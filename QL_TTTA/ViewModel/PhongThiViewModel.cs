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
                    MaPhong = SelectedItem.MaPhongThi;
                    
                    TenPhong = SelectedItem.TenPhong;
                    NgayThi = SelectedItem.ThoiGianBatDau;
                    TenTrinhDo = SelectedItem.MaTrinhDo;
                    KhoaThi = SelectedItem.MaKhoaThi;

                    SelectedPhanBoGiaoVien = new ObservableCollection<GiaoVien>(phongThiRepository.GetGVByPhong(SelectedItem.MaPhongThi).ToList());

                    SelectedPhanBoThiSinh = new ObservableCollection<ThiSinh>(phongThiRepository.GetTSByPhong(SelectedItem.MaPhongThi).ToList());
                    SoLuong = SelectedPhanBoThiSinh.Count();
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
        public ObservableCollection<ThiSinh> SelectedPhanBoThiSinh { get; set; }
        public TrinhDo SelectedTrinhDo { get; set; }
        public KhoaThi SelectedKhoaThi { get; set; }
        private ThiSinh _SelectedTS;
        public ThiSinh SelectedTS
        {
            get => _SelectedTS;
            set
            {
                _SelectedTS = value;
                if(_SelectedTS != null)
                {
                    foreach( var i in _listTDT)
                    {
                        if(i.SBD == SelectedTS.SoBaoDanh && i.MaPhongThi == SelectedItem.MaPhongThi)
                        {
                            DiemNghe = i.Nghe;
                            DiemNoi = i.Noi;
                            DiemDoc = i.Doc;
                            DiemViet = i.Viet;
                        }
                    }
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
        public int MaGV { get; set; }
        public string HoTenGV { get; set; }
        public string SDTGV { get; set; }
        private GiaoVien _SelectedItemGiaoVien;
        public GiaoVien SelectedItemGiaoVien
        {
            get => _SelectedItemGiaoVien;
            set
            {
                _SelectedItemGiaoVien = value;
                if (_SelectedItemGiaoVien != null)
                {
                    MaGV = _SelectedItemGiaoVien.MaGV;
                    HoTenGV = _SelectedItemGiaoVien.HoTen;
                    SDTGV = _SelectedItemGiaoVien.SDT;
                }
            }
        }

        #endregion

        // Các biến ở PhongThiView_ChiTiet_NhapDiem //
        #region
        public int? AddDiemNghe { get; set; }
        public int? AddDiemNoi { get; set; }
        public int? AddDiemDoc { get; set; }
        public int? AddDiemViet { get; set; }
        public ObservableCollection<SoBaoDanh> ListTSNhapDiem { get; set; }
        private ThiSinh _SelectedTSDiem;
        public ThiSinh SelectedTSDiem
        {
            get => _SelectedTSDiem;
            set
            {
                _SelectedTSDiem = value;
            }
        }
        private SoBaoDanh _SelectedTSNhapDiem;
        public SoBaoDanh SelectedTSNhapDiem
        {
            get => _SelectedTSNhapDiem;
            set
            {
                _SelectedTSNhapDiem = value;
            }
        }
        #endregion

        // Các biến ở PhongThiView_ChiTiet_ThemTS //
        #region
        public string CMNDTS { get; set; }
        public string SobaodanhTS { get; set; }
        public string KhoaThiTS { get; set; }
        public string TrinhDoTS { get; set; }

        public ObservableCollection<SoBaoDanh> ListTS { get; set; }
        private SoBaoDanh _SelectedItemTS;
        public SoBaoDanh SelectedItemTS
        {
            get => _SelectedItemTS;
            set
            {
                _SelectedItemTS = value;
                if (_SelectedItemTS != null)
                {
                    CMNDTS = _SelectedItemTS.CMND;
                    SobaodanhTS = _SelectedItemTS.SBD;
                    KhoaThiTS = _SelectedItemTS.SBD;
                    TrinhDoTS = _SelectedItemTS.SBD;
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

        private ObservableCollection<SoBaoDanh> _listSBD { get; set; }
        public ICollectionView ListSBD { get; set; }

        private ObservableCollection<ThamGiaDuThi> _listTDT { get; set; }

        private ObservableCollection<GiaoVien> _listGV { get; set; }
        public ICollectionView ListGV { get; set; }
        //Các công đoạn để Tìm Kiếm//
        #region
        //Danh sách phòng
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
        //Danh sách số báo danh
        private string _listFilterSBD = string.Empty;
        public string ListFilterSBD
        {
            get => _listFilterSBD;
            set
            {
                _listFilterSBD = value;
                ListSBD.Refresh();
            }
        }
        private bool FilterSBD(object obj)
        {
            if (obj is SoBaoDanh pt) return pt.CMND.Contains(ListFilterSBD, StringComparison.InvariantCultureIgnoreCase) || pt.SBD.Contains(ListFilterSBD, StringComparison.InvariantCultureIgnoreCase)||
                    pt.MaKhoaThi.Contains(ListFilterSBD, StringComparison.InvariantCultureIgnoreCase) || pt.MaTrinhDo.Contains(ListFilterSBD, StringComparison.InvariantCultureIgnoreCase);
            return false;
        }
        //Danh sách giáo viên
        private string _listFilterGV = string.Empty;
        public string ListFilterGV
        {
            get => _listFilterGV;
            set
            {
                _listFilterGV = value;
                ListGV.Refresh();
            }
        }
        private bool FilterGV(object obj)
        {
            if (obj is GiaoVien pt) return pt.HoTen.Contains(ListFilterGV, StringComparison.InvariantCultureIgnoreCase);
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
            this.giaoVienRepository = giaoVienRepository;

            Load();
            #region Các command
            Add = new RelayCommand<object>(p => true, p => ThemPT());
            AddNew();
            Close_PhongThem = new RelayCommand<object>(p => true, p => CloseThem(p));

            Details = new RelayCommand<object>(p => { return SelectedItem != null; }, p => ChiTietPT());
            XoaGV();
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
            NhapDiemMoi();
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
            Load();

        }
        private void AddNew()
        {
            //Reset
            Reset = new RelayCommand<PhongThiView_Them>(p => { return true; }, p => { AddSelectedTrinhDo = null;  AddSelectedKhoaThi = null;  AddGioBatDau = null; AddGioKetThuc = null; });

            //Save
            Save = new RelayCommand<PhongThiView_Them>(p =>
            {
                return  AddSelectedTrinhDo != null && AddSelectedKhoaThi != null && AddGioBatDau < AddGioKetThuc ;
            }, p =>
            {
                AddTenPhong = AddSelectedTrinhDo.TenTrinhDo + "P" + _listPhongThi.Count().ToString();
                var ptn = new PhongThi() {MaPhongThi = AddTenPhong, TenPhong = AddTenPhong, MaKhoaThi = AddSelectedKhoaThi.MaKhoaThi, MaTrinhDo = AddSelectedTrinhDo.TenTrinhDo, ThoiGianBatDau = (DateTime)AddGioBatDau, ThoiGianKetThuc = (DateTime)AddGioKetThuc };
                phongThiRepository.Add(ptn);
                CloseThem(p);
                MessageBox.Show($"Thêm thành công phòng thì: {AddTenPhong} - Thời gian bắt đầu: {AddGioBatDau} - Thời gian kết thúc: {AddGioKetThuc}");
            });
        }
        #endregion

        //Func Chi Tiết Phòng Thi
        #region
        private void ChiTietPT()
        {
            PhongThiView_ChiTiet x = new PhongThiView_ChiTiet();
            x.DataContext = this;
            SelectedPhanBoThiSinh = new ObservableCollection<ThiSinh>(phongThiRepository.GetTSByPhong(SelectedItem.MaPhongThi).ToList());
            SelectedPhanBoGiaoVien = new ObservableCollection<GiaoVien>(phongThiRepository.GetGVByPhong(SelectedItem.MaPhongThi).ToList());
            _listTDT = new ObservableCollection<ThamGiaDuThi>(thamGiaDuThiRepository.GetAll());
            x.ShowDialog();
        }
        private void CloseChiTiet(object obj)
        {
            PhongThiView_ChiTiet x = obj as PhongThiView_ChiTiet;
            x.Close();
            SoLuong = SelectedPhanBoThiSinh.Count();
        }

        //Các chức năng ở tại PhongThiView_ChiTiet
        #region

        private void XoaGV()
        {
            PhongXoaGV = new RelayCommand<object>(p => { return SelectedGV != null; }, 
                p => {});
        }

        private void CapNhapDiem()
        {

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
            _listGV = new ObservableCollection<GiaoVien>(giaoVienRepository.GetAll());
            ListGV = CollectionViewSource.GetDefaultView(_listGV);
            ListGV.Filter = FilterGV;
            x.ShowDialog();
        }
        private void ClosePhongThemGV(object p)
        {
            PhongThiView_ChiTiet_ThemGV x = p as PhongThiView_ChiTiet_ThemGV;
            x.Close();
            SelectedPhanBoGiaoVien = new ObservableCollection<GiaoVien>(phongThiRepository.GetGVByPhong(SelectedItem.MaPhongThi).ToList());

        }
        private void ThemMoiGV()
        {
            AddGV = new RelayCommand<PhongThiView_ChiTiet_ThemGV>(p =>
            {
                if (SelectedPhanBoGiaoVien.Count() >= 2) return false;
                if (SelectedItemGiaoVien != null)
                {
                    if (SelectedPhanBoGiaoVien.Count() == 0) return true;
                    foreach (var i in SelectedPhanBoGiaoVien)
                    {
                        if (i.MaGV == SelectedItemGiaoVien.MaGV) return false;
                    }
                    return true;
                }
                return false;
            }, p =>
            {
                var ct = new CanhThi() { MaPhongThi = SelectedItem.MaPhongThi, MaGV = SelectedItemGiaoVien.MaGV };
                canhThiRepository.Add(ct);
                ClosePhongThemGV(p);
                MessageBox.Show($"Thêm thành công giáo viên: Mã GV: {SelectedItemGiaoVien.MaGV}");
            });
        }
        #endregion

        //Các chức năng ở tại PhongThiView_ChiTiet_ThemTS
        #region
        private void ThemTS(object p)
        {
            PhongThiView_ChiTiet_ThemTS x = new PhongThiView_ChiTiet_ThemTS();
            x.DataContext = this;
            _listSBD = new ObservableCollection<SoBaoDanh>(soBaoDanhRepository.GetAll());
            ListSBD = CollectionViewSource.GetDefaultView(_listSBD);
            ListSBD.Filter = FilterSBD;
            x.ShowDialog();
        }
        private void ClosePhongThemTS(object p)
        {
            PhongThiView_ChiTiet_ThemTS x = p as PhongThiView_ChiTiet_ThemTS;
            x.Close();
            SelectedPhanBoThiSinh = new ObservableCollection<ThiSinh>(phongThiRepository.GetTSByPhong(SelectedItem.MaPhongThi).ToList());
            SoLuong = SelectedPhanBoThiSinh.Count();
            _listSBD = null;
        }
        private void ThemTSVaoPhong()
        {
            AddTS = new RelayCommand<PhongThiView_ChiTiet_ThemTS>(p =>
            {
                if (SoLuong >= 35) return false;
                if (SelectedItemTS != null)
                {
                    if (SelectedItemTS.MaTrinhDo == SelectedItem.MaTrinhDo && SelectedItemTS.MaKhoaThi == SelectedItem.MaKhoaThi)
                    {
                    if (SelectedPhanBoThiSinh.Count() == 0) return true;
                        foreach (var i in SelectedPhanBoThiSinh)
                        {
                            if (i.CMND == SelectedItemTS.CMND) return false;
                        }
                        return true;
                    }
                    return false;
                }
                return false;
            }, p =>
            {
                var tgdt = new ThamGiaDuThi() { MaPhongThi = SelectedItem.MaPhongThi, SBD =SelectedItemTS.SBD };
                thamGiaDuThiRepository.Add(tgdt);
                ClosePhongThemTS(p);
                MessageBox.Show($"Thêm thành công thí sinh: SBD: {SelectedItemTS.SBD} - CMND: {SelectedItemTS.CMND}");
            });
        }
        #endregion
        //Các chức năng ở tại PhongThiView_ChiTiet_NhapDiem
        #region
        private void CloseNhapDiem(object p)
        {
            PhongThiView_ChiTiet_NhapDiem x = p as PhongThiView_ChiTiet_NhapDiem;
            x.Close();
            ListTSNhapDiem = null;
            SelectedTSDiem = null;
        }
        private void NhapDiem()
        {
            PhongThiView_ChiTiet_NhapDiem x = new PhongThiView_ChiTiet_NhapDiem();
            x.DataContext = this;
            ListTSNhapDiem = new ObservableCollection<SoBaoDanh>();
            SelectedTS = null;
            x.ShowDialog();
        }
        private void NhapDiemMoi()
        {
            if (SelectedTSDiem != null) { SelectedTSNhapDiem = null; } if (SelectedTSNhapDiem != null) { SelectedTSDiem = null; }
            AddDiem = new RelayCommand<object>(p =>
            {
                if (SelectedTSDiem != null && ListTSNhapDiem.Count() == 0)
                {
                    return true;
                }
                else if (SelectedTSDiem != null && ListTSNhapDiem.Count() > 0)
                {
                    foreach (var i in ListTSNhapDiem) { if (i.SBD == SelectedTSDiem.SoBaoDanh) return false; }
                    return true;
                }
                return false;
            }, p =>
            {
                var capnhapdiem = new SoBaoDanh { SBD = SelectedTSDiem.SoBaoDanh };
                ListTSNhapDiem.Add(capnhapdiem);
                SelectedTSDiem = null;
            });
            RemoveDiem = new RelayCommand<object>(p =>
            {
                if (SelectedTSNhapDiem != null) return true;
                return false;
            }, p =>
            {
                var capnhapdiem = ListTSNhapDiem.SingleOrDefault(x => x.SBD == SelectedTSNhapDiem.SBD);
                ListTSNhapDiem.Remove(capnhapdiem);
                SelectedTSNhapDiem = null;

            });
            ResetDiem = new RelayCommand<object>(p =>
            {
                if (ListTSNhapDiem.Count() > 0) return true;
                return false;
            }, p =>
            {
                ListTSNhapDiem = new ObservableCollection<SoBaoDanh>();
            });
            SaveDiem = new RelayCommand<object>(p =>
            {
                if (SelectedItem!=null && ListTSNhapDiem.Count() > 0 && AddDiemDoc >=0 && AddDiemNghe >= 0 && AddDiemNoi >= 0 && AddDiemViet >= 0) return true;
                return false;
            }, p =>
            {
                foreach (var i in ListTSNhapDiem)
                {
                    var d = new ThamGiaDuThi() {MaPhongThi = SelectedItem.MaPhongThi, SBD = i.SBD, Doc = AddDiemDoc, Nghe = AddDiemNghe, Noi = AddDiemNoi, Viet = AddDiemViet };

                    thamGiaDuThiRepository.Update(d);
                }
                CloseNhapDiem(p);
                MessageBox.Show("Nhập điểm thành công!");
            });
        }
        #endregion
        #endregion
    }
}
