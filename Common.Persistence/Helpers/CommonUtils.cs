using System;
using System.Linq;
using System.Security.Cryptography;
using MongoDB.Bson;

namespace Common.Persistence.Helpers
{
    public static class CommonUtils
    {
        public static bool IsValidId(string userId)
        {
            ObjectId id;
            return (userId != string.Empty && ObjectId.TryParse(userId, out id));

        }

        public static string GetNextNhsNumber()
        {
            var random = new Random();
            var i = random.Next();
            return Convert.ToString(i);
        }

		public static string GetRandomCode()
		{
			using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
			{
				byte[] tokenData = new byte[32];
				rng.GetBytes(tokenData);

				var code = String.Join(String.Empty, Convert.ToBase64String(tokenData).Select(p => Char.IsLetter(p) ? p.ToString() : String.Empty));
				return code.ToLower();
			}
		}
	}
}
