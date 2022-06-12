// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MatrixSubPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
  public class MatrixSubPartClass : SubPartClass
  {
    private int ListSize;
    private int ListSelect;
    private int ColSelect;
    public int TopItemX;
    public int TopItemY;
    private StringListClass ListObj;
    private Font OwnFont;
    private Font ownfont2;
    private int ItemSize;
    private const int ItemFontOffset = 1;
    private const int LeftTextOffset = 5;
    private int Width;
    private int Height;
    private GameClass game;
    private bool Highlight;
    private int bx;
    private int by;
    private Bitmap backbitmap;
    private int clickscroll;
    private int rowheight;
    private int fontsize;
    private int fontoffsety;
    private bool nolines;
    private bool Marcy;
    private int colWidth;
    private int minimumColWidth;
    private int totalColWidth;
    private int LibSlot;
    private int twoColumnVariant;

    public override void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    public override void ShiftUp()
    {
      --this.ListSelect;
      if (this.ListSelect - this.TopItemY >= 0)
        return;
      --this.TopItemY;
    }

    public override void ShiftDown()
    {
      ++this.ListSelect;
      if (this.ListSelect - this.TopItemY <= this.ListSize)
        return;
      ++this.TopItemY;
    }

    public override void ShiftLeft()
    {
      --this.ColSelect;
      if (this.ColSelect - this.TopItemX >= 0)
        return;
      --this.TopItemX;
    }

    public override void ShiftRight()
    {
      int num1 = (int) Math.Round(Conversion.Int((double) (this.Width - 20) / (double) (this.ListObj.Width + 1)));
      if (num1 < this.colWidth)
        num1 = this.colWidth;
      int num2 = (int) Math.Round((double) (this.Width - 20) / (double) num1) - 2;
      if (num2 < 0)
        num2 = 0;
      ++this.ColSelect;
      if (this.ColSelect - this.TopItemX <= num2)
        return;
      ++this.TopItemX;
    }

    public override void Refresh(StringListClass tListObj, int tlistselect, int tcolselect)
    {
      this.ListObj = tListObj;
      this.ListSelect = tlistselect;
      this.ColSelect = tcolselect;
      if (this.TopItemY > this.ListObj.Length - this.ListSize)
        this.TopItemY = this.ListObj.Length - this.ListSize;
      if (0 > this.TopItemY)
        this.TopItemY = 0;
      this.Clear();
    }

    public override void DescriptInfo(int x, int y)
    {
      if (this.game.Data.Round < 1)
        return;
      if (x > 0 & y > 0 & x < this.Width & y < this.Height)
      {
        Coordinate coordinate = this.Click2(x, y, 0);
        if (coordinate.x >= 0 & coordinate.y >= 0 & coordinate.y <= this.ListObj.TempDesc.GetUpperBound(1) & coordinate.x <= this.ListObj.TempDesc.GetUpperBound(0))
          this.Descript = this.ListObj.TempDesc[coordinate.x, coordinate.y];
        else
          this.Descript = "";
      }
      else
        this.Descript = "";
    }

    public MatrixSubPartClass(
      StringListClass tListobj,
      int tlistsize,
      int twidth,
      int tlistselect,
      int tcolselect,
      GameClass tgame,
      bool systemfont = false,
      bool tHighlight = true,
      int tTop = 0,
      ref Bitmap tbackbitmap = null,
      int bbx = -1,
      int bby = -1,
      int trowheight = 16,
      int tfontsize = 12,
      int tfontoffsety = 0,
      bool tnolines = false,
      bool tMarcy = false,
      int tMinColValue = -1,
      int tTwoColumnVariant = 0,
      int tLibSlot = -1)
      : base(twidth, (tlistsize + 3) * trowheight)
    {
      this.LibSlot = -1;
      this.nolines = tnolines;
      if (!Information.IsNothing((object) tbackbitmap))
      {
        if (!Information.IsNothing((object) this.backbitmap))
          this.backbitmap.Dispose();
        this.backbitmap = new Bitmap(this.OwnBitmap.Width, this.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
        this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics graphics = Graphics.FromImage((Image) this.backbitmap);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.DrawImage((Image) tbackbitmap, new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), new Rectangle(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
        graphics.CompositingMode = CompositingMode.SourceOver;
        graphics.Dispose();
      }
      this.bx = bbx;
      this.by = bby;
      this.LibSlot = tLibSlot;
      this.Marcy = tMarcy;
      this.ItemSize = trowheight;
      this.fontsize = tfontsize;
      this.fontoffsety = tfontoffsety;
      this.Width = twidth;
      this.Height = (tlistsize + 3) * this.ItemSize;
      this.ListSize = tlistsize;
      this.ListSelect = tlistselect;
      this.ListObj = tListobj;
      this.MouseOver = true;
      this.ColSelect = tcolselect;
      this.clickscroll = 0;
      this.Highlight = tHighlight;
      this.TopItemY = tTop;
      this.twoColumnVariant = tTwoColumnVariant;
      this.game = tgame;
      if (tTop == 0)
      {
        this.TopItemY = (int) Math.Round((double) this.ListSelect - Conversion.Int((double) this.ListSize / 2.0));
        if (this.TopItemY < 0)
          this.TopItemY = 0;
      }
      if ((int) Math.Round(Conversion.Int((double) (this.Width - 20) / (double) (this.ListObj.Width + 1))) < this.colWidth)
      {
        int colWidth = this.colWidth;
        if (this.ColSelect > 0)
        {
          this.TopItemX = (int) Math.Round((double) this.ColSelect - Conversion.Int((double) this.ColSelect / 2.0));
          if (this.TopItemX < 0)
            this.TopItemX = 0;
        }
      }
      else
        this.TopItemX = 0;
      if (!systemfont)
      {
        if (this.Marcy)
        {
          if (this.game.Data.Round == 0)
          {
            this.OwnFont = this.game.MarcFont5;
            this.ownfont2 = this.game.MarcFont7;
          }
          else
          {
            this.OwnFont = this.game.MarcFont4;
            this.ownfont2 = this.game.MarcFont4;
          }
        }
        else
        {
          this.OwnFont = new Font(this.game.FontCol.Families[1], (float) this.fontsize, FontStyle.Regular, GraphicsUnit.Pixel);
          this.ownfont2 = new Font(this.game.FontCol.Families[1], (float) (int) Math.Round((double) this.fontsize * 0.9), FontStyle.Regular, GraphicsUnit.Pixel);
        }
      }
      else
      {
        this.OwnFont = new Font("Courier New", 12f, FontStyle.Regular, GraphicsUnit.Pixel);
        this.ownfont2 = new Font("Courier New", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
      }
      this.minimumColWidth = 70;
      if (tMinColValue > 0)
        this.minimumColWidth = tMinColValue;
      this.colWidth = (int) Math.Round(Conversion.Int((double) (this.Width - 20) / (double) (this.ListObj.Width + 1)));
      if (this.minimumColWidth > this.colWidth)
      {
        this.colWidth = this.minimumColWidth;
        --this.ListSize;
      }
      this.totalColWidth = this.colWidth * (this.ListObj.Width + 1);
    }

    public override Bitmap Paint()
    {
      SizeF sizeF1 = new SizeF();
      Color.FromArgb(0, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Color.FromArgb(0, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.ListSize >= this.ListObj.Length)
        this.TopItemY = 0;
      if (Information.IsNothing((object) this.backbitmap))
      {
        Expression.Clear(Color.Transparent);
      }
      else
      {
        Expression.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple(ref Expression, ref this.backbitmap, 0, 0);
        Expression.CompositingMode = CompositingMode.SourceOver;
      }
      if (this.Marcy)
      {
        DrawMod.DrawBlockGradient2(ref Expression, 0, 0, this.Width - 1, this.ItemSize, this.game.MarcCol3, this.game.MarcCol2);
        DrawMod.DrawBlockGradient2(ref Expression, 0, this.ItemSize, this.Width, this.Height - 2 * this.ItemSize, this.game.MarcCol1, this.game.MarcCol2);
      }
      else if (!this.nolines)
        DrawMod.DrawBlock(ref Expression, 0, this.ItemSize, this.Width, this.Height - 2 * this.ItemSize, 0, 0, 0, 166);
      else
        DrawMod.DrawBlock(ref Expression, 0, this.ItemSize, this.Width, this.Height - 2 * this.ItemSize, 0, 0, 0, 100);
      int num1 = 20;
      if (this.ListSize >= this.ListObj.Length)
        num1 = 0;
      int num2 = 2;
      int num3 = 1;
      int num4 = -1;
      int topItemY = this.TopItemY;
      int num5 = this.TopItemY + this.ListSize + num2;
      Bitmap bitmap;
      for (int index1 = topItemY; index1 <= num5; ++index1)
      {
        ++num4;
        if (num4 == 0)
        {
          if (this.ListObj.Width > -1)
          {
            int num6 = (int) Math.Round(Conversion.Int((double) (this.Width - 20) / (double) (this.ListObj.Width + 1)));
            if (num6 < this.colWidth)
              num6 = this.colWidth;
            if (this.ListObj.Width > this.ListObj.ColumnName.GetUpperBound(0))
              this.ListObj.ColumnName = (string[]) Utils.CopyArray((Array) this.ListObj.ColumnName, (Array) new string[this.ListObj.Width + 1]);
            int width = this.ListObj.Width;
            for (int index2 = 0; index2 <= width; ++index2)
            {
              if (Operators.CompareString(this.ListObj.ColumnName[index2], (string) null, false) == 0)
                this.ListObj.ColumnName[index2] = "";
              int x1 = 5 + num6 * index2 - num6 * this.TopItemX;
              if (this.twoColumnVariant > 0 && index2 == 1)
                x1 = this.twoColumnVariant + 5;
              if (x1 > 0 & x1 <= this.Width)
              {
                if (Conversions.ToDouble(this.ListObj.TempColumBmp[index2]) > 0.0)
                {
                  ref Graphics local1 = ref Expression;
                  bitmap = BitmapStore.GetBitmap(Conversions.ToInteger(this.ListObj.TempColumBmp[index2]));
                  ref Bitmap local2 = ref bitmap;
                  int x2 = x1;
                  int y = this.ItemSize * num4 + 1 + 1;
                  DrawMod.DrawSimple(ref local1, ref local2, x2, y);
                }
                else
                {
                  string str = this.ListObj.ColumnName[index2];
                  if (this.game.Data.Round == 0)
                  {
                    for (SizeF sizeF2 = Expression.MeasureString(str, this.OwnFont); (double) sizeF2.Width > (double) num6 & str.Length > 0; sizeF2 = Expression.MeasureString(str, this.OwnFont))
                      str = Strings.Left(str, Strings.Len(str) - 1);
                    if (this.ListObj.ColumnName[index2].Length <= str.Length & this.game.Data.Round == 0)
                    {
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.Number)
                        str += "<num>";
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.Text)
                        str += "<txt>";
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.RegimeId)
                        str += "<reg>";
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.YesNo)
                        str += "<yes/no>";
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.DateString)
                        str += "<date>";
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.HistoricalUnitId)
                        str += "<his>";
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.LandscapeId)
                        str += "<land>";
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.OfficerId)
                        str += "<com>";
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.HistoricalUnitModelId)
                        str += "<mod>";
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.PeopleId)
                        str += "<ppl>";
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.RiverId)
                        str += "<riv>";
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.RoadId)
                        str += "<road>";
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.SFTypeId)
                        str += "<sftyp>";
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.SmallGfxId)
                        str += "<smgfx>";
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.EventPicId)
                        str += "<evpic>";
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.ActionCardId)
                        str += "<acard>";
                      if (this.ListObj.ColValueType[index2] == NewEnums.LibVarValueType.LocationTypeId)
                        str += "<loctyp>";
                    }
                    for (SizeF sizeF3 = Expression.MeasureString(str, this.OwnFont); (double) sizeF3.Width > (double) num6 & str.Length > 0; sizeF3 = Expression.MeasureString(str, this.OwnFont))
                      str = Strings.Left(str, Strings.Len(str) - 1);
                  }
                  if (this.Marcy)
                    DrawMod.DrawTextColouredMarc(ref Expression, str, this.OwnFont, x1, this.ItemSize * num4 + 1 - 1 + this.fontoffsety, Color.White);
                  else
                    DrawMod.DrawText(ref Expression, str, this.OwnFont, x1, this.ItemSize * num4 + 1 - 1 + this.fontoffsety);
                }
              }
            }
          }
          if (this.TopItemY > 0)
          {
            if (num1 > 0)
            {
              ref Graphics local3 = ref Expression;
              bitmap = BitmapStore.GetBitmap(this.game.LISTUP);
              ref Bitmap local4 = ref bitmap;
              int x = this.Width - 20;
              DrawMod.DrawSimple(ref local3, ref local4, x, 3);
            }
          }
          else if (num1 > 0)
          {
            ref Graphics local5 = ref Expression;
            bitmap = BitmapStore.GetBitmap(this.game.LISTBLOCK);
            ref Bitmap local6 = ref bitmap;
            int x = this.Width - 20;
            DrawMod.DrawSimple(ref local5, ref local6, x, 3);
          }
        }
        else if (num4 == this.ListSize + 2)
        {
          if (this.TopItemY + this.ListSize >= this.ListObj.Length)
          {
            if (num1 > 0)
            {
              ref Graphics local7 = ref Expression;
              bitmap = BitmapStore.GetBitmap(this.game.LISTBLOCK);
              ref Bitmap local8 = ref bitmap;
              int x = this.Width - 20;
              int y = this.ItemSize * num4 + 3;
              DrawMod.DrawSimple(ref local7, ref local8, x, y);
            }
          }
          else if (num1 > 0)
          {
            ref Graphics local9 = ref Expression;
            bitmap = BitmapStore.GetBitmap(this.game.LISTDOWN);
            ref Bitmap local10 = ref bitmap;
            int x = this.Width - 20;
            int y = this.ItemSize * num4 + 3;
            DrawMod.DrawSimple(ref local9, ref local10, x, y);
          }
        }
        else if (index1 - num3 <= this.ListObj.Length && this.ListObj.Width > -1)
        {
          if (!this.nolines)
            DrawMod.drawLine(ref Expression, 0, this.ItemSize * num4 + this.ItemSize, this.Width - 20, this.ItemSize * num4 + this.ItemSize, 128, 128, 128, (int) byte.MaxValue);
          int w1 = (int) Math.Round(Conversion.Int((double) (this.Width - 20) / (double) (this.ListObj.Width + 1)));
          if (w1 < this.colWidth)
            w1 = this.colWidth;
          int width = this.ListObj.Width;
          int col;
          for (col = 0; col <= width; ++col)
          {
            int x3 = 5 + w1 * col - w1 * this.TopItemX;
            if (this.twoColumnVariant > 0)
            {
              if (col == 0)
                w1 = this.twoColumnVariant;
              if (col == 1)
              {
                x3 = this.twoColumnVariant + 5;
                w1 = this.Width - (20 - this.twoColumnVariant);
              }
            }
            if (x3 > 0 & x3 <= this.Width)
            {
              if (col == 0 & !this.Marcy && this.ListSelect == index1 - num3)
                DrawMod.DrawBlockGradient2(ref Expression, 0, this.ItemSize * num4, this.Width - num1, this.ItemSize, Color.FromArgb(55, 0, (int) byte.MaxValue, 0), Color.FromArgb(55, 0, (int) byte.MaxValue, 0));
              if (this.ListSelect == index1 - num3 & this.ColSelect == col)
              {
                if (!this.nolines)
                {
                  if (this.Marcy)
                    DrawMod.DrawBlockGradient2(ref Expression, x3 - 5, this.ItemSize * num4, w1, this.ItemSize, Color.FromArgb(165, (int) byte.MaxValue, 200, (int) byte.MaxValue), Color.FromArgb(10, (int) byte.MaxValue, 200, (int) byte.MaxValue));
                  else
                    DrawMod.DrawBlockGradient2(ref Expression, x3 - 5, this.ItemSize * num4, w1, this.ItemSize, Color.FromArgb(175, 0, (int) byte.MaxValue, 0), Color.FromArgb(50, 0, (int) byte.MaxValue, 0));
                }
              }
              else if (this.game.Data.Product >= 5 && !this.Marcy & this.ColSelect > -1 & this.ColSelect <= this.ListObj.Width & this.ListSelect > -1)
              {
                string valueText = this.ListObj.GetValue(ref this.game.Data, this.ListSelect, this.ColSelect, this.LibSlot).valueText;
                if (valueText.Length > 0 & Strings.InStr(this.ListObj.GetValue(ref this.game.Data, index1 - num3, col).valueText, valueText) > 0)
                  DrawMod.DrawBlockGradient2(ref Expression, x3 - 5, this.ItemSize * num4, w1, this.ItemSize, Color.FromArgb(135, (int) byte.MaxValue, (int) byte.MaxValue, 0), Color.FromArgb(50, (int) byte.MaxValue, (int) byte.MaxValue, 0));
              }
              if (this.ListObj.TempBmp[index1 - num3, col] > 0)
              {
                int num7;
                int num8;
                int nr;
                if (this.game.Data.Round == 0)
                {
                  num7 = w1 - 4;
                  num8 = this.ItemSize - 2;
                  nr = this.ListObj.TempBmp[index1 - num3, col];
                  if (BitmapStore.GetWidth(nr) < num7)
                    num7 = BitmapStore.GetWidth(nr);
                  if (BitmapStore.Getheight(nr) < num8)
                    num8 = BitmapStore.Getheight(nr);
                }
                else
                {
                  nr = this.ListObj.TempBmp[index1 - num3, col];
                  num7 = BitmapStore.GetWidth(nr);
                  num8 = BitmapStore.Getheight(nr);
                }
                ref Graphics local11 = ref Expression;
                bitmap = BitmapStore.GetBitmap(nr);
                ref Bitmap local12 = ref bitmap;
                int x4 = x3;
                int y = this.ItemSize * num4 + 1 + 1;
                int w2 = num7;
                int h = num8;
                DrawMod.DrawScaled(ref local11, ref local12, x4, y, w2, h);
              }
              else
              {
                string str = this.ListObj.GetValue(ref this.game.Data, index1 - num3, col, this.LibSlot).valueText;
                try
                {
                  while ((double) Expression.MeasureString(str, this.ownfont2).Width > (double) w1)
                    str = (double) Expression.MeasureString(str, this.ownfont2).Width <= (double) w1 * 2.2 ? Strings.Left(str, str.Length - 1) : Strings.Left(str, (int) Math.Round((double) str.Length / 2.0));
                  if (this.Marcy)
                    DrawMod.DrawTextColouredMarc(ref Expression, str, this.ownfont2, x3, this.ItemSize * num4 + 1 - 1 + this.fontoffsety, Color.White);
                  else
                    DrawMod.DrawText(ref Expression, str, this.ownfont2, x3, this.ItemSize * num4 + 1 - 1 + this.fontoffsety);
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  ProjectData.ClearProjectError();
                }
              }
              if (!this.nolines & col > 0)
                DrawMod.drawLine(ref Expression, x3 - 5, this.ItemSize * num4, x3 - 5, 1 * this.ItemSize + this.ItemSize * num4 - 1, 128, 128, 128, (int) byte.MaxValue);
            }
          }
          if (!this.nolines & col > 0)
            DrawMod.drawLine(ref Expression, w1 * col, this.ItemSize * num4, w1 * col, 1 * this.ItemSize + this.ItemSize * num4 - 1, 128, 128, 128, (int) byte.MaxValue);
        }
      }
      int num9 = (this.ListSize + 1) * this.ItemSize;
      float num10 = this.ListObj.Length <= 0 ? 1f : (float) this.ListSize / (float) this.ListObj.Length;
      if ((double) num10 > 1.0)
        num10 = 1f;
      int num11 = (int) Math.Round((double) Conversion.Int((float) num9 * num10));
      float num12 = this.ListObj.Length <= 0 ? 0.0f : (float) this.TopItemY / (float) this.ListObj.Length;
      if ((double) num12 > 1.0)
        num12 = 1f;
      int num13 = (int) Math.Round((double) Conversion.Int((float) num9 * num12)) + this.ItemSize;
      if (num9 < 5)
        num9 = 5;
      if (num13 + num11 > num9 + this.ItemSize)
        num11 = num9 + this.ItemSize - num13;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (this.ListSize < this.ListObj.Length)
      {
        int x = this.Width - 18;
        int y = num13 + 3;
        int width = 16;
        int num14 = num11 - 2;
        ref Graphics local13 = ref Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SLIDER1);
        ref Bitmap local14 = ref bitmap;
        rectangle1 = new Rectangle(0, 8, 28, 12);
        Rectangle srcrect1 = rectangle1;
        rectangle2 = new Rectangle(x, y + 8, width, num14 - 16);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect1, destrect1);
        ref Graphics local15 = ref Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SLIDER1);
        ref Bitmap local16 = ref bitmap;
        rectangle2 = new Rectangle(0, 0, 28, 8);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(x, y, width, 8);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect2, destrect2);
        ref Graphics local17 = ref Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SLIDER1);
        ref Bitmap local18 = ref bitmap;
        rectangle2 = new Rectangle(0, 28, 28, 8);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(x, y + num14 - 8, 28, 8);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect3, destrect3);
      }
      if (this.totalColWidth > this.Width - 20)
      {
        int num15 = (int) Math.Round(Conversion.Int((double) (this.Width - 20) / (double) (this.ListObj.Width + 1)));
        if (num15 < this.colWidth)
          num15 = this.colWidth;
        int num16 = (int) Math.Round((double) (this.Width - 20) / (double) num15) - 2;
        if (num16 < 0)
          num16 = 0;
        int num17 = 4;
        int y = this.Height - 2 * this.ItemSize;
        int num18 = this.Width - 20 - 24;
        int num19 = (int) Math.Round((double) this.Width * ((double) (this.Width - 20) / (double) this.totalColWidth));
        int num20 = this.Width - 20 - 24 - num19;
        double num21 = (double) this.TopItemX / (double) (this.ListObj.Width - num16) * (double) num20;
        DrawMod.DrawBlock(ref Expression, 0, y - 1, this.Width - 20, 24, 0, 0, 0, 128);
        int x = (int) Math.Round((double) num17 + num21);
        ref Graphics local19 = ref Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.VSLIDER);
        ref Bitmap local20 = ref bitmap;
        rectangle2 = new Rectangle(8, 0, 8, 22);
        Rectangle srcrect4 = rectangle2;
        rectangle1 = new Rectangle(x + 8, y, num19 + 4, 22);
        Rectangle destrect4 = rectangle1;
        DrawMod.DrawSimplePart2(ref local19, ref local20, srcrect4, destrect4);
        ref Graphics local21 = ref Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.VSLIDER);
        ref Bitmap local22 = ref bitmap;
        rectangle2 = new Rectangle(0, 0, 8, 22);
        Rectangle srcrect5 = rectangle2;
        rectangle1 = new Rectangle(x, y, 8, 22);
        Rectangle destrect5 = rectangle1;
        DrawMod.DrawSimplePart2(ref local21, ref local22, srcrect5, destrect5);
        ref Graphics local23 = ref Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.VSLIDER);
        ref Bitmap local24 = ref bitmap;
        rectangle2 = new Rectangle(14, 0, 8, 22);
        Rectangle srcrect6 = rectangle2;
        rectangle1 = new Rectangle(x + num19 + 8, y, 8, 22);
        Rectangle destrect6 = rectangle1;
        DrawMod.DrawSimplePart2(ref local23, ref local24, srcrect6, destrect6);
      }
      if (!this.nolines)
      {
        if (this.ListSize < this.ListObj.Length)
        {
          if (!this.Marcy)
            DrawMod.DrawRectangle(ref Expression, 0, this.ItemSize, this.Width - 21, this.Height - this.ItemSize * 2, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        }
        else if (!this.Marcy)
          DrawMod.DrawRectangle(ref Expression, 0, this.ItemSize, this.Width - 1, this.Height - this.ItemSize * 2, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      }
      if (this.Marcy)
        DrawMod.DrawFrame(ref this.OwnBitmap, ref this.backbitmap, ref Expression, 0, 0, this.Width, this.Height - 1 * this.ItemSize, -1, -1);
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return this.OwnBitmap;
    }

    public override Coordinate Click2(int x, int y, int b = 1)
    {
      int num1 = y;
      int num2 = x;
      y = (int) Math.Round(Conversion.Int((double) y / (double) this.ItemSize));
      this.Scroller = true;
      int num3 = 1;
      int num4 = 20;
      if (this.ListSize >= this.ListObj.Length)
        num4 = 0;
      if (y > 0 & y < this.ListSize + 2)
      {
        if (x <= this.Width - num4)
        {
          y -= num3;
          y += this.TopItemY;
          float num5 = (float) Conversion.Int((double) (this.Width - 20) / (double) (this.ListObj.Width + 1));
          if ((double) num5 < (double) this.colWidth)
            num5 = (float) this.colWidth;
          this.clickscroll = 0;
          if (y > this.ListObj.Length)
          {
            Coordinate coordinate;
            coordinate.x = -1;
            coordinate.y = -1;
            return coordinate;
          }
          this.ListSelect = y;
          Coordinate coordinate1;
          coordinate1.x = this.ListSelect;
          if (this.twoColumnVariant > 0)
          {
            if (x <= this.twoColumnVariant)
            {
              coordinate1.y = 1;
              this.ColSelect = 1;
            }
            else
            {
              coordinate1.y = 1;
              this.ColSelect = 1;
            }
          }
          else
          {
            coordinate1.y = (int) Math.Round((double) (Conversion.Int((float) x / num5) + (float) this.TopItemX));
            this.ColSelect = (int) Math.Round((double) (Conversion.Int((float) x / num5) + (float) this.TopItemX));
          }
          return coordinate1;
        }
        this.clickscroll = 1;
        int num6 = (this.ListSize + 1) * this.ItemSize;
        int num7 = num1 - this.ItemSize;
        if (num7 < 1)
          num7 = 1;
        int num8 = (int) Math.Round((double) (int) Math.Round((double) ((float) num7 / (float) num6 * (float) this.ListObj.Length)) - (double) this.ListSize / 2.0);
        if (0 > num8)
          num8 = 0;
        this.TopItemY = num8;
        if (this.TopItemY > this.ListObj.Length - this.ListSize)
          this.TopItemY = this.ListObj.Length - this.ListSize;
        if (0 > this.TopItemY)
          this.TopItemY = 0;
        Coordinate coordinate2;
        coordinate2.x = -1;
        coordinate2.y = -1;
        return coordinate2;
      }
      if (y == 0)
      {
        --this.TopItemY;
        this.clickscroll = 0;
        if (0 > this.TopItemY)
          this.TopItemY = 0;
        Coordinate coordinate;
        coordinate.x = -1;
        coordinate.y = -1;
        return coordinate;
      }
      if (y == this.ListSize + 2)
      {
        if (this.totalColWidth > this.Width - 20)
        {
          this.clickscroll = 2;
          if (x > this.Width - 20 + 8)
            x = this.Width - 20 + 8;
          if (4 > x)
            x = 4;
          float num9 = (float) Conversion.Int((double) (this.Width - 20) / (double) (this.ListObj.Width + 1));
          if ((double) num9 < (double) this.colWidth)
            num9 = (float) this.colWidth;
          int num10 = (int) Math.Round((double) ((float) (this.Width - 20) / num9)) - 2;
          if (num10 < 0)
            num10 = 0;
          this.TopItemX = (int) Math.Round(((double) this.ListObj.Width + 0.5) * ((double) num2 / (double) (this.Width - 20)));
          this.TopItemX = (int) Math.Round((double) this.TopItemX - (double) num10 / 2.0);
          if (0 > this.TopItemX)
            this.TopItemX = 0;
          if (this.TopItemX > this.ListObj.Width - num10)
            this.TopItemX = this.ListObj.Width - num10;
          Coordinate coordinate;
          coordinate.x = -1;
          coordinate.y = -1;
          return coordinate;
        }
        ++this.TopItemY;
        this.clickscroll = 0;
        if (this.TopItemY > this.ListObj.Length - this.ListSize)
          this.TopItemY = this.ListObj.Length - this.ListSize;
        if (0 > this.TopItemY)
          this.TopItemY = 0;
        Coordinate coordinate3;
        coordinate3.x = -1;
        coordinate3.y = -1;
        return coordinate3;
      }
      Coordinate coordinate4;
      coordinate4.x = -1;
      coordinate4.y = -1;
      return coordinate4;
    }

    public override int HandleMouseUp(int x, int y)
    {
      if (this.game.EditObj.matrixSubPart_BlockMouseUpScroller1time)
      {
        this.game.EditObj.matrixSubPart_BlockMouseUpScroller1time = false;
        this.Scroller = false;
      }
      if (this.clickscroll == 1 | this.Scroller)
      {
        this.clickscroll = 0;
        this.Scroller = false;
        return 1;
      }
      if (this.clickscroll != 2)
        return -1;
      this.clickscroll = 0;
      this.Scroller = false;
      return 1;
    }

    public override bool MouseMove(int x, int y)
    {
      int num1 = y;
      int num2 = x;
      y = (int) Math.Round(Conversion.Int((double) y / (double) this.ItemSize));
      int num3 = 0;
      int num4 = 2;
      int num5 = 20;
      if (this.ListSize >= this.ListObj.Length)
        num5 = 0;
      if (y > num3 & y < this.ListSize + num4 & this.clickscroll == 1)
      {
        int num6 = (this.ListSize + 1) * this.ItemSize;
        int num7 = num1 - this.ItemSize;
        if (num7 < 1)
          num7 = 1;
        int num8 = (int) Math.Round((double) (int) Math.Round((double) ((float) num7 / (float) num6 * (float) this.ListObj.Length)) - (double) this.ListSize / 2.0);
        if (0 > num8)
          num8 = 0;
        this.TopItemY = num8;
        if (this.TopItemY > this.ListObj.Length - this.ListSize)
          this.TopItemY = this.ListObj.Length - this.ListSize;
        if (0 > this.TopItemY)
          this.TopItemY = 0;
        return true;
      }
      if (this.clickscroll != 2)
        return false;
      if (x > this.Width - 20 + 8)
        x = this.Width - 20 + 8;
      if (4 > x)
        x = 4;
      float num9 = (float) Conversion.Int((double) (this.Width - 20) / (double) (this.ListObj.Width + 1));
      if ((double) num9 < (double) this.colWidth)
        num9 = (float) this.colWidth;
      int num10 = (int) Math.Round((double) ((float) (this.Width - 20) / num9)) - 2;
      if (num10 < 0)
        num10 = 0;
      this.TopItemX = (int) Math.Round(((double) this.ListObj.Width + 0.5) * ((double) num2 / (double) (this.Width - 20)));
      this.TopItemX = (int) Math.Round((double) this.TopItemX - (double) num10 / 2.0);
      if (0 > this.TopItemX)
        this.TopItemX = 0;
      if (this.TopItemX > this.ListObj.Width - num10)
        this.TopItemX = this.ListObj.Width - num10;
      return true;
    }
  }
}
