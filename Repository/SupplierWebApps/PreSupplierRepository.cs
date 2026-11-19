using AutoMapper;
using ServicesWebApp.Entities.SupplierWebApp;
//using SupplierWebApp.Helpers.C5SupplierApp.Security;
using ServicesWebApp.Interfaces.SupplierWebApp;
using Microsoft.EntityFrameworkCore;
//using SupplierWebApp.Entities.C5PortalWebApp;
//using SupplierWebApp.Helpers.C5PortalWebApp;
//using SupplierWebApp.Helpers.C5SupplierApp.Supplier;
//using SupplierWebApp.Helpers.C5SupplierApp;
//using SupplierWebApp.Helpers.C5SupplierApp.Custom;
//using SupplierWebApp.Helpers.C5SupplierApp.Catalog;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class PreSupplierRepository: SupplierAppRepositoryBase<PreSupplier>, IPreSupplierRepository {
        private SupplierAppRepositoryContext _repositoryContext;
        public PreSupplierRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext) {
            _repositoryContext = repositoryContext;
        }

        //public async Task<PreSupplier> SaveAsync(int idPreSupplier, int idContact, int idTypeSupplier, string rfc, string name, string postalCode, string address, int interiorNumber, int exteriorNumber, int idCountry, int idState, int idMunicipality, int idLocation) {
        //    try {
        //        if (idPreSupplier == 0) {
        //            PreSupplier preSupplier = new PreSupplier();
        //            preSupplier.RFC = rfc;
        //            preSupplier.Name = name;
        //            preSupplier.PostalCode = postalCode;
        //            preSupplier.Address = address;
        //            preSupplier.InteriorNumber = (interiorNumber!=0 ? interiorNumber: null);
        //            preSupplier.ExteriorNumber = exteriorNumber;
        //            preSupplier.IdContact = idContact;
        //            preSupplier.IdCountry = idCountry;
        //            preSupplier.IdState = idState;
        //            preSupplier.IdCountry = idCountry;
        //            preSupplier.IdMunicipality = idMunicipality;
        //            preSupplier.IdLocation = idLocation;
        //            preSupplier.CreatedDate = DateTime.Now;
        //            preSupplier.IdStatus = (int)Enumerators.StatusPreSupplier.New;
        //            preSupplier.IdTypeSupplier = idTypeSupplier;

        //            _repositoryContext.Entry(preSupplier).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        //            await _repositoryContext.SaveChangesAsync();

        //            return preSupplier;
        //        }
        //        else {
        //            PreSupplier preSupplier = await _repositoryContext.PreSuppliers.SingleOrDefaultAsync(x => x.IdPreSupplier == idPreSupplier);
        //            preSupplier.RFC = rfc;
        //            preSupplier.Name = name;
        //            preSupplier.PostalCode = postalCode;
        //            preSupplier.Address = address;
        //            preSupplier.InteriorNumber = (interiorNumber != 0 ? interiorNumber : null); ;
        //            preSupplier.ExteriorNumber = exteriorNumber;
        //            preSupplier.IdContact = idContact;
        //            preSupplier.IdCountry = idCountry;
        //            preSupplier.IdState = idState;
        //            preSupplier.IdCountry = idCountry;
        //            preSupplier.IdMunicipality = idMunicipality;
        //            preSupplier.IdLocation = idLocation;
        //            preSupplier.ModifiedDate = DateTime.Now;
        //            preSupplier.IdStatus = (int)Enumerators.StatusPreSupplier.New;
        //            preSupplier.IdTypeSupplier = idTypeSupplier;

        //            _repositoryContext.Entry(preSupplier).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //            await _repositoryContext.SaveChangesAsync();

        //            return preSupplier;
        //        }
        //    }
        //    catch (Exception ex) {
        //        throw(ex);
        //    }
        //}

        //public async Task<List<vtDocumentSupplier>> UploadDocumentsAsync(int idPreSupplier, List<IFormFile> files) {
        //    try {
        //        AppSettings appSettings = new AppSettings();
        //        PreSupplier preSupplier = await _repositoryContext.PreSuppliers.SingleOrDefaultAsync(x=>x.IdPreSupplier == idPreSupplier);
        //        List<CatDocument> catDocuments = await _repositoryContext.CatDocuments.Where(x => x.Status == true).ToListAsync();
        //        foreach (IFormFile file in files) {
        //            if (file.Length > 0) {
                        
        //                string[] arrfileName = file.FileName.Split(".");
        //                string PhysicalDirectory = appSettings.PhysicalServerFolder + "PreSupplier" + "\\" + preSupplier.RFC + "\\";
        //                bool exists = System.IO.Directory.Exists(PhysicalDirectory);
        //                CatDocument document = catDocuments.SingleOrDefault(x => x.Key.Equals(arrfileName.First()));
        //                int version = _repositoryContext.DocumentSuppliers.Where(x => x.IdPreSupplier == idPreSupplier && x.IdDocument == document.IdDocument).Count() + 1;
        //                string currentFilename = arrfileName.First() + "_version_" + version + "." + arrfileName.Last();

        //                if (!exists)
        //                    System.IO.Directory.CreateDirectory(PhysicalDirectory);

        //                //Guardar archivo fisico y en base de datos
        //                using (var stream = File.Create(PhysicalDirectory + "\\" + currentFilename)) {
        //                    await file.CopyToAsync(stream);

        //                    DocumentSupplier documentSupplier = new DocumentSupplier();
        //                    documentSupplier.IdPreSupplier = idPreSupplier;
        //                    documentSupplier.IdDocument = document.IdDocument;
        //                    documentSupplier.IdStatus = (int)Enumerators.StatusPreSupplier.New;
        //                    documentSupplier.Length = file.Length;
        //                    documentSupplier.Path = appSettings.RelativeServerFolder + "PreSupplier" + "\\" + preSupplier.RFC + "\\";
        //                    documentSupplier.Extension = Path.GetExtension(file.FileName);
        //                    documentSupplier.FileName = currentFilename;
        //                    documentSupplier.CreatedDate = DateTime.Now;
        //                    documentSupplier.Version = version;

        //                    _repositoryContext.Entry(documentSupplier).State = EntityState.Added;
        //                    await _repositoryContext.SaveChangesAsync();
        //                }

        //                //Si existe un archivo de version anterior eliminarlo de forma logica
        //                if(version > 1) {
        //                    DocumentSupplier currentDocumentSupplier = await _repositoryContext.DocumentSuppliers.SingleOrDefaultAsync(x => x.IdPreSupplier == idPreSupplier && x.IdDocument == document.IdDocument && x.Version == (version-1));
        //                    if (currentDocumentSupplier != null) {
        //                        currentDocumentSupplier.IdStatus = (int)Enumerators.StatusPreSupplier.Deleted;
        //                        _repositoryContext.Entry(currentDocumentSupplier).State = EntityState.Modified;
        //                        await _repositoryContext.SaveChangesAsync();
        //                    }
        //                }

        //            }
        //        }

        //        return _repositoryContext.vtDocumentSuppliers.Where(x=>x.IdPreSupplier == idPreSupplier && x.IdStatus != (int)Enumerators.StatusPreSupplier.Deleted).ToList();
        //    }
        //    catch (Exception ex) {
        //        throw(ex);
        //    }
        //}

        //public async Task<vtPreSupplier> GetViewAsync(int idPreSupplier) {
        //    try {
        //        vtPreSupplier vtPreSupplier = await _repositoryContext.VtPreSuppliers.SingleOrDefaultAsync(x => x.IdPreSupplier == idPreSupplier);
        //        return vtPreSupplier;
        //    }
        //    catch (Exception ex) {
        //        throw(ex);
        //    }
        //}

        //public async Task<DataSupplierView> GetDataViewAsync(int idPreSupplier) {
        //    try {
        //        DataSupplierView dataSupplierView = new DataSupplierView();
        //        dataSupplierView.PreSupplier = await _repositoryContext.VtPreSuppliers.SingleOrDefaultAsync(x => x.IdPreSupplier == idPreSupplier);
        //        dataSupplierView.Contact = await _repositoryContext.VtContacts.SingleOrDefaultAsync(x => x.Username.Equals(dataSupplierView.PreSupplier.RFC)); ;
        //        dataSupplierView.DocumentSuppliers = await _repositoryContext.vtDocumentSuppliers.Where(x => x.IdPreSupplier == idPreSupplier && x.IdStatus != (int)Enumerators.StatusPreSupplier.Deleted).ToListAsync();

        //        Supplier currentSupplier = await _repositoryContext.Suppliers.SingleOrDefaultAsync(x=>x.RFC.Equals(dataSupplierView.PreSupplier.RFC));
        //        if(currentSupplier != null) {
        //            List<vtPerson> LPersons = (await PersonHelper.GetViewAll()).Where(x => x.IdTypeAccount == (int)Enumerators.TypeAccount.Supplier && x.IdSupplier == currentSupplier.IdSupplier && x.Email.ToLower().Equals(dataSupplierView.Contact.Email.ToLower())).ToList();
        //            if (LPersons.Count > 0) {
        //                int idPerson = LPersons.FirstOrDefault().IdPerson;
        //                dataSupplierView.BranchCompanies = (await PersonBranchCompanyHelper.GetVtListAsync(idPerson)).ToList();
        //                dataSupplierView.BusinessUnit = (await PersonBusinessUnitHelper.GetVtListAsync(idPerson)).ToList();
        //            }
        //        }
                
        //        return dataSupplierView;
        //    }
        //    catch (Exception ex) {
        //        throw (ex);
        //    }
        //}

        //public async Task<PreSupplierTray> GetTrayAsync(List<int> idTypeSupplier, int idStatus, string description, DateTime startDate, DateTime endDate, int idPerson) {
        //    try {
        //        PreSupplierTray preSupplierTray = new PreSupplierTray();
        //        List<DateTime> LDates = UtilityHelper.GetRangeDate(startDate, endDate);
        //        List<vtPreSupplier> LPreSuppliers = await _repositoryContext.VtPreSuppliers
        //            .Where(x => (x.IdStatus != (int)Enumerators.StatusPreSupplier.Deleted && x.IdStatus != (int)Enumerators.StatusPreSupplier.New) &&
        //                (idStatus !=0 ? x.IdStatus == idStatus: true) &&
        //                (idTypeSupplier.FirstOrDefault() !=0 ? idTypeSupplier.Contains(x.IdTypeSupplier): true) &&
        //                (x.ContactName.Contains(description) || x.PhoneNumberContact.Contains(description) || x.EmailContact.Contains(description) || x.RFC.Contains(description) || x.Name.Contains(description) || x.PostalCode.Contains(description)) &&
        //                LDates.Contains(EF.Property<DateTime>(x, "CreatedDate").Date)
        //            )
        //            .ToListAsync();

        //        preSupplierTray.PreSuppliers = new List<vtPreSupplier>();

        //        if (idStatus == (int)Enumerators.StatusPreSupplier.All)
        //            preSupplierTray.PreSuppliers = LPreSuppliers;
        //        else if (idStatus == (int)Enumerators.StatusPreSupplier.New)
        //            preSupplierTray.PreSuppliers = LPreSuppliers.Where(x => x.IdStatus == (int)Enumerators.StatusPreSupplier.New).ToList();
        //        else if (idStatus == (int)Enumerators.StatusPreSupplier.SendToValidation)
        //            preSupplierTray.PreSuppliers = LPreSuppliers.Where(x => x.IdStatus == (int)Enumerators.StatusPreSupplier.SendToValidation).ToList();
        //        else if (idStatus == (int)Enumerators.StatusPreSupplier.Modified)
        //            preSupplierTray.PreSuppliers = LPreSuppliers.Where(x => x.IdStatus == (int)Enumerators.StatusPreSupplier.Modified).ToList();
        //        else if (idStatus == (int)Enumerators.StatusPreSupplier.Validated)
        //            preSupplierTray.PreSuppliers = LPreSuppliers.Where(x => x.IdStatus == (int)Enumerators.StatusPreSupplier.Validated).ToList();
        //        else if (idStatus == (int)Enumerators.StatusPreSupplier.Rejected)
        //            preSupplierTray.PreSuppliers = LPreSuppliers.Where(x => x.IdStatus == (int)Enumerators.StatusPreSupplier.Rejected).ToList();

        //        preSupplierTray.Inbox = LPreSuppliers.Count();
        //        preSupplierTray.Sent = LPreSuppliers.Where(x => x.IdStatus == (int)Enumerators.StatusPreSupplier.SendToValidation).ToList().Count();
        //        preSupplierTray.Modified = LPreSuppliers.Where(x => x.IdStatus == (int)Enumerators.StatusPreSupplier.Modified).ToList().Count();
        //        preSupplierTray.Validated = LPreSuppliers.Where(x => x.IdStatus == (int)Enumerators.StatusPreSupplier.Validated).ToList().Count();
        //        preSupplierTray.Rejected = LPreSuppliers.Where(x => x.IdStatus == (int)Enumerators.StatusPreSupplier.Rejected).ToList().Count();

        //        return preSupplierTray;
        //    }
        //    catch (Exception ex) {
        //        throw (ex);
        //    }
        //}

        //public async Task<bool> SendToValidationAsync(int idPreSupplier, IMapper mapper) {
        //    try {
        //        PreSupplier preSupplier = await _repositoryContext.PreSuppliers.SingleOrDefaultAsync(x => x.IdPreSupplier == idPreSupplier);

        //        preSupplier.IdStatus = (int)Enumerators.StatusPreSupplier.SendToValidation;
        //        preSupplier.SendToValidationDate = DateTime.Now;
        //        if(preSupplier.ValidationDate == null) {
        //            preSupplier.RequireModificationBy = null;
        //            preSupplier.RequireModificationDate = null;
        //            preSupplier.RequireModificationReason = null;
        //            preSupplier.ValidationBy = null;
        //            preSupplier.ValidationDate = null;
        //            preSupplier.ValidationReason = null;
        //            preSupplier.RejectedBy = null;
        //            preSupplier.RejectedDate = null;
        //            preSupplier.RejectedReason = null;
        //        }
                
        //        _repositoryContext.Entry(preSupplier).State = EntityState.Modified;
        //        await _repositoryContext.SaveChangesAsync();

        //        bool response = await PreSupplierHelper.SendToValidateEmailAsync(idPreSupplier, mapper);

        //        return response;
        //    }
        //    catch (Exception ex) {

        //        throw(ex);
        //    }
        //}

        //public async Task<bool> ActivateAsync(int idPreSupplier, List<int> branchCompanies, List<int> businessUnits, string validateReason, int idPerson) {
        //    try {
        //        AppSettings appSettings = new AppSettings();
        //        PreSupplier preSupplier = await _repositoryContext.PreSuppliers.SingleOrDefaultAsync(x => x.IdPreSupplier == idPreSupplier);
        //        Contact contact = await _repositoryContext.Contacts.SingleOrDefaultAsync(x => x.Username.Equals(preSupplier.RFC));
        //        Supplier supplier = await SupplierHelper.CreateAsync(preSupplier);
        //        bool responsePreSupplier = supplier != null ? await PreSupplierHelper.ActivateAsync(idPreSupplier, idPerson, validateReason) : false;
        //        bool responseContact = responsePreSupplier ? await ContactHelper.ActivateAsync(preSupplier.RFC) : false;
        //        bool responsePersonSupplier = responseContact ? await PersonHelper.CreateBySupplier(contact, supplier, branchCompanies, businessUnits) : false;

        //        if(responsePersonSupplier) {
        //            //Agregar las sucursales y las unidades de negocio donde se podra buscar al proveedor
        //            foreach (int idBranchCompany in branchCompanies) {
        //                foreach (int idBusinessUnit in businessUnits) {
        //                    CompanySupplier companySupplier = new CompanySupplier();
        //                    companySupplier.IdCompany = appSettings.Configuration.PrincipalIdCompany.Value;
        //                    companySupplier.IdBranchCompany = idBranchCompany;
        //                    companySupplier.IdBusinessUnit = idBusinessUnit;
        //                    companySupplier.IdSupplier = supplier.IdSupplier;
        //                    _repositoryContext.Entry(companySupplier).State = EntityState.Added;
        //                    await _repositoryContext.SaveChangesAsync();
        //                }
        //            }
        //        }

        //        return true;
        //    }
        //    catch (Exception ex) {

        //        throw (ex);
        //    }
        //}

        //public async Task<bool> RejectedAsync(int idPreSupplier, string rejectedReason, int idPerson) {
        //    try {

        //        PreSupplier preSupplier = await _repositoryContext.PreSuppliers.SingleOrDefaultAsync(x => x.IdPreSupplier == idPreSupplier);
        //        preSupplier.IdStatus = (int)Enumerators.StatusPreSupplier.Rejected;
        //        preSupplier.RejectedBy = idPerson;
        //        preSupplier.RejectedDate = DateTime.Now;
        //        preSupplier.RejectedReason = rejectedReason;
        //        _repositoryContext.Entry(preSupplier).State = EntityState.Modified;
        //        await _repositoryContext.SaveChangesAsync();

        //        bool response = await PreSupplierHelper.RejectedPreSupplierAsync(idPreSupplier);

        //        return response;
        //    }
        //    catch (Exception ex) {

        //        throw (ex);
        //    }
        //}

        //public async Task<bool> ModifiedAsync(int idPreSupplier, string modifiedReason, int idPerson) {
        //    try {

        //        PreSupplier preSupplier = await _repositoryContext.PreSuppliers.SingleOrDefaultAsync(x => x.IdPreSupplier == idPreSupplier);
        //        preSupplier.IdStatus = (int)Enumerators.StatusPreSupplier.Modified;
        //        preSupplier.RequireModificationBy = idPerson;
        //        preSupplier.RequireModificationDate = DateTime.Now;
        //        preSupplier.RequireModificationReason = modifiedReason;
        //        _repositoryContext.Entry(preSupplier).State = EntityState.Modified;
        //        await _repositoryContext.SaveChangesAsync();

        //        bool response = await PreSupplierHelper.ModifiedPreSupplierAsync(idPreSupplier);

        //        return response;
        //    }
        //    catch (Exception ex) {

        //        throw (ex);
        //    }
        //}

        //public async Task<bool> ValidateAsync(int idPreSupplier, string validateReason, List<int> branchCompanies, List<int> businessUnits, int idPerson) {
        //    try {
        //        bool response = false;

        //        response = await this.ActivateAsync(idPreSupplier, branchCompanies, businessUnits, validateReason, idPerson);
        //        if(response) 
        //            response = await PreSupplierHelper.ValidatePreSupplierAsync(idPreSupplier);

        //        return response;
        //    }
        //    catch (Exception ex) {

        //        throw (ex);
        //    }
        //}

    }
}
