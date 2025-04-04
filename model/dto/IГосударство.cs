using StavteClassy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopeForPravilnost.model.dto
{
    // Интерфейс - поведение класса Государство
    public interface IГосударство
    {
        string Название { get; }
        int ГодСоздания { get; }
        int ВычислитьВозраст();
        public void ДобавитьОбласть(Область область);
    }
}
