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
            return returnedInstitution.InstitutionName;
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
