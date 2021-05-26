using System;

namespace KsuEmployment.Common.Requests
{
    public class ExperienceRequest
    {
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int ResumeId { get; set; }
    }
}
