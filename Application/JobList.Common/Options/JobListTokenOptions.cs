using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace KsuEmployment.Common.Options
{
    public class JobListTokenOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Access_Token_Lifetime { get; set; }
        public string Security_Key { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Security_Key));
    }
}
