using AutoMapper;
using ServicesWebApp.Entities.PortalWebApp;
using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Models;
using ServicesWebApp.Models.PortalWebApp;
using ServicesWebApp.Models.SupplierWebApp;

namespace ServicesWebApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<vtPerson, DtPerson>();            
            CreateMap<TokenApplication, DtTokenApplication>();
            CreateMap<CatTypeSupplier, DtTypeSupplier>();
            CreateMap<vtSupplier, DtSupplier>();
            CreateMap<vtInvoice, DtInvoice>();
            CreateMap<vtDocumentSupplier, DtDocumentSupplier>();

        }
    }
}
