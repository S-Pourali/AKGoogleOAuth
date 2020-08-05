using AKGoogleOAuth.Global;
using AKGoogleOAuth.Services;
using MvvmCross.ViewModels;
using System;
using Xamarin.Auth;
using Xamarin.Forms;

namespace AKGoogleOAuth
{
    public class AuthenticatorVM : MvxViewModel
    {
        private bool _isUserAuthenticated;
        private OAuth2Authenticator _auth;
        
        private IAuthenticatorService _authenticatorService;

        public AuthenticatorVM(IAuthenticatorService authenticatorService)
        {
            _authenticatorService = authenticatorService;

            _auth = new OAuth2Authenticator(
               clientId: Device.RuntimePlatform == "Android " ? AkHelper.AndroidClientId : AkHelper.iOSClientId,
               clientSecret: string.Empty,
               scope: AkHelper.Scope,
               authorizeUrl: new Uri(AkHelper.AuthorizeUrl),
               redirectUrl: new Uri(AkHelper.RedirectUrl),
               accessTokenUrl: new Uri(AkHelper.AccessTokenUrl),
               getUsernameAsync: null,
               isUsingNativeUI: true
               );
        }

        public OAuth2Authenticator GetAuthenticator()
        {
            return _auth;
        }


        public void OnPageLoading(Uri uri)
        {
            _auth.OnPageLoading(uri);
        }


        public bool IsUserAuthenticated => _isUserAuthenticated;

        private void Auth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            try
            {
                if (e.IsAuthenticated)
                {
                    AkHelper.TokenType = e.Account.Properties["token_type"];
                    AkHelper.ClientAccessToken = e.Account.Properties["access_token"];

                    _authenticatorService.OnAuthenticateCompleted(AkHelper.TokenType, AkHelper.ClientAccessToken);

                    _isUserAuthenticated = true;
                    RaisePropertyChanged(nameof(IsUserAuthenticated));
                }
                else
                {
                    _authenticatorService.OnAuthenticateFailed();

                    _isUserAuthenticated = false;
                    RaisePropertyChanged(nameof(IsUserAuthenticated));

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        private void Auth_Error(object sender, AuthenticatorErrorEventArgs e)
        {
            //implementation of error behaviors
            _isUserAuthenticated = false;
            RaisePropertyChanged(nameof(IsUserAuthenticated));
        }


    }
}
