// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.UnitSFPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class UnitSFPartClass : SubPartClass
  {
    private object OwnBitmapNr;
    private int unr;
    private GameClass game;

    public UnitSFPartClass(int tunr, GameClass tgame)
      : base(620, 200)
    {
      this.unr = tunr;
      this.game = tgame;
    }

    public override Bitmap Paint()
    {
      SizeF sizeF = new SizeF();
      Coordinate coordinate1 = new Coordinate();
      Coordinate coordinate2 = new Coordinate();
      bool flag1;
      if (this.game.EditObj.OrderType == 14)
        flag1 = true;
      if (this.game.EditObj.OrderType == 15)
        flag1 = true;
      if (this.game.EditObj.OrderType == 2)
        flag1 = true;
      if (this.game.EditObj.OrderType == 12)
        flag1 = true;
      bool flag2;
      if (this.game.EditObj.OrderType == 11)
      {
        flag1 = true;
        flag2 = true;
      }
      if (this.game.EditObj.OrderType == 13)
      {
        flag1 = true;
        flag2 = true;
      }
      if (this.game.Data.UnitObj[this.unr].Regime == this.game.Data.Turn | this.game.Data.Round == 0)
        coordinate1.x = 3;
      else
        coordinate1 = this.game.HandyFunctionsObj.GetReconMinusHide(this.unr, this.game.Data.Turn);
      if (this.unr < 0 | this.unr > this.game.Data.UnitCounter)
        return this.OwnBitmap;
      if (this.game.Data.UnitObj[this.unr].SFCount < 0)
        return this.OwnBitmap;
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      int regime = this.game.Data.UnitObj[this.unr].Regime;
      int red1 = this.game.Data.RegimeObj[regime].Red;
      int green1 = this.game.Data.RegimeObj[regime].Green;
      int blue1 = this.game.Data.RegimeObj[regime].Blue;
      int red2 = red1 + 50;
      int green2 = green1 + 50;
      int blue2 = blue1 + 50;
      if ((int) byte.MaxValue < red2)
        red2 = (int) byte.MaxValue;
      if ((int) byte.MaxValue < green2)
        green2 = (int) byte.MaxValue;
      if ((int) byte.MaxValue < blue2)
        blue2 = (int) byte.MaxValue;
      int red2_1 = this.game.Data.RegimeObj[regime].Red2;
      int green2_1 = this.game.Data.RegimeObj[regime].Green2;
      int blue2_1 = this.game.Data.RegimeObj[regime].Blue2;
      Color c1_1 = Color.FromArgb((int) byte.MaxValue, red1, green1, blue1);
      Color c2_1 = Color.FromArgb(0, red1, green1, blue1);
      Color c1_2 = Color.FromArgb((int) byte.MaxValue, red2, green2, blue2);
      Color c2_2 = Color.FromArgb(0, red2, green2, blue2);
      Color color = Color.FromArgb((int) byte.MaxValue, red2_1, green2_1, blue2_1);
      Color.FromArgb(185, 0, 0, 0);
      Color.FromArgb(200, red2_1, green2_1, blue2_1);
      int num1 = -1;
      if (coordinate1.x > 1)
      {
        int sfCount = this.game.Data.UnitObj[this.unr].SFCount;
        for (int i = 0; i <= sfCount; ++i)
        {
          ++num1;
          int sf = this.game.Data.UnitObj[this.unr].SFList[i];
          int type = this.game.Data.SFObj[sf].Type;
          int people = this.game.Data.SFObj[sf].People;
          int picSpriteId = this.game.Data.SFTypeObj[type].PicSpriteID;
          int sidewaysSpriteId = this.game.Data.SFTypeObj[type].SidewaysSpriteID;
          int baseColor = this.game.Data.SFTypeObj[type].BaseColor;
          if (this.game.Data.RegimeObj[this.game.Data.UnitObj[this.unr].Regime].ExtraGraphicUse > -1)
          {
            int extraCounter = this.game.Data.SFTypeObj[type].ExtraCounter;
            for (int index = 0; index <= extraCounter; ++index)
            {
              if (this.game.Data.SFTypeObj[type].ExtraCode[index] == this.game.Data.RegimeObj[this.game.Data.UnitObj[this.unr].Regime].ExtraGraphicUse)
              {
                picSpriteId = this.game.Data.SFTypeObj[type].ExtraPicSpriteID[index];
                sidewaysSpriteId = this.game.Data.SFTypeObj[type].ExtraSidewaysSpriteID[index];
              }
            }
          }
          else if (this.game.Data.PeopleObj[people].ExtraGraphicUse > -1)
          {
            int extraCounter = this.game.Data.SFTypeObj[type].ExtraCounter;
            for (int index = 0; index <= extraCounter; ++index)
            {
              if (this.game.Data.SFTypeObj[type].ExtraCode[index] == this.game.Data.PeopleObj[people].ExtraGraphicUse)
              {
                picSpriteId = this.game.Data.SFTypeObj[type].ExtraPicSpriteID[index];
                sidewaysSpriteId = this.game.Data.SFTypeObj[type].ExtraSidewaysSpriteID[index];
              }
            }
          }
          if (this.game.Data.UnitObj[this.unr].SFCount < 8)
          {
            int num2 = (int) Math.Round(3.0 + Conversion.Int((double) i / 4.0) * -620.0 + (double) (i * 155));
            int num3 = (int) Math.Round(5.0 + Conversion.Int((double) i / 4.0) * 98.0);
            int index1 = regime;
            if (this.game.Data.PeopleObj[people].RegCol > -1)
              index1 = this.game.Data.PeopleObj[people].RegCol;
            int red3 = this.game.Data.RegimeObj[index1].Red;
            int green3 = this.game.Data.RegimeObj[index1].Green;
            int blue3 = this.game.Data.RegimeObj[index1].Blue;
            int red2_2 = this.game.Data.RegimeObj[index1].Red2;
            int green2_2 = this.game.Data.RegimeObj[index1].Green2;
            int blue2_2 = this.game.Data.RegimeObj[index1].Blue2;
            int red4 = red3 - 50;
            int green4 = green3 - 50;
            int blue4 = blue3 - 50;
            if (0 > red4)
              red4 = 0;
            if (0 > green4)
              green4 = 0;
            if (0 > blue4)
              blue4 = 0;
            c1_1 = Color.FromArgb((int) byte.MaxValue, red3, green3, blue3);
            c2_1 = Color.FromArgb((int) byte.MaxValue, red4, green4, blue4);
            color = Color.FromArgb((int) byte.MaxValue, red2_2, green2_2, blue2_2);
            DrawMod.DrawBlock(ref graphics, num2, num3 + 2, 150, 15, (int) this.game.VicColor3Shade.R, (int) this.game.VicColor3Shade.G, (int) this.game.VicColor3Shade.B, (int) this.game.VicColor3Shade.A);
            int Number1 = this.game.Data.SFObj[sf].Qty;
            if (coordinate1.x < 3 && this.game.Data.FOWOn & this.game.Data.UnitObj[this.unr].Regime != this.game.Data.Turn)
            {
              this.game.HandyFunctionsObj.RandomizeForUnit(this.unr, i);
              if (coordinate1.x == 2)
              {
                this.game.HandyFunctionsObj.RandomizeForUnit(this.unr, i);
                float num4 = (float) coordinate1.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
                float num5 = (float) ((1.0 - (double) num4) * 2.0);
                Number1 = (int) Math.Round((double) Conversion.Int((VBMath.Rnd() * num5 + num4) * (float) Number1));
                if (Number1 < 1)
                  Number1 = 1;
                VBMath.Randomize();
              }
            }
            if (this.game.Data.SFTypeObj[type].Ratio > 0)
              Number1 *= this.game.Data.SFTypeObj[type].Ratio;
            string tstring1 = Strings.Trim(Conversion.Str((object) Number1)) + "x " + this.game.Data.SFTypeObj[type].Name;
            if (this.game.Data.SFTypeObj[type].ModelID <= 0)
            {
              if (this.game.Data.RegimeObj[this.game.Data.UnitObj[this.unr].Regime].ExtraGraphicUse > -1)
              {
                int extraCounter = this.game.Data.SFTypeObj[type].ExtraCounter;
                for (int index2 = 0; index2 <= extraCounter; ++index2)
                {
                  if (this.game.Data.SFTypeObj[type].ExtraCode[index2] == this.game.Data.RegimeObj[this.game.Data.UnitObj[this.unr].Regime].ExtraGraphicUse)
                    tstring1 = Strings.Trim(Conversion.Str((object) Number1)) + "x " + this.game.Data.SFTypeObj[type].ExtraName[index2];
                }
              }
              else if (this.game.Data.PeopleObj[this.game.Data.SFObj[sf].People].ExtraGraphicUse > -1)
              {
                int extraCounter = this.game.Data.SFTypeObj[type].ExtraCounter;
                for (int index3 = 0; index3 <= extraCounter; ++index3)
                {
                  if (this.game.Data.SFTypeObj[type].ExtraCode[index3] == this.game.Data.PeopleObj[this.game.Data.SFObj[sf].People].ExtraGraphicUse)
                    tstring1 = Strings.Trim(Conversion.Str((object) Number1)) + "x " + this.game.Data.SFTypeObj[type].ExtraName[index3];
                }
              }
            }
            DrawMod.DrawTextVic2(ref graphics, tstring1, this.game.VicFont2, num2, num3 + 2, this.game.VicColor2, this.game.VicColor2Shade);
            Bitmap bitmap;
            Rectangle rectangle1;
            Rectangle rectangle2;
            if ((double) this.game.Data.RuleVar[869] >= 1.0)
            {
              if (this.game.Data.UnitObj[this.unr].X > -1)
              {
                int index4 = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y].LandscapeType;
                int index5 = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y].SpriteNr;
                if (this.game.Data.LandscapeTypeObj[index4].AirOverride > -1 & this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater == 2)
                {
                  index4 = this.game.Data.LandscapeTypeObj[index4].AirOverride;
                  index5 = 0;
                }
                else if ((double) this.game.Data.RuleVar[848] > 0.0 & this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater == 2)
                {
                  index4 = (int) Math.Round((double) this.game.Data.RuleVar[848]);
                  index5 = 0;
                }
                if (this.game.Data.LandscapeTypeObj[index4].NavyOverride > -1 & this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater == 1)
                {
                  index4 = this.game.Data.LandscapeTypeObj[index4].NavyOverride;
                  index5 = 0;
                }
                else if ((double) this.game.Data.RuleVar[872] > 0.0 & this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater == 1)
                {
                  index4 = (int) Math.Round((double) this.game.Data.RuleVar[872]);
                  index5 = 0;
                }
                if ((double) this.game.Data.RuleVar[869] == 3.0)
                {
                  int nr = this.game.Data.LandscapeTypeObj[index4].BasicPicID[index5];
                  ref Graphics local1 = ref graphics;
                  bitmap = BitmapStore.GetBitmap(nr);
                  ref Bitmap local2 = ref bitmap;
                  rectangle1 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr));
                  Rectangle srcrect = rectangle1;
                  rectangle2 = new Rectangle(num2 + 1, num3 + 19, 96, 72);
                  Rectangle destrect = rectangle2;
                  DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
                }
                else
                {
                  if ((double) this.game.Data.RuleVar[869] == 1.0)
                  {
                    int nr = this.game.Data.LandscapeTypeObj[index4].SidewaysSPriteID1[index5];
                    ref Graphics local3 = ref graphics;
                    bitmap = BitmapStore.GetBitmap(nr);
                    ref Bitmap local4 = ref bitmap;
                    rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr));
                    Rectangle srcrect = rectangle2;
                    rectangle1 = new Rectangle(num2 + 1, num3 + 19, 96, 72);
                    Rectangle destrect = rectangle1;
                    DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
                  }
                  int nr1 = this.game.Data.LandscapeTypeObj[index4].SidewaysSPriteID2[index5];
                  ref Graphics local5 = ref graphics;
                  bitmap = BitmapStore.GetBitmap(nr1);
                  ref Bitmap local6 = ref bitmap;
                  rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr1));
                  Rectangle srcrect1 = rectangle2;
                  rectangle1 = new Rectangle(num2 + 1, num3 + 19, 96, 72);
                  Rectangle destrect1 = rectangle1;
                  DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect1, destrect1);
                }
              }
              else
                DrawMod.DrawBlock(ref graphics, num2 + 1, num3 + 19, 96, 72, 0, 0, 0, (int) byte.MaxValue);
            }
            int red5 = this.game.Data.RegimeObj[index1].Red;
            int green5 = this.game.Data.RegimeObj[index1].Green;
            int blue5 = this.game.Data.RegimeObj[index1].Blue;
            switch (baseColor)
            {
              case 0:
                ref Graphics local7 = ref graphics;
                bitmap = BitmapStore.GetBitmap(picSpriteId);
                ref Bitmap local8 = ref bitmap;
                int x1 = num2 + 1;
                int y1 = num3 + 19;
                DrawMod.DrawScaled(ref local7, ref local8, x1, y1, 96, 72);
                break;
              case 1:
                ref Graphics local9 = ref graphics;
                bitmap = BitmapStore.GetBitmap(picSpriteId);
                ref Bitmap local10 = ref bitmap;
                int x2 = num2 + 1;
                int y2 = num3 + 19;
                int width1 = BitmapStore.GetWidth(picSpriteId);
                int origh1 = BitmapStore.Getheight(picSpriteId);
                double r1 = (double) ((float) red5 / 256f);
                double g1 = (double) ((float) green5 / 256f);
                double b1 = (double) ((float) blue5 / 256f);
                DrawMod.DrawScaledColorized2(ref local9, ref local10, x2, y2, 96, 72, width1, origh1, (float) r1, (float) g1, (float) b1, 1f);
                break;
              case 2:
                int red2_3 = this.game.Data.RegimeObj[index1].Red2;
                int green2_3 = this.game.Data.RegimeObj[index1].Green2;
                int blue2_3 = this.game.Data.RegimeObj[index1].Blue2;
                ref Graphics local11 = ref graphics;
                bitmap = BitmapStore.GetBitmap(picSpriteId);
                ref Bitmap local12 = ref bitmap;
                int x3 = num2 + 1;
                int y3 = num3 + 19;
                int width2 = BitmapStore.GetWidth(picSpriteId);
                int origh2 = BitmapStore.Getheight(picSpriteId);
                double r2 = (double) ((float) red2_3 / 256f);
                double g2 = (double) ((float) green2_3 / 256f);
                double b2 = (double) ((float) blue2_3 / 256f);
                DrawMod.DrawScaledColorized2(ref local11, ref local12, x3, y3, 96, 72, width2, origh2, (float) r2, (float) g2, (float) b2, 1f);
                break;
              case 3:
                int red3_1 = this.game.Data.RegimeObj[index1].Red3;
                int green3_1 = this.game.Data.RegimeObj[index1].Green3;
                int blue3_1 = this.game.Data.RegimeObj[index1].Blue3;
                ref Graphics local13 = ref graphics;
                bitmap = BitmapStore.GetBitmap(picSpriteId);
                ref Bitmap local14 = ref bitmap;
                int x4 = num2 + 1;
                int y4 = num3 + 19;
                int width3 = BitmapStore.GetWidth(picSpriteId);
                int origh3 = BitmapStore.Getheight(picSpriteId);
                double r3 = (double) ((float) red3_1 / 256f);
                double g3 = (double) ((float) green3_1 / 256f);
                double b3 = (double) ((float) blue3_1 / 256f);
                DrawMod.DrawScaledColorized2(ref local13, ref local14, x4, y4, 96, 72, width3, origh3, (float) r3, (float) g3, (float) b3, 1f);
                break;
              case 4:
                int red4_1 = this.game.Data.RegimeObj[index1].Red4;
                int green4_1 = this.game.Data.RegimeObj[index1].Green4;
                int blue4_1 = this.game.Data.RegimeObj[index1].Blue4;
                ref Graphics local15 = ref graphics;
                bitmap = BitmapStore.GetBitmap(picSpriteId);
                ref Bitmap local16 = ref bitmap;
                int x5 = num2 + 1;
                int y5 = num3 + 19;
                int width4 = BitmapStore.GetWidth(picSpriteId);
                int origh4 = BitmapStore.Getheight(picSpriteId);
                double r4 = (double) ((float) red4_1 / 256f);
                double g4 = (double) ((float) green4_1 / 256f);
                double b4 = (double) ((float) blue4_1 / 256f);
                DrawMod.DrawScaledColorized2(ref local15, ref local16, x5, y5, 96, 72, width4, origh4, (float) r4, (float) g4, (float) b4, 1f);
                break;
              case 5:
                ref Graphics local17 = ref graphics;
                bitmap = BitmapStore.GetBitmap(picSpriteId);
                ref Bitmap local18 = ref bitmap;
                int x6 = num2 + 1;
                int y6 = num3 + 19;
                int width5 = BitmapStore.GetWidth(picSpriteId);
                int origh5 = BitmapStore.Getheight(picSpriteId);
                double r5 = (double) ((float) (red5 + 392) / 1024f);
                double g5 = (double) ((float) (green5 + 392) / 1024f);
                double b5 = (double) ((float) (blue5 + 392) / 1024f);
                DrawMod.DrawScaledColorized2(ref local17, ref local18, x6, y6, 96, 72, width5, origh5, (float) r5, (float) g5, (float) b5, 1f);
                break;
              case 6:
                ref Graphics local19 = ref graphics;
                bitmap = BitmapStore.GetBitmap(picSpriteId);
                ref Bitmap local20 = ref bitmap;
                int x7 = num2 + 1;
                int y7 = num3 + 19;
                int width6 = BitmapStore.GetWidth(picSpriteId);
                int origh6 = BitmapStore.Getheight(picSpriteId);
                double r6 = (double) ((float) (red5 + 80) / 512f);
                double g6 = (double) ((float) (green5 + 200) / 512f);
                double b6 = (double) ((float) (blue5 + 80) / 512f);
                DrawMod.DrawScaledColorized2(ref local19, ref local20, x7, y7, 96, 72, width6, origh6, (float) r6, (float) g6, (float) b6, 1f);
                break;
            }
            if ((double) this.game.Data.RuleVar[870] > 0.0 & !Information.IsNothing((object) BitmapStore.GetBitmap(sidewaysSpriteId)))
            {
              ref Graphics local21 = ref graphics;
              bitmap = BitmapStore.GetBitmap(sidewaysSpriteId);
              ref Bitmap local22 = ref bitmap;
              int x8 = num2 + 1;
              int y8 = num3 + 19;
              DrawMod.DrawScaled(ref local21, ref local22, x8, y8, 96, 72);
            }
            if ((double) this.game.Data.RuleVar[869] >= 1.0 & (double) this.game.Data.RuleVar[869] < 3.0 && this.game.Data.UnitObj[this.unr].X > -1)
            {
              int index6 = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y].LandscapeType;
              int index7 = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y].SpriteNr;
              if (this.game.Data.LandscapeTypeObj[index6].AirOverride > -1 & this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater == 2)
              {
                index6 = this.game.Data.LandscapeTypeObj[index6].AirOverride;
                index7 = 0;
              }
              else if ((double) this.game.Data.RuleVar[848] > 0.0 & this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater == 2)
              {
                index6 = (int) Math.Round((double) this.game.Data.RuleVar[848]);
                index7 = 0;
              }
              if (this.game.Data.LandscapeTypeObj[index6].NavyOverride > -1 & this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater == 1)
              {
                index6 = this.game.Data.LandscapeTypeObj[index6].NavyOverride;
                index7 = 0;
              }
              else if ((double) this.game.Data.RuleVar[872] > 0.0 & this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater == 1)
              {
                index6 = (int) Math.Round((double) this.game.Data.RuleVar[872]);
                index7 = 0;
              }
              int nr = this.game.Data.LandscapeTypeObj[index6].SidewaysSPriteID3[index7];
              ref Graphics local23 = ref graphics;
              bitmap = BitmapStore.GetBitmap(nr);
              ref Bitmap local24 = ref bitmap;
              rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr));
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(num2 + 1, num3 + 19, 96, 72);
              Rectangle destrect = rectangle1;
              DrawMod.DrawSimplePart2(ref local23, ref local24, srcrect, destrect);
            }
            DrawMod.DrawRectangle(ref graphics, num2, num3 + 18, 97, 73, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
            if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].EP > 0)
            {
              string str = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sf].EP));
              if (coordinate1.x < 2)
                str = "?";
              ref Graphics local25 = ref graphics;
              rectangle2 = new Rectangle(num2 + 98, num3 + 18, 26, 15);
              Rectangle rect1 = rectangle2;
              rectangle1 = new Rectangle(num2 + 124, num3 + 18, 28, 15);
              Rectangle rect2 = rectangle1;
              string txt2 = str;
              DrawMod.MakeFullBoxVic(ref local25, rect1, "EP", rect2, txt2, 3);
            }
            else
            {
              string str = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sf].Ap));
              if (coordinate1.x < 2)
                str = "?";
              ref Graphics local26 = ref graphics;
              rectangle2 = new Rectangle(num2 + 98, num3 + 18, 26, 15);
              Rectangle rect1 = rectangle2;
              rectangle1 = new Rectangle(num2 + 124, num3 + 18, 28, 15);
              Rectangle rect2 = rectangle1;
              string txt2 = str;
              DrawMod.MakeFullBoxVic(ref local26, rect1, "AP", rect2, txt2, 3);
            }
            string str1 = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sf].Rdn));
            if (coordinate1.x < 2)
              str1 = "?";
            ref Graphics local27 = ref graphics;
            rectangle2 = new Rectangle(num2 + 98, num3 + 18 + 15, 26, 15);
            Rectangle rect1_1 = rectangle2;
            rectangle1 = new Rectangle(num2 + 124, num3 + 18 + 15, 28, 15);
            Rectangle rect2_1 = rectangle1;
            string txt2_1 = str1;
            DrawMod.MakeFullBoxVic(ref local27, rect1_1, "RDN", rect2_1, txt2_1, 3);
            string str2 = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sf].Xp));
            if (coordinate1.x < 2)
              str2 = "?";
            ref Graphics local28 = ref graphics;
            rectangle2 = new Rectangle(num2 + 98, num3 + 18 + 30, 26, 15);
            Rectangle rect1_2 = rectangle2;
            rectangle1 = new Rectangle(num2 + 124, num3 + 18 + 30, 28, 15);
            Rectangle rect2_2 = rectangle1;
            string txt2_2 = str2;
            DrawMod.MakeFullBoxVic(ref local28, rect1_2, "EXP", rect2_2, txt2_2, 3);
            string str3 = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sf].Mor));
            if (coordinate1.x < 2)
              str3 = "?";
            ref Graphics local29 = ref graphics;
            rectangle2 = new Rectangle(num2 + 98, num3 + 18 + 45, 26, 15);
            Rectangle rect1_3 = rectangle2;
            rectangle1 = new Rectangle(num2 + 124, num3 + 18 + 45, 28, 15);
            Rectangle rect2_3 = rectangle1;
            string txt2_3 = str3;
            DrawMod.MakeFullBoxVic(ref local29, rect1_3, "MOR", rect2_3, txt2_3, 3);
            string str4 = Strings.LCase(Strings.Left(this.game.Data.PeopleObj[people].Name, 3));
            if (coordinate1.x < 2)
              str4 = "?";
            ref Graphics local30 = ref graphics;
            rectangle2 = new Rectangle(num2 + 98, num3 + 18 + 60, 26, 15);
            Rectangle rect1_4 = rectangle2;
            rectangle1 = new Rectangle(num2 + 124, num3 + 18 + 60, 28, 15);
            Rectangle rect2_4 = rectangle1;
            string txt2_4 = str4;
            DrawMod.MakeFullBoxVic(ref local30, rect1_4, "PE", rect2_4, txt2_4, 3);
            if (this.game.Data.SFObj[sf].OffMod > 0)
            {
              string tstring2 = "+" + Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sf].OffMod)) + "%";
              DrawMod.DrawBlockGradient2(ref graphics, num2 + 10, num3 + 25, 31, 15, Color.Red, Color.DarkRed);
              DrawMod.DrawTextVic(ref graphics, tstring2, this.game.VicFont4, num2 + 11, num3 + 27, this.game.VicColor1, this.game.VicColor1Shade);
            }
            else if (this.game.Data.SFObj[sf].OffMod < 0)
            {
              DrawMod.DrawBlockGradient2(ref graphics, num2 + 10, num3 + 25, 31, 15, Color.Red, Color.DarkRed);
              string tstring3 = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sf].OffMod)) + "%";
              DrawMod.DrawTextVic(ref graphics, tstring3, this.game.VicFont4, num2 + 11, num3 + 27, this.game.VicColor1, this.game.VicColor1Shade);
            }
            if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater == 2)
            {
              float num6 = (double) this.game.HandyFunctionsObj.GetAirFieldStackModifier(this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y) >= 1.0 ? 1f : (float) (0.33 + 0.66 * (double) this.game.HandyFunctionsObj.GetAirFieldStackModifier(this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y));
              if ((double) num6 < 1.0)
              {
                int Number2 = -(int) Math.Round(100.0 - 100.0 * (double) num6);
                DrawMod.DrawBlockGradient2(ref graphics, num2 + 10, num3 + 75, 31, 15, Color.Green, Color.DarkGreen);
                string tstring4 = Strings.Trim(Conversion.Str((object) Number2)) + "%";
                DrawMod.DrawTextVic(ref graphics, tstring4, this.game.VicFont4, num2 + 11, num3 + 77, this.game.VicColor1, this.game.VicColor1Shade);
              }
            }
            if (this.game.Data.SFObj[sf].DefMod > 0)
            {
              string tstring5 = "+" + Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sf].DefMod)) + "%";
              DrawMod.DrawBlockGradient2(ref graphics, num2 + 60, num3 + 25, 33, 15, Color.Blue, Color.DarkBlue);
              DrawMod.DrawTextVic(ref graphics, tstring5, this.game.VicFont4, num2 + 61, num3 + 27, this.game.VicColor1, this.game.VicColor1Shade);
            }
            else if (this.game.Data.SFObj[sf].DefMod < 0)
            {
              DrawMod.DrawBlockGradient2(ref graphics, num2 + 60, num3 + 25, 33, 15, Color.Blue, Color.DarkBlue);
              string tstring6 = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sf].DefMod)) + "%";
              DrawMod.DrawTextVic(ref graphics, tstring6, this.game.VicFont4, num2 + 61, num3 + 27, this.game.VicColor1, this.game.VicColor1Shade);
            }
            if (this.game.Data.SFObj[sf].MoveType > -1)
            {
              string tstring7 = Strings.UCase(this.game.Data.TempString[this.game.Data.SFObj[sf].MoveType]);
              DrawMod.DrawTextVic(ref graphics, tstring7, this.game.VicFont4, num2 + 4, num3 + 83, this.game.VicColor1, this.game.VicColor1Shade);
            }
          }
        }
        if (this.game.Data.UnitObj[this.unr].PassengerCounter > -1)
        {
          int passengerCounter = this.game.Data.UnitObj[this.unr].PassengerCounter;
          for (int index = 0; index <= passengerCounter; ++index)
          {
            ++num1;
            int passenger = this.game.Data.UnitObj[this.unr].PassengerList[index];
            int num7 = (int) Math.Round(3.0 + Conversion.Int((double) num1 / 4.0) * -620.0 + (double) (num1 * 155));
            int num8 = (int) Math.Round(3.0 + Conversion.Int((double) num1 / 4.0) * 100.0);
            if (this.game.EditObj.SFSelected == num1)
              DrawMod.DrawBlockGradient(ref graphics, num7, num8, 150, 95, c1_2, c2_2);
            else
              DrawMod.DrawBlockGradient(ref graphics, num7, num8, 150, 95, c1_1, c2_1);
            this.game.CustomBitmapObj.DrawUnit(passenger, toG: graphics, tx: (num7 + 46), ty: (num8 + 30));
            DrawMod.DrawBlock(ref graphics, num7, num8, 150, 25, 0, 0, 0, 100);
            string name = this.game.Data.UnitObj[passenger].Name;
            DrawMod.DrawText(ref graphics, name, new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), num7, num8);
            if (this.game.EditObj.SFSelected != index)
              ;
          }
        }
      }
      if (!Information.IsNothing((object) graphics))
      {
        graphics.Dispose();
        graphics = (Graphics) null;
      }
      return this.OwnBitmap;
    }

    public override void DescriptInfo(int ix, int iy)
    {
      this.Descript = "";
      int num = (int) Math.Round(Conversion.Int((double) iy / 102.0) * 4.0 + Conversion.Int((double) ix / 155.0));
      if (num > this.game.Data.UnitObj[this.unr].SFCount)
      {
        if (num - (this.game.Data.UnitObj[this.unr].SFCount + 1) > this.game.Data.UnitObj[this.unr].PassengerCounter)
          return;
        this.Descript = "Click to see info on passenger.";
      }
      else
        this.Descript = "Click to see info on this SubformationType. (Ap=Action points, Rd=Readiness, Xp=Experience, Mo=Morale, Pe=People)";
    }

    public override int Click(int x, int y, int b = 1)
    {
      if (this.game.Data.UnitObj[this.unr].SFCount > 7)
      {
        int num = (int) Math.Round(Conversion.Int((double) y / 55.0) * 4.0 + Conversion.Int((double) x / 155.0));
        if (num <= this.game.Data.UnitObj[this.unr].SFCount || num - (this.game.Data.UnitObj[this.unr].SFCount + 1) <= this.game.Data.UnitObj[this.unr].PassengerCounter)
          return num;
      }
      else
      {
        int num = (int) Math.Round(Conversion.Int((double) y / 102.0) * 4.0 + Conversion.Int((double) x / 155.0));
        if (num <= this.game.Data.UnitObj[this.unr].SFCount || num - (this.game.Data.UnitObj[this.unr].SFCount + 1) <= this.game.Data.UnitObj[this.unr].PassengerCounter)
          return num;
      }
      return -1;
    }

    public override Bitmap PaintOverlay()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      ref Graphics local1 = ref Expression;
      Bitmap bitmap = BitmapStore.GetBitmap(Conversions.ToInteger(this.OwnBitmapNr));
      ref Bitmap local2 = ref bitmap;
      DrawMod.Draw(ref local1, ref local2, 0, 0, 0.3f, 0.3f, 0.3f, 1f);
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }
  }
}
