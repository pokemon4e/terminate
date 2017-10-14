using System;

namespace MilenaSapunova.Terminate.Model.Contracts
{
    public interface IAuditable
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
