using Core.CrossCuttingConcerns.Exceptions.Types;
using MovieProject.DataAccess.Repositories.Abstracts;
using MovieProject.Service.Constants.Categories;

namespace MovieProject.Service.BusinessRules.Categories;


// Aynı kategori ismine sahip bir kategori eklenemez (Kategori adı unique olmalıdır.)
// Validasyon kuralı : Veri tabanına bir sorgu ihtiyacı duyulmaz
// İş kuralı : Veri tabanına sorgu ihtiyacı duyulur.

//ICategoryRepository categoryRepository : yaparak constructor kullanmak yerine dependency injection yaparak kullanımı sağladık.
//Primary Constructor yapısını kullanarak dependency injection yapısını kullandık.
//Bu yapiyi kullanmak icin program.cs'e services.AddScope<CategoryBusinessRules>(); eklememiz gerekmektedir.
//Bu da bize CategoryBusinessRules'in herhangi bir yerde new'lenecegi bilgisini verir.
public sealed class CategoryBusinessRules(ICategoryRepository categoryRepository)
{
    
    //private readonly ICategoryRepository _categoryRepository;

    //public CategoryBusinessRules(ICategoryRepository categoryRepository)
    //{
    //    _categoryRepository = categoryRepository;
    //}
    //Bu islemler yerine primary constructor yapısını kullanarak dependency injection yapısını kullandık.

    
    // Kategori var mı yok mu kontrolü
    public void CategoryIsPresent(int id)
    {
        bool isPresent = categoryRepository.Any(x => x.Id == id);

        // Eğer kategori yoksa
        // CategoryService'de if kosulu yazmadan sadelestirdik. If kontrololerimizi burada yaparak daha temiz bir kod yapısı oluşturduk.
        if (!isPresent)
        {
            throw new NotFoundException(CategoryMessages.NotFoundMessage);
        }
    }

    // Kategori adı unique olmalıdır.
    public void CategoryNameMustBeUnique(string name)
    {
        var category = categoryRepository.Any(x => x.Name.ToLower() == name.ToLower());
        if (category)
        {
            throw new BusinessException(CategoryMessages.NameMustBeUniqueMessage);
        }
    }
}