// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SteveRadioPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
  pub class SteveRadioPartClass : SubPartClass
  {
     Bitmap backbitmap;
     int colorized;
     bool selected;

    pub SteveRadioPartClass(
      int tcolorized,
      bool tselected,
      tDescript: String = "",
       Bitmap tBackbitmap = null,
      let mut bbx: i32 = -1,
      let mut bby: i32 = -1)
      : base(35, 35)
    {
      self.Descript = tDescript;
      self.colorized = tcolorized;
      self.selected = tselected;
      if (Information.IsNothing((object) tBackbitmap))
        return;
      self.backbitmap = new Bitmap(self.OwnBitmap.Width, self.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
      self.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics = Graphics.FromImage((Image) self.backbitmap);
      graphics.CompositingMode = CompositingMode.SourceCopy;
      graphics.DrawImage((Image) tBackbitmap, new Rectangle(0, 0, self.OwnBitmap.Width, self.OwnBitmap.Height), new Rectangle(bbx, bby, self.OwnBitmap.Width, self.OwnBitmap.Height), GraphicsUnit.Pixel);
      graphics.CompositingMode = CompositingMode.SourceOver;
    }

    pub Bitmap Paint()
    {
      Graphics objGraphics = Graphics.FromImage((Image) self.OwnBitmap);
      if (!Information.IsNothing((object) self.backbitmap))
      {
        objGraphics.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple( objGraphics,  self.backbitmap, 0, 0);
        objGraphics.CompositingMode = CompositingMode.SourceOver;
      }
       Graphics local1 =  objGraphics;
      Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1);
       Bitmap local2 =  bitmap1;
      DrawMod.DrawSimple( local1,  local2, 0, 0);
      if (self.selected)
      {
        if (self.colorized == 0)
        {
           Graphics local3 =  objGraphics;
          Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.OKBALL);
           Bitmap local4 =  bitmap2;
          DrawMod.DrawSimple( local3,  local4, 2, 2);
        }
        else if (self.colorized == 1)
        {
           Graphics local5 =  objGraphics;
          Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.OKBALL);
           Bitmap local6 =  bitmap3;
          DrawMod.Draw( local5,  local6, 2, 2, 0.0f, 0.0f, 0.0f, 0.2f);
        }
      }
      else if (self.colorized == 0)
      {
         Graphics local7 =  objGraphics;
        Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.CANCELBALL);
         Bitmap local8 =  bitmap4;
        DrawMod.DrawSimple( local7,  local8, 2, 2);
      }
      else if (self.colorized == 1)
      {
         Graphics local9 =  objGraphics;
        Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.CANCELBALL);
         Bitmap local10 =  bitmap5;
        DrawMod.Draw( local9,  local10, 2, 2, 0.0f, 0.0f, 0.0f, 0.2f);
      }
      return self.OwnBitmap;
    }

    pub Bitmap PaintOverlay()
    {
      Graphics objGraphics = Graphics.FromImage((Image) self.OwnBitmap);
      if (!Information.IsNothing((object) self.backbitmap))
      {
        objGraphics.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple( objGraphics,  self.backbitmap, 0, 0);
        objGraphics.CompositingMode = CompositingMode.SourceOver;
      }
       Graphics local1 =  objGraphics;
      Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1b);
       Bitmap local2 =  bitmap1;
      DrawMod.DrawSimple( local1,  local2, 0, 0);
      if (self.selected)
      {
        if (self.colorized == 0)
        {
           Graphics local3 =  objGraphics;
          Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.OKBALL);
           Bitmap local4 =  bitmap2;
          DrawMod.DrawSimple( local3,  local4, 2, 2);
        }
        else if (self.colorized == 1)
        {
           Graphics local5 =  objGraphics;
          Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.OKBALL);
           Bitmap local6 =  bitmap3;
          DrawMod.Draw( local5,  local6, 2, 2, 0.0f, 0.0f, 0.0f, 0.2f);
        }
      }
      else if (self.colorized == 0)
      {
         Graphics local7 =  objGraphics;
        Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.CANCELBALL);
         Bitmap local8 =  bitmap4;
        DrawMod.DrawSimple( local7,  local8, 2, 2);
      }
      else if (self.colorized == 1)
      {
         Graphics local9 =  objGraphics;
        Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.CANCELBALL);
         Bitmap local10 =  bitmap5;
        DrawMod.Draw( local9,  local10, 2, 2, 0.0f, 0.0f, 0.0f, 0.2f);
      }
      return self.OwnBitmap;
    }
  }
}
