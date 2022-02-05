using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class TransferObjectList
    {
        public string TransferObjectListId { get; set; }
        public string HolderId { get; set; }
        public string HolderName { get; set; }
        public string HolderRfId { get; set; }
        public string ObjectId { get; set; }
        public string ObjectName { get; set; }
        public string ObjectRfId { get; set; }
        public int StorageState { get; set; }
        public long ObjectLogDateTime { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string MainComId { get; set; }
    }
}
