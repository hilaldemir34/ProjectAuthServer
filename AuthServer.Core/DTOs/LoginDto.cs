using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.DTOs//Dtoların hepsini clientlar görür
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
