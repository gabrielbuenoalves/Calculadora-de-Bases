namespace Trabalho_Arquitetura.Controllers;
using Microsoft.AspNetCore.Mvc;
using Trabalho_Arquitetura.Model;
using Trabalho_Arquitetura.Service;

[ApiController]
[Route("api/[controller]")]
public class ConversaoDeBasesController : ControllerBase
{
    private readonly ConversaoDeBasesService _baseConversionService;

    public ConversaoDeBasesController(ConversaoDeBasesService baseConversionService)
    {
        _baseConversionService = baseConversionService ?? throw new ArgumentNullException(nameof(baseConversionService)); ;
    }

    [HttpPost("convert")]
    public ActionResult<OperadoresModel> ConvertBase([FromBody] OperadoresModel model)
    {
        try
        {
            var result = _baseConversionService.ConvertBase(model);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
} 