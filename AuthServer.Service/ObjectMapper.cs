using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Service
{
    public static class ObjectMapper//IMapper üzerinden interface i almalıyım.
                             //Imapper üzerinden mapleme kodlamalarını gerçekleştir.
                             //nesne örneğini buradan alacağım 
    {
        //ben datayı alana kadar memory de bulunmasın.istediğim anda memory de bulunsun.Lazy loading, ihtiyaç olduğunda yükle demek.ihtiyaç anında çek
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {//hernahgi bir parametre almayan geriye IMapper dönen
            var config = new MapperConfiguration(cfg =>//cfg=IM apperConfigurationInterfacetir.
            {
                cfg.AddProfile<DtoMapper>();//automappera bildir.
            });
            return config.CreateMapper();//config ile beraber IMapper döner.
        });
        public static IMapper Mapper => lazy.Value;//sadece datayı alacağı için getleme işlemi yaptık

    }
}
