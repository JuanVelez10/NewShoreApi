using Application.References;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IJourneyServices
    {
        public Task<BaseResponse<List<Journey>>> Get(string origin, string destination, int route);
    }
}
