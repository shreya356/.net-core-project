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
    public class StudentsImplementInterface : IRepositoryInterface<Students, StudentsView>
    {

        FinalGPTWBackendProjectContext _db;
        public StudentsImplementInterface(FinalGPTWBackendProjectContext db)
        {
            _db = db;
        }

        public void Add(Students entity)
        {
            _db.Students.Add(entity);
            _db.SaveChanges();
            
        }

        public void Delete(Students entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public Students Get(long Id)
        {
            var use = _db.Students
                .SingleOrDefault(b => b.StudentsId == Id);

            if (use == null)
            {
                return null;
            }

            return use;
        }

        public IEnumerable<Users> GetAll()
        {
            if (_db != null)
            {
                return _db.Users.ToList();
            }

            return null;
        }
        public async Task<UsersView> GetView(long Id)
        {
            if (_db != null)
            {
                return await (from u in _db.Users
                              from s in _db.Attendance
                              where s.UsersId == Id
                              select new UsersView
                              {

                                  UsersId = s.UsersId,
                                  Name = u.Name,
                                  AttendanceId = s.AttendanceId,
                                  password = u.Password,
                                  Role = u.Role,
                                  Status = s.Status,
                                  Remark = s.Remark,
                                  AttendanceDate = s.AttendanceDate

                              }).FirstOrDefaultAsync();
            }

            return null;
        }
        public IEnumerable<StudentsView> GetAlViewModel()
        {
            throw new NotImplementedException();
        }

        

        public void StudentPresentDates(Students entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Students entityToUpdate, Students entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Students> IRepositoryInterface<Students, StudentsView>.GetAll()
        {
            throw new NotImplementedException();
        }

        StudentsView IRepositoryInterface<Students, StudentsView>.GetView(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
