using System;

namespace AviShop.Data.Infrasctucture
{
    public interface IDbFactory : IDisposable
    {
        AviShopDbContext Init();
    }
}