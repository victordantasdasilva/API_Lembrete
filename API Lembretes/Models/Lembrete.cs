using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_Lembretes.Models
{
    [Table("Tarefas")]
    public class Lembrete
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Conteudo { get; set; }
        [MaxLength(5)]
        public string Prioridade { get; set; }
    }
}