using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.Domain.Enums;

namespace TwitterProject.Domain.Entities.Interface
{
    public interface IBaseEntity
    {
        DateTime CreateDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        DateTime? DeleteDate { get; set; }
        Status Status { get; set; }
    }
}
