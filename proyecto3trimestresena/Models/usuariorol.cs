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
    
    public partial class usuariorol
    {
        public int id { get; set; }
        public int idUsuario { get; set; }
        public int idRol { get; set; }
    
        public virtual roles roles { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
