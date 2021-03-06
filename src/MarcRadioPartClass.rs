// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MarcRadioPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
  pub class MarcRadioPartClass : SubPartClass
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

    pub MarcRadioPartClass(
      int tcolorized,
      bool tselected,
      tDescript: String = "",
       Bitmap tBackbitmap = null,
      let mut bbx: i32 =  -1,
      let mut bby: i32 =  -1,
      bool tudsFlag = false)
      : base(35, 35)
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
      graphics.DrawImage((Image) tBackbitmap, Rectangle::new(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), Rectangle::new(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
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
      if (!this.udsFlag)
      {
        if (this.selected)
        {
          if (this.colorized == 0)
          {
             let mut local1: &Graphics = &objGraphics;
            Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.RADIO2);
             let mut local2: &Bitmap = &bitmap;
            DrawMod.DrawSimple( local1,  local2, 0, 0);
          }
          else if (this.colorized == 1)
          {
             let mut local3: &Graphics = &objGraphics;
            Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.RADIO2);
             let mut local4: &Bitmap = &bitmap;
            DrawMod.Draw( local3,  local4, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
          }
        }
        else if (this.colorized == 0)
        {
           let mut local5: &Graphics = &objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.RADIO1);
           let mut local6: &Bitmap = &bitmap;
          DrawMod.DrawSimple( local5,  local6, 0, 0);
        }
        else if (this.colorized == 1)
        {
           let mut local7: &Graphics = &objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.RADIO1);
           let mut local8: &Bitmap = &bitmap;
          DrawMod.Draw( local7,  local8, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
        }
      }
      else if (this.selected)
      {
         let mut local9: &Graphics = &objGraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.UDSRADIO2);
         let mut local10: &Bitmap = &bitmap;
        DrawMod.DrawSimple( local9,  local10, 0, 0);
      }
      else
      {
         let mut local11: &Graphics = &objGraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.UDSRADIO);
         let mut local12: &Bitmap = &bitmap;
        DrawMod.DrawSimple( local11,  local12, 0, 0);
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
      if (!this.udsFlag)
      {
        if (this.selected)
        {
          if (this.colorized == 0)
          {
             let mut local1: &Graphics = &objGraphics;
            Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.RADIO2A);
             let mut local2: &Bitmap = &bitmap;
            DrawMod.DrawSimple( local1,  local2, 0, 0);
          }
          else if (this.colorized == 1)
          {
             let mut local3: &Graphics = &objGraphics;
            Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.RADIO2A);
             let mut local4: &Bitmap = &bitmap;
            DrawMod.Draw( local3,  local4, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
          }
        }
        else if (this.colorized == 0)
        {
           let mut local5: &Graphics = &objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.RADIO1A);
           let mut local6: &Bitmap = &bitmap;
          DrawMod.DrawSimple( local5,  local6, 0, 0);
        }
        else if (this.colorized == 1)
        {
           let mut local7: &Graphics = &objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.RADIO1A);
           let mut local8: &Bitmap = &bitmap;
          DrawMod.Draw( local7,  local8, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
        }
      }
      else if (this.selected)
      {
         let mut local9: &Graphics = &objGraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.UDSRADIO2HIGH);
         let mut local10: &Bitmap = &bitmap;
        DrawMod.DrawSimple( local9,  local10, 0, 0);
      }
      else
      {
         let mut local11: &Graphics = &objGraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.UDSRADIOHIGH);
         let mut local12: &Bitmap = &bitmap;
        DrawMod.DrawSimple( local11,  local12, 0, 0);
      }
      return this.OwnBitmap;
    }
  }
}
