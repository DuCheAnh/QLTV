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
using BUS_QuanLy;
using DTO_QuanLy;

namespace GUI_QuanLy
{
    /// <summary>
    /// Interaction logic for User_Control_Page.xaml
    /// </summary>
    public partial class User_Control_Page : UserControl
    {
        User_Control_BUS singleUser = new User_Control_BUS();

        public User_Control_Page()
        {
            this.DataContext = singleUser.Get_Single_UserInfo();
            InitializeComponent();
        }
    }
}
