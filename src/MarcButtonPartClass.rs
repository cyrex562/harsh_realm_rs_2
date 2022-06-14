// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MarcButtonPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
  pub class MarcButtonPartClass : SubPartClass
  {
     int OwnBitmapNr;
     int colorized;
     Bitmap backbitmap;
     int otherback;

    pub void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    pub MarcButtonPartClass(
      int tbmpnr,
      let mut tcolorized: i32 =  0,
      tDescript: String = "",
       Bitmap tBackbitmap = null,
      let mut bbx: i32 =  -1,
      let mut bby: i32 =  -1,
      let mut totherback: i32 =  0,
      let mut tsize: i32 =  35)
      : base(tsize, tsize)
    {
      this.OwnBitmapNr = tbmpnr;
      this.colorized = tcolorized;
      this.Descript = tDescript;
      this.otherback = totherback;
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
        DrawMod.DrawSimple( objGraphics,  this.backbitmap, 0, 0);
        objGraphics.CompositingMode = CompositingMode.SourceOver;
      }
      if (this.colorized == 0)
      {
        if (this.otherback == 0)
        {
           let mut local1: &Graphics = &objGraphics;
          Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
           let mut local2: &Bitmap = &bitmap1;
          DrawMod.DrawSimple( local1,  local2, 0, 0);
           let mut local3: &Graphics = &objGraphics;
          Bitmap bitmap2 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local4: &Bitmap = &bitmap2;
          DrawMod.DrawSimple( local3,  local4, 2, 2);
        }
        else if (this.otherback == 1)
        {
           let mut local5: &Graphics = &objGraphics;
          Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK1);
           let mut local6: &Bitmap = &bitmap3;
          DrawMod.DrawSimple( local5,  local6, 0, 0);
           let mut local7: &Graphics = &objGraphics;
          Bitmap bitmap4 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local8: &Bitmap = &bitmap4;
          DrawMod.DrawSimple( local7,  local8, 0, 0);
        }
        else if (this.otherback == 2)
        {
           let mut local9: &Graphics = &objGraphics;
          Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK2);
           let mut local10: &Bitmap = &bitmap5;
          DrawMod.DrawSimple( local9,  local10, 0, 0);
           let mut local11: &Graphics = &objGraphics;
          Bitmap bitmap6 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local12: &Bitmap = &bitmap6;
          DrawMod.DrawSimple( local11,  local12, 0, 0);
        }
        else if (this.otherback == 3)
        {
           let mut local13: &Graphics = &objGraphics;
          Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK3);
           let mut local14: &Bitmap = &bitmap7;
          DrawMod.DrawSimple( local13,  local14, 0, 0);
           let mut local15: &Graphics = &objGraphics;
          Bitmap bitmap8 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local16: &Bitmap = &bitmap8;
          DrawMod.DrawSimple( local15,  local16, 0, 0);
        }
        else if (this.otherback == 4)
        {
           let mut local17: &Graphics = &objGraphics;
          Bitmap bitmap9 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK4);
           let mut local18: &Bitmap = &bitmap9;
          DrawMod.DrawSimple( local17,  local18, 0, 0);
           let mut local19: &Graphics = &objGraphics;
          Bitmap bitmap10 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local20: &Bitmap = &bitmap10;
          DrawMod.DrawSimple( local19,  local20, 0, 0);
        }
      }
      else if (this.colorized == 1)
      {
        if (this.otherback == 0)
        {
           let mut local21: &Graphics = &objGraphics;
          Bitmap bitmap11 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
           let mut local22: &Bitmap = &bitmap11;
          DrawMod.Draw( local21,  local22, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           let mut local23: &Graphics = &objGraphics;
          Bitmap bitmap12 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local24: &Bitmap = &bitmap12;
          DrawMod.DrawGray( local23,  local24, 2, 2);
        }
        else if (this.otherback == 1)
        {
           let mut local25: &Graphics = &objGraphics;
          Bitmap bitmap13 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK1);
           let mut local26: &Bitmap = &bitmap13;
          DrawMod.Draw( local25,  local26, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           let mut local27: &Graphics = &objGraphics;
          Bitmap bitmap14 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local28: &Bitmap = &bitmap14;
          DrawMod.DrawGray( local27,  local28, 0, 0);
        }
        else if (this.otherback == 2)
        {
           let mut local29: &Graphics = &objGraphics;
          Bitmap bitmap15 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK2);
           let mut local30: &Bitmap = &bitmap15;
          DrawMod.Draw( local29,  local30, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           let mut local31: &Graphics = &objGraphics;
          Bitmap bitmap16 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local32: &Bitmap = &bitmap16;
          DrawMod.DrawGray( local31,  local32, 0, 0);
        }
        else if (this.otherback == 3)
        {
           let mut local33: &Graphics = &objGraphics;
          Bitmap bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK3);
           let mut local34: &Bitmap = &bitmap17;
          DrawMod.Draw( local33,  local34, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           let mut local35: &Graphics = &objGraphics;
          Bitmap bitmap18 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local36: &Bitmap = &bitmap18;
          DrawMod.DrawGray( local35,  local36, 0, 0);
        }
        else if (this.otherback == 4)
        {
           let mut local37: &Graphics = &objGraphics;
          Bitmap bitmap19 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK4);
           let mut local38: &Bitmap = &bitmap19;
          DrawMod.Draw( local37,  local38, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           let mut local39: &Graphics = &objGraphics;
          Bitmap bitmap20 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local40: &Bitmap = &bitmap20;
          DrawMod.DrawGray( local39,  local40, 0, 0);
        }
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
        DrawMod.DrawSimple( objGraphics,  this.backbitmap, 0, 0);
        objGraphics.CompositingMode = CompositingMode.SourceOver;
      }
      if (this.colorized == 0)
      {
        if (this.otherback == 0)
        {
           let mut local1: &Graphics = &objGraphics;
          Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
           let mut local2: &Bitmap = &bitmap1;
          DrawMod.DrawSimple( local1,  local2, 0, 0);
           let mut local3: &Graphics = &objGraphics;
          Bitmap bitmap2 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local4: &Bitmap = &bitmap2;
          DrawMod.DrawSimple( local3,  local4, 2, 2);
        }
        else if (this.otherback == 1)
        {
           let mut local5: &Graphics = &objGraphics;
          Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK1B);
           let mut local6: &Bitmap = &bitmap3;
          DrawMod.DrawSimple( local5,  local6, 0, 0);
           let mut local7: &Graphics = &objGraphics;
          Bitmap bitmap4 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local8: &Bitmap = &bitmap4;
          DrawMod.DrawSimple( local7,  local8, 0, 0);
        }
        else if (this.otherback == 2)
        {
           let mut local9: &Graphics = &objGraphics;
          Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK2B);
           let mut local10: &Bitmap = &bitmap5;
          DrawMod.DrawSimple( local9,  local10, 0, 0);
           let mut local11: &Graphics = &objGraphics;
          Bitmap bitmap6 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local12: &Bitmap = &bitmap6;
          DrawMod.DrawSimple( local11,  local12, 0, 0);
        }
        else if (this.otherback == 3)
        {
           let mut local13: &Graphics = &objGraphics;
          Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK3B);
           let mut local14: &Bitmap = &bitmap7;
          DrawMod.DrawSimple( local13,  local14, 0, 0);
           let mut local15: &Graphics = &objGraphics;
          Bitmap bitmap8 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local16: &Bitmap = &bitmap8;
          DrawMod.DrawSimple( local15,  local16, 0, 0);
        }
        else if (this.otherback == 4)
        {
           let mut local17: &Graphics = &objGraphics;
          Bitmap bitmap9 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK4B);
           let mut local18: &Bitmap = &bitmap9;
          DrawMod.DrawSimple( local17,  local18, 0, 0);
           let mut local19: &Graphics = &objGraphics;
          Bitmap bitmap10 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local20: &Bitmap = &bitmap10;
          DrawMod.DrawSimple( local19,  local20, 0, 0);
        }
      }
      else if (this.colorized == 1)
      {
        if (this.otherback == 0)
        {
           let mut local21: &Graphics = &objGraphics;
          Bitmap bitmap11 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
           let mut local22: &Bitmap = &bitmap11;
          DrawMod.Draw( local21,  local22, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           let mut local23: &Graphics = &objGraphics;
          Bitmap bitmap12 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local24: &Bitmap = &bitmap12;
          DrawMod.Draw( local23,  local24, 2, 2, 0.0f, 0.0f, 0.0f, 0.4f);
        }
        else if (this.otherback == 1)
        {
           let mut local25: &Graphics = &objGraphics;
          Bitmap bitmap13 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK1B);
           let mut local26: &Bitmap = &bitmap13;
          DrawMod.Draw( local25,  local26, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           let mut local27: &Graphics = &objGraphics;
          Bitmap bitmap14 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local28: &Bitmap = &bitmap14;
          DrawMod.Draw( local27,  local28, 0, 0, 0.0f, 0.0f, 0.0f, 0.4f);
        }
        else if (this.otherback == 2)
        {
           let mut local29: &Graphics = &objGraphics;
          Bitmap bitmap15 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK2B);
           let mut local30: &Bitmap = &bitmap15;
          DrawMod.Draw( local29,  local30, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           let mut local31: &Graphics = &objGraphics;
          Bitmap bitmap16 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local32: &Bitmap = &bitmap16;
          DrawMod.Draw( local31,  local32, 0, 0, 0.0f, 0.0f, 0.0f, 0.4f);
        }
        else if (this.otherback == 3)
        {
           let mut local33: &Graphics = &objGraphics;
          Bitmap bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK3B);
           let mut local34: &Bitmap = &bitmap17;
          DrawMod.Draw( local33,  local34, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           let mut local35: &Graphics = &objGraphics;
          Bitmap bitmap18 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local36: &Bitmap = &bitmap18;
          DrawMod.Draw( local35,  local36, 0, 0, 0.0f, 0.0f, 0.0f, 0.4f);
        }
        else if (this.otherback == 4)
        {
           let mut local37: &Graphics = &objGraphics;
          Bitmap bitmap19 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK4B);
           let mut local38: &Bitmap = &bitmap19;
          DrawMod.Draw( local37,  local38, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           let mut local39: &Graphics = &objGraphics;
          Bitmap bitmap20 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           let mut local40: &Bitmap = &bitmap20;
          DrawMod.Draw( local39,  local40, 0, 0, 0.0f, 0.0f, 0.0f, 0.4f);
        }
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
