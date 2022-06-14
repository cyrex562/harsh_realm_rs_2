// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.NumberSliderSubPartClassUDS
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class NumberSliderSubPartClassUDS : SubPartClass
  {
     int minval;
     int maxval;
     int curval;
     GameClass game;
     int bx;
     int by;
     int bmp;
     int barw;
     int width;
     int height;

    pub void SubDispose()
    {
    }

    pub NumberSliderSubPartClassUDS(
      GameClass tgame,
      int twidth,
      int theight,
      int tminval,
      int tmaxval,
      int startval)
      : base(twidth, theight)
    {
      this.width = twidth;
      this.height = theight;
      this.minval = tminval;
      this.maxval = tmaxval;
      this.curval = startval;
      this.barw =  Math.Round(Math.Max(20.0, (double) twidth / 10.0));
      this.bmp = tgame.SE1_ARROWBUTTON;
      this.game = tgame;
    }

    pub Bitmap Paint()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
       let mut local1: &Graphics = &Expression;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.PAPERBACK2);
       let mut local2: &Bitmap = &bitmap1;
      let mut width: i32 =  this.width;
      let mut height1: i32 =  this.height;
      DrawMod.DrawScaled( local1,  local2, 0, 0, width, height1);
      DrawMod.DrawBlock( Expression, this.height, 0, this.width -  Math.Round((double) this.height / 2.0), this.height, 0, 0, 0, 64);
      let mut num: i32 =  this.width - this.barw - this.height * 2;
      let mut x1: i32 =  (this.maxval - this.minval <= 0 ? num :  Math.Round((double) (num * (this.curval - this.minval)) / (double) (this.maxval - this.minval))) + this.height;
       let mut local3: &Graphics = &Expression;
      Bitmap bitmap2 = BitmapStore.GetBitmap(this.bmp);
       let mut local4: &Bitmap = &bitmap2;
      let mut height2: i32 =  this.height;
      let mut height3: i32 =  this.height;
      DrawMod.DrawScaled( local3,  local4, 0, 0, height2, height3, true);
      DrawMod.DrawTextColouredConsoleCenterEmbossed( Expression, "<", this.game.MarcFont4,  Math.Round((double) this.height / 2.0),  Math.Round((double) (this.height - 20) / 2.0), Color.White);
       let mut local5: &Graphics = &Expression;
      Bitmap bitmap3 = BitmapStore.GetBitmap(this.bmp);
       let mut local6: &Bitmap = &bitmap3;
      let mut x2: i32 =  this.width - this.height;
      let mut height4: i32 =  this.height;
      let mut height5: i32 =  this.height;
      DrawMod.DrawScaled( local5,  local6, x2, 0, height4, height5, true);
      DrawMod.DrawTextColouredConsoleCenterEmbossed( Expression, ">", this.game.MarcFont4, this.width -  Math.Round((double) this.height / 2.0),  Math.Round((double) (this.height - 20) / 2.0), Color.White);
       let mut local7: &Graphics = &Expression;
      Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
       let mut local8: &Bitmap = &bitmap4;
      Rectangle rectangle1 = Rectangle::new(7, 0, 7, 35);
      let mut srcrect1: &Rectangle = &rectangle1
      Rectangle rectangle2 = Rectangle::new(x1 + 7, 0, this.barw - 14, this.height);
      let mut destrect1: &Rectangle = &rectangle2
      DrawMod.DrawSimplePart2( local7,  local8, srcrect1, destrect1);
       let mut local9: &Graphics = &Expression;
      Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
       let mut local10: &Bitmap = &bitmap5;
      rectangle2 = Rectangle::new(0, 0, 7, 35);
      let mut srcrect2: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x1, 0, 7, this.height);
      let mut destrect2: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2( local9,  local10, srcrect2, destrect2);
       let mut local11: &Graphics = &Expression;
      bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
       let mut local12: &Bitmap = &bitmap5;
      rectangle2 = Rectangle::new(29, 0, 7, 35);
      let mut srcrect3: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x1 + this.barw - 7, 0, 7, this.height);
      let mut destrect3: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2( local11,  local12, srcrect3, destrect3);
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }

    pub Bitmap PaintOverlay()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
       let mut local1: &Graphics = &Expression;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.PAPERBACK2);
       let mut local2: &Bitmap = &bitmap1;
      let mut width: i32 =  this.width;
      let mut height1: i32 =  this.height;
      DrawMod.DrawScaled( local1,  local2, 0, 0, width, height1);
      DrawMod.DrawBlock( Expression, this.height, 0, this.width -  Math.Round((double) this.height / 2.0), this.height, 0, 0, 0, 64);
      let mut num: i32 =  this.width - this.barw - this.height * 2;
      let mut x1: i32 =  (this.maxval - this.minval <= 0 ? num :  Math.Round((double) (num * (this.curval - this.minval)) / (double) (this.maxval - this.minval))) + this.height;
       let mut local3: &Graphics = &Expression;
      Bitmap bitmap2 = BitmapStore.GetBitmap(this.bmp);
       let mut local4: &Bitmap = &bitmap2;
      let mut height2: i32 =  this.height;
      let mut height3: i32 =  this.height;
      DrawMod.DrawScaled( local3,  local4, 0, 0, height2, height3, true);
      DrawMod.DrawTextColouredConsoleCenterEmbossed( Expression, "<", this.game.MarcFont4,  Math.Round((double) this.height / 2.0),  Math.Round((double) (this.height - 20) / 2.0), Color.White);
       let mut local5: &Graphics = &Expression;
      Bitmap bitmap3 = BitmapStore.GetBitmap(this.bmp);
       let mut local6: &Bitmap = &bitmap3;
      let mut x2: i32 =  this.width - this.height;
      let mut height4: i32 =  this.height;
      let mut height5: i32 =  this.height;
      DrawMod.DrawScaled( local5,  local6, x2, 0, height4, height5, true);
      DrawMod.DrawTextColouredConsoleCenterEmbossed( Expression, ">", this.game.MarcFont4, this.width -  Math.Round((double) this.height / 2.0),  Math.Round((double) (this.height - 20) / 2.0), Color.White);
       let mut local7: &Graphics = &Expression;
      Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
       let mut local8: &Bitmap = &bitmap4;
      Rectangle rectangle1 = Rectangle::new(7, 0, 7, 35);
      let mut srcrect1: &Rectangle = &rectangle1
      Rectangle rectangle2 = Rectangle::new(x1 + 7, 0, this.barw - 14, this.height);
      let mut destrect1: &Rectangle = &rectangle2
      DrawMod.DrawSimplePart2( local7,  local8, srcrect1, destrect1);
       let mut local9: &Graphics = &Expression;
      Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
       let mut local10: &Bitmap = &bitmap5;
      rectangle2 = Rectangle::new(0, 0, 7, 35);
      let mut srcrect2: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x1, 0, 7, this.height);
      let mut destrect2: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2( local9,  local10, srcrect2, destrect2);
       let mut local11: &Graphics = &Expression;
      bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
       let mut local12: &Bitmap = &bitmap5;
      rectangle2 = Rectangle::new(29, 0, 7, 35);
      let mut srcrect3: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(x1 + this.barw - 7, 0, 7, this.height);
      let mut destrect3: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2( local11,  local12, srcrect3, destrect3);
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }
  }
}
