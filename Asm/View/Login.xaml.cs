using Asm.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Asm.View
{
    public sealed partial class Login : ContentDialog
    {
        private static string valLogin = "PageLoad";
        public Login()
        {
            this.InitializeComponent();
        }

        private void Button_Register(Windows.UI.Xaml.Documents.Hyperlink sender, Windows.UI.Xaml.Documents.HyperlinkClickEventArgs args)
        {
            var rootFrame = Window.Current.Content as Frame;
            this.Hide();
            rootFrame.Navigate(typeof(View.Register1));
        }
        
        private async void Login_Submit(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

            Dictionary<String, String> LoginInfor = new Dictionary<string, string>();
            LoginInfor.Add("email", this.Email.Text);
            LoginInfor.Add("password", this.Password.Password);

            //Lay token
                HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(LoginInfor), System.Text.Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(Service.ApiHandle.API_LOGIN, content).Result;
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                //save file...
                    Debug.WriteLine(responseContent);
                //Doc token
                    TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(responseContent);

                //Luu token
                StorageFolder folder = ApplicationData.Current.LocalFolder;
                StorageFile file = await folder.CreateFileAsync("token.txt", CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(file, responseContent);
                
                var frame = Window.Current.Content as Frame;
                frame.Navigate(typeof(MainPage), valLogin);

            }
            else
            {
                Error errorObject = JsonConvert.DeserializeObject<Error>(responseContent);
                if (errorObject != null && errorObject.error.Count > 0)
                {
                    foreach (var key in errorObject.error.Keys)
                    {
                        var textMessage = this.FindName(key);
                        if (textMessage == null)
                        {
                            continue;
                        }
                        TextBlock textBlock = textMessage as TextBlock;
                        textBlock.Text = errorObject.error[key];
                        textBlock.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                        textBlock.Visibility = Visibility.Visible;
                    }
                }
            }
        }

    }

}
