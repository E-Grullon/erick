//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace INF244GI
{
    using System;
    using System.Collections.Generic;
    
    public partial class ALMACEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALMACEN()
        {
            this.EXISTENCIAxALMACEN = new HashSet<EXISTENCIAxALMACEN>();
        }
    
        public int ID_ALMACEN { get; set; }
        public string DESCRIPCION { get; set; }
        public string ESTADO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXISTENCIAxALMACEN> EXISTENCIAxALMACEN { get; set; }
    }
}
