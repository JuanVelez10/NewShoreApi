using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IStoreRepository
    {
        public List<Store> GetAll();

        public bool Insert(Store store);
    }
}
