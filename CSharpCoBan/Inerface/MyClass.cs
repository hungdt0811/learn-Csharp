using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inerface
{
    interface IHinhHoc
    {
        public double ChuVi();
        public double DienTich();
    }
    internal class HinhChuNhat : IHinhHoc, Interface1, Interface2
    {
        public HinhChuNhat(double _chieuDai, double _chieuRong)
        {
            chieuDai = _chieuDai;
            chieuRong = _chieuRong;
        }
        public double chieuDai { get; set; }
        public double chieuRong { get; set; }

        public double ChuVi() => (chieuDai + chieuRong) * 2;

        public double DienTich() => chieuDai * chieuRong;
    }
}
