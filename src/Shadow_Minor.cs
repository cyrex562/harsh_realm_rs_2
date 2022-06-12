// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.Shadow_Minor
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;

namespace WindowsApplication1
{
  public class Shadow_Minor
  {
    public DC2AIClass ai;
    public DataClass data;
    public MapClass map;
    public int RegimeId;
    public int slotRegRegKeys;
    public int slotRegimes;
    public int slotGameKeys;

    public Shadow_Minor(ref DC2AIClass tai)
    {
      this.slotRegRegKeys = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 275, 0, 0));
      this.slotRegimes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 143, 0, 0));
      this.slotGameKeys = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0));
      this.ai = tai;
      this.data = tai.game.Data;
      this.map = tai.game.Data.MapObj[0];
      this.RegimeId = tai.game.Data.RegimeObj[tai.game.Data.Turn].id;
    }

    public void Run()
    {
      HelperEconomyData hed = new HelperEconomyData(ref this.ai.game, "SE_Data");
      if (this.ai.game.Data.Round == 1)
        this.ai.game.EventRelatedObj.ExecMakeProduction("SE_Data", -1, 1, 0, "");
      hed.reg = this.ai.game.Data.Turn;
      hed.regid = this.ai.game.Data.RegimeObj[hed.reg].id;
      hed.currentRegimeNr = hed.reg;
      hed.currentRegimeId = hed.regid;
      int num1 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimes].GetData(0, this.RegimeId, 1)));
      int length1 = this.ai.game.Data.StringListObj[hed.slotZones].Length;
      for (int index = 0; index <= length1; ++index)
      {
        int num2 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[hed.slotZones].Data[index, 0]));
        if ((int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[hed.slotZones].Data[index, 8])) == this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].id)
        {
          hed.zoneId = num2;
          hed.Input();
          this.ai.game.EventRelatedObj.ZoneEconomy_EarlyPrivateEconomy(ref hed, "Se_Data");
          hed.Output();
        }
      }
      this.ai.game.EventRelatedObj.ExecMakeProduction("SE_Data", -1, 0, 0, "");
      hed.reg = this.ai.game.Data.Turn;
      hed.regid = this.ai.game.Data.RegimeObj[hed.reg].id;
      hed.currentRegimeNr = hed.reg;
      hed.currentRegimeId = hed.regid;
      int length2 = this.ai.game.Data.StringListObj[hed.slotZones].Length;
      for (int index = 0; index <= length2; ++index)
      {
        int num3 = (int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[hed.slotZones].Data[index, 0]));
        if ((int) Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[hed.slotZones].Data[index, 8])) == this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].id)
        {
          hed.zoneId = num3;
          hed.Input();
          this.ai.game.EventRelatedObj.ZoneEconomy_PrivateEconomy(ref hed, "SE_Data");
          this.ai.game.EventRelatedObj.ZoneEconomy_Militia_and_Minors(ref hed, "SE_Data");
          hed.Output();
        }
      }
      this.ai.game.EventRelatedObj.ExecMakeMaximization(false);
      if (num1 == 3)
        this.ai.game.EventRelatedObj.ZoneEconomy_NonZoneMilitiaSupply(ref this.RegimeId, "SE_Data");
      float num4 = this.data.RuleVar[941];
      this.data.RuleVar[941] = 1f;
      bool varDebugOn = this.ai.VAR_DEBUG_ON;
      if (this.ai.game.EventRelatedObj.Helper_IsDebug())
        this.ai.VAR_DEBUG_ON = true;
      this.ai.SetTempHexNeighbours();
      this.GetDistanceChanges();
      this.data.RuleVar[941] = num4;
      this.ai.VAR_DEBUG_ON = varDebugOn;
    }

    public void GetDistanceChanges()
    {
      int num1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 42, 2)));
      SimpleList simpleList = new SimpleList();
      int mapWidth1 = this.map.MapWidth;
      for (int cx = 0; cx <= mapWidth1; ++cx)
      {
        int mapHeight = this.map.MapHeight;
        for (int cy = 0; cy <= mapHeight; ++cy)
        {
          if (this.map.HexObj[cx, cy].Regime == this.data.Turn)
          {
            int tfacing = 1;
            do
            {
              Coordinate coordinate = this.ai.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
              if (coordinate.onmap && this.map.HexObj[coordinate.x, coordinate.y].Regime != this.data.Turn && this.map.HexObj[coordinate.x, coordinate.y].Regime > -1)
                simpleList.Add(this.map.HexObj[coordinate.x, coordinate.y].Regime, 1);
              ++tfacing;
            }
            while (tfacing <= 6);
          }
        }
      }
      int id = this.data.RegimeObj[this.data.Turn].id;
      int counter = simpleList.Counter;
      for (int index1 = 0; index1 <= counter; ++index1)
      {
        int index2 = simpleList.Id[index1];
        int num2 = this.data.RegimeObj[index2].id;
        if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, num2, 1))) == 1 & !this.data.RegimeObj[index2].AI)
        {
          if (this.data.RegimeObj[this.data.Turn].RegimeRel[index2] == 0)
          {
            simpleList.Weight[index1] = 1;
            AIMatrix aiMatrix = new AIMatrix(ref this.ai);
            int mapWidth2 = this.map.MapWidth;
            for (int index3 = 0; index3 <= mapWidth2; ++index3)
            {
              int mapHeight = this.map.MapHeight;
              for (int index4 = 0; index4 <= mapHeight; ++index4)
              {
                if (this.map.HexObj[index3, index4].Regime == index2 && this.map.HexObj[index3, index4].UnitCounter > -1)
                  aiMatrix.Value[index3, index4] = 1;
              }
            }
            aiMatrix.ExpandAndAddValueForAnyRegime(999);
            int mapWidth3 = this.map.MapWidth;
            for (int index5 = 0; index5 <= mapWidth3; ++index5)
            {
              int mapHeight = this.map.MapHeight;
              for (int index6 = 0; index6 <= mapHeight; ++index6)
              {
                if (aiMatrix.Value[index5, index6] > 0)
                {
                  int[,] numArray1 = aiMatrix.Value;
                  int[,] numArray2 = numArray1;
                  int index7 = index5;
                  int index8 = index7;
                  int index9 = index6;
                  int index10 = index9;
                  int num3 = numArray1[index7, index9] - 1;
                  numArray2[index8, index10] = num3;
                }
              }
            }
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int locCounter = this.data.LocCounter;
            for (int index11 = 0; index11 <= locCounter; ++index11)
            {
              int x = this.data.LocObj[index11].X;
              int y = this.data.LocObj[index11].Y;
              if (this.map.HexObj[x, y].Regime == this.data.Turn)
              {
                num4 += aiMatrix.Value[x, y];
                ++num5;
              }
            }
            int unitCounter = this.data.UnitCounter;
            for (int index12 = 0; index12 <= unitCounter; ++index12)
            {
              int x = this.data.UnitObj[index12].X;
              int y = this.data.UnitObj[index12].Y;
              if (x > -1 & this.data.UnitObj[index12].PreDef == -1 && this.data.UnitObj[index12].Regime == this.data.Turn)
              {
                num6 += aiMatrix.Value[x, y];
                ++num7;
              }
            }
            int num8 = num5 <= 0 ? 999 : (int) Math.Round((double) num4 / (double) num5);
            int num9 = num7 <= 0 ? 999 : (int) Math.Round((double) num6 / (double) num7);
            int num10 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, id, 1, num2, 2, "distanceCity", 3)));
            int num11 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, id, 1, num2, 2, "distanceUnit", 3)));
            if (this.data.Round == 1)
            {
              num10 = num8;
              num11 = num9;
            }
            this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id, 1, num2, 2, "distanceCity", 3, num8, true);
            this.data.StringListObj[this.slotRegRegKeys].SetData3(0, num2, 1, id, 2, "distanceCity", 3, num8, true);
            this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id, 1, num2, 2, "distanceUnit", 3, num9, true);
            this.data.StringListObj[this.slotRegRegKeys].SetData3(0, num2, 1, id, 2, "distanceUnit", 3, num9, true);
            int val1 = num10 - num8;
            int val2 = num11 - num9;
            if (num8 >= 999)
              val1 = val2;
            if (num9 >= 999)
              val2 = val1;
            int num12 = 0;
            int num13 = Math.Max(val1, val2);
            int num14 = Math.Min(num8, num9);
            if (id == 19)
              num2 = num2;
            if (num13 > 0)
            {
              if (num14 <= 1)
                num12 -= 15;
              else if (num14 <= 2)
                num12 -= 7;
              else if (num14 <= 3)
                num12 -= 4;
              else if (num14 <= 5)
                num12 -= 2;
              else if (num13 > 2)
                num12 -= 2;
              else if (num13 > 0)
                --num12;
            }
            else if (num13 < 0 & this.data.Round > 1)
            {
              if (num14 <= 2)
                num12 += 5;
              else if (num14 <= 3)
                num12 += 3;
              else if (num14 <= 4)
                num12 += 2;
              else if (num14 <= 5)
                ++num12;
            }
            if (num14 <= 1)
              num12 += 5;
            else if (num14 <= 2)
              num12 += 2;
            if (num1 == 0)
              num12 = (int) Math.Round((double) num12 / 2.0);
            if (num12 != 0)
            {
              int setValue = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, num2, 1, id, 2, "relation", 3))) + num12;
              if (setValue < 0)
                setValue = 0;
              if (setValue > 100)
                setValue = 100;
              this.data.StringListObj[this.slotRegRegKeys].SetData3(0, num2, 1, id, 2, "relation", 3, setValue, true);
            }
          }
          else
            simpleList.Weight[index1] = 0;
        }
        else
          simpleList.Weight[index1] = 0;
      }
    }
  }
}
