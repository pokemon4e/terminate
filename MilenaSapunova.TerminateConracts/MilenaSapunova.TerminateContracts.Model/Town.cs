using MilenaSapunova.TerminateContracts.Model.Abstract;
using MilenaSapunova.TerminateContracts.Model.DataValidation;
using System.ComponentModel.DataAnnotations;

namespace MilenaSapunova.TerminateContracts.Model
{
    public class Town : DataModel
    {
        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        public string Name { get; set; }

        [MaxLength(ModelsConstraints.PostalCodeMaxLenght), MinLength(ModelsConstraints.PostalCodeMinLenght)]
        public string PostalCode { get; set; }

        public virtual Country Country { get; set; }
    }
}
