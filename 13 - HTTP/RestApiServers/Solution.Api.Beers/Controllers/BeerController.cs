namespace Solution.Api.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesResponseType(typeof(GlobalErrorResponse), (int)HttpStatusCode.BadRequest)]
public partial class BeerController(IBeerService<Beer, int> service) : ControllerBase
{
    [HttpGet]
    [Route("/api/beer/get-total-count")]
    [SwaggerOperation(OperationId = "getCount")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(int))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetCount()
    {
        return Ok(await Task.FromResult(service.GetCount()));
    }

    [HttpGet]
    [Route("/api/beer/get-all")]
    [SwaggerOperation(OperationId = "getAll")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<Beer>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Task.FromResult(service.GetAll()));
    }

    [HttpGet]
    [Route("/api/beer/get/{id}")]
    [SwaggerOperation(OperationId = "get")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Beer))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetByid([FromRoute][Required] int id)
    {
        return Ok(await Task.FromResult(service.GetById(id)));
    }

    [HttpGet]
    [Route("/api/beer/get-page/{page}")]
    [SwaggerOperation(OperationId = "getByPage")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<Beer>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetByPage([FromRoute][Required] int page, [FromQuery][Required] int itemsPerPage)
    {
        return Ok(await Task.FromResult(service.GetByPage(page, itemsPerPage)));
    }

    [HttpDelete]
    [Route("/api/beer/delete/{id}")]
    [SwaggerOperation(OperationId = "delete")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete([FromRoute][Required] int id)
    {
        service.Delete(id);
        return Ok(await Task.FromResult(true));
    }

    [HttpPost]
    [Route("/api/beer/create")]
    [SwaggerOperation(OperationId = "create")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Beer))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody][Required] Beer requestParam)
    {
        return Ok(service.Create(requestParam));
    }

    [HttpPut]
    [Route("/api/beer/update")]
    [SwaggerOperation(OperationId = "update")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update([FromBody][Required] Beer requestParam)
    {
        service.Update(requestParam);
        return Ok(await Task.FromResult(true));
    }

    
}
