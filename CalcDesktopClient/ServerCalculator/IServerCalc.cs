namespace CalcDesktopClient.ServerCalculator
{
    public interface IServerCalc
    {
        string Url { get; }
        string Calculate(string num1, string num2, string opr);
    }
}