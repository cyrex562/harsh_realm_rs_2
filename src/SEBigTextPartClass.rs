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
         let mut local1: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
         let mut local2: &Bitmap = &bitmap;
        rectangle1 = Rectangle::new(0, 0, 44, 10);
        let mut srcrect1: &Rectangle = &rectangle1
        rectangle2 = Rectangle::new(0, 0, this.tw, 10);
        let mut destrect1: &Rectangle = &rectangle2
        DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
         let mut local3: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
         let mut local4: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 10, 44, 62);
        let mut srcrect2: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, 10, this.tw, this.th - 10);
        let mut destrect2: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
         let mut local5: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
         let mut local6: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 82, 44, 10);
        let mut srcrect3: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, this.th - 10, this.tw, 10);
        let mut destrect3: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
      }
      if (this.active)
      {
         let mut local7: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         let mut local8: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 0, 44, 10);
        let mut srcrect4: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, 0, this.tw, 10);
        let mut destrect4: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local7,  local8, srcrect4, destrect4);
         let mut local9: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         let mut local10: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 10, 44, 62);
        let mut srcrect5: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, 10, this.tw, this.th - 10);
        let mut destrect5: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local9,  local10, srcrect5, destrect5);
         let mut local11: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         let mut local12: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 82, 44, 10);
        let mut srcrect6: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, this.th - 10, this.tw, 10);
        let mut destrect6: &Rectangle = &rectangle1
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
         let mut local1: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
         let mut local2: &Bitmap = &bitmap;
        rectangle1 = Rectangle::new(0, 0, 44, 10);
        let mut srcrect1: &Rectangle = &rectangle1
        rectangle2 = Rectangle::new(0, 0, this.tw, 10);
        let mut destrect1: &Rectangle = &rectangle2
        DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
         let mut local3: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
         let mut local4: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 10, 44, 62);
        let mut srcrect2: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, 10, this.tw, this.th - 10);
        let mut destrect2: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
         let mut local5: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTON);
         let mut local6: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 82, 44, 10);
        let mut srcrect3: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, this.th - 10, this.tw, 10);
        let mut destrect3: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
         let mut local7: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         let mut local8: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 0, 44, 10);
        let mut srcrect4: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, 0, this.tw, 10);
        let mut destrect4: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2Coloured( local7,  local8, srcrect4, destrect4, 1f, 1f, 1f, 0.2f);
         let mut local9: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         let mut local10: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 10, 44, 62);
        let mut srcrect5: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, 10, this.tw, this.th - 10);
        let mut destrect5: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2Coloured( local9,  local10, srcrect5, destrect5, 1f, 1f, 1f, 0.2f);
         let mut local11: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         let mut local12: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 82, 44, 10);
        let mut srcrect6: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, this.th - 10, this.tw, 10);
        let mut destrect6: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2Coloured( local11,  local12, srcrect6, destrect6, 1f, 1f, 1f, 0.2f);
      }
      if (this.active)
      {
         let mut local13: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         let mut local14: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 0, 44, 10);
        let mut srcrect7: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, 0, this.tw, 10);
        let mut destrect7: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local13,  local14, srcrect7, destrect7);
         let mut local15: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         let mut local16: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 10, 44, 62);
        let mut srcrect8: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, 10, this.tw, this.th - 10);
        let mut destrect8: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local15,  local16, srcrect8, destrect8);
         let mut local17: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_BOTTOMPAGEBUTTONHIGH);
         let mut local18: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 82, 44, 10);
        let mut srcrect9: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, this.th - 10, this.tw, 10);
        let mut destrect9: &Rectangle = &rectangle1
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
