using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ServiceLayer
{
    public class InstitutionService
    {
        MediNoteEntities InstitutionContext = new MediNoteEntities();

        public void AddInstitution(string newInstitutionInfo)
        {
            InstitutionContext.spAddInstitution(newInstitutionInfo);
        }

        public string GetInstitutionByID(int institutionID)
        {
            var returnedInstitution = InstitutionContext.institution_table.Find(institutionID);
            if (returnedInstitution == null)
            {
                return null;
            }
            return returnedInstitution.InstitutionName;
        }

        public InstitutionDTO GetInstitutionByName(string name)
        {
            var returnedInstituion = InstitutionContext.spGetInstitutionByName(name);
            var institutionDTO = returnedInstituion
                .Select(i => new InstitutionDTO
                {
                    Id = i.ID,
                    InstitutionName = i.InstitutionName
                })
                .FirstOrDefault();
            return institutionDTO;
        }

        public void DeleteInstitutionByID(int institutionID)
        {
            InstitutionContext.spDeleteInstitution(institutionID);
        }

        public void UpdateInstitutionByID(int institutionID, string institutionName)
        {
            InstitutionContext.spUpdateInstitution(institutionID, institutionName);
        }
    }
}
