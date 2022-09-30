namespace Dominio
{
    public class Email
    {
        public int EmailId { get; set; }
        public int StudentId { get; set; }
        public string EmailStudent { get; set; }

        public Email()
        {
        }

        public Email(string emailStudent)
        {
            this.EmailStudent = emailStudent;
        }

        public Email(int studentId, string emailStudent)
        {
            this.StudentId = studentId;
            this.EmailStudent = emailStudent;
        }

        public override string ToString()
        {
            return $"{this.EmailId} - {this.StudentId} - {this.EmailStudent}";
        }

    }
}
