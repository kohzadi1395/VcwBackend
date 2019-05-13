using System;

namespace Domain
{
    public class BaseEntity
    {
        private DateTime _createDate;
        private Guid _id;

        public Guid Id
        {
            get
            {
                if (_id == Guid.Empty)
                    _id = new Guid();
                return _id;
            }

            set => _id = value;
        }

        public DateTime CreateDate
        {
            get
            {
                if (_createDate == default(DateTime)) _createDate = DateTime.Now;
                return _createDate;
            }
            set => _createDate = value;
        }

        public DateTime ModifyDate { get; set; }

        public bool Deleted { get; set; }
    }
}