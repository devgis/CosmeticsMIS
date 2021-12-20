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
    /// 用户评论.xaml 的交互逻辑
    /// </summary>
    public partial class 用户评论 : Window
    {
        public 用户评论()
        {
            InitializeComponent();
            myDataTable = new DataTable();
            DataContext = myDataTable;
            button1_Click(this, new RoutedEventArgs());
        }

        DataTable myDataTable;
        SqlConnection mysqlConnection;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxComment.Text.Trim()))
            {
                MessageBox.Show("请输入评语！");
                txtBoxComment.Focus();
                return;
            }
            string ucomment = txtBoxComment.Text.ToString();
            string write = $"insert into ucomments (user_id,ucomment,flag,clickcount)values({MainWindow.currentid},'{ucomment}',0,0)";
            using (mysqlConnection = new SqlConnection(MainWindow.MySqlCon))
            {
                mysqlConnection.Open();
                SqlCommand cmd = new SqlCommand(write, mysqlConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("请等待审核！");
                txtBoxComment.Text = string.Empty;
                button1_Click(sender,e);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (var mysqlConnection = new SqlConnection(MainWindow.MySqlCon))
            {
                mysqlConnection.Open();
                string readCmd = $"SELECT uc.ucomment,ul.displayname as ucname FROM ucomments uc left join ulogin ul on uc.user_id=ul.user_id where uc.user_id={MainWindow.currentid} or flag=1 order by uc.submittime desc";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection);
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
                
        }
    }
}
