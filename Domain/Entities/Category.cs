using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Attachments = new HashSet<Attachment>();
        }


        public string CategoryName { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}