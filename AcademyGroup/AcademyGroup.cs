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
    }
}