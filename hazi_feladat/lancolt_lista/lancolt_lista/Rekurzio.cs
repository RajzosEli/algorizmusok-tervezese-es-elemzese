using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lancolt_lista
{
    //5.részfeladat
    internal class Rekurzio
    {
        public static long Summa(int n)
        {
            long osszeg = 0;
            for (int i = 1; i <= n; i++)
            {
                osszeg += i;
            }
            return osszeg;
        }

        public static long RekSumma(int n)
        {

            if (n != 1)
            {
                return n + RekSumma(n - 1);
            }
            return 1;

        }

        public static long RekSummaIntervallum(int m, int n)
        {
            if (n != m)
            {
                return n + RekSummaIntervallum(m, n - 1);
            }
            return m;
        }

        public static int Euklidesz(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            return Euklidesz(b, a % b);

        }
        //----------------------------------------------

        //6. feladatrész

        public static long RekSum(int m, int n)
        {

            int kozep = (n + m) / 2;
            if (m == n)
            {
                return n;
            }

            long jobb = RekSum(m, kozep);

            long bal = RekSum(kozep + 1, n);

            return (bal + jobb);
        }

        public static long Fibonacci(int n)
        {
            long F_0 = 0;
            long F_1 = 1;

            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);

        }

        public static int BinKerTomb(int[] A, int i, int j, int k)
        {

            if (i + 1 >= j)
            {
                return -1;
            }

            int kozep = (i + j) / 2;



            if (A[kozep] == k)
            {
                return kozep;
            }

            if (k > A[kozep])
            {
                return BinKerTomb(A, kozep, j, k);
            }

            return BinKerTomb(A, i, kozep, k);
        }
    }
}
