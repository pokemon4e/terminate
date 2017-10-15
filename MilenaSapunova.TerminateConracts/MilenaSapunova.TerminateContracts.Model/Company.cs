using MilenaSapunova.Terminate.Model.Abstract;

namespace MilenaSapunova.TerminateContracts.Model
{
    public class Company : DataModel
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
