using System.ComponentModel;

namespace tiorem.editor
{
    public enum aymkError
    {
        [Description("System Error")]
        GeneralError = 0,

        [Description("Item couldn't update")]
        UpdateError = 1,

        [Description("Item couldn't delete")]
        DeleteError = 2,

        [Description("Item couldn't add")]
        AddError = 3,

        [Description("Item couldn't get")]
        GetError = 4,

        [Description("Item list couldn't get")]
        GetListError = 5,

        [Description("Username or password is incorret")]
        UsernamePasswordWrong = 6,

        [Description("User not found")]
        UserNotFound = 7,

        [Description("User can not register")]
        RegisterError = 8,

        [Description("Email is already registered")]
        Register_Email_Exist = 9,

        [Description("Username is already registered")]
        Register_Username_Exist = 10,

        [Description("Account data is not valid")]
        Register_Not_Valid = 11,

    }

    public static class aymkMethodType
    {
        public static readonly string NotFound = "Record not found";
        public static readonly string Add = "add";
        public static readonly string Update = "update";
        public static readonly string Delete = "delete";
        public static readonly string Get = "get";
        public static readonly string GetByIncludes = "getbyincludes";
        public static readonly string GetById = "getbyid";
        public static readonly string GetList = "getlist";
        public static readonly string ChangeStatus = "changestatus";
        public static readonly string Register = "register";
        public static readonly string Login = "login";
        public static readonly string ForgotPassword = "forgotpassword";
        public static readonly string Catalogs = "catalogs"; 

    }

   
}