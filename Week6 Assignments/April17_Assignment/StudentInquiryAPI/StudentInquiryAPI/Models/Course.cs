namespace StudentInquiryAPI.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public int FeesAmount { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Enquiry>? Enquiries { get; set; }
        public ICollection<Admission>? Admissions { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
