using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoCursoSimplificadoAPI.Connector;
using GerenciamentoCursoSimplificadoAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoCursoSimplificadoAPI.Controllers
{
    public class AlunoController : Controller
    {
        private TCCDataContext context;

        public AlunoController(TCCDataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("api/Aluno/Ping")]
        public IActionResult Ping()
        {
            return Ok("Pong!!");
        }

        [HttpGet]
        [Route("api/Aluno/Logar/{email}/{senha}")]
        public IActionResult Logar(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return Ok(new { codigo = 3, mensagem = "Campo E-MAIL em branco!" });
            }

            if (string.IsNullOrWhiteSpace(senha))
            {
                return Ok(new { codigo = 4, mensagem = "Campo SENHA em branco!" });
            }

            var aluno = context.Aluno.FirstOrDefault(x => x.Email == email);

            if (aluno != null)
            {
                if (aluno.Senha == senha)
                {
                    return Ok(new { codigo = 0, mensagem = "Login realizado com sucesso!", aluno });
                }
                else
                {
                    return Ok(new { codigo = 1, mensagem = "E-MAIL cadastrado no sistema, porém senha está errada!", aluno });
                }
            }
            else
            {
                return Ok(new { codigo = 2, mensagem = "Usuário informou dados válidos, mas não está cadastrado no sistema!", aluno });
            }
        }
    }
}