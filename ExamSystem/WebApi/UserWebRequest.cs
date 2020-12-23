using ExamSystem.WebApi.Common_Interface;
using ExamSystem.WebApi.entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.WebApi
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserWebRequest : Operation
    {
        private HttpClient client;
       // private string login_Token { get ; set ;}
       // private StringContent input;

        public UserWebRequest(string login_Token)
        {
            client = new HttpClient();
            //this.login_Token = login_Token;
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + login_Token);
        }

        /// <summary>
        /// 将输入转为json格式
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        private StringContent GetJson(IResult Dto)
        {
            var js = JsonConvert.SerializeObject(Dto);

            var input = new StringContent(js);

            input.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("Application/json") { CharSet = "utf-8" };

            return input;
        }

        public async Task<string> CreateRequest(Uri uri, IResult input)
        {
            using(client)
            {
                var inp = GetJson(input);
                var result =await client.PostAsync(uri, inp);
                if(result.IsSuccessStatusCode == false)
                { return "请求失败，查看是否用于权限"; }
                else
                { return result.StatusCode.ToString(); }
                
            }
        }

        public async Task<string> DeleteRequest(Uri uri, entity<long> input)
        {
            using(client)
            {
                var result = await client.DeleteAsync(uri + "?Id=" + input.id  );
                if (result.IsSuccessStatusCode == false)
                { return "请求失败，查看是否用于权限"; }
                else
                { return result.StatusCode.ToString(); }
            }
            
        }

        public async Task<Dictionary<string,string>> GetRequest(Uri uri, entity<long> input)
        {
            using(client)
            {
                var result = await client.GetAsync(uri + "?Id=" + input.id );
                if(result.IsSuccessStatusCode ==false)
                { return new Dictionary<string, string>(); }

                JToken re =await Getsuccess(result);
                return re["result"].ToDictionary(k=>k.ToString(),v=>v.ToString());    
            }
        }

        public async Task<string> UpdateRequest(Uri uri, IResult input)
        {
            using(client)
            {
                var inp = GetJson(input);
                var result = await client.PutAsync(uri, inp);
                if (result.IsSuccessStatusCode == false)
                { return "请求失败，查看是否用于权限"; }
                else
                { return result.StatusCode.ToString(); }
            }
        }

        public async Task<JToken> Getsuccess(HttpResponseMessage result)
        {
            string str = await result.Content.ReadAsStringAsync();

            var js = JToken.Parse(str);


            return js;
        }











    }
}
