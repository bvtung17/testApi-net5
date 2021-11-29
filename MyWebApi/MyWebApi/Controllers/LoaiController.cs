using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Data;
using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDbContext _context;
        public LoaiController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo=>lo.MaLoai == id);
            if (loai == null)
            {
                return BadRequest();
            }
            return Ok(loai);
        }
        [HttpPost]
        public IActionResult Create (LoaiVm loaiVm)
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = loaiVm.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch 
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int maLoai, LoaiVm loaiVm)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == maLoai);
            if (loai == null)
            {
                return NotFound();
            }
            loai.TenLoai = loaiVm.TenLoai;
            _context.SaveChanges();
            return Ok();
        }
    }

}
