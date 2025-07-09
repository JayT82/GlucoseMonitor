using GlucoseMonitor.Application.DTOs;
using GlucoseMonitor.Application.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MeasurementsController : ControllerBase
{
    private readonly IMeasurementService _service;

    public MeasurementsController(IMeasurementService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] MeasurementDto dto)
    {
        await _service.RegisterMeasurementAsync(dto);
        return Ok(new { message = "Measurement registered." });
    }

    [HttpGet("anomalies")]
    public async Task<IActionResult> GetAnomalies([FromQuery] double low = 3.9, [FromQuery] double high = 7.0)
    {
        var result = await _service.GetAnomaliesAsync(low, high);
        return Ok(new { anomalies = result });
    }
}
