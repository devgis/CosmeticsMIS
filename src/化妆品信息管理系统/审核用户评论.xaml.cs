using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace 化妆品信息管理系统
{
    /// <summary>
    /// 审核用户评论.xaml 的交互逻辑
    /// </summary>
    public partial class 审核用户评论 : Window
    {
        DataTable myDataTable = new DataTable();

        public string getComment { get; set; }
        public 审核用户评论()
        {
            InitializeComponent();
            DataContext = myDataTable;
            button_Click(this, new RoutedEventArgs());
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (var mysqlConnection = new SqlConnection(MainWindow.MySqlCon))
            {
                mysqlConnection.Open();

                string readCmd = $"SELECT uc.user_id,uc.ucomment,ul.displayname as ucname FROM ucomments uc left join ulogin ul on uc.user_id=ul.user_id where uc.flag=0 order by uc.submittime desc";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readCmd, mysqlConnection);
                myDataTable.Clear();
                sqlDataAdapter.Fill(myDataTable);
            }
                
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var item = listView.SelectedItem as DataRowView;
            if (item != null)
            {
                var user_id = item.Row["user_id"].ToString();
                var ucomment = item.Row["ucomment"].ToString();

                using (var mysqlConnection = new SqlConnection(MainWindow.MySqlCon))
                {
                    mysqlConnection.Open();

                    string readCmd = $"update ucomments set flag=1 where user_id={user_id}and ucomment='{ucomment}'";
                    SqlCommand cmd = new SqlCommand(readCmd, mysqlConnection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("审核成功！");
                    button_Click(sender, e);
                }
            }
        }
    }
}
