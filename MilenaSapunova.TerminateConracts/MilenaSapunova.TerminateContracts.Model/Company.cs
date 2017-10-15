using MilenaSapunova.Terminate.Model.Abstract;
using MilenaSapunova.TerminateContracts.Model.DataValidation;
using System.ComponentModel.DataAnnotations;

namespace MilenaSapunova.TerminateContracts.Model
{
    public class Company : DataModel
    {
        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        public string Name { get; set; }

        [MaxLength(ModelsConstraints.PhoneNumberMaxLength), MinLength(ModelsConstraints.PhoneNumberMinLength)]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
