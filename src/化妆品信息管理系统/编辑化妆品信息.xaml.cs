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
    /// 编辑化妆品信息.xaml 的交互逻辑
    /// </summary>
    public partial class 编辑化妆品信息 : Window
    {
        public 编辑化妆品信息()
        {
            InitializeComponent();
            myDataTable = new DataTable();
            DataContext = myDataTable;
        }

        DataTable myDataTable;
        SqlConnection mysqlConnection;

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mysqlConnection = new SqlConnection(MainWindow.MySqlCon);
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
            string readCmd = "SELECT * FROM cosmetics";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            string readCmd = "SELECT * FROM cosmetics";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(sqlDataAdapter);

                DataRow datarow = myDataTable.NewRow();
                datarow["coname"] = txtBoxConame.Text;
                datarow["versionnumber"] = txtBoxVersionnumber.Text;
                datarow["brandname"] = txtBoxBrandname.Text;
                datarow["periodafteropening"] = txtBoxPeriodafteropening.Text;
                datarow["price"] = txtBoxPrice.Text;
                datarow["category"] = txtBoxCategory.Text;
                datarow["netcontent"] = txtBoxNetcontent.Text;
                datarow["co_id"] = myDataTable.Rows.Count + 1;

                myDataTable.Rows.Add(datarow);
                sqlDataAdapter.Update(myDataTable);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string readCmd = "SELECT * FROM cosmetics";
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
                txtBoxConame.Text = selectRow.Row.ItemArray[0].ToString();
                txtBoxPrice.Text = selectRow.Row.ItemArray[2].ToString();
                txtBoxVersionnumber.Text = selectRow.Row.ItemArray[3].ToString();
                txtBoxBrandname.Text = selectRow.Row.ItemArray[4].ToString();
                txtBoxPeriodafteropening.Text = selectRow.Row.ItemArray[5].ToString();
                txtBoxCategory.Text = selectRow.Row.ItemArray[6].ToString();
                txtBoxNetcontent.Text = selectRow.Row.ItemArray[7].ToString();
            }
            catch
            {

            }
        }

        private void btnAlter_Click(object sender, RoutedEventArgs e)
        {
            string readCmd = "SELECT * FROM cosmetics";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(sqlDataAdapter);

                myDataTable.Rows[listView.SelectedIndex]["coname"] = txtBoxConame.Text;
                myDataTable.Rows[listView.SelectedIndex]["price"] = txtBoxPrice.Text;
                myDataTable.Rows[listView.SelectedIndex]["versionnumber"] = txtBoxVersionnumber.Text;
                myDataTable.Rows[listView.SelectedIndex]["brandname"] = txtBoxBrandname.Text;
                myDataTable.Rows[listView.SelectedIndex]["periodafteropening"] = txtBoxPeriodafteropening.Text;
                myDataTable.Rows[listView.SelectedIndex]["category"] = txtBoxCategory.Text;
                myDataTable.Rows[listView.SelectedIndex]["netcontent"] = txtBoxNetcontent.Text;

                sqlDataAdapter.Update(myDataTable);
            }
        }
    }
}
