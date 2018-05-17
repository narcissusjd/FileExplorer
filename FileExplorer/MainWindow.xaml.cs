using FileExplorer.View;
using FileExplorer.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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
            if(e.PropertyName=="SelectedDirectory")
            {
                DirectoryInfo di = (sender as DirectoryTreeView).SelectedDirectory;
                CurrentDirectoryChanged(sender, di);
            }

        }


        private void CurrentDirectoryChanged(object sender,DirectoryInfo info)
        {
            if (sender is DirectoryTreeView)
            {
                (flv_FileList.DataContext as FileListViewModel).ParentDirectory = (sender as DirectoryTreeView).SelectedDirectory;
            }
            else if (sender is FileListView)
            {

            }
            else if(true)
            { }
        }
    }
}
