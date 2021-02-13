using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
{
    public class Groups
    {
        //public Groups()
        //{
        //    Foci = new HashSet<Foci>();
        //    GroupInvitations = new HashSet<GroupInvitations>();
        //    GroupRequests = new HashSet<GroupRequests>();
        //}

        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        //public ICollection<Foci> Foci { get; set; }
        //public ICollection<GroupInvitations> GroupInvitations { get; set; }
        //public ICollection<GroupRequests> GroupRequests { get; set; }
    }
}
