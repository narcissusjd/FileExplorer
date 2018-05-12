using FileExplorer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace FileExplorer.View
{
    /// <summary>
    /// FileListView.xaml 的交互逻辑
    /// </summary>
    public partial class FileListView : RadPane
    {
        FileListViewModel viewModel;
        public FileListView()
        {
            InitializeComponent();
            viewModel = new FileListViewModel(this);
            this.DataContext = viewModel;
            //rlb_FileList.ItemsSource = viewModel.Items;
            viewModel.Items.CollectionChanged += Items_CollectionChanged; ;
        }

        private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            int jjj = 0;
        }
    }
}
