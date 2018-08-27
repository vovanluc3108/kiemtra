using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using kiemtrathuwinform.DataAcessLayer;
using System.Windows.Forms;
using kiemtrathuwinform.Entity;

namespace kiemtrathuwinform.BussinessLogicLayer
{
    class LoaiTourBL
    {
        LoaiTourDL loaiDL;

        public LoaiTourBL()
        {
            loaiDL = new LoaiTourDL();
        }

        public DataTable GetAllLoaiTour()
        {
            DataTable dt = new DataTable();
            dt = loaiDL.GetAllLoaiTour();
            return dt;
        }

        public int Insert(LoaiTour loai)
        {
            return loaiDL.Insert(loai);
        }
    }
}
