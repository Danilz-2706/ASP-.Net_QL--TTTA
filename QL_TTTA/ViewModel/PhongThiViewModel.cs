using QL_TTTA.Model;
using QL_TTTA.View.AdminManagerView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace QL_TTTA.ViewModel
{
    public class PhongThiViewModel : BaseViewModel
    {
        //----------------- Biến tham chiếu - biding của từng View -----------------//
        // Các biến ở PhongThiView //
        #region
        public int MaPhong { get; set; }
        public int SoLuong { get; set; }
        public string TenPhong { get; set; }
        public DateTime? NgayThi { get; set; }
        public string TenTrinhDo { get; set; }
        public string KhoaThi { get; set; }
        public ObservableCollection<GiaoVien> SelectedPhanBoGiaoVien { get; set; }

        private PhongThi _SelectedItem;
        public PhongThi SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (SelectedItem != null)
                {
                    MaPhong = SelectedItem.MaPhong;
                    SoLuong = SelectedItem.SoLuong;
                    TenPhong = SelectedItem.TenPhong;
                    NgayThi = SelectedItem.NgayThi;
                    TenTrinhDo = SelectedItem.TenTrinhDo;
                    KhoaThi = SelectedItem.KhoaThi;

                    //SelectedPhanBoGiaoVien = new ObservableCollection<GiaoVien>(doanDuLichService.GetNVsByDoan(SelectedItem.MaDoan).ToList());
                }
            }
        }
        #endregion

        // Các biến ở PhongThiView_Them //
        #region
        public ObservableCollection<TrinhDo> ListTrinhDo { get ; set; }
        public ObservableCollection<KhoaThi> ListKhoaThi { get; set; }

        public TrinhDo AddSelectedTrinhDo;
        public KhoaThi AddSelectedKhoaThi;
        public string AddTenPhong { get; set; }
        public int AddSoLuong { get; set; }

        #endregion

        // Các biến ở PhongThiView_ChiTiet //
        #region
        public ObservableCollection<ThiSinh> SelectedPhanBoThiSinh { get; set; }
        public TrinhDo SelectedTrinhDo;
        public KhoaThi SelectedKhoaThi;
        private ThiSinh _SelectedTS;
        public ThiSinh SelectedTS
        {
            get => _SelectedTS;
            set
            {
                _SelectedTS = value;
                if(_SelectedTS != null)
                {
                    DiemNghe = _SelectedTS.DiemNghe;
                    DiemNoi = _SelectedTS.DiemNoi;
                    DiemDoc = _SelectedTS.DiemDoc;
                    DiemViet = _SelectedTS.DiemViet;
                }
            }
        }
        public GiaoVien SelectedGV;
        public float DiemDoc, DiemViet,DiemNghe, DiemNoi;

        #endregion

        // Các biến ở PhongThiView_ChiTiet_ThemGV //
        #region
        public int MaGiaoVien;
        public string TenGiaoVien;
        public string SDT;
        public ObservableCollection<GiaoVien> ListGiaovien { get; set; }
        private GiaoVien _SelectedItemGiaoVien;
        public GiaoVien SelectedItemGiaoVien
        {
            get => _SelectedItemGiaoVien;
            set
            {
                _SelectedItemGiaoVien = value;
                if (_SelectedItemGiaoVien != null)
                {
                    MaGiaoVien = _SelectedItemGiaoVien.MaGV;
                    TenGiaoVien = _SelectedItemGiaoVien.TenGiaoVien;
                    SDT = _SelectedItemGiaoVien.SDT;
                }
            }
        }

        #endregion

        // Các biến ở PhongThiView_ChiTiet_NhapDiem //
        #region
        private ThiSinh _SelectedTSDiem;
        public ThiSinh SelectedTSDiem
        {
            get => _SelectedTSDiem;
            set
            {
                _SelectedTS = value;
                if (_SelectedTS != null)
                {
                    DiemNghe = _SelectedTSDiem.DiemNghe;
                    DiemNoi = _SelectedTSDiem.DiemNoi;
                    DiemDoc = _SelectedTSDiem.DiemDoc;
                    DiemViet = _SelectedTSDiem.DiemViet;
                }
            }
        }
        #endregion

        // Các biến ở PhongThiView_ChiTiet_ThemTS //
        #region
        #endregion

        //----------------- Lệnh (Command) của từng View -----------------//
        // Command ở PhongThiView //
        #region
        public ICommand Add { get; set; }
        public ICommand Details { get; set; }
        #endregion

        // Command ở PhongThiView_Them //
        #region
        public ICommand Save { get; set; }
        public ICommand Reset { get; set; }
        public ICommand Close_PhongThem { get; set; }

        #endregion

        // Command ở PhongThiView_ChiTiet //
        #region
        public ICommand Agree { get; set; }
        public ICommand Undo { get; set; }
        public ICommand Close_PhongChiTiet { get; set; }
        public ICommand PhongThemGV { get; set; }
        public ICommand PhongXoaGV { get; set; }
        public ICommand Update_Diem { get; set; }
        public ICommand Undo_Diem { get; set; }
        public ICommand PhongThemTS { get; set; }
        public ICommand PhongXoaTS { get; set; }
        public ICommand PhongNhapDiemNhieuTS { get; set; }

        #endregion

        // Command ở PhongThiView_ChiTiet_ThemGV //
        #region
        public ICommand Close_PhongThemGV { get; set; }
        public ICommand AddGV { get; set; }
        public ICommand AddGVn { get; set; }

        #endregion

        // Command ở PhongThiView_ChiTiet_NhapDiem //
        #region
        public ICommand CloseDiem { get; set; }
        public ICommand AddDiem { get; set; }
        public ICommand RemoveDiem { get; set; }
        public ICommand ResetDiem { get; set; }
        public ICommand SaveDiem { get; set; }
        #endregion

        // Command ở PhongThiView_ChiTiet_ThemTS //
        #region
        public ICommand Close_PhongThemTS { get; set; }
        public ICommand AddTS { get; set; }
        public ICommand AddTSn { get; set; }
        #endregion


        private ObservableCollection<PhongThi> _listPhongThi;
        public ICollectionView ListPhongThi { get ; }

        //Các công đoạn để Tìm Kiếm//
        #region
        private string _listFilter = string.Empty;
        public string ListFilter
        {
            get => _listFilter;
            set
            {
                _listFilter = value;
                ListPhongThi.Refresh();
            }
        }
        private bool Filter(object obj)
        {
            if (obj is PhongThi pt) return pt.TenPhong.Contains(ListFilter, StringComparison.InvariantCultureIgnoreCase);
            return false;
        }
        #endregion
        public PhongThiViewModel()
        {

            _listPhongThi = new ObservableCollection<PhongThi>();
            foreach (var i in GetViewModels()) { _listPhongThi.Add(i); }
            ListPhongThi = CollectionViewSource.GetDefaultView(_listPhongThi);
            ListPhongThi.Filter = Filter;

            #region Các command
            Add = new RelayCommand<object>(p => true, p => ThemPT());
            AddNew();
            Close_PhongThem = new RelayCommand<object>(p => true, p => CloseThem(p));

            Details = new RelayCommand<object>(p => true, p => ChiTietPT());
            XoaGV();
            XoaTS();
            CapNhapDiem();
            CapNhapThongTinPhong();
            Close_PhongChiTiet = new RelayCommand<object>(p => true, p => CloseChiTiet(p));

            PhongThemGV = new RelayCommand<object>(p => true, p => ThemGV());
            ThemMoiGV();
            Close_PhongThemGV = new RelayCommand<object>(p => true, p => ClosePhongThemGV(p));

            PhongThemTS = new RelayCommand<object>(p => true, p => ThemTS(p));
            Close_PhongThemTS = new RelayCommand<object>(p => true, p => ClosePhongThemTS(p));

            PhongNhapDiemNhieuTS = new RelayCommand<object>(p => true, p => NhapDiem());
            CloseDiem = new RelayCommand<object>(p => true, p => CloseNhapDiem(p));
            #endregion
        }


        // Danh sách tạm //
        private IEnumerable<PhongThi> GetViewModels()
        {
            yield return new PhongThi(1, "Doctor");
            yield return new PhongThi(2, "Web Developer");
            yield return new PhongThi(3, "Web Developer");
            yield return new PhongThi(4, "Construction Worker");
            yield return new PhongThi(5, "Cashier");
            yield return new PhongThi(6, "Doctor");
            yield return new PhongThi(7, "Doctor");
            yield return new PhongThi(7, "Doctor");
            yield return new PhongThi(7, "Doctor");
            yield return new PhongThi(7, "Doctor");
            yield return new PhongThi(7, "Doctor");
            yield return new PhongThi(7, "Doctor");
            yield return new PhongThi(7, "Doctor");
            yield return new PhongThi(7, "Doctor");
            yield return new PhongThi(7, "Doctor");
            yield return new PhongThi(7, "Doctor");
            yield return new PhongThi(7, "Doctor");
            yield return new PhongThi(7, "Doctor");
            yield return new PhongThi(7, "Doctor");
            yield return new PhongThi(7, "Doctor");
            yield return new PhongThi(8, "Guitar Player");
        }

        //Func Thêm Phòng Thi
        #region
        private void ThemPT()
        {
            PhongThiView_Them x = new PhongThiView_Them();
            x.DataContext = this;
            x.ShowDialog();
        }
        private void CloseThem(object obj)
        {
            PhongThiView_Them x = obj as PhongThiView_Them;
            x.Close();
            AddSelectedTrinhDo = null;
            AddTenPhong = null;
            AddSelectedKhoaThi = null;
            AddSoLuong = 0;
            //ListPhongThi = new ObservableCollection<PhongThi>();
        }
        private void AddNew()
        {
            //Reset
            Reset = new RelayCommand<PhongThiView_Them>(p => { return true; }, p => { AddSelectedTrinhDo = null; AddTenPhong = null; AddSelectedKhoaThi = null; AddSoLuong = 0; });

            //Save
            Save = new RelayCommand<PhongThiView_Them>(p =>
            {
                return !string.IsNullOrEmpty(AddTenPhong) && AddSelectedTrinhDo != null && AddSelectedKhoaThi != null && AddSoLuong > 0;
            }, p =>
            {
                try
                {
                    //var ptn = new PhongThi() { TenPhong = AddTenPhong, KhoaThi = AddSelectedKhoaThi.TenKhoaThi, SoLuong = AddSoLuong, TenTrinhDo = AddSelectedTrinhDo.TenTrinhDo };
                    //MessageBox.Show($"Bạn đã thêm phòng thi mới: \n Tên phòng {ptn.TenPhong} - Trình độ: {ptn.TenTrinhDo} - Số lượng: {ptn.SoLuong}");

                }
                catch (Exception e)
                {
                    MessageBox.Show($"Lỗi ở thêm Phòng. \n Lỗi: + {e}");
                }

            });
        }
        #endregion

        //Func Chi Tiết Phòng Thi
        #region
        private void ChiTietPT()
        {
            PhongThiView_ChiTiet x = new PhongThiView_ChiTiet();
            x.DataContext = this;
            x.ShowDialog();
        }
        private void CloseChiTiet(object obj)
        {
            PhongThiView_ChiTiet x = obj as PhongThiView_ChiTiet;
            x.Close();
            //ListPhongThi = new ObservableCollection<PhongThi>();
        }

        //Các chức năng ở tại PhongThiView_ChiTiet
        #region
        private void XoaTS()
        {
            PhongXoaTS = new RelayCommand<object>(p => { return SelectedTS != null && SelectedTS.DiemDoc ==0 && SelectedTS.DiemNghe == 0 && SelectedTS.DiemNoi == 0 && SelectedTS.DiemViet == 0; },
                p => { });
        }

        private void XoaGV()
        {
            PhongXoaGV = new RelayCommand<object>(p => { return SelectedGV != null; }, 
                p => {});
        }

        private void CapNhapDiem()
        {
            Update_Diem = new RelayCommand<object>(p => { return SelectedTS != null && (DiemNghe != SelectedTS.DiemNghe || DiemNoi != SelectedTS.DiemNoi || DiemDoc != SelectedTS.DiemDoc || DiemViet != SelectedTS.DiemViet); },
                p => {});
            Undo_Diem = new RelayCommand<object>(p => { return SelectedTS != null && (DiemNghe != SelectedTS.DiemNghe || DiemNoi != SelectedTS.DiemNoi || DiemDoc != SelectedTS.DiemDoc || DiemViet != SelectedTS.DiemViet); },
                p => { });

        }

        private void CapNhapThongTinPhong()
        {
            Undo = new RelayCommand<object>(p => { return SelectedItem != null && (TenPhong != SelectedItem.TenPhong || SoLuong != SelectedItem.SoLuong); },
                p => { });
            Agree = new RelayCommand<object>(p => { return SelectedItem != null && (TenPhong != SelectedItem.TenPhong || SoLuong != SelectedItem.SoLuong); },
                p => { });
        }
        #endregion

        //Các chức năng ở tại PhongThiView_ChiTiet_ThemGV
        #region
        private void ThemGV()
        {
            PhongThiView_ChiTiet_ThemGV x = new PhongThiView_ChiTiet_ThemGV();
            x.DataContext = this;
            x.ShowDialog();
        }
        private void ClosePhongThemGV(object p)
        {
            PhongThiView_ChiTiet_ThemGV x = p as PhongThiView_ChiTiet_ThemGV;
            x.Close();
        }
        private void ThemMoiGV()
        {
            AddGV = new RelayCommand<object>(p => {
                if (SelectedItemGiaoVien != null)
                {
                    if (SelectedPhanBoGiaoVien.Count() > 0)
                    {
                        foreach (var i in SelectedPhanBoGiaoVien) { if (i.MaGV == SelectedItemGiaoVien.MaGV) return false; }
                        return true;
                    } return true;
                } return false;
                },
                p => { });

            AddGVn = new RelayCommand<object>(p => {
                if (SelectedItemGiaoVien != null)
                {
                    if (SelectedPhanBoGiaoVien.Count() > 0)
                    {
                        foreach (var i in SelectedPhanBoGiaoVien) { if (i.MaGV == SelectedItemGiaoVien.MaGV) return false; }
                        return true;
                    }
                    return true;
                }
                return false;
            },
                p => { });
        }
        #endregion

        //Các chức năng ở tại PhongThiView_ChiTiet_ThemTS
        #region
        private void ThemTS(object p)
        {
            throw new NotImplementedException();
        }
        private void ClosePhongThemTS(object p)
        {
            throw new NotImplementedException();
        }

        //Các chức năng ở tại PhongThiView_ChiTiet_NhapDiem
        #region

        private void CloseNhapDiem(object p)
        {
            PhongThiView_ChiTiet_NhapDiem x = p as PhongThiView_ChiTiet_NhapDiem;
            x.Close();
        }

        private void NhapDiem()
        {
            PhongThiView_ChiTiet_NhapDiem x = new PhongThiView_ChiTiet_NhapDiem();
            x.DataContext = this;
            x.ShowDialog();
        }
        #endregion

        #endregion

        #endregion
    }

}
