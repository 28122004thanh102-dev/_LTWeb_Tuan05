using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LTWeb_Tuan05_Bai01.Models
{
    public class DuLieu
    {
        static string strcon = "Data Source=DESKTOP-MM3SSGT\\SQLEXPRESS; Database=QL_NhanSu; User ID=sa; Password = 123; TrustServerCertificate=true;";
        SqlConnection con = new SqlConnection(strcon);
        public List<Employee> dsNV = new List<Employee>();
        public List<Department> dsPhongBan = new List<Department>();
        public DuLieu()
        {
            ThietLap_DSNV();
            ThietLap_DSPhongBan();
        }
        public void ThietLap_DSNV()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblEmployee", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                var em = new Employee();
                em.MaNV = int.Parse(dr["Id"].ToString());
                em.Ten = dr["Name"].ToString();
                em.GioiTinh = dr["Gender"].ToString();
                em.Tinh = dr["City"].ToString();
                em.MaPg = (int)dr["DeptId"];
                dsNV.Add(em);
            }
        }
        public void ThietLap_DSPhongBan()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * FROM tblDepartment", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var pb = new Department();
                pb.MaPg = int.Parse(dr["DeptId"].ToString());
                pb.TenPhong = dr["Name"].ToString();
                dsPhongBan.Add(pb);
            }
        }
        public Department ChiTietPhongBan(int maPhong)
        {
            Department department = new Department();

            string sqlScript = String.Format("SELECT * FROM tblDepartment WHERE DeptId = {0}", maPhong);

            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            department.MaPg = int.Parse(dt.Rows[0]["DeptId"].ToString());
            department.TenPhong = dt.Rows[0]["Name"].ToString();

            return department;
        }
        public List<Employee> DanhSachNhanVienTheoMaPhong(int maPhong)
        {
            List<Employee> employees = new List<Employee>();
            string sqlScript = String.Format(
                "SELECT * FROM tblEmployee WHERE DeptId = {0}", maPhong
            );

            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var em = new Employee();
                em.MaNV = int.Parse(dr["Id"].ToString());
                em.Ten = dr["Name"].ToString();
                em.GioiTinh = dr["Gender"].ToString();
                em.Tinh = dr["City"].ToString();
                em.MaPg = (int)dr["DeptId"];

                employees.Add(em);
            }
            return employees;
        }

    }
}