using FirstDapper.Models;
using System.Collections.Generic;
namespace FirstDapper.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}