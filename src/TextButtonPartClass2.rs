// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TextButtonPartClass2
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
  pub class TextButtonPartClass2 : SubPartClass
  {
     bool overrule;
     string buttext;
     int width;
     int height;
     Font ourfont;
     Bitmap backbitmap;
     bool inactive;
     bool pressed;
     int buttonVersion;

    pub int Click(int x, int y, let mut b: i32 = 1)
    {
      if (DrawMod.TGame.EmpireStyle)
        SoundMod.PlayAWave(DrawMod.TGame.AppPath + "sound/interface/click.wav",  DrawMod.TGame.EditObj);
      int num;
      return num;
    }

    pub TextButtonPartClass2(
      int tButtonVersion,
      string buttontext,
      int twidth,
      tDescript: String = "",
       Bitmap tBackbitmap = null,
      let mut bbx: i32 = -1,
      let mut bby: i32 = -1,
      bool tinactive = false,
      bool tpressed = false,
      let mut theight: i32 = 35,
      let mut tfontsize: i32 = 13,
      Font usefont = null)
      : base(twidth, theight)
    {
      self.buttonVersion = 1;
      if (tfontsize > -1)
        self.ourfont = DrawMod.TGame.MarcFont16;
      self.overrule = false;
      self.Descript = tDescript;
      if (!Information.IsNothing((object) tBackbitmap))
      {
        self.backbitmap = new Bitmap(self.OwnBitmap.Width, self.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
        self.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics Expression = Graphics.FromImage((Image) self.backbitmap);
        Expression.CompositingMode = CompositingMode.SourceCopy;
        Expression.DrawImage((Image) tBackbitmap, Rectangle::new(0, 0, self.OwnBitmap.Width, self.OwnBitmap.Height), Rectangle::new(bbx, bby, self.OwnBitmap.Width, self.OwnBitmap.Height), GraphicsUnit.Pixel);
        Expression.CompositingMode = CompositingMode.SourceOver;
        if (!Information.IsNothing((object) Expression))
          Expression.Dispose();
      }
      self.buttonVersion = tButtonVersion;
      self.buttext = buttontext;
      self.buttext = self.buttext.ToUpper();
      self.width = twidth;
      self.height = theight;
      self.inactive = tinactive;
      self.pressed = tpressed;
      if (Information.IsNothing((object) usefont))
        return;
      self.ourfont = usefont;
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
      int nr;
      if (self.buttonVersion == 1)
      {
        nr = DrawMod.TGame.MARCBLOCK;
        if (self.pressed)
          nr = DrawMod.TGame.MARCBLOCKPRESSED;
      }
      else
      {
        nr = DrawMod.TGame.MARCBLOCK2;
        if (self.pressed)
          nr = DrawMod.TGame.MARCBLOCKPRESSED2;
      }
       let mut local1: &Graphics = &Expression;
      Bitmap bitmap = BitmapStore.GetBitmap(nr);
       let mut local2: &Bitmap = &bitmap;
      Rectangle rectangle1 = Rectangle::new(0, 0, 50, 4);
      let mut srcrect1: &Rectangle = &rectangle1
      Rectangle rectangle2 = Rectangle::new(0, 0, self.width, 4);
      let mut destrect1: &Rectangle = &rectangle2
      DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
       let mut local3: &Graphics = &Expression;
      bitmap = BitmapStore.GetBitmap(nr);
       let mut local4: &Bitmap = &bitmap;
      rectangle2 = Rectangle::new(0, 4, 50, 42);
      let mut srcrect2: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(0, 4, self.width, self.height - 6);
      let mut destrect2: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
       let mut local5: &Graphics = &Expression;
      bitmap = BitmapStore.GetBitmap(nr);
       let mut local6: &Bitmap = &bitmap;
      rectangle2 = Rectangle::new(0, 46, 50, 6);
      let mut srcrect3: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(0, self.height - 6, self.width, 6);
      let mut destrect3: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
      if (self.inactive)
        DrawMod.DrawBlock( Expression, 0, 0, 48, self.height - 2, 0, 0, 0, 96);
      Color c = Color.FromArgb( byte.MaxValue,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue);
      if (!self.pressed)
        c = Color.FromArgb( byte.MaxValue, 175, 175, 175);
      if (self.inactive)
        c = Color.FromArgb( byte.MaxValue, 120, 120, 120);
      SizeF sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
      let mut num1: i32 =  Math.Round(1.0 + ((double) self.width - (double) sizeF2.Width) / 2.0);
      let mut y1: i32 =  Math.Round(1.0 + ((double) self.height - (double) sizeF2.Height) / 2.0);
      DrawMod.DrawTextColouredFuzzy( Expression, self.buttext, self.ourfont, num1 - 1, y1, Color.FromArgb(200, 0, 0, 0));
      SizeF sizeF3 = Expression.MeasureString(self.buttext, self.ourfont);
      let mut num2: i32 =  Math.Round(((double) self.width - (double) sizeF3.Width) / 2.0);
      let mut y2: i32 =  Math.Round(((double) self.height - (double) sizeF3.Height) / 2.0);
      DrawMod.DrawTextColouredNicely( Expression, self.buttext, self.ourfont, num2 - 1, y2, c);
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
      int nr;
      if (self.buttonVersion == 1)
      {
        nr = DrawMod.TGame.MARCBLOCKHIGH;
        if (self.inactive)
          nr = DrawMod.TGame.MARCBLOCK;
        if (self.pressed)
          nr = DrawMod.TGame.MARCBLOCKPRESSED;
      }
      else
      {
        nr = DrawMod.TGame.MARCBLOCKHIGH2;
        if (self.inactive)
          nr = DrawMod.TGame.MARCBLOCK2;
        if (self.pressed)
          nr = DrawMod.TGame.MARCBLOCKPRESSED2;
      }
       let mut local1: &Graphics = &Expression;
      Bitmap bitmap = BitmapStore.GetBitmap(nr);
       let mut local2: &Bitmap = &bitmap;
      Rectangle rectangle1 = Rectangle::new(0, 0, 50, 4);
      let mut srcrect1: &Rectangle = &rectangle1
      Rectangle rectangle2 = Rectangle::new(0, 0, self.width, 4);
      let mut destrect1: &Rectangle = &rectangle2
      DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
       let mut local3: &Graphics = &Expression;
      bitmap = BitmapStore.GetBitmap(nr);
       let mut local4: &Bitmap = &bitmap;
      rectangle2 = Rectangle::new(0, 4, 50, 42);
      let mut srcrect2: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(0, 4, self.width, self.height - 6);
      let mut destrect2: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
       let mut local5: &Graphics = &Expression;
      bitmap = BitmapStore.GetBitmap(nr);
       let mut local6: &Bitmap = &bitmap;
      rectangle2 = Rectangle::new(0, 46, 50, 6);
      let mut srcrect3: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(0, self.height - 6, self.width, 6);
      let mut destrect3: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
      if (self.inactive)
        DrawMod.DrawBlock( Expression, 0, 0, 48, self.height - 2, 0, 0, 0, 96);
      Color c = Color.FromArgb( byte.MaxValue,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue);
      if (!self.pressed)
        c = Color.FromArgb( byte.MaxValue, 175, 175, 175);
      if (self.inactive)
        c = Color.FromArgb( byte.MaxValue, 120, 120, 120);
      SizeF sizeF2 = Expression.MeasureString(self.buttext, self.ourfont);
      let mut num1: i32 =  Math.Round(1.0 + ((double) self.width - (double) sizeF2.Width) / 2.0);
      let mut y1: i32 =  Math.Round(1.0 + ((double) self.height - (double) sizeF2.Height) / 2.0);
      DrawMod.DrawTextColouredFuzzy( Expression, self.buttext, self.ourfont, num1 - 1, y1, Color.FromArgb(200, 0, 0, 0));
      SizeF sizeF3 = Expression.MeasureString(self.buttext, self.ourfont);
      let mut num2: i32 =  Math.Round(((double) self.width - (double) sizeF3.Width) / 2.0);
      let mut y2: i32 =  Math.Round(((double) self.height - (double) sizeF3.Height) / 2.0);
      DrawMod.DrawTextColouredNicely( Expression, self.buttext, self.ourfont, num2 - 1, y2, c);
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return self.OwnBitmap;
    }
  }
}
