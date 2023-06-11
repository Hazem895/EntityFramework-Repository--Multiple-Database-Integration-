using ProjectEF.Shared.DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEF.BL.Service.IService
{
    public interface IPatientServices
    {
        Task<PatientSrvResponse> PatientCreate(PatientAdminDTO createdPatient,Guid loggedUser);
        Task<PatientSrvResponse> PatientUpdate(PatientAdminDTO updatedPatient, Guid loggedUser);
        Task<PatientSrvResponse> PatientDelete(string code, Guid loggedUser);
        Task<PatientDTO> GetPatientByCode(string code, Guid loggedUser);
        Task<IEnumerable<PatientDTO>> GetPatients( Guid loggedUser);
    }
}
