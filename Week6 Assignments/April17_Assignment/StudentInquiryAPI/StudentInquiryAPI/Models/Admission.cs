namespace StudentInquiryAPI.Models
{
    public class Admission
    {
        public int AdmissionID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string Status { get; set; }
        public int StudentId { get; set; }
        public int CourseID { get; set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
