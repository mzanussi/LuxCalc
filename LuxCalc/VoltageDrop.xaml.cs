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
    public partial class VoltageDrop : PhoneApplicationPage
    {
        private double ohms = 0.0;  // resistance per 1000 ft. @ 20C (ohms/kilofoot)

        public VoltageDrop()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            bool isOk = true;

            if (DataValidation.IsValidNumberOrEmpty(tbCurrent))
            {
                // Empty message.
                tbCurrentMsg.Text = "";
            }
            else
            {
                tbCurrentMsg.Text = "Invalid number.";
                isOk = false;
            }

            if (DataValidation.IsValidNumberOrEmpty(tbConductorLength))
            {
                // Empty message.
                tbConductorLengthMsg.Text = "";
            }
            else
            {
                tbConductorLengthMsg.Text = "Invalid number.";
                isOk = false;
            }

            if (isOk)
            {
                double i = Convert.ToDouble(tbCurrent.Text);
                double r = 2 * Convert.ToDouble(tbConductorLength.Text) * ohms / 1000;
                tbAnswer.Text = (i * r).ToString("0.000");
                tbAnswer.Text += " volts";
                lbAwgMsg.Text = TranslateAWG(slAwg.Value).ToString() + "; wire resistance=" + r + " Ω";
            }
        }

        private void EnableCalculateIfAllFilled()
        {
            if ((tbCurrent.Text.Trim() != "" && tbConductorLength.Text.Trim() != ""))
            {
                btnCalculate.IsEnabled = true;
                tbCalculateMsg.Text = "";
            }
            else
            {
                btnCalculate.IsEnabled = false;
                tbCalculateMsg.Text = "Specify all values.";
            }
        }

        private void tbCurrent_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (DataValidation.IsValidNumberOrEmpty(tbCurrent))
            {
                tbCurrentMsg.Text = "";
                EnableCalculateIfAllFilled();
            }
            else
            {
                tbCurrentMsg.Text = "Invalid number.";
            }
        }

        private void tbConductorLength_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (DataValidation.IsValidNumberOrEmpty(tbConductorLength))
            {
                tbConductorLengthMsg.Text = "";
                EnableCalculateIfAllFilled();
            }
            else
            {
                tbConductorLengthMsg.Text = "Invalid number.";
            }
        }

        private double TranslateAWG(double value)
        {
            if (value <= 0.0)
            {
                ohms = 0.0983;
                return 0.0;
            }
            else if (value <= 1.0)
            {
                ohms = 0.124;
                return 1.0;
            }
            else if (value <= 2.0)
            {
                ohms = 0.1563;
                return 2.0;
            }
            else if (value <= 3.0)
            {
                ohms = 0.197;
                return 3.0;
            }
            else if (value <= 4.0)
            {
                ohms = 0.2485;
                return 4.0;
            }
            else if (value <= 5.0)
            {
                ohms = 0.3133;
                return 5.0;
            }
            else if (value <= 6.0)
            {
                ohms = 0.3951;
                return 6.0;
            }
            else if (value <= 7.0)
            {
                ohms = 0.4982;
                return 7.0;
            }
            else if (value <= 8.0)
            {
                ohms = 0.6282;
                return 8.0;
            }
            else if (value <= 9.0)
            {
                ohms = 0.7921;
                return 9.0;
            }
            else if (value <= 10.0)
            {
                ohms = 0.9989;
                return 10.0;
            }
            else if (value <= 11.0)
            {
                ohms = 1.26;
                return 11.0;
            }
            else if (value <= 12.0)
            {
                ohms = 1.588;
                return 12.0;
            }
            else if (value <= 13.0)
            {
                ohms = 2.003;
                return 13.0;
            }
            else if (value <= 14.0)
            {
                ohms = 2.525;
                return 14.0;
            }
            else if (value <= 15.0)
            {
                ohms = 3.184;
                return 15.0;
            }
            else if (value <= 16.0)
            {
                ohms = 4.016;
                return 16.0;
            }
            else if (value <= 17.0)
            {
                ohms = 5.064;
                return 17.0;
            }
            else if (value <= 18.0)
            {
                ohms = 6.385;
                return 18.0;
            }
            else if (value <= 19.0)
            {
                ohms = 8.051;
                return 19.0;
            }
            else if (value <= 20.0)
            {
                ohms = 10.15;
                return 20.0;
            }
            else if (value <= 21.0)
            {
                ohms = 12.8;
                return 21.0;
            }
            else if (value <= 22.0)
            {
                ohms = 16.14;
                return 22.0;
            }

            ohms = 0.0983;
            return 0.0;
        }

        private void slAwg_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbAwgMsg != null)
            {
                lbAwgMsg.Text = TranslateAWG(e.NewValue).ToString();
                EnableCalculateIfAllFilled();
            }
        }

        private void slAwg_Loaded(object sender, RoutedEventArgs e)
        {
            lbAwgMsg.Text = TranslateAWG(slAwg.Value).ToString();
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // When we leave the page -
            // store the semi-completed log text in the application

            // Get a reference to the parent application
            App thisApp = App.Current as App;

            // Store the text in the application
            thisApp.VoltageDropCurrent = tbCurrent.Text;
            thisApp.VoltageDropConductorLength = tbConductorLength.Text;
            thisApp.VoltageDropAwg = slAwg.Value.ToString();
            thisApp.VoltageDropAnswerMsg = tbAnswerMsg.Text;
            thisApp.VoltageDropAnswer = tbAnswer.Text;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            // When we navigate to the page -
            // put the semi-completed log text in the application

            // Get a reference to the parent application
            App thisApp = App.Current as App;

            // Store the text in the application
            tbCurrent.Text = thisApp.VoltageDropCurrent;
            tbConductorLength.Text = thisApp.VoltageDropConductorLength;
            if (thisApp.VoltageDropAwg.Length > 0)
            {
                slAwg.Value = Convert.ToDouble(thisApp.VoltageDropAwg);
            }
            tbAnswerMsg.Text = thisApp.VoltageDropAnswerMsg;
            tbAnswer.Text = thisApp.VoltageDropAnswer;

            base.OnNavigatedTo(e);
        }
    }
}