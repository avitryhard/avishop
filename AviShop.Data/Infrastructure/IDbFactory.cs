using System;

namespace AviShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        AviShopDbContext Init();
    }
}