namespace AviShop.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}