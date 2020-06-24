using FinalGPTWBackendProject.Data;
using FinalGPTWBackendProject.Models;
using FinalGPTWBackendProject.Repository;
using FinalGPTWBackendProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalGPTWBackendProject.ImplementRepository
{
    public class TeachersImplementInterface : IRepositoryInterface<Teachers, TeachersView>
    {

        FinalGPTWBackendProjectContext _db;
        public TeachersImplementInterface(FinalGPTWBackendProjectContext db)
        {
            _db = db;
        }

        public void Add(Teachers entity)
        {

            _db.Teachers.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Teachers entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public Teachers Get(long Id)
        {
            var use = _db.Teachers
                .SingleOrDefault(b => b.TeachersId == Id);

            if (use == null)
            {
                return null;
            }

            return use;
        }

        public IEnumerable<Teachers> GetAll()
        {
            if (_db != null)
            {
                return _db.Teachers.ToList();
            }

            return null;
        }

        public async Task<TeachersView> GetView(long Id)
        {
            if (_db != null)
            {
                return await (from u in _db.Users
                              from s in _db.Teachers
                              where s.UsersId == Id
                              select new TeachersView
                              {

                                  UsersId = s.UsersId,
                                  Name = u.Name,
                                  TeachersId = s.TeachersId,
                                  
                                  
                                  Gender = s.Gender,
                                  Subject = s.Subjects,
                                  BirtDate = s.BirthDate

                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public IEnumerable<TeachersView> GetAlViewModel()
        {
            throw new NotImplementedException();
        }

        

        public void StudentPresentDates(Teachers entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Teachers entityToUpdate, Teachers entity)
        {
            throw new NotImplementedException();
        }

        TeachersView IRepositoryInterface<Teachers, TeachersView>.GetView(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
