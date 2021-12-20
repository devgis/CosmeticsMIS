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
    /// 编辑用户信息.xaml 的交互逻辑
    /// </summary>
    public partial class 编辑用户信息 : Window
    {
        public 编辑用户信息()
        {
            InitializeComponent();
            myDataTable = new DataTable();
            DataContext = myDataTable;
        }

        DataTable myDataTable;
        SqlConnection mysqlConnection;

        public static string MySqlCon = " Data Source=PC-20201024PGYI\\SQLEXPRESS;Initial Catalog=cosmeticsmanage;Integrated Security=True ";

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mysqlConnection = new SqlConnection(MySqlCon);
                mysqlConnection.Open();
                MessageBox.Show("数据库已经连接");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {
            string readCmd = "SELECT * FROM users";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            string readCmd = "SELECT * FROM users";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(sqlDataAdapter);

                DataRow datarow = myDataTable.NewRow();
                datarow["uname"] = txtBoxUname.Text;
                datarow["number"] = txtBoxNumber.Text;
                datarow["tell"] = txtBoxTell.Text;
                datarow["usex"] = txtBoxUsex.Text;
                datarow["user_id"] = myDataTable.Rows.Count + 1;

                myDataTable.Rows.Add(datarow);
                sqlDataAdapter.Update(myDataTable);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string readCmd = "SELECT * FROM users";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(sqlDataAdapter);

                myDataTable.Rows[listView.SelectedIndex].Delete();
                sqlDataAdapter.Update(myDataTable);
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView selectRow = (DataRowView)listView.SelectedItem;
                txtBoxUser_id.Text = selectRow.Row.ItemArray[2].ToString();
                txtBoxUname.Text = selectRow.Row.ItemArray[0].ToString();
                txtBoxUsex.Text = selectRow.Row.ItemArray[1].ToString();
                txtBoxNumber.Text = selectRow.Row.ItemArray[4].ToString();
                txtBoxTell.Text = selectRow.Row.ItemArray[3].ToString();
            }
            catch
            {

            }
        }

        private void btnAlter_Click(object sender, RoutedEventArgs e)
        {
            string readCmd = "SELECT * FROM users";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(sqlDataAdapter);

                myDataTable.Rows[listView.SelectedIndex]["uname"] = txtBoxUname.Text;
                myDataTable.Rows[listView.SelectedIndex]["usex"] = txtBoxUsex.Text;
                myDataTable.Rows[listView.SelectedIndex]["number"] = txtBoxNumber.Text;
                myDataTable.Rows[listView.SelectedIndex]["tell"] = txtBoxTell.Text;

                sqlDataAdapter.Update(myDataTable);
            }
        }
    }
}
