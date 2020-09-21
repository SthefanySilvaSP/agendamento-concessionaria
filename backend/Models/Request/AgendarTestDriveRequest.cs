using System;

namespace backend.Models.Request
{
    public class AgendarTestDriveRequest
    {
        public int IdLogin { get; set; }
        public int IdCarro { get; set; }
        public DateTime data { get; set; }
    }
}