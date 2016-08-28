using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.Models
{
    public interface IAgeRanger
    {
        string GetAgeDescription(int age);
    }
}
