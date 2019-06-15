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

namespace SGP.Views.Registros
{
    public partial class frmRegistration : Form
    {
        ConnectionString cs = new ConnectionString();
        CommonClasses cc = new CommonClasses();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmRegistration()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            txtContactNo.Text = "";
            txtEmailID.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtUserID.Text = "";
            cmbUserType.SelectedIndex = -1;
            txtUserID.Focus();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void delete_records()
        {

            try
            {
                if (txtUserID.Text == "Admin")
                {
                    MessageBox.Show("A conta Admin não pode ser deletada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int RowsAffected = 0;
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                string ct = "delete from Registration where UserID=@d1";
                cc.cmd = new SqlCommand(ct);
                cc.cmd.Connection = cc.con;
                cc.cmd.Parameters.AddWithValue("@d1", txtUserID.Text);
                RowsAffected = cc.cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "deletado o usuário com id '" + txtUserID.Text + "'";
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

        public void GetData()
        {
            try
            {

                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                cc.cmd = new SqlCommand("SELECT RTRIM(UserId), RTRIM(UserTipo), RTRIM(UserSenha), RTRIM(UserName), RTRIM(UserEmail), RTRIM(UserContato),RTRIM(DataCadastro) from Registration order by DataCadastro", cc.con);
                cc.rdr = cc.cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dgw.Rows.Clear();
                while (cc.rdr.Read() == true)
                {
                    dgw.Rows.Add(cc.rdr[0], cc.rdr[1], cc.rdr[2], cc.rdr[3], cc.rdr[4], cc.rdr[5], cc.rdr[6]);
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
                if (txtUserID.Text == "")
                {
                    MessageBox.Show("Informe o id do usuário", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserID.Focus();
                    return;
                }
                if (cmbUserType.Text == "")
                {
                    MessageBox.Show("Informe o tipo do usuário", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbUserType.Focus();
                    return;
                }
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Informe a senha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }
                if (txtName.Text == "")
                {
                    MessageBox.Show("informe o nome", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }
                if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Informe o no. de contato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContactNo.Focus();
                    return;
                }
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                string ct = "select UserID from Registration where UserID=@d1";
                cc.cmd = new SqlCommand(ct);
                cc.cmd.Connection = cc.con;
                cc.cmd.Parameters.AddWithValue("@d1", txtUserID.Text);
                cc.rdr = cc.cmd.ExecuteReader();
                if (cc.rdr.Read())
                {
                    MessageBox.Show("O ID do usuário já existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserID.Text = "";
                    txtUserID.Focus();
                    if ((cc.rdr != null))
                    {
                        cc.rdr.Close();
                    }
                    return;
                }

                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                string cb = "insert into Registration(UserID, UserTipo, UserSenha, UserName, UserContato, UserEmail,DataCadastro) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                cc.cmd = new SqlCommand(cb);
                cc.cmd.Connection = cc.con;
                cc.cmd.Parameters.AddWithValue("@d1", txtUserID.Text);
                cc.cmd.Parameters.AddWithValue("@d2", cmbUserType.Text);
                cc.cmd.Parameters.AddWithValue("@d3", txtPassword.Text);
                cc.cmd.Parameters.AddWithValue("@d4", txtName.Text);
                cc.cmd.Parameters.AddWithValue("@d5", txtContactNo.Text);
                cc.cmd.Parameters.AddWithValue("@d6", txtEmailID.Text);
                cc.cmd.Parameters.AddWithValue("@d7", System.DateTime.Now);
                cc.cmd.ExecuteReader();
                cc.con.Close();
                st1 = lblUser.Text;
                st2 = "incluído um novo usuário com id '" + txtUserID.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                GetData();
                btnSave.Enabled = false;
                MessageBox.Show("Registrado com sucesso", "Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserID.Text == "")
                {
                    MessageBox.Show("Informe o id do usuário", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserID.Focus();
                    return;
                }
                if (cmbUserType.Text == "")
                {
                    MessageBox.Show("Informe o tipo do usuário", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbUserType.Focus();
                    return;
                }
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Informe a senha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }
                if (txtName.Text == "")
                {
                    MessageBox.Show("Informe o nome", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }
                if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Informe o no. de contato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContactNo.Focus();
                    return;
                }

                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                string cb = "update registration set UserID=@d1, UserTipo=@d2,UserSenha=@d3,UserName=@d4,UserContato=@d5,UserEmail=@d6 where UserID=@d7";
                cc.cmd = new SqlCommand(cb);
                cc.cmd.Connection = cc.con;
                cc.cmd.Parameters.AddWithValue("@d1", txtUserID.Text);
                cc.cmd.Parameters.AddWithValue("@d2", cmbUserType.Text);
                cc.cmd.Parameters.AddWithValue("@d3", txtPassword.Text);
                cc.cmd.Parameters.AddWithValue("@d4", txtName.Text);
                cc.cmd.Parameters.AddWithValue("@d5", txtContactNo.Text);
                cc.cmd.Parameters.AddWithValue("@d6", txtEmailID.Text);
                cc.cmd.Parameters.AddWithValue("@d7", TextBox1.Text);
                cc.cmd.ExecuteReader();
                cc.con.Close();
                st1 = lblUser.Text;
                st2 = "atualizado o usuário com id '" + txtUserID.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                GetData();
                btnUpdate.Enabled = false;
                MessageBox.Show("Atualizada com sucesso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtEmailID_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmailID.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmailID.Text))
                {
                    MessageBox.Show("Email inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmailID.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void txtUserID_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9_]");
            if (txtUserID.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtUserID.Text))
                {
                    MessageBox.Show("somente letras, números e sublinhado são permitidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserID.SelectAll();
                    e.Cancel = true;
                }
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

        private void dgw_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow dr = dgw.SelectedRows[0];
            txtUserID.Text = dr.Cells[0].Value.ToString();
            TextBox1.Text = dr.Cells[0].Value.ToString();
            cmbUserType.Text = dr.Cells[1].Value.ToString();
            txtPassword.Text = dr.Cells[2].Value.ToString();
            txtName.Text = dr.Cells[3].Value.ToString();
            txtContactNo.Text = dr.Cells[5].Value.ToString();
            txtEmailID.Text = dr.Cells[4].Value.ToString();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja deletar esse registro ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }
    }
}
