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
    class TourBL
    {
        TourDL tourDL;

        public TourBL()
        {
            tourDL = new TourDL();
        }

        public BindingSource GetAllTour()
        {
            BindingSource bs = new BindingSource();
            DataTable dt = tourDL.GetAllTour();
            bs.DataSource = dt;
            return bs;
        }

        public int Insert(Tour tour )
        {
            return tourDL.Insert(tour);
        }
    }
}
