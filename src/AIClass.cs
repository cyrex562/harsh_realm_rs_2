// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.AIClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class AIClass
  {
    public int[] TempAvgUnits;
    public float[,] CombatMatrix;
    private GameClass game;
    private string[] LogTxt;
    private int LogCounter;
    private string[] LogTxt2;
    private int LogCounter2;
    public int[,] HexOA;
    public int OACount;
    public int[,] HexContinent;
    public int ContinentCount;
    public int[,] HexSA;
    public int[,] HexPlan;
    public int[,] HexBackPlan;
    public int[,] HexSeaSA;
    public int[,] HexSAWithoutTemp;
    public int SACount;
    public SAClass[] SAObj;
    public int[,] AIVP;
    public int[,] Matrix1;
    public int[,] Matrix2;
    public int[] UnitMovePhase;
    public int TPlanCount;
    public AIPlanClass[] TPlanObj;
    public const int PLANLANDFRONT = 20;
    public const int PLANLANDRESERVE = 30;
    public const int PLANBACK = 40;
    public const int PLANOLDLANDFRONT = 50;
    public const int STANDATTACK = 1;
    public const int STANDDEFEND = 2;
    public const int STANDRETREAT = 3;
    public const int STANDHOME = 4;
    public const int STANDRAID = 5;
    public const int STANDSEASUP = 6;
    public const int STANDAMPH = 7;
    public const int STANDHOME2 = 8;
    public const int ROLESTAFF = 1;
    public const int ROLELANDCAP = 2;
    public const int ROLESEACAP = 3;
    public const int ROLEAIRCAP = 4;
    public const int ROLEENGINEER = 5;
    public const int ROLEINFANTRY = 6;
    public const int ROLEINFANTRYSUPPORT = 7;
    public const int ROLEARTILLERY = 8;
    public const int ROLEMOBILIZER = 9;
    public const int ROLEARMOUR = 10;
    public const int ROLEPARATROOP = 11;
    public const int ROLEAA = 12;
    public const int ROLEFIGHTER = 13;
    public const int ROLETACTICALBOMBER = 14;
    public const int ROLESTRATEGICBOMBER = 15;
    public const int ROLETRANSPORTER = 16;
    public const int ROLECARGOSHIP = 17;
    public const int ROLESEASUPRIORITY = 18;
    public const int ROLERAIDER = 19;
    public const int GOALINFANTRY = 1;
    public const int GOALARMOUR = 2;
    public const int GOALARTILLERY = 3;
    public const int GOALENGINEER = 4;
    public const int GOALAIRSUPPORT = 5;
    public const int GOALSTRATEGICBOMBING = 6;
    public const int GOALTRANSPORT = 7;
    public const int GOALCARGO = 8;
    public const int GOALNAVALWAR = 9;
    public const int GOALRAIDER = 10;

    public AIClass(GameClass tgame)
    {
      this.TempAvgUnits = new int[2];
      this.CombatMatrix = new float[2, 2];
      this.LogTxt = new string[1];
      this.LogTxt2 = new string[1];
      this.HexOA = new int[1, 1];
      this.HexContinent = new int[1, 1];
      this.HexSA = new int[1, 1];
      this.HexPlan = new int[1, 1];
      this.HexBackPlan = new int[1, 1];
      this.HexSeaSA = new int[1, 1];
      this.HexSAWithoutTemp = new int[1, 1];
      this.SAObj = new SAClass[1];
      this.AIVP = new int[1, 1];
      this.Matrix1 = new int[1, 1];
      this.Matrix2 = new int[1, 1];
      this.UnitMovePhase = new int[1];
      this.TPlanObj = new AIPlanClass[1];
      this.game = tgame;
    }

    public void ExecuteAI()
    {
      object[,] objArray = new object[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      float aiConservative = this.game.Data.RegimeObj[this.game.Data.Turn].AIConservative;
      int tplanCount1 = this.TPlanCount;
      DateTime now;
      for (int index = 1; index <= tplanCount1; ++index)
      {
        if (this.TPlanObj[index].Type == 40 && this.TPlanObj[index].FriendlyUnitCount > 0)
        {
          Application.DoEvents();
          now = DateTime.Now;
          long num1 = (long) Math.Round((double) now.Ticks / 1000.0);
          this.ExecLoadUnitOnBoard(index);
          this.ExecuteMovement(index, 1);
          this.ExecUnloadUnit(index);
          now = DateTime.Now;
          this.AddLog2("backplan ops 1 took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num1)));
          now = DateTime.Now;
          long num2 = (long) Math.Round((double) now.Ticks / 1000.0);
          this.ExecuteAirAttack(index, 1f * aiConservative);
          now = DateTime.Now;
          this.AddLog2("backplan ops 2 took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num2)));
          now = DateTime.Now;
          long num3 = (long) Math.Round((double) now.Ticks / 1000.0);
          this.ExecuteNavalAttacks(index, 1f * aiConservative);
          now = DateTime.Now;
          this.AddLog2("backplan ops 3 took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num3)));
          now = DateTime.Now;
          long num4 = (long) Math.Round((double) now.Ticks / 1000.0);
          this.ExecuteEngineer(index);
          this.ExecuteMovement(index, 2);
          this.ExecJoinUnits(index);
          this.ExecuteEngineer(index);
          this.ExecuteMovement(index, 2);
          this.ExecuteEngineer(index);
          this.ExecuteEngineer(index);
          this.ExecuteEngineer(index);
          this.ExecuteEngineer(index);
          now = DateTime.Now;
          this.AddLog2("backplan ops 4 took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num4)));
        }
      }
      int tplanCount2 = this.TPlanCount;
      for (int index = 1; index <= tplanCount2; ++index)
      {
        if (this.TPlanObj[index].Type == 50 && this.TPlanObj[index].FriendlyUnitCount > 0)
        {
          Application.DoEvents();
          now = DateTime.Now;
          long num = (long) Math.Round((double) now.Ticks / 1000.0);
          this.ExecuteMovement(index, 1);
          this.ExecuteEngineer(index);
          this.ExecuteEngineer(index);
          this.ExecuteEngineer(index);
          this.ExecuteEngineer(index);
          this.ExecuteEngineer(index);
          now = DateTime.Now;
          this.AddLog2("executeOLDlandfronts took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num)));
        }
      }
      int tplanCount3 = this.TPlanCount;
      for (int plannr = 1; plannr <= tplanCount3; ++plannr)
      {
        if (this.TPlanObj[plannr].Type == 20 && this.TPlanObj[plannr].FriendlyUnitCount > 0)
        {
          Application.DoEvents();
          now = DateTime.Now;
          long num = (long) Math.Round((double) now.Ticks / 1000.0);
          this.ExecuteArtilleryAttack(plannr, 1f, 1);
          now = DateTime.Now;
          this.AddLog2("executeartilleryattack took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num)));
        }
      }
      int tplanCount4 = this.TPlanCount;
      for (int index = 1; index <= tplanCount4; ++index)
      {
        if (this.TPlanObj[index].Type == 20)
        {
          if (this.TPlanObj[index].FriendlyUnitCount > 0)
          {
            Application.DoEvents();
            if ((double) this.game.Data.RuleVar[225] == 0.0)
            {
              now = DateTime.Now;
              long num5 = (long) Math.Round((double) now.Ticks / 1000.0);
              if (this.TPlanObj[index].Stand == 2)
                this.ExecuteLandFrontAttacks(index, 2f * aiConservative);
              else if (this.TPlanObj[index].Stand == 1)
              {
                float d = this.TPlanObj[index].WeightEnemyForceUnMod / this.TPlanObj[index].WeightFriendlyForce;
                if ((double) this.TPlanObj[index].WeightEnemyForce / (double) this.TPlanObj[index].WeightFriendlyForce < (double) d)
                  d = this.TPlanObj[index].WeightEnemyForce / this.TPlanObj[index].WeightFriendlyForce;
                float num6 = (float) Math.Sqrt((double) d);
                if ((double) num6 < 0.25)
                  num6 = 0.25f;
                if ((double) num6 > 1.0)
                  num6 = 1f;
                this.ExecuteLandFrontAttacks(index, 1.5f * num6 * aiConservative);
              }
              else if (this.TPlanObj[index].Stand == 3)
                this.ExecuteLandFrontAttacks(index, 2.5f * aiConservative);
              now = DateTime.Now;
              this.AddLog2("ExecuteLandFrontAttacks took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num5)));
              now = DateTime.Now;
              long num7 = (long) Math.Round((double) now.Ticks / 1000.0);
              this.ExecuteMovement(index, 1);
              now = DateTime.Now;
              this.AddLog2("ExecuteMovement took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num7)));
            }
            else
            {
              Application.DoEvents();
              now = DateTime.Now;
              long num8 = (long) Math.Round((double) now.Ticks / 1000.0);
              this.ExecuteMovement(index, 1);
              now = DateTime.Now;
              this.AddLog2("ExecuteMovement took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num8)));
              now = DateTime.Now;
              long num9 = (long) Math.Round((double) now.Ticks / 1000.0);
              if (this.TPlanObj[index].Stand == 2)
                this.ExecuteLandFrontAttacks(index, 2f * aiConservative);
              else if (this.TPlanObj[index].Stand == 1)
              {
                float d = this.TPlanObj[index].WeightEnemyForceUnMod / this.TPlanObj[index].WeightFriendlyForce;
                if ((double) this.TPlanObj[index].WeightEnemyForce / (double) this.TPlanObj[index].WeightFriendlyForce < (double) d)
                  d = this.TPlanObj[index].WeightEnemyForce / this.TPlanObj[index].WeightFriendlyForce;
                float num10 = (float) Math.Sqrt((double) d);
                if ((double) num10 < 0.25)
                  num10 = 0.25f;
                if ((double) num10 > 1.0)
                  num10 = 1f;
                this.ExecuteLandFrontAttacks(index, 1.5f * num10 * aiConservative);
              }
              else if (this.TPlanObj[index].Stand == 3)
                this.ExecuteLandFrontAttacks(index, 2.5f * aiConservative);
              now = DateTime.Now;
              this.AddLog2("ExecuteLandFrontAttacks took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num9)));
            }
            Application.DoEvents();
            now = DateTime.Now;
            long num11 = (long) Math.Round((double) now.Ticks / 1000.0);
            this.ExecuteEngineer(index);
            now = DateTime.Now;
            this.AddLog2("ExecuteEngineer took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num11)));
            Application.DoEvents();
            now = DateTime.Now;
            long num12 = (long) Math.Round((double) now.Ticks / 1000.0);
            this.ExecuteArtilleryAttack(index, 1f, 2);
            now = DateTime.Now;
            this.AddLog2("ExecuteArtilleryAttack took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num12)));
            if (this.TPlanObj[index].Stand == 2)
              this.ExecuteLandFrontAttacks(index, 2.5f * aiConservative);
            else if (this.TPlanObj[index].Stand == 1)
            {
              float d = this.TPlanObj[index].WeightEnemyForceUnMod / this.TPlanObj[index].WeightFriendlyForce;
              if ((double) this.TPlanObj[index].WeightEnemyForce / (double) this.TPlanObj[index].WeightFriendlyForce < (double) d)
                d = this.TPlanObj[index].WeightEnemyForce / this.TPlanObj[index].WeightFriendlyForce;
              float num13 = (float) Math.Sqrt((double) d);
              if ((double) num13 < 0.25)
                num13 = 0.25f;
              if ((double) num13 > 1.0)
                num13 = 1f;
              this.ExecuteLandFrontAttacks(index, 2f * num13 * aiConservative);
            }
            else if (this.TPlanObj[index].Stand == 3)
              this.ExecuteLandFrontAttacks(index, 3f * aiConservative);
            this.ExecuteMovement(index, 2);
            this.ExecJoinUnits(index);
            this.ExecuteEngineer(index);
            this.ExecuteEngineer(index);
            this.ExecuteEngineer(index);
            this.ExecuteEngineer(index);
          }
        }
        else if (this.TPlanObj[index].Type == 30)
        {
          Application.DoEvents();
          this.ExecuteMovement(index, 1);
        }
      }
      Application.DoEvents();
      now = DateTime.Now;
      long num14 = (long) Math.Round((double) now.Ticks / 1000.0);
      this.ExecJoinUnits();
      now = DateTime.Now;
      this.AddLog2("ExecuteEngineer took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num14)));
      Application.DoEvents();
      now = DateTime.Now;
      long num15 = (long) Math.Round((double) now.Ticks / 1000.0);
      this.ExecChangeHQ();
      now = DateTime.Now;
      this.AddLog2("ExecuteChangeHQ+Staff up took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num15)));
      Application.DoEvents();
      now = DateTime.Now;
      long num16 = (long) Math.Round((double) now.Ticks / 1000.0);
      this.ExecSplitLandUnits();
      now = DateTime.Now;
      this.AddLog2("ExecSplitLandunits took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num16)));
      Application.DoEvents();
      now = DateTime.Now;
      long num17 = (long) Math.Round((double) now.Ticks / 1000.0);
      this.ExecNewairunits(1);
      now = DateTime.Now;
      this.AddLog2("ExecNewairunits took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num17)));
      Application.DoEvents();
      now = DateTime.Now;
      long num18 = (long) Math.Round((double) now.Ticks / 1000.0);
      this.ExecNewLandUnits(1);
      now = DateTime.Now;
      this.AddLog2("Execnewlandunits took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num18)));
      Application.DoEvents();
      now = DateTime.Now;
      long num19 = (long) Math.Round((double) now.Ticks / 1000.0);
      this.ExecNewNavyunits(1);
      now = DateTime.Now;
      this.AddLog2("Execnewnavyunits took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num19)));
      Application.DoEvents();
      now = DateTime.Now;
      long num20 = (long) Math.Round((double) now.Ticks / 1000.0);
      this.ExecDisbandForTransfer();
      now = DateTime.Now;
      this.AddLog2("Execdisbandfortransfer took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num20)));
      Application.DoEvents();
      now = DateTime.Now;
      long num21 = (long) Math.Round((double) now.Ticks / 1000.0);
      this.ExecLandTransfers(1);
      now = DateTime.Now;
      this.AddLog2("Execlandtransfers took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num21)));
      if ((double) this.game.Data.RuleVar[253] > 0.0)
      {
        Application.DoEvents();
        now = DateTime.Now;
        long num22 = (long) Math.Round((double) now.Ticks / 1000.0);
        this.ExecNewLandUnits(2);
        now = DateTime.Now;
        this.AddLog2("Execnewlandunits took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num22)));
        Application.DoEvents();
        now = DateTime.Now;
        long num23 = (long) Math.Round((double) now.Ticks / 1000.0);
        this.ExecLandTransfers(2);
        now = DateTime.Now;
        this.AddLog2("Execlandtransfers took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num23)));
      }
      Application.DoEvents();
      now = DateTime.Now;
      long num24 = (long) Math.Round((double) now.Ticks / 1000.0);
      this.InitResearch();
      now = DateTime.Now;
      this.AddLog2("InitResearch() took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num24)));
      Application.DoEvents();
      now = DateTime.Now;
      long num25 = (long) Math.Round((double) now.Ticks / 1000.0);
      this.ExecAirTransfers(1);
      now = DateTime.Now;
      this.AddLog2("Execairtransfers took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num25)));
      Application.DoEvents();
      now = DateTime.Now;
      long num26 = (long) Math.Round((double) now.Ticks / 1000.0);
      this.ExecNavyTransfers(1);
      now = DateTime.Now;
      this.AddLog2("Execnavytransfers took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num26)));
      Application.DoEvents();
      now = DateTime.Now;
      long num27 = (long) Math.Round((double) now.Ticks / 1000.0);
      this.ExecUpgrades();
      now = DateTime.Now;
      this.AddLog2("ExecUpgrades took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num27)));
      Application.DoEvents();
      now = DateTime.Now;
      long num28 = (long) Math.Round((double) now.Ticks / 1000.0);
      this.BlowBridges();
      now = DateTime.Now;
      this.AddLog2("blowbridges took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num28)));
      Application.DoEvents();
      now = DateTime.Now;
      long num29 = (long) Math.Round((double) now.Ticks / 1000.0);
      this.EmptyHQ();
      now = DateTime.Now;
      this.AddLog2("emptyHQ took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num29)));
      Application.DoEvents();
      now = DateTime.Now;
      long num30 = (long) Math.Round((double) now.Ticks / 1000.0);
      this.ExecSetProduction();
      now = DateTime.Now;
      this.AddLog2("Execsetproduction took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num30)));
      if ((double) this.game.Data.RuleVar[875] == 1.0)
      {
        Application.DoEvents();
        now = DateTime.Now;
        long num31 = (long) Math.Round((double) now.Ticks / 1000.0);
        this.ExecResourceComplient();
        now = DateTime.Now;
        this.AddLog2("ExecResourceComplient took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num31)));
      }
      Application.DoEvents();
      now = DateTime.Now;
      long num32 = (long) Math.Round((double) now.Ticks / 1000.0);
      this.ExecSendStaffUp();
      now = DateTime.Now;
      this.AddLog2("ExecSendStaffUp took " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num32)));
      for (int unitCounter = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
      {
        if (this.game.Data.UnitObj[unitCounter].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unitCounter].PreDef == -1 & !this.game.Data.UnitObj[unitCounter].IsHQ && this.game.Data.UnitObj[unitCounter].SFCount == -1)
          this.game.ProcessingObj.DoDisbandUnit(unitCounter);
      }
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn)
          this.game.Data.UnitObj[index].AIPlanRef = this.game.Data.UnitObj[index].AIPlanNr <= 0 ? (AIPlanClass) null : this.TPlanObj[this.game.Data.UnitObj[index].AIPlanNr];
      }
      this.game.AIRunning = false;
    }

    public void InitAIOnlyDim()
    {
      object[,] objArray = new object[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.HexOA = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.HexContinent = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.HexSA = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.HexSAWithoutTemp = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.HexPlan = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.HexBackPlan = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.HexSeaSA = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.UnitMovePhase = new int[this.game.Data.UnitCounter + 1000 + 1];
      this.LogTxt = new string[1];
      this.SAObj = new SAClass[1];
      this.SACount = 0;
      this.LogCounter = -1;
      this.OACount = 0;
      this.TPlanCount = 0;
      this.ContinentCount = 0;
    }

    public void InitAI()
    {
      object[,] objArray = new object[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.HexOA = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.HexContinent = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.HexSA = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.HexSAWithoutTemp = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.HexPlan = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.HexBackPlan = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.HexSeaSA = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.AIVP = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      this.UnitMovePhase = new int[this.game.Data.UnitCounter + 1000 + 1];
      this.LogTxt = new string[1];
      this.SAObj = new SAClass[1];
      this.SACount = 0;
      this.LogCounter = -1;
      this.LogCounter2 = -1;
      this.OACount = 0;
      this.TPlanCount = 0;
      this.game.EditObj.OrderMap = 0;
      this.game.EditObj.MapSelected = 0;
      this.game.EditObj.TargetMap = 0;
      this.ContinentCount = 0;
      this.AddLog2("INIT AI");
      this.InitRandomAI();
      this.TPlanObj = new AIPlanClass[1];
      Application.DoEvents();
      long num1 = (long) Math.Round((double) DateTime.Now.Ticks / 1000.0);
      this.InitAIVP();
      this.AddLog2("InitAIVP took " + Conversion.Str((object) ((double) DateTime.Now.Ticks / 1000.0 - (double) num1)));
      this.MakeCombatMatrix();
      if ((double) this.game.Data.RuleVar[903] > 0.0)
      {
        Application.DoEvents();
        DateTime now = DateTime.Now;
        long num2 = (long) Math.Round((double) now.Ticks / 1000.0);
        this.InitDeclareWar();
        now = DateTime.Now;
        this.AddLog2("InitDeclareWar " + Conversion.Str((object) ((double) now.Ticks / 1000.0 - (double) num2)));
      }
      this.InitDecisions();
      long num3 = (long) Math.Round((double) DateTime.Now.Ticks / 1000.0);
      this.InitFindOA();
      this.AddLog2("InitFindOA() took " + Conversion.Str((object) ((double) DateTime.Now.Ticks / 1000.0 - (double) num3)));
      long num4 = (long) Math.Round((double) DateTime.Now.Ticks / 1000.0);
      this.InitFindContinent();
      this.AddLog2("InitFindContinent() took " + Conversion.Str((object) ((double) DateTime.Now.Ticks / 1000.0 - (double) num4)));
      Application.DoEvents();
      long num5 = (long) Math.Round((double) DateTime.Now.Ticks / 1000.0);
      this.InitGetSA();
      this.AddLog2("InitGetSA() took " + Conversion.Str((object) ((double) DateTime.Now.Ticks / 1000.0 - (double) num5)));
      DateTime now1 = DateTime.Now;
      long num6 = (long) Math.Round((double) now1.Ticks / 1000.0);
      this.InitGetSeaSA();
      now1 = DateTime.Now;
      this.AddLog2("InitGetSeaSA() took " + Conversion.Str((object) ((double) now1.Ticks / 1000.0 - (double) num6)));
      Application.DoEvents();
      long num7 = (long) Math.Round((double) DateTime.Now.Ticks / 1000.0);
      this.InitSARelations();
      this.AddLog2("InitSARelations() took " + Conversion.Str((object) ((double) DateTime.Now.Ticks / 1000.0 - (double) num7)));
      DateTime now2 = DateTime.Now;
      long num8 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitTPlans();
      now2 = DateTime.Now;
      this.AddLog2("InitTPlans() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num8)));
      now2 = DateTime.Now;
      long num9 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitPlanFrontline();
      now2 = DateTime.Now;
      this.AddLog2("InitPlanFrontline() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num9)));
      Application.DoEvents();
      now2 = DateTime.Now;
      long num10 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitUnits();
      now2 = DateTime.Now;
      this.AddLog2("InitUnits() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num10)));
      now2 = DateTime.Now;
      long num11 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitLandReserves();
      now2 = DateTime.Now;
      this.AddLog2("InitLandReserves() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num11)));
      Application.DoEvents();
      now2 = DateTime.Now;
      long num12 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitLandReserveMetaHQ();
      now2 = DateTime.Now;
      this.AddLog2("InitLandReserveMetaHQ() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num12)));
      Application.DoEvents();
      now2 = DateTime.Now;
      long num13 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitEmergencyUnitSwitch();
      now2 = DateTime.Now;
      this.AddLog2("InitEmergencyUnitSwitch() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num13)));
      Application.DoEvents();
      now2 = DateTime.Now;
      long num14 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitTPlanForceBalance();
      now2 = DateTime.Now;
      this.AddLog2("InitTPlanForceBalance() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num14)));
      now2 = DateTime.Now;
      long num15 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitTPlanForceBalanceNavy();
      now2 = DateTime.Now;
      this.AddLog2("InitTPlanForceBalanceNavy() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num15)));
      Application.DoEvents();
      now2 = DateTime.Now;
      long num16 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitTPlanStrategicImportance();
      now2 = DateTime.Now;
      this.AddLog2("InitTPlanStrategicImportance() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num16)));
      Application.DoEvents();
      now2 = DateTime.Now;
      long num17 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitTransferUnits();
      now2 = DateTime.Now;
      this.AddLog2("InitAIVP took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num17)));
      Application.DoEvents();
      now2 = DateTime.Now;
      long num18 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitPlanLevelAnalysis();
      now2 = DateTime.Now;
      this.AddLog2("InitPlanLevelAnalysis() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num18)));
      now2 = DateTime.Now;
      long num19 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitTacticalHQ();
      now2 = DateTime.Now;
      this.AddLog2("InitTacticalHQ() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num19)));
      Application.DoEvents();
      now2 = DateTime.Now;
      long num20 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitTPlanAPCost();
      now2 = DateTime.Now;
      this.AddLog2("InitTPlanAPCost() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num20)));
      now2 = DateTime.Now;
      long num21 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitUnitGoals();
      now2 = DateTime.Now;
      this.AddLog2("InitUnitGoals() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num21)));
      Application.DoEvents();
      now2 = DateTime.Now;
      long num22 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitAirTransferUnits();
      now2 = DateTime.Now;
      this.AddLog2("InitAirTransferUnits() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num22)));
      Application.DoEvents();
      now2 = DateTime.Now;
      long num23 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitNavyTransferUnits();
      now2 = DateTime.Now;
      this.AddLog2("InitNavyTransferUnits() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num23)));
      Application.DoEvents();
      now2 = DateTime.Now;
      long num24 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitStrategicHQAnalysis();
      now2 = DateTime.Now;
      this.AddLog2("InitStrategicHQAnalysis() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num24)));
      Application.DoEvents();
      now2 = DateTime.Now;
      long num25 = (long) Math.Round((double) now2.Ticks / 1000.0);
      this.InitRiverLine();
      now2 = DateTime.Now;
      this.AddLog2("InitRiverLine() took " + Conversion.Str((object) ((double) now2.Ticks / 1000.0 - (double) num25)));
      this.InitSetStandingOrders();
      Application.DoEvents();
      this.InitShowStats();
      this.game.EventRelatedObj.DoCheckEvents(6);
    }

    public void ExecuteEngineer(int plannr)
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      SimpleList simpleList = new SimpleList();
      if ((double) this.game.Data.RuleVar[211] < 1.0)
        return;
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].AIPlanNr == plannr & this.game.Data.UnitObj[unr].AIUnitGoal == 4)
        {
          int engcount;
          ++engcount;
          Coordinate engineerCoord = this.GetEngineerCoord(engcount, plannr);
          if (engineerCoord.onmap && this.game.Data.UnitObj[unr].X == engineerCoord.x & this.game.Data.UnitObj[unr].Y == engineerCoord.y)
          {
            Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(engineerCoord.x, engineerCoord.y, engineerCoord.map, engineerCoord.data1);
            if (coordinate.onmap)
            {
              this.game.HandyFunctionsObj.InfraHexHighlight(engineerCoord.x, engineerCoord.y, engineerCoord.map, unr);
              if (this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y] == 0)
              {
                this.game.ProcessingObj.BuildInfra(unr, engineerCoord.x, engineerCoord.y, engineerCoord.map, engineerCoord.data1 - 1);
                this.AddLog(this.game.Data.UnitObj[unr].Name + " did infra construction from " + Conversion.Str((object) engineerCoord.x) + "," + Conversion.Str((object) engineerCoord.y) + " to " + Conversion.Str((object) coordinate.x) + "," + Conversion.Str((object) coordinate.y));
              }
            }
          }
        }
      }
    }

    public void ExecUpgrades()
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int tplanCount = this.TPlanCount;
      for (int index = 1; index <= tplanCount; ++index)
      {
        int hq = this.TPlanObj[index].HQ;
        if (hq > -1 && this.game.Data.UnitObj[hq].IsHQ)
        {
          this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[hq].Regime, (int) Math.Round((double) this.game.Data.RuleVar[99]), 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y, 0, allowshoredrop: true, SeaBlock: true);
          int unitCounter = this.game.Data.UnitCounter;
          for (int unr = 0; unr <= unitCounter; ++unr)
          {
            if (this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && (double) this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] <= (double) this.game.Data.RuleVar[51])
            {
              for (int sfCount = this.game.Data.UnitObj[unr].SFCount; sfCount >= 0; sfCount += -1)
              {
                int sf = this.game.Data.UnitObj[unr].SFList[sfCount];
                if (this.game.HandyFunctionsObj.CanUpgrade(sf, unr))
                {
                  int qty = this.game.HandyFunctionsObj.CanUpgradeMax(sf, unr, hq);
                  if (qty > this.game.Data.SFObj[sf].Qty)
                    qty = this.game.Data.SFObj[sf].Qty;
                  if (qty > 0)
                    this.game.ProcessingObj.DoUpgrade(unr, sf, qty, hq);
                }
              }
            }
          }
        }
      }
    }

    public void ExecUnloadUnit(int plnr)
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      OrderResult orderResult1;
      for (int unitCounter = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
      {
        if (this.game.Data.UnitObj[unitCounter].AIPlanNr == plnr)
        {
          int num1 = 1;
          while (num1 == 1)
          {
            num1 = 0;
            if (this.game.Data.UnitObj[unitCounter].PassengerCounter > -1 && this.game.Data.UnitObj[unitCounter].X == this.game.Data.UnitObj[unitCounter].AINavtargetX && this.game.Data.UnitObj[unitCounter].Y == this.game.Data.UnitObj[unitCounter].AINavtargetY)
            {
              SimpleList simpleList = new SimpleList();
              int tfacing = 1;
              do
              {
                Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(this.game.Data.UnitObj[unitCounter].X, this.game.Data.UnitObj[unitCounter].Y, this.game.Data.UnitObj[unitCounter].Map, tfacing);
                if (coordinate.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].CanAmph)
                {
                  int num2 = 0;
                  if (this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime == -1)
                    num2 = 1;
                  if (this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime > -1 && this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime] == 0)
                    num2 = 1;
                  if (num2 == 1 && this.HexSA[coordinate.x, coordinate.y] == this.TPlanObj[plnr].SeaTarget)
                  {
                    int num3 = 0;
                    if (this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitCounter > 14 && this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime, this.game.Data.Turn))
                      num3 = 1;
                    if (num3 == 0)
                    {
                      int tid;
                      simpleList.Add(tid, this.GetHexForceLandStrength(coordinate.x, coordinate.y), coordinate.x, coordinate.y);
                    }
                  }
                }
                ++tfacing;
              }
              while (tfacing <= 6);
              simpleList.Sort();
              if (simpleList.Counter > -1)
              {
                this.game.SelectX = simpleList.Data1[0];
                this.game.SelectY = simpleList.Data2[0];
                this.game.EditObj.OrderTarget = this.game.Data.UnitObj[unitCounter].PassengerList[0];
                this.game.EditObj.OrderUnit = unitCounter;
                OrderResult orderResult2 = this.game.ProcessingObj.unLoadUnit(this.game.EditObj.OrderTarget, this.game.EditObj.OrderUnit, this.game.SelectX, this.game.SelectY, 0);
                num1 = 1;
                if (orderResult2.OK)
                {
                  if (this.game.HandyFunctionsObj.VisibleEnemyUnitsInHex(this.game.SelectX, this.game.SelectY, 0, this.game.Data.Turn, true))
                  {
                    this.game.EditObj.TargetX = this.game.SelectX;
                    this.game.EditObj.TargetY = this.game.SelectY;
                    this.game.TempCombat = new CombatClass(this.game);
                    Coordinate Target = new Coordinate();
                    Target.x = this.game.EditObj.TargetX;
                    Target.y = this.game.EditObj.TargetY;
                    this.game.EditObj.TempUnitList = new UnitList();
                    this.game.EditObj.TempUnitList.add(this.game.EditObj.OrderTarget);
                    orderResult1 = this.game.TempCombat.Init(Target, 1, this.game.EditObj.TempUnitList, 21);
                    this.game.TempCombat.DoBattle();
                    this.game.TempCombat.EndBattle();
                    this.game.TempCombat = (CombatClass) null;
                    this.game.EditObj.TargetX = -1;
                    this.game.EditObj.TargetY = -1;
                  }
                  this.AddLog("Unloaded unit");
                }
              }
            }
          }
        }
      }
      for (int unitCounter = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
      {
        if (this.game.Data.UnitObj[unitCounter].AIPlanNr == plnr)
        {
          int num = 1;
          while (num == 1)
          {
            num = 0;
            if (this.game.Data.UnitObj[unitCounter].PassengerCounter > -1 && this.TPlanObj[plnr].Stand != 7)
            {
              this.game.SelectX = this.game.Data.UnitObj[unitCounter].X;
              this.game.SelectY = this.game.Data.UnitObj[unitCounter].Y;
              if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType].IsSea)
              {
                this.game.EditObj.OrderTarget = this.game.Data.UnitObj[unitCounter].PassengerList[0];
                this.game.EditObj.OrderUnit = unitCounter;
                orderResult1 = this.game.ProcessingObj.unLoadUnit(this.game.EditObj.OrderTarget, this.game.EditObj.OrderUnit, this.game.SelectX, this.game.SelectY, 0);
                num = 1;
                this.AddLog("Unloaded unit due to lack of AMPH plan");
              }
            }
          }
        }
      }
      this.CratesCheck();
    }

    public void ExecLoadUnitOnBoard(int plnr)
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      if (this.TPlanObj[plnr].SeaTarget <= 0)
        return;
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        if (this.game.Data.UnitObj[index].AIPlanNr == plnr && this.game.Data.UnitObj[index].AIUnitGoal == 8 && this.game.HandyFunctionsObj.GetUnitCarryCap(index, 1) > 0)
        {
          int x = this.game.Data.UnitObj[index].X;
          int y = this.game.Data.UnitObj[index].Y;
          if (x == this.TPlanObj[plnr].FromArea.X & y == this.TPlanObj[plnr].FromArea.Y)
          {
            for (int unitCounter2 = this.game.Data.MapObj[0].HexObj[x, y].UnitCounter; unitCounter2 >= 0; unitCounter2 += -1)
            {
              int unit = this.game.Data.MapObj[0].HexObj[x, y].UnitList[unitCounter2];
              if (index != unit && this.game.Data.UnitObj[unit].AIPlanNr == plnr && !this.game.Data.UnitObj[unit].AIReserve && !this.game.HandyFunctionsObj.HasUnitAirSF(unit) & !this.game.HandyFunctionsObj.HasUnitNavySF(unit) && this.game.HandyFunctionsObj.HasUnitlandSF(unit) & this.game.HandyFunctionsObj.GetUnitWeight(unit, true) > 0 && this.game.Data.UnitObj[unit].AIUnitGoal == 1 | this.game.Data.UnitObj[unit].AIUnitGoal == 2 | this.game.Data.UnitObj[unit].AIUnitGoal == 3 | this.game.Data.UnitObj[unit].AIUnitGoal == 4 && this.game.HandyFunctionsObj.GetUnitWeight(unit, true) <= this.game.HandyFunctionsObj.GetUnitCarryCap(index, 1, true))
                this.game.ProcessingObj.LoadUnit(unit, index);
            }
          }
        }
      }
    }

    public void ExecJoinUnits(int plannr = -1)
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      SimpleList simpleList = new SimpleList();
      this.AddLog("JOIN UNITS:");
      if ((double) this.game.Data.RuleVar[211] > 0.0)
      {
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index1 = 0; index1 <= mapWidth; ++index1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index2 = 0; index2 <= mapHeight; ++index2)
          {
            if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[index1, index2].Regime, this.game.Data.Turn))
            {
              int unrT = -1;
              int unitCounter = this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter;
              for (int index3 = 0; index3 <= unitCounter; ++index3)
              {
                int unit = this.game.Data.MapObj[0].HexObj[index1, index2].UnitList[index3];
                if (plannr == -1 | plannr == this.game.Data.UnitObj[unit].AIPlanNr && Operators.ConditionalCompareObjectGreater(this.GetEPPerTurn(unit), (object) 0, false) && this.game.Data.UnitObj[unit].AIUnitGoal == 4)
                {
                  if (unrT == -1)
                    unrT = unit;
                  else if (this.game.Data.UnitObj[unrT].AIPlanNr == this.game.Data.UnitObj[unit].AIPlanNr)
                  {
                    for (int sfCount = this.game.Data.UnitObj[unit].SFCount; sfCount >= 0; sfCount += -1)
                    {
                      int sf = this.game.Data.UnitObj[unit].SFList[sfCount];
                      this.game.ProcessingObj.DoTransfer(unit, unrT, 0, sf, this.game.Data.SFObj[sf].Qty, true, false);
                    }
                    if (this.game.Data.UnitObj[unit].IsHQ)
                    {
                      RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                      RegimeClass[] regimeClassArray = regimeObj;
                      int turn = this.game.Data.Turn;
                      int index4 = turn;
                      regimeClassArray[index4].ResPts = (int) Math.Round((double) ((float) regimeObj[turn].ResPts + this.game.Data.RuleVar[47]));
                    }
                    else
                    {
                      RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                      RegimeClass[] regimeClassArray = regimeObj;
                      int turn = this.game.Data.Turn;
                      int index5 = turn;
                      regimeClassArray[index5].ResPts = (int) Math.Round((double) ((float) regimeObj[turn].ResPts + this.game.Data.RuleVar[46]));
                    }
                    this.game.Data.RemoveUnit(unit, ref this.game);
                    break;
                  }
                }
              }
            }
          }
        }
      }
      if (plannr <= -1)
        return;
      int num1 = 1;
      while (num1 == 1)
      {
        num1 = 0;
        int num2 = this.TPlanObj[plannr].EnemyUnitCount * 2;
        if (num2 == 0)
          num2 = 1;
        int num3 = num2 + 1;
        if (num3 > this.TPlanObj[plannr].FrontSize)
          num3 = this.TPlanObj[plannr].FrontSize;
        if (this.TPlanObj[plannr].FriendlyUnitCount > num3 && (double) this.game.Data.RuleVar[249] == 0.0)
        {
          int mapWidth = this.game.Data.MapObj[0].MapWidth;
          for (int index6 = 0; index6 <= mapWidth; ++index6)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index7 = 0; index7 <= mapHeight; ++index7)
            {
              if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[index6, index7].Regime, this.game.Data.Turn))
              {
                int index8 = -1;
                int unitCounter = this.game.Data.MapObj[0].HexObj[index6, index7].UnitCounter;
                for (int index9 = 0; index9 <= unitCounter; ++index9)
                {
                  int unit = this.game.Data.MapObj[0].HexObj[index6, index7].UnitList[index9];
                  if (plannr == -1 | plannr == this.game.Data.UnitObj[unit].AIPlanNr)
                  {
                    if (index8 == -1)
                      index8 = unit;
                    else if (this.game.Data.UnitObj[index8].AIPlanNr == this.game.Data.UnitObj[unit].AIPlanNr && this.game.Data.UnitObj[unit].AIUnitGoal == this.game.Data.UnitObj[index8].AIUnitGoal && !this.game.Data.UnitObj[unit].IsHQ & !this.game.Data.UnitObj[index8].IsHQ && (double) (this.game.HandyFunctionsObj.GetUnitStackPts(unit) + this.game.HandyFunctionsObj.GetUnitStackPts(index8)) < (double) this.game.Data.RuleVar[184])
                    {
                      for (int sfCount = this.game.Data.UnitObj[unit].SFCount; sfCount >= 0; sfCount += -1)
                      {
                        int sf = this.game.Data.UnitObj[unit].SFList[sfCount];
                        this.game.ProcessingObj.DoTransfer(unit, index8, 0, sf, this.game.Data.SFObj[sf].Qty, true, false);
                      }
                      if (this.game.Data.UnitObj[unit].IsHQ)
                      {
                        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                        RegimeClass[] regimeClassArray = regimeObj;
                        int turn = this.game.Data.Turn;
                        int index10 = turn;
                        regimeClassArray[index10].ResPts = (int) Math.Round((double) ((float) regimeObj[turn].ResPts + this.game.Data.RuleVar[47]));
                      }
                      else
                      {
                        RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                        RegimeClass[] regimeClassArray = regimeObj;
                        int turn = this.game.Data.Turn;
                        int index11 = turn;
                        regimeClassArray[index11].ResPts = (int) Math.Round((double) ((float) regimeObj[turn].ResPts + this.game.Data.RuleVar[46]));
                      }
                      this.game.Data.RemoveUnit(unit, ref this.game);
                      this.AddLog("Joined unit");
                      num1 = 1;
                      break;
                    }
                  }
                }
              }
            }
          }
        }
        int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
        for (int index12 = 0; index12 <= mapWidth1; ++index12)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index13 = 0; index13 <= mapHeight; ++index13)
          {
            if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[index12, index13].Regime, this.game.Data.Turn))
            {
              int index14 = -1;
              int unitCounter = this.game.Data.MapObj[0].HexObj[index12, index13].UnitCounter;
              for (int index15 = 0; index15 <= unitCounter; ++index15)
              {
                int unit = this.game.Data.MapObj[0].HexObj[index12, index13].UnitList[index15];
                if (plannr == -1 | plannr == this.game.Data.UnitObj[unit].AIPlanNr)
                {
                  if (index14 == -1)
                    index14 = unit;
                  else if (this.game.Data.UnitObj[index14].AIPlanNr == this.game.Data.UnitObj[unit].AIPlanNr && this.game.Data.UnitObj[unit].AIUnitGoal == this.game.Data.UnitObj[index14].AIUnitGoal && (double) this.game.HandyFunctionsObj.GetUnitStackPts(unit) < (double) this.game.Data.RuleVar[182] & (double) this.game.HandyFunctionsObj.GetUnitStackPts(index14) < (double) this.game.Data.RuleVar[182] * 2.0 && (double) (this.game.HandyFunctionsObj.GetUnitStackPts(unit) + this.game.HandyFunctionsObj.GetUnitStackPts(index14)) < (double) this.game.Data.RuleVar[184] && !this.game.Data.UnitObj[unit].IsHQ & !this.game.Data.UnitObj[index14].IsHQ)
                  {
                    for (int sfCount = this.game.Data.UnitObj[unit].SFCount; sfCount >= 0; sfCount += -1)
                    {
                      int sf = this.game.Data.UnitObj[unit].SFList[sfCount];
                      this.game.ProcessingObj.DoTransfer(unit, index14, 0, sf, this.game.Data.SFObj[sf].Qty, true, false);
                    }
                    if (this.game.Data.UnitObj[unit].IsHQ)
                    {
                      RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                      RegimeClass[] regimeClassArray = regimeObj;
                      int turn = this.game.Data.Turn;
                      int index16 = turn;
                      regimeClassArray[index16].ResPts = (int) Math.Round((double) ((float) regimeObj[turn].ResPts + this.game.Data.RuleVar[47]));
                    }
                    else
                    {
                      RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                      RegimeClass[] regimeClassArray = regimeObj;
                      int turn = this.game.Data.Turn;
                      int index17 = turn;
                      regimeClassArray[index17].ResPts = (int) Math.Round((double) ((float) regimeObj[turn].ResPts + this.game.Data.RuleVar[46]));
                    }
                    this.game.Data.RemoveUnit(unit, ref this.game);
                    this.AddLog("Joined 2 to small unit");
                    num1 = 1;
                    break;
                  }
                }
              }
            }
          }
        }
      }
    }

    public float GetFriendlyAirRatio()
    {
      int unitCounter = this.game.Data.UnitCounter;
      int num1;
      int num2;
      int num3;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].PreDef == -1)
        {
          if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn)
          {
            num1 += this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unr);
            num2 += this.game.HandyFunctionsObj.GetPowerPtsAbsoluteForAirOnly(unr);
          }
          else if (this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.UnitObj[unr].Regime, this.game.Data.Turn))
            num3 += this.game.HandyFunctionsObj.GetPowerPtsAbsoluteForAirOnly(unr);
        }
      }
      if (num3 == 0)
        num3 = 1;
      int regimeCounter = this.game.Data.RegimeCounter;
      int num4;
      for (int regnr = 0; regnr <= regimeCounter; ++regnr)
      {
        if (this.game.HandyFunctionsObj.IsHostileNotSelf(regnr, this.game.Data.Turn) && this.game.Data.Turn != regnr & !this.game.Data.RegimeObj[regnr].Sleep)
          ++num4;
      }
      if (num4 < 1)
        num4 = 1;
      int num5 = (int) Math.Round((double) num3 / (double) num4);
      float friendlyAirRatio = (float) num2 / (float) num5;
      if ((double) friendlyAirRatio < 1.0)
      {
        if ((double) num1 / (double) num5 > 5.0)
          friendlyAirRatio += 0.6f;
        if ((double) num1 / (double) num5 > 10.0)
          friendlyAirRatio += 0.12f;
        if ((double) num1 / (double) num5 > 20.0)
          friendlyAirRatio += 0.12f;
        if ((double) num1 / (double) num5 > 30.0)
          friendlyAirRatio += 0.12f;
        if ((double) num1 / (double) num5 > 40.0)
          friendlyAirRatio += 0.12f;
        if ((double) num1 / (double) num5 > 40.0)
          friendlyAirRatio += 0.12f;
        if ((double) num1 / (double) num5 > 50.0)
          friendlyAirRatio += 0.22f;
        if ((double) num1 / (double) num5 > 99.0)
          friendlyAirRatio += 0.36f;
      }
      return friendlyAirRatio;
    }

    public void ExecSetProduction()
    {
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      SimpleList simpleList = new SimpleList();
      int[] numArray2 = new int[this.game.Data.UnitCounter + 1];
      this.AddLog("");
      this.AddLog("PRODUCTION:");
      int num1 = 0;
      int tplanCount1 = this.TPlanCount;
      for (int index = 1; index <= tplanCount1; ++index)
      {
        if (this.TPlanObj[index].Type == 30 & this.TPlanObj[index].HQ > -1 && this.TPlanObj[index].MetaChainNr > num1)
          num1 = this.TPlanObj[index].MetaChainNr;
      }
      int tplanCount2 = this.TPlanCount;
      for (int index = 1; index <= tplanCount2; ++index)
      {
        if (this.TPlanObj[index].Type == 20 && this.game.Data.MapObj[0].HexObj[this.TPlanObj[index].TooArea.X, this.TPlanObj[index].TooArea.Y].Regime == this.game.Data.Turn && this.game.Data.MapObj[0].HexObj[this.TPlanObj[index].TooArea.X, this.TPlanObj[index].TooArea.Y].Location > -1 && this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.TPlanObj[index].TooArea.X, this.TPlanObj[index].TooArea.Y].Location].HQ > -1)
        {
          this.SAObj[this.GetSANr(this.TPlanObj[index].TooArea)].LandReservePlan = this.SAObj[this.GetSANr(this.TPlanObj[index].FromArea)].LandReservePlan;
          if (this.game.Data.MapObj[0].HexObj[this.TPlanObj[index].FromArea.X, this.TPlanObj[index].FromArea.Y].Location > -1 && this.game.Data.MapObj[0].HexObj[this.TPlanObj[index].TooArea.X, this.TPlanObj[index].TooArea.Y].Location > -1)
            this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.TPlanObj[index].TooArea.X, this.TPlanObj[index].TooArea.Y].Location].HQ = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.TPlanObj[index].FromArea.X, this.TPlanObj[index].FromArea.Y].Location].HQ;
        }
      }
      for (; num1 > -1; --num1)
      {
        int tplanCount3 = this.TPlanCount;
        for (int index1 = 1; index1 <= tplanCount3; ++index1)
        {
          int hq1;
          if (this.TPlanObj[index1].Type == 30 & this.TPlanObj[index1].HQ > -1 & this.TPlanObj[index1].MetaChainNr == num1)
          {
            int num2 = 0;
            int saCount1 = this.SACount;
            for (int index2 = 1; index2 <= saCount1; ++index2)
            {
              if (this.SAObj[index2].LandReservePlan == index1)
              {
                int location = this.game.Data.MapObj[0].HexObj[this.SAObj[index2].X, this.SAObj[index2].Y].Location;
                if (location > -1 && this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].MaxProd > 0 && this.game.Data.MapObj[0].HexObj[this.SAObj[index2].X, this.SAObj[index2].Y].Regime == this.game.Data.Turn && this.ProdGetSupplyItem(location) > -1)
                  num2 = (int) Math.Round((double) num2 + (double) this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].MaxProd / (double) this.game.Data.ItemTypeObj[this.ProdGetSupplyItem(location)].ProdWeight);
              }
            }
            int num3 = 0;
            do
            {
              SimpleList Expression = (SimpleList) null;
              int saCount2 = this.SACount;
              for (int index3 = 1; index3 <= saCount2; ++index3)
              {
                if (this.SAObj[index3].LandReservePlan == index1)
                {
                  int locnr = this.game.Data.MapObj[0].HexObj[this.SAObj[index3].X, this.SAObj[index3].Y].Location;
                  if (locnr > -1 & this.game.Data.MapObj[0].HexObj[this.SAObj[index3].X, this.SAObj[index3].Y].Regime == this.game.Data.Turn)
                  {
                    if (this.game.Data.LocTypeObj[this.game.Data.LocObj[locnr].Type].AutoProd == -1)
                    {
                      if (this.game.HandyFunctionsObj.GetLocTypeItemTypesAmmount(this.game.Data.LocObj[locnr].Type) == num3 | num3 == 99 & this.game.HandyFunctionsObj.GetLocTypeItemTypesAmmount(this.game.Data.LocObj[locnr].Type) >= 99)
                      {
                        if (Information.IsNothing((object) Expression))
                          Expression = this.ProdWishes(index1, locnr);
                        if (this.game.Data.LocTypeObj[this.game.Data.LocObj[locnr].Type].MaxProd > 0 & this.game.HandyFunctionsObj.CanLocProduce(locnr, this.game.Data.Turn))
                        {
                          Application.DoEvents();
                          this.AddLog("Plan #" + Conversion.Str((object) index1) + ", Location: " + this.game.Data.LocObj[locnr].Name);
                          simpleList = new SimpleList();
                          hq1 = this.TPlanObj[index1].HQ;
                          int landCap = this.game.Data.UnitObj[hq1].LandCap;
                          int capPts = this.game.HandyFunctionsObj.GetCapPts(hq1, 0);
                          int Number1;
                          if (capPts == 0)
                            Number1 = 1;
                          else if ((double) landCap / (double) capPts < 0.2)
                            Number1 = 1;
                          if (this.ProdGetRole(locnr, 2) == -1)
                            Number1 = 0;
                          if ((double) this.game.Data.RuleVar[253] == 0.0)
                            Number1 = 0;
                          if (Number1 == 0)
                          {
                            int navyCap = this.game.Data.UnitObj[hq1].NavyCap;
                            capPts = this.game.HandyFunctionsObj.GetCapPts(hq1, 1);
                            if (this.SAObj[index3].SeaNeighbourCount > 0)
                            {
                              if (capPts == 0)
                                Number1 = 2;
                              else if ((double) navyCap / (double) capPts < 0.2)
                                Number1 = 2;
                              if (this.ProdGetRole(locnr, 3) == -1)
                                Number1 = 0;
                            }
                          }
                          if ((double) this.game.Data.RuleVar[253] == 0.0)
                            this.TPlanObj[index1].LandTransferMobility = 0;
                          if ((double) this.game.Data.RuleVar[253] == 0.0 & capPts > 0)
                            Number1 = 0;
                          int num4 = 0;
                          int num5 = this.game.HandyFunctionsObj.GetRealHQSupplyPts(this.TPlanObj[index1].HQ);
                          int unitCounter1 = this.game.Data.UnitCounter;
                          for (int unr = 0; unr <= unitCounter1; ++unr)
                          {
                            if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].AIPlanNr > 0)
                            {
                              int aiPlanNr = this.game.Data.UnitObj[unr].AIPlanNr;
                              if (this.IsHQinChain(unr, hq1))
                                num4 += this.game.HandyFunctionsObj.UnitSupplyNeed(unr, true);
                            }
                          }
                          if (num5 < 0)
                            num5 = 0;
                          int Number2 = (int) Math.Round((double) num4 * 1.5 - (double) num5);
                          if (Number2 < 0)
                            Number2 = 0;
                          this.AddLog("Supply before town divider: " + Conversion.Str((object) Number2));
                          int Number3 = this.ProdGetSupplyItem(locnr) != -1 ? (int) Math.Round((double) Number2 * ((double) this.game.Data.LocTypeObj[this.game.Data.LocObj[locnr].Type].MaxProd / (double) this.game.Data.ItemTypeObj[this.ProdGetSupplyItem(locnr)].ProdWeight / (double) num2)) : 0;
                          int unitCounter2 = this.game.Data.UnitCounter;
                          int Number4;
                          for (int unr = 0; unr <= unitCounter2; ++unr)
                          {
                            if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & this.game.Data.UnitObj[unr].IsHQ && this.game.Data.UnitObj[unr].AIPlanNr > 0)
                            {
                              int aiPlanNr = this.game.Data.UnitObj[unr].AIPlanNr;
                              if (this.TPlanObj[aiPlanNr].Type == 20 && this.SAObj[this.GetAreaNr(this.TPlanObj[aiPlanNr].FromArea)].LandReservePlan == index1 && this.game.HandyFunctionsObj.GetStaffPercent(unr) < 100)
                                Number4 = 1;
                            }
                          }
                          if (this.game.HandyFunctionsObj.GetStaffPercent(this.TPlanObj[index1].HQ) > 200)
                            Number4 = 0;
                          if (this.ProdGetRole(locnr, 1) == -1)
                            Number4 = 0;
                          if ((double) this.game.Data.RuleVar[(int) byte.MaxValue] == 1.0)
                            Number4 = 0;
                          int num6 = 0;
                          int num7 = 0;
                          if ((double) this.game.Data.RuleVar[211] > 0.0)
                          {
                            int unitCounter3 = this.game.Data.UnitCounter;
                            for (int unr = 0; unr <= unitCounter3; ++unr)
                            {
                              if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & this.game.Data.UnitObj[unr].AIUnitGoal == 4 && this.game.Data.UnitObj[unr].AIPlanNr > 0)
                              {
                                int aiPlanNr = this.game.Data.UnitObj[unr].AIPlanNr;
                                if (this.TPlanObj[aiPlanNr].Type == 20 | this.TPlanObj[aiPlanNr].Type == 40 && this.SAObj[this.GetAreaNr(this.TPlanObj[aiPlanNr].FromArea)].LandReservePlan == index1)
                                {
                                  int integer = Conversions.ToInteger(Operators.AddObject((object) Conversions.ToInteger(this.GetEPPerTurn(unr)), this.GetEPPerTurn(this.TPlanObj[index1].HQ)));
                                  num6 += integer;
                                  ++num7;
                                }
                              }
                            }
                          }
                          int num8 = num7 <= 0 ? 0 : ((double) VBMath.Rnd() * (double) this.game.Data.RuleVar[215] >= (double) num6 / (double) num7 ? 1 : 0);
                          int Number5;
                          if ((double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts < (double) this.game.Data.RuleVar[181])
                            Number5 = 1;
                          if ((double) VBMath.Rnd() < (double) this.game.Data.RuleVar[226])
                            Number5 = 1;
                          if (this.ProdGetPPItem(locnr) == -1)
                            Number5 = 0;
                          this.AddLog("Landcap: " + Conversion.Str((object) Number1) + ", Supply: " + Conversion.Str((object) Number3) + ", Staff=" + Conversion.Str((object) Number4) + ", PP=" + Conversion.Str((object) Number5));
                          this.AddLog("LandMobAlert=" + Conversion.Str((object) this.TPlanObj[index1].LandTransferMobility) + ", SeaMobAlert=" + Conversion.Str((object) this.TPlanObj[index1].SeaTransferMobility));
                          if (Number5 > 0 & Number4 > 0)
                          {
                            if ((double) VBMath.Rnd() > 0.5)
                              Number4 = 0;
                            else
                              Number5 = 0;
                          }
                          if (Number1 > 0 & (Number5 > 0 | Number4 > 0))
                          {
                            if ((double) VBMath.Rnd() > 0.5)
                            {
                              Number1 = 0;
                            }
                            else
                            {
                              Number5 = 0;
                              Number4 = 0;
                            }
                          }
                          this.game.Data.LocObj[locnr].HQ = this.TPlanObj[index1].HQ;
                          int index4 = 0;
                          int num9 = 0;
                          if (this.game.Data.LocObj[locnr].X == 22 & this.game.Data.LocObj[locnr].Y == 31)
                            locnr = locnr;
                          if (Number3 > -1)
                          {
                            int index5 = this.ProdGetSupplyItem(locnr);
                            if (Operators.CompareString(this.game.Data.LocObj[locnr].Name, "Aqaba", false) == 0)
                              index5 = index5;
                            if (index5 > -1)
                            {
                              int num10 = (int) Math.Round(100.0 * ((double) (this.game.Data.ItemTypeObj[index5].ProdWeight * Number3) / (double) this.game.Data.LocTypeObj[this.game.Data.LocObj[locnr].Type].MaxProd));
                              if (num10 < 10)
                                num10 = 10;
                              if (num10 > 100)
                              {
                                if (this.game.Data.UnitObj[this.TPlanObj[index1].HQ].HQ > -1)
                                {
                                  int[] numArray3 = numArray2;
                                  int[] numArray4 = numArray3;
                                  int hq2 = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].HQ;
                                  int index6 = hq2;
                                  int num11 = (int) Math.Round((double) numArray3[hq2] + ((double) Number3 - (double) this.game.Data.LocTypeObj[this.game.Data.LocObj[locnr].Type].MaxProd / (double) this.game.Data.ItemTypeObj[index5].ProdWeight));
                                  numArray4[index6] = num11;
                                }
                                num10 = 100;
                              }
                              this.game.Data.LocObj[locnr].Production[0] = index5;
                              this.game.Data.LocObj[locnr].ProdPercent[0] = num10;
                              index4 = 1;
                              num9 = num10;
                            }
                          }
                          if (num9 < 100 & index4 < 4)
                          {
                            int num12 = -1;
                            if (Number5 > 0 & num12 == -1)
                            {
                              num12 = this.ProdGetPPItem(locnr);
                              Number5 = 0;
                            }
                            if (Number1 == 1 & num12 == -1)
                            {
                              num12 = this.ProdGetRole(locnr, 2);
                              Number1 = 0;
                            }
                            if (Number1 == 2 & num12 == -1)
                            {
                              num12 = this.ProdGetRole(locnr, 3);
                              Number1 = 0;
                            }
                            if (Number4 > 0 & num12 == -1)
                            {
                              num12 = this.ProdGetRole(locnr, 1);
                              Number4 = 0;
                            }
                            int num13 = 100 - num9;
                            if (Number5 == 1)
                            {
                              if ((double) num13 > 30.0 + 30.0 * (double) this.game.Data.RuleVar[226])
                                num13 = (int) Math.Round(30.0 + 30.0 * (double) this.game.Data.RuleVar[226]);
                            }
                            else if (num13 > 30)
                              num13 = 30;
                            if (num12 > -1)
                            {
                              this.game.Data.LocObj[locnr].ProdPercent[index4] = num13;
                              this.game.Data.LocObj[locnr].Production[index4] = num12;
                              ++index4;
                              num9 += num13;
                            }
                          }
                          int num14 = 0;
                          if (num9 < 100 & index4 < 4 & Expression.Counter > -1)
                          {
                            int num15 = 0;
                            num14 = 0;
                            while (num15 == 0 & num14 < 20)
                            {
                              ++num14;
                              int index7 = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) (Expression.Counter + 1)));
                              int index8 = this.ProdGetRole(locnr, Expression.Weight[index7]);
                              if (index8 == -1)
                              {
                                index8 = this.ProdGetRole(locnr, Expression.Data1[index7]);
                                if (Expression.Data3[index7] > -1 && this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, Expression.Data3[index7]).result)
                                  index8 = Expression.Data3[index7];
                              }
                              else if (Expression.Data2[index7] > -1 && this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, Expression.Data2[index7]).result)
                                index8 = Expression.Data2[index7];
                              if ((double) this.game.Data.RuleVar[253] > 0.0)
                              {
                                if (this.TPlanObj[index1].LandTransferMobility == 1 & this.TPlanObj[index1].SeaTransferMobility == 0)
                                {
                                  if (this.ProdGetRole(locnr, 2) > -1)
                                    index8 = this.ProdGetRole(locnr, 2);
                                }
                                else if (this.TPlanObj[index1].LandTransferMobility == 0 & this.TPlanObj[index1].SeaTransferMobility == 1)
                                {
                                  if (this.ProdGetRole(locnr, 3) > -1)
                                    index8 = this.ProdGetRole(locnr, 3);
                                }
                                else if (this.TPlanObj[index1].LandTransferMobility == 1 & this.TPlanObj[index1].SeaTransferMobility == 1)
                                {
                                  if ((double) VBMath.Rnd() > 0.5)
                                  {
                                    if (this.ProdGetRole(locnr, 2) > -1)
                                      index8 = this.ProdGetRole(locnr, 2);
                                  }
                                  else if (this.ProdGetRole(locnr, 3) > -1)
                                    index8 = this.ProdGetRole(locnr, 3);
                                }
                              }
                              if ((double) this.game.Data.RuleVar[211] == 1.0 & num8 == 1 & (double) VBMath.Rnd() > 0.5)
                              {
                                if (this.ProdGetRole(locnr, 5) > -1)
                                  index8 = this.ProdGetRole(locnr, 5);
                              }
                              else if ((double) VBMath.Rnd() < (double) this.game.Data.RuleVar[226])
                                index8 = this.ProdGetPPItem(locnr);
                              int num16 = (int) Math.Round(Conversion.Int((double) (100 - num9) / 2.0));
                              if ((double) this.game.Data.LocObj[locnr].ProdPointRemainder[index4] >= (double) this.game.Data.LocTypeObj[this.game.Data.LocObj[locnr].Type].MaxProd * ((double) num16 / 150.0))
                              {
                                num9 += this.game.Data.LocObj[locnr].ProdPercent[index4];
                                int index9 = this.game.Data.LocObj[locnr].Production[index4];
                                if (index9 > -1 & num16 > 0 && (double) this.game.Data.ItemTypeObj[index9].ProdWeight > (double) this.game.HandyFunctionsObj.GetProdPtsForLoc2(locnr) * ((double) num16 / 100.0))
                                  num16 = 100 - num9;
                                this.game.Data.LocObj[locnr].ProdPercent[index4] = num16;
                                ++index4;
                                break;
                              }
                              if (index8 > -1 & num16 > 0 && (double) this.game.Data.ItemTypeObj[index8].ProdWeight > (double) this.game.HandyFunctionsObj.GetProdPtsForLoc2(locnr) * ((double) num16 / 100.0))
                                num16 = 100 - num9;
                              if (index8 > -1)
                              {
                                this.game.Data.LocObj[locnr].Production[index4] = index8;
                                this.game.Data.LocObj[locnr].ProdPercent[index4] = num16;
                                ++index4;
                                num9 += num16;
                                num15 = 1;
                              }
                            }
                          }
                          if (num9 < 100 & index4 < 4)
                          {
                            int num17 = 0;
                            num14 = 0;
                            while (num17 == 0 & num14 < 20)
                            {
                              ++num14;
                              int num18 = -1;
                              if (num18 == -1)
                                num18 = this.ProdGetRole(locnr, 6);
                              if (num18 == -1)
                                num18 = this.ProdGetRole(locnr, 7);
                              if (num18 == -1)
                                num18 = this.ProdGetRole(locnr, 8);
                              if (num18 == -1)
                                num18 = this.ProdGetRole(locnr, 10);
                              if (num18 == -1)
                                num18 = this.ProdGetRole(locnr, 12);
                              if (num18 == -1)
                                num18 = this.ProdGetRole(locnr, 1);
                              if (num18 == -1)
                                num18 = this.ProdGetRole(locnr, 5);
                              if (num18 == -1)
                                num18 = this.ProdGetRole(locnr, 9);
                              if (num18 == -1)
                                num18 = this.ProdGetRole(locnr, 12);
                              if (num18 == -1)
                                num18 = this.ProdGetRole(locnr, 19);
                              if (num18 == -1)
                                num18 = this.ProdGetRole(locnr, 18);
                              if (num18 == -1)
                                num18 = this.ProdGetPPItem(locnr);
                              if (num18 == -1 && (double) this.game.Data.RuleVar[253] > 0.0)
                              {
                                if (this.TPlanObj[index1].LandTransferMobility == 1 & this.TPlanObj[index1].SeaTransferMobility == 0)
                                {
                                  if (this.ProdGetRole(locnr, 2) > -1)
                                    num18 = this.ProdGetRole(locnr, 2);
                                }
                                else if (this.TPlanObj[index1].LandTransferMobility == 0 & this.TPlanObj[index1].SeaTransferMobility == 1)
                                {
                                  if (this.ProdGetRole(locnr, 3) > -1)
                                    num18 = this.ProdGetRole(locnr, 3);
                                }
                                else if (this.TPlanObj[index1].LandTransferMobility == 1 & this.TPlanObj[index1].SeaTransferMobility == 1)
                                {
                                  if ((double) VBMath.Rnd() > 0.5)
                                  {
                                    if (this.ProdGetRole(locnr, 2) > -1)
                                      num18 = this.ProdGetRole(locnr, 2);
                                  }
                                  else if (this.ProdGetRole(locnr, 3) > -1)
                                    num18 = this.ProdGetRole(locnr, 3);
                                }
                              }
                              int num19 = 100 - num9;
                              if ((double) this.game.Data.LocObj[locnr].ProdPointRemainder[index4] >= (double) this.game.Data.LocTypeObj[this.game.Data.LocObj[locnr].Type].MaxProd * ((double) num19 / 150.0))
                              {
                                int num20 = num9 + this.game.Data.LocObj[locnr].ProdPercent[index4];
                                this.game.Data.LocObj[locnr].ProdPercent[index4] = num19;
                                ++index4;
                                num9 = num20 + num19;
                                break;
                              }
                              if (num18 > -1)
                              {
                                this.game.Data.LocObj[locnr].Production[index4] = num18;
                                this.game.Data.LocObj[locnr].ProdPercent[index4] = num19;
                                ++index4;
                                num9 += num19;
                                num17 = 1;
                              }
                            }
                          }
                          int num21;
                          if (index4 < 3 & num14 > 18 & num9 < 100 & Number3 > 0)
                          {
                            int supplyItem = this.ProdGetSupplyItem(locnr);
                            if (supplyItem > -1)
                            {
                              num21 = this.game.Data.ItemTypeObj[supplyItem].ProdWeight * Number3;
                              int num22 = 100 - num9;
                              if (num22 > 100)
                              {
                                if (this.game.Data.UnitObj[this.TPlanObj[index1].HQ].HQ > -1)
                                {
                                  int[] numArray5 = numArray2;
                                  int[] numArray6 = numArray5;
                                  int hq3 = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].HQ;
                                  int index10 = hq3;
                                  int num23 = (int) Math.Round((double) numArray5[hq3] + ((double) Number3 - (double) this.game.Data.LocTypeObj[this.game.Data.LocObj[locnr].Type].MaxProd / (double) this.game.Data.ItemTypeObj[supplyItem].ProdWeight));
                                  numArray6[index10] = num23;
                                }
                                num22 = 100;
                              }
                              this.game.Data.LocObj[locnr].Production[0] = supplyItem;
                              int[] prodPercent = this.game.Data.LocObj[locnr].ProdPercent;
                              int[] numArray7 = prodPercent;
                              int index11 = 0;
                              int index12 = index11;
                              int num24 = prodPercent[index11] + num22;
                              numArray7[index12] = num24;
                              index4 = 1;
                              num9 += num22;
                            }
                          }
                          if (num14 > 18 & num9 < 100 & index4 == 2 & (double) this.game.Data.RuleVar[226] > 0.0 & (double) this.game.Data.RuleVar[501] == 0.0)
                          {
                            int num25 = 100 - num9;
                            this.game.Data.LocObj[locnr].Production[index4] = this.ProdGetPPItem(locnr);
                            this.game.Data.LocObj[locnr].ProdPercent[index4] = num25;
                            ++index4;
                            num9 += num25;
                            if (index4 < 4)
                            {
                              this.game.Data.LocObj[locnr].Production[index4] = -1;
                              this.game.Data.LocObj[locnr].ProdPercent[index4] = 0;
                            }
                          }
                          if (index4 < 3 & num14 > 18 & num9 < 100)
                          {
                            int supplyItem = this.ProdGetSupplyItem(locnr);
                            if (supplyItem > -1)
                            {
                              num21 = this.game.Data.ItemTypeObj[supplyItem].ProdWeight * Number3;
                              int num26 = 100 - num9;
                              if (num26 > 100)
                              {
                                if (this.game.Data.UnitObj[this.TPlanObj[index1].HQ].HQ > -1)
                                {
                                  int[] numArray8 = numArray2;
                                  int[] numArray9 = numArray8;
                                  int hq4 = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].HQ;
                                  int index13 = hq4;
                                  int num27 = (int) Math.Round((double) numArray8[hq4] + ((double) Number3 - (double) this.game.Data.LocTypeObj[this.game.Data.LocObj[locnr].Type].MaxProd / (double) this.game.Data.ItemTypeObj[supplyItem].ProdWeight));
                                  numArray9[index13] = num27;
                                }
                                num26 = 100;
                              }
                              this.game.Data.LocObj[locnr].Production[0] = supplyItem;
                              int[] prodPercent = this.game.Data.LocObj[locnr].ProdPercent;
                              int[] numArray10 = prodPercent;
                              int index14 = 0;
                              int index15 = index14;
                              int num28 = prodPercent[index14] + num26;
                              numArray10[index15] = num28;
                              index4 = 1;
                              num9 += num26;
                            }
                          }
                          if (num9 < 100 & index4 < 4 & Expression.Counter > -1)
                          {
                            int num29 = 0;
                            int num30 = 0;
                            while (num29 == 0 & num30 < 20)
                            {
                              ++num30;
                              int index16 = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) (Expression.Counter + 1)));
                              int role = this.ProdGetRole(locnr, Expression.Weight[index16]);
                              if (role == -1)
                              {
                                role = this.ProdGetRole(locnr, Expression.Data1[index16]);
                                if (Expression.Data3[index16] > -1 && this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, Expression.Data3[index16]).result)
                                  role = Expression.Data3[index16];
                              }
                              else if (Expression.Data2[index16] > -1 && this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, Expression.Data2[index16]).result)
                                role = Expression.Data2[index16];
                              if ((double) this.game.Data.RuleVar[211] == 1.0 & num8 == 1 && this.ProdGetRole(locnr, 5) > -1)
                                role = this.ProdGetRole(locnr, 5);
                              int num31 = 100 - num9;
                              if ((double) this.game.Data.LocObj[locnr].ProdPointRemainder[index4] >= (double) this.game.Data.LocTypeObj[this.game.Data.LocObj[locnr].Type].MaxProd * ((double) num31 / 100.0))
                              {
                                int num32 = num9 + this.game.Data.LocObj[locnr].ProdPercent[index4];
                                this.game.Data.LocObj[locnr].ProdPercent[index4] = num31;
                                ++index4;
                                break;
                              }
                              if (role > -1)
                              {
                                this.game.Data.LocObj[locnr].Production[index4] = role;
                                this.game.Data.LocObj[locnr].ProdPercent[index4] = num31;
                                ++index4;
                                num9 += num31;
                                num29 = 1;
                              }
                            }
                          }
                          if (index4 <= 3)
                          {
                            this.game.Data.LocObj[locnr].Production[3] = -1;
                            this.game.Data.LocObj[locnr].ProdPercent[3] = 0;
                            if (this.game.Data.LocObj[locnr].ProdPointRemainder[3] > 0)
                            {
                              int[] prodPointRemainder = this.game.Data.LocObj[locnr].ProdPointRemainder;
                              int[] numArray11 = prodPointRemainder;
                              int index17 = 2;
                              int index18 = index17;
                              int num33 = prodPointRemainder[index17] + this.game.Data.LocObj[locnr].ProdPointRemainder[3];
                              numArray11[index18] = num33;
                              this.game.Data.LocObj[locnr].ProdPointRemainder[3] = 0;
                            }
                          }
                          if (index4 <= 2)
                          {
                            this.game.Data.LocObj[locnr].Production[2] = -1;
                            this.game.Data.LocObj[locnr].ProdPercent[2] = 0;
                            if (this.game.Data.LocObj[locnr].ProdPointRemainder[2] > 0)
                            {
                              int[] prodPointRemainder = this.game.Data.LocObj[locnr].ProdPointRemainder;
                              int[] numArray12 = prodPointRemainder;
                              int index19 = 1;
                              int index20 = index19;
                              int num34 = prodPointRemainder[index19] + this.game.Data.LocObj[locnr].ProdPointRemainder[2];
                              numArray12[index20] = num34;
                              this.game.Data.LocObj[locnr].ProdPointRemainder[2] = 0;
                            }
                          }
                          if (index4 <= 1)
                          {
                            this.game.Data.LocObj[locnr].Production[1] = -1;
                            this.game.Data.LocObj[locnr].ProdPercent[1] = 0;
                            if (this.game.Data.LocObj[locnr].ProdPointRemainder[1] > 0)
                            {
                              int[] prodPointRemainder = this.game.Data.LocObj[locnr].ProdPointRemainder;
                              int[] numArray13 = prodPointRemainder;
                              int index21 = 0;
                              int index22 = index21;
                              int num35 = prodPointRemainder[index21] + this.game.Data.LocObj[locnr].ProdPointRemainder[1];
                              numArray13[index22] = num35;
                              this.game.Data.LocObj[locnr].ProdPointRemainder[1] = 0;
                            }
                          }
                        }
                      }
                    }
                    else if (this.game.Data.LocObj[locnr].Production[0] > -1)
                      this.game.Data.LocObj[locnr].HQ = this.TPlanObj[index1].HQ;
                  }
                }
              }
              ++num3;
            }
            while (num3 <= 99);
          }
          int num36 = 0;
          int num37 = 0;
          if (hq1 > -1 && this.game.Data.UnitObj[hq1].PreDef == -1)
          {
            int locCounter1 = this.game.Data.LocCounter;
            for (int locnr = 0; locnr <= locCounter1; ++locnr)
            {
              if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y].Regime == this.game.Data.Turn && this.game.Data.LocObj[locnr].HQ == hq1)
              {
                int prodslot = 0;
                do
                {
                  if (this.game.Data.LocObj[locnr].Production[prodslot] > -1 && this.game.Data.ItemTypeObj[this.game.Data.LocObj[locnr].Production[prodslot]].IsSupply)
                    num36 = (int) Math.Round((double) num36 + this.game.HandyFunctionsObj.GetEstimatedProduction(prodslot, locnr, true, false));
                  ++prodslot;
                }
                while (prodslot <= 3);
              }
            }
            int unitCounter = this.game.Data.UnitCounter;
            for (int unr = 0; unr <= unitCounter; ++unr)
            {
              if (this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.HandyFunctionsObj.IsUnitInHQChain(unr, hq1))
                num37 += this.game.HandyFunctionsObj.UnitSupplyNeed(unr, true);
            }
            if (num37 > num36)
            {
              int locCounter2 = this.game.Data.LocCounter;
              for (int index23 = 0; index23 <= locCounter2; ++index23)
              {
                if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index23].X, this.game.Data.LocObj[index23].Y].Regime == this.game.Data.Turn && this.game.Data.LocObj[index23].HQ == hq1)
                {
                  int index24 = 0;
                  do
                  {
                    if (this.game.Data.LocObj[index23].Production[index24] > -1 && this.game.Data.ItemTypeObj[this.game.Data.LocObj[index23].Production[index24]].IsSFType > -1)
                    {
                      this.game.Data.LocObj[index23].Production[index24] = -1;
                      this.game.Data.LocObj[index23].ProdPercent[index24] = 0;
                    }
                    ++index24;
                  }
                  while (index24 <= 3);
                }
              }
            }
          }
        }
      }
      int locCounter = this.game.Data.LocCounter;
      for (int index = 0; index <= locCounter; ++index)
      {
        if (this.game.Data.LocTypeObj[this.game.Data.LocObj[index].Type].NoHQ)
          this.game.Data.LocObj[index].HQ = -1;
      }
    }

    public SimpleList ProdWishes(int landres, int locnr)
    {
      SimpleList simpleList1 = new SimpleList();
      int num1 = 0;
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & !this.game.Data.UnitObj[unr].IsHQ && this.game.Data.UnitObj[unr].AIPlanNr > 0 & this.game.Data.UnitObj[unr].PreDef == -1)
        {
          int aiPlanNr = this.game.Data.UnitObj[unr].AIPlanNr;
          int num2 = 0;
          if (this.SAObj[this.GetAreaNr(this.TPlanObj[aiPlanNr].FromArea)].LandReservePlan == landres)
            num2 = 1;
          if (this.SAObj[this.GetAreaNr(this.TPlanObj[aiPlanNr].FromArea)].LandReservePlan > 0)
          {
            int hq1 = this.TPlanObj[this.SAObj[this.GetAreaNr(this.TPlanObj[aiPlanNr].FromArea)].LandReservePlan].HQ;
            int hq2 = this.TPlanObj[landres].HQ;
            if (hq1 > -1 & hq2 > -1 && this.IsHQinChain(hq1, hq2))
              num2 = 1;
          }
          if (num2 == 1)
          {
            int num3 = 0;
            if (this.TPlanObj[aiPlanNr].Type == 20)
              num3 = 1;
            if (this.TPlanObj[aiPlanNr].Type == 40 & this.game.Data.UnitObj[unr].AIUnitGoal == 5)
              num3 = 1;
            if (this.TPlanObj[aiPlanNr].Type == 40 & this.game.Data.UnitObj[unr].AIUnitGoal == 9)
              num3 = 1;
            if (this.TPlanObj[aiPlanNr].Type == 40 & this.game.Data.UnitObj[unr].AIUnitGoal == 10)
              num3 = 1;
            if (this.TPlanObj[aiPlanNr].Type == 40 & this.game.Data.UnitObj[unr].AIUnitGoal == 8)
              num3 = 1;
            if (this.TPlanObj[aiPlanNr].Type == 40 & this.game.Data.UnitObj[unr].AIUnitGoal == 1)
              num3 = 1;
            if (this.TPlanObj[aiPlanNr].Type == 40 & this.game.Data.UnitObj[unr].AIUnitGoal == 2)
              num3 = 1;
            if (this.HexOA[this.TPlanObj[landres].FromArea.X, this.TPlanObj[landres].FromArea.Y] != this.HexOA[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y])
              num3 = 0;
            if (this.TPlanObj[aiPlanNr].Type == 40 & this.game.Data.UnitObj[unr].AIUnitGoal == 8 && !this.needcargoships(landres))
              num3 = 0;
            if ((double) this.game.Data.RuleVar[224] == 0.0 & this.game.Data.UnitObj[unr].AIUnitGoal == 5)
              num3 = 0;
            if (num3 == 1)
            {
              int prodpts = (int) Math.Round((double) this.game.Data.LocTypeObj[this.game.Data.LocObj[locnr].Type].MaxProd / 2.0);
              RoleSFResult roleSfResult = this.LandTransferWhatWantsUnit(unr, 1, prodpts: prodpts);
              int rolenr1 = roleSfResult.rolenr;
              int itemtypenr1 = roleSfResult.itemtypenr;
              roleSfResult = this.LandTransferWhatWantsUnit(unr, 2, prodpts: prodpts);
              int rolenr2 = roleSfResult.rolenr;
              int itemtypenr2 = roleSfResult.itemtypenr;
              ++num1;
              if (rolenr1 > -1)
              {
                simpleList1.Add(num1, rolenr1, rolenr2, itemtypenr1, itemtypenr2);
                string str;
                if (rolenr1 == 6)
                  str = "INFANTRY";
                if (rolenr1 == 7)
                  str = "INFANTRYSUPPORT";
                if (rolenr1 == 8)
                  str = "ARTILERY";
                if (rolenr1 == 9)
                  str = "MOBILIZER";
                if (rolenr1 == 10)
                  str = "ARMOUR";
                if (rolenr1 == 1)
                  str = "STAFF";
                if (rolenr1 == 2)
                  str = "LANDCAP";
                if (rolenr1 == 3)
                  str = "SEACAP";
                if (rolenr1 == 5)
                  str = "ENGINEER";
                if (rolenr1 == 17)
                  str = "CARGOSHIP";
                if (rolenr1 == 19)
                  str = "RAIDER";
                if (rolenr1 == 18)
                  str = "SEA SUPRIORITY";
                if (rolenr1 == 13)
                  str = "FIGHTER";
                if (rolenr1 == 14)
                  str = "TACTICAL BOMBER";
                this.AddLog("RL#" + Conversion.Str((object) num1) + "..." + this.game.Data.UnitObj[unr].Name + " => ROLE = " + str);
              }
            }
          }
        }
      }
      if (simpleList1.Counter == -1)
      {
        int tplanCount = this.TPlanCount;
        for (int landres1 = 1; landres1 <= tplanCount; ++landres1)
        {
          if (this.TPlanObj[landres1].Type == 30 && this.TPlanObj[landres1].HQ > -1 & landres1 != landres && this.game.Data.UnitObj[this.TPlanObj[landres1].HQ].HQ == this.TPlanObj[landres].HQ)
          {
            SimpleList simpleList2 = new SimpleList();
            SimpleList simpleList3 = this.ProdWishes(landres1, locnr);
            if (simpleList3.Counter > -1)
            {
              int counter = simpleList3.Counter;
              for (int index = 0; index <= counter; ++index)
              {
                ++num1;
                simpleList1.Add(num1, simpleList3.Weight[index], simpleList3.Data1[index], simpleList3.Data2[index], simpleList3.Data3[index], simpleList3.Data4[index]);
              }
            }
          }
        }
      }
      for (int counter = simpleList1.Counter; counter >= 0; counter += -1)
      {
        if (simpleList1.Data2[counter] == -1 & simpleList1.Data3[counter] == -1)
          simpleList1.Remove(simpleList1.Id[counter]);
      }
      if (this.CanProduceAir() & (double) this.game.Data.RuleVar[221] > 0.0 & this.game.Data.Round > 3 && (double) this.GetAirPart(landres) < (double) this.game.Data.RuleVar[224])
      {
        for (int counter = simpleList1.Counter; counter >= 0; counter += -1)
        {
          if (simpleList1.Data2[counter] > -1)
          {
            int isSfType = this.game.Data.ItemTypeObj[simpleList1.Data2[counter]].IsSFType;
            if (isSfType > -1 && this.game.Data.SFTypeObj[isSfType].Theater != 2 && (double) VBMath.Rnd() > 0.66)
              simpleList1.Remove(simpleList1.Id[counter]);
          }
        }
      }
      return simpleList1;
    }

    public float GetAirPart(int landres)
    {
      int unitCounter = this.game.Data.UnitCounter;
      int num1;
      int num2;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index1].PreDef == -1 & this.game.Data.UnitObj[index1].X > -1 && this.HexSA[this.game.Data.UnitObj[index1].X, this.game.Data.UnitObj[index1].Y] > 0 && this.SAObj[this.HexSA[this.game.Data.UnitObj[index1].X, this.game.Data.UnitObj[index1].Y]].LandReservePlan == landres)
        {
          int sfCount = this.game.Data.UnitObj[index1].SFCount;
          for (int index2 = 0; index2 <= sfCount; ++index2)
          {
            int sf = this.game.Data.UnitObj[index1].SFList[index2];
            int type = this.game.Data.SFObj[sf].Type;
            if (this.game.Data.SFTypeObj[type].Theater == 2)
              num1 += this.game.Data.SFTypeObj[type].PowerPts * this.game.Data.SFObj[sf].Qty;
            num2 += this.game.Data.SFTypeObj[type].PowerPts * this.game.Data.SFObj[sf].Qty;
          }
        }
      }
      if (num2 < 1)
        num2 = 1;
      return (float) num1 / (float) num2;
    }

    public bool needcargoships(int landres)
    {
      int num1 = 1;
      int num2 = 0;
      int Left = 0;
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & !this.game.Data.UnitObj[unr].IsHQ && this.game.Data.UnitObj[unr].AIPlanNr > 0 & !this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].PreDef == -1 && this.SAObj[this.GetAreaNr(this.TPlanObj[this.game.Data.UnitObj[unr].AIPlanNr].FromArea)].LandReservePlan == landres)
        {
          num2 += this.game.HandyFunctionsObj.GetCarryCapPts(unr, 1);
          if (!this.game.Data.UnitObj[unr].AIReserve)
            Left = Conversions.ToInteger(Operators.AddObject((object) Left, this.game.HandyFunctionsObj.GetUnitNonSeaWeight(unr, false)));
        }
      }
      if (num2 >= Left)
        num1 = 0;
      return num1 != 0;
    }

    public object GetEPPerTurn(int unr)
    {
      int epPerTurn = 0;
      int sfCount = this.game.Data.UnitObj[unr].SFCount;
      for (int index = 0; index <= sfCount; ++index)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index];
        int type = this.game.Data.SFObj[sf].Type;
        if (this.game.Data.SFTypeObj[type].EP > 0)
          epPerTurn += this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].EP;
      }
      return (object) epPerTurn;
    }

    public bool IsHQinChain(int unr, int hq)
    {
      int num;
      do
      {
        ++num;
        int hq1 = this.game.Data.UnitObj[unr].HQ;
        if (hq1 == -1)
          return false;
        if (hq1 == hq)
          return true;
        unr = hq1;
      }
      while (num <= 9);
      this.game.Data.UnitObj[unr].HQ = -1;
      return false;
    }

    public int ProdGetRole(int locnr, int rolenr, bool returnsftypnr = false)
    {
      int num1 = -1;
      int num2 = -1;
      CanProduceItemResult produceItemResult = new CanProduceItemResult();
      if (rolenr == -1)
        return -1;
      int itemTypeCounter = this.game.Data.ItemTypeCounter;
      for (int itemtypenr = 0; itemtypenr <= itemTypeCounter; ++itemtypenr)
      {
        if (this.game.Data.ItemTypeObj[itemtypenr].IsSFType > -1)
        {
          if (returnsftypnr | locnr == -1)
          {
            produceItemResult.result = false;
            int locCounter = this.game.Data.LocCounter;
            for (int locnr1 = 0; locnr1 <= locCounter; ++locnr1)
            {
              if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[locnr1].X, this.game.Data.LocObj[locnr1].Y].Regime == this.game.Data.Turn)
              {
                produceItemResult = this.game.HandyFunctionsObj.CanProduceItem(locnr1, this.game.Data.Turn, itemtypenr);
                if (produceItemResult.result)
                  break;
              }
            }
          }
          else
            produceItemResult = this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, itemtypenr);
          if (produceItemResult.result)
          {
            int isSfType = this.game.Data.ItemTypeObj[itemtypenr].IsSFType;
            int num3;
            if (this.game.Data.SFTypeObj[isSfType].AIRoleScore[rolenr] > num3)
            {
              num1 = itemtypenr;
              num2 = isSfType;
              num3 = this.game.Data.SFTypeObj[isSfType].AIRoleScore[rolenr];
            }
          }
        }
      }
      return returnsftypnr ? num2 : num1;
    }

    public int ProdGetPPItem(int locnr)
    {
      int itemTypeCounter = this.game.Data.ItemTypeCounter;
      for (int itemtypenr = 0; itemtypenr <= itemTypeCounter; ++itemtypenr)
      {
        if (this.game.Data.ItemTypeObj[itemtypenr].IsResPt && this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, itemtypenr).result)
          return itemtypenr;
      }
      return -1;
    }

    public int ProdGetSupplyItem(int locnr)
    {
      int itemTypeCounter = this.game.Data.ItemTypeCounter;
      for (int itemtypenr = 0; itemtypenr <= itemTypeCounter; ++itemtypenr)
      {
        if (this.game.Data.ItemTypeObj[itemtypenr].IsSupply && this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, itemtypenr).result)
          return itemtypenr;
      }
      return -1;
    }

    public bool CanProduceAir()
    {
      int num = 0;
      int itemTypeCounter = this.game.Data.ItemTypeCounter;
      for (int itemtypenr = 0; itemtypenr <= itemTypeCounter; ++itemtypenr)
      {
        int isSfType = this.game.Data.ItemTypeObj[itemtypenr].IsSFType;
        if (isSfType > -1 && this.game.Data.SFTypeObj[isSfType].Theater == 2 && this.game.HandyFunctionsObj.CanProduceItem(-1, this.game.Data.Turn, itemtypenr, this.game.Data.RegimeObj[this.game.Data.Turn].People).result)
          ++num;
      }
      return num != 0;
    }

    public void ExecNewairunits(int phase)
    {
      bool[] flagArray = new bool[this.game.Data.UnitCounter + 1];
      int[] numArray1 = new int[this.game.Data.UnitCounter + 1];
      if ((double) this.game.Data.RuleVar[221] < 1.0 || (double) this.game.Data.RuleVar[249] == 1.0)
        return;
      this.AddLog("");
      this.AddLog("New Air Units:");
      if (!this.CanProduceAir())
        return;
      int unitCounter1 = this.game.Data.UnitCounter;
      int num1;
      for (int index1 = 0; index1 <= unitCounter1; ++index1)
      {
        if (this.game.Data.UnitObj[index1].AIUnitGoal == 5 & this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index1].PreDef == -1)
        {
          int index2 = this.HexSA[this.game.Data.UnitObj[index1].X, this.game.Data.UnitObj[index1].Y];
          if (this.SAObj[index2].LandReservePlan > 0 && this.TPlanObj[this.SAObj[index2].LandReservePlan].HQ > -1)
          {
            int[] numArray2 = numArray1;
            int[] numArray3 = numArray2;
            int hq = this.TPlanObj[this.SAObj[index2].LandReservePlan].HQ;
            int index3 = hq;
            int num2 = numArray2[hq] + 1;
            numArray3[index3] = num2;
          }
          ++num1;
        }
      }
      int tplanCount1 = this.TPlanCount;
      int num3;
      for (int index = 1; index <= tplanCount1; ++index)
      {
        if (this.TPlanObj[index].Type == 40)
          ++num3;
      }
      if (num1 >= num3)
        return;
      int tplanCount2 = this.TPlanCount;
      for (int Number = 1; Number <= tplanCount2; ++Number)
      {
        if (this.TPlanObj[Number].Type == 40)
        {
          int num4 = 0;
          int unitCounter2 = this.game.Data.UnitCounter;
          for (int index = 0; index <= unitCounter2; ++index)
          {
            if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index].AIUnitGoal == 5 & this.game.Data.UnitObj[index].AIPlanNr == Number)
              ++num4;
          }
          if (num4 == 0 && (double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= (double) this.game.Data.RuleVar[46] | (double) this.game.Data.RuleVar[863] > 0.0 && this.SAObj[this.GetAreaNr(this.TPlanObj[Number].FromArea)].LandReservePlan > 0)
          {
            int hq = this.TPlanObj[this.SAObj[this.GetAreaNr(this.TPlanObj[Number].FromArea)].LandReservePlan].HQ;
            if (hq > -1 && this.game.HandyFunctionsObj.HasUnitAirSF(hq) | numArray1[hq] == 0 && this.TPlanObj[Number].FriendlyAir < 1 | numArray1[hq] == 0 && !flagArray[hq] & this.game.Data.UnitObj[hq].AIPlanNr > 0)
            {
              int x = this.TPlanObj[this.game.Data.UnitObj[hq].AIPlanNr].FromArea.X;
              int y = this.TPlanObj[this.game.Data.UnitObj[hq].AIPlanNr].FromArea.Y;
              if (this.game.HandyFunctionsObj.IsHexAirfield(x, y, 0) & this.game.Data.MapObj[0].HexObj[x, y].UnitCounter < 15)
              {
                this.game.ProcessingObj.NewUnit(x, y, 0, false, this.game.Data.Turn);
                this.game.Data.UnitObj[this.game.Data.UnitCounter].HQ = hq;
                this.game.Data.UnitObj[this.game.Data.UnitCounter].AIPlanNr = Number;
                this.game.Data.UnitObj[this.game.Data.UnitCounter].AIUnitGoal = 5;
                this.AddLog("New Air unit placed at " + Conversion.Str((object) x) + "," + Conversion.Str((object) y) + " for plan #" + Conversion.Str((object) Number));
                int[] numArray4 = numArray1;
                int[] numArray5 = numArray4;
                int index4 = hq;
                int index5 = index4;
                int num5 = numArray4[index4] + 1;
                numArray5[index5] = num5;
                flagArray[hq] = true;
              }
            }
          }
        }
      }
    }

    public bool MakeNavyActive(int plnr)
    {
      int num1 = 1;
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].AIPlanNr == plnr && this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & this.game.HandyFunctionsObj.HasUnitNavySF(unr))
          return true;
      }
      int saCount1 = this.SACount;
      for (int area1 = 1; area1 <= saCount1; ++area1)
      {
        if (this.SAObj[area1].ConstitutantCount < 1)
        {
          int saCount2 = this.SACount;
          for (int index = 1; index <= saCount2; ++index)
          {
            if (this.SAObj[index].ConstitutantCount < 1 && this.HexOA[this.SAObj[index].X, this.SAObj[index].Y] == this.HexOA[this.TPlanObj[plnr].FromArea.X, this.TPlanObj[plnr].FromArea.Y] && area1 != index)
            {
              int num2 = 0;
              if (this.game.Data.MapObj[0].HexObj[this.SAObj[area1].X, this.SAObj[area1].Y].Regime != -1 && this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[this.game.Data.MapObj[0].HexObj[this.SAObj[area1].X, this.SAObj[area1].Y].Regime] == 0)
                num2 = 1;
              if (num2 == 1)
              {
                if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[this.SAObj[index].X, this.SAObj[index].Y].Regime, this.game.Data.Turn))
                {
                  if (this.SAObj[area1].IsNeighbour(index))
                    num1 = 0;
                }
                else if (this.JoinedNeighbour(area1, index))
                  num1 = 0;
              }
            }
          }
        }
      }
      return num1 == 1;
    }

    public void ExecNewNavyunits(int phase)
    {
      bool[] flagArray = new bool[this.game.Data.UnitCounter + 1];
      int[] numArray = new int[this.game.Data.UnitCounter + 1];
      if ((double) this.game.Data.RuleVar[227] < 1.0)
        return;
      this.AddLog("");
      this.AddLog("New Navy Units:");
      if ((double) this.game.Data.RuleVar[249] == 1.0)
        return;
      int tplanCount = this.TPlanCount;
      for (int index1 = 1; index1 <= tplanCount; ++index1)
      {
        if (this.TPlanObj[index1].Type == 40 & this.SAObj[this.GetAreaNr(this.TPlanObj[index1].FromArea)].SeaNeighbourCount > 0 && this.TPlanObj[index1].SeaTarget > 0 && this.MakeNavyActive(index1))
        {
          int num1 = 0;
          int unitCounter = this.game.Data.UnitCounter;
          for (int index2 = 0; index2 <= unitCounter; ++index2)
          {
            if (this.game.Data.UnitObj[index2].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index2].AIPlanNr == index1 && this.game.Data.UnitObj[index2].AIUnitGoal == 10 | this.game.Data.UnitObj[index2].AIUnitGoal == 9 | this.game.Data.UnitObj[index2].AIUnitGoal == 8)
            {
              ++num1;
              if (this.game.Data.UnitObj[index2].SFCount == -1 & this.TPlanObj[index1].FromArea.LandReservePlan > -1)
              {
                int hq = this.TPlanObj[this.SAObj[this.GetAreaNr(this.TPlanObj[index1].FromArea)].LandReservePlan].HQ;
                if (hq > -1)
                  flagArray[hq] = true;
              }
            }
          }
          int num2 = 0;
          if ((double) num2 < (double) this.game.Data.RuleVar[239])
            num2 = (int) Math.Round((double) this.game.Data.RuleVar[239]);
          if (this.TPlanObj[index1].SeaTarget > 0 & this.TPlanObj[index1].SeaTarget <= this.SACount)
          {
            int num3 = this.game.HandyFunctionsObj.Distance(this.TPlanObj[index1].FromArea.X, this.TPlanObj[index1].FromArea.Y, 0, this.SAObj[this.TPlanObj[index1].SeaTarget].X, this.SAObj[this.TPlanObj[index1].SeaTarget].Y, 0);
            if (num3 > 10)
              num2 = (int) Math.Round((double) num2 + Math.Sqrt((double) (num3 - 10) / 10.0) * (double) this.game.Data.RuleVar[239]);
          }
          if (this.TPlanObj[index1].EnemyNavy == 0)
            num2 = this.TPlanObj[index1].SeaTarget >= 1 ? (int) Math.Round(1.0 + (double) num2 / 2.0) : 0;
          if (num1 < num2 && (double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= (double) this.game.Data.RuleVar[46] | (double) this.game.Data.RuleVar[863] > 0.0 && this.SAObj[this.GetAreaNr(this.TPlanObj[index1].FromArea)].LandReservePlan > 0)
          {
            int hq = this.TPlanObj[this.SAObj[this.GetAreaNr(this.TPlanObj[index1].FromArea)].LandReservePlan].HQ;
            if (hq > -1 && !flagArray[hq])
            {
              int x = this.game.Data.UnitObj[hq].X;
              int y = this.game.Data.UnitObj[hq].Y;
              if (this.game.HandyFunctionsObj.IsHexPort(x, y, 0) & this.game.Data.MapObj[0].HexObj[x, y].Regime == this.game.Data.Turn & this.game.Data.MapObj[0].HexObj[x, y].UnitCounter < 15)
              {
                this.game.ProcessingObj.NewUnit(x, y, 0, false, this.game.Data.Turn);
                this.game.Data.UnitObj[this.game.Data.UnitCounter].HQ = hq;
                this.game.Data.UnitObj[this.game.Data.UnitCounter].AIPlanNr = index1;
                this.game.Data.UnitObj[this.game.Data.UnitCounter].AIUnitGoal = 0;
                this.AddLog("New Naval unit placed at " + Conversion.Str((object) x) + "," + Conversion.Str((object) y) + " for plan #" + Conversion.Str((object) index1));
                flagArray[hq] = true;
                this.InitUnitGoals(this.game.Data.UnitCounter);
              }
            }
          }
        }
      }
    }

    public bool Existingunitsok(int plnr)
    {
      int num1 = 999;
      int unitCounter = this.game.Data.UnitCounter;
      int num2;
      int num3;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].AIPlanNr == plnr & this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].X > -1)
        {
          int powerPtsAbsolute = this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unr, true);
          num2 += powerPtsAbsolute;
          ++num3;
          if (powerPtsAbsolute < num1)
            num1 = powerPtsAbsolute;
        }
      }
      if (num3 < 1)
        return true;
      int num4 = (int) Math.Round((double) num2 / (double) num3);
      return (double) num1 >= (double) this.game.Data.RuleVar[182] && (double) num4 >= (double) this.game.Data.RuleVar[247];
    }

    public int GetPlanUnitGoalPercent(int plnr, int goaltype)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int num5 = 0;
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (!this.game.Data.UnitObj[index].IsHQ && this.game.Data.UnitObj[index].AIPlanNr == plnr & this.game.Data.UnitObj[index].Regime == this.game.Data.Turn)
        {
          if (this.game.Data.UnitObj[index].AIUnitGoal > 0 & this.game.Data.UnitObj[index].PreDef == -1)
          {
            int aiUnitGoal = this.game.Data.UnitObj[index].AIUnitGoal;
            if (aiUnitGoal == 1)
            {
              ++num1;
              ++num4;
            }
            if (aiUnitGoal == 2)
            {
              ++num2;
              ++num4;
            }
            if (aiUnitGoal == 3)
            {
              ++num3;
              ++num4;
            }
          }
          ++num5;
        }
      }
      if (num4 == 0)
        return 0;
      switch (goaltype)
      {
        case 1:
          return (int) Math.Round((double) (num1 * 100) / (double) num4);
        case 2:
          return (int) Math.Round((double) (num2 * 100) / (double) num4);
        case 3:
          return (int) Math.Round((double) (num3 * 100) / (double) num4);
        default:
          return 0;
      }
    }

    public void ExecNewLandUnits(int phase)
    {
      this.AddLog("");
      this.AddLog("New Units:");
      if ((double) this.game.Data.RuleVar[249] == 1.0)
        return;
      if (phase == 1)
      {
        int tplanCount = this.TPlanCount;
        for (int index1 = 1; index1 <= tplanCount; ++index1)
        {
          if (this.TPlanObj[index1].Type == 20)
          {
            float num1 = (float) this.TPlanObj[index1].FriendlyUnitCount;
            if ((double) num1 < 1.0)
              num1 = 0.25f;
            int num2 = 0;
            if (this.TPlanObj[index1].Stand == 1)
            {
              if ((double) this.GetPlanUnitGoalPercent(index1, 2) < (double) this.game.Data.RuleVar[171] * 0.66)
                num2 = 1;
              if ((double) this.GetPlanUnitGoalPercent(index1, 1) < (double) this.game.Data.RuleVar[172] * 0.66)
                num2 = 1;
              if ((double) this.GetPlanUnitGoalPercent(index1, 3) < (double) this.game.Data.RuleVar[173])
                num2 = 1;
            }
            else
            {
              if ((double) this.GetPlanUnitGoalPercent(index1, 2) < (double) this.game.Data.RuleVar[161] * 0.66)
                num2 = 1;
              if ((double) this.GetPlanUnitGoalPercent(index1, 1) < (double) this.game.Data.RuleVar[162] * 0.66)
                num2 = 1;
              if ((double) this.GetPlanUnitGoalPercent(index1, 3) < (double) this.game.Data.RuleVar[163])
                num2 = 1;
            }
            if (num2 == 1)
              this.AddLog("Set ok3=1 because we need other unitgoals in plan too.");
            if ((double) (this.TPlanObj[index1].FrontSize * 100) / (double) num1 > (double) this.game.Data.RuleVar[155] | num2 == 1)
            {
              int num3 = this.TPlanObj[index1].EnemyUnitCount * 1;
              if (num3 == 0)
                num3 = 1;
              if (this.TPlanObj[index1].FriendlyUnitCount < num3 & this.Existingunitsok(index1) | num2 == 1 && (double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= (double) this.game.Data.RuleVar[46] | (double) this.game.Data.RuleVar[863] > 0.0 && this.SAObj[this.GetAreaNr(this.TPlanObj[index1].FromArea)].LandReservePlan > 0)
              {
                int hq = this.TPlanObj[this.SAObj[this.GetAreaNr(this.TPlanObj[index1].FromArea)].LandReservePlan].HQ;
                int num4 = 0;
                if (hq > -1)
                {
                  int sfCount = this.game.Data.UnitObj[hq].SFCount;
                  for (int index2 = 0; index2 <= sfCount; ++index2)
                  {
                    int sf = this.game.Data.UnitObj[hq].SFList[index2];
                    int type = this.game.Data.SFObj[sf].Type;
                    if (this.game.Data.SFTypeObj[type].AIRoleScore[1] < 1 && this.game.Data.SFTypeObj[type].AIRoleScore[2] < 1)
                      num4 += this.game.Data.SFTypeObj[type].PowerPts * this.game.Data.SFObj[sf].Qty;
                  }
                }
                if (this.TPlanObj[index1].FriendlyUnitCount == 0 & this.TPlanObj[index1].TooArea.aivp > 0)
                  num4 = 1;
                if (num4 > 0 & hq > -1 && this.game.Data.UnitObj[hq].LandCap > 0 | (double) this.game.Data.RuleVar[253] == 0.0 | this.TPlanObj[index1].FriendlyUnitCount == 0 & this.TPlanObj[index1].TooArea.aivp > 0)
                {
                  int num5 = 0;
                  int unitCounter = this.game.Data.UnitCounter;
                  for (int unr = 0; unr <= unitCounter; ++unr)
                  {
                    if (this.game.Data.UnitObj[unr].AIPlanNr == index1 && this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && (double) this.game.HandyFunctionsObj.GetUnitStackPts(unr) < (double) this.game.Data.RuleVar[182])
                      num5 = 1;
                  }
                  if (num5 == 0)
                  {
                    int x;
                    int y;
                    int num6;
                    if (this.TPlanObj[index1].HQ > -1)
                    {
                      x = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].X;
                      y = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].Y;
                      num6 = this.TPlanObj[index1].HQ;
                    }
                    else
                    {
                      num6 = this.SAObj[this.GetAreaNr(this.TPlanObj[index1].FromArea)].LandReservePlan <= 0 ? -1 : this.TPlanObj[this.SAObj[this.GetAreaNr(this.TPlanObj[index1].FromArea)].LandReservePlan].HQ;
                      x = this.TPlanObj[index1].FromArea.X;
                      y = this.TPlanObj[index1].FromArea.Y;
                      if (this.TPlanObj[index1].Stand == 3)
                      {
                        int neighbourForRetreater = this.GetBestNeighbourForRetreater(this.GetAreaNr(this.TPlanObj[index1].FromArea));
                        if (neighbourForRetreater > -1)
                        {
                          x = this.SAObj[neighbourForRetreater].X;
                          y = this.SAObj[neighbourForRetreater].Y;
                        }
                      }
                    }
                    if (this.game.Data.MapObj[0].HexObj[x, y].Regime == this.game.Data.Turn & this.game.Data.MapObj[0].HexObj[x, y].UnitCounter < 15)
                    {
                      this.game.ProcessingObj.NewUnit(x, y, 0, false, this.game.Data.Turn);
                      this.game.Data.UnitObj[this.game.Data.UnitCounter].HQ = num6;
                      this.game.Data.UnitObj[this.game.Data.UnitCounter].AIPlanNr = index1;
                      AIPlanClass[] tplanObj = this.TPlanObj;
                      AIPlanClass[] aiPlanClassArray = tplanObj;
                      int index3 = index1;
                      int index4 = index3;
                      aiPlanClassArray[index4].FriendlyUnitCount = tplanObj[index3].FriendlyUnitCount + 1;
                      this.AddLog("New unit placed at " + Conversion.Str((object) x) + "," + Conversion.Str((object) y) + " for plan #" + Conversion.Str((object) index1));
                      this.InitUnitGoals(this.game.Data.UnitCounter);
                    }
                  }
                }
              }
            }
          }
          if (this.TPlanObj[index1].Type == 40 && this.SAObj[this.GetAreaNr(this.TPlanObj[index1].FromArea)].LandReservePlan > 0)
          {
            int num7 = 0;
            int unitCounter = this.game.Data.UnitCounter;
            for (int index5 = 0; index5 <= unitCounter; ++index5)
            {
              if (this.game.Data.UnitObj[index5].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index5].AIPlanNr == index1 && this.game.Data.UnitObj[index5].AIUnitGoal == 1 && this.game.Data.UnitObj[index5].X > -1 & !this.game.Data.UnitObj[index5].AIReserve && this.HexSA[this.game.Data.UnitObj[index5].X, this.game.Data.UnitObj[index5].Y] == this.GetAreaNr(this.TPlanObj[index1].FromArea))
                ++num7;
            }
            if (num7 < 2 && this.TPlanObj[index1].EnemyUnitCount < 1 && !this.EmptyUnitForPlan(this.TPlanObj[index1].FromArea.X, this.TPlanObj[index1].FromArea.Y, index1, 1) && this.TPlanObj[index1].SeaTarget > 0 & this.TPlanObj[index1].SeaStand == 7 && this.MakeNavyActive(index1))
            {
              int x;
              int y;
              int num8;
              if (this.TPlanObj[index1].HQ > -1)
              {
                x = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].X;
                y = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].Y;
                num8 = this.TPlanObj[index1].HQ;
              }
              else
              {
                num8 = this.SAObj[this.GetAreaNr(this.TPlanObj[index1].FromArea)].LandReservePlan <= 0 ? -1 : this.TPlanObj[this.SAObj[this.GetAreaNr(this.TPlanObj[index1].FromArea)].LandReservePlan].HQ;
                x = this.TPlanObj[index1].FromArea.X;
                y = this.TPlanObj[index1].FromArea.Y;
              }
              if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[x, y].Regime, this.game.Data.Turn) & this.game.Data.MapObj[0].HexObj[x, y].UnitCounter < 15)
              {
                RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                RegimeClass[] regimeClassArray = regimeObj;
                int turn = this.game.Data.Turn;
                int index6 = turn;
                regimeClassArray[index6].ResPts = (int) Math.Round((double) ((float) regimeObj[turn].ResPts + this.game.Data.RuleVar[46]));
                this.game.ProcessingObj.NewUnit(x, y, 0, false, this.game.Data.Turn);
                this.game.Data.UnitObj[this.game.Data.UnitCounter].HQ = num8;
                this.game.Data.UnitObj[this.game.Data.UnitCounter].AIPlanNr = index1;
                this.game.Data.UnitObj[this.game.Data.UnitCounter].AIUnitGoal = 1;
                AIPlanClass[] tplanObj = this.TPlanObj;
                AIPlanClass[] aiPlanClassArray = tplanObj;
                int index7 = index1;
                int index8 = index7;
                aiPlanClassArray[index8].FriendlyUnitCount = tplanObj[index7].FriendlyUnitCount + 1;
                this.AddLog("New INF unit placed for AMPHIBIOUS OPS at " + Conversion.Str((object) x) + "," + Conversion.Str((object) y) + " for plan #" + Conversion.Str((object) index1));
              }
            }
          }
          if (this.TPlanObj[index1].Type == 40 && this.SAObj[this.GetAreaNr(this.TPlanObj[index1].FromArea)].LandReservePlan > 0)
          {
            int num9 = 0;
            int unitCounter = this.game.Data.UnitCounter;
            for (int index9 = 0; index9 <= unitCounter; ++index9)
            {
              if (this.game.Data.UnitObj[index9].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index9].AIPlanNr == index1 && this.game.Data.UnitObj[index9].AIUnitGoal == 1 && this.game.Data.UnitObj[index9].X > -1 & this.game.Data.UnitObj[index9].AIReserve && this.HexSA[this.game.Data.UnitObj[index9].X, this.game.Data.UnitObj[index9].Y] == this.GetAreaNr(this.TPlanObj[index1].FromArea))
                ++num9;
            }
            if (num9 < 1 && this.getfrontplan(this.TPlanObj[index1].FromArea.X, this.TPlanObj[index1].FromArea.Y) == -1 && !this.EmptyUnitForPlan(this.TPlanObj[index1].FromArea.X, this.TPlanObj[index1].FromArea.Y, index1, 1))
            {
              int num10 = 0;
              if (this.TPlanObj[index1].SeaTarget < 1 & this.SAObj[this.GetAreaNr(this.TPlanObj[index1].FromArea)].SeaNeighbourCount > 0)
                num10 = 1;
              if (num10 == 0 & (double) this.game.Data.RuleVar[252] > 0.0 && this.TPlanObj[index1].AssemblyArea == 1)
                num10 = 1;
              if (num10 == 0 & (double) this.game.Data.RuleVar[256] > 0.0 && this.TPlanObj[index1].AssemblyArea == 1)
                num10 = 1;
              if (num10 == 1)
              {
                int x;
                int y;
                int num11;
                if (this.TPlanObj[index1].HQ > -1)
                {
                  x = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].X;
                  y = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].Y;
                  num11 = this.TPlanObj[index1].HQ;
                }
                else
                {
                  num11 = this.SAObj[this.GetAreaNr(this.TPlanObj[index1].FromArea)].LandReservePlan <= 0 ? -1 : this.TPlanObj[this.SAObj[this.GetAreaNr(this.TPlanObj[index1].FromArea)].LandReservePlan].HQ;
                  x = this.TPlanObj[index1].FromArea.X;
                  y = this.TPlanObj[index1].FromArea.Y;
                }
                if (this.game.Data.MapObj[0].HexObj[x, y].UnitCounter < 15)
                {
                  RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                  RegimeClass[] regimeClassArray = regimeObj;
                  int turn = this.game.Data.Turn;
                  int index10 = turn;
                  regimeClassArray[index10].ResPts = (int) Math.Round((double) ((float) regimeObj[turn].ResPts + this.game.Data.RuleVar[46]));
                  this.game.ProcessingObj.NewUnit(x, y, 0, false, this.game.Data.Turn);
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].HQ = num11;
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIPlanNr = index1;
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIUnitGoal = (double) VBMath.Rnd() <= 0.5 ? 2 : 1;
                  AIPlanClass[] tplanObj = this.TPlanObj;
                  AIPlanClass[] aiPlanClassArray = tplanObj;
                  int index11 = index1;
                  int index12 = index11;
                  aiPlanClassArray[index12].FriendlyUnitCount = tplanObj[index11].FriendlyUnitCount + 1;
                  this.AddLog("New INF or ARM unit placed for BACKPLAN WITHOUT AMPH/FRONT or DEFENSE IN DEPTH at " + Conversion.Str((object) x) + "," + Conversion.Str((object) y) + " for plan #" + Conversion.Str((object) index1));
                }
              }
            }
          }
        }
      }
      if (phase != 2)
        return;
      int tplanCount1 = this.TPlanCount;
      for (int index13 = 1; index13 <= tplanCount1; ++index13)
      {
        int hq = this.TPlanObj[index13].HQ;
        if (hq > -1)
        {
          int num12 = 0;
          int num13 = 0;
          int num14 = 0;
          int num15 = 0;
          int x = this.game.Data.UnitObj[hq].X;
          int y = this.game.Data.UnitObj[hq].Y;
          int sfCount = this.game.Data.UnitObj[hq].SFCount;
          for (int index14 = 0; index14 <= sfCount; ++index14)
          {
            int sf = this.game.Data.UnitObj[hq].SFList[index14];
            int type = this.game.Data.SFObj[sf].Type;
            if (this.game.Data.SFTypeObj[type].AIRoleScore[1] < 1 && this.game.Data.SFTypeObj[type].AIRoleScore[2] < 1 && this.game.Data.SFTypeObj[type].AIRoleScore[5] < 1 && this.game.Data.SFTypeObj[type].AIRoleScore[7] < 25 && this.game.Data.SFTypeObj[type].AIRoleScore[12] < 25)
            {
              num12 += this.game.Data.SFTypeObj[type].PowerPts * this.game.Data.SFObj[sf].Qty;
              if (this.game.Data.SFTypeObj[type].AIRoleScore[6] > 50)
                num13 = 1;
              if (this.game.Data.SFTypeObj[type].AIRoleScore[10] > 50)
                num14 = 1;
              if (this.game.Data.SFTypeObj[type].AIRoleScore[8] > 50)
                num15 = 1;
            }
          }
          if (num12 > 0 & (num13 > 0 | num14 > 0 | num15 > 0))
          {
            int Number = this.getclosestplan(x, y, 20);
            if (Number > -1)
            {
              int unitCounter = this.game.Data.MapObj[0].HexObj[x, y].UnitCounter;
              for (int index15 = 0; index15 <= unitCounter; ++index15)
              {
                int unit = this.game.Data.MapObj[0].HexObj[x, y].UnitList[index15];
                if (!this.game.Data.UnitObj[unit].IsHQ & this.game.Data.UnitObj[unit].SFCount == -1 && this.game.Data.UnitObj[unit].AIUnitGoal == 1 | this.game.Data.UnitObj[unit].AIUnitGoal == 2 | this.game.Data.UnitObj[unit].AIUnitGoal == 3)
                {
                  this.AddLog("Already empty unit at HQ");
                  Number = -1;
                }
              }
            }
            if (Number > -1)
            {
              if (((double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= (double) this.game.Data.RuleVar[46] | (double) this.game.Data.RuleVar[863] > 0.0) & this.game.Data.MapObj[0].HexObj[x, y].UnitCounter < 15)
              {
                this.game.ProcessingObj.NewUnit(x, y, 0, false, this.game.Data.Turn);
                this.game.Data.UnitObj[this.game.Data.UnitCounter].HQ = hq;
                this.game.Data.UnitObj[this.game.Data.UnitCounter].AIPlanNr = Number;
                AIPlanClass[] tplanObj = this.TPlanObj;
                AIPlanClass[] aiPlanClassArray = tplanObj;
                int index16 = index13;
                int index17 = index16;
                aiPlanClassArray[index17].FriendlyUnitCount = tplanObj[index16].FriendlyUnitCount + 1;
                this.AddLog("New unit placed at Landreserve " + Conversion.Str((object) x) + "," + Conversion.Str((object) y) + " for plan #" + Conversion.Str((object) Number));
                if (num14 == 1)
                {
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIUnitGoal = 2;
                  num14 = 0;
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIMobilize = true;
                }
                else if (num15 == 1)
                {
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIUnitGoal = 3;
                  num15 = 0;
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIMobilize = true;
                }
                else if (num13 == 1)
                {
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIUnitGoal = 1;
                  num13 = 0;
                }
              }
              if ((double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= (double) this.game.Data.RuleVar[46] | (double) this.game.Data.RuleVar[863] > 0.0 && num14 > 0 | num15 > 0 | num13 > 0 & this.game.Data.MapObj[0].HexObj[x, y].UnitCounter < 15)
              {
                this.game.ProcessingObj.NewUnit(x, y, 0, false, this.game.Data.Turn);
                this.game.Data.UnitObj[this.game.Data.UnitCounter].HQ = hq;
                this.game.Data.UnitObj[this.game.Data.UnitCounter].AIPlanNr = Number;
                AIPlanClass[] tplanObj = this.TPlanObj;
                AIPlanClass[] aiPlanClassArray = tplanObj;
                int index18 = index13;
                int index19 = index18;
                aiPlanClassArray[index19].FriendlyUnitCount = tplanObj[index18].FriendlyUnitCount + 1;
                this.AddLog("New unit placed at Landreserve " + Conversion.Str((object) x) + "," + Conversion.Str((object) y) + " for plan #" + Conversion.Str((object) Number));
                if (num14 == 1)
                {
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIUnitGoal = 2;
                  num14 = 0;
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIMobilize = true;
                }
                else if (num15 == 1)
                {
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIUnitGoal = 3;
                  num15 = 0;
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIMobilize = true;
                }
                else if (num13 == 1)
                {
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIUnitGoal = 1;
                  num13 = 0;
                }
              }
              if (((double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= (double) this.game.Data.RuleVar[46] | (double) this.game.Data.RuleVar[863] > 0.0) & this.game.Data.MapObj[0].HexObj[x, y].UnitCounter < 15)
              {
                this.game.ProcessingObj.NewUnit(x, y, 0, false, this.game.Data.Turn);
                this.game.Data.UnitObj[this.game.Data.UnitCounter].HQ = hq;
                this.game.Data.UnitObj[this.game.Data.UnitCounter].AIPlanNr = Number;
                AIPlanClass[] tplanObj = this.TPlanObj;
                AIPlanClass[] aiPlanClassArray = tplanObj;
                int index20 = index13;
                int index21 = index20;
                aiPlanClassArray[index21].FriendlyUnitCount = tplanObj[index20].FriendlyUnitCount + 1;
                this.AddLog("New unit placed at Landreserve " + Conversion.Str((object) x) + "," + Conversion.Str((object) y) + " for plan #" + Conversion.Str((object) Number));
                if (num14 == 1)
                {
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIUnitGoal = 2;
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIMobilize = true;
                }
                else if (num15 == 1)
                {
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIUnitGoal = 3;
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIMobilize = true;
                }
                else if (num13 == 1)
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIUnitGoal = 1;
              }
            }
          }
        }
      }
    }

    public bool EmptyUnitForPlan(int x, int y, int plannr, int goal)
    {
      int unitCounter = this.game.Data.MapObj[0].HexObj[x, y].UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.game.Data.UnitObj[this.game.Data.MapObj[0].HexObj[x, y].UnitList[index]].AIUnitGoal == goal && this.game.Data.UnitObj[this.game.Data.MapObj[0].HexObj[x, y].UnitList[index]].SFCount == -1)
          return true;
      }
      return false;
    }

    public void ExecSplitLandUnits()
    {
      this.AddLog("");
      this.AddLog("Splitting Units:");
      if ((double) this.game.Data.RuleVar[249] == 1.0)
        return;
      int tplanCount1 = this.TPlanCount;
      int num1;
      for (int Number = 1; Number <= tplanCount1; ++Number)
      {
        if (this.TPlanObj[Number].Type == 20)
        {
          float num2 = (float) this.TPlanObj[Number].FriendlyUnitCount;
          if ((double) num2 < 1.0)
            num2 = 0.25f;
          if ((double) ((this.TPlanObj[Number].FrontSize + 1) * 100) / (double) num2 > (double) this.game.Data.RuleVar[155])
          {
            int num3 = this.TPlanObj[Number].EnemyUnitCount * 1;
            if (num3 == 0)
              num3 = 1;
            if (this.TPlanObj[Number].FriendlyUnitCount < num3 & this.TPlanObj[Number].FriendlyUnitCount > 0 && (double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= (double) this.game.Data.RuleVar[46] | (double) this.game.Data.RuleVar[863] > 0.0 && this.SAObj[this.GetAreaNr(this.TPlanObj[Number].FromArea)].LandReservePlan > 0)
            {
              SimpleList simpleList = new SimpleList();
              num1 = 0;
              int unitCounter = this.game.Data.UnitCounter;
              for (int index = 0; index <= unitCounter; ++index)
              {
                if (this.game.Data.UnitObj[index].AIPlanNr == Number && this.game.Data.UnitObj[index].Regime == this.game.Data.Turn && !this.game.Data.UnitObj[index].IsHQ)
                {
                  int unitStackPts = this.game.HandyFunctionsObj.GetUnitStackPts(index);
                  if ((double) unitStackPts >= (double) this.game.Data.RuleVar[247] * 2.5)
                    simpleList.Add(index, unitStackPts);
                }
              }
              simpleList.Sort();
              if (simpleList.Counter > -1)
              {
                int unr = simpleList.Id[simpleList.Counter];
                int x = this.game.Data.UnitObj[unr].X;
                int y = this.game.Data.UnitObj[unr].Y;
                int hq = this.game.Data.UnitObj[unr].HQ;
                if (this.game.Data.MapObj[0].HexObj[x, y].UnitCounter < 15)
                {
                  this.game.ProcessingObj.NewUnit(x, y, 0, false, this.game.Data.Turn);
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].HQ = hq;
                  this.game.Data.UnitObj[this.game.Data.UnitCounter].AIPlanNr = Number;
                  AIPlanClass[] tplanObj = this.TPlanObj;
                  AIPlanClass[] aiPlanClassArray = tplanObj;
                  int index1 = Number;
                  int index2 = index1;
                  aiPlanClassArray[index2].FriendlyUnitCount = tplanObj[index1].FriendlyUnitCount + 1;
                  this.AddLog("Unit " + this.game.Data.UnitObj[unr].Name + " split at " + Conversion.Str((object) x) + "," + Conversion.Str((object) y) + " for plan #" + Conversion.Str((object) Number));
                  for (int sfCount = this.game.Data.UnitObj[unr].SFCount; sfCount >= 0; sfCount += -1)
                  {
                    int sf = this.game.Data.UnitObj[unr].SFList[sfCount];
                    int Qty = (int) Math.Round(Conversion.Int((double) this.game.Data.SFObj[sf].Qty / 2.0));
                    if (Qty == 0 & this.game.Data.SFObj[sf].Qty > 0 && (double) VBMath.Rnd() > 0.5)
                      Qty = 1;
                    this.game.ProcessingObj.DoTransfer(unr, this.game.Data.UnitCounter, 0, sf, Qty, true);
                  }
                }
              }
            }
          }
        }
      }
      int tplanCount2 = this.TPlanCount;
      for (int Number = 1; Number <= tplanCount2; ++Number)
      {
        if (this.TPlanObj[Number].Type == 20 | this.TPlanObj[Number].Type == 40 && (double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= (double) this.game.Data.RuleVar[46] | (double) this.game.Data.RuleVar[863] > 0.0 && this.SAObj[this.GetAreaNr(this.TPlanObj[Number].FromArea)].LandReservePlan > 0)
        {
          num1 = 0;
          int unitCounter = this.game.Data.UnitCounter;
          for (int unr1 = 0; unr1 <= unitCounter; ++unr1)
          {
            if (this.game.Data.UnitObj[unr1].AIPlanNr == Number && this.game.Data.UnitObj[unr1].Regime == this.game.Data.Turn && !this.game.Data.UnitObj[unr1].IsHQ && this.game.Data.UnitObj[unr1].AIUnitGoal == 5 | this.game.Data.UnitObj[unr1].AIUnitGoal == 1 | this.game.Data.UnitObj[unr1].AIUnitGoal == 2 | this.game.Data.UnitObj[unr1].AIUnitGoal == 3 && (double) (this.game.HandyFunctionsObj.GetUnitStackPts(unr1) + this.game.HandyFunctionsObj.GetUnitairStackPts(unr1)) > (double) this.game.Data.RuleVar[30] && (double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= (double) this.game.Data.RuleVar[46])
            {
              int unr2 = unr1;
              int x = this.game.Data.UnitObj[unr2].X;
              int y = this.game.Data.UnitObj[unr2].Y;
              if (x > -1 & this.game.Data.UnitObj[unr2].PreDef == -1 && this.game.Data.MapObj[0].HexObj[x, y].UnitCounter < 15)
              {
                int hq = this.game.Data.UnitObj[unr2].HQ;
                this.game.ProcessingObj.NewUnit(x, y, 0, false, this.game.Data.Turn);
                this.game.Data.UnitObj[this.game.Data.UnitCounter].HQ = hq;
                this.game.Data.UnitObj[this.game.Data.UnitCounter].AIPlanNr = Number;
                AIPlanClass[] tplanObj = this.TPlanObj;
                AIPlanClass[] aiPlanClassArray = tplanObj;
                int index3 = Number;
                int index4 = index3;
                aiPlanClassArray[index4].FriendlyUnitCount = tplanObj[index3].FriendlyUnitCount + 1;
                this.AddLog("TO FAT Unit " + this.game.Data.UnitObj[unr2].Name + " split at " + Conversion.Str((object) x) + "," + Conversion.Str((object) y) + " for plan #" + Conversion.Str((object) Number));
                for (int sfCount = this.game.Data.UnitObj[unr2].SFCount; sfCount >= 0; sfCount += -1)
                {
                  int sf = this.game.Data.UnitObj[unr2].SFList[sfCount];
                  int Qty = (int) Math.Round(Conversion.Int((double) this.game.Data.SFObj[sf].Qty / 2.0));
                  if (Qty == 0 & this.game.Data.SFObj[sf].Qty > 0 && (double) VBMath.Rnd() > 0.5)
                    Qty = 1;
                  this.game.ProcessingObj.DoTransfer(unr2, this.game.Data.UnitCounter, 0, sf, Qty, true);
                }
              }
            }
          }
        }
      }
    }

    public void ExecDisbandForTransfer()
    {
      int num = 1;
      while (num == 1)
      {
        num = 0;
        int tplanCount = this.TPlanCount;
        for (int Number = 1; Number <= tplanCount; ++Number)
        {
          if (this.TPlanObj[Number].Type == 30)
          {
            int hq = this.TPlanObj[Number].HQ;
            if (hq > -1)
            {
              int x = this.game.Data.UnitObj[hq].X;
              int y = this.game.Data.UnitObj[hq].Y;
              for (int unitCounter = this.game.Data.MapObj[0].HexObj[x, y].UnitCounter; unitCounter >= 0; unitCounter += -1)
              {
                int unit = this.game.Data.MapObj[0].HexObj[x, y].UnitList[unitCounter];
                if (this.game.Data.UnitObj[unit].AIDisband & hq != unit && this.game.Data.UnitObj[unit].SFCount > -1)
                {
                  for (int sfCount = this.game.Data.UnitObj[unit].SFCount; sfCount >= 0; sfCount += -1)
                  {
                    int sf = this.game.Data.UnitObj[unit].SFList[sfCount];
                    int qty = this.game.Data.SFObj[sf].Qty;
                    this.game.ProcessingObj.DoTransfer(unit, hq, 0, sf, qty, true, false);
                  }
                  this.AddLog("LandResPlannr: " + Conversion.Str((object) Number) + ", Disbanded unit " + this.game.Data.UnitObj[unit].Name);
                  if (this.game.Data.UnitObj[unit].IsHQ)
                  {
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
                  this.game.Data.RemoveUnit(unit, ref this.game);
                  num = 1;
                  break;
                }
              }
            }
          }
        }
      }
    }

    public void EmptyHQ()
    {
      if ((double) this.game.Data.RuleVar[253] > 0.0)
        return;
      for (int unitCounter1 = this.game.Data.UnitCounter; unitCounter1 >= 0; unitCounter1 += -1)
      {
        if (this.game.Data.UnitObj[unitCounter1].IsHQ & this.game.Data.UnitObj[unitCounter1].PreDef == -1 & this.game.Data.UnitObj[unitCounter1].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unitCounter1].X > -1)
        {
          int unr = unitCounter1;
          int x = this.game.Data.UnitObj[unitCounter1].X;
          int y = this.game.Data.UnitObj[unitCounter1].Y;
          int num1 = 0;
          while (num1 == 0)
          {
            num1 = 1;
            for (int sfCount = this.game.Data.UnitObj[unitCounter1].SFCount; sfCount >= 0; sfCount += -1)
            {
              int sf = this.game.Data.UnitObj[unitCounter1].SFList[sfCount];
              int type = this.game.Data.SFObj[sf].Type;
              if (this.game.Data.SFTypeObj[type].AIRoleScore[1] < 10)
              {
                int num2 = 0;
                if (this.game.Data.SFTypeObj[type].AIRoleScore[6] > 0)
                  num2 = 1;
                if (this.game.Data.SFTypeObj[type].AIRoleScore[7] > 0)
                  num2 = 1;
                if (this.game.Data.SFTypeObj[type].AIRoleScore[5] > 0)
                  num2 = 1;
                if (this.game.Data.SFTypeObj[type].AIRoleScore[10] > 0)
                  num2 = 1;
                if (this.game.Data.SFTypeObj[type].AIRoleScore[17] > 0)
                  num2 = 1;
                if (this.game.Data.SFTypeObj[type].AIRoleScore[13] > 0)
                  num2 = 1;
                if (this.game.Data.SFTypeObj[type].AIRoleScore[8] > 0)
                  num2 = 1;
                if (this.game.Data.SFTypeObj[type].AIRoleScore[18] > 0)
                  num2 = 1;
                if (this.game.Data.SFTypeObj[type].AIRoleScore[19] > 0)
                  num2 = 1;
                if (this.game.Data.SFTypeObj[type].AIRoleScore[14] > 0)
                  num2 = 1;
                if (this.game.Data.SFTypeObj[type].AIRoleScore[15] > 0)
                  num2 = 1;
                if (num2 == 1 & this.game.Data.MapObj[0].HexObj[x, y].UnitCounter < 15)
                {
                  RegimeClass[] regimeObj = this.game.Data.RegimeObj;
                  RegimeClass[] regimeClassArray = regimeObj;
                  int turn = this.game.Data.Turn;
                  int index = turn;
                  regimeClassArray[index].ResPts = (int) Math.Round((double) ((float) regimeObj[turn].ResPts + this.game.Data.RuleVar[46]));
                  this.game.ProcessingObj.NewUnit(x, y, 0, false, this.game.Data.Turn);
                  int Qty = this.game.Data.SFObj[sf].Qty;
                  int unitCounter2 = this.game.Data.UnitCounter;
                  if (Qty > 0)
                  {
                    int num3 = Qty * this.game.Data.SFTypeObj[type].Frontage;
                    if (num3 > 60)
                      Qty = (int) Math.Round(Math.Min(Conversion.Int((double) Qty / 2.0), Conversion.Int((double) Qty * (60.0 / (double) num3))));
                    if (Qty == 0)
                      Qty = 1;
                    this.game.Data.UnitObj[unitCounter2].HQ = unr;
                    this.game.ProcessingObj.DoTransfer(unr, unitCounter2, this.game.Data.SFTypeObj[type].Theater, sf, Qty, true);
                    num1 = 0;
                  }
                }
              }
            }
          }
        }
      }
    }

    public void ExecLandTransfers(int phase)
    {
      int[] numArray1 = new int[this.game.Data.UnitCounter + 1];
      int[] numArray2 = new int[this.game.Data.UnitCounter + 1];
      int[,] numArray3 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int tplanCount1 = this.TPlanCount;
      int num1;
      for (int index = 1; index <= tplanCount1; ++index)
      {
        if (this.TPlanObj[index].Type == 20)
          num1 = (int) Math.Round((double) ((float) num1 + this.TPlanObj[index].WeightEnemyForce));
      }
      if (num1 == 0)
        num1 = 1;
      int tplanCount2 = this.TPlanCount;
      for (int index1 = 1; index1 <= tplanCount2; ++index1)
      {
        if (this.TPlanObj[index1].Type == 30 | this.TPlanObj[index1].Type == 20 && this.TPlanObj[index1].HQ > -1)
        {
          this.AddLog("");
          this.AddLog("*TransferExec for " + this.game.Data.UnitObj[this.TPlanObj[index1].HQ].Name + " PHASE " + Conversion.Str((object) phase));
          int x = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].X;
          int y = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].Y;
          this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), x, y, 0);
          int mapWidth = this.game.Data.MapObj[0].MapWidth;
          for (int index2 = 0; index2 <= mapWidth; ++index2)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index3 = 0; index3 <= mapHeight; ++index3)
              numArray3[index2, index3] = this.game.EditObj.TempValue[0].Value[index2, index3];
          }
          numArray3[x, y] = 0;
          SimpleList simpleList1 = new SimpleList();
          int num2 = 0;
          int tplanCount3 = this.TPlanCount;
          int num3;
          for (int index4 = 1; index4 <= tplanCount3; ++index4)
          {
            if ((double) this.game.Data.RuleVar[253] == 0.0 | phase == 1 & (this.TPlanObj[index4].Type == 50 | this.TPlanObj[index4].Type == 20 | this.TPlanObj[index4].Type == 40) & this.SAObj[this.GetAreaNr(this.TPlanObj[index4].FromArea)].LandReservePlan == index1 | this.TPlanObj[index4].Type == 20 & phase == 2)
            {
              if ((double) numArray3[this.TPlanObj[index4].FromArea.X, this.TPlanObj[index4].FromArea.Y] < (double) this.game.Data.RuleVar[78] | phase == 2)
              {
                int num4 = 0;
                if (phase == 2)
                  num4 = 100;
                int num5 = 0;
                if (this.TPlanObj[index4].Type == 20)
                {
                  if ((double) this.TPlanObj[index4].WeightEnemyForce > (double) this.TPlanObj[index4].WeightFriendlyForce)
                  {
                    int num6 = (int) Math.Round(100.0 * ((double) this.TPlanObj[index4].WeightEnemyForce / ((double) this.TPlanObj[index4].WeightFriendlyForce + 1.0)));
                    num5 = (int) Math.Round(100.0 * ((double) this.TPlanObj[index4].WeightEnemyForce / ((double) this.TPlanObj[index4].WeightFriendlyForce + 1.0))) + this.TPlanObj[index1].WeightStrategic;
                    num3 = (int) Math.Round((double) ((float) (num6 * (this.TPlanObj[index4].WeightStrategic + 1)) * (this.TPlanObj[index4].WeightEnemyForce / (float) num1)));
                  }
                  else
                  {
                    num5 = (int) Math.Round(100.0 * ((double) this.TPlanObj[index4].WeightEnemyForce / ((double) this.TPlanObj[index4].WeightFriendlyForce + 1.0))) + this.TPlanObj[index1].WeightStrategic;
                    num3 = (int) Math.Round((double) ((float) ((int) Math.Round(100.0 * ((double) this.TPlanObj[index4].WeightEnemyForce / ((double) this.TPlanObj[index4].WeightFriendlyForce + 1.0))) * (this.TPlanObj[index4].WeightStrategic + 1)) * (this.TPlanObj[index4].WeightEnemyForce / (float) num1)));
                    if (num3 == 0)
                      num3 = 10 * (this.TPlanObj[index4].WeightStrategic + 1);
                  }
                }
                else if (this.TPlanObj[index4].Type == 40)
                {
                  if ((double) this.game.Data.RuleVar[252] > 0.0 & this.TPlanObj[index4].AssemblyArea == 1)
                  {
                    num3 = (int) Math.Round((double) ((float) (this.TPlanObj[index4].WeightStrategic * 25) * this.game.Data.RuleVar[254]));
                    int closestFrontline = this.GetClosestFrontline(this.TPlanObj[index4].FromArea.X, this.TPlanObj[index4].FromArea.Y);
                    if (closestFrontline > 0)
                    {
                      if (this.TPlanObj[closestFrontline].Stand == 2)
                        num3 *= 3;
                      if (this.TPlanObj[closestFrontline].Stand == 3)
                        num3 *= 6;
                    }
                  }
                  else
                    num3 = this.TPlanObj[index4].WeightStrategic * 10;
                  if (num3 == 0)
                    num3 = 1;
                  num5 = num3;
                }
                else if (this.TPlanObj[index4].Type == 50)
                {
                  num3 = 50 * (this.SAObj[this.GetAreaNr(this.TPlanObj[index4].FromArea)].fuzzyvp + this.SAObj[this.GetAreaNr(this.TPlanObj[index4].TooArea)].fuzzyvp);
                  num5 = num3;
                }
                if (num3 > 0)
                  num4 += num3;
                if (num4 > 0)
                {
                  this.AddLog("Plan #" + Conversion.Str((object) index4) + " importance=" + Conversion.Str((object) num5) + ", weight=" + Conversion.Str((object) num4));
                  simpleList1.Add(index4, num4, num5);
                  num2 += num4;
                }
              }
              else
                this.AddLog("Plan #" + Conversion.Str((object) index4) + " IS OUT OF RANGE");
            }
          }
          int num7 = 0;
          if (this.TPlanObj[index1].Type == 30 && phase == 1)
          {
            int tplanCount4 = this.TPlanCount;
            for (int index5 = 1; index5 <= tplanCount4; ++index5)
            {
              if (this.TPlanObj[index5].Type == 30 && index5 != index1 && this.TPlanObj[index1].WeightStrategic < this.TPlanObj[index5].WeightStrategic && this.TPlanObj[index5].MetaChainNr > this.TPlanObj[index1].MetaChainNr && (double) numArray3[this.TPlanObj[index5].FromArea.X, this.TPlanObj[index5].FromArea.Y] < (double) this.game.Data.RuleVar[78])
              {
                int num8 = this.TPlanObj[index5].WeightStrategic - this.TPlanObj[index1].WeightStrategic;
                int num9 = this.TPlanObj[index5].WeightStrategic - this.TPlanObj[index1].WeightStrategic;
                if (num9 > 0)
                {
                  simpleList1.Add(index5, num9, num8);
                  this.AddLog("Plan #" + Conversion.Str((object) index5) + " importance=" + Conversion.Str((object) num8) + ", weight=" + Conversion.Str((object) num9));
                  num2 += num9;
                  ++num7;
                }
              }
            }
          }
          this.AddLog("=>toUnits");
          if (simpleList1.Counter > -1)
          {
            SimpleList simpleList2 = new SimpleList();
            int num10 = 0;
            int counter1 = simpleList1.Counter;
            for (int index6 = 0; index6 <= counter1; ++index6)
            {
              int plnr = simpleList1.Id[index6];
              int num11;
              if (phase == 1)
                num11 = 9999;
              if (phase == 2)
                num11 = 1;
              if ((double) this.game.Data.RuleVar[253] == 0.0)
                num11 = 9999;
              int unitCounter1 = this.game.Data.UnitCounter;
              for (int unr = 0; unr <= unitCounter1; ++unr)
              {
                if (unr != this.TPlanObj[index1].HQ & this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].AIPlanNr == plnr | this.TPlanObj[plnr].HQ == unr && numArray3[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] < num11 & !this.game.Data.UnitObj[unr].AIDisband && this.game.Data.UnitObj[unr].AIUnitGoal != 5 && !(this.game.Data.UnitObj[unr].IsHQ & this.TPlanObj[index1].Type != 30))
                {
                  int num12;
                  if (this.TPlanObj[plnr].Type != 30)
                  {
                    int num13 = (int) Math.Round(100.0 * ((double) simpleList1.Weight[index6] / (double) num2));
                    num3 = this.game.HandyFunctionsObj.GetUnitStackPts(unr);
                    if (num3 < 1)
                      num3 = 1;
                    if (!this.game.Data.UnitObj[unr].IsHQ & (double) num3 > (double) this.game.Data.RuleVar[247])
                      num13 = (int) Math.Round((double) ((float) num13 * (this.game.Data.RuleVar[247] / (float) num3)));
                    if (this.game.Data.UnitObj[unr].IsHQ & this.game.HandyFunctionsObj.GetStaffPercent(unr) < 100)
                      num13 *= 3;
                    if (!this.game.Data.UnitObj[unr].IsHQ & (double) num3 < (double) this.game.Data.RuleVar[182])
                      num13 *= 3;
                    if (0 > num13)
                      num13 = 0;
                    num12 = num13 + 1;
                  }
                  else
                    num12 = 1;
                  num10 += num12;
                }
              }
              if (num10 > 0)
              {
                int unitCounter2 = this.game.Data.UnitCounter;
                for (int index7 = 0; index7 <= unitCounter2; ++index7)
                {
                  if (index7 != this.TPlanObj[index1].HQ & this.game.Data.UnitObj[index7].X > -1 & this.game.Data.UnitObj[index7].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index7].AIPlanNr == plnr | this.TPlanObj[plnr].HQ == index7 && numArray3[this.game.Data.UnitObj[index7].X, this.game.Data.UnitObj[index7].Y] < num11 & !this.game.Data.UnitObj[index7].AIDisband && !(this.game.Data.UnitObj[index7].IsHQ & this.TPlanObj[index1].Type != 30))
                  {
                    int num14;
                    if (this.TPlanObj[plnr].Type != 30)
                    {
                      int num15 = (int) Math.Round(100.0 * ((double) simpleList1.Weight[index6] / (double) num2));
                      num3 = this.game.HandyFunctionsObj.GetUnitStackPts(index7);
                      if (num3 < 1)
                        num3 = 1;
                      if (!this.game.Data.UnitObj[index7].IsHQ & (double) num3 > (double) this.game.Data.RuleVar[247])
                        num15 = (int) Math.Round((double) ((float) num15 * (this.game.Data.RuleVar[247] / (float) num3)));
                      if (this.game.Data.UnitObj[index7].IsHQ & this.game.HandyFunctionsObj.GetStaffPercent(index7) < 100)
                        num15 *= 3;
                      if (!this.game.Data.UnitObj[index7].IsHQ & (double) num3 < (double) this.game.Data.RuleVar[182])
                        num15 *= 3;
                      if (0 > num15)
                        num15 = 0;
                      num14 = num15 + 1;
                    }
                    else
                      num14 = 1;
                    int num16 = num14;
                    if (this.game.Data.UnitObj[index7].AIUnitGoal == 4)
                      num16 *= this.PlanEngineerNeedScore(plnr);
                    if (this.game.Data.UnitObj[index7].AIUnitGoal != 5)
                    {
                      simpleList2.Add(index7, num16);
                      this.AddLog(this.game.Data.UnitObj[index7].Name + " => gets weight= " + Conversion.Str((object) num16));
                    }
                  }
                }
              }
            }
            int num17 = (int) Math.Round((double) num10 / 2.0);
            if (phase == 1)
              this.TPlanObj[index1].LandTransferMobility = 0;
            int landCap = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].LandCap;
            int num18 = 0;
            if (simpleList2.Counter > -1)
            {
              int powerPtsAbsolute = this.game.HandyFunctionsObj.GetPowerPtsAbsolute(this.TPlanObj[index1].HQ);
              int Number1 = 1;
              int num19;
              do
              {
                int Number2 = 0;
                int Number3 = 0;
                num3 = 0;
                int num20 = 0;
                int num21 = 0;
                int num22 = 0;
                num19 = 0;
                if (Number1 == 1)
                {
                  Number2 = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].LandCap;
                  Number3 = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].NavyCap;
                }
                if ((double) this.game.Data.RuleVar[253] == 0.0)
                {
                  this.game.Data.UnitObj[this.TPlanObj[index1].HQ].LandCap = 99999;
                  Number2 = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].LandCap;
                }
                this.AddLog("ROLECYCLE=" + Conversion.Str((object) Number1) + " , capleftland=" + Conversion.Str((object) Number2) + ", capleftnavy=" + Conversion.Str((object) Number3));
                for (; num20 == 0 & num21 < 4999 && (double) this.game.HandyFunctionsObj.GetPowerPtsAbsolute(this.TPlanObj[index1].HQ) >= (double) powerPtsAbsolute * 0.9; ++num21)
                {
                  for (int counter2 = simpleList2.Counter; counter2 >= 0; counter2 += -1)
                  {
                    if ((double) VBMath.Rnd() * (double) num17 < (double) simpleList2.Weight[counter2] && this.game.Data.UnitObj[simpleList2.Id[counter2]].AIUnitGoal != 5)
                    {
                      RoleSFResult roleSfResult = this.LandTransferWhatWantsUnit(simpleList2.Id[counter2], 1, this.TPlanObj[index1].HQ, onlyrole: true);
                      int rolenr = roleSfResult.rolenr;
                      if (rolenr > -1)
                      {
                        int SfNr = this.LandTransferGetSF(this.TPlanObj[index1].HQ, rolenr, roleSfResult.sftypenr);
                        if (rolenr == 9 & phase == 2)
                          SfNr = -1;
                        if (phase == 1 && rolenr == 9 & SfNr > -1 && this.game.Data.SFTypeObj[this.game.Data.SFObj[SfNr].Type].AIRoleScore[2] > 0 && (double) num18 >= (double) landCap * 0.33)
                          SfNr = -1;
                        if (SfNr == -1)
                        {
                          roleSfResult = this.LandTransferWhatWantsUnit(simpleList2.Id[counter2], 2, this.TPlanObj[index1].HQ, onlyrole: true);
                          rolenr = roleSfResult.rolenr;
                          if (rolenr > -1)
                            SfNr = this.LandTransferGetSF(this.TPlanObj[index1].HQ, rolenr, roleSfResult.sftypenr);
                          if (rolenr == 9 & phase == 2)
                            SfNr = -1;
                        }
                        if (phase == 1 && rolenr == 9 & SfNr > -1 && this.game.Data.SFTypeObj[this.game.Data.SFObj[SfNr].Type].AIRoleScore[2] > 0 && (double) num18 >= (double) landCap * 0.33)
                          SfNr = -1;
                        if (SfNr > -1)
                        {
                          int type = this.game.Data.SFObj[SfNr].Type;
                          int num23 = this.game.Data.SFTypeObj[type].Weight * numArray3[this.game.Data.UnitObj[simpleList2.Id[counter2]].X, this.game.Data.UnitObj[simpleList2.Id[counter2]].Y];
                          if ((double) this.game.Data.RuleVar[253] == 0.0)
                            num23 = 0;
                          int num24 = this.game.Data.SFTypeObj[type].Theater != 0 ? 0 : this.game.Data.SFTypeObj[type].Cap;
                          int num25 = this.game.Data.SFTypeObj[type].Theater != 1 ? 0 : this.game.Data.SFTypeObj[type].Cap;
                          if ((double) this.game.Data.RuleVar[253] == 0.0 | phase == 2 | Number2 - num24 >= 0 & Number3 - num25 >= 0)
                          {
                            if (!this.game.Data.UnitObj[simpleList2.Id[counter2]].IsHQ && this.game.HandyFunctionsObj.GetUnitSFNr(simpleList2.Id[counter2], type, this.game.Data.SFObj[SfNr].People) == -1 && this.game.Data.UnitObj[simpleList2.Id[counter2]].SFCount > 6)
                              num23 = 9999;
                            if (!this.game.Data.UnitObj[simpleList2.Id[counter2]].IsHQ && this.game.Data.SFTypeObj[type].Theater == 0 & this.game.HandyFunctionsObj.HasUnitNavySF(simpleList2.Id[counter2]))
                              num23 = 99999;
                            if (num23 < 99999)
                            {
                              if (num23 <= this.game.Data.UnitObj[this.TPlanObj[index1].HQ].LandCap | phase == 2)
                              {
                                int num26 = 1;
                                this.game.ProcessingObj.DoTransfer(this.TPlanObj[index1].HQ, simpleList2.Id[counter2], 0, SfNr, num26, AddtoHistory: false);
                                this.AddLog("Transfered " + Conversion.Str((object) num26) + "x " + this.game.Data.SFTypeObj[type].Name + " to " + this.game.Data.UnitObj[simpleList2.Id[counter2]].Name);
                                Number2 -= num24;
                                Number3 -= num25;
                                if ((double) this.game.Data.RuleVar[253] == 0.0)
                                {
                                  Number2 = 99999;
                                  this.game.Data.UnitObj[this.TPlanObj[index1].HQ].LandCap = 99999;
                                }
                                if (phase == 1 && rolenr == 9 & SfNr > -1)
                                  num18 += this.game.Data.SFTypeObj[type].Cap * num26;
                                num3 = 1;
                              }
                              else
                                num19 = 1;
                            }
                          }
                        }
                        else
                        {
                          num17 -= simpleList2.Weight[counter2];
                          simpleList2.Remove(simpleList2.Id[counter2]);
                          if (0 > num17)
                            num17 = 0;
                        }
                      }
                    }
                  }
                  if (num3 == 0)
                  {
                    ++num22;
                  }
                  else
                  {
                    num22 = 0;
                    num3 = 0;
                  }
                  if (num22 > (simpleList2.Counter + 1) * 10)
                    num20 = 1;
                }
                Application.DoEvents();
                ++Number1;
              }
              while (Number1 <= 1);
              if (phase == 1 & Number1 == 1)
                this.TPlanObj[index1].LandTransferMobility = num19;
            }
          }
        }
      }
    }

    public void ExecAirTransfers(int phase)
    {
      int tplanCount1 = this.TPlanCount;
      int num1;
      for (int index = 1; index <= tplanCount1; ++index)
      {
        if (this.TPlanObj[index].Type == 20)
          num1 = (int) Math.Round((double) ((float) num1 + this.TPlanObj[index].WeightEnemyForce));
      }
      if (num1 == 0)
        num1 = 1;
      int tplanCount2 = this.TPlanCount;
      for (int index1 = 1; index1 <= tplanCount2; ++index1)
      {
        if (this.TPlanObj[index1].Type == 30 && this.TPlanObj[index1].HQ > -1)
        {
          this.AddLog("");
          this.AddLog("*AIRTransferExec for " + this.game.Data.UnitObj[this.TPlanObj[index1].HQ].Name + " PHASE " + Conversion.Str((object) phase));
          int x = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].X;
          int y = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].Y;
          int increaseap = this.game.HandyFunctionsObj.GetLowestAirAp(this.TPlanObj[index1].HQ);
          if (increaseap < 100)
            increaseap = 100 - increaseap;
          if (0 > increaseap)
            increaseap = 0;
          if (increaseap > 100)
            increaseap = 100;
          this.game.HandyFunctionsObj.MakeMovePrediction(this.TPlanObj[index1].HQ, x, y, 0, false, PredictAirOnly: true, increaseap: increaseap, IsTransfer: true);
          SimpleList simpleList1 = new SimpleList();
          int num2 = 0;
          int tplanCount3 = this.TPlanCount;
          int num3;
          for (int index2 = 1; index2 <= tplanCount3; ++index2)
          {
            if (phase == 1 & (this.TPlanObj[index2].Type == 20 | this.TPlanObj[index2].Type == 40) | this.TPlanObj[index2].Type == 20 & phase == 2)
            {
              if ((double) this.game.EditObj.TempValue[0].Value[this.TPlanObj[index2].FromArea.X, this.TPlanObj[index2].FromArea.Y] < (double) this.game.Data.RuleVar[78] | phase == 2)
              {
                int num4 = 0;
                int num5 = 0;
                if (this.TPlanObj[index2].Type == 20)
                {
                  if ((double) this.TPlanObj[index2].WeightEnemyForce > (double) this.TPlanObj[index2].WeightFriendlyForce)
                  {
                    int num6 = (int) Math.Round(100.0 * ((double) this.TPlanObj[index2].WeightEnemyForce / ((double) this.TPlanObj[index2].WeightFriendlyForce + 1.0)));
                    num5 = (int) Math.Round(100.0 * ((double) this.TPlanObj[index2].WeightEnemyForce / ((double) this.TPlanObj[index2].WeightFriendlyForce + 1.0))) + this.TPlanObj[index1].WeightStrategic;
                    num3 = (int) Math.Round((double) ((float) (num6 * (this.TPlanObj[index2].WeightStrategic + 1)) * (this.TPlanObj[index2].WeightEnemyForce / (float) num1)));
                  }
                  else
                  {
                    num5 = (int) Math.Round(100.0 * ((double) this.TPlanObj[index2].WeightEnemyForce / ((double) this.TPlanObj[index2].WeightFriendlyForce + 1.0))) + this.TPlanObj[index1].WeightStrategic;
                    num3 = (int) Math.Round((double) ((float) ((int) Math.Round(100.0 * ((double) this.TPlanObj[index2].WeightEnemyForce / ((double) this.TPlanObj[index2].WeightFriendlyForce + 1.0))) * (this.TPlanObj[index2].WeightStrategic + 1)) * (this.TPlanObj[index2].WeightEnemyForce / (float) num1)));
                    if (num3 == 0)
                      num3 = 10 * (this.TPlanObj[index2].WeightStrategic + 1);
                  }
                }
                else if (this.TPlanObj[index2].Type == 40)
                {
                  num3 = this.TPlanObj[index2].WeightStrategic * 5;
                  if (num3 == 0)
                    num3 = 1;
                  num5 = num3;
                }
                if (num3 > 0)
                  num4 += num3;
                if (num4 > 0)
                {
                  this.AddLog("Plan #" + Conversion.Str((object) index2) + " importance=" + Conversion.Str((object) num5) + ", weight=" + Conversion.Str((object) num4));
                  simpleList1.Add(index2, num4, num5);
                  num2 += num4;
                }
              }
              else
                this.AddLog("Plan #" + Conversion.Str((object) index2) + " IS OUT OF RANGE");
            }
          }
          int num7 = 0;
          if (phase == 1)
          {
            int tplanCount4 = this.TPlanCount;
            for (int index3 = 1; index3 <= tplanCount4; ++index3)
            {
              if (this.TPlanObj[index3].Type == 30 && index3 != index1 && this.TPlanObj[index1].WeightStrategic < this.TPlanObj[index3].WeightStrategic && (double) this.game.EditObj.TempValue[0].Value[this.TPlanObj[index3].FromArea.X, this.TPlanObj[index3].FromArea.Y] < (double) this.game.Data.RuleVar[78])
              {
                int num8 = this.TPlanObj[index3].WeightStrategic - this.TPlanObj[index1].WeightStrategic;
                int num9 = this.TPlanObj[index3].WeightStrategic - this.TPlanObj[index1].WeightStrategic;
                if (num9 > 0)
                {
                  simpleList1.Add(index3, num9, num8);
                  this.AddLog("Plan #" + Conversion.Str((object) index3) + " importance=" + Conversion.Str((object) num8) + ", weight=" + Conversion.Str((object) num9));
                  num2 += num9;
                  ++num7;
                  num3 = 1;
                }
              }
            }
          }
          this.AddLog("=>toUnits");
          if (simpleList1.Counter > -1)
          {
            SimpleList simpleList2 = new SimpleList();
            int counter1 = simpleList1.Counter;
            int num10;
            for (int index4 = 0; index4 <= counter1; ++index4)
            {
              int plnr = simpleList1.Id[index4];
              num10 = 0;
              int num11;
              if (phase == 1)
                num11 = 9999;
              if (phase == 2)
                num11 = 1;
              int unitCounter1 = this.game.Data.UnitCounter;
              for (int unr = 0; unr <= unitCounter1; ++unr)
              {
                if (unr != this.TPlanObj[index1].HQ & this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].AIPlanNr == plnr | this.TPlanObj[plnr].HQ == unr | phase == 2 && this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] < num11 && this.game.Data.UnitObj[unr].AIUnitGoal == 5 && (double) this.game.HandyFunctionsObj.GetAirFieldStackModifier(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y) >= 1.0)
                {
                  int num12;
                  if (this.TPlanObj[plnr].Type != 30)
                  {
                    num12 = (int) Math.Round((double) (this.game.Data.RuleVar[31] - (float) this.game.HandyFunctionsObj.GetUnitStackPts(unr)));
                    if (this.game.HandyFunctionsObj.GetUnitStackPts(unr) < 10)
                      num12 = (int) Math.Round((double) num12 * (1.0 + (double) (10 - this.game.HandyFunctionsObj.GetUnitStackPts(unr)) / 5.0));
                    if (0 > num12)
                      num12 = 0;
                  }
                  else
                    num12 = 1;
                  num10 += num12;
                }
              }
              if (num10 > 0)
              {
                int unitCounter2 = this.game.Data.UnitCounter;
                for (int index5 = 0; index5 <= unitCounter2; ++index5)
                {
                  if (index5 != this.TPlanObj[index1].HQ & this.game.Data.UnitObj[index5].X > -1 & this.game.Data.UnitObj[index5].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index5].AIPlanNr == plnr | this.TPlanObj[plnr].HQ == index5 | phase == 2 && this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[index5].X, this.game.Data.UnitObj[index5].Y] < num11)
                  {
                    int num13;
                    if (this.TPlanObj[plnr].Type != 30)
                    {
                      num13 = (int) Math.Round((double) (this.game.Data.RuleVar[31] - (float) this.game.HandyFunctionsObj.GetUnitStackPts(index5)));
                      if (this.game.HandyFunctionsObj.GetUnitStackPts(index5) < 10)
                        num13 = (int) Math.Round((double) num13 * (1.0 + (double) (10 - this.game.HandyFunctionsObj.GetUnitStackPts(index5)) / 5.0));
                      if (0 > num13)
                        num13 = 0;
                    }
                    else
                      num13 = 1;
                    int num14 = (int) Math.Round(Conversion.Int((double) num13 * ((double) simpleList1.Data1[index4] / (double) num10)));
                    if (this.game.Data.UnitObj[index5].AIUnitGoal == 4)
                      num14 *= this.PlanEngineerNeedScore(plnr);
                    if (this.game.Data.UnitObj[index5].AIUnitGoal == 5 && (double) this.game.HandyFunctionsObj.GetAirFieldStackModifier(this.game.Data.UnitObj[index5].X, this.game.Data.UnitObj[index5].Y) >= 1.0)
                    {
                      simpleList2.Add(index5, num14);
                      this.AddLog(this.game.Data.UnitObj[index5].Name + " => gets weight= " + Conversion.Str((object) num14));
                    }
                  }
                }
              }
            }
            int num15 = 0;
            num3 = 0;
            int num16 = 0;
            int num17 = 0;
            if (phase == 1)
              this.TPlanObj[index1].LandTransferMobility = 0;
            if (simpleList2.Counter > -1)
            {
              for (; num16 == 0 & num7 < 1999; ++num7)
              {
                int counter2 = simpleList2.Counter;
                for (int index6 = 0; index6 <= counter2; ++index6)
                {
                  if (this.game.Data.UnitObj[simpleList2.Id[index6]].AIUnitGoal == 5 && (double) VBMath.Rnd() * (double) num10 < (double) simpleList2.Weight[index6])
                  {
                    RoleSFResult roleSfResult = this.LandTransferWhatWantsUnit(simpleList2.Id[index6], 1, this.TPlanObj[index1].HQ, onlyrole: true);
                    int rolenr1 = roleSfResult.rolenr;
                    if (rolenr1 > -1 & (rolenr1 == 13 | rolenr1 == 14))
                    {
                      int sf = this.LandTransferGetSF(this.TPlanObj[index1].HQ, rolenr1, roleSfResult.sftypenr);
                      if (sf == -1)
                      {
                        roleSfResult = this.LandTransferWhatWantsUnit(simpleList2.Id[index6], 2, this.TPlanObj[index1].HQ, onlyrole: true);
                        int rolenr2 = roleSfResult.rolenr;
                        sf = this.LandTransferGetSF(this.TPlanObj[index1].HQ, rolenr2, roleSfResult.sftypenr);
                      }
                      if (sf > -1)
                      {
                        int type = this.game.Data.SFObj[sf].Type;
                        int num18 = this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[simpleList2.Id[index6]].X, this.game.Data.UnitObj[simpleList2.Id[index6]].Y];
                        if (!this.game.Data.UnitObj[simpleList2.Id[index6]].IsHQ && this.game.HandyFunctionsObj.GetUnitSFNr(simpleList2.Id[index6], type, this.game.Data.SFObj[sf].People) == -1 && this.game.Data.UnitObj[simpleList2.Id[index6]].SFCount > 6)
                          num18 = 9999;
                        if (num18 < 9999)
                        {
                          this.game.ProcessingObj.DoTransfer(this.TPlanObj[index1].HQ, simpleList2.Id[index6], 2, sf, 1, true, false);
                          this.AddLog("Transfered 1x " + this.game.Data.SFTypeObj[type].Name + " to " + this.game.Data.UnitObj[simpleList2.Id[index6]].Name);
                          num3 = 1;
                        }
                        else
                          num17 = 1;
                      }
                    }
                  }
                }
                if (num3 == 0)
                {
                  ++num15;
                }
                else
                {
                  num15 = 0;
                  num3 = 0;
                }
                if (num15 > 20)
                  num16 = 1;
              }
              if (phase == 1)
                this.TPlanObj[index1].LandTransferMobility = num17;
            }
          }
        }
      }
    }

    public void ExecNavyTransfers(int phase)
    {
      int tplanCount1 = this.TPlanCount;
      int num1;
      for (int index = 1; index <= tplanCount1; ++index)
      {
        if (this.TPlanObj[index].Type == 20)
          num1 = (int) Math.Round((double) ((float) num1 + this.TPlanObj[index].WeightEnemyForce));
      }
      if (num1 == 0)
        ;
      int tplanCount2 = this.TPlanCount;
      for (int index1 = 1; index1 <= tplanCount2; ++index1)
      {
        if (this.TPlanObj[index1].Type == 30 && this.TPlanObj[index1].HQ > -1)
        {
          this.AddLog("");
          this.AddLog("*NavyTransferExec for " + this.game.Data.UnitObj[this.TPlanObj[index1].HQ].Name + " PHASE " + Conversion.Str((object) phase));
          int x = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].X;
          int y = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].Y;
          this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[1]), 1, (int) Math.Round((double) this.game.Data.RuleVar[78]), x, y, 0, false, istransfer: true);
          SimpleList simpleList1 = new SimpleList();
          int num2 = 0;
          int num3 = 0;
          if (phase == 1)
          {
            int tplanCount3 = this.TPlanCount;
            for (int index2 = 1; index2 <= tplanCount3; ++index2)
            {
              if (this.TPlanObj[index2].Type == 30 && index2 != index1 && this.TPlanObj[index1].WeightStrategic < this.TPlanObj[index2].WeightStrategic && (double) this.game.EditObj.TempValue[0].Value[this.TPlanObj[index2].FromArea.X, this.TPlanObj[index2].FromArea.Y] < (double) this.game.Data.RuleVar[78])
              {
                int num4 = this.TPlanObj[index2].WeightStrategic - this.TPlanObj[index1].WeightStrategic;
                int num5 = this.TPlanObj[index2].WeightStrategic - this.TPlanObj[index1].WeightStrategic;
                if (num5 > 0)
                {
                  simpleList1.Add(index2, num5, num4);
                  this.AddLog("Plan #" + Conversion.Str((object) index2) + " importance=" + Conversion.Str((object) num4) + ", weight=" + Conversion.Str((object) num5));
                  num2 += num5;
                  ++num3;
                }
              }
            }
          }
          this.AddLog("=>toUnits");
          if (simpleList1.Counter > -1)
          {
            SimpleList simpleList2 = new SimpleList();
            int counter1 = simpleList1.Counter;
            int num6;
            for (int index3 = 0; index3 <= counter1; ++index3)
            {
              int index4 = simpleList1.Id[index3];
              num6 = 0;
              int num7;
              if (phase == 1)
                num7 = 9999;
              if (phase == 2)
                num7 = 1;
              int unitCounter1 = this.game.Data.UnitCounter;
              for (int unr = 0; unr <= unitCounter1; ++unr)
              {
                if (unr != this.TPlanObj[index1].HQ & this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].AIPlanNr == index4 | this.TPlanObj[index4].HQ == unr | phase == 2 && this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] < num7)
                {
                  int num8;
                  if (this.TPlanObj[index4].Type != 30)
                  {
                    num8 = (int) Math.Round((double) (this.game.Data.RuleVar[31] - (float) this.game.HandyFunctionsObj.GetUnitStackPts(unr)));
                    if (this.game.HandyFunctionsObj.GetUnitStackPts(unr) < 10)
                      num8 = (int) Math.Round((double) num8 * (1.0 + (double) (10 - this.game.HandyFunctionsObj.GetUnitStackPts(unr)) / 5.0));
                    if (0 > num8)
                      num8 = 0;
                  }
                  else
                    num8 = 1;
                  num6 += num8;
                }
              }
              if (num6 > 0)
              {
                int unitCounter2 = this.game.Data.UnitCounter;
                for (int index5 = 0; index5 <= unitCounter2; ++index5)
                {
                  if (index5 != this.TPlanObj[index1].HQ & this.game.Data.UnitObj[index5].X > -1 & this.game.Data.UnitObj[index5].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index5].AIPlanNr == index4 | this.TPlanObj[index4].HQ == index5 | phase == 2 && this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[index5].X, this.game.Data.UnitObj[index5].Y] < num7)
                  {
                    int num9;
                    if (this.TPlanObj[index4].Type != 30)
                    {
                      num9 = (int) Math.Round((double) (this.game.Data.RuleVar[31] - (float) this.game.HandyFunctionsObj.GetUnitStackPts(index5)));
                      if (this.game.HandyFunctionsObj.GetUnitStackPts(index5) < 10)
                        num9 = (int) Math.Round((double) num9 * (1.0 + (double) (10 - this.game.HandyFunctionsObj.GetUnitStackPts(index5)) / 5.0));
                      if (0 > num9)
                        num9 = 0;
                    }
                    else
                      num9 = 1;
                    int num10 = (int) Math.Round(Conversion.Int((double) num9 * ((double) simpleList1.Data1[index3] / (double) num6)));
                    simpleList2.Add(index5, num10);
                    this.AddLog(this.game.Data.UnitObj[index5].Name + " => gets weight= " + Conversion.Str((object) num10));
                  }
                }
              }
            }
            int num11 = 0;
            int num12 = 0;
            int num13 = 0;
            int num14 = 0;
            if (phase == 1)
              this.TPlanObj[index1].SeaTransferMobility = 0;
            int num15 = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].NavyCap;
            int landCap = this.game.Data.UnitObj[this.TPlanObj[index1].HQ].LandCap;
            int num16 = 0;
            int num17 = 0;
            if (simpleList2.Counter > -1)
            {
              for (; num13 == 0 & num3 < 1999; ++num3)
              {
                int counter2 = simpleList2.Counter;
                for (int index6 = 0; index6 <= counter2; ++index6)
                {
                  if ((double) VBMath.Rnd() * (double) num6 < (double) simpleList2.Weight[index6])
                  {
                    RoleSFResult roleSfResult = this.LandTransferWhatWantsUnit(simpleList2.Id[index6], 1, this.TPlanObj[index1].HQ, onlyrole: true);
                    int rolenr1 = roleSfResult.rolenr;
                    if (rolenr1 > -1)
                    {
                      int sf = this.LandTransferGetSF(this.TPlanObj[index1].HQ, rolenr1, roleSfResult.sftypenr);
                      if (sf == -1)
                      {
                        roleSfResult = this.LandTransferWhatWantsUnit(simpleList2.Id[index6], 2, this.TPlanObj[index1].HQ, onlyrole: true);
                        int rolenr2 = roleSfResult.rolenr;
                        sf = this.LandTransferGetSF(this.TPlanObj[index1].HQ, rolenr2, roleSfResult.sftypenr);
                      }
                      if (sf > -1)
                      {
                        int type = this.game.Data.SFObj[sf].Type;
                        int num18 = this.game.Data.SFTypeObj[type].Weight * this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[simpleList2.Id[index6]].X, this.game.Data.UnitObj[simpleList2.Id[index6]].Y];
                        if (!this.game.Data.UnitObj[simpleList2.Id[index6]].IsHQ && this.game.HandyFunctionsObj.GetUnitSFNr(simpleList2.Id[index6], type, this.game.Data.SFObj[sf].People) == -1 && this.game.Data.UnitObj[simpleList2.Id[index6]].SFCount > 6)
                          num18 = 9999;
                        if (this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[simpleList2.Id[index6]].X, this.game.Data.UnitObj[simpleList2.Id[index6]].Y] < 9999 && this.game.HandyFunctionsObj.IsHexPort(this.game.Data.UnitObj[this.TPlanObj[index1].HQ].X, this.game.Data.UnitObj[this.TPlanObj[index1].HQ].Y, 0) && this.game.HandyFunctionsObj.IsHexPort(this.game.Data.UnitObj[simpleList2.Id[index6]].X, this.game.Data.UnitObj[simpleList2.Id[index6]].Y, 0) && this.game.Data.SFTypeObj[type].Theater == 1)
                          num18 = 0;
                        if (this.game.Data.SFTypeObj[type].AIRoleScore[3] > 0 && this.game.Data.UnitObj[this.TPlanObj[index1].HQ].NavyCap > this.game.Data.SFTypeObj[type].Cap)
                        {
                          int num19 = (int) Math.Round((double) (num15 - (num15 - this.game.Data.UnitObj[this.TPlanObj[index1].HQ].NavyCap)) / 2.0);
                          if (num19 > 0)
                          {
                            if (num16 + this.game.Data.SFTypeObj[type].Cap > num19)
                              num18 = 99999;
                            else
                              num16 += this.game.Data.SFTypeObj[type].Cap;
                          }
                        }
                        if (this.game.Data.SFTypeObj[type].AIRoleScore[17] > 0 && this.game.Data.SFObj[sf].Qty < 2)
                          num18 = 999999;
                        if (this.game.Data.SFTypeObj[type].AIRoleScore[2] > 0 && this.game.Data.UnitObj[this.TPlanObj[index1].HQ].LandCap > this.game.Data.SFTypeObj[type].Cap)
                        {
                          int num20 = (int) Math.Round((double) (landCap - (landCap - this.game.Data.UnitObj[this.TPlanObj[index1].HQ].LandCap)) / 2.0);
                          if (num20 > 0)
                          {
                            if (num17 + this.game.Data.SFTypeObj[type].Cap > num20)
                              num18 = 99999;
                            else
                              num17 += this.game.Data.SFTypeObj[type].Cap;
                          }
                        }
                        if (num18 < 9999)
                        {
                          if (num18 <= this.game.Data.UnitObj[this.TPlanObj[index1].HQ].NavyCap | (double) this.game.Data.RuleVar[253] == 0.0)
                          {
                            this.game.ProcessingObj.DoTransfer(this.TPlanObj[index1].HQ, simpleList2.Id[index6], 1, sf, 1, AddtoHistory: false);
                            this.AddLog("Transfered 1x " + this.game.Data.SFTypeObj[type].Name + " to " + this.game.Data.UnitObj[simpleList2.Id[index6]].Name);
                            if ((double) this.game.Data.RuleVar[253] == 0.0)
                            {
                              num15 = 99999;
                              this.game.Data.UnitObj[this.TPlanObj[index1].HQ].NavyCap = 99999;
                            }
                            num12 = 1;
                          }
                          else
                            num14 = 1;
                        }
                      }
                    }
                  }
                }
                if (num12 == 0)
                {
                  ++num11;
                }
                else
                {
                  num11 = 0;
                  num12 = 0;
                }
                if (num11 > 20)
                  num13 = 1;
              }
              if (phase == 1)
                this.TPlanObj[index1].SeaTransferMobility = num14;
            }
          }
        }
      }
    }

    public RoleSFResult LandTransferWhatWantsUnit(
      int unr,
      int info,
      int hq = -1,
      int prodpts = -1,
      bool onlyrole = false)
    {
      RoleSFResult roleSfResult = new RoleSFResult();
      int role = -1;
      if (this.TPlanObj[this.game.Data.UnitObj[unr].AIPlanNr].Type == 30)
      {
        if (hq > -1)
        {
          if (this.LandTransferGetSF(hq, 6) > -1)
            role = 6;
          else if (this.LandTransferGetSF(hq, 10) > -1)
            role = 10;
          else if (this.LandTransferGetSF(hq, 8) > -1)
            role = 8;
          else if (this.LandTransferGetSF(hq, 7) > -1)
            role = 7;
          else if (this.LandTransferGetSF(hq, 5) > -1)
            role = 5;
          else if (this.LandTransferGetSF(hq, 1) > -1)
            role = 1;
          else if (this.LandTransferGetSF(hq, 18) > -1)
            role = 18;
          else if (this.LandTransferGetSF(hq, 19) > -1)
            role = 19;
          else if (this.LandTransferGetSF(hq, 17) > -1)
            role = 17;
          else if (this.LandTransferGetSF(hq, 9) > -1)
            role = 9;
          else if (this.LandTransferGetSF(hq, 2) > -1)
            role = 2;
        }
        else
        {
          if (info == 1)
            role = 6;
          if (info == 2)
            role = 10;
        }
        roleSfResult.rolenr = role;
        roleSfResult.sftypenr = -1;
        return roleSfResult;
      }
      if (this.TPlanObj[this.game.Data.UnitObj[unr].AIPlanNr].Type == 20 | this.TPlanObj[this.game.Data.UnitObj[unr].AIPlanNr].Type == 50 | this.TPlanObj[this.game.Data.UnitObj[unr].AIPlanNr].Type == 40)
      {
        if (this.game.Data.UnitObj[unr].AIUnitGoal == 4)
        {
          if (info == 1)
            role = (double) this.game.Data.RuleVar[214] != 1.0 ? 5 : (!Operators.ConditionalCompareObjectGreaterEqual(this.GetEPPerTurn(unr), (object) this.game.Data.RuleVar[215], false) ? 5 : (!Operators.ConditionalCompareObjectLess((object) this.game.HandyFunctionsObj.GetUnitCarryCap(unr, 0), this.game.HandyFunctionsObj.GetUnitWeightWithoutLandCarryCap(unr), false) ? -1 : 9));
          if (info == 2)
            role = 5;
        }
        if (this.game.Data.UnitObj[unr].AIUnitGoal == 1)
        {
          if (Conversions.ToBoolean(Operators.AndObject((object) this.game.Data.UnitObj[unr].AIMobilize, Operators.CompareObjectLessEqual((object) this.game.HandyFunctionsObj.GetUnitCarryCap(unr, 0), this.game.HandyFunctionsObj.GetUnitWeightWithoutLandCarryCap(unr), false))))
          {
            if ((double) this.game.HandyFunctionsObj.GetUnitStackPts(unr) > (double) this.game.Data.RuleVar[247])
            {
              if (info == 1)
                role = 9;
              if ((double) this.game.HandyFunctionsObj.GetUnitStackPts(unr) < (double) this.game.Data.RuleVar[182])
              {
                if (info == 2)
                  role = 6;
              }
              else if (info == 2)
                role = -1;
            }
            else
            {
              if (info == 1)
                role = 6;
              if (info == 2)
                role = 7;
            }
            if ((double) this.game.Data.Round > (double) this.game.Data.RuleVar[259] & (double) this.game.Data.RuleVar[258] < (double) this.GetFriendlyAirRatio() & (double) this.GetFriendlyAirRatio() < 1.0 & (double) this.game.Data.RuleVar[258] > 0.0)
            {
              if (this.GetRolePercent(unr, 12) < 10)
              {
                if (info == 1)
                  role = 12;
                if (info == 2)
                  role = 6;
              }
            }
            else if ((double) this.game.Data.Round > (double) this.game.Data.RuleVar[259] & (double) this.GetFriendlyAirRatio() < (double) this.game.Data.RuleVar[258] && this.GetRolePercent(unr, 12) < 25)
            {
              if (info == 1)
                role = 12;
              if (info == 2)
                role = 6;
            }
          }
          else if (Conversions.ToBoolean(Operators.AndObject((object) (!this.game.Data.UnitObj[unr].AIMobilize & !this.game.Data.UnitObj[unr].AIReserve), Operators.CompareObjectLess((object) this.game.HandyFunctionsObj.GetUnitCarryCap(unr, 0), this.game.HandyFunctionsObj.GetUnitSpecialAIWeightWithoutLandCarryCap(unr), false))))
          {
            if ((double) this.game.HandyFunctionsObj.GetUnitStackPts(unr) > (double) this.game.Data.RuleVar[247])
            {
              if (info == 1)
                role = 9;
              if (info == 2)
                role = 6;
            }
            else
            {
              if (info == 1)
                role = 6;
              if (info == 2)
                role = 7;
            }
          }
          else if ((double) this.GetRolePercent(unr, 6) < (double) this.game.Data.RuleVar[156])
          {
            if (info == 1)
              role = 6;
            if ((double) this.game.HandyFunctionsObj.GetUnitStackPts(unr) < (double) this.game.Data.RuleVar[182])
            {
              if (info == 2)
                role = 6;
            }
            else if (info == 2)
              role = 7;
          }
          else
          {
            if ((double) this.game.HandyFunctionsObj.GetUnitStackPts(unr) < (double) this.game.Data.RuleVar[182])
            {
              if (info == 1)
                role = 6;
            }
            else if (info == 1)
              role = 7;
            if (info == 2)
              role = 6;
          }
          if (this.TPlanObj[this.game.Data.UnitObj[unr].AIPlanNr].Type == 40 && this.game.Data.UnitObj[unr].AIReserve)
          {
            if (this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unr, true) > this.GetAbsolutePowerForReserveUnit(this.game.Data.UnitObj[unr].AIPlanNr))
              role = -1;
            if ((double) this.game.Data.Round > (double) this.game.Data.RuleVar[259] & (double) this.game.Data.RuleVar[258] < (double) this.GetFriendlyAirRatio() & (double) this.GetFriendlyAirRatio() < 1.0 & (double) this.game.Data.RuleVar[258] > 0.0)
            {
              if (this.GetRolePercent(unr, 12) < 20 && info == 1)
                role = 12;
            }
            else if ((double) this.game.Data.Round > (double) this.game.Data.RuleVar[259] & (double) this.GetFriendlyAirRatio() < (double) this.game.Data.RuleVar[258] && this.GetRolePercent(unr, 12) < 40 && info == 1)
              role = 12;
          }
        }
        if (this.game.Data.UnitObj[unr].AIUnitGoal == 5)
        {
          int num = 1;
          if ((double) this.game.Data.Round > (double) this.game.Data.RuleVar[259] & (double) this.GetFriendlyAirRatio() < (double) this.game.Data.RuleVar[258])
            num = 0;
          if (this.game.HandyFunctionsObj.GetPowerPtsAbsoluteForAirOnly(unr) > 0)
            num = (double) this.game.HandyFunctionsObj.GetAirFieldStackModifier(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y) >= 1.0 ? num : 0;
          if (num == 1)
          {
            if ((double) this.GetRolePercent(unr, 13) > 0.5)
            {
              if (info == 1)
                role = 14;
              if (info == 2)
                role = 13;
              if (this.game.Data.UnitObj[unr].AIPlanNr > 0)
              {
                int aiPlanNr = this.game.Data.UnitObj[unr].AIPlanNr;
                if (this.TPlanObj[aiPlanNr].EnemyAir > this.TPlanObj[aiPlanNr].FriendlyAir)
                {
                  if (info == 1)
                    role = 13;
                  if (info == 2)
                    role = 14;
                }
              }
            }
            else
            {
              if (info == 1)
                role = 13;
              if (info == 2)
                role = 14;
            }
          }
          else
            role = -1;
        }
        if (this.game.Data.UnitObj[unr].AIUnitGoal == 9)
        {
          if (info == 1)
            role = 18;
          if (info == 2)
            role = 19;
        }
        if (this.game.Data.UnitObj[unr].AIUnitGoal == 10)
        {
          if (info == 1)
            role = 19;
          if (info == 2)
            role = 18;
        }
        if (this.game.Data.UnitObj[unr].AIUnitGoal == 8)
        {
          if (this.GetRolePercent(unr, 17) <= 0)
          {
            if (info == 1)
              role = 17;
            if (info == 2)
              role = 18;
          }
          else if ((double) this.GetRolePercent(unr, 18) > 0.5)
          {
            if (info == 1)
              role = 17;
            if (info == 2)
              role = 18;
          }
          else
          {
            if (info == 1)
              role = 18;
            if (info == 2)
              role = -1;
          }
          if ((double) this.game.HandyFunctionsObj.GetUnitCarryCap(unr, 1) > (double) this.game.Data.RuleVar[30] * 2.1)
          {
            if (info == 1)
              role = 18;
            if (info == 2)
              role = -1;
          }
        }
        if (this.game.Data.UnitObj[unr].AIUnitGoal == 2)
        {
          if (Conversions.ToBoolean(Operators.AndObject((object) this.game.Data.UnitObj[unr].AIMobilize, Operators.CompareObjectLessEqual((object) this.game.HandyFunctionsObj.GetUnitCarryCap(unr, 0), this.game.HandyFunctionsObj.GetUnitWeightWithoutLandCarryCap(unr), false))))
          {
            if ((double) this.game.HandyFunctionsObj.GetUnitStackPts(unr) > (double) this.game.Data.RuleVar[247])
            {
              if (info == 1)
                role = 9;
              if (info == 2)
                role = 10;
            }
            else
            {
              if (info == 1)
                role = 10;
              if (info == 2)
                role = 6;
            }
          }
          else if ((double) this.GetRolePercent(unr, 10) < (double) this.game.Data.RuleVar[157])
          {
            if (info == 1)
              role = 10;
            if (info == 2)
              role = 6;
          }
          else
          {
            if (info == 1)
              role = 6;
            if (info == 2)
              role = 10;
          }
          if ((double) this.game.Data.Round > (double) this.game.Data.RuleVar[259] & (double) this.game.Data.RuleVar[258] < (double) this.GetFriendlyAirRatio() & (double) this.GetFriendlyAirRatio() < 1.0 & (double) this.game.Data.RuleVar[258] > 0.0)
          {
            if (this.GetRolePercent(unr, 12) < 25)
            {
              if (info == 1)
                role = 12;
              if (info == 2)
                role = 10;
            }
          }
          else if ((double) this.game.Data.Round > (double) this.game.Data.RuleVar[259] & (double) this.GetFriendlyAirRatio() < (double) this.game.Data.RuleVar[258] && this.GetRolePercent(unr, 12) < 25)
          {
            if (info == 1)
              role = 12;
            if (info == 2)
              role = 10;
          }
          if (this.TPlanObj[this.game.Data.UnitObj[unr].AIPlanNr].Type == 40 && this.game.Data.UnitObj[unr].AIReserve && this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unr, true) > this.GetAbsolutePowerForReserveUnit(this.game.Data.UnitObj[unr].AIPlanNr))
            role = -1;
        }
        if (this.game.Data.UnitObj[unr].AIUnitGoal == 3)
        {
          if (Conversions.ToBoolean(Operators.AndObject((object) this.game.Data.UnitObj[unr].AIMobilize, Operators.CompareObjectLess((object) this.game.HandyFunctionsObj.GetUnitCarryCap(unr, 0), this.game.HandyFunctionsObj.GetUnitWeightWithoutLandCarryCap(unr), false))))
          {
            if ((double) this.game.HandyFunctionsObj.GetUnitStackPts(unr) > (double) this.game.Data.RuleVar[247])
            {
              if (info == 1)
                role = 9;
              if (info == 2)
                role = 8;
            }
            else
            {
              if (info == 2)
                role = 8;
              if (info == 1)
                role = 6;
            }
            if ((double) this.game.Data.Round > (double) this.game.Data.RuleVar[259] & (double) this.game.Data.RuleVar[258] < (double) this.GetFriendlyAirRatio() & (double) this.GetFriendlyAirRatio() < 1.0 & (double) this.game.Data.RuleVar[258] > 0.0)
            {
              if (info == 1)
                role = 12;
              if (info == 2)
                role = 8;
            }
            else if ((double) this.game.Data.Round > (double) this.game.Data.RuleVar[259] & (double) this.GetFriendlyAirRatio() < (double) this.game.Data.RuleVar[258])
            {
              if (info == 1)
                role = 12;
              if (info == 2)
                role = 8;
            }
          }
          else if ((double) this.GetRolePercent(unr, 8) < (double) this.game.Data.RuleVar[158])
          {
            if (info == 1)
              role = 8;
            if (info == 2)
              role = 6;
            if ((double) this.game.Data.Round > (double) this.game.Data.RuleVar[259] & (double) this.game.Data.RuleVar[258] < (double) this.GetFriendlyAirRatio() & (double) this.GetFriendlyAirRatio() < 1.0 & (double) this.game.Data.RuleVar[258] > 0.0)
            {
              if (this.GetRolePercent(unr, 12) < 10)
              {
                if (info == 1)
                  role = 12;
                if (info == 2)
                  role = 8;
              }
            }
            else if ((double) this.game.Data.Round > (double) this.game.Data.RuleVar[259] & (double) this.GetFriendlyAirRatio() < (double) this.game.Data.RuleVar[258] && this.GetRolePercent(unr, 12) < 25)
            {
              if (info == 1)
                role = 12;
              if (info == 2)
                role = 8;
            }
          }
          else
          {
            if (info == 2)
              role = 8;
            if (info == 1)
              role = 6;
          }
          if (this.TPlanObj[this.game.Data.UnitObj[unr].AIPlanNr].Type == 40 && this.game.Data.UnitObj[unr].AIReserve && this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unr, true) > this.GetAbsolutePowerForReserveUnit(this.game.Data.UnitObj[unr].AIPlanNr))
            role = -1;
        }
        if (this.game.Data.UnitObj[unr].IsHQ)
        {
          if (this.game.HandyFunctionsObj.GetStaffPercent(unr) < 100)
          {
            if ((double) this.game.Data.RuleVar[(int) byte.MaxValue] < 1.0)
            {
              if (info == 1)
                role = 1;
              if (info == 2)
                role = -1;
            }
            else
            {
              if (info == 1)
                role = 6;
              if (info == 2)
                role = -1;
            }
          }
          else
          {
            if (Operators.ConditionalCompareObjectLess((object) this.game.HandyFunctionsObj.GetUnitCarryCap(unr, 0), this.game.HandyFunctionsObj.GetUnitWeightWithoutLandCarryCap(unr), false))
            {
              if (info == 1)
                role = 9;
              if (info == 2)
                role = -1;
            }
            else if ((double) this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unr, true) < (double) this.game.Data.RuleVar[182])
            {
              if (info == 1)
                role = 6;
              if (info == 2)
                role = -1;
            }
            else
              role = -1;
            if ((double) this.game.Data.Round > (double) this.game.Data.RuleVar[259] & (double) this.game.Data.RuleVar[258] < (double) this.GetFriendlyAirRatio() & (double) this.GetFriendlyAirRatio() < 1.0 & (double) this.game.Data.RuleVar[258] > 0.0)
            {
              if (this.GetRolePercent(unr, 12) < 10)
              {
                if (info == 1)
                  role = 12;
                if (info == 2)
                  role = -1;
              }
            }
            else if ((double) this.game.Data.Round > (double) this.game.Data.RuleVar[259] & (double) this.GetFriendlyAirRatio() < (double) this.game.Data.RuleVar[258] && this.GetRolePercent(unr, 12) < 25)
            {
              if (info == 1)
                role = 12;
              if (info == 2)
                role = -1;
            }
          }
        }
        roleSfResult.rolenr = role;
        roleSfResult.itemtypenr = -1;
        roleSfResult.sftypenr = -1;
        if (!onlyrole)
        {
          if (role > -1 & role != 9)
          {
            roleSfResult.itemtypenr = this.FindBestSuitedItemType(unr, role, prodpts);
            roleSfResult.sftypenr = roleSfResult.itemtypenr <= -1 ? -1 : this.game.Data.ItemTypeObj[roleSfResult.itemtypenr].IsSFType;
          }
          else
          {
            roleSfResult.itemtypenr = -1;
            roleSfResult.sftypenr = -1;
          }
        }
        return roleSfResult;
      }
      roleSfResult.rolenr = -1;
      roleSfResult.sftypenr = -1;
      roleSfResult.itemtypenr = -1;
      return roleSfResult;
    }

    public int GetRolePercent(int unr, int rolenr)
    {
      int sfCount = this.game.Data.UnitObj[unr].SFCount;
      int num1;
      int num2;
      for (int index = 0; index <= sfCount; ++index)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index];
        int type = this.game.Data.SFObj[sf].Type;
        num1 += this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].PowerPts;
        if (this.game.Data.SFTypeObj[type].AIRoleScore[rolenr] > 0)
          num2 = (int) Math.Round((double) num2 + (double) (this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].PowerPts) * ((double) this.game.Data.SFTypeObj[type].AIRoleScore[rolenr] / 100.0));
      }
      return num1 == 0 ? 0 : (int) Math.Round(Conversion.Int((double) (100 * num2) / (double) num1));
    }

    public int LandTransferGetSF(int unr, int roletype, int sftypenr = -1)
    {
      int sf1 = -1;
      if (roletype == -1)
        return -1;
      int sfCount = this.game.Data.UnitObj[unr].SFCount;
      for (int index = 0; index <= sfCount; ++index)
      {
        int sf2 = this.game.Data.UnitObj[unr].SFList[index];
        int type = this.game.Data.SFObj[sf2].Type;
        int num1 = this.game.Data.SFTypeObj[type].AIRoleScore[roletype];
        if (type == sftypenr)
          num1 += 99999;
        if (roletype == 6 & this.game.Data.SFTypeObj[type].AIRoleScore[1] > num1)
          num1 = -1;
        int num2;
        if (num1 > num2)
        {
          num2 = num1;
          sf1 = sf2;
        }
      }
      return sf1;
    }

    public void ExecSendStaffUp()
    {
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int unr1 = 0; unr1 <= unitCounter1; ++unr1)
      {
        if (this.game.Data.UnitObj[unr1].X > -1 & this.game.Data.UnitObj[unr1].PreDef == -1 && this.game.Data.UnitObj[unr1].Regime == this.game.Data.Turn)
        {
          if (!this.game.Data.UnitObj[unr1].IsHQ && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unr1].X, this.game.Data.UnitObj[unr1].Y].LandscapeType].IsSea)
          {
            for (int sfCount = this.game.Data.UnitObj[unr1].SFCount; sfCount >= 0; sfCount += -1)
            {
              int sf = this.game.Data.UnitObj[unr1].SFList[sfCount];
              int type = this.game.Data.SFObj[this.game.Data.UnitObj[unr1].SFList[sfCount]].Type;
              if (this.game.Data.SFTypeObj[type].AIRoleScore[18] > 0 & this.game.Data.UnitObj[unr1].AIPlanNr > 0)
              {
                if (this.HexBackPlan[this.game.Data.UnitObj[unr1].X, this.game.Data.UnitObj[unr1].Y] < 1)
                {
                  int num = this.HexPlan[this.game.Data.UnitObj[unr1].X, this.game.Data.UnitObj[unr1].Y];
                }
                if (this.TPlanObj[this.game.Data.UnitObj[unr1].AIPlanNr].SeaStand == 4 | this.TPlanObj[this.game.Data.UnitObj[unr1].AIPlanNr].SeaStand == 8)
                {
                  int x = this.game.Data.UnitObj[unr1].X;
                  int y = this.game.Data.UnitObj[unr1].Y;
                  int unitCounter2 = this.game.Data.MapObj[0].HexObj[x, y].UnitCounter;
                  for (int index = 0; index <= unitCounter2; ++index)
                  {
                    int unit = this.game.Data.MapObj[0].HexObj[x, y].UnitList[index];
                    if (unit != unr1 && this.game.Data.UnitObj[unit].AIUnitGoal == 9 | this.game.Data.UnitObj[unit].AIUnitGoal == 10)
                    {
                      int unr2 = unit;
                      int qty = this.game.Data.SFObj[sf].Qty;
                      if (qty > 0)
                      {
                        this.game.HandyFunctionsObj.AddTroops3(unr2, type, this.game.Data.SFObj[sf].People, qty, this.game.Data.SFObj[sf].Xp, this.game.Data.SFObj[sf].Rdn, 0, this.game.Data.SFObj[sf].Mor, MoveType: this.game.Data.SFObj[sf].MoveType);
                        this.game.HandyFunctionsObj.RemoveTroops(unr1, type, this.game.Data.SFObj[sf].People, qty, this.game.Data.SFObj[sf].MoveType);
                      }
                    }
                  }
                }
              }
            }
          }
          if (!this.game.Data.UnitObj[unr1].IsHQ && Operators.ConditionalCompareObjectGreater(this.GetEPPerTurn(unr1), (object) this.game.Data.RuleVar[215], false))
          {
            for (int sfCount = this.game.Data.UnitObj[unr1].SFCount; sfCount >= 0; sfCount += -1)
            {
              int sf = this.game.Data.UnitObj[unr1].SFList[sfCount];
              int type = this.game.Data.SFObj[this.game.Data.UnitObj[unr1].SFList[sfCount]].Type;
              if (this.game.Data.SFTypeObj[type].EP > 0)
              {
                int landReservePlan = this.SAObj[this.HexSA[this.game.Data.UnitObj[unr1].X, this.game.Data.UnitObj[unr1].Y]].LandReservePlan;
                if (landReservePlan > 0)
                {
                  int hq = this.TPlanObj[landReservePlan].HQ;
                  if (hq > -1)
                  {
                    int num = (int) Math.Round((double) this.game.Data.SFObj[sf].Qty / 3.0);
                    if (num > 0)
                    {
                      int x = this.game.Data.UnitObj[unr1].X;
                      int y = this.game.Data.UnitObj[unr1].Y;
                      this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), x, y, 0);
                      if (this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y] < 9999)
                      {
                        this.game.HandyFunctionsObj.AddTroops3(hq, type, this.game.Data.SFObj[sf].People, num, this.game.Data.SFObj[sf].Xp, this.game.Data.SFObj[sf].Rdn, 0, this.game.Data.SFObj[sf].Mor, MoveType: this.game.Data.SFObj[sf].MoveType);
                        this.game.HandyFunctionsObj.RemoveTroops(unr1, type, this.game.Data.SFObj[sf].People, num, this.game.Data.SFObj[sf].MoveType);
                      }
                    }
                  }
                }
              }
            }
          }
          if (!this.game.Data.UnitObj[unr1].IsHQ)
          {
            int integer = Conversions.ToInteger(Operators.SubtractObject((object) this.game.HandyFunctionsObj.GetUnitCarryCap(unr1, 0), this.game.HandyFunctionsObj.GetUnitWeightWithoutLandCarryCap(unr1)));
            for (int sfCount = this.game.Data.UnitObj[unr1].SFCount; sfCount >= 0; sfCount += -1)
            {
              int sf = this.game.Data.UnitObj[unr1].SFList[sfCount];
              int type = this.game.Data.SFObj[this.game.Data.UnitObj[unr1].SFList[sfCount]].Type;
              if (this.game.Data.SFTypeObj[type].AIRoleScore[9] > 0 & this.game.Data.UnitObj[unr1].AIPlanNr > 0 && this.HexSA[this.game.Data.UnitObj[unr1].X, this.game.Data.UnitObj[unr1].Y] > 0)
              {
                int landReservePlan = this.SAObj[this.HexSA[this.game.Data.UnitObj[unr1].X, this.game.Data.UnitObj[unr1].Y]].LandReservePlan;
                integer -= this.game.Data.SFTypeObj[type].CarryCap;
                if (landReservePlan > 0 & integer > 0)
                {
                  int hq = this.TPlanObj[landReservePlan].HQ;
                  if (hq > -1)
                  {
                    int num = this.game.Data.SFObj[sf].Qty;
                    if (num > 1)
                      num = 1;
                    if (num > 0)
                    {
                      int x = this.game.Data.UnitObj[unr1].X;
                      int y = this.game.Data.UnitObj[unr1].Y;
                      this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), x, y, 0);
                      if (this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y] < 9999)
                      {
                        this.game.HandyFunctionsObj.AddTroops3(hq, type, this.game.Data.SFObj[sf].People, num, this.game.Data.SFObj[sf].Xp, this.game.Data.SFObj[sf].Rdn, 0, this.game.Data.SFObj[sf].Mor, MoveType: this.game.Data.SFObj[sf].MoveType);
                        this.game.HandyFunctionsObj.RemoveTroops(unr1, type, this.game.Data.SFObj[sf].People, num, this.game.Data.SFObj[sf].MoveType);
                      }
                    }
                  }
                }
              }
            }
          }
          if (!this.game.Data.UnitObj[unr1].IsHQ && this.game.Data.UnitObj[unr1].AIUnitGoal == 1 & !this.game.Data.UnitObj[unr1].AIReserve & !this.game.Data.UnitObj[unr1].AIMobilize)
          {
            for (int sfCount = this.game.Data.UnitObj[unr1].SFCount; sfCount >= 0; sfCount += -1)
            {
              int sf = this.game.Data.UnitObj[unr1].SFList[sfCount];
              int type = this.game.Data.SFObj[this.game.Data.UnitObj[unr1].SFList[sfCount]].Type;
              if (this.game.Data.SFTypeObj[type].AIRoleScore[12] > 0 & this.game.Data.UnitObj[unr1].AIPlanNr > 0)
              {
                int landReservePlan = this.SAObj[this.HexSA[this.game.Data.UnitObj[unr1].X, this.game.Data.UnitObj[unr1].Y]].LandReservePlan;
                if (landReservePlan > 0)
                {
                  int hq = this.TPlanObj[landReservePlan].HQ;
                  if (hq > -1)
                  {
                    int qty = this.game.Data.SFObj[sf].Qty;
                    if (qty > 0)
                    {
                      int x = this.game.Data.UnitObj[unr1].X;
                      int y = this.game.Data.UnitObj[unr1].Y;
                      this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), x, y, 0);
                      if (this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[hq].X, this.game.Data.UnitObj[hq].Y] < 9999)
                      {
                        this.game.HandyFunctionsObj.AddTroops3(hq, type, this.game.Data.SFObj[sf].People, qty, this.game.Data.SFObj[sf].Xp, this.game.Data.SFObj[sf].Rdn, 0, this.game.Data.SFObj[sf].Mor, MoveType: this.game.Data.SFObj[sf].MoveType);
                        this.game.HandyFunctionsObj.RemoveTroops(unr1, type, this.game.Data.SFObj[sf].People, qty, this.game.Data.SFObj[sf].MoveType);
                      }
                    }
                  }
                }
              }
            }
          }
          for (int sfCount = this.game.Data.UnitObj[unr1].SFCount; sfCount >= 0; sfCount += -1)
          {
            int sf = this.game.Data.UnitObj[unr1].SFList[sfCount];
            int type = this.game.Data.SFObj[this.game.Data.UnitObj[unr1].SFList[sfCount]].Type;
            if (this.game.Data.SFTypeObj[type].StaffPts > 0 && this.game.Data.UnitObj[unr1].HQ > -1)
            {
              int num1 = 0;
              if (!this.game.Data.UnitObj[unr1].IsHQ)
                num1 = 1;
              if (this.game.HandyFunctionsObj.GetStaffPercent(unr1) > 150)
                num1 = 2;
              if (num1 > 0)
              {
                int num2 = this.game.Data.SFObj[sf].Qty;
                if (num1 == 2)
                  num2 = (int) Math.Round((double) num2 / 3.0);
                if (num2 > 0)
                {
                  int x = this.game.Data.UnitObj[unr1].X;
                  int y = this.game.Data.UnitObj[unr1].Y;
                  this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), x, y, 0);
                  if (this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[this.game.Data.UnitObj[unr1].HQ].X, this.game.Data.UnitObj[this.game.Data.UnitObj[unr1].HQ].Y] < 9999)
                  {
                    this.game.HandyFunctionsObj.AddTroops3(this.game.Data.UnitObj[unr1].HQ, type, this.game.Data.SFObj[sf].People, num2, this.game.Data.SFObj[sf].Xp, this.game.Data.SFObj[sf].Rdn, 0, this.game.Data.SFObj[sf].Mor, MoveType: this.game.Data.SFObj[sf].MoveType);
                    this.game.HandyFunctionsObj.RemoveTroops(unr1, type, this.game.Data.SFObj[sf].People, num2, this.game.Data.SFObj[sf].MoveType);
                  }
                }
              }
            }
            if (this.game.Data.SFTypeObj[type].Cap > 0 & this.game.Data.SFTypeObj[type].Theater == 0 && this.game.Data.UnitObj[unr1].HQ > -1)
            {
              int num3 = 0;
              if (this.game.Data.UnitObj[this.game.Data.UnitObj[unr1].HQ].LandCap < this.game.Data.UnitObj[unr1].LandCap)
                num3 = 2;
              if (num3 > 0)
              {
                int num4 = (int) Math.Round((double) this.game.Data.SFObj[sf].Qty / 3.0);
                if (num4 > 0)
                {
                  int x = this.game.Data.UnitObj[unr1].X;
                  int y = this.game.Data.UnitObj[unr1].Y;
                  this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, (int) Math.Round((double) this.game.Data.RuleVar[78]), x, y, 0);
                  if (this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[this.game.Data.UnitObj[unr1].HQ].X, this.game.Data.UnitObj[this.game.Data.UnitObj[unr1].HQ].Y] < 9999)
                  {
                    this.game.HandyFunctionsObj.AddTroops3(this.game.Data.UnitObj[unr1].HQ, type, this.game.Data.SFObj[sf].People, num4, this.game.Data.SFObj[sf].Xp, this.game.Data.SFObj[sf].Rdn, 0, this.game.Data.SFObj[sf].Mor, MoveType: this.game.Data.SFObj[sf].MoveType);
                    this.game.HandyFunctionsObj.RemoveTroops(unr1, type, this.game.Data.SFObj[sf].People, num4, this.game.Data.SFObj[sf].MoveType);
                  }
                }
              }
            }
          }
        }
      }
    }

    public void ExecChangeHQ()
    {
      this.TempAvgUnits = new int[this.TPlanCount + 1];
      int tplanCount1 = this.TPlanCount;
      for (int index = 0; index <= tplanCount1; ++index)
        this.TempAvgUnits[index] = -1;
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter1; ++unr)
      {
        if (this.game.Data.UnitObj[unr].PreDef == -1 && this.game.Data.UnitObj[unr].X > -1 && this.game.Data.UnitObj[unr].IsHQ && this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].HQ == -1)
        {
          int num = 0;
          int tplanCount2 = this.TPlanCount;
          for (int index = 1; index <= tplanCount2; ++index)
          {
            if (this.TPlanObj[index].HQ == unr)
              num = 1;
          }
          if (num == 0 & this.game.Data.UnitObj[unr].SFCount <= 8)
          {
            this.AddLog(this.game.Data.UnitObj[unr].Name + " has been degraded from hq to normal unit.");
            this.game.Data.UnitObj[unr].IsHQ = false;
            RegimeClass[] regimeObj1 = this.game.Data.RegimeObj;
            RegimeClass[] regimeClassArray1 = regimeObj1;
            int turn1 = this.game.Data.Turn;
            int index1 = turn1;
            regimeClassArray1[index1].ResPts = (int) Math.Round((double) ((float) regimeObj1[turn1].ResPts + this.game.Data.RuleVar[47]));
            RegimeClass[] regimeObj2 = this.game.Data.RegimeObj;
            RegimeClass[] regimeClassArray2 = regimeObj2;
            int turn2 = this.game.Data.Turn;
            int index2 = turn2;
            regimeClassArray2[index2].ResPts = (int) Math.Round((double) ((float) regimeObj2[turn2].ResPts - this.game.Data.RuleVar[46]));
            if (this.game.HandyFunctionsObj.HasUnitNavySF(unr))
            {
              int x = this.game.Data.UnitObj[unr].X;
              int y = this.game.Data.UnitObj[unr].Y;
              int hq = this.game.Data.UnitObj[unr].HQ;
              if (this.game.Data.MapObj[0].HexObj[x, y].UnitCounter < 15)
              {
                this.game.ProcessingObj.NewUnit(x, y, 0, false, this.game.Data.Turn);
                this.game.Data.UnitObj[this.game.Data.UnitCounter].HQ = hq;
                this.game.Data.UnitObj[this.game.Data.UnitCounter].AIPlanNr = -1;
                this.game.Data.UnitObj[this.game.Data.UnitCounter].AIUnitGoal = 8;
                for (int sfCount = this.game.Data.UnitObj[unr].SFCount; sfCount >= 0; sfCount += -1)
                {
                  int sf = this.game.Data.UnitObj[unr].SFList[sfCount];
                  if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater == 1)
                  {
                    this.game.Data.UnitObj[unr].RemoveSF(sf);
                    this.game.Data.UnitObj[this.game.Data.UnitCounter].AddSF(sf);
                  }
                }
              }
            }
            if (this.game.HandyFunctionsObj.HasUnitAirSF(unr))
            {
              int x = this.game.Data.UnitObj[unr].X;
              int y = this.game.Data.UnitObj[unr].Y;
              int hq = this.game.Data.UnitObj[unr].HQ;
              if (this.game.Data.MapObj[0].HexObj[x, y].UnitCounter < 15)
              {
                this.game.ProcessingObj.NewUnit(x, y, 0, false, this.game.Data.Turn);
                this.game.Data.UnitObj[this.game.Data.UnitCounter].HQ = hq;
                this.game.Data.UnitObj[this.game.Data.UnitCounter].AIPlanNr = -1;
                this.game.Data.UnitObj[this.game.Data.UnitCounter].AIUnitGoal = 5;
                for (int sfCount = this.game.Data.UnitObj[unr].SFCount; sfCount >= 0; sfCount += -1)
                {
                  int sf = this.game.Data.UnitObj[unr].SFList[sfCount];
                  if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater == 2)
                  {
                    this.game.Data.UnitObj[unr].RemoveSF(sf);
                    this.game.Data.UnitObj[this.game.Data.UnitCounter].AddSF(sf);
                  }
                }
              }
            }
            int unitCounter2 = this.game.Data.UnitCounter;
            for (int index3 = 0; index3 <= unitCounter2; ++index3)
            {
              if (this.game.Data.UnitObj[index3].HQ == unr)
                this.game.Data.UnitObj[index3].HQ = -1;
            }
          }
        }
      }
      int tplanCount3 = this.TPlanCount;
      for (int index4 = 1; index4 <= tplanCount3; ++index4)
      {
        this.AddLog("ChangeHQ for " + Conversion.Str((object) index4) + "?");
        SimpleList simpleList = new SimpleList();
        int unitCounter3 = this.game.Data.UnitCounter;
        for (int tid = 0; tid <= unitCounter3; ++tid)
        {
          if (this.game.Data.UnitObj[tid].AIPlanNr == index4 & this.game.Data.UnitObj[tid].IsHQ & this.game.Data.UnitObj[tid].Regime == this.game.Data.Turn)
          {
            int num1 = (int) Math.Round((double) (this.game.Data.RuleVar[3] + Conversion.Int(this.game.Data.RuleVar[3] / 5f)));
            int tdata1 = this.AverageDistanceUnitsInAP(index4, this.game.Data.UnitObj[tid].X, this.game.Data.UnitObj[tid].Y, true) * this.AverageDistanceUnits(index4, this.game.Data.UnitObj[tid].X, this.game.Data.UnitObj[tid].Y);
            int num2 = num1 - tdata1;
            this.AddLog(this.game.Data.UnitObj[tid].Name + " gets weight = " + Conversion.Str((object) num2));
            simpleList.Add(tid, num2, tdata1);
          }
        }
        int tplanCount4 = this.TPlanCount;
        for (int index5 = 1; index5 <= tplanCount4; ++index5)
        {
          if (index5 != index4)
          {
            if (this.GetAreaNr(this.TPlanObj[index5].FromArea) == this.GetAreaNr(this.TPlanObj[index4].FromArea) & this.TPlanObj[index5].HQ > -1)
            {
              int num3 = (int) Math.Round((double) this.game.Data.RuleVar[3]);
              if (this.TPlanObj[index5].Type == 20)
                num3 += 100;
              int tdata1 = this.AverageDistanceUnitsInAP(index4, this.game.Data.UnitObj[this.TPlanObj[index5].HQ].X, this.game.Data.UnitObj[this.TPlanObj[index5].HQ].Y, true);
              int num4 = num3 - tdata1;
              this.AddLog(this.game.Data.UnitObj[this.TPlanObj[index5].HQ].Name + " gets weight = " + Conversion.Str((object) num4));
              simpleList.Add(this.TPlanObj[index5].HQ, num4, tdata1);
            }
            else if (this.TPlanObj[index5].HQ > -1)
            {
              int num5 = this.AreaDistance2(this.GetAreaNr(this.TPlanObj[index5].FromArea), this.GetAreaNr(this.TPlanObj[index4].FromArea));
              int num6 = 0;
              if (num5 <= 0)
              {
                num5 = this.AreaDistanceIncludingSea(this.GetAreaNr(this.TPlanObj[index5].FromArea), this.GetAreaNr(this.TPlanObj[index4].FromArea));
                num6 = 1;
              }
              if (num5 > 0)
              {
                int num7 = (int) Math.Round((double) (this.game.Data.RuleVar[3] - (float) (num5 * 10)));
                if (num6 == 1)
                  num7 -= 5;
                if (this.TPlanObj[index5].Type == 20)
                  num7 += 5;
                int tdata1 = this.AverageDistanceUnitsInAP(index4, this.game.Data.UnitObj[this.TPlanObj[index5].HQ].X, this.game.Data.UnitObj[this.TPlanObj[index5].HQ].Y, true);
                int num8 = num7 - tdata1;
                this.AddLog(this.game.Data.UnitObj[this.TPlanObj[index5].HQ].Name + " gets weight = " + Conversion.Str((object) num8));
                simpleList.Add(this.TPlanObj[index5].HQ, num8, tdata1);
              }
            }
          }
        }
        simpleList.Sort();
        if (simpleList.Counter > -1)
        {
          int unitCounter4 = this.game.Data.UnitCounter;
          for (int Unr = 1; Unr <= unitCounter4; ++Unr)
          {
            if (this.game.Data.UnitObj[Unr].AIPlanNr == index4 && !this.game.Data.UnitObj[Unr].IsHQ && this.game.Data.UnitObj[Unr].HQ != simpleList.Id[simpleList.Counter] && this.game.Data.UnitObj[Unr].X > -1 & this.game.Data.UnitObj[Unr].Regime == this.game.Data.Turn && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[Unr].X, this.game.Data.UnitObj[Unr].Y].LandscapeType].IsSea)
            {
              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, (int) Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[Unr].X, this.game.Data.UnitObj[Unr].Y, 0);
              int num9 = 1;
              if (this.game.Data.UnitObj[Unr].HQ > -1)
              {
                int num10 = this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[this.game.Data.UnitObj[Unr].HQ].X, this.game.Data.UnitObj[this.game.Data.UnitObj[Unr].HQ].Y];
                int num11 = (int) Math.Round((double) ((float) this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[simpleList.Id[simpleList.Counter]].X, this.game.Data.UnitObj[simpleList.Id[simpleList.Counter]].Y] + Conversion.Int(this.game.Data.RuleVar[3] / 4f)));
                int num12 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[this.game.Data.UnitObj[Unr].HQ].X, this.game.Data.UnitObj[this.game.Data.UnitObj[Unr].HQ].Y, 0, this.game.Data.UnitObj[Unr].X, this.game.Data.UnitObj[Unr].Y, 0);
                int num13 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[simpleList.Id[simpleList.Counter]].X, this.game.Data.UnitObj[simpleList.Id[simpleList.Counter]].Y, 0, this.game.Data.UnitObj[Unr].X, this.game.Data.UnitObj[Unr].Y, 0);
                if (num10 < num11 & num13 + 2 > num12)
                  num9 = 0;
                if (this.game.Data.UnitObj[Unr].HQ > -1 && this.game.Data.UnitObj[this.game.Data.UnitObj[Unr].HQ].AIPlanNr > 0 && this.TPlanObj[this.game.Data.UnitObj[this.game.Data.UnitObj[Unr].HQ].AIPlanNr].Type == 30)
                  num9 = 1;
                if (num9 == 0)
                  this.AddLog("Will not switch " + this.game.Data.UnitObj[Unr].Name + " to best HQ. Since it is less than 50ap closer && less then 2 hex closer.");
              }
              if (num9 == 1)
                this.game.ProcessingObj.SetUnitHq(Unr, simpleList.Id[simpleList.Counter]);
            }
          }
        }
        if (this.TPlanObj[index4].HQ > -1 & this.TPlanObj[index4].Type == 20)
        {
          int areaNr = this.GetAreaNr(this.TPlanObj[index4].FromArea);
          if (areaNr > 0 && this.SAObj[areaNr].LandReservePlan > 0)
          {
            int landReservePlan = this.SAObj[areaNr].LandReservePlan;
            if (this.TPlanObj[landReservePlan].HQ > -1 && this.game.Data.UnitObj[this.TPlanObj[index4].HQ].HQ != this.TPlanObj[landReservePlan].HQ)
            {
              this.game.ProcessingObj.SetUnitHq(this.TPlanObj[index4].HQ, this.TPlanObj[landReservePlan].HQ);
              this.AddLog("-Changed " + this.game.Data.UnitObj[this.TPlanObj[index4].HQ].Name + " HQ to " + this.game.Data.UnitObj[this.TPlanObj[landReservePlan].HQ].Name);
            }
          }
        }
      }
    }

    public void ExecuteMovement(int PlanNr, int MovePhaseNr)
    {
      object[,] objArray1 = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      CoordList coordList = new CoordList();
      SimpleList UL = new SimpleList();
      SimpleList SL = new SimpleList();
      if (PlanNr < 1)
        return;
      int unitCounter1 = this.game.Data.UnitCounter;
      int Number1;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        if (this.game.Data.UnitObj[index].AIPlanNr == PlanNr & this.game.Data.UnitObj[index].PreDef <= -1 && this.game.Data.UnitObj[index].Regime == this.game.Data.Turn)
        {
          UL.Add(index, this.GetForceLandStrength(index), -1);
          if (!(this.game.Data.UnitObj[index].IsHQ & this.TPlanObj[PlanNr].Type == 20) && !(this.game.Data.UnitObj[index].IsHQ & this.TPlanObj[PlanNr].Type == 30) && this.game.Data.UnitObj[index].AICutoff <= 0 && this.game.Data.UnitObj[index].AIUnitGoal != 4 && this.game.Data.UnitObj[index].AIUnitGoal != 5 && this.game.Data.UnitObj[index].AIUnitGoal != 3 && this.game.Data.UnitObj[index].AIUnitGoal != 9 && this.game.Data.UnitObj[index].AIUnitGoal != 10 && this.game.Data.UnitObj[index].AIUnitGoal != 8)
          {
            if (!this.game.Data.UnitObj[index].AIReserve)
            {
              if (this.game.Data.UnitObj[index].X != -1 && !this.game.Data.UnitObj[index].AIDisband)
                ++Number1;
            }
          }
        }
      }
      this.AddLog("");
      this.AddLog("Plan " + Conversion.Str((object) PlanNr) + " execution: .. av.units=" + Conversion.Str((object) Number1));
      int tid1;
      Coordinate Expression;
      if (Number1 > 0)
      {
        if (this.TPlanObj[PlanNr].Type == 20)
        {
          int num1;
          int num2;
          if (this.TPlanObj[PlanNr].Stand == 1 | this.TPlanObj[PlanNr].Stand == 2 & this.TPlanObj[PlanNr].RiverLine < 1)
          {
            tid1 = 0;
            int num3 = !Information.IsNothing((object) this.TPlanObj[PlanNr].TooArea) ? this.game.HandyFunctionsObj.Distance(this.TPlanObj[PlanNr].FromArea.X, this.TPlanObj[PlanNr].FromArea.Y, 0, this.TPlanObj[PlanNr].TooArea.X, this.TPlanObj[PlanNr].TooArea.Y, 0) : 15;
            if (num3 < 10)
              num3 = 10;
            int MaxDist = num3 * 2;
            this.SetMatrix1(this.TPlanObj[PlanNr].TooArea.X, this.TPlanObj[PlanNr].TooArea.Y, MaxDist: MaxDist);
            this.Matrix2 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
            int mapWidth = this.game.Data.MapObj[0].MapWidth;
            for (int index1 = 0; index1 <= mapWidth; ++index1)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index2 = 0; index2 <= mapHeight; ++index2)
                this.Matrix2[index1, index2] = this.Matrix1[index1, index2];
            }
            int unitCounter2 = this.game.Data.UnitCounter;
            for (int unr = 0; unr <= unitCounter2; ++unr)
            {
              if (this.game.Data.UnitObj[unr].Regime != this.game.Data.Turn & this.game.Data.UnitObj[unr].PreDef <= -1)
              {
                int x = this.game.Data.UnitObj[unr].X;
                int y = this.game.Data.UnitObj[unr].Y;
                if (x > -1 && this.HexSA[x, y] == this.GetAreaNr(this.TPlanObj[PlanNr].TooArea))
                {
                  int nr = SL.FindNr(-1, x, y);
                  int num4 = this.GetForceLandStrength(unr);
                  int num5 = (int) Math.Round(Conversion.Int((double) (this.GetClosestFrontlineDistance(this.GetAreaNr(this.TPlanObj[PlanNr].FromArea), x, y) + this.game.HandyFunctionsObj.Distance(x, y, 0, this.TPlanObj[PlanNr].FromArea.X, this.TPlanObj[PlanNr].FromArea.Y, 0)) / 2.0));
                  if (num5 < 1)
                    num5 = 1;
                  if (this.TPlanObj[PlanNr].Stand == 1)
                    num4 = (int) Math.Round((double) ((float) num4 * (1f + this.game.Data.RuleVar[225])));
                  int tweight = (int) Math.Round((double) num4 / (double) num5);
                  if (nr == -1)
                  {
                    ++tid1;
                    int tid2 = tid1;
                    SL.Add(tid2, tweight, x, y, this.Matrix1[x, y]);
                  }
                  else
                  {
                    int[] weight = SL.Weight;
                    int[] numArray = weight;
                    int index3 = nr;
                    int index4 = index3;
                    int num6 = weight[index3] + this.GetForceLandStrength(unr);
                    numArray[index4] = num6;
                  }
                  num1 += tweight;
                  ++num2;
                }
              }
            }
          }
          int num7;
          if (this.TPlanObj[PlanNr].Stand == 1)
          {
            if (num2 == 0)
              num2 = 1;
            if (num1 == 0)
              num1 = 100;
            num7 = (int) Math.Round((double) num1 / (double) num2);
            int x = this.TPlanObj[PlanNr].TooArea.X;
            int y = this.TPlanObj[PlanNr].TooArea.Y;
            int tweight = (int) Math.Round((double) ((float) (this.TPlanObj[PlanNr].TooArea.fuzzyvp * num7) * this.game.Data.RuleVar[151]));
            if (this.TPlanObj[PlanNr].TooArea.ConstitutantCount > 0)
              tweight = (int) Math.Round((double) tweight / 20.0);
            if ((double) this.game.Data.RuleVar[225] > 0.0)
              tweight = (int) Math.Round((double) tweight / Math.Pow((double) this.game.Data.RuleVar[225] + 1.0, 2.0));
            if (tweight < 0)
              tweight = 0;
            int nr = SL.FindNr(-1, x, y);
            if (nr == -1)
            {
              ++tid1;
              SL.Add(tid1, tweight, x, y, (int) Math.Round((double) this.game.Data.RuleVar[152]));
            }
            else
            {
              int[] weight = SL.Weight;
              int[] numArray = weight;
              int index5 = nr;
              int index6 = index5;
              int num8 = weight[index5] + tweight;
              numArray[index6] = num8;
            }
          }
          if (this.TPlanObj[PlanNr].Stand == 2 & this.TPlanObj[PlanNr].RiverLine < 1 | this.TPlanObj[PlanNr].Stand == 1)
          {
            int num9 = !Information.IsNothing((object) this.TPlanObj[PlanNr].TooArea) ? this.game.HandyFunctionsObj.Distance(this.TPlanObj[PlanNr].FromArea.X, this.TPlanObj[PlanNr].FromArea.Y, 0, this.TPlanObj[PlanNr].TooArea.X, this.TPlanObj[PlanNr].TooArea.Y, 0) : 15;
            if (num9 < 10)
              num9 = 10;
            int MaxDist = num9 * 2;
            this.SetMatrix1(this.TPlanObj[PlanNr].FromArea.X, this.TPlanObj[PlanNr].FromArea.Y, MaxDist: MaxDist);
            int mapWidth = this.game.Data.MapObj[0].MapWidth;
            for (int index7 = 0; index7 <= mapWidth; ++index7)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index8 = 0; index8 <= mapHeight; ++index8)
              {
                if (this.HexPlan[index7, index8] == PlanNr)
                {
                  if (this.TPlanObj[PlanNr].Stand == 2)
                  {
                    int tweight = (int) Math.Round(Conversion.Int((double) this.Matrix1[index7, index8] / (double) this.TPlanObj[PlanNr].FrontSize));
                    if (this.AIVP[index7, index8] > 0)
                      tweight *= 2;
                    if (tweight < 0)
                      tweight = 0;
                    int nr = SL.FindNr(-1, index7, index8);
                    if (nr == -1)
                    {
                      ++tid1;
                      SL.Add(tid1, tweight, index7, index8, this.Matrix1[index7, index8]);
                    }
                    else
                    {
                      int[] weight = SL.Weight;
                      int[] numArray = weight;
                      int index9 = nr;
                      int index10 = index9;
                      int num10 = weight[index9] + tweight;
                      numArray[index10] = num10;
                    }
                  }
                  if (this.TPlanObj[PlanNr].Stand == 1)
                  {
                    object obj = this.BestMatrix2(index7, index8, 2);
                    Coordinate coordinate;
                    Expression = obj != null ? (Coordinate) obj : coordinate;
                    if (Expression.onmap)
                    {
                      int nr = SL.FindNr(-1, Expression.x, Expression.y);
                      if (nr == -1)
                      {
                        ++tid1;
                        int tweight = (int) Math.Round((double) num7 / 3.0);
                        if (this.AIVP[Expression.x, Expression.y] > 0)
                          tweight *= 2;
                        SL.Add(tid1, tweight, Expression.x, Expression.y, this.Matrix1[index7, index8]);
                      }
                      else
                      {
                        int num11 = (int) Math.Round((double) num7 / 3.0);
                        if (this.AIVP[Expression.x, Expression.y] > 0)
                          num11 *= 2;
                        int[] weight = SL.Weight;
                        int[] numArray = weight;
                        int index11 = nr;
                        int index12 = index11;
                        int num12 = weight[index11] + num11;
                        numArray[index12] = num12;
                      }
                    }
                    else
                    {
                      ++tid1;
                      int tweight = (int) Math.Round((double) num7 / 3.0);
                      SL.Add(tid1, tweight, index7, index8, this.Matrix1[index7, index8]);
                    }
                  }
                }
              }
            }
          }
          if (this.TPlanObj[PlanNr].Stand == 2)
          {
            int mapWidth = this.game.Data.MapObj[0].MapWidth;
            for (int index13 = 0; index13 <= mapWidth; ++index13)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index14 = 0; index14 <= mapHeight; ++index14)
              {
                if (this.HexPlan[index13, index14] == PlanNr && this.TPlanObj[PlanNr].Stand == 2)
                {
                  int tweight = (int) Math.Round((double) ((float) (int) Math.Round((double) this.Matrix1[index13, index14] / (double) (this.TPlanObj[PlanNr].FrontSize + 1)) * this.GetEntrenchMod(index13, index14)));
                  if (tweight < 0)
                    tweight = 0;
                  int nr = SL.FindNr(-1, index13, index14);
                  if (nr == -1)
                  {
                    ++tid1;
                    SL.Add(tid1, tweight, index13, index14, this.Matrix1[index13, index14]);
                  }
                  else
                  {
                    int[] weight = SL.Weight;
                    int[] numArray = weight;
                    int index15 = nr;
                    int index16 = index15;
                    int num13 = weight[index15] + tweight;
                    numArray[index16] = num13;
                  }
                }
              }
            }
          }
          int num14 = 1;
          if ((double) this.game.Data.RuleVar[251] == 0.0)
            num14 = 0;
          if (num14 == 1)
          {
            int mapWidth = this.game.Data.MapObj[0].MapWidth;
            for (int index17 = 0; index17 <= mapWidth; ++index17)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index18 = 0; index18 <= mapHeight; ++index18)
              {
                if (this.HexSA[index17, index18] == this.GetAreaNr(this.TPlanObj[PlanNr].FromArea))
                {
                  int d = 0;
                  int unitCounter3 = this.game.Data.MapObj[0].HexObj[index17, index18].UnitCounter;
                  for (int index19 = 0; index19 <= unitCounter3; ++index19)
                  {
                    int unit = this.game.Data.MapObj[0].HexObj[index17, index18].UnitList[index19];
                    d += this.game.HandyFunctionsObj.GetPowerPtsAbsoluteForAirOnly(unit);
                  }
                  if (d > 0)
                  {
                    int num15 = this.GetClosestEnemyDistance(index17, index18, true);
                    if (num15 < 1)
                      num15 = 1;
                    if (num15 > 10)
                      num15 = 10;
                    if (num15 <= 6)
                    {
                      int nr = SL.FindNr(-1, index17, index18);
                      int tweight = (int) Math.Round(Math.Sqrt((double) d) * 25.0 / (double) num15);
                      if (this.TPlanObj[PlanNr].Stand == 1)
                        tweight = (int) Math.Round((double) ((float) tweight * (this.game.Data.RuleVar[251] / 2f)));
                      if (nr == -1)
                      {
                        ++tid1;
                        SL.Add(tid1, tweight, index17, index18, this.Matrix1[index17, index18]);
                        SL.Data4[SL.Counter] = 2;
                      }
                      else
                      {
                        int[] weight = SL.Weight;
                        int[] numArray = weight;
                        int index20 = nr;
                        int index21 = index20;
                        int num16 = weight[index20] + tweight;
                        numArray[index21] = num16;
                      }
                    }
                  }
                }
              }
            }
          }
          if (this.TPlanObj[PlanNr].Stand == 2 | this.TPlanObj[PlanNr].Stand == 1 && this.AIVP[this.TPlanObj[PlanNr].FromArea.X, this.TPlanObj[PlanNr].FromArea.Y] > 0)
          {
            int num17 = 1;
            if (this.TPlanObj[PlanNr].Stand == 1 && (double) this.game.Data.RuleVar[251] == 0.0)
              num17 = 0;
            if (num17 == 1)
            {
              if (num2 == 0)
                num2 = 1;
              if (num1 == 0)
                num1 = 100;
              int num18 = (int) Math.Round((double) num1 / (double) num2);
              if ((double) this.TPlanObj[PlanNr].WeightFriendlyForce > 0.0)
                num18 = (int) Math.Round((double) ((float) num18 * (this.TPlanObj[PlanNr].WeightEnemyForce / this.TPlanObj[PlanNr].WeightFriendlyForce)));
              int num19 = this.TPlanObj[PlanNr].Stand != 2 ? (int) Math.Round((double) num18 / 5.0) : (int) Math.Round((double) num18 / 2.0);
              int x = this.TPlanObj[PlanNr].FromArea.X;
              int y = this.TPlanObj[PlanNr].FromArea.Y;
              int tweight = (int) Math.Round((double) ((float) (this.TPlanObj[PlanNr].FromArea.fuzzyvp * num19) * this.game.Data.RuleVar[151]));
              if (tweight < 0)
                tweight = 0;
              int nr = SL.FindNr(-1, x, y);
              int frontlineDistance = this.GetClosestFrontlineDistance(this.GetAreaNr(this.TPlanObj[PlanNr].TooArea), x, y, true);
              int tdata4 = 0;
              int num20;
              if (frontlineDistance <= 1)
              {
                num20 = this.TPlanObj[PlanNr].Stand != 1 ? 2 : 1;
                tdata4 = 1;
              }
              else if (frontlineDistance <= 2)
              {
                num20 = 1;
                tdata4 = 1;
              }
              else if (frontlineDistance <= 3)
              {
                num20 = 1;
                tdata4 = 1;
                tweight = (int) Math.Round((double) tweight / 3.0);
              }
              else if (frontlineDistance <= 4)
              {
                num20 = 1;
                tweight = (int) Math.Round((double) tweight / 5.0);
              }
              else if (frontlineDistance <= 7)
              {
                num20 = 1;
                tweight = (int) Math.Round((double) tweight / 8.0);
              }
              else
              {
                num20 = 1;
                tweight = (int) Math.Round((double) tweight / 15.0);
              }
              if (this.TPlanObj[PlanNr].Stand == 1)
                tweight = (int) Math.Round((double) ((float) tweight * this.game.Data.RuleVar[251]));
              if (nr == -1)
              {
                if (num20 == 0)
                  num20 = 1;
                int num21 = num20;
                for (int index = 1; index <= num21; ++index)
                {
                  ++tid1;
                  SL.Add(tid1, tweight, x, y, (int) Math.Round((double) this.game.Data.RuleVar[152]), tdata4);
                }
              }
              else
              {
                int[] weight = SL.Weight;
                int[] numArray = weight;
                int index22 = nr;
                int index23 = index22;
                int num22 = weight[index22] + tweight * num20;
                numArray[index23] = num22;
                SL.Data4[nr] = tdata4;
              }
            }
          }
          if (this.TPlanObj[PlanNr].Stand == 3)
          {
            int saCount = this.SACount;
            for (int index = 1; index <= saCount; ++index)
            {
              if (this.IsAreaNeighbour(index, this.GetAreaNr(this.TPlanObj[PlanNr].FromArea)) && this.GetFriendlyAreaNeighbours(index, false) == this.SAObj[index].NeighbourCount)
              {
                ++tid1;
                int x = this.SAObj[index].X;
                int y = this.SAObj[index].Y;
                int tweight = (int) Math.Round((double) ((float) this.SAObj[index].fuzzyvp * this.game.Data.RuleVar[151]));
                if (tweight < 0)
                  tweight = 0;
                SL.Add(tid1, tweight, x, y, (int) Math.Round((double) this.game.Data.RuleVar[152]));
              }
            }
          }
        }
        else if (this.TPlanObj[PlanNr].Type == 40)
        {
          int num;
          tid1 = num + 1;
          int tweight = (int) Math.Round((double) (this.game.Data.RuleVar[151] * (float) this.TPlanObj[PlanNr].FromArea.fuzzyvp));
          if (tweight < 0)
            tweight = 0;
          SL.Add(tid1, tweight, this.TPlanObj[PlanNr].FromArea.X, this.TPlanObj[PlanNr].FromArea.Y, 2000);
        }
      }
      int counter1 = SL.Counter;
      for (int Number2 = 0; Number2 <= counter1; ++Number2)
        this.AddLog("FLAG " + Conversion.Str((object) Number2) + ": hex(" + Conversion.Str((object) SL.Data1[Number2]) + "," + Conversion.Str((object) SL.Data2[Number2]) + "), Weight=" + Conversion.Str((object) SL.Weight[Number2]) + ", Data4=" + Conversion.Str((object) SL.Data4[Number2]));
      int num23 = 1;
      SimpleList simpleList1 = new SimpleList();
      if (SL.Counter > -1)
      {
        while (num23 == 1)
        {
          num23 = 0;
          if (Number1 > SL.Counter + 1)
          {
            SL.Sort();
            Expression = this.ClosestFriendlyHex(SL.Data1[SL.Counter], SL.Data2[SL.Counter], ref SL);
            if (!Expression.onmap)
            {
              Expression = this.ClosestUnFriendlyHex(SL.Data1[SL.Counter], SL.Data2[SL.Counter], ref SL);
              if (!Expression.onmap)
              {
                Expression.x = SL.Data1[SL.Counter];
                Expression.y = SL.Data2[SL.Counter];
                Expression.onmap = true;
              }
            }
            int tweight = (int) Math.Round(Conversion.Int((double) SL.Weight[SL.Counter] / 6.0));
            int[] weight = SL.Weight;
            int[] numArray = weight;
            int counter2 = SL.Counter;
            int index = counter2;
            int num24 = weight[counter2] - tweight;
            numArray[index] = num24;
            ++tid1;
            SL.Add(tid1, tweight, Expression.x, Expression.y, this.Matrix1[Expression.x, Expression.y]);
            num23 = 1;
          }
          else if (Number1 < SL.Counter + 1 & SL.Counter > 0)
          {
            SimpleList simpleList2 = new SimpleList();
            int tid3 = 0;
            int counter3 = SL.Counter;
            for (int tdata1 = 0; tdata1 <= counter3; ++tdata1)
            {
              int counter4 = SL.Counter;
              for (int tdata2 = 0; tdata2 <= counter4; ++tdata2)
              {
                if (tdata1 != tdata2)
                {
                  int num25 = this.game.HandyFunctionsObj.Distance(SL.Data1[tdata1], SL.Data2[tdata1], 0, SL.Data1[tdata2], SL.Data2[tdata2], 0);
                  ++tid3;
                  if (num25 == 0)
                    num25 = 1;
                  int tweight = (int) Math.Round((double) num25 * Math.Sqrt((double) SL.Weight[tdata1]) * Math.Sqrt((double) SL.Weight[tdata2]));
                  simpleList2.Add(tid3, tweight, tdata1, tdata2);
                }
              }
            }
            simpleList2.Sort();
            if (SL.Weight[simpleList2.Data1[0]] + SL.Data4[simpleList2.Data1[0]] * 5000 > SL.Weight[simpleList2.Data2[0]] + SL.Data4[simpleList2.Data2[0]] * 5000)
            {
              this.AddLog("Join flag " + Conversion.Str((object) simpleList2.Data2[0]) + " with flag " + Conversion.Str((object) simpleList2.Data1[0]));
              int[] weight = SL.Weight;
              int[] numArray1 = weight;
              int[] data1 = simpleList2.Data1;
              int[] numArray2 = data1;
              int index24 = 0;
              int index25 = index24;
              int index26 = numArray2[index25];
              int num26 = weight[data1[index24]] + SL.Weight[simpleList2.Data2[0]];
              numArray1[index26] = num26;
              SL.Remove(SL.Id[simpleList2.Data2[0]]);
            }
            else
            {
              this.AddLog("Join flag " + Conversion.Str((object) simpleList2.Data1[0]) + " with flag " + Conversion.Str((object) simpleList2.Data2[0]));
              int[] weight = SL.Weight;
              int[] numArray3 = weight;
              int[] data2 = simpleList2.Data2;
              int[] numArray4 = data2;
              int index27 = 0;
              int index28 = index27;
              int index29 = numArray4[index28];
              int num27 = weight[data2[index27]] + SL.Weight[simpleList2.Data1[0]];
              numArray3[index29] = num27;
              SL.Remove(SL.Id[simpleList2.Data1[0]]);
            }
            num23 = 1;
          }
        }
        if (this.TPlanObj[PlanNr].Type == 20 & (double) this.game.Data.RuleVar[225] > 0.0 & this.TPlanObj[PlanNr].Stand == 1)
        {
          int num28;
          if ((double) this.game.Data.RuleVar[225] == 1.0)
            num28 = (int) Math.Round((double) SL.Counter * 0.5);
          if ((double) this.game.Data.RuleVar[225] == 2.0)
            num28 = (int) Math.Round((double) SL.Counter * 0.8);
          if (num28 == 0)
            num28 = 1;
          if (num28 >= SL.Counter + 1)
            num28 = SL.Counter - 1;
          if (num28 > 0)
          {
            SimpleList simpleList3 = new SimpleList();
            int tid4 = 0;
            int counter5 = SL.Counter;
            for (int index = 0; index <= counter5; ++index)
            {
              int num29 = (int) Math.Round(Math.Pow((double) this.game.HandyFunctionsObj.Distance(SL.Data1[index], SL.Data2[index], 0, this.TPlanObj[PlanNr].FromArea.X, this.TPlanObj[PlanNr].FromArea.Y, 0), 1.5));
              if (num29 == 0)
                num29 = 1;
              int tweight = (int) Math.Round((double) SL.Weight[index] / (double) num29);
              ++tid4;
              if (tweight == 0)
                tweight = 1;
              if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[SL.Data1[index], SL.Data2[index]].Regime, this.game.Data.Turn) | this.game.Data.MapObj[0].HexObj[SL.Data1[index], SL.Data2[index]].Regime == -1)
                tweight *= num29;
              if (SL.Data4[index] == 1)
                tweight += 1000;
              if (SL.Data4[index] == 2)
                tweight -= 1000;
              simpleList3.Add(tid4, tweight, SL.Id[index]);
            }
            simpleList3.Sort();
            int num30 = num28 - 1;
            for (int index = 0; index <= num30; ++index)
            {
              if (index >= 0)
                SL.Remove(simpleList3.Data1[index]);
            }
          }
          int num31 = 1;
          while (num31 == 1)
          {
            num31 = 0;
            if (Number1 > SL.Counter + 1)
            {
              SL.Sort();
              Expression.x = SL.Data1[SL.Counter];
              Expression.y = SL.Data2[SL.Counter];
              Expression.onmap = true;
              int tweight = (int) Math.Round(Conversion.Int((double) SL.Weight[SL.Counter] / 3.0));
              int[] weight = SL.Weight;
              int[] numArray = weight;
              int counter6 = SL.Counter;
              int index = counter6;
              int num32 = weight[counter6] - tweight;
              numArray[index] = num32;
              ++tid1;
              SL.Add(tid1, tweight, Expression.x, Expression.y, this.Matrix1[Expression.x, Expression.y]);
              num31 = 1;
            }
          }
        }
        SL.Sort();
        int counter7 = SL.Counter;
        for (int Number3 = 0; Number3 <= counter7; ++Number3)
          this.AddLog("FLAG.. " + Conversion.Str((object) Number3) + ": hex(" + Conversion.Str((object) SL.Data1[Number3]) + "," + Conversion.Str((object) SL.Data2[Number3]) + "), Weight=" + Conversion.Str((object) SL.Weight[Number3]));
        object[,] objArray2 = new object[SL.Counter + 1, UL.Counter + 1];
        int counter8 = UL.Counter;
        for (int index = 0; index <= counter8; ++index)
        {
          if (!(this.TPlanObj[PlanNr].Type == 20 & this.game.Data.UnitObj[UL.Id[index]].IsHQ) && !(this.TPlanObj[PlanNr].Type == 30 & this.game.Data.UnitObj[UL.Id[index]].IsHQ) && this.game.Data.UnitObj[UL.Id[index]].AICutoff == 0 & !(this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 4 | this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 3) && !(this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 5 | this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 10) && !(this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 9 | this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 8) && this.game.Data.UnitObj[UL.Id[index]].X != -1 & !this.game.Data.UnitObj[UL.Id[index]].AIReserve & !this.game.Data.UnitObj[UL.Id[index]].AIDisband)
          {
            this.game.HandyFunctionsObj.MakeMovePrediction(UL.Id[index], this.game.Data.UnitObj[UL.Id[index]].X, this.game.Data.UnitObj[UL.Id[index]].Y, 0, attack: true, increaseap: 200);
            int counter9 = SL.Counter;
            for (int Number4 = 0; Number4 <= counter9; ++Number4)
            {
              int Number5 = (int) Math.Round((double) ((float) this.game.EditObj.TempValue[0].Value[SL.Data1[Number4], SL.Data2[Number4]] * this.GetEntrenchMod(UL.Id[index])));
              if (Number5 < 9999)
                Number5 = (int) Math.Round((double) Number5 * (Math.Pow((double) this.GetTerrainMovePathMod(UL.Id[index], SL.Data1[Number4], SL.Data2[Number4]), 2.0) / 1.0));
              int num33 = 0;
              if (Number5 < 9999)
                num33 = (int) Math.Round(Math.Sqrt(Math.Sqrt((double) this.game.HandyFunctionsObj.GetPowerPtsAbsolute(UL.Id[index]))));
              if (num33 >= 1)
                Number5 = (int) Math.Round(Conversion.Int((double) Number5 / (double) num33));
              objArray2[Number4, index] = (object) Number5;
              this.AddLog(this.game.Data.UnitObj[UL.Id[index]].Name + " => flag " + Conversion.Str((object) Number4) + " = " + Conversion.Str((object) Number5));
            }
            Application.DoEvents();
          }
        }
        for (int counter10 = SL.Counter; counter10 >= 0; counter10 += -1)
        {
          int num34 = 9999;
          int index30 = -1;
          int counter11 = UL.Counter;
          for (int index31 = 0; index31 <= counter11; ++index31)
          {
            if (!(this.TPlanObj[PlanNr].Type == 20 & this.game.Data.UnitObj[UL.Id[index31]].IsHQ) && !(this.TPlanObj[PlanNr].Type == 30 & this.game.Data.UnitObj[UL.Id[counter10]].IsHQ) && this.game.Data.UnitObj[UL.Id[index31]].AICutoff == 0 & !(this.game.Data.UnitObj[UL.Id[index31]].AIUnitGoal == 4 | this.game.Data.UnitObj[UL.Id[index31]].AIUnitGoal == 3) && !(this.game.Data.UnitObj[UL.Id[index31]].AIUnitGoal == 5 | this.game.Data.UnitObj[UL.Id[index31]].AIUnitGoal == 10) && !(this.game.Data.UnitObj[UL.Id[index31]].AIUnitGoal == 9 | this.game.Data.UnitObj[UL.Id[index31]].AIUnitGoal == 8) && this.game.Data.UnitObj[UL.Id[index31]].X != -1 & !this.game.Data.UnitObj[UL.Id[index31]].AIReserve & !this.game.Data.UnitObj[UL.Id[index31]].AIDisband && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectLess(objArray2[counter10, index31], (object) num34, false), (object) (UL.Data1[index31] == -1))))
            {
              num34 = Conversions.ToInteger(objArray2[counter10, index31]);
              index30 = index31;
              this.AddLog(this.game.Data.UnitObj[UL.Id[index31]].Name + " => ASSIGNED TO flag " + Conversion.Str((object) counter10) + " with temphigh = " + Conversion.Str((object) num34));
            }
          }
          if (index30 > -1)
            UL.Data1[index30] = counter10;
        }
        int counter12 = UL.Counter;
        for (int index = 0; index <= counter12; ++index)
        {
          int num35 = 9999;
          int num36 = -1;
          if (UL.Data1[index] == -1)
          {
            for (int counter13 = SL.Counter; counter13 >= 0; counter13 += -1)
            {
              if (!(this.TPlanObj[PlanNr].Type == 20 & this.game.Data.UnitObj[UL.Id[index]].IsHQ) && !(this.TPlanObj[PlanNr].Type == 30 & this.game.Data.UnitObj[UL.Id[counter13]].IsHQ) && this.game.Data.UnitObj[UL.Id[index]].AICutoff == 0 & !(this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 4 | this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 3) && !(this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 5 | this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 10) && !(this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 9 | this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 8) && this.game.Data.UnitObj[UL.Id[index]].X != -1 & !this.game.Data.UnitObj[UL.Id[index]].AIReserve & !this.game.Data.UnitObj[UL.Id[index]].AIDisband && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectLess(objArray2[counter13, index], (object) num35, false), (object) (UL.Data1[index] == -1))))
              {
                this.AddLog(this.game.Data.UnitObj[UL.Id[index]].Name + " => (LAST DITCH ASSIGN) ASSIGNED TO flag " + Conversion.Str((object) counter13) + " with temphigh = " + Conversion.Str((object) num35));
                num35 = Conversions.ToInteger(objArray2[counter13, index]);
                num36 = counter13;
              }
            }
            if (num36 > -1)
              UL.Data1[index] = num36;
          }
        }
        int counter14 = UL.Counter;
        for (int index = 0; index <= counter14; ++index)
        {
          int Number6 = 9999;
          int num37 = -1;
          if (UL.Data1[index] == -1)
          {
            for (int counter15 = SL.Counter; counter15 >= 0; counter15 += -1)
            {
              if (!(this.TPlanObj[PlanNr].Type == 20 & this.game.Data.UnitObj[UL.Id[index]].IsHQ) && !(this.TPlanObj[PlanNr].Type == 30 & this.game.Data.UnitObj[UL.Id[counter15]].IsHQ) && this.game.Data.UnitObj[UL.Id[index]].AICutoff == 0 & !(this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 4 | this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 3) && !(this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 5 | this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 10) && !(this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 9 | this.game.Data.UnitObj[UL.Id[index]].AIUnitGoal == 8) && this.game.Data.UnitObj[UL.Id[index]].X != -1 & !this.game.Data.UnitObj[UL.Id[index]].AIReserve & !this.game.Data.UnitObj[UL.Id[index]].AIDisband && UL.Data1[index] == -1)
              {
                this.AddLog(this.game.Data.UnitObj[UL.Id[index]].Name + " => (REALLY LAST DITCH ASSIGN) ASSIGNED TO flag " + Conversion.Str((object) counter15) + " with temphigh = " + Conversion.Str((object) Number6));
                Conversions.ToInteger(objArray2[counter15, index]);
                num37 = counter15;
                break;
              }
            }
            if (num37 > -1)
              UL.Data1[index] = num37;
          }
        }
      }
      if (this.TPlanObj[PlanNr].Type == 20 | this.TPlanObj[PlanNr].Type == 40 | this.TPlanObj[PlanNr].Type == 30 | this.TPlanObj[PlanNr].Type == 50)
      {
        int counter16 = UL.Counter;
        for (int index32 = 0; index32 <= counter16; ++index32)
        {
          if (UL.Data1[index32] == -1 & this.game.Data.UnitObj[UL.Id[index32]].X != -1)
          {
            int index33 = UL.Id[index32];
            if (this.game.Data.UnitObj[index33].IsHQ)
            {
              int num38 = UL.Data1[index32];
              Expression = this.SetMatrixHQ(UL, index33);
              if (Expression.onmap)
              {
                ++tid1;
                SL.Add(tid1, 100, Expression.x, Expression.y, this.Matrix2[Expression.x, Expression.y]);
                this.AddLog("HQ FLAG ADDED to (" + Conversion.Str((object) Expression.x) + "," + Conversion.Str((object) Expression.y) + ")");
                UL.Data1[index32] = SL.Counter;
              }
            }
            else if (this.game.Data.UnitObj[index33].AIDisband)
            {
              int index34 = this.HexSA[this.game.Data.UnitObj[index33].X, this.game.Data.UnitObj[index33].Y];
              if (index34 > 0)
              {
                int landReservePlan = this.SAObj[index34].LandReservePlan;
                if (landReservePlan > 0)
                {
                  if (this.TPlanObj[landReservePlan].HQ > -1)
                  {
                    Expression = new Coordinate();
                    Expression.x = this.game.Data.UnitObj[this.TPlanObj[landReservePlan].HQ].X;
                    Expression.y = this.game.Data.UnitObj[this.TPlanObj[landReservePlan].HQ].Y;
                    ++tid1;
                    SL.Add(tid1, 100, Expression.x, Expression.y, 100);
                    UL.Data1[index32] = SL.Counter;
                    this.AddLog("DISBAND UNIT FLAG ADDED..  to (" + Conversion.Str((object) Expression.x) + "," + Conversion.Str((object) Expression.y) + ")");
                  }
                  else
                    this.game.Data.UnitObj[index33].AIReserve = true;
                }
                else
                  this.game.Data.UnitObj[index33].AIReserve = true;
              }
              else
                this.game.Data.UnitObj[index33].AIReserve = true;
            }
            else if (this.game.Data.UnitObj[index33].AIReserve)
            {
              int resnr;
              ++resnr;
              Expression = this.GetReserveCoord(PlanNr, resnr);
              if (Expression.onmap)
              {
                ++tid1;
                SL.Add(tid1, 100, Expression.x, Expression.y, 100);
                this.AddLog("RESERVE UNIT FLAG ADDED..  to (" + Conversion.Str((object) Expression.x) + "," + Conversion.Str((object) Expression.y) + ")");
                UL.Data1[index32] = SL.Counter;
              }
              else
              {
                ++tid1;
                SL.Add(tid1, 100, this.TPlanObj[PlanNr].FromArea.X, this.TPlanObj[PlanNr].FromArea.Y, 100);
                this.AddLog("RESERVE UNIT FLAG ADDED..  to  (" + Conversion.Str((object) this.TPlanObj[PlanNr].FromArea.X) + "," + Conversion.Str((object) this.TPlanObj[PlanNr].FromArea.Y) + ")");
                UL.Data1[index32] = SL.Counter;
              }
            }
            else if (this.game.Data.UnitObj[index33].AICutoff > 0)
            {
              Expression = this.GetEscapeCoord(this.game.Data.UnitObj[index33].X, this.game.Data.UnitObj[index33].Y, this.GetAreaNr(this.TPlanObj[PlanNr].FromArea));
              if (Expression.onmap)
              {
                ++tid1;
                SL.Add(tid1, 100, Expression.x, Expression.y, 100);
                this.AddLog("CUTTEN OFF UNIT FLAG ADDED.. (WE SEE ESCAPE OPTION) to (" + Conversion.Str((object) Expression.x) + "," + Conversion.Str((object) Expression.y) + ")");
                UL.Data1[index32] = SL.Counter;
              }
              else
              {
                ++tid1;
                SL.Add(tid1, 100, this.TPlanObj[PlanNr].FromArea.X, this.TPlanObj[PlanNr].FromArea.Y, 100);
                this.AddLog("CUTTEN OFF UNIT FLAG ADDED to (" + Conversion.Str((object) this.TPlanObj[PlanNr].FromArea.X) + "," + Conversion.Str((object) this.TPlanObj[PlanNr].FromArea.Y) + ")");
                UL.Data1[index32] = SL.Counter;
              }
            }
            else if (this.game.Data.UnitObj[index33].AIUnitGoal == 4)
            {
              int engcount;
              ++engcount;
              Expression = this.GetEngineerCoord(engcount, PlanNr);
              if (Expression.onmap)
              {
                ++tid1;
                SL.Add(tid1, 100, Expression.x, Expression.y, 100);
                this.AddLog("ENGINEER UNIT FLAG ADDED..  to (" + Conversion.Str((object) Expression.x) + "," + Conversion.Str((object) Expression.y) + ")");
                UL.Data1[index32] = SL.Counter;
              }
              else
              {
                ++tid1;
                SL.Add(tid1, 100, this.TPlanObj[PlanNr].FromArea.X, this.TPlanObj[PlanNr].FromArea.Y, 100);
                this.AddLog("ENGINEER UNIT FLAG ADDED to (" + Conversion.Str((object) this.TPlanObj[PlanNr].FromArea.X) + "," + Conversion.Str((object) this.TPlanObj[PlanNr].FromArea.Y) + ")");
                UL.Data1[index32] = SL.Counter;
              }
            }
            else if (this.game.Data.UnitObj[index33].AIUnitGoal == 9 | this.game.Data.UnitObj[index33].AIUnitGoal == 10 | this.game.Data.UnitObj[index33].AIUnitGoal == 8)
            {
              Expression = this.GetNavalWarCoord(index33, PlanNr);
              if (Expression.onmap)
              {
                ++tid1;
                SL.Add(tid1, 100, Expression.x, Expression.y, 100);
                this.AddLog("NAVAL UNIT FLAG ADDED..  to (" + Conversion.Str((object) Expression.x) + "," + Conversion.Str((object) Expression.y) + ")");
                UL.Data1[index32] = SL.Counter;
              }
              else
              {
                ++tid1;
                SL.Add(tid1, 100, this.TPlanObj[PlanNr].FromArea.X, this.TPlanObj[PlanNr].FromArea.Y, 100);
                this.AddLog("NAVAL UNIT FLAG ADDED to (" + Conversion.Str((object) this.TPlanObj[PlanNr].FromArea.X) + "," + Conversion.Str((object) this.TPlanObj[PlanNr].FromArea.Y) + ")");
                UL.Data1[index32] = SL.Counter;
              }
            }
            else if (this.game.Data.UnitObj[index33].AIUnitGoal == 5)
            {
              Expression = this.GetAirSupportCoord(index33, PlanNr);
              if (Expression.onmap)
              {
                ++tid1;
                SL.Add(tid1, 100, Expression.x, Expression.y, 100);
                this.AddLog("AIRSUPPORT UNIT FLAG ADDED..  to (" + Conversion.Str((object) Expression.x) + "," + Conversion.Str((object) Expression.y) + ")");
                UL.Data1[index32] = SL.Counter;
              }
              else
              {
                ++tid1;
                SL.Add(tid1, 100, this.TPlanObj[PlanNr].FromArea.X, this.TPlanObj[PlanNr].FromArea.Y, 100);
                this.AddLog("AIRSUPPORT UNIT FLAG ADDED to (" + Conversion.Str((object) this.TPlanObj[PlanNr].FromArea.X) + "," + Conversion.Str((object) this.TPlanObj[PlanNr].FromArea.Y) + ")");
                UL.Data1[index32] = SL.Counter;
              }
            }
            else if (this.game.Data.UnitObj[index33].AIUnitGoal == 3)
            {
              Expression = this.GetArtilleryCoord(index33, PlanNr);
              if (MovePhaseNr < 2 & this.TPlanObj[PlanNr].Stand == 1)
              {
                Expression.x = this.game.Data.UnitObj[index33].X;
                Expression.y = this.game.Data.UnitObj[index33].Y;
                Expression.onmap = true;
              }
              if (this.TPlanObj[PlanNr].Stand == 3)
              {
                Expression.x = this.TPlanObj[PlanNr].TooArea.X;
                Expression.y = this.TPlanObj[PlanNr].TooArea.Y;
                Expression.onmap = true;
              }
              if (Expression.onmap)
              {
                ++tid1;
                SL.Add(tid1, 100, Expression.x, Expression.y, 100);
                this.AddLog("ARTILLERY UNIT FLAG ADDED..  to (" + Conversion.Str((object) Expression.x) + "," + Conversion.Str((object) Expression.y) + ")");
                UL.Data1[index32] = SL.Counter;
              }
              else
              {
                ++tid1;
                SL.Add(tid1, 100, this.TPlanObj[PlanNr].FromArea.X, this.TPlanObj[PlanNr].FromArea.Y, 100);
                this.AddLog("ARTILLERY UNIT FLAG ADDED to (" + Conversion.Str((object) this.TPlanObj[PlanNr].FromArea.X) + "," + Conversion.Str((object) this.TPlanObj[PlanNr].FromArea.Y) + ")");
                UL.Data1[index32] = SL.Counter;
              }
            }
          }
        }
      }
      int counter17 = UL.Counter;
      for (int index = 0; index <= counter17; ++index)
      {
        if (UL.Data1[index] > -1)
          this.AddLog("UNIT " + this.game.Data.UnitObj[UL.Id[index]].Name + " --> flag(" + Conversion.Str((object) SL.Data1[UL.Data1[index]]) + "," + Conversion.Str((object) SL.Data2[UL.Data1[index]]) + ")");
        else
          this.AddLog("UNIT " + this.game.Data.UnitObj[UL.Id[index]].Name + " --> NO FLAG!! ");
      }
      this.AddLog("");
      this.AddLog("Unit Movements:");
      for (int counter18 = UL.Counter; counter18 >= 0; counter18 += -1)
      {
        if (UL.Data1[counter18] > -1 & this.game.Data.UnitObj[UL.Id[counter18]].X != -1)
        {
          int index35 = UL.Id[counter18];
          int num39 = 0;
          int num40 = 1;
          if (MovePhaseNr == 1 & (double) this.game.Data.RuleVar[225] > 0.0 && !(this.game.Data.UnitObj[index35].AIUnitGoal == 3 | this.game.Data.UnitObj[index35].AIUnitGoal == 4) && !(this.game.Data.UnitObj[index35].AIUnitGoal == 5 | this.game.Data.UnitObj[index35].AIUnitGoal == 10) && !(this.game.Data.UnitObj[index35].AIUnitGoal == 9 | this.game.Data.UnitObj[index35].AIUnitGoal == 8) && this.game.Data.UnitObj[UL.Id[counter18]].X != -1 & !this.game.Data.UnitObj[UL.Id[counter18]].AIReserve & !this.game.Data.UnitObj[UL.Id[counter18]].AIDisband && this.TPlanObj[PlanNr].Type == 20)
          {
            int tfacing = 1;
            do
            {
              Expression = this.game.HandyFunctionsObj.HexNeighbour(this.game.Data.UnitObj[index35].X, this.game.Data.UnitObj[index35].Y, 0, tfacing);
              if (Expression.onmap && this.game.Data.MapObj[0].HexObj[Expression.x, Expression.y].Regime > -1 && this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[Expression.x, Expression.y].Regime) && this.game.Data.MapObj[0].HexObj[Expression.x, Expression.y].UnitCounter > -1)
                num40 = 0;
              ++tfacing;
            }
            while (tfacing <= 6);
          }
          if (num40 == 1)
          {
            int num41 = !Information.IsNothing((object) this.TPlanObj[PlanNr].TooArea) ? this.game.HandyFunctionsObj.Distance(this.TPlanObj[PlanNr].FromArea.X, this.TPlanObj[PlanNr].FromArea.Y, 0, this.TPlanObj[PlanNr].TooArea.X, this.TPlanObj[PlanNr].TooArea.Y, 0) : 15;
            if (num41 < 10)
              num41 = 10;
            int MaxDist = num41 * 2;
            if (this.game.Data.UnitObj[index35].AIUnitGoal == 5)
              this.SetMatrix1(SL.Data1[UL.Data1[counter18]], SL.Data2[UL.Data1[counter18]]);
            else if (this.game.Data.UnitObj[index35].AIUnitGoal == 9 | this.game.Data.UnitObj[index35].AIUnitGoal == 10 | this.game.Data.UnitObj[index35].AIUnitGoal == 8)
              this.SetNavalMatrix1(SL.Data1[UL.Data1[counter18]], SL.Data2[UL.Data1[counter18]]);
            else if (this.game.Data.UnitObj[index35].AIPlanNr > 0)
            {
              if (this.GetAreaNr(this.TPlanObj[this.game.Data.UnitObj[index35].AIPlanNr].FromArea) == this.HexSA[this.game.Data.UnitObj[index35].X, this.game.Data.UnitObj[index35].Y])
              {
                if (this.TPlanObj[this.game.Data.UnitObj[index35].AIPlanNr].Type == 40 | this.TPlanObj[this.game.Data.UnitObj[index35].AIPlanNr].Type == 30)
                  this.SetMatrix1(SL.Data1[UL.Data1[counter18]], SL.Data2[UL.Data1[counter18]], unitnr: index35, onlyinplanarea: true, hq: this.game.Data.UnitObj[index35].HQ, MaxDist: MaxDist);
                else if (this.TPlanObj[this.game.Data.UnitObj[index35].AIPlanNr].FromArea.ConstitutantCount > 0)
                  this.SetMatrix1(SL.Data1[UL.Data1[counter18]], SL.Data2[UL.Data1[counter18]], true, index35, true, MaxDist: MaxDist);
                else
                  this.SetMatrix1(SL.Data1[UL.Data1[counter18]], SL.Data2[UL.Data1[counter18]], true, index35, true, hq: this.game.Data.UnitObj[index35].HQ, MaxDist: MaxDist);
              }
              else
                this.SetMatrix1(SL.Data1[UL.Data1[counter18]], SL.Data2[UL.Data1[counter18]], MaxDist: MaxDist);
            }
            else
              this.SetMatrix1(SL.Data1[UL.Data1[counter18]], SL.Data2[UL.Data1[counter18]], MaxDist: MaxDist);
            if (this.game.Data.UnitObj[index35].AIUnitGoal == 5)
            {
              this.game.HandyFunctionsObj.MakeMovePrediction(index35, this.game.Data.UnitObj[index35].X, this.game.Data.UnitObj[index35].Y, 0, ismove: true);
            }
            else
            {
              int gothroughenemy = (int) Math.Round((double) ((float) this.game.HandyFunctionsObj.GetPower(index35, this.game.Data.Turn) / (2f * this.game.Data.RegimeObj[this.game.Data.Turn].AIConservative)));
              this.game.HandyFunctionsObj.MakeMovePrediction(index35, this.game.Data.UnitObj[index35].X, this.game.Data.UnitObj[index35].Y, 0, increaseap: 250, ismove: true, gothroughenemy: gothroughenemy);
            }
            OrderResult orderResult = (OrderResult) null;
            int index36;
            int index37;
            if (this.game.EditObj.TempValue[0].Value[SL.Data1[UL.Data1[counter18]], SL.Data2[UL.Data1[counter18]]] >= 9999)
            {
              int mapWidth = this.game.Data.MapObj[0].MapWidth;
              for (int index38 = 0; index38 <= mapWidth; ++index38)
              {
                int mapHeight = this.game.Data.MapObj[0].MapHeight;
                for (int index39 = 0; index39 <= mapHeight; ++index39)
                {
                  if (this.game.EditObj.TempValue[0].Value[index38, index39] <= this.game.HandyFunctionsObj.GetLowestAp(index35) && this.Matrix1[index38, index39] > num39)
                  {
                    index36 = index38;
                    index37 = index39;
                    num39 = this.Matrix1[index38, index39];
                  }
                }
              }
              if (num39 > 0)
              {
                if ((double) this.game.Data.RuleVar[253] == 1.0 & !this.game.HandyFunctionsObj.HasUnitNavySF(index35) & !this.game.HandyFunctionsObj.HasUnitAirSF(index35))
                {
                  if (this.game.Data.MapObj[0].HexObj[SL.Data1[UL.Data1[counter18]], SL.Data2[UL.Data1[counter18]]].UnitCounter <= 14 & this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[SL.Data1[UL.Data1[counter18]], SL.Data2[UL.Data1[counter18]]].Regime, this.game.Data.Turn))
                  {
                    orderResult = (OrderResult) this.game.ProcessingObj.DoStrategicTransfer(-1, index35, 0, SL.Data1[UL.Data1[counter18]], SL.Data2[UL.Data1[counter18]], 0);
                    index36 = SL.Data1[UL.Data1[counter18]];
                    index37 = SL.Data2[UL.Data1[counter18]];
                    string s = this.game.Data.UnitObj[index35].Name + " strategicly transfers to " + Conversion.Str((object) index36) + "," + Conversion.Str((object) index37);
                    this.UnitMovePhase[index35] = MovePhaseNr;
                    this.AddLog(s);
                  }
                }
                else if (!(this.game.Data.MapObj[0].HexObj[index36, index37].UnitCounter > 14 & this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[index36, index37].Regime, this.game.Data.Turn)))
                {
                  orderResult = this.game.ProcessingObj.ExecuteMovement(index35, this.game.Data.UnitObj[index35].X, this.game.Data.UnitObj[index35].Y, 0, index36, index37, 0);
                  string s = this.game.Data.UnitObj[index35].Name + " moves to " + Conversion.Str((object) index36) + "," + Conversion.Str((object) index37);
                  this.UnitMovePhase[index35] = MovePhaseNr;
                  this.AddLog(s);
                }
              }
            }
            else
            {
              int num42 = 0;
              int num43 = 0;
              index36 = SL.Data1[UL.Data1[counter18]];
              index37 = SL.Data2[UL.Data1[counter18]];
              if (!(index36 == this.game.Data.UnitObj[index35].X & index37 == this.game.Data.UnitObj[index35].Y))
              {
                while (num42 == 0)
                {
                  if (this.game.EditObj.TempValue[0].Value[index36, index37] <= this.game.HandyFunctionsObj.GetLowestAp(index35))
                  {
                    num43 = 1;
                    break;
                  }
                  Expression = this.game.EditObj.TempCameFrom[0].Value[index36, index37];
                  if (!Information.IsNothing((object) Expression) && Expression.onmap)
                  {
                    index36 = Expression.x;
                    index37 = Expression.y;
                  }
                  else
                    break;
                }
              }
              else
                num43 = 0;
              if (num43 > 0 & !(this.game.Data.MapObj[0].HexObj[index36, index37].UnitCounter > 14 & this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[index36, index37].Regime, this.game.Data.Turn)))
              {
                orderResult = this.game.ProcessingObj.ExecuteMovement(index35, this.game.Data.UnitObj[index35].X, this.game.Data.UnitObj[index35].Y, 0, index36, index37, 0);
                string s = this.game.Data.UnitObj[index35].Name + " moves to " + Conversion.Str((object) index36) + "," + Conversion.Str((object) index37);
                this.UnitMovePhase[index35] = MovePhaseNr;
                this.AddLog(s);
              }
            }
          }
          else
            this.AddLog(this.game.Data.UnitObj[index35].Name + " stays on spot in this move phase due to possible enemy target near.");
        }
      }
      this.CratesCheck();
    }

    public float GetTerrainMovePathMod(int unr, int x, int y)
    {
      int num1 = 1;
      int num2 = 0;
      int sfCount1 = this.game.Data.UnitObj[unr].SFCount;
      for (int index = 0; index <= sfCount1; ++index)
      {
        int type = this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index]].Type;
        int qty = this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index]].Qty;
        int landscapeType = this.game.Data.MapObj[0].HexObj[x, y].LandscapeType;
        num2 += this.game.Data.SFTypeObj[type].PowerPts * qty;
      }
      int num3 = 0;
      float num4;
      while (num1 == 1)
      {
        num1 = 0;
        ++num3;
        int sfCount2 = this.game.Data.UnitObj[unr].SFCount;
        for (int index = 0; index <= sfCount2; ++index)
        {
          int type = this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index]].Type;
          int qty = this.game.Data.SFObj[this.game.Data.UnitObj[unr].SFList[index]].Qty;
          int landscapeType = this.game.Data.MapObj[0].HexObj[x, y].LandscapeType;
          int num5 = this.game.Data.SFTypeObj[type].PowerPts * qty;
          num4 += (float) (((double) this.game.Data.SFTypeObj[type].CombatModAtt[landscapeType] + (double) this.game.Data.SFTypeObj[type].CombatModDef[landscapeType]) / 2.0 * ((double) num5 / (double) num2));
        }
        Coordinate coordinate = this.game.EditObj.TempCameFrom[0].Value[x, y];
        if (coordinate.onmap)
        {
          x = coordinate.x;
          y = coordinate.y;
          num1 = 1;
        }
      }
      return num4 / (float) num3;
    }

    public void ExecuteLandFrontAttacks(int plannr, float advneed)
    {
      object[,] objArray = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      float num1 = 2f;
      do
      {
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index1 = 0; index1 <= mapWidth; ++index1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index2 = 0; index2 <= mapHeight; ++index2)
          {
            if (this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter > -1 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType].IsSea && this.HexSA[index1, index2] == this.GetAreaNr(this.TPlanObj[plannr].TooArea) && this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[index1, index2].Regime) & this.game.Data.MapObj[0].HexObj[index1, index2].get_SeeNow(this.game.Data.Turn) > 0)
            {
              int Number1 = this.GetHexForceLandStrength(index1, index2);
              if (Number1 == 0)
                Number1 = 1;
              SimpleList simpleList = new SimpleList();
              int num2 = 0;
              int num3 = 0;
              int num4 = this.game.Data.MapObj[0].HexObj[index1, index2].get_BattleStack(this.game.Data.Turn);
              this.game.EditObj.TempUnitList = new UnitList();
              this.game.EditObj.OrderX = index1;
              this.game.EditObj.OrderY = index2;
              int tfacing = 1;
              do
              {
                Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(index1, index2, 0, tfacing);
                if (coordinate.onmap && this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime, this.game.Data.Turn) & !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                {
                  int unitCounter = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitCounter;
                  for (int index3 = 0; index3 <= unitCounter; ++index3)
                  {
                    int unit = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitList[index3];
                    if (this.game.HandyFunctionsObj.MoveApCostPreview(unit, this.game.Data.UnitObj[unit].X, this.game.Data.UnitObj[unit].Y, this.game.Data.UnitObj[unit].X, this.game.Data.UnitObj[unit].Y, 0, index1, index2, 0, true).x <= this.game.HandyFunctionsObj.GetLowestAp(unit))
                    {
                      if ((double) this.game.Data.RuleVar[30] > (double) num4)
                      {
                        int num5 = this.GetForceLandStrength(unit, asattack: true, attackx: index1, attacky: index2);
                        if (this.TPlanObj[plannr].Stand == 2)
                          num5 = (int) Math.Round((double) ((float) num5 * (1f / this.GetEntrenchMod(unit))));
                        int tweight = (int) Math.Round((double) num5 * (Math.Pow((double) this.game.HandyFunctionsObj.GetAverageRdn(unit), 2.0) / 10000.0));
                        num2 += tweight;
                        num3 += tweight;
                        num4 += this.game.HandyFunctionsObj.GetUnitStackPts(unit);
                        simpleList.Add(unit, tweight);
                        this.game.EditObj.TempUnitList.add(unit);
                      }
                      else
                      {
                        int num6 = this.GetForceLandStrength(unit, asattack: true, attackx: index1, attacky: index2);
                        if (this.TPlanObj[plannr].Stand == 2)
                          num6 = (int) Math.Round((double) ((float) num6 * (1f / this.GetEntrenchMod(unit))));
                        int num7 = (int) Math.Round((double) num6 * (Math.Pow((double) this.game.HandyFunctionsObj.GetAverageRdn(unit), 2.0) / 10000.0));
                        num3 += num7;
                      }
                    }
                  }
                }
                ++tfacing;
              }
              while (tfacing <= 6);
              if (num2 > 0)
              {
                float concentricBonus2 = this.game.HandyFunctionsObj.GetConcentricBonus2();
                if ((double) concentricBonus2 >= (double) num1)
                {
                  int Number2 = (int) Math.Round((double) ((float) num2 * concentricBonus2));
                  if ((double) this.game.HandyFunctionsObj.GetHexStackPts(index1, index2, 0) > (double) this.game.Data.RuleVar[30] * 1.5)
                  {
                    float num8 = this.game.Data.RuleVar[30] * 1.5f / (float) this.game.HandyFunctionsObj.GetHexStackPts(index1, index2, 0);
                    if ((double) num8 > 1.0)
                      num8 = 1f;
                    Number1 = (int) Math.Round((double) Conversion.Int((float) Number1 * num8));
                  }
                  if (num3 > Number2 & Number2 > 0)
                    Number2 = (int) Math.Round((double) Number2 * ((double) num3 / (double) Number2));
                  if ((double) Number2 / (double) Number1 >= (double) advneed)
                  {
                    this.game.TempCombat = new CombatClass(this.game);
                    Coordinate Target = new Coordinate();
                    Target.x = index1;
                    Target.y = index2;
                    this.game.EditObj.TempUnitList = new UnitList();
                    this.AddLog("* Battle versus " + Conversion.Str((object) index1) + "," + Conversion.Str((object) index2) + " with " + Conversion.Str((object) Number2) + " vs " + Conversion.Str((object) Number1) + " force.");
                    int counter = simpleList.Counter;
                    for (int index4 = 0; index4 <= counter; ++index4)
                      this.game.EditObj.TempUnitList.add(simpleList.Id[index4]);
                    this.game.TempCombat.Init(Target, 1, this.game.EditObj.TempUnitList, 2);
                    this.game.TempCombat.DoBattle();
                    this.game.TempCombat.EndBattle();
                    this.game.TempCombat = (CombatClass) null;
                  }
                }
              }
            }
          }
        }
        num1 += -0.5f;
      }
      while ((double) num1 >= 0.0);
    }

    public void ExecuteNavalAttacks(int plannr, float advneed)
    {
      object[,] objArray = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter > -1 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType].IsSea | this.game.HandyFunctionsObj.IsHexPort(index1, index2, 0) && this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.UnitObj[this.game.Data.MapObj[0].HexObj[index1, index2].UnitList[0]].Regime) & this.game.Data.MapObj[0].HexObj[index1, index2].get_SeeNow(this.game.Data.Turn) > 0)
          {
            int Number1 = this.GetHexForceLandStrength(index1, index2);
            if (Number1 == 0)
              Number1 = 1;
            SimpleList simpleList = new SimpleList();
            int num1 = 0;
            this.game.EditObj.TempUnitList = new UnitList();
            this.game.EditObj.OrderX = index1;
            this.game.EditObj.OrderY = index2;
            int tfacing = 1;
            do
            {
              Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(index1, index2, 0, tfacing);
              if (coordinate.onmap && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitCounter > -1 & this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea && this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitList[0]].Regime, this.game.Data.Turn))
              {
                int unitCounter = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitCounter;
                for (int index3 = 0; index3 <= unitCounter; ++index3)
                {
                  int unit = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitList[index3];
                  if (this.game.Data.UnitObj[unit].AIPlanNr == plannr && this.game.HandyFunctionsObj.MoveApCostPreview(unit, this.game.Data.UnitObj[unit].X, this.game.Data.UnitObj[unit].Y, this.game.Data.UnitObj[unit].X, this.game.Data.UnitObj[unit].Y, this.game.Data.UnitObj[unit].X, this.game.Data.UnitObj[unit].Y, 0, index1, (uint) index2 > 0U, IgnoreBridges: true).x <= this.game.HandyFunctionsObj.GetLowestAp(unit))
                  {
                    num1 += this.GetForceNavalStrength(unit, asattack: true, attackx: index1, attacky: index2);
                    simpleList.Add(unit, this.GetForceNavalStrength(unit, asattack: true, attackx: index1, attacky: index2));
                    this.game.EditObj.TempUnitList.add(unit);
                  }
                }
              }
              ++tfacing;
            }
            while (tfacing <= 6);
            if (num1 > 0)
            {
              int Number2 = (int) Math.Round((double) ((float) num1 * this.game.HandyFunctionsObj.GetConcentricBonus2()));
              if ((double) this.game.HandyFunctionsObj.GetHexStackPts(index1, index2, 0) > (double) this.game.Data.RuleVar[30])
              {
                float num2 = this.game.Data.RuleVar[30] / (float) this.game.HandyFunctionsObj.GetHexStackPts(index1, index2, 0);
                if ((double) num2 > 1.0)
                  num2 = 1f;
                Number1 = (int) Math.Round((double) Conversion.Int((float) Number1 * num2));
              }
              if ((double) Number2 / (double) Number1 >= (double) advneed & Number2 > 0)
              {
                this.game.TempCombat = new CombatClass(this.game);
                Coordinate Target = new Coordinate();
                Target.x = index1;
                Target.y = index2;
                this.game.EditObj.TempUnitList = new UnitList();
                this.AddLog("* Nav Battle versus " + Conversion.Str((object) index1) + "," + Conversion.Str((object) index2) + " with " + Conversion.Str((object) Number2) + " vs " + Conversion.Str((object) Number1) + " force.");
                int counter = simpleList.Counter;
                for (int index4 = 0; index4 <= counter; ++index4)
                  this.game.EditObj.TempUnitList.add(simpleList.Id[index4]);
                this.game.TempCombat.Init(Target, 1, this.game.EditObj.TempUnitList, 12);
                this.game.TempCombat.DoBattle();
                this.game.TempCombat.EndBattle();
                this.game.TempCombat = (CombatClass) null;
              }
            }
          }
        }
      }
    }

    public void ExecuteAirAttack(int plannr, float advneed)
    {
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray2 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray3 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray4 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray5 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,,] numArray6 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 11];
      if (this.TPlanObj[plannr].FriendlyAir < 1)
        return;
      this.AddLog("AirAttacks for plannr: " + Conversion.Str((object) plannr));
      int index1 = -1;
      int index2 = 0;
      do
      {
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index3 = 0; index3 <= mapWidth; ++index3)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index4 = 0; index4 <= mapHeight; ++index4)
            numArray6[index3, index4, index2] = -1;
        }
        ++index2;
      }
      while (index2 <= 10);
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter1; ++unr)
      {
        if (this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & this.game.Data.UnitObj[unr].X > -1 && this.game.Data.UnitObj[unr].AIPlanNr == plannr && this.game.Data.UnitObj[unr].AIUnitGoal == 5 && this.GetRolePercent(unr, 13) > 0 | this.GetRolePercent(unr, 14) > 0)
        {
          this.game.HandyFunctionsObj.MakeMovePrediction(unr, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0, false, PredictAirOnly: true, attack: true);
          ++index1;
          if (index1 <= 10)
          {
            int mapWidth = this.game.Data.MapObj[0].MapWidth;
            for (int index5 = 0; index5 <= mapWidth; ++index5)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index6 = 0; index6 <= mapHeight; ++index6)
              {
                if (this.game.EditObj.TempValue[0].Value[index5, index6] < this.game.HandyFunctionsObj.GetLowestAirAp(unr) && this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[index5, index6].Regime) & this.game.Data.MapObj[0].HexObj[index5, index6].get_SeeNow(this.game.Data.Turn) > 0 && this.game.Data.MapObj[0].HexObj[index5, index6].UnitCounter > -1 && this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.UnitObj[this.game.Data.MapObj[0].HexObj[index5, index6].UnitList[0]].Regime))
                {
                  int[,] numArray7 = numArray1;
                  int[,] numArray8 = numArray7;
                  int index7 = index5;
                  int index8 = index7;
                  int index9 = index6;
                  int index10 = index9;
                  int num1 = numArray7[index7, index9] + this.GetForceAirStrength(unr, asattack: true, attackx: index5, attacky: index6);
                  numArray8[index8, index10] = num1;
                  int[,] numArray9 = numArray2;
                  int[,] numArray10 = numArray9;
                  int index11 = index5;
                  int index12 = index11;
                  int index13 = index6;
                  int index14 = index13;
                  int num2 = numArray9[index11, index13] + this.GetForceAirStrength(unr);
                  numArray10[index12, index14] = num2;
                  numArray6[index5, index6, index1] = unr;
                  int[,] numArray11 = numArray3;
                  int[,] numArray12 = numArray11;
                  int index15 = index5;
                  int index16 = index15;
                  int index17 = index6;
                  int index18 = index17;
                  int num3 = numArray11[index15, index17] + 1;
                  numArray12[index16, index18] = num3;
                  numArray4[index5, index6] = this.GetHexForceLandStrength(index5, index6);
                }
              }
            }
          }
        }
      }
      int unitCounter2 = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter2; ++unr)
      {
        if (this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].Regime != this.game.Data.Turn & this.game.Data.UnitObj[unr].X > -1 && this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].RegimeRel[this.game.Data.Turn] == 0 && this.game.HandyFunctionsObj.HasUnitAirSF(unr) && this.GetRolePercent(unr, 13) > 0)
        {
          this.game.HandyFunctionsObj.MakeMovePrediction(unr, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0, false, PredictAirOnly: true, attack: true);
          int mapWidth = this.game.Data.MapObj[0].MapWidth;
          for (int index19 = 0; index19 <= mapWidth; ++index19)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index20 = 0; index20 <= mapHeight; ++index20)
            {
              if (this.game.EditObj.TempValue[0].Value[index19, index20] <= 50)
              {
                int[,] numArray13 = numArray5;
                int[,] numArray14 = numArray13;
                int index21 = index19;
                int index22 = index21;
                int index23 = index20;
                int index24 = index23;
                int num = numArray13[index21, index23] + this.game.HandyFunctionsObj.GetPowerPtsAbsoluteForAirOnly(unr);
                numArray14[index22, index24] = num;
              }
            }
          }
        }
      }
      int unitCounter3 = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter3; ++unr)
      {
        if (this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].Regime != this.game.Data.Turn & this.game.Data.UnitObj[unr].X > -1 && this.game.Data.RegimeObj[this.game.Data.UnitObj[unr].Regime].RegimeRel[this.game.Data.Turn] == 0)
        {
          int num4 = this.game.HandyFunctionsObj.HasUnitAA(unr);
          if (num4 > 0)
          {
            int x = this.game.Data.UnitObj[unr].X;
            int y = this.game.Data.UnitObj[unr].Y;
            int num5 = x - (num4 + 1);
            int num6 = x + (num4 + 1);
            for (int x1 = num5; x1 <= num6; ++x1)
            {
              int num7 = y - (num4 + 1);
              int num8 = y + (num4 + 1);
              for (int y1 = num7; y1 <= num8; ++y1)
              {
                if (x1 >= 0 & x1 <= this.game.Data.MapObj[0].MapWidth & y1 >= 0 & y1 <= this.game.Data.MapObj[0].MapHeight && this.game.HandyFunctionsObj.Distance(x1, y1, 0, x, y, 0) <= num4)
                {
                  int num9 = 0;
                  int index25 = unr;
                  int sfCount = this.game.Data.UnitObj[index25].SFCount;
                  for (int index26 = 0; index26 <= sfCount; ++index26)
                  {
                    int sf = this.game.Data.UnitObj[index25].SFList[index26];
                    int type = this.game.Data.SFObj[sf].Type;
                    int num10;
                    if (this.game.Data.SFTypeObj[type].AIRoleScore[12] > 0)
                      num10 = (int) Math.Round((double) (this.game.Data.SFTypeObj[type].PowerPts * this.game.Data.SFObj[sf].Qty) * ((double) this.game.Data.SFTypeObj[type].AIRoleScore[12] / 100.0));
                    num9 += num10;
                  }
                  int[,] numArray15 = numArray5;
                  int[,] numArray16 = numArray15;
                  int index27 = x1;
                  int index28 = index27;
                  int index29 = y1;
                  int index30 = index29;
                  int num11 = numArray15[index27, index29] + num9;
                  numArray16[index28, index30] = num11;
                }
              }
            }
          }
        }
      }
      if (index1 <= -1)
        return;
      int Number1 = -1;
      int Number2 = -1;
      int num12 = 0;
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index31 = 0; index31 <= mapWidth1; ++index31)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index32 = 0; index32 <= mapHeight; ++index32)
        {
          if (this.game.Data.MapObj[0].HexObj[index31, index32].UnitCounter > -1 && this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[this.game.Data.UnitObj[this.game.Data.MapObj[0].HexObj[index31, index32].UnitList[0]].Regime] == 0)
          {
            int num13 = (int) Math.Round((double) ((float) (numArray1[index31, index32] + numArray4[index31, index32]) + VBMath.Rnd() * (float) numArray4[index31, index32]));
            if ((double) this.game.Data.RuleVar[834] > 0.0)
            {
              if (this.game.Data.MapObj[0].HexObj[index31, index32].get_BattleStackAir(this.game.Data.Turn) > (int) Math.Round((double) this.game.Data.RuleVar[833] * 0.5))
                num13 = (int) Math.Round((double) num13 / 2.0);
              else if (this.game.Data.MapObj[0].HexObj[index31, index32].get_BattleStackAir(this.game.Data.Turn) > (int) Math.Round((double) (this.game.Data.RuleVar[833] * 1f)))
                num13 = (int) Math.Round((double) num13 / 4.0);
            }
            if (numArray5[index31, index32] * 3 > numArray2[index31, index32])
              num13 = (int) Math.Round((double) num13 - (double) numArray5[index31, index32] / 3.0);
            if (numArray5[index31, index32] > numArray2[index31, index32])
              num13 = 0;
            if (num13 > num12 & num13 > 0)
            {
              Number1 = index31;
              Number2 = index32;
              num12 = num13;
            }
          }
        }
      }
      if (!(Number1 > -1 & Number2 > -1))
        return;
      this.game.EditObj.TempUnitList = new UnitList();
      int index33 = 0;
      do
      {
        if (numArray6[Number1, Number2, index33] > -1)
          this.game.EditObj.TempUnitList.add(numArray6[Number1, Number2, index33]);
        ++index33;
      }
      while (index33 <= 10);
      this.game.TempCombat = new CombatClass(this.game);
      Coordinate Target = new Coordinate();
      Target.x = Number1;
      Target.y = Number2;
      this.AddLog("* AIR Battle versus " + Conversion.Str((object) Number1) + "," + Conversion.Str((object) Number2));
      this.game.TempCombat.Init(Target, 1, this.game.EditObj.TempUnitList, 14);
      this.game.TempCombat.DoBattle();
      this.game.TempCombat.EndBattle();
      this.game.TempCombat = (CombatClass) null;
    }

    public void ExecuteAirAttack_OLD(int plannr, float advneed)
    {
      object[,] objArray = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      if (this.TPlanObj[plannr].FriendlyAir < 1)
        return;
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter > -1 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType].IsSea && -(-1 < this.AreaDistance(this.HexSA[index1, index2], this.GetAreaNr(this.TPlanObj[plannr].FromArea)) ? 1 : 0) <= 2 && this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[index1, index2].Regime) & this.game.Data.MapObj[0].HexObj[index1, index2].get_SeeNow(this.game.Data.Turn) > 0)
          {
            int Number1 = this.GetHexForceLandStrength(index1, index2);
            if (Number1 == 0)
              Number1 = 1;
            SimpleList simpleList = new SimpleList();
            int Number2 = 0;
            this.game.EditObj.TempUnitList = new UnitList();
            this.game.EditObj.OrderX = index1;
            this.game.EditObj.OrderY = index2;
            int num1 = (int) Math.Round((double) ((float) index1 - this.game.Data.RuleVar[223]));
            int num2 = (int) Math.Round((double) ((float) index1 + this.game.Data.RuleVar[223]));
            for (int index3 = num1; index3 <= num2; ++index3)
            {
              Coordinate coordinate;
              coordinate.x = index3;
              if (this.game.Data.MapObj[0].MapLoop & coordinate.x < 0)
                coordinate.x = this.game.Data.MapObj[0].MapWidth + coordinate.x + 1;
              if (this.game.Data.MapObj[0].MapLoop & coordinate.x > this.game.Data.MapObj[0].MapWidth)
                coordinate.x = coordinate.x - this.game.Data.MapObj[0].MapWidth - 1;
              ref Coordinate local = ref coordinate;
              int num3 = (int) Math.Round((double) ((float) index2 - this.game.Data.RuleVar[223]));
              int num4 = (int) Math.Round((double) ((float) index2 + this.game.Data.RuleVar[223]));
              for (local.y = num3; coordinate.y <= num4; ++coordinate.y)
              {
                if (coordinate.x > -1 & coordinate.y > -1 && coordinate.x <= this.game.Data.MapObj[0].MapWidth & coordinate.y <= this.game.Data.MapObj[0].MapHeight && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime == this.game.Data.Turn & !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                {
                  int unitCounter = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitCounter;
                  for (int index4 = 0; index4 <= unitCounter; ++index4)
                  {
                    int unit = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitList[index4];
                    if (this.game.Data.UnitObj[unit].AIPlanNr == plannr && this.game.Data.UnitObj[unit].AIUnitGoal == 5)
                    {
                      this.game.HandyFunctionsObj.MakeMovePrediction(unit, this.game.Data.UnitObj[unit].X, this.game.Data.UnitObj[unit].Y, 0, false, PredictAirOnly: true, attack: true);
                      if (this.game.EditObj.TempValue[0].Value[index1, index2] <= this.game.HandyFunctionsObj.GetLowestAp(unit))
                      {
                        Number2 += this.GetForceLandStrength(unit, asattack: true, attackx: index1, attacky: index2);
                        simpleList.Add(unit, this.GetForceLandStrength(unit, asattack: true, attackx: index1, attacky: index2));
                        this.game.EditObj.TempUnitList.add(unit);
                      }
                    }
                  }
                }
              }
            }
            if (Number2 > 0)
            {
              this.game.TempCombat = new CombatClass(this.game);
              Coordinate Target = new Coordinate();
              Target.x = index1;
              Target.y = index2;
              this.game.EditObj.TempUnitList = new UnitList();
              this.AddLog("* Battle versus " + Conversion.Str((object) index1) + "," + Conversion.Str((object) index2) + " with " + Conversion.Str((object) Number2) + " vs " + Conversion.Str((object) Number1) + " force.");
              int counter = simpleList.Counter;
              for (int index5 = 0; index5 <= counter; ++index5)
                this.game.EditObj.TempUnitList.add(simpleList.Id[index5]);
              this.game.TempCombat.Init(Target, 1, this.game.EditObj.TempUnitList, 14);
              this.game.TempCombat.DoBattle();
              this.game.TempCombat.EndBattle();
              this.game.TempCombat = (CombatClass) null;
            }
          }
        }
      }
    }

    public void ExecuteArtilleryAttack(int plannr, float advneed, int phase)
    {
      object[,] objArray = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter > -1 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType].IsSea && this.HexSA[index1, index2] == this.GetAreaNr(this.TPlanObj[plannr].TooArea) && this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[index1, index2].Regime) & this.game.Data.MapObj[0].HexObj[index1, index2].get_SeeNow(this.game.Data.Turn) > 0)
          {
            int Number1 = this.GetHexForceLandStrength(index1, index2);
            if (Number1 == 0)
              Number1 = 1;
            SimpleList simpleList = new SimpleList();
            int Number2 = 0;
            int num1 = this.game.Data.MapObj[0].HexObj[index1, index2].get_BattleStackArt(this.game.Data.Turn);
            this.game.EditObj.TempUnitList = new UnitList();
            this.game.EditObj.OrderX = index1;
            this.game.EditObj.OrderY = index2;
            int num2 = index1 - 5;
            int num3 = index1 + 5;
            for (int index3 = num2; index3 <= num3; ++index3)
            {
              Coordinate coordinate1;
              coordinate1.x = index3;
              if (this.game.Data.MapObj[0].MapLoop & coordinate1.x < 0)
                coordinate1.x = this.game.Data.MapObj[0].MapWidth + coordinate1.x + 1;
              if (this.game.Data.MapObj[0].MapLoop & coordinate1.x > this.game.Data.MapObj[0].MapWidth)
                coordinate1.x = coordinate1.x - this.game.Data.MapObj[0].MapWidth - 1;
              ref Coordinate local = ref coordinate1;
              int num4 = index2 - 5;
              int num5 = index2 + 5;
              for (local.y = num4; coordinate1.y <= num5; ++coordinate1.y)
              {
                if (coordinate1.x > -1 & coordinate1.y > -1 && coordinate1.x <= this.game.Data.MapObj[0].MapWidth & coordinate1.y <= this.game.Data.MapObj[0].MapHeight && this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].Regime, this.game.Data.Turn) & !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].LandscapeType].IsSea)
                {
                  int unitCounter = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].UnitCounter;
                  for (int index4 = 0; index4 <= unitCounter; ++index4)
                  {
                    int unit = this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].UnitList[index4];
                    if (this.game.Data.UnitObj[unit].AIPlanNr == plannr & this.game.Data.UnitObj[unit].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unit].AIUnitGoal == 3 & this.game.HandyFunctionsObj.GetMaxArtRange(unit, 0) >= this.game.HandyFunctionsObj.Distance(coordinate1.x, coordinate1.y, 0, index1, index2, 0))
                    {
                      int num6 = 1;
                      int tfacing = 1;
                      do
                      {
                        Coordinate coordinate2 = this.game.HandyFunctionsObj.HexNeighbour(coordinate1.x, coordinate1.y, 0, tfacing);
                        if (coordinate2.onmap && this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].Regime) && this.GetHexForceLandStrength(coordinate2.x, coordinate2.y) > 0)
                        {
                          num6 = 0;
                          break;
                        }
                        ++tfacing;
                      }
                      while (tfacing <= 6);
                      if (phase == 2)
                        num6 = 1;
                      if (num6 == 1 && 10 <= this.game.HandyFunctionsObj.GetLowestAp(unit))
                      {
                        Number2 += this.GetForceLandStrength(unit, asattack: true, attackx: index1, attacky: index2);
                        num1 += this.game.HandyFunctionsObj.GetUnitStackPtsArt(unit);
                        if (phase > 1 | (double) num1 < (double) this.game.Data.RuleVar[834] | (double) this.game.Data.RuleVar[834] < 1.0)
                        {
                          simpleList.Add(unit, this.GetForceLandStrength(unit, asattack: true, attackx: index1, attacky: index2));
                          this.game.EditObj.TempUnitList.add(unit);
                        }
                      }
                    }
                  }
                }
              }
            }
            if (Number2 > 0 & simpleList.Counter > -1)
            {
              this.game.TempCombat = new CombatClass(this.game);
              Coordinate Target = new Coordinate();
              Target.x = index1;
              Target.y = index2;
              this.game.EditObj.TempUnitList = new UnitList();
              this.AddLog("* Battle versus " + Conversion.Str((object) index1) + "," + Conversion.Str((object) index2) + " with " + Conversion.Str((object) Number2) + " vs " + Conversion.Str((object) Number1) + " force.");
              int counter = simpleList.Counter;
              for (int index5 = 0; index5 <= counter; ++index5)
                this.game.EditObj.TempUnitList.add(simpleList.Id[index5]);
              this.game.TempCombat.Init(Target, 1, this.game.EditObj.TempUnitList, 11);
              this.game.TempCombat.DoBattle();
              this.game.TempCombat.EndBattle();
              this.game.TempCombat = (CombatClass) null;
            }
          }
        }
      }
    }

    public void InitDecisions()
    {
      int num1;
      do
      {
        int Number;
        ++Number;
        this.AddLog("INIT DECISION ROUND " + Conversion.Str((object) Number));
        num1 = 0;
        SimpleList simpleList = new SimpleList();
        int locTypeCounter = this.game.Data.LocTypeCounter;
        for (int index1 = 0; index1 <= locTypeCounter; ++index1)
        {
          if (this.game.Data.LocTypeObj[index1].AICanBuild)
          {
            int num2 = 1;
            int index2 = 0;
            do
            {
              if (this.game.Data.LocTypeObj[index1].VarType[index2] > -1 && this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[this.game.Data.LocTypeObj[index1].VarType[index2]] < this.game.Data.LocTypeObj[index1].VarQty[index2])
                num2 = 0;
              if (this.game.Data.LocTypeObj[index1].Research[index2] > -1 && !this.game.Data.RegimeObj[this.game.Data.Turn].ResField[this.game.Data.LocTypeObj[index1].Research[index2]])
                num2 = 0;
              ++index2;
            }
            while (index2 <= 4);
            if (num2 == 1)
            {
              this.game.EditObj.AreaX = -1;
              this.game.EditObj.AreaY = -1;
              Coordinate locationForLocType;
              if (this.game.Data.LocTypeObj[index1].AILocEvent > -1)
              {
                this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.LocTypeObj[index1].AILocEvent, index1);
                locationForLocType.x = this.game.EditObj.AreaX;
                locationForLocType.y = this.game.EditObj.AreaY;
              }
              else
                locationForLocType = this.AutoFindLocationForLocType(index1);
              if (locationForLocType.x > -1 && this.game.EditObj.TempValue[0].Value[locationForLocType.x, locationForLocType.y] == 1)
              {
                int aiPriority = this.game.Data.LocTypeObj[index1].AIPriority;
                if (this.game.Data.LocTypeObj[index1].AIEvent > -1)
                {
                  this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.LocTypeObj[index1].AIEvent, index1);
                  aiPriority += this.game.EditObj.AreaX;
                }
                if (aiPriority > 0)
                {
                  int tid;
                  ++tid;
                  simpleList.Add(tid, aiPriority, 1, index1, locationForLocType.x, locationForLocType.y);
                  num1 = 1;
                }
              }
            }
          }
        }
        simpleList.Sort();
        int counter = simpleList.Counter;
        for (int index = 0; index <= counter; ++index)
          this.AddLog(Conversion.Str((object) simpleList.Id[index]) + ", weight=" + Conversion.Str((object) simpleList.Weight[index]) + " data= " + Conversion.Str((object) simpleList.Data1[index]) + "," + Conversion.Str((object) simpleList.Data2[index]) + "," + Conversion.Str((object) simpleList.Data3[index]) + ",");
        if (simpleList.Counter > -1)
        {
          int num3 = simpleList.Data1[simpleList.Counter];
          int index = simpleList.Data2[simpleList.Counter];
          int num4 = simpleList.Data3[simpleList.Counter];
          int num5 = simpleList.Data4[simpleList.Counter];
          if (num3 == 1)
          {
            this.AddLog("CONSTRUCT====>build type " + this.game.Data.LocTypeObj[index].Name + " on hex " + Conversion.Str((object) num4) + "," + Conversion.Str((object) num5));
            this.game.ProcessingObj.Build(-1, num4, num5, 0, index, this.game.Data.Turn);
            if (this.game.Data.LocTypeObj[index].AIAfterBuildEvent > -1)
              this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.LocTypeObj[index].AIAfterBuildEvent, index);
          }
        }
      }
      while (num1 == 1);
    }

    public Coordinate AutoFindLocationForLocType(int loctyp)
    {
      int num1 = -1;
      int num2 = 9999999;
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.game.HandyFunctionsObj.RedimTempValue(0);
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int x = 0; x <= mapWidth1; ++x)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int y = 0; y <= mapHeight; ++y)
        {
          if (this.game.HandyFunctionsObj.HasHexRoad(x, y, 0) | (double) this.game.Data.RuleVar[864] < 1.0)
          {
            if (this.game.Data.MapObj[0].HexObj[x, y].Regime > -1)
              numArray[x, y] = !this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[x, y].Regime) ? (!this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[x, y].Regime) ? 6000 : (this.game.Data.Turn != this.game.Data.MapObj[0].HexObj[x, y].Regime ? 7500 : 0)) : 9000;
            else if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[x, y].LandscapeType].IsSea)
              numArray[x, y] = 6000;
          }
        }
      }
      int num3 = 1;
      int num4 = 0;
      Coordinate locationForLocType;
      while (num3 == 1 & num4 < 999)
      {
        ++num4;
        num3 = 0;
        int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
        for (int cx = 0; cx <= mapWidth2; ++cx)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int cy = 0; cy <= mapHeight; ++cy)
          {
            int tfacing = 1;
            do
            {
              locationForLocType = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
              if (locationForLocType.onmap && (double) numArray[locationForLocType.x, locationForLocType.y] < Conversion.Int((double) numArray[cx, cy] * 0.9))
              {
                numArray[locationForLocType.x, locationForLocType.y] = (int) Math.Round(Conversion.Int((double) numArray[cx, cy] * 0.9));
                num3 = 1;
              }
              ++tfacing;
            }
            while (tfacing <= 6);
          }
        }
      }
      int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
      int index1;
      int num5;
      for (index1 = 0; index1 <= mapWidth3; ++index1)
      {
        int mapHeight1 = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight1; ++index2)
        {
          int num6 = 0;
          if (this.game.Data.MapObj[0].HexObj[index1, index2].Regime == this.game.Data.Turn && this.game.Data.MapObj[0].HexObj[index1, index2].Location == -1)
          {
            int buildGround = this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType].BuildGround;
            if (this.game.Data.LocTypeObj[loctyp].BuildgroundType[buildGround] && this.game.HandyFunctionsObj.IsHexNextToSea(index1, index2, 0) | !this.game.Data.LocTypeObj[loctyp].IsPort && this.game.HandyFunctionsObj.HasHexRoad(index1, index2, 0) | (double) this.game.Data.RuleVar[864] < 1.0)
            {
              bool flag = true;
              int mapWidth4 = this.game.Data.MapObj[0].MapWidth;
              for (int x2 = 0; x2 <= mapWidth4; ++x2)
              {
                int mapHeight2 = this.game.Data.MapObj[0].MapHeight;
                for (int y2 = 0; y2 <= mapHeight2; ++y2)
                {
                  int location = this.game.Data.MapObj[0].HexObj[x2, y2].Location;
                  if (location > -1)
                  {
                    int locTypeGroup = this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].LocTypeGroup;
                    int num7 = this.game.HandyFunctionsObj.Distance(index1, index2, 0, x2, y2, 0);
                    if (this.game.Data.LocTypeObj[loctyp].MinDistance[locTypeGroup] > -1 && this.game.Data.LocTypeObj[loctyp].MinDistance[locTypeGroup] > num7)
                      flag = false;
                  }
                }
              }
              if (this.game.Data.LocTypeObj[loctyp].SlotType > -1 && this.game.Data.MapObj[0].HexObj[index1, index2].AreaCode[this.game.Data.LocTypeObj[loctyp].SlotType] != this.game.Data.LocTypeObj[loctyp].SlotValue)
                flag = false;
              if (flag)
              {
                num6 = 1;
                if (numArray[index1, index2] < num2)
                {
                  num2 = numArray[index1, index2];
                  num1 = index1;
                  num5 = index2;
                }
              }
            }
          }
          this.game.EditObj.TempValue[0].Value[index1, index2] = num6 != 1 ? 0 : 1;
        }
      }
      locationForLocType.x = num1;
      locationForLocType.y = num5;
      locationForLocType.map = 0;
      locationForLocType.onmap = true;
      if (index1 == -1)
      {
        locationForLocType.onmap = false;
        locationForLocType.y = -1;
      }
      return locationForLocType;
    }

    public void InitRandomAI()
    {
      if ((double) this.game.Data.RuleVar[248] < 1.0)
        return;
      Random random = new Random((int) Math.Round((double) this.game.Data.GameID / (double) ((1 + this.game.Data.Turn) * 10) + (double) (this.game.Data.Turn * 100)));
      float num1 = (float) random.Next(1, 100) / 100f;
      float num2 = (float) random.Next(1, 100) / 100f;
      float num3 = (float) random.Next(1, 100) / 100f;
      float num4 = (float) random.Next(1, 100) / 100f;
      float num5 = (float) random.Next(1, 100) / 100f;
      if ((double) num1 < 0.33)
      {
        this.game.Data.RegimeObj[this.game.Data.Turn].AIConservative = (float) ((double) num4 / 3.0 + 0.33);
        if ((double) this.game.Data.RuleVar[226] > 0.0)
          this.game.Data.RuleVar[226] = (float) (0.1 + (double) num3 / 5.0);
        if ((double) this.game.Data.RuleVar[501] == 1.0)
          this.game.Data.RuleVar[226] = 0.0f;
        this.game.Data.RuleVar[225] = 0.0f;
        this.AddLog("THIS IS AN OFFENSIVE AI");
      }
      else if ((double) num1 < 0.66)
      {
        this.game.Data.RegimeObj[this.game.Data.Turn].AIConservative = (float) ((double) num4 / 4.0 + 0.88);
        if ((double) this.game.Data.RuleVar[226] > 0.0)
          this.game.Data.RuleVar[226] = (float) (0.1 + (double) num3 / 4.0);
        if ((double) this.game.Data.RuleVar[501] == 1.0)
          this.game.Data.RuleVar[226] = 0.0f;
        this.game.Data.RuleVar[225] = 0.0f;
        this.AddLog("THIS IS A NORMAL AI");
      }
      else
      {
        this.game.Data.RegimeObj[this.game.Data.Turn].AIConservative = (float) ((double) num4 / 3.0 + 1.25);
        if ((double) this.game.Data.RuleVar[226] > 0.0)
          this.game.Data.RuleVar[226] = (float) (0.1 + (double) num3 / 3.0);
        if ((double) this.game.Data.RuleVar[501] == 1.0)
          this.game.Data.RuleVar[226] = 0.0f;
        this.game.Data.RuleVar[225] = 0.0f;
        this.AddLog("FRONTLINE FOCUS");
        this.AddLog("THIS IS A DEFENSIVE AI");
      }
      this.game.Data.RuleVar[224] = (float) (0.05 + (double) num5 / 6.0);
      this.AddLog("CONSERVATIVE = " + Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].AIConservative));
      this.AddLog("AIR TO LAND RATIO = " + Conversion.Str((object) this.game.Data.RuleVar[224]));
      this.AddLog("RESEARCH = " + Conversion.Str((object) this.game.Data.RuleVar[226]));
      this.AddLog("-------------------------");
    }

    public bool HasRegimeAir(int regnr)
    {
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].PreDef == -1 && this.game.Data.UnitObj[unr].Regime == regnr && this.game.HandyFunctionsObj.HasUnitAirSF(unr))
          return true;
      }
      return false;
    }

    public void InitStrategicHQAnalysis()
    {
      int[] numArray1 = new int[this.TPlanCount + 1];
      int[] numArray2 = new int[this.TPlanCount + 1];
      int[] numArray3 = new int[this.TPlanCount + 1];
      this.AddLog(" ");
      this.AddLog("STRATEGIC HQ ANALYSIS:");
      int tplanCount1 = this.TPlanCount;
      for (int index1 = 1; index1 <= tplanCount1; ++index1)
      {
        if (this.TPlanObj[index1].Type == 20 && this.SAObj[this.GetSANr(this.TPlanObj[index1].FromArea)].LandReservePlan > 0)
        {
          int landReservePlan = this.SAObj[this.GetSANr(this.TPlanObj[index1].FromArea)].LandReservePlan;
          int[] numArray4 = numArray1;
          int[] numArray5 = numArray4;
          int index2 = landReservePlan;
          int index3 = index2;
          int num1 = numArray4[index2] + this.TPlanObj[index1].WeightStrategic;
          numArray5[index3] = num1;
          int[] numArray6 = numArray2;
          int[] numArray7 = numArray6;
          int index4 = landReservePlan;
          int index5 = index4;
          int num2 = (int) Math.Round((double) ((float) numArray6[index4] + this.TPlanObj[index1].WeightFriendlyForce));
          numArray7[index5] = num2;
          int[] numArray8 = numArray3;
          int[] numArray9 = numArray8;
          int index6 = landReservePlan;
          int index7 = index6;
          int num3 = (int) Math.Round((double) ((float) numArray8[index6] + this.TPlanObj[index1].WeightEnemyForceUnMod));
          numArray9[index7] = num3;
        }
        if (this.TPlanObj[index1].Type == 40 && this.SAObj[this.GetSANr(this.TPlanObj[index1].FromArea)].LandReservePlan > 0)
        {
          if (this.TPlanObj[index1].SeaTarget > 0)
          {
            int landReservePlan = this.SAObj[this.GetSANr(this.TPlanObj[index1].FromArea)].LandReservePlan;
            int[] numArray10 = numArray1;
            int[] numArray11 = numArray10;
            int index8 = landReservePlan;
            int index9 = index8;
            int num4 = numArray10[index8] + this.TPlanObj[index1].WeightStrategic;
            numArray11[index9] = num4;
            int[] numArray12 = numArray2;
            int[] numArray13 = numArray12;
            int index10 = landReservePlan;
            int index11 = index10;
            int num5 = (int) Math.Round((double) ((float) numArray12[index10] + this.TPlanObj[index1].WeightFriendlyForce));
            numArray13[index11] = num5;
            int[] numArray14 = numArray3;
            int[] numArray15 = numArray14;
            int index12 = landReservePlan;
            int index13 = index12;
            int num6 = (int) Math.Round((double) ((float) numArray14[index12] + this.TPlanObj[index1].WeightEnemyForceUnMod));
            numArray15[index13] = num6;
            int[] numArray16 = numArray2;
            int[] numArray17 = numArray16;
            int index14 = landReservePlan;
            int index15 = index14;
            int num7 = numArray16[index14] + this.TPlanObj[index1].FriendlyNavy;
            numArray17[index15] = num7;
            int[] numArray18 = numArray3;
            int[] numArray19 = numArray18;
            int index16 = landReservePlan;
            int index17 = index16;
            int num8 = numArray18[index16] + this.TPlanObj[index1].EnemyNavy;
            numArray19[index17] = num8;
          }
          else
          {
            int landReservePlan = this.SAObj[this.GetSANr(this.TPlanObj[index1].FromArea)].LandReservePlan;
            int[] numArray20 = numArray1;
            int[] numArray21 = numArray20;
            int index18 = landReservePlan;
            int index19 = index18;
            int num9 = numArray20[index18] + this.TPlanObj[index1].WeightStrategic;
            numArray21[index19] = num9;
            int[] numArray22 = numArray2;
            int[] numArray23 = numArray22;
            int index20 = landReservePlan;
            int index21 = index20;
            int num10 = numArray22[index20] + this.TPlanObj[index1].FriendlyNavy;
            numArray23[index21] = num10;
            int[] numArray24 = numArray3;
            int[] numArray25 = numArray24;
            int index22 = landReservePlan;
            int index23 = index22;
            int num11 = numArray24[index22] + this.TPlanObj[index1].EnemyNavy;
            numArray25[index23] = num11;
          }
        }
      }
      int tplanCount2 = this.TPlanCount;
      for (int index24 = 1; index24 <= tplanCount2; ++index24)
      {
        if (this.TPlanObj[index24].Type == 30)
        {
          int num12 = numArray1[index24] * 10;
          if (numArray2[index24] == 0)
            numArray2[index24] = 1;
          int num13 = (int) Math.Round((double) num12 * ((double) numArray3[index24] / (double) numArray2[index24]));
          this.TPlanObj[index24].WeightStrategic = num13;
          AIPlanClass[] tplanObj = this.TPlanObj;
          AIPlanClass[] aiPlanClassArray = tplanObj;
          int index25 = index24;
          int index26 = index25;
          aiPlanClassArray[index26].WeightStrategic = tplanObj[index25].WeightStrategic + 100;
        }
      }
    }

    public void InitShowStats()
    {
      this.AddLog(" ");
      this.AddLog("PLAN STATS::");
      int tplanCount1 = this.TPlanCount;
      for (int Number = 1; Number <= tplanCount1; ++Number)
      {
        if (this.TPlanObj[Number].Type == 20 | this.TPlanObj[Number].Type == 50)
        {
          this.AddLog(" ");
          this.AddLog("*Plan " + Strings.Trim(Conversion.Str((object) Number)) + ": ");
          string str1 = "";
          if (this.TPlanObj[Number].Type == 20)
            str1 = "LANDFRONT";
          if (this.TPlanObj[Number].Type == 50)
            str1 = "OLD-LANDFRONT";
          this.AddLog(str1 + " from " + this.game.HandyFunctionsObj.GetHexName(this.TPlanObj[Number].FromArea.X, this.TPlanObj[Number].FromArea.Y, 0) + "(" + Strings.Trim(Conversion.Str((object) this.TPlanObj[Number].FromArea.X)) + "," + Strings.Trim(Conversion.Str((object) this.TPlanObj[Number].FromArea.Y)) + ")" + " to " + this.game.HandyFunctionsObj.GetHexName(this.TPlanObj[Number].TooArea.X, this.TPlanObj[Number].TooArea.Y, 0) + "(" + Strings.Trim(Conversion.Str((object) this.TPlanObj[Number].TooArea.X)) + "," + Strings.Trim(Conversion.Str((object) this.TPlanObj[Number].TooArea.Y)) + "" + ", strategic-weight: " + Conversion.Str((object) this.TPlanObj[Number].WeightStrategic));
          this.AddLog("Friendly Force = " + Conversion.Str((object) this.TPlanObj[Number].WeightFriendlyForce) + ", Enemy Force = " + Conversion.Str((object) this.TPlanObj[Number].WeightEnemyForce) + ", Enemy UnMod = " + Conversion.Str((object) this.TPlanObj[Number].WeightEnemyForceUnMod));
          string str2 = "Units: ";
          int unitCounter = this.game.Data.UnitCounter;
          for (int index = 0; index <= unitCounter; ++index)
          {
            if (this.game.Data.UnitObj[index].AIPlanNr == Number & this.game.Data.UnitObj[index].Regime == this.game.Data.Turn)
            {
              string str3 = str2 + this.game.Data.UnitObj[index].Name;
              if (this.game.Data.UnitObj[index].AIUnitGoal == 1)
                str3 += "(INF)";
              if (this.game.Data.UnitObj[index].AIUnitGoal == 2)
                str3 += "(ARM)";
              if (this.game.Data.UnitObj[index].AIUnitGoal == 3)
                str3 += "(ART)";
              if (this.game.Data.UnitObj[index].AIUnitGoal == 4)
                str3 += "(ENG)";
              if (this.game.Data.UnitObj[index].AIMobilize)
                str3 += "(MOB)";
              if (this.game.Data.UnitObj[index].AIReserve)
                str3 += "(RESRV)";
              str2 = str3 + ", ";
            }
          }
          this.AddLog(str2 + " (count: F=" + Conversion.Str((object) this.TPlanObj[Number].FriendlyUnitCount) + "/E=" + Conversion.Str((object) this.TPlanObj[Number].EnemyUnitCount) + ")");
          string s = "Stand: ";
          if (this.TPlanObj[Number].Stand == 1)
            s += "ATTACK";
          if (this.TPlanObj[Number].Stand == 2)
            s += "DEFEND";
          if (this.TPlanObj[Number].Stand == 3)
            s += "RETREAT";
          this.AddLog(s);
          if (this.TPlanObj[Number].RiverLine == 1)
            this.AddLog("RIVERLINE DEFEND PLAN");
          this.AddLog("CurrentApCost: " + Conversion.Str((object) this.TPlanObj[Number].CurrentAPCost) + ", PossibleApCost: " + Conversion.Str((object) this.TPlanObj[Number].PossibleAPCost) + ", AverageunitAPDistance =" + Conversion.Str((object) this.TPlanObj[Number].AverageUnitAPCost));
          string str4 = "HQ: ";
          this.AddLog(this.TPlanObj[Number].HQ != -1 ? str4 + this.game.Data.UnitObj[this.TPlanObj[Number].HQ].Name : str4 + "n/a");
        }
      }
      int tplanCount2 = this.TPlanCount;
      for (int index1 = 1; index1 <= tplanCount2; ++index1)
      {
        if (this.TPlanObj[index1].Type == 40)
        {
          this.AddLog(" ");
          this.AddLog("*Plan " + Strings.Trim(Conversion.Str((object) index1)) + ": ");
          this.AddLog("PLANBACK" + " from " + this.game.HandyFunctionsObj.GetHexName(this.TPlanObj[index1].FromArea.X, this.TPlanObj[index1].FromArea.Y, 0) + "(" + Strings.Trim(Conversion.Str((object) this.TPlanObj[index1].FromArea.X)) + "," + Strings.Trim(Conversion.Str((object) this.TPlanObj[index1].FromArea.Y)) + ")" + ", strategic-weight: " + Conversion.Str((object) this.TPlanObj[index1].WeightStrategic));
          this.AddLog("Friendly Force = " + Conversion.Str((object) this.TPlanObj[index1].WeightFriendlyForce) + ", Enemy Force = " + Conversion.Str((object) this.TPlanObj[index1].WeightEnemyForce) + ", Enemy UnMod = " + Conversion.Str((object) this.TPlanObj[index1].WeightEnemyForceUnMod));
          this.AddLog("Friendly Naval Force = " + Conversion.Str((object) this.TPlanObj[index1].FriendlyNavy) + ", Enemy Naval Force = " + Conversion.Str((object) this.TPlanObj[index1].EnemyNavy));
          string s = "Units: ";
          int unitCounter = this.game.Data.UnitCounter;
          for (int index2 = 0; index2 <= unitCounter; ++index2)
          {
            if (this.game.Data.UnitObj[index2].AIPlanNr == index1 & this.game.Data.UnitObj[index2].Regime == this.game.Data.Turn)
            {
              string str = s + this.game.Data.UnitObj[index2].Name;
              if (this.game.Data.UnitObj[index2].AIUnitGoal == 1)
                str += "(INF)";
              if (this.game.Data.UnitObj[index2].AIUnitGoal == 2)
                str += "(ARM)";
              if (this.game.Data.UnitObj[index2].AIUnitGoal == 3)
                str += "(ART)";
              if (this.game.Data.UnitObj[index2].AIUnitGoal == 4)
                str += "(ENG)";
              if (this.game.Data.UnitObj[index2].AIUnitGoal == 5)
                str += "(AIR)";
              if (this.game.Data.UnitObj[index2].AIUnitGoal == 9)
                str += "(NAVWAR)";
              if (this.game.Data.UnitObj[index2].AIUnitGoal == 8)
                str += "(CARGO)";
              if (this.game.Data.UnitObj[index2].AIUnitGoal == 10)
                str += "(RAIDER)";
              if (this.game.Data.UnitObj[index2].AIReserve)
                str += "(RESRV)";
              s = str + ", ";
            }
          }
          this.AddLog(s);
          if (this.TPlanObj[index1].SeaStand > 0)
          {
            if (this.TPlanObj[index1].SeaStand == 4)
              s = "Sea Stand: HOME";
            if (this.TPlanObj[index1].SeaStand == 5)
              s = "Sea Stand: RAID";
            if (this.TPlanObj[index1].SeaStand == 6)
              s = "Sea Stand: SEASUP";
            if (this.TPlanObj[index1].SeaStand == 7)
              s = "Sea Stand: AMPH";
          }
          else
            s = "No Sea Stand";
          this.AddLog(s);
          this.AddLog(this.TPlanObj[index1].SeaTarget <= 0 ? "No Sea Target" : "Sea Target is Area# " + Conversion.Str((object) this.TPlanObj[index1].SeaTarget));
          if (this.MakeNavyActive(index1))
            this.AddLog("Navy is ACTIVE");
          else
            this.AddLog("Navy is NOT active");
          if (this.TPlanObj[index1].AssemblyArea == 1)
            this.AddLog("ASSEMBLY AREA FOR DEFENSE IN DEPTH");
          this.AddLog("CurrentApCost: " + Conversion.Str((object) this.TPlanObj[index1].CurrentAPCost) + ", PossibleApCost: " + Conversion.Str((object) this.TPlanObj[index1].PossibleAPCost) + ", AverageunitAPDistance =" + Conversion.Str((object) this.TPlanObj[index1].AverageUnitAPCost));
          this.AddLog("CurrentBackRoad to Area: " + Conversion.Str((object) this.TPlanObj[index1].CurrentBackRoad));
          string str5 = "HQ: ";
          this.AddLog(this.TPlanObj[index1].HQ != -1 ? str5 + this.game.Data.UnitObj[this.TPlanObj[index1].HQ].Name : str5 + "n/a");
        }
      }
      this.AddLog("");
      this.AddLog("LANDRESERVE PLANS:");
      int tplanCount3 = this.TPlanCount;
      for (int Number1 = 1; Number1 <= tplanCount3; ++Number1)
      {
        if (this.TPlanObj[Number1].Type == 30)
        {
          this.AddLog(" ");
          this.AddLog("*Plan " + Strings.Trim(Conversion.Str((object) Number1)) + ": ");
          string str6 = "";
          if (this.TPlanObj[Number1].Type == 20)
            str6 = "LANDRESERVE";
          this.AddLog(str6 + " at " + this.game.HandyFunctionsObj.GetHexName(this.TPlanObj[Number1].FromArea.X, this.TPlanObj[Number1].FromArea.Y, 0) + "(" + Strings.Trim(Conversion.Str((object) this.TPlanObj[Number1].FromArea.X)) + "," + Strings.Trim(Conversion.Str((object) this.TPlanObj[Number1].FromArea.Y)) + ")");
          string str7 = "Units: ";
          int unitCounter = this.game.Data.UnitCounter;
          for (int index = 0; index <= unitCounter; ++index)
          {
            if (this.game.Data.UnitObj[index].AIPlanNr == Number1 & this.game.Data.UnitObj[index].Regime == this.game.Data.Turn)
              str7 = str7 + this.game.Data.UnitObj[index].Name + ", ";
          }
          this.AddLog(str7 + " (count=" + Conversion.Str((object) this.TPlanObj[Number1].FriendlyUnitCount) + ")");
          string s = "Areas: ";
          int saCount = this.SACount;
          for (int Number2 = 1; Number2 <= saCount; ++Number2)
          {
            if (this.SAObj[Number2].LandReservePlan == Number1)
              s = s + this.game.HandyFunctionsObj.GetHexName(this.SAObj[Number2].X, this.SAObj[Number2].Y, 0) + "(#" + Conversion.Str((object) Number2) + "), ";
          }
          this.AddLog(s);
          string str8 = "HQ: ";
          this.AddLog(this.TPlanObj[Number1].HQ != -1 ? str8 + this.game.Data.UnitObj[this.TPlanObj[Number1].HQ].Name : str8 + "n/a");
          this.AddLog("ProdPts Total: " + Conversion.Str((object) this.TPlanObj[Number1].ProdPts) + " , Strategic Weight: " + Conversion.Str((object) this.TPlanObj[Number1].WeightStrategic));
          this.AddLog("CurrentHighestApCost: " + Conversion.Str((object) this.TPlanObj[Number1].CurrentAPCost) + ", PossibleHighestApCost: " + Conversion.Str((object) this.TPlanObj[Number1].PossibleAPCost));
          this.AddLog("MetaChainNr: " + Conversion.Str((object) this.TPlanObj[Number1].MetaChainNr));
        }
      }
    }

    public int GetPlanEPPerTurn(int plannr)
    {
      int unitCounter = this.game.Data.UnitCounter;
      int integer;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].X > -1 && this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].AIPlanNr == plannr)
          integer = Conversions.ToInteger(Operators.AddObject((object) integer, this.GetEPPerTurn(unr)));
      }
      return integer;
    }

    public void InitUnitGoals(int specificunit = -1)
    {
      this.AddLog("");
      this.AddLog("Assign UnitGoals:");
      int num1 = -1;
      if (specificunit > -1)
        num1 = this.game.Data.UnitObj[specificunit].AIPlanNr;
      int tplanCount1 = this.TPlanCount;
      for (int index1 = 1; index1 <= tplanCount1; ++index1)
      {
        if (this.TPlanObj[index1].Type == 20 | this.TPlanObj[index1].Type == 40 & (index1 == num1 | num1 == -1))
        {
          this.PlanEngineerNeedScore(index1);
          int num2 = 0;
          int num3 = 0;
          int num4 = 0;
          int num5 = 0;
          int num6 = 0;
          int num7 = 0;
          int num8 = 0;
          int num9 = 0;
          int num10 = 0;
          int num11 = 0;
          int unitCounter1 = this.game.Data.UnitCounter;
          for (int index2 = 0; index2 <= unitCounter1; ++index2)
          {
            if (!this.game.Data.UnitObj[index2].IsHQ && this.game.Data.UnitObj[index2].AIPlanNr == index1 & this.game.Data.UnitObj[index2].Regime == this.game.Data.Turn)
            {
              if (this.game.Data.UnitObj[index2].AIUnitGoal > 0)
              {
                int aiUnitGoal = this.game.Data.UnitObj[index2].AIUnitGoal;
                if (aiUnitGoal == 1)
                {
                  ++num2;
                  ++num6;
                }
                if (aiUnitGoal == 2)
                {
                  ++num3;
                  ++num6;
                }
                if (aiUnitGoal == 3)
                {
                  ++num4;
                  ++num6;
                }
                if (aiUnitGoal == 4)
                {
                  ++num5;
                  ++num6;
                }
                if (aiUnitGoal == 10)
                {
                  ++num9;
                  ++num8;
                }
                if (aiUnitGoal == 9)
                {
                  ++num10;
                  ++num8;
                }
                if (aiUnitGoal == 8)
                {
                  ++num11;
                  ++num8;
                }
              }
              ++num7;
            }
          }
          if (num6 == 0)
            num6 = 1;
          if (num8 == 0)
            num8 = 1;
          int unitCounter2 = this.game.Data.UnitCounter;
          int num12;
          bool Number;
          string str;
          for (int unr = 0; unr <= unitCounter2; ++unr)
          {
            if (this.game.Data.Round == 1 | this.game.Data.UnitObj[unr].AIUnitGoal < 1 && !this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unr].AIUnitGoal == 0 && this.game.Data.UnitObj[unr].AIPlanNr == index1 & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && unr == specificunit | specificunit == -1)
            {
              num12 = -1;
              Number = false;
              if ((double) this.GetRolePercent(unr, 10) >= (double) this.game.Data.RuleVar[157] * 0.6)
              {
                ++num3;
                ++num6;
                num12 = 2;
                str = "ARMOUR";
                if (this.TPlanObj[index1].Stand == 1)
                {
                  if ((double) VBMath.Rnd() * 100.0 <= (double) this.game.Data.RuleVar[154])
                    Number = true;
                }
                else if ((double) VBMath.Rnd() * 100.0 <= (double) this.game.Data.RuleVar[153])
                  Number = true;
                if ((double) this.game.Data.RuleVar[164] == 1.0)
                  Number = true;
                if (!Number && Operators.ConditionalCompareObjectGreaterEqual((object) this.game.HandyFunctionsObj.GetUnitCarryCap(unr, 0), this.game.HandyFunctionsObj.GetUnitWeightWithoutLandCarryCap(unr), false))
                  Number = true;
              }
              else if (this.GetRolePercent(unr, 5) >= 50)
              {
                ++num5;
                ++num6;
                num12 = 4;
                str = "ENGINEER";
                if ((double) this.game.Data.RuleVar[214] == 1.0)
                  Number = true;
              }
              else if ((double) this.GetRolePercent(unr, 8) >= (double) this.game.Data.RuleVar[158] * 0.3)
              {
                ++num4;
                ++num6;
                num12 = 3;
                str = "ART";
                if (this.TPlanObj[index1].Stand == 1)
                {
                  if ((double) VBMath.Rnd() * 100.0 <= (double) this.game.Data.RuleVar[154])
                    Number = true;
                }
                else if ((double) VBMath.Rnd() * 100.0 <= (double) this.game.Data.RuleVar[153])
                  Number = true;
                if ((double) this.game.Data.RuleVar[165] == 1.0)
                  Number = true;
                if (!Number && Operators.ConditionalCompareObjectGreaterEqual((object) this.game.HandyFunctionsObj.GetUnitCarryCap(unr, 0), this.game.HandyFunctionsObj.GetUnitWeightWithoutLandCarryCap(unr), false))
                  Number = true;
              }
              else if ((double) this.GetRolePercent(unr, 6) >= (double) this.game.Data.RuleVar[156] * 0.8)
              {
                ++num2;
                ++num6;
                num12 = 1;
                str = "INF";
                if (this.TPlanObj[index1].Stand == 1)
                {
                  if ((double) VBMath.Rnd() * 100.0 <= (double) this.game.Data.RuleVar[154])
                    Number = true;
                }
                else if ((double) VBMath.Rnd() * 100.0 <= (double) this.game.Data.RuleVar[153])
                  Number = true;
                if (!Number && Operators.ConditionalCompareObjectGreaterEqual((object) this.game.HandyFunctionsObj.GetUnitCarryCap(unr, 0), this.game.HandyFunctionsObj.GetUnitWeightWithoutLandCarryCap(unr), false))
                  Number = true;
              }
              else if (this.GetRolePercent(unr, 17) > 0)
              {
                num12 = 8;
                str = "CARGO";
              }
              else if (this.GetRolePercent(unr, 19) > 30)
              {
                num12 = 10;
                str = "RAIDER";
              }
              else if (this.GetRolePercent(unr, 18) > 0)
              {
                num12 = 9;
                str = "NAVALWAR";
              }
              else if (this.game.HandyFunctionsObj.HasUnitAirSF(unr))
              {
                num12 = 5;
                str = "AIRSUPPORT";
                this.game.Data.UnitObj[unr].SOInterceptRdnStop = 75;
              }
              if (num12 > -1)
              {
                if (this.TPlanObj[index1].Type == 20 && this.game.Data.MapObj[0].HexObj[this.TPlanObj[index1].TooArea.X, this.TPlanObj[index1].TooArea.Y].Regime == -1 | (double) this.TPlanObj[index1].WeightFriendlyForce > (double) this.TPlanObj[index1].WeightEnemyForce * 4.0)
                  Number = true;
                this.game.Data.UnitObj[unr].AIUnitGoal = num12;
                this.game.Data.UnitObj[unr].AIMobilize = Number;
                this.AddLog("AFTER ANALYSE OF COMPOSITION Unit: " + this.game.Data.UnitObj[unr].Name + " has been assigned goal: " + str + ", mobilize=" + Conversion.Str((object) Number));
              }
            }
          }
          int unitCounter3 = this.game.Data.UnitCounter;
          for (int unr = 0; unr <= unitCounter3; ++unr)
          {
            if (specificunit == -1 | unr == specificunit)
            {
              if (!this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unr].AIUnitGoal == 0 && this.game.Data.UnitObj[unr].AIPlanNr == index1 & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn)
              {
                if (this.TPlanObj[index1].Type == 20)
                {
                  num12 = 1;
                  Number = false;
                  str = "INFANTRY";
                  if (this.TPlanObj[index1].Stand == 2)
                  {
                    if ((double) this.TPlanObj[index1].WeightEnemyForce < 5.0)
                    {
                      num12 = 2;
                      str = "ARMOUR";
                      ++num2;
                      ++num6;
                      Number = true;
                    }
                    else if ((double) (num2 * 100) / (double) num6 < (double) this.game.Data.RuleVar[162])
                    {
                      num12 = 1;
                      str = "INFANTRY ";
                      ++num2;
                      ++num6;
                      if ((double) VBMath.Rnd() * 100.0 <= (double) this.game.Data.RuleVar[153])
                        Number = true;
                    }
                    else if ((double) (num3 * 100) / (double) num6 < (double) this.game.Data.RuleVar[161] & 100.0 * (1.0 / (double) num7) <= (double) this.game.Data.RuleVar[161])
                    {
                      num12 = 2;
                      str = "ARMOUR";
                      ++num3;
                      ++num6;
                      if ((double) VBMath.Rnd() * 100.0 <= (double) this.game.Data.RuleVar[153])
                        Number = true;
                      if ((double) this.game.Data.RuleVar[164] == 1.0)
                        Number = true;
                    }
                    else if ((double) (num4 * 100) / (double) num6 < (double) this.game.Data.RuleVar[163] & 100.0 * (1.0 / (double) num7) <= (double) this.game.Data.RuleVar[163])
                    {
                      num12 = 3;
                      str = "ARTILLERY";
                      ++num4;
                      ++num6;
                      if ((double) VBMath.Rnd() * 100.0 <= (double) this.game.Data.RuleVar[153])
                        Number = true;
                      if ((double) this.game.Data.RuleVar[165] == 1.0)
                        Number = true;
                    }
                  }
                  else if (this.TPlanObj[index1].Stand == 1)
                  {
                    if ((double) (num3 * 100) / (double) num6 < (double) this.game.Data.RuleVar[171] & 100.0 * (1.0 / (double) num7) <= (double) this.game.Data.RuleVar[171])
                    {
                      num12 = 2;
                      str = "ARMOUR";
                      ++num3;
                      ++num6;
                      if ((double) VBMath.Rnd() * 100.0 <= (double) this.game.Data.RuleVar[154])
                        Number = true;
                      if ((double) this.game.Data.RuleVar[164] == 1.0)
                        Number = true;
                    }
                    else if ((double) (num2 * 100) / (double) num6 < (double) this.game.Data.RuleVar[172])
                    {
                      num12 = 1;
                      str = "INFANTRY";
                      ++num2;
                      ++num6;
                      if ((double) VBMath.Rnd() * 100.0 <= (double) this.game.Data.RuleVar[154])
                        Number = true;
                    }
                    else if ((double) (num4 * 100) / (double) num6 < (double) this.game.Data.RuleVar[173] & 100.0 * (1.0 / (double) num7) <= (double) this.game.Data.RuleVar[173])
                    {
                      num12 = 3;
                      str = "ARTILLERY";
                      ++num4;
                      ++num6;
                      if ((double) VBMath.Rnd() * 100.0 <= (double) this.game.Data.RuleVar[154])
                        Number = true;
                      if ((double) this.game.Data.RuleVar[165] == 1.0)
                        Number = true;
                    }
                  }
                }
                else if (this.TPlanObj[index1].Type == 40)
                {
                  bool flag = this.MakeNavyActive(index1);
                  if (!this.game.HandyFunctionsObj.HasUnitlandSF(unr) & !this.game.HandyFunctionsObj.HasUnitAirSF(unr) & flag & this.TPlanObj[index1].SeaStand == 5 & this.game.HandyFunctionsObj.IsHexHarbourOrSea(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0))
                  {
                    num12 = 9;
                    Number = false;
                    str = "NAVALWAR";
                    if ((double) (num11 * 100) / (double) num8 < (double) this.game.Data.RuleVar[232])
                    {
                      num12 = 8;
                      str = "CARGO";
                      ++num11;
                      ++num8;
                    }
                    else if ((double) (num10 * 100) / (double) num8 < (double) this.game.Data.RuleVar[231])
                    {
                      num12 = 9;
                      str = "NAVWAR";
                      ++num10;
                      ++num8;
                    }
                    else if ((double) (num9 * 100) / (double) num8 < (double) this.game.Data.RuleVar[230])
                    {
                      num12 = 10;
                      str = "RAIDER";
                      ++num9;
                      ++num8;
                    }
                  }
                  else if (!this.game.HandyFunctionsObj.HasUnitlandSF(unr) & !this.game.HandyFunctionsObj.HasUnitAirSF(unr) & flag & this.TPlanObj[index1].SeaStand == 6 & this.game.HandyFunctionsObj.IsHexHarbourOrSea(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0))
                  {
                    num12 = 9;
                    Number = false;
                    str = "NAVALWAR";
                    if ((double) (num11 * 100) / (double) num8 < (double) this.game.Data.RuleVar[235])
                    {
                      num12 = 8;
                      str = "CARGO";
                      ++num11;
                      ++num8;
                    }
                    else if ((double) (num10 * 100) / (double) num8 < (double) this.game.Data.RuleVar[234])
                    {
                      num12 = 9;
                      str = "NAVWAR";
                      ++num10;
                      ++num8;
                    }
                    else if ((double) (num9 * 100) / (double) num8 < (double) this.game.Data.RuleVar[233])
                    {
                      num12 = 10;
                      str = "RAIDER";
                      ++num9;
                      ++num8;
                    }
                  }
                  else if (!this.game.HandyFunctionsObj.HasUnitlandSF(unr) & !this.game.HandyFunctionsObj.HasUnitAirSF(unr) & flag & this.TPlanObj[index1].SeaStand == 7 & this.game.HandyFunctionsObj.IsHexHarbourOrSea(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0))
                  {
                    num12 = 8;
                    Number = false;
                    str = "NAVALWAR";
                    if ((double) (num11 * 100) / (double) num8 < (double) this.game.Data.RuleVar[238])
                    {
                      num12 = 8;
                      str = "CARGO";
                      ++num11;
                      ++num8;
                    }
                    else if ((double) (num10 * 100) / (double) num8 < (double) this.game.Data.RuleVar[237])
                    {
                      num12 = 9;
                      str = "NAVWAR";
                      ++num10;
                      ++num8;
                    }
                    else if ((double) (num9 * 100) / (double) num8 < (double) this.game.Data.RuleVar[236])
                    {
                      num12 = 10;
                      str = "RAIDER";
                      ++num9;
                      ++num8;
                    }
                    if (this.TPlanObj[index1].SeaTarget > 0 & this.TPlanObj[index1].SeaTarget <= this.SACount)
                    {
                      if (this.game.Data.MapObj[0].HexObj[this.SAObj[this.TPlanObj[index1].SeaTarget].X, this.SAObj[this.TPlanObj[index1].SeaTarget].Y].Regime == -1)
                      {
                        num12 = 8;
                        str = "CARGO";
                      }
                    }
                    else
                      this.TPlanObj[index1].SeaStand = 0;
                  }
                  else if (!this.game.HandyFunctionsObj.HasUnitlandSF(unr) & !this.game.HandyFunctionsObj.HasUnitAirSF(unr) & flag & this.TPlanObj[index1].SeaStand == 4 & this.game.HandyFunctionsObj.IsHexHarbourOrSea(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0))
                  {
                    num12 = 9;
                    Number = false;
                    str = "NAVALWAR";
                    if ((double) (num11 * 100) / (double) num8 < (double) this.game.Data.RuleVar[242])
                    {
                      num12 = 8;
                      str = "CARGO";
                      ++num11;
                      ++num8;
                    }
                    else if ((double) (num10 * 100) / (double) num8 < (double) this.game.Data.RuleVar[241])
                    {
                      num12 = 9;
                      str = "NAVWAR";
                      ++num10;
                      ++num8;
                    }
                    else if ((double) (num9 * 100) / (double) num8 < (double) this.game.Data.RuleVar[240])
                    {
                      num12 = 10;
                      str = "RAIDER";
                      ++num9;
                      ++num8;
                    }
                  }
                }
                this.game.Data.UnitObj[unr].AIUnitGoal = num12;
                this.game.Data.UnitObj[unr].AIMobilize = Number;
                this.AddLog("Unit: " + this.game.Data.UnitObj[unr].Name + " has been assigned goal: " + str + ", mobilize=" + Conversion.Str((object) Number));
              }
              if ((double) this.game.Data.RuleVar[211] > 0.0 & (double) this.game.Data.RuleVar[32] > -1.0 && !this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unr].AIPlanNr == index1 && this.game.Data.UnitObj[unr].AIUnitGoal != 4 && this.game.HandyFunctionsObj.GetUnitEP(unr) >= this.game.Data.RoadTypeObj[(int) Math.Round((double) this.game.Data.RuleVar[32])].EPCost && (double) this.GetRolePercent(unr, 5) > 1.0 + (double) VBMath.Rnd() * 100.0)
              {
                str = "ENGINEER";
                num12 = 4;
                this.game.Data.UnitObj[unr].AIUnitGoal = num12;
                ++num5;
                this.AddLog("Unit: " + this.game.Data.UnitObj[unr].Name + " has been re-assigned goal: " + str);
              }
              if ((double) this.game.Data.RuleVar[221] > 0.0 && !this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unr].AIPlanNr == index1 && this.TPlanObj[index1].Type == 40 && this.game.HandyFunctionsObj.HasUnitAirSF(unr) & !this.game.HandyFunctionsObj.HasUnitNavySF(unr) && this.game.Data.UnitObj[unr].AIUnitGoal != 5)
              {
                str = "AIRSUPPORT";
                num12 = 5;
                this.game.Data.UnitObj[unr].AIUnitGoal = num12;
                this.game.Data.UnitObj[unr].SOInterceptRdnStop = 75;
                this.AddLog("Unit: " + this.game.Data.UnitObj[unr].Name + " has been re-assigned goal: " + str);
              }
              if ((double) this.game.Data.RuleVar[227] > 0.0 && !this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unr].AIPlanNr == index1 && this.TPlanObj[index1].Type == 40 && this.MakeNavyActive(index1) && this.game.HandyFunctionsObj.HasUnitNavySF(unr) && !(this.game.Data.UnitObj[unr].AIUnitGoal == 10 | this.game.Data.UnitObj[unr].AIUnitGoal == 8 | this.game.Data.UnitObj[unr].AIUnitGoal == 9) && this.game.HandyFunctionsObj.IsHexHarbourOrSea(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0))
              {
                str = "GOALNAVALWAR";
                num12 = 9;
                this.game.Data.UnitObj[unr].AIUnitGoal = num12;
                this.AddLog("Unit: " + this.game.Data.UnitObj[unr].Name + " has been re-assigned goal: " + str);
              }
            }
          }
        }
        if ((this.TPlanObj[index1].Type == 20 | this.TPlanObj[index1].Type == 40) & num1 == -1)
        {
          int Number = this.PlanEngineerNeedScore(index1);
          int num13;
          if (this.TPlanObj[index1].Type == 20)
            num13 = (int) Math.Round((double) this.game.Data.RuleVar[216]);
          if (this.TPlanObj[index1].Type == 40)
            num13 = (int) Math.Round((double) this.game.Data.RuleVar[217]);
          int num14 = 0;
          int num15 = 0;
          int num16 = 0;
          int num17 = 0;
          int num18 = 0;
          int unitCounter4 = this.game.Data.UnitCounter;
          for (int unr = 0; unr <= unitCounter4; ++unr)
          {
            if (!this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unr].AIUnitGoal > 0 && this.game.Data.UnitObj[unr].AIPlanNr == index1 & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn)
            {
              int aiUnitGoal = this.game.Data.UnitObj[unr].AIUnitGoal;
              if (aiUnitGoal == 1)
                ++num14;
              if (aiUnitGoal == 2)
                ++num15;
              if (aiUnitGoal == 3)
                ++num16;
              if (aiUnitGoal == 4)
                num17 = Conversions.ToInteger(Operators.AddObject((object) num17, this.GetEPPerTurn(unr)));
              ++num18;
            }
          }
          this.AddLog("Plan #" + Conversion.Str((object) index1) + " engineer need score =" + Conversion.Str((object) Number) + ", geng=" + Conversion.Str((object) num17));
          if ((double) this.game.Data.RuleVar[211] > 0.0 & !(num18 == 0 & this.TPlanObj[index1].Type == 20 & this.TPlanObj[index1].EnemyUnitCount > 0))
          {
            if (Number > num13 & (double) num17 < (double) this.game.Data.RuleVar[215] * 2.0)
            {
              SimpleList simpleList = new SimpleList();
              int tplanCount2 = this.TPlanCount;
              for (int index3 = 1; index3 <= tplanCount2; ++index3)
              {
                if (index1 != index3 & this.HasPlanEngineerUnit(index3) > -1)
                {
                  int num19 = this.PlanEngineerNeedScore(index3);
                  if (num19 < num13)
                  {
                    int num20 = 1;
                    int num21;
                    if (this.GetAreaNr(this.TPlanObj[index3].FromArea) == this.GetAreaNr(this.TPlanObj[index1].FromArea))
                    {
                      num21 = 1;
                    }
                    else
                    {
                      int num22 = this.AreaDistance(this.GetAreaNr(this.TPlanObj[index3].FromArea), this.GetAreaNr(this.TPlanObj[index1].FromArea), true);
                      num21 = num22 != 0 ? num22 * num22 : 9999;
                    }
                    int num23 = num19 * num21;
                    if (this.TPlanObj[index3].Type == 40 & this.TPlanObj[index3].CurrentBackRoad > 0)
                      num23 = 9999;
                    int num24;
                    if (this.TPlanObj[index3].Type == 20)
                      num24 = (int) Math.Round((double) this.game.Data.RuleVar[216]);
                    if (this.TPlanObj[index3].Type == 40)
                      num24 = (int) Math.Round((double) this.game.Data.RuleVar[217]);
                    if (this.PlanEngineerNeedScore(index3) > num24 & (double) num17 >= (double) this.game.Data.RuleVar[215])
                      num20 = 0;
                    if (this.PlanEngineerNeedScore(index3) > num24 & (double) this.GetPlanEPPerTurn(index3) < (double) this.game.Data.RuleVar[215])
                      num20 = 0;
                    if (num20 == 1 & num23 < 9999)
                    {
                      this.AddLog("-" + Conversion.Str((object) index3) + " gets weight=" + Conversion.Str((object) num23));
                      simpleList.Add(index3, num23);
                    }
                  }
                }
              }
              if (simpleList.Counter > -1)
              {
                simpleList.Sort();
                if (simpleList.Weight[0] < num13)
                {
                  int index4 = this.HasPlanEngineerUnit(simpleList.Id[0]);
                  this.game.Data.UnitObj[index4].AIPlanNr = index1;
                  this.AddLog("Switched " + this.game.Data.UnitObj[index4].Name + " from plannr " + Conversion.Str((object) simpleList.Id[0]) + " to " + Conversion.Str((object) index1));
                  ++num17;
                }
              }
            }
            int num25 = 0;
            int unitCounter5 = this.game.Data.UnitCounter;
            for (int unr = 0; unr <= unitCounter5; ++unr)
            {
              if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn & this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].PreDef == -1)
              {
                int aiPlanNr = this.game.Data.UnitObj[unr].AIPlanNr;
                if (aiPlanNr > 0 && this.SAObj[this.GetAreaNr(this.TPlanObj[aiPlanNr].FromArea)].LandReservePlan > -1)
                {
                  int landReservePlan1 = this.SAObj[this.GetAreaNr(this.TPlanObj[aiPlanNr].FromArea)].LandReservePlan;
                  int landReservePlan2 = this.SAObj[this.GetAreaNr(this.TPlanObj[index1].FromArea)].LandReservePlan;
                  if (landReservePlan1 > 0 & landReservePlan1 == landReservePlan2 && this.game.Data.UnitObj[unr].AIUnitGoal == 4 && Operators.ConditionalCompareObjectLess(this.GetEPPerTurn(unr), (object) this.game.Data.RuleVar[215], false))
                  {
                    ++num25;
                    this.AddLog("Found 1 engineer in same landreserve with not at ideal filling yet (if 5x found no new ones allowed).");
                  }
                }
              }
            }
            if ((double) this.game.Data.RuleVar[249] == 0.0 && Number > num13 & num17 == 0 & num25 < 5)
            {
              Coordinate engineerCoord = this.GetEngineerCoord(1, index1);
              if (engineerCoord.onmap && this.game.Data.MapObj[0].HexObj[engineerCoord.x, engineerCoord.y].Regime == this.game.Data.Turn)
              {
                int num26 = 0;
                int unitCounter6 = this.game.Data.MapObj[0].HexObj[engineerCoord.x, engineerCoord.y].UnitCounter;
                for (int index5 = 0; index5 <= unitCounter6; ++index5)
                {
                  if (this.game.Data.UnitObj[this.game.Data.MapObj[0].HexObj[engineerCoord.x, engineerCoord.y].UnitList[index5]].AIUnitGoal == 4)
                    ++num26;
                }
                if (num26 <= 1)
                {
                  int index6;
                  int index7;
                  if (((double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= (double) this.game.Data.RuleVar[46] | (double) this.game.Data.RuleVar[863] > 0.0) & this.game.Data.MapObj[0].HexObj[index6, index7].UnitCounter < 15)
                  {
                    this.game.ProcessingObj.NewUnit(engineerCoord.x, engineerCoord.y, 0, false, this.game.Data.Turn);
                    this.game.Data.UnitObj[this.game.Data.UnitCounter].HQ = this.TPlanObj[index1].HQ;
                    this.game.Data.UnitObj[this.game.Data.UnitCounter].AIPlanNr = index1;
                    this.game.Data.UnitObj[this.game.Data.UnitCounter].AIUnitGoal = 4;
                    AIPlanClass[] tplanObj = this.TPlanObj;
                    AIPlanClass[] aiPlanClassArray = tplanObj;
                    int index8 = index1;
                    int index9 = index8;
                    aiPlanClassArray[index9].FriendlyUnitCount = tplanObj[index8].FriendlyUnitCount + 1;
                    this.AddLog("New engineer goal unit placed at " + Conversion.Str((object) engineerCoord.x) + "," + Conversion.Str((object) engineerCoord.y) + " for plan #" + Conversion.Str((object) index1));
                  }
                }
                else
                  this.AddLog("No new unit placed since there is already at least 2 engineer units on this hex");
              }
            }
          }
        }
        if (this.TPlanObj[index1].Type == 40 & this.TPlanObj[index1].SeaTarget < 1 & (num1 == index1 | num1 == -1))
        {
          int num27 = 0;
          int saCount = this.SACount;
          for (int index10 = 1; index10 <= saCount; ++index10)
          {
            if (this.GetAreaNr(this.TPlanObj[index1].FromArea) != index10 && this.HexContinent[this.TPlanObj[index1].FromArea.X, this.TPlanObj[index1].FromArea.Y] == this.HexContinent[this.SAObj[index10].X, this.SAObj[index10].Y])
            {
              int neighbourCount = this.SAObj[index10].NeighbourCount;
              for (int index11 = 1; index11 <= neighbourCount; ++index11)
              {
                if (this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[this.SAObj[this.SAObj[index10].Neighbour[index11]].X, this.SAObj[this.SAObj[index10].Neighbour[index11]].Y].Regime))
                  ++num27;
              }
            }
          }
          int Number1 = 0;
          if (num27 == 0)
            Number1 = 1;
          if (num27 > 0 & this.getfrontplan(this.TPlanObj[index1].FromArea.X, this.TPlanObj[index1].FromArea.Y) == -1)
            Number1 = 2;
          if (Number1 > 0)
          {
            int absoluteLandForRegime = this.game.HandyFunctionsObj.GetPowerPtsAbsoluteLandForRegime(this.game.Data.Turn);
            int totalStrategicValue = this.GetTotalStrategicValue();
            int weightStrategic = this.TPlanObj[index1].WeightStrategic;
            int Number2 = (int) Math.Round((double) absoluteLandForRegime * ((double) weightStrategic / (double) totalStrategicValue) * ((double) this.game.Data.RuleVar[244] * (double) this.game.Data.RegimeObj[this.game.Data.Turn].AIConservative / 100.0));
            if (Number1 == 2)
              Number2 = (int) Math.Round((double) Number2 * 0.5);
            int num28 = 0;
            this.AddLog("Plan #" + Conversion.Str((object) index1) + " needs a reserve (typ" + Conversion.Str((object) Number1) + ") of " + Conversion.Str((object) Number2) + " absolute power pts.");
            int unitCounter = this.game.Data.UnitCounter;
            for (int unr = 0; unr <= unitCounter; ++unr)
            {
              if (this.game.Data.UnitObj[unr].AIPlanNr == index1)
              {
                this.game.Data.UnitObj[unr].AIDisband = false;
                this.game.Data.UnitObj[unr].AIReserve = false;
                if (this.game.Data.UnitObj[unr].AIUnitGoal == 1 | this.game.Data.UnitObj[unr].AIUnitGoal == 2 | this.game.Data.UnitObj[unr].AIUnitGoal == 3 | this.game.Data.UnitObj[unr].AIUnitGoal == 4)
                {
                  if (Number2 >= num28)
                    this.game.Data.UnitObj[unr].AIReserve = true;
                  else
                    this.game.Data.UnitObj[unr].AIDisband = true;
                  num28 += this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unr, true);
                }
              }
            }
          }
        }
        if (this.TPlanObj[index1].Type == 40 & this.TPlanObj[index1].SeaTarget > 0 & (num1 == -1 | num1 == index1) && this.MakeNavyActive(index1))
        {
          int absoluteLandForRegime = this.game.HandyFunctionsObj.GetPowerPtsAbsoluteLandForRegime(this.game.Data.Turn);
          int totalStrategicValue = this.GetTotalStrategicValue();
          int weightStrategic = this.TPlanObj[index1].WeightStrategic;
          int Number = (int) Math.Round((double) absoluteLandForRegime * ((double) weightStrategic / (double) totalStrategicValue) * ((double) this.game.Data.RuleVar[244] * (double) this.game.Data.RegimeObj[this.game.Data.Turn].AIConservative / 100.0));
          int num29 = 0;
          int num30 = 0;
          if (this.getfrontplan(this.TPlanObj[index1].FromArea.X, this.TPlanObj[index1].FromArea.Y) == -1)
          {
            this.AddLog("Plan amph #" + Conversion.Str((object) index1) + " needs a reserve (typ amph reserve) of " + Conversion.Str((object) Number) + " absolute power pts.");
            int unitCounter = this.game.Data.UnitCounter;
            for (int unr = 0; unr <= unitCounter; ++unr)
            {
              if (this.game.Data.UnitObj[unr].AIPlanNr == index1 && this.TPlanObj[index1].SeaStand == 7)
              {
                this.game.Data.UnitObj[unr].AIReserve = false;
                if (this.game.Data.UnitObj[unr].AIUnitGoal == 1 | this.game.Data.UnitObj[unr].AIUnitGoal == 2 | this.game.Data.UnitObj[unr].AIUnitGoal == 3 | this.game.Data.UnitObj[unr].AIUnitGoal == 4)
                {
                  ++num30;
                  this.game.Data.UnitObj[unr].AIReserve = Number >= num29 & num30 > 1;
                  num29 += this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unr, true);
                }
              }
            }
          }
          else
          {
            int unitCounter = this.game.Data.UnitCounter;
            for (int index12 = 0; index12 <= unitCounter; ++index12)
            {
              if (this.game.Data.UnitObj[index12].AIPlanNr == index1 && this.TPlanObj[index1].SeaStand == 7)
                this.game.Data.UnitObj[index12].AIReserve = false;
            }
          }
        }
      }
    }

    public int GetAbsolutePowerForReserveUnit(int plnr)
    {
      object Counter;
      object LoopForResult;
      object CounterResult;
      object obj;
      if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(Counter, (object) 0, (object) this.game.Data.UnitCounter, (object) 1, ref LoopForResult, ref CounterResult))
      {
        do
        {
          if (this.game.Data.UnitObj[Conversions.ToInteger(CounterResult)].AIPlanNr == plnr & this.game.Data.UnitObj[Conversions.ToInteger(CounterResult)].AIReserve)
            obj = Operators.AddObject(obj, (object) 1);
        }
        while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult, LoopForResult, ref CounterResult));
      }
      object absoluteLandForRegime = (object) this.game.HandyFunctionsObj.GetPowerPtsAbsoluteLandForRegime(this.game.Data.Turn);
      object totalStrategicValue = (object) this.GetTotalStrategicValue();
      object weightStrategic = (object) this.TPlanObj[plnr].WeightStrategic;
      object Left = Operators.MultiplyObject(Operators.MultiplyObject(absoluteLandForRegime, Operators.DivideObject(weightStrategic, totalStrategicValue)), (object) (float) ((double) this.game.Data.RuleVar[244] * (double) this.game.Data.RegimeObj[this.game.Data.Turn].AIConservative / 100.0));
      if (Operators.ConditionalCompareObjectEqual(obj, (object) 0, false))
        obj = (object) 1;
      return Conversions.ToInteger(Conversion.Int(Operators.DivideObject(Left, obj)));
    }

    public int GetTotalStrategicValue()
    {
      int tplanCount = this.TPlanCount;
      int totalStrategicValue;
      for (int index = 1; index <= tplanCount; ++index)
      {
        if (this.TPlanObj[index].Type == 40)
          totalStrategicValue += this.TPlanObj[index].WeightStrategic;
      }
      return totalStrategicValue;
    }

    public int HasPlanEngineerUnit(int plannr)
    {
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index].AIPlanNr == plannr && this.game.Data.UnitObj[index].X > -1 && this.game.Data.UnitObj[index].AIUnitGoal == 4)
          return index;
      }
      return -1;
    }

    public void InitNavyTransferUnits()
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      SimpleList simpleList1 = new SimpleList();
      SimpleList simpleList2 = new SimpleList();
      bool[] flagArray = new bool[this.game.Data.UnitCounter + 1];
      this.AddLog("*Transfer naval units");
      this.AddLog("");
      int num1 = 1;
      while (num1 == 1)
      {
        num1 = 0;
        SimpleList simpleList3 = new SimpleList();
        int tplanCount = this.TPlanCount;
        for (int tid = 1; tid <= tplanCount; ++tid)
        {
          if (this.TPlanObj[tid].Type == 40 && this.HexSeaSA[this.TPlanObj[tid].FromArea.X, this.TPlanObj[tid].FromArea.Y] > 0)
          {
            int num2 = 10;
            int num3 = !(this.TPlanObj[tid].SeaTarget > 0 & this.TPlanObj[tid].SeaTarget <= this.SACount) ? 5 : (!this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[this.SAObj[this.TPlanObj[tid].SeaTarget].X, this.SAObj[this.TPlanObj[tid].SeaTarget].Y].Regime, this.game.Data.Turn) ? num2 * this.SAObj[this.TPlanObj[tid].SeaTarget].fuzzyvp : num2 * 1);
            float num4 = !(this.TPlanObj[tid].FriendlyNavy > 0 & this.TPlanObj[tid].EnemyNavy > 0) ? 1f : (float) this.TPlanObj[tid].EnemyNavy / (float) this.TPlanObj[tid].FriendlyNavy;
            if ((double) num4 > 10.0)
              num4 = 10f;
            int tweight = (int) Math.Round((double) Conversion.Int((float) num3 * num4));
            if (tweight < 1)
              tweight = 1;
            simpleList3.Add(tid, tweight);
          }
        }
        simpleList3.Sort();
        int counter1 = simpleList3.Counter;
        for (int index = 0; index <= counter1; ++index)
          this.AddLog("Plan #" + Conversion.Str((object) simpleList3.Id[index]) + " ... weight = " + Conversion.Str((object) simpleList3.Weight[index]));
        if (simpleList3.Counter > -1)
        {
          SimpleList simpleList4 = new SimpleList();
          int unitCounter = this.game.Data.UnitCounter;
          for (int tid = 0; tid <= unitCounter; ++tid)
          {
            if (this.game.Data.UnitObj[tid].Regime == this.game.Data.Turn & this.game.Data.UnitObj[tid].PreDef == -1)
            {
              int num5 = 0;
              if (this.game.Data.UnitObj[tid].AIUnitGoal == 9 | this.game.Data.UnitObj[tid].AIUnitGoal == 10 | this.game.Data.UnitObj[tid].AIUnitGoal == 8)
                num5 = 1;
              if (this.TPlanObj[simpleList3.Id[simpleList3.Counter]].SeaTarget < 1 & this.game.Data.UnitObj[tid].AIUnitGoal == 8)
                num5 = 0;
              if (this.game.Data.UnitObj[tid].SFCount == -1)
                num5 = 0;
              if (this.game.Data.UnitObj[tid].AIUnitGoal == 8)
              {
                if (!this.MakeNavyActive(simpleList3.Id[simpleList3.Counter]))
                  num5 = 0;
                if (this.TPlanObj[simpleList3.Id[simpleList3.Counter]].SeaStand != 7)
                  num5 = 0;
              }
              if (num5 == 1)
              {
                int aiPlanNr = this.game.Data.UnitObj[tid].AIPlanNr;
                if (aiPlanNr > 0)
                {
                  int nr = simpleList3.FindNr(aiPlanNr);
                  if (nr > -1 && simpleList3.Weight[nr] * 4 < simpleList3.Weight[simpleList3.Counter] & !flagArray[tid])
                  {
                    this.SetNavalMatrix1(this.game.Data.UnitObj[tid].X, this.game.Data.UnitObj[tid].Y);
                    int tweight = (int) Math.Round((double) this.Matrix1[this.TPlanObj[simpleList3.Id[simpleList3.Counter]].FromArea.X, this.TPlanObj[simpleList3.Id[simpleList3.Counter]].FromArea.Y] / Math.Sqrt((double) simpleList3.Weight[nr]));
                    if (tweight > 0)
                      simpleList4.Add(tid, tweight);
                  }
                }
              }
            }
          }
          simpleList4.Sort();
          this.AddLog("Find unit for transfer to plan #" + Conversion.Str((object) simpleList3.Id[simpleList3.Counter]));
          int counter2 = simpleList4.Counter;
          for (int index = 0; index <= counter2; ++index)
            this.AddLog("Unit #" + this.game.Data.UnitObj[simpleList4.Id[index]].Name + " ... weight = " + Conversion.Str((object) simpleList4.Weight[index]));
          if (simpleList4.Counter > -1)
          {
            this.AddLog("Changing naval unit " + this.game.Data.UnitObj[simpleList4.Id[simpleList4.Counter]].Name + " to plan # " + Conversion.Str((object) simpleList3.Id[simpleList3.Counter]));
            num1 = 1;
            flagArray[simpleList4.Id[simpleList4.Counter]] = true;
            this.game.Data.UnitObj[simpleList4.Id[simpleList4.Counter]].AIPlanNr = simpleList3.Id[simpleList3.Counter];
            this.InitTPlanForceBalanceNavy();
          }
        }
      }
    }

    public void InitSetStandingOrders()
    {
      float friendlyAirRatio = this.GetFriendlyAirRatio();
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].X > -1 && this.game.HandyFunctionsObj.HasUnitAirSF(unr))
        {
          this.game.Data.UnitObj[unr].SOInterceptRdnStop = (double) friendlyAirRatio < 1.0 ? ((double) friendlyAirRatio < 0.5 ? (!((double) friendlyAirRatio >= 0.25 & (double) VBMath.Rnd() > 0.75) ? 100 : 75) : 75) : 50;
          int aiPlanNr = this.game.Data.UnitObj[unr].AIPlanNr;
          this.game.Data.UnitObj[unr].SODefendPercent = aiPlanNr <= 0 ? 50 : (this.TPlanObj[aiPlanNr].Stand != 3 ? 50 : 5);
        }
      }
    }

    public void InitAirTransferUnits()
    {
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      SimpleList simpleList1 = new SimpleList();
      SimpleList simpleList2 = new SimpleList();
      int[] numArray2 = new int[this.TPlanCount + 1];
      bool[] flagArray = new bool[this.game.Data.UnitCounter + 1];
      int[] numArray3 = new int[this.TPlanCount + 1];
      int[] numArray4 = new int[this.TPlanCount + 1];
      int[] numArray5 = new int[this.TPlanCount + 1];
      int[] numArray6 = new int[this.TPlanCount + 1];
      if ((double) this.game.Data.RuleVar[221] < 1.0)
        return;
      int num1 = 1;
      int num2 = 0;
      while (num1 == 1 & num2 <= this.TPlanCount * 2)
      {
        num1 = 0;
        ++num2;
        SimpleList simpleList3 = new SimpleList();
        int tplanCount1 = this.TPlanCount;
        for (int index1 = 1; index1 <= tplanCount1; ++index1)
        {
          if (this.TPlanObj[index1].Type == 40)
          {
            int num3 = 0;
            int d1 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int mapWidth = this.game.Data.MapObj[0].MapWidth;
            for (int index2 = 0; index2 <= mapWidth; ++index2)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index3 = 0; index3 <= mapHeight; ++index3)
              {
                if (this.HexBackPlan[index2, index3] == index1)
                {
                  int forceLandStrength1 = this.GetHexForceLandStrength(index2, index3, true);
                  this.GetHexForceAirStrength(index2, index3, true);
                  num3 += forceLandStrength1;
                  if (this.game.HandyFunctionsObj.IsHexAirfield(index2, index3, 0) & num5 == 0)
                  {
                    num5 = 1;
                    int num7 = (int) Math.Round((double) ((float) index2 - this.game.Data.RuleVar[223]));
                    int num8 = (int) Math.Round((double) ((float) index2 + this.game.Data.RuleVar[223]));
                    for (int index4 = num7; index4 <= num8; ++index4)
                    {
                      int index5 = index4;
                      if (this.game.Data.MapObj[0].MapLoop & index5 < 0)
                        index5 = this.game.Data.MapObj[0].MapWidth + index5 + 1;
                      if (this.game.Data.MapObj[0].MapLoop & index5 > this.game.Data.MapObj[0].MapWidth)
                        index5 = index5 - this.game.Data.MapObj[0].MapWidth - 1;
                      int num9 = (int) Math.Round((double) ((float) index3 - this.game.Data.RuleVar[223]));
                      int num10 = (int) Math.Round((double) ((float) index3 + this.game.Data.RuleVar[223]));
                      for (int index6 = num9; index6 <= num10; ++index6)
                      {
                        if (index5 > -1 & index6 > -1 && index5 <= this.game.Data.MapObj[0].MapWidth & index6 <= this.game.Data.MapObj[0].MapHeight)
                        {
                          if (this.game.Data.MapObj[0].HexObj[index5, index6].Location > -1 & this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[index5, index6].Regime, this.game.Data.Turn) && (double) this.game.HandyFunctionsObj.Distance(index2, index3, 0, index5, index6, 0) <= (double) this.game.Data.RuleVar[223] * (double) this.game.Data.RuleVar[147])
                            num6 += this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index5, index6].Location].Type].MaxProd;
                          if (this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[index5, index6].Regime) && this.game.Data.MapObj[0].HexObj[index5, index6].UnitCounter > -1 && (double) this.game.HandyFunctionsObj.Distance(index2, index3, 0, index5, index6, 0) <= (double) this.game.Data.RuleVar[223])
                          {
                            int forceLandStrength2 = this.GetHexForceLandStrength(index5, index6, true);
                            int forceAirStrength = this.GetHexForceAirStrength(index5, index6);
                            d1 += forceLandStrength2;
                            num4 += forceAirStrength;
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
            int num11 = 0;
            int unitCounter = this.game.Data.UnitCounter;
            for (int unr = 0; unr <= unitCounter; ++unr)
            {
              if (this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].X > -1 && this.game.Data.UnitObj[unr].AIPlanNr == index1)
                num11 += this.game.HandyFunctionsObj.GetPowerPtsAbsoluteForAirOnly(unr);
            }
            if (num3 == 0)
              num3 = 1;
            this.TPlanObj[index1].FriendlyAir = num11;
            this.TPlanObj[index1].EnemyAir = num4;
            this.TPlanObj[index1].EnemyTroops = d1;
            this.TPlanObj[index1].ProdPtsInRange = num6;
            numArray3[index1] = num11;
            numArray4[index1] = num4;
            numArray5[index1] = num3;
            numArray6[index1] = d1;
            int num12 = (int) Math.Round((double) (int) Math.Round((double) (int) Math.Round(1000.0 - Math.Sqrt((double) (num4 * 10))) - Math.Sqrt((double) d1)) - Math.Sqrt((double) num6 / 10.0));
            if (num4 < 1 & d1 < 1)
              num12 += 250;
            if (num11 < 1)
              num11 = 1;
            int d2 = num11 * 10;
            int num13 = (int) Math.Round((double) num12 + Math.Sqrt((double) d2));
            simpleList3.Add(index1, num13);
            this.AddLog("plnr " + Conversion.Str((object) index1) + " weight= " + Conversion.Str((object) num13));
          }
        }
        if (simpleList3.Counter > 0)
        {
          simpleList3.Sort();
          int Number1 = simpleList3.Id[0];
          int tplanCount2 = this.TPlanCount;
          for (int Number2 = 1; Number2 <= tplanCount2; ++Number2)
          {
            if (this.TPlanObj[Number2].Type == 40 && this.HasAreaAirfield(this.GetAreaNr(this.TPlanObj[Number2].FromArea)))
            {
              int num14 = 0;
              if (this.HexOA[this.TPlanObj[Number1].FromArea.X, this.TPlanObj[Number1].FromArea.Y] == this.HexOA[this.TPlanObj[Number2].FromArea.X, this.TPlanObj[Number2].FromArea.Y])
                num14 = 1;
              if (Number1 == Number2)
                num14 = 0;
              if (num14 == 1)
              {
                int unitCounter = this.game.Data.UnitCounter;
                for (int unr = 0; unr <= unitCounter; ++unr)
                {
                  if (this.game.Data.UnitObj[unr].AIUnitGoal == 5 & this.game.Data.UnitObj[unr].AIPlanNr == Number2 & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn)
                  {
                    int num15 = numArray3[Number2] - this.GetForceAirStrength(unr, true);
                    if (1 > num15)
                      num15 = 1;
                    int d3 = num15 * 10;
                    int d4 = numArray4[Number2] * 10;
                    int d5 = numArray6[Number2];
                    int prodPtsInRange1 = this.TPlanObj[Number2].ProdPtsInRange;
                    int num16 = (int) Math.Round((double) (int) Math.Round((double) (int) Math.Round(1000.0 - Math.Sqrt((double) d4)) - Math.Sqrt((double) d5)) - Math.Sqrt((double) prodPtsInRange1 / 10.0));
                    if (d4 < 1 & d5 < 1)
                      num16 += 250;
                    int Number3 = (int) Math.Round((double) num16 + Math.Sqrt((double) d3));
                    int num17 = numArray3[Number1] + this.GetForceAirStrength(unr, true);
                    if (1 > num17)
                      num17 = 1;
                    int d6 = num17 * 10;
                    int d7 = numArray4[Number1] * 10;
                    int d8 = numArray6[Number1];
                    int prodPtsInRange2 = this.TPlanObj[Number2].ProdPtsInRange;
                    int num18 = (int) Math.Round((double) (int) Math.Round((double) (int) Math.Round(1000.0 - Math.Sqrt((double) d7)) - Math.Sqrt((double) d8)) - Math.Sqrt((double) prodPtsInRange2 / 10.0));
                    if (d7 < 1 & d8 < 1)
                      Number3 += 250;
                    int Number4 = (int) Math.Round((double) num18 + Math.Sqrt((double) d6));
                    this.AddLog(Conversion.Str((object) Number1) + " will be " + Conversion.Str((object) Number4) + " while source plan " + Conversion.Str((object) Number2) + " will be " + Conversion.Str((object) Number3));
                    if ((double) Number3 > (double) Number4 * 1.15)
                    {
                      this.AddLog("Switching Airunit " + this.game.Data.UnitObj[unr].Name + " from plan#" + Conversion.Str((object) Number2) + " to plan#" + Conversion.Str((object) Number1));
                      this.AddLog("pred.weight= " + Conversion.Str((object) Number3) + " wile sl.weight= " + Conversion.Str((object) simpleList3.Weight[simpleList3.Counter]));
                      this.game.Data.UnitObj[unr].AIPlanNr = Number1;
                      num1 = 1;
                      break;
                    }
                  }
                }
                if (num1 == 1)
                  break;
              }
            }
          }
        }
      }
    }

    public bool HasAreaAirfield(int nr)
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int x = 0; x <= mapWidth; ++x)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int y = 0; y <= mapHeight; ++y)
        {
          if (this.HexSA[x, y] == nr & this.game.HandyFunctionsObj.IsHexAirfield(x, y, 0))
            return true;
        }
      }
      return false;
    }

    public void InitTransferUnits()
    {
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      SimpleList simpleList1 = new SimpleList();
      SimpleList simpleList2 = new SimpleList();
      int[] numArray2 = new int[this.TPlanCount + 1];
      bool[] flagArray = new bool[this.game.Data.UnitCounter + 1];
      this.AddLog("");
      this.AddLog("*Consider assigning Units to different Plans");
      int num1 = 1;
      int num2 = 0;
      while (num1 == 1 & num2 <= this.TPlanCount * 2)
      {
        num1 = 0;
        ++num2;
        SimpleList simpleList3 = new SimpleList();
        int tplanCount = this.TPlanCount;
        int num3;
        for (int index = 1; index <= tplanCount; ++index)
        {
          if (this.TPlanObj[index].Type == 20)
          {
            if ((double) this.TPlanObj[index].WeightFriendlyForce > 0.0)
            {
              num3 = (int) Math.Round(200.0 * ((double) this.TPlanObj[index].WeightEnemyForceUnMod / (double) this.TPlanObj[index].WeightFriendlyForce));
            }
            else
            {
              try
              {
                num3 = (double) this.TPlanObj[index].WeightEnemyForceUnMod >= 1.0 ? (int) Math.Round(400.0 + 20.0 * (double) this.TPlanObj[index].WeightEnemyForceUnMod) : 100;
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
              }
            }
            num3 = (int) Math.Round((double) (int) Math.Round((double) ((float) num3 + this.TPlanObj[index].WeightFriendlyForce * this.GetPercentCuttenOff(index))) + Math.Sqrt((double) this.TPlanObj[index].WeightStrategic) * 100.0);
            int regime = this.game.Data.MapObj[0].HexObj[this.TPlanObj[index].TooArea.X, this.TPlanObj[index].TooArea.Y].Regime;
            if ((double) this.game.Data.RuleVar[264] == 0.0 && regime > -1 && this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[regime] == 0 && this.game.Data.RegimeObj[regime].AI)
            {
              num3 = (int) Math.Round((double) num3 * 0.5);
              if (1 > num3)
                num3 = 1;
              if ((this.game.Data.GameID + regime + this.game.Data.Turn) % 2 == 0)
              {
                num3 = (int) Math.Round((double) num3 * 0.5);
                if (1 > num3)
                  num3 = 1;
              }
              else if ((this.game.Data.GameID + regime + this.game.Data.Turn) % 3 == 0)
              {
                num3 = (int) Math.Round((double) num3 * 0.1);
                if (1 > num3)
                  num3 = 1;
              }
            }
            this.AddLog("Plan #" + Conversion.Str((object) index) + " gets weight=" + Conversion.Str((object) num3));
            simpleList3.Add(index, num3);
          }
        }
        simpleList3.Sort();
        if (simpleList3.Counter > -1)
        {
          for (int counter1 = simpleList3.Counter; counter1 >= 0; counter1 += -1)
          {
            SimpleList simpleList4 = new SimpleList();
            int Number1 = simpleList3.Id[counter1];
            int counter2 = simpleList3.Counter;
            for (int index = 0; index <= counter2; ++index)
            {
              if (index != counter1 && simpleList3.Weight[index] < simpleList3.Weight[counter1])
              {
                int tid = simpleList3.Id[index];
                if (this.GetAreaNr(this.TPlanObj[Number1].FromArea) == this.GetAreaNr(this.TPlanObj[tid].FromArea))
                {
                  num3 = 0;
                }
                else
                {
                  num3 = this.AreaDistance(this.GetAreaNr(this.TPlanObj[Number1].FromArea), this.GetAreaNr(this.TPlanObj[tid].FromArea), true);
                  if (num3 == 0)
                    num3 = 999;
                }
                if (num3 < 99)
                {
                  int num4 = simpleList3.Weight[counter1] - simpleList3.Weight[index];
                  int tweight = num3 != 0 ? (int) Math.Round((double) num4 / (double) num3) : num4 * 2;
                  if (this.TPlanObj[tid].FriendlyUnitCount < 2)
                    tweight = 0;
                  if ((double) this.TPlanObj[tid].WeightFriendlyForce == 0.0)
                    tweight = 0;
                  simpleList4.Add(tid, tweight);
                }
              }
            }
            simpleList4.Sort();
            if (simpleList4.Counter > -1)
            {
              int Number2 = simpleList4.Id[simpleList4.Counter];
              if (simpleList4.Weight[simpleList4.Counter] > 50 + numArray2[Number2])
              {
                int num5 = 9999;
                int index1 = -1;
                int unitCounter = this.game.Data.UnitCounter;
                for (int unr = 0; unr <= unitCounter; ++unr)
                {
                  if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && !flagArray[unr] && !this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unr].AIUnitGoal != 4 && this.game.Data.UnitObj[unr].AIPlanNr == Number2 & this.game.Data.UnitObj[unr].AIUnitGoal != 4 && this.HexSA[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] == this.GetAreaNr(this.TPlanObj[Number2].FromArea))
                  {
                    int num6 = this.GetForceLandStrength(unr);
                    if (this.AIVP[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] > 0)
                      num6 *= 4;
                    if (this.game.Data.UnitObj[unr].HQ > -1 & this.game.Data.UnitObj[unr].HQ == this.TPlanObj[Number1].HQ)
                      num6 = (int) Math.Round((double) num6 / 2.0);
                    if (this.game.Data.UnitObj[unr].X == this.TPlanObj[Number2].FromArea.X & this.game.Data.UnitObj[unr].Y == this.TPlanObj[Number2].FromArea.Y)
                      num6 = 999999;
                    if (num6 < num5 & (double) num6 >= (double) this.game.Data.RuleVar[183] & num6 < 9999)
                    {
                      num5 = num6;
                      index1 = unr;
                    }
                  }
                }
                if (index1 > -1)
                {
                  this.AddLog("Switching " + this.game.Data.UnitObj[index1].Name + " from plan#" + Conversion.Str((object) Number2) + " to plan#" + Conversion.Str((object) Number1));
                  this.game.Data.UnitObj[index1].AIPlanNr = Number1;
                  flagArray[index1] = true;
                  AIPlanClass[] tplanObj1 = this.TPlanObj;
                  AIPlanClass[] aiPlanClassArray1 = tplanObj1;
                  int index2 = Number1;
                  int index3 = index2;
                  aiPlanClassArray1[index3].WeightFriendlyForce = tplanObj1[index2].WeightFriendlyForce + (float) num5;
                  AIPlanClass[] tplanObj2 = this.TPlanObj;
                  AIPlanClass[] aiPlanClassArray2 = tplanObj2;
                  int index4 = Number1;
                  int index5 = index4;
                  aiPlanClassArray2[index5].FriendlyUnitCount = tplanObj2[index4].FriendlyUnitCount + 1;
                  AIPlanClass[] tplanObj3 = this.TPlanObj;
                  AIPlanClass[] aiPlanClassArray3 = tplanObj3;
                  int index6 = Number2;
                  int index7 = index6;
                  aiPlanClassArray3[index7].WeightFriendlyForce = tplanObj3[index6].WeightFriendlyForce - (float) num5;
                  AIPlanClass[] tplanObj4 = this.TPlanObj;
                  AIPlanClass[] aiPlanClassArray4 = tplanObj4;
                  int index8 = Number2;
                  int index9 = index8;
                  aiPlanClassArray4[index9].FriendlyUnitCount = tplanObj4[index8].FriendlyUnitCount - 1;
                  int[] numArray3 = numArray2;
                  int[] numArray4 = numArray3;
                  int index10 = Number2;
                  int index11 = index10;
                  int num7 = numArray3[index10] + 50;
                  numArray4[index11] = num7;
                  num1 = 1;
                }
              }
            }
            if (num1 == 1)
              break;
          }
        }
      }
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter1; ++unr)
      {
        int aiPlanNr = this.game.Data.UnitObj[unr].AIPlanNr;
        if (aiPlanNr > 0 && this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && !this.game.HandyFunctionsObj.HasUnitNavySF(unr) & !this.game.HandyFunctionsObj.HasUnitAirSF(unr) && this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].PreDef == -1 && this.HexContinent[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] != this.HexContinent[this.TPlanObj[aiPlanNr].FromArea.X, this.TPlanObj[aiPlanNr].FromArea.Y])
        {
          int num8 = 0;
          if (this.TPlanObj[aiPlanNr].SeaTarget > 0 & this.TPlanObj[aiPlanNr].SeaTarget <= this.SACount)
          {
            if (this.HexContinent[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] != this.HexContinent[this.SAObj[this.TPlanObj[aiPlanNr].SeaTarget].X, this.SAObj[this.TPlanObj[aiPlanNr].SeaTarget].Y])
              num8 = 1;
          }
          else
            num8 = 1;
          if (num8 == 1)
            this.game.Data.UnitObj[unr].AIPlanNr = this.GetClosestBackPlan(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y);
        }
      }
      int unitCounter2 = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter2; ++unr)
      {
        int aiPlanNr = this.game.Data.UnitObj[unr].AIPlanNr;
        if (aiPlanNr > 0 && this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && !this.game.HandyFunctionsObj.HasUnitNavySF(unr) & !this.game.HandyFunctionsObj.HasUnitAirSF(unr) && this.game.Data.UnitObj[unr].X > -1 & this.game.Data.UnitObj[unr].PreDef == -1 && this.TPlanObj[aiPlanNr].Type == 40 && this.game.Data.UnitObj[unr].AIUnitGoal != 4)
        {
          if (this.getfrontplan(this.TPlanObj[aiPlanNr].FromArea.X, this.TPlanObj[aiPlanNr].FromArea.Y) > -1 && !(this.TPlanObj[aiPlanNr].SeaTarget > 0 & this.TPlanObj[aiPlanNr].SeaStand == 7))
          {
            this.game.Data.UnitObj[unr].AIPlanNr = this.getfrontplan(this.TPlanObj[aiPlanNr].FromArea.X, this.TPlanObj[aiPlanNr].FromArea.Y);
            this.AddLog("Switched unit " + this.game.Data.UnitObj[unr].Name + " from backplan to frontplan, since combat is near");
          }
          if (this.TPlanObj[aiPlanNr].SeaTarget > 0 && this.HexContinent[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] != this.HexContinent[this.TPlanObj[aiPlanNr].FromArea.X, this.TPlanObj[aiPlanNr].FromArea.Y] && this.getfrontplan(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y) > -1)
          {
            this.game.Data.UnitObj[unr].AIPlanNr = this.getfrontplan(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y);
            this.AddLog("Switched unit " + this.game.Data.UnitObj[unr].Name + " from backplan to frontplan, since combat is near");
          }
        }
      }
    }

    public void InitTacticalHQ()
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      SimpleList simpleList = new SimpleList();
      SimpleList UL = new SimpleList();
      if ((double) this.game.Data.RuleVar[(int) byte.MaxValue] == 1.0)
        return;
      int tplanCount1 = this.TPlanCount;
      for (int Number1 = 1; Number1 <= tplanCount1; ++Number1)
      {
        if (this.TPlanObj[Number1].Type == 20 && this.TPlanObj[Number1].HQ > -1)
        {
          int hq = this.TPlanObj[Number1].HQ;
          int x = this.game.Data.UnitObj[hq].X;
          int y = this.game.Data.UnitObj[hq].Y;
          this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), x, y, 0);
          int unitCounter = this.game.Data.UnitCounter;
          int Number2;
          int num1;
          for (int index = 0; index <= unitCounter; ++index)
          {
            if (this.game.Data.UnitObj[index].HQ == hq & this.game.Data.UnitObj[Number1].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index].X > -1 & this.game.Data.UnitObj[index].PreDef == -1 && this.HexSA[this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y] == this.GetAreaNr(this.TPlanObj[Number1].FromArea))
            {
              int num2 = this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y];
              if ((double) num2 > (double) this.game.Data.RuleVar[3] * 2.0)
                num2 = (int) Math.Round((double) (this.game.Data.RuleVar[3] * 2f));
              Number2 += num2;
              ++num1;
            }
          }
          Number2 = num1 != 0 ? (int) Math.Round((double) Number2 / (double) num1) : 0;
          if ((double) Number2 > (double) this.game.Data.RuleVar[52])
          {
            this.AddLog("SET TAC.HQ of Plan #" + Conversion.Str((object) Number1) + " to NONE because of really bad supply currently.. avg=" + Conversion.Str((object) Number2) + "ap need.");
            this.TPlanObj[Number1].HQ = -1;
          }
        }
      }
      int tplanCount2 = this.TPlanCount;
      for (int Number = 1; Number <= tplanCount2; ++Number)
      {
        if (this.TPlanObj[Number].Type == 20 && this.TPlanObj[Number].HQ == -1)
        {
          int unitCounter = this.game.Data.UnitCounter;
          for (int index = 0; index <= unitCounter; ++index)
          {
            if (this.game.Data.UnitObj[index].AIPlanNr == Number & this.game.Data.UnitObj[index].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index].IsHQ)
            {
              this.TPlanObj[Number].HQ = index;
              this.AddLog("*** Gave plan " + Conversion.Str((object) Number) + " the following HQ: " + this.game.Data.UnitObj[index].Name + " from its own troops.");
              break;
            }
          }
        }
      }
      int tplanCount3 = this.TPlanCount;
      for (int index1 = 1; index1 <= tplanCount3; ++index1)
      {
        if (this.TPlanObj[index1].Type == 20 & this.NeedHQ(index1) && this.TPlanObj[index1].HQ == -1)
        {
          int num = 0;
          int tplanCount4 = this.TPlanCount;
          for (int Number = 1; Number <= tplanCount4; ++Number)
          {
            if (this.TPlanObj[Number].Type == 20)
            {
              this.AreaDistance(this.GetAreaNr(this.TPlanObj[index1].FromArea), this.GetAreaNr(this.TPlanObj[Number].FromArea));
              if (index1 == Number)
              {
                int unitCounter = this.game.Data.UnitCounter;
                for (int index2 = 0; index2 <= unitCounter; ++index2)
                {
                  if (this.game.Data.UnitObj[index2].AIPlanNr == Number & this.TPlanObj[Number].HQ != index2 && this.game.Data.UnitObj[index2].IsHQ & this.game.Data.UnitObj[index2].Regime == this.game.Data.Turn)
                  {
                    this.TPlanObj[index1].HQ = index2;
                    this.game.Data.UnitObj[index2].AIPlanNr = index1;
                    this.AddLog("*** Gave plan " + Conversion.Str((object) index1) + " the following HQ: " + this.game.Data.UnitObj[index2].Name + " from plan # " + Conversion.Str((object) Number));
                    AIPlanClass[] tplanObj1 = this.TPlanObj;
                    AIPlanClass[] aiPlanClassArray1 = tplanObj1;
                    int index3 = index1;
                    int index4 = index3;
                    aiPlanClassArray1[index4].FriendlyUnitCount = tplanObj1[index3].FriendlyUnitCount + 1;
                    AIPlanClass[] tplanObj2 = this.TPlanObj;
                    AIPlanClass[] aiPlanClassArray2 = tplanObj2;
                    int index5 = Number;
                    int index6 = index5;
                    aiPlanClassArray2[index6].FriendlyUnitCount = tplanObj2[index5].FriendlyUnitCount - 1;
                    num = 1;
                    break;
                  }
                }
                if (num == 1)
                  break;
              }
            }
          }
        }
      }
      int tplanCount5 = this.TPlanCount;
      for (int index7 = 1; index7 <= tplanCount5; ++index7)
      {
        if (this.TPlanObj[index7].Type == 20 && this.TPlanObj[index7].HQ == -1 & this.NeedHQ(index7) && (double) this.game.Data.RuleVar[47] <= (double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts | (double) this.game.Data.RuleVar[863] > 0.0)
        {
          int num = 1;
          int tplanCount6 = this.TPlanCount;
          for (int index8 = 1; index8 <= tplanCount6; ++index8)
          {
            if (index8 != index7 && this.TPlanObj[index8].Type == 20 | this.TPlanObj[index8].Type == 30 && this.TPlanObj[index8].FromArea.X == this.TPlanObj[index7].FromArea.X && this.TPlanObj[index8].FromArea.Y == this.TPlanObj[index7].FromArea.Y && this.TPlanObj[index8].HQ > -1 && (double) this.AverageDistanceUnits(index7, this.game.Data.UnitObj[this.TPlanObj[index8].HQ].X, this.game.Data.UnitObj[this.TPlanObj[index8].HQ].Y) <= (double) this.game.Data.RuleVar[191])
              num = 0;
          }
          if (this.SAObj[this.GetAreaNr(this.TPlanObj[index7].FromArea)].LandReservePlan == 0)
            num = 0;
          if (this.SAObj[this.GetAreaNr(this.TPlanObj[index7].FromArea)].LandReservePlan > 0)
          {
            int landReservePlan = this.SAObj[this.GetAreaNr(this.TPlanObj[index7].FromArea)].LandReservePlan;
            int x1 = this.TPlanObj[landReservePlan].FromArea.X;
            int y1 = this.TPlanObj[landReservePlan].FromArea.Y;
            if (this.TPlanObj[landReservePlan].HQ > -1)
            {
              int x2 = this.TPlanObj[index7].FromArea.X;
              int y2 = this.TPlanObj[index7].FromArea.Y;
              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), x1, y1, 0);
              if ((double) this.game.EditObj.TempValue[0].Value[x2, y2] > (double) this.game.Data.RuleVar[52])
                num = 0;
            }
            else
              num = 0;
          }
          if (num == 1)
          {
            int unitCounter = this.game.Data.UnitCounter;
            for (int tid = 0; tid <= unitCounter; ++tid)
            {
              if (this.game.Data.UnitObj[tid].AIPlanNr == index7 & this.game.Data.UnitObj[tid].Regime == this.game.Data.Turn)
                UL.Add(tid, -1);
            }
            Coordinate coordinate = this.SetMatrixHQ(UL, onlysanr: this.GetAreaNr(this.TPlanObj[index7].FromArea));
            int x;
            int y;
            if (coordinate.onmap)
            {
              x = coordinate.x;
              y = coordinate.y;
            }
            else
            {
              x = this.TPlanObj[index7].FromArea.X;
              y = this.TPlanObj[index7].FromArea.Y;
            }
            if (this.TPlanObj[index7].Stand == 3)
            {
              int neighbourForRetreater = this.GetBestNeighbourForRetreater(this.GetAreaNr(this.TPlanObj[index7].FromArea));
              if (neighbourForRetreater > 0)
              {
                x = this.SAObj[neighbourForRetreater].X;
                y = this.SAObj[neighbourForRetreater].Y;
              }
            }
            if (this.game.Data.MapObj[0].HexObj[x, y].UnitCounter < 15)
            {
              this.game.ProcessingObj.NewUnit(x, y, 0, true, this.game.Data.Turn);
              this.game.Data.UnitObj[this.game.Data.UnitCounter].AIPlanNr = index7;
              this.TPlanObj[index7].HQ = this.game.Data.UnitCounter;
              AIPlanClass[] tplanObj = this.TPlanObj;
              AIPlanClass[] aiPlanClassArray = tplanObj;
              int index9 = index7;
              int index10 = index9;
              aiPlanClassArray[index10].FriendlyUnitCount = tplanObj[index9].FriendlyUnitCount + 1;
              this.AddLog("*** Gave plan " + Conversion.Str((object) index7) + " a new HQ: " + this.game.Data.UnitObj[this.game.Data.UnitCounter].Name + ", created freshly.");
            }
          }
        }
      }
    }

    public int AverageDistanceUnits(int plannr, int x, int y)
    {
      int unitCounter = this.game.Data.UnitCounter;
      int num1;
      int num2;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.game.Data.UnitObj[index].AIPlanNr == plannr & this.game.Data.UnitObj[index].Regime == this.game.Data.Turn)
        {
          num1 += this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y, 0, x, y, 0);
          ++num2;
        }
      }
      if (num2 == 0)
        num2 = 1;
      return (int) Math.Round(Conversion.Int((double) num1 / (double) num2));
    }

    public int AverageDistanceUnitsInAP(int plannr, int x, int y, bool onlyifinownarea = false)
    {
      if (this.TempAvgUnits[plannr] > -1)
        return this.TempAvgUnits[plannr];
      this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, (int) Math.Round((double) this.game.Data.RuleVar[3]), x, y, 0);
      int unitCounter = this.game.Data.UnitCounter;
      int num1;
      int num2;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.game.Data.UnitObj[index].X > -1 & this.game.Data.UnitObj[index].PreDef == -1 && this.game.Data.UnitObj[index].AIPlanNr == plannr & this.game.Data.UnitObj[index].Regime == this.game.Data.Turn)
        {
          int num3 = 1;
          if (onlyifinownarea && this.HexSA[this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y] != this.GetSANr(this.TPlanObj[plannr].FromArea))
            num3 = 0;
          if (num3 == 1)
          {
            int num4 = (int) Math.Round((double) this.game.Data.RegimeObj[this.game.Data.Turn].AIConservative);
            if (num4 > 250)
              num4 = 250;
            num1 += num4;
            ++num2;
          }
        }
      }
      if (num2 == 0)
        num2 = 1;
      return (int) Math.Round(Conversion.Int((double) num1 / (double) num2));
    }

    public void InitLandReserveMetaHQ()
    {
      int[] numArray = new int[this.game.Data.UnitCounter + 1];
      this.AddLog("");
      this.AddLog("LANDRESERVE HQ ASSIGNING");
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        numArray[index] = -1;
        if (this.game.Data.UnitObj[index].PreDef == -1 & this.game.Data.UnitObj[index].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index].IsHQ)
          this.game.Data.UnitObj[index].HQ = -1;
      }
      int num = 1;
      int Number = -1;
      int unitCounter2 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter2; ++index)
        numArray[index] = -1;
      while (num == 1)
      {
        ++Number;
        num = 0;
        SimpleList simpleList1 = new SimpleList();
        int unitCounter3 = this.game.Data.UnitCounter;
        for (int tid = 0; tid <= unitCounter3; ++tid)
        {
          if (this.game.Data.UnitObj[tid].PreDef == -1 & this.game.Data.UnitObj[tid].Regime == this.game.Data.Turn && this.game.Data.UnitObj[tid].X > -1 && this.game.Data.UnitObj[tid].IsHQ & this.game.Data.UnitObj[tid].HQ == -1 && this.game.Data.UnitObj[tid].AIPlanNr > 0 && this.TPlanObj[this.game.Data.UnitObj[tid].AIPlanNr].Type == 30 && numArray[tid] == -1)
          {
            int closestEnemyDistance = this.GetClosestEnemyDistance(this.game.Data.UnitObj[tid].X, this.game.Data.UnitObj[tid].Y);
            simpleList1.Add(tid, closestEnemyDistance);
          }
        }
        if (simpleList1.Counter > -1)
        {
          simpleList1.Sort();
          numArray[simpleList1.Id[simpleList1.Counter]] = Number;
          if (Number == 0)
            this.TPlanObj[this.game.Data.UnitObj[simpleList1.Id[simpleList1.Counter]].AIPlanNr].MetaChainNr = 0;
          this.AddLog("Set " + this.game.Data.UnitObj[simpleList1.Id[simpleList1.Counter]].Name + " to temp=" + Conversion.Str((object) Number));
          num = 1;
          if (Number > 0)
          {
            this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[simpleList1.Id[simpleList1.Counter]].X, this.game.Data.UnitObj[simpleList1.Id[simpleList1.Counter]].Y, 0, NoAPPenalties: true);
            SimpleList simpleList2 = new SimpleList();
            int unitCounter4 = this.game.Data.UnitCounter;
            for (int tid = 0; tid <= unitCounter4; ++tid)
            {
              if (this.game.Data.UnitObj[tid].X > -1 & this.game.Data.UnitObj[tid].PreDef == -1 && numArray[tid] > -1 & numArray[tid] < Number)
                simpleList2.Add(tid, this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[tid].X, this.game.Data.UnitObj[tid].Y]);
            }
            if (simpleList2.Counter > -1)
            {
              simpleList2.Sort();
              int index = simpleList2.Id[0];
              this.game.Data.UnitObj[simpleList1.Id[simpleList1.Counter]].HQ = index;
              this.TPlanObj[this.game.Data.UnitObj[simpleList1.Id[simpleList1.Counter]].AIPlanNr].MetaChainNr = this.TPlanObj[this.game.Data.UnitObj[index].AIPlanNr].MetaChainNr + 1;
              this.AddLog("Assigned " + this.game.Data.UnitObj[simpleList1.Id[simpleList1.Counter]].Name + " to => " + this.game.Data.UnitObj[index].Name);
            }
          }
        }
      }
      this.AddLog("");
    }

    public void InitResearch()
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      SimpleList simpleList = new SimpleList();
      if ((double) this.game.Data.RuleVar[226] <= 0.0)
        return;
      this.AddLog("");
      this.AddLog("RESEARCH");
      int resPts1 = this.game.Data.RegimeObj[this.game.Data.Turn].ResPts;
      if ((double) resPts1 > (double) this.game.Data.RuleVar[181] & (double) VBMath.Rnd() > 0.5 | (double) resPts1 > (double) this.game.Data.RuleVar[181] * 5.0)
      {
        int Number = (int) Math.Round((double) ((float) resPts1 - this.game.Data.RuleVar[181]));
        RegimeClass[] regimeObj1 = this.game.Data.RegimeObj;
        RegimeClass[] regimeClassArray1 = regimeObj1;
        int turn1 = this.game.Data.Turn;
        int index1 = turn1;
        regimeClassArray1[index1].AISavedPP = regimeObj1[turn1].AISavedPP + Number;
        RegimeClass[] regimeObj2 = this.game.Data.RegimeObj;
        RegimeClass[] regimeClassArray2 = regimeObj2;
        int turn2 = this.game.Data.Turn;
        int index2 = turn2;
        regimeClassArray2[index2].ResPts = regimeObj2[turn2].ResPts - Number;
        this.AddLog("Added " + Conversion.Str((object) Number) + " pp to savedpp of regime. which is now: " + Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].AISavedPP));
      }
      this.AddLog("Saved pp: " + Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].AISavedPP) + ", Normal pp: " + Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts));
      float Number1 = 1000f;
      int researchCounter1 = this.game.Data.ResearchCounter;
      for (int index = 0; index <= researchCounter1; ++index)
      {
        if (this.game.Data.RegimeObj[this.game.Data.Turn].ResField[index])
        {
          int sfTypePic = this.game.Data.ResearchObj[index].SFTypePic;
          if (sfTypePic > -1 && this.game.Data.SFTypeObj[sfTypePic].Cap <= 0 && this.game.Data.SFTypeObj[sfTypePic].Theater == 1)
          {
            float num1 = 0.0f;
            int num2 = 0;
            int mapWidth = this.game.Data.MapObj[0].MapWidth;
            for (int attackx = 0; attackx <= mapWidth; ++attackx)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int attacky = 0; attacky <= mapHeight; ++attacky)
              {
                if (!(this.game.Data.MapObj[0].HexObj[attackx, attacky].Regime > -1 & this.game.Data.SFTypeObj[sfTypePic].Theater != 1) && this.game.Data.SFTypeObj[sfTypePic].Theater == 1 & this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[attackx, attacky].LandscapeType].IsSea && this.game.Data.MapObj[0].HexObj[attackx, attacky].UnitCounter > -1 && this.game.Data.UnitObj[this.game.Data.MapObj[0].HexObj[attackx, attacky].UnitList[0]].Regime != this.game.Data.Turn)
                {
                  float num3 = this.AverageCombatPerform(-1, sfTypePic, attackx, attacky, onlysametheater: true);
                  float num4 = this.AverageCombatPerform(-1, sfTypePic, attackx, attacky, true, true);
                  if ((double) num3 > (double) num4)
                    num1 += (float) (((double) num3 * 3.0 + (double) num4) / 4.0);
                  else
                    num1 += (float) (((double) num4 * 3.0 + (double) num3) / 4.0);
                  ++num2;
                }
              }
            }
            if (num2 > 0 & (double) num1 > 0.0 && 1.0 / ((double) num1 / (double) num2) < (double) Number1)
              Number1 = (float) (1.0 / ((double) num1 / (double) num2));
          }
        }
      }
      this.AddLog("bestseamod= " + Conversion.Str((object) Number1));
      int researchCounter2 = this.game.Data.ResearchCounter;
      for (int tid = 0; tid <= researchCounter2; ++tid)
      {
        if (!this.game.Data.RegimeObj[this.game.Data.Turn].ResField[tid])
        {
          int num5 = 1;
          if (this.game.Data.ResearchObj[tid].PreReq > -1 && !this.game.Data.RegimeObj[this.game.Data.Turn].ResField[this.game.Data.ResearchObj[tid].PreReq])
            num5 = 0;
          if (this.game.Data.ResearchObj[tid].PreReq2 > -1 && !this.game.Data.RegimeObj[this.game.Data.Turn].ResField[this.game.Data.ResearchObj[tid].PreReq2])
            num5 = 0;
          if (num5 == 1)
          {
            int num6 = this.game.Data.ResearchObj[tid].PointCost[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.Turn].People].PeopleGroup];
            int sfTypePic = this.game.Data.ResearchObj[tid].SFTypePic;
            if (sfTypePic > -1 & num6 > -1 & num6 < 9998 && this.game.Data.SFTypeObj[sfTypePic].StaffPts <= 0 && this.game.Data.SFTypeObj[sfTypePic].Cap <= 0 && !(this.game.Data.SFTypeObj[sfTypePic].Theater == 1 & (double) this.game.Data.RuleVar[227] == 0.0))
            {
              float num7 = 0.0f;
              int num8 = 0;
              int mapWidth = this.game.Data.MapObj[0].MapWidth;
              for (int index3 = 0; index3 <= mapWidth; ++index3)
              {
                int mapHeight = this.game.Data.MapObj[0].MapHeight;
                for (int index4 = 0; index4 <= mapHeight; ++index4)
                {
                  if (this.game.Data.MapObj[0].HexObj[index3, index4].Regime > -1 & this.game.Data.SFTypeObj[sfTypePic].Theater != 1)
                  {
                    if (this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[index3, index4].Regime) && this.GetHexForceLandStrength(index3, index4, true) > 0)
                    {
                      float num9 = this.AverageCombatPerform(-1, sfTypePic, index3, index4, onlysametheater: true);
                      float num10 = this.AverageCombatPerform(-1, sfTypePic, index3, index4, true, true);
                      if ((double) num9 > (double) num10)
                        num7 += (float) (((double) num9 * 3.0 + (double) num10) / 4.0);
                      else
                        num7 += (float) (((double) num10 * 3.0 + (double) num9) / 4.0);
                      ++num8;
                    }
                  }
                  else if (this.game.Data.SFTypeObj[sfTypePic].Theater == 1 & this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index3, index4].LandscapeType].IsSea && this.game.Data.MapObj[0].HexObj[index3, index4].UnitCounter > -1 && this.game.Data.UnitObj[this.game.Data.MapObj[0].HexObj[index3, index4].UnitList[0]].Regime != this.game.Data.Turn)
                  {
                    float num11 = this.AverageCombatPerform(-1, sfTypePic, index3, index4, onlysametheater: true);
                    float num12 = this.AverageCombatPerform(-1, sfTypePic, index3, index4, true, true);
                    if ((double) num11 > (double) num12)
                      num7 += (float) (((double) num11 * 3.0 + (double) num12) / 4.0);
                    else
                      num7 += (float) (((double) num12 * 3.0 + (double) num11) / 4.0);
                    ++num8;
                  }
                }
              }
              if (num8 > 0 & (double) num7 > 0.0)
                num6 = (int) Math.Round((double) ((float) num6 * (float) (1.0 / ((double) num7 / (double) num8))));
              int num13 = this.GetPowerPointPercentUpgradeableToo(sfTypePic);
              if (num13 > 25)
                num13 = 25;
              if (num13 < 1)
                num13 = 1;
              int Number2 = num6;
              int num14 = (int) Math.Round((double) (100 * num6) * 0.1 + (double) (100 * num6) * 0.9 * ((double) (25 - num13 + 1) / 25.0));
              int Number3 = (int) Math.Round((double) this.GetPowerPointPercentUpgradeableToo(sfTypePic) / 10.0);
              if (Number3 > 7)
                Number3 = 7;
              if (Number3 < 1)
                Number3 = 1;
              int num15 = (int) Math.Round((double) num14 / (double) Number3);
              if ((double) this.GetFriendlyAirRatio() < (double) this.game.Data.RuleVar[258] & (double) this.game.Data.Round > (double) this.game.Data.RuleVar[259] && this.game.Data.SFTypeObj[sfTypePic].AIRoleScore[12] > 0)
                num15 = (int) Math.Round((double) num15 / 4.0);
              if (this.game.Data.SFTypeObj[sfTypePic].Theater == 1)
              {
                if (1.0 / ((double) num7 / (double) num8) <= (double) Number1 * 0.9)
                {
                  simpleList.Add(tid, num15);
                  this.AddLog(this.game.Data.SFTypeObj[sfTypePic].Name + " .. weight =" + Conversion.Str((object) num15) + ", previous weight= " + Conversion.Str((object) Number2) + ",  powerpointpercentmod=" + Conversion.Str((object) Number3));
                }
              }
              else
              {
                simpleList.Add(tid, num15);
                this.AddLog(this.game.Data.SFTypeObj[sfTypePic].Name + " .. weight =" + Conversion.Str((object) num15) + ", previous weight= " + Conversion.Str((object) Number2) + ",  powerpointpercentmod=" + Conversion.Str((object) Number3));
              }
            }
          }
        }
      }
      if (simpleList.Counter <= -1)
        return;
      simpleList.Sort();
      int counter = simpleList.Counter;
      for (int index5 = 0; index5 <= counter; ++index5)
      {
        if (index5 < 9 && (double) this.game.Data.RegimeObj[this.game.Data.Turn].AISavedPP >= (double) this.game.Data.ResearchObj[simpleList.Id[index5]].PointCost[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.Turn].People].PeopleGroup] * (double) this.game.Data.ResCostMod && !(this.game.Data.SFTypeObj[this.game.Data.ResearchObj[simpleList.Id[index5]].SFTypePic].Theater == 1 & (double) Number1 == 9999.0))
        {
          RegimeClass[] regimeObj3 = this.game.Data.RegimeObj;
          RegimeClass[] regimeClassArray3 = regimeObj3;
          int turn3 = this.game.Data.Turn;
          int index6 = turn3;
          regimeClassArray3[index6].ResPts = regimeObj3[turn3].ResPts + this.game.Data.RegimeObj[this.game.Data.Turn].AISavedPP;
          int resPts2 = this.game.Data.RegimeObj[this.game.Data.Turn].ResPts;
          this.game.ProcessingObj.BuyResearch(this.game.Data.RegimeObj[this.game.Data.Turn].People, this.game.Data.Turn, simpleList.Id[index5]);
          this.AddLog("Bought researchfield: " + this.game.Data.ResearchObj[simpleList.Id[index5]].Name);
          if (this.game.Data.SFTypeObj[this.game.Data.ResearchObj[simpleList.Id[index5]].SFTypePic].Theater == 1)
            Number1 = 9999f;
          int resPts3 = this.game.Data.RegimeObj[this.game.Data.Turn].ResPts;
          RegimeClass[] regimeObj4 = this.game.Data.RegimeObj;
          RegimeClass[] regimeClassArray4 = regimeObj4;
          int turn4 = this.game.Data.Turn;
          int index7 = turn4;
          regimeClassArray4[index7].AISavedPP = regimeObj4[turn4].AISavedPP - (resPts2 - resPts3);
          if (0 > this.game.Data.RegimeObj[this.game.Data.Turn].AISavedPP)
            this.game.Data.RegimeObj[this.game.Data.Turn].AISavedPP = 0;
          RegimeClass[] regimeObj5 = this.game.Data.RegimeObj;
          RegimeClass[] regimeClassArray5 = regimeObj5;
          int turn5 = this.game.Data.Turn;
          int index8 = turn5;
          regimeClassArray5[index8].ResPts = regimeObj5[turn5].ResPts - this.game.Data.RegimeObj[this.game.Data.Turn].AISavedPP;
          if (0 > this.game.Data.RegimeObj[this.game.Data.Turn].ResPts)
            this.game.Data.RegimeObj[this.game.Data.Turn].ResPts = 0;
          int num16 = simpleList.Id[index5];
          int itemTypeCounter = this.game.Data.ItemTypeCounter;
          for (int itemtypenr = 0; itemtypenr <= itemTypeCounter; ++itemtypenr)
          {
            if (this.game.Data.ItemTypeObj[itemtypenr].ResFieldNeeded[0] == num16 | this.game.Data.ItemTypeObj[itemtypenr].ResFieldNeeded[1] == num16 | this.game.Data.ItemTypeObj[itemtypenr].ResFieldNeeded[2] == num16 | this.game.Data.ItemTypeObj[itemtypenr].ResFieldNeeded[3] == num16 | this.game.Data.ItemTypeObj[itemtypenr].ResFieldNeeded[4] == num16 && this.game.Data.ItemTypeObj[itemtypenr].Blocks > -1)
            {
              int blocks = this.game.Data.ItemTypeObj[itemtypenr].Blocks;
              int locCounter = this.game.Data.LocCounter;
              for (int locnr = 0; locnr <= locCounter; ++locnr)
              {
                if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y].Regime == this.game.Data.Turn)
                {
                  int index9 = 0;
                  do
                  {
                    if (this.game.Data.LocObj[locnr].Production[index9] == this.game.Data.ItemTypeObj[itemtypenr].Blocks && this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, itemtypenr).result)
                    {
                      this.game.Data.LocObj[locnr].Production[index9] = itemtypenr;
                      int num17;
                      ++num17;
                    }
                    ++index9;
                  }
                  while (index9 <= 3);
                }
              }
            }
          }
        }
      }
    }

    public int GetPowerPointPercent(int sftype)
    {
      int unitCounter = this.game.Data.UnitCounter;
      int num1;
      int num2;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index1].PreDef == -1)
        {
          int sfCount = this.game.Data.UnitObj[index1].SFCount;
          for (int index2 = 0; index2 <= sfCount; ++index2)
          {
            int sf = this.game.Data.UnitObj[index1].SFList[index2];
            int type = this.game.Data.SFObj[sf].Type;
            if (type == sftype)
              num1 += this.game.Data.SFTypeObj[type].PowerPts * this.game.Data.SFObj[sf].Qty;
            num2 += this.game.Data.SFTypeObj[type].PowerPts * this.game.Data.SFObj[sf].Qty;
          }
        }
      }
      int num3 = num1 * 100;
      if (num2 < 1)
        num2 = 1;
      return (int) Math.Round((double) num3 / (double) num2);
    }

    public int GetPowerPointPercentUpgradeableToo(int sftype)
    {
      int unitCounter = this.game.Data.UnitCounter;
      int num1;
      int num2;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index1].PreDef == -1)
        {
          int sfCount = this.game.Data.UnitObj[index1].SFCount;
          for (int index2 = 0; index2 <= sfCount; ++index2)
          {
            int sf = this.game.Data.UnitObj[index1].SFList[index2];
            int type = this.game.Data.SFObj[sf].Type;
            if (this.game.Data.SFTypeObj[type].UpgradeToo == sftype)
              num1 += this.game.Data.SFTypeObj[type].PowerPts * this.game.Data.SFObj[sf].Qty;
            num2 += this.game.Data.SFTypeObj[type].PowerPts * this.game.Data.SFObj[sf].Qty;
          }
        }
      }
      int num3 = num1 * 100;
      if (num2 < 1)
        num2 = 1;
      return (int) Math.Round((double) num3 / (double) num2);
    }

    public int GetlandUnitsUnderHQ(int unr)
    {
      int unitCounter = this.game.Data.UnitCounter;
      int num;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index].HQ == unr && this.game.Data.UnitObj[index].PreDef == -1 & !this.game.Data.UnitObj[index].IsHQ && this.game.HandyFunctionsObj.HasUnitlandSF(unr))
          ++num;
      }
      return num;
    }

    public void InitLandReserves()
    {
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      SimpleList simpleList1 = new SimpleList();
      int saCount1 = this.SACount;
      for (int index = 1; index <= saCount1; ++index)
        this.SAObj[index].LandReservePlan = 0;
      simpleList1 = new SimpleList();
      int num1 = 1;
      while (num1 == 1)
      {
        num1 = 0;
        int num2 = 0;
        SimpleList simpleList2 = new SimpleList();
        int saCount2 = this.SACount;
        for (int index1 = 1; index1 <= saCount2; ++index1)
        {
          if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[this.SAObj[index1].X, this.SAObj[index1].Y].Regime, this.game.Data.Turn) && this.SAObj[index1].ConstitutantCount == 0 & this.SAObj[index1].LandReservePlan == 0)
          {
            int num3 = 9999;
            int num4 = 0;
            int tplanCount = this.TPlanCount;
            for (int index2 = 1; index2 <= tplanCount; ++index2)
            {
              if (this.TPlanObj[index2].Type == 30 && this.HexOA[this.TPlanObj[index2].FromArea.X, this.TPlanObj[index2].FromArea.Y] == this.HexOA[this.SAObj[index1].X, this.SAObj[index1].Y])
              {
                this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), this.TPlanObj[index2].FromArea.X, this.TPlanObj[index2].FromArea.Y, 0, istransfer: true, BridgeAP: 80);
                int num5 = this.game.EditObj.TempValue[0].Value[this.SAObj[index1].X, this.SAObj[index1].Y];
                if (num5 < num3)
                {
                  num4 = index2;
                  num3 = num5;
                }
              }
            }
            if (num4 > 0 & (double) num3 <= (double) this.game.Data.RuleVar[52])
            {
              this.SAObj[index1].LandReservePlan = num4;
            }
            else
            {
              num2 = 1;
              int num6 = 1000;
              int num7 = this.GetClosestFrontlineDistance2(this.SAObj[index1].X, this.SAObj[index1].Y);
              if (num7 > 999)
                num7 = 0;
              int tweight = num6 + num7;
              if (this.game.HandyFunctionsObj.IsHexAirfield(this.SAObj[index1].X, this.SAObj[index1].Y, 0))
                tweight += 200;
              if (this.game.HandyFunctionsObj.IsHexPort(this.SAObj[index1].X, this.SAObj[index1].Y, 0))
                tweight += 100 * this.SAObj[index1].SeaNeighbourCount;
              simpleList2.Add(index1, tweight, index1);
            }
          }
        }
        if (num2 == 1)
        {
          simpleList2.Sort();
          int Number = simpleList2.Data1[simpleList2.Counter];
          this.AddtPlan();
          this.TPlanObj[this.TPlanCount].FromArea = this.SAObj[Number];
          this.TPlanObj[this.TPlanCount].TooArea = (SAClass) null;
          this.TPlanObj[this.TPlanCount].Type = 30;
          this.AddLog("created new PLANLANDRESERVE " + Conversion.Str((object) this.TPlanCount) + " at area# " + Conversion.Str((object) Number));
          num1 = 1;
        }
      }
      int tplanCount1 = this.TPlanCount;
      for (int Number1 = 1; Number1 <= tplanCount1; ++Number1)
      {
        if (this.TPlanObj[Number1].Type == 30)
        {
          SimpleList simpleList3 = new SimpleList();
          int saCount3 = this.SACount;
          for (int index = 1; index <= saCount3; ++index)
          {
            if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[this.SAObj[index].X, this.SAObj[index].Y].Regime, this.game.Data.Turn) && this.SAObj[index].ConstitutantCount == 0 & this.SAObj[index].LandReservePlan == Number1)
            {
              int num8 = 1000;
              int num9 = this.GetClosestFrontlineDistance2(this.SAObj[index].X, this.SAObj[index].Y);
              if (num9 > 999)
                num9 = 0;
              int num10 = num8 + num9;
              if (this.game.HandyFunctionsObj.IsHexAirfield(this.SAObj[index].X, this.SAObj[index].Y, 0))
                num10 += 500;
              if (this.game.HandyFunctionsObj.IsHexPort(this.SAObj[index].X, this.SAObj[index].Y, 0))
                num10 += 100 * this.SAObj[index].SeaNeighbourCount;
              if (this.game.Data.MapObj[0].HexObj[this.SAObj[index].X, this.SAObj[index].Y].Location > -1)
                num10 += this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.SAObj[index].X, this.SAObj[index].Y].Location].Type].MaxProd;
              int tweight = num10 + this.game.Data.MapObj[0].HexObj[this.SAObj[index].X, this.SAObj[index].Y].VP * 100;
              simpleList3.Add(index, tweight, index);
            }
          }
          if (simpleList3.Counter > -1)
          {
            simpleList3.Sort();
            int Number2 = simpleList3.Data1[simpleList3.Counter];
            this.AddLog("Assigned Existing PLANLANDRESERVE " + Conversion.Str((object) Number1) + " the HQ AREA: " + Conversion.Str((object) Number2));
            this.TPlanObj[Number1].FromArea = this.SAObj[Number2];
          }
        }
      }
      int num11 = -1;
      int y1 = -1;
      int num12 = -1;
      SimpleList simpleList4 = new SimpleList();
      int tplanCount2 = this.TPlanCount;
      for (int tid = 1; tid <= tplanCount2; ++tid)
      {
        if (this.TPlanObj[tid].Type == 30)
        {
          this.TPlanObj[tid].ProdPts = 0;
          int saCount4 = this.SACount;
          for (int index3 = 1; index3 <= saCount4; ++index3)
          {
            if (this.SAObj[index3].LandReservePlan == tid && this.game.Data.MapObj[0].HexObj[this.SAObj[index3].X, this.SAObj[index3].Y].Location > -1 && this.game.Data.MapObj[0].HexObj[this.SAObj[index3].X, this.SAObj[index3].Y].Regime == this.game.Data.Turn)
            {
              int type = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.SAObj[index3].X, this.SAObj[index3].Y].Location].Type;
              if (!this.game.Data.LocTypeObj[type].NoHQ)
              {
                AIPlanClass[] tplanObj = this.TPlanObj;
                AIPlanClass[] aiPlanClassArray = tplanObj;
                int index4 = tid;
                int index5 = index4;
                aiPlanClassArray[index5].ProdPts = tplanObj[index4].ProdPts + this.game.Data.LocTypeObj[type].MaxProd;
                if (this.game.Data.LocTypeObj[type].MaxProd > num12)
                {
                  num12 = this.game.Data.LocTypeObj[type].MaxProd;
                  num11 = this.SAObj[index3].X;
                  y1 = this.SAObj[index3].Y;
                }
              }
            }
          }
          if (this.TPlanObj[tid].HQ == -1 & this.TPlanObj[tid].ProdPts > 0)
          {
            this.SetMatrixEnemyFront(this.game.Data.Turn, true);
            simpleList4.Add(tid, this.TPlanObj[tid].ProdPts);
          }
        }
      }
      if (simpleList4.Counter <= -1)
        return;
      int counter = simpleList4.Counter;
      for (int index6 = 0; index6 <= counter; ++index6)
      {
        int x1 = this.TPlanObj[simpleList4.Id[index6]].FromArea.X;
        int y2 = this.TPlanObj[simpleList4.Id[index6]].FromArea.Y;
        SimpleList simpleList5 = new SimpleList();
        this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, (int) Math.Round((double) this.game.Data.RuleVar[51]), x1, y2, 0, SeaBlock: true, BlockAllSea: true);
        int unitCounter = this.game.Data.UnitCounter;
        for (int index7 = 0; index7 <= unitCounter; ++index7)
        {
          if (this.game.Data.UnitObj[index7].AIPlanNr > 0 & this.game.Data.UnitObj[index7].IsHQ & this.game.Data.UnitObj[index7].Regime == this.game.Data.Turn && this.TPlanObj[this.game.Data.UnitObj[index7].AIPlanNr].Type != 30 && (double) this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[index7].X, this.game.Data.UnitObj[index7].Y] <= (double) this.game.Data.RuleVar[53])
          {
            int num13 = 0;
            int num14 = 0;
            int saCount5 = this.SACount;
            for (int index8 = 1; index8 <= saCount5; ++index8)
            {
              if (this.SAObj[index8].LandReservePlan == simpleList4.Id[index6] && this.game.Data.MapObj[0].HexObj[this.SAObj[index8].X, this.SAObj[index8].Y].Location > -1 && this.game.Data.MapObj[0].HexObj[this.SAObj[index8].X, this.SAObj[index8].Y].Regime == this.game.Data.Turn && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.SAObj[index8].X, this.SAObj[index8].Y].Location].Type].MaxProd > 0)
              {
                if (this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.SAObj[index8].X, this.SAObj[index8].Y].Location].HQ == index7)
                {
                  ++num13;
                  if (this.game.Data.Round == 1)
                    ++num13;
                }
                ++num14;
              }
            }
            int num15 = 0;
            if (num13 > 0)
              num15 = (int) Math.Round((double) (-2 * this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[index7].X, this.game.Data.UnitObj[index7].Y]) * ((double) num13 / (double) num14));
            int num16 = num15 - 150 * num13 + 10 * this.GetlandUnitsUnderHQ(index7) - 5 * this.GetClosestFrontlineDistance2(this.game.Data.UnitObj[index7].X, this.game.Data.UnitObj[index7].Y);
            int num17 = 1;
            if (!this.game.HandyFunctionsObj.IsHexAirfield(this.game.Data.UnitObj[index7].X, this.game.Data.UnitObj[index7].Y, 0))
              num17 = 0;
            if (num17 == 1)
              simpleList5.Add(index7, num16 + this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[index7].X, this.game.Data.UnitObj[index7].Y], this.game.Data.UnitObj[index7].AIPlanNr);
          }
        }
        if (simpleList5.Counter > -1)
        {
          simpleList5.Sort();
          this.TPlanObj[simpleList4.Id[index6]].HQ = simpleList5.Id[0];
          this.AddLog("Set HQ for LANDRESERVE to " + this.game.Data.UnitObj[simpleList5.Id[0]].Name);
          if (this.TPlanObj[simpleList5.Data1[0]].HQ == simpleList5.Id[0])
            this.TPlanObj[simpleList5.Data1[0]].HQ = -1;
          this.game.Data.UnitObj[simpleList5.Id[0]].AIPlanNr = simpleList4.Id[index6];
          AIPlanClass[] tplanObj1 = this.TPlanObj;
          AIPlanClass[] aiPlanClassArray1 = tplanObj1;
          int[] data1 = simpleList5.Data1;
          int[] numArray2 = data1;
          int index9 = 0;
          int index10 = index9;
          int index11 = numArray2[index10];
          aiPlanClassArray1[index11].FriendlyUnitCount = tplanObj1[data1[index9]].FriendlyUnitCount - 1;
          AIPlanClass[] tplanObj2 = this.TPlanObj;
          AIPlanClass[] aiPlanClassArray2 = tplanObj2;
          int[] id = simpleList4.Id;
          int[] numArray3 = id;
          int index12 = index6;
          int index13 = index12;
          int index14 = numArray3[index13];
          aiPlanClassArray2[index14].FriendlyUnitCount = tplanObj2[id[index12]].FriendlyUnitCount + 1;
        }
        else
        {
          int x2;
          if ((double) this.game.Data.RuleVar[863] != 0.0)
          {
            RegimeClass[] regimeObj = this.game.Data.RegimeObj;
            RegimeClass[] regimeClassArray = regimeObj;
            int turn = this.game.Data.Turn;
            int index15 = turn;
            regimeClassArray[index15].ResPts = (int) Math.Round((double) ((float) regimeObj[turn].ResPts + this.game.Data.RuleVar[47]));
            x2 = x1;
            y1 = y2;
          }
          else if ((double) this.game.Data.RuleVar[47] > (double) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts)
          {
            RegimeClass[] regimeObj = this.game.Data.RegimeObj;
            RegimeClass[] regimeClassArray = regimeObj;
            int turn = this.game.Data.Turn;
            int index16 = turn;
            regimeClassArray[index16].AISavedPP = (int) Math.Round((double) ((float) regimeObj[turn].AISavedPP - this.game.Data.RuleVar[47]));
            if (this.game.Data.RegimeObj[this.game.Data.Turn].AISavedPP < 0)
              this.game.Data.RegimeObj[this.game.Data.Turn].AISavedPP = 0;
            x2 = x1;
            y1 = y2;
          }
          else
            x2 = -1;
          if (x2 > -1)
          {
            this.game.ProcessingObj.NewUnit(x2, y1, 0, true, this.game.Data.Turn);
            this.game.Data.UnitObj[this.game.Data.UnitCounter].Name = this.game.HandyFunctionsObj.GetHexName(x2, y1, 0) + " HQ";
            this.game.Data.UnitObj[this.game.Data.UnitCounter].AIPlanNr = simpleList4.Id[index6];
            this.TPlanObj[simpleList4.Id[index6]].HQ = this.game.Data.UnitCounter;
            this.AddLog("Set NEWLY CREATED HQ for LANDRESERVE to " + this.game.Data.UnitObj[this.game.Data.UnitCounter].Name);
            AIPlanClass[] tplanObj = this.TPlanObj;
            AIPlanClass[] aiPlanClassArray = tplanObj;
            int[] id = simpleList4.Id;
            int[] numArray4 = id;
            int index17 = index6;
            int index18 = index17;
            int index19 = numArray4[index18];
            aiPlanClassArray[index19].FriendlyUnitCount = tplanObj[id[index17]].FriendlyUnitCount + 1;
            RegimeClass[] regimeObj = this.game.Data.RegimeObj;
            RegimeClass[] regimeClassArray = regimeObj;
            int turn = this.game.Data.Turn;
            int index20 = turn;
            regimeClassArray[index20].ResPts = (int) Math.Round((double) ((float) regimeObj[turn].ResPts + this.game.Data.RuleVar[47]));
          }
        }
      }
    }

    public int GetLandForcesNearHex(bool friendly, int dist, int x, int y)
    {
      int landForcesNearHex = 0;
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          int num = 0;
          if (friendly & this.game.Data.MapObj[0].HexObj[index1, index2].Regime == this.game.Data.Turn)
            num = 1;
          if (!friendly & this.game.Data.MapObj[0].HexObj[index1, index2].Regime > -1 && this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[this.game.Data.MapObj[0].HexObj[index1, index2].Regime] == 0)
            num = 1;
          if (num == 1 && this.game.HandyFunctionsObj.Distance(x, y, 0, index1, index2, 0) <= dist)
            landForcesNearHex += this.GetHexForceLandStrength(index1, index2);
        }
      }
      return landForcesNearHex;
    }

    public void InitPlanLevelAnalysis()
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      float aiConservative = this.game.Data.RegimeObj[this.game.Data.Turn].AIConservative;
      int tplanCount = this.TPlanCount;
      for (int plannr = 1; plannr <= tplanCount; ++plannr)
      {
        if (this.TPlanObj[plannr].Type == 20)
        {
          int num1 = (int) Math.Round(Conversion.Int((double) (int) Math.Round((double) ((float) this.GetRealForceInArea(this.GetAreaNr(this.TPlanObj[plannr].FromArea), plannr, false) + this.TPlanObj[plannr].WeightFriendlyForce)) / 2.0));
          int num2 = (int) Math.Round((double) this.TPlanObj[plannr].WeightEnemyForceUnMod);
          if ((double) this.TPlanObj[plannr].WeightEnemyForce < (double) num2)
            num2 = (int) Math.Round((double) this.TPlanObj[plannr].WeightEnemyForce);
          int index = this.game.Data.MapObj[0].HexObj[this.TPlanObj[plannr].TooArea.X, this.TPlanObj[plannr].TooArea.Y].Regime;
          int num3 = -1;
          if (index < 0)
          {
            index = 0;
            num3 = 1;
          }
          if (num3 == -1 & this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[index] > 0)
            this.TPlanObj[plannr].Stand = 2;
          else if ((double) num2 * (double) aiConservative < (double) num1)
            this.TPlanObj[plannr].Stand = 1;
          else if ((double) num2 * (double) aiConservative / 2.0 > (double) num1)
          {
            if ((double) num2 * (double) aiConservative / 4.0 > (double) num1)
            {
              int num4 = 1;
              int areaNr = this.GetAreaNr(this.TPlanObj[plannr].FromArea);
              if (this.SAObj[areaNr].LandReservePlan > 0 && this.GetAreaNr(this.TPlanObj[this.SAObj[areaNr].LandReservePlan].FromArea) == areaNr)
                num4 = 0;
              if (num4 == 1 && this.GetFriendlyAreaNeighbours(areaNr, true) < 1)
                num4 = 0;
              if (num4 == 1 && this.SAObj[areaNr].aivp > this.GetAverageAIVP())
                num4 = 0;
              if ((double) this.TPlanObj[plannr].WeightFriendlyForce * 2.0 > (double) this.TPlanObj[plannr].WeightEnemyForce)
                num4 = 1;
              this.TPlanObj[plannr].Stand = num4 != 1 ? 2 : 3;
            }
            else
              this.TPlanObj[plannr].Stand = 2;
          }
          else
            this.TPlanObj[plannr].Stand = 2;
        }
        else if (this.TPlanObj[plannr].Type == 40)
        {
          if (this.TPlanObj[plannr].FromArea.SeaNeighbourCount > 0)
          {
            if (this.TPlanObj[plannr].SeaStand == 0 | this.TPlanObj[plannr].SeaStand == 5 | this.TPlanObj[plannr].SeaStand == 4)
              this.TPlanObj[plannr].SeaStand = (double) this.TPlanObj[plannr].FriendlyNavy / 2.0 < (double) this.TPlanObj[plannr].EnemyNavy ? (this.TPlanObj[plannr].FriendlyNavy < this.TPlanObj[plannr].EnemyNavy ? ((double) this.TPlanObj[plannr].FriendlyNavy < (double) this.TPlanObj[plannr].EnemyNavy / 4.0 ? 4 : 5) : 6) : 7;
            else if (this.TPlanObj[plannr].SeaStand == 7)
              this.TPlanObj[plannr].SeaStand = this.TPlanObj[plannr].FriendlyNavy < this.TPlanObj[plannr].EnemyNavy ? ((double) this.TPlanObj[plannr].FriendlyNavy < (double) this.TPlanObj[plannr].EnemyNavy / 2.0 ? ((double) this.TPlanObj[plannr].FriendlyNavy < (double) this.TPlanObj[plannr].EnemyNavy / 8.0 ? 4 : 5) : 6) : 7;
            else if (this.TPlanObj[plannr].SeaStand == 6)
              this.TPlanObj[plannr].SeaStand = (double) this.TPlanObj[plannr].FriendlyNavy / 2.0 < (double) this.TPlanObj[plannr].EnemyNavy ? ((double) this.TPlanObj[plannr].FriendlyNavy < (double) this.TPlanObj[plannr].EnemyNavy / 2.0 ? ((double) this.TPlanObj[plannr].FriendlyNavy < (double) this.TPlanObj[plannr].EnemyNavy / 4.0 ? 4 : 5) : 6) : 7;
            if (this.getfrontplan(this.TPlanObj[plannr].FromArea.X, this.TPlanObj[plannr].FromArea.Y) > 0)
            {
              if (this.TPlanObj[plannr].SeaStand == 4)
                this.TPlanObj[plannr].SeaStand = 5;
              else if (this.TPlanObj[plannr].SeaStand == 5)
                this.TPlanObj[plannr].SeaStand = 6;
            }
            if (this.TPlanObj[plannr].FriendlyNavy + this.TPlanObj[plannr].FriendlyAir <= 0)
              ;
          }
          else
            this.TPlanObj[plannr].Stand = 2;
          if ((double) this.game.Data.RuleVar[252] > 0.0)
          {
            int closestFrontline = this.GetClosestFrontline(this.TPlanObj[plannr].FromArea.X, this.TPlanObj[plannr].FromArea.Y);
            if (closestFrontline > 0)
            {
              int num = this.AreaDistance(this.GetAreaNr(this.TPlanObj[plannr].FromArea), this.GetAreaNr(this.TPlanObj[closestFrontline].FromArea), true);
              if (num > 0 & (double) num <= (double) this.game.Data.RuleVar[252])
              {
                if (this.TPlanObj[closestFrontline].Stand != 1)
                  this.TPlanObj[plannr].AssemblyArea = 1;
                else if (this.TPlanObj[plannr].FromArea.SeaNeighbourCount < 1)
                {
                  int unitCounter = this.game.Data.UnitCounter;
                  for (int index = 0; index <= unitCounter; ++index)
                  {
                    if (this.game.Data.UnitObj[index].AIPlanNr == plannr && this.game.Data.UnitObj[index].AIUnitGoal == 1 | this.game.Data.UnitObj[index].AIUnitGoal == 2 && this.game.Data.Turn == this.game.Data.UnitObj[index].Regime & this.game.Data.UnitObj[index].PreDef == -1)
                    {
                      this.game.Data.UnitObj[index].AIPlanNr = -1;
                      this.game.Data.UnitObj[index].AIReserve = false;
                    }
                  }
                }
              }
            }
          }
          if ((double) this.game.Data.RuleVar[256] > 0.0 && this.game.Data.MapObj[0].HexObj[this.TPlanObj[plannr].FromArea.X, this.TPlanObj[plannr].FromArea.Y].Location > -1 && this.game.HandyFunctionsObj.CanLocProduce(this.game.Data.MapObj[0].HexObj[this.TPlanObj[plannr].FromArea.X, this.TPlanObj[plannr].FromArea.Y].Location, this.game.Data.Turn) && (double) this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.TPlanObj[plannr].FromArea.X, this.TPlanObj[plannr].FromArea.Y].Location].Type].MaxProd >= (double) this.game.Data.RuleVar[256])
            this.TPlanObj[plannr].AssemblyArea = 1;
        }
      }
    }

    public int GetAverageAIVP()
    {
      if (this.SACount <= 0)
        return 0;
      int saCount = this.SACount;
      int num;
      for (int index = 1; index <= saCount; ++index)
        num += this.SAObj[index].aivp;
      int averageAivp = (int) Math.Round((double) num / (double) this.SACount);
      if (0 > averageAivp)
        averageAivp = 0;
      return averageAivp;
    }

    public void InitTPlanForceBalance()
    {
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[] numArray2 = new int[this.SACount + 1];
      int[] numArray3 = new int[this.SACount + 1];
      int[] numArray4 = new int[this.SACount + 1];
      int[] numArray5 = new int[this.SACount + 1];
      int saCount = this.SACount;
      for (int index1 = 1; index1 <= saCount; ++index1)
      {
        int tplanCount = this.TPlanCount;
        for (int index2 = 1; index2 <= tplanCount; ++index2)
        {
          if (this.TPlanObj[index2].Type == 20 && this.TPlanObj[index2].TooArea.X == this.SAObj[index1].X & this.TPlanObj[index2].TooArea.Y == this.SAObj[index1].Y)
          {
            int mapWidth = this.game.Data.MapObj[0].MapWidth;
            for (int index3 = 0; index3 <= mapWidth; ++index3)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index4 = 0; index4 <= mapHeight; ++index4)
              {
                if (this.HexSA[index3, index4] > 0 & !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index3, index4].LandscapeType].IsSea && this.SAObj[this.HexSA[index3, index4]].X == this.TPlanObj[index2].FromArea.X & this.SAObj[this.HexSA[index3, index4]].Y == this.TPlanObj[index2].FromArea.Y && this.HexPlan[index3, index4] == index2)
                {
                  int[] numArray6 = numArray4;
                  int[] numArray7 = numArray6;
                  int index5 = index1;
                  int index6 = index5;
                  int num = numArray6[index5] + 1;
                  numArray7[index6] = num;
                }
              }
            }
          }
        }
        if (numArray4[index1] == 0)
          numArray4[index1] = 1;
        int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
        for (int index7 = 0; index7 <= mapWidth1; ++index7)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index8 = 0; index8 <= mapHeight; ++index8)
          {
            if (this.HexSA[index7, index8] == index1 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index7, index8].LandscapeType].IsSea)
            {
              int unitCounter = this.game.Data.MapObj[0].HexObj[index7, index8].UnitCounter;
              for (int index9 = 0; index9 <= unitCounter; ++index9)
              {
                int[] numArray8 = numArray2;
                int[] numArray9 = numArray8;
                int index10 = index1;
                int index11 = index10;
                int num1 = numArray8[index10] + this.GetForceLandStrength(this.game.Data.MapObj[0].HexObj[index7, index8].UnitList[index9]);
                numArray9[index11] = num1;
                int[] numArray10 = numArray3;
                int[] numArray11 = numArray10;
                int index12 = index1;
                int index13 = index12;
                int num2 = numArray10[index12] + this.GetForceLandStrength(this.game.Data.MapObj[0].HexObj[index7, index8].UnitList[index9], true);
                numArray11[index13] = num2;
                int[] numArray12 = numArray5;
                int[] numArray13 = numArray12;
                int index14 = index1;
                int index15 = index14;
                int num3 = numArray12[index14] + 1;
                numArray13[index15] = num3;
              }
            }
          }
        }
      }
      int tplanCount1 = this.TPlanCount;
      for (int index = 1; index <= tplanCount1; ++index)
      {
        int num4 = 0;
        int num5 = 0;
        float num6 = 0.0f;
        float num7 = 0.0f;
        int unitCounter = this.game.Data.UnitCounter;
        for (int unr = 0; unr <= unitCounter; ++unr)
        {
          if (this.game.Data.UnitObj[unr].AIPlanNr == index & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && !this.game.Data.UnitObj[unr].IsHQ && this.game.Data.UnitObj[unr].AIUnitGoal != 4)
          {
            num4 += this.GetForceLandStrength(unr);
            ++num5;
          }
        }
        if (this.TPlanObj[index].Type == 20)
        {
          int areaNr = this.GetAreaNr(this.TPlanObj[index].TooArea);
          num6 = (float) numArray2[areaNr] * ((float) this.TPlanObj[index].FrontSize / (float) numArray4[areaNr]);
          num7 = (float) numArray3[areaNr] * ((float) this.TPlanObj[index].FrontSize / (float) numArray4[areaNr]);
          if (this.game.Data.MapObj[0].HexObj[this.TPlanObj[index].TooArea.X, this.TPlanObj[index].TooArea.Y].Regime > -1 && this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[this.game.Data.MapObj[0].HexObj[this.TPlanObj[index].TooArea.X, this.TPlanObj[index].TooArea.Y].Regime] > 0)
          {
            num6 *= this.game.Data.RuleVar[246];
            num7 *= this.game.Data.RuleVar[246];
          }
          this.TPlanObj[index].EnemyUnitCount = numArray5[areaNr];
        }
        if ((double) num6 > 99999.0)
          num6 = 99999f;
        if ((double) num7 > 99999.0)
          num7 = 99999f;
        this.TPlanObj[index].WeightFriendlyForce = (float) num4;
        this.TPlanObj[index].FriendlyUnitCount = num5;
        this.TPlanObj[index].WeightEnemyForce = num6;
        this.TPlanObj[index].WeightEnemyForceUnMod = num7;
      }
    }

    public void InitTPlanForceBalanceNavy()
    {
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[] numArray2 = new int[this.SACount + 1];
      int[] numArray3 = new int[this.SACount + 1];
      int[] numArray4 = new int[this.SACount + 1];
      int[] numArray5 = new int[this.SACount + 1];
      int tplanCount1 = this.TPlanCount;
      for (int index1 = 1; index1 <= tplanCount1; ++index1)
      {
        if (this.TPlanObj[index1].Type == 40)
        {
          int navalTarget = this.GetNavalTarget(index1);
          if (navalTarget > 0)
            this.TPlanObj[index1].SeaTarget = navalTarget;
          this.TPlanObj[index1].FriendlyNavy = this.GetRealNavalForceInArea(-1, index1, true, true);
          this.TPlanObj[index1].EnemyNavy = this.GetRealNavalForceInArea(this.GetAreaNr(this.TPlanObj[index1].FromArea), index1, true, false);
          if (navalTarget > 0)
          {
            AIPlanClass[] tplanObj = this.TPlanObj;
            AIPlanClass[] aiPlanClassArray = tplanObj;
            int index2 = index1;
            int index3 = index2;
            aiPlanClassArray[index3].EnemyNavy = tplanObj[index2].EnemyNavy + this.GetRealNavalForceInArea(navalTarget, index1, true, false);
          }
          int tplanCount2 = this.TPlanCount;
          for (int index4 = 1; index4 <= tplanCount2; ++index4)
          {
            if (this.TPlanObj[index4].Type != 40)
              ;
          }
        }
      }
      int tplanCount3 = this.TPlanCount;
      for (int index5 = 1; index5 <= tplanCount3; ++index5)
      {
        if (this.TPlanObj[index5].Type == 40)
        {
          int tplanCount4 = this.TPlanCount;
          for (int plannr = 1; plannr <= tplanCount4; ++plannr)
          {
            if (this.TPlanObj[plannr].Type == 40 && plannr != index5 && this.TPlanObj[index5].SeaTarget == this.TPlanObj[plannr].SeaTarget && this.TPlanObj[index5].SeaTarget > 0)
            {
              AIPlanClass[] tplanObj = this.TPlanObj;
              AIPlanClass[] aiPlanClassArray = tplanObj;
              int index6 = index5;
              int index7 = index6;
              aiPlanClassArray[index7].FriendlyNavy = tplanObj[index6].FriendlyNavy + this.GetRealNavalForceInArea(-1, plannr, true, true);
            }
          }
        }
      }
    }

    public void InitEmergencyUnitSwitch()
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.AddLog("");
      this.AddLog("EMERGENCY SWITCHES:");
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        this.game.Data.UnitObj[index].AICutoff = 0;
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index].AIPlanNr > 0)
        {
          int aiPlanNr = this.game.Data.UnitObj[index].AIPlanNr;
          if (this.TPlanObj[aiPlanNr].Type == 20 && this.game.Data.UnitObj[index].SupplyInReq > 0 && this.game.Data.UnitObj[index].SupplyIn == 0 && this.SAObj[this.GetAreaNr(this.TPlanObj[aiPlanNr].FromArea)].LandReservePlan > 0 && this.HexSA[this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y] != this.GetAreaNr(this.TPlanObj[aiPlanNr].FromArea))
          {
            this.game.Data.UnitObj[index].AICutoff = 1;
            this.AddLog("Cutten off unit:" + this.game.Data.UnitObj[index].Name);
          }
        }
      }
    }

    public void InitUnits()
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.AddLog("");
      this.AddLog("Consistency in planning. Assign units back to last plan if possible:");
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        this.game.Data.UnitObj[index].AIPlanNr = 0;
        if (this.game.Data.UnitObj[index].PreDef == -1 & this.game.Data.UnitObj[index].Regime == this.game.Data.Turn)
          this.game.Data.UnitObj[index].AIPlanNr = 0;
      }
      int unitCounter2 = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter2; ++index1)
      {
        if (this.game.Data.UnitObj[index1].PreDef == -1 & this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index1].AIPlanRef != null)
        {
          this.AddLog("evaluating: " + this.game.Data.UnitObj[index1].Name);
          this.AddLog("FromArea:#" + Conversion.Str((object) this.WhichCurrentAreaIsThis(ref this.game.Data.UnitObj[index1].AIPlanRef.FromArea)));
          if (this.game.Data.UnitObj[index1].AIPlanRef.TooArea != null)
            this.AddLog("TooArea:#" + Conversion.Str((object) this.WhichCurrentAreaIsThis(ref this.game.Data.UnitObj[index1].AIPlanRef.TooArea)));
          int tplanCount1 = this.TPlanCount;
          for (int Number = 1; Number <= tplanCount1; ++Number)
          {
            if (this.TPlanObj[Number].Type == this.game.Data.UnitObj[index1].AIPlanRef.Type)
            {
              if (this.TPlanObj[Number].Type == 20 && this.GetAreaNr(this.TPlanObj[Number].FromArea) == this.WhichCurrentAreaIsThis(ref this.game.Data.UnitObj[index1].AIPlanRef.FromArea) && this.GetAreaNr(this.TPlanObj[Number].TooArea) == this.WhichCurrentAreaIsThis(ref this.game.Data.UnitObj[index1].AIPlanRef.TooArea))
              {
                this.game.Data.UnitObj[index1].AIPlanNr = Number;
                this.TPlanObj[Number].HQ = this.game.Data.UnitObj[index1].AIPlanRef.HQ;
                this.AddLog(this.game.Data.UnitObj[index1].Name + " to LANDFRONT plan# " + Conversion.Str((object) Number));
              }
              if (this.TPlanObj[Number].Type == 40 && this.GetAreaNr(this.TPlanObj[Number].FromArea) == this.WhichCurrentAreaIsThis(ref this.game.Data.UnitObj[index1].AIPlanRef.FromArea))
              {
                this.game.Data.UnitObj[index1].AIPlanNr = Number;
                this.TPlanObj[Number].CurrentBackRoad = this.game.Data.UnitObj[index1].AIPlanRef.CurrentBackRoad;
                this.TPlanObj[Number].HQ = this.game.Data.UnitObj[index1].AIPlanRef.HQ;
                this.TPlanObj[Number].SeaStand = this.game.Data.UnitObj[index1].AIPlanRef.SeaStand;
                this.TPlanObj[Number].SeaTarget = this.game.Data.UnitObj[index1].AIPlanRef.SeaTarget;
                this.AddLog(this.game.Data.UnitObj[index1].Name + " to BACK plan# " + Conversion.Str((object) Number));
              }
            }
          }
          int tplanCount2 = this.TPlanCount;
          for (int index2 = 1; index2 <= tplanCount2; ++index2)
          {
            if (this.game.Data.UnitObj[index1].AIUnitGoal == 4 & this.game.Data.UnitObj[index1].AIPlanNr < 1 && this.game.Data.UnitObj[index1].AIPlanRef.Type == 20 | this.game.Data.UnitObj[index1].AIPlanRef.Type == 50 && this.AreaDistance(this.WhichCurrentAreaIsThis(ref this.game.Data.UnitObj[index1].AIPlanRef.TooArea), this.WhichCurrentAreaIsThis(ref this.game.Data.UnitObj[index1].AIPlanRef.FromArea)) == 1)
            {
              int x1 = this.game.Data.UnitObj[index1].X;
              int y1 = this.game.Data.UnitObj[index1].Y;
              int x2 = this.SAObj[this.WhichCurrentAreaIsThis(ref this.game.Data.UnitObj[index1].AIPlanRef.TooArea)].X;
              int y2 = this.SAObj[this.WhichCurrentAreaIsThis(ref this.game.Data.UnitObj[index1].AIPlanRef.TooArea)].Y;
              if (!(x1 == x2 & y1 == y2))
              {
                this.AddtPlan();
                this.TPlanObj[this.TPlanCount].Type = 50;
                this.TPlanObj[this.TPlanCount].FromArea = this.SAObj[this.WhichCurrentAreaIsThis(ref this.game.Data.UnitObj[index1].AIPlanRef.FromArea)];
                this.TPlanObj[this.TPlanCount].TooArea = this.SAObj[this.WhichCurrentAreaIsThis(ref this.game.Data.UnitObj[index1].AIPlanRef.TooArea)];
                this.game.Data.UnitObj[index1].AIPlanNr = this.TPlanCount;
              }
            }
          }
          if (this.game.Data.UnitObj[index1].AIPlanNr == 0)
          {
            int tplanCount3 = this.TPlanCount;
            for (int Number = 1; Number <= tplanCount3; ++Number)
            {
              if (this.TPlanObj[Number].Type == this.game.Data.UnitObj[index1].AIPlanRef.Type && this.TPlanObj[Number].Type == 20 && this.GetAreaNr(this.TPlanObj[Number].FromArea) == this.HexSA[this.game.Data.UnitObj[index1].X, this.game.Data.UnitObj[index1].Y] && this.GetAreaNr(this.TPlanObj[Number].TooArea) == this.WhichCurrentAreaIsThis(ref this.game.Data.UnitObj[index1].AIPlanRef.TooArea))
              {
                this.game.Data.UnitObj[index1].AIPlanNr = Number;
                if (this.TPlanObj[Number].HQ == -1)
                  this.TPlanObj[Number].HQ = this.game.Data.UnitObj[index1].AIPlanRef.HQ;
                this.AddLog(this.game.Data.UnitObj[index1].Name + " to almost same plan# " + Conversion.Str((object) Number));
              }
            }
          }
          if (this.game.Data.UnitObj[index1].AIPlanNr == 0 && this.game.Data.UnitObj[index1].AIPlanRef.Type != 20 && this.game.Data.UnitObj[index1].AIPlanRef.Type == 30 && this.WhichCurrentAreaIsThis(ref this.game.Data.UnitObj[index1].AIPlanRef.FromArea) > 0)
          {
            this.AddtPlan();
            this.TPlanObj[this.TPlanCount] = this.game.Data.UnitObj[index1].AIPlanRef;
            this.TPlanObj[this.TPlanCount].FromArea = this.SAObj[this.WhichCurrentAreaIsThis(ref this.TPlanObj[this.TPlanCount].FromArea)];
            this.game.Data.UnitObj[index1].AIPlanNr = this.TPlanCount;
            this.AddLog("Initiated LANDRESERVEPLAN from memory by " + this.game.Data.UnitObj[index1].Name + " to plan# " + Conversion.Str((object) this.TPlanCount));
          }
        }
      }
      int unitCounter3 = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter3; ++unr)
      {
        if (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn)
        {
          int aiPlanNr = this.game.Data.UnitObj[unr].AIPlanNr;
          if (aiPlanNr > 0 && this.TPlanObj[aiPlanNr].Type == 40 & this.TPlanObj[aiPlanNr].SeaTarget > 0 && this.game.Data.UnitObj[unr].X > -1 && !this.game.HandyFunctionsObj.HasUnitNavySF(unr) & !this.game.HandyFunctionsObj.HasUnitAirSF(unr) && this.game.HandyFunctionsObj.HasUnitlandSF(unr) && this.HexSA[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] != this.GetAreaNr(this.TPlanObj[aiPlanNr].FromArea))
          {
            int tplanCount = this.TPlanCount;
            for (int index = 1; index <= tplanCount; ++index)
            {
              if (this.TPlanObj[index].Type == 20 && this.GetAreaNr(this.TPlanObj[index].FromArea) == this.HexSA[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] && this.GetAreaNr(this.TPlanObj[index].TooArea) == this.TPlanObj[aiPlanNr].SeaTarget)
              {
                this.game.Data.UnitObj[unr].AIPlanNr = index;
                break;
              }
            }
          }
        }
      }
      int unitCounter4 = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter4; ++unr)
      {
        if (this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unr].AIPlanNr == 0)
        {
          if (this.game.HandyFunctionsObj.HasUnitAirSF(unr))
          {
            int closestBackPlan = this.GetClosestBackPlan(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y);
            this.game.Data.UnitObj[unr].AIPlanNr = closestBackPlan;
          }
          else if (this.game.HandyFunctionsObj.HasUnitNavySF(unr))
          {
            int closestBackPlan = this.GetClosestBackPlan(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y);
            this.game.Data.UnitObj[unr].AIPlanNr = closestBackPlan;
          }
          else
          {
            int num = this.GetClosestFrontline(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y);
            if (num < 1)
              num = this.GetClosestBackPlan(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y);
            this.game.Data.UnitObj[unr].AIPlanNr = num;
          }
        }
      }
      int unitCounter5 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter5; ++index)
      {
        if (this.game.Data.UnitObj[index].PreDef == -1 & this.game.Data.UnitObj[index].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index].AIPlanNr > 0 & this.game.Data.UnitObj[index].X > -1 && this.TPlanObj[this.game.Data.UnitObj[index].AIPlanNr].Type == 20)
          this.game.Data.UnitObj[index].AIReserve = false;
      }
    }

    public void BlowBridges()
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      if ((double) this.game.Data.RuleVar[245] < 1.0)
        return;
      int tplanCount1 = this.TPlanCount;
      for (int plnr = 1; plnr <= tplanCount1; ++plnr)
      {
        if (this.TPlanObj[plnr].Type == 20 && this.TPlanObj[plnr].Stand == 2 && this.TPlanObj[plnr].RiverLine > 0)
        {
          int num1 = 1;
          int tplanCount2 = this.TPlanCount;
          for (int index = 1; index <= tplanCount2; ++index)
          {
            if (this.TPlanObj[index].Type == 20 && this.TPlanObj[index].Stand == 1 && this.GetAreaNr(this.TPlanObj[index].TooArea) == this.GetAreaNr(this.TPlanObj[plnr].TooArea))
              num1 = 0;
          }
          if (num1 == 1 && (double) this.GivePercentBehindRiver(plnr) >= 0.75)
          {
            int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
            for (int index1 = 0; index1 <= mapWidth1; ++index1)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index2 = 0; index2 <= mapHeight; ++index2)
              {
                if (this.HexSA[index1, index2] == this.GetAreaNr(this.TPlanObj[plnr].TooArea) && this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter > -1)
                  numArray[index1, index2] = 1;
              }
            }
            int num2 = 1;
            Coordinate coordinate;
            while (num2 == 1)
            {
              num2 = 0;
              int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
              for (int index3 = 0; index3 <= mapWidth2; ++index3)
              {
                int mapHeight = this.game.Data.MapObj[0].MapHeight;
                for (int index4 = 0; index4 <= mapHeight; ++index4)
                {
                  if (numArray[index3, index4] == 1)
                  {
                    int tfacing = 1;
                    do
                    {
                      coordinate = this.game.HandyFunctionsObj.HexNeighbour(index3, index4, 0, tfacing);
                      if (coordinate.onmap && this.HexSA[coordinate.x, coordinate.y] == this.GetAreaNr(this.TPlanObj[plnr].FromArea) | this.HexSA[coordinate.x, coordinate.y] == this.GetAreaNr(this.TPlanObj[plnr].TooArea) && this.game.Data.MapObj[0].HexObj[index3, index4].RiverType[tfacing - 1] == -1 & this.game.HandyFunctionsObj.MoveApCostPreview2(index3, index4, this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, index3, index4, 0, coordinate.x, coordinate.y, 0, false).x < 9999 && numArray[coordinate.x, coordinate.y] == 0)
                      {
                        numArray[coordinate.x, coordinate.y] = 1;
                        num2 = 1;
                      }
                      ++tfacing;
                    }
                    while (tfacing <= 6);
                  }
                }
              }
            }
            int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
            for (int index5 = 0; index5 <= mapWidth3; ++index5)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index6 = 0; index6 <= mapHeight; ++index6)
              {
                if (numArray[index5, index6] == 0)
                {
                  int tfacing = 1;
                  do
                  {
                    coordinate = this.game.HandyFunctionsObj.HexNeighbour(index5, index6, 0, tfacing);
                    if (coordinate.onmap && numArray[coordinate.x, coordinate.y] == 1 && this.game.Data.MapObj[0].HexObj[index5, index6].Regime == this.game.Data.Turn && this.game.Data.MapObj[0].HexObj[index5, index6].RiverType[tfacing - 1] > -1 && this.game.Data.MapObj[0].HexObj[index5, index6].Bridge[tfacing - 1])
                    {
                      this.game.Data.MapObj[0].HexObj[index5, index6].Bridge[tfacing - 1] = false;
                      int num3 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index5, index6, 0);
                      this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Bridge[num3 - 1] = false;
                    }
                    ++tfacing;
                  }
                  while (tfacing <= 6);
                }
              }
            }
          }
        }
      }
    }

    public void setrivermatrix(int plnr)
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int index1 = plnr;
      Coordinate coordinate;
      if (this.TPlanObj[index1].Type == 20 && this.TPlanObj[index1].Stand == 2 && this.TPlanObj[index1].FromArea.ConstitutantCount == 0)
      {
        int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
        for (int index2 = 0; index2 <= mapWidth1; ++index2)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; ++index3)
          {
            if (this.HexSA[index2, index3] == this.GetAreaNr(this.TPlanObj[index1].TooArea) && this.game.Data.MapObj[0].HexObj[index2, index3].UnitCounter > -1)
              numArray[index2, index3] = 1;
          }
        }
        int num = 1;
        while (num == 1)
        {
          num = 0;
          int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
          for (int index4 = 0; index4 <= mapWidth2; ++index4)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index5 = 0; index5 <= mapHeight; ++index5)
            {
              if (numArray[index4, index5] == 1)
              {
                int tfacing = 1;
                do
                {
                  coordinate = this.game.HandyFunctionsObj.HexNeighbour(index4, index5, 0, tfacing);
                  if (coordinate.onmap && this.HexSA[coordinate.x, coordinate.y] == this.GetAreaNr(this.TPlanObj[index1].FromArea) | this.HexSA[coordinate.x, coordinate.y] == this.GetAreaNr(this.TPlanObj[index1].TooArea) && this.game.Data.MapObj[0].HexObj[index4, index5].RiverType[tfacing - 1] == -1 & this.game.HandyFunctionsObj.MoveApCostPreview2(index4, index5, this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, index4, index5, 0, coordinate.x, coordinate.y, 0, false).x < 9999 && numArray[coordinate.x, coordinate.y] == 0)
                  {
                    numArray[coordinate.x, coordinate.y] = 1;
                    num = 1;
                  }
                  ++tfacing;
                }
                while (tfacing <= 6);
              }
            }
          }
        }
      }
      int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
      for (int index6 = 0; index6 <= mapWidth3; ++index6)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index7 = 0; index7 <= mapHeight; ++index7)
          this.Matrix1[index6, index7] = 0;
      }
      int num1 = 0;
      int num2 = 0;
      int mapWidth4 = this.game.Data.MapObj[0].MapWidth;
      for (int index8 = 0; index8 <= mapWidth4; ++index8)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index9 = 0; index9 <= mapHeight; ++index9)
        {
          if (this.HexSA[index8, index9] == this.GetAreaNr(this.TPlanObj[index1].FromArea) && numArray[index8, index9] == 0)
          {
            int num3 = 0;
            int tfacing = 1;
            do
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbour(index8, index9, 0, tfacing);
              if (coordinate.onmap && this.HexSA[coordinate.x, coordinate.y] == this.GetAreaNr(this.TPlanObj[index1].TooArea) | this.HexSA[coordinate.x, coordinate.y] == this.GetAreaNr(this.TPlanObj[index1].FromArea) && numArray[coordinate.x, coordinate.y] > 0)
                num3 = 1;
              ++tfacing;
            }
            while (tfacing <= 6);
            if (num3 == 1)
            {
              ++num2;
              num1 += this.game.HandyFunctionsObj.Distance(index8, index9, 0, this.TPlanObj[index1].FromArea.X, this.TPlanObj[index1].FromArea.Y, 0);
            }
          }
        }
      }
      if (num2 <= 0)
        return;
      int num4 = (int) Math.Round((double) num1 / (double) num2);
      int mapWidth5 = this.game.Data.MapObj[0].MapWidth;
      for (int index10 = 0; index10 <= mapWidth5; ++index10)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index11 = 0; index11 <= mapHeight; ++index11)
        {
          if (this.HexSA[index10, index11] == this.GetAreaNr(this.TPlanObj[index1].FromArea) && numArray[index10, index11] == 0)
          {
            int num5 = 0;
            int num6 = 0;
            int tfacing = 1;
            do
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbour(index10, index11, 0, tfacing);
              if (coordinate.onmap && this.HexSA[coordinate.x, coordinate.y] == this.GetAreaNr(this.TPlanObj[index1].TooArea) | this.HexSA[coordinate.x, coordinate.y] == this.GetAreaNr(this.TPlanObj[index1].FromArea) && numArray[coordinate.x, coordinate.y] > 0)
              {
                num5 = 1;
                if (this.game.Data.MapObj[0].HexObj[index10, index11].Bridge[tfacing - 1])
                  ++num6;
              }
              ++tfacing;
            }
            while (tfacing <= 6);
            if (num5 == 1)
            {
              int num7 = this.game.HandyFunctionsObj.Distance(index10, index11, 0, this.TPlanObj[index1].FromArea.X, this.TPlanObj[index1].FromArea.Y, 0);
              if (num7 == 0)
                num7 = 1;
              this.Matrix1[index10, index11] = (int) Math.Round((double) this.game.Data.RuleVar[152] * ((double) num4 / (double) num7));
              if (num6 > 0)
                this.Matrix1[index10, index11] = this.Matrix1[index10, index11] * (num6 * 2);
            }
          }
        }
      }
    }

    public float GivePercentBehindRiver(int plnr)
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int index1 = plnr;
      if (this.TPlanObj[index1].Type == 20 && this.TPlanObj[index1].Stand == 2 && this.TPlanObj[index1].FromArea.ConstitutantCount == 0)
      {
        int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
        for (int index2 = 0; index2 <= mapWidth1; ++index2)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index3 = 0; index3 <= mapHeight; ++index3)
          {
            if (this.HexSA[index2, index3] == this.GetAreaNr(this.TPlanObj[index1].TooArea) && this.game.Data.MapObj[0].HexObj[index2, index3].UnitCounter > -1)
              numArray[index2, index3] = 1;
          }
        }
        int num = 1;
        while (num == 1)
        {
          num = 0;
          int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
          for (int index4 = 0; index4 <= mapWidth2; ++index4)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index5 = 0; index5 <= mapHeight; ++index5)
            {
              if (numArray[index4, index5] == 1)
              {
                int tfacing = 1;
                do
                {
                  Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(index4, index5, 0, tfacing);
                  if (coordinate.onmap && this.HexSA[coordinate.x, coordinate.y] == this.GetAreaNr(this.TPlanObj[index1].FromArea) | this.HexSA[coordinate.x, coordinate.y] == this.GetAreaNr(this.TPlanObj[index1].TooArea) && this.game.Data.MapObj[0].HexObj[index4, index5].RiverType[tfacing - 1] == -1 & this.game.HandyFunctionsObj.MoveApCostPreview2(index4, index5, this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, index4, index5, 0, coordinate.x, coordinate.y, 0, false).x < 9999 && numArray[coordinate.x, coordinate.y] == 0)
                  {
                    numArray[coordinate.x, coordinate.y] = 1;
                    num = 1;
                  }
                  ++tfacing;
                }
                while (tfacing <= 6);
              }
            }
          }
        }
      }
      int unitCounter = this.game.Data.UnitCounter;
      int num1;
      int num2;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].AIPlanNr == index1 && this.game.Data.UnitObj[unr].X > -1)
        {
          if (numArray[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y] == 1)
            num1 += this.game.HandyFunctionsObj.GetPower(unr, this.game.Data.Turn);
          else
            num2 += this.game.HandyFunctionsObj.GetPower(unr, this.game.Data.Turn);
        }
      }
      return num1 + num2 > 0 ? (float) num2 / (float) (num1 + num2) : 0.0f;
    }

    public void InitRiverLine()
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int tplanCount = this.TPlanCount;
      for (int index1 = 1; index1 <= tplanCount; ++index1)
      {
        this.TPlanObj[index1].RiverLine = 0;
        if (this.TPlanObj[index1].Type == 20 && this.TPlanObj[index1].Stand == 2 && this.TPlanObj[index1].FromArea.ConstitutantCount == 0)
        {
          int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
          for (int index2 = 0; index2 <= mapWidth1; ++index2)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index3 = 0; index3 <= mapHeight; ++index3)
            {
              if (this.HexSA[index2, index3] == this.GetAreaNr(this.TPlanObj[index1].TooArea) && this.game.Data.MapObj[0].HexObj[index2, index3].UnitCounter > -1)
                numArray[index2, index3] = 1;
            }
          }
          int num = 1;
          while (num == 1)
          {
            num = 0;
            int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
            for (int index4 = 0; index4 <= mapWidth2; ++index4)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index5 = 0; index5 <= mapHeight; ++index5)
              {
                if (numArray[index4, index5] == 1)
                {
                  int tfacing = 1;
                  do
                  {
                    Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(index4, index5, 0, tfacing);
                    if (coordinate.onmap && this.HexSA[coordinate.x, coordinate.y] == this.GetAreaNr(this.TPlanObj[index1].FromArea) | this.HexSA[coordinate.x, coordinate.y] == this.GetAreaNr(this.TPlanObj[index1].TooArea) && this.game.Data.MapObj[0].HexObj[index4, index5].RiverType[tfacing - 1] == -1 & this.game.HandyFunctionsObj.MoveApCostPreview2(index4, index5, this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[0]), 0, index4, index5, 0, coordinate.x, coordinate.y, 0, false).x < 9999 && numArray[coordinate.x, coordinate.y] == 0)
                    {
                      numArray[coordinate.x, coordinate.y] = 1;
                      num = 1;
                    }
                    ++tfacing;
                  }
                  while (tfacing <= 6);
                }
              }
            }
          }
          if (numArray[this.TPlanObj[index1].FromArea.X, this.TPlanObj[index1].FromArea.Y] == 0)
            this.TPlanObj[index1].RiverLine = 1;
        }
      }
    }

    public void InitPlanFrontline()
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int tplanCount = this.TPlanCount;
      for (int index1 = 1; index1 <= tplanCount; ++index1)
      {
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int cx = 0; cx <= mapWidth; ++cx)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int cy = 0; cy <= mapHeight; ++cy)
          {
            if (this.HexSA[cx, cy] == this.GetSANr(this.TPlanObj[index1].FromArea))
            {
              if (this.TPlanObj[index1].Type == 20)
              {
                int tfacing = 1;
                do
                {
                  Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                  if (coordinate.onmap && this.HexSA[coordinate.x, coordinate.y] == this.GetSANr(this.TPlanObj[index1].TooArea) && this.HexPlan[cx, cy] <= 0)
                  {
                    this.HexPlan[cx, cy] = index1;
                    AIPlanClass[] tplanObj = this.TPlanObj;
                    AIPlanClass[] aiPlanClassArray = tplanObj;
                    int index2 = index1;
                    int index3 = index2;
                    aiPlanClassArray[index3].FrontSize = tplanObj[index2].FrontSize + 1;
                  }
                  ++tfacing;
                }
                while (tfacing <= 6);
              }
              if (this.TPlanObj[index1].Type == 40)
              {
                this.HexBackPlan[cx, cy] = index1;
                AIPlanClass[] tplanObj = this.TPlanObj;
                AIPlanClass[] aiPlanClassArray = tplanObj;
                int index4 = index1;
                int index5 = index4;
                aiPlanClassArray[index5].FrontSize = tplanObj[index4].FrontSize + 1;
              }
            }
          }
        }
      }
    }

    public int GetMostUsedHQ(int plannr)
    {
      SimpleList simpleList = new SimpleList();
      int unitCounter = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.game.Data.UnitObj[index1].Regime == this.game.Data.Turn & this.game.Data.UnitObj[index1].X > -1 && this.game.Data.UnitObj[index1].AIPlanNr == plannr)
        {
          int hq = this.game.Data.UnitObj[index1].HQ;
          if (hq > -1 && this.game.Data.UnitObj[hq].AIPlanNr == plannr)
          {
            int nr = simpleList.FindNr(hq);
            if (nr == -1)
            {
              simpleList.Add(hq, 1);
            }
            else
            {
              int[] weight = simpleList.Weight;
              int[] numArray = weight;
              int index2 = nr;
              int index3 = index2;
              int num = weight[index2] + 1;
              numArray[index3] = num;
            }
          }
        }
      }
      if (simpleList.Counter <= -1)
        return -1;
      simpleList.Sort();
      return simpleList.Id[simpleList.Counter];
    }

    public void InitTPlanAPCost()
    {
      int tplanCount1 = this.TPlanCount;
      int index1;
      int x1;
      int y1;
      for (int plannr = 1; plannr <= tplanCount1; ++plannr)
      {
        if (this.TPlanObj[plannr].Type == 20 & this.TPlanObj[plannr].FriendlyUnitCount > 0 && this.TPlanObj[plannr].TooArea.ConstitutantCount < 1)
        {
          this.TPlanObj[plannr].CurrentAPCost = 0;
          this.TPlanObj[plannr].PossibleAPCost = 0;
          this.TPlanObj[plannr].AverageUnitAPCost = 0;
          index1 = this.GetMostUsedHQ(plannr);
          int x2;
          int y2;
          if (index1 > -1)
          {
            if (this.game.Data.UnitObj[index1].HQ > -1 & this.TPlanObj[this.game.Data.UnitObj[index1].AIPlanNr].Type != 30)
              index1 = this.game.Data.UnitObj[index1].HQ;
            if (this.TPlanObj[this.game.Data.UnitObj[index1].AIPlanNr].Type == 30)
            {
              x2 = this.TPlanObj[this.game.Data.UnitObj[index1].AIPlanNr].FromArea.X;
              y2 = this.TPlanObj[this.game.Data.UnitObj[index1].AIPlanNr].FromArea.Y;
              x1 = this.TPlanObj[plannr].FromArea.X;
              y1 = this.TPlanObj[plannr].FromArea.Y;
            }
            else
            {
              x2 = this.TPlanObj[plannr].FromArea.X;
              y2 = this.TPlanObj[plannr].FromArea.Y;
              x1 = this.TPlanObj[plannr].FromArea.X;
              y1 = this.TPlanObj[plannr].FromArea.Y;
            }
          }
          else
          {
            x2 = this.TPlanObj[plannr].FromArea.X;
            y2 = this.TPlanObj[plannr].FromArea.Y;
            x1 = this.TPlanObj[plannr].FromArea.X;
            y1 = this.TPlanObj[plannr].FromArea.Y;
          }
          int num1 = this.game.HandyFunctionsObj.Distance(x2, y2, 0, x1, y1, 0);
          if (num1 < 8)
            num1 = 8;
          int MaxDistance = num1 * 2;
          if (!(x2 == x1 & y2 == y1))
          {
            this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, 200, x2, y2, 0, dontenterenemy: false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true, MaxDistance: MaxDistance);
            AIPlanClass[] tplanObj = this.TPlanObj;
            AIPlanClass[] aiPlanClassArray = tplanObj;
            int index2 = plannr;
            int index3 = index2;
            aiPlanClassArray[index3].CurrentAPCost = tplanObj[index2].CurrentAPCost + this.game.EditObj.TempValue[0].Value[x1, y1];
          }
          this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, 200, x1, y1, 0, dontenterenemy: false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true, MaxDistance: MaxDistance);
          AIPlanClass[] tplanObj1 = this.TPlanObj;
          AIPlanClass[] aiPlanClassArray1 = tplanObj1;
          int index4 = plannr;
          int index5 = index4;
          aiPlanClassArray1[index5].CurrentAPCost = tplanObj1[index4].CurrentAPCost + this.game.EditObj.TempValue[0].Value[this.TPlanObj[plannr].TooArea.X, this.TPlanObj[plannr].TooArea.Y];
          int unitCounter = this.game.Data.UnitCounter;
          int num2;
          int num3;
          for (int index6 = 0; index6 <= unitCounter; ++index6)
          {
            if (this.game.Data.UnitObj[index6].AIPlanNr == plannr && this.game.Data.UnitObj[index6].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index6].X > -1 && this.HexSA[this.game.Data.UnitObj[index6].X, this.game.Data.UnitObj[index6].Y] == this.GetAreaNr(this.TPlanObj[plannr].FromArea))
            {
              num2 += this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[index6].X, this.game.Data.UnitObj[index6].Y];
              ++num3;
            }
          }
          if (num3 < 1)
            num3 = 1;
          this.TPlanObj[plannr].AverageUnitAPCost = (int) Math.Round(Conversion.Int((double) num2 / (double) num3));
          if (!(x2 == x1 & y2 == y1))
          {
            this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, 200, x2, y2, 0, dontenterenemy: false, NoAPPenalties: true, BlockAllSea: true, EngineerTest: true, MaxDistance: MaxDistance);
            AIPlanClass[] tplanObj2 = this.TPlanObj;
            AIPlanClass[] aiPlanClassArray2 = tplanObj2;
            int index7 = plannr;
            int index8 = index7;
            aiPlanClassArray2[index8].PossibleAPCost = tplanObj2[index7].PossibleAPCost + this.game.EditObj.TempValue[0].Value[x1, y1];
          }
          this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, 200, x1, y1, 0, dontenterenemy: false, NoAPPenalties: true, BlockAllSea: true, EngineerTest: true, MaxDistance: MaxDistance);
          AIPlanClass[] tplanObj3 = this.TPlanObj;
          AIPlanClass[] aiPlanClassArray3 = tplanObj3;
          int index9 = plannr;
          int index10 = index9;
          aiPlanClassArray3[index10].PossibleAPCost = tplanObj3[index9].PossibleAPCost + this.game.EditObj.TempValue[0].Value[this.TPlanObj[plannr].TooArea.X, this.TPlanObj[plannr].TooArea.Y];
        }
      }
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int tplanCount2 = this.TPlanCount;
      for (int index11 = 1; index11 <= tplanCount2; ++index11)
      {
        if (this.TPlanObj[index11].Type == 40 & this.TPlanObj[index11].FriendlyUnitCount > 0)
        {
          int x3 = this.TPlanObj[index11].FromArea.X;
          int y3 = this.TPlanObj[index11].FromArea.Y;
          int num4 = 0;
          int index12 = 0;
          this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, 200, x3, y3, 0, dontenterenemy: false, NoAPPenalties: true, BlockAllSea: true);
          int mapWidth = this.game.Data.MapObj[0].MapWidth;
          for (int index13 = 0; index13 <= mapWidth; ++index13)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index14 = 0; index14 <= mapHeight; ++index14)
              numArray[index13, index14] = this.game.EditObj.TempValue[0].Value[index13, index14];
          }
          this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, 200, x3, y3, 0, dontenterenemy: false, NoAPPenalties: true, BlockAllSea: true, EngineerTest: true, MaxDistance: 20);
          if (this.TPlanObj[index11].CurrentBackRoad > 0)
          {
            int x4 = this.SAObj[this.TPlanObj[index11].CurrentBackRoad].X;
            int y4 = this.SAObj[this.TPlanObj[index11].CurrentBackRoad].Y;
            if (this.game.EditObj.TempValue[0].Value[x4, y4] >= numArray[x4, y4])
              this.TPlanObj[index11].CurrentBackRoad = 0;
          }
          int neighbourCount = this.TPlanObj[index11].FromArea.NeighbourCount;
          for (int index15 = 1; index15 <= neighbourCount; ++index15)
          {
            index1 = this.TPlanObj[index11].FromArea.Neighbour[index15];
            if (this.GetAreaNr(this.TPlanObj[index11].FromArea) != index1 && this.HexOA[this.SAObj[index1].X, this.SAObj[index1].Y] > 0)
            {
              x1 = this.SAObj[index1].X;
              y1 = this.SAObj[index1].Y;
              int num5 = 1;
              int tplanCount3 = this.TPlanCount;
              for (int index16 = 1; index16 <= tplanCount3; ++index16)
              {
                if (this.TPlanObj[index16].Type == 40 & index16 != index11 && this.TPlanObj[index16].CurrentBackRoad == this.GetAreaNr(this.TPlanObj[index11].FromArea) && index1 == this.GetAreaNr(this.TPlanObj[index16].FromArea))
                  num5 = 0;
              }
              if (num5 == 1 && this.game.EditObj.TempValue[0].Value[x1, y1] < numArray[x1, y1])
              {
                int num6 = numArray[x1, y1] - this.game.EditObj.TempValue[0].Value[x1, y1];
                if (num6 > num4)
                {
                  num4 = num6;
                  index12 = index1;
                }
              }
            }
          }
          int num7 = 0;
          if (num4 > 0)
          {
            num7 = 1;
            x1 = this.SAObj[index12].X;
            y1 = this.SAObj[index12].Y;
            index1 = index12;
          }
          if (num7 == 1)
          {
            if (this.TPlanObj[index11].CurrentBackRoad > 0)
            {
              int x5 = this.SAObj[this.TPlanObj[index11].CurrentBackRoad].X;
              int y5 = this.SAObj[this.TPlanObj[index11].CurrentBackRoad].Y;
              if (this.game.EditObj.TempValue[0].Value[x5, y5] < numArray[x5, y5])
              {
                this.TPlanObj[index11].PossibleAPCost = this.game.EditObj.TempValue[0].Value[x5, y5];
                this.TPlanObj[index11].CurrentAPCost = numArray[x5, y5];
              }
              else
              {
                this.TPlanObj[index11].PossibleAPCost = this.game.EditObj.TempValue[0].Value[x1, y1];
                this.TPlanObj[index11].CurrentAPCost = numArray[x1, y1];
                this.TPlanObj[index11].CurrentBackRoad = index1;
              }
            }
            else
            {
              this.TPlanObj[index11].PossibleAPCost = this.game.EditObj.TempValue[0].Value[x1, y1];
              this.TPlanObj[index11].CurrentAPCost = numArray[x1, y1];
              this.TPlanObj[index11].CurrentBackRoad = index1;
            }
          }
          else
          {
            this.TPlanObj[index11].CurrentAPCost = 0;
            this.TPlanObj[index11].PossibleAPCost = 0;
          }
        }
      }
    }

    public int getDistanceClosestUnit(int fromarea, int towardsarea)
    {
      object[,] objArray = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int Right = 0;
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          objArray[index1, index2] = (object) -1;
          if (this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter > -1 && this.HexSA[index1, index2] == fromarea)
            objArray[index1, index2] = (object) 0;
        }
      }
      for (int index = 1; index == 1 & Right < 99; ++Right)
      {
        index = 0;
        int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
        for (int cx = 0; cx <= mapWidth2; ++cx)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int cy = 0; cy <= mapHeight; ++cy)
          {
            if (Operators.ConditionalCompareObjectEqual(objArray[cx, cy], (object) Right, false))
            {
              if (this.HexSA[cx, cy] == towardsarea)
                return Right;
              int tfacing = 1;
              do
              {
                Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                {
                  objArray[coordinate.x, coordinate.y] = (object) (Right + 1);
                  index = 1;
                }
                ++tfacing;
              }
              while (tfacing <= 6);
            }
          }
        }
      }
      return 999;
    }

    public void InitTPlanStrategicImportance()
    {
      this.AverageFuzzyVP();
      int tplanCount = this.TPlanCount;
      for (int index = 1; index <= tplanCount; ++index)
      {
        if (this.TPlanObj[index].Type == 20)
        {
          int fuzzyvp1 = this.TPlanObj[index].FromArea.fuzzyvp;
          int fuzzyvp2 = this.TPlanObj[index].TooArea.fuzzyvp;
          this.TPlanObj[index].WeightStrategic = fuzzyvp1 + fuzzyvp2;
          if (this.SAObj[this.GetAreaNr(this.TPlanObj[index].TooArea)].ConstitutantCount > 0)
          {
            if (!this.IsAreaEmpty(this.GetAreaNr(this.TPlanObj[index].TooArea)))
            {
              int num = (int) Math.Round(Math.Pow((double) this.getDistanceClosestUnit(this.GetAreaNr(this.TPlanObj[index].TooArea), this.GetAreaNr(this.TPlanObj[index].FromArea)), 2.0));
              this.TPlanObj[index].WeightStrategic = (int) Math.Round((double) this.TPlanObj[index].WeightStrategic / (double) num);
              if (this.TPlanObj[index].WeightStrategic < 1)
                this.TPlanObj[index].WeightStrategic = 1;
              if (this.game.Data.MapObj[0].HexObj[this.TPlanObj[index].TooArea.X, this.TPlanObj[index].TooArea.Y].Regime == -1 & this.TPlanObj[index].TooArea.aivp == 0)
                this.TPlanObj[index].WeightStrategic = (int) Math.Round((double) this.TPlanObj[index].WeightStrategic / 3.0);
              else if (this.TPlanObj[index].EnemyUnitCount == 0 & this.TPlanObj[index].TooArea.aivp == 0)
                this.TPlanObj[index].WeightStrategic = (int) Math.Round((double) this.TPlanObj[index].WeightStrategic / 3.0);
              else if (this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[this.game.Data.MapObj[0].HexObj[this.TPlanObj[index].TooArea.X, this.TPlanObj[index].TooArea.Y].Regime] > 0)
                this.TPlanObj[index].WeightStrategic = (int) Math.Round((double) ((float) this.TPlanObj[index].WeightStrategic * this.game.Data.RuleVar[246]));
              else
                this.TPlanObj[index].WeightStrategic *= 3;
            }
            else
              this.TPlanObj[index].WeightStrategic = 0;
          }
          else if (this.game.Data.MapObj[0].HexObj[this.TPlanObj[index].TooArea.X, this.TPlanObj[index].TooArea.Y].Regime != -1)
          {
            if (this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[this.game.Data.MapObj[0].HexObj[this.TPlanObj[index].TooArea.X, this.TPlanObj[index].TooArea.Y].Regime] > 0)
              this.TPlanObj[index].WeightStrategic = (int) Math.Round((double) ((float) this.TPlanObj[index].WeightStrategic * this.game.Data.RuleVar[246]));
            else if (this.GetFriendlyAreaNeighbours(this.GetAreaNr(this.TPlanObj[index].TooArea), false) == 0)
              this.TPlanObj[index].WeightStrategic = (int) Math.Round((double) this.TPlanObj[index].WeightStrategic * 1.25);
          }
        }
        else
        {
          this.TPlanObj[index].WeightStrategic = this.SAObj[this.GetAreaNr(this.TPlanObj[index].FromArea)].aivp + this.SAObj[this.GetAreaNr(this.TPlanObj[index].FromArea)].fuzzyvp;
          if (1 > this.TPlanObj[index].WeightStrategic)
            this.TPlanObj[index].WeightStrategic = 1;
        }
        if (this.TPlanObj[index].Type == 20 && this.game.Data.MapObj[0].HexObj[this.TPlanObj[index].TooArea.X, this.TPlanObj[index].TooArea.Y].Regime != -1 && this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[this.game.Data.MapObj[0].HexObj[this.TPlanObj[index].TooArea.X, this.TPlanObj[index].TooArea.Y].Regime] == 0)
        {
          Random random = new Random(this.game.Data.GameID);
          float num1 = (float) random.Next(1, 100) / 100f;
          float num2 = (float) random.Next(1, 100) / 100f;
          float num3 = (float) random.Next(1, 100) / 100f;
          if ((double) num1 < 0.25)
            this.TPlanObj[index].WeightStrategic = (int) Math.Round((double) ((float) this.TPlanObj[index].WeightStrategic * (num2 * 3f)));
          else if ((double) num1 > 0.75)
            this.TPlanObj[index].WeightStrategic = (int) Math.Round((double) ((float) this.TPlanObj[index].WeightStrategic / (num2 * 3f)));
          if (1 > this.TPlanObj[index].WeightStrategic)
            this.TPlanObj[index].WeightStrategic = 1;
        }
      }
    }

    public bool IsAreaEmpty(int areanr)
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.HexSA[index1, index2] == areanr && (this.game.Data.MapObj[0].HexObj[index1, index2].Location > -1 || this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter > -1))
            return false;
        }
      }
      return true;
    }

    public void InitTPlans()
    {
      int saCount1 = this.SACount;
      for (int index1 = 1; index1 <= saCount1; ++index1)
      {
        if (this.HexOA[this.SAObj[index1].X, this.SAObj[index1].Y] > 0)
        {
          int neighbourCount = this.SAObj[index1].NeighbourCount;
          for (int index2 = 1; index2 <= neighbourCount; ++index2)
          {
            int index3 = this.SAObj[index1].Neighbour[index2];
            if (this.HexOA[this.SAObj[index3].X, this.SAObj[index3].Y] == 0)
            {
              int regime = this.game.Data.MapObj[0].HexObj[this.SAObj[index3].X, this.SAObj[index3].Y].Regime;
              int num = 1;
              if (regime > -1)
              {
                if (this.game.Data.RegimeObj[regime].Sleep & this.game.Data.RegimeObj[regime].DipBlock & (double) this.game.Data.RuleVar[263] == 0.0)
                  num = 0;
                if (this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[regime] == 0 & num == 0)
                  num = 1;
              }
              if (num == 1)
              {
                this.AddtPlan();
                this.TPlanObj[this.TPlanCount].Type = 20;
                this.TPlanObj[this.TPlanCount].FromArea = this.SAObj[index1].Clone();
                this.TPlanObj[this.TPlanCount].TooArea = this.SAObj[index3].Clone();
              }
            }
          }
        }
      }
      int saCount2 = this.SACount;
      for (int index = 1; index <= saCount2; ++index)
      {
        if (this.HexOA[this.SAObj[index].X, this.SAObj[index].Y] > 0 & this.game.Data.MapObj[0].HexObj[this.SAObj[index].X, this.SAObj[index].Y].Regime == this.game.Data.Turn && this.AIVP[this.SAObj[index].X, this.SAObj[index].Y] > 0)
        {
          this.AddtPlan();
          this.TPlanObj[this.TPlanCount].Type = 40;
          this.TPlanObj[this.TPlanCount].FromArea = this.SAObj[index].Clone();
        }
      }
    }

    public void InitDeclareWar()
    {
      int[] numArray1 = new int[this.game.Data.RegimeCounter + 1];
      int[] numArray2 = new int[this.game.Data.RegimeCounter + 1];
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int cx = 0; cx <= mapWidth; ++cx)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int cy = 0; cy <= mapHeight; ++cy)
        {
          int regime1 = this.game.Data.MapObj[0].HexObj[cx, cy].Regime;
          if (regime1 > -1)
          {
            int unitCounter = this.game.Data.MapObj[0].HexObj[cx, cy].UnitCounter;
            for (int index1 = 0; index1 <= unitCounter; ++index1)
            {
              int unit = this.game.Data.MapObj[0].HexObj[cx, cy].UnitList[index1];
              int[] numArray3 = numArray1;
              int[] numArray4 = numArray3;
              int regime2 = this.game.Data.UnitObj[unit].Regime;
              int index2 = regime2;
              int num1 = numArray3[regime2] + this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unit);
              numArray4[index2] = num1;
              int regimeCounter = this.game.Data.RegimeCounter;
              for (int index3 = 0; index3 <= regimeCounter; ++index3)
              {
                if (this.game.Data.RegimeObj[index3].RegimeRel[this.game.Data.UnitObj[unit].Regime] == 2 && index3 != this.game.Data.UnitObj[unit].Regime)
                {
                  int[] numArray5 = numArray1;
                  int[] numArray6 = numArray5;
                  int index4 = index3;
                  int index5 = index4;
                  int num2 = numArray5[index4] + this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unit);
                  numArray6[index5] = num2;
                }
              }
            }
            if (regime1 != this.game.Data.Turn)
            {
              int tfacing = 1;
              do
              {
                Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime == this.game.Data.Turn)
                {
                  int[] numArray7 = numArray2;
                  int[] numArray8 = numArray7;
                  int index6 = regime1;
                  int index7 = index6;
                  int num = numArray7[index6] + 1;
                  numArray8[index7] = num;
                }
                ++tfacing;
              }
              while (tfacing <= 6);
            }
          }
        }
      }
      int num3 = 0;
      int regimeCounter1 = this.game.Data.RegimeCounter;
      for (int index = 0; index <= regimeCounter1; ++index)
      {
        if (index != this.game.Data.Turn && this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[index] == 0)
          num3 += numArray1[index];
      }
      int onregnr1 = -1;
      int num4 = 0;
      int num5 = 0;
      if (numArray1[this.game.Data.Turn] <= num3)
        return;
      int regimeCounter2 = this.game.Data.RegimeCounter;
      int num6;
      for (int index = 0; index <= regimeCounter2; ++index)
      {
        if (!this.game.Data.RegimeObj[index].DipBlock & !this.game.Data.RegimeObj[index].Sleep && index != this.game.Data.Turn & this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[index] == 1)
        {
          num6 = 0;
          if (numArray1[index] + num3 < numArray1[this.game.Data.Turn])
          {
            int num7 = (int) Math.Round((double) numArray2[index] * ((double) numArray1[this.game.Data.Turn] / (double) numArray1[index]));
            num6 = (int) Math.Round((double) num7 * 0.5 + (double) num7 * (double) VBMath.Rnd() * 0.5);
            if (!this.game.Data.RegimeObj[index].AI)
              num6 *= 2;
          }
          if (numArray2[index] > 0)
            num5 = 1;
          if (num6 > num4)
          {
            num4 = num6;
            onregnr1 = index;
          }
        }
      }
      if (num5 == 1 && (double) this.game.Data.RuleVar[903] > 100.0 * (double) VBMath.Rnd() && (double) this.game.Data.RuleVar[903] > 100.0 * (double) VBMath.Rnd())
        num5 = 0;
      if (onregnr1 == -1 & num5 == 0)
      {
        this.game.HandyFunctionsObj.SetInitialXY(this.game.Data.Turn);
        int selectX = this.game.SelectX;
        int selectY = this.game.SelectY;
        int regimeCounter3 = this.game.Data.RegimeCounter;
        for (int regnr = 0; regnr <= regimeCounter3; ++regnr)
        {
          if (!this.game.Data.RegimeObj[regnr].DipBlock & !this.game.Data.RegimeObj[regnr].Sleep && regnr != this.game.Data.Turn & this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[regnr] == 1)
          {
            if (numArray1[regnr] + num3 < numArray1[this.game.Data.Turn])
            {
              this.game.HandyFunctionsObj.SetInitialXY(regnr);
              num6 = (int) Math.Round((double) ((float) (int) Math.Round(100.0 - Math.Sqrt((double) this.game.HandyFunctionsObj.Distance(selectX, selectY, 0, this.game.SelectX, this.game.SelectY, 0))) - VBMath.Rnd() * 5f));
              if (!this.game.Data.RegimeObj[regnr].AI)
                num6 += 4;
            }
            if (num6 > num4)
            {
              num4 = num6;
              onregnr1 = regnr;
            }
          }
        }
      }
      if (onregnr1 <= -1 || (double) this.game.Data.RuleVar[903] <= 100.0 * (double) VBMath.Rnd())
        return;
      this.game.ProcessingObj.DeclareWar(this.game.Data.Turn, onregnr1);
      int regimeCounter4 = this.game.Data.RegimeCounter;
      for (int onregnr2 = 0; onregnr2 <= regimeCounter4; ++onregnr2)
      {
        if (onregnr2 != this.game.Data.Turn & onregnr2 != onregnr1 && this.game.Data.RegimeObj[onregnr2].RegimeRel[onregnr1] == 2)
          this.game.ProcessingObj.DeclareWar(this.game.Data.Turn, onregnr2);
      }
    }

    public void InitFindOA()
    {
      object[,] objArray = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight1 = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight1; ++index2)
        {
          if (this.HexOA[index1, index2] == 0 & this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[index1, index2].Regime, this.game.Data.Turn))
          {
            ++this.OACount;
            this.HexOA[index1, index2] = this.OACount;
            int num = 1;
            while (num > 0)
            {
              num = 0;
              int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
              for (int cx = 0; cx <= mapWidth2; ++cx)
              {
                int mapHeight2 = this.game.Data.MapObj[0].MapHeight;
                for (int cy = 0; cy <= mapHeight2; ++cy)
                {
                  if (this.HexOA[cx, cy] == 0 & this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[cx, cy].Regime, this.game.Data.Turn))
                  {
                    int tfacing = 1;
                    do
                    {
                      Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                      if (coordinate.onmap && this.HexOA[coordinate.x, coordinate.y] > 0)
                      {
                        this.HexOA[cx, cy] = this.HexOA[coordinate.x, coordinate.y];
                        ++num;
                      }
                      ++tfacing;
                    }
                    while (tfacing <= 6);
                  }
                }
              }
            }
          }
        }
      }
      this.AddLog("Operational Areas found for this regime: " + Conversion.Str((object) this.OACount));
    }

    public void InitFindContinent()
    {
      object[,] objArray = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      if (this.HexContinent.GetUpperBound(0) < this.game.Data.MapObj[0].MapWidth)
        this.HexContinent = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      if (this.HexContinent.GetUpperBound(1) < this.game.Data.MapObj[0].MapHeight)
        this.HexContinent = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight1 = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight1; ++index2)
        {
          if (this.HexContinent[index1, index2] == 0 & !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType].IsSea)
          {
            ++this.ContinentCount;
            this.HexContinent[index1, index2] = this.ContinentCount;
            int num = 1;
            while (num > 0)
            {
              num = 0;
              int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
              for (int cx = 0; cx <= mapWidth2; ++cx)
              {
                int mapHeight2 = this.game.Data.MapObj[0].MapHeight;
                for (int cy = 0; cy <= mapHeight2; ++cy)
                {
                  if (this.HexContinent[cx, cy] == 0 & !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType].IsSea)
                  {
                    int tfacing = 1;
                    do
                    {
                      Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                      if (coordinate.onmap && this.HexContinent[coordinate.x, coordinate.y] > 0)
                      {
                        this.HexContinent[cx, cy] = this.HexContinent[coordinate.x, coordinate.y];
                        ++num;
                      }
                      ++tfacing;
                    }
                    while (tfacing <= 6);
                  }
                }
              }
            }
          }
        }
      }
      this.AddLog("Continents found on this map: " + Conversion.Str((object) this.ContinentCount));
    }

    public void InitGetSeaSA()
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int num = 1;
      while (num > 0)
      {
        num = 0;
        int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
        for (int index1 = 0; index1 <= mapWidth1; ++index1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index2 = 0; index2 <= mapHeight; ++index2)
            numArray[index1, index2] = 0;
        }
        int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
        for (int cx = 0; cx <= mapWidth2; ++cx)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int cy = 0; cy <= mapHeight; ++cy)
          {
            if (this.HexSeaSA[cx, cy] == 0 & this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType].IsSea)
            {
              int tfacing = 1;
              do
              {
                Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap && this.HexSA[coordinate.x, coordinate.y] > 0 & this.game.HandyFunctionsObj.IsHexPort(coordinate.x, coordinate.y, 0) | this.HexSeaSA[coordinate.x, coordinate.y] > 0)
                {
                  if (this.HexSA[coordinate.x, coordinate.y] > 0)
                  {
                    numArray[cx, cy] = this.HexSA[coordinate.x, coordinate.y];
                    if (this.HexSeaSA[coordinate.x, coordinate.y] == 0)
                      numArray[coordinate.x, coordinate.y] = this.HexSA[coordinate.x, coordinate.y];
                  }
                  else
                    numArray[cx, cy] = this.HexSeaSA[coordinate.x, coordinate.y];
                }
                ++tfacing;
              }
              while (tfacing <= 6);
            }
          }
        }
        int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
        for (int index3 = 0; index3 <= mapWidth3; ++index3)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index4 = 0; index4 <= mapHeight; ++index4)
          {
            if (numArray[index3, index4] > 0)
            {
              this.HexSeaSA[index3, index4] = numArray[index3, index4];
              ++num;
            }
          }
        }
      }
    }

    public bool JoinedNeighbour(int area1, int area2)
    {
      int neighbourCount1 = this.SAObj[area1].NeighbourCount;
      for (int index1 = 1; index1 <= neighbourCount1; ++index1)
      {
        int nr = this.SAObj[area1].Neighbour[index1];
        int neighbourCount2 = this.SAObj[area2].NeighbourCount;
        for (int index2 = 1; index2 <= neighbourCount2; ++index2)
        {
          if (this.SAObj[this.SAObj[area2].Neighbour[index2]].IsNeighbour(nr))
            return true;
        }
      }
      return false;
    }

    public void InitGetSA()
    {
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.HexSA[index1, index2] == 0 & !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType].IsSea & this.AIVP[index1, index2] > 0 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType].AIBlock < 1)
          {
            ++this.SACount;
            this.HexSA[index1, index2] = this.SACount;
            this.HexSAWithoutTemp[index1, index2] = this.SACount;
            this.SAObj = (SAClass[]) Utils.CopyArray((Array) this.SAObj, (Array) new SAClass[this.SACount + 1]);
            this.SAObj[this.SACount] = new SAClass();
            this.SAObj[this.SACount].X = index1;
            this.SAObj[this.SACount].Y = index2;
            this.SAObj[this.SACount].Size = 1;
            this.SAObj[this.SACount].aivp = this.AIVP[index1, index2];
          }
        }
      }
      int num1 = 1;
      Coordinate coordinate;
      while (num1 > 0)
      {
        num1 = 0;
        int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
        for (int index3 = 0; index3 <= mapWidth2; ++index3)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index4 = 0; index4 <= mapHeight; ++index4)
            numArray1[index3, index4] = 0;
        }
        int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
        for (int cx = 0; cx <= mapWidth3; ++cx)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int cy = 0; cy <= mapHeight; ++cy)
          {
            if (this.HexSAWithoutTemp[cx, cy] > 0)
            {
              int tfacing = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea & this.HexSAWithoutTemp[coordinate.x, coordinate.y] == 0 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].AIBlock < 1)
                  numArray1[coordinate.x, coordinate.y] = this.HexSAWithoutTemp[cx, cy];
                ++tfacing;
              }
              while (tfacing <= 6);
            }
          }
        }
        int mapWidth4 = this.game.Data.MapObj[0].MapWidth;
        for (int index5 = 0; index5 <= mapWidth4; ++index5)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index6 = 0; index6 <= mapHeight; ++index6)
          {
            if (numArray1[index5, index6] > 0)
            {
              this.HexSAWithoutTemp[index5, index6] = numArray1[index5, index6];
              ++num1;
            }
          }
        }
      }
      int num2 = 1;
      while (num2 > 0)
      {
        num2 = 0;
        int mapWidth5 = this.game.Data.MapObj[0].MapWidth;
        for (int index7 = 0; index7 <= mapWidth5; ++index7)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index8 = 0; index8 <= mapHeight; ++index8)
            numArray1[index7, index8] = 0;
        }
        int mapWidth6 = this.game.Data.MapObj[0].MapWidth;
        for (int cx = 0; cx <= mapWidth6; ++cx)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int cy = 0; cy <= mapHeight; ++cy)
          {
            if (this.HexSA[cx, cy] > 0)
            {
              int tfacing = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea & this.HexSA[coordinate.x, coordinate.y] == 0 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].AIBlock < 1 && this.game.Data.MapObj[0].HexObj[cx, cy].Regime == this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime)
                  numArray1[coordinate.x, coordinate.y] = this.HexSA[cx, cy];
                ++tfacing;
              }
              while (tfacing <= 6);
            }
          }
        }
        int mapWidth7 = this.game.Data.MapObj[0].MapWidth;
        for (int index9 = 0; index9 <= mapWidth7; ++index9)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index10 = 0; index10 <= mapHeight; ++index10)
          {
            if (numArray1[index9, index10] > 0)
            {
              this.HexSA[index9, index10] = numArray1[index9, index10];
              ++num2;
              SAClass[] saObj = this.SAObj;
              SAClass[] saClassArray = saObj;
              int[,] numArray2 = numArray1;
              int[,] numArray3 = numArray2;
              int index11 = index9;
              int index12 = index11;
              int index13 = index10;
              int index14 = index13;
              int index15 = numArray3[index12, index14];
              saClassArray[index15].Size = saObj[numArray2[index11, index13]].Size + 1;
            }
          }
        }
      }
      int num3 = 1;
      while (num3 == 1)
      {
        num3 = 0;
        int mapWidth8 = this.game.Data.MapObj[0].MapWidth;
        for (int index16 = 0; index16 <= mapWidth8; ++index16)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index17 = 0; index17 <= mapHeight; ++index17)
          {
            if (this.HexSA[index16, index17] == 0 & !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index16, index17].LandscapeType].IsSea && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index16, index17].LandscapeType].AIBlock < 1 && num3 == 0)
            {
              ++this.SACount;
              this.HexSA[index16, index17] = this.SACount;
              this.SAObj = (SAClass[]) Utils.CopyArray((Array) this.SAObj, (Array) new SAClass[this.SACount + 1]);
              this.SAObj[this.SACount] = new SAClass();
              this.SAObj[this.SACount].X = index16;
              this.SAObj[this.SACount].Y = index17;
              this.SAObj[this.SACount].Size = 1;
              this.SAObj[this.SACount].aivp = 0;
              this.SAObj[this.SACount].AddConstitutant(this.HexSAWithoutTemp[index16, index17]);
              num3 = 1;
            }
          }
        }
        int num4 = 1;
        while (num4 > 0)
        {
          num4 = 0;
          int mapWidth9 = this.game.Data.MapObj[0].MapWidth;
          for (int index18 = 0; index18 <= mapWidth9; ++index18)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index19 = 0; index19 <= mapHeight; ++index19)
              numArray1[index18, index19] = 0;
          }
          int mapWidth10 = this.game.Data.MapObj[0].MapWidth;
          for (int cx = 0; cx <= mapWidth10; ++cx)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int cy = 0; cy <= mapHeight; ++cy)
            {
              if (this.HexSA[cx, cy] > 0)
              {
                int tfacing = 1;
                do
                {
                  coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                  if (coordinate.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea & this.HexSA[coordinate.x, coordinate.y] == 0 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].AIBlock < 1 && this.game.Data.MapObj[0].HexObj[cx, cy].Regime == this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime)
                    numArray1[coordinate.x, coordinate.y] = this.HexSA[cx, cy];
                  ++tfacing;
                }
                while (tfacing <= 6);
              }
            }
          }
          int mapWidth11 = this.game.Data.MapObj[0].MapWidth;
          for (int index20 = 0; index20 <= mapWidth11; ++index20)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index21 = 0; index21 <= mapHeight; ++index21)
            {
              if (numArray1[index20, index21] > 0)
              {
                this.HexSA[index20, index21] = numArray1[index20, index21];
                this.SAObj[this.HexSA[index20, index21]].AddConstitutant(this.HexSAWithoutTemp[index20, index21]);
                ++num4;
                SAClass[] saObj = this.SAObj;
                SAClass[] saClassArray = saObj;
                int[,] numArray4 = numArray1;
                int[,] numArray5 = numArray4;
                int index22 = index20;
                int index23 = index22;
                int index24 = index21;
                int index25 = index24;
                int index26 = numArray5[index23, index25];
                saClassArray[index26].Size = saObj[numArray4[index22, index24]].Size + 1;
              }
            }
          }
        }
      }
    }

    public void InitSARelations()
    {
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[] numArray2 = new int[this.SACount + 1];
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      Coordinate coordinate;
      for (int cx = 0; cx <= mapWidth1; ++cx)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int cy = 0; cy <= mapHeight; ++cy)
        {
          if (this.HexSA[cx, cy] > 0)
          {
            int tfacing = 1;
            do
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
              if (coordinate.onmap && this.HexSA[coordinate.x, coordinate.y] > 0 & this.HexSA[coordinate.x, coordinate.y] != this.HexSA[cx, cy] && !this.SAObj[this.HexSA[cx, cy]].IsNeighbour(this.HexSA[coordinate.x, coordinate.y]))
                this.SAObj[this.HexSA[cx, cy]].AddNeighbour(this.HexSA[coordinate.x, coordinate.y]);
              ++tfacing;
            }
            while (tfacing <= 6);
          }
        }
      }
      int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
      for (int cx = 0; cx <= mapWidth2; ++cx)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int cy = 0; cy <= mapHeight; ++cy)
        {
          if (this.HexSeaSA[cx, cy] > 0)
          {
            int tfacing = 1;
            do
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
              if (coordinate.onmap && this.HexSeaSA[coordinate.x, coordinate.y] > 0 & this.HexSeaSA[coordinate.x, coordinate.y] != this.HexSeaSA[cx, cy] && !this.SAObj[this.HexSeaSA[cx, cy]].IsSeaNeighbour(this.HexSeaSA[coordinate.x, coordinate.y]))
                this.SAObj[this.HexSeaSA[cx, cy]].AddSeaNeighbour(this.HexSeaSA[coordinate.x, coordinate.y]);
              ++tfacing;
            }
            while (tfacing <= 6);
          }
        }
      }
      int saCount1 = this.SACount;
      for (int nr = 1; nr <= saCount1; ++nr)
      {
        if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.SAObj[nr].X, this.SAObj[nr].Y].LandscapeType].IsSea)
        {
          int num1 = 0;
          int saCount2 = this.SACount;
          for (int nr2 = 1; nr2 <= saCount2; ++nr2)
          {
            if (nr != nr2 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.SAObj[nr].X, this.SAObj[nr].Y].LandscapeType].IsSea)
            {
              int num2 = this.AreaDistance2(nr, nr2, MaxDistance: 3);
              if (num2 > 0)
              {
                int num3 = (int) Math.Round(Conversion.Int((double) this.SAObj[nr2].aivp / (double) num2));
                if (num3 > num1)
                  num1 = num3;
              }
            }
          }
          this.SAObj[nr].fuzzyvp = this.SAObj[nr].aivp + num1;
          if (this.SAObj[nr].aivp == 0 & this.game.Data.MapObj[0].HexObj[this.SAObj[nr].X, this.SAObj[nr].Y].Regime == -1)
            this.SAObj[nr].fuzzyvp = 0;
        }
      }
      this.AddLog("SubAreas found on whole map: " + Conversion.Str((object) this.SACount));
      int saCount3 = this.SACount;
      for (int Number1 = 1; Number1 <= saCount3; ++Number1)
      {
        this.AddLog(" ");
        this.AddLog("SubArea #" + Conversion.Str((object) Number1) + ": ");
        this.AddLog(this.game.HandyFunctionsObj.GetHexName(this.SAObj[Number1].X, this.SAObj[Number1].Y, 0) + "(" + Conversion.Str((object) this.SAObj[Number1].X) + "," + Conversion.Str((object) this.SAObj[Number1].Y) + "), size: " + Conversion.Str((object) this.SAObj[Number1].Size) + ", aivp/fuzzyvp: " + Conversion.Str((object) this.SAObj[Number1].aivp) + "/" + Conversion.Str((object) this.SAObj[Number1].fuzzyvp) + ", Bordering SA's: " + Conversion.Str((object) this.SAObj[Number1].NeighbourCount));
        string s1 = "Neighbours: ";
        int neighbourCount = this.SAObj[Number1].NeighbourCount;
        for (int index = 1; index <= neighbourCount; ++index)
        {
          int Number2 = this.SAObj[Number1].Neighbour[index];
          s1 = s1 + this.game.HandyFunctionsObj.GetHexName(this.SAObj[Number2].X, this.SAObj[Number2].Y, 0) + "(#" + Conversion.Str((object) Number2) + ")";
          if (index < this.SAObj[Number1].NeighbourCount)
            s1 += ", ";
        }
        this.AddLog(s1);
        string s2 = "SeaNeighbours: ";
        int seaNeighbourCount = this.SAObj[Number1].SeaNeighbourCount;
        for (int index = 1; index <= seaNeighbourCount; ++index)
        {
          int Number3 = this.SAObj[Number1].SeaNeighbour[index];
          s2 = s2 + this.game.HandyFunctionsObj.GetHexName(this.SAObj[Number3].X, this.SAObj[Number3].Y, 0) + "(#" + Conversion.Str((object) Number3) + ")";
          if (index < this.SAObj[Number1].SeaNeighbourCount)
            s2 += ", ";
        }
        this.AddLog(s2);
        if (this.SAObj[Number1].ConstitutantCount > 0)
        {
          string s3 = "Is Temporary Area. Constitutants:";
          int constitutantCount = this.SAObj[Number1].ConstitutantCount;
          for (int index = 1; index <= constitutantCount; ++index)
          {
            int Number4 = this.SAObj[Number1].Constitutant[index];
            if (Number4 > 0)
              s3 = s3 + this.game.HandyFunctionsObj.GetHexName(this.SAObj[Number4].X, this.SAObj[Number4].Y, 0) + "(#" + Conversion.Str((object) Number4) + ")";
            else
              s3 += "No VP Area";
            if (index < this.SAObj[Number1].ConstitutantCount)
              s3 += ", ";
          }
          this.AddLog(s3);
        }
      }
    }

    public void InitAIVP()
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.game.Data.MapObj[0].HexObj[index1, index2].VP > 0 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType].IsSea)
            this.game.Data.MapObj[0].HexObj[index1, index2].VP = 0;
          this.AIVP[index1, index2] = 0;
          this.AIVP[index1, index2] = this.game.Data.MapObj[0].HexObj[index1, index2].VP;
          if (this.game.Data.MapObj[0].HexObj[index1, index2].Location > -1)
          {
            int type = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index1, index2].Location].Type;
            if (this.game.Data.LocTypeObj[type].OnDestructLT == -1)
            {
              int num1 = (int) Math.Round((double) Conversion.Int((float) this.game.Data.LocTypeObj[type].MaxProd / this.game.Data.RuleVar[201]));
              if (num1 == 0)
                num1 = 1;
              if (this.game.Data.LocTypeObj[type].MaxProd < 1)
                num1 = 0;
              int[,] aivp = this.AIVP;
              int[,] numArray = aivp;
              int index3 = index1;
              int index4 = index3;
              int index5 = index2;
              int index6 = index5;
              int num2 = aivp[index3, index5] + num1;
              numArray[index4, index6] = num2;
            }
          }
          int[,] aivp1 = this.AIVP;
          int[,] numArray1 = aivp1;
          int index7 = index1;
          int index8 = index7;
          int index9 = index2;
          int index10 = index9;
          int num = aivp1[index7, index9] + this.game.Data.RegimeObj[this.game.Data.Turn].AIVP[0].Value[index1, index2];
          numArray1[index8, index10] = num;
          int regime = this.game.Data.MapObj[0].HexObj[index1, index2].Regime;
          if (regime > -1 & this.AIVP[index1, index2] > 0 && this.game.Data.Turn != regime && this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[regime] == 0 && (double) this.game.Data.RuleVar[264] == 0.0 && this.game.Data.RegimeObj[regime].AI)
          {
            this.AIVP[index1, index2] = (int) Math.Round((double) this.AIVP[index1, index2] * 0.5);
            if (1 > this.AIVP[index1, index2])
              this.AIVP[index1, index2] = 1;
            if ((this.game.Data.GameID + regime + this.game.Data.Turn) % 2 == 0)
            {
              this.AIVP[index1, index2] = (int) Math.Round((double) this.AIVP[index1, index2] * 0.5);
              if (1 > this.AIVP[index1, index2])
                this.AIVP[index1, index2] = 1;
            }
            else if ((this.game.Data.GameID + regime + this.game.Data.Turn) % 3 == 0)
            {
              this.AIVP[index1, index2] = (int) Math.Round((double) this.AIVP[index1, index2] * 0.1);
              if (1 > this.AIVP[index1, index2])
                this.AIVP[index1, index2] = 1;
            }
          }
        }
      }
    }

    public float GetEntrenchMod(int unr)
    {
      float entrenchMod = 0.0f;
      int sfCount = this.game.Data.UnitObj[unr].SFCount;
      for (int index = 0; index <= sfCount; ++index)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index];
        int entrenchPower = this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].EntrenchPower;
        float num = entrenchPower <= 0 ? 0.0f : (float) this.game.Data.SFObj[sf].CurrentEntrench / (float) entrenchPower;
        if ((double) num > (double) entrenchMod)
          entrenchMod = num;
      }
      if ((double) entrenchMod < 1.0)
        entrenchMod = 1f;
      return entrenchMod;
    }

    public float GetEntrenchMod(int x, int y)
    {
      if (this.game.Data.MapObj[0].HexObj[x, y].UnitCounter < 1)
        return 1f;
      float num = 0.0f;
      int unitCounter = this.game.Data.MapObj[0].HexObj[x, y].UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        int unit = this.game.Data.MapObj[0].HexObj[x, y].UnitList[index];
        num += this.GetEntrenchMod(unit);
      }
      float entrenchMod = num / (float) (this.game.Data.MapObj[0].HexObj[x, y].UnitCounter + 1);
      if ((double) entrenchMod < 1.0)
        entrenchMod = 1f;
      return entrenchMod;
    }

    public int PlanEngineerNeedScore(int plnr)
    {
      int num1;
      if (this.TPlanObj[plnr].Type == 40)
        num1 = this.TPlanObj[plnr].CurrentAPCost - this.TPlanObj[plnr].PossibleAPCost;
      else if (this.TPlanObj[plnr].Type == 20 & (this.TPlanObj[plnr].Stand == 1 | this.TPlanObj[plnr].EnemyUnitCount == 0))
      {
        int num2 = this.TPlanObj[plnr].CurrentAPCost - this.TPlanObj[plnr].PossibleAPCost;
        float num3 = (float) this.TPlanObj[plnr].AverageUnitAPCost / this.game.Data.RuleVar[51];
        if ((double) num3 < 1.0)
          num3 = 1f;
        num1 = (int) Math.Round((double) Conversion.Int((float) num2 * num3));
        if (this.TPlanObj[plnr].FromArea.ConstitutantCount > 0)
          num1 = 0;
        if (this.TPlanObj[plnr].TooArea.ConstitutantCount > 0)
          num1 = (int) Math.Round((double) num1 / 2.0);
      }
      else
        num1 = this.TPlanObj[plnr].Type != 50 ? 0 : 9999;
      return num1;
    }

    public float GetPercentCuttenOff(int plannr)
    {
      int unitCounter = this.game.Data.UnitCounter;
      int num1;
      int num2;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].AIPlanNr == plannr & this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn)
        {
          num1 += this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unr);
          if (this.game.Data.UnitObj[unr].AICutoff > 0)
            num2 += this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unr);
        }
      }
      return num1 == 0 ? 0.0f : (float) num2 / (float) num1;
    }

    public Coordinate SetMatrixHQ(SimpleList UL, int hqnr = -1, int onlysanr = -1)
    {
      this.Matrix2 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      Coordinate coordinate = new Coordinate();
      bool flag = true;
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
          this.Matrix2[index1, index2] = 0;
      }
      int aiPlanNr;
      if (hqnr > -1)
        aiPlanNr = this.game.Data.UnitObj[hqnr].AIPlanNr;
      if (aiPlanNr > 0 && this.TPlanObj[aiPlanNr].Type == 30)
      {
        flag = false;
        this.Matrix2[this.TPlanObj[aiPlanNr].FromArea.X, this.TPlanObj[aiPlanNr].FromArea.Y] = (int) Math.Round((double) this.game.Data.RuleVar[152]);
      }
      if (flag && UL.Counter > -1)
      {
        int counter = UL.Counter;
        for (int index3 = 0; index3 <= counter; ++index3)
        {
          int num1;
          if (aiPlanNr > 0)
          {
            num1 = Information.IsNothing((object) this.TPlanObj[aiPlanNr].TooArea) ? this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[UL.Id[index3]].X, this.game.Data.UnitObj[UL.Id[index3]].Y, 0, this.TPlanObj[aiPlanNr].FromArea.X, this.TPlanObj[aiPlanNr].FromArea.Y, 0) : this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[UL.Id[index3]].X, this.game.Data.UnitObj[UL.Id[index3]].Y, 0, this.TPlanObj[aiPlanNr].TooArea.X, this.TPlanObj[aiPlanNr].TooArea.Y, 0);
            if ((double) num1 <= (double) this.game.Data.RuleVar[191])
              num1 = 1;
          }
          this.SetMatrix1(this.game.Data.UnitObj[UL.Id[index3]].X, this.game.Data.UnitObj[UL.Id[index3]].Y, onlythroughfriendlyhex: true);
          int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
          for (int index4 = 0; index4 <= mapWidth2; ++index4)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index5 = 0; index5 <= mapHeight; ++index5)
            {
              int num2;
              num2 += 10 * this.game.HandyFunctionsObj.GetPowerPtsAbsolute(UL.Id[index3], true);
              int num3 = (int) Math.Round((double) ((float) this.Matrix1[index4, index5] * ((float) (10 * this.game.HandyFunctionsObj.GetPowerPtsAbsolute(UL.Id[index3], true)) / this.game.Data.RuleVar[152])));
              if (aiPlanNr > 0)
                num3 = (int) Math.Round((double) num3 / (double) num1);
              int[,] matrix2 = this.Matrix2;
              int[,] numArray = matrix2;
              int index6 = index4;
              int index7 = index6;
              int index8 = index5;
              int index9 = index8;
              int num4 = matrix2[index6, index8] + num3;
              numArray[index7, index9] = num4;
            }
          }
        }
      }
      if (hqnr > -1)
      {
        int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
        for (int x1 = 0; x1 <= mapWidth3; ++x1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int y1 = 0; y1 <= mapHeight; ++y1)
          {
            if (this.game.Data.MapObj[0].HexObj[x1, y1].Regime == -1 && this.AIVP[x1, y1] > 0 & this.HexSA[x1, y1] > 0 && this.IsAreaNeighbour(this.HexSA[x1, y1], this.HexSA[this.game.Data.UnitObj[hqnr].X, this.game.Data.UnitObj[hqnr].Y]))
            {
              int num5 = (int) Math.Round((double) ((float) this.AIVP[x1, y1] * this.game.Data.RuleVar[152]));
              int num6 = (int) Math.Round((double) this.game.HandyFunctionsObj.Distance(x1, y1, 0, this.game.Data.UnitObj[hqnr].X, this.game.Data.UnitObj[hqnr].Y, 0) / 2.0);
              if (num6 < 1)
                num6 = 1;
              int num7 = (int) Math.Round((double) num5 / (double) num6);
              this.Matrix2[x1, y1] = num7;
            }
          }
        }
      }
      this.SetMatrixEnemyFront(this.game.Data.Turn);
      int mapWidth4 = this.game.Data.MapObj[0].MapWidth;
      for (int index10 = 0; index10 <= mapWidth4; ++index10)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index11 = 0; index11 <= mapHeight; ++index11)
        {
          if (hqnr > -1)
          {
            if (this.game.Data.UnitObj[hqnr].AIPlanNr > -1)
            {
              if (this.TPlanObj[this.game.Data.UnitObj[hqnr].AIPlanNr].Type == 20)
              {
                if (this.TPlanObj[this.game.Data.UnitObj[hqnr].AIPlanNr].Stand == 1)
                {
                  if ((double) this.Matrix1[index10, index11] >= 0.9 * (double) this.game.Data.RuleVar[152])
                    this.Matrix2[index10, index11] = (int) Math.Round((double) this.Matrix2[index10, index11] * 0.5);
                }
                else if (this.TPlanObj[this.game.Data.UnitObj[hqnr].AIPlanNr].Stand == 2)
                {
                  if ((double) this.Matrix1[index10, index11] >= 0.8 * (double) this.game.Data.RuleVar[152])
                    this.Matrix2[index10, index11] = (int) Math.Round((double) this.Matrix2[index10, index11] * 0.4);
                }
                else if ((double) this.Matrix1[index10, index11] >= 0.7 * (double) this.game.Data.RuleVar[152])
                  this.Matrix2[index10, index11] = (int) Math.Round((double) this.Matrix2[index10, index11] * 0.3);
              }
              else if (this.TPlanObj[this.game.Data.UnitObj[hqnr].AIPlanNr].Type == 30)
              {
                if ((double) this.Matrix1[index10, index11] >= 0.7 * (double) this.game.Data.RuleVar[152])
                  this.Matrix2[index10, index11] = (int) Math.Round((double) this.Matrix2[index10, index11] * 0.3);
              }
              else if ((double) this.Matrix1[index10, index11] >= 0.9 * (double) this.game.Data.RuleVar[152])
                this.Matrix2[index10, index11] = (int) Math.Round((double) this.Matrix2[index10, index11] * 0.5);
            }
            else if ((double) this.Matrix1[index10, index11] >= 0.9 * (double) this.game.Data.RuleVar[152])
              this.Matrix2[index10, index11] = (int) Math.Round((double) this.Matrix2[index10, index11] * 0.5);
          }
        }
      }
      int mapWidth5 = this.game.Data.MapObj[0].MapWidth;
      for (int index12 = 0; index12 <= mapWidth5; ++index12)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index13 = 0; index13 <= mapHeight; ++index13)
        {
          if (!this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[index12, index13].Regime, this.game.Data.Turn) & this.game.Data.MapObj[0].HexObj[index12, index13].Regime != -1)
            this.Matrix2[index12, index13] = 0;
          if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index12, index13].LandscapeType].AIBlock == -1)
            this.Matrix2[index12, index13] = 0;
        }
      }
      if (onlysanr > 0)
      {
        int mapWidth6 = this.game.Data.MapObj[0].MapWidth;
        for (int index14 = 0; index14 <= mapWidth6; ++index14)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index15 = 0; index15 <= mapHeight; ++index15)
          {
            if (this.HexSA[index14, index15] > 0 && this.HexSA[index14, index15] != onlysanr)
              this.Matrix2[index14, index15] = 0;
          }
        }
      }
      int num8 = 0;
      int num9 = -1;
      int num10 = -1;
      int mapWidth7 = this.game.Data.MapObj[0].MapWidth;
      for (int index16 = 0; index16 <= mapWidth7; ++index16)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index17 = 0; index17 <= mapHeight; ++index17)
        {
          if (this.Matrix2[index16, index17] > num8)
          {
            num8 = this.Matrix2[index16, index17];
            num9 = index16;
            num10 = index17;
          }
        }
      }
      if (num9 > -1)
      {
        coordinate.onmap = true;
        coordinate.x = num9;
        coordinate.y = num10;
        return coordinate;
      }
      coordinate.onmap = false;
      return coordinate;
    }

    public bool NeedHQ(int nr) => this.TPlanObj[nr].FriendlyUnitCount > 2;

    public int WhichCurrentAreaIsThis(ref SAClass Area)
    {
      if (Information.IsNothing((object) Area))
        return 0;
      int saCount1 = this.SACount;
      for (int index = 1; index <= saCount1; ++index)
      {
        if (this.SAObj[index].X == Area.X && this.SAObj[index].Y == Area.Y)
          return index;
      }
      int num1;
      if (Area.ConstitutantCount > 0)
      {
        int saCount2 = this.SACount;
        for (int index1 = 1; index1 <= saCount2; ++index1)
        {
          int num2 = 0;
          if (this.SAObj[index1].ConstitutantCount > 0)
          {
            int constitutantCount1 = this.SAObj[index1].ConstitutantCount;
            for (int index2 = 1; index2 <= constitutantCount1; ++index2)
            {
              int constitutantCount2 = Area.ConstitutantCount;
              for (int index3 = 1; index3 <= constitutantCount2; ++index3)
              {
                if (this.SAObj[index1].Constitutant[index2] == Area.Constitutant[index3])
                  ++num2;
              }
            }
          }
          int num3;
          if (num2 > num3)
          {
            num3 = num2;
            num1 = index1;
          }
        }
      }
      if (num1 > 0)
        return num1;
      return this.HexSA[Area.X, Area.Y] > 0 ? this.HexSA[Area.X, Area.Y] : 0;
    }

    public Coordinate ClosestFriendlyHex(int tx, int ty, ref SimpleList SL)
    {
      Coordinate coordinate1 = new Coordinate();
      int tfacing = 1;
      do
      {
        Coordinate coordinate2 = this.game.HandyFunctionsObj.HexNeighbour(tx, ty, 0, tfacing);
        if (coordinate2.onmap && this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[tx, ty].Regime, this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].Regime) && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LandscapeType].IsSea && SL.FindNr(-1, coordinate2.x, coordinate2.y) == -1)
          return coordinate2;
        ++tfacing;
      }
      while (tfacing <= 6);
      coordinate1.x = -1;
      coordinate1.onmap = false;
      return coordinate1;
    }

    public Coordinate ClosestUnFriendlyHex(int tx, int ty, ref SimpleList SL)
    {
      Coordinate coordinate1 = new Coordinate();
      int tfacing = 1;
      do
      {
        Coordinate coordinate2 = this.game.HandyFunctionsObj.HexNeighbour(tx, ty, 0, tfacing);
        if (coordinate2.onmap && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[tx, ty].Regime, this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].Regime) && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LandscapeType].IsSea && SL.FindNr(-1, coordinate2.x, coordinate2.y) == -1)
          return coordinate2;
        ++tfacing;
      }
      while (tfacing <= 6);
      coordinate1.x = -1;
      coordinate1.onmap = false;
      return coordinate1;
    }

    public object BestMatrix2(int tx, int ty, int dist)
    {
      Coordinate coordinate1 = new Coordinate();
      int num1 = tx - (dist + 1);
      int num2 = tx + (dist + 1);
      int num3;
      int num4;
      int num5;
      for (int index = num1; index <= num2; ++index)
      {
        int x2 = index;
        if (this.game.Data.MapObj[0].MapLoop & x2 < 0)
          x2 = this.game.Data.MapObj[0].MapWidth + x2 + 1;
        if (this.game.Data.MapObj[0].MapLoop & x2 > this.game.Data.MapObj[0].MapWidth)
          x2 = x2 - this.game.Data.MapObj[0].MapWidth - 1;
        int num6 = ty - (dist + 1);
        int num7 = ty + (dist + 1);
        for (int y2 = num6; y2 <= num7; ++y2)
        {
          Coordinate coordinate2;
          if (x2 > -1 & y2 > -1 && x2 <= this.game.Data.MapObj[0].MapWidth & y2 <= this.game.Data.MapObj[0].MapHeight && this.game.HandyFunctionsObj.Distance(tx, ty, 0, x2, y2, 0) <= dist && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].LandscapeType].IsSea && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[x2, y2].Regime, this.game.Data.MapObj[0].HexObj[tx, ty].Regime) && this.Matrix2[x2, y2] > num3)
          {
            num3 = this.Matrix2[x2, y2];
            num4 = x2;
            num5 = y2;
          }
        }
      }
      if (num3 > 0)
      {
        coordinate1.x = num4;
        coordinate1.y = num5;
        coordinate1.onmap = true;
        return (object) coordinate1;
      }
      coordinate1.x = -1;
      coordinate1.onmap = false;
      return (object) coordinate1;
    }

    public void SetMatrix1(
      int x,
      int y,
      bool subtractformovedunit = false,
      int unitnr = -1,
      bool onlyinplanarea = false,
      bool onlythroughfriendlyhex = false,
      int hq = -1,
      int MaxDist = 9999)
    {
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.Matrix1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
          this.Matrix1[index1, index2] = 0;
      }
      if (hq > -1)
        this.game.HandyFunctionsObj.MakeSupplyLayer(hq, true);
      this.Matrix1[x, y] = (int) Math.Round((double) this.game.Data.RuleVar[152]);
      numArray1[x, y] = 1;
      int num1 = 0;
      int num2 = 1;
      int unit;
      while (num2 == 1)
      {
        num2 = 0;
        ++num1;
        if (num1 < MaxDist)
        {
          int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
          for (int cx = 0; cx <= mapWidth2; ++cx)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int cy = 0; cy <= mapHeight; ++cy)
            {
              if (numArray1[cx, cy] == num1)
              {
                int tfacing = 1;
                do
                {
                  Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                  if (coordinate.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea && numArray1[coordinate.x, coordinate.y] == 0)
                  {
                    numArray1[coordinate.x, coordinate.y] = num1 + 1;
                    num2 = 1;
                    this.Matrix1[coordinate.x, coordinate.y] = (double) this.Matrix1[cx, cy] <= (double) this.game.Data.RuleVar[152] * 0.25 ? this.Matrix1[cx, cy] - 1 : (int) Math.Round(Conversion.Int((double) this.Matrix1[cx, cy] * 0.95));
                    if (subtractformovedunit)
                    {
                      int unitCounter = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitCounter;
                      for (int index3 = 0; index3 <= unitCounter; ++index3)
                      {
                        unit = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitList[index3];
                        if (unit != unitnr && this.UnitMovePhase[unit] == 1)
                        {
                          int aiPlanNr = this.game.Data.UnitObj[unit].AIPlanNr;
                          if (aiPlanNr > 0)
                          {
                            num2 = (int) Math.Round((double) this.TPlanObj[aiPlanNr].WeightFriendlyForce);
                            if (num2 == 0)
                              num2 = 1;
                            int num3 = (int) Math.Round(Conversion.Int((double) this.GetForceLandStrength(unit) / (double) num2 * ((double) this.game.Data.RuleVar[152] * 0.1)));
                            int[,] matrix1 = this.Matrix1;
                            int[,] numArray2 = matrix1;
                            int x1 = coordinate.x;
                            int index4 = x1;
                            int y1 = coordinate.y;
                            int index5 = y1;
                            int num4 = matrix1[x1, y1] - num3;
                            numArray2[index4, index5] = num4;
                            if (unitnr > -1 && this.game.Data.UnitObj[unitnr].HQ > -1)
                            {
                              num2 = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[unitnr].X, this.game.Data.UnitObj[unitnr].Y, 0, this.game.Data.UnitObj[this.game.Data.UnitObj[unitnr].HQ].X, this.game.Data.UnitObj[this.game.Data.UnitObj[unitnr].HQ].Y, 0);
                              if ((double) num2 > (double) this.game.Data.RuleVar[191])
                                num2 = (int) Math.Round((double) (this.game.Data.RuleVar[191] - (float) num2));
                              if (num2 == 0)
                                num2 = 1;
                              this.Matrix1[coordinate.x, coordinate.y] = (int) Math.Round((double) this.Matrix1[coordinate.x, coordinate.y] * (1.0 / (double) num2));
                            }
                            if (0 > this.Matrix1[coordinate.x, coordinate.y])
                              this.Matrix1[coordinate.x, coordinate.y] = 0;
                          }
                        }
                      }
                    }
                    if (onlyinplanarea & unitnr > -1)
                    {
                      int aiPlanNr = this.game.Data.UnitObj[unitnr].AIPlanNr;
                      if (aiPlanNr > 0 && this.TPlanObj[aiPlanNr].Type != 30 & this.TPlanObj[aiPlanNr].Type != 40 && this.HexSA[coordinate.x, coordinate.y] != this.GetAreaNr(this.TPlanObj[aiPlanNr].FromArea) && this.HexSA[coordinate.x, coordinate.y] != this.GetAreaNr(this.TPlanObj[aiPlanNr].TooArea))
                        this.Matrix1[coordinate.x, coordinate.y] = (int) Math.Round((double) this.Matrix1[coordinate.x, coordinate.y] / 2.0);
                    }
                    if (onlythroughfriendlyhex && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime, this.game.Data.MapObj[0].HexObj[x, y].Regime))
                      this.Matrix1[coordinate.x, coordinate.y] = 0;
                  }
                  ++tfacing;
                }
                while (tfacing <= 6);
              }
            }
          }
        }
      }
      if (hq <= -1)
        return;
      float num5 = this.game.HandyFunctionsObj.UnitSupplyUse(unit) >= 1 ? (float) this.game.Data.UnitObj[unit].Supply / (float) this.game.HandyFunctionsObj.UnitSupplyUse(unit) : 1f;
      if (1.0 > (double) num5)
        num5 = 1f;
      if ((double) num5 > 9.0)
        num5 = 9f;
      int num6 = (int) Math.Round((double) num5 * (double) num5 * 3.0);
      if (1 > num6)
        num6 = 1;
      if (num6 > 50)
        num6 = 50;
      int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
      for (int index6 = 0; index6 <= mapWidth3; ++index6)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index7 = 0; index7 <= mapHeight; ++index7)
        {
          int num7 = this.Matrix1[index6, index7];
          int num8 = (int) Math.Round((double) ((float) num7 - (float) num7 * ((float) this.game.EditObj.TempSup[0].Value[index6, index7] / ((float) num6 * this.game.Data.RuleVar[3]))));
          this.Matrix1[index6, index7] = num8;
          if (0 > this.Matrix1[index6, index7])
            this.Matrix1[index6, index7] = 0;
        }
      }
    }

    public void SetNavalMatrix1(int x, int y)
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.Matrix1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
          this.Matrix1[index1, index2] = 0;
      }
      if (x == -1)
        return;
      this.Matrix1[x, y] = (int) Math.Round((double) this.game.Data.RuleVar[152]);
      numArray[x, y] = 1;
      int num1 = 0;
      int num2 = 1;
      while (num2 == 1)
      {
        num2 = 0;
        ++num1;
        int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
        for (int cx = 0; cx <= mapWidth2; ++cx)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int cy = 0; cy <= mapHeight; ++cy)
          {
            if (numArray[cx, cy] == num1)
            {
              int tfacing = 1;
              do
              {
                Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea | this.game.HandyFunctionsObj.IsHexPort(coordinate.x, coordinate.y, 0))
                {
                  int num3 = 1;
                  if (this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitCounter > -1 && this.game.Data.UnitObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitList[0]].Regime != this.game.Data.Turn)
                    num3 = 0;
                  if (numArray[coordinate.x, coordinate.y] == 0 & num3 == 1)
                  {
                    numArray[coordinate.x, coordinate.y] = num1 + 1;
                    num2 = 1;
                    this.Matrix1[coordinate.x, coordinate.y] = (double) this.Matrix1[cx, cy] <= (double) this.game.Data.RuleVar[152] * 0.25 ? this.Matrix1[cx, cy] - 1 : (int) Math.Round(Conversion.Int((double) this.Matrix1[cx, cy] * 0.95));
                  }
                }
                ++tfacing;
              }
              while (tfacing <= 6);
            }
          }
        }
      }
    }

    public Coordinate GetAirSupportCoord(int unr, int plannr)
    {
      long[,] numArray1 = new long[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      long[,] numArray2 = new long[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      long[,] numArray3 = new long[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      long[,] numArray4 = new long[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.game.HandyFunctionsObj.MakeMovePrediction(unr, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0, ismove: true);
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int x = 0; x <= mapWidth1; ++x)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int y = 0; y <= mapHeight; ++y)
        {
          if (this.HexBackPlan[x, y] == plannr)
          {
            if (this.game.HandyFunctionsObj.GetLowestAp(unr) >= this.game.EditObj.TempValue[0].Value[x, y])
              numArray3[x, y] = 5000L;
          }
          else if (this.HexSA[x, y] > 0 && this.SAObj[this.HexSA[x, y]].IsNeighbour(this.GetAreaNr(this.TPlanObj[plannr].FromArea)) && this.game.HandyFunctionsObj.GetLowestAp(unr) >= this.game.EditObj.TempValue[0].Value[x, y])
            numArray3[x, y] = 5000L;
          if (numArray3[x, y] > 0L)
          {
            if (this.game.HandyFunctionsObj.IsHexAirfield(x, y, 0))
            {
              float fieldStackModifier = this.game.HandyFunctionsObj.GetAirFieldStackModifier(x, y);
              if ((double) fieldStackModifier < 0.66)
                numArray3[x, y] = 0L;
              else if ((double) fieldStackModifier < 0.8)
                numArray3[x, y] = (long) Math.Round((double) numArray3[x, y] / 10.0);
              else if ((double) fieldStackModifier < 1.0)
                numArray3[x, y] = (long) Math.Round((double) numArray3[x, y] / 3.0);
            }
            int closestFrontline = this.GetClosestFrontline(x, y);
            if (closestFrontline > 0)
            {
              if (this.TPlanObj[closestFrontline].Stand == 2 | this.TPlanObj[closestFrontline].Stand == 3)
              {
                int closestEnemyDistance = this.GetClosestEnemyDistance(x, y, true);
                if (closestEnemyDistance > 0 & closestEnemyDistance < 4)
                  numArray3[x, y] = (long) Math.Round((double) numArray3[x, y] / 2.0);
                if (closestEnemyDistance > 0 & closestEnemyDistance < 3)
                  numArray3[x, y] = (long) Math.Round((double) numArray3[x, y] / 3.0);
              }
              if (this.TPlanObj[closestFrontline].Stand == 1)
              {
                int closestEnemyDistance = this.GetClosestEnemyDistance(x, y, true);
                if (closestEnemyDistance > 0 & closestEnemyDistance < 4)
                  numArray3[x, y] = (long) Math.Round((double) numArray3[x, y] / 2.0);
                if (closestEnemyDistance > 0 & closestEnemyDistance < 3)
                  numArray3[x, y] = (long) Math.Round((double) numArray3[x, y] / 2.0);
              }
            }
          }
        }
      }
      int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth2; ++index1)
      {
        int mapHeight1 = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight1; ++index2)
        {
          if (numArray3[index1, index2] > 0L)
          {
            int lowestAirAp = this.game.HandyFunctionsObj.GetLowestAirAp(unr);
            int num1 = lowestAirAp >= 100 ? 0 : 100 - lowestAirAp;
            if (num1 > 0)
            {
              this.game.HandyFunctionsObj.MakeMovePrediction(unr, index1, index2, 0, OneHexFurther: true, ClearSea: true, attack: ((uint) num1 > 0U));
              int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
              for (int index3 = 0; index3 <= mapWidth3; ++index3)
              {
                int mapHeight2 = this.game.Data.MapObj[0].MapHeight;
                for (int index4 = 0; index4 <= mapHeight2; ++index4)
                {
                  if (this.game.Data.MapObj[0].HexObj[index3, index4].Regime != -1)
                  {
                    if (!this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[index3, index4].Regime, this.game.Data.Turn) && this.game.EditObj.TempValue[0].Value[index3, index4] <= 100)
                    {
                      if (this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[index3, index4].Regime))
                      {
                        if ((double) this.game.HandyFunctionsObj.Distance(index1, index2, 0, index3, index4, 0) > (double) this.game.Data.RuleVar[223] / 3.0 && (double) this.game.HandyFunctionsObj.Distance(index1, index2, 0, index3, index4, 0) <= (double) this.game.Data.RuleVar[223] && -(-1 < this.AreaDistance(this.HexSA[index3, index4], this.GetAreaNr(this.TPlanObj[plannr].FromArea)) ? 1 : 0) <= 1)
                        {
                          long[,] numArray5 = numArray4;
                          long[,] numArray6 = numArray5;
                          int index5 = index1;
                          int index6 = index5;
                          int index7 = index2;
                          int index8 = index7;
                          long num2 = (long) Math.Round((double) numArray5[index5, index7] + (double) this.GetHexForceLandStrength(index3, index4, true) / 2.0);
                          numArray6[index6, index8] = num2;
                        }
                      }
                      else if (!this.game.Data.RegimeObj[this.game.Data.MapObj[0].HexObj[index3, index4].Regime].DipBlock && (double) this.game.HandyFunctionsObj.Distance(index1, index2, 0, index3, index4, 0) > (double) this.game.Data.RuleVar[223] / 3.0 && (double) this.game.HandyFunctionsObj.Distance(index1, index2, 0, index3, index4, 0) <= (double) this.game.Data.RuleVar[223] && -(-1 < this.AreaDistance(this.HexSA[index3, index4], this.GetAreaNr(this.TPlanObj[plannr].FromArea)) ? 1 : 0) <= 1)
                      {
                        long[,] numArray7 = numArray4;
                        long[,] numArray8 = numArray7;
                        int index9 = index1;
                        int index10 = index9;
                        int index11 = index2;
                        int index12 = index11;
                        long num3 = (long) Math.Round((double) numArray7[index9, index11] + (double) this.GetHexForceLandStrength(index3, index4, true) / 2.0);
                        numArray8[index10, index12] = num3;
                      }
                    }
                    if (!this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[index3, index4].Regime, this.game.Data.Turn) || this.game.EditObj.TempValue[0].Value[index3, index4] > 100 || (double) this.game.HandyFunctionsObj.Distance(index1, index2, 0, index3, index4, 0) > (double) this.game.Data.RuleVar[223] / 2.0)
                      ;
                  }
                }
              }
              if (this.GetHexForceAirStrength(index1, index2, true) > 0)
              {
                int num4 = (int) Math.Round(Math.Sqrt(Math.Sqrt(Math.Sqrt((double) this.GetHexForceAirStrength(index1, index2, true)))));
                numArray4[index1, index2] = (long) Math.Round((double) numArray4[index1, index2] / (double) num4);
              }
              long[,] numArray9 = numArray3;
              long[,] numArray10 = numArray9;
              int index13 = index1;
              int index14 = index13;
              int index15 = index2;
              int index16 = index15;
              long num5 = (long) Math.Round((double) numArray9[index13, index15] + Math.Sqrt((double) numArray4[index1, index2]));
              numArray10[index14, index16] = num5;
            }
          }
        }
      }
      int num6 = -1;
      int num7 = 0;
      int mapWidth4 = this.game.Data.MapObj[0].MapWidth;
      int num8;
      for (int index17 = 0; index17 <= mapWidth4; ++index17)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index18 = 0; index18 <= mapHeight; ++index18)
        {
          if (numArray3[index17, index18] > (long) num7)
          {
            num6 = index17;
            num8 = index18;
            num7 = (int) numArray3[index17, index18];
          }
        }
      }
      Coordinate airSupportCoord;
      if (num7 > 0)
      {
        airSupportCoord.x = num6;
        airSupportCoord.y = num8;
        airSupportCoord.onmap = true;
      }
      else
      {
        airSupportCoord.x = -1;
        airSupportCoord.y = -1;
        airSupportCoord.onmap = false;
      }
      return airSupportCoord;
    }

    public Coordinate GetArtilleryCoord(int unr, int plannr)
    {
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray2 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray3 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      object[,] objArray = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.game.HandyFunctionsObj.MakeMovePrediction(unr, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0);
      int maxArtRange = this.game.HandyFunctionsObj.GetMaxArtRange(unr, 0);
      Coordinate artilleryCoord;
      artilleryCoord.onmap = false;
      if (maxArtRange == 0)
        return artilleryCoord;
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (!Information.IsNothing((object) this.TPlanObj[plannr].TooArea) && this.GetAreaNr(this.TPlanObj[plannr].TooArea) == this.HexSA[index1, index2] && this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[index1, index2].Regime) && this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter > -1)
          {
            objArray[index1, index2] = (object) 1;
            int tfacing = 1;
            do
            {
              artilleryCoord = this.game.HandyFunctionsObj.HexNeighbour(index1, index2, 0, tfacing);
              if (artilleryCoord.onmap)
                objArray[artilleryCoord.x, artilleryCoord.y] = (object) 1;
              ++tfacing;
            }
            while (tfacing <= 6);
            numArray3[index1, index2] = this.GetHexForceLandStrength(index1, index2, true);
          }
        }
      }
      int num1 = -1;
      int num2 = -99999;
      int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
      int num3;
      for (int x1 = 0; x1 <= mapWidth2; ++x1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int y1 = 0; y1 <= mapHeight; ++y1)
        {
          if (numArray3[x1, y1] > 0)
          {
            int num4 = x1 - 5;
            int num5 = x1 + 5;
            for (int index3 = num4; index3 <= num5; ++index3)
            {
              int index4 = index3;
              if (this.game.Data.MapObj[0].MapLoop & index4 < 0)
                index4 = this.game.Data.MapObj[0].MapWidth + index4 + 1;
              if (this.game.Data.MapObj[0].MapLoop & index4 > this.game.Data.MapObj[0].MapWidth)
                index4 = index4 - this.game.Data.MapObj[0].MapWidth - 1;
              int num6 = y1 - 5;
              int num7 = y1 + 5;
              for (int index5 = num6; index5 <= num7; ++index5)
              {
                if (index4 >= 0 & index5 >= 0 && index4 <= this.game.Data.MapObj[0].MapWidth & index5 < this.game.Data.MapObj[0].MapHeight && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(objArray[index4, index5], (object) 0, false), (object) this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[index4, index5].Regime, this.game.Data.Turn))) && this.game.HandyFunctionsObj.Distance(x1, y1, 0, index4, index5, 0) <= maxArtRange)
                {
                  int num8 = (int) Math.Round((double) numArray3[x1, y1] - Math.Pow((double) this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0, index4, index5, 0), 2.0)) + this.GetHexForceLandStrength(index4, index5, true) * 12;
                  if (num8 > num2)
                  {
                    num1 = index4;
                    num3 = index5;
                    num2 = num8;
                  }
                }
              }
            }
          }
        }
      }
      if (num2 > -99999)
      {
        artilleryCoord.x = num1;
        artilleryCoord.y = num3;
        artilleryCoord.onmap = true;
      }
      else
      {
        artilleryCoord.x = -1;
        artilleryCoord.y = -1;
        artilleryCoord.onmap = false;
      }
      return artilleryCoord;
    }

    public int GetNavalTarget(int plnr)
    {
      this.SetNavalMatrix1(this.TPlanObj[plnr].FromArea.X, this.TPlanObj[plnr].FromArea.Y);
      int num1 = 0;
      int num2 = 0;
      int areaNr = this.GetAreaNr(this.TPlanObj[plnr].FromArea);
      int seaNeighbourCount = this.SAObj[areaNr].SeaNeighbourCount;
      for (int index1 = 1; index1 <= seaNeighbourCount; ++index1)
      {
        int index2 = this.SAObj[areaNr].SeaNeighbour[index1];
        int x = this.SAObj[index2].X;
        int y = this.SAObj[index2].Y;
        if (this.game.Data.MapObj[0].HexObj[x, y].Regime == -1 | this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[x, y].Regime) && this.Matrix1[x, y] > num1 & this.AIVP[x, y] > 0)
        {
          num1 = this.Matrix1[x, y];
          num2 = index2;
        }
      }
      return num2 > 0 ? num2 : 0;
    }

    public Coordinate GetNavalWarCoord(int unr, int plannr)
    {
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray2 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray3 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      numArray3 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      Coordinate navalWarCoord1;
      navalWarCoord1.onmap = false;
      if (this.TPlanObj[plannr].Type != 40)
      {
        Coordinate navalWarCoord2;
        return navalWarCoord2;
      }
      this.TPlanObj[plannr].FriendlyNavy = this.GetRealNavalForceInArea(this.GetAreaNr(this.TPlanObj[plannr].FromArea), plannr, false, true);
      this.TPlanObj[plannr].EnemyNavy = this.GetRealNavalForceInArea(this.GetAreaNr(this.TPlanObj[plannr].FromArea), plannr, false, false);
      int num1 = 4;
      if (this.TPlanObj[plannr].SeaStand == 4)
      {
        if (this.game.Data.UnitObj[unr].AIUnitGoal == 10)
          num1 = 4;
        else if (this.game.Data.UnitObj[unr].AIUnitGoal == 9)
          num1 = 4;
        else if (this.game.Data.UnitObj[unr].AIUnitGoal == 8)
          num1 = 4;
      }
      else if (this.TPlanObj[plannr].SeaStand == 5)
      {
        if (this.game.Data.UnitObj[unr].AIUnitGoal == 10)
          num1 = 5;
        else if (this.game.Data.UnitObj[unr].AIUnitGoal == 9)
          num1 = 8;
        else if (this.game.Data.UnitObj[unr].AIUnitGoal == 8)
          num1 = 4;
      }
      else if (this.TPlanObj[plannr].SeaStand == 6)
      {
        if (this.game.Data.UnitObj[unr].AIUnitGoal == 10)
          num1 = 5;
        else if (this.game.Data.UnitObj[unr].AIUnitGoal == 9)
          num1 = 5;
        else if (this.game.Data.UnitObj[unr].AIUnitGoal == 8)
          num1 = 4;
      }
      else if (this.TPlanObj[plannr].SeaStand == 7)
      {
        if (this.game.Data.UnitObj[unr].AIUnitGoal == 10)
          num1 = 5;
        else if (this.game.Data.UnitObj[unr].AIUnitGoal == 9)
          num1 = 5;
        else if (this.game.Data.UnitObj[unr].AIUnitGoal == 8)
          num1 = 5;
      }
      if (num1 == 4)
      {
        navalWarCoord1.x = this.TPlanObj[plannr].FromArea.X;
        navalWarCoord1.y = this.TPlanObj[plannr].FromArea.Y;
        navalWarCoord1.onmap = true;
      }
      else if (num1 == 8 | num1 == 5)
      {
        if ((double) this.game.HandyFunctionsObj.UnitSupplyStore(unr) * 0.4 > (double) this.game.Data.UnitObj[unr].Supply & this.game.Data.UnitObj[unr].PassengerCounter == -1)
        {
          navalWarCoord1.x = this.TPlanObj[plannr].FromArea.X;
          navalWarCoord1.y = this.TPlanObj[plannr].FromArea.Y;
          navalWarCoord1.onmap = true;
        }
        else if ((double) this.game.HandyFunctionsObj.UnitSupplyStore(unr) * 0.8 > (double) this.game.Data.UnitObj[unr].Supply & this.game.Data.UnitObj[unr].X == this.TPlanObj[plannr].FromArea.X & this.game.Data.UnitObj[unr].Y == this.TPlanObj[plannr].FromArea.Y)
        {
          navalWarCoord1.x = this.TPlanObj[plannr].FromArea.X;
          navalWarCoord1.y = this.TPlanObj[plannr].FromArea.Y;
          navalWarCoord1.onmap = true;
        }
        else if (this.game.Data.UnitObj[unr].AIUnitGoal == 8 & this.game.Data.UnitObj[unr].PassengerCounter == -1)
        {
          navalWarCoord1.x = this.TPlanObj[plannr].FromArea.X;
          navalWarCoord1.y = this.TPlanObj[plannr].FromArea.Y;
          navalWarCoord1.onmap = true;
        }
        else if (this.game.Data.UnitObj[unr].AIUnitGoal == 8 & this.game.Data.UnitObj[unr].PassengerCounter > -1)
        {
          SimpleList simpleList = new SimpleList();
          int tid = 0;
          int mapWidth = this.game.Data.MapObj[0].MapWidth;
          for (int cx = 0; cx <= mapWidth; ++cx)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int cy = 0; cy <= mapHeight; ++cy)
            {
              if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType].IsSea && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType].CanAmph && this.HexSA[cx, cy] == this.TPlanObj[plannr].SeaTarget)
              {
                int tfacing = 1;
                do
                {
                  navalWarCoord1 = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                  if (navalWarCoord1.onmap && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[navalWarCoord1.x, navalWarCoord1.y].LandscapeType].IsSea)
                  {
                    ++tid;
                    int seaTarget = this.TPlanObj[plannr].SeaTarget;
                    int num2 = 20;
                    if (navalWarCoord1.x == this.SAObj[seaTarget].X & navalWarCoord1.y == this.SAObj[seaTarget].Y)
                      num2 = 0;
                    if (!this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[navalWarCoord1.x, navalWarCoord1.y].Regime))
                      num2 += 10 * this.GetHexForceLandStrength(navalWarCoord1.x, navalWarCoord1.y);
                    int num3 = (int) Math.Round((double) num2 + (double) num2 * 0.1 * ((double) this.game.HandyFunctionsObj.Distance(navalWarCoord1.x, navalWarCoord1.y, 0, this.SAObj[seaTarget].X, this.SAObj[seaTarget].Y, 0) / 2.0));
                    int tweight = (int) Math.Round((double) num3 + (double) num3 * 0.1 * ((double) this.game.HandyFunctionsObj.Distance(navalWarCoord1.x, navalWarCoord1.y, 0, this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0) / 4.0));
                    simpleList.Add(tid, tweight, navalWarCoord1.x, navalWarCoord1.y);
                  }
                  ++tfacing;
                }
                while (tfacing <= 6);
              }
            }
          }
          if (simpleList.Counter > -1)
          {
            simpleList.Sort();
            navalWarCoord1.x = simpleList.Data1[0];
            navalWarCoord1.y = simpleList.Data2[0];
            navalWarCoord1.onmap = true;
          }
          else
          {
            navalWarCoord1.x = this.game.Data.UnitObj[unr].X;
            navalWarCoord1.y = this.game.Data.UnitObj[unr].Y;
            navalWarCoord1.onmap = true;
          }
        }
        else
        {
          SimpleList simpleList = new SimpleList();
          int tid1 = 0;
          int num4;
          if (this.game.Data.UnitObj[unr].AIUnitGoal != 8)
          {
            int mapWidth = this.game.Data.MapObj[0].MapWidth;
            for (int index1 = 0; index1 <= mapWidth; ++index1)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index2 = 0; index2 <= mapHeight; ++index2)
              {
                if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType].IsSea && this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter > -1 && this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.UnitObj[this.game.Data.MapObj[0].HexObj[index1, index2].UnitList[0]].Regime))
                {
                  ++tid1;
                  int tweight = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0, index1, index2, 0);
                  num4 = 0;
                  if (this.GetAreaNr(this.TPlanObj[plannr].FromArea) == this.HexSeaSA[index1, index2])
                    num4 = 1;
                  if (this.TPlanObj[plannr].SeaTarget > 0 && this.TPlanObj[plannr].SeaTarget == this.HexSeaSA[index1, index2])
                    num4 = 1;
                  if (num4 == 0)
                    tweight *= 3;
                  simpleList.Add(tid1, tweight, index1, index2);
                }
              }
            }
          }
          if (simpleList.Counter == -1 & this.TPlanObj[plannr].SeaTarget > 0 | this.game.Data.UnitObj[unr].AIUnitGoal == 8 & num1 == 5 && this.TPlanObj[plannr].SeaTarget <= this.SACount)
          {
            int x = this.SAObj[this.TPlanObj[plannr].SeaTarget].X;
            int y = this.SAObj[this.TPlanObj[plannr].SeaTarget].Y;
            int tweight = this.game.HandyFunctionsObj.Distance(this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y, 0, x, y, 0);
            int tid2 = tid1 + 1;
            simpleList.Add(tid2, tweight, x, y);
          }
          simpleList.Sort();
          int num5 = -1;
          int num6 = -1;
          int num7 = 0;
          if (simpleList.Counter > -1)
          {
            this.SetNavalMatrix1(simpleList.Data1[0], simpleList.Data2[0]);
            int mapWidth = this.game.Data.MapObj[0].MapWidth;
            for (int index3 = 0; index3 <= mapWidth; ++index3)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index4 = 0; index4 <= mapHeight; ++index4)
              {
                if (this.HexSeaSA[index3, index4] == this.HexSeaSA[this.TPlanObj[plannr].FromArea.X, this.TPlanObj[plannr].FromArea.Y])
                  num4 = 1;
                if (num1 == 5 & this.HexSeaSA[index3, index4] == this.TPlanObj[plannr].SeaTarget)
                  num4 = 1;
                if (this.Matrix1[index3, index4] > num7 & num4 == 1 && this.Matrix1[index3, index4] > num7)
                {
                  num7 = this.Matrix1[index3, index4];
                  num5 = index3;
                  num6 = index4;
                }
              }
            }
          }
          if (num7 > 0)
          {
            navalWarCoord1.x = num5;
            navalWarCoord1.y = num6;
            navalWarCoord1.onmap = true;
          }
        }
      }
      if (navalWarCoord1.onmap)
      {
        this.game.Data.UnitObj[unr].AINavtargetX = navalWarCoord1.x;
        this.game.Data.UnitObj[unr].AINavtargetY = navalWarCoord1.y;
      }
      else
      {
        this.game.Data.UnitObj[unr].AINavtargetX = -1;
        this.game.Data.UnitObj[unr].AINavtargetY = -1;
      }
      return navalWarCoord1;
    }

    public Coordinate GetReserveCoord(int plannr, int resnr)
    {
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray2 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray3 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      Coordinate reserveCoord;
      if (resnr <= 1)
      {
        reserveCoord.x = this.TPlanObj[plannr].FromArea.X;
        reserveCoord.y = this.TPlanObj[plannr].FromArea.Y;
        reserveCoord.onmap = true;
      }
      else
      {
        CoordList coordList = new CoordList();
        coordList.AddCoord(this.TPlanObj[plannr].FromArea.X, this.TPlanObj[plannr].FromArea.Y, 0);
        int num1 = resnr;
        for (int index1 = 2; index1 <= num1; ++index1)
        {
          SimpleList simpleList = new SimpleList();
          int tid = 0;
          int mapWidth = this.game.Data.MapObj[0].MapWidth;
          for (int index2 = 0; index2 <= mapWidth; ++index2)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index3 = 0; index3 <= mapHeight; ++index3)
            {
              if (this.HexSA[index2, index3] == this.GetAreaNr(this.TPlanObj[plannr].FromArea))
              {
                int num2 = 0;
                int tfacing = 1;
                do
                {
                  Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(index2, index3, 0, tfacing);
                  if (coordinate.onmap && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                    num2 = 1;
                  ++tfacing;
                }
                while (tfacing <= 6);
                if (num2 == 1)
                {
                  int num3 = 999;
                  int counter = coordList.counter;
                  int tweight;
                  for (int index4 = 0; index4 <= counter; ++index4)
                  {
                    tweight = this.game.HandyFunctionsObj.Distance(index2, index3, 0, coordList.coord[index4].x, coordList.coord[index4].y, 0);
                    if (tweight < num3)
                      num3 = tweight;
                  }
                  if (tweight > 0)
                  {
                    ++tid;
                    simpleList.Add(tid, tweight, index2, index3);
                  }
                }
              }
            }
          }
          if (simpleList.Counter > -1)
          {
            simpleList.Sort();
            reserveCoord.x = simpleList.Data1[simpleList.Counter];
            reserveCoord.y = simpleList.Data2[simpleList.Counter];
            reserveCoord.onmap = true;
            coordList.AddCoord(reserveCoord.x, reserveCoord.y, 0);
          }
        }
        if (!reserveCoord.onmap)
        {
          reserveCoord.x = this.TPlanObj[plannr].FromArea.X;
          reserveCoord.y = this.TPlanObj[plannr].FromArea.Y;
          reserveCoord.onmap = true;
        }
      }
      return reserveCoord;
    }

    public Coordinate GetEngineerCoord(int engcount, int plannr)
    {
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray2 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray3 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      numArray3 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      engcount = 1;
      CoordList coordList1 = new CoordList();
      CoordList coordList2 = new CoordList();
      int x1;
      int y1;
      if (this.TPlanObj[plannr].Type == 20 | this.TPlanObj[plannr].Type == 50)
      {
        x1 = this.TPlanObj[plannr].TooArea.X;
        y1 = this.TPlanObj[plannr].TooArea.Y;
      }
      else if (this.TPlanObj[plannr].Type == 40)
      {
        if (this.TPlanObj[plannr].CurrentBackRoad < 1)
        {
          int x2 = this.TPlanObj[plannr].FromArea.X;
          int y2 = this.TPlanObj[plannr].FromArea.Y;
          Coordinate engineerCoord;
          engineerCoord.x = x2;
          engineerCoord.y = y2;
          engineerCoord.onmap = true;
          return engineerCoord;
        }
        x1 = this.SAObj[this.TPlanObj[plannr].CurrentBackRoad].X;
        y1 = this.SAObj[this.TPlanObj[plannr].CurrentBackRoad].Y;
      }
      int x3;
      int y3;
      int x4;
      int y4;
      if (this.TPlanObj[plannr].Type == 20 | this.TPlanObj[plannr].Type == 50)
      {
        int index = this.GetMostUsedHQ(plannr);
        if (index > -1)
        {
          if (this.game.Data.UnitObj[index].HQ > -1 & this.TPlanObj[this.game.Data.UnitObj[index].AIPlanNr].Type != 30)
            index = this.game.Data.UnitObj[index].HQ;
          if (this.TPlanObj[this.game.Data.UnitObj[index].AIPlanNr].Type == 30)
          {
            x3 = this.TPlanObj[this.game.Data.UnitObj[index].AIPlanNr].FromArea.X;
            y3 = this.TPlanObj[this.game.Data.UnitObj[index].AIPlanNr].FromArea.Y;
            x4 = this.TPlanObj[plannr].FromArea.X;
            y4 = this.TPlanObj[plannr].FromArea.Y;
          }
          else
          {
            x3 = this.TPlanObj[plannr].FromArea.X;
            y3 = this.TPlanObj[plannr].FromArea.Y;
            x4 = this.TPlanObj[plannr].FromArea.X;
            y4 = this.TPlanObj[plannr].FromArea.Y;
          }
        }
        else
        {
          x3 = this.TPlanObj[plannr].FromArea.X;
          y3 = this.TPlanObj[plannr].FromArea.Y;
          x4 = this.TPlanObj[plannr].FromArea.X;
          y4 = this.TPlanObj[plannr].FromArea.Y;
        }
      }
      else if (this.TPlanObj[plannr].Type == 40)
      {
        x3 = this.TPlanObj[plannr].FromArea.X;
        y3 = this.TPlanObj[plannr].FromArea.Y;
        x4 = this.TPlanObj[plannr].FromArea.X;
        y4 = this.TPlanObj[plannr].FromArea.Y;
      }
      this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, 100, x4, y4, 0, dontenterenemy: false, NoAPPenalties: true, BlockAllSea: true);
      int num1 = 1;
      int x5 = x1;
      int y5 = y1;
      coordList1.AddCoord(x5, y5, 0);
      numArray1[x5, y5] = this.game.EditObj.TempValue[0].Value[x5, y5];
      Coordinate coordinate1;
      while (num1 == 1)
      {
        coordinate1 = this.game.EditObj.TempCameFrom[0].Value[x5, y5];
        if (coordinate1.onmap)
        {
          x5 = coordinate1.x;
          y5 = coordinate1.y;
          coordList1.AddCoord(coordinate1.x, coordinate1.y, 0);
          numArray1[x5, y5] = this.game.EditObj.TempValue[0].Value[x5, y5];
        }
        else
          num1 = 0;
      }
      int counter1 = coordList1.counter;
      int num2 = -1;
      if (!(x3 == x4 & y3 == y4))
      {
        this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, 200, x3, y3, 0, dontenterenemy: false, NoAPPenalties: true, BlockAllSea: true);
        int num3 = 1;
        int index1 = x4;
        int index2 = y4;
        while (num3 == 1)
        {
          coordinate1 = this.game.EditObj.TempCameFrom[0].Value[index1, index2];
          if (coordinate1.onmap)
          {
            index1 = coordinate1.x;
            index2 = coordinate1.y;
            coordList1.AddCoord(coordinate1.x, coordinate1.y, 0);
            if (num2 == -1)
              num2 = this.game.EditObj.TempValue[0].Value[index1, index2];
            numArray1[index1, index2] = this.game.EditObj.TempValue[0].Value[index1, index2];
          }
          else
            num3 = 0;
        }
        int num4 = counter1;
        for (int index3 = 0; index3 <= num4; ++index3)
        {
          int[,] numArray4 = numArray1;
          int[,] numArray5 = numArray4;
          int x6 = coordList1.coord[index3].x;
          int index4 = x6;
          int y6 = coordList1.coord[index3].y;
          int index5 = y6;
          int num5 = numArray4[x6, y6] + num2;
          numArray5[index4, index5] = num5;
        }
      }
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index6 = 0; index6 <= mapWidth; ++index6)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index7 = 0; index7 <= mapHeight; ++index7)
          numArray1[index6, index7] = this.game.EditObj.TempValue[0].Value[index6, index7];
      }
      this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, 200, x4, y4, 0, dontenterenemy: false, NoAPPenalties: true, BlockAllSea: true, EngineerTest: true);
      int num6 = 1;
      int x7 = x1;
      int y7 = y1;
      coordList2.AddCoord(x7, y7, 0);
      numArray2[x7, y7] = this.game.EditObj.TempValue[0].Value[x7, y7];
      while (num6 == 1)
      {
        coordinate1 = this.game.EditObj.TempCameFrom[0].Value[x7, y7];
        if (coordinate1.onmap)
        {
          x7 = coordinate1.x;
          y7 = coordinate1.y;
          coordList2.AddCoord(coordinate1.x, coordinate1.y, 0);
          numArray2[x7, y7] = this.game.EditObj.TempValue[0].Value[x7, y7];
        }
        else
          num6 = 0;
      }
      int counter2 = coordList2.counter;
      int num7 = -1;
      if (!(x3 == x4 & y3 == y4))
      {
        this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, 200, x3, y3, 0, dontenterenemy: false, NoAPPenalties: true, BlockAllSea: true, EngineerTest: true);
        int num8 = 1;
        int index8 = x4;
        int index9 = y4;
        while (num8 == 1)
        {
          coordinate1 = this.game.EditObj.TempCameFrom[0].Value[index8, index9];
          if (coordinate1.onmap)
          {
            index8 = coordinate1.x;
            index9 = coordinate1.y;
            coordList2.AddCoord(coordinate1.x, coordinate1.y, 0);
            if (num7 == -1)
              num7 = this.game.EditObj.TempValue[0].Value[index8, index9];
            numArray2[index8, index9] = this.game.EditObj.TempValue[0].Value[index8, index9];
          }
          else
            num8 = 0;
        }
        int num9 = counter2;
        for (int index10 = 0; index10 <= num9; ++index10)
        {
          int[,] numArray6 = numArray2;
          int[,] numArray7 = numArray6;
          int x8 = coordList1.coord[index10].x;
          int index11 = x8;
          int y8 = coordList1.coord[index10].y;
          int index12 = y8;
          int num10 = numArray6[x8, y8] + num7;
          numArray7[index11, index12] = num10;
        }
      }
      int num11 = 0;
      int counter3;
      for (counter3 = coordList2.counter; counter3 >= 0 && counter3 != 0; counter3 += -1)
      {
        Coordinate coordinate2 = this.game.HandyFunctionsObj.MoveApCostPreview2(coordList2.coord[counter3].x, coordList2.coord[counter3].y, this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, coordList2.coord[counter3].x, coordList2.coord[counter3].y, 0, coordList2.coord[counter3 - 1].x, coordList2.coord[counter3 - 1].y, 0, false, NoAPPenalties: true, BlockAllSea: true);
        int x9 = coordinate2.x;
        coordinate2 = this.game.HandyFunctionsObj.MoveApCostPreview2(coordList2.coord[counter3].x, coordList2.coord[counter3].y, this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, coordList2.coord[counter3].x, coordList2.coord[counter3].y, 0, coordList2.coord[counter3 - 1].x, coordList2.coord[counter3 - 1].y, 0, false, NoAPPenalties: true, BlockAllSea: true, EngineerTest: true);
        int x10 = coordinate2.x;
        if (x9 > x10)
          ++num11;
        if (num11 == engcount)
          break;
      }
      if (num11 == engcount)
      {
        Coordinate engineerCoord;
        engineerCoord.x = coordList2.coord[counter3].x;
        engineerCoord.y = coordList2.coord[counter3].y;
        engineerCoord.onmap = true;
        engineerCoord.data1 = this.game.HandyFunctionsObj.HexFacing(engineerCoord.x, engineerCoord.y, 0, coordList2.coord[counter3 - 1].x, coordList2.coord[counter3 - 1].y, 0);
        return engineerCoord;
      }
      Coordinate engineerCoord1;
      engineerCoord1.onmap = false;
      return engineerCoord1;
    }

    public Coordinate GetEngineerCoordOLDBACKUP(int engcount, int plannr)
    {
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray2 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray3 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      numArray3 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      engcount = 1;
      CoordList coordList1 = new CoordList();
      CoordList coordList2 = new CoordList();
      int x1;
      int y1;
      if (this.TPlanObj[plannr].Type == 20)
      {
        x1 = this.TPlanObj[plannr].TooArea.X;
        y1 = this.TPlanObj[plannr].TooArea.Y;
      }
      int index1 = this.GetMostUsedHQ(plannr);
      int x2;
      int y2;
      int x3;
      int y3;
      if (index1 > -1)
      {
        if (this.game.Data.UnitObj[index1].HQ > -1 & this.TPlanObj[this.game.Data.UnitObj[index1].AIPlanNr].Type != 30)
          index1 = this.game.Data.UnitObj[index1].HQ;
        if (this.TPlanObj[this.game.Data.UnitObj[index1].AIPlanNr].Type == 30)
        {
          x2 = this.TPlanObj[this.game.Data.UnitObj[index1].AIPlanNr].FromArea.X;
          y2 = this.TPlanObj[this.game.Data.UnitObj[index1].AIPlanNr].FromArea.Y;
          x3 = this.TPlanObj[plannr].FromArea.X;
          y3 = this.TPlanObj[plannr].FromArea.Y;
        }
        else
        {
          x2 = this.TPlanObj[plannr].FromArea.X;
          y2 = this.TPlanObj[plannr].FromArea.Y;
          x3 = this.TPlanObj[plannr].FromArea.X;
          y3 = this.TPlanObj[plannr].FromArea.Y;
        }
      }
      else
      {
        x2 = this.TPlanObj[plannr].FromArea.X;
        y2 = this.TPlanObj[plannr].FromArea.Y;
        x3 = this.TPlanObj[plannr].FromArea.X;
        y3 = this.TPlanObj[plannr].FromArea.Y;
      }
      this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, 200, x3, y3, 0, dontenterenemy: false, NoAPPenalties: true, BlockAllSea: true);
      int num1 = 1;
      int x4 = x1;
      int y4 = y1;
      coordList1.AddCoord(x4, y4, 0);
      numArray1[x4, y4] = this.game.EditObj.TempValue[0].Value[x4, y4];
      Coordinate coordinate1;
      while (num1 == 1)
      {
        coordinate1 = this.game.EditObj.TempCameFrom[0].Value[x4, y4];
        if (coordinate1.onmap)
        {
          x4 = coordinate1.x;
          y4 = coordinate1.y;
          coordList1.AddCoord(coordinate1.x, coordinate1.y, 0);
          numArray1[x4, y4] = this.game.EditObj.TempValue[0].Value[x4, y4];
        }
        else
          num1 = 0;
      }
      int counter1 = coordList1.counter;
      int num2 = -1;
      if (!(x2 == x3 & y2 == y3))
      {
        this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, 200, x2, y2, 0, dontenterenemy: false, NoAPPenalties: true, BlockAllSea: true);
        int num3 = 1;
        int index2 = x3;
        int index3 = y3;
        while (num3 == 1)
        {
          coordinate1 = this.game.EditObj.TempCameFrom[0].Value[index2, index3];
          if (coordinate1.onmap)
          {
            index2 = coordinate1.x;
            index3 = coordinate1.y;
            coordList1.AddCoord(coordinate1.x, coordinate1.y, 0);
            if (num2 == -1)
              num2 = this.game.EditObj.TempValue[0].Value[index2, index3];
            numArray1[index2, index3] = this.game.EditObj.TempValue[0].Value[index2, index3];
          }
          else
            num3 = 0;
        }
        int num4 = counter1;
        for (int index4 = 0; index4 <= num4; ++index4)
        {
          int[,] numArray4 = numArray1;
          int[,] numArray5 = numArray4;
          int x5 = coordList1.coord[index4].x;
          int index5 = x5;
          int y5 = coordList1.coord[index4].y;
          int index6 = y5;
          int num5 = numArray4[x5, y5] + num2;
          numArray5[index5, index6] = num5;
        }
      }
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index7 = 0; index7 <= mapWidth; ++index7)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index8 = 0; index8 <= mapHeight; ++index8)
          numArray1[index7, index8] = this.game.EditObj.TempValue[0].Value[index7, index8];
      }
      this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, 200, x3, y3, 0, dontenterenemy: false, NoAPPenalties: true, BlockAllSea: true, EngineerTest: true);
      int num6 = 1;
      int x6 = x1;
      int y6 = y1;
      coordList2.AddCoord(x6, y6, 0);
      numArray2[x6, y6] = this.game.EditObj.TempValue[0].Value[x6, y6];
      while (num6 == 1)
      {
        coordinate1 = this.game.EditObj.TempCameFrom[0].Value[x6, y6];
        if (coordinate1.onmap)
        {
          x6 = coordinate1.x;
          y6 = coordinate1.y;
          coordList2.AddCoord(coordinate1.x, coordinate1.y, 0);
          numArray2[x6, y6] = this.game.EditObj.TempValue[0].Value[x6, y6];
        }
        else
          num6 = 0;
      }
      int counter2 = coordList2.counter;
      int num7 = -1;
      if (!(x2 == x3 & y2 == y3))
      {
        this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, 200, x2, y2, 0, dontenterenemy: false, NoAPPenalties: true, BlockAllSea: true, EngineerTest: true);
        int num8 = 1;
        int index9 = x3;
        int index10 = y3;
        while (num8 == 1)
        {
          coordinate1 = this.game.EditObj.TempCameFrom[0].Value[index9, index10];
          if (coordinate1.onmap)
          {
            index9 = coordinate1.x;
            index10 = coordinate1.y;
            coordList2.AddCoord(coordinate1.x, coordinate1.y, 0);
            if (num7 == -1)
              num7 = this.game.EditObj.TempValue[0].Value[index9, index10];
            numArray2[index9, index10] = this.game.EditObj.TempValue[0].Value[index9, index10];
          }
          else
            num8 = 0;
        }
        int num9 = counter2;
        for (int index11 = 0; index11 <= num9; ++index11)
        {
          int[,] numArray6 = numArray2;
          int[,] numArray7 = numArray6;
          int x7 = coordList1.coord[index11].x;
          int index12 = x7;
          int y7 = coordList1.coord[index11].y;
          int index13 = y7;
          int num10 = numArray6[x7, y7] + num7;
          numArray7[index12, index13] = num10;
        }
      }
      int num11 = 0;
      int num12 = -1;
      int counter3;
      for (counter3 = coordList2.counter; counter3 >= 0; counter3 += -1)
      {
        ++num12;
        if (numArray1[coordList2.coord[counter3].x, coordList2.coord[counter3].y] > numArray2[coordList2.coord[counter3].x, coordList2.coord[counter3].y])
          ++num11;
        if (num11 == engcount)
          break;
      }
      if (num11 == engcount)
      {
        int index14;
        for (index14 = counter3 - 1; index14 >= 0; index14 += -1)
        {
          Coordinate coordinate2 = this.game.HandyFunctionsObj.MoveApCostPreview2(coordList2.coord[index14].x, coordList2.coord[index14].y, this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, coordList2.coord[index14].x, coordList2.coord[index14].y, 0, coordList2.coord[index14 - 1].x, coordList2.coord[index14 - 1].y, 0, false, NoAPPenalties: true, BlockAllSea: true);
          int x8 = coordinate2.x;
          coordinate2 = this.game.HandyFunctionsObj.MoveApCostPreview2(coordList2.coord[index14].x, coordList2.coord[index14].y, this.game.Data.Turn, (int) Math.Round((double) this.game.Data.RuleVar[99]), 0, coordList2.coord[index14].x, coordList2.coord[index14].y, 0, coordList2.coord[index14 - 1].x, coordList2.coord[index14 - 1].y, 0, false, NoAPPenalties: true, BlockAllSea: true, EngineerTest: true);
          int x9 = coordinate2.x;
          if (x8 > x9)
            break;
        }
        Coordinate engineerCoordOldbackup;
        engineerCoordOldbackup.x = coordList2.coord[index14].x;
        engineerCoordOldbackup.y = coordList2.coord[index14].y;
        engineerCoordOldbackup.onmap = true;
        engineerCoordOldbackup.data1 = this.game.HandyFunctionsObj.HexFacing(engineerCoordOldbackup.x, engineerCoordOldbackup.y, 0, coordList2.coord[index14 - 1].x, coordList2.coord[index14 - 1].y, 0);
        return engineerCoordOldbackup;
      }
      Coordinate engineerCoordOldbackup1;
      engineerCoordOldbackup1.onmap = false;
      return engineerCoordOldbackup1;
    }

    public Coordinate GetEscapeCoord(int x, int y, int areanr)
    {
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray2 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray3 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[,] numArray4 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          numArray4[index1, index2] = 0;
          if (this.HexSA[index1, index2] == areanr)
          {
            numArray4[index1, index2] = (int) Math.Round((double) this.game.Data.RuleVar[152]);
            numArray1[index1, index2] = 1;
          }
        }
      }
      int num1 = 0;
      int num2 = 1;
      Coordinate escapeCoord;
      while (num2 == 1)
      {
        num2 = 0;
        ++num1;
        int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
        for (int cx = 0; cx <= mapWidth2; ++cx)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int cy = 0; cy <= mapHeight; ++cy)
          {
            if (numArray1[cx, cy] == num1)
            {
              int tfacing = 1;
              do
              {
                escapeCoord = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (escapeCoord.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[escapeCoord.x, escapeCoord.y].LandscapeType].IsSea && numArray1[escapeCoord.x, escapeCoord.y] == 0 && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[escapeCoord.x, escapeCoord.y].Regime, this.game.Data.Turn) && this.GetHexForceLandStrength(escapeCoord.x, escapeCoord.y) == 0)
                {
                  numArray1[escapeCoord.x, escapeCoord.y] = num1 + 1;
                  num2 = 1;
                  numArray4[escapeCoord.x, escapeCoord.y] = (int) Math.Round(Conversion.Int((double) numArray4[cx, cy] * 0.95));
                }
                ++tfacing;
              }
              while (tfacing <= 6);
            }
          }
        }
      }
      int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
      for (int index3 = 0; index3 <= mapWidth3; ++index3)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index4 = 0; index4 <= mapHeight; ++index4)
        {
          numArray1[index3, index4] = 0;
          numArray2[index3, index4] = numArray4[index3, index4];
          numArray4[index3, index4] = 0;
        }
      }
      numArray4[x, y] = (int) Math.Round((double) this.game.Data.RuleVar[152]);
      numArray1[x, y] = 1;
      int num3 = 0;
      int num4 = 1;
      while (num4 == 1)
      {
        num4 = 0;
        ++num3;
        int mapWidth4 = this.game.Data.MapObj[0].MapWidth;
        for (int cx = 0; cx <= mapWidth4; ++cx)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int cy = 0; cy <= mapHeight; ++cy)
          {
            if (numArray1[cx, cy] == num3)
            {
              int tfacing = 1;
              do
              {
                escapeCoord = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (escapeCoord.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[escapeCoord.x, escapeCoord.y].LandscapeType].IsSea && numArray1[escapeCoord.x, escapeCoord.y] == 0 && numArray2[escapeCoord.x, escapeCoord.y] > 0)
                {
                  numArray1[escapeCoord.x, escapeCoord.y] = num3 + 1;
                  num4 = 1;
                  numArray4[escapeCoord.x, escapeCoord.y] = (int) Math.Round(Conversion.Int((double) numArray4[cx, cy] * 0.95));
                }
                ++tfacing;
              }
              while (tfacing <= 6);
            }
          }
        }
      }
      escapeCoord = new Coordinate();
      x = -1;
      y = -1;
      int num5 = 0;
      int mapWidth5 = this.game.Data.MapObj[0].MapWidth;
      for (int index5 = 0; index5 <= mapWidth5; ++index5)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index6 = 0; index6 <= mapHeight; ++index6)
        {
          if (this.HexSA[index5, index6] == areanr && numArray4[index5, index6] > num5)
          {
            num5 = numArray4[index5, index6];
            x = index5;
            y = index6;
          }
        }
      }
      if (num5 > 0)
      {
        escapeCoord.onmap = true;
        escapeCoord.x = x;
        escapeCoord.y = y;
      }
      else
        escapeCoord.onmap = false;
      return escapeCoord;
    }

    public void SetMatrixEnemyFront(int notregnr, bool emptyhexisdanger = false)
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.Matrix1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int x = 0; x <= mapWidth1; ++x)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int y = 0; y <= mapHeight; ++y)
        {
          this.Matrix1[x, y] = 0;
          if (this.game.Data.MapObj[0].HexObj[x, y].Regime > -1 & !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[0].HexObj[x, y].Regime, notregnr))
          {
            if (this.game.Data.MapObj[0].HexObj[x, y].UnitCounter > -1)
            {
              numArray[x, y] = 1;
              this.Matrix1[x, y] = (int) Math.Round((double) (this.game.Data.RuleVar[152] * ((float) this.GetHexForceLandStrength(x, y) / this.game.Data.RuleVar[183])));
              if ((double) this.Matrix1[x, y] > (double) this.game.Data.RuleVar[152])
                this.Matrix1[x, y] = (int) Math.Round((double) this.game.Data.RuleVar[152]);
            }
            if (emptyhexisdanger)
              this.Matrix1[x, y] = (int) Math.Round((double) this.game.Data.RuleVar[152]);
          }
        }
      }
      int num1 = 0;
      int num2 = 1;
      while (num2 == 1)
      {
        num2 = 0;
        ++num1;
        int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
        for (int cx = 0; cx <= mapWidth2; ++cx)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int cy = 0; cy <= mapHeight; ++cy)
          {
            if (numArray[cx, cy] == num1)
            {
              int tfacing = 1;
              do
              {
                Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea && numArray[coordinate.x, coordinate.y] == 0)
                {
                  numArray[coordinate.x, coordinate.y] = num1 + 1;
                  num2 = 1;
                  this.Matrix1[coordinate.x, coordinate.y] = (int) Math.Round(Conversion.Int((double) this.Matrix1[cx, cy] * 0.95));
                }
                ++tfacing;
              }
              while (tfacing <= 6);
            }
          }
        }
      }
    }

    public int GetAreaNr(SAClass tempSA)
    {
      try
      {
        int saCount = this.SACount;
        for (int areaNr = 1; areaNr <= saCount; ++areaNr)
        {
          if (this.SAObj[areaNr].X == tempSA.X & this.SAObj[areaNr].Y == tempSA.Y)
            return areaNr;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return 0;
    }

    public bool IsAreaNeighbour(int area1, int area2)
    {
      int neighbourCount = this.SAObj[area1].NeighbourCount;
      for (int index = 1; index <= neighbourCount; ++index)
      {
        if (this.SAObj[area1].Neighbour[index] == area2)
          return true;
      }
      return false;
    }

    public int GetForceLandStrength(
      int unr,
      bool withoutmods = false,
      bool asattack = false,
      int attackx = -1,
      int attacky = -1)
    {
      if (this.game.Data.UnitObj[unr].SFCount <= -1)
        return 0;
      int sfCount = this.game.Data.UnitObj[unr].SFCount;
      int forceLandStrength;
      for (int index = 0; index <= sfCount; ++index)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index];
        int type = this.game.Data.SFObj[sf].Type;
        int powerPts = this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].PowerPts;
        int num1 = this.game.Data.SFObj[sf].Qty * powerPts;
        int regime = this.game.Data.UnitObj[unr].Regime;
        if (this.game.Data.SFTypeObj[type].Theater == 0)
        {
          if (!asattack)
          {
            if (!withoutmods)
            {
              int num2 = (int) Math.Round((double) num1 * 0.5 + (double) num1 * 0.5 * ((double) this.game.Data.SFObj[sf].Rdn / 100.0));
              int num3 = (int) Math.Round((double) num2 * 0.5 + (double) num2 * 0.5 * ((double) (this.game.Data.SFObj[sf].DefMod + 100) / 100.0));
              int num4 = (int) Math.Round((double) num3 * 0.1 + (double) num3 * 0.9 * ((double) this.game.Data.UnitObj[unr].SupplyConsume / 100.0));
              if (this.game.Data.Turn != this.game.Data.UnitObj[unr].Regime)
                num4 = (int) Math.Round((double) num4 * ((double) this.game.Data.SFObj[sf].Rdn / 100.0));
              int num5 = (int) Math.Round((double) num4 * (1.0 + (double) this.game.Data.SFObj[sf].CurrentEntrench / 100.0));
              if (this.game.Data.UnitObj[unr].X != -1)
                num5 = (int) Math.Round((double) ((float) num5 * this.game.Data.SFTypeObj[type].CombatModDef[this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y].LandscapeType]));
              num1 = (int) Math.Round((double) ((float) num5 * this.game.Data.PeopleObj[this.game.Data.SFObj[sf].People].BattleForMod[this.game.Data.PeopleObj[this.game.Data.RegimeObj[regime].People].PeopleGroup]));
            }
          }
          else
          {
            int num6 = (int) Math.Round((double) num1 * 0.5 + (double) num1 * 0.5 * ((double) this.game.Data.SFObj[sf].Rdn / 100.0));
            int num7 = (int) Math.Round((double) num6 * 0.1 + (double) num6 * 0.9 * ((double) (this.game.Data.SFObj[sf].OffMod + 100) / 100.0));
            num1 = (int) Math.Round((double) num7 * 0.1 + (double) num7 * 0.9 * ((double) this.game.Data.UnitObj[unr].SupplyConsume / 100.0));
            if (this.game.Data.Turn != this.game.Data.UnitObj[unr].Regime)
              num1 = (int) Math.Round((double) num1 * ((double) this.game.Data.SFObj[sf].Rdn / 100.0));
            if (attackx > -1)
            {
              num1 = (int) Math.Round((double) ((float) num1 * this.AverageCombatPerform(sf, type, attackx, attacky)));
              if (this.game.Data.UnitObj[unr].X != -1)
                num1 = (int) Math.Round((double) ((float) num1 * this.game.Data.SFTypeObj[type].CombatModAtt[this.game.Data.MapObj[0].HexObj[attackx, attacky].LandscapeType]));
            }
          }
          int Number = (int) Math.Round((double) num1 * 0.5 + 1.5 * (double) num1 * ((double) this.game.Data.SFObj[sf].Xp / 100.0));
          forceLandStrength += Conversion.Int(Number);
        }
      }
      return forceLandStrength;
    }

    public int GetForceAirStrength(
      int unr,
      bool withoutmods = false,
      bool asattack = false,
      int attackx = -1,
      int attacky = -1)
    {
      if (this.game.Data.UnitObj[unr].SFCount <= -1)
        return 0;
      int sfCount = this.game.Data.UnitObj[unr].SFCount;
      int forceAirStrength;
      for (int index = 0; index <= sfCount; ++index)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index];
        int type = this.game.Data.SFObj[sf].Type;
        int powerPts = this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].PowerPts;
        int theater = this.game.Data.SFTypeObj[type].Theater;
        int num1 = this.game.Data.SFObj[sf].Qty * powerPts;
        if (theater == 2)
        {
          if (!asattack)
          {
            if (!withoutmods)
            {
              int num2 = (int) Math.Round((double) num1 * 0.5 + (double) num1 * 0.5 * ((double) this.game.Data.SFObj[sf].Rdn / 100.0));
              num1 = (int) Math.Round((double) num2 * 0.5 + (double) num2 * 0.5 * ((double) (this.game.Data.SFObj[sf].DefMod + 100) / 100.0));
              if (this.game.Data.Turn != this.game.Data.UnitObj[unr].Regime)
                num1 = (int) Math.Round((double) num1 * ((double) this.game.Data.SFObj[sf].Rdn / 100.0));
            }
          }
          else
          {
            int num3 = (int) Math.Round((double) num1 * 0.5 + (double) num1 * 0.5 * ((double) this.game.Data.SFObj[sf].Rdn / 100.0));
            num1 = (int) Math.Round((double) num3 * 0.1 + (double) num3 * 0.9 * ((double) (this.game.Data.SFObj[sf].OffMod + 100) / 100.0));
            if (this.game.Data.Turn != this.game.Data.UnitObj[unr].Regime)
              num1 = (int) Math.Round((double) num1 * ((double) this.game.Data.SFObj[sf].Rdn / 100.0));
            if (attackx > -1)
              num1 = (int) Math.Round((double) ((float) (int) Math.Round((double) ((float) num1 * this.AverageCombatPerform(sf, type, attackx, attacky))) * this.game.Data.SFTypeObj[type].CombatModAtt[this.game.Data.MapObj[0].HexObj[attackx, attacky].LandscapeType]));
          }
          int Number = (int) Math.Round((double) num1 * 0.5 + 1.5 * (double) num1 * ((double) this.game.Data.SFObj[sf].Xp / 100.0));
          forceAirStrength += Conversion.Int(Number);
        }
      }
      return forceAirStrength;
    }

    public int GetForceNavalStrength(
      int unr,
      bool withoutmods = false,
      bool asattack = false,
      int attackx = -1,
      int attacky = -1)
    {
      if (this.game.Data.UnitObj[unr].SFCount <= -1)
        return 0;
      int sfCount = this.game.Data.UnitObj[unr].SFCount;
      int forceNavalStrength;
      for (int index = 0; index <= sfCount; ++index)
      {
        int sf = this.game.Data.UnitObj[unr].SFList[index];
        int type = this.game.Data.SFObj[sf].Type;
        int num1 = this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].PowerPts;
        if (this.game.Data.SFTypeObj[type].AIRoleScore[18] < 1 && this.game.Data.SFTypeObj[type].AIRoleScore[19] < 1 && this.game.Data.SFTypeObj[type].AIRoleScore[17] > 0)
          num1 = 0;
        int theater = this.game.Data.SFTypeObj[type].Theater;
        int num2 = this.game.Data.SFObj[sf].Qty * num1;
        if (theater == 1)
        {
          if (!asattack)
          {
            if (!withoutmods)
            {
              int num3 = (int) Math.Round((double) num2 * 0.5 + (double) num2 * 0.5 * ((double) this.game.Data.SFObj[sf].Rdn / 100.0));
              num2 = (int) Math.Round((double) num3 * 0.5 + (double) num3 * 0.5 * ((double) (this.game.Data.SFObj[sf].DefMod + 100) / 100.0));
              if (this.game.Data.Turn != this.game.Data.UnitObj[unr].Regime)
                num2 = (int) Math.Round((double) num2 * ((double) this.game.Data.SFObj[sf].Rdn / 100.0));
            }
          }
          else
          {
            int num4 = (int) Math.Round((double) num2 * 0.1 + (double) num2 * 0.9 * ((double) (this.game.Data.SFObj[sf].OffMod + 100) / 100.0));
            num2 = (int) Math.Round((double) num4 * 0.5 + (double) num4 * 0.5 * ((double) this.game.Data.SFObj[sf].Rdn / 100.0));
            if (this.game.Data.Turn != this.game.Data.UnitObj[unr].Regime)
              num2 = (int) Math.Round((double) num2 * ((double) this.game.Data.SFObj[sf].Rdn / 100.0));
            if (attackx > -1)
              num2 = (int) Math.Round((double) ((float) (int) Math.Round((double) ((float) num2 * this.AverageCombatPerform(sf, type, attackx, attacky))) * this.game.Data.SFTypeObj[type].CombatModAtt[this.game.Data.MapObj[0].HexObj[attackx, attacky].LandscapeType]));
          }
          int Number = (int) Math.Round((double) num2 * 0.5 + 1.5 * (double) num2 * ((double) this.game.Data.SFObj[sf].Xp / 100.0));
          forceNavalStrength += Conversion.Int(Number);
        }
      }
      return forceNavalStrength;
    }

    public int FindBestSuitedItemType(
      int unr,
      int role,
      int prodpts = -1,
      int locnr = -1,
      bool randomeffect = false,
      int rangy = 5)
    {
      SimpleList simpleList1 = new SimpleList();
      int[] numArray1 = new int[this.game.Data.LandscapeTypeCounter + 1];
      if (role == -1)
        return -1;
      int aiPlanNr = this.game.Data.UnitObj[unr].AIPlanNr;
      if (aiPlanNr < 1)
        return -1;
      int itemTypeCounter = this.game.Data.ItemTypeCounter;
      for (int index = 0; index <= itemTypeCounter; ++index)
      {
        int isSfType = this.game.Data.ItemTypeObj[index].IsSFType;
        if (isSfType > -1 && this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, index, this.game.Data.RegimeObj[this.game.Data.Turn].People).result)
        {
          int tweight = this.game.Data.SFTypeObj[isSfType].AIRoleScore[role];
          if (tweight > 0)
          {
            if (prodpts > -1 && this.game.Data.ItemTypeObj[index].ProdWeight > prodpts)
              tweight = (int) Math.Round((double) tweight / (0.5 + (double) this.game.Data.ItemTypeObj[index].ProdWeight / (double) prodpts));
            if (tweight > 0)
              simpleList1.Add(isSfType, tweight, index);
          }
        }
      }
      if (simpleList1.Counter == -1)
        return -1;
      int x1 = this.game.Data.UnitObj[unr].X;
      int y1 = this.game.Data.UnitObj[unr].Y;
      if (x1 == -1)
        return -1;
      int counter = simpleList1.Counter;
      for (int index1 = 0; index1 <= counter; ++index1)
      {
        int num1 = simpleList1.Weight[index1];
        int num2 = 0;
        int landscapeTypeCounter1 = this.game.Data.LandscapeTypeCounter;
        int num3;
        for (int index2 = 0; index2 <= landscapeTypeCounter1; ++index2)
        {
          numArray1[index2] = 0;
          num3 = 0;
        }
        int num4 = x1 - rangy;
        int num5 = x1 + rangy;
        for (int index3 = num4; index3 <= num5; ++index3)
        {
          int x2 = index3;
          if (this.game.Data.MapObj[0].MapLoop & x2 < 0)
            x2 = this.game.Data.MapObj[0].MapWidth + x2 + 1;
          if (this.game.Data.MapObj[0].MapLoop & x2 > this.game.Data.MapObj[0].MapWidth)
            x2 = x2 - this.game.Data.MapObj[0].MapWidth - 1;
          int num6 = y1 - 5;
          int num7 = y1 + 5;
          for (int y2 = num6; y2 <= num7; ++y2)
          {
            if (x2 > -1 & y2 > -1 && x2 <= this.game.Data.MapObj[0].MapWidth & y2 <= this.game.Data.MapObj[0].MapHeight)
            {
              if (this.TPlanObj[aiPlanNr].Type == 20)
              {
                if (this.HexSA[x2, y2] == this.GetAreaNr(this.TPlanObj[aiPlanNr].TooArea))
                {
                  if (this.game.Data.MapObj[0].HexObj[x2, y2].UnitCounter > -1)
                    num2 += this.GetHexForceLandStrength(x2, y2, true);
                  if (this.TPlanObj[aiPlanNr].Stand == 1)
                  {
                    ++num3;
                    int[] numArray2 = numArray1;
                    int[] numArray3 = numArray2;
                    int landscapeType = this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType;
                    int index4 = landscapeType;
                    int num8 = numArray2[landscapeType] + 1;
                    numArray3[index4] = num8;
                  }
                }
                if (this.HexSA[x2, y2] == this.GetAreaNr(this.TPlanObj[aiPlanNr].FromArea))
                {
                  if (this.TPlanObj[aiPlanNr].Stand == 2)
                  {
                    ++num3;
                    int[] numArray4 = numArray1;
                    int[] numArray5 = numArray4;
                    int landscapeType = this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType;
                    int index5 = landscapeType;
                    int num9 = numArray4[landscapeType] + 1;
                    numArray5[index5] = num9;
                  }
                  if (this.TPlanObj[aiPlanNr].Stand == 3)
                  {
                    ++num3;
                    int[] numArray6 = numArray1;
                    int[] numArray7 = numArray6;
                    int landscapeType = this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType;
                    int index6 = landscapeType;
                    int num10 = numArray6[landscapeType] + 1;
                    numArray7[index6] = num10;
                  }
                }
              }
              if (this.TPlanObj[aiPlanNr].Type == 40)
              {
                if (this.game.Data.MapObj[0].HexObj[x2, y2].UnitCounter > -1)
                  num2 += this.GetHexForceLandStrength(x2, y2, true);
                ++num3;
                int[] numArray8 = numArray1;
                int[] numArray9 = numArray8;
                int landscapeType = this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType;
                int index7 = landscapeType;
                int num11 = numArray8[landscapeType] + 1;
                numArray9[index7] = num11;
              }
            }
          }
        }
        float num12 = 0.0f;
        int landscapeTypeCounter2 = this.game.Data.LandscapeTypeCounter;
        for (int index8 = 0; index8 <= landscapeTypeCounter2; ++index8)
        {
          if (numArray1[index8] > 0)
          {
            if (this.TPlanObj[aiPlanNr].Stand == 2)
              num12 = num12 + (float) ((double) this.game.Data.LandscapeTypeObj[index8].DefBonus[this.game.Data.SFTypeObj[simpleList1.Id[index1]].UnitGroup] / 100.0 * ((double) numArray1[index8] / (double) num3)) + this.game.Data.SFTypeObj[simpleList1.Id[index1]].CombatModDef[index8] * ((float) numArray1[index8] / (float) num3);
            else if (this.TPlanObj[aiPlanNr].Stand == 1 | this.TPlanObj[aiPlanNr].Type == 40)
              num12 += this.game.Data.SFTypeObj[simpleList1.Id[index1]].CombatModAtt[index8] * ((float) numArray1[index8] / (float) num3);
          }
        }
        if (num2 > 0)
        {
          SimpleList simpleList2 = new SimpleList();
          int tid = 0;
          int num13 = x1 - rangy;
          int num14 = x1 + rangy;
          for (int index9 = num13; index9 <= num14; ++index9)
          {
            int attackx = index9;
            if (this.game.Data.MapObj[0].MapLoop & attackx < 0)
              attackx = this.game.Data.MapObj[0].MapWidth + attackx + 1;
            if (this.game.Data.MapObj[0].MapLoop & attackx > this.game.Data.MapObj[0].MapWidth)
              attackx = attackx - this.game.Data.MapObj[0].MapWidth - 1;
            int num15 = y1 - rangy;
            int num16 = y1 + rangy;
            float a;
            for (int attacky = num15; attacky <= num16; ++attacky)
            {
              if (attackx > -1 & attacky > -1 && attackx <= this.game.Data.MapObj[0].MapWidth & attacky <= this.game.Data.MapObj[0].MapHeight && !(attackx == x1 & attacky == y1))
              {
                if (this.TPlanObj[aiPlanNr].Type == 20)
                {
                  if (this.HexSA[attackx, attacky] == this.GetAreaNr(this.TPlanObj[aiPlanNr].TooArea) && this.game.Data.MapObj[0].HexObj[attackx, attacky].UnitCounter > -1)
                  {
                    if (this.TPlanObj[aiPlanNr].Stand == 2)
                      a = this.AverageCombatPerform(-1, simpleList1.Id[index1], attackx, attacky, true) + this.AverageCombatPerform(-1, simpleList1.Id[index1], attackx, attacky) / 2f;
                    else if (this.TPlanObj[aiPlanNr].Stand == 1)
                      a = this.AverageCombatPerform(-1, simpleList1.Id[index1], attackx, attacky) + this.AverageCombatPerform(-1, simpleList1.Id[index1], attackx, attacky, true) / 2f;
                    if ((double) a > 10.0)
                      a = 10f;
                    if ((double) a < 0.1)
                      a = 0.1f;
                    ++tid;
                    simpleList2.Add(tid, (int) Math.Round((double) (a * 10f)));
                  }
                }
                else if (this.TPlanObj[aiPlanNr].Type == 40 && -(-1 < this.AreaDistance(this.HexSA[attackx, attacky], this.GetAreaNr(this.TPlanObj[aiPlanNr].FromArea)) ? 1 : 0) <= 1 && this.game.Data.MapObj[0].HexObj[attackx, attacky].UnitCounter > -1)
                {
                  a = this.AverageCombatPerform(-1, simpleList1.Id[index1], attackx, attacky) + this.AverageCombatPerform(-1, simpleList1.Id[index1], attackx, attacky, true) / 2f;
                  if ((double) a > 10.0)
                    a = 10f;
                  if ((double) a < 0.1)
                    a = 0.1f;
                  ++tid;
                  simpleList2.Add(tid, (int) Math.Round((double) a));
                }
              }
            }
          }
          if (simpleList2.Counter > -1)
          {
            simpleList2.Sort();
            num1 = simpleList2.Counter <= 0 ? (int) Math.Round((double) num1 * ((double) (simpleList2.Weight[0] + simpleList2.Weight[simpleList2.Counter]) / 2.0)) : (int) Math.Round((double) num1 * ((double) (simpleList2.Weight[(int) Math.Round((double) (Conversion.Int(VBMath.Rnd() * (float) simpleList2.Counter) + 1f))] + simpleList2.Weight[(int) Math.Round((double) (Conversion.Int(VBMath.Rnd() * (float) simpleList2.Counter) + 1f))] + simpleList2.Weight[0] + simpleList2.Weight[simpleList2.Counter]) / 4.0));
          }
        }
        else
          num1 = simpleList1.Weight[index1];
        int num17 = (int) Math.Round((double) ((float) num1 * num12));
        if (randomeffect)
          num17 = (int) Math.Round((double) num17 * 0.5 + (double) num17 * (double) VBMath.Rnd());
        simpleList1.Weight[index1] = num17;
      }
      simpleList1.Sort();
      return simpleList1.Data1[simpleList1.Counter];
    }

    public void MakeCombatMatrix()
    {
      bool flag = false;
      if (flag)
      {
        this.LogCounter = -1;
        this.AddLog("COMBATMATRIX");
      }
      this.CombatMatrix = new float[this.game.Data.SFTypeCounter + 1, this.game.Data.SFTypeCounter + 1];
      int sfTypeCounter1 = this.game.Data.SFTypeCounter;
      for (int index1 = 0; index1 <= sfTypeCounter1; ++index1)
      {
        if (flag)
          this.AddLog("********* " + this.game.Data.SFTypeObj[index1].Name + " VERSUS: ");
        int sfTypeCounter2 = this.game.Data.SFTypeCounter;
        for (int index2 = 0; index2 <= sfTypeCounter2; ++index2)
        {
          int num1 = this.game.Data.SFTypeObj[index1].AttackPower[this.game.Data.SFTypeObj[index2].UnitGroup] * this.game.Data.SFTypeObj[index1].Attacks;
          int num2 = this.game.Data.SFTypeObj[index2].AttackPowerDef[this.game.Data.SFTypeObj[index1].UnitGroup] * this.game.Data.SFTypeObj[index2].Attacks;
          int num3 = this.game.Data.SFTypeObj[index1].HitPoints[this.game.Data.SFTypeObj[index2].UnitGroup];
          int num4 = this.game.Data.SFTypeObj[index2].HitPointsDef[this.game.Data.SFTypeObj[index1].UnitGroup];
          if (this.game.Data.SFTypeObj[index2].BackBench & this.game.Data.SFTypeObj[index1].Theater == 0)
            num4 *= 2;
          if (this.game.Data.SFTypeObj[index1].BackBench & this.game.Data.SFTypeObj[index2].Theater == 0)
            num3 *= 4;
          int num5 = this.game.Data.SFTypeObj[index1].PowerPts;
          int num6 = this.game.Data.SFTypeObj[index2].PowerPts;
          if (num6 == 0)
            num6 = 1;
          if (num5 == 0)
            num5 = 1;
          float num7 = 1f;
          float num8 = 1f;
          if (num5 > num6)
          {
            num2 = (int) Math.Round((double) num2 * ((double) num5 / (double) num6));
            num4 = (int) Math.Round((double) num4 * ((double) num5 / (double) num6));
            num8 *= (float) num5 / (float) num6;
          }
          else if (num6 > num5)
          {
            num1 = (int) Math.Round((double) num1 * ((double) num6 / (double) num5));
            num3 = (int) Math.Round((double) num3 * ((double) num6 / (double) num5));
            num7 *= (float) num6 / (float) num5;
          }
          if ((double) num7 * (double) this.game.Data.SFTypeObj[index1].Attacks > (double) num8 * (double) this.game.Data.SFTypeObj[index2].MaxAttacked)
            num1 = (int) Math.Round((double) ((float) num1 * (float) ((double) num8 * (double) this.game.Data.SFTypeObj[index2].MaxAttacked / ((double) num7 * (double) this.game.Data.SFTypeObj[index1].Attacks))));
          if ((double) num8 * (double) this.game.Data.SFTypeObj[index2].Attacks > (double) num7 * (double) this.game.Data.SFTypeObj[index1].MaxAttacked)
            num2 = (int) Math.Round((double) ((float) num2 * (float) ((double) num7 * (double) this.game.Data.SFTypeObj[index1].MaxAttacked / ((double) num8 * (double) this.game.Data.SFTypeObj[index2].Attacks))));
          float num9 = (float) num1 / (float) num4;
          float num10 = (float) num2 / (float) num3;
          float Number = (double) num10 <= 0.0 ? 10f : num9 / num10;
          if ((double) Number > 5.0)
            Number = (float) (5.0 + Math.Sqrt((double) Number - 4.0));
          if ((double) Number < 0.1)
            Number = 0.1f;
          this.CombatMatrix[index1, index2] = Number;
          if (this.game.Data.SFTypeObj[index1].Theater == this.game.Data.SFTypeObj[index2].Theater | (double) num9 > 0.0 && flag)
            this.AddLog(this.game.Data.SFTypeObj[index2].Name + " = " + Conversion.Str((object) Number));
        }
      }
    }

    public float AverageCombatPerform(
      int sfnrxxx,
      int typ,
      int attackx,
      int attacky,
      bool defend = false,
      bool onlysametheater = false)
    {
      int[] numArray1 = new int[this.game.Data.SFTypeCounter + 1];
      float[] numArray2 = new float[this.game.Data.SFTypeCounter + 1];
      float[] numArray3 = new float[this.game.Data.SFTypeCounter + 1];
      if (this.CombatMatrix.GetUpperBound(0) == this.game.Data.SFTypeCounter)
      {
        int unitCounter = this.game.Data.MapObj[0].HexObj[attackx, attacky].UnitCounter;
        int num1;
        int num2;
        for (int index1 = 0; index1 <= unitCounter; ++index1)
        {
          int unit = this.game.Data.MapObj[0].HexObj[attackx, attacky].UnitList[index1];
          int sfCount = this.game.Data.UnitObj[unit].SFCount;
          for (int index2 = 0; index2 <= sfCount; ++index2)
          {
            int sf = this.game.Data.UnitObj[unit].SFList[index2];
            int num3 = this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].PowerPts;
            if (!onlysametheater | this.game.Data.SFTypeObj[typ].Theater == this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater)
            {
              float num4 = !defend ? this.CombatMatrix[typ, this.game.Data.SFObj[sf].Type] * this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].CombatModAtt[this.game.Data.MapObj[0].HexObj[attackx, attacky].LandscapeType] : this.CombatMatrix[this.game.Data.SFObj[sf].Type, typ] * this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].CombatModDef[this.game.Data.MapObj[0].HexObj[attackx, attacky].LandscapeType];
              num1 = (int) Math.Round((double) ((float) num1 + num4 * (float) num3));
              num2 += num3;
            }
          }
        }
        return num2 <= 0 ? 1f : (float) num1 / (float) num2;
      }
      float num5;
      if (!defend)
      {
        int sfTypeCounter1 = this.game.Data.SFTypeCounter;
        for (int index = 0; index <= sfTypeCounter1; ++index)
        {
          float num6 = (float) this.game.Data.SFTypeObj[typ].AttackPower[this.game.Data.SFTypeObj[index].UnitGroup] * this.game.Data.SFTypeObj[typ].CombatModAtt[this.game.Data.MapObj[0].HexObj[attackx, attacky].LandscapeType] * (float) this.game.Data.SFTypeObj[typ].Attacks;
          float num7 = (float) Conversion.Int((double) this.game.Data.SFTypeObj[typ].KillPercent / 100.0 * 10.0 * 100.0 * ((double) num6 / (double) this.game.Data.SFTypeObj[index].DefPower));
          if ((double) num7 > 9999.0)
            num7 = 9999f;
          float num8 = this.game.Data.SFTypeObj[typ].PowerPts <= 0 ? num7 : num7 * ((float) this.game.Data.SFTypeObj[index].PowerPts / (float) this.game.Data.SFTypeObj[typ].PowerPts);
          numArray2[index] = num8;
          float num9 = (float) this.game.Data.SFTypeObj[index].AttackPowerDef[this.game.Data.SFTypeObj[typ].UnitGroup] * this.game.Data.SFTypeObj[typ].CombatModDef[this.game.Data.MapObj[0].HexObj[attackx, attacky].LandscapeType] * (float) this.game.Data.SFTypeObj[index].Attacks;
          float num10 = (float) Conversion.Int((double) this.game.Data.SFTypeObj[index].KillPercent / 100.0 * 10.0 * 100.0 * ((double) num9 / (double) this.game.Data.SFTypeObj[typ].DefPower));
          if (this.game.Data.SFTypeObj[typ].BackBench)
            num10 /= this.game.Data.RuleVar[222];
          if (this.game.Data.SFTypeObj[typ].ArtRange > 1)
            num10 /= 3f;
          if ((double) num10 > 9999.0)
            num10 = 9999f;
          numArray3[index] = num10;
        }
        int unitCounter = this.game.Data.MapObj[0].HexObj[attackx, attacky].UnitCounter;
        int num11;
        for (int index3 = 0; index3 <= unitCounter; ++index3)
        {
          int unit = this.game.Data.MapObj[0].HexObj[attackx, attacky].UnitList[index3];
          int sfCount = this.game.Data.UnitObj[unit].SFCount;
          for (int index4 = 0; index4 <= sfCount; ++index4)
          {
            int sf = this.game.Data.UnitObj[unit].SFList[index4];
            int num12 = this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].PowerPts;
            if (this.game.Data.SFTypeObj[typ].Theater == this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater)
              num12 *= 10;
            if (!onlysametheater | this.game.Data.SFTypeObj[typ].Theater == this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater)
            {
              int[] numArray4 = numArray1;
              int[] numArray5 = numArray4;
              int type = this.game.Data.SFObj[sf].Type;
              int index5 = type;
              int num13 = numArray4[type] + num12;
              numArray5[index5] = num13;
              num11 += num12;
            }
          }
        }
        int sfTypeCounter2 = this.game.Data.SFTypeCounter;
        float num14;
        float num15;
        for (int index = 0; index <= sfTypeCounter2; ++index)
        {
          if (numArray1[index] > 0)
          {
            num14 += numArray2[index] * ((float) numArray1[index] / (float) num11);
            num15 += numArray3[index] * ((float) numArray1[index] / (float) num11);
          }
        }
        if ((double) num14 == 0.0)
          num14 = 1f;
        if ((double) num15 == 0.0)
          num15 = 1f;
        num5 = num14 / num15;
      }
      else
      {
        int sfTypeCounter3 = this.game.Data.SFTypeCounter;
        for (int index = 0; index <= sfTypeCounter3; ++index)
        {
          float num16 = (float) this.game.Data.SFTypeObj[typ].AttackPowerDef[this.game.Data.SFTypeObj[index].UnitGroup] * this.game.Data.SFTypeObj[typ].CombatModDef[this.game.Data.MapObj[0].HexObj[attackx, attacky].LandscapeType] * (float) this.game.Data.SFTypeObj[typ].Attacks;
          float num17 = (float) Conversion.Int((double) this.game.Data.SFTypeObj[typ].KillPercent / 100.0 * 10.0 * 100.0 * ((double) num16 / (double) this.game.Data.SFTypeObj[index].DefPower));
          if ((double) num17 > 9999.0)
            num17 = 9999f;
          if (this.game.Data.SFTypeObj[typ].PowerPts > 0)
            num17 *= (float) this.game.Data.SFTypeObj[index].PowerPts / (float) this.game.Data.SFTypeObj[typ].PowerPts;
          numArray2[index] = num17;
          float num18 = (float) this.game.Data.SFTypeObj[index].AttackPower[this.game.Data.SFTypeObj[typ].UnitGroup] * this.game.Data.SFTypeObj[typ].CombatModAtt[this.game.Data.MapObj[0].HexObj[attackx, attacky].LandscapeType] * (float) this.game.Data.SFTypeObj[index].Attacks;
          float num19 = (float) Conversion.Int((double) this.game.Data.SFTypeObj[index].KillPercent / 100.0 * 10.0 * 100.0 * ((double) num18 / (double) this.game.Data.SFTypeObj[typ].DefPower));
          if (this.game.Data.SFTypeObj[typ].BackBench)
            num19 /= this.game.Data.RuleVar[222];
          if (this.game.Data.SFTypeObj[typ].ArtRange > 1)
            num19 /= 3f;
          if ((double) num19 > 9999.0)
            num19 = 9999f;
          numArray3[index] = num19;
        }
        int unitCounter = this.game.Data.MapObj[0].HexObj[attackx, attacky].UnitCounter;
        int num20;
        for (int index6 = 0; index6 <= unitCounter; ++index6)
        {
          int unit = this.game.Data.MapObj[0].HexObj[attackx, attacky].UnitList[index6];
          int sfCount = this.game.Data.UnitObj[unit].SFCount;
          for (int index7 = 0; index7 <= sfCount; ++index7)
          {
            int sf = this.game.Data.UnitObj[unit].SFList[index7];
            int num21 = this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].PowerPts;
            if (this.game.Data.SFTypeObj[typ].Theater == this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater)
              num21 *= 10;
            if (!onlysametheater | this.game.Data.SFTypeObj[typ].Theater == this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Theater)
            {
              int[] numArray6 = numArray1;
              int[] numArray7 = numArray6;
              int type = this.game.Data.SFObj[sf].Type;
              int index8 = type;
              int num22 = numArray6[type] + num21;
              numArray7[index8] = num22;
              num20 += num21;
            }
          }
        }
        int sfTypeCounter4 = this.game.Data.SFTypeCounter;
        float num23;
        float num24;
        for (int index = 0; index <= sfTypeCounter4; ++index)
        {
          if (numArray1[index] > 0)
          {
            num23 += numArray2[index] * ((float) numArray1[index] / (float) num20);
            num24 += numArray3[index] * ((float) numArray1[index] / (float) num20);
          }
        }
        if ((double) num23 == 0.0)
          num23 = 1f;
        if ((double) num24 == 0.0)
          num24 = 1f;
        num5 = num23 / num24;
      }
      return num5;
    }

    public int GetHexForceLandStrength(
      int x,
      int y,
      bool withoutmods = false,
      bool asattack = false,
      int attackx = -1,
      int attacky = -1)
    {
      int unitCounter = this.game.Data.MapObj[0].HexObj[x, y].UnitCounter;
      int forceLandStrength;
      for (int index = 0; index <= unitCounter; ++index)
        forceLandStrength += this.GetForceLandStrength(this.game.Data.MapObj[0].HexObj[x, y].UnitList[index], withoutmods, asattack, attackx, attacky);
      return forceLandStrength;
    }

    public int GetHexForceAirStrength(
      int x,
      int y,
      bool withoutmods = false,
      bool asattack = false,
      int attackx = -1,
      int attacky = -1)
    {
      int unitCounter = this.game.Data.MapObj[0].HexObj[x, y].UnitCounter;
      int forceAirStrength;
      for (int index = 0; index <= unitCounter; ++index)
        forceAirStrength += this.GetForceAirStrength(this.game.Data.MapObj[0].HexObj[x, y].UnitList[index], withoutmods, asattack, attackx, attacky);
      return forceAirStrength;
    }

    public int GetClosestFrontline(int x, int y)
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      if (x == -1)
        return 0;
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
          numArray[index1, index2] = 0;
      }
      int closestFrontline = 0;
      int num1 = 9999;
      int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
      for (int x2 = 0; x2 <= mapWidth2; ++x2)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int y2 = 0; y2 <= mapHeight; ++y2)
        {
          if (this.HexPlan[x2, y2] > 0 & this.HexOA[x, y] == this.HexOA[x2, y2] && this.TPlanObj[this.HexPlan[x2, y2]].Type == 20)
          {
            int num2 = this.game.HandyFunctionsObj.Distance(x, y, 0, x2, y2, 0);
            if (num1 > num2)
            {
              num1 = num2;
              closestFrontline = this.HexPlan[x2, y2];
            }
          }
        }
      }
      return closestFrontline;
    }

    public int GetClosestBackPlan(int x, int y)
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      if (x == -1)
        return 0;
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
          numArray[index1, index2] = 0;
      }
      int closestBackPlan = 0;
      int num1 = 9999;
      int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
      for (int x2 = 0; x2 <= mapWidth2; ++x2)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int y2 = 0; y2 <= mapHeight; ++y2)
        {
          if (this.HexBackPlan[x2, y2] > 0)
          {
            int num2 = this.game.HandyFunctionsObj.Distance(x, y, 0, x2, y2, 0);
            if (num1 > num2)
            {
              num1 = num2;
              closestBackPlan = this.HexBackPlan[x2, y2];
            }
          }
        }
      }
      return closestBackPlan;
    }

    public int GetClosestFrontlineDistance2(int x, int y)
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
          numArray[index1, index2] = 0;
      }
      int num1 = 0;
      int frontlineDistance2 = 9999;
      int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
      for (int x2 = 0; x2 <= mapWidth2; ++x2)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int y2 = 0; y2 <= mapHeight; ++y2)
        {
          if (this.HexPlan[x2, y2] > 0 && this.TPlanObj[this.HexPlan[x2, y2]].Type == 20)
          {
            int num2 = this.game.HandyFunctionsObj.Distance(x, y, 0, x2, y2, 0);
            if (frontlineDistance2 > num2)
            {
              frontlineDistance2 = num2;
              num1 = this.HexPlan[x2, y2];
            }
          }
        }
      }
      return frontlineDistance2;
    }

    public int GetClosestEnemyDistance(int x, int y, bool enemyunit = false)
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
          numArray[index1, index2] = 0;
      }
      int num1 = 0;
      int closestEnemyDistance = 9999;
      int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
      for (int x2 = 0; x2 <= mapWidth2; ++x2)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int y2 = 0; y2 <= mapHeight; ++y2)
        {
          if (this.game.Data.MapObj[0].HexObj[x2, y2].Regime > -1 && this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[x2, y2].Regime))
          {
            int num2 = this.game.HandyFunctionsObj.Distance(x, y, 0, x2, y2, 0);
            if (enemyunit && this.game.Data.MapObj[0].HexObj[x2, y2].UnitCounter < 0)
              num2 = 99999;
            if (closestEnemyDistance > num2)
            {
              closestEnemyDistance = num2;
              num1 = this.HexPlan[x2, y2];
            }
          }
        }
      }
      return closestEnemyDistance;
    }

    public int GetClosestFrontlineDistance(int sanr, int x, int y, bool withunit = false)
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
          numArray[index1, index2] = 0;
      }
      int num1 = 0;
      int frontlineDistance = 9999;
      int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
      for (int x2 = 0; x2 <= mapWidth2; ++x2)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int y2 = 0; y2 <= mapHeight; ++y2)
        {
          if (this.HexSA[x2, y2] == sanr)
          {
            int num2 = 1;
            if (this.game.Data.MapObj[0].HexObj[x2, y2].UnitCounter < 0 & withunit)
              num2 = 0;
            if (num2 == 1)
            {
              int num3 = this.game.HandyFunctionsObj.Distance(x, y, 0, x2, y2, 0);
              if (frontlineDistance > num3)
              {
                frontlineDistance = num3;
                num1 = this.HexSA[x2, y2];
              }
            }
          }
        }
      }
      return frontlineDistance;
    }

    public int GetSANr(SAClass TempArea)
    {
      int saCount = this.SACount;
      for (int saNr = 1; saNr <= saCount; ++saNr)
      {
        if (this.SAObj[saNr].X == TempArea.X & this.SAObj[saNr].Y == TempArea.Y)
          return saNr;
      }
      return 0;
    }

    public int AverageFuzzyVP()
    {
      int saCount = this.SACount;
      int num;
      for (int index = 1; index <= saCount; ++index)
        num += this.SAObj[index].fuzzyvp;
      return (int) Math.Round(Conversion.Int((double) num / (double) this.SACount));
    }

    public int GetFriendlyAreaNeighbours(int areanr, bool withoutenemies)
    {
      int index1 = areanr;
      int neighbourCount = this.SAObj[index1].NeighbourCount;
      int friendlyAreaNeighbours;
      for (int index2 = 1; index2 <= neighbourCount; ++index2)
      {
        int areanr1 = this.SAObj[index1].Neighbour[index2];
        if (!this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.MapObj[0].HexObj[this.SAObj[index1].X, this.SAObj[index1].Y].Regime, this.game.Data.MapObj[0].HexObj[this.SAObj[areanr1].X, this.SAObj[areanr1].Y].Regime))
        {
          int num = 1;
          if (withoutenemies && this.GetFriendlyAreaNeighbours(areanr1, false) < this.SAObj[areanr1].NeighbourCount)
            num = 0;
          if (num == 1)
            ++friendlyAreaNeighbours;
        }
      }
      return friendlyAreaNeighbours;
    }

    public int GetBestNeighbourForRetreater(int areanr)
    {
      int neighbourCount = this.SAObj[areanr].NeighbourCount;
      for (int index = 1; index <= neighbourCount; ++index)
      {
        int areanr1 = this.SAObj[areanr].Neighbour[index];
        if (!this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.MapObj[0].HexObj[this.SAObj[areanr].X, this.SAObj[areanr].Y].Regime, this.game.Data.MapObj[0].HexObj[this.SAObj[areanr1].X, this.SAObj[areanr1].Y].Regime))
        {
          if (this.GetFriendlyAreaNeighbours(areanr1, false) == this.SAObj[areanr1].NeighbourCount)
            return areanr1;
        }
      }
      return -1;
    }

    public int AreaDistance(int nr, int nr2, bool onlyfriendly = false, int MaxDistance = 999)
    {
      int[] numArray = new int[this.SACount + 1];
      int saCount1 = this.SACount;
      for (int index = 1; index <= saCount1; ++index)
        numArray[index] = -1;
      int num1 = 1;
      int num2 = 0;
      numArray[nr] = 0;
      while (num1 == 1 & num2 < MaxDistance)
      {
        num1 = 0;
        ++num2;
        int saCount2 = this.SACount;
        for (int index = 1; index <= saCount2; ++index)
        {
          if (numArray[index] == num2 - 1)
          {
            int saCount3 = this.SACount;
            for (int nr1 = 1; nr1 <= saCount3; ++nr1)
            {
              if (this.SAObj[index].IsNeighbour(nr1) && !onlyfriendly | this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[this.SAObj[nr1].X, this.SAObj[nr1].Y].Regime) && numArray[nr1] == -1)
              {
                numArray[nr1] = num2;
                if (nr1 == nr2)
                  return num2;
                num1 = 1;
              }
            }
          }
        }
      }
      return numArray[nr2];
    }

    public int AreaDistance2(int nr, int nr2, bool onlyfriendly = false, int MaxDistance = 999)
    {
      int[] numArray = new int[this.SACount + 1];
      int saCount1 = this.SACount;
      for (int index = 1; index <= saCount1; ++index)
        numArray[index] = -1;
      int num1 = 1;
      int num2 = 0;
      numArray[nr] = 0;
      while (num1 == 1 & num2 < MaxDistance)
      {
        num1 = 0;
        ++num2;
        int saCount2 = this.SACount;
        for (int index1 = 1; index1 <= saCount2; ++index1)
        {
          if (numArray[index1] == num2 - 1)
          {
            int neighbourCount = this.SAObj[index1].NeighbourCount;
            for (int index2 = 1; index2 <= neighbourCount; ++index2)
            {
              int index3 = this.SAObj[index1].Neighbour[index2];
              if (index3 > 0 && !onlyfriendly | this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, this.game.Data.MapObj[0].HexObj[this.SAObj[index3].X, this.SAObj[index3].Y].Regime) && numArray[index3] == -1)
              {
                numArray[index3] = num2;
                if (index3 == nr2)
                  return num2;
                num1 = 1;
              }
            }
          }
        }
      }
      return numArray[nr2];
    }

    public int AreaDistanceIncludingSea(int nr, int nr2)
    {
      int[] numArray = new int[this.SACount + 1];
      int saCount1 = this.SACount;
      for (int index = 1; index <= saCount1; ++index)
        numArray[index] = -1;
      int num1 = 1;
      int num2 = 0;
      numArray[nr] = 0;
      while (num1 == 1)
      {
        num1 = 0;
        ++num2;
        int saCount2 = this.SACount;
        for (int index = 1; index <= saCount2; ++index)
        {
          if (numArray[index] == num2 - 1)
          {
            int saCount3 = this.SACount;
            for (int nr1 = 1; nr1 <= saCount3; ++nr1)
            {
              if (this.SAObj[index].IsNeighbour(nr1) | this.SAObj[index].IsSeaNeighbour(nr1) && numArray[nr1] == -1)
              {
                numArray[nr1] = num2;
                if (nr1 == nr2)
                  return num2;
                num1 = 1;
              }
            }
          }
        }
      }
      return numArray[nr2];
    }

    public int AreaDistanceOnlySea(int nr, int nr2)
    {
      int[] numArray = new int[this.SACount + 1];
      int saCount1 = this.SACount;
      for (int index = 1; index <= saCount1; ++index)
        numArray[index] = -1;
      int num1 = 1;
      int num2 = 0;
      numArray[nr] = 0;
      while (num1 == 1)
      {
        num1 = 0;
        ++num2;
        int saCount2 = this.SACount;
        for (int index = 1; index <= saCount2; ++index)
        {
          if (numArray[index] == num2 - 1)
          {
            int saCount3 = this.SACount;
            for (int nr1 = 1; nr1 <= saCount3; ++nr1)
            {
              if (this.SAObj[index].IsSeaNeighbour(nr1) && numArray[nr1] == -1)
              {
                numArray[nr1] = num2;
                if (nr1 == nr2)
                  return num2;
                num1 = 1;
              }
            }
          }
        }
      }
      return numArray[nr2];
    }

    public void AddtPlan()
    {
      ++this.TPlanCount;
      this.TPlanObj = (AIPlanClass[]) Utils.CopyArray((Array) this.TPlanObj, (Array) new AIPlanClass[this.TPlanCount + 1]);
      this.TPlanObj[this.TPlanCount] = new AIPlanClass();
    }

    public void Removetplan(int nr)
    {
      if (nr < this.TPlanCount)
      {
        int num1 = nr;
        int num2 = this.TPlanCount - 1;
        for (int index = num1; index <= num2; ++index)
          this.TPlanObj[index] = this.TPlanObj[index + 1];
      }
      --this.TPlanCount;
      this.TPlanObj = (AIPlanClass[]) Utils.CopyArray((Array) this.TPlanObj, (Array) new AIPlanClass[this.TPlanCount + 1]);
    }

    public int getclosestplan(int x, int y, int plantype)
    {
      int num;
      for (; num < 99; ++num)
      {
        int nr = this.HexSA[x, y];
        int tplanCount1 = this.TPlanCount;
        for (int index = 1; index <= tplanCount1; ++index)
        {
          if (this.TPlanObj[index].Type == plantype && this.GetAreaNr(this.TPlanObj[index].FromArea) == nr)
            return index;
        }
        int saCount = this.SACount;
        for (int nr2 = 0; nr2 <= saCount; ++nr2)
        {
          if (this.AreaDistance(nr, nr2) == num)
          {
            int tplanCount2 = this.TPlanCount;
            for (int index = 1; index <= tplanCount2; ++index)
            {
              if (this.TPlanObj[index].Type == plantype && this.GetAreaNr(this.TPlanObj[index].FromArea) == nr2)
                return index;
            }
          }
        }
      }
      return -1;
    }

    public int getclosestplansea(int x, int y, int plantype)
    {
      int num;
      for (; num < 99; ++num)
      {
        int nr = this.HexSA[x, y];
        int tplanCount1 = this.TPlanCount;
        for (int index = 1; index <= tplanCount1; ++index)
        {
          if (this.TPlanObj[index].Type == plantype && this.GetAreaNr(this.TPlanObj[index].FromArea) == nr)
            return index;
        }
        int saCount = this.SACount;
        for (int nr2 = 0; nr2 <= saCount; ++nr2)
        {
          if (this.AreaDistanceOnlySea(nr, nr2) == num)
          {
            int tplanCount2 = this.TPlanCount;
            for (int index = 1; index <= tplanCount2; ++index)
            {
              if (this.TPlanObj[index].Type == plantype && this.GetAreaNr(this.TPlanObj[index].FromArea) == nr2)
                return index;
            }
          }
        }
      }
      return -1;
    }

    public int getfrontplan(int x, int y)
    {
      int num1 = 20;
      int num2 = this.HexSA[x, y];
      int tplanCount = this.TPlanCount;
      for (int index = 1; index <= tplanCount; ++index)
      {
        if (this.TPlanObj[index].Type == num1 && this.GetAreaNr(this.TPlanObj[index].FromArea) == num2)
          return index;
      }
      return -1;
    }

    public int GetRealForceInArea(int areanr, int plannr, bool withoutmods)
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      int realForceInArea;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.HexSA[index1, index2] == areanr)
          {
            int unitCounter = this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter;
            for (int index3 = 0; index3 <= unitCounter; ++index3)
            {
              int unit = this.game.Data.MapObj[0].HexObj[index1, index2].UnitList[index3];
              if (this.game.Data.UnitObj[unit].AIPlanNr == plannr)
                realForceInArea += this.GetForceLandStrength(unit, withoutmods);
            }
          }
        }
      }
      return realForceInArea;
    }

    public int GetRealForceInArea2(int areanr, bool withoutmods)
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      int realForceInArea2;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.HexSA[index1, index2] == areanr)
          {
            int unitCounter = this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter;
            for (int index3 = 0; index3 <= unitCounter; ++index3)
            {
              int unit = this.game.Data.MapObj[0].HexObj[index1, index2].UnitList[index3];
              realForceInArea2 += this.GetForceLandStrength(unit, withoutmods);
            }
          }
        }
      }
      return realForceInArea2;
    }

    public int GetRealNavalForceInArea(int seaareanr, int plannr, bool withoutmods, bool friendly)
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      int navalForceInArea;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.HexSeaSA[index1, index2] == seaareanr | seaareanr == -1)
          {
            int unitCounter = this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter;
            for (int index3 = 0; index3 <= unitCounter; ++index3)
            {
              int unit = this.game.Data.MapObj[0].HexObj[index1, index2].UnitList[index3];
              if (friendly)
              {
                if (this.game.Data.UnitObj[unit].Regime == this.game.Data.Turn && this.game.Data.UnitObj[unit].AIPlanNr == plannr)
                  navalForceInArea += this.GetForceNavalStrength(unit, withoutmods);
              }
              else if (this.game.HandyFunctionsObj.IsHostileNotSelf(this.game.Data.Turn, this.game.Data.UnitObj[unit].Regime))
                navalForceInArea += this.GetForceNavalStrength(unit, withoutmods);
            }
          }
        }
      }
      return navalForceInArea;
    }

    public void Screenshot(int typ, string fileextension)
    {
      FileStream fileStream = new FileStream(this.game.AppPath + "logs/screenshot_typ" + Strings.Trim(Conversion.Str((object) typ)) + "_pl" + Strings.Trim(Conversion.Str((object) this.game.Data.Turn)) + fileextension + ".bmp", FileMode.Create);
      Bitmap bitmap = new Bitmap(this.game.Data.MapObj[0].MapWidth * 40 + 80, this.game.Data.MapObj[0].MapHeight * 32 + 68, PixelFormat.Format24bppRgb);
      bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      if (typ == 1)
      {
        DrawMod.DrawText(ref graphics, "SA", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 10, bitmap.Height - 15);
        this.Screenshotgrid(ref graphics);
        this.Screenshot1(ref graphics);
      }
      if (typ == 2)
      {
        DrawMod.DrawText(ref graphics, "Plan Frontlines", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 10, bitmap.Height - 15);
        this.Screenshotgrid(ref graphics);
        this.Screenshot2(ref graphics);
      }
      if (typ == 3)
      {
        DrawMod.DrawText(ref graphics, "Matrix1", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 10, bitmap.Height - 15);
        this.Screenshotgrid(ref graphics);
        this.Screenshot3(ref graphics);
      }
      if (typ == 4)
      {
        DrawMod.DrawText(ref graphics, "Matrix2", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 10, bitmap.Height - 15);
        this.Screenshotgrid(ref graphics);
        this.Screenshot4(ref graphics);
      }
      if (typ == 5)
      {
        DrawMod.DrawText(ref graphics, "Continents", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 10, bitmap.Height - 15);
        this.Screenshotgrid(ref graphics);
        this.Screenshot5(ref graphics);
      }
      if (typ == 6)
      {
        DrawMod.DrawText(ref graphics, "Operational Areas", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 10, bitmap.Height - 15);
        this.Screenshotgrid(ref graphics);
        this.Screenshot6(ref graphics);
      }
      if (typ == 7)
      {
        DrawMod.DrawText(ref graphics, "Sea SA", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 10, bitmap.Height - 15);
        this.Screenshotgrid(ref graphics);
        this.Screenshot7(ref graphics);
      }
      graphics.Dispose();
      bitmap.Save((Stream) fileStream, ImageFormat.Bmp);
      fileStream.Close();
    }

    public void Screenshotgrid(ref Graphics g)
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          CustomBitmapClass customBitmapObj = this.game.CustomBitmapObj;
          int cx = index1;
          int cy = index2;
          Bitmap bitmap = (Bitmap) null;
          ref Bitmap local1 = ref bitmap;
          bool flag = false;
          ref bool local2 = ref flag;
          Bitmap objBitmap = customBitmapObj.DrawHex(cx, cy, 0, gBitmap: (ref local1), tFromMapPopup: (ref local2));
          if (index1 == 0 | index1 % 2 == 0)
          {
            DrawMod.DrawScaled(ref g, ref objBitmap, index1 * 40, index2 * 32, 40, 32);
            DrawMod.DrawRectangle(ref g, index1 * 40, index2 * 32, 40, 32, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          }
          else
          {
            DrawMod.DrawScaled(ref g, ref objBitmap, index1 * 40, index2 * 32 + 16, 40, 32);
            DrawMod.DrawRectangle(ref g, index1 * 40, index2 * 32 + 16, 40, 32, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          }
        }
      }
    }

    public void Screenshot5(ref Graphics g)
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.HexContinent[index1, index2] > 0)
          {
            if (index1 == 0 | index1 % 2 == 0)
              DrawMod.DrawTextOutline(ref g, Conversion.Str((object) this.HexContinent[index1, index2]), new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2);
            else
              DrawMod.DrawTextOutline(ref g, Conversion.Str((object) this.HexContinent[index1, index2]), new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2 + 16);
          }
        }
      }
    }

    public void Screenshot6(ref Graphics g)
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.HexOA[index1, index2] > 0)
          {
            if (index1 == 0 | index1 % 2 == 0)
              DrawMod.DrawTextOutline(ref g, Conversion.Str((object) this.HexOA[index1, index2]), new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2);
            else
              DrawMod.DrawTextOutline(ref g, Conversion.Str((object) this.HexOA[index1, index2]), new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2 + 16);
          }
        }
      }
    }

    public void Screenshot7(ref Graphics g)
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.HexSeaSA[index1, index2] > 0)
          {
            if (index1 == 0 | index1 % 2 == 0)
              DrawMod.DrawTextOutline(ref g, Conversion.Str((object) this.HexSeaSA[index1, index2]), new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2);
            else
              DrawMod.DrawTextOutline(ref g, Conversion.Str((object) this.HexSeaSA[index1, index2]), new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2 + 16);
          }
        }
      }
    }

    public void Screenshot1(ref Graphics g)
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.HexSA[index1, index2] > 0)
          {
            if (index1 == 0 | index1 % 2 == 0)
            {
              DrawMod.DrawTextOutline(ref g, Conversion.Str((object) this.HexSA[index1, index2]), new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2);
              DrawMod.DrawTextOutline(ref g, Conversion.Str((object) this.HexSAWithoutTemp[index1, index2]), new Font("Times New Roman", 11f, FontStyle.Italic, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 17);
            }
            else
            {
              DrawMod.DrawTextOutline(ref g, Conversion.Str((object) this.HexSA[index1, index2]), new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2 + 16);
              DrawMod.DrawTextOutline(ref g, Conversion.Str((object) this.HexSAWithoutTemp[index1, index2]), new Font("Times New Roman", 11f, FontStyle.Italic, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 17 + 16);
            }
          }
        }
      }
    }

    public void Screenshot2(ref Graphics g)
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.HexPlan[index1, index2] > 0)
          {
            if (index1 == 0 | index1 % 2 == 0)
              DrawMod.DrawTextOutline(ref g, Conversion.Str((object) this.HexPlan[index1, index2]), new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2);
            else
              DrawMod.DrawTextOutline(ref g, Conversion.Str((object) this.HexPlan[index1, index2]), new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2 + 16);
          }
        }
      }
    }

    public void Screenshot3(ref Graphics g)
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.Matrix1[index1, index2] > 0)
          {
            if (index1 == 0 | index1 % 2 == 0)
              DrawMod.DrawTextOutline(ref g, Conversion.Str((object) this.Matrix1[index1, index2]), new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2);
            else
              DrawMod.DrawTextOutline(ref g, Conversion.Str((object) this.Matrix1[index1, index2]), new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2 + 16);
          }
        }
      }
    }

    public void Screenshot4(ref Graphics g)
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.Matrix2[index1, index2] > 0)
          {
            if (index1 == 0 | index1 % 2 == 0)
              DrawMod.DrawTextOutline(ref g, Conversion.Str((object) this.Matrix2[index1, index2]), new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2);
            else
              DrawMod.DrawTextOutline(ref g, Conversion.Str((object) this.Matrix2[index1, index2]), new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), index1 * 40 + 2, index2 * 32 + 2 + 16);
          }
        }
      }
    }

    public void CloseAI()
    {
      this.CratesCheck();
      this.WriteLog();
      this.WriteLog2();
    }

    public void CratesCheck()
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.game.Data.MapObj[0].HexObj[index1, index2].CardUponConquest > -1)
          {
            int unitCounter = this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter;
            for (int index3 = 0; index3 <= unitCounter; ++index3)
            {
              if (this.game.Data.UnitObj[this.game.Data.MapObj[0].HexObj[index1, index2].UnitList[index3]].Regime == this.game.Data.Turn && this.game.Data.MapObj[0].HexObj[index1, index2].CardUponConquest > -1)
              {
                this.game.EditObj.AreaX = index1;
                this.game.EditObj.AreaY = index2;
                this.game.EditObj.AreaMap = 0;
                this.game.EditObj.DoCardSlot = this.game.Data.MapObj[0].HexObj[index1, index2].CardUponConquest;
                this.game.ProcessingObj.PlayCard(this.game.EditObj.DoCardSlot);
                int num = 0;
                int locCounter = this.game.Data.LocCounter;
                for (int locnr = 0; locnr <= locCounter; ++locnr)
                {
                  if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y].Regime == this.game.Data.Turn)
                  {
                    int index4 = 0;
                    do
                    {
                      if (this.game.Data.LocObj[locnr].Production[index4] > -1 && !this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, this.game.Data.LocObj[locnr].Production[index4]).result)
                      {
                        ++num;
                        this.game.Data.LocObj[locnr].Production[index4] = -1;
                        this.game.Data.LocObj[locnr].ProdPointRemainder[index4] = 0;
                        this.game.Data.LocObj[locnr].ProdPercent[index4] = 0;
                      }
                      ++index4;
                    }
                    while (index4 <= 3);
                  }
                }
                this.game.EditObj.DoCardSlot = -1;
                this.game.Data.MapObj[0].HexObj[index1, index2].CardUponConquest = -1;
                break;
              }
            }
          }
        }
      }
    }

    public void AddLog2(string s)
    {
      ++this.LogCounter2;
      this.LogTxt2 = (string[]) Utils.CopyArray((Array) this.LogTxt2, (Array) new string[this.LogCounter2 + 1]);
      this.LogTxt2[this.LogCounter2] = s;
    }

    public void WriteLog2()
    {
      int num1 = this.game.HandyFunctionsObj.CheckDiskSpace(Strings.Left(this.game.AppPath, Strings.InStr(this.game.AppPath, ":")));
      if (num1 > 0 & num1 < 50)
      {
        int num2 = (int) Interaction.MsgBox((object) "Not of space left to write to disk.");
      }
      else
      {
        StreamWriter text = File.CreateText(this.game.AppPath + "logs/AItimer.txt");
        int logCounter2 = this.LogCounter2;
        for (int index = 0; index <= logCounter2; ++index)
          text.WriteLine(this.LogTxt2[index]);
        text.Close();
      }
    }

    public void AddLog(string s)
    {
      ++this.LogCounter;
      this.LogTxt = (string[]) Utils.CopyArray((Array) this.LogTxt, (Array) new string[this.LogCounter + 1]);
      this.LogTxt[this.LogCounter] = s;
    }

    public void WriteLog()
    {
      int num1 = this.game.HandyFunctionsObj.CheckDiskSpace(Strings.Left(this.game.AppPath, Strings.InStr(this.game.AppPath, ":")));
      if (num1 > 0 & num1 < 50)
      {
        int num2 = (int) Interaction.MsgBox((object) "Not of space left to write to disk.");
      }
      else
      {
        StreamWriter text = File.CreateText(this.game.AppPath + "logs/AIlog_" + Conversion.Str((object) this.game.Data.Turn) + ".txt");
        int logCounter = this.LogCounter;
        for (int index = 0; index <= logCounter; ++index)
          text.WriteLine(this.LogTxt[index]);
        text.Close();
      }
    }

    public object GetAAonHex(int x, int y, int versusattacker)
    {
      Coordinate target = new Coordinate();
      int aaonHex = 0;
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (Math.Abs(index1 - x) < 5 & Math.Abs(index2 - y) < 5)
          {
            int unitCounter = this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter;
            for (int index3 = 0; index3 <= unitCounter; ++index3)
            {
              int unit = this.game.Data.MapObj[0].HexObj[index1, index2].UnitList[index3];
              target.x = index1;
              target.y = index2;
              target.onmap = true;
              if (this.game.HandyFunctionsObj.CanUnitAA(unit, target, versusattacker))
              {
                int sfCount = this.game.Data.UnitObj[unit].SFCount;
                for (int index4 = 0; index4 <= sfCount; ++index4)
                {
                  int sf = this.game.Data.UnitObj[unit].SFList[index4];
                  int type = this.game.Data.SFObj[sf].Type;
                  int num;
                  if (this.game.Data.SFTypeObj[type].AIRoleScore[12] > 0)
                    num = (int) Math.Round((double) (this.game.Data.SFTypeObj[type].PowerPts * this.game.Data.SFObj[sf].Qty) * ((double) this.game.Data.SFTypeObj[type].AIRoleScore[12] / 100.0));
                  aaonHex += num;
                }
              }
            }
          }
        }
      }
      return (object) aaonHex;
    }

    public int GetMeRandomUnit()
    {
      SimpleList simpleList = new SimpleList();
      int unitCounter = this.game.Data.UnitCounter;
      for (int tid = 0; tid <= unitCounter; ++tid)
      {
        if (this.game.Data.UnitObj[tid].Regime == this.game.Data.Turn && this.game.Data.UnitObj[tid].X > -1 & this.game.Data.UnitObj[tid].SupplyConsume >= 100 & this.game.Data.UnitObj[tid].PreDef == -1)
          simpleList.Add(tid, 1);
      }
      return simpleList.Counter > -1 ? simpleList.Id[(int) Math.Round((double) (VBMath.Rnd() * (float) (simpleList.Counter + 1)))] : -1;
    }

    public void ExecResourceComplient()
    {
      int[] numArray1 = new int[500];
      if (!this.game.Data.RegimeObj[this.game.Data.Turn].AI)
        return;
      this.game.ProcessingObj.LocationProductionPrognosis();
      int index1 = 0;
      do
      {
        int num1 = 0;
        do
        {
          int num2 = 0;
          int num3 = this.game.Data.RegimeObj[this.game.Data.Turn].TempRegimeSlotPredict[index1];
          if (num3 < 0 & this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index1] != num3)
          {
            int num4;
            do
            {
              ++num2;
              this.game.ProcessingObj.LocationProductionPrognosis();
              num4 = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index1] + this.game.Data.RegimeObj[this.game.Data.Turn].TempRegimeSlotPredict[index1];
              if (num4 < 0 & this.game.Data.RegimeObj[this.game.Data.Turn].TempRegimeSlotPredict[index1] != 0)
              {
                SimpleList simpleList1 = new SimpleList();
                int locCounter1 = this.game.Data.LocCounter;
                for (int tid = 0; tid <= locCounter1; ++tid)
                {
                  if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[tid].X, this.game.Data.LocObj[tid].Y].Regime == this.game.Data.Turn)
                  {
                    int tdata1 = 0;
                    do
                    {
                      if (this.game.Data.LocObj[tid].ProdPercent[tdata1] > 0)
                      {
                        int tdata2 = this.game.Data.LocObj[tid].Production[tdata1];
                        if (tdata2 > -1)
                        {
                          int index2 = 0;
                          do
                          {
                            if (this.game.Data.ItemTypeObj[tdata2].RegimeSlotsCost[index2] == index1 & this.game.Data.ItemTypeObj[tdata2].RegimeSlotsCostQty[index2] > 0)
                            {
                              int tweight = (int) Math.Round(100.0 / (double) this.game.Data.ItemTypeObj[tdata2].ProdWeight * (double) this.game.Data.ItemTypeObj[tdata2].RegimeSlotsCostQty[index2] * 100.0);
                              if (this.game.Data.ItemTypeObj[tdata2].IsSFType > -1 && this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[tdata2].IsSFType].Theater == 1)
                                tweight = (int) Math.Round((double) Conversion.Int((float) (int) Math.Round((double) tweight / 2.0) * VBMath.Rnd()));
                              simpleList1.Add(tid, tweight, tdata1, tdata2, CheckExistence: false);
                            }
                            ++index2;
                          }
                          while (index2 <= 4);
                        }
                      }
                      ++tdata1;
                    }
                    while (tdata1 <= 3);
                  }
                }
                simpleList1.ReverseSort();
                int num5 = 0;
                int index3 = simpleList1.Data2[0];
                int index4 = simpleList1.Data1[0];
                int locnr = simpleList1.Id[0];
                int[] numArray2 = new int[500];
                int index5 = 0;
                do
                {
                  if (this.game.Data.ItemTypeObj[index3].RegimeSlotsCost[index5] > -1)
                    numArray2[this.game.Data.ItemTypeObj[index3].RegimeSlotsCost[index5]] = this.game.Data.ItemTypeObj[index3].RegimeSlotsCostQty[index5];
                  ++index5;
                }
                while (index5 <= 4);
                if (num5 == 0)
                {
                  SimpleList simpleList2 = new SimpleList();
                  switch (num1)
                  {
                    case 0:
                      int locCounter2 = this.game.Data.LocCounter;
                      for (int index6 = 0; index6 <= locCounter2; ++index6)
                      {
                        if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index6].X, this.game.Data.LocObj[index6].Y].Regime == this.game.Data.Turn)
                        {
                          int index7 = 0;
                          do
                          {
                            if (this.game.Data.LocObj[index6].ProdPercent[index7] > 0)
                            {
                              int tid = this.game.Data.LocObj[index6].Production[index7];
                              if (tid > -1)
                              {
                                int num6 = 1;
                                int index8 = 0;
                                do
                                {
                                  if (this.game.Data.ItemTypeObj[tid].RegimeSlotsCost[index8] > -1)
                                  {
                                    if (this.game.Data.ItemTypeObj[tid].RegimeSlotsCost[index8] == index1 & this.game.Data.ItemTypeObj[tid].RegimeSlotsCostQty[index8] >= numArray2[index1])
                                      num6 = 0;
                                    if (this.game.Data.ItemTypeObj[tid].RegimeSlotsCostQty[index8] >= numArray2[index1])
                                      num6 = 0;
                                  }
                                  ++index8;
                                }
                                while (index8 <= 4);
                                if (num6 == 1 && !(this.game.Data.ItemTypeObj[index3].IsSFType > -1 & this.game.Data.ItemTypeObj[tid].IsSFType == -1) && !(this.game.Data.ItemTypeObj[index3].IsRegimeSlot > -1 & this.game.Data.ItemTypeObj[tid].IsRegimeSlot == -1) && !(this.game.Data.ItemTypeObj[index3].IsSupply & !this.game.Data.ItemTypeObj[tid].IsSupply) && !(this.game.Data.ItemTypeObj[index3].IsResPt & !this.game.Data.ItemTypeObj[tid].IsResPt) && this.game.Data.ItemTypeObj[tid].IsSFType > -1 & this.game.Data.ItemTypeObj[index3].IsSFType > -1 && this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[tid].IsSFType].AIRoleScore[5] <= 0 && this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[tid].IsSFType].AIRoleScore[1] <= 0)
                                  simpleList2.Add(tid, 3000 + (int) Math.Round((double) (VBMath.Rnd() * 1000f)));
                              }
                            }
                            ++index7;
                          }
                          while (index7 <= 3);
                        }
                      }
                      break;
                    case 1:
                      int num7 = 0;
                      do
                      {
                        int meRandomUnit = this.GetMeRandomUnit();
                        if (meRandomUnit > -1)
                        {
                          int tid = this.FindBestSuitedItemType(meRandomUnit, 6, 10000, locnr, true);
                          if (tid == 0)
                            tid = 0;
                          if (tid > -1)
                          {
                            int num8 = 1;
                            int index9 = 0;
                            do
                            {
                              if (this.game.Data.ItemTypeObj[tid].RegimeSlotsCost[index9] > -1)
                              {
                                if (this.game.Data.ItemTypeObj[tid].RegimeSlotsCost[index9] == index1 & this.game.Data.ItemTypeObj[tid].RegimeSlotsCostQty[index9] >= numArray2[index1])
                                  num8 = 0;
                                if (this.game.Data.ItemTypeObj[tid].RegimeSlotsCostQty[index9] >= numArray2[index1])
                                  num8 = 0;
                              }
                              ++index9;
                            }
                            while (index9 <= 4);
                            if (num8 == 1)
                            {
                              if (this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[tid].IsSFType].AIRoleScore[5] > 0)
                                simpleList2.Add(tid, 4000 - this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[tid].IsSFType].AIRoleScore[6] * 10);
                              else if (this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[tid].IsSFType].AIRoleScore[1] > 0)
                                simpleList2.Add(tid, 4000 - this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[tid].IsSFType].AIRoleScore[6] * 10);
                              else
                                simpleList2.Add(tid, 2000 - this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[tid].IsSFType].AIRoleScore[6] * 10);
                            }
                          }
                        }
                        ++num7;
                      }
                      while (num7 <= 10);
                      break;
                    default:
                      int locCounter3 = this.game.Data.LocCounter;
                      for (int index10 = 0; index10 <= locCounter3; ++index10)
                      {
                        if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index10].X, this.game.Data.LocObj[index10].Y].Regime == this.game.Data.Turn)
                        {
                          int index11 = 0;
                          do
                          {
                            if (this.game.Data.LocObj[index10].ProdPercent[index11] > 0)
                            {
                              int tid = this.game.Data.LocObj[index10].Production[index11];
                              if (tid > -1)
                              {
                                int num9 = 1;
                                int index12 = 0;
                                do
                                {
                                  if (this.game.Data.ItemTypeObj[tid].RegimeSlotsCost[index12] > -1)
                                  {
                                    if (this.game.Data.ItemTypeObj[tid].RegimeSlotsCost[index12] == index1 & this.game.Data.ItemTypeObj[tid].RegimeSlotsCostQty[index12] >= numArray2[index1])
                                      num9 = 0;
                                    if (this.game.Data.ItemTypeObj[tid].RegimeSlotsCostQty[index12] >= numArray2[index1])
                                      num9 = 0;
                                  }
                                  ++index12;
                                }
                                while (index12 <= 4);
                                if (num9 == 1)
                                {
                                  if (this.game.Data.ItemTypeObj[index3].IsSFType > -1 & this.game.Data.ItemTypeObj[tid].IsSFType == -1)
                                    simpleList2.Add(tid, 99999);
                                  else if (this.game.Data.ItemTypeObj[index3].IsRegimeSlot > -1 & this.game.Data.ItemTypeObj[tid].IsRegimeSlot == -1)
                                    simpleList2.Add(tid, 99999);
                                  else if (this.game.Data.ItemTypeObj[index3].IsSupply & !this.game.Data.ItemTypeObj[tid].IsSupply)
                                    simpleList2.Add(tid, 99999);
                                  else if (this.game.Data.ItemTypeObj[index3].IsResPt & !this.game.Data.ItemTypeObj[tid].IsResPt)
                                    simpleList2.Add(tid, 99999);
                                  else if (this.game.Data.ItemTypeObj[tid].IsSFType > -1 & this.game.Data.ItemTypeObj[index3].IsSFType > -1)
                                  {
                                    if (this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[tid].IsSFType].AIRoleScore[5] <= 0 && this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[tid].IsSFType].AIRoleScore[1] <= 0)
                                      simpleList2.Add(tid, 3000 + (int) Math.Round((double) (VBMath.Rnd() * 1000f)));
                                  }
                                  else
                                    simpleList2.Add(tid, 5000 + (int) Math.Round((double) (VBMath.Rnd() * 1000f)));
                                }
                              }
                            }
                            ++index11;
                          }
                          while (index11 <= 3);
                        }
                      }
                      break;
                  }
                  simpleList2.Sort();
                  if (simpleList2.Counter > -1)
                  {
                    int counter = simpleList2.Counter;
                    for (int index13 = 0; index13 <= counter; ++index13)
                    {
                      int itemtypenr = simpleList2.Id[index13];
                      if (this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, itemtypenr).result)
                      {
                        this.game.Data.LocObj[locnr].Production[index4] = itemtypenr;
                        break;
                      }
                    }
                  }
                }
              }
            }
            while (num4 < 0 & num2 < 999);
          }
          ++num1;
        }
        while (num1 <= 2);
        ++index1;
      }
      while (index1 <= 499);
    }

    ~AIClass() => base.Finalize();
  }
}
