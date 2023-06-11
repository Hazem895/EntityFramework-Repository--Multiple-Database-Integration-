using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEF.Api.MapperHelper;
using ProjectEF.BL.Service;
using ProjectEF.BL.Service.IService;
using ProjectEF.Domain.DomainModels;
using ProjectEF.Domain.IRepository;
using ProjectEF.Shared.CommandsModels;
using ProjectEF.Shared.DataObjectLayer;
using System.Text.Json;

namespace ProjectEF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientServices _srv;
        JsonSerializerOptions Options;
        public PatientsController(IPatientServices srv)
        {
            this._srv = srv;
            Options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

        }

        [HttpPost("{loggedUser:Guid}")]
        public async Task<ActionResult<PatientSrvResponse>> SaveRequest(string createdPatientJSON, Guid loggedUser)
        {
            PatientSrvResponse result;
            try
            {
                var createdPatient = JsonSerializer.Deserialize<PatientAdminDTO>(createdPatientJSON, Options);
                result = await _srv.PatientCreate(createdPatient, loggedUser);
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPut("{loggedUser:Guid}")]
        public async Task<ActionResult<PatientSrvResponse>> UpdateRequest(string updatedPatientJSON, Guid loggedUser)
        {
            try
            {
                var createdPatient = JsonSerializer.Deserialize<PatientAdminDTO>(updatedPatientJSON, Options);
                return await _srv.PatientUpdate(createdPatient, loggedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpDelete("{code}/{loggedUser:Guid}")]
        public async Task<ActionResult<PatientSrvResponse>> DeleteRequest(string code, Guid loggedUser)
        {
            try
            {
                return await _srv.PatientDelete(code, loggedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{loggedUser:Guid}")]
        public async Task<ActionResult<List<PatientDTO>>> SelectRequest(Guid loggedUser)
        {
            try
            {
                var result = await _srv.GetPatients(loggedUser);
                return result.ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{code}/{loggedUser:Guid}")]
        public async Task<ActionResult<PatientDTO>> SelectByIdRequest(string code, Guid loggedUser)
        {
            try
            {
                return (await _srv.GetPatientByCode(code, loggedUser));
            }
            catch (Exception)
            {
                return NoContent();
            }
        }


    }
}
