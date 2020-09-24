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
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http.Internal;

namespace TryingFLURL
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Company _obj = new Company();
            var ret_login = await _obj.Post_Login(Company.Default_user());
            var ret_gene_event = await _obj.Post_GenerateEvent(Company.generate_event());
            var ret_com_event = await _obj.Post_Company_Eventdetails(Company.Com_event_detail());
            var ret_comget_event = await _obj.Get_Company_Eventdetails(Company.Com_event_detail());
            var ret_PostfileUpload = await _obj.Post_FileUpload();
            var ret_getfileUpload = await _obj.Get_FileUpload(61);
            var ret_romupload = await _obj.Post_Rom_Upload(Company.romupload());

            var ret_PostApproved = await _obj.PostApproved_Event(24);
            var ret_Get_List = await _obj.Get_List("rta");
            var ret_Get_ListPrivateList = await _obj.Get_PrivateList("scrutinizer");
            var ret_Get_EventList = await _obj.Get_EventList("current");

            var ret_Post_chPass = await _obj.Post_ChangePasssword(Company.change_password());
            var ret_Post_ForgotPass = await _obj.PostForgotPassword(Company.forgot_password());

            var ret_Post_Registration = await _obj.Post_Registration(Company.Registration());
            /// var ret_Get_Registration = await _obj.GetRegistration(13);
            /// var ret_Put_Registration = await _obj.Put_Registration(Company.Registration());

            var ret_Post_DocUpload = await _obj.Post_DocUpload(Company.Docupload());
            ////var ret_Get_DocUpload = await _obj.Get_DocUpload(Company.Docupload());
            var ret_Get_Docdownload = await _obj.Get_Docdownload();
            var ret_Post_Docdownload = await _obj.Post_Docdownload("tri_partiate_agreement");

            var ret_Post_Registration2 = await _obj.Put_Prifile(Company.Registration());
            var ret_Put_Registration2 = await _obj.Post_Prifile(Company.Registration());

            /////////////////////////////////////////////////RTA////////////////////////////////
            RTA rTA = new RTA();
            var ret_login1 = await rTA.Post_Login(RTA.Default_user());
            var ret_PostUpdateEvent = await rTA.Post_UpdateEvent(RTA.Update_Event());
           // var ret_GetUpdateEvent = await rTA.Get_UpdateEvent();
            var ret_PostfileUpload1 = await rTA.Post_FileUpload();
            var ret_getfileUpload1 = await rTA.Get_FileUpload(61);
            var ret_romupload1 = await rTA.Post_Rom_Upload(RTA.romupload());

            var ret_PostApproved1 = await rTA.PostApproved_Event(24);
            var ret_Get_List1 = await rTA.Get_List("rta");
            var ret_Get_ListPrivateList1 = await rTA.Get_PrivateList("scrutinizer");
            var ret_Get_EventList1 = await rTA.Get_EventList("current");

            var ret_Post_Registration1 = await rTA.Post_Registration(RTA.Registration());
            var ret_Get_Registration1 = await rTA.GetRegistration(13);
            var ret_Put_Registration1 = await rTA.Put_Registration(RTA.Registration());
            var ret_Post_DocUpload1 = await rTA.Post_DocUpload(RTA.Docupload());
            var ret_Get_Docdownload1 = await rTA.Get_Docdownload();
            var ret_Post_Docdownload1 = await rTA.Post_Docdownload("tri_partiate_agreement");
            var ret_Post_Registration3 = await rTA.Put_Prifile(RTA.Registration());
            var ret_Put_Registration3 = await rTA.Post_Prifile(RTA.Registration());

            //FlurlTry _objnew = new FlurlTry();
            //_objnew.CheckCompanyAdd(return_value1.data.Token);
            // Console.WriteLine(ret_login.data);
            //Console.ReadLine();
        }

    }

    public class FlurlTry
    {
        public async Task CheckCompanyAdd(string token)
        {
            string _url = CommanUrl.GenerateEvent();
            var check = Company.generate_event();
            var get_url1 = await _url.WithHeader("Token", token).PostJsonAsync(check).ReceiveString();
            dynamic _return_obj = JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }
        public async Task GetResponseAsync()
        {
            string default_link = "http://bigshareonline.com:6001";

            var _url1 = default_link.AppendPathSegment("api").AppendPathSegment("Login");
            var _url2 = default_link.AppendPathSegment("api").AppendPathSegment("fileupload");
            var get_url1 = await _url1.PostJsonAsync
                (new FJC_LoginRequest()
                { UserID = "C100000000000007", encrypt_Password = "bigshare@123", system_ip = "127.0.0.128" }).ReceiveString();
            dynamic _return_obj = JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
            var opt_check = _return_obj.data.EmailID;
            string token = _return_obj.data.Token;
            Console.WriteLine(opt_check);
            Console.WriteLine(token);

            var get_url2 = await _url2.WithHeader("Token", token).PostMultipartAsync(x =>
                            x.AddFile("files", @"D:\Bigshare\Vendor\Kushal Dubal\Mobile_API_list.xlsx")
                             .AddString("upload_type", "ROM")).ReceiveString();

            //Keep the following code when checking resolutions data
            //foreach (var enabledEndpoint in ((IEnumerable<dynamic>)config.endpoints).Where(t => t.enabled))
            //{
            //    Console.WriteLine($"{enabledEndpoint.name} is enabled");
            //}

            Console.WriteLine(get_url2);
        }
    }
}
