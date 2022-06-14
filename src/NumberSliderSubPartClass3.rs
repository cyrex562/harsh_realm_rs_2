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
  pub class NumberSliderSubPartClass3 : SubPartClass
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

    pub NumberSliderSubPartClass3(
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
      let mut bby: i32 =  -1)
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
        graphics.DrawImage((Image) tbackbitmap, Rectangle::new(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), Rectangle::new(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
        graphics.CompositingMode = CompositingMode.SourceOver;
      }
      this.bx = bbx;
      this.by = bby;
      this.smallchange = tsmallchange;
      this.game = tgame;
      if (!systemfont)
        this.OwnFont = Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel);
      else
        this.OwnFont = Font::new("Courier New", 14f, FontStyle.Regular, GraphicsUnit.Pixel);
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
      let mut num1: i32 =   Math.Round(Conversion.Int((double) this.curval / (double) this.maxval * (double) (this.Width - 291)));
      DrawMod.DrawSteveBlock( Expression, 200, 0, this.Width - 201, 20);
      let mut num2: i32 =  num1 - 11;
      if (num2 < 0)
        num2 = 0;
       let mut local1: &Graphics = &Expression;
      Bitmap bitmap = BitmapStore.GetBitmap(this.game.VSLIDER);
       let mut local2: &Bitmap = &bitmap;
      let mut x1: i32 =  240 + num2;
      DrawMod.DrawSimple( local1,  local2, x1, 0);
       let mut local3: &Graphics = &Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONLEFT);
       let mut local4: &Bitmap = &bitmap;
      DrawMod.DrawSimple( local3,  local4, 220, 0);
       let mut local5: &Graphics = &Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONRIGHT);
       let mut local6: &Bitmap = &bitmap;
      let mut x2: i32 =  this.Width - 40;
      DrawMod.DrawSimple( local5,  local6, x2, 0);
       let mut local7: &Graphics = &Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONLEFT2);
       let mut local8: &Bitmap = &bitmap;
      DrawMod.DrawSimple( local7,  local8, 200, 0);
       let mut local9: &Graphics = &Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONRIGHT2);
       let mut local10: &Bitmap = &bitmap;
      let mut x3: i32 =  this.Width - 20;
      DrawMod.DrawSimple( local9,  local10, x3, 0);
      DrawMod.DrawSteveBlock( Expression, 0, 0, 180, 20);
      SizeF sizeF1 = SizeF::new();
      SizeF sizeF2 = Expression.MeasureString(this.prefix + Conversion.Str((object) this.curval) + this.suffix, this.OwnFont);
      DrawMod.DrawText( Expression, this.prefix + Conversion.Str((object) this.curval) + this.suffix, this.OwnFont,  Math.Round((double) (172f - sizeF2.Width)), 0);
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return this.OwnBitmap;
    }

    pub int Click(int x, int y, let mut b: i32 =  1)
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
        this.curval =  Math.Round(Conversion.Int((double) (x - 240) / (double) (this.Width - 291) * (double) this.maxval));
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
