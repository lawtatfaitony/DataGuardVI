using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceBussiness.Public
{
    public partial class ModalDialog
    {
        public string MsgCode { get; set; }    // 1=Success 0=Fail -1=Other 

        public string Message { get; set; }
         
    }
    public partial class MetaModal
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "OK";
        public int ErrorCode { get; set; } = -1;
    }

    public partial class ResponseModal
    {
        public  MetaModal meta { get; set; }
        public  Object data { get; set; }
    }
    #region
//#状态码（状态码）状态描述（状态描述）
//200 
//OK-[GET]：服务器成功返回用户请求的数据，该操作是幂等的。

//201
//创建-[POST / PUT / PATCH]：​​用户新建或修改数据成功。

//202
//接受-[*]：表示一个请求已经进入后台队列（初始化任务）

//204
//没有内容-[DELETE]：用户删除数据成功。

//400
//无效请求-[POST / PUT / PATCH]：​​用户发出的请求有错误，服务器没有进行新建或修改数据的操作，该操作是幂等的。

//401
//未经授权-[*]：表示用户冇权限（令牌，用户名，密码错误）。

//403
//禁止-[*]：表示用户得到授权（同401错误相对），但访问是被禁止的。

//404
//找不到-[*]：用户发出的请求针对的是不存在的记录，服务器没有进行操作。

//406
//不可接受-[GET]：用户请求的格式不可得（某种用户请求json格式，但是只有xml格式）

//410
//-[GET]：用户请求的资源被永久删除，且不会再得到的。

//422
//无法处理的实体-[POST / PUT / PATCH]：​​用户请求的资源被永久删除，且不会再得到。

//500
//内部服务器错误-[*]：服务器发生错误，用户将无法判断发出的请求是否成功。

    #endregion
}
