﻿using HopeForPravilnost.model.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StavteClassy
{

    public class Государство : Субъект, IПравитель, IГосударство
    {
        public override sealed string Название
        {
            get => base.Название; // Получаем значение от базового класса
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    // Преобразуем первую букву к заглавной
                    char firstChar = value[0];
                    if (char.IsLower(firstChar))
                    {
                        firstChar = char.ToUpper(firstChar);
                    }
                    название = firstChar + value.Substring(1); // Собираем новое значение
                }
            }
        }

        public List<Область> Области; // ассоциация

        // Индексатор для доступа к областям по индексу
        public Область this[int index]
        {
            get
            {
                if (index >= 0 && index < Области.Count)
                    return Области[index];
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс вне диапазона");
            }
        }

        private int годСоздания = 0;
        public int ГодСоздания
        {
            get => годСоздания;
            set
            {
                if (value == 0)
                {
                    годСоздания = DateTime.Now.Year;
                }
                else
                {
                    годСоздания = value;
                }
            }
        }
        public Правитель ТекущийПравитель;
        private bool ктоТоПравит = false;
        public bool КтоТоПравит
        {
            get => ктоТоПравит;
            set => ктоТоПравит = value;
        }
        public bool ПроходятВыборы;

        public Государство(int id, string название) : base(id, название) // конструктор
        {
            Области = new List<Область>(); // композиция
        }

        public Государство(int id, string название, int годСоздания, bool проходятВыборы = false) : base(id, название) // перегруженный конструктор 
        {
            Области = new List<Область>(); // композиция
            ГодСоздания = годСоздания;
            ПроходятВыборы = проходятВыборы;
        }

        public event Action<string> ПравителяНет;
        public void Революция()
        {
            ПроходятВыборы = true;
            КтоТоПравит = false;
            ТекущийПравитель = new Правитель();
            ПравителяНет?.Invoke($"В стране {Название} революция, правитель сброшен.");
            ИзменитьСостояниеРайоновНаОпасный(); // изменить состояние всех районов на "Опасный"
        }
        public void ИзменитьСостояниеРайоновНаОпасный()
        {
            foreach (var область in Области)
            {
                foreach (var город in область.Города)
                {
                    foreach (var район in город.Районы)
                    {
                        район.СостояниеБезопасности = "Опасный"; // изменения состояния района на "Опасный"
                    }
                }
            }
        }

        public int ВычислитьВозраст()
        {
            return DateTime.Now.Year - ГодСоздания;
        }

        public void ДобавитьОбласть(Область область)
        {
            Области.Add(область);
        }
        public override string ПолучитьИнформацию()
        {
            var информация = base.ПолучитьИнформацию(); // Получаем базовую информацию
            информация += $", Области: {Области.Count}"; // Дополнительная информация о областях
            return информация;
        }
        public void УстановитьПравителя(string имя, string фамилия, string отчество, int возраст, DateTime НачПрав)
        {
            ТекущийПравитель = new Правитель(имя, фамилия, отчество, возраст, НачПрав);
            КтоТоПравит = true;
            ПроходятВыборы = false;
        }
        public void УстановитьПравителя(string имя, string фамилия, int возраст, DateTime НачПрав)
        {
            ТекущийПравитель = new Правитель(имя, фамилия, возраст, НачПрав);
            КтоТоПравит = true;
            ПроходятВыборы = false;
        }
        public string ПоказатьИнформациюОПравителе()
        {
            if (ТекущийПравитель.Существует == true)
            {
                return $"\nСейчас здесь правит: {ТекущийПравитель.Имя} {ТекущийПравитель.Отчество} {ТекущийПравитель.Фамилия}, " +
                    $"возраст: {ТекущийПравитель.Возраст}. \nНачал править: {ТекущийПравитель.НачалоПравления}";
            }
            return $"\nСейчаc никто не правит здесь.";
        }
        public override string ToString()
        {
            return $"ID: {ID}, Название самой великой страны: {Название}";
        }

    }

    
}