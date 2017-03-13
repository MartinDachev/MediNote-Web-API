using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ServiceLayer
{
    public class HealthCareFacilitiesService
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

        public HealthCareFacilitesDTO GetFacilityByName(string name)
        {
            var returnedFacility = FacilitesContext.spGetHealthcareFacilitieByName(name)
                .Select(h => new HealthCareFacilitesDTO()
                {
                    Id = h.ID,
                    FacilityName = h.FacilityName
                }).FirstOrDefault();

            return returnedFacility;
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

