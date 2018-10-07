using System;

namespace AviShop.Model.Abstract
{
    public interface IAuditable
    {
        //IAuditable
        DateTime? CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }

        //ISeoable
        string MetaKeyword { get; set; }
        string MetaDescription { get; set; }

        //ISwitchable
        bool Status { get; set; }
    }
}