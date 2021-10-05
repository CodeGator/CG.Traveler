using CG.Traveler.Extensions;
using CG.Traveler.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CG.Traveler.Forms
{
    /// <summary>
    /// This class is the code-behind for the screen saver form.
    /// </summary>
    public partial class ScreenSaverForm : Form
    {
        // *******************************************************************
        // Types.
        // *******************************************************************

        #region Types

        /// <summary>
        /// This class contains WIN32 functions and constants.
        /// </summary>
        class NativeMethods
        {
            [DllImport("user32.dll")]
            public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

            [DllImport("user32.dll")]
            public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32.dll")]
            public static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

            public const int GWL_STYLE = -16;

            public const long WS_CHILD = 0x40000000;
        }

        #endregion

        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        /// <summary>
        /// This field contains the last known mour position.
        /// </summary>
        private Point mouseLocation;

        /// <summary>
        /// This field contains a flag for preview mode.
        /// </summary>
        private bool previewMode = false;

        /// <summary>
        /// This field contains the fonts for the screen saver.
        /// </summary>
        private PrivateFontCollection _fonts;

        /// <summary>
        /// This field contains layers of text to display.
        /// </summary>
        private readonly List<List<string>> _layers;

        /// <summary>
        /// This field contains a random number generator.
        /// </summary>
        private readonly RandomNumberGenerator _random;

        /// <summary>
        /// This field contains the options for the application.
        /// </summary>
        protected AppOptions _options;

        /// <summary>
        /// This field contains the foot print for a line.
        /// </summary>
        private Size _lineSize;

        /// <summary>
        /// This field contains the number of characters in a line.
        /// </summary>
        private int _lineLength;

        /// <summary>
        /// This field contains a temporary screen buffer.
        /// </summary>
        private Bitmap? _tempScreenImage;

        /// <summary>
        /// This field contains a temporary line buffer.
        /// </summary>
        private Bitmap? _tempLineImage;

        /// <summary>
        /// The field contains a temporary glow pen for layer 2.
        /// </summary>
        private Pen? _tempPen;

        /// <summary>
        /// This field contains a timer for the periodic processing.
        /// </summary>
        private Timer _timer;

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="ScreenSaverForm"/>
        /// class.
        /// </summary>
        public ScreenSaverForm()
        {
            // Make the form designer happy.
            InitializeComponent();

            // Set these styles for the form.
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // Create the layers collection.
            _layers = new List<List<string>>();

            // Create a random number generator.
            _random = RandomNumberGenerator.Create();

            // Create the font collection.
            _fonts = new PrivateFontCollection();

            // Create default options.
            _options = new AppOptions();

            // Create a timer.
            _timer = new Timer();
            _timer.Tick += _timer_Tick;
        }

        // *******************************************************************

        /// <summary>
        /// This constructor creates a new instance of the <see cref="ScreenSaverForm"/>
        /// class.
        /// </summary>
        /// <param name="bounds">The bounding rectangle for the form.</param>
        public ScreenSaverForm(
            Rectangle bounds
            ) : this()
        {
            // Place our window inside the rectangle.
            Bounds = bounds;
        }

        // *******************************************************************

        /// <summary>
        /// This constructor creates a new instance of the <see cref="ScreenSaverForm"/>
        /// class.
        /// </summary>
        /// <param name="PreviewWndHandle">The window for a preview parent.</param>
        public ScreenSaverForm(
            IntPtr PreviewWndHandle
            ) : this()
        {
            // Set the preview window as the parent of this window
            NativeMethods.SetParent(
                Handle, 
                PreviewWndHandle
                );

            // Set the child window style.
            NativeMethods.SetWindowLong(
                Handle, 
                NativeMethods.GWL_STYLE, 
                new IntPtr(
                    NativeMethods.GetWindowLong(Handle, NativeMethods.GWL_STYLE) |
                    NativeMethods.WS_CHILD
                    )
                );

            // Get the parent client's footprint.
            NativeMethods.GetClientRect(
                PreviewWndHandle, 
                out var ParentRect
                );

            // Place our window inside the parent
            Size = ParentRect.Size;
            Location = new Point(0, 0);

            // We are in preview mode.
            previewMode = true;
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
                // Read the options.
                _options = AppOptions.ReadFromRegistry();

                // Load the embedded font(s).
                _fonts.LoadFromResources(
                    "MarsVoyager Travelers"
                    );

                // Hide the cursor.
                Cursor.Hide();

                // Bring the form to the top of the z-order.
                TopMost = true;

                // Calculate the metrics for the lines.
                CalculateLineMetrics();

                // Create the layers.
                CreateLayers();

                // Start the timer.
                _timer.Interval = _options.Speed;
                _timer.Enabled = true;

                // Give the base class a chance.
                base.OnLoad(e);
            }
            catch (Exception ex)
            {
                // Tell the world what happened!
                MessageBox.Show(
                    this,
                    $"Failed to show the screen saver form! {Environment.NewLine}" +
                    $"Error: '{ex.Message}'",
                    $"{Application.ProductName} {Application.ProductVersion}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                // Close the application.
                Application.Exit();
            }
        }

        // *******************************************************************

        /// <summary>
        /// This method is called when the form closes, to raise the Closed 
        /// event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnClosed(
            EventArgs e
            )
        {
            // In this method we're closing the form.

            // Show the cursor.
            Cursor.Show();

            // Cleanup resources.
            _timer.Enabled = false;
            _timer.Dispose();
            _tempScreenImage?.Dispose();
            _tempLineImage?.Dispose();
            _random?.Dispose();
            _fonts?.Dispose();
            _tempPen?.Dispose();

            // Give the base class a chance.
            base.OnClosed(e);
        }

        // *******************************************************************

        /// <summary>
        /// This method is called when the mouse moves, to raise the MouseMove 
        /// event.
        /// </summary>
        /// <param name="e">The event arguments.</param>

        protected override void OnMouseMove(
            MouseEventArgs e
            )
        {
            // In this method we're responding to a mouse move.

            // We are NOT in preview mode?
            if (!previewMode)
            {
                // Has the mouse NOT yet moved before?
                if (!mouseLocation.IsEmpty)
                {
                    // Did the mouse move enough to be on purpose?
                    if (Math.Abs(mouseLocation.X - e.X) > 5 ||
                        Math.Abs(mouseLocation.Y - e.Y) > 5)
                    {
                        // Stop the application.
                        Application.Exit();
                    }
                }

                // Update current mouse location
                mouseLocation = e.Location;
            }

            // Give the base class a chance.
            base.OnMouseMove(e);
        }

        // *******************************************************************

        /// <summary>
        /// This is called when a mouse button is clicked, to raise the MouseClick
        /// event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnMouseClick(
            MouseEventArgs e
            )
        {
            // In this method we're responding to a mouse click.

            // We are NOT in preview mode?
            if (!previewMode)
            {
                // Stop the application.
                Application.Exit();
            }
                
            // Give the base class a chance.
            base.OnMouseClick(e);
        }

        // *******************************************************************

        /// <summary>
        /// This method is called when a key is pressed, to raise the KeyPress
        /// event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnKeyPress(
            KeyPressEventArgs e
            )
        {
            // In this method we're responding to a key click.

            // We are NOT in preview mode?
            if (!previewMode)
            {
                // Stop the application.
                Application.Exit();
            }

            // Give the base class a chance.
            base.OnKeyPress(e);
        }

        // *******************************************************************

        /// <summary>
        /// This method paints the form.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnPaint(
            PaintEventArgs e
            )
        {
            // In this method we're painting the screen saver,

            // Get the font family.
            var fontFamily = _fonts.Families.FirstOrDefault(
                x => x.Name == _options.FontFamily
                ) ?? FontFamily.GenericSerif;

            // Get the font size.
            var fontSize = _options.FontSize;

            // Get the glow color.
            var glowColor = Color.FromName(
                _options.GlowColor
                );

            // Should we create the pen?
            if (null == _tempPen)
            {
                // Create the custom glow pen.
                _tempPen = new Pen(
                    glowColor, 
                    3
                    );
            }

            // Paint layer 0.
            PaintLayer(
                e.Graphics,
                fontFamily,
                FontStyle.Italic,
                fontSize,
                Pens.White,
                0.2f,
                _layers[0]
                );

            // Paint layer 1.
            PaintLayer(
                e.Graphics,
                fontFamily,
                FontStyle.Regular,
                fontSize,
                _tempPen,
                0.6f,
                _layers[1]
                );
        }

        #endregion

        // *******************************************************************
        // Private methods.
        // *******************************************************************

        #region Private methods

        /// <summary>
        /// This method calculates metrics for the display, including how many
        /// characters are required to span the screen, and what the footprint
        /// of such a line should be, in pixels.
        /// </summary>
        private void CalculateLineMetrics()
        {
            // In this method we're calculating basic numbers that we'll need,
            //   later, to fill the display with random text.

            // Get the font family.
            var fontFamily = _fonts.Families.FirstOrDefault(
                x => x.Name == _options.FontFamily
                ) ?? FontFamily.GenericSerif;

            // Get the font size.
            var fontSize = _options.FontSize;

            _lineSize = new Size();
            _lineLength = 0;

            // Create the font.
            using (var font = new Font(
                fontFamily,
                (float)fontSize,
                FontStyle.Regular
                ))
            {
                // Get the device context.
                using (var gdi = Graphics.FromHwnd(Handle))
                {
                    // Loop until we've filled the client width.
                    while (_lineSize.Width < ClientRectangle.Width)
                    {
                        // Get a line of Z's (Z to guestimate the average
                        //   width of a character, in this font).
                        var line = new string(
                            'Z',
                            _lineLength += 10
                            );

                        // Measure the line.
                        _lineSize = gdi.MeasureString(
                            line,
                            font
                            ).ToSize();
                    }
                }
            }

            // The "MarsVoyager Travelers" font has an odd symbol that 
            //   I haven't yet been able to map to a specific character,
            //   but, it seems to love hanging out at the end of the lines,
            //   so, we'll expand the line size, a bit, to shove any unwanted
            //   symbols out of sight.
            _lineLength += (int)(_lineLength * 1.6f);

            // My calculation seems to want the font to be higher than it
            //   really is, resulting in too much space between lines. I
            //   don't know if that's something odd with the font, or, 
            //   something odd with my math. In either case, this line
            //   of code is scaling the height down a bit, to compensate.
            _lineSize.Height -= (int)fontSize / 3;
        }

        // *******************************************************************

        /// <summary>
        /// This method creates the various layers for the form.
        /// </summary>
        private void CreateLayers()
        {
            // In this method we're creating the layers for the screen saver.

            // Clear any old layers.
            _layers.Clear();

            // Loop and create the layers.
            for (var x = 0; x < 2; x++)
            {
                // Create the new layer.
                _layers.Add(new List<string>());

                // Loop and create lines for the layer.
                for (var y = 0; y < Height; y += (int)_lineSize.Height)
                {
                    // We'll fill the layer with actual text later. For now,
                    //   the spaces are fine.

                    // Add a string of spaces.
                    _layers[x].Add(
                        new string(' ', _lineLength)
                    );
                }
            }
        }

        // *******************************************************************

        /// <summary>
        /// This method is called with the timer period has elapsed.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void _timer_Tick(object? sender, EventArgs e)
        {
            // In this method we're moving text around, replacing symbols, etc,
            //   trying to make our text display more interesting to watch.

            // Loop through the layers.
            for (var x = 0; x < _layers.Count; x++)
            {
                // Loop through the lines.
                for (var y = 0; y < _layers[x].Count; y++)
                {
                    // Get some replacement characters.
                    var replacementText = _random.NextString(
                        _lineLength
                        );

                    // Copy the line.
                    var sb = new StringBuilder(_layers[x][y]);

                    // Loop and replace a random number of characters.
                    for (var z = 0; z < _random.Next(0, _lineLength); z++)
                    {
                        // Get a random character location.
                        var index = _random.Next(0, _lineLength);

                        // Should we set the character to a space?
                        if (_random.Next(1, 100) is >= 0 and <= 50)
                        {
                            // Set the character to a space.
                            sb[index] = ' ';
                        }
                        else
                        {
                            // Overwrite the specified character.
                            sb[index] = replacementText[index];
                        }
                    }

                    // Should we scroll this line?
                    if (_random.Next(1, 100) is >= 10 and <= 20)
                    {
                        // Scroll the line by one character.
                        sb = new StringBuilder(
                            sb[_lineLength - 1] + sb.ToString(0, _lineLength - 1)
                            );
                    }

                    // Copy the changes back to the line.
                    _layers[x][y] = sb.ToString();
                }
            }

            // Force a repaint.
            Invalidate();
        }

        // *******************************************************************

        /// <summary>
        /// This method paints an individual layer of text on the screen.
        /// </summary>
        /// <param name="graphics">The device context to use for the operation/.</param>
        /// <param name="fontFamily">The font family to use for the operation.</param>
        /// <param name="fontStyle">The font style to use for the operation.</param>
        /// <param name="fontSize">The font size to use for the operation.</param>
        /// <param name="glowPen">The glow pen to use for the operation.</param>
        /// <param name="opacity">The opacity to use for the operation.</param>
        /// <param name="lines">The lines to use for the operation.</param>
        private void PaintLayer(
            Graphics graphics,
            FontFamily fontFamily,
            FontStyle fontStyle,
            decimal fontSize,
            Pen glowPen,
            float opacity,
            List<string> lines
            )
        {
            // In this method we're painting all the lines for a layer
            //   on the screen.

            // Should we create the image?
            if (null == _tempScreenImage)
            {
                // Create a scratch image to draw on.
                _tempScreenImage = new Bitmap(
                    ClientRectangle.Width,
                    ClientRectangle.Height,
                    PixelFormat.Format32bppArgb
                    );
            }

            // Create a device context from the image.
            using (var tempGraphics = Graphics.FromImage(_tempScreenImage))
            {
                // Clear the image.
                tempGraphics.Clear(
                    Color.Transparent
                    );

                // Loop through all the lines.
                for (var x = 0; x < lines.Count; x++)
                {
                    // Calculate a footprint for the line of text.
                    var rect = new Rectangle(
                        0,
                        x * _lineSize.Height,
                        _lineSize.Width,
                        _lineSize.Height
                        );

                    // Draw the text with a glow effect.
                    DrawStringWithGlow(
                        tempGraphics,
                        rect,
                        fontFamily,
                        FontStyle.Regular,
                        (int)fontSize,
                        glowPen,
                        lines[x]
                        );
                }
            }

            // Draw the image to the screen.
            DrawImageWithOpacity(
                graphics,
                _tempScreenImage,
                ClientRectangle,
                0,
                0,
                _tempScreenImage.Width,
                _tempScreenImage.Height,
                GraphicsUnit.Pixel,
                opacity
                );
        }

        // *******************************************************************

        /// <summary>
        /// This method draws the specified image using an opacity value.
        /// </summary>
        /// <param name="graphics">The device context to use for the operation.</param>
        /// <param name="image">The source image to use for the operation.</param>
        /// <param name="destRect">The destination rectangle to use for the 
        /// operation.</param>
        /// <param name="srcX">The x-coordinate of the upper-left corner of the
        /// source image.</param>
        /// <param name="srcY">The y-coordinate of the upper-left corner of the
        /// source image.</param>
        /// <param name="srcWidth">The width of the source image.</param>
        /// <param name="srcHeight">The height of the source image.</param>
        /// <param name="srcUnit">The units of measure used to determine the
        /// source rectangle.</param>
        /// <param name="opacity">The opacity to use for the operation.</param>
        private void DrawImageWithOpacity(
            Graphics graphics,
            Image image,
            Rectangle destRect,
            float srcX,
            float srcY,
            float srcWidth,
            float srcHeight,
            GraphicsUnit srcUnit,
            float opacity
            )
        {
            // In this method we're drawing an image with opacity.

            // Setup a matrix for the changing the alpha channel.
            float[][] matrixItems =
            {
                new float[]{1, 0, 0, 0, 0},
                new float[]{0, 1, 0, 0, 0},
                new float[]{0, 0, 1, 0, 0},
                new float[]{0, 0, 0, opacity, 0},
                new float[]{0, 0, 0, 0, 1}
            };
            var colorMatrix = new ColorMatrix(matrixItems);

            // Create image attributes to control the drawing.
            using (var imageAtt = new ImageAttributes())
            {
                // Apply the matrix.
                imageAtt.SetColorMatrix(
                    colorMatrix,
                    ColorMatrixFlag.Default,
                    ColorAdjustType.Bitmap
                    );

                // Draw the image.
                graphics.DrawImage(
                    image,
                    destRect,
                    srcX,
                    srcY,
                    srcWidth,
                    srcHeight,
                    srcUnit,
                    imageAtt
                    );
            }
        }

        // *******************************************************************

        /// <summary>
        /// This method draws a string using a glow effect.
        /// </summary>
        /// <param name="graphics">The device context to use for the operation.</param>
        /// <param name="destRect">The destination rectangle to use for the 
        /// operation.</param>
        /// <param name="fontFamily">The font family to use for the operation.</param>
        /// <param name="fontStyle">The font style to use for the operation.</param>
        /// <param name="fontSize">The font size to use for the operation.</param>
        /// <param name="glowPen">The pen to use for the glow operation.</param>
        /// <param name="text">The text to use for the operation.</param>
        private void DrawStringWithGlow(
            Graphics graphics,
            Rectangle destRect,
            FontFamily fontFamily,
            FontStyle fontStyle,
            int fontSize,
            Pen glowPen,
            string text
            )
        {
            // In this method we're drawing text with a glow effect.

            // The size of our glow effect.
            var glowSize = 6;

            // Make it look all purdy.
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Should we create the image?
            if (null == _tempLineImage)
            {
                // Create a scratchpad image to work with.
                _tempLineImage = new Bitmap(
                    destRect.Width / glowSize,
                    destRect.Height / glowSize,
                    PixelFormat.Format32bppArgb
                    );
            }

            // Create a graphics path.
            using (var tempPath = new GraphicsPath())
            {
                // Add the string to the path.
                tempPath.AddString(
                    text,
                    fontFamily,
                    (int)fontStyle,
                    graphics.DpiY * fontSize / 72,
                    new Point(0, 0),
                    StringFormat.GenericTypographic
                    );

                // Create a device context to draw with.
                using (var tempGraphics = Graphics.FromImage(_tempLineImage))
                {
                    // Clear the image's background.
                    tempGraphics.Clear(
                        Color.Transparent
                        );

                    // Make it look all purdy.
                    tempGraphics.SmoothingMode = SmoothingMode.AntiAlias;

                    // Create a matrix to control the glow effect.
                    using (var tempMatrix = new Matrix(
                        1.0f / glowSize,
                        0,
                        0,
                        1.0f / glowSize,
                        -(1.0f / glowSize),
                        -(1.0f / glowSize)
                        ))
                    {
                        // Set the matrix in the device context.
                        tempGraphics.Transform = tempMatrix;

                        // Draw the path, which is really our text.
                        tempGraphics.DrawPath(
                            glowPen,
                            tempPath
                            );
                    }

                    // Now draw the image resized up to the original footprint,
                    //   thereby creating the glow effect we're after.
                    graphics.DrawImage(
                        _tempLineImage,
                        destRect,
                        0,
                        0,
                        _tempLineImage.Width,
                        _tempLineImage.Height,
                        GraphicsUnit.Pixel
                        );

                    // Create another temporary matrix.
                    using (var tempMatrix2 = new Matrix())
                    {
                        // We need to create a translation to account for
                        //   any offset in the client rectangle.
                        tempMatrix2.Translate(
                            destRect.X,
                            destRect.Y
                            );

                        // Move the path.
                        tempPath.Transform(
                            tempMatrix2
                            );
                    }

                    // Refill the repositioned path so the characters stand
                    //   out against our nicely glowy backdrop.
                    graphics.FillPath(
                        Brushes.Black,
                        tempPath
                        );
                }
            }
        }

        #endregion
    }
}
