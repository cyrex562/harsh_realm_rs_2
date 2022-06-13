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
      int tcolorized = 0,
      tDescript: String = "",
       Bitmap tBackbitmap = null,
      int bbx = -1,
      int bby = -1,
      int totherback = 0,
      int tsize = 35)
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
      Expression.DrawImage((Image) tBackbitmap, new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), new Rectangle(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
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
           Graphics local1 =  objGraphics;
          Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
           Bitmap local2 =  bitmap1;
          DrawMod.DrawSimple( local1,  local2, 0, 0);
           Graphics local3 =  objGraphics;
          Bitmap bitmap2 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local4 =  bitmap2;
          DrawMod.DrawSimple( local3,  local4, 2, 2);
        }
        else if (this.otherback == 1)
        {
           Graphics local5 =  objGraphics;
          Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK1);
           Bitmap local6 =  bitmap3;
          DrawMod.DrawSimple( local5,  local6, 0, 0);
           Graphics local7 =  objGraphics;
          Bitmap bitmap4 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local8 =  bitmap4;
          DrawMod.DrawSimple( local7,  local8, 0, 0);
        }
        else if (this.otherback == 2)
        {
           Graphics local9 =  objGraphics;
          Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK2);
           Bitmap local10 =  bitmap5;
          DrawMod.DrawSimple( local9,  local10, 0, 0);
           Graphics local11 =  objGraphics;
          Bitmap bitmap6 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local12 =  bitmap6;
          DrawMod.DrawSimple( local11,  local12, 0, 0);
        }
        else if (this.otherback == 3)
        {
           Graphics local13 =  objGraphics;
          Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK3);
           Bitmap local14 =  bitmap7;
          DrawMod.DrawSimple( local13,  local14, 0, 0);
           Graphics local15 =  objGraphics;
          Bitmap bitmap8 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local16 =  bitmap8;
          DrawMod.DrawSimple( local15,  local16, 0, 0);
        }
        else if (this.otherback == 4)
        {
           Graphics local17 =  objGraphics;
          Bitmap bitmap9 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK4);
           Bitmap local18 =  bitmap9;
          DrawMod.DrawSimple( local17,  local18, 0, 0);
           Graphics local19 =  objGraphics;
          Bitmap bitmap10 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local20 =  bitmap10;
          DrawMod.DrawSimple( local19,  local20, 0, 0);
        }
      }
      else if (this.colorized == 1)
      {
        if (this.otherback == 0)
        {
           Graphics local21 =  objGraphics;
          Bitmap bitmap11 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
           Bitmap local22 =  bitmap11;
          DrawMod.Draw( local21,  local22, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           Graphics local23 =  objGraphics;
          Bitmap bitmap12 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local24 =  bitmap12;
          DrawMod.DrawGray( local23,  local24, 2, 2);
        }
        else if (this.otherback == 1)
        {
           Graphics local25 =  objGraphics;
          Bitmap bitmap13 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK1);
           Bitmap local26 =  bitmap13;
          DrawMod.Draw( local25,  local26, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           Graphics local27 =  objGraphics;
          Bitmap bitmap14 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local28 =  bitmap14;
          DrawMod.DrawGray( local27,  local28, 0, 0);
        }
        else if (this.otherback == 2)
        {
           Graphics local29 =  objGraphics;
          Bitmap bitmap15 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK2);
           Bitmap local30 =  bitmap15;
          DrawMod.Draw( local29,  local30, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           Graphics local31 =  objGraphics;
          Bitmap bitmap16 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local32 =  bitmap16;
          DrawMod.DrawGray( local31,  local32, 0, 0);
        }
        else if (this.otherback == 3)
        {
           Graphics local33 =  objGraphics;
          Bitmap bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK3);
           Bitmap local34 =  bitmap17;
          DrawMod.Draw( local33,  local34, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           Graphics local35 =  objGraphics;
          Bitmap bitmap18 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local36 =  bitmap18;
          DrawMod.DrawGray( local35,  local36, 0, 0);
        }
        else if (this.otherback == 4)
        {
           Graphics local37 =  objGraphics;
          Bitmap bitmap19 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK4);
           Bitmap local38 =  bitmap19;
          DrawMod.Draw( local37,  local38, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           Graphics local39 =  objGraphics;
          Bitmap bitmap20 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local40 =  bitmap20;
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
           Graphics local1 =  objGraphics;
          Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
           Bitmap local2 =  bitmap1;
          DrawMod.DrawSimple( local1,  local2, 0, 0);
           Graphics local3 =  objGraphics;
          Bitmap bitmap2 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local4 =  bitmap2;
          DrawMod.DrawSimple( local3,  local4, 2, 2);
        }
        else if (this.otherback == 1)
        {
           Graphics local5 =  objGraphics;
          Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK1B);
           Bitmap local6 =  bitmap3;
          DrawMod.DrawSimple( local5,  local6, 0, 0);
           Graphics local7 =  objGraphics;
          Bitmap bitmap4 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local8 =  bitmap4;
          DrawMod.DrawSimple( local7,  local8, 0, 0);
        }
        else if (this.otherback == 2)
        {
           Graphics local9 =  objGraphics;
          Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK2B);
           Bitmap local10 =  bitmap5;
          DrawMod.DrawSimple( local9,  local10, 0, 0);
           Graphics local11 =  objGraphics;
          Bitmap bitmap6 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local12 =  bitmap6;
          DrawMod.DrawSimple( local11,  local12, 0, 0);
        }
        else if (this.otherback == 3)
        {
           Graphics local13 =  objGraphics;
          Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK3B);
           Bitmap local14 =  bitmap7;
          DrawMod.DrawSimple( local13,  local14, 0, 0);
           Graphics local15 =  objGraphics;
          Bitmap bitmap8 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local16 =  bitmap8;
          DrawMod.DrawSimple( local15,  local16, 0, 0);
        }
        else if (this.otherback == 4)
        {
           Graphics local17 =  objGraphics;
          Bitmap bitmap9 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK4B);
           Bitmap local18 =  bitmap9;
          DrawMod.DrawSimple( local17,  local18, 0, 0);
           Graphics local19 =  objGraphics;
          Bitmap bitmap10 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local20 =  bitmap10;
          DrawMod.DrawSimple( local19,  local20, 0, 0);
        }
      }
      else if (this.colorized == 1)
      {
        if (this.otherback == 0)
        {
           Graphics local21 =  objGraphics;
          Bitmap bitmap11 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
           Bitmap local22 =  bitmap11;
          DrawMod.Draw( local21,  local22, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           Graphics local23 =  objGraphics;
          Bitmap bitmap12 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local24 =  bitmap12;
          DrawMod.Draw( local23,  local24, 2, 2, 0.0f, 0.0f, 0.0f, 0.4f);
        }
        else if (this.otherback == 1)
        {
           Graphics local25 =  objGraphics;
          Bitmap bitmap13 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK1B);
           Bitmap local26 =  bitmap13;
          DrawMod.Draw( local25,  local26, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           Graphics local27 =  objGraphics;
          Bitmap bitmap14 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local28 =  bitmap14;
          DrawMod.Draw( local27,  local28, 0, 0, 0.0f, 0.0f, 0.0f, 0.4f);
        }
        else if (this.otherback == 2)
        {
           Graphics local29 =  objGraphics;
          Bitmap bitmap15 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK2B);
           Bitmap local30 =  bitmap15;
          DrawMod.Draw( local29,  local30, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           Graphics local31 =  objGraphics;
          Bitmap bitmap16 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local32 =  bitmap16;
          DrawMod.Draw( local31,  local32, 0, 0, 0.0f, 0.0f, 0.0f, 0.4f);
        }
        else if (this.otherback == 3)
        {
           Graphics local33 =  objGraphics;
          Bitmap bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK3B);
           Bitmap local34 =  bitmap17;
          DrawMod.Draw( local33,  local34, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           Graphics local35 =  objGraphics;
          Bitmap bitmap18 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local36 =  bitmap18;
          DrawMod.Draw( local35,  local36, 0, 0, 0.0f, 0.0f, 0.0f, 0.4f);
        }
        else if (this.otherback == 4)
        {
           Graphics local37 =  objGraphics;
          Bitmap bitmap19 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK4B);
           Bitmap local38 =  bitmap19;
          DrawMod.Draw( local37,  local38, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
           Graphics local39 =  objGraphics;
          Bitmap bitmap20 = BitmapStore.GetBitmap(this.OwnBitmapNr);
           Bitmap local40 =  bitmap20;
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
