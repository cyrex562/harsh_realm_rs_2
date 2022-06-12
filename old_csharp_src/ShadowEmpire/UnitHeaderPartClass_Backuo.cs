// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.UnitHeaderPartClass_Backuo
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class UnitHeaderPartClass_Backuo : SubPartClass
  {
    private object OwnBitmapNr;
    private int unr;
    private GameClass game;
    private int his;

    public UnitHeaderPartClass_Backuo(int tunr, GameClass tgame)
      : base(225, 200)
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
      if (x > 0 & y > 42 & x < 33 & y < 100)
        this.Descript = "Action Points";
      if (x > 33 & y > 42 & x < 71 & y < 100)
        this.Descript = "Supply % consumed at start of this turn.";
      if (x > 71 & y > 42 & x < 109 & y < 100)
        this.Descript = "Readiness.";
      if (x > 109 & y > 42 & x < 147 & y < 100)
        this.Descript = "Experience.";
      if (x > 147 & y > 42 & x < 185 & y < 100)
        this.Descript = "Morale.";
      if (x > 185 & y > 42 & x < 223 & y < 100)
        this.Descript = "Entrenchment.";
      if (x > 0 & y > 170 & x < 100 & y < 190)
        this.Descript = "Weight of whole unit.";
      if (x > 0 & y > 110 & x < 100 & y < 130)
        this.Descript = "Stack Points of whole unit.";
      if (x > 0 & y > 130 & x < 100 & y < 150)
        this.Descript = "Land Transport Capacity. (for transfers)";
      if (x > 0 & y > 150 & x < 100 & y < 170)
        this.Descript = "Navy Transport Capacity. (for naval transfers)";
      if (x > 125 & y > 110 & x < 225 & y < 130)
      {
        int hq = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ;
        if (this.game.Data.Round != 0 & this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime != this.game.Data.Turn & this.game.Data.FOWOn)
        {
          this.Descript = "Staff points in HQ expressed as a % of needed staff points. ";
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
      if (x > 125 & y > 130 & x < 225 & y < 150)
        this.Descript = "Headquarter Power over unit (determines staff influence).";
      if (x > 125 & y > 150 & x < 225 & y < 170)
        this.Descript = "Carry Points. L=Land, N=Navy, A=Air. ";
      if (x > 125 & y > 170 & x < 225 & y < 190)
      {
        if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
        {
          if ((double) this.game.Data.RuleVar[509] == 0.0)
            this.Descript = "Rail capacity availabe";
          else
            this.Descript = "";
        }
        else
          this.Descript = "Aircraftcarrier Points / And amount of those used.";
      }
      if (x > 45 & y > 0 & x < 200 & y < 17)
        this.Descript = "Click to change name of unit.";
      if (x > 45 & y > 17 & x < 200 & y < 30)
      {
        if (this.game.Data.UnitObj[this.unr].Regime == this.game.Data.Turn)
          this.Descript = "Click to jump to units HQ.";
        else
          this.Descript = "";
      }
      if (x > 190 & y < 41)
        this.Descript = "For all practical purposes this unit travels with the movement speed this movement type";
      if (!(x > 5 & y > 1 & x < 43 & y < 38) || !this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
        return;
      this.Descript = "Click to change color of hq.";
    }

    public override Bitmap Paint()
    {
      SizeF sizeF1 = new SizeF();
      Coordinate coordinate = new Coordinate();
      if (this.game.Data.UnitObj[this.unr].Regime == this.game.Data.Turn | this.game.Data.Round == 0)
        coordinate.x = 3;
      else
        coordinate = this.game.HandyFunctionsObj.GetReconMinusHide(this.unr, this.game.Data.Turn);
      Graphics toG = Graphics.FromImage((Image) this.OwnBitmap);
      int integer1 = Conversions.ToInteger(this.game.HandyFunctionsObj.GetUnitPeople(this.unr));
      int regime = this.game.Data.UnitObj[this.unr].Regime;
      int index1 = regime;
      if (this.game.Data.PeopleObj[integer1].RegCol > -1)
        index1 = this.game.Data.PeopleObj[integer1].RegCol;
      int red1 = this.game.Data.RegimeObj[index1].Red;
      int green1 = this.game.Data.RegimeObj[index1].Green;
      int blue1 = this.game.Data.RegimeObj[index1].Blue;
      int red2 = this.game.Data.RegimeObj[index1].Red2;
      int green2 = this.game.Data.RegimeObj[index1].Green2;
      int blue2 = this.game.Data.RegimeObj[index1].Blue2;
      int red3 = red1 - 50;
      int green3 = green1 - 50;
      int blue3 = blue1 - 50;
      int red4 = red1 + 40;
      int green4 = green1 + 40;
      int blue4 = blue1 + 40;
      if (red4 > (int) byte.MaxValue)
        red4 = (int) byte.MaxValue;
      if (green4 > (int) byte.MaxValue)
        green4 = (int) byte.MaxValue;
      if (blue4 > (int) byte.MaxValue)
        blue4 = (int) byte.MaxValue;
      if (0 > red3)
        red3 = 0;
      if (0 > green3)
        green3 = 0;
      if (0 > blue3)
        blue3 = 0;
      Color.FromArgb((int) byte.MaxValue, red4, green4, blue4);
      Color.FromArgb((int) byte.MaxValue, red3, green3, blue3);
      Color.FromArgb((int) byte.MaxValue, red2, green2, blue2);
      this.game.CustomBitmapObj.DrawUnit(this.unr, toG: toG, tx: 5, ShowAttacker: true);
      string str1 = this.game.Data.UnitObj[this.unr].Name;
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
      SizeF sizeF2 = toG.MeasureString(str1, this.game.GameFont3);
      if ((double) sizeF2.Width < 150.0)
      {
        DrawMod.DrawText(ref toG, str1, this.game.GameFont3, 45, 0);
      }
      else
      {
        sizeF2 = toG.MeasureString(str1, this.game.GameFont1);
        if ((double) sizeF2.Width < 150.0)
          DrawMod.DrawText(ref toG, str1, this.game.GameFont1, 45, 0);
        else
          DrawMod.DrawText(ref toG, str1, this.game.GameFont2, 45, 0);
      }
      if (this.game.Data.UnitObj[this.unr].HQ > -1)
      {
        string str3 = this.game.Data.UnitObj[this.game.Data.UnitObj[this.unr].HQ].Name;
        if (coordinate.x < 2)
          str3 = "?";
        DrawMod.DrawTextColoured(ref toG, "HQ: " + str3, new Font(this.game.FontCol.Families[1], 11f, FontStyle.Underline, GraphicsUnit.Pixel), 45, 17, Color.White);
      }
      else
      {
        string tstring = "(has no HQ)";
        if (coordinate.x < 2)
          tstring = "HQ: ?";
        DrawMod.DrawTextColoured(ref toG, tstring, new Font(this.game.FontCol.Families[1], 11f, FontStyle.Italic, GraphicsUnit.Pixel), 45, 17, Color.White);
      }
      int num1 = 0;
      if (!this.game.Data.FOWOn)
        num1 = 1;
      if (this.unr > -1)
      {
        if (this.game.Data.Turn == this.game.Data.UnitObj[this.unr].Regime)
          num1 = 1;
        if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, this.game.Data.UnitObj[this.unr].Regime))
          num1 = 1;
      }
      if (num1 == 1 & (double) this.game.Data.RuleVar[354] == 1.0 && this.game.HandyFunctionsObj.GetStartPower(this.unr) > 0 & !this.game.Data.UnitObj[this.unr].IsHQ)
      {
        DrawMod.DrawBlock(ref toG, 40, 39, 184, 10, (int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue);
        int breakPercent = this.game.HandyFunctionsObj.GetBreakPercent(this.unr);
        int powerPtsAbsolute = this.game.HandyFunctionsObj.GetPowerPtsAbsolute(this.unr, true);
        int num2 = (int) Math.Round((double) this.game.Data.RuleVar[307]);
        int startPower = this.game.HandyFunctionsObj.GetStartPower(this.unr);
        int num3 = (int) Math.Round((double) startPower * ((double) breakPercent / 100.0));
        float num4 = startPower < powerPtsAbsolute ? 184f / (float) powerPtsAbsolute : 184f / (float) startPower;
        int w1 = (int) Math.Round((double) ((float) num3 * num4));
        int num5 = (int) Math.Round((double) ((float) startPower * num4));
        int num6 = (int) Math.Round((double) ((float) powerPtsAbsolute * num4));
        int w2 = (int) Math.Round((double) ((float) num2 * num4));
        if (num5 >= num6)
        {
          DrawMod.DrawBlockGradient(ref toG, 40 + w1 - 5, 39, num5 - w1 + 5, 10, Color.Yellow, Color.Green);
          DrawMod.DrawBlockGradient(ref toG, 40, 39, w1, 10, Color.Red, Color.Yellow);
          DrawMod.DrawBlockGradient(ref toG, 40, 39, w2, 10, Color.Red, Color.Red);
          DrawMod.DrawBlock(ref toG, 225 - (184 - num6), 39, 184 - num6, 10, 0, 0, 0, (int) byte.MaxValue);
        }
        else
        {
          DrawMod.DrawBlockGradient(ref toG, 40, 39, 184, 10, Color.Yellow, Color.Green);
          DrawMod.DrawBlockGradient(ref toG, 40, 39, w1, 10, Color.Red, Color.Yellow);
          DrawMod.DrawBlockGradient(ref toG, 40, 39, w2, 10, Color.Red, Color.Red);
        }
        DrawMod.drawLine(ref toG, 40 + num5, 39, 40 + num5, 49, (int) this.game.GameCol2.R, (int) this.game.GameCol2.G, (int) this.game.GameCol2.B, (int) byte.MaxValue);
        DrawMod.drawLine(ref toG, 40 + w1, 39, 40 + w1, 49, (int) this.game.GameCol2.R, (int) this.game.GameCol2.G, (int) this.game.GameCol2.B, (int) byte.MaxValue);
        DrawMod.drawLine(ref toG, 40 + w2, 39, 40 + w2, 49, (int) this.game.GameCol2.R, (int) this.game.GameCol2.G, (int) this.game.GameCol2.B, (int) byte.MaxValue);
        DrawMod.DrawBlockGradient(ref toG, 1, 39, 40, 10, this.game.GameCol5, this.game.GameCol6);
        DrawMod.DrawRectangle(ref toG, 0, 39, 224, 10, (int) this.game.GameCol2.R, (int) this.game.GameCol2.G, (int) this.game.GameCol2.B, (int) byte.MaxValue);
        DrawMod.drawLine(ref toG, 40, 39, 40, 49, (int) this.game.GameCol2.R, (int) this.game.GameCol2.G, (int) this.game.GameCol2.B, (int) byte.MaxValue);
        DrawMod.DrawText(ref toG, "Intgrty", this.game.GameFont2, 3, 37);
      }
      int num7 = 0;
      if (this.game.Data.Turn == this.game.Data.UnitObj[this.unr].Regime | !this.game.Data.FOWOn | this.game.Data.Round == 0 | coordinate.x >= 2)
      {
        num7 = 1;
        int nr = -1;
        int index2 = this.game.HandyFunctionsObj.GetLowestSpeed(this.unr, -1, true);
        if (index2 > -1)
        {
          int sfCount = this.game.Data.UnitObj[this.unr].SFCount;
          for (nr = 0; nr <= sfCount; ++nr)
          {
            if (this.game.Data.SFTypeObj[this.game.Data.SFObj[this.game.Data.UnitObj[this.unr].SFList[nr]].Type].SymbolGroup == this.game.Data.SFTypeObj[this.game.Data.SFObj[index2].Type].SymbolGroup && this.game.Data.SFTypeObj[this.game.Data.SFObj[this.game.Data.UnitObj[this.unr].SFList[nr]].Type].SymbolWeight > this.game.Data.SFTypeObj[this.game.Data.SFObj[index2].Type].SymbolWeight)
              index2 = this.game.Data.UnitObj[this.unr].SFList[nr];
          }
        }
        string str4 = index2 <= -1 ? "Immobile" : (this.game.Data.SFObj[index2].MoveType != -1 ? Strings.Trim(this.game.Data.TempString[this.game.Data.SFObj[index2].MoveType]) : Strings.Trim(this.game.Data.TempString[this.game.Data.SFTypeObj[this.game.Data.SFObj[index2].Type].MoveType]));
        if (index2 == -2)
          nr = this.game.SUPPLIESSYMBOL;
        else if (index2 > -1)
          nr = this.game.Data.SFTypeObj[this.game.Data.SFObj[index2].Type].SymbolSpriteID;
        int integer2 = Conversions.ToInteger(this.game.HandyFunctionsObj.GetUnitPeople(this.unr));
        if (regime > -1 & index2 > -1)
        {
          if (this.game.Data.RegimeObj[regime].ExtraGraphicUse > -1)
          {
            int extraCounter = this.game.Data.SFTypeObj[this.game.Data.SFObj[index2].Type].ExtraCounter;
            for (int index3 = 0; index3 <= extraCounter; ++index3)
            {
              if (this.game.Data.SFTypeObj[this.game.Data.SFObj[index2].Type].ExtraCode[index3] == this.game.Data.RegimeObj[regime].ExtraGraphicUse)
                nr = this.game.Data.SFTypeObj[this.game.Data.SFObj[index2].Type].ExtraSymbolSpriteID[index3];
            }
          }
          else if (this.game.Data.PeopleObj[integer2].ExtraGraphicUse > -1)
          {
            int extraCounter = this.game.Data.SFTypeObj[this.game.Data.SFObj[index2].Type].ExtraCounter;
            for (int index4 = 0; index4 <= extraCounter; ++index4)
            {
              if (this.game.Data.SFTypeObj[this.game.Data.SFObj[index2].Type].ExtraCode[index4] == this.game.Data.PeopleObj[integer2].ExtraGraphicUse)
                nr = this.game.Data.SFTypeObj[this.game.Data.SFObj[index2].Type].ExtraSymbolSpriteID[index4];
            }
          }
        }
        if (nr > -1 & index2 > -1)
        {
          ref Graphics local1 = ref toG;
          Bitmap bitmap = BitmapStore.GetBitmap(nr);
          ref Bitmap local2 = ref bitmap;
          DrawMod.DrawSimple(ref local1, ref local2, 188, 13);
          string str5 = this.game.Data.SFObj[index2].MoveType <= -1 ? this.game.Data.TempString[this.game.Data.SFTypeObj[this.game.Data.SFObj[index2].Type].MoveType] : this.game.Data.TempString[this.game.Data.SFObj[index2].MoveType];
          if (Strings.Len(str5) > 7)
            str5 = Strings.Left(str5, 7);
          sizeF2 = toG.MeasureString(str5, new Font(this.game.FontCol.Families[1], 10f, FontStyle.Regular, GraphicsUnit.Pixel));
          DrawMod.DrawText(ref toG, str5, new Font(this.game.FontCol.Families[1], 10f, FontStyle.Regular, GraphicsUnit.Pixel), (int) Math.Round(209.0 - (double) sizeF2.Width / 2.0), 1);
        }
        else if (nr > -1)
        {
          ref Graphics local3 = ref toG;
          Bitmap bitmap = BitmapStore.GetBitmap(nr);
          ref Bitmap local4 = ref bitmap;
          DrawMod.DrawSimple(ref local3, ref local4, 188, 13);
          if (Strings.Len(str4) > 7)
            str4 = Strings.Left(str4, 7);
          sizeF2 = toG.MeasureString(str4, new Font(this.game.FontCol.Families[1], 10f, FontStyle.Regular, GraphicsUnit.Pixel));
          DrawMod.DrawText(ref toG, str4, new Font(this.game.FontCol.Families[1], 10f, FontStyle.Regular, GraphicsUnit.Pixel), (int) Math.Round(209.0 - (double) sizeF2.Width / 2.0), 1);
        }
        string str6 = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetLowestAp(this.unr)));
        if (coordinate.x == 2)
          str6 = "?";
        sizeF2 = toG.MeasureString(str6, this.game.GameFont3);
        DrawMod.DrawText(ref toG, str6, this.game.GameFont3, (int) Math.Round(16.0 - (double) sizeF2.Width / 2.0), 84);
        string str7 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].SupplyConsume));
        if (coordinate.x == 2)
          str7 = "?";
        sizeF2 = toG.MeasureString(str7, this.game.GameFont3);
        DrawMod.DrawText(ref toG, str7, this.game.GameFont3, (int) Math.Round(57.0 - (double) sizeF2.Width / 2.0), 84);
        int Number1 = this.game.HandyFunctionsObj.GetAverageRdn(this.unr);
        if (coordinate.x == 2)
        {
          this.game.HandyFunctionsObj.RandomizeForUnit(this.unr, 0);
          float num8 = (float) coordinate.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
          float num9 = (float) ((1.0 - (double) num8) * 2.0);
          float num10 = VBMath.Rnd() * num9 + num8;
          Number1 = (int) Math.Round((double) Conversion.Int((float) Number1 * num10));
          if (Number1 < 0)
            Number1 = 0;
          if (Number1 > 100)
            Number1 = 100;
        }
        string str8 = Strings.Trim(Conversion.Str((object) Number1));
        sizeF2 = toG.MeasureString(str8, this.game.GameFont3);
        DrawMod.DrawText(ref toG, str8, this.game.GameFont3, (int) Math.Round(95.0 - (double) sizeF2.Width / 2.0), 84);
        int Number2 = this.game.HandyFunctionsObj.GetAverageXp(this.unr);
        if (coordinate.x == 2)
        {
          this.game.HandyFunctionsObj.RandomizeForUnit(this.unr, 0);
          float num11 = (float) coordinate.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
          float num12 = (float) ((1.0 - (double) num11) * 2.0);
          float num13 = VBMath.Rnd() * num12 + num11;
          Number2 = (int) Math.Round((double) Conversion.Int((float) Number2 * num13));
          if (Number2 < 0)
            Number2 = 0;
          if (Number2 > 100)
            Number2 = 100;
        }
        string str9 = Strings.Trim(Conversion.Str((object) Number2));
        sizeF2 = toG.MeasureString(str9, this.game.GameFont3);
        DrawMod.DrawText(ref toG, str9, this.game.GameFont3, (int) Math.Round(133.0 - (double) sizeF2.Width / 2.0), 84);
        int Number3 = this.game.HandyFunctionsObj.GetAverageMor(this.unr);
        if (coordinate.x == 2)
        {
          this.game.HandyFunctionsObj.RandomizeForUnit(this.unr, 0);
          float num14 = (float) coordinate.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
          float num15 = (float) ((1.0 - (double) num14) * 2.0);
          float num16 = VBMath.Rnd() * num15 + num14;
          Number3 = (int) Math.Round((double) Conversion.Int((float) Number3 * num16));
          if (Number3 < 0)
            Number3 = 0;
          if (Number3 > 999)
            Number3 = 999;
        }
        string str10 = Strings.Trim(Conversion.Str((object) Number3));
        sizeF2 = toG.MeasureString(str10, this.game.GameFont3);
        DrawMod.DrawText(ref toG, str10, this.game.GameFont3, (int) Math.Round(171.0 - (double) sizeF2.Width / 2.0), 84);
        int Number4 = this.game.HandyFunctionsObj.GetAverageEntrench(this.unr);
        if (coordinate.x == 2)
        {
          this.game.HandyFunctionsObj.RandomizeForUnit(this.unr, 0);
          float num17 = (float) coordinate.y / (this.game.Data.RuleVar[56] - this.game.Data.RuleVar[55]);
          float num18 = (float) ((1.0 - (double) num17) * 2.0);
          float num19 = VBMath.Rnd() * num18 + num17;
          Number4 = (int) Math.Round((double) Conversion.Int((float) Number4 * num19));
          if (Number4 < 0)
            Number4 = 0;
          if (Number4 > 999)
            Number4 = 999;
        }
        string str11 = Strings.Trim(Conversion.Str((object) Number4));
        sizeF2 = toG.MeasureString(str11, this.game.GameFont3);
        DrawMod.DrawText(ref toG, str11, this.game.GameFont3, (int) Math.Round(209.0 - (double) sizeF2.Width / 2.0), 84);
      }
      int num20 = 3;
      do
      {
        DrawMod.DrawBlockGradient(ref toG, 0, 50 + num20 * 20, 40, 20, this.game.GameCol5, this.game.GameCol6);
        DrawMod.DrawBlock(ref toG, 40, 50 + num20 * 20, 60, 20, (int) this.game.GameCol7.R, (int) this.game.GameCol7.G, (int) this.game.GameCol7.B, (int) byte.MaxValue);
        DrawMod.DrawRectangle(ref toG, 0, 50 + num20 * 20, 100, 20, (int) this.game.GameCol2.R, (int) this.game.GameCol2.G, (int) this.game.GameCol2.B, (int) byte.MaxValue);
        DrawMod.drawLine(ref toG, 40, 50 + num20 * 20, 40, 70 + num20 * 20, (int) this.game.GameCol2.R, (int) this.game.GameCol2.G, (int) this.game.GameCol2.B, (int) byte.MaxValue);
        DrawMod.DrawRectangle(ref toG, 1, 51 + num20 * 20, 38, 18, 0, 0, 0, (int) byte.MaxValue);
        ++num20;
      }
      while (num20 <= 6);
      int num21 = 3;
      do
      {
        DrawMod.DrawBlockGradient(ref toG, 124, 50 + num21 * 20, 40, 20, this.game.GameCol5, this.game.GameCol6);
        DrawMod.DrawBlock(ref toG, 164, 50 + num21 * 20, 60, 20, (int) this.game.GameCol7.R, (int) this.game.GameCol7.G, (int) this.game.GameCol7.B, (int) byte.MaxValue);
        DrawMod.DrawRectangle(ref toG, 124, 50 + num21 * 20, 100, 20, (int) this.game.GameCol2.R, (int) this.game.GameCol2.G, (int) this.game.GameCol2.B, (int) byte.MaxValue);
        DrawMod.drawLine(ref toG, 164, 50 + num21 * 20, 164, 70 + num21 * 20, (int) this.game.GameCol2.R, (int) this.game.GameCol2.G, (int) this.game.GameCol2.B, (int) byte.MaxValue);
        DrawMod.DrawRectangle(ref toG, 125, 51 + num21 * 20, 38, 18, 0, 0, 0, (int) byte.MaxValue);
        ++num21;
      }
      while (num21 <= 6);
      DrawMod.DrawText(ref toG, "Stk", this.game.GameFont2, 3, 115);
      if (this.game.Data.UnitObj[this.unr].IsHQ)
        DrawMod.DrawText(ref toG, "Lnd", this.game.GameFont2, 3, 135);
      else
        DrawMod.DrawText(ref toG, "Units", this.game.GameFont2, 3, 135);
      if (this.game.Data.UnitObj[this.unr].IsHQ)
        DrawMod.DrawText(ref toG, "Nvy", this.game.GameFont2, 3, 155);
      else
        DrawMod.DrawText(ref toG, "Owner", this.game.GameFont2, 3, 155);
      DrawMod.DrawText(ref toG, "Wgt", this.game.GameFont2, 3, 175);
      DrawMod.DrawText(ref toG, "Staf", this.game.GameFont2, 128, 115);
      DrawMod.DrawText(ref toG, "HqPw", this.game.GameFont2, 128, 135);
      DrawMod.DrawText(ref toG, "Car", this.game.GameFont2, 128, 155);
      string tstring1 = Strings.Trim(Conversion.Str(Operators.AddObject(this.game.HandyFunctionsObj.GetUnitNonSeaWeight(this.unr, true), this.game.HandyFunctionsObj.GetUnitExcessWeight(this.unr))));
      if (coordinate.x <= 2)
        tstring1 = "?";
      DrawMod.DrawText(ref toG, tstring1, this.game.gamefont1b, 41, 175);
      string tstring2 = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetUnitStackPts(this.unr)));
      if (coordinate.x <= 2)
        tstring2 = "?";
      DrawMod.DrawText(ref toG, tstring2, this.game.gamefont1b, 41, 115);
      string tstring3;
      if (this.game.HandyFunctionsObj.HasUnitNavySF(this.unr))
      {
        int unitCarryCap = this.game.HandyFunctionsObj.GetUnitCarryCap(this.unr, 1);
        int Number = this.game.HandyFunctionsObj.GetUnitCarryCap(this.unr, 1) - this.game.HandyFunctionsObj.GetUnitCarryCap(this.unr, 1, true);
        tstring3 = "N:" + Strings.Trim(Conversion.Str((object) unitCarryCap)) + "/" + Strings.Trim(Conversion.Str((object) Number));
      }
      else if (this.game.HandyFunctionsObj.HasUnitAirSF(this.unr))
        tstring3 = "A:" + Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetUnitCarryCap(this.unr, 2)));
      else if (this.game.HandyFunctionsObj.HasUnitlandSF(this.unr))
      {
        int unitCarryCap = this.game.HandyFunctionsObj.GetUnitCarryCap(this.unr, 0);
        int Number = this.game.HandyFunctionsObj.GetUnitCarryCap(this.unr, 0) - this.game.HandyFunctionsObj.GetUnitCarryCap(this.unr, 0, true);
        tstring3 = "L:" + Strings.Trim(Conversion.Str((object) unitCarryCap)) + "/" + Strings.Trim(Conversion.Str((object) Number));
      }
      else
        tstring3 = "N/A";
      if (coordinate.x <= 2)
        tstring3 = "?";
      DrawMod.DrawText(ref toG, tstring3, this.game.gamefont2b, 166, 155);
      if (!this.game.Data.UnitObj[this.unr].IsHQ)
      {
        DrawMod.DrawText(ref toG, "Acar", this.game.GameFont2, 128, 175);
        string tstring4;
        if (this.game.Data.UnitObj[this.unr].Regime == this.game.Data.Turn)
        {
          int airCarryCapPts = this.game.HandyFunctionsObj.GetAirCarryCapPts(this.unr);
          int integer3 = Conversions.ToInteger(Operators.SubtractObject(this.game.HandyFunctionsObj.GetUnitNonSeaWeight(this.unr, true), this.game.HandyFunctionsObj.GetUnitNonSeaWeight(this.unr, false)));
          tstring4 = Strings.Trim(Conversion.Str((object) airCarryCapPts)) + "/" + Strings.Trim(Conversion.Str((object) integer3));
          if (coordinate.x <= 2)
            tstring4 = "?";
        }
        else
          tstring4 = "?";
        DrawMod.DrawText(ref toG, tstring4, this.game.gamefont1b, 166, 175);
      }
      if ((this.game.Data.UnitObj[this.unr].Regime == this.game.Data.Turn | !this.game.Data.FOWOn) & this.game.Data.UnitObj[this.unr].IsHQ)
      {
        if ((double) this.game.Data.RuleVar[509] == 0.0)
        {
          DrawMod.DrawText(ref toG, "Rail", this.game.GameFont2, 128, 175);
          string tstring5 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].AirCap));
          if (coordinate.x <= 2)
            tstring5 = "?";
          DrawMod.DrawText(ref toG, tstring5, this.game.gamefont1b, 166, 175);
        }
        string tstring6 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].NavyCap));
        if (coordinate.x <= 2)
          tstring6 = "?";
        DrawMod.DrawText(ref toG, tstring6, this.game.gamefont1b, 44, 155);
        string tstring7 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].LandCap));
        if (coordinate.x <= 2)
          tstring7 = "?";
        DrawMod.DrawText(ref toG, tstring7, this.game.gamefont1b, 44, 135);
        string tstring8 = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetStaffPercent(this.unr))) + "%";
        if (coordinate.x <= 2)
          tstring8 = "?";
        DrawMod.DrawText(ref toG, tstring8, this.game.gamefont1b, 166, 115);
        string tstring9 = "100%";
        if (coordinate.x <= 2)
          tstring9 = "?";
        DrawMod.DrawText(ref toG, tstring9, this.game.gamefont1b, 166, 135);
      }
      else
      {
        string tstring10 = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.Gethqpow(this.unr))) + "%";
        if (coordinate.x <= 2)
          tstring10 = "?";
        DrawMod.DrawText(ref toG, tstring10, this.game.gamefont1b, 166, 135);
        if (!this.game.Data.UnitObj[this.unr].IsHQ)
        {
          string tstring11 = this.game.Data.UnitObj[this.unr].HQ <= -1 ? "N/A" : Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetStaffPercent(this.game.Data.UnitObj[this.unr].HQ))) + "%";
          if (coordinate.x <= 2)
            tstring11 = "?";
          DrawMod.DrawText(ref toG, tstring11, this.game.gamefont1b, 166, 115);
        }
        else
        {
          string tstring12 = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetStaffPoints(this.unr))) + "/" + Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetStaffNeeded(this.unr)));
          if (coordinate.x <= 2)
            tstring12 = "?";
          DrawMod.DrawText(ref toG, tstring12, this.game.gamefont2b, 166, 115);
        }
        if (this.game.Data.UnitObj[this.unr].Historical > -1)
        {
          string tstring13 = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.unr].Historical].StartSize));
          if (coordinate.x <= 2)
            tstring13 = "?";
          DrawMod.DrawText(ref toG, tstring13, this.game.gamefont2b, 44, 135);
        }
        else
          DrawMod.DrawText(ref toG, "N/A", this.game.gamefont2b, 44, 135);
        string tstring14 = Strings.Left(this.game.Data.RegimeObj[this.game.Data.UnitObj[this.unr].Regime].Name, 10);
        DrawMod.DrawText(ref toG, tstring14, this.game.gamefont2b, 44, 155);
      }
      if (((num7 == 0 ? 1 : 0) & 0) != 0)
      {
        DrawMod.DrawText(ref toG, "?", this.game.gamefont1b, 41, 115);
        DrawMod.DrawText(ref toG, "?", this.game.gamefont1b, 41, 135);
        DrawMod.DrawText(ref toG, "?", this.game.gamefont1b, 41, 155);
        DrawMod.DrawText(ref toG, "?", this.game.gamefont1b, 41, 175);
        DrawMod.DrawText(ref toG, "?", this.game.gamefont1b, 166, 115);
        DrawMod.DrawText(ref toG, "?", this.game.gamefont1b, 166, 135);
        DrawMod.DrawText(ref toG, "?", this.game.gamefont1b, 166, 155);
        DrawMod.DrawText(ref toG, "?", this.game.gamefont1b, 166, 175);
      }
      if (num7 == 0)
      {
        DrawMod.DrawText(ref toG, "?", this.game.GameFont3, 15, 83);
        DrawMod.DrawText(ref toG, "?", this.game.GameFont3, 53, 83);
        DrawMod.DrawText(ref toG, "?", this.game.GameFont3, 91, 83);
        DrawMod.DrawText(ref toG, "?", this.game.GameFont3, 129, 83);
        DrawMod.DrawText(ref toG, "?", this.game.GameFont3, 167, 83);
        DrawMod.DrawText(ref toG, "?", this.game.GameFont3, 205, 83);
      }
      return this.OwnBitmap;
    }

    public override Bitmap PaintOverlay()
    {
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      ref Graphics local1 = ref graphics;
      Bitmap bitmap = BitmapStore.GetBitmap(Conversions.ToInteger(this.OwnBitmapNr));
      ref Bitmap local2 = ref bitmap;
      DrawMod.Draw(ref local1, ref local2, 0, 0, 0.3f, 0.3f, 0.3f, 1f);
      return this.OwnBitmap;
    }
  }
}
