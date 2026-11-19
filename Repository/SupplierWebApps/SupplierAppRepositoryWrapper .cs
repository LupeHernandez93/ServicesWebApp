using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;
using ServicesWebApp.Repository;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class SupplierAppRepositoryWrapper : ISupplierAppRepositoryWrapper, IDisposable
    {
        private SupplierAppRepositoryContext _repoContext;

        private ICatDocumentRepository _catDocumentRepository;
        private IContactRepository _contactRepository;
        private ICatPriority _catPriorityRepository;
        private IConfigurationRepository _configurationRepository;
        private ITypeSupplierRepository _typeSupplierRepository;
        private ICompanySupplierRepository _companySupplierRepository;
        private ISupplierRepository _supplierRepository;    
        private IInvoiceRepository _invoiceRepository;
        private IInvoiceAttachmentRepository _invoiceAttachmentRepository;
        private IInvoiceAttachmentPPDRepository _invoiceAttachmentPPDRepository;
        private IPreInvoiceRepository _preInvoiceRepository;
        private IPreSupplierRepository _preSupplierRepository;
        private IPersonInvoicePrivilegesRepository _personInvoicePrivileges;
        private IPersonInvoicePrivilegesDetailRepository _personInvoicePrivilegesDetail;
        private IDocumentRepository _documentRepository;
        private IDocumentSupplierRepository _documentSupplierRepository;
        private INotificationRepository _notificationRepository;
        private INotificationAttachmentRepository _notificationAttachmentRepository;
        private INotificationResponsibleRepository _notificationResponsibleRepository;
        private IToNotificationRepository _toNotification;
        private IStatusInvoiceRepository _statusInvoiceRepository;
        private IStatusNotificationRepository _statusNotificationRepository;

        public SupplierAppRepositoryWrapper(SupplierAppRepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public ICatDocumentRepository CatDocument {
            get {
                if (_catDocumentRepository == null) {
                    _catDocumentRepository = new CatDocumentRepository(_repoContext);
                }
                return _catDocumentRepository;
            }
        }

   

        public IContactRepository Contact {
            get {
                if (_contactRepository == null) {
                    _contactRepository = new ContactRepository(_repoContext);
                }
                return _contactRepository;
            }
        }

        public ICatPriority CatPriority
        {
            get
            {
                if (_catPriorityRepository == null)
                {
                    _catPriorityRepository = new CatPriorityRepository(_repoContext);
                }
                return _catPriorityRepository;
            }
        }

        public IConfigurationRepository Configuration
        {
            get
            {
                if (_contactRepository == null)
                {
                    _configurationRepository = new ConfigurationRepository(_repoContext);
                }
                return _configurationRepository;
            }
        }

        public ITypeSupplierRepository TypeSupplier {
            get {
                if (_typeSupplierRepository == null) {
                    _typeSupplierRepository = new TypeSupplierRepository(_repoContext);
                }
                return _typeSupplierRepository;
            }
        }

        public ICompanySupplierRepository CompanySupplier
        {
            get
            {
                if (_companySupplierRepository == null)
                {
                    _companySupplierRepository = new CompanySupplierRepository(_repoContext);
                }
                return _companySupplierRepository;
            }
        }

        public ISupplierRepository Supplier
        {
            get
            {
                if (_supplierRepository == null)
                {
                    _supplierRepository = new SupplierRepository(_repoContext);
                }
                return _supplierRepository;
            }
        }

        public IInvoiceAttachmentRepository InvoiceAttachment
        {
            get
            {
                if (_invoiceAttachmentRepository == null)
                {
                    _invoiceAttachmentRepository = new InvoiceAttachmentRepository(_repoContext);
                }
                return _invoiceAttachmentRepository;
            }
        }

        public IInvoiceAttachmentPPDRepository InvoiceAttachmentPPD
        {
            get { 
                if(_invoiceAttachmentPPDRepository == null)
                {
                    _invoiceAttachmentPPDRepository = new InvoiceAttachmentPPDRepository(_repoContext);
                }
                return _invoiceAttachmentPPDRepository; 
            }

        }

        public IInvoiceRepository Invoice {
            get
            {
                if (_invoiceRepository == null)
                {
                    _invoiceRepository = new InvoiceRepository(_repoContext);
                }
                return _invoiceRepository;
            }
        }

        public INotificationRepository Notification
        {
            get
            {
                if (_notificationRepository == null)
                {
                    _notificationRepository = new NotificationRepository(_repoContext);
                }
                return _notificationRepository;
            }
        }
        public INotificationAttachmentRepository NotificationAttachment
        {
            get
            {
                if (_notificationAttachmentRepository == null)
                {
                    _notificationAttachmentRepository = new NotificationAttachmentRepository(_repoContext);
                }
                return _notificationAttachmentRepository;
            }
        }
        
        public IToNotificationRepository ToNotification
        {
            get
            {
                if (_toNotification == null)
                {
                    _toNotification = new ToNotificationRepository(_repoContext);
                }
                return _toNotification;
            }
        }

        public INotificationResponsibleRepository NotificationResponsible
        {
            get { 
                if(_notificationResponsibleRepository == null)
                {
                    _notificationResponsibleRepository = new NotificationResponsibleRepository(_repoContext);   
                }

                return _notificationResponsibleRepository;
            }
        }

        public IPreInvoiceRepository PreInvoice {
            get {
                if (_preInvoiceRepository == null) {
                    _preInvoiceRepository = new PreInvoiceRepository(_repoContext);
                }
                return _preInvoiceRepository;
            }
        }

        public IPreSupplierRepository PreSupplier {
            get {
                if (_preSupplierRepository == null) {
                    _preSupplierRepository = new PreSupplierRepository(_repoContext);
                }
                return _preSupplierRepository;
            }
        }

        public IPersonInvoicePrivilegesRepository PersonInvoicePrivileges
        {
            get { 
                if(_personInvoicePrivileges == null)
                {
                    _personInvoicePrivileges = new PersonInvoiceWithoutOCRespository(_repoContext);
                }
                return _personInvoicePrivileges;
            }
        }

        public IPersonInvoicePrivilegesDetailRepository PersonInvoicePrivilegesDetail
        {
            get
            {
                if (_personInvoicePrivilegesDetail == null)
                {
                    _personInvoicePrivilegesDetail = new PersonInvoiceWithoutOCDetailRespository (_repoContext);
                }
                return _personInvoicePrivilegesDetail;
            }
        }

        public IDocumentRepository Document {
            get {
                if (_documentRepository == null) {
                    _documentRepository = new DocumentRepository(_repoContext);
                }
                return _documentRepository;
            }
        }

        public IDocumentSupplierRepository DocumentSupplier {
            get {
                if (_documentSupplierRepository == null) {
                    _documentSupplierRepository = new DocumentSupplierRepository(_repoContext);
                }
                return _documentSupplierRepository;
            }
        }

        public IStatusInvoiceRepository StatusInvoice {
            get {
                if (_statusInvoiceRepository == null) {
                    _statusInvoiceRepository = new StatusInvoiceRepository(_repoContext);
                }
                return _statusInvoiceRepository;
            }
        }

        public IStatusNotificationRepository StatusNotification
        {
            get
            {
                if (_statusNotificationRepository == null)
                {
                    _statusNotificationRepository = new StatusNotificationRepository(_repoContext);
                }
                return _statusNotificationRepository;
            }
        }

        

        public void Dispose() {
            if (_repoContext != null) {
                _repoContext.Dispose();
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
