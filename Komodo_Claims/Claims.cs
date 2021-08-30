using System;
using System.Collections.Generic;
using System.Text;

namespace Komodo_Claims
{
    public enum ClaimType { Car = 1, Home, Theft }

    public class Claims
    {
        public int ClaimID { get; set; }
        private object id;
        public ClaimType ClaimType { get; set; }
        private object claimType;
        public string Description { get; set; }
        private object description;
        public decimal ClaimAmount { get; set; }
        private object claimAmount;
        public DateTime DateOfIncident { get; set; }
        private object dateOfIncident;
        public DateTime DateOfClaim { get; set; }
        private object dateOfClaim;
        public bool IsValid
        {
            get
            {
                if (DateOfClaim.Month > (DateOfIncident.Month + 1))
                {
                    return false;
                }
                else
                    return true;
            }
        }
        private object valid;
        public Claims(int v) { }
         
        public Claims(int id, ClaimType claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = id;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

        public Claims(object id, object claimType, object description, object claimAmount, object dateOfIncident, object dateOfClaim, object valid)
        {
            this.claimType = claimType;
            this.id = id;
            this.description = description;
            this.claimAmount = claimAmount;
            this.dateOfIncident = dateOfIncident;
            this.dateOfClaim = dateOfClaim;
            this.valid = valid;
        }

        public Claims()
        {
        }
    }
}
