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
    public class AttendanceImplementInterface : IRepositoryInterface<Attendance, AttendanceView>
    {


        FinalGPTWBackendProjectContext _db;
        public AttendanceImplementInterface(FinalGPTWBackendProjectContext db)
        {
            _db = db;
        }

        public void Add(Attendance entity)
        {
            _db.Attendance.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Attendance entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public Attendance Get(long Id)
        {
            var use = _db.Attendance
                 .SingleOrDefault(b => b.AttendanceId == Id);

            if (use == null)
            {
                return null;
            }

            return use;
        }

        public IEnumerable<Attendance> GetAll()
        {
            if (_db != null)
            {
                return _db.Attendance.ToList();
            }

            return null;
        }

        public IEnumerable<AttendanceView> GetAlViewModel()
        {
            throw new NotImplementedException();
        }

       

        public void StudentPresentDates(Attendance entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Attendance entityToUpdate, Attendance entity)
        {
            throw new NotImplementedException();
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

        AttendanceView IRepositoryInterface<Attendance, AttendanceView>.GetView(long Id)
        {
            throw new NotImplementedException();
        }

      
       
    }
}
