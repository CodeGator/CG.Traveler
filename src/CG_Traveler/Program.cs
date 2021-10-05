using CG.Traveler.Forms;
using System;
using System.Windows.Forms;

namespace CG.Traveler
{
    /// <summary>
    ///  This class contains the logic for the process.
    /// </summary>
    internal static class Program
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method represents the main entry point for the application.
        /// </summary>
        /// <param name="args">Optional command line arguments.</param>
        [STAThread]
        static void Main(string[] args)
        {
            // In this method we're running the screen saver according to
            //   the arguments passed from Windows (if any).

            // Use high DPI mode, if available.
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            // Use visual styles.
            Application.EnableVisualStyles();

            // Disable the 'use compatible text rendering' flag.
            Application.SetCompatibleTextRenderingDefault(false);

            // Set a top level error handler.
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                // Tell the world.
                MessageBox.Show(
                    $"FATAL ERROR!{Environment.NewLine}" +
                    $"Error: {(e.ExceptionObject as Exception)?.Message}",
                    $"{Application.ProductName} {Application.ProductVersion}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            };

            // Are there arguments?
            if (args.Length > 0)
            {
                var firstArgument = args[0].ToLower().Trim();
                var secondArgument = string.Empty;

                // Are there more than 2 arguments?
                if (firstArgument.Length > 2)
                {
                    // Copy the arguments.
                    secondArgument = firstArgument.Substring(3).Trim();
                    firstArgument = firstArgument.Substring(0, 2);
                }

                // Are there 2 arguments?
                else if (args.Length > 1)
                {
                    // Copy the argument.
                    secondArgument = args[1];
                }

                // Was configured mode specified?
                if ("/c" == firstArgument)
                {
                    // Run the application with the settings form.
                    Application.Run(new SettingsForm());
                }

                // Was preview mode specified?
                else if ("/p" == firstArgument)
                {
                    // Is the second argument missing?
                    if (string.IsNullOrEmpty(secondArgument))
                    {
                        // Tell the world what happened.
                        MessageBox.Show(
                            "Sorry, but the expected window handle was not provided.",
                            $"{Application.ProductName} {Application.ProductVersion}", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Exclamation
                            );

                        return; // Nothing else to do.
                    }

                    // Get the handle to the preview window.
                    var previewWndHandle = new IntPtr(
                        long.Parse(secondArgument)
                        );

                    // Run the application with the form in a preview window.
                    Application.Run(
                        new ScreenSaverForm(previewWndHandle)
                        );
                }

                // Was full-screen mode specified?
                else if ("/s" == firstArgument)
                {
                    // Loop through all the screens.
                    foreach (Screen screen in Screen.AllScreens)
                    {
                        // Create a form for the screen.
                        var screensaver = new ScreenSaverForm(screen.Bounds);

                        // Show the form.
                        screensaver.Show();
                    }

                    // Run the application.
                    Application.Run();
                }

                // Undefined argument(s)?
                else
                {
                    // Tell the world what happened.
                    MessageBox.Show(
                        $"Sorry, but the command line argument '{firstArgument}' " +
                        $"is not valid.",
                        $"{Application.ProductName} {Application.ProductVersion}",
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Exclamation
                        );
                }
            }

            // No arguments - treat like /c
            else
            {
                // Run the application with the settings form.
                Application.Run(new SettingsForm());
            }
        }

        #endregion
    }
}
