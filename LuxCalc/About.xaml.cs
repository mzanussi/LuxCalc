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
using System.Reflection;

namespace LuxCalc
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
            Display();
        }

        private void Display()
        {
            string str = Assembly.GetExecutingAssembly().FullName;
            txtVersion.Text = "v" + str.Split('=')[1].Split(',')[0] + " (9/5/2016)";
        }
    }
}