using AutoMapper;

namespace MilenaSapunova.TerminateContracts.Web.Infrastructure
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}

