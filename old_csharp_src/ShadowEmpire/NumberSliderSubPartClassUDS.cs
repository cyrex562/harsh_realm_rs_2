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
  public class NumberSliderSubPartClassUDS : SubPartClass
  {
    private int minval;
    private int maxval;
    private int curval;
    private GameClass game;
    private int bx;
    private int by;
    private int bmp;
    private int barw;
    private int width;
    private int height;

    public override void SubDispose()
    {
    }

    public NumberSliderSubPartClassUDS(
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
      this.barw = (int) Math.Round(Math.Max(20.0, (double) twidth / 10.0));
      this.bmp = tgame.SE1_ARROWBUTTON;
      this.game = tgame;
    }

    public override Bitmap Paint()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      ref Graphics local1 = ref Expression;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.PAPERBACK2);
      ref Bitmap local2 = ref bitmap1;
      int width = this.width;
      int height1 = this.height;
      DrawMod.DrawScaled(ref local1, ref local2, 0, 0, width, height1);
      DrawMod.DrawBlock(ref Expression, this.height, 0, this.width - (int) Math.Round((double) this.height / 2.0), this.height, 0, 0, 0, 64);
      int num = this.width - this.barw - this.height * 2;
      int x1 = (this.maxval - this.minval <= 0 ? num : (int) Math.Round((double) (num * (this.curval - this.minval)) / (double) (this.maxval - this.minval))) + this.height;
      ref Graphics local3 = ref Expression;
      Bitmap bitmap2 = BitmapStore.GetBitmap(this.bmp);
      ref Bitmap local4 = ref bitmap2;
      int height2 = this.height;
      int height3 = this.height;
      DrawMod.DrawScaled(ref local3, ref local4, 0, 0, height2, height3, true);
      DrawMod.DrawTextColouredConsoleCenterEmbossed(ref Expression, "<", this.game.MarcFont4, (int) Math.Round((double) this.height / 2.0), (int) Math.Round((double) (this.height - 20) / 2.0), Color.White);
      ref Graphics local5 = ref Expression;
      Bitmap bitmap3 = BitmapStore.GetBitmap(this.bmp);
      ref Bitmap local6 = ref bitmap3;
      int x2 = this.width - this.height;
      int height4 = this.height;
      int height5 = this.height;
      DrawMod.DrawScaled(ref local5, ref local6, x2, 0, height4, height5, true);
      DrawMod.DrawTextColouredConsoleCenterEmbossed(ref Expression, ">", this.game.MarcFont4, this.width - (int) Math.Round((double) this.height / 2.0), (int) Math.Round((double) (this.height - 20) / 2.0), Color.White);
      ref Graphics local7 = ref Expression;
      Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
      ref Bitmap local8 = ref bitmap4;
      Rectangle rectangle1 = new Rectangle(7, 0, 7, 35);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(x1 + 7, 0, this.barw - 14, this.height);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect1, destrect1);
      ref Graphics local9 = ref Expression;
      Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
      ref Bitmap local10 = ref bitmap5;
      rectangle2 = new Rectangle(0, 0, 7, 35);
      Rectangle srcrect2 = rectangle2;
      rectangle1 = new Rectangle(x1, 0, 7, this.height);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect2, destrect2);
      ref Graphics local11 = ref Expression;
      bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
      ref Bitmap local12 = ref bitmap5;
      rectangle2 = new Rectangle(29, 0, 7, 35);
      Rectangle srcrect3 = rectangle2;
      rectangle1 = new Rectangle(x1 + this.barw - 7, 0, 7, this.height);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect3, destrect3);
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }

    public override Bitmap PaintOverlay()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      ref Graphics local1 = ref Expression;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.PAPERBACK2);
      ref Bitmap local2 = ref bitmap1;
      int width = this.width;
      int height1 = this.height;
      DrawMod.DrawScaled(ref local1, ref local2, 0, 0, width, height1);
      DrawMod.DrawBlock(ref Expression, this.height, 0, this.width - (int) Math.Round((double) this.height / 2.0), this.height, 0, 0, 0, 64);
      int num = this.width - this.barw - this.height * 2;
      int x1 = (this.maxval - this.minval <= 0 ? num : (int) Math.Round((double) (num * (this.curval - this.minval)) / (double) (this.maxval - this.minval))) + this.height;
      ref Graphics local3 = ref Expression;
      Bitmap bitmap2 = BitmapStore.GetBitmap(this.bmp);
      ref Bitmap local4 = ref bitmap2;
      int height2 = this.height;
      int height3 = this.height;
      DrawMod.DrawScaled(ref local3, ref local4, 0, 0, height2, height3, true);
      DrawMod.DrawTextColouredConsoleCenterEmbossed(ref Expression, "<", this.game.MarcFont4, (int) Math.Round((double) this.height / 2.0), (int) Math.Round((double) (this.height - 20) / 2.0), Color.White);
      ref Graphics local5 = ref Expression;
      Bitmap bitmap3 = BitmapStore.GetBitmap(this.bmp);
      ref Bitmap local6 = ref bitmap3;
      int x2 = this.width - this.height;
      int height4 = this.height;
      int height5 = this.height;
      DrawMod.DrawScaled(ref local5, ref local6, x2, 0, height4, height5, true);
      DrawMod.DrawTextColouredConsoleCenterEmbossed(ref Expression, ">", this.game.MarcFont4, this.width - (int) Math.Round((double) this.height / 2.0), (int) Math.Round((double) (this.height - 20) / 2.0), Color.White);
      ref Graphics local7 = ref Expression;
      Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
      ref Bitmap local8 = ref bitmap4;
      Rectangle rectangle1 = new Rectangle(7, 0, 7, 35);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(x1 + 7, 0, this.barw - 14, this.height);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect1, destrect1);
      ref Graphics local9 = ref Expression;
      Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
      ref Bitmap local10 = ref bitmap5;
      rectangle2 = new Rectangle(0, 0, 7, 35);
      Rectangle srcrect2 = rectangle2;
      rectangle1 = new Rectangle(x1, 0, 7, this.height);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect2, destrect2);
      ref Graphics local11 = ref Expression;
      bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
      ref Bitmap local12 = ref bitmap5;
      rectangle2 = new Rectangle(29, 0, 7, 35);
      Rectangle srcrect3 = rectangle2;
      rectangle1 = new Rectangle(x1 + this.barw - 7, 0, 7, this.height);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect3, destrect3);
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }
  }
}
