using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FaceRecognitionDotNet.Front.Models
{

    public sealed class ListViewModel
    {

        #region Properties
        
        public IEnumerable<PersonViewModel> Persons
        {
            get;
            set;
        }

        #endregion

    }

}