
using Microsoft.EntityFrameworkCore;
using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class InvoiceAttachmentPPDRepository : SupplierAppRepositoryBase<InvoiceAttachmentPPD>, IInvoiceAttachmentPPDRepository
    {
        private SupplierAppRepositoryContext _repositoryContext;
        public InvoiceAttachmentPPDRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        //public async Task<vtInvoiceAttachmentPPD> GetView(int idAttachmentPPD)
        //{
        //    try
        //    {
        //        return await _repositoryContext.VtInvoiceAttachmentPPDs.SingleOrDefaultAsync(x => x.IdAttachmentPPD == idAttachmentPPD);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw(ex);
        //    }
        //}

        //public async Task<List<vtInvoiceAttachmentPPD>> GetAllAsync(int idInvoice, string type)
        //{
        //    try
        //    {
        //        return await _repositoryContext.VtInvoiceAttachmentPPDs.Where(x => x.IdInvoice == idInvoice && x.Type.Equals(type)).OrderBy(x=>x.CreatedDate).ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw(ex);
        //    }
        //}
    }
}
