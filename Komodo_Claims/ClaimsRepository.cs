using System;
using System.Collections.Generic;
using System.Text;

namespace Komodo_Claims
{
    public class ClaimsRepository
    {
        public readonly Queue<Claims> _claims = new Queue<Claims>();

        public Queue<Claims> AllClaims()
        {
            return _claims;
        }
        public bool NextClaim(Claims nextClaim)
        {
            Claims contentToQueue = nextClaim;
            if (contentToQueue != null)
            {
                _claims.Dequeue();
                return true;
            }
            else
                return false;
        }

        public Claims PeekNextClaim()
        {
            return _claims.Peek();
        }

        public bool Addclaim(Claims newClaim)
        {
            int startingCount = _claims.Count;
            _claims.Enqueue(newClaim);
            bool claimAdded = (_claims.Count > startingCount) ? true : false;
            return claimAdded;
        }
    }
}
