// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleButtonPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
  public class SimpleButtonPartClass : SubPartClass
  {
    private int OwnBitmapNr;
    private Bitmap backbitmap;

    public override void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    public SimpleButtonPartClass(
      int tbmpnr,
      string tDescript,
      ref Bitmap tBackbitmap,
      int bbx,
      int bby)
      : base(BitmapStore.GetWidth(tbmpnr), BitmapStore.Getheight(tbmpnr))
    {
      this.OwnBitmapNr = tbmpnr;
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
      ref Graphics local1 = ref objGraphics;
      Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
      ref Bitmap local2 = ref bitmap;
      DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
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
      ref Graphics local1 = ref objGraphics;
      Bitmap bitmap = BitmapStore.GetBitmap(this.OwnBitmapNr);
      ref Bitmap local2 = ref bitmap;
      DrawMod.Draw(ref local1, ref local2, 0, 0, 0.3f, 0.3f, 0.3f, 1f);
      if (!Information.IsNothing((object) objGraphics))
      {
        objGraphics.Dispose();
        objGraphics = (Graphics) null;
      }
      return this.OwnBitmap;
    }
  }
}
