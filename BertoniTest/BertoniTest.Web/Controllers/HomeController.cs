using System.Diagnostics;
using BertoniTest.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BertoniTest.Services.Interfaces;
using System.Collections.Generic;
using BertoniTest.Helpers.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BertoniTest.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Private Properties

        /// <summary>
        /// Instance of the Logger Service
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Instance of the Integration Service
        /// </summary>
        private readonly IIntegrationService _integrationService;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="integrationService"></param>
        public HomeController(ILogger<HomeController> logger, IIntegrationService integrationService)
        {
            _logger = logger;
            _integrationService = integrationService;
        }

        #endregion

        #region Actions

        /// <summary>
        /// Initial view action
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var albums = _integrationService.GetAlbumsAsync()?.Result;
            ViewData["AlbumList"] = albums;
            return View();
        }

        [HttpPost]
        public IActionResult AlbumPhotos([FromForm] Album model)
        {
            var photos = _integrationService.GetPhotos(model.Id).Result;
            return PartialView("_AlbumPhotos", photos);
        }

        /// <summary>
        /// Error catch action
        /// </summary>
        /// <returns></returns>

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion

    }
}
