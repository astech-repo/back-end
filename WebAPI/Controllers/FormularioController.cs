using astech_DTO.DTO;
using astech_DAO.DAO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormularioController : ControllerBase
    {
        [HttpPost]
        [Route("enviar")]
        public async Task<IActionResult> EnviarFormulario([FromBody] FormularioDTO formulario)
        {
            try
            {
                if (formulario == null)
                {
                    return BadRequest("Formulário Inválido.");
                }

                var formularioDAO = new FormularioDAO();
                await formularioDAO.CadastrarFormulario(formulario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
