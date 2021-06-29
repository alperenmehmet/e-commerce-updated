using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities.Concrete
{
    public partial class UserOperationClaim
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public virtual OperationClaim OperationClaim { get; set; }
        public virtual User User { get; set; }
    }
}
