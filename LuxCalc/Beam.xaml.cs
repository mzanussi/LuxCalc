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
    public partial class Beam : PhoneApplicationPage
    {
        public Beam()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            bool isOk = true;

            if (DataValidation.IsValidNumberOrEmpty(tbDiameter))
            {
                // Empty message.
                tbDiameterMsg.Text = "";
            }
            else
            {
                tbDiameterMsg.Text = "Invalid number.";
                isOk = false;
            }

            if (DataValidation.IsValidNumberOrEmpty(tbAngle))
            {
                // Empty message.
                tbAngleMsg.Text = "";
            }
            else
            {
                tbAngleMsg.Text = "Invalid number.";
                isOk = false;
            }

            if (DataValidation.IsValidNumberOrEmpty(tbThrow))
            {
                // Empty message.
                tbThrowMsg.Text = "";
            }
            else
            {
                tbThrowMsg.Text = "Invalid number.";
                isOk = false;
            }

            if (!DataValidation.IsValidNumberOrEmpty(tbHorizontal))
            {
                isOk = false;
            }

            if (!DataValidation.IsValidNumberOrEmpty(tbVertical))
            {
                isOk = false;
            }

            if (isOk)
            {
                if (String.IsNullOrEmpty(tbHorizontal.Text))
                {
                    // must be beam calculations
                    if (String.IsNullOrEmpty(tbDiameter.Text))
                    {
                        tbAnswerMsg.Text = "(for beam diameter)";
                        double diameter = (2 * (Convert.ToDouble(tbThrow.Text) * (Math.Tan((Convert.ToDouble(tbAngle.Text) / (180.0 / Math.PI)) / 2))));
                        tbAnswer.Text = diameter.ToString("0.00");
                        tbAnswer.Text += " units";
                    }
                    else if (String.IsNullOrEmpty(tbAngle.Text))
                    {
                        tbAnswerMsg.Text = "(for beam angle)";
                        double angle = (2 * ((Math.Atan2((Convert.ToDouble(tbDiameter.Text) / 2), Convert.ToDouble(tbThrow.Text))) * (180 / Math.PI)));
                        tbAnswer.Text = angle.ToString("0.00");
                        tbAnswer.Text += " deg";
                    }
                    else
                    {
                        tbAnswerMsg.Text = "(for throw distance)";
                        double dist = (Convert.ToDouble(tbDiameter.Text) / 2) / (Math.Tan((Convert.ToDouble(tbAngle.Text) / (180 / Math.PI)) / 2));
                        tbAnswer.Text = dist.ToString("0.00");
                        tbAnswer.Text += " units";
                    }
                }
                else
                {
                    // throw distance
                    tbAnswerMsg.Text = "(for throw distance)";
                    double h = Convert.ToDouble(tbHorizontal.Text);
                    double v = Convert.ToDouble(tbVertical.Text);
                    double d = Math.Sqrt((h * h) + (v * v));
                    tbAnswer.Text = d.ToString("0.00");
                    tbAnswer.Text += " units";
                }
            }
        }

        private void EnableCalculateIfAnyTwoFilled()
        {
            if (DataValidation.AnyTwoFilled(tbDiameter, tbAngle, tbThrow) && tbHorizontal.Text.Trim() == "" && tbVertical.Text.Trim() == "")
            {
                btnCalculate.IsEnabled = true;
                tbCalculateMsg.Text = "";
                return;
            }
            if (DataValidation.AnyTwoFilled(tbHorizontal, tbVertical) && tbDiameter.Text.Trim() == "" && tbAngle.Text.Trim() == "" && tbThrow.Text.Trim() == "")
            {
                btnCalculate.IsEnabled = true;
                tbCalculateMsg.Text = "";
                return;
            }
            btnCalculate.IsEnabled = false;
            tbCalculateMsg.Text = "Specify any 2 values (top only or bottom only).";
        }

        private void tbDiameter_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (DataValidation.IsValidNumberOrEmpty(tbDiameter))
            {
                tbDiameterMsg.Text = "";
                EnableCalculateIfAnyTwoFilled();
            }
            else
            {
                tbDiameterMsg.Text = "Invalid number.";
            }
        }

        private void tbAngle_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (DataValidation.IsValidNumberOrEmpty(tbAngle))
            {
                tbAngleMsg.Text = "";
                EnableCalculateIfAnyTwoFilled();
            }
            else
            {
                tbAngleMsg.Text = "Invalid number.";
            }
        }

        private void tbThrow_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (DataValidation.IsValidNumberOrEmpty(tbThrow))
            {
                tbThrowMsg.Text = "";
                EnableCalculateIfAnyTwoFilled();
            }
            else
            {
                tbThrowMsg.Text = "Invalid number.";
            }
        }

        private void tbHorizontal_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DataValidation.IsValidNumberOrEmpty(tbHorizontal))
            {
                tbThrowMsg.Text = "";
                EnableCalculateIfAnyTwoFilled();
            }
        }

        private void tbVertical_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DataValidation.IsValidNumberOrEmpty(tbVertical))
            {
                tbThrowMsg.Text = "";
                EnableCalculateIfAnyTwoFilled();
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
            thisApp.Diameter = tbDiameter.Text;
            thisApp.Angle = tbAngle.Text;
            thisApp.Throw = tbThrow.Text;
            thisApp.BeamAnswerMsg = tbAnswerMsg.Text;
            thisApp.BeamAnswer = tbAnswer.Text;
            thisApp.Horizontal = tbHorizontal.Text;
            thisApp.Vertical = tbVertical.Text;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            // When we navigate to the page -
            // put the semi-completed log text in the application

            // Get a reference to the parent application
            App thisApp = App.Current as App;

            // Store the text in the application
            tbDiameter.Text = thisApp.Diameter;
            tbAngle.Text = thisApp.Angle;
            tbThrow.Text = thisApp.Throw;
            tbAnswerMsg.Text = thisApp.BeamAnswerMsg;
            tbAnswer.Text = thisApp.BeamAnswer;
            tbHorizontal.Text = thisApp.Horizontal;
            tbVertical.Text = thisApp.Vertical;

            base.OnNavigatedTo(e);
        }
    }
}