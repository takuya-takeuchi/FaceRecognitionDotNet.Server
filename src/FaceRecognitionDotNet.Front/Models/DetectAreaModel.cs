namespace FaceRecognitionDotNet.Front.Models
{

    public sealed class DetectAreaModel
    {

        #region Constructors

        public DetectAreaModel(int x, int y, int width, int height, float confidence)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Confidence = confidence;
        }

        #endregion

        #region Properties

        public float Confidence
        {
            get;
        }

        public int Height
        {
            get;
        }

        public int X
        {
            get;
        }

        public int Y
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