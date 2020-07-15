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

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            if (Data_Context.currentBooksdataUI.Count > 0)
                IBook.ItemsSource = Data_Context.currentBooksdataUI;
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


/*
            ListBoxItem myListBoxItem = (ListBoxItem)(IBook.ItemContainerGenerator.ContainerFromItem(IBook.Items.CurrentItem));

            ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);

            DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;

            Label myTextBlock = (Label)myDataTemplate.FindName("Actor", myContentPresenter);

            MessageBox.Show("The text of the TextBlock of the selected list item: " + myTextBlock.Content);*/
        }

  

 /*       private childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                {
                    return (childItem)child;
                }
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }*/
    }
}
