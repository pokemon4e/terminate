using MilenaSapunova.TerminateContracts.Model.Abstract;
using MilenaSapunova.TerminateContracts.Model.DataValidation;
using System.ComponentModel.DataAnnotations;

namespace MilenaSapunova.TerminateContracts.Model
{
    public class Company : DataModel
    {
        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        public string Name { get; set; }

        [RegularExpression(ModelsConstraints.PhoneNumberRegex)]
        [MaxLength(ModelsConstraints.PhoneNumberMaxLength), MinLength(ModelsConstraints.PhoneNumberMinLength)]
        public string PhoneNumber { get; set; }

        [RegularExpression(ModelsConstraints.EmailRegex)]
        [MaxLength(ModelsConstraints.EmailMaxLength), MinLength(ModelsConstraints.EmailMinLength)]
        public string Email { get; set; }
    }
}
