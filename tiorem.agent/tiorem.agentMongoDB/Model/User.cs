namespace tiorem.agentMongoDB.Model
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Active { get; set; }
        public System.DateTime InsertedAt { get; set; } 
    }
}
