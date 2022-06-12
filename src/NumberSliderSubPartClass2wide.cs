// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.NumberSliderSubPartClass2wide
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
  public class NumberSliderSubPartClass2wide : SubPartClass
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
    private bool Marc;

    public override void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    public NumberSliderSubPartClass2wide(
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
      int bby = -1,
      bool tMarc = false)
      : base(twidth, 60)
    {
      this.Width = twidth;
      this.prefix = tprefix;
      this.minval = tminval;
      this.maxval = tmaxval;
      this.curval = startval;
      this.suffix = tsuffix;
      this.Marc = tMarc;
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
      if (tMarc)
        this.OwnFont = this.game.MarcFont7;
      else if (!systemfont)
        this.OwnFont = this.game.VicFont3;
      else
        this.OwnFont = this.game.VicFont3;
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
      DrawMod.DrawBlock(ref Expression, 0, 20, this.Width, 40, 0, 0, 0, 155);
      int num1 = this.Width - 264;
      int num2 = this.maxval <= 0 ? num1 : (int) Math.Round(Conversion.Int((double) this.curval / (double) this.maxval * (double) num1));
      if (num2 < 0)
        num2 = 0;
      ref Graphics local1 = ref Expression;
      Bitmap bitmap = BitmapStore.GetBitmap(this.game.VSLIDERBIG);
      ref Bitmap local2 = ref bitmap;
      int x1 = 120 + num2;
      DrawMod.DrawSimple(ref local1, ref local2, x1, 20);
      ref Graphics local3 = ref Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONLEFTBIG);
      ref Bitmap local4 = ref bitmap;
      DrawMod.DrawSimple(ref local3, ref local4, 60, 20);
      ref Graphics local5 = ref Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONRIGHTBIG);
      ref Bitmap local6 = ref bitmap;
      int x2 = this.Width - 120;
      DrawMod.DrawSimple(ref local5, ref local6, x2, 20);
      ref Graphics local7 = ref Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONLEFT2BIG);
      ref Bitmap local8 = ref bitmap;
      DrawMod.DrawSimple(ref local7, ref local8, 0, 20);
      ref Graphics local9 = ref Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONRIGHT2BIG);
      ref Bitmap local10 = ref bitmap;
      int x3 = this.Width - 60;
      DrawMod.DrawSimple(ref local9, ref local10, x3, 20);
      if (this.Marc)
      {
        string str = Strings.UCase(this.prefix + Conversion.Str((object) this.curval) + this.suffix);
        SizeF sizeF1 = new SizeF();
        SizeF sizeF2 = Expression.MeasureString(str, this.game.MarcFont4);
        DrawMod.DrawTextColouredMarc(ref Expression, str, this.game.MarcFont4, (int) Math.Round(((double) this.Width - (double) sizeF2.Width) / 2.0), 2, Color.White);
      }
      else
        DrawMod.DrawTextVic2(ref Expression, this.prefix + Conversion.Str((object) this.curval) + this.suffix, this.OwnFont, 2, 3, this.game.VicColor2, this.game.VicColor2Shade);
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return this.OwnBitmap;
    }

    public override int HandleMouseUp(int x, int y)
    {
      if (!(this.Scroller | this.clickscroll == 1))
        return -1;
      this.curval = (int) Math.Round(Conversion.Int((double) (x - 120) / (double) (this.Width - 264) * (double) this.maxval));
      if (this.curval % this.smallchange > 0)
        this.curval -= this.curval % this.smallchange;
      if (this.curval < this.minval)
        this.curval = this.minval;
      if (this.curval > this.maxval)
        this.curval = this.maxval;
      this.Scroller = false;
      this.clickscroll = 0;
      return this.curval;
    }

    public override bool MouseMove(int x, int y)
    {
      if (this.clickscroll != 1)
        return false;
      this.clickscroll = 1;
      this.curval = (int) Math.Round(Conversion.Int((double) (x - 120) / (double) (this.Width - 264) * (double) this.maxval));
      if (this.curval % this.smallchange > 0)
        this.curval -= this.curval % this.smallchange;
      if (this.curval < this.minval)
        this.curval = this.minval;
      if (this.curval > this.maxval)
        this.curval = this.maxval;
      return true;
    }

    public override int Click(int x, int y, int b = 1)
    {
      int curval = this.curval;
      this.clickscroll = 0;
      if (y > 20)
      {
        if (x < 60)
        {
          if (b == 1)
            this.curval -= this.smallchange * 10;
          if (this.minval > this.curval)
            this.curval = this.minval;
        }
        else if (x < 120)
        {
          if (b == 1)
            this.curval -= this.smallchange;
          if (this.minval > this.curval)
            this.curval = this.minval;
        }
        else if (x > this.Width - 120 & x <= this.Width - 60)
        {
          if (b == 1)
            this.curval += this.smallchange;
          if (this.curval > this.maxval)
            this.curval = this.maxval;
        }
        else if (x > this.Width - 60)
        {
          if (b == 1)
          {
            this.curval += this.smallchange * 10;
            if (curval == 1 & this.curval == 11)
              this.curval = 10;
            if (curval == 1 & this.curval == 101)
              this.curval = 100;
          }
          if (this.curval > this.maxval)
            this.curval = this.maxval;
        }
        else
        {
          this.clickscroll = 1;
          this.Scroller = true;
          this.curval = (int) Math.Round(Conversion.Int((double) (x - 120) / (double) (this.Width - 264) * (double) this.maxval));
          if (this.curval % this.smallchange > 0)
            this.curval -= this.curval % this.smallchange;
        }
      }
      if (this.curval < this.minval)
        this.curval = this.minval;
      if (this.curval > this.maxval)
        this.curval = this.maxval;
      return this.curval;
    }
  }
}
