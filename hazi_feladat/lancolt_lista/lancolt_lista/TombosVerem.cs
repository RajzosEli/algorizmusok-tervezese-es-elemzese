using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lancolt_lista
{
    public class TombosVerem
    {
        //3. feladatrész

        public int[] A;
        public int teto;
        public int meret;

        public TombosVerem(int meret)
        {
            this.meret = meret;
            this.teto = 0;
            A = new int[meret + 1];
        }

        public bool UresVerem()
        {
            if (teto == 0)
            {
                return true;
            }
            return false;
        }

        public bool VeremMegtelt()
        {
            if (meret == teto)
            {
                return true;
            }
            return false;
        }

        public string Verembe(int ertek)
        {
            if (VeremMegtelt() == true)
            {return "Túlcsordulás";
            }

            teto++;

            A[teto] = ertek;

            return "Rendben";
        }

        public (int? Ertek, string Hibajelzes) Verembol()
        {

            if (UresVerem())
            {
                return (null, "Alulcsordulás");
            }
            int aktualis = A[teto];

            teto--;
            return (aktualis, "Rendben");
        }
    }
}
