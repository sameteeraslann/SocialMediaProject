using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.Domain.Entities.Interface;
using TwitterProject.Domain.Enums;

namespace TwitterProject.Domain.Entities.Concrete
{
    public abstract class BaseEntity<T> : IBaseEntity
    {
        public T Id { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => value = _createDate; }

        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => value = _status; }

    }
}
