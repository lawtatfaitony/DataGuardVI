using System;
using System.ComponentModel;
using System.Reflection;
namespace AttEnumCode
{ 
    public enum AuthorizationErrorCode
    {
        [EnumDisplayName("GeneralUI_AUTH_WRONG_USERNAME_OR_PASSWORD")]
        WRONG_USERNAME_OR_PASSWORD = 0,
        [EnumDisplayName("GeneralUI_LoginFail")]
        LONGIN_FAIL = 10001,
        [EnumDisplayName("GeneralUI_SUCC")]
        SUCCESS = -1
    }
    public enum LoginErrorCode
    {
        [EnumDisplayName("GeneralUI_LoginSucc")]
        SUCCESS = -1
    }

    public enum RegisterErrorCode
    { 
        [EnumDisplayName("GeneralUI_RegisterFail")]
        RREGISTER_FAIL = 10021
    }
}
