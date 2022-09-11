using WebShop;

namespace WebShopTests;

public class RabatBeregnerTest
{
    [Fact]
    public void Elleve_gratis_vare_skal_give_0()
    {
        Rabatberegner beregner = new Rabatberegner();

        string pris = beregner.GetPrisEfterRabat(11, 0).ToString();

        //Dette er blot en test på at den ikke fejler hvis varene er gratis
        Assert.Equal("0", pris);
    }

    [Fact]
    public void Nul_dyre_vare_skal_give_0()
    {
        Rabatberegner beregner = new Rabatberegner();

        string pris = beregner.GetPrisEfterRabat(0, 10000).ToString();

        //Dette er blot en test på at den ikke fejler ved 0 vare
        Assert.Equal("0", pris);
    }


    [Fact]
    public void Ti_eller_derunder_vare_til_1000_eller_derunder_skal_ikke_give_rabat() 
    {
        Rabatberegner beregner = new Rabatberegner();

        string pris = beregner.GetPrisEfterRabat(10, 100).ToString();

        // Normalpris er 10 x 100 = 1000
        // Da antalet kun er 10 og beløbet er 1000 gives der ikke noget rabat
        Assert.Equal("1000", pris);
    }
    
    [Fact]
    public void Under_11_vare_over_1000_skal_give_3_procent_rabat()
    {
        Rabatberegner beregner = new Rabatberegner();

        string pris = beregner.GetPrisEfterRabat(10, 101).ToString();

        // Normalpris er 10 x 101 = 1010
        // Forventer 3% rabet på købet da antalet kun er 10, men beløbet er over 1000
        // 3% rabat af 1010 er 30,3
        // Forventetpris efter rabat er 979.7
        Assert.Equal("979,7", pris);
    }

    [Fact]
    public void Elleve_eller_derover_vare_til_1000_eller_derunder_skal_give_2_procent_rabat()
    {
        Rabatberegner beregner = new Rabatberegner();

        string pris = beregner.GetPrisEfterRabat(11, 50).ToString();

        // Normalpris er 11 x 50 = 550
        // Forventer 5% rabet på købet da antalet er over 10, men beløbet blot er 550 
        // 2% rabat af 550 er 11
        // Forventetpris efter rabat er 539
        Assert.Equal("539", pris);
    }

    [Fact]
    public void Elleve_eller_derover_vare_over_1000_skal_give_5_procent_rabat()
    {
        Rabatberegner beregner = new Rabatberegner();

        string pris = beregner.GetPrisEfterRabat(11, 100).ToString();

        // Normalpris er 11 x 1000 = 1100
        // Forventer 5% rabet på købet da både antalet er over 10 og beløbet er over 1000
        // 5% rabat af 1100 er 55
        // Forventetpris efter rabat er 1045
        Assert.Equal("1045", pris);
    }

    [Fact]
    public void Elleve_eller_derover_vare_over_1000_skal_give_5_procent_rabat_Decimal()
    {
        Rabatberegner beregner = new Rabatberegner();

        string pris = beregner.GetPrisEfterRabat(11, 100.50).ToString();

        // Normalpris er 11 x 100,5 = 1105,5
        // Forventer 5% rabet på købet da både antalet er over 10 og beløbet er over 1000
        // 5% rabat af 1105,5 er 55,275
        // Forventetpris efter rabat er 1.050,225
        Assert.Equal("1050,225", pris);
    }
}