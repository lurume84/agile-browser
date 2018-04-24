//using System;
//using System.Linq;
//using AgileBrowser.WinForms.Security;
//using DotNetAuth.OAuth1a;
//using DotNetAuth.OAuth1a.Framework;
//using RestSharp;
//using RestSharp.Authenticators;

//public class OAuth1aAuthenticator : IAuthenticator
//{
//    private OAuth1aProviderDefinition definition;
//    private ApplicationCredentials credentials;
//    private string access_token;
//    private string access_token_secret;
//    private string method;

//    public OAuth1aAuthenticator(OAuth1aProviderDefinition oAuthDefinition, string consumerKey, string privateKey,
//              string accessToken, string accessTokenSecret)
//    {
//        var consumerSecret = privateKey.Replace("-----BEGIN PRIVATE KEY-----", "").Replace("-----END PRIVATE KEY-----", "").Replace("\r\n", "").Replace("\n", "");

//        var keyInfo = opensslkey.DecodePrivateKeyInfo(Convert.FromBase64String(consumerSecret));

//        var applicationCredentials = new ApplicationCredentials
//        {
//            ConsumerKey = consumerKey,
//            ConsumerSecret = keyInfo.ToXmlString(true)
//        };

//        this.definition = oAuthDefinition;
//        this.credentials = applicationCredentials;
//        this.access_token = accessToken;
//        this.access_token_secret = accessTokenSecret;
//    }

//    public void Authenticate(IRestClient client, IRestRequest request)
//    {
//        method = request.Method.ToString();

//        string url = client.BuildUri(request)
//               .ToString();
//        int queryStringStart = url.IndexOf('?');

//        string leftPart = url;
//        if (queryStringStart != -1)
//        {
//            leftPart = url.Substring(0, queryStringStart);
//        }

//        var contentType = request.Parameters.Where(x => x.ContentType == "application/x-www-form-urlencoded");

//        ParameterSet parameterSet = ParameterSet.FromResponseBody(request.Resource);
//        ParameterSet parameterSet2 = (contentType.Any()) ? ParameterSet.FromResponseBody(contentType.FirstOrDefault().Value.ToString()) : new ParameterSet();
//        ParameterSet authorizationParameters = definition.GetAuthorizationParameters(credentials, access_token);

//        string signature = definition.GetSignature(credentials.ConsumerSecret, access_token_secret, leftPart, method, new ParameterSet[]
//        {
//                authorizationParameters,
//                parameterSet,
//                parameterSet2
//        });
//        authorizationParameters.Add("oauth_signature", signature, null);
//        string authorizationHeader = definition.GetAuthorizationHeader(authorizationParameters);

//        request.AddHeader("Authorization", authorizationHeader);
//        request.AddHeader("Accept", "application/json");
//    }
//}