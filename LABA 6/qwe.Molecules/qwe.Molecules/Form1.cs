using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;


namespace qwe.Molecules
{
    
    public partial class Form1 : Form
    {
        FormOfSetText formOfSetText = new FormOfSetText();
        FormOfSetRadius formOfSetRadius = new FormOfSetRadius();
        Circles b = new Circles();
        Edges w = new Edges();
        CirclesAndEdges CAE = new CirclesAndEdges();
        int color = 16777215; // 16777215 - белый цвет
        Point firstPoint = default(Point);
        Point secondPoint = default(Point);
        public Form1()
        {
            InitializeComponent();
        }

        private void SerializeXML()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer xml = new XmlSerializer(typeof(CirclesAndEdges));
                using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, CAE);
                }
            }            
        }        

        private CirclesAndEdges DeserializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(CirclesAndEdges));
            using (FileStream fs = new FileStream("Circles.xml", FileMode.OpenOrCreate))
            {
                return (CirclesAndEdges)xml.Deserialize(fs);
            }
        }

        private void workingField_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {               
                if (b.CirclesList.Count == 0 || CheckDistance(e.X, e.Y) > SearchCircle(e.X,e.Y).Radius)
                {
                    if (b.CirclesList.Count == 0)
                    {
                        CallColorDialog();
                    }
                    do
                    {
                      formOfSetRadius.ShowDialog();
                    } while (formOfSetRadius.TextFromFormOfSetRadius <= 0);                    
                    if (b.CirclesList.Count > 0 && CheckDistance(e.X, e.Y) > (formOfSetRadius.TextFromFormOfSetRadius + SearchCircle(e.X, e.Y).Radius))
                    {
                        b.CirclesList.Add(new Circle(new Point(e.X, e.Y), color, "default", formOfSetRadius.TextFromFormOfSetRadius));  ////                 
                        workingField.Invalidate();
                    }
                    if (b.CirclesList.Count == 0)
                    {
                        b.CirclesList.Add(new Circle(new Point(e.X, e.Y), color, "default", formOfSetRadius.TextFromFormOfSetRadius));  ////                 
                        workingField.Invalidate();
                    }
                    return;
                }
                if (CheckDistance(e.X, e.Y) <= SearchCircle(e.X, e.Y).Radius)
                {                    
                    for (int i = 0; i < b.CirclesList.Count; i++)
                    {
                        if(b.CirclesList[i] == SearchCircle(e.X, e.Y))
                        {
                            formOfSetText.ShowDialog();
                            b.CirclesList[i].CircleText = formOfSetText.TextFromFormOfSetText;
                            workingField.Invalidate();
                        }
                    }
                }
            }
            if (e.Button == MouseButtons.Right && b.CirclesList.Count > 0)
            {
                if (CheckDistance(e.X, e.Y) <= SearchCircle(e.X, e.Y).Radius)
                {
                    if (firstPoint.X == default(Point).X && firstPoint.Y == default(Point).Y)
                    {
                        firstPoint = SearchCircle(e.X, e.Y).CircleCoordinate;                                               
                        return;
                    }
                    secondPoint = SearchCircle(e.X, e.Y).CircleCoordinate;
                    w.EdgesList.Add(new Edge(firstPoint, secondPoint, color));
                    firstPoint = default(Point);
                    secondPoint = new Point();
                    workingField.Invalidate();
                }
            }
            if (e.Button == MouseButtons.Middle && b.CirclesList.Count > 0)
            {
                if (CheckDistance(e.X, e.Y) <= SearchCircle(e.X, e.Y).Radius)
                {
                    Circle m = SearchCircle(e.X, e.Y);
                    for (int i = 0; i < b.CirclesList.Count; i++)
                    {
                        if (b.CirclesList[i] == m)
                        {
                            for (int j = 0; j < w.EdgesList.Count; j++)
                            {
                                if (b.CirclesList[i].CircleCoordinate == w.EdgesList[j].PointFirst || b.CirclesList[i].CircleCoordinate == w.EdgesList[j].PointSecond)
                                {
                                    w.EdgesList[j] = new Edge();
                                }
                            }                            
                            b.CirclesList[i] = new Circle();
                            workingField.Invalidate();
                        }
                    }
                    m = new Circle();
                }
            }
        }

        public void DrawEdge(Graphics a)
        {
            for (int i = 0; i < w.EdgesList.Count; i++)
            {
                Pen pen = new Pen(Color.FromArgb(w.EdgesList[i].EdgeColor), 6.0F);
                a.DrawLine(pen, w.EdgesList[i].PointFirst, w.EdgesList[i].PointSecond);
            }
        }

        public void DrawText(Graphics a)
        {
            for (int i = 0; i < b.CirclesList.Count; i++)
            {
                Color textColor = Color.Black;
                if(b.CirclesList[i].CircleColor == -16777216) // -16777216 Черный цвет
                {
                    textColor = Color.Red;
                }
                Font font = new Font("Times New Roman", 20);
                Size size = TextRenderer.MeasureText(b.CirclesList[i].CircleText, font);
                a.DrawString(b.CirclesList[i].CircleText, font, new SolidBrush(textColor), b.CirclesList[i].CircleCoordinate.X - (size.Width/2), b.CirclesList[i].CircleCoordinate.Y - font.Size);
            }
        }

        public void DrawCircle(Graphics a)
        {
            for (int i = 0; i < b.CirclesList.Count; i++)
            {
                Pen pen = new Pen(Color.FromArgb(b.CirclesList[i].CircleColor));
                a.FillEllipse(new SolidBrush(Color.FromArgb(b.CirclesList[i].CircleColor)), b.CirclesList[i].CircleCoordinate.X - b.CirclesList[i].Radius, b.CirclesList[i].CircleCoordinate.Y - b.CirclesList[i].Radius, 2 * b.CirclesList[i].Radius, 2 * b.CirclesList[i].Radius);
                a.DrawEllipse(pen, b.CirclesList[i].CircleCoordinate.X - b.CirclesList[i].Radius, b.CirclesList[i].CircleCoordinate.Y - b.CirclesList[i].Radius, 2 * b.CirclesList[i].Radius, 2 * b.CirclesList[i].Radius);
            }
        }

        public Circle SearchCircle(int x, int y)
        {
            var distance = CheckDistance(x, y);
            for (int i = 0; i<b.CirclesList.Count; i++)
            {
                if(Math.Sqrt(Math.Pow(x - b.CirclesList[i].CircleCoordinate.X, 2) + Math.Pow(y - b.CirclesList[i].CircleCoordinate.Y, 2)) == distance)
                {
                    return b.CirclesList[i];
                }
            }
            return b.CirclesList[0];
        }
        
        public double CheckDistance(int x, int y) // проверка на разницу в координатах
        {
            var list = new List<double>();
            for (int i = 0; i < b.CirclesList.Count; i++)
            {
                list.Add(Math.Sqrt(Math.Pow(x - b.CirclesList[i].CircleCoordinate.X, 2) + Math.Pow(y - b.CirclesList[i].CircleCoordinate.Y, 2)));                
            }
            list.Sort();
            
            return list[0];
        }        

        public void CallColorDialog()
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            color = MyDialog.Color.ToArgb();
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                color = MyDialog.Color.ToArgb();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CallColorDialog();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            CAE = new CirclesAndEdges(w, b);
            SerializeXML();
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            b = new Circles();
            w = new Edges();
            b = DeserializeXML().CirclesList;
            w = DeserializeXML().EdgesList;
            workingField.Invalidate();
        }

        private void workingField_Paint(object sender, PaintEventArgs e)
        {
            DrawEdge(e.Graphics);
            DrawCircle(e.Graphics);
            DrawText(e.Graphics);
        }
    }
}
