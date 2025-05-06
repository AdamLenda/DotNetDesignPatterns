using System;
using System.Net;
using App.Commands;
using Microsoft.AspNetCore.Mvc;
using App.DataTransportObjects;
using App.Services;
using App.Patterns;

namespace App.Interface.Http.Controllers
{
    [ApiController]
    [Route("workflow")]
    public class WorkflowController(IServiceProvider serviceProvider) : ControllerBase
    {
        [HttpPut("{workflowGuid}")]
        public IActionResult CreateOrReplaceWorkflow(Guid workflowGuid, [FromBody] IWorkflowDto workflowDto)
        {
            workflowDto.ExternalKey = workflowGuid;

            var command = new ValidateAndSaveWorkflowCommand
            {
                ServiceProvider = serviceProvider,
                WorkflowDto = workflowDto
            };

            var outcome = command.Execute();

            if (outcome.IsSuccess())
            {
                return Ok();
            }

            if (outcome.IsInvalid())
            {
                return this.BadRequest(outcome.Messages);
            }

            return StatusCode((int)HttpStatusCode.InternalServerError, outcome.Messages);
        }

        [HttpGet("{workflowGuid}")]
        public IActionResult GetWorkflow(Guid workflowGuid)
        {
            // Replace the following dummy implementation with actual retrieval logic.
            var workflowDto = new WorkflowDto
            {
                ExternalKey = workflowGuid
            };

            var outcome = serviceProvider.GetRequiredService<IServiceFactory>().WorkflowService().PopulateWorkflowDto(workflowDto);
            if (outcome.IsFound())
            {
                return Ok(workflowDto);
            }
            if (outcome.IsNotFound())
            {
                return NotFound();
            }
            if (outcome.IsInvalid())
            {
                return BadRequest(outcome.Messages);
            }

            return StatusCode((int)HttpStatusCode.InternalServerError, outcome.Messages);
        }
    }
}