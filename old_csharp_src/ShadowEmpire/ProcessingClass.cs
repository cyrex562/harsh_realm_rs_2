// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ProcessingClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class ProcessingClass
  {
    private GameClass game;
    private int[,,] cacheLIShistory;
    private int[,,] cacheLISpoints;
    private int[,,] cacheLIStotalHistory;
    private int[,,] cacheLISorganic;
    private int[,,] cacheLISorganicPercentage;
    private int[,,] cacheLISpull;
    private int[,,] tempLISwithoutLogExt;
    public int plogcounter;
    public string[] plog;

    public ProcessingClass(GameClass tgame)
    {
      this.cacheLIShistory = new int[2, 2, 2];
      this.cacheLISpoints = new int[2, 2, 2];
      this.cacheLIStotalHistory = new int[2, 2, 2];
      this.cacheLISorganic = new int[2, 2, 2];
      this.cacheLISorganicPercentage = new int[2, 2, 2];
      this.cacheLISpull = new int[2, 2, 2];
      this.tempLISwithoutLogExt = new int[2, 2, 2];
      this.plog = new string[1];
      this.game = tgame;
      this.plogcounter = -1;
    }

    public string AutoMoveChange(
      int unr,
      bool setAutoMove,
      bool subordinates,
      int targetX,
      int targetY)
    {
      int num1 = 0;
      int num2 = -1;
      if (unr > -1)
        num2 = !this.game.Data.UnitObj[unr].IsHQ ? this.game.Data.UnitObj[unr].HQ : unr;
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (index == unr | this.game.Data.UnitObj[index].HQ == num2 & subordinates && this.game.Data.UnitObj[index].PreDef == -1 & this.game.Data.UnitObj[index].X > -1)
        {
          if (setAutoMove)
          {
            if (!(this.game.Data.UnitObj[index].X == targetX & this.game.Data.UnitObj[index].Y == targetY))
            {
              this.game.Data.UnitObj[index].autoMoveX = targetX;
              this.game.Data.UnitObj[index].autoMoveY = targetY;
              ++num1;
            }
            else
            {
              this.game.Data.UnitObj[index].autoMoveX = -1;
              this.game.Data.UnitObj[index].autoMoveY = -1;
            }
          }
          else
          {
            this.game.Data.UnitObj[index].autoMoveX = -1;
            this.game.Data.UnitObj[index].autoMoveY = -1;
            ++num1;
          }
        }
      }
      string str1 = "We changed auto-move setting of " + this.game.Data.UnitObj[unr].Name;
      string str2 = num1 <= 1 ? (num1 != 0 ? str1 + ".\r\n" : str1 + ". No units where affected.") : str1 + " and " + (num1 - 1).ToString() + " other subordinate unit(s).\r\n";
      if (setAutoMove)
        str2 += this.AutoMoveExecute(unr, subordinates);
      return str2;
    }

    public string AutoMoveExecute(int unr, bool alsoSubordinates, bool calledFromStartTurn = false)
    {
      string str = "";
      if (Information.IsNothing((object) this.game.EditObj.TempValue[0]))
        this.game.HandyFunctionsObj.RedimTempValue(9999);
      if (Information.IsNothing((object) this.game.EditObj.TempValueSpecial[0]))
        this.game.HandyFunctionsObj.RedimTempValueSpecial(0);
      if (Information.IsNothing((object) this.game.EditObj.TempValueSpecial2[0]))
        this.game.HandyFunctionsObj.RedimTempValueSpecial2(0);
      if (Information.IsNothing((object) this.game.EditObj.TempValue2[0]))
        this.game.HandyFunctionsObj.RedimTempValue2(9999);
      if (Information.IsNothing((object) this.game.EditObj.TempCameFrom[0]))
        this.game.HandyFunctionsObj.RedimTempCameFrom();
      if (Information.IsNothing((object) this.game.EditObj.TempAttack[0]))
        this.game.HandyFunctionsObj.RedimTempAttack(true);
      MapMatrix2 mapMatrix2_1 = this.game.EditObj.TempValue[0].Clone();
      MapMatrix2Coordinate matrix2Coordinate = this.game.EditObj.TempCameFrom[0].Clone();
      MapMatrix2 mapMatrix2_2 = this.game.EditObj.TempValueSpecial[0].Clone();
      MapMatrix2 mapMatrix2_3 = this.game.EditObj.TempValueSpecial2[0].Clone();
      MapMatrix2 mapMatrix2_4 = this.game.EditObj.TempValue2[0].Clone();
      MapMatrix2Plus6 mapMatrix2Plus6 = this.game.EditObj.TempAttack[0].Clone();
      SimpleList simpleList1 = new SimpleList();
      SimpleList simpleList2 = new SimpleList();
      int num1 = -1;
      if (unr > -1)
        num1 = !this.game.Data.UnitObj[unr].IsHQ ? this.game.Data.UnitObj[unr].HQ : unr;
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (unr == -1 | index == unr | this.game.Data.UnitObj[index].HQ == num1 & alsoSubordinates && this.game.Data.UnitObj[index].PreDef == -1 & this.game.Data.UnitObj[index].X > -1 & this.game.Data.UnitObj[index].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index].autoMoveX > -1 && this.game.Data.UnitObj[index].Historical > -1)
        {
          if (this.game.Data.UnitObj[index].autoMoveX > this.game.Data.MapObj[0].MapWidth | this.game.Data.UnitObj[index].autoMoveY > this.game.Data.MapObj[0].MapHeight)
          {
            str = str + this.game.Data.UnitObj[index].Name + " auto-move cancelled because impossible destination.\r\n";
            this.game.Data.UnitObj[index].autoMoveX = -1;
            this.game.Data.UnitObj[index].autoMoveY = -1;
          }
          else
          {
            simpleList1.Add(this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index].Historical].ID, 1, this.game.Data.UnitObj[index].HistoricalSubPart, this.game.Data.UnitObj[index].autoMoveX, this.game.Data.UnitObj[index].autoMoveY, CheckExistence: false);
            simpleList2.AddWeight(this.game.Data.UnitObj[index].autoMoveX * 1000 + this.game.Data.UnitObj[index].autoMoveY, 1, this.game.Data.UnitObj[index].autoMoveX, this.game.Data.UnitObj[index].autoMoveY);
          }
        }
      }
      int counter1 = simpleList2.Counter;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        int targetX = simpleList2.Data1[index1];
        int targetY = simpleList2.Data2[index1];
        AIMatrix aiMatrix = this.game.HandyFunctionsObj.AutoMoveLongRangeMatrix(targetX, targetY, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight);
        int counter2 = simpleList1.Counter;
        for (int index2 = 0; index2 <= counter2; ++index2)
        {
          unr = this.game.HandyFunctionsObj.GetUnitByHistorical(this.game.HandyFunctionsObj.GetHistoricalUnitByID(simpleList1.Id[index2]), simpleList1.Data1[index2]);
          if (unr > -1 && this.game.Data.UnitObj[unr].attachedTo == -1)
          {
            int autoMoveX = this.game.Data.UnitObj[unr].autoMoveX;
            int autoMoveY = this.game.Data.UnitObj[unr].autoMoveY;
            if (autoMoveX == targetX & autoMoveY == targetY && !(autoMoveX == this.game.Data.UnitObj[unr].X & autoMoveY == this.game.Data.UnitObj[unr].Y))
            {
              this.game.HandyFunctionsObj.MakeMovePrediction(unr, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, increaseap: Math.Max(100 - this.game.HandyFunctionsObj.GetLowestAp(unr), 0), ismove: true);
              int num2 = 99999;
              int index3 = -1;
              bool flag1 = false;
              int lowestAp = this.game.HandyFunctionsObj.GetLowestAp(unr);
              int mapWidth = this.game.Data.MapObj[0].MapWidth;
              int index4;
              for (int index5 = 0; index5 <= mapWidth; ++index5)
              {
                int mapHeight = this.game.Data.MapObj[0].MapHeight;
                for (int index6 = 0; index6 <= mapHeight; ++index6)
                {
                  if (aiMatrix.Value[index5, index6] > 0 && aiMatrix.Value[index5, index6] < num2)
                  {
                    if (this.game.EditObj.TempValue[0].Value[index5, index6] <= lowestAp)
                    {
                      if (this.game.Data.MapObj[0].HexObj[index5, index6].UnitCounter < 15)
                      {
                        num2 = aiMatrix.Value[index5, index6];
                        index3 = index5;
                        index4 = index6;
                      }
                    }
                    else
                      flag1 = true;
                  }
                }
              }
              if (index3 > -1)
              {
                if (index3 > -1 & this.game.EditObj.TempValue[0].Value[index3, index4] < 9999 & this.game.EditObj.TempCameFrom[0].Value[index3, index4].onmap)
                {
                  Coordinate coordinate;
                  coordinate.x = index3;
                  coordinate.y = index4;
                  coordinate.onmap = true;
                  bool flag2 = false;
                  int num3 = 0;
                  while (coordinate.onmap)
                  {
                    ++num3;
                    if (lowestAp >= this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y])
                    {
                      coordinate.onmap = false;
                      flag2 = true;
                    }
                    else
                      coordinate = this.game.EditObj.TempCameFrom[0].Value[coordinate.x, coordinate.y];
                    if (num3 > 9999)
                      break;
                  }
                  if (flag2 && !(coordinate.x == this.game.Data.UnitObj[unr].X & coordinate.y == this.game.Data.UnitObj[unr].Y))
                  {
                    OrderResult orderResult = this.ExecuteMovement(unr, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0, coordinate.x, coordinate.y, 0, true, calledFromStartTurn);
                    if (orderResult.BattleIntercept)
                      str = str + "Tried moving " + this.game.Data.UnitObj[unr].Name + " to " + coordinate.x.ToString() + "," + coordinate.y.ToString() + " but suffered intercept fire on " + orderResult.BattleX.ToString() + "," + orderResult.BattleY.ToString() + ".\r\n";
                    else if (orderResult.BattleUnit > -1)
                      str = str + "Tried moving " + this.game.Data.UnitObj[unr].Name + " to " + coordinate.x.ToString() + "," + coordinate.y.ToString() + " but ran into an ambush on " + orderResult.BattleX.ToString() + "," + orderResult.BattleY.ToString() + ".\r\n";
                    else
                      str = str + "Moved " + this.game.Data.UnitObj[unr].Name + " to " + coordinate.x.ToString() + "," + coordinate.y.ToString() + ".\r\n";
                  }
                  if (this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0, autoMoveX, autoMoveY, 0, 2) <= 2)
                  {
                    str = str + this.game.Data.UnitObj[unr].Name + " arrived at (or close to) destination.\r\n";
                    this.game.Data.UnitObj[unr].autoMoveX = -1;
                    this.game.Data.UnitObj[unr].autoMoveY = -1;
                  }
                }
              }
              else if (!flag1)
              {
                if (this.game.Data.UnitObj[unr].attachedTo == -1)
                {
                  str = str + this.game.Data.UnitObj[unr].Name + " did not see a movement path to " + autoMoveX.ToString() + "," + autoMoveY.ToString() + " and dropped out of auto-move.\r\n";
                  this.game.Data.UnitObj[unr].autoMoveX = -1;
                  this.game.Data.UnitObj[unr].autoMoveY = -1;
                }
              }
              else
                str = str + this.game.Data.UnitObj[unr].Name + " did not have the AP to advance at this moment.\r\n";
            }
          }
        }
      }
      this.game.EditObj.TempValue[0] = mapMatrix2_1;
      this.game.EditObj.TempCameFrom[0] = matrix2Coordinate;
      this.game.EditObj.TempValueSpecial[0] = mapMatrix2_2;
      this.game.EditObj.TempValueSpecial2[0] = mapMatrix2_3;
      this.game.EditObj.TempValue2[0] = mapMatrix2_4;
      this.game.EditObj.TempAttack[0] = mapMatrix2Plus6;
      return str;
    }

    public void MakeNewSFTypeModel(int sftypenr)
    {
      int stringListById = this.game.HandyFunctionsObj.GetStringListByID(this.game.Data.SFTypeObj[sftypenr].ModelNameList);
      if (stringListById == -1)
        return;
      int num1 = 0;
      int num2 = 0;
      string Right;
      while (num1 == 0 & num2 < 999)
      {
        int randomFromStringList = this.GetRandomFromStringList(stringListById);
        ++num2;
        Right = this.game.Data.StringListObj[stringListById].Data[randomFromStringList, 1];
        int num3 = -1;
        int sfTypeCounter = this.game.Data.SFTypeCounter;
        for (int index = 0; index <= sfTypeCounter; ++index)
        {
          if (Operators.CompareString(this.game.Data.SFTypeObj[index].ModelName, Right, false) == 0)
          {
            num3 = index;
            break;
          }
        }
        if (num3 == -1)
          num1 = 1;
      }
      this.game.Data.AddSFType();
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter] = this.game.Data.SFTypeObj[sftypenr].Clone();
      int tv10 = -1;
      if (this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelItemType > -1)
      {
        int modelItemType = this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelItemType;
        this.game.Data.AddItemType();
        this.game.Data.ItemTypeObj[this.game.Data.ItemTypeCounter] = this.game.Data.ItemTypeObj[modelItemType].Clone();
        this.game.Data.ItemTypeObj[this.game.Data.ItemTypeCounter].RegimeSpecific = this.game.Data.Turn;
        this.game.Data.ItemTypeObj[this.game.Data.ItemTypeCounter].IsSFType = this.game.Data.SFTypeCounter;
        this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelItemType = this.game.Data.ItemTypeCounter;
        tv10 = this.game.Data.ItemTypeCounter;
      }
      int sfTypeCounter1 = this.game.Data.SFTypeCounter;
      int tempNewLevels = this.game.Data.SFTypeObj[sftypenr].TempNewLevels;
      int tv8_1 = 1;
      this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.SFTypeObj[sftypenr].ModelNewEvent, tv9: sfTypeCounter1, tv7: tempNewLevels, tv8: tv8_1, tv10: tv10);
      int sfTypeCounter2 = this.game.Data.SFTypeCounter;
      int tv7 = 0;
      int tv8_2 = 0;
      int researchCounter = this.game.Data.ResearchCounter;
      for (int index = 0; index <= researchCounter; ++index)
      {
        if (this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelLastState[index] == 0 & this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelImproveEvent[index] > 0 && this.game.Data.RegimeObj[this.game.Data.Turn].ResField[index])
        {
          this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelImproveEvent[index], tv9: sfTypeCounter2, tv7: tv7, tv8: tv8_2, tv10: tv10);
          this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelLastState[index] = 1;
        }
      }
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelName = Right;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].Name = Right;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelIsBase = false;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelBaseModel = sftypenr;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelLevel = this.game.Data.SFTypeObj[sftypenr].TempNewLevels;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelMark = 1;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelVersion = 1;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelRegime = this.game.Data.Turn;
      ++this.game.Data.SFModelIDCounter;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelID = this.game.Data.SFModelIDCounter;
      if (tv10 > -1)
        this.game.Data.ItemTypeObj[tv10].Name = Right;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].LoadSprites();
      if (this.game.Data.SFTypeObj[sftypenr].ModelCostType == -1)
      {
        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
        RegimeClass[] regimeClassArray = regimeObj;
        int turn = this.game.Data.Turn;
        int index = turn;
        regimeClassArray[index].ResPts = regimeObj[turn].ResPts - this.game.Data.SFTypeObj[sftypenr].TempNewCost;
      }
      else
      {
        int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
        int[] numArray = regimeSlot;
        int modelCostType = this.game.Data.SFTypeObj[sftypenr].ModelCostType;
        int index = modelCostType;
        int num4 = regimeSlot[modelCostType] - this.game.Data.SFTypeObj[sftypenr].TempNewCost;
        numArray[index] = num4;
      }
    }

    public void AttachUnit(int attachUnr, int transportUnr)
    {
      this.game.Data.UnitObj[transportUnr].AddTransport(attachUnr);
      this.game.Data.UnitObj[attachUnr].moveMode = this.game.Data.UnitObj[transportUnr].moveMode;
      this.game.Data.UnitObj[attachUnr].attachedTo = transportUnr;
      this.game.Data.UnitObj[attachUnr].FreeCombatX = -1;
      this.game.Data.UnitObj[attachUnr].FreeCombatY = -1;
    }

    public void DetachUnit(int detachUnr, int transportUnr)
    {
      this.game.Data.UnitObj[transportUnr].RemoveTransport(detachUnr);
      this.game.Data.UnitObj[detachUnr].attachedTo = -1;
    }

    public void MakeInitialModels()
    {
      int sfTypeCounter = this.game.Data.SFTypeCounter;
      for (int sftypenr = 0; sftypenr <= sfTypeCounter; ++sftypenr)
      {
        if (this.game.Data.SFTypeObj[sftypenr].ModelInitialForAll)
        {
          int regimeCounter = this.game.Data.RegimeCounter;
          for (int regnr = 0; regnr <= regimeCounter; ++regnr)
            this.MakeInitialSFTypeModel(sftypenr, regnr);
          this.game.Data.SFTypeObj[sftypenr].ModelRegime = -2;
        }
      }
    }

    public void MakeInitialSFTypeModel(int sftypenr, int regnr)
    {
      this.game.Data.AddSFType();
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter] = this.game.Data.SFTypeObj[sftypenr].Clone();
      int tv10 = -1;
      if (this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelItemType > -1)
      {
        int modelItemType = this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelItemType;
        this.game.Data.AddItemType();
        this.game.Data.ItemTypeObj[this.game.Data.ItemTypeCounter] = this.game.Data.ItemTypeObj[modelItemType].Clone();
        this.game.Data.ItemTypeObj[this.game.Data.ItemTypeCounter].RegimeSpecific = regnr;
        this.game.Data.ItemTypeObj[this.game.Data.ItemTypeCounter].IsSFType = this.game.Data.SFTypeCounter;
        this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelItemType = this.game.Data.ItemTypeCounter;
        tv10 = this.game.Data.ItemTypeCounter;
      }
      if (this.game.Data.SFTypeObj[sftypenr].ModelInitialEvent > -1)
      {
        int sfTypeCounter = this.game.Data.SFTypeCounter;
        int tv7 = 0;
        int tv8 = 0;
        this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.SFTypeObj[sftypenr].ModelInitialEvent, tv9: sfTypeCounter, tv7: tv7, tv8: tv8, tv10: tv10);
      }
      int sfTypeCounter1 = this.game.Data.SFTypeCounter;
      int tv7_1 = 0;
      int tv8_1 = 0;
      int researchCounter = this.game.Data.ResearchCounter;
      for (int index = 0; index <= researchCounter; ++index)
      {
        if (this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelLastState[index] == 0 & this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelImproveEvent[index] > 0 && this.game.Data.RegimeObj[regnr].ResField[index])
        {
          this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelImproveEvent[index], tv9: sfTypeCounter1, tv7: tv7_1, tv8: tv8_1, tv10: tv10);
          this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelLastState[index] = 1;
        }
      }
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelRegime = regnr;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelIsBase = false;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].LoadSprites();
      int unitCounter = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.game.Data.UnitObj[index1].PreDef == -1 & this.game.Data.UnitObj[index1].Regime == regnr)
        {
          int sfCount = this.game.Data.UnitObj[index1].SFCount;
          for (int index2 = 0; index2 <= sfCount; ++index2)
          {
            int sf = this.game.Data.UnitObj[index1].SFList[index2];
            if (this.game.Data.SFObj[sf].Type == sftypenr)
              this.game.Data.SFObj[sf].Type = this.game.Data.SFTypeCounter;
          }
        }
      }
    }

    public void MakeSFTypeModelImprovement(int sftypenr)
    {
      string modelName = this.game.Data.SFTypeObj[sftypenr].ModelName;
      this.game.Data.AddSFType();
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter] = this.game.Data.SFTypeObj[sftypenr].Clone();
      int tv10 = -1;
      if (this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelItemType > -1)
      {
        int modelItemType = this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelItemType;
        this.game.Data.AddItemType();
        this.game.Data.ItemTypeObj[this.game.Data.ItemTypeCounter] = this.game.Data.ItemTypeObj[modelItemType].Clone();
        this.game.Data.ItemTypeObj[this.game.Data.ItemTypeCounter].RegimeSpecific = this.game.Data.Turn;
        this.game.Data.ItemTypeObj[this.game.Data.ItemTypeCounter].IsSFType = this.game.Data.SFTypeCounter;
        this.game.Data.ItemTypeObj[this.game.Data.ItemTypeCounter].Blocks = this.game.Data.SFTypeObj[sftypenr].ModelItemType;
        this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelItemType = this.game.Data.ItemTypeCounter;
        tv10 = this.game.Data.ItemTypeCounter;
      }
      int sfTypeCounter1 = this.game.Data.SFTypeCounter;
      int tv7 = 0;
      int tv8 = 0;
      int num1 = 0;
      int researchCounter = this.game.Data.ResearchCounter;
      for (int index = 0; index <= researchCounter; ++index)
      {
        if (this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelLastState[index] == 0 & this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelImproveEvent[index] > 0 && this.game.Data.RegimeObj[this.game.Data.Turn].ResField[index])
        {
          if (this.game.Data.ResearchObj[index].UpgradeCost == -1)
            num1 = -1;
          else if (num1 > -1)
            num1 += this.game.Data.ResearchObj[index].UpgradeCost;
          this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelImproveEvent[index], tv9: sfTypeCounter1, tv7: tv7, tv8: tv8, tv10: tv10);
          this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelLastState[index] = 1;
        }
      }
      if (num1 > -1)
      {
        this.game.Data.SFTypeObj[sftypenr].UpgradeToo = this.game.Data.SFTypeCounter;
        this.game.Data.SFTypeObj[sftypenr].UpgradeCost = (int) Math.Round((double) ((float) num1 * this.game.Data.SFTypeObj[sftypenr].ModelSFTypeUpgrade));
      }
      else
      {
        this.game.Data.SFTypeObj[sftypenr].UpgradeToo = -1;
        this.game.Data.SFTypeObj[sftypenr].UpgradeCost = 0;
      }
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelName = modelName;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].Name = modelName;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelIsBase = false;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelVersion = this.game.Data.SFTypeObj[sftypenr].ModelVersion + 1;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelRegime = this.game.Data.Turn;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelID = this.game.Data.SFTypeObj[sftypenr].ModelID;
      if (tv10 > -1)
        this.game.Data.ItemTypeObj[tv10].Name = modelName;
      int num2 = 1;
      int sfTypeCounter2 = this.game.Data.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter2; ++index)
      {
        if (this.game.Data.SFTypeObj[index].ModelID == this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelID && this.game.Data.SFTypeObj[index].ModelMark > num2)
          num2 = this.game.Data.SFTypeObj[index].ModelMark;
      }
      int sfTypeCounter3 = this.game.Data.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter3; ++index)
      {
        if (this.game.Data.SFTypeObj[index].ModelID == this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelID && this.game.Data.SFTypeObj[index].ModelMark == this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelMark)
        {
          string str;
          if (num2 > 1)
            str = Conversions.ToString(Operators.AddObject((object) this.game.HandyFunctionsObj.GetRomanNumerical(this.game.Data.SFTypeObj[index].ModelMark), NewLateBinding.LateGet((object) null, typeof (Strings), "LCase", new object[1]
            {
              RuntimeHelpers.GetObjectValue(this.game.HandyFunctionsObj.GetAlphabetLetter(this.game.Data.SFTypeObj[index].ModelVersion))
            }, (string[]) null, (System.Type[]) null, (bool[]) null)));
          else
            str = Conversions.ToString(Operators.AddObject((object) "", NewLateBinding.LateGet((object) null, typeof (Strings), "UCase", new object[1]
            {
              RuntimeHelpers.GetObjectValue(this.game.HandyFunctionsObj.GetAlphabetLetter(this.game.Data.SFTypeObj[index].ModelVersion))
            }, (string[]) null, (System.Type[]) null, (bool[]) null)));
          this.game.Data.SFTypeObj[index].Name = modelName + " " + str;
          if (this.game.Data.SFTypeObj[index].ModelItemType > -1)
            this.game.Data.ItemTypeObj[this.game.Data.SFTypeObj[index].ModelItemType].Name = this.game.Data.SFTypeObj[index].Name;
        }
      }
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].LoadSprites();
      if (this.game.Data.SFTypeObj[sftypenr].ModelCostType == -1)
      {
        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
        RegimeClass[] regimeClassArray = regimeObj;
        int turn = this.game.Data.Turn;
        int index = turn;
        regimeClassArray[index].ResPts = regimeObj[turn].ResPts - this.game.Data.SFTypeObj[sftypenr].TempImproveCost;
      }
      else
      {
        int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
        int[] numArray = regimeSlot;
        int modelCostType = this.game.Data.SFTypeObj[sftypenr].ModelCostType;
        int index = modelCostType;
        int num3 = regimeSlot[modelCostType] - this.game.Data.SFTypeObj[sftypenr].TempImproveCost;
        numArray[index] = num3;
      }
    }

    public void MakeSFTypeModelUpgrade(int sftypenr)
    {
      string modelName = this.game.Data.SFTypeObj[sftypenr].ModelName;
      this.game.Data.AddSFType();
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter] = this.game.Data.SFTypeObj[sftypenr].Clone();
      int tv10 = -1;
      if (this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelItemType > -1)
      {
        int modelItemType = this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelItemType;
        this.game.Data.AddItemType();
        this.game.Data.ItemTypeObj[this.game.Data.ItemTypeCounter] = this.game.Data.ItemTypeObj[modelItemType].Clone();
        this.game.Data.ItemTypeObj[this.game.Data.ItemTypeCounter].RegimeSpecific = this.game.Data.Turn;
        this.game.Data.ItemTypeObj[this.game.Data.ItemTypeCounter].IsSFType = this.game.Data.SFTypeCounter;
        this.game.Data.ItemTypeObj[this.game.Data.ItemTypeCounter].Blocks = this.game.Data.SFTypeObj[sftypenr].ModelItemType;
        this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelItemType = this.game.Data.ItemTypeCounter;
        tv10 = this.game.Data.ItemTypeCounter;
      }
      int sfTypeCounter1 = this.game.Data.SFTypeCounter;
      int tempUpgradeLevels = this.game.Data.SFTypeObj[sftypenr].TempUpgradeLevels;
      int tv8_1 = 0;
      this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.SFTypeObj[sftypenr].ModelNewEvent, tv9: sfTypeCounter1, tv7: tempUpgradeLevels, tv8: tv8_1, tv10: tv10);
      int sfTypeCounter2 = this.game.Data.SFTypeCounter;
      int tv7 = 0;
      int tv8_2 = 0;
      int researchCounter = this.game.Data.ResearchCounter;
      for (int index = 0; index <= researchCounter; ++index)
      {
        if (this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelLastState[index] == 0 & this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelImproveEvent[index] > 0 && this.game.Data.RegimeObj[this.game.Data.Turn].ResField[index])
        {
          this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelImproveEvent[index], tv9: sfTypeCounter2, tv7: tv7, tv8: tv8_2, tv10: tv10);
          this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelLastState[index] = 1;
        }
      }
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelName = modelName;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].Name = modelName;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelIsBase = false;
      SFTypeClass[] sfTypeObj1 = this.game.Data.SFTypeObj;
      SFTypeClass[] sfTypeClassArray1 = sfTypeObj1;
      int sfTypeCounter3 = this.game.Data.SFTypeCounter;
      int index1 = sfTypeCounter3;
      sfTypeClassArray1[index1].ModelLevel = sfTypeObj1[sfTypeCounter3].ModelLevel + this.game.Data.SFTypeObj[sftypenr].TempUpgradeLevels;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelMark = this.game.Data.SFTypeObj[sftypenr].ModelMark + 1;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelVersion = 1;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelRegime = this.game.Data.Turn;
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelID = this.game.Data.SFTypeObj[sftypenr].ModelID;
      if (tv10 > -1)
        this.game.Data.ItemTypeObj[tv10].Name = modelName;
      int num1 = 1;
      int sfTypeCounter4 = this.game.Data.SFTypeCounter;
      for (int index2 = 0; index2 <= sfTypeCounter4; ++index2)
      {
        if (this.game.Data.SFTypeObj[index2].ModelID == this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelID && this.game.Data.SFTypeObj[index2].ModelVersion > num1)
          num1 = this.game.Data.SFTypeObj[index2].ModelVersion;
      }
      int sfTypeCounter5 = this.game.Data.SFTypeCounter;
      for (int index3 = 0; index3 <= sfTypeCounter5; ++index3)
      {
        if (this.game.Data.SFTypeObj[index3].ModelID == this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].ModelID)
        {
          string romanNumerical = this.game.HandyFunctionsObj.GetRomanNumerical(this.game.Data.SFTypeObj[index3].ModelMark);
          this.game.Data.SFTypeObj[index3].Name = modelName + " " + romanNumerical;
          if (num1 > 1)
          {
            SFTypeClass[] sfTypeObj2 = this.game.Data.SFTypeObj;
            SFTypeClass[] sfTypeClassArray2 = sfTypeObj2;
            int index4 = index3;
            int index5 = index4;
            sfTypeClassArray2[index5].Name = Conversions.ToString(Operators.AddObject((object) sfTypeObj2[index4].Name, NewLateBinding.LateGet((object) null, typeof (Strings), "LCase", new object[1]
            {
              RuntimeHelpers.GetObjectValue(this.game.HandyFunctionsObj.GetAlphabetLetter(this.game.Data.SFTypeObj[index3].ModelVersion))
            }, (string[]) null, (System.Type[]) null, (bool[]) null)));
          }
          if (this.game.Data.SFTypeObj[index3].ModelItemType > -1)
            this.game.Data.ItemTypeObj[this.game.Data.SFTypeObj[index3].ModelItemType].Name = this.game.Data.SFTypeObj[index3].Name;
        }
      }
      this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].LoadSprites();
      if (this.game.Data.SFTypeObj[sftypenr].ModelCostType == -1)
      {
        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
        RegimeClass[] regimeClassArray = regimeObj;
        int turn = this.game.Data.Turn;
        int index6 = turn;
        regimeClassArray[index6].ResPts = regimeObj[turn].ResPts - this.game.Data.SFTypeObj[sftypenr].TempUpgradeCost;
      }
      else
      {
        int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
        int[] numArray = regimeSlot;
        int modelCostType = this.game.Data.SFTypeObj[sftypenr].ModelCostType;
        int index7 = modelCostType;
        int num2 = regimeSlot[modelCostType] - this.game.Data.SFTypeObj[sftypenr].TempUpgradeCost;
        numArray[index7] = num2;
      }
    }

    public void SetUberOff()
    {
      int mapCounter = this.game.Data.MapCounter;
      for (int index1 = 0; index1 <= mapCounter; ++index1)
      {
        int mapWidth = this.game.Data.MapObj[index1].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; ++index2)
        {
          int mapHeight = this.game.Data.MapObj[index1].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; ++index3)
          {
            if (this.game.Data.MapObj[index1].HexObj[index2, index3].TempOwner > -1)
              this.game.Data.MapObj[index1].HexObj[index2, index3].Regime = this.game.Data.MapObj[index1].HexObj[index2, index3].TempOwner;
          }
        }
      }
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.game.Data.UnitObj[index].TempOwner > -1)
          this.game.Data.UnitObj[index].Regime = this.game.Data.UnitObj[index].TempOwner;
      }
    }

    public void SetUberOn()
    {
      int mapCounter = this.game.Data.MapCounter;
      for (int index1 = 0; index1 <= mapCounter; ++index1)
      {
        int mapWidth = this.game.Data.MapObj[index1].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; ++index2)
        {
          int mapHeight = this.game.Data.MapObj[index1].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; ++index3)
          {
            this.game.Data.MapObj[index1].HexObj[index2, index3].TempOwner = -1;
            int regime = this.game.Data.MapObj[index1].HexObj[index2, index3].Regime;
            if (regime > -1 && this.game.Data.RegimeObj[regime].UberRegime == this.game.Data.Turn)
            {
              this.game.Data.MapObj[index1].HexObj[index2, index3].TempOwner = this.game.Data.MapObj[index1].HexObj[index2, index3].Regime;
              this.game.Data.MapObj[index1].HexObj[index2, index3].Regime = this.game.Data.RegimeObj[regime].UberRegime;
            }
          }
        }
      }
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        int regime = this.game.Data.UnitObj[index].Regime;
        this.game.Data.UnitObj[index].TempOwner = -1;
        if (regime > -1 && this.game.Data.RegimeObj[regime].UberRegime == this.game.Data.Turn & this.game.Data.RegimeObj[regime].UberRegime > -1)
        {
          this.game.Data.UnitObj[index].TempOwner = regime;
          this.game.Data.UnitObj[index].Regime = this.game.Data.RegimeObj[regime].UberRegime;
        }
      }
    }

    public int GetRandomFromStringList(int nr, int coluse = 0)
    {
      int length1 = this.game.Data.StringListObj[nr].Length;
      int num1;
      for (int index = 0; index <= length1; ++index)
      {
        if (coluse == -1)
          ++num1;
        else
          num1 = (int) Math.Round((double) num1 + Conversion.Val(this.game.Data.StringListObj[nr].Data[index, coluse]));
      }
      if (num1 < 1)
        return -1;
      int num2 = (int) Math.Round((double) (1f + Conversion.Int(VBMath.Rnd() * (float) num1)));
      int num3 = 0;
      int length2 = this.game.Data.StringListObj[nr].Length;
      for (int randomFromStringList = 0; randomFromStringList <= length2; ++randomFromStringList)
      {
        if (coluse == -1)
          ++num3;
        else
          num3 = (int) Math.Round((double) num3 + Conversion.Val(this.game.Data.StringListObj[nr].Data[randomFromStringList, coluse]));
        if (num2 <= num3)
          return randomFromStringList;
      }
      return -1;
    }

    public int GetRandomFromStringList2(int nr, int coluse = 0, int blockcoluse = -1)
    {
      int length1 = this.game.Data.StringListObj[nr].Length;
      int num1;
      for (int index = 0; index <= length1; ++index)
      {
        bool flag = true;
        if (blockcoluse > -1 && Conversion.Val(this.game.Data.StringListObj[nr].Data[index, blockcoluse]) >= 1.0)
          flag = false;
        if (flag)
        {
          if (coluse == -1)
            ++num1;
          else
            num1 = (int) Math.Round((double) num1 + Conversion.Val(this.game.Data.StringListObj[nr].Data[index, coluse]));
        }
      }
      if (num1 < 1)
        return -1;
      int num2 = (int) Math.Round((double) (1f + Conversion.Int(VBMath.Rnd() * (float) num1)));
      int num3 = 0;
      int length2 = this.game.Data.StringListObj[nr].Length;
      for (int randomFromStringList2 = 0; randomFromStringList2 <= length2; ++randomFromStringList2)
      {
        bool flag = true;
        if (blockcoluse > -1 && Conversion.Val(this.game.Data.StringListObj[nr].Data[randomFromStringList2, blockcoluse]) >= 1.0)
          flag = false;
        if (flag)
        {
          if (coluse == -1)
            ++num3;
          else
            num3 = (int) Math.Round((double) num3 + Conversion.Val(this.game.Data.StringListObj[nr].Data[randomFromStringList2, coluse]));
          if (num2 <= num3)
            return randomFromStringList2;
        }
      }
      return -1;
    }

    public void SwapOfficerOtherData(int regnr, int his1, int his2, int unr, ref DataClass tData)
    {
      bool flag;
      if (Information.IsNothing((object) tData.HistoricalUnitObj[his1].CommanderName))
        flag = true;
      else if (tData.HistoricalUnitObj[his1].CommanderName.Length < 1)
        flag = true;
      if (tData.Round > 0)
      {
        if (!(tData.RegimeObj[tData.Turn].AI & (double) tData.RuleVar[914] == 1.0) && regnr > -1)
        {
          RegimeClass[] regimeObj1 = tData.RegimeObj;
          RegimeClass[] regimeClassArray1 = regimeObj1;
          int index1 = regnr;
          int index2 = index1;
          regimeClassArray1[index2].ResPts = (int) Math.Round((double) ((float) regimeObj1[index1].ResPts - tData.RuleVar[904]));
          if (tData.HistoricalUnitObj[his1].PP < 0)
          {
            RegimeClass[] regimeObj2 = tData.RegimeObj;
            RegimeClass[] regimeClassArray2 = regimeObj2;
            int index3 = regnr;
            int index4 = index3;
            regimeClassArray2[index4].ResPts = regimeObj2[index3].ResPts - Math.Abs(tData.HistoricalUnitObj[his1].PP);
          }
          if (his2 > -1 && tData.HistoricalUnitObj[his2].PP > 0)
          {
            RegimeClass[] regimeObj3 = tData.RegimeObj;
            RegimeClass[] regimeClassArray3 = regimeObj3;
            int index5 = regnr;
            int index6 = index5;
            regimeClassArray3[index6].ResPts = regimeObj3[index5].ResPts - Math.Abs(tData.HistoricalUnitObj[his2].PP);
          }
        }
        if ((double) tData.RuleVar[907] > 0.0)
        {
          int hisVarCount1 = tData.HistoricalUnitObj[his1].HisVarCount;
          for (int index = 0; index <= hisVarCount1; ++index)
          {
            if ((double) tData.HistoricalUnitObj[his1].HisVarType[index] == (double) tData.RuleVar[907])
              tData.HistoricalUnitObj[his1].HisVarValue[index] = 0;
          }
          if (his2 > -1)
          {
            int hisVarCount2 = tData.HistoricalUnitObj[his2].HisVarCount;
            for (int index = 0; index <= hisVarCount2; ++index)
            {
              if ((double) tData.HistoricalUnitObj[his2].HisVarType[index] == (double) tData.RuleVar[907])
                tData.HistoricalUnitObj[his2].HisVarValue[index] = 0;
            }
          }
        }
      }
      if (his1 == -1)
      {
        tData.UnitObj[unr].Historical = his2;
        tData.HistoricalUnitObj[his2].Pool = false;
      }
      else
      {
        string commanderName = tData.HistoricalUnitObj[his1].CommanderName;
        tData.HistoricalUnitObj[his1].CommanderName = tData.HistoricalUnitObj[his2].CommanderName;
        tData.HistoricalUnitObj[his2].CommanderName = commanderName;
        string descript = tData.HistoricalUnitObj[his1].Descript;
        tData.HistoricalUnitObj[his1].Descript = tData.HistoricalUnitObj[his2].Descript;
        tData.HistoricalUnitObj[his2].Descript = descript;
        string commanderFileName = tData.HistoricalUnitObj[his1].CommanderFileName;
        tData.HistoricalUnitObj[his1].CommanderFileName = tData.HistoricalUnitObj[his2].CommanderFileName;
        tData.HistoricalUnitObj[his2].CommanderFileName = commanderFileName;
        int commanderSpriteId = tData.HistoricalUnitObj[his1].CommanderSpriteID;
        tData.HistoricalUnitObj[his1].CommanderSpriteID = tData.HistoricalUnitObj[his2].CommanderSpriteID;
        tData.HistoricalUnitObj[his2].CommanderSpriteID = commanderSpriteId;
        string overdrawFileName = tData.HistoricalUnitObj[his1].OverdrawFileName;
        tData.HistoricalUnitObj[his1].OverdrawFileName = tData.HistoricalUnitObj[his2].OverdrawFileName;
        tData.HistoricalUnitObj[his2].OverdrawFileName = overdrawFileName;
        int overdrawSpriteId = tData.HistoricalUnitObj[his1].OverdrawSpriteID;
        tData.HistoricalUnitObj[his1].OverdrawSpriteID = tData.HistoricalUnitObj[his2].OverdrawSpriteID;
        tData.HistoricalUnitObj[his2].OverdrawSpriteID = overdrawSpriteId;
        int staffSize = tData.HistoricalUnitObj[his1].StaffSize;
        tData.HistoricalUnitObj[his1].StaffSize = tData.HistoricalUnitObj[his2].StaffSize;
        tData.HistoricalUnitObj[his2].StaffSize = staffSize;
        int combatMod = tData.HistoricalUnitObj[his1].CombatMod;
        tData.HistoricalUnitObj[his1].CombatMod = tData.HistoricalUnitObj[his2].CombatMod;
        tData.HistoricalUnitObj[his2].CombatMod = combatMod;
        int moraleMod = tData.HistoricalUnitObj[his1].MoraleMod;
        tData.HistoricalUnitObj[his1].MoraleMod = tData.HistoricalUnitObj[his2].MoraleMod;
        tData.HistoricalUnitObj[his2].MoraleMod = moraleMod;
        int xp = tData.HistoricalUnitObj[his1].Xp;
        tData.HistoricalUnitObj[his1].Xp = tData.HistoricalUnitObj[his2].Xp;
        tData.HistoricalUnitObj[his2].Xp = xp;
        int tempVar1 = tData.HistoricalUnitObj[his1].TempVar1;
        tData.HistoricalUnitObj[his1].TempVar1 = tData.HistoricalUnitObj[his2].TempVar1;
        tData.HistoricalUnitObj[his2].TempVar1 = tempVar1;
        int tempVar2 = tData.HistoricalUnitObj[his1].TempVar2;
        tData.HistoricalUnitObj[his1].TempVar2 = tData.HistoricalUnitObj[his2].TempVar2;
        tData.HistoricalUnitObj[his2].TempVar2 = tempVar2;
        int tempVar3 = tData.HistoricalUnitObj[his1].TempVar3;
        tData.HistoricalUnitObj[his1].TempVar3 = tData.HistoricalUnitObj[his2].TempVar3;
        tData.HistoricalUnitObj[his2].TempVar3 = tempVar3;
        int pp = tData.HistoricalUnitObj[his1].PP;
        tData.HistoricalUnitObj[his1].PP = tData.HistoricalUnitObj[his2].PP;
        tData.HistoricalUnitObj[his2].PP = pp;
        int people = tData.HistoricalUnitObj[his1].People;
        tData.HistoricalUnitObj[his1].People = tData.HistoricalUnitObj[his2].People;
        tData.HistoricalUnitObj[his2].People = people;
        int tempRegime = tData.HistoricalUnitObj[his1].TempRegime;
        tData.HistoricalUnitObj[his1].TempRegime = tData.HistoricalUnitObj[his2].TempRegime;
        tData.HistoricalUnitObj[his2].TempRegime = tempRegime;
        object[] objArray1 = new object[1];
        object[] objArray2 = new object[1];
        if (tData.HistoricalUnitObj[his1].AutoEventCounter > -1)
        {
          objArray1 = new object[tData.HistoricalUnitObj[his1].AutoEventCounter + 1];
          objArray2 = new object[tData.HistoricalUnitObj[his1].AutoEventCounter + 1];
        }
        int autoEventCounter1 = tData.HistoricalUnitObj[his1].AutoEventCounter;
        for (int index = 0; index <= autoEventCounter1; ++index)
        {
          objArray1[index] = (object) tData.HistoricalUnitObj[his1].AutoEvent[index];
          objArray2[index] = (object) tData.HistoricalUnitObj[his1].AutoChance[index];
        }
        int autoEventCounter2 = tData.HistoricalUnitObj[his1].AutoEventCounter;
        tData.HistoricalUnitObj[his1].AutoEventCounter = tData.HistoricalUnitObj[his2].AutoEventCounter;
        tData.HistoricalUnitObj[his2].AutoEventCounter = autoEventCounter2;
        if (tData.HistoricalUnitObj[his2].AutoEventCounter > -1)
        {
          tData.HistoricalUnitObj[his1].AutoEvent = new int[tData.HistoricalUnitObj[his1].AutoEventCounter + 1];
          tData.HistoricalUnitObj[his1].AutoChance = new int[tData.HistoricalUnitObj[his1].AutoEventCounter + 1];
        }
        else
        {
          tData.HistoricalUnitObj[his1].AutoEvent = new int[1];
          tData.HistoricalUnitObj[his1].AutoChance = new int[1];
        }
        int autoEventCounter3 = tData.HistoricalUnitObj[his1].AutoEventCounter;
        for (int index = 0; index <= autoEventCounter3; ++index)
        {
          tData.HistoricalUnitObj[his1].AutoEvent[index] = tData.HistoricalUnitObj[his2].AutoEvent[index];
          tData.HistoricalUnitObj[his1].AutoChance[index] = tData.HistoricalUnitObj[his2].AutoChance[index];
        }
        if (tData.HistoricalUnitObj[his2].AutoEventCounter > -1)
        {
          tData.HistoricalUnitObj[his2].AutoEvent = new int[tData.HistoricalUnitObj[his2].AutoEventCounter + 1];
          tData.HistoricalUnitObj[his2].AutoChance = new int[tData.HistoricalUnitObj[his2].AutoEventCounter + 1];
        }
        else
        {
          tData.HistoricalUnitObj[his2].AutoEvent = new int[1];
          tData.HistoricalUnitObj[his2].AutoChance = new int[1];
        }
        int autoEventCounter4 = tData.HistoricalUnitObj[his2].AutoEventCounter;
        for (int index = 0; index <= autoEventCounter4; ++index)
        {
          tData.HistoricalUnitObj[his2].AutoEvent[index] = Conversions.ToInteger(objArray1[index]);
          tData.HistoricalUnitObj[his2].AutoChance[index] = Conversions.ToInteger(objArray2[index]);
        }
        object[] objArray3 = new object[tData.HistoricalUnitObj[his1].DeckCardCounter + 1];
        object[] objArray4 = new object[tData.HistoricalUnitObj[his1].DeckCardCounter + 1];
        int deckCardCounter1 = tData.HistoricalUnitObj[his1].DeckCardCounter;
        for (int index = 0; index <= deckCardCounter1; ++index)
        {
          objArray3[index] = (object) tData.HistoricalUnitObj[his1].DeckCard[index];
          objArray4[index] = (object) tData.HistoricalUnitObj[his1].DeckChance[index];
        }
        int deckCardCounter2 = tData.HistoricalUnitObj[his1].DeckCardCounter;
        tData.HistoricalUnitObj[his1].DeckCardCounter = tData.HistoricalUnitObj[his2].DeckCardCounter;
        tData.HistoricalUnitObj[his2].DeckCardCounter = deckCardCounter2;
        tData.HistoricalUnitObj[his1].DeckCard = new int[tData.HistoricalUnitObj[his1].DeckCardCounter + 1];
        tData.HistoricalUnitObj[his1].DeckChance = new int[tData.HistoricalUnitObj[his1].DeckCardCounter + 1];
        int deckCardCounter3 = tData.HistoricalUnitObj[his1].DeckCardCounter;
        for (int index = 0; index <= deckCardCounter3; ++index)
        {
          tData.HistoricalUnitObj[his1].DeckCard[index] = tData.HistoricalUnitObj[his2].DeckCard[index];
          tData.HistoricalUnitObj[his1].DeckChance[index] = tData.HistoricalUnitObj[his2].DeckChance[index];
        }
        tData.HistoricalUnitObj[his2].DeckCard = new int[tData.HistoricalUnitObj[his2].DeckCardCounter + 1];
        tData.HistoricalUnitObj[his2].DeckChance = new int[tData.HistoricalUnitObj[his2].DeckCardCounter + 1];
        int deckCardCounter4 = tData.HistoricalUnitObj[his2].DeckCardCounter;
        for (int index = 0; index <= deckCardCounter4; ++index)
        {
          tData.HistoricalUnitObj[his2].DeckCard[index] = Conversions.ToInteger(objArray3[index]);
          tData.HistoricalUnitObj[his2].DeckChance[index] = Conversions.ToInteger(objArray4[index]);
        }
        object[] objArray5 = new object[tData.HistoricalUnitObj[his1].HisVarCount + 1];
        object[] objArray6 = new object[tData.HistoricalUnitObj[his1].HisVarCount + 1];
        object[] objArray7 = new object[tData.HistoricalUnitObj[his1].HisVarCount + 1];
        object[] objArray8 = new object[tData.HistoricalUnitObj[his1].HisVarCount + 1];
        int hisVarCount3 = tData.HistoricalUnitObj[his1].HisVarCount;
        for (int index = 0; index <= hisVarCount3; ++index)
        {
          objArray5[index] = (object) tData.HistoricalUnitObj[his1].HisVarType[index];
          objArray6[index] = (object) tData.HistoricalUnitObj[his1].HisVarValue[index];
          objArray8[index] = (object) tData.HistoricalUnitObj[his1].HisVarNato[index];
          objArray7[index] = (object) tData.HistoricalUnitObj[his1].HisVarSmall[index];
        }
        int hisVarCount4 = tData.HistoricalUnitObj[his1].HisVarCount;
        tData.HistoricalUnitObj[his1].HisVarCount = tData.HistoricalUnitObj[his2].HisVarCount;
        tData.HistoricalUnitObj[his2].HisVarCount = hisVarCount4;
        tData.HistoricalUnitObj[his1].HisVarType = new int[tData.HistoricalUnitObj[his1].HisVarCount + 1];
        tData.HistoricalUnitObj[his1].HisVarValue = new int[tData.HistoricalUnitObj[his1].HisVarCount + 1];
        tData.HistoricalUnitObj[his1].HisVarNato = new int[tData.HistoricalUnitObj[his1].HisVarCount + 1];
        tData.HistoricalUnitObj[his1].HisVarSmall = new int[tData.HistoricalUnitObj[his1].HisVarCount + 1];
        int hisVarCount5 = tData.HistoricalUnitObj[his1].HisVarCount;
        for (int index = 0; index <= hisVarCount5; ++index)
        {
          tData.HistoricalUnitObj[his1].HisVarType[index] = tData.HistoricalUnitObj[his2].HisVarType[index];
          tData.HistoricalUnitObj[his1].HisVarValue[index] = tData.HistoricalUnitObj[his2].HisVarValue[index];
          tData.HistoricalUnitObj[his1].HisVarNato[index] = tData.HistoricalUnitObj[his2].HisVarNato[index];
          tData.HistoricalUnitObj[his1].HisVarSmall[index] = tData.HistoricalUnitObj[his2].HisVarSmall[index];
        }
        tData.HistoricalUnitObj[his2].HisVarType = new int[tData.HistoricalUnitObj[his2].HisVarCount + 1];
        tData.HistoricalUnitObj[his2].HisVarValue = new int[tData.HistoricalUnitObj[his2].HisVarCount + 1];
        tData.HistoricalUnitObj[his2].HisVarNato = new int[tData.HistoricalUnitObj[his2].HisVarCount + 1];
        tData.HistoricalUnitObj[his2].HisVarSmall = new int[tData.HistoricalUnitObj[his2].HisVarCount + 1];
        int hisVarCount6 = tData.HistoricalUnitObj[his2].HisVarCount;
        for (int index = 0; index <= hisVarCount6; ++index)
        {
          tData.HistoricalUnitObj[his2].HisVarType[index] = Conversions.ToInteger(objArray5[index]);
          tData.HistoricalUnitObj[his2].HisVarValue[index] = Conversions.ToInteger(objArray6[index]);
          tData.HistoricalUnitObj[his2].HisVarNato[index] = Conversions.ToInteger(objArray8[index]);
          tData.HistoricalUnitObj[his2].HisVarSmall[index] = Conversions.ToInteger(objArray7[index]);
        }
        if ((double) tData.RuleVar[355] == 0.0)
        {
          tData.HistoricalUnitObj[his1].HandCardCounter = -1;
          tData.HistoricalUnitObj[his1].HandCard = new int[1];
          tData.HistoricalUnitObj[his2].HandCardCounter = -1;
          tData.HistoricalUnitObj[his2].HandCard = new int[1];
        }
        else if ((double) tData.RuleVar[355] == 1.0)
        {
          object[] objArray9 = new object[tData.HistoricalUnitObj[his1].HandCardCounter + 1];
          int handCardCounter1 = tData.HistoricalUnitObj[his1].HandCardCounter;
          for (int index = 0; index <= handCardCounter1; ++index)
            objArray9[index] = (object) tData.HistoricalUnitObj[his1].HandCard[index];
          int handCardCounter2 = tData.HistoricalUnitObj[his1].HandCardCounter;
          tData.HistoricalUnitObj[his1].HandCardCounter = tData.HistoricalUnitObj[his2].HandCardCounter;
          tData.HistoricalUnitObj[his2].HandCardCounter = handCardCounter2;
          tData.HistoricalUnitObj[his1].HandCard = new int[tData.HistoricalUnitObj[his1].HandCardCounter + 1];
          int handCardCounter3 = tData.HistoricalUnitObj[his1].HandCardCounter;
          for (int index = 0; index <= handCardCounter3; ++index)
            tData.HistoricalUnitObj[his1].HandCard[index] = tData.HistoricalUnitObj[his2].HandCard[index];
          tData.HistoricalUnitObj[his2].HandCard = new int[tData.HistoricalUnitObj[his2].HandCardCounter + 1];
          int handCardCounter4 = tData.HistoricalUnitObj[his2].HandCardCounter;
          for (int index = 0; index <= handCardCounter4; ++index)
            tData.HistoricalUnitObj[his2].HandCard[index] = Conversions.ToInteger(objArray9[index]);
        }
        if (!flag)
          return;
        tData.RemoveHistoricalUnit(his2);
      }
    }

    public void SwapOfficer(int regnr, int his1, int his2, int unr)
    {
      bool flag;
      if (Information.IsNothing((object) this.game.Data.HistoricalUnitObj[his1].CommanderName))
        flag = true;
      else if (this.game.Data.HistoricalUnitObj[his1].CommanderName.Length < 1)
        flag = true;
      if (this.game.Data.Round > 0)
      {
        if (!(this.game.Data.RegimeObj[this.game.Data.Turn].AI & (double) this.game.Data.RuleVar[914] == 1.0))
        {
          RegimeClass[] regimeObj1 = this.game.Data.RegimeObj;
          RegimeClass[] regimeClassArray1 = regimeObj1;
          int index1 = regnr;
          int index2 = index1;
          regimeClassArray1[index2].ResPts = (int) Math.Round((double) ((float) regimeObj1[index1].ResPts - this.game.Data.RuleVar[904]));
          if (this.game.Data.HistoricalUnitObj[his1].PP < 0)
          {
            RegimeClass[] regimeObj2 = this.game.Data.RegimeObj;
            RegimeClass[] regimeClassArray2 = regimeObj2;
            int index3 = regnr;
            int index4 = index3;
            regimeClassArray2[index4].ResPts = regimeObj2[index3].ResPts - Math.Abs(this.game.Data.HistoricalUnitObj[his1].PP);
          }
          if (his2 > -1 && this.game.Data.HistoricalUnitObj[his2].PP > 0)
          {
            RegimeClass[] regimeObj3 = this.game.Data.RegimeObj;
            RegimeClass[] regimeClassArray3 = regimeObj3;
            int index5 = regnr;
            int index6 = index5;
            regimeClassArray3[index6].ResPts = regimeObj3[index5].ResPts - Math.Abs(this.game.Data.HistoricalUnitObj[his2].PP);
          }
        }
        if ((double) this.game.Data.RuleVar[907] > 0.0)
        {
          int hisVarCount1 = this.game.Data.HistoricalUnitObj[his1].HisVarCount;
          for (int index = 0; index <= hisVarCount1; ++index)
          {
            if ((double) this.game.Data.HistoricalUnitObj[his1].HisVarType[index] == (double) this.game.Data.RuleVar[907])
              this.game.Data.HistoricalUnitObj[his1].HisVarValue[index] = 0;
          }
          if (his2 > -1)
          {
            int hisVarCount2 = this.game.Data.HistoricalUnitObj[his2].HisVarCount;
            for (int index = 0; index <= hisVarCount2; ++index)
            {
              if ((double) this.game.Data.HistoricalUnitObj[his2].HisVarType[index] == (double) this.game.Data.RuleVar[907])
                this.game.Data.HistoricalUnitObj[his2].HisVarValue[index] = 0;
            }
          }
        }
      }
      if (his1 == -1)
      {
        this.game.Data.UnitObj[unr].Historical = his2;
        this.game.Data.HistoricalUnitObj[his2].Pool = false;
      }
      else
      {
        string commanderName = this.game.Data.HistoricalUnitObj[his1].CommanderName;
        this.game.Data.HistoricalUnitObj[his1].CommanderName = this.game.Data.HistoricalUnitObj[his2].CommanderName;
        this.game.Data.HistoricalUnitObj[his2].CommanderName = commanderName;
        string descript = this.game.Data.HistoricalUnitObj[his1].Descript;
        this.game.Data.HistoricalUnitObj[his1].Descript = this.game.Data.HistoricalUnitObj[his2].Descript;
        this.game.Data.HistoricalUnitObj[his2].Descript = descript;
        string commanderFileName = this.game.Data.HistoricalUnitObj[his1].CommanderFileName;
        this.game.Data.HistoricalUnitObj[his1].CommanderFileName = this.game.Data.HistoricalUnitObj[his2].CommanderFileName;
        this.game.Data.HistoricalUnitObj[his2].CommanderFileName = commanderFileName;
        int commanderSpriteId = this.game.Data.HistoricalUnitObj[his1].CommanderSpriteID;
        this.game.Data.HistoricalUnitObj[his1].CommanderSpriteID = this.game.Data.HistoricalUnitObj[his2].CommanderSpriteID;
        this.game.Data.HistoricalUnitObj[his2].CommanderSpriteID = commanderSpriteId;
        string overdrawFileName = this.game.Data.HistoricalUnitObj[his1].OverdrawFileName;
        this.game.Data.HistoricalUnitObj[his1].OverdrawFileName = this.game.Data.HistoricalUnitObj[his2].OverdrawFileName;
        this.game.Data.HistoricalUnitObj[his2].OverdrawFileName = overdrawFileName;
        int overdrawSpriteId = this.game.Data.HistoricalUnitObj[his1].OverdrawSpriteID;
        this.game.Data.HistoricalUnitObj[his1].OverdrawSpriteID = this.game.Data.HistoricalUnitObj[his2].OverdrawSpriteID;
        this.game.Data.HistoricalUnitObj[his2].OverdrawSpriteID = overdrawSpriteId;
        int staffSize = this.game.Data.HistoricalUnitObj[his1].StaffSize;
        this.game.Data.HistoricalUnitObj[his1].StaffSize = this.game.Data.HistoricalUnitObj[his2].StaffSize;
        this.game.Data.HistoricalUnitObj[his2].StaffSize = staffSize;
        int combatMod = this.game.Data.HistoricalUnitObj[his1].CombatMod;
        this.game.Data.HistoricalUnitObj[his1].CombatMod = this.game.Data.HistoricalUnitObj[his2].CombatMod;
        this.game.Data.HistoricalUnitObj[his2].CombatMod = combatMod;
        int moraleMod = this.game.Data.HistoricalUnitObj[his1].MoraleMod;
        this.game.Data.HistoricalUnitObj[his1].MoraleMod = this.game.Data.HistoricalUnitObj[his2].MoraleMod;
        this.game.Data.HistoricalUnitObj[his2].MoraleMod = moraleMod;
        int xp = this.game.Data.HistoricalUnitObj[his1].Xp;
        this.game.Data.HistoricalUnitObj[his1].Xp = this.game.Data.HistoricalUnitObj[his2].Xp;
        this.game.Data.HistoricalUnitObj[his2].Xp = xp;
        int tempVar1 = this.game.Data.HistoricalUnitObj[his1].TempVar1;
        this.game.Data.HistoricalUnitObj[his1].TempVar1 = this.game.Data.HistoricalUnitObj[his2].TempVar1;
        this.game.Data.HistoricalUnitObj[his2].TempVar1 = tempVar1;
        int tempVar2 = this.game.Data.HistoricalUnitObj[his1].TempVar2;
        this.game.Data.HistoricalUnitObj[his1].TempVar2 = this.game.Data.HistoricalUnitObj[his2].TempVar2;
        this.game.Data.HistoricalUnitObj[his2].TempVar2 = tempVar2;
        int tempVar3 = this.game.Data.HistoricalUnitObj[his1].TempVar3;
        this.game.Data.HistoricalUnitObj[his1].TempVar3 = this.game.Data.HistoricalUnitObj[his2].TempVar3;
        this.game.Data.HistoricalUnitObj[his2].TempVar3 = tempVar3;
        int pp = this.game.Data.HistoricalUnitObj[his1].PP;
        this.game.Data.HistoricalUnitObj[his1].PP = this.game.Data.HistoricalUnitObj[his2].PP;
        this.game.Data.HistoricalUnitObj[his2].PP = pp;
        int people = this.game.Data.HistoricalUnitObj[his1].People;
        this.game.Data.HistoricalUnitObj[his1].People = this.game.Data.HistoricalUnitObj[his2].People;
        this.game.Data.HistoricalUnitObj[his2].People = people;
        int tempRegime = this.game.Data.HistoricalUnitObj[his1].TempRegime;
        this.game.Data.HistoricalUnitObj[his1].TempRegime = this.game.Data.HistoricalUnitObj[his2].TempRegime;
        this.game.Data.HistoricalUnitObj[his2].TempRegime = tempRegime;
        object[] objArray1 = new object[1];
        object[] objArray2 = new object[1];
        if (this.game.Data.HistoricalUnitObj[his1].AutoEventCounter > -1)
        {
          objArray1 = new object[this.game.Data.HistoricalUnitObj[his1].AutoEventCounter + 1];
          objArray2 = new object[this.game.Data.HistoricalUnitObj[his1].AutoEventCounter + 1];
        }
        int autoEventCounter1 = this.game.Data.HistoricalUnitObj[his1].AutoEventCounter;
        for (int index = 0; index <= autoEventCounter1; ++index)
        {
          objArray1[index] = (object) this.game.Data.HistoricalUnitObj[his1].AutoEvent[index];
          objArray2[index] = (object) this.game.Data.HistoricalUnitObj[his1].AutoChance[index];
        }
        int autoEventCounter2 = this.game.Data.HistoricalUnitObj[his1].AutoEventCounter;
        this.game.Data.HistoricalUnitObj[his1].AutoEventCounter = this.game.Data.HistoricalUnitObj[his2].AutoEventCounter;
        this.game.Data.HistoricalUnitObj[his2].AutoEventCounter = autoEventCounter2;
        if (this.game.Data.HistoricalUnitObj[his2].AutoEventCounter > -1)
        {
          this.game.Data.HistoricalUnitObj[his1].AutoEvent = new int[this.game.Data.HistoricalUnitObj[his1].AutoEventCounter + 1];
          this.game.Data.HistoricalUnitObj[his1].AutoChance = new int[this.game.Data.HistoricalUnitObj[his1].AutoEventCounter + 1];
        }
        else
        {
          this.game.Data.HistoricalUnitObj[his1].AutoEvent = new int[1];
          this.game.Data.HistoricalUnitObj[his1].AutoChance = new int[1];
        }
        int autoEventCounter3 = this.game.Data.HistoricalUnitObj[his1].AutoEventCounter;
        for (int index = 0; index <= autoEventCounter3; ++index)
        {
          this.game.Data.HistoricalUnitObj[his1].AutoEvent[index] = this.game.Data.HistoricalUnitObj[his2].AutoEvent[index];
          this.game.Data.HistoricalUnitObj[his1].AutoChance[index] = this.game.Data.HistoricalUnitObj[his2].AutoChance[index];
        }
        if (this.game.Data.HistoricalUnitObj[his2].AutoEventCounter > -1)
        {
          this.game.Data.HistoricalUnitObj[his2].AutoEvent = new int[this.game.Data.HistoricalUnitObj[his2].AutoEventCounter + 1];
          this.game.Data.HistoricalUnitObj[his2].AutoChance = new int[this.game.Data.HistoricalUnitObj[his2].AutoEventCounter + 1];
        }
        else
        {
          this.game.Data.HistoricalUnitObj[his2].AutoEvent = new int[1];
          this.game.Data.HistoricalUnitObj[his2].AutoChance = new int[1];
        }
        int autoEventCounter4 = this.game.Data.HistoricalUnitObj[his2].AutoEventCounter;
        for (int index = 0; index <= autoEventCounter4; ++index)
        {
          this.game.Data.HistoricalUnitObj[his2].AutoEvent[index] = Conversions.ToInteger(objArray1[index]);
          this.game.Data.HistoricalUnitObj[his2].AutoChance[index] = Conversions.ToInteger(objArray2[index]);
        }
        object[] objArray3 = new object[this.game.Data.HistoricalUnitObj[his1].DeckCardCounter + 1];
        object[] objArray4 = new object[this.game.Data.HistoricalUnitObj[his1].DeckCardCounter + 1];
        int deckCardCounter1 = this.game.Data.HistoricalUnitObj[his1].DeckCardCounter;
        for (int index = 0; index <= deckCardCounter1; ++index)
        {
          objArray3[index] = (object) this.game.Data.HistoricalUnitObj[his1].DeckCard[index];
          objArray4[index] = (object) this.game.Data.HistoricalUnitObj[his1].DeckChance[index];
        }
        int deckCardCounter2 = this.game.Data.HistoricalUnitObj[his1].DeckCardCounter;
        this.game.Data.HistoricalUnitObj[his1].DeckCardCounter = this.game.Data.HistoricalUnitObj[his2].DeckCardCounter;
        this.game.Data.HistoricalUnitObj[his2].DeckCardCounter = deckCardCounter2;
        this.game.Data.HistoricalUnitObj[his1].DeckCard = new int[this.game.Data.HistoricalUnitObj[his1].DeckCardCounter + 1];
        this.game.Data.HistoricalUnitObj[his1].DeckChance = new int[this.game.Data.HistoricalUnitObj[his1].DeckCardCounter + 1];
        int deckCardCounter3 = this.game.Data.HistoricalUnitObj[his1].DeckCardCounter;
        for (int index = 0; index <= deckCardCounter3; ++index)
        {
          this.game.Data.HistoricalUnitObj[his1].DeckCard[index] = this.game.Data.HistoricalUnitObj[his2].DeckCard[index];
          this.game.Data.HistoricalUnitObj[his1].DeckChance[index] = this.game.Data.HistoricalUnitObj[his2].DeckChance[index];
        }
        this.game.Data.HistoricalUnitObj[his2].DeckCard = new int[this.game.Data.HistoricalUnitObj[his2].DeckCardCounter + 1];
        this.game.Data.HistoricalUnitObj[his2].DeckChance = new int[this.game.Data.HistoricalUnitObj[his2].DeckCardCounter + 1];
        int deckCardCounter4 = this.game.Data.HistoricalUnitObj[his2].DeckCardCounter;
        for (int index = 0; index <= deckCardCounter4; ++index)
        {
          this.game.Data.HistoricalUnitObj[his2].DeckCard[index] = Conversions.ToInteger(objArray3[index]);
          this.game.Data.HistoricalUnitObj[his2].DeckChance[index] = Conversions.ToInteger(objArray4[index]);
        }
        object[] objArray5 = new object[this.game.Data.HistoricalUnitObj[his1].HisVarCount + 1];
        object[] objArray6 = new object[this.game.Data.HistoricalUnitObj[his1].HisVarCount + 1];
        object[] objArray7 = new object[this.game.Data.HistoricalUnitObj[his1].HisVarCount + 1];
        object[] objArray8 = new object[this.game.Data.HistoricalUnitObj[his1].HisVarCount + 1];
        int hisVarCount3 = this.game.Data.HistoricalUnitObj[his1].HisVarCount;
        for (int index = 0; index <= hisVarCount3; ++index)
        {
          objArray5[index] = (object) this.game.Data.HistoricalUnitObj[his1].HisVarType[index];
          objArray6[index] = (object) this.game.Data.HistoricalUnitObj[his1].HisVarValue[index];
          objArray8[index] = (object) this.game.Data.HistoricalUnitObj[his1].HisVarNato[index];
          objArray7[index] = (object) this.game.Data.HistoricalUnitObj[his1].HisVarSmall[index];
        }
        int hisVarCount4 = this.game.Data.HistoricalUnitObj[his1].HisVarCount;
        this.game.Data.HistoricalUnitObj[his1].HisVarCount = this.game.Data.HistoricalUnitObj[his2].HisVarCount;
        this.game.Data.HistoricalUnitObj[his2].HisVarCount = hisVarCount4;
        this.game.Data.HistoricalUnitObj[his1].HisVarType = new int[this.game.Data.HistoricalUnitObj[his1].HisVarCount + 1];
        this.game.Data.HistoricalUnitObj[his1].HisVarValue = new int[this.game.Data.HistoricalUnitObj[his1].HisVarCount + 1];
        this.game.Data.HistoricalUnitObj[his1].HisVarNato = new int[this.game.Data.HistoricalUnitObj[his1].HisVarCount + 1];
        this.game.Data.HistoricalUnitObj[his1].HisVarSmall = new int[this.game.Data.HistoricalUnitObj[his1].HisVarCount + 1];
        int hisVarCount5 = this.game.Data.HistoricalUnitObj[his1].HisVarCount;
        for (int index = 0; index <= hisVarCount5; ++index)
        {
          this.game.Data.HistoricalUnitObj[his1].HisVarType[index] = this.game.Data.HistoricalUnitObj[his2].HisVarType[index];
          this.game.Data.HistoricalUnitObj[his1].HisVarValue[index] = this.game.Data.HistoricalUnitObj[his2].HisVarValue[index];
          this.game.Data.HistoricalUnitObj[his1].HisVarNato[index] = this.game.Data.HistoricalUnitObj[his2].HisVarNato[index];
          this.game.Data.HistoricalUnitObj[his1].HisVarSmall[index] = this.game.Data.HistoricalUnitObj[his2].HisVarSmall[index];
        }
        this.game.Data.HistoricalUnitObj[his2].HisVarType = new int[this.game.Data.HistoricalUnitObj[his2].HisVarCount + 1];
        this.game.Data.HistoricalUnitObj[his2].HisVarValue = new int[this.game.Data.HistoricalUnitObj[his2].HisVarCount + 1];
        this.game.Data.HistoricalUnitObj[his2].HisVarNato = new int[this.game.Data.HistoricalUnitObj[his2].HisVarCount + 1];
        this.game.Data.HistoricalUnitObj[his2].HisVarSmall = new int[this.game.Data.HistoricalUnitObj[his2].HisVarCount + 1];
        int hisVarCount6 = this.game.Data.HistoricalUnitObj[his2].HisVarCount;
        for (int index = 0; index <= hisVarCount6; ++index)
        {
          this.game.Data.HistoricalUnitObj[his2].HisVarType[index] = Conversions.ToInteger(objArray5[index]);
          this.game.Data.HistoricalUnitObj[his2].HisVarValue[index] = Conversions.ToInteger(objArray6[index]);
          this.game.Data.HistoricalUnitObj[his2].HisVarNato[index] = Conversions.ToInteger(objArray8[index]);
          this.game.Data.HistoricalUnitObj[his2].HisVarSmall[index] = Conversions.ToInteger(objArray7[index]);
        }
        if ((double) this.game.Data.RuleVar[355] == 0.0)
        {
          this.game.Data.HistoricalUnitObj[his1].HandCardCounter = -1;
          this.game.Data.HistoricalUnitObj[his1].HandCard = new int[1];
          this.game.Data.HistoricalUnitObj[his2].HandCardCounter = -1;
          this.game.Data.HistoricalUnitObj[his2].HandCard = new int[1];
        }
        else if ((double) this.game.Data.RuleVar[355] == 1.0)
        {
          object[] objArray9 = new object[this.game.Data.HistoricalUnitObj[his1].HandCardCounter + 1];
          int handCardCounter1 = this.game.Data.HistoricalUnitObj[his1].HandCardCounter;
          for (int index = 0; index <= handCardCounter1; ++index)
            objArray9[index] = (object) this.game.Data.HistoricalUnitObj[his1].HandCard[index];
          int handCardCounter2 = this.game.Data.HistoricalUnitObj[his1].HandCardCounter;
          this.game.Data.HistoricalUnitObj[his1].HandCardCounter = this.game.Data.HistoricalUnitObj[his2].HandCardCounter;
          this.game.Data.HistoricalUnitObj[his2].HandCardCounter = handCardCounter2;
          this.game.Data.HistoricalUnitObj[his1].HandCard = new int[this.game.Data.HistoricalUnitObj[his1].HandCardCounter + 1];
          int handCardCounter3 = this.game.Data.HistoricalUnitObj[his1].HandCardCounter;
          for (int index = 0; index <= handCardCounter3; ++index)
            this.game.Data.HistoricalUnitObj[his1].HandCard[index] = this.game.Data.HistoricalUnitObj[his2].HandCard[index];
          this.game.Data.HistoricalUnitObj[his2].HandCard = new int[this.game.Data.HistoricalUnitObj[his2].HandCardCounter + 1];
          int handCardCounter4 = this.game.Data.HistoricalUnitObj[his2].HandCardCounter;
          for (int index = 0; index <= handCardCounter4; ++index)
            this.game.Data.HistoricalUnitObj[his2].HandCard[index] = Conversions.ToInteger(objArray9[index]);
        }
        if (!flag)
          return;
        this.game.Data.RemoveHistoricalUnit(his2);
      }
    }

    public void RecruitOfficer(int regnr, bool MakePay, int OverWriteHis = -1, int OverWritePool = -1)
    {
      if (MakePay & this.game.Data.Round > 0)
      {
        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
        RegimeClass[] regimeClassArray = regimeObj;
        int index1 = regnr;
        int index2 = index1;
        regimeClassArray[index2].ResPts = (int) Math.Round((double) ((float) regimeObj[index1].ResPts - this.game.Data.RuleVar[345]));
      }
      int id = this.game.Data.RegimeObj[regnr].OfficerPool;
      if (OverWritePool > -1)
        id = OverWritePool;
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(id);
      if (stringListById1 == -1)
        return;
      int randomFromStringList1 = this.GetRandomFromStringList(stringListById1);
      if (randomFromStringList1 == -1)
        return;
      int index3;
      if (OverWriteHis == -1)
      {
        this.game.Data.AddHistoricalUnit();
        index3 = this.game.Data.HistoricalUnitCounter;
        this.game.Data.HistoricalUnitObj[index3].Pool = true;
      }
      else
      {
        index3 = OverWriteHis;
        this.game.Data.HistoricalUnitObj[index3].Pool = false;
      }
      this.game.Data.HistoricalUnitObj[index3].TempRegime = regnr;
      this.game.Data.HistoricalUnitObj[index3].OverdrawFileName = this.game.Data.StringListObj[stringListById1].Data[randomFromStringList1, 1];
      this.game.Data.HistoricalUnitObj[index3].PP = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[randomFromStringList1, 2]));
      this.game.Data.HistoricalUnitObj[index3].StaffSize = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[randomFromStringList1, 3]));
      this.game.Data.HistoricalUnitObj[index3].CombatMod = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[randomFromStringList1, 4]));
      this.game.Data.HistoricalUnitObj[index3].MoraleMod = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[randomFromStringList1, 5]));
      this.game.Data.HistoricalUnitObj[index3].Descript = this.game.Data.StringListObj[stringListById1].Data[randomFromStringList1, 13];
      this.game.Data.HistoricalUnitObj[index3].TempVar1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[randomFromStringList1, 14]));
      this.game.Data.HistoricalUnitObj[index3].TempVar2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[randomFromStringList1, 15]));
      this.game.Data.HistoricalUnitObj[index3].TempVar3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[randomFromStringList1, 16]));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[randomFromStringList1, 6])));
      if (stringListById2 > -1)
      {
        int randomFromStringList2 = this.GetRandomFromStringList(stringListById2);
        this.game.Data.HistoricalUnitObj[index3].CommanderFileName = this.game.Data.StringListObj[stringListById2].Data[randomFromStringList2, 1];
        if (this.game.Data.StringListObj[stringListById2].Data[randomFromStringList2, 2].Length > 1)
          this.game.Data.HistoricalUnitObj[index3].OverdrawFileName = this.game.Data.StringListObj[stringListById2].Data[randomFromStringList2, 2];
      }
      int num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[randomFromStringList1, 8]));
      for (int index4 = 1; index4 <= num1; ++index4)
      {
        int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[randomFromStringList1, 7])));
        if (stringListById3 > -1)
        {
          int randomFromStringList3 = this.GetRandomFromStringList(stringListById3);
          HistoricalUnitClass[] historicalUnitObj1 = this.game.Data.HistoricalUnitObj;
          HistoricalUnitClass[] historicalUnitClassArray1 = historicalUnitObj1;
          int index5 = index3;
          int index6 = index5;
          historicalUnitClassArray1[index6].DeckCardCounter = historicalUnitObj1[index5].DeckCardCounter + 1;
          this.game.Data.HistoricalUnitObj[index3].DeckCard = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[index3].DeckCard, (Array) new int[this.game.Data.HistoricalUnitObj[index3].DeckCardCounter + 1]);
          this.game.Data.HistoricalUnitObj[index3].DeckChance = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[index3].DeckChance, (Array) new int[this.game.Data.HistoricalUnitObj[index3].DeckCardCounter + 1]);
          this.game.Data.HistoricalUnitObj[index3].DeckCard[this.game.Data.HistoricalUnitObj[index3].DeckCardCounter] = Conversions.ToInteger(this.game.Data.StringListObj[stringListById3].Data[randomFromStringList3, 1]);
          this.game.Data.HistoricalUnitObj[index3].DeckChance[this.game.Data.HistoricalUnitObj[index3].DeckCardCounter] = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[randomFromStringList3, 2]));
          if (Strings.InStr(this.game.Data.HistoricalUnitObj[index3].Descript, this.game.Data.StringListObj[stringListById3].Data[randomFromStringList3, 3]) <= 0)
          {
            HistoricalUnitClass[] historicalUnitObj2 = this.game.Data.HistoricalUnitObj;
            HistoricalUnitClass[] historicalUnitClassArray2 = historicalUnitObj2;
            int index7 = index3;
            int index8 = index7;
            historicalUnitClassArray2[index8].Descript = historicalUnitObj2[index7].Descript + " " + this.game.Data.StringListObj[stringListById3].Data[randomFromStringList3, 3];
          }
        }
      }
      int num2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[randomFromStringList1, 10]));
      for (int index9 = 1; index9 <= num2; ++index9)
      {
        int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[randomFromStringList1, 9])));
        if (stringListById4 > -1)
        {
          int randomFromStringList4 = this.GetRandomFromStringList(stringListById4);
          HistoricalUnitClass[] historicalUnitObj3 = this.game.Data.HistoricalUnitObj;
          HistoricalUnitClass[] historicalUnitClassArray3 = historicalUnitObj3;
          int index10 = index3;
          int index11 = index10;
          historicalUnitClassArray3[index11].AutoEventCounter = historicalUnitObj3[index10].AutoEventCounter + 1;
          this.game.Data.HistoricalUnitObj[index3].AutoEvent = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[index3].AutoEvent, (Array) new int[this.game.Data.HistoricalUnitObj[index3].AutoEventCounter + 1]);
          this.game.Data.HistoricalUnitObj[index3].AutoChance = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[index3].AutoChance, (Array) new int[this.game.Data.HistoricalUnitObj[index3].AutoEventCounter + 1]);
          this.game.Data.HistoricalUnitObj[index3].AutoEvent[this.game.Data.HistoricalUnitObj[index3].AutoEventCounter] = Conversions.ToInteger(this.game.Data.StringListObj[stringListById4].Data[randomFromStringList4, 1]);
          this.game.Data.HistoricalUnitObj[index3].AutoChance[this.game.Data.HistoricalUnitObj[index3].AutoEventCounter] = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].Data[randomFromStringList4, 2]));
          if (Strings.InStr(this.game.Data.HistoricalUnitObj[index3].Descript, this.game.Data.StringListObj[stringListById4].Data[randomFromStringList4, 3]) <= 0)
          {
            HistoricalUnitClass[] historicalUnitObj4 = this.game.Data.HistoricalUnitObj;
            HistoricalUnitClass[] historicalUnitClassArray4 = historicalUnitObj4;
            int index12 = index3;
            int index13 = index12;
            historicalUnitClassArray4[index13].Descript = historicalUnitObj4[index12].Descript + " " + this.game.Data.StringListObj[stringListById4].Data[randomFromStringList4, 3];
          }
        }
      }
      int stringListById5 = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[randomFromStringList1, 11])));
      if (stringListById5 > -1)
      {
        int randomFromStringList5 = this.GetRandomFromStringList(stringListById5);
        this.game.Data.HistoricalUnitObj[index3].CommanderName = this.game.Data.StringListObj[stringListById5].Data[randomFromStringList5, 1];
      }
      int stringListById6 = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[randomFromStringList1, 12])));
      if (stringListById6 > -1)
      {
        int randomFromStringList6 = this.GetRandomFromStringList(stringListById6);
        HistoricalUnitClass[] historicalUnitObj = this.game.Data.HistoricalUnitObj;
        HistoricalUnitClass[] historicalUnitClassArray = historicalUnitObj;
        int index14 = index3;
        int index15 = index14;
        historicalUnitClassArray[index15].CommanderName = historicalUnitObj[index14].CommanderName + " " + this.game.Data.StringListObj[stringListById6].Data[randomFromStringList6, 1];
      }
      this.game.Data.HistoricalUnitObj[index3].LoadSprites();
      if ((double) this.game.Data.RuleVar[843] <= 0.0)
        return;
      this.game.EventRelatedObj.DoCheckSpecificEvent((int) Math.Round((double) this.game.Data.RuleVar[843]));
    }

    public void InitialAPPenalty(int regnr, bool resetAP)
    {
      int mapCounter = this.game.Data.MapCounter;
      for (int index1 = 0; index1 <= mapCounter; ++index1)
      {
        int mapWidth = this.game.Data.MapObj[index1].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; ++index2)
        {
          int mapHeight = this.game.Data.MapObj[index1].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; ++index3)
          {
            if (resetAP)
              this.game.Data.MapObj[index1].HexObj[index2, index3].set_APPenalty(regnr, 0);
            if (resetAP)
              this.game.Data.MapObj[index1].HexObj[index2, index3].set_BattleStack(regnr, 0);
            if (resetAP)
              this.game.Data.MapObj[index1].HexObj[index2, index3].set_BattleStackAir(regnr, 0);
            if (resetAP)
              this.game.Data.MapObj[index1].HexObj[index2, index3].set_BattleStackArt(regnr, 0);
            if (resetAP)
              this.game.Data.MapObj[index1].HexObj[index2, index3].set_BattlePenalty(regnr, 0);
            if (this.game.Data.MapObj[index1].HexObj[index2, index3].Regime != regnr)
            {
              if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[index1].HexObj[index2, index3].LandscapeType].IsSea)
              {
                int num = 0;
                if (this.game.Data.MapObj[index1].HexObj[index2, index3].Regime > -1)
                {
                  if (this.game.Data.RegimeObj[regnr].RegimeRel[this.game.Data.MapObj[index1].HexObj[index2, index3].Regime] == 2)
                    num = 1;
                  if (this.game.Data.RegimeObj[regnr].UberRegime > -1 & this.game.Data.MapObj[index1].HexObj[index2, index3].Regime == this.game.Data.RegimeObj[regnr].UberRegime && (double) this.game.Data.MapObj[index1].HexObj[index2, index3].get_APPenalty(regnr) > (double) this.game.Data.RuleVar[4])
                    this.game.Data.MapObj[index1].HexObj[index2, index3].set_APPenalty(regnr, (int) Math.Round((double) this.game.Data.RuleVar[4]));
                }
                if (num == 0)
                  this.game.Data.MapObj[index1].HexObj[index2, index3].set_APPenalty(regnr, (int) Math.Round((double) this.game.Data.RuleVar[4]));
              }
            }
            else if ((double) this.game.Data.MapObj[index1].HexObj[index2, index3].get_APPenalty(regnr) > (double) this.game.Data.RuleVar[4])
              this.game.Data.MapObj[index1].HexObj[index2, index3].set_APPenalty(regnr, (int) Math.Round((double) this.game.Data.RuleVar[4]));
          }
        }
      }
    }

    public void PlayCard(int regnr, int cardinhandnr, bool dontDelete = false)
    {
      object obj1 = (object) this.game.Data.RegimeObj[regnr].ActionCard[cardinhandnr];
      if (this.game.Data.Product <= 6)
        this.game.Data.RegimeObj[regnr].RemoveActionCard(cardinhandnr);
      if (this.game.Data.Product == 7)
      {
        if (this.game.Data.ActionCardObj[Conversions.ToInteger(obj1)].customCostType == 1 & this.game.Data.ActionCardObj[Conversions.ToInteger(obj1)].customCostQty > 0)
        {
          int stringListById = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 210, 0, 0));
          int setValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "fp", 2))) - this.game.Data.ActionCardObj[Conversions.ToInteger(obj1)].customCostQty;
          this.game.Data.StringListObj[stringListById].SetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "fp", 2, setValue, true);
        }
        else
        {
          RegimeClass[] regimeObj = this.game.Data.RegimeObj;
          RegimeClass[] regimeClassArray = regimeObj;
          int index1 = regnr;
          int index2 = index1;
          regimeClassArray[index2].ResPts = regimeObj[index1].ResPts - this.game.Data.ActionCardObj[Conversions.ToInteger(obj1)].PPCost;
        }
      }
      else
      {
        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
        RegimeClass[] regimeClassArray = regimeObj;
        int index3 = regnr;
        int index4 = index3;
        regimeClassArray[index4].ResPts = regimeObj[index3].ResPts - this.game.Data.ActionCardObj[Conversions.ToInteger(obj1)].PPCost;
      }
      object obj2 = !this.game.Data.ActionCardObj[Conversions.ToInteger(obj1)].UnitSelect ? (object) -1 : (object) this.game.EditObj.UnitSelected;
      this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.ActionCardObj[Conversions.ToInteger(obj1)].ExecuteEvent, this.game.Data.ActionCardObj[Conversions.ToInteger(obj1)].TempVar0, this.game.Data.ActionCardObj[Conversions.ToInteger(obj1)].TempVar1, -1, Conversions.ToInteger(obj2));
      if (this.game.Data.Product > 6 & !dontDelete)
        this.game.Data.RegimeObj[regnr].RemoveActionCard(cardinhandnr);
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
        this.game.Data.UnitObj[index].LastAP = -1;
    }

    public void PlayCardByUnit(int unr, int cardnr)
    {
      int regime = this.game.Data.UnitObj[unr].Regime;
      int historical = this.game.Data.UnitObj[unr].Historical;
      int tv3 = !this.game.Data.ActionCardObj[cardnr].UnitSelect ? -1 : this.game.EditObj.UnitSelected;
      this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.ActionCardObj[cardnr].ExecuteEvent, this.game.Data.ActionCardObj[cardnr].TempVar0, this.game.Data.ActionCardObj[cardnr].TempVar1, unr, tv3);
      int handCardCounter = this.game.Data.HistoricalUnitObj[historical].HandCardCounter;
      for (int index1 = 0; index1 <= handCardCounter; ++index1)
      {
        if (this.game.Data.HistoricalUnitObj[historical].HandCard[index1] == cardnr)
        {
          int num1 = index1;
          int num2 = this.game.Data.HistoricalUnitObj[historical].HandCardCounter - 1;
          for (int index2 = num1; index2 <= num2; ++index2)
            this.game.Data.HistoricalUnitObj[historical].HandCard[index2] = this.game.Data.HistoricalUnitObj[historical].HandCard[index2 + 1];
          HistoricalUnitClass[] historicalUnitObj = this.game.Data.HistoricalUnitObj;
          HistoricalUnitClass[] historicalUnitClassArray = historicalUnitObj;
          int index3 = historical;
          int index4 = index3;
          historicalUnitClassArray[index4].HandCardCounter = historicalUnitObj[index3].HandCardCounter - 1;
          if (this.game.Data.HistoricalUnitObj[historical].HandCardCounter > -1)
          {
            this.game.Data.HistoricalUnitObj[historical].HandCard = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[historical].HandCard, (Array) new int[this.game.Data.HistoricalUnitObj[historical].HandCardCounter + 1]);
            break;
          }
          break;
        }
      }
      RegimeClass[] regimeObj = this.game.Data.RegimeObj;
      RegimeClass[] regimeClassArray = regimeObj;
      int index5 = regime;
      int index6 = index5;
      regimeClassArray[index6].ResPts = regimeObj[index5].ResPts - this.game.Data.ActionCardObj[cardnr].PPCost;
      if (this.game.Data.ActionCardObj[cardnr].HisVarCostType > -1)
      {
        int hisVarCount = this.game.Data.HistoricalUnitObj[historical].HisVarCount;
        for (int index7 = 0; index7 <= hisVarCount; ++index7)
        {
          if (this.game.Data.HistoricalUnitObj[historical].HisVarType[index7] == this.game.Data.ActionCardObj[cardnr].HisVarCostType)
          {
            int[] hisVarValue = this.game.Data.HistoricalUnitObj[historical].HisVarValue;
            int[] numArray = hisVarValue;
            int index8 = index7;
            int index9 = index8;
            int num = hisVarValue[index8] - this.game.Data.ActionCardObj[cardnr].HisVarCostQty;
            numArray[index9] = num;
          }
        }
      }
      int unitCounter = this.game.Data.UnitCounter;
      for (int index10 = 0; index10 <= unitCounter; ++index10)
        this.game.Data.UnitObj[index10].LastAP = -1;
    }

    public void PlayCard(int cardnr)
    {
      int tv3 = !this.game.Data.ActionCardObj[cardnr].UnitSelect ? -1 : this.game.EditObj.UnitSelected;
      this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.ActionCardObj[cardnr].ExecuteEvent, this.game.Data.ActionCardObj[cardnr].TempVar0, this.game.Data.ActionCardObj[cardnr].TempVar1, -1, tv3);
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
        this.game.Data.UnitObj[index].LastAP = -1;
    }

    public void PlayCardPreEvent(int cardnr)
    {
      int tv2 = !this.game.Data.ActionCardObj[cardnr].UnitSelect ? this.game.EditObj.UnitSelected : this.game.EditObj.UnitSelected;
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
        this.game.Data.UnitObj[index].TempUnitSelectable = false;
      this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.ActionCardObj[cardnr].PreExecuteEvent, this.game.Data.ActionCardObj[cardnr].TempVar0, this.game.Data.ActionCardObj[cardnr].TempVar1, tv2, -1);
    }

    public void PlayCardPreEvent(int regnr, int cardinhandnr)
    {
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
        this.game.Data.UnitObj[index].TempUnitSelectable = false;
      int index1 = this.game.Data.RegimeObj[regnr].ActionCard[cardinhandnr];
      if (this.game.Data.ActionCardObj[index1].PreExecuteEvent <= -1)
        return;
      this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.ActionCardObj[index1].PreExecuteEvent, this.game.Data.ActionCardObj[index1].TempVar0, this.game.Data.ActionCardObj[index1].TempVar1);
    }

    public void AddNewUnitBasedOnHistorical(
      int x,
      int y,
      int map,
      int reg,
      int his,
      int subpart = -1,
      int OverWriteUnr = -1,
      bool freePPnoUnit = false,
      bool DontCreateUnits = false,
      bool populateUnit = false)
    {
      if (subpart == -1)
      {
        if (!(this.game.Data.RegimeObj[reg].AI & (double) this.game.Data.RuleVar[914] == 1.0) && !freePPnoUnit)
        {
          RegimeClass[] regimeObj = this.game.Data.RegimeObj;
          RegimeClass[] regimeClassArray = regimeObj;
          int turn = this.game.Data.Turn;
          int index = turn;
          regimeClassArray[index].ResPts = regimeObj[turn].ResPts - this.game.Data.HistoricalUnitObj[his].PP;
        }
      }
      else
      {
        int num = 0;
        int index1 = 0;
        do
        {
          if (this.game.Data.HistoricalUnitObj[his].SubParts[index1] > -1)
            ++num;
          ++index1;
        }
        while (index1 <= 9);
        if (!(this.game.Data.RegimeObj[this.game.Data.Turn].AI & (double) this.game.Data.RuleVar[914] == 1.0) && !freePPnoUnit)
        {
          RegimeClass[] regimeObj = this.game.Data.RegimeObj;
          RegimeClass[] regimeClassArray = regimeObj;
          int turn = this.game.Data.Turn;
          int index2 = turn;
          regimeClassArray[index2].ResPts = regimeObj[turn].ResPts - (int) Math.Round((double) this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[his].ModelMaster].PP / (double) num);
        }
      }
      int num1 = 9999;
      int num2 = -1;
      int index3 = his;
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index4 = 0; index4 <= unitCounter1; ++index4)
      {
        if (this.game.Data.UnitObj[index4].Regime == this.game.Data.HistoricalUnitObj[index3].TempRegime && this.game.Data.UnitObj[index4].PreDef == -1 && this.game.Data.UnitObj[index4].IsHQ && this.game.Data.UnitObj[index4].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index4].Historical].Type > this.game.Data.HistoricalUnitObj[index3].Type)
        {
          int num3 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[index4].X, this.game.Data.UnitObj[index4].Y, this.game.Data.UnitObj[index4].Map, x, y, this.game.EditObj.EventMap);
          if (num3 < num1)
          {
            num1 = num3;
            num2 = index4;
          }
        }
      }
      if (subpart == -1)
      {
        this.game.Data.AddHistoricalUnit();
        index3 = this.game.Data.HistoricalUnitCounter;
        int index5 = his;
        if (this.game.Data.HistoricalUnitObj[his].UseModelCounter > -1)
          index5 = this.game.Data.HistoricalUnitObj[his].UseModelCounter;
        int num4 = 0;
        if (this.game.Data.HistoricalUnitObj[index5].PercentOldName > (int) Math.Round((double) (VBMath.Rnd() * 100f)) & this.game.Data.HistoricalUnitObj[index5].NameCounter > 0)
          num4 = 1;
        int nameCounter1;
        if (num4 == 1)
        {
          SimpleList simpleList1 = new SimpleList();
          int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
          for (int index6 = 0; index6 <= historicalUnitCounter; ++index6)
          {
            if (this.game.Data.HistoricalUnitObj[index6].TempRegime == this.game.Data.Turn && this.game.Data.HistoricalUnitObj[index6].ModelMaster > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[index6].ModelMaster].UseModelCounter == index5 | this.game.Data.HistoricalUnitObj[index6].ModelMaster == index5)
            {
              simpleList1.Add(this.game.Data.HistoricalUnitObj[index6].NameCounter, 1);
              simpleList1.Add((int) Math.Round(Conversion.Val(this.game.Data.HistoricalUnitObj[index6].CounterString)), 1);
            }
          }
          SimpleList simpleList2 = new SimpleList();
          int nameCounter2 = this.game.Data.HistoricalUnitObj[index5].NameCounter;
          for (int tid = 1; tid <= nameCounter2; ++tid)
          {
            if (simpleList1.FindNr(tid) == -1)
              simpleList2.Add(tid, 1);
          }
          if (simpleList2.Counter > -1)
          {
            nameCounter1 = simpleList2.Id[(int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) (simpleList2.Counter + 1)))];
            num4 = 1;
          }
          else
            num4 = 0;
        }
        if (num4 == 0)
        {
          if (this.game.Data.HistoricalUnitObj[index5].NameCounter > -1)
          {
            HistoricalUnitClass[] historicalUnitObj = this.game.Data.HistoricalUnitObj;
            HistoricalUnitClass[] historicalUnitClassArray = historicalUnitObj;
            int index7 = index5;
            int index8 = index7;
            historicalUnitClassArray[index8].NameCounter = historicalUnitObj[index7].NameCounter + 1;
          }
          nameCounter1 = this.game.Data.HistoricalUnitObj[index5].NameCounter;
        }
        this.game.Data.HistoricalUnitObj[index3].Counter = nameCounter1;
        string str1;
        string str2;
        if (nameCounter1 > -1)
        {
          string str3 = Strings.Trim(Conversion.Str((object) nameCounter1));
          string str4 = !((nameCounter1 + 10) % 10 == 1 & (nameCounter1 + 100) % 100 != 11) ? (!((nameCounter1 + 10) % 10 == 2 & (nameCounter1 + 100) % 100 != 12) ? (!((nameCounter1 + 10) % 10 == 3 & (nameCounter1 + 100) % 100 != 13) ? str3 + "th" : str3 + "rd") : str3 + "nd") : str3 + "st";
          if (this.game.Data.HistoricalUnitObj[his].UseRomans)
          {
            str1 = this.game.HandyFunctionsObj.GetRomanNumerical(nameCounter1);
            str4 = str1;
            if (Strings.Len(this.game.Data.HistoricalUnitObj[his].CounterString) > 0 && Conversion.Val(this.game.Data.HistoricalUnitObj[his].CounterString) != -1.0)
              str1 = str1 + " " + this.game.Data.HistoricalUnitObj[his].CounterString;
          }
          else
          {
            str1 = Strings.Trim(Conversion.Str((object) nameCounter1));
            if (Strings.Len(this.game.Data.HistoricalUnitObj[his].CounterString) > 0 && Conversion.Val(this.game.Data.HistoricalUnitObj[his].CounterString) != -1.0)
              str1 += this.game.Data.HistoricalUnitObj[his].CounterString;
          }
          str2 = str4 + " " + this.game.Data.HistoricalUnitObj[his].Name;
        }
        else
        {
          str2 = this.game.Data.HistoricalUnitObj[his].Name;
          str1 = this.game.Data.HistoricalUnitObj[his].CounterString;
        }
        this.game.Data.HistoricalUnitObj[index3].Name = str2;
        this.game.Data.HistoricalUnitObj[index3].CounterString = str1;
        this.game.Data.HistoricalUnitObj[index3].SmallGfx = this.game.Data.HistoricalUnitObj[his].SmallGfx;
        this.game.Data.HistoricalUnitObj[index3].Counter = this.game.Data.HistoricalUnitObj[his].Counter;
        this.game.Data.HistoricalUnitObj[index3].Green = this.game.Data.HistoricalUnitObj[his].Green;
        this.game.Data.HistoricalUnitObj[index3].Red = this.game.Data.HistoricalUnitObj[his].Red;
        this.game.Data.HistoricalUnitObj[index3].Blue = this.game.Data.HistoricalUnitObj[his].Blue;
        this.game.Data.HistoricalUnitObj[index3].TempVar1 = this.game.Data.HistoricalUnitObj[his].TempVar1;
        this.game.Data.HistoricalUnitObj[index3].TempVar2 = this.game.Data.HistoricalUnitObj[his].TempVar2;
        this.game.Data.HistoricalUnitObj[index3].TempVar3 = this.game.Data.HistoricalUnitObj[his].TempVar3;
        this.game.Data.HistoricalUnitObj[index3].People = this.game.Data.HistoricalUnitObj[his].People;
        this.game.Data.HistoricalUnitObj[index3].UsePeopleGfx = this.game.Data.HistoricalUnitObj[his].UsePeopleGfx;
        this.game.Data.HistoricalUnitObj[index3].Type = this.game.Data.HistoricalUnitObj[his].Type;
        this.game.Data.HistoricalUnitObj[index3].NoSplit = this.game.Data.HistoricalUnitObj[his].NoSplit;
        this.game.Data.HistoricalUnitObj[index3].TempRegime = reg;
        this.game.Data.HistoricalUnitObj[index3].ModelMaster = his;
        this.game.Data.HistoricalUnitObj[index3].NameCounter = this.game.Data.HistoricalUnitObj[his].NameCounter;
        if ((double) this.game.Data.RuleVar[343] > 0.0 & this.game.Data.HistoricalUnitObj[index3].Type >= 5)
        {
          int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
          int num5 = 0;
          while (num5 <= historicalUnitCounter)
            ++num5;
        }
      }
      int index9 = 0;
      do
      {
        if (subpart == -1 | subpart == index9 && subpart == -1)
        {
          this.game.Data.HistoricalUnitObj[index3].SubParts[index9] = this.game.Data.HistoricalUnitObj[his].SubParts[index9];
          this.game.Data.HistoricalUnitObj[index3].Designation[index9] = this.game.Data.HistoricalUnitObj[his].Designation[index9];
          this.game.Data.HistoricalUnitObj[index3].DesignationSmall[index9] = this.game.Data.HistoricalUnitObj[his].DesignationSmall[index9];
        }
        ++index9;
      }
      while (index9 <= 9);
      SimpleList simpleList3 = new SimpleList();
      SimpleList simpleList4 = new SimpleList();
      string str5;
      int Number1;
      if (OverWriteUnr > -1)
      {
        if (this.game.Data.UnitObj[OverWriteUnr].Historical == -1)
        {
          str5 = "Unit is currently a to be disbanded formation.";
          simpleList3.Add(OverWriteUnr, 0);
          Number1 = 1;
        }
        else if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[OverWriteUnr].Historical].ModelMaster == -1)
        {
          str5 = "Unit is currently an ad hoc formation." + " Current unit consists of " + Conversion.Str((object) Number1) + " subunits.";
          int unitCounter2 = this.game.Data.UnitCounter;
          for (int tid = 0; tid <= unitCounter2; ++tid)
          {
            if (this.game.Data.UnitObj[tid].PreDef == -1 && this.game.Data.UnitObj[tid].Historical == this.game.Data.UnitObj[OverWriteUnr].Historical)
            {
              int num6;
              ++num6;
              simpleList3.Add(tid, 0);
            }
          }
        }
        else
        {
          string str6 = "Current Model is " + this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[OverWriteUnr].Historical].ModelMaster].Name;
          int unitCounter3 = this.game.Data.UnitCounter;
          int Number2;
          for (int tid = 0; tid <= unitCounter3; ++tid)
          {
            if (this.game.Data.UnitObj[tid].PreDef == -1 && this.game.Data.UnitObj[tid].Historical == this.game.Data.UnitObj[OverWriteUnr].Historical)
            {
              ++Number2;
              simpleList3.Add(tid, 0);
            }
          }
          str5 = str6 + " Current unit consists of " + Conversion.Str((object) Number2) + " subunits.";
        }
      }
      if (subpart == -1 & OverWriteUnr > -1 & !DontCreateUnits)
      {
        for (int counter = simpleList3.Counter; counter >= 0; counter += -1)
        {
          int index10 = simpleList3.Id[counter];
          int historical = this.game.Data.UnitObj[index10].Historical;
          int historicalSubPart = this.game.Data.UnitObj[index10].HistoricalSubPart;
          int num7 = 0;
          int tid1 = 0;
          while (!(historical > -1 & historicalSubPart > -1) || simpleList4.FindNr(tid1) != -1 || this.game.Data.HistoricalUnitObj[index3].SubParts[tid1] <= -1 || this.game.Data.HistoricalUnitObj[historical].SubParts[historicalSubPart] != this.game.Data.HistoricalUnitObj[index3].SubParts[tid1])
          {
            ++tid1;
            if (tid1 > 9)
              goto label_76;
          }
          this.game.Data.UnitObj[index10].HistoricalSubPart = tid1;
          simpleList4.Add(tid1, 0);
          this.game.Data.UnitObj[index10].Historical = index3;
          simpleList3.Remove(index10);
          num7 = 1;
label_76:
          if (num7 == 0)
          {
            int tid2 = 0;
            while (!(historical > -1 & historicalSubPart > -1) || simpleList4.FindNr(tid2) != -1 || this.game.Data.HistoricalUnitObj[index3].Designation[tid2] <= -1 || this.game.Data.HistoricalUnitObj[historical].Designation[historicalSubPart] != this.game.Data.HistoricalUnitObj[index3].Designation[tid2])
            {
              ++tid2;
              if (tid2 > 9)
                goto label_81;
            }
            this.game.Data.UnitObj[index10].HistoricalSubPart = tid2;
            simpleList4.Add(tid2, 0);
            this.game.Data.UnitObj[index10].Historical = index3;
            simpleList3.Remove(index10);
            num7 = 1;
          }
label_81:
          if (num7 == 0)
          {
            SimpleList simpleList5 = new SimpleList();
            int tid3 = 0;
            do
            {
              if (simpleList4.FindNr(tid3) == -1 && this.game.Data.HistoricalUnitObj[index3].SubParts[tid3] > -1)
                simpleList5.Add(tid3, this.game.HandyFunctionsObj.PowerPointsDifferent(index10, this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[index3].SubParts[tid3])));
              ++tid3;
            }
            while (tid3 <= 9);
            simpleList5.Sort();
            if (simpleList5.Counter > -1)
            {
              int tid4 = simpleList5.Id[0];
              this.game.Data.UnitObj[index10].HistoricalSubPart = tid4;
              simpleList4.Add(tid4, 0);
              this.game.Data.UnitObj[index10].Historical = index3;
              simpleList3.Remove(index10);
              num7 = 1;
            }
          }
          if (num7 == 1)
          {
            this.game.Data.UnitObj[index10].Name = this.game.Data.HistoricalUnitObj[index3].Name;
            this.game.Data.UnitObj[index10].IsHQ = this.game.Data.UnitObj[this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[index3].SubParts[this.game.Data.UnitObj[index10].HistoricalSubPart])].IsHQ;
            this.game.Data.UnitObj[index10].StartPower = this.game.HandyFunctionsObj.GetPowerPtsAbsolute(this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[index3].SubParts[counter]), true);
            this.game.Data.UnitObj[index10].Regime = this.game.Data.HistoricalUnitObj[index3].TempRegime;
            int num8 = 0;
            int unitCounter4 = this.game.Data.UnitCounter;
            for (int index11 = 0; index11 <= unitCounter4; ++index11)
            {
              if (this.game.Data.UnitObj[index11].Historical == this.game.Data.UnitObj[index10].Historical)
                ++num8;
            }
            this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index10].Historical].StartSize = num8;
          }
        }
      }
      else
      {
        if (DontCreateUnits)
          return;
        bool flag = false;
        int index12 = 0;
        do
        {
          if (this.game.Data.HistoricalUnitObj[index3].SubParts[index12] > -1)
            flag = true;
          ++index12;
        }
        while (index12 <= 9);
        if (this.game.Data.Product < 6)
          flag = true;
        int index13 = 0;
        do
        {
          if (subpart == -1 | subpart == index13 && this.game.Data.HistoricalUnitObj[index3].SubParts[index13] > -1 | index13 == 0 & !flag & this.game.Data.Product >= 6)
          {
            int unr;
            if (OverWriteUnr == -1)
            {
              this.game.Data.AddUnit(x, y, map);
              unr = this.game.Data.UnitCounter;
            }
            else
              unr = OverWriteUnr;
            if (populateUnit)
              this.game.HandyFunctionsObj.CopyUnit(unr, this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[index3].SubParts[index13]));
            this.game.Data.UnitObj[unr].Name = this.game.Data.HistoricalUnitObj[index3].Name;
            this.game.Data.UnitObj[unr].Historical = index3;
            if (flag)
            {
              this.game.Data.UnitObj[unr].IsHQ = this.game.Data.UnitObj[this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[index3].SubParts[index13])].IsHQ;
              this.game.Data.UnitObj[unr].HistoricalSubPart = index13;
            }
            else
            {
              this.game.Data.UnitObj[unr].IsHQ = false;
              this.game.Data.UnitObj[unr].HistoricalSubPart = 0;
            }
            this.game.Data.UnitObj[unr].Regime = this.game.Data.HistoricalUnitObj[index3].TempRegime;
            this.game.Data.UnitObj[unr].StartPower = this.game.HandyFunctionsObj.GetPowerPtsAbsolute(this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[index3].SubParts[index13]), true);
            if (this.game.Data.Product == 6 & this.game.Data.Round >= 1)
            {
              int sfCount = this.game.Data.UnitObj[unr].SFCount;
              for (int index14 = 0; index14 <= sfCount; ++index14)
                this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index14]].Ap = 0;
            }
            if (OverWriteUnr == -1)
              this.game.Data.UnitObj[unr].HQ = num2;
            if (subpart > -1)
            {
              int num9 = this.game.Data.UnitCounter - 1;
              for (int index15 = 0; index15 <= num9; ++index15)
              {
                if (this.game.Data.UnitObj[index15].Historical == index3 & this.game.Data.UnitObj[index15].HQ > -1)
                {
                  this.game.Data.UnitObj[unr].HQ = this.game.Data.UnitObj[index15].HQ;
                  this.game.Data.UnitObj[unr].SODefendPercent = this.game.Data.UnitObj[index15].SODefendPercent;
                  if (OverWriteUnr == -1)
                    this.game.Data.UnitObj[unr].HQ = num2;
                  this.game.Data.UnitObj[unr].SOSupReqPercent = this.game.Data.UnitObj[index15].SOSupReqPercent;
                  this.game.Data.UnitObj[unr].SOReplacementPercent = this.game.Data.UnitObj[index15].SOReplacementPercent;
                  this.game.Data.UnitObj[unr].SOInterceptRdnStop = this.game.Data.UnitObj[index15].SOInterceptRdnStop;
                  break;
                }
              }
            }
          }
          ++index13;
        }
        while (index13 <= 9);
        int num10 = 0;
        int unitCounter5 = this.game.Data.UnitCounter;
        for (int index16 = 0; index16 <= unitCounter5; ++index16)
        {
          if (this.game.Data.UnitObj[index16].Historical == index3)
            ++num10;
        }
        this.game.Data.HistoricalUnitObj[index3].StartSize = num10;
      }
    }

    public void AutoConquerNeutral(int regnr)
    {
      MapMatrix2[] mapMatrix2Array = new MapMatrix2[this.game.Data.MapCounter + 1];
      int mapCounter1 = this.game.Data.MapCounter;
      for (int index = 0; index <= mapCounter1; ++index)
        mapMatrix2Array[index] = new MapMatrix2(this.game.Data.MapObj[index].MapWidth, this.game.Data.MapObj[index].MapHeight);
      ++this.game.Data.StepNr;
      int mapCounter2 = this.game.Data.MapCounter;
      for (int cmap = 0; cmap <= mapCounter2; ++cmap)
      {
        int mapWidth = this.game.Data.MapObj[cmap].MapWidth;
        for (int cx = 0; cx <= mapWidth; ++cx)
        {
          int mapHeight = this.game.Data.MapObj[cmap].MapHeight;
          for (int cy = 0; cy <= mapHeight; ++cy)
          {
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime == regnr)
            {
              int tfacing = 1;
              do
              {
                Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, tfacing);
                if (coordinate.onmap && this.game.Data.MapObj[cmap].HexObj[coordinate.x, coordinate.y].Regime == -1 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[cmap].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                  mapMatrix2Array[cmap].Value[coordinate.x, coordinate.y] = 1;
                ++tfacing;
              }
              while (tfacing <= 6);
            }
          }
        }
      }
      int mapCounter3 = this.game.Data.MapCounter;
      for (int map = 0; map <= mapCounter3; ++map)
      {
        int mapWidth = this.game.Data.MapObj[map].MapWidth;
        for (int x = 0; x <= mapWidth; ++x)
        {
          int mapHeight = this.game.Data.MapObj[map].MapHeight;
          for (int y = 0; y <= mapHeight; ++y)
          {
            if (mapMatrix2Array[map].Value[x, y] == 1)
            {
              this.game.Data.MapObj[map].HexObj[x, y].Regime = regnr;
              this.game.HandyFunctionsObj.HistoryAddHex(x, y, map, regnr);
            }
          }
        }
      }
    }

    public void SetExtraStat(int regnr)
    {
      int index1 = 0;
      do
      {
        this.game.EditObj.uds_subtab[index1] = -1;
        int index2 = 0;
        do
        {
          this.game.EditObj.uds_page[index1, index2] = -1;
          ++index2;
        }
        while (index2 <= 18);
        ++index1;
      }
      while (index1 <= 8);
      this.game.EditObj.statsTab_tab = -1;
      this.game.EditObj.statsTab_item = -1;
      if ((double) this.game.Data.RuleVar[650] > 0.0)
        this.game.Data.RegimeObj[regnr].ExtraStat[0, this.game.Data.Round] = this.game.Data.RegimeObj[regnr].RegimeSlot[(int) Math.Round((double) this.game.Data.RuleVar[650])];
      if ((double) this.game.Data.RuleVar[651] > 0.0)
        this.game.Data.RegimeObj[regnr].ExtraStat[1, this.game.Data.Round] = this.game.Data.RegimeObj[regnr].RegimeSlot[(int) Math.Round((double) this.game.Data.RuleVar[651])];
      if ((double) this.game.Data.RuleVar[652] <= 0.0)
        return;
      this.game.Data.RegimeObj[regnr].ExtraStat[2, this.game.Data.Round] = this.game.Data.RegimeObj[regnr].RegimeSlot[(int) Math.Round((double) this.game.Data.RuleVar[652])];
    }

    public void SetInitialReconAndZOC(int regnr)
    {
      int mapCounter1 = this.game.Data.MapCounter;
      for (int index1 = 0; index1 <= mapCounter1; ++index1)
      {
        this.game.Data.MapObj[index1].CanSee = false;
        int mapWidth = this.game.Data.MapObj[index1].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; ++index2)
        {
          int mapHeight = this.game.Data.MapObj[index1].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; ++index3)
          {
            if (this.game.Data.ShrowdOn)
              this.game.Data.MapObj[index1].HexObj[index2, index3].set_SeeNow(regnr, 0);
            else
              this.game.Data.MapObj[index1].HexObj[index2, index3].set_SeeNow(regnr, 1);
            this.game.Data.MapObj[index1].HexObj[index2, index3].set_ReconPts(regnr, 0);
            this.game.Data.MapObj[index1].HexObj[index2, index3].set_ZocPts(regnr, 0);
            this.game.Data.MapObj[index1].HexObj[index2, index3].MaxRecon = 0;
            this.game.Data.MapObj[index1].HexObj[index2, index3].MaxLos = 0;
            this.game.Data.MapObj[index1].HexObj[index2, index3].MaxObstruct = 0;
          }
        }
      }
      int mapCounter2 = this.game.Data.MapCounter;
      for (int map = 0; map <= mapCounter2; ++map)
      {
        int mapWidth = this.game.Data.MapObj[map].MapWidth;
        for (int x = 0; x <= mapWidth; ++x)
        {
          int mapHeight = this.game.Data.MapObj[map].MapHeight;
          for (int y = 0; y <= mapHeight; ++y)
            this.game.HandyFunctionsObj.SetHexReconAndZOC(x, y, map, regnr);
        }
      }
      int mapCounter3 = this.game.Data.MapCounter;
      for (int cmap = 0; cmap <= mapCounter3; ++cmap)
      {
        int mapWidth = this.game.Data.MapObj[cmap].MapWidth;
        for (int cx = 0; cx <= mapWidth; ++cx)
        {
          int mapHeight = this.game.Data.MapObj[cmap].MapHeight;
          for (int cy = 0; cy <= mapHeight; ++cy)
          {
            int num = 0;
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].get_LastLT(regnr) > -1)
              this.game.Data.MapObj[cmap].CanSee = true;
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime == regnr)
              num = 1;
            if (this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime > -1 && this.game.Data.RegimeObj[regnr].RegimeRel[this.game.Data.MapObj[cmap].HexObj[cx, cy].Regime] == 2 & (double) this.game.Data.RuleVar[328] == 1.0)
              num = 1;
            if (num == 1)
            {
              if ((double) this.game.Data.RuleVar[8] > (double) this.game.Data.MapObj[cmap].HexObj[cx, cy].get_ReconPts(regnr))
              {
                this.game.Data.MapObj[cmap].HexObj[cx, cy].set_ReconPts(regnr, (int) Math.Round((double) this.game.Data.RuleVar[8]));
                this.game.Data.MapObj[cmap].CanSee = true;
              }
              int tfacing = 1;
              do
              {
                Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, cmap, tfacing);
                if (coordinate.onmap && (double) this.game.Data.RuleVar[8] > (double) this.game.Data.MapObj[cmap].HexObj[coordinate.x, coordinate.y].get_ReconPts(regnr))
                {
                  this.game.Data.MapObj[cmap].HexObj[coordinate.x, coordinate.y].set_ReconPts(regnr, (int) Math.Round((double) this.game.Data.RuleVar[8]));
                  this.game.Data.MapObj[cmap].CanSee = true;
                }
                ++tfacing;
              }
              while (tfacing <= 6);
            }
          }
        }
      }
      int mapCounter4 = this.game.Data.MapCounter;
      for (int index4 = 0; index4 <= mapCounter4; ++index4)
      {
        int mapWidth = this.game.Data.MapObj[index4].MapWidth;
        for (int index5 = 0; index5 <= mapWidth; ++index5)
        {
          int mapHeight = this.game.Data.MapObj[index4].MapHeight;
          for (int index6 = 0; index6 <= mapHeight; ++index6)
          {
            if (this.game.Data.MapObj[index4].HexObj[index5, index6].get_ReconPts(regnr) >= 1)
            {
              this.game.Data.MapObj[index4].HexObj[index5, index6].set_SeeNow(regnr, 1);
              this.game.Data.MapObj[index4].HexObj[index5, index6].set_LastLT(regnr, this.game.Data.MapObj[index4].HexObj[index5, index6].LandscapeType);
              this.game.Data.MapObj[index4].HexObj[index5, index6].set_LastSpr(regnr, this.game.Data.MapObj[index4].HexObj[index5, index6].SpriteNr);
              this.game.Data.MapObj[index4].HexObj[index5, index6].set_LastReg(regnr, this.game.Data.MapObj[index4].HexObj[index5, index6].Regime);
            }
            this.game.Data.MapObj[index4].HexObj[index5, index6].MaxRecon = this.game.Data.MapObj[index4].HexObj[index5, index6].get_ReconPts(regnr);
          }
        }
      }
      this.SpottedAndIdentifiedUpdate(regnr);
    }

    public void SpottedAndIdentifiedUpdate(int regnr, int tunr = -1, bool improveOnly = false)
    {
      if (!((double) this.game.Data.RuleVar[419] > 0.0 & this.game.Data.Product >= 6 & this.game.Data.Round > 0))
        return;
      if (tunr == -1)
      {
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index1 = 0; index1 <= mapWidth; ++index1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index2 = 0; index2 <= mapHeight; ++index2)
          {
            int unitCounter = this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter;
            for (int index3 = 0; index3 <= unitCounter; ++index3)
            {
              int unit = this.game.Data.MapObj[0].HexObj[index1, index2].UnitList[index3];
              if (this.game.Data.UnitObj[unit].Regime != regnr)
              {
                if (index1 == 59 & index2 == 19)
                  index1 = index1;
                int val1 = this.game.Data.MapObj[0].HexObj[index1, index2].get_ReconPts(regnr);
                if (this.game.Data.Turn == regnr)
                  val1 = Math.Max(val1, this.game.Data.MapObj[0].HexObj[index1, index2].MaxRecon);
                Coordinate reconMinusHide;
                if (this.game.Data.Round == 0 | !this.game.Data.FOWOn)
                  reconMinusHide.x = 3;
                else
                  reconMinusHide = this.game.HandyFunctionsObj.GetReconMinusHide(unit, this.game.Data.Turn);
                if (reconMinusHide.y >= 1 & !this.game.Data.UnitObj[unit].Spotted)
                  this.game.Data.UnitObj[unit].Spotted = true;
                else if (this.game.Data.UnitObj[unit].Spotted & (reconMinusHide.y < 1 | val1 < 1) && !improveOnly)
                  this.game.Data.UnitObj[unit].Spotted = false;
                if ((double) reconMinusHide.y >= (double) this.game.Data.RuleVar[55] & !this.game.Data.UnitObj[unit].Identified)
                  this.game.Data.UnitObj[unit].Identified = true;
                else if (this.game.Data.UnitObj[unit].Identified & (reconMinusHide.y < 1 | val1 < 1) && !improveOnly)
                  this.game.Data.UnitObj[unit].Identified = false;
              }
            }
          }
        }
      }
      else
      {
        if (tunr <= -1)
          return;
        int unr = tunr;
        int x = this.game.Data.UnitObj[unr].X;
        int y = this.game.Data.UnitObj[unr].Y;
        if (this.game.Data.UnitObj[unr].Regime == regnr)
          return;
        int val1 = this.game.Data.MapObj[0].HexObj[x, y].get_ReconPts(regnr);
        if (this.game.Data.Turn == regnr)
          val1 = Math.Max(val1, this.game.Data.MapObj[0].HexObj[x, y].MaxRecon);
        Coordinate reconMinusHide;
        if (this.game.Data.Round == 0 | !this.game.Data.FOWOn)
          reconMinusHide.x = 3;
        else
          reconMinusHide = this.game.HandyFunctionsObj.GetReconMinusHide(unr, this.game.Data.Turn);
        if (reconMinusHide.y >= 1 & !this.game.Data.UnitObj[unr].Spotted)
          this.game.Data.UnitObj[unr].Spotted = true;
        else if (this.game.Data.UnitObj[unr].Spotted & (reconMinusHide.y < 1 | val1 < 1) && !improveOnly)
          this.game.Data.UnitObj[unr].Spotted = false;
        if ((double) reconMinusHide.y >= (double) this.game.Data.RuleVar[55] & !this.game.Data.UnitObj[unr].Identified)
        {
          this.game.Data.UnitObj[unr].Identified = true;
        }
        else
        {
          if (!(this.game.Data.UnitObj[unr].Identified & (reconMinusHide.y < 1 | val1 < 1)) || improveOnly)
            return;
          this.game.Data.UnitObj[unr].Identified = false;
        }
      }
    }

    public void IntialZOCConquestCheck(int regnr)
    {
      int num = 0;
      do
      {
        int mapCounter = this.game.Data.MapCounter;
        for (int map = 0; map <= mapCounter; ++map)
        {
          int mapWidth = this.game.Data.MapObj[map].MapWidth;
          for (int x = 0; x <= mapWidth; ++x)
          {
            int mapHeight = this.game.Data.MapObj[map].MapHeight;
            for (int y = 0; y <= mapHeight; ++y)
              this.game.HandyFunctionsObj.DoZOCConquest(x, y, map, regnr);
          }
        }
        ++num;
      }
      while (num <= 3);
    }

    public void DoEntrench(int regnr, bool onlyauto = false)
    {
      if (this.game.Data.UnitCounter < 0)
        return;
      int unitCounter = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.game.Data.UnitObj[index1].Regime == regnr & this.game.Data.UnitObj[index1].X > -1 & this.game.Data.UnitObj[index1].PreDef <= -1 && this.game.Data.UnitObj[index1].SFCount > -1)
        {
          int sfCount = this.game.Data.UnitObj[index1].SFCount;
          for (int index2 = 0; index2 <= sfCount; ++index2)
          {
            int sf = this.game.Data.UnitObj[index1].SFList[index2];
            int ap = this.game.Data.SFObj[sf].Ap;
            int type = this.game.Data.SFObj[sf].Type;
            int unitGroup = this.game.Data.SFTypeObj[type].UnitGroup;
            if (this.game.Data.SFTypeObj[type].Theater == 0)
            {
              int landscapeType = this.game.Data.MapObj[this.game.Data.UnitObj[index1].Map].HexObj[this.game.Data.UnitObj[index1].X, this.game.Data.UnitObj[index1].Y].LandscapeType;
              int location = this.game.Data.MapObj[this.game.Data.UnitObj[index1].Map].HexObj[this.game.Data.UnitObj[index1].X, this.game.Data.UnitObj[index1].Y].Location;
              if (!this.game.Data.LandscapeTypeObj[landscapeType].IsSea)
              {
                int num1 = Conversion.Int(this.game.Data.SFTypeObj[type].EntrenchPower);
                if (this.game.Data.Product == 6 & this.game.Data.SFTypeObj[type].EP <= 0)
                {
                  Coordinate coordinate = this.game.HandyFunctionsObj.EPandPowerInHex(this.game.Data.UnitObj[index1].X, this.game.Data.UnitObj[index1].Y);
                  if (coordinate.x > 0 & coordinate.y > 0)
                  {
                    float num2 = (float) coordinate.x / (float) coordinate.y;
                    int num3 = coordinate.data1 - num1;
                    if (num3 > 0)
                    {
                      if ((double) num2 < 1.0)
                        num3 = (int) Math.Round((double) ((float) num3 * num2));
                      num1 += num3;
                    }
                  }
                }
                if ((double) this.game.Data.RuleVar[494] > 0.0)
                {
                  DataClass data = this.game.Data;
                  string str = "Snow";
                  ref string local = ref str;
                  int libVar = data.FindLibVar(ref local, "");
                  if (this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index1].X, this.game.Data.UnitObj[index1].Y].GetHexLibVarValue(libVar) > 0)
                    num1 = (int) Math.Round((double) num1 * (double) this.game.Data.RuleVar[494] / 100.0);
                }
                if (onlyauto)
                  num1 = 0;
                SFClass[] sfObj = this.game.Data.SFObj;
                SFClass[] sfClassArray = sfObj;
                int index3 = sf;
                int index4 = index3;
                sfClassArray[index4].CurrentEntrench = sfObj[index3].CurrentEntrench + num1;
                int num4 = (int) Math.Round((double) this.game.Data.LandscapeTypeObj[landscapeType].DefBonus[unitGroup]);
                if (location > -1 && this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].PictureLT > -1)
                  num4 = (int) Math.Round((double) ((float) num4 + this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].PictureLT].DefBonus[unitGroup]));
                if (num4 > this.game.Data.SFObj[sf].CurrentEntrench)
                  this.game.Data.SFObj[sf].CurrentEntrench = num4;
                int num5 = (int) Math.Round((double) this.game.Data.LandscapeTypeObj[landscapeType].DefBonusMax[unitGroup]);
                if (location > -1 && this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].PictureLT > -1)
                  num5 = (int) Math.Round((double) ((float) num5 + this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].PictureLT].DefBonusMax[unitGroup]));
                if (num5 < this.game.Data.SFObj[sf].CurrentEntrench)
                  this.game.Data.SFObj[sf].CurrentEntrench = num5;
                if (9999 < this.game.Data.SFObj[sf].CurrentEntrench)
                  this.game.Data.SFObj[sf].CurrentEntrench = 9999;
              }
            }
            if (this.game.Data.Product >= 6)
              this.game.Data.SFObj[sf].initialEntrench = this.game.Data.SFObj[sf].CurrentEntrench;
          }
        }
      }
    }

    public void DoMorale(int regnr)
    {
      int peopleGroup = this.game.Data.PeopleObj[this.game.Data.RegimeObj[regnr].People].PeopleGroup;
      if (this.game.Data.UnitCounter < 0)
        return;
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr1 = 0; unr1 <= unitCounter; ++unr1)
      {
        if (this.game.Data.UnitObj[unr1].Regime == regnr & this.game.Data.UnitObj[unr1].PreDef <= -1)
        {
          bool flag = false;
          if (this.game.Data.Product >= 6 && (double) this.game.Data.RuleVar[469] > 0.0 && 100 + this.game.HandyFunctionsObj.GetAverageDefensiveMod_SupplyOnly(unr1) < DrawMod.RandyNumber.Next(0, 100))
            flag = true;
          if (this.game.Data.UnitObj[unr1].SFCount > -1)
          {
            int sfCount = this.game.Data.UnitObj[unr1].SFCount;
            for (int index = 0; index <= sfCount; ++index)
            {
              int sf = this.game.Data.UnitObj[unr1].SFList[index];
              int ap = this.game.Data.SFObj[sf].Ap;
              int mor = this.game.Data.SFObj[sf].Mor;
              int type = this.game.Data.SFObj[sf].Type;
              int num1 = (int) Math.Round((double) this.game.Data.PeopleObj[this.game.Data.SFObj[sf].People].BaseMorale[peopleGroup] * ((double) this.game.Data.RegimeObj[regnr].BaseMorale / 100.0));
              if (!flag)
              {
                if (mor < num1)
                {
                  int num2 = (int) Math.Round((double) (this.game.Data.RuleVar[65] * (float) num1));
                  int unr2 = !this.game.Data.UnitObj[unr1].IsHQ ? this.game.Data.UnitObj[unr1].HQ : unr1;
                  if (unr2 > -1)
                  {
                    int num3 = this.game.HandyFunctionsObj.GetStaffPercent(unr2, true);
                    if (num3 > 100)
                      num3 = 100;
                    int num4 = this.game.HandyFunctionsObj.GetStaffPercent(unr2);
                    if (num4 > 100)
                      num4 = 100;
                    num2 = (int) Math.Round((double) num2 * (1.0 + (double) this.game.Data.RuleVar[141] * ((double) num4 / 100.0) * ((double) this.game.HandyFunctionsObj.Gethqpow(unr1) / 100.0) + (double) this.game.HandyFunctionsObj.GetStaffMoraleMod(unr2) * ((double) num3 / 100.0) * ((double) this.game.HandyFunctionsObj.Gethqpow(unr1) / 100.0)));
                  }
                  int num5 = (int) Math.Round(Conversion.Int((double) num2 * ((double) this.game.Data.SFObj[sf].Rdn / 100.0)));
                  this.game.Data.SFObj[sf].Mor += num5;
                  if (this.game.Data.SFObj[sf].Mor > num1)
                    this.game.Data.SFObj[sf].Mor = num1;
                }
              }
              else
              {
                int num6 = (int) Math.Round((double) num1 / 5.0);
                if (mor > num6)
                {
                  int num7 = (int) Math.Round((double) this.game.Data.RuleVar[469]);
                  int num8 = num7 - (int) Math.Round((double) (num7 * this.game.Data.SFObj[sf].Xp) / 100.0);
                  if (num8 > 0)
                  {
                    int num9 = mor - num8;
                    if (num9 < num6)
                      num9 = num6;
                    this.game.Data.SFObj[sf].Mor = num9;
                  }
                }
              }
            }
          }
        }
      }
    }

    public void DoTraining(int regnr)
    {
      int peopleGroup = this.game.Data.PeopleObj[this.game.Data.RegimeObj[regnr].People].PeopleGroup;
      if (this.game.Data.UnitCounter < 0)
        return;
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int unr1 = 0; unr1 <= unitCounter1; ++unr1)
      {
        if (this.game.Data.UnitObj[unr1].Regime == regnr & this.game.Data.UnitObj[unr1].PreDef <= -1 && this.game.Data.UnitObj[unr1].SFCount > -1)
        {
          int sfCount = this.game.Data.UnitObj[unr1].SFCount;
          for (int index1 = 0; index1 <= sfCount; ++index1)
          {
            int sf = this.game.Data.UnitObj[unr1].SFList[index1];
            int ap = this.game.Data.SFObj[sf].Ap;
            int mor = this.game.Data.SFObj[sf].Mor;
            int type = this.game.Data.SFObj[sf].Type;
            int people = this.game.Data.SFObj[sf].People;
            int xp = this.game.Data.SFObj[sf].Xp;
            int unitGroup = this.game.Data.SFTypeObj[type].UnitGroup;
            int num1 = 0;
            int unr2 = !this.game.Data.UnitObj[unr1].IsHQ ? this.game.Data.UnitObj[unr1].HQ : unr1;
            if ((double) xp < (double) this.game.Data.RuleVar[63] * 0.5)
              num1 = (int) Math.Round((double) ((float) num1 + Conversion.Int(this.game.Data.RuleVar[64])));
            else if ((double) xp < (double) this.game.Data.RuleVar[63] * 0.75)
            {
              num1 = (int) Math.Round((double) ((float) num1 + Conversion.Int(this.game.Data.RuleVar[64] / 2f)));
              if (num1 == 0 && (double) VBMath.Rnd() < (double) this.game.Data.RuleVar[64] / 2.0)
                num1 = 1;
            }
            else if ((double) xp < (double) this.game.Data.RuleVar[63])
            {
              num1 = (int) Math.Round((double) ((float) num1 + Conversion.Int(this.game.Data.RuleVar[64] / 4f)));
              if (num1 == 0 && (double) VBMath.Rnd() < (double) this.game.Data.RuleVar[64] / 4.0)
                num1 = 1;
            }
            if (unr2 > -1)
            {
              int num2 = this.game.HandyFunctionsObj.GetStaffPercent(unr2, true);
              if (num2 > 100)
                num2 = 100;
              num1 = (int) Math.Round((double) num1 * (1.0 + (double) num2 / 100.0 * ((double) this.game.HandyFunctionsObj.Gethqpow(unr1) / 100.0)));
            }
            SFClass[] sfObj = this.game.Data.SFObj;
            SFClass[] sfClassArray = sfObj;
            int index2 = sf;
            int index3 = index2;
            sfClassArray[index3].Xp = sfObj[index2].Xp + num1;
            if ((double) this.game.Data.SFObj[sf].Xp > (double) this.game.Data.RuleVar[81])
              this.game.Data.SFObj[sf].Xp = (int) Math.Round((double) this.game.Data.RuleVar[81]);
          }
        }
      }
      int unitCounter2 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter2; ++index)
      {
        if (this.game.Data.Turn == this.game.Data.UnitObj[index].Regime & this.game.Data.UnitObj[index].PreDef == -1 && this.game.Data.UnitObj[index].UnitIsGiven)
          this.game.Data.UnitObj[index].UnitIsGiven = false;
      }
    }

    public void ClearTempUnitVariables()
    {
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[index].Regime) == this.game.Data.Turn)
        {
          this.game.Data.UnitObj[index].DidAttack = false;
          this.game.Data.UnitObj[index].DidHQ = false;
          this.game.Data.UnitObj[index].DidMove = false;
          this.game.Data.UnitObj[index].defensiveCombat = 0;
          this.game.Data.UnitObj[index].offensiveCombat = 0;
          this.game.Data.UnitObj[index].MoveAPSpent = 0;
        }
      }
    }

    public void GainApReserveRules(int regNr)
    {
      if ((double) this.game.Data.RuleVar[472] < 1.0 || this.game.Data.Product < 6)
        return;
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.HandyFunctionsObj.GetRegime(this.game.Data.UnitObj[unr].Regime) == regNr)
        {
          if (this.game.Data.UnitObj[unr].DidMove)
          {
            this.game.Data.UnitObj[unr].apReserve = 0;
          }
          else
          {
            UnitClass[] unitObj = this.game.Data.UnitObj;
            UnitClass[] unitClassArray = unitObj;
            int index1 = unr;
            int index2 = index1;
            unitClassArray[index2].apReserve = unitObj[index1].apReserve + (int) Math.Round((double) this.game.Data.RuleVar[472]);
            if ((int) Math.Round((double) this.game.Data.RuleVar[473]) < this.game.Data.UnitObj[unr].apReserve)
              this.game.Data.UnitObj[unr].apReserve = (int) Math.Round((double) this.game.Data.RuleVar[473]);
            int lowestAp = this.game.HandyFunctionsObj.GetLowestAp(unr);
            if (lowestAp <= 0)
              this.game.Data.UnitObj[unr].apReserve = 0;
            else if (lowestAp <= 50)
              this.game.Data.UnitObj[unr].apReserve = (int) Math.Round((double) (this.game.Data.UnitObj[unr].apReserve * lowestAp) / 50.0);
          }
        }
      }
    }

    public void ApToSf_SimplifiedSupplyRules()
    {
      if (this.game.Data.UnitCounter > -1)
      {
        int unitCounter = this.game.Data.UnitCounter;
        for (int unr = 0; unr <= unitCounter; ++unr)
        {
          if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & this.game.Data.UnitObj[unr].PreDef <= -1)
          {
            if ((double) this.game.Data.RuleVar[333] == 0.0 & !this.game.Data.UnitObj[unr].UnitIsGiven)
            {
              this.game.Data.UnitObj[unr].LastAP = -1;
              int num1 = 0;
              int num2 = 0;
              float num3;
              if (this.game.Data.UnitObj[unr].SFCount > -1)
              {
                int sfCount = this.game.Data.UnitObj[unr].SFCount;
                for (int index = 0; index <= sfCount; ++index)
                {
                  int sf = this.game.Data.UnitObj[unr].SFList[index];
                  if (0 > this.game.Data.SFObj[sf].Rdn)
                    this.game.Data.SFObj[sf].Rdn = 0;
                  if (0 > this.game.Data.SFObj[sf].Ap)
                    this.game.Data.SFObj[sf].Ap = 0;
                  int type = this.game.Data.SFObj[sf].Type;
                  int qty = this.game.Data.SFObj[sf].Qty;
                  num2 += this.game.Data.SFTypeObj[type].BasicSupplyNeed * qty;
                  if (this.game.Data.SFTypeObj[type].BasicSupplyNeed > 0 & num2 == 0)
                    num2 = 1;
                  int num4 = this.game.HandyFunctionsObj.SFSupplyUse(sf);
                  num1 += num4;
                }
                float num5;
                if (this.game.Data.UnitObj[unr].OnBoard == -1)
                {
                  num3 = num1 <= this.game.Data.UnitObj[unr].Supply ? 1f : (float) this.game.Data.UnitObj[unr].Supply / (float) num1;
                  if (num1 > num2)
                  {
                    if (num2 < this.game.Data.UnitObj[unr].Supply)
                    {
                      if ((double) ((float) (this.game.Data.UnitObj[unr].Supply - num2) / (float) (num1 - num2)) > 1.0)
                        num5 = 1f;
                    }
                    else
                      num5 = 0.0f;
                  }
                  else
                    num5 = 1f;
                }
                else
                {
                  num3 = num1 <= this.game.Data.UnitObj[this.game.Data.UnitObj[unr].OnBoard].Supply ? 1f : (float) this.game.Data.UnitObj[this.game.Data.UnitObj[unr].OnBoard].Supply / (float) num1;
                  if (num1 > num2)
                  {
                    if (num2 < this.game.Data.UnitObj[this.game.Data.UnitObj[unr].OnBoard].Supply)
                    {
                      if ((double) ((float) (this.game.Data.UnitObj[this.game.Data.UnitObj[unr].OnBoard].Supply - num2) / (float) (num1 - num2)) > 1.0)
                        num5 = 1f;
                    }
                    else
                      num5 = 0.0f;
                  }
                  else
                    num5 = 1f;
                }
              }
              int num6 = 0;
              int num7 = 0;
              float num8 = 0.0f;
              if (this.game.Data.UnitObj[unr].SFCount > -1)
              {
                int sfCount = this.game.Data.UnitObj[unr].SFCount;
                for (int index1 = 0; index1 <= sfCount; ++index1)
                {
                  int sf = this.game.Data.UnitObj[unr].SFList[index1];
                  int type = this.game.Data.SFObj[sf].Type;
                  int qty = this.game.Data.SFObj[sf].Qty;
                  int num9 = this.game.HandyFunctionsObj.SFSupplyUse(sf);
                  int num10 = this.game.Data.SFTypeObj[type].BasicSupplyNeed * qty;
                  if (this.game.Data.SFTypeObj[type].BasicSupplyNeed > 0 & num10 == 0)
                    num10 = 1;
                  float num11 = num3;
                  int num12 = (int) Math.Round((double) Conversion.Int((float) num9 * num11));
                  float num13 = num12 < num10 ? (float) num12 / (float) num10 : 1f;
                  num6 += qty;
                  num7 += num12;
                  num8 += (float) qty * num13;
                  float rdn = (float) this.game.Data.SFObj[sf].Rdn;
                  if ((double) num13 > 0.5)
                  {
                    int num14 = (int) Math.Round(Math.Floor((double) this.game.Data.RuleVar[59] * 2.0 * ((double) num13 - 0.5)));
                    SFClass[] sfObj = this.game.Data.SFObj;
                    SFClass[] sfClassArray = sfObj;
                    int index2 = sf;
                    int index3 = index2;
                    sfClassArray[index3].Rdn = sfObj[index2].Rdn + num14;
                  }
                  else if ((double) num13 < 0.5)
                  {
                    int num15 = (int) Math.Round(Math.Floor((double) this.game.Data.RuleVar[61] * 2.0 * (0.5 - (double) num13)));
                    SFClass[] sfObj = this.game.Data.SFObj;
                    SFClass[] sfClassArray = sfObj;
                    int index4 = sf;
                    int index5 = index4;
                    sfClassArray[index5].Rdn = sfObj[index4].Rdn - num15;
                  }
                  if ((double) this.game.Data.SFObj[sf].Rdn < (double) this.game.Data.RuleVar[60])
                    this.game.Data.SFObj[sf].Rdn = (int) Math.Round((double) this.game.Data.RuleVar[60]);
                  if ((double) this.game.Data.RuleVar[399] > 0.0)
                  {
                    if (this.game.Data.UnitObj[unr].DidAttack & this.game.Data.UnitObj[unr].offensiveCombat > 0 | this.game.Data.UnitObj[unr].DidMove)
                    {
                      int num16 = (int) Math.Round((double) this.game.Data.RuleVar[398]);
                      SFClass[] sfObj = this.game.Data.SFObj;
                      SFClass[] sfClassArray = sfObj;
                      int index6 = sf;
                      int index7 = index6;
                      sfClassArray[index7].Vigor = sfObj[index6].Vigor - num16;
                      if (this.game.Data.SFObj[sf].Vigor < 1)
                        this.game.Data.SFObj[sf].Vigor = 1;
                    }
                    else
                    {
                      int num17 = 0;
                      int num18 = 100;
                      if (this.game.Data.UnitObj[unr].X > -1)
                      {
                        int regimeCounter = this.game.Data.RegimeCounter;
                        for (int Index = 0; Index <= regimeCounter; ++Index)
                        {
                          if (Index != this.game.Data.Turn && this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y].get_ZocPts(Index) > 0)
                            num17 = 1;
                        }
                      }
                      if (this.game.Data.SFObj[sf].Vigor < 60)
                        unr = unr;
                      if (this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                        num17 = 0;
                      if (num17 == 0)
                        num18 = (int) Math.Round((double) num18 * 1.5);
                      if ((int) Math.Round(Conversion.Val((object) this.game.Data.RuleVar[393])) == 1)
                        num18 = (int) Math.Round((double) num18 * 1.5);
                      if (this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                        num18 = (int) Math.Round((double) num18 * 1.5);
                      if (this.game.Data.UnitObj[unr].defensiveCombat > 0 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                      {
                        num18 = (int) Math.Round((double) (int) Math.Round((double) num18 * (Math.Min(50.0, (double) Math.Min(100, this.game.Data.SFObj[sf].Rdn) / 2.0) / 100.0)) * ((double) Math.Min(100, this.game.Data.SFObj[sf].Rdn) / 100.0));
                        if (num18 < 0)
                          num18 = 0;
                      }
                      int num19 = (int) Math.Round((double) num18 * (double) this.game.Data.RuleVar[399] / 100.0);
                      if (!this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                        num19 = (int) Math.Round(Math.Ceiling((double) (num19 * Math.Max(20, this.game.Data.SFObj[sf].Vigor)) / 100.0));
                      SFClass[] sfObj = this.game.Data.SFObj;
                      SFClass[] sfClassArray = sfObj;
                      int index8 = sf;
                      int index9 = index8;
                      sfClassArray[index9].Vigor = sfObj[index8].Vigor + num19;
                      if (this.game.Data.SFObj[sf].Vigor > 100)
                        this.game.Data.SFObj[sf].Vigor = 100;
                    }
                  }
                  int num20 = 100;
                  if ((double) this.game.Data.RuleVar[399] > 0.0)
                  {
                    num20 = (int) Math.Round(Math.Ceiling(Math.Sqrt((double) this.game.Data.SFObj[sf].Vigor) * 10.0));
                    if (num20 > 100)
                      num20 = 100;
                  }
                  if (this.game.Data.SFObj[sf].Rdn > num20)
                    this.game.Data.SFObj[sf].Rdn = num20;
                  if ((double) this.game.Data.RuleVar[814] < 1.0)
                  {
                    if (this.game.Data.UnitObj[unr].OnBoard == -1)
                      this.game.Data.UnitObj[unr].Supply -= num12;
                    else
                      this.game.Data.UnitObj[this.game.Data.UnitObj[unr].OnBoard].Supply -= num12;
                  }
                }
                if (num6 > 0)
                {
                  float num21 = num8 / (float) num6;
                  if ((double) num21 < 1.0)
                  {
                    int num22 = (int) Math.Round((double) (this.game.Data.RuleVar[437] * (1f - num21)));
                    UnitClass[] unitObj = this.game.Data.UnitObj;
                    UnitClass[] unitClassArray = unitObj;
                    int index10 = unr;
                    int index11 = index10;
                    unitClassArray[index11].SupplyConsume = unitObj[index10].SupplyConsume - num22;
                    if (0 > this.game.Data.UnitObj[unr].SupplyConsume)
                      this.game.Data.UnitObj[unr].SupplyConsume = 0;
                  }
                  else
                  {
                    int num23 = (int) Math.Round((double) (this.game.Data.RuleVar[437] * 2f));
                    UnitClass[] unitObj = this.game.Data.UnitObj;
                    UnitClass[] unitClassArray = unitObj;
                    int index12 = unr;
                    int index13 = index12;
                    unitClassArray[index13].SupplyConsume = unitObj[index12].SupplyConsume + num23;
                    if (100 < this.game.Data.UnitObj[unr].SupplyConsume)
                      this.game.Data.UnitObj[unr].SupplyConsume = 100;
                  }
                }
                else
                  this.game.Data.UnitObj[unr].SupplyConsume = 0;
                this.MaxReadinessRule(unr);
              }
            }
            else
              this.game.Data.UnitObj[unr].SupplyConsume = 100;
          }
        }
      }
      if (this.game.Data.UnitCounter > -1)
      {
        int unitCounter = this.game.Data.UnitCounter;
        for (int index14 = 0; index14 <= unitCounter; ++index14)
        {
          if (this.game.Data.UnitObj[index14].Regime == this.game.Data.Turn && !this.game.Data.UnitObj[index14].UnitIsGiven && this.game.Data.UnitObj[index14].SFCount > -1)
          {
            int sfCount = this.game.Data.UnitObj[index14].SFCount;
            for (int index15 = 0; index15 <= sfCount; ++index15)
            {
              int sf = this.game.Data.UnitObj[index14].SFList[index15];
              this.game.Data.SFObj[sf].Ap = 50;
              SFClass[] sfObj1 = this.game.Data.SFObj;
              SFClass[] sfClassArray1 = sfObj1;
              int index16 = sf;
              int index17 = index16;
              sfClassArray1[index17].Ap = sfObj1[index16].Ap + (int) Math.Round(Math.Floor((double) this.game.Data.SFObj[sf].Rdn * 0.5));
              this.game.Data.SFObj[sf].Ap = (int) Math.Round(Math.Floor((double) (this.game.Data.SFObj[sf].Ap * this.game.Data.UnitObj[index14].SupplyConsume) / 100.0));
              if (this.game.Data.SFObj[sf].Ap > 100)
                this.game.Data.SFObj[sf].Ap = 100;
              this.game.Data.SFObj[sf].Ap = (int) Math.Round((double) ((float) this.game.Data.SFObj[sf].Ap * this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].ApMod));
              int sfEpGrowth = this.game.HandyFunctionsObj.GetSfEPGrowth(sf);
              SFClass[] sfObj2 = this.game.Data.SFObj;
              SFClass[] sfClassArray2 = sfObj2;
              int index18 = sf;
              int index19 = index18;
              sfClassArray2[index19].EP = (int) Math.Round((double) sfObj2[index18].EP + (double) sfEpGrowth * ((double) this.game.Data.SFObj[sf].Ap / 100.0));
              if ((double) sfEpGrowth * (double) this.game.Data.RuleVar[42] < (double) this.game.Data.SFObj[sf].EP)
                this.game.Data.SFObj[sf].EP = (int) Math.Round((double) ((float) sfEpGrowth * this.game.Data.RuleVar[42]));
              if (this.game.Data.UnitObj[index14].X >= 0 && this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater == 1 | this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.Data.UnitObj[index14].Map].HexObj[this.game.Data.UnitObj[index14].X, this.game.Data.UnitObj[index14].Y].LandscapeType].IsSea && (double) this.game.Data.RuleVar[44] > (double) this.game.Data.SFObj[sf].Ap)
                this.game.Data.SFObj[sf].Ap = (int) Math.Round((double) this.game.Data.RuleVar[44]);
              if (this.game.Data.UnitObj[index14].SetAPToZero == 1)
                this.game.Data.SFObj[sf].Ap = 0;
            }
          }
          this.game.Data.UnitObj[index14].SetAPToZero = 0;
        }
      }
      this.MaximumHQSuppliesRule();
    }

    public void ApToSf()
    {
      if ((double) this.game.Data.RuleVar[434] > 0.0)
      {
        this.ApToSf_SimplifiedSupplyRules();
      }
      else
      {
        if (this.game.Data.UnitCounter > -1)
        {
          int unitCounter = this.game.Data.UnitCounter;
          for (int unr = 0; unr <= unitCounter; ++unr)
          {
            if (unr == 137)
              unr = unr;
            if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & this.game.Data.UnitObj[unr].PreDef <= -1)
            {
              if ((double) this.game.Data.RuleVar[333] == 0.0 & !this.game.Data.UnitObj[unr].UnitIsGiven)
              {
                this.game.Data.UnitObj[unr].LastAP = -1;
                int num1 = 0;
                int num2 = 0;
                if (unr == 154)
                  unr = unr;
                float num3;
                float num4;
                if (this.game.Data.UnitObj[unr].SFCount > -1)
                {
                  int sfCount = this.game.Data.UnitObj[unr].SFCount;
                  for (int index = 0; index <= sfCount; ++index)
                  {
                    int sf = this.game.Data.UnitObj[unr].SFList[index];
                    if (0 > this.game.Data.SFObj[sf].Rdn)
                      this.game.Data.SFObj[sf].Rdn = 0;
                    if (0 > this.game.Data.SFObj[sf].Ap)
                      this.game.Data.SFObj[sf].Ap = 0;
                    int type = this.game.Data.SFObj[sf].Type;
                    int qty = this.game.Data.SFObj[sf].Qty;
                    num2 = (int) Math.Round((double) num2 + (double) this.game.Data.SFTypeObj[type].BasicSupplyNeed / 2.0 * (double) qty);
                    if (this.game.Data.SFTypeObj[type].BasicSupplyNeed > 0 & num2 == 0)
                      num2 = 1;
                    int num5 = this.game.HandyFunctionsObj.SFSupplyUse(sf);
                    num1 += num5;
                  }
                  if (this.game.Data.UnitObj[unr].OnBoard == -1)
                  {
                    num3 = num1 <= this.game.Data.UnitObj[unr].Supply ? 1f : (float) this.game.Data.UnitObj[unr].Supply / (float) num1;
                    if (num1 > num2)
                    {
                      if (num2 < this.game.Data.UnitObj[unr].Supply)
                      {
                        num4 = (float) (this.game.Data.UnitObj[unr].Supply - num2) / (float) (num1 - num2);
                        if ((double) num4 > 1.0)
                          num4 = 1f;
                      }
                      else
                        num4 = 0.0f;
                    }
                    else
                      num4 = 1f;
                  }
                  else
                  {
                    num3 = num1 <= this.game.Data.UnitObj[this.game.Data.UnitObj[unr].OnBoard].Supply ? 1f : (float) this.game.Data.UnitObj[this.game.Data.UnitObj[unr].OnBoard].Supply / (float) num1;
                    if (num1 > num2)
                    {
                      if (num2 < this.game.Data.UnitObj[this.game.Data.UnitObj[unr].OnBoard].Supply)
                      {
                        num4 = (float) (this.game.Data.UnitObj[this.game.Data.UnitObj[unr].OnBoard].Supply - num2) / (float) (num1 - num2);
                        if ((double) num4 > 1.0)
                          num4 = 1f;
                      }
                      else
                        num4 = 0.0f;
                    }
                    else
                      num4 = 1f;
                  }
                }
                if (unr == 65)
                  ;
                int num6 = 0;
                int num7 = 0;
                float num8 = 0.0f;
                if (this.game.Data.UnitObj[unr].SFCount > -1)
                {
                  int sfCount = this.game.Data.UnitObj[unr].SFCount;
                  for (int index = 0; index <= sfCount; ++index)
                  {
                    int sf = this.game.Data.UnitObj[unr].SFList[index];
                    int type = this.game.Data.SFObj[sf].Type;
                    int qty = this.game.Data.SFObj[sf].Qty;
                    int num9 = this.game.HandyFunctionsObj.SFSupplyUse(sf);
                    int num10 = (int) Math.Round((double) this.game.Data.SFTypeObj[type].BasicSupplyNeed / 2.0 * (double) qty);
                    if (this.game.Data.SFTypeObj[type].BasicSupplyNeed > 0 & num10 == 0)
                      num10 = 1;
                    float num11 = num3;
                    int num12 = (int) Math.Round((double) Conversion.Int((float) num9 * num11));
                    float num13 = num12 < num10 ? (float) (1.0 - (double) num12 / (double) num10) : 0.0f;
                    num6 += qty;
                    num7 += num12;
                    num8 += (float) qty * num13;
                    float rdn = (float) this.game.Data.SFObj[sf].Rdn;
                    int num14 = (int) Math.Round((double) ((float) (int) Math.Round((double) this.game.Data.RuleVar[61]) * num13));
                    this.game.Data.SFObj[sf].Rdn = (int) Math.Round(Conversion.Int((double) this.game.Data.SFObj[sf].Rdn * ((double) (100 - num14) / 100.0)));
                    if ((double) this.game.Data.SFObj[sf].Rdn < (double) this.game.Data.RuleVar[60])
                      this.game.Data.SFObj[sf].Rdn = (int) Math.Round((double) this.game.Data.RuleVar[60]);
                    if ((double) num13 == 0.0)
                    {
                      int num15 = (int) Math.Round((double) (this.game.Data.RuleVar[59] * num4));
                      int num16;
                      if (this.game.Data.UnitObj[unr].X > -1)
                      {
                        if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.Data.UnitObj[unr].Map].HexObj[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y].LandscapeType].IsSea)
                          num16 = (int) Math.Round(Conversion.Int(Math.Sqrt((double) this.game.Data.MapObj[this.game.Data.UnitObj[unr].Map].HexObj[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y].DammageToInfra)));
                      }
                      else
                        num16 = 0;
                      if (num16 > 90)
                        num16 = 90;
                      if (this.game.Data.UnitObj[unr].X > -1 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.Data.UnitObj[unr].Map].HexObj[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y].LandscapeType].IsSea)
                        num15 = (int) Math.Round((double) num15 * (1.0 - (double) num16 / 100.0));
                      this.game.Data.SFObj[sf].Rdn += num15;
                      if (100 < this.game.Data.SFObj[sf].Rdn)
                        this.game.Data.SFObj[sf].Rdn = 100;
                    }
                    if ((double) this.game.Data.RuleVar[814] < 1.0)
                    {
                      if (this.game.Data.UnitObj[unr].OnBoard == -1)
                        this.game.Data.UnitObj[unr].Supply -= num12;
                      else
                        this.game.Data.UnitObj[this.game.Data.UnitObj[unr].OnBoard].Supply -= num12;
                    }
                  }
                  if (num6 > 0)
                  {
                    float num17 = num8 / (float) num6;
                    this.game.Data.UnitObj[unr].SupplyConsume = (int) Math.Round(100.0 * (1.0 - (double) num17));
                  }
                  else
                    this.game.Data.UnitObj[unr].SupplyConsume = 0;
                  this.MaxReadinessRule(unr);
                }
              }
              else
                this.game.Data.UnitObj[unr].SupplyConsume = 100;
            }
          }
        }
        if (this.game.Data.UnitCounter > -1)
        {
          int unitCounter = this.game.Data.UnitCounter;
          for (int index1 = 0; index1 <= unitCounter; ++index1)
          {
            if (this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn && !this.game.Data.UnitObj[index1].UnitIsGiven && this.game.Data.UnitObj[index1].SFCount > -1)
            {
              int sfCount = this.game.Data.UnitObj[index1].SFCount;
              for (int index2 = 0; index2 <= sfCount; ++index2)
              {
                int sf = this.game.Data.UnitObj[index1].SFList[index2];
                this.game.Data.SFObj[sf].Ap = (int) Math.Round(Conversion.Int((double) this.game.Data.SFObj[sf].Rdn * 0.5 + (double) this.game.Data.UnitObj[index1].SupplyConsume * 0.5));
                if (this.game.Data.SFObj[sf].Ap > 100)
                  this.game.Data.SFObj[sf].Ap = 100;
                this.game.Data.SFObj[sf].Ap = (int) Math.Round((double) ((float) this.game.Data.SFObj[sf].Ap * this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].ApMod));
                int sfEpGrowth = this.game.HandyFunctionsObj.GetSfEPGrowth(sf);
                SFClass[] sfObj = this.game.Data.SFObj;
                SFClass[] sfClassArray = sfObj;
                int index3 = sf;
                int index4 = index3;
                sfClassArray[index4].EP = (int) Math.Round((double) sfObj[index3].EP + (double) sfEpGrowth * ((double) this.game.Data.SFObj[sf].Ap / 100.0));
                if ((double) sfEpGrowth * (double) this.game.Data.RuleVar[42] < (double) this.game.Data.SFObj[sf].EP)
                  this.game.Data.SFObj[sf].EP = (int) Math.Round((double) ((float) sfEpGrowth * this.game.Data.RuleVar[42]));
                if (this.game.Data.UnitObj[index1].X >= 0 && this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater == 1 | this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.Data.UnitObj[index1].Map].HexObj[this.game.Data.UnitObj[index1].X, this.game.Data.UnitObj[index1].Y].LandscapeType].IsSea && (double) this.game.Data.RuleVar[44] > (double) this.game.Data.SFObj[sf].Ap)
                  this.game.Data.SFObj[sf].Ap = (int) Math.Round((double) this.game.Data.RuleVar[44]);
                if (this.game.Data.UnitObj[index1].SetAPToZero == 1)
                  this.game.Data.SFObj[sf].Ap = 0;
              }
            }
            this.game.Data.UnitObj[index1].SetAPToZero = 0;
          }
        }
        this.MaximumHQSuppliesRule();
      }
    }

    public void MaximumHQSuppliesRule()
    {
      if ((double) this.game.Data.RuleVar[336] == 1.0)
      {
        int unitCounter = this.game.Data.UnitCounter;
        for (int unr = 0; unr <= unitCounter; ++unr)
        {
          if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].Supply > this.game.HandyFunctionsObj.UnitSupplyStore(unr))
            this.game.Data.UnitObj[unr].Supply = this.game.HandyFunctionsObj.UnitSupplyStore(unr);
        }
      }
      else
      {
        if ((double) this.game.Data.RuleVar[336] <= 100.0)
          return;
        int unitCounter = this.game.Data.UnitCounter;
        for (int unr = 0; unr <= unitCounter; ++unr)
        {
          if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].Supply > this.game.HandyFunctionsObj.UnitSupplyStore(unr))
          {
            bool flag = false;
            if (this.game.Data.UnitObj[unr].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unr].Historical].Type == 8)
              flag = true;
            if (this.game.Data.UnitObj[unr].HQ == -1 | flag)
            {
              int num1 = this.game.Data.UnitObj[unr].Supply - this.game.HandyFunctionsObj.UnitSupplyStore(unr);
              if ((double) num1 > (double) this.game.Data.RuleVar[336])
              {
                int num2 = (int) Math.Round((double) ((float) num1 - this.game.Data.RuleVar[336]));
                this.game.Data.UnitObj[unr].Supply -= num2;
              }
            }
            else if (this.game.Data.UnitObj[unr].Supply > this.game.HandyFunctionsObj.UnitSupplyStore(unr))
              this.game.Data.UnitObj[unr].Supply = this.game.HandyFunctionsObj.UnitSupplyStore(unr);
          }
        }
      }
    }

    public int AutoReinforce_UnitWillGive(int unr, int typ, int movtyp, int ppl)
    {
      int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
      for (int index = 0; index <= sfCount1; ++index)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index];
        int reinforcementType = this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].ReinforcementType;
        int moveType = this.game.Data.SFObj[sf].MoveType;
        int people = this.game.Data.SFObj[sf].People;
        if (typ == reinforcementType & movtyp == moveType & ppl == people)
          return sf;
      }
      int sfCount2 = this.game.Data.UnitObj[unr].SFCount;
      for (int index = 0; index <= sfCount2; ++index)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index];
        int reinforcementType2 = this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].ReinforcementType2;
        int moveType = this.game.Data.SFObj[sf].MoveType;
        int people = this.game.Data.SFObj[sf].People;
        if (typ == reinforcementType2 & movtyp == moveType & ppl == people)
          return sf;
      }
      return -1;
    }

    public int AutoReinforce_HQwillGive(
      int hq,
      int unr,
      SimpleList ideallist,
      int typ,
      int movtyp,
      int ppl,
      int secondaryPhase)
    {
      if (ideallist.FindNr(typ, movtyp, ppl) == -1)
        return -1;
      SimpleList simpleList1 = new SimpleList();
      SimpleList simpleList2 = new SimpleList();
      SimpleList simpleList3 = new SimpleList();
      int val1 = 999;
      if (this.game.Data.Product == 6)
        val1 = 1;
      int nr = ideallist.FindNr(typ, movtyp, ppl);
      if (nr == -1)
        return -1;
      int num1 = ideallist.Data3[nr];
      if (this.game.Data.UnitObj[unr].IsHQ)
        num1 = 99;
      int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
      int num2;
      for (int index = 0; index <= sfCount1; ++index)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index];
        int type = this.game.Data.SFObj[sf].Type;
        int reinforcementType = this.game.Data.SFTypeObj[type].ReinforcementType;
        int moveType = this.game.Data.SFObj[sf].MoveType;
        int people = this.game.Data.SFObj[sf].People;
        if (reinforcementType == typ & moveType == movtyp & people == ppl)
        {
          ++num2;
          simpleList1.Add(type, this.game.Data.SFObj[sf].Qty * Math.Min(val1, this.game.Data.SFTypeObj[type].PowerPts));
        }
      }
      simpleList1.Sort();
      int sfCount2 = this.game.Data.UnitObj[hq].SFCount;
      for (int index = 0; index <= sfCount2; ++index)
      {
        int sf = this.game.Data.UnitObj[hq].SFList[index];
        int type = this.game.Data.SFObj[sf].Type;
        int num3 = secondaryPhase != 0 ? this.game.Data.SFTypeObj[type].ReinforcementType2 : this.game.Data.SFTypeObj[type].ReinforcementType;
        int moveType = this.game.Data.SFObj[sf].MoveType;
        int people = this.game.Data.SFObj[sf].People;
        if (num3 == typ & moveType == movtyp & people == ppl)
          simpleList3.Add(type, this.game.Data.SFObj[sf].Qty * Math.Min(val1, this.game.Data.SFTypeObj[type].PowerPts), sf);
      }
      if (Strings.InStr(this.game.Data.UnitObj[unr].Name, "***") > 0)
        unr = unr;
      if ((double) this.game.Data.RuleVar[910] > 0.0 | (double) this.game.Data.RuleVar[911] > 0.0 | (double) this.game.Data.RuleVar[912] > 0.0 && !this.game.HandyFunctionsObj.HasUnitAirSF(unr) & !this.game.HandyFunctionsObj.HasUnitNavySF(unr) & !this.game.Data.UnitObj[unr].IsHQ)
      {
        int num4 = 0;
        int sfCount3 = this.game.Data.UnitObj[unr].SFCount;
        for (int index = 0; index <= sfCount3; ++index)
        {
          int sf = this.game.Data.UnitObj[unr].SFList[index];
          int type = this.game.Data.SFObj[sf].Type;
          int num5 = 1;
          if ((double) this.game.Data.RuleVar[910] == (double) this.game.Data.SFTypeObj[type].MoveType)
            num5 = 0;
          if ((double) this.game.Data.RuleVar[911] == (double) this.game.Data.SFTypeObj[type].MoveType)
            num5 = 0;
          if ((double) this.game.Data.RuleVar[912] == (double) this.game.Data.SFTypeObj[type].MoveType)
            num5 = 0;
          if (this.game.Data.SFTypeObj[type].CarryCap > 0)
            num5 = 0;
          if (num5 == 1)
            num4 += this.game.Data.SFTypeObj[type].Weight * this.game.Data.SFObj[sf].Qty;
        }
        this.game.HandyFunctionsObj.GetMoveType(unr);
        int num6 = 0;
        int num7;
        if (this.game.Data.UnitObj[unr].Historical > -1 && this.game.Data.UnitObj[unr].HistoricalSubPart > -1)
        {
          num7 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unr].Historical].SubParts[this.game.Data.UnitObj[unr].HistoricalSubPart];
          if (num7 > -1)
          {
            num7 = this.game.HandyFunctionsObj.GetPreDef(num7);
            num6 = this.game.HandyFunctionsObj.GetCarryCapPts(num7, 0);
          }
        }
        int carryCapPts = this.game.HandyFunctionsObj.GetCarryCapPts(unr, 0);
        if (simpleList3.Counter > -1)
        {
          for (int counter = simpleList3.Counter; counter <= 0; ++counter)
          {
            int index = simpleList3.Id[counter];
            if (num4 + this.game.Data.SFTypeObj[index].Weight > carryCapPts & num6 > carryCapPts)
            {
              int num8 = 1;
              if (num7 > -1 && this.game.HandyFunctionsObj.GetMoveType(num7) == this.game.Data.SFTypeObj[index].MoveType)
                num8 = 0;
              if ((double) this.game.Data.RuleVar[910] == (double) this.game.Data.SFTypeObj[index].MoveType)
                num8 = 0;
              if ((double) this.game.Data.RuleVar[911] == (double) this.game.Data.SFTypeObj[index].MoveType)
                num8 = 0;
              if ((double) this.game.Data.RuleVar[912] == (double) this.game.Data.SFTypeObj[index].MoveType)
                num8 = 0;
              if (num8 == 1)
                simpleList3.RemoveNr(counter);
            }
          }
        }
      }
      simpleList3.Sort();
      int num9 = 1;
      if (num1 > num2)
      {
        for (int counter = simpleList3.Counter; counter >= 0; counter += -1)
        {
          if (simpleList1.FindNr(simpleList3.Id[counter]) == -1)
            return simpleList3.Data1[counter];
        }
      }
      if (num9 == 1)
      {
        int counter1 = simpleList1.Counter;
        for (int index = 0; index <= counter1; ++index)
        {
          for (int counter2 = simpleList3.Counter; counter2 >= 0; counter2 += -1)
          {
            if (simpleList3.Id[counter2] == simpleList1.Id[index])
              return simpleList3.Data1[counter2];
          }
        }
      }
      for (int counter = simpleList3.Counter; counter >= 0; counter += -1)
      {
        if (simpleList1.FindNr(simpleList3.Id[counter]) == -1)
          return simpleList3.Data1[counter];
      }
      return this.game.Data.UnitObj[unr].SFCount >= 7 | !this.game.Data.UnitObj[unr].IsHQ ? -2 : -1;
    }

    public void WritePLog(string s)
    {
      if ((double) this.game.Data.RuleVar[948] < 1.0 & !this.game.EventRelatedObj.Helper_IsDebug())
        return;
      StreamWriter text = File.CreateText(this.game.AppPath + "logs/" + s + ".txt");
      int plogcounter = this.plogcounter;
      for (int index = 0; index <= plogcounter; ++index)
        text.WriteLine(this.plog[index]);
      text.Close();
    }

    public void AddPLog(string s)
    {
      if ((double) this.game.Data.RuleVar[948] < 1.0 & !this.game.EventRelatedObj.Helper_IsDebug())
        return;
      ++this.plogcounter;
      this.plog = (string[]) Utils.CopyArray((Array) this.plog, (Array) new string[this.plogcounter + 1]);
      this.plog[this.plogcounter] = s;
    }

    public void DoAutoReinforce()
    {
      Coordinate[] coordinateArray = new Coordinate[251];
      int[] numArray1 = new int[this.game.Data.UnitCounter + 1];
      int[] numArray2 = new int[this.game.Data.UnitCounter + 1];
      int[] numArray3 = new int[this.game.Data.UnitCounter + 1];
      SimpleList[] simpleListArray1 = new SimpleList[this.game.Data.UnitCounter + 1];
      SimpleList[] simpleListArray2 = new SimpleList[this.game.Data.UnitCounter + 1];
      SimpleList[] simpleListArray3 = new SimpleList[this.game.Data.UnitCounter + 1];
      SimpleList[] simpleListArray4 = new SimpleList[this.game.Data.UnitCounter + 1];
      SimpleList[] simpleListArray5 = new SimpleList[this.game.Data.UnitCounter + 1];
      if (this.game.Data.UnitCounter < 0)
        return;
      int[] numArray4 = new int[this.game.Data.UnitCounter + 1];
      int[] numArray5 = new int[this.game.Data.UnitCounter + 1];
      MapMatrix2[] mapMatrix2Array1 = new MapMatrix2[this.game.Data.MapCounter + 1];
      MapMatrix2[] mapMatrix2Array2 = new MapMatrix2[this.game.Data.MapCounter + 1];
      MapMatrix2[] mapMatrix2Array3 = new MapMatrix2[this.game.Data.MapCounter + 1];
      int val1_1 = 999;
      if (this.game.Data.Product == 6)
        val1_1 = 1;
      bool useTrafficRules = false;
      if ((double) this.game.Data.RuleVar[459] > 0.0 & this.game.Data.Product >= 6)
        useTrafficRules = true;
      int num1 = -1;
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
        numArray4[index] = -1;
      int index1;
      if ((double) this.game.Data.RuleVar[499] > 0.0)
      {
        int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[499]));
        if (stringListById > -1)
        {
          bool[] flaggy = new bool[this.game.Data.StringListObj[stringListById].Length + 1];
          for (int length = this.game.Data.StringListObj[stringListById].Length; length >= 0; length += -1)
          {
            index1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[length, 0]));
            if (index1 == this.game.Data.Turn)
              flaggy[length] = true;
          }
          this.game.Data.StringListObj[stringListById].RemoveMultipleRow(flaggy);
        }
      }
      this.plogcounter = -1;
      this.AddPLog("AUTO-REINFORCE");
      this.AddPLog("");
      for (int unitCounter2 = this.game.Data.UnitCounter; unitCounter2 >= 0; unitCounter2 += -1)
      {
        if ((double) this.game.Data.RuleVar[977] > 0.0 && this.game.Data.UnitObj[unitCounter2].SOReplacementPercent == 0)
          this.game.Data.UnitObj[unitCounter2].SOReplacementPercent = 100;
        int num2 = (double) this.game.Data.RuleVar[887] != 1.0 ? Math.Min(100, this.game.Data.UnitObj[unitCounter2].SOReplacementPercent) : Math.Min(100, this.game.HandyFunctionsObj.GetAggregatedReplacementRequest(unitCounter2));
        if (this.game.Data.UnitObj[unitCounter2].SFCount == -1 & num2 == 0 & this.game.Data.UnitObj[unitCounter2].X > -1 & this.game.Data.UnitObj[unitCounter2].Regime == this.game.Data.Turn & this.game.Data.UnitObj[unitCounter2].PreDef == -1)
        {
          int Number = 0;
          if (this.game.Data.UnitObj[unitCounter2].Historical > -1)
          {
            int index2 = this.game.Data.UnitObj[unitCounter2].Historical;
            if (this.game.Data.HistoricalUnitObj[index2].ModelMaster > -1)
              index2 = this.game.Data.HistoricalUnitObj[index2].ModelMaster;
            if (this.game.Data.HistoricalUnitObj[index2].PP > 0)
            {
              int num3 = 0;
              int index3 = 0;
              do
              {
                if (this.game.Data.HistoricalUnitObj[index2].SubParts[index3] > -1)
                  ++num3;
                ++index3;
              }
              while (index3 <= 9);
              Number = (int) Math.Round((double) this.game.Data.HistoricalUnitObj[index2].PP / (double) num3);
            }
          }
          this.AddPLog("(RETURN) DISBAND EMPTY UNIT = " + this.game.Data.UnitObj[unitCounter2].Name + " earns " + Conversion.Str((object) Number) + " pp point as refund.");
          DataClass data = this.game.Data;
          int nr = unitCounter2;
          GameClass gameClass = (GameClass) null;
          ref GameClass local = ref gameClass;
          data.RemoveUnit(nr, ref local);
          if (!(this.game.Data.RegimeObj[this.game.Data.Turn].AI & (double) this.game.Data.RuleVar[914] == 1.0))
          {
            RegimeClass[] regimeObj = this.game.Data.RegimeObj;
            RegimeClass[] regimeClassArray = regimeObj;
            int turn = this.game.Data.Turn;
            int index4 = turn;
            regimeClassArray[index4].ResPts = regimeObj[turn].ResPts + Number;
          }
        }
      }
      int num4;
      do
      {
        num4 = 0;
        ++num1;
        int unitCounter3 = this.game.Data.UnitCounter;
        for (int index5 = 0; index5 <= unitCounter3; ++index5)
        {
          if (this.game.Data.UnitObj[index5].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index5].IsHQ & this.game.Data.UnitObj[index5].PreDef <= -1)
          {
            if (num1 == 0)
            {
              if (this.game.Data.UnitObj[index5].HQ == -1)
              {
                numArray4[index5] = 0;
                num4 = 1;
              }
            }
            else if (this.game.Data.UnitObj[index5].HQ > -1 & numArray4[index5] == -1 & this.game.Data.UnitObj[index5].PreDef <= -1)
            {
              int hq = this.game.Data.UnitObj[index5].HQ;
              if (numArray4[hq] == num1 - 1)
              {
                num4 = 1;
                numArray4[index5] = num1;
              }
            }
          }
        }
      }
      while (num4 > 0);
      int num5 = num1 - 1;
      if ((double) this.game.Data.RuleVar[887] == 1.0)
        num5 = 0;
      for (int index6 = num5; index6 >= 0; index6 += -1)
      {
        int unitCounter4 = this.game.Data.UnitCounter;
        for (int index7 = 0; index7 <= unitCounter4; ++index7)
        {
          if (this.game.Data.UnitObj[index7].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index7].IsHQ & this.game.Data.UnitObj[index7].PreDef <= -1 && numArray4[index7] == index6)
          {
            this.AddPLog("");
            this.AddPLog("----------------------");
            this.AddPLog("----------------------");
            this.AddPLog("AUTO-REINFORCE CHECKING FOR " + this.game.Data.UnitObj[index7].Name);
            this.AddPLog("----------------------");
            this.AddPLog("----------------------");
            this.AddPLog("");
            CoordList coordList1;
            if ((double) this.game.Data.RuleVar[340] > -1.0)
            {
              coordList1 = this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[2]), 0, (int) Math.Round((double) this.game.Data.RuleVar[339]), this.game.Data.UnitObj[index7].X, this.game.Data.UnitObj[index7].Y, this.game.Data.UnitObj[index7].Map, allowshoredrop: true, SeaBlock: true);
              int mapCounter1 = this.game.Data.MapCounter;
              for (int index8 = 0; index8 <= mapCounter1; ++index8)
                mapMatrix2Array2[index8] = this.game.EditObj.TempValue[index8].Clone();
              coordList1 = this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[1]), 1, (int) Math.Round((double) this.game.Data.RuleVar[339]), this.game.Data.UnitObj[index7].X, this.game.Data.UnitObj[index7].Y, this.game.Data.UnitObj[index7].Map, allowshoredrop: true, SeaBlock: true);
              int mapCounter2 = this.game.Data.MapCounter;
              for (int index9 = 0; index9 <= mapCounter2; ++index9)
                mapMatrix2Array1[index9] = this.game.EditObj.TempValue[index9].Clone();
              coordList1 = this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, (int) Math.Round((double) this.game.Data.RuleVar[339]), this.game.Data.UnitObj[index7].X, this.game.Data.UnitObj[index7].Y, this.game.Data.UnitObj[index7].Map, allowshoredrop: true, SeaBlock: true);
              int mapCounter3 = this.game.Data.MapCounter;
              for (int index10 = 0; index10 <= mapCounter3; ++index10)
                mapMatrix2Array3[index10] = this.game.EditObj.TempValue[index10].Clone();
            }
            int num6 = 1;
            do
            {
              int secondaryPhase = 0;
              do
              {
                Application.DoEvents();
                int unitCounter5 = this.game.Data.UnitCounter;
                for (int index11 = 0; index11 <= unitCounter5; ++index11)
                  simpleListArray2[index11] = new SimpleList();
                int index12;
                if ((double) this.game.Data.RuleVar[455] > 0.0)
                {
                  this.game.HandyFunctionsObj.MakeFuzzyOwner(true, false, this.game.Data.Turn);
                  this.game.HandyFunctionsObj.RedimTempValue3(0);
                  int mapWidth = this.game.Data.MapObj[index12].MapWidth;
                  for (int index13 = 0; index13 <= mapWidth; ++index13)
                  {
                    int mapHeight = this.game.Data.MapObj[index12].MapHeight;
                    for (int index14 = 0; index14 <= mapHeight; ++index14)
                      this.game.EditObj.TempValue3[index12].Value[index13, index14] = this.game.Data.MapObj[0].HexObj[index13, index14].Regime;
                  }
                  this.game.HandyFunctionsObj.MakeFuzzyOwner(false, false, this.game.Data.Turn);
                }
                coordList1 = this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 99, (int) Math.Round((double) this.game.Data.RuleVar[339]), this.game.Data.UnitObj[index7].X, this.game.Data.UnitObj[index7].Y, this.game.Data.UnitObj[index7].Map, allowshoredrop: true, SeaBlock: true, useTrafficRules: useTrafficRules);
                this.AddPLog("");
                this.AddPLog("*********************");
                this.AddPLog("FOR HQ: " + this.game.Data.UnitObj[index7].Name + " , PRIORITY CYCLE: " + num6.ToString() + " , REINFORCEMENTTYPE1/2 = " + (secondaryPhase + 1).ToString());
                this.AddPLog("*********************");
                this.AddPLog("");
                SimpleList simpleList1 = new SimpleList();
                int index15 = index7;
                int sfCount1 = this.game.Data.UnitObj[index15].SFCount;
                for (int index16 = 0; index16 <= sfCount1; ++index16)
                {
                  int sf = this.game.Data.UnitObj[index15].SFList[index16];
                  int type = this.game.Data.SFObj[sf].Type;
                  index1 = secondaryPhase != 0 ? this.game.Data.SFTypeObj[type].ReinforcementType2 : this.game.Data.SFTypeObj[type].ReinforcementType;
                  int moveType = this.game.Data.SFObj[sf].MoveType;
                  int people = this.game.Data.SFObj[sf].People;
                  int nr = simpleList1.FindNr(index1, moveType, people);
                  if (nr > -1)
                  {
                    int[] weight = simpleList1.Weight;
                    int[] numArray6 = weight;
                    int index17 = nr;
                    int index18 = index17;
                    int num7 = weight[index17] + this.game.Data.SFObj[sf].Qty * Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts);
                    numArray6[index18] = num7;
                    int[] data3 = simpleList1.Data3;
                    int[] numArray7 = data3;
                    int index19 = nr;
                    int index20 = index19;
                    int num8 = data3[index19] + 1;
                    numArray7[index20] = num8;
                  }
                  else
                    simpleList1.Add(index1, this.game.Data.SFObj[sf].Qty * Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts), moveType, people, 1, CheckExistence: false);
                }
                int historical1 = this.game.Data.UnitObj[index7].Historical;
                int predefnr1;
                if (historical1 > -1)
                {
                  if (this.game.Data.HistoricalUnitObj[historical1].ModelMaster > -1)
                  {
                    int historicalSubPart = this.game.Data.UnitObj[index7].HistoricalSubPart;
                    predefnr1 = historicalSubPart <= -1 ? -1 : this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[historical1].ModelMaster].SubParts[historicalSubPart];
                  }
                  else
                  {
                    int historicalSubPart = this.game.Data.UnitObj[index7].HistoricalSubPart;
                    predefnr1 = historicalSubPart <= -1 ? this.game.Data.HistoricalUnitObj[historical1].SubParts[0] : this.game.Data.HistoricalUnitObj[historical1].SubParts[historicalSubPart];
                  }
                }
                else
                  predefnr1 = -1;
                int index21 = this.game.HandyFunctionsObj.GetPreDef(predefnr1);
                if (index21 > -1)
                {
                  int sfCount2 = this.game.Data.UnitObj[index21].SFCount;
                  for (int index22 = 0; index22 <= sfCount2; ++index22)
                  {
                    int sf = this.game.Data.UnitObj[index21].SFList[index22];
                    int type = this.game.Data.SFObj[sf].Type;
                    index1 = this.game.Data.SFTypeObj[type].ReinforcementType;
                    int moveType = this.game.Data.SFObj[sf].MoveType;
                    int people = this.game.Data.SFObj[sf].People;
                    int nr = simpleList1.FindNr(index1, moveType, people);
                    int num9 = (int) Math.Round(100.0 * ((double) this.game.HandyFunctionsObj.GetStaffPoints(index21) / (double) this.game.HandyFunctionsObj.GetStaffNeeded(index7)));
                    int num10 = this.game.Data.SFObj[sf].Qty;
                    if (this.game.Data.UnitObj[index21].IsHQ && this.game.Data.SFTypeObj[type].StaffPts > 0 && this.game.HandyFunctionsObj.GetStaffPercent(index7) < 100)
                      num10 = (int) Math.Round((double) num10 * (100.0 / (double) num9));
                    if (nr > -1)
                    {
                      int[] weight = simpleList1.Weight;
                      int[] numArray8 = weight;
                      int index23 = nr;
                      int index24 = index23;
                      int num11 = weight[index23] - num10 * Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts);
                      numArray8[index24] = num11;
                      if (simpleList1.Weight[nr] < 1)
                        simpleList1.RemoveNr(nr);
                    }
                  }
                }
                SimpleList simpleList2 = new SimpleList();
                int unitCounter6 = this.game.Data.UnitCounter;
                int num12;
                for (int index25 = 0; index25 <= unitCounter6; ++index25)
                {
                  if (this.game.Data.UnitObj[index25].PreDef == -1 & this.game.Data.UnitObj[index25].Regime == this.game.Data.Turn & (!this.game.HandyFunctionsObj.CheckIsBattlegroup(index25) | this.game.Data.Product == 6) && this.game.Data.UnitObj[index25].HQ == index7 | (double) this.game.Data.RuleVar[887] == 1.0 & this.game.HandyFunctionsObj.IsUnitInHQChain(index25, index7))
                  {
                    int num13 = 0;
                    if (this.game.Data.UnitObj[index25].Historical > -1 & this.game.Data.UnitObj[index25].HistoricalSubPart > -1 | this.game.Data.UnitObj[index25].IsHQ && this.game.Data.UnitObj[index25].X > -1)
                    {
                      if ((double) this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[index25].X, this.game.Data.UnitObj[index25].Y] <= (double) this.game.Data.RuleVar[339])
                        num13 = 1;
                      if (this.game.Data.UnitObj[index25].Historical > -1)
                      {
                        if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index25].Historical].ModelMaster == -1 & !this.game.Data.UnitObj[index25].IsHQ)
                        {
                          num13 = 0;
                          if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index25].Historical].SubParts[this.game.Data.UnitObj[index25].HistoricalSubPart] > -1)
                            num13 = 1;
                          if (this.game.Data.Product == 6 & this.game.HandyFunctionsObj.CheckIsBattlegroup(index25))
                            num13 = 1;
                        }
                        if (this.game.HandyFunctionsObj.GetAggregatedReplacementRequest(index25) < 999 & num6 == 1)
                          num13 = 0;
                        if ((double) this.game.Data.RuleVar[455] > 0.0 && num13 == 1)
                        {
                          bool flag = true;
                          int num14 = 0;
                          while (flag)
                          {
                            ++num14;
                            flag = false;
                            CoordList coordList2 = new CoordList();
                            Coordinate coordinate;
                            coordinate.x = this.game.Data.UnitObj[index25].X;
                            coordinate.y = this.game.Data.UnitObj[index25].Y;
                            if (coordinate.x == 41 & coordinate.y == 27)
                              index1 = index1;
                            coordinate.onmap = true;
                            while (coordinate.onmap)
                            {
                              coordinate = this.game.EditObj.TempCameFrom[0].Value[coordinate.x, coordinate.y];
                              if (coordinate.onmap)
                                coordList2.AddCoord(coordinate.x, coordinate.y, 0);
                            }
                            if (coordList2.counter > -1)
                            {
                              flag = false;
                              for (int counter = coordList2.counter; counter >= 0; counter += -1)
                              {
                                if (this.game.EditObj.TempValue3[index12].Value[coordList2.coord[counter].x, coordList2.coord[counter].y] != this.game.Data.Turn)
                                {
                                  this.game.Data.MapObj[0].HexObj[coordList2.coord[counter].x, coordList2.coord[counter].y].FuzzyBlock = 1;
                                  this.game.HandyFunctionsObj.MakeFuzzyOwner(false, false, this.game.Data.Turn);
                                  coordList1 = this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 99, (int) Math.Round((double) this.game.Data.RuleVar[339]), this.game.Data.UnitObj[index7].X, this.game.Data.UnitObj[index7].Y, this.game.Data.UnitObj[index7].Map, allowshoredrop: true, SeaBlock: true, useTrafficRules: useTrafficRules);
                                  flag = true;
                                  break;
                                }
                              }
                            }
                            if (!flag && (double) this.game.EditObj.TempValue[this.game.Data.UnitObj[index25].Map].Value[this.game.Data.UnitObj[index25].X, this.game.Data.UnitObj[index25].Y] > (double) this.game.Data.RuleVar[339])
                              num13 = 0;
                            if (num14 > 999)
                            {
                              flag = false;
                              num13 = 0;
                            }
                          }
                        }
                        if (num13 == 1)
                        {
                          this.AddPLog("Under command: -" + this.game.Data.UnitObj[index25].Name);
                          int breakPercent = this.game.HandyFunctionsObj.GetBreakPercent(index25);
                          int powerPtsAbsolute = this.game.HandyFunctionsObj.GetPowerPtsAbsolute(index25);
                          num12 = (int) Math.Round((double) this.game.Data.RuleVar[307]);
                          int startPower = this.game.HandyFunctionsObj.GetStartPower(index25);
                          index1 = (int) Math.Round((double) startPower * ((double) breakPercent / 100.0));
                          int tweight = startPower != 0 ? Math.Min(100, (int) Math.Round((double) powerPtsAbsolute / (double) startPower * 100.0)) : 100;
                          simpleList2.Add(index25, tweight, CheckExistence: false);
                        }
                      }
                    }
                  }
                }
                int num15 = 1;
                int num16 = 0;
                int num17;
                while (num15 == 1)
                {
                  ++num16;
                  num15 = 0;
                  int num18 = 0;
                  simpleList2.Sort();
                  int counter1 = simpleList2.Counter;
                  for (int index26 = 0; index26 <= counter1; ++index26)
                  {
                    int index27 = simpleList2.Id[index26];
                    if (index27 == 106)
                      index27 = index27;
                    if (index27 == 993)
                      index27 = index27;
                    if (Information.IsNothing((object) simpleListArray1[index27]))
                      simpleListArray1[index27] = new SimpleList();
                    num17 = simpleList2.Weight[index26];
                    int num19 = (double) this.game.Data.RuleVar[887] != 1.0 ? Math.Min(100, this.game.Data.UnitObj[index27].SOReplacementPercent) : Math.Min(this.game.HandyFunctionsObj.GetAggregatedReplacementRequest(index27), 100);
                    if (Operators.CompareString(this.game.Data.UnitObj[index27].Name, "Finnish Army HQ", false) == 0)
                      index27 = index27;
                    if (Operators.CompareString(this.game.Data.UnitObj[index27].Name, "11th Army", false) == 0)
                      index27 = index27;
                    int historical2 = this.game.Data.UnitObj[index27].Historical;
                    if (historical2 > -1)
                    {
                      if (this.game.Data.HistoricalUnitObj[historical2].ModelMaster > -1)
                      {
                        int historicalSubPart = this.game.Data.UnitObj[index27].HistoricalSubPart;
                        index21 = historicalSubPart <= -1 ? -1 : this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[historical2].ModelMaster].SubParts[historicalSubPart];
                      }
                      else
                      {
                        int historicalSubPart = this.game.Data.UnitObj[index27].HistoricalSubPart;
                        index21 = historicalSubPart <= -1 ? this.game.Data.HistoricalUnitObj[historical2].SubParts[0] : this.game.Data.HistoricalUnitObj[historical2].SubParts[historicalSubPart];
                      }
                    }
                    else
                      index21 = -1;
                    SimpleList ideallist = new SimpleList();
                    SimpleList simpleList3 = new SimpleList();
                    SimpleList simpleList4 = new SimpleList();
                    if (index21 > -1)
                    {
                      index21 = this.game.HandyFunctionsObj.GetPreDef(index21);
                      if (secondaryPhase == 0 & Strings.InStr(this.game.Data.UnitObj[index21].Name, "SS") > 0 & num15 == 0)
                        index27 = index27;
                      int sfCount3 = this.game.Data.UnitObj[index21].SFCount;
                      for (int index28 = 0; index28 <= sfCount3; ++index28)
                      {
                        int sf = this.game.Data.UnitObj[index21].SFList[index28];
                        int type = this.game.Data.SFObj[sf].Type;
                        int reinforcementType = this.game.Data.SFTypeObj[type].ReinforcementType;
                        int moveType = this.game.Data.SFObj[sf].MoveType;
                        int people = this.game.Data.SFObj[sf].People;
                        int nr = ideallist.FindNr(reinforcementType, moveType, people);
                        int tdata5 = 0;
                        int num20 = (int) Math.Round(100.0 * ((double) this.game.HandyFunctionsObj.GetStaffPoints(index21) / (double) Math.Max(1, this.game.HandyFunctionsObj.GetStaffNeeded(index27))));
                        int num21 = this.game.Data.SFObj[sf].Qty;
                        if (this.game.Data.UnitObj[index21].IsHQ)
                        {
                          if (this.game.Data.SFTypeObj[type].StaffPts > 0)
                          {
                            tdata5 = 1;
                            if (this.game.HandyFunctionsObj.GetStaffPercent(index27) < 100)
                            {
                              num21 = (int) Math.Round((double) num21 * (100.0 / (double) num20));
                              if (num21 < this.game.Data.SFObj[sf].Qty)
                                num21 = this.game.Data.SFObj[sf].Qty;
                            }
                          }
                        }
                        else if (!this.game.Data.UnitObj[index21].IsHQ | this.game.Data.SFTypeObj[type].StaffPts <= 0)
                        {
                          int num22 = (double) this.game.Data.RuleVar[887] != 1.0 ? Math.Min(100, this.game.Data.UnitObj[index27].SOReplacementPercent) : Math.Min(100, this.game.HandyFunctionsObj.GetAggregatedReplacementRequest(index27));
                          num21 = (int) Math.Round((double) num21 * ((double) num22 / 100.0));
                        }
                        if (num21 > 0)
                        {
                          if (nr > -1)
                          {
                            int[] weight = ideallist.Weight;
                            int[] numArray9 = weight;
                            int index29 = nr;
                            int index30 = index29;
                            int num23 = weight[index29] + num21 * Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts);
                            numArray9[index30] = num23;
                            int[] data3 = ideallist.Data3;
                            int[] numArray10 = data3;
                            int index31 = nr;
                            int index32 = index31;
                            int num24 = data3[index31] + 1;
                            numArray10[index32] = num24;
                          }
                          else
                            ideallist.Add(reinforcementType, num21 * Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts), moveType, people, 1, tdata5: tdata5, CheckExistence: false);
                        }
                      }
                      simpleList4 = new SimpleList();
                      int counter2 = ideallist.Counter;
                      for (int index33 = 0; index33 <= counter2; ++index33)
                        simpleList4.Add(ideallist.Id[index33], ideallist.Weight[index33], ideallist.Data1[index33], ideallist.Data2[index33], tdata5: ideallist.Data5[index33], CheckExistence: false);
                      int sfCount4 = this.game.Data.UnitObj[index27].SFCount;
                      for (int index34 = 0; index34 <= sfCount4; ++index34)
                      {
                        int sf = this.game.Data.UnitObj[index27].SFList[index34];
                        int type = this.game.Data.SFObj[sf].Type;
                        int reinforcementType = this.game.Data.SFTypeObj[type].ReinforcementType;
                        int moveType = this.game.Data.SFObj[sf].MoveType;
                        int people = this.game.Data.SFObj[sf].People;
                        int tdata5 = 0;
                        if (this.game.Data.SFTypeObj[type].StaffPts > 0)
                          tdata5 = 1;
                        if (ideallist.FindNr(reinforcementType, moveType, people) > -1)
                        {
                          int nr = simpleList3.FindNr(reinforcementType, moveType, people);
                          int tweight = this.game.Data.SFObj[sf].Qty * Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts);
                          if (nr > -1)
                          {
                            int[] weight = simpleList3.Weight;
                            int[] numArray11 = weight;
                            int index35 = nr;
                            int index36 = index35;
                            int num25 = weight[index35] + tweight;
                            numArray11[index36] = num25;
                            int[] data3 = simpleList3.Data3;
                            int[] numArray12 = data3;
                            int index37 = nr;
                            int index38 = index37;
                            int num26 = data3[index37] + 1;
                            numArray12[index38] = num26;
                          }
                          else
                          {
                            simpleList3.Add(reinforcementType, tweight, moveType, people, 1, tdata5: tdata5, CheckExistence: false);
                            num12 = simpleList3.Counter;
                          }
                        }
                      }
                      int sfCount5 = this.game.Data.UnitObj[index27].SFCount;
                      for (int index39 = 0; index39 <= sfCount5; ++index39)
                      {
                        int sf = this.game.Data.UnitObj[index27].SFList[index39];
                        int type = this.game.Data.SFObj[sf].Type;
                        int reinforcementType = this.game.Data.SFTypeObj[type].ReinforcementType;
                        int moveType = this.game.Data.SFObj[sf].MoveType;
                        int people = this.game.Data.SFObj[sf].People;
                        int tdata5 = 0;
                        if (this.game.Data.SFTypeObj[type].StaffPts > 0)
                          tdata5 = 1;
                        if (this.game.Data.SFTypeObj[type].ReinforcementType2 > -1)
                        {
                          int nr1 = ideallist.FindNr(reinforcementType, moveType, people);
                          int num27 = nr1 <= -1 ? 0 : ideallist.Weight[nr1];
                          int nr2 = simpleList3.FindNr(reinforcementType, moveType, people);
                          if (nr2 > -1)
                          {
                            int num28 = simpleList3.Weight[nr2];
                            if (num28 > num27)
                            {
                              int tweight = Math.Min(this.game.Data.SFObj[sf].Qty * Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts), num28 - num27);
                              int index40 = nr2;
                              int reinforcementType2 = this.game.Data.SFTypeObj[type].ReinforcementType2;
                              int num29 = tweight;
                              if (this.game.Data.SFTypeObj[type].ReinforcementType > -1 & this.game.Data.SFTypeObj[type].ReinforcementType2 > -1 && this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType2] > 0 & this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType] > 0 && this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType] != this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType2])
                                tweight = (int) Math.Round(Conversion.Int((double) tweight * ((double) this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType] / (double) this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType2])));
                              int nr3 = simpleList3.FindNr(reinforcementType2, moveType, people);
                              if (nr3 > -1)
                              {
                                int[] weight1 = simpleList3.Weight;
                                int[] numArray13 = weight1;
                                int index41 = nr3;
                                int index42 = index41;
                                int num30 = weight1[index41] + tweight;
                                numArray13[index42] = num30;
                                int[] data3 = simpleList3.Data3;
                                int[] numArray14 = data3;
                                int index43 = nr3;
                                int index44 = index43;
                                int num31 = data3[index43] + 1;
                                numArray14[index44] = num31;
                                int[] weight2 = simpleList3.Weight;
                                int[] numArray15 = weight2;
                                int index45 = index40;
                                int index46 = index45;
                                int num32 = weight2[index45] - num29;
                                numArray15[index46] = num32;
                                if (simpleList3.Weight[index40] <= 0)
                                  simpleList3.RemoveNr(nr3);
                              }
                              else
                              {
                                simpleList3.Add(reinforcementType2, tweight, moveType, people, 1, tdata5: tdata5, CheckExistence: false);
                                int counter3 = simpleList3.Counter;
                                int[] weight = simpleList3.Weight;
                                int[] numArray16 = weight;
                                int index47 = index40;
                                int index48 = index47;
                                int num33 = weight[index47] - num29;
                                numArray16[index48] = num33;
                                if (simpleList3.Weight[index40] <= 0)
                                  simpleList3.RemoveNr(counter3);
                              }
                            }
                          }
                        }
                      }
                      for (int counter4 = ideallist.Counter; counter4 >= 0; counter4 += -1)
                      {
                        if (simpleList3.FindNr(ideallist.Id[counter4], ideallist.Data1[counter4], ideallist.Data2[counter4]) == -1)
                          simpleList3.Add(ideallist.Id[counter4], 0, ideallist.Data1[counter4], ideallist.Data2[counter4], tdata5: ideallist.Data5[counter4], CheckExistence: false);
                      }
                      for (int counter5 = simpleList3.Counter; counter5 >= 0; counter5 += -1)
                      {
                        int nr = ideallist.FindNr(simpleList3.Id[counter5], simpleList3.Data1[counter5], simpleList3.Data2[counter5]);
                        if (nr > -1)
                        {
                          int num34 = ideallist.Weight[nr];
                          int num35 = simpleList3.Weight[counter5];
                          if (num35 >= (int) Math.Round(Conversion.Int((double) num34 * ((double) num19 / 100.0))))
                            simpleList3.RemoveNr(counter5);
                          else
                            simpleList3.Weight[counter5] = (int) Math.Round(Conversion.Int((double) num34 * ((double) num19 / 100.0))) - num35;
                        }
                        else
                          simpleList3.RemoveNr(counter5);
                      }
                    }
                    SimpleList simpleList5 = new SimpleList();
                    int counter6 = simpleList3.Counter;
                    for (int index49 = 0; index49 <= counter6; ++index49)
                      simpleList5.Add(simpleList3.Id[index49], simpleList3.Weight[index49], simpleList3.Data1[index49], simpleList3.Data2[index49], CheckExistence: false);
                    if ((double) this.game.Data.RuleVar[883] > 0.0)
                    {
                      int counter7 = simpleList4.Counter;
                      for (int index50 = 0; index50 <= counter7; ++index50)
                      {
                        int num36 = simpleList4.Weight[index50];
                        if (index27 == 58 & simpleList4.Id[index50] == 0)
                          index27 = index27;
                        int num37 = Math.Max(1, (int) Math.Round((double) ((float) num36 * (this.game.Data.RuleVar[883] / 100f))));
                        int logCounter = this.game.Data.UnitObj[index27].LogCounter;
                        for (int index51 = 0; index51 <= logCounter; ++index51)
                        {
                          if (this.game.Data.UnitObj[index27].LogType[index51] == 2 && this.game.Data.UnitObj[index27].LogData1[index51] == simpleList4.Id[index50] && this.game.Data.UnitObj[index27].LogData2[index51] == simpleList4.Data2[index50])
                          {
                            num37 -= this.game.Data.UnitObj[index27].LogData3[index51];
                            if (0 > num37)
                              num37 = 0;
                          }
                        }
                        if (num37 == 3)
                          num37 = num37;
                        int counter8 = simpleList3.Counter;
                        for (int index52 = 0; index52 <= counter8; ++index52)
                        {
                          if (simpleList3.Id[index52] == simpleList4.Id[index50] & simpleList3.Data1[index52] == simpleList4.Data1[index50] & simpleList3.Data2[index52] == simpleList4.Data2[index50] && num37 < simpleList3.Weight[index52])
                            simpleList3.Weight[index52] = num37;
                        }
                      }
                    }
                    if (this.game.Data.UnitObj[index27].IsHQ & (double) this.game.Data.RuleVar[887] < 1.0 && !Information.IsNothing((object) simpleListArray3[index27]))
                    {
                      int counter9 = simpleListArray3[index27].Counter;
                      for (int index53 = 0; index53 <= counter9; ++index53)
                      {
                        int nr4 = simpleList3.FindNr(simpleListArray3[index27].Id[index53], simpleListArray3[index27].Data1[index53], simpleListArray3[index27].Data2[index53]);
                        if (nr4 == -1)
                        {
                          simpleList3.Add(simpleListArray3[index27].Id[index53], (int) Math.Round(Conversion.Int((double) simpleListArray3[index27].Weight[index53] * ((double) num19 / 100.0))), simpleListArray3[index27].Data1[index53], simpleListArray3[index27].Data2[index53], CheckExistence: false);
                        }
                        else
                        {
                          int[] weight = simpleList3.Weight;
                          int[] numArray17 = weight;
                          int index54 = nr4;
                          int index55 = index54;
                          int num38 = (int) Math.Round((double) weight[index54] + Conversion.Int((double) simpleListArray3[index27].Weight[index53] * ((double) num19 / 100.0)));
                          numArray17[index55] = num38;
                        }
                        int nr5 = ideallist.FindNr(simpleListArray3[index27].Id[index53], simpleListArray3[index27].Data1[index53], simpleListArray3[index27].Data2[index53]);
                        if (nr5 == -1)
                        {
                          ideallist.Add(simpleListArray3[index27].Id[index53], (int) Math.Round(Conversion.Int((double) simpleListArray3[index27].Weight[index53] * ((double) num19 / 100.0))), simpleListArray3[index27].Data1[index53], simpleListArray3[index27].Data2[index53], CheckExistence: false);
                        }
                        else
                        {
                          int[] weight = ideallist.Weight;
                          int[] numArray18 = weight;
                          int index56 = nr5;
                          int index57 = index56;
                          int num39 = (int) Math.Round((double) weight[index56] + Conversion.Int((double) simpleListArray3[index27].Weight[index53] * ((double) num19 / 100.0)));
                          numArray18[index57] = num39;
                        }
                        int nr6 = simpleList5.FindNr(simpleListArray3[index27].Id[index53], simpleListArray3[index27].Data1[index53], simpleListArray3[index27].Data2[index53]);
                        if (nr6 == -1)
                        {
                          simpleList5.Add(simpleListArray3[index27].Id[index53], (int) Math.Round(Conversion.Int((double) simpleListArray3[index27].Weight[index53] * ((double) num19 / 100.0))), simpleListArray3[index27].Data1[index53], simpleListArray3[index27].Data2[index53], CheckExistence: false);
                        }
                        else
                        {
                          int[] weight = simpleList5.Weight;
                          int[] numArray19 = weight;
                          int index58 = nr6;
                          int index59 = index58;
                          int num40 = (int) Math.Round((double) weight[index58] + Conversion.Int((double) simpleListArray3[index27].Weight[index53] * ((double) num19 / 100.0)));
                          numArray19[index59] = num40;
                        }
                      }
                    }
                    if (index7 == 54 & index27 == 993)
                      index7 = index7;
                    if ((double) this.game.Data.RuleVar[887] < 1.0)
                    {
                      for (int counter10 = simpleListArray1[index27].Counter; counter10 >= 0; counter10 += -1)
                      {
                        int nr7 = simpleList3.FindNr(simpleListArray1[index27].Id[counter10], simpleListArray1[index27].Data1[counter10], simpleListArray1[index27].Data2[counter10]);
                        if (nr7 > -1)
                        {
                          int[] weight = simpleList3.Weight;
                          int[] numArray20 = weight;
                          int index60 = nr7;
                          int index61 = index60;
                          int num41 = weight[index60] - simpleListArray1[index27].Weight[counter10];
                          numArray20[index61] = num41;
                          if (1 > simpleList3.Weight[nr7])
                            simpleList3.RemoveNr(nr7);
                        }
                        int nr8 = simpleList5.FindNr(simpleListArray1[index27].Id[counter10], simpleListArray1[index27].Data1[counter10], simpleListArray1[index27].Data2[counter10]);
                        if (nr8 > -1)
                        {
                          int[] weight = simpleList5.Weight;
                          int[] numArray21 = weight;
                          int index62 = nr8;
                          int index63 = index62;
                          int num42 = weight[index62] - simpleListArray1[index27].Weight[counter10];
                          numArray21[index63] = num42;
                          if (1 > simpleList5.Weight[nr8])
                            simpleList5.RemoveNr(nr8);
                        }
                      }
                    }
                    simpleListArray2[index27] = new SimpleList();
                    int counter11 = simpleList5.Counter;
                    for (int index64 = 0; index64 <= counter11; ++index64)
                      simpleListArray2[index27].Add(simpleList5.Id[index64], simpleList5.Weight[index64], simpleList5.Data1[index64], simpleList5.Data2[index64], CheckExistence: false);
                    if (index27 == 256)
                      index27 = index27;
                    if (num16 == 1 & secondaryPhase == 0 & (num6 == 1 | num6 == 2 & this.game.HandyFunctionsObj.GetAggregatedReplacementRequest(index27) < 999))
                    {
                      int counter12 = simpleList3.Counter;
                      for (int index65 = 0; index65 <= counter12; ++index65)
                      {
                        if (index27 == 224)
                          index65 = index65;
                        this.game.Data.UnitObj[index27].AddLog(1, simpleList3.Id[index65], simpleList3.Data2[index65], simpleList3.Weight[index65]);
                        this.game.Data.UnitObj[index7].AddLog(5, simpleList3.Id[index65], simpleList3.Data2[index65], simpleList3.Weight[index65]);
                      }
                      int counter13 = simpleList5.Counter;
                      for (int index66 = 0; index66 <= counter13; ++index66)
                        this.game.Data.UnitObj[index27].AddLog(9, simpleList5.Id[index66], simpleList5.Data2[index66], simpleList5.Weight[index66]);
                    }
                    for (int counter14 = simpleList3.Counter; counter14 >= 0; counter14 += -1)
                    {
                      int tid = simpleList3.Id[counter14];
                      int tdata1 = simpleList3.Data1[counter14];
                      int tdata2 = simpleList3.Data2[counter14];
                      if (simpleList1.FindNr(tid, tdata1, tdata2) == -1)
                        simpleList3.RemoveNr(counter14);
                    }
                    for (index1 = simpleList3.Counter; index1 >= 0; index1 += -1)
                    {
                      if (simpleList3.Weight[index1] < 1)
                        simpleList3.RemoveNr(index1);
                    }
                    simpleList3.Sort();
                    if (num15 == 0)
                    {
                      for (int counter15 = simpleList3.Counter; counter15 >= 0; counter15 += -1)
                      {
                        if (index27 == 859)
                          index27 = index27;
                        index1 = this.AutoReinforce_HQwillGive(index7, index27, ideallist, simpleList3.Id[counter15], simpleList3.Data1[counter15], simpleList3.Data2[counter15], secondaryPhase);
                        if (index27 == 993)
                          index27 = index27;
                        if (index1 > -1)
                        {
                          int theater = -2;
                          if ((double) this.game.Data.RuleVar[340] == -1.0)
                            theater = -1;
                          if (index1 > -1 && (double) this.game.Data.RuleVar[340] > -1.0)
                          {
                            if (((double) this.game.Data.RuleVar[340] == 2.0 | (double) this.game.Data.RuleVar[340] == 3.0) & this.game.Data.UnitObj[index7].AirCap >= mapMatrix2Array2[this.game.Data.UnitObj[index27].Map].Value[this.game.Data.UnitObj[index27].X, this.game.Data.UnitObj[index27].Y] * this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].Weight)
                            {
                              theater = 2;
                              this.game.EditObj.TempValue = mapMatrix2Array2;
                            }
                            else if (((double) this.game.Data.RuleVar[340] == 1.0 | (double) this.game.Data.RuleVar[340] == 3.0) & this.game.Data.UnitObj[index7].NavyCap >= mapMatrix2Array1[this.game.Data.UnitObj[index27].Map].Value[this.game.Data.UnitObj[index27].X, this.game.Data.UnitObj[index27].Y] * this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].Weight)
                            {
                              theater = 1;
                              this.game.EditObj.TempValue = mapMatrix2Array1;
                            }
                            else if (((double) this.game.Data.RuleVar[340] == 0.0 | (double) this.game.Data.RuleVar[340] == 3.0) & this.game.Data.UnitObj[index7].LandCap >= mapMatrix2Array3[this.game.Data.UnitObj[index27].Map].Value[this.game.Data.UnitObj[index27].X, this.game.Data.UnitObj[index27].Y] * this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].Weight)
                            {
                              theater = 0;
                              this.game.EditObj.TempValue = mapMatrix2Array3;
                            }
                            this.game.EditObj.TempValue2 = (MapMatrix2[]) this.game.EditObj.TempValue.Clone();
                            this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].MoveType, this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].Theater, this.game.Data.SFObj[index1].Ap, this.game.Data.UnitObj[index7].X, this.game.Data.UnitObj[index7].Y, this.game.Data.UnitObj[index7].Map);
                            if (this.game.EditObj.TempValue[this.game.Data.UnitObj[index27].Map].Value[this.game.Data.UnitObj[index27].X, this.game.Data.UnitObj[index27].Y] <= this.game.Data.SFObj[index1].Ap)
                              theater = -1;
                            this.game.EditObj.TempValue = this.game.EditObj.TempValue2;
                          }
                          int num43;
                          if (theater == -2 | index1 == -2)
                          {
                            theater = -2;
                            int nr9 = simpleList1.FindNr(simpleList3.Id[counter15], simpleList3.Data1[counter15], simpleList3.Data2[counter15]);
                            if (nr9 > -1)
                            {
                              num43 = simpleList3.Weight[counter15];
                              if (simpleList1.Weight[nr9] < num43)
                                num43 = simpleList1.Weight[nr9];
                              int[] weight3 = simpleList1.Weight;
                              int[] numArray22 = weight3;
                              int index67 = nr9;
                              int index68 = index67;
                              int num44 = weight3[index67] - simpleList3.Weight[counter15];
                              numArray22[index68] = num44;
                              if (1 > simpleList1.Weight[nr9])
                                simpleList1.RemoveNr(nr9);
                              int nr10 = simpleListArray2[index27].FindNr(simpleList3.Id[counter15], simpleList3.Data1[counter15], simpleList3.Data2[counter15]);
                              if (nr10 > -1)
                              {
                                int[] weight4 = simpleListArray2[index27].Weight;
                                int[] numArray23 = weight4;
                                int index69 = nr10;
                                int index70 = index69;
                                int num45 = weight4[index69] - num43;
                                numArray23[index70] = num45;
                                if (1 > simpleListArray2[index27].Weight[nr10])
                                  simpleListArray2[index27].RemoveNr(nr10);
                                this.AddPLog(this.game.Data.UnitObj[index27].Name + " 's HQ has " + Conversion.Str((object) num43) + " power pts of " + this.game.Data.ReinfName[simpleList3.Id[counter15]] + ", but not the CAP to send! / or target slots full");
                                simpleListArray1[index27].Add(simpleList3.Id[counter15], num43, simpleList3.Data1[counter15], simpleList3.Data2[counter15], CheckExistence: false);
                              }
                              num15 = 1;
                            }
                          }
                          if (theater > -2)
                          {
                            if (index27 == 54)
                              index27 = index27;
                            int nr11 = secondaryPhase != 0 ? simpleListArray2[index27].FindNr(this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].ReinforcementType2, this.game.Data.SFObj[index1].MoveType, this.game.Data.SFObj[index1].People) : simpleListArray2[index27].FindNr(this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].ReinforcementType, this.game.Data.SFObj[index1].MoveType, this.game.Data.SFObj[index1].People);
                            if (nr11 > -1)
                            {
                              int[] weight = simpleListArray2[index27].Weight;
                              int[] numArray24 = weight;
                              int index71 = nr11;
                              int index72 = index71;
                              int num46 = weight[index71] - Math.Min(val1_1, this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].PowerPts);
                              numArray24[index72] = num46;
                              if (simpleListArray2[index27].Weight[nr11] <= 0)
                                simpleListArray2[index27].RemoveNr(nr11);
                            }
                            if (this.game.Data.UnitObj[index27].IsHQ && !Information.IsNothing((object) simpleListArray3[index27]))
                            {
                              int nr12 = secondaryPhase != 0 ? simpleListArray3[index27].FindNr(this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].ReinforcementType2, this.game.Data.SFObj[index1].MoveType, this.game.Data.SFObj[index1].People) : simpleListArray3[index27].FindNr(this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].ReinforcementType, this.game.Data.SFObj[index1].MoveType, this.game.Data.SFObj[index1].People);
                              if (nr12 > -1)
                              {
                                int[] weight = simpleListArray3[index27].Weight;
                                int[] numArray25 = weight;
                                int index73 = nr12;
                                int index74 = index73;
                                int num47 = weight[index73] - Math.Min(val1_1, this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].PowerPts);
                                numArray25[index74] = num47;
                                if (simpleListArray3[index27].Weight[nr12] <= 0)
                                  simpleListArray3[index27].RemoveNr(nr12);
                              }
                            }
                            this.AddPLog("transfer 1 " + this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].Name + " to => " + this.game.Data.UnitObj[index27].Name + ", landcap=" + Conversion.Str((object) this.game.Data.UnitObj[index7].LandCap) + ", railcap=" + Conversion.Str((object) this.game.Data.UnitObj[index7].AirCap) + ", seacap=" + Conversion.Str((object) this.game.Data.UnitObj[index7].NavyCap));
                            if (!Information.IsNothing((object) simpleListArray3[index7]))
                            {
                              int counter16 = simpleListArray3[index7].Counter;
                              for (int index75 = 0; index75 <= counter16; ++index75)
                                this.AddPLog("HQRemListHQ(" + this.game.Data.UnitObj[index7].Name + ") " + this.game.Data.ReinfName[simpleListArray3[index7].Id[index75]] + " (mvtyp=" + simpleListArray3[index7].Data1[index75].ToString() + ",ppl=" + simpleListArray3[index7].Data2[index75].ToString() + ") = " + simpleListArray3[index7].Weight[index75].ToString());
                            }
                            int type = this.game.Data.SFObj[index1].Type;
                            if (theater == -1)
                              this.DoTransfer(index7, index27, 0, index1, 1, true, false, MoveMatrixDone: true);
                            else
                              this.DoTransfer(index7, index27, theater, index1, 1, AddtoHistory: false, MoveMatrixDone: true);
                            if (index27 == 58 & type == 0)
                              index27 = index27;
                            int nr13 = simpleList1.FindNr(simpleList3.Id[counter15], simpleList3.Data1[counter15], simpleList3.Data2[counter15]);
                            if (nr13 > -1)
                            {
                              if (secondaryPhase == 0)
                              {
                                this.game.Data.UnitObj[index7].AddLog(6, this.game.Data.SFTypeObj[type].ReinforcementType, simpleList3.Data2[counter15], Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts));
                                if (this.game.EditObj.TransferLostQty < 1)
                                  this.game.Data.UnitObj[index27].AddLog(2, this.game.Data.SFTypeObj[type].ReinforcementType, simpleList3.Data2[counter15], Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts));
                                else
                                  this.game.Data.UnitObj[index7].AddLog(7, this.game.Data.SFTypeObj[type].ReinforcementType, simpleList3.Data2[counter15], Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts));
                              }
                              else if (this.game.Data.Product == 6)
                              {
                                this.game.Data.UnitObj[index7].AddLog(6, this.game.Data.SFTypeObj[type].ReinforcementType, simpleList3.Data2[counter15], Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts));
                                if (this.game.EditObj.TransferLostQty < 1)
                                  this.game.Data.UnitObj[index27].AddLog(2, this.game.Data.SFTypeObj[type].ReinforcementType, simpleList3.Data2[counter15], Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts));
                                else
                                  this.game.Data.UnitObj[index7].AddLog(7, this.game.Data.SFTypeObj[type].ReinforcementType, simpleList3.Data2[counter15], Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts));
                              }
                              else
                              {
                                this.game.Data.UnitObj[index7].AddLog(6, this.game.Data.SFTypeObj[type].ReinforcementType2, simpleList3.Data2[counter15], Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts));
                                if (this.game.EditObj.TransferLostQty < 1)
                                  this.game.Data.UnitObj[index27].AddLog(2, this.game.Data.SFTypeObj[type].ReinforcementType2, simpleList3.Data2[counter15], Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts));
                                else
                                  this.game.Data.UnitObj[index7].AddLog(7, this.game.Data.SFTypeObj[type].ReinforcementType2, simpleList3.Data2[counter15], Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts));
                              }
                              int[] weight = simpleList1.Weight;
                              int[] numArray26 = weight;
                              int index76 = nr13;
                              int index77 = index76;
                              int num48 = weight[index76] - Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts);
                              numArray26[index77] = num48;
                              if (simpleList1.Weight[nr13] < 1)
                                simpleList1.RemoveNr(nr13);
                            }
                            num15 = 1;
                            int breakPercent = this.game.HandyFunctionsObj.GetBreakPercent(index27);
                            int powerPtsAbsolute = this.game.HandyFunctionsObj.GetPowerPtsAbsolute(index27);
                            int num49 = (int) Math.Round((double) this.game.Data.RuleVar[307]);
                            int startPower = this.game.HandyFunctionsObj.GetStartPower(index27);
                            index1 = (int) Math.Round((double) startPower * ((double) breakPercent / 100.0));
                            int num50 = startPower != 0 ? Math.Min(100, (int) Math.Round((double) powerPtsAbsolute / (double) startPower * 100.0)) : 100;
                            simpleList2.Weight[index26] = num50;
                            if (useTrafficRules)
                            {
                              Coordinate coordinate1;
                              coordinate1.x = this.game.Data.UnitObj[index27].X;
                              coordinate1.y = this.game.Data.UnitObj[index27].Y;
                              bool flag = false;
                              int index78 = 0;
                              while (this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y].onmap)
                              {
                                int num51 = index78 + 1;
                                Coordinate coordinate2 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                                int index79 = this.game.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0) - 1;
                                int index80 = index79 + 3;
                                if (index80 > 5)
                                  index80 -= 6;
                                int liSpoint1 = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[index79];
                                int liSpoint2 = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints[index80];
                                int[] liSpoints1 = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints;
                                int[] numArray27 = liSpoints1;
                                int index81 = index79;
                                int index82 = index81;
                                int num52 = liSpoints1[index81] + (int) Math.Round(Math.Ceiling((double) (this.game.Data.SFTypeObj[type].Weight * 1) / (double) this.game.Data.RuleVar[33]));
                                numArray27[index82] = num52;
                                int[] liSpoints2 = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints;
                                int[] numArray28 = liSpoints2;
                                int index83 = index80;
                                int index84 = index83;
                                int num53 = liSpoints2[index83] + (int) Math.Round(Math.Ceiling((double) (this.game.Data.SFTypeObj[type].Weight * 1) / (double) this.game.Data.RuleVar[33]));
                                numArray28[index84] = num53;
                                int index85 = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[index79];
                                if (index85 > -1 && this.game.Data.RoadTypeObj[index85].trafficPoints > 0)
                                {
                                  int num54 = (int) Math.Round(Math.Floor((double) (liSpoint1 * 1) / (double) this.game.Data.RoadTypeObj[index85].trafficPoints));
                                  if ((int) Math.Round(Math.Floor((double) (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[index79] * 1) / (double) this.game.Data.RoadTypeObj[index85].trafficPoints)) > num54)
                                    flag = true;
                                }
                                index78 = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].RoadType[index80];
                                if (index78 > -1 && this.game.Data.RoadTypeObj[index78].trafficPoints > 0)
                                {
                                  int num55 = (int) Math.Round(Math.Floor((double) (num49 * 1) / (double) this.game.Data.RoadTypeObj[index78].trafficPoints));
                                  if ((int) Math.Round(Math.Floor((double) (this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints[index80] * 1) / (double) this.game.Data.RoadTypeObj[index78].trafficPoints)) > num55)
                                    flag = true;
                                }
                                coordinate1 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                                if (index78 > 999)
                                  break;
                              }
                              if (flag)
                              {
                                coordList1 = this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, num43, 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[index7].X, this.game.Data.UnitObj[index7].Y, this.game.Data.UnitObj[index7].Map, allowshoredrop: true, SeaBlock: true, useTrafficRules: useTrafficRules);
                                break;
                              }
                              break;
                            }
                            break;
                          }
                        }
                        else
                          index1 = index1;
                      }
                    }
                    if (num15 == 1 & num18 == 1)
                      break;
                  }
                  if (num15 == 0 & secondaryPhase == 1 & num6 == 2)
                  {
                    if (index7 == 99)
                      index21 = index21;
                    simpleListArray3[index7] = new SimpleList();
                    int counter17 = simpleList2.Counter;
                    for (int index86 = 0; index86 <= counter17; ++index86)
                    {
                      int index87 = simpleList2.Id[index86];
                      if (index7 == 54 & index87 == 993)
                        index7 = index7;
                      if (index87 == 993)
                        index87 = index87;
                      if (this.game.Data.UnitObj[index87].HQ == index7)
                      {
                        for (index1 = simpleListArray2[index87].Counter; index1 >= 0; index1 += -1)
                        {
                          int num56 = (double) this.game.Data.RuleVar[887] != 1.0 ? Math.Min(100, this.game.Data.UnitObj[index7].SOReplacementPercent) : Math.Min(100, this.game.HandyFunctionsObj.GetAggregatedReplacementRequest(index7));
                          simpleListArray2[index87].Weight[index1] = (int) Math.Round(Conversion.Int((double) simpleListArray2[index87].Weight[index1] * ((double) num56 / 100.0)));
                          if (simpleListArray2[index87].Weight[index1] > 0 & simpleListArray2[index87].Id[index1] > -1)
                          {
                            this.AddPLog(this.game.Data.UnitObj[index87].Name + " could not get " + Conversion.Str((object) simpleListArray2[index87].Weight[index1]) + " power pts of " + this.game.Data.ReinfName[simpleListArray2[index87].Id[index1]] + " (" + Conversion.Str((object) simpleListArray2[index87].Data1[index1]) + "," + Conversion.Str((object) simpleListArray2[index87].Data2[index1]) + ") passed on to " + this.game.Data.UnitObj[index7].Name);
                            int nr = simpleListArray3[index7].FindNr(simpleListArray2[index87].Id[index1], simpleListArray2[index87].Data1[index1], simpleListArray2[index87].Data2[index1]);
                            if (simpleListArray2[index87].Id[index1] == 0)
                              index1 = index1;
                            if (nr == -1)
                            {
                              simpleListArray3[index7].Add(simpleListArray2[index87].Id[index1], simpleListArray2[index87].Weight[index1], simpleListArray2[index87].Data1[index1], simpleListArray2[index87].Data2[index1], CheckExistence: false);
                            }
                            else
                            {
                              int[] weight = simpleListArray3[index7].Weight;
                              int[] numArray29 = weight;
                              int index88 = nr;
                              int index89 = index88;
                              int num57 = weight[index88] + simpleListArray2[index87].Weight[index1];
                              numArray29[index89] = num57;
                            }
                            if (!Information.IsNothing((object) simpleListArray3[index7]))
                            {
                              int counter18 = simpleListArray3[index7].Counter;
                              for (int index90 = 0; index90 <= counter18; ++index90)
                                this.AddPLog("HQRemListHQ(" + this.game.Data.UnitObj[index7].Name + ") " + this.game.Data.ReinfName[simpleListArray3[index7].Id[index90]] + " (mvtyp=" + simpleListArray3[index7].Data1[index90].ToString() + ",ppl=" + simpleListArray3[index7].Data2[index90].ToString() + ") = " + simpleListArray3[index7].Weight[index90].ToString());
                            }
                          }
                          else
                            simpleListArray2[index87].RemoveNr(index1);
                        }
                      }
                    }
                    simpleListArray4[index7] = new SimpleList();
                    if (!Information.IsNothing((object) simpleListArray3[index7]))
                    {
                      if (index7 == 54)
                        index7 = index7;
                      int counter19 = simpleListArray3[index7].Counter;
                      for (index1 = 0; index1 <= counter19; ++index1)
                        simpleListArray4[index7].Add(simpleListArray3[index7].Id[index1], simpleListArray3[index7].Weight[index1], simpleListArray3[index7].Data1[index1], simpleListArray3[index7].Data2[index1], simpleListArray3[index7].Data3[index1], CheckExistence: false);
                    }
                    int counter20 = simpleList1.Counter;
                    for (int index91 = 0; index91 <= counter20; ++index91)
                    {
                      if (simpleList1.Id[index91] > -1)
                      {
                        index1 = simpleListArray3[index7].FindNr(simpleList1.Id[index91], simpleList1.Data1[index91], simpleList1.Data2[index91]);
                        if (index1 != -1)
                        {
                          int[] weight = simpleListArray3[index7].Weight;
                          int[] numArray30 = weight;
                          int index92 = index1;
                          int index93 = index92;
                          int num58 = weight[index92] - simpleList1.Weight[index91];
                          numArray30[index93] = num58;
                          if (simpleListArray3[index7].Weight[index1] < 1)
                            simpleListArray3[index7].RemoveNr(index1);
                        }
                      }
                    }
                    if (index7 == 54)
                      index7 = index7;
                  }
                }
                if (secondaryPhase == 1 & num6 == 2)
                {
                  this.AddPLog("RETURN CHECKING FOR " + this.game.Data.UnitObj[index7].Name);
                  int num59 = 1;
                  int num60 = 0;
                  while (num59 == 1)
                  {
                    num59 = 0;
                    ++num60;
                    int counter21 = simpleList2.Counter;
                    for (int index94 = 0; index94 <= counter21; ++index94)
                    {
                      int unr = simpleList2.Id[index94];
                      int replacementPercent = this.game.Data.UnitObj[unr].SOReplacementPercent;
                      num17 = simpleList2.Weight[index94];
                      int num61 = simpleList2.Data1[index94];
                      if (num60 == 1)
                        simpleListArray5[unr] = new SimpleList();
                      bool flag1 = false;
                      if (this.game.HandyFunctionsObj.CheckIsBattlegroup(unr) & this.game.Data.Product == 6)
                        flag1 = true;
                      int historical3 = this.game.Data.UnitObj[unr].Historical;
                      int predefnr2;
                      if (historical3 > -1)
                      {
                        if (this.game.Data.HistoricalUnitObj[historical3].ModelMaster > -1)
                        {
                          int historicalSubPart = this.game.Data.UnitObj[unr].HistoricalSubPart;
                          predefnr2 = historicalSubPart <= -1 ? -1 : this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[historical3].ModelMaster].SubParts[historicalSubPart];
                        }
                        else
                        {
                          int historicalSubPart = this.game.Data.UnitObj[unr].HistoricalSubPart;
                          predefnr2 = this.game.Data.HistoricalUnitObj[historical3].SubParts[historicalSubPart];
                        }
                      }
                      else
                        predefnr2 = -1;
                      SimpleList simpleList6 = new SimpleList();
                      SimpleList simpleList7 = new SimpleList();
                      SimpleList simpleList8 = new SimpleList();
                      if (Operators.CompareString(this.game.Data.UnitObj[unr].Name, "Finnish Army HQ", false) == 0)
                        unr = unr;
                      if (Operators.CompareString(this.game.Data.UnitObj[unr].Name, "KG Hoffman", false) == 0)
                        unr = unr;
                      bool flag2 = true;
                      if (predefnr2 > -1)
                      {
                        int preDef = this.game.HandyFunctionsObj.GetPreDef(predefnr2);
                        int sfCount6 = this.game.Data.UnitObj[preDef].SFCount;
                        for (int index95 = 0; index95 <= sfCount6; ++index95)
                        {
                          int sf = this.game.Data.UnitObj[preDef].SFList[index95];
                          int type = this.game.Data.SFObj[sf].Type;
                          index1 = this.game.Data.SFTypeObj[type].ReinforcementType;
                          int moveType = this.game.Data.SFObj[sf].MoveType;
                          int people = this.game.Data.SFObj[sf].People;
                          int nr14 = simpleList6.FindNr(index1, moveType, people);
                          int nr15 = simpleList8.FindNr(index1, moveType, people);
                          int num62 = this.game.Data.SFObj[sf].Qty;
                          int num63 = this.game.Data.SFObj[sf].Qty;
                          if (this.game.Data.UnitObj[unr].IsHQ)
                          {
                            if (this.game.Data.SFTypeObj[type].StaffPts > 0)
                            {
                              int num64 = this.game.HandyFunctionsObj.GetStaffNeeded(unr) > 0 ? (int) Math.Round(100.0 * ((double) this.game.HandyFunctionsObj.GetStaffPoints(preDef) / (double) this.game.HandyFunctionsObj.GetStaffNeeded(unr))) : 100;
                              if (num64 <= 100)
                              {
                                num62 = (int) Math.Round((double) num62 * (100.0 / (double) num64)) + 1;
                                num63 = (int) Math.Round((double) num63 * (100.0 / (double) num64)) + 1;
                                if (((double) this.game.Data.RuleVar[887] != 1.0 ? Math.Min(100, this.game.Data.UnitObj[unr].SOReplacementPercent) : Math.Min(100, this.game.HandyFunctionsObj.GetAggregatedReplacementRequest(unr))) == 0)
                                  num62 = 0;
                              }
                              else if (((double) this.game.Data.RuleVar[887] != 1.0 ? Math.Min(100, this.game.Data.UnitObj[unr].SOReplacementPercent) : Math.Min(100, this.game.HandyFunctionsObj.GetAggregatedReplacementRequest(unr))) == 0)
                                num62 = 0;
                            }
                            else if (((double) this.game.Data.RuleVar[887] != 1.0 ? Math.Min(100, this.game.Data.UnitObj[unr].SOReplacementPercent) : Math.Min(100, this.game.HandyFunctionsObj.GetAggregatedReplacementRequest(unr))) == 0)
                              num62 = 0;
                          }
                          else if (!this.game.Data.UnitObj[unr].IsHQ | this.game.Data.SFTypeObj[type].StaffPts <= 0 && ((double) this.game.Data.RuleVar[887] != 1.0 ? Math.Min(100, this.game.Data.UnitObj[unr].SOReplacementPercent) : Math.Min(100, this.game.HandyFunctionsObj.GetAggregatedReplacementRequest(unr))) == 0)
                            num62 = 0;
                          if (num62 > 0)
                          {
                            if (this.game.Data.SFTypeObj[type].StaffPts > 0)
                              num62 += Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts);
                            if (nr14 > -1)
                            {
                              int[] weight = simpleList6.Weight;
                              int[] numArray31 = weight;
                              int index96 = nr14;
                              int index97 = index96;
                              int num65 = weight[index96] + num62 * Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts);
                              numArray31[index97] = num65;
                              int[] data3 = simpleList6.Data3;
                              int[] numArray32 = data3;
                              int index98 = nr14;
                              int index99 = index98;
                              int num66 = data3[index98] + 1;
                              numArray32[index99] = num66;
                            }
                            else
                              simpleList6.Add(index1, num62 * Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts), moveType, people, 1, CheckExistence: false);
                          }
                          if (num63 > 0)
                          {
                            if (this.game.Data.SFTypeObj[type].StaffPts > 0)
                              num63 += Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts);
                            if (nr15 > -1)
                            {
                              int[] weight = simpleList8.Weight;
                              int[] numArray33 = weight;
                              int index100 = nr15;
                              int index101 = index100;
                              int num67 = weight[index100] + num63 * Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts);
                              numArray33[index101] = num67;
                              int[] data3 = simpleList8.Data3;
                              int[] numArray34 = data3;
                              int index102 = nr15;
                              int index103 = index102;
                              int num68 = data3[index102] + 1;
                              numArray34[index103] = num68;
                            }
                            else
                              simpleList8.Add(index1, num63 * Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts), moveType, people, 1, CheckExistence: false);
                          }
                        }
                      }
                      else
                      {
                        int num69 = 1;
                        if (((double) this.game.Data.RuleVar[887] != 1.0 ? Math.Min(100, this.game.Data.UnitObj[unr].SOReplacementPercent) : Math.Min(100, this.game.HandyFunctionsObj.GetAggregatedReplacementRequest(unr))) == 0)
                          num69 = 0;
                        if (num69 > 0)
                          flag2 = false;
                      }
                      if (flag2)
                      {
                        int sfCount7 = this.game.Data.UnitObj[unr].SFCount;
                        for (int index104 = 0; index104 <= sfCount7; ++index104)
                        {
                          int sf = this.game.Data.UnitObj[unr].SFList[index104];
                          int type = this.game.Data.SFObj[sf].Type;
                          index1 = this.game.Data.SFTypeObj[type].ReinforcementType;
                          int moveType = this.game.Data.SFObj[sf].MoveType;
                          int people = this.game.Data.SFObj[sf].People;
                          int nr = simpleList7.FindNr(index1, moveType, people);
                          if (!(this.game.Data.SFTypeObj[type].DontReturnFromHQ & this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unr].SOReplacementPercent > 0) && this.game.Data.SFTypeObj[type].Theater != 1)
                          {
                            if (nr > -1)
                            {
                              int[] weight = simpleList7.Weight;
                              int[] numArray35 = weight;
                              int index105 = nr;
                              int index106 = index105;
                              int num70 = weight[index105] + this.game.Data.SFObj[sf].Qty * Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts);
                              numArray35[index106] = num70;
                            }
                            else
                              simpleList7.Add(index1, this.game.Data.SFObj[sf].Qty * Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts), moveType, people, 1, CheckExistence: false);
                          }
                        }
                        int sfCount8 = this.game.Data.UnitObj[unr].SFCount;
                        for (int index107 = 0; index107 <= sfCount8; ++index107)
                        {
                          int sf = this.game.Data.UnitObj[unr].SFList[index107];
                          int type = this.game.Data.SFObj[sf].Type;
                          index1 = this.game.Data.SFTypeObj[type].ReinforcementType;
                          int moveType = this.game.Data.SFObj[sf].MoveType;
                          int people = this.game.Data.SFObj[sf].People;
                          if (this.game.Data.SFTypeObj[type].ReinforcementType2 > -1)
                          {
                            int nr16 = simpleList6.FindNr(index1, moveType, people);
                            int num71 = nr16 <= -1 ? 0 : simpleList6.Weight[nr16];
                            int nr17 = simpleList7.FindNr(index1, moveType, people);
                            if (nr17 > -1)
                            {
                              int num72 = simpleList7.Weight[nr17];
                              if (num72 > num71)
                              {
                                int val1_2 = Math.Min(this.game.Data.SFObj[sf].Qty * Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts), num72 - num71);
                                int nr18 = nr17;
                                index1 = this.game.Data.SFTypeObj[type].ReinforcementType2;
                                int nr19 = simpleList7.FindNr(index1, moveType, people);
                                int nr20 = simpleList6.FindNr(index1, moveType, people);
                                if (nr20 > -1)
                                {
                                  int num73 = simpleList6.Weight[nr20];
                                  if (nr19 > -1)
                                  {
                                    int num74 = simpleList7.Weight[nr19];
                                    int val1_3 = Math.Min(val1_2, num73 - num74);
                                    int num75 = val1_3;
                                    if (this.game.Data.SFTypeObj[type].ReinforcementType > -1 & this.game.Data.SFTypeObj[type].ReinforcementType2 > -1 && this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType] > 0 & this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType2] > 0 && this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType] != this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType2])
                                    {
                                      val1_3 = (int) Math.Round(Conversion.Int((double) val1_3 * ((double) this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType] / (double) this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType2])));
                                      if (val1_3 > num73 - num74)
                                      {
                                        val1_3 = Math.Min(val1_3, num73 - num74);
                                        num75 = (int) Math.Round(Conversion.Int((double) val1_3 * ((double) this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType2] / (double) this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType])));
                                        if ((double) num75 < (double) val1_3 * ((double) this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType2] / (double) this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType]))
                                          ++num75;
                                      }
                                    }
                                    if (val1_3 > 0)
                                    {
                                      int[] weight5 = simpleList7.Weight;
                                      int[] numArray36 = weight5;
                                      int index108 = nr19;
                                      int index109 = index108;
                                      int num76 = weight5[index108] + val1_3;
                                      numArray36[index109] = num76;
                                      int[] data3 = simpleList7.Data3;
                                      int[] numArray37 = data3;
                                      int index110 = nr19;
                                      int index111 = index110;
                                      int num77 = data3[index110] + 1;
                                      numArray37[index111] = num77;
                                      int[] weight6 = simpleList7.Weight;
                                      int[] numArray38 = weight6;
                                      int index112 = nr18;
                                      int index113 = index112;
                                      int num78 = weight6[index112] - num75;
                                      numArray38[index113] = num78;
                                      if (simpleList7.Weight[nr18] <= 0)
                                        simpleList7.RemoveNr(nr18);
                                    }
                                  }
                                  else
                                  {
                                    int num79 = 0;
                                    int num80 = Math.Min(val1_2, num73 - num79);
                                    int num81 = num80;
                                    if (this.game.Data.SFTypeObj[type].ReinforcementType > -1 & this.game.Data.SFTypeObj[type].ReinforcementType2 > -1 && this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType] > 0 & this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType2] > 0 && this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType] != this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType2])
                                    {
                                      num80 = (int) Math.Round(Conversion.Int((double) num80 * ((double) this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType] / (double) this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType2])));
                                      if (num80 > num73 - num79)
                                      {
                                        num80 = Math.Min(num80, num73 - num79);
                                        num81 = (int) Math.Round(Conversion.Int((double) num80 * ((double) this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType2] / (double) this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType])));
                                        if ((double) num81 < (double) num80 * ((double) this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType2] / (double) this.game.Data.ReinfRatio[this.game.Data.SFTypeObj[type].ReinforcementType]))
                                          ++num81;
                                      }
                                    }
                                    if (num80 > 0)
                                    {
                                      simpleList7.Add(index1, num80, moveType, people, 1, CheckExistence: false);
                                      num12 = simpleList7.Counter;
                                      int[] weight = simpleList7.Weight;
                                      int[] numArray39 = weight;
                                      int index114 = nr18;
                                      int index115 = index114;
                                      int num82 = weight[index114] - num81;
                                      numArray39[index115] = num82;
                                      if (simpleList7.Weight[nr18] <= 0)
                                        simpleList7.RemoveNr(nr18);
                                    }
                                  }
                                }
                              }
                            }
                          }
                        }
                        int counter22 = simpleList6.Counter;
                        for (int index116 = 0; index116 <= counter22; ++index116)
                        {
                          index1 = simpleList7.FindNr(simpleList6.Id[index116], simpleList6.Data1[index116], simpleList6.Data2[index116]);
                          if (index1 > -1)
                          {
                            int[] weight = simpleList7.Weight;
                            int[] numArray40 = weight;
                            int index117 = index1;
                            int index118 = index117;
                            int num83 = weight[index117] - simpleList6.Weight[index116];
                            numArray40[index118] = num83;
                            if (1 > simpleList7.Weight[index1])
                              simpleList7.RemoveNr(index1);
                          }
                        }
                        SimpleList simpleList9 = new SimpleList();
                        int counter23 = simpleList7.Counter;
                        for (int index119 = 0; index119 <= counter23; ++index119)
                        {
                          simpleList7.Data5[index119] = 0;
                          simpleList9.Add(simpleList7.Id[index119], simpleList7.Weight[index119], simpleList7.Data1[index119], simpleList7.Data2[index119], CheckExistence: false);
                        }
                        if (unr == 3)
                          unr = unr;
                        if ((double) this.game.Data.RuleVar[883] > 0.0)
                        {
                          if (flag1)
                            simpleList8 = simpleList7.Clone();
                          int counter24 = simpleList8.Counter;
                          for (int index120 = 0; index120 <= counter24; ++index120)
                          {
                            int num84 = simpleList8.Weight[index120];
                            index1 = !(flag1 & this.game.Data.Product == 6) ? Math.Max(1, (int) Math.Round((double) ((float) num84 * (this.game.Data.RuleVar[883] / 100f)))) : Math.Max(1, (int) Math.Round(Math.Ceiling((double) num84 * ((double) this.game.Data.RuleVar[883] / 100.0))));
                            int counter25 = simpleList7.Counter;
                            for (int index121 = 0; index121 <= counter25; ++index121)
                            {
                              if (simpleList7.Id[index121] == simpleList8.Id[index120] & simpleList7.Data1[index121] == simpleList8.Data1[index120] & simpleList7.Data2[index121] == simpleList8.Data2[index120])
                              {
                                simpleList7.Data5[index121] = 1;
                                if (index1 < simpleList7.Weight[index121])
                                  simpleList7.Weight[index121] = index1;
                              }
                            }
                          }
                          int counter26 = simpleList7.Counter;
                          for (int index122 = 0; index122 <= counter26; ++index122)
                          {
                            if (simpleList7.Data5[index122] == 0 && simpleList7.Weight[index122] > 1)
                              simpleList7.Weight[index122] = Math.Max(1, (int) Math.Round((double) ((float) simpleList7.Weight[index122] * (this.game.Data.RuleVar[883] / 100f))));
                          }
                          int counter27 = simpleListArray5[unr].Counter;
                          for (int index123 = 0; index123 <= counter27; ++index123)
                          {
                            for (int counter28 = simpleList7.Counter; counter28 >= 0; counter28 += -1)
                            {
                              if (simpleList7.Id[counter28] == simpleListArray5[unr].Id[index123] & simpleList7.Data1[counter28] == simpleListArray5[unr].Data1[index123] & simpleList7.Data2[counter28] == simpleListArray5[unr].Data2[index123])
                              {
                                int[] weight = simpleList7.Weight;
                                int[] numArray41 = weight;
                                int index124 = counter28;
                                int index125 = index124;
                                int num85 = weight[index124] - simpleListArray5[unr].Weight[index123];
                                numArray41[index125] = num85;
                                if (simpleList7.Weight[counter28] < 1)
                                  simpleList7.RemoveNr(counter28);
                              }
                            }
                          }
                        }
                        if (this.game.Data.UnitObj[unr].IsHQ)
                        {
                          int unitCounter7 = this.game.Data.UnitCounter;
                          for (index1 = 0; index1 <= unitCounter7; ++index1)
                          {
                            if (this.game.Data.UnitObj[index1].HQ == unr && !Information.IsNothing((object) simpleListArray1[index1]))
                            {
                              int counter29 = simpleListArray1[index1].Counter;
                              for (int index126 = 0; index126 <= counter29; ++index126)
                              {
                                int nr21 = simpleList7.FindNr(simpleListArray1[index1].Id[index126], simpleListArray1[index1].Data1[index126], simpleListArray1[index1].Data2[index126]);
                                if (nr21 > -1)
                                {
                                  int[] weight = simpleList7.Weight;
                                  int[] numArray42 = weight;
                                  int index127 = nr21;
                                  int index128 = index127;
                                  int num86 = weight[index127] - simpleListArray1[index1].Weight[index126];
                                  numArray42[index128] = num86;
                                  if (1 > simpleList7.Weight[nr21])
                                    simpleList7.RemoveNr(nr21);
                                }
                                int nr22 = simpleList9.FindNr(simpleListArray1[index1].Id[index126], simpleListArray1[index1].Data1[index126], simpleListArray1[index1].Data2[index126]);
                                if (nr22 > -1)
                                {
                                  int[] weight = simpleList9.Weight;
                                  int[] numArray43 = weight;
                                  int index129 = nr22;
                                  int index130 = index129;
                                  int num87 = weight[index129] - simpleListArray1[index1].Weight[index126];
                                  numArray43[index130] = num87;
                                  if (1 > simpleList9.Weight[nr22])
                                    simpleList9.RemoveNr(nr22);
                                }
                              }
                            }
                          }
                        }
                        if (Operators.CompareString(this.game.Data.UnitObj[unr].Name, "11th Army", false) == 0)
                          unr = unr;
                        if (this.game.Data.UnitObj[unr].IsHQ && !Information.IsNothing((object) simpleListArray4[unr]))
                        {
                          int counter30 = simpleListArray4[unr].Counter;
                          for (int index131 = 0; index131 <= counter30; ++index131)
                          {
                            int nr23 = simpleList7.FindNr(simpleListArray4[unr].Id[index131], simpleListArray4[unr].Data1[index131], simpleListArray4[unr].Data2[index131]);
                            if (nr23 > -1)
                            {
                              int[] weight = simpleList7.Weight;
                              int[] numArray44 = weight;
                              int index132 = nr23;
                              int index133 = index132;
                              int num88 = weight[index132] - simpleListArray4[unr].Weight[index131];
                              numArray44[index133] = num88;
                              if (1 > simpleList7.Weight[nr23])
                                simpleList7.RemoveNr(nr23);
                            }
                            int nr24 = simpleList9.FindNr(simpleListArray4[unr].Id[index131], simpleListArray4[unr].Data1[index131], simpleListArray4[unr].Data2[index131]);
                            if (nr24 > -1)
                            {
                              int[] weight = simpleList9.Weight;
                              int[] numArray45 = weight;
                              int index134 = nr24;
                              int index135 = index134;
                              int num89 = weight[index134] - simpleListArray4[unr].Weight[index131];
                              numArray45[index135] = num89;
                              if (1 > simpleList9.Weight[nr24])
                                simpleList9.RemoveNr(nr24);
                            }
                          }
                        }
                        if (num60 == 1)
                        {
                          for (int counter31 = simpleList9.Counter; counter31 >= 0; counter31 += -1)
                            this.game.Data.UnitObj[unr].AddLog(10, simpleList9.Id[counter31], simpleList9.Data2[counter31], simpleList9.Weight[counter31]);
                        }
                        for (int counter32 = simpleList7.Counter; counter32 >= 0; counter32 += -1)
                        {
                          index1 = this.AutoReinforce_UnitWillGive(unr, simpleList7.Id[counter32], simpleList7.Data1[counter32], simpleList7.Data2[counter32]);
                          if (index1 > -1)
                          {
                            int theater = -2;
                            if ((double) this.game.Data.RuleVar[340] == -1.0)
                              theater = -1;
                            if ((double) this.game.Data.RuleVar[340] > -1.0)
                            {
                              if (((double) this.game.Data.RuleVar[340] == 2.0 | (double) this.game.Data.RuleVar[340] == 3.0) & this.game.Data.UnitObj[index7].AirCap >= mapMatrix2Array2[this.game.Data.UnitObj[unr].Map].Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] * this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].Weight)
                              {
                                theater = 2;
                                this.game.EditObj.TempValue = mapMatrix2Array2;
                              }
                              else if (((double) this.game.Data.RuleVar[340] == 1.0 | (double) this.game.Data.RuleVar[340] == 3.0) & this.game.Data.UnitObj[index7].NavyCap >= mapMatrix2Array1[this.game.Data.UnitObj[unr].Map].Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] * this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].Weight)
                              {
                                theater = 1;
                                this.game.EditObj.TempValue = mapMatrix2Array1;
                              }
                              else if (((double) this.game.Data.RuleVar[340] == 0.0 | (double) this.game.Data.RuleVar[340] == 3.0) & this.game.Data.UnitObj[index7].LandCap >= mapMatrix2Array3[this.game.Data.UnitObj[unr].Map].Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] * this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].Weight)
                              {
                                theater = 0;
                                this.game.EditObj.TempValue = mapMatrix2Array3;
                              }
                              this.game.EditObj.TempValue2 = (MapMatrix2[]) this.game.EditObj.TempValue.Clone();
                              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].MoveType, this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].Theater, this.game.Data.SFObj[index1].Ap, this.game.Data.UnitObj[index7].X, this.game.Data.UnitObj[index7].Y, this.game.Data.UnitObj[index7].Map);
                              if (this.game.EditObj.TempValue[this.game.Data.UnitObj[unr].Map].Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] <= this.game.Data.SFObj[index1].Ap)
                                theater = -1;
                              this.game.EditObj.TempValue = this.game.EditObj.TempValue2;
                            }
                            if (theater > -2)
                            {
                              this.AddPLog("(RETURN) transfer 1 " + this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].Name + " FROM " + this.game.Data.UnitObj[unr].Name + ", landcap=" + Conversion.Str((object) this.game.Data.UnitObj[index7].LandCap) + ", railcap=" + Conversion.Str((object) this.game.Data.UnitObj[index7].AirCap) + ", seacap=" + Conversion.Str((object) this.game.Data.UnitObj[index7].NavyCap));
                              int nr = simpleListArray5[unr].FindNr(simpleList7.Id[counter32], simpleList7.Data1[counter32], simpleList7.Data2[counter32]);
                              if (nr > -1)
                              {
                                int[] weight = simpleListArray5[unr].Weight;
                                int[] numArray46 = weight;
                                int index136 = nr;
                                int index137 = index136;
                                int num90 = weight[index136] + Math.Min(val1_1, this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].PowerPts);
                                numArray46[index137] = num90;
                              }
                              else
                                simpleListArray5[unr].Add(simpleList7.Id[counter32], Math.Min(val1_1, this.game.Data.SFTypeObj[this.game.Data.SFObj[index1].Type].PowerPts), simpleList7.Data1[counter32], simpleList7.Data2[counter32]);
                              int type = this.game.Data.SFObj[index1].Type;
                              if (theater == -1)
                                this.DoTransfer(unr, index7, 0, index1, 1, true, false, MoveMatrixDone: true, IsDisbandTransfer: true);
                              else
                                this.DoTransfer(unr, index7, theater, index1, 1, AddtoHistory: false, byHQ: index7, MoveMatrixDone: true, IsDisbandTransfer: true);
                              if (unr == 3)
                                unr = unr;
                              if (this.game.EditObj.TransferLostQty < 1)
                              {
                                this.game.Data.UnitObj[unr].AddLog(3, this.game.Data.SFTypeObj[type].ReinforcementType, simpleList7.Data2[counter32], Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts));
                                this.game.Data.UnitObj[index7].AddLog(8, this.game.Data.SFTypeObj[type].ReinforcementType, simpleList7.Data2[counter32], Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts));
                              }
                              else
                                this.game.Data.UnitObj[unr].AddLog(4, this.game.Data.SFTypeObj[type].ReinforcementType, simpleList7.Data2[counter32], Math.Min(val1_1, this.game.Data.SFTypeObj[type].PowerPts));
                              num59 = 1;
                              break;
                            }
                          }
                        }
                      }
                    }
                  }
                }
                ++secondaryPhase;
              }
              while (secondaryPhase <= 1);
              ++num6;
            }
            while (num6 <= 2);
          }
        }
      }
      this.game.HandyFunctionsObj.RedimTempValue(9999);
      this.game.HandyFunctionsObj.RedimTempValue2(9999);
      this.WritePLog("autoreinforcelog");
    }

    public void SetCapForUnitS()
    {
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & this.game.Data.UnitObj[unr].PreDef == -1)
          this.game.HandyFunctionsObj.SetCapForUnit(unr);
      }
    }

    public void DoSupplySystem()
    {
      Coordinate[] coordinateArray = new Coordinate[251];
      int[] numArray1 = new int[this.game.Data.UnitCounter + 1];
      int[] numArray2 = new int[this.game.Data.UnitCounter + 1];
      int[] numArray3 = new int[this.game.Data.UnitCounter + 1];
      if (this.game.Data.UnitCounter < 0)
        return;
      int[] numArray4 = new int[this.game.Data.UnitCounter + 1];
      int[] numArray5 = new int[this.game.Data.UnitCounter + 1];
      bool useTrafficRules = false;
      if ((double) this.game.Data.RuleVar[459] > 0.0 & this.game.Data.Product >= 6)
        useTrafficRules = true;
      int num1 = -1;
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        numArray4[index] = -1;
        numArray3[index] = 0;
        numArray5[index] = 0;
        if ((double) this.game.Data.RuleVar[322] == 1.0)
          this.game.Data.UnitObj[index].Reserve = 0;
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn)
        {
          this.game.Data.UnitObj[index].SupplyInReq = 0;
          this.game.Data.UnitObj[index].FuelRequested = 0;
        }
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index].PreDef == -1)
        {
          if (!this.game.Data.UnitObj[index].UnitIsGiven)
          {
            if ((double) this.game.Data.RuleVar[434] < 1.0)
              this.game.Data.UnitObj[index].SupplyConsume = 0;
          }
          else
          {
            this.game.Data.UnitObj[index].SupplyIn = 0;
            this.game.Data.UnitObj[index].FuelRequested = 0;
          }
        }
      }
      int num2;
      do
      {
        num2 = 0;
        ++num1;
        int unitCounter2 = this.game.Data.UnitCounter;
        for (int index = 0; index <= unitCounter2; ++index)
        {
          if (!this.game.Data.UnitObj[index].UnitIsGiven & this.game.Data.UnitObj[index].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index].IsHQ & this.game.Data.UnitObj[index].PreDef <= -1)
          {
            if (num1 == 0)
            {
              if (this.game.Data.UnitObj[index].HQ == -1)
              {
                numArray4[index] = 0;
                num2 = 1;
              }
            }
            else if (!this.game.Data.UnitObj[index].UnitIsGiven & this.game.Data.UnitObj[index].HQ > -1 & numArray4[index] == -1 & this.game.Data.UnitObj[index].PreDef <= -1)
            {
              int hq = this.game.Data.UnitObj[index].HQ;
              if (numArray4[hq] == num1 - 1)
              {
                num2 = 1;
                numArray4[index] = num1;
              }
            }
          }
        }
      }
      while (num2 > 0);
      object obj = (object) (num1 - 1);
      if ((double) this.game.Data.RuleVar[887] == 1.0)
        obj = (object) 0;
      for (int integer = Conversions.ToInteger(obj); integer >= 0; integer += -1)
      {
        int unitCounter3 = this.game.Data.UnitCounter;
        for (int index = 0; index <= unitCounter3; ++index)
        {
          if (!this.game.Data.UnitObj[index].UnitIsGiven & this.game.Data.UnitObj[index].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index].IsHQ & this.game.Data.UnitObj[index].PreDef <= -1 && numArray4[index] == integer)
          {
            Application.DoEvents();
            int num3 = this.game.Data.UnitObj[index].Supply - this.game.Data.UnitObj[index].Reserve;
            int num4 = 0;
            if (num3 < 0)
              num3 = 0;
            int unitCounter4 = this.game.Data.UnitCounter;
            for (int unr = 0; unr <= unitCounter4; ++unr)
            {
              if (!this.game.Data.UnitObj[unr].UnitIsGiven & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & (this.game.Data.UnitObj[unr].HQ == index | (double) this.game.Data.RuleVar[887] == 1.0 & this.game.HandyFunctionsObj.IsUnitInHQChain(unr, index)) & this.game.Data.UnitObj[unr].PreDef <= -1)
              {
                if (this.game.Data.UnitObj[unr].IsHQ & (double) this.game.Data.RuleVar[887] < 1.0)
                {
                  num4 += numArray5[unr];
                  numArray1[unr] = numArray5[unr];
                }
                else
                {
                  int num5 = this.game.HandyFunctionsObj.UnitSupplyNeed(unr, true);
                  if (unr == 137)
                    unr = unr;
                  num4 += num5;
                  numArray1[unr] = num5;
                  this.game.Data.UnitObj[unr].SupplyInReq = num5;
                }
              }
            }
            int num6 = (double) this.game.Data.RuleVar[887] != 1.0 ? this.game.Data.UnitObj[index].SOSupReqPercent : this.game.HandyFunctionsObj.GetAggregatedSupplyRequest(index);
            if (this.game.Data.UnitObj[index].HQ != -1)
              num4 = (int) Math.Round((double) num4 * ((double) num6 / 100.0));
            int num7 = num4 + this.game.HandyFunctionsObj.UnitSupplyNeed(index, false);
            int num8 = num3 - num7;
            numArray5[index] = num8 >= 0 ? 0 : -num8;
            this.game.Data.UnitObj[index].SupplyInReq = numArray5[index];
          }
        }
      }
      int integer1 = Conversions.ToInteger(obj);
      for (int index1 = 0; index1 <= integer1; ++index1)
      {
        int unitCounter5 = this.game.Data.UnitCounter;
        for (int index2 = 0; index2 <= unitCounter5; ++index2)
        {
          if (this.game.Data.UnitObj[index2].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index2].IsHQ && index1 == numArray4[index2])
          {
            int num9 = this.game.Data.UnitObj[index2].Supply;
            int num10 = this.game.HandyFunctionsObj.UnitSupplyNeed(index2, false);
            if (num9 < 0)
              num9 = 0;
            SimpleList simpleList = new SimpleList();
            int unitCounter6 = this.game.Data.UnitCounter;
            for (int unr = 0; unr <= unitCounter6; ++unr)
            {
              if (!this.game.Data.UnitObj[unr].UnitIsGiven & this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].PreDef <= -1 && this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & (this.game.Data.UnitObj[unr].HQ == index2 | (double) this.game.Data.RuleVar[887] == 1.0 & this.game.HandyFunctionsObj.IsUnitInHQChain(unr, index2)))
              {
                if (this.game.Data.UnitObj[unr].IsHQ & (double) this.game.Data.RuleVar[887] < 1.0)
                {
                  num10 += numArray5[unr];
                }
                else
                {
                  int num11 = this.game.HandyFunctionsObj.UnitSupplyNeed(unr, true);
                  num10 += num11;
                }
              }
            }
            this.game.Data.UnitObj[index2].SupplyReq = num10 - this.game.HandyFunctionsObj.UnitSupplyNeed(index2, false);
            float num12 = num10 <= num9 ? 1f : (float) num9 / (float) num10;
            int unitCounter7 = this.game.Data.UnitCounter;
            int unr1;
            for (int index3 = 0; index3 <= unitCounter7; ++index3)
            {
              if (!this.game.Data.UnitObj[index3].UnitIsGiven & this.game.Data.UnitObj[index3].X > -1 & this.game.Data.UnitObj[index3].PreDef <= -1 && this.game.Data.UnitObj[index3].Regime == this.game.Data.Turn & (this.game.Data.UnitObj[index3].HQ == index2 | (double) this.game.Data.RuleVar[887] == 1.0 & this.game.HandyFunctionsObj.IsUnitInHQChain(index3, index2)))
              {
                int num13 = 0;
                if (Strings.InStr(this.game.Data.UnitObj[index3].Name, "11th Panzer") > 0)
                  unr1 = unr1;
                if (index3 == 154)
                  unr1 = unr1;
                if (!this.game.Data.UnitObj[index3].IsHQ | (double) this.game.Data.RuleVar[887] == 1.0)
                  num13 = this.game.HandyFunctionsObj.UnitSupplyNeed(index3, true);
                else if (this.game.Data.UnitObj[index3].IsHQ)
                  num13 += numArray5[index3];
                int tdata1 = (int) Math.Round((double) Conversion.Int((float) num13 * num12));
                simpleList.Add(index3, 0, tdata1);
              }
            }
            if (simpleList.Counter > -1 && this.game.Data.UnitObj[index2].X > -1)
            {
              int movetype = (int) Math.Round((double) this.game.Data.RuleVar[99]);
              int index4;
              if ((double) this.game.Data.RuleVar[455] > 0.0)
              {
                this.game.HandyFunctionsObj.MakeFuzzyOwner(true, false, this.game.Data.Turn);
                int mapWidth = this.game.Data.MapObj[index4].MapWidth;
                for (int index5 = 0; index5 <= mapWidth; ++index5)
                {
                  int mapHeight = this.game.Data.MapObj[index4].MapHeight;
                  for (int index6 = 0; index6 <= mapHeight; ++index6)
                    this.game.EditObj.TempValue2[index4].Value[index5, index6] = this.game.Data.MapObj[0].HexObj[index5, index6].Regime;
                }
                this.game.HandyFunctionsObj.MakeFuzzyOwner(false, false, this.game.Data.Turn);
              }
              CoordList coordList1 = this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype, 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y, this.game.Data.UnitObj[index2].Map, allowshoredrop: true, SeaBlock: true, useTrafficRules: useTrafficRules);
              if (numArray3[index2] > 0)
              {
                int mapCounter = this.game.Data.MapCounter;
                for (index4 = 0; index4 <= mapCounter; ++index4)
                {
                  int mapWidth = this.game.Data.MapObj[index4].MapWidth;
                  for (int index7 = 0; index7 <= mapWidth; ++index7)
                  {
                    int mapHeight = this.game.Data.MapObj[index4].MapHeight;
                    for (int index8 = 0; index8 <= mapHeight; ++index8)
                    {
                      int[,] numArray6 = this.game.EditObj.TempValue[index4].Value;
                      int[,] numArray7 = numArray6;
                      int index9 = index7;
                      int index10 = index9;
                      int index11 = index8;
                      int index12 = index11;
                      int num14 = numArray6[index9, index11] + numArray3[index2];
                      numArray7[index10, index12] = num14;
                    }
                  }
                }
              }
              int counter1 = simpleList.Counter;
              for (int index13 = 0; index13 <= counter1; ++index13)
                simpleList.Data2[index13] = (double) this.game.EditObj.TempValue[this.game.Data.UnitObj[simpleList.Id[index13]].Map].Value[this.game.Data.UnitObj[simpleList.Id[index13]].X, this.game.Data.UnitObj[simpleList.Id[index13]].Y] <= (double) this.game.Data.RuleVar[3] ? 0 : 1;
              int counter2 = simpleList.Counter;
              for (int index14 = 0; index14 <= counter2; ++index14)
              {
                int index15;
                if ((double) this.game.Data.RuleVar[455] > 0.0 && simpleList.Data2[index14] == 0)
                {
                  bool flag = true;
                  int num15 = 0;
                  while (flag)
                  {
                    ++num15;
                    flag = false;
                    CoordList coordList2 = new CoordList();
                    Coordinate coordinate;
                    coordinate.x = this.game.Data.UnitObj[simpleList.Id[index14]].X;
                    coordinate.y = this.game.Data.UnitObj[simpleList.Id[index14]].Y;
                    if (coordinate.x == 41 & coordinate.y == 27)
                      index15 = index15;
                    coordinate.onmap = true;
                    while (coordinate.onmap)
                    {
                      coordinate = this.game.EditObj.TempCameFrom[0].Value[coordinate.x, coordinate.y];
                      if (coordinate.onmap)
                        coordList2.AddCoord(coordinate.x, coordinate.y, 0);
                    }
                    if (coordList2.counter > -1)
                    {
                      flag = false;
                      for (int index16 = coordList2.counter; index16 >= 0; index16 += -1)
                      {
                        if (coordList2.coord[index14].x == 47 & coordList2.coord[index14].y == 23)
                          index16 = index16;
                        if (this.game.EditObj.TempValue2[index4].Value[coordList2.coord[index16].x, coordList2.coord[index16].y] != this.game.Data.Turn)
                        {
                          this.game.Data.MapObj[0].HexObj[coordList2.coord[index16].x, coordList2.coord[index16].y].FuzzyBlock = 1;
                          this.game.HandyFunctionsObj.MakeFuzzyOwner(false, false, this.game.Data.Turn);
                          coordList1 = this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype, 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y, this.game.Data.UnitObj[index2].Map, allowshoredrop: true, SeaBlock: true, useTrafficRules: useTrafficRules);
                          flag = true;
                          break;
                        }
                      }
                    }
                    if (!flag && (double) this.game.EditObj.TempValue[this.game.Data.UnitObj[simpleList.Id[index14]].Map].Value[this.game.Data.UnitObj[simpleList.Id[index14]].X, this.game.Data.UnitObj[simpleList.Id[index14]].Y] > (double) this.game.Data.RuleVar[3])
                      simpleList.Data2[index14] = 1;
                    if (num15 > 999)
                    {
                      flag = false;
                      simpleList.Data2[index14] = 1;
                    }
                  }
                }
                if (simpleList.Data2[index14] == 0)
                {
                  unr1 = simpleList.Id[index14];
                  int num16 = simpleList.Data1[index14];
                  int num17 = 100;
                  if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[simpleList.Id[index14]].Map].Value[this.game.Data.UnitObj[simpleList.Id[index14]].X, this.game.Data.UnitObj[simpleList.Id[index14]].Y] > (double) this.game.Data.RuleVar[51])
                    num17 = 75;
                  if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[simpleList.Id[index14]].Map].Value[this.game.Data.UnitObj[simpleList.Id[index14]].X, this.game.Data.UnitObj[simpleList.Id[index14]].Y] > (double) this.game.Data.RuleVar[52])
                    num17 = 50;
                  if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[simpleList.Id[index14]].Map].Value[this.game.Data.UnitObj[simpleList.Id[index14]].X, this.game.Data.UnitObj[simpleList.Id[index14]].Y] > (double) this.game.Data.RuleVar[53])
                    num17 = 25;
                  if ((double) this.game.Data.RuleVar[434] > 0.0)
                    num17 = this.game.Data.UnitObj[unr1].SOSupReqPercent > num17 ? (int) Math.Round(Math.Floor((double) (100 * num17) / (double) this.game.Data.UnitObj[unr1].SOSupReqPercent)) : 100;
                  int num18 = (int) Math.Round(Conversion.Int(Math.Floor((double) (num16 * num17) / 100.0)));
                  int num19 = num18;
                  int antiSupply = this.game.HandyFunctionsObj.GetAntiSupply(this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y, this.game.Data.UnitObj[index2].Map, this.game.Data.UnitObj[unr1].X, this.game.Data.UnitObj[unr1].Y, this.game.Data.UnitObj[unr1].Map);
                  int suppts = (int) Math.Round(Conversion.Int((double) num18 * ((double) antiSupply / 100.0)));
                  int num20 = num18 - suppts;
                  RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                  RegimeClass[] regimeClassArray = regimeObj;
                  int turn = this.game.Data.Turn;
                  int index17 = turn;
                  regimeClassArray[index17].SASSupplyLost = regimeObj[turn].SASSupplyLost + suppts;
                  this.game.HandyFunctionsObj.SetAntiSupplyKills(this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y, this.game.Data.UnitObj[index2].Map, this.game.Data.UnitObj[unr1].X, this.game.Data.UnitObj[unr1].Y, this.game.Data.UnitObj[unr1].Map, suppts, 0, 0);
                  if ((double) this.game.Data.RuleVar[324] == 1.0 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                    numArray3[unr1] = this.game.EditObj.TempValue[this.game.Data.UnitObj[unr1].Map].Value[this.game.Data.UnitObj[unr1].X, this.game.Data.UnitObj[unr1].Y];
                  if (this.game.Data.UnitObj[unr1].Supply < 0)
                    this.game.Data.UnitObj[unr1].Supply = 0;
                  int num21 = Math.Max(num20 - (this.game.HandyFunctionsObj.UnitSupplyNeed(unr1, true, false) + numArray5[unr1]), 0);
                  int num22 = num20 - num21;
                  this.game.Data.UnitObj[unr1].Supply += num22;
                  UnitClass[] unitObj1 = this.game.Data.UnitObj;
                  UnitClass[] unitClassArray1 = unitObj1;
                  int index18 = unr1;
                  int index19 = index18;
                  unitClassArray1[index19].StockpileCurrent = unitObj1[index18].StockpileCurrent + num21;
                  if (this.game.Data.UnitObj[unr1].StockpileCurrent > this.game.HandyFunctionsObj.GetMaxStockpile(unr1))
                    this.game.Data.UnitObj[unr1].StockpileCurrent = this.game.HandyFunctionsObj.GetMaxStockpile(unr1);
                  if (num21 > 0)
                    ;
                  if (unr1 == 815)
                    unr1 = unr1;
                  int[] numArray8 = numArray2;
                  int[] numArray9 = numArray8;
                  int index20 = unr1;
                  int index21 = index20;
                  int num23 = numArray8[index20] + num20;
                  numArray9[index21] = num23;
                  UnitClass[] unitObj2 = this.game.Data.UnitObj;
                  UnitClass[] unitClassArray2 = unitObj2;
                  int index22 = unr1;
                  int index23 = index22;
                  unitClassArray2[index23].SupplyLost = unitObj2[index22].SupplyLost + suppts;
                  UnitClass[] unitObj3 = this.game.Data.UnitObj;
                  UnitClass[] unitClassArray3 = unitObj3;
                  int index24 = unr1;
                  int index25 = index24;
                  unitClassArray3[index25].SupplyIn = unitObj3[index24].SupplyIn + num20;
                  UnitClass[] unitObj4 = this.game.Data.UnitObj;
                  UnitClass[] unitClassArray4 = unitObj4;
                  int index26 = index2;
                  int index27 = index26;
                  unitClassArray4[index27].SupplyOut = unitObj4[index26].SupplyOut + num19;
                  simpleList.Data1[index14] = simpleList.Data1[index14] - num20;
                  this.game.Data.UnitObj[index2].Supply -= num19;
                  if (useTrafficRules)
                  {
                    Coordinate coordinate1;
                    coordinate1.x = this.game.Data.UnitObj[unr1].X;
                    coordinate1.y = this.game.Data.UnitObj[unr1].Y;
                    bool flag = false;
                    int index28 = 0;
                    while (this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y].onmap)
                    {
                      int num24 = index28 + 1;
                      Coordinate coordinate2 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                      index15 = this.game.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0) - 1;
                      int index29 = index15 + 3;
                      if (index29 > 5)
                        index29 -= 6;
                      int liSpoint1 = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[index15];
                      int liSpoint2 = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints[index29];
                      int[] liSpoints1 = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints;
                      int[] numArray10 = liSpoints1;
                      int index30 = index15;
                      int index31 = index30;
                      int num25 = liSpoints1[index30] + num19;
                      numArray10[index31] = num25;
                      int[] liSpoints2 = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints;
                      int[] numArray11 = liSpoints2;
                      int index32 = index29;
                      int index33 = index32;
                      int num26 = liSpoints2[index32] + num19;
                      numArray11[index33] = num26;
                      int index34 = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[index15];
                      if (index34 > -1 && this.game.Data.RoadTypeObj[index34].trafficPoints > 0)
                      {
                        int num27 = (int) Math.Round(Math.Floor((double) (liSpoint1 * 1) / (double) this.game.Data.RoadTypeObj[index34].trafficPoints));
                        if ((int) Math.Round(Math.Floor((double) (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[index15] * 1) / (double) this.game.Data.RoadTypeObj[index34].trafficPoints)) > num27)
                          flag = true;
                      }
                      index28 = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].RoadType[index29];
                      if (index28 > -1 && this.game.Data.RoadTypeObj[index28].trafficPoints > 0)
                      {
                        int num28 = (int) Math.Round(Math.Floor((double) (liSpoint2 * 1) / (double) this.game.Data.RoadTypeObj[index28].trafficPoints));
                        if ((int) Math.Round(Math.Floor((double) (this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints[index29] * 1) / (double) this.game.Data.RoadTypeObj[index28].trafficPoints)) > num28)
                          flag = true;
                      }
                      coordinate1 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                      if (index28 > 999)
                        break;
                    }
                    if (flag)
                      coordList1 = this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype, 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y, this.game.Data.UnitObj[index2].Map, allowshoredrop: true, SeaBlock: true, useTrafficRules: useTrafficRules);
                  }
                }
              }
            }
          }
        }
      }
      int unitCounter8 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter8; ++index)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn)
          this.game.Data.UnitObj[index].LastSupplyPercent = numArray1[index] <= 0 ? -1 : (int) Math.Round(Conversion.Int((double) numArray2[index] / (double) numArray1[index] * 100.0));
      }
      if ((double) this.game.Data.RuleVar[435] <= 0.0)
        return;
      int num29 = 0;
      int unitCounter9 = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter9; ++unr)
      {
        if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & this.game.Data.UnitObj[unr].PreDef == -1)
        {
          int num30 = this.game.HandyFunctionsObj.UnitMaximumFuelReserve(unr);
          if (num30 > 0)
          {
            int num31 = num30 - this.game.Data.UnitObj[unr].Fuel;
            if (num31 > 0)
              num29 += num31;
          }
        }
      }
      if (num29 <= 0)
        return;
      float num32 = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[(int) Math.Round((double) this.game.Data.RuleVar[435])] <= 0 ? 0.0f : (float) this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[(int) Math.Round((double) this.game.Data.RuleVar[435])] / (float) num29;
      if ((double) num32 > 1.0)
        num32 = 1f;
      int unitCounter10 = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter10; ++unr)
      {
        if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & this.game.Data.UnitObj[unr].PreDef == -1)
        {
          this.game.Data.UnitObj[unr].FuelRequested = 0;
          this.game.Data.UnitObj[unr].FuelReceived = 0;
          int num33 = Math.Max(0, this.game.HandyFunctionsObj.UnitMaximumFuelReserve(unr) - this.game.Data.UnitObj[unr].Fuel);
          this.game.Data.UnitObj[unr].FuelRequested = num33;
          if (num33 > 0 & this.game.Data.UnitObj[unr].LastSupplyPercent > 0)
          {
            int num34 = (int) Math.Round(Math.Floor((double) num33 * (double) num32 * (double) this.game.Data.UnitObj[unr].LastSupplyPercent / 100.0));
            this.game.Data.UnitObj[unr].FuelReceived = num34;
            UnitClass[] unitObj = this.game.Data.UnitObj;
            UnitClass[] unitClassArray = unitObj;
            int index35 = unr;
            int index36 = index35;
            unitClassArray[index36].Fuel = unitObj[index35].Fuel + num34;
            int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
            int[] numArray12 = regimeSlot;
            int index37 = (int) Math.Round((double) this.game.Data.RuleVar[435]);
            int index38 = index37;
            int num35 = regimeSlot[index37] - num34;
            numArray12[index38] = num35;
          }
        }
      }
    }

    public void AddSupplyLog(
      int fromUnitId,
      int fromLocId,
      int tooUnitId,
      int tooLocId,
      int type,
      int phase,
      int request,
      int delivered,
      int ap,
      string texty)
    {
      if ((double) this.game.Data.RuleVar[499] < 1.0)
        return;
      int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[499]));
      if (stringListById == -1)
        return;
      int turn = this.game.Data.Turn;
      this.game.Data.StringListObj[stringListById].AddRowWithData(turn.ToString(), fromUnitId.ToString(), fromLocId.ToString(), tooUnitId.ToString(), tooLocId.ToString(), type.ToString(), phase.ToString(), request.ToString(), delivered.ToString(), s10: ap.ToString(), s11: texty);
    }

    public void DoSupplyBaseSystem(
      bool depleteMode,
      bool buildUpMode,
      bool evacuateMode,
      bool finalMode,
      bool supplySourceMode)
    {
      Coordinate[] coordinateArray = new Coordinate[251];
      int num1 = Math.Max(this.game.Data.UnitCounter, this.game.Data.LocCounter);
      int[] numArray1 = new int[num1 + 1 + 1];
      int[] numArray2 = new int[num1 + 1 + 1];
      int[] numArray3 = new int[num1 + 1 + 1];
      int[] numArray4 = new int[num1 + 1 + 1];
      int[] numArray5 = new int[num1 + 1 + 1];
      int[] numArray6 = new int[num1 + 1 + 1];
      int[] numArray7 = new int[num1 + 1 + 1];
      int[] numArray8 = new int[num1 + 1 + 1];
      int[] numArray9 = new int[num1 + 1 + 1];
      int[] numArray10 = new int[num1 + 1 + 1];
      int[] numArray11 = new int[num1 + 1 + 1];
      int[] numArray12 = new int[num1 + 1 + 1];
      int[] numArray13 = new int[num1 + 1 + 1];
      int index1;
      if (depleteMode)
      {
        int unitCounter = this.game.Data.UnitCounter;
        for (int unr = 0; unr <= unitCounter; ++unr)
        {
          if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].X > -1)
          {
            int num2 = this.game.HandyFunctionsObj.UnitMaximumFuelReserve(unr);
            if (this.game.Data.UnitObj[unr].Fuel > num2)
              this.game.Data.UnitObj[unr].Fuel = num2;
            index1 = this.game.HandyFunctionsObj.UnitSupplyStore(unr) + this.game.HandyFunctionsObj.UnitSupplyUse(unr);
            if (this.game.Data.UnitObj[unr].Supply > index1)
              this.game.Data.UnitObj[unr].Supply = index1;
          }
        }
      }
      if (finalMode)
      {
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; ++index2)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; ++index3)
          {
            if (this.game.Data.MapObj[0].HexObj[index2, index3].Location2 > -1 & this.game.Data.MapObj[0].HexObj[index2, index3].Regime == this.game.Data.Turn)
            {
              bool flag = false;
              int location2;
              if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index2, index3].Location2].Type].isSupplySource)
              {
                location2 = this.game.Data.MapObj[0].HexObj[index2, index3].Location2;
                if (this.game.Data.LocObj[location2].supplyIn <= 0 & this.game.Data.LocObj[location2].fuelIn <= 0 && this.game.Data.LocObj[location2].supply <= 0 & this.game.Data.LocObj[location2].fuel <= 0)
                  flag = true;
              }
              else if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index2, index3].Location2].Type].isSupplyBase)
              {
                int supplyBaseMode = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index2, index3].Location2].supplyBaseMode;
                int num3 = supplyBaseMode;
                location2 = this.game.Data.MapObj[0].HexObj[index2, index3].Location2;
                int type = this.game.Data.LocObj[location2].Type;
                if (supplyBaseMode == 5)
                {
                  int num4 = this.game.Data.LocObj[location2].supply;
                  int num5 = (int) Math.Round((double) (this.game.Data.LocTypeObj[type].maxSupply * this.game.Data.LocTypeObj[type].maxDestroy) / 100.0);
                  if (num5 < num4)
                    num4 = num5;
                  LocationClass[] locObj1 = this.game.Data.LocObj;
                  LocationClass[] locationClassArray1 = locObj1;
                  int index4 = location2;
                  int index5 = index4;
                  locationClassArray1[index5].supplyDestroyed = locObj1[index4].supplyDestroyed + num4;
                  LocationClass[] locObj2 = this.game.Data.LocObj;
                  LocationClass[] locationClassArray2 = locObj2;
                  int index6 = location2;
                  int index7 = index6;
                  locationClassArray2[index7].supply = locObj2[index6].supply - num4;
                  int num6 = this.game.Data.LocObj[location2].fuel;
                  int num7 = (int) Math.Round((double) (this.game.Data.LocTypeObj[type].maxFuel * this.game.Data.LocTypeObj[type].maxDestroy) / 100.0);
                  if (num7 < num6)
                    num6 = num7;
                  LocationClass[] locObj3 = this.game.Data.LocObj;
                  LocationClass[] locationClassArray3 = locObj3;
                  int index8 = location2;
                  int index9 = index8;
                  locationClassArray3[index9].fuelDestroyed = locObj3[index8].fuelDestroyed + num6;
                  LocationClass[] locObj4 = this.game.Data.LocObj;
                  LocationClass[] locationClassArray4 = locObj4;
                  int index10 = location2;
                  int index11 = index10;
                  locationClassArray4[index11].fuel = locObj4[index10].fuel - num6;
                }
                if (supplyBaseMode == 2 && this.game.Data.LocObj[location2].supply >= this.game.Data.LocTypeObj[type].maxSupply && this.game.Data.LocObj[location2].fuel >= this.game.Data.LocTypeObj[type].maxFuel && this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index2, index3].Location2].supplyBaseFixed < 1)
                  this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index2, index3].Location2].supplyBaseMode = 1;
                if ((int) Math.Round(Math.Floor((double) (this.game.Data.LocTypeObj[type].Logistical * this.game.Data.LocObj[location2].supply) / (double) this.game.Data.LocTypeObj[type].maxSupply)) <= 0 & (int) Math.Round(Math.Floor((double) (this.game.Data.LocTypeObj[type].Logistical * this.game.Data.LocObj[location2].fuel) / (double) this.game.Data.LocTypeObj[type].maxFuel)) <= 0 & (num3 == 4 | num3 == 5))
                  flag = true;
              }
              if (flag)
                this.game.Data.RemoveLoc(location2);
            }
          }
        }
      }
      else
      {
        if (this.game.Data.UnitCounter < 0)
          return;
        bool useTrafficRules = false;
        if ((double) this.game.Data.RuleVar[459] > 0.0 & this.game.Data.Product >= 6)
          useTrafficRules = true;
        if (depleteMode)
        {
          int unitCounter = this.game.Data.UnitCounter;
          for (int index12 = 0; index12 <= unitCounter; ++index12)
          {
            this.game.Data.UnitObj[index12].supplyBaseSupplyIn = 0;
            this.game.Data.UnitObj[index12].supplyBaseFuelIn = 0;
          }
          int locCounter = this.game.Data.LocCounter;
          for (int index13 = 0; index13 <= locCounter; ++index13)
          {
            if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index13].X, this.game.Data.LocObj[index13].Y].Regime == this.game.Data.Turn)
            {
              this.game.Data.LocObj[index13].supplyEvacuated = 0;
              this.game.Data.LocObj[index13].supplyDestroyed = 0;
              this.game.Data.LocObj[index13].supplyOutUnits = 0;
              this.game.Data.LocObj[index13].fuelOutUnits = 0;
              if (!this.game.Data.LocTypeObj[this.game.Data.LocObj[index13].Type].isSupplySource)
              {
                this.game.Data.LocObj[index13].supplyIn = 0;
                this.game.Data.LocObj[index13].fuelIn = 0;
              }
              this.game.Data.LocObj[index13].supplyReq = 0;
              this.game.Data.LocObj[index13].fuelReq = 0;
              this.game.Data.LocObj[index13].fuelEvacuated = 0;
              this.game.Data.LocObj[index13].fuelDestroyed = 0;
              this.game.Data.LocObj[index13].fuelOutUnits = 0;
            }
          }
        }
        int unitCounter1 = this.game.Data.UnitCounter;
        for (int index14 = 0; index14 <= unitCounter1; ++index14)
        {
          numArray1[index14] = 0;
          numArray2[index14] = 0;
        }
        int locCounter1 = this.game.Data.LocCounter;
        for (int index15 = 0; index15 <= locCounter1; ++index15)
        {
          numArray1[index15] = 0;
          numArray2[index15] = 0;
          numArray4[index15] = 0;
          numArray3[index15] = 0;
        }
        if (supplySourceMode)
        {
          int locCounter2 = this.game.Data.LocCounter;
          for (int index16 = 0; index16 <= locCounter2; ++index16)
          {
            numArray3[index16] = 0;
            if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index16].X, this.game.Data.LocObj[index16].Y].Regime == this.game.Data.Turn && this.game.Data.LocTypeObj[this.game.Data.LocObj[index16].Type].isSupplySource)
            {
              this.game.Data.LocObj[index16].supplyEvacuated = 0;
              this.game.Data.LocObj[index16].supplyDestroyed = 0;
              this.game.Data.LocObj[index16].supplyOutUnits = 0;
              this.game.Data.LocObj[index16].fuelOutUnits = 0;
              this.game.Data.LocObj[index16].supplyReq = 0;
              this.game.Data.LocObj[index16].fuelReq = 0;
              this.game.Data.LocObj[index16].fuelEvacuated = 0;
              this.game.Data.LocObj[index16].fuelDestroyed = 0;
              this.game.Data.LocObj[index16].fuelOutUnits = 0;
              this.game.Data.LocObj[index16].supplyOutBases = 0;
              this.game.Data.LocObj[index16].fuelOutBases = 0;
              this.game.Data.LocObj[index16].fuelExcess = 0;
              this.game.Data.LocObj[index16].supplyExcess = 0;
            }
          }
          int unitCounter2 = this.game.Data.UnitCounter;
          for (int index17 = 0; index17 <= unitCounter2; ++index17)
          {
            if ((double) this.game.Data.RuleVar[322] == 1.0)
              this.game.Data.UnitObj[index17].Reserve = 0;
            if (this.game.Data.UnitObj[index17].Regime == this.game.Data.Turn)
            {
              this.game.Data.UnitObj[index17].SupplyInReq = 0;
              this.game.Data.UnitObj[index17].FuelRequested = 0;
              this.game.Data.UnitObj[index17].supplyX = -1;
              this.game.Data.UnitObj[index17].supplyY = -1;
            }
            if (this.game.Data.UnitObj[index17].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index17].PreDef == -1)
            {
              if (!this.game.Data.UnitObj[index17].UnitIsGiven)
              {
                if ((double) this.game.Data.RuleVar[434] < 1.0)
                  this.game.Data.UnitObj[index17].SupplyConsume = 0;
              }
              else
              {
                this.game.Data.UnitObj[index17].SupplyIn = 0;
                this.game.Data.UnitObj[index17].FuelReceived = 0;
              }
            }
          }
        }
        int num8 = 10;
        SimpleList simpleList1 = new SimpleList();
        int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
        for (int tdata1 = 0; tdata1 <= mapWidth1; ++tdata1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int tdata2 = 0; tdata2 <= mapHeight; ++tdata2)
          {
            if (this.game.Data.MapObj[0].HexObj[tdata1, tdata2].Location2 > -1 & this.game.Data.MapObj[0].HexObj[tdata1, tdata2].Regime == this.game.Data.Turn && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[tdata1, tdata2].Location2].Type].isSupplyBase | this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[tdata1, tdata2].Location2].Type].isSupplySource)
              simpleList1.Add(tdata1 * 1000 + tdata2, 0, tdata1, tdata2);
          }
        }
        int num9 = num8;
        int num10;
        int num11;
        int num12;
        int num13;
        for (int phase = 1; phase <= num9; ++phase)
        {
          simpleList1.ReverseSort();
          index1 = index1;
          bool flag1 = false;
          int counter1 = simpleList1.Counter;
          for (int index18 = 0; index18 <= counter1; ++index18)
          {
            int index19 = simpleList1.Data1[index18];
            int index20 = simpleList1.Data2[index18];
            bool flag2 = false;
            if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index19, index20].Location2].Type].isSupplyBase)
            {
              index1 = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index19, index20].Location2].supplyBaseMode;
              if (index1 == 3 & depleteMode)
                flag2 = true;
              if (index1 == 2 & buildUpMode)
                flag2 = true;
              if (index1 == 4 & evacuateMode)
                flag2 = true;
            }
            if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index19, index20].Location2].Type].isSupplySource && supplySourceMode)
              flag2 = true;
            if (flag2)
            {
              if (index18 != 0)
              {
                int[] weight = simpleList1.Weight;
                int[] numArray14 = weight;
                int index21 = index18;
                int index22 = index21;
                int num14 = weight[index21] + 1;
                numArray14[index22] = num14;
              }
              int location2 = this.game.Data.MapObj[0].HexObj[index19, index20].Location2;
              int type = this.game.Data.LocObj[location2].Type;
              SimpleList simpleList2;
              int delivered1;
              int delivered2;
              if (phase == 1)
              {
                simpleList2 = new SimpleList();
                int unitCounter3 = this.game.Data.UnitCounter;
                for (int index23 = 0; index23 <= unitCounter3; ++index23)
                {
                  if (!this.game.Data.UnitObj[index23].UnitIsGiven & this.game.Data.UnitObj[index23].X > -1 & this.game.Data.UnitObj[index23].PreDef <= -1 && this.game.Data.UnitObj[index23].Regime == this.game.Data.Turn)
                  {
                    if (Strings.InStr(this.game.Data.UnitObj[index23].Name, "1818 H") > 0)
                      index23 = index23;
                    int num15 = (double) this.game.Data.RuleVar[887] != 1.0 ? Math.Min(100, this.game.Data.UnitObj[index23].SOSupReqPercent) : Math.Min(100, this.game.HandyFunctionsObj.GetAggregatedSupplyRequest(index23));
                    if (depleteMode)
                    {
                      simpleList2.Add(index23, 1);
                      delivered1 = (int) Math.Round((double) (this.game.HandyFunctionsObj.UnitSupplyNeed(index23, true) * num15) / 100.0);
                      if (delivered1 > numArray2[index23])
                        numArray2[index23] = delivered1;
                      if (!flag1)
                        num10 += numArray2[index23];
                      delivered2 = (int) Math.Round((double) (Math.Max(0, this.game.HandyFunctionsObj.UnitMaximumFuelReserve(index23) - this.game.Data.UnitObj[index23].Fuel) * num15) / 100.0);
                      if (delivered2 > numArray6[index23])
                        numArray6[index23] = delivered2;
                      if (!flag1)
                        num11 += numArray6[index23];
                    }
                    else if (supplySourceMode)
                    {
                      simpleList2.Add(index23, 1);
                      delivered1 = (int) Math.Round((double) (this.game.HandyFunctionsObj.UnitSupplyNeed(index23, true) * num15) / 100.0);
                      if (delivered1 > numArray2[index23])
                        numArray2[index23] = delivered1;
                      this.game.Data.UnitObj[index23].SupplyInReq = numArray2[index23];
                      if (!flag1)
                        num10 += numArray2[index23];
                      delivered2 = (int) Math.Round((double) (Math.Max(0, this.game.HandyFunctionsObj.UnitMaximumFuelReserve(index23) - this.game.Data.UnitObj[index23].Fuel) * num15) / 100.0);
                      if (delivered2 > numArray6[index23])
                        numArray6[index23] = delivered2;
                      this.game.Data.UnitObj[index23].FuelRequested = numArray6[index23];
                      if (!flag1)
                        num11 += numArray6[index23];
                    }
                  }
                }
                int locCounter3 = this.game.Data.LocCounter;
                for (int tid = 0; tid <= locCounter3; ++tid)
                {
                  if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[tid].X, this.game.Data.LocObj[tid].Y].Regime == this.game.Data.Turn && this.game.Data.LocTypeObj[this.game.Data.LocObj[tid].Type].isSupplySource)
                  {
                    if (buildUpMode)
                    {
                      simpleList2.Add(tid, 1);
                      int num16 = this.game.Data.LocTypeObj[type].maxSupply - this.game.Data.LocObj[location2].supply;
                      int num17 = (int) Math.Round((double) (this.game.Data.LocTypeObj[type].maxSupply * this.game.Data.LocTypeObj[type].maxEvacuate) / 100.0);
                      if (num17 < num16)
                        num16 = num17;
                      if (num16 > numArray3[location2])
                        numArray3[location2] = num16;
                      this.game.Data.LocObj[location2].supplyReq = numArray3[location2];
                      if (!flag1)
                        num10 += numArray3[location2];
                      delivered1 = this.game.Data.LocTypeObj[type].maxFuel - this.game.Data.LocObj[location2].fuel;
                      int num18 = (int) Math.Round((double) (this.game.Data.LocTypeObj[type].maxFuel * this.game.Data.LocTypeObj[type].maxEvacuate) / 100.0);
                      if (num18 < delivered1)
                        delivered1 = num18;
                      if (delivered1 > numArray7[location2])
                        numArray7[location2] = delivered1;
                      this.game.Data.LocObj[location2].fuelReq = numArray7[location2];
                      if (!flag1)
                        num11 += numArray7[location2];
                    }
                    else if (evacuateMode)
                    {
                      simpleList2.Add(tid, 1);
                      int val2 = this.game.Data.LocTypeObj[type].maxSupply - this.game.Data.LocObj[location2].supply;
                      int num19 = (int) Math.Round((double) (this.game.Data.LocTypeObj[type].maxSupply * this.game.Data.LocTypeObj[type].maxEvacuate) / 100.0);
                      if (num19 < val2)
                        val2 = num19;
                      if (val2 > numArray3[location2])
                        numArray3[location2] = val2;
                      if (!flag1)
                        num10 += Math.Max(0, val2);
                      delivered1 = this.game.Data.LocTypeObj[type].maxFuel - this.game.Data.LocObj[location2].fuel;
                      int num20 = (int) Math.Round((double) (this.game.Data.LocTypeObj[type].maxFuel * this.game.Data.LocTypeObj[type].maxEvacuate) / 100.0);
                      if (num20 < delivered1)
                        delivered1 = num20;
                      if (delivered1 > numArray7[location2])
                        numArray7[location2] = delivered1;
                      if (!flag1)
                        num11 += numArray7[location2];
                    }
                  }
                }
              }
              if (simpleList2.Counter > -1)
              {
                int movetype = (int) Math.Round((double) this.game.Data.RuleVar[99]);
                int index24;
                if ((double) this.game.Data.RuleVar[455] > 0.0)
                {
                  this.game.HandyFunctionsObj.MakeFuzzyOwner(true, false, this.game.Data.Turn);
                  int mapWidth2 = this.game.Data.MapObj[index24].MapWidth;
                  for (int index25 = 0; index25 <= mapWidth2; ++index25)
                  {
                    int mapHeight = this.game.Data.MapObj[index24].MapHeight;
                    for (int index26 = 0; index26 <= mapHeight; ++index26)
                      this.game.EditObj.TempValue2[index24].Value[index25, index26] = this.game.Data.MapObj[0].HexObj[index25, index26].Regime;
                  }
                  this.game.HandyFunctionsObj.MakeFuzzyOwner(false, false, this.game.Data.Turn);
                }
                int ap = (int) Math.Round((double) this.game.Data.RuleVar[3]);
                if (depleteMode)
                  ap = this.game.Data.LocTypeObj[type].supplyRange;
                CoordList coordList1 = !(supplySourceMode | buildUpMode | evacuateMode) ? this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype, 99, ap, this.game.Data.LocObj[location2].X, this.game.Data.LocObj[location2].Y, this.game.Data.LocObj[location2].Map, allowshoredrop: true, SeaBlock: true, useTrafficRules: useTrafficRules, blockLogisticalBonus: true) : this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype, 99, ap, this.game.Data.LocObj[location2].X, this.game.Data.LocObj[location2].Y, this.game.Data.LocObj[location2].Map, allowshoredrop: true, SeaBlock: true, useTrafficRules: useTrafficRules);
                int counter2 = simpleList2.Counter;
                for (int index27 = 0; index27 <= counter2; ++index27)
                  simpleList2.Data2[index27] = !(buildUpMode | evacuateMode) ? (this.game.EditObj.TempValue[this.game.Data.UnitObj[simpleList2.Id[index27]].Map].Value[this.game.Data.UnitObj[simpleList2.Id[index27]].X, this.game.Data.UnitObj[simpleList2.Id[index27]].Y] <= ap ? 0 : 1) : (this.game.EditObj.TempValue[this.game.Data.LocObj[simpleList2.Id[index27]].Map].Value[this.game.Data.LocObj[simpleList2.Id[index27]].X, this.game.Data.LocObj[simpleList2.Id[index27]].Y] <= ap ? 0 : 1);
                int counter3 = simpleList2.Counter;
                for (int index28 = 0; index28 <= counter3; ++index28)
                {
                  string str1 = "Phase " + phase.ToString() + ". ";
                  string str2 = "Phase " + phase.ToString() + ". ";
                  if ((double) this.game.Data.RuleVar[455] > 0.0)
                  {
                    if (simpleList2.Data2[index28] == 0)
                    {
                      bool flag3 = true;
                      int num21 = 0;
                      while (flag3)
                      {
                        ++num21;
                        flag3 = false;
                        CoordList coordList2 = new CoordList();
                        Coordinate coordinate;
                        if (buildUpMode | evacuateMode)
                        {
                          coordinate.x = this.game.Data.LocObj[simpleList2.Id[index28]].X;
                          coordinate.y = this.game.Data.LocObj[simpleList2.Id[index28]].Y;
                        }
                        else
                        {
                          coordinate.x = this.game.Data.UnitObj[simpleList2.Id[index28]].X;
                          coordinate.y = this.game.Data.UnitObj[simpleList2.Id[index28]].Y;
                        }
                        if (coordinate.x == 41 & coordinate.y == 27)
                          index1 = index1;
                        coordinate.onmap = true;
                        while (coordinate.onmap)
                        {
                          coordinate = this.game.EditObj.TempCameFrom[0].Value[coordinate.x, coordinate.y];
                          if (coordinate.onmap)
                            coordList2.AddCoord(coordinate.x, coordinate.y, 0);
                        }
                        if (coordList2.counter > -1)
                        {
                          flag3 = false;
                          for (int counter4 = coordList2.counter; counter4 >= 0; counter4 += -1)
                          {
                            if (this.game.EditObj.TempValue2[index24].Value[coordList2.coord[counter4].x, coordList2.coord[counter4].y] != this.game.Data.Turn)
                            {
                              this.game.Data.MapObj[0].HexObj[coordList2.coord[counter4].x, coordList2.coord[counter4].y].FuzzyBlock = 1;
                              this.game.HandyFunctionsObj.MakeFuzzyOwner(false, false, this.game.Data.Turn);
                              coordList1 = !(supplySourceMode | buildUpMode | evacuateMode) ? this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype, 99, ap, this.game.Data.LocObj[location2].X, this.game.Data.LocObj[location2].Y, this.game.Data.LocObj[location2].Map, allowshoredrop: true, SeaBlock: true, useTrafficRules: useTrafficRules, blockLogisticalBonus: true) : this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype, 99, ap, this.game.Data.LocObj[location2].X, this.game.Data.LocObj[location2].Y, this.game.Data.LocObj[location2].Map, allowshoredrop: true, SeaBlock: true, useTrafficRules: useTrafficRules);
                              flag3 = true;
                              break;
                            }
                          }
                        }
                        if (!flag3)
                        {
                          if (buildUpMode | evacuateMode)
                          {
                            if (this.game.EditObj.TempValue[this.game.Data.LocObj[simpleList2.Id[index28]].Map].Value[this.game.Data.LocObj[simpleList2.Id[index28]].X, this.game.Data.LocObj[simpleList2.Id[index28]].Y] > ap)
                            {
                              simpleList2.Data2[index28] = 1;
                              str1 += "Enemy forces blocking supply path. ";
                              str2 += "Enemy forces blocking supply path. ";
                            }
                          }
                          else if (this.game.EditObj.TempValue[this.game.Data.UnitObj[simpleList2.Id[index28]].Map].Value[this.game.Data.UnitObj[simpleList2.Id[index28]].X, this.game.Data.UnitObj[simpleList2.Id[index28]].Y] > ap)
                          {
                            simpleList2.Data2[index28] = 1;
                            str1 += "Enemy forces blocking supply path. ";
                            str2 += "Enemy forces blocking supply path. ";
                          }
                        }
                        if (num21 > 999)
                        {
                          flag3 = false;
                          simpleList2.Data2[index28] = 1;
                        }
                      }
                    }
                    else
                    {
                      str1 += "No supply path possible. ";
                      str2 += "No supply path possible. ";
                    }
                  }
                  int index29;
                  if (simpleList2.Id[index28] == 1564)
                    index29 = index29;
                  int request1;
                  int request2;
                  if (simpleList2.Data2[index28] == 0)
                  {
                    index29 = simpleList2.Id[index28];
                    if (depleteMode)
                      delivered1 = numArray2[index29];
                    else if (supplySourceMode)
                      delivered1 = numArray2[index29];
                    else if (buildUpMode)
                      delivered1 = numArray3[location2];
                    else if (evacuateMode)
                    {
                      delivered1 = (int) Math.Round((double) (this.game.Data.LocTypeObj[type].maxSupply * this.game.Data.LocTypeObj[type].maxEvacuate) / 100.0);
                      if (this.game.Data.LocObj[location2].supply < delivered1)
                        delivered1 = this.game.Data.LocObj[location2].supply;
                    }
                    if (index29 == 124)
                      index29 = index29;
                    if (depleteMode)
                      delivered2 = numArray6[index29];
                    else if (supplySourceMode)
                      delivered2 = numArray6[index29];
                    else if (buildUpMode)
                      delivered2 = numArray7[location2];
                    else if (evacuateMode)
                    {
                      delivered2 = (int) Math.Round((double) (this.game.Data.LocTypeObj[type].maxFuel * this.game.Data.LocTypeObj[type].maxEvacuate) / 100.0);
                      if (this.game.Data.LocObj[location2].fuel < delivered2)
                        delivered2 = this.game.Data.LocObj[location2].fuel;
                    }
                    request1 = delivered1;
                    request2 = delivered2;
                    int num22 = 100;
                    string str3;
                    string str4;
                    if (buildUpMode | evacuateMode)
                    {
                      if ((double) this.game.EditObj.TempValue[this.game.Data.LocObj[simpleList2.Id[index28]].Map].Value[this.game.Data.LocObj[simpleList2.Id[index28]].X, this.game.Data.LocObj[simpleList2.Id[index28]].Y] > (double) ap * ((double) this.game.Data.RuleVar[51] / (double) this.game.Data.RuleVar[3]))
                        num22 = 75;
                      if ((double) this.game.EditObj.TempValue[this.game.Data.LocObj[simpleList2.Id[index28]].Map].Value[this.game.Data.LocObj[simpleList2.Id[index28]].X, this.game.Data.LocObj[simpleList2.Id[index28]].Y] > (double) ap * ((double) this.game.Data.RuleVar[52] / (double) this.game.Data.RuleVar[3]))
                        num22 = 50;
                      if ((double) this.game.EditObj.TempValue[this.game.Data.LocObj[simpleList2.Id[index28]].Map].Value[this.game.Data.LocObj[simpleList2.Id[index28]].X, this.game.Data.LocObj[simpleList2.Id[index28]].Y] > (double) ap * ((double) this.game.Data.RuleVar[53] / (double) this.game.Data.RuleVar[3]))
                        num22 = 25;
                      if (this.game.EditObj.TempValue[this.game.Data.LocObj[simpleList2.Id[index28]].Map].Value[this.game.Data.LocObj[simpleList2.Id[index28]].X, this.game.Data.LocObj[simpleList2.Id[index28]].Y] > ap)
                        num22 = 0;
                      str3 = str1 + "Logistics percentage based on " + this.game.EditObj.TempValue[this.game.Data.LocObj[simpleList2.Id[index28]].Map].Value[this.game.Data.LocObj[simpleList2.Id[index28]].X, this.game.Data.LocObj[simpleList2.Id[index28]].Y].ToString() + " AP distance is " + num22.ToString() + "%. ";
                      str4 = str2 + "Logistics percentage based on " + this.game.EditObj.TempValue[this.game.Data.LocObj[simpleList2.Id[index28]].Map].Value[this.game.Data.LocObj[simpleList2.Id[index28]].X, this.game.Data.LocObj[simpleList2.Id[index28]].Y].ToString() + " AP distance is " + num22.ToString() + "%. ";
                    }
                    else
                    {
                      if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[simpleList2.Id[index28]].Map].Value[this.game.Data.UnitObj[simpleList2.Id[index28]].X, this.game.Data.UnitObj[simpleList2.Id[index28]].Y] > (double) ap * ((double) this.game.Data.RuleVar[51] / (double) this.game.Data.RuleVar[3]))
                        num22 = 75;
                      if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[simpleList2.Id[index28]].Map].Value[this.game.Data.UnitObj[simpleList2.Id[index28]].X, this.game.Data.UnitObj[simpleList2.Id[index28]].Y] > (double) ap * ((double) this.game.Data.RuleVar[52] / (double) this.game.Data.RuleVar[3]))
                        num22 = 50;
                      if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[simpleList2.Id[index28]].Map].Value[this.game.Data.UnitObj[simpleList2.Id[index28]].X, this.game.Data.UnitObj[simpleList2.Id[index28]].Y] > (double) ap * ((double) this.game.Data.RuleVar[53] / (double) this.game.Data.RuleVar[3]))
                        num22 = 25;
                      if (this.game.EditObj.TempValue[this.game.Data.UnitObj[simpleList2.Id[index28]].Map].Value[this.game.Data.UnitObj[simpleList2.Id[index28]].X, this.game.Data.UnitObj[simpleList2.Id[index28]].Y] > ap)
                        num22 = 0;
                      str3 = str1 + "Logistics percentage based on " + this.game.EditObj.TempValue[this.game.Data.UnitObj[simpleList2.Id[index28]].Map].Value[this.game.Data.UnitObj[simpleList2.Id[index28]].X, this.game.Data.UnitObj[simpleList2.Id[index28]].Y].ToString() + " AP distance is " + num22.ToString() + "%. ";
                      str4 = str2 + "Logistics percentage based on " + this.game.EditObj.TempValue[this.game.Data.UnitObj[simpleList2.Id[index28]].Map].Value[this.game.Data.UnitObj[simpleList2.Id[index28]].X, this.game.Data.UnitObj[simpleList2.Id[index28]].Y].ToString() + " AP distance is " + num22.ToString() + "%. ";
                    }
                    if ((double) this.game.Data.RuleVar[434] > 0.0 & (depleteMode | supplySourceMode))
                      num22 = this.game.Data.UnitObj[index29].SOSupReqPercent > num22 ? (int) Math.Round(Math.Floor((double) (100 * num22) / (double) this.game.Data.UnitObj[index29].SOSupReqPercent)) : 100;
                    string str5 = str3 + "Logistics percentage after Standing Order modifier is " + num22.ToString() + "%. ";
                    string str6 = str4 + "Logistics percentage after Standing Order modifier is " + num22.ToString() + "%. ";
                    delivered1 = (int) Math.Round(Conversion.Int(Math.Floor((double) (delivered1 * num22) / 100.0)));
                    if ((double) this.game.Data.RuleVar[489] > 0.0 & supplySourceMode & delivered2 > 0)
                    {
                      if (phase == 1)
                      {
                        if (num22 >= 100 | num22 < 1)
                          numArray9[index29] = -1;
                        else if (new Random(index29 * (int) Math.Round((double) this.game.Data.GameID / 10000.0) * this.game.Data.Round).Next(0, 100) < num22)
                        {
                          numArray9[index29] = 100;
                          str6 += "Binary fuel delivery rule roll succesfull. ";
                        }
                        else
                        {
                          str6 += "Binary fuel delivery rule roll failed. ";
                          numArray9[index29] = 0;
                        }
                      }
                      else if (numArray9[index29] == 0)
                        index24 = index24;
                      delivered2 = numArray9[index29] != -1 ? (int) Math.Round(Conversion.Int(Math.Floor((double) (delivered2 * numArray9[index29]) / 100.0))) : (int) Math.Round(Conversion.Int(Math.Floor((double) (delivered2 * num22) / 100.0)));
                    }
                    else
                      delivered2 = (int) Math.Round(Conversion.Int(Math.Floor((double) (delivered2 * num22) / 100.0)));
                    if (depleteMode)
                      delivered1 = (int) Math.Round(Math.Ceiling((double) (delivered1 * phase) / (double) num8)) - numArray1[index29];
                    else if (supplySourceMode)
                      delivered1 = (int) Math.Round(Math.Ceiling((double) (delivered1 * phase) / (double) num8)) - numArray1[index29];
                    else if (buildUpMode)
                      delivered1 = (int) Math.Round(Math.Ceiling((double) (delivered1 * phase) / (double) num8)) - numArray4[location2];
                    else if (evacuateMode)
                      delivered1 = (int) Math.Round(Math.Ceiling((double) (delivered1 * phase) / (double) num8)) - numArray4[location2];
                    if (depleteMode)
                      delivered2 = (int) Math.Round(Math.Ceiling((double) (delivered2 * phase) / (double) num8)) - numArray5[index29];
                    else if (supplySourceMode)
                      delivered2 = (int) Math.Round(Math.Ceiling((double) (delivered2 * phase) / (double) num8)) - numArray5[index29];
                    else if (buildUpMode)
                      delivered2 = (int) Math.Round(Math.Ceiling((double) (delivered2 * phase) / (double) num8)) - numArray8[location2];
                    else if (evacuateMode)
                      delivered2 = (int) Math.Round(Math.Ceiling((double) (delivered2 * phase) / (double) num8)) - numArray8[location2];
                    if (depleteMode)
                      request1 = (int) Math.Round(Math.Ceiling((double) (request1 * phase) / (double) num8)) - numArray1[index29];
                    else if (supplySourceMode)
                      request1 = (int) Math.Round(Math.Ceiling((double) (request1 * phase) / (double) num8)) - numArray1[index29];
                    else if (buildUpMode)
                      request1 = (int) Math.Round(Math.Ceiling((double) (request1 * phase) / (double) num8)) - numArray4[location2];
                    else if (evacuateMode)
                      request1 = (int) Math.Round(Math.Ceiling((double) (request1 * phase) / (double) num8)) - numArray4[location2];
                    if (depleteMode)
                      request2 = (int) Math.Round(Math.Ceiling((double) (request2 * phase) / (double) num8)) - numArray5[index29];
                    else if (supplySourceMode)
                      request2 = (int) Math.Round(Math.Ceiling((double) (request2 * phase) / (double) num8)) - numArray5[index29];
                    else if (buildUpMode)
                      request2 = (int) Math.Round(Math.Ceiling((double) (request2 * phase) / (double) num8)) - numArray8[location2];
                    else if (evacuateMode)
                      request2 = (int) Math.Round(Math.Ceiling((double) (request2 * phase) / (double) num8)) - numArray8[location2];
                    if (request1 > 0)
                      str5 = str5 + "Request is " + request1.ToString() + " supply. ";
                    if (request2 > 0)
                      str6 = str6 + "Request is " + request2.ToString() + " fuel. ";
                    if (depleteMode | supplySourceMode)
                    {
                      if (this.game.Data.UnitObj[index29].Supply < 0)
                        this.game.Data.UnitObj[index29].Supply = 0;
                      if (this.game.Data.UnitObj[index29].Fuel < 0)
                        this.game.Data.UnitObj[index29].Fuel = 0;
                    }
                    if (depleteMode | supplySourceMode)
                    {
                      int num23 = (int) Math.Round((double) (int) Math.Round(Math.Ceiling((double) ((this.game.Data.LocObj[location2].supply + this.game.Data.LocObj[location2].supplyOutUnits) * phase) / (double) num8)) - (double) (this.game.Data.LocObj[location2].supplyOutUnits * phase) / (double) num8);
                      if (num23 > this.game.Data.LocObj[location2].supply)
                        num23 = this.game.Data.LocObj[location2].supply;
                      if (num23 < 0)
                        num23 = 0;
                      if (num23 < delivered1)
                        delivered1 = num23;
                      index1 = (int) Math.Round((double) (int) Math.Round(Math.Ceiling((double) ((this.game.Data.LocObj[location2].fuel + this.game.Data.LocObj[location2].fuelOutUnits) * phase) / (double) num8)) - (double) (this.game.Data.LocObj[location2].fuelOutUnits * phase) / (double) num8);
                      if (index1 > this.game.Data.LocObj[location2].fuel)
                        index1 = this.game.Data.LocObj[location2].fuel;
                      if (index1 < 0)
                        index1 = 0;
                      if (index1 < delivered2)
                        delivered2 = index1;
                    }
                    if (buildUpMode)
                    {
                      int supply = this.game.Data.LocObj[index29].supply;
                      if (supply < delivered1)
                        delivered1 = supply;
                      int fuel = this.game.Data.LocObj[index29].fuel;
                      if (fuel < delivered2)
                        delivered2 = fuel;
                    }
                    if (0 > delivered1)
                      delivered1 = 0;
                    if (0 > delivered2)
                      delivered2 = 0;
                    if (delivered1 > 0 | delivered2 > 0)
                    {
                      index1 = delivered1;
                      int num24 = (int) Math.Round(Math.Floor((double) index1 * (double) this.game.Data.RuleVar[33]));
                      if ((double) this.game.Data.RuleVar[33] < 1.0 && index1 > (int) Math.Round((double) ((float) num24 / this.game.Data.RuleVar[33])))
                      {
                        int num25 = index1 - (int) Math.Round((double) ((float) num24 / this.game.Data.RuleVar[33]));
                        int num26 = (int) Math.Round(Math.Ceiling(1.0 / (double) this.game.Data.RuleVar[33]));
                        if (DrawMod.RandyNumber.Next(1, num26 + 1) <= num25)
                          ++num24;
                      }
                      int num27 = num24;
                      int num28 = 0;
                      if (delivered2 > 0)
                      {
                        if ((double) this.game.Data.RuleVar[488] > 0.0)
                        {
                          index1 = delivered2;
                          num28 = (int) Math.Round(Math.Floor((double) index1 * (double) this.game.Data.RuleVar[488]));
                          if ((double) this.game.Data.RuleVar[488] < 1.0 && index1 > (int) Math.Round((double) ((float) num28 / this.game.Data.RuleVar[488])))
                          {
                            int num29 = index1 - (int) Math.Round((double) ((float) num28 / this.game.Data.RuleVar[488]));
                            int num30 = (int) Math.Round(Math.Ceiling(1.0 / (double) this.game.Data.RuleVar[488]));
                            if (DrawMod.RandyNumber.Next(1, num30 + 1) <= num29)
                              ++num28;
                          }
                        }
                        else
                        {
                          index1 = delivered2;
                          num28 = (int) Math.Round(Math.Floor((double) index1 * (double) this.game.Data.RuleVar[33]));
                          if ((double) this.game.Data.RuleVar[33] < 1.0 && index1 > (int) Math.Round((double) ((float) num28 / this.game.Data.RuleVar[33])))
                          {
                            int num31 = index1 - (int) Math.Round((double) ((float) num28 / this.game.Data.RuleVar[33]));
                            int num32 = (int) Math.Round(Math.Ceiling(1.0 / (double) this.game.Data.RuleVar[33]));
                            if (DrawMod.RandyNumber.Next(1, num32 + 1) <= num31)
                              ++num28;
                          }
                        }
                      }
                      int num33 = num27 + num28;
                      if (delivered1 > request1)
                        delivered1 = request1;
                      if (delivered2 > request2)
                        delivered2 = request2;
                      if (delivered1 > 0)
                      {
                        string str7 = str5 + delivered1.ToString() + " supply has been given ";
                        if (depleteMode)
                        {
                          string texty = str7 + "from supply base " + this.game.Data.LocObj[location2].X.ToString() + "," + this.game.Data.LocObj[location2].Y.ToString() + ". ";
                          int[] numArray15 = numArray1;
                          int[] numArray16 = numArray15;
                          int index30 = index29;
                          int index31 = index30;
                          int num34 = numArray15[index30] + delivered1;
                          numArray16[index31] = num34;
                          this.game.Data.UnitObj[index29].Supply += delivered1;
                          UnitClass[] unitObj = this.game.Data.UnitObj;
                          UnitClass[] unitClassArray = unitObj;
                          int index32 = index29;
                          int index33 = index32;
                          unitClassArray[index33].supplyBaseSupplyIn = unitObj[index32].supplyBaseSupplyIn + delivered1;
                          LocationClass[] locObj = this.game.Data.LocObj;
                          LocationClass[] locationClassArray = locObj;
                          int index34 = location2;
                          int index35 = index34;
                          locationClassArray[index35].supplyOutUnits = locObj[index34].supplyOutUnits + delivered1;
                          this.game.Data.LocObj[location2].supply -= delivered1;
                          num12 += delivered1;
                          int[] numArray17 = numArray10;
                          int[] numArray18 = numArray17;
                          int index36 = location2;
                          int index37 = index36;
                          int num35 = numArray17[index36] + delivered1;
                          numArray18[index37] = num35;
                          if (phase > 2 && this.game.Data.UnitObj[index29].supplyX == -1 & this.game.EditObj.TempCameFrom[0].Value[this.game.Data.UnitObj[index29].X, this.game.Data.UnitObj[index29].Y].onmap)
                          {
                            this.game.Data.UnitObj[index29].supplyX = this.game.EditObj.TempCameFrom[0].Value[this.game.Data.UnitObj[index29].X, this.game.Data.UnitObj[index29].Y].x;
                            this.game.Data.UnitObj[index29].supplyY = this.game.EditObj.TempCameFrom[0].Value[this.game.Data.UnitObj[index29].X, this.game.Data.UnitObj[index29].Y].y;
                          }
                          this.AddSupplyLog(0, this.game.Data.LocObj[location2].ID, this.game.Data.UnitObj[index29].Historical * 10 + this.game.Data.UnitObj[index29].HistoricalSubPart, 0, 7, phase, request1, delivered1, this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[simpleList2.Id[index28]].X, this.game.Data.UnitObj[simpleList2.Id[index28]].Y], texty);
                        }
                        else if (supplySourceMode)
                        {
                          string texty = str7 + "from supply source " + this.game.Data.LocObj[location2].X.ToString() + "," + this.game.Data.LocObj[location2].Y.ToString() + ". ";
                          if (this.game.Data.UnitObj[index29].supplyX == -1 & this.game.EditObj.TempCameFrom[0].Value[this.game.Data.UnitObj[index29].X, this.game.Data.UnitObj[index29].Y].onmap)
                          {
                            this.game.Data.UnitObj[index29].supplyX = this.game.EditObj.TempCameFrom[0].Value[this.game.Data.UnitObj[index29].X, this.game.Data.UnitObj[index29].Y].x;
                            this.game.Data.UnitObj[index29].supplyY = this.game.EditObj.TempCameFrom[0].Value[this.game.Data.UnitObj[index29].X, this.game.Data.UnitObj[index29].Y].y;
                          }
                          int[] numArray19 = numArray1;
                          int[] numArray20 = numArray19;
                          int index38 = index29;
                          int index39 = index38;
                          int num36 = numArray19[index38] + delivered1;
                          numArray20[index39] = num36;
                          num12 += delivered1;
                          int[] numArray21 = numArray10;
                          int[] numArray22 = numArray21;
                          int index40 = location2;
                          int index41 = index40;
                          int num37 = numArray21[index40] + delivered1;
                          numArray22[index41] = num37;
                          this.game.Data.UnitObj[index29].Supply += delivered1;
                          UnitClass[] unitObj = this.game.Data.UnitObj;
                          UnitClass[] unitClassArray = unitObj;
                          int index42 = index29;
                          int index43 = index42;
                          unitClassArray[index43].SupplyIn = unitObj[index42].SupplyIn + delivered1;
                          LocationClass[] locObj = this.game.Data.LocObj;
                          LocationClass[] locationClassArray = locObj;
                          int index44 = location2;
                          int index45 = index44;
                          locationClassArray[index45].supplyOutUnits = locObj[index44].supplyOutUnits + delivered1;
                          this.game.Data.LocObj[location2].supply -= delivered1;
                          this.AddSupplyLog(0, this.game.Data.LocObj[location2].ID, this.game.Data.UnitObj[index29].Historical * 10 + this.game.Data.UnitObj[index29].HistoricalSubPart, 0, 1, phase, request1, delivered1, this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[simpleList2.Id[index28]].X, this.game.Data.UnitObj[simpleList2.Id[index28]].Y], texty);
                        }
                        else if (evacuateMode)
                        {
                          string texty = str7 + "from evacuation of supply base " + this.game.Data.LocObj[location2].X.ToString() + "," + this.game.Data.LocObj[location2].Y.ToString() + ". ";
                          int[] numArray23 = numArray4;
                          int[] numArray24 = numArray23;
                          int index46 = location2;
                          int index47 = index46;
                          int num38 = numArray23[index46] + delivered1;
                          numArray24[index47] = num38;
                          this.game.Data.LocObj[index29].supply += delivered1;
                          LocationClass[] locObj5 = this.game.Data.LocObj;
                          LocationClass[] locationClassArray5 = locObj5;
                          int index48 = index29;
                          int index49 = index48;
                          locationClassArray5[index49].supplyEvacuated = locObj5[index48].supplyEvacuated + delivered1;
                          LocationClass[] locObj6 = this.game.Data.LocObj;
                          LocationClass[] locationClassArray6 = locObj6;
                          int index50 = location2;
                          int index51 = index50;
                          locationClassArray6[index51].supplyEvacuated = locObj6[index50].supplyEvacuated + delivered1;
                          this.game.Data.LocObj[location2].supply -= delivered1;
                          this.AddSupplyLog(0, this.game.Data.LocObj[location2].ID, this.game.Data.LocObj[index29].ID, 0, 5, phase, request1, delivered1, this.game.EditObj.TempValue[0].Value[this.game.Data.LocObj[simpleList2.Id[index28]].X, this.game.Data.LocObj[simpleList2.Id[index28]].Y], texty);
                          num12 += delivered1;
                          int[] numArray25 = numArray10;
                          int[] numArray26 = numArray25;
                          int index52 = location2;
                          int index53 = index52;
                          int num39 = numArray25[index52] + delivered1;
                          numArray26[index53] = num39;
                          int[] numArray27 = numArray12;
                          int[] numArray28 = numArray27;
                          int index54 = index29;
                          int index55 = index54;
                          int num40 = numArray27[index54] + delivered1;
                          numArray28[index55] = num40;
                        }
                        else if (buildUpMode)
                        {
                          string texty = str7 + "from supply source " + this.game.Data.LocObj[index29].X.ToString() + "," + this.game.Data.LocObj[index29].Y.ToString() + ". ";
                          int[] numArray29 = numArray4;
                          int[] numArray30 = numArray29;
                          int index56 = location2;
                          int index57 = index56;
                          int num41 = numArray29[index56] + delivered1;
                          numArray30[index57] = num41;
                          this.game.Data.LocObj[index29].supply -= delivered1;
                          LocationClass[] locObj7 = this.game.Data.LocObj;
                          LocationClass[] locationClassArray7 = locObj7;
                          int index58 = index29;
                          int index59 = index58;
                          locationClassArray7[index59].supplyOutBases = locObj7[index58].supplyOutBases + delivered1;
                          LocationClass[] locObj8 = this.game.Data.LocObj;
                          LocationClass[] locationClassArray8 = locObj8;
                          int index60 = location2;
                          int index61 = index60;
                          locationClassArray8[index61].supplyIn = locObj8[index60].supplyIn + delivered1;
                          this.game.Data.LocObj[location2].supply += delivered1;
                          num12 += delivered1;
                          this.AddSupplyLog(0, this.game.Data.LocObj[location2].ID, this.game.Data.LocObj[index29].ID, 0, 11, phase, request1, delivered1, this.game.EditObj.TempValue[0].Value[this.game.Data.LocObj[simpleList2.Id[index28]].X, this.game.Data.LocObj[simpleList2.Id[index28]].Y], texty);
                          int[] numArray31 = numArray10;
                          int[] numArray32 = numArray31;
                          int index62 = index29;
                          int index63 = index62;
                          int num42 = numArray31[index62] + delivered1;
                          numArray32[index63] = num42;
                          int[] numArray33 = numArray12;
                          int[] numArray34 = numArray33;
                          int index64 = location2;
                          int index65 = index64;
                          int num43 = numArray33[index64] + delivered1;
                          numArray34[index65] = num43;
                        }
                      }
                      if (delivered2 > 0)
                      {
                        string str8 = str6 + delivered2.ToString() + " fuel has been given ";
                        if (depleteMode)
                        {
                          string texty = str8 + "from supply base " + this.game.Data.LocObj[location2].X.ToString() + "," + this.game.Data.LocObj[location2].Y.ToString() + ". ";
                          int[] numArray35 = numArray5;
                          int[] numArray36 = numArray35;
                          int index66 = index29;
                          int index67 = index66;
                          int num44 = numArray35[index66] + delivered2;
                          numArray36[index67] = num44;
                          this.game.Data.UnitObj[index29].Fuel += delivered2;
                          UnitClass[] unitObj = this.game.Data.UnitObj;
                          UnitClass[] unitClassArray = unitObj;
                          int index68 = index29;
                          int index69 = index68;
                          unitClassArray[index69].supplyBaseFuelIn = unitObj[index68].supplyBaseFuelIn + delivered2;
                          LocationClass[] locObj = this.game.Data.LocObj;
                          LocationClass[] locationClassArray = locObj;
                          int index70 = location2;
                          int index71 = index70;
                          locationClassArray[index71].fuelOutUnits = locObj[index70].fuelOutUnits + delivered2;
                          num13 += delivered2;
                          this.game.Data.LocObj[location2].fuel -= delivered2;
                          this.AddSupplyLog(0, this.game.Data.LocObj[location2].ID, this.game.Data.UnitObj[index29].Historical * 10 + this.game.Data.UnitObj[index29].HistoricalSubPart, 0, 8, phase, request2, delivered2, this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[simpleList2.Id[index28]].X, this.game.Data.UnitObj[simpleList2.Id[index28]].Y], texty);
                          int[] numArray37 = numArray11;
                          int[] numArray38 = numArray37;
                          int index72 = location2;
                          int index73 = index72;
                          int num45 = numArray37[index72] + delivered2;
                          numArray38[index73] = num45;
                        }
                        else if (supplySourceMode)
                        {
                          string texty = str8 + "from supply source " + this.game.Data.LocObj[location2].X.ToString() + "," + this.game.Data.LocObj[location2].Y.ToString() + ". ";
                          int[] numArray39 = numArray5;
                          int[] numArray40 = numArray39;
                          int index74 = index29;
                          int index75 = index74;
                          int num46 = numArray39[index74] + delivered2;
                          numArray40[index75] = num46;
                          this.game.Data.UnitObj[index29].Fuel += delivered2;
                          UnitClass[] unitObj = this.game.Data.UnitObj;
                          UnitClass[] unitClassArray = unitObj;
                          int index76 = index29;
                          int index77 = index76;
                          unitClassArray[index77].FuelReceived = unitObj[index76].FuelReceived + delivered2;
                          LocationClass[] locObj = this.game.Data.LocObj;
                          LocationClass[] locationClassArray = locObj;
                          int index78 = location2;
                          int index79 = index78;
                          locationClassArray[index79].fuelOutUnits = locObj[index78].fuelOutUnits + delivered2;
                          num13 += delivered2;
                          this.game.Data.LocObj[location2].fuel -= delivered2;
                          this.AddSupplyLog(0, this.game.Data.LocObj[location2].ID, this.game.Data.UnitObj[index29].Historical * 10 + this.game.Data.UnitObj[index29].HistoricalSubPart, 0, 2, phase, request2, delivered2, this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[simpleList2.Id[index28]].X, this.game.Data.UnitObj[simpleList2.Id[index28]].Y], texty);
                          int[] numArray41 = numArray11;
                          int[] numArray42 = numArray41;
                          int index80 = location2;
                          int index81 = index80;
                          int num47 = numArray41[index80] + delivered2;
                          numArray42[index81] = num47;
                        }
                        else if (evacuateMode)
                        {
                          string texty = str8 + "from evacuation of supply base " + this.game.Data.LocObj[location2].X.ToString() + "," + this.game.Data.LocObj[location2].Y.ToString() + ". ";
                          int[] numArray43 = numArray8;
                          int[] numArray44 = numArray43;
                          int index82 = location2;
                          int index83 = index82;
                          int num48 = numArray43[index82] + delivered2;
                          numArray44[index83] = num48;
                          this.game.Data.LocObj[index29].fuel += delivered2;
                          LocationClass[] locObj9 = this.game.Data.LocObj;
                          LocationClass[] locationClassArray9 = locObj9;
                          int index84 = index29;
                          int index85 = index84;
                          locationClassArray9[index85].fuelEvacuated = locObj9[index84].fuelEvacuated + delivered2;
                          LocationClass[] locObj10 = this.game.Data.LocObj;
                          LocationClass[] locationClassArray10 = locObj10;
                          int index86 = location2;
                          int index87 = index86;
                          locationClassArray10[index87].fuelEvacuated = locObj10[index86].fuelEvacuated + delivered2;
                          num13 += delivered2;
                          this.game.Data.LocObj[location2].fuel -= delivered2;
                          this.AddSupplyLog(0, this.game.Data.LocObj[location2].ID, this.game.Data.LocObj[index29].ID, 0, 6, phase, request2, delivered2, this.game.EditObj.TempValue[0].Value[this.game.Data.LocObj[simpleList2.Id[index28]].X, this.game.Data.LocObj[simpleList2.Id[index28]].Y], texty);
                          int[] numArray45 = numArray11;
                          int[] numArray46 = numArray45;
                          int index88 = location2;
                          int index89 = index88;
                          int num49 = numArray45[index88] + delivered2;
                          numArray46[index89] = num49;
                          int[] numArray47 = numArray13;
                          int[] numArray48 = numArray47;
                          int index90 = index29;
                          int index91 = index90;
                          int num50 = numArray47[index90] + delivered2;
                          numArray48[index91] = num50;
                        }
                        else if (buildUpMode)
                        {
                          string texty = str8 + "from supply source " + this.game.Data.LocObj[index29].X.ToString() + "," + this.game.Data.LocObj[index29].Y.ToString() + ". ";
                          int[] numArray49 = numArray8;
                          int[] numArray50 = numArray49;
                          int index92 = location2;
                          int index93 = index92;
                          int num51 = numArray49[index92] + delivered2;
                          numArray50[index93] = num51;
                          this.game.Data.LocObj[index29].fuel -= delivered2;
                          LocationClass[] locObj11 = this.game.Data.LocObj;
                          LocationClass[] locationClassArray11 = locObj11;
                          int index94 = index29;
                          int index95 = index94;
                          locationClassArray11[index95].fuelOutBases = locObj11[index94].fuelOutBases + delivered2;
                          LocationClass[] locObj12 = this.game.Data.LocObj;
                          LocationClass[] locationClassArray12 = locObj12;
                          int index96 = location2;
                          int index97 = index96;
                          locationClassArray12[index97].fuelIn = locObj12[index96].fuelIn + delivered2;
                          num13 += delivered2;
                          this.game.Data.LocObj[location2].fuel += delivered2;
                          this.AddSupplyLog(0, this.game.Data.LocObj[location2].ID, this.game.Data.LocObj[index29].ID, 0, 12, phase, request2, delivered2, this.game.EditObj.TempValue[0].Value[this.game.Data.LocObj[simpleList2.Id[index28]].X, this.game.Data.LocObj[simpleList2.Id[index28]].Y], texty);
                          int[] numArray51 = numArray11;
                          int[] numArray52 = numArray51;
                          int index98 = index29;
                          int index99 = index98;
                          int num52 = numArray51[index98] + delivered2;
                          numArray52[index99] = num52;
                          int[] numArray53 = numArray13;
                          int[] numArray54 = numArray53;
                          int index100 = location2;
                          int index101 = index100;
                          int num53 = numArray53[index100] + delivered2;
                          numArray54[index101] = num53;
                        }
                      }
                      if (useTrafficRules & num33 > 0)
                      {
                        Coordinate coordinate1;
                        if (evacuateMode | buildUpMode)
                        {
                          coordinate1.x = this.game.Data.LocObj[index29].X;
                          coordinate1.y = this.game.Data.LocObj[index29].Y;
                        }
                        else
                        {
                          coordinate1.x = this.game.Data.UnitObj[index29].X;
                          coordinate1.y = this.game.Data.UnitObj[index29].Y;
                        }
                        bool flag4 = false;
                        int index102 = 0;
                        while (this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y].onmap)
                        {
                          int num54 = index102 + 1;
                          Coordinate coordinate2 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                          index1 = this.game.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0) - 1;
                          int index103 = index1 + 3;
                          if (index103 > 5)
                            index103 -= 6;
                          int liSpoint1 = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[index1];
                          int liSpoint2 = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints[index103];
                          int[] liSpoints1 = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints;
                          int[] numArray55 = liSpoints1;
                          int index104 = index1;
                          int index105 = index104;
                          int num55 = liSpoints1[index104] + num33;
                          numArray55[index105] = num55;
                          int[] liSpoints2 = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints;
                          int[] numArray56 = liSpoints2;
                          int index106 = index103;
                          int index107 = index106;
                          int num56 = liSpoints2[index106] + num33;
                          numArray56[index107] = num56;
                          int index108 = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[index1];
                          if (index108 > -1 && this.game.Data.RoadTypeObj[index108].trafficPoints > 0)
                          {
                            int num57 = (int) Math.Round(Math.Floor((double) (liSpoint1 * 1) / (double) this.game.Data.RoadTypeObj[index108].trafficPoints));
                            if ((int) Math.Round(Math.Floor((double) (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[index1] * 1) / (double) this.game.Data.RoadTypeObj[index108].trafficPoints)) > num57)
                              flag4 = true;
                          }
                          index102 = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].RoadType[index103];
                          if (index102 > -1 && this.game.Data.RoadTypeObj[index102].trafficPoints > 0)
                          {
                            int num58 = (int) Math.Round(Math.Floor((double) (liSpoint2 * 1) / (double) this.game.Data.RoadTypeObj[index102].trafficPoints));
                            if ((int) Math.Round(Math.Floor((double) (this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints[index103] * 1) / (double) this.game.Data.RoadTypeObj[index102].trafficPoints)) > num58)
                              flag4 = true;
                          }
                          coordinate1 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                          if (index102 > 999)
                            break;
                        }
                        if (flag4)
                          coordList1 = !(supplySourceMode | buildUpMode | evacuateMode) ? this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype, 99, ap, this.game.Data.LocObj[location2].X, this.game.Data.LocObj[location2].Y, this.game.Data.LocObj[location2].Map, allowshoredrop: true, SeaBlock: true, useTrafficRules: useTrafficRules, blockLogisticalBonus: true) : this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype, 99, ap, this.game.Data.LocObj[location2].X, this.game.Data.LocObj[location2].Y, this.game.Data.LocObj[location2].Map, allowshoredrop: true, SeaBlock: true, useTrafficRules: useTrafficRules);
                      }
                    }
                  }
                  else
                  {
                    if (depleteMode)
                      delivered1 = numArray2[index29];
                    else if (supplySourceMode)
                      delivered1 = numArray2[index29];
                    else if (buildUpMode)
                      delivered1 = numArray3[location2];
                    else if (evacuateMode)
                      delivered1 = numArray3[location2];
                    if (index29 == 124)
                      index29 = index29;
                    if (depleteMode)
                      delivered2 = numArray6[index29];
                    else if (supplySourceMode)
                      delivered2 = numArray6[index29];
                    else if (buildUpMode)
                      delivered2 = numArray7[location2];
                    else if (evacuateMode)
                      delivered2 = numArray7[location2];
                    request1 = delivered1;
                    request2 = delivered2;
                    string texty1 = str1 + "Nothing delivered. ";
                    string texty2 = str2 + "Nothing delivered. ";
                    if (request2 > 0)
                    {
                      if (depleteMode)
                        this.AddSupplyLog(0, this.game.Data.LocObj[location2].ID, this.game.Data.UnitObj[index29].Historical, 0, 8, phase, request2, delivered2, this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[simpleList2.Id[index28]].X, this.game.Data.UnitObj[simpleList2.Id[index28]].Y], texty2);
                      else if (supplySourceMode)
                        this.AddSupplyLog(0, this.game.Data.LocObj[location2].ID, this.game.Data.UnitObj[index29].Historical, 0, 2, phase, request2, delivered2, this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[simpleList2.Id[index28]].X, this.game.Data.UnitObj[simpleList2.Id[index28]].Y], texty2);
                      else if (evacuateMode)
                        this.AddSupplyLog(0, this.game.Data.LocObj[location2].ID, this.game.Data.LocObj[index29].ID, 0, 6, phase, request2, delivered2, this.game.EditObj.TempValue[0].Value[this.game.Data.LocObj[simpleList2.Id[index28]].X, this.game.Data.LocObj[simpleList2.Id[index28]].Y], texty2);
                      else if (buildUpMode)
                        this.AddSupplyLog(0, this.game.Data.LocObj[location2].ID, this.game.Data.LocObj[index29].ID, 0, 12, phase, request2, delivered2, this.game.EditObj.TempValue[0].Value[this.game.Data.LocObj[simpleList2.Id[index28]].X, this.game.Data.LocObj[simpleList2.Id[index28]].Y], texty2);
                    }
                    if (request1 > 0)
                    {
                      if (depleteMode)
                        this.AddSupplyLog(0, this.game.Data.LocObj[location2].ID, this.game.Data.UnitObj[index29].Historical, 0, 8, phase, request1, delivered1, this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[simpleList2.Id[index28]].X, this.game.Data.UnitObj[simpleList2.Id[index28]].Y], texty1);
                      else if (supplySourceMode)
                        this.AddSupplyLog(0, this.game.Data.LocObj[location2].ID, this.game.Data.UnitObj[index29].Historical, 0, 2, phase, request1, delivered1, this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[simpleList2.Id[index28]].X, this.game.Data.UnitObj[simpleList2.Id[index28]].Y], texty1);
                      else if (evacuateMode)
                        this.AddSupplyLog(0, this.game.Data.LocObj[location2].ID, this.game.Data.LocObj[index29].ID, 0, 6, phase, request1, delivered1, this.game.EditObj.TempValue[0].Value[this.game.Data.LocObj[simpleList2.Id[index28]].X, this.game.Data.LocObj[simpleList2.Id[index28]].Y], texty1);
                      else if (buildUpMode)
                        this.AddSupplyLog(0, this.game.Data.LocObj[location2].ID, this.game.Data.LocObj[index29].ID, 0, 12, phase, request1, delivered1, this.game.EditObj.TempValue[0].Value[this.game.Data.LocObj[simpleList2.Id[index28]].X, this.game.Data.LocObj[simpleList2.Id[index28]].Y], texty1);
                    }
                  }
                }
              }
              flag1 = true;
            }
          }
        }
        if (!((double) this.game.Data.RuleVar[957] > 0.0 & (double) this.game.Data.RuleVar[499] > 0.0))
          return;
        int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[957]));
        int num59 = 0;
        int num60 = 0;
        int num61 = 0;
        int num62 = 0;
        int locCounter4 = this.game.Data.LocCounter;
        for (int index109 = 0; index109 <= locCounter4; ++index109)
        {
          if (numArray10[index109] > 0)
            num59 += numArray10[index109];
          if (numArray11[index109] > 0)
            num60 += numArray11[index109];
          if (numArray12[index109] > 0)
            num61 += numArray12[index109];
          if (numArray13[index109] > 0)
            num62 += numArray13[index109];
          if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index109].X, this.game.Data.LocObj[index109].Y].Regime == this.game.Data.Turn && this.game.Data.LocTypeObj[this.game.Data.LocObj[index109].Type].isSupplySource)
          {
            if (supplySourceMode)
              this.game.Data.StringListObj[stringListById].AddRowWithData("Supply source " + this.game.Data.LocObj[index109].X.ToString() + "," + this.game.Data.LocObj[index109].Y.ToString() + " : Supply", this.game.Data.Turn.ToString(), "Sent to units", this.game.Data.Round.ToString(), numArray10[index109].ToString());
            if (buildUpMode)
              this.game.Data.StringListObj[stringListById].AddRowWithData("Supply source " + this.game.Data.LocObj[index109].X.ToString() + "," + this.game.Data.LocObj[index109].Y.ToString() + " : Supply", this.game.Data.Turn.ToString(), "Sent to supply base", this.game.Data.Round.ToString(), numArray10[index109].ToString());
            if (supplySourceMode)
              this.game.Data.StringListObj[stringListById].AddRowWithData("Supply source " + this.game.Data.LocObj[index109].X.ToString() + "," + this.game.Data.LocObj[index109].Y.ToString() + " : Fuel", this.game.Data.Turn.ToString(), "Sent to units", this.game.Data.Round.ToString(), numArray11[index109].ToString());
            if (buildUpMode)
              this.game.Data.StringListObj[stringListById].AddRowWithData("Supply source " + this.game.Data.LocObj[index109].X.ToString() + "," + this.game.Data.LocObj[index109].Y.ToString() + " : Fuel", this.game.Data.Turn.ToString(), "Sent to supply base", this.game.Data.Round.ToString(), numArray11[index109].ToString());
          }
        }
        if (depleteMode)
        {
          this.game.Data.StringListObj[stringListById].AddRowWithData("Unit supply", this.game.Data.Turn.ToString(), "Received from supply base", this.game.Data.Round.ToString(), num12.ToString());
          this.game.Data.StringListObj[stringListById].AddRowWithData("Unit fuel", this.game.Data.Turn.ToString(), "Received from supply base", this.game.Data.Round.ToString(), num13.ToString());
        }
        else if (supplySourceMode)
        {
          this.game.Data.StringListObj[stringListById].AddRowWithData("Unit supply", this.game.Data.Turn.ToString(), "Requested", this.game.Data.Round.ToString(), num10.ToString());
          this.game.Data.StringListObj[stringListById].AddRowWithData("Unit supply", this.game.Data.Turn.ToString(), "Received from supply source", this.game.Data.Round.ToString(), num12.ToString());
          this.game.Data.StringListObj[stringListById].AddRowWithData("Unit fuel", this.game.Data.Turn.ToString(), "Requested", this.game.Data.Round.ToString(), num11.ToString());
          this.game.Data.StringListObj[stringListById].AddRowWithData("Unit fuel", this.game.Data.Turn.ToString(), "Received from supply source", this.game.Data.Round.ToString(), num13.ToString());
          this.game.Data.StringListObj[stringListById].AddRowWithData("All supply source : Supply", this.game.Data.Turn.ToString(), "Sent to units", this.game.Data.Round.ToString(), num59.ToString());
          this.game.Data.StringListObj[stringListById].AddRowWithData("All supply source : Fuel", this.game.Data.Turn.ToString(), "Sent to units", this.game.Data.Round.ToString(), num60.ToString());
        }
        else
        {
          if (evacuateMode || !buildUpMode)
            return;
          this.game.Data.StringListObj[stringListById].AddRowWithData("All supply source : Supply", this.game.Data.Turn.ToString(), "Sent to supply base", this.game.Data.Round.ToString(), num59.ToString());
          this.game.Data.StringListObj[stringListById].AddRowWithData("All supply source : Fuel", this.game.Data.Turn.ToString(), "Sent to supply base", this.game.Data.Round.ToString(), num60.ToString());
        }
      }
    }

    public void LIS_LocationSupply() => this.LIS_UniversalSupplyAndReturn(2, false);

    public void LIS_UnitSupply(bool freeOfCost)
    {
      int num1 = 20;
      int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[404]));
      this.plogcounter = -1;
      this.AddPLog(nameof (LIS_UnitSupply));
      this.AddPLog("");
      SimpleList simpleList = new SimpleList();
      int unitCounter1 = this.game.Data.UnitCounter;
      int index1;
      for (index1 = 0; index1 <= unitCounter1; ++index1)
      {
        this.game.Data.UnitObj[index1].tempCoords = (CoordList) null;
        this.game.Data.UnitObj[index1].tempComplexCoords = (ComplexCoordList) null;
      }
      int num2;
      if (this.game.Data.Turn == 4)
        num2 = index1;
      int unitCounter2 = this.game.Data.UnitCounter;
      int index2;
      int dat1;
      for (index2 = 0; index2 <= unitCounter2; ++index2)
      {
        if (this.game.Data.UnitObj[index2].IsHQ & this.game.Data.UnitObj[index2].Regime == this.game.Data.Turn)
        {
          int historical1 = this.game.Data.UnitObj[index2].Historical;
          if (historical1 > -1 && this.game.Data.HistoricalUnitObj[historical1].Type == 8)
          {
            bool flag1 = false;
            int unitCounter3 = this.game.Data.UnitCounter;
            for (int unr = 0; unr <= unitCounter3; ++unr)
            {
              int historical2 = this.game.Data.UnitObj[unr].Historical;
              if (this.game.HandyFunctionsObj.IsUnitInHQChain(unr, index2) & unr != index2 & historical2 > -1)
              {
                bool flag2 = true;
                int num3 = this.game.Data.HistoricalUnitObj[historical2].GiveHisVarValue(71);
                int movetype = this.game.Data.HistoricalUnitObj[historical2].GiveHisVarValue(72);
                this.game.Data.UnitObj[unr].tempCoords = new CoordList();
                this.game.Data.UnitObj[unr].tempComplexCoords = new ComplexCoordList();
                this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype, 0, num3 * 2, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, false, SeaBlock: true, BlockAllSea: true);
                this.game.Data.UnitObj[unr].tempCoords.AddCoord(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0, 0, 100);
                if (this.game.Data.Turn == 2)
                  index2 = index2;
                int mapWidth = this.game.Data.MapObj[0].MapWidth;
                for (int x = 0; x <= mapWidth; ++x)
                {
                  int mapHeight = this.game.Data.MapObj[0].MapHeight;
                  for (int y = 0; y <= mapHeight; ++y)
                  {
                    if (this.game.EditObj.TempValue[0].Value[x, y] <= num3 * 2)
                    {
                      int num4 = this.game.EditObj.TempValue[0].Value[x, y];
                      int dat2_1 = 0;
                      if (num4 <= num3)
                        dat2_1 = 100;
                      else if (num4 < num3 * 2)
                        dat2_1 = 100 - (int) Math.Round((double) (100 * (num4 - num3)) / (double) num3);
                      CoordList tCoordList = new CoordList(true);
                      Coordinate coordinate;
                      coordinate.onmap = true;
                      coordinate.x = x;
                      coordinate.y = y;
                      coordinate = this.game.EditObj.TempCameFrom[0].Value[x, y];
                      if (this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y] >= 9999)
                        coordinate.onmap = false;
                      while (coordinate.onmap)
                      {
                        dat1 = this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y];
                        int dat2_2 = 0;
                        if (dat1 <= num3)
                          dat2_2 = 100;
                        else if (dat1 < num3 * 2)
                          dat2_2 = 100 - (int) Math.Round((double) (100 * (dat1 - num3)) / (double) num3);
                        tCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map, dat1, dat2_2);
                        coordinate = this.game.EditObj.TempCameFrom[0].Value[coordinate.x, coordinate.y];
                        if (this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y] >= 9999)
                          coordinate.onmap = false;
                      }
                      this.game.Data.UnitObj[unr].tempComplexCoords.AddCoord(x, y, 0, this.game.EditObj.TempValue[0].Value[x, y], dat2_1, tCoordList);
                      this.game.Data.UnitObj[unr].tempCoords.AddCoord(x, y, 0, this.game.EditObj.TempValue[0].Value[x, y], dat2_1);
                    }
                  }
                }
                flag1 = flag2;
              }
            }
            if (flag1)
            {
              if (Information.IsNothing((object) this.game.Data.UnitObj[index2].items))
                this.game.Data.UnitObj[index2].items = new ItemList();
              this.game.Data.UnitObj[index2].tempLisStartHistory = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y].LIShistory[6];
              simpleList.Add(index2, 1);
            }
          }
        }
      }
      if (this.game.Data.Turn == 2)
        num2 = index2;
      int unitCounter4 = this.game.Data.UnitCounter;
      for (int index3 = 0; index3 <= unitCounter4; ++index3)
      {
        this.game.Data.UnitObj[index3].tempHandledItems = new SimpleList();
        if (this.game.Data.UnitObj[index3].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index3].PreDef == -1 && !Information.IsNothing((object) this.game.Data.UnitObj[index3].tempRequestItems))
        {
          int counter = this.game.Data.UnitObj[index3].tempRequestItems.Counter;
          for (int index4 = 0; index4 <= counter; ++index4)
          {
            UnitClass[] unitObj = this.game.Data.UnitObj;
            UnitClass[] unitClassArray = unitObj;
            int index5 = index3;
            int index6 = index5;
            unitClassArray[index6].SupplyInReq = unitObj[index5].SupplyInReq + this.game.Data.UnitObj[index3].tempRequestItems.Weight[index4];
          }
        }
      }
      bool[] flagArray1 = new bool[this.game.Data.UnitCounter + 1];
      bool[] flagArray2 = new bool[this.game.Data.UnitCounter + 1];
      int[] numArray = new int[this.game.Data.UnitCounter + 1];
      bool[] flagArray3 = new bool[this.game.Data.UnitCounter + 1];
      bool[] flagArray4 = new bool[this.game.Data.UnitCounter + 1];
      bool[] flagArray5 = new bool[this.game.Data.UnitCounter + 1];
      bool flag3 = true;
      int num5 = 0;
      int num6 = 0;
      while (flag3)
      {
        ++num5;
        num6 += num1;
        flag3 = false;
        bool flag4 = true;
        this.AddPLog(num5.ToString() + ".Superloop. CurMaxPercent=" + num6.ToString());
        int num7 = 0;
        while (flag4)
        {
          flag4 = false;
          ++num7;
          this.AddPLog("ShqLoop");
          int counter1 = simpleList.Counter;
          bool flag5;
          for (int index7 = 0; index7 <= counter1; ++index7)
          {
            int hq = simpleList.Id[index7];
            int num8 = 0;
            num8 = this.game.Data.UnitObj[hq].lisInstructions.FindWeight(2) + this.game.Data.UnitObj[hq].lisInstructions.FindWeight(3);
            if (num8 > 100)
              num8 = 100;
            int weight1 = this.game.Data.UnitObj[hq].lisInstructions.FindWeight(13);
            int weight2 = this.game.Data.UnitObj[hq].lisInstructions.FindWeight(12);
            this.AddPLog("SHQ Max Percentage Allowed " + num8.ToString() + "%");
            int data3_1 = (int) Math.Round((double) ((this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y].LISpoints[6] + this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y].LIShistory[6]) * num8) / 100.0) - (this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y].LIShistory[6] - this.game.Data.UnitObj[hq].tempLisStartHistory);
            if (data3_1 < 1)
              data3_1 = 0;
            if (num7 == 1 & num5 == 1)
              this.game.Data.UnitObj[hq].AddLog(603, 1, 0, data3_1);
            if (data3_1 < 1)
              data3_1 = 0;
            int num9 = (int) Math.Round((double) (data3_1 * num6) / 100.0);
            if (!freeOfCost)
            {
              if (this.game.EventRelatedObj.Helper_AirEnabled() & weight1 == 1)
                this.game.HandyFunctionsObj.MakeMovePredictionLIS(this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y, this.game.Data.UnitObj[hq].Map, useAirBridge: true, maxDam: weight2);
              else
                this.game.HandyFunctionsObj.MakeMovePredictionLIS(this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y, this.game.Data.UnitObj[hq].Map);
            }
            this.AddPLog(num5.ToString() + "." + num7.ToString() + ".Shq: " + this.game.Data.UnitObj[hq].Name + ", CurrentLisAvailable: " + num9.ToString());
            flag5 = true;
            int num10 = 0;
            int num11 = 0;
            while (flag5)
            {
              flag5 = false;
              ++num10;
              num11 += 10;
              if (num11 > 100)
                num11 = 100;
              if (num11 < 100)
                flag5 = true;
              int unitCounter5 = this.game.Data.UnitCounter;
              for (int unr = 0; unr <= unitCounter5; ++unr)
              {
                if (this.game.HandyFunctionsObj.IsUnitInHQChain(unr, hq) & this.game.Data.UnitObj[unr].Historical > -1)
                {
                  bool flag6 = false;
                  if (this.game.Data.UnitObj[hq].X == this.game.Data.UnitObj[unr].X & this.game.Data.UnitObj[hq].Y == this.game.Data.UnitObj[unr].Y)
                    flag6 = true;
                  this.AddPLog(num5.ToString() + "." + num7.ToString() + "." + num10.ToString() + ".Unit: " + this.game.Data.UnitObj[unr].Name);
                  if (unr == 202)
                    unr = unr;
                  if (Information.IsNothing((object) this.game.Data.UnitObj[unr].tempRequestItems))
                    this.game.Data.UnitObj[unr].tempRequestItems = new SimpleList();
                  int counter2 = this.game.Data.UnitObj[unr].tempRequestItems.Counter;
                  for (int index8 = 0; index8 <= counter2; ++index8)
                  {
                    if (!freeOfCost & num10 == 1 & num7 == 1 & num5 == 1)
                    {
                      int data1 = this.game.Data.UnitObj[unr].tempRequestItems.Id[index8];
                      int data3_2 = this.game.Data.UnitObj[unr].tempRequestItems.Weight[index8];
                      this.game.Data.UnitObj[unr].AddLog(202, data1, 0, data3_2);
                      this.game.Data.UnitObj[hq].AddLog(202, data1, 0, data3_2);
                    }
                    if (this.game.Data.UnitObj[unr].X == 14 & this.game.Data.UnitObj[unr].Y == 3)
                      unr = unr;
                    if (num9 > 0 | freeOfCost | flag6)
                    {
                      int num12 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unr].Historical].GiveHisVarValue(71);
                      int num13 = this.game.Data.UnitObj[unr].tempRequestItems.Id[index8];
                      int num14 = this.game.Data.UnitObj[unr].tempRequestItems.Weight[index8];
                      int integer = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].GetData(0, num13, 3));
                      int nr1 = this.game.Data.UnitObj[unr].tempHandledItems.FindNr(num13);
                      int num15 = 0;
                      if (nr1 > -1)
                        num15 = this.game.Data.UnitObj[unr].tempHandledItems.Weight[nr1];
                      int num16 = (int) Math.Round(Math.Ceiling((double) num14 * ((double) num6 / 100.0) * ((double) num11 / 100.0)));
                      if (num14 > 0 & num16 == 0)
                        num16 = 1;
                      int num17 = num16 - num15;
                      int pts = num17 * integer;
                      if (flag6)
                        pts = 0;
                      if (!freeOfCost && pts > num9)
                      {
                        num17 = (int) Math.Round(Math.Floor((double) (num17 * num9) / (double) pts));
                        pts = num9;
                        if (!flagArray5[unr])
                        {
                          flagArray5[unr] = true;
                          this.game.Data.UnitObj[unr].AddLog(704, 0, 0, 0);
                        }
                      }
                      int nr2 = this.game.Data.UnitObj[hq].items.list.FindNr(num13);
                      if (nr2 > -1)
                      {
                        int num18 = this.game.Data.UnitObj[hq].items.list.Weight[nr2];
                        if (num18 < 0)
                          num18 = 0;
                        if (num17 > num18)
                        {
                          num17 = num18;
                          if (!flagArray4[unr])
                          {
                            flagArray4[unr] = true;
                            this.game.Data.UnitObj[unr].AddLog(703, 0, 0, 0);
                          }
                        }
                      }
                      else
                      {
                        num17 = 0;
                        if (!flagArray4[unr])
                        {
                          flagArray4[unr] = true;
                          this.game.Data.UnitObj[unr].AddLog(703, 0, 0, 0);
                        }
                      }
                      Coordinate unitBestCoordinate;
                      if (!freeOfCost & num17 > 0)
                      {
                        if (flag6)
                        {
                          unitBestCoordinate.x = this.game.Data.UnitObj[hq].X;
                          unitBestCoordinate.y = this.game.Data.UnitObj[hq].Y;
                          unitBestCoordinate.data2 = 100;
                          if (!flagArray1[unr] | unitBestCoordinate.data2 < numArray[unr])
                          {
                            flagArray1[unr] = true;
                            numArray[unr] = unitBestCoordinate.data2;
                            this.game.Data.UnitObj[unr].AddLog(701, unitBestCoordinate.x, unitBestCoordinate.y, unitBestCoordinate.data2);
                          }
                        }
                        else
                        {
                          if (unr == 978)
                            unr = unr;
                          unitBestCoordinate = this.LIS_GetUnitBestCoordinate(this.game.Data.UnitObj[unr].tempCoords, num17, true, this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y);
                          if (this.game.Data.UnitObj[unr].X == 14)
                            unr = unr;
                          if (unitBestCoordinate.onmap)
                          {
                            if (this.game.EventRelatedObj.Helper_AirEnabled() & !flag6 && integer < 1 && this.LIS_HasAirBridgeOnTrajectory(unitBestCoordinate.x, unitBestCoordinate.y, this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y))
                            {
                              int num19 = 1;
                              if (this.IsItemMaximizer(num13))
                                num17 = 0;
                              pts = num17 * num19;
                              if (!freeOfCost && pts > num9)
                              {
                                num17 = (int) Math.Round(Math.Floor((double) (num17 * num9) / (double) pts));
                                pts = num9;
                                if (!flagArray5[unr])
                                {
                                  flagArray5[unr] = true;
                                  this.game.Data.UnitObj[unr].AddLog(704, 0, 0, 0);
                                }
                              }
                            }
                            bool flag7 = false;
                            this.AddPLog("Best pickup adress: " + unitBestCoordinate.x.ToString() + "," + unitBestCoordinate.y.ToString() + ", organic ap need for pickup= " + unitBestCoordinate.data2.ToString());
                            if (unitBestCoordinate.data2 < 2 * num12)
                            {
                              if (this.game.Data.UnitObj[unr].tempRequestItems.Id[index8] == 7)
                              {
                                dat1 = Convert.ToInt32(Math.Floor(new Decimal(this.game.Data.UnitObj[unr].tempRequestItems.Weight[index8])));
                                flag7 = true;
                              }
                              else
                                dat1 = (int) Math.Round(Math.Floor((double) (this.game.Data.UnitObj[unr].tempRequestItems.Weight[index8] * unitBestCoordinate.data2) / 100.0));
                              if (num17 + num15 > dat1)
                              {
                                num17 = dat1 - num15;
                                if (0 > num17)
                                  num17 = 0;
                              }
                            }
                            else
                              dat1 = dat1;
                            if (!flagArray1[unr] | unitBestCoordinate.data2 < numArray[unr] && !flag7)
                            {
                              flagArray1[unr] = true;
                              numArray[unr] = unitBestCoordinate.data2;
                              this.game.Data.UnitObj[unr].AddLog(701, unitBestCoordinate.x, unitBestCoordinate.y, unitBestCoordinate.data2);
                            }
                            if (num17 > 0)
                            {
                              int pointsOnTrajectory = this.LIS_GetLowestPointsOnTrajectory(unitBestCoordinate.x, unitBestCoordinate.y, this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y, true);
                              if (pointsOnTrajectory < num14 && !flagArray3[unr])
                              {
                                flagArray3[unr] = true;
                                this.game.Data.UnitObj[unr].AddLog(702, 0, 0, 0);
                              }
                              if (pointsOnTrajectory < 0)
                              {
                                num17 = 0;
                                pts = 0;
                                if (!flagArray3[unr])
                                {
                                  flagArray3[unr] = true;
                                  this.game.Data.UnitObj[unr].AddLog(702, 0, 0, 0);
                                }
                              }
                              else if (pointsOnTrajectory < pts)
                              {
                                num17 = (int) Math.Round(Math.Floor((double) (num17 * pointsOnTrajectory) / (double) pts));
                                pts = pointsOnTrajectory;
                                if (!flagArray3[unr])
                                {
                                  flagArray3[unr] = true;
                                  this.game.Data.UnitObj[unr].AddLog(702, 0, 0, 0);
                                }
                              }
                            }
                          }
                          else
                          {
                            this.AddPLog("No pickup hex found for unit.");
                            if (!flagArray2[unr])
                            {
                              flagArray2[unr] = true;
                              this.game.Data.UnitObj[unr].AddLog(705, 0, 0, 0);
                            }
                            num17 = 0;
                          }
                        }
                      }
                      if (num17 > 0)
                      {
                        this.AddPLog("Item: ID" + num13.ToString() + ", Qty=" + num17.ToString() + ", Already transferred: " + num15.ToString() + "/" + num14.ToString() + ", LogPtsNeed: " + pts.ToString());
                        flag5 = true;
                        int num20 = num17;
                        bool ok;
                        if (!freeOfCost & !flag6)
                        {
                          if (this.game.EventRelatedObj.Helper_AirEnabled())
                          {
                            OrderResult orderResult = this.LIS_RemovePointsFromTrajectory(unitBestCoordinate.x, unitBestCoordinate.y, pts);
                            ok = orderResult.OK;
                            if (orderResult.Data > 0)
                            {
                              int randomizedRoundingDam = this.game.HandyFunctionsObj.Air_GetRandomizedRoundingDam(num20, orderResult.Data);
                              num20 -= randomizedRoundingDam;
                              this.game.Data.UnitObj[unr].AddLog(107, num13, 0, randomizedRoundingDam);
                              this.game.Data.UnitObj[hq].AddLog(107, num13, 0, randomizedRoundingDam);
                            }
                          }
                          else
                            ok = this.LIS_RemovePointsFromTrajectory(unitBestCoordinate.x, unitBestCoordinate.y, pts).OK;
                        }
                        this.game.Data.UnitObj[hq].items.list.RemoveWeight(num13, num17);
                        this.game.Data.UnitObj[unr].items.list.AddWeight(num13, num20);
                        if (!freeOfCost)
                          this.game.Data.UnitObj[hq].AddLog(103, num13, 0, num17);
                        if (!freeOfCost)
                          this.game.Data.UnitObj[unr].AddLog(105, num13, 0, num20);
                        UnitClass[] unitObj = this.game.Data.UnitObj;
                        UnitClass[] unitClassArray = unitObj;
                        int index9 = unr;
                        int index10 = index9;
                        unitClassArray[index10].SupplyIn = unitObj[index9].SupplyIn + num20;
                        this.game.Data.UnitObj[unr].tempHandledItems.AddWeight(num13, num17);
                        if (!freeOfCost & !flag6)
                        {
                          num9 -= pts;
                          this.game.Data.UnitObj[unr].AddLog(503, 1, 0, num17);
                          this.LIS_AddOrganicPointsToTrajectory(unitBestCoordinate.x, unitBestCoordinate.y, num17, unitBestCoordinate.data2, unr);
                          this.AddPLog("--Removed " + pts.ToString() + " from trajectory " + unitBestCoordinate.x.ToString() + "," + unitBestCoordinate.y.ToString() + " <> " + this.game.Data.UnitObj[hq].Name);
                          if (ok & pts > 0)
                          {
                            this.AddPLog("--0 reached--");
                            if (this.game.EventRelatedObj.Helper_AirEnabled() & weight1 == 1)
                              this.game.HandyFunctionsObj.MakeMovePredictionLIS(this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y, this.game.Data.UnitObj[hq].Map, useAirBridge: true, maxDam: weight2);
                            else
                              this.game.HandyFunctionsObj.MakeMovePredictionLIS(this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y, this.game.Data.UnitObj[hq].Map);
                          }
                        }
                      }
                    }
                    else if (!flagArray5[unr])
                    {
                      flagArray5[unr] = true;
                      this.game.Data.UnitObj[unr].AddLog(704, 0, 0, 0);
                    }
                  }
                }
              }
            }
          }
          if (flag5)
            flag4 = true;
        }
        if (num6 < 100)
          flag3 = true;
      }
      int counter3 = simpleList.Counter;
      for (int index11 = 0; index11 <= counter3; ++index11)
      {
        int index12 = simpleList.Id[index11];
        int num21 = 0;
        num21 = this.game.Data.UnitObj[index12].lisInstructions.FindWeight(2) + this.game.Data.UnitObj[index12].lisInstructions.FindWeight(3);
        int data3 = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index12].X, this.game.Data.UnitObj[index12].Y].LIShistory[6] - this.game.Data.UnitObj[index12].tempLisStartHistory;
        this.AddPLog("SHQ " + this.game.Data.UnitObj[index12].Name + " total Logistical Points use is " + data3.ToString() + ".");
        this.game.Data.UnitObj[index12].AddLog(503, 1, 0, data3);
      }
      if (!freeOfCost)
        this.WritePLog("LIS_UnitSupply_Log");
      if (freeOfCost)
        this.WritePLog("LIS_UnitSupply_Free_Log");
      if (!freeOfCost)
        this.LIS_SetNetwork(true);
      int unitCounter6 = this.game.Data.UnitCounter;
      for (int index13 = 0; index13 <= unitCounter6; ++index13)
        this.game.Data.UnitObj[index13].tempComplexCoords = (ComplexCoordList) null;
      if (freeOfCost || !this.game.EventRelatedObj.Helper_AirEnabled())
        return;
      this.game.HandyFunctionsObj.Air_LogUpdateForAll(this.game.Data.Turn, "", " Air Points left after Unit Supply");
    }

    public void LIS_UnitAutoReinforceSetTempLists(int underUnr = -1, bool makeLogs = true)
    {
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        this.game.Data.UnitObj[unr].tempRequestItems = new SimpleList();
        this.game.Data.UnitObj[unr].tempMaxItems = new SimpleList();
        if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & this.game.Data.UnitObj[unr].PreDef == -1 & this.game.HandyFunctionsObj.LIS_AutoReinforceRulesValid(unr) & !this.game.HandyFunctionsObj.CheckIsBattlegroup(unr))
        {
          bool flag = true;
          if (underUnr > -1)
          {
            if (underUnr == unr)
              flag = true;
            else if (!this.game.HandyFunctionsObj.IsUnitInHQChain(unr, underUnr))
              flag = false;
          }
          if (flag)
          {
            int historical = this.game.Data.UnitObj[unr].Historical;
            if (historical > -1)
            {
              int preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[historical].SubParts[0]);
              int index1 = -1;
              if (this.game.Data.UnitObj[unr].HQ > -1)
                index1 = this.game.Data.UnitObj[unr].HQ;
              if (index1 > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index1].Historical].Type < 8 && this.game.Data.UnitObj[index1].HQ > -1)
              {
                index1 = this.game.Data.UnitObj[index1].HQ;
                if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index1].Historical].Type < 8)
                  index1 = -1;
              }
              SimpleList simpleList1 = new SimpleList();
              SimpleList simpleList2 = new SimpleList();
              if (preDef > -1)
              {
                int sfCount = this.game.Data.UnitObj[preDef].SFCount;
                for (int index2 = 0; index2 <= sfCount; ++index2)
                {
                  int sf = this.game.Data.UnitObj[preDef].SFList[index2];
                  int type = this.game.Data.SFObj[sf].Type;
                  int reinforcementType = this.game.Data.SFTypeObj[type].ReinforcementType;
                  int reinforcementType2 = this.game.Data.SFTypeObj[type].ReinforcementType2;
                  int tweight = (int) Math.Round((double) (this.game.Data.SFObj[sf].Qty * this.game.Data.UnitObj[unr].SOReplacementPercent) / 100.0);
                  if (reinforcementType > -1 & tweight > 0)
                    simpleList1.AddWeight(reinforcementType, tweight);
                  if (reinforcementType > -1 & tweight > 0)
                    simpleList2.AddWeight(reinforcementType, tweight);
                  if (reinforcementType2 > -1 & tweight > 0)
                    simpleList2.AddWeight(reinforcementType2, tweight);
                }
              }
              SimpleList SL = new SimpleList();
              if (preDef > -1)
              {
                int sfCount = this.game.Data.UnitObj[unr].SFCount;
                for (int index3 = 0; index3 <= sfCount; ++index3)
                {
                  int sf = this.game.Data.UnitObj[unr].SFList[index3];
                  int reinforcementType = this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].ReinforcementType;
                  int qty = this.game.Data.SFObj[sf].Qty;
                  if (reinforcementType > -1 & qty > 0)
                    SL.AddWeight(reinforcementType, qty);
                }
              }
              simpleList1.RemoveWeight(ref SL);
              simpleList2.RemoveWeight(ref SL);
              simpleList2.removeWeight0orLower();
              simpleList1.removeWeight0orLower();
              if (simpleList1.Counter > -1)
              {
                this.game.Data.UnitObj[unr].tempRequestItems = simpleList1;
                int counter = simpleList1.Counter;
                for (int index4 = 0; index4 <= counter; ++index4)
                {
                  if (makeLogs)
                  {
                    this.game.Data.UnitObj[unr].AddLog(1, simpleList1.Id[index4], 0, simpleList1.Weight[index4]);
                    if (index1 > -1)
                      this.game.Data.UnitObj[index1].AddLog(11, simpleList1.Id[index4], 0, simpleList1.Weight[index4]);
                  }
                }
              }
              if (simpleList2.Counter > 1)
                this.game.Data.UnitObj[unr].tempMaxItems = simpleList2;
            }
          }
        }
      }
    }

    public void LIS_UnitAutoReinforce()
    {
      int num1 = 20;
      this.plogcounter = -1;
      this.AddPLog("LIS_AutoReinforce");
      this.AddPLog("");
      this.LIS_UnitAutoReinforceSetTempLists();
      if (this.game.Data.Turn == 2)
      {
        int num2 = num2;
      }
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
        this.game.Data.UnitObj[index].tempCoords = (CoordList) null;
      SimpleList simpleList = new SimpleList();
      int unitCounter2 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter2; ++index)
      {
        if (this.game.Data.UnitObj[index].IsHQ & this.game.Data.UnitObj[index].Regime == this.game.Data.Turn)
        {
          int historical1 = this.game.Data.UnitObj[index].Historical;
          if (historical1 > -1 && this.game.Data.HistoricalUnitObj[historical1].Type == 8)
          {
            bool flag = false;
            int unitCounter3 = this.game.Data.UnitCounter;
            for (int unr = 0; unr <= unitCounter3; ++unr)
            {
              if (this.game.HandyFunctionsObj.IsUnitInHQChain(unr, index) & this.game.Data.UnitObj[unr].Historical > -1 & unr != index)
              {
                flag = true;
                if (unr == 966)
                  unr = unr;
                int historical2 = this.game.Data.UnitObj[unr].Historical;
                int num3 = this.game.Data.HistoricalUnitObj[historical2].GiveHisVarValue(71);
                int movetype = this.game.Data.HistoricalUnitObj[historical2].GiveHisVarValue(72);
                this.game.Data.UnitObj[unr].tempCoords = new CoordList();
                this.game.Data.UnitObj[unr].tempComplexCoords = new ComplexCoordList();
                this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype, 0, num3 * 2, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, false, SeaBlock: true, BlockAllSea: true);
                int mapWidth = this.game.Data.MapObj[0].MapWidth;
                for (int x = 0; x <= mapWidth; ++x)
                {
                  int mapHeight = this.game.Data.MapObj[0].MapHeight;
                  for (int y = 0; y <= mapHeight; ++y)
                  {
                    if (this.game.EditObj.TempValue[0].Value[x, y] <= 2 * num3)
                    {
                      int num4 = this.game.EditObj.TempValue[0].Value[x, y];
                      int dat2_1 = 0;
                      if (num4 <= num3)
                        dat2_1 = 100;
                      else if (num4 < num3 * 2)
                        dat2_1 = 100 - (int) Math.Round((double) (100 * (num4 - num3)) / (double) num3);
                      CoordList tCoordList = new CoordList(true);
                      Coordinate coordinate;
                      coordinate.onmap = true;
                      coordinate.x = x;
                      coordinate.y = y;
                      coordinate = this.game.EditObj.TempCameFrom[0].Value[x, y];
                      while (coordinate.onmap)
                      {
                        int dat1 = this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y];
                        int dat2_2 = 0;
                        if (dat1 <= num3)
                          dat2_2 = 100;
                        else if (dat1 < num3 * 2)
                          dat2_2 = 100 - (int) Math.Round((double) (100 * (dat1 - num3)) / (double) num3);
                        tCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map, dat1, dat2_2);
                        coordinate = this.game.EditObj.TempCameFrom[0].Value[coordinate.x, coordinate.y];
                        if (tCoordList.counter > 200)
                        {
                          tCoordList = new CoordList(true);
                          break;
                        }
                      }
                      this.game.Data.UnitObj[unr].tempComplexCoords.AddCoord(x, y, 0, this.game.EditObj.TempValue[0].Value[x, y], dat2_1, tCoordList);
                      this.game.Data.UnitObj[unr].tempCoords.AddCoord(x, y, 0, this.game.EditObj.TempValue[0].Value[x, y], dat2_1);
                    }
                    else
                    {
                      int num5 = this.game.EditObj.TempValue[0].Value[x, y];
                    }
                  }
                }
                index = index;
              }
            }
            if (flag)
            {
              if (Information.IsNothing((object) this.game.Data.UnitObj[index].items))
                this.game.Data.UnitObj[index].items = new ItemList();
              this.game.Data.UnitObj[index].tempLisStartHistory = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y].LIShistory[6];
              simpleList.Add(index, 1);
            }
          }
        }
      }
      int unitCounter4 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter4; ++index)
        this.game.Data.UnitObj[index].tempHandledItems = new SimpleList();
      bool flag1 = true;
      int num6 = 0;
      int num7 = 0;
      while (flag1)
      {
        ++num6;
        num7 += num1;
        flag1 = false;
        bool flag2 = true;
        this.AddPLog(num6.ToString() + ".Superloop. CurMaxPercent=" + num7.ToString());
        int num8 = 0;
        while (flag2)
        {
          flag2 = false;
          ++num8;
          this.AddPLog("ShqLoop");
          int counter1 = simpleList.Counter;
          bool flag3;
          for (int index1 = 0; index1 <= counter1; ++index1)
          {
            int index2 = simpleList.Id[index1];
            int num9 = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y].LISpoints[6] + this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y].LIShistory[6];
            int num10 = this.game.Data.UnitObj[index2].lisInstructions.FindWeight(2) + this.game.Data.UnitObj[index2].lisInstructions.FindWeight(3) + this.game.Data.UnitObj[index2].lisInstructions.FindWeight(5) + this.game.Data.UnitObj[index2].lisInstructions.FindWeight(6);
            this.AddPLog("SHQ Max Percentage Allowed " + num10.ToString() + "%");
            if (num10 > 100)
              num10 = 100;
            int data3 = (int) Math.Round((double) (num9 * num10) / 100.0) - (this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y].LIShistory[6] - this.game.Data.UnitObj[index2].tempLisStartHistory);
            if (data3 < 1)
              data3 = 0;
            if (num8 == 1 & num6 == 1)
              this.game.Data.UnitObj[index2].AddLog(606, 1, 0, data3);
            if (0 > data3)
              data3 = 0;
            int num11 = (int) Math.Round((double) (data3 * num7) / 100.0);
            this.game.HandyFunctionsObj.MakeMovePredictionLIS(this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y, this.game.Data.UnitObj[index2].Map);
            this.AddPLog(num6.ToString() + "." + num8.ToString() + ".Shq: " + this.game.Data.UnitObj[index2].Name + ", CurrentLisAvailable: " + num11.ToString());
            flag3 = true;
            int num12 = 0;
            int num13 = 0;
            while (flag3)
            {
              flag3 = false;
              ++num12;
              num13 += 10;
              if (num13 > 100)
                num13 = 100;
              if (num13 < 100)
                flag3 = true;
              int unitCounter5 = this.game.Data.UnitCounter;
              for (int unr = 0; unr <= unitCounter5; ++unr)
              {
                if (this.game.HandyFunctionsObj.IsUnitInHQChain(unr, index2) & !this.game.HandyFunctionsObj.CheckIsBattlegroup(unr))
                {
                  bool flag4 = false;
                  if (this.game.Data.UnitObj[index2].X == this.game.Data.UnitObj[unr].X & this.game.Data.UnitObj[index2].Y == this.game.Data.UnitObj[unr].Y)
                    flag4 = true;
                  this.AddPLog(num6.ToString() + "." + num8.ToString() + "." + num12.ToString() + ".Unit: " + this.game.Data.UnitObj[unr].Name);
                  int counter2 = this.game.Data.UnitObj[unr].tempRequestItems.Counter;
                  for (int index3 = 0; index3 <= counter2; ++index3)
                  {
                    if (num12 == 1 & num8 == 1 & num6 == 1)
                    {
                      int num14 = this.game.Data.UnitObj[unr].tempRequestItems.Id[index3];
                      int num15 = this.game.Data.UnitObj[unr].tempRequestItems.Weight[index3];
                    }
                    if (num11 > 0 | flag4)
                    {
                      int num16 = this.game.Data.UnitObj[unr].tempRequestItems.Id[index3];
                      int reinfType = -1;
                      int num17 = 0;
                      int index4 = -1;
                      int historical = this.game.Data.UnitObj[unr].Historical;
                      int index5;
                      if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].SubParts[0] > 0)
                      {
                        int preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[historical].SubParts[0]);
                        if (preDef > -1)
                        {
                          int sfCount = this.game.Data.UnitObj[preDef].SFCount;
                          for (int index6 = 0; index6 <= sfCount; ++index6)
                          {
                            index5 = this.game.Data.UnitObj[preDef].SFList[index6];
                            int type = this.game.Data.SFObj[index5].Type;
                            if (this.game.Data.SFTypeObj[type].ReinforcementType == num16)
                            {
                              reinfType = this.game.Data.SFTypeObj[type].ReinforcementType2;
                              num17 = this.game.Data.SFTypeObj[type].Weight;
                              index4 = this.game.Data.SFTypeObj[type].MoveType;
                            }
                          }
                        }
                      }
                      int num18 = this.game.Data.UnitObj[unr].tempRequestItems.Weight[index3];
                      int nr = this.game.Data.UnitObj[unr].tempHandledItems.FindNr(num16);
                      int num19 = 0;
                      if (nr > -1)
                        num19 = this.game.Data.UnitObj[unr].tempHandledItems.Weight[nr];
                      int num20 = (int) Math.Round(Math.Ceiling((double) num18 * ((double) num7 / 100.0) * ((double) num13 / 100.0)));
                      if (num18 > 0 & num20 == 0)
                        num20 = 1;
                      int num21 = num20 - num19;
                      int num22 = num21;
                      if (flag4)
                        num22 = 0;
                      int num23 = 1 * num17;
                      if (num23 > num11)
                      {
                        num21 = (int) Math.Round(Math.Floor((double) (num21 * num11) / (double) num23));
                        num23 = num11;
                      }
                      if (index4 > -1)
                      {
                        int num24 = 9999;
                        bool flag5 = false;
                        int x = this.game.Data.UnitObj[unr].X;
                        int y = this.game.Data.UnitObj[unr].Y;
                        int index7 = 0;
                        do
                        {
                          int index8 = this.game.Data.MapObj[0].HexObj[x, y].RoadType[index7];
                          if (index8 > -1)
                          {
                            if (this.game.Data.RoadTypeObj[index8].MoveCostOverrule[index4] >= 999)
                            {
                              flag5 = true;
                            }
                            else
                            {
                              int num25 = this.game.Data.RoadTypeObj[index8].MoveCostOverrule[index4];
                              if (num25 < num24)
                                num24 = num25;
                            }
                          }
                          ++index7;
                        }
                        while (index7 <= 5);
                        int num26 = this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[x, y].LandscapeType].MoveCost[index4];
                        if (num26 < num24)
                          num24 = num26;
                        if (num24 > 100 & !flag5)
                          num21 = 0;
                      }
                      int index9 = -1;
                      if (num21 > 0)
                      {
                        bool quality2 = false;
                        bool quality3 = false;
                        bool quality4 = false;
                        bool quality5 = false;
                        if (num21 > 1)
                          quality2 = quality2;
                        if (historical > -1)
                        {
                          if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(42) <= 0)
                            quality2 = true;
                          if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(43) <= 0)
                            quality3 = true;
                          if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(44) <= 0)
                            quality4 = true;
                          if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(45) <= 0)
                            quality5 = true;
                          if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(11) > 0)
                          {
                            quality2 = true;
                            quality3 = true;
                            quality4 = true;
                            quality5 = true;
                          }
                        }
                        int people = this.game.Data.HistoricalUnitObj[historical].People;
                        int index10 = Conversions.ToInteger(this.LIS_GetSHQSFObjNr(index2, quality2, quality3, quality4, quality5, num16, people));
                        if (index10 == -1)
                        {
                          index10 = Conversions.ToInteger(this.LIS_GetSHQSFObjNr(index2, quality2, quality3, quality4, quality5, reinfType, people));
                          if (index10 > -1)
                          {
                            int reinforcementType = this.game.Data.SFTypeObj[this.game.Data.SFObj[index10].Type].ReinforcementType;
                            if (this.game.Data.UnitObj[unr].tempMaxItems.FindWeight(reinforcementType) < 1)
                              index10 = -1;
                          }
                        }
                        index5 = index10;
                        if (index5 > -1)
                          index9 = this.game.Data.SFObj[index5].Type;
                        if (index10 > -1)
                        {
                          num21 = 1;
                          if (num18 < 1)
                            num21 = 0;
                        }
                        else
                          num21 = 0;
                      }
                      Coordinate unitBestCoordinate;
                      if (num21 > 0)
                      {
                        unitBestCoordinate = this.LIS_GetUnitBestCoordinate(this.game.Data.UnitObj[unr].tempCoords, num21, true, this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y);
                        if (unitBestCoordinate.onmap)
                        {
                          this.AddPLog("Pickup adress: " + unitBestCoordinate.x.ToString() + "," + unitBestCoordinate.y.ToString());
                          if (this.LIS_GetLowestPointsOnTrajectory(unitBestCoordinate.x, unitBestCoordinate.y, this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y) < num23)
                            num21 = 0;
                        }
                        else
                        {
                          this.AddPLog("No pickup hex found for unit.");
                          num21 = 0;
                        }
                      }
                      if (num21 > 0)
                      {
                        this.AddPLog("ReinfType: ID" + num16.ToString() + ", Qty=" + num21.ToString() + ", Already transferred: " + num19.ToString() + "/" + num18.ToString() + ", LogPtsNeed: " + num23.ToString());
                        flag3 = true;
                        this.game.Data.UnitObj[unr].AddLog(2, num16, 0, 1);
                        this.game.Data.UnitObj[index2].AddLog(12, num16, 0, 1);
                        this.game.HandyFunctionsObj.AddTroops3(unr, index9, this.game.Data.SFObj[index5].People, 1, this.game.Data.SFObj[index5].Xp, this.game.Data.SFObj[index5].Rdn, 0, this.game.Data.SFObj[index5].Mor, vigor: this.game.Data.SFObj[index5].Vigor);
                        this.game.HandyFunctionsObj.RemoveTroops(index2, index9, this.game.Data.SFObj[index5].People, 1, -1);
                        SimpleList SL = new SimpleList();
                        int tid1 = this.game.Data.SFTypeObj[index9].SFTypeVar[45];
                        int tweight1 = this.game.Data.SFTypeObj[index9].SFTypeVar[52];
                        if (tweight1 > 0)
                          SL.Add(tid1, tweight1);
                        int tid2 = this.game.Data.SFTypeObj[index9].SFTypeVar[47];
                        int tweight2 = this.game.Data.SFTypeObj[index9].SFTypeVar[53];
                        if (tweight2 > 0)
                          SL.Add(tid2, tweight2);
                        int tid3 = this.game.Data.SFTypeObj[index9].SFTypeVar[50];
                        int tweight3 = this.game.Data.SFTypeObj[index9].SFTypeVar[54];
                        if (tweight3 > 0)
                          SL.Add(tid3, tweight3);
                        if (this.game.Data.UnitObj[index2].items.list.CanRemoveWeight(ref SL))
                        {
                          this.game.Data.UnitObj[index2].items.list.RemoveWeight(ref SL);
                          this.game.Data.UnitObj[unr].items.list.AddWeight(ref SL);
                        }
                        this.game.Data.UnitObj[unr].tempHandledItems.AddWeight(num16, num21);
                        this.game.Data.UnitObj[unr].tempMaxItems.RemoveWeight(this.game.Data.SFTypeObj[index9].ReinforcementType, 1);
                        num11 -= num23;
                        this.game.Data.UnitObj[unr].AddLog(506, 1, 0, num23);
                        this.game.Data.UnitObj[index2].AddLog(506, 1, 0, num23);
                        bool ok = this.LIS_RemovePointsFromTrajectory(unitBestCoordinate.x, unitBestCoordinate.y, num23).OK;
                        this.LIS_AddOrganicPointsToTrajectory(unitBestCoordinate.x, unitBestCoordinate.y, num23, unitBestCoordinate.data2, unr);
                        this.AddPLog("--Removed " + num23.ToString() + " from trajectory " + unitBestCoordinate.x.ToString() + "," + unitBestCoordinate.y.ToString() + " <> " + this.game.Data.UnitObj[index2].Name);
                        if (ok & num23 > 0)
                        {
                          this.AddPLog("--0 reached--");
                          this.game.HandyFunctionsObj.MakeMovePredictionLIS(this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y, this.game.Data.UnitObj[index2].Map);
                        }
                      }
                    }
                  }
                }
              }
            }
          }
          if (flag3)
            flag2 = true;
        }
        if (num7 < 100)
          flag1 = true;
      }
      int counter = simpleList.Counter;
      for (int index11 = 0; index11 <= counter; ++index11)
      {
        int index12 = simpleList.Id[index11];
        int data3 = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index12].X, this.game.Data.UnitObj[index12].Y].LIShistory[6] - this.game.Data.UnitObj[index12].tempLisStartHistory;
        this.AddPLog("SHQ " + this.game.Data.UnitObj[index12].Name + " total LIS use " + data3.ToString() + " pts.");
        this.game.Data.UnitObj[index12].AddLog(506, 1, 0, data3);
      }
      this.WritePLog("LIS_AutoReinforce_Log");
      this.LIS_SetNetwork(true);
      int unitCounter6 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter6; ++index)
        this.game.Data.UnitObj[index].tempComplexCoords = (ComplexCoordList) null;
    }

    public void LIS_UnitAutoReinforceReturns(bool normal, bool swappy)
    {
      int num1 = 20;
      int id = this.game.Data.RegimeObj[this.game.Data.Turn].id;
      int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[412]));
      this.plogcounter = -1;
      this.AddPLog("LIS_AutoReinforceRETURNS");
      this.AddPLog("");
      int num2 = 1;
      do
      {
        bool flag1 = false;
        if (normal)
          flag1 = true;
        if (swappy & num2 == 1)
          flag1 = true;
        if (flag1)
        {
          if (normal)
            this.AddPLog("NORMAL PHASE " + num2.ToString());
          if (swappy)
            this.AddPLog("SWAPPY PHASE " + num2.ToString());
          this.AddPLog("");
          int unitCounter1 = this.game.Data.UnitCounter;
          int index1;
          for (int unr = 0; unr <= unitCounter1; ++unr)
          {
            this.game.Data.UnitObj[unr].tempRequestItems = new SimpleList();
            this.game.Data.UnitObj[unr].tempMaxItems = new SimpleList();
            if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & this.game.Data.UnitObj[unr].PreDef == -1 & this.game.HandyFunctionsObj.LIS_AutoReinforceRulesValid(unr) & (!this.game.HandyFunctionsObj.CheckIsBattlegroup(unr) | this.game.Data.UnitObj[unr].SOReplacementPercent == 0))
            {
              int index2 = this.game.Data.UnitObj[unr].Historical;
              if (index2 > -1 && this.game.Data.UnitObj[unr].IsHQ & this.game.Data.HistoricalUnitObj[index2].TempVar1 == 1 && normal)
                index2 = -1;
              if (index2 > -1 && this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(11) < 1)
              {
                int preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[index2].SubParts[0]);
                int index3 = -1;
                if (this.game.Data.UnitObj[unr].HQ > -1)
                  index3 = this.game.Data.UnitObj[unr].HQ;
                if (index3 > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index3].Historical].Type < 8 && this.game.Data.UnitObj[index3].HQ > -1)
                {
                  index3 = this.game.Data.UnitObj[index3].HQ;
                  if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index3].Historical].Type < 8)
                    index3 = -1;
                }
                SimpleList SL = new SimpleList();
                SimpleList simpleList1 = new SimpleList();
                SimpleList simpleList2 = new SimpleList();
                int historical = this.game.Data.UnitObj[unr].Historical;
                bool flag2 = false;
                bool flag3 = false;
                bool flag4 = false;
                bool flag5 = false;
                if (historical > -1)
                {
                  if (swappy)
                  {
                    if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(42) != 1)
                      flag2 = true;
                    if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(43) != 1)
                      flag3 = true;
                    if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(44) != 1)
                      flag4 = true;
                    if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(45) != 1)
                      flag5 = true;
                  }
                  else if (normal)
                  {
                    if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(42) <= 1)
                      flag2 = true;
                    if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(43) <= 1)
                      flag3 = true;
                    if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(44) <= 1)
                      flag4 = true;
                    if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(45) <= 1)
                      flag5 = true;
                  }
                }
                if (preDef > -1)
                {
                  int sfCount = this.game.Data.UnitObj[unr].SFCount;
                  for (int index4 = 0; index4 <= sfCount; ++index4)
                  {
                    index1 = this.game.Data.UnitObj[unr].SFList[index4];
                    int type = this.game.Data.SFObj[index1].Type;
                    int reinforcementType = this.game.Data.SFTypeObj[type].ReinforcementType;
                    int reinforcementType2 = this.game.Data.SFTypeObj[type].ReinforcementType2;
                    int qty = this.game.Data.SFObj[index1].Qty;
                    int integer = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].GetData2(1, id, 0, this.game.Data.SFTypeObj[type].Id, 2));
                    bool flag6 = false;
                    if (num2 == 2)
                      flag6 = true;
                    if (num2 == 1 & integer == 1)
                      flag6 = true;
                    if (num2 == 1 & integer == 2 & !flag2)
                      flag6 = true;
                    if (num2 == 1 & integer == 3 & !flag3)
                      flag6 = true;
                    if (num2 == 1 & integer == 4 & !flag4)
                      flag6 = true;
                    if (num2 == 1 & integer == 5 & !flag5)
                      flag6 = true;
                    if (flag6)
                    {
                      if (reinforcementType > -1 & qty > 0)
                        simpleList2.AddWeight(reinforcementType, qty, this.game.Data.SFTypeObj[type].Weight);
                      if (reinforcementType > -1 & qty > 0)
                        simpleList1.AddWeight(reinforcementType, qty);
                      if (reinforcementType2 > -1 & reinforcementType != reinforcementType2 & qty > 0)
                        simpleList1.AddWeight(reinforcementType2, qty);
                    }
                  }
                }
                if (preDef > -1 & num2 == 2)
                {
                  int sfCount = this.game.Data.UnitObj[preDef].SFCount;
                  for (int index5 = 0; index5 <= sfCount; ++index5)
                  {
                    index1 = this.game.Data.UnitObj[preDef].SFList[index5];
                    int type = this.game.Data.SFObj[index1].Type;
                    int reinforcementType1 = this.game.Data.SFTypeObj[type].ReinforcementType;
                    int reinforcementType2 = this.game.Data.SFTypeObj[type].ReinforcementType;
                    int tweight = this.game.Data.SFObj[index1].Qty;
                    if (this.game.Data.UnitObj[unr].SOReplacementPercent == 0)
                      tweight = 0;
                    if (reinforcementType1 > -1 & tweight > 0)
                      SL.AddWeight(reinforcementType1, tweight);
                    if (reinforcementType1 > -1 & tweight > 0)
                      simpleList1.RemoveWeight(reinforcementType1, tweight);
                    if (reinforcementType2 > -1 & reinforcementType1 != reinforcementType2 & tweight > 0)
                      simpleList1.RemoveWeight(reinforcementType2, tweight);
                  }
                }
                simpleList2.RemoveWeight(ref SL);
                simpleList2.removeWeight0orLower();
                simpleList1.removeWeight0orLower();
                SL = simpleList2.Clone();
                if (SL.Counter > -1)
                {
                  this.game.Data.UnitObj[unr].tempRequestItems = SL;
                  int counter = SL.Counter;
                  for (int index6 = 0; index6 <= counter; ++index6)
                  {
                    if (normal)
                    {
                      this.game.Data.UnitObj[unr].AddLog(10, SL.Id[index6], 0, SL.Weight[index6]);
                      if (index3 > -1)
                        this.game.Data.UnitObj[index3].AddLog(18, SL.Id[index6], 0, SL.Weight[index6]);
                    }
                    else
                    {
                      int num3 = swappy ? 1 : 0;
                    }
                  }
                }
                if (simpleList1.Counter > -1)
                  this.game.Data.UnitObj[unr].tempMaxItems = simpleList1;
              }
            }
          }
          int unitCounter2 = this.game.Data.UnitCounter;
          for (int index7 = 0; index7 <= unitCounter2; ++index7)
          {
            this.game.Data.UnitObj[index7].tempCoords = (CoordList) null;
            this.game.Data.UnitObj[index7].tempComplexCoords = (ComplexCoordList) null;
          }
          SimpleList simpleList = new SimpleList();
          int unitCounter3 = this.game.Data.UnitCounter;
          int data3;
          for (int index8 = 0; index8 <= unitCounter3; ++index8)
          {
            if (this.game.Data.UnitObj[index8].IsHQ & this.game.Data.UnitObj[index8].Regime == this.game.Data.Turn)
            {
              int historical1 = this.game.Data.UnitObj[index8].Historical;
              if (historical1 > -1 && this.game.Data.HistoricalUnitObj[historical1].Type == 8)
              {
                bool flag7 = false;
                int unitCounter4 = this.game.Data.UnitCounter;
                for (int unr = 0; unr <= unitCounter4; ++unr)
                {
                  if (this.game.HandyFunctionsObj.IsUnitInHQChain(unr, index8) & this.game.Data.UnitObj[unr].Historical > -1 & unr != index8)
                  {
                    flag7 = true;
                    int historical2 = this.game.Data.UnitObj[unr].Historical;
                    int num4 = this.game.Data.HistoricalUnitObj[historical2].GiveHisVarValue(71);
                    int movetype = this.game.Data.HistoricalUnitObj[historical2].GiveHisVarValue(72);
                    this.game.Data.UnitObj[unr].tempCoords = new CoordList();
                    this.game.Data.UnitObj[unr].tempComplexCoords = new ComplexCoordList();
                    this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype, 0, num4 * 2, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, false, SeaBlock: true, BlockAllSea: true);
                    int mapWidth = this.game.Data.MapObj[0].MapWidth;
                    for (int x = 0; x <= mapWidth; ++x)
                    {
                      int mapHeight = this.game.Data.MapObj[0].MapHeight;
                      for (int y = 0; y <= mapHeight; ++y)
                      {
                        if (this.game.EditObj.TempValue[0].Value[x, y] <= 2 * num4)
                        {
                          data3 = this.game.EditObj.TempValue[0].Value[x, y];
                          int dat2_1 = 0;
                          if (data3 <= num4)
                            dat2_1 = 100;
                          else if (data3 < num4 * 2)
                            dat2_1 = 100 - (int) Math.Round((double) (100 * (data3 - num4)) / (double) num4);
                          CoordList tCoordList = new CoordList(true);
                          Coordinate coordinate;
                          coordinate.onmap = true;
                          coordinate.x = x;
                          coordinate.y = y;
                          coordinate = this.game.EditObj.TempCameFrom[0].Value[x, y];
                          while (coordinate.onmap)
                          {
                            int dat1 = this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y];
                            int dat2_2 = 0;
                            if (dat1 <= num4)
                              dat2_2 = 100;
                            else if (dat1 < num4 * 2)
                              dat2_2 = 100 - (int) Math.Round((double) (100 * (dat1 - num4)) / (double) num4);
                            if (tCoordList.FindSlot(coordinate.x, coordinate.y, coordinate.map) == -1)
                            {
                              tCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map, dat1, dat2_2);
                              coordinate = this.game.EditObj.TempCameFrom[0].Value[coordinate.x, coordinate.y];
                            }
                            else
                              coordinate.onmap = false;
                          }
                          this.game.Data.UnitObj[unr].tempComplexCoords.AddCoord(x, y, 0, this.game.EditObj.TempValue[0].Value[x, y], dat2_1, tCoordList);
                          this.game.Data.UnitObj[unr].tempCoords.AddCoord(x, y, 0, this.game.EditObj.TempValue[0].Value[x, y], dat2_1);
                        }
                      }
                    }
                  }
                }
                if (flag7)
                {
                  if (Information.IsNothing((object) this.game.Data.UnitObj[index8].items))
                    this.game.Data.UnitObj[index8].items = new ItemList();
                  this.game.Data.UnitObj[index8].tempLisStartHistory = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index8].X, this.game.Data.UnitObj[index8].Y].LIShistory[6];
                  simpleList.Add(index8, 1);
                }
              }
            }
          }
          int unitCounter5 = this.game.Data.UnitCounter;
          for (int index9 = 0; index9 <= unitCounter5; ++index9)
            this.game.Data.UnitObj[index9].tempHandledItems = new SimpleList();
          bool flag8 = true;
          int num5 = 0;
          int num6 = 0;
          while (flag8)
          {
            ++num5;
            num6 += num1;
            flag8 = false;
            bool flag9 = true;
            this.AddPLog(num5.ToString() + ".Superloop. CurMaxPercent=" + num6.ToString());
            int num7 = 0;
            while (flag9)
            {
              flag9 = false;
              ++num7;
              this.AddPLog("ShqLoop");
              int counter1 = simpleList.Counter;
              bool flag10;
              for (int index10 = 0; index10 <= counter1; ++index10)
              {
                int index11 = simpleList.Id[index10];
                int liSpoint = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index11].X, this.game.Data.UnitObj[index11].Y].LISpoints[6];
                int num8 = this.game.Data.UnitObj[index11].lisInstructions.FindWeight(2) + this.game.Data.UnitObj[index11].lisInstructions.FindWeight(3) + this.game.Data.UnitObj[index11].lisInstructions.FindWeight(5) + this.game.Data.UnitObj[index11].lisInstructions.FindWeight(6);
                this.AddPLog("SHQ Max Percentage Allowed " + num8.ToString() + "%");
                if (num8 > 100)
                  num8 = 100;
                int num9 = (int) Math.Round((double) (liSpoint * num8) / 100.0);
                data3 = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index11].X, this.game.Data.UnitObj[index11].Y].LIShistory[6] - this.game.Data.UnitObj[index11].tempLisStartHistory;
                int num10 = num9 - data3;
                if (num10 < 1)
                  num10 = 0;
                if (0 > num10)
                  num10 = 0;
                int num11 = (int) Math.Round((double) (num10 * num6) / 100.0);
                this.game.HandyFunctionsObj.MakeMovePredictionLIS(this.game.Data.UnitObj[index11].X, this.game.Data.UnitObj[index11].Y, this.game.Data.UnitObj[index11].Map);
                if (this.game.Data.Turn == 2)
                  index10 = index10;
                this.AddPLog(num5.ToString() + "." + num7.ToString() + ".Shq: " + this.game.Data.UnitObj[index11].Name + ", CurrentLisAvailable: " + num11.ToString());
                flag10 = true;
                int num12 = 0;
                int num13 = 0;
                while (flag10)
                {
                  flag10 = false;
                  ++num12;
                  num13 += 10;
                  if (num13 > 100)
                    num13 = 100;
                  if (num13 < 100)
                    flag10 = true;
                  int unitCounter6 = this.game.Data.UnitCounter;
                  for (int unr = 0; unr <= unitCounter6; ++unr)
                  {
                    if (this.game.HandyFunctionsObj.IsUnitInHQChain(unr, index11) & (!this.game.HandyFunctionsObj.CheckIsBattlegroup(unr) | this.game.Data.UnitObj[unr].SOReplacementPercent == 0))
                    {
                      bool flag11 = false;
                      if (this.game.Data.UnitObj[index11].X == this.game.Data.UnitObj[unr].X & this.game.Data.UnitObj[index11].Y == this.game.Data.UnitObj[unr].Y)
                        flag11 = true;
                      this.AddPLog(num5.ToString() + "." + num7.ToString() + "." + num12.ToString() + ".Unit: " + this.game.Data.UnitObj[unr].Name);
                      int counter2 = this.game.Data.UnitObj[unr].tempRequestItems.Counter;
                      for (int index12 = 0; index12 <= counter2; ++index12)
                      {
                        int num14;
                        if (num12 == 1 & num7 == 1 & num5 == 1)
                        {
                          int num15 = this.game.Data.UnitObj[unr].tempRequestItems.Id[index12];
                          num14 = this.game.Data.UnitObj[unr].tempRequestItems.Weight[index12];
                        }
                        if (num11 > 0 | flag11)
                        {
                          int num16 = this.game.Data.UnitObj[unr].tempRequestItems.Id[index12];
                          num14 = this.game.Data.UnitObj[unr].tempRequestItems.Weight[index12];
                          int num17 = Math.Max(1, this.game.Data.UnitObj[unr].tempRequestItems.Data1[index12]);
                          data3 = this.game.Data.UnitObj[unr].tempHandledItems.FindNr(num16);
                          int num18 = 0;
                          if (data3 > -1)
                            num18 = this.game.Data.UnitObj[unr].tempHandledItems.Weight[data3];
                          int num19 = (int) Math.Round(Math.Ceiling((double) num14 * ((double) num6 / 100.0) * ((double) num13 / 100.0)));
                          if (num14 > 0 & num19 == 0)
                            num19 = 1;
                          int num20 = num19 - num18;
                          int num21 = num17;
                          if (flag11)
                            num21 = 0;
                          if (num21 > num11)
                          {
                            num20 = (int) Math.Round(Math.Floor((double) (num20 * num11) / (double) num21));
                            num21 = num11;
                          }
                          int index13 = -1;
                          int index14;
                          int type;
                          if (num20 > 0)
                          {
                            bool quality2_1 = false;
                            bool quality3_1 = false;
                            bool quality4_1 = false;
                            bool quality5_1 = false;
                            bool quality2_2 = false;
                            bool quality3_2 = false;
                            bool quality4_2 = false;
                            bool quality5_2 = false;
                            int historical = this.game.Data.UnitObj[unr].Historical;
                            if (this.game.Data.Turn == 2)
                              quality2_1 = quality2_1;
                            if (historical > -1)
                            {
                              if (swappy)
                              {
                                if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(42) != 1)
                                  quality2_1 = true;
                                if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(43) != 1)
                                  quality3_1 = true;
                                if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(44) != 1)
                                  quality4_1 = true;
                                if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(45) != 1)
                                  quality5_1 = true;
                                if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(42) == 0)
                                  quality2_2 = true;
                                if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(43) == 0)
                                  quality3_2 = true;
                                if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(44) == 0)
                                  quality4_2 = true;
                                if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(45) == 0)
                                  quality5_2 = true;
                              }
                              else if (normal)
                              {
                                if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(42) <= 1)
                                  quality2_1 = true;
                                if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(43) <= 1)
                                  quality3_1 = true;
                                if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(44) <= 1)
                                  quality4_1 = true;
                                if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(45) <= 1)
                                  quality5_1 = true;
                              }
                            }
                            data3 = -1;
                            int num22 = -1;
                            switch (num2)
                            {
                              case 1:
                                data3 = Conversions.ToInteger(this.LIS_GetUnitSFObjNrForReturn(unr, quality2_1, quality3_1, quality4_1, quality5_1, num16, true));
                                break;
                              case 2:
                                data3 = Conversions.ToInteger(this.LIS_GetUnitSFObjNrForReturn(unr, quality2_1, quality3_1, quality4_1, quality5_1, num16, false));
                                break;
                            }
                            if (swappy)
                            {
                              num22 = data3 <= -1 ? -1 : Conversions.ToInteger(this.LIS_GetSHQSFObjNr(index11, quality2_2, quality3_2, quality4_2, quality5_2, num16, this.game.Data.SFObj[data3].People));
                              if (num22 == -1)
                                data3 = -1;
                            }
                            if (data3 > -1 && this.game.Data.UnitObj[unr].tempMaxItems.FindWeight(this.game.Data.SFTypeObj[this.game.Data.SFObj[data3].Type].ReinforcementType) < 1)
                              data3 = -1;
                            index1 = data3;
                            index14 = num22;
                            if (index1 > -1)
                              index13 = this.game.Data.SFObj[index1].Type;
                            if (index14 > -1)
                              type = this.game.Data.SFObj[index14].Type;
                            if (swappy)
                            {
                              if (type > -1)
                                num21 = this.game.Data.SFTypeObj[type].Weight * 1;
                            }
                            else if (normal && index13 > -1)
                              num21 = this.game.Data.SFTypeObj[index13].Weight * 1;
                            if (data3 > -1)
                            {
                              num20 = 1;
                              if (num14 < 1)
                                num20 = 0;
                            }
                            else
                              num20 = 0;
                          }
                          Coordinate unitBestCoordinate;
                          if (num20 > 0)
                          {
                            unitBestCoordinate = this.LIS_GetUnitBestCoordinate(this.game.Data.UnitObj[unr].tempCoords, num20, true, this.game.Data.UnitObj[index11].X, this.game.Data.UnitObj[index11].Y);
                            if (unitBestCoordinate.onmap)
                            {
                              this.AddPLog("Pickup adress: " + unitBestCoordinate.x.ToString() + "," + unitBestCoordinate.y.ToString());
                              data3 = this.LIS_GetLowestPointsOnTrajectory(unitBestCoordinate.x, unitBestCoordinate.y, this.game.Data.UnitObj[index11].X, this.game.Data.UnitObj[index11].Y);
                              if (data3 < num21)
                                num20 = 0;
                            }
                            else
                            {
                              this.AddPLog("No pickup hex found for unit.");
                              num20 = 0;
                            }
                          }
                          if (num20 > 0)
                          {
                            this.AddPLog("ReinfType: ID" + num16.ToString() + ", Qty=" + num20.ToString() + ", Already transferred: " + num18.ToString() + "/" + num14.ToString() + ", LogPtsNeed: " + num21.ToString());
                            flag10 = true;
                            this.game.Data.UnitObj[index11].AddLog(8, num16, 0, 1);
                            this.game.Data.UnitObj[unr].AddLog(3, num16, 0, 1);
                            if (swappy)
                            {
                              this.game.Data.UnitObj[index11].AddLog(18, num16, 0, 1);
                              this.game.Data.UnitObj[unr].AddLog(10, num16, 0, 1);
                              this.game.Data.UnitObj[unr].AddLog(1, num16, 0, 1);
                              this.game.Data.UnitObj[unr].AddLog(2, num16, 0, 1);
                              this.game.Data.UnitObj[index11].AddLog(11, num16, 0, 1);
                              this.game.Data.UnitObj[index11].AddLog(12, num16, 0, 1);
                            }
                            if (!swappy)
                            {
                              this.game.HandyFunctionsObj.AddTroops3(index11, index13, this.game.Data.SFObj[index1].People, 1, this.game.Data.SFObj[index1].Xp, this.game.Data.SFObj[index1].Rdn, 0, this.game.Data.SFObj[index1].Mor, vigor: this.game.Data.SFObj[index1].Vigor);
                              this.game.HandyFunctionsObj.RemoveTroops(unr, index13, this.game.Data.SFObj[index1].People, 1, -1);
                            }
                            else if (swappy)
                            {
                              this.game.HandyFunctionsObj.AddTroops3(index11, index13, this.game.Data.SFObj[index14].People, 1, this.game.Data.SFObj[index14].Xp, this.game.Data.SFObj[index14].Rdn, 0, this.game.Data.SFObj[index14].Mor, vigor: this.game.Data.SFObj[index14].Vigor);
                              this.game.HandyFunctionsObj.RemoveTroops(unr, index13, this.game.Data.SFObj[index1].People, 1, -1);
                              this.game.HandyFunctionsObj.AddTroops3(unr, type, this.game.Data.SFObj[index1].People, 1, this.game.Data.SFObj[index1].Xp, this.game.Data.SFObj[index1].Rdn, 0, this.game.Data.SFObj[index1].Mor, vigor: this.game.Data.SFObj[index1].Vigor);
                              this.game.HandyFunctionsObj.RemoveTroops(index11, type, this.game.Data.SFObj[index14].People, 1, -1);
                            }
                            SimpleList SL = new SimpleList();
                            int tid1 = this.game.Data.SFTypeObj[index13].SFTypeVar[45];
                            int tweight1 = this.game.Data.SFTypeObj[index13].SFTypeVar[52];
                            if (tweight1 > 0)
                              SL.Add(tid1, tweight1);
                            int tid2 = this.game.Data.SFTypeObj[index13].SFTypeVar[47];
                            int tweight2 = this.game.Data.SFTypeObj[index13].SFTypeVar[53];
                            if (tweight2 > 0)
                              SL.Add(tid2, tweight2);
                            int tid3 = this.game.Data.SFTypeObj[index13].SFTypeVar[50];
                            int tweight3 = this.game.Data.SFTypeObj[index13].SFTypeVar[54];
                            if (tweight3 > 0)
                              SL.Add(tid3, tweight3);
                            if (this.game.Data.UnitObj[unr].items.list.CanRemoveWeight(ref SL))
                            {
                              this.game.Data.UnitObj[unr].items.list.RemoveWeight(ref SL);
                              this.game.Data.UnitObj[index11].items.list.AddWeight(ref SL);
                            }
                            if (swappy)
                            {
                              int tid4 = this.game.Data.SFTypeObj[type].SFTypeVar[45];
                              int tweight4 = this.game.Data.SFTypeObj[type].SFTypeVar[52];
                              if (tweight4 > 0)
                                SL.Add(tid4, tweight4);
                              int tid5 = this.game.Data.SFTypeObj[type].SFTypeVar[47];
                              int tweight5 = this.game.Data.SFTypeObj[type].SFTypeVar[53];
                              if (tweight5 > 0)
                                SL.Add(tid5, tweight5);
                              int tid6 = this.game.Data.SFTypeObj[type].SFTypeVar[50];
                              int tweight6 = this.game.Data.SFTypeObj[type].SFTypeVar[54];
                              if (tweight6 > 0)
                                SL.Add(tid6, tweight6);
                              if (this.game.Data.UnitObj[index11].items.list.CanRemoveWeight(ref SL))
                              {
                                this.game.Data.UnitObj[index11].items.list.RemoveWeight(ref SL);
                                this.game.Data.UnitObj[unr].items.list.AddWeight(ref SL);
                              }
                            }
                            this.game.Data.UnitObj[unr].tempHandledItems.AddWeight(num16, num20);
                            num11 -= num21;
                            this.game.Data.UnitObj[unr].AddLog(506, 1, 0, num21);
                            bool ok = this.LIS_RemovePointsFromTrajectory(unitBestCoordinate.x, unitBestCoordinate.y, num21).OK;
                            this.LIS_AddOrganicPointsToTrajectory(unitBestCoordinate.x, unitBestCoordinate.y, num21, unitBestCoordinate.data2, unr);
                            this.AddPLog("--Removed " + num21.ToString() + " from trajectory " + unitBestCoordinate.x.ToString() + "," + unitBestCoordinate.y.ToString() + " <> " + this.game.Data.UnitObj[index11].Name);
                            if (ok & num21 > 0)
                            {
                              this.AddPLog("--0 reached--");
                              this.game.HandyFunctionsObj.MakeMovePredictionLIS(this.game.Data.UnitObj[index11].X, this.game.Data.UnitObj[index11].Y, this.game.Data.UnitObj[index11].Map);
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
              if (flag10)
                flag9 = true;
            }
            if (num6 < 100)
              flag8 = true;
          }
          int counter3 = simpleList.Counter;
          for (int index15 = 0; index15 <= counter3; ++index15)
          {
            int index16 = simpleList.Id[index15];
            data3 = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index16].X, this.game.Data.UnitObj[index16].Y].LIShistory[6] - this.game.Data.UnitObj[index16].tempLisStartHistory;
            this.AddPLog("SHQ " + this.game.Data.UnitObj[index16].Name + " total LIS use " + data3.ToString() + " pts.");
            this.game.Data.UnitObj[index16].AddLog(506, 1, 0, data3);
          }
        }
        ++num2;
      }
      while (num2 <= 2);
      this.WritePLog("LIS_AutoReinforceRETURNS_Log");
      this.LIS_SetNetwork(true);
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
        this.game.Data.UnitObj[index].tempComplexCoords = (ComplexCoordList) null;
    }

    public object LIS_GetSHQSFObjNr(
      int shqNr,
      bool quality2,
      bool quality3,
      bool quality4,
      bool quality5,
      int reinfType,
      int ppl)
    {
      SimpleList simpleList1 = new SimpleList();
      SimpleList simpleList2 = new SimpleList();
      int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[412]));
      int id = this.game.Data.RegimeObj[this.game.Data.UnitObj[shqNr].Regime].id;
      int sfCount = this.game.Data.UnitObj[shqNr].SFCount;
      for (int index = 0; index <= sfCount; ++index)
      {
        int sf = this.game.Data.UnitObj[shqNr].SFList[index];
        int type = this.game.Data.SFObj[sf].Type;
        int qty = this.game.Data.SFObj[sf].Qty;
        int reinforcementType = this.game.Data.SFTypeObj[type].ReinforcementType;
        int people = this.game.Data.SFObj[sf].People;
        bool flag1 = false;
        if (this.game.Data.PeopleObj[people].tv0 == this.game.Data.PeopleObj[ppl].tv0 && this.game.Data.PeopleObj[people].tv1 > 0 & this.game.Data.PeopleObj[ppl].tv1 > 0 & this.game.Data.PeopleObj[people].tv1 < 9 & this.game.Data.PeopleObj[ppl].tv1 < 9 | this.game.Data.PeopleObj[people].tv1 > 10 & this.game.Data.PeopleObj[ppl].tv1 > 10 & this.game.Data.PeopleObj[people].tv1 < 19 & this.game.Data.PeopleObj[ppl].tv1 < 19)
          flag1 = true;
        if (Strings.InStr(this.game.Data.PeopleObj[people].Name.ToLower(), "robotic") > 0 && this.game.Data.PeopleObj[people].tv1 > 0 & this.game.Data.PeopleObj[ppl].tv1 > 0 & this.game.Data.PeopleObj[people].tv1 < 9 & this.game.Data.PeopleObj[ppl].tv1 < 9 | this.game.Data.PeopleObj[people].tv1 > 10 & this.game.Data.PeopleObj[ppl].tv1 > 10 & this.game.Data.PeopleObj[people].tv1 < 19 & this.game.Data.PeopleObj[ppl].tv1 < 19)
          flag1 = true;
        if (flag1 && reinforcementType == reinfType)
        {
          bool flag2 = false;
          int integer = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].GetData2(0, this.game.Data.SFTypeObj[type].Id, 1, id, 2));
          if (integer == 0)
            flag2 = true;
          if (integer == 2 & quality2)
            flag2 = true;
          if (integer == 3 & quality3)
            flag2 = true;
          if (integer == 4 & quality4)
            flag2 = true;
          if (integer == 5 & quality5)
            flag2 = true;
          if (this.game.Data.PeopleObj[people].tv1 > 10 & this.game.Data.PeopleObj[ppl].tv1 > 10 & this.game.Data.PeopleObj[people].tv1 < 19 & this.game.Data.PeopleObj[ppl].tv1 < 19)
            flag2 = true;
          if (flag2)
          {
            int num = this.game.Data.ReinfId[reinforcementType];
            int weight = this.game.Data.SFTypeObj[type].Weight;
            simpleList1.AddWeight(sf, DrawMod.RandyNumber.Next(0, qty + 1));
          }
        }
      }
      simpleList1.ReverseSortHighSpeed();
      return simpleList1.Counter == -1 ? (object) -1 : (object) simpleList1.Id[0];
    }

    public object LIS_GetUnitSFObjNrForReturn(
      int unr,
      bool quality2,
      bool quality3,
      bool quality4,
      bool quality5,
      int reinfType,
      bool checkQuality)
    {
      SimpleList simpleList1 = new SimpleList();
      SimpleList simpleList2 = new SimpleList();
      int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[412]));
      int id = this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].id;
      int sfCount = this.game.Data.UnitObj[unr].SFCount;
      for (int index = 0; index <= sfCount; ++index)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index];
        int type = this.game.Data.SFObj[sf].Type;
        int qty = this.game.Data.SFObj[sf].Qty;
        int reinforcementType = this.game.Data.SFTypeObj[type].ReinforcementType;
        if (reinforcementType == reinfType)
        {
          bool flag = true;
          int integer = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].GetData2(0, this.game.Data.SFTypeObj[type].Id, 1, id, 2));
          if (integer == 0)
            flag = false;
          if (integer == 2 & quality2)
            flag = false;
          if (integer == 3 & quality3)
            flag = false;
          if (integer == 4 & quality4)
            flag = false;
          if (integer == 5 & quality5)
            flag = false;
          if (!checkQuality)
            flag = true;
          if (flag)
          {
            int num = this.game.Data.ReinfId[reinforcementType];
            int weight = this.game.Data.SFTypeObj[type].Weight;
            simpleList1.AddWeight(sf, DrawMod.RandyNumber.Next(0, qty + 1));
          }
        }
      }
      simpleList1.ReverseSortHighSpeed();
      return simpleList1.Counter == -1 ? (object) -1 : (object) simpleList1.Id[0];
    }

    public void LIS_LocationReturns(bool freeOfCost) => this.LIS_UniversalSupplyAndReturn(1, freeOfCost);

    public void LIS_UniversalSupplyAndReturn(int mode, bool freeOfCost)
    {
      int num1 = 20;
      bool flag1;
      if (mode == 1)
        flag1 = true;
      bool flag2;
      if (mode == 2)
        flag2 = true;
      int id = (int) Math.Round((double) this.game.Data.RuleVar[404]);
      int stringListById = this.game.HandyFunctionsObj.GetStringListByID(id);
      int[] numArray1 = new int[this.game.Data.StringListObj[stringListById].GetHighestValue(0) + 1 + 1];
      int length = this.game.Data.StringListObj[stringListById].Length;
      for (int index = 0; index <= length; ++index)
        numArray1[(int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index, 0]))] = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index, 3]));
      this.plogcounter = -1;
      if (flag1)
        this.AddPLog("LIS_LocationReturns");
      if (flag2)
        this.AddPLog("LIS_LocationSupply");
      this.AddPLog("");
      if (this.game.Data.Turn == 2)
        ;
      SimpleList simpleList = new SimpleList();
      int unitCounter = this.game.Data.UnitCounter;
      for (int tid = 0; tid <= unitCounter; ++tid)
      {
        if (this.game.Data.UnitObj[tid].IsHQ & this.game.Data.UnitObj[tid].Regime == this.game.Data.Turn)
        {
          int historical = this.game.Data.UnitObj[tid].Historical;
          if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].Type == 8)
          {
            bool flag3 = false;
            int locCounter = this.game.Data.LocCounter;
            for (int index = 0; index <= locCounter; ++index)
            {
              if (this.game.Data.LocObj[index].HQ == tid)
              {
                flag3 = true;
                break;
              }
            }
            if (flag3)
            {
              if (Information.IsNothing((object) this.game.Data.UnitObj[tid].items))
                this.game.Data.UnitObj[tid].items = new ItemList();
              this.game.Data.UnitObj[tid].tempLisStartHistory = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[tid].X, this.game.Data.UnitObj[tid].Y].LIShistory[6];
              simpleList.Add(tid, 1);
            }
          }
        }
      }
      int locCounter1 = this.game.Data.LocCounter;
      for (int index = 0; index <= locCounter1; ++index)
        this.game.Data.LocObj[index].tempHandledItems = new SimpleList();
      bool flag4 = true;
      int num2 = 0;
      int num3 = 0;
      while (flag4)
      {
        ++num2;
        num3 += num1;
        flag4 = false;
        bool flag5 = true;
        this.AddPLog(num2.ToString() + ".Superloop. CurMaxPercent=" + num3.ToString());
        int num4 = 0;
        while (flag5)
        {
          flag5 = false;
          ++num4;
          this.AddPLog("ShqLoop");
          int counter1 = simpleList.Counter;
          bool flag6;
          for (int index1 = 0; index1 <= counter1; ++index1)
          {
            int index2 = simpleList.Id[index1];
            int num5 = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y].LISpoints[6] + this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y].LIShistory[6];
            if (this.game.Data.Turn == 2 & flag1)
              ;
            int num6 = 0;
            if (flag2)
              num6 = this.game.Data.UnitObj[index2].lisInstructions.FindWeight(2);
            if (flag1)
              num6 = this.game.Data.UnitObj[index2].lisInstructions.FindWeight(2) + this.game.Data.UnitObj[index2].lisInstructions.FindWeight(3) + this.game.Data.UnitObj[index2].lisInstructions.FindWeight(5);
            if (num6 > 100)
              num6 = 100;
            int num7 = 0;
            if (mode == 2)
              num7 = this.game.Data.UnitObj[index2].lisInstructions.FindWeight(14);
            if (mode == 1)
              num7 = this.game.Data.UnitObj[index2].lisInstructions.FindWeight(15);
            bool flag7 = false;
            if (this.game.EventRelatedObj.Helper_AirEnabled())
              flag7 = true;
            if (num7 < 1)
              flag7 = false;
            int weight = this.game.Data.UnitObj[index2].lisInstructions.FindWeight(12);
            this.AddPLog("SHQ Max Percentage Allowed " + num6.ToString() + "%");
            int num8 = (int) Math.Round((double) (num5 * num6) / 100.0);
            id = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y].LIShistory[6] - this.game.Data.UnitObj[index2].tempLisStartHistory;
            int data3_1 = num8 - id;
            if (data3_1 < 1)
              data3_1 = 0;
            if (num4 == 1 & num2 == 1)
            {
              if (this.game.Data.Turn == 2)
                index1 = index1;
              if (flag1)
                this.game.Data.UnitObj[index2].AddLog(605, 1, 0, data3_1);
              else
                this.game.Data.UnitObj[index2].AddLog(602, 1, 0, data3_1);
            }
            if (0 > data3_1)
              data3_1 = 0;
            int num9 = (int) Math.Round((double) (data3_1 * num3) / 100.0);
            int[,] numArray2 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
            this.game.HandyFunctionsObj.MakeMovePredictionLIS(this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y, this.game.Data.UnitObj[index2].Map, addHistoryToCurrent: true);
            int mapWidth = this.game.Data.MapObj[0].MapWidth;
            for (int index3 = 0; index3 <= mapWidth; ++index3)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index4 = 0; index4 <= mapHeight; ++index4)
                numArray2[index3, index4] = this.game.EditObj.TempValue[0].Value[index3, index4];
            }
            if (flag7 & num7 == 1)
            {
              if (!freeOfCost)
                this.game.HandyFunctionsObj.MakeMovePredictionLIS(this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y, this.game.Data.UnitObj[index2].Map, useAirBridge: true, maxDam: weight);
            }
            else if (!freeOfCost)
              this.game.HandyFunctionsObj.MakeMovePredictionLIS(this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y, this.game.Data.UnitObj[index2].Map);
            this.AddPLog(num2.ToString() + "." + num4.ToString() + ".Shq: " + this.game.Data.UnitObj[index2].Name + ", CurrentLisAvailable: " + num9.ToString());
            flag6 = true;
            int num10 = 0;
            int num11 = 0;
            while (flag6)
            {
              flag6 = false;
              ++num10;
              num11 += 10;
              if (num11 > 100)
                num11 = 100;
              if (num11 < 100)
                flag6 = true;
              int locCounter2 = this.game.Data.LocCounter;
              for (int index5 = 0; index5 <= locCounter2; ++index5)
              {
                if (this.game.Data.LocObj[index5].HQ == index2)
                {
                  bool flag8 = false;
                  if (this.game.Data.UnitObj[index2].X == this.game.Data.LocObj[index5].X & this.game.Data.UnitObj[index2].Y == this.game.Data.LocObj[index5].Y)
                    flag8 = true;
                  this.AddPLog(num2.ToString() + "." + num4.ToString() + "." + num10.ToString() + ".Loc: " + this.game.Data.LocObj[index5].Name);
                  if (!Information.IsNothing((object) this.game.Data.LocObj[index5].tempRequestItems))
                  {
                    if (this.game.Data.Turn == 2)
                      index1 = index1;
                    int counter2 = this.game.Data.LocObj[index5].tempRequestItems.Counter;
                    for (int index6 = 0; index6 <= counter2; ++index6)
                    {
                      int num12;
                      if (!freeOfCost & num10 == 1 & num4 == 1 & num2 == 1)
                      {
                        int data1 = this.game.Data.LocObj[index5].tempRequestItems.Id[index6];
                        int data3_2 = this.game.Data.LocObj[index5].tempRequestItems.Weight[index6];
                        num12 = numArray1[data1];
                        if (flag1)
                        {
                          this.game.Data.LocObj[index5].AddLog(202, data1, 0, data3_2);
                          this.game.Data.UnitObj[index2].AddLog(212, data1, 0, data3_2);
                        }
                        else
                        {
                          this.game.Data.LocObj[index5].AddLog(201, data1, 0, data3_2);
                          this.game.Data.UnitObj[index2].AddLog(211, data1, 0, data3_2);
                        }
                      }
                      if (num9 >= num12 | freeOfCost | flag8)
                      {
                        int index7 = this.game.Data.LocObj[index5].tempRequestItems.Id[index6];
                        int num13 = this.game.Data.LocObj[index5].tempRequestItems.Weight[index6];
                        num12 = numArray1[index7];
                        id = this.game.Data.LocObj[index5].tempHandledItems.FindNr(index7);
                        int num14 = 0;
                        if (id > -1)
                          num14 = this.game.Data.LocObj[index5].tempHandledItems.Weight[id];
                        int num15 = (int) Math.Round(Math.Ceiling((double) num13 * ((double) num3 / 100.0) * ((double) num11 / 100.0)));
                        if (num13 > 0 & num15 == 0)
                          num15 = 1;
                        int num16 = num15 - num14;
                        if (flag7 & !flag8 && num12 < 1 && this.LIS_HasAirBridgeOnTrajectory(this.game.Data.LocObj[index5].X, this.game.Data.LocObj[index5].Y, this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y))
                        {
                          num12 = 1;
                          if (this.IsItemMaximizer(index7))
                            num16 = 0;
                        }
                        int num17 = num16;
                        if (flag8)
                          num17 = 0;
                        if (!freeOfCost && num17 > num9)
                        {
                          num16 = num12 <= 0 ? num13 - num14 : (int) Math.Round(Math.Floor((double) (num16 * num9) / (double) (num12 * num17)));
                          num17 = num9;
                        }
                        if (!flag1)
                        {
                          id = this.game.Data.UnitObj[index2].items.list.FindNr(index7);
                          if (id > -1)
                          {
                            int num18 = this.game.Data.UnitObj[index2].items.list.Weight[id];
                            if (num18 < 0)
                              num18 = 0;
                            if (num16 > num18)
                              num16 = num18;
                          }
                          else
                            num16 = 0;
                        }
                        if (!freeOfCost & num16 > 0 & !flag8)
                        {
                          id = this.LIS_GetLowestPointsOnTrajectory(this.game.Data.LocObj[index5].X, this.game.Data.LocObj[index5].Y, this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y, true);
                          if (num12 < 1 | flag8 && id < 0 && numArray2[this.game.Data.LocObj[index5].X, this.game.Data.LocObj[index5].Y] > 0)
                            id = 1;
                          if (id < 0)
                          {
                            id = 0;
                            if (num12 == 0)
                              id = id;
                            num16 = 0;
                          }
                          else if (id < num17)
                          {
                            if (num12 > 0)
                            {
                              num16 = (int) Math.Round(Math.Floor((double) (num16 * id) / (double) (num12 * num17)));
                              if (num12 == 0)
                                id = id;
                            }
                            else
                              num16 = num16;
                            num17 = id;
                          }
                          else if (num12 > 0 & !flag8 & id < 1)
                          {
                            id = 0;
                            num16 = 0;
                          }
                        }
                        if (num16 > 0)
                        {
                          if (this.game.Data.Turn == 2 & mode == 2)
                            index1 = index1;
                          this.AddPLog("Item: ID" + index7.ToString() + ", Qty=" + num16.ToString() + ", Already transferred: " + num14.ToString() + "/" + num13.ToString() + ", LogPtsNeed: " + num17.ToString());
                          flag6 = true;
                          if (this.game.Data.Turn == 1)
                            id = id;
                          if (this.game.Data.LocObj[index5].X == 14 & this.game.Data.LocObj[index5].Y == 3)
                            index5 = index5;
                          int num19 = num16;
                          bool ok;
                          if (!(flag8 | num12 < 1))
                          {
                            if (flag7)
                            {
                              OrderResult orderResult = this.LIS_RemovePointsFromTrajectory(this.game.Data.LocObj[index5].X, this.game.Data.LocObj[index5].Y, num17 * num12);
                              ok = orderResult.OK;
                              if (orderResult.Data > 0)
                              {
                                int randomizedRoundingDam = this.game.HandyFunctionsObj.Air_GetRandomizedRoundingDam(num19, orderResult.Data);
                                num19 -= randomizedRoundingDam;
                                if (flag2)
                                {
                                  this.game.Data.LocObj[index5].AddLog(107, index7, 0, randomizedRoundingDam);
                                  this.game.Data.UnitObj[index2].AddLog(108, index7, 0, randomizedRoundingDam);
                                }
                                else if (flag1)
                                {
                                  this.game.Data.LocObj[index5].AddLog(108, index7, 0, randomizedRoundingDam);
                                  this.game.Data.UnitObj[index2].AddLog(109, index7, 0, randomizedRoundingDam);
                                }
                              }
                            }
                            else
                              ok = this.LIS_RemovePointsFromTrajectory(this.game.Data.LocObj[index5].X, this.game.Data.LocObj[index5].Y, num17 * num12).OK;
                          }
                          if (flag1)
                          {
                            this.game.Data.UnitObj[index2].items.list.AddWeight(index7, num19);
                            this.game.Data.LocObj[index5].items.list.RemoveWeight(index7, num16);
                            if (!freeOfCost)
                              this.game.Data.UnitObj[index2].AddLog(101, index7, 0, num19);
                            if (!freeOfCost)
                              this.game.Data.LocObj[index5].AddLog(102, index7, 0, num16);
                            if (!freeOfCost)
                              this.game.Data.LocObj[index5].AddLog(505, 1, 0, num17 * num12);
                          }
                          else if (flag2)
                          {
                            this.game.Data.UnitObj[index2].items.list.RemoveWeight(index7, num16);
                            this.game.Data.LocObj[index5].items.list.AddWeight(index7, num19);
                            if (!freeOfCost)
                              this.game.Data.UnitObj[index2].AddLog(102, index7, 0, num16);
                            if (!freeOfCost)
                              this.game.Data.LocObj[index5].AddLog(101, index7, 0, num16);
                            if (!freeOfCost)
                              this.game.Data.LocObj[index5].AddLog(502, 1, 0, num17 * num12);
                          }
                          this.game.Data.LocObj[index5].tempHandledItems.AddWeight(index7, num16);
                          if (!freeOfCost)
                          {
                            num9 -= num17 * num12;
                            bool flag9 = false;
                            this.AddPLog("--Removed " + (num17 * num12).ToString() + " from trajectory " + this.game.Data.LocObj[index5].Name + " > " + this.game.Data.UnitObj[index2].Name);
                            if (flag9 & num17 > 0)
                            {
                              this.AddPLog("--0 reached--");
                              if (flag7)
                                this.game.HandyFunctionsObj.MakeMovePredictionLIS(this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y, this.game.Data.UnitObj[index2].Map, useAirBridge: true, maxDam: weight);
                              else
                                this.game.HandyFunctionsObj.MakeMovePredictionLIS(this.game.Data.UnitObj[index2].X, this.game.Data.UnitObj[index2].Y, this.game.Data.UnitObj[index2].Map);
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
          if (flag6)
            flag5 = true;
        }
        if (num3 < 100)
          flag4 = true;
      }
      int counter = simpleList.Counter;
      for (int index8 = 0; index8 <= counter; ++index8)
      {
        int index9 = simpleList.Id[index8];
        int data3 = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[index9].X, this.game.Data.UnitObj[index9].Y].LIShistory[6] - this.game.Data.UnitObj[index9].tempLisStartHistory;
        this.AddPLog("SHQ " + this.game.Data.UnitObj[index9].Name + " total LIS use " + data3.ToString() + " pts.");
        if (flag2)
          this.game.Data.UnitObj[index9].AddLog(502, 1, 0, data3);
        if (flag1)
          this.game.Data.UnitObj[index9].AddLog(505, 1, 0, data3);
      }
      if (flag2)
        this.WritePLog("LIS_LocationSupply_Log");
      if (flag1 & !freeOfCost)
        this.WritePLog("LIS_LocationReturns_Log");
      if (flag1 & freeOfCost)
        this.WritePLog("LIS_LocationReturns_Free_Log");
      if (!freeOfCost)
        this.LIS_SetNetwork(true);
      if (freeOfCost || !this.game.EventRelatedObj.Helper_AirEnabled())
        return;
      if (flag2)
        this.game.HandyFunctionsObj.Air_LogUpdateForAll(this.game.Data.Turn, "", " Air Points left after Zone Supply");
      if (!flag1)
        return;
      this.game.HandyFunctionsObj.Air_LogUpdateForAll(this.game.Data.Turn, "", " Air Points left after Zone Pickups");
    }

    public void LIS_AddOrganicPointsToTrajectory(
      int ox,
      int oy,
      int pts,
      int percentageWholeTrajectory,
      int unr)
    {
      bool flag = true;
      int slot1 = this.game.Data.UnitObj[unr].tempComplexCoords.FindSlot(ox, oy, 0);
      int slot2 = this.game.Data.UnitObj[unr].tempCoords.FindSlot(ox, oy, 0);
      if (slot1 == -1 || slot2 == -1)
        return;
      CoordList coordList = new CoordList();
      for (int counter = this.game.Data.UnitObj[unr].tempComplexCoords.coordList[slot1].counter; counter >= 0; counter += -1)
        coordList.AddCoord(this.game.Data.UnitObj[unr].tempComplexCoords.coordList[slot1].coord[counter].x, this.game.Data.UnitObj[unr].tempComplexCoords.coordList[slot1].coord[counter].y, this.game.Data.UnitObj[unr].tempComplexCoords.coordList[slot1].coord[counter].map, this.game.Data.UnitObj[unr].tempComplexCoords.coordList[slot1].coord[counter].data1, this.game.Data.UnitObj[unr].tempComplexCoords.coordList[slot1].coord[counter].data2);
      coordList.AddCoord(ox, oy, 0, 0, this.game.Data.UnitObj[unr].tempCoords.coord[slot2].data2);
      int num1 = (int) Math.Round(Math.Ceiling((double) coordList.counter / 2.0));
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        int index2 = coordList.counter - index1;
        int data2 = coordList.coord[index1].data2;
        coordList.coord[index1].data2 = coordList.coord[index2].data2;
        coordList.coord[index2].data2 = data2;
      }
      int num2 = percentageWholeTrajectory;
      Coordinate coordinate1;
      coordinate1.x = coordList.coord[0].x;
      coordinate1.y = coordList.coord[0].y;
      coordinate1.map = 0;
      coordinate1.onmap = true;
      if (this.game.Data.Turn == 2)
        ;
      int counter1 = coordList.counter;
      for (int index3 = 1; index3 <= counter1; ++index3)
      {
        Coordinate coordinate2 = coordList.coord[index3];
        int data2 = coordinate2.data2;
        if (!coordinate2.onmap)
          break;
        int index4 = this.game.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0) - 1;
        int index5 = index4 + 3;
        if (index5 > 5)
          index5 -= 6;
        if (flag)
        {
          int num3 = (int) Math.Round((double) (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISorganic[6] * this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISorganicPercentage[6] + pts * num2) / (double) (pts + this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISorganic[6]));
          this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISorganicPercentage[6] = num3;
          int[] liSorganic = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISorganic;
          int[] numArray = liSorganic;
          int index6 = 6;
          int index7 = index6;
          int num4 = liSorganic[index6] + pts;
          numArray[index7] = num4;
        }
        int num5 = (int) Math.Round((double) (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISorganic[index4] * this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISorganicPercentage[index4] + pts * num2) / (double) (pts + this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISorganic[index4]));
        this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISorganicPercentage[index4] = num5;
        int[] liSorganic1 = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISorganic;
        int[] numArray1 = liSorganic1;
        int index8 = index4;
        int index9 = index8;
        int num6 = liSorganic1[index8] + pts;
        numArray1[index9] = num6;
        int num7 = (int) Math.Round((double) (this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISorganic[index5] * this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISorganicPercentage[index5] + pts * num2) / (double) (pts + this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISorganic[index5]));
        this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISorganicPercentage[index5] = num7;
        int[] liSorganic2 = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISorganic;
        int[] numArray2 = liSorganic2;
        int index10 = index5;
        int index11 = index10;
        int num8 = liSorganic2[index10] + pts;
        numArray2[index11] = num8;
        int num9 = (int) Math.Round((double) (this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISorganic[6] * this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISorganicPercentage[6] + pts * data2) / (double) (pts + this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISorganic[6]));
        this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISorganicPercentage[6] = num9;
        int[] liSorganic3 = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISorganic;
        int[] numArray3 = liSorganic3;
        int index12 = 6;
        int index13 = index12;
        int num10 = liSorganic3[index12] + pts;
        numArray3[index13] = num10;
        flag = false;
        coordinate1 = coordinate2;
        num2 = data2;
      }
    }

    public OrderResult LIS_RemovePointsFromTrajectory(
      int ox,
      int oy,
      int pts,
      int unrForDam = -1)
    {
      bool flag1 = false;
      bool flag2 = true;
      int num1 = 0;
      OrderResult orderResult = new OrderResult();
      orderResult.OK = false;
      orderResult.Data = 0;
      if (pts <= 0)
        return orderResult;
      Coordinate coordinate1;
      coordinate1.x = ox;
      coordinate1.y = oy;
      Coordinate coordinate2;
      for (coordinate1.onmap = true; coordinate1.onmap; coordinate1 = coordinate2)
      {
        coordinate2 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
        if (coordinate2.onmap)
        {
          int index1 = this.game.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0) - 1;
          bool flag3 = false;
          int index2;
          if (index1 >= 0 & index1 <= 5)
          {
            index2 = index1 + 3;
            if (index2 > 5)
              index2 -= 6;
          }
          else
          {
            flag3 = true;
            if (unrForDam > -1)
            {
              int damForAirBridge = this.game.HandyFunctionsObj.Air_GetDamForAirBridge(coordinate2.x, coordinate2.y, coordinate1.x, coordinate1.y);
              this.game.HandyFunctionsObj.Air_applyDamToUnit(unrForDam, damForAirBridge);
              if (num1 > 0)
                num1 += (int) Math.Round((double) ((100 - num1) * damForAirBridge) / 100.0);
              else
                num1 += damForAirBridge;
            }
            if (this.game.HandyFunctionsObj.Air_removeLisFromAirBridge(coordinate2.x, coordinate2.y, coordinate1.x, coordinate1.y, pts))
              flag1 = true;
          }
          if (flag2)
          {
            int[] liSpoints = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints;
            int[] numArray = liSpoints;
            int index3 = 6;
            int index4 = index3;
            int num2 = liSpoints[index3] - pts;
            numArray[index4] = num2;
          }
          if (!flag3)
          {
            int[] liSpoints = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints;
            int[] numArray = liSpoints;
            int index5 = index1;
            int index6 = index5;
            int num3 = liSpoints[index5] - pts;
            numArray[index6] = num3;
          }
          if (!flag3)
          {
            int[] liSpoints = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints;
            int[] numArray = liSpoints;
            int index7 = index2;
            int index8 = index7;
            int num4 = liSpoints[index7] - pts;
            numArray[index8] = num4;
          }
          int[] liSpoints1 = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints;
          int[] numArray1 = liSpoints1;
          int index9 = 6;
          int index10 = index9;
          int num5 = liSpoints1[index9] - pts;
          numArray1[index10] = num5;
          if (flag2)
          {
            int[] liShistory = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIShistory;
            int[] numArray2 = liShistory;
            int index11 = 6;
            int index12 = index11;
            int num6 = liShistory[index11] + pts;
            numArray2[index12] = num6;
          }
          if (!flag3)
          {
            int[] liShistory = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIShistory;
            int[] numArray3 = liShistory;
            int index13 = index1;
            int index14 = index13;
            int num7 = liShistory[index13] + pts;
            numArray3[index14] = num7;
          }
          if (!flag3)
          {
            int[] liShistory = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LIShistory;
            int[] numArray4 = liShistory;
            int index15 = index2;
            int index16 = index15;
            int num8 = liShistory[index15] + pts;
            numArray4[index16] = num8;
          }
          int[] liShistory1 = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LIShistory;
          int[] numArray5 = liShistory1;
          int index17 = 6;
          int index18 = index17;
          int num9 = liShistory1[index17] + pts;
          numArray5[index18] = num9;
          if (flag2 & this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[6] <= 0)
            flag1 = true;
          if (!flag3 && this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[index1] <= 0)
            flag1 = true;
          if (!flag3 && this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints[index2] <= 0)
            flag1 = true;
          if (this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints[6] <= 0)
            flag1 = true;
          flag2 = false;
        }
        else
          break;
      }
      return new OrderResult() { OK = flag1, Data = num1 };
    }

    public Coordinate LIS_GetUnitBestCoordinate(
      CoordList CL,
      int lisPtsNeeded,
      bool lowestOnTrajectCheck = false,
      int shqX = -1,
      int shqY = -1)
    {
      int num1 = 9999999;
      int num2 = 0;
      int num3 = 0;
      Coordinate unitBestCoordinate;
      unitBestCoordinate.x = -1;
      unitBestCoordinate.y = -1;
      unitBestCoordinate.onmap = false;
      if (lisPtsNeeded < 1)
        lisPtsNeeded = 1;
      if (this.game.EventRelatedObj.Helper_AirEnabled())
        ;
      if (Information.IsNothing((object) CL))
        return unitBestCoordinate;
      if (lowestOnTrajectCheck && this.game.Data.RegimeObj[this.game.Data.Turn].AI)
        lowestOnTrajectCheck = false;
      if (!lowestOnTrajectCheck)
      {
        int counter1 = CL.counter;
        for (int index = 0; index <= counter1; ++index)
        {
          if (this.game.Data.MapObj[0].HexObj[CL.coord[index].x, CL.coord[index].y].LISpoints[6] >= lisPtsNeeded && CL.coord[index].data2 > num2 | CL.coord[index].data2 == num2 & this.game.Data.MapObj[0].HexObj[CL.coord[index].x, CL.coord[index].y].LISpoints[6] > num3)
          {
            num1 = CL.coord[index].data1;
            num2 = CL.coord[index].data2;
            num3 = this.game.Data.MapObj[0].HexObj[CL.coord[index].x, CL.coord[index].y].LISpoints[6];
            unitBestCoordinate = CL.coord[index] with
            {
              onmap = true
            };
          }
        }
        if (!unitBestCoordinate.onmap & lisPtsNeeded > 1)
        {
          int counter2 = CL.counter;
          for (int index = 0; index <= counter2; ++index)
          {
            if (this.game.Data.MapObj[0].HexObj[CL.coord[index].x, CL.coord[index].y].LISpoints[6] >= 1 && CL.coord[index].data1 < num1)
            {
              num1 = CL.coord[index].data1;
              unitBestCoordinate = CL.coord[index] with
              {
                onmap = true
              };
            }
          }
        }
      }
      else
      {
        int counter3 = CL.counter;
        int data1;
        for (int index = 0; index <= counter3; ++index)
        {
          int pointsOnTrajectory = this.LIS_GetLowestPointsOnTrajectory(CL.coord[index].x, CL.coord[index].y, shqX, shqY, true);
          int num4;
          if (pointsOnTrajectory >= lisPtsNeeded && CL.coord[index].data2 > num2 | CL.coord[index].data2 == num2 & pointsOnTrajectory > num3 | pointsOnTrajectory > 0 & CL.coord[index].data2 > 0 & num4 == 1)
          {
            data1 = CL.coord[index].data1;
            num2 = CL.coord[index].data2;
            num3 = pointsOnTrajectory;
            num4 = 0;
            if (this.game.EditObj.TempCameFrom[0].Value[CL.coord[index].x, CL.coord[index].y].data2 > 0 && this.game.EditObj.TempCameFrom[0].Value[CL.coord[index].x, CL.coord[index].y].data2 < 999)
              num4 = 1;
            unitBestCoordinate = CL.coord[index] with
            {
              onmap = true
            };
          }
        }
        if (!unitBestCoordinate.onmap & lisPtsNeeded > 1)
        {
          int counter4 = CL.counter;
          for (int index = 0; index <= counter4; ++index)
          {
            int pointsOnTrajectory = this.LIS_GetLowestPointsOnTrajectory(CL.coord[index].x, CL.coord[index].y, shqX, shqY, true);
            if (pointsOnTrajectory >= 1 && CL.coord[index].data2 > num2 | CL.coord[index].data2 == num2 & pointsOnTrajectory > num3)
            {
              data1 = CL.coord[index].data1;
              num2 = CL.coord[index].data2;
              num3 = pointsOnTrajectory;
              unitBestCoordinate = CL.coord[index] with
              {
                onmap = true
              };
            }
          }
        }
      }
      return unitBestCoordinate;
    }

    public int LIS_GetLowestPointsOnTrajectory(
      int ox,
      int oy,
      int tarX,
      int tarY,
      bool verifyTargetReached = false)
    {
      bool flag1 = true;
      int pointsOnTrajectory = 9999999;
      bool flag2 = false;
      Coordinate coordinate1;
      coordinate1.x = ox;
      coordinate1.y = oy;
      coordinate1.onmap = true;
      while (coordinate1.onmap)
      {
        Coordinate coordinate2 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
        if (coordinate2.onmap)
        {
          int index1 = this.game.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0) - 1;
          bool flag3 = false;
          int index2;
          if (index1 >= 0 & index1 <= 5)
          {
            index2 = index1 + 3;
            if (index2 > 5)
              index2 -= 6;
          }
          else
          {
            flag3 = true;
            int integer = Conversions.ToInteger(this.game.HandyFunctionsObj.Air_getLisFromAirBridge(coordinate2.x, coordinate2.y, coordinate1.x, coordinate1.y));
            if (integer < pointsOnTrajectory)
              pointsOnTrajectory = integer;
          }
          if (flag1 & this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[6] < pointsOnTrajectory)
            pointsOnTrajectory = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[6];
          if (!flag3)
          {
            if (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[index1] < pointsOnTrajectory)
              pointsOnTrajectory = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[index1];
            if (this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints[index2] < pointsOnTrajectory)
              pointsOnTrajectory = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints[index2];
          }
          if (this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints[6] < pointsOnTrajectory)
            pointsOnTrajectory = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints[6];
          flag1 = false;
          coordinate1 = coordinate2;
          if (coordinate1.x == tarX & coordinate1.y == tarY)
            flag2 = true;
        }
        else
        {
          if (coordinate1.x == tarX & coordinate1.y == tarY)
            flag2 = true;
          if (ox == coordinate1.x & oy == coordinate1.y & flag1)
          {
            pointsOnTrajectory = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[6];
            break;
          }
          break;
        }
      }
      if (pointsOnTrajectory >= 999999)
        pointsOnTrajectory = 0;
      if (verifyTargetReached & !flag2)
        pointsOnTrajectory = -1;
      return pointsOnTrajectory;
    }

    public bool LIS_HasAirBridgeOnTrajectory(
      int ox,
      int oy,
      int tarX,
      int tarY,
      bool verifyTargetReached = false)
    {
      Coordinate coordinate1;
      coordinate1.x = ox;
      coordinate1.y = oy;
      Coordinate coordinate2;
      for (coordinate1.onmap = true; coordinate1.onmap; coordinate1 = coordinate2)
      {
        coordinate2 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
        if (coordinate2.onmap)
        {
          int num = this.game.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0) - 1;
          if (!(num >= 0 & num <= 5))
            return true;
        }
        else
          break;
      }
      return false;
    }

    public bool IsItemMaximizer(int itemNr) => itemNr >= 16 & itemNr <= 20 || itemNr == 22;

    public int LIS_GetLowestPointsOnTrajectory_PREVIEW(
      int ox,
      int oy,
      int tarX,
      int tarY,
      bool verifyTargetReached = false)
    {
      bool flag1 = true;
      int trajectoryPreview = 9999999;
      bool flag2 = false;
      Coordinate coordinate1;
      coordinate1.x = ox;
      coordinate1.y = oy;
      coordinate1.onmap = true;
      while (coordinate1.onmap)
      {
        Coordinate coordinate2 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
        if (coordinate2.onmap)
        {
          int index1 = this.game.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0) - 1;
          int index2 = index1 + 3;
          if (index2 > 5)
            index2 -= 6;
          if (flag1 & this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].tempPreviewLIS[6] < trajectoryPreview)
            trajectoryPreview = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].tempPreviewLIS[6];
          if (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].tempPreviewLIS[index1] < trajectoryPreview)
            trajectoryPreview = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].tempPreviewLIS[index1];
          if (this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].tempPreviewLIS[index2] < trajectoryPreview)
            trajectoryPreview = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].tempPreviewLIS[index2];
          if (this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].tempPreviewLIS[6] < trajectoryPreview)
            trajectoryPreview = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].tempPreviewLIS[6];
          flag1 = false;
          coordinate1 = coordinate2;
          if (coordinate1.x == tarX & coordinate1.y == tarY)
            flag2 = true;
        }
        else
        {
          if (coordinate1.x == tarX & coordinate1.y == tarY)
            flag2 = true;
          if (ox == coordinate1.x & oy == coordinate1.y & flag1)
          {
            trajectoryPreview = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].tempPreviewLIS[6];
            break;
          }
          break;
        }
      }
      if (trajectoryPreview >= 999999)
        trajectoryPreview = 0;
      if (verifyTargetReached & !flag2)
        trajectoryPreview = -1;
      return trajectoryPreview;
    }

    public int LIS_GetLowestTotalHistoryTrajectory(int ox, int oy)
    {
      bool flag = true;
      int historyTrajectory = 9999999;
      Coordinate coordinate1;
      coordinate1.x = ox;
      coordinate1.y = oy;
      Coordinate coordinate2;
      for (coordinate1.onmap = true; coordinate1.onmap; coordinate1 = coordinate2)
      {
        coordinate2 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
        if (coordinate2.onmap)
        {
          int index1 = this.game.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0) - 1;
          int index2 = index1 + 3;
          if (index2 > 5)
            index2 -= 6;
          if (flag & this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIShistory[6] + this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[6] < historyTrajectory)
            historyTrajectory = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIShistory[6] + this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[6];
          if (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIShistory[index1] + this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[index1] < historyTrajectory)
            historyTrajectory = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIShistory[index1] + this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[index1];
          if (this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LIShistory[index2] + this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints[index2] < historyTrajectory)
            historyTrajectory = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LIShistory[index2] + this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints[index2];
          if (this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LIShistory[6] + this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints[6] < historyTrajectory)
            historyTrajectory = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LIShistory[6] + this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LISpoints[6];
          flag = false;
        }
        else
          break;
      }
      if (historyTrajectory >= 999999)
        historyTrajectory = 0;
      return historyTrajectory;
    }

    public int LIS_GetLowestPotentialPointsOnTrajectory(int ox, int oy)
    {
      bool flag = true;
      int pointsOnTrajectory = 9999999;
      Coordinate coordinate1;
      coordinate1.x = ox;
      coordinate1.y = oy;
      Coordinate coordinate2;
      for (coordinate1.onmap = true; coordinate1.onmap; coordinate1 = coordinate2)
      {
        coordinate2 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
        if (coordinate2.onmap)
        {
          int index1 = this.game.HandyFunctionsObj.HexFacing(coordinate1.x, coordinate1.y, 0, coordinate2.x, coordinate2.y, 0) - 1;
          int index2 = index1 + 3;
          if (index2 > 5)
            index2 -= 6;
          if (flag & this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIStotalHistory[6] - this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIShistory[6] < pointsOnTrajectory)
            pointsOnTrajectory = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIStotalHistory[6] - this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIShistory[6];
          if (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIStotalHistory[index1] - this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIShistory[index1] < pointsOnTrajectory)
            pointsOnTrajectory = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIStotalHistory[index1] - this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LIShistory[index1];
          if (this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LIStotalHistory[index2] - this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LIShistory[index2] < pointsOnTrajectory)
            pointsOnTrajectory = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LIStotalHistory[index2] - this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LIShistory[index2];
          if (this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LIStotalHistory[6] - this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LIShistory[6] < pointsOnTrajectory)
            pointsOnTrajectory = this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LIStotalHistory[6] - this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LIShistory[6];
          flag = false;
        }
        else
          break;
      }
      return pointsOnTrajectory;
    }

    public void LIS_SetNetwork(bool isCalibrationCall, bool isPreview = false, int onlyForAssetID = -1)
    {
      int index1 = -1;
      string libName1 = "SE_Data";
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 149, 0, 0));
      int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 148, 0, 0));
      int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 144, 0, 0));
      object[,] objArray1 = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      object[,] objArray2 = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index2 = 0; index2 <= mapWidth1; ++index2)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index3 = 0; index3 <= mapHeight; ++index3)
        {
          objArray1[index2, index3] = (object) this.game.EditObj.TempValue[0].Value[index2, index3];
          objArray2[index2, index3] = (object) this.game.EditObj.TempCameFrom[0].Value[index2, index3];
          if (this.game.Data.MapObj[0].HexObj[index2, index3].Regime != this.game.Data.Turn)
            this.game.Data.RegimeObj[this.game.Data.Turn].Trafic[0].Value[index2, index3] = 0;
        }
      }
      if (isPreview & !this.game.Data.RegimeObj[this.game.Data.Turn].AI & this.game.Data.InTurn)
        this.game.EventRelatedObj.ExecSuperImposeMessage("Calculating", "Hold on while we calculate the logistics Preview...", 0, 0, "");
      if (!isCalibrationCall & onlyForAssetID < 1)
      {
        index1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 511, 0, 0));
        if (index1 > -1)
          this.game.Data.StringListObj[index1].ClearAllRows();
      }
      if (!isCalibrationCall)
      {
        index1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 512, 0, 0));
        if (index1 > -1)
          this.game.Data.StringListObj[index1].ClearAllRows();
      }
      if (!isCalibrationCall & !isPreview)
      {
        index1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 505, 0, 0));
        if (index1 > -1)
          this.game.Data.StringListObj[index1].ClearAllRows();
      }
      if (this.game.Data.RegimeObj[this.game.Data.Turn].AI)
        index1 = -1;
      if (this.game.Data.RegimeObj[this.game.Data.Turn].Sleep)
        index1 = -1;
      if (isCalibrationCall)
        index1 = -1;
      int pts1 = 0;
      int pts2 = 0;
      int pts3 = 0;
      int pts4 = 0;
      int num1 = -1;
      int num2 = -1;
      int num3 = -1;
      int num4 = -1;
      int num5 = 0;
      this.game.EditObj.layerLisOnlyAssetId_isSupplyBase = false;
      int tid1;
      if (isPreview)
      {
        index1 = onlyForAssetID <= -1 ? this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 511, 0, 0)) : this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 512, 0, 0));
        if (onlyForAssetID > -1)
        {
          int stringListById5 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 361, 0, 0));
          num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData(9, onlyForAssetID, 3)));
          num2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData(9, onlyForAssetID, 4)));
          int length = this.game.Data.StringListObj[stringListById5].Length;
          for (tid1 = 0; tid1 <= length; ++tid1)
          {
            if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].Data[tid1, 0])) == onlyForAssetID)
            {
              if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].Data[tid1, 1])) == 6 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].Data[tid1, 2])) == 14)
              {
                string str = this.game.Data.StringListObj[stringListById5].Data[tid1, 3];
                int num6 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].Data[tid1, 4]));
                if (Operators.CompareString(str.ToLower(), "truckpoints", false) == 0)
                  pts4 += num6;
                if (Operators.CompareString(str.ToLower(), "maglevpoints", false) == 0)
                  pts2 += num6;
                if (Operators.CompareString(str.ToLower(), "truckfreeap", false) == 0)
                  pts3 += num6;
                if (Operators.CompareString(str.ToLower(), "maglevfreeap", false) == 0)
                  pts1 += num6;
              }
              if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].Data[tid1, 1])) == 5 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].Data[tid1, 2])) == 14)
              {
                string str = this.game.Data.StringListObj[stringListById5].Data[tid1, 3];
                int num7 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].Data[tid1, 4]));
                if (Operators.CompareString(str.ToLower(), "logistical extension", false) == 0)
                  num5 += num7;
              }
            }
          }
          if (num5 > 0)
          {
            this.game.EditObj.layerLisOnlyAssetId_isSupplyBase = true;
            num3 = num1;
            num4 = num2;
            num1 = -1;
            num2 = -1;
          }
        }
      }
      if (index1 > -1 && this.game.Data.StringListObj[index1].Width < 7)
        index1 = -1;
      int[,,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 5];
      int index4;
      if (!isCalibrationCall)
      {
        int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
        for (int index5 = 0; index5 <= mapWidth2; ++index5)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index6 = 0; index6 <= mapHeight; ++index6)
          {
            if (this.game.Data.MapObj[0].HexObj[index5, index6].Regime == this.game.Data.Turn)
            {
              int location = this.game.Data.MapObj[0].HexObj[index5, index6].Location;
              if (location > -1)
              {
                if (isPreview)
                {
                  DataClass data1 = this.game.Data;
                  string str1 = "truckPoints";
                  ref string local1 = ref str1;
                  string libName2 = libName1;
                  int libVar1 = data1.FindLibVar(ref local1, libName2);
                  index4 = this.game.Data.MapObj[0].HexObj[index5, index6].GetHexLibVarValue(libVar1);
                  DataClass data2 = this.game.Data;
                  string str2 = "truckFreeAp";
                  ref string local2 = ref str2;
                  string libName3 = libName1;
                  int libVar2 = data2.FindLibVar(ref local2, libName3);
                  int hexLibVarValue1 = this.game.Data.MapObj[0].HexObj[index5, index6].GetHexLibVarValue(libVar2);
                  DataClass data3 = this.game.Data;
                  string str3 = "maglevPoints";
                  ref string local3 = ref str3;
                  string libName4 = libName1;
                  int libVar3 = data3.FindLibVar(ref local3, libName4);
                  int hexLibVarValue2 = this.game.Data.MapObj[0].HexObj[index5, index6].GetHexLibVarValue(libVar3);
                  DataClass data4 = this.game.Data;
                  string str4 = "maglevFreeAp";
                  ref string local4 = ref str4;
                  string libName5 = libName1;
                  int libVar4 = data4.FindLibVar(ref local4, libName5);
                  int hexLibVarValue3 = this.game.Data.MapObj[0].HexObj[index5, index6].GetHexLibVarValue(libVar4);
                  if (index4 > 0 & hexLibVarValue1 > 0)
                    numArray1[index5, index6, 1] = index4;
                  if (hexLibVarValue2 > 0 & hexLibVarValue3 > 0)
                    numArray1[index5, index6, 2] = hexLibVarValue2;
                }
                else if (!Information.IsNothing((object) this.game.Data.LocObj[location].tempLIS) && !Information.IsNothing((object) this.game.Data.LocObj[location].tempLISfreeAP) && this.game.Data.LocObj[location].tempLIS.Counter > -1)
                {
                  tid1 = 1;
                  do
                  {
                    index4 = this.game.Data.LocObj[location].tempLIS.FindWeight(tid1);
                    int weight = this.game.Data.LocObj[location].tempLISfreeAP.FindWeight(tid1);
                    if (index4 > 0 & weight > 0)
                      numArray1[index5, index6, tid1] = index4;
                    ++tid1;
                  }
                  while (tid1 <= 2);
                }
              }
            }
          }
        }
      }
      if (isPreview & !isCalibrationCall)
      {
        this.tempLISwithoutLogExt = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 9];
        this.cacheLIShistory = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 9];
        this.cacheLISpoints = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 9];
        this.cacheLIStotalHistory = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 9];
        this.cacheLISorganic = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 9];
        this.cacheLISorganicPercentage = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 9];
        this.cacheLISpull = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 9];
        int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
        for (int index7 = 0; index7 <= mapWidth3; ++index7)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index8 = 0; index8 <= mapHeight; ++index8)
          {
            int index9 = 0;
            do
            {
              this.tempLISwithoutLogExt[index7, index8, index9] = 0;
              this.cacheLIShistory[index7, index8, index9] = this.game.Data.MapObj[0].HexObj[index7, index8].LIShistory[index9];
              this.cacheLISpoints[index7, index8, index9] = this.game.Data.MapObj[0].HexObj[index7, index8].LISpoints[index9];
              this.cacheLIStotalHistory[index7, index8, index9] = this.game.Data.MapObj[0].HexObj[index7, index8].LIStotalHistory[index9];
              this.cacheLISorganic[index7, index8, index9] = this.game.Data.MapObj[0].HexObj[index7, index8].LISorganic[index9];
              this.cacheLISorganicPercentage[index7, index8, index9] = this.game.Data.MapObj[0].HexObj[index7, index8].LISorganicPercentage[index9];
              this.cacheLISpull[index7, index8, index9] = this.game.Data.MapObj[0].HexObj[index7, index8].LISpull[index9];
              ++index9;
            }
            while (index9 <= 8);
          }
        }
      }
      int[,,,] numArray2 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 6, 4];
      int[,,] numArray3 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 6];
      if (this.game.Data.Turn == 2)
        index4 = index4;
      if (Information.IsNothing((object) this.game.Data.RegimeObj[this.game.Data.Turn].Trafic[0]))
        this.game.Data.RegimeObj[this.game.Data.Turn].Trafic[0] = new MapMatrix2(this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight);
      if (Information.IsNothing((object) this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0]))
        this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0] = new MapMatrix2(this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight);
      if (this.game.Data.RegimeObj[this.game.Data.Turn].Trafic[0].Value.GetUpperBound(0) >= this.game.Data.MapObj[0].MapWidth)
      {
        int mapWidth4 = this.game.Data.MapObj[0].MapWidth;
        for (int x = 0; x <= mapWidth4; ++x)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int y = 0; y <= mapHeight; ++y)
          {
            if (!isCalibrationCall)
            {
              int index10 = 0;
              do
              {
                this.game.Data.MapObj[0].HexObj[x, y].LISpull[index10] = 0;
                ++index10;
              }
              while (index10 <= 8);
            }
            NeighboursExtra lisTraffic = this.game.HandyFunctionsObj.GetLisTraffic(x, y);
            tid1 = 0;
            do
            {
              if (lisTraffic.truck)
                numArray2[x, y, tid1, 0] = lisTraffic.data[tid1];
              if (lisTraffic.rail)
                numArray2[x, y, tid1, 1] = lisTraffic.data[tid1];
              if (lisTraffic.pull)
                numArray2[x, y, tid1, 2] = lisTraffic.data[tid1];
              ++tid1;
            }
            while (tid1 <= 5);
          }
        }
      }
      int stringListById6 = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[405]));
      this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[404]));
      if (isCalibrationCall)
        return;
      if (isCalibrationCall)
      {
        int mapWidth5 = this.game.Data.MapObj[0].MapWidth;
        for (int index11 = 0; index11 <= mapWidth5; ++index11)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index12 = 0; index12 <= mapHeight; ++index12)
          {
            int index13 = 0;
            do
            {
              this.game.Data.MapObj[0].HexObj[index11, index12].tempOldLISpoints[index13] = this.game.Data.MapObj[0].HexObj[index11, index12].LISpoints[index13];
              this.game.Data.MapObj[0].HexObj[index11, index12].LISpoints[index13] = 0;
              ++index13;
            }
            while (index13 <= 8);
          }
        }
      }
      else
      {
        int mapWidth6 = this.game.Data.MapObj[0].MapWidth;
        for (int index14 = 0; index14 <= mapWidth6; ++index14)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index15 = 0; index15 <= mapHeight; ++index15)
          {
            int index16 = 0;
            do
            {
              this.game.Data.MapObj[0].HexObj[index14, index15].tempOldLISpoints[index16] = 0;
              this.game.Data.MapObj[0].HexObj[index14, index15].LIShistory[index16] = 0;
              this.game.Data.MapObj[0].HexObj[index14, index15].LISpoints[index16] = 0;
              this.game.Data.MapObj[0].HexObj[index14, index15].LIStotalHistory[index16] = 0;
              this.game.Data.MapObj[0].HexObj[index14, index15].LISorganic[index16] = 0;
              this.game.Data.MapObj[0].HexObj[index14, index15].LISorganicPercentage[index16] = 0;
              this.game.Data.MapObj[0].HexObj[index14, index15].LISpull[index16] = 0;
              ++index16;
            }
            while (index16 <= 8);
          }
        }
      }
      int locCounter1 = this.game.Data.LocCounter;
      for (int index17 = 0; index17 <= locCounter1; ++index17)
      {
        if (Information.IsNothing((object) this.game.Data.LocObj[index17].tempLIS))
          this.game.Data.LocObj[index17].tempLIS = new SimpleList();
        if (Information.IsNothing((object) this.game.Data.LocObj[index17].tempLISfreeAP))
          this.game.Data.LocObj[index17].tempLISfreeAP = new SimpleList();
      }
      bool flag1 = false;
      if (this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 144, 0, 0))].FindRow(0, 3291) >= 0)
        flag1 = true;
      this.game.EditObj.tempZoneTest = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int index18;
      int y1;
      int index19;
      int movetype1;
      Coordinate coordinate1;
      if (!isCalibrationCall & flag1)
      {
        bool[,] flagArray1 = new bool[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
        bool[,] flagArray2 = new bool[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
        int locCounter2 = this.game.Data.LocCounter;
        for (int index20 = 0; index20 <= locCounter2; ++index20)
        {
          index18 = this.game.Data.LocObj[index20].X;
          y1 = this.game.Data.LocObj[index20].Y;
          bool flag2 = false;
          if (this.game.Data.MapObj[0].HexObj[index18, y1].Regime == this.game.Data.Turn && !Information.IsNothing((object) this.game.Data.LocObj[index20].tempLIS))
          {
            if (this.game.Data.LocObj[index20].tempLIS.Counter > -1)
              flag2 = true;
            if (isPreview & !flag2)
            {
              DataClass data = this.game.Data;
              string str = "maglevPoints";
              ref string local = ref str;
              string libName6 = libName1;
              index4 = data.FindLibVar(ref local, libName6);
              if (this.game.Data.MapObj[0].HexObj[index18, y1].GetHexLibVarValue(index4) > 0)
                flag2 = true;
            }
          }
          if (flag2)
          {
            index19 = 2;
            movetype1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData(0, index19, 4)));
            int num8 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData(0, index19, 2)));
            index4 = this.game.Data.LocObj[index20].tempLIS.FindNr(index19);
            int num9 = 0;
            if (index4 > -1)
              num9 = Convert.ToInt32(Math.Floor(new Decimal(this.game.Data.LocObj[index20].tempLIS.Weight[index4])));
            if (num9 < 1)
            {
              DataClass data = this.game.Data;
              string str = "maglevPoints";
              ref string local = ref str;
              string libName7 = libName1;
              index4 = data.FindLibVar(ref local, libName7);
              int hexLibVarValue = this.game.Data.MapObj[0].HexObj[index18, y1].GetHexLibVarValue(index4);
              if (hexLibVarValue > 0)
                num9 = hexLibVarValue;
            }
            if (num9 > 0)
              flagArray2[index18, y1] = true;
          }
        }
        int locCounter3 = this.game.Data.LocCounter;
        for (int index21 = 0; index21 <= locCounter3; ++index21)
        {
          index18 = this.game.Data.LocObj[index21].X;
          y1 = this.game.Data.LocObj[index21].Y;
          bool flag3 = false;
          if (this.game.Data.MapObj[0].HexObj[index18, y1].Regime == this.game.Data.Turn)
          {
            if (!Information.IsNothing((object) this.game.Data.LocObj[index21].tempLIS) && this.game.Data.LocObj[index21].tempLIS.Counter > -1)
              flag3 = true;
            if (isPreview)
            {
              DataClass data = this.game.Data;
              string str = "maglevPoints";
              ref string local = ref str;
              string libName8 = libName1;
              int libVar = data.FindLibVar(ref local, libName8);
              if (this.game.Data.MapObj[0].HexObj[index18, y1].GetHexLibVarValue(libVar) > 0)
                flag3 = true;
            }
          }
          if (flag3)
          {
            index19 = 2;
            movetype1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData(0, index19, 4)));
            int theater = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData(0, index19, 2)));
            index4 = 0;
            int num10 = 0;
            if (!Information.IsNothing((object) this.game.Data.LocObj[index21].tempLIS))
            {
              index4 = this.game.Data.LocObj[index21].tempLIS.FindNr(index19);
              if (index4 > -1)
                num10 = Convert.ToInt32(Math.Floor(new Decimal(this.game.Data.LocObj[index21].tempLIS.Weight[index4])));
            }
            if (isPreview & num10 < 1)
            {
              DataClass data = this.game.Data;
              string str = "maglevPoints";
              ref string local = ref str;
              string libName9 = libName1;
              int libVar = data.FindLibVar(ref local, libName9);
              int hexLibVarValue = this.game.Data.MapObj[0].HexObj[index18, y1].GetHexLibVarValue(libVar);
              if (hexLibVarValue > 0)
                num10 = hexLibVarValue;
            }
            if (num10 > 0)
            {
              index4 = -1;
              if (!Information.IsNothing((object) this.game.Data.LocObj[index21].tempLISfreeAP))
                index4 = this.game.Data.LocObj[index21].tempLISfreeAP.FindNr(index19);
              int num11 = 0;
              if (index4 > -1)
                num11 = this.game.Data.LocObj[index21].tempLISfreeAP.Weight[index4];
              if (isPreview)
              {
                DataClass data = this.game.Data;
                string str = "maglevFreeAp";
                ref string local = ref str;
                string libName10 = libName1;
                int libVar = data.FindLibVar(ref local, libName10);
                int hexLibVarValue = this.game.Data.MapObj[0].HexObj[index18, y1].GetHexLibVarValue(libVar);
                if (hexLibVarValue > 0)
                  num11 = hexLibVarValue;
              }
              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype1, theater, num11 * 2, index18, y1, 0, NoAPPenalties: isPreview, roadsOnly: true, alwaysUseLogisticalBonus: true, lisMode: index19, specialRuleNumber: 2);
              flagArray1[index18, y1] = true;
              if (num11 > 0)
              {
                int mapWidth7 = this.game.Data.MapObj[0].MapWidth;
                for (int index22 = 0; index22 <= mapWidth7; ++index22)
                {
                  int mapHeight = this.game.Data.MapObj[0].MapHeight;
                  for (int index23 = 0; index23 <= mapHeight; ++index23)
                  {
                    if (flagArray2[index22, index23] && !(index22 == index18 & index23 == y1) && this.game.EditObj.TempValue[0].Value[index22, index23] < 9999)
                    {
                      coordinate1.x = index22;
                      coordinate1.y = index23;
                      for (coordinate1.onmap = true; coordinate1.onmap; coordinate1 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y])
                        flagArray1[coordinate1.x, coordinate1.y] = true;
                    }
                  }
                }
              }
            }
          }
        }
        int mapWidth8 = this.game.Data.MapObj[0].MapWidth;
        for (int index24 = 0; index24 <= mapWidth8; ++index24)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index25 = 0; index25 <= mapHeight; ++index25)
            this.game.EditObj.tempZoneTest[index24, index25] = !flagArray1[index24, index25] ? 0 : 1;
        }
        this.game.HandyFunctionsObj.RedimTempValue(9999);
      }
      else
      {
        int mapWidth9 = this.game.Data.MapObj[0].MapWidth;
        for (int index26 = 0; index26 <= mapWidth9; ++index26)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index27 = 0; index27 <= mapHeight; ++index27)
            this.game.EditObj.tempZoneTest[index26, index27] = 1;
        }
      }
      if (this.game.Data.Turn == 2)
        ;
      bool flag4 = false;
      int mapWidth10 = this.game.Data.MapObj[0].MapWidth;
      for (int index28 = 0; index28 <= mapWidth10; ++index28)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index29 = 0; index29 <= mapHeight; ++index29)
        {
          if (this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0].Value[index28, index29] > 0)
            flag4 = true;
        }
      }
      int stringListById7 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 210, 0, 0));
      int num12 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "pullAssetsOff", 2)));
      int num13 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "pullUnitsOff", 2)));
      int num14 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "pullCitiesOff", 2)));
      this.game.EditObj.PossiblePull = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 7];
      this.game.EditObj.origPossiblePull = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 7];
      object[,,] objArray3 = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 7];
      bool flag5;
      if ((int) Math.Round(Conversion.Val(this.game.Data.Designer)) >= 42 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI & !this.game.Data.RegimeObj[this.game.Data.Turn].minimumDataUsage && !isCalibrationCall & onlyForAssetID < 1 & (flag4 | num12 == 0 | num13 == 0 | num14 == 0))
      {
        int locCounter4 = this.game.Data.LocCounter;
        for (int index30 = 0; index30 <= locCounter4; ++index30)
        {
          index18 = this.game.Data.LocObj[index30].X;
          y1 = this.game.Data.LocObj[index30].Y;
          if (index18 == 120 & y1 == 65)
            index18 = index18;
          flag5 = false;
          int num15 = 0;
          int num16 = 0;
          int num17 = 0;
          int num18 = 0;
          if (this.game.Data.MapObj[0].HexObj[index18, y1].Regime == this.game.Data.Turn)
          {
            if (isPreview)
            {
              DataClass data5 = this.game.Data;
              string str5 = "truckPoints";
              ref string local5 = ref str5;
              string libName11 = libName1;
              int libVar5 = data5.FindLibVar(ref local5, libName11);
              num15 = this.game.Data.MapObj[0].HexObj[index18, y1].GetHexLibVarValue(libVar5);
              DataClass data6 = this.game.Data;
              string str6 = "truckFreeAp";
              ref string local6 = ref str6;
              string libName12 = libName1;
              int libVar6 = data6.FindLibVar(ref local6, libName12);
              num16 = this.game.Data.MapObj[0].HexObj[index18, y1].GetHexLibVarValue(libVar6);
              DataClass data7 = this.game.Data;
              string str7 = "maglevPoints";
              ref string local7 = ref str7;
              string libName13 = libName1;
              int libVar7 = data7.FindLibVar(ref local7, libName13);
              num17 = this.game.Data.MapObj[0].HexObj[index18, y1].GetHexLibVarValue(libVar7);
              DataClass data8 = this.game.Data;
              string str8 = "maglevFreeAp";
              ref string local8 = ref str8;
              string libName14 = libName1;
              int libVar8 = data8.FindLibVar(ref local8, libName14);
              num18 = this.game.Data.MapObj[0].HexObj[index18, y1].GetHexLibVarValue(libVar8);
            }
            else
            {
              if (!Information.IsNothing((object) this.game.Data.LocObj[index30].tempLIS))
              {
                num15 = this.game.Data.LocObj[index30].tempLIS.FindWeight(1);
                num17 = this.game.Data.LocObj[index30].tempLIS.FindWeight(2);
              }
              if (!Information.IsNothing((object) this.game.Data.LocObj[index30].tempLISfreeAP))
              {
                num16 = this.game.Data.LocObj[index30].tempLISfreeAP.FindWeight(1);
                num18 = this.game.Data.LocObj[index30].tempLISfreeAP.FindWeight(2);
              }
            }
            int num19 = 1;
            do
            {
              int num20 = 1;
              if (num19 == 2)
                num20 = 2;
              int num21 = num20;
              for (int index31 = 1; index31 <= num21; ++index31)
              {
                int theater = 0;
                int tdata1;
                int num22;
                switch (num19)
                {
                  case 1:
                    tdata1 = num15;
                    num22 = num16;
                    movetype1 = 9;
                    index19 = 1;
                    break;
                  case 2:
                    tdata1 = num17;
                    num22 = num18;
                    movetype1 = 12;
                    index19 = 2;
                    break;
                }
                if (tdata1 > 0 & num22 > 0)
                {
                  if (flag1 & num19 == 2)
                  {
                    if (index31 == 1)
                    {
                      tdata1 = (int) Math.Round(Math.Floor((double) tdata1 * 0.9));
                      this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype1, theater, num22 * 2 + 200, index18, y1, 0, NoAPPenalties: isPreview, tempZoneTest: true, roadsOnly: true, lisMode: index19);
                    }
                    else
                    {
                      tdata1 = (int) Math.Round(Math.Floor((double) tdata1 * 0.1));
                      this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype1, theater, num22 * 2 + 200, index18, y1, 0, NoAPPenalties: isPreview, roadsOnly: true, lisMode: index19);
                    }
                  }
                  else
                    this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype1, theater, num22 * 2 + 200, index18, y1, 0, NoAPPenalties: isPreview, roadsOnly: true, lisMode: index19);
                  object[,,] objArray4 = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 7];
                  SimpleList simpleList1 = new SimpleList();
                  SimpleList simpleList2 = new SimpleList();
                  simpleList1.Add(index18 * 1000 + y1, 0, 1, tdata3: index18, tdata4: y1);
                  simpleList2.Add(index18 * 1000 + y1, 0, tdata1);
                  bool flag6 = true;
                  while (flag6)
                  {
                    flag6 = false;
                    int counter1 = simpleList1.Counter;
                    for (int index32 = 0; index32 <= counter1; ++index32)
                    {
                      if (simpleList1.Data1[index32] == 1)
                      {
                        int cx = simpleList1.Data3[index32];
                        int cy = simpleList1.Data4[index32];
                        int num23 = this.game.EditObj.TempValue[0].Value[cx, cy];
                        index4 = simpleList1.Weight[index32];
                        int tweight = simpleList2.Weight[index32];
                        tdata1 = simpleList2.Data1[index32];
                        int tfacing = 1;
                        do
                        {
                          coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                          if (coordinate1.onmap)
                          {
                            int num24 = this.game.EditObj.TempValue[0].Value[coordinate1.x, coordinate1.y];
                            if (num24 > num23 & num24 <= num22 * 2)
                            {
                              int num25 = this.game.HandyFunctionsObj.GetLogisticalBonus(coordinate1.x, coordinate1.y, index19);
                              if (num25 > 0)
                              {
                                if (num24 < num25)
                                  num25 = num24;
                                if (num25 > simpleList1.Data2[index32] && num24 > simpleList1.Data2[index32])
                                  simpleList1.Data2[index32] = num24;
                              }
                              int num26 = num24 - num23;
                              int num27 = 0;
                              if (simpleList1.Data5[index32] < simpleList1.Data2[index32])
                              {
                                num27 = simpleList1.Data2[index32] - simpleList1.Data5[index32];
                                if (num27 > num26)
                                  num27 = num26;
                                num26 -= num27;
                              }
                              if (Conversions.ToBoolean(Operators.AndObject((object) (simpleList1.Weight[index32] + num26 <= num22 * 2), Operators.CompareObjectLess(objArray4[cx, cy, tfacing - 1], (object) 1, false))))
                              {
                                simpleList1.FindWeight(-1, tdata3: coordinate1.x, tdata4: coordinate1.y);
                                simpleList1.Add(coordinate1.x * 1000 + coordinate1.y, simpleList1.Weight[index32], 1, simpleList1.Data2[index32], coordinate1.x, coordinate1.y, simpleList1.Data5[index32], false);
                                int counter2 = simpleList1.Counter;
                                int[] weight = simpleList1.Weight;
                                int[] numArray4 = weight;
                                int index33 = counter2;
                                int index34 = index33;
                                int num28 = weight[index33] + num26;
                                numArray4[index34] = num28;
                                int[] data5 = simpleList1.Data5;
                                int[] numArray5 = data5;
                                int index35 = counter2;
                                int index36 = index35;
                                int num29 = data5[index35] + num27;
                                numArray5[index36] = num29;
                                flag6 = true;
                                int num30 = tdata1;
                                if (simpleList1.Weight[counter2] > num22)
                                {
                                  num30 -= (int) Math.Round((double) (num30 * (simpleList1.Weight[counter2] - num22)) / (double) num22);
                                  if (num30 < 0)
                                    num30 = 0;
                                  if (num30 == 0)
                                    simpleList1.Data1[counter2] = 0;
                                }
                                if (cx == 20 & cy == 12)
                                  cx = cx;
                                objArray4[cx, cy, tfacing - 1] = (object) num30;
                                if (numArray1[coordinate1.x, coordinate1.y, index19] > 0)
                                {
                                  if ((int) Math.Round(Conversion.Val(this.game.Data.Designer)) == 49)
                                    simpleList1.Data1[counter2] = 0;
                                  else if ((int) Math.Round(Conversion.Val(this.game.Data.Designer)) >= 50)
                                  {
                                    ++tweight;
                                    if (tweight <= 3)
                                    {
                                      simpleList1.Weight[index32] = 0;
                                      tdata1 -= (int) Math.Round((double) tdata1 * ((double) simpleList1.Weight[index32] / (double) (num22 * 2)));
                                      if (tweight == 1)
                                        tdata1 = (int) Math.Round((double) tdata1 * 0.75);
                                      if (tweight == 2)
                                        tdata1 = (int) Math.Round((double) tdata1 * 0.5);
                                      if (tweight == 3)
                                        tdata1 = (int) Math.Round((double) tdata1 * 0.25);
                                    }
                                    else
                                      simpleList1.Data1[counter2] = 0;
                                  }
                                }
                                simpleList2.Add(coordinate1.x * 1000 + coordinate1.y, tweight, tdata1, CheckExistence: false);
                              }
                            }
                          }
                          ++tfacing;
                        }
                        while (tfacing <= 6);
                        simpleList1.Data1[index32] = 0;
                      }
                    }
                  }
                  int mapWidth11 = this.game.Data.MapObj[0].MapWidth;
                  for (int index37 = 0; index37 <= mapWidth11; ++index37)
                  {
                    int mapHeight = this.game.Data.MapObj[0].MapHeight;
                    for (int index38 = 0; index38 <= mapHeight; ++index38)
                    {
                      int index39 = 0;
                      do
                      {
                        int[,,] possiblePull = this.game.EditObj.PossiblePull;
                        int[,,] numArray6 = possiblePull;
                        int index40 = index37;
                        int index41 = index40;
                        int index42 = index38;
                        int index43 = index42;
                        int index44 = index39;
                        int index45 = index44;
                        int integer = Conversions.ToInteger(Operators.AddObject((object) possiblePull[index40, index42, index44], objArray4[index37, index38, index39]));
                        numArray6[index41, index43, index45] = integer;
                        ++index39;
                      }
                      while (index39 <= 5);
                    }
                  }
                }
              }
              ++num19;
            }
            while (num19 <= 2);
          }
        }
        int mapWidth12 = this.game.Data.MapObj[0].MapWidth;
        for (int index46 = 0; index46 <= mapWidth12; ++index46)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index47 = 0; index47 <= mapHeight; ++index47)
          {
            int index48 = 0;
            do
            {
              this.game.EditObj.origPossiblePull[index46, index47, index48] = this.game.EditObj.PossiblePull[index46, index47, index48];
              ++index48;
            }
            while (index48 <= 5);
          }
        }
      }
      int index49;
      int index50;
      int num31;
      string s4;
      if (!isCalibrationCall)
      {
        if (onlyForAssetID > 0)
        {
          int mapWidth13 = this.game.Data.MapObj[0].MapWidth;
          for (int index51 = 0; index51 <= mapWidth13; ++index51)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index52 = 0; index52 <= mapHeight; ++index52)
            {
              int index53 = 0;
              do
              {
                numArray3[index51, index52, index53] = this.game.Data.MapObj[0].HexObj[index51, index52].tempPreviewRoadPull[index53];
                ++index53;
              }
              while (index53 <= 5);
            }
          }
        }
        else if ((int) Math.Round(Conversion.Val(this.game.Data.Designer)) >= 42 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI & !this.game.Data.RegimeObj[this.game.Data.Turn].minimumDataUsage)
        {
          this.game.EventRelatedObj.Helper_MakeListForUnitRequests("SE_Data", -1, false, BothMilitiaAndReg: true);
          int[,,] numArray7 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 7];
          int[,] numArray8 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
          int[,] numArray9 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
          int[,,] numArray10 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 7];
          int[,] numArray11 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
          int[] numArray12 = new int[this.game.Data.StringListObj[stringListById1].GetHighestValue(0) + 1000 + 1];
          int[] numArray13 = new int[this.game.Data.StringListObj[stringListById1].GetHighestValue(0) + 1000 + 1];
          SimpleList simpleList3 = new SimpleList();
          SimpleList simpleList4 = new SimpleList();
          int length1 = this.game.Data.StringListObj[stringListById1].Length;
          for (int index54 = 0; index54 <= length1; ++index54)
          {
            int tid2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index54, 0]));
            numArray12[tid2] = -1;
            index4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index54, 8]));
            if (index4 == this.game.Data.RegimeObj[this.game.Data.Turn].id)
            {
              numArray12[tid2] = this.game.Data.Turn;
              simpleList4.Add(tid2, 1, index18, y1);
              int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index54, 6]));
              if (id > 0)
              {
                int locationById = this.game.HandyFunctionsObj.GetLocationByID(id);
                if (locationById > -1)
                {
                  simpleList4.Add(tid2, 1, this.game.Data.LocObj[locationById].X, this.game.Data.LocObj[locationById].Y, locationById);
                  numArray13[tid2] = this.game.Data.LocObj[locationById].HQ;
                }
              }
            }
          }
          int unitCounter1 = this.game.Data.UnitCounter;
          for (int tid3 = 0; tid3 <= unitCounter1; ++tid3)
          {
            if (this.game.Data.UnitObj[tid3].PreDef == -1 & this.game.Data.UnitObj[tid3].Regime == this.game.Data.Turn)
            {
              index4 = this.game.Data.UnitObj[tid3].Historical;
              if (index4 > -1 && this.game.Data.HistoricalUnitObj[index4].Type == 8)
                simpleList3.Add(tid3, 1);
            }
          }
          int num32 = 1;
          do
          {
            int counter3;
            if (num32 == 3)
              counter3 = simpleList4.Counter;
            if (num32 == 2 | num32 == 1)
              counter3 = simpleList3.Counter;
            if (num32 == 3)
            {
              int mapWidth14 = this.game.Data.MapObj[0].MapWidth;
              for (int index55 = 0; index55 <= mapWidth14; ++index55)
              {
                int mapHeight = this.game.Data.MapObj[0].MapHeight;
                for (index49 = 0; index49 <= mapHeight; ++index49)
                {
                  int index56 = 0;
                  do
                  {
                    numArray7[index55, index49, index56] = numArray3[index55, index49, index56];
                    ++index56;
                  }
                  while (index56 <= 5);
                }
              }
            }
            int num33 = counter3;
            for (int index57 = 0; index57 <= num33; ++index57)
            {
              int[,] numArray14 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
              int num34;
              if (num32 == 3 & num12 < 1)
              {
                num34 = simpleList4.Id[index57];
                index18 = simpleList4.Data1[index57];
                y1 = simpleList4.Data2[index57];
                this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, 8, 0, 1000, index18, y1, 0, NoAPPenalties: true, roadsOnly: true, lisMode: -1, specialRuleNumber: 3);
              }
              int hq;
              if (num32 == 2 & num13 < 1 | num32 == 1 & (flag4 | num14 < 1))
              {
                hq = simpleList3.Id[index57];
                index18 = this.game.Data.UnitObj[hq].X;
                y1 = this.game.Data.UnitObj[hq].Y;
                switch (num32)
                {
                  case 1:
                    this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, 8, 0, 1000, index18, y1, 0, NoAPPenalties: true, roadsOnly: true, lisMode: -1, specialRuleNumber: 3, specialRuleNumber2: 1);
                    break;
                  case 2:
                    this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, 11, 0, 2000, index18, y1, 0, NoAPPenalties: true, roadsOnly: true, lisMode: -1, specialRuleNumber: 3, specialRuleNumber2: 1);
                    CoordList tCoordList = new CoordList();
                    int mapWidth15 = this.game.Data.MapObj[0].MapWidth;
                    for (int x = 0; x <= mapWidth15; ++x)
                    {
                      int mapHeight = this.game.Data.MapObj[0].MapHeight;
                      for (index49 = 0; index49 <= mapHeight; ++index49)
                      {
                        numArray14[x, index49] = this.game.EditObj.TempValue[0].Value[x, index49];
                        if (this.game.EditObj.TempValue[0].Value[x, index49] < 9999)
                          tCoordList.AddCoord(x, index49, 0, this.game.EditObj.TempValue[0].Value[x, index49], 0);
                      }
                    }
                    this.game.HandyFunctionsObj.MakeMovePrediction2_multiStart(tCoordList, this.game.Data.Turn, 10, 0, 200, index18, y1, 0, NoAPPenalties: true, lisMode: -1);
                    index4 = index4;
                    break;
                }
              }
              int mapWidth16 = this.game.Data.MapObj[0].MapWidth;
              int index58;
              for (index58 = 0; index58 <= mapWidth16; ++index58)
              {
                int mapHeight = this.game.Data.MapObj[0].MapHeight;
                for (index49 = 0; index49 <= mapHeight; ++index49)
                {
                  numArray9[index58, index49] = 0;
                  numArray11[index58, index49] = 0;
                  numArray8[index58, index49] = 0;
                  int index59 = 0;
                  do
                  {
                    numArray10[index58, index49, index59] = 0;
                    ++index59;
                  }
                  while (index59 <= 6);
                }
              }
              if (num32 == 2 & num13 < 1)
              {
                int unitCounter2 = this.game.Data.UnitCounter;
                for (int unr = 0; unr <= unitCounter2; ++unr)
                {
                  if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].PreDef == -1 && !(this.game.Data.UnitObj[unr].X == this.game.Data.UnitObj[hq].X & this.game.Data.UnitObj[unr].Y == this.game.Data.UnitObj[hq].Y) && this.game.HandyFunctionsObj.IsUnitInHQChain(unr, hq))
                  {
                    int num35 = -1;
                    Coordinate coordinate2;
                    coordinate2.onmap = true;
                    coordinate2.x = this.game.Data.UnitObj[unr].X;
                    coordinate2.y = this.game.Data.UnitObj[unr].Y;
                    if (unr == 345)
                      unr = unr;
                    int y2;
                    for (; coordinate2.onmap; coordinate2 = this.game.EditObj.TempCameFrom[0].Value[coordinate2.x, coordinate2.y])
                    {
                      if (numArray14[coordinate2.x, coordinate2.y] < 9999 | coordinate2.x == index18 & coordinate2.y == y1)
                      {
                        num35 = coordinate2.x;
                        y2 = coordinate2.y;
                        break;
                      }
                    }
                    if (coordinate2.x == 23 & coordinate2.y == 12 & num32 == 2)
                      index58 = index58;
                    if (num35 > -1)
                    {
                      int num36 = 0;
                      int counter4 = this.game.Data.UnitObj[unr].tempRequestItems.Counter;
                      for (index50 = 0; index50 <= counter4; ++index50)
                      {
                        int idValue = this.game.Data.UnitObj[unr].tempRequestItems.Id[index50];
                        int num37 = this.game.Data.UnitObj[unr].tempRequestItems.Weight[index50];
                        int num38 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, idValue, 3)));
                        if (num38 > 0)
                          num36 += num37 * num38;
                      }
                      if (num36 > 0)
                      {
                        int num39 = num35;
                        int num40 = y2;
                        int[,] numArray15 = numArray8;
                        int[,] numArray16 = numArray15;
                        int index60 = num39;
                        int index61 = index60;
                        int index62 = num40;
                        int index63 = index62;
                        int num41 = numArray15[index60, index62] + num36;
                        numArray16[index61, index63] = num41;
                      }
                    }
                  }
                }
              }
              if (num32 == 3 & num12 < 1)
              {
                int length2 = this.game.Data.StringListObj[stringListById3].Length;
                for (int index64 = 0; index64 <= length2; ++index64)
                {
                  index4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index64, 0]));
                  int num42 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index64, 14]));
                  if (num42 > 0)
                    index4 = num42;
                  if (index4 == num34 && numArray12[index4] == this.game.Data.Turn)
                  {
                    int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index64, 1]));
                    int num43 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index64, 5]));
                    int num44 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index64, 8]));
                    int num45 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, idValue, 2)));
                    int num46 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, idValue, 5)));
                    int num47 = 0;
                    if (num43 >= 0)
                    {
                      num47 = num45 * 100;
                      if (num46 <= 0)
                      {
                        num47 = (int) Math.Round((double) num47 / 2.0);
                        if (num44 > 0)
                          num47 = 0;
                      }
                    }
                    if (num47 > 0)
                    {
                      int index65 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index64, 3]));
                      int index66 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index64, 4]));
                      if (!(index65 == index18 & index66 == y1))
                      {
                        int num48 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index64, 15]));
                        if (num48 > 0)
                          num47 = (int) Math.Round(Math.Ceiling((double) (num47 * num48) / 100.0));
                        if (num47 > numArray9[index65, index66])
                          numArray9[index65, index66] = num47;
                      }
                    }
                  }
                }
              }
              if (num32 == 1 & num14 < 1)
              {
                int counter5 = simpleList4.Counter;
                for (int index67 = 0; index67 <= counter5; ++index67)
                {
                  if (numArray13[simpleList4.Id[index67]] == hq && !(simpleList4.Data1[index67] == this.game.Data.UnitObj[hq].X & simpleList4.Data2[index67] == this.game.Data.UnitObj[hq].Y))
                  {
                    index4 = simpleList4.Data3[index67];
                    int num49 = 0;
                    int logCounter = this.game.Data.LocObj[index4].LogCounter;
                    for (int index68 = 0; index68 <= logCounter; ++index68)
                    {
                      if (isPreview & this.game.Data.LocObj[index4].LogType[index68] == 202 | !isPreview & this.game.Data.LocObj[index4].LogType[index68] == 2202)
                      {
                        int idValue = this.game.Data.LocObj[index4].LogData1[index68];
                        int num50 = this.game.Data.LocObj[index4].LogData3[index68];
                        int num51 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, idValue, 3)));
                        if (num51 > 0)
                          num49 += num50 * num51;
                      }
                    }
                    this.game.EventRelatedObj.Helper_MakeListForLocationRequests("SE_Data", simpleList4.Id[index67], true, true);
                    int num52 = 0;
                    int counter6 = this.game.Data.LocObj[index4].tempRequestItems.Counter;
                    for (index50 = 0; index50 <= counter6; ++index50)
                    {
                      int idValue = this.game.Data.LocObj[index4].tempRequestItems.Id[index50];
                      int num53 = this.game.Data.LocObj[index4].tempRequestItems.Weight[index50];
                      int num54 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, idValue, 3)));
                      if (num54 > 0)
                        num52 += num53 * num54;
                    }
                    int num55 = num49 + num52;
                    if (num55 > 0)
                    {
                      int num56 = simpleList4.Data1[index67];
                      int num57 = simpleList4.Data2[index67];
                      int[,] numArray17 = numArray11;
                      int[,] numArray18 = numArray17;
                      int index69 = num56;
                      int index70 = index69;
                      int index71 = num57;
                      int index72 = index71;
                      int num58 = numArray17[index69, index71] + num55;
                      numArray18[index70, index72] = num58;
                    }
                  }
                }
              }
              int mapWidth17 = this.game.Data.MapObj[0].MapWidth;
              for (int index73 = 0; index73 <= mapWidth17; ++index73)
              {
                int mapHeight1 = this.game.Data.MapObj[0].MapHeight;
                for (index49 = 0; index49 <= mapHeight1; ++index49)
                {
                  index4 = this.game.Data.RegimeObj[this.game.Data.Turn].Trafic2[0].Value[index73, index49];
                  num31 = 0;
                  bool flag7 = true;
                  if (index4 < 0)
                  {
                    numArray9[index73, index49] = 0;
                    numArray8[index73, index49] = 0;
                    numArray11[index73, index49] = 0;
                  }
                  int[] liSpull1 = this.game.Data.MapObj[0].HexObj[index73, index49].LISpull;
                  int[] numArray19 = liSpull1;
                  int index74 = 1;
                  int index75 = index74;
                  int num59 = liSpull1[index74] + numArray9[index73, index49];
                  numArray19[index75] = num59;
                  int[] liSpull2 = this.game.Data.MapObj[0].HexObj[index73, index49].LISpull;
                  int[] numArray20 = liSpull2;
                  int index76 = 2;
                  int index77 = index76;
                  int num60 = liSpull2[index76] + numArray8[index73, index49];
                  numArray20[index77] = num60;
                  int[] liSpull3 = this.game.Data.MapObj[0].HexObj[index73, index49].LISpull;
                  int[] numArray21 = liSpull3;
                  int index78 = 3;
                  int index79 = index78;
                  int num61 = liSpull3[index78] + numArray11[index73, index49];
                  numArray21[index79] = num61;
                  if (numArray9[index73, index49] > 0 & index1 > -1 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                  {
                    s4 = numArray9[index73, index49].ToString() + " Asset Pull Points have been assigned to Hex";
                    this.game.Data.StringListObj[index1].AddRowWithData(index73.ToString(), index49.ToString(), "4", "0", s4, index73.ToString(), index49.ToString(), "0");
                  }
                  if (numArray11[index73, index49] > 0 & index1 > -1 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                  {
                    s4 = numArray11[index73, index49].ToString() + " City Pull Points have been assigned to Hex";
                    this.game.Data.StringListObj[index1].AddRowWithData(index73.ToString(), index49.ToString(), "4", "0", s4, index73.ToString(), index49.ToString(), "0");
                  }
                  if (numArray8[index73, index49] > 0 & index1 > -1 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                  {
                    s4 = numArray8[index73, index49].ToString() + " Unit Pull Points have been assigned to Hex";
                    this.game.Data.StringListObj[index1].AddRowWithData(index73.ToString(), index49.ToString(), "4", "0", s4, index73.ToString(), index49.ToString(), "0");
                  }
                  if (index4 == -1)
                  {
                    if (num32 == 1 && index4 == -1 & index1 > -1 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                    {
                      s4 = "Custom Pull Points sets Hex to 0 Pull Points";
                      this.game.Data.StringListObj[index1].AddRowWithData(index73.ToString(), index49.ToString(), "4", "0", s4, index73.ToString(), index49.ToString(), "0");
                    }
                    if (index4 == -1)
                      index4 = 0;
                    this.game.Data.MapObj[0].HexObj[index73, index49].LISpull[0] = index4;
                  }
                  else
                  {
                    if (num32 != 1)
                      index4 = 0;
                    if (index4 < 0)
                    {
                      flag7 = false;
                      index4 = Math.Abs(index4);
                    }
                    if (index4 > 0 & index1 > -1 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                    {
                      if (flag7)
                        s4 = index4.ToString() + " Custom Pull Points have been added on Hex";
                      if (!flag7)
                        s4 = index4.ToString() + " Custom Pull Points have replaced any Auto Pull Points";
                      this.game.Data.StringListObj[index1].AddRowWithData(index73.ToString(), index49.ToString(), "4", "0", s4, index73.ToString(), index49.ToString(), "0");
                    }
                    if (flag7)
                    {
                      if (num32 == 3)
                      {
                        index4 += numArray9[index73, index49];
                        int num62 = numArray9[index73, index49];
                        if (num62 > 0)
                          num62 = num62;
                        int[] liSpull4 = this.game.Data.MapObj[0].HexObj[index73, index49].LISpull;
                        int[] numArray22 = liSpull4;
                        int index80 = 0;
                        int index81 = index80;
                        int num63 = liSpull4[index80] + num62;
                        numArray22[index81] = num63;
                      }
                      if (num32 == 2)
                      {
                        index4 += numArray8[index73, index49];
                        int num64 = numArray8[index73, index49];
                        int[] liSpull5 = this.game.Data.MapObj[0].HexObj[index73, index49].LISpull;
                        int[] numArray23 = liSpull5;
                        int index82 = 0;
                        int index83 = index82;
                        int num65 = liSpull5[index82] + num64;
                        numArray23[index83] = num65;
                      }
                      if (num32 == 1)
                      {
                        int[] liSpull6 = this.game.Data.MapObj[0].HexObj[index73, index49].LISpull;
                        int[] numArray24 = liSpull6;
                        int index84 = 4;
                        int index85 = index84;
                        int num66 = liSpull6[index84] + index4;
                        numArray24[index85] = num66;
                        int[] liSpull7 = this.game.Data.MapObj[0].HexObj[index73, index49].LISpull;
                        int[] numArray25 = liSpull7;
                        int index86 = 0;
                        int index87 = index86;
                        int num67 = liSpull7[index86] + index4;
                        numArray25[index87] = num67;
                        index4 += numArray11[index73, index49];
                        int num68 = numArray11[index73, index49];
                        int[] liSpull8 = this.game.Data.MapObj[0].HexObj[index73, index49].LISpull;
                        int[] numArray26 = liSpull8;
                        int index88 = 0;
                        int index89 = index88;
                        int num69 = liSpull8[index88] + num68;
                        numArray26[index89] = num69;
                      }
                    }
                    else if (num32 == 1)
                    {
                      this.game.Data.MapObj[0].HexObj[index73, index49].LISpull[4] = -index4;
                      this.game.Data.MapObj[0].HexObj[index73, index49].LISpull[0] = -index4;
                    }
                  }
                  if (index4 > 0)
                  {
                    bool flag8 = true;
                    int num70 = -1;
                    while (flag8)
                    {
                      ++num70;
                      if (num70 <= 0 || num70 <= 10)
                      {
                        int num71 = index4;
                        flag8 = false;
                        if (num70 > 0)
                        {
                          switch (num32)
                          {
                            case 1:
                              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, 8, 0, 1000, index18, y1, 0, NoAPPenalties: true, roadsOnly: true, lisMode: -1, specialRuleNumber: 3, specialRuleNumber2: index4);
                              break;
                            case 2:
                              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, 11, 0, 2000, index18, y1, 0, NoAPPenalties: true, roadsOnly: true, lisMode: -1, specialRuleNumber: 3, specialRuleNumber2: index4);
                              CoordList tCoordList = new CoordList();
                              int mapWidth18 = this.game.Data.MapObj[0].MapWidth;
                              for (int x = 0; x <= mapWidth18; ++x)
                              {
                                int mapHeight2 = this.game.Data.MapObj[0].MapHeight;
                                for (int y3 = 0; y3 <= mapHeight2; ++y3)
                                {
                                  if (this.game.EditObj.TempValue[0].Value[x, y3] < 9999)
                                    tCoordList.AddCoord(x, y3, 0, this.game.EditObj.TempValue[0].Value[x, y3], 0);
                                }
                              }
                              this.game.HandyFunctionsObj.MakeMovePrediction2_multiStart(tCoordList, this.game.Data.Turn, 10, 0, 200, index18, y1, 0, NoAPPenalties: true, lisMode: -1);
                              break;
                            case 3:
                              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, 8, 0, 1000, index18, y1, 0, NoAPPenalties: true, roadsOnly: true, lisMode: -1, specialRuleNumber: 3, specialRuleNumber2: index4);
                              break;
                          }
                        }
                        Coordinate coordinate3;
                        coordinate3.onmap = true;
                        coordinate3.x = index73;
                        coordinate3.y = index49;
                        Coordinate coordinate4;
                        for (; coordinate3.onmap; coordinate3 = coordinate4)
                        {
                          coordinate4 = this.game.EditObj.TempCameFrom[0].Value[coordinate3.x, coordinate3.y];
                          if (coordinate4.onmap | coordinate4.x == index18 & coordinate4.y == y1)
                          {
                            int index90 = this.game.HandyFunctionsObj.HexFacing(coordinate3.x, coordinate3.y, 0, coordinate4.x, coordinate4.y, 0) - 1;
                            int index91 = index90 + 3;
                            if (index91 > 5)
                              index91 -= 6;
                            if (numArray2[coordinate4.x, coordinate4.y, index91, 2] < 7)
                            {
                              if (numArray2[coordinate4.x, coordinate4.y, index91, 2] == 0)
                                index50 = 100;
                              if (numArray2[coordinate4.x, coordinate4.y, index91, 2] == 1)
                                index50 = 80;
                              if (numArray2[coordinate4.x, coordinate4.y, index91, 2] == 2)
                                index50 = 60;
                              if (numArray2[coordinate4.x, coordinate4.y, index91, 2] == 3)
                                index50 = 40;
                              if (numArray2[coordinate4.x, coordinate4.y, index91, 2] == 4)
                                index50 = 20;
                              if (numArray2[coordinate4.x, coordinate4.y, index91, 2] == 5)
                                index50 = 10;
                              if (numArray2[coordinate4.x, coordinate4.y, index91, 2] == 6)
                                index50 = 5;
                              if (index50 < 100)
                                index4 = (int) Math.Round(Math.Floor((double) (index4 * index50) / 100.0));
                            }
                            else if (numArray2[coordinate4.x, coordinate4.y, index91, 2] == 7)
                              index4 = 0;
                            if (coordinate4.x == 22 & coordinate4.y == 15)
                              index4 = index4;
                            if (index4 > this.game.EditObj.PossiblePull[coordinate4.x, coordinate4.y, index91])
                              index4 = this.game.EditObj.PossiblePull[coordinate4.x, coordinate4.y, index91];
                            if (num32 == 3)
                            {
                              if ((int) Math.Round(Math.Floor((double) (numArray10[coordinate3.x, coordinate3.y, 6] * index50) / 100.0)) > index4)
                                index4 = numArray10[coordinate3.x, coordinate3.y, 6];
                              if (index4 > numArray10[coordinate4.x, coordinate4.y, index91])
                              {
                                int[,,] numArray27 = numArray10;
                                int[,,] numArray28 = numArray27;
                                int x = coordinate4.x;
                                int index92 = x;
                                int y4 = coordinate4.y;
                                int index93 = y4;
                                int index94 = 6;
                                int index95 = index94;
                                int num72 = numArray27[x, y4, index94] + (index4 - numArray10[coordinate4.x, coordinate4.y, index91]);
                                numArray28[index92, index93, index95] = num72;
                                numArray10[coordinate4.x, coordinate4.y, index91] = index4;
                              }
                              if (index4 > numArray3[coordinate4.x, coordinate4.y, index91])
                              {
                                if (coordinate3.x == 8 & coordinate3.y == 26)
                                  index4 = index4;
                                num31 = 0;
                                int num73 = 0;
                                Coordinate coordinate5 = this.game.EditObj.TempCameFrom[0].Value[coordinate4.x, coordinate4.y];
                                if (coordinate5.onmap)
                                {
                                  index50 = this.game.HandyFunctionsObj.HexFacing(coordinate5.x, coordinate5.y, 0, coordinate4.x, coordinate4.y, 0) - 1;
                                  num73 = numArray7[coordinate5.x, coordinate5.y, index50];
                                }
                                int num74 = numArray7[coordinate4.x, coordinate4.y, index91];
                                if (num73 > num74)
                                {
                                  int[,,] numArray29 = numArray10;
                                  int[,,] numArray30 = numArray29;
                                  int x = coordinate4.x;
                                  int index96 = x;
                                  int y5 = coordinate4.y;
                                  int index97 = y5;
                                  int index98 = 6;
                                  int index99 = index98;
                                  int num75 = numArray29[x, y5, index98] + (num73 - num74);
                                  numArray30[index96, index97, index99] = num75;
                                }
                                int[,,] possiblePull = this.game.EditObj.PossiblePull;
                                int[,,] numArray31 = possiblePull;
                                int x1 = coordinate4.x;
                                int index100 = x1;
                                int y6 = coordinate4.y;
                                int index101 = y6;
                                int index102 = index91;
                                int index103 = index102;
                                int num76 = possiblePull[x1, y6, index102] - Math.Max(0, index4 - numArray10[coordinate3.x, coordinate3.y, index90] - numArray3[coordinate4.x, coordinate4.y, index91]);
                                numArray31[index100, index101, index103] = num76;
                                if (0 > this.game.EditObj.PossiblePull[coordinate4.x, coordinate4.y, index91])
                                  this.game.EditObj.PossiblePull[coordinate4.x, coordinate4.y, index91] = 0;
                                if (index4 > numArray3[coordinate4.x, coordinate4.y, index91])
                                  numArray3[coordinate4.x, coordinate4.y, index91] = index4;
                              }
                            }
                            else
                            {
                              int[,,] numArray32 = numArray3;
                              int[,,] numArray33 = numArray32;
                              int x2 = coordinate4.x;
                              int index104 = x2;
                              int y7 = coordinate4.y;
                              int index105 = y7;
                              int index106 = index91;
                              int index107 = index106;
                              int num77 = numArray32[x2, y7, index106] + index4;
                              numArray33[index104, index105, index107] = num77;
                              int[,,] possiblePull = this.game.EditObj.PossiblePull;
                              int[,,] numArray34 = possiblePull;
                              int x3 = coordinate4.x;
                              int index108 = x3;
                              int y8 = coordinate4.y;
                              int index109 = y8;
                              int index110 = index91;
                              int index111 = index110;
                              int num78 = possiblePull[x3, y8, index110] - index4;
                              numArray34[index108, index109, index111] = num78;
                            }
                            if (index4 < 1)
                              break;
                          }
                        }
                        if (num71 > index4 & num71 != index4 & num71 > 0 & index4 > 0)
                        {
                          flag8 = true;
                          index4 = num71 - index4;
                        }
                      }
                      else
                        break;
                    }
                  }
                }
              }
            }
            ++num32;
          }
          while (num32 <= 3);
          int mapWidth19 = this.game.Data.MapObj[0].MapWidth;
          for (int index112 = 0; index112 <= mapWidth19; ++index112)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (index49 = 0; index49 <= mapHeight; ++index49)
            {
              int index113 = 0;
              do
              {
                this.game.Data.MapObj[0].HexObj[index112, index49].tempPreviewRoadPull[index113] = numArray3[index112, index49, index113];
                ++index113;
              }
              while (index113 <= 5);
            }
          }
        }
      }
      if (!isCalibrationCall & isPreview)
      {
        int locCounter5 = this.game.Data.LocCounter;
        for (int locnr = 0; locnr <= locCounter5; ++locnr)
        {
          int x = this.game.Data.LocObj[locnr].X;
          int y9 = this.game.Data.LocObj[locnr].Y;
          flag5 = false;
          this.game.Data.LocObj[locnr].tempLIS = new SimpleList();
          this.game.Data.LocObj[locnr].tempLISfreeAP = new SimpleList();
          if (this.game.Data.MapObj[0].HexObj[x, y9].Regime == this.game.Data.Turn && num1 == -1 | num1 == x & num2 == y9)
          {
            if (num1 == -1)
            {
              int id = this.game.Data.LocObj[locnr].ID;
              int num79 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(6, id, 0)));
              DataClass data9 = this.game.Data;
              string str9 = "truckPoints";
              ref string local9 = ref str9;
              string libName15 = libName1;
              int libVar9 = data9.FindLibVar(ref local9, libName15);
              int hexLibVarValue4 = this.game.Data.MapObj[0].HexObj[x, y9].GetHexLibVarValue(libVar9);
              if (this.game.Data.RegimeObj[this.game.Data.Turn].AI & num79 > 0)
                hexLibVarValue4 += 150000;
              DataClass data10 = this.game.Data;
              string str10 = "truckFreeAp";
              ref string local10 = ref str10;
              string libName16 = libName1;
              int libVar10 = data10.FindLibVar(ref local10, libName16);
              int hexLibVarValue5 = this.game.Data.MapObj[0].HexObj[x, y9].GetHexLibVarValue(libVar10);
              if (this.game.Data.RegimeObj[this.game.Data.Turn].AI & num79 > 0)
                hexLibVarValue5 += 1000;
              DataClass data11 = this.game.Data;
              string str11 = "maglevPoints";
              ref string local11 = ref str11;
              string libName17 = libName1;
              int libVar11 = data11.FindLibVar(ref local11, libName17);
              int hexLibVarValue6 = this.game.Data.MapObj[0].HexObj[x, y9].GetHexLibVarValue(libVar11);
              DataClass data12 = this.game.Data;
              string str12 = "maglevFreeAp";
              ref string local12 = ref str12;
              string libName18 = libName1;
              int libVar12 = data12.FindLibVar(ref local12, libName18);
              int hexLibVarValue7 = this.game.Data.MapObj[0].HexObj[x, y9].GetHexLibVarValue(libVar12);
              this.game.EventRelatedObj.ExecSetLIS(locnr, 1, -1, hexLibVarValue4, "");
              this.game.EventRelatedObj.ExecSetLISfreeAP(locnr, 1, -1, hexLibVarValue5, "");
              this.game.EventRelatedObj.ExecSetLIS(locnr, 2, -1, hexLibVarValue6, "");
              this.game.EventRelatedObj.ExecSetLISfreeAP(locnr, 2, -1, hexLibVarValue7, "");
            }
            else
            {
              if (pts4 > 0)
                this.game.EventRelatedObj.ExecSetLIS(locnr, 1, -1, pts4, "");
              if (pts3 > 0)
                this.game.EventRelatedObj.ExecSetLISfreeAP(locnr, 1, -1, pts3, "");
              if (pts2 > 0)
                this.game.EventRelatedObj.ExecSetLIS(locnr, 2, -1, pts2, "");
              if (pts1 > 0)
                this.game.EventRelatedObj.ExecSetLISfreeAP(locnr, 2, -1, pts1, "");
            }
          }
        }
      }
      int num80 = 0;
      do
      {
        int locCounter6 = this.game.Data.LocCounter;
        for (int index114 = 0; index114 <= locCounter6; ++index114)
        {
          int x = this.game.Data.LocObj[index114].X;
          int y10 = this.game.Data.LocObj[index114].Y;
          bool flag9 = false;
          if (this.game.Data.MapObj[0].HexObj[x, y10].Regime == this.game.Data.Turn && !Information.IsNothing((object) this.game.Data.LocObj[index114].tempLIS) && this.game.Data.LocObj[index114].tempLIS.Counter > -1)
            flag9 = true;
          if (flag9)
          {
            if (x == 89 & y10 == 13)
              x = x;
            int num81 = 100;
            int length = this.game.Data.StringListObj[stringListById6].Length;
            for (int index115 = 0; index115 <= length; ++index115)
            {
              int index116 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].Data[index115, 0]));
              bool flag10 = false;
              if (num80 == 1 & index116 == 1)
                flag10 = true;
              if (num80 == 0 & index116 == 2)
                flag10 = true;
              if (flag10)
              {
                int movetype2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].Data[index115, 4]));
                string str13 = this.game.Data.StringListObj[stringListById6].Data[index115, 1];
                int theater = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].Data[index115, 2]));
                int nr = this.game.Data.LocObj[index114].tempLIS.FindNr(index116);
                int num82 = 0;
                if (nr > -1)
                  num82 = (int) Math.Round(Math.Floor((double) (this.game.Data.LocObj[index114].tempLIS.Weight[nr] * num81) / 100.0));
                if (num82 > 0)
                {
                  int index117 = this.game.Data.LocObj[index114].tempLISfreeAP.FindNr(index116);
                  int num83 = 0;
                  if (index117 > -1)
                    num83 = this.game.Data.LocObj[index114].tempLISfreeAP.Weight[index117];
                  if (num83 > 0)
                  {
                    int num84 = 1;
                    if (!isCalibrationCall & index116 == 2 & flag1)
                      num84 = 2;
                    int num85 = num84;
                    for (int index118 = 1; index118 <= num85; ++index118)
                    {
                      bool flag11 = flag1;
                      int num86;
                      CoordList coordList;
                      if (!isCalibrationCall & index116 == 2 & flag1)
                      {
                        if (index118 == 1)
                        {
                          index117 = this.game.Data.LocObj[index114].tempLIS.FindNr(index116);
                          num86 = 0;
                          num82 = (int) Math.Round(Math.Floor((double) (this.game.Data.LocObj[index114].tempLIS.Weight[index117] * num81) / 100.0 * 0.9));
                          coordList = this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype2, theater, num83 * 2, x, y10, 0, NoAPPenalties: isPreview, tempZoneTest: true, roadsOnly: true, alwaysUseLogisticalBonus: true, lisMode: index116);
                        }
                        else
                        {
                          flag11 = false;
                          index117 = this.game.Data.LocObj[index114].tempLIS.FindNr(index116);
                          num86 = 0;
                          num82 = (int) Math.Round(Math.Floor((double) (this.game.Data.LocObj[index114].tempLIS.Weight[index117] * num81) / 100.0 * 0.1));
                          coordList = this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype2, theater, num83 * 2, x, y10, 0, NoAPPenalties: isPreview, roadsOnly: true, alwaysUseLogisticalBonus: true, lisMode: index116);
                        }
                      }
                      else
                        coordList = this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype2, theater, num83 * 2, x, y10, 0, NoAPPenalties: isPreview, roadsOnly: true, alwaysUseLogisticalBonus: true, lisMode: index116);
                      int tid4 = 0;
                      int num87 = 0;
                      LisRunner[] arySrc = new LisRunner[1];
                      arySrc[0].awaitingSplit = true;
                      arySrc[0].originRunner = new SimpleList();
                      arySrc[0].originRunner.Add(0, 1, CheckExistence: false);
                      arySrc[0].x = x;
                      arySrc[0].y = y10;
                      arySrc[0].apUsed = 0;
                      arySrc[0].direction = -1;
                      arySrc[0].lisPoints = num82;
                      bool flag12 = true;
                      bool flag13 = true;
                      string[] strArray1 = new string[2]
                      {
                        "[",
                        "]"
                      };
                      SimpleList[,] simpleListArray = new SimpleList[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
                      simpleListArray[x, y10] = new SimpleList();
                      simpleListArray[x, y10].AddBlind(0, 1);
                      int[] liSpoints1 = this.game.Data.MapObj[0].HexObj[x, y10].LISpoints;
                      int[] numArray35 = liSpoints1;
                      int index119 = 6;
                      int index120 = index119;
                      int num88 = liSpoints1[index119] + num82;
                      numArray35[index120] = num88;
                      if (index1 > -1 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                      {
                        if (x == 13 & y10 == 11)
                          x = x;
                        s4 = num82.ToString() + " Logistical Pts using '" + str13 + "' movement have been generated in Hex";
                        this.game.Data.StringListObj[index1].AddRowWithData(x.ToString(), y10.ToString(), "4", "0", s4, x.ToString(), y10.ToString(), index116.ToString());
                      }
                      while (flag13)
                      {
                        flag13 = false;
                        int num89 = num87;
                        int num90 = tid4;
                        int num91;
                        for (int index121 = num89; index121 <= num90; ++index121)
                        {
                          if (arySrc[index121].active)
                          {
                            flag13 = true;
                            arySrc[index121].active = false;
                            arySrc[index121].awaitingSplit = false;
                            bool flag14 = true;
                            if (index121 == 194)
                              index121 = index121;
                            while (flag14)
                            {
                              flag14 = false;
                              Coordinate coordinate6 = this.game.HandyFunctionsObj.HexNeighbour(arySrc[index121].x, arySrc[index121].y, 0, arySrc[index121].direction + 1);
                              Coordinate coordinate7 = this.game.HandyFunctionsObj.MoveApCostPreview2(arySrc[index121].x, arySrc[index121].y, this.game.Data.Turn, movetype2, theater, arySrc[index121].x, arySrc[index121].y, 0, coordinate6.x, coordinate6.y, 0, NoAPPenalties: isPreview, roadsOnly: true, alwaysUseLogisticalBonus: true);
                              int index122 = this.game.Data.MapObj[0].HexObj[arySrc[index121].x, arySrc[index121].y].RoadType[arySrc[index121].direction];
                              if (index122 > -1)
                              {
                                if (this.game.Data.RoadTypeObj[index122].MoveCostOverrule[movetype2] >= 999)
                                  coordinate6.onmap = false;
                              }
                              else
                                coordinate6.onmap = false;
                              if (coordinate6.onmap && index116 == 2 & index118 == 1 && this.game.EditObj.tempZoneTest[coordinate6.x, coordinate6.y] < 1)
                                coordinate6.onmap = false;
                              if (coordinate6.onmap)
                              {
                                if (arySrc[index121].x == 14 & arySrc[index121].y == 12)
                                  index121 = index121;
                                if (arySrc[index121].apUsed + coordinate7.x < num83 * 2)
                                {
                                  int num92 = this.game.HandyFunctionsObj.GetLogisticalBonus(arySrc[index121].x, arySrc[index121].y, index116);
                                  if ((int) Math.Round(Conversion.Val(this.game.Data.Designer)) > 40 && arySrc[index121].apUsed < num92)
                                  {
                                    num92 = arySrc[index121].apUsed;
                                    if (0 > num92)
                                      num92 = 0;
                                  }
                                  if (isPreview & num5 > 0 && arySrc[index121].x == num3 & arySrc[index121].y == num4 & num3 > -1)
                                  {
                                    num92 -= num5;
                                    if (0 > num92)
                                      num92 = 0;
                                  }
                                  if (num92 > arySrc[index121].extensionAllowed)
                                    arySrc[index121].extensionAllowed = num92;
                                  int num93 = arySrc[index121].extensionAllowed - arySrc[index121].extensionUsed;
                                  int num94 = coordinate7.x;
                                  if (num93 > 0)
                                  {
                                    if (num94 > num93)
                                    {
                                      num94 -= num93;
                                      arySrc[index121].extensionUsed = arySrc[index121].extensionAllowed;
                                    }
                                    else
                                    {
                                      LisRunner[] lisRunnerArray1 = arySrc;
                                      LisRunner[] lisRunnerArray2 = lisRunnerArray1;
                                      index119 = index121;
                                      int index123 = index119;
                                      lisRunnerArray2[index123].extensionUsed = lisRunnerArray1[index119].extensionUsed + num94;
                                      num94 = 0;
                                    }
                                  }
                                  index117 = arySrc[index121].apUsed + num94 <= num83 ? arySrc[index121].lisPoints : (int) Math.Round((double) arySrc[index121].lisPoints * ((double) (num83 - (arySrc[index121].apUsed + num94 - num83)) / (double) num83));
                                  LisRunner[] lisRunnerArray3 = arySrc;
                                  LisRunner[] lisRunnerArray4 = lisRunnerArray3;
                                  index119 = index121;
                                  int index124 = index119;
                                  lisRunnerArray4[index124].apUsed = lisRunnerArray3[index119].apUsed + num94;
                                  int num95 = arySrc[index121].direction + 3;
                                  if (num95 > 5)
                                    num95 -= 6;
                                  bool flag15 = false;
                                  bool flag16 = false;
                                  bool flag17 = false;
                                  if (arySrc[index121].x == 47 & arySrc[index121].y == 17 & coordinate6.x == 47 & coordinate6.y == 18)
                                    index117 = index117;
                                  if (coordinate6.x == 42 & coordinate6.y == 21 & arySrc[index121].x == 42 & arySrc[index121].y == 20)
                                    index117 = index117;
                                  if (!Information.IsNothing((object) simpleListArray[coordinate6.x, coordinate6.y]))
                                  {
                                    num31 = 0;
                                    int num96 = 0;
                                    int num97 = 0;
                                    int num98 = 0;
                                    int num99 = 0;
                                    num91 = 0;
                                    int counter7 = simpleListArray[coordinate6.x, coordinate6.y].Counter;
                                    for (int index125 = 0; index125 <= counter7; ++index125)
                                    {
                                      int num100 = 0;
                                      ++num97;
                                      int counter8 = arySrc[index121].originRunner.Counter;
                                      for (int index126 = 0; index126 <= counter8; ++index126)
                                      {
                                        if (arySrc[index121].originRunner.Id[index126] == simpleListArray[coordinate6.x, coordinate6.y].Id[index125])
                                          ++num100;
                                      }
                                      if (num100 > 0)
                                        ++num96;
                                    }
                                    int counter9 = arySrc[index121].originRunner.Counter;
                                    for (index50 = 0; index50 <= counter9; ++index50)
                                    {
                                      int num101 = 0;
                                      ++num99;
                                      int counter10 = simpleListArray[coordinate6.x, coordinate6.y].Counter;
                                      for (int index127 = 0; index127 <= counter10; ++index127)
                                      {
                                        if (arySrc[index121].originRunner.Id[index50] == simpleListArray[coordinate6.x, coordinate6.y].Id[index127])
                                          ++num101;
                                      }
                                      if (num101 > 0)
                                        ++num98;
                                    }
                                    if (num98 == num99 | num96 == num97)
                                      flag17 = true;
                                    if (this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                                    {
                                      if (arySrc[index121].originRunner.Counter > 9)
                                      {
                                        flag15 = true;
                                        flag16 = true;
                                        flag17 = true;
                                      }
                                    }
                                    else if (arySrc[index121].originRunner.Counter > 29)
                                    {
                                      flag15 = true;
                                      flag16 = true;
                                      flag17 = true;
                                    }
                                  }
                                  if (!flag17)
                                  {
                                    if (Information.IsNothing((object) simpleListArray[coordinate6.x, coordinate6.y]))
                                      simpleListArray[coordinate6.x, coordinate6.y] = new SimpleList();
                                    simpleListArray[coordinate6.x, coordinate6.y].AddWeightBlind(ref arySrc[index121].originRunner);
                                  }
                                  if (flag15 | flag16)
                                    index117 = 0;
                                  if (!flag15 & index117 > 0)
                                  {
                                    int[] liSpoints2 = this.game.Data.MapObj[0].HexObj[arySrc[index121].x, arySrc[index121].y].LISpoints;
                                    int[] numArray36 = liSpoints2;
                                    index119 = arySrc[index121].direction;
                                    int index128 = index119;
                                    int num102 = liSpoints2[index119] + index117;
                                    numArray36[index128] = num102;
                                    arySrc[index121].awaitingSplit = false;
                                  }
                                  if (index1 > -1 & index117 > 0 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                                  {
                                    if (!flag15)
                                      s4 = "Sent " + index117.ToString() + " " + str13 + " Points (ap=" + arySrc[index121].apUsed.ToString() + "/" + num83.ToString() + " ext=" + arySrc[index121].extensionUsed.ToString() + "/" + arySrc[index121].extensionAllowed.ToString() + " br=" + Math.Round((double) Math.Max(0, arySrc[index121].branchCount - 100) / 100.0, 2).ToString() + ")";
                                    if (flag15)
                                      s4 = "Sent Back " + index117.ToString() + " " + str13 + " Points (ap=" + arySrc[index121].apUsed.ToString() + "/" + num83.ToString() + " ext=" + arySrc[index121].extensionUsed.ToString() + "/" + arySrc[index121].extensionAllowed.ToString() + ")";
                                    if (flag17)
                                      s4 += " [End]";
                                    s4 += " to ";
                                    if (arySrc[index121].direction == 0)
                                      s4 += "North.";
                                    if (arySrc[index121].direction == 1)
                                      s4 += "North-East.";
                                    if (arySrc[index121].direction == 2)
                                      s4 += "South-East.";
                                    if (arySrc[index121].direction == 3)
                                      s4 += "South.";
                                    if (arySrc[index121].direction == 4)
                                      s4 += "South-West.";
                                    if (arySrc[index121].direction == 5)
                                      s4 += "North-West.";
                                    this.game.Data.StringListObj[index1].AddRowWithData(arySrc[index121].x.ToString(), arySrc[index121].y.ToString(), "2", arySrc[index121].direction.ToString(), s4, x.ToString(), y10.ToString(), index116.ToString());
                                  }
                                  if (!arySrc[index121].splitJustDone && !flag15 & index117 > 0 && (int) Math.Round(Conversion.Val(this.game.Data.Designer)) >= 42 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI & !this.game.Data.RegimeObj[this.game.Data.Turn].minimumDataUsage && numArray3[arySrc[index121].x, arySrc[index121].y, arySrc[index121].direction] > 0)
                                  {
                                    if (index1 > -1)
                                    {
                                      index119 = Math.Min(numArray3[arySrc[index121].x, arySrc[index121].y, arySrc[index121].direction], index117);
                                      s4 = index119.ToString() + " Pull Points have been removed (dir=";
                                      if (arySrc[index121].direction == 0)
                                        s4 += "North).";
                                      if (arySrc[index121].direction == 1)
                                        s4 += "North-East).";
                                      if (arySrc[index121].direction == 2)
                                        s4 += "South-East).";
                                      if (arySrc[index121].direction == 3)
                                        s4 += "South).";
                                      if (arySrc[index121].direction == 4)
                                        s4 += "South-West).";
                                      if (arySrc[index121].direction == 5)
                                        s4 += "North-West).";
                                      this.game.Data.StringListObj[index1].AddRowWithData(arySrc[index121].x.ToString(), arySrc[index121].y.ToString(), "3", arySrc[index121].direction.ToString(), s4, "-1", "-1", "0");
                                    }
                                    int[,,] numArray37 = numArray3;
                                    int[,,] numArray38 = numArray37;
                                    index119 = arySrc[index121].x;
                                    int index129 = index119;
                                    int y11 = arySrc[index121].y;
                                    int index130 = y11;
                                    int direction = arySrc[index121].direction;
                                    int index131 = direction;
                                    int num103 = numArray37[index119, y11, direction] - index117;
                                    numArray38[index129, index130, index131] = num103;
                                    if (0 > numArray3[arySrc[index121].x, arySrc[index121].y, arySrc[index121].direction])
                                      numArray3[arySrc[index121].x, arySrc[index121].y, arySrc[index121].direction] = 0;
                                  }
                                  if (!flag16 & index117 > 0)
                                  {
                                    int[] liSpoints3 = this.game.Data.MapObj[0].HexObj[coordinate6.x, coordinate6.y].LISpoints;
                                    int[] numArray39 = liSpoints3;
                                    index119 = num95;
                                    int index132 = index119;
                                    int num104 = liSpoints3[index119] + index117;
                                    numArray39[index132] = num104;
                                  }
                                  if (index1 > -1 & index117 > 0 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                                  {
                                    if (!flag16)
                                      s4 = "Rec. " + index117.ToString() + " " + str13 + " Points (ap=" + arySrc[index121].apUsed.ToString() + "/" + num83.ToString() + " ext=" + arySrc[index121].extensionUsed.ToString() + "/" + arySrc[index121].extensionAllowed.ToString() + " br=" + Math.Round((double) Math.Max(0, arySrc[index121].branchCount - 100) / 100.0, 2).ToString() + ")";
                                    if (flag16)
                                      s4 = "Rec. Sent Back " + index117.ToString() + " " + str13 + " Points (ap=" + arySrc[index121].apUsed.ToString() + "/" + num83.ToString() + " ext=" + arySrc[index121].extensionUsed.ToString() + "/" + arySrc[index121].extensionAllowed.ToString() + ")";
                                    if (flag17)
                                      s4 += " [End]";
                                    s4 += " from ";
                                    if (num95 == 0)
                                      s4 += "North.";
                                    if (num95 == 1)
                                      s4 += "North-East.";
                                    if (num95 == 2)
                                      s4 += "South-East.";
                                    if (num95 == 3)
                                      s4 += "South.";
                                    if (num95 == 4)
                                      s4 += "South-West.";
                                    if (num95 == 5)
                                      s4 += "North-West.";
                                    this.game.Data.StringListObj[index1].AddRowWithData(coordinate6.x.ToString(), coordinate6.y.ToString(), "1", num95.ToString(), s4, x.ToString(), y10.ToString(), index116.ToString());
                                  }
                                  if (!flag17 & index117 > 0)
                                  {
                                    int[] liSpoints4 = this.game.Data.MapObj[0].HexObj[coordinate6.x, coordinate6.y].LISpoints;
                                    int[] numArray40 = liSpoints4;
                                    index119 = 6;
                                    int index133 = index119;
                                    int num105 = liSpoints4[index119] + index117;
                                    numArray40[index133] = num105;
                                  }
                                  arySrc[index121].splitJustDone = false;
                                  if (numArray1[coordinate6.x, coordinate6.y, index116] > 0 & !flag17)
                                  {
                                    if ((int) Math.Round(Conversion.Val(this.game.Data.Designer)) == 49)
                                    {
                                      flag17 = true;
                                      if (index1 > -1 & index117 > 0 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                                      {
                                        if (index116 == 1)
                                          s4 = "[Truck Points End with meeting other Truck Logistics Asset]";
                                        if (index116 == 2)
                                          s4 = "[Rail Points End with meeting other Rail Logistics Asset]";
                                        this.game.Data.StringListObj[index1].AddRowWithData(coordinate6.x.ToString(), coordinate6.y.ToString(), "1", num95.ToString(), s4, x.ToString(), y10.ToString(), index116.ToString());
                                      }
                                    }
                                    else if ((int) Math.Round(Conversion.Val(this.game.Data.Designer)) >= 50)
                                    {
                                      LisRunner[] lisRunnerArray5 = arySrc;
                                      LisRunner[] lisRunnerArray6 = lisRunnerArray5;
                                      index119 = index121;
                                      int index134 = index119;
                                      lisRunnerArray6[index134].reFocusCount = lisRunnerArray5[index119].reFocusCount + 1;
                                      if (arySrc[index121].reFocusCount <= 3)
                                      {
                                        string[] strArray2 = new string[5]
                                        {
                                          "LogPts -",
                                          null,
                                          null,
                                          null,
                                          null
                                        };
                                        string[] strArray3 = strArray2;
                                        index119 = (int) Math.Round((double) (arySrc[index121].apUsed * 100) / (double) (num83 * 2));
                                        string str14 = index119.ToString();
                                        strArray3[1] = str14;
                                        strArray2[2] = "% for ";
                                        strArray2[3] = arySrc[index121].apUsed.ToString();
                                        strArray2[4] = "AP";
                                        string str15 = string.Concat(strArray2);
                                        int num106 = arySrc[index121].lisPoints - (int) Math.Round((double) arySrc[index121].lisPoints * ((double) arySrc[index121].apUsed / (double) (num83 * 2)));
                                        arySrc[index121].apUsed = 0;
                                        if (arySrc[index121].reFocusCount == 1)
                                        {
                                          num106 = (int) Math.Round((double) num106 * 0.75);
                                          str15 = "1st refocus. " + str15 + " & -25%.";
                                        }
                                        if (arySrc[index121].reFocusCount == 2)
                                        {
                                          num106 = (int) Math.Round((double) num106 * 0.5);
                                          str15 = "2nd refocus. " + str15 + " & -50%.";
                                        }
                                        if (arySrc[index121].reFocusCount == 3)
                                        {
                                          num106 = (int) Math.Round((double) num106 * 0.25);
                                          str15 = "3rd refocus. " + str15 + " & -75%.";
                                        }
                                        arySrc[index121].lisPoints = num106;
                                        string str16 = str15 + " " + num106.ToString() + " LP refocussed.";
                                        if (index1 > -1 & index117 > 0 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                                        {
                                          if (index116 == 1)
                                            s4 = "[Trucks " + str16 + "]";
                                          if (index116 == 2)
                                            s4 = "[Rail " + str16 + "]";
                                          this.game.Data.StringListObj[index1].AddRowWithData(coordinate6.x.ToString(), coordinate6.y.ToString(), "1", num95.ToString(), s4, x.ToString(), y10.ToString(), index116.ToString());
                                        }
                                      }
                                      else
                                      {
                                        flag17 = true;
                                        if (index1 > -1 & index117 > 0 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                                        {
                                          if (index116 == 1)
                                            s4 = "[Truck Points end with 4th time meeting other Truck Asset]";
                                          if (index116 == 2)
                                            s4 = "[Rail Points end with 4th time meeting other Rail Asset]";
                                          this.game.Data.StringListObj[index1].AddRowWithData(coordinate6.x.ToString(), coordinate6.y.ToString(), "1", num95.ToString(), s4, x.ToString(), y10.ToString(), index116.ToString());
                                        }
                                      }
                                    }
                                  }
                                  if (flag17)
                                  {
                                    arySrc[index121].awaitingSplit = false;
                                  }
                                  else
                                  {
                                    arySrc[index121].x = coordinate6.x;
                                    arySrc[index121].y = coordinate6.y;
                                    int num107 = -1;
                                    int num108 = 0;
                                    int num109 = 0;
                                    if (coordinate6.x == 13 & coordinate6.y == 11)
                                      index121 = index121;
                                    int num110 = index116 - 1;
                                    if (arySrc[index121].isPull)
                                      num110 = 3;
                                    int index135 = 0;
                                    do
                                    {
                                      if (index135 != num95)
                                      {
                                        Coordinate coordinate8 = this.game.HandyFunctionsObj.HexNeighbour(coordinate6.x, coordinate6.y, 0, index135 + 1);
                                        if (coordinate8.onmap)
                                        {
                                          Coordinate coordinate9 = this.game.HandyFunctionsObj.MoveApCostPreview2(coordinate6.x, coordinate6.y, this.game.Data.Turn, movetype2, theater, coordinate6.x, coordinate6.y, 0, coordinate8.x, coordinate8.y, 0, roadsOnly: true, alwaysUseLogisticalBonus: true);
                                          int index136 = this.game.Data.MapObj[0].HexObj[coordinate6.x, coordinate6.y].RoadType[index135];
                                          if (index136 > -1)
                                          {
                                            if (this.game.Data.RoadTypeObj[index136].MoveCostOverrule[movetype2] >= 999)
                                              coordinate9.x = 9999;
                                          }
                                          else
                                            coordinate9.x = 9999;
                                          if (coordinate9.x < 999)
                                          {
                                            ++num108;
                                            num107 = index135;
                                          }
                                          else
                                            index121 = index121;
                                        }
                                      }
                                      else if (index135 != num95)
                                        ++num109;
                                      ++index135;
                                    }
                                    while (index135 <= 5);
                                    if (index117 > 0)
                                    {
                                      if (num108 == 1 & num109 == 0)
                                      {
                                        arySrc[index121].direction = num107;
                                        flag14 = true;
                                      }
                                      else if (num108 > 0 | num109 > 0)
                                      {
                                        if (arySrc[index121].x == 26 & arySrc[index121].y == 3)
                                          index121 = index121;
                                        arySrc[index121].direction = num95;
                                        flag14 = false;
                                        arySrc[index121].awaitingSplit = true;
                                        if (num108 == 0)
                                          arySrc[index121].direction = -1;
                                      }
                                    }
                                    else
                                    {
                                      index117 = index117;
                                      arySrc[index121].awaitingSplit = false;
                                    }
                                  }
                                }
                              }
                              else
                                arySrc[index121].awaitingSplit = false;
                            }
                          }
                        }
                        int num111 = num87;
                        int num112 = tid4;
                        for (int index137 = num111; index137 <= num112; ++index137)
                        {
                          if (arySrc[index137].awaitingSplit)
                          {
                            flag13 = true;
                            arySrc[index137].awaitingSplit = false;
                            arySrc[index137].active = false;
                            SimpleList simpleList = new SimpleList();
                            int tid5 = 0;
                            do
                            {
                              if (tid5 != arySrc[index137].direction)
                              {
                                Coordinate coordinate10 = this.game.HandyFunctionsObj.HexNeighbour(arySrc[index137].x, arySrc[index137].y, 0, tid5 + 1);
                                if (coordinate10.onmap && index116 == 2 & index118 == 1 && this.game.EditObj.tempZoneTest[coordinate10.x, coordinate10.y] < 1)
                                  coordinate10.onmap = false;
                                if (coordinate10.onmap)
                                {
                                  Coordinate coordinate11 = this.game.HandyFunctionsObj.MoveApCostPreview2(arySrc[index137].x, arySrc[index137].y, this.game.Data.Turn, movetype2, theater, arySrc[index137].x, arySrc[index137].y, 0, coordinate10.x, coordinate10.y, 0, NoAPPenalties: isPreview, roadsOnly: true, alwaysUseLogisticalBonus: true);
                                  int index138 = this.game.Data.MapObj[0].HexObj[arySrc[index137].x, arySrc[index137].y].RoadType[tid5];
                                  if (index138 > -1)
                                  {
                                    if (this.game.Data.RoadTypeObj[index138].MoveCostOverrule[movetype2] >= 999)
                                      coordinate11.x = 9999;
                                  }
                                  else
                                    coordinate11.x = 9999;
                                  if (arySrc[index137].apUsed + coordinate11.x < num83 * 2)
                                  {
                                    num31 = 0;
                                    int num113 = 0;
                                    int num114 = 0;
                                    int num115 = 0;
                                    int num116 = 0;
                                    num91 = 0;
                                    if (arySrc[index137].x == 20 & arySrc[index137].y == 12)
                                      index117 = index117;
                                    bool flag18 = true;
                                    if (!Information.IsNothing((object) simpleListArray[coordinate10.x, coordinate10.y]))
                                    {
                                      int counter11 = simpleListArray[coordinate10.x, coordinate10.y].Counter;
                                      for (int index139 = 0; index139 <= counter11; ++index139)
                                      {
                                        int num117 = 0;
                                        ++num114;
                                        int counter12 = arySrc[index137].originRunner.Counter;
                                        for (int index140 = 0; index140 <= counter12; ++index140)
                                        {
                                          if (arySrc[index137].originRunner.Id[index140] == simpleListArray[coordinate10.x, coordinate10.y].Id[index139])
                                            ++num117;
                                        }
                                        if (num117 > 0)
                                          ++num113;
                                      }
                                      int counter13 = arySrc[index137].originRunner.Counter;
                                      for (index50 = 0; index50 <= counter13; ++index50)
                                      {
                                        int num118 = 0;
                                        ++num116;
                                        int counter14 = simpleListArray[coordinate10.x, coordinate10.y].Counter;
                                        for (int index141 = 0; index141 <= counter14; ++index141)
                                        {
                                          if (arySrc[index137].originRunner.Id[index50] == simpleListArray[coordinate10.x, coordinate10.y].Id[index141])
                                            ++num118;
                                        }
                                        if (num118 > 0)
                                          ++num115;
                                      }
                                      if (num113 == arySrc[index137].originRunner.Counter + 1)
                                        flag18 = false;
                                      if (num115 == num116)
                                        flag18 = false;
                                      if (num113 == num114)
                                        flag18 = false;
                                      if (this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                                      {
                                        if (arySrc[index137].originRunner.Counter > 11)
                                          flag18 = false;
                                      }
                                      else if (arySrc[index137].originRunner.Counter > 11)
                                        flag18 = false;
                                    }
                                    if (flag18)
                                      simpleList.Add(tid5, 10000, tdata3: coordinate11.x);
                                  }
                                }
                              }
                              ++tid5;
                            }
                            while (tid5 <= 5);
                            simpleList.ReverseSort();
                            bool flag19 = false;
                            int num119 = 0;
                            if ((int) Math.Round(Conversion.Val(this.game.Data.Designer)) >= 42 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI & !this.game.Data.RegimeObj[this.game.Data.Turn].minimumDataUsage)
                            {
                              flag19 = true;
                              num119 = 1;
                            }
                            int num120 = 0;
                            int num121 = 0;
                            int num122 = 0;
                            int num123 = 0;
                            if (flag19)
                            {
                              int counter = simpleList.Counter;
                              for (int index142 = 0; index142 <= counter; ++index142)
                              {
                                if (simpleList.Weight[0] == simpleList.Weight[index142])
                                {
                                  ++num123;
                                  if (numArray3[arySrc[index137].x, arySrc[index137].y, simpleList.Id[index142]] > 0)
                                  {
                                    ++num122;
                                    num120 += numArray3[arySrc[index137].x, arySrc[index137].y, simpleList.Id[index142]];
                                    simpleList.Data4[index142] = numArray3[arySrc[index137].x, arySrc[index137].y, simpleList.Id[index142]];
                                  }
                                }
                              }
                            }
                            if (num120 < 1 | num123 < 2)
                              num119 = 0;
                            for (int index143 = num119; index143 >= 0; index143 += -1)
                            {
                              int index144 = index116 - 1;
                              if (index143 == 1)
                                index144 = 3;
                              int num124 = 0;
                              int num125 = 0;
                              for (int counter = simpleList.Counter; counter >= 0; counter += -1)
                              {
                                if (simpleList.Weight[0] == simpleList.Weight[counter])
                                {
                                  if (numArray2[arySrc[index137].x, arySrc[index137].y, simpleList.Id[counter], index144] < 7)
                                  {
                                    ++num124;
                                    if (numArray2[arySrc[index137].x, arySrc[index137].y, simpleList.Id[counter], index144] == 0)
                                      index50 = 100;
                                    if (numArray2[arySrc[index137].x, arySrc[index137].y, simpleList.Id[counter], index144] == 1)
                                      index50 = 80;
                                    if (numArray2[arySrc[index137].x, arySrc[index137].y, simpleList.Id[counter], index144] == 2)
                                      index50 = 60;
                                    if (numArray2[arySrc[index137].x, arySrc[index137].y, simpleList.Id[counter], index144] == 3)
                                      index50 = 40;
                                    if (numArray2[arySrc[index137].x, arySrc[index137].y, simpleList.Id[counter], index144] == 4)
                                      index50 = 20;
                                    if (numArray2[arySrc[index137].x, arySrc[index137].y, simpleList.Id[counter], index144] == 5)
                                      index50 = 10;
                                    if (numArray2[arySrc[index137].x, arySrc[index137].y, simpleList.Id[counter], index144] == 6)
                                      index50 = 5;
                                    if (numArray2[arySrc[index137].x, arySrc[index137].y, simpleList.Id[counter], index144] == 7)
                                      index50 = 0;
                                    num125 += index50;
                                    simpleList.Data5[counter] = index50;
                                  }
                                  else
                                    simpleList.RemoveNr(counter);
                                }
                              }
                              if (index50 < 100 & num124 == 1 & simpleList.Counter > 0 && simpleList.Weight[1] > 0)
                              {
                                simpleList.Weight[1] = simpleList.Weight[0];
                                int index145 = 1;
                                ++num124;
                                if (numArray2[arySrc[index137].x, arySrc[index137].y, simpleList.Id[index145], index144] < 7)
                                {
                                  num125 += index50;
                                  index50 = 100 - index50;
                                  simpleList.Data5[index145] = index50;
                                }
                              }
                              if (num124 > 0)
                              {
                                simpleList.SortOnData5();
                                int num126 = simpleList.Counter <= 0 ? simpleList.Data5[simpleList.Counter] : simpleList.Data5[simpleList.Counter - 1];
                                if (index143 == 0)
                                  index137 = index137;
                                int num127 = num124 - 1;
                                for (int index146 = 0; index146 <= num127; ++index146)
                                {
                                  ++tid4;
                                  if (tid4 > arySrc.GetUpperBound(0) - 10)
                                    arySrc = (LisRunner[]) Utils.CopyArray((Array) arySrc, (Array) new LisRunner[tid4 + 5000 + 1]);
                                  arySrc[tid4].splitJustDone = false;
                                  if (arySrc[index137].x == 153 & arySrc[index137].y == 41 & index116 == 1)
                                    index50 = index50;
                                  int num128 = 0;
                                  int num129 = simpleList.Data4[index146];
                                  switch (index143)
                                  {
                                    case 0:
                                      index117 = (int) Math.Round(Math.Floor((double) Math.Max(0, arySrc[index137].lisPoints - num121) * ((double) simpleList.Data5[index146] / (double) num125)));
                                      break;
                                    case 1:
                                      index117 = (int) Math.Round(Math.Floor((double) arySrc[index137].lisPoints * ((double) simpleList.Data4[index146] / (double) num120)));
                                      if (index117 > 0)
                                      {
                                        int num130 = index117;
                                        int num131 = index117;
                                        float num132 = 1f;
                                        int num133;
                                        if (arySrc[index137].apUsed + simpleList.Data3[index146] > num83)
                                        {
                                          num132 = (float) (num83 - (arySrc[index137].apUsed + simpleList.Data3[index146] - num83)) / (float) num83;
                                          num131 = (int) Math.Round(Math.Ceiling((double) num130 * (double) num132));
                                          num133 = (int) Math.Round(Math.Floor((double) num130 * (double) num132));
                                        }
                                        else
                                          num133 = num130;
                                        if (num133 > numArray3[arySrc[index137].x, arySrc[index137].y, simpleList.Id[index146]])
                                          num133 = numArray3[arySrc[index137].x, arySrc[index137].y, simpleList.Id[index146]];
                                        if (num131 > numArray3[arySrc[index137].x, arySrc[index137].y, simpleList.Id[index146]])
                                          num131 = numArray3[arySrc[index137].x, arySrc[index137].y, simpleList.Id[index146]];
                                        int num134;
                                        if ((double) num132 > 0.0 & (double) num132 < 1.0)
                                        {
                                          int num135 = Math.Min(index117, (int) Math.Round(Math.Ceiling((double) (num131 * 1) / (double) num132)));
                                          num121 += num135;
                                          num134 = num135;
                                        }
                                        else
                                        {
                                          num121 += num133;
                                          num134 = num133;
                                        }
                                        num128 = num133;
                                        arySrc[tid4].splitJustDone = true;
                                        int[,,] numArray41 = numArray3;
                                        int[,,] numArray42 = numArray41;
                                        index119 = arySrc[index137].x;
                                        int index147 = index119;
                                        int y12 = arySrc[index137].y;
                                        int index148 = y12;
                                        int[] id = simpleList.Id;
                                        int[] numArray43 = id;
                                        int index149 = index146;
                                        int index150 = index149;
                                        int index151 = numArray43[index150];
                                        int num136 = numArray41[index119, y12, id[index149]] - num133;
                                        numArray42[index147, index148, index151] = num136;
                                        if (0 > numArray3[arySrc[index137].x, arySrc[index137].y, simpleList.Id[index146]])
                                          numArray3[arySrc[index137].x, arySrc[index137].y, simpleList.Id[index146]] = 0;
                                        if (index117 > num134)
                                        {
                                          index117 = num134;
                                          break;
                                        }
                                        break;
                                      }
                                      break;
                                  }
                                  if (index143 == 1 & num122 <= 1 & num126 > 0)
                                    num126 = 0;
                                  else if (index143 == 0 & num124 <= 1 & num126 > 0)
                                    num126 = 0;
                                  else if (index143 == 0 & num126 > 0)
                                    index137 = index137;
                                  if (flag12)
                                  {
                                    flag12 = false;
                                    num126 = 100;
                                  }
                                  arySrc[tid4].lisPoints = index117;
                                  arySrc[tid4].x = arySrc[index137].x;
                                  arySrc[tid4].y = arySrc[index137].y;
                                  arySrc[tid4].apUsed = arySrc[index137].apUsed;
                                  arySrc[tid4].reFocusCount = arySrc[index137].reFocusCount;
                                  arySrc[tid4].branchCount = arySrc[index137].branchCount + num126;
                                  arySrc[tid4].extensionAllowed = arySrc[index137].extensionAllowed;
                                  arySrc[tid4].extensionUsed = arySrc[index137].extensionUsed;
                                  arySrc[tid4].active = true;
                                  arySrc[tid4].isPull = index143 == 1;
                                  arySrc[tid4].awaitingSplit = false;
                                  arySrc[tid4].direction = simpleList.Id[index146];
                                  arySrc[tid4].originRunner = new SimpleList();
                                  arySrc[tid4].originRunner.AddWeightBlind(ref arySrc[index137].originRunner);
                                  arySrc[tid4].originRunner.AddBlind(tid4, 1);
                                  if (arySrc[tid4].branchCount > 500 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                                  {
                                    int num137 = (int) Math.Round(Math.Ceiling((double) (arySrc[tid4].branchCount - 500) / 100.0));
                                    int num138 = num137 * num137 * 10;
                                    if (num138 > 999)
                                      num138 = 999;
                                    int num139 = arySrc[tid4].extensionAllowed - arySrc[tid4].extensionUsed;
                                    if (num139 >= num138)
                                    {
                                      LisRunner[] lisRunnerArray7 = arySrc;
                                      LisRunner[] lisRunnerArray8 = lisRunnerArray7;
                                      index119 = tid4;
                                      int index152 = index119;
                                      lisRunnerArray8[index152].extensionUsed = lisRunnerArray7[index119].extensionUsed + num138;
                                    }
                                    else
                                    {
                                      num138 -= num139;
                                      arySrc[tid4].extensionUsed = arySrc[tid4].extensionAllowed;
                                      LisRunner[] lisRunnerArray9 = arySrc;
                                      LisRunner[] lisRunnerArray10 = lisRunnerArray9;
                                      index119 = tid4;
                                      int index153 = index119;
                                      lisRunnerArray10[index153].apUsed = lisRunnerArray9[index119].apUsed + num138;
                                    }
                                    if (index146 == 0 && index1 > -1 & num124 > 1 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                                    {
                                      s4 = Math.Round((double) Math.Max(0, arySrc[tid4].branchCount - 100) / 100.0, 2).ToString() + "th branching causes +" + num138.ToString() + " AP cost.";
                                      this.game.Data.StringListObj[index1].AddRowWithData(arySrc[tid4].x.ToString(), arySrc[tid4].y.ToString(), "3", "6", s4, x.ToString(), y10.ToString(), index116.ToString());
                                    }
                                  }
                                  if ((0 | (index143 == 1 ? 1 : 0)) != 0 && index1 > -1 & num124 > 1 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI && arySrc[tid4].lisPoints > 0)
                                  {
                                    index117 = num128;
                                    s4 = "Pull (" + num129.ToString() + ") Prioritized " + index117.ToString() + " " + str13 + " points" + " to ";
                                    if (simpleList.Id[index146] == 0)
                                      s4 += "North.";
                                    if (simpleList.Id[index146] == 1)
                                      s4 += "North-East.";
                                    if (simpleList.Id[index146] == 2)
                                      s4 += "South-East.";
                                    if (simpleList.Id[index146] == 3)
                                      s4 += "South.";
                                    if (simpleList.Id[index146] == 4)
                                      s4 += "South-West.";
                                    if (simpleList.Id[index146] == 5)
                                      s4 += "North-West.";
                                    this.game.Data.StringListObj[index1].AddRowWithData(arySrc[index137].x.ToString(), arySrc[index137].y.ToString(), "3", simpleList.Id[index146].ToString(), s4, "-1", "-1", "0");
                                  }
                                  index117 = index117;
                                }
                              }
                            }
                          }
                        }
                        index117 = 9999999;
                        int num140 = num87;
                        int num141 = tid4;
                        for (int index154 = num140; index154 <= num141; ++index154)
                        {
                          if ((arySrc[index154].active | arySrc[index154].awaitingSplit) & index117 > index154)
                            index117 = index154;
                        }
                        num87 = index117;
                      }
                    }
                  }
                }
              }
            }
          }
        }
        ++num80;
      }
      while (num80 <= 1);
      int mapWidth20 = this.game.Data.MapObj[0].MapWidth;
      for (int index155 = 0; index155 <= mapWidth20; ++index155)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (index49 = 0; index49 <= mapHeight; ++index49)
        {
          if (this.game.Data.MapObj[0].HexObj[index155, index49].LISpoints[6] > 0)
          {
            int num142 = 0;
            do
            {
              coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(index155, index49, 0, num142 + 1);
              if (coordinate1.onmap && this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[6] > 0)
              {
                int index156 = this.game.HandyFunctionsObj.HexFacing(index155, index49, 0, coordinate1.x, coordinate1.y, 0) - 1;
                int index157 = index156 + 3;
                if (index157 > 5)
                  index157 -= 6;
                if (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LISpoints[index157] == 0 & this.game.Data.MapObj[0].HexObj[index155, index49].LISpoints[index156] == 0)
                {
                  int num143 = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[index157] > -1 & this.game.Data.MapObj[0].HexObj[index155, index49].RoadType[index156] > -1 ? 1 : 0;
                }
              }
              ++num142;
            }
            while (num142 <= 5);
          }
        }
      }
      if (this.game.EventRelatedObj.Helper_AirEnabled() && !isPreview & !isCalibrationCall)
        this.LIS_AddAirBridges(isPreview);
      if (!isCalibrationCall)
      {
        int mapWidth21 = this.game.Data.MapObj[0].MapWidth;
        for (int index158 = 0; index158 <= mapWidth21; ++index158)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (index49 = 0; index49 <= mapHeight; ++index49)
          {
            int index159 = 0;
            do
            {
              this.game.Data.MapObj[0].HexObj[index158, index49].LIStotalHistory[index159] = this.game.Data.MapObj[0].HexObj[index158, index49].LISpoints[index159];
              ++index159;
            }
            while (index159 <= 8);
          }
        }
      }
      if (!isCalibrationCall && isPreview)
      {
        int mapWidth22 = this.game.Data.MapObj[0].MapWidth;
        for (int index160 = 0; index160 <= mapWidth22; ++index160)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (index49 = 0; index49 <= mapHeight; ++index49)
          {
            int index161 = 0;
            do
            {
              if (onlyForAssetID > 0)
              {
                if (index160 == 6 & index49 == 39 & index161 == 5)
                  index161 = index161;
                if (num5 > 0)
                {
                  this.game.Data.MapObj[0].HexObj[index160, index49].tempPreviewAssetLIS[index161] = this.game.Data.MapObj[0].HexObj[index160, index49].tempPreviewLIS[index161] - this.game.Data.MapObj[0].HexObj[index160, index49].LISpoints[index161];
                  if (this.game.Data.MapObj[0].HexObj[index160, index49].tempPreviewAssetLIS[index161] < 0)
                    this.game.Data.MapObj[0].HexObj[index160, index49].tempPreviewAssetLIS[index161] = 0;
                }
                else
                  this.game.Data.MapObj[0].HexObj[index160, index49].tempPreviewAssetLIS[index161] = this.game.Data.MapObj[0].HexObj[index160, index49].LISpoints[index161];
              }
              else
              {
                this.game.Data.MapObj[0].HexObj[index160, index49].tempPreviewLIS[index161] = this.game.Data.MapObj[0].HexObj[index160, index49].LISpoints[index161];
                this.game.Data.MapObj[0].HexObj[index160, index49].tempPreviewPull[index161] = this.game.Data.MapObj[0].HexObj[index160, index49].LISpull[index161];
              }
              this.game.Data.MapObj[0].HexObj[index160, index49].LIShistory[index161] = this.cacheLIShistory[index160, index49, index161];
              this.game.Data.MapObj[0].HexObj[index160, index49].LISpoints[index161] = this.cacheLISpoints[index160, index49, index161];
              this.game.Data.MapObj[0].HexObj[index160, index49].LIStotalHistory[index161] = this.cacheLIStotalHistory[index160, index49, index161];
              this.game.Data.MapObj[0].HexObj[index160, index49].LISorganic[index161] = this.cacheLISorganic[index160, index49, index161];
              this.game.Data.MapObj[0].HexObj[index160, index49].LISorganicPercentage[index161] = this.cacheLISorganicPercentage[index160, index49, index161];
              this.game.Data.MapObj[0].HexObj[index160, index49].LISpull[index161] = this.cacheLISpull[index160, index49, index161];
              ++index161;
            }
            while (index161 <= 8);
          }
        }
        this.tempLISwithoutLogExt = new int[2, 2, 2];
        this.cacheLIShistory = new int[2, 2, 2];
        this.cacheLISpoints = new int[2, 2, 2];
        this.cacheLIStotalHistory = new int[2, 2, 2];
        this.cacheLISorganic = new int[2, 2, 2];
        this.cacheLISorganicPercentage = new int[2, 2, 2];
        this.cacheLISpull = new int[2, 2, 2];
      }
      if (isPreview & !this.game.Data.RegimeObj[this.game.Data.Turn].AI & this.game.Data.InTurn)
        this.game.EventRelatedObj.ExecSuperImposeMessage("", "", 0, 0, "");
      int mapWidth23 = this.game.Data.MapObj[0].MapWidth;
      for (int index162 = 0; index162 <= mapWidth23; ++index162)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (index49 = 0; index49 <= mapHeight; ++index49)
        {
          this.game.EditObj.TempValue[0].Value[index162, index49] = Conversions.ToInteger(objArray1[index162, index49]);
          Coordinate[,] coordinateArray = this.game.EditObj.TempCameFrom[0].Value;
          int index163 = index162;
          int index164 = index49;
          object obj = objArray2[index162, index49];
          Coordinate coordinate12;
          Coordinate coordinate13 = obj != null ? (Coordinate) obj : coordinate12;
          coordinateArray[index163, index164] = coordinate13;
        }
      }
    }

    public void LIS_AddAirBridges(bool preview)
    {
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 534, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 535, 0, 0));
      int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 363, 0, 0));
      if (stringListById1 < 1)
        return;
      int id = this.game.Data.RegimeObj[this.game.Data.Turn].id;
      for (int length = this.game.Data.StringListObj[stringListById2].Length; length >= 0; length += -1)
      {
        int regimeById = this.game.HandyFunctionsObj.GetRegimeByID((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[length, 0])));
        if (regimeById == -1)
          this.game.Data.StringListObj[stringListById2].RemoveRow(length);
        else if (this.game.Data.RegimeObj[regimeById].AI | regimeById == this.game.Data.Turn)
          this.game.Data.StringListObj[stringListById2].RemoveRow(length);
      }
      SimpleList simpleList1 = new SimpleList();
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn)
        {
          int historical = this.game.Data.UnitObj[index].Historical;
          if (historical > -1 && this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(55) > 0)
          {
            int x = this.game.Data.UnitObj[index].X;
            int y = this.game.Data.UnitObj[index].Y;
            int tdata3 = this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(56);
            int tdata4 = this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(57);
            simpleList1.Add(this.game.Data.HistoricalUnitObj[historical].ID, 1, x, y, tdata3, tdata4);
          }
        }
      }
      for (int length = this.game.Data.StringListObj[stringListById1].Length; length >= 0; length += -1)
      {
        if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length, 0])) == id)
        {
          int tdata1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length, 1]));
          int tdata2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length, 2]));
          int tdata3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length, 3]));
          int tdata4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length, 4]));
          int num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length, 9]));
          if (simpleList1.FindNr(-1, tdata1, tdata2, tdata3, tdata4) <= -1)
            num1 = -1;
          if (num1 == -1)
          {
            this.game.Data.StringListObj[stringListById1].RemoveRow(length);
            int unitCounter2 = this.game.Data.UnitCounter;
            for (int index = 0; index <= unitCounter2; ++index)
            {
              if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index].PreDef == -1)
              {
                int historical = this.game.Data.UnitObj[index].Historical;
                if (this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(55) > 0)
                {
                  int x = this.game.Data.UnitObj[index].X;
                  int y = this.game.Data.UnitObj[index].Y;
                  int num2 = this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(56);
                  int num3 = this.game.Data.HistoricalUnitObj[historical].GiveHisVarValue(57);
                  if (x == tdata1 & y == tdata2 & num2 == tdata3 & num3 == tdata4)
                  {
                    this.game.Data.HistoricalUnitObj[historical].SetHisVarValue(55, 0);
                    this.game.Data.HistoricalUnitObj[historical].SetHisVarValue(56, 0);
                    this.game.Data.HistoricalUnitObj[historical].SetHisVarValue(57, 0);
                    this.game.Data.HistoricalUnitObj[historical].SetHisVarValue(58, 0);
                    this.game.Data.HistoricalUnitObj[historical].SetHisVarValue(59, 0);
                  }
                }
              }
            }
          }
        }
        else if (this.game.HandyFunctionsObj.GetRegimeByID((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length, 0]))) == -1)
          this.game.Data.StringListObj[stringListById1].RemoveRow(length);
      }
      for (int length = this.game.Data.StringListObj[stringListById1].Length; length >= 0; length += -1)
      {
        if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length, 0])) == id)
        {
          int x1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length, 1]));
          int y1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length, 2]));
          int x2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length, 3]));
          int y2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length, 4]));
          int num4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length, 8]));
          int num5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length, 9]));
          this.game.Data.StringListObj[stringListById2].AddRowWithData(id.ToString(), num4.ToString(), "Attempting to execute Air Bridge");
          SimpleList simpleList2 = new SimpleList();
          int counter1 = simpleList1.Counter;
          for (int index = 0; index <= counter1; ++index)
          {
            if (simpleList1.Data1[index] == x1 & simpleList1.Data2[index] == y1 & simpleList1.Data3[index] == x2 & simpleList1.Data4[index] == y2)
            {
              int historicalUnitById = this.game.HandyFunctionsObj.GetHistoricalUnitByID(simpleList1.Id[index]);
              if (historicalUnitById > -1)
              {
                int unitByHistorical = this.game.HandyFunctionsObj.GetUnitByHistorical(historicalUnitById);
                int lowestAirRdn = this.game.HandyFunctionsObj.GetLowestAirRdn(unitByHistorical);
                int lowestAirApRule = this.game.HandyFunctionsObj.GetLowestAirApRule(unitByHistorical);
                int tdata1 = this.game.HandyFunctionsObj.GetLowestAirAp(unitByHistorical);
                int minimumAirfieldLevel = this.game.HandyFunctionsObj.SE1_GetUnitMinimumAirfieldLevel(unitByHistorical);
                int num6 = 0;
                int num7 = 0;
                if (this.game.Data.MapObj[0].HexObj[x1, y1].Location > -1)
                  num6 = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x1, y1].Location].tempAirfieldLevel;
                if (this.game.Data.MapObj[0].HexObj[x2, y2].Location > -1)
                  num7 = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x2, y2].Location].tempAirfieldLevel;
                if (tdata1 > lowestAirRdn)
                  tdata1 = lowestAirRdn;
                int num8 = (int) Math.Round(Math.Floor((double) tdata1 / (double) lowestAirApRule));
                int num9 = this.game.HandyFunctionsObj.Distance(x1, y1, 0, x2, y2, 0);
                if (minimumAirfieldLevel > num6)
                  this.game.Data.StringListObj[stringListById2].AddRowWithData(id.ToString(), num4.ToString(), this.game.Data.UnitObj[unitByHistorical].Name + " source Hex Airbase Level was not high enough.", "Current Level is " + num6.ToString() + " instead of " + minimumAirfieldLevel.ToString() + ".");
                else if (minimumAirfieldLevel > num7)
                  this.game.Data.StringListObj[stringListById2].AddRowWithData(id.ToString(), num4.ToString(), this.game.Data.UnitObj[unitByHistorical].Name + " target Hex Airbase Level was not high enough.", "Current Level is " + num7.ToString() + " instead of " + minimumAirfieldLevel.ToString() + ".");
                else if (num8 >= num9)
                {
                  tdata1 = this.game.HandyFunctionsObj.GetLowestAirAp(unitByHistorical);
                  this.game.Data.StringListObj[stringListById2].AddRowWithData(id.ToString(), num4.ToString(), this.game.Data.UnitObj[unitByHistorical].Name + " is ready (ap=" + tdata1.ToString() + ",rdn=" + lowestAirRdn.ToString() + ") and joins mission.");
                  simpleList2.Add(this.game.Data.HistoricalUnitObj[historicalUnitById].ID, 1, tdata1, unitByHistorical);
                }
                else
                {
                  tdata1 = this.game.HandyFunctionsObj.GetLowestAirAp(unitByHistorical);
                  if (lowestAirRdn < tdata1)
                    this.game.Data.StringListObj[stringListById2].AddRowWithData(id.ToString(), num4.ToString(), this.game.Data.UnitObj[unitByHistorical].Name + " did not have enough Readiness (" + lowestAirRdn.ToString() + ") to join mission.", "Current maximum range is " + num8.ToString() + " instead of " + num9.ToString() + ".");
                  else
                    this.game.Data.StringListObj[stringListById2].AddRowWithData(id.ToString(), num4.ToString(), this.game.Data.UnitObj[unitByHistorical].Name + " did not have enough Action Points (" + tdata1.ToString() + ") to join mission.", "Current maximum range is " + num8.ToString() + " instead of " + num9.ToString() + ".");
                }
              }
            }
          }
          if (simpleList2.Counter > -1)
          {
            this.game.Data.StringListObj[stringListById2].AddRowWithData(id.ToString(), num4.ToString(), "Executing Air Bridge");
            this.game.TempCombat = new CombatClass(this.game);
            Coordinate Target = new Coordinate();
            Target.x = x2;
            Target.y = y2;
            this.game.EditObj.TempUnitList = new UnitList();
            int num10 = 0;
            int counter2 = simpleList2.Counter;
            for (int index = 0; index <= counter2; ++index)
            {
              int historicalUnitById = this.game.HandyFunctionsObj.GetHistoricalUnitByID(simpleList2.Id[index]);
              if (historicalUnitById > -1)
                this.game.EditObj.TempUnitList.add(this.game.HandyFunctionsObj.GetUnitByHistorical(historicalUnitById));
            }
            this.game.TempCombat.Init(Target, 1, this.game.EditObj.TempUnitList, 55, true);
            this.game.TempCombat.DoBattle();
            int se1carryPointsDelivered = this.game.TempCombat.se1carryPointsDelivered;
            int se1damagePercentage = this.game.TempCombat.se1damagePercentage;
            SimpleList simpleList3 = new SimpleList();
            SimpleList simpleList4 = new SimpleList();
            SimpleList simpleList5 = new SimpleList();
            SimpleList simpleList6 = new SimpleList();
            int num11 = 0;
            int num12 = 0;
            int num13 = 0;
            int num14 = 0;
            int counter3 = simpleList2.Counter;
            for (int index1 = 0; index1 <= counter3; ++index1)
            {
              int icounter = this.game.TempCombat.ICounter;
              for (int index2 = 0; index2 <= icounter; ++index2)
              {
                if (this.game.TempCombat.IList[index2].IUnr == simpleList2.Data2[index1])
                {
                  num10 += this.game.Data.SFTypeObj[this.game.TempCombat.IList[index2].ISFType].CarryCap;
                  if (this.game.TempCombat.IList[index2].IKilled > 0)
                  {
                    num11 += this.game.Data.SFTypeObj[this.game.TempCombat.IList[index2].ISFType].Ratio;
                    simpleList4.AddWeight(this.game.TempCombat.IList[index2].ISFType, this.game.Data.SFTypeObj[this.game.TempCombat.IList[index2].ISFType].Ratio);
                  }
                  else if (this.game.TempCombat.IList[index2].IKilled == 0 & (this.game.TempCombat.IList[index2].IRetreatMode == 2 | this.game.TempCombat.IList[index2].IRetreatMode == 0))
                  {
                    num12 += this.game.Data.SFTypeObj[this.game.TempCombat.IList[index2].ISFType].Ratio;
                    simpleList6.AddWeight(this.game.TempCombat.IList[index2].ISFType, this.game.Data.SFTypeObj[this.game.TempCombat.IList[index2].ISFType].Ratio);
                  }
                  else
                  {
                    num13 += this.game.Data.SFTypeObj[this.game.TempCombat.IList[index2].ISFType].Ratio;
                    simpleList5.AddWeight(this.game.TempCombat.IList[index2].ISFType, this.game.Data.SFTypeObj[this.game.TempCombat.IList[index2].ISFType].Ratio);
                  }
                }
              }
            }
            int icounter1 = this.game.TempCombat.ICounter;
            for (int index = 0; index <= icounter1; ++index)
            {
              if (this.game.TempCombat.IList[index].IAttacker == 0 && this.game.Data.SFTypeObj[this.game.TempCombat.IList[index].ISFType].Theater == 2)
              {
                num14 += this.game.Data.SFTypeObj[this.game.TempCombat.IList[index].ISFType].Ratio;
                simpleList3.AddWeight(this.game.TempCombat.IList[index].ISFType, this.game.Data.SFTypeObj[this.game.TempCombat.IList[index].ISFType].Ratio);
              }
            }
            if (num14 > 0)
            {
              string s2 = "Our mission was intercepted by " + num14.ToString() + " enemy aircraft.";
              string s3 = "";
              int counter4 = simpleList3.Counter;
              for (int index = 0; index <= counter4; ++index)
              {
                if (simpleList3.Weight[index] > 0)
                {
                  if (s3.Length > 0)
                    s3 += "\r\n";
                  s3 = s3 + simpleList3.Weight[index].ToString() + "x " + this.game.Data.SFTypeObj[simpleList3.Id[index]].Name + " were intercepting.";
                }
              }
              this.game.Data.StringListObj[stringListById2].AddRowWithData(id.ToString(), num4.ToString(), s2, s3);
            }
            string s2_1;
            if (num12 > 0)
              s2_1 = num12.ToString() + " aircraft established Air Bridge. " + num13.ToString() + " air retreated. " + num11.ToString() + " air lost.";
            else
              s2_1 = "Failure to establish Air Bridge. " + num13.ToString() + " air retreated. " + num11.ToString() + " air lost.";
            string s3_1 = "";
            int counter5 = simpleList4.Counter;
            for (int index = 0; index <= counter5; ++index)
            {
              if (simpleList4.Weight[index] > 0)
              {
                if (s3_1.Length > 0)
                  s3_1 += "\r\n";
                s3_1 = s3_1 + simpleList4.Weight[index].ToString() + "x " + this.game.Data.SFTypeObj[simpleList4.Id[index]].Name + " were killed in action.";
              }
            }
            this.game.Data.StringListObj[stringListById2].AddRowWithData(id.ToString(), num4.ToString(), s2_1, s3_1);
            this.game.TempCombat.EndBattle();
            int counter6 = simpleList2.Counter;
            for (int index = 0; index <= counter6; ++index)
            {
              int historicalUnitById = this.game.HandyFunctionsObj.GetHistoricalUnitByID(simpleList2.Id[index]);
              if (historicalUnitById > -1 && this.game.HandyFunctionsObj.GetUnitByHistorical(historicalUnitById) > -1)
                this.game.EventRelatedObj.Helper_MakeListForUnitRequests("SE_Data", this.game.Data.HistoricalUnitObj[historicalUnitById].ID, false);
            }
            int num15 = 0;
            int num16 = 0;
            int num17;
            if ((int) Math.Round(Conversion.Val(this.game.Data.Designer)) >= 82)
            {
              int counter7 = simpleList2.Counter;
              for (int index3 = 0; index3 <= counter7; ++index3)
              {
                int historicalUnitById = this.game.HandyFunctionsObj.GetHistoricalUnitByID(simpleList2.Id[index3]);
                if (historicalUnitById > -1)
                {
                  int unitByHistorical = this.game.HandyFunctionsObj.GetUnitByHistorical(historicalUnitById);
                  if (unitByHistorical > -1)
                  {
                    int sfCount = this.game.Data.UnitObj[unitByHistorical].SFCount;
                    for (int index4 = 0; index4 <= sfCount; ++index4)
                    {
                      int sf = this.game.Data.UnitObj[unitByHistorical].SFList[index4];
                      int idValue = this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].SFTypeVar[81];
                      if (idValue > 0)
                      {
                        int num18 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData2(0, idValue, 1, 503, 2)));
                        num16 += this.game.Data.SFObj[sf].Qty;
                        num15 += this.game.Data.SFObj[sf].Qty * num18;
                      }
                    }
                  }
                }
              }
              num17 = (int) Math.Round(Math.Ceiling(Math.Sqrt(Math.Ceiling((double) (int) Math.Round(Math.Floor((double) num15 / (double) num16)) / 1000.0))));
              if (num17 < 1)
                num17 = 1;
            }
            else
            {
              int counter8 = simpleList2.Counter;
              for (int index5 = 0; index5 <= counter8; ++index5)
              {
                int historicalUnitById = this.game.HandyFunctionsObj.GetHistoricalUnitByID(simpleList2.Id[index5]);
                if (historicalUnitById > -1)
                {
                  int unitByHistorical = this.game.HandyFunctionsObj.GetUnitByHistorical(historicalUnitById);
                  if (unitByHistorical > -1)
                  {
                    int sfCount = this.game.Data.UnitObj[unitByHistorical].SFCount;
                    for (int index6 = 0; index6 <= sfCount; ++index6)
                    {
                      int sf = this.game.Data.UnitObj[unitByHistorical].SFList[index6];
                      int num19 = this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].SFTypeVar[22];
                      num16 += this.game.Data.SFObj[sf].Qty;
                      num15 += this.game.Data.SFObj[sf].Qty * num19;
                    }
                  }
                }
              }
              num17 = (int) Math.Round(Math.Floor((double) num15 / (double) num16));
              if (num17 < 1)
                num17 = 1;
            }
            this.game.Data.StringListObj[stringListById1].Data[length, 5] = se1carryPointsDelivered.ToString();
            this.game.Data.StringListObj[stringListById1].Data[length, 6] = se1carryPointsDelivered.ToString();
            this.game.Data.StringListObj[stringListById1].Data[length, 7] = se1damagePercentage.ToString();
            this.game.Data.StringListObj[stringListById1].Data[length, 9] = "1";
            this.game.Data.StringListObj[stringListById1].Data[length, 10] = num17.ToString();
            this.game.Data.StringListObj[stringListById1].Data[length, 11] = num10.ToString();
            int[] liSpoints1 = this.game.Data.MapObj[0].HexObj[x1, y1].LISpoints;
            int[] numArray1 = liSpoints1;
            int index7 = 6;
            int index8 = index7;
            int num20 = liSpoints1[index7] + se1carryPointsDelivered;
            numArray1[index8] = num20;
            int[] liSpoints2 = this.game.Data.MapObj[0].HexObj[x2, y2].LISpoints;
            int[] numArray2 = liSpoints2;
            int index9 = 6;
            int index10 = index9;
            int num21 = liSpoints2[index9] + se1carryPointsDelivered;
            numArray2[index10] = num21;
            if (se1carryPointsDelivered > 0)
            {
              string s2_2 = "Air Bridge established with " + se1carryPointsDelivered.ToString() + " Air Points.";
              string s3_2 = "Maximum Size for Air Bridge usage is " + num17.ToString() + ".\r\nDamage that will be taken by usage is " + se1damagePercentage.ToString() + "%.";
              this.game.Data.StringListObj[stringListById2].AddRowWithData(id.ToString(), num4.ToString(), s2_2, s3_2);
            }
          }
        }
      }
    }

    public void LIS_SetNetwork_BACKUP(bool isCalibrationCall)
    {
      int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[405]));
      this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[404]));
      if (isCalibrationCall)
      {
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index1 = 0; index1 <= mapWidth; ++index1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index2 = 0; index2 <= mapHeight; ++index2)
          {
            int index3 = 0;
            do
            {
              this.game.Data.MapObj[0].HexObj[index1, index2].tempOldLISpoints[index3] = this.game.Data.MapObj[0].HexObj[index1, index2].LISpoints[index3];
              this.game.Data.MapObj[0].HexObj[index1, index2].LISpoints[index3] = 0;
              ++index3;
            }
            while (index3 <= 8);
          }
        }
      }
      else
      {
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index4 = 0; index4 <= mapWidth; ++index4)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index5 = 0; index5 <= mapHeight; ++index5)
          {
            int index6 = 0;
            do
            {
              this.game.Data.MapObj[0].HexObj[index4, index5].tempOldLISpoints[index6] = 0;
              this.game.Data.MapObj[0].HexObj[index4, index5].LIShistory[index6] = 0;
              this.game.Data.MapObj[0].HexObj[index4, index5].LISpoints[index6] = 0;
              this.game.Data.MapObj[0].HexObj[index4, index5].LIStotalHistory[index6] = 0;
              this.game.Data.MapObj[0].HexObj[index4, index5].LISorganic[index6] = 0;
              this.game.Data.MapObj[0].HexObj[index4, index5].LISorganicPercentage[index6] = 0;
              ++index6;
            }
            while (index6 <= 8);
          }
        }
      }
      int locCounter = this.game.Data.LocCounter;
      for (int index7 = 0; index7 <= locCounter; ++index7)
      {
        int x1 = this.game.Data.LocObj[index7].X;
        int y1 = this.game.Data.LocObj[index7].Y;
        bool flag = false;
        if (this.game.Data.MapObj[0].HexObj[x1, y1].Regime == this.game.Data.Turn && !Information.IsNothing((object) this.game.Data.LocObj[index7].tempLIS) && this.game.Data.LocObj[index7].tempLIS.Counter > -1)
          flag = true;
        if (flag)
        {
          int num1 = 100;
          if (isCalibrationCall)
          {
            int num2 = 0;
            int length = this.game.Data.StringListObj[stringListById].Length;
            for (int index8 = 0; index8 <= length; ++index8)
            {
              int tid = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index8, 0]));
              int num3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index8, 4]));
              int num4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index8, 2]));
              int nr1 = this.game.Data.LocObj[index7].tempLIS.FindNr(tid);
              int num5 = 0;
              if (nr1 > -1)
                num5 = this.game.Data.LocObj[index7].tempLIS.Weight[nr1];
              if (num5 > 0)
              {
                int nr2 = this.game.Data.LocObj[index7].tempLISfreeAP.FindNr(tid);
                int num6 = 0;
                if (nr2 > -1)
                  num6 = this.game.Data.LocObj[index7].tempLISfreeAP.Weight[nr2];
                if (num6 > 0)
                  num2 += num5;
              }
            }
            if (num2 > 0)
              num1 = (int) Math.Round(Math.Floor((double) (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index7].X, this.game.Data.LocObj[index7].Y].tempOldLISpoints[6] * 100) / (double) num2));
          }
          int length1 = this.game.Data.StringListObj[stringListById].Length;
          for (int index9 = 0; index9 <= length1; ++index9)
          {
            int tid = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index9, 0]));
            int movetype = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index9, 4]));
            int theater = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[index9, 2]));
            int nr3 = this.game.Data.LocObj[index7].tempLIS.FindNr(tid);
            int num7 = 0;
            if (nr3 > -1)
              num7 = (int) Math.Round(Math.Floor((double) (this.game.Data.LocObj[index7].tempLIS.Weight[nr3] * num1) / 100.0));
            if (num7 > 0)
            {
              int nr4 = this.game.Data.LocObj[index7].tempLISfreeAP.FindNr(tid);
              int num8 = 0;
              if (nr4 > -1)
                num8 = this.game.Data.LocObj[index7].tempLISfreeAP.Weight[nr4];
              if (num8 > 0)
              {
                int[] liSpoints1 = this.game.Data.MapObj[0].HexObj[x1, y1].LISpoints;
                int[] numArray1 = liSpoints1;
                int index10 = 6;
                int index11 = index10;
                int num9 = liSpoints1[index10] + num7;
                numArray1[index11] = num9;
                CoordList coordList1 = this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype, theater, num8 * 2, x1, y1, 0, roadsOnly: true, alwaysUseLogisticalBonus: true);
                int counter1 = coordList1.counter;
                for (int index12 = 0; index12 <= counter1; ++index12)
                {
                  if (coordList1.coord[index12].onmap)
                  {
                    int x2 = coordList1.coord[index12].x;
                    int y2 = coordList1.coord[index12].y;
                    if (this.game.EditObj.TempCameFrom[0].Value[x2, y2].onmap & this.game.EditObj.TempValue[0].Value[x2, y2] < 9999)
                    {
                      int x3 = this.game.EditObj.TempCameFrom[0].Value[x2, y2].x;
                      int y3 = this.game.EditObj.TempCameFrom[0].Value[x2, y2].y;
                      int num10 = this.game.HandyFunctionsObj.HexFacing(x3, y3, 0, x2, y2, 0) - 1;
                      int num11 = num10 + 3;
                      if (num11 > 5)
                        num11 -= 6;
                      int num12 = this.game.EditObj.TempValue[0].Value[x2, y2];
                      int num13 = num12 <= num8 ? num7 : (int) Math.Round((double) num7 * ((double) (num8 - (num12 - num8)) / (double) num8));
                      if (isCalibrationCall)
                      {
                        int pointsOnTrajectory = this.LIS_GetLowestPotentialPointsOnTrajectory(x2, y2);
                        if (num13 > pointsOnTrajectory)
                          num13 = pointsOnTrajectory;
                      }
                      if (((!isCalibrationCall ? 1 : 0) & 0) != 0)
                      {
                        int num14 = 0;
                        int num15 = 0;
                        if (this.game.Data.Turn == 2)
                          num14 = num14;
                        Coordinate coordinate1;
                        coordinate1.onmap = true;
                        coordinate1.x = x3;
                        coordinate1.y = y3;
                        while (coordinate1.onmap)
                        {
                          int num16 = 0;
                          int tfacing1 = 1;
                          do
                          {
                            if (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[tfacing1 - 1] > -1)
                            {
                              Coordinate coordinate2 = this.game.HandyFunctionsObj.HexNeighbour(coordinate1.x, coordinate1.y, 0, tfacing1);
                              if (coordinate2.onmap && this.game.EditObj.TempValue[0].Value[coordinate2.x, coordinate2.y] < 9999)
                              {
                                int index13 = tfacing1 - 1 + 3;
                                if (index13 > 5)
                                  index13 -= 6;
                                if (this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].RoadType[index13] > -1)
                                  ++num16;
                              }
                            }
                            ++tfacing1;
                          }
                          while (tfacing1 <= 6);
                          if (((!isCalibrationCall ? 1 : 0) & 0) != 0)
                          {
                            int num17 = 0;
                            Coordinate coordinate3 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                            CoordList coordList2 = new CoordList();
                            if (coordinate3.onmap)
                            {
                              int num18 = 1;
                              Coordinate coordinate4;
                              do
                              {
                                coordinate4 = this.game.HandyFunctionsObj.HexNeighbour(coordinate1.x, coordinate1.y, 0, num18);
                                if (coordinate4.onmap && !(coordinate4.x == coordinate1.x & coordinate4.y == coordinate1.y) & !(coordinate4.x == coordinate3.x & coordinate4.y == coordinate3.y) && this.game.EditObj.TempCameFrom[0].Value[coordinate4.x, coordinate4.y].onmap & !(this.game.EditObj.TempCameFrom[0].Value[coordinate4.x, coordinate4.y].x == coordinate1.x & this.game.EditObj.TempCameFrom[0].Value[coordinate4.x, coordinate4.y].y == coordinate1.y))
                                {
                                  int num19 = num18 + 3;
                                  if (num19 > 6)
                                    num19 -= 6;
                                  int dat2 = 0;
                                  if (this.game.Data.MapObj[0].HexObj[coordinate4.x, coordinate4.y].RoadType[num19 - 1] > -1 && this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RoadType[num18 - 1] > -1)
                                  {
                                    ++num17;
                                    int tfacing2 = 1;
                                    do
                                    {
                                      Coordinate coordinate5 = this.game.HandyFunctionsObj.HexNeighbour(coordinate4.x, coordinate4.y, 0, tfacing2);
                                      if (coordinate5.onmap)
                                      {
                                        int num20 = tfacing2 + 3;
                                        if (num20 > 6)
                                          num20 -= 6;
                                        if (this.game.Data.MapObj[0].HexObj[coordinate5.x, coordinate5.y].RoadType[num20 - 1] > -1 && this.game.Data.MapObj[0].HexObj[coordinate4.x, coordinate4.y].RoadType[tfacing2 - 1] > -1)
                                          ++dat2;
                                      }
                                      ++tfacing2;
                                    }
                                    while (tfacing2 <= 6);
                                    coordList2.AddCoord(coordinate4.x, coordinate4.y, 0, num18, dat2);
                                  }
                                }
                                ++num18;
                              }
                              while (num18 <= 6);
                              if (num17 > 0)
                              {
                                int counter2 = coordList2.counter;
                                for (int index14 = 0; index14 <= counter2; ++index14)
                                {
                                  coordinate4.x = coordList2.coord[index14].x;
                                  coordinate4.y = coordList2.coord[index14].y;
                                  coordinate4.onmap = true;
                                  int data1 = coordList2.coord[index14].data1;
                                  int data2 = coordList2.coord[index14].data2;
                                  int num21 = data1 + 3;
                                  int num22;
                                  int liSpoint;
                                  if (num21 > 6)
                                  {
                                    int num23 = num21 - 6;
                                    num22 = this.game.EditObj.TempValue[0].Value[coordinate4.x, coordinate4.y];
                                    liSpoint = this.game.Data.MapObj[0].HexObj[coordinate4.x, coordinate4.y].LISpoints[6];
                                  }
                                  Coordinate coordinate6 = this.game.HandyFunctionsObj.MoveApCostPreview2(coordinate4.x, coordinate4.y, this.game.Data.Turn, movetype, theater, coordinate4.x, coordinate4.y, 0, coordinate1.x, coordinate1.y, 0, roadsOnly: true, alwaysUseLogisticalBonus: true);
                                  if (num22 + coordinate6.x <= num8 * 2)
                                  {
                                    int num24 = (int) Math.Round(Math.Floor((num22 + coordinate6.x <= num8 ? (double) liSpoint : (double) (int) Math.Round((double) liSpoint * ((double) (num8 - (num22 + coordinate6.x - num8)) / (double) num8))) / (double) (coordList2.counter + 1)));
                                    if (num24 > 0)
                                      num15 += num24;
                                  }
                                }
                              }
                            }
                          }
                          coordinate1 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                          if (coordinate1.onmap)
                          {
                            if (num16 > 2)
                              num14 += num16 - 2;
                          }
                          else if (num16 > 1)
                            num14 += num16 - 1;
                        }
                        if (num14 > 0)
                        {
                          int num25 = num14;
                          for (int index15 = 1; index15 <= num25; ++index15)
                            num13 = (int) Math.Round(Math.Floor((double) num13 / 2.0));
                        }
                        num13 += num15;
                      }
                      int[] liSpoints2 = this.game.Data.MapObj[0].HexObj[x3, y3].LISpoints;
                      int[] numArray2 = liSpoints2;
                      int index16 = num10;
                      int index17 = index16;
                      int num26 = liSpoints2[index16] + num13;
                      numArray2[index17] = num26;
                      int[] liSpoints3 = this.game.Data.MapObj[0].HexObj[x2, y2].LISpoints;
                      int[] numArray3 = liSpoints3;
                      int index18 = num11;
                      int index19 = index18;
                      int num27 = liSpoints3[index18] + num13;
                      numArray3[index19] = num27;
                      int[] liSpoints4 = this.game.Data.MapObj[0].HexObj[x2, y2].LISpoints;
                      int[] numArray4 = liSpoints4;
                      int index20 = 6;
                      int index21 = index20;
                      int num28 = liSpoints4[index20] + num13;
                      numArray4[index21] = num28;
                    }
                  }
                }
              }
            }
          }
        }
      }
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index22 = 0; index22 <= mapWidth1; ++index22)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index23 = 0; index23 <= mapHeight; ++index23)
        {
          if (this.game.Data.MapObj[0].HexObj[index22, index23].LISpoints[6] > 0)
          {
            int num29 = 0;
            do
            {
              Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(index22, index23, 0, num29 + 1);
              if (coordinate.onmap && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LISpoints[6] > 0)
              {
                int index24 = this.game.HandyFunctionsObj.HexFacing(index22, index23, 0, coordinate.x, coordinate.y, 0) - 1;
                int index25 = index24 + 3;
                if (index25 > 5)
                  index25 -= 6;
                if (this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LISpoints[index25] == 0 & this.game.Data.MapObj[0].HexObj[index22, index23].LISpoints[index24] == 0 && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RoadType[index25] > -1 & this.game.Data.MapObj[0].HexObj[index22, index23].RoadType[index24] > -1)
                {
                  int num30 = Math.Min(this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LISpoints[6], this.game.Data.MapObj[0].HexObj[index22, index23].LISpoints[6]);
                  this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LISpoints[index25] = num30;
                  this.game.Data.MapObj[0].HexObj[index22, index23].LISpoints[index24] = num30;
                }
              }
              ++num29;
            }
            while (num29 <= 5);
          }
        }
      }
      if (isCalibrationCall)
        return;
      int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
      for (int index26 = 0; index26 <= mapWidth2; ++index26)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index27 = 0; index27 <= mapHeight; ++index27)
        {
          int index28 = 0;
          do
          {
            this.game.Data.MapObj[0].HexObj[index26, index27].LIStotalHistory[index28] = this.game.Data.MapObj[0].HexObj[index26, index27].LISpoints[index28];
            ++index28;
          }
          while (index28 <= 8);
        }
      }
    }

    public void LocationProduction()
    {
      SimpleList simpleList1 = new SimpleList();
      int movetype = (int) Math.Round((double) this.game.Data.RuleVar[99]);
      int ap = (int) Math.Round((double) this.game.Data.RuleVar[3]);
      SimpleList simpleList2 = new SimpleList();
      if (this.game.Data.LocCounter == -1)
        return;
      int locCounter = this.game.Data.LocCounter;
      int regime;
      for (int tid = 0; tid <= locCounter; ++tid)
      {
        regime = this.game.Data.MapObj[this.game.Data.LocObj[tid].Map].HexObj[this.game.Data.LocObj[tid].X, this.game.Data.LocObj[tid].Y].Regime;
        int type = this.game.Data.LocObj[tid].Type;
        if (regime == this.game.Data.Turn & (this.game.Data.LocObj[tid].HQ > -1 | (double) this.game.Data.RuleVar[332] == 1.0))
          simpleList2.Add(tid, this.game.Data.LocTypeObj[type].ZOrder);
        else if (regime == this.game.Data.Turn & (this.game.Data.LocTypeObj[this.game.Data.LocObj[tid].Type].NoHQ | (double) this.game.Data.RuleVar[332] == 1.0))
          simpleList2.Add(tid, this.game.Data.LocTypeObj[type].ZOrder);
      }
      if (simpleList2.Counter == -1)
        return;
      simpleList2.Sort();
      int counter1 = simpleList2.Counter;
      CoordList coordList;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        int index2 = simpleList2.Id[index1];
        int x = this.game.Data.LocObj[index2].X;
        int y = this.game.Data.LocObj[index2].Y;
        int map = this.game.Data.LocObj[index2].Map;
        int hq = this.game.Data.LocObj[index2].HQ;
        regime = this.game.Data.MapObj[this.game.Data.LocObj[index2].Map].HexObj[this.game.Data.LocObj[index2].X, this.game.Data.LocObj[index2].Y].Regime;
        if (hq > -1 & !this.game.Data.LocTypeObj[this.game.Data.LocObj[index2].Type].NoHQ)
        {
          if (this.game.Data.UnitObj[hq].X == -1)
          {
            simpleList2.Data1[index1] = 1;
          }
          else
          {
            movetype = (int) Math.Round((double) this.game.Data.RuleVar[99]);
            ap = (int) Math.Round((double) this.game.Data.RuleVar[3]);
            if (!this.game.Data.RegimeObj[this.game.Data.Turn].AI & (double) this.game.Data.RuleVar[312] == 1.0)
              ap = 0;
            coordList = this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype, 99, ap, this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y, this.game.Data.UnitObj[hq].Map);
            if (this.game.EditObj.TempValue[map].Value[x, y] < 9999)
            {
              simpleList2.Data2[index1] = this.game.EditObj.TempValue[map].Value[x, y];
              int antiSupply = this.game.HandyFunctionsObj.GetAntiSupply(this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y, this.game.Data.UnitObj[hq].Map, x, y, map);
              simpleList2.Data3[index1] = antiSupply;
            }
            else
            {
              simpleList2.Data1[index1] = 1;
              simpleList2.Data2[index1] = 9999;
            }
          }
        }
        else if (this.game.Data.LocTypeObj[this.game.Data.LocObj[index2].Type].NoHQ)
        {
          simpleList2.Data2[index1] = 0;
          simpleList2.Data3[index1] = 0;
        }
        else if ((double) this.game.Data.RuleVar[332] != 1.0)
          simpleList2.Data1[index1] = 1;
      }
      int counter2 = simpleList2.Counter;
      for (int index3 = 0; index3 <= counter2; ++index3)
      {
        int locnr = simpleList2.Id[index3];
        int x = this.game.Data.LocObj[locnr].X;
        int y = this.game.Data.LocObj[locnr].Y;
        int map = this.game.Data.LocObj[locnr].Map;
        int hq = this.game.Data.LocObj[locnr].HQ;
        if (!this.game.Data.RegimeObj[this.game.Data.Turn].AI & (double) this.game.Data.RuleVar[312] == 1.0)
          ap = 0;
        int type = this.game.Data.LocObj[locnr].Type;
        if ((double) this.game.Data.RuleVar[332] == 0.0 & !this.game.Data.LocTypeObj[type].NoHQ)
          coordList = this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, movetype, 99, ap, this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y, this.game.Data.UnitObj[hq].Map);
        int index4 = 0;
        do
        {
          int itemtypenr = this.game.Data.LocObj[locnr].Production[index4];
          if (itemtypenr > -1)
          {
            if (Operators.CompareString(this.game.Data.LocObj[locnr].Name, "Sydney", false) == 0)
              ;
            int num1;
            int num2;
            if ((double) simpleList2.Data2[index3] > (double) this.game.Data.RuleVar[51])
            {
              num1 = (int) Math.Round(Conversion.Int(this.game.HandyFunctionsObj.GetEstimatedProduction(index4, locnr, false, false)));
              num2 = (int) Math.Round(Conversion.Int(this.game.HandyFunctionsObj.GetEstimatedProduction(index4, locnr, false, false, true)));
            }
            else
            {
              num1 = (int) Math.Round(Conversion.Int(this.game.HandyFunctionsObj.GetEstimatedProduction(index4, locnr, true, false)));
              num2 = (int) Math.Round(Conversion.Int(this.game.HandyFunctionsObj.GetEstimatedProduction(index4, locnr, true, false, true)));
            }
            bool flag = false;
            if (itemtypenr > -1 && !this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, itemtypenr).result)
            {
              num1 = 0;
              flag = true;
            }
            float num3 = 1f;
            if ((double) this.game.Data.RuleVar[332] == 0.0)
            {
              if ((double) simpleList2.Data2[index3] > (double) this.game.Data.RuleVar[53])
              {
                num1 = (int) Math.Round((double) num1 * 0.25);
                num3 = 0.25f;
              }
              else if ((double) simpleList2.Data2[index3] > (double) this.game.Data.RuleVar[52])
              {
                num1 = (int) Math.Round((double) num1 * 0.5);
                num3 = 0.5f;
              }
              else if ((double) simpleList2.Data2[index3] > (double) this.game.Data.RuleVar[51])
              {
                num1 = (int) Math.Round((double) num1 * 0.75);
                num3 = 0.75f;
              }
            }
            if (simpleList2.Data1[index3] == 1)
              num1 = 0;
            int Qty = num1;
            if (Qty > 0)
              Qty *= this.game.Data.ItemTypeObj[itemtypenr].Multiplier;
            int num4 = 0;
            int index5 = 0;
            do
            {
              if (this.game.Data.ItemTypeObj[itemtypenr].RegimeSlotsCost[index5] > -1 && this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[this.game.Data.ItemTypeObj[itemtypenr].RegimeSlotsCost[index5]] < num2 * this.game.Data.ItemTypeObj[itemtypenr].RegimeSlotsCostQty[index5])
                flag = true;
              ++index5;
            }
            while (index5 <= 4);
            int num5;
            if (simpleList2.Data3[index3] > 0 & Qty != 0)
            {
              if (this.game.Data.ItemTypeObj[itemtypenr].IsSFType > -1)
              {
                if (this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[itemtypenr].IsSFType].Theater != 1)
                {
                  int num6 = Qty;
                  Qty = (int) Math.Round(Conversion.Int((double) Qty * (1.0 - (double) simpleList2.Data3[index3] / 100.0)));
                  if (num6 == Qty && (double) VBMath.Rnd() < (double) simpleList2.Data3[index3] / 100.0)
                  {
                    --Qty;
                    num4 = 1;
                  }
                  if (num6 > Qty)
                  {
                    num4 = num6 - Qty;
                    int[] sasProdLost = this.game.Data.RegimeObj[this.game.Data.Turn].SASProdLost;
                    int[] numArray = sasProdLost;
                    int index6 = itemtypenr;
                    int index7 = index6;
                    int num7 = sasProdLost[index6] + (num6 - Qty);
                    numArray[index7] = num7;
                    if (this.game.Data.ItemTypeObj[itemtypenr].IsSupply)
                      this.game.HandyFunctionsObj.SetAntiSupplyKills(this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y, this.game.Data.UnitObj[hq].Map, x, y, map, num6 - Qty, 0, 0);
                    if (this.game.Data.ItemTypeObj[itemtypenr].IsSFType > -1)
                      this.game.HandyFunctionsObj.SetAntiSupplyKills(this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y, this.game.Data.UnitObj[hq].Map, x, y, map, 0, this.game.Data.ItemTypeObj[itemtypenr].IsSFType, num6 - Qty);
                    num5 = num6;
                  }
                }
              }
              else if (this.game.Data.ItemTypeObj[itemtypenr].IsSupply)
              {
                int num8 = Qty;
                Qty = (int) Math.Round(Conversion.Int((double) Qty * (1.0 - (double) simpleList2.Data3[index3] / 100.0)));
                if (num8 == Qty && (double) VBMath.Rnd() < (double) simpleList2.Data3[index3] / 100.0)
                {
                  --Qty;
                  num4 = 1;
                }
                if (num8 > Qty)
                {
                  num4 = num8 - Qty;
                  int[] sasProdLost = this.game.Data.RegimeObj[this.game.Data.Turn].SASProdLost;
                  int[] numArray = sasProdLost;
                  int index8 = itemtypenr;
                  int index9 = index8;
                  int num9 = sasProdLost[index8] + (num8 - Qty);
                  numArray[index9] = num9;
                  if (this.game.Data.ItemTypeObj[itemtypenr].IsSupply)
                    this.game.HandyFunctionsObj.SetAntiSupplyKills(this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y, this.game.Data.UnitObj[hq].Map, x, y, map, num8 - Qty, 0, 0);
                  if (this.game.Data.ItemTypeObj[itemtypenr].IsSFType > -1)
                    this.game.HandyFunctionsObj.SetAntiSupplyKills(this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y, this.game.Data.UnitObj[hq].Map, x, y, map, 0, this.game.Data.ItemTypeObj[itemtypenr].IsSFType, num8 - Qty);
                  num5 = num8;
                }
              }
            }
            if (Qty > 0)
            {
              int num10 = 0;
              int Xp = 0 + this.game.Data.ItemTypeObj[itemtypenr].XpMod;
              if (Xp < 0)
                Xp = 0;
              if ((double) Xp > (double) this.game.Data.RuleVar[81])
                Xp = (int) Math.Round((double) this.game.Data.RuleVar[81]);
              int Peopletype = this.game.Data.LocObj[locnr].People;
              if (this.game.Data.ItemTypeObj[itemtypenr].PeopleMod > -1)
                Peopletype = this.game.Data.ItemTypeObj[itemtypenr].PeopleMod;
              if (this.game.Data.ItemTypeObj[itemtypenr].PeopleMod == -2)
                Peopletype = this.game.Data.RegimeObj[this.game.Data.Turn].People;
              int Mor = this.game.Data.PeopleObj[this.game.Data.LocObj[locnr].People].BaseMorale[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.Turn].People].PeopleGroup];
              if (this.game.Data.ItemTypeObj[itemtypenr].MorMod > 0)
              {
                Mor += this.game.Data.ItemTypeObj[itemtypenr].MorMod;
                if (Mor > 100)
                  Mor = 100;
              }
              int moveTypeMod = this.game.Data.ItemTypeObj[itemtypenr].MoveTypeMod;
              if (this.game.Data.ItemTypeObj[itemtypenr].IsRegimeSlot > -1)
              {
                int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
                int[] numArray1 = regimeSlot;
                int isRegimeSlot = this.game.Data.ItemTypeObj[itemtypenr].IsRegimeSlot;
                int index10 = isRegimeSlot;
                int num11 = regimeSlot[isRegimeSlot] + Qty;
                numArray1[index10] = num11;
                if (num10 == 0)
                {
                  int[,] sprod = this.game.Data.RegimeObj[regime].SProd;
                  int[,] numArray2 = sprod;
                  int index11 = itemtypenr;
                  int index12 = index11;
                  int round = this.game.Data.Round;
                  int index13 = round;
                  int num12 = sprod[index11, round] + Qty;
                  numArray2[index12, index13] = num12;
                  num10 = 1;
                }
              }
              if (this.game.Data.LocTypeObj[type].NoHQ & this.game.Data.ItemTypeObj[itemtypenr].IsResPt)
              {
                RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                RegimeClass[] regimeClassArray = regimeObj;
                int turn = this.game.Data.Turn;
                int index14 = turn;
                regimeClassArray[index14].ResPts = regimeObj[turn].ResPts + Qty;
                if (num10 == 0)
                {
                  int[,] sprod = this.game.Data.RegimeObj[regime].SProd;
                  int[,] numArray = sprod;
                  int index15 = itemtypenr;
                  int index16 = index15;
                  int round = this.game.Data.Round;
                  int index17 = round;
                  int num13 = sprod[index15, round] + Qty;
                  numArray[index16, index17] = num13;
                  num10 = 1;
                }
              }
              index5 = 0;
              do
              {
                if (this.game.Data.ItemTypeObj[itemtypenr].RegimeSlotsCost[index5] > -1)
                {
                  int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
                  int[] numArray3 = regimeSlot;
                  int[] regimeSlotsCost = this.game.Data.ItemTypeObj[itemtypenr].RegimeSlotsCost;
                  int[] numArray4 = regimeSlotsCost;
                  int index18 = index5;
                  int index19 = index18;
                  int index20 = numArray4[index19];
                  int num14 = regimeSlot[regimeSlotsCost[index18]] - Qty * this.game.Data.ItemTypeObj[itemtypenr].RegimeSlotsCostQty[index5];
                  numArray3[index20] = num14;
                }
                ++index5;
              }
              while (index5 <= 4);
              int num15;
              if (!this.game.Data.LocTypeObj[type].NoHQ)
              {
                if (this.game.Data.ItemTypeObj[itemtypenr].IsSupply)
                {
                  this.game.Data.UnitObj[hq].Supply += Qty;
                  UnitClass[] unitObj = this.game.Data.UnitObj;
                  UnitClass[] unitClassArray = unitObj;
                  int index21 = hq;
                  int index22 = index21;
                  unitClassArray[index22].SupplyIn = unitObj[index21].SupplyIn + Qty;
                  if (num10 == 0)
                  {
                    int[,] sprod = this.game.Data.RegimeObj[regime].SProd;
                    int[,] numArray = sprod;
                    int index23 = itemtypenr;
                    int index24 = index23;
                    int round = this.game.Data.Round;
                    int index25 = round;
                    int num16 = sprod[index23, round] + Qty;
                    numArray[index24, index25] = num16;
                    num15 = 1;
                  }
                }
                else if (this.game.Data.ItemTypeObj[itemtypenr].IsResPt)
                {
                  RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                  RegimeClass[] regimeClassArray = regimeObj;
                  int turn = this.game.Data.Turn;
                  int index26 = turn;
                  regimeClassArray[index26].ResPts = regimeObj[turn].ResPts + Qty;
                  if (num10 == 0)
                  {
                    int[,] sprod = this.game.Data.RegimeObj[regime].SProd;
                    int[,] numArray = sprod;
                    int index27 = itemtypenr;
                    int index28 = index27;
                    int round = this.game.Data.Round;
                    int index29 = round;
                    int num17 = sprod[index27, round] + Qty;
                    numArray[index28, index29] = num17;
                    num15 = 1;
                  }
                }
                else if (this.game.Data.ItemTypeObj[itemtypenr].IsSFType > -1)
                {
                  if ((double) this.game.Data.RuleVar[332] == 0.0)
                  {
                    this.game.HandyFunctionsObj.GetPowerPtsAbsolute(hq, true);
                    int isSfType;
                    if (this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[itemtypenr].IsSFType].Theater == 0 && this.game.Data.SFTypeObj[isSfType].StaffPts < 1 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                    {
                      isSfType = this.game.Data.ItemTypeObj[itemtypenr].IsSFType;
                      int staffPoints = this.game.HandyFunctionsObj.GetStaffPoints(hq);
                      int groupPowerPoints = this.game.HandyFunctionsObj.GetGroupPowerPoints(hq);
                      int num18 = this.game.Data.SFTypeObj[isSfType].Theater != 0 ? groupPowerPoints : groupPowerPoints + this.game.Data.SFTypeObj[isSfType].PowerPts * Qty;
                      int num19 = num18 - groupPowerPoints;
                      if (num18 > staffPoints)
                        num19 -= num18 - staffPoints;
                      float num20;
                      if (num19 > 0 & staffPoints > 0)
                      {
                        num20 = (float) num19 / (float) staffPoints * this.game.Data.RuleVar[36];
                        if ((double) this.game.Data.RuleVar[36] < (double) num20)
                          num20 = this.game.Data.RuleVar[36];
                      }
                      else
                        num20 = 0.0f;
                      int sfCount = this.game.Data.UnitObj[hq].SFCount;
                      for (int index30 = 0; index30 <= sfCount; ++index30)
                      {
                        int sf = this.game.Data.UnitObj[hq].SFList[index30];
                        if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].StaffPts > 0)
                        {
                          int xp = this.game.Data.SFObj[sf].Xp;
                          int num21 = xp;
                          int num22 = (int) Math.Round(Math.Ceiling((double) xp * (1.0 - (double) num20)));
                          float num23 = (float) ((double) num21 * (1.0 - (double) num20) % 1.0);
                          if ((double) num23 > 0.0 && (double) DrawMod.RandyNumber.Next(0, 100) / 100.0 > (double) num23)
                            --num22;
                          if (0 > num22)
                            num22 = 0;
                          this.game.Data.SFObj[sf].Xp = num22;
                        }
                      }
                    }
                    if (this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[itemtypenr].IsSFType].Theater == 1 & !(this.game.Data.LocObj[locnr].X == this.game.Data.UnitObj[hq].X & this.game.Data.LocObj[locnr].Y == this.game.Data.UnitObj[hq].Y))
                    {
                      int unitForProduction = this.game.HandyFunctionsObj.GetNavyUnitForProduction(this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y, this.game.Data.LocObj[locnr].Map, this.game.Data.ItemTypeObj[itemtypenr].IsSFType, this.game.Data.LocObj[locnr].People, moveTypeMod);
                      if (unitForProduction > -1)
                      {
                        this.game.HandyFunctionsObj.AddTroops3(unitForProduction, this.game.Data.ItemTypeObj[itemtypenr].IsSFType, Peopletype, Qty, Xp, 100, 100, Mor, MoveType: moveTypeMod);
                        if (this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                        {
                          UnitClass[] unitObj = this.game.Data.UnitObj;
                          UnitClass[] unitClassArray = unitObj;
                          int index31 = unitForProduction;
                          int index32 = index31;
                          unitClassArray[index32].Supply = unitObj[index31].Supply + this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[itemtypenr].IsSFType].SupplyCarry * Qty;
                        }
                        if (num10 == 0)
                        {
                          int[,] sprod = this.game.Data.RegimeObj[regime].SProd;
                          int[,] numArray = sprod;
                          int index33 = itemtypenr;
                          int index34 = index33;
                          int round = this.game.Data.Round;
                          int index35 = round;
                          int num24 = sprod[index33, round] + Qty;
                          numArray[index34, index35] = num24;
                          num15 = 1;
                        }
                      }
                      else
                      {
                        num1 = 0;
                        Qty = 0;
                        if (num10 == 0)
                        {
                          int[,] sprod = this.game.Data.RegimeObj[regime].SProd;
                          int[,] numArray = sprod;
                          int index36 = itemtypenr;
                          int index37 = index36;
                          int round = this.game.Data.Round;
                          int index38 = round;
                          int num25 = sprod[index36, round] + Qty;
                          numArray[index37, index38] = num25;
                          num15 = 1;
                        }
                      }
                    }
                    else
                    {
                      if (this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                      {
                        UnitClass[] unitObj = this.game.Data.UnitObj;
                        UnitClass[] unitClassArray = unitObj;
                        int index39 = hq;
                        int index40 = index39;
                        unitClassArray[index40].Supply = unitObj[index39].Supply + this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[itemtypenr].IsSFType].SupplyCarry * Qty;
                      }
                      if (this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[itemtypenr].IsSFType].Theater == 2)
                        this.game.Data.UnitObj[hq].SOInterceptRdnStop = 100;
                      this.game.HandyFunctionsObj.AddTroops3(hq, this.game.Data.ItemTypeObj[itemtypenr].IsSFType, Peopletype, Qty, Xp, (int) Math.Round((double) (100f * num3)), 0, Mor, MoveType: moveTypeMod);
                      if (num10 == 0)
                      {
                        int[,] sprod = this.game.Data.RegimeObj[regime].SProd;
                        int[,] numArray = sprod;
                        int index41 = itemtypenr;
                        int index42 = index41;
                        int round = this.game.Data.Round;
                        int index43 = round;
                        int num26 = sprod[index41, round] + Qty;
                        numArray[index42, index43] = num26;
                        num15 = 1;
                      }
                    }
                  }
                  else
                  {
                    int unitForProduction = this.game.HandyFunctionsObj.GetAnyUnitForProduction(this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y, this.game.Data.LocObj[locnr].Map, this.game.Data.ItemTypeObj[itemtypenr].IsSFType, this.game.Data.LocObj[locnr].People, moveTypeMod);
                    if (unitForProduction > -1)
                    {
                      this.game.HandyFunctionsObj.AddTroops3(unitForProduction, this.game.Data.ItemTypeObj[itemtypenr].IsSFType, Peopletype, Qty, Xp, 100, 0, Mor, MoveType: moveTypeMod);
                      if (this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                      {
                        UnitClass[] unitObj = this.game.Data.UnitObj;
                        UnitClass[] unitClassArray = unitObj;
                        int index44 = unitForProduction;
                        int index45 = index44;
                        unitClassArray[index45].Supply = unitObj[index44].Supply + this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[itemtypenr].IsSFType].SupplyCarry * Qty;
                      }
                      if (num10 == 0)
                      {
                        int[,] sprod = this.game.Data.RegimeObj[regime].SProd;
                        int[,] numArray = sprod;
                        int index46 = itemtypenr;
                        int index47 = index46;
                        int round = this.game.Data.Round;
                        int index48 = round;
                        int num27 = sprod[index46, round] + Qty;
                        numArray[index47, index48] = num27;
                        num15 = 1;
                      }
                    }
                    else
                    {
                      num1 = 0;
                      Qty = 0;
                      if (num10 == 0)
                      {
                        int[,] sprod = this.game.Data.RegimeObj[regime].SProd;
                        int[,] numArray = sprod;
                        int index49 = itemtypenr;
                        int index50 = index49;
                        int round = this.game.Data.Round;
                        int index51 = round;
                        int num28 = sprod[index49, round] + Qty;
                        numArray[index50, index51] = num28;
                        num15 = 1;
                      }
                    }
                  }
                }
                else if (num10 == 0)
                {
                  int[,] sprod = this.game.Data.RegimeObj[regime].SProd;
                  int[,] numArray = sprod;
                  int index52 = itemtypenr;
                  int index53 = index52;
                  int round = this.game.Data.Round;
                  int index54 = round;
                  int num29 = sprod[index52, round] + Qty;
                  numArray[index53, index54] = num29;
                  num15 = 1;
                }
              }
            }
            int num30 = Qty;
            if (flag & num2 > num1)
              Qty += num2 - num1;
            if (!flag)
            {
              if (num1 == 0 | (double) simpleList2.Data2[index3] > (double) this.game.Data.RuleVar[51])
              {
                int[] prodPointRemainder = this.game.Data.LocObj[locnr].ProdPointRemainder;
                int[] numArray = prodPointRemainder;
                int index55 = index4;
                int index56 = index55;
                int num31 = prodPointRemainder[index55] + (this.game.HandyFunctionsObj.GetProdPtsForLoc(locnr, index4) - (Qty + num4) * this.game.Data.ItemTypeObj[itemtypenr].ProdWeight);
                numArray[index56] = num31;
              }
              else
                this.game.Data.LocObj[locnr].ProdPointRemainder[index4] = this.game.HandyFunctionsObj.GetProdPtsForLoc(locnr, index4, true) - (Qty + num4) * this.game.Data.ItemTypeObj[itemtypenr].ProdWeight;
            }
            else
              this.game.Data.LocObj[locnr].ProdPointRemainder[index4] = this.game.HandyFunctionsObj.GetProdPtsForLoc(locnr, index4, true) - (num30 + num4) * this.game.Data.ItemTypeObj[itemtypenr].ProdWeight;
            if (0 > this.game.Data.LocObj[locnr].ProdPointRemainder[index4])
              this.game.Data.LocObj[locnr].ProdPointRemainder[index4] = 0;
          }
          ++index4;
        }
        while (index4 <= 3);
      }
      if ((double) this.game.Data.RuleVar[843] <= 0.0)
        return;
      this.game.EventRelatedObj.DoCheckSpecificEvent((int) Math.Round((double) this.game.Data.RuleVar[843]));
    }

    public void LocationProductionPrognosis()
    {
      SimpleList simpleList1 = new SimpleList();
      int num1 = (int) Math.Round((double) this.game.Data.RuleVar[0]);
      int num2 = (int) Math.Round((double) this.game.Data.RuleVar[3]);
      SimpleList simpleList2 = new SimpleList();
      int regimeCounter = this.game.Data.RegimeCounter;
      for (int index = 0; index <= regimeCounter; ++index)
        this.game.Data.RegimeObj[index].TempPPIncrease = 0;
      if (this.game.Data.LocCounter == -1)
        return;
      int locCounter = this.game.Data.LocCounter;
      for (int tid = 0; tid <= locCounter; ++tid)
      {
        int regime = this.game.Data.MapObj[this.game.Data.LocObj[tid].Map].HexObj[this.game.Data.LocObj[tid].X, this.game.Data.LocObj[tid].Y].Regime;
        int type = this.game.Data.LocObj[tid].Type;
        if (regime == this.game.Data.Turn & (this.game.Data.LocObj[tid].HQ > -1 | (double) this.game.Data.RuleVar[332] == 1.0))
        {
          if (regime != -1)
            simpleList2.Add(tid, this.game.Data.LocTypeObj[type].ZOrder);
        }
        else if (regime == this.game.Data.Turn & (this.game.Data.LocTypeObj[this.game.Data.LocObj[tid].Type].NoHQ | (double) this.game.Data.RuleVar[332] == 1.0) && regime != -1)
          simpleList2.Add(tid, this.game.Data.LocTypeObj[type].ZOrder);
      }
      if (simpleList2.Counter == -1)
        return;
      simpleList2.Sort();
      int[] numArray1 = new int[500];
      int[] numArray2 = new int[500];
      if (this.game.Data.Round > 0 & this.game.Data.Turn > -1)
      {
        int index = 0;
        do
        {
          numArray2[index] = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index];
          ++index;
        }
        while (index <= 499);
      }
      int counter1 = simpleList2.Counter;
      int x;
      int y;
      int map;
      int hq;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        int index2 = simpleList2.Id[index1];
        x = this.game.Data.LocObj[index2].X;
        y = this.game.Data.LocObj[index2].Y;
        map = this.game.Data.LocObj[index2].Map;
        hq = this.game.Data.LocObj[index2].HQ;
        int regime = this.game.Data.MapObj[this.game.Data.LocObj[index2].Map].HexObj[this.game.Data.LocObj[index2].X, this.game.Data.LocObj[index2].Y].Regime;
        simpleList2.Data2[index1] = 0;
        simpleList2.Data3[index1] = 0;
      }
      int counter2 = simpleList2.Counter;
      for (int index3 = 0; index3 <= counter2; ++index3)
      {
        int locnr = simpleList2.Id[index3];
        int regime = this.game.Data.MapObj[this.game.Data.LocObj[locnr].Map].HexObj[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y].Regime;
        x = this.game.Data.LocObj[locnr].X;
        y = this.game.Data.LocObj[locnr].Y;
        map = this.game.Data.LocObj[locnr].Map;
        hq = this.game.Data.LocObj[locnr].HQ;
        int type = this.game.Data.LocObj[locnr].Type;
        int prodslot = 0;
        do
        {
          this.game.Data.LocObj[locnr].TempProdPredict[prodslot] = 0;
          int itemtypenr = this.game.Data.LocObj[locnr].Production[prodslot];
          if (itemtypenr > -1)
          {
            int num3 = (int) Math.Round(Conversion.Int(this.game.HandyFunctionsObj.GetEstimatedProduction(prodslot, locnr, true, false)));
            int num4 = (int) Math.Round(Conversion.Int(this.game.HandyFunctionsObj.GetEstimatedProduction(prodslot, locnr, true, false, true)));
            if (itemtypenr > -1 && !this.game.HandyFunctionsObj.CanProduceItem(locnr, regime, itemtypenr).result)
              num3 = 0;
            if (simpleList2.Data1[index3] == 1)
              num3 = 0;
            int num5 = num3;
            if (num5 > 0)
              num5 *= this.game.Data.ItemTypeObj[itemtypenr].Multiplier;
            if (num5 > 0)
            {
              this.game.Data.LocObj[locnr].TempProdPredict[prodslot] = num5;
              if (this.game.Data.ItemTypeObj[itemtypenr].IsRegimeSlot > -1)
              {
                int[] numArray3 = numArray1;
                int[] numArray4 = numArray3;
                int isRegimeSlot = this.game.Data.ItemTypeObj[itemtypenr].IsRegimeSlot;
                int index4 = isRegimeSlot;
                int num6 = numArray3[isRegimeSlot] + this.game.Data.ItemTypeObj[itemtypenr].Multiplier * num5;
                numArray4[index4] = num6;
              }
              if (this.game.Data.ItemTypeObj[itemtypenr].IsResPt)
              {
                RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                RegimeClass[] regimeClassArray = regimeObj;
                int index5 = regime;
                int index6 = index5;
                regimeClassArray[index6].TempPPIncrease = regimeObj[index5].TempPPIncrease + this.game.Data.ItemTypeObj[itemtypenr].Multiplier * num5;
              }
            }
            if (regime == this.game.Data.Turn && num4 > 0)
            {
              int index7 = 0;
              do
              {
                if (this.game.Data.ItemTypeObj[itemtypenr].RegimeSlotsCost[index7] > -1)
                {
                  int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
                  int[] numArray5 = regimeSlot;
                  int[] regimeSlotsCost = this.game.Data.ItemTypeObj[itemtypenr].RegimeSlotsCost;
                  int[] numArray6 = regimeSlotsCost;
                  int index8 = index7;
                  int index9 = index8;
                  int index10 = numArray6[index9];
                  int num7 = regimeSlot[regimeSlotsCost[index8]] - num4 * this.game.Data.ItemTypeObj[itemtypenr].RegimeSlotsCostQty[index7];
                  numArray5[index10] = num7;
                }
                ++index7;
              }
              while (index7 <= 4);
            }
          }
          ++prodslot;
        }
        while (prodslot <= 3);
      }
      if (!(this.game.Data.Round > 0 & this.game.Data.Turn > -1))
        return;
      int index11 = 0;
      do
      {
        this.game.Data.RegimeObj[this.game.Data.Turn].TempRegimeSlotPredict[index11] = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index11];
        this.game.Data.RegimeObj[this.game.Data.Turn].TempRegimeSlotIncrease[index11] = numArray1[index11];
        this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index11] = numArray2[index11];
        this.game.Data.RegimeObj[this.game.Data.Turn].LastTempRegimeSlotPredict[index11] = this.game.Data.RegimeObj[this.game.Data.Turn].TempRegimeSlotPredict[index11];
        ++index11;
      }
      while (index11 <= 499);
    }

    public void GoToMarchMode(int unr)
    {
      int sfCount = this.game.Data.UnitObj[unr].SFCount;
      for (int index1 = 0; index1 <= sfCount; ++index1)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index1];
        SFClass[] sfObj = this.game.Data.SFObj;
        SFClass[] sfClassArray = sfObj;
        int index2 = sf;
        int index3 = index2;
        sfClassArray[index3].Ap = sfObj[index2].Ap - 25;
        if (0 > this.game.Data.SFObj[sf].Ap)
          this.game.Data.SFObj[sf].Ap = 0;
        this.game.Data.SFObj[sf].Rdn = (int) Math.Round(0.75 * (double) this.game.Data.SFObj[sf].Rdn);
      }
      this.game.Data.UnitObj[unr].moveMode = 1;
    }

    public OrderResult ExecuteMovement(
      int unr,
      int x1,
      int y1,
      int map1,
      int x2,
      int y2,
      int map2,
      bool immediateBattleExecute = false,
      bool allowHistoryForOwnRegime = false)
    {
      Coordinate[] coordinateArray = new Coordinate[251];
      OrderResult orderResult1 = new OrderResult();
      MapMatrix2[] mapMatrix2Array = new MapMatrix2[this.game.Data.MapCounter + 1];
      orderResult1.OK = false;
      if (x1 == x2 & y1 == y2)
        return orderResult1;
      orderResult1.OK = true;
      SimpleList simpleList1 = new SimpleList();
      bool isSea = this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y].LandscapeType].IsSea;
      bool flag;
      if (this.game.HandyFunctionsObj.HasUnitAirSF(unr) && !this.game.HandyFunctionsObj.HasUnitlandSF(unr) && !this.game.HandyFunctionsObj.HasUnitNavySF(unr))
        flag = true;
      int mapCounter1 = this.game.Data.MapCounter;
      for (int index1 = 0; index1 <= mapCounter1; ++index1)
      {
        mapMatrix2Array[index1] = new MapMatrix2(this.game.Data.MapObj[index1].MapWidth, this.game.Data.MapObj[index1].MapHeight);
        int mapWidth = this.game.Data.MapObj[index1].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; ++index2)
        {
          int mapHeight = this.game.Data.MapObj[index1].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; ++index3)
            mapMatrix2Array[index1].Value[index2, index3] = 9999;
        }
      }
      int index4 = x2;
      int index5 = y2;
      int index6 = map2;
      coordinateArray[0].x = x2;
      coordinateArray[0].y = y2;
      coordinateArray[0].map = map2;
      int index7 = 0;
      int regime1 = this.game.Data.UnitObj[unr].Regime;
      for (; !(index4 == x1 & index5 == y1 & index6 == map1); index6 = coordinateArray[index7].map)
      {
        ++index7;
        if (index7 > 249)
        {
          orderResult1.OK = false;
          return orderResult1;
        }
        coordinateArray[index7] = this.game.EditObj.TempCameFrom[index6].Value[index4, index5];
        index4 = coordinateArray[index7].x;
        index5 = coordinateArray[index7].y;
      }
      int num1 = index7 - 1;
      int x3 = x1;
      int y3 = y1;
      int index8 = map1;
      if ((double) this.game.Data.RuleVar[814] == 1.0)
        num1 = 0;
      int ox = x3;
      int oy = y3;
      if ((this.game.Data.Product == 6 | this.game.Data.Product == 7) & this.game.Data.RegimeObj[this.game.Data.Turn].AI)
      {
        if (Information.IsNothing((object) this.game.Data.UnitObj[unr].tempCoords))
          this.game.Data.UnitObj[unr].tempCoords = new CoordList();
        this.game.Data.UnitObj[unr].tempCoords.AddCoord(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0);
      }
      int regime2;
      int num2;
      for (int index9 = num1; index9 >= 0; index9 += -1)
      {
        int hisdata = 0;
        if ((double) this.game.Data.RuleVar[459] > 0.0 & this.game.Data.Product >= 6 && !this.game.HandyFunctionsObj.HasUnitAirSF(unr) && !this.game.HandyFunctionsObj.HasUnitNavySF(unr))
        {
          int num3 = this.game.HandyFunctionsObj.HexFacing(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0, coordinateArray[index9].x, coordinateArray[index9].y, 0) - 1;
          int num4 = num3 + 3;
          if (num4 > 5)
            num4 -= 6;
          int num5 = (int) Math.Round(Math.Ceiling((double) (this.game.HandyFunctionsObj.GetUnitWeight(unr, true) * 1) / (double) this.game.Data.RuleVar[33]));
          if (this.game.Data.UnitObj[unr].moveMode == 1)
            num5 *= 2;
          int[] liSpoints1 = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y].LISpoints;
          int[] numArray1 = liSpoints1;
          int index10 = num3;
          int index11 = index10;
          int num6 = liSpoints1[index10] + num5;
          numArray1[index11] = num6;
          int[] liSpoints2 = this.game.Data.MapObj[0].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].LISpoints;
          int[] numArray2 = liSpoints2;
          int index12 = num4;
          int index13 = index12;
          int num7 = liSpoints2[index12] + num5;
          numArray2[index13] = num7;
        }
        if (!this.game.HandyFunctionsObj.VisibleEnemyUnitsInHex(coordinateArray[index9].x, coordinateArray[index9].y, coordinateArray[index9].map, regime1, true, true) | this.game.HandyFunctionsObj.HasUnitAirSF(unr) & !this.game.HandyFunctionsObj.HasUnitNavySF(unr))
        {
          regime2 = this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Regime;
          if (!this.game.HandyFunctionsObj.HasUnitAirSF(unr) && !this.game.HandyFunctionsObj.HasUnitNavySF(unr) && this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Regime != this.game.Data.Turn)
          {
            num2 = 0;
            if (this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Regime == -1)
              num2 = 1;
            else if (this.game.Data.RegimeObj[regime1].RegimeRel[this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Regime] == 0)
              num2 = 1;
            if (num2 == 1)
            {
              if ((double) this.game.Data.RuleVar[840] == 1.0 & this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].OrigOwner > -1 & this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[unr].Regime, this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].OrigOwner))
              {
                if (unr > -1)
                  this.game.HandyFunctionsObj.UnitCausesHexOwnershipChange(this.game.Data.UnitObj[unr].Regime, coordinateArray[index9].x, coordinateArray[index9].y, ox, oy);
                this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].set_LastReg(this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Regime, this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].OrigOwner);
                this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Regime = this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].OrigOwner;
              }
              else
              {
                if (unr > -1)
                  this.game.HandyFunctionsObj.UnitCausesHexOwnershipChange(this.game.Data.UnitObj[unr].Regime, coordinateArray[index9].x, coordinateArray[index9].y, ox, oy);
                this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Regime = this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime <= -1 ? this.game.Data.Turn : this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime;
                if (this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].FuzzyBlock == 1)
                  this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].FuzzyBlock = 2;
              }
              if (this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Location > -1)
              {
                this.game.Data.LocObj[this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Location].HQ = -1;
                int index14 = 0;
                do
                {
                  this.game.Data.LocObj[this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Location].Production[index14] = -1;
                  this.game.Data.LocObj[this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Location].ProdPercent[index14] = 0;
                  this.game.Data.LocObj[this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Location].ProdPointRemainder[index14] = 0;
                  ++index14;
                }
                while (index14 <= 3);
                if ((double) this.game.Data.RuleVar[898] > 0.0)
                  this.game.Data.LocObj[this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Location].StructuralPts = 0;
                if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Location].Type].AutoProd > -1)
                {
                  this.game.Data.LocObj[this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Location].Production[0] = this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Location].Type].AutoProd;
                  this.game.Data.LocObj[this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Location].ProdPercent[0] = 100;
                  this.game.HandyFunctionsObj.UpgradeProduction(this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].Location);
                }
                this.LocationProductionPrognosis();
              }
            }
            hisdata = 1;
          }
          int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
          for (int index15 = 0; index15 <= sfCount1; ++index15)
          {
            int type = this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index15]].Type;
            int tweight = this.game.HandyFunctionsObj.MoveApCostPreview2(x1, y1, this.game.Data.Turn, this.game.Data.SFTypeObj[type].MoveType, this.game.Data.SFTypeObj[type].Theater, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, coordinateArray[index9].x, coordinateArray[index9].y, coordinateArray[index9].map, false, redux: this.game.Data.SFTypeObj[type].MoveRedux).x;
            if (this.game.Data.SFTypeObj[type].Theater == 2)
              tweight = (int) Math.Round((double) tweight / 2.0);
            if (tweight > 4000)
              tweight = 0;
            simpleList1.AddWeight(this.game.Data.UnitObj[unr].SFList[index15], tweight);
          }
          int transportCounter1 = this.game.Data.UnitObj[unr].TransportCounter;
          for (int index16 = 0; index16 <= transportCounter1; ++index16)
          {
            int transport = this.game.Data.UnitObj[unr].TransportList[index16];
            int sfCount2 = this.game.Data.UnitObj[transport].SFCount;
            for (int index17 = 0; index17 <= sfCount2; ++index17)
            {
              int type = this.game.Data.SFObj[this.game.Data.UnitObj[transport].SFList[index17]].Type;
              int tweight = this.game.HandyFunctionsObj.MoveApCostPreview2(x1, y1, this.game.Data.Turn, this.game.Data.SFTypeObj[type].MoveType, this.game.Data.SFTypeObj[type].Theater, this.game.Data.UnitObj[transport].X, this.game.Data.UnitObj[transport].Y, this.game.Data.UnitObj[transport].Map, coordinateArray[index9].x, coordinateArray[index9].y, coordinateArray[index9].map, false, redux: this.game.Data.SFTypeObj[type].MoveRedux).x;
              if (this.game.Data.SFTypeObj[type].Theater == 2)
                tweight = (int) Math.Round((double) tweight / 2.0);
              if (tweight > 4000)
                tweight = 0;
              simpleList1.AddWeight(this.game.Data.UnitObj[transport].SFList[index17], tweight);
            }
          }
          this.game.Data.MapObj[index8].HexObj[x3, y3].RemoveUnitFromList(unr);
          int transportCounter2 = this.game.Data.UnitObj[unr].TransportCounter;
          for (int index18 = 0; index18 <= transportCounter2; ++index18)
            this.game.Data.MapObj[index8].HexObj[x3, y3].RemoveUnitFromList(this.game.Data.UnitObj[unr].TransportList[index18]);
          ++this.game.Data.StepNr;
          string infostring1 = this.game.Data.UnitObj[unr].Name + " moves...";
          if (!flag | x3 == x1 & y3 == y1 & index8 == map1)
            this.game.HandyFunctionsObj.HistoryAddHex(x3, y3, index8, regime1, 2, 0, unr, infostring: infostring1, allowAddedForCurrentTurn: allowHistoryForOwnRegime, infostringunknown: "Unknown unit moves...", infostringnotseen: "Unseen unit moves...");
          if (this.game.Data.UnitObj[unr].PassengerCounter > -1 && (double) this.game.Data.RuleVar[881] > 0.0 && this.game.HandyFunctionsObj.IsHexPort(x3, y3, 0) & !isSea)
          {
            int passengerCounter = this.game.Data.UnitObj[unr].PassengerCounter;
            for (int index19 = 0; index19 <= passengerCounter; ++index19)
            {
              int passenger = this.game.Data.UnitObj[unr].PassengerList[index19];
              int sfCount3 = this.game.Data.UnitObj[passenger].SFCount;
              for (int index20 = 0; index20 <= sfCount3; ++index20)
                this.game.Data.SFObj[this.game.Data.UnitObj[passenger].SFList[index20]].Ap = 0;
            }
          }
          int transportCounter3 = this.game.Data.UnitObj[unr].TransportCounter;
          for (int index21 = 0; index21 <= transportCounter3; ++index21)
            this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].AddUnitToList(this.game.Data.UnitObj[unr].TransportList[index21]);
          this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].AddUnitToList(unr);
          if ((this.game.Data.Product == 6 | this.game.Data.Product == 7) & this.game.Data.RegimeObj[this.game.Data.Turn].AI)
            this.game.Data.UnitObj[unr].tempCoords.AddCoord(coordinateArray[index9].x, coordinateArray[index9].y, 0);
          int x4 = this.game.Data.UnitObj[unr].X;
          int y4 = this.game.Data.UnitObj[unr].Y;
          this.game.Data.UnitObj[unr].X = coordinateArray[index9].x;
          this.game.Data.UnitObj[unr].Y = coordinateArray[index9].y;
          this.game.Data.UnitObj[unr].Map = coordinateArray[index9].map;
          this.game.HandyFunctionsObj.SetHexReconAndZOCUnitMoves(x4, y4, index8, coordinateArray[index9].x, coordinateArray[index9].y, coordinateArray[index9].map, this.game.Data.UnitObj[unr].Regime, unr, dontcountair: true);
          if (this.game.EventRelatedObj.Helper_AirEnabled())
          {
            int historical = this.game.Data.UnitObj[unr].Historical;
            if (historical > -1)
            {
              this.game.Data.HistoricalUnitObj[historical].SetHisVarValue(55, 0);
              this.game.Data.HistoricalUnitObj[historical].SetHisVarValue(56, 0);
              this.game.Data.HistoricalUnitObj[historical].SetHisVarValue(57, 0);
              this.game.Data.HistoricalUnitObj[historical].SetHisVarValue(58, 0);
              this.game.Data.HistoricalUnitObj[historical].SetHisVarValue(59, 0);
            }
          }
          int transportCounter4 = this.game.Data.UnitObj[unr].TransportCounter;
          for (int index22 = 0; index22 <= transportCounter4; ++index22)
          {
            int transport = this.game.Data.UnitObj[unr].TransportList[index22];
            int x5 = this.game.Data.UnitObj[transport].X;
            int y5 = this.game.Data.UnitObj[transport].Y;
            this.game.Data.UnitObj[transport].X = coordinateArray[index9].x;
            this.game.Data.UnitObj[transport].Y = coordinateArray[index9].y;
            this.game.Data.UnitObj[transport].Map = coordinateArray[index9].map;
            this.game.HandyFunctionsObj.SetHexReconAndZOCUnitMoves(x5, y5, index8, coordinateArray[index9].x, coordinateArray[index9].y, coordinateArray[index9].map, this.game.Data.UnitObj[transport].Regime, transport, dontcountair: true);
          }
          if (!flag | coordinateArray[index9].x == x2 & coordinateArray[index9].y == y2 & coordinateArray[index9].map == map2)
          {
            string infostring2 = this.game.Data.UnitObj[unr].Name + " moves...";
            this.game.HandyFunctionsObj.HistoryAddHex(coordinateArray[index9].x, coordinateArray[index9].y, coordinateArray[index9].map, regime1, 2, hisdata, unr, infostring: infostring2, allowAddedForCurrentTurn: allowHistoryForOwnRegime, infostringunknown: "Unknown unit moves...", infostringnotseen: "Unseen unit moves...");
          }
          x3 = coordinateArray[index9].x;
          y3 = coordinateArray[index9].y;
          index8 = coordinateArray[index9].map;
          mapMatrix2Array[index8].Value[x3, y3] = 0;
          orderResult1.CList.AddCoord(x3, y3, index8);
          if ((double) this.game.Data.RuleVar[428] > 0.0 && this.game.HandyFunctionsObj.CheckIfIntercepted(unr, coordinateArray[index9].x, coordinateArray[index9].y))
          {
            orderResult1.BattleUnit = unr;
            orderResult1.BattleX = coordinateArray[index9].x;
            orderResult1.BattleY = coordinateArray[index9].y;
            orderResult1.BattleMap = coordinateArray[index9].map;
            orderResult1.BattleIntercept = true;
            break;
          }
          if (this.game.Data.MapObj[index8].HexObj[x3, y3].CardUponConquest > -1 & (this.game.HandyFunctionsObj.HasUnitlandSF(unr) | this.game.HandyFunctionsObj.HasUnitNavySF(unr)))
          {
            this.game.EditObj.AreaX = x3;
            this.game.EditObj.AreaY = y3;
            this.game.EditObj.AreaMap = index8;
            if (regime2 > -1 && !this.game.Data.RegimeObj[regime2].AI)
              this.game.EditObj.DoCardSlot = this.game.Data.MapObj[index8].HexObj[x3, y3].CardUponConquest;
            x2 = x3;
            y2 = y3;
            map2 = index8;
            break;
          }
          ox = coordinateArray[index9].x;
          oy = coordinateArray[index9].y;
        }
        else
        {
          if (index9 == num1)
          {
            x2 = x1;
            y2 = y1;
            map2 = map1;
          }
          else
          {
            x2 = coordinateArray[index9 + 1].x;
            y2 = coordinateArray[index9 + 1].y;
            map2 = coordinateArray[index9 + 1].map;
          }
          if (!this.game.HandyFunctionsObj.VisibleEnemyUnitsInHex(coordinateArray[index9].x, coordinateArray[index9].y, coordinateArray[index9].map, regime1, alwaysshowotherregime: true))
          {
            if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].LandscapeType].IsSea & (double) this.game.Data.RuleVar[326] == 0.0)
            {
              int[,] numArray3 = this.game.EditObj.TempValue[map2].Value;
              int[,] numArray4 = numArray3;
              int index23 = x2;
              int index24 = index23;
              int index25 = y2;
              int index26 = index25;
              int num8 = numArray3[index23, index25] + 25;
              numArray4[index24, index26] = num8;
            }
            else
            {
              orderResult1.BattleUnit = unr;
              orderResult1.BattleX = coordinateArray[index9].x;
              orderResult1.BattleY = coordinateArray[index9].y;
              orderResult1.BattleMap = coordinateArray[index9].map;
            }
            if ((double) this.game.Data.RuleVar[431] < 1.0)
              this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].MaxRecon = 999;
            int regimeCounter = this.game.Data.RegimeCounter;
            for (int index27 = 0; index27 <= regimeCounter; ++index27)
            {
              if (index27 != this.game.Data.Turn && this.game.HandyFunctionsObj.IsAlliedOrSelf(index27, this.game.Data.Turn, true) && this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].MaxRecon > this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].get_ReconPts(index27))
                this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].set_ReconPts(index27, this.game.Data.MapObj[coordinateArray[index9].map].HexObj[coordinateArray[index9].x, coordinateArray[index9].y].MaxRecon);
            }
            break;
          }
          break;
        }
      }
      int index28 = unr;
      int transportCounter = this.game.Data.UnitObj[index28].TransportCounter;
      for (int index29 = -1; index29 <= transportCounter; ++index29)
      {
        if (index29 == -1)
          unr = index28;
        if (index29 > -1)
          unr = this.game.Data.UnitObj[index28].TransportList[index29];
        this.game.Data.UnitObj[unr].DidMove = true;
        this.game.Data.UnitObj[unr].apReserve = 0;
        this.game.Data.UnitObj[unr].Spotted = false;
        this.game.Data.UnitObj[unr].Identified = false;
        if (this.game.Data.UnitObj[unr].SFCount > -1)
        {
          UnitClass[] unitObj1 = this.game.Data.UnitObj;
          UnitClass[] unitClassArray1 = unitObj1;
          int index30 = unr;
          int index31 = index30;
          unitClassArray1[index31].MoveAPSpent = unitObj1[index30].MoveAPSpent + this.game.EditObj.TempValue[map2].Value[x2, y2];
          SimpleList simpleList2 = new SimpleList();
          int sf1;
          if (this.game.Data.Product >= 5)
          {
            int sfCount = this.game.Data.UnitObj[unr].SFCount;
            for (int index32 = 0; index32 <= sfCount; ++index32)
            {
              int sf2 = this.game.Data.UnitObj[unr].SFList[index32];
              if (sf2 != sf1)
              {
                int type = this.game.Data.SFObj[sf2].Type;
                if (this.game.Data.SFTypeObj[type].CarryCap > 0)
                {
                  int readinessLoss = this.game.Data.SFTypeObj[type].ReadinessLoss;
                  if (this.game.Data.UnitObj[unr].moveMode == 1 && readinessLoss * 2 > 30)
                    ;
                  simpleList2.Add(sf2, this.game.Data.SFTypeObj[type].CarryCap * this.game.Data.SFObj[sf2].Qty, this.game.Data.SFTypeObj[type].ReadinessLoss, this.game.Data.SFTypeObj[type].CarryCap, type, tdata5: this.game.Data.SFTypeObj[type].ReadinessLoss, CheckExistence: false);
                }
              }
            }
            simpleList2.removeWeight0orLower();
            simpleList2.SortOnData5();
          }
          int sfCount4 = this.game.Data.UnitObj[unr].SFCount;
          for (int index33 = 0; index33 <= sfCount4; ++index33)
          {
            sf1 = this.game.Data.UnitObj[unr].SFList[index33];
            int type1 = this.game.Data.SFObj[sf1].Type;
            num2 = 1;
            if (this.game.Data.SFTypeObj[type1].Theater == 2 && this.game.HandyFunctionsObj.HasUnitNavySF(unr))
              num2 = 0;
            if (num2 == 1)
            {
              if ((double) this.game.Data.RuleVar[321] == 1.0 & !this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].AI)
                this.game.Data.SFObj[sf1].EP = 0;
              this.game.Data.SFObj[sf1].Ap -= this.game.EditObj.TempValue[map2].Value[x2, y2];
              if ((double) this.game.Data.RuleVar[407] > 0.0)
              {
                int num9 = 0;
                Coordinate coordinate1;
                coordinate1.x = x2;
                coordinate1.y = y2;
                Coordinate coordinate2 = this.game.EditObj.TempCameFrom[0].Value[coordinate1.x, coordinate1.y];
                while (coordinate2.onmap)
                {
                  ++num9;
                  coordinate2 = this.game.EditObj.TempCameFrom[0].Value[coordinate2.x, coordinate2.y];
                  if (num9 > 99)
                  {
                    num9 = 100;
                    break;
                  }
                }
                if (num9 > 0)
                {
                  int tid = this.game.Data.SFTypeObj[type1].SFTypeVar[(int) Math.Round((double) (this.game.Data.RuleVar[407] + 0.0f))];
                  int num10 = this.game.Data.SFTypeObj[type1].SFTypeVar[(int) Math.Round((double) (this.game.Data.RuleVar[407] + 1f))];
                  if (tid > 0 & num10 > 0)
                  {
                    int tweight1;
                    float d;
                    if (this.game.Data.SFTypeObj[type1].Theater == 2)
                    {
                      tweight1 = (int) Math.Round(Math.Ceiling((double) (this.game.Data.SFObj[sf1].Qty * num10 * num9) / 20.0));
                      d = (float) (this.game.Data.SFObj[sf1].Qty * num10 * num9) / 20f;
                    }
                    else
                    {
                      tweight1 = (int) Math.Round(Math.Ceiling((double) (this.game.Data.SFObj[sf1].Qty * num10 * num9) / 10.0));
                      d = (float) (this.game.Data.SFObj[sf1].Qty * num10 * num9) / 10f;
                    }
                    float num11 = (float) tweight1 - d;
                    if ((double) VBMath.Rnd() > (double) num11)
                    {
                      if (tweight1 > 0)
                        this.game.Data.UnitObj[unr].items.list.RemoveWeight(tid, tweight1);
                    }
                    else
                    {
                      int tweight2 = (int) Math.Round(Math.Floor((double) d));
                      if (tweight2 > 0)
                        this.game.Data.UnitObj[unr].items.list.RemoveWeight(tid, tweight2);
                    }
                  }
                }
                if (Information.IsNothing((object) this.game.Data.UnitObj[unr].items))
                  this.game.Data.UnitObj[unr].items = new ItemList();
                this.game.Data.UnitObj[unr].items.list.removeWeight0orLower();
              }
              int num12 = simpleList1.FindWeight(sf1);
              if (this.game.Data.UnitObj[unr].FreeCombatX == x2 & this.game.Data.UnitObj[unr].FreeCombatY == y2)
                num12 = 0;
              if (this.game.Data.SFTypeObj[type1].FuelForMove > 0 & this.game.Data.SFTypeObj[type1].FuelRegimeVar > -1)
              {
                if ((double) this.game.Data.RuleVar[435] > 0.0)
                {
                  int fuelForMove = this.game.Data.SFTypeObj[type1].FuelForMove;
                  int fuelRegimeVar = this.game.Data.SFTypeObj[type1].FuelRegimeVar;
                  if (this.game.Data.SFTypeObj[type1].FuelForMove > fuelForMove & num12 > 0)
                    fuelForMove = this.game.Data.SFTypeObj[type1].FuelForMove;
                  int num13 = fuelForMove * this.game.Data.SFObj[sf1].Qty;
                  if (this.game.Data.UnitObj[unr].moveMode == 1)
                    num13 = (int) Math.Round(Math.Ceiling((double) num13 / 2.0));
                  UnitClass[] unitObj2 = this.game.Data.UnitObj;
                  UnitClass[] unitClassArray2 = unitObj2;
                  int index34 = unr;
                  int index35 = index34;
                  unitClassArray2[index35].Fuel = unitObj2[index34].Fuel - num13;
                  if (0 > this.game.Data.UnitObj[unr].Fuel)
                    this.game.Data.UnitObj[unr].Fuel = 0;
                  UnitClass[] unitObj3 = this.game.Data.UnitObj;
                  UnitClass[] unitClassArray3 = unitObj3;
                  int index36 = unr;
                  int index37 = index36;
                  unitClassArray3[index37].FuelUsedMove = unitObj3[index36].FuelUsedMove + num13;
                }
                else if (num12 > 0)
                {
                  int num14 = (int) Math.Round((double) this.game.Data.SFTypeObj[type1].FuelForMove * ((double) num12 / 10.0));
                  int currentSlot = this.game.Data.SFTypeObj[type1].FuelRegimeVar;
                  if ((double) this.game.Data.RuleVar[949] > 0.0)
                    currentSlot = this.game.HandyFunctionsObj.GetFuelSlot949(currentSlot, x1, y1);
                  if (this.game.Data.SFTypeObj[type1].FuelForMove > num14)
                    num14 = this.game.Data.SFTypeObj[type1].FuelForMove;
                  int num15 = num14 * this.game.Data.SFObj[sf1].Qty;
                  if (this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].RegimeSlot[currentSlot] >= num15)
                  {
                    int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].RegimeSlot;
                    int[] numArray5 = regimeSlot;
                    int index38 = currentSlot;
                    int index39 = index38;
                    int num16 = regimeSlot[index38] - num15;
                    numArray5[index39] = num16;
                    int[] regimeSlotPredict = this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].TempRegimeSlotPredict;
                    int[] numArray6 = regimeSlotPredict;
                    int index40 = currentSlot;
                    int index41 = index40;
                    int num17 = regimeSlotPredict[index40] - num15;
                    numArray6[index41] = num17;
                    UnitClass[] unitObj4 = this.game.Data.UnitObj;
                    UnitClass[] unitClassArray4 = unitObj4;
                    int index42 = unr;
                    int index43 = index42;
                    unitClassArray4[index43].FuelUsedMove = unitObj4[index42].FuelUsedMove + num15;
                  }
                  else
                  {
                    int num18 = this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].RegimeSlot[currentSlot];
                    int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].RegimeSlot;
                    int[] numArray7 = regimeSlot;
                    int index44 = currentSlot;
                    int index45 = index44;
                    int num19 = regimeSlot[index44] - num18;
                    numArray7[index45] = num19;
                    int[] regimeSlotPredict = this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].TempRegimeSlotPredict;
                    int[] numArray8 = regimeSlotPredict;
                    int index46 = currentSlot;
                    int index47 = index46;
                    int num20 = regimeSlotPredict[index46] - num18;
                    numArray8[index47] = num20;
                    UnitClass[] unitObj5 = this.game.Data.UnitObj;
                    UnitClass[] unitClassArray5 = unitObj5;
                    int index48 = unr;
                    int index49 = index48;
                    unitClassArray5[index49].FuelUsedMove = unitObj5[index48].FuelUsedMove + num18;
                  }
                }
              }
              float num21 = (float) this.game.Data.SFTypeObj[this.game.Data.SFObj[sf1].Type].ReadinessLoss;
              if (this.game.Data.UnitObj[unr].moveMode == 1)
              {
                num21 *= 2f;
                if ((double) num21 > 30.0)
                  num21 = 30f;
              }
              float Number = num21 * ((float) this.game.EditObj.TempValue[map2].Value[x2, y2] / 100f);
              int num22 = (int) Math.Round((double) Conversion.Int(Number));
              if (this.game.Data.Product >= 5)
              {
                int num23 = 0;
                int num24 = 0;
                int num25 = this.game.Data.SFTypeObj[this.game.Data.SFObj[sf1].Type].Weight * this.game.Data.SFObj[sf1].Qty;
                int num26 = this.game.Data.SFTypeObj[this.game.Data.SFObj[sf1].Type].Weight * this.game.Data.SFObj[sf1].Qty;
                if (this.game.Data.UnitObj[unr].attachedTo > -1 & this.game.Data.SFTypeObj[this.game.Data.SFObj[sf1].Type].CarryCap < 1)
                {
                  int attachedTo = this.game.Data.UnitObj[unr].attachedTo;
                  int num27 = 0;
                  int num28 = 0;
                  int sfCount5 = this.game.Data.UnitObj[attachedTo].SFCount;
                  for (int index50 = 0; index50 <= sfCount5; ++index50)
                  {
                    int type2 = this.game.Data.SFObj[this.game.Data.UnitObj[attachedTo].SFList[index50]].Type;
                    int qty = this.game.Data.SFObj[this.game.Data.UnitObj[attachedTo].SFList[index50]].Qty;
                    if (this.game.Data.SFTypeObj[type2].CarryCap > 0)
                    {
                      if (this.game.Data.UnitObj[attachedTo].moveMode == 1)
                        num27 += this.game.Data.SFTypeObj[type2].ReadinessLoss * qty;
                      else
                        num27 += this.game.Data.SFTypeObj[type2].ReadinessLoss * qty;
                      num28 += qty;
                    }
                  }
                  if (num28 > 0)
                  {
                    Number = (float) (int) Math.Round((double) num27 / (double) num28) * ((float) this.game.EditObj.TempValue[map2].Value[x2, y2] / 100f);
                    num22 = (int) Math.Round((double) Conversion.Int(Number));
                  }
                }
                else if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf1].Type].CarryCap < 1)
                {
                  int counter = simpleList2.Counter;
                  for (int index51 = 0; index51 <= counter; ++index51)
                  {
                    if (num26 > 0 & simpleList2.Weight[index51] > 0 & this.game.Data.SFTypeObj[simpleList2.Data3[index51]].CarryCap >= this.game.Data.SFTypeObj[this.game.Data.SFObj[sf1].Type].Weight)
                    {
                      int num29 = this.game.Data.SFTypeObj[this.game.Data.SFObj[sf1].Type].ReadinessLoss;
                      if (this.game.Data.UnitObj[unr].moveMode == 1)
                      {
                        num29 *= 2;
                        if (num29 > 30)
                          num29 = 30;
                      }
                      if (num29 > simpleList2.Data1[index51])
                      {
                        if (simpleList2.Weight[index51] < num26)
                        {
                          num24 += simpleList2.Weight[index51] * simpleList2.Data1[index51];
                          num23 += simpleList2.Weight[index51];
                          num26 -= simpleList2.Weight[index51];
                          simpleList2.Weight[index51] = 0;
                        }
                        else
                        {
                          num24 += num26 * simpleList2.Data1[index51];
                          num23 += num26;
                          int[] weight = simpleList2.Weight;
                          int[] numArray = weight;
                          int index52 = index51;
                          int index53 = index52;
                          int num30 = weight[index52] - num26;
                          numArray[index53] = num30;
                          num26 = 0;
                        }
                      }
                    }
                  }
                  if (num24 > 0)
                  {
                    int num31 = (int) Math.Round((double) num24 / (double) num23);
                    int num32 = this.game.Data.SFTypeObj[this.game.Data.SFObj[sf1].Type].ReadinessLoss;
                    if (this.game.Data.UnitObj[unr].moveMode == 1)
                    {
                      num32 *= 2;
                      if (num32 > 30)
                        num32 = 30;
                    }
                    if (num31 < num32)
                    {
                      Number = (float) num31 * ((float) this.game.EditObj.TempValue[map2].Value[x2, y2] / 100f);
                      num22 = (int) Math.Round((double) Conversion.Int(Number));
                    }
                  }
                }
              }
              float num33 = Number - (float) num22;
              if ((double) num33 > 0.0 && (double) VBMath.Rnd() < (double) num33)
                ++num22;
              if (!this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].AI | (double) this.game.Data.RuleVar[995] == 0.0)
                this.game.Data.SFObj[sf1].Rdn -= num22;
              else if (this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].AI | (double) this.game.Data.RuleVar[995] == 2.0)
                this.game.Data.SFObj[sf1].Rdn = (int) Math.Round((double) this.game.Data.SFObj[sf1].Rdn - (double) num22 / 2.0);
              if ((double) this.game.Data.SFObj[sf1].Rdn < (double) this.game.Data.RuleVar[60])
                this.game.Data.SFObj[sf1].Rdn = (int) Math.Round((double) this.game.Data.RuleVar[60]);
              if (0 > this.game.Data.SFObj[sf1].Ap)
                this.game.Data.SFObj[sf1].Ap = 0;
            }
            if (this.game.EditObj.TempValue[map2].Value[x2, y2] >= 0 & !(x2 == x1 & y2 == y1 & map2 == map1))
            {
              int num34 = (int) Math.Round((double) this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[map2].HexObj[x2, y2].LandscapeType].DefBonus[this.game.Data.SFTypeObj[type1].UnitGroup]);
              if (this.game.Data.MapObj[map2].HexObj[x2, y2].Location > -1 && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[map2].HexObj[x2, y2].Location].Type].PictureLT > -1)
                num34 = (int) Math.Round((double) ((float) num34 + this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[map2].HexObj[x2, y2].Location].Type].PictureLT].DefBonus[this.game.Data.SFTypeObj[type1].UnitGroup]));
              this.game.Data.SFObj[sf1].CurrentEntrench = num34;
              this.game.Data.SFObj[sf1].initialEntrench = this.game.Data.SFObj[sf1].CurrentEntrench;
            }
          }
        }
        this.game.Data.UnitObj[unr].FreeCombatX = -1;
        this.game.Data.UnitObj[unr].FreeCombatY = -1;
        this.game.Data.UnitObj[unr].FreeCombatMap = -1;
      }
      unr = index28;
      if (!this.game.Data.RegimeObj[this.game.Data.Turn].AI & !immediateBattleExecute)
      {
        int num35 = 3;
        if ((double) this.game.Data.RuleVar[419] > 0.0 && (double) this.game.Data.RuleVar[422] > 0.0)
          num35 = (int) Math.Round(Conversion.Val((object) this.game.Data.RuleVar[422]));
        int num36 = 9999;
        int num37 = 0;
        int num38 = 9999;
        int num39 = 0;
        int counter1 = orderResult1.CList.counter;
        for (int index54 = 0; index54 <= counter1; ++index54)
        {
          if (orderResult1.CList.coord[index54].x < num36)
            num36 = orderResult1.CList.coord[index54].x;
          if (orderResult1.CList.coord[index54].x > num37)
            num37 = orderResult1.CList.coord[index54].x;
          if (orderResult1.CList.coord[index54].y < num38)
            num38 = orderResult1.CList.coord[index54].y;
          if (orderResult1.CList.coord[index54].y > num39)
            num39 = orderResult1.CList.coord[index54].y;
        }
        int num40 = num36 - (num35 + 1);
        int num41 = num37 + (num35 + 1);
        int num42 = num38 - (num35 + 1);
        int num43 = num39 + (num35 + 1);
        if (num40 < 0)
          num40 = 0;
        if (num41 > this.game.Data.MapObj[0].MapWidth)
          num41 = this.game.Data.MapObj[0].MapWidth;
        if (num42 < 0)
          num42 = 0;
        if (num43 > this.game.Data.MapObj[0].MapHeight)
          num43 = this.game.Data.MapObj[0].MapHeight;
        int num44 = 0;
        do
        {
          int mapCounter2 = this.game.Data.MapCounter;
          for (int index55 = 0; index55 <= mapCounter2; ++index55)
          {
            int num45 = num40;
            int num46 = num41;
            for (int index56 = num45; index56 <= num46; ++index56)
            {
              int num47 = num42;
              int num48 = num43;
              for (int index57 = num47; index57 <= num48; ++index57)
              {
                if (num44 == 0 & num35 > 0)
                {
                  int num49 = 999;
                  int counter2 = orderResult1.CList.counter;
                  for (int index58 = 0; index58 <= counter2; ++index58)
                  {
                    int num50 = this.game.HandyFunctionsObj.Distance(index56, index57, 0, orderResult1.CList.coord[index58].x, orderResult1.CList.coord[index58].y, 0, num35 + 1);
                    if (num50 < num49)
                      num49 = num50;
                  }
                  if (num49 <= num35)
                    orderResult1.CList.AddCoord(index56, index57, 0);
                }
                if (num44 < 4)
                {
                  if (num44 == mapMatrix2Array[index55].Value[index56, index57])
                  {
                    int tfacing = 1;
                    do
                    {
                      Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(index56, index57, index55, tfacing);
                      if (coordinate.onmap && num44 + 1 < mapMatrix2Array[coordinate.map].Value[coordinate.x, coordinate.y])
                      {
                        mapMatrix2Array[coordinate.map].Value[coordinate.x, coordinate.y] = num44 + 1;
                        orderResult1.CList.AddCoord(coordinate.x, coordinate.y, coordinate.map);
                      }
                      ++tfacing;
                    }
                    while (tfacing <= 6);
                  }
                }
                else if (mapMatrix2Array[index55].Value[index56, index57] == 9999)
                {
                  num2 = 0;
                  if (this.game.EditObj.TempValue[index55].Value[index56, index57] < 9999)
                    num2 = 1;
                  int index59 = 0;
                  do
                  {
                    if (this.game.EditObj.TempAttack[index55].Value[index56, index57, index59])
                      num2 = 1;
                    ++index59;
                  }
                  while (index59 <= 5);
                  if (num2 == 1)
                    orderResult1.CList.AddCoord(index56, index57, index55);
                }
              }
            }
          }
          num2 = num2;
          ++num44;
        }
        while (num44 <= 4);
      }
      if (orderResult1.BattleUnit > -1 & (this.game.Data.RegimeObj[this.game.Data.Turn].AI | immediateBattleExecute))
      {
        this.game.TempCombat = new CombatClass(this.game);
        Coordinate Target = new Coordinate();
        Target.x = orderResult1.BattleX;
        Target.y = orderResult1.BattleY;
        Target.map = orderResult1.BattleMap;
        OrderResult orderResult2;
        if (immediateBattleExecute)
          orderResult2 = orderResult1;
        if (orderResult1.BattleIntercept)
        {
          this.game.EditObj.TempUnitList = this.game.HandyFunctionsObj.GetInterceptFireUnits(orderResult1.BattleUnit, orderResult1.BattleX, orderResult1.BattleY);
          orderResult1 = this.game.TempCombat.Init(Target, 1, this.game.EditObj.TempUnitList, 99, tallowHistoryOwnRegime: allowHistoryForOwnRegime);
        }
        else
        {
          this.game.EditObj.TempUnitList = new UnitList();
          this.game.EditObj.TempUnitList.add(orderResult1.BattleUnit);
          orderResult1 = this.game.TempCombat.Init(Target, 1, this.game.EditObj.TempUnitList, 1, tallowHistoryOwnRegime: allowHistoryForOwnRegime);
        }
        this.game.TempCombat.DoBattle();
        this.game.TempCombat.EndBattle();
        this.game.TempCombat = (CombatClass) null;
        if (immediateBattleExecute)
          orderResult1 = orderResult2;
      }
      if (unr > this.game.Data.UnitCounter)
        unr = -1;
      if (unr > -1)
      {
        this.game.ProcessingObj.MaxReadinessRule(unr);
        if (this.game.Data.MapObj[index8].HexObj[x3, y3].CardUponConquest > -1 & (this.game.HandyFunctionsObj.HasUnitlandSF(unr) | this.game.HandyFunctionsObj.HasUnitNavySF(unr)) && regime2 > -1 && this.game.Data.RegimeObj[regime2].AI)
          this.PlayCard(this.game.Data.MapObj[index8].HexObj[x3, y3].CardUponConquest);
      }
      if ((double) this.game.Data.RuleVar[843] > 0.0)
        this.game.EventRelatedObj.DoCheckSpecificEvent((int) Math.Round((double) this.game.Data.RuleVar[843]));
      return orderResult1;
    }

    public object DoDeckCards()
    {
      if ((double) this.game.Data.RuleVar[817] != 1.0)
      {
        int unitCounter = this.game.Data.UnitCounter;
        for (int index1 = 0; index1 <= unitCounter; ++index1)
        {
          if (this.game.Data.UnitObj[index1].Historical > -1 && this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index1].PreDef == -1)
          {
            int historical = this.game.Data.UnitObj[index1].Historical;
            if (this.game.Data.HistoricalUnitObj[historical].DeckCardCounter > -1)
            {
              int deckCardCounter = this.game.Data.HistoricalUnitObj[historical].DeckCardCounter;
              for (int index2 = 0; index2 <= deckCardCounter; ++index2)
              {
                int num1 = this.game.Data.HistoricalUnitObj[historical].DeckCard[index2];
                int num2 = this.game.Data.HistoricalUnitObj[historical].DeckChance[index2];
                if ((double) Conversion.Int(VBMath.Rnd() * 100f) + 1.0 <= (double) num2)
                {
                  int num3 = 1;
                  int handCardCounter = this.game.Data.HistoricalUnitObj[historical].HandCardCounter;
                  for (int index3 = 0; index3 <= handCardCounter; ++index3)
                  {
                    if (this.game.Data.HistoricalUnitObj[historical].HandCard[index3] == num1)
                      num3 = 0;
                  }
                  if (num3 == 1)
                  {
                    HistoricalUnitClass[] historicalUnitObj = this.game.Data.HistoricalUnitObj;
                    HistoricalUnitClass[] historicalUnitClassArray = historicalUnitObj;
                    int index4 = historical;
                    int index5 = index4;
                    historicalUnitClassArray[index5].HandCardCounter = historicalUnitObj[index4].HandCardCounter + 1;
                    this.game.Data.HistoricalUnitObj[historical].HandCard = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[historical].HandCard, (Array) new int[this.game.Data.HistoricalUnitObj[historical].HandCardCounter + 1]);
                    this.game.Data.HistoricalUnitObj[historical].HandCard[this.game.Data.HistoricalUnitObj[historical].HandCardCounter] = num1;
                  }
                }
              }
            }
          }
        }
      }
      object obj;
      return obj;
    }

    public object DoAutoEvents()
    {
      if ((double) this.game.Data.RuleVar[817] != 1.0)
      {
        int unitCounter = this.game.Data.UnitCounter;
        for (int tv2 = 0; tv2 <= unitCounter; ++tv2)
        {
          if (this.game.Data.UnitObj[tv2].Historical > -1 && this.game.Data.UnitObj[tv2].Regime == this.game.Data.Turn && this.game.Data.UnitObj[tv2].PreDef == -1)
          {
            int historical = this.game.Data.UnitObj[tv2].Historical;
            if (this.game.Data.HistoricalUnitObj[historical].AutoEventCounter > -1)
            {
              int autoEventCounter = this.game.Data.HistoricalUnitObj[historical].AutoEventCounter;
              for (int index = 0; index <= autoEventCounter; ++index)
              {
                int enr = this.game.Data.HistoricalUnitObj[historical].AutoEvent[index];
                int num = this.game.Data.HistoricalUnitObj[historical].AutoChance[index];
                if ((double) Conversion.Int(VBMath.Rnd() * 100f) + 1.0 <= (double) num)
                  this.game.EventRelatedObj.DoCheckSpecificEvent(enr, -1, -1, tv2, -1);
              }
            }
          }
        }
      }
      object obj;
      return obj;
    }

    public int EditorMovement(int unr, int x1, int y1, int map1, int x2, int y2, int map2)
    {
      if (!(x1 == x2 & y1 == y2) && !(x1 == -1 | x2 == -1))
      {
        this.game.Data.MapObj[map1].HexObj[x1, y1].RemoveUnitFromList(unr);
        this.game.Data.MapObj[map2].HexObj[x2, y2].AddUnitToList(unr);
        this.game.Data.UnitObj[unr].X = x2;
        this.game.Data.UnitObj[unr].Y = y2;
        this.game.Data.UnitObj[unr].Map = map2;
      }
      int num;
      return num;
    }

    public OrderResult LoadUnit(int Unr, int OnUnr)
    {
      OrderResult orderResult = new OrderResult();
      if (this.game.Data.Turn > -1)
        this.game.HandyFunctionsObj.SetHexReconAndZOCUnitMoves(this.game.Data.UnitObj[Unr].X, this.game.Data.UnitObj[Unr].Y, this.game.Data.UnitObj[Unr].Map, -1, -1, -1, this.game.Data.Turn, Unr);
      this.game.Data.MapObj[this.game.Data.UnitObj[Unr].Map].HexObj[this.game.Data.UnitObj[Unr].X, this.game.Data.UnitObj[Unr].Y].RemoveUnitFromList(Unr);
      this.game.Data.UnitObj[Unr].X = -1;
      this.game.Data.UnitObj[Unr].Y = -1;
      this.game.Data.UnitObj[OnUnr].AddPassenger(Unr);
      this.game.Data.UnitObj[Unr].OnBoard = OnUnr;
      bool flag;
      if (this.game.Data.MapObj[this.game.Data.UnitObj[OnUnr].Map].HexObj[this.game.Data.UnitObj[OnUnr].X, this.game.Data.UnitObj[OnUnr].Y].Location > -1 && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.game.Data.UnitObj[OnUnr].Map].HexObj[this.game.Data.UnitObj[OnUnr].X, this.game.Data.UnitObj[OnUnr].Y].Location].Type].IsPort)
        flag = true;
      orderResult.OK = true;
      if (this.game.Data.UnitObj[Unr].SFCount > -1)
      {
        int sfCount = this.game.Data.UnitObj[Unr].SFCount;
        for (int index = 0; index <= sfCount; ++index)
        {
          int sf = this.game.Data.UnitObj[Unr].SFList[index];
          if ((double) this.game.Data.RuleVar[880] < 1.0 | !flag)
            this.game.Data.SFObj[sf].Ap = 0;
          this.game.Data.SFObj[sf].CurrentEntrench = 0;
          this.game.Data.SFObj[sf].initialEntrench = 0;
          this.game.Data.SFObj[sf].EP = 0;
        }
      }
      if (!flag & (double) this.game.Data.RuleVar[882] > 0.0 && this.game.Data.UnitObj[OnUnr].SFCount > -1)
      {
        int sfCount = this.game.Data.UnitObj[OnUnr].SFCount;
        for (int index = 0; index <= sfCount; ++index)
          this.game.Data.SFObj[this.game.Data.UnitObj[OnUnr].SFList[index]].Ap = 0;
      }
      if ((double) this.game.Data.RuleVar[843] > 0.0)
        this.game.EventRelatedObj.DoCheckSpecificEvent((int) Math.Round((double) this.game.Data.RuleVar[843]));
      return orderResult;
    }

    public OrderResult unLoadUnit(int Unr, int OnUnr, int x, int y, int map)
    {
      OrderResult orderResult = new OrderResult();
      this.game.EditObj.SFSelected = -1;
      int num = 0;
      if (this.game.Data.MapObj[map].HexObj[x, y].Regime != this.game.Data.UnitObj[Unr].Regime && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[Unr].Regime, this.game.Data.MapObj[map].HexObj[x, y].Regime))
      {
        if (this.game.Data.MapObj[map].HexObj[x, y].UnitCounter < 0)
        {
          if ((double) this.game.Data.RuleVar[840] == 1.0 & this.game.Data.MapObj[map].HexObj[x, y].OrigOwner > -1 & this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[Unr].Regime, this.game.Data.MapObj[map].HexObj[x, y].OrigOwner))
          {
            this.game.Data.MapObj[map].HexObj[x, y].set_LastReg(this.game.Data.MapObj[map].HexObj[x, y].Regime, this.game.Data.MapObj[map].HexObj[x, y].OrigOwner);
            this.game.Data.MapObj[map].HexObj[x, y].Regime = this.game.Data.MapObj[map].HexObj[x, y].OrigOwner;
          }
          else
            this.game.Data.MapObj[map].HexObj[x, y].Regime = this.game.Data.RegimeObj[this.game.Data.UnitObj[Unr].Regime].UberRegime <= -1 ? this.game.Data.UnitObj[Unr].Regime : this.game.Data.RegimeObj[this.game.Data.UnitObj[Unr].Regime].UberRegime;
          if (this.game.Data.MapObj[map].HexObj[x, y].Location > -1)
          {
            this.game.Data.LocObj[this.game.Data.MapObj[map].HexObj[x, y].Location].HQ = -1;
            if ((double) this.game.Data.RuleVar[898] > 0.0)
              this.game.Data.LocObj[this.game.Data.MapObj[map].HexObj[x, y].Location].StructuralPts = 0;
            int index = 0;
            do
            {
              this.game.Data.LocObj[this.game.Data.MapObj[map].HexObj[x, y].Location].Production[index] = -1;
              this.game.Data.LocObj[this.game.Data.MapObj[map].HexObj[x, y].Location].ProdPercent[index] = 0;
              this.game.Data.LocObj[this.game.Data.MapObj[map].HexObj[x, y].Location].ProdPointRemainder[index] = 0;
              ++index;
            }
            while (index <= 3);
          }
        }
        else
          num = 1;
      }
      this.game.Data.MapObj[map].HexObj[x, y].AddUnitToList(Unr);
      this.game.Data.UnitObj[OnUnr].RemovePassenger(Unr);
      this.game.Data.UnitObj[Unr].X = x;
      this.game.Data.UnitObj[Unr].Y = y;
      this.game.Data.UnitObj[Unr].Map = map;
      this.game.Data.UnitObj[Unr].OnBoard = -1;
      int sfCount1 = this.game.Data.UnitObj[Unr].SFCount;
      for (int index = 0; index <= sfCount1; ++index)
      {
        if (this.game.Data.Round > 0)
        {
          this.game.Data.SFObj[this.game.Data.UnitObj[Unr].SFList[index]].Ap = 0;
          this.game.Data.SFObj[this.game.Data.UnitObj[Unr].SFList[index]].EP = 0;
        }
      }
      if (!this.game.HandyFunctionsObj.IsHexPort(this.game.Data.UnitObj[OnUnr].X, this.game.Data.UnitObj[OnUnr].Y, 0) && (double) this.game.Data.RuleVar[882] > 0.0 && this.game.Data.UnitObj[OnUnr].SFCount > -1)
      {
        int sfCount2 = this.game.Data.UnitObj[OnUnr].SFCount;
        for (int index = 0; index <= sfCount2; ++index)
        {
          int sf = this.game.Data.UnitObj[OnUnr].SFList[index];
          if (this.game.Data.Round > 0)
            this.game.Data.SFObj[sf].Ap = 0;
        }
      }
      if (num == 0)
      {
        ++this.game.Data.StepNr;
        string infostring = this.game.Data.UnitObj[Unr].Name + " disembarks...";
        int sfCount3 = this.game.Data.UnitObj[Unr].SFCount;
        for (int index = 0; index <= sfCount3; ++index)
        {
          int sf = this.game.Data.UnitObj[Unr].SFList[index];
          this.game.Data.SFObj[sf].CurrentEntrench = this.game.HandyFunctionsObj.GetMinimumEntrench(x, y, map, this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].UnitGroup);
          this.game.Data.SFObj[sf].initialEntrench = this.game.Data.SFObj[sf].CurrentEntrench;
        }
        this.game.HandyFunctionsObj.HistoryAddHex(x, y, map, this.game.Data.UnitObj[Unr].Regime, infostring: infostring);
        if (this.game.Data.MapObj[map].HexObj[x, y].CardUponConquest > -1)
        {
          this.game.EditObj.AreaX = x;
          this.game.EditObj.AreaY = y;
          this.game.EditObj.AreaMap = map;
          if (this.game.Data.RegimeObj[this.game.Data.Turn].AI)
            this.PlayCard(this.game.Data.MapObj[map].HexObj[x, y].CardUponConquest);
          else
            this.game.EditObj.DoCardSlot = this.game.Data.MapObj[map].HexObj[x, y].CardUponConquest;
        }
      }
      this.game.HandyFunctionsObj.SetOnlyReconAround(x, y, map, this.game.Data.UnitObj[Unr].Regime, Unr);
      this.game.HandyFunctionsObj.SetOnlyZOCAround(x, y, map, this.game.Data.UnitObj[Unr].Regime, Unr);
      if (this.game.Data.Turn > -1 && num == 0)
      {
        int mapCounter = this.game.Data.MapCounter;
        for (int map1 = 0; map1 <= mapCounter; ++map1)
        {
          int mapWidth = this.game.Data.MapObj[map1].MapWidth;
          for (int x1 = 0; x1 <= mapWidth; ++x1)
          {
            int mapHeight = this.game.Data.MapObj[map1].MapHeight;
            for (int y1 = 0; y1 <= mapHeight; ++y1)
              this.game.HandyFunctionsObj.DoZOCConquest(x1, y1, map1, this.game.Data.Turn);
          }
        }
      }
      if ((double) this.game.Data.RuleVar[843] > 0.0)
        this.game.EventRelatedObj.DoCheckSpecificEvent((int) Math.Round((double) this.game.Data.RuleVar[843]));
      orderResult.OK = true;
      return orderResult;
    }

    public OrderResult paradropUnit(int Unr, int OnUnr, int x, int y, int map)
    {
      OrderResult orderResult = new OrderResult();
      bool flag = false;
      if (this.game.Data.MapObj[map].HexObj[x, y].Regime == this.game.Data.Turn & this.game.Data.MapObj[this.game.EditObj.OrderMap].HexObj[x, y].Location > -1)
      {
        if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.OrderMap].HexObj[x, y].Location].Type].IsAirfield)
          flag = true;
        if (this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.OrderMap].HexObj[x, y].Location].isAirfield)
          flag = true;
      }
      if (flag)
        this.game.HandyFunctionsObj.MakeMovePrediction(OnUnr, this.game.Data.UnitObj[OnUnr].X, this.game.Data.UnitObj[OnUnr].Y, this.game.Data.UnitObj[OnUnr].Map, false, PredictAirOnly: true, ClearSea: true, ismove: true);
      else
        this.game.HandyFunctionsObj.MakeMovePrediction(OnUnr, this.game.Data.UnitObj[OnUnr].X, this.game.Data.UnitObj[OnUnr].Y, this.game.Data.UnitObj[OnUnr].Map, false, PredictAirOnly: true, ClearSea: true);
      if (this.game.EditObj.TempValue[map].Value[x, y] == 9999)
      {
        orderResult.OK = false;
        orderResult.ErrorString = "Not enough AP";
        return orderResult;
      }
      if (this.game.Data.UnitObj[OnUnr].SFCount > -1)
      {
        int sfCount = this.game.Data.UnitObj[OnUnr].SFCount;
        for (int index1 = 0; index1 <= sfCount; ++index1)
        {
          int sf = this.game.Data.UnitObj[OnUnr].SFList[index1];
          if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater == 2)
          {
            SFClass[] sfObj = this.game.Data.SFObj;
            SFClass[] sfClassArray = sfObj;
            int index2 = sf;
            int index3 = index2;
            sfClassArray[index3].Ap = sfObj[index2].Ap - this.game.EditObj.TempValue[map].Value[x, y];
          }
        }
      }
      ++this.game.Data.StepNr;
      this.game.Data.MapObj[map].HexObj[x, y].AddUnitToList(Unr);
      this.game.Data.MapObj[this.game.Data.UnitObj[Unr].Map].HexObj[this.game.Data.UnitObj[Unr].X, this.game.Data.UnitObj[Unr].Y].RemoveUnitFromList(Unr);
      this.game.HandyFunctionsObj.HistoryAddHex(this.game.Data.UnitObj[Unr].X, this.game.Data.UnitObj[Unr].Y, this.game.Data.UnitObj[Unr].Map, this.game.Data.UnitObj[Unr].Regime);
      this.game.Data.UnitObj[Unr].X = x;
      this.game.Data.UnitObj[Unr].Y = y;
      this.game.Data.UnitObj[Unr].Map = map;
      int sfCount1 = this.game.Data.UnitObj[Unr].SFCount;
      for (int index = 0; index <= sfCount1; ++index)
      {
        this.game.Data.SFObj[this.game.Data.UnitObj[Unr].SFList[index]].Ap = 0;
        this.game.Data.SFObj[this.game.Data.UnitObj[Unr].SFList[index]].EP = 0;
        this.game.Data.SFObj[this.game.Data.UnitObj[Unr].SFList[index]].CurrentEntrench = 0;
        this.game.Data.SFObj[this.game.Data.UnitObj[Unr].SFList[index]].initialEntrench = 0;
      }
      string infostring = this.game.Data.UnitObj[Unr].Name + " paradrops without opposition....";
      this.game.HandyFunctionsObj.HistoryAddHex(x, y, map, this.game.Data.UnitObj[Unr].Regime, infostring: infostring);
      this.game.HandyFunctionsObj.SetHexReconAndZOCAround(x, y, map, this.game.Data.UnitObj[Unr].Regime);
      if ((double) this.game.Data.RuleVar[843] > 0.0)
        this.game.EventRelatedObj.DoCheckSpecificEvent((int) Math.Round((double) this.game.Data.RuleVar[843]));
      orderResult.OK = true;
      return orderResult;
    }

    public OrderResult SetUnitHq(int Unr, int Hqnr, bool recurse = false)
    {
      OrderResult orderResult = new OrderResult();
      if (Unr == Hqnr)
        return orderResult;
      int num1 = 1;
      int num2;
      int num3;
      if (this.game.Data.Round > 0 & (double) this.game.Data.RuleVar[814] != 1.0)
      {
        num2 = this.game.HandyFunctionsObj.ExtraHQSwitchPPCost(Unr, true);
        num3 = this.game.HandyFunctionsObj.ExtraHQSwitchPPCost(Unr, false);
      }
      int howMuchPercentage1;
      int howMuchPercentage2;
      if (this.game.Data.Round > 0 & (double) this.game.Data.RuleVar[907] > 0.0)
      {
        howMuchPercentage1 = this.game.HandyFunctionsObj.AddUnitToHQIsHowMuchPercentage(Hqnr, Unr, true);
        howMuchPercentage2 = this.game.HandyFunctionsObj.AddUnitToHQIsHowMuchPercentage(Hqnr, Unr, false);
      }
      int num4;
      int val1;
      if (!recurse)
      {
        int num5 = 0;
        if (this.game.Data.Turn > -1)
        {
          if (!this.game.Data.RegimeObj[this.game.Data.Turn].AI & this.game.Data.UnitObj[Unr].Historical > -1)
          {
            int index = 0;
            do
            {
              if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[Unr].Historical].SubParts[index] > -1)
                ++num5;
              ++index;
            }
            while (index <= 9);
            if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.HandyFunctionsObj.ExtraHQSwitchPPCost(Unr, true) && num5 > 1 & !this.game.EditObj.TutMode && Interaction.MsgBox((object) "Set for all subunits of unit?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
              num4 = 1;
            if (num4 == 1)
            {
              int unitCounter = this.game.Data.UnitCounter;
              for (int Unr1 = 0; Unr1 <= unitCounter; ++Unr1)
              {
                if (this.game.Data.UnitObj[Unr1].Historical == this.game.Data.UnitObj[Unr].Historical)
                {
                  ++val1;
                  this.SetUnitHq(Unr1, Hqnr, true);
                }
              }
            }
          }
        }
        else if (this.game.Data.Round == 0 & this.game.Data.UnitObj[Unr].Historical > -1)
        {
          int index = 0;
          do
          {
            if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[Unr].Historical].SubParts[index] > -1)
              ++num5;
            ++index;
          }
          while (index <= 9);
          if (num5 > 1 & !this.game.EditObj.TutMode)
          {
            if (Interaction.MsgBox((object) "Set for all subunits of unit?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
              num4 = 1;
          }
          else
            num4 = 1;
          if (num4 == 1)
          {
            int unitCounter = this.game.Data.UnitCounter;
            for (int Unr2 = 0; Unr2 <= unitCounter; ++Unr2)
            {
              if (this.game.Data.UnitObj[Unr2].Historical == this.game.Data.UnitObj[Unr].Historical)
              {
                ++val1;
                this.SetUnitHq(Unr2, Hqnr, true);
              }
            }
          }
        }
      }
      int index1 = Hqnr;
      if ((double) this.game.Data.RuleVar[897] == 0.0)
      {
        while (index1 > -1)
        {
          if (this.game.Data.UnitObj[index1].Historical > -1)
          {
            this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index1].Historical].HandCardCounter = -1;
            this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index1].Historical].HandCard = new int[1];
            index1 = this.game.Data.UnitObj[index1].HQ;
          }
          else
            index1 = -1;
        }
      }
      if (this.game.Data.Turn > -1 && !(this.game.Data.RegimeObj[this.game.Data.Turn].AI & (double) this.game.Data.RuleVar[914] == 1.0) && this.game.Data.Round > 0 & (double) this.game.Data.RuleVar[814] != 1.0)
      {
        if (num4 == 1)
        {
          RegimeClass[] regimeObj = this.game.Data.RegimeObj;
          RegimeClass[] regimeClassArray = regimeObj;
          int turn = this.game.Data.Turn;
          int index2 = turn;
          regimeClassArray[index2].ResPts = regimeObj[turn].ResPts - num2;
        }
        else if (!recurse)
        {
          RegimeClass[] regimeObj = this.game.Data.RegimeObj;
          RegimeClass[] regimeClassArray = regimeObj;
          int turn = this.game.Data.Turn;
          int index3 = turn;
          regimeClassArray[index3].ResPts = regimeObj[turn].ResPts - num3;
        }
      }
      if (this.game.Data.Round > 0 & (double) this.game.Data.RuleVar[907] > 0.0 && Hqnr > -1)
      {
        int historical = this.game.Data.UnitObj[Hqnr].Historical;
        if (historical > -1)
        {
          int hisVarCount = this.game.Data.HistoricalUnitObj[historical].HisVarCount;
          for (int index4 = 0; index4 <= hisVarCount; ++index4)
          {
            if ((double) this.game.Data.HistoricalUnitObj[historical].HisVarType[index4] == (double) this.game.Data.RuleVar[907])
            {
              if (num4 == 1)
              {
                int[] hisVarValue = this.game.Data.HistoricalUnitObj[historical].HisVarValue;
                int[] numArray = hisVarValue;
                int index5 = index4;
                int index6 = index5;
                int num6 = (int) Math.Round((double) hisVarValue[index5] - Math.Max((double) val1, Conversion.Int((double) howMuchPercentage1 / 100.0 * (double) this.game.Data.HistoricalUnitObj[historical].HisVarValue[index4])));
                numArray[index6] = num6;
              }
              else if (!recurse)
              {
                int[] hisVarValue = this.game.Data.HistoricalUnitObj[historical].HisVarValue;
                int[] numArray = hisVarValue;
                int index7 = index4;
                int index8 = index7;
                int num7 = (int) Math.Round((double) hisVarValue[index7] - Math.Max(1.0, Conversion.Int((double) howMuchPercentage2 / 100.0 * (double) this.game.Data.HistoricalUnitObj[historical].HisVarValue[index4])));
                numArray[index8] = num7;
              }
              if (0 > this.game.Data.HistoricalUnitObj[historical].HisVarValue[index4])
                this.game.Data.HistoricalUnitObj[historical].HisVarValue[index4] = 0;
            }
          }
        }
      }
      if (num1 == 1 & (double) this.game.Data.RuleVar[814] != 1.0 && !this.game.Data.UnitObj[Unr].IsHQ)
      {
        if (Hqnr > -1)
        {
          if (this.game.Data.UnitObj[Unr].SFCount > -1 && this.game.Data.UnitObj[Unr].HQ != -1 && this.game.Data.UnitObj[Unr].HQ != Hqnr)
          {
            int sfCount = this.game.Data.UnitObj[Unr].SFCount;
            for (int index9 = 0; index9 <= sfCount; ++index9)
            {
              int sf = this.game.Data.UnitObj[Unr].SFList[index9];
              if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater < 1)
                this.game.Data.SFObj[sf].Rdn = (int) Math.Round((double) ((float) this.game.Data.SFObj[sf].Rdn * this.game.Data.RuleVar[48]));
            }
          }
          if (this.game.Data.Turn > -1 && !this.game.Data.RegimeObj[this.game.Data.Turn].AI && !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
          {
            int staffPoints = this.game.HandyFunctionsObj.GetStaffPoints(Hqnr);
            int groupPowerPoints = this.game.HandyFunctionsObj.GetGroupPowerPoints(Hqnr);
            int num8 = groupPowerPoints + this.game.HandyFunctionsObj.GetPowerPtsAbsolute(Unr, true, false);
            int num9 = num8 - groupPowerPoints;
            if (num8 > staffPoints)
              num9 -= num8 - staffPoints;
            float num10;
            if (num9 > 0 & staffPoints > 0)
            {
              num10 = (float) num9 / (float) staffPoints * this.game.Data.RuleVar[36];
              if ((double) this.game.Data.RuleVar[36] < (double) num10)
                num10 = this.game.Data.RuleVar[36];
            }
            else
              num10 = 0.0f;
            int sfCount = this.game.Data.UnitObj[Hqnr].SFCount;
            for (int index10 = 0; index10 <= sfCount; ++index10)
            {
              int sf = this.game.Data.UnitObj[Hqnr].SFList[index10];
              if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].StaffPts > 0)
              {
                int xp = this.game.Data.SFObj[sf].Xp;
                int num11 = xp;
                int num12 = (int) Math.Round(Math.Ceiling((double) xp * (1.0 - (double) num10)));
                float num13 = (float) ((double) num11 * (1.0 - (double) num10) % 1.0);
                if ((double) num13 > 0.0 && (double) DrawMod.RandyNumber.Next() / 100.0 > (double) num13)
                  --num12;
                if (0 > num12)
                  num12 = 0;
                this.game.Data.SFObj[sf].Xp = num12;
              }
            }
          }
        }
        else if (this.game.Data.UnitObj[Unr].SFCount > -1 && this.game.Data.UnitObj[Unr].HQ != -1 && this.game.Data.UnitObj[Unr].HQ != Hqnr)
        {
          int sfCount = this.game.Data.UnitObj[Unr].SFCount;
          for (int index11 = 0; index11 <= sfCount; ++index11)
          {
            int sf = this.game.Data.UnitObj[Unr].SFList[index11];
            if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater < 1)
              this.game.Data.SFObj[sf].Rdn = (int) Math.Round((double) ((float) this.game.Data.SFObj[sf].Rdn * this.game.Data.RuleVar[48]));
          }
        }
      }
      this.game.Data.UnitObj[Unr].HQ = Hqnr;
      this.game.Data.UnitObj[Unr].DidHQ = true;
      orderResult.OK = true;
      return orderResult;
    }

    public OrderResult SetProdHq(int locnr, int Hqnr)
    {
      OrderResult orderResult = new OrderResult();
      this.game.Data.LocObj[locnr].HQ = Hqnr;
      orderResult.OK = true;
      return orderResult;
    }

    public OrderResult NewUnit(
      int x,
      int y,
      int map,
      bool hq,
      int regime,
      bool WithoutOfficerPlease = false)
    {
      OrderResult orderResult = new OrderResult();
      if (this.game.Data.Round == 0)
      {
        if (this.game.Data.MapObj[map].HexObj[x, y].Regime > -1)
          regime = this.game.Data.MapObj[map].HexObj[x, y].Regime;
        else if (regime == -1)
        {
          orderResult.OK = false;
          return orderResult;
        }
      }
      int index1 = this.game.Data.AddUnit(x, y, map);
      this.game.Data.UnitObj[index1].Regime = regime;
      if (this.game.Data.Round != 0 && !(this.game.Data.RegimeObj[regime].AI & (double) this.game.Data.RuleVar[863] == 1.0) && !(this.game.Data.RegimeObj[regime].AI & (double) this.game.Data.RuleVar[914] == 1.0))
      {
        if (!hq)
        {
          RegimeClass[] regimeObj = this.game.Data.RegimeObj;
          RegimeClass[] regimeClassArray = regimeObj;
          int index2 = regime;
          int index3 = index2;
          regimeClassArray[index3].ResPts = (int) Math.Round((double) ((float) regimeObj[index2].ResPts - this.game.Data.RuleVar[46]));
        }
        if (hq)
        {
          RegimeClass[] regimeObj = this.game.Data.RegimeObj;
          RegimeClass[] regimeClassArray = regimeObj;
          int index4 = regime;
          int index5 = index4;
          regimeClassArray[index5].ResPts = (int) Math.Round((double) ((float) regimeObj[index4].ResPts - this.game.Data.RuleVar[47]));
        }
      }
      this.game.Data.UnitObj[index1].IsHQ = hq;
      this.game.Data.UnitObj[index1].LastSupplyPercent = -1;
      this.game.Data.UnitObj[index1].SODefendPercent = 50;
      this.game.Data.UnitObj[index1].SOSupReqPercent = 100;
      this.game.Data.UnitObj[index1].SOReplacementPercent = 100;
      this.game.Data.UnitObj[index1].SOInterceptRdnStop = 100;
      this.game.Data.UnitObj[index1].SupplyConsume = (double) this.game.Data.RuleVar[434] <= 0.0 ? 0 : 100;
      if (!hq)
      {
        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
        RegimeClass[] regimeClassArray = regimeObj;
        int index6 = regime;
        int index7 = index6;
        regimeClassArray[index7].UnitNumber = regimeObj[index6].UnitNumber + 1;
        string str1 = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[regime].UnitNumber));
        string str2 = (!((this.game.Data.RegimeObj[regime].UnitNumber + 10) % 10 == 1 & (this.game.Data.RegimeObj[regime].UnitNumber + 100) % 100 != 11) ? (!((this.game.Data.RegimeObj[regime].UnitNumber + 10) % 10 == 2 & (this.game.Data.RegimeObj[regime].UnitNumber + 100) % 100 != 12) ? (!((this.game.Data.RegimeObj[regime].UnitNumber + 10) % 10 == 3 & (this.game.Data.RegimeObj[regime].UnitNumber + 100) % 100 != 13) ? str1 + "th" : str1 + "rd") : str1 + "nd") : str1 + "st") + " " + this.game.Data.RegimeObj[regime].UnitName;
        this.game.Data.UnitObj[index1].Name = str2;
      }
      else
      {
        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
        RegimeClass[] regimeClassArray = regimeObj;
        int index8 = regime;
        int index9 = index8;
        regimeClassArray[index9].HQNumber = regimeObj[index8].HQNumber + 1;
        string str3 = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[regime].HQNumber));
        string str4 = (!((this.game.Data.RegimeObj[regime].HQNumber + 10) % 10 == 1 & (this.game.Data.RegimeObj[regime].HQNumber + 100) % 100 != 11) ? (!((this.game.Data.RegimeObj[regime].HQNumber + 10) % 10 == 2 & (this.game.Data.RegimeObj[regime].HQNumber + 100) % 100 != 12) ? (!((this.game.Data.RegimeObj[regime].HQNumber + 10) % 10 == 3 & (this.game.Data.RegimeObj[regime].HQNumber + 100) % 100 != 13) ? str3 + "th" : str3 + "rd") : str3 + "nd") : str3 + "st") + " " + this.game.Data.RegimeObj[regime].HQName;
        this.game.Data.UnitObj[index1].Name = str4;
        if ((double) this.game.Data.RuleVar[343] == 1.0 & !WithoutOfficerPlease & this.game.Data.RegimeObj[regime].OfficerPool > -1)
        {
          this.game.Data.AddHistoricalUnit();
          this.game.Data.UnitObj[index1].Historical = this.game.Data.HistoricalUnitCounter;
          this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].TempRegime = this.game.Data.Turn;
          this.game.ProcessingObj.RecruitOfficer(this.game.Data.Turn, false, this.game.Data.HistoricalUnitCounter);
        }
      }
      orderResult.OK = true;
      orderResult.Data = index1;
      return orderResult;
    }

    public object DoTransfer(
      int unr,
      int unrT,
      int theater,
      int SfNr,
      int Qty,
      bool OwnPower = false,
      bool AddtoHistory = true,
      int byHQ = -1,
      bool MoveMatrixDone = false,
      bool IsDisbandTransfer = false)
    {
      OrderResult orderResult = new OrderResult();
      Coordinate[] coordinateArray = new Coordinate[251];
      this.game.EditObj.SFSelected = -1;
      int index1 = -1;
      this.game.EditObj.TransferLostQty = 0;
      this.game.EditObj.TransferLostType = -1;
      this.game.EditObj.TransferLostTransports = 0;
      if (!OwnPower)
      {
        if (this.game.Data.UnitObj[unr].IsHQ & !this.game.Data.UnitObj[unrT].IsHQ)
          index1 = unr;
        if (!this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unrT].IsHQ)
          index1 = unrT;
        if (this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unrT].IsHQ)
          index1 = unr;
      }
      if (byHQ > -1)
        index1 = byHQ;
      int index2 = SfNr != -2 ? this.game.Data.SFObj[SfNr].Type : -2;
      this.game.HandyFunctionsObj.SetHexReconAndZOCUnitMoves(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, -1, -1, -1, this.game.Data.UnitObj[unr].Regime, unr, false);
      if (this.game.Data.RegimeObj[this.game.Data.Turn].AI & index2 > -1 && !OwnPower)
      {
        int num;
        if (this.game.Data.SFTypeObj[this.game.Data.SFObj[SfNr].Type].Theater == 2)
        {
          if (!MoveMatrixDone)
            this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[unr].Regime, this.game.Data.SFTypeObj[index2].MoveType, 2, this.game.Data.SFObj[SfNr].Ap, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, false, muststartonairfield: false, istransfer: true);
          num = this.game.EditObj.TempValue[this.game.Data.UnitObj[unrT].Map].Value[this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y];
        }
        else if (this.game.Data.SFTypeObj[this.game.Data.SFObj[SfNr].Type].Theater == 1)
        {
          this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[unr].Regime, this.game.Data.SFTypeObj[index2].MoveType, 1, this.game.Data.SFObj[SfNr].Ap, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, false, muststartonairfield: false, istransfer: true);
          num = this.game.EditObj.TempValue[this.game.Data.UnitObj[unrT].Map].Value[this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y];
        }
        else
        {
          if (!MoveMatrixDone)
            this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[unr].Regime, this.game.Data.SFTypeObj[index2].MoveType, this.game.Data.SFTypeObj[index2].Theater, this.game.Data.SFObj[SfNr].Ap, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map);
          num = this.game.EditObj.TempValue[this.game.Data.UnitObj[unrT].Map].Value[this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y];
        }
        if (num <= this.game.Data.SFObj[SfNr].Ap)
        {
          OwnPower = true;
          theater = this.game.Data.SFTypeObj[index2].Theater;
        }
      }
      int num1;
      if (!OwnPower)
      {
        switch (theater)
        {
          case 1:
            if (!MoveMatrixDone)
              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[unr].Regime, (int) Math.Round((double) this.game.Data.RuleVar[1]), 1, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, false);
            num1 = byHQ != unrT ? this.game.EditObj.TempValue[this.game.Data.UnitObj[unrT].Map].Value[this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y] : this.game.EditObj.TempValue[this.game.Data.UnitObj[unrT].Map].Value[this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y];
            break;
          case 2:
            if (!MoveMatrixDone)
              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[unr].Regime, (int) Math.Round((double) this.game.Data.RuleVar[2]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map);
            num1 = byHQ != unrT ? this.game.EditObj.TempValue[this.game.Data.UnitObj[unrT].Map].Value[this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y] : this.game.EditObj.TempValue[this.game.Data.UnitObj[unrT].Map].Value[this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y];
            break;
          default:
            if (!MoveMatrixDone)
              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[unr].Regime, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map);
            num1 = this.game.EditObj.TempValue[this.game.Data.UnitObj[unrT].Map].Value[this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y];
            break;
        }
      }
      else
      {
        theater = this.game.Data.SFTypeObj[index2].Theater;
        if (theater == 2)
        {
          this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[unr].Regime, this.game.Data.SFTypeObj[index2].MoveType, 2, this.game.Data.SFObj[SfNr].Ap, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, false, muststartonairfield: false, istransfer: true, redux: this.game.Data.SFTypeObj[index2].MoveRedux, SFTypeX: index2, SFTypeQty: Qty);
          num1 = this.game.EditObj.TempValue[this.game.Data.UnitObj[unrT].Map].Value[this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y];
        }
        else
        {
          this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[unr].Regime, this.game.Data.SFTypeObj[index2].MoveType, this.game.Data.SFTypeObj[index2].Theater, this.game.Data.SFObj[SfNr].Ap, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, redux: this.game.Data.SFTypeObj[index2].MoveRedux, SFTypeX: index2, SFTypeQty: Qty);
          num1 = this.game.EditObj.TempValue[this.game.Data.UnitObj[unrT].Map].Value[this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y];
        }
      }
      int antiSupply = this.game.HandyFunctionsObj.GetAntiSupply(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y, this.game.Data.UnitObj[unrT].Map);
      int Qty1;
      int num2;
      if (antiSupply > 0 & !OwnPower)
      {
        if (SfNr == -2 | theater == 1 | theater == 0 & (double) this.game.Data.RuleVar[309] == 1.0)
        {
          int num3 = (int) Math.Round(Conversion.Int((double) Qty * ((double) antiSupply / 100.0)));
          if ((double) Qty * ((double) antiSupply / 100.0) % 1.0 > 0.0 && (double) VBMath.Rnd() < (double) antiSupply / 100.0)
            ++num3;
          Qty1 = Qty - num3;
          if (SfNr == -2)
            this.game.HandyFunctionsObj.SetAntiSupplyKills(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y, this.game.Data.UnitObj[unrT].Map, num3, 0, 0);
          else
            this.game.HandyFunctionsObj.SetAntiSupplyKills(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y, this.game.Data.UnitObj[unrT].Map, 0, this.game.Data.SFObj[SfNr].Type, num3);
          this.game.EditObj.TransferLostQty = num3;
          this.game.EditObj.TransferLostType = SfNr != -2 ? this.game.Data.SFObj[SfNr].Type : -2;
        }
        else
        {
          num2 = 0;
          Qty1 = Qty;
        }
      }
      else if (SfNr > -1 & antiSupply > 0 & theater == 1 & OwnPower)
      {
        int qty = (int) Math.Round(Conversion.Int((double) Qty * ((double) antiSupply / 100.0)));
        if ((double) Qty * ((double) antiSupply / 100.0) % 1.0 > 0.0 && (double) VBMath.Rnd() < (double) antiSupply / 100.0)
          ++qty;
        Qty1 = Qty - qty;
        this.game.HandyFunctionsObj.SetAntiSupplyKills(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y, this.game.Data.UnitObj[unrT].Map, 0, this.game.Data.SFObj[SfNr].Type, qty);
        this.game.EditObj.TransferLostQty = qty;
        this.game.EditObj.TransferLostType = this.game.Data.SFObj[SfNr].Type;
      }
      else
      {
        num2 = 0;
        Qty1 = Qty;
      }
      int num4;
      int num5;
      int people;
      int Xp;
      int Rdn;
      int mor;
      int Ep;
      int Ap;
      int offMod;
      int defMod;
      int moveType;
      int entr;
      int theater1;
      int supplyConsume;
      if (SfNr == -2)
      {
        num4 = (int) Math.Round((double) Conversion.Int((float) (num1 * Qty) * this.game.Data.RuleVar[33]));
        num5 = num4;
      }
      else
      {
        people = this.game.Data.SFObj[SfNr].People;
        Xp = this.game.Data.SFObj[SfNr].Xp;
        if (IsDisbandTransfer)
          Xp = (int) Math.Round((double) ((float) Xp * this.game.Data.RuleVar[926]));
        Rdn = this.game.Data.SFObj[SfNr].Rdn;
        mor = this.game.Data.SFObj[SfNr].Mor;
        Ep = (int) Math.Round(Conversion.Int((double) this.game.Data.SFObj[SfNr].EP * ((double) Qty / (double) this.game.Data.SFObj[SfNr].Qty)));
        SFClass[] sfObj = this.game.Data.SFObj;
        SFClass[] sfClassArray = sfObj;
        int index3 = SfNr;
        int index4 = index3;
        sfClassArray[index4].EP = sfObj[index3].EP - Ep;
        Ap = this.game.Data.SFObj[SfNr].Ap;
        offMod = this.game.Data.SFObj[SfNr].OffMod;
        defMod = this.game.Data.SFObj[SfNr].DefMod;
        moveType = this.game.Data.SFObj[SfNr].MoveType;
        if (this.game.Data.UnitObj[unr].X == this.game.Data.UnitObj[unrT].X & this.game.Data.UnitObj[unr].Y == this.game.Data.UnitObj[unrT].Y)
        {
          entr = this.game.Data.SFObj[SfNr].CurrentEntrench;
        }
        else
        {
          entr = this.game.HandyFunctionsObj.GetMinimumEntrench(this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y, this.game.Data.UnitObj[unrT].Map, this.game.Data.SFTypeObj[this.game.Data.SFObj[SfNr].Type].UnitGroup);
          if (OwnPower)
          {
            Ap -= num1;
            if (0 > Ap)
              Ap = 0;
          }
          else
          {
            Ep = 0;
            Ap = 0;
          }
        }
        int weight = this.game.Data.SFTypeObj[index2].Weight;
        theater1 = this.game.Data.SFTypeObj[index2].Theater;
        num4 = Conversion.Int(num1 * Qty * weight);
        supplyConsume = this.game.Data.UnitObj[unr].SupplyConsume;
        if (theater == 1 & this.game.Data.SFTypeObj[this.game.Data.SFObj[SfNr].Type].Theater == 1 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.Data.UnitObj[unrT].Map].HexObj[this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y].LandscapeType].IsSea)
          num4 = 0;
        num5 = num4;
      }
      if (SfNr == -2)
      {
        UnitClass[] unitObj1 = this.game.Data.UnitObj;
        UnitClass[] unitClassArray1 = unitObj1;
        int index5 = unrT;
        int index6 = index5;
        unitClassArray1[index6].Supply = unitObj1[index5].Supply + Qty1;
        UnitClass[] unitObj2 = this.game.Data.UnitObj;
        UnitClass[] unitClassArray2 = unitObj2;
        int index7 = unr;
        int index8 = index7;
        unitClassArray2[index8].Supply = unitObj2[index7].Supply - Qty;
      }
      else
      {
        int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
        int num6;
        for (int index9 = 0; index9 <= sfCount1; ++index9)
        {
          int sf = this.game.Data.UnitObj[unr].SFList[index9];
          num6 += Conversion.Int(this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].SupplyCarry * this.game.Data.SFObj[sf].Qty);
        }
        int num7 = this.game.Data.SFTypeObj[index2].SupplyCarry * Qty;
        int num8;
        if (num6 > 0)
          num8 = (int) Math.Round(Conversion.Int((double) this.game.Data.UnitObj[unr].Supply * ((double) num7 / (double) num6)));
        if (num8 > num7)
          num8 = num7;
        this.game.HandyFunctionsObj.RemoveTroops(unr, index2, people, Qty, moveType);
        UnitClass[] unitObj3 = this.game.Data.UnitObj;
        UnitClass[] unitClassArray3 = unitObj3;
        int index10 = unr;
        int index11 = index10;
        unitClassArray3[index11].Supply = unitObj3[index10].Supply - num8;
        if (Qty1 > 0)
        {
          bool flag = false;
          if (this.game.Data.UnitObj[unrT].HQ == this.game.Data.UnitObj[unr].HQ | this.game.Data.UnitObj[unr].HQ == unrT | this.game.Data.UnitObj[unrT].HQ == unr)
            flag = true;
          if (this.game.Data.SFTypeObj[index2].StaffPts > 0 & this.game.Data.UnitObj[unrT].IsHQ)
            flag = false;
          if (this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unrT].IsHQ)
            flag = false;
          if (Strings.InStr(this.game.Data.UnitObj[unrT].Name, "326.Pi") > 0)
            unr = unr;
          if (flag)
          {
            if (theater1 == 0)
              Rdn = (int) Math.Round((double) ((float) Rdn * this.game.Data.RuleVar[49]));
            this.game.HandyFunctionsObj.AddTroops3(unrT, index2, people, Qty1, Xp, Rdn, Ap, mor, supplyConsume, entr, offMod, defMod, moveType, Ep);
          }
          else
          {
            if (theater1 == 0)
              Rdn = (int) Math.Round((double) ((float) Rdn * this.game.Data.RuleVar[50]));
            int unr1 = this.game.Data.UnitObj[unrT].HQ;
            if (this.game.Data.UnitObj[unrT].IsHQ)
              unr1 = unrT;
            int staffPercent1;
            if (unr1 > -1)
              staffPercent1 = this.game.HandyFunctionsObj.GetStaffPercent(unr1);
            if (unr1 > -1 & !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
            {
              if (this.game.Data.SFTypeObj[index2].StaffPts > 0 & this.game.Data.UnitObj[unrT].IsHQ)
              {
                int staffPercent2 = this.game.HandyFunctionsObj.GetStaffPercent(unr1, additionalstaffpts: (this.game.Data.SFTypeObj[index2].StaffPts * Qty1));
                float num9;
                if (staffPercent2 <= 100)
                  num9 = this.game.Data.RuleVar[36];
                else if (staffPercent1 > 99)
                {
                  num9 = 0.0f;
                }
                else
                {
                  int num10 = staffPercent2 - staffPercent1;
                  num9 = this.game.Data.RuleVar[36] * (float) (1.0 - (double) (staffPercent2 - 100) / (double) num10);
                }
                int num11 = Xp;
                Xp = (int) Math.Round(Math.Ceiling((double) Xp * (1.0 - (double) num9)));
                float num12 = (float) ((double) num11 * (1.0 - (double) num9) % 1.0);
                if ((double) num12 > 0.0)
                {
                  if ((double) DrawMod.RandyNumber.Next(0, 100) / 100.0 > (double) num12)
                    --Xp;
                  if (0 > Xp)
                    Xp = 0;
                }
              }
              else if (this.game.Data.SFTypeObj[index2].StaffPts < 1)
              {
                int staffPoints = this.game.HandyFunctionsObj.GetStaffPoints(unr1);
                int groupPowerPoints = this.game.HandyFunctionsObj.GetGroupPowerPoints(unr1);
                int num13 = this.game.Data.SFTypeObj[index2].Theater != 0 ? groupPowerPoints : groupPowerPoints + this.game.Data.SFTypeObj[index2].PowerPts * Qty1;
                int num14 = num13 - groupPowerPoints;
                if (num13 > staffPoints)
                  num14 -= num13 - staffPoints;
                float num15;
                if (num14 > 0 & staffPoints > 0)
                {
                  num15 = (float) num14 / (float) staffPoints * this.game.Data.RuleVar[36];
                  if ((double) this.game.Data.RuleVar[36] < (double) num15)
                    num15 = this.game.Data.RuleVar[36];
                }
                else
                  num15 = 0.0f;
                int sfCount2 = this.game.Data.UnitObj[unr1].SFCount;
                for (int index12 = 0; index12 <= sfCount2; ++index12)
                {
                  int sf = this.game.Data.UnitObj[unr1].SFList[index12];
                  if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].StaffPts > 0)
                  {
                    int xp = this.game.Data.SFObj[sf].Xp;
                    int num16 = xp;
                    int num17 = (int) Math.Round(Math.Ceiling((double) xp * (1.0 - (double) num15)));
                    float num18 = (float) ((double) num16 * (1.0 - (double) num15) % 1.0);
                    if ((double) num18 > 0.0 && (double) DrawMod.RandyNumber.Next(0, 100) / 100.0 > (double) num18)
                      --num17;
                    if (0 > num17)
                      num17 = 0;
                    this.game.Data.SFObj[sf].Xp = num17;
                  }
                }
              }
            }
            this.game.HandyFunctionsObj.AddTroops3(unrT, index2, people, Qty1, Xp, Rdn, Ap, mor, supplyConsume, entr, offMod, defMod, moveType, Ep);
          }
          this.game.Data.UnitObj[unr].LastAP = -1;
          this.game.Data.UnitObj[unrT].LastAP = -1;
          this.game.Data.UnitObj[unrT].FreeCombatX = -1;
          this.game.Data.UnitObj[unrT].FreeCombatY = -1;
          UnitClass[] unitObj4 = this.game.Data.UnitObj;
          UnitClass[] unitClassArray4 = unitObj4;
          int index13 = unrT;
          int index14 = index13;
          unitClassArray4[index14].Supply = (int) Math.Round((double) unitObj4[index13].Supply + (double) num8 * ((double) Qty1 / (double) Qty));
        }
        if (AddtoHistory)
        {
          ++this.game.Data.StepNr;
          string infostring;
          if (this.game.Data.FOWOn)
            infostring = "Transfer";
          else
            infostring = "Transferred " + Conversion.Str((object) Qty) + "x " + this.game.Data.SFTypeObj[index2].Name + " to " + this.game.Data.UnitObj[unrT].Name + ".";
          this.game.HandyFunctionsObj.HistoryAddHex(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, this.game.Data.UnitObj[unr].Regime, 2, 0, unr, infostring: infostring);
          this.game.HandyFunctionsObj.HistoryAddHex(this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y, this.game.Data.UnitObj[unrT].Map, this.game.Data.UnitObj[unr].Regime, 2, 0, unrT, infostring: infostring);
        }
      }
      if (!OwnPower && antiSupply > 0 & num4 > 0)
        this.game.EditObj.TransferLostTransports = this.game.HandyFunctionsObj.DoDestroyTransporters(unr, theater, (int) Math.Round((double) num4 * ((double) antiSupply / 100.0)), this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y, this.game.Data.UnitObj[unrT].Map);
      if (index1 > -1 & !OwnPower)
      {
        switch (theater)
        {
          case 0:
            this.game.Data.UnitObj[index1].LandCap -= num4;
            break;
          case 1:
            this.game.Data.UnitObj[index1].NavyCap -= num4;
            break;
          case 2:
            this.game.Data.UnitObj[index1].AirCap -= num4;
            break;
        }
      }
      int map = this.game.Data.UnitObj[unrT].Map;
      if (!this.game.Data.RegimeObj[this.game.Data.Turn].AI)
      {
        if (OwnPower)
        {
          if ((double) this.game.Data.RuleVar[886] == 0.0 && this.game.Data.SFTypeObj[index2].FuelForMove > 0 & this.game.Data.SFTypeObj[index2].FuelRegimeVar > -1)
          {
            if ((double) this.game.Data.RuleVar[435] > 0.0)
            {
              int num19 = (int) Math.Round((double) this.game.Data.SFTypeObj[index2].FuelForMove * ((double) this.game.EditObj.TempValue[map].Value[this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y] / 10.0));
              if (this.game.Data.SFTypeObj[index2].FuelForMove > num19 & this.game.EditObj.TempValue[map].Value[this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y] > 0)
                num19 = this.game.Data.SFTypeObj[index2].FuelForMove;
              int num20 = num19 * this.game.Data.SFObj[SfNr].Qty;
              UnitClass[] unitObj5 = this.game.Data.UnitObj;
              UnitClass[] unitClassArray5 = unitObj5;
              int index15 = unr;
              int index16 = index15;
              unitClassArray5[index16].Fuel = unitObj5[index15].Fuel - num20;
              if (0 > this.game.Data.UnitObj[unr].Fuel)
                this.game.Data.UnitObj[unr].Fuel = 0;
              UnitClass[] unitObj6 = this.game.Data.UnitObj;
              UnitClass[] unitClassArray6 = unitObj6;
              int index17 = unr;
              int index18 = index17;
              unitClassArray6[index18].FuelUsedMove = unitObj6[index17].FuelUsedMove + num20;
            }
            else
            {
              int currentSlot = this.game.Data.SFTypeObj[index2].FuelRegimeVar;
              if ((double) this.game.Data.RuleVar[949] > 0.0)
                currentSlot = this.game.HandyFunctionsObj.GetFuelSlot949(currentSlot, this.game.Data.UnitObj[index1].RealX(ref this.game), this.game.Data.UnitObj[index1].RealY(ref this.game));
              int num21 = (int) Math.Round((double) this.game.Data.SFTypeObj[index2].FuelForMove * ((double) this.game.EditObj.TempValue[map].Value[this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y] / 10.0));
              if (this.game.Data.SFTypeObj[index2].FuelForMove > num21 & this.game.EditObj.TempValue[map].Value[this.game.Data.UnitObj[unrT].X, this.game.Data.UnitObj[unrT].Y] > 0)
                num21 = this.game.Data.SFTypeObj[index2].FuelForMove;
              int num22 = num21 * Qty;
              if (this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].RegimeSlot[currentSlot] >= num22)
              {
                int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].RegimeSlot;
                int[] numArray1 = regimeSlot;
                int index19 = currentSlot;
                int index20 = index19;
                int num23 = regimeSlot[index19] - num22;
                numArray1[index20] = num23;
                int[] regimeSlotPredict = this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].TempRegimeSlotPredict;
                int[] numArray2 = regimeSlotPredict;
                int index21 = currentSlot;
                int index22 = index21;
                int num24 = regimeSlotPredict[index21] - num22;
                numArray2[index22] = num24;
                UnitClass[] unitObj = this.game.Data.UnitObj;
                UnitClass[] unitClassArray = unitObj;
                int index23 = unr;
                int index24 = index23;
                unitClassArray[index24].FuelUsedMove = unitObj[index23].FuelUsedMove + num22;
              }
              else
              {
                int num25 = this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].RegimeSlot[currentSlot];
                int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].RegimeSlot;
                int[] numArray3 = regimeSlot;
                int index25 = currentSlot;
                int index26 = index25;
                int num26 = regimeSlot[index25] - num25;
                numArray3[index26] = num26;
                int[] regimeSlotPredict = this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].TempRegimeSlotPredict;
                int[] numArray4 = regimeSlotPredict;
                int index27 = currentSlot;
                int index28 = index27;
                int num27 = regimeSlotPredict[index27] - num25;
                numArray4[index28] = num27;
                UnitClass[] unitObj = this.game.Data.UnitObj;
                UnitClass[] unitClassArray = unitObj;
                int index29 = unr;
                int index30 = index29;
                unitClassArray[index30].FuelUsedMove = unitObj[index29].FuelUsedMove + num25;
              }
            }
          }
        }
        else
        {
          if ((double) this.game.Data.RuleVar[852] > 0.0 & theater == 0 & num4 > 0)
          {
            int num28 = (int) Math.Round((double) Math.Max(1f, Conversion.Int((float) (int) Math.Round((double) num4 / 1000.0) * this.game.Data.RuleVar[852])));
            float fuelSlot949 = this.game.Data.RuleVar[851];
            if ((double) this.game.Data.RuleVar[949] > 0.0)
              fuelSlot949 = (float) this.game.HandyFunctionsObj.GetFuelSlot949((int) Math.Round((double) fuelSlot949), this.game.Data.UnitObj[index1].RealX(ref this.game), this.game.Data.UnitObj[index1].RealY(ref this.game));
            int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
            int[] numArray = regimeSlot;
            int index31 = (int) Math.Round((double) fuelSlot949);
            int index32 = index31;
            int num29 = regimeSlot[index31] - num28;
            numArray[index32] = num29;
          }
          if ((double) this.game.Data.RuleVar[854] > 0.0 & theater == 1 & num4 > 0)
          {
            int num30 = (int) Math.Round((double) Math.Max(1f, Conversion.Int((float) (int) Math.Round((double) num4 / 1000.0) * this.game.Data.RuleVar[854])));
            float fuelSlot949 = this.game.Data.RuleVar[851];
            if ((double) this.game.Data.RuleVar[949] > 0.0)
              fuelSlot949 = (float) this.game.HandyFunctionsObj.GetFuelSlot949((int) Math.Round((double) fuelSlot949), this.game.Data.UnitObj[index1].RealX(ref this.game), this.game.Data.UnitObj[index1].RealY(ref this.game));
            int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
            int[] numArray = regimeSlot;
            int index33 = (int) Math.Round((double) fuelSlot949);
            int index34 = index33;
            int num31 = regimeSlot[index33] - num30;
            numArray[index34] = num31;
          }
          if ((double) this.game.Data.RuleVar[856] > 0.0 & theater == 0 & num4 > 0)
          {
            int num32 = (int) Math.Round((double) Math.Max(1f, Conversion.Int((float) (int) Math.Round((double) num4 / 1000.0) * this.game.Data.RuleVar[856])));
            float fuelSlot949 = this.game.Data.RuleVar[851];
            if ((double) this.game.Data.RuleVar[949] > 0.0)
              fuelSlot949 = (float) this.game.HandyFunctionsObj.GetFuelSlot949((int) Math.Round((double) fuelSlot949), this.game.Data.UnitObj[index1].RealX(ref this.game), this.game.Data.UnitObj[index1].RealY(ref this.game));
            int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
            int[] numArray = regimeSlot;
            int index35 = (int) Math.Round((double) this.game.Data.RuleVar[(int) Math.Round((double) fuelSlot949)]);
            int index36 = index35;
            int num33 = regimeSlot[index35] - num32;
            numArray[index36] = num33;
          }
        }
      }
      this.game.ProcessingObj.MaxReadinessRule(unrT);
      int sfCount = this.game.Data.UnitObj[unr].SFCount;
      int num34;
      int num35;
      int num36;
      for (int index37 = 0; index37 <= sfCount; ++index37)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index37];
        int type = this.game.Data.SFObj[sf].Type;
        int qty = this.game.Data.SFObj[sf].Qty;
        int theater2 = this.game.Data.SFTypeObj[type].Theater;
        if (theater2 == 0)
          num34 += this.game.Data.SFTypeObj[type].Cap * qty;
        if (theater2 == 1)
          num35 += this.game.Data.SFTypeObj[type].Cap * qty;
        num36 += this.game.Data.SFTypeObj[type].RailCap * qty;
      }
      if (this.game.Data.UnitObj[unr].LandCap > num34)
        this.game.Data.UnitObj[unr].LandCap = num34;
      if (this.game.Data.UnitObj[unr].AirCap > num36)
        this.game.Data.UnitObj[unr].AirCap = num36;
      if (this.game.Data.UnitObj[unr].NavyCap > num35)
        this.game.Data.UnitObj[unr].NavyCap = num35;
      this.game.HandyFunctionsObj.SetHexReconAndZOCUnitMoves(-1, -1, 0, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, this.game.Data.UnitObj[unr].Regime, unr, false);
      if ((double) this.game.Data.RuleVar[843] > 0.0)
        this.game.EventRelatedObj.DoCheckSpecificEvent((int) Math.Round((double) this.game.Data.RuleVar[843]));
      this.LocationProductionPrognosis();
      orderResult.OK = true;
      return (object) orderResult;
    }

    public object DoStrategicTransfer(
      int unrH,
      int unrS,
      int theater,
      int tarx,
      int tary,
      int tarmap)
    {
      OrderResult orderResult = new OrderResult();
      Coordinate[] coordinateArray = new Coordinate[251];
      if (this.game.HandyFunctionsObj.VisibleEnemyUnitsInHex(tarx, tary, 0, 1, true))
      {
        int num1 = num1;
      }
      if (this.game.Data.RegimeObj[this.game.Data.Turn].AI)
      {
        this.game.EditObj.TransferLostQty = 0;
        this.game.EditObj.TransferLostType = -1;
        this.game.EditObj.TransferLostTransports = 0;
      }
      int num2;
      if (!(this.game.Data.RegimeObj[this.game.Data.Turn].AI & (double) this.game.Data.RuleVar[253] == 1.0))
      {
        int num3;
        if ((double) this.game.Data.RuleVar[350] == 0.0)
        {
          switch (theater)
          {
            case 1:
              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[unrH].Regime, (int) Math.Round((double) this.game.Data.RuleVar[1]), 1, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[unrH].X, this.game.Data.UnitObj[unrH].Y, this.game.Data.UnitObj[unrH].Map);
              num3 = this.game.EditObj.TempValue[tarmap].Value[tarx, tary] + this.game.EditObj.TempValue[this.game.Data.UnitObj[unrS].Map].Value[this.game.Data.UnitObj[unrS].X, this.game.Data.UnitObj[unrS].Y];
              break;
            case 2:
              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[unrH].Regime, (int) Math.Round((double) this.game.Data.RuleVar[2]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[unrH].X, this.game.Data.UnitObj[unrH].Y, this.game.Data.UnitObj[unrH].Map);
              num3 = this.game.EditObj.TempValue[tarmap].Value[tarx, tary] + this.game.EditObj.TempValue[this.game.Data.UnitObj[unrS].Map].Value[this.game.Data.UnitObj[unrS].X, this.game.Data.UnitObj[unrS].Y];
              break;
            default:
              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[unrH].Regime, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[unrH].X, this.game.Data.UnitObj[unrH].Y, this.game.Data.UnitObj[unrH].Map);
              num3 = this.game.EditObj.TempValue[tarmap].Value[tarx, tary] + this.game.EditObj.TempValue[this.game.Data.UnitObj[unrS].Map].Value[this.game.Data.UnitObj[unrS].X, this.game.Data.UnitObj[unrS].Y];
              break;
          }
        }
        else
        {
          switch (theater)
          {
            case 1:
              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[unrH].Regime, (int) Math.Round((double) this.game.Data.RuleVar[1]), 1, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[unrS].X, this.game.Data.UnitObj[unrS].Y, this.game.Data.UnitObj[unrS].Map);
              num3 = this.game.EditObj.TempValue[tarmap].Value[tarx, tary];
              break;
            case 2:
              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[unrH].Regime, (int) Math.Round((double) this.game.Data.RuleVar[2]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[unrS].X, this.game.Data.UnitObj[unrS].Y, this.game.Data.UnitObj[unrS].Map);
              num3 = this.game.EditObj.TempValue[tarmap].Value[tarx, tary];
              break;
            default:
              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[unrH].Regime, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), this.game.Data.UnitObj[unrS].X, this.game.Data.UnitObj[unrS].Y, this.game.Data.UnitObj[unrS].Map);
              num3 = this.game.EditObj.TempValue[tarmap].Value[tarx, tary];
              break;
          }
        }
        num2 = Conversion.Int((int) Math.Round((double) ((float) num3 + this.game.Data.RuleVar[351])) * this.game.HandyFunctionsObj.GetUnitWeight(unrS, true));
        int num4;
        int num5;
        if (theater == 1 | theater == 0 & (double) this.game.Data.RuleVar[309] == 1.0)
        {
          int antiSupply1 = this.game.HandyFunctionsObj.GetAntiSupply(this.game.Data.UnitObj[unrH].X, this.game.Data.UnitObj[unrH].Y, this.game.Data.UnitObj[unrH].Map, tarx, tary, tarmap);
          num4 = antiSupply1;
          if (antiSupply1 > 0)
            this.game.EditObj.TransferLostQty = this.game.HandyFunctionsObj.DoDestroyRandom(unrS, -1, antiSupply1, this.game.Data.UnitObj[unrH].X, this.game.Data.UnitObj[unrH].Y, this.game.Data.UnitObj[unrH].Map, tarx, tary, tarmap);
          int antiSupply2 = this.game.HandyFunctionsObj.GetAntiSupply(this.game.Data.UnitObj[unrH].X, this.game.Data.UnitObj[unrH].Y, this.game.Data.UnitObj[unrH].Map, this.game.Data.UnitObj[unrS].X, this.game.Data.UnitObj[unrS].Y, this.game.Data.UnitObj[unrS].Map);
          num5 = antiSupply2;
          if (antiSupply2 > 0)
            this.game.EditObj.TransferLostQty = this.game.HandyFunctionsObj.DoDestroyRandom(unrS, -1, antiSupply2, this.game.Data.UnitObj[unrH].X, this.game.Data.UnitObj[unrH].Y, this.game.Data.UnitObj[unrH].Map, this.game.Data.UnitObj[unrS].X, this.game.Data.UnitObj[unrS].Y, this.game.Data.UnitObj[unrS].Map);
        }
        switch (theater)
        {
          case 0:
            this.game.Data.UnitObj[unrH].LandCap -= num2;
            break;
          case 1:
            this.game.Data.UnitObj[unrH].NavyCap -= num2;
            break;
          case 2:
            this.game.Data.UnitObj[unrH].AirCap -= num2;
            break;
        }
        if (num4 > 0)
          this.game.EditObj.TransferLostTransports = this.game.HandyFunctionsObj.DoDestroyTransporters(unrH, theater, (int) Math.Round(Conversion.Int((double) num2 * ((double) num4 / 100.0))), this.game.Data.UnitObj[unrH].X, this.game.Data.UnitObj[unrH].Y, this.game.Data.UnitObj[unrH].Map, tarx, tary, tarmap);
        if (num5 > 0)
          this.game.EditObj.TransferLostTransports += this.game.HandyFunctionsObj.DoDestroyTransporters(unrH, theater, (int) Math.Round(Conversion.Int((double) num2 * ((double) num5 / 100.0))), this.game.Data.UnitObj[unrH].X, this.game.Data.UnitObj[unrH].Y, this.game.Data.UnitObj[unrH].Map, this.game.Data.UnitObj[unrS].X, this.game.Data.UnitObj[unrS].Y, this.game.Data.UnitObj[unrS].Map);
      }
      this.game.Data.MapObj[this.game.Data.UnitObj[unrS].Map].HexObj[this.game.Data.UnitObj[unrS].X, this.game.Data.UnitObj[unrS].Y].RemoveUnitFromList(unrS);
      int x = this.game.Data.UnitObj[unrS].X;
      int y = this.game.Data.UnitObj[unrS].Y;
      int map = this.game.Data.UnitObj[unrS].Map;
      this.game.Data.UnitObj[unrS].X = tarx;
      this.game.Data.UnitObj[unrS].Y = tary;
      this.game.Data.UnitObj[unrS].Map = tarmap;
      this.game.Data.MapObj[tarmap].HexObj[tarx, tary].AddUnitToList(unrS);
      this.game.HandyFunctionsObj.SetHexReconAndZOCUnitMoves(x, y, map, -1, -1, -1, this.game.Data.UnitObj[unrS].Regime, unrS, false);
      if (this.game.EventRelatedObj.Helper_AirEnabled())
      {
        int historical = this.game.Data.UnitObj[unrS].Historical;
        if (historical > -1)
        {
          this.game.Data.HistoricalUnitObj[historical].SetHisVarValue(55, 0);
          this.game.Data.HistoricalUnitObj[historical].SetHisVarValue(56, 0);
          this.game.Data.HistoricalUnitObj[historical].SetHisVarValue(57, 0);
          this.game.Data.HistoricalUnitObj[historical].SetHisVarValue(58, 0);
          this.game.Data.HistoricalUnitObj[historical].SetHisVarValue(59, 0);
        }
      }
      ++this.game.Data.StepNr;
      this.game.HandyFunctionsObj.HistoryAddHex(x, y, map, this.game.Data.UnitObj[unrS].Regime, infostring: "Strategic Transfer...");
      this.game.HandyFunctionsObj.HistoryAddHex(tarx, tary, tarmap, this.game.Data.UnitObj[unrS].Regime, infostring: "Strategic Transfer...");
      if (this.game.Data.UnitObj[unrS].SFCount > -1)
      {
        int sfCount = this.game.Data.UnitObj[unrS].SFCount;
        for (int index = 0; index <= sfCount; ++index)
        {
          int sf = this.game.Data.UnitObj[unrS].SFList[index];
          this.game.Data.SFObj[sf].Ap = 0;
          this.game.Data.SFObj[sf].EP = 0;
          this.game.Data.SFObj[sf].CurrentEntrench = this.game.HandyFunctionsObj.GetMinimumEntrench(tarx, tary, tarmap, this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].UnitGroup);
          this.game.Data.SFObj[sf].initialEntrench = this.game.Data.SFObj[sf].CurrentEntrench;
          this.game.Data.SFObj[sf].Rdn = (int) Math.Round((double) ((float) this.game.Data.SFObj[sf].Rdn * this.game.Data.RuleVar[131]));
        }
      }
      this.game.Data.UnitObj[unrS].Spotted = true;
      this.game.Data.UnitObj[unrS].Identified = true;
      this.game.Data.UnitObj[unrS].LandCap = 0;
      this.game.Data.UnitObj[unrS].NavyCap = 0;
      this.game.Data.UnitObj[unrS].AirCap = 0;
      this.game.Data.UnitObj[unrS].FreeCombatX = -1;
      this.game.Data.UnitObj[unrS].FreeCombatY = -1;
      this.game.ProcessingObj.MaxReadinessRule(unrS);
      if (this.game.Data.MapObj[tarmap].HexObj[tarx, tary].CardUponConquest > -1)
      {
        this.game.EditObj.AreaX = tarx;
        this.game.EditObj.AreaY = tary;
        this.game.EditObj.AreaMap = tarmap;
        if (this.game.Data.RegimeObj[this.game.Data.Turn].AI)
          this.PlayCard(this.game.Data.MapObj[map].HexObj[x, y].CardUponConquest);
        else
          this.game.EditObj.DoCardSlot = this.game.Data.MapObj[map].HexObj[x, y].CardUponConquest;
      }
      if (!this.game.Data.RegimeObj[this.game.Data.Turn].AI)
      {
        if ((double) this.game.Data.RuleVar[852] > 0.0 & theater == 0 & num2 > 0)
        {
          int num6 = (int) Math.Round((double) Math.Max(1f, Conversion.Int((float) (int) Math.Round((double) num2 / 1000.0) * this.game.Data.RuleVar[852])));
          float fuelSlot949 = this.game.Data.RuleVar[851];
          if ((double) this.game.Data.RuleVar[949] > 0.0)
            fuelSlot949 = (float) this.game.HandyFunctionsObj.GetFuelSlot949((int) Math.Round((double) fuelSlot949), this.game.Data.UnitObj[unrH].RealX(ref this.game), this.game.Data.UnitObj[unrH].RealY(ref this.game));
          int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
          int[] numArray = regimeSlot;
          int index1 = (int) Math.Round((double) fuelSlot949);
          int index2 = index1;
          int num7 = regimeSlot[index1] - num6;
          numArray[index2] = num7;
        }
        if ((double) this.game.Data.RuleVar[854] > 0.0 & theater == 1 & num2 > 0)
        {
          int num8 = (int) Math.Round((double) Math.Max(1f, Conversion.Int((float) (int) Math.Round((double) num2 / 1000.0) * this.game.Data.RuleVar[854])));
          float fuelSlot949 = this.game.Data.RuleVar[851];
          if ((double) this.game.Data.RuleVar[949] > 0.0)
            fuelSlot949 = (float) this.game.HandyFunctionsObj.GetFuelSlot949((int) Math.Round((double) fuelSlot949), this.game.Data.UnitObj[unrH].RealX(ref this.game), this.game.Data.UnitObj[unrH].RealY(ref this.game));
          int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
          int[] numArray = regimeSlot;
          int index3 = (int) Math.Round((double) fuelSlot949);
          int index4 = index3;
          int num9 = regimeSlot[index3] - num8;
          numArray[index4] = num9;
        }
        if ((double) this.game.Data.RuleVar[856] > 0.0 & theater == 0 & num2 > 0)
        {
          int num10 = (int) Math.Round((double) Math.Max(1f, Conversion.Int((float) (int) Math.Round((double) num2 / 1000.0) * this.game.Data.RuleVar[856])));
          float fuelSlot949 = this.game.Data.RuleVar[851];
          if ((double) this.game.Data.RuleVar[949] > 0.0)
            fuelSlot949 = (float) this.game.HandyFunctionsObj.GetFuelSlot949((int) Math.Round((double) fuelSlot949), this.game.Data.UnitObj[unrH].RealX(ref this.game), this.game.Data.UnitObj[unrH].RealY(ref this.game));
          int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
          int[] numArray = regimeSlot;
          int index5 = (int) Math.Round((double) fuelSlot949);
          int index6 = index5;
          int num11 = regimeSlot[index5] - num10;
          numArray[index6] = num11;
        }
      }
      if ((double) this.game.Data.RuleVar[843] > 0.0)
        this.game.EventRelatedObj.DoCheckSpecificEvent((int) Math.Round((double) this.game.Data.RuleVar[843]));
      orderResult.OK = true;
      this.LocationProductionPrognosis();
      return (object) orderResult;
    }

    public object LIS_DoStrategicTransfer(int unrS, int tarx, int tary, int tarmap)
    {
      OrderResult orderResult = new OrderResult();
      Coordinate[] coordinateArray = new Coordinate[251];
      if (this.game.Data.RegimeObj[this.game.Data.Turn].AI)
      {
        this.game.EditObj.TransferLostQty = 0;
        this.game.EditObj.TransferLostType = -1;
        this.game.EditObj.TransferLostTransports = 0;
      }
      int unitWeight = this.game.HandyFunctionsObj.GetUnitWeight(unrS, includeLisWeight: true);
      this.game.ProcessingObj.LIS_RemovePointsFromTrajectory(tarx, tary, unitWeight, unrS);
      this.game.Data.MapObj[this.game.Data.UnitObj[unrS].Map].HexObj[this.game.Data.UnitObj[unrS].X, this.game.Data.UnitObj[unrS].Y].RemoveUnitFromList(unrS);
      int x = this.game.Data.UnitObj[unrS].X;
      int y = this.game.Data.UnitObj[unrS].Y;
      int map = this.game.Data.UnitObj[unrS].Map;
      this.game.Data.UnitObj[unrS].X = tarx;
      this.game.Data.UnitObj[unrS].Y = tary;
      this.game.Data.UnitObj[unrS].Map = tarmap;
      this.game.Data.MapObj[tarmap].HexObj[tarx, tary].AddUnitToList(unrS);
      this.game.HandyFunctionsObj.SetHexReconAndZOCUnitMoves(x, y, map, -1, -1, -1, this.game.Data.UnitObj[unrS].Regime, unrS, false);
      ++this.game.Data.StepNr;
      this.game.HandyFunctionsObj.HistoryAddHex(x, y, map, this.game.Data.UnitObj[unrS].Regime, infostring: "Strategic Transfer...");
      if (this.game.Data.MapObj[0].HexObj[tarx, tary].Regime == this.game.Data.UnitObj[unrS].Regime)
        this.game.HandyFunctionsObj.HistoryAddHex(tarx, tary, tarmap, this.game.Data.UnitObj[unrS].Regime, infostring: "Strategic Transfer...");
      if (this.game.Data.UnitObj[unrS].SFCount > -1)
      {
        int sfCount = this.game.Data.UnitObj[unrS].SFCount;
        for (int index = 0; index <= sfCount; ++index)
        {
          int sf = this.game.Data.UnitObj[unrS].SFList[index];
          this.game.Data.SFObj[sf].Ap = 0;
          this.game.Data.SFObj[sf].EP = 0;
          this.game.Data.SFObj[sf].CurrentEntrench = this.game.HandyFunctionsObj.GetMinimumEntrench(tarx, tary, tarmap, this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].UnitGroup);
          this.game.Data.SFObj[sf].initialEntrench = this.game.Data.SFObj[sf].CurrentEntrench;
          this.game.Data.SFObj[sf].Rdn = (int) Math.Round((double) ((float) this.game.Data.SFObj[sf].Rdn * this.game.Data.RuleVar[131]));
        }
      }
      this.game.Data.UnitObj[unrS].LandCap = 0;
      this.game.Data.UnitObj[unrS].NavyCap = 0;
      this.game.Data.UnitObj[unrS].AirCap = 0;
      this.game.Data.UnitObj[unrS].FreeCombatX = -1;
      this.game.Data.UnitObj[unrS].FreeCombatY = -1;
      this.game.Data.UnitObj[unrS].DidMove = true;
      this.game.ProcessingObj.MaxReadinessRule(unrS);
      if ((double) this.game.Data.RuleVar[843] > 0.0)
        this.game.EventRelatedObj.DoCheckSpecificEvent((int) Math.Round((double) this.game.Data.RuleVar[843]));
      orderResult.OK = true;
      this.LocationProductionPrognosis();
      return (object) orderResult;
    }

    public OrderResult BuyResearch(int pplnr, int regnr, int resnr)
    {
      int index1 = regnr;
      OrderResult orderResult = new OrderResult();
      int num1 = (int) Math.Round((double) Conversion.Int((float) this.game.Data.ResearchObj[resnr].PointCost[this.game.Data.PeopleObj[pplnr].PeopleGroup] * this.game.Data.ResCostMod));
      if (this.game.Data.ResearchObj[resnr].CostType == -1)
      {
        if (num1 > this.game.Data.RegimeObj[regnr].ResPts)
        {
          orderResult.ErrorString = "Not enough Research Pts.";
          orderResult.OK = false;
          return orderResult;
        }
      }
      else if (num1 > this.game.Data.RegimeObj[regnr].RegimeSlot[this.game.Data.ResearchObj[resnr].CostType])
      {
        orderResult.ErrorString = "Not enough Research Pts.";
        orderResult.OK = false;
        return orderResult;
      }
      if (this.game.Data.ResearchObj[resnr].CostType == -1)
      {
        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
        RegimeClass[] regimeClassArray = regimeObj;
        int index2 = regnr;
        int index3 = index2;
        regimeClassArray[index3].ResPts = regimeObj[index2].ResPts - num1;
      }
      else
      {
        int[] regimeSlot = this.game.Data.RegimeObj[regnr].RegimeSlot;
        int[] numArray = regimeSlot;
        int costType = this.game.Data.ResearchObj[resnr].CostType;
        int index4 = costType;
        int num2 = regimeSlot[costType] - num1;
        numArray[index4] = num2;
      }
      this.game.Data.RegimeObj[index1].ResField[resnr] = true;
      orderResult.OK = true;
      int sfTypeCounter = this.game.Data.SFTypeCounter;
      for (int index5 = 0; index5 <= sfTypeCounter; ++index5)
      {
        if (this.game.Data.SFTypeObj[index5].ModelID >= 0 & this.game.Data.SFTypeObj[index5].ModelRegime == index1)
        {
          int modelItemType = this.game.Data.SFTypeObj[index5].ModelItemType;
          int tv9 = index5;
          int tv7 = 0;
          int tv8 = 0;
          if (this.game.Data.SFTypeObj[index5].ModelAutoImprovement[resnr] && this.game.Data.SFTypeObj[index5].ModelLastState[resnr] == 0 & this.game.Data.SFTypeObj[index5].ModelImproveEvent[resnr] > 0 && this.game.Data.RegimeObj[index1].ResField[resnr])
          {
            this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.SFTypeObj[index5].ModelImproveEvent[resnr], tv9: tv9, tv7: tv7, tv8: tv8, tv10: modelItemType);
            this.game.Data.SFTypeObj[index5].ModelLastState[resnr] = 1;
          }
        }
      }
      return orderResult;
    }

    public OrderResult DeclareWar(
      int regnr,
      int onregnr,
      bool HideMessage = false,
      bool Recurse = false,
      bool conciousChoice = false)
    {
      OrderResult orderResult = new OrderResult();
      if (!Recurse)
      {
        if ((double) this.game.Data.RuleVar[818] > 0.0)
        {
          RegimeClass[] regimeObj = this.game.Data.RegimeObj;
          RegimeClass[] regimeClassArray = regimeObj;
          int index1 = regnr;
          int index2 = index1;
          regimeClassArray[index2].ResPts = (int) Math.Round((double) ((float) regimeObj[index1].ResPts - this.game.Data.RuleVar[818]));
          if (0 > this.game.Data.RegimeObj[regnr].ResPts)
            this.game.Data.RegimeObj[regnr].ResPts = 0;
        }
        int regimeCounter1 = this.game.Data.RegimeCounter;
        for (int regnr1 = 0; regnr1 <= regimeCounter1; ++regnr1)
        {
          if (this.game.Data.RegimeObj[regnr1].UberRegime == regnr && this.game.Data.RegimeObj[regnr1].RegimeRel[onregnr] != 0)
          {
            this.DeclareWar(regnr1, onregnr, HideMessage, true);
            int regimeCounter2 = this.game.Data.RegimeCounter;
            for (int onregnr1 = 0; onregnr1 <= regimeCounter2; ++onregnr1)
            {
              if (this.game.Data.RegimeObj[onregnr1].UberRegime == onregnr && this.game.Data.RegimeObj[regnr1].RegimeRel[onregnr1] != 0)
                this.DeclareWar(regnr1, onregnr1, HideMessage, true);
            }
          }
        }
        int regimeCounter3 = this.game.Data.RegimeCounter;
        for (int onregnr2 = 0; onregnr2 <= regimeCounter3; ++onregnr2)
        {
          if (this.game.Data.RegimeObj[onregnr2].UberRegime == onregnr && this.game.Data.RegimeObj[regnr].RegimeRel[onregnr2] != 0)
            this.DeclareWar(regnr, onregnr2, HideMessage, true);
        }
      }
      if (this.game.Data.RegimeObj[regnr].RegimeRel[onregnr] == 0)
      {
        orderResult.ErrorString = "Already at war";
        orderResult.OK = false;
        return orderResult;
      }
      this.game.Data.RegimeObj[regnr].RegimeRel[onregnr] = 0;
      this.game.Data.RegimeObj[onregnr].RegimeRel[regnr] = 0;
      this.game.Data.RegimeObj[regnr].RegimeOffer[onregnr] = 0;
      this.game.Data.RegimeObj[onregnr].RegimeOffer[regnr] = 0;
      if (!HideMessage)
      {
        if (this.game.Data.RegimeObj[regnr].RegimeRel[onregnr] == 2)
          this.game.HandyFunctionsObj.AddMessageForAll(this.game.Data.RegimeObj[regnr].Name + " backstabs its ally " + this.game.Data.RegimeObj[onregnr].Name + " and declares war.", -1, 1);
        else
          this.game.HandyFunctionsObj.AddMessageForAll(this.game.Data.RegimeObj[regnr].Name + " declares war on " + this.game.Data.RegimeObj[onregnr].Name, -1, 1);
      }
      int mapCounter1 = this.game.Data.MapCounter;
      int Number;
      for (int map = 0; map <= mapCounter1; ++map)
      {
        int mapWidth = this.game.Data.MapObj[map].MapWidth;
        for (int x = 0; x <= mapWidth; ++x)
        {
          int mapHeight = this.game.Data.MapObj[map].MapHeight;
          for (int y = 0; y <= mapHeight; ++y)
          {
            if (this.game.Data.MapObj[map].HexObj[x, y].Regime != regnr)
            {
              int num = 0;
              if (this.game.Data.MapObj[map].HexObj[x, y].Regime > -1)
              {
                if (this.game.Data.RegimeObj[regnr].RegimeRel[this.game.Data.MapObj[map].HexObj[x, y].Regime] == 0)
                  num = 1;
              }
              else
                num = 1;
              if (num == 1)
              {
                int index3 = -1;
                int unitCounter1 = this.game.Data.MapObj[map].HexObj[x, y].UnitCounter;
                for (int index4 = 0; index4 <= unitCounter1; ++index4)
                {
                  int unit = this.game.Data.MapObj[map].HexObj[x, y].UnitList[index4];
                  if (regnr != this.game.Data.UnitObj[unit].Regime && this.game.Data.RegimeObj[regnr].RegimeRel[this.game.Data.UnitObj[unit].Regime] == 0)
                    index3 = unit;
                }
                int unitCounter2 = this.game.Data.MapObj[map].HexObj[x, y].UnitCounter;
                for (int index5 = 0; index5 <= unitCounter2; ++index5)
                {
                  if (this.game.Data.UnitObj[this.game.Data.MapObj[map].HexObj[x, y].UnitList[index5]].Regime == regnr)
                  {
                    if (this.game.HandyFunctionsObj.VisibleEnemyUnitsInHex(x, y, map, regnr, true) & index3 > -1)
                    {
                      this.game.TempCombat = new CombatClass(this.game);
                      Coordinate Target = new Coordinate();
                      Target.x = x;
                      Target.y = y;
                      Target.map = map;
                      this.game.EditObj.TempUnitList = new UnitList();
                      int unitCounter3 = this.game.Data.MapObj[map].HexObj[x, y].UnitCounter;
                      for (int index6 = 0; index6 <= unitCounter3; ++index6)
                      {
                        int unit = this.game.Data.MapObj[map].HexObj[x, y].UnitList[index6];
                        if (regnr == this.game.Data.UnitObj[unit].Regime && this.game.Data.RegimeObj[this.game.Data.UnitObj[unit].Regime].RegimeRel[this.game.Data.UnitObj[index3].Regime] == 0)
                          this.game.EditObj.TempUnitList.add(unit);
                      }
                      this.game.TempCombat.Init(Target, 1, this.game.EditObj.TempUnitList, 31);
                      this.game.TempCombat.DoBattle();
                      this.game.TempCombat.EndBattle();
                      ++Number;
                      break;
                    }
                    if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[map].HexObj[x, y].LandscapeType].IsSea)
                      this.game.Data.MapObj[map].HexObj[x, y].Regime = regnr;
                    ++this.game.Data.StepNr;
                    this.game.HandyFunctionsObj.HistoryAddHex(x, y, map, -1, infostring: "Hex occupied after declaration of war");
                    break;
                  }
                }
              }
            }
            else
            {
              int unitCounter4 = this.game.Data.MapObj[map].HexObj[x, y].UnitCounter;
              for (int index7 = 0; index7 <= unitCounter4; ++index7)
              {
                int unit1 = this.game.Data.MapObj[map].HexObj[x, y].UnitList[index7];
                if (this.game.Data.RegimeObj[regnr].RegimeRel[this.game.Data.UnitObj[unit1].Regime] == 0)
                {
                  if (this.game.HandyFunctionsObj.VisibleEnemyUnitsInHex(x, y, map, this.game.Data.UnitObj[unit1].Regime, true))
                  {
                    this.game.TempCombat = new CombatClass(this.game);
                    Coordinate Target = new Coordinate();
                    Target.x = x;
                    Target.y = y;
                    Target.map = map;
                    this.game.EditObj.TempUnitList = new UnitList();
                    int unitCounter5 = this.game.Data.MapObj[map].HexObj[x, y].UnitCounter;
                    for (int index8 = 0; index8 <= unitCounter5; ++index8)
                    {
                      int unit2 = this.game.Data.MapObj[map].HexObj[x, y].UnitList[index8];
                      if (regnr != this.game.Data.UnitObj[unit2].Regime && this.game.Data.RegimeObj[this.game.Data.UnitObj[unit2].Regime].RegimeRel[regnr] == 0)
                        this.game.EditObj.TempUnitList.add(unit2);
                    }
                    this.game.TempCombat.Init(Target, 1, this.game.EditObj.TempUnitList, 31);
                    this.game.TempCombat.DoBattle();
                    this.game.TempCombat.EndBattle();
                    ++Number;
                    break;
                  }
                  if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[map].HexObj[x, y].LandscapeType].IsSea)
                    this.game.Data.MapObj[map].HexObj[x, y].Regime = this.game.Data.UnitObj[unit1].Regime;
                  ++this.game.Data.StepNr;
                  this.game.HandyFunctionsObj.HistoryAddHex(x, y, map, -1, infostring: "Hex occupied after declaration of war");
                  break;
                }
              }
            }
          }
        }
      }
      int mapCounter2 = this.game.Data.MapCounter;
      for (int map = 0; map <= mapCounter2; ++map)
      {
        int mapWidth = this.game.Data.MapObj[map].MapWidth;
        for (int x = 0; x <= mapWidth; ++x)
        {
          int mapHeight = this.game.Data.MapObj[map].MapHeight;
          for (int y = 0; y <= mapHeight; ++y)
          {
            int regimeCounter = this.game.Data.RegimeCounter;
            for (regnr = 0; regnr <= regimeCounter; ++regnr)
              this.game.HandyFunctionsObj.DoZOCConquest(x, y, map, regnr);
          }
        }
      }
      orderResult.ErrorString = Number <= 0 ? "" : Strings.Trim(Conversion.Str((object) Number));
      orderResult.OK = true;
      return orderResult;
    }

    public OrderResult MakePeace(
      int regnr,
      int onregnr,
      bool HideMessage = false,
      bool Recurse = false)
    {
      OrderResult orderResult = new OrderResult();
      if (!Recurse)
      {
        int regimeCounter1 = this.game.Data.RegimeCounter;
        for (int regnr1 = 0; regnr1 <= regimeCounter1; ++regnr1)
        {
          if (this.game.Data.RegimeObj[regnr1].UberRegime == regnr && this.game.Data.RegimeObj[regnr1].RegimeRel[onregnr] != 1)
          {
            this.MakePeace(regnr1, onregnr, HideMessage, true);
            int regimeCounter2 = this.game.Data.RegimeCounter;
            for (int onregnr1 = 0; onregnr1 <= regimeCounter2; ++onregnr1)
            {
              if (this.game.Data.RegimeObj[onregnr1].UberRegime == onregnr && this.game.Data.RegimeObj[regnr1].RegimeRel[onregnr1] != 1)
                this.MakePeace(regnr1, onregnr1, HideMessage, true);
            }
          }
        }
        int regimeCounter3 = this.game.Data.RegimeCounter;
        for (int onregnr2 = 0; onregnr2 <= regimeCounter3; ++onregnr2)
        {
          if (this.game.Data.RegimeObj[onregnr2].UberRegime == onregnr && this.game.Data.RegimeObj[regnr].RegimeRel[onregnr2] != 1)
            this.MakePeace(regnr, onregnr2, HideMessage, true);
        }
      }
      if (this.game.Data.RegimeObj[regnr].RegimeRel[onregnr] == 1)
      {
        orderResult.ErrorString = "Already at peace";
        orderResult.OK = false;
        return orderResult;
      }
      if (!HideMessage)
        this.game.HandyFunctionsObj.AddMessageForAll(this.game.Data.RegimeObj[regnr].Name + " makes peace with " + this.game.Data.RegimeObj[onregnr].Name, -1, 1);
      this.game.Data.RegimeObj[regnr].RegimeRel[onregnr] = 1;
      this.game.Data.RegimeObj[onregnr].RegimeRel[regnr] = 1;
      this.game.Data.RegimeObj[regnr].RegimeOffer[onregnr] = 0;
      this.game.Data.RegimeObj[onregnr].RegimeOffer[regnr] = 0;
      orderResult.OK = true;
      return orderResult;
    }

    public OrderResult MakeAlliance(
      int regnr,
      int onregnr,
      bool HideMessage = false,
      bool recurse = false)
    {
      OrderResult orderResult = new OrderResult();
      if (!recurse)
      {
        int regimeCounter1 = this.game.Data.RegimeCounter;
        for (int regnr1 = 0; regnr1 <= regimeCounter1; ++regnr1)
        {
          if (this.game.Data.RegimeObj[regnr1].UberRegime == regnr && this.game.Data.RegimeObj[regnr1].RegimeRel[onregnr] != 2)
          {
            this.MakeAlliance(regnr1, onregnr, HideMessage, true);
            int regimeCounter2 = this.game.Data.RegimeCounter;
            for (int onregnr1 = 0; onregnr1 <= regimeCounter2; ++onregnr1)
            {
              if (this.game.Data.RegimeObj[onregnr1].UberRegime == onregnr && this.game.Data.RegimeObj[regnr1].RegimeRel[onregnr1] != 2)
                this.MakeAlliance(regnr1, onregnr1, HideMessage, true);
            }
          }
        }
        int regimeCounter3 = this.game.Data.RegimeCounter;
        for (int onregnr2 = 0; onregnr2 <= regimeCounter3; ++onregnr2)
        {
          if (this.game.Data.RegimeObj[onregnr2].UberRegime == onregnr && this.game.Data.RegimeObj[regnr].RegimeRel[onregnr2] != 2)
            this.MakeAlliance(regnr, onregnr2, HideMessage, true);
        }
      }
      if (this.game.Data.RegimeObj[regnr].RegimeRel[onregnr] == 2)
      {
        orderResult.ErrorString = "Already Allied";
        orderResult.OK = false;
        return orderResult;
      }
      if (!HideMessage)
        this.game.HandyFunctionsObj.AddMessageForAll(this.game.Data.RegimeObj[regnr].Name + " makes alliance with " + this.game.Data.RegimeObj[onregnr].Name, -1, 1);
      this.game.Data.RegimeObj[regnr].RegimeRel[onregnr] = 2;
      this.game.Data.RegimeObj[onregnr].RegimeRel[regnr] = 2;
      this.game.Data.RegimeObj[regnr].RegimeOffer[onregnr] = 0;
      this.game.Data.RegimeObj[onregnr].RegimeOffer[regnr] = 0;
      orderResult.OK = true;
      return orderResult;
    }

    public OrderResult Build(int unr, int x, int y, int map, int loctype, int regnr = -1)
    {
      OrderResult orderResult = new OrderResult();
      orderResult.OK = true;
      if (unr > -1)
      {
        if (regnr == -1)
          regnr = this.game.Data.UnitObj[unr].Regime;
      }
      else
        regnr = this.game.Data.Turn;
      int index1 = -1;
      if (unr > -1)
        index1 = !this.game.Data.UnitObj[unr].IsHQ ? this.game.Data.UnitObj[unr].HQ : unr;
      int location = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[x, y].Location;
      int num1 = -1;
      if (location > -1)
      {
        num1 = this.game.Data.LocObj[location].People;
        this.game.Data.RemoveLoc(location);
      }
      this.game.Data.AddLoc(x, y, map);
      int locCounter = this.game.Data.LocCounter;
      this.game.Data.MapObj[map].HexObj[x, y].Location = locCounter;
      if (this.game.Data.LocTypeObj[loctype].OverdrawLTNr > -1)
      {
        this.game.Data.MapObj[map].HexObj[x, y].LandscapeType = this.game.Data.LocTypeObj[loctype].OverdrawLTNr;
        this.game.Data.MapObj[map].HexObj[x, y].SpriteNr = this.game.Data.LocTypeObj[loctype].OverdrawSpriteNr;
      }
      this.game.Data.LocObj[locCounter].Type = loctype;
      this.game.Data.LocObj[locCounter].StructuralPts = this.game.Data.LocTypeObj[loctype].StructuralPts;
      if ((double) this.game.Data.RuleVar[819] > 0.0)
        this.game.Data.LocObj[locCounter].StructuralPts = 0;
      this.game.Data.LocObj[locCounter].People = unr <= -1 ? this.game.Data.RegimeObj[regnr].People : this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].People;
      this.game.Data.LocObj[locCounter].HQ = index1;
      if (this.game.Data.LocTypeObj[loctype].NoHQ)
        this.game.Data.LocObj[locCounter].HQ = -1;
      if (this.game.Data.RegimeObj[regnr].AI)
        this.game.Data.LocObj[locCounter].HQ = -1;
      int epCost;
      if (!this.game.Data.RegimeObj[regnr].AI)
      {
        if (unr > -1)
        {
          int num2 = (int) Math.Round((double) ((float) this.game.Data.LocTypeObj[loctype].SupplyCost / this.game.Data.RuleVar[77]));
          while (index1 > -1 & num2 > 0)
          {
            if (this.game.Data.UnitObj[index1].Supply >= num2)
            {
              UnitClass[] unitObj = this.game.Data.UnitObj;
              UnitClass[] unitClassArray = unitObj;
              int index2 = index1;
              int index3 = index2;
              unitClassArray[index3].Supply = unitObj[index2].Supply - num2;
              num2 = 0;
            }
            else
              index1 = this.game.Data.UnitObj[index1].HQ;
          }
        }
        int index4 = 0;
        do
        {
          if (this.game.Data.LocTypeObj[loctype].VarType[index4] > -1)
          {
            int[] regimeSlot = this.game.Data.RegimeObj[regnr].RegimeSlot;
            int[] numArray1 = regimeSlot;
            int[] varType = this.game.Data.LocTypeObj[loctype].VarType;
            int[] numArray2 = varType;
            int index5 = index4;
            int index6 = index5;
            int index7 = numArray2[index6];
            int num3 = regimeSlot[varType[index5]] - this.game.Data.LocTypeObj[loctype].VarQty[index4];
            numArray1[index7] = num3;
          }
          ++index4;
        }
        while (index4 <= 4);
        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
        RegimeClass[] regimeClassArray = regimeObj;
        int index8 = regnr;
        int index9 = index8;
        regimeClassArray[index9].ResPts = regimeObj[index8].ResPts - this.game.Data.LocTypeObj[loctype].PPCost;
        epCost = this.game.Data.LocTypeObj[loctype].EPCost;
      }
      this.game.Data.LocObj[this.game.Data.LocCounter].Name = this.game.Data.LocTypeObj[loctype].Name;
      if (this.game.Data.LocTypeObj[loctype].SetPeopleToSlotX > -1)
      {
        int num4 = this.game.Data.MapObj[0].HexObj[x, y].AreaCode[this.game.Data.LocTypeObj[loctype].SetPeopleToSlotX];
        if (num4 > -1 & num4 <= this.game.Data.PeopleCounter)
          this.game.Data.LocObj[this.game.Data.LocCounter].People = num4;
      }
      if (num1 > -1)
        this.game.Data.LocObj[this.game.Data.LocCounter].People = num1;
      if (unr > -1)
      {
        int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
        int num5;
        for (int index10 = 0; index10 <= sfCount1; ++index10)
        {
          int sf = this.game.Data.UnitObj[unr].SFList[index10];
          if (this.game.Data.SFObj[sf].EP > 0)
          {
            SFClass[] sfObj = this.game.Data.SFObj;
            SFClass[] sfClassArray = sfObj;
            int index11 = sf;
            int index12 = index11;
            sfClassArray[index12].Ap = sfObj[index11].Ap - epCost;
            if (0 > this.game.Data.SFObj[sf].Ap)
              this.game.Data.SFObj[sf].Ap = 0;
            num5 += this.game.Data.SFObj[sf].EP;
          }
        }
        float num6 = (float) epCost / (float) num5;
        if ((double) num6 > 1.0)
          num6 = 1f;
        int sfCount2 = this.game.Data.UnitObj[unr].SFCount;
        for (int index13 = 0; index13 <= sfCount2; ++index13)
        {
          int sf = this.game.Data.UnitObj[unr].SFList[index13];
          SFClass[] sfObj = this.game.Data.SFObj;
          SFClass[] sfClassArray = sfObj;
          int index14 = sf;
          int index15 = index14;
          sfClassArray[index15].EP = (int) Math.Round((double) ((float) sfObj[index14].EP - (float) this.game.Data.SFObj[sf].EP * num6));
        }
      }
      int unitCounter = this.game.Data.MapObj[map].HexObj[x, y].UnitCounter;
      for (int index16 = 0; index16 <= unitCounter; ++index16)
      {
        int unit = this.game.Data.MapObj[map].HexObj[x, y].UnitList[index16];
        int sfCount = this.game.Data.UnitObj[unit].SFCount;
        for (int index17 = 0; index17 <= sfCount; ++index17)
        {
          int sf = this.game.Data.UnitObj[unit].SFList[index17];
          if (this.game.Data.SFObj[sf].CurrentEntrench < this.game.HandyFunctionsObj.GetMinimumEntrench(x, y, map, this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].UnitGroup))
          {
            this.game.Data.SFObj[sf].CurrentEntrench = this.game.HandyFunctionsObj.GetMinimumEntrench(x, y, map, this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].UnitGroup);
            this.game.Data.SFObj[sf].initialEntrench = this.game.Data.SFObj[sf].CurrentEntrench;
          }
        }
      }
      if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.LocCounter].Type].AutoProd > -1)
      {
        this.game.Data.LocObj[this.game.Data.LocCounter].Production[0] = this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.LocCounter].Type].AutoProd;
        this.game.Data.LocObj[this.game.Data.LocCounter].ProdPercent[0] = 100;
        this.game.Data.LocObj[this.game.Data.LocCounter].Production[1] = -1;
        this.game.Data.LocObj[this.game.Data.LocCounter].Production[2] = -1;
        this.game.Data.LocObj[this.game.Data.LocCounter].Production[3] = -1;
        this.game.Data.LocObj[this.game.Data.LocCounter].ProdPercent[1] = 0;
        this.game.Data.LocObj[this.game.Data.LocCounter].ProdPercent[2] = 0;
        this.game.Data.LocObj[this.game.Data.LocCounter].ProdPercent[3] = 0;
        this.game.HandyFunctionsObj.UpgradeProduction(this.game.Data.LocCounter);
      }
      this.LocationProductionPrognosis();
      return orderResult;
    }

    public OrderResult RepairLocation(int unr, int x, int y, int map)
    {
      OrderResult orderResult = new OrderResult();
      orderResult.OK = true;
      int location = this.game.Data.MapObj[map].HexObj[x, y].Location;
      int type = this.game.Data.LocObj[location].Type;
      float num1 = (float) (1.0 - (double) this.game.Data.LocObj[location].StructuralPts / (double) this.game.Data.LocTypeObj[type].StructuralPts);
      int num2 = (int) Math.Round((double) ((float) this.game.Data.LocTypeObj[type].EPCost * num1));
      if (num2 == 0)
        num2 = 1;
      int num3 = this.game.HandyFunctionsObj.GetUnitEP(unr);
      if (num3 > num2)
        num3 = num2;
      float num4 = (float) num3 / (float) num2;
      int Number = (int) Math.Round((double) ((float) (this.game.Data.LocTypeObj[type].StructuralPts - this.game.Data.LocObj[location].StructuralPts) * num4));
      EditClass editObj = this.game.EditObj;
      editObj.FeedBackString = editObj.FeedBackString + "We repaired " + Conversion.Str((object) Number) + " structural points of dammage.";
      LocationClass[] locObj = this.game.Data.LocObj;
      LocationClass[] locationClassArray = locObj;
      int index1 = location;
      int index2 = index1;
      locationClassArray[index2].StructuralPts = locObj[index1].StructuralPts + Number;
      if (this.game.Data.LocObj[location].StructuralPts > this.game.Data.LocTypeObj[type].StructuralPts)
        this.game.Data.LocObj[location].StructuralPts = this.game.Data.LocTypeObj[type].StructuralPts;
      int num5 = num3;
      int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
      int num6;
      for (int index3 = 0; index3 <= sfCount1; ++index3)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index3];
        SFClass[] sfObj = this.game.Data.SFObj;
        SFClass[] sfClassArray = sfObj;
        int index4 = sf;
        int index5 = index4;
        sfClassArray[index5].Ap = sfObj[index4].Ap - num5;
        if (0 > this.game.Data.SFObj[sf].Ap)
          this.game.Data.SFObj[sf].Ap = 0;
        num6 += this.game.Data.SFObj[sf].EP;
      }
      float num7 = num6 != 0 ? (float) num5 / (float) num6 : 0.0f;
      if ((double) num7 > 1.0)
        num7 = 1f;
      int sfCount2 = this.game.Data.UnitObj[unr].SFCount;
      for (int index6 = 0; index6 <= sfCount2; ++index6)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index6];
        SFClass[] sfObj = this.game.Data.SFObj;
        SFClass[] sfClassArray = sfObj;
        int index7 = sf;
        int index8 = index7;
        sfClassArray[index8].EP = (int) Math.Round((double) ((float) sfObj[index7].EP - (float) this.game.Data.SFObj[sf].EP * num7));
      }
      this.LocationProductionPrognosis();
      return orderResult;
    }

    public object SetInitialPeek(int regnr)
    {
      int mapCounter = this.game.Data.MapCounter;
      for (int index1 = 0; index1 <= mapCounter; ++index1)
      {
        int mapWidth = this.game.Data.MapObj[index1].MapWidth;
        for (int index2 = 0; index2 <= mapWidth; ++index2)
        {
          int mapHeight = this.game.Data.MapObj[index1].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; ++index3)
          {
            this.game.Data.MapObj[index1].HexObj[index2, index3].set_LastLT(regnr, this.game.Data.MapObj[index1].HexObj[index2, index3].LandscapeType);
            if (this.game.Data.Product != 7 | !this.game.Data.ShrowdOn)
              this.game.Data.MapObj[index1].HexObj[index2, index3].set_LastReg(regnr, this.game.Data.MapObj[index1].HexObj[index2, index3].Regime);
            else
              this.game.Data.MapObj[index1].HexObj[index2, index3].set_LastReg(regnr, -1);
            this.game.Data.MapObj[index1].HexObj[index2, index3].set_LastSpr(regnr, this.game.Data.MapObj[index1].HexObj[index2, index3].SpriteNr);
          }
        }
      }
      object obj;
      return obj;
    }

    public OrderResult BuildInfra(int unr, int x, int y, int map, int facing)
    {
      OrderResult orderResult = new OrderResult();
      orderResult.OK = true;
      Coordinate coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, map, facing + 1);
      int landscapeType = this.game.Data.MapObj[map].HexObj[coordinate1.x, coordinate1.y].LandscapeType;
      int Number;
      bool flag1;
      if (this.game.Data.MapObj[map].HexObj[x, y].RiverType[facing] > -1)
      {
        Number = (int) Math.Round((double) (this.game.Data.LandscapeTypeObj[landscapeType].RoadCostModifier * (float) this.game.Data.BridgeObj[0].EPCost * this.game.Data.RiverTypeObj[this.game.Data.MapObj[map].HexObj[x, y].RiverType[facing]].BridgeCostModifier));
        flag1 = true;
      }
      bool flag2;
      if (this.game.Data.MapObj[map].HexObj[x, y].RoadType[facing] == -1)
      {
        if (Number == 0)
          Number = (int) Math.Round((double) (this.game.Data.LandscapeTypeObj[landscapeType].RoadCostModifier * (float) this.game.Data.RoadTypeObj[(int) Math.Round((double) this.game.Data.RuleVar[32])].EPCost));
        flag2 = true;
      }
      else if ((double) this.game.Data.RuleVar[821] == (double) this.game.Data.MapObj[map].HexObj[x, y].RoadType[facing] & (double) this.game.Data.RuleVar[820] > -1.0)
      {
        if (Number == 0)
          Number = (int) Math.Round((double) (this.game.Data.LandscapeTypeObj[landscapeType].RoadCostModifier * (float) this.game.Data.RoadTypeObj[(int) Math.Round((double) this.game.Data.RuleVar[820])].EPCost));
        flag2 = true;
      }
      Coordinate coordinate2 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, map, facing + 1);
      Coordinate coordinate3 = this.game.HandyFunctionsObj.MoveApCostPreview(unr, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, x, y, map, coordinate2.x, coordinate2.y, coordinate2.map, OnlyEngineer: 1);
      int x1 = coordinate3.x;
      if (flag1)
      {
        int index1 = this.game.HandyFunctionsObj.HexFacing(coordinate2.x, coordinate2.y, coordinate2.map, x, y, map) - 1;
        this.game.Data.MapObj[map].HexObj[x, y].Bridge[facing] = true;
        this.game.Data.MapObj[map].HexObj[coordinate2.x, coordinate2.y].Bridge[index1] = true;
        if ((double) this.game.Data.RuleVar[822] > -1.0)
        {
          int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
          int[] numArray = regimeSlot;
          int index2 = (int) Math.Round((double) this.game.Data.RuleVar[822]);
          int index3 = index2;
          int num = (int) Math.Round((double) ((float) regimeSlot[index2] - this.game.Data.RuleVar[825] * this.game.Data.RiverTypeObj[this.game.Data.MapObj[map].HexObj[x, y].RiverType[facing]].BridgeCostModifier));
          numArray[index3] = num;
        }
      }
      if (flag2)
      {
        int index4 = this.game.HandyFunctionsObj.HexFacing(coordinate2.x, coordinate2.y, coordinate2.map, x, y, map) - 1;
        if (this.game.Data.MapObj[map].HexObj[x, y].RoadType[facing] == -1 | flag1)
        {
          if (this.game.Data.MapObj[map].HexObj[x, y].RoadType[facing] == -1)
          {
            this.game.Data.MapObj[map].HexObj[x, y].RoadType[facing] = (int) Math.Round((double) this.game.Data.RuleVar[32]);
            this.game.Data.MapObj[map].HexObj[coordinate2.x, coordinate2.y].RoadType[index4] = (int) Math.Round((double) this.game.Data.RuleVar[32]);
          }
          if ((double) this.game.Data.RuleVar[822] > -1.0)
          {
            int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
            int[] numArray = regimeSlot;
            int index5 = (int) Math.Round((double) this.game.Data.RuleVar[822]);
            int index6 = index5;
            int num = (int) Math.Round((double) ((float) regimeSlot[index5] - this.game.Data.RuleVar[823]));
            numArray[index6] = num;
          }
        }
        else
        {
          this.game.Data.MapObj[map].HexObj[x, y].RoadType[facing] = (int) Math.Round((double) this.game.Data.RuleVar[820]);
          this.game.Data.MapObj[map].HexObj[coordinate2.x, coordinate2.y].RoadType[index4] = (int) Math.Round((double) this.game.Data.RuleVar[820]);
          if ((double) this.game.Data.RuleVar[822] > -1.0 & !flag1)
          {
            int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
            int[] numArray = regimeSlot;
            int index7 = (int) Math.Round((double) this.game.Data.RuleVar[822]);
            int index8 = index7;
            int num = (int) Math.Round((double) ((float) regimeSlot[index7] - this.game.Data.RuleVar[824]));
            numArray[index8] = num;
          }
        }
      }
      coordinate3 = this.game.HandyFunctionsObj.MoveApCostPreview(unr, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, x, y, map, coordinate2.x, coordinate2.y, coordinate2.map, OnlyEngineer: 2);
      int x2 = coordinate3.x;
      int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
      int num1;
      for (int index9 = 0; index9 <= sfCount1; ++index9)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index9];
        if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].EP > 0)
        {
          SFClass[] sfObj = this.game.Data.SFObj;
          SFClass[] sfClassArray = sfObj;
          int index10 = sf;
          int index11 = index10;
          sfClassArray[index11].Ap = sfObj[index10].Ap - x1;
        }
        else
        {
          SFClass[] sfObj = this.game.Data.SFObj;
          SFClass[] sfClassArray = sfObj;
          int index12 = sf;
          int index13 = index12;
          sfClassArray[index13].Ap = sfObj[index12].Ap - x2;
        }
        if (this.game.Data.SFObj[sf].Ap < 0)
          this.game.Data.SFObj[sf].Ap = 0;
        num1 += this.game.Data.SFObj[sf].EP;
      }
      float num2 = (float) Number / (float) num1;
      if ((double) num2 > 1.0)
        num2 = 1f;
      int sfCount2 = this.game.Data.UnitObj[unr].SFCount;
      for (int index14 = 0; index14 <= sfCount2; ++index14)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index14];
        SFClass[] sfObj = this.game.Data.SFObj;
        SFClass[] sfClassArray = sfObj;
        int index15 = sf;
        int index16 = index15;
        sfClassArray[index16].EP = (int) Math.Round((double) ((float) sfObj[index15].EP - (float) this.game.Data.SFObj[sf].EP * num2));
      }
      if ((double) this.game.Data.RuleVar[483] > 0.0 & this.game.Data.Product >= 6)
      {
        ++this.game.Data.StepNr;
        string infostring = this.game.Data.UnitObj[unr].Name + " Constructs road...";
        if (flag1)
          infostring = this.game.Data.UnitObj[unr].Name + " Constructs bridge...";
        this.game.HandyFunctionsObj.HistoryAddHex(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, map, this.game.Data.Turn, 2, 0, unr, infostring: infostring);
      }
      else
      {
        this.game.Data.MapObj[map].HexObj[x, y].RemoveUnitFromList(unr);
        ++this.game.Data.StepNr;
        string infostring1 = this.game.Data.UnitObj[unr].Name + " Constructs road...";
        if (flag1)
          infostring1 = this.game.Data.UnitObj[unr].Name + " Constructs bridge...";
        this.game.HandyFunctionsObj.HistoryAddHex(x, y, map, this.game.Data.Turn, 2, 0, unr, infostring: infostring1);
        this.game.Data.MapObj[map].HexObj[coordinate2.x, coordinate2.y].AddUnitToList(unr);
        this.game.Data.UnitObj[unr].X = coordinate2.x;
        this.game.Data.UnitObj[unr].Y = coordinate2.y;
        string infostring2 = "";
        this.game.HandyFunctionsObj.HistoryAddHex(coordinate2.x, coordinate2.y, coordinate2.map, this.game.Data.Turn, 2, 0, unr, infostring: infostring2);
        this.game.HandyFunctionsObj.SetHexReconAndZOCUnitMoves(x, y, map, coordinate2.x, coordinate2.y, coordinate2.map, this.game.Data.UnitObj[unr].Regime, unr, dontcountair: true);
      }
      this.game.EditObj.FeedBackString = "";
      if (flag1)
      {
        string str = x1.ToString();
        if (x1 >= 999)
          str = "all";
        if (this.game.Data.Product >= 6)
          this.game.EditObj.FeedBackString = "Bridge constructed! Cost was " + Strings.Trim(Conversion.Str((object) Number)) + " engineer points.";
        else
          this.game.EditObj.FeedBackString = "Bridge constructed! Cost was " + Strings.Trim(Conversion.Str((object) x1)) + " action points and " + Strings.Trim(Conversion.Str((object) Number)) + " engineer points.";
      }
      if (this.game.Data.MapObj[map].HexObj[x, y].CardUponConquest > -1)
      {
        this.game.EditObj.AreaX = x;
        this.game.EditObj.AreaY = y;
        this.game.EditObj.AreaMap = map;
        if (this.game.Data.RegimeObj[this.game.Data.Turn].AI)
          this.PlayCard(this.game.Data.MapObj[map].HexObj[x, y].CardUponConquest);
        else
          this.game.EditObj.DoCardSlot = this.game.Data.MapObj[map].HexObj[x, y].CardUponConquest;
      }
      if ((double) this.game.Data.RuleVar[843] > 0.0)
        this.game.EventRelatedObj.DoCheckSpecificEvent((int) Math.Round((double) this.game.Data.RuleVar[843]));
      return orderResult;
    }

    public OrderResult BlowBridge(int unr, int x, int y, int map, int facing)
    {
      OrderResult orderResult = new OrderResult();
      Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, map, facing + 1);
      int index1 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, coordinate.map, x, y, map) - 1;
      int num1 = Conversion.Int(this.game.HandyFunctionsObj.GetBlowBridgePts(unr));
      int num2 = (int) Math.Round((double) Conversion.Int(this.game.Data.RuleVar[7] * this.game.Data.RiverTypeObj[this.game.Data.MapObj[map].HexObj[x, y].RiverType[facing]].BridgeCostModifier));
      this.game.EditObj.FeedBackString = "";
      int num3 = 0;
      if (this.game.Data.Product >= 6 & this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime != this.game.Data.Turn & this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime > -1)
      {
        int num4 = 0;
        int unitCounter1 = this.game.Data.MapObj[0].HexObj[x, y].UnitCounter;
        for (int index2 = 0; index2 <= unitCounter1; ++index2)
          num4 += this.game.HandyFunctionsObj.GetPowerPtsAbsolute(this.game.Data.MapObj[0].HexObj[x, y].UnitList[index2]);
        int num5 = 0;
        int unitCounter2 = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitCounter;
        for (int index3 = 0; index3 <= unitCounter2; ++index3)
          num5 += this.game.HandyFunctionsObj.GetPowerPtsAbsolute(this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitList[index3]);
        num3 = 0;
        int num6 = num4 <= 0 ? 1000 : (int) Math.Round((double) (100 * num5) / (double) num4);
        if (num6 > 1000)
          num6 = 1000;
        if (num6 > 0)
        {
          num2 += (int) Math.Round((double) (num2 * num6) / 100.0);
          this.game.EditObj.FeedBackString = "Due to enemy troops on opposite side of the bridge def score increased with +" + num6.ToString() + "%. ";
        }
      }
      int Number1 = num1;
      int Number2 = num2;
      int Number3 = (int) Math.Round((double) Conversion.Int((float) num1 * VBMath.Rnd()));
      int Number4 = (int) Math.Round((double) Conversion.Int((float) num2 * VBMath.Rnd()));
      EditClass editObj = this.game.EditObj;
      editObj.FeedBackString = editObj.FeedBackString + "Blow attempt score = " + Conversion.Str((object) Number3) + " (max " + Strings.Trim(Conversion.Str((object) Number1)) + "), Bridge def score = " + Conversion.Str((object) Number4) + " (max " + Strings.Trim(Conversion.Str((object) Number2)) + ")";
      if (Number3 >= Number4)
      {
        this.game.Data.MapObj[map].HexObj[x, y].Bridge[facing] = false;
        this.game.Data.MapObj[map].HexObj[coordinate.x, coordinate.y].Bridge[index1] = false;
        int sfCount = this.game.Data.UnitObj[unr].SFCount;
        for (int index4 = 0; index4 <= sfCount; ++index4)
        {
          int sf = this.game.Data.UnitObj[unr].SFList[index4];
          SFClass[] sfObj = this.game.Data.SFObj;
          SFClass[] sfClassArray = sfObj;
          int index5 = sf;
          int index6 = index5;
          sfClassArray[index6].Ap = sfObj[index5].Ap - 50;
          this.game.Data.SFObj[sf].EP = 0;
          if (0 > this.game.Data.SFObj[sf].Ap)
            this.game.Data.SFObj[sf].Ap = 0;
        }
        this.game.EditObj.FeedBackString += ". Bridge destroyed.";
        orderResult.OK = true;
        ++this.game.Data.StepNr;
        this.game.HandyFunctionsObj.HistoryAddHex(x, y, map, this.game.Data.UnitObj[unr].Regime, infostring: "Bridge is blown.");
      }
      else
      {
        int sfCount = this.game.Data.UnitObj[unr].SFCount;
        for (int index7 = 0; index7 <= sfCount; ++index7)
        {
          int sf = this.game.Data.UnitObj[unr].SFList[index7];
          SFClass[] sfObj = this.game.Data.SFObj;
          SFClass[] sfClassArray = sfObj;
          int index8 = sf;
          int index9 = index8;
          sfClassArray[index9].Ap = sfObj[index8].Ap - 50;
          this.game.Data.SFObj[sf].EP = 0;
          if (0 > this.game.Data.SFObj[sf].Ap)
            this.game.Data.SFObj[sf].Ap = 0;
        }
        this.game.EditObj.FeedBackString += ". Bridge survives.";
        orderResult.OK = false;
        ++this.game.Data.StepNr;
        this.game.HandyFunctionsObj.HistoryAddHex(x, y, map, this.game.Data.UnitObj[unr].Regime, infostring: "Failed attempt to blow bridge.");
      }
      return orderResult;
    }

    public void MaxReadinessRule(int unr)
    {
      int x = this.game.Data.UnitObj[unr].X;
      int y = this.game.Data.UnitObj[unr].Y;
      int map = this.game.Data.UnitObj[unr].Map;
      if (x == -1 | y == -1)
        return;
      int location = this.game.Data.MapObj[map].HexObj[x, y].Location;
      if (location <= -1)
        return;
      int type1 = this.game.Data.LocObj[location].Type;
      int num1 = this.game.Data.LocObj[location].StructuralPts;
      int structuralPts = this.game.Data.LocTypeObj[type1].StructuralPts;
      if (this.game.Data.Product >= 6 && this.game.Data.LocTypeObj[type1].Invincible)
        num1 = structuralPts;
      int num2 = structuralPts <= 0 ? 100 : (int) Math.Round(Conversion.Int(100.0 * ((double) num1 / (double) structuralPts)));
      if ((double) num2 < (double) this.game.Data.RuleVar[60])
        num2 = (int) Math.Round((double) this.game.Data.RuleVar[60]);
      if (num2 < 100)
      {
        int sfCount = this.game.Data.UnitObj[unr].SFCount;
        for (int index = 0; index <= sfCount; ++index)
        {
          int sf = this.game.Data.UnitObj[unr].SFList[index];
          int type2 = this.game.Data.SFObj[sf].Type;
          if (this.game.Data.LocTypeObj[type1].IsPort && this.game.Data.SFTypeObj[type2].Theater == 1 && this.game.Data.SFObj[sf].Rdn > num2)
            this.game.Data.SFObj[sf].Rdn = num2;
          if (this.game.Data.LocTypeObj[type1].IsAirfield | this.game.Data.LocObj[location].isAirfield && this.game.Data.SFTypeObj[type2].Theater == 2 && this.game.Data.SFObj[sf].Rdn > num2)
            this.game.Data.SFObj[sf].Rdn = num2;
        }
      }
      if ((double) num2 >= (double) this.game.Data.RuleVar[60])
        return;
      int num3 = (int) Math.Round((double) this.game.Data.RuleVar[60]);
    }

    public OrderResult BlowLocation(int unr, int x, int y, int map)
    {
      OrderResult orderResult = new OrderResult();
      Conversion.Int(this.game.HandyFunctionsObj.GetBlowBridgePts(unr));
      int location = this.game.Data.MapObj[map].HexObj[x, y].Location;
      int type = this.game.Data.LocObj[location].Type;
      int blowBridgePts = this.game.HandyFunctionsObj.GetBlowBridgePts(unr);
      if (!this.game.Data.LocTypeObj[type].Invincible)
      {
        int Number = (int) Math.Round((double) Conversion.Int((float) blowBridgePts * VBMath.Rnd()));
        this.game.EditObj.FeedBackString = "Loc has " + Conversion.Str((object) this.game.Data.LocObj[location].StructuralPts) + "pts. Dam done to loc: " + Strings.Trim(Conversion.Str((object) Number)) + ".";
        LocationClass[] locObj = this.game.Data.LocObj;
        LocationClass[] locationClassArray = locObj;
        int index1 = location;
        int index2 = index1;
        locationClassArray[index2].StructuralPts = locObj[index1].StructuralPts - Number;
        if (1 > this.game.Data.LocObj[location].StructuralPts)
        {
          if (this.game.Data.LocTypeObj[type].OnDestructLT > -1)
          {
            this.game.EditObj.FeedBackString += ". Loc destroyed!";
            this.game.Data.MapObj[map].HexObj[this.game.Data.LocObj[location].X, this.game.Data.LocObj[location].Y].LandscapeType = this.game.Data.LocTypeObj[type].OnDestructLT;
            this.game.Data.MapObj[map].HexObj[this.game.Data.LocObj[location].X, this.game.Data.LocObj[location].Y].SpriteNr = this.game.Data.LocTypeObj[type].OnDestructSpriteNr;
            this.game.Data.RemoveLoc(location);
          }
          else if (this.game.Data.LocTypeObj[type].OnDestructLT == -2)
          {
            this.game.EditObj.FeedBackString += ". Loc destroyed!";
            this.game.Data.RemoveLoc(location);
          }
          else
          {
            this.game.EditObj.FeedBackString += ". Loc is knocked out!";
            this.game.Data.LocObj[location].StructuralPts = 0;
          }
        }
        else
        {
          EditClass editObj = this.game.EditObj;
          editObj.FeedBackString = editObj.FeedBackString + ". Loc down to " + Strings.Trim(Conversion.Str((object) this.game.Data.LocObj[location].StructuralPts)) + " pts.";
        }
      }
      int sfCount = this.game.Data.UnitObj[unr].SFCount;
      for (int index3 = 0; index3 <= sfCount; ++index3)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index3];
        SFClass[] sfObj = this.game.Data.SFObj;
        SFClass[] sfClassArray = sfObj;
        int index4 = sf;
        int index5 = index4;
        sfClassArray[index5].Ap = sfObj[index4].Ap - 50;
        this.game.Data.SFObj[sf].EP = 0;
        if (0 > this.game.Data.SFObj[sf].Ap)
          this.game.Data.SFObj[sf].Ap = 0;
      }
      this.LocationProductionPrognosis();
      orderResult.OK = true;
      return orderResult;
    }

    public void CheckForWinner()
    {
      if (this.game.Data.Winner > -1 || this.game.Data.VPWin == -1 || this.game.Data.PbemDrawGame > 0)
        return;
      int regimeCounter = this.game.Data.RegimeCounter;
      for (int regnr = 0; regnr <= regimeCounter; ++regnr)
      {
        if (this.game.HandyFunctionsObj.GetRegimeVP(regnr) >= this.game.Data.VPWin)
        {
          this.game.Data.Winner = regnr;
          break;
        }
      }
    }

    public void DoAutoRecoverLocations(int regnr)
    {
      if (this.game.Data.LocCounter == -1)
        return;
      int locCounter = this.game.Data.LocCounter;
      for (int index1 = 0; index1 <= locCounter; ++index1)
      {
        if (this.game.Data.MapObj[this.game.Data.LocObj[index1].Map].HexObj[this.game.Data.LocObj[index1].X, this.game.Data.LocObj[index1].Y].Regime == regnr)
        {
          int type = this.game.Data.LocObj[index1].Type;
          bool flag = true;
          if (this.game.Data.LocTypeObj[type].isSupplyBase && this.game.Data.LocObj[index1].supplyBaseMode >= 3)
            flag = false;
          if (flag && this.game.Data.LocObj[index1].StructuralPts < this.game.Data.LocTypeObj[type].StructuralPts)
          {
            LocationClass[] locObj1 = this.game.Data.LocObj;
            LocationClass[] locationClassArray1 = locObj1;
            int index2 = index1;
            int index3 = index2;
            locationClassArray1[index3].StructuralPts = locObj1[index2].StructuralPts + this.game.Data.LocTypeObj[type].AutoRecoverPts;
            if (this.game.Data.MapObj[this.game.Data.LocObj[index1].Map].HexObj[this.game.Data.LocObj[index1].X, this.game.Data.LocObj[index1].Y].Regime > -1 && this.game.Data.RegimeObj[this.game.Data.MapObj[this.game.Data.LocObj[index1].Map].HexObj[this.game.Data.LocObj[index1].X, this.game.Data.LocObj[index1].Y].Regime].AI && (double) this.game.Data.RuleVar[250] == 1.0)
            {
              LocationClass[] locObj2 = this.game.Data.LocObj;
              LocationClass[] locationClassArray2 = locObj2;
              int index4 = index1;
              int index5 = index4;
              locationClassArray2[index5].StructuralPts = (int) Math.Round((double) locObj2[index4].StructuralPts + (double) this.game.Data.LocTypeObj[type].StructuralPts * 0.33);
            }
            if (this.game.Data.LocObj[index1].StructuralPts > this.game.Data.LocTypeObj[type].StructuralPts)
              this.game.Data.LocObj[index1].StructuralPts = this.game.Data.LocTypeObj[type].StructuralPts;
          }
          if (this.game.Data.LocTypeObj[type].isSupplyBase)
          {
            if (this.game.Data.LocObj[index1].supplyBaseMode >= 3)
            {
              this.game.Data.LocObj[index1].StructuralPts = 0;
            }
            else
            {
              int num = (int) Math.Round(Math.Floor((double) this.game.Data.LocTypeObj[type].StructuralPts * Math.Max((double) this.game.Data.LocObj[index1].supply / (double) this.game.Data.LocTypeObj[type].maxSupply, (double) this.game.Data.LocObj[index1].fuel / (double) this.game.Data.LocTypeObj[type].maxFuel)));
              if (num < this.game.Data.LocObj[index1].StructuralPts)
                this.game.Data.LocObj[index1].StructuralPts = num;
            }
          }
          this.game.Data.LocObj[index1].startTurnStructuralPts = this.game.Data.LocObj[index1].StructuralPts;
        }
      }
      int num1;
      for (int index = 0; index <= -1; ++index)
        num1 = 1;
      num1 = 0;
    }

    public OrderResult DoDisband(int unr, int sfnr)
    {
      OrderResult orderResult1 = new OrderResult();
      orderResult1.OK = true;
      orderResult1.ErrorString = "";
      if ((double) this.game.Data.RuleVar[861] > 0.0)
      {
        int type = this.game.Data.SFObj[sfnr].Type;
        int itemTypeCounter = this.game.Data.ItemTypeCounter;
        for (int index1 = 0; index1 <= itemTypeCounter; ++index1)
        {
          if (this.game.Data.ItemTypeObj[index1].IsSFType == type)
          {
            int index2 = 0;
            do
            {
              if (this.game.Data.ItemTypeObj[index1].RegimeSlotsCost[index2] > -1)
              {
                int num1;
                ++num1;
                int index3 = this.game.Data.ItemTypeObj[index1].RegimeSlotsCost[index2];
                int Number = (int) Math.Round((double) ((float) (this.game.Data.ItemTypeObj[index1].RegimeSlotsCostQty[index2] * this.game.Data.SFObj[sfnr].Qty) * this.game.Data.RuleVar[861]));
                int[] regimeSlot = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot;
                int[] numArray = regimeSlot;
                int index4 = index3;
                int index5 = index4;
                int num2 = regimeSlot[index4] + Number;
                numArray[index5] = num2;
                if (num1 == 1)
                  orderResult1.ErrorString = "Disbanding provided the following recycled resources: ";
                if (num1 > 1)
                  orderResult1.ErrorString += ", ";
                OrderResult orderResult2 = orderResult1;
                orderResult2.ErrorString = orderResult2.ErrorString + Strings.Trim(Conversion.Str((object) Number)) + "x " + this.game.Data.RegimeSlotName[index3];
              }
              ++index2;
            }
            while (index2 <= 4);
            break;
          }
        }
      }
      this.LocationProductionPrognosis();
      this.game.HandyFunctionsObj.SetHexReconAndZOCUnitMoves(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, -1, -1, -1, this.game.Data.UnitObj[unr].Regime, unr, false);
      this.game.Data.RemoveSF(sfnr);
      this.game.HandyFunctionsObj.SetHexReconAndZOCUnitMoves(-1, -1, -1, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, this.game.Data.UnitObj[unr].Map, this.game.Data.UnitObj[unr].Regime, unr, false);
      return orderResult1;
    }

    public void DoDisbandUnit(int unr)
    {
      int x = this.game.Data.UnitObj[unr].X;
      int y = this.game.Data.UnitObj[unr].Y;
      if (this.game.Data.UnitObj[unr].IsHQ)
      {
        int unitCounter = this.game.Data.UnitCounter;
        for (int index1 = 0; index1 <= unitCounter; ++index1)
        {
          if (this.game.Data.UnitObj[index1].SFCount > -1 && this.game.Data.UnitObj[index1].HQ == unr && !this.game.Data.UnitObj[index1].IsHQ)
          {
            int sfCount = this.game.Data.UnitObj[index1].SFCount;
            for (int index2 = 0; index2 <= sfCount; ++index2)
            {
              int sf = this.game.Data.UnitObj[index1].SFList[index2];
              if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater < 1)
                this.game.Data.SFObj[sf].Rdn = (int) Math.Round((double) ((float) this.game.Data.SFObj[sf].Rdn * this.game.Data.RuleVar[48]));
            }
          }
        }
        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
        RegimeClass[] regimeClassArray = regimeObj;
        int turn = this.game.Data.Turn;
        int index = turn;
        regimeClassArray[index].ResPts = (int) Math.Round((double) ((float) regimeObj[turn].ResPts + this.game.Data.RuleVar[47]));
      }
      else
      {
        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
        RegimeClass[] regimeClassArray = regimeObj;
        int turn = this.game.Data.Turn;
        int index = turn;
        regimeClassArray[index].ResPts = (int) Math.Round((double) ((float) regimeObj[turn].ResPts + this.game.Data.RuleVar[46]));
      }
      this.game.Data.RemoveUnit(unr, ref this.game);
    }

    public OrderResult DoUpgrade(int unr, int sfnr, int qty, int hq)
    {
      OrderResult orderResult = new OrderResult();
      if (qty == 0)
        return orderResult;
      orderResult.OK = true;
      int upgradeToo = this.game.Data.SFTypeObj[this.game.Data.SFObj[sfnr].Type].UpgradeToo;
      this.game.HandyFunctionsObj.AddTroops3(unr, upgradeToo, this.game.Data.SFObj[sfnr].People, qty, this.game.Data.SFObj[sfnr].Xp, this.game.Data.SFObj[sfnr].Rdn, 0, this.game.Data.SFObj[sfnr].Mor, entr: this.game.Data.SFObj[sfnr].CurrentEntrench, offmod: this.game.Data.SFObj[sfnr].OffMod, defmod: this.game.Data.SFObj[sfnr].DefMod, MoveType: this.game.Data.SFObj[sfnr].MoveType);
      this.game.HandyFunctionsObj.RemoveTroops(unr, this.game.Data.SFObj[sfnr].Type, this.game.Data.SFObj[sfnr].People, qty, this.game.Data.SFObj[sfnr].MoveType);
      int num = this.game.HandyFunctionsObj.CanUpgradeCost(sfnr, unr, qty);
      if (hq > -1)
      {
        UnitClass[] unitObj = this.game.Data.UnitObj;
        UnitClass[] unitClassArray = unitObj;
        int index1 = hq;
        int index2 = index1;
        unitClassArray[index2].Supply = unitObj[index1].Supply - num;
      }
      return orderResult;
    }

    public OrderResult DoMakeHQ(int unr)
    {
      int regime = this.game.Data.UnitObj[unr].Regime;
      OrderResult orderResult = new OrderResult();
      orderResult.OK = true;
      this.game.Data.UnitObj[unr].IsHQ = !this.game.Data.UnitObj[unr].IsHQ;
      if (!this.game.Data.UnitObj[unr].IsHQ)
      {
        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
        RegimeClass[] regimeClassArray = regimeObj;
        int index1 = regime;
        int index2 = index1;
        regimeClassArray[index2].UnitNumber = regimeObj[index1].UnitNumber + 1;
        string str1 = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[regime].UnitNumber));
        if (this.game.Data.RegimeObj[regime].UnitNumber == 1)
          str1 += "st";
        if (this.game.Data.RegimeObj[regime].UnitNumber == 2)
          str1 += "nd";
        if (this.game.Data.RegimeObj[regime].UnitNumber > 2)
          str1 += "th";
        string str2 = str1 + " " + this.game.Data.RegimeObj[regime].UnitName;
        this.game.Data.UnitObj[unr].Name = str2;
        int unitCounter = this.game.Data.UnitCounter;
        for (int index3 = 0; index3 <= unitCounter; ++index3)
        {
          if (this.game.Data.UnitObj[unr].HQ == unr)
            this.game.Data.UnitObj[unr].HQ = -1;
        }
      }
      else
      {
        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
        RegimeClass[] regimeClassArray = regimeObj;
        int index4 = regime;
        int index5 = index4;
        regimeClassArray[index5].HQNumber = regimeObj[index4].HQNumber + 1;
        string str3 = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[regime].HQNumber));
        if (this.game.Data.RegimeObj[regime].UnitNumber == 1)
          str3 += "st";
        if (this.game.Data.RegimeObj[regime].UnitNumber == 2)
          str3 += "nd";
        if (this.game.Data.RegimeObj[regime].UnitNumber > 2)
          str3 += "th";
        string str4 = str3 + " " + this.game.Data.RegimeObj[regime].HQName;
        this.game.Data.UnitObj[unr].Name = str4;
      }
      return orderResult;
    }
  }
}
