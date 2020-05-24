using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.services
{
    public interface IEFGroupService
    {
        

        Task AddGroup(GroupDTO group);

        Task UpdateGroup(GroupDTO group);

        Task DeleteGroup(int Id);

        Task<GroupDTO> GetGroupById(int Id);

        Task<IEnumerable<GroupDTO>> GetAllGroups();

      


    }
}
