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
    public partial class Conversions : PhoneApplicationPage
    {
        public Conversions()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            bool isOk = true;

            if (DataValidation.IsValidNumberOrEmpty(tbFootcandles))
            {
                // Empty message.
                tbFootcandlesMsg.Text = "";
            }
            else
            {
                tbFootcandlesMsg.Text = "Invalid number.";
                isOk = false;
            }

            if (DataValidation.IsValidNumberOrEmpty(tbLux))
            {
                // Empty message.
                tbLuxMsg.Text = "";
            }
            else
            {
                tbLuxMsg.Text = "Invalid number.";
                isOk = false;
            }

            if (isOk)
            {
                if (!String.IsNullOrEmpty(tbFootcandles.Text))
                {
                    tbAnswerMsg.Text = "(for lux, or lumens/m" + Char.ToString('\u00b2') + ")";
                    tbAnswer.Text = (Convert.ToDouble(tbFootcandles.Text) * 10.764).ToString("0.000");
                    tbAnswer.Text += " lux";
                }
                else if (!String.IsNullOrEmpty(tbLux.Text))
                {
                    tbAnswerMsg.Text = "(for footcandles, or lumens/ft" + Char.ToString('\u00b2') + ")";
                    tbAnswer.Text = (Convert.ToDouble(tbLux.Text) * 0.0929).ToString("0.000");
                    tbAnswer.Text += " fc";
                }
            }
        }

        private void EnableCalculateIfAnyOneFilled()
        {
            if ((tbFootcandles.Text.Trim() == "" && tbLux.Text.Trim() == "") || (tbFootcandles.Text.Trim() != "" && tbLux.Text.Trim() != ""))
            {
                btnCalculate.IsEnabled = false;
                tbCalculateMsg.Text = "Specify only 1 value.";
            }
            else
            {
                btnCalculate.IsEnabled = true;
                tbCalculateMsg.Text = "";
            }
        }

        private void tbFootcandles_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (DataValidation.IsValidNumberOrEmpty(tbFootcandles))
            {
                tbFootcandlesMsg.Text = "";
                EnableCalculateIfAnyOneFilled();
            }
            else
            {
                tbFootcandlesMsg.Text = "Invalid number.";
            }
        }

        private void tbLux_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (DataValidation.IsValidNumberOrEmpty(tbLux))
            {
                tbLuxMsg.Text = "";
                EnableCalculateIfAnyOneFilled();
            }
            else
            {
                tbLuxMsg.Text = "Invalid number.";
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
            thisApp.Footcandles = tbFootcandles.Text;
            thisApp.Lux = tbLux.Text;
            thisApp.ConversionsAnswerMsg = tbAnswerMsg.Text;
            thisApp.ConversionsAnswer = tbAnswer.Text;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            // When we navigate to the page -
            // put the semi-completed log text in the application

            // Get a reference to the parent application
            App thisApp = App.Current as App;

            // Store the text in the application
            tbFootcandles.Text = thisApp.Footcandles;
            tbLux.Text = thisApp.Lux;
            tbAnswerMsg.Text = thisApp.ConversionsAnswerMsg;
            tbAnswer.Text = thisApp.ConversionsAnswer;

            base.OnNavigatedTo(e);
        }
    }
}