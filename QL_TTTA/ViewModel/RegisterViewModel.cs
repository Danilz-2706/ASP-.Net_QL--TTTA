using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QL_TTTA.ViewModel
{
    public class RegisterViewModel:BaseViewModel
    {
        private readonly IKhoaThiRepository khoaThiRepository;
        private readonly IThamGiaDuThiRepository thamGiaDuThiRepository;
        private readonly ITrinhDoRepository trinhDoRepository;
        private readonly IThiSinhRepository thiSinhRepository;
        private readonly ISoBaoDanhRepository soBaoDanhRepository;
        // Các biến ở RegisterView //
        #region
        public string AddCMND { get; set; }
        public string AddTenTS { get; set; }
        public string AddSDT { get; set; }
        public string AddNoiSinh { get; set; }
        public string AddEmail { get; set; }
        public Gender? AddGender { get; set; }
        public DateTime? AddNgaySinh { get; set; }
        public DateTime? AddNgayCap { get; set; }
        public ObservableCollection<ThiSinh> ListTS { get; set; }
        public ObservableCollection<TrinhDo> ListTD { get; set; }
        public ObservableCollection<KhoaThi> ListKT { get; set; }
        public TrinhDo SelectedTD { get; set; }
        public KhoaThi SelectedKT { get; set; }

        private ThiSinh _SelectedTS;
        public ThiSinh SelectedTS
        {
            get => _SelectedTS;
            set
            {
                _SelectedTS = value;
                if (_SelectedTS != null)
                {
                    AddCMND = _SelectedTS.CMND;
                    AddTenTS = _SelectedTS.HoTen;
                    AddSDT = _SelectedTS.SDT;
                    AddGender = _SelectedTS.GioiTinh;
                    AddNgaySinh = _SelectedTS.NgaySinh;
                    AddNgayCap = _SelectedTS.NgayCap;
                }
            }
        }
        #endregion

        // Command ở RegisterView //
        #region
        public ICommand Register { get; set; }
        public ICommand Reset { get; set; }

        #endregion
        public RegisterViewModel() { }
        public RegisterViewModel(IKhoaThiRepository khoaThiRepository, IThamGiaDuThiRepository thamGiaDuThiRepository, ITrinhDoRepository trinhDoRepository, IThiSinhRepository thiSinhRepository, ISoBaoDanhRepository soBaoDanhRepository) 
        {
            this.khoaThiRepository = khoaThiRepository;
            this.thamGiaDuThiRepository = thamGiaDuThiRepository;
            this.thiSinhRepository = thiSinhRepository;
            this.trinhDoRepository = trinhDoRepository;
            this.soBaoDanhRepository = soBaoDanhRepository;

            ListTS = new ObservableCollection<ThiSinh>(thiSinhRepository.GetAll());
            ListTD = new ObservableCollection<TrinhDo>(trinhDoRepository.GetAll());
            ListKT = new ObservableCollection<KhoaThi>(khoaThiRepository.GetAll());

            Reset = new RelayCommand<object>(p => true, p =>
            {
                SelectedTS = null;
                AddCMND = null;
                AddTenTS = null;
                AddSDT = null;
                AddGender = null;
                AddNoiSinh = null;
                AddEmail = null;
                AddNgaySinh = null;
                AddNgayCap = null;
            });

            Register = new RelayCommand<object>(p =>
            {
                return !string.IsNullOrEmpty(AddCMND) && !string.IsNullOrEmpty(AddTenTS) && !string.IsNullOrEmpty(AddSDT) && AddGender != null && AddNgaySinh != null && AddNgayCap != null && SelectedTD != null && SelectedKT != null;
            }, p =>
            {
                if (SelectedTS != null)
                {
                    MessageBox.Show($"Đã đăng ký thành công thí sinh: CMND {AddCMND} - Họ tên {AddTenTS}");
                }
                else
                {
                    var tsm = new ThiSinh() { CMND = AddCMND, HoTen = AddTenTS, NoiSinh = AddNoiSinh, GioiTinh = (Gender)AddGender, NgaySinh = (DateTime)AddNgaySinh, SDT = AddSDT, NgayCap = (DateTime)AddNgayCap, Email = AddEmail };
                    thiSinhRepository.Add(tsm);
                    MessageBox.Show($"Đã tạo thành công thí sinh: CMND {AddCMND} - Họ tên {AddTenTS}");
                }

                var y = soBaoDanhRepository.GetAll().Where(x => x.MaTrinhDo.StartsWith($"{SelectedTD.MaTrinhDo}")).Count() + 1;
                string x = SelectedTD.MaTrinhDo + y.ToString();

                var sbdn = new SoBaoDanh() { CMND = AddCMND, MaKhoaThi = SelectedKT.MaKhoaThi, MaTrinhDo = SelectedTD.MaTrinhDo, SBD = x };
                soBaoDanhRepository.Add(sbdn);

                SelectedTS = null;
                AddCMND = null;
                AddTenTS = null;
                AddSDT = null;
                AddGender = null;
                AddNoiSinh = null;
                AddEmail = null;
                AddNgaySinh = null;
                AddNgayCap = null;
            });
        }
    }
}
