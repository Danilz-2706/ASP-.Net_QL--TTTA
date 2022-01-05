
using Domain.Entities;
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
    public class ThiSinhViewModel
    {
        private readonly IThiSinhRepository thiSinhRepository;
        private ObservableCollection<ThiSinh> _listTS;
        public ICollectionView ListTS { get; }

        private string _listFilter = string.Empty;
        public string ListFilter
        {
            get => _listFilter;
            set
            {
                _listFilter = value;
                
                if(ListTS != null) { ListTS.Refresh(); }
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
            _listTS = new ObservableCollection<ThiSinh>(thiSinhRepository.GetAll());
                ListTS = CollectionViewSource.GetDefaultView(_listTS);
                ListTS.Filter = Filter;
        }
       
    }
}
