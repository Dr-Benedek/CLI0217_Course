    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Course;

    internal class Hallgatok
    {
    public string Nev { get; set; }
    public string Nem { get; set; }
    public int Befizetes { get; set; }
    public List<int> Eredmeneyek { get; set; }

    public Hallgatok(string sor)
    {
        var h = sor.Split(';');
        Nev = h[0];
        Nem = h[1];
        Befizetes = int.Parse(h[2]);
        Eredmeneyek = new List<int>();
        for (int i = 3; i < 7; i++)
        {
            Eredmeneyek.Add(int.Parse(h[i]));
        }
    }
}