// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ATTextPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class ATTextPartClass : SubPartClass
  {
     Font OwnFont;
     string OwnText;
     bool CenterIt;
     int OColor;
     bool BlackBack;
     bool Outline;
     int progress;
     bool Marc;

    pub ATTextPartClass(
      string txt,
      Font f,
      int w,
      int h,
      bool tcenterit,
      let mut tcolor: i32 =  -1,
      tDescript: String = "",
      bool tBlackBack = false,
      bool toutline = false,
      let mut tProgress: i32 =  -1,
      bool tMarc = false)
      : base(w, h)
    {
      this.OwnFont = f;
      this.Marc = tMarc;
      this.CenterIt = tcenterit;
      this.OwnText = txt;
      this.OColor = tcolor;
      this.Descript = tDescript;
      this.BlackBack = tBlackBack;
      this.Outline = toutline;
      this.progress = tProgress;
    }

    pub Bitmap Paint()
    {
      SizeF sizeF1 = SizeF::new();
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      SizeF sizeF2 = Expression.MeasureString(this.OwnText, this.OwnFont);
      int x;
      int y;
      if ((double) sizeF2.Width <= (double) this.OwnBitmap.Width)
      {
        if (this.CenterIt)
          x = (int) Math.Round((double) Conversion.Int((float) (((double) this.OwnBitmap.Width - (double) sizeF2.Width) / 2.0)));
        y = (int) Math.Round((double) Conversion.Int((float) (((double) this.OwnBitmap.Height - (double) sizeF2.Height) / 2.0)));
      }
      sizeF1 = SizeF::new();
      if (this.BlackBack)
      {
        if (!this.Marc)
        {
          DrawMod.DrawBlock(ref Expression, 0, 0, this.OwnBitmap.Width - 1, this.OwnBitmap.Height - 1, (int) DrawMod.TGame.VicColor4.R, (int) DrawMod.TGame.VicColor4.G, (int) DrawMod.TGame.VicColor4.B, (int) DrawMod.TGame.VicColor4.A);
          if (this.progress > -1)
            DrawMod.DrawBlock(ref Expression, 0, 0, (int) Math.Round((double) this.OwnBitmap.Width * ((double) this.progress / 100.0)), this.OwnBitmap.Height - 1, (int) byte.MaxValue, 0, 0, 105);
        }
        else
        {
          if (this.progress > -1)
            DrawMod.DrawBlock(ref Expression, 5, 5, (int) Math.Round((double) (this.OwnBitmap.Width - 10) * ((double) this.progress / 100.0)), this.OwnBitmap.Height - 10 - 1, (int) byte.MaxValue, 0, 0, 105);
          DrawMod.DrawFrame(ref this.OwnBitmap, ref this.OwnBitmap, ref Expression, 0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height, -1, -1);
        }
      }
      DrawMod.DrawTextVic2(ref Expression, this.OwnText, this.OwnFont, x, y, DrawMod.TGame.VicColor2, DrawMod.TGame.VicColor2Shade);
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }
  }
}
