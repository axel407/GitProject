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
    }
}