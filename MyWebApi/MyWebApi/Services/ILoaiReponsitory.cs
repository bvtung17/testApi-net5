using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public interface ILoaiReponsitory
    {
        List<LoaiViewModel> GetAll();
        LoaiViewModel GetById(int id);
        LoaiViewModel Add(LoaiViewModel loaiViewModel);
        void Update(int id, LoaiViewModel loaiViewModel);
        void Delete(int id);

    }
}
