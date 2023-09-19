namespace Matriculas.Common.Database
{
    public class DatabaseConnectionCredentials
    {
        /*
            These settings must be set in the usersecrets json file
        */
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string Port { get; set; }

        public string GetConnectionString() =>
            $"Server={Host};Database={Database};Port={Port};Username={User};Password={Password}";
    }
}