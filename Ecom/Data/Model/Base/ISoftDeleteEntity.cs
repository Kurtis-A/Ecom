using System;

namespace Ecom.Data.Model.Base
{
    public interface ISoftDeleteEntity : IEntity
    {
        DateTime? Archived { get; set; }
    }
}
