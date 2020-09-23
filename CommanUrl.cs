using System;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using evoting;
using System.Net.Http;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Converters;
using evoting.Domain.Models;

namespace TryingFLURL
{
  
  public static class CommanUrl
    {
        const string  DefaultUrl = "http://bigshareonline.com:6001";

        
        public static string Login()
        {
            var UrlLogin = DefaultUrl.AppendPathSegment("api").AppendPathSegment("Login");
            return UrlLogin;
        }
        public static string GenerateEvent()
        {
            var _genevent = DefaultUrl.AppendPathSegment("api").AppendPathSegment("Event");
            return _genevent;
        }
        public static string ComEvntDetail()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("CompanyEVENTDetails");
            return _ComEvntDe;
        }
        public static string ComFileUpload()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("FileUpload");
            return _ComEvntDe;
        }
        public static string ComRomUpload()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("ROM");
            return _ComEvntDe;
        }

        public static string ApprovedEvent()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("ApproveEvent");
            return _ComEvntDe;
        }
        
        public static string CompanyList()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("list");
            return _ComEvntDe;
        }
        
          public static string PrivateList()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("private-list");
            return _ComEvntDe;
        }

        public static string EventList()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("event-list");
            return _ComEvntDe;
        }

        public static string ChangePass()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("ChangePassword");
            return _ComEvntDe;
        }
        public static string ForgotPass()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("ForgotPassword");
            return _ComEvntDe;
        }
        public static string Registration()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("Registration");
            return _ComEvntDe;
        }

        public static string DocUpload()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("DocumentUpload");
            return _ComEvntDe;
        }

        public static string DocDownload()
        {
            var _ComEvntDe = DefaultUrl.AppendPathSegment("api").AppendPathSegment("DocumentDownload");
            return _ComEvntDe;
        }
    }
}
