using System.ComponentModel.DataAnnotations;

namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class PersonInvoicePrivileges
    {
        public int IdPerson { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Status { get; set; }
    }
}
