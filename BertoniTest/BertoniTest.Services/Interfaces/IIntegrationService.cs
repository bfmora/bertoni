using System.Collections.Generic;
using System.Threading.Tasks;
using BertoniTest.Helpers.Models;

namespace BertoniTest.Services.Interfaces
{
    public interface IIntegrationService
    {
        /// <summary>
        /// Retrieves a complete list of albums
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Album>> GetAlbumsAsync();

        /// <summary>
        /// Retrieves the related list of photos for the selected album
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        Task<IEnumerable<Photo>> GetPhotos(int albumId);

        /// <summary>
        /// Retrieves the related list of comments for the selected post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        Task<IEnumerable<Comment>> GetComments(int postId);
    }
}
