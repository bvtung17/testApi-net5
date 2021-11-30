using MyWebApi.Data;
using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public class LoaiReponsitory : ILoaiReponsitory
    {
        private readonly MyDbContext _context;
        public LoaiReponsitory(MyDbContext context)
        {
            _context = context;
        }
        public LoaiViewModel Add(LoaiViewModel loaiViewModel)
        {
            var _loai = new Loai
            {
                TenLoai = loaiViewModel.TenLoai
            };
            _context.Add(_loai);
            _context.SaveChanges();
            return new LoaiViewModel
            {
                MaLoai = _loai.MaLoai,
                TenLoai = _loai.TenLoai
            };
        }

        public void Delete(int id)
        {
            var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
            }
        }

        public List<LoaiViewModel> GetAll()
        {
            var loais = _context.Loais.Select(l => new LoaiViewModel
            {
                MaLoai = l.MaLoai,
                TenLoai = l.TenLoai
            }).ToList();
            return loais;
        }

        public LoaiViewModel GetById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == id);
            if (loai == null)
            {
                return null;
            }
            return new LoaiViewModel
            {
                MaLoai = loai.MaLoai,
                TenLoai = loai.TenLoai
            };
        }

        public void Update(int id,LoaiViewModel loaiViewModel)
        {
            var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == id);
            loai.TenLoai = loaiViewModel.TenLoai;
            _context.SaveChanges();
        }
    }
}
