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

        public static string MySqlCon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Temp\\db\\cosmeticsmanage.mdf;Integrated Security=True;Connect Timeout=30"; //" Data Source=PC-20201024PGYI\\SQLEXPRESS;Initial Catalog=cosmeticsmanage;Integrated Security=True ";

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
    }
}
