namespace Empite.MicroserviceTemplate.Models.Configs
{
    public class Settings
    {
        public string AppId { get; set; }
        public string SecretKey { get; set; }
        public string IdentityUrl { get; set; }
        public string IdentityAppId { get; set; }
        public string IdentityApiKey { get; set; }
        public ApiSettings ApiSettings { get; set; }
        public HangFireConnectionSettings HangFireConnectionSettings { get; set; }
    }

    
    
}
