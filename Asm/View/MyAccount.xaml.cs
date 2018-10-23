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
    public sealed partial class MyAccount : Page
    {
        private int choose;
        public MyAccount()
        {
            this.InitializeComponent();
            GetMember();
        }

        private async void GetMember()
        {
            Member member = Service.ApiHandle.Loggedin_Member;
            NameMember.Text = member.firstName + member.lastName;
            Uri uri = new Uri(member.avatar, UriKind.Absolute);
            BitmapImage bmImage = new BitmapImage(uri);
            this.Avatar.Source = bmImage;
            Email.Text = member.email;
            Phone.Text = member.phone;
            Address.Text = member.address;
            Birthday.Text = member.birthday;
        }
    }
}
