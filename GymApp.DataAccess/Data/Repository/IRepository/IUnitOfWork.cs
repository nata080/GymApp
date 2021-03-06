﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IExerciseRepository Exercise { get; }

        void Save();
    }
}
