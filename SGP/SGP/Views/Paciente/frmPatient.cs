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

namespace SGP.Views.Paciente
{
    public partial class frmPatient : Form
    {
        ConnectionString cs = new ConnectionString();
        CommonClasses cc = new CommonClasses();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        string gender;
        public frmPatient()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            txtEmailID.Text = "";
            txtPatientName.Text = "";
            txtMedicamento.Text = "";
            txtAlgumaDoenca.Text = "";
            txtFumante.Text = "";
            txtContactNo.Text = "";
            txtObs.Text = "";
            txtPatientID.Text = "";
            rbMale.Checked = false;
            rbFemale.Checked = false;
            dtpDOB.Text = System.DateTime.Today.ToString();
            txtID.Text = "";
            txtPatientName.Focus();
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
                string ct = "delete from Patient where P_ID=@d1";
                cc.cmd = new SqlCommand(ct);
                cc.cmd.Connection = cc.con;
                cc.cmd.Parameters.AddWithValue("@d1", txtID.Text);
                RowsAffected = cc.cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "deletado o paciente '" + txtPatientName.Text + "' com o seguinte id'" + txtPatientID.Text + "'";
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
                string sql = "SELECT MAX(P_ID+1) FROM Patient";
                cc.cmd = new SqlCommand(sql);
                cc.cmd.Connection = cc.con;
                if (Convert.IsDBNull(cc.cmd.ExecuteScalar()))
                {
                    Num = 1;
                    txtID.Text = Convert.ToString(Num);
                    txtPatientID.Text = "P-" + Convert.ToString(Num);
                }
                else
                {
                    Num = (int)(cc.cmd.ExecuteScalar());
                    txtID.Text = Convert.ToString(Num);
                    txtPatientID.Text = "P-" + Convert.ToString(Num);
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPatientName.Text == "")
                {
                    MessageBox.Show("Informe o nome do paciente", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPatientName.Focus();
                    return;
                }
                if (rbMale.Checked == false && rbFemale.Checked == false)
                {
                    MessageBox.Show("Selecione o gênero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtAlgumaDoenca.Text == "")
                {
                    MessageBox.Show("Informe se o paciente possui alguma doença", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAlgumaDoenca.Focus();
                    return;
                }
                if (txtMedicamento.Text == "")
                {
                    MessageBox.Show("Informe se o paciente utiliza algum medicamento", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMedicamento.Focus();
                    return;
                }
                if (txtFumante.Text == "")
                {
                    MessageBox.Show("Informe se o paciente é fumante ou não", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFumante.Focus();
                    return;
                }
                if (txtObs.Text == "")
                {
                    MessageBox.Show("Informe algum outra observação do cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtObs.Focus();
                    return;
                }
                if (rbMale.Checked == true)
                {
                    gender = rbMale.Text;
                }
                if (rbFemale.Checked == true)
                {
                    gender = rbFemale.Text;
                }


                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                string cb = "insert into Patient(P_ID,PacienteID,Nome,Doencas,Medicamentos,Observacoes,Email,Sexo,DOB,Fumante,Contato) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,'" + gender + "',@d10,@d8,@d9)";
                cc.cmd = new SqlCommand(cb);
                cc.cmd.Connection = cc.con;
                cc.cmd.Parameters.AddWithValue("@d1", txtID.Text);
                cc.cmd.Parameters.AddWithValue("@d2", txtPatientID.Text);
                cc.cmd.Parameters.AddWithValue("@d3", txtPatientName.Text);
                cc.cmd.Parameters.AddWithValue("@d4", txtAlgumaDoenca.Text);
                cc.cmd.Parameters.AddWithValue("@d5", txtMedicamento.Text);
                cc.cmd.Parameters.AddWithValue("@d6", txtObs.Text);
                cc.cmd.Parameters.AddWithValue("@d7", txtEmailID.Text);
                cc.cmd.Parameters.AddWithValue("@d8", txtFumante.Text);
                cc.cmd.Parameters.AddWithValue("@d9", txtContactNo.Text);
                cc.cmd.Parameters.AddWithValue("@d10", DateTime.Parse(dtpDOB.Text));
                cc.cmd.ExecuteReader();
                cc.con.Close();
                st1 = lblUser.Text;
                st2 = "novo paciente incluído '" + txtPatientName.Text + "' com seguinte id '" + txtPatientID.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                btnSave.Enabled = false;
                MessageBox.Show("Salvo com sucesso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (txtPatientName.Text == "")
                {
                    MessageBox.Show("Informe o nome do paciente", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPatientName.Focus();
                    return;
                }
                if (rbMale.Checked == false && rbFemale.Checked == false)
                {
                    MessageBox.Show("Informe o gênero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtAlgumaDoenca.Text == "")
                {
                    MessageBox.Show("Informe se o paciente possui alguma doença", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAlgumaDoenca.Focus();
                    return;
                }
                if (txtMedicamento.Text == "")
                {
                    MessageBox.Show("Informe se o paciente utiliza algum medicamento", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMedicamento.Focus();
                    return;
                }
                if (txtFumante.Text == "")
                {
                    MessageBox.Show("Informe se o paciente é fumante ou não", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFumante.Focus();
                    return;
                }
                if (txtObs.Text == "")
                {
                    MessageBox.Show("Informe algum outra observação do cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtObs.Focus();
                    return;
                }
                if (rbMale.Checked == true)
                {
                    gender = rbMale.Text;
                }
                if (rbFemale.Checked == true)
                {
                    gender = rbFemale.Text;
                }
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                string cb = "Update Patient set PacienteID=@d2,Nome=@d3,Doencas=@d4,Medicamentos=@d5,Observacoes=@d6,Email=@d7,Fumante=@d8,Sexo='" + gender + "',DOB=@d10,Contato=@d9 where P_ID=@d1";
                cc.cmd = new SqlCommand(cb);
                cc.cmd.Connection = cc.con;
                cc.cmd.Parameters.AddWithValue("@d1", txtID.Text);
                cc.cmd.Parameters.AddWithValue("@d2", txtPatientID.Text);
                cc.cmd.Parameters.AddWithValue("@d3", txtPatientName.Text);
                cc.cmd.Parameters.AddWithValue("@d4", txtAlgumaDoenca.Text);
                cc.cmd.Parameters.AddWithValue("@d5", txtMedicamento.Text);
                cc.cmd.Parameters.AddWithValue("@d6", txtObs.Text);
                cc.cmd.Parameters.AddWithValue("@d7", txtEmailID.Text);
                cc.cmd.Parameters.AddWithValue("@d8", txtFumante.Text);
                cc.cmd.Parameters.AddWithValue("@d9", txtContactNo.Text);
                cc.cmd.Parameters.AddWithValue("@d10", DateTime.Parse(dtpDOB.Text));
                cc.cmd.ExecuteReader();
                cc.con.Close();
                st1 = lblUser.Text;
                st2 = "paciente atualizado  '" + txtPatientName.Text + "' com id '" + txtPatientID.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                btnUpdate.Enabled = false;
                MessageBox.Show("Atualizada com sucesso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmailID_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmailID.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmailID.Text))
                {
                    MessageBox.Show("Email linválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmailID.SelectAll();
                    e.Cancel = true;
                }
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
            frmPatientRecord frm = new frmPatientRecord();
            frm.Reset();
            frm.lblOperation.Text = "Paciente Master";
            frm.lblUser.Text = lblUser.Text;
            frm.Show();
        }
    }
    
}
