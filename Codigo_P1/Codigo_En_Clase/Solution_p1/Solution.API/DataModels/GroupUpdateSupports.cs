using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
{
    public class GroupUpdateSupports
    {
        public int GroupUpdateSupportId { get; set; }
        public int GroupUpdateId { get; set; }
        public int GroupUserId { get; set; }
        public DateTime UpdateSupportedDate { get; set; }

        public virtual GroupUpdates GroupUpdate { get; set; }
    }
}
