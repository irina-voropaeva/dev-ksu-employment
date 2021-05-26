namespace KsuEmployment.Common.Requests
{
    public class CompanyResetPasswordRequest
    {
        public string currentPassword { get; set; }
        public string newPassword { get; set; }
    }
}
