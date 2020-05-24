using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.services;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.services
{
   public class EFGroupService : IEFGroupService
    {


        IUnitOfWork _efUnitOfWork;
        private readonly IMapper _mapper;

        public EFGroupService(IUnitOfWork efUnitOfWork, IMapper mapper)
        {
            _efUnitOfWork = efUnitOfWork;
            _mapper = mapper;
        }
        

        public async Task<IEnumerable<GroupDTO>> GetAllGroups()
        {
            var x = await _efUnitOfWork.EFGroupRepository.GetAll();
            List<GroupDTO> res = new List<GroupDTO>();
            foreach (var i in x)
                res.Add(_mapper.Map<Group, GroupDTO>(i));

            return res;
        }

        public async Task<GroupDTO> GetGroupById(int Id)
        {
            var x = await _efUnitOfWork.EFGroupRepository.Get(Id);
            GroupDTO res = _mapper.Map<Group, GroupDTO>(x);

            return res;
        }

        public async Task AddGroup(GroupDTO group)
        {
            var x = _mapper.Map<GroupDTO, Group>(group);
            await _efUnitOfWork.EFGroupRepository.Add(x);
        }

        public async Task DeleteGroup(int Id)
        { await _efUnitOfWork.EFGroupRepository.Delete(Id); }

        public async Task UpdateGroup(GroupDTO group)
        {
            var x = _mapper.Map<GroupDTO, Group>(group);
            await _efUnitOfWork.EFGroupRepository.Update(x);
        }

       

    }
}
