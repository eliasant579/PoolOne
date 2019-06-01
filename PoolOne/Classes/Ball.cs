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
        #region My old ball class
        /*
        public PointF position;
        public float x, y, xSpeed, ySpeed;
        public int size;
        public Color colour;
        public bool solidTrue, inPocket;

        public Ball(float _x, float _y, float _xSpeed, float _ySpeed, int _ballSize, Color _colour, string _stripesOrSolid)
        {
            position = new Point(_x, _y);
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            size = _ballSize;
            colour = _colour;

            if(_stripesOrSolid == "solid")
            {
                solidTrue = true;
            }
            else
            {
                solidTrue = false;
            }

            inPocket = false;
        }

        public Ball()
        {
            //empty method
        }
        //*/
        #endregion

        public Color colour;
        public Vector2d velocity;
        public Vector2d position;
        public float radius;
        public Boolean inPocket;
        //public float angularVel;
        //public float orientation = 45f;

        public Ball()
        {

        }

        /*
        public Ball(float _x, float _y, float _radius, Color _colour)
        {
            this.velocity = new Vector2d(0, 0);
            this.position = new Vector2d(_x, _y);
            radius = _radius;
            colour = _colour;
            inPocket = false;
        }
        //*/

        public Boolean colliding(Ball ball)
        {
            float xd = position.x - ball.position.x;
            float yd = position.y - ball.position.y;

            float sumRadius = radius + ball.radius;
            float sqrRadius = sumRadius * sumRadius;

            float distSqr = (xd * xd) + (yd * yd);

            if (distSqr <= sqrRadius)
            {
                return true;
            }

            return false;

        }

        public void resolveCollision(Ball ball)
        {

            // get the mtd
            Vector2d delta = (position.subtract(ball.position));
            float r = radius + ball.radius;
            float dist2 = delta.dot(delta);

            if (dist2 > r * r) return; // they aren't colliding


            float d = delta.getLength();

            Vector2d mtd;
            if (d != 0.0f)
            {
                mtd = delta.multiply(((radius + ball.radius) - d) / d); // minimum translation distance to push balls apart after intersecting

            }
            else // Special case. Balls are exactly on top of eachother.  Don't want to divide by zero.
            {
                d = ball.radius + radius - 1.0f;
                delta = new Vector2d(ball.radius + radius, 0.0f);

                mtd = delta.multiply(((radius + ball.radius) - d) / d);
            }

            // impact speed
            Vector2d v = (this.velocity.subtract(ball.velocity));
            float vn = v.dot(mtd.normalize());

            // sphere intersecting but moving away from each other already
            if (vn > 0.0f) return;

            // collision impulse
            float i = -(1.0f + 0.85f) * vn / 2;
            Vector2d impulse = mtd.multiply(i);
        }

        /*
        public int compareTo(Ball ball)
        {
            if (this.position.getX() - this.radius > ball.position.getX() - ball.radius)
            {
                return 1;
            }
            else if (this.position.getX() - this.radius < ball.position.getX() - ball.radius)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        //*/
    }
}
