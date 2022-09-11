namespace WebShop;

public class Rabatberegner
{
    public double GetPrisEfterRabat(int antalVarer, double stykPris)
    {
        double bruttoPris = antalVarer * stykPris;
        double resultPrice = bruttoPris;

        bool largeamount = (bruttoPris > 1000);
        bool largevalue = (antalVarer > 10);

        if (largeamount && !largevalue)
        {
            // Indkøb over 1000 kr, men 10 vare eller under: giver 3% rabat
            double rabat = bruttoPris * 0.03;
            resultPrice = resultPrice - rabat;
        }
        else if (largevalue && !largeamount)
        {
            // Under 1000 men flere end 10 varer: giver 2% rabat
            double rabat = bruttoPris * 0.02;
            resultPrice = resultPrice - rabat;
        }
        else if (largeamount && largevalue)
        {
            // Over 1000 og flere end 10 varer: giver 5% rabat
            double rabat = bruttoPris * 0.05;
            resultPrice = resultPrice - rabat;
        }

        return resultPrice;
    }
}