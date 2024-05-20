public interface Rentible
{
    double GetCost(int months);
    bool IsReserved();
    bool Reserve(int months);
}
