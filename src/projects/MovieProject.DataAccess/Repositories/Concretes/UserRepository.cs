using Core.DataAccess.Repositories;
using Core.Security.Entities;
using MovieProject.DataAccess.Contexts;
using MovieProject.DataAccess.Repositories.Abstracts;

namespace MovieProject.DataAccess.Repositories.Concretes;

public sealed class UserRepository : EfRepositoryBase<User, int, BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext context) : base(context)
    {
    }
}
