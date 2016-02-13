using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LuxCalc
{
    public static class DataValidation
    {
        public static bool IsValidNumberOrEmpty(TextBox tb)
        {
            tb.Text = tb.Text.Trim();

            if (tb.Text == "")
            {
                // Default background color.
                tb.Background = new SolidColorBrush(Color.FromArgb(0xBF, 0xFF, 0xFF, 0xFF));
                return true;
            }

            try
            {
                // Convert to double.
                double number = Convert.ToDouble(tb.Text);

                // Verify weight > 0.
                if (number <= 0.0)
                {
                    tb.Background = new SolidColorBrush(Colors.Red);
                    return false;
                }
            }
            catch
            {
                tb.Background = new SolidColorBrush(Colors.Red);
                return false;
            }

            // Default background color.
            tb.Background = new SolidColorBrush(Color.FromArgb(0xBF, 0xFF, 0xFF, 0xFF));
            return true;
        }

        public static bool AnyTwoFilled(TextBox tb1, TextBox tb2, TextBox tb3)
        {
            if (tb1.Text.Trim() != "" && tb2.Text.Trim() != "" && tb3.Text.Trim() == "")
            {
                return true;
            }
            else if (tb1.Text.Trim() != "" && tb2.Text.Trim() == "" && tb3.Text.Trim() != "")
            {
                return true;
            }
            else if (tb1.Text.Trim() == "" && tb2.Text.Trim() != "" && tb3.Text.Trim() != "")
            {
                return true;
            }

            return false;
        }

        public static bool AnyTwoFilled(TextBox tb1, TextBox tb2)
        {
            if (tb1.Text.Trim() != "" && tb2.Text.Trim() != "")
            {
                return true;
            }

            return false;
        }
    }
}
