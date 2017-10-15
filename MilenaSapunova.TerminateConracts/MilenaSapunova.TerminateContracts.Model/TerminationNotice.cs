using MilenaSapunova.TerminateContracts.Model.Abstract;

namespace MilenaSapunova.TerminateContracts.Model
{
    public class TerminationNotice : DataModel
    {
        public string Content { get; set; }

        public virtual Company Company { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual User User { get; set; }
    }
}
