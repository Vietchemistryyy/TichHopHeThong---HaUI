using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NguyenQuocViet_2022601829.Controllers;
using NguyenQuocViet_2022601829.Models;
namespace NguyenQuocViet_2022601829.Controllers
{
    public class LopHocController : ApiController
    {
        TruongHocEntities db = new TruongHocEntities();

        [HttpGet]
        [Route("api/getall")]
        public IEnumerable<LopHoc> getAll()
        {
            return db.LopHocs;
        }

        [HttpPost]
        [Route("api/post")]
        public IHttpActionResult post(LopHoc lh)
        {
            try
            {
                if (lh.SoSinhVien < 0)
                {
                    return Ok("Thêm thất bại! Số sinh viên không hợp lệ!");
                }
                var lhfind = db.LopHocs.FirstOrDefault(x => x.MaLop == lh.MaLop);
                if (lhfind == null)
                {
                    db.LopHocs.Add(lh);
                    db.SaveChanges();
                    return Ok("Thêm thành công");
                }
                return Ok("Thêm thất bại! Đã tồn tại mã lớp này!");
            }
            catch (Exception ex)
            {
                return BadRequest("Có lỗi xảy ra: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("api/put")]
        public IHttpActionResult put(LopHoc lh)
        {
            try
            {
                if (lh.SoSinhVien < 0)
                {
                    return Ok("Cập nhật thất bại! Số sinh viên không hợp lệ!");
                }
                var lhfind = db.LopHocs.FirstOrDefault(x => x.MaLop == lh.MaLop);
                if (lhfind != null)
                {
                    lhfind.PhongHoc = lh.PhongHoc;
                    lhfind.SoSinhVien = lh.SoSinhVien;
                    lh.ChuNhiem = lh.ChuNhiem;
                    db.SaveChanges();
                    return Ok("Cập nhật thành công");
                }
                return Ok("Cập nhật thất bại! Không tồn tại mã lớp này!");
            }
            catch (Exception ex)
            {
                return BadRequest("Có lỗi xảy ra: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/delete/{id}")]
        public IHttpActionResult delete(string id)
        {
            var lhfind = db.LopHocs.FirstOrDefault(x => x.MaLop == id);
            if (lhfind != null)
            {
                db.LopHocs.Remove(lhfind);
                db.SaveChanges();
                return Ok("Xóa thành công");
            }
            return Ok("Xóa thất bại! Không tồn tại mã lớp này!");
        }
    }
}
