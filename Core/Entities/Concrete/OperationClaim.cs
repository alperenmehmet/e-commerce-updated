using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities.Concrete
{
    public partial class OperationClaim
    {
        public OperationClaim()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }

        public int OperationClaimId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
