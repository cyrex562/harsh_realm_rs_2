// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ButtonPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsApplication1
{
  pub class ButtonPartClass : SubPartClass
  {
    pub OwnBitmapNr: i32;
     int colorized;
     bool overrule;
     int resizex;
     int resizey;
     bool videoMode;

    pub ButtonPartClass(
      int tbmpnr,
      int tcolorized = 0,
      tDescript: String = "",
      int tResizeX = -1,
      int tresizeY = -1,
      bool tVideoMode = false)
      : base(BitmapStore.GetWidth(tbmpnr), BitmapStore.Getheight(tbmpnr))
    {
      if (tResizeX > -1 & tresizeY > -1)
        this.Resize(tResizeX, tresizeY);
      this.OwnBitmapNr = tbmpnr;
      this.overrule = false;
      this.colorized = tcolorized;
      this.Descript = tDescript;
      this.resizex = tResizeX;
      this.resizey = tresizeY;
      this.videoMode = tVideoMode;
    }

    pub ButtonPartClass(Bitmap tbmpnr, tDescript: String = "")
      : base(tbmpnr.Width, tbmpnr.Height)
    {
      this.OwnBitmap = (Bitmap) tbmpnr.Clone();
      this.overrule = true;
      this.Descript = tDescript;
    }

    pub Bitmap Paint()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (!this.overrule)
      {
        if (this.colorized == 0)
        {
          if (this.resizex == -1)
          {
            ref Graphics local1 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
            ref Bitmap local2 = ref bitmap;
            DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
          }
          else
          {
            ref Graphics local3 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
            ref Bitmap local4 = ref bitmap;
            int resizex = this.resizex;
            int resizey = this.resizey;
            DrawMod.DrawScaled(ref local3, ref local4, 0, 0, resizex, resizey);
          }
        }
        else if (this.colorized == 1)
        {
          if (this.resizex == -1)
          {
            ref Graphics local5 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
            ref Bitmap local6 = ref bitmap;
            DrawMod.Draw(ref local5, ref local6, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
          }
          else
          {
            ref Graphics local7 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
            ref Bitmap local8 = ref bitmap;
            int resizex = this.resizex;
            int resizey = this.resizey;
            int width = BitmapStore.GetWidth(this.OwnBitmapNr);
            int origh = BitmapStore.Getheight(this.OwnBitmapNr);
            DrawMod.DrawScaledColorized(ref local7, ref local8, 0, 0, resizex, resizey, width, origh, -0.3f, -0.3f, -0.3f, 1f);
          }
        }
        else if (this.colorized == 2)
        {
          if (this.resizex == -1)
          {
            ref Graphics local9 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
            ref Bitmap local10 = ref bitmap;
            DrawMod.Draw(ref local9, ref local10, 0, 0, 0.0f, 0.0f, 0.0f, 0.5f);
          }
          else
          {
            ref Graphics local11 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
            ref Bitmap local12 = ref bitmap;
            int resizex = this.resizex;
            int resizey = this.resizey;
            int width = BitmapStore.GetWidth(this.OwnBitmapNr);
            int origh = BitmapStore.Getheight(this.OwnBitmapNr);
            DrawMod.DrawScaledColorized(ref local11, ref local12, 0, 0, resizex, resizey, width, origh, -0.6f, -0.6f, -0.6f, 1f);
          }
        }
        else if (this.colorized == 3)
        {
          if (this.resizex == -1)
          {
            ref Graphics local13 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
            ref Bitmap local14 = ref bitmap;
            DrawMod.Draw(ref local13, ref local14, 0, 0, -0.3f, -0.3f, -0.3f, 1f);
          }
          else
          {
            ref Graphics local15 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
            ref Bitmap local16 = ref bitmap;
            int resizex = this.resizex;
            int resizey = this.resizey;
            int width = BitmapStore.GetWidth(this.OwnBitmapNr);
            int origh = BitmapStore.Getheight(this.OwnBitmapNr);
            DrawMod.DrawScaledColorized(ref local15, ref local16, 0, 0, resizex, resizey, width, origh, -0.6f, -0.6f, -0.6f, 1f);
          }
        }
        else if (this.colorized == 4)
        {
          if (this.resizex == -1)
          {
            ref Graphics local17 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
            ref Bitmap local18 = ref bitmap;
            DrawMod.Draw(ref local17, ref local18, 0, 0, -0.6f, -0.6f, -0.6f, 1f);
          }
          else
          {
            ref Graphics local19 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
            ref Bitmap local20 = ref bitmap;
            int resizex = this.resizex;
            int resizey = this.resizey;
            int width = BitmapStore.GetWidth(this.OwnBitmapNr);
            int origh = BitmapStore.Getheight(this.OwnBitmapNr);
            DrawMod.DrawScaledColorized(ref local19, ref local20, 0, 0, resizex, resizey, width, origh, -0.6f, -0.6f, -0.6f, 1f);
          }
        }
      }
      if (this.videoMode)
      {
        int width = BitmapStore.GetWidth(this.OwnBitmapNr);
        int num1 = BitmapStore.Getheight(this.OwnBitmapNr);
        int num2 = (int) Math.Round((double) width / 2.0);
        int num3 = (int) Math.Round((double) num1 / 2.0);
        int num4 = (int) Math.Round((double) width / 3.0);
        if ((int) Math.Round((double) num1 / 3.0) < num4)
          num4 = (int) Math.Round((double) num1 / 3.0);
        int num5 = num2 - num4;
        int num6 = num3 - num4;
        int num7 = num2 - num4;
        int num8 = num3 + num4;
        int num9 = num2 + num4;
        int num10 = num3;
        Point[] points = new Point[3];
        points[0].X = num5;
        points[0].Y = num6;
        points[1].X = num7;
        points[1].Y = num8;
        points[2].X = num9;
        points[2].Y = num10;
        SolidBrush solidBrush1 = new SolidBrush(Color.FromArgb(50, 155, 155, 155));
        Expression.FillPolygon((Brush) solidBrush1, points);
        Expression.SmoothingMode = SmoothingMode.AntiAlias;
        points[0].X = num5 + 3;
        points[0].Y = num6 + 5;
        points[1].X = num7 + 3;
        points[1].Y = num8 - 5;
        points[2].X = num9 - 5;
        points[2].Y = num10;
        SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(100, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        Expression.FillPolygon((Brush) solidBrush2, points);
      }
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }

    pub Bitmap PaintOverlay()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (!this.overrule)
      {
        if (this.colorized == 0)
        {
          if (this.resizex == -1)
          {
            ref Graphics local1 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
            ref Bitmap local2 = ref bitmap;
            DrawMod.Draw(ref local1, ref local2, 0, 0, 0.2f, 0.2f, 0.2f, 1f);
          }
          else
          {
            ref Graphics local3 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
            ref Bitmap local4 = ref bitmap;
            int resizex = this.resizex;
            int resizey = this.resizey;
            int width = BitmapStore.GetWidth(this.OwnBitmapNr);
            int origh = BitmapStore.Getheight(this.OwnBitmapNr);
            DrawMod.DrawScaledColorized(ref local3, ref local4, 0, 0, resizex, resizey, width, origh, 1f, 0.0f, 0.0f, 1f);
          }
        }
        else if (this.colorized == 1)
        {
          if (this.resizex == -1)
          {
            ref Graphics local5 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
            ref Bitmap local6 = ref bitmap;
            DrawMod.Draw(ref local5, ref local6, 0, 0, 0.0f, 0.0f, 0.0f, 1f);
          }
          else
          {
            ref Graphics local7 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
            ref Bitmap local8 = ref bitmap;
            int resizex = this.resizex;
            int resizey = this.resizey;
            int width = BitmapStore.GetWidth(this.OwnBitmapNr);
            int origh = BitmapStore.Getheight(this.OwnBitmapNr);
            DrawMod.DrawScaledColorized(ref local7, ref local8, 0, 0, resizex, resizey, width, origh, 0.0f, 0.0f, 0.0f, 1f);
          }
        }
        else if (this.colorized == 3)
        {
          if (this.resizex == -1)
          {
            ref Graphics local9 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
            ref Bitmap local10 = ref bitmap;
            DrawMod.Draw(ref local9, ref local10, 0, 0, 0.0f, 0.0f, 0.0f, 1f);
          }
          else
          {
            ref Graphics local11 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
            ref Bitmap local12 = ref bitmap;
            int resizex = this.resizex;
            int resizey = this.resizey;
            int width = BitmapStore.GetWidth(this.OwnBitmapNr);
            int origh = BitmapStore.Getheight(this.OwnBitmapNr);
            DrawMod.DrawScaledColorized(ref local11, ref local12, 0, 0, resizex, resizey, width, origh, -0.6f, -0.6f, -0.6f, 1f);
          }
        }
      }
      if (this.videoMode)
      {
        int width = BitmapStore.GetWidth(this.OwnBitmapNr);
        int num1 = BitmapStore.Getheight(this.OwnBitmapNr);
        int num2 = (int) Math.Round((double) width / 2.0);
        int num3 = (int) Math.Round((double) num1 / 2.0);
        int num4 = (int) Math.Round((double) width / 3.0);
        if ((int) Math.Round((double) num1 / 3.0) < num4)
          num4 = (int) Math.Round((double) num1 / 3.0);
        int num5 = num2 - num4;
        int num6 = num3 - num4;
        int num7 = num2 - num4;
        int num8 = num3 + num4;
        int num9 = num2 + num4;
        int num10 = num3;
        Point[] points = new Point[3];
        points[0].X = num5;
        points[0].Y = num6;
        points[1].X = num7;
        points[1].Y = num8;
        points[2].X = num9;
        points[2].Y = num10;
        SolidBrush solidBrush1 = new SolidBrush(Color.FromArgb(100, 155, 155, 155));
        Expression.FillPolygon((Brush) solidBrush1, points);
        Expression.SmoothingMode = SmoothingMode.AntiAlias;
        points[0].X = num5 + 3;
        points[0].Y = num6 + 5;
        points[1].X = num7 + 3;
        points[1].Y = num8 - 5;
        points[2].X = num9 - 5;
        points[2].Y = num10;
        SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        Expression.FillPolygon((Brush) solidBrush2, points);
      }
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }
  }
}
