using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public interface IProductReponsitory
    {
        List<HangHoaVm> GetAll(string search);
    }
}
