//using System;
//using System.Security.Cryptography;
//using System.Text;
//using DotNetAuth.OAuth1a;

//public class JIRAOAuth1aProvider : OAuth1aProviderDefinition
//{
//    public JIRAOAuth1aProvider(string JIRA_BASE_URL)
//    {
//        RequestTokenEndopointUri = JIRA_BASE_URL + "/plugins/servlet/oauth/request-token";
//        AuthorizeEndpointUri = JIRA_BASE_URL + "/plugins/servlet/oauth/authorize";
//        AuthenticateEndpointUri = JIRA_BASE_URL + "/plugins/servlet/oauth/authorize";
//        AccessTokenEndpointUri = JIRA_BASE_URL + "/plugins/servlet/oauth/access-token";
//    }
//    public override string GetSignatureMethod()
//    {
//        return "RSA-SHA1";
//    }
//    public override string Sign(string stringToSign, string signingKey)
//    {
//        var privateKey = new RSACryptoServiceProvider();
//        privateKey.FromXmlString(signingKey);

//        var shaHashObject = new SHA1Managed();
//        var data = Encoding.ASCII.GetBytes(stringToSign);
//        var hash = shaHashObject.ComputeHash(data);

//        var signedValue = privateKey.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));

//        var result = Convert.ToBase64String(signedValue, Base64FormattingOptions.None);
//        return result;
//    }
//}