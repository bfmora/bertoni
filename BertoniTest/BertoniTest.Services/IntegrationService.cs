using System;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using BertoniTest.Helpers.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BertoniTest.Services.Interfaces;

namespace BertoniTest.Services
{
    public class IntegrationService : IIntegrationService
    {
        #region Private Properties

        /// <summary>
        /// Configuraciones del aplicativo
        /// </summary>
        private readonly AppSettings _appSettings;

        /// <summary>
        /// Instance of the Logger Service
        /// </summary>
        private readonly ILogger<IntegrationService> _logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appSettings"></param>
        public IntegrationService(ILogger<IntegrationService> logger, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            _logger = logger;
        }

        #endregion

        /// <summary>
        /// Retrieves a complete list of albums
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Album>> GetAlbumsAsync()
        {
            IEnumerable<Album> albums = new List<Album> { new Album() { Title = "--- Seleccione Album ---", Id = 0 } };
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponse = await client.GetAsync(_appSettings.AlbumEndpoint);
                    httpResponse.EnsureSuccessStatusCode();
                    string responseBody = await httpResponse.Content.ReadAsStringAsync();

                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        // Converts the response
                        albums = JsonConvert.DeserializeObject<IEnumerable<Album>>(responseBody);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Ha ocurrido un error: {ex.Message} {ex.InnerException?.Message}");
                }
            }

            return albums;
        }

        /// <summary>
        /// Retrieves the related list of photos for the selected album
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Photo>> GetPhotos(int albumId)
        {
            IEnumerable<Photo> photos = new List<Photo>();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponse = await client.GetAsync($"{_appSettings.PhotosEndpoint}?albumId={albumId}");
                    httpResponse.EnsureSuccessStatusCode();
                    string responseBody = await httpResponse.Content.ReadAsStringAsync();

                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        // Converts the response
                        photos = JsonConvert.DeserializeObject<IEnumerable<Photo>>(responseBody);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Ha ocurrido un error: {ex.Message} {ex.InnerException?.Message}");
                }
            }

            return photos;
        }

        /// <summary>
        /// Retrieves the related list of comments for the selected post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Comment>> GetComments(int postId)
        {
            return null;
        }
    }
}
