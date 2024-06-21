using astech_DTO.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SMessengerController : ControllerBase
    {
        private readonly SMessengerController _sMessengerService;

        public SMessengerController(SMessengerController sMessengerService)
        {
            _sMessengerService = sMessengerService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessageAsync([FromBody] SMessengerDTO model)
        {
            try
            {
                await _sMessengerService.SendMessageAsync(model.ToNumber, model.Message);
                return Ok("Mensagem enviada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao enviar mensagem: {ex.Message}");
            }
        }
    }
}
