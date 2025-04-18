using System.Collections.Generic;
using System.Threading.Tasks;
using MyMicroservice.Domain.Entities;
using MyMicroservice.Infrastructure.Repositories;
using HotChocolate;

namespace MyMicroservice.GraphQL.Queries;

public class TioQuery
{
    public async Task<IEnumerable<Tio>> GetTios([Service] ITioRepository repository)
    {
        return await repository.GetAllAsync();
    }
}