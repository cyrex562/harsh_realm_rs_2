﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SEButtonPartClassWithText
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class SEButtonPartClassWithText : SubPartClass
  {
    private int OwnBitmapNr;
    private int iconNr;
    private int width;
    private int height;
    private bool gray;
    private string texty;

    public override void SubDispose()
    {
    }

    public SEButtonPartClassWithText(
      string ttexty,
      int tbmpnr,
      string tDescript = "",
      int twidth = 35,
      int theight = 35,
      int ticonNr = -1,
      bool tgrayedOut = false)
      : base(twidth, theight)
    {
      this.width = twidth;
      this.height = theight;
      this.OwnBitmapNr = tbmpnr;
      this.Descript = tDescript;
      this.iconNr = ticonNr;
      this.gray = tgrayedOut;
      this.texty = ttexty;
    }

    public override Bitmap Paint()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (this.gray)
      {
        ref Graphics local1 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
        ref Bitmap local2 = ref bitmap;
        rectangle1 = new Rectangle(14, 0, 7, 35);
        Rectangle srcrect1 = rectangle1;
        rectangle2 = new Rectangle(14, 0, this.width - 28, this.height);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2ColouredOld(ref local1, ref local2, srcrect1, destrect1, 0.25f, 0.25f, 0.25f, 1f);
        ref Graphics local3 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
        ref Bitmap local4 = ref bitmap;
        rectangle2 = new Rectangle(0, 0, 14, 35);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(0, 0, 14, this.height);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2ColouredOld(ref local3, ref local4, srcrect2, destrect2, 0.25f, 0.25f, 0.25f, 1f);
        ref Graphics local5 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
        ref Bitmap local6 = ref bitmap;
        rectangle2 = new Rectangle(21, 0, 14, 35);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(this.width - 14, 0, 14, this.height);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2ColouredOld(ref local5, ref local6, srcrect3, destrect3, 0.25f, 0.25f, 0.25f, 1f);
      }
      else
      {
        ref Graphics local7 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
        ref Bitmap local8 = ref bitmap;
        rectangle2 = new Rectangle(14, 0, 7, 35);
        Rectangle srcrect4 = rectangle2;
        rectangle1 = new Rectangle(14, 0, this.width - 28, this.height);
        Rectangle destrect4 = rectangle1;
        DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
        ref Graphics local9 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
        ref Bitmap local10 = ref bitmap;
        rectangle2 = new Rectangle(0, 0, 14, 35);
        Rectangle srcrect5 = rectangle2;
        rectangle1 = new Rectangle(0, 0, 14, this.height);
        Rectangle destrect5 = rectangle1;
        DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
        ref Graphics local11 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
        ref Bitmap local12 = ref bitmap;
        rectangle2 = new Rectangle(21, 0, 14, 35);
        Rectangle srcrect6 = rectangle2;
        rectangle1 = new Rectangle(this.width - 14, 0, 14, this.height);
        Rectangle destrect6 = rectangle1;
        DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
      }
      if (this.iconNr < 0)
      {
        BitmapStore.GetWidth(this.OwnBitmapNr);
        int num1 = BitmapStore.Getheight(this.OwnBitmapNr);
        int num2 = 0;
        int num3 = (int) Math.Round((double) (this.height - num1) / 2.0);
        ref Graphics local13 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
        ref Bitmap local14 = ref bitmap;
        int x = num2;
        int y = num3;
        DrawMod.DrawSimple(ref local13, ref local14, x, y);
      }
      else
      {
        int x = 0;
        int y = (int) Math.Round((double) (this.height - 32) / 2.0);
        if (this.gray)
        {
          ref Graphics local15 = ref objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
          ref Bitmap local16 = ref bitmap;
          rectangle2 = new Rectangle(this.iconNr * 42, 0, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(x, y, 42, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2ColouredOld(ref local15, ref local16, srcrect, destrect, 0.3f, 0.3f, 0.3f, 1f);
        }
        else
        {
          ref Graphics local17 = ref objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
          ref Bitmap local18 = ref bitmap;
          rectangle2 = new Rectangle(this.iconNr * 42, 0, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(x, y, 42, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect, destrect);
        }
      }
      if (this.gray)
        DrawMod.DrawTextColouredConsole(ref objgraphics, this.texty, DrawMod.TGame.MarcFont7, 42, 8, Color.FromArgb((int) byte.MaxValue, 140, 140, 140));
      else
        DrawMod.DrawTextColouredConsole(ref objgraphics, this.texty, DrawMod.TGame.MarcFont7, 42, 8, DrawMod.TGame.seColGray);
      if (!Information.IsNothing((object) objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }

    public override Bitmap PaintOverlay()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (this.gray)
      {
        ref Graphics local1 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
        ref Bitmap local2 = ref bitmap;
        rectangle1 = new Rectangle(14, 0, 7, 35);
        Rectangle srcrect1 = rectangle1;
        rectangle2 = new Rectangle(14, 0, this.width - 28, this.height);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2ColouredOld(ref local1, ref local2, srcrect1, destrect1, 0.25f, 0.25f, 0.25f, 1f);
        ref Graphics local3 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
        ref Bitmap local4 = ref bitmap;
        rectangle2 = new Rectangle(0, 0, 14, 35);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(0, 0, 14, this.height);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2ColouredOld(ref local3, ref local4, srcrect2, destrect2, 0.25f, 0.25f, 0.25f, 1f);
        ref Graphics local5 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
        ref Bitmap local6 = ref bitmap;
        rectangle2 = new Rectangle(21, 0, 14, 35);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(this.width - 14, 0, 14, this.height);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2ColouredOld(ref local5, ref local6, srcrect3, destrect3, 0.25f, 0.25f, 0.25f, 1f);
      }
      else
      {
        ref Graphics local7 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTONHIGH);
        ref Bitmap local8 = ref bitmap;
        rectangle2 = new Rectangle(14, 0, 7, 35);
        Rectangle srcrect4 = rectangle2;
        rectangle1 = new Rectangle(14, 0, this.width - 28, this.height);
        Rectangle destrect4 = rectangle1;
        DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
        ref Graphics local9 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTONHIGH);
        ref Bitmap local10 = ref bitmap;
        rectangle2 = new Rectangle(0, 0, 14, 35);
        Rectangle srcrect5 = rectangle2;
        rectangle1 = new Rectangle(0, 0, 14, this.height);
        Rectangle destrect5 = rectangle1;
        DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
        ref Graphics local11 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTONHIGH);
        ref Bitmap local12 = ref bitmap;
        rectangle2 = new Rectangle(21, 0, 14, 35);
        Rectangle srcrect6 = rectangle2;
        rectangle1 = new Rectangle(this.width - 14, 0, 14, this.height);
        Rectangle destrect6 = rectangle1;
        DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
      }
      if (this.iconNr < 0)
      {
        BitmapStore.GetWidth(this.OwnBitmapNr);
        int num1 = BitmapStore.Getheight(this.OwnBitmapNr);
        int num2 = 0;
        int num3 = (int) Math.Round((double) (this.height - num1) / 2.0);
        ref Graphics local13 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
        ref Bitmap local14 = ref bitmap;
        int x = num2;
        int y = num3;
        DrawMod.DrawSimple(ref local13, ref local14, x, y);
      }
      else
      {
        int x = 0;
        int y = (int) Math.Round((double) (this.height - 32) / 2.0);
        if (this.gray)
        {
          ref Graphics local15 = ref objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
          ref Bitmap local16 = ref bitmap;
          rectangle2 = new Rectangle(this.iconNr * 42, 0, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(x, y, 42, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2ColouredOld(ref local15, ref local16, srcrect, destrect, 0.3f, 0.3f, 0.3f, 1f);
        }
        else
        {
          ref Graphics local17 = ref objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
          ref Bitmap local18 = ref bitmap;
          rectangle2 = new Rectangle(this.iconNr * 42, 32, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(x, y, 42, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect, destrect);
        }
      }
      DrawMod.DrawTextColouredConsole(ref objgraphics, this.texty, DrawMod.TGame.MarcFont7, 42, 8, DrawMod.TGame.seColWhite);
      if (!Information.IsNothing((object) objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }
  }
}
