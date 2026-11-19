using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
//using Org.BouncyCastle.Asn1;
using ServicesWebApp.Entities.SupplierWebApp;
using System.Net.Mail;
using System.Xml.Linq;

namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class SupplierAppRepositoryContext : DbContext
    {
        public SupplierAppRepositoryContext()
        {

        } 

        public SupplierAppRepositoryContext(DbContextOptions<SupplierAppRepositoryContext> options) : base(options)
        {

        }

        public virtual DbSet<CatDocument> CatDocuments { get; set; }
        public virtual DbSet<CatObjetoImp> CatObjetoImps { get; set; }
        public virtual DbSet<CatFiscalRegime> CatFiscalRegimes { get; set; }
        public virtual DbSet<CatFormPayment> CatFormPayments { get; set; }
        public virtual DbSet<CatPriority> CatPriorities { get; set; }
        public virtual DbSet<CatTax> CatTaxes { get; set; }
        public virtual DbSet<CatTypeSupplier> CatTypeSuppliers { get; set; }
        public virtual DbSet<CompanySupplier> CompanySuppliers { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Configuration> Configuration { get; set; }  
        public virtual DbSet<DocumentSupplier> DocumentSuppliers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceAttachment> InvoiceAttachments { get; set; }
        public virtual DbSet<InvoiceAttachmentPPD> InvoiceAttachmentPPDs { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationAttachment> NotificationAttachments { get; set; }
        public virtual DbSet<NotificationResponsible> NotificationResponsibles { get; set; }
        public virtual DbSet<ToNotification> ToNotifications { get; set; }
        public virtual DbSet<PersonInvoicePrivileges> PersonInvoicePrivileges { get; set; }
        public virtual DbSet<PersonInvoicePrivilegesDetail> PersonInvoicePrivilegesDetails { get; set; }
        public virtual DbSet<PreInvoice> PreInvoices { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<PreSupplier> PreSuppliers { get; set; }
        public virtual DbSet<StatusInvoice> StatusInvoices { get; set; }
        public virtual DbSet<StatusNotification> StatusNotifications { get; set; }
        public virtual DbSet<vtContact> VtContacts { get; set; }
        public virtual DbSet<vtInvoice> vtInvoices { get; set; }
        public virtual DbSet<vtInvoiceAttachmentPPD> VtInvoiceAttachmentPPDs { get; set; }
        public virtual DbSet<vtPreInvoice> vtPreInvoices { get; set; }
        public virtual DbSet<vtDocumentSupplier> vtDocumentSuppliers { get; set; }
        public virtual DbSet<vtPersonInvoicePrivileges> VtPersonInvoicePrivileges { get; set; }
        public virtual DbSet<vtPersonInvoicePrivilegesDetail> VtPersonInvoicePrivilegesDetails { get; set; }
        public virtual DbSet<vtNotification> VtNotifications { get; set; }
        public virtual DbSet<vtNotificationResponsible> VtNofiticationResponsibles { get; set; }
        public virtual DbSet<vtPreSupplier> VtPreSuppliers { get; set; }
        public virtual DbSet<vtSupplier> VtSuppliers { get; set; }
        public virtual DbSet<vtToNotification> VtToNotifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var filename = $"appsettings.{envName}.json";
            filename = filename.Replace("..", ".");
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                 .AddJsonFile(filename, optional: false)
                 .Build();

            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.EnableDetailedErrors(true);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SupplierConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatDocument>(entity => {

                entity.HasKey(e => e.IdDocument);

                entity.ToTable("CatDocument", "supplier");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.IdTypeSupplier)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Extension)
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<CatObjetoImp>(entity => {
                entity.HasKey(e => e.IdObjetoImp);

                entity.ToTable("CatObjetoImp");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CatFiscalRegime>(entity => {
                entity.HasKey(e => e.IdFiscalRegime);

                entity.ToTable("CatFiscalRegime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<CatFormPayment>(entity => {
                entity.HasKey(e => e.IdFormPayment);

                entity.ToTable("CatFormPayment");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CatPriority>(entity => {
                entity.HasKey(e => e.IdPriority);

                entity.ToTable("CatPriority");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CatTax>(entity => {
                entity.HasKey(e => e.IdTax);

                entity.ToTable("CatTax");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CatTypeSupplier>(entity => {
                entity.HasKey(e => e.IdTypeSupplier);

                entity.ToTable("CatTypeSupplier", "supplier");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CompanySupplier>(entity => {
                entity.HasKey(e => new { e.IdCompany, e.IdBranchCompany, e.IdBusinessUnit, e.IdSupplier });

                entity.ToTable("CompanySupplier");

            });

            modelBuilder.Entity<Configuration>(entity => {
                entity.HasKey(e => e.Id);

                entity.ToTable("Configuration");

                entity.Property(e => e.DefaultIdCountry)
                    .HasMaxLength(3);

                entity.Property(e => e.DefaultCompany)
                    .HasMaxLength(20);

                entity.Property(e => e.UrlServicesWebApp)
                    .HasMaxLength(200);

                entity.Property(e => e.UrlColaboratorWebApp)
                    .HasMaxLength(200);

                entity.Property(e => e.InvoiceDeadlineMessage)
                    .HasMaxLength(1500);

                entity.Property(e => e.RolValidationSupplier)
                    .HasMaxLength(300);

            });

            modelBuilder.Entity<Contact>(entity => {
                entity.HasKey(e => new { e.IdContact });

                entity.ToTable("Contact", "supplier");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PwdTemp)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DocumentSupplier>(entity => {
                entity.HasKey(e => e.IdDocumentSupplier);

                entity.ToTable("DocumentSupplier", "supplier");

                entity.Property(e => e.IdDocument)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IdPreSupplier)
                    .IsRequired()
                   .HasMaxLength(20);

                entity.Property(e => e.IdSupplier)
                   .HasMaxLength(20);


                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.RejectedReason)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Notification>(entity => {
                entity.HasKey(e => e.IdNotification);

                entity.ToTable("Notification");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Message)
                    .IsRequired();
            });

            modelBuilder.Entity<NotificationAttachment>(entity => {
                entity.HasKey(e => e.IdAttachment);

                entity.ToTable("NotificationAttachment");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e=>e.Extension)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<NotificationResponsible>(entity => {
                entity.HasKey(e => e.IdPerson);

                entity.ToTable("NotificationResponsible");
            });

            modelBuilder.Entity<ToNotification>(entity => {
                entity.HasKey(e => new { e.IdNotification, e.IdPerson});

                entity.ToTable("ToNotification");
            });

            modelBuilder.Entity<InvoiceAttachment>(entity => {
                entity.HasKey(e => e.IdAttachment);

                entity.ToTable("InvoiceAttachment");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<InvoiceAttachmentPPD>(entity => {
                entity.HasKey(e => e.IdAttachmentPPD);

                entity.ToTable("InvoiceAttachmentPPD");

                entity.Property(e => e.Currency)
                    .HasMaxLength(5);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PaidReason)
                    .HasMaxLength(1000);

            });

            modelBuilder.Entity<Invoice>(entity => {
                entity.HasKey(e => e.IdInvoice);

                entity.ToTable("Invoice");

                entity.Property(e => e.UUID)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Serie)
                    .HasMaxLength(20);

                entity.Property(e => e.Folio)
                    .HasMaxLength(40);

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.PaymentTerms)
                    .HasMaxLength(200);

                entity.Property(e => e.IdExport)
                    .HasMaxLength(5);

                entity.Property(e => e.PlaceExpedition)
                    .HasMaxLength(10);

                entity.Property(e => e.Emitter_RFC)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Emitter_Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Emitter_IdFiscalRegime)
                    .HasMaxLength(5);

                entity.Property(e => e.Receptor_RFC)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Receptor_Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Receptor_TaxDomicile)
                    .HasMaxLength(10);

                entity.Property(e => e.Receptor_IdFiscalRegime)
                    .HasMaxLength(5);

                entity.Property(e => e.Receptor_IdUseCFDI)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.PurchaseOrder)
                    .HasMaxLength(100);

                entity.Property(e => e.ReceptionOrder)
                    .HasMaxLength(100);

                entity.Property(e => e.JSONPurchaseOrder)
                    .HasMaxLength(500);

                entity.Property(e => e.Comments)
                    .HasMaxLength(500);

                entity.Property(e => e.XML_Content)
                    .HasConversion(
                        xml => xml.ToString(),
                        xml => xml != null ? XElement.Parse(xml) : null)
                    .HasColumnType("xml");

                //entity.Ignore(e => e.XmlValueWrapper);

                entity.Property(e => e.XML_FileName)
                    .HasMaxLength(200);

                entity.Property(e => e.XML_Path)
                    .HasMaxLength(200);

                entity.Property(e => e.PDF_FileName)
                    .HasMaxLength(200);

                entity.Property(e => e.PDF_Path)
                    .HasMaxLength(200);

                entity.Property(e => e.Version)
                    .HasMaxLength(5);

            });

            modelBuilder.Entity<PreInvoice>(entity => {
                entity.HasKey(e => e.IdPreInvoice);

                entity.ToTable("PreInvoice");

                entity.Property(e => e.KeyID)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UUID)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Serie)
                    .HasMaxLength(20);

                entity.Property(e => e.Folio)
                    .HasMaxLength(40);

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.PaymentTerms)
                    .HasMaxLength(70);

                entity.Property(e => e.IdExport)
                    .HasMaxLength(5);

                entity.Property(e => e.PlaceExpedition)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Emitter_RFC)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Emitter_Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Emitter_IdFiscalRegime)
                    .HasMaxLength(5);

                entity.Property(e => e.Receptor_RFC)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Receptor_Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Receptor_TaxDomicile)
                    .HasMaxLength(10);

                entity.Property(e => e.Receptor_IdFiscalRegime)
                    .HasMaxLength(5);

                entity.Property(e => e.Receptor_IdUseCFDI)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.PurchaseOrder)
                    .HasMaxLength(30);

                entity.Property(e => e.Comments)
                    .HasMaxLength(500);

                entity.Property(e => e.XML_Content)
                    .HasConversion(
                        xml => xml.ToString(),
                        xml => xml != null ? XElement.Parse(xml) : null)
                    .HasColumnType("xml");

                //entity.Ignore(e => e.XmlValueWrapper);

                entity.Property(e => e.XML_FileName)
                    .HasMaxLength(200);

                entity.Property(e => e.XML_Path)
                    .HasMaxLength(200);

                entity.Property(e => e.PDF_FileName)
                    .HasMaxLength(200);

                entity.Property(e => e.PDF_Path)
                    .HasMaxLength(200);

                entity.Property(e => e.Version)
                    .HasMaxLength(5);

                entity.Property(e => e.ValidationMessage)
                    .HasMaxLength(500);

            });

            modelBuilder.Entity<PersonInvoicePrivileges>(entity => {
                entity.HasKey(e => e.IdPerson);

                entity.ToTable("PersonInvoicePrivileges");
            });

            modelBuilder.Entity<PersonInvoicePrivilegesDetail>(entity => {
                entity.HasKey(e => new { e.IdPerson, e.IdSupplier });

                entity.ToTable("PersonInvoicePrivilegesDetail");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.IdSupplier);

                entity.ToTable("Supplier");

                entity.Property(e => e.RFC)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50);

                entity.Property(e => e.Address)
                    .HasMaxLength(500);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<PreSupplier>(entity => {
                entity.HasKey(e => e.IdPreSupplier);

                entity.ToTable("PreSupplier", "supplier");

                entity.Property(e => e.RFC)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Address)
                    .HasMaxLength(500);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<StatusInvoice>(entity => {
                entity.HasKey(e => e.IdStatus);

                entity.ToTable("StatusInvoice");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StatusNotification>(entity => {
                entity.HasKey(e => e.IdStatus);

                entity.ToTable("StatusNotification");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<vtContact>(entity => {
                entity.HasKey(e => e.IdContact);

                entity.ToTable("vtContact", "supplier");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TypeSupplierName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PwdTemp)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<vtDocumentSupplier>(entity => {
                entity.HasKey(e => e.IdDocumentSupplier);

                entity.ToTable("vtDocumentSupplier", "supplier");

                entity.Property(e => e.IdDocument)
                   .IsRequired()
                   .HasMaxLength(20);

                entity.Property(e => e.IdPreSupplier)
                    .IsRequired()
                   .HasMaxLength(20);

                entity.Property(e => e.IdSupplier)
                   .HasMaxLength(20);

                entity.Property(e => e.Key) 
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.RFC)
                    .HasMaxLength(15);

                entity.Property(e => e.Name)                  
                    .HasMaxLength(250);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ValidateByName)
                    .HasMaxLength(152);

                entity.Property(e => e.RejectedByName)
                    .HasMaxLength(152);

                entity.Property(e => e.RejectedReason)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<vtInvoice>(entity => {
                entity.HasKey(e => e.IdInvoice);

                entity.ToTable("vtInvoice");

                
                entity.Property(e => e.RFCCompany)
                    .HasMaxLength(20);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.RFCBranchCompany)
                    .HasMaxLength(20);

                entity.Property(e => e.BranchCompanyName)
                    .HasMaxLength(20);

                entity.Property(e => e.BusinessUnitName)
                    .HasMaxLength(150);

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UUID)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Serie)
                    .HasMaxLength(20);

                entity.Property(e => e.Folio)
                    .HasMaxLength(40);

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.PaymentTerms)
                    .HasMaxLength(70);

                entity.Property(e => e.PaymentMethodName)
                    .HasMaxLength(50);

                entity.Property(e => e.ReceiptTypeName)
                    .HasMaxLength(50);

                entity.Property(e => e.FormPaymentName)
                    .HasMaxLength(50);

                entity.Property(e => e.IdExport)
                    .HasMaxLength(5);

                entity.Property(e => e.ExportName)
                    .HasMaxLength(100);

                entity.Property(e => e.PlaceExpedition)
                    .HasMaxLength(10);

                entity.Property(e => e.Emitter_RFC)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Emitter_Name)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.Emitter_IdFiscalRegime)
                    .HasMaxLength(5);

                entity.Property (e => e.Emitter_FiscalRegimeName)
                .HasMaxLength (200);

                entity.Property(e => e.Receptor_RFC)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Receptor_Name)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.Receptor_TaxDomicile)
                    .HasMaxLength(10);

                entity.Property(e => e.Receptor_IdFiscalRegime)
                    .HasMaxLength(5);

                entity.Property(e => e.Receptor_FiscalRegimeName)
                .HasMaxLength(200);

                entity.Property(e => e.Receptor_IdUseCFDI)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.UseCFDIName)
                .HasMaxLength(200);

                entity.Property(e => e.PurchaseOrder)
                    .HasMaxLength(100);

                entity.Property(e => e.ReceptionOrder)
                    .HasMaxLength(100);

                entity.Property(e => e.JSONPurchaseOrder)
                    .HasMaxLength(500);

                entity.Property(e => e.Comments)
                    .HasMaxLength(500);

                entity.Property(e => e.XML_Content)
                    .HasColumnType("xml");

                //entity.Ignore(e => e.XmlValueWrapper);

                entity.Property(e => e.XML_FileName)
                    .HasMaxLength(200);

                entity.Property(e => e.XML_Path)
                    .HasMaxLength(200);

                entity.Property(e => e.PDF_FileName)
                    .HasMaxLength(200);

                entity.Property(e => e.PDF_Path)
                    .HasMaxLength(200);

                entity.Property(e => e.Version)
                    .HasMaxLength(5);

                entity.Property(e => e.CreatedByTypeAccount)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.CreatedByFullname)
                    .HasMaxLength(152);
            });

            modelBuilder.Entity<vtInvoiceAttachmentPPD>(entity => {
                entity.HasKey(e => e.IdAttachmentPPD);

                entity.ToTable("vtInvoiceAttachmentPPD");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TypeAccountName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedByName)
                    .HasMaxLength(152);

                entity.Property(e => e.PositionName)
                    .HasMaxLength(150);

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(150);

                entity.Property(e => e.SupplierRFC)
                    .HasMaxLength(20);

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<vtPreInvoice>(entity => {
                entity.HasKey(e => e.IdPreInvoice);

                entity.ToTable("vtPreInvoice");

                entity.Property(e => e.RFCCompany)
                    .HasMaxLength(20);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.RFCBranchCompany)
                    .HasMaxLength(20);

                entity.Property(e => e.BranchCompanyName)
                    .HasMaxLength(20);

                entity.Property(e => e.BusinessUnitName)
                    .HasMaxLength(150);

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KeyID)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UUID)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Serie)
                    .HasMaxLength(20);

                entity.Property(e => e.Folio)
                    .HasMaxLength(40);

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.PaymentTerms)
                    .HasMaxLength(70);

                entity.Property(e => e.PaymentMethodName)
                    .HasMaxLength(50);

                entity.Property(e => e.ReceiptTypeName)
                    .HasMaxLength(50);

                entity.Property(e => e.FormPaymentName)
                    .HasMaxLength(50);

                entity.Property(e => e.IdExport)
                    .HasMaxLength(5);

                entity.Property(e => e.ExportName)
                    .HasMaxLength(100);

                entity.Property(e => e.PlaceExpedition)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Emitter_RFC)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Emitter_Name)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.Emitter_IdFiscalRegime)
                    .HasMaxLength(5);

                entity.Property(e => e.Emitter_FiscalRegimeName)
                .HasMaxLength(200);

                entity.Property(e => e.Receptor_RFC)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Receptor_Name)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.Receptor_TaxDomicile)
                    .HasMaxLength(10);

                entity.Property(e => e.Receptor_IdFiscalRegime)
                    .HasMaxLength(5);

                entity.Property(e => e.Receptor_FiscalRegimeName)
                .HasMaxLength(200);

                entity.Property(e => e.Receptor_IdUseCFDI)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.UseCFDIName)
                .HasMaxLength(200);

                entity.Property(e => e.PurchaseOrder)
                    .HasMaxLength(30);

                entity.Property(e => e.Comments)
                    .HasMaxLength(500);

                entity.Property(e => e.XML_Content)
                    .HasColumnType("xml");

                //entity.Ignore(e => e.XmlValueWrapper);

                entity.Property(e => e.XML_FileName)
                    .HasMaxLength(200);

                entity.Property(e => e.XML_Path)
                    .HasMaxLength(200);

                entity.Property(e => e.PDF_FileName)
                    .HasMaxLength(200);

                entity.Property(e => e.PDF_Path)
                    .HasMaxLength(200);

                entity.Property(e => e.Version)
                    .HasMaxLength(5);

                entity.Property(e => e.CreatedByTypeAccount)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.CreatedByFullname)
                    .HasMaxLength(152);

                entity.Property(e => e.ValidationMessage)
                    .HasMaxLength(500);

            });

            modelBuilder.Entity<vtPreSupplier>(entity => {
                entity.HasKey(e => e.IdPreSupplier);

                entity.ToTable("vtPreSupplier", "supplier");

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasMaxLength(152);

                entity.Property(e => e.PhoneNumberContact)
                    .HasMaxLength(152);

                entity.Property(e => e.EmailContact)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.StatusSupplier)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TypeSupplierName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RFC)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(150);

                entity.Property(e => e.StateName)
                    .HasMaxLength(150);

                entity.Property(e => e.MunicipalityName)
                    .HasMaxLength(200);

                entity.Property(e => e.LocationName)
                    .HasMaxLength(150);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RequireModificationFullName)
                    .HasMaxLength(152);

                entity.Property(e => e.RequireModificationReason)
                    .HasMaxLength(500);

                entity.Property(e => e.ValidationFullName)
                    .HasMaxLength(152);

                entity.Property(e => e.ValidationReason)
                    .HasMaxLength(500);

                entity.Property(e => e.RejectedFullName)
                    .HasMaxLength(152);

                entity.Property(e => e.RejectedReason)
                    .HasMaxLength(700);

            });

            modelBuilder.Entity<vtPersonInvoicePrivileges>(entity => {
                entity.HasKey(e => e.IdPerson);

                entity.ToTable("vtPersonInvoicePrivileges");
            });

            modelBuilder.Entity<vtPersonInvoicePrivilegesDetail>(entity => {
                entity.HasKey(e => new { e.IdPerson, e.IdSupplier });

                entity.ToTable("vtPersonInvoicePrivilegesDetail");
            });

            modelBuilder.Entity<vtNotification>(entity => {
                entity.HasKey(e => e.IdNotification);

                entity.ToTable("vtNotification");

                entity.Property(e => e.TypeAccountName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SupplierRFC)
                    .HasMaxLength(20);

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(250);

                entity.Property(e => e.Subject)
                    .HasMaxLength(250);

                entity.Property(e => e.Message)
                    .IsRequired();
            });

            modelBuilder.Entity<vtNotificationResponsible>(entity => {
                entity.HasKey(e => e.IdPerson);

                entity.ToTable("vtNotificationResponsible");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(150);

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(150);

                entity.Property(e => e.PositionName)
                    .HasMaxLength(150);

            });

            modelBuilder.Entity<vtSupplier>(entity => {
                entity.HasKey(e => e.IdSupplier);

                entity.ToTable("vtSupplier");

                entity.Property(e => e.RFC)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50);

                entity.Property(e => e.Address)
                    .HasMaxLength(500);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(50);

                entity.Property(e => e.StateName)
                    .HasMaxLength(50);

                entity.Property(e => e.MunicipalityName)
                    .HasMaxLength(200);

                entity.Property(e => e.LocationName)
                    .HasMaxLength(150);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<vtToNotification>(entity => {
                entity.HasKey(e => e.IdSupplier);

                entity.ToTable("vtToNotification");

                entity.Property(e => e.RFC)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TypeAccountName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PersonFullName)
                    .IsRequired()
                    .HasMaxLength(152);

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
