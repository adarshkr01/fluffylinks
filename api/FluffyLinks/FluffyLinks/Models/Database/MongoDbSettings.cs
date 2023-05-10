namespace FluffyLinks.Models.Database
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }

        public string Database { get; set; }

        public string NotesCollection { get; set; }
    }
}
