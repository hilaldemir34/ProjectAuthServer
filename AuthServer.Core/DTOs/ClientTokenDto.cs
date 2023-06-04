using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.DTOs
{
    public class ClientTokenDto//üyelik sistemi ile ilgili bir şey yok.Clientları döneceğimiz token modeli.
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
    }
}
