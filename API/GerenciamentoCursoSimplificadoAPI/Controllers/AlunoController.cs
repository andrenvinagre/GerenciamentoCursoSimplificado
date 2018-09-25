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
    //[Route("api/Aluno")]
    public class AlunoController : Controller
    {
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
                return Ok("Campo E-MAIL em branco!");
            }

            if (string.IsNullOrWhiteSpace(senha))
            {
                return Ok("Campo SENHA em branco!");
            }

            Conn mySqlGet = new Conn();

            var aluno = mySqlGet.RealizarLogin(email);

            if (aluno != null)
            {
                if (aluno.Senha == senha)
                {
                    return Ok("Login realizado com sucesso!");                    
                }
                else
                {
                    return Ok("E-MAIL cadastrado no sistema, porém senha está errada!");
                }
            }
            else
            {
                return Ok("Usuário informou dados válido, mas não está cadastrado no sistema!");
            }
        }
    }
}