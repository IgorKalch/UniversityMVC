using AutoMapper;
using UniversityApplication.CQRSModuels.Groups.Commands.Create;
using UniversityApplication.CQRSModuels.Groups.Commands.Delete;
using UniversityApplication.CQRSModuels.Groups.Commands.Edit;
using UniversityApplication.DTOs;
using UniversityDataLayer.Entities;

namespace UniversityApplication.Mapping
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {

            CreateMap<GroupDTO, CreateGroupCommand>();            

            CreateMap<CreateGroupCommand , GroupDTO>();

            CreateMap<GroupDTO, Group>();

            CreateMap<Group, GroupDTO>();

            CreateMap<Group, DeleteGroupCommand>();

            CreateMap<Group, EditGroupCommand>();
        }
    }
}
