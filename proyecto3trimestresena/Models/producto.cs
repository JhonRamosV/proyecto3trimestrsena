//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proyecto3trimestresena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public producto()
        {
            this.producto_imagen = new HashSet<producto_imagen>();
            this.producto_compra = new HashSet<producto_compra>();
        }
    
        public int id { get; set; }
        [Required(ErrorMessage = "por favor llene todos los datos")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "por favor llene todos los datos")]
        public int percio_unitario { get; set; }
        [Required(ErrorMessage = "por favor llene todos los datos")]
        public string descripcion { get; set; }
        [Required(ErrorMessage = "por favor llene todos los datos")]
        public int cantidad { get; set; }
        [Required(ErrorMessage = "por favor llene todos los datos")]
        public int id_proveedor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<producto_imagen> producto_imagen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<producto_compra> producto_compra { get; set; }
        public virtual proveedor proveedor { get; set; }
    }
}
