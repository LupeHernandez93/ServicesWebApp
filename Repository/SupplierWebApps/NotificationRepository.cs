//using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
//using MimeKit;
using ServicesWebApp.Entities.SupplierWebApp;
//using SupplierWebApp.Helpers.C5PortalWebApp;
//using SupplierWebApp.Helpers.C5SupplierApp;
//using SupplierWebApp.Helpers.C5SupplierApp.Custom;
//using SupplierWebApp.Helpers.C5SupplierApp.Notification;
//using SupplierWebApp.Helpers.C5SupplierApp.Security;
//using SupplierWebApp.Helpers.C5SupplierApp.Supplier;
using ServicesWebApp.Interfaces.SupplierWebApp;
//using SupplierWebApp.ViewModels.Notification.Email;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class NotificationRepository : SupplierAppRepositoryBase<Entities.SupplierWebApp.Notification>, INotificationRepository
    {
        private SupplierAppRepositoryContext _repositoryContext;
        public NotificationRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        //public async Task<vtNotification> GetView(int idNotification)
        //{
        //    try
        //    {
        //        return await _repositoryContext.VtNotifications.SingleOrDefaultAsync(x => x.IdNotification == idNotification);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw(ex);
        //    }
        //}

        //public async Task<Entities.C5SupplierApp.Notification> SendAsync(int idNotification, int idParentNotification, int idTypeAccount, int idPriority, List<int> to, string subject, string message, bool requireResponse, List<IFormFile> attachments, int idPerson)
        //{
        //    try
        //    {
        //        AppSettings appSettings = new AppSettings();
        //        if (idNotification ==0)
        //        {
        //            if(idTypeAccount == (int)Enumerators.TypeAccount.Collaborator)
        //            {
        //                using (_repositoryContext = new SupplierAppRepositoryContext())
        //                {
        //                    Entities.C5SupplierApp.Notification notification = new Entities.C5SupplierApp.Notification();
        //                    notification.IdParentNotification = idParentNotification;
        //                    notification.IdTypeAccount = idTypeAccount;
        //                    notification.IdPriority = idPriority;
        //                    notification.SentToBy = idPerson;
        //                    notification.IdStatus = (int)Enumerators.StatusNotification.Unread;
        //                    if (to.Count() > 1)
        //                        notification.To = 0;
        //                    else
        //                    {
        //                        vtSupplier supplier = await SupplierHelper.GetViewAsync(to.FirstOrDefault());
        //                        if (supplier != null)
        //                        {
        //                            List<vtPerson> currentPersons = await SupplierHelper.GetAllAccountAsync(supplier.IdSupplier);
        //                            if(currentPersons.Count()>0)
        //                            {
        //                                notification.To = currentPersons.FirstOrDefault().IdPerson;
        //                                notification.IdSupplier = supplier.IdSupplier;
        //                            }
        //                        }
        //                    }
        //                    notification.Subject = subject;
        //                    notification.Message = message;
        //                    notification.SendToDate = DateTime.Now;
        //                    notification.RequireResponse = requireResponse;
        //                    notification.From = idPerson;
        //                    _repositoryContext.Entry(notification).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        //                    await _repositoryContext.SaveChangesAsync();

        //                    if (attachments.Count() > 0)
        //                    {
        //                        string pathServerFolder = "Notifications\\" + notification.IdNotification.ToString();

        //                        //Comprobar si existe el directorio
        //                        bool exists = System.IO.Directory.Exists(appSettings.PhysicalServerFolder + "\\" + pathServerFolder);

        //                        //Comprobar si existe el directorio
        //                        if (!exists)
        //                            System.IO.Directory.CreateDirectory(appSettings.PhysicalServerFolder + "\\" + pathServerFolder);

        //                        foreach (IFormFile file in attachments)
        //                        {
        //                            using (var stream = System.IO.File.Create(appSettings.PhysicalServerFolder + "\\" + pathServerFolder + "\\" + file.FileName))
        //                            {
        //                                await file.CopyToAsync(stream);

        //                                NotificationAttachment notificationAttachment = new NotificationAttachment();
        //                                notificationAttachment.IdNotification = notification.IdNotification;
        //                                notificationAttachment.FileName = file.FileName;
        //                                notificationAttachment.Path = appSettings.RelativeServerFolder + "\\" + pathServerFolder + "\\";
        //                                notificationAttachment.Extension = Path.GetExtension(file.FileName);
        //                                notificationAttachment.Length = file.Length;
        //                                notificationAttachment.CreatedDate = DateTime.Now;
        //                                notificationAttachment.AttachedBy = idPerson;
        //                                _repositoryContext.Entry(notificationAttachment).State = EntityState.Added;
        //                                _repositoryContext.SaveChanges();
        //                            }
        //                        }
        //                    }

        //                    if (to.Count() > 1)
        //                    {
        //                        foreach (int row in to)
        //                        {
        //                            vtSupplier supplier = await SupplierHelper.GetViewAsync(row);
        //                            if (supplier != null)
        //                            {
        //                                List<vtPerson> currentPersons = await SupplierHelper.GetAllAccountAsync(supplier.IdSupplier);
        //                                if (currentPersons.Count() > 0)
        //                                {
        //                                    ToNotification toNotification = new ToNotification();
        //                                    toNotification.IdNotification = notification.IdNotification;
        //                                    toNotification.IdPerson = currentPersons.FirstOrDefault().IdPerson;
        //                                    toNotification.IdStatus = (int)Enumerators.StatusNotification.Unread;
        //                                    _repositoryContext.Entry(toNotification).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        //                                    await _repositoryContext.SaveChangesAsync();
        //                                }
        //                            }
        //                        }
        //                    }

        //                    //Enviar notificacion por correo
        //                    await this.SendEmail(notification.IdNotification);

        //                    return notification;
        //                }
        //            }
        //            else if (idTypeAccount == (int)Enumerators.TypeAccount.Supplier)
        //            {
        //                using (_repositoryContext = new SupplierAppRepositoryContext())
        //                {
        //                    Entities.C5SupplierApp.Notification notification = new Entities.C5SupplierApp.Notification();
        //                    notification.IdParentNotification = idParentNotification;
        //                    notification.IdTypeAccount = idTypeAccount;
        //                    notification.IdPriority = idPriority;
        //                    notification.SentToBy = idPerson;
        //                    notification.IdStatus = (int)Enumerators.StatusNotification.Unread;
        //                    notification.To = to.FirstOrDefault();
        //                    notification.Subject = subject;
        //                    notification.Message = message;
        //                    notification.SendToDate = DateTime.Now;
        //                    notification.RequireResponse = false;
        //                    notification.From = idPerson;
        //                    _repositoryContext.Entry(notification).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        //                    await _repositoryContext.SaveChangesAsync();

        //                    if (attachments.Count() > 0)
        //                    {
        //                        string pathServerFolder = "Notifications\\" + notification.IdNotification.ToString();

        //                        //Comprobar si existe el directorio
        //                        bool exists = System.IO.Directory.Exists(appSettings.PhysicalServerFolder + "\\" + pathServerFolder);

        //                        //Comprobar si existe el directorio
        //                        if (!exists)
        //                            System.IO.Directory.CreateDirectory(appSettings.PhysicalServerFolder + "\\" + pathServerFolder);

        //                        foreach (IFormFile file in attachments)
        //                        {
        //                            using (var stream = System.IO.File.Create(appSettings.PhysicalServerFolder + "\\" + pathServerFolder + "\\" + file.FileName))
        //                            {
        //                                await file.CopyToAsync(stream);

        //                                NotificationAttachment notificationAttachment = new NotificationAttachment();
        //                                notificationAttachment.IdNotification = notification.IdNotification;
        //                                notificationAttachment.FileName = file.FileName;
        //                                notificationAttachment.Path = appSettings.RelativeServerFolder + "\\" + pathServerFolder + "\\";
        //                                notificationAttachment.Extension = Path.GetExtension(file.FileName);
        //                                notificationAttachment.Length = file.Length;
        //                                notificationAttachment.CreatedDate = DateTime.Now;
        //                                notificationAttachment.AttachedBy = idPerson;
        //                                _repositoryContext.Entry(notificationAttachment).State = EntityState.Added;
        //                                _repositoryContext.SaveChanges();
        //                            }
        //                        }
        //                    }

        //                    //Enviar notificacion por correo

        //                    return notification;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Entities.C5SupplierApp.Notification notification = await _repositoryContext.Notifications.SingleOrDefaultAsync(x => x.IdNotification == idNotification);

        //            return notification;
        //        }

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw(ex);
        //    }
        //}

        //public async Task<TrayNotification> SearchAsync(List<int> idStatus, List<int> idPriorities, List<int> idPersons, string description, DateTime startRange, DateTime endRange, Enumerators.TypeAccount typeAccount, int idPerson)
        //{
        //    try
        //    {
        //        TrayNotification trayNotification = new TrayNotification();
        //        trayNotification.receivedNotifications = new List<vtNotification>();
        //        List<vtNotification> currentReceivedNotifications = new List<vtNotification>();
        //        trayNotification.sentNotifications = new List<vtNotification>();

        //        if (idStatus.FirstOrDefault() == 0)
        //            idStatus = _repositoryContext.StatusNotifications.Select(x => x.IdStatus).ToList();

        //        if (idPriorities.FirstOrDefault() == 0)
        //            idPriorities = _repositoryContext.CatPriorities.Select(x => x.IdPriority).ToList();

        //        List<DateTime> rangeDates = UtilityHelper.GetRangeDate(startRange, endRange);
        //        List<vtNotification> receivedNotifications = new List<vtNotification>();
        //        List<vtNotification> sentNotifications = new List<vtNotification>();

        //        if (typeAccount == Enumerators.TypeAccount.Collaborator)
        //        {
        //            #region Received Notifications

        //            receivedNotifications = await _repositoryContext.VtNotifications
        //                .Where(x=>
        //                    //(idStatus.FirstOrDefault() != 0 ? idStatus.Contains(x.IdStatus) : true) &&
        //                    (idPriorities.FirstOrDefault() !=0 ? idPriorities.Contains(x.IdPriority):  true) &&
        //                    rangeDates.Contains(EF.Property<DateTime>(x, "SendToDate").Date) &&
        //                    (x.Subject.Equals(description) || x.Message.Contains(description) || x.SupplierRFC.Equals(description))
        //                )
        //                .OrderBy(x=>x.SendToDate)
        //                .ToListAsync();
        //            List<int> currentIdNotifications = receivedNotifications.Select(x => x.IdNotification).ToList();
        //            List<ToNotification> toNotifications = await _repositoryContext.ToNotifications.Where(x => currentIdNotifications.Contains(x.IdNotification) && x.IdPerson == idPerson).ToListAsync();
        //            currentReceivedNotifications = receivedNotifications.Where(x => x.To == idPerson).ToList();
        //            if(toNotifications.Count()>0)
        //            {
        //                List<int> currentToIdNotifications = toNotifications.Select(x => x.IdNotification).ToList();
        //                currentReceivedNotifications.AddRange(receivedNotifications.Where(x=> currentToIdNotifications.Contains(x.IdNotification)).ToList());
        //            }

        //            trayNotification.receivedNotifications = currentReceivedNotifications.Where(x => (idStatus.FirstOrDefault() != (int)Enumerators.StatusNotification.Inbox && idStatus.FirstOrDefault() != (int)Enumerators.StatusNotification.Sent ? idStatus.Contains(x.IdStatus) : true)).OrderBy(x => x.SendToDate).ToList();

        //            #region Complement Supplier

        //            foreach (vtNotification notification in trayNotification.receivedNotifications.Where(x=>x.IdTypeAccount == (int)Enumerators.TypeAccount.Supplier))
        //            {
        //                Person person = await PersonHelper.GetAsync(notification.From);
        //                if (person.IdSupplier != null)
        //                {
        //                    vtSupplier supplier = await SupplierHelper.GetViewAsync(person.IdSupplier.Value);
        //                    if (supplier != null)
        //                    {
        //                        notification.IdSupplier = supplier.IdSupplier;
        //                        notification.SupplierRFC = supplier.RFC;
        //                        notification.SupplierName = supplier.Name;
        //                    }
        //                }
        //            }

        //            #endregion

        //            #endregion

        //            #region Sent Notifications

        //            sentNotifications = await _repositoryContext.VtNotifications
        //                .Where(x =>
        //                    //(idStatus.FirstOrDefault() != 0 ? idStatus.Contains(x.IdStatus) : true) &&
        //                    (idPriorities.FirstOrDefault() != 0 ? idPriorities.Contains(x.IdPriority) : true) &&
        //                    (x.From == idPerson) &&
        //                    rangeDates.Contains(EF.Property<DateTime>(x, "SendToDate").Date) &&
        //                    (x.Subject.Equals(description) || x.Message.Contains(description) || x.SupplierRFC.Equals(description))
        //                )
        //                .OrderBy(x => x.SendToDate)
        //                .ToListAsync();

        //            trayNotification.sentNotifications = sentNotifications;

        //            #endregion
        //        }
        //        else if (typeAccount == Enumerators.TypeAccount.Supplier)
        //        {
        //            #region Received Notifications

        //            receivedNotifications = await _repositoryContext.VtNotifications
        //                .Where(x =>
        //                    //(idStatus.FirstOrDefault() != 0 ? idStatus.Contains(x.IdStatus) : true) &&
        //                    (x.To == idPerson || x.To == 0) &&
        //                    (idPriorities.FirstOrDefault() != 0 ? idPriorities.Contains(x.IdPriority) : true) &&
        //                    rangeDates.Contains(EF.Property<DateTime>(x, "SendToDate").Date) &&
        //                    (x.Subject.Equals(description) || x.Message.Contains(description) || x.SupplierRFC.Equals(description))
        //                )
        //                .OrderBy(x => x.SendToDate)
        //                .ToListAsync();
        //            List<int> currentIdNotifications = receivedNotifications.Select(x => x.IdNotification).ToList();
        //            List<ToNotification> toNotifications = await _repositoryContext.ToNotifications.Where(x => currentIdNotifications.Contains(x.IdNotification) && x.IdPerson == idPerson).ToListAsync();
        //            currentReceivedNotifications = receivedNotifications.Where(x => x.To == idPerson).ToList();
        //            if (toNotifications.Count() > 0)
        //            {
        //                List<int> currentToIdNotifications = toNotifications.Select(x => x.IdNotification).ToList();
        //                foreach(int id in currentToIdNotifications)
        //                {
        //                    if(currentReceivedNotifications.Select(x=>x.IdNotification).Count(x=>x == id) == 0)
        //                    {
        //                        currentReceivedNotifications.AddRange(receivedNotifications.Where(x => currentToIdNotifications.Contains(x.IdNotification)).ToList());
        //                    }
        //                }
        //            }

        //            trayNotification.receivedNotifications = currentReceivedNotifications.Where(x=>(idStatus.FirstOrDefault() != (int)Enumerators.StatusNotification.Inbox && idStatus.FirstOrDefault() != (int)Enumerators.StatusNotification.Sent ? idStatus.Contains(x.IdStatus) : true)).OrderBy(x => x.SendToDate).ToList();

        //            #region Complement notification received (To = 0)

        //            if (currentReceivedNotifications.Count(x=>x.To == 0)>0)
        //            {
        //                foreach(vtNotification row in currentReceivedNotifications)
        //                {
        //                    ToNotification currentToNotification = toNotifications.SingleOrDefault(x => x.IdNotification == row.IdNotification && x.IdPerson == idPerson);
        //                    vtPerson currentPerson = await PersonHelper.GetViewAsync(idPerson);
        //                    if(currentToNotification != null)
        //                    {
        //                        if (currentPerson != null)
        //                        {
        //                            if (currentPerson.IdSupplier != null)
        //                            {
        //                                vtSupplier currentSupplier = _repositoryContext.VtSuppliers.SingleOrDefault(x => x.IdSupplier == currentPerson.IdSupplier);
        //                                if (currentSupplier != null)
        //                                {
        //                                    row.To = idPerson;
        //                                    row.IdStatus = currentToNotification.IdStatus;
        //                                    row.ReadDate = currentToNotification.ReadDate ?? null;
        //                                    row.ArchivedDate = currentToNotification.ArchivedDate ?? null;
        //                                    row.ResponseDate = currentToNotification.ResponseDate ?? null;
        //                                    row.PersonToEmail = currentPerson.Email ?? null;
        //                                    row.PersonToFullName = currentSupplier.Name;
        //                                    row.PersonToDepartmentName = currentPerson.DepartmentName ?? null;
        //                                    row.PersonToPositionName = currentPerson.PositionName ?? null;
        //                                    row.SupplierName = currentSupplier.Name ?? null;
        //                                    row.SupplierRFC = currentSupplier.RFC ?? null;
        //                                }
        //                            }

        //                        }
        //                    }
        //                }

        //                trayNotification.receivedNotifications = currentReceivedNotifications.Where(x => (idStatus.FirstOrDefault() != (int)Enumerators.StatusNotification.Inbox && idStatus.FirstOrDefault() != (int)Enumerators.StatusNotification.Sent ? idStatus.Contains(x.IdStatus) : true)).OrderBy(x => x.SendToDate).ToList();
        //            }

        //            #endregion

        //            #region Complement Supplier

        //            foreach (vtNotification notification in trayNotification.receivedNotifications.Where(x => x.IdTypeAccount == (int)Enumerators.TypeAccount.Supplier))
        //            {
        //                Person person = await PersonHelper.GetAsync(notification.From);
        //                if (person.IdSupplier != null)
        //                {
        //                    vtSupplier supplier = await SupplierHelper.GetViewAsync(person.IdSupplier.Value);
        //                    if (supplier != null)
        //                    {
        //                        notification.IdSupplier = supplier.IdSupplier;
        //                        notification.SupplierRFC = supplier.RFC;
        //                        notification.SupplierName = supplier.Name;
        //                    }
        //                }
        //            }

        //            #endregion

        //            #endregion

        //            #region Sent Notifications

        //            sentNotifications = await _repositoryContext.VtNotifications
        //                .Where(x =>
        //                    //(idStatus.FirstOrDefault() != 0 ? idStatus.Contains(x.IdStatus) : true) &&
        //                    (idPriorities.FirstOrDefault() != 0 ? idPriorities.Contains(x.IdPriority) : true) &&
        //                    (x.From == idPerson) &&
        //                    rangeDates.Contains(EF.Property<DateTime>(x, "SendToDate").Date) &&
        //                    (x.Subject.Equals(description) || x.Message.Contains(description) || x.SupplierRFC.Equals(description))
        //                )
        //                .OrderBy(x => x.SendToDate)
        //                .ToListAsync();

        //            trayNotification.sentNotifications = sentNotifications;

        //            #endregion
        //        }

        //        trayNotification.Inbox = currentReceivedNotifications.Count();
        //        trayNotification.Read = currentReceivedNotifications.Where(x => x.IdStatus == (int)Enumerators.StatusNotification.Read).Count();
        //        trayNotification.Unread = currentReceivedNotifications.Where(x => x.IdStatus == (int)Enumerators.StatusNotification.Unread).Count();
        //        trayNotification.Archived = currentReceivedNotifications.Where(x => x.IdStatus == (int)Enumerators.StatusNotification.Archived).Count();
        //        trayNotification.Sent = sentNotifications.Count();

        //        return trayNotification;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw(ex);
        //    }
        //}

        //public async Task<List<Entities.C5SupplierApp.vtNotification>> GetAllUnread(Enumerators.TypeAccount typeAccount, int idPerson)
        //{
        //    try
        //    {
        //        List<vtNotification> receivedAllNotifications = new List<vtNotification>();
        //        List<vtNotification> currentReceivedNotifications = new List<vtNotification>();
        //        List<vtNotification> receivedNotifications = new List<vtNotification>();

        //        if (typeAccount == Enumerators.TypeAccount.Collaborator)
        //        {
        //            receivedNotifications = await _repositoryContext.VtNotifications
        //                .Where(x =>
        //                    (x.To == 0 || x.To == idPerson) &&
        //                    x.IdTypeAccount == (int)Enumerators.TypeAccount.Supplier &&
        //                    x.IdStatus == (int)Enumerators.StatusNotification.Unread && x.ReadDate == null
        //                )
        //                .OrderBy(x => x.SendToDate)
        //                .ToListAsync();
        //            List<int> currentIdNotifications = receivedNotifications.Select(x => x.IdNotification).ToList();
        //            List<ToNotification> toNotifications = await _repositoryContext.ToNotifications.Where(x => currentIdNotifications.Contains(x.IdNotification) && x.IdPerson == idPerson).ToListAsync();
        //            currentReceivedNotifications = receivedNotifications.Where(x => x.To == idPerson).ToList();
        //            if (toNotifications.Count() > 0)
        //            {
        //                List<int> currentToIdNotifications = toNotifications.Select(x => x.IdNotification).ToList();
        //                currentReceivedNotifications.AddRange(receivedNotifications.Where(x => currentToIdNotifications.Contains(x.IdNotification)).ToList());
        //            }

        //            receivedAllNotifications = currentReceivedNotifications.OrderBy(x => x.SendToDate).ToList();

        //            #region Complement Supplier

        //            foreach (vtNotification notification in receivedAllNotifications.Where(x => x.IdTypeAccount == (int)Enumerators.TypeAccount.Supplier))
        //            {
        //                Person person = await PersonHelper.GetAsync(notification.From);
        //                if (person.IdSupplier != null)
        //                {
        //                    vtSupplier supplier = await SupplierHelper.GetViewAsync(person.IdSupplier.Value);
        //                    if (supplier != null)
        //                    {
        //                        notification.IdSupplier = supplier.IdSupplier;
        //                        notification.SupplierRFC = supplier.RFC;
        //                        notification.SupplierName = supplier.Name;
        //                    }
        //                }
        //            }

        //            #endregion
        //        }
        //        else if (typeAccount == Enumerators.TypeAccount.Supplier)
        //        {
        //            receivedNotifications = await _repositoryContext.VtNotifications
        //                .Where(x =>
        //                    x.To == 0 || x.To == idPerson &&
        //                    x.IdTypeAccount == (int)Enumerators.TypeAccount.Collaborator &&
        //                    x.IdStatus == (int)Enumerators.StatusNotification.Unread && x.ReadDate == null
        //                )
        //                .OrderBy(x => x.SendToDate)
        //                .ToListAsync();
        //            List<int> currentIdNotifications = receivedNotifications.Select(x => x.IdNotification).ToList();
        //            List<ToNotification> toNotifications = await _repositoryContext.ToNotifications.Where(x => currentIdNotifications.Contains(x.IdNotification) && x.IdPerson == idPerson).ToListAsync();
        //            currentReceivedNotifications = receivedNotifications.Where(x => x.To == idPerson).ToList();
        //            if (toNotifications.Count() > 0)
        //            {
        //                List<int> currentToIdNotifications = toNotifications.Select(x => x.IdNotification).ToList();
        //                currentReceivedNotifications.AddRange(receivedNotifications.Where(x => currentToIdNotifications.Contains(x.IdNotification)).ToList());
        //            }

        //            if (currentReceivedNotifications.Count() > 0)
        //            {
        //                foreach (vtNotification notification in currentReceivedNotifications.Where(x => x.To == 0)) {

        //                    ToNotification singleToNotification = toNotifications.SingleOrDefault(x => x.IdNotification == notification.IdNotification && x.IdPerson == idPerson);
        //                    if (singleToNotification != null)
        //                    {
        //                        notification.IdStatus = singleToNotification.IdStatus;
        //                        notification.ReadDate = singleToNotification.ReadDate ?? null;
        //                        notification.ArchivedDate = singleToNotification.ArchivedDate ?? null;
        //                        notification.ResponseDate = singleToNotification.ResponseDate ?? null;
        //                    }
        //                }
        //            }

        //            receivedAllNotifications = currentReceivedNotifications.Where(x=> x.IdStatus == (int)Enumerators.StatusNotification.Unread && x.ReadDate == null).OrderBy(x => x.SendToDate).ToList();

        //            #region Complement Supplier

        //            foreach (vtNotification notification in receivedAllNotifications.Where(x => x.IdTypeAccount == (int)Enumerators.TypeAccount.Supplier))
        //            {
        //                Person person = await PersonHelper.GetAsync(notification.From);
        //                if (person.IdSupplier != null)
        //                {
        //                    vtSupplier supplier = await SupplierHelper.GetViewAsync(person.IdSupplier.Value);
        //                    if (supplier != null)
        //                    {
        //                        notification.IdSupplier = supplier.IdSupplier;
        //                        notification.SupplierRFC = supplier.RFC;
        //                        notification.SupplierName = supplier.Name;
        //                    }
        //                }
        //            }

        //            #endregion
        //        }

        //        return receivedAllNotifications;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw(ex);
        //    }
        //}

        //public async Task<bool> SendEmail(int idNotification)
        //{
        //    try
        //    {
        //        AppSettings appSettings = new AppSettings();
        //        NotificationSupplierEmailView Template = new NotificationSupplierEmailView(idNotification);
        //        var message = new MimeMessage();
        //        message.From.Add(new MailboxAddress("Portal de Proveedores", appSettings.EmailAlert));
        //        message.Subject = "Tienes una nueva notificación en el Portal de Proveedores de C5M";
        //        if(Template.notification.To == 0)
        //        {
        //            foreach(vtToNotification row in Template.notification.toNotifications)
        //                message.To.Add(new MailboxAddress(row.PersonFullName, (appSettings.Configuration.DebugEmail != null ? appSettings.Configuration.DebugEmail : row.Email.ToLower())));
        //        }
        //        else
        //        {
        //            message.To.Add(new MailboxAddress(Template.notification.PersonToFullName, (appSettings.Configuration.DebugEmail != null ? appSettings.Configuration.DebugEmail : Template.notification.PersonToEmail.ToLower())));
        //        }
                
        //        message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        //        {
        //            Text = await Template.GetTemplateAsync()
        //        };

        //        var multipart = new Multipart("mixed");
        //        multipart.Add(message.Body);

        //        using (var smtp = new SmtpClient())
        //        {
        //            smtp.Connect(appSettings.EmailAlertHost, appSettings.EmailAlertPort.Value, false);
        //            smtp.Authenticate(appSettings.EmailAlert, AESCipherHelper.ToDecrypt(appSettings.EmailAlertPassword));
        //            smtp.Send(message);
        //            smtp.Disconnect(true);
        //        }

        //        return await Task.FromResult(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
    }
}
