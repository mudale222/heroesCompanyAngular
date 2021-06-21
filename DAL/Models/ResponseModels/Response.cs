using System;

namespace heroesCompany.Models {
    public class Response {
        public bool IsSuccessed { get; set; }
        public Error Error { get; set; }
        public Object Data { get; set; }

    }


    public class Error {
        public Error(int code, string msg) { this.ErrorCode = code; this.ErrorMessage = msg; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
