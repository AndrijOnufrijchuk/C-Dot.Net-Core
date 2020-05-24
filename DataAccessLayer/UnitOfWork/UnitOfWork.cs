using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IEFRepos;

namespace DataAccessLayer.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly IEFGroupRepo _EFGroupRepository;
      
        private readonly IEFStudentRepo _EFStudentRepository;

      

        public EFUnitOfWork(IEFGroupRepo eFGroupRepo, IEFStudentRepo eFStudentRepo) {
            _EFGroupRepository = eFGroupRepo;
            _EFStudentRepository = eFStudentRepo;


        }
        public IEFGroupRepo EFGroupRepository
        {
            get { return _EFGroupRepository; }
        }
        public IEFStudentRepo EFStudentRepository
        {
            get { return _EFStudentRepository; }
        }


        public void Complete()
        {  }

      
    }
}
