// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.CustomCombatCalls
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class CustomCombatCalls
  {
    pub SimpleList SL;
    pub SimpleList MODL;
    pub SimpleList logLeaderBonus;
    pub SimpleList logLeaderBonusDef;
    pub SimpleList otherBonus;
    pub SimpleList otherBonusDef;
    pub SimpleList SkillCacheList;
    pub slotModelsAdditive: i32;
    pub slotModelsClean: i32;
    pub slotModels: i32;
    pub slotGameKeys: i32;
    pub slotLeaders: i32;
    pub slotRegimes: i32;
    pub slotZones: i32;
    pub slotUnitFeats: i32;
    pub slotCharSkill: i32;
    pub slotChar: i32;
    pub slotAssets: i32;
    pub slotAssetTypes: i32;
    pub slotBehaviour: i32;
    pub slotSkill: i32;
    pub slotRegimeKey: i32;
    pub slotMM: i32;
    pub slotSkillTypes: i32;
    pub rememberRadPts: i32;
    pub airEnabled: bool;
    pub float SKILLEFFECT;
    pub EntrBunkerInit: bool;
    pub float EntrBunkerMod;
    pub float EntrAssetMod;

    pub CustomCombatCalls()
    {
      this.SKILLEFFECT = 0.5f;
      this.EntrBunkerMod = 1f;
      this.EntrAssetMod = 1f;
      if ((int) Math.Round(Conversion.Val(DrawMod.TGame.Data.Designer)) < 103)
        this.SKILLEFFECT = 1f;
      this.SL = SimpleList::new();
      this.MODL = SimpleList::new();
      this.logLeaderBonus = SimpleList::new();
      this.logLeaderBonusDef = SimpleList::new();
      this.otherBonus = SimpleList::new();
      this.otherBonusDef = SimpleList::new();
      this.SkillCacheList = SimpleList::new();
      this.slotModelsAdditive = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 363, 0, 0));
      this.slotModelsClean = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 229, 0, 0));
      this.slotModels = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 228, 0, 0));
      this.slotGameKeys = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0));
      this.slotLeaders = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 196, 0, 0));
      this.slotRegimes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 143, 0, 0));
      this.slotZones = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
      this.slotUnitFeats = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 402, 0, 0));
      this.slotCharSkill = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 199, 0, 0));
      this.slotChar = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 196, 0, 0));
      this.slotAssets = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 148, 0, 0));
      this.slotAssetTypes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 144, 0, 0));
      this.slotBehaviour = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 404, 0, 0));
      this.slotSkill = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 199, 0, 0));
      this.slotRegimeKey = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 210, 0, 0));
      this.slotMM = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 446, 0, 0));
      this.slotSkillTypes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 203, 0, 0));
      this.EntrBunkerInit = false;
      this.airEnabled = DrawMod.TGame.EventRelatedObj.Helper_AirEnabled();
    }

    pub HasCustumCalls: bool() => true;

    pub int IndividualMORMod(ref CombatClass cc, int inr, int morMod, int sfnr = -1)
    {
      int people;
      if (inr > -1)
      {
        people = DrawMod.TGame.Data.SFObj[cc.IList[inr].ISFNr].People;
      }
      else
      {
        if (sfnr <= -1)
          return morMod;
        people = DrawMod.TGame.Data.SFObj[sfnr].People;
      }
      if (DrawMod.TGame.Data.PeopleObj[people].tv0 == (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotGameKeys].GetData(0, 37, 2))))
        morMod = 0;
      return morMod;
    }

    pub int IndividualXPMod(ref CombatClass cc, int inr, int xpToBeGiven, int sfnr = -1)
    {
      int people;
      if (inr > -1)
      {
        people = DrawMod.TGame.Data.SFObj[cc.IList[inr].ISFNr].People;
      }
      else
      {
        if (sfnr <= -1)
          return xpToBeGiven;
        people = DrawMod.TGame.Data.SFObj[sfnr].People;
      }
      if (DrawMod.TGame.Data.PeopleObj[people].tv0 == (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotGameKeys].GetData(0, 37, 2))))
        xpToBeGiven = 0;
      return xpToBeGiven;
    }

    pub int CachedSkillRoll(GameClass game, int charId, int skillId)
    {
      int nr = this.SkillCacheList.FindNr(charId, skillId);
      int tdata2;
      if (nr < 0)
      {
        tdata2 = game.EventRelatedObj.CheckHardcoded_SkillRoll(charId, skillId, false, 0, false);
        this.SkillCacheList.Add(charId, 1, skillId, tdata2, CheckExistence: false);
      }
      else
        tdata2 = this.SkillCacheList.Data2[nr];
      return tdata2;
    }

    pub int EntrenchModifier(ref CombatClass cc, int indNr, int curX, int curY, int entr)
    {
      if (cc.IList[indNr].IAttacker == 0 & (int) Math.Round(Conversion.Val(cc.game.Data.Designer)) >= 112)
      {
        if (!this.EntrBunkerInit)
        {
          data: DataClass = cc.game.Data;
          str: String = "bunkerPoints";
          ref local: String = ref str;
          int libVar = data.FindLibVar(ref local, "SE_Data");
          int hexLibVarValue = cc.game.Data.MapObj[0].HexObj[cc.TargetX, cc.TargetY].GetHexLibVarValue(libVar);
          this.EntrAssetMod = 1f;
          int num1 = 0;
          int length = cc.game.Data.StringListObj[this.slotAssets].Length;
          for (int index = 0; index <= length; index += 1)
          {
            int num2 = (int) Math.Round(Conversion.Val(cc.game.Data.StringListObj[this.slotAssets].Data[index, 3]));
            int num3 = (int) Math.Round(Conversion.Val(cc.game.Data.StringListObj[this.slotAssets].Data[index, 4]));
            if (num2 == cc.TargetX & num3 == cc.TargetY)
            {
              int idValue = (int) Math.Round(Conversion.Val(cc.game.Data.StringListObj[this.slotAssets].Data[index, 1]));
              int num4 = (int) Math.Round(Conversion.Val(cc.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 2)));
              int num5 = (int) Math.Round(Conversion.Val(cc.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 13)));
              if (num5 < 1)
                num5 = 1;
              num1 += num4 * (5 + num5);
            }
          }
          if (num1 > 0)
            hexLibVarValue += num1;
          this.EntrBunkerInit = true;
          this.EntrBunkerMod = 1f;
          if (hexLibVarValue > 0)
          {
            int num6 = 0;
            int icounter = cc.ICounter;
            for (int index = 0; index <= icounter; index += 1)
            {
              if (cc.IList[index].IAttacker == 0)
                num6 += cc.game.Data.SFTypeObj[cc.IList[index].ISFType].PowerPts * 10;
            }
            int num7 = (int) Math.Round(Math.Sqrt((double) hexLibVarValue) * 10.0);
            if (num6 < num7)
              num6 = num7;
            while (num6 > 0 & hexLibVarValue > 0)
            {
              float num8 = (float) hexLibVarValue / (float) num6;
              if ((double) num8 > 1.0)
                num8 = 1f;
              hexLibVarValue -= num6;
              this.EntrBunkerMod += num8 * 0.25f;
            }
          }
        }
        entr = (int) Math.Round((double) ((float) entr * this.EntrBunkerMod));
      }
      return entr;
    }

    pub int AIHelpCombatChanger(ref CombatClass cc, int forNr, int againstNr, int tHelpCombat)
    {
      if (tHelpCombat > 0 && cc.game.Data.RegimeObj[DrawMod.TGame.Data.UnitObj[cc.IList[forNr].IUnr].Regime].AI && cc.game.Data.RegimeObj[DrawMod.TGame.Data.UnitObj[cc.IList[againstNr].IUnr].Regime].AI)
      {
        int id1 = cc.game.Data.RegimeObj[DrawMod.TGame.Data.UnitObj[cc.IList[forNr].IUnr].Regime].id;
        int id2 = cc.game.Data.RegimeObj[DrawMod.TGame.Data.UnitObj[cc.IList[forNr].IUnr].Regime].id;
        if ((int) Math.Round(Conversion.Val(cc.game.Data.StringListObj[this.slotRegimes].GetData(0, id1, 1))) > 1 & (int) Math.Round(Conversion.Val(cc.game.Data.StringListObj[this.slotRegimes].GetData(0, id2, 1))) == 1)
          tHelpCombat = 0;
      }
      return tHelpCombat;
    }

    pub void PersonalCombatRoll(
      ref CombatClass cc,
      GameClass game,
      int unr,
      int inr,
      int randomizedDiff,
      string wasKilledByString,
      bool unitLossCheck,
      bool hexLossCheck)
    {
      int index1 = -1;
      int num1 = -1;
      int num2 = -1;
      if (unr > -1)
      {
        index1 = game.Data.UnitObj[unr].Historical;
        num1 = game.Data.RegimeObj[game.Data.UnitObj[unr].Regime].id;
        num2 = game.Data.HistoricalUnitObj[index1].ID;
      }
      int idValue3_1 = -1;
      int idValue3_2 = -1;
      int index2 = -1;
      int index3 = -1;
      int index4 = -1;
      int index5 = -1;
      bool flag1 = false;
      bool flag2 = false;
      if (cc.CombatType2 == 16 | cc.CombatType == 13 | cc.CombatType == 5)
        hexLossCheck = false;
      if (index1 > -1)
      {
        if (game.Data.HistoricalUnitObj[index1].Type == 8)
        {
          flag2 = true;
          idValue3_2 = num2;
          index5 = unr;
          index2 = index1;
        }
        else if (game.Data.UnitObj[unr].IsHQ)
        {
          flag1 = true;
          idValue3_1 = num2;
          index4 = unr;
          index3 = index1;
        }
      }
      if (idValue3_1 > 0)
      {
        int hq = game.Data.UnitObj[index4].HQ;
        if (hq > -1)
        {
          index5 = hq;
          index2 = game.Data.UnitObj[index5].Historical;
          idValue3_2 = game.Data.HistoricalUnitObj[index2].ID;
        }
      }
      else if (idValue3_2 <= 0 && unr > -1 && game.Data.UnitObj[unr].HQ > -1)
      {
        index4 = game.Data.UnitObj[unr].HQ;
        index3 = game.Data.UnitObj[index4].Historical;
        idValue3_1 = game.Data.HistoricalUnitObj[index3].ID;
        if (index4 > -1)
        {
          index3 = game.Data.UnitObj[index4].Historical;
          if (game.Data.HistoricalUnitObj[index3].Type == 8)
          {
            index5 = index4;
            index2 = game.Data.UnitObj[index5].Historical;
            idValue3_2 = game.Data.HistoricalUnitObj[index2].ID;
            index4 = -1;
            idValue3_1 = -1;
            index3 = -1;
          }
          if (index4 > -1)
          {
            index5 = game.Data.UnitObj[index4].HQ;
            if (index5 > -1)
            {
              index2 = game.Data.UnitObj[index5].Historical;
              idValue3_2 = game.Data.HistoricalUnitObj[index2].ID;
            }
          }
        }
      }
      str1: String = "";
      string str2;
      int num3;
      if (idValue3_1 > 0)
      {
        int integer = Conversions.ToInteger(game.Data.StringListObj[this.slotLeaders].GetData3(5, num1, 6, 3, 7, idValue3_1, 0));
        if (integer > 0)
        {
          int num4 = 0;
          int unitCounter = game.Data.UnitCounter;
          for (int index6 = 0; index6 <= unitCounter; index6 += 1)
          {
            if (game.Data.UnitObj[index6].HQ == index4 & !flag1 | index6 == index4 & flag1)
            {
              int sfCount = game.Data.UnitObj[index6].SFCount;
              for (int index7 = 0; index7 <= sfCount; index7 += 1)
              {
                int sf = game.Data.UnitObj[index6].SFList[index7];
                num4 += game.Data.SFObj[sf].Qty;
              }
            }
          }
          data1: String = game.Data.StringListObj[this.slotLeaders].GetData(0, integer, 46);
          int row = game.Data.StringListObj[this.slotLeaders].FindRow(0, integer);
          string texty;
          if (DrawMod.RandyNumber.Next(0, num4 * 10) <= 10 & (flag1 | Conversions.ToDouble(data1) > (double) DrawMod.RandyNumber.Next(1, 100)) | unitLossCheck & flag1)
          {
            int num5 = game.EventRelatedObj.CheckHardcoded_SkillRoll(integer, 10, false, 0, true);
            this.SL.AddWeight(integer, 1, 10, CheckData1Existence: true);
            int num6 = DrawMod.RandyNumber.Next(0, randomizedDiff) + 70;
            if (num5 < num6)
            {
              data2: String = game.Data.StringListObj[this.slotLeaders].GetData(0, integer, 3);
              data3: String = game.Data.StringListObj[this.slotLeaders].GetData(0, integer, 4);
              characterJobTitle: String = game.EventRelatedObj.Helper_GetCharacterJobTitle(integer);
              if (inr > -1)
              {
                if (str1.Length > 0)
                  str1 += " ";
                str2 = characterJobTitle + " " + data2 + " " + data3 + " was killed in action during fighting in the front line.";
                str1 += str2;
                game.EventRelatedObj.AddLeaderTempLog(integer, str2);
              }
              else if (unitLossCheck)
              {
                if (str1.Length > 0)
                  str1 += " ";
                str2 = characterJobTitle + " " + data2 + " " + data3 + " was killed in action during the destruction of " + game.Data.UnitObj[unr].Name + ".";
                str1 += str2;
                game.EventRelatedObj.AddLeaderTempLog(integer, str2);
              }
              game.EventRelatedObj.Helper_AddMessageToUpcomingOrCurrentUDS(num1, "Leader KIA", str2, integer, DetailType.CharacterDeath);
              game.Data.HistoricalUnitObj[index3].SetHisVarValue(61, 0);
              game.EventRelatedObj.HelperResetAdvisorFor(integer, false, num1);
              game.Data.StringListObj[this.slotLeaders].Data[row, 5] = 0.ToString();
              game.Data.StringListObj[this.slotLeaders].Data[row, 6] = 0.ToString();
              game.Data.StringListObj[this.slotLeaders].Data[row, 7] = 0.ToString();
              game.Data.StringListObj[this.slotLeaders].Data[row, 25] = game.Data.Round.ToString();
              game.Data.StringListObj[this.slotLeaders].Data[row, 26] = num1.ToString();
              game.EventRelatedObj.Helper_RemoveAllTraceOfLeader(integer);
            }
            else if (unitLossCheck & flag1)
            {
              game.EventRelatedObj.Helper_AddMessageToUpcomingOrCurrentUDS(num1, "Leader Survived Unit Destruction", texty, integer, DetailType.CharacterNews);
              game.Data.HistoricalUnitObj[index3].SetHisVarValue(61, 0);
              string[,] data4 = game.Data.StringListObj[this.slotLeaders].Data;
              int index8 = row;
              num3 = 1;
              str3: String = num3.ToString();
              data4[index8, 6] = str3;
              string[,] data5 = game.Data.StringListObj[this.slotLeaders].Data;
              int index9 = row;
              num3 = 0;
              str4: String = num3.ToString();
              data5[index9, 7] = str4;
            }
          }
          else if (unitLossCheck & flag1)
          {
            game.EventRelatedObj.Helper_AddMessageToUpcomingOrCurrentUDS(num1, "Leader Survived Unit Destruction", texty, integer, DetailType.CharacterNews);
            game.Data.HistoricalUnitObj[index3].SetHisVarValue(61, 0);
            string[,] data6 = game.Data.StringListObj[this.slotLeaders].Data;
            int index10 = row;
            num3 = 1;
            str5: String = num3.ToString();
            data6[index10, 6] = str5;
            string[,] data7 = game.Data.StringListObj[this.slotLeaders].Data;
            int index11 = row;
            num3 = 0;
            str6: String = num3.ToString();
            data7[index11, 7] = str6;
          }
        }
      }
      if (idValue3_2 > 0)
      {
        if (num1 == 4)
        {
          int num7 = num7;
        }
        int integer = Conversions.ToInteger(game.Data.StringListObj[this.slotLeaders].GetData3(5, num1, 6, 4, 7, idValue3_2, 0));
        if (integer > 0)
        {
          int num8 = 0;
          int unitCounter = game.Data.UnitCounter;
          for (int index12 = 0; index12 <= unitCounter; index12 += 1)
          {
            if (game.Data.UnitObj[index12].HQ == index5 & !flag2 | index12 == index5 & flag2)
            {
              int sfCount = game.Data.UnitObj[index12].SFCount;
              for (int index13 = 0; index13 <= sfCount; index13 += 1)
              {
                int sf = game.Data.UnitObj[index12].SFList[index13];
                num8 += game.Data.SFObj[sf].Qty;
              }
            }
            else if (game.Data.UnitObj[index12].HQ > -1 && game.Data.UnitObj[game.Data.UnitObj[index12].HQ].HQ > -1)
            {
              int hq = game.Data.UnitObj[game.Data.UnitObj[index12].HQ].HQ;
              int sfCount = game.Data.UnitObj[hq].SFCount;
              for (int index14 = 0; index14 <= sfCount; index14 += 1)
              {
                int sf = game.Data.UnitObj[hq].SFList[index14];
                num8 += game.Data.SFObj[sf].Qty;
              }
            }
          }
          data8: String = game.Data.StringListObj[this.slotLeaders].GetData(0, integer, 46);
          int row = game.Data.StringListObj[this.slotLeaders].FindRow(0, integer);
          if (DrawMod.RandyNumber.Next(0, num8 * 10) <= 5 & (flag2 | Conversions.ToDouble(data8) > (double) DrawMod.RandyNumber.Next(1, 100)) | unitLossCheck & flag2)
          {
            int num9 = game.EventRelatedObj.CheckHardcoded_SkillRoll(integer, 10, false, 0, true);
            this.SL.AddWeight(integer, 1, 10, CheckData1Existence: true);
            int num10 = DrawMod.RandyNumber.Next(0, randomizedDiff) + 70;
            if (num9 < num10)
            {
              data9: String = game.Data.StringListObj[this.slotLeaders].GetData(0, integer, 3);
              data10: String = game.Data.StringListObj[this.slotLeaders].GetData(0, integer, 4);
              characterJobTitle: String = game.EventRelatedObj.Helper_GetCharacterJobTitle(integer);
              if (inr > -1)
              {
                if (str1.Length > 0)
                  str1 += " ";
                str2 = characterJobTitle + " " + data9 + " " + data10 + " was killed in action during fighting in the front line.";
                str1 += str2;
                game.EventRelatedObj.AddLeaderTempLog(integer, str2);
              }
              else if (unitLossCheck)
              {
                if (str1.Length > 0)
                  str1 += " ";
                str2 = characterJobTitle + " " + data9 + " " + data10 + " was killed in action during the destruction of " + game.Data.UnitObj[unr].Name + ".";
                str1 += str2;
                game.EventRelatedObj.AddLeaderTempLog(integer, str2);
              }
              game.EventRelatedObj.Helper_AddMessageToUpcomingOrCurrentUDS(num1, "Leader KIA", str2, integer, DetailType.CharacterDeath);
              game.Data.HistoricalUnitObj[index2].SetHisVarValue(61, 0);
              game.EventRelatedObj.HelperResetAdvisorFor(integer, false, num1);
              string[,] data11 = game.Data.StringListObj[this.slotLeaders].Data;
              int index15 = row;
              num3 = 0;
              str7: String = num3.ToString();
              data11[index15, 5] = str7;
              string[,] data12 = game.Data.StringListObj[this.slotLeaders].Data;
              int index16 = row;
              num3 = 0;
              str8: String = num3.ToString();
              data12[index16, 6] = str8;
              string[,] data13 = game.Data.StringListObj[this.slotLeaders].Data;
              int index17 = row;
              num3 = 0;
              str9: String = num3.ToString();
              data13[index17, 7] = str9;
              game.Data.StringListObj[this.slotLeaders].Data[row, 25] = game.Data.Round.ToString();
              game.Data.StringListObj[this.slotLeaders].Data[row, 26] = num1.ToString();
              game.EventRelatedObj.Helper_RemoveAllTraceOfLeader(integer);
            }
            else if (unitLossCheck & flag2)
            {
              game.EventRelatedObj.Helper_AddMessageToUpcomingOrCurrentUDS(num1, "Leader Survived Unit Destruction", str2, integer, DetailType.CharacterNews);
              game.Data.HistoricalUnitObj[index2].SetHisVarValue(61, 0);
              string[,] data14 = game.Data.StringListObj[this.slotLeaders].Data;
              int index18 = row;
              num3 = 1;
              str10: String = num3.ToString();
              data14[index18, 6] = str10;
              string[,] data15 = game.Data.StringListObj[this.slotLeaders].Data;
              int index19 = row;
              num3 = 0;
              str11: String = num3.ToString();
              data15[index19, 7] = str11;
            }
          }
          else if (unitLossCheck & flag2)
          {
            game.EventRelatedObj.Helper_AddMessageToUpcomingOrCurrentUDS(num1, "Leader Survived Unit Destruction", str2, integer, DetailType.CharacterNews);
            game.Data.HistoricalUnitObj[index2].SetHisVarValue(61, 0);
            string[,] data16 = game.Data.StringListObj[this.slotLeaders].Data;
            int index20 = row;
            num3 = 1;
            str12: String = num3.ToString();
            data16[index20, 6] = str12;
            string[,] data17 = game.Data.StringListObj[this.slotLeaders].Data;
            int index21 = row;
            num3 = 0;
            str13: String = num3.ToString();
            data17[index21, 7] = str13;
          }
        }
      }
      if (hexLossCheck)
      {
        int defenderRegime = cc.DefenderRegime;
        num1 = game.Data.RegimeObj[defenderRegime].id;
        int location = game.Data.MapObj[0].HexObj[cc.TargetX, cc.TargetY].Location;
        if (location > -1)
        {
          int id1 = game.Data.LocObj[location].ID;
          int id2 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotRegimes].GetData(0, num1, 12)));
          int locationById = game.HandyFunctionsObj.GetLocationByID(id2);
          int integer1 = Conversions.ToInteger(game.Data.StringListObj[this.slotZones].GetData(6, id1, 0));
          int integer2 = Conversions.ToInteger(game.Data.StringListObj[this.slotLeaders].GetData3(5, num1, 6, 10, 7, integer1, 0));
          if (integer2 > 0)
          {
            int row = game.Data.StringListObj[this.slotLeaders].FindRow(0, integer2);
            int num11 = game.EventRelatedObj.CheckHardcoded_SkillRoll(integer2, 10, false, 0, true);
            this.SL.AddWeight(integer2, 1, 10, CheckData1Existence: true);
            int num12 = DrawMod.RandyNumber.Next(0, randomizedDiff) + 70;
            if (num11 < num12)
            {
              data18: String = game.Data.StringListObj[this.slotLeaders].GetData(0, integer2, 3);
              data19: String = game.Data.StringListObj[this.slotLeaders].GetData(0, integer2, 4);
              characterJobTitle: String = game.EventRelatedObj.Helper_GetCharacterJobTitle(integer2);
              if (str1.Length > 0)
                str1 += " ";
              str14: String = characterJobTitle + " " + data18 + " " + data19 + " was killed in action during the loss of " + game.Data.LocObj[location].Name + ".";
              str1 += str14;
              game.EventRelatedObj.Helper_AddMessageToUpcomingOrCurrentUDS(num1, "Leader KIA", str14, integer2, DetailType.CharacterDeath);
              game.EventRelatedObj.AddLeaderTempLog(integer2, str14);
              game.EventRelatedObj.HelperResetAdvisorFor(integer2, true, num1);
              string[,] data20 = game.Data.StringListObj[this.slotLeaders].Data;
              int index22 = row;
              num3 = 0;
              str15: String = num3.ToString();
              data20[index22, 5] = str15;
              string[,] data21 = game.Data.StringListObj[this.slotLeaders].Data;
              int index23 = row;
              num3 = 0;
              str16: String = num3.ToString();
              data21[index23, 6] = str16;
              string[,] data22 = game.Data.StringListObj[this.slotLeaders].Data;
              int index24 = row;
              num3 = 0;
              str17: String = num3.ToString();
              data22[index24, 7] = str17;
              game.Data.StringListObj[this.slotLeaders].Data[row, 25] = game.Data.Round.ToString();
              game.Data.StringListObj[this.slotLeaders].Data[row, 26] = num1.ToString();
              game.EventRelatedObj.Helper_RemoveAllTraceOfLeader(integer2);
            }
          }
          if (locationById == location)
          {
            int length = game.Data.StringListObj[this.slotLeaders].Length;
            for (int index25 = 0; index25 <= length; index25 += 1)
            {
              if ((int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotLeaders].Data[index25, 5])) == num1)
              {
                int num13 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotLeaders].Data[index25, 6]));
                if (num13 == 5 | num13 == 6)
                {
                  int num14 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotLeaders].Data[index25, 0]));
                  int row = game.Data.StringListObj[this.slotLeaders].FindRow(0, num14);
                  int num15 = game.EventRelatedObj.CheckHardcoded_SkillRoll(num14, 10, false, 0, true);
                  this.SL.AddWeight(num14, 1, 10, CheckData1Existence: true);
                  int num16 = DrawMod.RandyNumber.Next(0, randomizedDiff) + 70;
                  if (num15 < num16)
                  {
                    data23: String = game.Data.StringListObj[this.slotLeaders].GetData(0, num14, 3);
                    data24: String = game.Data.StringListObj[this.slotLeaders].GetData(0, num14, 4);
                    characterJobTitle: String = game.EventRelatedObj.Helper_GetCharacterJobTitle(num14);
                    if (str1.Length > 0)
                      str1 += " ";
                    str18: String = characterJobTitle + " " + data23 + " " + data24 + " was killed in action during the loss of the capital city (" + game.Data.LocObj[location].Name + ").";
                    str1 += str18;
                    game.EventRelatedObj.AddLeaderTempLog(num14, str18);
                    game.EventRelatedObj.Helper_AddMessageToUpcomingOrCurrentUDS(num1, "Leader KIA", str18, num14, DetailType.CharacterDeath);
                    game.EventRelatedObj.HelperResetAdvisorFor(num14, true, num1);
                    string[,] data25 = game.Data.StringListObj[this.slotLeaders].Data;
                    int index26 = row;
                    num3 = 0;
                    str19: String = num3.ToString();
                    data25[index26, 5] = str19;
                    string[,] data26 = game.Data.StringListObj[this.slotLeaders].Data;
                    int index27 = row;
                    num3 = 0;
                    str20: String = num3.ToString();
                    data26[index27, 6] = str20;
                    string[,] data27 = game.Data.StringListObj[this.slotLeaders].Data;
                    int index28 = row;
                    num3 = 0;
                    str21: String = num3.ToString();
                    data27[index28, 7] = str21;
                    game.Data.StringListObj[this.slotLeaders].Data[row, 25] = game.Data.Round.ToString();
                    game.Data.StringListObj[this.slotLeaders].Data[row, 26] = num1.ToString();
                    game.EventRelatedObj.Helper_RemoveAllTraceOfLeader(num14);
                  }
                }
              }
            }
          }
        }
      }
      if (str1.Length <= 0)
        return;
      if (Operators.CompareString(game.EditObj.CombatOneSentenceCustom, "", false) != 0)
        str1 += " ";
      game.EditObj.CombatOneSentenceCustom += str1;
      cc.AddBiggy(str1);
      if (hexLossCheck)
      {
        data: DataClass = game.Data;
        str22: String = "Zones";
        ref local: String = ref str22;
        int libVar = data.FindLibVar(ref local, "SE_Data");
        int hexLibVarValue = game.Data.MapObj[0].HexObj[cc.TargetX, cc.TargetY].GetHexLibVarValue(libVar);
        texty: String = game.EventRelatedObj.CheckHexName(cc.TargetX, cc.TargetY, 0, 0) + " was conquered by " + game.Data.RegimeObj[cc.AttackerRegime].Name + ". " + str1;
        int instanceId = hexLibVarValue;
        DrawMod.TGame.EventRelatedObj.Helper_AddDetailedReport(DetailType.Combat, instanceId, texty, game.Data.RegimeObj[cc.DefenderRegime].id);
      }
      else
      {
        if (unr <= -1)
          return;
        if (game.Data.UnitObj[unr].Regime == cc.DefenderRegime)
        {
          data: DataClass = game.Data;
          str23: String = "Zones";
          ref local: String = ref str23;
          int libVar = data.FindLibVar(ref local, "SE_Data");
          int hexLibVarValue = game.Data.MapObj[0].HexObj[cc.TargetX, cc.TargetY].GetHexLibVarValue(libVar);
          DrawMod.TGame.EventRelatedObj.Helper_AddDetailedReport(DetailType.Combat, hexLibVarValue, str1, game.Data.RegimeObj[cc.DefenderRegime].id);
        }
        else
        {
          if (game.Data.UnitObj[unr].Regime != cc.AttackerRegime)
            return;
          data: DataClass = game.Data;
          str24: String = "Zones";
          ref local: String = ref str24;
          int libVar = data.FindLibVar(ref local, "SE_Data");
          int hexLibVarValue = game.Data.MapObj[0].HexObj[cc.TargetX, cc.TargetY].GetHexLibVarValue(libVar);
          texty: String = "Attackers from " + game.Data.RegimeObj[cc.AttackerRegime].Name + " lost a Leader: " + str1;
          DrawMod.TGame.EventRelatedObj.Helper_AddDetailedReport(DetailType.Combat, hexLibVarValue, texty, game.Data.RegimeObj[cc.DefenderRegime].id);
        }
      }
    }

    pub void PreCombatCall(ref CombatClass cc, GameClass game)
    {
      int ucounter1 = cc.UCounter;
      for (int index = 0; index <= ucounter1; index += 1)
      {
        int unr = cc.UList[index].UNr;
        if (cc.UList[index].Uattacker == 0)
        {
          int historical = game.Data.UnitObj[unr].Historical;
          if (game.Data.HistoricalUnitObj[historical].Type >= 8)
          {
            cc.UList[index].UCanRetreat.x = -1;
            cc.UList[index].UCanRetreat.y = -1;
            cc.UList[index].UCanRetreat.onmap = false;
          }
        }
      }
      if (this.slotUnitFeats <= -1)
        return;
      int highestValue = game.Data.StringListObj[this.slotUnitFeats].GetHighestValue(0);
      int ucounter2 = cc.UCounter;
      for (int index1 = 0; index1 <= ucounter2; index1 += 1)
      {
        int unr = cc.UList[index1].UNr;
        int historical = game.Data.UnitObj[unr].Historical;
        SimpleList simpleList1 = SimpleList::new();
        int num1 = 100 + highestValue;
        int num2;
        for (int typ = 101; typ <= num1; typ += 1)
        {
          int tweight = game.Data.HistoricalUnitObj[historical].GiveHisVarValue(typ);
          if (tweight > 0)
          {
            int tdata1 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotUnitFeats].GetData(0, typ - 100, 11)));
            int tdata2 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotUnitFeats].GetData(0, typ - 100, 13)));
            simpleList1.Add(typ - 100, tweight, tdata1, tdata2);
            if (tweight > num2)
              num2 = tweight;
          }
        }
        if (simpleList1.Counter > -1)
        {
          int[,,] numArray = new int[simpleList1.Counter + 1, num2 + 1, 100];
          SimpleList simpleList2 = SimpleList::new();
          int counter1 = simpleList1.Counter;
          for (int index2 = 0; index2 <= counter1; index2 += 1)
          {
            int icounter = cc.ICounter;
            for (int tid = 0; tid <= icounter; tid += 1)
            {
              if (Information.IsNothing((object) cc.IList[tid].IunitFeat))
                cc.IList[tid].IunitFeat = SimpleList::new();
              if (cc.IList[tid].IUnr == unr && simpleList1.Data1[index2] == -1 | simpleList1.Data1[index2] == game.Data.SFTypeObj[cc.IList[tid].ISFType].UnitGroup)
              {
                int num3 = game.Data.SFTypeObj[cc.IList[tid].ISFType].AttackPower[game.Data.SFTypeObj[cc.IList[tid].ISFType].UnitGroup];
                if (game.Data.SFTypeObj[cc.IList[tid].ISFType].ArtRange < 1 & game.Data.SFTypeObj[cc.IList[tid].ISFType].BackBench)
                  num3 = (int) Math.Round((double) num3 / 10.0);
                int num4 = 0;
                int counter2 = cc.IList[tid].IunitFeat.Counter;
                for (int index3 = 0; index3 <= counter2; index3 += 1)
                {
                  if (cc.IList[tid].IunitFeat.Data1[index3] == tid)
                    num4 = 1;
                }
                if (num4 == 0)
                  simpleList2.Add(tid, 10 * num3);
              }
            }
            int index4 = simpleList1.Weight[index2];
            int num5 = index4;
            for (int index5 = 1; index5 <= num5; index5 += 1)
            {
              int randomIdbasedOnWeight = simpleList2.GetRandomIdbasedOnWeight();
              if (randomIdbasedOnWeight > -1)
              {
                if (Information.IsNothing((object) cc.IList[randomIdbasedOnWeight].IunitFeat))
                  cc.IList[randomIdbasedOnWeight].IunitFeat = SimpleList::new();
                cc.IList[randomIdbasedOnWeight].IunitFeat.Add(simpleList1.Id[index2], 1, cc.IList[randomIdbasedOnWeight].IID);
                cc.IList[randomIdbasedOnWeight].IunitFeatStart = simpleList1.Id[index2];
                numArray[index2, index4, 1] = randomIdbasedOnWeight;
                simpleList2.Remove(randomIdbasedOnWeight);
              }
            }
          }
          SimpleList simpleList3 = SimpleList::new();
          int counter3 = simpleList1.Counter;
          for (int index6 = 0; index6 <= counter3; index6 += 1)
          {
            int icounter = cc.ICounter;
            for (int tid = 0; tid <= icounter; tid += 1)
            {
              if (Information.IsNothing((object) cc.IList[tid].IunitFeat))
                cc.IList[tid].IunitFeat = SimpleList::new();
              if (cc.IList[tid].IUnr == unr && simpleList1.Data1[index6] == -1 | simpleList1.Data1[index6] == game.Data.SFTypeObj[cc.IList[tid].ISFType].UnitGroup && cc.IList[tid].IunitFeat.FindNr(simpleList1.Id[index6]) == -1)
              {
                int num6 = game.Data.SFTypeObj[cc.IList[tid].ISFType].AttackPower[game.Data.SFTypeObj[cc.IList[tid].ISFType].UnitGroup];
                if (game.Data.SFTypeObj[cc.IList[tid].ISFType].ArtRange < 1 & game.Data.SFTypeObj[cc.IList[tid].ISFType].BackBench)
                  num6 = (int) Math.Round((double) num6 / 10.0);
                simpleList3.Add(tid, 10 * num6);
              }
            }
            int index7 = simpleList1.Weight[index6];
            int num7 = index7;
            for (int index8 = 1; index8 <= num7; index8 += 1)
            {
              if (simpleList1.Data2[index6] >= 2)
              {
                int num8 = simpleList1.Data2[index6];
                for (int index9 = 2; index9 <= num8; index9 += 1)
                {
                  int randomIdbasedOnWeight = simpleList3.GetRandomIdbasedOnWeight();
                  if (randomIdbasedOnWeight > -1)
                  {
                    int index10 = numArray[index6, index7, 1];
                    if (Information.IsNothing((object) cc.IList[randomIdbasedOnWeight].IunitFeat))
                      cc.IList[randomIdbasedOnWeight].IunitFeat = SimpleList::new();
                    cc.IList[randomIdbasedOnWeight].IunitFeat.Add(simpleList1.Id[index6], 1, cc.IList[index10].IID);
                    simpleList3.Remove(randomIdbasedOnWeight);
                  }
                }
              }
            }
          }
        }
      }
    }

    pub void DoStructuralDamageCall(ref CombatClass cc, GameClass game, int damPts)
    {
      int num1 = (int) Math.Round((double) cc.CombatRound / 3.0) + 1;
      s: String = "";
      data1: DataClass = game.Data;
      str1: String = "Zones";
      ref local1: String = ref str1;
      int libVar1 = data1.FindLibVar(ref local1, "SE_Data");
      int hexLibVarValue1 = game.Data.MapObj[0].HexObj[cc.TargetX, cc.TargetY].GetHexLibVarValue(libVar1);
      if (damPts < 1)
        return;
      data2: DataClass = DrawMod.TGame.Data;
      str2: String = "bunkerPoints";
      ref local2: String = ref str2;
      int libVar2 = data2.FindLibVar(ref local2, "SE_Data");
      int hexLibVarValue2 = game.Data.MapObj[0].HexObj[cc.TargetX, cc.TargetY].GetHexLibVarValue(libVar2);
      float num2 = 0.0f;
      int val2 = damPts;
      if (hexLibVarValue2 > 0 & libVar2 > -1)
      {
        int val1 = hexLibVarValue2;
        while (val1 > 0 & damPts > 0)
        {
          float num3 = (float) Math.Min(val1, val2) / (float) val2;
          if ((double) num3 > 1.0)
            num3 = 1f;
          int num4 = (int) Math.Round(Math.Ceiling((double) damPts * 0.5 * (double) num3));
          num2 += num3;
          val1 -= val2;
          if (0 > val1)
            val1 = 0;
          damPts -= num4 + 1;
          if (0 > damPts)
            damPts = 0;
        }
        s = s + hexLibVarValue2.ToString() + " Bunker Points halved the structural damage " + Math.Round((double) num2, 1).ToString() + "x times letting: " + damPts.ToString() + " structural damage through.";
      }
      if (damPts > 0)
      {
        if (cc.CombatType == 5)
        {
          data3: DataClass = game.Data;
          str3: String = "aiStrucDam";
          ref local3: String = ref str3;
          int libVar3 = data3.FindLibVar(ref local3, "SE_Data");
          if (libVar3 > -1)
          {
            int tValue = game.Data.MapObj[0].HexObj[cc.TargetX, cc.TargetY].GetHexLibVarValue(libVar3) + damPts;
            game.Data.MapObj[0].HexObj[cc.TargetX, cc.TargetY].SetHexLibVarValue(libVar3, tValue);
          }
        }
        SimpleList simpleList = SimpleList::new();
        int length = game.Data.StringListObj[this.slotAssets].Length;
        int num5;
        for (int index = 0; index <= length; index += 1)
        {
          int num6 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssets].Data[index, 3]));
          int num7 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssets].Data[index, 4]));
          if (num6 == cc.TargetX & num7 == cc.TargetY)
          {
            int num8 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssets].Data[index, 2]));
            int tdata2 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssets].Data[index, 6]));
            num5 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssets].Data[index, 2]));
            int num9 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssets].Data[index, 9]));
            int idValue = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssets].Data[index, 1]));
            int tdata3 = game.Data.StringListObj[this.slotAssetTypes].Width < 29 ? 0 : (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 29)));
            simpleList.Add(num9, num8 * 10 + 10, num9, tdata2, tdata3);
          }
        }
        if (simpleList.Counter > -1)
        {
          int num10 = (int) Math.Round((double) damPts / (double) Math.Max(1, simpleList.Counter)) + (int) Math.Round((double) damPts / 3.0);
          if (num10 < 1)
            num10 = 1;
          int num11 = 0;
          int counter1 = simpleList.Counter;
          for (int index = 0; index <= counter1; index += 1)
          {
            int num12 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssets].GetData(9, simpleList.Data1[index], 6)));
            int num13 = num10;
            if (num13 > 100)
              num13 = 100 + (int) Math.Round((double) (num13 - 100) / 2.0);
            if (num13 > 200)
              num13 = 200 + (int) Math.Round((double) (num13 - 200) / 3.0);
            if (num13 > 300)
              num13 = 300 + (int) Math.Round((double) (num13 - 300) / 4.0);
            if (num13 > 400)
              num13 = 400 + (int) Math.Round((double) (num13 - 400) / 5.0);
            if (num13 > 500)
              num13 = 500 + (int) Math.Round((double) (num13 - 500) / 6.0);
            if (num13 > 600)
              num13 = 600 + (int) Math.Round((double) (num13 - 600) / 7.0);
            if (num13 > 700)
              num13 = 700;
            if (simpleList.Data3[index] > 0)
            {
              num13 = (int) Math.Round((double) num13 - (double) (num13 * simpleList.Data3[index]) / 100.0);
              if (num13 < 0)
                num13 = 0;
            }
            int setValue = num12 + num13;
            num11 += num13;
            game.Data.StringListObj[this.slotAssets].SetData(9, simpleList.Data1[index], 6, setValue);
          }
          s = s + "Attack did " + num11.ToString() + " of damage to the Assets in the hex. ";
          int counter2 = simpleList.Counter;
          for (int index = 0; index <= counter2; index += 1)
          {
            int row1 = game.Data.StringListObj[this.slotAssets].FindRow(9, simpleList.Data1[index]);
            if (row1 > -1)
            {
              int idValue1 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssets].Data[row1, 1]));
              int nr = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue1, 2)));
              int num14 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssets].Data[row1, 6]));
              int idValue2 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssets].Data[row1, 3]));
              int idValue2_1 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssets].Data[row1, 4]));
              num5 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssets].Data[row1, 2]));
              int tval = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssets].Data[row1, 9]));
              int integer = Conversions.ToInteger(game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue1, 14));
              str4: String = game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue1, 1);
              if (nr > 0)
                str4 = str4 + " " + game.HandyFunctionsObj.GetRomanNumerical(nr);
              int num15 = 0;
              if (num14 > 200 * nr)
              {
                int num16 = (int) Math.Round(Math.Ceiling((double) (num14 - 200 * nr) / 10.0));
                if (DrawMod.RandyNumber.Next(0, 100) < num16)
                {
                  num15 = 1;
                  s = s + str4 + " was completely obliterated. ";
                  int row2 = game.Data.StringListObj[this.slotAssets].FindRow(9, tval);
                  game.Data.StringListObj[this.slotAssets].RemoveRow(row2);
                  if (nr >= 1)
                  {
                    int idValue2_2 = nr + 1;
                    int idValue3 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssetTypes].GetData2(14, integer, 2, idValue2_2, 0)));
                    if (idValue3 > 0)
                    {
                      int num17 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssets].GetData3(3, idValue2, 4, idValue2_1, 1, idValue3, 9)));
                      if (num17 > 0 && (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotAssets].GetData(9, num17, 8))) >= 1)
                      {
                        int row3 = game.Data.StringListObj[this.slotAssets].FindRow(9, num17);
                        game.Data.StringListObj[this.slotAssets].RemoveRow(row3);
                      }
                    }
                  }
                }
              }
              if (num15 == 0)
              {
                int num18 = num14 - simpleList.Data2[index];
                s = s + str4 + " survived the attack but suffered " + num18.ToString() + " damage points. ";
              }
            }
          }
        }
      }
      int num19;
      int num20;
      int num21;
      if (this.rememberRadPts > 0)
      {
        if (hexLibVarValue1 > 0)
        {
          HelperEconomyData hed = new HelperEconomyData(ref game, "SE_Data")
          {
            zoneId = hexLibVarValue1
          };
          hed.zoneName = game.Data.StringListObj[hed.slotZones].GetData(0, hexLibVarValue1, 7);
          hed.locId = (int) Math.Round(Conversion.Val(game.Data.StringListObj[hed.slotZones].GetData(0, hexLibVarValue1, 6)));
          hed.locNr = -1;
          if (hed.locId > 0)
            hed.locNr = game.HandyFunctionsObj.GetLocationByID(hed.locId);
          hed.origRegimeId = (int) Math.Round(Conversion.Val(game.Data.StringListObj[hed.slotZones].GetData(0, hexLibVarValue1, 8)));
          hed.regid = hed.origRegimeId;
          hed.origRegimeNr = -1;
          hed.Input(hed.origRegimeId);
          int pop1 = hed.pop;
          int worker1 = hed.worker;
          int freeFolk1 = hed.freeFolk;
          game.EventRelatedObj.ZoneEconomy_ExposureEffects(ref hed, "SE_Data", cc.TargetX, cc.TargetY, this.rememberRadPts * 3);
          int pop2 = hed.pop;
          int worker2 = hed.worker;
          int freeFolk2 = hed.freeFolk;
          int num22;
          if (pop1 > pop2)
            num22 = pop1 - pop2;
          int num23;
          if (worker1 > worker2)
            num23 = worker1 - worker2;
          int num24;
          if (freeFolk1 > freeFolk2)
            num24 = freeFolk1 - freeFolk2;
          hed.Output(hed.origRegimeId);
          num19 = num22 * 100;
          num20 = num23 * 100;
          num21 = num24 * 100;
        }
        if (num19 > 0 | num20 > 0 | num21 > 0)
          s = num19.ToString() + " Population and " + num20.ToString() + " Workers and " + num21.ToString() + " Free Folk lost in strike. " + s;
        s = "Attack by " + game.Data.RegimeObj[cc.AttackerRegime].Name + " made use of Atomic weapons. " + this.rememberRadPts.ToString() + " of RAD points has been added to Hex. " + s;
      }
      if (s.Length <= 0)
        return;
      game.EditObj.CombatOneSentenceCustom += s;
      cc.AddBiggy(s);
      str5: String = s.Replace(". ", ".\r\n");
      texty1: String = game.EventRelatedObj.CheckHexName(cc.TargetX, cc.TargetY, 0, 0) + "(" + cc.TargetX.ToString() + "," + cc.TargetY.ToString() + ") was attacked.\r\n" + str5;
      DrawMod.TGame.EventRelatedObj.Helper_AddDetailedReport(DetailType.Combat, hexLibVarValue1, texty1, game.Data.RegimeObj[cc.DefenderRegime].id);
      if (!(this.rememberRadPts >= 200 & !game.Data.RegimeObj[cc.DefenderRegime].AI & hexLibVarValue1 > 0))
        return;
      texty2: String = game.EventRelatedObj.CheckHexName(cc.TargetX, cc.TargetY, 0, 0) + "(" + cc.TargetX.ToString() + "," + cc.TargetY.ToString() + ") was attacked.\r\nAttack by " + game.Data.RegimeObj[cc.AttackerRegime].Name + " made use of Atomic weapons. " + this.rememberRadPts.ToString() + " of RAD points has been added to Hex. ";
      if (num19 > 0 | num20 > 0 | num21 > 0)
        texty2 = texty2 + num19.ToString() + " Population and " + num20.ToString() + " Workers and " + num21.ToString() + " Free Folk lost in strike. ";
      game.EventRelatedObj.Helper_AddDetailedReportPlusData(DetailType.Nuke, hexLibVarValue1, texty2, game.Data.RegimeObj[cc.DefenderRegime].id, -1);
    }

    pub void EndCombatCall(ref CombatClass cc, GameClass game)
    {
      int num1 = (int) Math.Round((double) cc.CombatRound / 3.0) + 1;
      SimpleList simpleList1 = SimpleList::new();
      int ucounter = cc.UCounter;
      for (int index = 0; index <= ucounter; index += 1)
      {
        int unr = cc.UList[index].UNr;
        if (!Information.IsNothing((object) game.Data.UnitObj[unr].tempSFTypeBitmap))
        {
          game.Data.UnitObj[unr].tempSFTypeBitmap.Dispose();
          game.Data.UnitObj[unr].tempSFTypeBitmap = (Bitmap) null;
        }
      }
      int num2 = 0;
      int counter1 = this.SL.Counter;
      for (int index = 0; index <= counter1; index += 1)
      {
        if (this.SL.Weight[index] > 0)
          this.SL.Weight[index] = (int) Math.Round(Math.Sqrt(Math.Sqrt((double) this.SL.Weight[index])));
        simpleList1.AddWeight(this.SL.Id[index], DrawMod.RandyNumber.Next(1, 100));
        num2 += 1;
      }
      simpleList1.ReverseSortHighSpeed();
      if (this.SL.Counter > -1)
      {
        int num3 = num1;
        for (int index = 1; index <= num3; index += 1)
        {
          int nr = this.SL.FindNr(this.SL.GetRandomIdbasedOnWeight());
          int idValue = this.SL.Id[nr];
          int idValue2 = this.SL.Data1[nr];
          int setValue = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotCharSkill].GetData2(0, idValue, 1, idValue2, 4))) + 1;
          game.Data.StringListObj[this.slotCharSkill].SetData2(0, idValue, 1, idValue2, 4, setValue, true);
        }
      }
      int num4 = -1;
      SimpleList simpleList2 = SimpleList::new();
      int counter2 = simpleList1.Counter;
      for (int index1 = 0; index1 <= counter2; index1 += 1)
      {
        int num5 = simpleList1.Id[index1];
        int num6 = simpleList1.Weight[index1];
        int id = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotChar].GetData(0, num5, 5)));
        int regimeById = game.HandyFunctionsObj.GetRegimeByID(id);
        int num7 = 0;
        int num8;
        if (cc.AttackerRegime == regimeById)
        {
          if (simpleList2.FindNr(num5) == -1)
          {
            if ((int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotChar].GetData(0, num5, 6))) == 3)
              simpleList2.Add(num5, 100);
            else
              simpleList2.Add(num5, 10);
          }
          num8 = cc.BattleEnded != 1 ? num7 + 10 : num7 + 20;
        }
        else
          num8 = cc.BattleEnded != 2 ? num7 + 10 : num7 + 20;
        int num9 = 0;
        int combatRound = cc.CombatRound;
        for (int index2 = 1; index2 <= combatRound; index2 += 1)
        {
          if (index2 <= 10)
            num9 += (int) Math.Round(Math.Ceiling((double) index2 / 3.0));
        }
        int xpGain = num8 + num9;
        if ((int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotChar].GetData(0, num5, 6))) == 4)
          xpGain = (int) Math.Round((double) xpGain / 3.0);
        int num10 = game.EventRelatedObj.Helper_ModifyXPGain(xpGain, num5);
        int setValue = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotChar].GetData(0, num5, 17))) + num10;
        game.EventRelatedObj.AddLeaderTempLog(num5, "Gained " + num10.ToString() + " XP during combat in " + game.HandyFunctionsObj.GetHexName(cc.TargetX, cc.TargetY, 0));
        game.Data.StringListObj[this.slotChar].SetData(0, num5, 17, setValue);
      }
      if (cc.BattleEnded == 1)
        this.PersonalCombatRoll(ref cc, game, -1, -1, 0, "", false, true);
      if (simpleList2.Counter > -1)
        num4 = simpleList2.GetRandomIdbasedOnWeight();
      int num11 = 1;
      if (num4 > -1)
        num11 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotChar].GetData(0, num4, 15)));
      int num12 = new Random(num4).Next(1, 5);
      if (cc.dontUseSfx)
        return;
      if (cc.CombatType == 3)
      {
        if (num4 <= -1)
          return;
        int num13 = new Random(num4).Next(1, 21);
        string Soundfile;
        if (num11 == 2)
          Soundfile = game.AppPath + "sound/voiceovers_female" + num12.ToString() + "/acknowledged" + num13.ToString() + ".ogg";
        else
          Soundfile = game.AppPath + "sound/voiceovers/acknowledged" + num13.ToString() + ".wav";
        if (!(!game.AIRunning & !game.Data.RegimeObj[game.Data.Turn].AI))
          return;
        SoundMod.PlayAWave(Soundfile, ref game.EditObj);
      }
      else if (cc.CombatType == 13 | cc.CombatType == 5)
      {
        if (num4 <= -1)
          return;
        int num14 = 0;
        int num15 = 0;
        int icounter = cc.ICounter;
        for (int index = 0; index <= icounter; index += 1)
        {
          if (cc.IList[index].IAttacker == 1 && game.Data.SFTypeObj[cc.IList[index].ISFType].Theater == 2)
          {
            if (cc.IList[index].IKilled > 0)
              num15 += 1;
            else
              num14 += 1;
          }
        }
        string Soundfile;
        if (num15 >= num14)
        {
          int num16 = new Random(num4).Next(1, 3);
          Soundfile = game.AppPath + "sound/air/voiceovers/mayday" + num16.ToString() + ".wav";
        }
        else
        {
          int num17 = new Random(num4).Next(1, 3);
          Soundfile = game.AppPath + "sound/air/voiceovers/endofmission" + num17.ToString() + ".wav";
        }
        if (!(!game.AIRunning & !game.Data.RegimeObj[game.Data.Turn].AI))
          return;
        SoundMod.PlayAWave(Soundfile, ref game.EditObj);
      }
      else if (cc.BattleEnded == 1)
      {
        this.PersonalCombatRoll(ref cc, game, -1, -1, 0, "", false, true);
        if (num4 <= -1)
          return;
        int num18 = new Random(num4).Next(1, 11);
        string Soundfile;
        if (num11 == 2)
          Soundfile = game.AppPath + "sound/voiceovers_female" + num12.ToString() + "/battlewon" + num18.ToString() + ".ogg";
        else
          Soundfile = game.AppPath + "sound/voiceovers/battlewon" + num18.ToString() + ".wav";
        if (!(!game.AIRunning & !game.Data.RegimeObj[game.Data.Turn].AI))
          return;
        SoundMod.PlayAWave(Soundfile, ref game.EditObj);
      }
      else
      {
        if (num4 <= -1)
          return;
        int num19 = new Random(num4).Next(1, 7);
        string Soundfile;
        if (num11 == 2)
          Soundfile = game.AppPath + "sound/voiceovers_female" + num12.ToString() + "/battlelost" + num19.ToString() + ".ogg";
        else
          Soundfile = game.AppPath + "sound/voiceovers/battlelost" + num19.ToString() + ".wav";
        if (!(!game.AIRunning & !game.Data.RegimeObj[game.Data.Turn].AI))
          return;
        SoundMod.PlayAWave(Soundfile, ref game.EditObj);
      }
    }

    pub void EndBattleCall(ref CombatClass cc, GameClass game)
    {
      int index1 = (int) Math.Round((double) game.Data.RuleVar[407]) + 5;
      int index2 = (int) Math.Round((double) game.Data.RuleVar[407]) + 9;
      int index3 = (int) Math.Round((double) game.Data.RuleVar[407]) + 0;
      int index4 = (int) Math.Round((double) game.Data.RuleVar[407]) + 7;
      int index5 = (int) Math.Round((double) game.Data.RuleVar[407]) + 2;
      int index6 = (int) Math.Round((double) game.Data.RuleVar[407]) + 8;
      int ucounter1 = cc.UCounter;
      for (int index7 = 0; index7 <= ucounter1; index7 += 1)
      {
        if (cc.UList[index7].UDead == 0)
        {
          int unr = cc.UList[index7].UNr;
          SimpleList simpleList = SimpleList::new();
          int sfCount = game.Data.UnitObj[unr].SFCount;
          for (int index8 = 0; index8 <= sfCount; index8 += 1)
          {
            int sf = game.Data.UnitObj[unr].SFList[index8];
            int type = game.Data.SFObj[sf].Type;
            if (game.Data.SFTypeObj[type].SFTypeVar[index2] > 0)
              simpleList.AddWeight(game.Data.SFTypeObj[type].SFTypeVar[index1], game.Data.SFTypeObj[type].SFTypeVar[index2] * game.Data.SFObj[sf].Qty);
            if (game.Data.SFTypeObj[type].SFTypeVar[index4] > 0)
              simpleList.AddWeight(game.Data.SFTypeObj[type].SFTypeVar[index3], game.Data.SFTypeObj[type].SFTypeVar[index4] * game.Data.SFObj[sf].Qty);
            if (game.Data.SFTypeObj[type].SFTypeVar[index6] > 0)
              simpleList.AddWeight(game.Data.SFTypeObj[type].SFTypeVar[index5], game.Data.SFTypeObj[type].SFTypeVar[index6] * game.Data.SFObj[sf].Qty);
          }
          if (game.Data.UnitObj[unr].Historical > -1 && game.Data.HistoricalUnitObj[game.Data.UnitObj[unr].Historical].Type < 8)
          {
            int counter = game.Data.UnitObj[unr].items.list.Counter;
            for (int index9 = 0; index9 <= counter; index9 += 1)
            {
              int weight = simpleList.FindWeight(game.Data.UnitObj[unr].items.list.Id[index9]);
              if (game.Data.UnitObj[unr].items.list.Weight[index9] > weight)
                game.Data.UnitObj[unr].items.list.Weight[index9] = weight;
            }
          }
        }
      }
      if (this.slotUnitFeats > -1)
      {
        game.Data.StringListObj[this.slotUnitFeats].GetHighestValue(0);
        int ucounter2 = cc.UCounter;
        for (int index10 = 0; index10 <= ucounter2; index10 += 1)
        {
          int unr = cc.UList[index10].UNr;
          int historical = game.Data.UnitObj[unr].Historical;
          int icounter = cc.ICounter;
          for (int index11 = 0; index11 <= icounter; index11 += 1)
          {
            if (cc.IList[index11].IUnr == unr && !Information.IsNothing((object) cc.IList[index11].IunitFeat) && cc.IList[index11].IunitFeatStart > 0 & cc.IList[index11].IunitFeat.Counter > -1 && cc.IList[index11].IunitFeat.Id[0] < 1 | cc.IList[index11].IunitFeatDeadRound > 0 | cc.IList[index11].ICapitulate | cc.IList[index11].IKilled > 0)
            {
              int num = game.Data.HistoricalUnitObj[historical].GiveHisVarValue(100 + cc.IList[index11].IunitFeatStart) - 1;
              game.Data.HistoricalUnitObj[historical].SetHisVarValue(100 + cc.IList[index11].IunitFeatStart, num);
            }
          }
        }
      }
      int ucounter3 = cc.UCounter;
      for (int index12 = 0; index12 <= ucounter3; index12 += 1)
        game.EventRelatedObj.Helper_RemoveExcessUnitFeats(cc.UList[index12].UNr);
      int counter1 = this.MODL.Counter;
      for (int index13 = 0; index13 <= counter1; index13 += 1)
      {
        int idValue = this.MODL.Id[index13];
        if (idValue > 0)
        {
          int num1 = (int) Math.Round(Math.Sqrt((double) this.MODL.Weight[index13]));
          if (num1 > 10)
            num1 = 10;
          if (num1 > 0)
          {
            int setValue1 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotModelsClean].GetData2(0, idValue, 1, 7, 2)));
            int setValue2 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotModelsAdditive].GetData2(0, idValue, 1, 7, 2)));
            int num2 = 120 + (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotModels].GetData(0, idValue, 4))) * 10;
            int num3 = num1;
            for (int index14 = 1; index14 <= num3; index14 += 1)
            {
              int num4 = num2 - setValue1;
              if (num4 > 40)
              {
                setValue1 += 1;
                setValue2 += 1;
              }
              else if (num4 > 0 && DrawMod.RandyNumber.Next(0, 40) < num4 && DrawMod.RandyNumber.Next(0, 40) < num4)
              {
                setValue1 += 1;
                setValue2 += 1;
              }
            }
            game.Data.StringListObj[this.slotModelsClean].SetData2(0, idValue, 1, 7, 2, setValue1);
            game.Data.StringListObj[this.slotModelsAdditive].SetData2(0, idValue, 1, 7, 2, setValue2);
          }
        }
      }
    }

    pub void StartCombatRound(ref CombatClass cc, GameClass game, int combatRound)
    {
      int num1 = -1;
      int jobSpecificId1 = -1;
      int jobSpecificId2 = -1;
      int num2 = -1;
      SimpleList simpleList1 = SimpleList::new();
      int icounter1 = cc.ICounter;
      int num3;
      int num4;
      int num5;
      int num6;
      int num7;
      int num8;
      int num9;
      for (int index1 = 0; index1 <= icounter1; index1 += 1)
      {
        int index2 = cc.IList[index1].IUnr;
        bool flag = false;
        if (cc.IList[index1].IRetreat > 0)
          flag = true;
        if (cc.IList[index1].IKilled > 0)
          flag = true;
        if (cc.IList[index1].IRetreated > 0)
          flag = true;
        if (!flag)
        {
          int historical1 = game.Data.UnitObj[index2].Historical;
          int id = game.Data.RegimeObj[game.Data.UnitObj[cc.IList[index1].IUnr].Regime].id;
          if (historical1 > -1)
            num1 = game.Data.HistoricalUnitObj[historical1].ID;
          for (; index2 > -1; index2 = game.Data.UnitObj[index2].HQ)
          {
            int historical2 = game.Data.UnitObj[index2].Historical;
            if (game.Data.UnitObj[index2].IsHQ)
            {
              if (game.Data.HistoricalUnitObj[historical2].Type == 8)
                jobSpecificId2 = game.Data.HistoricalUnitObj[historical2].ID;
              else if (game.Data.HistoricalUnitObj[historical2].Type >= 5)
                jobSpecificId1 = game.Data.HistoricalUnitObj[historical2].ID;
            }
          }
          int characterId1 = game.EventRelatedObj.Helper_GetCharacterId(id, 3, jobSpecificId1, -1, this.slotChar);
          int characterId2 = game.EventRelatedObj.Helper_GetCharacterId(id, 4, jobSpecificId2, -1, this.slotChar);
          if (id == game.Data.RegimeObj[game.Data.Turn].id)
          {
            num3 += (int) Math.Round((double) (cc.IList[index1].ILisFuelMod * 100f));
            num4 += 1;
            num5 += (int) Math.Round((double) (cc.IList[index1].ILisAmmoMod * 100f));
            num6 += 1;
            num7 += 1;
            if (game.Data.SFTypeObj[cc.IList[index1].ISFType].UnitGroup == 3)
              num8 += 1;
            if (game.Data.SFTypeObj[cc.IList[index1].ISFType].UnitGroup == 2)
              num9 += 1;
            if (characterId1 > -1 & simpleList1.FindNr(characterId1) == -1)
              simpleList1.Add(characterId1, 100);
            if (characterId2 > -1 & simpleList1.FindNr(characterId2) == -1)
              simpleList1.Add(characterId2, 10);
          }
          if (characterId1 > -1)
          {
            int num10 = this.CachedSkillRoll(game, characterId1, 11);
            if (game.HandyFunctionsObj.Gethqpow(cc.IList[index1].IUnr) > DrawMod.RandyNumber.Next(0, 100))
            {
              this.SL.AddWeight(characterId1, 1, 11, CheckData1Existence: true);
              int mor = game.Data.SFObj[cc.IList[index1].ISFNr].Mor;
              if (cc.IList[index1].IMor < mor)
              {
                if (num10 > 200)
                {
                  Individual[] ilist = cc.IList;
                  Individual[] individualArray = ilist;
                  int index3 = index1;
                  int index4 = index3;
                  individualArray[index4].IMor = ilist[index3].IMor + 4;
                }
                else if (num10 > 150)
                {
                  Individual[] ilist = cc.IList;
                  Individual[] individualArray = ilist;
                  int index5 = index1;
                  int index6 = index5;
                  individualArray[index6].IMor = ilist[index5].IMor + 2;
                }
                else if (num10 > 100)
                {
                  Individual[] ilist = cc.IList;
                  Individual[] individualArray = ilist;
                  int index7 = index1;
                  int index8 = index7;
                  individualArray[index8].IMor = ilist[index7].IMor + 1;
                }
                if (cc.IList[index1].IMor > mor)
                  cc.IList[index1].IMor = mor;
              }
            }
          }
        }
      }
      int icounter2 = cc.ICounter;
      int index9;
      for (int index10 = 0; index10 <= icounter2; index10 += 1)
      {
        if (Information.IsNothing((object) cc.IList[index10].IunitFeat))
          cc.IList[index10].IunitFeat = SimpleList::new();
        txt: String = "";
        int counter = cc.IList[index10].IunitFeat.Counter;
        for (int index11 = 0; index11 <= counter; index11 += 1)
        {
          if (cc.IList[index10].IunitFeat.Id[index11] > 0)
          {
            string data;
            if (cc.IList[cc.FindISlot(cc.IList[index10].IunitFeat.Data1[index11])].IKilled == 0 & cc.IList[cc.FindISlot(cc.IList[index10].IunitFeat.Data1[index11])].IRetreated == 0 & cc.IList[cc.FindISlot(cc.IList[index10].IunitFeat.Data1[index11])].IRetreat == 0)
            {
              int idValue = cc.IList[index10].IunitFeat.Id[index11];
              data = game.Data.StringListObj[this.slotUnitFeats].GetData(0, idValue, 2);
              int length = game.Data.StringListObj[this.slotBehaviour].Length;
              for (int index12 = 0; index12 <= length; index12 += 1)
              {
                int num11 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index12, 0]));
                if ((int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index12, 1])) == idValue)
                {
                  int num12 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index12, 3]));
                  int num13 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index12, 4]));
                  int num14 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index12, 5]));
                  int num15 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index12, 6]));
                  int num16 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index12, 7]));
                  int index13;
                  str1: String = game.Data.StringListObj[this.slotBehaviour].Data[index12, index13];
                  int val2 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index12, 8]));
                  int num17 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index12, 9]));
                  bool flag1 = false;
                  if (cc.CombatType == 1 & num12 == 1)
                    flag1 = true;
                  if (cc.CombatType == 3 & num13 == 1)
                    flag1 = true;
                  if (num13 == 1 & cc.game.Data.SFTypeObj[cc.IList[index10].ISFType].ArtRange > 0)
                    flag1 = true;
                  if (num14 != 11)
                    flag1 = false;
                  bool flag2 = false;
                  if (cc.IList[index10].IRetreat > 0)
                    flag2 = true;
                  if (cc.IList[index10].IKilled > 0)
                    flag2 = true;
                  if (cc.IList[index10].IRetreated > 0)
                    flag2 = true;
                  if (flag2)
                    flag1 = false;
                  if (flag1)
                  {
                    if (num11 == 17 && cc.IList[index10].IAttacker != 1)
                    {
                      index9 = game.Data.SFObj[cc.IList[index10].ISFNr].CurrentEntrench;
                      int ientrench = cc.IList[index10].IEntrench;
                      int val1 = index9 - ientrench;
                      if (val1 > 0)
                      {
                        int num18 = Math.Min(val1, val2);
                        txt = data + " restored " + num18.ToString() + " entrenchment points.";
                        Individual[] ilist = cc.IList;
                        Individual[] individualArray = ilist;
                        int index14 = index10;
                        int index15 = index14;
                        individualArray[index15].IEntrench = ilist[index14].IEntrench + num18;
                      }
                    }
                    if (num11 == 26 && cc.IList[index10].IBreakTrough < 1)
                    {
                      str2: String = data + " gives " + num16.ToString() + "% chance on a breakthrough. ";
                      if (DrawMod.RandyNumber.Next(0, 100) < num16)
                      {
                        txt = str2 + "Succes!";
                        cc.IList[index10].IBreakTrough = combatRound;
                      }
                      else
                        txt = str2 + "Failed.";
                    }
                    if (num11 == 22)
                    {
                      index9 = game.Data.SFObj[cc.IList[index10].ISFNr].Mor;
                      int imor = cc.IList[index10].IMor;
                      int val1 = index9 - imor;
                      if (val1 > 0)
                      {
                        int num19 = Math.Min(val1, val2);
                        txt = data + " restored " + num19.ToString() + " morale points.";
                        Individual[] ilist = cc.IList;
                        Individual[] individualArray = ilist;
                        int index16 = index10;
                        int index17 = index16;
                        individualArray[index17].IMor = ilist[index16].IMor + num19;
                      }
                    }
                    if (num11 == 5)
                    {
                      index9 = game.Data.SFObj[cc.IList[index10].ISFNr].Rdn;
                      int irdn = cc.IList[index10].IRdn;
                      int val1 = index9 - irdn;
                      if (val1 > 0)
                      {
                        int num20 = Math.Min(val1, val2);
                        txt = data + " restored " + num20.ToString() + " readiness points.";
                        Individual[] ilist = cc.IList;
                        Individual[] individualArray = ilist;
                        int index18 = index10;
                        int index19 = index18;
                        individualArray[index19].IRdn = ilist[index18].IRdn + num20;
                      }
                    }
                    if (num11 == 29 & cc.UList[cc.IList[index10].IUlistNr].URetreat < 1)
                    {
                      SimpleList simpleList2 = SimpleList::new();
                      SimpleList simpleList3 = SimpleList::new();
                      int icounter3 = cc.ICounter;
                      for (int tid = 0; tid <= icounter3; tid += 1)
                      {
                        if (cc.IList[tid].IUnr == cc.IList[index10].IUnr & index10 != tid)
                        {
                          if (cc.IList[tid].IRetreated < 1 & cc.IList[tid].IRetreat > 0)
                          {
                            if (cc.IList[tid].IKilled < 1)
                              simpleList2.Add(tid, 10);
                          }
                          else if (cc.IList[tid].IRetreat < 1 & cc.IList[tid].IKilled < 1)
                            simpleList3.Add(tid, 100 - cc.IList[tid].IMor);
                        }
                      }
                      if (simpleList2.Counter > -1 & simpleList3.Counter > -1)
                      {
                        index9 = simpleList2.GetRandomIdbasedOnWeight();
                        txt = data + " killed our own #" + index9.ToString() + " individual to instill discipline and morale on troops still fighting.";
                        cc.IList[index9].IKilled = cc.CombatRound;
                        int num21 = num17;
                        for (int index20 = 1; index20 <= num21; index20 += 1)
                        {
                          if (simpleList3.Counter > -1)
                          {
                            int randomIdbasedOnWeight = simpleList3.GetRandomIdbasedOnWeight();
                            simpleList3.Remove(randomIdbasedOnWeight);
                            if (randomIdbasedOnWeight > -1)
                            {
                              Individual[] ilist = cc.IList;
                              Individual[] individualArray = ilist;
                              int index21 = randomIdbasedOnWeight;
                              int index22 = index21;
                              individualArray[index22].IMor = ilist[index21].IMor + val2;
                              if (100 < cc.IList[randomIdbasedOnWeight].IMor)
                                cc.IList[randomIdbasedOnWeight].IMor = 100;
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
            if (txt.Length > 0)
              cc.AddReport(0, data + " effect", txt, 10000 + index10, cc.CombatRound);
          }
        }
      }
      if (cc.CombatRound != 1 || !(!game.AIRunning & !game.Data.RegimeObj[game.Data.Turn].AI & !cc.dontUseSfx))
        return;
      if (simpleList1.Counter > -1)
        num2 = simpleList1.GetRandomIdbasedOnWeight();
      if (num2 <= -1)
        return;
      bool flag3;
      if (cc.CombatType == 3)
        flag3 = true;
      if (DrawMod.RandyNumber.Next(1, num7 + 1) <= (int) Math.Round((double) num9 / 2.0))
        flag3 = true;
      bool flag4;
      if (DrawMod.RandyNumber.Next(1, num7 + 1) <= (int) Math.Round((double) num8 / 2.0))
        flag4 = true;
      int num22 = (int) Math.Round((double) num5 / (double) num6);
      int num23 = (int) Math.Round((double) num3 / (double) num4);
      bool flag5;
      if (num22 < DrawMod.RandyNumber.Next(50, 85))
        flag5 = true;
      bool flag6;
      if (num23 < DrawMod.RandyNumber.Next(50, 85))
        flag6 = true;
      if (DrawMod.RandyNumber.Next(0, 100) < 50)
      {
        flag5 = false;
        flag6 = false;
      }
      bool flag7;
      if ((double) cc.ConcentricBonus > (double) DrawMod.RandyNumber.Next(40, 120))
        flag7 = true;
      if (cc.CombatType == 1)
        ;
      bool flag8;
      if (cc.CombatType == 11)
      {
        flag8 = true;
        flag6 = false;
        flag5 = false;
      }
      if (cc.CombatType == 3)
        flag6 = false;
      if (flag3 & flag4)
      {
        if (cc.CombatType == 3)
          flag4 = false;
        else
          flag3 = false;
      }
      bool flag9;
      if (cc.CombatType == 13 & cc.CombatType2 != 16)
        flag9 = true;
      bool flag10;
      if (cc.CombatType == 5)
        flag10 = true;
      Random random = new Random(num2);
      int num24 = 1;
      if (num2 > -1)
        num24 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotChar].GetData(0, num2, 15)));
      int num25 = new Random(num2).Next(1, 5);
      string Soundfile;
      if (flag9)
        Soundfile = game.AppPath + "sound/air/voiceovers/airrecon.wav";
      else if (flag10)
        Soundfile = game.AppPath + "sound/air/voiceovers/airstrike.wav";
      else if (flag7)
      {
        index9 = random.Next(1, 3);
        if (num24 == 2)
          Soundfile = game.AppPath + "sound/voiceovers_female" + num25.ToString() + "/concentric" + index9.ToString() + ".ogg";
        else
          Soundfile = game.AppPath + "sound/voiceovers/concentric" + index9.ToString() + ".wav";
      }
      else if (flag5)
      {
        index9 = 1;
        if (num24 == 2)
          Soundfile = game.AppPath + "sound/voiceovers_female" + num25.ToString() + "/ammo" + index9.ToString() + ".ogg";
        else
          Soundfile = game.AppPath + "sound/voiceovers/ammo" + index9.ToString() + ".wav";
      }
      else if (flag6)
      {
        index9 = random.Next(1, 3);
        if (num24 == 2)
          Soundfile = game.AppPath + "sound/voiceovers_female" + num25.ToString() + "/fuel" + index9.ToString() + ".ogg";
        else
          Soundfile = game.AppPath + "sound/voiceovers/fuel" + index9.ToString() + ".wav";
      }
      else if (flag8)
      {
        index9 = random.Next(1, 8);
        if (num24 == 2)
          Soundfile = game.AppPath + "sound/voiceovers_female" + num25.ToString() + "/surprise" + index9.ToString() + ".ogg";
        else
          Soundfile = game.AppPath + "sound/voiceovers/surprise" + index9.ToString() + ".wav";
      }
      else if (flag3)
      {
        index9 = random.Next(1, 7);
        if (num24 == 2)
          Soundfile = game.AppPath + "sound/voiceovers_female" + num25.ToString() + "/fire" + index9.ToString() + ".ogg";
        else
          Soundfile = game.AppPath + "sound/voiceovers/fire" + index9.ToString() + ".wav";
      }
      else if (flag4)
      {
        index9 = random.Next(1, 5);
        if (num24 == 2)
          Soundfile = game.AppPath + "sound/voiceovers_female" + num25.ToString() + "/tank" + index9.ToString() + ".ogg";
        else
          Soundfile = game.AppPath + "sound/voiceovers/tank" + index9.ToString() + ".wav";
      }
      else
      {
        index9 = random.Next(1, 13);
        if (num24 == 2)
          Soundfile = game.AppPath + "sound/voiceovers_female" + num25.ToString() + "/general" + index9.ToString() + ".ogg";
        else
          Soundfile = game.AppPath + "sound/voiceovers/general" + index9.ToString() + ".wav";
      }
      if (Soundfile.Length <= 0)
        return;
      SoundMod.PlayAWave(Soundfile, ref game.EditObj);
    }

    pub int NumberOfMods() => this.airEnabled ? 22 : 15;

    pub string GetModName(int nr)
    {
      switch (nr)
      {
        case 1:
          return "Skill Tank Tactics";
        case 2:
          return "Skill Gun Tactics";
        case 3:
          return "Skill Infantry Tactics";
        case 4:
          return "Skill Escape Artist";
        case 5:
          return "Skill Demolitions";
        case 6:
          return "Skill Offensive Tactics";
        case 7:
          return "Skill Defensive Tactics";
        case 8:
          return "Skill Operational Command";
        case 9:
          return "Skill High Command";
        case 10:
          return "Posture Combat Bonus";
        case 11:
          return "Profile Combat Bonus";
        case 12:
          return "Unit Feat Mod";
        case 13:
          return "Skill Deception";
        case 14:
          return "Weapon Matrix Mod";
        case 15:
          return "Callibre Matrix Mod";
        case 16:
          return "Air Combat Range";
        case 17:
          return "Dogfight Modifier";
        case 18:
          return "Skill Air Tactics";
        case 19:
          return "Skill Air Intercepts";
        case 20:
          return "Skill Air Offensive";
        case 21:
          return "Skill Ground Attack";
        case 22:
          return "Skill Anti-Air Tactics";
        default:
          string modName;
          return modName;
      }
    }

    pub int IndividualCombatCall_HasNoEarlyCombatRoundPenalties(
      ref CombatClass cc,
      GameClass game,
      int attnr,
      int defnr,
      bool isCounterAttack,
      ref string s9)
    {
      int num1 = -1;
      int index1 = -1;
      int unitGroup = game.Data.SFTypeObj[cc.IList[defnr].ISFType].UnitGroup;
      int iunr = cc.IList[defnr].IUnr;
      int historical = game.Data.UnitObj[iunr].Historical;
      int id = game.Data.RegimeObj[game.Data.UnitObj[cc.IList[defnr].IUnr].Regime].id;
      if (historical > -1)
        num1 = game.Data.HistoricalUnitObj[historical].ID;
      if (index1 > -1 && game.Data.HistoricalUnitObj[index1].GiveHisVarValue(30) < 0)
        return 0;
      int num2 = 100;
      int num3 = 1;
      do
      {
        int index2 = -1;
        int index3 = -1;
        if (num3 == 1)
        {
          index2 = attnr;
          index3 = defnr;
        }
        if (num3 == 2)
        {
          index2 = defnr;
          index3 = attnr;
        }
        if (!Information.IsNothing((object) cc.IList[index2].IunitFeat))
        {
          int counter = cc.IList[index2].IunitFeat.Counter;
          for (int index4 = 0; index4 <= counter; index4 += 1)
          {
            if (cc.IList[index2].IunitFeat.Id[index4] > 0 && cc.IList[cc.FindISlot(cc.IList[index2].IunitFeat.Data1[index4])].IKilled == 0 & cc.IList[cc.FindISlot(cc.IList[index2].IunitFeat.Data1[index4])].IRetreated == 0 & cc.IList[cc.FindISlot(cc.IList[index2].IunitFeat.Data1[index4])].IRetreat == 0)
            {
              int idValue = cc.IList[index2].IunitFeat.Id[index4];
              data: String = game.Data.StringListObj[this.slotUnitFeats].GetData(0, idValue, 2);
              int length = game.Data.StringListObj[this.slotBehaviour].Length;
              for (int index5 = 0; index5 <= length; index5 += 1)
              {
                int num4 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 0]));
                if ((int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 1])) == idValue)
                {
                  int num5 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 3]));
                  int num6 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 4]));
                  int num7 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 5]));
                  int num8 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 6]));
                  int num9 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 7]));
                  int index6;
                  str: String = game.Data.StringListObj[this.slotBehaviour].Data[index5, index6];
                  int num10 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 8]));
                  int num11 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 9]));
                  bool flag = false;
                  if (cc.CombatType == 1 & num5 == 1)
                    flag = true;
                  if (cc.CombatType == 3 & num6 == 1)
                    flag = true;
                  if (num6 == 1 & cc.game.Data.SFTypeObj[cc.IList[index2].ISFType].ArtRange > 0)
                    flag = true;
                  if (num7 != 5)
                    flag = false;
                  if (num8 > -1 & num8 != game.Data.SFTypeObj[cc.IList[index3].ISFType].UnitGroup)
                    flag = false;
                  if (flag && num4 == 1 && index2 == attnr)
                  {
                    num2 -= (int) Math.Round((double) (num2 * num9) / 100.0);
                    s9 = data + " diminished battle startup penalty with " + num9.ToString() + "%.";
                  }
                }
              }
            }
          }
        }
        num3 += 1;
      }
      while (num3 <= 2);
      return num2;
    }

    pub int UnitCombatCall_AvoidPanic(GameClass game, int unr, ref string s9)
    {
      int num = -1;
      int idValue2 = -1;
      int historical1 = game.Data.UnitObj[unr].Historical;
      int id = game.Data.RegimeObj[game.Data.UnitObj[unr].Regime].id;
      if (historical1 > -1)
        num = game.Data.HistoricalUnitObj[historical1].ID;
      unr = game.Data.UnitObj[unr].HQ;
      if (unr > -1)
      {
        int historical2 = game.Data.UnitObj[unr].Historical;
        if (game.Data.UnitObj[unr].IsHQ && game.Data.HistoricalUnitObj[historical2].Type >= 5)
          idValue2 = game.Data.HistoricalUnitObj[historical2].ID;
      }
      if (idValue2 > 0)
      {
        int charId = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotChar].GetData2(6, 3, 7, idValue2, 0)));
        if (charId > 0 && game.HandyFunctionsObj.Gethqpow(unr) > DrawMod.RandyNumber.Next(0, 100) && this.CachedSkillRoll(game, charId, 16) >= 100)
        {
          s9 = "Operational Commander managed to avoid the unit panicking by succesfull Against the Odds roll.";
          return 1;
        }
      }
      return 0;
    }

    pub int UnitAirBridgeBonus(GameClass game, int unr)
    {
      int num1 = -1;
      int idValue2 = -1;
      int historical1 = game.Data.UnitObj[unr].Historical;
      int id = game.Data.RegimeObj[game.Data.UnitObj[unr].Regime].id;
      if (historical1 > -1)
        num1 = game.Data.HistoricalUnitObj[historical1].ID;
      unr = game.Data.UnitObj[unr].HQ;
      if (unr > -1)
      {
        int historical2 = game.Data.UnitObj[unr].Historical;
        if (game.Data.UnitObj[unr].IsHQ && game.Data.HistoricalUnitObj[historical2].Type >= 5)
          idValue2 = game.Data.HistoricalUnitObj[historical2].ID;
      }
      if (idValue2 > 0)
      {
        int charId = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotChar].GetData2(6, 3, 7, idValue2, 0)));
        if (charId > 0 && game.HandyFunctionsObj.Gethqpow(unr) > DrawMod.RandyNumber.Next(0, 100))
        {
          int num2 = this.CachedSkillRoll(game, charId, 55);
          if (num2 > 100)
            return num2 - 100;
        }
      }
      return 0;
    }

    pub int IndividualCombatCall_RiverTypeAndLandscapeTypeModifier(
      ref CombatClass cc,
      GameClass game,
      int attnr,
      int defnr,
      bool isCounterAttack,
      ref string s9,
      int riverHpMod,
      int landscapeAttMod,
      int landscapeDefMod,
      int riverType)
    {
      int num1 = -1;
      int unitGroup = game.Data.SFTypeObj[cc.IList[defnr].ISFType].UnitGroup;
      int iunr = cc.IList[defnr].IUnr;
      int historical = game.Data.UnitObj[iunr].Historical;
      int id = game.Data.RegimeObj[game.Data.UnitObj[cc.IList[defnr].IUnr].Regime].id;
      if (historical > -1)
        num1 = game.Data.HistoricalUnitObj[historical].ID;
      int num2 = 100;
      if (riverHpMod != 0)
        num2 = riverHpMod;
      if (landscapeAttMod != 0)
        num2 = landscapeAttMod;
      if (landscapeDefMod != 0)
        num2 = landscapeDefMod;
      int num3 = 1;
      do
      {
        int index1 = -1;
        int index2 = -1;
        if (num3 == 1)
        {
          index1 = attnr;
          index2 = defnr;
        }
        if (num3 == 2)
        {
          index1 = defnr;
          index2 = attnr;
        }
        if (!Information.IsNothing((object) cc.IList[index1].IunitFeat))
        {
          int counter = cc.IList[index1].IunitFeat.Counter;
          for (int index3 = 0; index3 <= counter; index3 += 1)
          {
            if (cc.IList[index1].IunitFeat.Id[index3] > 0 && cc.IList[cc.FindISlot(cc.IList[index1].IunitFeat.Data1[index3])].IKilled == 0 & cc.IList[cc.FindISlot(cc.IList[index1].IunitFeat.Data1[index3])].IRetreated == 0 & cc.IList[cc.FindISlot(cc.IList[index1].IunitFeat.Data1[index3])].IRetreat == 0)
            {
              int idValue = cc.IList[index1].IunitFeat.Id[index3];
              data: String = game.Data.StringListObj[this.slotUnitFeats].GetData(0, idValue, 2);
              int length = game.Data.StringListObj[this.slotBehaviour].Length;
              for (int index4 = 0; index4 <= length; index4 += 1)
              {
                int num4 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 0]));
                if ((int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 1])) == idValue)
                {
                  int num5 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 3]));
                  int num6 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 4]));
                  int num7 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 5]));
                  int num8 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 6]));
                  int num9 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 7]));
                  int index5;
                  str1: String = game.Data.StringListObj[this.slotBehaviour].Data[index4, index5];
                  int num10 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 8]));
                  int num11 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 9]));
                  bool flag = false;
                  if (cc.CombatType == 1 & num5 == 1)
                    flag = true;
                  if (cc.CombatType == 3 & num6 == 1)
                    flag = true;
                  if (num6 == 1 & cc.game.Data.SFTypeObj[cc.IList[index1].ISFType].ArtRange > 0)
                    flag = true;
                  if (num7 != 12)
                    flag = false;
                  if (num8 > -1 & num8 != game.Data.SFTypeObj[cc.IList[index2].ISFType].UnitGroup)
                    flag = false;
                  if (flag)
                  {
                    int num12;
                    int num13;
                    if (num4 == 36 && index1 == attnr && num9 == -1 | game.Data.MapObj[0].HexObj[cc.TargetX, cc.TargetY].LandscapeType == num9)
                    {
                      int num14 = num2;
                      if (num2 < num11)
                      {
                        num2 += num10;
                        if (num2 > num11)
                          num2 = num11;
                        ref local: String = ref s9;
                        string[] strArray1 = new string[6]
                        {
                          data,
                          " changed landscape modifier from ",
                          null,
                          null,
                          null,
                          null
                        };
                        string[] strArray2 = strArray1;
                        num12 = num14 - 100;
                        str2: String = num12.ToString();
                        strArray2[2] = str2;
                        strArray1[3] = "% to ";
                        string[] strArray3 = strArray1;
                        num13 = num2 - 100;
                        str3: String = num13.ToString();
                        strArray3[4] = str3;
                        strArray1[5] = "%.";
                        str4: String = string.Concat(strArray1);
                        local = str4;
                      }
                    }
                    if (num4 == 35 && index1 == defnr && num9 == -1 | riverType == num9)
                    {
                      int num15 = num2;
                      if (num2 < 100)
                      {
                        num2 += num10;
                        if (num2 > 100)
                          num2 = 100;
                        ref local: String = ref s9;
                        string[] strArray4 = new string[6]
                        {
                          data,
                          "  changed river modifier from ",
                          null,
                          null,
                          null,
                          null
                        };
                        string[] strArray5 = strArray4;
                        num13 = num15 - 100;
                        str5: String = num13.ToString();
                        strArray5[2] = str5;
                        strArray4[3] = "% to ";
                        string[] strArray6 = strArray4;
                        num12 = num2 - 100;
                        str6: String = num12.ToString();
                        strArray6[4] = str6;
                        strArray4[5] = "%.";
                        str7: String = string.Concat(strArray4);
                        local = str7;
                      }
                    }
                  }
                }
              }
            }
          }
        }
        num3 += 1;
      }
      while (num3 <= 2);
      return num2;
    }

    pub IndividualCombatCall_SmallSizeBGmodifierApplies: bool(
      ref CombatClass cc,
      GameClass game,
      int attnr,
      int defnr)
    {
      int isfType = cc.IList[attnr].ISFType;
      int id = game.Data.SFTypeObj[isfType].Id;
      int integer = Conversions.ToInteger(game.Data.StringListObj[this.slotModels].GetData(5, id, 2));
      return game.HandyFunctionsObj.GetRegimeByID(integer) > 0;
    }

    pub int IndividualCombatCall_ResultModifier(
      int result,
      ref CombatClass cc,
      GameClass game,
      int attnr,
      int defnr,
      bool isCounterAttack,
      float attval,
      float defval,
      ref string s9)
    {
      int num1 = -1;
      int id1 = -1;
      int num2 = -1;
      int num3 = -1;
      int id2 = -1;
      int num4 = -1;
      int unitGroup1 = game.Data.SFTypeObj[cc.IList[attnr].ISFType].UnitGroup;
      int iunr1 = cc.IList[attnr].IUnr;
      int historical1 = game.Data.UnitObj[iunr1].Historical;
      int id3 = game.Data.RegimeObj[game.Data.UnitObj[cc.IList[attnr].IUnr].Regime].id;
      if (historical1 > -1)
        num1 = game.Data.HistoricalUnitObj[historical1].ID;
      for (int index = iunr1; index > -1; index = game.Data.UnitObj[index].HQ)
      {
        int historical2 = game.Data.UnitObj[index].Historical;
        if (game.Data.UnitObj[index].IsHQ)
        {
          if (game.Data.HistoricalUnitObj[historical2].Type == 8)
            num2 = game.Data.HistoricalUnitObj[historical2].ID;
          else if (game.Data.HistoricalUnitObj[historical2].Type >= 5)
            id1 = game.Data.HistoricalUnitObj[historical2].ID;
        }
      }
      int num5 = -1;
      if (id1 > -1)
        num5 = game.HandyFunctionsObj.GetHistoricalUnitByID(id1);
      int unitGroup2 = game.Data.SFTypeObj[cc.IList[defnr].ISFType].UnitGroup;
      int iunr2 = cc.IList[defnr].IUnr;
      int historical3 = game.Data.UnitObj[iunr2].Historical;
      int id4 = game.Data.RegimeObj[game.Data.UnitObj[cc.IList[defnr].IUnr].Regime].id;
      if (historical3 > -1)
        num3 = game.Data.HistoricalUnitObj[historical3].ID;
      for (int index = iunr2; index > -1; index = game.Data.UnitObj[index].HQ)
      {
        int historical4 = game.Data.UnitObj[index].Historical;
        if (game.Data.UnitObj[index].IsHQ)
        {
          if (game.Data.HistoricalUnitObj[historical4].Type == 8)
            num4 = game.Data.HistoricalUnitObj[historical4].ID;
          else if (game.Data.HistoricalUnitObj[historical4].Type >= 5)
            id2 = game.Data.HistoricalUnitObj[historical4].ID;
        }
      }
      int num6 = -1;
      if (id2 > -1)
        num6 = game.HandyFunctionsObj.GetHistoricalUnitByID(id2);
      s9 = "";
      int num7 = 1;
      int tid1;
      do
      {
        int index1 = -1;
        int index2 = -1;
        if (num7 == 1)
        {
          index1 = attnr;
          index2 = defnr;
        }
        if (num7 == 2)
        {
          index1 = defnr;
          index2 = attnr;
        }
        if (!Information.IsNothing((object) cc.IList[index1].IunitFeat))
        {
          int counter = cc.IList[index1].IunitFeat.Counter;
          for (int index3 = 0; index3 <= counter; index3 += 1)
          {
            if (cc.IList[index1].IunitFeat.Id[index3] > 0 && cc.IList[cc.FindISlot(cc.IList[index1].IunitFeat.Data1[index3])].IKilled == 0 & cc.IList[cc.FindISlot(cc.IList[index1].IunitFeat.Data1[index3])].IRetreated == 0 & cc.IList[cc.FindISlot(cc.IList[index1].IunitFeat.Data1[index3])].IRetreat == 0)
            {
              int idValue = cc.IList[index1].IunitFeat.Id[index3];
              data: String = game.Data.StringListObj[this.slotUnitFeats].GetData(0, idValue, 2);
              int length = game.Data.StringListObj[this.slotBehaviour].Length;
              for (int index4 = 0; index4 <= length; index4 += 1)
              {
                int num8 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 0]));
                if ((int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 1])) == idValue)
                {
                  int num9 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 3]));
                  int num10 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 4]));
                  int num11 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 5]));
                  int num12 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 6]));
                  int num13 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 7]));
                  int index5;
                  idValue2: String = game.Data.StringListObj[this.slotBehaviour].Data[index4, index5];
                  int Expression = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 8]));
                  int num14 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index4, 9]));
                  bool flag = false;
                  if (cc.CombatType == 1 & num9 == 1)
                    flag = true;
                  if (cc.CombatType == 3 & num10 == 1)
                    flag = true;
                  if (num10 == 1 & cc.game.Data.SFTypeObj[cc.IList[index1].ISFType].ArtRange > 0)
                    flag = true;
                  if (num11 != 4)
                    flag = false;
                  if (num12 > -1 & num12 != game.Data.SFTypeObj[cc.IList[index2].ISFType].UnitGroup)
                    flag = false;
                  if (flag)
                  {
                    if (num8 == 14 && index1 == defnr && result == 3)
                    {
                      s9 = data + " tried to prevent RETREAT result. " + num13.ToString() + "% chance. ";
                      if (DrawMod.RandyNumber.Next(0, 100) < num13)
                      {
                        result = 0;
                        s9 += "Succes!";
                      }
                      else
                        s9 += "Failed.";
                    }
                    if (num8 == 24 && index1 == defnr && result == 1)
                    {
                      s9 = data + " tried to prevent KILL result. " + num13.ToString() + "% chance. ";
                      if (DrawMod.RandyNumber.Next(0, 100) < num13)
                      {
                        result = 3;
                        s9 += "Succes!";
                      }
                      else
                        s9 += "Failed.";
                    }
                    if (num8 == 27 && index1 == attnr && result > 0)
                    {
                      tid1 = (int) Math.Round((double) (cc.IList[defnr].IRdn * num13) / 100.0);
                      Individual[] ilist1 = cc.IList;
                      Individual[] individualArray1 = ilist1;
                      int index6 = defnr;
                      int index7 = index6;
                      individualArray1[index7].IRdn = ilist1[index6].IRdn - tid1;
                      Individual[] ilist2 = cc.IList;
                      Individual[] individualArray2 = ilist2;
                      int index8 = attnr;
                      int index9 = index8;
                      individualArray2[index9].IRdn = ilist2[index8].IRdn + tid1;
                      if (100 > cc.IList[attnr].IRdn)
                        cc.IList[attnr].IRdn = 100;
                      s9 = data + " took " + tid1.ToString() + " readiness from target and added it to own readiness.";
                    }
                    if (num8 == 31 && index1 == attnr && result > 0)
                    {
                      tid1 = (int) Math.Round((double) (cc.IList[defnr].IXp * num13) / 100.0);
                      Individual[] ilist = cc.IList;
                      Individual[] individualArray = ilist;
                      int index10 = defnr;
                      int index11 = index10;
                      individualArray[index11].IXp = ilist[index10].IXp - tid1;
                      s9 = data + " destroyed " + tid1.ToString() + " experience of target.";
                    }
                    if (num8 == 6 && index1 == attnr && result == 0 | result == 4)
                    {
                      s9 = data + " tried to make enemy RETREAT. " + num13.ToString() + "% chance. ";
                      if (DrawMod.RandyNumber.Next(0, 100) < num13)
                      {
                        result = 3;
                        s9 += "Succes!";
                      }
                      else
                        s9 += "Failed.";
                    }
                    if (num8 == 4 && index1 == attnr && result == 1)
                    {
                      tid1 = game.Data.SFTypeObj[cc.IList[defnr].ISFType].HitPoints[game.Data.SFTypeObj[cc.IList[attnr].ISFType].UnitGroup];
                      int num15 = (int) Math.Round((double) ((int) Math.Round(Conversion.Val((object) Expression)) * tid1) / 1000.0) + 1;
                      if (num15 > 0)
                      {
                        s9 = data + " took " + num15.ToString() + " " + idValue2 + " of plunder from killed target.";
                        int setValue = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotRegimeKey].GetData2(0, id3, 1, idValue2, 2))) + num15;
                        game.Data.StringListObj[this.slotRegimeKey].SetData2(0, id3, 1, idValue2, 2, setValue);
                      }
                    }
                    if (num8 == 28 && index1 == attnr && result != 1)
                    {
                      s9 = data + " tried to KILL the target. " + num13.ToString() + "% chance. ";
                      if (DrawMod.RandyNumber.Next(0, 100) < num13)
                      {
                        result = 1;
                        s9 += "Succes!";
                      }
                      else
                        s9 += "Failed.";
                    }
                  }
                }
              }
            }
          }
        }
        num7 += 1;
      }
      while (num7 <= 2);
      if (result == 3)
      {
        int people = game.Data.SFObj[cc.IList[defnr].ISFNr].People;
        if (people > -1 && DrawMod.TGame.Data.PeopleObj[people].tv0 == (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[this.slotGameKeys].GetData(0, 37, 2))))
          result = game.Data.SFTypeObj[cc.IList[attnr].ISFType].KillPercent * 2 < DrawMod.RandyNumber.Next(0, 100) ? 4 : 1;
      }
      if (result == 1)
        this.PersonalCombatRoll(ref cc, game, cc.IList[defnr].IUnr, defnr, 50, "", false, false);
      if (result != 0)
      {
        tid1 = game.Data.SFTypeObj[cc.IList[attnr].ISFType].SFTypeVar[81];
        int tid2 = game.Data.SFTypeObj[cc.IList[defnr].ISFType].SFTypeVar[81];
        if (tid1 > 0)
          this.MODL.AddWeight(tid1, 1);
        if (tid2 > 0)
          this.MODL.AddWeight(tid2, 5);
      }
      if (result != 0)
      {
        int[] sfTypeVar1 = game.Data.SFTypeObj[cc.IList[attnr].ISFType].SFTypeVar;
        int[] numArray1 = sfTypeVar1;
        int index12 = 4;
        int index13 = index12;
        int num16 = sfTypeVar1[index12] + 1;
        numArray1[index13] = num16;
        if (game.Data.SFTypeObj[cc.IList[defnr].ISFType].UnitGroup == 3 | game.Data.SFTypeObj[cc.IList[defnr].ISFType].UnitGroup == 4)
        {
          int[] sfTypeVar2 = game.Data.SFTypeObj[cc.IList[attnr].ISFType].SFTypeVar;
          int[] numArray2 = sfTypeVar2;
          int index14 = 5;
          int index15 = index14;
          int num17 = sfTypeVar2[index14] + 1;
          numArray2[index15] = num17;
        }
        else if (game.Data.SFTypeObj[cc.IList[defnr].ISFType].UnitGroup == 8 | game.Data.SFTypeObj[cc.IList[defnr].ISFType].UnitGroup == 9)
        {
          int[] sfTypeVar3 = game.Data.SFTypeObj[cc.IList[attnr].ISFType].SFTypeVar;
          int[] numArray3 = sfTypeVar3;
          int index16 = 6;
          int index17 = index16;
          int num18 = sfTypeVar3[index16] + 1;
          numArray3[index17] = num18;
        }
        int[] sfTypeVar4 = game.Data.SFTypeObj[cc.IList[defnr].ISFType].SFTypeVar;
        int[] numArray4 = sfTypeVar4;
        int index18 = 1;
        int index19 = index18;
        int num19 = sfTypeVar4[index18] + 1;
        numArray4[index19] = num19;
        if (game.Data.SFTypeObj[cc.IList[attnr].ISFType].UnitGroup == 3 | game.Data.SFTypeObj[cc.IList[attnr].ISFType].UnitGroup == 4)
        {
          int[] sfTypeVar5 = game.Data.SFTypeObj[cc.IList[defnr].ISFType].SFTypeVar;
          int[] numArray5 = sfTypeVar5;
          int index20 = 2;
          int index21 = index20;
          int num20 = sfTypeVar5[index20] + 1;
          numArray5[index21] = num20;
        }
        else if (game.Data.SFTypeObj[cc.IList[attnr].ISFType].UnitGroup == 8 | game.Data.SFTypeObj[cc.IList[attnr].ISFType].UnitGroup == 9)
        {
          int[] sfTypeVar6 = game.Data.SFTypeObj[cc.IList[defnr].ISFType].SFTypeVar;
          int[] numArray6 = sfTypeVar6;
          int index22 = 3;
          int index23 = index22;
          int num21 = sfTypeVar6[index22] + 1;
          numArray6[index23] = num21;
        }
      }
      if (result == 0 && cc.game.Data.SFTypeObj[cc.IList[defnr].ISFType].SFTypeVar[82] > 0 && cc.game.Data.SFTypeObj[cc.IList[defnr].ISFType].SFTypeVar[8] > 100000)
      {
        int isfType = cc.IList[defnr].ISFType;
        if (cc.game.Data.SFTypeObj[isfType].SFTypeVar[8] > 0)
        {
          int num22 = (int) Math.Round(Conversion.Val(Strings.Mid(cc.game.Data.SFTypeObj[isfType].SFTypeVar[8].ToString(), 5, 1)));
          if (num22 > 0)
          {
            tid1 = cc.IList[attnr].IMor;
            tid1 = (int) Math.Round(Math.Ceiling((double) (tid1 * num22) / 20.0));
            Individual[] ilist = cc.IList;
            Individual[] individualArray = ilist;
            int index24 = attnr;
            int index25 = index24;
            individualArray[index25].IMor = ilist[index24].IMor - tid1;
            if (cc.IList[attnr].IMor < 1)
              cc.IList[attnr].IMor = 1;
            s9 += "Morale loss for attacker due to Bane Fauna Feat. ";
          }
        }
      }
      if (result != 0 && cc.game.Data.SFTypeObj[cc.IList[defnr].ISFType].SFTypeVar[82] > 0 && cc.game.Data.SFTypeObj[cc.IList[defnr].ISFType].SFTypeVar[8] > 100000)
      {
        int isfType = cc.IList[defnr].ISFType;
        if (cc.game.Data.SFTypeObj[isfType].SFTypeVar[8] > 0)
        {
          int num23 = (int) Math.Round(Conversion.Val(Strings.Mid(cc.game.Data.SFTypeObj[isfType].SFTypeVar[8].ToString(), 6, 1)));
          if (num23 > 0 && DrawMod.RandyNumber.Next(0, 100) < 40 + num23 * 10)
          {
            s9 += "Regenerate Fauna Feat cancels effects of hit. ";
            result = 0;
          }
        }
      }
      return result;
    }

    pub float IndividualCombatCall_AttValModder(
      int modNr,
      ref CombatClass cc,
      GameClass game,
      int attnr,
      int defnr,
      bool isCounterAttack,
      float attval,
      ref string s9)
    {
      int num1 = -1;
      int num2 = -1;
      int jobSpecificId = -1;
      int unitGroup1 = game.Data.SFTypeObj[cc.IList[attnr].ISFType].UnitGroup;
      int index1 = cc.IList[attnr].IUnr;
      int historical1 = game.Data.UnitObj[index1].Historical;
      int id1 = game.Data.RegimeObj[game.Data.UnitObj[cc.IList[attnr].IUnr].Regime].id;
      if (historical1 > -1)
        num1 = game.Data.HistoricalUnitObj[historical1].ID;
      int num3 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotRegimes].GetData(0, id1, 1)));
      bool flag1 = false;
      if (game.Data.HistoricalUnitObj[historical1].GiveHisVarValue(11) > 0)
        flag1 = true;
      if ((int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotRegimes].GetData(0, id1, 1))) > 1)
        flag1 = true;
      for (; index1 > -1; index1 = game.Data.UnitObj[index1].HQ)
      {
        int historical2 = game.Data.UnitObj[index1].Historical;
        if (game.Data.UnitObj[index1].IsHQ)
        {
          if (game.Data.HistoricalUnitObj[historical2].Type == 8)
            jobSpecificId = game.Data.HistoricalUnitObj[historical2].ID;
          else if (game.Data.HistoricalUnitObj[historical2].Type >= 5)
            num2 = game.Data.HistoricalUnitObj[historical2].ID;
        }
      }
      if (modNr == 12 && cc.game.Data.SFTypeObj[cc.IList[defnr].ISFType].SFTypeVar[82] > 0 && cc.IList[attnr].IUnr > -1 && DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.UnitObj[cc.IList[attnr].IUnr].Regime].AI)
        attval *= 2f;
      if (modNr == 12)
      {
        if (cc.game.Data.SFTypeObj[cc.IList[attnr].ISFType].SFTypeVar[82] > 0 && cc.game.Data.SFTypeObj[cc.IList[attnr].ISFType].SFTypeVar[8] > 100000)
        {
          int isfType = cc.IList[attnr].ISFType;
          if (cc.game.Data.SFTypeObj[isfType].SFTypeVar[8] > 0)
          {
            int num4 = (int) Math.Round(Conversion.Val(Strings.Mid(cc.game.Data.SFTypeObj[isfType].SFTypeVar[8].ToString(), 3, 1)));
            if (num4 > 0 && cc.CombatRound == 1 & cc.IList[attnr].IAttacker == 0)
            {
              int num5 = (int) Math.Round((double) (attval * (float) num4));
              s9 = s9 + "Traps set by critter adds " + num5.ToString() + " attack points.";
              attval += (float) num5;
            }
          }
        }
        if (cc.game.Data.SFTypeObj[cc.IList[defnr].ISFType].SFTypeVar[82] > 0 && cc.game.Data.SFTypeObj[cc.IList[defnr].ISFType].SFTypeVar[8] > 100000)
        {
          int isfType1 = cc.IList[defnr].ISFType;
          if (cc.game.Data.SFTypeObj[isfType1].SFTypeVar[8] > 0)
          {
            int num6 = (int) Math.Round(Conversion.Val(Strings.Mid(cc.game.Data.SFTypeObj[isfType1].SFTypeVar[8].ToString(), 4, 1)));
            if (num6 > 0)
            {
              int isfType2 = cc.IList[attnr].ISFType;
              int num7 = cc.game.Data.SFTypeObj[isfType2].AttackPower[cc.game.Data.SFTypeObj[isfType1].UnitGroup];
              if (cc.game.Data.SFTypeObj[isfType1].HitPoints[cc.game.Data.SFTypeObj[isfType2].UnitGroup] > num7 & DrawMod.RandyNumber.Next(0, 100) < 50 + num6 * 10)
              {
                s9 += "Amorphous feat of critter negates the attack.";
                attval = 0.0f;
              }
            }
          }
        }
      }
      int num8 = 0;
      int num9 = -1;
      int num10 = 1;
      do
      {
        int index2 = -1;
        int index3 = -1;
        if (num10 == 1)
        {
          index2 = attnr;
          index3 = defnr;
        }
        if (num10 == 2)
        {
          index2 = defnr;
          index3 = attnr;
        }
        if (!Information.IsNothing((object) cc.IList[index2].IunitFeat))
        {
          int counter = cc.IList[index2].IunitFeat.Counter;
          for (int index4 = 0; index4 <= counter; index4 += 1)
          {
            if (cc.IList[index2].IunitFeat.Id[index4] > 0 && cc.IList[cc.FindISlot(cc.IList[index2].IunitFeat.Data1[index4])].IKilled == 0 & cc.IList[cc.FindISlot(cc.IList[index2].IunitFeat.Data1[index4])].IRetreated == 0 & cc.IList[cc.FindISlot(cc.IList[index2].IunitFeat.Data1[index4])].IRetreat == 0)
            {
              int idValue = cc.IList[index2].IunitFeat.Id[index4];
              data: String = game.Data.StringListObj[this.slotUnitFeats].GetData(0, idValue, 2);
              int length = game.Data.StringListObj[this.slotBehaviour].Length;
              for (int index5 = 0; index5 <= length; index5 += 1)
              {
                int num11 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 0]));
                if ((int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 1])) == idValue)
                {
                  int num12 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 3]));
                  int num13 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 4]));
                  int num14 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 5]));
                  int num15 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 6]));
                  int num16 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 7]));
                  int index6;
                  str1: String = game.Data.StringListObj[this.slotBehaviour].Data[index5, index6];
                  int maxValue = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 8]));
                  int num17 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index5, 9]));
                  bool flag2 = false;
                  if (cc.CombatType == 1 & num12 == 1)
                    flag2 = true;
                  if (cc.CombatType == 3 & num13 == 1)
                    flag2 = true;
                  if (num13 == 1 & cc.game.Data.SFTypeObj[cc.IList[index2].ISFType].ArtRange > 0)
                    flag2 = true;
                  if (!(num14 == 1 | num14 == 3))
                    flag2 = false;
                  if (num15 > -1 & num15 != game.Data.SFTypeObj[cc.IList[index3].ISFType].UnitGroup)
                    flag2 = false;
                  if (flag2)
                  {
                    if (modNr == 12)
                    {
                      if (num11 == 2 && index2 == defnr)
                      {
                        s9 = s9 + "Defenders " + data + " gives " + num16.ToString() + "% chance to foil our attack. ";
                        if (DrawMod.RandyNumber.Next(0, 100) > num16)
                        {
                          s9 += "Succes!";
                          attval = 0.0f;
                        }
                        else
                          s9 += "Failed.";
                      }
                      if (num11 == 16 && index2 == attnr)
                      {
                        int num18 = (int) Math.Round((double) (cc.IList[defnr].IEntrench * num16) / 100.0);
                        Individual[] ilist = cc.IList;
                        Individual[] individualArray = ilist;
                        int index7 = defnr;
                        int index8 = index7;
                        individualArray[index8].IEntrench = ilist[index7].IEntrench - num18;
                        s9 = s9 + data + " diminished targets entrenchment with " + num18.ToString() + ".";
                      }
                      if (num11 == 33 && index2 == attnr & cc.IList[attnr].IAttacker < 1 & maxValue >= cc.CombatRound & cc.CombatRound <= num17)
                      {
                        int num19 = num16;
                        attval += (float) num19;
                        s9 = s9 + data + " adds " + num19.ToString() + " attack points.";
                      }
                      if (num11 == 7 && index2 == defnr)
                      {
                        int num20 = (int) Math.Round((double) attval * (double) num16 / 100.0);
                        attval -= (float) num20;
                        s9 = s9 + "Defenders " + data + " diminished attackers attack with " + num16.ToString() + "%.";
                      }
                      if (num11 == 23 && index2 == attnr)
                      {
                        s9 = s9 + data + " has " + num16.ToString() + "% chance to make a succesfull attack. ";
                        if (DrawMod.RandyNumber.Next(0, 100) < num16)
                        {
                          s9 += "Succes. ";
                          int num21 = DrawMod.RandyNumber.Next(0, maxValue);
                          s9 = s9 + " Did " + num21.ToString() + " points of attack dammage.";
                          attval += (float) num21;
                        }
                        else
                          s9 += "Failure. ";
                        if (num17 > 0 && DrawMod.RandyNumber.Next(0, 100) < num17)
                        {
                          s9 = s9 + " The " + data + " was destroyed in the process.";
                          cc.IList[attnr].IunitFeat.Id[index4] = 0;
                          cc.IList[attnr].IunitFeatDeadRound = cc.CombatRound;
                        }
                      }
                      if (num11 == 13 && index2 == attnr & cc.IList[attnr].AttackCount < 1 & !isCounterAttack)
                      {
                        cc.AddXp(attnr, num16);
                        s9 = s9 + " The " + data + " provided 10 experience gain chances.";
                      }
                      if (num11 == 25 && index2 == attnr && num17 < 1 | num17 <= cc.IList[attnr].IMor)
                      {
                        if (num16 > 0)
                        {
                          int num22 = (int) Math.Round((double) attval * (double) num16 / 100.0);
                          attval += (float) num22;
                          s9 = data + " increased our attack with " + num16.ToString() + "%. ";
                        }
                        if (maxValue > 0)
                        {
                          int num23 = maxValue;
                          attval += (float) num23;
                          s9 = s9 + data + " increased our attack with +" + maxValue.ToString() + " points.";
                        }
                      }
                      if (num11 == 34 && index2 == attnr && maxValue >= cc.CombatRound && game.Data.SFTypeObj[cc.IList[defnr].ISFType].SFTypeVar[42] < num17 && num16 > 0)
                      {
                        int num24 = num16;
                        attval += (float) num24;
                        s9 = data + " increased our attack with +" + num16.ToString() + " points.";
                      }
                      if (num11 == 15 && index2 == attnr)
                      {
                        int num25 = (int) Math.Round((double) (game.Data.SFObj[cc.IList[attnr].ISFNr].Rdn * num16) / 100.0);
                        int num26 = num25 - cc.IList[attnr].IRdn;
                        if (cc.IList[attnr].IRdn < num25)
                          cc.IList[attnr].IRdn = num25;
                        if (num26 > 0)
                          s9 = data + " increased our readiness with " + num26.ToString() + "points back to " + num16.ToString() + "% of original readiness.";
                      }
                    }
                    else if (modNr != 12 && num11 == 12 & index2 == attnr)
                    {
                      str2: String = num16 <= 0 ? "on all skills." : "on skill '" + game.Data.StringListObj[this.slotSkillTypes].GetData(0, num16, 1) + "'";
                      s9 = s9 + data + " gives a skill modification of " + maxValue.ToString() + " points " + str2;
                      num9 = num16;
                      num8 = maxValue;
                    }
                  }
                }
              }
            }
          }
        }
        num10 += 1;
      }
      while (num10 <= 2);
      int index9 = -1;
      if (num2 > -1)
        index9 = game.HandyFunctionsObj.GetHistoricalUnitByID(num2);
      int characterId1 = game.EventRelatedObj.Helper_GetCharacterId(id1, 3, num2, -1, this.slotChar);
      int characterId2 = game.EventRelatedObj.Helper_GetCharacterId(id1, 4, jobSpecificId, -1, this.slotChar);
      if (characterId1 > 0 & game.HandyFunctionsObj.Gethqpow(cc.IList[attnr].IUnr) > DrawMod.RandyNumber.Next(0, 100))
      {
        float num27 = attval;
        int tdata2 = 0;
        if (this.airEnabled)
        {
          if (modNr == 18 & game.Data.SFTypeObj[cc.IList[attnr].ISFType].Theater == 2 & game.Data.SFTypeObj[cc.IList[defnr].ISFType].Theater == 2)
          {
            int num28 = this.CachedSkillRoll(game, characterId1, 51);
            if (51 == num9 | num9 == -1)
              num28 += num8;
            this.SL.AddWeight(characterId1, 1, 51, CheckData1Existence: true);
            if (num28 > 100)
              attval += (float) ((double) attval * (double) (num28 - 100) / 100.0) * this.SKILLEFFECT;
            tdata2 = 51;
          }
          if (cc.IList[attnr].IAttacker == 0 && modNr == 19 & game.Data.SFTypeObj[cc.IList[attnr].ISFType].Theater == 2 & game.Data.SFTypeObj[cc.IList[defnr].ISFType].Theater == 2)
          {
            int num29 = this.CachedSkillRoll(game, characterId1, 52);
            if (52 == num9 | num9 == -1)
              num29 += num8;
            this.SL.AddWeight(characterId1, 1, 52, CheckData1Existence: true);
            if (num29 > 100)
              attval += (float) ((double) attval * (double) (num29 - 100) / 100.0) * this.SKILLEFFECT;
            tdata2 = 52;
          }
          if (cc.IList[attnr].IAttacker == 1 & cc.CombatType2 != 16 && modNr == 20 & game.Data.SFTypeObj[cc.IList[attnr].ISFType].Theater == 2 & game.Data.SFTypeObj[cc.IList[defnr].ISFType].Theater == 2)
          {
            int num30 = this.CachedSkillRoll(game, characterId1, 53);
            if (53 == num9 | num9 == -1)
              num30 += num8;
            this.SL.AddWeight(characterId1, 1, 53, CheckData1Existence: true);
            if (num30 > 100)
              attval += (float) ((double) attval * (double) (num30 - 100) / 100.0) * this.SKILLEFFECT;
            tdata2 = 53;
          }
          if (modNr == 21 & game.Data.SFTypeObj[cc.IList[attnr].ISFType].Theater == 2 & game.Data.SFTypeObj[cc.IList[defnr].ISFType].Theater < 2)
          {
            int num31 = this.CachedSkillRoll(game, characterId1, 54);
            if (54 == num9 | num9 == -1)
              num31 += num8;
            this.SL.AddWeight(characterId1, 1, 54, CheckData1Existence: true);
            if (num31 > 100)
              attval += (float) ((double) attval * (double) (num31 - 100) / 100.0) * this.SKILLEFFECT;
            tdata2 = 54;
          }
          if (modNr == 22 & game.Data.SFTypeObj[cc.IList[attnr].ISFType].Theater < 2 & game.Data.SFTypeObj[cc.IList[defnr].ISFType].Theater == 2)
          {
            int num32 = this.CachedSkillRoll(game, characterId1, 56);
            if (56 == num9 | num9 == -1)
              num32 += num8;
            this.SL.AddWeight(characterId1, 1, 56, CheckData1Existence: true);
            if (num32 > 100)
              attval += (float) ((double) attval * (double) (num32 - 100) / 100.0) * this.SKILLEFFECT;
            tdata2 = 56;
          }
        }
        if (game.Data.SFTypeObj[cc.IList[attnr].ISFType].Theater < 2)
        {
          if (modNr == 8)
          {
            int num33 = this.CachedSkillRoll(game, characterId1, 24);
            if (24 == num9 | num9 == -1)
              num33 += num8;
            this.SL.AddWeight(characterId1, 1, 24, CheckData1Existence: true);
            if (num33 > 100)
              attval += (float) ((double) attval * (double) (num33 - 100) / 100.0) * this.SKILLEFFECT;
            tdata2 = 24;
          }
          if (modNr == 1 & unitGroup1 == 3 & game.Data.SFTypeObj[cc.IList[attnr].ISFType].ArtRange < 1)
          {
            int num34 = this.CachedSkillRoll(game, characterId1, 31);
            if (31 == num9 | num9 == -1)
              num34 += num8;
            this.SL.AddWeight(characterId1, 1, 31, CheckData1Existence: true);
            if (num34 > 100)
              attval += (float) ((double) attval * (double) (num34 - 100) / 100.0) * this.SKILLEFFECT;
            tdata2 = 31;
          }
          if (modNr == 2 & (unitGroup1 == 1 | unitGroup1 == 3 & game.Data.SFTypeObj[cc.IList[attnr].ISFType].ArtRange > 0))
          {
            int num35 = this.CachedSkillRoll(game, characterId1, 32);
            if (32 == num9 | num9 == -1)
              num35 += num8;
            this.SL.AddWeight(characterId1, 1, 32, CheckData1Existence: true);
            if (num35 > 100)
              attval += (float) ((double) attval * (double) (num35 - 100) / 100.0) * this.SKILLEFFECT;
            tdata2 = 32;
          }
          if (modNr == 13 & cc.IList[attnr].IAttacker == 0)
          {
            int num36 = this.CachedSkillRoll(game, characterId1, 4);
            if (4 == num9 | num9 == -1)
              num36 += num8;
            this.SL.AddWeight(characterId1, 1, 4, CheckData1Existence: true);
            int num37 = num36 - 100;
            if (num37 > 0)
              attval += (float) (int) Math.Round((double) attval * ((double) cc.IList[attnr].IEntrench / 100.0) * ((double) num37 / 100.0));
            tdata2 = 4;
          }
          if (modNr == 3 & unitGroup1 == 0)
          {
            int num38 = this.CachedSkillRoll(game, characterId1, 33);
            if (33 == num9 | num9 == -1)
              num38 += num8;
            this.SL.AddWeight(characterId1, 1, 33, CheckData1Existence: true);
            if (num38 > 100)
              attval += (float) ((double) attval * (double) (num38 - 100) / 100.0) * this.SKILLEFFECT;
            tdata2 = 33;
          }
          if (modNr == 6 & cc.IList[attnr].IAttacker == 1)
          {
            int num39 = this.CachedSkillRoll(game, characterId1, 36);
            if (36 == num9 | num9 == -1)
              num39 += num8;
            this.SL.AddWeight(characterId1, 1, 36, CheckData1Existence: true);
            if (num39 > 100)
              attval += (float) ((double) attval * (double) (num39 - 100) / 100.0) * this.SKILLEFFECT;
            tdata2 = 36;
          }
          if (modNr == 5 & cc.IList[attnr].IAttacker == 1)
          {
            int num40 = this.CachedSkillRoll(game, characterId1, 23);
            if (23 == num9 | num9 == -1)
              num40 += num8;
            if (num40 > 100)
            {
              int num41 = num40 - 100;
              this.SL.AddWeight(characterId1, 1, 23, CheckData1Existence: true);
              if (cc.IList[defnr].IEntrench > 0)
              {
                int num42 = (int) Math.Round((double) (cc.IList[defnr].IEntrench * num41) / 200.0);
                cc.IList[defnr].IEntrench -= num42;
                if (0 > cc.IList[defnr].IEntrench)
                  cc.IList[defnr].IEntrench = 0;
              }
            }
            tdata2 = 23;
          }
        }
        int tweight = (int) Math.Round((double) ((float) (((double) attval - (double) num27) * 100.0) / num27));
        if (tweight > 0)
          tweight = tweight;
        if (tdata2 > 0)
        {
          int nr = this.logLeaderBonus.FindNr(characterId1, tdata2: tdata2);
          if (nr <= -1)
          {
            this.logLeaderBonus.AddWeight(characterId1, tweight, 1, tdata2, CheckExistence: false);
          }
          else
          {
            int[] weight = this.logLeaderBonus.Weight;
            int[] numArray1 = weight;
            int index10 = nr;
            int index11 = index10;
            int num43 = weight[index10] + tweight;
            numArray1[index11] = num43;
            int[] data1 = this.logLeaderBonus.Data1;
            int[] numArray2 = data1;
            int index12 = nr;
            int index13 = index12;
            int num44 = data1[index12] + 1;
            numArray2[index13] = num44;
          }
        }
      }
      if (characterId2 > 0)
      {
        float num45 = attval;
        int tdata2 = 0;
        if (modNr == 9)
        {
          int num46 = this.CachedSkillRoll(game, characterId2, 18);
          if (18 == num9 | num9 == -1)
            num46 += num8;
          this.SL.AddWeight(characterId2, 1, 18, CheckData1Existence: true);
          if (num46 > 100)
            attval += (float) ((double) attval * (double) (num46 - 100) / 100.0) * this.SKILLEFFECT;
          tdata2 = 18;
        }
        int tweight = (int) Math.Round((double) ((float) (((double) attval - (double) num45) * 100.0) / num45));
        if (tdata2 > 0)
        {
          int nr = this.logLeaderBonus.FindNr(characterId2, tdata2: tdata2);
          if (nr <= -1)
          {
            this.logLeaderBonus.AddWeight(characterId2, tweight, 1, tdata2, CheckExistence: false);
          }
          else
          {
            int[] weight = this.logLeaderBonus.Weight;
            int[] numArray3 = weight;
            int index14 = nr;
            int index15 = index14;
            int num47 = weight[index14] + tweight;
            numArray3[index15] = num47;
            int[] data1 = this.logLeaderBonus.Data1;
            int[] numArray4 = data1;
            int index16 = nr;
            int index17 = index16;
            int num48 = data1[index16] + 1;
            numArray4[index17] = num48;
          }
        }
      }
      if (modNr == 10)
      {
        float num49 = attval;
        int iunr = cc.IList[attnr].IUnr;
        if (index9 > -1)
        {
          if (cc.AttackerRegime == game.Data.UnitObj[iunr].Regime)
          {
            int unitGroup2 = game.Data.SFTypeObj[cc.IList[attnr].ISFType].UnitGroup;
            if (unitGroup2 == 0)
            {
              int num50 = game.Data.HistoricalUnitObj[index9].GiveHisVarValue(22);
              attval *= (float) (100 + num50) / 100f;
            }
            else if (unitGroup2 == 1 | unitGroup2 == 6)
            {
              int num51 = game.Data.HistoricalUnitObj[index9].GiveHisVarValue(23);
              attval *= (float) (100 + num51) / 100f;
            }
            else if (unitGroup2 == 2 | unitGroup2 == 3)
            {
              int num52 = game.Data.HistoricalUnitObj[index9].GiveHisVarValue(24);
              attval *= (float) (100 + num52) / 100f;
            }
          }
          if (cc.DefenderRegime == game.Data.UnitObj[iunr].Regime)
          {
            int unitGroup3 = game.Data.SFTypeObj[cc.IList[attnr].ISFType].UnitGroup;
            if (unitGroup3 == 0)
            {
              int num53 = game.Data.HistoricalUnitObj[index9].GiveHisVarValue(25);
              attval *= (float) (100 + num53) / 100f;
            }
            else if (unitGroup3 == 1 | unitGroup3 == 6)
            {
              int num54 = game.Data.HistoricalUnitObj[index9].GiveHisVarValue(26);
              attval *= (float) (100 + num54) / 100f;
            }
            else if (unitGroup3 == 2 | unitGroup3 == 3)
            {
              int num55 = game.Data.HistoricalUnitObj[index9].GiveHisVarValue(27);
              attval *= (float) (100 + num55) / 100f;
            }
          }
          int num56 = game.Data.HistoricalUnitObj[index9].GiveHisVarValue(40);
          if (num56 == 1 & cc.IList[attnr].IAttacker == 1)
            attval *= cc.ConcentricBonus;
          if (num56 == 2)
          {
            int num57 = cc.IList[attnr].IMor - cc.IList[defnr].IMor;
            if (num57 > 0)
              attval *= (float) (100 + num57) / 100f;
          }
          if ((double) num49 > 0.0)
          {
            int tweight = (int) Math.Round((double) ((float) (((double) attval - (double) num49) * 100.0) / num49));
            int nr = this.otherBonus.FindNr(cc.IList[attnr].IAttacker, tdata2: 1);
            if (nr <= -1)
            {
              this.otherBonus.AddWeight(cc.IList[attnr].IAttacker, tweight, 1, 1, CheckExistence: false);
            }
            else
            {
              int[] weight = this.otherBonus.Weight;
              int[] numArray5 = weight;
              int index18 = nr;
              int index19 = index18;
              int num58 = weight[index18] + tweight;
              numArray5[index19] = num58;
              int[] data1 = this.otherBonus.Data1;
              int[] numArray6 = data1;
              int index20 = nr;
              int index21 = index20;
              int num59 = data1[index20] + 1;
              numArray6[index21] = num59;
            }
          }
        }
      }
      if (modNr == 11)
      {
        float num60 = attval;
        int regime = game.Data.UnitObj[cc.IList[attnr].IUnr].Regime;
        int id2 = game.Data.RegimeObj[regime].id;
        int num61 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotRegimeKey].GetData2(0, id2, 1, "combatBonus", 2)));
        attval += (float) ((double) attval * (double) num61 / 100.0);
        if ((double) num60 > 0.0)
        {
          int tweight = (int) Math.Round((double) ((float) (((double) attval - (double) num60) * 100.0) / num60));
          int nr = this.otherBonus.FindNr(cc.IList[attnr].IAttacker, tdata2: 2);
          if (nr <= -1)
          {
            this.otherBonus.AddWeight(cc.IList[attnr].IAttacker, tweight, 1, 2, CheckExistence: false);
          }
          else
          {
            int[] weight = this.otherBonus.Weight;
            int[] numArray7 = weight;
            int index22 = nr;
            int index23 = index22;
            int num62 = weight[index22] + tweight;
            numArray7[index23] = num62;
            int[] data1 = this.otherBonus.Data1;
            int[] numArray8 = data1;
            int index24 = nr;
            int index25 = index24;
            int num63 = data1[index24] + 1;
            numArray8[index25] = num63;
          }
        }
      }
      if (modNr == 16 && game.Data.SFTypeObj[cc.IList[attnr].ISFType].Theater == 2 & game.Data.SFTypeObj[cc.IList[defnr].ISFType].Theater == 2)
      {
        float num64 = attval;
        int regime = game.Data.UnitObj[cc.IList[attnr].IUnr].Regime;
        int id3 = game.Data.RegimeObj[regime].id;
        int num65 = game.Data.SFTypeObj[cc.IList[attnr].ISFType].SFTypeVar[15];
        int num66 = game.Data.SFTypeObj[cc.IList[attnr].ISFType].SFTypeVar[16];
        int num67 = 100;
        if (cc.CombatRound == 1)
          num67 = num65;
        if (cc.CombatRound == 2)
          num67 = num66;
        if (num67 < 0)
          num67 = 0;
        attval = (float) ((double) attval * (double) num67 / 100.0);
        if ((double) num64 > 0.0 & num67 != 0)
        {
          int tweight = (int) Math.Round((double) ((float) (((double) attval - (double) num64) * 100.0) / num64));
          int nr = this.otherBonus.FindNr(cc.IList[attnr].IAttacker, tdata2: 2);
          if (nr <= -1)
          {
            this.otherBonus.AddWeight(cc.IList[attnr].IAttacker, tweight, 1, 2, CheckExistence: false);
          }
          else
          {
            int[] weight = this.otherBonus.Weight;
            int[] numArray9 = weight;
            int index26 = nr;
            int index27 = index26;
            int num68 = weight[index26] + tweight;
            numArray9[index27] = num68;
            int[] data1 = this.otherBonus.Data1;
            int[] numArray10 = data1;
            int index28 = nr;
            int index29 = index28;
            int num69 = data1[index28] + 1;
            numArray10[index29] = num69;
          }
        }
      }
      if (modNr == 17 && game.Data.SFTypeObj[cc.IList[attnr].ISFType].Theater == 2 & game.Data.SFTypeObj[cc.IList[defnr].ISFType].Theater == 2)
      {
        float num70 = attval;
        int regime = game.Data.UnitObj[cc.IList[attnr].IUnr].Regime;
        int id4 = game.Data.RegimeObj[regime].id;
        float d = (float) game.Data.SFTypeObj[cc.IList[attnr].ISFType].SFTypeVar[13] / (float) game.Data.SFTypeObj[cc.IList[defnr].ISFType].SFTypeVar[13];
        if ((double) d > 1.0)
          d = (float) Math.Sqrt((double) d);
        if (cc.CombatRound == 1)
          d = (float) Math.Sqrt(Math.Sqrt((double) d));
        if (cc.CombatRound == 2)
          d = (float) Math.Sqrt((double) d);
        attval *= d;
        if ((double) num70 > 0.0 & (double) d != 0.0)
        {
          int tweight = (int) Math.Round((double) ((float) (((double) attval - (double) num70) * 100.0) / num70));
          int nr = this.otherBonus.FindNr(cc.IList[attnr].IAttacker, tdata2: 2);
          if (nr <= -1)
          {
            this.otherBonus.AddWeight(cc.IList[attnr].IAttacker, tweight, 1, 2, CheckExistence: false);
          }
          else
          {
            int[] weight = this.otherBonus.Weight;
            int[] numArray11 = weight;
            int index30 = nr;
            int index31 = index30;
            int num71 = weight[index30] + tweight;
            numArray11[index31] = num71;
            int[] data1 = this.otherBonus.Data1;
            int[] numArray12 = data1;
            int index32 = nr;
            int index33 = index32;
            int num72 = data1[index32] + 1;
            numArray12[index33] = num72;
          }
        }
      }
      if (modNr == 14)
      {
        float num73 = attval;
        int num74 = game.Data.SFTypeObj[cc.IList[attnr].ISFType].SFTypeVar[37];
        int num75 = game.Data.SFTypeObj[cc.IList[defnr].ISFType].SFTypeVar[38];
        int num76 = 100;
        if (num74 == 0)
        {
          if (num75 == 1)
            num76 = 66;
          if (num75 == 2)
            num76 = 33;
          if (num75 == 3)
            num76 = 66;
        }
        if (num74 == 1)
        {
          if (num75 == 3)
            num76 = 150;
          if (num75 == 4)
            num76 = 50;
        }
        if (num74 == 2)
        {
          if (num75 == 3)
            num76 = 50;
          if (num75 == 4)
            num76 = 33;
        }
        if (num74 == 3)
        {
          if (num75 == 3)
            num76 = 25;
          if (num75 == 4)
            num76 = 50;
        }
        if (num74 == 4)
        {
          if (num75 == 3)
            num76 = 66;
          if (num75 == 4)
            num76 = 75;
        }
        if (num74 == 5)
        {
          if (num75 == 1)
            num76 = 50;
          if (num75 == 2)
            num76 = 75;
        }
        attval = (float) ((double) attval * (double) num76 / 100.0);
        if ((double) num73 > 0.0)
        {
          int tweight = (int) Math.Round((double) ((float) (((double) attval - (double) num73) * 100.0) / num73));
          int nr = this.otherBonus.FindNr(cc.IList[attnr].IAttacker, tdata2: 4);
          if (nr <= -1)
          {
            this.otherBonus.AddWeight(cc.IList[attnr].IAttacker, tweight, 1, 4, CheckExistence: false);
          }
          else
          {
            int[] weight = this.otherBonus.Weight;
            int[] numArray13 = weight;
            int index34 = nr;
            int index35 = index34;
            int num77 = weight[index34] + tweight;
            numArray13[index35] = num77;
            int[] data1 = this.otherBonus.Data1;
            int[] numArray14 = data1;
            int index36 = nr;
            int index37 = index36;
            int num78 = data1[index36] + 1;
            numArray14[index37] = num78;
          }
        }
      }
      if (modNr == 15)
      {
        float num79 = attval;
        int num80 = game.Data.SFTypeObj[cc.IList[attnr].ISFType].SFTypeVar[37];
        int num81 = game.Data.SFTypeObj[cc.IList[defnr].ISFType].SFTypeVar[38];
        int idValue1 = game.Data.SFTypeObj[cc.IList[attnr].ISFType].SFTypeVar[41];
        if (this.airEnabled && idValue1 < 1 | game.Data.SFTypeObj[cc.IList[defnr].ISFType].Theater == 2 & game.Data.SFTypeObj[cc.IList[attnr].ISFType].SFTypeVar[20] > 0)
          idValue1 = game.Data.SFTypeObj[cc.IList[attnr].ISFType].SFTypeVar[20];
        int idValue2 = game.Data.SFTypeObj[cc.IList[defnr].ISFType].SFTypeVar[42];
        int num82 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotMM].GetData(0, idValue1, 1)));
        if (num82 < 1)
          num82 = 1;
        if (game.Data.SFTypeObj[cc.IList[attnr].ISFType].ArtRange > 0)
          num82 = (int) Math.Round((double) num82 / 3.0);
        int num83 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotMM].GetData(0, idValue2, 1)));
        int num84 = 100;
        if (num80 != 6 & num80 != 0)
        {
          if (num81 != 4)
          {
            float num85 = 1f;
            if (num83 > 0)
              num85 = (float) num82 / (float) num83;
            if ((double) num85 > 10.0)
              num85 = 10f;
            if ((double) num85 < 1.0)
              num85 += (float) ((1.0 - (double) num85) * 0.1);
            if ((double) num85 > 1.0)
              num85 = 1f;
            num84 = (int) Math.Round((double) (100f * num85));
          }
        }
        attval = (float) ((double) attval * (double) num84 / 100.0);
        if ((double) num79 > 0.0)
        {
          int tweight = (int) Math.Round((double) ((float) (((double) attval - (double) num79) * 100.0) / num79));
          int nr = this.otherBonus.FindNr(cc.IList[attnr].IAttacker, tdata2: 5);
          if (nr <= -1)
          {
            this.otherBonus.AddWeight(cc.IList[attnr].IAttacker, tweight, 1, 5, CheckExistence: false);
          }
          else
          {
            int[] weight = this.otherBonus.Weight;
            int[] numArray15 = weight;
            int index38 = nr;
            int index39 = index38;
            int num86 = weight[index38] + tweight;
            numArray15[index39] = num86;
            int[] data1 = this.otherBonus.Data1;
            int[] numArray16 = data1;
            int index40 = nr;
            int index41 = index40;
            int num87 = data1[index40] + 1;
            numArray16[index41] = num87;
          }
        }
      }
      return attval;
    }

    pub string GetUnitFeatName(GameClass game, int id)
    {
      unitFeatName: String = game.Data.StringListObj[this.slotUnitFeats].GetData(0, id, 2);
      if (unitFeatName.Length < 1)
        unitFeatName = "Unknown Unit Feat";
      return unitFeatName;
    }

    pub float IndividualCombatCall_DefValModder(
      int modNr,
      ref CombatClass cc,
      GameClass game,
      int attnr2,
      int defnr,
      bool isCounterAttack,
      float defval,
      ref string s9)
    {
      int num1 = -1;
      int num2 = -1;
      int jobSpecificId = -1;
      int unitGroup1 = game.Data.SFTypeObj[cc.IList[defnr].ISFType].UnitGroup;
      int index1 = cc.IList[defnr].IUnr;
      int historical1 = game.Data.UnitObj[index1].Historical;
      int id = game.Data.RegimeObj[game.Data.UnitObj[cc.IList[defnr].IUnr].Regime].id;
      if (historical1 > -1)
        num1 = game.Data.HistoricalUnitObj[historical1].ID;
      bool flag1 = false;
      if (game.Data.HistoricalUnitObj[historical1].GiveHisVarValue(11) > 0)
        flag1 = true;
      if ((int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotRegimes].GetData(0, id, 1))) > 1)
        flag1 = true;
      int num3 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotRegimes].GetData(0, id, 1)));
      for (; index1 > -1; index1 = game.Data.UnitObj[index1].HQ)
      {
        int historical2 = game.Data.UnitObj[index1].Historical;
        if (game.Data.UnitObj[index1].IsHQ)
        {
          if (game.Data.HistoricalUnitObj[historical2].Type == 8)
            jobSpecificId = game.Data.HistoricalUnitObj[historical2].ID;
          else if (game.Data.HistoricalUnitObj[historical2].Type >= 5)
            num2 = game.Data.HistoricalUnitObj[historical2].ID;
        }
      }
      int index2 = -1;
      if (num2 > -1)
        index2 = game.HandyFunctionsObj.GetHistoricalUnitByID(num2);
      int characterId1 = game.EventRelatedObj.Helper_GetCharacterId(id, 3, num2, -1, this.slotChar);
      int characterId2 = game.EventRelatedObj.Helper_GetCharacterId(id, 4, jobSpecificId, -1, this.slotChar);
      int num4 = 0;
      int num5 = -1;
      int num6 = 1;
      int index3;
      int num7;
      do
      {
        int index4 = -1;
        int index5 = -1;
        if (num6 == 1)
        {
          index4 = index3;
          index5 = defnr;
        }
        if (num6 == 2)
        {
          index4 = defnr;
          index5 = index3;
        }
        if (!Information.IsNothing((object) cc.IList[index4].IunitFeat))
        {
          int counter = cc.IList[index4].IunitFeat.Counter;
          for (int index6 = 0; index6 <= counter; index6 += 1)
          {
            if (cc.IList[index4].IunitFeat.Id[index6] > 0 && cc.IList[cc.FindISlot(cc.IList[index4].IunitFeat.Data1[index6])].IKilled == 0 & cc.IList[cc.FindISlot(cc.IList[index4].IunitFeat.Data1[index6])].IRetreated == 0 & cc.IList[cc.FindISlot(cc.IList[index4].IunitFeat.Data1[index6])].IRetreat == 0)
            {
              int idValue1 = cc.IList[index4].IunitFeat.Id[index6];
              data: String = game.Data.StringListObj[this.slotUnitFeats].GetData(0, idValue1, 2);
              int length = game.Data.StringListObj[this.slotBehaviour].Length;
              for (int index7 = 0; index7 <= length; index7 += 1)
              {
                int num8 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index7, 0]));
                if ((int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index7, 1])) == idValue1)
                {
                  int num9 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index7, 3]));
                  int num10 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index7, 4]));
                  int num11 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index7, 5]));
                  int num12 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index7, 6]));
                  int idValue2 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index7, 7]));
                  int index8;
                  str1: String = game.Data.StringListObj[this.slotBehaviour].Data[index7, index8];
                  int num13 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index7, 8]));
                  int num14 = (int) Math.Round(Conversion.Val(game.Data.StringListObj[this.slotBehaviour].Data[index7, 9]));
                  bool flag2 = false;
                  if (cc.CombatType == 1 & num9 == 1)
                    flag2 = true;
                  if (cc.CombatType == 3 & num10 == 1)
                    flag2 = true;
                  if (num10 == 1 & cc.game.Data.SFTypeObj[cc.IList[index4].ISFType].ArtRange > 0)
                    flag2 = true;
                  if (!(num11 == 3 | num11 == 2))
                    flag2 = false;
                  if (num12 > -1 & num12 != game.Data.SFTypeObj[cc.IList[index5].ISFType].UnitGroup)
                    flag2 = false;
                  if (flag2)
                  {
                    if (modNr == 12)
                    {
                      if (num8 == 11 && index4 == defnr)
                      {
                        s9 = "";
                        if (idValue2 > 0)
                        {
                          int num15 = (int) Math.Round((double) defval * (double) idValue2 / 100.0);
                          defval += (float) num15;
                          s9 = data + " provided " + idValue2.ToString() + "% extra defensive points. ";
                        }
                        if (num13 > 0)
                        {
                          int num16 = num13;
                          defval += (float) num16;
                          s9 = s9 + data + " provided " + num13.ToString() + " extra defensive points.";
                        }
                      }
                      if (num8 == 37 && index4 == defnr)
                      {
                        s9 = "";
                        if (idValue2 > 0)
                        {
                          int ientrench = cc.IList[defnr].IEntrench;
                          num7 = (int) Math.Round((double) (ientrench * idValue2) / 100.0);
                          int num17 = (int) Math.Round((double) defval * (double) ientrench / 100.0);
                          defval += (float) num17;
                          s9 = data + " provided " + num17.ToString() + "% extra defensive points. ";
                        }
                      }
                      if (num8 == 15 && index4 == defnr)
                      {
                        int num18 = (int) Math.Round((double) (game.Data.SFObj[cc.IList[defnr].ISFNr].Rdn * idValue2) / 100.0);
                        int num19 = num18 - cc.IList[defnr].IRdn;
                        if (cc.IList[defnr].IRdn < num18)
                          cc.IList[defnr].IRdn = num18;
                        if (num19 > 0)
                          s9 = data + " increased our readiness with " + num19.ToString() + "points back to " + idValue2.ToString() + "% of original readiness.";
                      }
                    }
                    else if (modNr != 12 && num8 == 12 & index4 == defnr)
                    {
                      str2: String = idValue2 <= 0 ? "on all skills." : "on skill '" + game.Data.StringListObj[this.slotSkillTypes].GetData(0, idValue2, 1) + "'";
                      s9 = data + " gives a skill modification of " + num13.ToString() + " points " + str2;
                      num5 = idValue2;
                      num4 = num13;
                    }
                  }
                }
              }
            }
          }
        }
        num6 += 1;
      }
      while (num6 <= 2);
      if (characterId1 > 0 & game.HandyFunctionsObj.Gethqpow(cc.IList[defnr].IUnr) > DrawMod.RandyNumber.Next(0, 100))
      {
        float num20 = defval;
        int tdata2 = 0;
        if (game.Data.SFTypeObj[cc.IList[defnr].ISFType].Theater < 2)
        {
          if (modNr == 8)
          {
            int num21 = this.CachedSkillRoll(game, characterId1, 24);
            if (24 == num5 | num5 == -1)
              num21 += num4;
            this.SL.AddWeight(characterId1, 1, 24, CheckData1Existence: true);
            if (num21 > 100)
              defval += (float) ((double) defval * (double) (num21 - 100) / 100.0) * this.SKILLEFFECT;
            tdata2 = 24;
          }
          if (modNr == 1 & unitGroup1 == 3 & game.Data.SFTypeObj[cc.IList[defnr].ISFType].ArtRange < 1)
          {
            int num22 = this.CachedSkillRoll(game, characterId1, 31);
            if (31 == num5 | num5 == -1)
              num22 += num4;
            this.SL.AddWeight(characterId1, 1, 31, CheckData1Existence: true);
            if (num22 > 100)
              defval += (float) ((double) defval * (double) (num22 - 100) / 100.0) * this.SKILLEFFECT;
            tdata2 = 31;
          }
          if (modNr == 2 & (unitGroup1 == 1 | unitGroup1 == 3 & game.Data.SFTypeObj[cc.IList[defnr].ISFType].ArtRange > 0))
          {
            int num23 = this.CachedSkillRoll(game, characterId1, 32);
            if (32 == num5 | num5 == -1)
              num23 += num4;
            this.SL.AddWeight(characterId1, 1, 32, CheckData1Existence: true);
            if (num23 > 100)
              defval += (float) ((double) defval * (double) (num23 - 100) / 100.0) * this.SKILLEFFECT;
            tdata2 = 32;
          }
          if (modNr == 3 & unitGroup1 == 0)
          {
            int num24 = this.CachedSkillRoll(game, characterId1, 33);
            if (33 == num5 | num5 == -1)
              num24 += num4;
            this.SL.AddWeight(characterId1, 1, 33, CheckData1Existence: true);
            if (num24 > 100)
              defval += (float) ((double) defval * (double) (num24 - 100) / 100.0) * this.SKILLEFFECT;
            tdata2 = 33;
          }
          if (modNr == 7 & cc.IList[defnr].IAttacker == 0)
          {
            int num25 = this.CachedSkillRoll(game, characterId1, 37);
            if (37 == num5 | num5 == -1)
              num25 += num4;
            this.SL.AddWeight(characterId1, 1, 37, CheckData1Existence: true);
            if (num25 > 100)
              defval += (float) ((double) defval * (double) (num25 - 100) / 100.0) * this.SKILLEFFECT;
            tdata2 = 37;
          }
          if (modNr == 4 & cc.IList[defnr].IRetreat > 0)
          {
            int num26 = this.CachedSkillRoll(game, characterId1, 13);
            if (13 == num5 | num5 == -1)
              num26 += num4;
            if (num26 > 100)
            {
              this.SL.AddWeight(characterId1, 1, 13, CheckData1Existence: true);
              defval += defval * 3f;
            }
            tdata2 = 13;
          }
        }
        int tweight = (int) Math.Round((double) ((float) (((double) defval - (double) num20) * 100.0) / num20));
        if (tweight > 0)
          tweight = tweight;
        if (tdata2 > 0)
        {
          int nr = this.logLeaderBonusDef.FindNr(characterId1, tdata2: tdata2);
          if (nr <= -1)
          {
            this.logLeaderBonusDef.AddWeight(characterId1, tweight, 1, tdata2, CheckExistence: false);
          }
          else
          {
            int[] weight = this.logLeaderBonusDef.Weight;
            int[] numArray1 = weight;
            int index9 = nr;
            int index10 = index9;
            int num27 = weight[index9] + tweight;
            numArray1[index10] = num27;
            int[] data1 = this.logLeaderBonusDef.Data1;
            int[] numArray2 = data1;
            int index11 = nr;
            int index12 = index11;
            int num28 = data1[index11] + 1;
            numArray2[index12] = num28;
          }
        }
      }
      if (characterId2 > 0)
      {
        float num29 = defval;
        int tdata2 = 0;
        if (modNr == 9)
        {
          int num30 = this.CachedSkillRoll(game, characterId2, 18);
          if (18 == num5 | num5 == -1)
            num30 += num4;
          this.SL.AddWeight(characterId2, 1, 18, CheckData1Existence: true);
          if (num30 > 100)
            defval += (float) ((double) defval * (double) (num30 - 100) / 100.0) * this.SKILLEFFECT;
          tdata2 = 18;
        }
        int tweight = (int) Math.Round((double) ((float) (((double) defval - (double) num29) * 100.0) / num29));
        if (tdata2 > 0)
        {
          int nr = this.logLeaderBonusDef.FindNr(characterId2, tdata2: tdata2);
          if (nr <= -1)
          {
            this.logLeaderBonusDef.AddWeight(characterId2, tweight, 1, tdata2, CheckExistence: false);
          }
          else
          {
            int[] weight = this.logLeaderBonusDef.Weight;
            int[] numArray3 = weight;
            int index13 = nr;
            int index14 = index13;
            int num31 = weight[index13] + tweight;
            numArray3[index14] = num31;
            int[] data1 = this.logLeaderBonusDef.Data1;
            int[] numArray4 = data1;
            int index15 = nr;
            int index16 = index15;
            int num32 = data1[index15] + 1;
            numArray4[index16] = num32;
          }
        }
      }
      if (modNr == 10)
      {
        float num33 = defval;
        int iunr = cc.IList[defnr].IUnr;
        if (index2 > -1)
        {
          if (cc.AttackerRegime == game.Data.UnitObj[iunr].Regime)
          {
            int unitGroup2 = game.Data.SFTypeObj[cc.IList[defnr].ISFType].UnitGroup;
            if (unitGroup2 == 0)
              num7 = game.Data.HistoricalUnitObj[index2].GiveHisVarValue(22);
            else if (unitGroup2 == 1 | unitGroup2 == 6)
              num7 = game.Data.HistoricalUnitObj[index2].GiveHisVarValue(23);
            else if (unitGroup2 == 2 | unitGroup2 == 3)
              num7 = game.Data.HistoricalUnitObj[index2].GiveHisVarValue(24);
          }
          if (cc.DefenderRegime == game.Data.UnitObj[iunr].Regime)
          {
            int unitGroup3 = game.Data.SFTypeObj[cc.IList[defnr].ISFType].UnitGroup;
            if (unitGroup3 == 0)
              num7 = game.Data.HistoricalUnitObj[index2].GiveHisVarValue(25);
            else if (unitGroup3 == 1 | unitGroup3 == 6)
              num7 = game.Data.HistoricalUnitObj[index2].GiveHisVarValue(26);
            else if (unitGroup3 == 2 | unitGroup3 == 3)
              num7 = game.Data.HistoricalUnitObj[index2].GiveHisVarValue(27);
          }
          int num34 = game.Data.HistoricalUnitObj[index2].GiveHisVarValue(40);
          if (num34 == 4 && DrawMod.RandyNumber.Next(0, 1000) < 200)
            defval = 0.0f;
          if (num34 == 3 & cc.IList[defnr].IRetreat == cc.CombatRound - 1 & cc.IList[defnr].IRetreat > 0 && DrawMod.RandyNumber.Next(0, 1000) < 50)
            defval = 0.0f;
          if (num34 == 5 & cc.IList[defnr].IRetreat == cc.CombatRound - 1 & cc.IList[defnr].IRetreat > 0 && DrawMod.RandyNumber.Next(0, 1000) < 750)
            defval = 0.0f;
          if (num34 == 6 & cc.IList[defnr].IRetreat == cc.CombatRound - 1 & cc.IList[defnr].IRetreat > 0 && DrawMod.RandyNumber.Next(0, 1000) < 500)
            defval = 0.0f;
          int tweight = (int) Math.Round((double) ((float) (((double) defval - (double) num33) * 100.0) / num33));
          int nr = this.otherBonusDef.FindNr(cc.IList[index3].IAttacker, tdata2: 1);
          if (nr <= -1)
          {
            this.otherBonusDef.AddWeight(cc.IList[index3].IAttacker, tweight, 1, 1, CheckExistence: false);
          }
          else
          {
            int[] weight = this.otherBonusDef.Weight;
            int[] numArray5 = weight;
            int index17 = nr;
            int index18 = index17;
            int num35 = weight[index17] + tweight;
            numArray5[index18] = num35;
            int[] data1 = this.otherBonusDef.Data1;
            int[] numArray6 = data1;
            int index19 = nr;
            int index20 = index19;
            int num36 = data1[index19] + 1;
            numArray6[index20] = num36;
          }
        }
      }
      return defval;
    }

    pub void UnitLost(ref CombatClass cc, GameClass game, int unr) => this.PersonalCombatRoll(ref cc, game, unr, -1, 75, "", true, false);

    pub int IndividualCombatCall_FirstAttackOfRound(
      ref CombatClass cc,
      GameClass game,
      int attnr,
      int defnr,
      ref string s9)
    {
      if (cc.previewMode)
        return 0;
      int isfType = cc.IList[attnr].ISFType;
      int num1 = game.Data.SFTypeObj[isfType].SFTypeVar[95];
      if ((double) cc.IList[attnr].ILisAmmoMod < 1.0)
        num1 = (int) Math.Round((double) ((float) num1 * cc.IList[attnr].ILisAmmoMod));
      if (num1 < 1)
        return 0;
      data: DataClass = game.Data;
      str: String = "rad";
      ref local: String = ref str;
      int libVar = data.FindLibVar(ref local, "SE_Data");
      int num2 = cc.TargetX - 4;
      int num3 = cc.TargetX + 4;
      for (int index1 = num2; index1 <= num3; index1 += 1)
      {
        int num4 = cc.TargetY - 4;
        int num5 = cc.TargetY + 4;
        for (int index2 = num4; index2 <= num5; index2 += 1)
        {
          int x2 = index1;
          int y2 = index2;
          if (x2 > game.Data.MapObj[0].MapWidth)
            x2 -= game.Data.MapObj[0].MapWidth + 1;
          if (x2 < 0)
            x2 = game.Data.MapObj[0].MapWidth + 1 + x2;
          if (y2 >= 0 & y2 <= game.Data.MapObj[0].MapHeight)
          {
            int num6 = game.HandyFunctionsObj.Distance(cc.TargetX, cc.TargetY, 0, x2, y2, 0, 5);
            int num7 = 0;
            if (num6 < 5)
            {
              if (num6 == 0)
                num7 = num1;
              if (num6 == 1)
                num7 = (int) Math.Round((double) num1 / 4.0);
              if (num6 == 2)
                num7 = (int) Math.Round((double) num1 / 16.0);
              if (num6 == 3)
                num7 = (int) Math.Round((double) num1 / 64.0);
              if (num6 == 4)
                num7 = (int) Math.Round((double) num1 / 256.0);
            }
            if (num7 > 0)
            {
              int hexLibVarValue = game.Data.MapObj[0].HexObj[x2, y2].GetHexLibVarValue(libVar);
              int num8 = hexLibVarValue + num7;
              int num9 = 0;
              if (hexLibVarValue <= 1000)
              {
                num9 = 1000 - hexLibVarValue;
                if (num7 < num9)
                  num9 = num7;
                num7 -= num9;
              }
              if (num8 > 1000)
                num7 = (int) Math.Round((double) num7 / 2.0);
              if (hexLibVarValue + num7 > 2000)
                num7 = (int) Math.Round((double) num7 / 2.0);
              if (hexLibVarValue + num7 > 3000)
                num7 = (int) Math.Round((double) num7 / 2.0);
              if (hexLibVarValue + num7 > 4000)
                num7 = (int) Math.Round((double) num7 / 2.0);
              if (hexLibVarValue + num7 > 5000)
                num7 = (int) Math.Round((double) num7 / 2.0);
              if (hexLibVarValue + num7 > 6000)
                num7 = (int) Math.Round((double) num7 / 2.0);
              if (hexLibVarValue + num7 > 7000)
                num7 = (int) Math.Round((double) num7 / 2.0);
              if (hexLibVarValue + num7 > 8000)
                num7 = (int) Math.Round((double) num7 / 2.0);
              if (hexLibVarValue + num7 > 9000)
                num7 = (int) Math.Round((double) num7 / 2.0);
              int num10 = num7 + num9;
              int tValue = hexLibVarValue + num10;
              game.Data.MapObj[0].HexObj[x2, y2].SetHexLibVarValue(libVar, tValue);
            }
          }
        }
      }
      s9 = "Hex irradiated with " + num1.ToString() + " RAD.";
      if (num1 > this.rememberRadPts)
        this.rememberRadPts = num1;
      return num1;
    }

    pub int AlterCombatLastRound(ref CombatClass cc) => cc.CombatType == 13 ? 3 : -1;
  }
}
