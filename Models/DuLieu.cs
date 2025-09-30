using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LTWeb_Tuan05_Bai03.Models
{
    public class DuLieu
    {
        static string strcon = "Data source = DESKTOP-MM3SSGT\\SQLEXPRESS; Database=QL_DTTDD1; User ID=sa; Password=123; TrustServerCertificate=true;";
        SqlConnection con = new SqlConnection(strcon);
        public List<Loai> dsLoai = new List<Loai>();
        public List<SanPham> dsSP = new List<SanPham>();
        public DuLieu()
        {
            ThietLap_DSLoai();
            ThietLap_DSSanPham();
        }
        public void ThietLap_DSLoai()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Loai", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                var em = new Loai();
                em.MaLoai = int.Parse(dr["MaLoai"].ToString());
                em.TenLoai = dr["TenLoai"].ToString();
                dsLoai.Add(em);
            }
        }
        public void ThietLap_DSSanPham()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SanPham", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var em = new SanPham();
                em.MaSP = int.Parse(dr["MaSP"].ToString());
                em.TenSP = dr["TenSP"].ToString();
                em.DuongDan = dr["DuongDan"].ToString();
                em.Gia = double.Parse(dr["Gia"].ToString());
                em.MoTa = dr["MoTa"].ToString();
                em.MaLoai = int.Parse(dr["MaLoai"].ToString());
                dsSP.Add(em);
            }
        }
    }
}