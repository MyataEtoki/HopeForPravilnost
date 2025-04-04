using StavteClassy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopeForPravilnost.model.dto
{
    // Интерфейс - поведение класса Область
    public interface IОбласть
    {
        void ДобавитьГород(Город город);
        void УдалитьГород(Город город);
        string ПолучитьСписокГородов();
    }
}
