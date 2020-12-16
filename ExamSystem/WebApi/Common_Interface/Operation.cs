using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.WebApi.Common_Interface
{
    public interface Operation
    {
        Task<int> CreateRequest();

        Task<int> UpdateRequest();

        Task<int> DeleteRequest();

        Task<int> GetRequest();
    }
}
