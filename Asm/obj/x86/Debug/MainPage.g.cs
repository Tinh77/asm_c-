﻿#pragma checksum "C:\Users\Tinh\source\repos\Asm\Asm\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "87891B5CB189CFAB458FC19898B4D045"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Asm
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 15
                {
                    this.MySplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3: // MainPage.xaml line 72
                {
                    global::Windows.UI.Xaml.Controls.Button element3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element3).Click += this.Button_Click;
                }
                break;
            case 4: // MainPage.xaml line 17
                {
                    this.StackIcon = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 5: // MainPage.xaml line 18
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element5 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element5).Click += this.RadioButton_Click;
                }
                break;
            case 6: // MainPage.xaml line 24
                {
                    this.RegisterBtn = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.RegisterBtn).Click += this.RadioButton_Click;
                }
                break;
            case 7: // MainPage.xaml line 30
                {
                    this.LoginBtn = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.LoginBtn).Click += this.RadioButton_Click;
                }
                break;
            case 8: // MainPage.xaml line 36
                {
                    this.MyAccount = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.MyAccount).Click += this.RadioButton_Click;
                }
                break;
            case 9: // MainPage.xaml line 42
                {
                    this.MySong = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.MySong).Click += this.RadioButton_Click;
                }
                break;
            case 10: // MainPage.xaml line 48
                {
                    this.LatestSong = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.LatestSong).Click += this.RadioButton_Click;
                }
                break;
            case 11: // MainPage.xaml line 54
                {
                    this.CreateSong = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.CreateSong).Click += this.RadioButton_Click;
                }
                break;
            case 12: // MainPage.xaml line 60
                {
                    this.SignOut = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.SignOut).Click += this.SignOutClick;
                }
                break;
            case 13: // MainPage.xaml line 69
                {
                    this.MainFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

