// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MarcRadioPartClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
  public class MarcRadioPartClass2 : SubPartClass
  {
    private Bitmap backbitmap;
    private int colorized;
    private bool selected;
    private bool udsFlag;

    public override void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    public MarcRadioPartClass2(
      int tcolorized,
      bool tselected,
      string tDescript = "",
      ref Bitmap tBackbitmap = null,
      int bbx = -1,
      int bby = -1,
      bool tudsFlag = false)
      : base(35, 23)
    {
      this.Descript = tDescript;
      this.colorized = tcolorized;
      this.selected = tselected;
      this.udsFlag = tudsFlag;
      if (Information.IsNothing((object) tBackbitmap))
        return;
      this.backbitmap = new Bitmap(this.OwnBitmap.Width, this.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
      this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics = Graphics.FromImage((Image) this.backbitmap);
      graphics.CompositingMode = CompositingMode.SourceCopy;
      graphics.DrawImage((Image) tBackbitmap, new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), new Rectangle(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
      graphics.CompositingMode = CompositingMode.SourceOver;
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
      if (this.udsFlag)
      {
        if (this.selected)
        {
          ref Graphics local1 = ref objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.UDSSMALLRADIO2);
          ref Bitmap local2 = ref bitmap;
          DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
        }
        else
        {
          ref Graphics local3 = ref objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.UDSSMALLRADIO);
          ref Bitmap local4 = ref bitmap;
          DrawMod.DrawSimple(ref local3, ref local4, 0, 0);
        }
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
      if (this.udsFlag)
      {
        if (this.selected)
        {
          ref Graphics local1 = ref objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.UDSSMALLRADIO2HIGH);
          ref Bitmap local2 = ref bitmap;
          DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
        }
        else
        {
          ref Graphics local3 = ref objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.UDSSMALLRADIOHIGH);
          ref Bitmap local4 = ref bitmap;
          DrawMod.DrawSimple(ref local3, ref local4, 0, 0);
        }
      }
      return this.OwnBitmap;
    }
  }
}
