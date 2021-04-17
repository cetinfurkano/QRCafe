using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otomasyon.KullaniciArayuzu.Exceptions
{
    class BosVeriGirmeHatasi:Exception 
    {
        public BosVeriGirmeHatasi (string message) : base(message)
        {

        }
    }
}
