using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NguyenQuocViet_API.Models;
namespace NguyenQuocViet_API.Controllers
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
                var nvfind = db.Nhanviens.FirstOrDefault(x => x.MaNV == nv.MaNV);
                if (nvfind == null)
                {
                    db.Nhanviens.Add(nv);
                    db.SaveChanges();
                    return Ok("Thêm thành công");
                }
                return Ok("Thêm không thành công! Đã tồn tại mã nhân viên này!");
            }
            catch (Exception ex)
            {
                return BadRequest("Có lỗi xảy ra: " + ex.Message);
            }
        }

    }
}
