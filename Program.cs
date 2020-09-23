﻿using System;
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
            // var ret_gene_event = await _obj.Post_GenerateEvent(Company.generate_event());
            // var ret_com_event = await _obj.Post_Company_Eventdetails(Company.Com_event_detail());
            var ret_comget_event = await _obj.Get_Company_Eventdetails(Company.Com_event_detail());
            var ret_PostfileUpload = await _obj.Post_FileUpload();
            var ret_getfileUpload = await _obj.Get_FileUpload();
            var ret_romupload = await _obj.Post_Rom_Upload(Company.romupload());
            var ret_PostApproved = await _obj.PostApproved_Event(int event_id);
            var ret_Get_List = await _obj.Get_List(string str);
            var ret_Get_ListPrivateList = await _obj.Get_PrivateList(string str);
            var ret_Get_EventList = await _obj.Get_EventList(string str);
            var ret_Post_chPass = await _obj.Post_ChangePasssword(Company.change_password());
            var ret_Post_ForgotPass = await _obj.PostForgotPassword(Company.forgot_password());
            var ret_Post_Registration = await _obj.Post_Registration(Company.Registration());
            var ret_Get_Registration = await _obj.GetRegistration(Company.Registration());
            var ret_Put_Registration = await _obj.Put_Registration(Company.Registration());

            var ret_Post_DocUpload = await _obj.Post_DocUpload(Company.Docupload());
            var ret_Get_DocUpload = await _obj.Get_DocUpload(Company.Docupload());
            var ret_Get_Docdownload = await _obj.Get_Docdownload(Company.Registration());
            var ret_Post_Docdownload = await _obj.Post_Docdownload(Company.Registration());
            
                
                
                





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
                             .AddString("upload_type","ROM")).ReceiveString();

            //Keep the following code when checking resolutions data
            //foreach (var enabledEndpoint in ((IEnumerable<dynamic>)config.endpoints).Where(t => t.enabled))
            //{
            //    Console.WriteLine($"{enabledEndpoint.name} is enabled");
            //}

            Console.WriteLine(get_url2);
        }
    }
}
