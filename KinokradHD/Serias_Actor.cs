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
    
    public partial class Serias_Actor
    {
        public int ID_Serias { get; set; }
        public int ID_Actor { get; set; }
        public int ID { get; set; }
    
        public virtual Actor Actor { get; set; }
        public virtual Serias Serias { get; set; }
    }
}
