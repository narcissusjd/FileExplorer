using FileExplorer.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace FileExplorer.View
{
    /// <summary>
    /// DirectoryTreeView.xaml 的交互逻辑
    /// </summary>
    public partial class DirectoryTreeView : UserControl, INotifyPropertyChanged
    {
        public DirectoryInfo SelectedDirectory
        {
            get
            {
                return (this.DataContext as DirectoryTreeViewModel).SelectedDirectory;
            }
            set
            {
                (this.DataContext as DirectoryTreeViewModel).SelectedDirectory = value;
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion

        public DirectoryTreeView()
        {
            InitializeComponent();
            (this.DataContext as DirectoryTreeViewModel).PropertyChanged += DirectoryTreeView_PropertyChanged;
        }

        private void DirectoryTreeView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged("SelectedDirectory");
        }
    }
}
