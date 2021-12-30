using QL_TTTA.Model;
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
    class ThiSinhViewModel
    {
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
            if (obj is ThiSinh pt) return pt.TenTS.Contains(ListFilter, StringComparison.InvariantCultureIgnoreCase);
            return false;
        }
        public ThiSinhViewModel()
        {
            _listTS = new ObservableCollection<ThiSinh>();
            if(GetViewModels() != null) {
                foreach (var i in GetViewModels()) { _listTS.Add(i); }
                ListTS = CollectionViewSource.GetDefaultView(_listTS);
                ListTS.Filter = Filter;
            }
            
        }
        private IEnumerable<ThiSinh> GetViewModels()
        {
            //return null;
            yield return new ThiSinh(1, "Doctor");
            yield return new ThiSinh(2, "Web Developer");
            yield return new ThiSinh(3, "Web Developer");
            yield return new ThiSinh(4, "Construction Worker");
            yield return new ThiSinh(5, "Cashier");
            yield return new ThiSinh(5, "Cashier");
            yield return new ThiSinh(5, "Cashier");
            yield return new ThiSinh(5, "Cashier");
            yield return new ThiSinh(5, "Cashier");
            yield return new ThiSinh(5, "Cashier");
            yield return new ThiSinh(5, "Cashier");
            yield return new ThiSinh(3, "Web Developer");
            yield return new ThiSinh(3, "Web Developer");
            yield return new ThiSinh(3, "Web Developer");
            yield return new ThiSinh(3, "Web Developer");
            yield return new ThiSinh(5, "Cashier");
        }
    }
}
