using MilenaSapunova.TerminateContracts.Model.Abstract;
using MilenaSapunova.TerminateContracts.Model.DataValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MilenaSapunova.TerminateContracts.Model
{
    public class Country : DataModel
    {
        public Country()
        {
            this.Towns = new List<Town>();
        }

        [MaxLength(ModelsConstraints.NameMaxLenght), MinLength(ModelsConstraints.NameMinLenght)]
        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}
