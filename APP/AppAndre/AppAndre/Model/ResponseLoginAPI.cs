using System;
using System.Collections.Generic;
using System.Text;

namespace AppAndre.Model
{       
    public class ResponseLoginAPI
    {
        public int codigo { get; set; }
        public string mensagem { get; set; }
        public Aluno aluno { get; set; }
    }
}
