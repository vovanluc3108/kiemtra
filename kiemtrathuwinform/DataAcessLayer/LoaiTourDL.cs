using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using kiemtrathuwinform.Entity;

namespace kiemtrathuwinform.DataAcessLayer
{
    class LoaiTourDL
    {
        DataAcess db;

        public LoaiTourDL()
        {
            db = new DataAcess();
        }

        public DataTable GetAllLoaiTour()
        {
            string sql = "select * from LOAITOUR";
            SqlParameter[] pr = new SqlParameter[0];

            return db.Select(sql, pr);
        }

        public int Insert(LoaiTour loai)
        {
            string sql = "insert into LOAITOUR values(@maloai, @tenloai)";
            SqlParameter[] pr = {
                                    new SqlParameter("@maloai", loai.MaLoai),
                                    new SqlParameter("@tenloai", loai.TenLoai)
                                };
            return db.Insert(sql, pr);
        }
    }
}
