using AutoMapper;
using ProjectEF.Domain.DomainModels;
using ProjectEF.Shared.CommandsModels;
using ProjectEF.Shared.DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEF.BL.MapperHelper
{
    public static class PatientMapper
    {
        private static MapperConfiguration DtoConfig
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Patient, PatientDTO>();
                });
            }
        }
        private static MapperConfiguration DtoAdminConfig
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Patient, PatientAdminDTO>();
                });
            }
        }

        private static MapperConfiguration DomainConfig
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PatientDTO, Patient>();
                });
            }
        }
        private static MapperConfiguration DomainAdminConfig
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PatientAdminDTO, Patient>();
                });
            }
        }


        public static Patient CreateMapper(this PatientAdminDTO createdPatient)
        {
            var returnedItem = new Mapper(DtoConfig).Map<Patient>(createdPatient); ;
            returnedItem.ID = Guid.NewGuid();

            return returnedItem;
        }
        public static Patient UpdateMapper(this PatientAdminDTO updatedPatient)
        {
            var returnedItem = new Mapper(DtoConfig).Map<Patient>(updatedPatient);
            return returnedItem;
        }

        public static PatientDTO ToDto(this Patient CC)
        {
            return new Mapper(DtoConfig).Map<PatientDTO>(CC); ;
        }
        public static PatientAdminDTO ToAdminDto(this Patient CC)
        {
            return new Mapper(DtoAdminConfig).Map<PatientAdminDTO>(CC); ;
        }

        public static IEnumerable<PatientAdminDTO> ToAdminDto(this IEnumerable<Patient> CC)
        {
            return new Mapper(DtoAdminConfig).Map<IEnumerable<PatientAdminDTO>>(CC); ;
        }
        public static IEnumerable<PatientDTO> ToDto(this IEnumerable<Patient> CC)
        {
            return new Mapper(DtoConfig).Map<IEnumerable<PatientDTO>>(CC); ;
        }

        public static Patient ToDomain(this PatientAdminDTO CC)
        {
            return new Mapper(DomainAdminConfig).Map<Patient>(CC); ;
        }
        public static Patient ToDomain(this PatientDTO CC)
        {
            return new Mapper(DomainConfig).Map<Patient>(CC); ;
        }

        public static IEnumerable<Patient> ToDomain(this IEnumerable<PatientDTO> CC)
        {

            return new Mapper(DomainConfig).Map<IEnumerable<Patient>>(CC); ;
        }
        public static IEnumerable<Patient> ToAdminDomain(this IEnumerable<PatientAdminDTO> CC)
        {

            return new Mapper(DomainAdminConfig).Map<IEnumerable<Patient>>(CC); ;
        }
    }
}
