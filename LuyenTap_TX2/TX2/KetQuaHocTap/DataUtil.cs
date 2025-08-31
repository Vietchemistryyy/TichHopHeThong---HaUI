using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
namespace KetQuaHocTap
{
    internal class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;

        public DataUtil()
        {
            doc = new XmlDocument();
            filename = "bangdiem.xml";
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
            XmlNode find = root.SelectSingleNode("sinhvien[@masv= '" + masv + "']");
            return find != null;
        }
        public void AddSinhVien(SinhVien sv)
        {
            XmlElement sinhvien = doc.CreateElement("sinhvien");
            XmlElement masv = doc.CreateElement("masv");
            XmlElement monhoc = doc.CreateElement("monhoc");
            XmlElement diemlan1 = doc.CreateElement("diemlan1");
            XmlElement diemlan2 = doc.CreateElement("diemlan2");

            masv.InnerText = sv.masv;
            monhoc.InnerText = sv.monhoc;  
            diemlan1.InnerText = sv.diemlan1;
            diemlan2.InnerText = sv.diemlan2;

            sinhvien.SetAttribute("masv", sv.masv);
            sinhvien.SetAttribute("monhoc", sv.monhoc);
            sinhvien.AppendChild(diemlan1);
            sinhvien.AppendChild(diemlan2);

            root.AppendChild(sinhvien);
            doc.Save(filename);
        }
        public List<SinhVien> GetAllSinhVien()
        {
            List<SinhVien> li = new List<SinhVien>();
            XmlNodeList nodes = root.SelectNodes("sinhvien");
            foreach (XmlNode item in nodes) 
            {
                SinhVien s = new SinhVien();
                s.masv = item.Attributes["masv"].Value;
                s.monhoc = item.Attributes["monhoc"].Value;
                s.diemlan1 = item.SelectSingleNode("diemlan1").InnerText;
                s.diemlan2 = item.SelectSingleNode("diemlan2").InnerText;
                li.Add(s);
            }
            return li;
        }
        public bool DeleteSinhVien(string masv)
        {
            XmlNode find = root.SelectSingleNode("sinhvien[@masv='" + masv + "']");
            if (find != null)
            {
                root.RemoveChild(find);
                doc.Save(filename);
                return true;
            }
            return false;
        }
        public bool UpdateSinhVien(SinhVien sv)
        {
            XmlNode find = root.SelectSingleNode("sinhvien[@masv='" + sv.masv + "']");
            if (find != null)
            {
                find.Attributes["monhoc"].Value = sv.monhoc;
                find.SelectSingleNode("diemlan1").InnerText = sv.diemlan1;
                find.SelectSingleNode("diemlan2").InnerText = sv.diemlan2;
                doc.Save(filename); 
                return true;
            }
            return false;
        }
    }
}
