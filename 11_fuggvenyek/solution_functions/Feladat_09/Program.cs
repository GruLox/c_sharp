using IOLibrary;

const double USD = 0.8;
const double JPY = 0.75;
const double CHF = 0.55;

int huf = ExtendedConsole.ReadInteger("Kérem adja meg a pénzösszeget HUF-ban");

double eur = (double)huf / 400;

bool isCurrency = false;
Currency currency;
do
{
    string input = ExtendedConsole.ReadString("Kérem adja meg a cél valutát (USD, CHF, JPY): ");
    Enum.TryParse(input, true, out isCurrency);

} while (!isCurrency);


public enum Currency
{
    JPY,
    USD,
    CHF
}