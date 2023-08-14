using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Student
{
    [Serializable]
    [KnownType(typeof(Person.Person))]
    [XmlInclude(typeof(Person.Person))]
    [DataContract]
    public class Student : Person.Person, IComparable
    {
        //поля класса Student
        private double average;
        private int number_of_group;

        //свойства класса Student
        [DataMember]
        public double Average
        {
            get { return average; }
            set
            {
                try
                {
                    if (value > 0 && value <= 12)
                        average = value;
                    else
                        throw new Exception("Wrong value. Try again");
                }
                catch
                {
                    throw;
                }
            }
        }
        [DataMember]
        public int Number_Of_Group
        {
            get { return number_of_group; }
            set
            {
                try
                {
                    if (value > 0)
                        number_of_group = value;
                    else
                        throw new Exception("Wrong value! try again");
                }
                catch
                {
                    throw;
                }
            }
        }

        //конструкторы класса Student
        public Student() : this(12, 1)
        {

        }
        public Student(double _average, int _number_of_group)
        {
            Average = _average;
            Number_Of_Group = _number_of_group;
        }

        //метод печати информации на экран
        new public void Print()
        {
            base.Print();
            Console.WriteLine("Average: {0}\nNumber Of Group: {1}", Average, Number_Of_Group);
        }

        //Реализация CompareTo, сравнивается по фамилии
        public int CompareTo(object? obj)
        {
            if (obj is Student)
                return this.Surname.CompareTo((obj as Student).Surname);

            throw new NotImplementedException();
        }

        public class SortByName : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                if (x is Student && y is Student)
                    return (x as Student).Name.CompareTo((y as Student).Name);

                throw new NotImplementedException();
            }
        }
        public class SortByAge : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                if (x is Student && y is Student)
                    return (x as Student).Age.CompareTo((y as Student).Age);

                throw new NotImplementedException();
            }
        }
        public class SortByAverage : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                if (x is Student && y is Student)
                    return (x as Student).Average.CompareTo((y as Student).Average);

                throw new NotImplementedException();
            }
        }
        public class SortByGroup : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                if (x is Student && y is Student)
                    return (x as Student).Number_Of_Group.CompareTo((y as Student).Number_Of_Group);

                throw new NotImplementedException();
            }

        }
    }
}