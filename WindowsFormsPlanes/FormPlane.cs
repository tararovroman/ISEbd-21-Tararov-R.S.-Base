using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsPlanes
{
    public partial class FormPlane : Form
    {
        private ITransport plane;
        /// <summary>
        /// Конструктор
        /// </summary>
        public FormPlane()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод отрисовки истребителя
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxPlanes.Width, pictureBoxPlanes.Height);
            Graphics gr = Graphics.FromImage(bmp);
            plane.DrawTransport(gr);
            pictureBoxPlanes.Image = bmp;
        }

        /// <summary>
        /// Обработка нажатия кнопки "Создать военный самолет"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateWarPlane_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            plane = new WarPlane(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.DarkGreen);
            plane.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxPlanes.Width, pictureBoxPlanes.Height);
            Draw();
        }

        /// <summary>
        /// Обработка нажатия кнопки "Создать истребитель"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateIstrebitel_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            plane = new Istrebitel(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Gray, Color.DarkGray, true, true, true);
            plane.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxPlanes.Width, pictureBoxPlanes.Height);
            Draw();
        }

        /// <summary>
        /// Обработка нажатия кнопок управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    plane.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    plane.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    plane.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    plane.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
