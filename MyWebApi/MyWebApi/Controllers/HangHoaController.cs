using Microsoft.AspNetCore.Mvc;
using MyWebApi.Data;
using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly MyDbContext _context;
        public HangHoaController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var hangHoas = _context.HangHoas.ToList();
            return Ok(hangHoas);
        }
        [HttpPost]
        public IActionResult Create(HangHoaVm hangHoaVm)
        {
            var hangHoa = new Data.HangHoa()
            {
                MaHh = Guid.NewGuid(),
                TenHh = hangHoaVm.TenHangHoa,
                DonGia = hangHoaVm.DonGia
            };
            _context.HangHoas.Add(hangHoa);
            _context.SaveChanges();
            return Ok(new
            {
                Success = true,
                Data = hangHoa
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hangHoa = _context.HangHoas.SingleOrDefault(hh => hh.MaHh == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {

                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa1 hangHoaEdit)
        {
            try
            {
                var hangHoa = _context.HangHoas.SingleOrDefault(hh => hh.MaHh == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                //Update
                if (id != hangHoa.MaHh.ToString())
                {
                    return BadRequest();
                }
                hangHoa.TenHh = hangHoaEdit.TenHangHoa;
                hangHoa.DonGia = hangHoaEdit.DonGia;
                _context.SaveChanges();
                return Ok();
            }
            catch
            {

                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var hangHoa = _context.HangHoas.SingleOrDefault(hh => hh.MaHh == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                //Update
                if (id != hangHoa.MaHh.ToString())
                {
                    return BadRequest();
                }
                _context.Remove(hangHoa);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}
