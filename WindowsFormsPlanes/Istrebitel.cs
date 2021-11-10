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
    class Istrebitel
    {
        /// <summary>
        /// Левая координата отрисовки истребителя
        /// </summary>
        private float _startPosX;

        /// <summary>
        /// Правая кооридната отрисовки истребителя
        /// </summary>
        private float _startPosY;

        /// <summary>
        /// Ширина отрисовки окна
        /// </summary>
        private int _pictureWidth;

        /// <summary>
        /// Высота отрисовки окна
        /// </summary>
        private int _pictureHeight;

        /// <summary>
        /// Ширина отрисовки истребителя
        /// </summary>
        private readonly int planeWidth = 145;

        /// <summary>
        /// Высота отрисовки истребителя
        /// </summary>
        private readonly int planeHeight = 95;

        /// <summary>
        /// Максимальная скорость 
        /// </summary>
        public int MaxSpeed { private set; get; }

        /// <summary>
        /// Вес 
        /// </summary>
        public float Weight { private set; get; }

        /// <summary>
        /// Основной цвет
        /// </summary>
        public Color MainColor { private set; get; }

        /// <summary>
        /// Дополнительный цвет
        /// </summary>
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

        public void Init(int maxSpeed, float weight, Color mainColor, Color dopColor,
            bool wings, bool rockets, bool guns)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            Wings = wings;
            Rockets = rockets;
            Guns = guns;
        }

        /// <summary>
        /// Установка позиции истребителя
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }

        /// <summary>
        /// Изменение направления пермещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
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

        /// <summary>
        /// Отрисовка истребителя
        /// </summary>
        /// <param name="g"></param>
        public void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);

            // отрисуем ракеты
            if (Rockets)
            {
                g.DrawEllipse(pen, _startPosX + 25, _startPosY + 40, 20, 8);
                g.DrawRectangle(pen, _startPosX + 35, _startPosY + 40, 40, 8);

                g.DrawEllipse(pen, _startPosX + 25, _startPosY + 100, 20, 8);
                g.DrawRectangle(pen, _startPosX + 35, _startPosY + 100, 40, 8);

                Brush brRed = new SolidBrush(Color.Red);
                g.FillEllipse(brRed, _startPosX + 25, _startPosY + 40, 20, 8);
                g.FillRectangle(brRed, _startPosX + 35, _startPosY + 40, 40, 8);

                g.FillEllipse(brRed, _startPosX + 25, _startPosY + 100, 20, 8);
                g.FillRectangle(brRed, _startPosX + 35, _startPosY + 100, 40, 8);
            }

            if (Guns)
            {
                g.DrawRectangle(pen, _startPosX + 38, _startPosY + 25, 35, 5);
                g.DrawRectangle(pen, _startPosX + 38, _startPosY + 115, 35, 5);
                Brush brBlack = new SolidBrush(Color.Black);
                g.FillRectangle(brBlack, _startPosX + 38, _startPosY + 25, 35, 5);
                g.FillRectangle(brBlack, _startPosX + 38, _startPosY + 115, 35, 5);
            }

            // отрисуем крылья истребителя
            if (Wings)
            {
                g.DrawRectangle(pen, _startPosX + 50, _startPosY, 20, 150);
                Brush brYellow = new SolidBrush(DopColor);
                g.FillRectangle(brYellow, _startPosX + 50, _startPosY, 20, 150);
            }

            // отрисуем задние крылья истребителя
            g.DrawRectangle(pen, _startPosX + 130, _startPosY + 33, 20, 75);
            Brush wings = new SolidBrush(DopColor);
            g.FillRectangle(wings, _startPosX + 130, _startPosY + 33, 20, 75);

            // отрисуем основу истребителя
            // отрисуем нос
            g.DrawEllipse(pen, _startPosX - 20, _startPosY + 60, 50, 20);
            Brush br = new SolidBrush(MainColor);
            g.FillEllipse(br, _startPosX - 20, _startPosY + 60, 50, 20);

            // отрисуем основание
            g.DrawRectangle(pen, _startPosX, _startPosY + 60, 150, 20);
            Brush br1 = new SolidBrush(MainColor);
            g.FillRectangle(br1, _startPosX, _startPosY + 60, 150, 20);
        }
    }
}
