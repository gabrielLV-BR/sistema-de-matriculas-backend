namespace Configuration.POCO
{
    public class DatabaseConnectionCredentials
    {
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }


        public string GetConnectionString() => $"Host={Host}; Database=db; Username={User}; Password={Password}";
    }
}