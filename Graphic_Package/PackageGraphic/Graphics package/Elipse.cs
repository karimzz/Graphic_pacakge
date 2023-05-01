using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics.Graphics_package
{
    internal class Elipse
    {
        private point center;
        private int radiusX;
        private int radiusY;
        private int decisionParameter;


        public Elipse(point center, int radiusX, int radiusY)
        {
            this.center = center;
            this.radiusX = radiusX;
            this.radiusY = radiusY;
        }

        public Bitmap drawElipse(Bitmap p)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "save";
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sfd.FileName = "Untitled.html";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(sfd.FileName).ToLower() != ".html")
                {
                    sfd.FileName += ".html";
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("<table style = 'width : 100%;border-spacing : 0px;'>;");
            sb.Append("<tr><td colspan=\"5\" style = 'padding : 15px;background-color : #f44336;color : #fff;font-weight : bold;text-align : center;'>Region 1</td></tr>");
            sb.Append("<tr style = 'color : #fff;text-align : center;'><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>K</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>P1<sub>k</sub></td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>(X<sub>k+1</sub>,Y<sub>k+1</sub>)</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>2r<sub>y</sub><sup>2</sup>X<sub>k+1</sub></td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>2r<sub>x</sub><sup>2</sup>Y<sub>k+1</sub></td></tr>");
            int k = 0;
            int x = 0;
            int y = radiusY;
            int xCenter = center.GetXPoint();
            int yCenter = center.GetYPoint();
            int rx2 = (int)Math.Pow(radiusX, 2);
            int ry2 = (int)Math.Pow(radiusY, 2);
            decisionParameter = ry2 - rx2 * radiusY + (rx2 / 4);
            int parameterIncrementX = 2 * ry2 * x;
            int parameterIncrementY = 2 * rx2 * y;
            ElipsePoints(x, y, xCenter, yCenter, p);
            while(parameterIncrementX <= parameterIncrementY)
            {
                k++;
                sb.Append("<tr><td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "P" + "<sub>" + k + "</sub>" + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + decisionParameter + "</td>");
                x++;
                    parameterIncrementX += 2 * ry2;
                    if(decisionParameter < 0)
                    {
                        decisionParameter += (parameterIncrementX + ry2);
                    }
                    else
                    {
                        y--;
                        parameterIncrementY -= 2 * rx2;
                        decisionParameter += (parameterIncrementX - parameterIncrementY + ry2);
                    }
                sb.Append("<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2;'>" + "(" + x + "," + y + ")" + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + ((2 * ry2) * (x)) + " </td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + ((2 * rx2) * (y)) + "</td></tr>");

                ElipsePoints(x, y, xCenter, yCenter, p);
            }
            decisionParameter = (int)(ry2 * Math.Pow((x + 0.5), 2) + rx2 * Math.Pow((y - 1), 2) - rx2 * ry2);
            sb.Append("<tr><td colspan=\"5\" style = 'padding : 15px;background-color : #f44336;color : #fff;font-weight : bold;text-align : center;'>Region 2</td></tr>");
            sb.Append("<tr style = 'color : #fff;text-align : center;'><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>K</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>P2<sub>k</sub></td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>(X<sub>k+1</sub>,Y<sub>k+1</sub>)</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>2r<sub>y</sub><sup>2</sup>X<sub>k+1</sub></td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>2r<sub>x</sub><sup>2</sup>Y<sub>k+1</sub></td></tr>");
            k = 0;
            while (y >= 0)
            {
                k++;
                if (y > 0)
                    sb.Append("<tr><td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "P" + "<sub>" + k + "</sub>" + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + decisionParameter + "</td>");
                y--;
                parameterIncrementY -= 2 * rx2;
                if (decisionParameter > 0)
                {
                    decisionParameter += rx2 - parameterIncrementY;
                }
                else
                {
                    x++;
                    parameterIncrementX += 2 * ry2;
                    decisionParameter += parameterIncrementX - parameterIncrementY + rx2;
                }
                if (y >= 0)
                    sb.Append("<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2;'>" + "(" + x + "," + y + ")" + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + ((2 * ry2) * (x)) + " </td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + ((2 * rx2) * (y)) + "</td></tr>");
                ElipsePoints(x, y, xCenter, yCenter, p);
            }
            sb.Append("</table>");
            System.IO.File.WriteAllText(sfd.FileName, sb.ToString());
            return p;
        }


        private void ElipsePoints(int x, int y, int xCenter, int yCenter, Bitmap p)
        {
            p.SetPixel(xCenter + x, yCenter + y, Color.Red);
            p.SetPixel(xCenter + x, yCenter - y, Color.Red);
            p.SetPixel(xCenter - x, yCenter + y, Color.Red);
            p.SetPixel(xCenter - x, yCenter - y, Color.Red);
        }
    }
}
