using System;
using System.Drawing.Text;
using System.Globalization;
using System.IO;

namespace CG.Traveler.Extensions
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="PrivateFontCollection"/>
    /// type.
    /// </summary>
    internal static partial class PrivateFontCollectionExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method loads a true-type font from an embedded resource.
        /// </summary>
        /// <param name="fonts">The font collection to use for the operation.</param>
        /// <param name="resourceName">The name of the font resource.</param>
        /// <returns>The value of the <paramref name="fonts"/> parameter, for
        /// chaining methods calls together.
        /// </returns>
        public static PrivateFontCollection LoadFromResources(
            this PrivateFontCollection fonts,
            string resourceName
            )
        {
            // In this method we're writing an embedded font to disk so we
            //   can load it into the font collection.

            // Make a path for the font.
            var path = Path.Combine(
                Path.GetTempPath(),
                $"{Path.GetFileNameWithoutExtension(resourceName)}.ttf"
                );

            // Don't overwrite the file if it's already there.
            if (false == File.Exists(path))
            {
                // Get the resource as bytes.
                var bytes = Properties.Resources.ResourceManager.GetObject(
                        resourceName,
                        CultureInfo.CurrentCulture
                        ) as byte[];

                // Did we fail?
                if (null == bytes)
                {
                    // Panic!!
                    throw new ArgumentException(
                        message: $"Unable to load the resource: '{resourceName}'"
                        );
                }

                // Write the bytes to disk.
                File.WriteAllBytes(
                    path,
                    bytes
                    );
            }

            // Add the font to the collection.
            fonts.AddFontFile(path);

            // Return the font collection.
            return fonts;
        }

        #endregion
    }
}
