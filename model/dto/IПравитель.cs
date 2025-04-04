using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopeForPravilnost.model.dto
{
    // Интерфейс - поведение структуры Правитель в классе Государство
    public interface IПравитель
    {
        bool КтоТоПравит { get; } // свойство для проверки, есть ли правитель
        void УстановитьПравителя(string имя, string фамилия, string отчество, int возраст, DateTime началоПравления);
        void УстановитьПравителя(string имя, string фамилия, int возраст, DateTime началоПравления);
        string ПоказатьИнформациюОПравителе();
        void Революция();
        void ИзменитьСостояниеРайоновНаОпасный();
    }
}
