using GymApp.DataAccess.Data.Repository.IRepository;
using GymApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymApp.DataAccess.Data.Repository
{
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        private readonly ApplicationDbContext _db;

        public ExerciseRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public void Update(Exercise exercise)
        {
            var exerciseFromDb = _db.Exercise.FirstOrDefault(mbox => mbox.Id == exercise.Id);
            exerciseFromDb.Name = exercise.Name;
            exerciseFromDb.Set = exercise.Set;
            exerciseFromDb.Burden = exercise.Burden;
            exerciseFromDb.Time = exercise.Time;
            exerciseFromDb.Comment = exercise.Comment;
            exerciseFromDb.CategoryId = exercise.CategoryId;
            _db.SaveChanges();
        }
    }
}
