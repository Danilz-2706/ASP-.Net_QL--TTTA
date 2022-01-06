using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using QL_TTTA.View.AdminManagerView;
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
    public class GiaoVienViewModel:BaseViewModel
    {
        private readonly IGiaoVienRepository giaoVienRepository;

        public int MaGV { get; set; }
        public string HoTen { get; set; }
        public Gender GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }

        private GiaoVien _SelectedItem;
        public GiaoVien SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (SelectedItem != null)
                {
                    MaGV = SelectedItem.MaGV;
                    HoTen = SelectedItem.HoTen;
                    GioiTinh = SelectedItem.GioiTinh;
                    NgaySinh = SelectedItem.NgaySinh;
                    SDT = SelectedItem.SDT;
                    Email = SelectedItem.Email;
                }
            }
        }

        // Các biến ở KhoaThiView_Them //
        #region
        public string AddTenGV { get; set; }
        public string AddSDT { get; set; }
        #endregion

        // Command ở KhoaThiView //
        #region
        public ICommand Add { get; set; }
        #endregion

        // Command ở KhoaThiView_Them //
        #region
        public ICommand Save { get; set; }
        public ICommand Reset { get; set; }
        public ICommand Close_PhongThem { get; set; }
        #endregion

        private ObservableCollection<GiaoVien> _listGV;
        public ICollectionView ListGV { get; set; }

        private string _listFilter = string.Empty;
        public string ListFilter
        {
            get => _listFilter;
            set
            {
                _listFilter = value;
                if (ListGV != null) { ListGV.Refresh(); }
            }
        }
        private bool Filter(object obj)
        {
            if (obj is GiaoVien pt) return pt.HoTen.Contains(ListFilter, StringComparison.InvariantCultureIgnoreCase) || pt.SDT.Contains(ListFilter, StringComparison.InvariantCultureIgnoreCase);
            return false;
        }
        public GiaoVienViewModel(IGiaoVienRepository giaoVienRepository)
        {
            this.giaoVienRepository = giaoVienRepository;
            Load();
            Add = new RelayCommand<object>(p => true, p => ThemPT());
            AddNew();
            Close_PhongThem = new RelayCommand<object>(p => true, p => CloseThem(p));
        }
        private void Load()
        {
            _listGV = new ObservableCollection<GiaoVien>(giaoVienRepository.GetAll());
            ListGV = CollectionViewSource.GetDefaultView(_listGV);
            ListGV.Filter = Filter;
        }
        private void CloseThem(object p)
        {
            GiaoVienView_Them x = p as GiaoVienView_Them;
            x.Close();
            Load();
            AddTenGV = null;
            AddSDT = null;

        }

        private void ThemPT()
        {
            GiaoVienView_Them x = new GiaoVienView_Them();
            x.DataContext = this;
            x.ShowDialog();
        }

        private void AddNew()
        {
            //Reset
            Reset = new RelayCommand<GiaoVienView_Them>(p => { return true; }, p => { AddSDT = null; AddTenGV = null; });

            //Save
            Save = new RelayCommand<GiaoVienView_Them>(p =>
            {
                return AddSDT != null && AddSDT != null;
            }, p =>
            {
                var ktn = new GiaoVien() { HoTen = AddTenGV,  SDT = AddSDT };
                giaoVienRepository.Add(ktn);
                CloseThem(p);
            });
        }

    }
}
