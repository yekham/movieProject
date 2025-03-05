using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.CrossCuttingConcerns.Exceptions.Types.Validation;

namespace Core.CrossCuttingConcerns.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    //async methodlar dosya okuma, veritabani islemleri, ag islemleri, vs. gibi islemlerde kullanilir.
    // Normal bu yapilar birbirini bekler ama biz bu yapi sayesinde eszamanli calisma yapilmasini saglar.
    
    
    //Abstract class'da async methodlarin imzasi Task ile tanimlanir.
    public Task HandleExceptionAsync(Exception exception)
    {
        return exception switch
        {
            BusinessException businessException => HandleException(businessException),
            NotFoundException notFoundException => HandleException(notFoundException),
            ValidationException validationException => HandleException(validationException),
            _ => HandleException(exception)

        };
    }

    // switch expression

    protected abstract Task HandleException(NotFoundException notFoundException);
    protected abstract Task HandleException(BusinessException businessException);
    //Handle etmedigimiz istisnalar icin default olarak Exception tipini kullaniriz.
    protected abstract Task HandleException(Exception exception);
    protected abstract Task HandleException(ValidationException validationException);
}