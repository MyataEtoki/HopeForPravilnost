using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HopeForPravilnost.view;
using HopeForPravilnost.model;
using StavteClassy;
using System.Windows.Forms;

namespace HopeForPravilnost.presenter
{
    public class MainPresenter
    {
        private IFormView view;
        private Db db;
        public MainPresenter(IFormView view) 
        {
            this.view = view;
            db = new Db();
        }
        // Get
        public List<Государство> GetГосударства() 
        {
            return db.GetГосударства();
        }
        public List<Область> GetОбласти()
        {
            return db.GetОбласти();
        }
        public List<Город> GetГорода()
        {
            return db.GetГорода();
        }
        public List<Район> GetРайоны()
        {
            return db.GetРайоны();
        }
        // Add
        public void AddГосударство(int id, string название, int _годСоздания)
        {
            db.AddГосударство(id, название, _годСоздания);
        }
        public void AddОбласть(int id, string название, int idВГосударстве)
        {
            db.AddОбласть(id, название, idВГосударстве);
        }
        public void AddГород(int id, string название, int idВОбласти)
        {
            db.AddГород(id, название, idВОбласти);
        }
        public void AddРайон(int id, string название, int idВГороде)
        {
            db.AddРайон(id, название, idВГороде);
        }
        public void SetПравитель(int id, string t1, string t2, string t3, int age)
        {
            db.SetПравитель(id, t1,t2,t3,age);
        }
        public Государство FindГосударствоId(int id)
        {
            return db.FindГосударствоId(id);
        }
        public Государство FindГосударствоName(string название)
        {
            return db.FindГосударствоName(название);
        }
        public Область FindОбластьName(string название)
        {
            return db.FindОбластьName(название);
        }
        public Город FindГородName(string название)
        {
            return db.FindГородName(название);
        }
        public Район FindРайонId(int id)
        {
            return db.FindРайонId(id);
        }
        public Район FindРайонName(string название)
        {
            return db.FindРайонName(название);
        }        
        public void ClearDB()
        {
            db.ClearDB();
        }
        // обращаемся к государству напрямую - через ref.
        public void ИзменитьНазваниеГосударства(ref Государство государство, string новоеНазвание)
        {
            db.ИзменитьНазваниеГосударства(ref государство, новоеНазвание);
        }
        public void ЗагрузитьДанныеButton(string filePath)
        {
            db.ЗагрузитьДанныеButton(filePath);
        }
        public void СохранитьДанныеButton(string filePath)
        {
            db.СохранитьДанныеButton(filePath);
        }
        // Революция
        public void SetРеволюцияButton(int id)
        {
            db.SetРеволюцияButton(id);
        }
        public void SetРеволюция(int id)
        {
            db.SetРеволюция(id);
        }        
        public void SetРайонОпасный(int id)
        {
            db.SetРайонОпасный(id);            
        }
        public void SetРайонБезопасный(int id)
        {
            db.SetРайонБезопасный(id);
        }
    }
}
