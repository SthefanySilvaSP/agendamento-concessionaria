using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_funcionario")]
    public partial class TbFuncionario
    {
        public TbFuncionario()
        {
            TbAgendamento = new HashSet<TbAgendamento>();
        }

        [Key]
        [Column("id_funcionario", TypeName = "int(11)")]
        public int IdFuncionario { get; set; }
        [Column("id_login", TypeName = "int(11)")]
        public int IdLogin { get; set; }
        [Column("nm_funcionario", TypeName = "varchar(200)")]
        public string NmFuncionario { get; set; }
        [Column("ds_genero", TypeName = "varchar(45)")]
        public string DsGenero { get; set; }
        [Column("dt_nascimento", TypeName = "datetime")]
        public DateTime? DtNascimento { get; set; }
        [Column("ds_cpf", TypeName = "varchar(14)")]
        public string DsCpf { get; set; }
        [Column("ds_cargo", TypeName = "varchar(250)")]
        public string DsCargo { get; set; }
        [Column("ds_dpto", TypeName = "varchar(150)")]
        public string DsDpto { get; set; }

        [ForeignKey(nameof(IdLogin))]
        [InverseProperty(nameof(TbLogin.TbFuncionario))]
        public virtual TbLogin IdLoginNavigation { get; set; }
        [InverseProperty("IdFuncionarioNavigation")]
        public virtual ICollection<TbAgendamento> TbAgendamento { get; set; }
    }
}
