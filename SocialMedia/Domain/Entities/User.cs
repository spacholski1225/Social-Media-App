namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(int id, string name, string password)
        {
            (Id, Name, Password) = (id, name, password);
        }
    }
}
