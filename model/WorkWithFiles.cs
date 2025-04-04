using HopeForPravilnost.view;
using StavteClassy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopeForPravilnost.model
{
    public class WorkWithFiles
    {
        private Db db;
        public WorkWithFiles(Db dB)
        {
            db = dB;
        }
        public bool ЗагрузитьДанные(string filePath, out int количествоЗаписей)
        {
            var государства = db.GetГосударства();
            var области = db.GetГосударства();
            var города = db.GetГосударства();
            var районы = db.GetГосударства();
            количествоЗаписей = 0;

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                var stateMap = new Dictionary<int, Государство>(); // для привязки ID к Государству

                foreach (var line in lines)
                {
                    количествоЗаписей++;
                    var parts = line.Split(',');

                    if (parts.Length >= 2)
                    {
                        if (parts[0].Trim() == "Государство")
                        {
                            int id = int.Parse(parts[1].Trim());
                            string название = parts[2].Trim();
                            int годСоздания = int.Parse(parts[3].Trim());
                            var правитель = new Правитель
                            {
                                Имя = parts[4].Trim(),
                                Фамилия = parts[5].Trim(),
                                Отчество = parts[6].Trim(),
                                Возраст = int.Parse(parts[7].Trim()),
                                НачалоПравления = DateTime.Parse(parts[8].Trim())
                            };
                            string путьККартинке = parts.Length > 9 ? parts[9] : null;
                            var государство = new Государство(id, название, годСоздания)
                            {
                                ТекущийПравитель = правитель,
                                ПутьККартинке = путьККартинке
                            };
                            if (parts[4].Trim() != "") { государство.КтоТоПравит = true; }
                            государства.Add(государство);
                            stateMap[id] = государство; // запомнить ссылку на государство
                        }
                        else if (parts[0].Trim() == "Область")
                        {
                            int id = int.Parse(parts[1].Trim());
                            string название = parts[2].Trim();
                            int idГосударства = int.Parse(parts[3].Trim());

                            var область = new Область(id, название);
                            области.Add(область);

                            // Привязываем область к соответствующему государству
                            if (stateMap.TryGetValue(idГосударства, out var государство))
                            {
                                государство.ДобавитьОбласть(область);
                            }
                        }
                        else if (parts[0].Trim() == "Город")
                        {
                            int id = int.Parse(parts[1].Trim());
                            string название = parts[2].Trim();
                            int idОбласти = int.Parse(parts[3].Trim());

                            var город = new Город(id, название);
                            города.Add(город);

                            // Привязываем город к соответствующей области
                            var область = области.Find(o => o.ID == idОбласти);
                            область?.ДобавитьГород(город);
                        }
                        else if (parts[0].Trim() == "Район")
                        {
                            int id = int.Parse(parts[1].Trim());
                            string название = parts[2].Trim();
                            int idГорода = int.Parse(parts[3].Trim());

                            var район = new Район(id, название);
                            районы.Add(район);

                            // Привязываем район к соответствующему городу
                            var город = города.Find(g => g.ID == idГорода);
                            город?.ДобавитьРайон(район);
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public void СохранитьДанныеButton(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var государство in государства)
                {
                    // Сохраняем данные о государстве
                    writer.WriteLine($"Государство,{государство.ID},{государство.Название},{государство.ГодСоздания}," +
                    $"{государство.ТекущийПравитель.Имя},{государство.ТекущийПравитель.Фамилия}," +
                    $"{государство.ТекущийПравитель.Отчество},{государство.ТекущийПравитель.Возраст}," +
                    $"{государство.ТекущийПравитель.НачалоПравления},{государство.ПутьККартинке}");

                    // Сохраняем области
                    foreach (var область in государство.Области)
                    {
                        writer.WriteLine($"Область,{область.ID},{область.название},{государство.ID}");

                        // Сохраняем города
                        foreach (var город in область.Города)
                        {
                            writer.WriteLine($"Город,{город.ID},{город.Название},{область.ID}");

                            // Сохраняем районы
                            foreach (var район in город.Районы)
                            {
                                writer.WriteLine($"Район,{район.ID},{район.Название},{город.ID}");
                            }
                        }
                    }
                }
            }
        }
}
