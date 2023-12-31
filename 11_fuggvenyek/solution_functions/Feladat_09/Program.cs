﻿using IOLibrary;

const double USD = 0.8;
const double JPY = 0.75;
const double CHF = 0.55;

int huf = ExtendedConsole.ReadInteger("Kérem adja meg a pénzösszeget HUF-ban: ", int.MaxValue, 0);

double eur = (double)huf / 400;

bool isCurrency = false;
Currency currency;
do
{
    string input = ExtendedConsole.ReadString("Kérem adja meg a cél valutát (USD, CHF, JPY): ");
    isCurrency = Enum.TryParse(input, true, out currency);

} while (!isCurrency);

double convertedValue = currency switch {
    Currency.USD => eur / USD,
    Currency.CHF => eur / CHF,
    Currency.JPY => eur / JPY,
};

Console.WriteLine($"{huf} HUF = {eur} EUR");
Console.WriteLine($"{huf} HUF = {convertedValue} {currency}");
