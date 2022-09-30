namespace Vista.Modelo
{
    internal class Phone
    {
        public int PhoneId { get; set; }
        public int StudentId { get; set; }
        public string PhoneNumber { get; set; }

        public Phone()
        {
        }

        public Phone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public Phone(int studentId, string phoneNumber)
        {
            this.StudentId = studentId;
            this.PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{this.PhoneId} - {this.StudentId} - {this.PhoneNumber}";
        }
    }
}
