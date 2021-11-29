﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Models
{
    public class HangHoaVm
    {
        public string TenHangHoa { get; set; }
        public double DonGia { get; set; }
    }
    public class HangHoa : HangHoaVm
    {
        public Guid MaHangHoa { get; set; }
    }

}
