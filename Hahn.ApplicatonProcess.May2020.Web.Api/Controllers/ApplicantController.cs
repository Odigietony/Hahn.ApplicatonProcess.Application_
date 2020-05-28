using Hahn.ApplicatonProcess.May2020.Application.Interfaces;
using Hahn.ApplicatonProcess.May2020.Domain.Application.Dto;
using Hahn.ApplicatonProcess.May2020.Domain.Dto;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Web.Api.Controllers
{
    /// <summary>
    /// The applicant api controller.
    /// Handles the Post,Put,Get and Delete requests.
    /// </summary>
    [Route("api/applicant")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantInterface _applicant;  
        /// <summary>
        /// Include the required services needed to execute requests.
        /// </summary>
        /// <param name="applicant"></param>
        public ApplicantController(IApplicantInterface applicant)
        {
            _applicant = applicant; 
        }


        /// <summary>
        /// Get all applicants data.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ApplicantDto>))]
        public IActionResult Get()
        {
            var applicantObj = _applicant.Read();
            return Ok(applicantObj);
        } 


        /// <summary>
        /// Get the object by the given id
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns></returns>
        [HttpGet("{applicantId:int}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicantDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async  Task<IActionResult> Get(int applicantId)
        {
            var result = await _applicant.Find(applicantId); 
            return result != null ? (IActionResult) Ok(result) : NotFound(); 
        }
 

        /// <summary>
        /// Create a new applicant object
        /// </summary>
        /// <param name="applicantDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateApplicantDto))]
        public async Task<IActionResult> Post([FromBody] CreateApplicantDto applicantDto)
        {
            var result = await _applicant.Create(applicantDto);
            return result > -1 ? (IActionResult) CreatedAtAction(nameof(Get), 
                new { id = result }, applicantDto) : BadRequest(); 
        }

 
        /// <summary>
        /// To update the object with the given id
        /// </summary>
        /// <param name="applicantId">The Id of the record to be updated </param>
        /// <param name="applicantDto">The body parameters</param>
        /// <returns></returns>
        [HttpPut("{applicantId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)] 
        public async Task<IActionResult> Put(int applicantId, [FromBody] UpdateApplicantDto applicantDto)
        {
            var result = await _applicant.Update(applicantId, applicantDto);
            return result != null ? (IActionResult) NoContent() : BadRequest(); 
        }

 
        /// <summary>
        /// To delete the object with the given Id
        /// </summary>
        /// <param name="applicantId">The Id of the record to be deleted</param>
        /// <returns></returns>
        [HttpDelete("{applicantId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int applicantId)
        {
            var result = await _applicant.Delete(applicantId);
            return result ? (IActionResult)NoContent() : BadRequest(); 
        }
    }
}
