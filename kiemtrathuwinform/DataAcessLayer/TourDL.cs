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
    class TourDL
    {
        DataAcess db;

        public TourDL()
        {
            db = new DataAcess();
        }

        public DataTable GetAllTour()
        {
            string sql = "select * from TOUR";
            SqlParameter[] pr = new SqlParameter[0];
            return db.Select(sql, pr);
        }

        public int Insert(Tour tour)
        {
            string sql = " Insert Into TOUR Values (@matour, @tentour, @hinh, @ngaykhoihanh, @maloai)";
            SqlParameter[] pr = {
                                    new SqlParameter("@matour" , tour.MaLoai),
                                    new SqlParameter("tentour", tour.TenTour),
                                    new SqlParameter("hinh", tour.Hinh), 
                                    new SqlParameter("ngaykhoihanh", tour.NgayKhoiHanh),
                                    new SqlParameter("maloai", tour.MaLoai)
                                };
            return db.Insert(sql, pr);
        }
    }
}
