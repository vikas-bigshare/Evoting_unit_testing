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
    public class Company
    {
        public string token { get; set; }
        public static FJC_LoginRequest Default_user()
        {
            return new FJC_LoginRequest()
            { UserID = "C100000000000007", system_ip = "127.0.0.128", encrypt_Password = "bigshare@12" };

        }
        public static FJC_GenerateEVENT generate_event()
        {
            return new FJC_GenerateEVENT()
            {
                event_id = 0,
                isin = "INE98765888",
                type_isin = 3,
                type_evoting = 1,
                total_nof_share = 10000,
                voting_rights = 1,
                cut_of_date = "2020-08-30",
                scrutinizer = 9093
            };

        }
        public static FJC_CompanyUpdate_Event Com_event_detail()
        {
            List<FJC_Resolutions_Data> resolutions_Datas = new List<FJC_Resolutions_Data>();
            resolutions_Datas.Add(new FJC_Resolutions_Data() { doc_id = 65, resolution_id = 1, title = "title1", description = "description1" });
            resolutions_Datas.Add(new FJC_Resolutions_Data() { doc_id = 66, resolution_id = 2, title = "title2", description = "description2" });
            resolutions_Datas.Add(new FJC_Resolutions_Data() { doc_id = 67, resolution_id = 3, title = "title3", description = "description3" });
            resolutions_Datas.Add(new FJC_Resolutions_Data() { doc_id = 69, resolution_id = 4, title = "title4", description = "description4" });
            return new FJC_CompanyUpdate_Event()
            {
                event_id = 25,
                isin = "INE98765432",
                type_isin = 3,
                type_evoting = 1,
                total_nof_share = 100000,
                voting_rights = 1,
                cut_of_date = "2020-08-31",
                scrutinizer = 1,
                voting_start_datetime = "",
                voting_end_datetime = "",
                meeting_datetime = "",
                last_date_notice = "",
                voting_result_date = "",
                upload_logo = 1,
                upload_resolution_file = 3,
                upload_notice = 2,
                enter_nof_resolution = 9,
                resolutions = resolutions_Datas.ToArray()
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
        public static FJC_ChangePassword change_password()
        {
            return new FJC_ChangePassword()
            {
                UserID = "C100000000000007",
                encrypt_OldPassword = "bigshare@123",
                encrypt_NewPassword = "bigshare@12"
            };
        }
        public static FJC_ForgotPassword forgot_password()
        {
            return new FJC_ForgotPassword()
            {
                UserID = "C100000000000003",
                EmailID = "shivkumar@bigshareonline.com",
                PAN_ID = "XXXXXXXXXX"
            };
        }
        public static FJC_Registration Registration()
        {
            return new FJC_Registration()
            {
                aud_id = 0,
                reg_type_id = 2,
                name = "Testingcompany",
                reg_no = "Lenovo123",
                reg_add1 = "Mumbai",
                reg_add2 = "Mumbai",
                reg_add3 = "Mumbai",
                reg_city = "Mumbai",
                reg_pincode = "401001",
                reg_state_id = 4,
                reg_country = 1,
                corres_add1 = "Mumbai1",
                corres_add2 = "Mumbai1",
                corres_add3 = "Mumbai1",
                corres_city = "Mumbai",
                corres_pincode = "401002",
                corres_state_id = 6,
                corres_country = 1,
                pcs_no = "000001",
                cs_name = "Shivkumar",
                cs_email_id = "shivkumar@bigshareonline.com",
                cs_alt_email_id = "shivkumar@bigshareonline.com",
                cs_tel_no = "234234",
                cs_fax_no = "23423",
                cs_mobile_no = "1234567890",
                panid = "XXXXXXXX10",
                rta_id = 2
            };

        }
        public static FJC_DOC_Upload Docupload()
        {
            return new FJC_DOC_Upload()
            {
                doc_id = 61,
                upload_type = "ROM",

            };

        }


        //////////////////////////////////////////////////////company //////////////////////////////////////////////////////////////////
        public static async Task<dynamic> Post_Login1(FJC_LoginRequest _fjc_login)
        {
            string default_link = "http://bigshareonline.com:6001";
            var _url1 = default_link.AppendPathSegment("api").AppendPathSegment("Login");//commonurl.login
            var get_url1 = await _url1.PostJsonAsync(_fjc_login).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
            //var opt_check = _return_obj.data.EmailID;
            //string token = _return_obj.data.Token;
            //Console.WriteLine(opt_check);
            //Console.WriteLine(token);
        }

        public async Task<dynamic> Post_Login(FJC_LoginRequest _fjc_login)
        {
            var get_url1 = await CommanUrl.Login().PostJsonAsync(_fjc_login).ReceiveString();
            //return  JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
            dynamic _obj = JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
            token = _obj.data.Token;
            return _obj;
        }

        public async Task<dynamic> Post_GenerateEvent(FJC_GenerateEVENT fJC_GenerateEVENT)
        {
            string _url = CommanUrl.GenerateEvent();
            var get_url1 = await _url.WithHeader("Token", token).PostJsonAsync(fJC_GenerateEVENT).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

        public async Task<dynamic> Post_Company_Eventdetails(FJC_CompanyUpdate_Event fJC_CompanyUpdate_Event)
        {
            var get_url1 = await CommanUrl.ComEvntDetail().WithHeader("Token", token).PostJsonAsync(fJC_CompanyUpdate_Event).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }
        public async Task<dynamic> Put_Company_Eventdetails(FJC_CompanyUpdate_Event fJC_CompanyUpdate_Event)
        {
            var get_url1 = await CommanUrl.ComEvntDetail().WithHeader("Token", token).PutJsonAsync(fJC_CompanyUpdate_Event).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }
        public async Task<dynamic> Get_Company_Eventdetails(int event_id)
        {
            //var get_url1 = await CommanUrl.ComEvntDetail().WithHeader("Token", token).PostJsonAsync(fJC_CompanyUpdate_Event).ReceiveString();
            var get_url1 = await CommanUrl.ComFileUpload().WithHeader("Token", token).SetQueryParam("doc_id", event_id).GetJsonAsync();
            var message = get_url1.data.file_name;
            return get_url1;
          
        }
        public async Task<dynamic> Post_FileUpload()
        {
            var get_url1 = await CommanUrl.ComFileUpload().WithHeader("Token", token).PostMultipartAsync(x =>
                            x.AddFile("files", @"C:\Evoting-Github\Files\sample_Logo.jpg")
                            .AddString("upload_type", "ROM")).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

        public async Task<dynamic> Get_FileUpload(int doc_id)   
        {
            var get_url1 = await CommanUrl.ComFileUpload().WithHeader("Token", token).SetQueryParam("doc_id", doc_id).GetJsonAsync();
            var message = get_url1.data.file_name;
            return get_url1;
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
            var get_url1 = await CommanUrl.CompanyList().WithHeader("Token", token).SetQueryParam("str", str).GetJsonAsync();
            var message = get_url1.message;
            return get_url1;
        }

        public async Task<dynamic> Get_PrivateList(string str)
        {
            var get_url1 = await CommanUrl.PrivateList().WithHeader("Token", token).SetQueryParam("str", str).GetJsonAsync();
            var message = get_url1.message;
            return get_url1;
        }

        public async Task<dynamic> Get_EventList(string str)
        {
            var get_url1 = await CommanUrl.EventList().WithHeader("Token", token).SetQueryParam("str", str).GetJsonAsync();
            var message = get_url1.message;
            return get_url1;
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

        public async Task<dynamic> Post_Registration(FJC_Registration fJC_Registration)
        {
            var get_url1 = await CommanUrl.Registration().WithHeader("Token", token).PostJsonAsync(fJC_Registration).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

        //////public async Task<dynamic> GetRegistration(int aud_id)
        //////{
        //////    var get_url1 = await CommanUrl.Registration().WithHeader("Token", token).SetQueryParam("str", aud_id).GetJsonAsync();
        //////    var message = get_url1.message;
        //////    return get_url1;
        //////}

        //////public async Task<dynamic> Put_Registration(FJC_Registration fJC_Registration)
        //////{
        //////    var get_url1 = await CommanUrl.Registration().WithHeader("Token", token).PutJsonAsync(fJC_Registration).ReceiveString();
        //////    return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        //////}


        public async Task<dynamic> Post_DocUpload(FJC_DOC_Upload fJC_DOC_Upload)
        {
            var get_url1 = await CommanUrl.DocUpload().WithHeader("Token", token).PostJsonAsync(fJC_DOC_Upload).ReceiveString();

            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

        //////public  async Task<dynamic> Get_DocUpload(FJC_DOC_Upload fJC_DOC_Upload)
        //////{
        //////   // var get_url1 = await CommanUrl.DocUpload().WithHeader("Token", token).PostJsonAsync(fJC_DOC_Upload).ReceiveString();
        //////    var get_url1 = await CommanUrl.DocUpload().WithHeader("Token", token).SetQueryParam("str", str).GetJsonAsync();
        //////    return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        //////}

        public async Task<dynamic> Get_Docdownload()
        {
            var get_url1 = await CommanUrl.DocUpload().WithHeader("Token", token).GetJsonAsync();
            var message = get_url1.message;
            return get_url1;
        }
        public async Task<dynamic> Post_Docdownload(string DownloadType)   //tri_partiate_agreement
        {
            //var get_url1 = await CommanUrl.DocDownload().WithHeader("Token", token).PostJsonAsync(DownloadType).ReceiveString();
            // return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
            var get_url1 = await CommanUrl.DocDownload().WithHeader("Token", token).SetQueryParam("DownloadType", DownloadType).PostJsonAsync("");
            var message = get_url1.ReasonPhrase.ToString();
            return get_url1;
        }

        public async Task<dynamic> Put_Prifile(FJC_Registration fJC_Registration)
        {
            var get_url1 = await CommanUrl.userprofile().WithHeader("Token", token).PutJsonAsync(fJC_Registration).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

        public async Task<dynamic> Get_Prifile(int aud_id)
        {
            var get_url1 = await CommanUrl.userprofile().WithHeader("Token", token).SetQueryParam("aud_id", aud_id).GetJsonAsync();
            var message = get_url1.data.file_name;
            return get_url1;
        }
    }
}
