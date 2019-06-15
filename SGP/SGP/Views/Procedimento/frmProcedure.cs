using DentalManagementSystem;
using SGP.Views.Paciente;
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

namespace SGP.Views.Procedimento
{
    public partial class frmProcedure : Form
    {
        ConnectionString cs = new ConnectionString();
        CommonClasses cc = new CommonClasses();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        string exo;
        string endo;
        string peri;
        public frmProcedure()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            txtToothInvolved.Text = "";
            cmbStaffName.SelectedIndex = -1;
            txtDescription.Text = "";
            txtPatientID.Text = "";
            txtPatientName.Text = "";
            txtExodontia.Text = "";
            txtProcedureType.Text = "";
            txtDesignation.Text = "";
            txtEndodontia.Text = "";
            txtPeriodontia.Text = "";
            txtStaffID.Text = "";
            dtpDate.Text = System.DateTime.Now.ToString();
            dtpDate.Enabled = true;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            auto();
        }


        private void delete_records()
        {

            try
            {
                int RowsAffected = 0;
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                string ct = "delete from [Procedure] where Proc_ID=@d1";
                cc.cmd = new SqlCommand(ct);
                cc.cmd.Connection = cc.con;
                cc.cmd.Parameters.AddWithValue("@d1", txtID.Text);
                RowsAffected = cc.cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "deletado o procedimento com id '" + txtConsultaID.Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Deletado com sucesso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("Registro não encontrado", "Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                if (cc.con.State == ConnectionState.Open)
                {
                    cc.con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void auto()
        {
            try
            {
                int Num = 0;
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                string sql = "SELECT MAX(Proc_ID+1) FROM [Procedure]";
                cc.cmd = new SqlCommand(sql);
                cc.cmd.Connection = cc.con;
                if (Convert.IsDBNull(cc.cmd.ExecuteScalar()))
                {
                    Num = 1;
                    txtID.Text = Convert.ToString(Num);
                    txtConsultaID.Text = "C-" + Convert.ToString(Num);
                }
                else
                {
                    Num = (int)(cc.cmd.ExecuteScalar());
                    txtID.Text = Convert.ToString(Num);
                    txtConsultaID.Text = "C-" + Convert.ToString(Num);
                }
                cc.cmd.Dispose();
                cc.con.Close();
                cc.con.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FillStaffName()
        {
            try
            {
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                string ct = "select RTRIM(Nome) from Staff order by Nome";
                cc.cmd = new SqlCommand(ct);
                cc.cmd.Connection = cc.con;
                cc.rdr = cc.cmd.ExecuteReader();
                while (cc.rdr.Read())
                {
                    cmbStaffName.Items.Add(cc.rdr[0]);
                }
                cc.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPatientID.Text == "")
                {
                    MessageBox.Show("Digite a informação do paciente", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    button1.Focus();
                    return;
                }
                if (cmbStaffName.Text == "")
                {
                    MessageBox.Show("Selecione o funcionário", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStaffName.Focus();
                    return;
                }
                if (txtProcedureType.Text == "")
                {
                    MessageBox.Show("Informe o tipo de procedimento", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProcedureType.Focus();
                    return;
                }
                if (txtToothInvolved.Text == "")
                {
                    MessageBox.Show("Informe o dente envolvido", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtToothInvolved.Focus();
                    return;
                }
                if (txtExodontia.Text == "")
                {
                    exo = "nada";
                }
                if(txtEndodontia.Text == "")
                {
                    endo = "nada";
                }
                if(txtPeriodontia.Text == "")
                {
                    peri = "nada";
                }
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                string cb = "insert into [Procedure](Proc_Id,ProcID,Data,PacienteID,StaffID,ProcTipo,Descricao,Dente,Exodontia,Endodontia,Periodontia) Values (" + txtID.Text + ",'" + txtConsultaID.Text + "',@d4," + txtP_ID.Text + "," + txtStaffID.Text + ",@d1,@d2,@d3,'" + txtExodontia.Text + "','" + txtEndodontia.Text + "','" + txtPeriodontia.Text + "')";
                cc.cmd = new SqlCommand(cb);
                cc.cmd.Parameters.AddWithValue("@d1", txtProcedureType.Text);
                cc.cmd.Parameters.AddWithValue("@d2", txtDescription.Text);
                cc.cmd.Parameters.AddWithValue("@d3", txtToothInvolved.Text);
                cc.cmd.Parameters.AddWithValue("@d4", dtpDate.Value);
                cc.cmd.Connection = cc.con;
                cc.cmd.ExecuteReader();
                cc.con.Close();
                st1 = lblUser.Text;
                st2 = "incluido um novo procedimento com id '" + txtConsultaID.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                btnSave.Enabled = false;
                MessageBox.Show("Salvo com sucesso", "Procedure", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPatientID.Text == "")
                {
                    MessageBox.Show("Digite a informação do paciente", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    button1.Focus();
                    return;
                }
                if (cmbStaffName.Text == "")
                {
                    MessageBox.Show("Selecione o funcionário", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStaffName.Focus();
                    return;
                }
                if (txtProcedureType.Text == "")
                {
                    MessageBox.Show("Informe o tipo de procedimento", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProcedureType.Focus();
                    return;
                }
                if (txtToothInvolved.Text == "")
                {
                    MessageBox.Show("Informe o dente envolvido", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtToothInvolved.Focus();
                    return;
                }
                if (txtExodontia.Text == "")
                {
                    exo = "nada";
                }
                if (txtEndodontia.Text == "")
                {
                    endo = "nada";
                }
                if (txtPeriodontia.Text == "")
                {
                    peri = "nada";
                }
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                string cb = "Update [Procedure] set ProcID='" + txtConsultaID.Text + "',PacienteID=" + txtP_ID.Text + ",StaffID=" + txtStaffID.Text + ",ProcTipo=@d1,Descricao=@d2,Dente=@d3,Exodontia=" + txtExodontia.Text + ",Endodontia=" + txtEndodontia.Text  + ",Periodontia=" + txtPeriodontia.Text + " where proc_ID=" + txtID.Text + "";
                cc.cmd = new SqlCommand(cb);
                cc.cmd.Parameters.AddWithValue("@d1", txtProcedureType.Text);
                cc.cmd.Parameters.AddWithValue("@d2", txtDescription.Text);
                cc.cmd.Parameters.AddWithValue("@d3", txtToothInvolved.Text);
                cc.cmd.Connection = cc.con;
                cc.cmd.ExecuteReader();
                cc.con.Close();
                st1 = lblUser.Text;
                st2 = "Atualizado o procedimento com id '" + txtConsultaID.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                btnUpdate.Enabled = false;
                MessageBox.Show("Atualizada com sucesso", "Procedure", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja deletar esse registro ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmProcedureRecord frm = new frmProcedureRecord();
            frm.Reset();
            frm.lblOperation.Text = "Procedure";
            frm.lblUser.Text = lblUser.Text;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPatientRecord frm = new frmPatientRecord();
            frm.Reset();
            frm.lblOperation.Text = "Procedimento";
            frm.lblUser.Text = lblUser.Text;
            frm.Show();
        }

        private void cmbStaffName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                cc.cmd = cc.con.CreateCommand();
                cc.cmd.CommandText = "SELECT Tipo,S_ID FROM Staff WHERE Nome=@d1";
                cc.cmd.Parameters.AddWithValue("@d1", cmbStaffName.Text);
                cc.rdr = cc.cmd.ExecuteReader();
                if (cc.rdr.Read())
                {
                    txtDesignation.Text = cc.rdr.GetValue(0).ToString();
                    txtStaffID.Text = cc.rdr.GetValue(1).ToString();
                }
                if ((cc.rdr != null))
                {
                    cc.rdr.Close();
                }
                if (cc.con.State == ConnectionState.Open)
                {
                    cc.con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmProcedure_Load(object sender, EventArgs e)
        {
            FillStaffName();
        }

        private void txtToothInvolved_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
