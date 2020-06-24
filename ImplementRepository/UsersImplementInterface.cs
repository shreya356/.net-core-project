using FinalGPTWBackendProject.Data;
using FinalGPTWBackendProject.Models;
using FinalGPTWBackendProject.Repository;
using FinalGPTWBackendProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FinalGPTWBackendProject.ImplementRepository
{
    public class UsersImplementInterface : IRepositoryInterface<Users, UsersView>
    {

        FinalGPTWBackendProjectContext _db;
        public UsersImplementInterface(FinalGPTWBackendProjectContext db)
        {
            _db = db;
        }

        public void Add(Users entity)
        {
            _db.Users.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Users entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public Users Get(long Id)
        {
            var use = _db.Users
                .SingleOrDefault(b => b.UsersId == Id);

            if(use == null)
            {
                return null; 
            }

            return use;
        }

        public IEnumerable<Users> GetAll()
        {
            if (_db != null)
            {
                return  _db.Users.ToList();
            }

            return null;
        }

        public IEnumerable<UsersView> GetAlViewModel()
        {
            throw new NotImplementedException();
           
        }

        public  async Task<UsersView> GetView(long Id)
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

        public void StudentPresentDates(Users entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Users entityToUpdate, Users entity)
        {
            entityToUpdate = _db.Users
                  .Include(a => a.Students)
                  .Include(a => a.Teachers)
                  .Include(a => a.Attendance)
                  .Single(b => b.UsersId == entityToUpdate.UsersId);

            entityToUpdate.Name = entity.Name;
            entityToUpdate.Role = entity.Role;


            //Students
            var deletedStudents = entityToUpdate.Students.Except(entity.Students).ToList();
            var addedStudents = entity.Students.Except(entityToUpdate.Students).ToList();

            deletedStudents.ForEach(usersToDelete =>
                entityToUpdate.Students.Remove(
                    entityToUpdate.Students
                        .First(b => b.StudentsId == usersToDelete.UsersId)));

            foreach (var addedStudent in addedStudents)
            {
                _db.Entry(addedStudents).State = EntityState.Added;
            }

            _db.SaveChanges();


            //Teachers
            var deletedTeachers = entityToUpdate.Teachers.Except(entity.Teachers).ToList();
            var addedTeachers = entity.Teachers.Except(entityToUpdate.Teachers).ToList();

            deletedTeachers.ForEach(usersToDelete =>
                entityToUpdate.Teachers.Remove(
                    entityToUpdate.Teachers
                        .First(b => b.TeachersId == usersToDelete.UsersId)));

            foreach (var addedTeacher in addedTeachers)
            {
                _db.Entry(addedTeachers).State = EntityState.Added;
            }

            _db.SaveChanges();


            //Attendance
            var deletedAttendance = entityToUpdate.Attendance.Except(entity.Attendance).ToList();
            var addedAttendance = entity.Attendance.Except(entityToUpdate.Attendance).ToList();

            deletedAttendance.ForEach(usersToDelete =>
                entityToUpdate.Attendance.Remove(
                    entityToUpdate.Attendance
                        .First(b => b.AttendanceId == usersToDelete.UsersId)));

            foreach (var addedAttendances in addedAttendance)
            {
                _db.Entry(addedAttendance).State = EntityState.Added;
            }

            _db.SaveChanges();

        }

        UsersView IRepositoryInterface<Users, UsersView>.GetView(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
