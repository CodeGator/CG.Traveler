using Microsoft.Win32;
using System.Text.Json;

namespace CG.Traveler.Options
{
    /// <summary>
    /// This class contains configuration settings for the application.
    /// </summary>
    public class AppOptions
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains the size of the screen font.
        /// </summary>
        public int FontSize { get; set; }

        /// <summary>
        /// This property contains the default font family.
        /// </summary>
        public string FontFamily { get; set; }

        /// <summary>
        /// This property contains the color for the text glow.
        /// </summary>
        public string GlowColor { get; set; }

        /// <summary>
        /// This property contains the update speed for the screen saver.
        /// </summary>
        public int Speed { get; set; }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="AppOptions"/>
        /// class.
        /// </summary>
        public AppOptions()
        {
            // Set default values.
            FontSize = 60;
            FontFamily = "MarsVoyager Travelers";
            GlowColor = "Orange";
            Speed = 1000;
        }

        #endregion

        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method is used to read an instance of <see cref="AppOptions"/>
        /// from the registry.
        /// </summary>
        /// <returns>An <see cref="AppOptions"/> instance.</returns>
        public static AppOptions ReadFromRegistry()
        {
            // Create default options.
            var options = new AppOptions();

            // Look for our registry key.
            using (var key = Registry.CurrentUser.OpenSubKey(
                Globals.REGKEYNAME
                ))
            {
                // Did we succeed?
                if (null != key)
                {
                    // Read the json (if any).
                    var json = $"{key.GetValue(nameof(AppOptions)) ?? string.Empty}";

                    // Deserialize the json.
                    options = JsonSerializer.Deserialize<AppOptions>(
                        json
                        ) ?? new AppOptions();
                }
                else
                {
                    // Create our registry key.
                    using (var key2 = Registry.CurrentUser.CreateSubKey(
                        Globals.REGKEYNAME
                        ))
                    {
                        // Serialize the options.
                        var json = JsonSerializer.Serialize(options);

                        // Write the options.
                        key2.SetValue(nameof(AppOptions), json);
                    }
                }
            }

            // Return the options.
            return options;
        }

        // *******************************************************************

        /// <summary>
        /// This method write the specified <see cref="AppOptions"/> object to
        /// the registry.
        /// </summary>
        /// <param name="options"></param>
        public static void WriteToRegistry(
            AppOptions options
            )
        {
            // Look for our registry key.
            using (var key = Registry.CurrentUser.OpenSubKey(
                Globals.REGKEYNAME,
                true
                ))
            {
                // Did we succeed?
                if (null != key)
                {
                    // Serialize the options.
                    var json = JsonSerializer.Serialize(options);

                    // Write the options.
                    key.SetValue(nameof(AppOptions), json);
                }
                else
                {
                    // Create our registry key.
                    using (var key2 = Registry.CurrentUser.CreateSubKey(
                        Globals.REGKEYNAME
                        ))
                    {
                        // Serialize the options.
                        var json = JsonSerializer.Serialize(options);

                        // Write the options.
                        key2.SetValue(nameof(AppOptions), json);
                    }
                }
            }
        }

        #endregion
    }
}
