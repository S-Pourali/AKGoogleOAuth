using System;

namespace AKGoogleOAuth.Services
{
    public interface IAuthenticatorService
    {
        void OnAuthenticateCompleted(string tokenType, string accessToken);
        void OnAuthenticateFailed(); // could handle with exception

    }
}
