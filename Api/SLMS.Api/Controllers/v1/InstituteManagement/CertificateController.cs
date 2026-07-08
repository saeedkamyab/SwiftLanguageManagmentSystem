using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SLMS.Application.Features.InstituteManagement.Certificate.Commands;
using SLMS.Application.Features.InstituteManagement.Certificate.Queries;
using SLMS.Dto.InstituteManagement;
using SLMS.Shared;
using SLMS.Shared.Enums;

namespace SLMS.Api.Controllers.v1.InstituteManagement
{
    [Authorize]
    [Route("api/certificates")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public CertificateController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<CertificateQueryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] Guid? classificationId = null,
            [FromQuery] CertificateStatus? status = null,
            CancellationToken cancellationToken = default)
        {
            var query = new GetCertificatesQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                ClassificationId = classificationId,
                Status = status
            };

            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CertificateQueryResponse>> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetCertificateByIdQuery { Id = id }, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCertificateDto certificate, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateCertificateCommand>(certificate);
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateCertificateDto certificate, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateCertificateCommand>(certificate);
            command.Id = id;
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id, [FromBody] DeleteCertificateDto certificate, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<DeleteCertificateCommand>(certificate);
            command.Id = id;
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }
    }
}
