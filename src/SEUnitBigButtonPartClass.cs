// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SEUnitBigButtonPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;

namespace WindowsApplication1
{
  public class SEUnitBigButtonPartClass : SubPartClass
  {
    private string description;
    private bool active;
    private int unr;

    public SEUnitBigButtonPartClass(int tUnr, string tDescript, bool tactive)
      : base(93, 97)
    {
      this.Descript = tDescript;
      this.active = tactive;
      this.unr = tUnr;
    }

    public override Bitmap Paint()
    {
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      if (!this.active)
      {
        ref Graphics local1 = ref graphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_UNITBED);
        ref Bitmap local2 = ref bitmap;
        DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
      }
      if (this.active)
      {
        ref Graphics local3 = ref graphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_UNITBEDHIGH);
        ref Bitmap local4 = ref bitmap;
        DrawMod.DrawSimple(ref local3, ref local4, 0, 0);
      }
      DrawMod.TGame.CustomBitmapObj.DrawUnitBig(this.unr, toG: graphics, tx: 10, ty: 11);
      if (!Information.IsNothing((object) graphics))
        graphics.Dispose();
      return this.OwnBitmap;
    }

    public override Bitmap PaintOverlay()
    {
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      if (!this.active)
      {
        ref Graphics local1 = ref graphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_UNITBED);
        ref Bitmap local2 = ref bitmap;
        DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
        ref Graphics local3 = ref graphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_UNITBEDHIGH);
        ref Bitmap local4 = ref bitmap;
        DrawMod.Draw(ref local3, ref local4, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
      }
      if (this.active)
      {
        ref Graphics local5 = ref graphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_UNITBEDHIGH);
        ref Bitmap local6 = ref bitmap;
        DrawMod.DrawSimple(ref local5, ref local6, 0, 0);
      }
      DrawMod.TGame.CustomBitmapObj.DrawUnitBig(this.unr, toG: graphics, tx: 10, ty: 11);
      if (!Information.IsNothing((object) graphics))
        graphics.Dispose();
      return this.OwnBitmap;
    }
  }
}
