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
       Graphics local1 =  Expression;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.PAPERBACK2);
       Bitmap local2 =  bitmap1;
      int width = this.width;
      int height1 = this.height;
      DrawMod.DrawScaled( local1,  local2, 0, 0, width, height1);
      DrawMod.DrawBlock( Expression, this.height, 0, this.width -  Math.Round((double) this.height / 2.0), this.height, 0, 0, 0, 64);
      int num = this.width - this.barw - this.height * 2;
      int x1 = (this.maxval - this.minval <= 0 ? num :  Math.Round((double) (num * (this.curval - this.minval)) / (double) (this.maxval - this.minval))) + this.height;
       Graphics local3 =  Expression;
      Bitmap bitmap2 = BitmapStore.GetBitmap(this.bmp);
       Bitmap local4 =  bitmap2;
      int height2 = this.height;
      int height3 = this.height;
      DrawMod.DrawScaled( local3,  local4, 0, 0, height2, height3, true);
      DrawMod.DrawTextColouredConsoleCenterEmbossed( Expression, "<", this.game.MarcFont4,  Math.Round((double) this.height / 2.0),  Math.Round((double) (this.height - 20) / 2.0), Color.White);
       Graphics local5 =  Expression;
      Bitmap bitmap3 = BitmapStore.GetBitmap(this.bmp);
       Bitmap local6 =  bitmap3;
      int x2 = this.width - this.height;
      int height4 = this.height;
      int height5 = this.height;
      DrawMod.DrawScaled( local5,  local6, x2, 0, height4, height5, true);
      DrawMod.DrawTextColouredConsoleCenterEmbossed( Expression, ">", this.game.MarcFont4, this.width -  Math.Round((double) this.height / 2.0),  Math.Round((double) (this.height - 20) / 2.0), Color.White);
       Graphics local7 =  Expression;
      Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
       Bitmap local8 =  bitmap4;
      Rectangle rectangle1 = new Rectangle(7, 0, 7, 35);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(x1 + 7, 0, this.barw - 14, this.height);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2( local7,  local8, srcrect1, destrect1);
       Graphics local9 =  Expression;
      Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
       Bitmap local10 =  bitmap5;
      rectangle2 = new Rectangle(0, 0, 7, 35);
      Rectangle srcrect2 = rectangle2;
      rectangle1 = new Rectangle(x1, 0, 7, this.height);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2( local9,  local10, srcrect2, destrect2);
       Graphics local11 =  Expression;
      bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
       Bitmap local12 =  bitmap5;
      rectangle2 = new Rectangle(29, 0, 7, 35);
      Rectangle srcrect3 = rectangle2;
      rectangle1 = new Rectangle(x1 + this.barw - 7, 0, 7, this.height);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2( local11,  local12, srcrect3, destrect3);
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }

    pub Bitmap PaintOverlay()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
       Graphics local1 =  Expression;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.PAPERBACK2);
       Bitmap local2 =  bitmap1;
      int width = this.width;
      int height1 = this.height;
      DrawMod.DrawScaled( local1,  local2, 0, 0, width, height1);
      DrawMod.DrawBlock( Expression, this.height, 0, this.width -  Math.Round((double) this.height / 2.0), this.height, 0, 0, 0, 64);
      int num = this.width - this.barw - this.height * 2;
      int x1 = (this.maxval - this.minval <= 0 ? num :  Math.Round((double) (num * (this.curval - this.minval)) / (double) (this.maxval - this.minval))) + this.height;
       Graphics local3 =  Expression;
      Bitmap bitmap2 = BitmapStore.GetBitmap(this.bmp);
       Bitmap local4 =  bitmap2;
      int height2 = this.height;
      int height3 = this.height;
      DrawMod.DrawScaled( local3,  local4, 0, 0, height2, height3, true);
      DrawMod.DrawTextColouredConsoleCenterEmbossed( Expression, "<", this.game.MarcFont4,  Math.Round((double) this.height / 2.0),  Math.Round((double) (this.height - 20) / 2.0), Color.White);
       Graphics local5 =  Expression;
      Bitmap bitmap3 = BitmapStore.GetBitmap(this.bmp);
       Bitmap local6 =  bitmap3;
      int x2 = this.width - this.height;
      int height4 = this.height;
      int height5 = this.height;
      DrawMod.DrawScaled( local5,  local6, x2, 0, height4, height5, true);
      DrawMod.DrawTextColouredConsoleCenterEmbossed( Expression, ">", this.game.MarcFont4, this.width -  Math.Round((double) this.height / 2.0),  Math.Round((double) (this.height - 20) / 2.0), Color.White);
       Graphics local7 =  Expression;
      Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
       Bitmap local8 =  bitmap4;
      Rectangle rectangle1 = new Rectangle(7, 0, 7, 35);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(x1 + 7, 0, this.barw - 14, this.height);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2( local7,  local8, srcrect1, destrect1);
       Graphics local9 =  Expression;
      Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
       Bitmap local10 =  bitmap5;
      rectangle2 = new Rectangle(0, 0, 7, 35);
      Rectangle srcrect2 = rectangle2;
      rectangle1 = new Rectangle(x1, 0, 7, this.height);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2( local9,  local10, srcrect2, destrect2);
       Graphics local11 =  Expression;
      bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
       Bitmap local12 =  bitmap5;
      rectangle2 = new Rectangle(29, 0, 7, 35);
      Rectangle srcrect3 = rectangle2;
      rectangle1 = new Rectangle(x1 + this.barw - 7, 0, 7, this.height);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2( local11,  local12, srcrect3, destrect3);
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }
  }
}
