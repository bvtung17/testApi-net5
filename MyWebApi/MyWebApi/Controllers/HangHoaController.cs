﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }
        [HttpPost]
        public IActionResult Create(HangHoaVm hangHoaVm)
        {
            var hangHoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVm.TenHangHoa,
                DonGia = hangHoaVm.DonGia
            };
            hangHoas.Add(hangHoa);
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
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
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
        public IActionResult Edit(string id, HangHoa hangHoaEdit)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                //Update
                if (id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hangHoa.DonGia = hangHoaEdit.DonGia;
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
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                //Update
                if (id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                hangHoas.Remove(hangHoa); 
                return Ok();
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}
