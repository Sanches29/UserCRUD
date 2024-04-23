namespace UserCRUD.Domain.Models
{
    public class AppSettingsModel
    {
        public ConnectionSettings ConnectionSettings { get; set; }
    }

    public class ConnectionSettings
    {
        public string POSTGRES_HOST { get; set; }
        public string POSTGRES_PORT { get; set; }
        public string POSTGRES_DATABASE { get; set; }
        public string POSTGRES_USERNAME { get; set; }
        public string POSTGRES_PASSWORD { get; set; }
    }
}
