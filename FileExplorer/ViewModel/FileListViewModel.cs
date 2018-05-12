using FileExplorer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Telerik.Windows.Controls;

namespace FileExplorer.ViewModel
{
    partial class FileListViewModel : ViewModelBase
    {
        public delegate void ReportItem(FileListItem item);

        DirectoryInfo parentDirectory;
        ObservableCollection<FileListItem> items;
        View.FileListView view;

        public DirectoryInfo ParentDirectory { get => parentDirectory; set { parentDirectory = value; LoadFiles(parentDirectory); OnPropertyChanged("ParentDirectory"); } }
        public ObservableCollection<FileListItem> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }

        public FileListViewModel(View.FileListView view_)
        {
            view = view_;
            items = new ObservableCollection<FileListItem>();
        }

        private void LoadFiles(DirectoryInfo parent)
        {
            items.Clear();
            LoadFilesManager manager = new LoadFilesManager(view.Dispatcher, Report, parent);
            Thread t = new Thread(manager.LoadFiles);
            t.Start();
        }

        class LoadFilesManager
        {
            Dispatcher mainDispatcher;
            ReportItem report;
            DirectoryInfo parentDi;

            public LoadFilesManager(Dispatcher dis, ReportItem rep, DirectoryInfo di)
            {
                mainDispatcher = dis;
                report = rep;
                parentDi = di;
            }

            public void LoadFiles()
            {
                try
                {
                    var directories = parentDi.EnumerateDirectories().GetEnumerator();
                    var files = parentDi.EnumerateFiles().GetEnumerator();

                    while (directories.MoveNext())
                    {
                        DirectoryInfo current = directories.Current;
                        FileListItem item = new FileListItem();
                        item.FullPath = current.FullName;
                        item.Header = current.Name;
                        item.Info = current;
                        item.Opacity = (current.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden ? 0.5 : 1.0;
                        item.Path = current.Name;
                        mainDispatcher.BeginInvoke((ThreadStart)delegate ()
                        {
                            report(item);
                        });
                    }

                    while (files.MoveNext())
                    {
                        FileInfo current = files.Current;
                        FileListItem item = new FileListItem();
                        item.FullPath = current.FullName;
                        item.Header = current.Name;
                        item.Info = current;
                        item.Opacity = (current.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden ? 0.5 : 1.0;
                        item.Path = current.Name;
                        mainDispatcher.BeginInvoke((ThreadStart)delegate ()
                        {
                            report(item);
                        });
                    }
                }
                catch (Exception ex)
                {
                    FileListItem item = new FileListItem();
                    item.Header = ex.Message;
                    item.Opacity = 1.0;
                    mainDispatcher.BeginInvoke((ThreadStart)delegate ()
                    {
                        report(item);
                    });
                }
            }

        }

    }
}
