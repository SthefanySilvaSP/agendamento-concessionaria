using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_cliente")]
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbAgendamento = new HashSet<TbAgendamento>();
        }

        [Key]
        [Column("id_cliente", TypeName = "int(11)")]
        public int IdCliente { get; set; }
        [Column("id_login", TypeName = "int(11)")]
        public int IdLogin { get; set; }
        [Column("nm_cliente", TypeName = "varchar(200)")]
        public string NmCliente { get; set; }
        [Column("ds_genero", TypeName = "varchar(45)")]
        public string DsGenero { get; set; }
        [Column("dt_nascimento", TypeName = "datetime")]
        public DateTime? DtNascimento { get; set; }
        [Column("ds_cpf", TypeName = "varchar(14)")]
        public string DsCpf { get; set; }
        [Column("ds_cnh", TypeName = "varchar(100)")]
        public string DsCnh { get; set; }

        [ForeignKey(nameof(IdLogin))]
        [InverseProperty(nameof(TbLogin.TbCliente))]
        public virtual TbLogin IdLoginNavigation { get; set; }
        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<TbAgendamento> TbAgendamento { get; set; }
    }
}
