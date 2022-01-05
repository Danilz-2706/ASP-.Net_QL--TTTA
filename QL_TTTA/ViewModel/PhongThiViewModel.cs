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
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace QL_TTTA.ViewModel
{
    public class PhongThiViewModel : BaseViewModel
    {
        private readonly IPhongThiRepository phongThiRepository;
        private readonly ICanhThiRepository canhThiRepository;
        private readonly IKhoaThiRepository khoaThiRepository;
        private readonly IThamGiaDuThiRepository thamGiaDuThiRepository;
        private readonly ITrinhDoRepository trinhDoRepository;
        private readonly IThiSinhRepository thiSinhRepository;
        private readonly ISoBaoDanhRepository soBaoDanhRepository;
        private readonly IGiaoVienRepository giaoVienRepository;

        //----------------- Biến tham chiếu - biding của từng View -----------------//
        // Các biến ở PhongThiView //
        #region
        public string MaPhong { get; set; }
        public int? SoLuong { get; set; }
        public string TenPhong { get; set; }
        public DateTime? NgayThi { get; set; }
        public string TenTrinhDo { get; set; }
        public string KhoaThi { get; set; }
        public ICollection<GiaoVien> SelectedPhanBoGiaoVien { get; set; }

        private PhongThi _SelectedItem;
        public PhongThi SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (SelectedItem != null)
                {
                    MaPhong = SelectedItem.MaPhongThi;
                    //if(SelectedItem.ThamGiaDuThis.Count() >= 0) { SoLuong = SelectedItem.ThamGiaDuThis.Count(); }
                    
                    TenPhong = SelectedItem.TenPhong;
                    NgayThi = SelectedItem.ThoiGianBatDau;
                    TenTrinhDo = SelectedItem.MaTrinhDo;
                    KhoaThi = SelectedItem.MaKhoaThi;

                    SelectedPhanBoThiSinh = SelectedItem.ThamGiaDuThis;
                }
            }
        }
        #endregion

        // Các biến ở PhongThiView_Them //
        #region
        public ObservableCollection<TrinhDo> ListTrinhDo { get ; set; }
        public ObservableCollection<KhoaThi> ListKhoaThi { get; set; }

        public TrinhDo AddSelectedTrinhDo { get; set; }
        public KhoaThi AddSelectedKhoaThi { get; set; }
        public DateTime? AddGioBatDau { get; set; }
        public DateTime? AddGioKetThuc { get; set; }
        public string AddTenPhong { get; set; }
        public int AddSoLuong { get; set; }

        #endregion

        // Các biến ở PhongThiView_ChiTiet //
        #region
        public ICollection<ThamGiaDuThi> SelectedPhanBoThiSinh { get; set; }
        public TrinhDo SelectedTrinhDo { get; set; }
        public KhoaThi SelectedKhoaThi { get; set; }
        private ThamGiaDuThi _SelectedTS;
        public ThamGiaDuThi SelectedTS
        {
            get => _SelectedTS;
            set
            {
                _SelectedTS = value;
                if(_SelectedTS != null)
                {
                    DiemNghe = _SelectedTS.Nghe;
                    DiemNoi = _SelectedTS.Noi;
                    DiemDoc = _SelectedTS.Doc;
                    DiemViet = _SelectedTS.Viet;
                }
            }
        }
        public GiaoVien SelectedGV { get; set; }
        public int? DiemNghe { get; set; }
        public int? DiemNoi { get; set; }
        public int? DiemDoc { get; set; }
        public int? DiemViet { get; set; }

        #endregion

        // Các biến ở PhongThiView_ChiTiet_ThemGV //
        #region
        public int MaGiaoVien { get; set; }
        public string TenGiaoVien { get; set; }
        public string SDT { get; set; }
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
                    TenGiaoVien = _SelectedItemGiaoVien.HoTen;
                    SDT = _SelectedItemGiaoVien.SDT;
                }
            }
        }

        #endregion

        // Các biến ở PhongThiView_ChiTiet_NhapDiem //
        #region
        private ThamGiaDuThi _SelectedTSDiem;
        public ThamGiaDuThi SelectedTSDiem
        {
            get => _SelectedTSDiem;
            set
            {
                _SelectedTS = value;
                if (_SelectedTS != null)
                {
                    DiemNghe = _SelectedTSDiem.Nghe;
                    DiemNoi = _SelectedTSDiem.Noi;
                    DiemDoc = _SelectedTSDiem.Doc;
                    DiemViet = _SelectedTSDiem.Viet;
                }
            }
        }
        #endregion

        // Các biến ở PhongThiView_ChiTiet_ThemTS //
        #region
        public string CMNDTS { get; set; }
        public string HoTenTS { get; set; }
        public string SDTTS { get; set; }

        public ObservableCollection<ThiSinh> ListTS { get; set; }
        private ThiSinh _SelectedItemTS;
        public ThiSinh SelectedItemTS
        {
            get => _SelectedItemTS;
            set
            {
                _SelectedItemTS = value;
                if (_SelectedItemTS != null)
                {
                    CMNDTS = _SelectedItemTS.CMND;
                    HoTenTS = _SelectedItemTS.HoTen;
                    SDTTS = _SelectedItemTS.SDT;
                }
            }
        }

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


        private ObservableCollection<PhongThi> _listPhongThi { get; set; }
        public ICollectionView ListPhongThi { get; set; }

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
        public PhongThiViewModel(IPhongThiRepository phongThiRepository, ITrinhDoRepository trinhDoRepository, IKhoaThiRepository khoaThiRepository, 
            IGiaoVienRepository giaoVienRepository, ICanhThiRepository canhThiRepository, IThamGiaDuThiRepository thamGiaDuThiRepository, IThiSinhRepository thiSinhRepository, ISoBaoDanhRepository soBaoDanhRepository)
        {
            this.phongThiRepository = phongThiRepository;
            this.canhThiRepository = canhThiRepository;
            this.khoaThiRepository = khoaThiRepository;
            this.thamGiaDuThiRepository = thamGiaDuThiRepository;
            this.thiSinhRepository = thiSinhRepository;
            this.trinhDoRepository = trinhDoRepository;
            this.soBaoDanhRepository = soBaoDanhRepository;

            Load();
            #region Các command
            Add = new RelayCommand<object>(p => true, p => ThemPT());
            AddNew();
            Close_PhongThem = new RelayCommand<object>(p => true, p => CloseThem(p));

            Details = new RelayCommand<object>(p => { return SelectedItem != null; }, p => ChiTietPT());
            XoaGV();
            XoaTS();
            CapNhapDiem();
            CapNhapThongTinPhong();
            Close_PhongChiTiet = new RelayCommand<object>(p => true, p => CloseChiTiet(p));

            PhongThemGV = new RelayCommand<object>(p => true, p => ThemGV());
            ThemMoiGV();
            Close_PhongThemGV = new RelayCommand<object>(p => true, p => ClosePhongThemGV(p));

            PhongThemTS = new RelayCommand<object>(p => true, p => ThemTS(p));
            ThemTSVaoPhong();
            Close_PhongThemTS = new RelayCommand<object>(p => true, p => ClosePhongThemTS(p));

            PhongNhapDiemNhieuTS = new RelayCommand<object>(p => true, p => NhapDiem());
            CloseDiem = new RelayCommand<object>(p => true, p => CloseNhapDiem(p));
            #endregion
        }
        //Load lại danh sách
        #region
        private void Load()
        {
            _listPhongThi = new ObservableCollection<PhongThi>(phongThiRepository.GetAll());
            ListPhongThi = CollectionViewSource.GetDefaultView(_listPhongThi);
            ListPhongThi.Filter = Filter;
        }
        #endregion
        //Func Thêm Phòng Thi
        #region
        private void ThemPT()
        {
            PhongThiView_Them x = new PhongThiView_Them();
            x.DataContext = this;
            
            ListTrinhDo = new ObservableCollection<TrinhDo>(trinhDoRepository.GetAll());
            ListKhoaThi = new ObservableCollection<KhoaThi>(khoaThiRepository.GetAll());
            x.ShowDialog();


        }
        private void CloseThem(object obj)
        {
            PhongThiView_Them x = obj as PhongThiView_Them;
            x.Close();
            AddSelectedTrinhDo = null;
            AddTenPhong = null;
            AddGioKetThuc = null;
            AddGioBatDau = null;
            AddSelectedKhoaThi = null;
            AddSoLuong = 0;
            Load();

        }
        private void AddNew()
        {
            //Reset
            Reset = new RelayCommand<PhongThiView_Them>(p => { return true; }, p => { AddSelectedTrinhDo = null;  AddSelectedKhoaThi = null; AddSoLuong = 0; AddGioBatDau = null; AddGioKetThuc = null; });

            //Save
            Save = new RelayCommand<PhongThiView_Them>(p =>
            {
                return  AddSelectedTrinhDo != null && AddSelectedKhoaThi != null && AddSoLuong > 0 && AddGioBatDau < AddGioKetThuc ;
            }, p =>
            {
                AddTenPhong = AddSelectedTrinhDo.TenTrinhDo + "P" + _listPhongThi.Count().ToString();
                var ptn = new PhongThi() {MaPhongThi = AddTenPhong, TenPhong = AddTenPhong, MaKhoaThi = AddSelectedKhoaThi.MaKhoaThi, MaTrinhDo = AddSelectedTrinhDo.TenTrinhDo, ThoiGianBatDau = (DateTime)AddGioBatDau, ThoiGianKetThuc = (DateTime)AddGioKetThuc };
                phongThiRepository.Add(ptn);
                CloseThem(p);
                //try
                //{
                //    var ptn = new PhongThi() { TenPhong = AddTenPhong, MaKhoaThi = AddSelectedKhoaThi.MaKhoaThi,  MaTrinhDo = AddSelectedTrinhDo.TenTrinhDo, ThoiGianBatDau = (DateTime)AddGioBatDau, ThoiGianKetThuc = (DateTime)AddGioKetThuc };
                //    phongThiRepository.Add(ptn);
                //    //MessageBox.Show($"Bạn đã thêm phòng thi mới: \n Tên phòng {ptn.TenPhong} - Trình độ: {ptn.TenTrinhDo} - Số lượng: {ptn.SoLuong}");

                //}
                //catch (Exception e)
                //{
                //    MessageBox.Show($"Lỗi ở thêm Phòng. \n Lỗi: + {e}");
                //}

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
            PhongXoaTS = new RelayCommand<object>(p => { return SelectedTS != null && SelectedTS.Nghe ==0 && SelectedTS.Noi == 0 && SelectedTS.Doc == 0 && SelectedTS.Viet == 0; },
                p => { });
        }

        private void XoaGV()
        {
            PhongXoaGV = new RelayCommand<object>(p => { return SelectedGV != null; }, 
                p => {});
        }

        private void CapNhapDiem()
        {
            Update_Diem = new RelayCommand<object>(p => { return SelectedTS != null && (DiemNghe != SelectedTS.Nghe || DiemNoi != SelectedTS.Noi || DiemDoc != SelectedTS.Doc || DiemViet != SelectedTS.Viet); },
                p => {});
            Undo_Diem = new RelayCommand<object>(p => { return SelectedTS != null && (DiemNghe != SelectedTS.Nghe || DiemNoi != SelectedTS.Noi || DiemDoc != SelectedTS.Doc || DiemViet != SelectedTS.Viet); },
                p => { });

        }

        private void CapNhapThongTinPhong()
        {
            Undo = new RelayCommand<object>(p => { return SelectedItem != null && (TenPhong != SelectedItem.TenPhong ); },
                p => { });
            Agree = new RelayCommand<object>(p => { return SelectedItem != null && (TenPhong != SelectedItem.TenPhong); },
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
            PhongThiView_ChiTiet_ThemTS x = new PhongThiView_ChiTiet_ThemTS();
            x.DataContext = this;
            ListTS = new ObservableCollection<ThiSinh>(thiSinhRepository.GetAll());
            x.ShowDialog();
        }
        private void ClosePhongThemTS(object p)
        {
            PhongThiView_ChiTiet_ThemTS x = p as PhongThiView_ChiTiet_ThemTS;
            x.Close();
        }
        private void ThemTSVaoPhong()
        {
            AddTS = new RelayCommand<PhongThiView_ChiTiet_ThemTS>(p =>
            {
                if (SelectedItemTS != null) return true;
                return false;
            }, p =>
            {
                var y = trinhDoRepository.GetBy(SelectedItem.MaTrinhDo).SBDs;

                string x = SelectedItem.MaTrinhDo + $"{y.Count}";

                var sbdn = new SoBaoDanh() { CMND = SelectedItemTS.CMND, MaKhoaThi = SelectedItem.MaKhoaThi, MaTrinhDo = SelectedItem.MaTrinhDo, SBD = x };
                MessageBox.Show($"Bạn đã thêm nhân viên: Tên nhân viên: ");

                //soBaoDanhRepository.Add(sbdn);
                //try
                //{
                //    var tsn = new ThamGiaDuThi() { MaPhongThi = SelectedItem.MaPhongThi, SBD = };
                //    if (phanBoNhanVienDoanService.Create(pbnv))
                //    {
                //        pbnv.NhanVien = SelectedItemNhanVien;
                //        CloseThemNV(p);
                //        MessageBox.Show($"Bạn đã thêm nhân viên: Tên nhân viên: {TenNhanVien} - Nhiệm vụ: {pbnv.NhiemVu} ");
                //        //Show();
                //    }
                //}
                //catch
                //{
                //    MessageBox.Show("Lỗi ở thêm NHÂN VIÊN - Đoàn Du Lịch");
                //}

            });
            //AddTSn = new RelayCommand<PhongThiView_ChiTiet_ThemTS>(p =>
            //{
            //    if (SelectedItemNhanVien != null)
            //    {
            //        if (SelectedPhanBoNhanVienDoan.Count() > 0)
            //        {
            //            foreach (var i in SelectedPhanBoNhanVienDoan)
            //            {
            //                if (i.MaNhanVien == SelectedItemNhanVien.MaNhanVien || MaNhanVien == 0 || string.IsNullOrEmpty(TenNhanVien) || string.IsNullOrEmpty(NhiemVu)) return false;
            //            }
            //            return true;
            //        }
            //        return !string.IsNullOrEmpty(NhiemVu);
            //    }
            //    else { return false; }
            //}, p =>
            //{
            //    try
            //    {
            //        var pbnv = new PhanBoNhanVienDoan() { MaDoan = this.doanDuLichService.Get(SelectedItem.MaDoan).MaDoan, MaNhanVien = SelectedItemNhanVien.MaNhanVien, NhiemVu = NhiemVu };
            //        if (phanBoNhanVienDoanService.Create(pbnv))
            //        {
            //            pbnv.NhanVien = SelectedItemNhanVien;
            //            MessageBox.Show($"Bạn đã thêm nhân viên: Tên nhân viên: {SelectedItemNhanVien.TenNhanVien} - Nhiệm vụ: {pbnv.NhiemVu} ");
            //            NhiemVu = null;
            //        }
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Lỗi ở thêm NHÂN VIÊN - Đoàn Du Lịch");
            //    }
            //});
        
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
