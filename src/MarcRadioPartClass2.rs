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
  pub class MarcRadioPartClass2 : SubPartClass
  {
     Bitmap backbitmap;
     int colorized;
     bool selected;
     bool udsFlag;

    pub void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    pub MarcRadioPartClass2(
      int tcolorized,
      bool tselected,
      tDescript: String = "",
       Bitmap tBackbitmap = null,
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

    pub Bitmap Paint()
    {
      Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
      {
        objGraphics.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple( objGraphics,  this.backbitmap, 0, 0);
        objGraphics.CompositingMode = CompositingMode.SourceOver;
      }
      if (this.udsFlag)
      {
        if (this.selected)
        {
           Graphics local1 =  objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.UDSSMALLRADIO2);
           Bitmap local2 =  bitmap;
          DrawMod.DrawSimple( local1,  local2, 0, 0);
        }
        else
        {
           Graphics local3 =  objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.UDSSMALLRADIO);
           Bitmap local4 =  bitmap;
          DrawMod.DrawSimple( local3,  local4, 0, 0);
        }
      }
      return this.OwnBitmap;
    }

    pub Bitmap PaintOverlay()
    {
      Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
      {
        objGraphics.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple( objGraphics,  this.backbitmap, 0, 0);
        objGraphics.CompositingMode = CompositingMode.SourceOver;
      }
      if (this.udsFlag)
      {
        if (this.selected)
        {
           Graphics local1 =  objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.UDSSMALLRADIO2HIGH);
           Bitmap local2 =  bitmap;
          DrawMod.DrawSimple( local1,  local2, 0, 0);
        }
        else
        {
           Graphics local3 =  objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.UDSSMALLRADIOHIGH);
           Bitmap local4 =  bitmap;
          DrawMod.DrawSimple( local3,  local4, 0, 0);
        }
      }
      return this.OwnBitmap;
    }
  }
}
