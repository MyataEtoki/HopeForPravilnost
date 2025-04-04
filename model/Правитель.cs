using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StavteClassy
{
    public struct Правитель // представитель государства
    {
        private string имя = "Undefined";
        public string Имя
        {
            get => имя;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    // Проверка первого символа
                    char firstChar = value[0];
                    // Если первый символ строчный, заменяем его на прописной
                    if (char.IsLower(firstChar))
                    {
                        firstChar = char.ToUpper(firstChar);
                    }
                    // Собираем новое значение с измененным первым символом
                    имя = firstChar + value.Substring(1);
                }
            }
        }
        public string Фамилия = "Undefined";
        public string Отчество = "Undefined";
        public int Возраст;
        private DateTime началоПравления;
        public DateTime НачалоПравления
        {
            get => началоПравления;
            set
            {
                началоПравления = value;
            }
        }
        public bool Существует = false;
        public Правитель()
        {
            Существует = false;
        }
        public Правитель(string имя, string фамилия, int возраст, DateTime НачПрав) : this()
        {
            Существует = true;
            Имя = имя;
            Фамилия = фамилия;
            Возраст = возраст;
            НачалоПравления = НачПрав;
        }
        public Правитель(string имя, string фамилия, string отчество, int возраст, DateTime НачПрав) : this()
        {
            Существует = true;
            Имя = имя;
            Фамилия = фамилия;
            Возраст = возраст;
            Отчество = отчество;
            НачалоПравления = НачПрав;
        }
    }
}
