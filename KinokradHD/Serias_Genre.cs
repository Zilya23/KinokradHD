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
    
    public partial class Serias_Genre
    {
        public int ID_Serias { get; set; }
        public int ID_Genre { get; set; }
        public int ID { get; set; }
    
        public virtual Genre Genre { get; set; }
        public virtual Serias Serias { get; set; }
    }
}
