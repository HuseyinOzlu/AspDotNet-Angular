using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        bool Success { get; } // get sadece okunabilir (get->oku)
        // yapılan işlem (ekleme çıkarma (CRUD operasyonları) ) başarılı ya da başarısız
        string Message { get; }
        // kullanıcıya mesaj vermek için kullanılıyor 
    }
}
