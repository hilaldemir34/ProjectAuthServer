using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Configuration
{
    public class Client//iç kodlamada kullanacağım client nesnesini ve tokenservicesini dış dünyaya açmayacağım
    {//AuthServer da istek yapacak uygulamalara karşılık gelir.
        public string Id { get; set; }
        public string Secret { get; set; }
        public List<string>Audiences { get; set; }//hangi apiler ulaşacak onları burda tutacağım.payload ta gözükür.
    }
}
