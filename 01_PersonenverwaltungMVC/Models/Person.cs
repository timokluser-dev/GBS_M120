namespace TimoKluser.PersonenverwaltungMVC
{
    public class Person
    {
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string TelefonNr { get; set; }

        public Person(string nn, string vn, string tn)
        {
            Name = nn;
            Vorname = vn;
            TelefonNr = tn;
        }
    }
}
