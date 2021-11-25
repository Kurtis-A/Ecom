﻿using Ecom.Services;
using Ecom.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Ecom.View.User
{
    /// <summary>
    /// Interaction logic for UserList.xaml
    /// </summary>
    public partial class UserList : UserControl
    {
        private readonly UserService _service;

        public UserList(UserService service)
        {
            InitializeComponent();
            _service = service;
        }

        public ObservableCollection<UserListViewModel> Users { get; set; }
    }
}
