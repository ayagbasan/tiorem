using System;

namespace tiorem.editor
{

    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public dynamic Data { get; set; }


        public ApiResponse()
        {
            this.IsSuccess = true;
        }

        public ApiResponse(dynamic data)
        {
            this.IsSuccess = true;
            this.Data = data;
        }

        public ApiResponse(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

        public ApiResponse(bool isSuccess, string message, string detail)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.Detail = detail;
        }

        public ApiResponse(bool isSuccess, string message, string detail,dynamic data)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.Detail = detail;
            this.Data = data;
        }


        public ApiResponse(aymkError error, string errDetail="")
        {
            this.IsSuccess = false;
            this.Message = error.GetDescription();
            this.Detail = errDetail;           
        }

        public ApiResponse(aymkError error, string entityName,string errDetail = "")
        {
            this.IsSuccess = false;
            this.Message = error.GetDescription();
            this.Detail = string.Format("{0}{1}{2}", entityName, errDetail == "" ? "" : Environment.NewLine, errDetail);
        }

        public ApiResponse(aymkError error, string entityName, Exception ex)
        {
            this.IsSuccess = false;
            this.Message = error.GetDescription();          
            this.Detail = string.Format("{0}{1}{2}", entityName, Environment.NewLine, ex.ToString());
        }

    }
}
