using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lancolt_lista
{
    //3. feladarész
    public class SzabadTarolo
    {
        public int[] A;
        public int teto;
        public int meret;
        public SzabadTarolo(int meret)
        {
            this.meret = meret;
            this.teto = 1;
            A = new int[meret + 1];

            for (int i = 1; i < A.Length; i++)
            {
                A[i] = i + 1;
            }
            A[meret] = 0;
        }

        public int ObjektumotLefoglal()
        {
            if (teto == 0)
            {
                return 0;
            }
            int aktualis = teto;
            teto = A[teto];

            return aktualis;
        }

        public void ObjektumotFelszabadit(int hely)
        {

            A[hely] = teto;
            teto = hely;
        }
    }
}
