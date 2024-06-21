using astech_DAO.DAO.Conexao;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class DatabaseController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                using (var connection = ConnectionFactory.Build())
                {
                    await connection.OpenAsync();
                    await connection.CloseAsync();
                }
                return Ok($"Copyright © {DateTime.Now.Year} ASTech - Tecnologia, Reparo e Suporte 24 Horas");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao conectar com o banco de dados: {ex.Message}");
            }
        }
    }
}
