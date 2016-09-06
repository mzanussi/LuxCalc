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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace LuxCalc
{
    public partial class App : Application
    {
        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;

            // Standard Silverlight initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = false;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Disable the application idle detection by setting the UserIdleDetectionMode property of the
                // application's PhoneApplicationService object to Disabled.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

        }

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
            if (e.IsApplicationInstancePreserved)
            {
                // MBZ: returning from dormant state, no need to restore state.
                // do so at your own peril and app speed considerations.
                WasTombstoned = false;
            }
            else
            {
                // MBZ: returning from a tombstoning, restore state obj.
                WasTombstoned = true;
                LoadFromStateObject();
            }
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
            // MBZ: iso storage save and/or state obj save
            SaveToStateObject();
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        public static bool WasTombstoned { get; private set; }

        public string Watts = "";
        public string Volts = "";
        public string Amps = "";
        public string PowerAnswerMsg = "";
        public string PowerAnswer = "";
        public string BeamAnswerMsg = "";
        public string BeamAnswer = "";
        public string ConversionsAnswerMsg = "";
        public string ConversionsAnswer = "";
        public string VoltageDropAnswerMsg = "";
        public string VoltageDropAnswer = "";
        public string OhmsAnswerMsg = "";
        public string OhmsAnswer = "";
        public string Diameter = "";
        public string Angle = "";
        public string Throw = "";
        public string Horizontal = "";
        public string Vertical = "";
        public string Footcandles = "";
        public string Lux = "";
        public string VoltageDropCurrent = "";
        public string VoltageDropConductorLength = "";
        public string VoltageDropAwg = "";
        public string OVolts = "";
        public string OAmps = "";
        public string Ohms = "";

        private void SaveToStateObject()
        {
            SaveTextToStateObject("Watts", Watts);
            SaveTextToStateObject("Volts", Volts);
            SaveTextToStateObject("Amps", Amps);
            SaveTextToStateObject("PowerAnswerMsg", PowerAnswerMsg);
            SaveTextToStateObject("PowerAnswer", PowerAnswer);
            SaveTextToStateObject("BeamAnswerMsg", BeamAnswerMsg);
            SaveTextToStateObject("BeamAnswer", BeamAnswer);
            SaveTextToStateObject("ConversionsAnswerMsg", ConversionsAnswerMsg);
            SaveTextToStateObject("ConversionsAnswer", ConversionsAnswer);
            SaveTextToStateObject("VoltageDropAnswerMsg", VoltageDropAnswerMsg);
            SaveTextToStateObject("VoltageDropAnswer", VoltageDropAnswer);
            SaveTextToStateObject("OhmsAnswerMsg", OhmsAnswerMsg);
            SaveTextToStateObject("OhmsAnswer", OhmsAnswer);
            SaveTextToStateObject("Diameter", Diameter);
            SaveTextToStateObject("Angle", Angle);
            SaveTextToStateObject("Throw", Throw);
            SaveTextToStateObject("Horizontal", Horizontal);
            SaveTextToStateObject("Vertical", Vertical);
            SaveTextToStateObject("Footcandles", Footcandles);
            SaveTextToStateObject("Lux", Lux);
            SaveTextToStateObject("VoltageDropCurrent", VoltageDropCurrent);
            SaveTextToStateObject("VoltageDropConductorLength", VoltageDropConductorLength);
            SaveTextToStateObject("VoltageDropAwg", VoltageDropAwg);
            SaveTextToStateObject("OVolts", OVolts);
            SaveTextToStateObject("OAmps", OAmps);
            SaveTextToStateObject("Ohms", Ohms);
        }

        private void LoadFromStateObject()
        {
            LoadTextFromStateObject("Watts", out Watts);
            LoadTextFromStateObject("Volts", out Volts);
            LoadTextFromStateObject("Amps", out Amps);
            LoadTextFromStateObject("PowerAnswerMsg", out PowerAnswerMsg);
            LoadTextFromStateObject("PowerAnswer", out PowerAnswer);
            LoadTextFromStateObject("BeamAnswerMsg", out BeamAnswerMsg);
            LoadTextFromStateObject("BeamAnswer", out BeamAnswer);
            LoadTextFromStateObject("ConversionsAnswerMsg", out ConversionsAnswerMsg);
            LoadTextFromStateObject("ConversionsAnswer", out ConversionsAnswer);
            LoadTextFromStateObject("VoltageDropAnswerMsg", out VoltageDropAnswerMsg);
            LoadTextFromStateObject("VoltageDropAnswer", out VoltageDropAnswer);
            LoadTextFromStateObject("OhmsAnswerMsg", out OhmsAnswerMsg);
            LoadTextFromStateObject("OhmsAnswer", out OhmsAnswer);
            LoadTextFromStateObject("Diameter", out Diameter);
            LoadTextFromStateObject("Angle", out Angle);
            LoadTextFromStateObject("Throw", out Throw);
            LoadTextFromStateObject("Horizontal", out Horizontal);
            LoadTextFromStateObject("Vertical", out Vertical);
            LoadTextFromStateObject("Footcandles", out Footcandles);
            LoadTextFromStateObject("Lux", out Lux);
            LoadTextFromStateObject("VoltageDropCurrent", out VoltageDropCurrent);
            LoadTextFromStateObject("VoltageDropConductorLength", out VoltageDropConductorLength);
            LoadTextFromStateObject("VoltageDropAwg", out VoltageDropAwg);
            LoadTextFromStateObject("OVolts", out OVolts);
            LoadTextFromStateObject("OAmps", out OAmps);
            LoadTextFromStateObject("Ohms", out Ohms);
        }

        private void SaveTextToStateObject(string filename, string text)
        {
            IDictionary<string, object> stateStore = PhoneApplicationService.Current.State;
            stateStore.Remove(filename);
            stateStore.Add(filename, text);
        }

        private bool LoadTextFromStateObject(string filename, out string result)
        {
            IDictionary<string, object> stateStore = PhoneApplicationService.Current.State;
            result = "";
            if (!stateStore.ContainsKey(filename))
            {
                return false;
            }
            result = (string)stateStore[filename];
            return true;
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion
    }
}