using ExamSystem.WebApi.Common_Interface;
using ExamSystem.WebApi.entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.WebApi
{
    public class UserWebRequest : Operation
    {
        private HttpClient client;
       // private StringContent input;

        public UserWebRequest()
        {
            client = new HttpClient();
           
        }

        private StringContent GetJson(Object Dto)
        {
            var js = JsonConvert.SerializeObject(Dto);

            var  input = new StringContent(js);

            input.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("Application/json") { CharSet = "utf-8" };

            return input;
        }


        public Task<int> CreateRequest(string uri,UserDto userDto)
        {


            throw new NotImplementedException();

        }

        public Task<int> DeleteRequest()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetRequest()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateRequest()
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateRequest()
        {
            throw new NotImplementedException();
        }
    }
}
