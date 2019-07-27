namespace TipCalc.Core.Services
{
    interface ICalculationService
    {
        double TipAmount(double subTotal, int generosity);
    }
}
