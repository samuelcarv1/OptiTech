using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiTech.Application.Mappings
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
    }
}
