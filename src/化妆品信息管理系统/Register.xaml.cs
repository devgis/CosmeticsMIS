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
    /// Register.xaml 的交互逻辑
    /// </summary>
    public partial class Register : Window
    {
        SqlConnection mysqlConnection;

        public Register()
        {
            InitializeComponent();
            mysqlConnection = new SqlConnection(MainWindow.MySqlCon);
            mysqlConnection.Open();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable myDataTable = new DataTable();

                string readCmd = "SELECT * FROM ulogin where displayname = '" + txtBoxName.Text + "'";
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
                {
                    myDataTable.Clear();
                    sqlDataAdapter.Fill(myDataTable);

                    if (myDataTable.Rows.Count > 0)
                    {
                        MessageBox.Show("账号已经存在，请选择其他账号");
                    }
                    else
                    {
                        string readRegisterCmd = "SELECT * FROM ulogin ";
                        int nextuser_id = GetMax();
                        using (SqlDataAdapter sqlRegisterDataAdapter = new SqlDataAdapter(readRegisterCmd, mysqlConnection))
                        {
                            myDataTable.Clear();
                            sqlRegisterDataAdapter.Fill(myDataTable);
                            SqlCommandBuilder builder = new SqlCommandBuilder(sqlRegisterDataAdapter);
                            DataRow datarow = myDataTable.NewRow();
                            datarow["displayname"] = txtBoxName.Text;
                            datarow["upassword"] = passwordBox.Password;
                            datarow["user_id"] = nextuser_id;
                            myDataTable.Rows.Add(datarow);
                            sqlRegisterDataAdapter.Update(myDataTable);
                            MessageBox.Show($"注册成功,请使用账户: {nextuser_id} 登录！");
                            this.Close();


                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private int GetMax()
        {
            int min =1001;
            string readRegisterCmd = "SELECT max(user_id) FROM ulogin ";
            DataTable myDataTable = new DataTable();
            using (SqlDataAdapter sqlRegisterDataAdapter = new SqlDataAdapter(readRegisterCmd, mysqlConnection))
            {
                sqlRegisterDataAdapter.Fill(myDataTable);
                if (myDataTable == null || myDataTable.Rows.Count <= 0)
                {
                    return min;
                }
                else
                {
                    return Convert.ToInt32(myDataTable.Rows[0][0]) + 1;
                }
            }
        }

        private void txtBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataTable myDataTable = new DataTable();
            string readCmd = "SELECT * FROM ulogin where displayname = '" + txtBoxName.Text + "'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);

                if (myDataTable.Rows.Count > 0)
                {
                    labelNameCheck.Content = "已经存在";
                }
                else
                {
                    labelNameCheck.Content = "可以使用";
                }
            }
        }
    }
}
