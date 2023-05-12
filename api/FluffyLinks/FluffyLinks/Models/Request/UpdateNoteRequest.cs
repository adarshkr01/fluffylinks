namespace FluffyLinks.Models.Request
{
    public class UpdateNoteRequest
    {
        public string Url { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string HighlightedText { get; set; }
    }
}
