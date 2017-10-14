using MilenaSapunova.Terminate.Model.Abstract;
using System;

namespace MilenaSapunova.Terminate.Data.Models
{
    public class Contract : DataModel
    {
        public User Owner { get; set; }

        public string ContractNumber { get; set; }

        public String Title { get; set; }

        public DateTime TerminationDate { get; set; }

        public TimeSpan NoticePeriod { get; set; }
    }
}
