using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace LuxCalc
{
    public partial class Power : PhoneApplicationPage
    {
        public Power()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            bool isOk = true;

            if (DataValidation.IsValidNumberOrEmpty(tbWatts))
            {
                // Empty message.
                tbWattsMsg.Text = "";
            }
            else
            {
                tbWattsMsg.Text = "Invalid number.";
                isOk = false;
            }

            if (DataValidation.IsValidNumberOrEmpty(tbVolts))
            {
                // Empty message.
                tbVoltsMsg.Text = "";
            }
            else
            {
                tbVoltsMsg.Text = "Invalid number.";
                isOk = false;
            }

            if (DataValidation.IsValidNumberOrEmpty(tbAmps))
            {
                // Empty message.
                tbAmpsMsg.Text = "";
            }
            else
            {
                tbAmpsMsg.Text = "Invalid number.";
                isOk = false;
            }

            if (isOk)
            {
                if (String.IsNullOrEmpty(tbWatts.Text))
                {
                    tbAnswerMsg.Text = "(for watts)";
                    tbAnswer.Text = (Convert.ToDouble(tbVolts.Text) * Convert.ToDouble(tbAmps.Text)).ToString("0.00");
                    tbAnswer.Text += " watts";
                }
                else if (String.IsNullOrEmpty(tbVolts.Text))
                {
                    tbAnswerMsg.Text = "(for volts)";
                    // division by zero handled by data validation
                    tbAnswer.Text = (Convert.ToDouble(tbWatts.Text) / Convert.ToDouble(tbAmps.Text)).ToString("0.00");
                    tbAnswer.Text += " volts";
                }
                else
                {
                    tbAnswerMsg.Text = "(for amps)";
                    // division by zero handled by data validation
                    tbAnswer.Text = (Convert.ToDouble(tbWatts.Text) / Convert.ToDouble(tbVolts.Text)).ToString("0.00");
                    tbAnswer.Text += " amps";
                }
            }
        }

        private void EnableCalculateIfAnyTwoFilled()
        {
            if (DataValidation.AnyTwoFilled(tbWatts, tbVolts, tbAmps))
            {
                btnCalculate.IsEnabled = true;
                tbCalculateMsg.Text = "";
            }
            else
            {
                btnCalculate.IsEnabled = false;
                tbCalculateMsg.Text = "Specify any 2 values.";
            }
        }

        private void tbWatts_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (DataValidation.IsValidNumberOrEmpty(tbWatts))
            {
                tbWattsMsg.Text = "";
                EnableCalculateIfAnyTwoFilled();
            }
            else
            {
                tbWattsMsg.Text = "Invalid number.";
            }
        }

        private void tbVolts_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (DataValidation.IsValidNumberOrEmpty(tbVolts))
            {
                tbVoltsMsg.Text = "";
                EnableCalculateIfAnyTwoFilled();
            }
            else
            {
                tbVoltsMsg.Text = "Invalid number.";
            }
        }

        private void tbAmps_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (DataValidation.IsValidNumberOrEmpty(tbAmps))
            {
                tbAmpsMsg.Text = "";
                EnableCalculateIfAnyTwoFilled();
            }
            else
            {
                tbAmpsMsg.Text = "Invalid number.";
            }
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // When we leave the page -
            // store the semi-completed log text in the application

            // Get a reference to the parent application
            App thisApp = App.Current as App;

            // Store the text in the application
            thisApp.Watts = tbWatts.Text;
            thisApp.Volts = tbVolts.Text;
            thisApp.Amps = tbAmps.Text;
            thisApp.PowerAnswerMsg = tbAnswerMsg.Text;
            thisApp.PowerAnswer = tbAnswer.Text;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            // When we navigate to the page -
            // put the semi-completed log text in the application

            // Get a reference to the parent application
            App thisApp = App.Current as App;

            // Store the text in the application
            tbWatts.Text = thisApp.Watts;
            tbVolts.Text = thisApp.Volts;
            tbAmps.Text = thisApp.Amps;
            tbAnswerMsg.Text = thisApp.PowerAnswerMsg;
            tbAnswer.Text = thisApp.PowerAnswer;

            base.OnNavigatedTo(e);
        }
    }
}