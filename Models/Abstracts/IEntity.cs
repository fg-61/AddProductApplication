namespace ProductApplication.Models.Abstracts
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}