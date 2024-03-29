﻿using System.Collections;
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
        public void Print()
        {
            int i = 0;
            try
            {
                foreach (object o in group)
                {
                    Student.Student temp = new Student.Student();
                    temp = group[i++] as Student.Student;
                    Console.WriteLine("{0}. {1} {2}", i++, temp.Name, temp.Surname);
                    i--;
                }
            }
            catch
            {
                throw;
            }
        }
        public void Save()
        {
            try
            {
                FileStream file = new FileStream("group.dat", FileMode.Create, FileAccess.Write);
                BinaryWriter writer = new BinaryWriter(file);
                writer.Write(group.Count);
                for (int i = 0; i < group.Count; i++)
                {
                    Student.Student temp = group[i] as Student.Student;
                    writer.Write(temp.Name);
                    writer.Write(temp.Surname);
                    writer.Write(temp.Phone);
                    writer.Write(temp.Age);
                    writer.Write(temp.Average);
                    writer.Write(temp.Number_Of_Group);
                }
                writer.Close();
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Load()
        {
            try
            {
                FileStream file1 = new FileStream("group.dat", FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(file1);
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    Student.Student student1 = new Student.Student();
                    student1.Name = reader.ReadString();
                    student1.Surname = reader.ReadString();
                    student1.Phone = reader.ReadString();
                    student1.Age = reader.ReadInt32();
                    student1.Average = reader.ReadDouble();
                    student1.Number_Of_Group = reader.ReadInt32();

                    group.Add(student1);
                }
                reader.Close();
                file1.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void Sort(int choice)
        {
            try
            {
                if (choice == 1)
                    group.Sort(new Student.Student.SortByName());
                else if (choice == 2)
                    group.Sort();
                else if (choice == 3)
                    group.Sort(new Student.Student.SortByAge());
                else if (choice == 4)
                    group.Sort(new Student.Student.SortByAverage());
                else if (choice == 5)
                    group.Sort(new Student.Student.SortByGroup());
                else
                    throw new Exception("Wrong choice");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public object Clone()
        {
            AcademyGroup new_list = new AcademyGroup();
            for (int i = 0; i < group.Count; i++)
                new_list.group.Add(this.group[i]);
            return new_list;
        }
    }
}