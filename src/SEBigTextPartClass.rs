// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SEBigTextPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class SEBigTextPartClass : SubPartClass
  {
     string description;
     bool active;
     string texty;
     int tw;
     int th;

    pub SEBigTextPartClass(
      string tTexty,
      string tDescript,
      bool tactive,
      int twidth,
      int theight)
      : base(twidth, theight)
    {
      this.Descript = tDescript;
      this.active = tactive;
      this.texty = tTexty;
      this.tw = twidth;
      this.th = theight;
    }

    pub Bitmap Paint()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (!this.active)
      {
         Graphics local1 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
         Bitmap local2 =  bitmap;
        rectangle1 = new Rectangle(0, 0, 44, 10);
        Rectangle srcrect1 = rectangle1;
        rectangle2 = new Rectangle(0, 0, this.tw, 10);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
         Graphics local3 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
         Bitmap local4 =  bitmap;
        rectangle2 = new Rectangle(0, 10, 44, 62);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(0, 10, this.tw, this.th - 10);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
         Graphics local5 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
         Bitmap local6 =  bitmap;
        rectangle2 = new Rectangle(0, 82, 44, 10);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(0, this.th - 10, this.tw, 10);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
      }
      if (this.active)
      {
         Graphics local7 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         Bitmap local8 =  bitmap;
        rectangle2 = new Rectangle(0, 0, 44, 10);
        Rectangle srcrect4 = rectangle2;
        rectangle1 = new Rectangle(0, 0, this.tw, 10);
        Rectangle destrect4 = rectangle1;
        DrawMod.DrawSimplePart2( local7,  local8, srcrect4, destrect4);
         Graphics local9 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         Bitmap local10 =  bitmap;
        rectangle2 = new Rectangle(0, 10, 44, 62);
        Rectangle srcrect5 = rectangle2;
        rectangle1 = new Rectangle(0, 10, this.tw, this.th - 10);
        Rectangle destrect5 = rectangle1;
        DrawMod.DrawSimplePart2( local9,  local10, srcrect5, destrect5);
         Graphics local11 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         Bitmap local12 =  bitmap;
        rectangle2 = new Rectangle(0, 82, 44, 10);
        Rectangle srcrect6 = rectangle2;
        rectangle1 = new Rectangle(0, this.th - 10, this.tw, 10);
        Rectangle destrect6 = rectangle1;
        DrawMod.DrawSimplePart2( local11,  local12, srcrect6, destrect6);
      }
      if (this.texty.Length > 3)
      {
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.texty, DrawMod.TGame.MarcFont3,  Math.Round((double) this.tw / 2.0) + 1,  Math.Round((double) this.th / 2.0) - 14, Color.Black);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.texty, DrawMod.TGame.MarcFont3,  Math.Round((double) this.tw / 2.0) + 1,  Math.Round((double) this.th / 2.0) - 14, Color.Black);
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.texty, DrawMod.TGame.MarcFont3,  Math.Round((double) this.tw / 2.0),  Math.Round((double) this.th / 2.0) - 15, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.texty, DrawMod.TGame.MarcFont3,  Math.Round((double) this.tw / 2.0),  Math.Round((double) this.th / 2.0) - 15, DrawMod.TGame.seColWhite);
      }
      else
      {
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.texty, DrawMod.TGame.MarcFont1,  Math.Round((double) this.tw / 2.0) + 1,  Math.Round((double) this.th / 2.0) - 14, Color.Black);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.texty, DrawMod.TGame.MarcFont1,  Math.Round((double) this.tw / 2.0) + 1,  Math.Round((double) this.th / 2.0) - 14, Color.Black);
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.texty, DrawMod.TGame.MarcFont1,  Math.Round((double) this.tw / 2.0),  Math.Round((double) this.th / 2.0) - 15, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.texty, DrawMod.TGame.MarcFont1,  Math.Round((double) this.tw / 2.0),  Math.Round((double) this.th / 2.0) - 15, DrawMod.TGame.seColWhite);
      }
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
      if (!this.active)
      {
         Graphics local1 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
         Bitmap local2 =  bitmap;
        rectangle1 = new Rectangle(0, 0, 44, 10);
        Rectangle srcrect1 = rectangle1;
        rectangle2 = new Rectangle(0, 0, this.tw, 10);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
         Graphics local3 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
         Bitmap local4 =  bitmap;
        rectangle2 = new Rectangle(0, 10, 44, 62);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(0, 10, this.tw, this.th - 10);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
         Graphics local5 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
         Bitmap local6 =  bitmap;
        rectangle2 = new Rectangle(0, 82, 44, 10);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(0, this.th - 10, this.tw, 10);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
         Graphics local7 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         Bitmap local8 =  bitmap;
        rectangle2 = new Rectangle(0, 0, 44, 10);
        Rectangle srcrect4 = rectangle2;
        rectangle1 = new Rectangle(0, 0, this.tw, 10);
        Rectangle destrect4 = rectangle1;
        DrawMod.DrawSimplePart2Coloured( local7,  local8, srcrect4, destrect4, 1f, 1f, 1f, 0.2f);
         Graphics local9 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         Bitmap local10 =  bitmap;
        rectangle2 = new Rectangle(0, 10, 44, 62);
        Rectangle srcrect5 = rectangle2;
        rectangle1 = new Rectangle(0, 10, this.tw, this.th - 10);
        Rectangle destrect5 = rectangle1;
        DrawMod.DrawSimplePart2Coloured( local9,  local10, srcrect5, destrect5, 1f, 1f, 1f, 0.2f);
         Graphics local11 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         Bitmap local12 =  bitmap;
        rectangle2 = new Rectangle(0, 82, 44, 10);
        Rectangle srcrect6 = rectangle2;
        rectangle1 = new Rectangle(0, this.th - 10, this.tw, 10);
        Rectangle destrect6 = rectangle1;
        DrawMod.DrawSimplePart2Coloured( local11,  local12, srcrect6, destrect6, 1f, 1f, 1f, 0.2f);
      }
      if (this.active)
      {
         Graphics local13 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         Bitmap local14 =  bitmap;
        rectangle2 = new Rectangle(0, 0, 44, 10);
        Rectangle srcrect7 = rectangle2;
        rectangle1 = new Rectangle(0, 0, this.tw, 10);
        Rectangle destrect7 = rectangle1;
        DrawMod.DrawSimplePart2( local13,  local14, srcrect7, destrect7);
         Graphics local15 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         Bitmap local16 =  bitmap;
        rectangle2 = new Rectangle(0, 10, 44, 62);
        Rectangle srcrect8 = rectangle2;
        rectangle1 = new Rectangle(0, 10, this.tw, this.th - 10);
        Rectangle destrect8 = rectangle1;
        DrawMod.DrawSimplePart2( local15,  local16, srcrect8, destrect8);
         Graphics local17 =  objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         Bitmap local18 =  bitmap;
        rectangle2 = new Rectangle(0, 82, 44, 10);
        Rectangle srcrect9 = rectangle2;
        rectangle1 = new Rectangle(0, this.th - 10, this.tw, 10);
        Rectangle destrect9 = rectangle1;
        DrawMod.DrawSimplePart2( local17,  local18, srcrect9, destrect9);
      }
      if (this.texty.Length > 3)
      {
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.texty, DrawMod.TGame.MarcFont3,  Math.Round((double) this.tw / 2.0) + 1,  Math.Round((double) this.th / 2.0) - 14, Color.Black);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.texty, DrawMod.TGame.MarcFont3,  Math.Round((double) this.tw / 2.0) + 1,  Math.Round((double) this.th / 2.0) - 14, Color.Black);
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.texty, DrawMod.TGame.MarcFont3,  Math.Round((double) this.tw / 2.0),  Math.Round((double) this.th / 2.0) - 15, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.texty, DrawMod.TGame.MarcFont3,  Math.Round((double) this.tw / 2.0),  Math.Round((double) this.th / 2.0) - 15, DrawMod.TGame.seColWhite);
      }
      else
      {
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.texty, DrawMod.TGame.MarcFont1,  Math.Round((double) this.tw / 2.0) + 1,  Math.Round((double) this.th / 2.0) - 14, Color.Black);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.texty, DrawMod.TGame.MarcFont1,  Math.Round((double) this.tw / 2.0) + 1,  Math.Round((double) this.th / 2.0) - 14, Color.Black);
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.texty, DrawMod.TGame.MarcFont1,  Math.Round((double) this.tw / 2.0),  Math.Round((double) this.th / 2.0) - 15, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter( objgraphics, this.texty, DrawMod.TGame.MarcFont1,  Math.Round((double) this.tw / 2.0),  Math.Round((double) this.th / 2.0) - 15, DrawMod.TGame.seColWhite);
      }
      if (!Information.IsNothing((object) objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }
  }
}
