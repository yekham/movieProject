using Core.DataAccess.Repositories;
using MovieProject.DataAccess.Contexts;
using MovieProject.DataAccess.Repositories.Abstracts;
using MovieProject.Model.Entities;

namespace MovieProject.DataAccess.Repositories.Concretes;

//EfRepository'den turemistir(inheritance) IArtistRepository'den implement edilmistir.
//IArtistRepository'den turetilseydi metodlarin icini doldurmak zorunda kalacaktik.
public sealed class ArtistRepository : EfRepositoryBase<Artist, long, BaseDbContext>, IArtistRepository
{
    public ArtistRepository(BaseDbContext context) : base(context)
    {
    }
}