// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TextButtonPartClass
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
  public class TextButtonPartClass : SubPartClass
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
    private bool udsButton;
    private int udsButtonSubType;
    private bool useOverruleCol;
    private Color overruleCol;

    public override int Click(int x, int y, int b = 1)
    {
      if (DrawMod.TGame.EmpireStyle)
        SoundMod.PlayAWave(DrawMod.TGame.AppPath + "sound/interface/click.wav", ref DrawMod.TGame.EditObj);
      int num;
      return num;
    }

    public TextButtonPartClass(
      string buttontext,
      int twidth,
      string tDescript = "",
      ref Bitmap tBackbitmap = null,
      int bbx = -1,
      int bby = -1,
      bool tinactive = false,
      bool tred = false,
      int theight = 35,
      int tfontsize = 13,
      Font usefont = null,
      bool useshadow = false,
      bool tMarcStyle = false,
      string textras = "",
      Font tfont2 = null,
      bool tudsButton = false,
      int tudsButtonSubType = 0,
      int toverrulered = 0,
      int toverrulegreen = 0,
      int toverruleblue = 0)
      : base(twidth, theight)
    {
      if (tfontsize > -1)
        this.ourfont = new Font(DrawMod.TGame.FontCol.Families[1], (float) tfontsize, FontStyle.Bold, GraphicsUnit.Pixel);
      this.udsButton = tudsButton;
      this.udsButtonSubType = tudsButtonSubType;
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
      this.red = tred;
      this.extraS = textras;
      this.marcStyle = tMarcStyle;
      this.tuseshadow = useshadow;
      if (!Information.IsNothing((object) usefont))
        this.ourfont = usefont;
      if (!Information.IsNothing((object) tfont2))
        this.ourfont2 = tfont2;
      if (!(toverruleblue > 0 | toverrulegreen > 0 | toverrulered > 0))
        return;
      this.overruleCol = Color.FromArgb((int) byte.MaxValue, toverrulered, toverrulegreen, toverruleblue);
      this.useOverruleCol = true;
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
      if (this.udsButton)
      {
        if (this.udsButtonSubType == 3)
        {
          if (this.inactive)
          {
            DrawMod.DrawBlock(ref Expression, 4, 3, this.width - 12, this.height, 0, 0, 0, 96);
          }
          else
          {
            DrawMod.DrawBlock(ref Expression, 4, 3, this.width - 12, this.height, 0, 0, 0, 24);
            DrawMod.DrawRectangle(ref Expression, 4, 3, this.width - 12, this.height - 6, 0, 0, 0, 64, 4);
          }
        }
        else if (this.udsButtonSubType < 2 | this.udsButtonSubType == 4)
        {
          if (this.inactive)
          {
            DrawMod.DrawBlock(ref Expression, 4, 3, this.width - 12, this.height - 10, 0, 0, 0, 96);
          }
          else
          {
            DrawMod.DrawBlock(ref Expression, 4, 3, this.width - 12, this.height - 10, 0, 0, 0, 24);
            DrawMod.DrawRectangle(ref Expression, 4, 3, this.width - 12, this.height - 10, 0, 0, 0, 64, 4);
          }
        }
        else if (this.udsButtonSubType == 2)
        {
          if (this.height == 35)
          {
            ref Graphics local1 = ref Expression;
            Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
            ref Bitmap local2 = ref bitmap1;
            Rectangle rectangle1 = new Rectangle(15, 0, 205, 35);
            Rectangle srcrect1 = rectangle1;
            Rectangle rectangle2 = new Rectangle(15, 0, this.width - 30, this.height);
            Rectangle destrect1 = rectangle2;
            DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
            ref Graphics local3 = ref Expression;
            Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
            ref Bitmap local4 = ref bitmap2;
            rectangle2 = new Rectangle(0, 0, 15, 35);
            Rectangle srcrect2 = rectangle2;
            rectangle1 = new Rectangle(0, 0, 15, this.height);
            Rectangle destrect2 = rectangle1;
            DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
            ref Graphics local5 = ref Expression;
            Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
            ref Bitmap local6 = ref bitmap3;
            rectangle2 = new Rectangle(220, 0, 15, 35);
            Rectangle srcrect3 = rectangle2;
            rectangle1 = new Rectangle(this.width - 15, 0, 15, this.height);
            Rectangle destrect3 = rectangle1;
            DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
          }
          else
          {
            ref Graphics local7 = ref Expression;
            Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
            ref Bitmap local8 = ref bitmap4;
            Rectangle rectangle3 = new Rectangle(7, 5, 222, 22);
            Rectangle srcrect4 = rectangle3;
            Rectangle rectangle4 = new Rectangle(7, 5, this.width - 14, this.height - 8);
            Rectangle destrect4 = rectangle4;
            DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
            ref Graphics local9 = ref Expression;
            Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
            ref Bitmap local10 = ref bitmap5;
            rectangle3 = new Rectangle(0, 5, 7, 22);
            Rectangle srcrect5 = rectangle3;
            rectangle4 = new Rectangle(0, 5, 7, this.height - 8);
            Rectangle destrect5 = rectangle4;
            DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
            ref Graphics local11 = ref Expression;
            Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
            ref Bitmap local12 = ref bitmap6;
            rectangle3 = new Rectangle(224, 5, 12, 22);
            Rectangle srcrect6 = rectangle3;
            rectangle4 = new Rectangle(this.width - 12, 5, 12, this.height - 8);
            Rectangle destrect6 = rectangle4;
            DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
            ref Graphics local13 = ref Expression;
            Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
            ref Bitmap local14 = ref bitmap7;
            rectangle3 = new Rectangle(7, 0, 222, 5);
            Rectangle srcrect7 = rectangle3;
            rectangle4 = new Rectangle(7, 0, this.width - 14, 5);
            Rectangle destrect7 = rectangle4;
            DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
            ref Graphics local15 = ref Expression;
            bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
            ref Bitmap local16 = ref bitmap7;
            rectangle3 = new Rectangle(0, 0, 7, 5);
            Rectangle srcrect8 = rectangle3;
            rectangle4 = new Rectangle(0, 0, 7, 5);
            Rectangle destrect8 = rectangle4;
            DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
            ref Graphics local17 = ref Expression;
            bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
            ref Bitmap local18 = ref bitmap7;
            rectangle3 = new Rectangle(224, 0, 12, 5);
            Rectangle srcrect9 = rectangle3;
            rectangle4 = new Rectangle(this.width - 12, 0, 12, 5);
            Rectangle destrect9 = rectangle4;
            DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
            ref Graphics local19 = ref Expression;
            bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
            ref Bitmap local20 = ref bitmap7;
            rectangle3 = new Rectangle(7, 28, 222, 7);
            Rectangle srcrect10 = rectangle3;
            rectangle4 = new Rectangle(7, this.height - 4, this.width - 14, 4);
            Rectangle destrect10 = rectangle4;
            DrawMod.DrawSimplePart2(ref local19, ref local20, srcrect10, destrect10);
            ref Graphics local21 = ref Expression;
            bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
            ref Bitmap local22 = ref bitmap7;
            rectangle3 = new Rectangle(0, 28, 7, 7);
            Rectangle srcrect11 = rectangle3;
            rectangle4 = new Rectangle(0, this.height - 4, 7, 4);
            Rectangle destrect11 = rectangle4;
            DrawMod.DrawSimplePart2(ref local21, ref local22, srcrect11, destrect11);
            ref Graphics local23 = ref Expression;
            bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONG);
            ref Bitmap local24 = ref bitmap7;
            rectangle3 = new Rectangle(224, 28, 12, 7);
            Rectangle srcrect12 = rectangle3;
            rectangle4 = new Rectangle(this.width - 12, this.height - 4, 12, 4);
            Rectangle destrect12 = rectangle4;
            DrawMod.DrawSimplePart2(ref local23, ref local24, srcrect12, destrect12);
          }
        }
      }
      else if (this.marcStyle)
      {
        if (this.width > 39 & DrawMod.TGame.Data.Product == 7)
        {
          ref Graphics local25 = ref Expression;
          Bitmap bitmap8 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
          ref Bitmap local26 = ref bitmap8;
          Rectangle rectangle5 = new Rectangle(14, 0, 197, 35);
          Rectangle srcrect13 = rectangle5;
          Rectangle rectangle6 = new Rectangle(14, 0, this.width - 28, this.height);
          Rectangle destrect13 = rectangle6;
          DrawMod.DrawSimplePart2(ref local25, ref local26, srcrect13, destrect13);
          ref Graphics local27 = ref Expression;
          Bitmap bitmap9 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
          ref Bitmap local28 = ref bitmap9;
          rectangle5 = new Rectangle(0, 0, 14, 35);
          Rectangle srcrect14 = rectangle5;
          rectangle6 = new Rectangle(0, 0, 14, this.height);
          Rectangle destrect14 = rectangle6;
          DrawMod.DrawSimplePart2(ref local27, ref local28, srcrect14, destrect14);
          ref Graphics local29 = ref Expression;
          Bitmap bitmap10 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
          ref Bitmap local30 = ref bitmap10;
          rectangle5 = new Rectangle(211, 0, 24, 35);
          Rectangle srcrect15 = rectangle5;
          rectangle6 = new Rectangle(this.width - 24, 0, 24, this.height);
          Rectangle destrect15 = rectangle6;
          DrawMod.DrawSimplePart2(ref local29, ref local30, srcrect15, destrect15);
        }
        else
        {
          ref Graphics local31 = ref Expression;
          Bitmap bitmap11 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
          ref Bitmap local32 = ref bitmap11;
          Rectangle rectangle7 = new Rectangle(7, 0, 7, 35);
          Rectangle srcrect16 = rectangle7;
          Rectangle rectangle8 = new Rectangle(7, 0, this.width - 14, this.height);
          Rectangle destrect16 = rectangle8;
          DrawMod.DrawSimplePart2(ref local31, ref local32, srcrect16, destrect16);
          ref Graphics local33 = ref Expression;
          Bitmap bitmap12 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
          ref Bitmap local34 = ref bitmap12;
          rectangle7 = new Rectangle(0, 0, 7, 35);
          Rectangle srcrect17 = rectangle7;
          rectangle8 = new Rectangle(0, 0, 7, this.height);
          Rectangle destrect17 = rectangle8;
          DrawMod.DrawSimplePart2(ref local33, ref local34, srcrect17, destrect17);
          ref Graphics local35 = ref Expression;
          Bitmap bitmap13 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1);
          ref Bitmap local36 = ref bitmap13;
          rectangle7 = new Rectangle(29, 0, 7, 35);
          Rectangle srcrect18 = rectangle7;
          rectangle8 = new Rectangle(this.width - 7, 0, 7, this.height);
          Rectangle destrect18 = rectangle8;
          DrawMod.DrawSimplePart2(ref local35, ref local36, srcrect18, destrect18);
        }
      }
      else if (this.width > 39)
      {
        ref Graphics local37 = ref Expression;
        Bitmap bitmap14 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
        ref Bitmap local38 = ref bitmap14;
        Rectangle rectangle9 = new Rectangle(7, 5, 222, 22);
        Rectangle srcrect19 = rectangle9;
        Rectangle rectangle10 = new Rectangle(7, 5, this.width - 14, this.height - 8);
        Rectangle destrect19 = rectangle10;
        DrawMod.DrawSimplePart2(ref local37, ref local38, srcrect19, destrect19);
        ref Graphics local39 = ref Expression;
        Bitmap bitmap15 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
        ref Bitmap local40 = ref bitmap15;
        rectangle9 = new Rectangle(0, 5, 7, 22);
        Rectangle srcrect20 = rectangle9;
        rectangle10 = new Rectangle(0, 5, 7, this.height - 8);
        Rectangle destrect20 = rectangle10;
        DrawMod.DrawSimplePart2(ref local39, ref local40, srcrect20, destrect20);
        ref Graphics local41 = ref Expression;
        Bitmap bitmap16 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
        ref Bitmap local42 = ref bitmap16;
        rectangle9 = new Rectangle(224, 5, 12, 22);
        Rectangle srcrect21 = rectangle9;
        rectangle10 = new Rectangle(this.width - 12, 5, 12, this.height - 8);
        Rectangle destrect21 = rectangle10;
        DrawMod.DrawSimplePart2(ref local41, ref local42, srcrect21, destrect21);
        ref Graphics local43 = ref Expression;
        Bitmap bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
        ref Bitmap local44 = ref bitmap17;
        rectangle9 = new Rectangle(7, 0, 222, 5);
        Rectangle srcrect22 = rectangle9;
        rectangle10 = new Rectangle(7, 0, this.width - 14, 5);
        Rectangle destrect22 = rectangle10;
        DrawMod.DrawSimplePart2(ref local43, ref local44, srcrect22, destrect22);
        ref Graphics local45 = ref Expression;
        bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
        ref Bitmap local46 = ref bitmap17;
        rectangle9 = new Rectangle(0, 0, 7, 5);
        Rectangle srcrect23 = rectangle9;
        rectangle10 = new Rectangle(0, 0, 7, 5);
        Rectangle destrect23 = rectangle10;
        DrawMod.DrawSimplePart2(ref local45, ref local46, srcrect23, destrect23);
        ref Graphics local47 = ref Expression;
        bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
        ref Bitmap local48 = ref bitmap17;
        rectangle9 = new Rectangle(224, 0, 12, 5);
        Rectangle srcrect24 = rectangle9;
        rectangle10 = new Rectangle(this.width - 12, 0, 12, 5);
        Rectangle destrect24 = rectangle10;
        DrawMod.DrawSimplePart2(ref local47, ref local48, srcrect24, destrect24);
        ref Graphics local49 = ref Expression;
        bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
        ref Bitmap local50 = ref bitmap17;
        rectangle9 = new Rectangle(7, 28, 222, 7);
        Rectangle srcrect25 = rectangle9;
        rectangle10 = new Rectangle(7, this.height - 4, this.width - 14, 4);
        Rectangle destrect25 = rectangle10;
        DrawMod.DrawSimplePart2(ref local49, ref local50, srcrect25, destrect25);
        ref Graphics local51 = ref Expression;
        bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
        ref Bitmap local52 = ref bitmap17;
        rectangle9 = new Rectangle(0, 28, 7, 7);
        Rectangle srcrect26 = rectangle9;
        rectangle10 = new Rectangle(0, this.height - 4, 7, 4);
        Rectangle destrect26 = rectangle10;
        DrawMod.DrawSimplePart2(ref local51, ref local52, srcrect26, destrect26);
        ref Graphics local53 = ref Expression;
        bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONG);
        ref Bitmap local54 = ref bitmap17;
        rectangle9 = new Rectangle(224, 28, 12, 7);
        Rectangle srcrect27 = rectangle9;
        rectangle10 = new Rectangle(this.width - 12, this.height - 4, 12, 4);
        Rectangle destrect27 = rectangle10;
        DrawMod.DrawSimplePart2(ref local53, ref local54, srcrect27, destrect27);
      }
      else
      {
        ref Graphics local55 = ref Expression;
        Bitmap bitmap18 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1);
        ref Bitmap local56 = ref bitmap18;
        Rectangle rectangle11 = new Rectangle(7, 0, 7, 35);
        Rectangle srcrect28 = rectangle11;
        Rectangle rectangle12 = new Rectangle(7, 0, this.width - 14, this.height);
        Rectangle destrect28 = rectangle12;
        DrawMod.DrawSimplePart2(ref local55, ref local56, srcrect28, destrect28);
        ref Graphics local57 = ref Expression;
        Bitmap bitmap19 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1);
        ref Bitmap local58 = ref bitmap19;
        rectangle11 = new Rectangle(0, 0, 7, 35);
        Rectangle srcrect29 = rectangle11;
        rectangle12 = new Rectangle(0, 0, 7, this.height);
        Rectangle destrect29 = rectangle12;
        DrawMod.DrawSimplePart2(ref local57, ref local58, srcrect29, destrect29);
        ref Graphics local59 = ref Expression;
        Bitmap bitmap20 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1);
        ref Bitmap local60 = ref bitmap20;
        rectangle11 = new Rectangle(29, 0, 7, 35);
        Rectangle srcrect30 = rectangle11;
        rectangle12 = new Rectangle(this.width - 7, 0, 7, this.height);
        Rectangle destrect30 = rectangle12;
        DrawMod.DrawSimplePart2(ref local59, ref local60, srcrect30, destrect30);
      }
      if (!this.udsButton)
      {
        if (this.inactive & !this.marcStyle)
          DrawMod.DrawBlock(ref Expression, 0, 0, this.width, this.height, 0, 0, 0, 128);
        else if (this.inactive & this.marcStyle)
        {
          if (DrawMod.TGame.Data.Product >= 6 & this.red)
            DrawMod.DrawBlockGradient2(ref Expression, -1, -1, this.width - 6, (int) Math.Round((double) this.height - (3.0 + (double) Math.Max(0, this.height - 40) / 7.0)), Color.FromArgb(64, 155, 25, 0), Color.FromArgb(164, 155, 25, 0));
          else
            DrawMod.DrawBlockGradient2(ref Expression, 2, 2, this.width - 6, (int) Math.Round((double) this.height - (3.0 + (double) Math.Max(0, this.height - 40) / 7.0)), Color.FromArgb(128, 0, 0, 0), Color.FromArgb(196, 0, 0, 0));
        }
      }
      Color c = Color.White;
      if (DrawMod.TGame.Data.Product == 7 & this.inactive)
        c = Color.Gray;
      if (this.marcStyle & this.red)
        c = DrawMod.TGame.Data.Product != 7 ? Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 210, 210) : Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 60, 60);
      if (this.marcStyle & this.useOverruleCol)
        c = this.overruleCol;
      if (this.udsButton)
      {
        c = Color.Black;
        if (this.udsButtonSubType == 2)
          c = Color.White;
      }
      SizeF sizeF2;
      int num;
      int y1;
      if (this.udsButton)
      {
        sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
        num = (int) Math.Round(((double) (this.width - 6) - (double) sizeF2.Width) / 2.0);
        y1 = (int) Math.Round(((double) (this.height + 2) - (double) sizeF2.Height) / 2.0 - 1.0);
        if (this.udsButtonSubType == 3)
          y1 += 2;
        if (this.inactive)
          c = Color.FromArgb((int) Math.Round((double) c.A / 2.0), (int) c.R, (int) c.G, (int) c.B);
        DrawMod.DrawTextColouredNicely(ref Expression, this.buttext, this.ourfont, num, y1, c);
      }
      else if (!this.marcStyle & !this.tuseshadow)
      {
        sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
        num = (int) Math.Round(((double) (this.width - 6) - (double) sizeF2.Width) / 2.0);
        y1 = (int) Math.Round(((double) (this.height + 2) - (double) sizeF2.Height) / 2.0 - 1.0);
        DrawMod.DrawTextVic3(ref Expression, this.buttext, this.ourfont, num, y1, DrawMod.TGame.VicColor2, DrawMod.TGame.VicColor1Shade);
      }
      else if (this.extraS.Length > 0)
      {
        SizeF sizeF3 = Expression.MeasureString(this.buttext, this.ourfont);
        int x1 = (int) Math.Round(2.0 + ((double) this.width - (double) sizeF3.Width) / 2.0);
        int y2 = (int) Math.Round(2.0 + ((double) this.height - (double) sizeF3.Height) / 2.0 - 8.0);
        DrawMod.DrawTextColouredFuzzy(ref Expression, this.buttext, this.ourfont, x1, y2, Color.FromArgb(200, 0, 0, 0));
        SizeF sizeF4 = Expression.MeasureString(this.buttext, this.ourfont);
        int x2 = (int) Math.Round(((double) this.width - (double) sizeF4.Width) / 2.0);
        int y3 = (int) Math.Round(((double) this.height - (double) sizeF4.Height) / 2.0 - 8.0);
        DrawMod.DrawTextColouredNicely(ref Expression, this.buttext, this.ourfont, x2, y3, c);
        SizeF sizeF5 = Expression.MeasureString(this.extraS, this.ourfont2);
        int x3 = (int) Math.Round(2.0 + ((double) this.width - (double) sizeF5.Width) / 2.0);
        int y4 = (int) Math.Round(2.0 + ((double) this.height - (double) sizeF5.Height) / 2.0 + 8.0);
        DrawMod.DrawTextColouredFuzzy(ref Expression, this.extraS, this.ourfont2, x3, y4, Color.FromArgb(200, 0, 0, 0));
        sizeF2 = Expression.MeasureString(this.extraS, this.ourfont2);
        num = (int) Math.Round(((double) this.width - (double) sizeF2.Width) / 2.0);
        y1 = (int) Math.Round(((double) this.height - (double) sizeF2.Height) / 2.0 + 8.0);
        DrawMod.DrawTextColouredNicely(ref Expression, this.extraS, this.ourfont2, num, y1, c);
      }
      else if (this.tuseshadow)
      {
        sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
        int x = (int) Math.Round(((double) this.width - (double) sizeF2.Width) / 2.0);
        int y5 = (int) Math.Round(2.0 + ((double) this.height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextColouredFuzzy(ref Expression, this.buttext, this.ourfont, x, y5, Color.FromArgb(200, 0, 0, 0));
        sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
        num = (int) Math.Round(((double) this.width - (double) sizeF2.Width) / 2.0 - 2.0);
        y1 = (int) Math.Round(0.0 + ((double) this.height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextColouredNicely(ref Expression, this.buttext, this.ourfont, num, y1, c);
      }
      else
      {
        SizeF sizeF6 = Expression.MeasureString(this.buttext, this.ourfont);
        int x4 = (int) Math.Round(((double) this.width - (double) sizeF6.Width) / 2.0);
        int y6 = (int) Math.Round(((double) this.height - (double) sizeF6.Height) / 2.0 - 1.0);
        DrawMod.DrawTextColoured(ref Expression, this.buttext, this.ourfont, x4, y6, Color.Black);
        sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
        int x5 = (int) Math.Round(((double) this.width - (double) sizeF2.Width) / 2.0);
        int y7 = (int) Math.Round(((double) this.height - (double) sizeF2.Height) / 2.0 + 1.0);
        DrawMod.DrawTextColoured(ref Expression, this.buttext, this.ourfont, x5, y7, Color.Black);
        sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
        int x6 = (int) Math.Round(((double) this.width - (double) sizeF2.Width) / 2.0 + 1.0);
        int y8 = (int) Math.Round(((double) this.height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextColoured(ref Expression, this.buttext, this.ourfont, x6, y8, Color.Black);
        sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
        int x7 = (int) Math.Round(((double) this.width - (double) sizeF2.Width) / 2.0 - 1.0);
        int y9 = (int) Math.Round(((double) this.height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextColoured(ref Expression, this.buttext, this.ourfont, x7, y9, Color.Black);
        sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
        num = (int) Math.Round(((double) this.width - (double) sizeF2.Width) / 2.0);
        y1 = (int) Math.Round(((double) this.height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextColoured(ref Expression, this.buttext, this.ourfont, num, y1, c);
      }
      if (!this.marcStyle && this.red)
      {
        if (this.height == 26)
          DrawMod.drawLine(ref Expression, num, (int) Math.Round((double) y1 + (double) sizeF2.Height - 1.0), (int) Math.Round((double) ((float) num + sizeF2.Width)), (int) Math.Round((double) y1 + (double) sizeF2.Height - 1.0), (int) DrawMod.TGame.viccolor7.R, (int) DrawMod.TGame.viccolor7.G, (int) DrawMod.TGame.viccolor7.B, (int) DrawMod.TGame.viccolor7.A);
        else
          DrawMod.drawLine(ref Expression, num, (int) Math.Round((double) y1 + (double) sizeF2.Height + 2.0), (int) Math.Round((double) ((float) num + sizeF2.Width)), (int) Math.Round((double) y1 + (double) sizeF2.Height + 2.0), (int) DrawMod.TGame.viccolor7.R, (int) DrawMod.TGame.viccolor7.G, (int) DrawMod.TGame.viccolor7.B, (int) DrawMod.TGame.viccolor7.A);
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
      SizeF sizeF1 = new SizeF();
      if (this.inactive)
        return this.Paint();
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
        DrawMod.DrawSimple(ref Expression, ref this.backbitmap, 0, 0);
      Expression.SmoothingMode = SmoothingMode.AntiAlias;
      Expression.TextRenderingHint = TextRenderingHint.AntiAlias;
      Expression.TextContrast = 1;
      if (this.udsButton)
      {
        if (this.udsButtonSubType == 3 | this.udsButtonSubType == 4)
        {
          DrawMod.DrawBlock(ref Expression, 3, 2, this.width - 12, this.height, (int) byte.MaxValue, 225, 225, 24);
          DrawMod.DrawRectangle(ref Expression, 3, 2, this.width - 12, this.height - 6, 0, 0, 0, 32, 4);
        }
        else if (this.udsButtonSubType < 2 | this.udsButtonSubType == 3)
        {
          DrawMod.DrawBlock(ref Expression, 3, 2, this.width - 12, this.height - 6, (int) byte.MaxValue, 225, 225, 24);
          DrawMod.DrawRectangle(ref Expression, 3, 2, this.width - 12, this.height - 6, 0, 0, 0, 32, 4);
        }
        else if (this.udsButtonSubType == 2)
        {
          if (this.height == 35)
          {
            ref Graphics local1 = ref Expression;
            Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
            ref Bitmap local2 = ref bitmap1;
            Rectangle rectangle1 = new Rectangle(15, 0, 205, 35);
            Rectangle srcrect1 = rectangle1;
            Rectangle rectangle2 = new Rectangle(15, 0, this.width - 30, this.height);
            Rectangle destrect1 = rectangle2;
            DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
            ref Graphics local3 = ref Expression;
            Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
            ref Bitmap local4 = ref bitmap2;
            rectangle2 = new Rectangle(0, 0, 15, 35);
            Rectangle srcrect2 = rectangle2;
            rectangle1 = new Rectangle(0, 0, 15, this.height);
            Rectangle destrect2 = rectangle1;
            DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
            ref Graphics local5 = ref Expression;
            Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
            ref Bitmap local6 = ref bitmap3;
            rectangle2 = new Rectangle(220, 0, 15, 35);
            Rectangle srcrect3 = rectangle2;
            rectangle1 = new Rectangle(this.width - 15, 0, 15, this.height);
            Rectangle destrect3 = rectangle1;
            DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
          }
          else
          {
            ref Graphics local7 = ref Expression;
            Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
            ref Bitmap local8 = ref bitmap4;
            Rectangle rectangle3 = new Rectangle(7, 5, 222, 22);
            Rectangle srcrect4 = rectangle3;
            Rectangle rectangle4 = new Rectangle(7, 5, this.width - 14, this.height - 8);
            Rectangle destrect4 = rectangle4;
            DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
            ref Graphics local9 = ref Expression;
            Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
            ref Bitmap local10 = ref bitmap5;
            rectangle3 = new Rectangle(0, 5, 7, 22);
            Rectangle srcrect5 = rectangle3;
            rectangle4 = new Rectangle(0, 5, 7, this.height - 8);
            Rectangle destrect5 = rectangle4;
            DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
            ref Graphics local11 = ref Expression;
            Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
            ref Bitmap local12 = ref bitmap6;
            rectangle3 = new Rectangle(224, 5, 12, 22);
            Rectangle srcrect6 = rectangle3;
            rectangle4 = new Rectangle(this.width - 12, 5, 12, this.height - 8);
            Rectangle destrect6 = rectangle4;
            DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
            ref Graphics local13 = ref Expression;
            Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
            ref Bitmap local14 = ref bitmap7;
            rectangle3 = new Rectangle(7, 0, 222, 5);
            Rectangle srcrect7 = rectangle3;
            rectangle4 = new Rectangle(7, 0, this.width - 14, 5);
            Rectangle destrect7 = rectangle4;
            DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
            ref Graphics local15 = ref Expression;
            Bitmap bitmap8 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
            ref Bitmap local16 = ref bitmap8;
            rectangle3 = new Rectangle(0, 0, 7, 5);
            Rectangle srcrect8 = rectangle3;
            rectangle4 = new Rectangle(0, 0, 7, 5);
            Rectangle destrect8 = rectangle4;
            DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
            ref Graphics local17 = ref Expression;
            Bitmap bitmap9 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
            ref Bitmap local18 = ref bitmap9;
            rectangle3 = new Rectangle(224, 0, 12, 5);
            Rectangle srcrect9 = rectangle3;
            rectangle4 = new Rectangle(this.width - 12, 0, 12, 5);
            Rectangle destrect9 = rectangle4;
            DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
            ref Graphics local19 = ref Expression;
            Bitmap bitmap10 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
            ref Bitmap local20 = ref bitmap10;
            rectangle3 = new Rectangle(7, 28, 222, 7);
            Rectangle srcrect10 = rectangle3;
            rectangle4 = new Rectangle(7, this.height - 4, this.width - 14, 4);
            Rectangle destrect10 = rectangle4;
            DrawMod.DrawSimplePart2(ref local19, ref local20, srcrect10, destrect10);
            ref Graphics local21 = ref Expression;
            Bitmap bitmap11 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
            ref Bitmap local22 = ref bitmap11;
            rectangle3 = new Rectangle(0, 28, 7, 7);
            Rectangle srcrect11 = rectangle3;
            rectangle4 = new Rectangle(0, this.height - 4, 7, 4);
            Rectangle destrect11 = rectangle4;
            DrawMod.DrawSimplePart2(ref local21, ref local22, srcrect11, destrect11);
            ref Graphics local23 = ref Expression;
            Bitmap bitmap12 = BitmapStore.GetBitmap(DrawMod.TGame.UDSBUT2LONGHIGH);
            ref Bitmap local24 = ref bitmap12;
            rectangle3 = new Rectangle(224, 28, 12, 7);
            Rectangle srcrect12 = rectangle3;
            rectangle4 = new Rectangle(this.width - 12, this.height - 4, 12, 4);
            Rectangle destrect12 = rectangle4;
            DrawMod.DrawSimplePart2(ref local23, ref local24, srcrect12, destrect12);
          }
        }
      }
      else if (this.marcStyle)
      {
        if (this.width > 39 & DrawMod.TGame.Data.Product == 7)
        {
          ref Graphics local25 = ref Expression;
          Bitmap bitmap13 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
          ref Bitmap local26 = ref bitmap13;
          Rectangle rectangle5 = new Rectangle(14, 0, 197, 35);
          Rectangle srcrect13 = rectangle5;
          Rectangle rectangle6 = new Rectangle(14, 0, this.width - 28, this.height);
          Rectangle destrect13 = rectangle6;
          DrawMod.DrawSimplePart2(ref local25, ref local26, srcrect13, destrect13);
          ref Graphics local27 = ref Expression;
          Bitmap bitmap14 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
          ref Bitmap local28 = ref bitmap14;
          rectangle5 = new Rectangle(0, 0, 14, 35);
          Rectangle srcrect14 = rectangle5;
          rectangle6 = new Rectangle(0, 0, 14, this.height);
          Rectangle destrect14 = rectangle6;
          DrawMod.DrawSimplePart2(ref local27, ref local28, srcrect14, destrect14);
          ref Graphics local29 = ref Expression;
          Bitmap bitmap15 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
          ref Bitmap local30 = ref bitmap15;
          rectangle5 = new Rectangle(211, 0, 24, 35);
          Rectangle srcrect15 = rectangle5;
          rectangle6 = new Rectangle(this.width - 24, 0, 24, this.height);
          Rectangle destrect15 = rectangle6;
          DrawMod.DrawSimplePart2(ref local29, ref local30, srcrect15, destrect15);
        }
        else
        {
          ref Graphics local31 = ref Expression;
          Bitmap bitmap16 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
          ref Bitmap local32 = ref bitmap16;
          Rectangle rectangle7 = new Rectangle(7, 0, 7, 35);
          Rectangle srcrect16 = rectangle7;
          Rectangle rectangle8 = new Rectangle(7, 0, this.width - 14, this.height);
          Rectangle destrect16 = rectangle8;
          DrawMod.DrawSimplePart2(ref local31, ref local32, srcrect16, destrect16);
          ref Graphics local33 = ref Expression;
          Bitmap bitmap17 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
          ref Bitmap local34 = ref bitmap17;
          rectangle7 = new Rectangle(0, 0, 7, 35);
          Rectangle srcrect17 = rectangle7;
          rectangle8 = new Rectangle(0, 0, 7, this.height);
          Rectangle destrect17 = rectangle8;
          DrawMod.DrawSimplePart2(ref local33, ref local34, srcrect17, destrect17);
          ref Graphics local35 = ref Expression;
          Bitmap bitmap18 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONMARC1b);
          ref Bitmap local36 = ref bitmap18;
          rectangle7 = new Rectangle(29, 0, 7, 35);
          Rectangle srcrect18 = rectangle7;
          rectangle8 = new Rectangle(this.width - 7, 0, 7, this.height);
          Rectangle destrect18 = rectangle8;
          DrawMod.DrawSimplePart2(ref local35, ref local36, srcrect18, destrect18);
        }
      }
      else if (this.width > 39)
      {
        ref Graphics local37 = ref Expression;
        Bitmap bitmap19 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
        ref Bitmap local38 = ref bitmap19;
        Rectangle rectangle9 = new Rectangle(7, 5, 222, 22);
        Rectangle srcrect19 = rectangle9;
        Rectangle rectangle10 = new Rectangle(7, 5, this.width - 14, this.height - 8);
        Rectangle destrect19 = rectangle10;
        DrawMod.DrawSimplePart2(ref local37, ref local38, srcrect19, destrect19);
        ref Graphics local39 = ref Expression;
        Bitmap bitmap20 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
        ref Bitmap local40 = ref bitmap20;
        rectangle9 = new Rectangle(0, 5, 7, 22);
        Rectangle srcrect20 = rectangle9;
        rectangle10 = new Rectangle(0, 5, 7, this.height - 8);
        Rectangle destrect20 = rectangle10;
        DrawMod.DrawSimplePart2(ref local39, ref local40, srcrect20, destrect20);
        ref Graphics local41 = ref Expression;
        Bitmap bitmap21 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
        ref Bitmap local42 = ref bitmap21;
        rectangle9 = new Rectangle(224, 5, 12, 22);
        Rectangle srcrect21 = rectangle9;
        rectangle10 = new Rectangle(this.width - 12, 5, 12, this.height - 8);
        Rectangle destrect21 = rectangle10;
        DrawMod.DrawSimplePart2(ref local41, ref local42, srcrect21, destrect21);
        ref Graphics local43 = ref Expression;
        Bitmap bitmap22 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
        ref Bitmap local44 = ref bitmap22;
        rectangle9 = new Rectangle(7, 0, 222, 5);
        Rectangle srcrect22 = rectangle9;
        rectangle10 = new Rectangle(7, 0, this.width - 14, 5);
        Rectangle destrect22 = rectangle10;
        DrawMod.DrawSimplePart2(ref local43, ref local44, srcrect22, destrect22);
        ref Graphics local45 = ref Expression;
        Bitmap bitmap23 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
        ref Bitmap local46 = ref bitmap23;
        rectangle9 = new Rectangle(0, 0, 7, 5);
        Rectangle srcrect23 = rectangle9;
        rectangle10 = new Rectangle(0, 0, 7, 5);
        Rectangle destrect23 = rectangle10;
        DrawMod.DrawSimplePart2(ref local45, ref local46, srcrect23, destrect23);
        ref Graphics local47 = ref Expression;
        Bitmap bitmap24 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
        ref Bitmap local48 = ref bitmap24;
        rectangle9 = new Rectangle(224, 0, 12, 5);
        Rectangle srcrect24 = rectangle9;
        rectangle10 = new Rectangle(this.width - 12, 0, 12, 5);
        Rectangle destrect24 = rectangle10;
        DrawMod.DrawSimplePart2(ref local47, ref local48, srcrect24, destrect24);
        ref Graphics local49 = ref Expression;
        Bitmap bitmap25 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
        ref Bitmap local50 = ref bitmap25;
        rectangle9 = new Rectangle(7, 28, 222, 7);
        Rectangle srcrect25 = rectangle9;
        rectangle10 = new Rectangle(7, this.height - 4, this.width - 14, 4);
        Rectangle destrect25 = rectangle10;
        DrawMod.DrawSimplePart2(ref local49, ref local50, srcrect25, destrect25);
        ref Graphics local51 = ref Expression;
        Bitmap bitmap26 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
        ref Bitmap local52 = ref bitmap26;
        rectangle9 = new Rectangle(0, 28, 7, 7);
        Rectangle srcrect26 = rectangle9;
        rectangle10 = new Rectangle(0, this.height - 4, 7, 4);
        Rectangle destrect26 = rectangle10;
        DrawMod.DrawSimplePart2(ref local51, ref local52, srcrect26, destrect26);
        ref Graphics local53 = ref Expression;
        Bitmap bitmap27 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONLONGHIGH);
        ref Bitmap local54 = ref bitmap27;
        rectangle9 = new Rectangle(224, 28, 12, 7);
        Rectangle srcrect27 = rectangle9;
        rectangle10 = new Rectangle(this.width - 12, this.height - 4, 12, 4);
        Rectangle destrect27 = rectangle10;
        DrawMod.DrawSimplePart2(ref local53, ref local54, srcrect27, destrect27);
      }
      else
      {
        ref Graphics local55 = ref Expression;
        Bitmap bitmap28 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1b);
        ref Bitmap local56 = ref bitmap28;
        Rectangle rectangle11 = new Rectangle(7, 0, 7, 35);
        Rectangle srcrect28 = rectangle11;
        Rectangle rectangle12 = new Rectangle(7, 0, this.width - 14, this.height);
        Rectangle destrect28 = rectangle12;
        DrawMod.DrawSimplePart2(ref local55, ref local56, srcrect28, destrect28);
        ref Graphics local57 = ref Expression;
        Bitmap bitmap29 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1b);
        ref Bitmap local58 = ref bitmap29;
        rectangle11 = new Rectangle(0, 0, 7, 35);
        Rectangle srcrect29 = rectangle11;
        rectangle12 = new Rectangle(0, 0, 7, this.height);
        Rectangle destrect29 = rectangle12;
        DrawMod.DrawSimplePart2(ref local57, ref local58, srcrect29, destrect29);
        ref Graphics local59 = ref Expression;
        Bitmap bitmap30 = BitmapStore.GetBitmap(DrawMod.TGame.BUTTONSTEVE1b);
        ref Bitmap local60 = ref bitmap30;
        rectangle11 = new Rectangle(29, 0, 7, 35);
        Rectangle srcrect30 = rectangle11;
        rectangle12 = new Rectangle(this.width - 7, 0, 7, this.height);
        Rectangle destrect30 = rectangle12;
        DrawMod.DrawSimplePart2(ref local59, ref local60, srcrect30, destrect30);
      }
      Color c = Color.White;
      if (this.marcStyle & this.red)
        c = DrawMod.TGame.Data.Product != 7 ? Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 210, 210) : Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 110, 110);
      if (this.marcStyle & this.useOverruleCol)
        c = this.overruleCol;
      if (this.udsButton)
        c = Color.Red;
      SizeF sizeF2;
      int num;
      int y1;
      if (this.udsButton)
      {
        sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
        num = (int) Math.Round(((double) (this.width - 6) - (double) sizeF2.Width) / 2.0);
        y1 = (int) Math.Round(((double) (this.height + 2) - (double) sizeF2.Height) / 2.0 - 1.0);
        if (this.udsButtonSubType == 3)
          y1 += 2;
        DrawMod.DrawTextColouredNicely(ref Expression, this.buttext, this.ourfont, num, y1, c);
      }
      else if (!this.marcStyle & !this.tuseshadow)
      {
        sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
        num = (int) Math.Round(((double) (this.width - 6) - (double) sizeF2.Width) / 2.0);
        y1 = (int) Math.Round(((double) (this.height + 2) - (double) sizeF2.Height) / 2.0 - 1.0);
        DrawMod.DrawTextVic3(ref Expression, this.buttext, this.ourfont, num, y1, DrawMod.TGame.VicColor2, DrawMod.TGame.VicColor1Shade);
      }
      else if (this.extraS.Length > 0)
      {
        sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
        int x1 = (int) Math.Round(2.0 + ((double) this.width - (double) sizeF2.Width) / 2.0);
        int y2 = (int) Math.Round(2.0 + ((double) this.height - (double) sizeF2.Height) / 2.0 - 8.0);
        DrawMod.DrawTextColouredFuzzy(ref Expression, this.buttext, this.ourfont, x1, y2, Color.FromArgb(200, 0, 0, 0));
        sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
        int x2 = (int) Math.Round(((double) this.width - (double) sizeF2.Width) / 2.0);
        int y3 = (int) Math.Round(((double) this.height - (double) sizeF2.Height) / 2.0 - 8.0);
        DrawMod.DrawTextColouredNicely(ref Expression, this.buttext, this.ourfont, x2, y3, Color.White);
        sizeF2 = Expression.MeasureString(this.extraS, this.ourfont2);
        int x3 = (int) Math.Round(2.0 + ((double) this.width - (double) sizeF2.Width) / 2.0);
        int y4 = (int) Math.Round(2.0 + ((double) this.height - (double) sizeF2.Height) / 2.0 + 8.0);
        DrawMod.DrawTextColouredFuzzy(ref Expression, this.extraS, this.ourfont2, x3, y4, Color.FromArgb(200, 0, 0, 0));
        sizeF2 = Expression.MeasureString(this.extraS, this.ourfont2);
        num = (int) Math.Round(((double) this.width - (double) sizeF2.Width) / 2.0);
        y1 = (int) Math.Round(((double) this.height - (double) sizeF2.Height) / 2.0 + 8.0);
        DrawMod.DrawTextColouredNicely(ref Expression, this.extraS, this.ourfont2, num, y1, Color.White);
      }
      else if (this.tuseshadow)
      {
        sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
        int x = (int) Math.Round(0.0 + ((double) this.width - (double) sizeF2.Width) / 2.0);
        int y5 = (int) Math.Round(2.0 + ((double) this.height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextColouredFuzzy(ref Expression, this.buttext, this.ourfont, x, y5, Color.FromArgb(200, 0, 0, 0));
        sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
        num = (int) Math.Round(((double) this.width - (double) sizeF2.Width) / 2.0 - 2.0);
        y1 = (int) Math.Round(0.0 + ((double) this.height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextColouredNicely(ref Expression, this.buttext, this.ourfont, num, y1, c);
      }
      else
      {
        SizeF sizeF3 = Expression.MeasureString(this.buttext, this.ourfont);
        int x4 = (int) Math.Round(((double) this.width - (double) sizeF3.Width) / 2.0);
        int y6 = (int) Math.Round(((double) this.height - (double) sizeF3.Height) / 2.0 - 1.0);
        DrawMod.DrawTextColoured(ref Expression, this.buttext, this.ourfont, x4, y6, Color.Black);
        SizeF sizeF4 = Expression.MeasureString(this.buttext, this.ourfont);
        int x5 = (int) Math.Round(((double) this.width - (double) sizeF4.Width) / 2.0);
        int y7 = (int) Math.Round(((double) this.height - (double) sizeF4.Height) / 2.0 + 1.0);
        DrawMod.DrawTextColoured(ref Expression, this.buttext, this.ourfont, x5, y7, Color.Black);
        SizeF sizeF5 = Expression.MeasureString(this.buttext, this.ourfont);
        int x6 = (int) Math.Round(((double) this.width - (double) sizeF5.Width) / 2.0 + 1.0);
        int y8 = (int) Math.Round(((double) this.height - (double) sizeF5.Height) / 2.0);
        DrawMod.DrawTextColoured(ref Expression, this.buttext, this.ourfont, x6, y8, Color.Black);
        SizeF sizeF6 = Expression.MeasureString(this.buttext, this.ourfont);
        int x7 = (int) Math.Round(((double) this.width - (double) sizeF6.Width) / 2.0 - 1.0);
        int y9 = (int) Math.Round(((double) this.height - (double) sizeF6.Height) / 2.0);
        DrawMod.DrawTextColoured(ref Expression, this.buttext, this.ourfont, x7, y9, Color.Black);
        sizeF2 = Expression.MeasureString(this.buttext, this.ourfont);
        num = (int) Math.Round(((double) this.width - (double) sizeF2.Width) / 2.0);
        y1 = (int) Math.Round(((double) this.height - (double) sizeF2.Height) / 2.0);
        DrawMod.DrawTextColoured(ref Expression, this.buttext, this.ourfont, num, y1, c);
      }
      if (!this.marcStyle && this.red)
      {
        if (this.height == 26)
          DrawMod.drawLine(ref Expression, num, (int) Math.Round((double) y1 + (double) sizeF2.Height - 1.0), (int) Math.Round((double) ((float) num + sizeF2.Width)), (int) Math.Round((double) y1 + (double) sizeF2.Height - 1.0), (int) DrawMod.TGame.viccolor7.R, (int) DrawMod.TGame.viccolor7.G, (int) DrawMod.TGame.viccolor7.B, (int) DrawMod.TGame.viccolor7.A);
        else
          DrawMod.drawLine(ref Expression, num, (int) Math.Round((double) y1 + (double) sizeF2.Height + 2.0), (int) Math.Round((double) ((float) num + sizeF2.Width)), (int) Math.Round((double) y1 + (double) sizeF2.Height + 2.0), (int) DrawMod.TGame.viccolor7.R, (int) DrawMod.TGame.viccolor7.G, (int) DrawMod.TGame.viccolor7.B, (int) DrawMod.TGame.viccolor7.A);
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
