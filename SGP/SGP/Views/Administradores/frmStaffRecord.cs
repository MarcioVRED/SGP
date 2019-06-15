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

namespace SGP.Views.Administradores
{
    public partial class frmStaffRecord : Form
    {
        ConnectionString cs = new ConnectionString();
        CommonClasses cc = new CommonClasses();
        public frmStaffRecord()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            try
            {
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                cc.cmd = new SqlCommand("SELECT RTRIM(S_ID) as [ID],RTRIM(StaffID) as [Funci ID],RTRIM(Nome) as [Nome],RTRIM(Tipo) as [Tipo],RTRIM(Sexo) as [Gênero],Convert(Date,DOB,103) as [Nascimento],RTRIM(Endereco) as [Endereço],RTRIM(Cidade) as [Cidade],RTRIM(Contato) as [Contato],RTRIM(Email) as [Email] from Staff order by Nome", cc.con);
                cc.da = new SqlDataAdapter(cc.cmd);
                cc.ds = new DataSet();
                cc.da.Fill(cc.ds, "Staff");
                dgw.DataSource = cc.ds.Tables["Staff"].DefaultView;
                cc.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Reset()
        {
            txtStaffName.Text = "";
            GetData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                cc.cmd = new SqlCommand("SELECT RTRIM(S_ID) as [ID],RTRIM(StaffID) as [Funci ID],RTRIM(Nome) as [Nome],RTRIM(Tipo) as [Tipo],RTRIM(Sexo) as [Gênero],Convert(Date,DOB,103) as [Nascimento],RTRIM(Endereco) as [Endereço],RTRIM(Cidade) as [Cidade],RTRIM(Contato) as [Contato],RTRIM(Email) as [Email] from Staff  WHERE Nome like '" + txtStaffName.Text + "%' order by Nome", cc.con);
                cc.da = new SqlDataAdapter(cc.cmd);
                cc.ds = new DataSet();
                cc.da.Fill(cc.ds, "Staff");
                dgw.DataSource = cc.ds.Tables["Staff"].DefaultView;
                cc.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgw_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lblOperation.Text == "Funcionário Master")
                {
                    DataGridViewRow dr = dgw.SelectedRows[0];
                    this.Hide();
                    frmStaff frm = new frmStaff();
                    frm.Show();
                    frm.txtID.Text = dr.Cells[0].Value.ToString();
                    frm.txtStaffID.Text = dr.Cells[1].Value.ToString();
                    frm.txtStaffName.Text = dr.Cells[2].Value.ToString();
                    frm.cmbStaffType.Text = dr.Cells[3].Value.ToString();
                    if (dr.Cells[4].Value.ToString() == "Male")
                    {
                        frm.rbMale.Checked = true;
                    }
                    else
                    {
                        frm.rbFemale.Checked = true;
                    }

                    frm.dtpDOB.Text = dr.Cells[5].Value.ToString();
                    frm.txtAddress.Text = dr.Cells[6].Value.ToString();
                    frm.txtCity.Text = dr.Cells[7].Value.ToString();
                    frm.txtContactNo.Text = dr.Cells[8].Value.ToString();
                    frm.txtEmailID.Text = dr.Cells[9].Value.ToString();
                    frm.btnUpdate.Enabled = true;
                    frm.btnDelete.Enabled = true;
                    frm.btnSave.Enabled = false;
                    frm.lblUser.Text = lblUser.Text;
                    lblOperation.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgw_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void frmStaffRecord_Load(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
