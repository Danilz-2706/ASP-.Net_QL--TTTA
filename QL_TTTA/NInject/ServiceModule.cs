using Domain.Interfaces;
using Infrastructure.Persistence.Service;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_TTTA.NInject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            //EF
            Bind(typeof(IEFRepository<>)).To(typeof(EFRepository<>)).InThreadScope();

            //CanhThi
            Bind<ICanhThiRepository>().To<CanhThiRepository>().InThreadScope();

            //GiaoVien
            Bind<IGiaoVienRepository>().To<GiaoVienRepository>().InThreadScope();

            //KhoaThi
            Bind<IKhoaThiRepository>().To<KhoaThiRepository>().InThreadScope();

            //PhongThi
            Bind<IPhongThiRepository>().To<PhongThiRepository>().InThreadScope();

            //SoBaoDanh
            Bind<ISoBaoDanhRepository>().To<SoBaoDanhRepository>().InThreadScope();

            //ThamGiaDuThi
            Bind<IThamGiaDuThiRepository>().To<ThamGiaDuThiRepository>().InThreadScope();

            //ThiSinh
            Bind<IThiSinhRepository>().To<ThiSinhRepository>().InThreadScope();

            //TrinhDo
            Bind<ITrinhDoRepository>().To<TrinhDoRepository>().InThreadScope();
        }
    }
}
