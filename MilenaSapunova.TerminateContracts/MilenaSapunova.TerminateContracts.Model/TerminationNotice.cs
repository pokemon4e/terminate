﻿using MilenaSapunova.TerminateContracts.Model.Abstract;
using MilenaSapunova.TerminateContracts.Model.DataValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilenaSapunova.TerminateContracts.Model
{
    public class TerminationNotice : DataModel
    {
        [MaxLength(ModelsConstraints.ContentMaxLength), MinLength(ModelsConstraints.ContentMinLength)]
        public string Content { get; set; }

        public virtual Company Company { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual User Owner { get; set; }

        [Index]
        public bool IsTemplate { get; set; }
    }
}
