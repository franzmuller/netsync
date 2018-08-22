using System;

namespace DataAccessLayer
{
    public class Deleted
    {
        public long Id { get; set; }
        public string TableName { get; set; }
        public string KeyName { get; set; }
        public string KeyValue { get; set; }

        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        public int SyncStatus { get; set; }
    }
}
