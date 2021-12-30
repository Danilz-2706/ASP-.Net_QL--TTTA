using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace QL_TTTA.ViewModel
{
    class MainWindowViewModel:BaseViewModel
    {
        private CollectionViewSource MenuItemsCollection;
        public ICollectionView SourceCollection => MenuItemsCollection.View;
        public MainWindowViewModel()
        {
            //Obser.... Lam moi lai danh sach //
            ObservableCollection<MenuItems> menuItems = new ObservableCollection<MenuItems>
            {
                new MenuItems { MenuName = "Admin", MenuImage = @"Assets/Icon/DT1__UI--icon/Admin.png" },
                new MenuItems { MenuName = "Register", MenuImage = @"Assets/Icon/DT1__UI--icon/tour.png" }
            };

            MenuItemsCollection = new CollectionViewSource { Source = menuItems };
        }

        // Menu Button Command
        private ICommand _menucommand;
        public ICommand MenuCommand
        {
            get
            {
                if (_menucommand == null)
                {
                    _menucommand = new RelayCommand<object>(param => SwitchViews(param));
                }
                return _menucommand;
            }
        }


        //Command Close//
        public void CloseApp(object obj)
        {
            MainWindow x = obj as MainWindow;
            x.Close();
        }
        private ICommand closeCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                if (closeCommand == null)
                {
                    closeCommand = new RelayCommand<object>(p => CloseApp(p));
                }
                return closeCommand;
            }
        }

        //}


        // Select ViewModel
        private object _selectedViewModel;
        public object SelectedViewModel
        {
            get => _selectedViewModel;
            set { _selectedViewModel = value; }
        }

        // Switch Views
        public void SwitchViews(object parameter)
        {
            switch (parameter)
            {
                case "Admin":
                    SelectedViewModel = new AdminViewModel();
                    break;
                case "Register":
                    SelectedViewModel = new RegisterViewModel();
                    break;
                default:
                    SelectedViewModel = new AdminViewModel();
                    break;
            }
        }
    }
    public class MenuItems
    {
        public string MenuName { get; set; }
        public string MenuImage { get; set; }

    }
}
