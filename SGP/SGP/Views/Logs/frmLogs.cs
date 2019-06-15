using DentalManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGP.Views.Logs
{
    public partial class frmLogs : Form
    {
        ConnectionString cs = new ConnectionString();
        CommonClasses cc = new CommonClasses();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmLogs()
        {
            InitializeComponent();
        }


        //AUXILIARES
        public void Reset()
        {
            try
            {
                cmbUserID.SelectedIndex = -1;
                dtpDateFrom.Text = System.DateTime.Today.ToString();
                dtpDateTo.Text = System.DateTime.Now.ToString();
                GetData();
                fillCombo();
            }
            catch
            {
                throw;
            }
        }

        public void fillCombo()
        {
            try
            {
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                cc.da = new SqlDataAdapter();
                cc.da.SelectCommand = new SqlCommand("SELECT distinct RTRIM(UserID) FROM Registration", cc.con);
                cc.ds = new DataSet("ds");
                cc.da.Fill(cc.ds);
                cc.dtable = cc.ds.Tables[0];
                cmbUserID.Items.Clear();
                foreach (DataRow drow in cc.dtable.Rows)
                {
                    cmbUserID.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetData()
        {
            try
            {
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                cc.cmd = new SqlCommand("SELECT RTRIM(UserID),RTRIM(Data),RTRIM(Operacao) from Logs order by Data", cc.con);
                cc.rdr = cc.cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dgw.Rows.Clear();
                while ((cc.rdr.Read() == true))
                {
                    dgw.Rows.Add(cc.rdr[0], cc.rdr[1], cc.rdr[2]);
                }
                cc.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteRecord()
        {
            try
            {
                int RowsAffected = 0;
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                string ct = "delete from logs";
                cc.cmd = new SqlCommand(ct);
                cc.cmd.Connection = cc.con;
                RowsAffected = cc.cmd.ExecuteNonQuery();
                if (cc.con.State == ConnectionState.Open)
                {
                    cc.con.Close();
                }
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "foram deletados todos os logs até '" + System.DateTime.Now + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Deletado com sucesso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    GetData();
                }
                else
                {
                    MessageBox.Show("Registro não encontrado", "Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                cc.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //PRINCIPAIS

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteAllLogs_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja deletar todos os logs ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    DeleteRecord();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogs_Load(object sender, EventArgs e)
        {
            try
            {
                fillCombo();
                GetData();
            }
            catch
            {
                throw;
            }
        }

        private void dgw_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                string strRowNumber = (e.RowIndex + 1).ToString();
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
                if (dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
                {
                    dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
                }
                Brush b = SystemBrushes.ControlText;
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
            catch
            {
                throw;
            }
        }

        private void cmbUserID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                cc.cmd = new SqlCommand("SELECT RTRIM(UserID),RTRIM(Data),RTRIM(Operacao) from Logs where UserID='" + cmbUserID.Text + "' order by Data", cc.con);
                cc.rdr = cc.cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dgw.Rows.Clear();
                while (cc.rdr.Read() == true)
                {
                    dgw.Rows.Add(cc.rdr[0], cc.rdr[1], cc.rdr[2]);
                }
                cc.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                cc.cmd = new SqlCommand("SELECT RTRIM(UserID),RTRIM(Data),RTRIM(Operacao) from Logs where Data between @date1 and @date2 order by Data", cc.con);
                cc.cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "Data").Value = dtpDateFrom.Value.Date;
                cc.cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "Data").Value = dtpDateTo.Value;
                cc.rdr = cc.cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dgw.Rows.Clear();
                while ((cc.rdr.Read() == true))
                {
                    dgw.Rows.Add(cc.rdr[0], cc.rdr[1], cc.rdr[2]);
                }
                cc.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
