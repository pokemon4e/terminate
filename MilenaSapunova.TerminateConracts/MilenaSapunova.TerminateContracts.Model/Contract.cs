using MilenaSapunova.Terminate.Model.Abstract;
using MilenaSapunova.TerminateContracts.Model.DataValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace MilenaSapunova.Terminate.Data.Models
{
    public class Contract : DataModel
    {
        public User Owner { get; set; }

        [MaxLength(ModelsConstraints.ContractTitleMaxLength), MinLength(ModelsConstraints.ContractTitleMinLength)]
        public string Title { get; set; }

        [MaxLength(ModelsConstraints.ContractNumberMaxLength), MinLength(ModelsConstraints.ContractNumberMinLength)]
        public string ContractNumber { get; set; }

        [DateInTheFuture]
        public DateTime TerminationDate { get; set; }

        [DateInTheFuture]
        public DateTime NotificationDate { get; set; }
    }
}
