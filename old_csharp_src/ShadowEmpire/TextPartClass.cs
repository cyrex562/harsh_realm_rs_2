// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TextPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class TextPartClass : SubPartClass
  {
    private Font OwnFont;
    private string OwnText;
    private bool CenterIt;
    private int OColor;
    private bool BlackBack;
    private bool Outline;
    private int progress;
    private bool Marc;

    public TextPartClass(
      string txt,
      Font f,
      int w,
      int h,
      bool tcenterit,
      int tcolor = -1,
      string tDescript = "",
      bool tBlackBack = false,
      bool toutline = false,
      int tProgress = -1,
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
      this.oldStyle = true;
    }

    public override Bitmap Paint()
    {
      SizeF sizeF1 = new SizeF();
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      int x;
      int y;
      if (this.CenterIt)
      {
        SizeF sizeF2 = Expression.MeasureString(this.OwnText, this.OwnFont);
        if ((double) sizeF2.Width <= (double) this.OwnBitmap.Width)
        {
          x = (int) Math.Round((double) Conversion.Int((float) (((double) this.OwnBitmap.Width - (double) sizeF2.Width) / 2.0)));
          y = (int) Math.Round((double) Conversion.Int((float) (((double) this.OwnBitmap.Height - (double) sizeF2.Height) / 2.0)));
        }
        sizeF1 = new SizeF();
      }
      if (this.BlackBack)
      {
        if (!this.Marc)
        {
          DrawMod.DrawBlock(ref Expression, 0, 0, this.OwnBitmap.Width - 1, this.OwnBitmap.Height - 1, 0, 0, 0, 175);
          DrawMod.drawLine(ref Expression, 2, this.OwnBitmap.Height - 1, this.OwnBitmap.Width - 1, this.OwnBitmap.Height - 1, 200, 220, 120, (int) byte.MaxValue);
          DrawMod.drawLine(ref Expression, this.OwnBitmap.Width - 1, 3, this.OwnBitmap.Width - 1, this.OwnBitmap.Height - 1, 200, 220, 120, (int) byte.MaxValue);
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
      if (!this.Marc)
      {
        if (!this.Outline)
        {
          if (this.OColor == -1)
            DrawMod.DrawText(ref Expression, this.OwnText, this.OwnFont, x, y);
          else if (this.OColor == 1)
            DrawMod.DrawTextColoured(ref Expression, this.OwnText, this.OwnFont, x, y, Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, 0));
          else if (this.OColor == 2)
            DrawMod.DrawTextColoured(ref Expression, this.OwnText, this.OwnFont, x, y, Color.FromArgb((int) byte.MaxValue, 0, 0, 0));
          else if (this.OColor == 0)
            DrawMod.DrawTextColoured(ref Expression, this.OwnText, this.OwnFont, x, y, Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
        else
          DrawMod.DrawTextOutline(ref Expression, this.OwnText, this.OwnFont, x, y);
      }
      else
        DrawMod.DrawTextColouredMarc(ref Expression, this.OwnText, this.OwnFont, x, y, Color.White);
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }
  }
}
