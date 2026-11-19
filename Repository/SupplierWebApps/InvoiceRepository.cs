using AutoMapper;
using ServicesWebApp.Entities.SupplierWebApp;
//using SupplierWebApp.Helpers.C5SupplierApp.Invoice;
using ServicesWebApp.Interfaces.SupplierWebApp;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using System.Xml.Linq;
//using SupplierWebApp.Helpers.C5SupplierApp.Catalog;
//using SupplierWebApp.Helpers.C5SupplierApp;
//using SupplierWebApp.Entities.C5PortalWebApp;
//using SupplierWebApp.Helpers.C5PortalWebApp;
//using SupplierWebApp.Helpers.C5SupplierApp.Supplier;
//using SupplierWebApp.Enumerators;
//using SupplierWebApp.Entities.C5SupplierApp.SAE;
//using SupplierWebApp.Repository.SAE;
using System.Text.Json;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class InvoiceRepository : SupplierAppRepositoryBase<Invoice>, IInvoiceRepository
    {
        private readonly SupplierAppRepositoryContext _repositoryContext;
        public InvoiceRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public async Task<List<vtInvoice>> GetInvoiceDateApiAsync(DateTime DateStart, DateTime DateEnd)
        {
            try
            {
                return await _repositoryContext.vtInvoices.Where(x => x.InvoiceDate >= DateStart.Date && (x.InvoiceDate <= DateEnd.Date)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<List<vtInvoice>> GetInvoiceCreatedAsync(DateTime DateStart, DateTime DateEnd)
        {
            try
            {
                return await _repositoryContext.vtInvoices.Where(x => x.CreatedDate >= DateStart.Date && (x.CreatedDate <= DateEnd.Date)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public async Task<List<UploadResult>> CreateAsync(List<IFormFile> files, int idPerson, int idBranchCompany, int idBusinessUnit)
        //{
        //    try
        //    {
        //        AppSettings appSettings = new AppSettings();
        //        List<UploadResult> uploadResults = new List<UploadResult>();
        //        vtPerson person = await PersonHelper.GetViewAsync(idPerson);
        //        string rfcSupplier = person.IdSupplier != null ? (await SupplierHelper.GetViewAsync(person.IdSupplier.Value)).RFC: person.CompanyRFC;

        //        foreach(IFormFile file in files.OrderByDescending(x=>x.ContentType))
        //        {
        //            Invoice invoice = new Invoice();
        //            if (file.ContentType.ToLower().Equals("text/xml"))
        //            {
        //                //Obtener el documento xml
        //                XmlDocument xDocument = await InvoiceHelper.GetFileXMLAsync(file);
        //                //Cargar los nodos requeridos del xml
        //                InvoiceCfdi invoiceCfdi = new InvoiceCfdi(xDocument.OuterXml);
        //                string pathServerFolder = rfcSupplier.ToUpper() + "\\" + invoiceCfdi.Fecha.Year.ToString();
        //                string UUID = invoiceCfdi.TimbreFiscal.Attributes["UUID"].Value;

        //                //Comprobar que no existe en la tabla el UUID
        //                if (_repositoryContext.Invoices.Count(x => x.UUID.Equals(UUID)) ==0)
        //                {
        //                    //Cargar los atributos xml al objeto de tabla
        //                    invoice.IdPerson = idPerson;
        //                    invoice.IdCompany = appSettings.Configuration.PrincipalIdCompany.Value;

        //                    /*
        //                    if (person.IdTypeAccount == (int)TypeAccount.Collaborator)
        //                        invoice.IdCompany = person.IdCompany.Value;
        //                    */

        //                    invoice.IdBranchCompany = idBranchCompany;
        //                    invoice.IdBusinessUnit = idBusinessUnit;
        //                    invoice.IdStatus = (int)SupplierWebApp.Enumerators.StatusInvoice.Pending;
        //                    invoice.UUID = UUID;
        //                    if (invoiceCfdi.Comprobante.Attributes["Serie"] != null)
        //                        invoice.Serie = invoiceCfdi.Comprobante.Attributes["Serie"].Value;
        //                    else
        //                        invoice.Serie = null;
        //                    if (invoiceCfdi.Comprobante.Attributes["Folio"] != null)
        //                        invoice.Folio = invoiceCfdi.Comprobante.Attributes["Folio"].Value;
        //                    else
        //                        invoice.Folio = null;
        //                    invoice.InvoiceDate = Convert.ToDateTime(invoiceCfdi.Comprobante.Attributes["Fecha"].Value);
        //                    invoice.CreatedDate = DateTime.Now;
        //                    invoice.SubTotal = Convert.ToDecimal(invoiceCfdi.Comprobante.Attributes["SubTotal"].Value ?? "");
        //                    invoice.Discount = Convert.ToDecimal(invoiceCfdi.Comprobante.Attributes["Descuento"]!= null ? invoiceCfdi.Comprobante.Attributes["Descuento"] .Value: 0);
        //                    invoice.Total = Convert.ToDecimal(invoiceCfdi.Comprobante.Attributes["Total"].Value ?? "");
        //                    if (invoiceCfdi.Comprobante.Attributes["TipoCambio"] != null)
        //                        invoice.ExchangeRate = Convert.ToDecimal(invoiceCfdi.Comprobante.Attributes["TipoCambio"].Value);
        //                    else
        //                        invoice.ExchangeRate = 1;

        //                    invoice.Currency = (invoiceCfdi.Comprobante.Attributes["Moneda"].Value ?? "");
        //                    invoice.IdReceiptType = (invoiceCfdi.Comprobante.Attributes["TipoDeComprobante"].Value ?? "");
        //                    invoice.IdPaymentMethod = (invoiceCfdi.Comprobante.Attributes["MetodoPago"].Value ?? "");

        //                    if (invoiceCfdi.Comprobante.Attributes["CondicionesDePago"] != null)
        //                        invoice.PaymentTerms = invoiceCfdi.Comprobante.Attributes["CondicionesDePago"].Value;
        //                    else
        //                        invoice.PaymentTerms = null;

        //                    if (invoiceCfdi.Comprobante.Attributes["Exportacion"] != null)
        //                        invoice.IdExport = invoiceCfdi.Comprobante.Attributes["Exportacion"].Value;
        //                    else
        //                        invoice.IdExport = null;

        //                    if (invoiceCfdi.Comprobante.Attributes["LugarExpedicion"] != null)
        //                        invoice.PlaceExpedition = invoiceCfdi.Comprobante.Attributes["LugarExpedicion"].Value;
        //                    else
        //                        invoice.PlaceExpedition = null;

        //                    invoice.Emitter_RFC = (invoiceCfdi.Emisor.Attributes["Rfc"].Value ?? "");
        //                    invoice.Emitter_Name = (invoiceCfdi.Emisor.Attributes["Nombre"].Value ?? "");

        //                    if (invoiceCfdi.Emisor.Attributes["RegimenFiscal"] != null)
        //                        invoice.Emitter_IdFiscalRegime = invoiceCfdi.Emisor.Attributes["RegimenFiscal"].Value;
        //                    else
        //                        invoice.Emitter_IdFiscalRegime = null;

        //                    invoice.Receptor_RFC = (invoiceCfdi.Receptor.Attributes["Rfc"].Value ?? "");
        //                    invoice.Receptor_Name = (invoiceCfdi.Receptor.Attributes["Nombre"].Value ?? "");

        //                    if (invoiceCfdi.Receptor.Attributes["DomicilioFiscalReceptor"] != null)
        //                        invoice.Receptor_TaxDomicile = invoiceCfdi.Receptor.Attributes["DomicilioFiscalReceptor"].Value;
        //                    else
        //                        invoice.Receptor_TaxDomicile = null;

        //                    if (invoiceCfdi.Receptor.Attributes["RegimenFiscalReceptor"] != null)
        //                        invoice.Receptor_IdFiscalRegime = invoiceCfdi.Receptor.Attributes["RegimenFiscalReceptor"].Value;
        //                    else
        //                        invoice.Receptor_IdFiscalRegime = null;

        //                    if (invoiceCfdi.Receptor.Attributes["UsoCFDI"] != null)
        //                        invoice.Receptor_IdUseCFDI = invoiceCfdi.Receptor.Attributes["UsoCFDI"].Value;
        //                    else
        //                        invoice.Receptor_IdUseCFDI = null;

        //                    invoice.PurchaseOrder = null;
        //                    invoice.Comments = null;
        //                    invoice.Version = invoiceCfdi.version;

        //                    //Nuevo nombre final del archivo RFC_EMISOR + AÑO + MES + DIA + SERIE + FOLIO
        //                    string xmlNewFilename = invoice.Emitter_RFC + "-" + invoice.InvoiceDate.ToString("yyyy") + invoice.InvoiceDate.ToString("MM") + invoice.InvoiceDate.ToString("dd") + "-" + invoice.Serie + invoice.Folio + ".xml";

        //                    //Guardar archivo xml
        //                    if (file != null)
        //                    {
        //                        bool exists = System.IO.Directory.Exists(appSettings.PhysicalServerFolder + "\\" + pathServerFolder);

        //                        //Comprobar si existe el directorio
        //                        if (!exists)
        //                            System.IO.Directory.CreateDirectory(appSettings.PhysicalServerFolder + "\\" + pathServerFolder);

        //                        //Crear el archivo xml y guadar su contenido
        //                        using (var stream = System.IO.File.Create(appSettings.PhysicalServerFolder + "\\" + pathServerFolder + "\\" + xmlNewFilename))
        //                        {
        //                            await file.CopyToAsync(stream);

        //                            invoice.XML_OriginalFileName = file.FileName;
        //                            invoice.XML_FileName = xmlNewFilename;
        //                            invoice.XML_Length = file.Length;
        //                            invoice.XML_Path = appSettings.RelativeServerFolder + pathServerFolder + "\\";
        //                            invoice.XML_Content = XElement.Parse(xDocument.OuterXml);
        //                        }
        //                    }

        //                    //Guardar el objeto en la base de datos
        //                    _repositoryContext.Entry(invoice).State = EntityState.Added;
        //                    await _repositoryContext.SaveChangesAsync();

        //                    //Agrear la referencia de carga
        //                    uploadResults.Add(new UploadResult {
        //                        IdInvoice = invoice.IdInvoice,
        //                        UUID = UUID,
        //                        EmitterRFC = invoice.Emitter_RFC,
        //                        EmitterName = invoice.Emitter_Name,
        //                        Filename = file.FileName,
        //                        Serie = invoice.Serie,
        //                        Folio = invoice.Folio,
        //                        SupportXMLFile = xmlNewFilename,
        //                        SupportPath = appSettings.RelativeServerFolder + pathServerFolder + "\\",
        //                        SupportPDFFile = "",
        //                        InvoiceDate = invoice.InvoiceDate,
        //                        TotalInvoice = invoice.Total,
        //                        TypeFile = file.ContentType,
        //                        Version = invoice.Version,
        //                        CreatedDate = DateTime.Now,
        //                        Description = "Cargado con éxito",
        //                        Status = true
        //                    });

        //                }
        //                else
        //                {
        //                    //Agrear la referencia de carga
        //                    uploadResults.Add(new UploadResult
        //                    {
        //                        IdInvoice =0,
        //                        UUID = UUID,
        //                        EmitterRFC = invoice.Emitter_RFC,
        //                        EmitterName = invoice.Emitter_Name,
        //                        Filename = file.FileName,
        //                        Serie = invoice.Serie,
        //                        Folio = invoice.Folio,
        //                        SupportXMLFile = file.FileName,
        //                        SupportPath = appSettings.RelativeServerFolder + pathServerFolder + "\\",
        //                        SupportPDFFile = "",
        //                        InvoiceDate = invoice.InvoiceDate,
        //                        TotalInvoice = invoice.Total,
        //                        TypeFile = file.ContentType,
        //                        Version = invoiceCfdi.version,
        //                        CreatedDate = DateTime.Now,
        //                        Description = "El comprobante ya existe en la base de datos",
        //                        Status = false
        //                    });
        //                }

        //            }
        //            else if (file.ContentType.ToLower().Equals("application/pdf"))
        //            {
        //                string pdfFilename = file.FileName.ToLower().Replace(".pdf", "");
        //                string UUID = "";

        //                if (files.Count() > 1)
        //                {
        //                    //MultiFiles
        //                    foreach (IFormFile xmlFile in files.Where(x => x.ContentType.ToLower().Equals("text/xml")))
        //                    {
        //                        string xmlFilename = xmlFile.FileName.Replace(".xml", "");

        //                        if (xmlFilename.ToUpper().Equals(pdfFilename.ToUpper()))
        //                        {
        //                            //Obtener el documento xml
        //                            XmlDocument xDocument = await InvoiceHelper.GetFileXMLAsync(xmlFile);
        //                            //Cargar los nodos requeridos del xml para obtener el UUID
        //                            InvoiceCfdi invoiceCfdi = new InvoiceCfdi(xDocument.OuterXml);
        //                            UUID = invoiceCfdi.UUID;

        //                            //Buscar el registro en la base
        //                            Invoice pdfInvoice = _repositoryContext.Invoices.SingleOrDefault(x => x.UUID.Equals(UUID));
        //                            string pdfNewFilename = pdfInvoice.XML_FileName.ToUpper().Replace(".xml", "") + ".pdf";

        //                            //Guardar los datos del pdf
        //                            if (pdfInvoice.PDF_FileName == null)
        //                            {
        //                                string pathServerFolder = rfcSupplier.ToUpper() + "\\" + invoiceCfdi.Fecha.Year.ToString();
        //                                //Crear el archivo xml y guadar su contenido
        //                                using (var stream = System.IO.File.Create(appSettings.PhysicalServerFolder + "\\" + pathServerFolder + "\\" + pdfNewFilename))
        //                                {
        //                                    await file.CopyToAsync(stream);

        //                                    pdfInvoice.PDF_FileName = pdfNewFilename;
        //                                    pdfInvoice.PDF_Length = file.Length;
        //                                    pdfInvoice.PDF_Path = pdfInvoice.XML_Path;
        //                                    pdfInvoice.PDF_CreatedDate = DateTime.Now;
        //                                    _repositoryContext.Entry(pdfInvoice).State = EntityState.Modified;
        //                                    await _repositoryContext.SaveChangesAsync();
        //                                }

        //                                //Agrear la referencia de carga
        //                                uploadResults.Add(new UploadResult
        //                                {
        //                                    UUID = pdfInvoice.UUID,
        //                                    EmitterName = pdfInvoice.Emitter_Name,
        //                                    Filename = file.FileName,
        //                                    SupportPDFFile = pdfNewFilename,
        //                                    TypeFile = file.ContentType,
        //                                    Version = invoiceCfdi.version,
        //                                    CreatedDate = DateTime.Now,
        //                                    Description = "Cargado con éxito",
        //                                    Status = true
        //                                });

        //                                break;
        //                            }
        //                            else
        //                            {
        //                                //No sepuede cargar el pdf, ya existe un documento
        //                                uploadResults.Add(new UploadResult
        //                                {
        //                                    UUID = "",
        //                                    EmitterName = "",
        //                                    Filename = file.FileName,
        //                                    SupportPDFFile = file.FileName,
        //                                    TypeFile = file.ContentType,
        //                                    Version = "",
        //                                    CreatedDate = DateTime.Now,
        //                                    Description = "No sepuede cargar el pdf por que ya existe",
        //                                    Status = false
        //                                });
        //                            }

        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    //SingleFile
        //                    Invoice tempInvoice = await _repositoryContext.Invoices.SingleOrDefaultAsync(x => (x.XML_FileName.Contains(pdfFilename) ||x.XML_OriginalFileName.Contains(pdfFilename) || x.UUID.Contains(pdfFilename)) && x.IdBranchCompany == idBranchCompany && x.IdBusinessUnit == x.IdBusinessUnit);
        //                    if (tempInvoice != null)
        //                    {
        //                        //Obtener el documento xml
        //                        XmlDocument xDocument = InvoiceHelper.GetXML(tempInvoice.XML_Content.ToString());
        //                        //Cargar los nodos requeridos del xml para obtener el UUID
        //                        InvoiceCfdi invoiceCfdi = new InvoiceCfdi(xDocument.OuterXml);
        //                        UUID = invoiceCfdi.UUID;

        //                        string xmlNewFilename = tempInvoice.XML_FileName.Replace(".xml", "") + ".pdf";

        //                        //Guardar los datos del pdf
        //                        if (tempInvoice.PDF_FileName == null)
        //                        {
        //                            string pathServerFolder = rfcSupplier.ToUpper() + "\\" + invoiceCfdi.Fecha.Year.ToString();
        //                            //Crear el archivo xml y guadar su contenido
        //                            using (var stream = System.IO.File.Create(appSettings.PhysicalServerFolder + "\\" + pathServerFolder + "\\" + xmlNewFilename))
        //                            {
        //                                await file.CopyToAsync(stream);

        //                                tempInvoice.PDF_FileName = xmlNewFilename;
        //                                tempInvoice.PDF_Length = file.Length;
        //                                tempInvoice.PDF_Path = tempInvoice.XML_Path;
        //                                tempInvoice.PDF_CreatedDate = DateTime.Now;
        //                                _repositoryContext.Entry(tempInvoice).State = EntityState.Modified;
        //                                await _repositoryContext.SaveChangesAsync();
        //                            }

        //                            //Agrear la referencia de carga
        //                            uploadResults.Add(new UploadResult
        //                            {
        //                                UUID = tempInvoice.UUID,
        //                                EmitterName = tempInvoice.Emitter_Name,
        //                                Filename = file.FileName,
        //                                TypeFile = file.ContentType,
        //                                Version = invoiceCfdi.version,
        //                                CreatedDate = DateTime.Now,
        //                                Description = "Cargado con éxito",
        //                                Status = true
        //                            });

        //                            break;
        //                        }
        //                        else
        //                        {
        //                            //No sepuede cargar el pdf, ya existe un documento
        //                            uploadResults.Add(new UploadResult
        //                            {
        //                                UUID = "",
        //                                EmitterName = "",
        //                                Filename = file.FileName,
        //                                TypeFile = file.ContentType,
        //                                Version = "",
        //                                CreatedDate = DateTime.Now,
        //                                Description = "No sepuede cargar el pdf por que ya existe",
        //                                Status = false
        //                            });
        //                        }

        //                    }
        //                    else
        //                    {
        //                        //No se encontro la factura que se relaciona al pdf
        //                        uploadResults.Add(new UploadResult
        //                        {
        //                            UUID = "",
        //                            EmitterName = "",
        //                            Filename = file.FileName,
        //                            TypeFile = file.ContentType,
        //                            Version = "",
        //                            CreatedDate = DateTime.Now,
        //                            Description = "No se encontro la factura que se relaciona al archivo pdf",
        //                            Status = false
        //                        });
        //                    }
        //                }

        //            }
        //        }

        //        //Asignar los archivos PDF a sus respectivos XML
        //        foreach(UploadResult row in uploadResults) {
        //            if (row.TypeFile.Equals("text/xml")) {
        //                UploadResult pdfFile = uploadResults.SingleOrDefault(x => x.TypeFile.Equals("application/pdf") && x.UUID.Equals(row.UUID));
        //                if(pdfFile != null) {
        //                    row.SupportPDFFile = pdfFile.SupportPDFFile;
        //                }
        //            }
        //        }

        //        return await Task.FromResult(uploadResults.Where(x=>x.TypeFile.Equals("text/xml")).OrderByDescending(x=>x.TypeFile).ThenBy(x=>x.EmitterName).ThenBy(x=>x.Filename).ToList());

        //    }
        //    catch (Exception ex)
        //    {
        //        throw(ex);
        //    }
        //}

        //public async Task<TrayCollaborator> SearchAsync(List<int> idStatus, List<int> idCompanies, List<int> idSuppliers, List<int> idBusinessUnits, List<int> idBranchCompanies, List<string> idMoney, List<int> paymentReceipt, string Description, DateTime startDate, DateTime endDate, bool onlyMyInvoices, int idPerson)
        //{
        //    try
        //    {
        //        AppSettings appSettings = new AppSettings();
        //        if (idStatus.FirstOrDefault() == 0)
        //            idStatus = _repositoryContext.StatusInvoices.Select(x=>x.IdStatus).ToList();
        //        if (idBranchCompanies.FirstOrDefault() == 0)
        //            idBranchCompanies = (await PersonBranchCompanyHelper.GetListAsync(idPerson)).Select(x => x.IdBranchCompany).ToList();
        //        if (idBusinessUnits.FirstOrDefault() == 0)
        //            idBusinessUnits = (await PersonBusinessUnitHelper.GetListAsync(idPerson)).Select(x => x.IdBusinessUnit).ToList();
        //        if(idSuppliers.FirstOrDefault()==0)
        //            idSuppliers = await _repositoryContext.CompanySuppliers.Where(x => x.IdCompany == appSettings.Configuration.PrincipalIdCompany.Value && idBranchCompanies.Contains(x.IdBranchCompany) && idBusinessUnits.Contains(x.IdBusinessUnit)).Select(x => x.IdSupplier).Distinct().ToListAsync();

        //        if(idStatus.Contains((int)SupplierWebApp.Enumerators.StatusInvoice.Paid))
        //        {
        //            idStatus.Add((int)SupplierWebApp.Enumerators.StatusInvoice.PartialPaid);
        //        }

        //        TrayCollaborator Data = new TrayCollaborator();
        //        Data.Invoices = new List<vtInvoice>();
        //        List<vtInvoice> invoices = await InvoiceHelper.SearchAsync(new List<int> { 0 }, idCompanies, idSuppliers, idBusinessUnits, idBranchCompanies, idMoney, paymentReceipt, Description, startDate, endDate, onlyMyInvoices, idPerson);
        //        Data.Invoices = invoices.Where(x => idStatus.Contains(x.IdStatus)).OrderByDescending(x=>x.CreatedDate).ToList();
        //        Data.Inbox = invoices.Count();
        //        Data.Pending = invoices.Where(x => x.IdStatus ==  (int)SupplierWebApp.Enumerators.StatusInvoice.Pending).Count();
        //        Data.Stopped = invoices.Where(x => x.IdStatus ==  (int)SupplierWebApp.Enumerators.StatusInvoice.Stopped).Count();
        //        Data.Approved = invoices.Where(x => x.IdStatus == (int)SupplierWebApp.Enumerators.StatusInvoice.Approved).Count();
        //        Data.Paid = invoices.Where(x => x.IdStatus == (int)SupplierWebApp.Enumerators.StatusInvoice.Paid || x.IdStatus == (int)SupplierWebApp.Enumerators.StatusInvoice.PartialPaid).Count();
        //        Data.Rejected = invoices.Where(x => x.IdStatus == (int)SupplierWebApp.Enumerators.StatusInvoice.Rejected).Count();
        //        Data.Canceled = invoices.Where(x => x.IdStatus == (int)SupplierWebApp.Enumerators.StatusInvoice.Canceled).Count();

        //        return Data;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw(ex);
        //    }
        //}

        //public async Task<TrayCollaborator> SearchAsync(List<int> idStatus, List<int> idSuppliers, List<int> idBusinessUnits, List<int> idBranchCompanies, List<string> idMoney, List<int> rep, string Description, DateTime startDate, DateTime endDate, bool onlyMyInvoices, int idPerson) {
        //    try {
        //        if (idStatus.First() == 0)
        //            idStatus = _repositoryContext.StatusInvoices.Select(x => x.IdStatus).ToList();
        //        if(idBranchCompanies.FirstOrDefault() == 0)
        //            idBranchCompanies = (await PersonBranchCompanyHelper.GetListAsync(idPerson)).Select(x => x.IdBranchCompany).ToList();
        //        if (idBusinessUnits.FirstOrDefault() == 0)
        //            idBusinessUnits = (await PersonBusinessUnitHelper.GetListAsync(idPerson)).Select(x => x.IdBusinessUnit).ToList();

        //        if (idStatus.Contains((int)SupplierWebApp.Enumerators.StatusInvoice.Paid))
        //        {
        //            idStatus.Add((int)SupplierWebApp.Enumerators.StatusInvoice.PartialPaid);
        //        }

        //        TrayCollaborator Data = new TrayCollaborator();
        //        Data.Invoices = new List<vtInvoice>();
        //        List<vtInvoice> invoices = await InvoiceHelper.SearchAsync(new List<int> { 0 }, idSuppliers, idBusinessUnits, idBranchCompanies, idMoney, rep, Description, startDate, endDate, onlyMyInvoices, idPerson);
        //        Data.Invoices = invoices.Where(x => idStatus.Contains(x.IdStatus)).OrderByDescending(x => x.CreatedDate).ToList();
        //        Data.Inbox = invoices.Count();
        //        Data.Pending = invoices.Where(x => x.IdStatus ==  (int)SupplierWebApp.Enumerators.StatusInvoice.Pending).Count();
        //        Data.Stopped = invoices.Where(x => x.IdStatus ==  (int)SupplierWebApp.Enumerators.StatusInvoice.Stopped).Count();
        //        Data.Approved = invoices.Where(x => x.IdStatus == (int)SupplierWebApp.Enumerators.StatusInvoice.Approved).Count();
        //        Data.Paid = invoices.Where(x => x.IdStatus == (int)SupplierWebApp.Enumerators.StatusInvoice.Paid || x.IdStatus == (int)SupplierWebApp.Enumerators.StatusInvoice.PartialPaid).Count();
        //        Data.Rejected = invoices.Where(x => x.IdStatus == (int)SupplierWebApp.Enumerators.StatusInvoice.Rejected).Count();
        //        Data.Canceled = invoices.Where(x => x.IdStatus == (int)SupplierWebApp.Enumerators.StatusInvoice.Canceled).Count();

        //        return Data;
        //    }
        //    catch (Exception ex) {
        //        throw (ex);
        //    }
        //}

        //public async Task<vtInvoice> GetAsync(int idInvoice) {
        //    try {
        //        return await _repositoryContext.vtInvoices.SingleOrDefaultAsync(x => x.IdInvoice == idInvoice);
        //    }
        //    catch (Exception ex) {
        //        throw(ex);
        //    }
        //}

        //public async Task<List<vtInvoice>> GetListAsync(string keyID)
        //{
        //    try
        //    {
        //        return await _repositoryContext.vtInvoices.Where(x => x.KeyID.Equals(keyID)).ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        //public async Task<List<ItemsCfdi>> GetItemsAsync(int idInvoice) 
        //{
        //    try {
        //        List<ItemsCfdi> itemsCfdis = new List<ItemsCfdi>();
        //        vtInvoice invoice = await _repositoryContext.vtInvoices.SingleOrDefaultAsync(x => x.IdInvoice == idInvoice);
        //        InvoiceCfdi invoiceCfdi = new InvoiceCfdi(invoice.XML_Content);
        //        if(invoiceCfdi.Conceptos != null)
        //        {
        //            var conceptos = invoiceCfdi.Conceptos.ChildNodes;
        //            foreach (XmlElement row in conceptos)
        //            {
        //                string objetoImpDescription = (row.Attributes["ObjetoImp"] != null ? _repositoryContext.CatObjetoImps.SingleOrDefault(x => x.IdObjetoImp.Equals(row.Attributes["ObjetoImp"].Value.ToString())).Description : "");
        //                itemsCfdis.Add(new ItemsCfdi
        //                {
        //                    ClaveProdServ = (row.Attributes["ClaveProdServ"] != null ? row.Attributes["ClaveProdServ"].Value : ""),
        //                    ClaveUnidad = (row.Attributes["ClaveUnidad"] != null ? row.Attributes["ClaveUnidad"].Value : ""),
        //                    Descripcion = (row.Attributes["Descripcion"] != null ? row.Attributes["Descripcion"].Value : ""),
        //                    Cantidad = (row.Attributes["Cantidad"] != null ? decimal.Parse(row.Attributes["Cantidad"].Value) : 0),
        //                    Importe = (row.Attributes["Importe"] != null ? decimal.Parse(row.Attributes["Importe"].Value) : 0),
        //                    Descuento = (row.Attributes["Descuento"] != null ? decimal.Parse(row.Attributes["Descuento"].Value) : 0),
        //                    NoIdentificacion = (row.Attributes["NoIdentificacion"] != null ? row.Attributes["NoIdentificacion"].Value : ""),
        //                    ObjetoImp = (row.Attributes["ObjetoImp"] != null ? row.Attributes["ObjetoImp"].Value : ""),
        //                    ObjetoImpDescription = objetoImpDescription,
        //                    Unidad = (row.Attributes["Unidad"] != null ? row.Attributes["Unidad"].Value : ""),
        //                    ValorUnitario = (row.Attributes["ValorUnitario"] != null ? decimal.Parse(row.Attributes["ValorUnitario"].Value) : 0),
        //                });

        //            }

        //        }

        //        return itemsCfdis;
        //    }
        //    catch (Exception ex) {
        //        throw (ex);
        //    }
        //}

        //public async Task<List<TaxesCfdi>> GetTaxesAsync(int idInvoice) {
        //    try 
        //    {
        //        List<TaxesCfdi> taxesCfdis = new List<TaxesCfdi>();
        //        vtInvoice invoice = await _repositoryContext.vtInvoices.SingleOrDefaultAsync(x => x.IdInvoice == idInvoice);
        //        InvoiceCfdi invoiceCfdi = new InvoiceCfdi(invoice.XML_Content);
        //        if(invoiceCfdi.Impuestos != null) {
        //            var impuestos = invoiceCfdi.Impuestos.ChildNodes;
        //            foreach (XmlElement row in impuestos) {
        //                foreach (XmlElement raw in row) {
        //                    string impuestoDescription = (raw.Attributes["Impuesto"] != null ? _repositoryContext.CatTaxes.SingleOrDefault(x => x.IdTax.Equals(raw.Attributes["Impuesto"].Value.ToString())).Description : "");
        //                    taxesCfdis.Add(new TaxesCfdi {
        //                        IdImpuesto = (raw.Attributes["Impuesto"] != null ? raw.Attributes["Impuesto"].Value : ""),
        //                        NombreImpuesto = impuestoDescription,
        //                        TipoFactor = (raw.Attributes["TipoFactor"] != null ? raw.Attributes["TipoFactor"].Value : ""),
        //                        TasaOCuota = (raw.Attributes["TasaOCuota"] != null ? decimal.Parse(raw.Attributes["TasaOCuota"].Value) : 0),
        //                        Importe = (raw.Attributes["Importe"] != null ? decimal.Parse(raw.Attributes["Importe"].Value) : 0),
        //                        Base = (raw.Attributes["Base"] != null ? decimal.Parse(raw.Attributes["Base"].Value) : 0),
        //                    });
        //                }
        //            }
        //        }

        //        return taxesCfdis;
        //    }
        //    catch (Exception ex) {
        //        throw(ex);
        //    }
        //}

        //public async Task<List<InvoiceAttachment>> GetAttachmentsAsync(int idInvoice)
        //{
        //    try
        //    {
        //        List<InvoiceAttachment> attachments = await _repositoryContext.InvoiceAttachments.Where(x => x.IdInvoice == idInvoice).OrderBy(x => x.CreatedDate).ToListAsync();

        //        return attachments;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        //public async Task<string> GetViewPurchaseOrderAsync(int idInvoice) {
        //    try {
        //        vtInvoice currentInvoice = await _repositoryContext.vtInvoices.SingleOrDefaultAsync(x => x.IdInvoice == idInvoice);
        //        string JSONPurchaseOrder = currentInvoice.JSONPurchaseOrder != null ? currentInvoice.JSONPurchaseOrder : "";
        //        if(!string.IsNullOrEmpty(JSONPurchaseOrder))
        //        {
        //            JSONCustomPurchaseOrder jsonPurchaseOrder = JsonSerializer.Deserialize<JSONCustomPurchaseOrder>(JSONPurchaseOrder.Replace("[", "").Replace("]", ""));
        //            if (jsonPurchaseOrder != null)
        //            {
        //                List<CustomPurchaseOrder> purchaseOrders = new List<CustomPurchaseOrder>();
        //                using (SAERepositoryContext contextSAE = new SAERepositoryContext())
        //                {
        //                    SAERepositoryWrapper _repositorySAE = new SAERepositoryWrapper(contextSAE);
        //                    purchaseOrders = await _repositorySAE.Receptions.GetCustomPurchaseOrdersAsync(jsonPurchaseOrder.OrdenCompra, currentInvoice.Emitter_RFC);
        //                }
        //                jsonPurchaseOrder.Saldo = 0;

        //                //Buscar las facturas relacionadas a cada OC
        //                List<string> purchaseOrdeList = purchaseOrders.Select(x => x.CVE_DOC).Distinct().ToList();
        //                foreach (string numOC in purchaseOrdeList)
        //                {
        //                    List<Invoice> invoices = _repositoryContext.Invoices.Where(x => x.PurchaseOrder.Equals(numOC) && (x.IdStatus != (int)Enumerators.StatusInvoice.Canceled && x.IdStatus != (int)Enumerators.StatusInvoice.Rejected)).ToList();
        //                    if (invoices.Count() > 0)
        //                    {
        //                        foreach (Invoice invoice in invoices)
        //                        {
        //                            purchaseOrders.SingleOrDefault(x => x.CVE_DOC.Equals(numOC)).SALDO -= (double)invoice.Total;
        //                            jsonPurchaseOrder.Saldo = (Decimal)purchaseOrders.SingleOrDefault(x => x.CVE_DOC.Equals(numOC)).SALDO;
        //                        }
        //                    }
        //                }
        //            }

        //            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        //            JSONPurchaseOrder = "[" + JsonSerializer.Serialize<JSONCustomPurchaseOrder>(jsonPurchaseOrder, options) + "]";
        //        }

        //        JSONPurchaseOrder = JSONPurchaseOrder.Replace("}]", ",\"ImporteFactura\":" + currentInvoice.Total + "}]");

        //        return JSONPurchaseOrder;
        //    }
        //    catch (Exception ex) {
        //        throw (ex);
        //    }
        //}

        //public async Task<vtInvoice> Upload(string uuid, IFormFile invoiceFile, IFormFile supportFile, string jsonPurchaseOrder, int idPerson, IMapper mapper) {
        //    try {
        //        AppSettings appSettings = new AppSettings();
        //        PreInvoice preInvoice = await _repositoryContext.PreInvoices.OrderBy(x=>x.IdPreInvoice).LastOrDefaultAsync(x => x.UUID.Equals(uuid) && x.IdStatus == (int)StatusPreInvoice.Validation);
        //        vtPerson person = (await PersonHelper.GetViewAsync(idPerson));
        //        List<JSONCustomPurchaseOrder> LPurchaseOrders = new List<JSONCustomPurchaseOrder>();

        //        if(jsonPurchaseOrder != null)
        //        {
        //            LPurchaseOrders = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JSONCustomPurchaseOrder>>(jsonPurchaseOrder);
        //        }

        //        if (_repositoryContext.Invoices.Count(x => x.UUID.Equals(uuid) && x.IdStatus != (int)Enumerators.StatusInvoice.Canceled) > 0)
        //            throw new Exception("El comprobante con UUID: " + uuid + " ya fue cargada en base de datos");

        //        List<int> idSuppliers = await _repositoryContext.Suppliers.Where(x => x.RFC.Equals(preInvoice.Emitter_RFC)).Select(x => x.IdSupplier).ToListAsync();
        //        if(idSuppliers.Count==0) {
        //            throw new Exception("El proveedor con RFC: " + preInvoice.Emitter_RFC + " y Nombre: " + preInvoice.Emitter_Name + ", no existe para el comprobante con UUID: " + uuid + ", favor de crear el registro del proveedor antes de realizar este proceso");
        //        }
        //        else {
        //            List<int> idCompanySupplier = await _repositoryContext.CompanySuppliers.Where(x => x.IdCompany == appSettings.Configuration.PrincipalIdCompany.Value && x.IdBranchCompany == preInvoice.IdBranchCompany && x.IdBusinessUnit == preInvoice.IdBusinessUnit).Select(x => x.IdSupplier).Distinct().ToListAsync();
        //            if(idCompanySupplier.Count ==0) {
        //                throw new Exception("El proveedor con RFC: " + preInvoice.Emitter_RFC + " y Nombre: " + preInvoice.Emitter_Name + ", existe en la base de datos pero no se ha establecido para la sucursal y unidad de negocio del comprobante con UUID: " + uuid);
        //            }
        //        }

        //        //string pathServerFolder = "Invoices\\" + person.VatNum.ToUpper() + "\\" + preInvoice.InvoiceDate.Year.ToString();
        //        string pathServerFolder = "Invoices\\" + preInvoice.Emitter_RFC.ToUpper() + "\\" + preInvoice.InvoiceDate.Year.ToString();
        //        //Nuevo nombre final del archivo RFC_EMISOR + AÑO + MES + DIA + SERIE + FOLIO
        //        string xmlNewFilename = preInvoice.Emitter_RFC + "-" + preInvoice.InvoiceDate.ToString("yyyy") + preInvoice.InvoiceDate.ToString("MM") + preInvoice.InvoiceDate.ToString("dd") + "-" + preInvoice.Serie + preInvoice.Folio + ".xml";
        //        string pdfNewFilename = preInvoice.Emitter_RFC + "-" + preInvoice.InvoiceDate.ToString("yyyy") + preInvoice.InvoiceDate.ToString("MM") + preInvoice.InvoiceDate.ToString("dd") + "-" + preInvoice.Serie + preInvoice.Folio + ".pdf";
        //        string pdfSupportFilename = preInvoice.Emitter_RFC + "-" + preInvoice.InvoiceDate.ToString("yyyy") + preInvoice.InvoiceDate.ToString("MM") + preInvoice.InvoiceDate.ToString("dd") + "-" + preInvoice.Serie + preInvoice.Folio + "_Support.pdf";

        //        //Comprobar si existe el directorio
        //        bool exists = System.IO.Directory.Exists(appSettings.PhysicalServerFolder + "\\" + pathServerFolder);

        //        //Comprobar si existe el directorio
        //        if (!exists)
        //            System.IO.Directory.CreateDirectory(appSettings.PhysicalServerFolder + "\\" + pathServerFolder);

        //        //Guardar el archivo XML de factura en su nueva ubicacion
        //        File.Copy(appSettings.PhysicalServerFiles + preInvoice.XML_Path + "\\" + preInvoice.XML_FileName, appSettings.PhysicalServerFolder + pathServerFolder + "\\"+ xmlNewFilename, true);
        //        //Elimina el archivo XML anterior
        //        File.Delete(appSettings.PhysicalServerFiles + preInvoice.XML_Path + "\\" + preInvoice.XML_FileName);

        //        //Guardar el archivo PDF de factura en su nueva ubicacion
        //        if (invoiceFile==null) {
        //            File.Copy(appSettings.PhysicalServerFiles + preInvoice.PDF_Path + "\\" + preInvoice.PDF_FileName, appSettings.PhysicalServerFolder + pathServerFolder + "\\" + pdfNewFilename, true);
        //            //Elimina el archivo PDF anterior
        //            File.Delete(appSettings.PhysicalServerFiles + preInvoice.PDF_Path + "\\" + preInvoice.PDF_FileName);
        //            //Guardar la informacion a la PreInvoice
        //            preInvoice.PDF_Path = appSettings.RelativeServerFolder + pathServerFolder + "\\";
        //        }
        //        else {
        //            //Crear el archivo en la nueva ubicacion
        //            using (var stream = System.IO.File.Create(appSettings.PhysicalServerFolder + "\\" + pathServerFolder + "\\" + pdfNewFilename)) {
        //                await invoiceFile.CopyToAsync(stream);
        //                //Guardar la informacion a la PreInvoice
        //                preInvoice.PDF_FileName = pdfNewFilename;
        //                preInvoice.PDF_Length = invoiceFile.Length;
        //                preInvoice.PDF_Path = appSettings.RelativeServerFolder + pathServerFolder + "\\";
        //                preInvoice.PDF_CreatedDate = DateTime.Now;
        //            }
        //        }

        //        if(supportFile!= null) {
        //            //Crear el archivo
        //            using (var stream = System.IO.File.Create(appSettings.PhysicalServerFolder + "\\" + pathServerFolder + "\\" + pdfSupportFilename)) {
        //                await supportFile.CopyToAsync(stream);
        //                //Guardar la informacion a la PreInvoice
        //                preInvoice.SUPPORT_FileName = pdfSupportFilename;
        //                preInvoice.SUPPORT_Length = supportFile.Length;
        //                preInvoice.SUPPORT_Path = appSettings.RelativeServerFolder + pathServerFolder + "\\";
        //                preInvoice.SUPPORT_CreatedDate = DateTime.Now;
        //            }
        //        }

        //        //Guardar el objeto en la base de datos
        //        Invoice invoice = mapper.Map<Invoice>(preInvoice);
        //        invoice.IdPreInvoice = preInvoice.IdPreInvoice;
        //        invoice.XML_Path = appSettings.RelativeServerFolder + pathServerFolder + "\\";
        //        invoice.XML_FileName = xmlNewFilename;
        //        invoice.CreatedDate = DateTime.Now;
        //        invoice.IdPerson = idPerson;
        //        invoice.IdStatus = (int)SupplierWebApp.Enumerators.StatusInvoice.Pending;
        //        if(LPurchaseOrders.Count()>0)
        //            invoice.PurchaseOrder = string.Join(",", LPurchaseOrders.Select(x=>x.OrdenCompra).ToList());
        //        invoice.ReceptionOrder = string.Join(",", new List<string>() /*LPurchaseOrders.Select(x => x.Recepcion).ToList()*/); ;
        //        invoice.JSONPurchaseOrder = jsonPurchaseOrder;

        //        if (invoiceFile!= null) {
        //            invoice.PDF_FileName = pdfNewFilename;
        //            invoice.PDF_Length = invoiceFile.Length;
        //            invoice.PDF_Path = appSettings.RelativeServerFolder + pathServerFolder + "\\";
        //            invoice.PDF_CreatedDate = DateTime.Now;
        //        }
        //        if (supportFile != null) {
        //            invoice.SUPPORT_FileName = pdfSupportFilename;
        //            invoice.SUPPORT_Length = supportFile.Length;
        //            invoice.SUPPORT_Path = appSettings.RelativeServerFolder + pathServerFolder + "\\";
        //            invoice.SUPPORT_CreatedDate = DateTime.Now;
        //        }

        //        _repositoryContext.Entry(invoice).State = EntityState.Added;
        //        await _repositoryContext.SaveChangesAsync();

        //        //Cambia el Esatus de la PreInvoice
        //        preInvoice.IdStatus = (int)StatusPreInvoice.Completed;
        //        preInvoice.CompleteDate = DateTime.Now;
        //        preInvoice.XML_Path = appSettings.RelativeServerFolder + pathServerFolder + "\\";
        //        _repositoryContext.Entry(preInvoice).State = EntityState.Modified;

        //        await _repositoryContext.SaveChangesAsync();


        //        return await _repositoryContext.vtInvoices.SingleOrDefaultAsync(x => x.IdInvoice == invoice.IdInvoice);
        //    }
        //    catch (Exception ex) {
        //        throw (ex);
        //    }
        //}

        //public async Task<bool> UpdateStatusAsync(int idInvoice, int idStatus, string reasonStatus, IFormFile cepFileXML, IFormFile cepFilePDF, decimal amountPaid, string currency, decimal exchangeRate, int idPerson) {
        //    try {
        //        string fullCEPFilenameXML = null;
        //        string fullCEPFilenamePDF = null;

        //        Invoice invoice = await _repositoryContext.Invoices.SingleOrDefaultAsync(x => x.IdInvoice == idInvoice);
        //        invoice.IdStatus = idStatus;
        //        if(idStatus == (int)SupplierWebApp.Enumerators.StatusInvoice.Stopped) {
        //            invoice.StoppedBy = idPerson;
        //            invoice.StoppedDate = DateTime.Now;
        //            invoice.StoppedReason = reasonStatus;
        //        }
        //        else if (idStatus == (int)SupplierWebApp.Enumerators.StatusInvoice.Approved) {
        //            invoice.ApprovedBy = idPerson;
        //            invoice.ApprovedDate = DateTime.Now;
        //            invoice.ApprovedReason = reasonStatus;
        //        }
        //        else if (idStatus == (int)SupplierWebApp.Enumerators.StatusInvoice.Rejected) {
        //            invoice.RejectedBy = idPerson;
        //            invoice.RejectedDate = DateTime.Now;
        //            invoice.RejectedReason = reasonStatus;
        //        }
        //        else if (idStatus == (int)SupplierWebApp.Enumerators.StatusInvoice.Canceled) {
        //            invoice.CanceledBy = idPerson;
        //            invoice.CanceledDate = DateTime.Now;
        //            invoice.CanceledReason = reasonStatus;

        //            //Cambian el estatus de la PreFactura
        //            PreInvoice preInvoice = _repositoryContext.PreInvoices.SingleOrDefault(x => x.IdPreInvoice == invoice.IdPreInvoice);
        //            if(preInvoice != null)
        //            {
        //                preInvoice.IdStatus = (int)Enumerators.StatusPreInvoice.Validation;
        //                _repositoryContext.Entry(preInvoice).State = EntityState.Modified;
        //                _repositoryContext.SaveChanges();
        //            }
        //        }
        //        else if (idStatus == (int)SupplierWebApp.Enumerators.StatusInvoice.Paid) {
        //            AppSettings appSettings = new AppSettings();
        //            string cepFilenameXML = invoice.Emitter_RFC + "-" + invoice.InvoiceDate.ToString("yyyy") + invoice.InvoiceDate.ToString("MM") + invoice.InvoiceDate.ToString("dd") + "-" + invoice.Serie + invoice.Folio + "_CEP.xml";
        //            string cepFilenamePDF = invoice.Emitter_RFC + "-" + invoice.InvoiceDate.ToString("yyyy") + invoice.InvoiceDate.ToString("MM") + invoice.InvoiceDate.ToString("dd") + "-" + invoice.Serie + invoice.Folio + "_CEP.pdf";
        //            fullCEPFilenameXML = appSettings.PhysicalServerFiles + "\\" + invoice.XML_Path + "\\" + cepFilenameXML;
        //            fullCEPFilenamePDF = appSettings.PhysicalServerFiles + "\\" + invoice.XML_Path + "\\" + cepFilenamePDF;

        //            if(cepFileXML!= null)
        //            {
        //                using (var stream = System.IO.File.Create(fullCEPFilenameXML))
        //                {
        //                    await cepFileXML.CopyToAsync(stream);
        //                }
        //            }

        //            using (var stream = System.IO.File.Create(fullCEPFilenamePDF)) {
        //                await cepFilePDF.CopyToAsync(stream);
        //            }

        //            invoice.PaidBy = idPerson;
        //            invoice.PaidDate = DateTime.Now;
        //            invoice.PaidReason = reasonStatus;
        //            invoice.PaidCEPFileXML = (cepFileXML!= null ? cepFilenameXML: null);
        //            invoice.PaidCEPFilePDF = cepFilenamePDF;
        //        }
        //        else if (idStatus == (int)SupplierWebApp.Enumerators.StatusInvoice.PartialPaid)
        //        {
        //            AppSettings appSettings = new AppSettings();
        //            List<InvoiceAttachmentPPD> invoiceAttachmentPPDs = _repositoryContext.InvoiceAttachmentPPDs.Where(x => x.IdInvoice == idInvoice && x.Type.Equals("CEP") && x.Extension.ToLower().Equals(".pdf")).ToList();
        //            decimal currentAmountPaid = invoiceAttachmentPPDs.Sum(x => x.AmountPaid.Value) + amountPaid;
        //            int totalFiles = invoiceAttachmentPPDs.Count() + 1;
        //            string cepFilenameXML = invoice.Emitter_RFC + "-" + invoice.InvoiceDate.ToString("yyyy") + invoice.InvoiceDate.ToString("MM") + invoice.InvoiceDate.ToString("dd") + "-" + invoice.Serie + invoice.Folio + "_CEP_" + totalFiles + ".xml";
        //            string cepFilenamePDF = invoice.Emitter_RFC + "-" + invoice.InvoiceDate.ToString("yyyy") + invoice.InvoiceDate.ToString("MM") + invoice.InvoiceDate.ToString("dd") + "-" + invoice.Serie + invoice.Folio + "_CEP_" + totalFiles + ".pdf";
        //            fullCEPFilenameXML = appSettings.PhysicalServerFiles + "\\" + invoice.XML_Path + "\\" + cepFilenameXML;
        //            fullCEPFilenamePDF = appSettings.PhysicalServerFiles + "\\" + invoice.XML_Path + "\\" + cepFilenamePDF;

        //            if(currentAmountPaid == invoice.Total)
        //            {
        //                invoice.IdStatus = (int)Enumerators.StatusInvoice.Paid;
        //            }

        //            if (currentAmountPaid > invoice.Total)
        //            {
        //                throw new Exception("La suma de pagos acumulada supera el importe total de la factura, revise el importe y vuelva a intenterlo");
        //            }

        //            if (cepFileXML != null)
        //            {
        //                using (var stream = System.IO.File.Create(fullCEPFilenameXML))
        //                {
        //                    await cepFileXML.CopyToAsync(stream);
        //                }

        //                //Guardar el registro en la base de datos
        //                InvoiceAttachmentPPD invoiceAttachmentPPD_XML = new InvoiceAttachmentPPD();
        //                invoiceAttachmentPPD_XML.IdInvoice = idInvoice;
        //                invoiceAttachmentPPD_XML.Consecutive = totalFiles;
        //                invoiceAttachmentPPD_XML.OriginalFileName = cepFileXML.FileName;
        //                invoiceAttachmentPPD_XML.FileName = cepFilenameXML;
        //                invoiceAttachmentPPD_XML.Path = invoice.XML_Path + "\\";
        //                invoiceAttachmentPPD_XML.Extension = Path.GetExtension(fullCEPFilenameXML);
        //                invoiceAttachmentPPD_XML.Length = cepFileXML.Length;
        //                invoiceAttachmentPPD_XML.Type = "CEP";
        //                invoiceAttachmentPPD_XML.CreatedBy = idPerson;
        //                invoiceAttachmentPPD_XML.CreatedDate = DateTime.Now;
        //                invoiceAttachmentPPD_XML.PaidReason = reasonStatus;
        //                _repositoryContext.Entry(invoiceAttachmentPPD_XML).State = EntityState.Added;
        //                await _repositoryContext.SaveChangesAsync();
        //            }

        //            using (var stream = System.IO.File.Create(fullCEPFilenamePDF))
        //            {
        //                await cepFilePDF.CopyToAsync(stream);

        //                //Guardar el registro en la base de datos
        //                InvoiceAttachmentPPD invoiceAttachmentPPD_PDF = new InvoiceAttachmentPPD();
        //                invoiceAttachmentPPD_PDF.IdInvoice = idInvoice;
        //                invoiceAttachmentPPD_PDF.Consecutive = totalFiles;
        //                invoiceAttachmentPPD_PDF.Currency = currency;
        //                invoiceAttachmentPPD_PDF.ExchangeRate = exchangeRate;
        //                invoiceAttachmentPPD_PDF.AmountPaid = amountPaid;
        //                invoiceAttachmentPPD_PDF.OriginalFileName = cepFilePDF.FileName;
        //                invoiceAttachmentPPD_PDF.FileName = cepFilenamePDF;
        //                invoiceAttachmentPPD_PDF.Path = invoice.XML_Path + "\\";
        //                invoiceAttachmentPPD_PDF.Extension = Path.GetExtension(fullCEPFilenamePDF);
        //                invoiceAttachmentPPD_PDF.Length = cepFilePDF.Length;
        //                invoiceAttachmentPPD_PDF.Type = "CEP";
        //                invoiceAttachmentPPD_PDF.CreatedBy = idPerson;
        //                invoiceAttachmentPPD_PDF.CreatedDate = DateTime.Now;
        //                invoiceAttachmentPPD_PDF.PaidReason = reasonStatus;
        //                _repositoryContext.Entry(invoiceAttachmentPPD_PDF).State = EntityState.Added;
        //                await _repositoryContext.SaveChangesAsync();
        //            }

        //            invoice.PaidBy = idPerson;
        //            invoice.PaidDate = DateTime.Now;
        //            invoice.PaidReason = reasonStatus;
        //        }

        //        _repositoryContext.Entry(invoice).State = EntityState.Modified;
        //        await _repositoryContext.SaveChangesAsync();

        //        bool response = await InvoiceHelper.UpdateStatusEmailAsync(idInvoice, idStatus, (cepFileXML != null ? fullCEPFilenameXML: null), fullCEPFilenamePDF, idPerson, reasonStatus);

        //        return true;
        //    }
        //    catch (Exception ex) {
        //        throw(ex);
        //    }
        //}

        //public async Task<bool> UpdateOCAsync(string uuid, string jsonPurchaseOrder) {
        //    try {
        //        List<JSONCustomPurchaseOrder> LPurchaseOrders = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JSONCustomPurchaseOrder>>(jsonPurchaseOrder);
        //        Invoice invoice = await _repositoryContext.Invoices.SingleOrDefaultAsync(x => x.UUID.Equals(uuid));
        //        invoice.PurchaseOrder = string.Join(",", LPurchaseOrders.Select(x => x.OrdenCompra).ToList());
        //        invoice.JSONPurchaseOrder = jsonPurchaseOrder;
        //        _repositoryContext.Entry(invoice).State = EntityState.Modified;
        //        await _repositoryContext.SaveChangesAsync();

        //        return true;
        //    }
        //    catch (Exception ex) {
        //        throw (ex);
        //    }
        //}

        //public async Task<bool> UploadREPAsync(int idInvoice, IFormFile repFileXML, IFormFile repFilePDF, int idPerson) {
        //    try {
        //        Invoice invoice = await _repositoryContext.Invoices.SingleOrDefaultAsync(x => x.IdInvoice == idInvoice);
        //        AppSettings appSettings = new AppSettings();

        //        if((invoice.IdStatus == (int)Enumerators.StatusInvoice.PartialPaid || invoice.IdStatus == (int)Enumerators.StatusInvoice.Paid) && invoice.IdPaymentMethod == "PPD")
        //        {
        //            int totalFiles = _repositoryContext.InvoiceAttachmentPPDs.Count(x => x.IdInvoice == idInvoice && x.Type.Equals("REP") && x.Extension.ToLower().Equals(".xml")) + 1;
        //            string repfileNameXML = invoice.Emitter_RFC + "-" + invoice.InvoiceDate.ToString("yyyy") + invoice.InvoiceDate.ToString("MM") + invoice.InvoiceDate.ToString("dd") + "-" + invoice.Serie + invoice.Folio + "_REP_"+ totalFiles + ".xml";
        //            string repfileNamePDF = invoice.Emitter_RFC + "-" + invoice.InvoiceDate.ToString("yyyy") + invoice.InvoiceDate.ToString("MM") + invoice.InvoiceDate.ToString("dd") + "-" + invoice.Serie + invoice.Folio + "_REP_"+ totalFiles + ".pdf";
        //            string fullREPFilenameXML = appSettings.PhysicalServerFiles + "\\" + invoice.XML_Path + "\\" + repfileNameXML;
        //            string fullREPFilenamePDF = appSettings.PhysicalServerFiles + "\\" + invoice.XML_Path + "\\" + repfileNamePDF;

        //            using (var stream = System.IO.File.Create(fullREPFilenameXML))
        //            {
        //                await repFileXML.CopyToAsync(stream);

        //                InvoiceAttachmentPPD invoiceAttachmentPPD_XML = new InvoiceAttachmentPPD();
        //                invoiceAttachmentPPD_XML.IdInvoice = idInvoice;
        //                invoiceAttachmentPPD_XML.Consecutive = totalFiles;
        //                invoiceAttachmentPPD_XML.OriginalFileName = repFileXML.FileName;
        //                invoiceAttachmentPPD_XML.FileName = repfileNameXML;
        //                invoiceAttachmentPPD_XML.Path = invoice.XML_Path + "\\";
        //                invoiceAttachmentPPD_XML.Extension = Path.GetExtension(fullREPFilenameXML);
        //                invoiceAttachmentPPD_XML.Length = repFileXML.Length;
        //                invoiceAttachmentPPD_XML.Type = "REP";
        //                invoiceAttachmentPPD_XML.CreatedBy = idPerson;
        //                invoiceAttachmentPPD_XML.CreatedDate = DateTime.Now;
        //                _repositoryContext.Entry(invoiceAttachmentPPD_XML).State = EntityState.Added;
        //                await _repositoryContext.SaveChangesAsync();
        //            }

        //            using (var stream = System.IO.File.Create(fullREPFilenamePDF))
        //            {
        //                await repFilePDF.CopyToAsync(stream);

        //                InvoiceAttachmentPPD invoiceAttachmentPPD_PDF = new InvoiceAttachmentPPD();
        //                invoiceAttachmentPPD_PDF.IdInvoice = idInvoice;
        //                invoiceAttachmentPPD_PDF.Consecutive = totalFiles;
        //                invoiceAttachmentPPD_PDF.OriginalFileName = repFilePDF.FileName;
        //                invoiceAttachmentPPD_PDF.FileName = repfileNamePDF;
        //                invoiceAttachmentPPD_PDF.Path = invoice.XML_Path + "\\";
        //                invoiceAttachmentPPD_PDF.Extension = Path.GetExtension(fullREPFilenamePDF);
        //                invoiceAttachmentPPD_PDF.Length = repFilePDF.Length;
        //                invoiceAttachmentPPD_PDF.Type = "REP";
        //                invoiceAttachmentPPD_PDF.CreatedBy = idPerson;
        //                invoiceAttachmentPPD_PDF.CreatedDate = DateTime.Now;
        //                _repositoryContext.Entry(invoiceAttachmentPPD_PDF).State = EntityState.Added;
        //                await _repositoryContext.SaveChangesAsync();
        //            }
        //        }
        //        else
        //        {
        //            string repfileNameXML = invoice.Emitter_RFC + "-" + invoice.InvoiceDate.ToString("yyyy") + invoice.InvoiceDate.ToString("MM") + invoice.InvoiceDate.ToString("dd") + "-" + invoice.Serie + invoice.Folio + "_REP.xml";
        //            string repfileNamePDF = invoice.Emitter_RFC + "-" + invoice.InvoiceDate.ToString("yyyy") + invoice.InvoiceDate.ToString("MM") + invoice.InvoiceDate.ToString("dd") + "-" + invoice.Serie + invoice.Folio + "_REP.pdf";

        //            using (var stream = System.IO.File.Create(appSettings.PhysicalServerFiles + "\\" + invoice.XML_Path + "\\" + repfileNameXML))
        //            {
        //                await repFileXML.CopyToAsync(stream);
        //            }

        //            using (var stream = System.IO.File.Create(appSettings.PhysicalServerFiles + "\\" + invoice.XML_Path + "\\" + repfileNamePDF))
        //            {
        //                await repFilePDF.CopyToAsync(stream);
        //            }

        //            invoice.REPBy = idPerson;
        //            invoice.REPDate = DateTime.Now;
        //            invoice.REPFileXML = repfileNameXML;
        //            invoice.REPFilePDF = repfileNamePDF;
        //        }

        //        _repositoryContext.Entry(invoice).State = EntityState.Modified;
        //        await _repositoryContext.SaveChangesAsync();

        //        //bool response = await InvoiceHelper.UpdateStatusEmailAsync(idInvoice, 0);

        //        return true;
        //    }
        //    catch (Exception ex) {
        //        throw (ex);
        //    }
        //}
    }
}
