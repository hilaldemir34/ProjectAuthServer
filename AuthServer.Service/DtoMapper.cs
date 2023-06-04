using AuthServer.Core.DTOs;
using AuthServer.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Service
{
    internal class DtoMapper:Profile//profile sınıfından miras alarak maplenme işlemini gerçekleştirdim.
    {
        public DtoMapper()
        {
            CreateMap<ProductDto, Product>().ReverseMap();//ikisi birbirine dönüşebilir.
            CreateMap<UserAppDto, UserApp>().ReverseMap();
        }
    }
}
