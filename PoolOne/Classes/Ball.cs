using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PoolOne
{
    class Ball
    {
        public float x, y, xSpeed, ySpeed;
        public int size, number;
        public Color colour;
        public bool inPocket;

        public Ball(float _x, float _y, float _xSpeed, float _ySpeed, int _ballSize, int _number, Color _colour)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            size = _ballSize;
            number = _number;
            colour = _colour;
            inPocket = false;
        }

        public Ball()
        {
        }
    }
}
