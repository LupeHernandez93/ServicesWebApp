using AutoMapper;
using ServicesWebApp.Entities.SupplierWebApp;
//using ServicesWebApp.Helpers.SupplierWebApp.Supplier;

namespace ServicesWebApp.Interfaces.SupplierWebApp {
    public interface IPreSupplierRepository: IRepositoryBase<PreSupplier> {
        //public Task<PreSupplier> SaveAsync(int idPreSupplier, int idContact, int idTypeSupplier, string rfc, string name, string postalCode, string address, int interiorNumber, int exteriorNumber, int idCountry, int idState, int idMunicipality, int idLocation);

        //public Task<List<vtDocumentSupplier>> UploadDocumentsAsync(int idPreSupplier, List<IFormFile> files);

        //public Task<vtPreSupplier> GetViewAsync(int idPreSupplier);

        //public Task<DataSupplierView> GetDataViewAsync(int idPreSupplier);

        //public Task<PreSupplierTray> GetTrayAsync(List<int> idTypeSupplier, int idStatus, string description, DateTime startDate, DateTime endDate, int idPerson);

        //public Task<bool> SendToValidationAsync(int idPreSupplier, IMapper mapper);

        //public Task<bool> ActivateAsync(int idPreSupplier, List<int> branchCompanies, List<int> businessUnits, string validateReason, int idPerso);

        //public Task<bool> RejectedAsync(int idPreSupplier, string rejectedReason, int idPerson);

        //public Task<bool> ModifiedAsync(int idPreSupplier, string modifiedReason, int idPerson);

        //public Task<bool> ValidateAsync(int idPreSupplier, string validateReason, List<int> branchCompanies, List<int> businessUnits, int idPerson);
    }
}
