namespace tiorem.agentMongoDB.Model
{
    public partial class CatalogueTag
    {
        public long Id { get; set; }
        public string TagName { get; set; }
        public int Hits { get; set; }
        public System.DateTime InsertDate { get; set; }
        public int InsertUserId { get; set; }
        public bool Active { get; set; }
    }
}
