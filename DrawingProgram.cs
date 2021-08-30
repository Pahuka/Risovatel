using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    class Painter
    {
        private static float x, y;
        private static Graphics grafic;

        public static void MakeGrafic(Graphics newGrafic)
        {
            grafic = newGrafic;
            grafic.SmoothingMode = SmoothingMode.None;
            grafic.Clear(Color.Black);
        }

        public static void SetPosition(float x0, float y0)
        {
            x = x0;
            y = y0;
        }

        public static void DrawLine(Pen pen, double length, double angle)
        {
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            grafic.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void ChangeCoordinates(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle));
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, double angleTurn, Graphics newGrafic)
        {
            Painter.MakeGrafic(newGrafic);

            var size = Math.Min(width, height);
            var angleStep = new List<double>(){0, - Math.PI / 2, Math.PI, Math.PI / 2 };
            var diagonalLength = Math.Sqrt(2) * (size * 0.375f + size * 0.04f) / 2;
            var x0 = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Painter.SetPosition(x0, y0);

            foreach (var angle in angleStep)
            {
                Painter.DrawLine(Pens.Yellow, size * 0.375f, angle);
                Painter.DrawLine(Pens.Yellow, size * 0.04f * Math.Sqrt(2), angle + Math.PI / 4);
                Painter.DrawLine(Pens.Yellow, size * 0.375f, angle + Math.PI);
                Painter.DrawLine(Pens.Yellow, size * 0.375f - size * 0.04f, angle + Math.PI / 2);

                Painter.ChangeCoordinates(size * 0.04f, angle - Math.PI);
                Painter.ChangeCoordinates(size * 0.04f * Math.Sqrt(2), angle + 3 * Math.PI / 4);
            }
        }
    }
}