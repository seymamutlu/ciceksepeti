using System;

namespace CicekSepeti.Model
{
    //Base class for adding the created date, created by, mmodified date and modified columns to the datatables
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }

        string CreatedBy { get; set; }
        DateTime UpdatedDate { get; set; }

        string UpdatedBy { get; set; }
    }
}