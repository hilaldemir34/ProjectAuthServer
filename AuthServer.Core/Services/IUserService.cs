using AuthServer.Core.DTOs;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IUserService//yeni üyeleri kaydetme
    {                           //direkt api ile haberleşecek
        //bu methodu AUTHAPI da herhangi bir kullanıcı oluşturacak controllerın constructorın da bu servisi geçeceğim.
        //bu yüzden response dönmeliyim
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<UserAppDto>> GetUserByNameAsync(string UserName);//username ine göre veri tabanından
                                                                       //kullanıcıyı bul.
    }
}
