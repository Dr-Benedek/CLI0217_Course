using Course;
using System.IO;
using System.Text;
List<Hallgatok> hallgatok = [];

using StreamReader sr = new($"..\\..\\..\\resource\\course.txt", Encoding.UTF8);
string fejlec = sr.ReadLine();
while (!sr.EndOfStream)
{
    hallgatok.Add(new(sr.ReadLine()));
}
Console.WriteLine($"1. feladat: adatsorok száma: {hallgatok.Count}");

double f2 = hallgatok.Average(h => h.Eredmeneyek[0]);
Console.WriteLine($"2. feladat: Backend fejlesztés átlag: {f2:0.00}");

var f3 = hallgatok.OrderByDescending(h => h.Eredmeneyek.Sum()).First();
Console.WriteLine($"3. feladat: Osztályelső: {f3.Nev} eredmények összege: {f3.Eredmeneyek.Sum()}");

double f4 = (double)hallgatok.Count(h => h.Nem == "m") / hallgatok.Count() * 100;
Console.WriteLine($"4. feladat: a férfiak aránya: {f4:0.00} %");


var f5 = hallgatok.Where(h => h.Nem == "f")
    .OrderByDescending(h => h.Eredmeneyek[0] + h.Eredmeneyek[1])
    .First();
Console.WriteLine($"5. feladat: A legjobb női webfejlesdztő: {f5.Nev}, eredménye: {f5.Eredmeneyek[0] + f5.Eredmeneyek[1]}");


Console.WriteLine($"6. feladat: Előfinanszírozták a tanfolyam árát:");
var f6 = hallgatok.Where(h => h.Befizetes >= 2600).ToList();
foreach (var s in f6)
{
    Console.WriteLine($"\t\t\t\t\t\t{s.Nev}");
}


Console.WriteLine($"7. feladat:");
Console.Write("\tAdja meg a diák nevét: ");
string sn = Console.ReadLine();
var diak = hallgatok.FirstOrDefault(h => h.Nev == sn);
static string Targynevek(int szam)
{
    var targyak = new[] { "hálozat", "mobil", "forontend", "backend" };
    return targyak[szam];
}
if (diak != null)
{
    var f7 = diak.Eredmeneyek
        .Select((s, i) => s < 51 ? Targynevek(i) : null)
        .Where(t => t != null).ToList();

    if (f7.Any())
    {
        Console.WriteLine($"\n\t{sn} -nak/-nek kell javítóvizsgát az alábbi(ak)ból: {string.Join(", ", f7)}");
    }
    else
    {
        Console.WriteLine($"\n\t{sn} -nak/-nek nem kell javítóvizsgát tennie.");
    }
}
else
{
    Console.WriteLine("\t\tNincs ilyen diák!.");
}


var f8 = hallgatok.Where(h => h.Eredmeneyek.Any(s => s == 100) && h.Eredmeneyek.All(s => s >= 51)).Count();
Console.WriteLine($"\n8. feladat: azon diákok száma, akik legalább egy modulból 100% teljesítettek: {f8}");


Console.WriteLine($"\n9. feladat: Modulonként hány tanulónak kell javítóvizsgáznia: ");
for (int i = 0; i < 4; i++)
{
    int f9 = hallgatok.Count(h => h.Eredmeneyek[i] < 51);
    Console.WriteLine($"\t {Targynevek(i)} modulból, javítók száma: {f9}");
}


var f10 = hallgatok.OrderBy(h => h.Nev.Split(' ')[1])
    .Select(h => new { h.Nev, AverageScore = h.Eredmeneyek.Average() }).ToList();
using StreamWriter w = new System.IO.StreamWriter("rendezett_hallgatok.txt");
{
    foreach (var s in f10)
    {
        w.WriteLine($"{s.Nev}; {s.AverageScore}");
    }
}