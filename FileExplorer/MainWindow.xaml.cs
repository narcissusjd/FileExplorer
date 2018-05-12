using FileExplorer.View;
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

namespace FileExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RadRibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DirectoryTreeView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (flv_FileList.DataContext as FileListViewModel).ParentDirectory = (sender as DirectoryTreeView).SelectDirectory;
        }
    }
}
