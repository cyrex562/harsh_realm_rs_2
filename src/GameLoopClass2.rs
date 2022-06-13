// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.GameLoopClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace WindowsApplication1
{
  pub class GameLoopClass2
  {
     bool DoingAI;
     GameClass game;
    pub text: String;
    pub text2: String;
    pub value1: i32;
    pub value2: i32;
    pub value3: i32;

    pub GameLoopClass2(ref GameClass GameRef) => this.game = GameRef;

    pub void Setup()
    {
      if (this.game.Data.Turn > -1 && !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
      {
        this.game.EditObj.RealRound = this.game.Data.Round;
        this.game.EditObj.RealTurn = this.game.Data.Turn;
      }
      if (this.game.EditObj.TestEarlyCinematics == 1)
        this.game.EditObj.Test = 3;
      else if (this.game.Data.se1_earlyCinematicsLogin == 1)
      {
        this.game.Data.se1_earlyCinematicsLogin = 2;
        this.game.EditObj.Test = 3;
      }
      else
      {
        this.game.EditObj.Test = -1;
        this.game.EditObj.OldUnit = -1;
        this.game.EditObj.AIMoving = false;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    pub void handleTimer()
    {
      if (this.game.Data.Turn > -1 && !this.game.Data.RegimeObj[this.game.Data.Turn].AI)
      {
        this.game.EditObj.RealRound = this.game.Data.Round;
        this.game.EditObj.RealTurn = this.game.Data.Turn;
      }
      this.DoingAI = false;
      while (true)
      {
        do
        {
          do
          {
            string s;
            do
            {
              if (this.game.Data.UseAI == 1)
              {
                if (Information.IsNothing((object) this.game.NewAIObj))
                  this.game.NewAIObj = new NewAIClass(this.game);
                this.game.DC2AIObj = (DC2AIClass) null;
                this.game.AIObj = (AIClass) null;
              }
              else if (this.game.Data.UseAI == 2)
              {
                if (Information.IsNothing((object) this.game.DC2AIObj))
                  this.game.DC2AIObj = new DC2AIClass(this.game);
                this.game.NewAIObj = (NewAIClass) null;
                this.game.AIObj = (AIClass) null;
              }
              if (!Information.IsNothing((object) this.game.AIThread))
              {
                if (!this.game.AIRunning & this.game.AIThreadRunning & (this.game.EditObj.Test == 10 | this.game.EditObj.Test == 9))
                {
                  this.game.AIThreadRunning = false;
                  this.game.AIThread.Abort();
                  this.game.AIThread.Join();
                  this.DoingAI = false;
                }
                else if (this.game.AIThreadRunning & (this.game.EditObj.Test == 9 | this.game.EditObj.Test == 10))
                  this.DoingAI = true;
              }
              while (this.DoingAI)
              {
                if (!this.game.AIRunning & this.game.AIThreadRunning & (this.game.EditObj.Test == 10 | this.game.EditObj.Test == 9))
                {
                  this.game.AIThreadRunning = false;
                  this.game.AIThread.Abort();
                  this.game.AIThread.Join();
                  this.DoingAI = false;
                }
                else if (this.game.AIThreadRunning & (this.game.EditObj.Test == 9 | this.game.EditObj.Test == 10))
                  this.DoingAI = true;
                Thread.Sleep(1);
              }
              this.game.EditObj.OrderType = 0;
              this += 1.game.EditObj.Test;
              if (this.game.EditObj.Test == 0)
              {
                if (this.game.Data.Turn > -1)
                  s = "End of turn";
                if (this.game.Data.Round == 0)
                {
                  s = "Setting up scenario.";
                  this.game.EditObj.SetViewModeExtraNr = 0;
                }
                this.game.EditObj.LayerSupplyOn = false;
              }
              int index1;
              if (this.game.EditObj.Test == 1)
              {
                if (this.game.Data.Turn > -1 & this.game.Data.Round != 0 && this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                {
                  this.game.ProcessingObj.SetInitialReconAndZOC(this.game.Data.Turn);
                  this.game.HandyFunctionsObj.ClearHistory((object) this.game.Data.Turn);
                }
                if (this.game.Data.Round == 0)
                {
                  if (this.game.Data.UseAI == 1)
                    this.game.NewAIObj.tempextraaivp = false;
                  if ((double) this.game.Data.RuleVar[840] == 1.0)
                  {
                    int mapCounter = this.game.Data.MapCounter;
                    for (int index2 = 0; index2 <= mapCounter; index2 += 1)
                    {
                      int mapWidth = this.game.Data.MapObj[index2].MapWidth;
                      for (int index3 = 0; index3 <= mapWidth; index3 += 1)
                      {
                        int mapHeight = this.game.Data.MapObj[index2].MapHeight;
                        for (int index4 = 0; index4 <= mapHeight; index4 += 1)
                          this.game.Data.MapObj[index2].HexObj[index3, index4].OrigOwner = this.game.Data.MapObj[index2].HexObj[index3, index4].Regime;
                      }
                    }
                  }
                  if ((double) this.game.Data.RuleVar[501] == 1.0)
                    this.game.Data.RuleVar[226] = 0.0f;
                  int regimeCounter1 = this.game.Data.RegimeCounter;
                  for (int regnr = 0; regnr <= regimeCounter1; regnr += 1)
                  {
                    this.game.ProcessingObj.InitialAPPenalty(regnr, true);
                    this.game.EditObj.firstroundcheck = true;
                    int sfCounter = this.game.Data.SFCounter;
                    for (int index5 = 0; index5 <= sfCounter; index5 += 1)
                      this.game.Data.SFObj[index5].Ap = this.game.Data.SFObj[index5].Rdn;
                    int turn = this.game.Data.Turn;
                    this.game.Data.Turn = regnr;
                    this.game.Data.Round = 1;
                    this.game.ProcessingObj.SetInitialReconAndZOC(regnr);
                    this.game.HandyFunctionsObj.ClearHistory((object) regnr);
                    this.game.Data.Round = 0;
                    this.game.Data.Turn = turn;
                  }
                  this.game.EventRelatedObj.DoCheckEvents(7);
                  int regimeCounter2 = this.game.Data.RegimeCounter;
                  for (index1 = 0; index1 <= regimeCounter2; index1 += 1)
                  {
                    if (this.game.Data.ShrowdPeek)
                      this.game.ProcessingObj.SetInitialPeek(index1);
                  }
                }
                s = "Add turn";
              }
              if (this.game.EditObj.Test == 2)
              {
                s = "Turn events";
                if (this.game.Data.Turn != -1)
                  this.game.ProcessingObj.InitialAPPenalty(this.game.Data.Turn, true);
                if (this.game.Data.Turn != -1 && this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                  this.game.EventRelatedObj.DoCheckEvents(5);
                this += 1.game.Data.Turn;
                this.game.Data.InTurn = false;
                if (this.game.Data.Turn == 1)
                  s = s;
              }
              bool sleep;
              if (this.game.EditObj.Test == 3)
              {
                s = "Round events";
                this.game.EditObj.TestEarlyCinematics = 0;
                if (this.game.Data.Round == 0 | this.game.Data.Turn > this.game.Data.RegimeCounter)
                {
                  this += 1.game.Data.Round;
                  if (this.game.Data.Round > 1)
                    this.game.Data.Turn = 0;
                  this.game.HandyFunctionsObj.RedimStats();
                  this.game.ProcessingObj.CheckForWinner();
                  this.game.EventRelatedObj.DoCheckEvents(1);
                  this.DoPresentStats();
                  if (this.game.Data.Round == 1 & this.game.Data.Turn == 0)
                    this.game.ProcessingObj.MakeInitialModels();
                }
                if (this.game.Data.Product >= 7)
                  this.game.HandyFunctionsObj.ResetRegimeLowData((object) this.game.Data.Turn);
                if ((double) this.game.Data.RuleVar[336] == 2.0)
                {
                  int unitCounter = this.game.Data.UnitCounter;
                  for (index1 = 0; index1 <= unitCounter; index1 += 1)
                  {
                    if (this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index1].Supply > this.game.HandyFunctionsObj.UnitSupplyStore(index1))
                      this.game.Data.UnitObj[index1].Supply = this.game.HandyFunctionsObj.UnitSupplyStore(index1);
                  }
                }
                if (this.game.Data.RegimeObj[this.game.Data.Turn].Sleep)
                {
                  int num = 0;
                  int regimeCounter = this.game.Data.RegimeCounter;
                  for (index1 = 0; index1 <= regimeCounter; index1 += 1)
                  {
                    if (this.game.Data.RegimeObj[index1].UberRegime == this.game.Data.Turn)
                      num += 1;
                  }
                  if (num == 0)
                  {
                    this.game.HandyFunctionsObj.GameLoop_SleepingRegime();
                    if (this.game.Data.RegimeObj[this.game.Data.Turn].Sleep)
                    {
                      this.game.EventRelatedObj.DoCheckEvents(11);
                      this.game.EditObj.Test = 1;
                    }
                  }
                }
                sleep = this.game.Data.RegimeObj[this.game.Data.Turn].Sleep;
              }
              if (this.game.Data.Round > 1)
                this.game.EditObj.CombatSim = false;
              if (this.game.EditObj.Test == 4)
              {
                if (!this.game.Data.RegimeObj[this.game.Data.Turn].AI && this.game.Data.Product == 7 & this.game.EditObj.TestEarlyCinematics == 0 & (double) this.game.Data.RuleVar[971] > 0.0)
                {
                  this.game.EventRelatedObj.DoCheckEvents(12);
                  if (this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round((double) this.game.Data.RuleVar[971]))].Length > -1)
                  {
                    this.game.EditObj.TestEarlyCinematics = 1;
                    if (DrawMod.TGame.EditObj.debugAiOnlyTillRound < this.game.Data.Round)
                    {
                      this.ExitTheLoopSub(s);
                      return;
                    }
                  }
                }
                if (this.game.Data.Round > 1)
                  this.game.EditObj.CombatSim = false;
                s = "Supply system";
                this.game.ProcessingObj.InitialAPPenalty(this.game.Data.Turn, false);
                this.game.HandyFunctionsObj.DoAntiInfraDammage();
                this.game.ProcessingObj.SetUberOn();
                int unitCounter = this.game.Data.UnitCounter;
                for (int index6 = 0; index6 <= unitCounter; index6 += 1)
                {
                  if (this.game.Data.UnitObj[index6].Regime == this.game.Data.Turn)
                    this.game.Data.UnitObj[index6].ClearLogs();
                  if (this.game.Data.UnitObj[index6].Regime == this.game.Data.Turn && (double) this.game.Data.RuleVar[403] > 0.0)
                  {
                    this.game.Data.UnitObj[index6].SupplyConsume = 0;
                    this.game.Data.UnitObj[index6].SupplyIn = 0;
                    this.game.Data.UnitObj[index6].SupplyInReq = 0;
                  }
                }
                int locCounter = this.game.Data.LocCounter;
                for (index1 = 0; index1 <= locCounter; index1 += 1)
                {
                  if (this.game.Data.LocObj[index1].X > -1 && this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index1].X, this.game.Data.LocObj[index1].Y].Regime == this.game.Data.Turn)
                  {
                    int logCounter = this.game.Data.LocObj[index1].LogCounter;
                    for (int index7 = 0; index7 <= logCounter; index7 += 1)
                    {
                      int num = this.game.Data.LocObj[index1].LogType[index7];
                      if (num < 2000)
                      {
                        int data1 = this.game.Data.LocObj[index1].LogData1[index7];
                        int data2 = this.game.Data.LocObj[index1].LogData2[index7];
                        int data3 = this.game.Data.LocObj[index1].LogData3[index7];
                        this.game.Data.LocObj[index1].AddLog(num + 2000, data1, data2, data3);
                      }
                    }
                    this.game.Data.LocObj[index1].ClearLogs(true, 0, 799);
                  }
                }
                if (this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1)
                  this.game.EventRelatedObj.DoCheckEvents(2);
                this.game.ProcessingObj.InitialAPPenalty(this.game.Data.Turn, false);
                if ((double) this.game.Data.RuleVar[955] > 0.0)
                {
                  int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID( Math.Round((double) this.game.Data.RuleVar[955]));
                  if (stringListById1 > -1)
                  {
                    for (int length1 = this.game.Data.StringListObj[stringListById1].Length; length1 >= 0; length1 += -1)
                    {
                      int num =  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length1, 0]));
                      if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length1, 9])) < this.game.Data.Round &  Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[length1, 1])) == this.game.Data.Turn)
                      {
                        int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID( Math.Round((double) this.game.Data.RuleVar[956]));
                        if (stringListById2 > -1)
                        {
                          for (int length2 = this.game.Data.StringListObj[stringListById2].Length; length2 >= 0; length2 += -1)
                          {
                            if ( Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[length2, 0])) == num)
                              this.game.Data.StringListObj[stringListById2].RemoveRow(length2);
                          }
                        }
                        this.game.Data.StringListObj[stringListById1].RemoveRow(length1);
                      }
                    }
                  }
                }
                if (this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1)
                  this.game.ProcessingObj.LocationProduction();
                if (this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1)
                  this.game.ProcessingObj.SetCapForUnitS();
                if ((double) this.game.Data.RuleVar[403] == 1.0)
                  this.game.ProcessingObj.LIS_SetNetwork(false);
                if ((double) this.game.Data.RuleVar[403] == 1.0)
                  this.game.ProcessingObj.LIS_LocationSupply();
                if ((double) this.game.Data.RuleVar[403] == 1.0)
                  this.game.ProcessingObj.LIS_UnitSupply(false);
                this.game.EventRelatedObj.DoCheckEvents(11);
                if ((double) this.game.Data.RuleVar[403] == 1.0)
                  this.game.ProcessingObj.LIS_LocationReturns(false);
                if ((double) this.game.Data.RuleVar[403] == 1.0)
                  this.game.ProcessingObj.LIS_UnitAutoReinforce();
                if ((double) this.game.Data.RuleVar[403] == 1.0)
                  this.game.ProcessingObj.LIS_UnitAutoReinforceReturns(true, false);
                if ((double) this.game.Data.RuleVar[403] == 1.0)
                  this.game.ProcessingObj.LIS_UnitAutoReinforceReturns(false, true);
                if ((double) this.game.Data.RuleVar[403] != 1.0 & this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1 & (double) this.game.Data.RuleVar[337] == 1.0)
                  this.game.ProcessingObj.DoAutoReinforce();
              }
              if (this.game.EditObj.Test == 5)
              {
                this.game.EditObj.TestEarlyCinematics = 0;
                s = "Supply system";
              }
              if (this.game.EditObj.Test == 6)
              {
                s = "Supply consumption";
                if ((double) this.game.Data.RuleVar[333] == 0.0 & (double) this.game.Data.RuleVar[403] < 1.0 && this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1)
                  this.game.ProcessingObj.DoSupplySystem();
                if ((double) this.game.Data.RuleVar[402] > 0.0 & this.game.Data.Product > 6)
                {
                  this.game.EventRelatedObj.DoCheckSpecificEvent( Math.Round((double) this.game.Data.RuleVar[402]));
                  if (this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1)
                    this.game.ProcessingObj.DoAutoRecoverLocations(this.game.Data.Turn);
                  if (this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1 & (double) this.game.Data.RuleVar[79] == 1.0)
                    this.game.ProcessingObj.AutoConquerNeutral(this.game.Data.Turn);
                }
                else
                {
                  if (this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1)
                    this.game.ProcessingObj.ApToSf();
                  if (this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1)
                    this.game.ProcessingObj.DoEntrench(this.game.Data.Turn);
                  if (this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1)
                    this.game.ProcessingObj.DoMorale(this.game.Data.Turn);
                  if (this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1)
                    this.game.ProcessingObj.DoAutoRecoverLocations(this.game.Data.Turn);
                  if (this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1)
                    this.game.ProcessingObj.DoTraining(this.game.Data.Turn);
                  if (this.game.Data.RegimeObj[this.game.Data.Turn].UberRegime == -1 & (double) this.game.Data.RuleVar[79] == 1.0)
                    this.game.ProcessingObj.AutoConquerNeutral(this.game.Data.Turn);
                }
                this.game.ProcessingObj.SetUberOff();
              }
              if (this.game.EditObj.Test == 7)
              {
                s = "Miscellaneous calculations";
                if (this.game.Data.RegimeObj[this.game.Data.Turn].Sleep & sleep)
                {
                  this.game.ProcessingObj.SetInitialReconAndZOC(this.game.Data.Turn);
                  this.game.EditObj.Test = 1;
                }
              }
              if (this.game.EditObj.Test == 8)
              {
                this.game.ProcessingObj.SetInitialReconAndZOC(this.game.Data.Turn);
                this.game.ProcessingObj.DoDeckCards();
                this.game.ProcessingObj.DoAutoEvents();
                this.game.EventRelatedObj.DoCheckEvents(3);
                this.game.ProcessingObj.SetExtraStat(this.game.Data.Turn);
                this.game.ProcessingObj.IntialZOCConquestCheck(this.game.Data.Turn);
                if (!this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                  this.game.HandyFunctionsObj.SetInitialXY(this.game.Data.Turn);
                if (!this.game.Data.RegimeObj[this.game.Data.Turn].AI)
                {
                  s = "Start turn";
                  this.game.EditObj.UnitSelected = -1;
                  this.game.EditObj.OrderType = 0;
                  this.game.Data.InTurn = false;
                  this.game.EditObj.TempAIInitialized = false;
                  this.game.EditObj.SFSelected = -1;
                  this.game.EventRelatedObj.DoCheckEvents(8);
                  this.game.ProcessingObj.ClearTempUnitVariables();
                  if (DrawMod.TGame.EditObj.debugAiOnlyTillRound < this.game.Data.Round)
                  {
                    this.ExitTheLoopSub(s);
                    return;
                  }
                  this.game.ProcessingObj.ClearTempUnitVariables();
                  this.game.EventRelatedObj.DoCheckEvents(4);
                  this.game.EditObj.Test = 0;
                  this.game.EventRelatedObj.DoCheckEvents(5);
                }
                else
                {
                  this.game.EventRelatedObj.DoCheckEvents(8);
                  this.game.ProcessingObj.ClearTempUnitVariables();
                  this.game.EventRelatedObj.DoCheckEvents(4);
                  s = "Setting up initialization";
                }
              }
              if (this.game.EditObj.Test == 9)
              {
                s = "AI for " + this.game.Data.RegimeObj[this.game.Data.Turn].Name + " is playing. Executing";
                if ((double) this.game.Data.RuleVar[814] == 0.0)
                {
                  if (this.game.Data.Product >= 7 && Information.IsNothing((object) this.game.DC2AIObj))
                  {
                    this.game.DC2AIObj = (DC2AIClass) null;
                    this.game.DC2AIObj = new DC2AIClass(this.game);
                  }
                  this.game.AIRunning = true;
                  this.game.AIThreadRunning = true;
                  let mut game: GameClass = this.game;
                  DC2AIClass dc2AiObj = this.game.DC2AIObj;
                  Thread thread = new Thread((ParameterizedThreadStart) (a0 => dc2AiObj.InitAI(Conversions.ToBoolean(a0))));
                  game.AIThread = thread;
                  this.game.AIThread.Name = "AI Init Thread";
                  this.game.AIThread.Start((object) true);
                }
              }
              if (this.game.EditObj.Test == 10 && (double) this.game.Data.RuleVar[814] == 0.0)
              {
                if (this.game.Data.Turn == 6)
                  index1 = index1;
                bool flag = true;
                if (this.game.Data.UseAI == 2 & !Information.IsNothing((object) this.game.DC2AIObj) && this.game.DC2AIObj.initExitCode == 1)
                {
                  flag = false;
                  this.game.DC2AIObj.initExitCode = 0;
                }
                if (flag)
                {
                  this.game.AIRunning = true;
                  this.game.AIThreadRunning = true;
                  if (this.game.Data.UseAI == 0)
                    this.game.AIThread = new Thread(new ThreadStart(this.game.AIObj.ExecuteAI));
                  if (this.game.Data.UseAI == 1)
                    this.game.AIThread = new Thread(new ThreadStart(this.game.NewAIObj.ExecuteAI));
                  if (this.game.Data.UseAI == 2)
                    this.game.AIThread = new Thread(new ThreadStart(this.game.DC2AIObj.ExecuteAI));
                  this.game.AIThread.Name = "AI Execute Thread";
                  this.game.AIThread.Start();
                }
              }
            }
            while (this.game.EditObj.Test < 11);
            this.game.EditObj.Test = 0;
            s = "Finished";
            this.DoingAI = true;
            if ((double) this.game.Data.RuleVar[814] == 0.0)
            {
              if (this.game.Data.UseAI == 0)
                this.game.AIObj.CloseAI();
              if (this.game.Data.UseAI == 1)
                this.game.NewAIObj.CloseAI();
              if (this.game.Data.UseAI == 2)
                this.game.DC2AIObj.CloseAI();
            }
            if (this.game.Data.Product >= 7 && this.game.Data.UseAI == 2)
            {
              this.game.DC2AIObj = (DC2AIClass) null;
              GC.Collect();
              Application.DoEvents();
            }
            if (this.game.Data.DontShowAIMove)
            {
              this.game.EditObj.AIMoving = false;
              this.game.EditObj.TempAIWatch = false;
            }
            int unitCounter1 = this.game.Data.UnitCounter;
            for (int index = 0; index <= unitCounter1; index += 1)
              this.game.Data.UnitObj[index].TempUnitSelectable = false;
            this.DoingAI = false;
          }
          while (this.game.HandyFunctionsObj.GetHumanPlayers() != 0);
          if (this.game.EditObj.Screenshoton)
            this.game.HandyFunctionsObj.doscreenshot("ai", 0);
          int num1 = this.game.EditObj.AutoSave ? 1 : 0;
        }
        while (!(this.game.EditObj.debugAiOnlyTillRound < this.game.Data.Round - 1 & this.game.Data.Winner > -1));
        ProjectData.EndApp();
      }
    }

    pub void ExitTheLoopSub(string s)
    {
      this.game.se1Running = false;
      if (!(this.game.EditObj.Test == 9 | this.game.EditObj.Test == 10))
        this.game.EditObj.TempAIString = s;
      if (this.game.Data.Turn <= -1 || this.game.Data.RegimeObj[this.game.Data.Turn].AI)
        return;
      this.game.EditObj.RealRound = this.game.Data.Round;
      this.game.EditObj.RealTurn = this.game.Data.Turn;
    }

    pub void DoPresentStats()
    {
      int regimeCounter = this.game.Data.RegimeCounter;
      for (int index1 = 0; index1 <= regimeCounter; index1 += 1)
      {
        this.game.Data.RegimeObj[index1].SPresent = (int[,]) Utils.CopyArray((Array) this.game.Data.RegimeObj[index1].SPresent, (Array) new int[this.game.Data.SFTypeCounter + 1, this.game.Data.Round + 1 + 1]);
        int sfTypeCounter = this.game.Data.SFTypeCounter;
        for (int index2 = 0; index2 <= sfTypeCounter; index2 += 1)
        {
          this.game.Data.RegimeObj[index1].SPresent[index2, 0] = 0;
          this.game.Data.RegimeObj[index1].SPresent[index2, this.game.Data.Round] = 0;
        }
      }
      int unitCounter = this.game.Data.UnitCounter;
      for (int index3 = 0; index3 <= unitCounter; index3 += 1)
      {
        if (this.game.Data.UnitObj[index3].PreDef == -1)
        {
          int regime = this.game.Data.UnitObj[index3].Regime;
          int sfCount = this.game.Data.UnitObj[index3].SFCount;
          for (int index4 = 0; index4 <= sfCount; index4 += 1)
          {
            int sf = this.game.Data.UnitObj[index3].SFList[index4];
            int[,] spresent = this.game.Data.RegimeObj[regime].SPresent;
            int[,] numArray = spresent;
            int type = this.game.Data.SFObj[sf].Type;
            int index5 = type;
            int round = this.game.Data.Round;
            int index6 = round;
            int num = spresent[type, round] + this.game.Data.SFObj[sf].Qty;
            numArray[index5, index6] = num;
          }
        }
      }
    }
  }
}
