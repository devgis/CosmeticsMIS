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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace 化妆品信息管理系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myDataTable = new DataTable();
            DataContext = myDataTable;
        }

        DataTable myDataTable;
        SqlConnection mysqlConnection;
        public static int currentid = 0;

        public static string MySqlCon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Github\\CosmeticsMIS\\db\\cosmeticsmanage.mdf;Integrated Security=True;Connect Timeout=30"; //" Data Source=PC-20201024PGYI\\SQLEXPRESS;Initial Catalog=cosmeticsmanage;Integrated Security=True ";

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            用户评论 comment = new 用户评论();
            comment.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            化妆品分类查找 category = new 化妆品分类查找();
            category.Show(); 
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT co_id,coname,category,price FROM cosmetics ORDER BY co_id DESC";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
       
        }

        private void button2_Copy_Click(object sender, RoutedEventArgs e)
        {
            设置保质期到期提醒 reminder = new 设置保质期到期提醒();
            reminder.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this .Close();
            Login wlogin = new Login();
            wlogin.Show();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            

            string readCmd = "SELECT co_id,coname,category,price FROM cosmetics ";
            if (!string.IsNullOrEmpty(txtBoxSearch.Text))
            {
                readCmd += $" where coname like '%{txtBoxSearch.Text}%' ";
            }
            if (!string.IsNullOrEmpty(comboBox.Text))
            {
                switch (comboBox.Text)
                {
                    case "最新":
                        readCmd += $" order by submittime desc";
                        break;
                    case "最热":
                        readCmd += $" order by clickcount desc";
                        break;
                    default:
                        break;
                }
                
            }
            using (mysqlConnection = new SqlConnection(MySqlCon))
            {
                mysqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection);
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = listView.SelectedItem as DataRowView;
            if (item != null)
            {
                var id=item.Row["co_id"].ToString();

                string write = $"update cosmetics set clickcount =clickcount+1 where co_id={id}";
                using (mysqlConnection = new SqlConnection(MySqlCon))
                {
                    mysqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(write, mysqlConnection);
                    cmd.ExecuteNonQuery();
                }

            }
            //(e.Source as ListViewItem).GetValue("");
        }
    }
}
