using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Db
{
    public class Student
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserID { get; set; }
    }
}
