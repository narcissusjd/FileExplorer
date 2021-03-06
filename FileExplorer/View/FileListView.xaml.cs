﻿using FileExplorer.ViewModel;
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
        public static DependencyProperty PressedImageProperty;//依赖属性
        public FileListView()
        {
            InitializeComponent();
            viewModel = new FileListViewModel(this);
            this.DataContext = viewModel;

        }
    }
}
