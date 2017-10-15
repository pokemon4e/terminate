using MilenaSapunova.TerminateContracts.Model.Abstract;
using MilenaSapunova.TerminateContracts.Model.DataValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MilenaSapunova.TerminateContracts.Model
{
    public class Town : DataModel
    {
        public Town()
        {
            this.Addresses = new List<Address>();
        }

        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        public string Name { get; set; }

        public string PostalCode { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
