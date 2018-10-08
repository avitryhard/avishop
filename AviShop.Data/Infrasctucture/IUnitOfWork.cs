namespace AviShop.Data.Infrasctucture
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}