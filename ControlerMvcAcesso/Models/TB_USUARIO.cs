//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlerMvcAcesso.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class TB_USUARIO
    {
        [Key]
        public int COD_USUARIO { get; set; }
        [Required(ErrorMessage ="� Obrigatorio Informar o Nome")]
        public string NOME { get; set; }
        [Required(ErrorMessage = "� Obrigatorio Informar o Sobrenome")]
        public string SOBRENOME { get; set; }
        [Required(ErrorMessage = "� Obrigatorio Informar o Email")]
        public string EMAIL { get; set; }
        [Required(ErrorMessage = "� Obrigatorio Informar o Senha")]
        public string SENHA { get; set; }
        public Nullable<int> COD_CARGO { get; set; }
    
        public virtual TB_CARGO TB_CARGO { get; set; }
    }
}
