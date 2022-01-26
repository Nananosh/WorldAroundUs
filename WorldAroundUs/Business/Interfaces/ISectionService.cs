using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorldAroundUs.ViewModels;

namespace WorldAroundUs
{
    public interface ISectionService
    {
        List<SectionViewModel> GetAllSections();
        Task<List<SubsectionViewModel>> GetSubsectionBySectionId(int id);
        void RemoveSection(SectionViewModel model);
        void RemoveSubsection(SubsectionViewModel model);
        SectionViewModel UpdateSection(SectionViewModel model);
        SubsectionViewModel UpdateSubsection(SubsectionViewModel model);
        SectionViewModel CreateSection(SectionViewModel model);
        SubsectionViewModel CreateSubsection(SubsectionViewModel model);
        IEnumerable<SubsectionViewModel> GetAllSubsections();
    }
}