using ServicesWebApp.Entities.SupplierWebApp;
//using SupplierWebApp.Helpers;
using ServicesWebApp.Interfaces.SupplierWebApp;
using Microsoft.EntityFrameworkCore;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class DocumentSupplierRepository : SupplierAppRepositoryBase<vtDocumentSupplier>, IDocumentSupplierRepository {
        private SupplierAppRepositoryContext _repositoryContext;
        public DocumentSupplierRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext) {
            _repositoryContext = repositoryContext;
        }

        //public async Task<bool> UpdateStatusAsync(int idDocumentSupplier, int idStatus, int idPerson) {
        //    try {
        //        DocumentSupplier documentSupplier = await _repositoryContext.DocumentSuppliers.SingleOrDefaultAsync(x => x.IdDocumentSupplier == idDocumentSupplier);
        //        if (documentSupplier != null) {
        //            if(idStatus == 0) {
        //                documentSupplier.IdStatus = (int)Enumerators.StatusPreSupplier.SendToValidation;
        //                documentSupplier.ValidationBy = null;
        //                documentSupplier.ValidationDate = null;
        //                documentSupplier.ModifiedRequestBy = null;
        //                documentSupplier.ModifiedRequestDate = null;
        //                documentSupplier.ModifiedRequestReason = null;
        //                documentSupplier.RejectedBy = null;
        //                documentSupplier.RejectedDate = null;
        //                documentSupplier.RejectedReason = null;
        //                _repositoryContext.Entry(documentSupplier).State = EntityState.Modified;
        //                await _repositoryContext.SaveChangesAsync();
        //            }
        //            else if (idStatus == (int)Enumerators.StatusPreSupplier.Validated) {
        //                documentSupplier.ValidationBy = idPerson;
        //                documentSupplier.ValidationDate = DateTime.Now;
        //                documentSupplier.IdStatus = (int)Enumerators.StatusPreSupplier.Validated;
        //                documentSupplier.ModifiedRequestBy = null;
        //                documentSupplier.ModifiedRequestDate = null;
        //                documentSupplier.ModifiedRequestReason = null;
        //                documentSupplier.RejectedBy = null;
        //                documentSupplier.RejectedDate = null;
        //                documentSupplier.RejectedReason = null;
        //                _repositoryContext.Entry(documentSupplier).State = EntityState.Modified;
        //                await _repositoryContext.SaveChangesAsync();
        //            }
        //            else if (idStatus == (int)Enumerators.StatusPreSupplier.Modified) {
        //                documentSupplier.ModifiedRequestBy = idPerson;
        //                documentSupplier.ModifiedRequestDate = DateTime.Now;
        //                documentSupplier.ModifiedRequestReason = "Requiere modificación";
        //                documentSupplier.IdStatus = (int)Enumerators.StatusPreSupplier.Modified;
        //                documentSupplier.ValidationBy = null;
        //                documentSupplier.ValidationDate = null;
        //                documentSupplier.RejectedBy = null;
        //                documentSupplier.RejectedDate = null;
        //                documentSupplier.RejectedReason = null;
        //                _repositoryContext.Entry(documentSupplier).State = EntityState.Modified;
        //                await _repositoryContext.SaveChangesAsync();
        //            }
        //            else if (idStatus == (int)Enumerators.StatusPreSupplier.Rejected) {
        //                documentSupplier.RejectedBy = idPerson;
        //                documentSupplier.RejectedDate = DateTime.Now;
        //                documentSupplier.RejectedReason = "Rechazado a nivel general";
        //                documentSupplier.IdStatus = (int)Enumerators.StatusPreSupplier.Rejected;
        //                documentSupplier.ValidationBy = null;
        //                documentSupplier.ValidationDate = null;
        //                documentSupplier.ModifiedRequestBy = null;
        //                documentSupplier.ModifiedRequestDate = null;
        //                documentSupplier.ModifiedRequestReason = null;
        //                _repositoryContext.Entry(documentSupplier).State = EntityState.Modified;
        //                await _repositoryContext.SaveChangesAsync();
        //            }
        //        }

        //        return true;
        //    }
        //    catch (Exception ex) {
        //        throw new Exception(ex.Message, ex.InnerException);
        //    }
        //}
    }
}
