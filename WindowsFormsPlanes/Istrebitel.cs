using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsPlanes
{
    /// <summary>
    /// Класс отрисовки истребителя
    /// </summary>
    class Istrebitel : WarPlane
    {
        
        public Color DopColor { private set; get; }

        /// <summary>
        /// Признак наличия крыльев
        /// </summary>
        public bool Wings { private set; get; }

        /// <summary>
        /// Признак наличия ракет
        /// </summary>
        public bool Rockets { private set; get; }

        /// <summary>
        /// Признак наличия пушек
        /// </summary>
        public bool Guns { private set; get; }


        /// <summary>
        /// Инициализация свойств
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес</param>
        /// <param name="mainColor">Основной цвет</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="wings">Признак наличия крыльев</param>
        /// <param name="rockets">Признак наличия ракет</param>
        /// <param name="guns">Признак наличия пушек</param>

        public Istrebitel(int maxSpeed, float weight, Color mainColor, Color dopColor,
            bool wings, bool rockets, bool guns) : base (maxSpeed, weight, mainColor, 100, 60)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            Wings = wings;
            Rockets = rockets;
            Guns = guns;
        }
        
        public override void DrawTransport(Graphics g)
        {
            base.DrawTransport(g);
            Pen pen = new Pen(Color.Black, 3);

            // отрисуем ракеты
            if (Rockets)
            {
                g.DrawEllipse(pen, _startPosX + 25, _startPosY + 40, 20, 8);
                g.DrawRectangle(pen, _startPosX + 35, _startPosY + 40, 40, 8);

                g.DrawEllipse(pen, _startPosX + 25, _startPosY + 90, 20, 8);
                g.DrawRectangle(pen, _startPosX + 35, _startPosY + 90, 40, 8);

                Brush brRed = new SolidBrush(Color.Red);
                g.FillEllipse(brRed, _startPosX + 25, _startPosY + 40, 20, 8);
                g.FillRectangle(brRed, _startPosX + 35, _startPosY + 40, 40, 8);

                g.FillEllipse(brRed, _startPosX + 25, _startPosY + 90, 20, 8);
                g.FillRectangle(brRed, _startPosX + 35, _startPosY + 90, 40, 8);
            }

            if (Guns)
            {
                g.DrawRectangle(pen, _startPosX + 38, _startPosY + 25, 35, 5);
                g.DrawRectangle(pen, _startPosX + 38, _startPosY + 112, 35, 5);
                Brush brBlack = new SolidBrush(Color.Black);
                g.FillRectangle(brBlack, _startPosX + 38, _startPosY + 25, 35, 5);
                g.FillRectangle(brBlack, _startPosX + 38, _startPosY + 112, 35, 5);
            }

            // отрисуем крылья истребителя
            if (Wings)
            {
                g.DrawRectangle(pen, _startPosX + 50, _startPosY, 20, 150);
                g.DrawRectangle(pen, _startPosX + 130, _startPosY + 33, 20, 75);
                Brush wings = new SolidBrush(DopColor);
                g.FillRectangle(wings, _startPosX + 50, _startPosY, 20, 150);
                g.FillRectangle(wings, _startPosX + 130, _startPosY + 33, 20, 75);
            }
        }
    }
}
