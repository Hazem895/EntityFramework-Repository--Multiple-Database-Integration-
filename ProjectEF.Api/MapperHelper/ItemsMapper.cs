using AutoMapper;
using ProjectEF.Domain.DomainModels;
using ProjectEF.Shared.CommandsModels;
using ProjectEF.Shared.DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEF.Api.MapperHelper
{
    public static class ItemsMapper
    {
        private static MapperConfiguration DtoConfig
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
                    cfg.CreateMap<PatientAdminDTO, Patient>();
                });
            }
        }


        public static Patient CreateMapper(this CreatedPatient createdPatient)
        {
            var returnedItem = new Mapper(DtoConfig).Map<Patient>(createdPatient); ;
            returnedItem.ID = Guid.NewGuid();

            return returnedItem;
        }
        public static Patient UpdateMapper(this UpdatedPatient updatedPatient, Guid Id)
        {
            var returnedItem = new Mapper(DtoConfig).Map<Patient>(updatedPatient);
            returnedItem.ID = Id;

            return returnedItem;
        }

        public static PatientAdminDTO ToDto(this Patient CC)
        {
            return new Mapper(DtoConfig).Map<PatientAdminDTO>(CC); ;
        }

        public static IEnumerable<PatientAdminDTO> ToDto(this IEnumerable<Patient> CC)
        {
            return new Mapper(DtoConfig).Map<IEnumerable<PatientAdminDTO>>(CC); ;
        }

        public static Patient ToDomain(this PatientAdminDTO CC)
        {
            return new Mapper(DomainConfig).Map<Patient>(CC); ;
        }

        public static IEnumerable<Patient> ToDomain(this IEnumerable<PatientAdminDTO> CC)
        {

            return new Mapper(DomainConfig).Map<IEnumerable<Patient>>(CC); ;
        }
    }
}
