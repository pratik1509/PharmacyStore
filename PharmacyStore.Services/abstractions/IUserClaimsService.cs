using System.Collections.Generic;

namespace PharmacyStore.Services.Abstraction
{
    public interface IUserClaimsService
    {
        string Id { get; }
        string Name { get; }
        string Email { get; }
        string Type { get; }

        Dictionary<string, string> GetAllClaims();
    }
}