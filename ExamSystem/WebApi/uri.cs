using System;
using System.Collections.Generic;
using System.Text;
using Abp.Authorization;

namespace ExamSystem.WebApi
{
    public class uri
    {
        public const string baseUrl = "http://localhost:21021";  //服务器地址

        public const string loginToken = "/api/TokenAuth/Authenticate"; //获取Token地址
        
    }
}
