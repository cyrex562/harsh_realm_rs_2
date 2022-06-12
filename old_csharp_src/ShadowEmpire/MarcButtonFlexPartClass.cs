// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MarcButtonFlexPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
  public class MarcButtonFlexPartClass : SubPartClass
  {
    private int OwnBitmapNr;
    private Bitmap backbitmap;
    private int otherback;
    private string texty;
    private int bw;
    private int bh;
    private int colorized;

    public override void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    public MarcButtonFlexPartClass(
      int tbmpnr,
      string tTexty,
      int tcolorized = 0,
      string tDescript = "",
      ref Bitmap tBackbitmap = null,
      int bbx = -1,
      int bby = -1,
      int totherback = 0,
      int tWidth = 35,
      int tHeight = 35)
      : base(tWidth, tHeight)
    {
      this.OwnBitmapNr = tbmpnr;
      this.bw = tWidth;
      this.colorized = tcolorized;
      this.bh = tHeight;
      this.Descript = tDescript;
      this.texty = tTexty;
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
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
      {
        Expression.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple(ref Expression, ref this.backbitmap, 0, 0);
        Expression.CompositingMode = CompositingMode.SourceOver;
      }
      int nr = 0;
      int num1;
      int num2;
      if (this.otherback == 0)
      {
        nr = DrawMod.TGame.BUTTONMARC1;
        num1 = 2;
        num2 = 2;
      }
      else if (this.otherback == 1)
        nr = DrawMod.TGame.MARCBACK1;
      else if (this.otherback == 2)
        nr = DrawMod.TGame.MARCBACK2;
      else if (this.otherback == 3)
        nr = DrawMod.TGame.MARCBACK3;
      else if (this.otherback == 4)
        nr = DrawMod.TGame.MARCBACK4;
      if (this.colorized == 0)
      {
        ref Graphics local1 = ref Expression;
        Bitmap bitmap1 = BitmapStore.GetBitmap(nr);
        ref Bitmap local2 = ref bitmap1;
        Rectangle rectangle1 = new Rectangle(0, 0, 8, this.bh);
        Rectangle srcrect1 = rectangle1;
        Rectangle rectangle2 = new Rectangle(0, 0, 8, this.bh);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
        ref Graphics local3 = ref Expression;
        Bitmap bitmap2 = BitmapStore.GetBitmap(nr);
        ref Bitmap local4 = ref bitmap2;
        rectangle2 = new Rectangle(this.bh - 8, 0, 8, this.bh);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(this.bw - 8, 0, 8, this.bh);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        ref Graphics local5 = ref Expression;
        bitmap2 = BitmapStore.GetBitmap(nr);
        ref Bitmap local6 = ref bitmap2;
        rectangle2 = new Rectangle(8, 0, this.bh - 16, this.bh);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(8, 0, this.bw - 16, this.bh);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
        ref Graphics local7 = ref Expression;
        bitmap2 = BitmapStore.GetBitmap(this.OwnBitmapNr);
        ref Bitmap local8 = ref bitmap2;
        int x = num1;
        int y = num2;
        DrawMod.DrawSimple(ref local7, ref local8, x, y);
        DrawMod.DrawTextColouredMarc(ref Expression, this.texty, DrawMod.TGame.MarcFont4, num1 + this.bh, num2 + 4, Color.White);
      }
      else if (this.colorized == 1)
      {
        ref Graphics local9 = ref Expression;
        Bitmap bitmap3 = BitmapStore.GetBitmap(nr);
        ref Bitmap local10 = ref bitmap3;
        Rectangle rectangle3 = new Rectangle(0, 0, 8, this.bh);
        Rectangle srcrect4 = rectangle3;
        Rectangle rectangle4 = new Rectangle(0, 0, 8, this.bh);
        Rectangle destrect4 = rectangle4;
        DrawMod.DrawSimplePart2ColouredNew(ref local9, ref local10, srcrect4, destrect4, 0.5f, 0.5f, 0.5f, 0.5f);
        ref Graphics local11 = ref Expression;
        Bitmap bitmap4 = BitmapStore.GetBitmap(nr);
        ref Bitmap local12 = ref bitmap4;
        rectangle3 = new Rectangle(this.bh - 8, 0, 8, this.bh);
        Rectangle srcrect5 = rectangle3;
        rectangle4 = new Rectangle(this.bw - 8, 0, 8, this.bh);
        Rectangle destrect5 = rectangle4;
        DrawMod.DrawSimplePart2ColouredNew(ref local11, ref local12, srcrect5, destrect5, 0.5f, 0.5f, 0.5f, 0.5f);
        ref Graphics local13 = ref Expression;
        bitmap4 = BitmapStore.GetBitmap(nr);
        ref Bitmap local14 = ref bitmap4;
        rectangle3 = new Rectangle(8, 0, this.bh - 16, this.bh);
        Rectangle srcrect6 = rectangle3;
        rectangle4 = new Rectangle(8, 0, this.bw - 16, this.bh);
        Rectangle destrect6 = rectangle4;
        DrawMod.DrawSimplePart2ColouredNew(ref local13, ref local14, srcrect6, destrect6, 0.5f, 0.5f, 0.5f, 0.5f);
        ref Graphics local15 = ref Expression;
        bitmap4 = BitmapStore.GetBitmap(this.OwnBitmapNr);
        ref Bitmap local16 = ref bitmap4;
        int x = num1;
        int y = num2;
        DrawMod.Draw(ref local15, ref local16, x, y, 0.5f, 0.5f, 0.5f, 0.5f);
        DrawMod.DrawTextColouredMarc(ref Expression, this.texty, DrawMod.TGame.MarcFont4, num1 + this.bh, num2 + 4, Color.Gray);
      }
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return this.OwnBitmap;
    }

    public override Bitmap PaintOverlay()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
      {
        Expression.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple(ref Expression, ref this.backbitmap, 0, 0);
        Expression.CompositingMode = CompositingMode.SourceOver;
      }
      int nr = 0;
      int num1;
      int num2;
      if (this.otherback == 0)
      {
        nr = DrawMod.TGame.BUTTONMARC1b;
        num1 = 2;
        num2 = 2;
      }
      else if (this.otherback == 1)
        nr = DrawMod.TGame.MARCBACK1B;
      else if (this.otherback == 2)
        nr = DrawMod.TGame.MARCBACK2B;
      else if (this.otherback == 3)
        nr = DrawMod.TGame.MARCBACK3B;
      else if (this.otherback == 4)
        nr = DrawMod.TGame.MARCBACK4B;
      if (this.colorized == 0)
      {
        ref Graphics local1 = ref Expression;
        Bitmap bitmap1 = BitmapStore.GetBitmap(nr);
        ref Bitmap local2 = ref bitmap1;
        Rectangle rectangle1 = new Rectangle(0, 0, 8, this.bh);
        Rectangle srcrect1 = rectangle1;
        Rectangle rectangle2 = new Rectangle(0, 0, 8, this.bh);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
        ref Graphics local3 = ref Expression;
        Bitmap bitmap2 = BitmapStore.GetBitmap(nr);
        ref Bitmap local4 = ref bitmap2;
        rectangle2 = new Rectangle(this.bh - 8, 0, 8, this.bh);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(this.bw - 8, 0, 8, this.bh);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        ref Graphics local5 = ref Expression;
        bitmap2 = BitmapStore.GetBitmap(nr);
        ref Bitmap local6 = ref bitmap2;
        rectangle2 = new Rectangle(8, 0, this.bh - 16, this.bh);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(8, 0, this.bw - 16, this.bh);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
        ref Graphics local7 = ref Expression;
        bitmap2 = BitmapStore.GetBitmap(this.OwnBitmapNr);
        ref Bitmap local8 = ref bitmap2;
        int x = num1;
        int y = num2;
        DrawMod.DrawSimple(ref local7, ref local8, x, y);
        DrawMod.DrawTextColouredMarc(ref Expression, this.texty, DrawMod.TGame.MarcFont4, num1 + this.bh, num2 + 4, Color.White);
      }
      else if (this.colorized == 1)
      {
        ref Graphics local9 = ref Expression;
        Bitmap bitmap3 = BitmapStore.GetBitmap(nr);
        ref Bitmap local10 = ref bitmap3;
        Rectangle rectangle3 = new Rectangle(0, 0, 8, this.bh);
        Rectangle srcrect4 = rectangle3;
        Rectangle rectangle4 = new Rectangle(0, 0, 8, this.bh);
        Rectangle destrect4 = rectangle4;
        DrawMod.DrawSimplePart2ColouredNew(ref local9, ref local10, srcrect4, destrect4, 0.0f, 0.0f, 0.0f, 0.2f);
        ref Graphics local11 = ref Expression;
        Bitmap bitmap4 = BitmapStore.GetBitmap(nr);
        ref Bitmap local12 = ref bitmap4;
        rectangle3 = new Rectangle(this.bh - 8, 0, 8, this.bh);
        Rectangle srcrect5 = rectangle3;
        rectangle4 = new Rectangle(this.bw - 8, 0, 8, this.bh);
        Rectangle destrect5 = rectangle4;
        DrawMod.DrawSimplePart2ColouredNew(ref local11, ref local12, srcrect5, destrect5, 0.0f, 0.0f, 0.0f, 0.2f);
        ref Graphics local13 = ref Expression;
        bitmap4 = BitmapStore.GetBitmap(nr);
        ref Bitmap local14 = ref bitmap4;
        rectangle3 = new Rectangle(8, 0, 19, this.bh);
        Rectangle srcrect6 = rectangle3;
        rectangle4 = new Rectangle(8, 0, this.bw - 16, this.bh);
        Rectangle destrect6 = rectangle4;
        DrawMod.DrawSimplePart2ColouredNew(ref local13, ref local14, srcrect6, destrect6, 0.0f, 0.0f, 0.0f, 0.2f);
        ref Graphics local15 = ref Expression;
        bitmap4 = BitmapStore.GetBitmap(this.OwnBitmapNr);
        ref Bitmap local16 = ref bitmap4;
        int x = num1;
        int y = num2;
        DrawMod.Draw(ref local15, ref local16, x, y, 0.0f, 0.0f, 0.0f, 0.4f);
        DrawMod.DrawTextColouredMarc(ref Expression, this.texty, DrawMod.TGame.MarcFont4, num1 + this.bh, num2 + 4, Color.Gray);
      }
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return this.OwnBitmap;
    }
  }
}
