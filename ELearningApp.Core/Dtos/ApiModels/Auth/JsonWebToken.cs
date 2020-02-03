namespace ELearningApp.Core.Dtos.ApiModels.Auth
{
    public class JsonWebToken
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}