using AutoMapper;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Web.Infrastructure;

namespace MilenaSapunova.TerminateContracts.Web.Models
{
    public class CompanyViewModel : IMapFrom<Company>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Town { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Company, CompanyViewModel>()
                .ForMember(cvm => cvm.Name, cfg => cfg.MapFrom(c => c.Name))
                .ForMember(cvm => cvm.PhoneNumber, cfg => cfg.MapFrom(c => c.PhoneNumber))
                .ForMember(cvm => cvm.Email, cfg => cfg.MapFrom(c => c.Email))
                .ForMember(cvm => cvm.Address, cfg => cfg.MapFrom(c => c.Address.Name))
                .ForMember(cvm => cvm.Town, cfg => cfg.MapFrom(c => c.Address.Town.Name))
                .ForMember(cvm => cvm.PostalCode, cfg => cfg.MapFrom(c => c.Address.Town.PostalCode))
                .ForMember(cvm => cvm.Country, cfg => cfg.MapFrom(c => c.Address.Town.Country.Name));
        }
    }
}