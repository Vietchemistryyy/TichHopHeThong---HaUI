using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
namespace KQHT
{
    internal class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;

        public DataUtil()
        {
            filename = "KQHT.xml";
            doc = new XmlDocument();
            if (!File.Exists(filename))
            {
                XmlElement bangdiem = doc.CreateElement("bangdiem");
                doc.AppendChild(bangdiem); 
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }
        public bool Exists(string masv)
        {
            XmlNode find = root.SelectSingleNode($"sinhvien[@masv='{masv}']");
            return find != null;
        }

        public void Add(SinhVien s)
        {
            XmlElement sv = doc.CreateElement("sinhvien");
            sv.SetAttribute("masv", s.masv);
            sv.SetAttribute("monhoc", s.monhoc);
            XmlElement diemlan1 = doc.CreateElement("diemlan1");
            diemlan1.InnerText = s.diemlan1;
            XmlElement diemlan2 = doc.CreateElement("diemlan2");
            diemlan2.InnerText = s.diemlan2;

            sv.AppendChild(diemlan1);
            sv.AppendChild(diemlan2);
            root.AppendChild(sv);
            doc.Save(filename);
        }
        public List<SinhVien> GetAllData()
        {
            XmlNodeList nodes = root.SelectNodes("sinhvien");
            List<SinhVien> li = new List<SinhVien>();
            foreach (XmlNode item in nodes)
            {
                SinhVien s = new SinhVien();
                s.masv = item.Attributes[0].InnerText;
                s.monhoc = item.Attributes[1].InnerText;
                s.diemlan1 = item.SelectSingleNode("diemlan1").InnerText;
                s.diemlan2 = item.SelectSingleNode("diemlan2").InnerText;
                li.Add(s);
            }
            return li;
        }
        public bool Update(SinhVien s)
        {
            XmlNode find = root.SelectSingleNode("sinhvien[@masv= '" + s.masv + "']");
            if (find != null) 
            {
                XmlElement sv = doc.CreateElement("sinhvien");
                sv.SetAttribute("masv", s.masv);
                sv.SetAttribute("monhoc", s.monhoc);
                XmlElement diemlan1 = doc.CreateElement("diemlan1");
                diemlan1.InnerText = s.diemlan1;
                XmlElement diemlan2 = doc.CreateElement("diemlan2");
                diemlan2.InnerText = s.diemlan2;

                sv.AppendChild(diemlan1);
                sv.AppendChild(diemlan2);
                root.ReplaceChild(sv, find);
                doc.Save(filename);
                return true;
            }
            return false;
        }
        public bool Delete(string masv)
        {
            XmlNode find = root.SelectSingleNode("sinhvien[@masv= '" + masv + "']");
            if (find != null)
            {
                root.RemoveChild(find);
                doc.Save(filename);
                return true;
            }
            return false;
        }
    }
}
