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
    /// 化妆品分类查找.xaml 的交互逻辑
    /// </summary>
    public partial class 化妆品分类查找 : Window
    {
        public 化妆品分类查找()
        {
            InitializeComponent();
            myDataTable = new DataTable();
            DataContext = myDataTable;
        }
        DataTable myDataTable;
        SqlConnection mysqlConnection;

        public static string MySqlCon = " Data Source=PC-20201024PGYI\\SQLEXPRESS;Initial Catalog=cosmeticsmanage;Integrated Security=True ";

        private void button_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE brandname='海蓝之谜'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy9_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE category='唇部护理'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE brandname='理肤泉'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy3_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE brandname='魅可'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE brandname='娇兰'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE brandname='兰蔻'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy6_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE brandname='希思黎'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy4_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE brandname='资生堂'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy5_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE brandname='雅诗兰黛'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy10_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE category='精华'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy11_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE category='口红'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy12_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE category='粉底气垫'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy13_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE category='高光修容'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy14_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE category='化妆水'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy15_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE category='香水'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy16_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE category='乳液面霜'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy7_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE category='其他'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

        private void button_Copy8_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnection = new SqlConnection(MySqlCon);
            mysqlConnection.Open();

            string readCmd = "SELECT coname,brandname,category,price FROM cosmetics WHERE brandname='其他'";
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection))
            {
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
        }

       
    }
}
