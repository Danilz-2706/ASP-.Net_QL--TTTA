using Ninject;
using QL_TTTA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_TTTA.NInject
{
    public class ServiceLocator
    {
        public IKernel Kernel { get; private set; } = new StandardKernel(new ServiceModule());

        //Phòng thi//
        public PhongThiViewModel PhongThiViewModel
        {
            get
            {
                return Kernel.Get<PhongThiViewModel>();
            }
        }

        //Thí sinh//
        public ThiSinhViewModel ThiSinhViewModel
        {
            get
            {
                return Kernel.Get<ThiSinhViewModel>();
            }
        }

        //Giáo viên//
        public GiaoVienViewModel GiaoVienViewModel
        {
            get
            {
                return Kernel.Get<GiaoVienViewModel>();
            }
        }

        //Khóa thi//
        public KhoaThiViewModel KhoaThiViewModel
        {
            get
            {
                return Kernel.Get<KhoaThiViewModel>();
            }
        }

        //Đăng ký//
        public RegisterViewModel RegisterViewModel
        {
            get
            {
                return Kernel.Get<RegisterViewModel>();
            }
        }
    }
}
