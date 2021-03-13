using System;

namespace FaceRecognitionDotNet.Front.Models
{

    public sealed class ImageViewModel
    {

        #region Constructors

        public ImageViewModel(string name, string data, int width, int height)
        {
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentNullException(nameof(data));

            this.Name = name;
            this.Data = data;
            this.Width = width;
            this.Height = height;
        }

        #endregion

        #region Properties

        public string Data
        {
            get;
        }

        public int Height
        {
            get;
        }

        public string Name
        {
            get;
        }

        public int Width
        {
            get;
        }

        #endregion

    }

}