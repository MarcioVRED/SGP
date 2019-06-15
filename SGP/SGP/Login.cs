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

namespace SGP
{
    public partial class frmLogin : Form
    {
        //Criação do Util
        ConnectionString cs = new ConnectionString();
        frmMainMenu frm = new frmMainMenu();
        CommonClasses cc = new CommonClasses();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            //Válida os campos
            if (txtUser.Text == "")
            {
                MessageBox.Show("Informe o ID do usuário", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Focus();
                return;
            }
            if (txtSenha.Text == "")
            {
                MessageBox.Show("Informe a senha", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Focus();
                return;
            }
            try
            {
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                cc.cmd = cc.con.CreateCommand();
                cc.cmd.CommandText = "SELECT RTRIM(UserID),RTRIM(UserSenha) FROM Registration WHERE UserID = @d1 and UserSenha=@d2";
                cc.cmd.Parameters.AddWithValue("@d1", txtUser.Text);
                cc.cmd.Parameters.AddWithValue("@d2", txtSenha.Text);
                cc.rdr = cc.cmd.ExecuteReader();
                if (cc.rdr.Read())
                {
                    cc.con = new SqlConnection(cs.DBConn);
                    cc.con.Open();
                    cc.cmd = cc.con.CreateCommand();
                    cc.cmd.CommandText = "SELECT UserTipo, UserID FROM Registration WHERE UserID=@d3 and UserSenha=@d4";
                    cc.cmd.Parameters.AddWithValue("@d3", txtUser.Text);
                    cc.cmd.Parameters.AddWithValue("@d4", txtSenha.Text);
                    cc.rdr = cc.cmd.ExecuteReader();
                    if (cc.rdr.Read())
                    {
                        UserType.Text = cc.rdr.GetValue(0).ToString().Trim();
                        UserID.Text = cc.rdr.GetValue(1).ToString().Trim();
                    }
                    if ((cc.rdr != null))
                    {
                        cc.rdr.Close();
                    }
                    if (cc.con.State == ConnectionState.Open)
                    {
                        cc.con.Close();
                    }
                    if ((UserType.Text == "ADM"))
                    {
                        frm.usersToolStripMenuItem.Enabled = true;
                        frm.databaseToolStripMenuItem.Enabled = true;
                        frm.staffToolStripMenuItem.Enabled = true;
                        frm.patientToolStripMenuItem.Enabled = true;
                        frm.procedureToolStripMenuItem.Enabled = true;
                        frm.lblUser.Text = txtUser.Text;
                        frm.lblUserType.Text = UserType.Text;
                        ProgressBar1.Visible = true;
                        ProgressBar1.Maximum = 5000;
                        ProgressBar1.Minimum = 0;
                        ProgressBar1.Value = 4;
                        ProgressBar1.Step = 1;
                        for (int i = 0; i <= 5000; i++)
                        {
                            ProgressBar1.PerformStep();
                        }
                        st1 = UserID.Text;
                        st2 = "Logado com sucesso";
                        cf.LogFunc(st1, System.DateTime.Now, st2);
                        this.Hide();
                        frm.Show();

                    }
                    if ((UserType.Text == "GERENTE"))
                    {
                        frm.usersToolStripMenuItem.Enabled = false;
                        frm.databaseToolStripMenuItem.Enabled = false;
                        frm.staffToolStripMenuItem.Enabled = true;
                        frm.patientToolStripMenuItem.Enabled = true;
                        frm.procedureToolStripMenuItem.Enabled = false;
                        frm.lblUser.Text = txtUser.Text;
                        frm.lblUserType.Text = UserType.Text;
                        ProgressBar1.Visible = true;
                        ProgressBar1.Maximum = 5000;
                        ProgressBar1.Minimum = 0;
                        ProgressBar1.Value = 4;
                        ProgressBar1.Step = 1;
                        for (int i = 0; i <= 5000; i++)
                        {
                            ProgressBar1.PerformStep();
                        }
                        st1 = UserID.Text;
                        st2 = "Logado com sucesso";
                        cf.LogFunc(st1, System.DateTime.Now, st2);
                        this.Hide();
                        frm.Show();

                    }
                    if ((UserType.Text == "MEDICO"))
                    {
                        frm.usersToolStripMenuItem.Enabled = false;
                        frm.databaseToolStripMenuItem.Enabled = false;
                        frm.staffToolStripMenuItem.Enabled = false;
                        frm.patientToolStripMenuItem.Enabled = true;
                        frm.procedureToolStripMenuItem.Enabled = true;
                        frm.lblUser.Text = txtUser.Text;
                        frm.lblUserType.Text = UserType.Text;
                        ProgressBar1.Visible = true;
                        ProgressBar1.Maximum = 5000;
                        ProgressBar1.Minimum = 0;
                        ProgressBar1.Value = 4;
                        ProgressBar1.Step = 1;
                        for (int i = 0; i <= 5000; i++)
                        {
                            ProgressBar1.PerformStep();
                        }
                        st1 = UserID.Text;
                        st2 = "Logado com sucesso";
                        cf.LogFunc(st1, System.DateTime.Now, st2);
                        this.Hide();
                        frm.Show();

                    }
                    if ((UserType.Text == "FUNCIONARIO"))
                    {
                        frm.usersToolStripMenuItem.Enabled = false;
                        frm.databaseToolStripMenuItem.Enabled = false;
                        frm.staffToolStripMenuItem.Enabled = false;
                        frm.patientToolStripMenuItem.Enabled = true;
                        frm.procedureToolStripMenuItem.Enabled = false;
                        frm.lblUser.Text = txtUser.Text;
                        frm.lblUserType.Text = UserType.Text;
                        ProgressBar1.Visible = true;
                        ProgressBar1.Maximum = 5000;
                        ProgressBar1.Minimum = 0;
                        ProgressBar1.Value = 4;
                        ProgressBar1.Step = 1;
                        for (int i = 0; i <= 5000; i++)
                        {
                            ProgressBar1.PerformStep();
                        }
                        st1 = UserID.Text;
                        st2 = "Logado com sucesso";
                        cf.LogFunc(st1, System.DateTime.Now, st2);
                        this.Hide();
                        frm.Show();

                    }
                }
                else
                {
                    MessageBox.Show("Login falhou... tente novamente !", "Login Falhou", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.Text = "";
                    txtSenha.Text = "";
                    txtUser.Focus();
                }
                cc.cmd.Dispose();
                cc.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
