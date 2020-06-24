using FinalGPTWBackendProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalGPTWBackendProject.Repository
{
    interface IRepositoryInterface <TEntity , TViewModel>
    {

        IEnumerable<TEntity> GetAll();

        TEntity Get(long Id);

        TViewModel GetView(long Id);

        IEnumerable<TViewModel> GetAlViewModel();

        void Add(TEntity entity);
        void Update(TEntity entityToUpdate, TEntity entity);

        void Delete(TEntity entity);

      




    }
}
