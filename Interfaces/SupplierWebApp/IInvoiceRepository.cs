using AutoMapper;
using ServicesWebApp.Entities.SupplierWebApp;
//using ServicesWebApp.Helpers.SupplierWebApp.Invoice;
using Microsoft.AspNetCore.Mvc;

namespace ServicesWebApp.Interfaces.SupplierWebApp
{
    public interface IInvoiceRepository: IRepositoryBase<Invoice>
    {
        //public Task<List<UploadResult>> CreateAsync(List<IFormFile> files, int idPerson, int idBranchCompany, int idBusinessUnit);

        //public Task<TrayCollaborator> SearchAsync(List<int> idStatus, List<int> idCompanies, List<int>idSuppliers, List<int> idBusinessUnits, List<int> idBranchCompanies, List<string> idMoney, List<int> paymentReceipt, string Description, DateTime StartDate, DateTime EndDate, bool onlyMyInvoices, int idPerson);

        //public Task<TrayCollaborator> SearchAsync(List<int> idStatus, List<int> idSuppliers, List<int> idBusinessUnits, List<int> idBranchCompanies, List<string> idMoney, List<int> rep, string Description, DateTime startDate, DateTime endDate, bool onlyMyInvoices, int idPerson);

        //public Task<vtInvoice> Upload(string uuid, IFormFile invoiceFile, IFormFile suportFile, string jsonPurchaseOrder, int idPerson, IMapper mapper);

        //public Task<vtInvoice> GetAsync(int idInvoice);

        //public Task<List<vtInvoice>> GetListAsync(string keyID);

        //public Task<List<ItemsCfdi>> GetItemsAsync(int idInvoice);

        //public Task<List<TaxesCfdi>> GetTaxesAsync(int idInvoice);

        //public Task<List<InvoiceAttachment>> GetAttachmentsAsync(int idInvoice);

        //public Task<string> GetViewPurchaseOrderAsync(int idInvoice);

        //public Task<bool> UpdateStatusAsync(int idInvoice, int idStatus, string reasonStatus, IFormFile cepFileXML, IFormFile cepFilePDF, decimal amountPaid, string currency, decimal exchangeRate, int idPerson);

        //public Task<bool> UploadREPAsync(int idInvoice, IFormFile repFileXML, IFormFile repFilePDF, int idPerson);

        //public Task<bool> UpdateOCAsync(string uuid, string jsonPurchaseOrder);

        public Task<List<vtInvoice>> GetInvoiceDateApiAsync(DateTime DateStart, DateTime DateEnd);

        public Task<List<vtInvoice>> GetInvoiceCreatedAsync(DateTime DateStart, DateTime DateEnd);
    }
}
