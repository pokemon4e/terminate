using MilenaSapunova.TerminateContracts.Model.Abstract;
using MilenaSapunova.TerminateContracts.Model.DataValidation;
using System.ComponentModel.DataAnnotations;

namespace MilenaSapunova.TerminateContracts.Model
{
    public class Address : DataModel
    {
        [MaxLength(ModelsConstraints.AddressNameMaxLenght), MinLength(ModelsConstraints.AddressNameMinLenght)]
        public string Name { get; set; }

        public virtual Town Town { get; set; }
    }
}
