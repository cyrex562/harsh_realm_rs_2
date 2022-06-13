// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SEButtonPartClassWithText
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class SEButtonPartClassWithText : SubPartClass
  {
     int OwnBitmapNr;
     int iconNr;
     int width;
     int height;
     bool gray;
     string texty;

    pub void SubDispose()
    {
    }

    pub SEButtonPartClassWithText(
      string ttexty,
      int tbmpnr,
      tDescript: String = "",
      let mut twidth: i32 = 35,
      let mut theight: i32 = 35,
      let mut ticonNr: i32 = -1,
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

    pub Bitmap Paint()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (this.gray)
      {
         Graphics local1 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         Bitmap local2 =  bitmap;
        rectangle1 = new Rectangle(14, 0, 7, 35);
        Rectangle srcrect1 = rectangle1;
        rectangle2 = new Rectangle(14, 0, this.width - 28, this.height);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2ColouredOld( local1,  local2, srcrect1, destrect1, 0.25f, 0.25f, 0.25f, 1f);
         Graphics local3 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         Bitmap local4 =  bitmap;
        rectangle2 = new Rectangle(0, 0, 14, 35);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(0, 0, 14, this.height);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2ColouredOld( local3,  local4, srcrect2, destrect2, 0.25f, 0.25f, 0.25f, 1f);
         Graphics local5 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         Bitmap local6 =  bitmap;
        rectangle2 = new Rectangle(21, 0, 14, 35);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(this.width - 14, 0, 14, this.height);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2ColouredOld( local5,  local6, srcrect3, destrect3, 0.25f, 0.25f, 0.25f, 1f);
      }
      else
      {
         Graphics local7 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         Bitmap local8 =  bitmap;
        rectangle2 = new Rectangle(14, 0, 7, 35);
        Rectangle srcrect4 = rectangle2;
        rectangle1 = new Rectangle(14, 0, this.width - 28, this.height);
        Rectangle destrect4 = rectangle1;
        DrawMod.DrawSimplePart2( local7,  local8, srcrect4, destrect4);
         Graphics local9 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         Bitmap local10 =  bitmap;
        rectangle2 = new Rectangle(0, 0, 14, 35);
        Rectangle srcrect5 = rectangle2;
        rectangle1 = new Rectangle(0, 0, 14, this.height);
        Rectangle destrect5 = rectangle1;
        DrawMod.DrawSimplePart2( local9,  local10, srcrect5, destrect5);
         Graphics local11 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         Bitmap local12 =  bitmap;
        rectangle2 = new Rectangle(21, 0, 14, 35);
        Rectangle srcrect6 = rectangle2;
        rectangle1 = new Rectangle(this.width - 14, 0, 14, this.height);
        Rectangle destrect6 = rectangle1;
        DrawMod.DrawSimplePart2( local11,  local12, srcrect6, destrect6);
      }
      if (this.iconNr < 0)
      {
        BitmapStore.GetWidth(this.OwnBitmapNr);
        let mut num1: i32 = BitmapStore.Getheight(this.OwnBitmapNr);
        let mut num2: i32 = 0;
        let mut num3: i32 =  Math.Round((double) (this.height - num1) / 2.0);
         Graphics local13 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
         Bitmap local14 =  bitmap;
        let mut x: i32 = num2;
        let mut y: i32 = num3;
        DrawMod.DrawSimple( local13,  local14, x, y);
      }
      else
      {
        let mut x: i32 = 0;
        let mut y: i32 =  Math.Round((double) (this.height - 32) / 2.0);
        if (this.gray)
        {
           Graphics local15 =  objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
           Bitmap local16 =  bitmap;
          rectangle2 = new Rectangle(this.iconNr * 42, 0, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(x, y, 42, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2ColouredOld( local15,  local16, srcrect, destrect, 0.3f, 0.3f, 0.3f, 1f);
        }
        else
        {
           Graphics local17 =  objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
           Bitmap local18 =  bitmap;
          rectangle2 = new Rectangle(this.iconNr * 42, 0, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(x, y, 42, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2( local17,  local18, srcrect, destrect);
        }
      }
      if (this.gray)
        DrawMod.DrawTextColouredConsole( objgraphics, this.texty, DrawMod.TGame.MarcFont7, 42, 8, Color.FromArgb( byte.MaxValue, 140, 140, 140));
      else
        DrawMod.DrawTextColouredConsole( objgraphics, this.texty, DrawMod.TGame.MarcFont7, 42, 8, DrawMod.TGame.seColGray);
      if (!Information.IsNothing((object) objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }

    pub Bitmap PaintOverlay()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (this.gray)
      {
         Graphics local1 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         Bitmap local2 =  bitmap;
        rectangle1 = new Rectangle(14, 0, 7, 35);
        Rectangle srcrect1 = rectangle1;
        rectangle2 = new Rectangle(14, 0, this.width - 28, this.height);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2ColouredOld( local1,  local2, srcrect1, destrect1, 0.25f, 0.25f, 0.25f, 1f);
         Graphics local3 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         Bitmap local4 =  bitmap;
        rectangle2 = new Rectangle(0, 0, 14, 35);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(0, 0, 14, this.height);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2ColouredOld( local3,  local4, srcrect2, destrect2, 0.25f, 0.25f, 0.25f, 1f);
         Graphics local5 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         Bitmap local6 =  bitmap;
        rectangle2 = new Rectangle(21, 0, 14, 35);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(this.width - 14, 0, 14, this.height);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2ColouredOld( local5,  local6, srcrect3, destrect3, 0.25f, 0.25f, 0.25f, 1f);
      }
      else
      {
         Graphics local7 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTONHIGH);
         Bitmap local8 =  bitmap;
        rectangle2 = new Rectangle(14, 0, 7, 35);
        Rectangle srcrect4 = rectangle2;
        rectangle1 = new Rectangle(14, 0, this.width - 28, this.height);
        Rectangle destrect4 = rectangle1;
        DrawMod.DrawSimplePart2( local7,  local8, srcrect4, destrect4);
         Graphics local9 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTONHIGH);
         Bitmap local10 =  bitmap;
        rectangle2 = new Rectangle(0, 0, 14, 35);
        Rectangle srcrect5 = rectangle2;
        rectangle1 = new Rectangle(0, 0, 14, this.height);
        Rectangle destrect5 = rectangle1;
        DrawMod.DrawSimplePart2( local9,  local10, srcrect5, destrect5);
         Graphics local11 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTONHIGH);
         Bitmap local12 =  bitmap;
        rectangle2 = new Rectangle(21, 0, 14, 35);
        Rectangle srcrect6 = rectangle2;
        rectangle1 = new Rectangle(this.width - 14, 0, 14, this.height);
        Rectangle destrect6 = rectangle1;
        DrawMod.DrawSimplePart2( local11,  local12, srcrect6, destrect6);
      }
      if (this.iconNr < 0)
      {
        BitmapStore.GetWidth(this.OwnBitmapNr);
        let mut num1: i32 = BitmapStore.Getheight(this.OwnBitmapNr);
        let mut num2: i32 = 0;
        let mut num3: i32 =  Math.Round((double) (this.height - num1) / 2.0);
         Graphics local13 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
         Bitmap local14 =  bitmap;
        let mut x: i32 = num2;
        let mut y: i32 = num3;
        DrawMod.DrawSimple( local13,  local14, x, y);
      }
      else
      {
        let mut x: i32 = 0;
        let mut y: i32 =  Math.Round((double) (this.height - 32) / 2.0);
        if (this.gray)
        {
           Graphics local15 =  objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
           Bitmap local16 =  bitmap;
          rectangle2 = new Rectangle(this.iconNr * 42, 0, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(x, y, 42, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2ColouredOld( local15,  local16, srcrect, destrect, 0.3f, 0.3f, 0.3f, 1f);
        }
        else
        {
           Graphics local17 =  objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
           Bitmap local18 =  bitmap;
          rectangle2 = new Rectangle(this.iconNr * 42, 32, 42, 32);
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(x, y, 42, 32);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2( local17,  local18, srcrect, destrect);
        }
      }
      DrawMod.DrawTextColouredConsole( objgraphics, this.texty, DrawMod.TGame.MarcFont7, 42, 8, DrawMod.TGame.seColWhite);
      if (!Information.IsNothing((object) objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }
  }
}
