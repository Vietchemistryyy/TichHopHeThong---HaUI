using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _2022601829_NguyenQuocViet.Models;
namespace _2022601829_NguyenQuocViet.Controllers
{
    public class NhanVienController : ApiController
    {
        QLNVEntities db = new QLNVEntities();

        [HttpGet]
        [Route("api/dsnv")]
        public IEnumerable<Nhanvien> DanhsachNV()
        {
            return db.Nhanviens;
        }

        [HttpPost]
        [Route("api/themnv")]
        public IHttpActionResult ThemNhanvien(Nhanvien nv)
        {
            try
            {
                if (nv.Luong < 0)
                {
                    return Ok("Thêm không thành công! Lương không hợp lệ!");
                }
                var nvfind = db.Nhanviens.FirstOrDefault(x => x.MaNV == nv.MaNV);
                if (nvfind == null)
                {
                    db.Nhanviens.Add(nv);
                    db.SaveChanges();
                    return Ok("Thêm thành công!");
                }
                return Ok("Thêm không thành công! Đã tồn tại mã nhân viên này!");
            }
            catch (Exception ex)
            {
                return BadRequest("Có lỗi xảy ra: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/xoanv/{id}")]
        public IHttpActionResult XoaNhanvien(string id)
        {
            var nvfind = db.Nhanviens.FirstOrDefault(x => x.MaNV == id);
            if (nvfind != null)
            {
                db.Nhanviens.Remove(nvfind);
                db.SaveChanges();
                return Ok("Xóa thành công");
            }
            return Ok("Xóa không thành công! Không tồn tại mã nhân viên này!");
        }
    }
}
