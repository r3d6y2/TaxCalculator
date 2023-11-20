using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Domain.Services.Commands;
using TaxCalculator.Domain.Services.Interfaces;
using TaxCalculator.Infrastructure.Api.Models;

namespace TaxCalculator.Infrastructure.Api.Controllers;

[ApiController]
[Route("Tax")]
public class TaxController : ControllerBase
{
    private readonly ICommandHandler<CalculateTaxCommand, CalculateTaxCommand.Reply> _handler;
    private readonly IMapper _mapper;
    private readonly ILogger<TaxController> _logger;

    public TaxController(ICommandHandler<CalculateTaxCommand, CalculateTaxCommand.Reply> handler, 
        IMapper mapper,
        ILogger<TaxController> logger)
    {
        _handler = handler;
        _mapper = mapper;
        _logger = logger;
    }
    
    [HttpPost]
    public async Task<IActionResult> Get([FromBody]TaxCalculationRequest request)
    {
        var reply = await _handler.Handle(new CalculateTaxCommand(request.IncomingSalary));
        return Ok(_mapper.Map<TaxCalculationResponse>(reply));
    }
}