using System;
using System.Collections.Generic;
using System.Text;

namespace KsuEmployment.Common.Requests
{
    public class EmployeeResetPasswordRequest
    {
        public string currentPassword { get; set; }
        public string newPassword { get; set; }
    }
}
