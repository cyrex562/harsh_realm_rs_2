// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.CircleButtonPartClass
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
  pub class CircleButtonPartClass : SubPartClass
  {
     int OwnBitmapNr;
     Rectangle useRect;
     Rectangle bmpRect;
     Color useCol;
     Color useColHigh;
     Bitmap backbitmap;
     int drawArtCodeSfType;
     int drawArtCodePpl;

    pub void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    pub CircleButtonPartClass(
      int tbmpnr,
      Rectangle tbmpRect,
      Rectangle trect,
      Color tUseCol,
      Color tUseColHigh,
      tDescript: String = "",
      ref Bitmap tBackbitmap = null,
      let mut bbx: i32 =  -1,
      let mut bby: i32 =  -1,
      let mut tArtCodeSfType: i32 =  -1,
      let mut tArtCodePeople: i32 =  -1)
      : base(trect.Width, trect.Height)
    {
      this.OwnBitmapNr = tbmpnr;
      this.Descript = tDescript;
      this.useRect = trect;
      this.useCol = tUseCol;
      this.drawArtCodePpl = tArtCodePeople;
      this.drawArtCodeSfType = tArtCodeSfType;
      this.bmpRect = tbmpRect;
      this.useColHigh = tUseColHigh;
      if (Information.IsNothing((object) tBackbitmap))
        return;
      this.backbitmap = new Bitmap(this.OwnBitmap.Width, this.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
      this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics Expression = Graphics.FromImage((Image) this.backbitmap);
      Expression.CompositingMode = CompositingMode.SourceCopy;
      Expression.DrawImage((Image) tBackbitmap, Rectangle::new(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), Rectangle::new(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
      Expression.CompositingMode = CompositingMode.SourceOver;
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
    }

    pub Bitmap Paint()
    {
      Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
      {
        objGraphics.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple(ref objGraphics, ref this.backbitmap, 0, 0);
        objGraphics.CompositingMode = CompositingMode.SourceOver;
      }
      let mut smoothingMode: i32 =  (int) objGraphics.SmoothingMode;
      objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
      DrawMod.DrawFilledCircle(ref objGraphics, 0, 0, this.useRect.Width, this.useRect.Height, (int) this.useCol.R, (int) this.useCol.G, (int) this.useCol.B, (int) this.useCol.A);
      objGraphics.SmoothingMode = (SmoothingMode) smoothingMode;
      let mut x: i32 =  (int) Math.Round((double) (this.useRect.Width - this.bmpRect.Width) / 2.0);
      let mut y: i32 =  (int) Math.Round((double) (this.useRect.Height - this.bmpRect.Height) / 2.0);
      if (this.drawArtCodePpl > -1)
      {
        let mut num1: i32 =  (int) Math.Round((double) (this.useRect.Width - 35) / 2.0);
        let mut num2: i32 =  (int) Math.Round((double) (this.useRect.Height - 17) / 2.0);
        ref Graphics local1 = ref objGraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
        ref Bitmap local2 = ref bitmap;
        let mut drawArtCodeSfType: i32 =  this.drawArtCodeSfType;
        let mut drawArtCodePpl: i32 =  this.drawArtCodePpl;
        let mut tx: i32 =  num1;
        let mut ty: i32 =  num2;
        DrawMod.DrawWithArtCode(ref local1, ref local2, 34, 17, drawArtCodeSfType, drawArtCodePpl, tx, ty, -1, -1);
      }
      else
      {
        ref Graphics local3 = ref objGraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
        ref Bitmap local4 = ref bitmap;
        Rectangle bmpRect = this.bmpRect;
        Rectangle destrect = Rectangle::new(x, y, this.bmpRect.Width, this.bmpRect.Height);
        DrawMod.DrawSimplePart2(ref local3, ref local4, bmpRect, destrect);
      }
      if (!Information.IsNothing((object) objGraphics))
      {
        objGraphics.Dispose();
        objGraphics = (Graphics) null;
      }
      return this.OwnBitmap;
    }

    pub Bitmap PaintOverlay()
    {
      Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
      {
        objGraphics.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple(ref objGraphics, ref this.backbitmap, 0, 0);
        objGraphics.CompositingMode = CompositingMode.SourceOver;
      }
      let mut smoothingMode: i32 =  (int) objGraphics.SmoothingMode;
      objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
      DrawMod.DrawFilledCircle(ref objGraphics, 0, 0, this.useRect.Width, this.useRect.Height, (int) this.useColHigh.R, (int) this.useColHigh.G, (int) this.useColHigh.B, (int) this.useColHigh.A);
      objGraphics.SmoothingMode = (SmoothingMode) smoothingMode;
      let mut x: i32 =  (int) Math.Round((double) (this.useRect.Width - this.bmpRect.Width) / 2.0);
      let mut y: i32 =  (int) Math.Round((double) (this.useRect.Height - this.bmpRect.Height) / 2.0);
      if (this.drawArtCodePpl > -1)
      {
        let mut num1: i32 =  (int) Math.Round((double) (this.useRect.Width - 35) / 2.0);
        let mut num2: i32 =  (int) Math.Round((double) (this.useRect.Height - 17) / 2.0);
        ref Graphics local1 = ref objGraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
        ref Bitmap local2 = ref bitmap;
        let mut drawArtCodeSfType: i32 =  this.drawArtCodeSfType;
        let mut drawArtCodePpl: i32 =  this.drawArtCodePpl;
        let mut tx: i32 =  num1;
        let mut ty: i32 =  num2;
        DrawMod.DrawWithArtCode(ref local1, ref local2, 34, 17, drawArtCodeSfType, drawArtCodePpl, tx, ty, -1, -1);
      }
      else
      {
        ref Graphics local3 = ref objGraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
        ref Bitmap local4 = ref bitmap;
        Rectangle bmpRect = this.bmpRect;
        Rectangle destrect = Rectangle::new(x, y, this.bmpRect.Width, this.bmpRect.Height);
        DrawMod.DrawSimplePart2(ref local3, ref local4, bmpRect, destrect);
      }
      if (!Information.IsNothing((object) objGraphics))
      {
        objGraphics.Dispose();
        objGraphics = (Graphics) null;
      }
      return this.OwnBitmap;
    }
  }
}
