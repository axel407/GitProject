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
    }
}