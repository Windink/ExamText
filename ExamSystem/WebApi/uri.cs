using System;
using System.Collections.Generic;
using System.Text;
using Abp.Authorization;

namespace ExamSystem.WebApi
{
    public class uri
    {
        public const string BaseUrl = "http://localhost:21021";  //服务器地址

        public const string loginToken = "/api/TokenAuth/Authenticate"; //获取Token地址

        public const string Current_Server = "/api/services/app/Session/GetCurrentLoginInformations"; // 获取当前服务状态

        public const string User = "/api/services/app/User/"; //用户通用地址

        public const string Role = "/api/services/app/Role/"; // 角色

    }
}
