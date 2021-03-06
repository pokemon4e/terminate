﻿using MilenaSapunova.TerminateContracts.Model;
using System.Linq;

namespace MilenaSapunova.TerminateContracts.Services
{
    public interface ITerminationNoticeService
    {
        IQueryable<TerminationNotice> GetAll();

        void Update(TerminationNotice termination);

         void Add(TerminationNotice terminationNotice);
    }
}
