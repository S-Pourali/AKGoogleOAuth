namespace AKGoogleOAuth.Global
{
    public class AkHelper
    {
        public static string AuthorizeUrl => "https://accounts.google.com/o/oauth2/v2/auth";
        public static string AccessTokenUrl => "https://www.googleapis.com/oauth2/v4/token";
        public static string RedirectUrl => "com.companyname.akgoogleoauth:/oauth2redirect";

        // Local, Deug Mode
        public static string AndroidClientId => "432891328982-d6c113tquqvifm4u1a4jdb9fkqte7n0m.apps.googleusercontent.com";
        
        // Local, Debug Mode
        public static string iOSClientId => "432891328982-621phmnce9rjugo8bs5pohbobtgpatcg.apps.googleusercontent.com";

        public static string ClientSecret => "ClientSecret";
        public static string Scope => "email";

        public static string TokenType { get; set; }
        public static string ClientAccessToken { get; set; }
    }


}
