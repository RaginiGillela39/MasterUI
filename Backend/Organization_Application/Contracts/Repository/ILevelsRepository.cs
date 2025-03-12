using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQMS_Admin_Application.Contracts.Repository
{
    public interface ILevelsRepository
    {
        Task<IEnumerable<Levels>> GetAllLevelssAsync();
        Task<Levels> GetByIdLevelsAsync(Guid LevelsTypeId);
        Task<Guid> AddLevelsAsync(Levels Levels);
        Task UpdateLevelsAsync(Levels Levels);
        Task DeleteLevelsAsync(Levels Levels);
        Task<IEnumerable<Levels>> GetActiveLevelsAsync();
    }
}
