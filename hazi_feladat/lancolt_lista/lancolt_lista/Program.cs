using System.Globalization;

namespace lancolt_lista
{
    internal class Program
    {
        //1. és 2. feladatrész
        public struct TombElem
        {
            public int Elo;
            public int Kulcs;
            public int Kov;

            public TombElem(int elo, int kulcs, int kov)
            {
                elo = 0;
                Kulcs = kulcs;
                kov = 0;
            }
        }

        public class TombLista
        {
            public TombElem[] A = new TombElem[11];
            public int Fej;

            public TombLista()
            {
                Fej = 0;
            }

            public void Kiir()
            {
                int aktualis = Fej;
                while (aktualis != 0)
                {
                    Console.Write($"{A[aktualis].Kulcs}, ");
                    aktualis = A[aktualis].Kov;
                }
            }

            public int Elemszam()
            {
                int db = 0;
                int aktualis = Fej;

                while (aktualis != 0)
                {
                    db++;
                    aktualis = A[aktualis].Kov;
                }

                return db;
            }

            public int Keres(int keresett)
            {
                int aktualis = Fej;

                while (aktualis != 0 && A[aktualis].Kulcs != keresett)
                {
                    aktualis = A[aktualis].Kov;
                }

                return aktualis;
            }

            public void BeszurElejere(int hely, int kulcs)
            {

                A[hely].Kov = Fej;
                A[hely].Kulcs = kulcs;
                A[hely].Elo = 0;

                if (Fej != 0)
                {
                    A[Fej].Elo = hely;
                }

                Fej = hely;
            }

            public void BeszurVegere(int hely, int kulcs)
            {
                int aktualis = Fej;

                if (Fej == 0)
                {
                    A[hely].Kulcs = kulcs;
                    A[hely].Elo = 0;
                    A[hely].Kov = 0;
                    Fej = hely;
                    return;
                }

                while (A[aktualis].Kov != 0)
                {
                    aktualis = A[aktualis].Kov;

                }
                A[hely].Elo = aktualis;
                A[hely].Kov = 0;
                A[aktualis].Kov = hely;
                A[hely].Kulcs = kulcs;
            }

            public void BeszurUtan(int elozo, int hely, int kulcs)
            {

                if (Fej == 0)
                {
                    A[hely].Kulcs = kulcs;
                    A[hely].Elo = 0;
                    A[hely].Kov = 0;
                    Fej = hely;
                    return;
                }

                int kovetkezo = A[elozo].Kov;


                A[elozo].Kov = hely;
                A[hely].Kov = kovetkezo;
                A[hely].Kulcs = kulcs;
                A[hely].Elo = elozo;

                if (kovetkezo != 0)
                {
                    A[kovetkezo].Elo = hely;
                }
            }

            public void TorolKozepso(int hely)
            {
                int elozo = A[hely].Elo;
                int kovetkezo = A[hely].Kov;

                A[elozo].Kov = A[hely].Kov;
                A[kovetkezo].Elo = A[hely].Elo;
            }

            public void TorolElso()
            {
                int kovetkezoFej = A[Fej].Kov;

                Fej = kovetkezoFej;

                A[kovetkezoFej].Elo = 0;
            }

            public void TorolUtolso()
            {
                int aktualis = Fej;

                int utolso;
                while (A[aktualis].Kov != 0)
                {
                    aktualis = A[aktualis].Kov;
                }

                utolso = aktualis;
                int utolsoelotti = A[utolso].Elo;
                

                if (utolso == Fej)
                {
                    Fej = 0;
                }

                else
                {
                    A[utolsoelotti].Kov = 0;
                    A[utolso].Elo = 0;
                }
            }

