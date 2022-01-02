using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVWAREHOUSE.DataTransferObject
{
    public class DanhSachHoaDonDTO
    {
        
        private string tenKH;
        private string diaChi;
        private string sDT;
        private string tenSeries;
        private int congSuat;
        private string option;
        private string maQR;

        
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string TenSeries { get => tenSeries; set => tenSeries = value; }
        public int CongSuat { get => congSuat; set => congSuat = value; }
        public string Option { get => option; set => option = value; }
        public string MaQR { get => maQR; set => maQR = value; }
        

        public DanhSachHoaDonDTO(string tenkh, string diachi, string sdt, string tenseries, int cs, string opt, string qr)
        {
            this.TenKH = tenkh;
            this.DiaChi = diachi;
            this.SDT = sdt;
            this.TenSeries = tenseries;
            this.CongSuat = cs;
            this.Option = opt;
            this.MaQR = qr;
        }
    }
}
