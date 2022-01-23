using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Равномерное_Распределение
{
    class mdlRotate
    {
        public static float[,] MtxSingle = new float[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
        public static float degSt = (float)Math.PI / 180;
        public static int W, H;
        public static float cAx, mmh, mmw;
        public static float[,] MtxStartCrd;
        public static float[,] MtxEndCrd;
        public static float[,] MtxDecCrd;
        public static int[,] MtxDisCrd;
        public static float[,] MtxTrs;
        public static float[,] mtxZ;
        public static int[] mathGeneral(float Angle)
        {
            int[] NewCrd = new int[2];
            mtxZ = new float[,] { { (float)Math.Cos(degSt * Angle), (float)Math.Sin(degSt * Angle), 0, 0 }, { (float)-Math.Sin(degSt * Angle),
                                    (float)Math.Cos(degSt * Angle), 0, 0 }, {0, 0, 1, 0 }, { 0, 0, 0, 1} };
            float[,] AdditionalMtx = new float[4, 4];
            multyplyMtx(mtxZ, MtxTrs, AdditionalMtx);
            multyplyMtx(AdditionalMtx, MtxSingle, MtxTrs);
            multyplyMtx(MtxStartCrd, MtxTrs, MtxEndCrd);
            homogToDec(MtxEndCrd, MtxDecCrd);
            calculateDisCord(MtxDisCrd, MtxDecCrd);
            NewCrd[0] = MtxDisCrd[3, 0] - (int)clsElements.Diametr / 2;
            NewCrd[1] = MtxDisCrd[3, 1] - (int)clsElements.Diametr / 2;
            return NewCrd;
        }
        static void multyplyMtx(float[,] mtx1, float[,] mtx2, float[,] mtxrez)
        {
            for (int i = 0; i < mtxrez.GetLength(0); i++)
            {
                for (int j = 0; j < mtxrez.GetLength(1); j++)
                {
                    mtxrez[i, j] = 0;
                }
            }
            if (mtx1.GetLength(1) == mtx2.GetLength(1))
            {
                for (int i = 0; i < mtx1.GetLength(0); i++)
                {
                    for (int j = 0; j < mtx2.GetLength(1); j++)
                    {
                        for (int r = 0; r < mtx1.GetLength(1); r++)
                        {
                            mtxrez[i, j] = mtxrez[i, j] + mtx1[i, r] * mtx2[r, j];
                        }
                    }
                }
            }
        }
        static void homogToDec(float[,] endCord, float[,] decCord)
        {
            // Из однородной системы координат переходим к декартовой системе координат
            // нормирование координат трансформированного объекта
            for (int i = 0; i < endCord.GetLength(0); i++)
            {
                for (int j = 0; j < endCord.GetLength(1); j++)
                {
                    if (endCord[i, 3] != 1)
                    {
                        if (endCord[i, 3] == 0)
                        {
                            endCord[i, 3] = 0.01f;
                        }
                        else
                        {
                            decCord[i, j] = endCord[i, j] / endCord[i, 3];
                        }
                    }
                    else
                    {
                        decCord[i, j] = endCord[i, j];
                    }
                }
            }
        }
        static void calculateDisCord(int[,] mDisp, float[,] mDek)
        {
            for (int i = 0; i < mDek.GetLength(0); i++)
            {
                for (int j = 0; j < mDek.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        mDisp[i, 0] = (int)(W / 2 + (mmw * mDek[i, j]));
                    }
                    if (j == 1)
                    {
                        mDisp[i, 1] = (int)(H / 2 - (mmh * mDek[i, j]));
                    }
                }
            }
        }
    }
}
