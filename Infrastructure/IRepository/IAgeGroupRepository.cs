using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Model;

namespace Infrastructure.IRepository
{
    public interface IAgeGroupRepository
    {
        IEnumerable<AgeGroup> GetAll();
    }
}
