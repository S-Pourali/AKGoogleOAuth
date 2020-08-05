using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AKGoogleOAuth.Services;
using Foundation;
using UIKit;

namespace AKGoogleOAuth.iOS
{
    public class AkViewHandler : UIViewController, IAuthenticatorService
    {
        public static AuthenticatorVM Auth;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Auth = new AuthenticatorVM(this);

            var authenticator = Auth.GetAuthenticator();
            var authenticatorUI = authenticator.GetUI();
            PresentViewController(authenticatorUI, true, null);

        }

        
        public void OnAuthenticateCompleted(string tokenType, string accessToken)
        {
            // could retrive some user information such as Name and etc.
            DismissViewController(true, null);
        }

        public void OnAuthenticateFailed()
        {
            // decide to display either alert box or something else.
            throw new NotImplementedException();
        }
    }
}