using GlucoseMonitor.Application.DTOs;
using GlucoseMonitor.Application.Services;
using GlucoseMonitor.Infrastructure.Messaging;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("api/[controller]")]
public class MeasurementsController : ControllerBase
{
    private readonly IMeasurementService _service;
    private readonly IMessageQueueService _queueService;

    public MeasurementsController(IMeasurementService service, IMessageQueueService queueService)
    {
        _service = service;
        _queueService = queueService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] MeasurementDto dto)
    {
        await _service.RegisterMeasurementAsync(dto);
        return Ok(new { message = "Measurement registered." });
    }

    [HttpPost("register-buffered")]
    public async Task<IActionResult> RegisterAlways([FromBody] MeasurementDto dto)
    {
        var json = JsonConvert.SerializeObject(dto);
        await _queueService.SendMessageAsync(json); // robuuste buffer
        return Ok(new { message = "Measurement accepted." });
    }

    [HttpGet("anomalies")]
    public async Task<IActionResult> GetAnomalies([FromQuery] double low = 3.9, [FromQuery] double high = 7.0)
    {
        var result = await _service.GetAnomaliesAsync(low, high);
        return Ok(new { anomalies = result });
    }

    [HttpGet("measurements")]
    public async Task<IActionResult> GetAll()
    {
        var measurements = await _service.GetAllAsync();
        return Ok(measurements);
    }
}
