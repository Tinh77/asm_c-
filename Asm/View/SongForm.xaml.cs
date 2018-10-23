using Asm.Entity;
using Asm.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Asm.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SongForm : Page
    {
        private Song currentSong;
        private StorageFile thumbnailSong;
        private string currentUploadUrl;

        private bool validName = false;
        private bool validSinger = false;
        private bool validAuthor = false;
        private bool validThumbnail = false;
        private bool IsValidate = false;

        public SongForm()
        {
            this.currentSong = new Song();
            this.InitializeComponent();
        }

        private async void Add_Song(object sender, RoutedEventArgs e)
        {
            this.currentSong.name = NameSong.Text;
            this.currentSong.description = Description.Text;
            this.currentSong.singer = Singer.Text;
            this.currentSong.author = Author.Text;
            this.currentSong.thumbnail = ThumbnailURL.Text;
            this.currentSong.link = LinkSong.Text;

            var httpResponse = ApiHandle.Create_Song(this.currentSong);
            if (httpResponse.Result.StatusCode == HttpStatusCode.Created)
            {
                var dialog = new Windows.UI.Popups.MessageDialog("You created a new song successfully");
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("Closed") { Id = 1 });
                dialog.CancelCommandIndex = 1;
                await dialog.ShowAsync();
            }
            else
            {
                var errorJson = await httpResponse.Result.Content.ReadAsStringAsync();
                Error errResponse = JsonConvert.DeserializeObject<Error>(errorJson);
                if (errResponse.error.Count > 0)
                {
                    foreach (var errorField in errResponse.error.Keys)
                    {
                        if (this.FindName(errorField) is TextBlock textBlock)
                        {
                            textBlock.Text = "* " + errResponse.error[errorField];
                            textBlock.Visibility = Visibility.Visible;
                            textBlock.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                        }
                    }
                }
            }
        }

        private void Button_Reset(object sender, RoutedEventArgs e)
        {
            if (NameSong.Text != null
               || Description.Text != null
               || Singer.Text != null
               || Author.Text != null
               || ThumbnailURL.Text != null
               || LinkSong.Text != null)
            {
                NameSong.Text = String.Empty;
                Description.Text = String.Empty;
                Singer.Text = String.Empty;
                Author.Text = String.Empty;
                ThumbnailURL.Text = String.Empty;
                LinkSong.Text = String.Empty;
            }
        }

        private async void Upload_Image_Song(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

            this.thumbnailSong = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (this.thumbnailSong == null)
            {
                // User cancelled photo capture
                return;
            }
            HttpClient httpClient = new HttpClient();
            currentUploadUrl = await httpClient.GetStringAsync(Service.ApiHandle.GET_UPLOAD_URL);
            Debug.WriteLine("Upload url: " + currentUploadUrl);
            HttpUploadFile(currentUploadUrl, "myFile", "image/png");
        }

        public async void HttpUploadFile(string url, string paramName, string contentType)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";

            Stream rs = await wr.GetRequestStreamAsync();
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string header = string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n", paramName, "path_file", contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            // write file.
            Stream fileStream = await this.thumbnailSong.OpenStreamForReadAsync();
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);

            WebResponse wresp = null;
            try
            {
                wresp = await wr.GetResponseAsync();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                string imageUrl = reader2.ReadToEnd();
                Thumbnail.Source = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
                ThumbnailURL.Text = imageUrl;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error uploading file", ex.StackTrace);
                Debug.WriteLine("Error uploading file", ex.InnerException);
                if (wresp != null)
                {
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
        }

        private async void Chosse_Image_File(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            this.thumbnailSong = await openPicker.PickSingleFileAsync();
            HttpClient httpClient = new HttpClient();
            currentUploadUrl = await httpClient.GetStringAsync(Service.ApiHandle.GET_UPLOAD_URL);
            Debug.WriteLine("Upload url: " + currentUploadUrl);
            HttpUploadFile(currentUploadUrl, "myFile", "image/png");
        }

        private void song_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            validName = Validate.ValidateinputTypeText(NameSong.Text, name);
            CheckSubmitEnable();

        }

        private void song_singer_TextChanged(object sender, TextChangedEventArgs e)
        {
            validSinger = Validate.ValidateinputTypeText(Singer.Text, singer);
            CheckSubmitEnable();
        }

        private void song_author_TextChanged(object sender, TextChangedEventArgs e)
        {
            validAuthor = Validate.ValidateinputTypeText(Author.Text, author);
            CheckSubmitEnable();
        }
        
        private void CheckSubmitEnable()
        {
            if (!validAuthor || !validSinger || !validThumbnail || !validName)
            {
                IsValidate = false;
            }
            else
            {
                IsValidate = true;
            }
        }
    }
}
