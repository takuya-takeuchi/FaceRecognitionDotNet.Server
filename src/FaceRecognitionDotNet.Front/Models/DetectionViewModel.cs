using System.Collections.Generic;

namespace FaceRecognitionDotNet.Front.Models
{

    public sealed class DetectionViewModel
    {

        public ImageViewModel[] Images
        {
            get;
            set;
        }

        public IEnumerable<DetectAreaModel>[] DetectAreas
        {
            get;
            set;
        }

    }

}