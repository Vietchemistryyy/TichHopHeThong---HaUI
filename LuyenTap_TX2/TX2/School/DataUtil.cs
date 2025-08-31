using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Drawing;
namespace School
{
    internal class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;

        public DataUtil()
        {
            doc = new XmlDocument();
            filename = "school.xml";
            if (!File.Exists(filename))
            {
                XmlElement truonghoc = doc.CreateElement("truonghoc");
                doc.AppendChild(truonghoc);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }
        public bool Exists(string malop)
        {
            XmlNode find = root.SelectSingleNode("lophoc[malop= '" + malop + "']");
            return find != null;
        }
        public void AddClass(LopHoc lh)
        {
            XmlElement lophoc = doc.CreateElement("lophoc");
            XmlElement malop = doc.CreateElement("malop");
            XmlElement phonghoc = doc.CreateElement("phonghoc");
            XmlElement sinhvien = doc.CreateElement("sinhvien");
            XmlElement masv = doc.CreateElement("masv");
            XmlElement hoten = doc.CreateElement("hoten");
            XmlElement diachi = doc.CreateElement("diachi");


            malop.InnerText = lh.malop;
            phonghoc.InnerText = lh.phonghoc;   
            masv.InnerText = lh.masv;
            hoten.InnerText = lh.hoten;
            diachi.InnerText = lh.diachi;

            sinhvien.SetAttribute("masv", lh.masv);
            sinhvien.AppendChild(hoten);
            sinhvien.AppendChild(diachi);

            lophoc.AppendChild(sinhvien);
            lophoc.AppendChild(malop);
            lophoc.AppendChild(phonghoc);

            root.AppendChild(lophoc);
            doc.Save(filename);
        }
        public List<LopHoc> GetAllClass()
        {
            List<LopHoc> li = new List<LopHoc>();
            XmlNodeList nodes = root.SelectNodes("lophoc");
            foreach (XmlNode item in nodes) 
            { 
                LopHoc lh = new LopHoc();
                lh.malop = item.SelectSingleNode("malop").InnerText;
                lh.phonghoc = item.SelectSingleNode("phonghoc").InnerText;
                lh.masv = item.SelectSingleNode("sinhvien").Attributes["masv"].Value;
                lh.hoten = item.SelectSingleNode("sinhvien/hoten").InnerText;
                lh.diachi = item.SelectSingleNode("sinhvien/diachi").InnerText;
                li.Add(lh);
            }
            return li;
        }
        public bool DeleteClass(string malop)
        {
            XmlNode find = root.SelectSingleNode("lophoc[malop= '" + malop + "']");
            if (find != null)
            {
                root.RemoveChild(find);
                doc.Save(filename);
                return true;
            }
            return false;
        }
        public bool UpdateClass(LopHoc lh)
        {
            XmlNode find = root.SelectSingleNode("lophoc[malop= '" + lh.malop + "']");
            if (find != null) 
            {
                XmlElement lophoc = doc.CreateElement("lophoc");
                XmlElement malop = doc.CreateElement("malop");
                XmlElement phonghoc = doc.CreateElement("phonghoc");
                XmlElement sinhvien = doc.CreateElement("sinhvien");
                XmlElement masv = doc.CreateElement("masv");
                XmlElement hoten = doc.CreateElement("hoten");
                XmlElement diachi = doc.CreateElement("diachi");


                malop.InnerText = lh.malop;
                phonghoc.InnerText = lh.phonghoc;
                masv.InnerText = lh.masv;
                hoten.InnerText = lh.hoten;
                diachi.InnerText = lh.diachi;

                sinhvien.SetAttribute("masv", lh.masv);
                sinhvien.AppendChild(hoten);
                sinhvien.AppendChild(diachi);

                lophoc.AppendChild(sinhvien);
                lophoc.AppendChild(malop);
                lophoc.AppendChild(phonghoc);

                root.AppendChild(lophoc);
                doc.Save(filename);
                return true;
            }
            return false;
        }
    }
}
