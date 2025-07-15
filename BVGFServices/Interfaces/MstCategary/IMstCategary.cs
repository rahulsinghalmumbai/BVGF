using BVGF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVGFServices.Interfaces.MstCategary
{
    public  interface IMstCategary
    {
        Task<List<MstCategory>> GetAllAsync();
    }
}
