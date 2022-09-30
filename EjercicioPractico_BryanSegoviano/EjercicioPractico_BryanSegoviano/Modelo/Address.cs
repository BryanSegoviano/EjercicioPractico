namespace Vista.Modelo
{
    internal class Address
    {
        public int AddressId { get; set; }
        public int StudentId { get; set; }
        public string AddressInf { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string State { get; set; }

        public Address()
        {
        }

        public Address(string addressInf, string city, int zipCode, string state)
        {
            AddressInf = addressInf;
            City = city;
            ZipCode = zipCode;
            State = state;
        }

        public Address(int studentId, string addressInf,
            string city, int zipCode, string state)
        {
            this.StudentId = studentId;
            this.AddressInf = addressInf;
            this.City = city;
            this.ZipCode = zipCode;
            this.State = state;
        }
        public override string ToString()
        {
            return $"{this.AddressId} - {this.StudentId} - {this.AddressInf} " +
                $"- {this.City} - {this.ZipCode} - {this.State}";
        }
    }
}
