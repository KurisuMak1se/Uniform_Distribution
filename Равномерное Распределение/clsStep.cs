using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Равномерное_Распределение
{
    class clsStep
    {
        public static IList<clsStep> MyCol = new List<clsStep>();
        // MyCol - Коллекция шагов
        public bool[] SeriaL;
        // SerialL - Количество серий и определение из них больших
        public clsElements[] ElOfMark;
        // ElOfMark - Элементы шага
        public int SmallSeria;
        // SmallSeria - Маленькая серия(количество элементов между маркированными элементами)
        public static int[,] EvklidAlgoritm;
        //EvklidAlgoritm - матрица всех шагов алгоритма Евклида
        //В i шаге алгоритма Евклида EvklidAlgoritm[i][0] - общее число элементов, EvklidAlgoritm[i][2] - число маркированных элементов, EvklidAlgoritm[i][1] - промежуток между маркированными элементами 
        //EvklidAlgoritm[i][3] - количество больших серий(большие серии = промежуток EvklidAlgoritm[i][2] + 1)
        /// <summary>
        /// Инициализация шага(Количество элементов в шаге / Маленькая серия / Количество серий)
        /// </summary>
        /// <param name="index"></param>
        public clsStep(int index)
        {
            int NumLargeSeria = EvklidAlgoritm[index, 3];
            ElOfMark = new clsElements[EvklidAlgoritm[index ,0]];
            SmallSeria = EvklidAlgoritm[index, 1];
            SeriaL = new bool[EvklidAlgoritm[index, 2]];
            for(int i = 0; i < SeriaL.Length; i++)
            {
                if (EvklidAlgoritm[index, 3] != 0)
                {
                    SeriaL[i] = true;
                    EvklidAlgoritm[index, 3] -= 1;
                }
                else
                {
                    SeriaL[i] = false;
                }
            }
            EvklidAlgoritm[index, 3] = NumLargeSeria;
        }
        /// <summary>
        /// Сортировка коллекции шагов
        /// </summary>
        /// <returns></returns>
        public static IList<clsStep> SortElements()
        {
            IList<clsStep> NewCol = new List<clsStep>();
            int AdditionalIndex;
            for (int i = 0; i < MyCol.Count; i++)
            {
                if (i == MyCol.Count - 1)
                {
                    NewCol.Add(MyCol[i]);
                }
                else
                {
                    NewCol.Add(new clsStep(i));
                }
            }
            NewCol.Add(AdditionalStep());
            for (int i = 0; i < (NewCol.Count == 1 ? 1 : NewCol.Count - 1); i++)
            {
                AdditionalIndex = 0;
                for(int j = 0; j < NewCol[NewCol.Count - 1 - i].ElOfMark.Length; j++)
                {
                    if (NewCol[NewCol.Count - 1 - i].ElOfMark[j].Marking)
                    {
                        NewCol[NewCol.Count - 2 - i].SeriaL[j] = true;
                        for(int k = 0; k < NewCol[NewCol.Count - 2 - i].SmallSeria + 1; k++)
                        {
                            NewCol[NewCol.Count - 2 - i].ElOfMark[k + AdditionalIndex] = new clsElements(MyCol[NewCol.Count - 2 - i].ElOfMark[k + AdditionalIndex].CrdX,
                                                                                                MyCol[NewCol.Count - 2 - i].ElOfMark[k + AdditionalIndex].CrdY);
                            if (k == 0)
                            {
                                NewCol[NewCol.Count - 2 - i].ElOfMark[k + AdditionalIndex].Marking = true;
                            }
                        }
                        AdditionalIndex += NewCol[NewCol.Count - 2 - i].SmallSeria + 1;
                    }
                    else
                    {
                        NewCol[NewCol.Count - 2 - i].SeriaL[j] = false;
                        for (int k = 0; k < NewCol[NewCol.Count - 2 - i].SmallSeria; k++)
                        {
                            NewCol[NewCol.Count - 2 - i].ElOfMark[k + AdditionalIndex] = new clsElements(MyCol[NewCol.Count - 2 - i].ElOfMark[k + AdditionalIndex].CrdX,
                                                                                                MyCol[NewCol.Count - 2 - i].ElOfMark[k + AdditionalIndex].CrdY);
                            if (k == 0)
                            {
                                NewCol[NewCol.Count - 2 - i].ElOfMark[k + AdditionalIndex].Marking = true;
                            }
                        }
                        AdditionalIndex += NewCol[NewCol.Count - 2 - i].SmallSeria;
                    }
                }
            }
            if (MyCol.Count == 1)
            {
                NewCol.RemoveAt(1);
            }
            return NewCol;
        }
        /// <summary>
        /// Дополнительный шаг для сортировки
        /// </summary>
        /// <returns></returns>
        private static clsStep AdditionalStep()
        {
            clsStep AdditionalStep = new clsStep(0);
            AdditionalStep.ElOfMark = new clsElements[EvklidAlgoritm[EvklidAlgoritm.GetLength(0) - 1, 0] / 
                                                   EvklidAlgoritm[EvklidAlgoritm.GetLength(0) - 1, 1]];
            for(int i = 0; i < AdditionalStep.ElOfMark.Length; i++)
            {
                AdditionalStep.ElOfMark[i] = new clsElements(0, 0);
            }
            return AdditionalStep;
        }
        /// <summary>
        /// Инициализация матрицы Алгоритма Евклида
        /// </summary>
        /// <param name="AlgOneStep"></param>
        public static void AlgoritmEvklid(int[] AlgOneStep)
        {
            int NumberRows = 1;
            int[] StartMas = new int[4];
            bool AlgLog;
            EvklidAlgoritm = new int[1, 4];
            if (AlgOneStep[0] / 2 < AlgOneStep[2])
            {
                AlgOneStep[2]--;
            }
            if (AlgOneStep[2] != 0)
            {
                Math.DivRem(AlgOneStep[0], AlgOneStep[2], out AlgOneStep[3]);
                AlgOneStep[1] = (AlgOneStep[0] - AlgOneStep[3]) / AlgOneStep[2];
            }
            for (int i = 0; i < StartMas.Length; i++)
            {
                StartMas[i] = AlgOneStep[i];
            }
            do
            {
                AlgLog = false;
                EvklidAlgoritm = NewSizeArr(EvklidAlgoritm, NumberRows);
                for (int i = 0; i < EvklidAlgoritm.GetLength(1); i++)
                {
                    clsStep.EvklidAlgoritm[NumberRows - 1, i] = AlgOneStep[i];
                }
                NumberRows++;
                AlgOneStep[0] = AlgOneStep[2];
                AlgOneStep[2] = AlgOneStep[3];
                if (AlgOneStep[2] != 0)
                {
                    Math.DivRem(AlgOneStep[0], AlgOneStep[2], out AlgOneStep[3]);
                    AlgOneStep[1] = (AlgOneStep[0] - AlgOneStep[3]) / AlgOneStep[2];
                    AlgLog = true;
                }
            }
            while (AlgLog);
            for (int i = 0; i < AlgOneStep.Length; i++)
            {
                AlgOneStep[i] = StartMas[i];
            }
        }
        /// <summary>
        /// Увелечение строк матрицы
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="NewLength"></param>
        /// <returns></returns>
        private static int[,] NewSizeArr(int[,] arr, int NewLength)
        {
            int[,] NewArr = new int[NewLength, 4];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    NewArr[i, j] = arr[i, j];
                }
            }
            return NewArr;
        }
    }
}