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
using System.Collections.Generic;

namespace TryingFLURL
{
    class RTA
    {
        public string token { get; set; }
        public static FJC_LoginRequest Default_user()
        {
            return new FJC_LoginRequest()
            { UserID = "R200000000000005", system_ip = "127.0.0.128", encrypt_Password = "bigshare@123" };

        }
        public static FJC_UpdateEVENT Update_Event()
        {
            return new FJC_UpdateEVENT()
            {
                event_id= 65,
                isin= "INE98765499",
                type_isin= 3,
                type_evoting= 1,
                total_nof_share= 100000.0,
                voting_rights= 1,
                cut_of_date= "2020-08-31",
                scrutinizer= 9069,
                voting_start_datetime= "",
                voting_end_datetime="",
                meeting_datetime= "",
                last_date_notice= "",
                voting_result_date= "",
                upload_logo= 1,
                upload_resolution_file= 3,
                upload_notice= 2,
                enter_nof_resolution= 9,
                resolutions_Datas= 
                };

        }

        public static FJC_ROMUpload romupload()
        {
            return new FJC_ROMUpload()
            {
                event_id = 24,
                doc_id = 61,
            };
        }

        /////////////////////////////////////////////////////////////-RTA-/////////////////////////////////////////////////////////////
        public async Task<dynamic> Post_Login(FJC_LoginRequest _fjc_login)
        {
            var get_url1 = await CommanUrl.Login().PostJsonAsync(_fjc_login).ReceiveString();
            //return  JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
            dynamic _obj = JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
            token = _obj.data.Token;
            return _obj;
        }

        public async Task<dynamic> Post_UpdateEvent(FJC_UpdateEVENT fJC_UpdateEVENT)
        {
            var get_url1 = await CommanUrl.updateEvent().WithHeader("Token", token).PostJsonAsync(fJC_UpdateEVENT).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

        public async Task<dynamic> Get_UpdateEven(int event_id)   //get error in result converting
        {
            //var get_url1 = await CommanUrl.ComFileUpload().WithHeader("Token", token).PostJsonAsync(doc_id).ReceiveString();
            var get_url1 = await CommanUrl.updateEvent().WithHeader("Token", token).SetQueryParam("event_id", event_id).GetJsonAsync();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

        public async Task<dynamic> Put_UpdateEven(FJC_UpdateEVENT fJC_UpdateEVENT)   //get error in result converting
        {
            var get_url1 = await CommanUrl.updateEvent().WithHeader("Token", token).PutJsonAsync(fJC_UpdateEVENT).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

         public async Task<dynamic> Post_FileUpload()
        {
            var get_url1 = await CommanUrl.ComFileUpload().WithHeader("Token", token).PostMultipartAsync(x =>
                            x.AddFile("files", @"C:\Evoting-Github\Files\sample_Logo.jpg")
                            .AddString("upload_type", "ROM")).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

        public async Task<dynamic> Get_FileUpload(int doc_id)   //get error in result converting
        {
            // var get_url1 = await CommanUrl.ComFileUpload().WithHeader("Token", token).PostJsonAsync(doc_id).ReceiveString();
            var get_url1 = await CommanUrl.ComFileUpload().WithHeader("Token", token).SetQueryParam("doc_id", doc_id).GetJsonAsync();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }
        public async Task<dynamic> Post_Rom_Upload(FJC_ROMUpload fJC_ROM)
        {
            var get_url1 = await CommanUrl.ComRomUpload().WithHeader("Token", token).PostJsonAsync(fJC_ROM).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

        public async Task<dynamic> PostApproved_Event(int event_id)
        {
            var get_url1 = await CommanUrl.ApprovedEvent().WithHeader("Token", token).PostJsonAsync(event_id).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

        public async Task<dynamic> Get_List(string str)
        {
            // var get_url1 = await CommanUrl.CompanyList().WithHeader("Token", token).PostJsonAsync(str).ReceiveString();
            var get_url1 = await CommanUrl.CompanyList().WithHeader("Token", token).SetQueryParam("str", str).GetJsonAsync();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

        public async Task<dynamic> Get_PrivateList(string str)
        {
            //var get_url1 = await CommanUrl.PrivateList().WithHeader("Token", token).PostJsonAsync(str).ReceiveString();
            var get_url1 = await CommanUrl.PrivateList().WithHeader("Token", token).SetQueryParam("str", str).GetJsonAsync();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

        public async Task<dynamic> Get_EventList(string str)
        {
            //var get_url1 = await CommanUrl.EventList().WithHeader("Token", token).PostJsonAsync(str).ReceiveString();
            var get_url1 = await CommanUrl.EventList().WithHeader("Token", token).SetQueryParam("str", str).GetJsonAsync();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

        public async Task<dynamic> Post_ChangePasssword(FJC_ChangePassword fJC_ChangePassword)
        {
            var get_url1 = await CommanUrl.ChangePass().WithHeader("Token", token).PostJsonAsync(fJC_ChangePassword).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

        public async Task<dynamic> PostForgotPassword(FJC_ForgotPassword fJC_ForgotPassword)
        {
            var get_url1 = await CommanUrl.ForgotPass().WithHeader("Token", token).PostJsonAsync(fJC_ForgotPassword).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }



    }
}
