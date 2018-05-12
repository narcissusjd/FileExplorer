using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Windows.Media;

namespace FileExplorer.Model
{
    class FileListItem:INotifyPropertyChanged
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
        ObservableCollection<ContextMenuItem> menuItems;
        double opacity;
        FileAttributes attributes;

        public string Header { get => header; set { header = value; NotifyPropertyChanged("Header"); } }
        public string Path { get => path; set { path = value; NotifyPropertyChanged("Path"); } }
        public string FullPath { get => fullPath; set { fullPath = value; NotifyPropertyChanged("FullPath"); } }
        public ImageSource IconSource { get => iconSource; set { iconSource = value; NotifyPropertyChanged("IconSource"); } }
        public FileSystemInfo Info { get => info; set { info = value; NotifyPropertyChanged("Info"); } }
        public ObservableCollection<ContextMenuItem> MenuItems { get => menuItems; set { menuItems = value;NotifyPropertyChanged("MenuItems"); } }
        public double Opacity { get => opacity; set => opacity = value; }
        public FileAttributes Attributes { get => attributes; set => attributes = value; }
    }
}
