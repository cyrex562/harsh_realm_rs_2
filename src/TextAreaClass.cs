// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TextAreaClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
  public class TextAreaClass : SubPartClass
  {
    private int ListSize;
    private int ListSelect;
    public int TopItem;
    private ListClass[] ListObj;
    private int Tab;
    private string[] TabName;
    private int TabCount;
    private Font OwnFont;
    private int ItemSize;
    private const int ItemFontOffset = 1;
    private const int LeftTextOffset = 15;
    private int Width;
    private int Height;
    private string Header;
    private bool HeaderCenter;
    private GameClass game;
    private Bitmap backbitmap;
    private int bx;
    private int by;
    private Color fontcol;
    private Color fontcol2;
    private bool centerit;
    private int clickscroll;
    private bool HideShade;
    private int Style;
    private int scrollw;
    public bool BlockScroller;
    public bool MarcStyle;
    public Rectangle[] TabRect;

    public override void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    public TextAreaClass(
      GameClass tgame,
      int twidth,
      int trows,
      Font tfont,
      string theader,
      bool theadercenter,
      string tText,
      Color tfontcol,
      int tTop = 0,
      int tItemSize = 16,
      ref Bitmap tbackbitmap = null,
      int bbx = -1,
      int bby = -1,
      bool tcenterit = false,
      bool tHideShade = false,
      int tStyle = 0,
      bool tBlockScroller = false)
      : base(twidth, (trows + 2) * tItemSize)
    {
      this.ListObj = new ListClass[10];
      this.TabName = new string[10];
      this.TabRect = new Rectangle[100];
      this.ItemSize = tItemSize;
      this.Width = twidth;
      this.MarcStyle = false;
      this.Height = (trows + 1) * this.ItemSize;
      this.game = tgame;
      this.scrollw = 60;
      if (this.MarcStyle)
        this.scrollw = 45;
      this.BlockScroller = tBlockScroller;
      this.HideShade = tHideShade;
      this.centerit = tcenterit;
      if (!Information.IsNothing((object) tbackbitmap))
      {
        this.backbitmap = new Bitmap(this.OwnBitmap.Width, this.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
        this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics graphics = Graphics.FromImage((Image) this.backbitmap);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.DrawImage((Image) tbackbitmap, new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), new Rectangle(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
        graphics.CompositingMode = CompositingMode.SourceOver;
      }
      if (Information.IsNothing((object) tfontcol))
      {
        this.fontcol = this.game.VicColor2;
        this.fontcol2 = this.game.VicColor2Shade;
      }
      else
      {
        this.fontcol = tfontcol;
        this.fontcol2 = Color.Transparent;
      }
      this.bx = bbx;
      this.by = bby;
      this.Style = tStyle;
      if (this.Style == 1 | this.Style == 2)
        this.scrollw = 35;
      SizeF sizeF = new SizeF();
      string[] strArray = new string[10];
      this.Tab = 0;
      this.TabCount = -1;
      this.TabName[0] = "";
      int num1 = 1;
      if (Information.IsNothing((object) tText))
        tText = "";
      tText = tText.Replace("\t", " ");
      while (num1 == 1)
      {
        num1 = 0;
        int num2 = Strings.InStr(tText, "[tab]");
        if (num2 > 0)
        {
          int num3 = Strings.InStr(tText, "[/tab]");
          if (num3 > num2 & num3 > 0)
          {
            string str1 = Strings.Mid(tText, num2 + Strings.Len("[tab]"), num3 - (num2 + Strings.Len("[tab]")));
            int num4 = Strings.InStr(str1, ",");
            if (num4 > 0)
            {
              ++this.TabCount;
              this.TabName[this.TabCount] = Strings.Left(str1, num4 - 1);
              string str2 = Strings.Mid(str1, num4 + 1);
              strArray[this.TabCount] = str2;
              tText = Strings.Left(tText, num2 - 1) + Strings.Mid(tText, num3 + Strings.Len("[/tab]"));
              num1 = 1;
            }
          }
        }
      }
      if (this.TabCount == -1)
      {
        this.TabCount = 0;
        strArray[0] = tText;
      }
      int tabCount = this.TabCount;
      for (int index = 0; index <= tabCount; ++index)
      {
        this.ListObj[index] = new ListClass();
        Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
        this.OwnFont = tfont != null ? tfont : tgame.VicFont2;
        int num5 = 1;
        this.clickscroll = 0;
        tText = strArray[index];
        while (Strings.Len(tText) > 0)
        {
          int num6 = 1;
          string tname = "";
          while (num6 == 1)
          {
            int num7 = Strings.InStr(tText, "\r\n");
            int num8 = Strings.InStr(tText, " ");
            if (num8 == 0)
              num8 = 9999999;
            bool flag = false;
            if (num7 < num8 & num7 > 0)
            {
              flag = true;
              int num9 = num7;
              num6 = 0;
              int num10 = 0;
              if (num9 != 1)
              {
                if ((double) Expression.MeasureString(tname + Strings.Left(tText, num9 - 1), this.OwnFont).Width <= (double) (this.Width - this.scrollw))
                {
                  tname += Strings.Left(tText, num9 - 1);
                }
                else
                {
                  num10 = 1;
                  flag = false;
                }
              }
              if (num10 == 0)
                tText = num9 >= Strings.Len(tText) ? "" : Strings.Mid(tText, num9 + 2);
            }
            if (!flag)
            {
              int Length = Strings.InStr(tText, " ");
              string str = Length <= 0 ? tText : Strings.Left(tText, Length);
              int num11 = 0;
              num6 = 0;
              if ((double) Expression.MeasureString(tname + str, this.OwnFont).Width <= (double) (this.Width - this.scrollw))
              {
                num5 = 1;
                num11 = 1;
              }
              else if (num5 == 1)
              {
                num5 = 0;
              }
              else
              {
                num5 = 1;
                num11 = 1;
              }
              if (num11 == 1)
              {
                tname += str;
                if (Length > 0)
                {
                  if (Strings.Len(tText) >= Length + 1)
                  {
                    tText = Strings.Mid(tText, Length + 1);
                    num6 = 1;
                  }
                  else
                  {
                    tText = "";
                    num6 = 0;
                  }
                }
                else
                {
                  tText = "";
                  num6 = 0;
                }
              }
            }
          }
          this.ListObj[index].add(tname, 0);
        }
        if (!Information.IsNothing((object) Expression))
          Expression.Dispose();
      }
      this.ListSize = trows;
      if (this.TabCount > 0)
        --this.ListSize;
      this.ListSelect = -1;
      this.TopItem = tTop;
      this.HeaderCenter = theadercenter;
      if (Strings.Len(theader) > 0)
        this.Header = theader;
      if (tTop == 0)
      {
        this.TopItem = (int) Math.Round((double) this.ListSelect - Conversion.Int((double) this.ListSize / 2.0));
        if (this.TopItem < 0)
          this.TopItem = 0;
      }
      this.MouseOver = true;
      this.scrollw -= 20;
    }

    public override int HeightUsed() => Math.Min(this.ListSize + 1, this.ListObj[this.Tab].ListCount + 1) * this.ItemSize;

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
      if (!this.MarcStyle)
      {
        if (this.Style == 1)
          Expression.Clear(Color.Black);
        if (this.Style == 2)
          Expression.Clear(Color.White);
      }
      else if (this.TabCount > 0)
        DrawMod.DrawBlockGradient2(ref Expression, 0, this.ItemSize, this.Width, this.Height - this.ItemSize, this.game.MarcCol1, this.game.MarcCol2);
      else
        DrawMod.DrawBlockGradient2(ref Expression, 0, this.ItemSize, this.Width, this.Height, this.game.MarcCol1, this.game.MarcCol2);
      if (!this.MarcStyle)
      {
        int num1;
        if (this.TabCount == 0)
        {
          if (this.Style == 0 & !this.HideShade)
            DrawMod.DrawBlock(ref Expression, 0, 0, this.Width - (this.scrollw - 5), this.ItemSize * (this.ListSize + 1) + 2, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
          num1 = -1;
        }
        else
        {
          if (this.Style == 0 & !this.HideShade)
            DrawMod.DrawBlock(ref Expression, 0, this.ItemSize, this.Width - (this.scrollw - 5), this.ItemSize * (this.ListSize + 0) + 2, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
          num1 = 0;
          int w = Math.Min(120, (int) Math.Round((double) this.Width * 0.9 / (double) (this.TabCount + 1)));
          int x1 = 0;
          int tabCount1 = this.TabCount;
          for (int index = 0; index <= tabCount1; ++index)
          {
            if (this.Tab != index)
            {
              DrawMod.DrawBlock(ref Expression, x1, 0, w, this.ItemSize, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
              DrawMod.DrawTextVic2(ref Expression, this.TabName[index], new Font(this.OwnFont.Name, this.OwnFont.Size - 2f, FontStyle.Regular, GraphicsUnit.Pixel), x1 + 1, 2, this.fontcol, this.fontcol2);
              DrawMod.DrawRectangle(ref Expression, x1, 0, w, this.ItemSize, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
            }
            x1 += w;
          }
          int num2 = 0;
          int tabCount2 = this.TabCount;
          for (int index = 0; index <= tabCount2; ++index)
          {
            if (index == this.Tab)
            {
              DrawMod.DrawBlock(ref Expression, num2 + 1, 0, w - 2, this.ItemSize, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
              DrawMod.DrawTextVic2(ref Expression, this.TabName[index], new Font(this.OwnFont.Name, this.OwnFont.Size - 2f, FontStyle.Regular, GraphicsUnit.Pixel), num2 + 1, 2, Color.Black, Color.Transparent);
              DrawMod.DrawRectangle(ref Expression, num2 + 1, 0, w - 2, this.ItemSize - 1, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
            }
            num2 += w;
          }
        }
        int num3 = 0;
        if (this.TabCount > 0)
          num3 = -1;
        int topItem = this.TopItem;
        int num4 = this.TopItem + this.ListSize + num3;
        for (int index = topItem; index <= num4; ++index)
        {
          ++num1;
          if (index <= this.ListObj[this.Tab].ListCount)
          {
            string str = this.ListObj[this.Tab].ListName[index];
            if (this.BlockScroller && index == this.TopItem + this.ListSize + num3 & index != this.ListObj[this.Tab].ListCount && Strings.Len(str) > 0)
              str = Strings.Left(str, Strings.Len(str) - 3) + "...";
            if (!this.centerit)
            {
              if (this.Style == 0)
                DrawMod.DrawTextVic2(ref Expression, str, this.OwnFont, 15, this.ItemSize * num1 + 1, this.fontcol, this.fontcol2);
              else
                DrawMod.DrawTextVic2(ref Expression, str, this.OwnFont, 15, this.ItemSize * num1 + 1, this.fontcol, this.fontcol2);
            }
            else
            {
              int num5 = (int) Math.Round((double) (this.Width - this.scrollw) / 2.0 - (double) Expression.MeasureString(this.ListObj[this.Tab].ListName[index], this.OwnFont).Width / 2.0);
              if (0 > num5)
                num5 = 0;
              if (this.Style == 0)
                DrawMod.DrawTextVic2(ref Expression, str, this.OwnFont, num5 + 15, this.ItemSize * num1 + 1, this.fontcol, this.fontcol2);
              else
                DrawMod.DrawTextVic2(ref Expression, str, this.OwnFont, num5 + 15, this.ItemSize * num1 + 1, this.fontcol, this.fontcol2);
            }
          }
        }
      }
      else
      {
        int num6;
        if (this.TabCount == 0)
        {
          SizeF sizeF2 = Expression.MeasureString(Strings.UCase(this.Header), DrawMod.TGame.MarcFont5);
          DrawMod.DrawTextColouredMarc(ref Expression, Strings.UCase(this.Header), DrawMod.TGame.MarcFont5, (int) Math.Round(((double) this.Width - (double) sizeF2.Width) / 2.0), 0, Color.White);
        }
        else
        {
          num6 = 0;
          int num7 = 0;
          int tabCount3 = this.TabCount;
          for (int index = 0; index <= tabCount3; ++index)
          {
            this.TabName[index] = Strings.UCase(this.TabName[index]);
            SizeF sizeF3 = index >= this.TabCount ? Expression.MeasureString(this.TabName[index], DrawMod.TGame.MarcFont5) : Expression.MeasureString(this.TabName[index] + " | ", DrawMod.TGame.MarcFont5);
            num7 = (int) Math.Round((double) ((float) num7 + sizeF3.Width));
          }
          int x = (int) Math.Round(Math.Max(0.0, (double) (this.Width - num7) / 2.0));
          int tabCount4 = this.TabCount;
          for (int index = 0; index <= tabCount4; ++index)
          {
            SizeF sizeF4;
            if (index < this.TabCount)
            {
              if (this.Tab != index)
                DrawMod.DrawTextColouredMarc(ref Expression, this.TabName[index] + " | ", DrawMod.TGame.MarcFont5, x + 1, 0, Color.White);
              if (index == this.Tab)
              {
                DrawMod.DrawTextColouredMarc(ref Expression, this.TabName[index], DrawMod.TGame.MarcFont5, x + 1, 0, DrawMod.TGame.MarcCol5);
                SizeF sizeF5 = Expression.MeasureString(this.TabName[index], DrawMod.TGame.MarcFont5);
                DrawMod.DrawTextColouredMarc(ref Expression, " | ", DrawMod.TGame.MarcFont5, (int) Math.Round((double) (x + 1) + (double) sizeF5.Width - 4.0), 0, Color.White);
              }
              sizeF4 = Expression.MeasureString(this.TabName[index] + " | ", DrawMod.TGame.MarcFont5);
            }
            else
            {
              if (this.Tab != index)
                DrawMod.DrawTextColouredMarc(ref Expression, this.TabName[index], DrawMod.TGame.MarcFont5, x + 1, 0, Color.White);
              if (index == this.Tab)
                DrawMod.DrawTextColouredMarc(ref Expression, this.TabName[index], DrawMod.TGame.MarcFont5, x + 1, 0, DrawMod.TGame.MarcCol5);
              sizeF4 = Expression.MeasureString(this.TabName[index], DrawMod.TGame.MarcFont5);
            }
            this.TabRect[index] = index >= this.TabCount ? new Rectangle(x, 0, (int) Math.Round((double) sizeF4.Width), this.ItemSize) : new Rectangle(x, 0, (int) Math.Round((double) sizeF4.Width - (double) Expression.MeasureString(" | ", DrawMod.TGame.MarcFont5).Width), this.ItemSize);
            x = (int) Math.Round((double) ((float) x + sizeF4.Width));
          }
        }
        int num8 = -1;
        if (this.TabCount > 0)
          num8 = -2;
        int topItem = this.TopItem;
        int num9 = this.TopItem + this.ListSize + num8;
        for (int index = topItem; index <= num9; ++index)
        {
          ++num6;
          if (index <= this.ListObj[this.Tab].ListCount)
          {
            string str = this.ListObj[this.Tab].ListName[index];
            if (this.BlockScroller && index == this.TopItem + this.ListSize + num8 & index != this.ListObj[this.Tab].ListCount)
              str = Strings.Left(str, Strings.Len(str) - 3) + "...";
            if (!this.centerit)
            {
              DrawMod.DrawTextColouredMarc(ref Expression, str, this.OwnFont, 15, this.ItemSize * num6 + 15, this.fontcol);
            }
            else
            {
              int num10 = (int) Math.Round((double) (this.Width - this.scrollw) / 2.0 - (double) Expression.MeasureString(this.ListObj[this.Tab].ListName[index], this.OwnFont).Width / 2.0);
              if (0 > num10)
                num10 = 0;
              DrawMod.DrawTextColouredMarc(ref Expression, str, this.OwnFont, num10 + 15, this.ItemSize * num6 + 15, this.fontcol);
            }
          }
        }
      }
      if (!this.MarcStyle)
      {
        if (this.TabCount == 0)
        {
          if (this.Style == 0 & !this.HideShade)
            DrawMod.DrawRectangle(ref Expression, 0, 0, this.Width - (this.scrollw - 5), this.ItemSize * (this.ListSize + 1) + 2, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
        }
        else if (this.Style == 0 & !this.HideShade)
          DrawMod.DrawRectangle(ref Expression, 0, this.ItemSize, this.Width - (this.scrollw - 5), this.ItemSize * (this.ListSize + 0) + 2, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
      }
      if (this.ListSize < this.ListObj[this.Tab].ListCount & this.Style == 0 & !this.BlockScroller)
      {
        int num11;
        if (this.TabCount > 0)
        {
          if (!this.MarcStyle)
            DrawMod.DrawSteveBlock(ref Expression, this.Width - 29, this.ItemSize * 1, 28, this.ItemSize * (this.ListSize + 0));
          num11 = (this.ListSize + 0) * this.ItemSize;
        }
        else
        {
          if (!this.MarcStyle)
            DrawMod.DrawSteveBlock(ref Expression, this.Width - 29, this.ItemSize * 0, 28, this.ItemSize * (this.ListSize + 1));
          num11 = (this.ListSize + 1) * this.ItemSize;
        }
        float num12 = this.ListObj[this.Tab].ListCount <= 0 ? 1f : (this.TabCount <= 0 ? (float) this.ListSize / (float) this.ListObj[this.Tab].ListCount : (float) (this.ListSize - 1) / (float) this.ListObj[this.Tab].ListCount);
        if ((double) num12 > 1.0)
          num12 = 1f;
        int num13 = (int) Math.Round((double) Conversion.Int((float) num11 * num12));
        float num14 = this.ListObj[this.Tab].ListCount <= 0 ? 0.0f : (float) this.TopItem / (float) this.ListObj[this.Tab].ListCount;
        if ((double) num14 > 1.0)
          num14 = 1f;
        if (this.ListSize < this.ListObj[this.Tab].ListCount)
        {
          int num15 = !this.MarcStyle ? (int) Math.Round((double) Conversion.Int((float) num11 * num14)) : (int) Math.Round((double) Conversion.Int((float) num11 * num14));
          if (num13 < 20)
            num13 = 20;
          if (num15 + 2 + num13 > this.ItemSize * (this.ListSize + 1))
          {
            num15 -= this.ItemSize * (this.ListSize + 1) - (num15 + 2 + num13);
            if (0 > num15)
              num15 = 0;
          }
          int x = 1 + (this.Width - 24);
          int y = num15 + 2;
          int width = 20;
          int num16 = num13 + this.ItemSize;
          if (this.TabCount > 0)
            y += this.ItemSize;
          if (this.TabCount == 0)
          {
            y += this.ItemSize;
            num16 += this.ItemSize;
          }
          if (this.TabCount > 0 && y + num16 > this.Height)
            num16 -= y + num16 - this.Height;
          if (!this.MarcStyle)
          {
            int num17;
            if (this.TabCount == 0)
            {
              y -= this.ItemSize;
              num17 = num16 - this.ItemSize * 2;
            }
            else
              num17 = num16 - this.ItemSize;
            ref Graphics local1 = ref Expression;
            Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.SLIDER1);
            ref Bitmap local2 = ref bitmap1;
            Rectangle rectangle1 = new Rectangle(0, 8, 28, 16);
            Rectangle srcrect1 = rectangle1;
            Rectangle rectangle2 = new Rectangle(x, y + 8, width, num17 - 16);
            Rectangle destrect1 = rectangle2;
            DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
            ref Graphics local3 = ref Expression;
            Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.SLIDER1);
            ref Bitmap local4 = ref bitmap2;
            rectangle2 = new Rectangle(0, 0, 28, 8);
            Rectangle srcrect2 = rectangle2;
            rectangle1 = new Rectangle(x, y, width, 8);
            Rectangle destrect2 = rectangle1;
            DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
            ref Graphics local5 = ref Expression;
            Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.SLIDER1);
            ref Bitmap local6 = ref bitmap3;
            rectangle2 = new Rectangle(0, 28, 28, 8);
            Rectangle srcrect3 = rectangle2;
            rectangle1 = new Rectangle(x, y + num17 - 8, width, 8);
            Rectangle destrect3 = rectangle1;
            DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
          }
          else
          {
            Rectangle rectangle3;
            Rectangle rectangle4;
            if (this.TabCount == 0)
            {
              ref Graphics local7 = ref Expression;
              Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
              ref Bitmap local8 = ref bitmap4;
              rectangle3 = new Rectangle(0, 2, 20, 6);
              Rectangle srcrect4 = rectangle3;
              rectangle4 = new Rectangle(x, 2 + this.ItemSize, 20, this.Height - 4);
              Rectangle destrect4 = rectangle4;
              DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
              ref Graphics local9 = ref Expression;
              Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
              ref Bitmap local10 = ref bitmap5;
              rectangle3 = new Rectangle(0, 0, 20, 2);
              Rectangle srcrect5 = rectangle3;
              rectangle4 = new Rectangle(x, this.ItemSize, 20, 2);
              Rectangle destrect5 = rectangle4;
              DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
              ref Graphics local11 = ref Expression;
              Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
              ref Bitmap local12 = ref bitmap6;
              rectangle3 = new Rectangle(0, 8, 20, 2);
              Rectangle srcrect6 = rectangle3;
              rectangle4 = new Rectangle(x, this.Height + this.ItemSize - 2, 20, 2);
              Rectangle destrect6 = rectangle4;
              DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
            }
            else
            {
              ref Graphics local13 = ref Expression;
              Bitmap bitmap7 = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
              ref Bitmap local14 = ref bitmap7;
              rectangle3 = new Rectangle(0, 2, 20, 6);
              Rectangle srcrect7 = rectangle3;
              rectangle4 = new Rectangle(x, 2 + this.ItemSize, 20, this.Height - (4 + this.ItemSize));
              Rectangle destrect7 = rectangle4;
              DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
              ref Graphics local15 = ref Expression;
              Bitmap bitmap8 = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
              ref Bitmap local16 = ref bitmap8;
              rectangle3 = new Rectangle(0, 0, 20, 2);
              Rectangle srcrect8 = rectangle3;
              rectangle4 = new Rectangle(x, this.ItemSize, 20, 2);
              Rectangle destrect8 = rectangle4;
              DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
              ref Graphics local17 = ref Expression;
              Bitmap bitmap9 = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
              ref Bitmap local18 = ref bitmap9;
              rectangle3 = new Rectangle(0, 8, 20, 2);
              Rectangle srcrect9 = rectangle3;
              rectangle4 = new Rectangle(x, this.Height - 2, 20, 2);
              Rectangle destrect9 = rectangle4;
              DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
            }
            ref Graphics local19 = ref Expression;
            Bitmap bitmap10 = BitmapStore.GetBitmap(DrawMod.TGame.LISTBLOCK);
            ref Bitmap local20 = ref bitmap10;
            rectangle3 = new Rectangle(0, 2, 20, 6);
            Rectangle srcrect10 = rectangle3;
            rectangle4 = new Rectangle(x, y + 2, width, num16 - 2);
            Rectangle destrect10 = rectangle4;
            DrawMod.DrawSimplePart2(ref local19, ref local20, srcrect10, destrect10);
            ref Graphics local21 = ref Expression;
            Bitmap bitmap11 = BitmapStore.GetBitmap(DrawMod.TGame.LISTBLOCK);
            ref Bitmap local22 = ref bitmap11;
            rectangle3 = new Rectangle(0, 0, 20, 2);
            Rectangle srcrect11 = rectangle3;
            rectangle4 = new Rectangle(x, y, width, 2);
            Rectangle destrect11 = rectangle4;
            DrawMod.DrawSimplePart2(ref local21, ref local22, srcrect11, destrect11);
            ref Graphics local23 = ref Expression;
            Bitmap bitmap12 = BitmapStore.GetBitmap(DrawMod.TGame.LISTBLOCK);
            ref Bitmap local24 = ref bitmap12;
            rectangle3 = new Rectangle(0, 8, 20, 2);
            Rectangle srcrect12 = rectangle3;
            rectangle4 = new Rectangle(x, y + num16 - 2, 10, 2);
            Rectangle destrect12 = rectangle4;
            DrawMod.DrawSimplePart2(ref local23, ref local24, srcrect12, destrect12);
          }
        }
      }
      if (this.MarcStyle)
      {
        if (this.TabCount > 0)
          DrawMod.DrawFrame(ref this.OwnBitmap, ref this.backbitmap, ref Expression, 0, this.ItemSize, this.Width - 10, this.Height - this.ItemSize, -1, -1);
        else
          DrawMod.DrawFrame(ref this.OwnBitmap, ref this.backbitmap, ref Expression, 0, this.ItemSize, this.Width - 10, this.Height, -1, -1);
      }
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return this.OwnBitmap;
    }

    public override int HandleMouseUp(int x, int y)
    {
      if (!(this.clickscroll == 1 | this.Scroller & !this.BlockScroller))
        return -1;
      this.clickscroll = 0;
      this.Scroller = false;
      return 1;
    }

    public override int Click(int x, int y, int b = 1)
    {
      int num1 = y;
      y = (int) Math.Round(Conversion.Int((double) y / (double) this.ItemSize));
      if (y >= 0 & y <= this.ListSize + 1)
      {
        if (this.TabCount > 0 & num1 < this.ItemSize)
        {
          if (!this.MarcStyle)
          {
            int num2 = Math.Min(120, (int) Math.Round((double) this.Width * 0.9 / (double) (this.TabCount + 1)));
            int num3 = (int) Math.Round(Conversion.Int((double) x / (double) num2));
            if (num3 <= this.TabCount)
              this.Tab = num3;
            this.TopItem = 0;
            return -1;
          }
          float tabCount = (float) this.TabCount;
          for (float a = 0.0f; (double) a <= (double) tabCount; ++a)
          {
            if (x >= this.TabRect[(int) Math.Round((double) a)].X & y >= this.TabRect[(int) Math.Round((double) a)].Y && x <= this.TabRect[(int) Math.Round((double) a)].X + this.TabRect[(int) Math.Round((double) a)].Width & y <= this.TabRect[(int) Math.Round((double) a)].Y + this.TabRect[(int) Math.Round((double) a)].Height)
            {
              this.Tab = (int) Math.Round((double) a);
              this.TopItem = 0;
              return -1;
            }
          }
        }
        else
        {
          if (x < this.Width - 30)
          {
            y += this.TopItem;
            if (y > this.ListObj[this.Tab].ListCount)
              return -1;
            this.ListSelect = y;
            this.clickscroll = 0;
            return this.ListObj[this.Tab].ListData[this.ListSelect];
          }
          if (!this.BlockScroller)
          {
            this.clickscroll = 1;
            this.Scroller = true;
            int num4;
            int num5;
            if (this.TabCount > 0)
            {
              num4 = (this.ListSize + 0) * this.ItemSize;
              num5 = num1 - this.ItemSize * 2;
            }
            else
            {
              num4 = (this.ListSize + 1) * this.ItemSize;
              num5 = num1 - this.ItemSize * 1;
            }
            if (num5 < 1)
              num5 = 1;
            int num6 = (int) Math.Round((double) (int) Math.Round((double) ((float) num5 / (float) num4 * (float) this.ListObj[this.Tab].ListCount)) - (double) this.ListSize / 2.0);
            if (0 > num6)
              num6 = 0;
            this.TopItem = num6;
            if (this.TabCount > 0)
            {
              if (this.TopItem > this.ListObj[this.Tab].ListCount - (this.ListSize - 1))
                this.TopItem = this.ListObj[this.Tab].ListCount - (this.ListSize - 1);
            }
            else if (this.TopItem > this.ListObj[this.Tab].ListCount - this.ListSize)
              this.TopItem = this.ListObj[this.Tab].ListCount - this.ListSize;
            if (0 > this.TopItem)
              this.TopItem = 0;
            return -1;
          }
        }
      }
      int num7;
      return num7;
    }

    public override bool MouseMove(int x, int y)
    {
      if (this.BlockScroller)
        return false;
      int num1 = y;
      y = (int) Math.Round(Conversion.Int((double) y / (double) this.ItemSize));
      if (!(y >= 0 & y <= this.ListSize & this.clickscroll == 1))
        return false;
      int num2;
      int num3;
      if (this.TabCount > 0)
      {
        num2 = (this.ListSize + 0) * this.ItemSize;
        num3 = num1 - this.ItemSize * 2;
      }
      else
      {
        num2 = (this.ListSize + 1) * this.ItemSize;
        num3 = num1 - this.ItemSize * 1;
      }
      if (num3 < 1)
        num3 = 1;
      int num4 = (int) Math.Round((double) (int) Math.Round((double) ((float) num3 / (float) num2 * (float) this.ListObj[this.Tab].ListCount)) - (double) this.ListSize / 2.0);
      if (0 > num4)
        num4 = 0;
      this.TopItem = num4;
      if (this.TabCount > 0)
      {
        if (this.TopItem > this.ListObj[this.Tab].ListCount - (this.ListSize - 1))
          this.TopItem = this.ListObj[this.Tab].ListCount - (this.ListSize - 1);
      }
      else if (this.TopItem > this.ListObj[this.Tab].ListCount - this.ListSize)
        this.TopItem = this.ListObj[this.Tab].ListCount - this.ListSize;
      if (0 > this.TopItem)
        this.TopItem = 0;
      return true;
    }
  }
}
