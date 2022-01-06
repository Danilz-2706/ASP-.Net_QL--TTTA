using Domain.Entities;
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
    public class KhoaThiViewModel: BaseViewModel
    {
        private readonly IKhoaThiRepository khoaThiRepository;
        // Các biến ở KhoaThiView //
        #region
        public string MaKhoaThi { get; set; }
        public string TenKhoaThi { get; set; }
        public DateTime? NgayThi { get; set; }
        private KhoaThi _SelectedItem;
        public KhoaThi SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (SelectedItem != null)
                {
                    MaKhoaThi = SelectedItem.MaKhoaThi;
                    TenKhoaThi = SelectedItem.TenKhoaThi;
                    NgayThi = SelectedItem.NgayThi;
                }
            }
        }
        #endregion
        // Các biến ở KhoaThiView_Them //
        #region
        public DateTime? AddNgayThi { get; set; }
        public string AddTenKT { get; set; }
        #endregion

        // Command ở KhoaThiView //
        #region
        public ICommand Add { get; set; }
        public ICommand Edit { get; set; }
        public ICommand Delete { get; set; }
        #endregion

        // Command ở KhoaThiView_Them //
        #region
        public ICommand Save { get; set; }
        public ICommand Reset { get; set; }
        public ICommand Close_KhoaThiThem { get; set; }
        #endregion

        private ObservableCollection<KhoaThi> _list { get; set; }
        public ICollectionView ListKhoaThi { get; set; }

        //Các công đoạn để Tìm Kiếm//
        #region
        private string _listFilter = string.Empty;

        public string ListFilter
        {
            get => _listFilter;
            set
            {
                _listFilter = value;
                ListKhoaThi.Refresh();
            }
        }
        private bool Filter(object obj)
        {
            if (obj is KhoaThi pt) return pt.TenKhoaThi.Contains(ListFilter, StringComparison.InvariantCultureIgnoreCase);
            return false;
        }
        #endregion

        public KhoaThiViewModel(IKhoaThiRepository khoaThiRepository)
        {
            this.khoaThiRepository = khoaThiRepository;
            Load();

            #region Các command
            Add = new RelayCommand<object>(p => true, p => ThemPT());
            AddNew();
            Close_KhoaThiThem = new RelayCommand<object>(p => true, p => CloseThem(p));

            //Details = new RelayCommand<object>(p => true, p => ChiTietPT());
            //XoaGV();
            //XoaTS();
            //CapNhapDiem();
            //CapNhapThongTinPhong();
            //Close_PhongChiTiet = new RelayCommand<object>(p => true, p => CloseChiTiet(p));

            //PhongThemGV = new RelayCommand<object>(p => true, p => ThemGV());
            //ThemMoiGV();
            //Close_PhongThemGV = new RelayCommand<object>(p => true, p => ClosePhongThemGV(p));

            //PhongThemTS = new RelayCommand<object>(p => true, p => ThemTS(p));
            //Close_PhongThemTS = new RelayCommand<object>(p => true, p => ClosePhongThemTS(p));

            //PhongNhapDiemNhieuTS = new RelayCommand<object>(p => true, p => NhapDiem());
            //CloseDiem = new RelayCommand<object>(p => true, p => CloseNhapDiem(p));
            #endregion
        }
        //Load lại danh sách
        #region
        private void Load()
        {
            _list = new ObservableCollection<KhoaThi>(khoaThiRepository.GetAll());
            ListKhoaThi = CollectionViewSource.GetDefaultView(_list);
            ListKhoaThi.Filter = Filter;
        }
        #endregion

        //Func Thêm Phòng Thi
        #region
        private void ThemPT()
        {
            KhoaThiView_Them x = new KhoaThiView_Them();
            x.DataContext = this;
            x.ShowDialog();


        }
        private void CloseThem(object obj)
        {
            KhoaThiView_Them x = obj as KhoaThiView_Them;
            x.Close();
            AddTenKT = null;
            AddNgayThi = null;
            Load();

        }
        private void AddNew()
        {
            //Reset
            Reset = new RelayCommand<KhoaThiView_Them>(p => { return true; }, p => { AddNgayThi = null; AddTenKT = null; });

            //Save
            Save = new RelayCommand<KhoaThiView_Them>(p =>
            {
                return AddNgayThi != null && AddTenKT != null;
            }, p =>
            {
                var ktn = new KhoaThi() { TenKhoaThi = AddTenKT, NgayThi = (DateTime)AddNgayThi, MaKhoaThi =AddTenKT};
                khoaThiRepository.Add(ktn);
                CloseThem(p);
            });
        }
        #endregion    
    }
}
