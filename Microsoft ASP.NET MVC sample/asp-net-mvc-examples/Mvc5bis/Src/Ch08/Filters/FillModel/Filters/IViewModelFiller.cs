namespace FillModel.Filters
{
    public interface IViewModelFiller<in T>
    {
        void Fill(T model);
    }
}