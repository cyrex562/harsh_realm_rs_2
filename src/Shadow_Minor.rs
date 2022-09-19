// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.Shadow_Minor
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingSystem;

namespace WindowsApplication1
{
  pub class Shadow_Minor
  {
    pub DC2AIClass ai;
    pub DataClass data;
    pub MapClass map;
    pub RegimeId: i32;
    pub slotRegRegKeys: i32;
    pub slotRegimes: i32;
    pub slotGameKeys: i32;

    pub Shadow_Minor( DC2AIClass tai)
    {
      this.slotRegRegKeys = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 275, 0, 0));
      this.slotRegimes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 143, 0, 0));
      this.slotGameKeys = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0));
      this.ai = tai;
      this.data = tai.game.Data;
      this.map = tai.game.Data.MapObj[0];
      this.RegimeId = tai.game.Data.RegimeObj[tai.game.Data.Turn].id;
    }

    pub void Run()
    {
      HelperEconomyData hed = new HelperEconomyData( this.ai.game, "SE_Data");
      if (this.ai.game.Data.Round == 1)
        this.ai.game.EventRelatedObj.ExecMakeProduction("SE_Data", -1, 1, 0, "");
      hed.reg = this.ai.game.Data.Turn;
      hed.regid = this.ai.game.Data.RegimeObj[hed.reg].id;
      hed.currentRegimeNr = hed.reg;
      hed.currentRegimeId = hed.regid;
      let mut num1: i32 =  Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[this.slotRegimes].GetData(0, this.RegimeId, 1)));
      let mut length1: i32 = this.ai.game.Data.StringListObj[hed.slotZones].Length;
      for (let mut index: i32 = 0; index <= length1; index += 1)
      {
        let mut num2: i32 =  Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[hed.slotZones].Data[index, 0]));
        if ( Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[hed.slotZones].Data[index, 8])) == this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].id)
        {
          hed.zoneId = num2;
          hed.Input();
          this.ai.game.EventRelatedObj.ZoneEconomy_EarlyPrivateEconomy( hed, "Se_Data");
          hed.Output();
        }
      }
      this.ai.game.EventRelatedObj.ExecMakeProduction("SE_Data", -1, 0, 0, "");
      hed.reg = this.ai.game.Data.Turn;
      hed.regid = this.ai.game.Data.RegimeObj[hed.reg].id;
      hed.currentRegimeNr = hed.reg;
      hed.currentRegimeId = hed.regid;
      let mut length2: i32 = this.ai.game.Data.StringListObj[hed.slotZones].Length;
      for (let mut index: i32 = 0; index <= length2; index += 1)
      {
        let mut num3: i32 =  Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[hed.slotZones].Data[index, 0]));
        if ( Math.Round(Conversion.Val(this.ai.game.Data.StringListObj[hed.slotZones].Data[index, 8])) == this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].id)
        {
          hed.zoneId = num3;
          hed.Input();
          this.ai.game.EventRelatedObj.ZoneEconomy_PrivateEconomy( hed, "SE_Data");
          this.ai.game.EventRelatedObj.ZoneEconomy_Militia_and_Minors( hed, "SE_Data");
          hed.Output();
        }
      }
      this.ai.game.EventRelatedObj.ExecMakeMaximization(false);
      if (num1 == 3)
        this.ai.game.EventRelatedObj.ZoneEconomy_NonZoneMilitiaSupply( this.RegimeId, "SE_Data");
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

    pub void GetDistanceChanges()
    {
      let mut num1: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotGameKeys].GetData(0, 42, 2)));
      SimpleList simpleList = SimpleList::new();
      let mut mapWidth1: i32 = this.map.MapWidth;
      for (let mut cx: i32 = 0; cx <= mapWidth1; cx += 1)
      {
        let mut mapHeight: i32 = this.map.MapHeight;
        for (let mut cy: i32 = 0; cy <= mapHeight; cy += 1)
        {
          if (this.map.HexObj[cx, cy].Regime == this.data.Turn)
          {
            let mut tfacing: i32 = 1;
            do
            {
              Coordinate coordinate = this.ai.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
              if (coordinate.onmap && this.map.HexObj[coordinate.x, coordinate.y].Regime != this.data.Turn && this.map.HexObj[coordinate.x, coordinate.y].Regime > -1)
                simpleList.Add(this.map.HexObj[coordinate.x, coordinate.y].Regime, 1);
              tfacing += 1;
            }
            while (tfacing <= 6);
          }
        }
      }
      let mut id: i32 = this.data.RegimeObj[this.data.Turn].id;
      let mut counter: i32 = simpleList.Counter;
      for (let mut index1: i32 = 0; index1 <= counter; index1 += 1)
      {
        let mut index2: i32 = simpleList.Id[index1];
        let mut num2: i32 = this.data.RegimeObj[index2].id;
        if ( Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, num2, 1))) == 1 & !this.data.RegimeObj[index2].AI)
        {
          if (this.data.RegimeObj[this.data.Turn].RegimeRel[index2] == 0)
          {
            simpleList.Weight[index1] = 1;
            AIMatrix aiMatrix = new AIMatrix( this.ai);
            let mut mapWidth2: i32 = this.map.MapWidth;
            for (let mut index3: i32 = 0; index3 <= mapWidth2; index3 += 1)
            {
              let mut mapHeight: i32 = this.map.MapHeight;
              for (let mut index4: i32 = 0; index4 <= mapHeight; index4 += 1)
              {
                if (this.map.HexObj[index3, index4].Regime == index2 && this.map.HexObj[index3, index4].UnitCounter > -1)
                  aiMatrix.Value[index3, index4] = 1;
              }
            }
            aiMatrix.ExpandAndAddValueForAnyRegime(999);
            let mut mapWidth3: i32 = this.map.MapWidth;
            for (let mut index5: i32 = 0; index5 <= mapWidth3; index5 += 1)
            {
              let mut mapHeight: i32 = this.map.MapHeight;
              for (let mut index6: i32 = 0; index6 <= mapHeight; index6 += 1)
              {
                if (aiMatrix.Value[index5, index6] > 0)
                {
                  int[,] numArray1 = aiMatrix.Value;
                  int[,] numArray2 = numArray1;
                  let mut index7: i32 = index5;
                  let mut index8: i32 = index7;
                  let mut index9: i32 = index6;
                  let mut index10: i32 = index9;
                  let mut num3: i32 = numArray1[index7, index9] - 1;
                  numArray2[index8, index10] = num3;
                }
              }
            }
            let mut num4: i32 = 0;
            let mut num5: i32 = 0;
            let mut num6: i32 = 0;
            let mut num7: i32 = 0;
            let mut locCounter: i32 = this.data.LocCounter;
            for (let mut index11: i32 = 0; index11 <= locCounter; index11 += 1)
            {
              let mut x: i32 = this.data.LocObj[index11].X;
              let mut y: i32 = this.data.LocObj[index11].Y;
              if (this.map.HexObj[x, y].Regime == this.data.Turn)
              {
                num4 += aiMatrix.Value[x, y];
                num5 += 1;
              }
            }
            let mut unitCounter: i32 = this.data.UnitCounter;
            for (let mut index12: i32 = 0; index12 <= unitCounter; index12 += 1)
            {
              let mut x: i32 = this.data.UnitObj[index12].X;
              let mut y: i32 = this.data.UnitObj[index12].Y;
              if (x > -1 & this.data.UnitObj[index12].PreDef == -1 && this.data.UnitObj[index12].Regime == this.data.Turn)
              {
                num6 += aiMatrix.Value[x, y];
                num7 += 1;
              }
            }
            let mut num8: i32 = num5 <= 0 ? 999 :  Math.Round( num4 /  num5);
            let mut num9: i32 = num7 <= 0 ? 999 :  Math.Round( num6 /  num7);
            let mut num10: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, id, 1, num2, 2, "distanceCity", 3)));
            let mut num11: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, id, 1, num2, 2, "distanceUnit", 3)));
            if (this.data.Round == 1)
            {
              num10 = num8;
              num11 = num9;
            }
            this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id, 1, num2, 2, "distanceCity", 3, num8, true);
            this.data.StringListObj[this.slotRegRegKeys].SetData3(0, num2, 1, id, 2, "distanceCity", 3, num8, true);
            this.data.StringListObj[this.slotRegRegKeys].SetData3(0, id, 1, num2, 2, "distanceUnit", 3, num9, true);
            this.data.StringListObj[this.slotRegRegKeys].SetData3(0, num2, 1, id, 2, "distanceUnit", 3, num9, true);
            let mut val1: i32 = num10 - num8;
            let mut val2: i32 = num11 - num9;
            if (num8 >= 999)
              val1 = val2;
            if (num9 >= 999)
              val2 = val1;
            let mut num12: i32 = 0;
            let mut num13: i32 = Math.Max(val1, val2);
            let mut num14: i32 = Math.Min(num8, num9);
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
                num12 += 1;
            }
            if (num14 <= 1)
              num12 += 5;
            else if (num14 <= 2)
              num12 += 2;
            if (num1 == 0)
              num12 =  Math.Round( num12 / 2.0);
            if (num12 != 0)
            {
              let mut setValue: i32 =  Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegRegKeys].GetData3(0, num2, 1, id, 2, "relation", 3))) + num12;
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
