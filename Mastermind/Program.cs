IEnumerable<string> foo = GenerierePermutationen("1233");
Console.WriteLine(string.Concat(foo.Select(x=>x+" ")));

Generiere(2013, 2);
 static void Generiere(int zuErrateneZahl, int anzahlDerHinweise)
{
    var zuErrateneZahlString = zuErrateneZahl.ToString();
    var möglicheZahlen = GenerierePermutationen(zuErrateneZahlString).ToList();
    var hinweise = new List<(int zahl, int richtig, int falsch)>();

    while (hinweise.Count < anzahlDerHinweise && möglicheZahlen.Count > 1)
    {
        var index = new Random().Next(möglicheZahlen.Count);
        var ausgewählteZahl = möglicheZahlen[index];
        var hinweis = BerechneHinweis(zuErrateneZahlString, ausgewählteZahl);

        hinweise.Add((int.Parse(ausgewählteZahl), hinweis.richtig, hinweis.falsch));
        möglicheZahlen = FilterMöglicheZahlen(möglicheZahlen, hinweis, ausgewählteZahl);
    }

    // Ergebnisse ausgeben
    foreach (var hinweis in hinweise)
    {
        Console.WriteLine($"{hinweis.zahl} ({hinweis.richtig},{hinweis.falsch})");
    }
}

 static IEnumerable<string> GenerierePermutationen(string zahl)
{
    return zahl.Length == 1 ? new List<string> { zahl } :
           zahl.Select((e, i) => GenerierePermutationen(zahl.Substring(0, i) + zahl.Substring(i + 1))
               .Select(s => e + s))
               .SelectMany(x => x).Distinct();
}

 static (int richtig, int falsch) BerechneHinweis(string zuErrateneZahl, string zahlString)
{
    var richtigPositioniert = 0;
    var falschPositioniert = 0;

    for (int i = 0; i < zuErrateneZahl.Length; i++)
    {
        if (zuErrateneZahl[i] == zahlString[i])
        {
            richtigPositioniert++;
        }
        else if (zuErrateneZahl.Contains(zahlString[i]) && zahlString.Count(c => c == zahlString[i]) < zuErrateneZahl.Count(c => c == zahlString[i]))
        {
            falschPositioniert++;
        }
    }

    return (richtigPositioniert, falschPositioniert);
}

 static List<string> FilterMöglicheZahlen(List<string> möglicheZahlen, (int richtig, int falsch) hinweis, string hinweisZahl)
{
    return möglicheZahlen.Where(zahl =>
    {
        var prüfHinweis = BerechneHinweis(hinweisZahl, zahl);
        return prüfHinweis.richtig == hinweis.richtig && prüfHinweis.falsch == hinweis.falsch;
    }).ToList();
}