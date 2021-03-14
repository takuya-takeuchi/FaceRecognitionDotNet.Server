using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using FaceRecognitionDotNet.Front.Helpers;
using FaceRecognitionDotNet.Front.Models;
using FaceRecognitionDotNet.Front.Services.Interfaces;

namespace FaceRecognitionDotNet.Front.Controllers
{

    public sealed class ListController : Controller
    {

        #region Fields

        private readonly IFaceRegistrationService _FaceRegistrationService;

        #endregion

        #region Constructors

        public ListController(IFaceRegistrationService faceRegistrationService)
        {
            this._FaceRegistrationService = faceRegistrationService;
        }

        #endregion

        #region Methods

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAll()
        {
            var results = await this._FaceRegistrationService.GetAll();
            
            var persons = new List<PersonViewModel>();

            foreach (var result in results)
            {
                await using var ms = new MemoryStream(result.Photo.Data);
                using var bitmap = Image.FromStream(ms);

                var photo = ImageHelper.ConvertToBase64(result.Photo.Data);

                persons.Add(new PersonViewModel
                {
                    FirstName = result.Demographics.FirstName,
                    LastName = result.Demographics.LastName,
                    Photo = new ImageViewModel("", photo, 0, 0),
                    CreatedDateTime = result.Demographics.CreatedDateTime
                });
            }

            return this.View(nameof(this.Index), new ListViewModel{ Persons = persons});
        }

    #region Helpers

    [NonAction]
    private static string ViewImage(byte[] arrayImage)
    {
        var base64String = Convert.ToBase64String(arrayImage, 0, arrayImage.Length);
        return $"data:image/png;base64,{base64String}";
    }

    #endregion

    #endregion

}

}
