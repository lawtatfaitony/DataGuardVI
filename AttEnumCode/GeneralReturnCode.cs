using System;
using System.ComponentModel;
using System.Reflection;
namespace AttEnumCode
{
    public enum GeneralReturnCode
    { 
        [EnumDisplayName("GeneralUI_Success")]
        SUCCESS = -1,

        [EnumDisplayName("GeneralUI_Fail")]
        FAIL = 1,

        [EnumDisplayName("GeneralUI_EXCEPTION")]
        EXCEPTION = 2,

        [EnumDisplayName("GeneralUI_UNAUTHORIED")]
        UNAUTHORIED = 3,

        [EnumDisplayName("GeneralUI_PAGE_NO_ERR")]
        GENERALUI_PAGE_NO_ERR = 4,

        [EnumDisplayName("GeneralUI_NoRecord")]
        GENERALUI_NO_RECORD = 5,

        [EnumDisplayName("FILE_UPLOAD_SUCCESS")]
        FILE_UPLOAD_SUCCESS = 6,

        [EnumDisplayName("FILE_UPLOAD_FAIL")]
        FILE_UPLOAD_FAIL = 7,

        [EnumDisplayName("FILESIZE_IS_LIMITED")]
        FILESIZE_IS_LIMITED = 8,

        [EnumDisplayName("GeneralUI_ListNoRecord")]
        LIST_NO_RECORD = 9
    } 
}
