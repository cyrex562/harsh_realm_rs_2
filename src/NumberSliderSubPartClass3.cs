// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.NumberSliderSubPartClass3
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
  public class NumberSliderSubPartClass3 : SubPartClass
  {
    private Font OwnFont;
    private int Width;
    private string prefix;
    private string suffix;
    private int minval;
    private int maxval;
    private int curval;
    private int smallchange;
    private GameClass game;
    private int bx;
    private int by;
    private Bitmap backbitmap;
    private int clickscroll;

    public NumberSliderSubPartClass3(
      GameClass tgame,
      string tprefix,
      string tsuffix,
      int twidth,
      int tminval,
      int tmaxval,
      int startval,
      bool systemfont = false,
      int tsmallchange = 1,
      ref Bitmap tbackbitmap = null,
      int bbx = -1,
      int bby = -1)
      : base(twidth, 22)
    {
      this.Width = twidth;
      this.prefix = tprefix;
      this.minval = tminval;
      this.maxval = tmaxval;
      this.curval = startval;
      this.suffix = tsuffix;
      if (!Information.IsNothing((object) tbackbitmap))
      {
        this.backbitmap = new Bitmap(this.OwnBitmap.Width, this.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
        this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics graphics = Graphics.FromImage((Image) this.backbitmap);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.DrawImage((Image) tbackbitmap, new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), new Rectangle(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
        graphics.CompositingMode = CompositingMode.SourceOver;
      }
      this.bx = bbx;
      this.by = bby;
      this.smallchange = tsmallchange;
      this.game = tgame;
      if (!systemfont)
        this.OwnFont = new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel);
      else
        this.OwnFont = new Font("Courier New", 14f, FontStyle.Regular, GraphicsUnit.Pixel);
    }

    public override Bitmap Paint()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
      {
        Expression.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple(ref Expression, ref this.backbitmap, 0, 0);
        Expression.CompositingMode = CompositingMode.SourceOver;
      }
      int num1 = (int) Math.Round(Conversion.Int((double) this.curval / (double) this.maxval * (double) (this.Width - 291)));
      DrawMod.DrawSteveBlock(ref Expression, 200, 0, this.Width - 201, 20);
      int num2 = num1 - 11;
      if (num2 < 0)
        num2 = 0;
      ref Graphics local1 = ref Expression;
      Bitmap bitmap = BitmapStore.GetBitmap(this.game.VSLIDER);
      ref Bitmap local2 = ref bitmap;
      int x1 = 240 + num2;
      DrawMod.DrawSimple(ref local1, ref local2, x1, 0);
      ref Graphics local3 = ref Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONLEFT);
      ref Bitmap local4 = ref bitmap;
      DrawMod.DrawSimple(ref local3, ref local4, 220, 0);
      ref Graphics local5 = ref Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONRIGHT);
      ref Bitmap local6 = ref bitmap;
      int x2 = this.Width - 40;
      DrawMod.DrawSimple(ref local5, ref local6, x2, 0);
      ref Graphics local7 = ref Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONLEFT2);
      ref Bitmap local8 = ref bitmap;
      DrawMod.DrawSimple(ref local7, ref local8, 200, 0);
      ref Graphics local9 = ref Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONRIGHT2);
      ref Bitmap local10 = ref bitmap;
      int x3 = this.Width - 20;
      DrawMod.DrawSimple(ref local9, ref local10, x3, 0);
      DrawMod.DrawSteveBlock(ref Expression, 0, 0, 180, 20);
      SizeF sizeF1 = new SizeF();
      SizeF sizeF2 = Expression.MeasureString(this.prefix + Conversion.Str((object) this.curval) + this.suffix, this.OwnFont);
      DrawMod.DrawText(ref Expression, this.prefix + Conversion.Str((object) this.curval) + this.suffix, this.OwnFont, (int) Math.Round((double) (172f - sizeF2.Width)), 0);
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return this.OwnBitmap;
    }

    public override int Click(int x, int y, int b = 1)
    {
      this.clickscroll = 0;
      if (x > 200 & x < 220)
      {
        if (b == 1)
          this.curval -= this.smallchange * 10;
        if (this.minval > this.curval)
          this.curval = this.minval;
      }
      else if (x < 240)
      {
        if (b == 1)
          this.curval -= this.smallchange;
        if (this.minval > this.curval)
          this.curval = this.minval;
      }
      else if (x > this.Width - 40 & x <= this.Width - 20)
      {
        if (b == 1)
          this.curval += this.smallchange;
        if (this.curval > this.maxval)
          this.curval = this.maxval;
      }
      else if (x > this.Width - 20)
      {
        if (b == 1)
          this.curval += this.smallchange * 10;
        if (this.curval > this.maxval)
          this.curval = this.maxval;
      }
      else
      {
        this.clickscroll = 1;
        this.curval = (int) Math.Round(Conversion.Int((double) (x - 240) / (double) (this.Width - 291) * (double) this.maxval));
        if (this.curval % this.smallchange > 0)
          this.curval -= this.curval % this.smallchange;
      }
      if (this.curval < this.minval)
        this.curval = this.minval;
      if (this.curval > this.maxval)
        this.curval = this.maxval;
      return this.curval;
    }
  }
}
