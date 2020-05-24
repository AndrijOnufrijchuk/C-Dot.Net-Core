using DataAccessLayer.Interfaces.IEFRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IEFGroupRepo EFGroupRepository { get; }
        IEFStudentRepo EFStudentRepository { get; }
      

        void Complete();
    }
}
