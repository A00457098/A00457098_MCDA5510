namespace MergeCsvFiles
{
    /// <summary>
    /// This class contains propeerties which matches the header
    /// This is required by CSV Hleper library to parse the files
    /// </summary>
    public class HeaderInfo
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string emailAddress { get; set; }

    }

    public class OutputHeaderInfo
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string emailAddress { get; set; }
        public string Date { get; set; }

    }
}
