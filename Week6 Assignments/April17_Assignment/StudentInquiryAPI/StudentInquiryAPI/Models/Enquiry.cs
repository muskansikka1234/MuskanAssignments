namespace StudentInquiryAPI.Models
{
    public class Enquiry
    {
        public int EnquiryID { get; set; }
        public DateTime EnquiryDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EnquiryType { get; set; }
        public int StudentId { get; set; }
        public int CourseID { get; set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
