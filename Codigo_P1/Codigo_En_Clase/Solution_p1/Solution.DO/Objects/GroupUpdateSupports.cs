using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
    public partial class GroupUpdateSupports
    {
        public int GroupUpdateSupportId { get; set; }
        public int GroupUpdateId { get; set; }
        public int GroupUserId { get; set; }
        public DateTime UpdateSupportedDate { get; set; }

        public virtual GroupUpdates GroupUpdate { get; set; }
    }
}
