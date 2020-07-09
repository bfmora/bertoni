namespace BertoniTest.Helpers.Models
{
    /// <summary>
    /// Helper class for Comments Data
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Related PostId
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// Comment Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Comment Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Comment Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Comment Body Content
        /// </summary>
        public string Body { get; set; }
    }
}
