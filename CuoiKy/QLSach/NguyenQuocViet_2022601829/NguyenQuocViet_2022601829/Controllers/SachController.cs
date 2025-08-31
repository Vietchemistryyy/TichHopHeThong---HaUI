using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NguyenQuocViet_2022601829.Models;
namespace NguyenQuocViet_2022601829.Controllers
{
    public class SachController : ApiController
    {
        QLSachEntities1 db = new QLSachEntities1();

        [HttpGet]
        [Route("api/getall")]
        public IEnumerable<Sach> ThongTinSach()
        {
            return db.Saches;
        }

        [HttpPost]
        [Route("api/post")]
        public IHttpActionResult ThemSach(Sach s)
        {
            try
            {
                if (s.SoLuong < 0)
                {
                    return Ok("Thêm không thành công! Số trang không hợp lệ");
                }
                var sachfind = db.Saches.FirstOrDefault(x => x.MaSach == s.MaSach);
                if (sachfind == null)
                {
                    db.Saches.Add(s);
                    db.SaveChanges();
                    return Ok("Thêm thành công");
                }
                return Ok("Thêm không thành công! Đã tồn tại mã sách này!");
            }
            catch (Exception ex)
            {
                return BadRequest("Có lỗi xảy ra: " + ex.Message);
            }
        }


        [HttpPut]
        [Route("api/put")]
        public IHttpActionResult SuaSach(Sach s)
        {
            try
            {
                if (s.SoLuong < 0)
                {
                    return Ok("Cập nhật không thành công! Số lượng không hợp lệ");
                }
                var sachfind = db.Saches.FirstOrDefault(x => x.MaSach == s.MaSach);
                if (sachfind != null)
                {
                    sachfind.TenSach = s.TenSach;
                    sachfind.NhaXuatBan = s.NhaXuatBan;
                    sachfind.TheLoai = s.TheLoai;
                    sachfind.SoLuong = s.SoLuong;
                    db.SaveChanges();
                    return Ok("Cập nhật thành công");
                }
                return Ok("Cập nhật không thành công! Không tồn tại mã sách này!");
            }
            catch (Exception ex)
            {
                return BadRequest("Có lỗi xảy ra: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/delete/{id}")]
        public IHttpActionResult XoaSach(string id)
        {
            var sachfind = db.Saches.FirstOrDefault(x => x.MaSach == id);
            if (sachfind != null)
            {
                db.Saches.Remove(sachfind);
                db.SaveChanges();
                return Ok("Xóa thành công");
            }
            return Ok("Xóa không thành công! Không tồn tại mã sách này!");
        }
    }
}
