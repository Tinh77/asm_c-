﻿using Asm.Entity;
using Asm.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Asm
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static bool isLogged = false;
        private static string valLogin = "loginFalse";
        private static Windows.Storage.StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
        public MainPage()
        {
            CheckAuthentication();
            this.InitializeComponent();

        }

        private async void CheckAuthentication()
        {

            // trường hợp chưa có token key trong hệ thống.
            if (Service.ApiHandle.TOKEN_STRING == null)
            {
                // Lấy token từ trong file.
                if (await folder.TryGetItemAsync("token.txt") != null)
                {
                    try
                    {
                        Windows.Storage.StorageFile file = await folder.GetFileAsync("token.txt");
                        string fileContent = await Windows.Storage.FileIO.ReadTextAsync(file);
                        TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(fileContent);
                        Service.ApiHandle.TOKEN_STRING = token.token;
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                }
            }
            // Check tính hợp lệ của token của api.
            if (Service.ApiHandle.TOKEN_STRING != null)
            {
                if (await Service.ApiHandle.GetInformation())
                {
                    isLogged = true;
                    var frame = Window.Current.Content as Frame;
                    var currentPage = frame.Content as Page;
                    var btnLogin = currentPage.FindName("LoginBtn") as RadioButton;
                    btnLogin.Visibility = Visibility.Collapsed;
                    var dialog = new Windows.UI.Popups.MessageDialog("Welcome to our app!");
                    dialog.Commands.Add(new Windows.UI.Popups.UICommand("Closed") { Id = 1 });
                    dialog.CancelCommandIndex = 1;
                    await dialog.ShowAsync();
                }
            }

            if (!isLogged)
            {
                Login login = new Login();
                await login.ShowAsync();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.MySplitView.IsPaneOpen = !this.MySplitView.IsPaneOpen;
            if (!this.MySplitView.IsPaneOpen)
            {
                this.StackIcon.Margin = new Thickness(10, 50, 0, 0);
            }
            else
            {
                this.StackIcon.Margin = new Thickness(50, 50, 0, 0);
            }
        }

        private async void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            switch (radio.Tag.ToString())
            {
                case "Home":
                    this.MainFrame.Navigate(typeof(View.Home));
                    break;
                case "Register":
                    this.MainFrame.Navigate(typeof(View.Register1));
                    break;
                case "Login":
                    Login login = new Login();
                    await login.ShowAsync();
                    break;
                case "MyAccount":
                    this.MainFrame.Navigate(typeof(View.MyAccount));
                    break;
                case "MySong":
                    this.MainFrame.Navigate(typeof(View.ListSong));
                    break;
                case "LatestSong":
                    this.MainFrame.Navigate(typeof(View.LatestSong));
                    break;
                case "CreateSong":
                    this.MainFrame.Navigate(typeof(View.SongForm));
                    break;
                case "SignOut":
                    this.MainFrame.Navigate(typeof(View.SongForm));
                    break;
                default:
                    break;
            }

        }


        private async void SignOutClick(object sender, RoutedEventArgs e)
        {

            StorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync("token.txt");
            if (storageFile != null)
            {
                await storageFile.DeleteAsync();

                var frame = Window.Current.Content as Frame;
                var currentPage = frame.Content as Page;
                var radioBtn1 = currentPage.FindName("LoginBtn");
                RadioButton btnLogin = radioBtn1 as RadioButton;

                var radioBtn2 = currentPage.FindName("MyAccount");
                var radioBtn3 = currentPage.FindName("MySong");
                var radioBtn4 = currentPage.FindName("LatestSong");
                var radioBtn5 = currentPage.FindName("CreateSong");
                var radioBtn6 = currentPage.FindName("SignOut");
                RadioButton btnMyAcc = radioBtn2 as RadioButton;
                RadioButton btnMySong = radioBtn3 as RadioButton;
                RadioButton btnNewSong = radioBtn4 as RadioButton;
                RadioButton btnLatestSong = radioBtn5 as RadioButton;
                RadioButton btnSignOut = radioBtn6 as RadioButton;
                btnMyAcc.Visibility = Visibility.Collapsed;
                btnMySong.Visibility = Visibility.Collapsed;
                btnNewSong.Visibility = Visibility.Collapsed;
                btnLatestSong.Visibility = Visibility.Collapsed;
                btnSignOut.Visibility = Visibility.Collapsed;
                btnLogin.Visibility = Visibility.Visible;
                var dialog = new Windows.UI.Popups.MessageDialog("Goodbye. See you again!");
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("Closed") { Id = 1 });
                dialog.CancelCommandIndex = 1;
                await dialog.ShowAsync();
            }
            else
            {
                Debug.WriteLine("Trong nay la khu vuc xoa file yoken.");
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            valLogin = e.Parameter as string;
            if (valLogin == "PageLoad")
            {
                var frame = Window.Current.Content as Frame;
                var currentPage = frame.Content as Page;
                var radioBtn1 = currentPage.FindName("LoginBtn");
                var radioBtn2 = currentPage.FindName("MyAccount");
                var radioBtn3 = currentPage.FindName("MySong");
                var radioBtn4 = currentPage.FindName("LatestSong");
                var radioBtn5 = currentPage.FindName("CreateSong");
                var radioBtn6 = currentPage.FindName("SignOut");
                RadioButton btnLogin = radioBtn1 as RadioButton;
                RadioButton btnMyAcc = radioBtn2 as RadioButton;
                RadioButton btnMySong = radioBtn3 as RadioButton;
                RadioButton btnNewSong = radioBtn4 as RadioButton;
                RadioButton btnLatestSong = radioBtn5 as RadioButton;
                RadioButton btnSignOut = radioBtn6 as RadioButton;
                btnMyAcc.Visibility = Visibility.Visible;
                btnMySong.Visibility = Visibility.Visible;
                btnNewSong.Visibility = Visibility.Visible;
                btnLatestSong.Visibility = Visibility.Visible;
                btnSignOut.Visibility = Visibility.Visible;
                btnLogin.Visibility = Visibility.Collapsed;
            }
        }
    }
}
