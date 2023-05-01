using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics.Graphics_package
{
    internal class Transformations2D
    {
        public Transformations2D()
        {

        }
        public polygon polygonShearX(polygon shape, int shx)
        {
            List<point> points = shape.GetPoints();
            List<point> newPoints = new List<point>();
            foreach (point p in points)
            {
                newPoints.Add(shearX(p, shx));
            }
            return new polygon(newPoints);
        }
        public polygon polygonShearY(polygon shape, int shy)
        {
            List<point> points = shape.GetPoints();
            List<point> newPoints = new List<point>();
            foreach (point p in points)
            {
                newPoints.Add(shearY(p, shy));
            }
            return new polygon(newPoints);
        }
        public polygon Rotation(polygon shape, int angle)
        {
            List <point> points = shape.GetPoints();
            List <point> newPoints = new List<point>();
            double convertAngle = Math.PI * angle / 180.0;
            int x = 0;
            int y = 0;
            for (int i = 0; i < points.Count; i++)
            {
                x = points[i].GetXPoint();
                y = points[i].GetYPoint();
                int newX = (int)(x * Math.Cos(convertAngle) - y * Math.Sin(convertAngle));
                int newY = (int)(x * Math.Sin(convertAngle) + y * Math.Cos(convertAngle));
                newPoints.Add(new point(newX, newY));
            }
            return new polygon(newPoints);
        }
        public polygon Scalling(polygon shape, int ScaleX, int ScaleY)
        {
            List<point> points = shape.GetPoints();
            List<point> newPoints = new List<point>();
            for(int i = 0; i < points.Count; i++)
            {
                newPoints.Add(new point(points[i].GetXPoint() * ScaleX, points[i].GetYPoint() * ScaleY));
            }
            return new polygon(newPoints);
        }
        public polygon Translation(polygon shape, int translateX, int translateY)
        {
            List<point> points = shape.GetPoints();
            List<point> newPoints = new List<point>();
            for (int i = 0; i < points.Count; i++)
            {
                newPoints.Add(new point(points[i].GetXPoint() + translateX, points[i].GetYPoint() + translateY));
            }
            return new polygon(newPoints);
        }
        public polygon reflectX(polygon shape)
        {
            List<point> points = shape.GetPoints();
            List<point> newPoints = new List<point>();
            for(int i = 0; i < points.Count; i++)
            {
                newPoints.Add(new point(points[i].GetXPoint() * - 1, points[i].GetYPoint()));
            }
            return new polygon(newPoints);
        }
        public polygon reflectY(polygon shape)
        {
            List<point> points = shape.GetPoints();
            List<point> newPoints = new List<point>();
            for (int i = 0; i < points.Count; i++)
            {
                newPoints.Add(new point(points[i].GetXPoint(), points[i].GetYPoint()* -1));
            }
            return new polygon(newPoints);
        }
        public polygon reflectOrigin(polygon shape)
        {
            List<point> points = shape.GetPoints();
            List<point> newPoints = new List<point>();
            for (int i = 0; i < points.Count; i++)
            {
                newPoints.Add(new point(points[i].GetXPoint() * -1, points[i].GetYPoint() * -1));
            }
            return new polygon(newPoints);
        }
        private point shearX(point p, int shX)
        {
            int x = p.GetXPoint();
            int y = p.GetYPoint();
            int newX = x + shX * y;
            point newPoint = new point(newX, y);
            return newPoint;
        }
        private point shearY(point p, int shY)
        {
            int x = p.GetXPoint();
            int y = p.GetYPoint();
            int newY = x * shY + y;
            point newPoint = new point(x, newY);
            return newPoint;
        }
    }
}
