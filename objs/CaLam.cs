using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_Final_Project.objs
{
    class CaLam
    {
        private int ma_nv;
        private string ho_ten;
        private string buoi;
        private DateTime ngay_lam_viec;

        public CaLam(int ma_nv, string ho_ten, string buoi, DateTime ngay_lam_viec)
        {
            this.Ma_nv = ma_nv;
            this.Ho_ten = ho_ten;
            this.Buoi = buoi;
            this.Ngay_lam_viec = ngay_lam_viec;
        }

        public int Ma_nv { get => ma_nv; set => ma_nv = value; }
        public string Ho_ten { get => ho_ten; set => ho_ten = value; }
        public string Buoi { get => buoi; set => buoi = value; }
        public DateTime Ngay_lam_viec { get => ngay_lam_viec; set => ngay_lam_viec = value; }
    }
}
