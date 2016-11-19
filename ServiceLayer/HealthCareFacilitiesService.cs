using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ServiceLayer
{
    class HealthCareFacilitiesService
    {

        MediNoteEntities FacilitesContext = new MediNoteEntities();

        public void AddHealthcareFacilite(string newFaciliteName)
        {
            FacilitesContext.spAddNewHealthcareFacilitie(newFaciliteName);
        }

        public string GetFacilityByID(int facilityID)
        {
            var returnedFacility = FacilitesContext.healthcareFacilities_table.Find(facilityID);
            return returnedFacility.FacilityName;
        }

        public void DeleteFacilityByID(int facilityID)
        {
            FacilitesContext.spDeleteHealthcareFacilitieByID(facilityID);
        }

        public void UpdateFacilityByID(int facilityID, string facilityName)
        {
            FacilitesContext.spUpdateHealthcareFacilitieByID(facilityID, facilityName);
        }
    }
}

