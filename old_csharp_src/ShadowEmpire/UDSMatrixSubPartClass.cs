// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.UDSMatrixSubPartClass
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
  public class UDSMatrixSubPartClass : SubPartClass
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
    private int twoColumnVariant;
    private int slotRegimes;
    private int slotPortrait;
    private int slotCharacter;

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
      int num1 = (int) Math.Round(Conversion.Int((double) (this.Width - 0) / (double) (this.ListObj.Width + 1)));
      if (num1 < this.colWidth)
        num1 = this.colWidth;
      int num2 = (int) Math.Round((double) (this.Width - 0) / (double) num1) - 2;
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

    public UDSMatrixSubPartClass(
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
      ref Font customFont = null)
      : base(twidth, (tlistsize + 3) * trowheight)
    {
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
      string libName = "SE_Data";
      this.slotPortrait = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(libName, 204, 0, 0));
      this.slotRegimes = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(libName, 143, 0, 0));
      this.slotCharacter = tgame.HandyFunctionsObj.GetStringListByID(tgame.EventRelatedObj.CheckStringlistID(libName, 196, 0, 0));
      this.bx = bbx;
      this.by = bby;
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
      if ((int) Math.Round(Conversion.Int((double) (this.Width - 0) / (double) (this.ListObj.Width + 1))) < this.colWidth)
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
      if (!Information.IsNothing((object) customFont))
      {
        this.OwnFont = customFont;
        this.ownfont2 = customFont;
      }
      else if (!systemfont)
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
      this.minimumColWidth = 30;
      if (tMinColValue > 0)
        this.minimumColWidth = tMinColValue;
      this.colWidth = (int) Math.Round(Conversion.Int((double) (this.Width - 0) / (double) (this.ListObj.Width + 1)));
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
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.ListSize >= this.ListObj.Length)
        this.TopItemY = 0;
      if (Information.IsNothing((object) this.backbitmap))
      {
        graphics.Clear(Color.Transparent);
      }
      else
      {
        graphics.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple(ref graphics, ref this.backbitmap, 0, 0);
        graphics.CompositingMode = CompositingMode.SourceOver;
      }
      int num1 = (int) Math.Round(((double) this.ItemSize - (double) graphics.MeasureString("X", this.OwnFont).Height) / 2.0) - 1;
      if (num1 < 0)
        num1 = 0;
      int num2 = (int) Math.Round(((double) this.ItemSize - (double) graphics.MeasureString("X", this.ownfont2).Height) / 2.0) - 1;
      if (num2 < 0)
        num1 = 0;
      DrawMod.DrawBlockGradient2(ref graphics, 0, 0, this.Width - 0, this.ItemSize, Color.FromArgb((int) byte.MaxValue, 0, 0, 0), Color.FromArgb(200, 0, 0, 0));
      if (!this.nolines)
        DrawMod.DrawBlock(ref graphics, 0, this.ItemSize, this.Width - 1, this.Height - 2 * this.ItemSize, 0, 0, 0, 20);
      int num3 = 0;
      if (this.ListSize >= this.ListObj.Length)
        num3 = 0;
      int num4 = 2;
      int num5 = 1;
      int num6 = -1;
      int topItemY = this.TopItemY;
      int num7 = this.TopItemY + this.ListSize + num4;
      for (int index1 = topItemY; index1 <= num7; ++index1)
      {
        ++num6;
        Bitmap bitmap;
        if (num6 == 0)
        {
          if (this.ListObj.Width > -1)
          {
            if (this.ListObj.Width > this.ListObj.ColumnName.GetUpperBound(0))
              this.ListObj.ColumnName = (string[]) Utils.CopyArray((Array) this.ListObj.ColumnName, (Array) new string[this.ListObj.Width + 1]);
            int width = this.ListObj.Width;
            for (int index2 = 0; index2 <= width; ++index2)
            {
              if (Operators.CompareString(this.ListObj.ColumnName[index2], (string) null, false) == 0)
                this.ListObj.ColumnName[index2] = "";
              int num8 = (int) Math.Round(Conversion.Int((double) (this.Width - 0) / (double) (this.ListObj.Width + 1)));
              if (num8 < this.colWidth)
                num8 = this.colWidth;
              if (this.ListObj.ColWidth[index2] > 0)
                num8 = this.ListObj.ColWidth[index2];
              int x1 = 5 + num8 * index2 - num8 * this.TopItemX;
              if (this.ListObj.ColWidth[index2] > 0)
              {
                x1 = 5;
                int num9 = index2 - 1;
                for (int index3 = 0; index3 <= num9; ++index3)
                  x1 += this.ListObj.ColWidth[index3];
              }
              if (this.twoColumnVariant > 0 && index2 == 1)
                x1 = this.twoColumnVariant + 5;
              if (x1 > 0 & x1 <= this.Width)
              {
                if (Conversions.ToDouble(this.ListObj.TempColumBmp[index2]) > 0.0)
                {
                  ref Graphics local1 = ref graphics;
                  bitmap = BitmapStore.GetBitmap(Conversions.ToInteger(this.ListObj.TempColumBmp[index2]));
                  ref Bitmap local2 = ref bitmap;
                  int x2 = x1;
                  int y = this.ItemSize * num6 + 1 + 1;
                  DrawMod.DrawSimple(ref local1, ref local2, x2, y);
                }
                else
                {
                  string str = this.ListObj.ColumnName[index2];
                  if (Strings.InStr(str, "\r\n") > 0)
                    DrawMod.DrawTextColouredNicely(ref graphics, str, this.OwnFont, x1, this.ItemSize * num6 + 1 + this.fontoffsety + 4, Color.White);
                  else
                    DrawMod.DrawTextColouredNicely(ref graphics, str, this.OwnFont, x1, this.ItemSize * num6 + 1 + num1 + this.fontoffsety + 2, Color.White);
                }
              }
            }
          }
        }
        else if (num6 != this.ListSize + 2 && index1 - num5 <= this.ListObj.Length && this.ListObj.Width > -1)
        {
          if (!this.nolines & index1 != this.TopItemY + this.ListSize + num4)
            DrawMod.drawLine(ref graphics, 0, this.ItemSize * num6 + this.ItemSize, this.Width - 2, this.ItemSize * num6 + this.ItemSize, 128, 128, 128, (int) byte.MaxValue, 2);
          int width1 = this.ListObj.Width;
          for (int index4 = 0; index4 <= width1; ++index4)
          {
            int num10 = (int) Math.Round(Conversion.Int((double) (this.Width - 0) / (double) (this.ListObj.Width + 1)));
            if (num10 < this.colWidth)
              num10 = this.colWidth;
            if (this.ListObj.ColWidth[index4] > 0)
              num10 = this.ListObj.ColWidth[index4];
            int x3 = 5 + num10 * index4 - num10 * this.TopItemX;
            if (this.ListObj.ColWidth[index4] > 0)
            {
              x3 = 5;
              int num11 = index4 - 1;
              for (int index5 = 0; index5 <= num11; ++index5)
                x3 += this.ListObj.ColWidth[index5];
            }
            if (this.twoColumnVariant > 0)
            {
              if (index4 == 0)
                num10 = this.twoColumnVariant;
              if (index4 == 1)
              {
                x3 = this.twoColumnVariant + 5;
                num10 = this.Width - -this.twoColumnVariant;
              }
            }
            if (x3 > 0 & x3 <= this.Width)
            {
              if (!(index4 == 0 & !this.Marcy) || this.ListSelect != index1 - num5)
                ;
              if (this.ListSelect == index1 - num5 & this.ColSelect == index4)
              {
                if (this.nolines || !this.Marcy)
                  ;
              }
              else if (this.game.Data.Product >= 5 && !this.Marcy & this.ColSelect > -1 & this.ColSelect <= this.ListObj.Width & this.ListSelect > -1)
              {
                string str1 = this.ListObj.Data[this.ListSelect, this.ColSelect];
              }
              string[] strArray1 = this.ListObj.Data[index1 - num5, index4].Split('#');
              if (strArray1.GetUpperBound(0) > 0)
              {
                SizeF sizeF2;
                if (Operators.CompareString(strArray1[0], "1", false) == 0)
                {
                  int num12 = 0;
                  sizeF2 = graphics.MeasureString(strArray1[1], this.ownfont2);
                  DrawMod.DrawTextColouredNicely(ref graphics, strArray1[1], this.ownfont2, x3, this.ItemSize * num6 + 1 + 3 + num2 + this.fontoffsety, Color.Black);
                  int num13 = (int) Math.Round((double) ((float) num12 + sizeF2.Width));
                  int nr = (int) Math.Round(Conversion.Val(strArray1[2]));
                  int width2 = BitmapStore.GetWidth(nr);
                  int num14 = BitmapStore.Getheight(nr);
                  ref Graphics local3 = ref graphics;
                  bitmap = BitmapStore.GetBitmap(nr);
                  ref Bitmap local4 = ref bitmap;
                  int x4 = x3 + num13;
                  int y = this.ItemSize * num6 + (int) Math.Round((double) (this.ItemSize - num14) / 2.0) + 1;
                  int w = width2;
                  int h = num14;
                  DrawMod.DrawScaled(ref local3, ref local4, x4, y, w, h);
                  if (strArray1.GetUpperBound(0) > 2)
                  {
                    int num15 = num13 + width2;
                    DrawMod.DrawTextColouredNicely(ref graphics, strArray1[3], this.ownfont2, x3 + num15, this.ItemSize * num6 + 1 + 3 + num2 + this.fontoffsety, Color.Black);
                  }
                }
                if (Operators.CompareString(strArray1[0], "99", false) == 0)
                {
                  int num16 = 0;
                  int upperBound = strArray1.GetUpperBound(0);
                  for (int index6 = 1; index6 <= upperBound; ++index6)
                  {
                    int nr = (int) Math.Round(Conversion.Val(strArray1[index6]));
                    if (nr > 0)
                    {
                      ref Graphics local5 = ref graphics;
                      bitmap = BitmapStore.GetBitmap(nr);
                      ref Bitmap local6 = ref bitmap;
                      int x5 = x3 + num16;
                      int y = this.ItemSize * num6 + (int) Math.Round((double) (this.ItemSize - 18) / 2.0);
                      DrawMod.DrawSimple(ref local5, ref local6, x5, y);
                    }
                    num16 += 20;
                    if (num16 > num10 - 20)
                      break;
                  }
                }
                if (Operators.CompareString(strArray1[0], "2", false) == 0)
                {
                  int num17 = 0;
                  int num18 = 0;
                  if (strArray1.GetUpperBound(0) >= 1)
                  {
                    if (strArray1.GetUpperBound(0) <= 2)
                      num18 = -12;
                    int upperBound = strArray1.GetUpperBound(0);
                    for (int index7 = 1; index7 <= upperBound; index7 += 2)
                    {
                      int nr1 = (int) Math.Round(Conversion.Val(strArray1[index7]));
                      int nr2 = 0;
                      if (strArray1.GetUpperBound(0) >= 2)
                        nr2 = (int) Math.Round(Conversion.Val(strArray1[index7 + 1]));
                      if (nr1 > 0)
                      {
                        ref Graphics local7 = ref graphics;
                        bitmap = BitmapStore.GetBitmap(nr1);
                        ref Bitmap local8 = ref bitmap;
                        int x6 = x3 + num17;
                        int y = this.ItemSize * num6 + (int) Math.Round((double) (this.ItemSize - 20) / 2.0) + num18;
                        DrawMod.DrawSimple(ref local7, ref local8, x6, y);
                      }
                      if (nr2 > 0)
                      {
                        ref Graphics local9 = ref graphics;
                        bitmap = BitmapStore.GetBitmap(nr2);
                        ref Bitmap local10 = ref bitmap;
                        int x7 = x3 + num17;
                        int y = this.ItemSize * num6 + (int) Math.Round((double) (this.ItemSize - 20) / 2.0) + num18;
                        DrawMod.DrawSimple(ref local9, ref local10, x7, y);
                      }
                      num17 += 20;
                      if (index7 == 1)
                      {
                        num17 += 6;
                        num18 = -12;
                      }
                      if (num17 > num10 - 20)
                        break;
                    }
                  }
                }
                if (Operators.CompareString(strArray1[0], "3", false) == 0)
                {
                  int num19 = 5;
                  int upperBound = strArray1.GetUpperBound(0);
                  for (int index8 = 1; index8 <= upperBound; index8 += 2)
                  {
                    int nr = (int) Math.Round(Conversion.Val(strArray1[index8]));
                    if (nr > 0)
                    {
                      ref Graphics local11 = ref graphics;
                      bitmap = BitmapStore.GetBitmap(nr);
                      ref Bitmap local12 = ref bitmap;
                      int x8 = x3 + num19 - 6;
                      int y = this.ItemSize * num6 + (int) Math.Round((double) (this.ItemSize - BitmapStore.Getheight(nr)) / 2.0);
                      DrawMod.DrawSimple(ref local11, ref local12, x8, y);
                    }
                    int num20 = num19 + 32;
                    sizeF2 = graphics.MeasureString(strArray1[index8 + 1], this.ownfont2);
                    DrawMod.DrawTextColouredNicely(ref graphics, strArray1[index8 + 1], this.ownfont2, x3 + num20, this.ItemSize * num6 + 1 - 1 + num2 + this.fontoffsety, Color.Black);
                    num19 = (int) Math.Round((double) ((float) num20 + (sizeF2.Width + 10f)));
                    if (num19 > num10 - 45)
                      break;
                  }
                }
                if (Operators.CompareString(strArray1[0], "6", false) == 0)
                {
                  int num21 = 5;
                  int upperBound = strArray1.GetUpperBound(0);
                  for (int index9 = 1; index9 <= upperBound; index9 += 5)
                  {
                    int num22 = (int) Math.Round(Conversion.Val(strArray1[index9]));
                    Bitmap objBitmap = this.game.CustomBitmapObj.DrawSFTypeGraphic(this.game.HandyFunctionsObj.GetSFTypeByID(num22), (int) Math.Round(Conversion.Val(strArray1[index9 + 2])) == 1, (int) Math.Round(Conversion.Val(strArray1[index9 + 3])), (int) Math.Round(Conversion.Val(strArray1[index9 + 4])), -1);
                    int num23 = 0;
                    int num24 = 2;
                    int w = 64;
                    int h = this.ItemSize;
                    int width3 = objBitmap.Width;
                    int height = objBitmap.Height;
                    if (width3 > w | height > h)
                    {
                      if ((double) width3 / (double) w > (double) height / (double) h)
                      {
                        float num25 = (float) w / (float) width3;
                        float num26 = (float) h - (float) height * num25;
                        int num27 = num24 + (int) Math.Round((double) (num26 / 2f));
                        h = (int) Math.Round((double) ((float) h - num26));
                      }
                      else
                      {
                        float num28 = (float) h / (float) height;
                        float num29 = (float) w - (float) width3 * num28;
                        int num30 = num23 + (int) Math.Round((double) (num29 / 2f));
                        w = (int) Math.Round((double) ((float) w - num29));
                      }
                      DrawMod.DrawScaled(ref graphics, ref objBitmap, x3 + num21 - 6, this.ItemSize * num6 + 0, w, h, true);
                    }
                    else
                      DrawMod.DrawSimple(ref graphics, ref objBitmap, x3 + num21 - 6, this.ItemSize * num6 + (int) Math.Round((double) (this.ItemSize - BitmapStore.Getheight(num22)) / 2.0));
                    int num31 = num21 + w;
                    sizeF2 = graphics.MeasureString(strArray1[index9 + 1], this.ownfont2);
                    DrawMod.DrawTextColouredNicely(ref graphics, strArray1[index9 + 1], this.ownfont2, x3 + num31, this.ItemSize * num6 + 1 - 1 + num2 + this.fontoffsety, Color.Black);
                    num21 = (int) Math.Round((double) ((float) num31 + (sizeF2.Width + 10f)));
                    if (num21 > num10 - 45)
                      break;
                  }
                }
                if (Operators.CompareString(strArray1[0], "4", false) == 0)
                {
                  int num32 = 0;
                  int upperBound = strArray1.GetUpperBound(0);
                  for (int index10 = 1; index10 <= upperBound; index10 += 2)
                  {
                    int nr = (int) Math.Round(Conversion.Val(strArray1[index10]));
                    if (nr > 0)
                    {
                      ref Graphics local13 = ref graphics;
                      bitmap = BitmapStore.GetBitmap(nr, -1);
                      ref Bitmap local14 = ref bitmap;
                      int x9 = x3 + num32 - 6;
                      int y = this.ItemSize * num6 + (int) Math.Round((double) (this.ItemSize - BitmapStore.Getheight(nr, -1)) / 2.0);
                      DrawMod.DrawSimple(ref local13, ref local14, x9, y);
                    }
                    int num33 = num32 + 20;
                    sizeF2 = graphics.MeasureString(strArray1[index10 + 1], this.ownfont2);
                    DrawMod.DrawTextColouredNicely(ref graphics, strArray1[index10 + 1], this.ownfont2, x3 + num33, this.ItemSize * num6 + 1 - 1 + num2 + this.fontoffsety, Color.Black);
                    num32 = (int) Math.Round((double) ((float) num33 + sizeF2.Width));
                    if (num32 > num10 - 45)
                      break;
                  }
                }
                if (Operators.CompareString(strArray1[0], "5", false) == 0)
                {
                  int num34 = 3;
                  int upperBound = strArray1.GetUpperBound(0);
                  for (int index11 = 1; index11 <= upperBound; index11 += 2)
                  {
                    int nr = (int) Math.Round(Conversion.Val(strArray1[index11]));
                    if (nr > 0)
                    {
                      ref Graphics local15 = ref graphics;
                      bitmap = BitmapStore.GetBitmap(nr);
                      ref Bitmap local16 = ref bitmap;
                      int x10 = x3 + num34 - 7;
                      int y = this.ItemSize * num6 + (int) Math.Round((double) (this.ItemSize - BitmapStore.Getheight(nr)) / 2.0);
                      DrawMod.DrawSimple(ref local15, ref local16, x10, y);
                    }
                    int num35 = num34 + 22;
                    sizeF2 = graphics.MeasureString(strArray1[index11 + 1], this.ownfont2);
                    DrawMod.DrawTextColouredNicely(ref graphics, strArray1[index11 + 1], this.ownfont2, x3 + num35, this.ItemSize * num6 + 1 + 1 + num2 + this.fontoffsety, Color.Black);
                    num34 = (int) Math.Round((double) ((float) num35 + (sizeF2.Width + 8f)));
                    if (num34 > num10 - 45)
                      break;
                  }
                }
                if (Operators.CompareString(strArray1[0], "5b", false) == 0)
                {
                  int num36 = 3;
                  int num37 = 1;
                  int num38 = 0;
                  int upperBound = strArray1.GetUpperBound(0);
                  for (int index12 = 1; index12 <= upperBound; index12 += 2)
                  {
                    int nr = (int) Math.Round(Conversion.Val(strArray1[index12]));
                    int num39 = 0;
                    if (nr > 0)
                      num39 = (int) Math.Round((double) (this.ItemSize - BitmapStore.Getheight(nr) * 2) / 3.0);
                    if (nr > 0 & num37 == 1)
                    {
                      ref Graphics local17 = ref graphics;
                      bitmap = BitmapStore.GetBitmap(nr);
                      ref Bitmap local18 = ref bitmap;
                      int x11 = x3 + num36 - 7;
                      int y = this.ItemSize * num6 + num39;
                      DrawMod.DrawSimple(ref local17, ref local18, x11, y);
                    }
                    if (nr > 0 & num37 == 2)
                    {
                      ref Graphics local19 = ref graphics;
                      bitmap = BitmapStore.GetBitmap(nr);
                      ref Bitmap local20 = ref bitmap;
                      int x12 = x3 + num36 - 7;
                      int y = this.ItemSize * num6 + BitmapStore.Getheight(nr) + num39 * 2;
                      DrawMod.DrawSimple(ref local19, ref local20, x12, y);
                    }
                    sizeF2 = graphics.MeasureString(strArray1[index12 + 1], this.ownfont2);
                    if ((double) sizeF2.Width > (double) num38)
                      num38 = (int) Math.Round((double) sizeF2.Width);
                    if (num37 == 1)
                      DrawMod.DrawTextColouredNicely(ref graphics, strArray1[index12 + 1], this.ownfont2, x3 + num36 + 22, this.ItemSize * num6 + num39, Color.Black);
                    if (num37 == 2)
                      DrawMod.DrawTextColouredNicely(ref graphics, strArray1[index12 + 1], this.ownfont2, x3 + num36 + 22, this.ItemSize * num6 + BitmapStore.Getheight(nr) + num39 * 2, Color.Black);
                    ++num37;
                    if (num37 > 2)
                    {
                      num37 = 1;
                      num36 = num36 + 22 + (num38 + 8);
                      num38 = 0;
                    }
                    if (num36 > num10 - 45)
                      break;
                  }
                }
              }
              else if (this.ListObj.TempBmp[index1 - num5, index4] > 0)
              {
                int nr = this.ListObj.TempBmp[index1 - num5, index4];
                if (nr < 100000)
                {
                  int width4 = BitmapStore.GetWidth(nr);
                  int num40 = BitmapStore.Getheight(nr);
                  ref Graphics local21 = ref graphics;
                  bitmap = BitmapStore.GetBitmap(nr);
                  ref Bitmap local22 = ref bitmap;
                  int x13 = x3;
                  int y = this.ItemSize * num6 + 1 + 1;
                  int w = width4;
                  int h = num40;
                  DrawMod.DrawScaled(ref local21, ref local22, x13, y, w, h);
                }
                else
                {
                  if (nr == 100001)
                    this.Hardcoded_DrawPortrait(graphics, x3 - 5, this.ItemSize * num6, (int) Math.Round((double) (this.ItemSize * 10) / 14.0), this.ItemSize, (int) Math.Round(Conversion.Val(this.ListObj.Data[index1 - num5, index4])));
                  if (nr == 1000001)
                  {
                    string[] strArray2 = this.ListObj.Data[index1 - num5, index4].Split(',');
                    Bitmap objBitmap = this.game.CustomBitmapObj.DrawSFTypeGraphic(this.game.HandyFunctionsObj.GetSFTypeByID((int) Math.Round(Conversion.Val(strArray2[0]))), (int) Math.Round(Conversion.Val(strArray2[1])) == 1, (int) Math.Round(Conversion.Val(strArray2[2])), (int) Math.Round(Conversion.Val(strArray2[3])), -1);
                    int num41 = 0;
                    int num42 = 2;
                    int w = this.ItemSize * 2;
                    int h = this.ItemSize;
                    int width5 = objBitmap.Width;
                    int height = objBitmap.Height;
                    if (width5 > w | height > h)
                    {
                      if ((double) width5 / (double) w > (double) height / (double) h)
                      {
                        float num43 = (float) w / (float) width5;
                        float num44 = (float) h - (float) height * num43;
                        num42 += (int) Math.Round((double) (num44 / 2f));
                        h = (int) Math.Round((double) ((float) h - num44));
                      }
                      else
                      {
                        float num45 = (float) h / (float) height;
                        float num46 = (float) w - (float) width5 * num45;
                        num41 += (int) Math.Round((double) (num46 / 2f));
                        w = (int) Math.Round((double) ((float) w - num46));
                      }
                      DrawMod.DrawScaled(ref graphics, ref objBitmap, x3 - 5 + num41, this.ItemSize * num6 + num42, w, h);
                    }
                    else
                      DrawMod.DrawSimple(ref graphics, ref objBitmap, x3 - 5 + num41 + (int) Math.Round((double) (w - width5) / 2.0), this.ItemSize * num6 + num42 + (int) Math.Round((double) (h - height) / 2.0));
                  }
                }
              }
              else
              {
                string str2 = this.ListObj.Data[index1 - num5, index4];
                string str3 = "";
                if ((double) (num2 * 2) >= (double) this.ItemSize / 2.0 & (double) graphics.MeasureString(str2, this.ownfont2).Width > (double) num10)
                {
                  int Length;
                  for (; (double) graphics.MeasureString(str2, this.ownfont2).Width > (double) (num10 - 4); str2 = Strings.Left(str2, Length))
                  {
                    Length = str2.LastIndexOf(" ");
                    if (Length > 0)
                      str3 = Strings.Right(str2, str2.Length - Length) + str3;
                    else
                      break;
                  }
                  int num47 = this.ItemSize - 2 * num2;
                  int num48 = (int) Math.Round((double) (this.ItemSize - 2 * num47) / 3.0);
                  if (Operators.CompareString(Strings.Left(str3, 1), " ", false) == 0)
                    str3 = Strings.Mid(str3, 2);
                  DrawMod.DrawTextColouredNicely(ref graphics, str2, this.ownfont2, x3, this.ItemSize * num6 + num48 + 2, Color.Black);
                  DrawMod.DrawTextColouredNicely(ref graphics, str3, this.ownfont2, x3, this.ItemSize * num6 + this.ItemSize - (num47 + num48 + 2), Color.Black);
                }
                else
                {
                  while ((double) graphics.MeasureString(str2, this.ownfont2).Width > (double) num10)
                    str2 = (double) graphics.MeasureString(str2, this.ownfont2).Width <= (double) num10 * 2.2 ? Strings.Left(str2, str2.Length - 1) : Strings.Left(str2, (int) Math.Round((double) str2.Length / 2.0));
                  if (Strings.InStr(str2, "\r\n") > 0)
                    DrawMod.DrawTextColouredNicely(ref graphics, str2, this.ownfont2, x3, this.ItemSize * num6 + 1 + this.fontoffsety, Color.Black);
                  else
                    DrawMod.DrawTextColouredNicely(ref graphics, str2, this.ownfont2, x3, this.ItemSize * num6 + 1 + num2 + this.fontoffsety + 2, Color.Black);
                }
              }
              if (!this.nolines & index4 > 0)
                DrawMod.drawLine(ref graphics, x3 - 5, this.ItemSize * num6, x3 - 5, 1 * this.ItemSize + this.ItemSize * num6 - 1, 128, 128, 128, (int) byte.MaxValue);
            }
          }
        }
      }
      DrawMod.DrawRectangle(ref graphics, 0, this.ItemSize, this.Width - 1, this.Height - this.ItemSize * 2, 0, 0, 0, (int) byte.MaxValue);
      if (!Information.IsNothing((object) graphics))
        graphics.Dispose();
      return this.OwnBitmap;
    }

    public void Hardcoded_DrawPortrait(Graphics g, int x, int y, int w, int h, int charId)
    {
      int num = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].GetData(0, charId, 12)));
      ref Graphics local1 = ref g;
      Bitmap bitmap = this.game.CustomBitmapObj.DrawLeaderPortrait(charId, w, h);
      ref Bitmap local2 = ref bitmap;
      int x1 = x;
      int y1 = y;
      DrawMod.DrawSimple(ref local1, ref local2, x1, y1);
    }

    public override Coordinate Click2(int x, int y, int b = 1)
    {
      y = (int) Math.Round(Conversion.Int((double) y / (double) this.ItemSize));
      this.Scroller = true;
      int num1 = 1;
      int num2 = 0;
      if (this.ListSize >= this.ListObj.Length)
        num2 = 0;
      if (b == 1)
      {
        if (y > 0 & y < this.ListSize + 2)
        {
          if (x <= this.Width - num2)
          {
            y -= num1;
            y += this.TopItemY;
            float num3 = (float) Conversion.Int((double) (this.Width - 0) / (double) (this.ListObj.Width + 1));
            if ((double) num3 < (double) this.colWidth)
              num3 = (float) this.colWidth;
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
              coordinate1.y = (int) Math.Round((double) (Conversion.Int((float) x / num3) + (float) this.TopItemX));
              this.ColSelect = (int) Math.Round((double) (Conversion.Int((float) x / num3) + (float) this.TopItemX));
            }
            return coordinate1;
          }
        }
        else
        {
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
          ++this.TopItemY;
          this.clickscroll = 0;
          if (this.TopItemY > this.ListObj.Length - this.ListSize)
            this.TopItemY = this.ListObj.Length - this.ListSize;
          if (0 > this.TopItemY)
            this.TopItemY = 0;
          Coordinate coordinate2;
          coordinate2.x = -1;
          coordinate2.y = -1;
          return coordinate2;
        }
      }
      Coordinate coordinate3;
      coordinate3.x = -1;
      coordinate3.y = -1;
      return coordinate3;
    }

    public override int HandleMouseUp(int x, int y)
    {
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
      y = (int) Math.Round(Conversion.Int((double) y / (double) this.ItemSize));
      int num2 = 0;
      int num3 = 2;
      int num4 = 0;
      if (this.ListSize >= this.ListObj.Length)
        num4 = 0;
      if (y > num2 & y < this.ListSize + num3 & this.clickscroll == 1)
      {
        int num5 = (this.ListSize + 1) * this.ItemSize;
        int num6 = num1 - this.ItemSize;
        if (num6 < 1)
          num6 = 1;
        int num7 = (int) Math.Round((double) (int) Math.Round((double) ((float) num6 / (float) num5 * (float) this.ListObj.Length)) - (double) this.ListSize / 2.0);
        if (0 > num7)
          num7 = 0;
        this.TopItemY = num7;
        if (this.TopItemY > this.ListObj.Length - this.ListSize)
          this.TopItemY = this.ListObj.Length - this.ListSize;
        if (0 > this.TopItemY)
          this.TopItemY = 0;
        return true;
      }
      if (this.clickscroll != 2)
        ;
      return false;
    }
  }
}
