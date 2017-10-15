using MilenaSapunova.TerminateContracts.Model.Abstract;
using MilenaSapunova.TerminateContracts.Model.DataValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace MilenaSapunova.TerminateContracts.Model
{
    public class Contract : DataModel
    {
        public virtual User Owner { get; set; }

        [MaxLength(ModelsConstraints.ContractTitleMaxLength), MinLength(ModelsConstraints.ContractTitleMinLength)]
        public string Title { get; set; }

        [MaxLength(ModelsConstraints.ContractNumberMaxLength), MinLength(ModelsConstraints.ContractNumberMinLength)]
        public string ContractNumber { get; set; }

        [DateInTheFuture]
        public DateTime TerminationDate { get; set; }

        [DateInTheFuture]
        public DateTime NotificationDate { get; set; }

        public virtual Company Company { get; set; }
    }
}
