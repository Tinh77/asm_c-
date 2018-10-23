using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Asm.Service
{
    class Validate
    {

        public static bool ValidateinputTypeName(string input, TextBlock textBlock)
        {
            Regex regex = new Regex(@"^[a-zA-Z_ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶ" +
            "ẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợ" +
            "ụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\\s]+$");
            if (input.Length > 0)
            {
                if (!regex.IsMatch(input))
                {
                    textBlock.Text = "*Don't contain special characters";
                    textBlock.Foreground = new SolidColorBrush(Colors.Red);
                    textBlock.FontStyle = FontStyle.Italic;
                    return false;
                }
                else
                {
                    textBlock.Text = "";
                    return true;
                }
            }
            else
            {
                textBlock.Text = "*Not empty or null";
                textBlock.Foreground = new SolidColorBrush(Colors.Red);
                textBlock.FontStyle = FontStyle.Italic;
                return false;
            }
        }
        public static bool ValidateinputTypeEmail(string input, TextBlock textBlock)
        {
            Regex regex = new Regex(@"^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@"
        + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$");
            if (input.Length > 0)
            {
                if (!regex.IsMatch(input))
                {
                    textBlock.Text = "*Invalid: example@gmail.com";
                    textBlock.Foreground = new SolidColorBrush(Colors.Red);
                    textBlock.FontStyle = FontStyle.Italic;
                    return false;
                }
                else
                {
                    textBlock.Text = "";
                    return true;
                }
            }
            else
            {
                textBlock.Text = "*Not empty or null";
                textBlock.Foreground = new SolidColorBrush(Colors.Red);
                textBlock.FontStyle = FontStyle.Italic;
                return false;
            }
        }
        public static bool ValidateinputTypePassword(string input, TextBlock textBlock)
        {
            if (input.Length > 0)
            {
                if (input.Length < 8 || input.Length > 25)
                {
                    textBlock.Text = "*Must be from 8 to 25 characters";
                    textBlock.Foreground = new SolidColorBrush(Colors.Red);
                    textBlock.FontStyle = FontStyle.Italic;
                    return false;
                }
                else
                {
                    textBlock.Text = "";
                    return true;
                }
            }
            else
            {
                textBlock.Text = "*Not empty or null";
                textBlock.Foreground = new SolidColorBrush(Colors.Red);
                textBlock.FontStyle = FontStyle.Italic;
                return false;
            }
        }
        public static bool ValidateinputTypePhone(string input, TextBlock textBlock)
        {
            Regex regex = new Regex(@"^\s*\+?\s*([0-9][\s-]*){10,13}$");
            if (input.Length > 0)
            {
                if (!regex.IsMatch(input))
                {
                    textBlock.Text = "*Must be 10 or 11 numbers";
                    textBlock.Foreground = new SolidColorBrush(Colors.Red);
                    textBlock.FontStyle = FontStyle.Italic;
                    return false;
                }
                else
                {
                    textBlock.Text = "";
                    return true;
                }
            }
            else
            {
                textBlock.Text = "*Not empty or null";
                textBlock.Foreground = new SolidColorBrush(Colors.Red);
                textBlock.FontStyle = FontStyle.Italic;
                return false;
            }
        }

        public static bool ValidateinputTypeText(string input, TextBlock textBlock)
        {
            if (input.Length > 0)
            {
                textBlock.Text = "";
                return true;
            }
            else
            {
                textBlock.Text = "*Not empty or null";
                textBlock.Foreground = new SolidColorBrush(Colors.Red);
                textBlock.FontStyle = FontStyle.Italic;
                return false;
            }
        }
    }
}
