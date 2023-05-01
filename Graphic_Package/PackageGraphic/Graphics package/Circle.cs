using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics.Graphics_package
{
    internal class Circle
    {
        private point Center;
        private int Radius;
        private int decisionParameter;

        public Circle(point center, int radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        public Bitmap drawCircle(Bitmap p)
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
            sb.Append("<thead style = 'background-color : #0075FF;color : #fff;font-weight : bold;text-align : center;border-color : #f35246'><tr><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>K</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>P<sub>k</sub></td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>(X,Y)</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>2X<sub>k+1</sub></td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>2Y<sub>k+1</sub></td></tr></thead>");
            int k = 0;
            int x = 0;
            int y = Radius;
            int xCenter = Center.GetXPoint();
            int yCenter = Center.GetYPoint();
            decisionParameter = 1 - Radius;
            CirclePoints(x, y, xCenter, yCenter, p);
            while(x < y)
            {
                k++;
                sb.Append("<tr><td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "P" + "<sub>" + k + "</sub>" + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + decisionParameter + "</td>");
                x++;
                if (decisionParameter < 0)
                {
                    decisionParameter += 2 * x + 1;
                }
                else
                {
                    y--;
                    decisionParameter += 2 * (x - y) + 1;
                }
                sb.Append("<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2;'>" + "(" + x + "," + y + ")" + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + (2 * x) + " </td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + (2 * y) + "</td></tr>");

                CirclePoints(x, y, xCenter, yCenter, p);
            }
            sb.Append("</table>");
            System.IO.File.WriteAllText(sfd.FileName, sb.ToString());
            return p;
        }

        private void CirclePoints(int x, int y, int xCenter, int yCenter, Bitmap p)
        {
            p.SetPixel(xCenter + x, yCenter + y, Color.Red);
            p.SetPixel(xCenter - x, yCenter + y, Color.Red);
            p.SetPixel(xCenter + x, yCenter - y, Color.Red);
            p.SetPixel(xCenter - x, yCenter - y, Color.Red);
            p.SetPixel(xCenter + y, yCenter + x, Color.Red);
            p.SetPixel(xCenter + y, yCenter - x, Color.Red);
            p.SetPixel(xCenter - y, yCenter + x, Color.Red);
            p.SetPixel(xCenter - y, yCenter - x, Color.Red);

        }
    }
}
