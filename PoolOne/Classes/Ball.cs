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

        public Ball(float _x, float _y, float _radius, Color _colour)
        {
            velocity = new Vector2d(0, 0);
            position = new Vector2d(_x, _y);
            radius = _radius;
            colour = _colour;
            inPocket = false;
        }

        public Boolean Colliding(Ball ball)
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

        public void ResolveCollision(Ball ball)
        {

            // get the mtd
            Vector2d delta = (position.subtract(ball.position));
            float r = radius + ball.radius;
            float dist2 = delta.dot(delta);

            if (dist2 > r * r)
            { return; }// they aren't colliding


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
            Vector2d v = (velocity.subtract(ball.velocity));
            float vn = v.dot(mtd.normalize());

            // sphere intersecting but moving away from each other already
            if (vn > 0.0f) return;

            // collision impulse
            float i = -(1.0f + 0.85f) * vn / 2;
            Vector2d impulse = mtd.multiply(i);

            // change in momentum
            velocity = this.velocity.add(impulse.multiply(1));
            ball.velocity = ball.velocity.subtract(impulse.multiply(1));
        }

        public void SidesCollsion(GameScreen UC)
        {
            if (position.x <= 30)
            {
                velocity.x = Math.Abs(velocity.x);
            }
            // Collision with right wall
            if (position.x >= (UC.Width - radius * 2 - 30))
            {
                velocity.x = Math.Abs(velocity.x) * -1;
            }
            // Collision with top wall
            if (position.y <= 32)
            {
                velocity.y = Math.Abs(velocity.y);
            }
            if (position.y >= (UC.Height - radius * 2 - 30))
            {
                velocity.y = Math.Abs(velocity.y) * -1;
            }
        }
    }
}
