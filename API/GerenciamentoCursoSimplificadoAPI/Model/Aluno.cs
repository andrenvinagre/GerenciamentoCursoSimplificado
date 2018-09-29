using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoCursoSimplificadoAPI.Model
{
    public class Aluno
    {
        public Aluno()
        {        
        }

        [Key]
        [MaxLength(11)]
        public string CpfAluno { get; set; }

        [MaxLength(80)]
        public string Nome { get; set; }

        [MaxLength(100)]
        public string Endereco { get; set; }

        [MaxLength(2)]
        public string Estado { get; set; }

        [MaxLength(80)]
        public string Municipio { get; set; }

        [MaxLength(11)]
        public string Telefone { get; set; }

        [MaxLength(80)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Senha { get; set; }
    }
}
