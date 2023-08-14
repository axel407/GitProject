using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace AcademyGroup
{
    [Serializable]
    [KnownType(typeof(Person.Person))]
    [KnownType(typeof(Student.Student))]
    [XmlInclude(typeof(Person.Person))]
    [XmlInclude(typeof(Student.Student))]
    [DataContract]
    public class AcademyGroup
    {
        [DataMember]
        private ArrayList group = new ArrayList();

        public AcademyGroup()
        {
            group.Clear();
        }

        public void Add(Student.Student new_student)
        {
            group.Add(new_student);
        }
        public void Remove(string surname)
        {

            for (int i = 0; i < group.Count; i++)
            {
                try
                {
                    Student.Student temp = (Student.Student)group[i];
                    if (temp.Surname == surname)
                    {
                        group.RemoveAt(i);
                        break;
                    }
                }
                catch
                {
                    break;
                    throw;
                }
            }
        }
        public void Edit(string surname)
        {
            bool ifThere = false;
            int index = 0;
            for (int i = 0; i < group.Count; i++)
            {
                try
                {
                    Student.Student temp = (Student.Student)group[i];
                    if (temp.Surname == surname)
                    {
                        ifThere = true;
                        index = i;
                        break;
                    }
                }
                catch
                {
                    break;
                    throw;
                }
            }
            if (ifThere)
            {
                try
                {
                    int choice = 0;
                    Student.Student temp = group[index] as Student.Student;
                    temp.Print();
                    Console.WriteLine("\nWhat do you want to change\n");
                    Console.WriteLine("1.Name\n2.Surname\n3.Age\n4.Average grade\n5.Group №\n6.Phone number\n");
                    choice = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        switch (choice)
                        {
                            case 1:
                                string _name = Console.ReadLine();
                                temp.Name = _name;
                                break;
                            case 2:
                                string _surname = Console.ReadLine();
                                temp.Surname = _surname;
                                break;
                            case 3:
                                int _age = Convert.ToInt32(Console.ReadLine());
                                temp.Age = _age;
                                break;
                            case 4:
                                double _average = Convert.ToDouble(Console.ReadLine());
                                temp.Average = _average;
                                break;
                            case 5:
                                int _group = Convert.ToInt32(Console.ReadLine());
                                temp.Number_Of_Group = _group;
                                break;
                            case 6:
                                string _phone = Console.ReadLine();
                                temp.Phone = _phone;
                                break;
                            default:
                                throw new Exception("Wrong choice. Try again");
                                break;
                        }
                    }
                    catch
                    { throw; }
                }
                catch
                {
                    throw;
                }

            }

        }
    }
}