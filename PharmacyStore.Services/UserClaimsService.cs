using PharmacyStore.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyStore.Services
{
    public class UserClaimsService : IUserClaimsService
    {
        public string Id => "";

        public string Name => "";

        public string Email => "";

        public string Type => "";

        public Dictionary<string, string> GetAllClaims()
        {
            return new Dictionary<string, string>();
        }
    }
}
