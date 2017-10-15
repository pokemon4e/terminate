using MilenaSapunova.TerminateContracts.Model.Abstract;

namespace MilenaSapunova.TerminateContracts.Model
{
    public class Address : DataModel
    {
        //[MaxLength(ModelsConstraints.AddressNameMaxLenght), MinLength(ModelsConstraints.AddressNameMinLenght)]
        public string Name { get; set; }

        public virtual Town Town { get; set; }
    }
}
