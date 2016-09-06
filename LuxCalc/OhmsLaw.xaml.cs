using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace LuxCalc
{
    public partial class OhmsLaw : PhoneApplicationPage
    {
        public OhmsLaw()
        {
            InitializeComponent();
        }
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            bool isOk = true;

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

            if (DataValidation.IsValidNumberOrEmpty(tbOhms))
            {
                // Empty message.
                tbOhmsMsg.Text = "";
            }
            else
            {
                tbOhmsMsg.Text = "Invalid number.";
                isOk = false;
            }

            if (isOk)
            {
                if (String.IsNullOrEmpty(tbVolts.Text))
                {
                    tbAnswerMsg.Text = "(for volts)";
                    tbAnswer.Text = (Convert.ToDouble(tbAmps.Text) * Convert.ToDouble(tbOhms.Text)).ToString("0.00");
                    tbAnswer.Text += " volts";
                }
                else if (String.IsNullOrEmpty(tbAmps.Text))
                {
                    tbAnswerMsg.Text = "(for amps)";
                    // division by zero handled by data validation
                    tbAnswer.Text = (Convert.ToDouble(tbVolts.Text) / Convert.ToDouble(tbOhms.Text)).ToString("0.00");
                    tbAnswer.Text += " amp";
                }
                else
                {
                    tbAnswerMsg.Text = "(for Ω)";
                    // division by zero handled by data validation
                    tbAnswer.Text = (Convert.ToDouble(tbVolts.Text) / Convert.ToDouble(tbAmps.Text)).ToString("0.00");
                    tbAnswer.Text += " Ω";
                }
            }
        }

        private void EnableCalculateIfAnyTwoFilled()
        {
            if (DataValidation.AnyTwoFilled(tbVolts, tbAmps, tbOhms))
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

        private void tbOhms_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (DataValidation.IsValidNumberOrEmpty(tbOhms))
            {
                tbOhmsMsg.Text = "";
                EnableCalculateIfAnyTwoFilled();
            }
            else
            {
                tbOhmsMsg.Text = "Invalid number.";
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
            thisApp.OVolts = tbVolts.Text;
            thisApp.OAmps = tbAmps.Text;
            thisApp.Ohms = tbOhms.Text;
            thisApp.OhmsAnswerMsg = tbAnswerMsg.Text;
            thisApp.OhmsAnswer = tbAnswer.Text;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            // When we navigate to the page -
            // put the semi-completed log text in the application

            // Get a reference to the parent application
            App thisApp = App.Current as App;

            // Store the text in the application
            tbVolts.Text = thisApp.OVolts;
            tbAmps.Text = thisApp.OAmps;
            tbOhms.Text = thisApp.Ohms;
            tbAnswerMsg.Text = thisApp.OhmsAnswerMsg;
            tbAnswer.Text = thisApp.OhmsAnswer;

            base.OnNavigatedTo(e);
        }
    }
}