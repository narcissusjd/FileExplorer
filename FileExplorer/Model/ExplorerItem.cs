using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace FileExplorer.Model
{
    class ExplorerItem : INotifyPropertyChanged
    {
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

        string header;
        string path;
        string fullPath;
        FileSystemInfo info;
        ImageSource iconSource;
        ObservableCollection<ExplorerItem> children;

        public string Header { get => header; set { header = value; NotifyPropertyChanged("Header"); } }
        public string Path { get => path; set { path = value; NotifyPropertyChanged("Path"); } }
        public string FullPath { get => fullPath; set { fullPath = value; NotifyPropertyChanged("FullPath"); } }
        public ImageSource IconSource { get => iconSource; set { iconSource = value; NotifyPropertyChanged("IconSource"); } }
        public ObservableCollection<ExplorerItem> Children { get => children; set { children = value; NotifyPropertyChanged("Children"); } }
        public FileSystemInfo Info { get => info; set { info = value; NotifyPropertyChanged("Info"); } }

        public ExplorerItem()
        {
            children = new ObservableCollection<ExplorerItem>();
        }
    }
}
