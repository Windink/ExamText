using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.WebApi.entities
{
    public class UserDto
    {
        public string userName ;
        public string name  ;
        public string surname ;
        public string emailAddress ;
        public string[] roleNames  ;
        public string password = "123";
    }
}
