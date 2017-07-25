namespace SimpleClassRegisterApp.Models
{
    public class TeacherSubject
    {
        public int TeacherSubjectID { get; set; }
       
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
        public int? TeacherID { get; set; }
        public Teacher Teacher { get; set; }
     
    }
}