            public bool TorolKulcs(int kulcs)
            {
                int aktualis = Keres(kulcs);
                if (aktualis == 0)
                {
                    return false;
                }

                if (aktualis == Fej)
                {
                    TorolElso();
                }
                else if (A[aktualis].Kov == 0)
                {
                    TorolUtolso();
                }
                else
                {
                    TorolKozepso(aktualis);
                }

                return true;
            }
            //---------------------------------------------------
        }
        static void Main(string[] args)
        {
            //1., 2. rész: TombosLista
            Console.WriteLine("--- 1,2. rész: TombosLista tesztek ---");
            TombLista uresLista = new TombLista();
            Console.WriteLine($"Üres lista Fej: {uresLista.Fej} (Elvárt: 0)");
            Console.WriteLine($"Üres lista Elemszám: {uresLista.Elemszam()} (Elvárt: 0)");
            Console.WriteLine($"Keres(500) üres listában: {uresLista.Keres(500)} (Elvárt: 0)");

            TombLista egyelemvLista = new TombLista();
            egyelemvLista.A[4] = new TombElem { Elo = 0, Kulcs = 500, Kov = 0 };
            egyelemvLista.Fej = 4;
            Console.WriteLine($"Egyelemű lista Elemszám: {egyelemvLista.Elemszam()} (Elvárt: 1)");
            Console.WriteLine($"Keres(500): {egyelemvLista.Keres(500)} (Elvárt: 4)");
            Console.WriteLine($"Keres(999): {egyelemvLista.Keres(999)} (Elvárt: 0)");

            //Teljes körű művelet- és ágteszt
            TombLista tesztLista = new TombLista();
            tesztLista.BeszurElejere(1, 10); //Lista: 10
            tesztLista.BeszurVegere(2, 30);  //Lista: 10 -> 30
            tesztLista.BeszurUtan(1, 3, 20);  //Lista: 10 -> 20 -> 30
            Console.Write("Beszúrások után (10, 20, 30): ");
            tesztLista.Kiir();
            Console.WriteLine($"\nElemek száma: {tesztLista.Elemszam()} (Elvárt: 3)");

            //Középső elem törlése (20-as, 3-as helyen)
            tesztLista.TorolKozepso(3);
            Console.Write("Középső elem (20) törlése után (10, 30): ");
            tesztLista.Kiir();
            Console.WriteLine();

            //Első elem törlése
            tesztLista.BeszurElejere(4, 5); //Lista: 5 -> 10 -> 30
            tesztLista.TorolElso();
            Console.Write("Első elem (5) törlése után (10, 30): ");
            tesztLista.Kiir();
            Console.WriteLine();

            //Utolsó elem törlése
            tesztLista.TorolUtolso();
            Console.Write("Utolsó elem (30) törlése után (10): ");
            tesztLista.Kiir();
            Console.WriteLine();

            //TorolKulcs tesztek (létező és nem létező kulcs)
            bool toroltE = tesztLista.TorolKulcs(10);
            Console.WriteLine($"TorolKulcs(10) sikeres: {toroltE} (Elvárt: True)");
            Console.WriteLine($"Elemek száma kiürítés után: {tesztLista.Elemszam()} (Elvárt: 0)");

            bool nemTorolt = tesztLista.TorolKulcs(999);
            Console.WriteLine($"TorolKulcs(999) nem létező kulcsra: {nemTorolt} (Elvárt: False)\n");









            //3. rész: TombosVerem, SzabadTarolo
            Console.WriteLine("--- 3. rész: TombosVerem tesztek ---");
            TombosVerem verem = new TombosVerem(3);
            Console.WriteLine($"UresVerem: {verem.UresVerem()} (Elvárt: True)");
            Console.WriteLine($"Verembe(10): {verem.Verembe(10)}");
            Console.WriteLine($"Verembe(20): {verem.Verembe(20)}");
            Console.WriteLine($"Verembe(30): {verem.Verembe(30)}");
            Console.WriteLine($"Verembe(40) túlcsordulás: {verem.Verembe(40)} (Elvárt: Túlcsordulás)");
            Console.WriteLine($"VeremMegtelt: {verem.VeremMegtelt()} (Elvárt: True)");
            var (v1, h1) = verem.Verembol();
            Console.WriteLine($"Verembol(): {v1}, {h1} (Elvárt: 30, Rendben)");
            var (v2, h2) = verem.Verembol();
            Console.WriteLine($"Verembol(): {v2}, {h2} (Elvárt: 20, Rendben)\n");

            Console.WriteLine("--- 3. rész: SzabadTarolo tesztek ---");
            SzabadTarolo tarolo = new SzabadTarolo(6);
            int l1 = tarolo.ObjektumotLefoglal();
            int l2 = tarolo.ObjektumotLefoglal();
            Console.WriteLine($"Első két lefoglalás: {l1}, {l2} (Elvárt: 1, 2)");
            tarolo.ObjektumotFelszabadit(1);
            tarolo.ObjektumotFelszabadit(2);
            int l3 = tarolo.ObjektumotLefoglal();
            int l4 = tarolo.ObjektumotLefoglal();
            Console.WriteLine($"Felszabadítás utáni lefoglalások: {l3}, {l4} (Elvárt: 2, 1)");

            SzabadTarolo tarolo2 = new SzabadTarolo(3);
            tarolo2.ObjektumotLefoglal();
            tarolo2.ObjektumotLefoglal();
            tarolo2.ObjektumotLefoglal();
            int nullazott = tarolo2.ObjektumotLefoglal();
            Console.WriteLine($"Összes hely lefoglalása után: {nullazott} (Elvárt: 0)");
            tarolo2.ObjektumotFelszabadit(2);
            int ujra = tarolo2.ObjektumotLefoglal();
            Console.WriteLine($"Felszabadított 2-es hely újbóli lefoglalása: {ujra} (Elvárt: 2)\n");







            //4. rész: TombosSor
            Console.WriteLine("--- 4. rész: TombosSor tesztek ---");
            TombosSor sor = new TombosSor(3); // legfeljebb 2 elem tárolható
            Console.WriteLine($"UresSor: {sor.UresSor()} (Elvárt: True)");
            Console.WriteLine($"Sorba(100): {sor.Sorba(100)}");
            Console.WriteLine($"Sorba(200): {sor.Sorba(200)}");
            Console.WriteLine($"Sorba(300) tele sor: {sor.Sorba(300)} (Elvárt: Tele sor)");
            Console.WriteLine($"SorMegtelt: {sor.MegteltSor()} (Elvárt: True)");

            int[] tartalom = sor.SorTartalma();
            Console.Write("SorTartalma: ");
            for (int i = 0; i < tartalom.Length; i++)
            {
                Console.Write(tartalom[i]);
                if (i < tartalom.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(" (Elvárt: 100, 200)");

            var (s1, sh1) = sor.Sorbol();
            Console.WriteLine($"Sorbol(): {s1}, {sh1} (Elvárt: 100, Sikeres eltávolítás)");
            var (s2, sh2) = sor.Sorbol();
            Console.WriteLine($"Sorbol(): {s2}, {sh2} (Elvárt: 200, Sikeres eltávolítás)");
            Console.WriteLine($"UresSor kiürülés után: {sor.UresSor()} (Elvárt: True)\n");

            //5. Rekurzió alapok
            Console.WriteLine("--- 5. Rész: Rekurzio (Alap) tesztek ---");
            Console.WriteLine($"Summa(5): {Rekurzio.Summa(5)} (Elvárt: 15)");
            Console.WriteLine($"RekSumma(5): {Rekurzio.RekSumma(5)} (Elvárt: 15)");
            Console.WriteLine($"RekSummaIntervallum(2, 5): {Rekurzio.RekSummaIntervallum(2, 5)} (Elvárt: 14)");
            Console.WriteLine($"Euklidesz(48, 18): {Rekurzio.Euklidesz(48, 18)} (Elvárt: 6)");
            Console.WriteLine($"Euklidesz(0, 0): {Rekurzio.Euklidesz(0, 0)} (Elvárt: 0)\n");

            //6. rész Rekurzió folytat
            Console.WriteLine("--- 6. Rész: Rekurzio (Haladó) tesztek ---");
            Console.WriteLine($"RekSum(1, 5): {Rekurzio.RekSum(1, 5)} (Elvárt: 15)");
            Console.WriteLine($"Fibonacci(10): {Rekurzio.Fibonacci(10)} (Elvárt: 55)");

            int[] uresTomb = new int[0];
            Console.WriteLine($"BinKerTomb üres tömbön: {Rekurzio.BinKerTomb(uresTomb, -1, 0, 5)} (Elvárt: -1)");

            int[] egyElemTomb = new int[] { 42 };
            Console.WriteLine($"BinKerTomb egyelemű találat (42): {Rekurzio.BinKerTomb(egyElemTomb, -1, 1, 42)} (Elvárt: 0)");
            Console.WriteLine($"BinKerTomb egyelemű sikertelen (99): {Rekurzio.BinKerTomb(egyElemTomb, -1, 1, 99)} (Elvárt: -1)");

            int[] rendezettTomb = new int[] { 10, 20, 30, 40, 50 };
            int[] eredetiMasolat = (int[])rendezettTomb.Clone();
            Console.WriteLine($"BinKerTomb rendezett találat (30): {Rekurzio.BinKerTomb(rendezettTomb, -1, rendezettTomb.Length, 30)} (Elvárt: 2)");
            Console.WriteLine($"BinKerTomb rendezett sikertelen (25): {Rekurzio.BinKerTomb(rendezettTomb, -1, rendezettTomb.Length, 25)} (Elvárt: -1)");
            
            bool valtozatlan = true;
            if (rendezettTomb.Length != eredetiMasolat.Length)
            {
                valtozatlan = false;
            }
            else
            {
                for (int i = 0; i < rendezettTomb.Length; i++)
                {
                    if (rendezettTomb[i] != eredetiMasolat[i])
                    {
                        valtozatlan = false;
                        break;
                    }
                }
            }

            Console.WriteLine($"Tömb tartalma változatlan maradt: {valtozatlan} (Elvárt: True)");


        }
    }
}
