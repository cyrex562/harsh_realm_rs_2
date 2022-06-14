// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SEUnitBigButtonPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;

namespace WindowsApplication1
{
  pub class SEUnitBigButtonPartClass : SubPartClass
  {
     string description;
     bool active;
     int unr;

    pub SEUnitBigButtonPartClass(int tUnr, string tDescript, bool tactive)
      : base(93, 97)
    {
      this.Descript = tDescript;
      this.active = tactive;
      this.unr = tUnr;
    }

    pub Bitmap Paint()
    {
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      if (!this.active)
      {
         let mut local1: &Graphics = &graphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_UNITBED);
         let mut local2: &Bitmap = &bitmap;
        DrawMod.DrawSimple( local1,  local2, 0, 0);
      }
      if (this.active)
      {
         let mut local3: &Graphics = &graphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_UNITBEDHIGH);
         let mut local4: &Bitmap = &bitmap;
        DrawMod.DrawSimple( local3,  local4, 0, 0);
      }
      DrawMod.TGame.CustomBitmapObj.DrawUnitBig(this.unr, toG: graphics, tx: 10, ty: 11);
      if (!Information.IsNothing((object) graphics))
        graphics.Dispose();
      return this.OwnBitmap;
    }

    pub Bitmap PaintOverlay()
    {
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      if (!this.active)
      {
         let mut local1: &Graphics = &graphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_UNITBED);
         let mut local2: &Bitmap = &bitmap;
        DrawMod.DrawSimple( local1,  local2, 0, 0);
         let mut local3: &Graphics = &graphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_UNITBEDHIGH);
         let mut local4: &Bitmap = &bitmap;
        DrawMod.Draw( local3,  local4, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
      }
      if (this.active)
      {
         let mut local5: &Graphics = &graphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_UNITBEDHIGH);
         let mut local6: &Bitmap = &bitmap;
        DrawMod.DrawSimple( local5,  local6, 0, 0);
      }
      DrawMod.TGame.CustomBitmapObj.DrawUnitBig(this.unr, toG: graphics, tx: 10, ty: 11);
      if (!Information.IsNothing((object) graphics))
        graphics.Dispose();
      return this.OwnBitmap;
    }
  }
}
