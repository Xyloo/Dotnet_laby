﻿using System.Runtime.InteropServices;
using Lab8.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace Lab8.Data
{
    public class FoxesRepository : IFoxesRepository
    {
        private readonly LiteDatabase db;
        public FoxesRepository()
        {
            db = new LiteDatabase(@"foxes.litedb");
        }
        public void Add(Fox f)
        {
            var all = db.GetCollection<Fox>();
            f.Id = all.Count() > 0 ? all.Max(x => x.Id) + 1 : 1;
            db.GetCollection<Fox>().Insert(f);
        }
        public Fox? Get(int id)
        {
            return db.GetCollection<Fox>().FindById(id);
        }
        public IEnumerable<Fox> GetAll()
        {
            return db.GetCollection<Fox>().FindAll();
        }
        public void Update(int id, Fox f)
        {
            var c = db.GetCollection<Fox>().FindById(id);
            c.Loves = f.Loves;
            c.Hates = f.Hates;
            db.GetCollection<Fox>().Update(c);
        }

        public Fox? IncrementLoves(int id)
        {
            Fox? fox = db.GetCollection<Fox>().FindById(id);
            if (fox == null)
                return null;

            fox.Loves++;
            db.GetCollection<Fox>().Update(fox);
            return fox;
        }

        public Fox? IncrementHates(int id)
        {
            Fox? fox = db.GetCollection<Fox>().FindById(id);
            if (fox == null)
                return null;

            fox.Hates++;
            db.GetCollection<Fox>().Update(fox);
            return fox;
        }
    }

}
