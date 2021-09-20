using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WEB.API_Banco.Models;

namespace WEB.API_Banco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : Controller
    {
        private static double saldo;

        /// <summary>
        /// Realizar abertura da conta
        /// </summary>
        /// <returns></returns>
        [HttpGet("abrirConta")]
        public IActionResult RetornaDataAberturaFormatada()
        {
            var conta = new ContaBancaria
            {
                idCounta = 1,
                saldo = 0.0,
                dataAbertura = DateTime.Now
            };

            saldo = conta.saldo;
            var data = Convert.ToDateTime(conta.dataAbertura).ToString("dd/MM/yyyy");
            return Ok($"dataAbertura: {data}");
        }

        /// <summary>
        /// Realizar depósito em conta
        /// </summary>
        /// <param name="movimento"></param>
        /// <returns></returns>
        [HttpPost("depositar")]
        public IActionResult Depositar(MovimentoDTO movimento)
        {
            if (movimento.valor == 0) return BadRequest("Valor do depósito invalido.");

            saldo += movimento.valor;
            return Ok($"Deposito efetuado com sucesso.");
        }

        /// <summary>
        /// Realizar saque em conta
        /// </summary>
        /// <param name="movimento"></param>
        /// <returns></returns>
        [HttpPost("sacar")]
        public IActionResult sacar(MovimentoDTO movimento)
        {
            if (movimento.valor == 0) return BadRequest("Valor do saque invalido.");
            if (movimento.valor > saldo) return BadRequest("saldo insuficiente para saque");

            saldo -= movimento.valor;
            return Ok($"Saque efetuado com sucesso.");
        }

        /// <summary>
        /// Retonar valor do Saldo da conta
        /// </summary>
        /// <returns></returns>
        [HttpGet("RetornaSaldoFormatado")]
        public IActionResult RetornaSaldoFormatado()
        {
            //Formatar padrão moeda
            var returnSaldo = string.Format("{0:N}", saldo);
            return Ok($"saldo em conta: {returnSaldo}");
        }
    }
}
