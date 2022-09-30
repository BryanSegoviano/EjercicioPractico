using Vista.Modelo;

namespace Vista.Modelo
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Phone Phone { get; set; }
        public Email Email { get; set; }

        public Address Address { get; set; }

        public Student()
        {
        }
        public Student(int studentId)
        {
            this.StudentId = studentId;
        }
        public Student(string name, string lastName, DateTime createdOn,
            DateTime updatedOn, Phone phone, Email email, Address address)
        {
            this.Name = name;
            this.LastName = lastName;
            this.CreatedOn = createdOn;
            this.UpdatedOn = updatedOn;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.LastName} - " +
                $"{this.CreatedOn} - {this.UpdatedOn}";
        }
    }
}
