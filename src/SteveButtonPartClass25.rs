﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SteveButtonPartClass25
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingSystem.Drawing;
// usingSystem.Drawing.Drawing2D;
// usingSystem.Drawing.Imaging;

namespace WindowsApplication1
{
  pub class SteveButtonPartClass25 : SubPartClass
  {
     int OwnBitmapNr;
     int colorized;
     Bitmap backbitmap;

    pub SteveButtonPartClass25(
      int tbmpnr,
      let mut tcolorized: i32 = 0,
      tDescript: String = "",
       Bitmap tBackbitmap = null,
      let mut bbx: i32 = -1,
      let mut bby: i32 = -1)
      : base(25, 25)
    {
      self.OwnBitmapNr = tbmpnr;
      self.colorized = tcolorized;
      self.Descript = tDescript;
      if (Information.IsNothing( tBackbitmap))
        return;
      self.backbitmap = new Bitmap(self.OwnBitmap.Width, self.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
      self.backbitmap.SetResolution( DrawMod.DPIx,  DrawMod.DPIy);
      Graphics Expression = Graphics.FromImage((Image) self.backbitmap);
      Expression.CompositingMode = CompositingMode.SourceCopy;
      Expression.DrawImage((Image) tBackbitmap, Rectangle::new(0, 0, self.OwnBitmap.Width, self.OwnBitmap.Height), Rectangle::new(bbx, bby, self.OwnBitmap.Width, self.OwnBitmap.Height), GraphicsUnit.Pixel);
      Expression.CompositingMode = CompositingMode.SourceOver;
      if (Information.IsNothing( Expression))
        return;
      Expression.Dispose();
    }

    pub Bitmap Paint()
    {
      Graphics objGraphics = Graphics.FromImage((Image) self.OwnBitmap);
      if (!Information.IsNothing( self.backbitmap))
      {
        objGraphics.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple( objGraphics,  self.backbitmap, 0, 0);
        objGraphics.CompositingMode = CompositingMode.SourceOver;
      }
      if (self.colorized == 0)
      {
         let mut local1: &Graphics = &objGraphics;
        Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1);
         let mut local2: &Bitmap = &bitmap1;
        DrawMod.DrawScaled( local1,  local2, 0, 0, 25, 25);
         let mut local3: &Graphics = &objGraphics;
        Bitmap bitmap2 = BitmapStore.GetBitmap(self.OwnBitmapNr);
         let mut local4: &Bitmap = &bitmap2;
        DrawMod.DrawScaled( local3,  local4, 1, 1, 25, 25);
      }
      if (!Information.IsNothing( objGraphics))
      {
        objGraphics.Dispose();
        objGraphics = (Graphics) null;
      }
      return self.OwnBitmap;
    }

    pub Bitmap PaintOverlay()
    {
      Graphics objGraphics = Graphics.FromImage((Image) self.OwnBitmap);
      if (!Information.IsNothing( self.backbitmap))
      {
        objGraphics.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple( objGraphics,  self.backbitmap, 0, 0);
        objGraphics.CompositingMode = CompositingMode.SourceOver;
      }
      if (self.colorized == 0)
      {
         let mut local1: &Graphics = &objGraphics;
        Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1b);
         let mut local2: &Bitmap = &bitmap1;
        DrawMod.DrawScaled( local1,  local2, 0, 0, 25, 25);
         let mut local3: &Graphics = &objGraphics;
        Bitmap bitmap2 = BitmapStore.GetBitmap(self.OwnBitmapNr);
         let mut local4: &Bitmap = &bitmap2;
        DrawMod.DrawScaled( local3,  local4, 1, 1, 25, 25);
      }
      if (!Information.IsNothing( objGraphics))
      {
        objGraphics.Dispose();
        objGraphics = (Graphics) null;
      }
      return self.OwnBitmap;
    }
  }
}
