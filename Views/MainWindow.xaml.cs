using System.Windows;
using CSharpPractice1.ViewModels;

namespace CSharpPractice1.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainViewModel();
        } 
    }
}
