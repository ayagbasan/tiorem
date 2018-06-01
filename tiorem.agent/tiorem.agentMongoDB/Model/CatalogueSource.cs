namespace tiorem.agentMongoDB.Model
{

    public partial class CatalogueSource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string SourceUrl { get; set; }
        public int Followers { get; set; }
        public bool Active { get; set; }
    }
}
