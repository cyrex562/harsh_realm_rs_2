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
  pub class NumberSliderSubPartClass2wide : SubPartClass
  {
     Font OwnFont;
     int Width;
     string prefix;
     string suffix;
     int minval;
     int maxval;
     int curval;
     int smallchange;
     GameClass game;
     int bx;
     int by;
     Bitmap backbitmap;
     int clickscroll;
     bool Marc;

    pub void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    pub NumberSliderSubPartClass2wide(
      GameClass tgame,
      string tprefix,
      string tsuffix,
      int twidth,
      int tminval,
      int tmaxval,
      int startval,
      bool systemfont = false,
      let mut tsmallchange: i32 =  1,
       Bitmap tbackbitmap = null,
      let mut bbx: i32 =  -1,
      let mut bby: i32 =  -1,
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
        graphics.DrawImage((Image) tbackbitmap, Rectangle::new(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), Rectangle::new(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
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

    pub Bitmap Paint()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
      {
        Expression.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple( Expression,  this.backbitmap, 0, 0);
        Expression.CompositingMode = CompositingMode.SourceOver;
      }
      DrawMod.DrawBlock( Expression, 0, 20, this.Width, 40, 0, 0, 0, 155);
      let mut num1: i32 =  this.Width - 264;
      let mut num2: i32 =  this.maxval <= 0 ? num1 :  Math.Round(Conversion.Int((double) this.curval / (double) this.maxval * (double) num1));
      if (num2 < 0)
        num2 = 0;
       let mut local1: &Graphics = &Expression;
      Bitmap bitmap = BitmapStore.GetBitmap(this.game.VSLIDERBIG);
       let mut local2: &Bitmap = &bitmap;
      let mut x1: i32 =  120 + num2;
      DrawMod.DrawSimple( local1,  local2, x1, 20);
       let mut local3: &Graphics = &Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONLEFTBIG);
       let mut local4: &Bitmap = &bitmap;
      DrawMod.DrawSimple( local3,  local4, 60, 20);
       let mut local5: &Graphics = &Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONRIGHTBIG);
       let mut local6: &Bitmap = &bitmap;
      let mut x2: i32 =  this.Width - 120;
      DrawMod.DrawSimple( local5,  local6, x2, 20);
       let mut local7: &Graphics = &Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONLEFT2BIG);
       let mut local8: &Bitmap = &bitmap;
      DrawMod.DrawSimple( local7,  local8, 0, 20);
       let mut local9: &Graphics = &Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONRIGHT2BIG);
       let mut local10: &Bitmap = &bitmap;
      let mut x3: i32 =  this.Width - 60;
      DrawMod.DrawSimple( local9,  local10, x3, 20);
      if (this.Marc)
      {
        str: String = Strings.UCase(this.prefix + Conversion.Str((object) this.curval) + this.suffix);
        SizeF sizeF1 = SizeF::new();
        SizeF sizeF2 = Expression.MeasureString(str, this.game.MarcFont4);
        DrawMod.DrawTextColouredMarc( Expression, str, this.game.MarcFont4,  Math.Round(((double) this.Width - (double) sizeF2.Width) / 2.0), 2, Color.White);
      }
      else
        DrawMod.DrawTextVic2( Expression, this.prefix + Conversion.Str((object) this.curval) + this.suffix, this.OwnFont, 2, 3, this.game.VicColor2, this.game.VicColor2Shade);
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return this.OwnBitmap;
    }

    pub int HandleMouseUp(int x, int y)
    {
      if (!(this.Scroller | this.clickscroll == 1))
        return -1;
      this.curval =  Math.Round(Conversion.Int((double) (x - 120) / (double) (this.Width - 264) * (double) this.maxval));
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

    pub bool MouseMove(int x, int y)
    {
      if (this.clickscroll != 1)
        return false;
      this.clickscroll = 1;
      this.curval =  Math.Round(Conversion.Int((double) (x - 120) / (double) (this.Width - 264) * (double) this.maxval));
      if (this.curval % this.smallchange > 0)
        this.curval -= this.curval % this.smallchange;
      if (this.curval < this.minval)
        this.curval = this.minval;
      if (this.curval > this.maxval)
        this.curval = this.maxval;
      return true;
    }

    pub int Click(int x, int y, let mut b: i32 =  1)
    {
      let mut curval: i32 =  this.curval;
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
          this.curval =  Math.Round(Conversion.Int((double) (x - 120) / (double) (this.Width - 264) * (double) this.maxval));
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
