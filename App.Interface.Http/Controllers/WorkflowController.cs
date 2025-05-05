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
            if (workflowDto == null)
            {
                return BadRequest("Invalid workflow data.");
            }
            workflowDto.ExternalKey = workflowGuid;

            var command = new ValidateAndSaveWorkflowCommand
            {
                ServiceProvider = serviceProvider,
                WorkflowDto = workflowDto
            }.Execute();

            if (command.OutcomeFlags == OutcomeFlags.Success)
            {
                return StatusCode(200);
            }

            if (command.OutcomeFlags == OutcomeFlags.Invalid)
            {
                return StatusCode(400);
            }

            return StatusCode(500, command);
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
            if (outcome.IsInvalid())
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            if (outcome.IsSuccess())
            {
                // return workflowDto as JsonResult;
                return Ok(workflowDto);
            }

            // Assuming the workflow exists. Otherwise, return NotFound.
            return Ok(workflowDto);
        }
    }
}