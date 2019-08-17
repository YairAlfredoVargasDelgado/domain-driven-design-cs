using infraestructure.data.generics;
using domain.entities;
using Microsoft.EntityFrameworkCore;

namespace infraestructure.data.contracts.onlinestore.repositories
{
    public class ClienteRepository : Repository<Cliente>
    {
        public ClienteRepository(DbContext context) : base(context) { }
    }
}