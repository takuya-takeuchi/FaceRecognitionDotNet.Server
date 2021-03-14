using System;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;

namespace FaceRecognitionDotNet.Front.Models
{

    public sealed class RegistrationViewModel
    {

        #region Properties
        
        public Guid Id
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        [StringLength(32)]
        public string FirstName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        [StringLength(32)]
        public string LastName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please choose photo image")]
        [Display(Name = "Profile Photo")]
        public IFormFile Photo
        {
            get;
            set;
        }

        #endregion

    }

}