namespace LR_7
{
    public interface IVectorable
    {
        int this[int i] { get; set; }
        int Length { get; set; }
        double GetNorm();
    }
}
