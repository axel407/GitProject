using System.Runtime.Serialization;

namespace Person
{
    [Serializable]
    [DataContract]
    public class Person
    {
        //поля класса Person
        private string name = "Un";
        private string surname = "Un";
        private int age;
        private string phone = "Un";

        //свойства класса Person
        [DataMember]
        public string Name
        {
            get { return name; }
            set
            {
                try
                {
                    name = value;
                }
                catch
                {
                    throw;
                }
            }
        }
        [DataMember]
        public string Surname
        {
            get { return surname; }
            set
            {
                try
                {
                    surname = value;
                }
                catch
                {
                    throw;
                }
            }
        }
        [DataMember]
        public int Age
        {
            get { return age; }
            set
            {
                try
                {
                    if (value > 0)
                        age = value;
                    else
                        throw new Exception("Wrong age value! Try again");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        [DataMember]
        public string Phone
        {
            get { return phone; }
            set
            {
                try
                {
                    phone = value;
                }
                catch
                {
                    throw;
                }
            }
        }

        //конструкторы класса Person
        public Person() : this("Unknown", "Unknown", 2, "+000 000 000")
        {

        }
        public Person(string _name, string _surname, int _age, string _phone)
        {
            Name = _name;
            Surname = _surname;
            Age = _age;
            Phone = _phone;
        }

        //метод печати информации на экран
        public void Print()
        {
            Console.WriteLine("Name: {0}\nSurname: {1}\nAge: {2}\nPhone: {3}", Name, Surname, Age, Phone);
        }
    }
}