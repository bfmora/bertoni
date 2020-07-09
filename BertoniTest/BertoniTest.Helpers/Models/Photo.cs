namespace BertoniTest.Helpers.Models
{
    /// <summary>
    /// Helper class for Photo Data
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// Related Album Id
        /// </summary>
        public int AlbumId { get; set; }

        /// <summary>
        /// Photo Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Photo Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Photo Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Photo Thumbnail
        /// </summary>
        public string ThumbnailUrl { get; set; }
    }
}
