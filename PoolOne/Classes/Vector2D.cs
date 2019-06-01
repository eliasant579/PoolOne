using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolOne
{
    class Vector2d
    {
        public float x;
        public float y;

        public Vector2d()
        {

        }

        public Vector2d(float _x, float _y)
        {
            x = _x;
            y = _y;
        }

        public float dot(Vector2d v2)
        {
            float result = 0.0f;
            result = x * v2.x + x * v2.y;
            return result;
        }

        public float getLength()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public float getDistance(Vector2d v2)
        {
            return (float)Math.Sqrt((v2.x - x) * (v2.x - x) + (v2.y - y) * (v2.y - y));
        }


        public Vector2d add(Vector2d v2)
        {
            Vector2d result = new Vector2d();
            result.x = (x + v2.x);
            result.y = (y + v2.y);
            return result;
        }

        public Vector2d subtract(Vector2d v2)
        {
            Vector2d result = new Vector2d();
            result.x = (x - v2.x);
            result.y = (y - v2.y);
            return result;
        }

        public Vector2d multiply(float scaleFactor)
        {
            Vector2d result = new Vector2d();
            result.x = (x * scaleFactor);
            result.y = (y * scaleFactor);
            return result;
        }

        public Vector2d normalize()
        {
            float len = getLength();
            if (len != 0.0f)
            {
                x = (x / len);
                y = (y / len);
            }
            else
            {
                x = (0.0f);
                y = (0.0f);
            }

            return this;
        }

        /*
        public String toString()
        {
            return "X: " + x + " Y: " + y;
        }
        //*/
    }
}
