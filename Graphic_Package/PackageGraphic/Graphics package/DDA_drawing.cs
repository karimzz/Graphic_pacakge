using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics.Graphics_package
{
    internal class DDA_drawing
    {
        private point Start;
        private point End;
        private int steps;
        private float xIncrement; 
        private float yIncrement;

        public DDA_drawing(point start, point end)
        {
            this.Start = start;
            this.End = end;
        }

        private int DeltaX()
        {
            return End.GetXPoint() - Start.GetXPoint();
        }

        private int DeltaY()
        {
            return End.GetYPoint() - Start.GetYPoint();
        }

        private void setSteps()
        {
            if (DeltaY() < DeltaX())
            {
                steps = Math.Abs(DeltaX());
            }
            else
                steps = Math.Abs(DeltaY());
        }

        private void setIncrements()
        {
            xIncrement = DeltaX() / (float)steps;
            yIncrement = DeltaY() / (float)steps;
        }

        public Bitmap drawLine(Bitmap p)
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
            sb.Append("<thead style = 'background-color : #f44336;color : #fff;font-weight : bold;text-align : center;border-color : #f35246'><tr><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>K</td>");
             if (Math.Abs( DeltaX() ) > Math.Abs( DeltaY()  ))
                sb.Append("<td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246' > X </td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'> Y </td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246' > Pixel Plotted </td></tr></thead>");
            else
                sb.Append("<td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246' > Y </td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'> X </td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246' > Pixel Plotted </td></tr></thead>");

            setSteps();
            setIncrements();
            float x = Start.GetXPoint();
            float y = Start.GetYPoint();
            p.SetPixel((int)x, (int)y, Color.Red);
            for (int i = 0; i < steps; i++)
            {
                x += xIncrement;
                y += yIncrement;
                p.SetPixel((int)Math.Round(x), (int)Math.Round(y), Color.Red);
                if (Math.Abs( DeltaX() ) > Math.Abs(  DeltaY() ))
                    sb.Append("<tr><td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "P" + "<sub>" + (i + 1) + "</sub>" + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + Math.Round((x - 300), 2) + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + Math.Round((300 - y), 2) + " </td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "(" + ((int)Math.Round((x - 300))) + "," + ((int)Math.Round((300 - y))) + ")" + "</td></tr>");
                else
                    sb.Append("<tr><td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "P" + "<sub>" + (i + 1) + "</sub>" + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + Math.Round((300 - y), 2) + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + Math.Round((x - 300), 2) + " </td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "(" + ((int)Math.Round((x - 300))) + "," + ((int)Math.Round((300 - y))) + ")" + "</td></tr>");
            }
             sb.Append("</table>");
            System.IO.File.WriteAllText(sfd.FileName, sb.ToString());
            return p;
        }
    }
}
