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
    public sealed partial class Register1 : Page
    {

        private string currentUploadUrl;
        private StorageFile photo;
        private Member currentMember;
        private bool resultFirstName = false;
        private bool resultLastName = false;
        private bool resultEmail = false;
        private bool resultPassword = false;
        private bool resultPhone = false;
        private bool resultAddress = false;
        private bool IsValidate = false;

        public Register1()
        {
            this.currentMember = new Member();
            this.InitializeComponent();
            BirthdayPicker.Date = DateTime.Now;
            CheckSubmitEnable();
        }

        private async void Do_Register(object sender, TappedRoutedEventArgs e)
        {
            this.currentMember.firstName = this.FirstName.Text;
            this.currentMember.lastName = this.LastName.Text;
            this.currentMember.avatar = this.AvatarUrl.Text;
            this.currentMember.address = this.Address.Text;
            this.currentMember.introduction = this.Introduction.Text;
            this.currentMember.phone = this.Phone.Text;
            this.currentMember.email = this.Email.Text;
            this.currentMember.password = this.Password.Password;

            var httpResponseMessage = ApiHandle.Sign_Up(this.currentMember);
            if (httpResponseMessage.Result.StatusCode == HttpStatusCode.Created)
            {
                IsValidate = true;
                var dialog = new Windows.UI.Popups.MessageDialog("Bạn đã tạo mới tài khoản thành công");
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("Đóng") { Id = 1 });
                dialog.CancelCommandIndex = 1;
                await dialog.ShowAsync();
            }
            else
            {
                var errorJson = await httpResponseMessage.Result.Content.ReadAsStringAsync();
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

        

        private void BirthdayPicker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            this.currentMember.birthday = sender.Date.Value.ToString("yyyy-MM-dd");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            this.currentMember.gender = Int32.Parse(radio.Tag.ToString());
        }


        private async void Choose_Image(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

            this.photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (this.photo == null)
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
            Stream fileStream = await this.photo.OpenStreamForReadAsync();
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
                Avatar.Source = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
                AvatarUrl.Text = imageUrl;
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

        private void Do_Reset(object sender, RoutedEventArgs e)
        {
            if (FirstName.Text != null
                || LastName.Text != null
                || AvatarUrl.Text != null
                || Phone.Text != null
                || Address.Text != null
                || Introduction.Text != null
                || Email.Text != null
                || Password.Password != null
                || ConfirmPassword.Password != null)
            {
                FirstName.Text = String.Empty;
                LastName.Text = String.Empty;
                AvatarUrl.Text = String.Empty;
                Phone.Text = String.Empty;
                Address.Text = String.Empty;
                Introduction.Text = String.Empty;
                Email.Text = String.Empty;
                Password.Password = String.Empty;
                ConfirmPassword.Password = String.Empty;
            }
        }

        private async void Do_Login(Windows.UI.Xaml.Documents.Hyperlink sender, Windows.UI.Xaml.Documents.HyperlinkClickEventArgs args)
        {
            Login login = new Login();
            await login.ShowAsync();
        }

        private async void Get_Image_File(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            this.photo = await openPicker.PickSingleFileAsync();
            HttpClient httpClient = new HttpClient();
            currentUploadUrl = await httpClient.GetStringAsync(Service.ApiHandle.GET_UPLOAD_URL);
            Debug.WriteLine("Upload url: " + currentUploadUrl);
            HttpUploadFile(currentUploadUrl, "myFile", "image/png");

        }

        private void box_firstname_TextChanged(object sender, TextChangedEventArgs e)
        {
            resultFirstName = Validate.ValidateinputTypeName(FirstName.Text, firstName);
            Debug.WriteLine(resultFirstName);
            CheckSubmitEnable();
        }

        private void box_lastname_TextChanged(object sender, TextChangedEventArgs e)
        {
            resultLastName = Validate.ValidateinputTypeName(LastName.Text, lastName);
            CheckSubmitEnable();
        }

        private void box_email_TextChanged(object sender, TextChangedEventArgs e)
        {
            resultEmail = Validate.ValidateinputTypeEmail(Email.Text, email);
            CheckSubmitEnable();
        }

        private void pwd_password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            resultPassword = Validate.ValidateinputTypePassword(Password.Password, password);
            CheckSubmitEnable();
        }

        private void box_phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            resultPhone = Validate.ValidateinputTypePhone(Phone.Text, phone);
            CheckSubmitEnable();
        }

        private void box_address_TextChanged(object sender, TextChangedEventArgs e)
        {
            resultAddress = Validate.ValidateinputTypeText(Address.Text, address);
            CheckSubmitEnable();
        }
        private void CheckSubmitEnable()
        {
            if (!resultAddress || !resultEmail || !resultFirstName || !resultLastName || !resultPassword || !resultPhone)
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
