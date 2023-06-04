using AuthServer.Core.Configuration;
using AuthServer.Core.DTOs;
using AuthServer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services//service kısmında yazdığım interfaceleri servicete implemente ediyorum
{
    public interface ITokenService//bunu kendi içinde kullandırıyorum.dış dünyaya açma
    {
        TokenDto CreateToken(UserApp userApp);
        ClientTokenDto CreateTokenByClient(Client client);//client authservice e istek yapacak uygulama
    }
}
