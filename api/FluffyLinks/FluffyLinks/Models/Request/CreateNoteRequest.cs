namespace FluffyLinks.Models.Request
{
    public class CreateNoteRequest
    {
        public string Url { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string HighlightedText { get; set; }

        public string UserId { get; set; }
    }
}
