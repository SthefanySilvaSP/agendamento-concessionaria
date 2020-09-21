using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_carro")]
    public partial class TbCarro
    {
        public TbCarro()
        {
            TbAgendamento = new HashSet<TbAgendamento>();
        }

        [Key]
        [Column("id_carro", TypeName = "int(11)")]
        public int IdCarro { get; set; }
        [Column("nm_modelo", TypeName = "varchar(100)")]
        public string NmModelo { get; set; }
        [Column("nr_ano_modelo", TypeName = "int(11)")]
        public int? NrAnoModelo { get; set; }
        [Column("ds_cor", TypeName = "varchar(45)")]
        public string DsCor { get; set; }
        [Column("ds_placa", TypeName = "varchar(9)")]
        public string DsPlaca { get; set; }
        [Column("ds_renavan", TypeName = "varchar(11)")]
        public string DsRenavan { get; set; }
        [Column("bt_test_drive", TypeName = "tinyint(4)")]
        public sbyte? BtTestDrive { get; set; }
        [Column("bt_disponivel", TypeName = "tinyint(4)")]
        public sbyte? BtDisponivel { get; set; }

        [InverseProperty("IdCarroNavigation")]
        public virtual ICollection<TbAgendamento> TbAgendamento { get; set; }
    }
}
