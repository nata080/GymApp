﻿using GymApp.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {

            _db = db;
            Category = new CategoryRepository(_db);
            Exercise = new ExerciseRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public IExerciseRepository Exercise { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
    
}
