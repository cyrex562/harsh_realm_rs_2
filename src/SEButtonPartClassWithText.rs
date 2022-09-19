// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SEButtonPartClassWithText
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingSystem;
// usingSystem.Drawing;

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
         let mut local1: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         let mut local2: &Bitmap = &bitmap;
        rectangle1 = Rectangle::new(14, 0, 7, 35);
        let mut srcrect1: &Rectangle = &rectangle1
        rectangle2 = Rectangle::new(14, 0, this.width - 28, this.height);
        let mut destrect1: &Rectangle = &rectangle2
        DrawMod.DrawSimplePart2ColouredOld( local1,  local2, srcrect1, destrect1, 0.25f, 0.25f, 0.25f, 1f);
         let mut local3: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         let mut local4: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 0, 14, 35);
        let mut srcrect2: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, 0, 14, this.height);
        let mut destrect2: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2ColouredOld( local3,  local4, srcrect2, destrect2, 0.25f, 0.25f, 0.25f, 1f);
         let mut local5: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         let mut local6: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(21, 0, 14, 35);
        let mut srcrect3: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(this.width - 14, 0, 14, this.height);
        let mut destrect3: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2ColouredOld( local5,  local6, srcrect3, destrect3, 0.25f, 0.25f, 0.25f, 1f);
      }
      else
      {
         let mut local7: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         let mut local8: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(14, 0, 7, 35);
        let mut srcrect4: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(14, 0, this.width - 28, this.height);
        let mut destrect4: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local7,  local8, srcrect4, destrect4);
         let mut local9: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         let mut local10: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 0, 14, 35);
        let mut srcrect5: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, 0, 14, this.height);
        let mut destrect5: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local9,  local10, srcrect5, destrect5);
         let mut local11: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         let mut local12: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(21, 0, 14, 35);
        let mut srcrect6: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(this.width - 14, 0, 14, this.height);
        let mut destrect6: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local11,  local12, srcrect6, destrect6);
      }
      if (this.iconNr < 0)
      {
        BitmapStore.GetWidth(this.OwnBitmapNr);
        let mut num1: i32 = BitmapStore.Getheight(this.OwnBitmapNr);
        let mut num2: i32 = 0;
        let mut num3: i32 =  Math.Round( (this.height - num1) / 2.0);
         let mut local13: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
         let mut local14: &Bitmap = &bitmap;
        let mut x: i32 = num2;
        let mut y: i32 = num3;
        DrawMod.DrawSimple( local13,  local14, x, y);
      }
      else
      {
        let mut x: i32 = 0;
        let mut y: i32 =  Math.Round( (this.height - 32) / 2.0);
        if (this.gray)
        {
           let mut local15: &Graphics = &objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
           let mut local16: &Bitmap = &bitmap;
          rectangle2 = Rectangle::new(this.iconNr * 42, 0, 42, 32);
          let mut srcrect: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(x, y, 42, 32);
          let mut destrect: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2ColouredOld( local15,  local16, srcrect, destrect, 0.3f, 0.3f, 0.3f, 1f);
        }
        else
        {
           let mut local17: &Graphics = &objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
           let mut local18: &Bitmap = &bitmap;
          rectangle2 = Rectangle::new(this.iconNr * 42, 0, 42, 32);
          let mut srcrect: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(x, y, 42, 32);
          let mut destrect: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2( local17,  local18, srcrect, destrect);
        }
      }
      if (this.gray)
        DrawMod.DrawTextColouredConsole( objgraphics, this.texty, DrawMod.TGame.MarcFont7, 42, 8, Color.FromArgb( byte.MaxValue, 140, 140, 140));
      else
        DrawMod.DrawTextColouredConsole( objgraphics, this.texty, DrawMod.TGame.MarcFont7, 42, 8, DrawMod.TGame.seColGray);
      if (!Information.IsNothing( objgraphics))
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
         let mut local1: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         let mut local2: &Bitmap = &bitmap;
        rectangle1 = Rectangle::new(14, 0, 7, 35);
        let mut srcrect1: &Rectangle = &rectangle1
        rectangle2 = Rectangle::new(14, 0, this.width - 28, this.height);
        let mut destrect1: &Rectangle = &rectangle2
        DrawMod.DrawSimplePart2ColouredOld( local1,  local2, srcrect1, destrect1, 0.25f, 0.25f, 0.25f, 1f);
         let mut local3: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         let mut local4: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 0, 14, 35);
        let mut srcrect2: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, 0, 14, this.height);
        let mut destrect2: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2ColouredOld( local3,  local4, srcrect2, destrect2, 0.25f, 0.25f, 0.25f, 1f);
         let mut local5: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         let mut local6: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(21, 0, 14, 35);
        let mut srcrect3: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(this.width - 14, 0, 14, this.height);
        let mut destrect3: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2ColouredOld( local5,  local6, srcrect3, destrect3, 0.25f, 0.25f, 0.25f, 1f);
      }
      else
      {
         let mut local7: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTONHIGH);
         let mut local8: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(14, 0, 7, 35);
        let mut srcrect4: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(14, 0, this.width - 28, this.height);
        let mut destrect4: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local7,  local8, srcrect4, destrect4);
         let mut local9: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTONHIGH);
         let mut local10: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(0, 0, 14, 35);
        let mut srcrect5: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, 0, 14, this.height);
        let mut destrect5: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local9,  local10, srcrect5, destrect5);
         let mut local11: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTONHIGH);
         let mut local12: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(21, 0, 14, 35);
        let mut srcrect6: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(this.width - 14, 0, 14, this.height);
        let mut destrect6: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local11,  local12, srcrect6, destrect6);
      }
      if (this.iconNr < 0)
      {
        BitmapStore.GetWidth(this.OwnBitmapNr);
        let mut num1: i32 = BitmapStore.Getheight(this.OwnBitmapNr);
        let mut num2: i32 = 0;
        let mut num3: i32 =  Math.Round( (this.height - num1) / 2.0);
         let mut local13: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
         let mut local14: &Bitmap = &bitmap;
        let mut x: i32 = num2;
        let mut y: i32 = num3;
        DrawMod.DrawSimple( local13,  local14, x, y);
      }
      else
      {
        let mut x: i32 = 0;
        let mut y: i32 =  Math.Round( (this.height - 32) / 2.0);
        if (this.gray)
        {
           let mut local15: &Graphics = &objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
           let mut local16: &Bitmap = &bitmap;
          rectangle2 = Rectangle::new(this.iconNr * 42, 0, 42, 32);
          let mut srcrect: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(x, y, 42, 32);
          let mut destrect: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2ColouredOld( local15,  local16, srcrect, destrect, 0.3f, 0.3f, 0.3f, 1f);
        }
        else
        {
           let mut local17: &Graphics = &objgraphics;
          bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
           let mut local18: &Bitmap = &bitmap;
          rectangle2 = Rectangle::new(this.iconNr * 42, 32, 42, 32);
          let mut srcrect: &Rectangle = &rectangle2
          rectangle1 = Rectangle::new(x, y, 42, 32);
          let mut destrect: &Rectangle = &rectangle1
          DrawMod.DrawSimplePart2( local17,  local18, srcrect, destrect);
        }
      }
      DrawMod.DrawTextColouredConsole( objgraphics, this.texty, DrawMod.TGame.MarcFont7, 42, 8, DrawMod.TGame.seColWhite);
      if (!Information.IsNothing( objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }
  }
}
