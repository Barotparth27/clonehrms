using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrmscloneapi.Model
{
    public class ResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }
        public string AdditionalMessage { set; get; }
        public object ResponseData { set; get; }
        public int StatusCode { set; get; }
    }
}
