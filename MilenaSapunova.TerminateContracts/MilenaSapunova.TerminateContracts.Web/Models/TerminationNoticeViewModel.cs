using AutoMapper;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Web.Areas.Administration.Models;
using MilenaSapunova.TerminateContracts.Web.Infrastructure;
using System;

namespace MilenaSapunova.TerminateContracts.Web.Models
{
    public class TerminationNoticeViewModel : IMapFrom<TerminationNotice>, IHaveCustomMappings
    {
        public CompanyViewModel Company { get; set; }

        public UserViewModel Owner { get; set; }

        public string Content { get; set; }

        public Guid Id { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<TerminationNotice, TerminationNoticeViewModel>()
                .ForMember(tvm => tvm.Id, cfg => cfg.MapFrom(t => t.Id))
                .ForMember(tvm => tvm.Content, cfg => cfg.MapFrom(t => t.Content))
                .ForMember(tvm => tvm.Owner, cfg => cfg.MapFrom(t => t.Owner))
                .ForMember(tvm => tvm.Company, cfg => cfg.MapFrom(t => t.Company));
        }
    }
}