// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SteveButtonPartClass25
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
  public class SteveButtonPartClass25 : SubPartClass
  {
    private int OwnBitmapNr;
    private int colorized;
    private Bitmap backbitmap;

    public SteveButtonPartClass25(
      int tbmpnr,
      int tcolorized = 0,
      string tDescript = "",
      ref Bitmap tBackbitmap = null,
      int bbx = -1,
      int bby = -1)
      : base(25, 25)
    {
      this.OwnBitmapNr = tbmpnr;
      this.colorized = tcolorized;
      this.Descript = tDescript;
      if (Information.IsNothing((object) tBackbitmap))
        return;
      this.backbitmap = new Bitmap(this.OwnBitmap.Width, this.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
      this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics Expression = Graphics.FromImage((Image) this.backbitmap);
      Expression.CompositingMode = CompositingMode.SourceCopy;
      Expression.DrawImage((Image) tBackbitmap, new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), new Rectangle(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
      Expression.CompositingMode = CompositingMode.SourceOver;
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
    }

    public override Bitmap Paint()
    {
      Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
      {
        objGraphics.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple(ref objGraphics, ref this.backbitmap, 0, 0);
        objGraphics.CompositingMode = CompositingMode.SourceOver;
      }
      if (this.colorized == 0)
      {
        ref Graphics local1 = ref objGraphics;
        Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1);
        ref Bitmap local2 = ref bitmap1;
        DrawMod.DrawScaled(ref local1, ref local2, 0, 0, 25, 25);
        ref Graphics local3 = ref objGraphics;
        Bitmap bitmap2 = BitmapStore.GetBitmap(this.OwnBitmapNr);
        ref Bitmap local4 = ref bitmap2;
        DrawMod.DrawScaled(ref local3, ref local4, 1, 1, 25, 25);
      }
      if (!Information.IsNothing((object) objGraphics))
      {
        objGraphics.Dispose();
        objGraphics = (Graphics) null;
      }
      return this.OwnBitmap;
    }

    public override Bitmap PaintOverlay()
    {
      Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
      {
        objGraphics.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple(ref objGraphics, ref this.backbitmap, 0, 0);
        objGraphics.CompositingMode = CompositingMode.SourceOver;
      }
      if (this.colorized == 0)
      {
        ref Graphics local1 = ref objGraphics;
        Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1b);
        ref Bitmap local2 = ref bitmap1;
        DrawMod.DrawScaled(ref local1, ref local2, 0, 0, 25, 25);
        ref Graphics local3 = ref objGraphics;
        Bitmap bitmap2 = BitmapStore.GetBitmap(this.OwnBitmapNr);
        ref Bitmap local4 = ref bitmap2;
        DrawMod.DrawScaled(ref local3, ref local4, 1, 1, 25, 25);
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
