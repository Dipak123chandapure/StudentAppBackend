using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccessAPI.Models
{
    public class Group
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public bool? IsVirtuallyDeleted { get; set; }

    }
}
