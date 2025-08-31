using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace QLSVTEST
{
    internal class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;
        public DataUtil() 
        {
            filename = "Course1.xml";
            doc = new XmlDocument();
            if (!File.Exists(filename)) 
            {
                XmlElement course = doc.CreateElement("course");
                doc.AppendChild(course);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }

        public void AddStudent(Student s)
        {
            XmlElement st = doc.CreateElement("student");
            st.SetAttribute("id", s.id);
            XmlElement name = doc.CreateElement("name");
            name.InnerText = s.name;
            XmlElement age = doc.CreateElement("age");
            age.InnerText = s.age;
            XmlElement city = doc.CreateElement("city");
            city.InnerText = s.city;

            st.AppendChild(name);
            st.AppendChild(age);
            st.AppendChild(city);
            root.AppendChild(st);
            doc.Save(filename);
        }
        public bool UpdateStudent(Student s)
        {
            XmlNode stfind = root.SelectSingleNode("student[@id= '" + s.id + "']");
            if (stfind != null)
            {
                XmlElement st = doc.CreateElement("student");
                st.SetAttribute("id", s.id);
                XmlElement name = doc.CreateElement("name");
                name.InnerText = s.name;
                XmlElement age = doc.CreateElement("age");
                age.InnerText = s.age;
                XmlElement city = doc.CreateElement("city");
                city.InnerText = s.city;

                st.AppendChild(name);
                st.AppendChild(age);
                st.AppendChild(city);
                root.ReplaceChild(st, stfind);
                doc.Save(filename);
                return true;
            }
            return false;
        }
        public List<Student> GetAllStudent()
        {
            XmlNodeList nodes = root.SelectNodes("student");
            List<Student> li = new List<Student>();
            foreach (XmlNode item in nodes) 
            {
                Student s = new Student();
                s.id = item.Attributes[0].InnerText;
                s.name = item.SelectSingleNode("name").InnerText;
                s.age = item.SelectSingleNode("age").InnerText;
                s.city = item.SelectSingleNode("city").InnerText;
                li.Add(s);
            }
            return li;
        }
        public bool DeleteStudent(string id)
        {
            XmlNode stfind = root.SelectSingleNode("student[@id= '" + id + "']");
            if (stfind != null)
            {
                root.RemoveChild(stfind);
                doc.Save(filename);
                return true;
            }
            return false;
        }
        public Student FindByID(string id) 
        {
            XmlNode stfind = root.SelectSingleNode("student[@id= '" + id + "']");
            Student s = null;
            if (stfind != null) 
            {
                s = new Student();
                s.id = stfind.Attributes[0].InnerText;
                s.name = stfind.SelectSingleNode("name").InnerText;
                s.age = stfind.SelectSingleNode("age").InnerText;
                s.city = stfind.SelectSingleNode("city").InnerText;
            }
            return s;
        }
    }
}
