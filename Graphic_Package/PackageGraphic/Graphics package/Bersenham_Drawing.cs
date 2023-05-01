using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics.Graphics_package
{
    internal class Bersenham_Drawing
    {
        private int X, Y, xEnd, P, yEnd;
        private point Start, End;
        private float slope;
        private int DeltaX, DeltaY;
        private int twoDeltaY, twoDeltaYMinusTwoDeltaX;
        int height, width;

        public Bersenham_Drawing(point Start, point End, int height, int width)
        {
            this.Start = Start;
            this.End = End;
            slope = Slope();
            this.width = width;
            this.height = height;
        }

        private void intiateConstants()
        {


            P = (2 * DeltaY) - DeltaX;
            twoDeltaY = 2 * DeltaY;
            twoDeltaYMinusTwoDeltaX = twoDeltaY - (2 * DeltaX);
        }
        public float Slope()
        {
            return ((float)End.GetYPoint() - (float)Start.GetYPoint()) / ((float)End.GetXPoint() - (float)Start.GetXPoint());
        }
        private int deltaX()
        {
            return xEnd - X;
        }
        private int deltaY()
        {
            return yEnd - Y;
        }

        private void nextPIfpos()
        {
            if (P < 0)
            {
                P = P + twoDeltaY;
            }
            else
            {
                Y++;
                P = P + twoDeltaYMinusTwoDeltaX;

            }
        }
        private void nextPIfneg()
        {
            if (P < 0)
            {
                P += twoDeltaY;

            }
            else
            {
                Y--;
                P += twoDeltaYMinusTwoDeltaX;

            }
        }
        private void swap(int x, int y)
        {
            int z;
            z = x;
            x = y;
            y = z;
        }
        public Bitmap drawLine(Bitmap pic)
        {

            if (slope <= 1 && slope > 0)
            {
                if (Start.GetXPoint() < End.GetXPoint())
                {
                    fristOctant(pic);
                }
                else
                {
                    fifthoctant(pic);
                }
            }
            else if (slope > 1)
            {
                if (Start.GetYPoint() < End.GetYPoint())
                {
                    secondOctant(pic);
                }
                else
                {
                    sixoctant(pic);
                }
            }
            else if (slope < -1)
            {
                if (Start.GetYPoint() < End.GetYPoint())
                {
                    thirdOctant(pic);
                }
                else
                {
                    seventhOctant(pic);
                }
            }
            else if (slope >= -1 && slope < 0)
            {
                if (Start.GetXPoint() > End.GetXPoint())
                {
                    fourthOctant(pic);
                }
                else
                {
                    lastOctant(pic);
                }
            }

            return pic;
        }
        private void originalInitiatePoint()
        {
            X = Start.GetXPoint();
            Y = Start.GetYPoint();
            xEnd = End.GetXPoint();
            yEnd = End.GetYPoint();
        }
        private void swappingpoint()
        {
            X = Start.GetYPoint();
            Y = Start.GetXPoint();
            xEnd = End.GetYPoint();
            yEnd = End.GetXPoint();
        }
        private void fristOctant(Bitmap pic)
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
            sb.Append("<thead style = 'background-color : #0075FF;color : #fff;font-weight : bold;text-align : center;border-color : #f35246'><tr><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>K</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>P<sub>k</sub></td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>X</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>Y</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>Pixel Plotted</td></tr></thead>");
            int k = 0;
            originalInitiatePoint();
            DeltaX = deltaX();
            DeltaY = deltaY();
            intiateConstants();

            pic.SetPixel(X + width, height - Y, Color.Red);
            while (X < xEnd)
            {
                X += 1;
                nextPIfpos();
                pic.SetPixel(X + width, height - Y, Color.Red);
                sb.Append("<tr><td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "P" + "<sub>" + k + "</sub>" + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + P + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2;'>" + X + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + Y + " </td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "(" + X + "," + Y + ")" + "</td></tr>");
            }
            sb.Append("</table>");
            System.IO.File.WriteAllText(sfd.FileName, sb.ToString());
        }
        private void secondOctant(Bitmap pic)
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
            sb.Append("<thead style = 'background-color : #0075FF;color : #fff;font-weight : bold;text-align : center;border-color : #f35246'><tr><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>K</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>P<sub>k</sub></td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>X</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>Y</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>Pixel Plotted</td></tr></thead>");
            int k = 0;
            swappingpoint();
            DeltaX = deltaX();
            DeltaY = deltaY();
            intiateConstants();
            pic.SetPixel(Y + width, height - X, Color.Red);
            while (X < xEnd)
            {
                X += 1;
                nextPIfpos();
                pic.SetPixel(Y + width, height - X, Color.Red);
                pic.SetPixel(Y + width, height - X, Color.Black);
                sb.Append("<tr><td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "P" + "<sub>" + k + "</sub>" + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + P + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2;'>" + X + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + Y + " </td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "(" + X + "," + Y + ")" + "</td></tr>");

            }
            sb.Append("</table>");
            System.IO.File.WriteAllText(sfd.FileName, sb.ToString());
        }
        private void thirdOctant(Bitmap pic)
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
            sb.Append("<thead style = 'background-color : #f44336;color : #fff;font-weight : bold;text-align : center;border-color : #f35246'><tr><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>K</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>P<sub>k</sub></td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>X</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>Y</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>Pixel Plotted</td></tr></thead>");
            int k = 0;
            swappingpoint();
            DeltaX = deltaX();
            DeltaY = Math.Abs(deltaY());
            intiateConstants();
            pic.SetPixel(X + width, height - Y, Color.Red);
            while(X < xEnd)
            {
                X += 1;
                nextPIfneg();
                pic.SetPixel(Y + width, height - X, Color.Red);
                pic.SetPixel(Y + width, height - X, Color.Black);
                sb.Append("<tr><td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "P" + "<sub>" + k + "</sub>" + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + P + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2;'>" + X + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + Y + " </td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "(" + X + "," + Y + ")" + "</td></tr>");

            }
            sb.Append("</table>");
            System.IO.File.WriteAllText(sfd.FileName, sb.ToString());

        }
        private void fourthOctant(Bitmap pic)
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
            sb.Append("<thead style = 'background-color : #f44336;color : #fff;font-weight : bold;text-align : center;border-color : #f35246'><tr><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>K</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>P<sub>k</sub></td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>X</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>Y</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>Pixel Plotted</td></tr></thead>");
            int k = 0;
            originalInitiatePoint();
            DeltaX = Math.Abs(deltaX());
            DeltaY = Math.Abs(deltaY());
            intiateConstants();
            pic.SetPixel(X + width, height - Y, Color.Red);
            while(X > xEnd)
            {
                X -= 1;
                nextPIfpos();
                pic.SetPixel(X + width, height - Y, Color.Red);
                sb.Append("<tr><td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "P" + "<sub>" + k + "</sub>" + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + P + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2;'>" + X + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + Y + " </td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "(" + X + "," + Y + ")" + "</td></tr>");

            }
            sb.Append("</table>");
            System.IO.File.WriteAllText(sfd.FileName, sb.ToString());
        }
        private void fifthoctant(Bitmap pic)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            int k = 0;
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
            sb.Append("<thead style = 'background-color : #f44336;color : #fff;font-weight : bold;text-align : center;border-color : #f35246'><tr><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>K</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>P<sub>k</sub></td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>X</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>Y</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>Pixel Plotted</td></tr></thead>");
            originalInitiatePoint();
            DeltaX = Math.Abs(deltaX());
            DeltaY = Math.Abs(deltaY());
            intiateConstants();
            pic.SetPixel(X + width, height - Y, Color.Red);
            while (X > xEnd)
            {
                X -= 1;
                nextPIfneg();
                pic.SetPixel(X + width, height - Y, Color.Red);
                sb.Append("<tr><td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "P" + "<sub>" + k + "</sub>" + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + P + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2;'>" + X + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + Y + " </td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "(" + X + "," + Y + ")" + "</td></tr>");

            }
            sb.Append("</table>");
            System.IO.File.WriteAllText(sfd.FileName, sb.ToString());
        }
        public void sixoctant(Bitmap pic)
        {
            SaveFileDialog sfd = new SaveFileDialog(); int k = 0;
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
            sb.Append("<thead style = 'background-color : #f44336;color : #fff;font-weight : bold;text-align : center;border-color : #f35246'><tr><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>K</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>P<sub>k</sub></td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>X</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>Y</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>Pixel Plotted</td></tr></thead>");
            swappingpoint();
            DeltaX = Math.Abs(deltaX());
            DeltaY = Math.Abs(deltaY());
            intiateConstants();
            pic.SetPixel(Y + width, height - X, Color.Red);
            while (X > xEnd)
            {
                X -= 1;
                nextPIfneg();
                pic.SetPixel(Y + width, height - X, Color.Red);
                sb.Append("<tr><td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "P" + "<sub>" + k + "</sub>" + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + P + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2;'>" + X + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + Y + " </td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "(" + X + "," + Y + ")" + "</td></tr>");

            }
            sb.Append("</table>");
            System.IO.File.WriteAllText(sfd.FileName, sb.ToString());
        }
        private void seventhOctant(Bitmap pic)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            int k = 0;
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
            sb.Append("<thead style = 'background-color : #f44336;color : #fff;font-weight : bold;text-align : center;border-color : #f35246'><tr><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>K</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>P<sub>k</sub></td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>X</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>Y</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>Pixel Plotted</td></tr></thead>");
            swappingpoint();
            DeltaX = Math.Abs(deltaX());
            DeltaY = Math.Abs(deltaY());
            intiateConstants();
            pic.SetPixel(Y + width, height - X, Color.Red);
            while (X > xEnd)
            {
                X -= 1;
                nextPIfpos();
                pic.SetPixel(Y + width, height - X, Color.Red);
                sb.Append("<tr><td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "P" + "<sub>" + k + "</sub>" + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + P + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2;'>" + X + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + Y + " </td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "(" + X + "," + Y + ")" + "</td></tr>");

            }
            sb.Append("</table>");
            System.IO.File.WriteAllText(sfd.FileName, sb.ToString());
        }
        private void lastOctant(Bitmap pic)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            int k = 0;
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
            sb.Append("<thead style = 'background-color : #f44336;color : #fff;font-weight : bold;text-align : center;border-color : #f35246'><tr><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>K</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>P<sub>k</sub></td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>X</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>Y</td><td style = 'padding : 15px;background-color:#f44336;border : 1px solid #f35246'>Pixel Plotted</td></tr></thead>");
            originalInitiatePoint();
            DeltaX = Math.Abs(deltaX());
            DeltaY = Math.Abs(deltaY());
            intiateConstants();
            pic.SetPixel(X + width, Y, Color.Red);
            while(X < xEnd)
            {
                X += 1;
                nextPIfneg();
                pic.SetPixel(X+width, height - Y, Color.Red);
                pic.SetPixel(X + width, height - Y, Color.Black);
                sb.Append("<tr><td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "P" + "<sub>" + k + "</sub>" + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + P + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2;'>" + X + "</td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + Y + " </td>" + "<td style = 'padding : 15px;background-color:#eee;border : 1px solid #e2e2e2'>" + "(" + X + "," + Y + ")" + "</td></tr>");
            }
            sb.Append("</table>");
            System.IO.File.WriteAllText(sfd.FileName, sb.ToString());
        }
        public float returnP()
        {
            return slope;
        }
    }
}
