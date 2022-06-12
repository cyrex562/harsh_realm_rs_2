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
  public class MarcButtonPartClass : SubPartClass
  {
    private int OwnBitmapNr;
    private int colorized;
    private Bitmap backbitmap;
    private int otherback;

    public override void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    public MarcButtonPartClass(
      int tbmpnr,
      int tcolorized = 0,
      string tDescript = "",
      ref Bitmap tBackbitmap = null,
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
        if (this.otherback == 0)
        {
          ref Graphics local1 = ref objGraphics;
          Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
          ref Bitmap local2 = ref bitmap1;
          DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
          ref Graphics local3 = ref objGraphics;
          Bitmap bitmap2 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local4 = ref bitmap2;
          DrawMod.DrawSimple(ref local3, ref local4, 2, 2);
        }
        else if (this.otherback == 1)
        {
          ref Graphics local5 = ref objGraphics;
          Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK1);
          ref Bitmap local6 = ref bitmap3;
          DrawMod.DrawSimple(ref local5, ref local6, 0, 0);
          ref Graphics local7 = ref objGraphics;
          Bitmap bitmap4 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local8 = ref bitmap4;
          DrawMod.DrawSimple(ref local7, ref local8, 0, 0);
        }
        else if (this.otherback == 2)
        {
          ref Graphics local9 = ref objGraphics;
          Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK2);
          ref Bitmap local10 = ref bitmap5;
          DrawMod.DrawSimple(ref local9, ref local10, 0, 0);
          ref Graphics local11 = ref objGraphics;
          Bitmap bitmap6 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local12 = ref bitmap6;
          DrawMod.DrawSimple(ref local11, ref local12, 0, 0);
        }
        else if (this.otherback == 3)
        {
          ref Graphics local13 = ref objGraphics;
          Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK3);
          ref Bitmap local14 = ref bitmap7;
          DrawMod.DrawSimple(ref local13, ref local14, 0, 0);
          ref Graphics local15 = ref objGraphics;
          Bitmap bitmap8 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local16 = ref bitmap8;
          DrawMod.DrawSimple(ref local15, ref local16, 0, 0);
        }
        else if (this.otherback == 4)
        {
          ref Graphics local17 = ref objGraphics;
          Bitmap bitmap9 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK4);
          ref Bitmap local18 = ref bitmap9;
          DrawMod.DrawSimple(ref local17, ref local18, 0, 0);
          ref Graphics local19 = ref objGraphics;
          Bitmap bitmap10 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local20 = ref bitmap10;
          DrawMod.DrawSimple(ref local19, ref local20, 0, 0);
        }
      }
      else if (this.colorized == 1)
      {
        if (this.otherback == 0)
        {
          ref Graphics local21 = ref objGraphics;
          Bitmap bitmap11 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
          ref Bitmap local22 = ref bitmap11;
          DrawMod.Draw(ref local21, ref local22, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
          ref Graphics local23 = ref objGraphics;
          Bitmap bitmap12 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local24 = ref bitmap12;
          DrawMod.DrawGray(ref local23, ref local24, 2, 2);
        }
        else if (this.otherback == 1)
        {
          ref Graphics local25 = ref objGraphics;
          Bitmap bitmap13 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK1);
          ref Bitmap local26 = ref bitmap13;
          DrawMod.Draw(ref local25, ref local26, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
          ref Graphics local27 = ref objGraphics;
          Bitmap bitmap14 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local28 = ref bitmap14;
          DrawMod.DrawGray(ref local27, ref local28, 0, 0);
        }
        else if (this.otherback == 2)
        {
          ref Graphics local29 = ref objGraphics;
          Bitmap bitmap15 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK2);
          ref Bitmap local30 = ref bitmap15;
          DrawMod.Draw(ref local29, ref local30, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
          ref Graphics local31 = ref objGraphics;
          Bitmap bitmap16 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local32 = ref bitmap16;
          DrawMod.DrawGray(ref local31, ref local32, 0, 0);
        }
        else if (this.otherback == 3)
        {
          ref Graphics local33 = ref objGraphics;
          Bitmap bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK3);
          ref Bitmap local34 = ref bitmap17;
          DrawMod.Draw(ref local33, ref local34, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
          ref Graphics local35 = ref objGraphics;
          Bitmap bitmap18 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local36 = ref bitmap18;
          DrawMod.DrawGray(ref local35, ref local36, 0, 0);
        }
        else if (this.otherback == 4)
        {
          ref Graphics local37 = ref objGraphics;
          Bitmap bitmap19 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK4);
          ref Bitmap local38 = ref bitmap19;
          DrawMod.Draw(ref local37, ref local38, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
          ref Graphics local39 = ref objGraphics;
          Bitmap bitmap20 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local40 = ref bitmap20;
          DrawMod.DrawGray(ref local39, ref local40, 0, 0);
        }
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
        if (this.otherback == 0)
        {
          ref Graphics local1 = ref objGraphics;
          Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
          ref Bitmap local2 = ref bitmap1;
          DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
          ref Graphics local3 = ref objGraphics;
          Bitmap bitmap2 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local4 = ref bitmap2;
          DrawMod.DrawSimple(ref local3, ref local4, 2, 2);
        }
        else if (this.otherback == 1)
        {
          ref Graphics local5 = ref objGraphics;
          Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK1B);
          ref Bitmap local6 = ref bitmap3;
          DrawMod.DrawSimple(ref local5, ref local6, 0, 0);
          ref Graphics local7 = ref objGraphics;
          Bitmap bitmap4 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local8 = ref bitmap4;
          DrawMod.DrawSimple(ref local7, ref local8, 0, 0);
        }
        else if (this.otherback == 2)
        {
          ref Graphics local9 = ref objGraphics;
          Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK2B);
          ref Bitmap local10 = ref bitmap5;
          DrawMod.DrawSimple(ref local9, ref local10, 0, 0);
          ref Graphics local11 = ref objGraphics;
          Bitmap bitmap6 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local12 = ref bitmap6;
          DrawMod.DrawSimple(ref local11, ref local12, 0, 0);
        }
        else if (this.otherback == 3)
        {
          ref Graphics local13 = ref objGraphics;
          Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK3B);
          ref Bitmap local14 = ref bitmap7;
          DrawMod.DrawSimple(ref local13, ref local14, 0, 0);
          ref Graphics local15 = ref objGraphics;
          Bitmap bitmap8 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local16 = ref bitmap8;
          DrawMod.DrawSimple(ref local15, ref local16, 0, 0);
        }
        else if (this.otherback == 4)
        {
          ref Graphics local17 = ref objGraphics;
          Bitmap bitmap9 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK4B);
          ref Bitmap local18 = ref bitmap9;
          DrawMod.DrawSimple(ref local17, ref local18, 0, 0);
          ref Graphics local19 = ref objGraphics;
          Bitmap bitmap10 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local20 = ref bitmap10;
          DrawMod.DrawSimple(ref local19, ref local20, 0, 0);
        }
      }
      else if (this.colorized == 1)
      {
        if (this.otherback == 0)
        {
          ref Graphics local21 = ref objGraphics;
          Bitmap bitmap11 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
          ref Bitmap local22 = ref bitmap11;
          DrawMod.Draw(ref local21, ref local22, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
          ref Graphics local23 = ref objGraphics;
          Bitmap bitmap12 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local24 = ref bitmap12;
          DrawMod.Draw(ref local23, ref local24, 2, 2, 0.0f, 0.0f, 0.0f, 0.4f);
        }
        else if (this.otherback == 1)
        {
          ref Graphics local25 = ref objGraphics;
          Bitmap bitmap13 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK1B);
          ref Bitmap local26 = ref bitmap13;
          DrawMod.Draw(ref local25, ref local26, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
          ref Graphics local27 = ref objGraphics;
          Bitmap bitmap14 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local28 = ref bitmap14;
          DrawMod.Draw(ref local27, ref local28, 0, 0, 0.0f, 0.0f, 0.0f, 0.4f);
        }
        else if (this.otherback == 2)
        {
          ref Graphics local29 = ref objGraphics;
          Bitmap bitmap15 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK2B);
          ref Bitmap local30 = ref bitmap15;
          DrawMod.Draw(ref local29, ref local30, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
          ref Graphics local31 = ref objGraphics;
          Bitmap bitmap16 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local32 = ref bitmap16;
          DrawMod.Draw(ref local31, ref local32, 0, 0, 0.0f, 0.0f, 0.0f, 0.4f);
        }
        else if (this.otherback == 3)
        {
          ref Graphics local33 = ref objGraphics;
          Bitmap bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK3B);
          ref Bitmap local34 = ref bitmap17;
          DrawMod.Draw(ref local33, ref local34, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
          ref Graphics local35 = ref objGraphics;
          Bitmap bitmap18 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local36 = ref bitmap18;
          DrawMod.Draw(ref local35, ref local36, 0, 0, 0.0f, 0.0f, 0.0f, 0.4f);
        }
        else if (this.otherback == 4)
        {
          ref Graphics local37 = ref objGraphics;
          Bitmap bitmap19 = BitmapStore.GetBitmap(DrawMod.TGame.MARCBACK4B);
          ref Bitmap local38 = ref bitmap19;
          DrawMod.Draw(ref local37, ref local38, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
          ref Graphics local39 = ref objGraphics;
          Bitmap bitmap20 = BitmapStore.GetBitmap(this.OwnBitmapNr);
          ref Bitmap local40 = ref bitmap20;
          DrawMod.Draw(ref local39, ref local40, 0, 0, 0.0f, 0.0f, 0.0f, 0.4f);
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
