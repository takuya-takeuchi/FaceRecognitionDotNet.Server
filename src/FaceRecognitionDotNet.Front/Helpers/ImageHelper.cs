using System;

namespace FaceRecognitionDotNet.Front.Helpers
{

    internal static class ImageHelper
    {
        
        public static string ConvertToBase64(byte[] arrayImage)
        {
            var base64String = Convert.ToBase64String(arrayImage, 0, arrayImage.Length);
            return $"data:image/png;base64,{base64String}";
        }

    }

}
