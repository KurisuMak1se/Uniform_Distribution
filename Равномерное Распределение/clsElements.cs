using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Равномерное_Распределение
{
    class clsElements
    {
        public float CrdX, CrdY;
        public static float Diametr;
        // CrdX - Координата x элемента
        // CrdY - Координата y элемента
        // Diametr - диаметр элемента
        public bool Marking;
        // Marking - Определяет, маркирован элемент или нет
        /// <summary>
        /// Инициализация элемента
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="d"></param>
        public clsElements(float x, float y)
        {
            CrdX = x;
            CrdY = y;
        }
        /// <summary>
        /// Проецирование координат на внутренние шаги
        /// </summary>
        /// <param name="Hypotenuse"></param>
        /// <param name="Angle"></param>
        public void Projection(int Hypotenuse, float Angle)
        {
            CrdX += Hypotenuse * (float)Math.Cos((90 - Angle) * Math.PI / 180);
            CrdY += Hypotenuse * (float)Math.Sin((90 - Angle) * Math.PI / 180);
        }
    }
}
