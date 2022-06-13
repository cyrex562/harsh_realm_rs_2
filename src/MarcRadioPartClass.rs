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
      int bbx = -1,
      int bby = -1,
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
      if (!this.udsFlag)
      {
        if (this.selected)
        {
          if (this.colorized == 0)
          {
             Graphics local1 =  objGraphics;
            Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.RADIO2);
             Bitmap local2 =  bitmap;
            DrawMod.DrawSimple( local1,  local2, 0, 0);
          }
          else if (this.colorized == 1)
          {
             Graphics local3 =  objGraphics;
            Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.RADIO2);
             Bitmap local4 =  bitmap;
            DrawMod.Draw( local3,  local4, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
          }
        }
        else if (this.colorized == 0)
        {
           Graphics local5 =  objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.RADIO1);
           Bitmap local6 =  bitmap;
          DrawMod.DrawSimple( local5,  local6, 0, 0);
        }
        else if (this.colorized == 1)
        {
           Graphics local7 =  objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.RADIO1);
           Bitmap local8 =  bitmap;
          DrawMod.Draw( local7,  local8, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
        }
      }
      else if (this.selected)
      {
         Graphics local9 =  objGraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.UDSRADIO2);
         Bitmap local10 =  bitmap;
        DrawMod.DrawSimple( local9,  local10, 0, 0);
      }
      else
      {
         Graphics local11 =  objGraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.UDSRADIO);
         Bitmap local12 =  bitmap;
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
             Graphics local1 =  objGraphics;
            Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.RADIO2A);
             Bitmap local2 =  bitmap;
            DrawMod.DrawSimple( local1,  local2, 0, 0);
          }
          else if (this.colorized == 1)
          {
             Graphics local3 =  objGraphics;
            Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.RADIO2A);
             Bitmap local4 =  bitmap;
            DrawMod.Draw( local3,  local4, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
          }
        }
        else if (this.colorized == 0)
        {
           Graphics local5 =  objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.RADIO1A);
           Bitmap local6 =  bitmap;
          DrawMod.DrawSimple( local5,  local6, 0, 0);
        }
        else if (this.colorized == 1)
        {
           Graphics local7 =  objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.RADIO1A);
           Bitmap local8 =  bitmap;
          DrawMod.Draw( local7,  local8, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
        }
      }
      else if (this.selected)
      {
         Graphics local9 =  objGraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.UDSRADIO2HIGH);
         Bitmap local10 =  bitmap;
        DrawMod.DrawSimple( local9,  local10, 0, 0);
      }
      else
      {
         Graphics local11 =  objGraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.UDSRADIOHIGH);
         Bitmap local12 =  bitmap;
        DrawMod.DrawSimple( local11,  local12, 0, 0);
      }
      return this.OwnBitmap;
    }
  }
}
