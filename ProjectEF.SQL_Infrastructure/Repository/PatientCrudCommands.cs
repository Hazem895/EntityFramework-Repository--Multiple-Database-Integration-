using Microsoft.EntityFrameworkCore;
using ProjectEF.Domain.DomainModels;
using ProjectEF.Domain.IRepository;
using ProjectEF.ProjectEF.SQL_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEF.SQL_Infrastructure.Repository
{
    public class PatientCrudCommands : IPatientsCommand
    {
        private readonly ApplicationDbContext_SQL _context;

        public PatientCrudCommands(ApplicationDbContext_SQL context) { _context = context; }


        public async Task<IEnumerable<Patient>> ReadAll()
        {
            return _context.Patients.AsEnumerable();
        }

        public async Task<Patient?> ReadByCode(string Code)
        {
            return await _context.Patients.SingleOrDefaultAsync(x => x.Code == Code);
        }
        private async Task<Patient?> ReadByCode_ID(string Code)
        {
            var rec = await ReadByCode(Code);
            return await _context.Patients.SingleOrDefaultAsync(x => x.Code == Code && x.ID == rec.ID);
        }

        public async Task<bool> Create(Patient patient)
        {
            try
            {
                await _context.Patients.AddAsync(patient);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }


        public async Task<bool> Update(Patient patient)
        {
            try
            {
                Patient? record = await ReadByCode(patient.Code);
                Detached(record);

                //_context?.Entry(record).State = EntityState.Detached;
                if (record != null)
                {
                    _context.Patients.Update(patient);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        private void Detached(Patient? Item)
        {
            if (Item != null) _context.Entry(Item).State = EntityState.Detached;
        }

        public async Task<Patient?> ReadByID(Guid ID)
        {
            return await _context.Patients.SingleOrDefaultAsync(x => x.ID == ID);
        }

        public async Task<bool> Delete(Guid ID)
        {
            Patient? patient = await ReadByID(ID);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(string code)
        {
            Patient? patient = await ReadByCode_ID(code);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
