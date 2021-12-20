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
using System.Windows.Threading;

namespace 化妆品信息管理系统
{
    /// <summary>
    /// 设置保质期到期提醒.xaml 的交互逻辑
    /// </summary>
    public partial class 设置保质期到期提醒 : Window
    {
        public 设置保质期到期提醒()
        {
            InitializeComponent();
        }

        private DispatcherTimer timer;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            button.BorderThickness = new Thickness(10, 10, 0, 0);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer1_Tick;
            timer.Start();
            MessageBox.Show("设置提醒成功！我们将在到期时提醒您！");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int dyear;
            dyear = Int32.Parse(comboBoxDYear.Text.ToString());
            int dmonth;
            dmonth = Int32.Parse(comboBoxMonth_Copy.Text.ToString());
            int dday;
            dday = Int32.Parse(comboBox_Copy.Text.ToString());
            if (DateTime.Now.Year == dyear  && DateTime.Now.Month == dmonth && DateTime.Now.Day == dday && DateTime.Now.Hour == 0 && DateTime.Now.Minute == 0)  
            {
                MessageBox.Show("化妆品"+ txtBoxConame.Text+"今日到期！");

                timer.Stop();

                button.Content = "已过期";
            }
        }
    }
}
