using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.ValidatorService
{
    public interface IValidator<T> where T : class
    {
        bool IsValid(T entity);
    }
}
