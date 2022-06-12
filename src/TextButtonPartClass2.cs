// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TextButtonPartClass2
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
  public class TextButtonPartClass2 : SubPartClass
  {
    private bool overrule;
    private string buttext;
    private int width;
    private int height;
    private Font ourfont;
    private Bitmap backbitmap;
    private bool inactive;
    private bool pressed;
    private int buttonVersion;

    public override int Click(int x, int y, int b = 1)
    {
      if (DrawMod.TGame.EmpireStyle)
        SoundMod.PlayAWave(DrawMod.TGame.AppPath + "sound/interface/click.wav", ref DrawMod.TGame.EditObj);
      int num;
      return num;
    }

    public TextButtonPartClass2(
      int tButtonVersion,
      string buttontext,
      int twidth,
      string tDescript = "",
      ref Bitmap tBackbitmap = null,
      int bbx = -1,
      int bby = -1,
      bool tinactive = false,
      bool tpressed = false,
      int theight = 35,
      int tfontsize = 13,
      Font usefont = null)
      : base(twidth, theight)
    {
      this.buttonVersion = 1;
      if (tfontsize > -1)
        this.ourfont = DrawMod.TGame.MarcFont16;
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
      this.buttonVersion = tButtonVersion;
      this.buttext = buttontext;
      this.buttext = this.buttext.ToUpper();
      this.width = twidth;
      this.height = theight;
      this.inactive = tinactive;
      this.pressed = tpressed;
      if (Information.IsNothing((object) usefont))
        return;
      this.ourfont = usefont;
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
      int nr;
      if (this.buttonVersion == 1)
      {
        nr = DrawMod.TGame.MARCBLOCK;
        if (this.pressed)
          nr = DrawMod.TGame.MARCBLOCKPRESSED;
      }
      else
      {
        nr = DrawMod.TGame.MARCBLOCK2;
        if (this.pressed)
          nr = DrawMod.TGame.MARCBLOCKPRESSED2;
      }
      ref Graphics local1 = ref Expression;
      Bitmap bitmap = BitmapStore.GetBitmap(nr);
      ref Bitmap local2 = ref bitmap;
      Rectangle rectangle1 = new Rectangle(0, 0, 50, 4);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(0, 0, this.width, 4);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
      ref Graphics local3 = ref Expression;
      bitmap = BitmapStore.GetBitmap(nr);
      ref Bitmap local4 = ref bitmap;
      rectangle2 = new Rectangle(0, 4, 50, 42);
      Rectangle srcrect2 = rectangle2;
      rectangle1 = new Rectangle(0, 4, this.width, this.height - 6);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
      ref Graphics local5 = ref Expression;
      bitmap = BitmapStore.GetBitmap(nr);
      ref Bitmap local6 = ref bitmap;
      rectangle2 = new Rectangle(0, 46, 50, 6);
      Rectangle srcrect3 = rectangle2;
      rectangle1 = new Rectangle(0, this.height - 6, this.width, 6);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
      if (this.inactive)
        DrawMod.DrawBlock(ref Expression, 0, 0, 48, this.height - 2, 0, 0, 0, 96);
      Color c = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      if (!this.pressed)
        c = Color.FromArgb((int) byte.MaxValue, 175, 175, 175);
      if (this.inactive)
        c = Color.FromArgb((int) byte.MaxValue, 120, 120, 120);
      SizeF sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
      int num1 = (int) Math.Round(1.0 + ((double) this.width - (double) sizeF2.Width) / 2.0);
      int y1 = (int) Math.Round(1.0 + ((double) this.height - (double) sizeF2.Height) / 2.0);
      DrawMod.DrawTextColouredFuzzy(ref Expression, this.buttext, this.ourfont, num1 - 1, y1, Color.FromArgb(200, 0, 0, 0));
      SizeF sizeF3 = Expression.MeasureString(this.buttext, this.ourfont);
      int num2 = (int) Math.Round(((double) this.width - (double) sizeF3.Width) / 2.0);
      int y2 = (int) Math.Round(((double) this.height - (double) sizeF3.Height) / 2.0);
      DrawMod.DrawTextColouredNicely(ref Expression, this.buttext, this.ourfont, num2 - 1, y2, c);
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
      int nr;
      if (this.buttonVersion == 1)
      {
        nr = DrawMod.TGame.MARCBLOCKHIGH;
        if (this.inactive)
          nr = DrawMod.TGame.MARCBLOCK;
        if (this.pressed)
          nr = DrawMod.TGame.MARCBLOCKPRESSED;
      }
      else
      {
        nr = DrawMod.TGame.MARCBLOCKHIGH2;
        if (this.inactive)
          nr = DrawMod.TGame.MARCBLOCK2;
        if (this.pressed)
          nr = DrawMod.TGame.MARCBLOCKPRESSED2;
      }
      ref Graphics local1 = ref Expression;
      Bitmap bitmap = BitmapStore.GetBitmap(nr);
      ref Bitmap local2 = ref bitmap;
      Rectangle rectangle1 = new Rectangle(0, 0, 50, 4);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(0, 0, this.width, 4);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
      ref Graphics local3 = ref Expression;
      bitmap = BitmapStore.GetBitmap(nr);
      ref Bitmap local4 = ref bitmap;
      rectangle2 = new Rectangle(0, 4, 50, 42);
      Rectangle srcrect2 = rectangle2;
      rectangle1 = new Rectangle(0, 4, this.width, this.height - 6);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
      ref Graphics local5 = ref Expression;
      bitmap = BitmapStore.GetBitmap(nr);
      ref Bitmap local6 = ref bitmap;
      rectangle2 = new Rectangle(0, 46, 50, 6);
      Rectangle srcrect3 = rectangle2;
      rectangle1 = new Rectangle(0, this.height - 6, this.width, 6);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
      if (this.inactive)
        DrawMod.DrawBlock(ref Expression, 0, 0, 48, this.height - 2, 0, 0, 0, 96);
      Color c = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      if (!this.pressed)
        c = Color.FromArgb((int) byte.MaxValue, 175, 175, 175);
      if (this.inactive)
        c = Color.FromArgb((int) byte.MaxValue, 120, 120, 120);
      SizeF sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
      int num1 = (int) Math.Round(1.0 + ((double) this.width - (double) sizeF2.Width) / 2.0);
      int y1 = (int) Math.Round(1.0 + ((double) this.height - (double) sizeF2.Height) / 2.0);
      DrawMod.DrawTextColouredFuzzy(ref Expression, this.buttext, this.ourfont, num1 - 1, y1, Color.FromArgb(200, 0, 0, 0));
      SizeF sizeF3 = Expression.MeasureString(this.buttext, this.ourfont);
      int num2 = (int) Math.Round(((double) this.width - (double) sizeF3.Width) / 2.0);
      int y2 = (int) Math.Round(((double) this.height - (double) sizeF3.Height) / 2.0);
      DrawMod.DrawTextColouredNicely(ref Expression, this.buttext, this.ourfont, num2 - 1, y2, c);
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return this.OwnBitmap;
    }
  }
}
