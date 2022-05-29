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
    public partial class enroll : Form
    {
        public enroll()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //注册按钮
        private void button1_Click(object sender, EventArgs e)
        {
            bool Bool = Fac();
            if (Bool)
            {
                string type = "普通用户";
                string sex = "";
                if (radioButton1.Checked)//判断单选按钮的text
                {
                    sex = radioButton1.Text;
                }
                else if (radioButton2.Checked)
                {
                    sex = radioButton2.Text;
                }
                string sql = string.Format("insert into UserList values('{0}','{1}','{2}','{3}','{4}','{5}')", textBox1.Text, textBox2.Text, sex, textBox4.Text, textBox5.Text, type);
                bool sqlinsert = DBHelper.ExecuteNonQuery(sql);
                if (sqlinsert)
                {
                    DialogResult result = MessageBox.Show("注册成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.Hide();
                    Login LG = new Login();
                    LG.ShowDialog();
                }
            }
            else
            {
                return;
            }
        }


        /// <summary>
        /// 用于注册界面里格式的判断
        /// </summary>
        /// <returns></returns>
        private bool Fac()
        {
            string sql = string.Format("select * from UserList where UserID='{0}'", textBox1.Text);
            SqlDataReader reader = DBHelper.GetDataReader(sql);
            if (textBox1.Text == "")
            {
                MessageBox.Show("用户名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                reader.Close();
                return false;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                reader.Close();
                return false;
            }
            else if (textBox3.Text != textBox3.Text)
            {
                MessageBox.Show("两次密码必须一样！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                reader.Close();
                return false;
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("请输入手机号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                reader.Close();
                return false;
            }
            else if (reader.Read())
            {
                DialogResult result = MessageBox.Show("此用户已存在，是否前往登录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Login LG = new Login();
                    LG.ShowDialog();
                    reader.Close();
                    this.Close();
                    return false;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            else
            {
                reader.Close();
                return true;
            }
        }




        //返回登录
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login LG = new Login();
            LG.ShowDialog();
        }

        private void enroll_Load(object sender, EventArgs e)
        {

        }
    }
}
