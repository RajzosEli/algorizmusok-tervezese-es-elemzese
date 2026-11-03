using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lancolt_lista
{
    //4. feladatrész
    internal class TombosSor
    {
        public int[] A;
        public int fej;
        public int vege;
        public int meret;

        public TombosSor(int meret)
        {
            if (meret < 2)
            {
                throw new Exception("A mérete 2-nél kisebb!");
            }

            this.meret = meret;
            A = new int[meret + 1];
            fej = 1;
            vege = 1;
        }

        public int KovetkezoIndex(int i)
        {
            if (i != meret)
            {
                return i + 1;
            }
            return 1;
        }
        public bool UresSor()
        {
            if (fej == vege)
            {
                return true;
            }
            return false;
        }

        public bool MegteltSor()
        {
            if ((fej == 1 && vege == meret) || (vege + 1 == fej))
            {
                return true;
            }
            return false;
        }

        public string Sorba(int ertek)
        {
            if(MegteltSor())
            {
                return "Tele sor";
            }
            A[vege] = ertek;
            vege = KovetkezoIndex(vege);
            return "Sikeres beszúrás";
        }

        public (int? Ertek, string Hibajelzes) Sorbol()
        {
            if (UresSor())
            {
                return (null, "Üres sor");
            }

            int aktualis = A[fej];
            fej = KovetkezoIndex(fej);

            return (aktualis,"Sikeres eltávolítás");

        }

        public int[] SorTartalma()
        {
            int aktualis = fej;
            List<int> ertekek = new();

            while (aktualis != vege)
            {
                ertekek.Add(A[aktualis]);
                aktualis = KovetkezoIndex(aktualis);
            }

           return ertekek.ToArray();
        }
    }
}
