//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class LIBRO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LIBRO()
        {
            this.PRESTAMO = new HashSet<PRESTAMO>();
        }
    
        public int IDLIBRO { get; set; }
        public int IDAUTOR { get; set; }
        public int IDGL { get; set; }
        public string NOMBRELIBRO { get; set; }
        public Nullable<System.DateTime> ANIOPUBLIBRO { get; set; }
        public string IMGLIBRO { get; set; }
        public string ISBNLIBRO { get; set; }
        public Nullable<bool> ESTADOLIBRO { get; set; }
        public string EDITORIALLIBRO { get; set; }
        public int STOCKLIBRO { get; set; }
    
        public virtual AUTOR AUTOR { get; set; }
        public virtual GENEROLITERARIO GENEROLITERARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRESTAMO> PRESTAMO { get; set; }
    }
}