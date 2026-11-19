using ServicesWebApp.Entities.SupplierWebApp;
//using SupplierWebApp.Helpers.C5SupplierApp.Invoice;
using ServicesWebApp.Interfaces.SupplierWebApp;
//using Microsoft.EntityFrameworkCore;
//using System.Xml;
//using System.Xml.Linq;
//using SupplierWebApp.Entities.C5PortalWebApp;
//using SupplierWebApp.Helpers.C5SupplierApp;
//using SupplierWebApp.Helpers.C5PortalWebApp;
//using SupplierWebApp.Helpers.C5SupplierApp.Custom;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class PreInvoiceRepository : SupplierAppRepositoryBase<PreInvoice>, IPreInvoiceRepository
    {
        private SupplierAppRepositoryContext _repositoryContext;
        public PreInvoiceRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        //public async Task<List<UploadResult>> UploadAsync(List<IFormFile> files, int idPerson, int idBranchCompany, int idBusinessUnit)
        //{
        //    try
        //    {
        //        AppSettings appSettings = new AppSettings();
        //        List<UploadResult> uploadResults = new List<UploadResult>();
        //        vtPerson person = (await PersonHelper.GetViewAsync(idPerson));
        //        List<vtPersonInvoicePrivilegesDetail> personInvoicePrivilegesDetail = await _repositoryContext.VtPersonInvoicePrivilegesDetails.Where(x => x.IdPerson == idPerson).ToListAsync();
        //        string KeyID = PreInvoiceHelper.GetKeyID(10);
        //        bool uploadInvoiceOutOfPeriod = (PersonHelper.GetByPrivilegeAsync(idPerson, (int)Enumerators.Applications.SupplierWebApp).Result).Count(x=>x.RuleName.Equals("APP_PORTALWEBAPPS_COLABORATOR_UPLOAD_INVOICE_OUT_OF_PERIOD"))> 0;

        //        //Validar si puede subir facturas en la fecha de corte
        //        DateTime currentDate = new DateTime(2023, 11, 26);
        //        //DateTime currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        //        DateTime deadline = new DateTime(currentDate.Year, currentDate.Month, appSettings.Configuration.MonthlyInvoiceDeadline.Value);

        //        if (currentDate <= deadline || uploadInvoiceOutOfPeriod)
        //        {

        //            foreach (IFormFile file in files.OrderByDescending(x => x.ContentType))
        //            {
        //                PreInvoice invoice = new PreInvoice();
        //                if (file.ContentType.ToLower().Equals("text/xml"))
        //                {
        //                    //Obtener la validacion mediante el SAT
        //                    CFDI satCFDI = await InvoiceHelper.GetCFDI(file);
                            
        //                    //Obtener el documento xml
        //                    XmlDocument xDocument = await InvoiceHelper.GetFileXMLAsync(file);
        //                    //Cargar los nodos requeridos del xml
        //                    InvoiceCfdi invoiceCfdi = new InvoiceCfdi(xDocument.OuterXml);
        //                    string pathServerFolder = "PreInvoices\\" + (invoiceCfdi.Emisor.Attributes["Rfc"].Value ?? "").ToUpper() + "\\" + invoiceCfdi.Fecha.Year.ToString();
        //                    string UUID = invoiceCfdi.TimbreFiscal.Attributes["UUID"].Value;

        //                    //Comprobar que no existe en la tabla el UUID
        //                    if (_repositoryContext.PreInvoices.Count(x => x.UUID.Equals(UUID) && x.IdStatus == (int)Enumerators.StatusPreInvoice.Completed) == 0)
        //                    {
        //                        bool localError = false;
        //                        //Cargar los atributos xml al objeto de tabla
        //                        invoice.KeyID = KeyID;
        //                        invoice.IdPerson = idPerson;
        //                        invoice.IdCompany = appSettings.Configuration.PrincipalIdCompany.Value;

        //                        if (person.IdTypeAccount == (int)Enumerators.TypeAccount.Collaborator)
        //                            invoice.IdCompany = person.IdCompany.Value;

        //                        invoice.IdBranchCompany = idBranchCompany;
        //                        invoice.IdBusinessUnit = idBusinessUnit;
        //                        invoice.IdStatus = (int)Enumerators.StatusInvoice.Pending;
        //                        invoice.UUID = UUID;
        //                        if (invoiceCfdi.Comprobante.Attributes["Serie"] != null)
        //                            invoice.Serie = invoiceCfdi.Comprobante.Attributes["Serie"].Value;
        //                        else
        //                            invoice.Serie = null;
        //                        if (invoiceCfdi.Comprobante.Attributes["Folio"] != null)
        //                            invoice.Folio = invoiceCfdi.Comprobante.Attributes["Folio"].Value;
        //                        else
        //                            invoice.Folio = null;
        //                        invoice.InvoiceDate = Convert.ToDateTime(invoiceCfdi.Comprobante.Attributes["Fecha"].Value);
        //                        invoice.CreatedDate = DateTime.Now;
        //                        invoice.SubTotal = Convert.ToDecimal(invoiceCfdi.Comprobante.Attributes["SubTotal"].Value ?? "");
        //                        invoice.Discount = Convert.ToDecimal(invoiceCfdi.Comprobante.Attributes["Descuento"] != null ? invoiceCfdi.Comprobante.Attributes["Descuento"].Value : 0);
        //                        invoice.TransferredTax = invoiceCfdi.TotalImpuestosTrasladados;
        //                        invoice.RetainedTax = invoiceCfdi.TotalImpuestosRetenidos;
        //                        invoice.Total = Convert.ToDecimal(invoiceCfdi.Comprobante.Attributes["Total"].Value ?? "");
        //                        if (invoiceCfdi.Comprobante.Attributes["TipoCambio"] != null)
        //                            invoice.ExchangeRate = Convert.ToDecimal(invoiceCfdi.Comprobante.Attributes["TipoCambio"].Value);
        //                        else
        //                            invoice.ExchangeRate = 1;

        //                        invoice.Currency = (invoiceCfdi.Comprobante.Attributes["Moneda"].Value ?? "");
        //                        invoice.IdReceiptType = (invoiceCfdi.Comprobante.Attributes["TipoDeComprobante"].Value ?? "");
        //                        invoice.IdPaymentMethod = (invoiceCfdi.Comprobante.Attributes["MetodoPago"]!= null ? invoiceCfdi.Comprobante.Attributes["MetodoPago"].Value: "");
        //                        invoice.IdFormPayment = (invoiceCfdi.Comprobante.Attributes["FormaPago"]!= null ? invoiceCfdi.Comprobante.Attributes["FormaPago"].Value : "");

        //                        if (invoiceCfdi.Comprobante.Attributes["CondicionesDePago"] != null)
        //                            invoice.PaymentTerms = invoiceCfdi.Comprobante.Attributes["CondicionesDePago"].Value;
        //                        else
        //                            invoice.PaymentTerms = null;

        //                        if (invoiceCfdi.Comprobante.Attributes["Exportacion"] != null)
        //                            invoice.IdExport = invoiceCfdi.Comprobante.Attributes["Exportacion"].Value;
        //                        else
        //                            invoice.IdExport = null;

        //                        if (invoiceCfdi.Comprobante.Attributes["LugarExpedicion"] != null)
        //                            invoice.PlaceExpedition = invoiceCfdi.Comprobante.Attributes["LugarExpedicion"].Value;
        //                        else
        //                            invoice.PlaceExpedition = null;

        //                        invoice.Emitter_RFC = (invoiceCfdi.Emisor.Attributes["Rfc"].Value ?? "");
        //                        invoice.Emitter_Name = (invoiceCfdi.Emisor.Attributes["Nombre"].Value ?? "");

        //                        if (invoiceCfdi.Emisor.Attributes["RegimenFiscal"] != null)
        //                            invoice.Emitter_IdFiscalRegime = invoiceCfdi.Emisor.Attributes["RegimenFiscal"].Value;
        //                        else
        //                            invoice.Emitter_IdFiscalRegime = null;

        //                        invoice.Receptor_RFC = (invoiceCfdi.Receptor.Attributes["Rfc"].Value ?? "");
        //                        invoice.Receptor_Name = (invoiceCfdi.Receptor.Attributes["Nombre"].Value ?? "");

        //                        if (invoiceCfdi.Receptor.Attributes["DomicilioFiscalReceptor"] != null)
        //                            invoice.Receptor_TaxDomicile = invoiceCfdi.Receptor.Attributes["DomicilioFiscalReceptor"].Value;
        //                        else
        //                            invoice.Receptor_TaxDomicile = null;

        //                        if (invoiceCfdi.Receptor.Attributes["RegimenFiscalReceptor"] != null)
        //                            invoice.Receptor_IdFiscalRegime = invoiceCfdi.Receptor.Attributes["RegimenFiscalReceptor"].Value;
        //                        else
        //                            invoice.Receptor_IdFiscalRegime = null;

        //                        if (invoiceCfdi.Receptor.Attributes["UsoCFDI"] != null)
        //                            invoice.Receptor_IdUseCFDI = invoiceCfdi.Receptor.Attributes["UsoCFDI"].Value;
        //                        else
        //                            invoice.Receptor_IdUseCFDI = null;

        //                        invoice.PurchaseOrder = null;
        //                        if (satCFDI != null)
        //                            invoice.Comments = "Validación del SAT: (Estado) " + satCFDI.ESTADO + " | (Descripción) " + satCFDI.CODIGO_ESTATUS + (!satCFDI.ES_CANCELABLE.Equals("") ? " | (¿Es Cancelable?) " + satCFDI.ES_CANCELABLE : "") + (!satCFDI.ESTATUS_CANCELACION.Equals("") ? " | (Estado de Cancelación) " + satCFDI.ESTATUS_CANCELACION : "");
        //                        else
        //                            invoice.Comments = null;
        //                        invoice.Version = invoiceCfdi.version;


        //                        //Nuevo nombre final del archivo RFC_EMISOR + AÑO + MES + DIA + SERIE + FOLIO
        //                        string xmlNewFilename = invoice.Emitter_RFC + "-" + invoice.InvoiceDate.ToString("yyyy") + invoice.InvoiceDate.ToString("MM") + invoice.InvoiceDate.ToString("dd") + "-" + invoice.Serie + invoice.Folio + ".xml";

        //                        //Comprobar que el proveedor existe en la base de datos y que fue configurado para usarse en la compañia y unidad de negocio
        //                        List<int> idSuppliers = await _repositoryContext.Suppliers.Where(x => x.RFC.Equals(invoice.Emitter_RFC)).Select(x => x.IdSupplier).ToListAsync();
        //                        if (idSuppliers.Count == 0)
        //                        {
        //                            localError = true;
        //                            uploadResults.Add(new UploadResult
        //                            {
        //                                IdInvoice = invoice.IdPreInvoice,
        //                                UUID = UUID,
        //                                EmitterRFC = invoice.Emitter_RFC,
        //                                EmitterName = invoice.Emitter_Name,
        //                                Filename = file.FileName,
        //                                Serie = invoice.Serie,
        //                                Folio = invoice.Folio,
        //                                SupportXMLFile = xmlNewFilename,
        //                                SupportPath = appSettings.RelativeServerFolder + pathServerFolder + "\\",
        //                                SupportPDFFile = "",
        //                                InvoiceDate = invoice.InvoiceDate,
        //                                TotalInvoice = invoice.Total,
        //                                TypeFile = file.ContentType,
        //                                Version = invoice.Version,
        //                                CreatedDate = DateTime.Now,
        //                                Description = "El proveedor con RFC: " + invoice.Emitter_RFC + " y Nombre: " + invoice.Emitter_Name + ", no existe para el comprobante con UUID: " + invoice.UUID + ", favor de crear el registro del proveedor antes de realizar este proceso",
        //                                Status = false
        //                            });

        //                            if (file != null)
        //                            {
        //                                bool exists = System.IO.Directory.Exists(appSettings.PhysicalServerFolder + "\\" + pathServerFolder);

        //                                //Comprobar si existe el directorio
        //                                if (!exists)
        //                                    System.IO.Directory.CreateDirectory(appSettings.PhysicalServerFolder + "\\" + pathServerFolder);

        //                                //Crear el archivo xml y guadar su contenido
        //                                using (var stream = System.IO.File.Create(appSettings.PhysicalServerFolder + "\\" + pathServerFolder + "\\" + xmlNewFilename))
        //                                {
        //                                    await file.CopyToAsync(stream);
        //                                }
        //                            }
                                        
        //                        }
        //                        else
        //                        {
        //                        List<int> idCompanySupplier = await _repositoryContext.CompanySuppliers.Where(x => x.IdCompany == appSettings.Configuration.PrincipalIdCompany.Value && x.IdBranchCompany == invoice.IdBranchCompany && x.IdBusinessUnit == invoice.IdBusinessUnit).Select(x => x.IdSupplier).Distinct().ToListAsync();
        //                        if (idCompanySupplier.Count == 0)
        //                        {
        //                            localError = true;
        //                            uploadResults.Add(new UploadResult
        //                            {
        //                                IdInvoice = invoice.IdPreInvoice,
        //                                UUID = UUID,
        //                                EmitterRFC = invoice.Emitter_RFC,
        //                                EmitterName = invoice.Emitter_Name,
        //                                Filename = file.FileName,
        //                                Serie = invoice.Serie,
        //                                Folio = invoice.Folio,
        //                                SupportXMLFile = xmlNewFilename,
        //                                SupportPath = appSettings.RelativeServerFolder + pathServerFolder + "\\",
        //                                SupportPDFFile = "",
        //                                InvoiceDate = invoice.InvoiceDate,
        //                                TotalInvoice = invoice.Total,
        //                                TypeFile = file.ContentType,
        //                                Version = invoice.Version,
        //                                CreatedDate = DateTime.Now,
        //                                Description = "El proveedor con RFC: " + invoice.Emitter_RFC + " y Nombre: " + invoice.Emitter_Name + ", existe en la base de datos pero no se ha establecido para la compañia y unidad de negocio del comprobante con UUID: " + invoice.UUID,
        //                                Status = false
        //                            });
                                    
        //                                if (file != null)
        //                                {
        //                                    bool exists = System.IO.Directory.Exists(appSettings.PhysicalServerFolder + "\\" + pathServerFolder);

        //                                    //Comprobar si existe el directorio
        //                                    if (!exists)
        //                                        System.IO.Directory.CreateDirectory(appSettings.PhysicalServerFolder + "\\" + pathServerFolder);

        //                                    //Crear el archivo xml y guadar su contenido
        //                                    using (var stream = System.IO.File.Create(appSettings.PhysicalServerFolder + "\\" + pathServerFolder + "\\" + xmlNewFilename))
        //                                    {
        //                                        await file.CopyToAsync(stream);
        //                                    }
        //                                }
        //                        }
        //                    }

        //                        //Validacion del SAT
        //                        if(localError == false)
        //                        {
        //                            if(!satCFDI.ESTADO.Equals("Vigente"))
        //                            {
        //                                localError = true;
        //                                uploadResults.Add(new UploadResult
        //                                {
        //                                    IdInvoice = invoice.IdPreInvoice,
        //                                    UUID = UUID,
        //                                    EmitterRFC = invoice.Emitter_RFC,
        //                                    EmitterName = invoice.Emitter_Name,
        //                                    Filename = file.FileName,
        //                                    Serie = invoice.Serie,
        //                                    Folio = invoice.Folio,
        //                                    SupportXMLFile = null,
        //                                    SupportPath = appSettings.RelativeServerFolder + pathServerFolder + "\\",
        //                                    SupportPDFFile = "",
        //                                    InvoiceDate = invoice.InvoiceDate,
        //                                    TotalInvoice = invoice.Total,
        //                                    TypeFile = file.ContentType,
        //                                    Version = invoice.Version,
        //                                    CreatedDate = DateTime.Now, 
        //                                    Description = "Validación del SAT: (Estado) " + satCFDI.ESTADO + " | (Descripción) " + satCFDI.CODIGO_ESTATUS + (!satCFDI.ESTATUS_CANCELACION.Equals("") ? " | " + satCFDI.ESTATUS_CANCELACION: ""),
        //                                    Status = false
        //                                });
        //                            }
        //                        }

        //                        //Recuperar informacion de proveedor
        //                        Supplier supplier = await _repositoryContext.Suppliers.SingleOrDefaultAsync(x => x.IdSupplier == idSuppliers[0]);

        //                        //Revisar permisos especiales de carga de facturas
        //                        bool AllowUploadInvoiceSupportFile = false;
        //                        bool AllowUploadInvoiceWithoutOC = false;

        //                        if(personInvoicePrivilegesDetail.Count()>0)
        //                        {
        //                            //Verificar si el proveedor esta en los permisos especiales asignados a la persona
        //                            if(personInvoicePrivilegesDetail.Count(x=>x.IdSupplier == supplier.IdSupplier) > 0)
        //                            {
        //                                vtPersonInvoicePrivilegesDetail detailPrivilege = personInvoicePrivilegesDetail.SingleOrDefault(x => x.IdSupplier == supplier.IdSupplier);
        //                                //Obtener los permisos
        //                                if (detailPrivilege.AllowUploadInvoiceSupportFile)
        //                                    AllowUploadInvoiceSupportFile = true;
        //                                if (detailPrivilege.AllowUploadInvoiceWithoutOC)
        //                                    AllowUploadInvoiceWithoutOC = true;
        //                            }
        //                        }

        //                        //Guardar archivo xml
        //                        if (file != null)
        //                        {
        //                            bool exists = System.IO.Directory.Exists(appSettings.PhysicalServerFolder + "\\" + pathServerFolder);

        //                            //Comprobar si existe el directorio
        //                            if (!exists)
        //                                System.IO.Directory.CreateDirectory(appSettings.PhysicalServerFolder + "\\" + pathServerFolder);

        //                            //Crear el archivo xml y guadar su contenido
        //                            using (var stream = System.IO.File.Create(appSettings.PhysicalServerFolder + "\\" + pathServerFolder + "\\" + xmlNewFilename))
        //                            {
        //                                await file.CopyToAsync(stream);

        //                                invoice.XML_OriginalFileName = file.FileName;
        //                                invoice.XML_FileName = xmlNewFilename;
        //                                invoice.XML_Length = file.Length;
        //                                invoice.XML_Path = appSettings.RelativeServerFolder + pathServerFolder + "\\";
        //                                invoice.XML_Content = XElement.Parse(xDocument.OuterXml.ToString());
        //                            }
        //                        }

        //                        //Guardar el objeto en la base de datos
        //                        _repositoryContext.Entry(invoice).State = EntityState.Added;
        //                        await _repositoryContext.SaveChangesAsync();

        //                        //Agrear la referencia de carga
        //                        if (!localError)
        //                            uploadResults.Add(new UploadResult
        //                            {
        //                                IdInvoice = invoice.IdPreInvoice,
        //                                UUID = UUID,
        //                                EmitterRFC = invoice.Emitter_RFC,
        //                                EmitterName = invoice.Emitter_Name,
        //                                Filename = file.FileName,
        //                                Serie = invoice.Serie,
        //                                Folio = invoice.Folio,
        //                                SupportXMLFile = xmlNewFilename,
        //                                SupportPath = appSettings.RelativeServerFolder + pathServerFolder + "\\",
        //                                SupportPDFFile = "",
        //                                InvoiceDate = invoice.InvoiceDate,
        //                                TotalInvoice = invoice.Total,
        //                                TypeFile = file.ContentType,
        //                                Version = invoice.Version,
        //                                CreatedDate = DateTime.Now,
        //                                Description = "Cargado con éxito",
        //                                Status = true,
        //                                AllowUploadInvoiceSupportFile = AllowUploadInvoiceSupportFile,
        //                                AllowUploadInvoiceWithoutOC = AllowUploadInvoiceWithoutOC
        //                            });

        //                    }
        //                    else
        //                    {
        //                        //Agrear la referencia de carga
        //                        PreInvoice invalidInvoice = await _repositoryContext.PreInvoices.OrderBy(x => x.IdPreInvoice).LastOrDefaultAsync(x => x.UUID.Equals(UUID));

        //                        uploadResults.Add(new UploadResult
        //                        {
        //                            IdInvoice = 0,
        //                            UUID = UUID,
        //                            EmitterRFC = invalidInvoice.Emitter_RFC,
        //                            EmitterName = invalidInvoice.Emitter_Name,
        //                            Filename = invalidInvoice.XML_FileName,
        //                            Serie = invalidInvoice.Serie,
        //                            Folio = invalidInvoice.Folio,
        //                            SupportXMLFile = invalidInvoice.XML_FileName,
        //                            SupportPath = invalidInvoice.XML_Path,
        //                            SupportPDFFile = invalidInvoice.PDF_FileName,
        //                            InvoiceDate = invalidInvoice.InvoiceDate,
        //                            TotalInvoice = invalidInvoice.Total,
        //                            TypeFile = file.ContentType,
        //                            Version = invoiceCfdi.version,
        //                            CreatedDate = DateTime.Now,
        //                            Description = "El comprobante ya existe en la base de datos",
        //                            Status = false
        //                        });
        //                    }

        //                }
        //                else if (file.ContentType.ToLower().Equals("application/pdf"))
        //                {
        //                    string pdfFilename = file.FileName.ToLower().Replace(".pdf", "");
        //                    string UUID = "";

        //                    if (files.Count() > 1)
        //                    {
        //                        //MultiFiles
        //                        foreach (IFormFile xmlFile in files.Where(x => x.ContentType.ToLower().Equals("text/xml")))
        //                        {
        //                            string xmlFilename = xmlFile.FileName.Replace(".xml", "");

        //                            if (xmlFilename.ToUpper().Equals(pdfFilename.ToUpper()))
        //                            {
        //                                //Obtener el documento xml
        //                                XmlDocument xDocument = await InvoiceHelper.GetFileXMLAsync(xmlFile);
        //                                //Cargar los nodos requeridos del xml para obtener el UUID
        //                                InvoiceCfdi invoiceCfdi = new InvoiceCfdi(xDocument.OuterXml);
        //                                UUID = invoiceCfdi.UUID;

        //                                //Buscar el registro en la base
        //                                PreInvoice pdfInvoice = await _repositoryContext.PreInvoices.OrderBy(x => x.IdPreInvoice).LastOrDefaultAsync(x => x.UUID.Equals(UUID));
        //                                string pdfNewFilename = pdfInvoice.XML_FileName.ToUpper().Replace(".xml", "").Replace(".XML", "") + ".pdf";

        //                                //Guardar los datos del pdf
        //                                if (pdfInvoice.PDF_FileName == null)
        //                                {
        //                                    string pathServerFolder = "PreInvoices\\" + (invoiceCfdi.Emisor.Attributes["Rfc"].Value ?? "") + "\\" + invoiceCfdi.Fecha.Year.ToString();
        //                                    //Crear el archivo xml y guadar su contenido
        //                                    using (var stream = System.IO.File.Create(appSettings.PhysicalServerFolder + "\\" + pathServerFolder + "\\" + pdfNewFilename))
        //                                    {
        //                                        await file.CopyToAsync(stream);

        //                                        pdfInvoice.PDF_FileName = pdfNewFilename;
        //                                        pdfInvoice.PDF_Length = file.Length;
        //                                        pdfInvoice.PDF_Path = pdfInvoice.XML_Path;
        //                                        pdfInvoice.PDF_CreatedDate = DateTime.Now;
        //                                        _repositoryContext.Entry(pdfInvoice).State = EntityState.Modified;
        //                                        await _repositoryContext.SaveChangesAsync();
        //                                    }

        //                                    //Agrear la referencia de carga
        //                                    uploadResults.Add(new UploadResult
        //                                    {
        //                                        UUID = pdfInvoice.UUID,
        //                                        EmitterName = pdfInvoice.Emitter_Name,
        //                                        Filename = file.FileName,
        //                                        SupportPDFFile = pdfNewFilename,
        //                                        TypeFile = file.ContentType,
        //                                        Version = invoiceCfdi.version,
        //                                        CreatedDate = DateTime.Now,
        //                                        Description = "Cargado con éxito",
        //                                        Status = true
        //                                    });

        //                                    break;
        //                                }
        //                                else
        //                                {
        //                                    //No sepuede cargar el pdf, ya existe un documento
        //                                    uploadResults.Add(new UploadResult
        //                                    {
        //                                        UUID = "",
        //                                        EmitterName = "",
        //                                        Filename = file.FileName,
        //                                        SupportPDFFile = file.FileName,
        //                                        TypeFile = file.ContentType,
        //                                        Version = "",
        //                                        CreatedDate = DateTime.Now,
        //                                        Description = "No sepuede cargar el pdf por que ya existe",
        //                                        Status = false
        //                                    });
        //                                }

        //                            }
        //                        }
        //                    }

        //                }
        //            }

        //            //Asignar los archivos PDF a sus respectivos XML
        //            foreach (UploadResult row in uploadResults)
        //            {
        //                if (row.TypeFile.Equals("text/xml"))
        //                {
        //                    UploadResult pdfFile = uploadResults.SingleOrDefault(x => x.TypeFile.Equals("application/pdf") && x.UUID.Equals(row.UUID));
        //                    if (pdfFile != null)
        //                    {
        //                        row.SupportPDFFile = pdfFile.SupportPDFFile;
        //                    }
        //                }
        //            }
        //        }
        //        else
        //            throw new Exception("Solo se permite cargar facturas hasta los días 25 de cada mes como fecha límite");

        //        return await Task.FromResult(uploadResults.Where(x=>x.TypeFile.Equals("text/xml")).OrderByDescending(x=>x.TypeFile).ThenBy(x=>x.EmitterName).ThenBy(x=>x.Filename).ToList());

        //    }
        //    catch (Exception ex)
        //    {
        //        throw(ex);
        //    }
        //}

        //public async Task<List<UploadResult>> UploadAsync(List<IFormFile> files, int idPerson, int idBranchCompany, int idBusinessUnit, string supplierRFC) {
        //    try {
        //        AppSettings appSettings = new AppSettings();
        //        List<UploadResult> uploadResults = new List<UploadResult>();
        //        vtPerson person = (await PersonHelper.GetViewAsync(idPerson));
        //        SupplierWebApp.Entities.C5PortalWebApp.BranchCompany branchCompany = await BranchCompanyHelper.GetAsync(idBranchCompany);
        //        string KeyID = PreInvoiceHelper.GetKeyID(10);
        //        bool uploadInvoiceOutOfPeriod = (PersonHelper.GetByPrivilegeAsync(idPerson, (int)Enumerators.Applications.SupplierWebApp).Result).Count(x => x.RuleName.Equals("APP_PORTALWEBAPPS_SUPPLIER_UPLOAD_INVOICE_OUT_OF_PERIOD")) > 0;

        //        //Validar si puede subir facturas en la fecha de corte
        //        DateTime currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        //        //DateTime currentDate = new DateTime(2023, 12, 1);
        //        DateTime deadline = new DateTime(currentDate.Year, currentDate.Month, appSettings.Configuration.MonthlyInvoiceDeadline.Value);

        //        if (currentDate <= deadline || uploadInvoiceOutOfPeriod)
        //        {
        //            foreach (IFormFile file in files.OrderByDescending(x => x.ContentType))
        //            {
        //                PreInvoice invoice = new PreInvoice();
        //                if (file.ContentType.ToLower().Equals("text/xml"))
        //                {
        //                    //Obtener la validacion mediante el SAT
        //                    CFDI satCFDI = await InvoiceHelper.GetCFDI(file);

        //                    //Obtener el documento xml
        //                    XmlDocument xDocument = await InvoiceHelper.GetFileXMLAsync(file);
        //                    //Cargar los nodos requeridos del xml
        //                    InvoiceCfdi invoiceCfdi = new InvoiceCfdi(xDocument.OuterXml);
        //                    string pathServerFolder = "PreInvoices\\" + (invoiceCfdi.Emisor.Attributes["Rfc"].Value ?? "") + "\\" + invoiceCfdi.Fecha.Year.ToString();
        //                    string UUID = invoiceCfdi.TimbreFiscal.Attributes["UUID"].Value;

        //                    //Comprobar que no existe en la tabla el UUID
        //                    if (_repositoryContext.PreInvoices.Count(x => x.UUID.Equals(UUID) && x.IdStatus == (int)Enumerators.StatusPreInvoice.Completed) == 0)
        //                    {
        //                        //Cargar los atributos xml al objeto de tabla
        //                        invoice.KeyID = KeyID;
        //                        invoice.IdPerson = idPerson;
        //                        invoice.IdCompany = appSettings.Configuration.PrincipalIdCompany.Value;

        //                        if (person.IdTypeAccount == (int)Enumerators.TypeAccount.Collaborator)
        //                            invoice.IdCompany = person.IdCompany.Value;

        //                        invoice.IdBranchCompany = idBranchCompany;
        //                        invoice.IdBusinessUnit = idBusinessUnit;
        //                        invoice.IdStatus = (int)Enumerators.StatusInvoice.Pending;
        //                        invoice.UUID = UUID;
        //                        if (invoiceCfdi.Comprobante.Attributes["Serie"] != null)
        //                            invoice.Serie = invoiceCfdi.Comprobante.Attributes["Serie"].Value;
        //                        else
        //                            invoice.Serie = null;
        //                        if (invoiceCfdi.Comprobante.Attributes["Folio"] != null)
        //                            invoice.Folio = invoiceCfdi.Comprobante.Attributes["Folio"].Value;
        //                        else
        //                            invoice.Folio = null;
        //                        invoice.InvoiceDate = Convert.ToDateTime(invoiceCfdi.Comprobante.Attributes["Fecha"].Value);
        //                        invoice.CreatedDate = DateTime.Now;
        //                        invoice.SubTotal = Convert.ToDecimal(invoiceCfdi.Comprobante.Attributes["SubTotal"].Value ?? "");
        //                        invoice.Discount = Convert.ToDecimal(invoiceCfdi.Comprobante.Attributes["Descuento"] != null ? invoiceCfdi.Comprobante.Attributes["Descuento"].Value : 0);
        //                        invoice.TransferredTax = invoiceCfdi.TotalImpuestosTrasladados;
        //                        invoice.RetainedTax = invoiceCfdi.TotalImpuestosRetenidos;
        //                        invoice.Total = Convert.ToDecimal(invoiceCfdi.Comprobante.Attributes["Total"].Value ?? "");
        //                        if (invoiceCfdi.Comprobante.Attributes["TipoCambio"] != null)
        //                            invoice.ExchangeRate = Convert.ToDecimal(invoiceCfdi.Comprobante.Attributes["TipoCambio"].Value);
        //                        else
        //                            invoice.ExchangeRate = 1;

        //                        invoice.Currency = (invoiceCfdi.Comprobante.Attributes["Moneda"].Value ?? "");
        //                        invoice.IdReceiptType = (invoiceCfdi.Comprobante.Attributes["TipoDeComprobante"].Value ?? "");
        //                        invoice.IdPaymentMethod = (invoiceCfdi.Comprobante.Attributes["MetodoPago"] != null ? invoiceCfdi.Comprobante.Attributes["MetodoPago"].Value: "");
        //                        invoice.IdFormPayment = (invoiceCfdi.Comprobante.Attributes["FormaPago"] != null ? invoiceCfdi.Comprobante.Attributes["FormaPago"].Value :"");

        //                        if (invoiceCfdi.Comprobante.Attributes["CondicionesDePago"] != null)
        //                            invoice.PaymentTerms = invoiceCfdi.Comprobante.Attributes["CondicionesDePago"].Value;
        //                        else
        //                            invoice.PaymentTerms = null;

        //                        if (invoiceCfdi.Comprobante.Attributes["Exportacion"] != null)
        //                            invoice.IdExport = invoiceCfdi.Comprobante.Attributes["Exportacion"].Value;
        //                        else
        //                            invoice.IdExport = null;

        //                        if (invoiceCfdi.Comprobante.Attributes["LugarExpedicion"] != null)
        //                            invoice.PlaceExpedition = invoiceCfdi.Comprobante.Attributes["LugarExpedicion"].Value;
        //                        else
        //                            invoice.PlaceExpedition = null;

        //                        invoice.Emitter_RFC = (invoiceCfdi.Emisor.Attributes["Rfc"].Value ?? "");
        //                        invoice.Emitter_Name = (invoiceCfdi.Emisor.Attributes["Nombre"].Value ?? "");

        //                        if (invoiceCfdi.Emisor.Attributes["RegimenFiscal"] != null)
        //                            invoice.Emitter_IdFiscalRegime = invoiceCfdi.Emisor.Attributes["RegimenFiscal"].Value;
        //                        else
        //                            invoice.Emitter_IdFiscalRegime = null;

        //                        invoice.Receptor_RFC = (invoiceCfdi.Receptor.Attributes["Rfc"].Value ?? "");
        //                        invoice.Receptor_Name = (invoiceCfdi.Receptor.Attributes["Nombre"].Value ?? "");

        //                        if (invoiceCfdi.Receptor.Attributes["DomicilioFiscalReceptor"] != null)
        //                            invoice.Receptor_TaxDomicile = invoiceCfdi.Receptor.Attributes["DomicilioFiscalReceptor"].Value;
        //                        else
        //                            invoice.Receptor_TaxDomicile = null;

        //                        if (invoiceCfdi.Receptor.Attributes["RegimenFiscalReceptor"] != null)
        //                            invoice.Receptor_IdFiscalRegime = invoiceCfdi.Receptor.Attributes["RegimenFiscalReceptor"].Value;
        //                        else
        //                            invoice.Receptor_IdFiscalRegime = null;

        //                        if (invoiceCfdi.Receptor.Attributes["UsoCFDI"] != null)
        //                            invoice.Receptor_IdUseCFDI = invoiceCfdi.Receptor.Attributes["UsoCFDI"].Value;
        //                        else
        //                            invoice.Receptor_IdUseCFDI = null;

        //                        invoice.PurchaseOrder = null;
        //                        if (satCFDI != null)
        //                            invoice.Comments = "Validación del SAT: (Estado) " + satCFDI.ESTADO + " | (Descripción) " + satCFDI.CODIGO_ESTATUS + (!satCFDI.ES_CANCELABLE.Equals("") ? " | (¿Es Cancelable?) " + satCFDI.ES_CANCELABLE : "") + (!satCFDI.ESTATUS_CANCELACION.Equals("") ? " | (Estado de Cancelación) " + satCFDI.ESTATUS_CANCELACION : "");
        //                        else
        //                            invoice.Comments = null;
        //                        invoice.Version = invoiceCfdi.version;

        //                        //Validar aqui que le RFC del proveedor sea el mismo de la factura
        //                        if (!supplierRFC.Equals(invoice.Emitter_RFC))
        //                        {
        //                            PreInvoice invalidInvoice = await _repositoryContext.PreInvoices.OrderBy(x => x.IdPreInvoice).LastOrDefaultAsync(x => x.UUID.Equals(UUID));
        //                            uploadResults.Add(new UploadResult
        //                            {
        //                                IdInvoice = 0,
        //                                UUID = UUID,
        //                                EmitterRFC = invoice.Emitter_RFC,
        //                                EmitterName = invoice.Emitter_Name,
        //                                Filename = invoice.XML_FileName,
        //                                Serie = invoice.Serie,
        //                                Folio = invoice.Folio,
        //                                SupportXMLFile = invoice.XML_FileName,
        //                                SupportPath = invoice.XML_Path,
        //                                SupportPDFFile = invoice.PDF_FileName,
        //                                InvoiceDate = invoice.InvoiceDate,
        //                                TotalInvoice = invoice.Total,
        //                                TypeFile = file.ContentType,
        //                                Version = invoice.Version,
        //                                CreatedDate = DateTime.Now,
        //                                Description = "El RFC(" + invoice.Emitter_RFC + ") emisor del comprobante no coincide con el RFC del proveedor(" + supplierRFC + ")",
        //                                Status = false
        //                            });
        //                        }
        //                        else if (!branchCompany.RFC.Equals(invoice.Receptor_RFC))
        //                        {
        //                            PreInvoice invalidInvoice = await _repositoryContext.PreInvoices.OrderBy(x => x.IdPreInvoice).LastOrDefaultAsync(x => x.UUID.Equals(UUID));
        //                            uploadResults.Add(new UploadResult
        //                            {
        //                                IdInvoice = 0,
        //                                UUID = UUID,
        //                                EmitterRFC = invoice.Emitter_RFC,
        //                                EmitterName = invoice.Emitter_Name,
        //                                Filename = invoice.XML_FileName,
        //                                Serie = invoice.Serie,
        //                                Folio = invoice.Folio,
        //                                SupportXMLFile = invoice.XML_FileName,
        //                                SupportPath = invoice.XML_Path,
        //                                SupportPDFFile = invoice.PDF_FileName,
        //                                InvoiceDate = invoice.InvoiceDate,
        //                                TotalInvoice = invoice.Total,
        //                                TypeFile = file.ContentType,
        //                                Version = invoice.Version,
        //                                CreatedDate = DateTime.Now,
        //                                Description = "El RFC(" + invoice.Receptor_RFC + ") receptor del comprobante no coincide con el RFC de la compañia(" + branchCompany.RFC + ")",
        //                                Status = false
        //                            });
        //                        }
        //                        else if(!satCFDI.ESTADO.Equals("Vigente"))
        //                        {
        //                            //Validacion del SAT
        //                            uploadResults.Add(new UploadResult
        //                            {
        //                                IdInvoice = invoice.IdPreInvoice,
        //                                UUID = UUID,
        //                                EmitterRFC = invoice.Emitter_RFC,
        //                                EmitterName = invoice.Emitter_Name,
        //                                Filename = file.FileName,
        //                                Serie = invoice.Serie,
        //                                Folio = invoice.Folio,
        //                                SupportXMLFile = null,
        //                                SupportPath = appSettings.RelativeServerFolder + pathServerFolder + "\\",
        //                                SupportPDFFile = "",
        //                                InvoiceDate = invoice.InvoiceDate,
        //                                TotalInvoice = invoice.Total,
        //                                TypeFile = file.ContentType,
        //                                Version = invoice.Version,
        //                                CreatedDate = DateTime.Now,
        //                                Description = "Validación del SAT: (Estado) " + satCFDI.ESTADO + " | (Descripción) " + satCFDI.CODIGO_ESTATUS + (!satCFDI.ESTATUS_CANCELACION.Equals("") ? " | " + satCFDI.ESTATUS_CANCELACION : ""),
        //                                Status = false
        //                            });
        //                        }
        //                        else
        //                        {
                                    
        //                            //Nuevo nombre final del archivo RFC_EMISOR + AÑO + MES + DIA + SERIE + FOLIO
        //                            string xmlNewFilename = invoice.Emitter_RFC + "-" + invoice.InvoiceDate.ToString("yyyy") + invoice.InvoiceDate.ToString("MM") + invoice.InvoiceDate.ToString("dd") + "-" + invoice.Serie + invoice.Folio + ".xml";

        //                            //Guardar archivo xml
        //                            if (file != null)
        //                            {
        //                                bool exists = System.IO.Directory.Exists(appSettings.PhysicalServerFolder + "\\" + pathServerFolder);

        //                                //Comprobar si existe el directorio
        //                                if (!exists)
        //                                    System.IO.Directory.CreateDirectory(appSettings.PhysicalServerFolder + "\\" + pathServerFolder);

        //                                //Crear el archivo xml y guadar su contenido
        //                                using (var stream = System.IO.File.Create(appSettings.PhysicalServerFolder + "\\" + pathServerFolder + "\\" + xmlNewFilename))
        //                                {
        //                                    await file.CopyToAsync(stream);

        //                                    invoice.XML_OriginalFileName = file.FileName;
        //                                    invoice.XML_FileName = xmlNewFilename;
        //                                    invoice.XML_Length = file.Length;
        //                                    invoice.XML_Path = appSettings.RelativeServerFolder + pathServerFolder + "\\";
        //                                    invoice.XML_Content = XElement.Parse(xDocument.OuterXml.ToString());
        //                                }
        //                            }

        //                            //Recuperar informacion de proveedor
        //                            Supplier supplier = await _repositoryContext.Suppliers.SingleOrDefaultAsync(x => x.RFC.Equals(supplierRFC));

        //                            //Revisar permisos especiales de carga de facturas
        //                            bool AllowUploadInvoiceSupportFile = false;
        //                            bool AllowUploadInvoiceWithoutOC = false;
                                    
        //                            if (supplier != null)
        //                            {
        //                                if (supplier.AllowUploadInvoiceSupportFile ?? false)
        //                                    AllowUploadInvoiceSupportFile = true;
        //                                if(supplier.AllowUploadInvoiceWithoutOC ?? false)
        //                                    AllowUploadInvoiceWithoutOC = true;
        //                            }
                                    
        //                            //Guardar el objeto en la base de datos
        //                            _repositoryContext.Entry(invoice).State = EntityState.Added;
        //                            await _repositoryContext.SaveChangesAsync();

        //                            //Agrear la referencia de carga
        //                            uploadResults.Add(new UploadResult
        //                            {
        //                                IdInvoice = invoice.IdPreInvoice,
        //                                UUID = UUID,
        //                                EmitterRFC = invoice.Emitter_RFC,
        //                                EmitterName = invoice.Emitter_Name,
        //                                Filename = file.FileName,
        //                                Serie = invoice.Serie,
        //                                Folio = invoice.Folio,
        //                                SupportXMLFile = xmlNewFilename,
        //                                SupportPath = appSettings.RelativeServerFolder + pathServerFolder + "\\",
        //                                SupportPDFFile = "",
        //                                InvoiceDate = invoice.InvoiceDate,
        //                                TotalInvoice = invoice.Total,
        //                                TypeFile = file.ContentType,
        //                                Version = invoice.Version,
        //                                CreatedDate = DateTime.Now,
        //                                Description = "Cargado con éxito",
        //                                Status = true,
        //                                AllowUploadInvoiceSupportFile = AllowUploadInvoiceSupportFile,
        //                                AllowUploadInvoiceWithoutOC = AllowUploadInvoiceWithoutOC
        //                            });

        //                        }
        //                    }
        //                    else
        //                    {
        //                        //Agrear la referencia de carga
        //                        PreInvoice invalidInvoice = await _repositoryContext.PreInvoices.OrderBy(x => x.IdPreInvoice).LastOrDefaultAsync(x => x.UUID.Equals(UUID));
        //                        uploadResults.Add(new UploadResult
        //                        {
        //                            IdInvoice = 0,
        //                            UUID = UUID,
        //                            EmitterRFC = invalidInvoice.Emitter_RFC,
        //                            EmitterName = invalidInvoice.Emitter_Name,
        //                            Filename = invalidInvoice.XML_FileName,
        //                            Serie = invalidInvoice.Serie,
        //                            Folio = invalidInvoice.Folio,
        //                            SupportXMLFile = invalidInvoice.XML_FileName,
        //                            SupportPath = invalidInvoice.XML_Path,
        //                            SupportPDFFile = invalidInvoice.PDF_FileName,
        //                            InvoiceDate = invalidInvoice.InvoiceDate,
        //                            TotalInvoice = invalidInvoice.Total,
        //                            TypeFile = file.ContentType,
        //                            Version = invoiceCfdi.version,
        //                            CreatedDate = DateTime.Now,
        //                            Description = "El comprobante ya existe en la base de datos",
        //                            Status = false
        //                        });
        //                    }

        //                }
        //                else if (file.ContentType.ToLower().Equals("application/pdf"))
        //                {
        //                    string pdfFilename = file.FileName.ToLower().Replace(".pdf", "");
        //                    string UUID = "";

        //                    if (files.Count() > 1)
        //                    {
        //                        //MultiFiles
        //                        foreach (IFormFile xmlFile in files.Where(x => x.ContentType.ToLower().Equals("text/xml")))
        //                        {
        //                            string xmlFilename = xmlFile.FileName.Replace(".xml", "");

        //                            if (xmlFilename.ToUpper().Equals(pdfFilename.ToUpper()))
        //                            {
        //                                //Obtener el documento xml
        //                                XmlDocument xDocument = await InvoiceHelper.GetFileXMLAsync(xmlFile);
        //                                //Cargar los nodos requeridos del xml para obtener el UUID
        //                                InvoiceCfdi invoiceCfdi = new InvoiceCfdi(xDocument.OuterXml);
        //                                UUID = invoiceCfdi.UUID;

        //                                //Buscar el registro en la base
        //                                PreInvoice pdfInvoice = await _repositoryContext.PreInvoices.OrderBy(x => x.IdPreInvoice).LastOrDefaultAsync(x=>x.UUID.Equals(UUID));
        //                                if (pdfInvoice == null)
        //                                {
        //                                    //No se encontro el comprobante .xml relacionado al .pdf
        //                                    uploadResults.Add(new UploadResult
        //                                    {
        //                                        UUID = "",
        //                                        EmitterName = "",
        //                                        Filename = file.FileName,
        //                                        SupportPDFFile = file.FileName,
        //                                        TypeFile = file.ContentType,
        //                                        Version = "",
        //                                        CreatedDate = DateTime.Now,
        //                                        Description = "No se encontro el comprobante .xml relacionado al .pdf",
        //                                        Status = false
        //                                    });
        //                                }
        //                                else
        //                                {
        //                                    //Guardar los datos del pdf
        //                                    if (pdfInvoice.PDF_FileName == null)
        //                                    {
        //                                        string pdfNewFilename = pdfInvoice.XML_FileName.ToUpper().Replace(".xml", "").Replace(".XML", "") + ".pdf";
        //                                        string pathServerFolder = "PreInvoices\\" + (invoiceCfdi.Emisor.Attributes["Rfc"].Value ?? "") + "\\" + invoiceCfdi.Fecha.Year.ToString();
        //                                        //Crear el archivo xml y guadar su contenido
        //                                        using (var stream = System.IO.File.Create(appSettings.PhysicalServerFolder + "\\" + pathServerFolder + "\\" + pdfNewFilename))
        //                                        {
        //                                            await file.CopyToAsync(stream);

        //                                            pdfInvoice.PDF_FileName = pdfNewFilename;
        //                                            pdfInvoice.PDF_Length = file.Length;
        //                                            pdfInvoice.PDF_Path = pdfInvoice.XML_Path;
        //                                            pdfInvoice.PDF_CreatedDate = DateTime.Now;
        //                                            _repositoryContext.Entry(pdfInvoice).State = EntityState.Modified;
        //                                            await _repositoryContext.SaveChangesAsync();
        //                                        }

        //                                        //Agrear la referencia de carga
        //                                        uploadResults.Add(new UploadResult
        //                                        {
        //                                            UUID = pdfInvoice.UUID,
        //                                            EmitterName = pdfInvoice.Emitter_Name,
        //                                            Filename = file.FileName,
        //                                            SupportPDFFile = pdfNewFilename,
        //                                            TypeFile = file.ContentType,
        //                                            Version = invoiceCfdi.version,
        //                                            CreatedDate = DateTime.Now,
        //                                            Description = "Cargado con éxito",
        //                                            Status = true
        //                                        });

        //                                        break;
        //                                    }
        //                                    else
        //                                    {
        //                                        //No sepuede cargar el pdf, ya existe un documento
        //                                        uploadResults.Add(new UploadResult
        //                                        {
        //                                            UUID = "",
        //                                            EmitterName = "",
        //                                            Filename = file.FileName,
        //                                            SupportPDFFile = file.FileName,
        //                                            TypeFile = file.ContentType,
        //                                            Version = "",
        //                                            CreatedDate = DateTime.Now,
        //                                            Description = "No sepuede cargar el pdf por que ya existe",
        //                                            Status = false
        //                                        });
        //                                    }

        //                                }
        //                            }
        //                        }
        //                    }

        //                }
        //            }

        //            //Asignar los archivos PDF a sus respectivos XML
        //            foreach (UploadResult row in uploadResults)
        //            {
        //                if (row.TypeFile.Equals("text/xml"))
        //                {
        //                    UploadResult pdfFile = uploadResults.SingleOrDefault(x => x.TypeFile.Equals("application/pdf") && x.UUID.Equals(row.UUID));
        //                    if (pdfFile != null)
        //                    {
        //                        row.SupportPDFFile = pdfFile.SupportPDFFile;
        //                    }
        //                }
        //            }

        //        }
        //        else
        //            throw new Exception("Solo se permite cargar facturas hasta los días 25 de cada mes como fecha límite");

        //        return await Task.FromResult(uploadResults.Where(x => x.TypeFile.Equals("text/xml")).OrderByDescending(x => x.TypeFile).ThenBy(x => x.EmitterName).ThenBy(x => x.Filename).ToList());

        //    }
        //    catch (Exception ex) {
        //        throw (ex);
        //    }
        //}

        //public async Task<vtPreInvoice> GetAsync(int idInvoice) {
        //    try {
        //        return await _repositoryContext.vtPreInvoices.SingleOrDefaultAsync(x => x.IdPreInvoice == idInvoice);
        //    }
        //    catch (Exception ex) {
        //        throw(ex);
        //    }
        //}

        //public async Task<List<vtPreInvoice>> GetListAsync(string keyID)
        //{
        //    try
        //    {
        //        return await _repositoryContext.vtPreInvoices.Where(x => x.KeyID.Equals(keyID)).ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw(ex);
        //    }
        //}

        //public async Task<List<ItemsCfdi>> GetItemsAsync(int idInvoice) 
        //{
        //    try {
        //        List<ItemsCfdi> itemsCfdis = new List<ItemsCfdi>();
        //        vtPreInvoice invoice = await _repositoryContext.vtPreInvoices.SingleOrDefaultAsync(x => x.IdPreInvoice == idInvoice);
        //        InvoiceCfdi invoiceCfdi = new InvoiceCfdi(invoice.XML_Content);
        //        var conceptos = invoiceCfdi.Conceptos.ChildNodes;
        //        foreach(XmlElement row in conceptos) {
        //            string objetoImpDescription = (row.Attributes["ObjetoImp"] != null ? _repositoryContext.CatObjetoImps.SingleOrDefault(x=>x.IdObjetoImp.Equals(row.Attributes["ObjetoImp"].Value.ToString())).Description: "");
        //            itemsCfdis.Add(new ItemsCfdi { 
        //                ClaveProdServ = (row.Attributes["ClaveProdServ"]!= null ? row.Attributes["ClaveProdServ"].Value: ""),
        //                ClaveUnidad = (row.Attributes["ClaveUnidad"] != null ? row.Attributes["ClaveUnidad"].Value : ""),
        //                Descripcion = (row.Attributes["Descripcion"] != null ? row.Attributes["Descripcion"].Value : ""),
        //                Cantidad = (row.Attributes["Cantidad"] != null ? decimal.Parse(row.Attributes["Cantidad"].Value) : 0),
        //                Importe = (row.Attributes["Importe"] != null ? decimal.Parse(row.Attributes["Importe"].Value) : 0),
        //                Descuento = (row.Attributes["Descuento"] != null ? decimal.Parse(row.Attributes["Descuento"].Value) : 0),
        //                NoIdentificacion = (row.Attributes["NoIdentificacion"] != null ? row.Attributes["NoIdentificacion"].Value : ""),
        //                ObjetoImp = (row.Attributes["ObjetoImp"] != null ? row.Attributes["ObjetoImp"].Value : ""),
        //                ObjetoImpDescription = objetoImpDescription,
        //                Unidad = (row.Attributes["Unidad"] != null ? row.Attributes["Unidad"].Value : ""),
        //                ValorUnitario = (row.Attributes["ValorUnitario"] != null ? decimal.Parse(row.Attributes["ValorUnitario"].Value) : 0),
        //            });
                    
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
        //        vtPreInvoice invoice = await _repositoryContext.vtPreInvoices.SingleOrDefaultAsync(x => x.IdPreInvoice == idInvoice);
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
        

    }
}
