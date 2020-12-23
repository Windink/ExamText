using ExamSystem.WebApi.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.WebApi.Common_Interface
{
    public interface Operation
    {
        Task<string> CreateRequest(Uri uri,IResult input);

        Task<string> UpdateRequest(Uri uri,IResult input);

        Task<string> DeleteRequest(Uri uri, entity<long> input);

        Task<Dictionary<string,string>> GetRequest(Uri uri, entity<long> input);

        //Task<>
    }
}
