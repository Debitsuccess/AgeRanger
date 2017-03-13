using System.Collections.Generic;
using System.Linq;
using Infrastructure.IRepository;
using Infrastructure.Model;
using Infrastructure.Service;

namespace Infrastructure.Repository
{
    public class AgeGroupRepository : IAgeGroupRepository
    {
        private readonly AgeRangerContext _db;

        public AgeGroupRepository(AgeRangerContext db)
        {
            _db = db;
        }

        public IEnumerable<AgeGroup> GetAll()
        {
            return _db
                .AgeGroups
                .ToList();
        }
    }
}