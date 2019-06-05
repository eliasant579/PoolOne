using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolOne
{
    class Pocket
    {
        public PointF position;
        public float radius;

        public Pocket()
        {

        }

        public Pocket (float _x, float _y, float _radius)
        {
            position = new PointF(_x, _y);
            radius = _radius;
        }

        public Boolean PocketCollsion(PointF centre)
        {
            RectangleF centreRectangle = new RectangleF(centre.X - 7.5f, centre.Y - 7.5f, 15, 15);
            RectangleF pocketRectangle = new RectangleF(position.X, position.Y, radius * 2, radius * 2);

            if(pocketRectangle.IntersectsWith(centreRectangle))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
