// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SmallTextButtonPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace WindowsApplication1
{
  pub class SmallTextButtonPartClass : SubPartClass
  {
     bool overrule;
     string buttext;
     int width;
     int height;
     Font ourfont;
     Font ourfont2;
     Bitmap backbitmap;
     bool inactive;
     bool red;
     bool tuseshadow;
     bool marcStyle;
     string extraS;

    pub int Click(int x, int y, let mut b: i32 = 1)
    {
      if (DrawMod.TGame.EmpireStyle)
        SoundMod.PlayAWave(DrawMod.TGame.AppPath + "sound/interface/click.wav",  DrawMod.TGame.EditObj);
      int num;
      return num;
    }

    pub SmallTextButtonPartClass(
      string buttontext,
      int twidth,
      tDescript: String = "",
       Bitmap tBackbitmap = null,
      let mut bbx: i32 = -1,
      let mut bby: i32 = -1,
      bool tinactive = false,
      let mut theight: i32 = 25)
      : base(twidth, theight)
    {
      self.ourfont = Font::new(DrawMod.TGame.FontCol.Families[1], 12f, FontStyle.Bold, GraphicsUnit.Pixel);
      self.overrule = false;
      self.Descript = tDescript;
      if (!Information.IsNothing((object) tBackbitmap))
      {
        self.backbitmap = new Bitmap(self.OwnBitmap.Width, self.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
        self.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics Expression = Graphics.FromImage((Image) self.backbitmap);
        Expression.CompositingMode = CompositingMode.SourceCopy;
        Expression.DrawImage((Image) tBackbitmap, new Rectangle(0, 0, self.OwnBitmap.Width, self.OwnBitmap.Height), new Rectangle(bbx, bby, self.OwnBitmap.Width, self.OwnBitmap.Height), GraphicsUnit.Pixel);
        Expression.CompositingMode = CompositingMode.SourceOver;
        if (!Information.IsNothing((object) Expression))
          Expression.Dispose();
      }
      self.buttext = buttontext;
      self.width = twidth;
      self.height = theight;
      self.inactive = tinactive;
    }

    pub void SubDispose()
    {
      if (Information.IsNothing((object) self.backbitmap))
        return;
      self.backbitmap.Dispose();
      self.backbitmap = (Bitmap) null;
    }

    pub Bitmap Paint()
    {
      SizeF sizeF1 = SizeF::new();
      Graphics Expression = Graphics.FromImage((Image) self.OwnBitmap);
      if (!Information.IsNothing((object) self.backbitmap))
      {
        Expression.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple( Expression,  self.backbitmap, 0, 0);
        Expression.CompositingMode = CompositingMode.SourceOver;
      }
      Expression.SmoothingMode = SmoothingMode.AntiAlias;
      Expression.TextRenderingHint = TextRenderingHint.AntiAlias;
      Expression.TextContrast = 1;
      if (self.inactive)
      {
         Graphics local1 =  Expression;
        Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALLHIGH);
         Bitmap local2 =  bitmap1;
        Rectangle rectangle1 = new Rectangle(7, 0, 7, 25);
        Rectangle srcrect1 = rectangle1;
        Rectangle rectangle2 = new Rectangle(7, 0, self.width - 14, self.height);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
         Graphics local3 =  Expression;
        Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALLHIGH);
         Bitmap local4 =  bitmap2;
        rectangle2 = new Rectangle(0, 0, 7, 25);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(0, 0, 7, self.height);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
         Graphics local5 =  Expression;
        Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALLHIGH);
         Bitmap local6 =  bitmap3;
        rectangle2 = new Rectangle(19, 0, 7, 25);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(self.width - 7, 0, 7, self.height);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
      }
      else
      {
         Graphics local7 =  Expression;
        Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALL);
         Bitmap local8 =  bitmap4;
        Rectangle rectangle3 = new Rectangle(7, 0, 7, 25);
        Rectangle srcrect4 = rectangle3;
        Rectangle rectangle4 = new Rectangle(7, 0, self.width - 14, self.height);
        Rectangle destrect4 = rectangle4;
        DrawMod.DrawSimplePart2( local7,  local8, srcrect4, destrect4);
         Graphics local9 =  Expression;
        Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALL);
         Bitmap local10 =  bitmap5;
        rectangle3 = new Rectangle(0, 0, 7, 25);
        Rectangle srcrect5 = rectangle3;
        rectangle4 = new Rectangle(0, 0, 7, self.height);
        Rectangle destrect5 = rectangle4;
        DrawMod.DrawSimplePart2( local9,  local10, srcrect5, destrect5);
         Graphics local11 =  Expression;
        Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALL);
         Bitmap local12 =  bitmap6;
        rectangle3 = new Rectangle(19, 0, 7, 25);
        Rectangle srcrect6 = rectangle3;
        rectangle4 = new Rectangle(self.width - 7, 0, 7, self.height);
        Rectangle destrect6 = rectangle4;
        DrawMod.DrawSimplePart2( local11,  local12, srcrect6, destrect6);
      }
      SizeF sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
      let mut x1: i32 =  Math.Round(2.0 + ((double) self.width - (double) sizeF2.Width) / 2.0);
      let mut y1: i32 =  Math.Round(2.0 + ((double) self.height - (double) sizeF2.Height) / 2.0);
      DrawMod.DrawTextColouredFuzzy( Expression, self.buttext, self.ourfont, x1, y1, Color.FromArgb(200, 0, 0, 0));
      SizeF sizeF3 = Expression.MeasureString(self.buttext, self.ourfont);
      let mut x2: i32 =  Math.Round(((double) self.width - (double) sizeF3.Width) / 2.0);
      let mut y2: i32 =  Math.Round(((double) self.height - (double) sizeF3.Height) / 2.0);
      DrawMod.DrawTextColouredNicely( Expression, self.buttext, self.ourfont, x2, y2, Color.White);
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return self.OwnBitmap;
    }

    pub Bitmap PaintOverlay()
    {
      SizeF sizeF1 = SizeF::new();
      if (self.inactive)
        return self.Paint();
      Graphics Expression = Graphics.FromImage((Image) self.OwnBitmap);
      if (!Information.IsNothing((object) self.backbitmap))
        DrawMod.DrawSimple( Expression,  self.backbitmap, 0, 0);
      Expression.SmoothingMode = SmoothingMode.AntiAlias;
      Expression.TextRenderingHint = TextRenderingHint.AntiAlias;
      Expression.TextContrast = 1;
       Graphics local1 =  Expression;
      Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALLHIGH);
       Bitmap local2 =  bitmap;
      Rectangle rectangle1 = new Rectangle(7, 0, 7, 25);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(7, 0, self.width - 14, self.height);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
       Graphics local3 =  Expression;
      bitmap = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALLHIGH);
       Bitmap local4 =  bitmap;
      rectangle2 = new Rectangle(0, 0, 7, 25);
      Rectangle srcrect2 = rectangle2;
      rectangle1 = new Rectangle(0, 0, 7, self.height);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
       Graphics local5 =  Expression;
      bitmap = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALLHIGH);
       Bitmap local6 =  bitmap;
      rectangle2 = new Rectangle(19, 0, 7, 25);
      Rectangle srcrect3 = rectangle2;
      rectangle1 = new Rectangle(self.width - 7, 0, 7, self.height);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
      SizeF sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
      let mut x1: i32 =  Math.Round(2.0 + ((double) self.width - (double) sizeF2.Width) / 2.0);
      let mut y1: i32 =  Math.Round(2.0 + ((double) self.height - (double) sizeF2.Height) / 2.0);
      DrawMod.DrawTextColouredFuzzy( Expression, self.buttext, self.ourfont, x1, y1, Color.FromArgb(200, 0, 0, 0));
      SizeF sizeF3 = Expression.MeasureString(self.buttext, self.ourfont);
      let mut x2: i32 =  Math.Round(((double) self.width - (double) sizeF3.Width) / 2.0);
      let mut y2: i32 =  Math.Round(((double) self.height - (double) sizeF3.Height) / 2.0);
      DrawMod.DrawTextColouredNicely( Expression, self.buttext, self.ourfont, x2, y2, Color.White);
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return self.OwnBitmap;
    }
  }
}
