using MyWebApi.Data;
using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public class ProductReponsitory : IProductReponsitory
    {
        private readonly MyDbContext _context;
        public ProductReponsitory(MyDbContext context)
        {
            _context = context;
        }

        public List<HangHoaVm> GetAll(string search)
        {
            throw new NotImplementedException();
        }
    }
}
