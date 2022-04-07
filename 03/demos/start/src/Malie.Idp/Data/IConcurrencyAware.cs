namespace Malie.Idp.Data
{
    public interface IConcurrencyAware
    {
        public string ConcurrencyStamp { get; set; }
    }
}