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
   public class Scrutinizer
    {
        public string token { get; set; }
        public static FJC_LoginRequest Default_user()
        {
            return new FJC_LoginRequest()
            { UserID = "S300000000000048", system_ip = "127.0.0.60", encrypt_Password = "bigshare@123" };

        }

        public static FJC_Registration Registration()
        {
            return new FJC_Registration()
            {
                aud_id = 0,
                reg_type_id = 3,
                name = "Fortunekit",
                reg_no = "ADROIT1720",
                reg_add1 = "C114 Regency Plaza Shanti Nagar Near VJ Honda",
                reg_add2 = "MAROL NAKA, ANDHERI (E)",
                reg_add3 = "Mumbai",
                reg_city = "Kalyan",
                reg_pincode = "401001",
                reg_state_id = 4,
                reg_country = 1,
                corres_add1 = "Bigshare Services,1st Floor, Bharat Tin Work ,Makawana Road",
                corres_add2 = "Marol",
                corres_add3 = "Andheri East",
                corres_city = "Mumbai",
                corres_pincode = "421003",
                corres_state_id = 4,
                corres_country = 1,
                pcs_no = "000001",
                cs_name = "Shivkumar",
                cs_email_id = "admin@fortunekit.com",
                cs_alt_email_id = "shivkumar@bigshareonline.com",
                cs_tel_no = "62638200",
                cs_fax_no = "62699990",
                cs_mobile_no = "1234567890",
                panid = "XXXXXXXX50",
                alt_mob_num = 9022120324,
                rta_id = 0
            };

        }

        public static FJC_ChangePassword change_password()
        {
            return new FJC_ChangePassword()
            {
                UserID = "S300000000000048",
                encrypt_OldPassword = "bigshare@123",
                encrypt_NewPassword = "bigshare@12"
            };
        }

        public static FJC_DOC_Upload Docupload()
        {
            return new FJC_DOC_Upload()
            {
                doc_id = 65,
                upload_type = "Tri_partiate_agreement",

            };

        }

        public async Task<dynamic> Post_Login(FJC_LoginRequest _fjc_login)
        {
            var get_url1 = await CommanUrl.Login().PostJsonAsync(_fjc_login).ReceiveString();
            dynamic _obj = JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
            token = _obj.data.Token;
            return _obj;
        }

        public async Task<dynamic> Post_Registration(FJC_Registration fJC_Registration)
        {
            var get_url1 = await CommanUrl.Registration().WithHeader("Token", token).PostJsonAsync(fJC_Registration).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }
        
        public async Task<dynamic> Post_ChangePasssword(FJC_ChangePassword fJC_ChangePassword)
        {
            var get_url1 = await CommanUrl.ChangePass().WithHeader("Token", token).PostJsonAsync(fJC_ChangePassword).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }

        public async Task<dynamic> Get_Docdownload()
        {
            var get_url1 = await CommanUrl.DocUpload().WithHeader("Token", token).GetJsonAsync();
            var message = get_url1.message;
            return get_url1;
        }
        public async Task<dynamic> Post_Docdownload(string DownloadType)   //tri_partiate_agreement
        {
            var get_url1 = await CommanUrl.DocDownload().WithHeader("Token", token).SetQueryParam("DownloadType", DownloadType).PostJsonAsync("");
            var message = get_url1.ReasonPhrase.ToString();
            return get_url1;
        }

        public async Task<dynamic> Get_DocUpload()
        {
            var get_url1 = await CommanUrl.DocUpload().WithHeader("Token", token).GetJsonAsync();
            var message = get_url1.message;
            return get_url1;
        }
        public async Task<dynamic> Post_DocUpload(FJC_DOC_Upload fJC_DOC_Upload)
        {
            var get_url1 = await CommanUrl.DocUpload().WithHeader("Token", token).PostJsonAsync(fJC_DOC_Upload).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }
        //////public async Task<dynamic> Put_Prifile(FJC_Registration fJC_Registration)
        //////{
        //////    var get_url1 = await CommanUrl.userprofile().WithHeader("Token", token).PutJsonAsync(fJC_Registration).ReceiveString();
        //////    return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        //////}
        public async Task<dynamic> Get_Prifile(int aud_id)
        {
            var get_url1 = await CommanUrl.userprofile().WithHeader("Token", token).SetQueryParam("aud_id", aud_id).GetJsonAsync();
            var message = get_url1.data.file_name;
            return get_url1;
        }



    }
}
