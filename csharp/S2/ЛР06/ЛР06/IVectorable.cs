namespace LR_6
{
    interface IVectorable
    {
        int this[int i] { get; set; }
        int Length { get; set; }
        double GetNorm();
    }
}
