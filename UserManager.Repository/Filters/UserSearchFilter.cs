using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Repository.Filters
{
    public class UserSearchFilter
    {
        public string Name { get; set; }
        public int? DisplayRecordCount { get; set; }
    }
}
