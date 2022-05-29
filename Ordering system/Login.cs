using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Ordering_system
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Username.name=textBox1.Text;
            string sql = string.Format("select * from UserList where UserID='{0}'and UserPassword='{1} '", textBox1.Text, textBox2.Text);
            SqlDataReader reader = DBHelper.GetDataReader(sql);
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (reader.Read())
            {
                Username.ID = reader["ID"].ToString();//获取ID用于个人中心修改信息
                reader.Close();
                if (Username.name == "Sweet")
                {
                    管理员界面.GL gLY = new 管理员界面.GL();
                    this.Hide();
                    gLY.ShowDialog();
                    Application.ExitThread();
                }
                Home home = new Home();
                this.Hide();
                home.ShowDialog();
                Application.ExitThread();
            }
            else
            {
                MessageBox.Show("用户名或密码输入错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reader.Close();
        }


        //注册
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            enroll EN = new enroll();
            this.Hide();
            EN.ShowDialog();
            Application.ExitThread();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPwd forget = new ForgotPwd();
            this.Hide();
            forget.ShowDialog();
            Application.ExitThread();
        }
    }
}
