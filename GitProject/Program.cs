using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace GitProject
{
    internal class Program
    {
        public class Main_Class
        {
            public void Add(AcademyGroup.AcademyGroup agroup)
            {
                try
                {
                    Console.Clear();
                    Student.Student student = new Student.Student();
                    Console.WriteLine("Imput student data");
                    Console.WriteLine("Name: ");
                    student.Name = Console.ReadLine();
                    Console.WriteLine("Surname: ");
                    student.Surname = Console.ReadLine();
                    Console.WriteLine("Phone: ");
                    student.Phone = Console.ReadLine();
                    Console.WriteLine("Age: ");
                    student.Age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Average: ");
                    student.Average = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Number of group: ");
                    student.Number_Of_Group = Convert.ToInt32(Console.ReadLine());

                    agroup.Add(student);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            public void Remove(AcademyGroup.AcademyGroup agroup)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Imput surname: ");
                    string surname = Console.ReadLine();
                    agroup.Remove(surname);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            public void Edit(AcademyGroup.AcademyGroup agroup)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Imput surname: ");
                    string surname = Console.ReadLine();
                    agroup.Edit(surname);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            public void Menu()
            {
                AcademyGroup.AcademyGroup agroup = new AcademyGroup.AcademyGroup();
                //agroup.Load();
                object clone = agroup.Clone();
                FileStream stream = null;
                BinaryFormatter formatter = null;
                XmlSerializer serializer = null;
                SoapFormatter soap = null;
                DataContractJsonSerializer jsonFormatter = null;
                try
                {
                    do
                    {
                        Console.WriteLine("Test original obj/clone(O/C)");
                        char chO = Convert.ToChar(Console.ReadLine());
                        if (chO == 'O')
                            do
                            {
                                Console.Clear();
                                int choice;
                                Console.WriteLine("Make choice" +
                                    "\n1. Add\n2. Remove\n3. Edit" +
                                    "\n4. Print\n5. Sort\n6. Serialization (binary)" +
                                    "\n7. Deserialization(binary)" +
                                    "\n8. Serialization (xml)\n9. Deserialization (xml)" +
                                    "\n10. Serialization (json)\n11. Deserialization (json)" +
                                    "\n12. Serialization (soap)\n13. Deserialazton (soap)");
                                choice = Convert.ToInt32(Console.ReadLine());
                                switch (choice)
                                {
                                    case 1:
                                        Add(agroup);
                                        break;
                                    case 2:
                                        Remove(agroup);
                                        break;
                                    case 3:
                                        Edit(agroup);
                                        break;
                                    case 4:
                                        Console.Clear();
                                        agroup.Print();
                                        Console.ReadKey();
                                        break;
                                    case 5:
                                        Console.Clear();
                                        Console.WriteLine("1. By Name\n2. By Surname\n3. By Age\n4. By Average\n5. By Group");
                                        int ch = Convert.ToInt32(Console.ReadLine());
                                        agroup.Sort(ch);
                                        break;
                                    case 6:
                                        stream = new FileStream("AcademyGroupBinary", FileMode.Create);
                                        formatter = new BinaryFormatter();
                                        formatter.Serialize(stream, agroup);
                                        stream.Close();
                                        Console.WriteLine("Сериализация успешно выполнена!");
                                        Console.ReadKey();
                                        break;
                                    case 7:
                                        stream = new FileStream("Person.txt", FileMode.Open);
                                        formatter = new BinaryFormatter();
                                        agroup = (AcademyGroup.AcademyGroup)formatter.Deserialize(stream);
                                        agroup.Print();
                                        Console.ReadKey();
                                        stream.Close();
                                        break;
                                    case 8:
                                        stream = new FileStream("data.xml", FileMode.Create);
                                        serializer = new XmlSerializer(typeof(AcademyGroup.AcademyGroup));
                                        serializer.Serialize(stream, agroup);
                                        stream.Close();
                                        Console.WriteLine("Сериализация успешно выполнена!");
                                        Console.ReadKey();
                                        break;
                                    case 9:
                                        stream = new FileStream("data.xml", FileMode.Open);
                                        serializer = new XmlSerializer(typeof(AcademyGroup.AcademyGroup));
                                        agroup = (AcademyGroup.AcademyGroup)serializer.Deserialize(stream);
                                        agroup.Print();
                                        Console.ReadKey();
                                        stream.Close();
                                        break;
                                    case 10:
                                        stream = new FileStream("data1.json", FileMode.Create);
                                        jsonFormatter = new DataContractJsonSerializer(typeof(AcademyGroup.AcademyGroup));
                                        jsonFormatter.WriteObject(stream, agroup);
                                        stream.Close();
                                        Console.WriteLine("Сериализация успешно выполнена!");
                                        Console.ReadKey();
                                        break;
                                    case 11:
                                        stream = new FileStream("data1" +
                                            ".json", FileMode.Open);
                                        jsonFormatter = new DataContractJsonSerializer(typeof(AcademyGroup.AcademyGroup));
                                        agroup = (AcademyGroup.AcademyGroup)jsonFormatter.ReadObject(stream);
                                        agroup.Print();
                                        Console.ReadKey();
                                        stream.Close();
                                        break;
                                    case 12:
                                        stream = new FileStream("soap.xml", FileMode.Create);
                                        soap = new SoapFormatter();
                                        soap.Serialize(stream, agroup);
                                        stream.Close();
                                        Console.WriteLine("Сериализация успешно выполнена!");
                                        break;
                                    case 13:
                                        stream = new FileStream("soap.xml", FileMode.Open);
                                        soap = new SoapFormatter();
                                        agroup = (AcademyGroup.AcademyGroup)soap.Deserialize(stream);
                                        stream.Close();
                                        break;
                                    default:
                                        throw new Exception("Wrong choice");
                                        break;

                                }
                                agroup.Save();

                                Console.Clear();
                                Console.WriteLine("Continue? (Y/N)");
                                char ch2 = Convert.ToChar(Console.ReadLine());
                                if (ch2 == 'Y')
                                    continue;
                                else if (ch2 == 'N')
                                    break;
                                else
                                    throw new Exception("Wrong choice");
                            }
                            while (true);
                        else if (chO == 'C')
                            do
                            {
                                Console.Clear();
                                int choice;
                                Console.WriteLine("Make choice\n1. Add\n2. Remove\n3. Edit\n4. Print\n5. Sort");
                                choice = Convert.ToInt32(Console.ReadLine());
                                switch (choice)
                                {
                                    case 1:
                                        Add(clone as AcademyGroup.AcademyGroup);
                                        break;
                                    case 2:
                                        Remove(clone as AcademyGroup.AcademyGroup);
                                        break;
                                    case 3:
                                        Edit(clone as AcademyGroup.AcademyGroup);
                                        break;
                                    case 4:
                                        Console.Clear();
                                        (clone as AcademyGroup.AcademyGroup).Print();
                                        Console.ReadKey();
                                        break;
                                    case 5:
                                        Console.Clear();
                                        Console.WriteLine("1. By Name\n2. By Surname\n3. By Age\n4. By Average\n5. By Group");
                                        int ch = Convert.ToInt32(Console.ReadLine());
                                        (clone as AcademyGroup.AcademyGroup).Sort(ch);
                                        break;
                                    default:
                                        throw new Exception("Wrong choice");
                                        break;
                                }


                                Console.Clear();
                                Console.WriteLine("Continue? (Y/N)");
                                char ch2 = Convert.ToChar(Console.ReadLine());
                                if (ch2 == 'Y')
                                    continue;
                                else if (ch2 == 'N')
                                    break;
                                else
                                    throw new Exception("Wrong choice");
                            }
                            while (true);
                        else
                            throw new Exception("Wrong choice");

                    }
                    while (true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void Main(string[] args)
        {
            Main_Class test = new Main_Class();
            test.Menu();
        }
    }
} 