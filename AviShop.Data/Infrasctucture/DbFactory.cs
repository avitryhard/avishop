namespace AviShop.Data.Infrasctucture
{
    public class DbFactory : Disposable, IDbFactory
    {
        private AviShopDbContext dbContext;

        public AviShopDbContext Init()
        {
            return dbContext ?? (dbContext = new AviShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}