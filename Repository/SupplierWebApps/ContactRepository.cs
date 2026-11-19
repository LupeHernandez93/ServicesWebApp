using ServicesWebApp.Entities.SupplierWebApp;
//using SupplierWebApp.Helpers.C5SupplierApp.Security;
//using SupplierWebApp.Helpers.C5SupplierApp.Supplier;
using ServicesWebApp.Interfaces.SupplierWebApp;
using Microsoft.EntityFrameworkCore;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class ContactRepository : SupplierAppRepositoryBase<Contact>, IContactRepository {
        private SupplierAppRepositoryContext _repositoryContext;
        public ContactRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext) {
            _repositoryContext = repositoryContext;
        }

        //public async Task<vtContact> GetCustomAsync(int idContact) {
        //    try {
        //        return await _repositoryContext.VtContacts.SingleOrDefaultAsync(x => x.IdContact == idContact);
        //    }
        //    catch (Exception ex) {
        //        throw (ex);
        //    }
        //}

        //public async Task<ContactTray> GetListCustomAsync(List<int> idTypeSupplier, int idStatus, string description)
        //{
        //    try {
        //        ContactTray contactTray = new ContactTray();
        //        List<vtContact> Contacts = await _repositoryContext.VtContacts
        //            .Where(x => (idTypeSupplier.FirstOrDefault() != 0 ? idTypeSupplier.Contains(x.IdTypeSupplier) : true) && (x.CompanyName.Contains(description) || x.Name.Contains(description) || x.FirstName.Contains(description) || x.LastName.Contains(description) || x.Email.Contains(description) || x.Username.Contains(description)))
        //            .OrderBy(x=>x.CreatedDate)
        //            .ThenBy(x=>x.Name)
        //            .ToListAsync();

        //        contactTray.Contacts = new List<vtContact>();

        //        if (idStatus == (int)StatusContact.All)
        //            contactTray.Contacts = Contacts;
        //        else if (idStatus == (int)StatusContact.Pending)
        //            contactTray.Contacts = Contacts.Where(x => x.Status == true && x.ActivationDate == null).ToList();
        //        else if (idStatus == (int)StatusContact.Completed)
        //            contactTray.Contacts = Contacts.Where(x => x.Status == false && x.ActivationDate != null).ToList();
        //        else if (idStatus == (int)StatusContact.Canceled)
        //            contactTray.Contacts = Contacts.Where(x => x.Status == false).ToList();

        //        contactTray.Inbox = Contacts.Count();
        //        contactTray.Pending = Contacts.Where(x => x.Status == true && x.ActivationDate == null).ToList().Count();
        //        contactTray.Completed = Contacts.Where(x => x.Status == false && x.ActivationDate != null).ToList().Count();
        //        contactTray.Canceled = Contacts.Where(x => x.Status == false).ToList().Count();

        //        return contactTray;
        //    }
        //    catch (Exception ex) {
        //        throw (ex);
        //    }
        //}

        //public async Task<Contact> SaveAsync(int idContact, string companyName, string contactName, string firstName, string lastName, string phoneNumber, string email, int idTypeSupplier, string username, string password, int expiredDays, bool status, int idPerson) {
        //    try {
        //        if(idContact ==0) {
        //            int countRow = _repositoryContext.Contacts.Count(x => x.Username.Equals(username) && x.Status == true);
        //            if(countRow > 0) 
        //                throw new Exception("Ya existe un contacto activo registrado con el RFC de proveedor: " + username);

        //            Contact contact = new Contact();
        //            contact.CompanyName = companyName.ToUpper();
        //            contact.Name = contactName;
        //            contact.FirstName = firstName;
        //            contact.LastName = lastName;
        //            contact.PhoneNumber = phoneNumber;
        //            contact.Email = email.ToLower();
        //            contact.IdTypeSupplier = idTypeSupplier;
        //            contact.Username = username.ToUpper();
        //            contact.Password = password; 
        //            contact.PwdTemp = password;
        //            contact.CreatedBy = idPerson;
        //            contact.CreatedDate = DateTime.Now;
        //            contact.ExpirationDays = expiredDays;
        //            contact.ExpiredDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(expiredDays);
        //            contact.Status = true;
        //            _repositoryContext.Entry(contact).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        //            await _repositoryContext.SaveChangesAsync();

        //            contact.Password = SecurityHelper.HashPassword(SecurityHelper.CreateSalt(contact.IdContact.ToString()), password);
        //            _repositoryContext.Entry(contact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //            await _repositoryContext.SaveChangesAsync();

        //            return contact;
        //        }
        //        else {
        //            int countRow = _repositoryContext.Contacts.Count(x => x.Username.Equals(username) && x.Status == true && x.IdContact != idContact);
        //            if (countRow > 0)
        //                throw new Exception("Ya existe un contacto activo registrado con el RFC de proveedor: " + username);

        //            Contact contact = _repositoryContext.Contacts.SingleOrDefault(x => x.IdContact == idContact);
        //            contact.CompanyName = companyName.ToUpper();
        //            contact.Name = contactName;
        //            contact.FirstName = firstName;
        //            contact.LastName = lastName;
        //            contact.PhoneNumber = phoneNumber;
        //            contact.Email = email.ToLower();
        //            contact.IdTypeSupplier = idTypeSupplier;
        //            contact.Username = username.ToUpper();
        //            contact.Password = SecurityHelper.HashPassword(SecurityHelper.CreateSalt(contact.IdContact.ToString()), password);
        //            contact.PwdTemp = password;
        //            contact.ExpirationDays = expiredDays;
        //            contact.ExpiredDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(expiredDays);
        //            contact.Status = status;
        //            _repositoryContext.Entry(contact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //            await _repositoryContext.SaveChangesAsync();

        //            return contact;
        //        }
        //    }
        //    catch (Exception ex) {
        //        throw(ex);
        //    }
        //}

        //public async Task<bool> SendEmailContact(int idContact, int idPerson) {
        //    try {
                 
        //        Contact contact = await _repositoryContext.Contacts.SingleOrDefaultAsync(x => x.IdContact == idContact);
        //        /*
        //        if(contact.ExpiredDate < DateTime.Now)
        //            throw new Exception("No se puede enviar la notificación por email por que ha expirado el contacto, registre una fecha de expiración nueva");
        //        */
        //        DateTime expirationDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(contact.ExpirationDays);
        //        if (!contact.Status)
        //            throw new Exception("No se puede enviar la notificación por email por el estatus del contacto es CANCELADO");
        //        if(contact.ExpiredDate!= expirationDay)
        //            contact.ExpiredDate = expirationDay;

        //        contact.SendLastEmailDate = DateTime.Now;
        //        contact.SendLastEmailBy = idPerson;
        //        _repositoryContext.Entry(contact).State = EntityState.Modified;
        //        await _repositoryContext.SaveChangesAsync();

        //        bool response = await ContactHelper.SendEmailAsync(idContact);

        //        return response;

        //    }
        //    catch (Exception ex) {
        //        throw (ex);
        //    }
        //}
    }
}
