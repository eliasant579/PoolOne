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
        public float mass;

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
            mass = 1f;
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

        /// <summary>
        /// I barely know what goes on here. I'm going to study it if I have time
        /// </summary>
        /// <param name="ball"></param>
        public void ResolveCollision(Ball ball)
        {
            #region OLD COLLISION FROM ONLINE SOMEWHERE
            /*
            // get the mtd
            Vector2d delta = (position.subtract(ball.position));
            float r = radius + ball.radius;
            float dist2 = delta.dot(delta);

            if (dist2 > r * r)
            {
                return;
            }// they aren't colliding

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
            float i = -(1.0f + 0.65f) * vn / 2;
            Vector2d impulse = mtd.multiply(i);

            // change in momentum
            velocity = this.velocity.add(impulse.multiply(1));
            ball.velocity = ball.velocity.subtract(impulse.multiply(1));
            //*/
            #endregion

            /*
            Vector2d sumVelocity = velocity.add(ball.velocity);

            Vector2d delta = position.subtract(ball.position);
            delta.normalize();
            Vector2d perpendicularUnitVector = delta.perpendicular();

            Vector2d vectProjSumOntoCentre = delta.multiply(sumVelocity.dot(delta));
            Vector2d vectProjSumOntoPerp = perpendicularUnitVector.multiply(sumVelocity.dot(perpendicularUnitVector));

            velocity = vectProjSumOntoCentre;
            ball.velocity = vectProjSumOntoPerp;
            */

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

            // resolve intersection
            float im1 = 1 / mass; // inverse mass quantities
            float im2 = 1 / ball.mass;

            // push-pull them apart
            position = position.add(mtd.multiply(im1 / (im1 + im2)));
            ball.position = ball.position.subtract(mtd.multiply(im2 / (im1 + im2)));

            // impact speed
            Vector2d v = (this.velocity.subtract(ball.velocity));
            float vn = v.dot(mtd.normalize());

            // sphere intersecting but moving away from each other already
            if (vn > 0.0f) return;

            // collision impulse
            float i = (-1.85f * vn) / (im1 + im2);
            Vector2d impulse = mtd.multiply(i);

            // change in momentum
            this.velocity = this.velocity.add(impulse.multiply(im1));
            ball.velocity = ball.velocity.subtract(impulse.multiply(im2));

        }

        public bool SidesCollsion(GameScreen UC)
        {
            int totalOffset = UC.getBorder() + UC.getOffset();

            if (position.x <= totalOffset)
            {
                velocity.x = Math.Abs(velocity.x);
                return true;
            }
            // Collision with right wall
            else if (position.x >= (UC.Width - radius * 2 - totalOffset))
            {
                velocity.x = Math.Abs(velocity.x) * -1;
                return true;
            }
            // Collision with top wall
            else if (position.y <= totalOffset + 2)
            {
                velocity.y = Math.Abs(velocity.y);
                return true;
            }
            else if (position.y >= (UC.Height - radius * 2 - totalOffset))
            {
                velocity.y = Math.Abs(velocity.y) * -1;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
