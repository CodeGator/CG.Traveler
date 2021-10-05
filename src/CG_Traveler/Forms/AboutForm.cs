using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CG.Traveler.Forms
{
    /// <summary>
    /// This class is the code-behind for the about form.
    /// </summary>
    public partial class AboutForm : Form
    {
        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="AboutForm"/>
        /// class.
        /// </summary>
        public AboutForm()
        {
            // Make the form designer happy.
            InitializeComponent();
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

            // Set the caption for the form.
            Text = $"About {Application.ProductName} {Application.ProductVersion}";

            // Set the title.
            _labelTitle.Text = $"{Application.ProductName} {Application.ProductVersion}";

            // Give the base class a chance.
            base.OnLoad(e);
        }

        #endregion

        // *******************************************************************
        // Private methods.
        // *******************************************************************

        #region Private methods

        /// <summary>
        /// This method is called when the user clicks the codegator link.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void _linkLabelCodeGator_LinkClicked(
            object sender, 
            LinkLabelLinkClickedEventArgs e
            )
        {
            // In this method we're opening the codegator link.

            // Open the link.
            Process.Start(
                "explorer.exe", 
                "http://codegator.com"
                );
        }

        // *******************************************************************

        /// <summary>
        /// This method is called when the user clicks the codegator link.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void _linkLabelCode_LinkClicked(
            object sender, 
            LinkLabelLinkClickedEventArgs e
            )
        {
            // In this method we're opening the project link.

            // Open the link.
            Process.Start(
                "explorer.exe", 
                "http://github.com/codegator/cg.traveler"
                );
        }

        // *******************************************************************

        /// <summary>
        /// This method is called when the user clicks the codegator link.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void _linkLabelFont_LinkClicked(
            object sender, 
            LinkLabelLinkClickedEventArgs e
            )
        {
            // In this method we're opening the font link.

            // Open the link.
            Process.Start(
                "explorer.exe", 
                "https://www.therpf.com/forums/threads/travelers-font.299039/"
                );
        }

        // *******************************************************************

        /// <summary>
        /// This method is called when the user clicks the screen saver link.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void _linkLabelScreenSaver_LinkClicked(
            object sender, 
            LinkLabelLinkClickedEventArgs e
            )
        {
            // In this method we're opening the screen saver project link.

            // Open the link.
            Process.Start(
                "explorer.exe",
                "https://sites.harding.edu/fmccown/screensaver/screensaver.html"
                );
        }

        #endregion


    }
}
