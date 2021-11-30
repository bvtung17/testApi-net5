using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using MyWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestLoaiController : ControllerBase
    {
        private readonly ILoaiReponsitory _loaiReponsitory;
        public TestLoaiController(ILoaiReponsitory loaiReponsitory)
        {
            _loaiReponsitory = loaiReponsitory;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_loaiReponsitory.GetAll());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _loaiReponsitory.GetById(id);
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, LoaiViewModel loaiViewModel)
        {
            if (id != loaiViewModel.MaLoai)
            {
                return BadRequest();
            }
            try
            {
                _loaiReponsitory.Update(id, loaiViewModel);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _loaiReponsitory.Delete(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(LoaiViewModel loaiViewModel)
        {
            try
            {
                _loaiReponsitory.Add(loaiViewModel);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
