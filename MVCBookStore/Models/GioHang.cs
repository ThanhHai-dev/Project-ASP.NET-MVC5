using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCBookStore.Models
{
    public class GioHang
    {
        public SACH SACH { get; set; }
        public int Soluong { get; set; }
        public GioHang (SACH sach, int soluong)
        {
            SACH = sach;
            Soluong = soluong;
        }
    }
}