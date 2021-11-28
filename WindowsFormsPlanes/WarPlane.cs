using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsPlanes
{
    class WarPlane : Vehicle
    {
        /// <summary>
        /// Ширина отрисовки военного самолета
        /// </summary>
        protected readonly int planeWidth = 160;

        /// <summary>
        /// Высота отрисовки военного самолета
        /// </summary>
        protected readonly int planeHeight = 150;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес</param>
        /// <param name="mainColor">Основной цвет</param>
  
        public WarPlane(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;

        }

        /// <summary>
        /// Конструкторс изменением размеров машины
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес</param>
        /// <param name="mainColor">Основной цвет</param>
        /// <param name="planeWidth">Ширина отрисовки транспорта</param>
        /// <param name="planeHeight">Высота отрисовки транспорта</param>
        protected WarPlane(int maxSpeed, float weight, Color mainColor, int planeWidth, int planeHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            this.planeWidth = planeWidth;
            this.planeHeight = planeHeight;
        }

        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                //вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - planeWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - planeHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);

            //отрисуем бомбы
            g.DrawEllipse(pen, _startPosX + 38, _startPosY + 76, 40, 10);
            g.DrawEllipse(pen, _startPosX + 38, _startPosY + 54, 40, 10);
            Brush brDarkGray = new SolidBrush(Color.DarkGray);
            g.FillEllipse(brDarkGray, _startPosX + 38, _startPosY + 76, 40, 10);
            g.FillEllipse(brDarkGray, _startPosX + 38, _startPosY + 54, 40, 10);

            //отрисуем крылья военнного самолета
            g.DrawRectangle(pen, _startPosX + 50, _startPosY, 20, 150);
            g.DrawRectangle(pen, _startPosX + 130, _startPosY + 33, 20, 75);
            Brush brGreen = new SolidBrush(Color.Green);
            g.FillRectangle(brGreen, _startPosX + 50, _startPosY, 20, 150);
            g.FillRectangle(brGreen, _startPosX + 130, _startPosY + 33, 20, 75);

            // отрисуем основу военного самолета
            // отрисуем нос
            g.DrawEllipse(pen, _startPosX - 20, _startPosY + 60, 50, 20);
            Brush br = new SolidBrush(MainColor);
            g.FillEllipse(br, _startPosX - 20, _startPosY + 60, 50, 20);

            // отрисуем основание военного самолета
            g.DrawRectangle(pen, _startPosX, _startPosY + 60, 150, 20);
            Brush br1 = new SolidBrush(MainColor);
            g.FillRectangle(br1, _startPosX, _startPosY + 60, 150, 20);
        }
    }
}





