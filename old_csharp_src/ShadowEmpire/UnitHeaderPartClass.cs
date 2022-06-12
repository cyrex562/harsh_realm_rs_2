// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.UnitHeaderPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class UnitHeaderPartClass : SubPartClass
  {
    private object OwnBitmapNr;
    private int unr;
    private GameClass game;
    private int his;

    public UnitHeaderPartClass(int tunr, GameClass tgame)
      : base(280, 200)
    {
      this.unr = tunr;
      this.game = tgame;
      this.his = this.game.Data.UnitObj[this.unr].Historical;
    }

    public override void DescriptInfo(int x, int y)
    {
      if (this.game.EditObj.UnitSelected == -1)
        return;
      this.Descript = "";
      if (x > 105 & y > 5 & x < 140 & y < 45)
        this.Descript = "Action Points";
      if (x > 0 & y > 152 & x < 70 & y < 204)
        this.Descript = "Supply % consumed at start of this turn.";
      if (x > 140 & y > 5 & x < 175 & y < 45)
        this.Descript = "Readiness.";
      if (x > 175 & y > 5 & x < 210 & y < 45)
        this.Descript = "Experience.";
      if (x > 210 & y > 5 & x < 245 & y < 45)
        this.Descript = "Morale.";
      if (x > 245 & y > 5 & x < 280 & y < 45)
        this.Descript = "Entrenchment.";
      if (x > 125 & y > 123 & x < 277 & y < 143)
      {
        int hq = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ;
        if (this.game.Data.Round != 0 & this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime != this.game.Data.Turn & this.game.Data.FOWOn)
        {
          this.Descript = "HQ power and Staff points in HQ expressed as a % of needed staff points. ";
        }
        else
        {
          int Number1;
          int Number2;
          if (hq == -1 | this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
          {
            Number1 = 0;
            Number2 = 0;
          }
          else
          {
            int num1 = this.game.HandyFunctionsObj.GetStaffPercent(hq, true);
            int num2 = this.game.HandyFunctionsObj.GetStaffPercent(hq, true);
            int num3 = this.game.HandyFunctionsObj.GetStaffPercent(hq);
            int num4 = this.game.HandyFunctionsObj.GetStaffPercent(hq);
            if (num1 > 100)
              num1 = 100;
            if (num2 > 100)
              num2 = 100;
            if (num3 > 100)
              num3 = 100;
            if (num4 > 100)
              num4 = 100;
            Number1 = (int) Math.Round((double) (int) Math.Round((double) num1 * (double) this.game.HandyFunctionsObj.GetStaffCombatMod(hq) * ((double) this.game.HandyFunctionsObj.Gethqpow(this.game.EditObj.UnitSelected) / 100.0)) + (double) num3 * (double) this.game.Data.RuleVar[140] * ((double) this.game.HandyFunctionsObj.Gethqpow(this.game.EditObj.UnitSelected) / 100.0));
            Number2 = (int) Math.Round((double) (int) Math.Round((double) num2 * (double) this.game.HandyFunctionsObj.GetStaffMoraleMod(hq) * ((double) this.game.HandyFunctionsObj.Gethqpow(this.game.EditObj.UnitSelected) / 100.0)) + (double) num4 * (double) this.game.Data.RuleVar[141] * ((double) this.game.HandyFunctionsObj.Gethqpow(this.game.EditObj.UnitSelected) / 100.0));
          }
          if (this.game.HandyFunctionsObj.HasUnitlandSF(this.unr))
            this.Descript = "Staff points in HQ expressed as a % of needed staff points. Current CombatMod = +" + Conversion.Str((object) Number1) + "%. Current MoraleMod = +" + Conversion.Str((object) Number2) + "%";
          else
            this.Descript = "Staff only gives bonuses to land theater subformations. not to air and navy.";
        }
      }
      if (x > 125 & y > 70 & x < 277 & y < 88)
        this.Descript = "Click to change name of unit.";
      if (x > 125 & y > 90 & x < 277 & y < 108)
      {
        if (this.game.Data.UnitObj[this.unr].Regime == this.game.Data.Turn)
          this.Descript = "Click to jump to units HQ.";
        else
          this.Descript = "";
      }
      if (x > 0 & y > 65 & x < 44 & y < 103)
        this.Descript = "For all practical purposes this unit travels with the movement speed this movement type";
      if (x > 0 & y > 105 & x < 44 & y < 132)
        this.Descript = "The regime controlling the unit. " + this.game.Data.RegimeObj[this.game.Data.UnitObj[this.unr].Regime].Name;
      if (x > 44 & y > 60 & x < 122 & y < 138)
      {
        if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
          this.Descript = "The selected unit. Click to change color of hq.";
        else
          this.Descript = "The selected unit.";
      }
      if (x > 70 & y > 152 & x < 140 & y < 204)
        this.Descript = "Supply Stock. The total number of supply points with the unit.";
      if (x > 140 & y > 152 & x < 210 & y < 204)
      {
        if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
          this.Descript = "Supply Requested Out";
        else
          this.Descript = "Supply Requested In";
      }
      if (!(x > 210 & y > 152 & x < 280 & y < 204))
        return;
      if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
        this.Descript = "Supply Send Out";
      else
        this.Descript = "Supply Received In";
    }

    public override Bitmap Paint()
    {
      SizeF sizeF1 = new SizeF();
      Coordinate coordinate = new Coordinate();
      if (this.game.Data.UnitObj[this.unr].Regime == this.game.Data.Turn | this.game.Data.Round == 0)
        coordinate.x = 3;
      else
        coordinate = this.game.HandyFunctionsObj.GetReconMinusHide(this.unr, this.game.Data.Turn);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      Conversions.ToInteger(this.game.HandyFunctionsObj.GetUnitPeople(this.unr));
      int regime = this.game.Data.UnitObj[this.unr].Regime;
      string str1 = this.game.Data.UnitObj[this.unr].Name;
      ref Graphics local1 = ref graphics;
      Rectangle rectangle1 = new Rectangle(0, 35, 150, 14);
      Rectangle rect1_1 = rectangle1;
      Rectangle rectangle2;
      Rectangle rect2_1 = rectangle2;
      DrawMod.MakeFullBoxVic2(ref local1, rect1_1, "SELECTED UNIT", rect2_1, "");
      int num1 = 45;
      DrawMod.DrawBlock(ref graphics, 0, 5 + num1, 280, 95, (int) this.game.VicColor3Shade.R, (int) this.game.VicColor3Shade.G, (int) this.game.VicColor3Shade.B, (int) this.game.VicColor3Shade.A);
      DrawMod.DrawRectangle(ref graphics, 0, 5 + num1, 279, 95, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
      this.game.CustomBitmapObj.DrawUnitBig(this.unr, true, graphics, 44, 15 + num1, true);
      if ((double) this.game.Data.RuleVar[344] == 1.0 && (double) this.game.Data.RuleVar[337] == 1.0)
      {
        if (this.game.Data.UnitObj[this.unr].Historical > -1)
        {
          if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.unr].Historical].ModelMaster > -1)
          {
            string str2 = str1 + " (" + Strings.Left(this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.unr].Historical].ModelMaster].Name, 3);
            if (this.game.Data.UnitObj[this.unr].HistoricalSubPart > -1)
              str2 = str2 + ", " + Strings.Left(this.game.Data.UnitObj[this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.unr].Historical].SubParts[this.game.Data.UnitObj[this.unr].HistoricalSubPart])].Name, 3);
            str1 = str2 + ")";
          }
          else
            str1 += " (ad hoc)";
        }
        else
          str1 += " (remnant)";
      }
      if (coordinate.x < 2)
        str1 = "?";
      string str3 = str1;
      string str4;
      if (this.game.Data.UnitObj[this.unr].HQ > -1)
      {
        str4 = this.game.Data.UnitObj[this.game.Data.UnitObj[this.unr].HQ].Name;
        if (coordinate.x < 2)
          str4 = "HQ: ?";
      }
      else
      {
        str4 = "(has no HQ)";
        if (coordinate.x < 2)
          str4 = "HQ: ?";
      }
      string str5 = str4;
      string str6 = "";
      SizeF sizeF2;
      if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, this.game.Data.UnitObj[this.unr].Regime))
      {
        if (!this.game.Data.UnitObj[this.unr].IsHQ)
        {
          string str7 = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.Gethqpow(this.unr)));
          if (coordinate.x <= 2)
            str7 = "?";
          if (coordinate.x <= 1)
            str7 = "?";
          str6 = "HQP: " + str7 + "%" + ", ";
        }
        string str8;
        if (!this.game.Data.UnitObj[this.unr].IsHQ)
        {
          str8 = this.game.Data.UnitObj[this.unr].HQ <= -1 ? "N/A" : Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetStaffPercent(this.game.Data.UnitObj[this.unr].HQ)));
          if (coordinate.x <= 2)
            str8 = "?";
        }
        else
        {
          str8 = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetStaffPercent(this.unr)));
          if (coordinate.x <= 2)
            str8 = "?";
        }
        if (coordinate.x <= 1)
          str8 = "?";
        string str9 = str6 + "STF: " + str8 + "%";
        sizeF2 = graphics.MeasureString(str3, this.game.VicFont2);
        int num2 = (int) Math.Round((152.0 - (double) sizeF2.Width) / 2.0);
        if ((double) sizeF2.Width > 145.0)
        {
          sizeF2 = graphics.MeasureString(str3, this.game.VicFont4);
          int num3 = (int) Math.Round((152.0 - (double) sizeF2.Width) / 2.0);
          DrawMod.DrawTextVic2(ref graphics, str3, this.game.VicFont4, 125 + num3, 25 + num1, this.game.VicColor2, this.game.VicColor2Shade);
        }
        else
          DrawMod.DrawTextVic2(ref graphics, str3, this.game.VicFont2, 125 + num2, 25 + num1, this.game.VicColor2, this.game.VicColor2Shade);
        sizeF2 = graphics.MeasureString(str9, this.game.VicFont3);
        int num4 = (int) Math.Round((152.0 - (double) sizeF2.Width) / 2.0);
        DrawMod.DrawTextVic2(ref graphics, str9, this.game.VicFont3, 125 + num4, 78 + num1, this.game.VicColor1, this.game.VicColor1Shade);
        sizeF2 = graphics.MeasureString(str5, this.game.VicFont3);
        int num5 = (int) Math.Round((152.0 - (double) sizeF2.Width) / 2.0);
        if ((double) sizeF2.Width > 145.0)
        {
          sizeF2 = graphics.MeasureString(str5, this.game.VicFont4);
          int num6 = (int) Math.Round((152.0 - (double) sizeF2.Width) / 2.0);
          DrawMod.DrawTextVic2(ref graphics, str5, this.game.VicFont4, 125 + num6, 45 + num1, this.game.VicColor1, this.game.VicColor1Shade);
        }
        else
          DrawMod.DrawTextVic2(ref graphics, str5, this.game.VicFont3, 125 + num5, 45 + num1, this.game.VicColor1, this.game.VicColor1Shade);
      }
      else
      {
        string str10 = "HQPW: ?, STF: ?";
        int num7 = (int) Math.Round((152.0 - (double) graphics.MeasureString(str10, this.game.VicFont3).Width) / 2.0);
        DrawMod.DrawTextVic2(ref graphics, str10, this.game.VicFont3, 125 + num7, 78 + num1, this.game.VicColor1, this.game.VicColor1Shade);
        int num8 = (int) Math.Round((152.0 - (double) graphics.MeasureString(str3, this.game.VicFont2).Width) / 2.0);
        DrawMod.DrawTextVic2(ref graphics, str3, this.game.VicFont2, 125 + num8, 25 + num1, this.game.VicColor2, this.game.VicColor2Shade);
        int num9 = (int) Math.Round((152.0 - (double) graphics.MeasureString(str4, this.game.VicFont3).Width) / 2.0);
        DrawMod.DrawTextVic2(ref graphics, str4, this.game.VicFont3, 125 + num9, 45 + num1, this.game.VicColor1, this.game.VicColor1Shade);
      }
      int num10 = 0;
      Bitmap bitmap1;
      if (this.game.Data.Turn == this.game.Data.UnitObj[this.unr].Regime | !this.game.Data.FOWOn | this.game.Data.Round == 0 | coordinate.x >= 2)
      {
        num10 = 1;
        int nr = -1;
        int index1 = this.game.HandyFunctionsObj.GetLowestSpeed(this.unr, -1, true);
        if (index1 > -1)
        {
          int sfCount = this.game.Data.UnitObj[this.unr].SFCount;
          for (nr = 0; nr <= sfCount; ++nr)
          {
            if (this.game.Data.SFTypeObj[this.game.Data.SFObj[this.game.Data.UnitObj[this.unr].SFList[nr]].Type].SymbolGroup == this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].SymbolGroup && this.game.Data.SFTypeObj[this.game.Data.SFObj[this.game.Data.UnitObj[this.unr].SFList[nr]].Type].SymbolWeight > this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].SymbolWeight && this.game.Data.SFTypeObj[this.game.Data.SFObj[this.game.Data.UnitObj[this.unr].SFList[nr]].Type].MoveType == this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].MoveType)
              index1 = this.game.Data.UnitObj[this.unr].SFList[nr];
          }
        }
        string str11 = index1 <= -1 ? "Immobile" : (this.game.Data.SFObj[index1].MoveType != -1 ? Strings.Trim(this.game.Data.TempString[this.game.Data.SFObj[index1].MoveType]) : Strings.Trim(this.game.Data.TempString[this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].MoveType]));
        if (index1 == -2)
          nr = this.game.SUPPLIESSYMBOL;
        else if (index1 > -1)
          nr = this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].SymbolSpriteID;
        int integer = Conversions.ToInteger(this.game.HandyFunctionsObj.GetUnitPeople(this.unr));
        if (regime > -1 & index1 > -1)
        {
          if (this.game.Data.RegimeObj[regime].ExtraGraphicUse > -1)
          {
            int extraCounter = this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].ExtraCounter;
            for (int index2 = 0; index2 <= extraCounter; ++index2)
            {
              if (this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].ExtraCode[index2] == this.game.Data.RegimeObj[regime].ExtraGraphicUse)
                nr = this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].ExtraSymbolSpriteID[index2];
            }
          }
          else if (this.game.Data.PeopleObj[integer].ExtraGraphicUse > -1)
          {
            int extraCounter = this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].ExtraCounter;
            for (int index3 = 0; index3 <= extraCounter; ++index3)
            {
              if (this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].ExtraCode[index3] == this.game.Data.PeopleObj[integer].ExtraGraphicUse)
                nr = this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].ExtraSymbolSpriteID[index3];
            }
          }
        }
        if (coordinate.x < 3)
          nr = -1;
        if (nr > -1 & index1 > -1)
        {
          ref Graphics local2 = ref graphics;
          bitmap1 = BitmapStore.GetBitmap(nr);
          ref Bitmap local3 = ref bitmap1;
          int y = 20 + num1;
          DrawMod.DrawSimple(ref local2, ref local3, 2, y);
          string str12 = Strings.UCase(Strings.Left(this.game.Data.SFObj[index1].MoveType <= -1 ? this.game.Data.TempString[this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].MoveType] : this.game.Data.TempString[this.game.Data.SFObj[index1].MoveType], 5));
          sizeF2 = graphics.MeasureString(str12, this.game.VicFont5);
          DrawMod.DrawTextVic2(ref graphics, str12, this.game.VicFont5, (int) Math.Round(22.0 - (double) sizeF2.Width / 2.0), 43 + num1, this.game.VicColor1, this.game.VicColor1Shade);
        }
        else if (nr > -1)
        {
          ref Graphics local4 = ref graphics;
          Bitmap bitmap2 = BitmapStore.GetBitmap(nr);
          ref Bitmap local5 = ref bitmap2;
          int y = 20 + num1;
          DrawMod.DrawSimple(ref local4, ref local5, 2, y);
          string str13 = Strings.UCase(Strings.Left(str11, 5));
          sizeF2 = graphics.MeasureString(str13, this.game.VicFont5);
          DrawMod.DrawTextVic2(ref graphics, str13, this.game.VicFont5, (int) Math.Round(22.0 - (double) sizeF2.Width / 2.0), 43 + num1, this.game.VicColor1, this.game.VicColor1Shade);
        }
      }
      int hqSpriteNr = this.game.Data.RegimeObj[this.game.Data.UnitObj[this.unr].Regime].HQSpriteNr;
      ref Graphics local6 = ref graphics;
      bitmap1 = BitmapStore.GetBitmap(hqSpriteNr);
      ref Bitmap local7 = ref bitmap1;
      int y1 = 60 + num1;
      DrawMod.DrawSimple(ref local6, ref local7, 0, y1);
      if (this.game.Data.Turn == this.game.Data.UnitObj[this.unr].Regime | !this.game.Data.FOWOn | this.game.Data.Round == 0 | coordinate.x >= 1)
      {
        int num11 = -105;
        string str14 = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetLowestAp(this.unr)));
        if (coordinate.x == 2)
          str14 = "?";
        if (coordinate.x <= 1)
          str14 = "?";
        ref Graphics local8 = ref graphics;
        rectangle1 = new Rectangle(105, num11 + 110, 30, 14);
        Rectangle rect1_2 = rectangle1;
        Rectangle rectangle3 = new Rectangle(105, num11 + 124, 30, 23);
        Rectangle rect2_2 = rectangle3;
        string txt2_1 = str14;
        DrawMod.MakeFullBoxVic2(ref local8, rect1_2, "AP", rect2_2, txt2_1);
        int Number1 = this.game.HandyFunctionsObj.GetAverageRdn(this.unr);
        if (coordinate.x == 2)
        {
          this.game.HandyFunctionsObj.RandomizeForUnit(this.unr, 0);
          float num12 = (float) coordinate.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
          float num13 = (float) ((1.0 - (double) num12) * 2.0);
          float num14 = VBMath.Rnd() * num13 + num12;
          Number1 = (int) Math.Round((double) Conversion.Int((float) Number1 * num14));
          if (Number1 < 0)
            Number1 = 0;
          if (Number1 > 100)
            Number1 = 100;
        }
        string str15 = Strings.Trim(Conversion.Str((object) Number1));
        if (coordinate.x <= 1)
          str15 = "?";
        ref Graphics local9 = ref graphics;
        rectangle3 = new Rectangle(140, num11 + 110, 30, 14);
        Rectangle rect1_3 = rectangle3;
        rectangle1 = new Rectangle(140, num11 + 124, 30, 23);
        Rectangle rect2_3 = rectangle1;
        string txt2_2 = str15;
        DrawMod.MakeFullBoxVic2(ref local9, rect1_3, "RDN", rect2_3, txt2_2);
        int Number2 = this.game.HandyFunctionsObj.GetAverageXp(this.unr);
        if (coordinate.x == 2)
        {
          this.game.HandyFunctionsObj.RandomizeForUnit(this.unr, 0);
          float num15 = (float) coordinate.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
          float num16 = (float) ((1.0 - (double) num15) * 2.0);
          float num17 = VBMath.Rnd() * num16 + num15;
          Number2 = (int) Math.Round((double) Conversion.Int((float) Number2 * num17));
          if (Number2 < 0)
            Number2 = 0;
          if (Number2 > 100)
            Number2 = 100;
        }
        string str16 = Strings.Trim(Conversion.Str((object) Number2));
        if (coordinate.x <= 1)
          str16 = "?";
        ref Graphics local10 = ref graphics;
        rectangle3 = new Rectangle(175, num11 + 110, 30, 14);
        Rectangle rect1_4 = rectangle3;
        rectangle1 = new Rectangle(175, num11 + 124, 30, 23);
        Rectangle rect2_4 = rectangle1;
        string txt2_3 = str16;
        DrawMod.MakeFullBoxVic2(ref local10, rect1_4, "EXP", rect2_4, txt2_3);
        int Number3 = this.game.HandyFunctionsObj.GetAverageMor(this.unr);
        if (coordinate.x == 2)
        {
          this.game.HandyFunctionsObj.RandomizeForUnit(this.unr, 0);
          float num18 = (float) coordinate.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
          float num19 = (float) ((1.0 - (double) num18) * 2.0);
          float num20 = VBMath.Rnd() * num19 + num18;
          Number3 = (int) Math.Round((double) Conversion.Int((float) Number3 * num20));
          if (Number3 < 0)
            Number3 = 0;
          if (Number3 > 999)
            Number3 = 999;
        }
        string str17 = Strings.Trim(Conversion.Str((object) Number3));
        if (coordinate.x <= 1)
          str17 = "?";
        ref Graphics local11 = ref graphics;
        rectangle3 = new Rectangle(210, num11 + 110, 30, 14);
        Rectangle rect1_5 = rectangle3;
        rectangle1 = new Rectangle(210, num11 + 124, 30, 23);
        Rectangle rect2_5 = rectangle1;
        string txt2_4 = str17;
        DrawMod.MakeFullBoxVic2(ref local11, rect1_5, "MOR", rect2_5, txt2_4);
        int Number4 = this.game.HandyFunctionsObj.GetAverageEntrench(this.unr);
        if (coordinate.x == 2)
        {
          this.game.HandyFunctionsObj.RandomizeForUnit(this.unr, 0);
          float num21 = (float) coordinate.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
          float num22 = (float) ((1.0 - (double) num21) * 2.0);
          float num23 = VBMath.Rnd() * num22 + num21;
          Number4 = (int) Math.Round((double) Conversion.Int((float) Number4 * num23));
          if (Number4 < 0)
            Number4 = 0;
          if (Number4 > 999)
            Number4 = 999;
        }
        string str18 = Strings.Trim(Conversion.Str((object) Number4));
        if (coordinate.x <= 1)
          str18 = "?";
        ref Graphics local12 = ref graphics;
        rectangle3 = new Rectangle(245, num11 + 110, 30, 14);
        Rectangle rect1_6 = rectangle3;
        rectangle1 = new Rectangle(245, num11 + 124, 30, 23);
        Rectangle rect2_6 = rectangle1;
        string txt2_5 = str18;
        DrawMod.MakeFullBoxVic2(ref local12, rect1_6, "ENT", rect2_6, txt2_5);
        int num24 = 40;
        string str19 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].SupplyConsume)) + "%";
        if (coordinate.x <= 2)
          str19 = "?";
        if (coordinate.x <= 1)
          str19 = "?";
        ref Graphics local13 = ref graphics;
        rectangle3 = new Rectangle(0, num24 + 110, 65, 14);
        Rectangle rect1_7 = rectangle3;
        rectangle1 = new Rectangle(0, num24 + 124, 65, 23);
        Rectangle rect2_7 = rectangle1;
        string txt2_6 = str19;
        DrawMod.MakeFullBoxVic2(ref local13, rect1_7, "SUP.CONS", rect2_7, txt2_6);
        if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.unr].Regime, this.game.Data.Turn))
        {
          string str20 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].Supply));
          if (coordinate.x <= 2)
            str20 = "?";
          if (coordinate.x <= 1)
            str20 = "?";
          ref Graphics local14 = ref graphics;
          rectangle3 = new Rectangle(70, num24 + 110, 65, 14);
          Rectangle rect1_8 = rectangle3;
          rectangle1 = new Rectangle(70, num24 + 124, 65, 23);
          Rectangle rect2_8 = rectangle1;
          string txt2_7 = str20;
          DrawMod.MakeFullBoxVic2(ref local14, rect1_8, "SUP.STOCK", rect2_8, txt2_7);
          if (this.game.Data.UnitObj[this.unr].IsHQ)
          {
            string str21 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].SupplyReq));
            if (coordinate.x == 2)
              str21 = "?";
            if (coordinate.x <= 1)
              str21 = "?";
            ref Graphics local15 = ref graphics;
            rectangle3 = new Rectangle(140, num24 + 110, 65, 14);
            Rectangle rect1_9 = rectangle3;
            rectangle1 = new Rectangle(140, num24 + 124, 65, 23);
            Rectangle rect2_9 = rectangle1;
            string txt2_8 = str21;
            DrawMod.MakeFullBoxVic2(ref local15, rect1_9, "REQ.OUT", rect2_9, txt2_8);
            string str22 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].SupplyOut));
            if (coordinate.x == 2)
              str22 = "?";
            if (coordinate.x <= 1)
              str22 = "?";
            ref Graphics local16 = ref graphics;
            rectangle3 = new Rectangle(210, num24 + 110, 65, 14);
            Rectangle rect1_10 = rectangle3;
            rectangle1 = new Rectangle(210, num24 + 124, 65, 23);
            Rectangle rect2_10 = rectangle1;
            string txt2_9 = str22;
            DrawMod.MakeFullBoxVic2(ref local16, rect1_10, "SEND.OUT", rect2_10, txt2_9);
          }
          else
          {
            string str23 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].SupplyInReq));
            if (coordinate.x == 2)
              str23 = "?";
            if (coordinate.x <= 1)
              str23 = "?";
            ref Graphics local17 = ref graphics;
            rectangle3 = new Rectangle(140, num24 + 110, 65, 14);
            Rectangle rect1_11 = rectangle3;
            rectangle1 = new Rectangle(140, num24 + 124, 65, 23);
            Rectangle rect2_11 = rectangle1;
            string txt2_10 = str23;
            DrawMod.MakeFullBoxVic2(ref local17, rect1_11, "REQ.IN", rect2_11, txt2_10);
            string str24 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].SupplyIn));
            if (coordinate.x == 2)
              str24 = "?";
            if (coordinate.x <= 1)
              str24 = "?";
            ref Graphics local18 = ref graphics;
            rectangle3 = new Rectangle(210, num24 + 110, 65, 14);
            Rectangle rect1_12 = rectangle3;
            rectangle1 = new Rectangle(210, num24 + 124, 65, 23);
            Rectangle rect2_12 = rectangle1;
            string txt2_11 = str24;
            DrawMod.MakeFullBoxVic2(ref local18, rect1_12, "SUP.IN", rect2_12, txt2_11);
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
