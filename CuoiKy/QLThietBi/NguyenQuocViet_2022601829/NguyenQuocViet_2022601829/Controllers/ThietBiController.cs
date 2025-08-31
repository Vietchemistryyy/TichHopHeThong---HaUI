using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;
using NguyenQuocViet_2022601829.Models;
namespace NguyenQuocViet_2022601829.Controllers
{
    public class ThietBiController : ApiController
    {
        QLTBEntities db = new QLTBEntities();

        [HttpGet]
        [Route("api/getall")]
        public IEnumerable<ThietBi> getall()
        {
            return db.ThietBis;
        }

        [HttpPost]
        [Route("api/post")]
        public IHttpActionResult ThemThietBi(ThietBi tb)
        {
            try
            {
                if (tb.GiaBan < 0)
                {
                    return Ok("Thêm không thành công! Giá bán không hợp lệ!");
                }
                var tbfind = db.ThietBis.FirstOrDefault(x => x.MaTB == tb.MaTB);
                if (tbfind == null)
                {
                    db.ThietBis.Add(tb);
                    db.SaveChanges();
                    return Ok("Thêm thành công");
                }
                return Ok("Thêm không thành công! Đã tồn tại mã thiết bị này!");
            }
            catch (Exception ex)
            {
                return BadRequest("Có lỗi xảy ra: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("api/put")]
        public IHttpActionResult SuaThietBi(ThietBi tb)
        {
            try
            {
                if (tb.GiaBan < 0)
                {
                    return Ok("Cập nhật không thành công! Giá bán không hợp lệ!");
                }
                var tbfind = db.ThietBis.FirstOrDefault(x => x.MaTB == tb.MaTB);
                if (tbfind != null)
                {
                    tbfind.TenTB = tb.TenTB;
                    tbfind.GiaBan = tb.GiaBan;
                    tbfind.Loai = tb.Loai;
                    db.SaveChanges();
                    return Ok("Cập nhật thành công");
                }
                return Ok("Cập nhật không thành công! Không tồn tại mã thiết bị này!");
            }
            catch (Exception ex)
            {
                return BadRequest("Có lỗi xảy ra: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/delete/{id}")]
        public IHttpActionResult XoaThietBi(string id)
        {
            var tbfind = db.ThietBis.FirstOrDefault(x => x.MaTB == id);
            if (tbfind != null)
            {
                db.ThietBis.Remove(tbfind);
                db.SaveChanges();
                return Ok("Xóa thành công");
            }
            return Ok("Xóa không thành công! Không tồn tại mã thiết bị này!");
        }
    }
}
