using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoCursoSimplificadoAPI.Model
{
    public class Aluno
    {
        public Aluno()
        {        
        }

        public string CPFAluno { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Estado { get; set; }

        public string Municipio { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
