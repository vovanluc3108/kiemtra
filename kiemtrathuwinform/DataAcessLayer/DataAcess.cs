using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using kiemtrathuwinform.Entity;
using System.Windows.Forms;


namespace kiemtrathuwinform.DataAcessLayer
{
    class DataAcess
    {
        SqlDataAdapter da;
        SqlConnection con;

        public DataAcess()
        {
            string strcon = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Code\C#\kiemtrathuwinform\kiemtrathuwinform\Database1.mdf;Integrated Security=True";
            con = new SqlConnection(strcon);
        }

        SqlConnection Open()
        {
            if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                con.Open();
            }

            return con;
        }

        void Close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public DataTable Select(string sql, SqlParameter[] pr)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter();
            try
            {
                cmd.Connection = this.Open();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(pr);
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
            return dt;
            
        }

        public int Insert(string sql, SqlParameter[] pr)
        {
            SqlCommand cmd = new SqlCommand();
            int i = 0;
            try
            {
                cmd.Connection = this.Open();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(pr);
                da.InsertCommand = cmd;
                i = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
            return i;
        }

        public int Delete(string sql, SqlParameter[] pr)
        {
            SqlCommand cmd = new SqlCommand();
            int i = 0;
            try
            {
                cmd.Connection = this.Open();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(pr);
                da.DeleteCommand = cmd;
                i = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
            return i;
        }

        public int Update(string sql, SqlParameter[] pr)
        {
            SqlCommand cmd = new SqlCommand();
            int i = 0;
            try
            {
                cmd.Connection = this.Open();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(pr);
                da.UpdateCommand = cmd;
                i = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
            return i;
        }
    }
}
