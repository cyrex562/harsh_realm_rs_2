﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.GraphClass
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
  public class GraphClass : SubPartClass
  {
    private int Width;
    private int Height;
    private GameClass game;
    private Bitmap backbitmap;
    private int bx;
    private int by;
    private int[,] Mat;
    private string MatTitle;
    private int Multiplier;
    private Color[] RegCol;
    private string[] RegName;
    private int RegCount;
    private bool showNumbers;
    private bool checkForRegime;
    private int tmin;
    private bool tminRun;

    public override void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    public GraphClass(
      GameClass tgame,
      int[,] tMat,
      bool tshowNumbers,
      string tMatTitle,
      int tMultiplier,
      Color[] tRegCol,
      string[] tRegName,
      int tregcount,
      int twidth,
      int theight,
      ref Bitmap tbackbitmap = null,
      int bbx = -1,
      int bby = -1,
      bool tcheckforregime = true)
      : base(twidth, theight)
    {
      this.Width = twidth;
      this.Height = theight;
      this.game = tgame;
      this.Mat = tMat;
      this.tminRun = false;
      this.checkForRegime = tcheckforregime;
      this.showNumbers = tshowNumbers;
      this.RegCol = tRegCol;
      this.RegName = tRegName;
      this.RegCount = tregcount;
      this.MatTitle = tMatTitle;
      this.Multiplier = tMultiplier;
      if (!Information.IsNothing((object) tbackbitmap))
      {
        this.backbitmap = new Bitmap(this.OwnBitmap.Width, this.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
        this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics graphics = Graphics.FromImage((Image) this.backbitmap);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.DrawImage((Image) tbackbitmap, new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), new Rectangle(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
        graphics.CompositingMode = CompositingMode.SourceOver;
      }
      this.bx = bbx;
      this.by = bby;
    }

    public override Bitmap Paint()
    {
      SizeF sizeF1 = new SizeF();
      Rectangle[] rectangleArray = new Rectangle[10000];
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (!Information.IsNothing((object) this.backbitmap))
      {
        graphics.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple(ref graphics, ref this.backbitmap, 0, 0);
        graphics.CompositingMode = CompositingMode.SourceOver;
      }
      DrawMod.DrawBlockGradient2(ref graphics, 0, 0, this.Width - 1, this.Height - 1, this.game.MarcCol1, this.game.MarcCol2);
      int[,] numArray1 = new int[this.Mat.GetUpperBound(0) + 1, this.Mat.GetUpperBound(1) + 1];
      int[,] numArray2 = new int[this.Mat.GetUpperBound(0) + 1, this.Mat.GetUpperBound(1) + 1];
      int num1 = this.Width - 70;
      int num2 = 60;
      int num3 = (int) Math.Round((double) this.Height - (50.0 + Math.Max(2.0, (double) this.RegCount / 2.0 + 0.5) * 15.0));
      int num4 = (int) Math.Round(20.0 + Math.Max(2.0, (double) this.RegCount / 2.0 + 0.5) * 15.0);
      int num5 = (int) Math.Round(Conversion.Int((double) num1 / (double) Math.Max(10, this.game.Data.Round)));
      if (!this.tminRun)
      {
        this.tmin = 0;
        this.tminRun = true;
        int round1 = this.game.Data.Round;
        for (int index1 = 1; index1 <= round1; ++index1)
        {
          int regCount = this.RegCount;
          for (int index2 = 1; index2 <= regCount; ++index2)
          {
            if (this.Mat[index1, index2] < this.tmin)
              this.tmin = this.Mat[index1, index2];
          }
        }
        int round2 = this.game.Data.Round;
        for (int index3 = 1; index3 <= round2; ++index3)
        {
          int regCount = this.RegCount;
          for (int index4 = 1; index4 <= regCount; ++index4)
          {
            int[,] mat = this.Mat;
            int[,] numArray3 = mat;
            int index5 = index3;
            int index6 = index5;
            int index7 = index4;
            int index8 = index7;
            int num6 = mat[index5, index7] + Math.Abs(this.tmin);
            numArray3[index6, index8] = num6;
          }
        }
      }
      int num7 = 0;
      int round3 = this.game.Data.Round;
      for (int index9 = 1; index9 <= round3; ++index9)
      {
        int regCount = this.RegCount;
        for (int index10 = 1; index10 <= regCount; ++index10)
        {
          if (this.Mat[index9, index10] > num7)
            num7 = this.Mat[index9, index10];
        }
      }
      int num8 = 0;
      float a1 = 1E+09f;
      if (num7 < 10)
        num7 = 10;
label_43:
      if (num8 == 0)
      {
        a1 /= 10f;
        int num9 = 1;
        do
        {
          int num10;
          if (num9 == 1)
            num10 = (int) Math.Round((double) a1);
          if (num9 == 2)
            num10 = (int) Math.Round((double) a1 * 0.8);
          if (num9 == 3)
            num10 = (int) Math.Round((double) a1 * 0.6);
          if (num9 == 4)
            num10 = (int) Math.Round((double) (a1 / 2f));
          if (num9 == 5)
            num10 = (int) Math.Round((double) a1 * 0.4);
          if (num9 >= 6)
            num10 = (int) Math.Round((double) a1 * 0.2);
          if (num10 > num7 & num10 <= num7 * 2 | (double) a1 < 10.0)
          {
            num7 = num10;
            goto label_44;
          }
          else
            ++num9;
        }
        while (num9 <= 8);
        goto label_43;
      }
label_44:
      int round4 = this.game.Data.Round;
      for (int index11 = 1; index11 <= round4; ++index11)
      {
        int regCount1 = this.RegCount;
        for (int index12 = 1; index12 <= regCount1; ++index12)
        {
          numArray1[index11, index12] = (int) Math.Round((double) Conversion.Int(num5 * index11) - Conversion.Int((double) num5 / 2.0));
          numArray2[index11, index12] = (int) Math.Round(Conversion.Int((double) this.Mat[index11, index12] / (double) num7 * (double) num3));
        }
        int num11 = 1;
        while (num11 == 1)
        {
          num11 = 0;
          int regCount2 = this.RegCount;
          for (int index13 = 1; index13 <= regCount2; ++index13)
          {
            int regCount3 = this.RegCount;
            for (int index14 = 1; index14 <= regCount3; ++index14)
            {
              if (index13 != index14 && numArray2[index11, index13] > numArray2[index11, index14] - 1 & numArray2[index11, index13] < numArray2[index11, index14] + 1 && numArray2[index11, index13] >= numArray2[index11, index14])
              {
                numArray2[index11, index13] = numArray2[index11, index14] + 2;
                num11 = 1;
              }
            }
          }
        }
        int regCount4 = this.RegCount;
        for (int index15 = 1; index15 <= regCount4; ++index15)
        {
          numArray2[index11, index15] = num4 + (num3 - numArray2[index11, index15]);
          numArray1[index11, index15] = num2 + numArray1[index11, index15];
        }
      }
      Color c1 = Color.FromArgb(128, 200, 200, 200);
      Color c2 = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      DrawMod.drawLine(ref graphics, num2, num4 - 10, num2, this.Height - 5, c1);
      DrawMod.drawLine(ref graphics, 5, num4 + num3 + 10, this.Width - 5, num4 + num3 + 10, c1);
      int num12 = Math.Max(10, this.game.Data.Round);
      for (int index = 1; index <= num12; ++index)
        DrawMod.drawLineDot(ref graphics, num2 + num5 * index, num4 - 10, num2 + num5 * index, this.Height - 5, c1);
      int num13 = Math.Max(10, this.game.Data.Round);
      SizeF sizeF2;
      for (int round5 = 1; round5 <= num13; ++round5)
      {
        string str = this.DateString(round5);
        sizeF2 = graphics.MeasureString(str, this.game.MarcFont5);
        float num14 = (float) num5;
        int num15 = 1;
        for (; (double) num14 < (double) sizeF2.Width + 10.0; num14 = (float) (num5 * num15))
          ++num15;
        if (round5 % num15 == 0)
          DrawMod.DrawTextColouredMarc(ref graphics, str, this.game.MarcFont5, (int) Math.Round((double) (num2 + num5 * round5) - (double) num5 / 2.0 - (double) sizeF2.Width / 2.0), num4 + num3 + 12, c2);
      }
      int num16 = 0;
      do
      {
        float num17 = (float) ((int) Math.Round((double) num7 / 10.0) * num16);
        int num18 = (int) Math.Round((double) ((float) (num4 + num3) - (float) num3 * (num17 / (float) num7)));
        DrawMod.drawLineDot(ref graphics, num2 - 20, num18, num2 + num1, num18, c1);
        string str = Strings.Trim(Conversion.Str((object) (((int) Math.Round((double) num7 / 10.0) * num16 - Math.Abs(this.tmin)) * this.Multiplier)));
        if (Operators.CompareString(Strings.Right(str, 4), "0000", false) == 0)
          str = Strings.Left(str, Strings.Len(str) - 3) + "K";
        sizeF2 = graphics.MeasureString(str, this.game.MarcFont5);
        DrawMod.DrawTextColouredMarc(ref graphics, str, this.game.MarcFont5, (int) Math.Round((double) ((float) (num2 - 25) - sizeF2.Width / 2f)), (int) Math.Round((double) ((float) num18 - sizeF2.Height)), c2);
        ++num16;
      }
      while (num16 <= 10);
      DrawMod.DrawTextColouredMarc(ref graphics, this.MatTitle, this.game.MarcFont4, 20, 5, c2);
      sizeF2 = graphics.MeasureString(this.MatTitle, this.game.MarcFont4);
      int num19 = (int) Math.Round((double) Math.Max(0.0f, 220f - sizeF2.Width));
      int y1_1 = -5;
      int x1_1 = (int) Math.Round((double) ((float) num2 + sizeF2.Width));
      int num20 = 0;
      int regCount5 = this.RegCount;
      for (int index = 1; index <= regCount5; ++index)
      {
        if ((double) index > Math.Max(2.0, Conversion.Int((double) this.RegCount / 2.0 + 0.5)) & num20 == 0)
        {
          num20 = 1;
          y1_1 = -5;
          x1_1 = (int) Math.Round((double) num2 + (double) num1 / 2.0 + (double) num1 / 5.0 - (double) num19) + 75;
        }
        y1_1 += 15;
        Color color = DrawMod.LightenColor(Color.FromArgb((int) this.RegCol[index].A, (int) this.RegCol[index].R, (int) this.RegCol[index].G, (int) this.RegCol[index].B), 66);
        DrawMod.DrawBlock(ref graphics, x1_1, y1_1, 20, 10, (int) this.RegCol[index].R, (int) this.RegCol[index].G, (int) this.RegCol[index].B, (int) this.RegCol[index].A);
        DrawMod.DrawRectangle(ref graphics, x1_1, y1_1, 20, 10, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
        DrawMod.DrawRectangle(ref graphics, x1_1 - 1, y1_1 - 1, 22, 12, 0, 0, 0, 200);
        DrawMod.DrawTextColouredMarc(ref graphics, this.RegName[index], this.game.MarcFont5, x1_1 + 30, y1_1 - 2, c2);
      }
      int num21 = this.game.Data.Round - 1;
      for (int index16 = 1; index16 <= num21; ++index16)
      {
        int regCount6 = this.RegCount;
        for (int index17 = 1; index17 <= regCount6; ++index17)
        {
          if (!this.checkForRegime | !(this.game.Data.Round == index16 + 1 & this.game.Data.Turn < index17 - 1))
          {
            int num22 = numArray1[index16, index17];
            int num23 = numArray2[index16, index17];
            int x1_2 = num22;
            int num24 = num23;
            float a2 = (float) numArray1[index16 + 1, index17];
            int num25 = numArray2[index16 + 1, index17];
            int y1_2 = num24 + 0;
            int y2 = num25 + 0;
            Color color = DrawMod.LightenColor(Color.FromArgb((int) this.RegCol[index17].A, (int) this.RegCol[index17].R, (int) this.RegCol[index17].G, (int) this.RegCol[index17].B), 66);
            DrawMod.drawLine(ref graphics, x1_2, y1_2 + 1, (int) Math.Round((double) a2), y2 + 1, (int) this.RegCol[index17].R, (int) this.RegCol[index17].G, (int) this.RegCol[index17].B, (int) this.RegCol[index17].A);
            DrawMod.drawLine(ref graphics, x1_2, y1_2, (int) Math.Round((double) a2), y2, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
          }
        }
      }
      int round6 = this.game.Data.Round;
      for (int index18 = 1; index18 <= round6; ++index18)
      {
        int regCount7 = this.RegCount;
        for (int index19 = 1; index19 <= regCount7; ++index19)
        {
          if (!this.checkForRegime | !(this.game.Data.Round == index18 & this.game.Data.Turn < index19 - 1))
          {
            int num26 = numArray1[index18, index19];
            int num27 = numArray2[index18, index19];
            int num28 = num26 - 2;
            int num29 = num27 - 2;
            DrawMod.LightenColor(Color.FromArgb((int) this.RegCol[index19].A, (int) this.RegCol[index19].R, (int) this.RegCol[index19].G, (int) this.RegCol[index19].B), 66);
            if (this.showNumbers)
            {
              float num30 = (float) ((this.Mat[index18, index19] - Math.Abs(this.tmin)) * this.Multiplier);
              string str = !((double) num30 > 9999.0 | (double) num30 < -9999.0) ? num30.ToString() : Strings.Format((object) (float) ((double) num30 / 1000.0), "0.0") + "K";
              sizeF2 = graphics.MeasureString(str, this.game.MarcFont5);
              int num31 = 0;
              int index20;
              int num32 = index20;
              for (int index21 = 1; index21 <= num32; ++index21)
              {
                if (rectangleArray[index21].X >= num28 & (double) rectangleArray[index21].X <= (double) num28 + (double) sizeF2.Width && rectangleArray[index21].Y >= num29 & (double) rectangleArray[index21].Y <= (double) num29 + (double) sizeF2.Height)
                  num31 = 1;
                if (rectangleArray[index21].X >= num28 & (double) rectangleArray[index21].X <= (double) num28 + (double) sizeF2.Width && rectangleArray[index21].Y + rectangleArray[index21].Height >= num29 & (double) (rectangleArray[index21].Y + rectangleArray[index21].Height) <= (double) num29 + (double) sizeF2.Height)
                  num31 = 1;
                if (rectangleArray[index21].X + rectangleArray[index21].Width >= num28 & (double) (rectangleArray[index21].X + rectangleArray[index21].Width) <= (double) num28 + (double) sizeF2.Width && rectangleArray[index21].Y >= num29 & (double) rectangleArray[index21].Y <= (double) num29 + (double) sizeF2.Height)
                  num31 = 1;
                if (rectangleArray[index21].X + rectangleArray[index21].Width >= num28 & (double) (rectangleArray[index21].X + rectangleArray[index21].Width) <= (double) num28 + (double) sizeF2.Width && rectangleArray[index21].Y + rectangleArray[index21].Height >= num29 & (double) rectangleArray[index21].Y <= (double) num29 + (double) sizeF2.Height)
                  num31 = 1;
              }
              if (num31 == 0)
              {
                ++index20;
                Color c3 = DrawMod.LightenColor(Color.FromArgb((int) this.RegCol[index19].A, (int) this.RegCol[index19].R, (int) this.RegCol[index19].G, (int) this.RegCol[index19].B), 66);
                DrawMod.DrawBlock(ref graphics, num28, num29, 5, 5, (int) this.RegCol[index19].R, (int) this.RegCol[index19].G, (int) this.RegCol[index19].B, (int) this.RegCol[index19].A);
                DrawMod.DrawRectangle(ref graphics, num28, num29, 5, 5, (int) c3.R, (int) c3.G, (int) c3.B, (int) c3.A);
                DrawMod.DrawRectangle(ref graphics, num28 - 1, num29 - 1, 7, 7, 0, 0, 0, 80);
                DrawMod.DrawBlock(ref graphics, num28 + 6, num29 - 2, (int) Math.Round((double) sizeF2.Width), (int) Math.Round((double) (sizeF2.Height - 3f)), 0, 0, 0, 100);
                rectangleArray[index20] = this.game.Data.Product < 6 ? new Rectangle(num28, num29, (int) Math.Round((double) sizeF2.Width), (int) Math.Round((double) sizeF2.Height)) : new Rectangle(num28 - 8, num29 - 4, (int) Math.Round((double) (sizeF2.Width + 16f)), (int) Math.Round((double) (sizeF2.Height + 8f)));
                DrawMod.DrawTextColouredMarc(ref graphics, str, this.game.MarcFont5, num28 + 6, num29 - 3, c3);
              }
            }
          }
        }
      }
      DrawMod.DrawFrame(ref this.OwnBitmap, ref this.backbitmap, ref graphics, 0, 0, this.Width, this.Height, 0, 0);
      return this.OwnBitmap;
    }

    public string DateString(int round)
    {
      object Counter;
      string str;
      if (this.game.Data.AlternateRound > -1)
      {
        DateTime dateTime = new DateTime().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1));
        object LoopForResult;
        object CounterResult;
        if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(Counter, (object) 2, (object) round, (object) 1, ref LoopForResult, ref CounterResult))
        {
          do
          {
            if (this.game.Data.AlternateRound == 31)
            {
              dateTime = dateTime.AddMonths(1);
            }
            else
            {
              TimeSpan timeSpan = new TimeSpan(this.game.Data.AlternateRound, 0, 0, 0);
              dateTime = dateTime.Add(timeSpan);
            }
          }
          while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult, LoopForResult, ref CounterResult));
        }
        str = Strings.Trim(Conversion.Str((object) dateTime.Day)) + "/" + Strings.Trim(Conversion.Str((object) dateTime.Month));
      }
      else if (this.game.Data.AlternateRound2 > -1)
      {
        DateTime dateTime = new DateTime().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1)).AddHours((double) this.game.Data.StartData.Hour);
        object LoopForResult;
        object CounterResult;
        if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(Counter, (object) 2, (object) round, (object) 1, ref LoopForResult, ref CounterResult))
        {
          do
          {
            TimeSpan timeSpan = new TimeSpan(0, this.game.Data.AlternateRound2, 0, 0);
            dateTime = dateTime.Add(timeSpan);
          }
          while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult, LoopForResult, ref CounterResult));
        }
        if (((this.game.Data.Round <= 10 ? 1 : 0) & 0) != 0)
          str = Strings.Trim(Conversion.Str((object) dateTime.Day)) + "/" + Strings.Trim(Conversion.Str((object) dateTime.Month)) + " " + Strings.Trim(Conversion.Str((object) dateTime.Hour)) + ":00";
        else
          str = Strings.Trim(Conversion.Str((object) dateTime.Day)) + "/" + Strings.Trim(Conversion.Str((object) dateTime.Month)) + " " + Strings.Trim(Conversion.Str((object) dateTime.Hour)) + "h";
      }
      else
        str = Strings.Trim(Conversion.Str((object) round));
      return str;
    }
  }
}
