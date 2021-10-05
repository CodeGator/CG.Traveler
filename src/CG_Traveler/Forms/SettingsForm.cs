using CG.Traveler.Options;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CG.Traveler.Forms
{
    /// <summary>
    /// This class is the code-behind for the settings form.
    /// </summary>
    public partial class SettingsForm : Form
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        /// <summary>
        /// This field contains the options for the application.
        /// </summary>
        protected AppOptions _options;

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="SettingsForm"/>
        /// class.
        /// </summary>
        public SettingsForm()
        {
            // Make the form designer happy.
            InitializeComponent();

            // Create default options.
            _options = new AppOptions();
        }

        #endregion

        // *******************************************************************
        // Protected methods.
        // *******************************************************************

        #region Protected methods

        /// <summary>
        /// This method is called when the form is first loaded, to raise the 
        /// Load event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnLoad(
            EventArgs e
            )
        {
            // In this method we're initializing the form.

            try
            {
                // Set the caption for the form.
                Text = $"{Application.ProductName} " +
                    $"{Application.ProductVersion} Settings";

                // Read the options.
                _options = AppOptions.ReadFromRegistry();

                // Update the font labels.
                _labelFontSize.Text = $"Font Size: {_options.FontSize}";
                _labelSpeed.Text = $"Speed (milliseconds): {_options.Speed:N0}";

                // Bind the font size track bar.
                _trackBarFontSize.Value = _options.FontSize;

                // Bind the speed track bar.
                _trackBarSpeed.Value = _options.Speed;

                // Bind the font family.
                _comboBoxFontFamily.DataSource = new string[]
                {
                    "MarsVoyager Travelers"
                };
                var index = _comboBoxFontFamily.Items.IndexOf(_options.FontFamily);
                _comboBoxFontFamily.SelectedIndex = index;

                // Bind the glow color.
                _comboBoxGlowColor.DataSource = Enum.GetNames<KnownColor>()
                    .Where(x => x != "Transparent" &&
                                x != "ActiveBorder" &&
                                x != "ActiveCaption" &&
                                x != "ActiveCaptionText" &&
                                x != "ActiveText" &&
                                x != "AppWorkspace" &&
                                x != "Black" &&
                                x != "Control" &&
                                x != "ControlDark" &&
                                x != "ControlDarkDark" &&
                                x != "ControlLight" &&
                                x != "ControlLightLight" &&
                                x != "ControlText" &&
                                x != "Desktop" &&
                                x != "Highlight" &&
                                x != "HighlightText" &&
                                x != "HotTrack" &&
                                x != "InactiveBorder" &&
                                x != "InactiveCaption" &&
                                x != "InactiveCaptionText" &&
                                x != "Info" &&
                                x != "InfoText" &&
                                x != "Menu" &&
                                x != "MenuText" &&
                                x != "ScrollBar" &&
                                x != "Window" &&
                                x != "WindowFrame" &&
                                x != "WindowText" &&
                                x != "ButtonFace" &&
                                x != "ButtonHighlight" &&
                                x != "ButtonShadow" &&
                                x != "GradientActiveCaption" &&
                                x != "GradientInactiveCaption" &&
                                x != "MenuBar" &&
                                x != "MenuHighlight"
                                )
                    .OrderBy(x => x)
                    .ToList();
                index = _comboBoxGlowColor.Items.IndexOf(_options.GlowColor);
                _comboBoxGlowColor.SelectedIndex = index;

                // Give the base class a chance.
                base.OnLoad(e);
            }
            catch (Exception ex)
            {
                // Tell the world.
                MessageBox.Show(
                    $"Failed to save the options!{Environment.NewLine}" +
                    $"Error: {ex.Message}",
                    $"{Application.ProductName} {Application.ProductVersion}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                // Close the form.
                Close();
            }
        }

        #endregion

        // *******************************************************************
        // Private methods.
        // *******************************************************************

        #region Private methods

        /// <summary>
        /// This method is called when the ok button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void _buttonOk_Click(
            object sender, 
            EventArgs e
            )
        {
            // In this method we're saving any changes to the options.

            try
            {
                // Update the options.
                _options.FontFamily = $"{_comboBoxFontFamily.SelectedValue}";
                _options.FontSize = _trackBarFontSize.Value;
                _options.GlowColor = $"{_comboBoxGlowColor.SelectedValue}";
                _options.Speed = _trackBarSpeed.Value;

                // Save the options.
                AppOptions.WriteToRegistry(_options);
            }
            catch (Exception ex)
            {
                // Tell the world.
                MessageBox.Show(
                    $"Failed to save the options!{Environment.NewLine}" +
                    $"Error: {ex.Message}",
                    $"{Application.ProductName} {Application.ProductVersion}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }

            // Close the form.
            Close();
        }

        // *******************************************************************

        /// <summary>
        /// This method is called when the cancel button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void _buttonCancel_Click(
            object sender, 
            EventArgs e
            )
        {
            // In this method we're just closing the form, since there are
            //   no changes to save.

            // Close the form.
            Close();
        }

        // *******************************************************************

        /// <summary>
        /// This method is called when the about button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void _buttonAbout_Click(
            object sender, 
            EventArgs e
            )
        {
            // In this method we're showing the about box.

            // Should the about box.
            new AboutForm().ShowDialog(this);
        }

        // *******************************************************************

        /// <summary>
        /// This method is called when the trackbar value changes.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void _trackBarFontSize_ValueChanged(
            object sender, 
            EventArgs e
            )
        {
            // In this method we're updating the label for the font size.

            // Update the font size label.
            _labelFontSize.Text = $"Font Size: {_trackBarFontSize.Value}";
        }

        // *******************************************************************

        /// <summary>
        /// This method is called when the trackbar value changes.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void _trackBarSpeed_ValueChanged(
            object sender, 
            EventArgs e
            )
        {
            // In this method we're updating the label for the speed.

            // Update speed the label.
            _labelSpeed.Text = $"Speed (milliseconds): {_trackBarSpeed.Value:N0}";
        }

        #endregion
    }
}
