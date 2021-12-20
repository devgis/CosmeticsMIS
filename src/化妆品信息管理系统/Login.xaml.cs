using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace 化妆品信息管理系统
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection mysqlConnection;

        public Login()
        {
            InitializeComponent();
        }



        //用户点击注册按钮，跳转注册界面
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register mRegisterWindow = new Register();
            mRegisterWindow.ShowDialog();
        }


        //用户登录系统
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            DataTable myDataTable = new DataTable();

            mysqlConnection = new SqlConnection(MainWindow.MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT * FROM ulogin where user_id = '" + txtBoxName.Text + "'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);

                if (myDataTable.Rows.Count > 0)
                {
                    if (myDataTable.Rows[0]["upassword"].ToString().Trim() == pwdBox.Password.ToString())
                    {
                        MessageBox.Show("登录成功");
                        MainWindow mMainWindow = new MainWindow();
                        MainWindow.currentid = Convert.ToInt32(txtBoxName.Text);
                        this.Visibility = Visibility.Collapsed;
                        mMainWindow.ShowDialog();
                    }
                    else
                        MessageBox.Show("密码错误");
                }
                else
                    MessageBox.Show("账号不存在");
            }
        }


        //管理员登录
        private void btnwLogin_Click(object sender, RoutedEventArgs e)
        {
            DataTable myDataTable = new DataTable();

            mysqlConnection = new SqlConnection(MainWindow.MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT * FROM wlogin where workerid = '" + txtBoxName.Text + "'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);

                if (myDataTable.Rows.Count > 0)
                {
                    if (myDataTable.Rows[0]["wpassword"].ToString().Trim() == pwdBox.Password.ToString())
                    {
                        MessageBox.Show("登录成功");
                        MainWindowworker mMainWindow = new MainWindowworker();
                        this.Visibility = Visibility.Collapsed;
                        mMainWindow.ShowDialog();
                    }
                    else
                        MessageBox.Show("密码错误");
                }
                else
                    MessageBox.Show("账号不存在");
            }
        }

    }
}
