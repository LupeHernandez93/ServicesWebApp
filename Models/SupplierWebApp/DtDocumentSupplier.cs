namespace ServicesWebApp.Models
{
    public class DtDocumentSupplier
    {
        public int IdDocumentSupplier { get; set; }
        public int IdDocument { get; set; }
        public int IdPreSupplier { get; set; }
        public int? IdSupplier { get; set; }
        //public string Key { get; set; } = string.Empty;
        //public int Order { get; set; }
        public string Description { get; set; } = string.Empty;
        //public double? FileMaxLenghtMB { get; set; }
        public bool isRequired { get; set; }
        public string IdTypeSupplier { get; set; }
        public string RFC { get; set; } = string.Empty;
        //public string Name { get; set; } = string.Empty;
        //public int IdStatus { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        //public double Length { get; set; }
        public string Path { get; set; } = string.Empty;
        //public string? Extension { get; set; }
        public DateTime CreatedDate { get; set; }
        //public DateTime? LastModifiedDate { get; set; }
        //public int? ValidationBy { get; set; }
        public string? ValidateByName { get; set; }
        public DateTime? ValidationDate { get; set; }
        //public int? ModifiedRequestBy { get; set; }
        //public string? ModifiedRequestName { get; set; }
        //public DateTime? ModifiedRequestDate { get; set; }
        //public string? ModifiedRequestReason { get; set; }
        //public int? RejectedBy { get; set; }
        //public string? RejectedByName { get; set; }
        //public DateTime? RejectedDate { get; set; }
        //public string? RejectedReason { get; set; }
        public int Version { get; set; }

        //public string? FullAddres { get; set; }
        //public string? FileBase64 { get; set; }


    }
}
