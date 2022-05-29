using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordering_system
{
    public partial class ForgotPwd : Form
    {
        public ForgotPwd()
        {
            InitializeComponent();
        }


        //返回登录
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login LG = new Login();
            LG.ShowDialog();
        }


        //确定按钮
        private void button1_Click(object sender, EventArgs e)
        {

            if (!(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == ""))
            {
                if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("两次密码不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {  
                        string sql = "select * from UserList where UserID='" + textBox1.Text + "'and UserTel='" + textBox4.Text + "'";
                        DataSet ds = DBHelper.GetDataSet(sql);
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("请输入注册时的用户名和手机号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    
                 
                    else
                    {
                        try
                        {
                            string Sql = string.Format("update UserList set UserPassword = '{0}' where UserID = '{1}'", textBox2.Text, textBox1.Text);
                            if (DBHelper.ExecuteNonQuery(Sql))
                            {
                                MessageBox.Show("密码修改成功，前往登录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.Hide();
                                Login LG = new Login();
                                LG.ShowDialog();

                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("异常处理");

                        }

                    }
                }

            }
            else
            {
                MessageBox.Show("必填项不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
    }
}
