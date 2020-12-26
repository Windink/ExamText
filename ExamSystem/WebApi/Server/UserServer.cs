using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ExamSystem.WebApi;
using ExamSystem.WebApi.entities;
using Newtonsoft.Json.Linq;

namespace ExamSystem.WebApi.Server
{
    public class UserServer : UserWebRequest
    {
        public UserServer(string login_Token):base(login_Token)
        {

        }

        public async Task<List<string>> GetUserRokes(string uri , entity<long> input)
        {
            var result = await base.GetRequest(uri, input);
            List<string> li = new List<string>();
            foreach(var item in result["roleNames"])
            {
                li.Add(item.ToString());
            }
            return li;
        }


    }
}
