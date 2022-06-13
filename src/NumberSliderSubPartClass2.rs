// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.NumberSliderSubPartClass2
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
  pub class NumberSliderSubPartClass2 : SubPartClass
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

    pub NumberSliderSubPartClass2(
      GameClass tgame,
      string tprefix,
      string tsuffix,
      int twidth,
      int tminval,
      int tmaxval,
      int startval,
      bool systemfont = false,
      int tsmallchange = 1,
       Bitmap tbackbitmap = null,
      int bbx = -1,
      int bby = -1,
      bool tMarc = false)
      : base(twidth, 40)
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

    pub Bitmap Paint()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
      {
        Expression.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple( Expression,  this.backbitmap, 0, 0);
        Expression.CompositingMode = CompositingMode.SourceOver;
      }
      if ((double) DrawMod.TGame.Data.RuleVar[839] <= 0.0)
        DrawMod.DrawBlock( Expression, 0, 0, this.Width, 20, 0, 0, 0, 128);
      if (DrawMod.TGame.Data.Product == 7)
        DrawMod.DrawBlock( Expression, 0, 20, this.Width, 20, 65, 40, 20,  byte.MaxValue);
      else
        DrawMod.DrawBlock( Expression, 0, 20, this.Width, 20, 50, 70, 125,  byte.MaxValue);
      int num1 = this.Width - 91;
      int num2 = (this.maxval <= 0 ? num1 :  Math.Round(Conversion.Int((double) this.curval / (double) this.maxval * (double) num1))) - 11;
      if (num2 < 0)
        num2 = 0;
       Graphics local1 =  Expression;
      Bitmap bitmap = BitmapStore.GetBitmap(this.game.VSLIDER);
       Bitmap local2 =  bitmap;
      int x1 = 40 + num2;
      DrawMod.DrawSimple( local1,  local2, x1, 20);
       Graphics local3 =  Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONLEFT);
       Bitmap local4 =  bitmap;
      DrawMod.DrawSimple( local3,  local4, 20, 20);
       Graphics local5 =  Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONRIGHT);
       Bitmap local6 =  bitmap;
      int x2 = this.Width - 40;
      DrawMod.DrawSimple( local5,  local6, x2, 20);
       Graphics local7 =  Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONLEFT2);
       Bitmap local8 =  bitmap;
      DrawMod.DrawSimple( local7,  local8, 0, 20);
       Graphics local9 =  Expression;
      bitmap = BitmapStore.GetBitmap(this.game.BUTTONRIGHT2);
       Bitmap local10 =  bitmap;
      int x3 = this.Width - 20;
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
      this.curval =  Math.Round(Conversion.Int((double) (x - 40) / (double) (this.Width - 91) * (double) this.maxval));
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
      this.curval =  Math.Round(Conversion.Int((double) (x - 40) / (double) (this.Width - 91) * (double) this.maxval));
      if (this.curval % this.smallchange > 0)
        this.curval -= this.curval % this.smallchange;
      if (this.curval < this.minval)
        this.curval = this.minval;
      if (this.curval > this.maxval)
        this.curval = this.maxval;
      return true;
    }

    pub int Click(int x, int y, int b = 1)
    {
      int curval = this.curval;
      this.clickscroll = 0;
      if (y > 20)
      {
        if (x < 20)
        {
          if (b == 1)
            this.curval -= this.smallchange * 10;
          if (this.minval > this.curval)
            this.curval = this.minval;
        }
        else if (x < 40)
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
          this.curval =  Math.Round(Conversion.Int((double) (x - 40) / (double) (this.Width - 91) * (double) this.maxval));
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
