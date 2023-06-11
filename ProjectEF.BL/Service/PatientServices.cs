using ProjectEF.Domain.DomainModels;
using ProjectEF.Domain.IRepository;
using ProjectEF.Shared.DataObjectLayer;
using ProjectEF.BL.MapperHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEF.Shared.CommandsModels;
using ProjectEF.BL.Service.IService;
using System.Net;

namespace ProjectEF.BL.Service
{
    public class PatientServices : IPatientServices
    {
        private readonly IPatientsCommand _patientSrv;
        private readonly IUserServices _userSrv;

        public PatientServices(IPatientsCommand patientSrv, IUserServices userSrv)
        {
            _patientSrv = patientSrv;
            _userSrv = userSrv;
        }
        public async Task<PatientSrvResponse> PatientCreate(PatientAdminDTO createdPatient, Guid loggedUser)
        {
            var isUserAdmin = await _userSrv.IsUserAdmin(loggedUser);
            if (!isUserAdmin)
            {
                return new()
                {
                    IsValid = false,
                    ResponseMessage = "Not Authorized",
                    HttpStatusCode = HttpStatusCode.Forbidden
                };
            }
            var codeCheck = GetPatientByCode(createdPatient.Code,loggedUser);
            if (codeCheck != null || codeCheck != default)
            {
                return new()
                {
                    IsValid = false,
                    ResponseMessage = "Patient with the same code exist",
                    HttpStatusCode = HttpStatusCode.Forbidden
                };
            }
            var isCreated = await _patientSrv.Create(createdPatient.CreateMapper());
            if (!isCreated)
            {
                return new() { IsValid = false, ResponseMessage = "Something went wrong", HttpStatusCode = HttpStatusCode.InternalServerError };
            }
            return new()
            {
                IsValid = true,
                ResponseMessage = "Created Successfully",
                HttpStatusCode = HttpStatusCode.OK
            };
        }
        public async Task<PatientSrvResponse> PatientUpdate(PatientAdminDTO updatedPatient, Guid loggedUser)
        {
            var isUserAdmin = await _userSrv.IsUserAdmin(loggedUser);
            if (!isUserAdmin)
            {
                return new()
                {
                    IsValid = false,
                    ResponseMessage = "Not Authorized",
                    HttpStatusCode = HttpStatusCode.Unauthorized
                };
            }

            var isUpdated = await _patientSrv.Update(updatedPatient.UpdateMapper());
            if (!isUpdated)
            {
                return new() { IsValid = false, ResponseMessage = "Something went wrong", HttpStatusCode = HttpStatusCode.InternalServerError };
            }
            return new()
            {
                IsValid = true,
                ResponseMessage = "Updated Successfully",
                HttpStatusCode = HttpStatusCode.OK
            };
        }
        public async Task<PatientSrvResponse> PatientDelete(string code, Guid loggedUser)
        {
            var isUserAdmin = await _userSrv.IsUserAdmin(loggedUser);
            if (!isUserAdmin)
            {
                return new()
                {
                    IsValid = false,
                    ResponseMessage = "Not Authorized",
                    HttpStatusCode = HttpStatusCode.Unauthorized
                };
            }
            var codeCheck = GetPatientByCode(code, loggedUser);
            if (codeCheck != null || codeCheck != default)
            {
                return new()
                {
                    IsValid = false,
                    ResponseMessage = "Patient with the same code exist",
                    HttpStatusCode = HttpStatusCode.Forbidden
                };
            }

            var isDeleted = await _patientSrv.Delete(code);
            if (!isDeleted)
            {
                return new() { IsValid = false, ResponseMessage = "Something went wrong", HttpStatusCode = HttpStatusCode.InternalServerError };
            }
            return new() { IsValid = true, ResponseMessage = "Deleted successfully", HttpStatusCode = HttpStatusCode.OK };
        }
        public async Task<PatientDTO> GetPatientByCode(string code, Guid loggedUser)
        {
            PatientDTO result;
            var isUserAdmin = await _userSrv.IsUserAdmin(loggedUser);
            if (isUserAdmin)
            {
                result = (await _patientSrv.ReadByCode(code)).ToAdminDto();
            }
            else { result = (await _patientSrv.ReadByCode(code)).ToDto(); }
            return result;
        }
        public async Task<IEnumerable<PatientDTO>> GetPatients(Guid loggedUser)
        {
            IEnumerable<PatientDTO> result;
            var isUserAdmin = await _userSrv.IsUserAdmin(loggedUser);
            if (isUserAdmin)
            {
                result = (await _patientSrv.ReadAll()).ToAdminDto();

            }
            else { result = (await _patientSrv.ReadAll()).ToDto(); }
            return result;
        }

    }

    public class PatientSrvResponse
    {
        public bool IsValid { get; set; }
        public string ResponseMessage { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
