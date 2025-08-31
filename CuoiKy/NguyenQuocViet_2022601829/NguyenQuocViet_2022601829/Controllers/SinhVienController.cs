using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NguyenQuocViet_2022601829.Models;
namespace NguyenQuocViet_2022601829.Controllers
{
    public class SinhVienController : ApiController
    {
        QLSVEntities db = new QLSVEntities();
        
        [HttpGet]
        [Route("api/getAll")]
        public IEnumerable<SinhVien> getAll()
        {
            return db.SinhViens;
        }
        
        [HttpGet]
        [Route("api/getByClass/{lop}")]
        public IEnumerable<SinhVien> getByClass(string lop)
        {
            return db.SinhViens.Where(x => x.Lop == lop);
        }

        [HttpPost]
        [Route("api/post")]
        public IHttpActionResult post(SinhVien sv)
        {
            try
            {
                if (sv.DiemTB < 0 || sv.DiemTB > 10)
                {
                    return Ok("Thêm thất bại! Điểm không hợp lệ!");
                }
                var svfind = db.SinhViens.FirstOrDefault(x => x.MaSV == sv.MaSV);
                if (svfind == null)
                {
                    db.SinhViens.Add(sv);
                    db.SaveChanges();
                    return Ok("Thêm thành công");
                }
                return Ok("Thêm không thành công! Đã tồn tại mã sinh viên này!");
            }
            catch(Exception ex)
            {
                return BadRequest("Có lỗi xảy ra: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("api/put")]
        public IHttpActionResult put(SinhVien sv)
        {
            try
            {
                if (sv.DiemTB < 0 || sv.DiemTB > 10)
                {
                    return Ok("Cập nhật thất bại! Điểm không hợp lệ!");
                }
                var svfind = db.SinhViens.FirstOrDefault(x => x.MaSV == sv.MaSV);
                if (svfind != null)
                {
                    svfind.HoTen = sv.HoTen;
                    svfind.DiemTB = sv.DiemTB;
                    svfind.Lop = sv.Lop;
                    db.SaveChanges();
                    return Ok("Cập nhật thành công!");
                }
                return Ok("Cập nhật không thành công! Không tồn tại mã sinh viên này!");
            }
            catch(Exception ex)
            {
                return BadRequest("Có lỗi xảy ra: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/delete/{id}")]
        public IHttpActionResult delete (string id)
        {
            var svfind = db.SinhViens.FirstOrDefault(x => x.MaSV == id);
            if (svfind != null) 
            {
                db.SinhViens.Remove(svfind);
                db.SaveChanges();
                return Ok("Xóa thành công!");
            }
            return Ok("Xóa thất bại! Không tồn tại sinh viên có mã này!");
        }
    }
}
