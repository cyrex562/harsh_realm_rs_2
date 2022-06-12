// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SmallTextButtonPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace WindowsApplication1
{
  public class SmallTextButtonPartClass : SubPartClass
  {
    private bool overrule;
    private string buttext;
    private int width;
    private int height;
    private Font ourfont;
    private Font ourfont2;
    private Bitmap backbitmap;
    private bool inactive;
    private bool red;
    private bool tuseshadow;
    private bool marcStyle;
    private string extraS;

    public override int Click(int x, int y, int b = 1)
    {
      if (DrawMod.TGame.EmpireStyle)
        SoundMod.PlayAWave(DrawMod.TGame.AppPath + "sound/interface/click.wav", ref DrawMod.TGame.EditObj);
      int num;
      return num;
    }

    public SmallTextButtonPartClass(
      string buttontext,
      int twidth,
      string tDescript = "",
      ref Bitmap tBackbitmap = null,
      int bbx = -1,
      int bby = -1,
      bool tinactive = false,
      int theight = 25)
      : base(twidth, theight)
    {
      this.ourfont = new Font(DrawMod.TGame.FontCol.Families[1], 12f, FontStyle.Bold, GraphicsUnit.Pixel);
      this.overrule = false;
      this.Descript = tDescript;
      if (!Information.IsNothing((object) tBackbitmap))
      {
        this.backbitmap = new Bitmap(this.OwnBitmap.Width, this.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
        this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics Expression = Graphics.FromImage((Image) this.backbitmap);
        Expression.CompositingMode = CompositingMode.SourceCopy;
        Expression.DrawImage((Image) tBackbitmap, new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), new Rectangle(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
        Expression.CompositingMode = CompositingMode.SourceOver;
        if (!Information.IsNothing((object) Expression))
          Expression.Dispose();
      }
      this.buttext = buttontext;
      this.width = twidth;
      this.height = theight;
      this.inactive = tinactive;
    }

    public override void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    public override Bitmap Paint()
    {
      SizeF sizeF1 = new SizeF();
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
      {
        Expression.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple(ref Expression, ref this.backbitmap, 0, 0);
        Expression.CompositingMode = CompositingMode.SourceOver;
      }
      Expression.SmoothingMode = SmoothingMode.AntiAlias;
      Expression.TextRenderingHint = TextRenderingHint.AntiAlias;
      Expression.TextContrast = 1;
      if (this.inactive)
      {
        ref Graphics local1 = ref Expression;
        Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALLHIGH);
        ref Bitmap local2 = ref bitmap1;
        Rectangle rectangle1 = new Rectangle(7, 0, 7, 25);
        Rectangle srcrect1 = rectangle1;
        Rectangle rectangle2 = new Rectangle(7, 0, this.width - 14, this.height);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
        ref Graphics local3 = ref Expression;
        Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALLHIGH);
        ref Bitmap local4 = ref bitmap2;
        rectangle2 = new Rectangle(0, 0, 7, 25);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(0, 0, 7, this.height);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        ref Graphics local5 = ref Expression;
        Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALLHIGH);
        ref Bitmap local6 = ref bitmap3;
        rectangle2 = new Rectangle(19, 0, 7, 25);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(this.width - 7, 0, 7, this.height);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
      }
      else
      {
        ref Graphics local7 = ref Expression;
        Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALL);
        ref Bitmap local8 = ref bitmap4;
        Rectangle rectangle3 = new Rectangle(7, 0, 7, 25);
        Rectangle srcrect4 = rectangle3;
        Rectangle rectangle4 = new Rectangle(7, 0, this.width - 14, this.height);
        Rectangle destrect4 = rectangle4;
        DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
        ref Graphics local9 = ref Expression;
        Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALL);
        ref Bitmap local10 = ref bitmap5;
        rectangle3 = new Rectangle(0, 0, 7, 25);
        Rectangle srcrect5 = rectangle3;
        rectangle4 = new Rectangle(0, 0, 7, this.height);
        Rectangle destrect5 = rectangle4;
        DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
        ref Graphics local11 = ref Expression;
        Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALL);
        ref Bitmap local12 = ref bitmap6;
        rectangle3 = new Rectangle(19, 0, 7, 25);
        Rectangle srcrect6 = rectangle3;
        rectangle4 = new Rectangle(this.width - 7, 0, 7, this.height);
        Rectangle destrect6 = rectangle4;
        DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
      }
      SizeF sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
      int x1 = (int) Math.Round(2.0 + ((double) this.width - (double) sizeF2.Width) / 2.0);
      int y1 = (int) Math.Round(2.0 + ((double) this.height - (double) sizeF2.Height) / 2.0);
      DrawMod.DrawTextColouredFuzzy(ref Expression, this.buttext, this.ourfont, x1, y1, Color.FromArgb(200, 0, 0, 0));
      SizeF sizeF3 = Expression.MeasureString(this.buttext, this.ourfont);
      int x2 = (int) Math.Round(((double) this.width - (double) sizeF3.Width) / 2.0);
      int y2 = (int) Math.Round(((double) this.height - (double) sizeF3.Height) / 2.0);
      DrawMod.DrawTextColouredNicely(ref Expression, this.buttext, this.ourfont, x2, y2, Color.White);
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return this.OwnBitmap;
    }

    public override Bitmap PaintOverlay()
    {
      SizeF sizeF1 = new SizeF();
      if (this.inactive)
        return this.Paint();
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
        DrawMod.DrawSimple(ref Expression, ref this.backbitmap, 0, 0);
      Expression.SmoothingMode = SmoothingMode.AntiAlias;
      Expression.TextRenderingHint = TextRenderingHint.AntiAlias;
      Expression.TextContrast = 1;
      ref Graphics local1 = ref Expression;
      Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALLHIGH);
      ref Bitmap local2 = ref bitmap;
      Rectangle rectangle1 = new Rectangle(7, 0, 7, 25);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(7, 0, this.width - 14, this.height);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
      ref Graphics local3 = ref Expression;
      bitmap = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALLHIGH);
      ref Bitmap local4 = ref bitmap;
      rectangle2 = new Rectangle(0, 0, 7, 25);
      Rectangle srcrect2 = rectangle2;
      rectangle1 = new Rectangle(0, 0, 7, this.height);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
      ref Graphics local5 = ref Expression;
      bitmap = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSMALLHIGH);
      ref Bitmap local6 = ref bitmap;
      rectangle2 = new Rectangle(19, 0, 7, 25);
      Rectangle srcrect3 = rectangle2;
      rectangle1 = new Rectangle(this.width - 7, 0, 7, this.height);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
      SizeF sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
      int x1 = (int) Math.Round(2.0 + ((double) this.width - (double) sizeF2.Width) / 2.0);
      int y1 = (int) Math.Round(2.0 + ((double) this.height - (double) sizeF2.Height) / 2.0);
      DrawMod.DrawTextColouredFuzzy(ref Expression, this.buttext, this.ourfont, x1, y1, Color.FromArgb(200, 0, 0, 0));
      SizeF sizeF3 = Expression.MeasureString(this.buttext, this.ourfont);
      int x2 = (int) Math.Round(((double) this.width - (double) sizeF3.Width) / 2.0);
      int y2 = (int) Math.Round(((double) this.height - (double) sizeF3.Height) / 2.0);
      DrawMod.DrawTextColouredNicely(ref Expression, this.buttext, this.ourfont, x2, y2, Color.White);
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }
  }
}
