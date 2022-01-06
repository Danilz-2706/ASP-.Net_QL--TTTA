
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace QL_TTTA.ViewModel
{
    public class ThiSinhViewModel: BaseViewModel
    {
        private readonly IThiSinhRepository thiSinhRepository;

        public string CMND { get; set; }
        public string HoTen { get; set; }
        public string NoiSinh { get; set; }
        public Gender GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; }
        public string NoiCap { get; set; }
        public DateTime NgayCap { get; set; }
        public string Email { get; set; }

        private ThiSinh _SelectedItem;
        public ThiSinh SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (SelectedItem != null)
                {
                    CMND = SelectedItem.CMND;
                    HoTen = SelectedItem.HoTen;
                    GioiTinh = SelectedItem.GioiTinh;
                    NgaySinh = SelectedItem.NgaySinh;
                    SDT = SelectedItem.SDT;
                    Email = SelectedItem.Email;
                }
            }
        }

        private ObservableCollection<ThiSinh> _listTS;
        public ICollectionView ListTS { get; set; }

        private string _listFilter = string.Empty;
        public string ListFilter
        {
            get => _listFilter;
            set
            {
                _listFilter = value;
                if (ListTS != null) { ListTS.Refresh(); }
            }
        }
        private bool Filter(object obj)
        {
            if (obj is ThiSinh pt) return pt.HoTen.Contains(ListFilter, StringComparison.InvariantCultureIgnoreCase) || pt.SDT.Contains(ListFilter, StringComparison.InvariantCultureIgnoreCase);
            return false;
        }

        public ThiSinhViewModel(IThiSinhRepository thiSinhRepository)
        {
            this.thiSinhRepository = thiSinhRepository;
            Load();
            
        }
        public void Load()
        {
            _listTS = new ObservableCollection<ThiSinh>(thiSinhRepository.GetAll());
            ListTS = CollectionViewSource.GetDefaultView(_listTS);
            ListTS.Filter = Filter;

        }
       
    }
}
