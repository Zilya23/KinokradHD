//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KinokradHD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Nomination
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nomination()
        {
            this.Film_Nomination = new HashSet<Film_Nomination>();
            this.Serias_Nominat = new HashSet<Serias_Nominat>();
        }
    
        public int ID_Nomination { get; set; }
        public string Name { get; set; }
        public Nullable<int> ID_Awarts { get; set; }
    
        public virtual Awards Awards { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Film_Nomination> Film_Nomination { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Serias_Nominat> Serias_Nominat { get; set; }
    }
}
