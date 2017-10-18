using MilenaSapunova.TerminateContracts.Web.Infrastructure;
using System;
using AutoMapper;
using MilenaSapunova.TerminateContracts.Model;
using System.ComponentModel.DataAnnotations;

namespace MilenaSapunova.TerminateContracts.Web.Areas.Administration.Models
{
    public class UserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(uvm => uvm.UserName, cfg => cfg.MapFrom(user => user.UserName))
                .ForMember(uvm => uvm.FirstName, cfg => cfg.MapFrom(user => user.FirstName))
                .ForMember(uvm => uvm.LastName, cfg => cfg.MapFrom(user => user.LastName))
                .ForMember(uvm => uvm.Email, cfg => cfg.MapFrom(user => user.Email))
                .ForMember(uvm => uvm.CreatedOn, cfg => cfg.MapFrom(user => user.CreatedOn));
        }
    }
}