using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace qwe.Molecules
{
    public class CustomButton: Control
    {

        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
        DoubleBuffered = true;
        Size = new Size(30,30);
        BackColor = Color.Tomato;
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(grPath);
            base.OnPaint(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gr = e.Graphics;
            gr.SmoothingMode = SmoothingMode.HighQuality;

            gr.Clear(Parent.BackColor);

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            Pen pen = new Pen(BackColor);
            Control one = new CustomButton();
            GraphicsPath Button_Path = new GraphicsPath();
            Button_Path.AddEllipse(0, 0, one.Width, one.Height);
            Region Button_Region = new Region(Button_Path);
            one.Region = Button_Region;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CustomButton
            // 
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ResumeLayout(false);

        }
    }
}
