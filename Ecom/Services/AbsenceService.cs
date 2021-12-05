using Ecom.Data.Model;
using Ecom.Data.Repository;
using Ecom.Helpers;
using Ecom.ViewModel.Absence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecom.Services
{
    public class AbsenceService
    {
        private readonly AbsenceRepository _absenceRepository;

        public AbsenceService(AbsenceRepository absenceRepository)
        {
            _absenceRepository = absenceRepository;
        }

        public async Task<List<AbsenceViewModel>> FetchAllAbsences()
        {
            return Globals.Mapper.Map<List<Absence>, List<AbsenceViewModel>>(await _absenceRepository.FindAll());
        }
    }
}
