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

namespace 化妆品信息管理系统
{
    /// <summary>
    /// 审核用户评论.xaml 的交互逻辑
    /// </summary>
    public partial class 审核用户评论 : Window
    {

        public string getComment { get; set; }
        public 审核用户评论()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            txtBoxOutputC.Text = getComment;
        }
    }
}
