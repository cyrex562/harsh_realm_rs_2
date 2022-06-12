// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.CustomDC2AICalls
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;

namespace WindowsApplication1
{
  public class CustomDC2AICalls
  {
    public DC2AIClass ai;
    public DataClass data;
    public int slotRegimeKeys;
    public int slotOobType;
    public int slotRegimes;
    public int slotregregkeys;
    public string dataLib;
    public bool[,] tempActuallyNotAtWarForMove;
    public bool[,] tempActuallyNotAtWarForAttack;

    public CustomDC2AICalls(ref DC2AIClass tai)
    {
      this.dataLib = "SE_Data";
      this.ai = tai;
      this.data = this.ai.game.Data;
      this.slotRegimes = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(this.dataLib, 143, 0, 0));
      this.slotRegimeKeys = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(this.dataLib, 210, 0, 0));
      this.slotregregkeys = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(this.dataLib, 275, 0, 0));
      this.slotOobType = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(this.dataLib, 236, 0, 0));
      this.tempActuallyNotAtWarForMove = new bool[this.data.RegimeCounter + 1, this.data.RegimeCounter + 1];
      this.tempActuallyNotAtWarForAttack = new bool[this.data.RegimeCounter + 1, this.data.RegimeCounter + 1];
      int regimeCounter1 = this.data.RegimeCounter;
      for (int index1 = 0; index1 <= regimeCounter1; ++index1)
      {
        int regimeCounter2 = this.data.RegimeCounter;
        for (int index2 = 0; index2 <= regimeCounter2; ++index2)
        {
          int num1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotregregkeys].GetData3(0, this.data.RegimeObj[index1].id, 1, this.data.RegimeObj[index2].id, 2, "dipClear", 3)));
          if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotregregkeys].GetData3(0, this.data.RegimeObj[index2].id, 1, this.data.RegimeObj[index1].id, 2, "dipClear", 3))) == 1 & num1 == 0)
            num1 = 1;
          int num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[index1].id, 1)));
          this.tempActuallyNotAtWarForMove[index1, index2] = false;
          this.tempActuallyNotAtWarForAttack[index1, index2] = false;
          if (this.data.RegimeObj[index1].RegimeRel[index2] == 0 && num2 == 2)
          {
            if (num1 < 1)
            {
              int num3 = Math.Max((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotregregkeys].GetData3(0, this.data.RegimeObj[index1].id, 1, this.data.RegimeObj[index2].id, 2, "relation", 3))), (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotregregkeys].GetData3(0, this.data.RegimeObj[index2].id, 1, this.data.RegimeObj[index1].id, 2, "relation", 3))));
              this.tempActuallyNotAtWarForAttack[index1, index2] = true;
              this.tempActuallyNotAtWarForMove[index1, index2] = num3 >= 35;
            }
            else
            {
              this.tempActuallyNotAtWarForMove[index1, index2] = false;
              this.tempActuallyNotAtWarForAttack[index1, index2] = false;
            }
          }
          this.tempActuallyNotAtWarForMove[index2, index1] = this.tempActuallyNotAtWarForMove[index1, index2];
          this.tempActuallyNotAtWarForAttack[index2, index1] = this.tempActuallyNotAtWarForAttack[index1, index2];
        }
      }
      if (Operators.CompareString(this.data.RegimeObj[this.data.Turn].Name, "Abaro Territory", false) != 0)
        ;
    }

    public void CustomAfterInitialization() => this.PlayPostures();

    public float CustomAllowedAsStrategicReserve(int byvalunr) => -1f;

    public float StrategicReserveModForUnit(int unr)
    {
      int historical1 = this.data.UnitObj[unr].Historical;
      int hq = this.data.UnitObj[unr].HQ;
      if (this.data.HistoricalUnitObj[historical1].GiveHisVarValue(11) > 0 && !this.data.UnitObj[unr].IsHQ)
        return 0.2f;
      if (this.data.UnitObj[unr].TempCategory == 5)
        return 1f;
      if (this.data.UnitObj[unr].IsHQ)
        return 99999f;
      if (hq > -1)
      {
        int historical2 = this.data.UnitObj[hq].Historical;
        int idValue = this.data.HistoricalUnitObj[historical1].GiveHisVarValue(1);
        if (idValue > 0 & historical2 > -1)
        {
          if ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotOobType].GetData(0, idValue, 4))) == 1)
          {
            if (this.data.HistoricalUnitObj[historical2].Type >= 7)
              return 2f;
            return this.data.HistoricalUnitObj[historical2].Type >= 5 ? 30f : 9999f;
          }
          return this.data.HistoricalUnitObj[historical2].Type >= 7 ? 30f : 9999f;
        }
      }
      return 9999f;
    }

    public void PlayPostures()
    {
      string str1 = "8101_AI_Play_Postures";
      int id1 = this.data.RegimeObj[this.data.Turn].id;
      int stringListById1 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(this.dataLib, 277, 0, 0));
      int stringListById2 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(this.dataLib, 169, 0, 0));
      int stringListById3 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(this.dataLib, 168, 0, 0));
      int num1 = 50;
      int num2 = 100;
      this.ai.ClearLog();
      this.ai.AddLog("");
      this.ai.AddLog(str1);
      this.ai.AddLog("");
      this.ai.AddLog("OHQs available:");
      SimpleList simpleList1 = new SimpleList();
      int unitCounter1 = this.data.UnitCounter;
      for (int tid = 0; tid <= unitCounter1; ++tid)
      {
        if (this.data.UnitObj[tid].HQ > -1 & this.data.UnitObj[tid].IsHQ && this.data.UnitObj[tid].Regime == this.data.Turn & this.data.UnitObj[tid].PreDef == -1 & this.data.UnitObj[tid].Historical > -1 && this.data.HistoricalUnitObj[this.data.UnitObj[tid].Historical].TempVar1 < 1)
        {
          simpleList1.Add(tid, 1);
          int num3 = this.data.HistoricalUnitObj[this.data.UnitObj[tid].Historical].GiveHisVarValue(21);
          this.ai.AddLog(Conversions.ToString(Operators.CompareString("-OHQ: " + this.data.UnitObj[tid].Name + " (posture=" + num3.ToString(), ")", false) == 0));
        }
      }
      this.ai.AddLog("");
      this.data.StringListObj[stringListById2].SetData(0, "REGIMEID", 1, id1, true);
      this.data.StringListObj[stringListById2].SetData(0, "SOURCEREGIMEID", 1, id1, true);
      this.data.StringListObj[stringListById2].SetData(0, "ROUND", 1, this.data.Round, true);
      SimpleList simpleList2 = new SimpleList();
      int length = this.data.StringListObj[stringListById1].Length;
      int num4;
      for (int index = 0; index <= length; ++index)
      {
        num4 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index, 0]));
        if ((int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index, 12])) == 7 & (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index, 7])) == 3)
        {
          string str2 = this.data.StringListObj[stringListById1].Data[index, 1];
          string str3 = this.data.StringListObj[stringListById1].Data[index, 6];
          int num5;
          if (str3.Length > 0)
          {
            EventRelatedClass eventRelatedObj = DrawMod.TGame.EventRelatedObj;
            int id2 = this.data.StringListObj[stringListById3].ID;
            int id3 = this.data.StringListObj[stringListById2].ID;
            string logicString = str3;
            Random random = (Random) null;
            ref Random local = ref random;
            num5 = eventRelatedObj.CheckLogicStringStart(id2, id3, logicString, 0, ref local);
          }
          else
            num5 = 1;
          if (num5 >= 1)
          {
            simpleList2.Add(num4, 1, 1);
            this.ai.AddLog("-Posture available: #" + num4.ToString() + " : " + str2);
          }
        }
      }
      this.ai.AddLog("");
      int counter1 = simpleList1.Counter;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        int index2 = simpleList1.Id[index1];
        int num6 = this.data.HistoricalUnitObj[this.data.UnitObj[index2].Historical].GiveHisVarValue(21);
        int num7 = 0;
        if (num6 > 0)
        {
          if (DrawMod.RandyNumber.Next(0, 100) < num1)
            num7 = 1;
        }
        else if (DrawMod.RandyNumber.Next(0, 100) < num2)
          num7 = 1;
        if (num7 == 1)
        {
          int num8 = 0;
          int num9 = 0;
          int num10 = 0;
          int num11 = 0;
          int num12 = 0;
          int num13 = 0;
          int num14 = 0;
          int unitCounter2 = this.data.UnitCounter;
          for (int index3 = 0; index3 <= unitCounter2; ++index3)
          {
            if (this.data.UnitObj[index3].HQ == index2)
            {
              int sfCount = this.data.UnitObj[index3].SFCount;
              for (int index4 = 0; index4 <= sfCount; ++index4)
              {
                int sf = this.data.UnitObj[index3].SFList[index4];
                int type = this.data.SFObj[sf].Type;
                int qty = this.data.SFObj[sf].Qty;
                int unitGroup = this.data.SFTypeObj[type].UnitGroup;
                int num15 = (this.data.SFTypeObj[type].SFTypeVar[30] + this.data.SFTypeObj[type].SFTypeVar[31] + (this.data.SFTypeObj[type].SFTypeVar[32] + this.data.SFTypeObj[type].SFTypeVar[33])) * qty;
                int num16 = this.data.SFObj[sf].Xp * qty;
                num14 += num16;
                num10 += qty;
                if (unitGroup == 0)
                {
                  if (this.data.SFTypeObj[type].ArtRange > 0)
                  {
                    num13 += num15;
                  }
                  else
                  {
                    switch (unitGroup)
                    {
                      case 0:
                        num9 += num15;
                        break;
                      case 1:
                        num13 += num15;
                        break;
                      case 2:
                        num12 += num15;
                        break;
                      default:
                        if (unitGroup == 3 | unitGroup == 4)
                        {
                          num11 += num15;
                          break;
                        }
                        break;
                    }
                  }
                  num8 += num15;
                }
              }
            }
          }
          int num17 = (int) Math.Round((double) num14 / (double) num10);
          int tweight1 = (int) Math.Round((double) (100 * num13) / (double) num8);
          int tweight2 = (int) Math.Round((double) (100 * num9) / (double) num8);
          int tweight3 = (int) Math.Round((double) (100 * num12) / (double) num8);
          int tweight4 = (int) Math.Round((double) (100 * num11) / (double) num8);
          simpleList2.AddWeight(601, tweight2);
          simpleList2.AddWeight(602, tweight2);
          simpleList2.AddWeight(603, tweight2);
          simpleList2.AddWeight(604, tweight2);
          simpleList2.AddWeight(607, tweight2);
          simpleList2.AddWeight(608, tweight2);
          simpleList2.AddWeight(609, tweight2);
          simpleList2.AddWeight(610, tweight2);
          simpleList2.AddWeight(611, tweight2);
          simpleList2.AddWeight(612, tweight2);
          simpleList2.AddWeight(615, tweight2 * 2);
          simpleList2.AddWeight(616, tweight2);
          simpleList2.AddWeight(619, tweight2);
          simpleList2.AddWeight(621, tweight2 * 2);
          simpleList2.AddWeight(622, tweight2 * 2);
          simpleList2.AddWeight(607, tweight4);
          simpleList2.AddWeight(608, tweight4);
          simpleList2.AddWeight(609, tweight4);
          simpleList2.AddWeight(610, tweight4);
          simpleList2.AddWeight(612, tweight4);
          simpleList2.AddWeight(616, tweight4);
          simpleList2.AddWeight(618, tweight4 * 2);
          simpleList2.AddWeight(619, tweight4);
          simpleList2.AddWeight(603, tweight1);
          simpleList2.AddWeight(607, tweight1);
          simpleList2.AddWeight(609, tweight1);
          simpleList2.AddWeight(610, tweight1);
          simpleList2.AddWeight(611, tweight1);
          simpleList2.AddWeight(616, tweight1);
          simpleList2.AddWeight(610, tweight3);
          int counter2 = simpleList2.Counter;
          for (int index5 = 0; index5 <= counter2; ++index5)
          {
            int num18 = new Random((int) Math.Round((double) this.data.GameID / 1000.0 * (double) id1 * (double) simpleList2.Id[index5])).Next(3, 8);
            simpleList2.Weight[index5] = (int) Math.Round((double) (simpleList2.Weight[index5] * num18) / 5.0);
          }
          int index6 = -1;
          int counter3 = this.ai.frontList.Counter;
          for (int index7 = 0; index7 <= counter3; ++index7)
          {
            if (this.ai.frontList.Front[index7].strictHQs.counter > -1)
            {
              int counter4 = this.ai.frontList.Front[index7].strictHQs.counter;
              for (int index8 = 0; index8 <= counter4; ++index8)
              {
                if (this.ai.frontList.Front[index7].strictHQs.unr[index8] == index2)
                  index6 = index7;
              }
            }
          }
          if (index6 > -1)
          {
            AIFront aiFront = this.ai.frontList.Front[index6];
            if (aiFront.FrontType == 11)
            {
              simpleList2.MultiplyWeight(601, 2f);
              simpleList2.MultiplyWeight(604, 2f);
              simpleList2.MultiplyWeight(607, 2f);
              simpleList2.MultiplyWeight(616, 2f);
              simpleList2.MultiplyWeight(622, 2f);
            }
            else if (aiFront.FrontType == 12)
            {
              simpleList2.MultiplyWeight(608, 2f);
              simpleList2.MultiplyWeight(611, 2f);
              simpleList2.MultiplyWeight(615, 4f);
              simpleList2.MultiplyWeight(619, 2f);
              simpleList2.MultiplyWeight(621, 4f);
            }
            else if (aiFront.FrontType == 1)
            {
              if (aiFront.Stance == 3)
              {
                simpleList2.MultiplyWeight(608, 2f);
                simpleList2.MultiplyWeight(611, 2f);
                simpleList2.MultiplyWeight(615, 2f);
                simpleList2.MultiplyWeight(619, 2f);
                simpleList2.MultiplyWeight(621, 2f);
              }
              else if (aiFront.Stance == 2)
              {
                simpleList2.MultiplyWeight(601, 2f);
                simpleList2.MultiplyWeight(604, 2f);
                simpleList2.MultiplyWeight(607, 2f);
                simpleList2.MultiplyWeight(616, 2f);
                simpleList2.MultiplyWeight(622, 2f);
              }
              else if (aiFront.Stance == 1)
              {
                simpleList2.MultiplyWeight(602, 2f);
                simpleList2.MultiplyWeight(618, 2f);
              }
              else if (aiFront.Stance == 4)
              {
                simpleList2.MultiplyWeight(602, 2f);
                simpleList2.MultiplyWeight(618, 2f);
                simpleList2.MultiplyWeight(603, 2.5f);
                simpleList2.MultiplyWeight(610, 2.5f);
                simpleList2.MultiplyWeight(612, 2.5f);
              }
            }
            else if (aiFront.FrontType == 2 | aiFront.FrontType == 3)
            {
              simpleList2.MultiplyWeight(603, 2f);
              simpleList2.MultiplyWeight(610, 2f);
              simpleList2.MultiplyWeight(612, 2f);
            }
            if (aiFront.vpScoreAveragePercent > 80)
            {
              simpleList2.MultiplyWeight(604, 2.5f);
              simpleList2.MultiplyWeight(611, 2.5f);
              simpleList2.MultiplyWeight(616, 2.5f);
              simpleList2.MultiplyWeight(621, 2.5f);
              simpleList2.MultiplyWeight(622, 2.5f);
            }
            else if (aiFront.vpScoreAveragePercent > 70)
            {
              simpleList2.MultiplyWeight(604, 2f);
              simpleList2.MultiplyWeight(611, 2f);
              simpleList2.MultiplyWeight(616, 2f);
              simpleList2.MultiplyWeight(621, 2f);
              simpleList2.MultiplyWeight(622, 2f);
            }
            else if (aiFront.vpScoreAveragePercent > 60)
            {
              simpleList2.MultiplyWeight(604, 1.5f);
              simpleList2.MultiplyWeight(611, 1.5f);
              simpleList2.MultiplyWeight(616, 1.5f);
              simpleList2.MultiplyWeight(621, 1.5f);
              simpleList2.MultiplyWeight(622, 1.5f);
            }
            if (aiFront.Stance == 3)
            {
              if ((double) aiFront.UnitCountRatio > 3.0)
                simpleList2.MultiplyWeight(619, 3f);
              else if ((double) aiFront.UnitCountRatio > 2.0)
                simpleList2.MultiplyWeight(619, 2f);
              else if ((double) aiFront.UnitCountRatio > 1.5)
                simpleList2.MultiplyWeight(619, 1.75f);
              else if ((double) aiFront.UnitCountRatio > 1.32000005245209)
                simpleList2.MultiplyWeight(619, 1.5f);
              else if ((double) aiFront.UnitCountRatio > 1.0)
                simpleList2.MultiplyWeight(619, 1.25f);
              else if ((double) aiFront.UnitCountRatio < 0.66)
                simpleList2.MultiplyWeight(619, 0.5f);
            }
            if ((double) aiFront.OrigAverageStrength < 5.0)
            {
              if ((double) aiFront.OrigAverageStrength >= 4.0)
              {
                simpleList2.MultiplyWeight(621, 0.66f);
                simpleList2.MultiplyWeight(623, 0.66f);
              }
              else if ((double) aiFront.OrigAverageStrength >= 3.33)
              {
                simpleList2.MultiplyWeight(615, 0.66f);
                simpleList2.MultiplyWeight(617, 0.66f);
                simpleList2.MultiplyWeight(621, 0.2f);
                simpleList2.MultiplyWeight(623, 0.2f);
              }
              else
              {
                simpleList2.MultiplyWeight(615, 0.2f);
                simpleList2.MultiplyWeight(617, 0.2f);
                simpleList2.MultiplyWeight(621, 0.01f);
                simpleList2.MultiplyWeight(623, 0.01f);
              }
            }
            if (aiFront.Stance == 3 | aiFront.Stance == 2)
            {
              int num19 = DrawMod.TGame.EventRelatedObj.CheckEnemyTroopsCloseBy(12, this.data.UnitObj[index2].X, this.data.UnitObj[index2].Y, 0);
              if (this.data.Turn == 5)
                index1 = index1;
              if (num19 < 1)
              {
                simpleList2.MultiplyWeight(609, 10f);
              }
              else
              {
                int num20 = DrawMod.TGame.EventRelatedObj.CheckEnemyTroopsCloseBy(8, this.data.UnitObj[index2].X, this.data.UnitObj[index2].Y, 0);
                if (num20 < 1)
                  simpleList2.MultiplyWeight(609, 5f);
                else if (num20 >= 10)
                  simpleList2.MultiplyWeight(609, 0.1f);
              }
            }
            if (num17 > 40)
              simpleList2.MultiplyWeight(609, 0.01f);
            else if (num17 > 30)
              simpleList2.MultiplyWeight(609, 0.1f);
            else if (num17 > 20)
              simpleList2.MultiplyWeight(609, 0.5f);
          }
          for (int counter5 = simpleList2.Counter; counter5 >= 0; counter5 += -1)
          {
            if (simpleList2.Data1[counter5] < 1)
              simpleList2.RemoveNr(counter5);
          }
          simpleList2.ReverseSortHighSpeed();
          simpleList2.removeWeight0orLower();
          if (simpleList2.Counter > -1)
          {
            int num21 = simpleList2.Id[0];
            num4 = num21;
            int historical = this.data.UnitObj[index2].Historical;
            this.ai.AddLog("Chosing Posture for " + this.data.UnitObj[index2].Name);
            int counter6 = simpleList2.Counter;
            for (int index9 = 0; index9 <= counter6; ++index9)
              this.ai.AddLog("Posture #" + simpleList2.Id[index9].ToString() + " has weight = " + simpleList2.Weight[index9].ToString());
            if (this.data.HistoricalUnitObj[historical].GiveHisVarValue(21) != num4)
            {
              this.data.HistoricalUnitObj[historical].SetHisVarValue(21, num4);
              this.ai.AddLog("Assigned Posture #" + num21.ToString() + " to " + this.data.UnitObj[index2].Name);
              int eventByLib = DrawMod.TGame.EventRelatedObj.CheckGetEventByLib("SE_Data", 541, 0, 0);
              this.data.AddActionCard();
              int actionCardCounter = this.data.ActionCardCounter;
              this.data.ActionCardObj[actionCardCounter].TempVar0 = num4;
              this.data.ActionCardObj[actionCardCounter].ExecuteEvent = eventByLib;
              int row = this.data.StringListObj[stringListById1].FindRow(0, num4);
              int num22 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[row, 7]));
              this.data.RegimeObj[this.data.Turn].AddActionCard(this.data.ActionCardCounter);
              DrawMod.TGame.EditObj.DoCardSlot = this.data.RegimeObj[this.data.Turn].ActionCardCounter;
              this.data.StringListObj[stringListById2].SetData(0, "REGID", 1, id1, true);
              this.data.StringListObj[stringListById2].SetData(0, "HISID", 1, this.data.HistoricalUnitObj[historical].ID, true);
              this.data.StringListObj[stringListById2].SetData(0, "REGIMEID", 1, id1, true);
              this.data.StringListObj[stringListById2].SetData(0, "SOURCEREGIMEID", 1, id1, true);
              this.data.StringListObj[stringListById2].SetData(0, "ROUND", 1, this.data.Round, true);
              DrawMod.TGame.SelectX = this.data.UnitObj[index2].X;
              DrawMod.TGame.SelectY = this.data.UnitObj[index2].Y;
              DrawMod.TGame.EventRelatedObj.ExecHardcodedSet(46, this.data.HistoricalUnitObj[historical].ID, 0, 0, "");
              this.data.HistoricalUnitObj[historical].SetHisVarValue(21, num4);
              DrawMod.TGame.EventRelatedObj.DoCheckSpecificEvent(eventByLib, num4, -1, -1, -1);
              DrawMod.TGame.EventRelatedObj.IO_AddClear();
              this.ai.AddLog("Played card: ID#" + num4.ToString() + " : " + this.data.StringListObj[stringListById1].GetData(0, num4, 1) + " on: " + this.data.HistoricalUnitObj[historical].Name);
              this.data.RemoveActionCard(this.data.ActionCardCounter);
            }
            else
              this.ai.AddLog("Already had Posture #" + num21.ToString() + " assigned to " + this.data.UnitObj[index2].Name);
          }
        }
      }
      this.ai.WriteLog(str1);
      this.ai.ClearLog();
    }

    public float CustomRuleTheater_MinimalAttackModifier(int x, int y, float currentMinimal)
    {
      float num1 = 1f;
      int num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[this.data.Turn].id, 1)));
      int regime = this.data.MapObj[0].HexObj[x, y].Regime;
      if (num2 == 1 & regime > -1)
      {
        int num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[regime].id, 1)));
        if (num3 == 2 | num3 == 3)
          num1 = 0.5f;
      }
      return num1;
    }

    public int CustomHelpCombatModifier(int tHelpCombat, int forRegimeNr)
    {
      int num1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[this.data.Turn].id, 1)));
      int num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[forRegimeNr].id, 1)));
      if (num1 == 1 && num2 > 1)
        tHelpCombat = 0;
      return tHelpCombat;
    }

    public bool TargetRegimeRelationIsActuallyNotWar(int regnr, int targetregnr, bool forMove)
    {
      if (forMove)
      {
        if (this.tempActuallyNotAtWarForMove.GetUpperBound(0) >= regnr & this.tempActuallyNotAtWarForMove.GetUpperBound(1) >= targetregnr && regnr > -1 & targetregnr > -1)
          return this.tempActuallyNotAtWarForMove[regnr, targetregnr];
      }
      else if (this.tempActuallyNotAtWarForAttack.GetUpperBound(0) >= regnr & this.tempActuallyNotAtWarForAttack.GetUpperBound(1) >= targetregnr && regnr > -1 & targetregnr > -1)
        return this.tempActuallyNotAtWarForAttack[regnr, targetregnr];
      return false;
    }

    public bool CustomRuleHQtoFrontAssign_AllowHQGroupsWithoutHQ(int unr)
    {
      int index = this.data.Turn;
      if (unr > -1)
        index = this.data.UnitObj[unr].Regime;
      int num = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[index].id, 1)));
      return num == 2 | num == 3;
    }

    public bool CustomDoStrategicIterations() => (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[this.data.Turn].id, 1))) == 1;

    public bool CustomIsMinor()
    {
      switch ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[this.data.Turn].id, 1))))
      {
        case 1:
          return false;
        case 2:
          return true;
        default:
          return false;
      }
    }

    public bool CustomIsMajor() => (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[this.data.Turn].id, 1))) == 1;

    public int CustomStrategicReserveMultiplier() => 1;

    public bool CustomStrategicReserveDelegateToFrontline(int phase) => false;

    public object CustomRuleInitVars()
    {
      int num = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[this.data.Turn].id, 1)));
      if (num == 2 | num == 3)
      {
        this.ai.VAR_SUPPLY_MAXIMUM_RANGE = 1000;
        this.ai.VAR_SUPPLY_75PERCENT_RANGE = 700;
        this.ai.VAR_SUPPLY_50PERCENT_RANGE = 800;
        this.ai.VAR_SUPPLY_25PERCENT_RANGE = 900;
      }
      if (num == 1)
      {
        this.ai.VAR_DC4_ATTACKUNIT_IS_IMPORTANT = true;
        this.ai.VAR_USE_STRATEGIC_OPS_WITH_STRICT_HQFRONT = true;
        this.ai.VAR_DC4_STRATEGIC_DEFENSE_OF_SUPPLY_SOURCE = true;
      }
      object obj;
      return obj;
    }

    public float CustomRuleTheaterModifiers_VpModifier(int x, int y) => 10f;

    public bool CustomRule_MakeFrontsFromDefensiveZones_NoUnitsAssignedNeeded() => true;

    public void CustomRuleHQtoFrontAssign_CustomScripting_BeforeHqsToFrontAssigns(
      ref AIUnitList hqlist,
      ref AIFrontList fronts)
    {
    }

    public float CustomRuleInitFrontlines_UnitRatioWeightModifier(int unr)
    {
      switch ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[this.data.UnitObj[unr].Regime].id, 1))))
      {
        case 1:
          return 1f;
        case 2:
          return 0.5f;
        case 4:
          return 0.25f;
        default:
          return 0.66f;
      }
    }

    public bool CustomRuleInitFrontlines_MLAalreadySet() => (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[this.data.Turn].id, 1))) == 1;

    public void CustomRuleInitFrontlines_ResetMatrixes()
    {
      int num1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[this.data.Turn].id, 1)));
      int stringListById1 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(this.dataLib, 123, 0, 0));
      int stringListById2 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(this.dataLib, 160, 0, 0));
      int stringListById3 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(this.dataLib, 236, 0, 0));
      int stringListById4 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(this.dataLib, 148, 0, 0));
      int stringListById5 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 144, 0, 0));
      int id1 = this.data.RegimeObj[this.data.Turn].id;
      if (num1 != 1)
        return;
      this.ai.AddLog("CUSTOM MATRIXES AND ZONES (OFF/DEF)");
      this.ai.AddLog("");
      this.ai.VAR_ZONES_TYPE = 3;
      this.ai.VAR_USE_BROAD_DEFENSIVE_ZONES = false;
      this.ai.VAR_BROAD_DEFENSIVE_ZONE_HEX_MINIMUM = 1;
      AIMatrix mask1 = this.ai.SetOwnerMatrix(0, 0, this.data.MapObj[0].MapWidth, this.data.MapObj[0].MapHeight);
      AIMatrix aiMatrix1 = mask1.Clone();
      aiMatrix1.RemoveValuesByMask(mask1, 1);
      aiMatrix1.ExpandAndAddValueForAnyRegime(199);
      aiMatrix1.SetAllValuesSubtractWith(2);
      int num2 = 0;
      AIMatrix aiMatrix2 = new AIMatrix(ref this.ai.game.DC2AIObj);
      aiMatrix2.SetAllValuesToWithMask(1, ref mask1, 1);
      AIMatrix aiMatrix3 = aiMatrix2.DetectAndMakeEdgeMatrix(false);
      aiMatrix3.RemoveValuesByLandscapeAIBlock(0);
      aiMatrix3.ExpandSpecificValueForAnyRegime(1, 1);
      int mapWidth1 = this.data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (aiMatrix3.Value[index1, index2] > 0)
            ++num2;
        }
      }
      int num3 = (int) Math.Round((double) num2 * 0.25);
      if (3 > num3)
        num3 = 3;
      int num4 = 0;
      int num5 = 0;
      int num6 = 0;
      int num7 = 0;
      int num8 = 0;
      int num9 = 0;
      int unitCounter1 = this.data.UnitCounter;
      int num10;
      for (int unr = 0; unr <= unitCounter1; ++unr)
      {
        if (this.data.UnitObj[unr].Regime == this.data.Turn & this.data.UnitObj[unr].PreDef == -1)
        {
          if (this.data.UnitObj[unr].AIAttack != 1)
          {
            int historical = this.data.UnitObj[unr].Historical;
            if (historical > -1 && this.data.HistoricalUnitObj[historical].GiveHisVarValue(11) < 1)
            {
              ++num4;
              if (this.ai.GetAIRolePercent(unr, 8) > 33)
                ++num5;
              else if (this.ai.GetAIRolePercent(unr, 10) > 33)
                ++num7;
              else if (this.ai.GetAIRolePercent(unr, 6) > 33)
                ++num6;
              else
                ++num8;
              num10 = -1;
              if (!this.data.UnitObj[unr].AIReserve)
                ++num9;
              else
                num9 = num9;
            }
          }
          else
            num10 = num10;
        }
      }
      float val2_1 = (float) num9 / (float) num3;
      this.ai.AddLog("UnitsPerFrontHex: " + val2_1.ToString());
      this.ai.AddLog("Units: " + num4.ToString());
      this.ai.AddLog("Frontage: " + num3.ToString());
      if (this.data.Round < 10)
        val2_1 += 0.18f;
      else if (this.data.Round < 20)
        val2_1 += 0.14f;
      else if (this.data.Round < 30)
        val2_1 += 0.1f;
      else if (this.data.Round < 40)
        val2_1 += 0.6f;
      else if (this.data.Round < 50)
        val2_1 += 0.2f;
      this.ai.AddLog("Adjusted UnitsPerFrontHex: " + val2_1.ToString());
      this.ai.AddLog("");
      this.ai.MLAMatrix = new AIMatrix(ref this.ai);
      int mapWidth2 = this.data.MapObj[0].MapWidth;
      for (int index3 = 0; index3 <= mapWidth2; ++index3)
      {
        int mapHeight = this.data.MapObj[0].MapHeight;
        for (int index4 = 0; index4 <= mapHeight; ++index4)
        {
          this.ai.VAR_MATRIX_ZONES.Value[index3, index4] = 0;
          this.ai.VAR_MATRIX_RETREAT.Value[index3, index4] = 100;
          this.ai.VAR_MATRIX_STRENGTH.Value[index3, index4] = 100;
          this.ai.MLAMatrix.Value[index3, index4] = 1;
        }
      }
      SimpleList simpleList1 = new SimpleList();
      int unitCounter2 = this.ai.game.Data.UnitCounter;
      for (int tid = 0; tid <= unitCounter2; ++tid)
      {
        if (this.ai.game.Data.UnitObj[tid].Regime == this.ai.game.Data.Turn)
        {
          int historical = this.data.UnitObj[tid].Historical;
          if (historical > -1)
          {
            if (this.data.UnitObj[tid].PreDef == -1 & this.data.UnitObj[tid].IsHQ && historical > -1 && this.data.HistoricalUnitObj[historical].Type == 5 && this.data.HistoricalUnitObj[historical].AIlist > 0)
            {
              simpleList1.Add(tid, this.data.HistoricalUnitObj[historical].AIlist);
              this.ai.AddLog("Added " + this.data.UnitObj[tid].Name + " to OldAIList: " + this.data.HistoricalUnitObj[historical].AIlist.ToString());
            }
            this.data.HistoricalUnitObj[historical].AIlist = 0;
          }
        }
      }
      this.ai.AddLog("");
      SimpleList simpleList2 = new SimpleList();
      SimpleList simpleList3 = new SimpleList();
      SimpleList simpleList4 = new SimpleList();
      int idValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, id1, 12)));
      int num11 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].GetData(6, idValue1, 0)));
      int length1 = this.data.StringListObj[stringListById1].Length;
      for (int index5 = 0; index5 <= length1; ++index5)
      {
        if ((int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index5, 8])) == id1)
        {
          int num12 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index5, 0]));
          string str = this.data.StringListObj[stringListById1].Data[index5, 7];
          int tweight1 = 0;
          int length2 = this.data.StringListObj[stringListById4].Length;
          for (int index6 = 0; index6 <= length2; ++index6)
          {
            if ((int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById4].Data[index6, 0])) == num12)
            {
              int idValue2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById4].Data[index6, 1]));
              int num13 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById5].GetData(0, idValue2, 2)));
              if ((int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById5].GetData(0, idValue2, 5))) == 1)
                tweight1 += 3 * (num13 + 1);
              else
                tweight1 += num13 + 1;
            }
          }
          simpleList3.AddWeight(num12, tweight1);
          int num14 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById2].GetData2(0, num12, 1, "pop", 2)));
          int num15 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById2].GetData2(0, num12, 1, "worker", 2)));
          int num16 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById2].GetData2(0, num12, 1, "cas", 2)));
          if (num16 < 1)
            num16 = 100;
          int num17 = num16 + 25;
          int tweight2 = (int) Math.Round((double) ((num14 + num15) * num17) / 100.0);
          this.ai.AddLog(str + " got score1: " + tweight1.ToString() + ", score2: " + tweight2.ToString());
          simpleList4.AddWeight(num12, tweight2);
        }
      }
      simpleList3.Percentify();
      simpleList4.Percentify();
      int length3 = this.data.StringListObj[stringListById1].Length;
      for (int index = 0; index <= length3; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index, 8])) == id1)
        {
          int tid = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index, 0]));
          int weight1 = simpleList3.FindWeight(tid);
          int weight2 = simpleList4.FindWeight(tid);
          int num18 = 0;
          if (num11 == tid)
            num18 = 100;
          int tweight = (int) Math.Round((double) (weight1 + weight2 + num18) / 3.0);
          simpleList2.AddWeight(tid, tweight);
        }
      }
      simpleList2.ReverseSort();
      int num19 = simpleList2.Counter + 1;
      int num20 = 0;
      int num21 = 2;
      int num22 = 1;
      int counter1 = simpleList2.Counter;
      for (int index = 0; index <= counter1; ++index)
      {
        ++num20;
        if (num20 > num21)
        {
          num20 = 0;
          ++num22;
          ++num21;
        }
      }
      if (num22 > simpleList2.Counter + 1)
        num22 = simpleList2.Counter + 1;
      this.ai.AddLog("");
      this.ai.AddLog("IMPORTANT FRIENDLY ZONES");
      int num23 = num22;
      int tid1;
      for (tid1 = 1; tid1 <= num23; ++tid1)
      {
        int idValue3 = simpleList2.Id[tid1 - 1];
        string data = this.data.StringListObj[stringListById1].GetData(0, idValue3, 7);
        this.ai.AddLog("#" + tid1.ToString() + " : " + data);
      }
      this.ai.AddLog("");
      SimpleList simpleList5 = new SimpleList();
      SimpleList simpleList6 = new SimpleList();
      SimpleList simpleList7 = new SimpleList();
      SimpleList simpleList8 = new SimpleList();
      SimpleList simpleList9 = new SimpleList();
      int regimeCounter1 = this.data.RegimeCounter;
      for (tid1 = 1; tid1 <= regimeCounter1; ++tid1)
      {
        if (tid1 != this.data.Turn)
        {
          int num24 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[tid1].id, 1)));
          int id2 = this.data.RegimeObj[tid1].id;
          int num25 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotregregkeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[tid1].id, 2, "aiIntention", 3)));
          int num26 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotregregkeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[tid1].id, 2, "relation", 3)));
          AIMatrix aiMatrix4 = mask1.Clone();
          int mapWidth3 = this.data.MapObj[0].MapWidth;
          for (int index7 = 0; index7 <= mapWidth3; ++index7)
          {
            int mapHeight = this.data.MapObj[0].MapHeight;
            for (int index8 = 0; index8 <= mapHeight; ++index8)
              aiMatrix4.Value[index7, index8] = this.data.MapObj[0].HexObj[index7, index8].Regime == tid1 ? 1 : 0;
          }
          aiMatrix4.ExpandAndAddValueForAnyRegime(49);
          aiMatrix4.SetAllValuesSubtractWith(1);
          AIMatrix aiMatrix5 = new AIMatrix(ref this.ai);
          int mapWidth4 = this.data.MapObj[0].MapWidth;
          for (int index9 = 0; index9 <= mapWidth4; ++index9)
          {
            int mapHeight = this.data.MapObj[0].MapHeight;
            for (int index10 = 0; index10 <= mapHeight; ++index10)
              aiMatrix5.Value[index9, index10] = this.data.MapObj[0].HexObj[index9, index10].Regime == this.data.Turn ? 1 : 0;
          }
          switch (num24)
          {
            case 1:
              aiMatrix5.ExpandAndAddValueForAnyRegime(20);
              break;
            case 2:
              aiMatrix5.ExpandAndAddValueForAnyRegime(10);
              break;
            default:
              aiMatrix5.ExpandAndAddValueForAnyRegime(5);
              break;
          }
          aiMatrix5.SetAllValuesSubtractWith(1);
          int num27 = 0;
          int num28 = 0;
          int mapWidth5 = this.data.MapObj[0].MapWidth;
          for (int index11 = 0; index11 <= mapWidth5; ++index11)
          {
            int mapHeight = this.data.MapObj[0].MapHeight;
            for (int index12 = 0; index12 <= mapHeight; ++index12)
            {
              if (this.data.MapObj[0].HexObj[index11, index12].Regime == this.data.Turn && aiMatrix3.Value[index11, index12] > 0 & aiMatrix4.Value[index11, index12] == 1)
                num27 += 10;
              if (this.data.MapObj[0].HexObj[index11, index12].Regime == tid1 && aiMatrix5.Value[index11, index12] > 0 & aiMatrix5.Value[index11, index12] < 21 && this.data.MapObj[0].HexObj[index11, index12].UnitCounter > -1)
              {
                int unitCounter3 = this.data.MapObj[0].HexObj[index11, index12].UnitCounter;
                for (int index13 = 0; index13 <= unitCounter3; ++index13)
                {
                  int unit = this.data.MapObj[0].HexObj[index11, index12].UnitList[index13];
                  num28 += this.data.UnitObj[unit].TempUnitPowerAbs;
                }
              }
            }
          }
          int tweight3 = (int) Math.Round((double) (num27 * num28) / 100.0);
          simpleList6.AddWeight(id2, tweight3);
          int tweight4 = 0;
          int length4 = this.data.StringListObj[stringListById1].Length;
          for (int index = 0; index <= length4; ++index)
          {
            if ((int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index, 8])) == id1)
            {
              int tid2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index, 0]));
              int nr1 = simpleList2.FindNr(tid2);
              if (nr1 > -1 & nr1 < num22)
              {
                int id3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index, 6]));
                if (id3 > 0)
                {
                  int locationById = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id3);
                  if (locationById > -1)
                  {
                    int num29 = aiMatrix4.Value[this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y];
                    int nr2 = simpleList2.FindNr(tid2);
                    if (nr2 > -1 && simpleList2.Data1[nr2] > num29)
                      simpleList2.Data1[nr2] = num29;
                    tweight4 += num29;
                  }
                }
              }
            }
          }
          simpleList7.Add(id2, tweight4);
          int tweight5 = 10;
          if (num24 == 1)
            tweight5 = 100;
          if (num24 == 2)
            tweight5 = 50;
          if (num24 == 3)
            tweight5 = 50;
          if (this.data.RegimeObj[this.data.Turn].RegimeRel[tid1] == 1)
            tweight5 = (int) Math.Round((double) tweight3 / 5.0);
          simpleList8.Add(id2, tweight5);
          int tweight6 = new Random((int) Math.Round((double) (this.data.RegimeObj[tid1].id * this.data.GameID) / 10.0)).Next(1, 101);
          simpleList9.Add(id2, tweight6);
        }
      }
      simpleList6.Percentify();
      simpleList7.Percentify();
      simpleList8.Percentify();
      simpleList9.Percentify();
      int regimeCounter2 = this.data.RegimeCounter;
      int index14;
      for (tid1 = 1; tid1 <= regimeCounter2; ++tid1)
      {
        if (tid1 != this.data.Turn)
        {
          int num30 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[tid1].id, 1)));
          int id4 = this.data.RegimeObj[tid1].id;
          int val1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotregregkeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[tid1].id, 2, "aiIntention", 3)));
          int val2_2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotregregkeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[tid1].id, 2, "relation", 3)));
          int num31 = this.data.RegimeObj[this.data.Turn].RegimeRel[tid1];
          if (num30 != 4)
          {
            int tweight = 0;
            index14 = simpleList6.FindWeight(id4);
            int num32 = 100 - simpleList7.FindWeight(id4);
            int weight = simpleList8.FindWeight(id4);
            int num33 = (int) Math.Round((double) simpleList9.FindWeight(id4) / 3.0);
            tweight = (int) Math.Round((double) (index14 + num32 + weight + num33) / 4.0);
            int num34 = 100 - Math.Max(val1, val2_2);
            if (num34 < 0)
              num34 = 0;
            if (num31 > 0)
            {
              tweight = (int) Math.Round((double) (tweight * 5 * num34) / 100.0);
              tweight = (int) Math.Round((double) (tweight * num34) / 100.0);
            }
            else
              tweight *= 100;
            this.ai.AddLog(this.data.RegimeObj[tid1].Name + " got score1(frontage+power): " + index14.ToString() + ", score2(distance): " + num32.ToString() + ", score3(rel): " + weight.ToString() + ", score4(rnd):" + num33.ToString() + " => finalscore: " + tweight.ToString());
            if (index14 > 0)
              simpleList5.Add(id4, tweight);
          }
        }
      }
      simpleList5.ReverseSort();
      index14 = simpleList5.Counter + 1;
      int num35 = 0;
      int num36 = 3;
      int num37 = 1;
      int counter2 = simpleList5.Counter;
      for (tid1 = 0; tid1 <= counter2; ++tid1)
      {
        ++num35;
        if (num35 > num36)
        {
          num35 = 0;
          ++num37;
          ++num36;
        }
      }
      int num38 = (int) Math.Round(Math.Ceiling((double) num37 * (double) Math.Min(1f, val2_1)));
      if (num38 < 1)
        num38 = 1;
      if (num38 > simpleList5.Counter + 1)
        num38 = simpleList5.Counter + 1;
      this.ai.AddLog("");
      this.ai.AddLog("IMPORTANT ENEMIES");
      int num39 = num38;
      for (tid1 = 1; tid1 <= num39; ++tid1)
      {
        index14 = simpleList5.Id[tid1 - 1];
        string name = this.data.RegimeObj[DrawMod.TGame.HandyFunctionsObj.GetRegimeByID(index14)].Name;
        this.ai.AddLog("#" + tid1.ToString() + " : " + name);
      }
      this.ai.AddLog("");
      SimpleList simpleList10 = new SimpleList();
      SimpleList simpleList11 = new SimpleList();
      int unitCounter4 = this.data.UnitCounter;
      for (tid1 = 0; tid1 <= unitCounter4; ++tid1)
      {
        if (this.data.UnitObj[tid1].Regime == this.ai.game.Data.Turn & this.data.UnitObj[tid1].PreDef == -1 & this.data.UnitObj[tid1].IsHQ)
        {
          int historical = this.data.UnitObj[tid1].Historical;
          if (historical > -1 && this.data.HistoricalUnitObj[historical].Type == 5)
          {
            index14 = 0;
            int num40 = 0;
            int unitCounter5 = this.data.UnitCounter;
            for (int index15 = 0; index15 <= unitCounter5; ++index15)
            {
              if (this.data.UnitObj[index15].Regime == this.ai.game.Data.Turn & this.data.UnitObj[index15].PreDef == -1 & !this.data.UnitObj[index15].IsHQ && this.data.UnitObj[index15].HQ == tid1)
              {
                ++index14;
                if (this.data.UnitObj[index15].TempTopUnit)
                  num40 += this.data.UnitObj[index15].TempUnitPowerAbs * 10;
                else
                  num40 += this.data.UnitObj[index15].TempUnitPowerAbs;
              }
            }
            if (index14 > 2)
            {
              index14 = num40;
              if (simpleList1.FindWeight(tid1) > 0)
                index14 *= 3;
              simpleList10.AddWeight(tid1, index14);
            }
          }
        }
      }
      simpleList10.ReverseSort();
      int unitCounter6 = this.data.UnitCounter;
      for (tid1 = 0; tid1 <= unitCounter6; ++tid1)
      {
        if (this.data.UnitObj[tid1].Regime == this.ai.game.Data.Turn & this.data.UnitObj[tid1].PreDef == -1 & this.data.UnitObj[tid1].IsHQ)
        {
          int historical = this.data.UnitObj[tid1].Historical;
          if (historical > -1 && this.data.HistoricalUnitObj[historical].Type == 5)
          {
            index14 = 0;
            int num41 = 0;
            int num42 = 0;
            int unitCounter7 = this.data.UnitCounter;
            for (int index16 = 0; index16 <= unitCounter7; ++index16)
            {
              if (this.data.UnitObj[index16].Regime == this.ai.game.Data.Turn & this.data.UnitObj[index16].PreDef == -1 & !this.data.UnitObj[index16].IsHQ && this.data.UnitObj[index16].HQ == tid1)
              {
                ++index14;
                if (this.data.UnitObj[index16].TempTopUnit)
                  ++num41;
              }
            }
            int idValue4 = this.data.HistoricalUnitObj[historical].GiveHisVarValue(1);
            if (idValue4 > 0)
            {
              int num43 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById3].GetData(0, idValue4, 2)));
              num42 = 2;
              if (num43 > 0)
                num42 = num43;
            }
            if (index14 > 3)
            {
              index14 = 100000;
              if (num41 > 0)
                index14 = (int) Math.Round((double) index14 / (double) ((num41 + 1) * (num41 + 1) * (num41 + 1)));
              int num44 = num42 * num42;
              if (num44 > 0)
                index14 = (int) Math.Round((double) index14 / (double) num44);
              if (simpleList1.FindWeight(tid1) > 0)
                index14 *= 10;
              simpleList11.AddWeight(tid1, index14);
            }
          }
        }
      }
      simpleList11.ReverseSort();
      int num45 = 0;
      int num46 = 2;
      int num47 = 1;
      int counter3 = simpleList10.Counter;
      for (tid1 = 0; tid1 <= counter3; ++tid1)
      {
        ++num45;
        if (num45 > num46)
        {
          num45 = 0;
          ++num47;
          ++num46;
        }
      }
      this.ai.AddLog("");
      this.ai.AddLog("SPARE OHQs (if Offensive)");
      int num48 = num47;
      for (tid1 = 1; tid1 <= num48; ++tid1)
      {
        index14 = simpleList10.Id[tid1 - 1];
        string name = this.data.UnitObj[index14].Name;
        this.ai.AddLog("#" + tid1.ToString() + " : " + name);
      }
      this.ai.AddLog("");
      this.ai.AddLog("");
      this.ai.AddLog("SPARE OHQs (if Defensive)");
      int num49 = num47;
      for (tid1 = 1; tid1 <= num49; ++tid1)
      {
        index14 = simpleList11.Id[tid1 - 1];
        string name = this.data.UnitObj[index14].Name;
        this.ai.AddLog("#" + tid1.ToString() + " : " + name);
      }
      this.ai.AddLog("");
      int num50 = 0;
      int num51 = 0;
      int num52 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, id1, 1, "majorAiOffensiveMode", 2)));
      int setValue1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, id1, 1, "majorAiOffensiveModeFixed", 2)));
      if (num52 < 1)
        num52 = 50;
      if (setValue1 < 1)
        setValue1 = 50;
      int num53 = 0;
      int num54 = 0;
      int num55 = num22 - 1;
      for (tid1 = 0; tid1 <= num55; ++tid1)
      {
        index14 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById2].GetData2(0, simpleList2.Id[tid1], 1, "majorAiEnemyDistance", 2)));
        if ((int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById2].GetData2(0, simpleList2.Id[tid1], 1, "majorAiRegId", 2))) == id1)
        {
          num50 += index14;
          num51 += simpleList2.Data1[tid1];
          if (num51 > num50)
          {
            int num56 = num51 - num50;
            if (num56 > num53)
              num53 = num56;
          }
          if (num51 < num50)
          {
            int num57 = num50 - num51;
            if (num57 > num54)
              num54 = num57;
          }
        }
      }
      if (num50 == 0)
        num50 = num51;
      int num58 = num52;
      int setValue2 = !(num50 > 0 & num51 > 0) ? num58 + 1 : ((double) (int) Math.Round((double) num51 / (double) num50) < 0.5 ? (num54 >= 1 ? (num54 >= 2 ? (num54 >= 3 ? num58 - 7 : num58 - 6) : num58 - 4) : num58 - 1) : (num53 >= 1 ? (num53 >= 2 ? (num53 >= 3 ? num58 + 7 : num58 + 6) : num58 + 4) : num58 + 1));
      this.ai.VAR_OFFENSIVE_ZONE_IS_ALL_OUT_MODE = 0;
      int num59 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, id1, 1, "pathWar_Offensive", 2)));
      int num60 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimeKeys].GetData2(0, id1, 1, "pathWar_Defensive", 2)));
      int num61 = num59 - num60;
      this.ai.VAR_OFFENSIVE_ZONE_IS_ALL_OUT_MODE = setValue2 < 80 ? (setValue2 < 70 ? (setValue2 <= 60 ? (setValue2 < 40 ? (setValue2 < 30 ? 0 : (num59 < 70 ? 0 : 1)) : (num59 < 50 ? 0 : 1)) : (num59 < 70 ? 1 : 2)) : (num59 < 50 ? 1 : 2)) : 2;
      if (setValue2 < 20)
        setValue2 = 20;
      if (setValue2 > 80)
        setValue2 = 80;
      this.ai.AddLog("OldOffensiveMod: " + num52.ToString());
      this.ai.AddLog("currentOffensiveMode: " + setValue2.ToString());
      this.ai.AddLog("OldOffensiveModFixed: " + setValue1.ToString());
      if (Math.Abs(setValue1 - setValue2) >= 15)
      {
        setValue1 = setValue2;
        this.ai.AddLog("OldOffensiveModFixed IS CHANGED TO CURRENT OFFENSIVE MODE");
      }
      else
        this.ai.AddLog("OldOffensiveModFixed IS UNCHANGED");
      int num62 = setValue1;
      int num63;
      int num64;
      if (num62 >= 50)
      {
        num63 = (int) Math.Round(Math.Ceiling((double) (num47 * num62) / 100.0));
        num64 = num47 - num63;
      }
      else
      {
        --num47;
        if (num47 < 1)
          num47 = 0;
        num64 = (int) Math.Round(Math.Ceiling((double) (num47 * (100 - num62)) / 100.0));
        num63 = num47 - num64;
      }
      if (num63 > 1 & num64 == 0)
      {
        num64 = 1;
        --num63;
      }
      if (num61 > 50)
      {
        if (num47 <= 5 & num64 > 0)
        {
          --num64;
          ++num63;
        }
        if (num47 <= 5 & num64 > 0)
        {
          --num64;
          ++num63;
        }
        if (num47 <= 5 & num64 > 0)
        {
          --num64;
          ++num63;
        }
      }
      else if (num61 > 30)
      {
        if (num47 <= 4 & num64 > 0)
        {
          --num64;
          ++num63;
        }
        if (num47 <= 4 & num64 > 0)
        {
          --num64;
          ++num63;
        }
      }
      else if (num61 > 15)
      {
        if (num47 <= 3 & num64 > 0)
        {
          --num64;
          ++num63;
        }
      }
      else if (num61 > 0 && num47 <= 2 & num64 > 0)
      {
        --num64;
        ++num63;
      }
      this.ai.AddLog("Offensive OHQs: " + num63.ToString() + ", Defensive OHQs: " + num64.ToString());
      this.ai.AddLog("");
      this.ai.AddLog("FIND BEST OFFENSIVE MATCHES");
      if (num63 > num47)
        num63 = num47;
      if (simpleList10.Counter + 1 < num63)
        num63 = simpleList10.Counter + 1;
      int[] numArray1 = new int[this.data.LocCounter + 10 + 1];
      int counter4 = simpleList10.Counter;
      for (tid1 = 0; tid1 <= counter4; ++tid1)
      {
        int num65;
        if (num65 < num63 && simpleList10.Data2[tid1] < 1 & simpleList11.FindData(simpleList10.Id[tid1], 2) < 1)
        {
          int num66 = 0;
          int num67 = 0;
          int index17 = 0;
          int index18 = 0;
          int id5 = 0;
          int x = this.data.UnitObj[simpleList10.Id[tid1]].X;
          int y = this.data.UnitObj[simpleList10.Id[tid1]].Y;
          AIMatrix aiMatrix6 = new AIMatrix(ref this.ai);
          aiMatrix6.SetAllValuesTo(0);
          aiMatrix6.Value[x, y] = 1;
          aiMatrix6.ExpandAndAddValueForSameRegime(49);
          aiMatrix6.ExpandAndAddValueForAnyRegime(99, true);
          aiMatrix6.SetValueXToValueY(0, 9999);
          this.ai.AddLog("For " + this.data.UnitObj[simpleList10.Id[tid1]].Name + ":");
          int num68 = num38 - 1;
          int locationById;
          for (int index19 = 0; index19 <= num68; ++index19)
          {
            int idValue5 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, simpleList5.Id[index19], 12)));
            int num69 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].GetData(6, idValue5, 0)));
            int length5 = this.data.StringListObj[stringListById1].Length;
            for (int index20 = 0; index20 <= length5; ++index20)
            {
              if ((int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index20, 8])) == simpleList5.Id[index19])
              {
                int num70 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index20, 0]));
                int num71 = 50;
                if (num69 == num70)
                  num71 = 100;
                int id6 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].Data[index20, 6]));
                if (id6 > 0)
                {
                  locationById = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id6);
                  if (locationById > -1)
                  {
                    int num72 = aiMatrix6.Value[this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y];
                    if (num72 < 199)
                    {
                      int num73 = (int) Math.Round((double) (num71 * 1000) / (double) num72);
                      if (simpleList1.FindWeight(simpleList10.Id[tid1]) == id6 && this.data.RegimeObj[this.data.MapObj[0].HexObj[this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y].Regime].RegimeRel[this.data.Turn] == 0)
                        num73 *= 3;
                      if (numArray1[locationById] > 0)
                        num73 = (int) Math.Round((double) num73 / (double) (numArray1[locationById] + 1));
                      this.ai.AddLog("*" + this.data.LocObj[locationById].Name + " = " + num73.ToString());
                      if (num73 > num67)
                      {
                        num67 = num73;
                        num66 = num70;
                        id5 = id6;
                        index17 = this.data.LocObj[locationById].X;
                        index18 = this.data.LocObj[locationById].Y;
                      }
                    }
                  }
                }
              }
            }
          }
          if (num67 > 0)
          {
            locationById = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id5);
            int[] numArray2 = numArray1;
            int[] numArray3 = numArray2;
            int index21 = locationById;
            int index22 = index21;
            int num74 = numArray2[index21] + 1;
            numArray3[index22] = num74;
            this.ai.AddLog("====> Assigned to: ==> " + this.data.LocObj[locationById].Name);
            this.ai.AddLog("");
            ++num65;
            simpleList10.Data2[tid1] = 1;
            this.ai.VAR_MATRIX_ZONES.Value[index17, index18] = id5;
            this.data.HistoricalUnitObj[this.data.UnitObj[simpleList10.Id[tid1]].Historical].AIlist = id5;
          }
          else
          {
            this.ai.AddLog("====> NOT ASSIGNED " + this.data.LocObj[locationById].Name);
            this.ai.AddLog("");
          }
        }
      }
      this.ai.AddLog("");
      this.ai.AddLog("");
      this.ai.AddLog("FIND BEST DEFENSIVE ZONE MATCHES");
      if (num64 > num47)
        num64 = num47;
      if (simpleList11.Counter + 1 < num64)
        num64 = simpleList11.Counter + 1;
      int[] numArray4 = new int[this.data.LocCounter + 10 + 1];
      int num75 = 0;
      int counter5 = simpleList11.Counter;
      for (tid1 = 0; tid1 <= counter5; ++tid1)
      {
        if (num75 < num64 && simpleList11.Data2[tid1] < 1 & simpleList10.FindData(simpleList11.Id[tid1], 2) < 1)
        {
          int num76 = 0;
          int num77 = 0;
          int index23 = 0;
          int index24 = 0;
          int id7 = 0;
          int x = this.data.UnitObj[simpleList11.Id[tid1]].X;
          int y = this.data.UnitObj[simpleList11.Id[tid1]].Y;
          AIMatrix aiMatrix7 = new AIMatrix(ref this.ai);
          aiMatrix7.SetAllValuesTo(0);
          aiMatrix7.Value[x, y] = 1;
          aiMatrix7.ExpandAndAddValueForSameRegime(69);
          aiMatrix7.SetValueXToValueY(0, 9999);
          this.ai.AddLog("For " + this.data.UnitObj[simpleList11.Id[tid1]].Name + ":");
          int num78 = num22 - 1;
          for (int index25 = 0; index25 <= num78; ++index25)
          {
            int idValue6 = simpleList2.Id[index25];
            int num79 = simpleList2.Weight[index25];
            int id8 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].GetData(0, idValue6, 6)));
            if (id8 > 0)
            {
              int locationById = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id8);
              if (locationById > -1)
              {
                int num80 = aiMatrix7.Value[this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y];
                if (num80 < 199)
                {
                  int num81 = (int) Math.Round((double) (num79 * 1000) / (double) num80);
                  if (simpleList1.FindWeight(simpleList11.Id[tid1] + 200000) - 200000 == id8)
                    num81 *= 3;
                  if (numArray4[locationById] > 0)
                    num81 *= numArray4[locationById] + 1;
                  this.ai.AddLog("*" + this.data.LocObj[locationById].Name + " = " + num81.ToString());
                  if (num81 > num77)
                  {
                    num77 = num81;
                    num76 = idValue6;
                    id7 = id8;
                    index23 = this.data.LocObj[locationById].X;
                    index24 = this.data.LocObj[locationById].Y;
                  }
                }
              }
            }
          }
          if (num77 > 0)
          {
            int locationById = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id7);
            int[] numArray5 = numArray4;
            int[] numArray6 = numArray5;
            int index26 = locationById;
            int index27 = index26;
            int num82 = numArray5[index26] + 1;
            numArray6[index27] = num82;
            this.ai.AddLog("====> Assigned to: ==> " + this.data.LocObj[locationById].Name);
            this.ai.AddLog("");
            ++num75;
            simpleList11.Data2[tid1] = 1;
            AIMatrix aiMatrix8 = new AIMatrix(ref this.ai);
            aiMatrix8.SetAllValuesTo(0);
            aiMatrix8.Value[index23, index24] = 1;
            aiMatrix8.ExpandAndAddValueForSameRegime(4);
            int mapWidth6 = this.data.MapObj[0].MapWidth;
            for (int index28 = 0; index28 <= mapWidth6; ++index28)
            {
              int mapHeight = this.data.MapObj[0].MapHeight;
              for (int index29 = 0; index29 <= mapHeight; ++index29)
              {
                if (this.data.MapObj[0].HexObj[index28, index29].Regime == this.data.Turn && aiMatrix8.Value[index28, index29] > 0)
                  this.ai.VAR_MATRIX_ZONES.Value[index28, index29] = 200000 + id7;
              }
            }
            this.data.HistoricalUnitObj[this.data.UnitObj[simpleList11.Id[tid1]].Historical].AIlist = 200000 + id7;
          }
        }
      }
      this.ai.AddLog("");
      int counter6 = simpleList2.Counter;
      for (tid1 = 0; tid1 <= counter6; ++tid1)
      {
        this.data.StringListObj[stringListById2].SetData2(0, simpleList2.Id[tid1], 1, "majorAiRegId", 2, this.data.RegimeObj[this.data.Turn].id, true);
        this.data.StringListObj[stringListById2].SetData2(0, simpleList2.Id[tid1], 1, "majorAiEnemyDistance", 2, simpleList2.Data1[tid1], true);
      }
      this.data.StringListObj[this.slotRegimeKeys].SetData2(0, id1, 1, "majorAiOffensiveMode", 2, setValue2, true);
      this.data.StringListObj[this.slotRegimeKeys].SetData2(0, id1, 1, "majorAiOffensiveModeFixed", 2, setValue1, true);
      AIMatrix addvalue = new AIMatrix(ref this.ai);
      int mapWidth7 = this.data.MapObj[0].MapWidth;
      for (int index30 = 0; index30 <= mapWidth7; ++index30)
      {
        int mapHeight = this.data.MapObj[0].MapHeight;
        for (int index31 = 0; index31 <= mapHeight; ++index31)
          addvalue.Value[index30, index31] = this.data.MapObj[0].HexObj[index30, index31].Regime != this.data.Turn ? 0 : 1;
      }
      int num83 = 0;
      int maxy1;
      if ((double) val2_1 < 0.2)
        maxy1 = 2;
      else if ((double) num83 > 0.4)
      {
        maxy1 = 99;
      }
      else
      {
        maxy1 = (int) Math.Round(7.0 * (((double) val2_1 - 0.2) / 0.2));
        if (maxy1 > 6)
          maxy1 = 6;
        if (maxy1 < 3)
          maxy1 = 3;
      }
      AIMatrix mask2 = new AIMatrix(ref this.ai);
      int mapWidth8 = this.data.MapObj[0].MapWidth;
      for (int index32 = 0; index32 <= mapWidth8; ++index32)
      {
        int mapHeight = this.data.MapObj[0].MapHeight;
        for (int index33 = 0; index33 <= mapHeight; ++index33)
        {
          if (this.data.MapObj[0].HexObj[index32, index33].Regime > -1)
          {
            index14 = simpleList5.FindNr(this.data.RegimeObj[this.data.MapObj[0].HexObj[index32, index33].Regime].id);
            if (index14 > -1)
              mask2.Value[index32, index33] = index14 >= num38 ? 0 : 1;
          }
        }
      }
      mask2.AddValue(addvalue, 1);
      if (maxy1 > 0)
        addvalue.ExpandValueForAnyRegimeWithinMask(ref mask2, maxy1);
      int num84 = 0;
      int maxy2;
      if ((double) val2_1 < 0.4)
        maxy2 = 0;
      else if ((double) num84 > 0.8)
      {
        maxy2 = 99;
      }
      else
      {
        maxy2 = (int) Math.Round(6.0 * (((double) val2_1 - 0.4) / 0.4));
        if (maxy2 > 5)
          maxy2 = 5;
        if (maxy2 < 1)
          maxy2 = 1;
      }
      if (maxy2 > 0)
        addvalue.ExpandValueForAnyRegime(maxy2);
      this.ai.MLAMatrix = addvalue;
      AIMatrix aiMatrix9 = new AIMatrix(ref this.ai);
      int mapWidth9 = this.data.MapObj[0].MapWidth;
      for (int index34 = 0; index34 <= mapWidth9; ++index34)
      {
        int mapHeight = this.data.MapObj[0].MapHeight;
        for (int index35 = 0; index35 <= mapHeight; ++index35)
          aiMatrix9.Value[index34, index35] = 0;
      }
      int num85 = num22 - 1;
      for (int index36 = 0; index36 <= num85; ++index36)
      {
        int idValue7 = simpleList2.Id[index36];
        int num86 = simpleList2.Weight[index36];
        int id9 = (int) Math.Round(Conversion.Val(this.data.StringListObj[stringListById1].GetData(0, idValue7, 6)));
        if (id9 > 0)
        {
          int locationById = DrawMod.TGame.HandyFunctionsObj.GetLocationByID(id9);
          if (locationById > -1)
            aiMatrix9.Value[this.data.LocObj[locationById].X, this.data.LocObj[locationById].Y] = 1;
        }
      }
      aiMatrix9.ExpandAndAddValueForAnyRegime(6);
      int mapWidth10 = this.data.MapObj[0].MapWidth;
      for (int index37 = 0; index37 <= mapWidth10; ++index37)
      {
        int mapHeight = this.data.MapObj[0].MapHeight;
        for (int index38 = 0; index38 <= mapHeight; ++index38)
        {
          if (aiMatrix9.Value[index37, index38] == 1)
            this.ai.VAR_MATRIX_RETREAT.Value[index37, index38] = 25;
          else if (aiMatrix9.Value[index37, index38] == 2)
            this.ai.VAR_MATRIX_RETREAT.Value[index37, index38] = 40;
          else if (aiMatrix9.Value[index37, index38] == 3)
            this.ai.VAR_MATRIX_RETREAT.Value[index37, index38] = 50;
          else if (aiMatrix9.Value[index37, index38] == 4)
            this.ai.VAR_MATRIX_RETREAT.Value[index37, index38] = 65;
          else if (aiMatrix9.Value[index37, index38] == 5)
            this.ai.VAR_MATRIX_RETREAT.Value[index37, index38] = 80;
        }
      }
      int[] numArray7 = new int[this.data.RegimeCounter + 1];
      int[] numArray8 = new int[this.data.RegimeCounter + 1];
      int[] numArray9 = new int[this.data.RegimeCounter + 1];
      int regimeCounter3 = this.data.RegimeCounter;
      for (tid1 = 1; tid1 <= regimeCounter3; ++tid1)
      {
        if (tid1 != this.data.Turn)
        {
          numArray7[tid1] = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[tid1].id, 1)));
          numArray8[tid1] = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotregregkeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[tid1].id, 2, "aiIntention", 3)));
          numArray9[tid1] = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotregregkeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[tid1].id, 2, "relation", 3)));
        }
      }
      AIMatrix aiMatrix10 = new AIMatrix(ref this.ai);
      int mapWidth11 = this.data.MapObj[0].MapWidth;
      for (int index39 = 0; index39 <= mapWidth11; ++index39)
      {
        int mapHeight = this.data.MapObj[0].MapHeight;
        for (int index40 = 0; index40 <= mapHeight; ++index40)
        {
          aiMatrix10.Value[index39, index40] = 0;
          index14 = this.data.MapObj[0].HexObj[index39, index40].Regime;
          if (index14 > -1 && index14 != this.data.Turn)
          {
            int num87 = 100;
            if (this.data.RegimeObj[this.data.Turn].RegimeRel[index14] == 0)
              num87 = numArray7[index14] != 1 ? 100 : 50;
            else if (numArray7[index14] == 1)
              num87 = !(numArray8[index14] < 21 | numArray9[index14] < 20) ? (!(numArray8[index14] < 29 | numArray9[index14] < 29) ? (!(numArray8[index14] < 37 | numArray9[index14] < 37) ? (!(numArray8[index14] < 45 | numArray9[index14] < 45) ? 400 : 250) : 150) : 100) : 80;
            else if (numArray7[index14] != 4)
              num87 = !(numArray8[index14] < 21 | numArray9[index14] < 14) ? (!(numArray8[index14] < 29 | numArray9[index14] < 20) ? (!(numArray8[index14] < 37 | numArray9[index14] < 25) ? (!(numArray8[index14] < 45 | numArray9[index14] < 30) ? 800 : 400) : 250) : 170) : 125;
            else if (numArray7[index14] == 4)
              num87 = 400;
            if (this.data.RegimeObj[this.data.Turn].RegimeRel[index14] == 0)
            {
              int nr = simpleList5.FindNr(this.data.RegimeObj[index14].id);
              if (nr > -1 & nr < num38)
              {
                num87 = (int) Math.Round((double) num87 / 2.0);
                if (num87 < 25)
                  num87 = 25;
              }
            }
            if (this.data.MapObj[0].HexObj[index39, index40].UnitCounter <= -1)
              num87 = 0;
            aiMatrix10.Value[index39, index40] = num87;
          }
        }
      }
      aiMatrix10.ExpandValueForSameRegime(19);
      int mapWidth12 = this.data.MapObj[0].MapWidth;
      for (int index41 = 0; index41 <= mapWidth12; ++index41)
      {
        int mapHeight = this.data.MapObj[0].MapHeight;
        for (int index42 = 0; index42 <= mapHeight; ++index42)
        {
          if (this.data.MapObj[0].HexObj[index41, index42].Regime != this.data.Turn & this.data.MapObj[0].HexObj[index41, index42].Regime > -1 && aiMatrix10.Value[index41, index42] == 0)
            aiMatrix10.Value[index41, index42] = 400;
        }
      }
      aiMatrix10.ExpandValueForAnyRegime(1);
      int mapWidth13 = this.data.MapObj[0].MapWidth;
      for (int index43 = 0; index43 <= mapWidth13; ++index43)
      {
        int mapHeight = this.data.MapObj[0].MapHeight;
        for (int index44 = 0; index44 <= mapHeight; ++index44)
        {
          if (this.data.MapObj[0].HexObj[index43, index44].Regime != this.data.Turn)
            aiMatrix10.Value[index43, index44] = 0;
        }
      }
      aiMatrix10.ExpandValueForSameRegime(99);
      AIMatrix aiMatrix11 = aiMatrix10.AverageValuesForSameRegime(2, mask1);
      aiMatrix11.ExpandValueForAnyRegime(20);
      if (this.ai.VAR_DEBUG_ON)
        this.ai.Screenshot("STRENGTH_MATRIX", ref aiMatrix11.Value);
      int mapWidth14 = this.data.MapObj[0].MapWidth;
      for (int index45 = 0; index45 <= mapWidth14; ++index45)
      {
        int mapHeight = this.data.MapObj[0].MapHeight;
        for (int index46 = 0; index46 <= mapHeight; ++index46)
          this.ai.VAR_MATRIX_STRENGTH.Value[index45, index46] = aiMatrix11.Value[index45, index46];
      }
      this.ai.VAR_STRENGTH_MOD_IS_ALSO_COMBAT_ADV_MOD = false;
      this.ai.WriteLog("0009_CustomMatrixes");
    }

    public int CustomRuleHQtoFrontAssign_howmanySSHQperDefensiveZone(int defzoneNumber) => 9;

    public float CustomRuleHQtoFrontAssign_ModifyScore1(
      ref AIMatrix frontlines,
      ref AIFront tempFront,
      int hq,
      int sshq,
      int curEnm,
      int curFr)
    {
      return 1f;
    }

    public int CustomRuleHQToFrontAssign_SetScore(
      int totalScore,
      float score1,
      float score2,
      float score3)
    {
      int num1 = (int) Math.Round((double) score1);
      int num2 = (int) Math.Round((double) score2);
      int num3 = (int) Math.Round((double) score3);
      if (num1 > 30 & num1 < 999)
        num1 = (int) Math.Round(30.0 + (double) (num1 - 30) * 0.8);
      if (num1 > 60 & num1 < 999)
        num1 = (int) Math.Round(60.0 + (double) (num1 - 60) * 0.6);
      if (num1 > 90 & num1 < 999)
        num1 = (int) Math.Round(90.0 + (double) (num1 - 90) * 0.4);
      if (num1 > 120 & num1 < 999)
        num1 = (int) Math.Round(120.0 + (double) (num1 - 120) * 0.2);
      if (num2 > 20 & num2 < 999)
        num2 = (int) Math.Round(20.0 + (double) (num2 - 20) * 0.66);
      if (num2 > 40 & num2 < 999)
        num2 = (int) Math.Round(40.0 + (double) (num2 - 40) * 0.33);
      if (num2 > 60 & num2 < 999)
        num2 = (int) Math.Round(60.0 + (double) (num2 - 60) * 0.33);
      if (num2 > 80 & num2 < 999)
        num2 = (int) Math.Round(80.0 + (double) (num2 - 80) * 0.2);
      return (int) Math.Round((double) (num1 * num2) * (double) score3 / 4.0);
    }

    public float GetUnitPowerModifier(int unr)
    {
      int num1 = (int) Math.Round(Conversion.Val(this.data.StringListObj[DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0))].GetData(0, 42, 2)));
      int regime = this.data.UnitObj[unr].Regime;
      float unitPowerModifier;
      if (DrawMod.TGame.HandyFunctionsObj.IsAlliedOrSelf(regime, this.data.Turn))
      {
        unitPowerModifier = 1f;
      }
      else
      {
        if (this.data.RegimeObj[this.data.Turn].RegimeRel[regime] == 0)
        {
          unitPowerModifier = 1f;
        }
        else
        {
          int num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotregregkeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[regime].id, 2, "aiIntention", 3)));
          int num3 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotregregkeys].GetData3(0, this.data.RegimeObj[this.data.Turn].id, 1, this.data.RegimeObj[regime].id, 2, "relation", 3)));
          if (num3 > 0)
            num3 = num3;
          if (num3 > num2)
            num3 = (int) Math.Round((double) (num3 + num2) / 2.0);
          else if (num2 > num3 & this.data.RegimeObj[regime].AI && num1 > 10)
            num3 = (int) Math.Round((double) (num3 + num2) / 2.0);
          float num4 = 1f - (float) num3 / 100f;
          unitPowerModifier = !(num2 < 10 | num3 < 10) ? (!(num2 < 20 | num3 < 20) ? (!(num2 < 25 | num3 < 25) ? (!(num2 < 30 | num3 < 30) ? (!(num2 < 35 | num3 < 35) ? (!(num2 < 40 | num3 < 40) ? (!(num2 < 40 | num3 < 40) ? (!(num2 < 50 | num3 < 50) ? (!(num2 < 60 | num3 < 60) ? num4 * 0.05f : num4 * 0.1f) : num4 * 0.15f) : num4 * 0.23f) : num4 * 0.3f) : num4 * 0.4f) : num4 * 0.52f) : num4 * 0.65f) : num4 * 0.8f) : num4 * 1f;
        }
        switch ((int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[regime].id, 1))))
        {
          case 2:
            unitPowerModifier *= 0.7f;
            break;
          case 4:
            unitPowerModifier *= 0.35f;
            break;
        }
      }
      if ((double) unitPowerModifier < 0.1)
        unitPowerModifier = 0.1f;
      return unitPowerModifier;
    }

    public bool CustomRuleHQtoFrontAssign_UnitInCorrectFront_SeeSSHQasSeperateHQ(int unr) => this.data.UnitObj[unr].IsHQ ? this.data.UnitObj[unr].HQ == -1 : this.data.UnitObj[unr].HQ > -1 && this.data.UnitObj[this.data.UnitObj[unr].HQ].HQ <= -1;

    public int CustomRuleWorld_ExtraTroopsOnHex(int x, int y, int curTroops)
    {
      int regime = this.data.MapObj[0].HexObj[x, y].Regime;
      int num1 = 0;
      if (regime > 0 && this.data.RegimeObj[this.data.Turn].RegimeRel[regime] == 0 & this.data.Turn != regime && (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[this.data.Turn].id, 1))) == 1)
      {
        int num2 = (int) Math.Round(Conversion.Val(this.data.StringListObj[this.slotRegimes].GetData(0, this.data.RegimeObj[regime].id, 1)));
        if (curTroops < 1 & DrawMod.RandyNumber.Next(0, 100) < 20)
          num1 = 5;
      }
      return num1;
    }

    public bool HasCustumCalls() => true;
  }
}
