// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.AITheater
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;

namespace WindowsApplication1
{
  pub class AITheater
  {
    pub DC2AIClass ai;
    pub MapClass map;
    pub AIFront front;
    pub AIFrontList frontList;
    pub AIMatrix FrontArea;
    pub AIMatrix origFrontArea;
    pub AIMatrix Owner;
    pub AIMatrix origAllTroops;
    pub AIMatrix origOwner;
    pub AIMatrix troopsMove;
    pub AIMatrix origEnemyDistance;
    pub AIMatrix enemyDistance;
    pub AIMatrix FriendlySupply;
    pub AIMatrix friendlySupplyIdeal;
    pub AIMatrix enemyPressureFull;
    pub AIMatrix enemySupply;
    pub AIMatrix FriendlyBottleneckIdeal;
    pub AIMatrix FriendlyBottleneck;
    pub AIMatrix ForceRatio;
    pub AIMatrix troopsstrength;
    pub AIMatrix Advance;
    pub AIMatrix EnemyPressure;
    pub AIMatrix TroopsReach;
    pub AIMatrix ShortenFront;
    pub AIMatrix FrontAreaForAttack;
    pub AIMatrix vpMatrix;
    pub AIMatrix FriendlySupplyAfterEnemyMove;
    pub AIMatrix EnemyBottleneck;
    pub AIMatrix EnemyBottleneckOwnFrontOnly;
    pub AIMatrix FriendlyBottleneckIdealOwnFrontOnly;
    pub AIMatrix allTroops;
    pub AIMatrix newOwner;
    pub AIMatrix origAdvance;
    pub AIMatrix[,] MoveCostAttack;
    pub AIMatrix[] MoveTempLos;
    pub AIMatrix[,] MoveCostArtAttack;
    pub AICoordinateMatrix[,] MoveFromAttack;
    pub AICoordinateMatrix[,] MoveFromArtAttack;
    pub AIMatrix[] MoveCostMove;
    pub AIMatrix[] MoveCostArtMove;
    pub AIMatrix[] MoveCostOrgMove;
    pub AICoordinateMatrix[] MoveFromMove;
    pub AICoordinateMatrix[] MoveFromArtMove;
    pub AICoordinateMatrix[] MoveFromOrgMove;
    pub AIMoveList MoveList;
    pub Score: i32;
    pub float initEncRatio3;
    pub float initEncRatio1;
    pub float initEncRatio2;
    pub float initEncRatio4;
    pub float initEncRatio5;
    pub float initEncRatio6;
    pub float initEncRatio7;
    pub float initEncRatio8;
    pub InitTotalTroops: i32;
    pub initFrontTroops: i32;
    pub InitHexes: i32;
    pub initHexesTot: i32;
    pub initOrigEnemyUnits: i32;
     int finalHexes;
     int finalHexesTot;
     float finalEncRatio1;
     float finalEncRatio3;
     float finalEncRatio2;
     float finalEncRatio4;
     float finalEncRatio5;
     float finalEncRatio6;
     int finalOrigEnemyUnits;
    pub currentVP: i32;
    pub triedX: i32;
    pub triedY: i32;
    pub Left: i32;
    pub Top: i32;
    pub Right: i32;
    pub Bottom: i32;
    pub Width: i32;
    pub Height: i32;
    pub LowestRetreatModifierAllowed: i32;

    pub AITheater(DC2AIClass tai, AIFront tfront, AIFrontList tfrontList)
    {
      this.ai = tai;
      this.map = this.ai.game.Data.MapObj[0];
      this.MoveList = AIMoveList::new();
      this.front = tfront;
      this.frontList = tfrontList;
      this.Score = 125;
      if ((double) this.front.UnitCountRatio > 3.0)
        this.Score = 20;
      else if ((double) this.front.UnitCountRatio > 2.0)
        this.Score = 50;
      else if ((double) this.front.UnitCountRatio > 1.5)
      {
        this.Score = 75;
      }
      else
      {
        if ((double) this.front.UnitCountRatio <= 1.0)
          return;
        this.Score = 100;
      }
    }

    pub AITheater Clone()
    {
      AITheater aiTheater = new AITheater(this.ai, this.front, this.frontList);
      aiTheater.MoveList = this.MoveList.Clone();
      aiTheater.Advance = this.Advance;
      aiTheater.origAdvance = this.origAdvance;
      aiTheater.TroopsReach = this.TroopsReach;
      aiTheater.FrontArea = this.FrontArea;
      aiTheater.FrontAreaForAttack = this.FrontAreaForAttack;
      aiTheater.troopsstrength = this.troopsstrength;
      aiTheater.troopsMove = this.troopsMove;
      aiTheater.ForceRatio = this.ForceRatio;
      aiTheater.EnemyPressure = this.EnemyPressure.Clone();
      aiTheater.enemyPressureFull = this.enemyPressureFull;
      aiTheater.enemySupply = this.enemySupply;
      aiTheater.FriendlySupply = this.FriendlySupply;
      aiTheater.friendlySupplyIdeal = this.friendlySupplyIdeal;
      aiTheater.FriendlySupplyAfterEnemyMove = this.FriendlySupplyAfterEnemyMove;
      aiTheater.FriendlyBottleneck = this.FriendlyBottleneck;
      aiTheater.FriendlyBottleneckIdeal = this.FriendlyBottleneckIdeal;
      aiTheater.EnemyBottleneck = this.EnemyBottleneck;
      aiTheater.LowestRetreatModifierAllowed = this.LowestRetreatModifierAllowed;
      aiTheater.vpMatrix = this.vpMatrix;
      aiTheater.EnemyBottleneckOwnFrontOnly = this.EnemyBottleneckOwnFrontOnly;
      aiTheater.FriendlyBottleneckIdealOwnFrontOnly = this.FriendlyBottleneckIdealOwnFrontOnly;
      if (this.front.units.counter > -1)
      {
        aiTheater.MoveCostMove = new AIMatrix[this.MoveCostMove.GetUpperBound(0) + 1];
        aiTheater.MoveTempLos = new AIMatrix[this.MoveTempLos.GetUpperBound(0) + 1];
        aiTheater.MoveFromMove = new AICoordinateMatrix[this.MoveCostMove.GetUpperBound(0) + 1];
        int upperBound1 = this.MoveCostMove.GetUpperBound(0);
        for (int index = 0; index <= upperBound1; index += 1)
        {
          aiTheater.MoveTempLos[index] = this.MoveTempLos[index];
          aiTheater.MoveCostMove[index] = this.MoveCostMove[index];
          aiTheater.MoveFromMove[index] = this.MoveFromMove[index];
        }
        aiTheater.MoveCostAttack = new AIMatrix[this.MoveCostAttack.GetUpperBound(0) + 1, 6];
        aiTheater.MoveFromAttack = new AICoordinateMatrix[this.MoveCostAttack.GetUpperBound(0) + 1, 6];
        int upperBound2 = this.MoveCostAttack.GetUpperBound(0);
        for (int index1 = 0; index1 <= upperBound2; index1 += 1)
        {
          int index2 = 0;
          do
          {
            aiTheater.MoveCostAttack[index1, index2] = this.MoveCostAttack[index1, index2];
            aiTheater.MoveFromAttack[index1, index2] = this.MoveFromAttack[index1, index2];
            index2 += 1;
          }
          while (index2 <= 5);
        }
      }
      if (this.front.artUnits.counter > -1)
      {
        aiTheater.MoveCostArtMove = new AIMatrix[this.MoveCostArtMove.GetUpperBound(0) + 1];
        aiTheater.MoveFromArtMove = new AICoordinateMatrix[this.MoveCostArtMove.GetUpperBound(0) + 1];
        int upperBound3 = this.MoveCostArtMove.GetUpperBound(0);
        for (int index = 0; index <= upperBound3; index += 1)
        {
          aiTheater.MoveCostArtMove[index] = this.MoveCostArtMove[index];
          aiTheater.MoveFromArtMove[index] = this.MoveFromArtMove[index];
        }
        aiTheater.MoveCostArtAttack = new AIMatrix[this.MoveCostArtAttack.GetUpperBound(0) + 1, 6];
        aiTheater.MoveFromArtAttack = new AICoordinateMatrix[this.MoveCostArtAttack.GetUpperBound(0) + 1, 6];
        int upperBound4 = this.MoveCostArtAttack.GetUpperBound(0);
        for (int index3 = 0; index3 <= upperBound4; index3 += 1)
        {
          int index4 = 0;
          do
          {
            aiTheater.MoveCostArtAttack[index3, index4] = this.MoveCostArtAttack[index3, index4];
            aiTheater.MoveFromArtAttack[index3, index4] = this.MoveFromArtAttack[index3, index4];
            index4 += 1;
          }
          while (index4 <= 5);
        }
      }
      if (this.front.orgUnits.counter > -1)
      {
        aiTheater.MoveCostOrgMove = new AIMatrix[this.MoveCostOrgMove.GetUpperBound(0) + 1];
        aiTheater.MoveFromOrgMove = new AICoordinateMatrix[this.MoveCostOrgMove.GetUpperBound(0) + 1];
        int upperBound = this.MoveCostOrgMove.GetUpperBound(0);
        for (int index = 0; index <= upperBound; index += 1)
        {
          aiTheater.MoveCostOrgMove[index] = this.MoveCostOrgMove[index];
          aiTheater.MoveFromOrgMove[index] = this.MoveFromOrgMove[index];
        }
      }
      aiTheater.Score = this.Score;
      aiTheater.InitTotalTroops = this.InitTotalTroops;
      aiTheater.initFrontTroops = this.initFrontTroops;
      aiTheater.Left = this.Left;
      aiTheater.Right = this.Right;
      aiTheater.Bottom = this.Bottom;
      aiTheater.Top = this.Top;
      aiTheater.Width = this.Width;
      aiTheater.Height = this.Height;
      aiTheater.initEncRatio3 = this.initEncRatio3;
      aiTheater.initEncRatio4 = this.initEncRatio4;
      aiTheater.initEncRatio1 = this.initEncRatio1;
      aiTheater.initEncRatio2 = this.initEncRatio2;
      aiTheater.initEncRatio5 = this.initEncRatio5;
      aiTheater.initEncRatio6 = this.initEncRatio6;
      aiTheater.initEncRatio7 = this.initEncRatio7;
      aiTheater.initEncRatio8 = this.initEncRatio8;
      aiTheater.initOrigEnemyUnits = this.initOrigEnemyUnits;
      aiTheater.InitHexes = this.InitHexes;
      aiTheater.initHexesTot = this.initHexesTot;
      aiTheater.currentVP = this.currentVP;
      aiTheater.origOwner = this.origOwner.Clone();
      aiTheater.origEnemyDistance = this.origEnemyDistance.Clone();
      aiTheater.origAllTroops = this.origAllTroops.Clone();
      aiTheater.Owner = this.origOwner.Clone();
      aiTheater.enemyDistance = aiTheater.origEnemyDistance.Clone();
      aiTheater.allTroops = aiTheater.origAllTroops.Clone();
      aiTheater.Score = 0;
      return aiTheater;
    }

    pub void InitializeReserve()
    {
      this.SetMatrixDimensions();
      this.Owner = this.ai.SetOwnerMatrix(this.Left, this.Top, this.Width, this.Height);
      DC2AIClass ai = this.ai;
      AITheater aiTheater = this;
      ref AITheater local1 = ref aiTheater;
      ref AIMatrix local2 = ref this.Owner;
      this.FrontArea = ai.SetFrontAreaMatrix(ref local1, ref local2);
      this.SetMoveCost(500);
      this.enemyDistance = this.Owner.Clone();
      this.enemyDistance.RemoveValuesByMask(this.Owner, 1);
      this.enemyDistance.ExpandAndAddValueForAnyRegime(19);
      this.enemyDistance.SetAllValuesSubtractWith(2);
      this.origEnemyDistance = this.enemyDistance.Clone();
      this.origOwner = this.Owner.Clone();
    }

    pub void InitializeStrategic()
    {
      this.SetMatrixDimensionsAir();
      this.Owner = this.ai.SetOwnerMatrix(this.Left, this.Top, this.Width, this.Height);
      DC2AIClass ai = this.ai;
      AITheater aiTheater = this;
      ref AITheater local1 = ref aiTheater;
      ref AIMatrix local2 = ref this.Owner;
      this.FrontArea = ai.SetFrontAreaMatrix(ref local1, ref local2);
      this.enemyDistance = this.Owner.Clone();
      this.enemyDistance.RemoveValuesByMask(this.Owner, 1);
      this.enemyDistance.ExpandAndAddValueForAnyRegime(19);
      this.enemyDistance.SetAllValuesSubtractWith(2);
      this.SetMoveCost();
      this.origEnemyDistance = this.enemyDistance.Clone();
      this.origOwner = this.Owner.Clone();
    }

    pub void InitializeAir()
    {
      this.SetMatrixDimensionsAir();
      this.Owner = this.ai.SetOwnerMatrix(this.Left, this.Top, this.Width, this.Height);
      DC2AIClass ai = this.ai;
      AITheater aiTheater = this;
      ref AITheater local1 = ref aiTheater;
      ref AIMatrix local2 = ref this.Owner;
      this.FrontArea = ai.SetFrontAreaMatrix(ref local1, ref local2);
      this.FrontArea.RemoveValuesByNotMask(this.FrontArea, this.front.TargetFrontID);
      this.FrontArea.SetAllValuesHigherThenXTo(0, 80);
      this.FrontArea.ExpandAndRemoveValueForAnyRegime(80);
      this.enemyDistance = this.Owner.Clone();
      this.enemyDistance.SetValueXToValueY(0, 2);
      this.enemyDistance.RemoveValuesByMask(this.Owner, 1);
      this.enemyDistance.ExpandAndAddValueForAnyRegime(79);
      this.enemyDistance.SetAllValuesSubtractWith(2);
      this.FriendlySupply = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      this.Setsupplymatrix(ref this.FriendlySupply, ref this.Owner, 1);
      this.SetMoveCost();
      this.origEnemyDistance = this.enemyDistance.Clone();
      this.origOwner = this.Owner.Clone();
    }

    pub void InitializeNavy()
    {
      this.SetMatrixDimensionsAir();
      this.Owner = this.ai.SetOwnerMatrix(this.Left, this.Top, this.Width, this.Height);
      this.SetMoveCost();
      if (!Information.IsNothing((object) this.enemyDistance))
        this.origEnemyDistance = this.enemyDistance.Clone();
      this.origOwner = this.Owner.Clone();
    }

    pub void InitializeAirTransport()
    {
      this.SetMatrixDimensionsAir();
      this.Owner = this.ai.SetOwnerMatrix(this.Left, this.Top, this.Width, this.Height);
      DC2AIClass ai = this.ai;
      AITheater aiTheater = this;
      ref AITheater local1 = ref aiTheater;
      ref AIMatrix local2 = ref this.Owner;
      this.FrontArea = ai.SetFrontAreaMatrix(ref local1, ref local2);
      this.FrontArea.RemoveValuesByNotMask(this.FrontArea, this.front.TargetFrontID);
      this.FrontArea.SetAllValuesHigherThenXTo(0, 60);
      this.FrontArea.ExpandAndRemoveValueForAnyRegime(60);
      this.enemyDistance = this.Owner.Clone();
      this.enemyDistance.RemoveValuesByMask(this.Owner, 1);
      this.enemyDistance.ExpandAndAddValueForAnyRegime(19);
      this.enemyDistance.SetAllValuesSubtractWith(2);
      this.FriendlySupply = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      this.Setsupplymatrix(ref this.FriendlySupply, ref this.Owner, 1);
      this.SetMoveCost();
      this.origEnemyDistance = this.enemyDistance.Clone();
      this.origOwner = this.Owner.Clone();
    }

    pub void InitializeEngineer()
    {
      this.SetMatrixDimensions();
      this.Owner = this.ai.SetOwnerMatrix(this.Left, this.Top, this.Width, this.Height);
      DC2AIClass ai = this.ai;
      AITheater aiTheater = this;
      ref AITheater local1 = ref aiTheater;
      ref AIMatrix local2 = ref this.Owner;
      this.FrontArea = ai.SetFrontAreaMatrix(ref local1, ref local2);
      this.FrontArea.ExpandUniquesValuesForSameRegime(4);
      this.enemyDistance = this.Owner.Clone();
      this.enemyDistance.RemoveValuesByMask(this.Owner, 1);
      this.enemyDistance.ExpandAndAddValueForAnyRegime(19);
      this.enemyDistance.SetAllValuesSubtractWith(2);
      this.SetMoveCost(300);
      this.origEnemyDistance = this.enemyDistance.Clone();
      this.origOwner = this.Owner.Clone();
    }

    pub void InitializeOrg()
    {
      this.SetMatrixDimensions();
      this.Owner = this.ai.SetOwnerMatrix(this.Left, this.Top, this.Width, this.Height);
      DC2AIClass ai = this.ai;
      AITheater aiTheater = this;
      ref AITheater local1 = ref aiTheater;
      ref AIMatrix local2 = ref this.Owner;
      this.FrontArea = ai.SetFrontAreaMatrix(ref local1, ref local2);
      this.FrontArea.ExpandUniquesValuesForSameRegime(4);
      this.enemyDistance = this.Owner.Clone();
      this.enemyDistance.RemoveValuesByMask(this.Owner, 1);
      this.enemyDistance.ExpandAndAddValueForAnyRegime(19);
      this.enemyDistance.SetAllValuesSubtractWith(2);
      this.SetMoveCost();
      this.origEnemyDistance = this.enemyDistance.Clone();
      this.origOwner = this.Owner.Clone();
    }

    pub void Initialize(
      int Iteration,
      int extraAP = 0,
      bool isArt = false,
      int tleft = -1,
      int ttop = -1,
      int tright = -1,
      int tbottom = -1)
    {
      if (tleft > -1)
      {
        this.Left = tleft;
        this.Top = ttop;
        this.Right = tright;
        this.Bottom = tbottom;
        this.Width = this.Right - this.Left;
        this.Height = this.Bottom - this.Top;
      }
      else
        this.SetMatrixDimensions();
      this.Owner = this.ai.SetOwnerMatrix(this.Left, this.Top, this.Width, this.Height);
      this.currentVP = 0;
      int mapWidth = this.ai.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth; index1 += 1)
      {
        int mapHeight = this.ai.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; index2 += 1)
        {
          if (this.ai.game.HandyFunctionsObj.GetRegime(this.ai.map.HexObj[index1, index2].Regime) == this.ai.GetGameDataTurn())
            this.currentVP += this.map.HexObj[index1, index2].VP;
        }
      }
      AITheater aiTheater;
      if (extraAP == 0 & !isArt)
      {
        if (this.front.DefensiveZone > 0)
        {
          DC2AIClass ai = this.ai;
          aiTheater = this;
          ref AITheater local1 = ref aiTheater;
          ref AIMatrix local2 = ref this.Owner;
          int frontId = this.front.FrontID;
          this.FrontArea = ai.SetFrontAreaMatrix(ref local1, ref local2, frontId, true);
        }
        else
        {
          DC2AIClass ai = this.ai;
          aiTheater = this;
          ref AITheater local3 = ref aiTheater;
          ref AIMatrix local4 = ref this.Owner;
          int frontId = this.front.FrontID;
          this.FrontArea = ai.SetFrontAreaMatrix(ref local3, ref local4, frontId, useExtended: true);
        }
      }
      else
      {
        DC2AIClass ai = this.ai;
        aiTheater = this;
        ref AITheater local5 = ref aiTheater;
        ref AIMatrix local6 = ref this.Owner;
        this.FrontArea = ai.SetFrontAreaMatrix2(ref local5, ref local6);
      }
      this.friendlySupplyIdeal = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      this.Setsupplymatrix(ref this.friendlySupplyIdeal, ref this.Owner, 1, true);
      this.friendlySupplyIdeal.SetAllValuesHigherThenXTo(this.ai.VAR_SUPPLY_50PERCENT_RANGE, 9999);
      this.friendlySupplyIdeal.SetAllValuesNotValueXTo(0, 9999);
      this.FriendlySupply = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      this.Setsupplymatrix(ref this.FriendlySupply, ref this.Owner, 1);
      DC2AIClass ai1 = this.ai;
      ref AIMatrix local7 = ref this.allTroops;
      ref AIMatrix local8 = ref this.troopsMove;
      int width1 = this.Width;
      int height1 = this.Height;
      int left1 = this.Left;
      int top1 = this.Top;
      AIFrontList aiFrontList1 = (AIFrontList) null;
      ref AIFrontList local9 = ref aiFrontList1;
      AIMatrix frontArea1 = this.FrontArea;
      int frontId1 = this.front.FrontID;
      ai1.SetTroopsAndAPMatrix(ref local7, ref local8, width1, height1, left1, top1, ref local9, absPower: true, onlyUnitsInCorrectFrontArea: true, tfrontArea: frontArea1, allowFrontIDoutsideCorrectFrontArea: frontId1);
      this.origAllTroops = this.allTroops.Clone();
      this.GetInitialScores();
      this.FrontAreaForAttack = this.FrontArea.Clone();
      this.FrontAreaForAttack.ExpandSpecificValueForAnyRegime(this.front.FrontID, 1);
      this.FrontAreaForAttack.RemoveValuesByMask(this.Owner, 0);
      this.vpMatrix = this.ai.SetAveragedVPMatrix(this.FrontArea, this.front.FrontID);
      this.vpMatrix.Percentify();
      DC2AIClass ai2 = this.ai;
      aiTheater = this;
      ref AITheater local10 = ref aiTheater;
      ref AIMatrix local11 = ref this.FrontArea;
      ref AIMatrix local12 = ref this.Owner;
      this.Advance = ai2.SetAdvanceMatrix(ref local10, ref local11, ref local12);
      this.Advance.Percentify();
      this.origAdvance = this.Advance.Clone();
      this.enemyDistance = this.Owner.Clone();
      this.enemyDistance.RemoveValuesByMask(this.Owner, 1);
      this.enemyDistance.ExpandAndAddValueForAnyRegime(19);
      this.enemyDistance.SetAllValuesSubtractWith(2);
      this.origEnemyDistance = this.enemyDistance.Clone();
      this.origOwner = this.Owner.Clone();
      this.SetMoveCost(extraAP);
      DC2AIClass ai3 = this.ai;
      aiTheater = this;
      ref AITheater local13 = ref aiTheater;
      this.TroopsReach = ai3.SetTroopReach(ref local13);
      this.TroopsReach.Percentify();
      AIMatrix aiMatrix = this.Owner.Clone();
      aiMatrix.RemoveValuesByNotMask(this.Owner, 1);
      aiMatrix.DetectAndMakeEdgeMatrix(false);
      if (this.front.FrontID == 1739)
        ;
      DC2AIClass ai4 = this.ai;
      ref AIMatrix local14 = ref this.troopsstrength;
      ref AIMatrix local15 = ref this.troopsMove;
      int width2 = this.Width;
      int height2 = this.Height;
      int left2 = this.Left;
      int top2 = this.Top;
      AIFrontList aiFrontList2 = (AIFrontList) null;
      ref AIFrontList local16 = ref aiFrontList2;
      int frontId2 = this.front.FrontID;
      AIMatrix frontArea2 = this.FrontArea;
      int frontId3 = this.front.FrontID;
      ai4.SetTroopsAndAPMatrix(ref local14, ref local15, width2, height2, left2, top2, ref local16, frontId2, onlyUnitsInCorrectFrontArea: true, tfrontArea: frontArea2, allowFrontIDoutsideCorrectFrontArea: frontId3);
      this.ai.SetTroopsWithOwnTempPower(ref this.troopsstrength, this.Width, this.Height, this.Left, this.Top, false);
      AIMatrix troops = this.troopsstrength.AverageAndDivideValuesForSameRegime(3, this.Owner, OnlyOwnerX: 2, dividy: 6);
      this.enemyPressureFull = this.ai.SetEnemyPressureFullMatrix(this.Owner, troops, this.FrontAreaForAttack, this.front.FrontID);
      this.enemyPressureFull = this.enemyPressureFull.AverageValuesForAnyRegime(2);
      this.EnemyPressure = (double) this.front.UnitCountRatio >= 0.45 ? ((double) this.front.UnitCountRatio >= 0.8 ? this.ai.SetEnemyPressureMatrix(this.Owner, troops.Clone().AverageValuesForSameRegime(2, this.Owner, OnlyOwnerX: 2), this.FrontAreaForAttack, this.front.FrontID) : this.ai.SetEnemyPressureMatrix(this.Owner, troops.Clone().AverageValuesForSameRegime(1, this.Owner, OnlyOwnerX: 2), this.FrontAreaForAttack, this.front.FrontID)) : this.ai.SetEnemyPressureMatrix(this.Owner, troops.Clone().AverageValuesForSameRegime(0, this.Owner, OnlyOwnerX: 2), this.FrontAreaForAttack, this.front.FrontID);
      this.ForceRatio = this.ai.SetRatioInPercentage(ref this.troopsstrength, ref this.EnemyPressure, this.FrontAreaForAttack, this.front.FrontID);
      this.ForceRatio.SetValueXToValueY(999, 0);
      this.ForceRatio.ExpandAndAddValueForSameOwner(998, ref this.Owner);
      this.EnemyPressure = this.EnemyPressure.AverageAndDivideValuesForSameRegime(5, this.Owner, OnlyOwnerX: 1, dividy: 200);
      this.EnemyPressure = this.EnemyPressure.AverageAndDivideValuesForSameRegime(2, this.Owner, OnlyOwnerX: 1, dividy: 50);
      this.ForceRatio.RemoveValuesByNotMask(this.Owner, 1);
      this.enemySupply = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      this.Setsupplymatrix(ref this.enemySupply, ref this.Owner, 2);
      this.EnemyBottleneck = this.ai.SetEnemyBottleNeckMatrix(this.front, this.FrontArea, this.enemySupply, this.Owner, false, 2);
      this.EnemyBottleneckOwnFrontOnly = this.ai.SetEnemyBottleNeckMatrix(this.front, this.FrontArea, this.enemySupply, this.Owner, true, 1);
      this.FriendlySupply = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      this.Setsupplymatrix(ref this.FriendlySupply, ref this.Owner, 1);
      this.FriendlyBottleneck = this.ai.SetFriendlyBottleNeckMatrix(this.front, this.FriendlySupply, this.Owner, false, 2);
      AIMatrix tSupply = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      if (this.front.FrontType == 12)
        this.SetsupplymatrixIdeal(ref tSupply, ref this.Owner, 1, ref this.enemySupply, ref this.troopsstrength, true);
      else
        this.SetsupplymatrixIdeal(ref tSupply, ref this.Owner, 1, ref this.enemySupply, ref this.troopsstrength);
      this.FriendlyBottleneckIdeal = this.ai.SetFriendlyBottleNeckMatrix(this.front, tSupply, this.Owner, false, 1);
      this.FriendlyBottleneckIdealOwnFrontOnly = this.front.FrontType != 12 ? this.ai.SetFriendlyBottleNeckMatrix(this.front, tSupply, this.Owner, true, 0) : this.ai.SetFriendlyBottleNeckMatrix(this.front, tSupply, this.Owner, true, 2);
      this.getInitialScores2();
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int num5 = 0;
      int width3 = this.Width;
      for (int tx = 0; tx <= width3; tx += 1)
      {
        int height3 = this.Height;
        for (int index = 0; index <= height3; index += 1)
        {
          if (this.ai.game.HandyFunctionsObj.GetRegime(this.ai.map.HexObj[this.GetRealX(tx), index + this.Top].Regime) == this.ai.GetGameDataTurn() && this.FrontArea.Value[tx, index] == this.front.FrontID & this.ai.frontMatrix.Value[this.GetRealX(tx), index + this.Top] == this.front.FrontID)
          {
            num1 += 1;
            num2 += this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(tx), index + this.Top];
            if (this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(tx), index + this.Top] <= 75)
              num5 += 1;
            if (this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(tx), index + this.Top] <= 50)
              num4 += 1;
            if (this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(tx), index + this.Top] <= 25)
              num3 += 1;
          }
        }
      }
      if (num1 > 0)
      {
        this.LowestRetreatModifierAllowed = 100;
        int num6 = (int) Math.Round((double) num1 / (double) this.ai.VAR_FRONTLINE_DEPTH);
        if (num5 + num4 + num3 >= num6)
          this.LowestRetreatModifierAllowed = 75;
        int num7 = (int) Math.Round((double) num1 / ((double) this.ai.VAR_FRONTLINE_DEPTH * 1.5));
        if (num4 + num3 >= num7)
          this.LowestRetreatModifierAllowed = 50;
        int num8 = (int) Math.Round((double) num1 / (double) (this.ai.VAR_FRONTLINE_DEPTH * 2));
        if (num3 >= num8)
          this.LowestRetreatModifierAllowed = 25;
      }
      else
        this.LowestRetreatModifierAllowed = 25;
      this.Score = 50;
    }

    pub void getInitialScores2()
    {
      this.InitHexes = this.GetInitialFrontAreaHexes(ref this.allTroops, ref this.Owner, 1);
      this.initHexesTot = this.GetInitialHexes(ref this.allTroops, ref this.Owner, 1);
      this.initEncRatio3 = this.GetTroopsRatioOutOfSupply(ref this.enemySupply, ref this.troopsstrength, ref this.Owner, 2);
      this.initEncRatio4 = this.GetTroopsFrontRatioOutOfSupply(ref this.enemySupply, ref this.troopsstrength, ref this.Owner, 2);
    }

    pub void GetInitialScores()
    {
      this.FriendlySupplyAfterEnemyMove = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      this.initEncRatio5 = this.GetTroopsRatioOutOfSupply(ref this.FriendlySupply, ref this.allTroops, ref this.Owner, 1);
      this.initEncRatio6 = this.GetTroopsFrontRatioOutOfSupply(ref this.FriendlySupply, ref this.allTroops, ref this.Owner, 1);
      AIMatrix tOwner = this.Owner.Clone();
      AIMatrix tTroops = this.allTroops.Clone();
      this.InitTotalTroops = this.GetInitialTotalTroops(ref tTroops, ref tOwner, 1);
      this.initFrontTroops = this.GetInitialFrontTroops(ref tTroops, ref tOwner, 1);
      this.Setsupplymatrix(ref this.FriendlySupplyAfterEnemyMove, ref tOwner, 1);
      this.initEncRatio1 = this.GetTroopsRatioOutOfSupply(ref this.FriendlySupplyAfterEnemyMove, ref tTroops, ref tOwner, 1);
      this.initEncRatio2 = this.GetTroopsFrontRatioOutOfSupply(ref this.FriendlySupplyAfterEnemyMove, ref tTroops, ref tOwner, 1);
      this.initOrigEnemyUnits = 0;
      int width = this.Width;
      for (int tx = 0; tx <= width; tx += 1)
      {
        int height = this.Height;
        for (int index = 0; index <= height; index += 1)
        {
          if (this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(tx), this.Top + index].UnitCounter > -1 && this.FrontArea.Value[tx, index] == this.front.FrontID & this.Owner.Value[tx, index] == 2)
            this.initOrigEnemyUnits += this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(tx), this.Top + index].UnitCounter + 1;
        }
      }
    }

    pub int GetInitialTotalTroops(ref AIMatrix tTroops, ref AIMatrix tOwner, int USEOWNER)
    {
      int width = tTroops.Width;
      int initialTotalTroops;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = tTroops.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (tOwner.Value[index1, index2] == USEOWNER)
          {
            int num = tTroops.Value[index1, index2];
            initialTotalTroops += num;
          }
        }
      }
      return initialTotalTroops;
    }

    pub int GetInitialFrontTroops(ref AIMatrix tTroops, ref AIMatrix tOwner, int USEOWNER)
    {
      int width = tTroops.Width;
      int initialFrontTroops;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = tTroops.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (tOwner.Value[index1, index2] == USEOWNER && this.FrontArea.Value[index1, index2] == this.front.FrontID)
          {
            int num = tTroops.Value[index1, index2];
            initialFrontTroops += num;
          }
        }
      }
      return initialFrontTroops;
    }

    pub int GetInitialFrontAreaHexes(ref AIMatrix tTroops, ref AIMatrix tOwner, int USEOWNER)
    {
      int width = tTroops.Width;
      int initialFrontAreaHexes;
      for (int tx = 0; tx <= width; tx += 1)
      {
        int height = tTroops.Height;
        for (int index = 0; index <= height; index += 1)
        {
          if (tOwner.Value[tx, index] == USEOWNER)
          {
            int num1 = this.ai.map.HexObj[this.GetRealX(tx), index + this.Top].VP + this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].AIVP[0].Value[this.GetRealX(tx), index + this.Top];
            if (this.friendlySupplyIdeal.Value[tx, index] < this.ai.VAR_SUPPLY_75PERCENT_RANGE)
            {
              if (this.FrontArea.Value[tx, index] == this.front.FrontID)
              {
                int num2 = 1;
                if (this.ai.frontMatrix.Value[this.GetRealX(tx), index + this.Top] == this.front.FrontID | this.ai.game.HandyFunctionsObj.GetRegime(this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(tx), index + this.Top].Regime) != this.ai.game.HandyFunctionsObj.GetRegime(this.ai.game.Data.Turn) & this.ai.frontlinesMatrix.Value[this.GetRealX(tx), index + this.Top] == 0)
                {
                  if (num1 > 0)
                    num2 += 12;
                  if (num1 > 0)
                    num2 += 4 * num1;
                }
                else
                {
                  if (num1 > 0)
                    num2 += 4;
                  if (num1 > 0)
                    num2 += 2 * num1;
                }
                if (!this.front.RealRetreat & num2 > 0 & this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(tx), index + this.Top] > 0 & this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(tx), index + this.Top] < 100)
                  num2 = (int) Math.Round((double) num2 * (100.0 / (double) this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(tx), index + this.Top]));
                if (this.ai.game.HandyFunctionsObj.HasHexRoad(this.GetRealX(tx + this.Left), index + this.Top, 0))
                {
                  if (this.FriendlyBottleneckIdealOwnFrontOnly.Value[tx, index] > 10)
                    num2 = (int) Math.Round((double) (num2 * this.FriendlyBottleneckIdealOwnFrontOnly.Value[tx, index]) / 10.0);
                  if (this.EnemyBottleneckOwnFrontOnly.Value[tx, index] > 10)
                    num2 = (int) Math.Round((double) (num2 * this.EnemyBottleneckOwnFrontOnly.Value[tx, index]) / 10.0);
                }
                initialFrontAreaHexes += num2;
              }
              else
              {
                if (num1 > 0)
                  initialFrontAreaHexes += 2;
                if (num1 > 0)
                  initialFrontAreaHexes += 1 * num1;
              }
            }
            else if (this.FrontArea.Value[tx, index] == this.front.FrontID && this.ai.frontMatrix.Value[this.GetRealX(tx), index + this.Top] == this.front.FrontID | this.ai.game.HandyFunctionsObj.GetRegime(this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(tx), index + this.Top].Regime) != this.ai.game.HandyFunctionsObj.GetRegime(this.ai.game.Data.Turn) & this.ai.frontlinesMatrix.Value[this.GetRealX(tx), index + this.Top] == 0)
            {
              int num3 = 0;
              if (num1 > 0)
                num3 += 2;
              if (num1 > 0)
                num3 += 4 * num1;
              initialFrontAreaHexes += num3;
            }
          }
        }
      }
      return initialFrontAreaHexes;
    }

    pub int GetInitialHexes(ref AIMatrix tTroops, ref AIMatrix tOwner, int USEOWNER)
    {
      int width = tTroops.Width;
      int initialHexes;
      for (int tx = 0; tx <= width; tx += 1)
      {
        int height = tTroops.Height;
        for (int index = 0; index <= height; index += 1)
        {
          int num1 = this.ai.map.HexObj[this.GetRealX(tx), index + this.Top].VP + this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].AIVP[0].Value[this.GetRealX(tx), index + this.Top];
          if (tOwner.Value[tx, index] == USEOWNER & this.friendlySupplyIdeal.Value[tx, index] < this.ai.VAR_SUPPLY_75PERCENT_RANGE)
          {
            int num2 = num1;
            if (num2 > 0)
              num2 = 6 + num2 * 4;
            int num3 = num2 + 1;
            if (num3 > 0 & !this.front.RealRetreat & this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(tx), index + this.Top] > 0 & this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(tx), index + this.Top] < 100)
              num3 = (int) Math.Round((double) num3 * (100.0 / (double) this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(tx), index + this.Top]));
            if (this.ai.game.HandyFunctionsObj.HasHexRoad(this.GetRealX(tx + this.Left), index + this.Top, 0))
            {
              if (this.FriendlyBottleneckIdeal.Value[tx, index] > 10)
                num3 = (int) Math.Round((double) (num3 * this.FriendlyBottleneckIdeal.Value[tx, index]) / 10.0);
              if (this.FriendlyBottleneck.Value[tx, index] > 10)
                num3 = (int) Math.Round((double) (num3 * this.FriendlyBottleneck.Value[tx, index]) / 10.0);
              if (this.EnemyBottleneck.Value[tx, index] > 10)
                num3 = (int) Math.Round((double) (num3 * this.EnemyBottleneck.Value[tx, index]) / 10.0);
            }
            initialHexes += num3;
          }
          else if (tOwner.Value[tx, index] == USEOWNER)
          {
            int num4 = num1;
            if (num4 > 0)
              num4 *= 2;
            initialHexes += num4;
          }
        }
      }
      return initialHexes;
    }

    pub float GetTroopsRatioOutOfSupply(
      ref AIMatrix tSupply,
      ref AIMatrix tTroops,
      ref AIMatrix tOwner,
      int USEOWNER)
    {
      int width = tSupply.Width;
      int num1;
      int num2;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = tSupply.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (tOwner.Value[index1, index2] == USEOWNER)
          {
            int num3 = tTroops.Value[index1, index2];
            num1 += num3;
            if (tSupply.Value[index1, index2] > this.ai.VAR_SUPPLY_MAXIMUM_RANGE)
              num2 += num3;
          }
        }
      }
      return num1 <= 0 ? 0.0f : (float) num2 / (float) num1;
    }

    pub float GetTroopsFrontRatioOutOfSupply(
      ref AIMatrix tSupply,
      ref AIMatrix tTroops,
      ref AIMatrix tOwner,
      int USEOWNER)
    {
      int width = tSupply.Width;
      int num1;
      int num2;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = tSupply.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (tOwner.Value[index1, index2] == USEOWNER)
          {
            if (USEOWNER == 1)
            {
              if (this.FrontArea.Value[index1, index2] == this.front.FrontID)
              {
                int num3 = tTroops.Value[index1, index2];
                num1 += num3;
                if (tSupply.Value[index1, index2] > this.ai.VAR_SUPPLY_MAXIMUM_RANGE)
                  num2 += num3;
              }
            }
            else if (this.FrontAreaForAttack.Value[index1, index2] == this.front.FrontID)
            {
              int num4 = tTroops.Value[index1, index2];
              num1 += num4;
              if (tSupply.Value[index1, index2] > this.ai.VAR_SUPPLY_MAXIMUM_RANGE)
                num2 += num4;
            }
          }
        }
      }
      return num1 <= 0 ? 0.0f : (float) num2 / (float) num1;
    }

    pub void Setsupplymatrix(
      ref AIMatrix tSupply,
      ref AIMatrix tOwner,
      int USEOWNER,
      bool enterEnemy = false)
    {
      tSupply.SetAllValuesTo(9999);
      int num1 = -999;
      int index1 = -1;
      int width1 = this.Width;
      int index2;
      int index3;
      bool flag;
      int index4;
      for (int tx = 0; tx <= width1; tx += 1)
      {
        int height = this.Height;
        for (int index5 = 0; index5 <= height; index5 += 1)
        {
          if (tOwner.Value[tx, index5] == USEOWNER)
          {
            if (USEOWNER == 1)
            {
              if (this.ai.friendlySupplyMatrix.Value[this.GetRealX(tx), this.Top + index5] == 0 & num1 < this.ai.map.HexObj[this.GetRealX(tx), index5 + this.Top].VP)
              {
                index2 = tx;
                index3 = index5;
                flag = true;
                num1 = this.ai.map.HexObj[this.GetRealX(tx), index5 + this.Top].VP;
              }
              if (this.ai.map.HexObj[this.GetRealX(tx), index5 + this.Top].VP >= 10 && this.ai.CustomCalls.CustomRuleHQtoFrontAssign_AllowHQGroupsWithoutHQ(-1) & num1 < this.ai.map.HexObj[this.GetRealX(tx), index5 + this.Top].VP)
              {
                index2 = tx;
                index3 = index5;
                flag = true;
                num1 = this.ai.map.HexObj[this.GetRealX(tx), index5 + this.Top].VP;
              }
            }
            else if (this.ai.enemySupplyMatrix.Value[this.GetRealX(tx), this.Top + index5] == 0 & num1 < this.ai.map.HexObj[this.GetRealX(tx), index5 + this.Top].VP)
            {
              index2 = tx;
              index3 = index5;
              flag = true;
              num1 = this.ai.map.HexObj[this.GetRealX(tx), index5 + this.Top].VP;
            }
            int vp;
            if (this.front.FrontType == 11 && this.ai.map.HexObj[this.GetRealX(tx), index5 + this.Top].VP > vp)
            {
              vp = this.ai.map.HexObj[this.GetRealX(tx), index5 + this.Top].VP;
              index1 = tx;
              index4 = index5;
            }
          }
        }
      }
      tSupply.SetAllValuesTo(9999);
      if (index1 > -1 & USEOWNER == 1)
        tSupply.Value[index1, index4] = 0;
      int width2 = this.Width;
      for (int tx = 0; tx <= width2; tx += 1)
      {
        int height = this.Height;
        for (int index6 = 0; index6 <= height; index6 += 1)
        {
          if (tx == 0 | index6 == 0 | tx == this.Width | index6 == this.Height && tOwner.Value[tx, index6] == USEOWNER)
            tSupply.Value[tx, index6] = USEOWNER != 1 ? this.ai.enemySupplyMatrix.Value[this.GetRealX(tx), this.Top + index6] : this.ai.friendlySupplyMatrix.Value[this.GetRealX(tx), this.Top + index6];
        }
      }
      int width3 = this.Width;
      for (int index7 = 0; index7 <= width3; index7 += 1)
      {
        int height = this.Height;
        int num2;
        for (int index8 = 0; index8 <= height; index8 += 1)
        {
          if (index7 == 0 | index8 == 0 | index7 == this.Width | index8 == this.Height && tSupply.Value[index7, index8] < 9999)
          {
            if (USEOWNER == 1)
            {
              if (this.ai.friendlySupplyMatrixCameFrom.Value[index7, index8].onmap)
              {
                int matrixX = this.GetMatrixX(this.ai.friendlySupplyMatrixCameFrom.Value[index7, index8].x);
                int y = this.ai.friendlySupplyMatrixCameFrom.Value[index7, index8].y;
                if (matrixX < 0 | y < this.Top | matrixX > this.Width | y > this.Top + this.Height)
                  num2 = matrixX;
                else
                  tSupply.Value[index7, index8] = 9999;
              }
            }
            else if (this.ai.enemySupplyMatrixCameFrom.Value[index7, index8].onmap)
            {
              int matrixX = this.GetMatrixX(this.ai.enemySupplyMatrixCameFrom.Value[index7, index8].x);
              int y = this.ai.enemySupplyMatrixCameFrom.Value[index7, index8].y;
              if (matrixX < 0 | y < this.Top | matrixX > this.Width | y > this.Top + this.Height)
                num2 = matrixX;
              else
                tSupply.Value[index7, index8] = 9999;
            }
          }
        }
      }
      if (flag)
        tSupply.Value[index2, index3] = 0;
      if (enterEnemy)
      {
        if (USEOWNER == 1)
          tSupply.ExpandAsSimplifiedSupplyRouteMatrix_SuperSpeed(this.ai.VAR_SUPPLY_FRIENDLY_MOVETYPE, ref tOwner, 1, true, useRoads: false);
        else
          tSupply.ExpandAsSimplifiedSupplyRouteMatrix_SuperSpeed(this.ai.VAR_SUPPLY_ENEMY_MOVETYPE, ref tOwner, 2, true, useRoads: false);
      }
      else if (USEOWNER == 1)
        tSupply.ExpandAsSimplifiedSupplyRouteMatrix_SuperSpeed(this.ai.VAR_SUPPLY_FRIENDLY_MOVETYPE, ref tOwner, 1);
      else
        tSupply.ExpandAsSimplifiedSupplyRouteMatrix_SuperSpeed(this.ai.VAR_SUPPLY_ENEMY_MOVETYPE, ref tOwner, 2);
    }

    pub void SetsupplymatrixIdeal(
      ref AIMatrix tSupply,
      ref AIMatrix tOwner,
      int USEOWNER,
      ref AIMatrix tenemysupply,
      ref AIMatrix ttroops,
      bool blockSea = false)
    {
      tSupply.SetAllValuesTo(9999);
      int width1 = this.Width;
      for (int tx = 0; tx <= width1; tx += 1)
      {
        int height = this.Height;
        for (int index = 0; index <= height; index += 1)
        {
          if (this.ai.friendlySupplyMatrix.Value[this.GetRealX(tx), this.Top + index] == 0 && tOwner.Value[tx, index] == USEOWNER)
            tSupply.Value[tx, index] = this.ai.friendlySupplyMatrix.Value[this.GetRealX(tx), this.Top + index];
          if (tx == 0 | index == 0 | tx == this.Width | index == this.Height && tOwner.Value[tx, index] == USEOWNER)
            tSupply.Value[tx, index] = this.ai.friendlySupplyMatrix.Value[this.GetRealX(tx), this.Top + index];
        }
      }
      tSupply.ExpandAsSupplyIdealRouteMatrix(this.ai.VAR_SUPPLY_FRIENDLY_MOVETYPE, this.ai.VAR_SUPPLY_ENEMY_MOVETYPE, ref tOwner, 1, tenemysupply, ttroops, blockSea);
      if (!blockSea)
        return;
      int width2 = this.Width;
      for (int index1 = 0; index1 <= width2; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (tOwner.Value[index1, index2] == 0)
            tSupply.Value[index1, index2] = 9999;
        }
      }
    }

    pub void GetEnemyMove(
      float RatioNeeded,
      bool DiminishForMultipleTarget,
      ref AIMatrix tOwner,
      ref AIMatrix tTroops,
      int RANGE,
      bool onlyOverRoad,
      bool notAdjustedForEnemyMoveMatrix = false)
    {
      int[,] numArray1 = new int[this.Width + 1, this.Height + 1];
      int width1 = this.Width;
      for (int index1 = 0; index1 <= width1; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (tOwner.Value[index1, index2] == 1 && this.enemyDistance.Value[index1, index2] == 1)
          {
            int num1 = 0;
            float num2 = 1f;
            int num3 = 0;
            if (DiminishForMultipleTarget)
            {
              int num4 = index1 - (RANGE + 0);
              int num5 = index1 + (RANGE + 0);
              for (int x2 = num4; x2 <= num5; x2 += 1)
              {
                int num6 = index2 - (RANGE + 0);
                int num7 = index2 + (RANGE + 0);
                for (int y2 = num6; y2 <= num7; y2 += 1)
                {
                  if (x2 <= this.Width & x2 >= 0 && y2 <= this.Height & y2 >= 0 && tTroops.Value[x2, y2] > 0)
                  {
                    int num8 = this.ai.game.HandyFunctionsObj.Distance(index1, index2, 0, x2, y2, 0, RANGE);
                    if (num8 <= RANGE)
                    {
                      if (tOwner.Value[x2, y2] == 2)
                        num3 += (int) Math.Round((double) tTroops.Value[x2, y2] * ((double) (RANGE + 1 - num8) / (double) RANGE));
                      else if (tOwner.Value[x2, y2] == 1)
                      {
                        if (num8 == 0)
                          num1 += (int) Math.Round((double) tTroops.Value[x2, y2] * ((double) (RANGE + 1 - num8) / (double) RANGE));
                        else
                          num1 += (int) Math.Round((double) tTroops.Value[x2, y2] * ((double) (RANGE + 1 - num8) / (double) (RANGE * 4)));
                      }
                    }
                  }
                }
              }
              if (num1 > 0)
              {
                num2 = (float) num3 / (float) num1;
                if ((double) num2 > 1.0)
                  num2 = 1f;
                if ((double) num2 < 0.3)
                  num2 = 0.3f;
              }
            }
            if (num3 > 0 | !DiminishForMultipleTarget)
            {
              int num9 = index1 - (RANGE + 0);
              int num10 = index1 + (RANGE + 0);
              for (int index3 = num9; index3 <= num10; index3 += 1)
              {
                int num11 = index2 - (RANGE + 0);
                int num12 = index2 + (RANGE + 0);
                for (int index4 = num11; index4 <= num12; index4 += 1)
                {
                  if (index3 <= this.Width & index3 >= 0 && index4 <= this.Height & index4 >= 0 && tOwner.Value[index3, index4] == 2)
                  {
                    int num13 = this.ai.game.HandyFunctionsObj.Distance(index1, index2, 0, index3, index4, 0, RANGE);
                    if (num13 <= RANGE && this.ai.game.HandyFunctionsObj.HexFacing(index1, index2, 0, index3, index4, 0) - 1 > -1)
                    {
                      int num14 = (int) Math.Round((double) ((float) (int) Math.Round((double) tTroops.Value[index3, index4] * ((double) (RANGE + 1 - num13) / (double) RANGE)) * num2));
                      int[,] numArray2 = numArray1;
                      int[,] numArray3 = numArray2;
                      int index5 = index1;
                      int index6 = index5;
                      int index7 = index2;
                      int index8 = index7;
                      int num15 = numArray2[index5, index7] + num14;
                      numArray3[index6, index8] = num15;
                    }
                  }
                }
              }
            }
          }
        }
      }
      int width2 = this.Width;
      for (int index9 = 0; index9 <= width2; index9 += 1)
      {
        int height = this.Height;
        for (int index10 = 0; index10 <= height; index10 += 1)
        {
          if (tOwner.Value[index9, index10] == 1 & numArray1[index9, index10] > 0)
          {
            float num16 = RatioNeeded;
            bool flag1 = false;
            Coordinate coordinate1;
            if (this.ai.VAR_EMPHASIS_AGAINST_CONCENTRIC)
            {
              Neighbours neighbours = Neighbours::new();
              int index11 = 0;
              do
              {
                coordinate1 = this.ai.TempHexNeighbour[index9, index10, index11];
                if (coordinate1.onmap & coordinate1.x <= this.Width & coordinate1.y <= this.Height && tOwner.Value[coordinate1.x, coordinate1.y] == 2)
                {
                  neighbours.data[index11] = 1;
                  if (this.ai.game.Data.MapObj[0].HexObj[index9, index10].RoadType[index11] > -1)
                    flag1 = true;
                }
                index11 += 1;
              }
              while (index11 <= 5);
              HandyFunctionsclass handyFunctionsObj = this.ai.game.HandyFunctionsObj;
              ref Neighbours local1 = ref neighbours;
              bool flag2 = false;
              ref bool local2 = ref flag2;
              float num17 = handyFunctionsObj.GetConcentricBonus(ref local1, ref local2, false);
              if ((double) num17 > 1.0)
              {
                if ((double) num17 >= 1.5)
                  num17 = num17;
                num16 /= num17;
              }
            }
            int num18 = tTroops.Value[index9, index10];
            if (this.allTroops.Value[index9, index10] > (int) Math.Round((double) (this.ai.game.Data.RuleVar[476] * 3f)))
              num18 += (int) Math.Round((double) this.ai.game.Data.RuleVar[476] * 2.2);
            else if (this.allTroops.Value[index9, index10] > (int) Math.Round((double) (this.ai.game.Data.RuleVar[476] * 2f)))
              num18 += (int) Math.Round((double) (this.ai.game.Data.RuleVar[476] * 2f));
            else if (this.allTroops.Value[index9, index10] > (int) Math.Round((double) (this.ai.game.Data.RuleVar[476] * 1f)))
              num18 += (int) Math.Round((double) this.ai.game.Data.RuleVar[476] * 1.66);
            else if (this.allTroops.Value[index9, index10] > (int) Math.Round((double) this.ai.game.Data.RuleVar[476] * 0.5))
              num18 += (int) Math.Round((double) this.ai.game.Data.RuleVar[476]);
            if (numArray1[index9, index10] > (int) Math.Round((double) (num16 * (float) num18)) & (!onlyOverRoad | flag1))
            {
              int num19 = 0;
              int num20 = 0;
              int index12 = 0;
              Coordinate coordinate2;
              do
              {
                coordinate1 = this.ai.TempHexNeighbour[index9, index10, index12];
                if (coordinate1.onmap & coordinate1.x <= this.Width & coordinate1.y <= this.Height)
                {
                  if (tOwner.Value[coordinate1.x, coordinate1.y] == 1)
                    this.enemyDistance.Value[coordinate1.x, coordinate1.y] = 1;
                  else if (tOwner.Value[coordinate1.x, coordinate1.y] == 2 & tTroops.Value[coordinate1.x, coordinate1.y] > 0)
                  {
                    num19 += tTroops.Value[coordinate1.x, coordinate1.y];
                    num20 += 1;
                  }
                  int index13 = 0;
                  do
                  {
                    coordinate2 = this.ai.TempHexNeighbour[coordinate1.x, coordinate1.y, index13];
                    if (coordinate2.onmap & coordinate2.x <= this.Width & coordinate2.y <= this.Height && tOwner.Value[coordinate2.x, coordinate2.y] == 2 & tTroops.Value[coordinate2.x, coordinate2.y] > 0)
                    {
                      num19 += tTroops.Value[coordinate2.x, coordinate2.y];
                      num20 += 1;
                    }
                    index13 += 1;
                  }
                  while (index13 <= 5);
                }
                index12 += 1;
              }
              while (index12 <= 5);
              float num21 = (float) numArray1[index9, index10] / (float) num19;
              if ((double) num21 > 1.0)
                num21 = 1f;
              float num22 = 1f - num21;
              tOwner.Value[index9, index10] = 2;
              tTroops.Value[index9, index10] = (int) Math.Round((double) numArray1[index9, index10] / 2.0);
              int index14 = 0;
              do
              {
                coordinate1 = this.ai.TempHexNeighbour[index9, index10, index14];
                if (coordinate1.onmap & coordinate1.x <= this.Width & coordinate1.y <= this.Height)
                {
                  if (tOwner.Value[coordinate1.x, coordinate1.y] == 2 & tTroops.Value[coordinate1.x, coordinate1.y] > 0 & !(coordinate1.x == index9 & coordinate1.y == index10))
                    tTroops.Value[coordinate1.x, coordinate1.y] = (int) Math.Round((double) ((float) tTroops.Value[coordinate1.x, coordinate1.y] * num22));
                  int index15 = 0;
                  do
                  {
                    coordinate2 = this.ai.TempHexNeighbour[coordinate1.x, coordinate1.y, index15];
                    if (coordinate2.onmap & coordinate2.x <= this.Width & coordinate2.y <= this.Height && tOwner.Value[coordinate2.x, coordinate2.y] == 2 & tTroops.Value[coordinate2.x, coordinate2.y] > 0 & !(coordinate2.x == index9 & coordinate2.y == index10))
                      tTroops.Value[coordinate2.x, coordinate2.y] = (int) Math.Round((double) ((float) tTroops.Value[coordinate2.x, coordinate2.y] * num22));
                    index15 += 1;
                  }
                  while (index15 <= 5);
                }
                index14 += 1;
              }
              while (index14 <= 5);
            }
          }
        }
      }
    }

    pub void BACKUP_GetEnemyMove(
      float RatioNeeded,
      bool DiminishForMultipleTarget,
      ref AIMatrix tOwner,
      ref AIMatrix tTroops,
      int RANGE,
      bool onlyOverRoad)
    {
      int[,] numArray1 = new int[this.Width + 1, this.Height + 1];
      int width1 = this.Width;
      for (int x1 = 0; x1 <= width1; x1 += 1)
      {
        int height = this.Height;
        for (int y1 = 0; y1 <= height; y1 += 1)
        {
          if (tOwner.Value[x1, y1] == 1 && this.enemyDistance.Value[x1, y1] == 1)
          {
            int num1 = 0;
            float num2 = 1f;
            int num3 = 0;
            if (DiminishForMultipleTarget)
            {
              int num4 = x1 - (RANGE + 0);
              int num5 = x1 + (RANGE + 0);
              for (int x2 = num4; x2 <= num5; x2 += 1)
              {
                int num6 = y1 - (RANGE + 0);
                int num7 = y1 + (RANGE + 0);
                for (int y2 = num6; y2 <= num7; y2 += 1)
                {
                  if (x2 <= this.Width & x2 >= 0 && y2 <= this.Height & y2 >= 0 && tTroops.Value[x2, y2] > 0)
                  {
                    int num8 = this.ai.game.HandyFunctionsObj.Distance(x1, y1, 0, x2, y2, 0, RANGE);
                    if (num8 <= RANGE)
                    {
                      if (tOwner.Value[x2, y2] == 2)
                        num3 += (int) Math.Round((double) tTroops.Value[x2, y2] * ((double) (RANGE + 1 - num8) / (double) RANGE));
                      else if (tOwner.Value[x2, y2] == 1)
                        num1 += (int) Math.Round((double) tTroops.Value[x2, y2] * ((double) (RANGE + 1 - num8) / (double) RANGE));
                    }
                  }
                }
              }
              if (num1 > 0)
              {
                num2 = (float) num3 / (float) num1;
                if ((double) num2 > 1.0)
                  num2 = 1f;
                if ((double) num2 < 0.3)
                  num2 = 0.3f;
              }
            }
            if (num3 > 0 | !DiminishForMultipleTarget)
            {
              int num9 = x1 - (RANGE + 0);
              int num10 = x1 + (RANGE + 0);
              for (int x2 = num9; x2 <= num10; x2 += 1)
              {
                int num11 = y1 - (RANGE + 0);
                int num12 = y1 + (RANGE + 0);
                for (int y2 = num11; y2 <= num12; y2 += 1)
                {
                  if (x2 <= this.Width & x2 >= 0 && y2 <= this.Height & y2 >= 0 && tOwner.Value[x2, y2] == 2)
                  {
                    int num13 = this.ai.game.HandyFunctionsObj.Distance(x1, y1, 0, x2, y2, 0, RANGE);
                    if (num13 <= RANGE)
                    {
                      int num14 = (int) Math.Round((double) ((float) (int) Math.Round((double) tTroops.Value[x2, y2] * ((double) (RANGE + 1 - num13) / (double) RANGE)) * num2));
                      int[,] numArray2 = numArray1;
                      int[,] numArray3 = numArray2;
                      int index1 = x1;
                      int index2 = index1;
                      int index3 = y1;
                      int index4 = index3;
                      int num15 = numArray2[index1, index3] + num14;
                      numArray3[index2, index4] = num15;
                    }
                  }
                }
              }
            }
          }
        }
      }
      int width2 = this.Width;
      for (int index5 = 0; index5 <= width2; index5 += 1)
      {
        int height = this.Height;
        for (int index6 = 0; index6 <= height; index6 += 1)
        {
          if (tOwner.Value[index5, index6] == 1 & numArray1[index5, index6] > 0)
          {
            float num16 = RatioNeeded;
            bool flag1 = false;
            Coordinate coordinate1;
            if (this.ai.VAR_EMPHASIS_AGAINST_CONCENTRIC)
            {
              Neighbours neighbours = Neighbours::new();
              int index7 = 0;
              do
              {
                coordinate1 = this.ai.TempHexNeighbour[index5, index6, index7];
                if (coordinate1.onmap & coordinate1.x <= this.Width & coordinate1.y <= this.Height && tOwner.Value[coordinate1.x, coordinate1.y] == 2)
                {
                  neighbours.data[index7] = 1;
                  if (this.ai.game.Data.MapObj[0].HexObj[index5, index6].RoadType[index7] > -1)
                    flag1 = true;
                }
                index7 += 1;
              }
              while (index7 <= 5);
              HandyFunctionsclass handyFunctionsObj = this.ai.game.HandyFunctionsObj;
              ref Neighbours local1 = ref neighbours;
              bool flag2 = false;
              ref bool local2 = ref flag2;
              float num17 = handyFunctionsObj.GetConcentricBonus(ref local1, ref local2, false);
              if ((double) num17 > 1.0)
              {
                if ((double) num17 >= 1.5)
                  num17 = num17;
                num16 /= num17;
              }
            }
            if (numArray1[index5, index6] > (int) Math.Round((double) (num16 * (float) tTroops.Value[index5, index6])) & (!onlyOverRoad | flag1))
            {
              int num18 = 0;
              int num19 = 0;
              int index8 = 0;
              Coordinate coordinate2;
              do
              {
                coordinate1 = this.ai.TempHexNeighbour[index5, index6, index8];
                if (coordinate1.onmap & coordinate1.x <= this.Width & coordinate1.y <= this.Height)
                {
                  if (tOwner.Value[coordinate1.x, coordinate1.y] == 1)
                    this.enemyDistance.Value[coordinate1.x, coordinate1.y] = 1;
                  else if (tOwner.Value[coordinate1.x, coordinate1.y] == 2 & tTroops.Value[coordinate1.x, coordinate1.y] > 0)
                  {
                    num18 += tTroops.Value[coordinate1.x, coordinate1.y];
                    num19 += 1;
                  }
                  int index9 = 0;
                  do
                  {
                    coordinate2 = this.ai.TempHexNeighbour[coordinate1.x, coordinate1.y, index9];
                    if (coordinate2.onmap & coordinate2.x <= this.Width & coordinate2.y <= this.Height && tOwner.Value[coordinate2.x, coordinate2.y] == 2 & tTroops.Value[coordinate2.x, coordinate2.y] > 0)
                    {
                      num18 += tTroops.Value[coordinate2.x, coordinate2.y];
                      num19 += 1;
                    }
                    index9 += 1;
                  }
                  while (index9 <= 5);
                }
                index8 += 1;
              }
              while (index8 <= 5);
              float num20 = (float) numArray1[index5, index6] / (float) num18;
              if ((double) num20 > 1.0)
                num20 = 1f;
              float num21 = 1f - num20;
              tOwner.Value[index5, index6] = 2;
              tTroops.Value[index5, index6] = (int) Math.Round((double) numArray1[index5, index6] / 2.0);
              int index10 = 0;
              do
              {
                coordinate1 = this.ai.TempHexNeighbour[index5, index6, index10];
                if (coordinate1.onmap & coordinate1.x <= this.Width & coordinate1.y <= this.Height)
                {
                  if (tOwner.Value[coordinate1.x, coordinate1.y] == 2 & tTroops.Value[coordinate1.x, coordinate1.y] > 0 & !(coordinate1.x == index5 & coordinate1.y == index6))
                    tTroops.Value[coordinate1.x, coordinate1.y] = (int) Math.Round((double) ((float) tTroops.Value[coordinate1.x, coordinate1.y] * num21));
                  int index11 = 0;
                  do
                  {
                    coordinate2 = this.ai.TempHexNeighbour[coordinate1.x, coordinate1.y, index11];
                    if (coordinate2.onmap & coordinate2.x <= this.Width & coordinate2.y <= this.Height && tOwner.Value[coordinate2.x, coordinate2.y] == 2 & tTroops.Value[coordinate2.x, coordinate2.y] > 0 & !(coordinate2.x == index5 & coordinate2.y == index6))
                      tTroops.Value[coordinate2.x, coordinate2.y] = (int) Math.Round((double) ((float) tTroops.Value[coordinate2.x, coordinate2.y] * num21));
                    index11 += 1;
                  }
                  while (index11 <= 5);
                }
                index10 += 1;
              }
              while (index10 <= 5);
            }
          }
        }
      }
    }

    pub void SetMoveCost(int extraAP = 0)
    {
      int num1;
      if (this.front.FrontID == 1362)
        num1 = num1;
      if (this.front.units.counter > -1)
      {
        this.MoveTempLos = new AIMatrix[this.front.units.counter + 1];
        this.MoveCostMove = new AIMatrix[this.front.units.counter + 1];
        this.MoveFromMove = new AICoordinateMatrix[this.front.units.counter + 1];
        this.MoveCostAttack = new AIMatrix[this.front.units.counter + 1, 6];
        this.MoveFromAttack = new AICoordinateMatrix[this.front.units.counter + 1, 6];
      }
      if (this.front.artUnits.counter > -1)
      {
        this.MoveCostArtMove = new AIMatrix[this.front.artUnits.counter + 1];
        this.MoveFromArtMove = new AICoordinateMatrix[this.front.artUnits.counter + 1];
        this.MoveCostArtAttack = new AIMatrix[this.front.artUnits.counter + 1, 6];
        this.MoveFromArtAttack = new AICoordinateMatrix[this.front.artUnits.counter + 1, 6];
      }
      if (this.front.orgUnits.counter > -1)
      {
        this.MoveCostOrgMove = new AIMatrix[this.front.orgUnits.counter + 1];
        this.MoveFromOrgMove = new AICoordinateMatrix[this.front.orgUnits.counter + 1];
      }
      if (this.front.units.counter > -1)
      {
        for (int counter = this.front.units.counter; counter >= 0; counter += -1)
        {
          this.front.units.unr[counter] = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[counter]);
          if (this.front.units.unr[counter] < 0)
            this.front.units.removeAiId(this.front.units.AIid[counter]);
        }
      }
      if (this.front.artUnits.counter > -1)
      {
        for (int counter = this.front.artUnits.counter; counter >= 0; counter += -1)
        {
          this.front.artUnits.unr[counter] = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.artUnits.AIid[counter]);
          if (this.front.artUnits.unr[counter] < 0)
            this.front.artUnits.removeAiId(this.front.artUnits.AIid[counter]);
        }
      }
      if (this.front.orgUnits.counter > -1)
      {
        for (int counter = this.front.orgUnits.counter; counter >= 0; counter += -1)
          this.front.orgUnits.unr[counter] = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.orgUnits.AIid[counter]);
      }
      int counter1 = this.front.units.counter;
      int num2;
      int num3;
      int num4;
      Coordinate coordinate1;
      int x1;
      int y1;
      Coordinate coordinate2;
      for (int index1 = 0; index1 <= counter1; index1 += 1)
      {
        this.MoveTempLos[index1] = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
        this.MoveCostMove[index1] = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
        this.MoveFromMove[index1] = new AICoordinateMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
        int index2 = 0;
        do
        {
          this.MoveCostAttack[index1, index2] = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
          this.MoveFromAttack[index1, index2] = new AICoordinateMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
          index2 += 1;
        }
        while (index2 <= 5);
        int unr = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index1]);
        if (this.ai.game.Data.Turn == 7)
          unr = unr;
        if (unr == 220)
          unr = unr;
        if (unr > -1)
        {
          if (unr == 171 | unr == 125)
            unr = unr;
          this.ai.game.Data.UnitObj[unr].LastAP = -1;
          bool flag = false;
          if (this.ai.game.Data.UnitObj[unr].Regime != this.ai.game.Data.Turn)
            flag = true;
          if (this.ai.game.HandyFunctionsObj.GetLowestAp(unr) < 10)
            flag = this.ai.game.Data.UnitObj[unr].FreeCombatX < 0;
          if (flag)
          {
            int width = this.Width;
            for (int index3 = 0; index3 <= width; index3 += 1)
            {
              int height = this.Height;
              for (int index4 = 0; index4 <= height; index4 += 1)
              {
                this.MoveCostMove[index1].Value[index3, index4] = 9999;
                this.MoveFromMove[index1].Value[index3, index4].onmap = false;
                int index5 = 0;
                do
                {
                  this.MoveCostAttack[index1, index5].Value[index3, index4] = 9999;
                  this.MoveFromAttack[index1, index5].Value[index3, index4].onmap = false;
                  index5 += 1;
                }
                while (index5 <= 5);
              }
            }
          }
          else
          {
            int x2 = this.ai.game.Data.UnitObj[unr].X;
            int y2 = this.ai.game.Data.UnitObj[unr].Y;
            num2 = 0;
            if (extraAP == 0)
              num2 = 1;
            if (extraAP > 0)
            {
              num2 = 1;
              if (this.front.FrontType == 12)
                ;
            }
            if (this.front.FrontType == 5 | this.front.FrontType == 4)
              num2 = 0;
            if (num2 == 1 | this.front.FrontType == 8 | this.front.FrontType == 9)
            {
              if (this.ai.game.HandyFunctionsObj.HasUnitAirSF(unr) & (this.front.FrontType == 5 | this.front.FrontType == 4))
                this.ai.game.HandyFunctionsObj.MakeMovePrediction(unr, x2, y2, 0, increaseap: extraAP, ismove: true);
              else
                this.ai.game.HandyFunctionsObj.MakeMovePrediction3(unr, x2, y2, 0, attack: true, increaseap: extraAP, attackoptions: true, ismove: true, OnlyFrontline: true, tcustomAi: (ref this.ai.CustomCalls));
              unr = unr;
            }
            else
              this.ai.game.HandyFunctionsObj.RedimTempValue(9999);
            int width1 = this.Width;
            for (int index6 = 0; index6 <= width1; index6 += 1)
            {
              int height = this.Height;
              for (int y2_1 = 0; y2_1 <= height; y2_1 += 1)
              {
                int index7 = 0;
                do
                {
                  int num5 = 0;
                  if (!Information.IsNothing((object) this.ai.game.EditObj.TempAttack[0]) && this.ai.game.EditObj.TempAttack[0].Value[this.GetRealX(index6), this.Top + y2_1, index7])
                    num5 = 1;
                  if (num5 == 1)
                  {
                    int num6 = index7 + 3;
                    if (num6 > 5)
                      num3 = num6 - 6;
                    this.MoveCostAttack[index1, index7].Value[index6, y2_1] = this.ai.game.EditObj.TempValue[0].Value[this.GetRealX(index6), this.Top + y2_1];
                    this.MoveFromAttack[index1, index7].Value[index6, y2_1] = this.ai.game.EditObj.TempCameFrom[0].Value[this.GetRealX(index6), this.Top + y2_1];
                    if (this.MoveFromAttack[index1, index7].Value[index6, y2_1].onmap)
                    {
                      if (this.GetMatrixX(this.MoveFromAttack[index1, index7].Value[index6, y2_1].x) <= this.Width & this.MoveFromAttack[index1, index7].Value[index6, y2_1].y - this.Top <= this.Height && this.MoveFromAttack[index1, index7].Value[index6, y2_1].y - this.Top >= 0 & this.GetMatrixX(this.MoveFromAttack[index1, index7].Value[index6, y2_1].x) >= 0)
                      {
                        if (this.Owner.Value[this.GetMatrixX(this.MoveFromAttack[index1, index7].Value[index6, y2_1].x), this.MoveFromAttack[index1, index7].Value[index6, y2_1].y - this.Top] != 1 | this.ai.map.HexObj[this.GetRealX(index6), y2_1 + this.Top].Regime == -1)
                        {
                          num4 = num5;
                          int num7 = 9999;
                          if (index6 + this.Left == 24 & y2_1 + this.Top == 16)
                            index6 = index6;
                          if (index6 + this.Left == 25 & y2_1 + this.Top == 13)
                            index6 = index6;
                          if (this.ai.game.EditObj.TempAttack[0].Value[this.GetRealX(index6), this.Top + y2_1, index7])
                          {
                            coordinate1 = this.ai.game.HandyFunctionsObj.HexNeighbour(this.GetRealX(index6), this.Top + y2_1, 0, index7 + 1);
                            if (coordinate1.onmap & this.GetMatrixX(coordinate1.x) <= this.Width & coordinate1.y - this.Top <= this.Height && this.GetMatrixX(coordinate1.x) >= 0 & coordinate1.y - this.Top >= 0 & this.GetMatrixX(coordinate1.x) <= this.Width & coordinate1.y - this.Top <= this.Height)
                            {
                              num7 = this.ai.game.EditObj.TempValue[0].Value[coordinate1.x, coordinate1.y];
                              x1 = coordinate1.x;
                              y1 = coordinate1.y;
                            }
                          }
                          if (num7 < 9999)
                          {
                            this.MoveFromAttack[index1, index7].Value[index6, y2_1].onmap = true;
                            this.MoveFromAttack[index1, index7].Value[index6, y2_1].x = x1;
                            this.MoveFromAttack[index1, index7].Value[index6, y2_1].y = y1;
                            int[,] numArray = this.MoveCostAttack[index1, index7].Value;
                            int index8 = index6;
                            int index9 = y2_1;
                            int num8 = this.ai.game.EditObj.TempValue[0].Value[x1, y1];
                            coordinate2 = this.ai.game.HandyFunctionsObj.MoveApCostPreview(unr, x1, y1, x1, y1, 0, this.GetRealX(index6), y2_1 + this.Top, 0, true);
                            int x3 = coordinate2.x;
                            int num9 = num8 + x3;
                            numArray[index8, index9] = num9;
                          }
                          else
                          {
                            this.MoveCostAttack[index1, index7].Value[index6, y2_1] = 9999;
                            this.MoveFromAttack[index1, index7].Value[index6, y2_1].onmap = false;
                          }
                        }
                        this.MoveFromAttack[index1, index7].Value[index6, y2_1].x = this.GetMatrixX(this.MoveFromAttack[index1, index7].Value[index6, y2_1].x);
                        Coordinate[,] coordinateArray1 = this.MoveFromAttack[index1, index7].Value;
                        Coordinate[,] coordinateArray2 = coordinateArray1;
                        int index10 = index6;
                        int index11 = index10;
                        int index12 = y2_1;
                        int index13 = index12;
                        coordinateArray2[index11, index13].y = coordinateArray1[index10, index12].y - this.Top;
                        if (DrawMod.TGame.HandyFunctionsObj.Distance(this.MoveFromAttack[index1, index7].Value[index6, y2_1].x, this.MoveFromAttack[index1, index7].Value[index6, y2_1].y, 0, index6, y2_1, 0) > 1)
                          index6 = index6;
                        if (this.MoveFromAttack[index1, index7].Value[index6, y2_1].x < 0 | this.MoveFromAttack[index1, index7].Value[index6, y2_1].y < 0)
                          this.MoveFromAttack[index1, index7].Value[index6, y2_1].onmap = false;
                      }
                    }
                    else
                      this.MoveCostAttack[index1, index7].Value[index6, y2_1] = 9999;
                  }
                  else
                    this.MoveCostAttack[index1, index7].Value[index6, y2_1] = 9999;
                  index7 += 1;
                }
                while (index7 <= 5);
              }
            }
            if (this.ai.game.HandyFunctionsObj.HasUnitAirSF(unr) & (this.front.FrontType == 5 | this.front.FrontType == 4))
              this.ai.game.HandyFunctionsObj.MakeMovePrediction(unr, x2, y2, 0, increaseap: extraAP, ismove: true);
            else
              this.ai.game.HandyFunctionsObj.MakeMovePrediction3(unr, x2, y2, 0, increaseap: extraAP, attackoptions: true, ismove: true, tcustomAi: (ref this.ai.CustomCalls));
            if (this.ai.game.Data.UnitObj[unr].FreeCombatX > -1)
              this.Left = this.Left;
            int width2 = this.Width;
            for (int tx = 0; tx <= width2; tx += 1)
            {
              int height = this.Height;
              for (int index14 = 0; index14 <= height; index14 += 1)
              {
                this.MoveCostMove[index1].Value[tx, index14] = this.ai.game.EditObj.TempValue[0].Value[this.GetRealX(tx), this.Top + index14];
                this.MoveFromMove[index1].Value[tx, index14] = this.ai.game.EditObj.TempCameFrom[0].Value[this.GetRealX(tx), this.Top + index14];
                if (this.MoveFromMove[index1].Value[tx, index14].onmap)
                {
                  this.MoveFromMove[index1].Value[tx, index14].x = this.GetMatrixX(this.MoveFromMove[index1].Value[tx, index14].x);
                  if (this.MoveFromMove[index1].Value[tx, index14].x > 100)
                    index1 = index1;
                  Coordinate[,] coordinateArray3 = this.MoveFromMove[index1].Value;
                  Coordinate[,] coordinateArray4 = coordinateArray3;
                  int index15 = tx;
                  int index16 = index15;
                  int index17 = index14;
                  int index18 = index17;
                  coordinateArray4[index16, index18].y = coordinateArray3[index15, index17].y - this.Top;
                  if (this.MoveFromMove[index1].Value[tx, index14].x < 0 | this.MoveFromMove[index1].Value[tx, index14].y < 0)
                    this.MoveFromMove[index1].Value[tx, index14].onmap = false;
                }
              }
            }
          }
        }
      }
      int counter2 = this.front.artUnits.counter;
      for (int index19 = 0; index19 <= counter2; index19 += 1)
      {
        int unitByAiid1 = DrawMod.TGame.HandyFunctionsObj.GetUnitByAIid(this.front.artUnits.AIid[index19]);
        this.MoveCostArtMove[index19] = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
        this.MoveFromArtMove[index19] = new AICoordinateMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
        int index20 = 0;
        do
        {
          this.MoveCostArtAttack[index19, index20] = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
          this.MoveFromArtAttack[index19, index20] = new AICoordinateMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
          index20 += 1;
        }
        while (index20 <= 5);
        this.ai.game.Data.UnitObj[unitByAiid1].LastAP = -1;
        bool flag1 = false;
        if (this.ai.game.Data.UnitObj[unitByAiid1].Regime != this.ai.game.Data.Turn)
          flag1 = true;
        if (!this.ai.game.HandyFunctionsObj.CanUnitMove(unitByAiid1))
          flag1 = true;
        if (this.ai.game.HandyFunctionsObj.GetMaxArtRange(unitByAiid1, 0) > 0)
          flag1 = true;
        if (this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid1) < 10)
          flag1 = this.ai.game.Data.UnitObj[unitByAiid1].FreeCombatX < 0;
        if (flag1)
        {
          int width = this.Width;
          for (int index21 = 0; index21 <= width; index21 += 1)
          {
            int height = this.Height;
            for (int index22 = 0; index22 <= height; index22 += 1)
            {
              int index23 = 0;
              do
              {
                this.MoveCostArtAttack[index19, index23].Value[index21, index22] = 9999;
                this.MoveFromArtAttack[index19, index23].Value[index21, index22].onmap = false;
                index23 += 1;
              }
              while (index23 <= 5);
            }
          }
        }
        else
        {
          int x4 = this.ai.game.Data.UnitObj[unitByAiid1].X;
          int y3 = this.ai.game.Data.UnitObj[unitByAiid1].Y;
          num2 = 0;
          if (extraAP == 0)
            num2 = 1;
          if (extraAP > 0)
          {
            num2 = 1;
            if (this.ai.frontMatrix.Value[x4, y3] == this.front.FrontID)
              num2 = 0;
            if (this.front.TargetFrontID > 0 && this.ai.frontMatrix.Value[x4, y3] == this.front.TargetFrontID)
              num2 = 0;
          }
          if (num2 == 1 | this.front.FrontType == 8 | this.front.FrontType == 9)
            this.ai.game.HandyFunctionsObj.MakeMovePrediction3(unitByAiid1, x4, y3, 0, attack: true, increaseap: extraAP, attackoptions: true, ismove: true, OnlyFrontline: true, tcustomAi: (ref this.ai.CustomCalls));
          else
            this.ai.game.HandyFunctionsObj.RedimTempValue(9999);
          int width = this.Width;
          for (int index24 = 0; index24 <= width; index24 += 1)
          {
            int height = this.Height;
            for (int y2 = 0; y2 <= height; y2 += 1)
            {
              int index25 = 0;
              do
              {
                int num10 = 0;
                if (unitByAiid1 == 82 & index24 + this.Left == 22 & y2 + this.Top == 8)
                  num10 = num10;
                if (!Information.IsNothing((object) this.ai.game.EditObj.TempAttack[0]) && this.ai.game.EditObj.TempAttack[0].Value[this.GetRealX(index24), this.Top + y2, index25])
                  num10 = 1;
                if (num10 == 1)
                {
                  int num11 = index25 + 3;
                  if (num11 > 5)
                    num3 = num11 - 6;
                  this.MoveCostArtAttack[index19, index25].Value[index24, y2] = this.ai.game.EditObj.TempValue[0].Value[this.GetRealX(index24), this.Top + y2];
                  this.MoveFromArtAttack[index19, index25].Value[index24, y2] = this.ai.game.EditObj.TempCameFrom[0].Value[this.GetRealX(index24), this.Top + y2];
                  if (this.MoveFromArtAttack[index19, index25].Value[index24, y2].onmap)
                  {
                    if (this.GetMatrixX(this.MoveFromArtAttack[index19, index25].Value[index24, y2].x) <= this.Width & this.MoveFromArtAttack[index19, index25].Value[index24, y2].y - this.Top <= this.Height && this.MoveFromArtAttack[index19, index25].Value[index24, y2].y - this.Top >= 0 & this.GetMatrixX(this.MoveFromArtAttack[index19, index25].Value[index24, y2].x) >= 0)
                    {
                      if (this.Owner.Value[this.GetMatrixX(this.MoveFromArtAttack[index19, index25].Value[index24, y2].x), this.MoveFromArtAttack[index19, index25].Value[index24, y2].y - this.Top] == 1 | this.ai.map.HexObj[this.GetRealX(index24), y2 + this.Top].Regime == -1)
                      {
                        num4 = num10;
                        int num12 = 9999;
                        if (this.ai.game.EditObj.TempAttack[0].Value[this.GetRealX(index24), this.Top + y2, index25])
                        {
                          coordinate1 = this.ai.game.HandyFunctionsObj.HexNeighbour(this.GetRealX(index24), this.Top + y2, 0, index25 + 1);
                          if (coordinate1.onmap && this.GetMatrixX(coordinate1.x) >= 0 & coordinate1.y - this.Top >= 0 & this.GetMatrixX(coordinate1.x) <= this.Width & coordinate1.y - this.Top <= this.Height)
                          {
                            num12 = this.ai.game.EditObj.TempValue[0].Value[coordinate1.x, coordinate1.y];
                            x1 = coordinate1.x;
                            y1 = coordinate1.y;
                          }
                        }
                        if (num12 < 9999)
                        {
                          this.MoveFromArtAttack[index19, index25].Value[index24, y2].onmap = true;
                          this.MoveFromArtAttack[index19, index25].Value[index24, y2].x = x1;
                          this.MoveFromArtAttack[index19, index25].Value[index24, y2].y = y1;
                          int[,] numArray = this.MoveCostArtAttack[index19, index25].Value;
                          int index26 = index24;
                          int index27 = y2;
                          int num13 = this.ai.game.EditObj.TempValue[0].Value[x1, y1];
                          coordinate2 = this.ai.game.HandyFunctionsObj.MoveApCostPreview(unitByAiid1, x1, y1, x1, y1, 0, this.GetRealX(index24), y2 + this.Top, 0, true);
                          int x5 = coordinate2.x;
                          int num14 = num13 + x5;
                          numArray[index26, index27] = num14;
                        }
                        else
                        {
                          this.MoveCostArtAttack[index19, index25].Value[index24, y2] = 9999;
                          this.MoveFromArtAttack[index19, index25].Value[index24, y2].onmap = false;
                        }
                      }
                      this.MoveFromArtAttack[index19, index25].Value[index24, y2].x = this.GetMatrixX(this.MoveFromArtAttack[index19, index25].Value[index24, y2].x);
                      Coordinate[,] coordinateArray5 = this.MoveFromArtAttack[index19, index25].Value;
                      Coordinate[,] coordinateArray6 = coordinateArray5;
                      int index28 = index24;
                      int index29 = index28;
                      int index30 = y2;
                      int index31 = index30;
                      coordinateArray6[index29, index31].y = coordinateArray5[index28, index30].y - this.Top;
                      if (DrawMod.TGame.HandyFunctionsObj.Distance(this.MoveFromArtAttack[index19, index25].Value[index24, y2].x, this.MoveFromArtAttack[index19, index25].Value[index24, y2].y, 0, index24, y2, 0) > 1)
                        index24 = index24;
                      if (this.MoveFromArtAttack[index19, index25].Value[index24, y2].x < 0 | this.MoveFromArtAttack[index19, index25].Value[index24, y2].y < 0)
                        this.MoveFromArtAttack[index19, index25].Value[index24, y2].onmap = false;
                    }
                  }
                  else
                    this.MoveCostArtAttack[index19, index25].Value[index24, y2] = 9999;
                }
                else
                  this.MoveCostArtAttack[index19, index25].Value[index24, y2] = 9999;
                index25 += 1;
              }
              while (index25 <= 5);
            }
          }
        }
        int unitByAiid2 = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.artUnits.AIid[index19]);
        if (unitByAiid2 > -1)
        {
          bool flag2 = false;
          if (this.ai.game.Data.UnitObj[unitByAiid2].Regime != this.ai.game.Data.Turn)
            flag2 = true;
          if (!this.ai.game.HandyFunctionsObj.CanUnitMove(unitByAiid2))
            flag2 = true;
          if (this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid2) < 20)
            flag2 = true;
          if (this.ai.game.Data.UnitObj[unitByAiid2].DidAttack & extraAP > 0)
            flag2 = true;
          if (this.ai.game.Data.UnitObj[unitByAiid2].DidMove & extraAP > 0)
            flag2 = true;
          if (flag2)
          {
            int width = this.Width;
            for (int index32 = 0; index32 <= width; index32 += 1)
            {
              int height = this.Height;
              for (int index33 = 0; index33 <= height; index33 += 1)
              {
                this.MoveCostArtMove[index19].Value[index32, index33] = 9999;
                this.MoveFromArtMove[index19].Value[index32, index33].onmap = false;
              }
            }
          }
          else
          {
            int x6 = this.ai.game.Data.UnitObj[unitByAiid2].X;
            int y4 = this.ai.game.Data.UnitObj[unitByAiid2].Y;
            if (extraAP == 0)
              num2 = 1;
            if (extraAP > 0)
            {
              num2 = 1;
              if (this.ai.frontMatrix.Value[x6, y4] == this.front.FrontID)
                num2 = 0;
              if (this.front.TargetFrontID > 0 && this.ai.frontMatrix.Value[x6, y4] == this.front.FrontID)
                num2 = 0;
            }
            if (num2 == 1)
            {
              this.ai.game.HandyFunctionsObj.MakeMovePrediction3(unitByAiid2, x6, y4, 0, increaseap: extraAP, attackoptions: true, ismove: true, tcustomAi: (ref this.ai.CustomCalls));
              num1 = x6;
            }
            else
              this.ai.game.HandyFunctionsObj.RedimTempValue(9999);
            int width = this.Width;
            for (int tx = 0; tx <= width; tx += 1)
            {
              int height = this.Height;
              for (int index34 = 0; index34 <= height; index34 += 1)
              {
                this.MoveCostArtMove[index19].Value[tx, index34] = this.ai.game.EditObj.TempValue[0].Value[this.GetRealX(tx), this.Top + index34];
                this.MoveFromArtMove[index19].Value[tx, index34] = this.ai.game.EditObj.TempCameFrom[0].Value[this.GetRealX(tx), this.Top + index34];
                if (this.MoveFromArtMove[index19].Value[tx, index34].onmap)
                {
                  this.MoveFromArtMove[index19].Value[tx, index34].x = this.GetMatrixX(this.MoveFromArtMove[index19].Value[tx, index34].x);
                  Coordinate[,] coordinateArray7 = this.MoveFromArtMove[index19].Value;
                  Coordinate[,] coordinateArray8 = coordinateArray7;
                  int index35 = tx;
                  int index36 = index35;
                  int index37 = index34;
                  int index38 = index37;
                  coordinateArray8[index36, index38].y = coordinateArray7[index35, index37].y - this.Top;
                  if (this.MoveFromArtMove[index19].Value[tx, index34].x < 0 | this.MoveFromArtMove[index19].Value[tx, index34].y < 0)
                    this.MoveFromArtMove[index19].Value[tx, index34].onmap = false;
                }
              }
            }
          }
        }
      }
      int counter3 = this.front.orgUnits.counter;
      for (int index39 = 0; index39 <= counter3; index39 += 1)
      {
        this.MoveCostOrgMove[index39] = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
        this.MoveFromOrgMove[index39] = new AICoordinateMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.orgUnits.AIid[index39]);
        if (unitByAiid > -1)
        {
          bool flag = false;
          if (this.ai.game.Data.UnitObj[unitByAiid].Regime != this.ai.game.Data.Turn)
            flag = true;
          if (!this.ai.game.HandyFunctionsObj.CanUnitMove(unitByAiid))
            flag = true;
          if (this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid) < 20)
            flag = true;
          if (this.ai.game.Data.UnitObj[unitByAiid].DidAttack & extraAP > 0)
            flag = true;
          if (this.ai.game.Data.UnitObj[unitByAiid].DidMove & extraAP > 0)
            flag = true;
          if (flag)
          {
            int width = this.Width;
            for (int index40 = 0; index40 <= width; index40 += 1)
            {
              int height = this.Height;
              for (int index41 = 0; index41 <= height; index41 += 1)
              {
                this.MoveCostOrgMove[index39].Value[index40, index41] = 9999;
                this.MoveFromOrgMove[index39].Value[index40, index41].onmap = false;
              }
            }
          }
          else
          {
            int x7 = this.ai.game.Data.UnitObj[unitByAiid].X;
            int y5 = this.ai.game.Data.UnitObj[unitByAiid].Y;
            if (extraAP == 0)
              num2 = 1;
            if (extraAP > 0)
            {
              num2 = 1;
              if (this.ai.frontMatrix.Value[x7, y5] == this.front.FrontID)
                num2 = 0;
              if (this.front.TargetFrontID > 0 && this.ai.frontMatrix.Value[x7, y5] == this.front.FrontID)
                num2 = 0;
            }
            if (num2 == 1)
            {
              HandyFunctionsclass handyFunctionsObj = this.ai.game.HandyFunctionsObj;
              int unr = unitByAiid;
              int x8 = x7;
              int y6 = y5;
              int increaseap = extraAP;
              CustomDC2AICalls customDc2AiCalls = (CustomDC2AICalls) null;
              ref CustomDC2AICalls local = ref customDc2AiCalls;
              handyFunctionsObj.MakeMovePrediction3(unr, x8, y6, 0, increaseap: increaseap, attackoptions: true, ismove: true, tcustomAi: (ref local));
            }
            else
              this.ai.game.HandyFunctionsObj.RedimTempValue(9999);
            int width = this.Width;
            for (int tx = 0; tx <= width; tx += 1)
            {
              int height = this.Height;
              for (int index42 = 0; index42 <= height; index42 += 1)
              {
                this.MoveCostOrgMove[index39].Value[tx, index42] = this.ai.game.EditObj.TempValue[0].Value[this.GetRealX(tx), this.Top + index42];
                this.MoveFromOrgMove[index39].Value[tx, index42] = this.ai.game.EditObj.TempCameFrom[0].Value[this.GetRealX(tx), this.Top + index42];
                if (this.MoveFromOrgMove[index39].Value[tx, index42].onmap)
                {
                  this.MoveFromOrgMove[index39].Value[tx, index42].x = this.GetMatrixX(this.MoveFromOrgMove[index39].Value[tx, index42].x);
                  Coordinate[,] coordinateArray9 = this.MoveFromOrgMove[index39].Value;
                  Coordinate[,] coordinateArray10 = coordinateArray9;
                  int index43 = tx;
                  int index44 = index43;
                  int index45 = index42;
                  int index46 = index45;
                  coordinateArray10[index44, index46].y = coordinateArray9[index43, index45].y - this.Top;
                  if (this.MoveFromOrgMove[index39].Value[tx, index42].x < 0 | this.MoveFromOrgMove[index39].Value[tx, index42].y < 0)
                    this.MoveFromOrgMove[index39].Value[tx, index42].onmap = false;
                }
              }
            }
          }
        }
      }
    }

    pub void SetMatrixDimensionsAir()
    {
      this.Left = 0;
      this.Top = 0;
      this.Right = this.map.MapWidth;
      this.Bottom = this.map.MapHeight;
      this.Width = this.map.MapWidth;
      this.Height = this.map.MapHeight;
    }

    pub void SetMatrixDimensions()
    {
      if (this.map.MapLoop)
      {
        this.SetMatrixDimensionsWithMapLoop();
      }
      else
      {
        this.Left = this.map.MapWidth;
        this.Top = this.map.MapHeight;
        this.Right = 0;
        this.Bottom = 0;
        int counter1 = this.front.units.counter;
        for (int index = 0; index <= counter1; index += 1)
        {
          int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index]);
          if (unitByAiid > -1 && this.ai.game.Data.UnitObj[unitByAiid].X > -1)
          {
            int x = this.ai.game.Data.UnitObj[unitByAiid].X;
            int y = this.ai.game.Data.UnitObj[unitByAiid].Y;
            if (this.Left > x)
              this.Left = x;
            if (this.Right < x)
              this.Right = x;
            if (this.Top > y)
              this.Top = y;
            if (this.Bottom < y)
              this.Bottom = y;
          }
        }
        if (this.front.FrontType == 6 && this.front.coordCount > -1)
        {
          int coordCount = this.front.coordCount;
          for (int index = 0; index <= coordCount; index += 1)
          {
            int x = this.front.Coords[index].x;
            int y = this.front.Coords[index].y;
            if (this.Left > x)
              this.Left = x;
            if (this.Right < x)
              this.Right = x;
            if (this.Top > y)
              this.Top = y;
            if (this.Bottom < y)
              this.Bottom = y;
          }
        }
        if (this.front.units.counter == -1 | this.Left > this.Right | this.Top > this.Bottom)
        {
          this.Left = 0;
          this.Top = 0;
          this.Right = this.map.MapWidth;
          this.Bottom = this.map.MapHeight;
        }
        int counter2 = this.front.artUnits.counter;
        for (int index = 0; index <= counter2; index += 1)
        {
          int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.artUnits.AIid[index]);
          if (unitByAiid > -1 && this.ai.game.Data.UnitObj[unitByAiid].X > -1)
          {
            int x = this.ai.game.Data.UnitObj[unitByAiid].X;
            int y = this.ai.game.Data.UnitObj[unitByAiid].Y;
            if (this.Left > x)
              this.Left = x;
            if (this.Right < x)
              this.Right = x;
            if (this.Top > y)
              this.Top = y;
            if (this.Bottom < y)
              this.Bottom = y;
          }
        }
        if (0 > this.Left)
          this.Left = 0;
        if (0 > this.Top)
          this.Top = 0;
        if (this.Right > this.ai.map.MapWidth)
          this.Right = this.ai.map.MapWidth;
        if (this.Bottom > this.ai.map.MapHeight)
          this.Bottom = this.ai.map.MapHeight;
        if (this.Right < this.Left)
        {
          int left = this.Left;
          this.Left = this.Right;
          this.Right = left;
        }
        if (this.Bottom < this.Top)
        {
          int top = this.Top;
          this.Top = this.Bottom;
          this.Bottom = top;
        }
        int mapWidth = this.ai.map.MapWidth;
        for (int index1 = 0; index1 <= mapWidth; index1 += 1)
        {
          int mapHeight = this.ai.map.MapHeight;
          for (int index2 = 0; index2 <= mapHeight; index2 += 1)
          {
            if (this.ai.frontMatrix.Value[index1, index2] == this.front.FrontID)
            {
              if (this.Left > index1)
                this.Left = index1;
              if (this.Right < index1)
                this.Right = index1;
              if (this.Top > index2)
                this.Top = index2;
              if (this.Bottom < index2)
                this.Bottom = index2;
            }
            if (this.front.TargetFrontID > 0 && this.ai.frontMatrix.Value[index1, index2] == this.front.TargetFrontID)
            {
              if (this.Left > index1)
                this.Left = index1;
              if (this.Right < index1)
                this.Right = index1;
              if (this.Top > index2)
                this.Top = index2;
              if (this.Bottom < index2)
                this.Bottom = index2;
            }
          }
        }
        int num = this.ai.VAR_MOVE_MAXIMUM_RANGE;
        if (this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].ProdBonus == 0)
          num = (int) Math.Round((double) num / 2.0);
        this.Left -= num;
        this.Right += num;
        this.Top -= num;
        this.Bottom += num;
        this.Left -= 2;
        this.Right += 2;
        this.Top -= 2;
        this.Bottom += 2;
        if (this.front.FrontType == 2)
        {
          this.Left -= 1 * num;
          this.Right += 1 * num;
          this.Top -= 1 * num;
          this.Bottom += 1 * num;
        }
        if (this.map.MapLoop & (this.Left <= 0 | this.Right > this.map.MapWidth))
        {
          this.Left = 0;
          this.Top = 0;
          this.Right = this.map.MapWidth;
          this.Bottom = this.map.MapHeight;
          this.Width = this.map.MapWidth;
          this.Height = this.map.MapHeight;
        }
        else
        {
          this.Left = Math.Max(0, this.Left);
          this.Top = Math.Max(0, this.Top);
          this.Right = Math.Min(this.map.MapWidth, this.Right);
          this.Bottom = Math.Min(this.map.MapHeight, this.Bottom);
          if ((this.Left + 2) % 2 > 0)
            --this.Left;
          if ((this.Top + 2) % 2 > 0)
            --this.Top;
          this.Width = this.Right - this.Left;
          this.Height = this.Bottom - this.Top;
        }
      }
    }

    pub void SetMatrixDimensionsWithMapLoop()
    {
      bool[] flagArray = new bool[this.map.MapWidth + 1];
      this.Left = this.map.MapWidth;
      this.Top = this.map.MapHeight;
      this.Right = 0;
      this.Bottom = 0;
      int counter1 = this.front.units.counter;
      for (int index = 0; index <= counter1; index += 1)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index]);
        if (unitByAiid > -1 && this.ai.game.Data.UnitObj[unitByAiid].X > -1)
        {
          int x = this.ai.game.Data.UnitObj[unitByAiid].X;
          int y = this.ai.game.Data.UnitObj[unitByAiid].Y;
          flagArray[x] = true;
          if (this.Top > y)
            this.Top = y;
          if (this.Bottom < y)
            this.Bottom = y;
        }
      }
      if (this.front.FrontType == 6 && this.front.coordCount > -1)
      {
        int coordCount = this.front.coordCount;
        for (int index = 0; index <= coordCount; index += 1)
        {
          int x = this.front.Coords[index].x;
          int y = this.front.Coords[index].y;
          flagArray[x] = true;
          if (this.Top > y)
            this.Top = y;
          if (this.Bottom < y)
            this.Bottom = y;
        }
      }
      int counter2 = this.front.artUnits.counter;
      for (int index = 0; index <= counter2; index += 1)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.artUnits.AIid[index]);
        if (unitByAiid > -1 && this.ai.game.Data.UnitObj[unitByAiid].X > -1)
        {
          int x = this.ai.game.Data.UnitObj[unitByAiid].X;
          int y = this.ai.game.Data.UnitObj[unitByAiid].Y;
          flagArray[x] = true;
          if (this.Top > y)
            this.Top = y;
          if (this.Bottom < y)
            this.Bottom = y;
        }
      }
      if (this.front.units.counter == -1 | this.Top > this.Bottom)
      {
        this.Top = 0;
        this.Bottom = this.map.MapHeight;
      }
      if (0 > this.Top)
        this.Top = 0;
      if (this.Bottom > this.ai.map.MapHeight)
        this.Bottom = this.ai.map.MapHeight;
      if (this.Bottom < this.Top)
      {
        int top = this.Top;
        this.Top = this.Bottom;
        this.Bottom = top;
      }
      int mapWidth1 = this.ai.map.MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; index1 += 1)
      {
        int mapHeight = this.ai.map.MapHeight;
        for (int index2 = 0; index2 <= mapHeight; index2 += 1)
        {
          if (this.ai.frontMatrix.Value[index1, index2] == this.front.FrontID)
          {
            flagArray[index1] = true;
            if (this.Top > index2)
              this.Top = index2;
            if (this.Bottom < index2)
              this.Bottom = index2;
          }
          if (this.front.TargetFrontID > 0 && this.ai.frontMatrix.Value[index1, index2] == this.front.TargetFrontID)
          {
            flagArray[index1] = true;
            if (this.Top > index2)
              this.Top = index2;
            if (this.Bottom < index2)
              this.Bottom = index2;
          }
        }
      }
      int num1 = 20;
      int num2 = 30;
      int counter3 = this.front.units.counter;
      for (int index = 0; index <= counter3; index += 1)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index]);
        if (unitByAiid > -1 && !DrawMod.TGame.HandyFunctionsObj.HasUnitAirSF(unitByAiid))
        {
          int lowestAp = DrawMod.TGame.HandyFunctionsObj.GetLowestAp(unitByAiid, true);
          if (lowestAp > num1 & lowestAp < 9999)
            num1 = lowestAp;
          int lowestMoveCostForAi = DrawMod.TGame.HandyFunctionsObj.GetLowestMoveCostForAI(unitByAiid, true);
          if (lowestMoveCostForAi < num2)
            num2 = lowestMoveCostForAi;
        }
      }
      int num3 = (int) Math.Round(Math.Ceiling((double) num1 / (double) num2)) + 1;
      int num4;
      int num5;
      if (num3 < 6)
        num5 = num4;
      int num6 = num3 - 2;
      if (DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.Turn].AIHelpMove > 0)
        num6 = (int) Math.Round((double) (num6 * (100 + DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.Turn].AIHelpMove)) / 100.0);
      if (num6 < 6)
        num6 = 6;
      if (DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.Turn].ProdBonus >= 250 && num6 < 8)
        num6 = 8;
      if (num6 > this.ai.VAR_MOVE_MAXIMUM_RANGE)
        num6 = this.ai.VAR_MOVE_MAXIMUM_RANGE;
      if (num6 > 9)
        num6 = 9 + (int) Math.Round((double) (num6 - 9) / 2.0);
      if (num6 > 12)
        num6 = 12 + (int) Math.Round((double) (num6 - 12) / 2.0);
      if (num6 > 14)
        num6 = 14;
      this.Top -= num6;
      this.Bottom += num6;
      int num7 = -1;
      int num8 = 0;
      int mapWidth2 = this.map.MapWidth;
      for (int index3 = 0; index3 <= mapWidth2; index3 += 1)
      {
        if (flagArray[index3])
        {
          num5 = 0;
          int num9 = index3 + 1;
          int num10 = index3 + this.map.MapWidth;
          for (int index4 = num9; index4 <= num10; index4 += 1)
          {
            int index5 = index4;
            if (index5 > this.map.MapWidth)
              index5 -= this.map.MapWidth + 1;
            if (!flagArray[index5])
            {
              num5 += 1;
              if (num5 > num8)
              {
                num8 = num5;
                num7 = index3;
              }
            }
            else
              break;
          }
        }
      }
      if (num8 > num6 * 2 & num7 > -1)
      {
        this.Left = num7 + num8 + 1;
        if (this.Left > this.map.MapWidth)
          this.Left -= this.map.MapWidth + 1;
        this.Right = this.Left + (this.map.MapWidth - num8);
        this.Left -= num6;
        if (this.Left < 0)
        {
          this.Left = this.map.MapWidth + this.Left + 1;
          this.Right = this.map.MapWidth + this.Right + 1;
        }
        this.Right += num6;
        if (this.Right > this.map.MapWidth)
          num5 = num5;
        num4 = num5;
      }
      else
      {
        this.Left = 0;
        this.Right = this.map.MapWidth;
      }
      this.Top = Math.Max(0, this.Top);
      this.Bottom = Math.Min(this.map.MapHeight, this.Bottom);
      if ((this.Left + 2) % 2 > 0)
        --this.Left;
      if ((this.Top + 2) % 2 > 0)
        --this.Top;
      this.Width = this.Right - this.Left;
      this.Height = this.Bottom - this.Top;
    }

    pub int GetRealX(int tx)
    {
      if (!this.map.MapLoop)
        tx += this.Left;
      else if (this.map.MapLoop)
      {
        tx += this.Left;
        if (tx > this.map.MapWidth)
        {
          tx -= this.map.MapWidth + 1;
          if (tx > this.map.MapWidth)
            tx -= this.map.MapWidth + 1;
        }
        else if (tx < 0)
          tx = this.map.MapWidth + 1 + tx;
      }
      return tx;
    }

    pub int GetMatrixX(int tx)
    {
      if (!this.map.MapLoop)
        tx -= this.Left;
      else if (this.map.MapLoop)
      {
        if (tx < this.Left)
          tx += this.map.MapWidth + 1;
        tx -= this.Left;
      }
      return tx;
    }

    pub int HexAttackOpportunity(int x, int y)
    {
      int num1 = 0 + this.TroopsReach.Value[x, y] + (int) Math.Round(1.5 * (double) this.Advance.Value[x, y]);
      if (this.front.Stance == 3)
        num1 += this.Advance.Value[x, y];
      int unitCounter = this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(x), this.Top + y].UnitCounter;
      int num2;
      int num3;
      int num4;
      for (int index = 0; index <= unitCounter; index += 1)
      {
        int unit = this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(x), this.Top + y].UnitList[index];
        num2 += 1;
        num3 += this.ai.game.Data.UnitObj[unit].SupplyConsume;
        if (this.ai.game.Data.UnitObj[unit].IsHQ)
          num4 += 1;
      }
      if (this.front.FrontType != 12)
      {
        if (num4 > 0)
          num1 = (num1 + 100 * num4) * (num4 + 1);
        if (num2 > 0)
        {
          int num5 = (int) Math.Round((double) num3 / (double) num2);
          if (num5 <= 10)
            num1 = (num1 + 50) * 20;
          else if (num5 <= 33)
            num1 = (num1 + 30) * 10;
          else if (num5 <= 66)
            num1 = (num1 + 20) * 3;
          else if (num5 > 75 & this.enemySupply.Value[x, y] > this.ai.VAR_SUPPLY_25PERCENT_RANGE & this.ai.VAR_HAMMER_OUT_POCKETS)
            num1 = (num1 + 10) * 2;
          else if (num5 > 75 & this.enemySupply.Value[x, y] > this.ai.VAR_SUPPLY_25PERCENT_RANGE & !this.ai.VAR_HAMMER_OUT_POCKETS)
            num1 = (int) Math.Round((double) num1 / 6.0);
        }
      }
      if (this.troopsstrength.Value[x, y] == 0 && this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(x + this.Left), y + this.Top].VP > 0 | this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].AIVP[0].Value[this.GetRealX(x + this.Left), y + this.Top] > 0)
        num1 *= 3;
      int d = 0;
      int num6 = 0;
      do
      {
        Coordinate coordinate = this.ai.game.HandyFunctionsObj.HexNeighbour(x, y, 0, num6 + 1);
        if (coordinate.onmap & coordinate.x <= this.Width & coordinate.y <= this.Height)
        {
          if (this.Owner.Value[coordinate.x, coordinate.y] == 1)
            d += 1;
          else if (this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(coordinate.x), coordinate.y + this.Top].UnitCounter == -1)
          {
            int counter = this.front.units.counter;
            for (int index = 0; index <= counter; index += 1)
            {
              if (this.MoveCostMove[index].Value[coordinate.x, coordinate.y] < 999)
              {
                d += 1;
                break;
              }
            }
          }
        }
        num6 += 1;
      }
      while (num6 <= 5);
      if (d == 0)
        d = 1;
      if (this.troopsstrength.Value[x, y] > 0)
        num1 = (int) Math.Round((double) num1 * Math.Sqrt((double) d));
      return num1;
    }

    pub int GetBestRiver(int x, int y, AIMatrix owner)
    {
      int num = 0;
      int bestRiver = -1;
      int index = 0;
      do
      {
        Coordinate coordinate = this.ai.TempHexNeighbour[x, y, index];
        if (coordinate.onmap && coordinate.x <= owner.Width & coordinate.y <= owner.Height && owner.Value[coordinate.x, coordinate.y] != owner.Value[x, y] && this.map.HexObj[this.GetRealX(x), y + owner.Top].RiverType[index] > -1)
        {
          int tempDefenseBonus = this.ai.game.Data.RiverTypeObj[this.map.HexObj[this.GetRealX(x), y + owner.Top].RiverType[index]].TempDefenseBonus;
          if (tempDefenseBonus > num)
          {
            num = tempDefenseBonus;
            bestRiver = this.map.HexObj[this.GetRealX(x), y + owner.Top].RiverType[index];
          }
        }
        index += 1;
      }
      while (index <= 5);
      return bestRiver;
    }

    pub int HexAttackImportance(int x, int y)
    {
      int num1 = 0;
      int num2 = this.FriendlyBottleneckIdeal.Value[x, y] - 5;
      if (num2 > 0)
        num1 += num2;
      int num3 = this.FriendlyBottleneckIdealOwnFrontOnly.Value[x, y] - 10;
      if (num3 > 0)
        num1 += num3;
      int num4 = this.EnemyBottleneck.Value[x, y] - 5;
      if (num4 > 0)
        num1 += num4;
      int num5 = this.EnemyBottleneckOwnFrontOnly.Value[x, y] - 10;
      if (num5 > 0)
        num1 += num5;
      if (this.enemySupply.Value[x, y] > this.ai.VAR_SUPPLY_MAXIMUM_RANGE && this.allTroops.Value[x, y] > 0 & this.front.enemyPower > 0)
      {
        int num6 = (int) Math.Round(300.0 * ((double) this.allTroops.Value[x, y] / (double) this.front.enemyPower));
        num1 += num6;
      }
      int num7 = this.vpMatrix.Value[x, y];
      if (this.ai.CustomCalls.HasCustumCalls())
        num7 = (int) Math.Round((double) ((float) num7 * this.ai.CustomCalls.CustomRuleTheaterModifiers_VpModifier(x, y)));
      int num8 = (int) Math.Round((double) num7 / 2.0);
      int num9 = num1 + num8;
      if (this.front.Stance == 3 && this.FrontAreaForAttack.Value[x, y] == this.front.FrontID)
      {
        if (this.ai.VAR_OFFENSIVE_ZONE_IS_ALL_OUT_MODE == 2)
        {
          num9 += (int) Math.Round((double) this.Advance.Value[x, y] * 1.5);
          if (this.origAdvance.Value[x, y] >= 100)
            num9 += 300;
          else if (this.origAdvance.Value[x, y] >= 85)
            num9 += 200;
          else if (this.origAdvance.Value[x, y] >= 70)
            num9 += 150;
          else if (this.origAdvance.Value[x, y] >= 55)
            num9 += 100;
          else if (this.origAdvance.Value[x, y] >= 40)
            num9 += 65;
          else if (this.origAdvance.Value[x, y] >= 25)
            num9 += 25;
        }
        else if (this.ai.VAR_OFFENSIVE_ZONE_IS_ALL_OUT_MODE == 1)
          num9 += (int) Math.Round((double) this.Advance.Value[x, y] * 0.5);
      }
      return num9;
    }

    pub float UnitOffensiveModifier(int unr)
    {
      int sfCount = this.ai.game.Data.UnitObj[unr].SFCount;
      int num1;
      int num2;
      for (int index = 0; index <= sfCount; index += 1)
      {
        int sf = this.ai.game.Data.UnitObj[unr].SFList[index];
        if (this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].AIRoleScore[10] > 0)
        {
          num1 += this.ai.game.Data.SFObj[sf].Qty;
          num2 += this.ai.game.Data.SFObj[sf].Qty;
        }
        else
          num1 += this.ai.game.Data.SFObj[sf].Qty;
      }
      return (float) num2 / (float) num1;
    }

    pub int CountUnitsWithSameHistoricalPresent(int his, UnitList UL)
    {
      int num = 0;
      int counter = UL.counter;
      for (int index = 0; index <= counter; index += 1)
      {
        if (this.ai.game.Data.UnitObj[UL.unr[index]].Historical == his)
          num += 1;
      }
      return num;
    }

    pub int CountUnitsWithSameHistoricalNearHex(int forunr, int forx, int fory)
    {
      int counter = this.front.units.counter;
      int num1;
      for (int index = 0; index <= counter; index += 1)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index]);
        if (unitByAiid > -1 & unitByAiid != forunr && this.ai.game.Data.UnitObj[unitByAiid].Historical == this.ai.game.Data.UnitObj[forunr].Historical)
        {
          int num2 = this.ai.game.HandyFunctionsObj.Distance(this.ai.game.Data.UnitObj[unitByAiid].X, this.ai.game.Data.UnitObj[unitByAiid].Y, 0, forx, fory, 0);
          if (num2 <= 1)
            num1 += 2;
          else if (num2 <= 2)
            num1 += 1;
        }
      }
      return (int) Math.Round((double) num1 / 2.0);
    }

    pub AIMoveList SetAttackMove(
      ref PassHexList passList,
      ref PassHexList tempPassList,
      ref PassHexList tryPassList,
      int stimulateAttack,
      bool forEncircled = false,
      int ignoreFirstXhexes = 0)
    {
      this.MoveList = AIMoveList::new();
      int num1 = 0;
      this.triedX = -1;
      this.triedY = -1;
      int index1 = -1;
      int index2 = -1;
      int num2 = -999999;
      int width = this.Width;
      int index3;
      int index4;
      for (index3 = 0; index3 <= width; index3 += 1)
      {
        int height = this.Height;
        for (int y = 0; y <= height; y += 1)
        {
          if (index3 == 7 & y == 12)
            index3 = index3;
          if (this.Owner.Value[index3, y] == 2)
          {
            int num3;
            if (this.FrontAreaForAttack.Value[index3, y] == this.front.FrontID & (forEncircled | this.TroopsReach.Value[index3, y] > 0))
            {
              if (!forEncircled)
              {
                num3 = this.HexAttackOpportunity(index3, y) + this.HexAttackImportance(index3, y);
                if (this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.GetRealX(index3), y + this.Top].LandscapeType].TempDefenseBonus > 0)
                  num3 = (int) Math.Round((double) num3 / (1.0 + (double) this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.GetRealX(index3), y + this.Top].LandscapeType].TempDefenseBonus / 100.0));
                Coordinate coordinate1;
                if (this.ai.VAR_EMPHASIS_FOR_CONCENTRIC & this.troopsstrength.Value[index3, y] > 0)
                {
                  Neighbours neighbours = Neighbours::new();
                  int num4 = 0;
                  int num5 = 0;
                  int index5 = 0;
                  do
                  {
                    coordinate1 = this.ai.TempHexNeighbour[this.GetRealX(index3), y + this.Top, index5];
                    if (coordinate1.onmap)
                    {
                      if (this.ai.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].Regime != -1)
                        num5 += 1;
                      if (this.ai.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].Regime == this.ai.game.Data.Turn)
                      {
                        neighbours.data[index5] = 1;
                        num4 += 1;
                      }
                    }
                    index5 += 1;
                  }
                  while (index5 <= 5);
                  HandyFunctionsclass handyFunctionsObj = this.ai.game.HandyFunctionsObj;
                  ref Neighbours local1 = ref neighbours;
                  bool flag = false;
                  ref bool local2 = ref flag;
                  float concentricBonus = handyFunctionsObj.GetConcentricBonus(ref local1, ref local2, true);
                  if (num3 > 0 & (double) concentricBonus > 1.0)
                    num3 = (int) Math.Round((double) ((float) num3 * concentricBonus));
                  if (num5 > 0)
                  {
                    float num6 = (float) num4 / (float) num5;
                    if ((double) num6 <= 0.0)
                      num3 = (int) Math.Round((double) num3 * 0.15);
                    else if ((double) num6 <= 0.200000002980232)
                      num3 = (int) Math.Round((double) num3 * 0.3);
                    else if ((double) num6 <= 0.300000011920929)
                      num3 = (int) Math.Round((double) num3 * 0.52);
                    else if ((double) num6 <= 0.400000005960464)
                      num3 = (int) Math.Round((double) num3 * 0.75);
                  }
                }
                if (this.ai.VAR_EMPHASIS_AGAINST_CONCENTRIC & this.troopsstrength.Value[index3, y] > 0)
                {
                  float num7 = 1f;
                  int index6 = 0;
                  do
                  {
                    coordinate1 = this.ai.TempHexNeighbour[this.GetRealX(index3), y + this.Top, index6];
                    if (coordinate1.onmap && this.ai.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].Regime != this.ai.game.Data.Turn && this.ai.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].Regime != -1)
                    {
                      Neighbours neighbours = Neighbours::new();
                      int index7 = 0;
                      do
                      {
                        Coordinate coordinate2 = this.ai.TempHexNeighbour[coordinate1.x, coordinate1.y, index7];
                        if (coordinate2.onmap && this.ai.game.Data.MapObj[0].HexObj[coordinate2.x, coordinate2.y].Regime == this.ai.game.Data.Turn)
                          neighbours.data[index7] = 1;
                        index7 += 1;
                      }
                      while (index7 <= 5);
                      HandyFunctionsclass handyFunctionsObj = this.ai.game.HandyFunctionsObj;
                      ref Neighbours local3 = ref neighbours;
                      bool flag = false;
                      ref bool local4 = ref flag;
                      float concentricBonus = handyFunctionsObj.GetConcentricBonus(ref local3, ref local4, true);
                      if ((double) concentricBonus > (double) num7)
                        num7 = concentricBonus;
                    }
                    index6 += 1;
                  }
                  while (index6 <= 5);
                  if (num3 > 0 & (double) num7 > 1.0)
                    num3 = (int) Math.Round((double) ((float) num3 * num7)) + (int) Math.Round(((double) num7 - 1.0) * 100.0);
                }
                if (this.friendlySupplyIdeal.Value[index3, y] > this.ai.VAR_SUPPLY_25PERCENT_RANGE)
                  num3 -= 250;
                if (this.friendlySupplyIdeal.Value[index3, y] > this.ai.VAR_SUPPLY_50PERCENT_RANGE)
                  num3 -= 110;
                if (this.friendlySupplyIdeal.Value[index3, y] > this.ai.VAR_SUPPLY_75PERCENT_RANGE)
                  num3 -= 40;
              }
              else
              {
                int num8 = this.HexAttackOpportunity(index3, y) + this.FriendlyBottleneckIdealOwnFrontOnly.Value[index3, y] * 200;
                if (this.map.HexObj[this.GetRealX(index3), y + this.Top].get_BattleStack(this.ai.game.Data.Turn) > 0)
                  num8 = (int) Math.Round((double) num8 / Math.Sqrt((double) this.map.HexObj[this.GetRealX(index3), y + this.Top].get_BattleStack(this.ai.game.Data.Turn)));
                int num9 = 0;
                int counter = this.front.units.counter;
label_57:
                for (int index8 = 0; index8 <= counter; index8 += 1)
                {
                  index4 = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index8]);
                  if (index4 > -1)
                  {
                    int index9 = 0;
                    while (this.ai.game.HandyFunctionsObj.GetLowestAp(index4) < this.MoveCostAttack[index8, index9].Value[index3, y])
                    {
                      if (this.ai.game.HandyFunctionsObj.GetLowestAp(index4) >= this.MoveCostMove[index8].Value[index3, y])
                      {
                        num9 += 1;
                        goto label_57;
                      }
                      else
                      {
                        index9 += 1;
                        if (index9 > 5)
                          goto label_57;
                      }
                    }
                    num9 += 1;
                  }
                }
                num3 = num9 <= 0 ? -9999999 : (int) Math.Round((double) (num8 * num9) / 2.0);
              }
            }
            else
              num3 = -9999999;
            if (this.ai.map.HexObj[this.GetRealX(index3), y + this.Top].Location > -1 | this.ai.map.HexObj[this.GetRealX(index3), y + this.Top].UnitCounter > -1 && this.ai.CustomCalls.TargetRegimeRelationIsActuallyNotWar(this.ai.game.Data.Turn, this.ai.map.HexObj[this.GetRealX(index3), y + this.Top].Regime, false))
              num3 = -9999999;
            if (num3 > num2 && !passList.Exists(index3, y, 1) && !tempPassList.Exists(index3, y, 1) && !tryPassList.Exists(index3, y, 1))
            {
              num2 = num3;
              if (ignoreFirstXhexes < 1)
              {
                index1 = index3;
                index2 = y;
              }
              else
                --ignoreFirstXhexes;
            }
          }
        }
      }
      int counter1;
      int counter2;
      int counter3;
      if (num2 > -1 & index1 > -1)
      {
        int num10;
        if (24 == index1 + this.Left & 16 == index2 + this.Top)
          num10 = index3;
        int num11 = 1;
        do
        {
          bool flag1 = false;
          int num12 = 0;
          int tfacing = 1;
          do
          {
            Coordinate coordinate = this.ai.game.HandyFunctionsObj.HexNeighbour(index1, index2, 0, tfacing);
            if (coordinate.onmap & coordinate.x <= this.Width & coordinate.y <= this.Height && this.Owner.Value[index1, index2] == this.Owner.Value[coordinate.x, coordinate.y])
              num12 += 1;
            tfacing += 1;
          }
          while (tfacing <= 6);
          if (num12 == 0 && this.ai.enemySupplyMatrix.Value[this.GetRealX(index1), index2 + this.Top] < this.ai.VAR_SUPPLY_25PERCENT_RANGE)
          {
            flag1 = true;
            if (this.ai.VAR_SIEGE_SIMULATION && this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index1), index2 + this.Top].Location > -1 && this.ai.game.HandyFunctionsObj.IsHexNextToSea(this.GetRealX(index1), index2 + this.Top, 0))
            {
              int unitCounter = this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index1), index2 + this.Top].UnitCounter;
              for (int index10 = 0; index10 <= unitCounter; index10 += 1)
              {
                int unit = this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index1), index2 + this.Top].UnitList[index10];
                int sfCount = this.ai.game.Data.UnitObj[unit].SFCount;
                for (int index11 = 0; index11 <= sfCount; index11 += 1)
                {
                  int sf = this.ai.game.Data.UnitObj[unit].SFList[index11];
                  if (this.ai.game.Data.SFObj[sf].CurrentEntrench > this.ai.VAR_SIEGE_SIMULATION_MAX_ENTR)
                    this.ai.game.Data.SFObj[sf].CurrentEntrench = this.ai.VAR_SIEGE_SIMULATION_MAX_ENTR;
                }
              }
            }
          }
          if (this.enemySupply.Value[index1, index2] < 999)
            num2 += 100;
          this.triedX = index1;
          this.triedY = index2;
          float num13 = 10f;
          float currentMinimal = 2.75f;
          if (this.front.Stance == 2)
          {
            float num14 = 3.75f;
            currentMinimal = (double) this.front.AverageStrength <= 2.25 ? ((double) this.front.AverageStrength <= 2.1 ? ((double) this.front.AverageStrength <= 1.9 ? ((double) this.front.AverageStrength <= 1.75 ? num14 + 1.25f : num14 + 1f) : num14 + 0.75f) : num14 + 0.5f) : num14 + 0.25f;
          }
          if (this.front.Stance == 3)
          {
            float num15 = 3.25f;
            currentMinimal = (double) this.front.AverageStrength <= 3.25 ? ((double) this.front.AverageStrength <= 3.1 ? ((double) this.front.AverageStrength <= 2.9 ? ((double) this.front.AverageStrength <= 2.75 ? num15 + 0.6f : num15 + 0.45f) : num15 + 0.3f) : num15 + 0.15f) : num15 - 0.0f;
          }
          switch (num11)
          {
            case 2:
              num13 *= 2f;
              currentMinimal *= 1.66f;
              break;
            case 3:
              num13 *= 3f;
              currentMinimal *= 2f;
              break;
          }
          if ((double) this.front.UnitCountRatio >= 0.33 && (double) this.front.UnitCountRatio >= 0.66 && (double) this.front.UnitCountRatio >= 1.33)
          {
            if ((double) this.front.UnitCountRatio < 1.6 & this.front.Stance == 3)
            {
              num13 *= 1.2f;
              currentMinimal *= 0.95f;
            }
            else if ((double) this.front.UnitCountRatio < 2.1 & this.front.Stance == 3)
            {
              num13 *= 1.3f;
              currentMinimal *= 0.9f;
            }
            else if ((double) this.front.UnitCountRatio < 3.2 & this.front.Stance == 3)
            {
              num13 *= 1.4f;
              currentMinimal *= 0.85f;
            }
            else if ((double) this.front.UnitCountRatio < 5.0 & this.front.Stance == 3)
            {
              num13 *= 1.5f;
              currentMinimal *= 0.8f;
            }
            else if (this.front.Stance == 3)
            {
              num13 *= 1.75f;
              currentMinimal *= 0.7f;
            }
          }
          if (this.front.Stance != 3 && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.GetRealX(index1), index2 + this.Top].LandscapeType].TempDefenseBonus > 0)
            currentMinimal += currentMinimal * ((float) Math.Max(this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.GetRealX(index1), index2 + this.Top].LandscapeType].TempDefenseBonus - 50, 0) / 200f);
          if (this.front.Stance == 3)
          {
            float num16 = num13 + (float) ((double) num13 * 0.1 * ((double) this.FriendlyBottleneckIdealOwnFrontOnly.Value[index1, index2] / 30.0));
            float num17 = currentMinimal - (float) ((double) currentMinimal * 0.4 * ((double) this.FriendlyBottleneckIdealOwnFrontOnly.Value[index1, index2] / 100.0));
            num13 = num16 + (float) ((double) num16 * 0.1 * ((double) this.FriendlyBottleneckIdeal.Value[index1, index2] / 30.0));
            currentMinimal = num17 - (float) ((double) num17 * 0.3 * ((double) this.FriendlyBottleneckIdeal.Value[index1, index2] / 50.0));
          }
          if (forEncircled)
            currentMinimal /= 4f;
          if ((double) currentMinimal < 0.5)
            currentMinimal = 0.5f;
          if (flag1)
          {
            currentMinimal = 1.5f;
            num13 = 16f;
          }
          if ((double) this.ai.VAR_MODIFY_MINIMUM_ATTACK > 0.0)
            currentMinimal *= this.ai.VAR_MODIFY_MINIMUM_ATTACK;
          if (this.ai.CustomCalls.HasCustumCalls())
            currentMinimal *= this.ai.CustomCalls.CustomRuleTheater_MinimalAttackModifier(this.GetRealX(index1), index2 + this.Top, currentMinimal);
          if (this.ai.VAR_STRENGTH_MOD_IS_ALSO_COMBAT_ADV_MOD && this.ai.VAR_MATRIX_STRENGTH.Value[this.GetRealX(index1), index2 + this.Top] != 100)
            currentMinimal = (float) ((double) currentMinimal * (double) this.ai.VAR_MATRIX_STRENGTH.Value[this.GetRealX(index1), index2 + this.Top] / 100.0);
          if (this.front.OffensiveZone > 0)
          {
            if (this.ai.VAR_OFFENSIVE_ZONE_IS_ALL_OUT_MODE == 1)
            {
              currentMinimal *= 0.85f;
              num13 *= 1.5f;
            }
            else if (this.ai.VAR_OFFENSIVE_ZONE_IS_ALL_OUT_MODE == 2)
            {
              currentMinimal *= 0.7f;
              num13 *= 2f;
            }
          }
          if ((double) num13 <= (double) currentMinimal + 2.0)
            num13 = currentMinimal + 2f;
          UnitList UL = UnitList::new();
          SimpleList simpleList1 = SimpleList::new();
          SimpleList simpleList2 = SimpleList::new();
          SimpleList simpleList3 = SimpleList::new();
          int num18 = this.troopsstrength.Value[index1, index2];
          int[,] numArray1 = new int[this.Width + 1, this.Height + 1];
          int[,] numArray2 = new int[this.Width + 1, this.Height + 1];
          int num19 = 0;
          float num20 = 0.0f;
          int val2 = 0;
          int num21 = 0;
          int num22 = 0;
          int num23 = 0;
          int num24 = 0;
          int num25 = 0;
          float num26 = 0.0f;
          if (index1 == 12 & index2 == 5)
            index1 = index1;
          int unitCounter1 = this.ai.map.HexObj[this.GetRealX(index1), index2 + this.Top].UnitCounter;
          for (int index12 = 0; index12 <= unitCounter1; index12 += 1)
          {
            index4 = this.ai.map.HexObj[this.GetRealX(index1), index2 + this.Top].UnitList[index12];
            int tempUnitPowerAbs = this.ai.game.Data.UnitObj[index4].TempUnitPowerAbs;
            int num27 = (int) Math.Round((double) tempUnitPowerAbs * 0.1) + (int) Math.Round((double) tempUnitPowerAbs * 0.9 * (double) this.ai.game.Data.UnitObj[index4].SupplyConsume / 100.0);
            int num28 = (int) Math.Round((double) num27 * 1.0) + (int) Math.Round((double) (num27 * 1 * this.ai.game.HandyFunctionsObj.GetAverageXp(index4)) / 60.0);
            int num29 = this.front.FrontType != 12 ? (this.front.Stance != 3 ? num28 + (int) Math.Round((double) (num28 * this.ai.game.HandyFunctionsObj.GetAverageEntrench(index4)) / 200.0) : num28 + (int) Math.Round((double) (num28 * this.ai.game.HandyFunctionsObj.GetAverageEntrench(index4)) / 300.0)) : num28;
            int num30 = (int) Math.Round((double) num29 * 0.5 + (double) num29 * 0.5 * (double) this.ai.game.HandyFunctionsObj.GetAverageRdn(index4) / 100.0);
            num12 = (int) Math.Round((double) num30 * 0.1 + (double) num30 * 0.9 * (double) (this.GetAverageDefensiveMod2(index4) + 100) / 100.0);
            if (!this.ai.game.Data.UnitObj[index4].IsHQ & this.ai.game.Data.UnitObj[index4].HQ > -1 && !this.ai.game.Data.UnitObj[index4].IsHQ & this.ai.game.Data.UnitObj[index4].HQ > -1)
              num12 += (int) Math.Round((double) (num12 * this.ai.game.HandyFunctionsObj.GetRealHqCombatImprovementPercentage(this.ai.game.Data.UnitObj[index4].HQ)) / 100.0 * ((double) this.ai.game.HandyFunctionsObj.Gethqpow(index4) / 100.0));
            if (!this.ai.game.HandyFunctionsObj.HasUnitlandSF(index4))
              num12 = 0;
            val2 += num12;
            num21 += this.ai.game.HandyFunctionsObj.GetUnitStackPts(index4);
            int sfCount = this.ai.game.Data.UnitObj[index4].SFCount;
            for (int index13 = 0; index13 <= sfCount; index13 += 1)
            {
              int sf = this.ai.game.Data.UnitObj[index4].SFList[index13];
              num23 += this.ai.game.Data.SFObj[sf].Qty;
              num22 += this.ai.game.Data.SFObj[sf].Qty * this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].Attacks;
            }
          }
          if (num21 > this.ai.VAR_HEX_STACK_REGULAR)
          {
            val2 = (int) Math.Round((double) (val2 * this.ai.VAR_HEX_STACK_REGULAR) / (double) num21);
            currentMinimal = currentMinimal * 0.6f + currentMinimal * 0.4f * (float) this.ai.VAR_HEX_STACK_REGULAR / (float) num21;
          }
          int num31 = this.ai.map.HexObj[this.GetRealX(index1), index2 + this.Top].get_BattleStack(this.ai.game.Data.Turn);
          bool flag2;
          int index14;
          Coordinate coordinate3;
          int index15;
          int tdata2_1;
          float concentricBonus2Prognosis1;
          do
          {
            flag2 = false;
            int num32 = 99999;
            int counter4 = this.front.units.counter;
            int index16;
            int index17;
            int num33;
            for (index14 = 0; index14 <= counter4; index14 += 1)
            {
              index4 = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index14]);
              if (index4 > -1 && !UL.CheckIfPresent(index4))
              {
                int tdata2_2 = 0;
                do
                {
                  if (!(this.ai.game.Data.UnitObj[index4].TempCategory == 5 | this.ai.game.Data.UnitObj[index4].TempCategory == 2) & this.ai.game.HandyFunctionsObj.GetLowestAp(index4) >= this.MoveCostAttack[index14, tdata2_2].Value[index1, index2] && !(this.ai.game.Data.UnitObj[index4].TempProtector & val2 <= 1))
                  {
                    int num34 = 20 + this.MoveCostAttack[index14, tdata2_2].Value[index1, index2] - 16 * this.CountUnitsWithSameHistoricalPresent(this.ai.game.Data.UnitObj[index4].Historical, UL);
                    if (this.enemyDistance.Value[index16, index17] > 1)
                      num34 = (int) Math.Round((double) num34 / (double) this.enemyDistance.Value[index16, index17]);
                    int num35 = (int) Math.Round((double) (int) Math.Round((double) (int) Math.Round((double) num34 / ((double) this.ai.game.HandyFunctionsObj.GetAverageRdn(index4) / 100.0)) / ((double) this.ai.game.HandyFunctionsObj.GetAverageRdn(index4) / 100.0)) / ((double) this.ai.game.Data.UnitObj[index4].SupplyConsume / 100.0));
                    int num36 = (int) Math.Round((double) num35 * 0.1 + (double) num35 * 0.9 * ((double) (100 + this.GetAverageOffensiveMod2(index4)) / 100.0));
                    Coordinate coordinate4 = this.ai.game.HandyFunctionsObj.HexNeighbour(index1, index2, 0, tdata2_2 + 1);
                    if (coordinate4.onmap & coordinate4.x <= this.Width & coordinate4.y <= this.Height)
                      num36 = (int) Math.Round((double) num36 / ((double) Math.Max(20, Math.Min(50, this.ai.game.HandyFunctionsObj.GetLowestAp(index4) - this.MoveCostMove[index14].Value[coordinate4.x, coordinate4.y])) / 50.0));
                    if (this.ai.game.Data.UnitObj[index4].TempProtector)
                      num36 = (int) Math.Round((double) num36 / 20.0);
                    float num37 = 0.0f;
                    int num38 = 0;
                    int sfCount = this.ai.game.Data.UnitObj[index4].SFCount;
                    for (int index18 = 0; index18 <= sfCount; index18 += 1)
                    {
                      num37 += this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[this.ai.game.Data.UnitObj[index4].SFList[index18]].Type].CombatModAtt[this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index1), index2 + this.Top].LandscapeType] * (float) this.ai.game.Data.SFObj[this.ai.game.Data.UnitObj[index4].SFList[index18]].Qty * (float) this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[this.ai.game.Data.UnitObj[index4].SFList[index18]].Type].PowerPts;
                      num38 += this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[this.ai.game.Data.UnitObj[index4].SFList[index18]].Type].PowerPts * this.ai.game.Data.SFObj[this.ai.game.Data.UnitObj[index4].SFList[index18]].Qty;
                    }
                    float num39 = (float) Math.Pow((double) (1f / (num37 / (float) num38)), 2.0);
                    int num40 = (int) Math.Round((double) ((float) num36 * num39));
                    if ((double) num39 <= 1.0)
                      num40 -= (int) Math.Round((double) (100f * this.UnitOffensiveModifier(index4)));
                    this.ai.game.EditObj.TempUnitList = UnitList::new();
                    int counter5 = UL.counter;
                    for (int index19 = 0; index19 <= counter5; index19 += 1)
                      this.ai.game.EditObj.TempUnitList.add(UL.unr[index19], tdata2: UL.data2[index19]);
                    this.ai.game.EditObj.TargetX = this.GetRealX(index1);
                    this.ai.game.EditObj.TargetY = index2 + this.Top;
                    this.ai.game.EditObj.OrderX = this.GetRealX(index1);
                    this.ai.game.EditObj.OrderY = index2 + this.Top;
                    float concentricBonus2Prognosis2 = this.ai.game.HandyFunctionsObj.GetConcentricBonus2Prognosis(true, true);
                    this.ai.game.EditObj.TempUnitList.add(index4, tdata2: tdata2_2);
                    float concentricBonus2Prognosis3 = this.ai.game.HandyFunctionsObj.GetConcentricBonus2Prognosis(true, true);
                    this.ai.game.EditObj.TempUnitList = UnitList::new();
                    if ((double) concentricBonus2Prognosis3 > (double) concentricBonus2Prognosis2)
                      num40 -= (int) Math.Round((double) ((float) num40 * (Math.Min(90f, (float) (((double) concentricBonus2Prognosis3 - (double) concentricBonus2Prognosis2) * 100.0)) / 50f)));
                    if (this.ai.VAR_TOPUNIT_STIMULUS > 0)
                    {
                      int tempType = this.ai.game.Data.UnitObj[index4].TempType;
                      if (tempType > -1 & this.ai.game.Data.UnitObj[index4].TempTopUnit)
                      {
                        int moveType = this.ai.game.Data.SFTypeObj[tempType].MoveType;
                        if (this.ai.game.Data.LandscapeTypeObj[this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index1), index2 + this.Top].LandscapeType].MoveCost[moveType] <= 33)
                        {
                          num40 = (int) Math.Round((double) num40 / 2.0);
                          if (this.ai.VAR_TOPUNIT_STIMULUS >= 200)
                            num40 = (int) Math.Round((double) ((float) num40 / 3f));
                          else if (this.ai.VAR_TOPUNIT_STIMULUS >= 150)
                            num40 = (int) Math.Round((double) ((float) num40 / 2.5f));
                          else if (this.ai.VAR_TOPUNIT_STIMULUS >= 100)
                            num40 = (int) Math.Round((double) ((float) num40 / 2f));
                          else if (this.ai.VAR_TOPUNIT_STIMULUS >= 50)
                            num40 = (int) Math.Round((double) ((float) num40 / 1.5f));
                        }
                      }
                    }
                    if (!forEncircled & this.front.FrontType != 12)
                    {
                      if (val2 > (int) Math.Round((double) this.ai.game.Data.UnitObj[index4].TempUnitPower / 3.0))
                      {
                        if (new Random(this.ai.game.Data.GameID + this.front.FrontID + this.ai.game.Data.Round).Next(0, 100) < 50)
                        {
                          if (this.ai.game.HandyFunctionsObj.GetAverageRdn(index4) < 60 & this.front.Stance == 3)
                            num40 = 99999999;
                        }
                        else if (this.ai.game.HandyFunctionsObj.GetAverageRdn(index4) < 80 & this.front.Stance == 3)
                          num40 = 99999999;
                      }
                      else if (this.ai.game.HandyFunctionsObj.GetAverageRdn(index4) < 40 & this.front.Stance == 3 && val2 > (int) Math.Round((double) this.ai.game.Data.UnitObj[index4].TempUnitPower / 15.0))
                        num40 = 99999999;
                      if ((double) this.ai.game.Data.RuleVar[434] > 0.0)
                      {
                        if (this.GetAverageOffensiveMod2(index4) < -50)
                          num40 = 99999999;
                        else if (this.GetAverageOffensiveMod2(index4) < -25)
                          num40 = 99999999;
                        else if (this.GetAverageOffensiveMod2(index4) < -5)
                          num40 = 99999999;
                      }
                      if (this.ai.game.HandyFunctionsObj.GetAverageRdn(index4) < 75 & this.front.Stance == 2 && val2 > (int) Math.Round((double) this.ai.game.Data.UnitObj[index4].TempUnitPower / 6.0))
                        num40 = 99999999;
                      if (this.ai.game.HandyFunctionsObj.GetAverageRdn(index4) < 80 & flag1 && val2 > (int) Math.Round((double) this.ai.game.Data.UnitObj[index4].TempUnitPower / 6.0))
                        num40 = 99999999;
                    }
                    if (num40 < num32)
                    {
                      bool flag3 = false;
                      index16 = this.GetMatrixX(this.ai.game.Data.UnitObj[index4].X);
                      index17 = this.ai.game.Data.UnitObj[index4].Y - this.Top;
                      int unr = index4;
                      coordinate3 = this.MoveFromAttack[index14, tdata2_2].Value[index1, index2];
                      if (coordinate3.y + this.Top <= this.ai.game.Data.MapObj[0].MapHeight & coordinate3.x <= this.Width)
                      {
                        if (this.ai.game.HandyFunctionsObj.HexFacing(index1, index2, 0, index16, index17, 0) == -1 | this.map.HexObj[this.GetRealX(index1), index2 + this.Top].UnitCounter == -1)
                        {
                          if (index1 == 13 & index2 == 19)
                            index1 = index1;
                          int num41 = this.HexDefendedScore(index16, index17, -1, index4, numArray1[index16, index17], 0, true) - this.HexDefendImportance(index16, index17) + stimulateAttack;
                          if (num41 > 300)
                            num41 = 300 + (int) Math.Round(Math.Sqrt((double) (num41 - 300)) * 3.0);
                          int num42 = this.HexAttackImportance(index1, index2);
                          int num43 = this.ai.game.HandyFunctionsObj.GetHexStackPts(this.GetRealX(coordinate3.x), coordinate3.y + this.Top, 0) + numArray2[coordinate3.x, coordinate3.y] + this.ai.game.HandyFunctionsObj.GetUnitStackPts(unr);
                          if (this.IsLastUnit(index4, this.front) & this.ForceRatio.Value[index16, index17] > 0 & this.ForceRatio.Value[index16, index17] < 600 && this.FrontArea.Value[index16, index17] == this.front.FrontID)
                          {
                            if (this.front.FrontType == 1)
                              num41 -= Math.Abs((int) Math.Round((double) num42 / 3.0));
                            else
                              num41 -= Math.Abs((int) Math.Round((double) num42 / 2.0));
                          }
                          if (numArray1[index16, index17] > 0)
                            index16 = index16;
                          if (num42 > 200)
                            index16 = index16;
                          if ((double) num43 > (double) this.ai.VAR_HEX_STACK_REGULAR * 0.66)
                            num41 = (int) Math.Round((double) num41 * ((double) this.ai.VAR_HEX_STACK_REGULAR * 0.66 / (double) num43));
                          if (this.enemyDistance.Value[index16, index17] == 1)
                          {
                            if (num41 >= 150 - num42)
                              flag3 = true;
                          }
                          else if (num41 >= 100 - num42)
                            flag3 = true;
                        }
                        else
                          flag3 = true;
                        if (forEncircled)
                          flag3 = true;
                        if (!forEncircled && this.friendlySupplyIdeal.Value[index1, index2] < 999 && this.friendlySupplyIdeal.Value[coordinate3.x, coordinate3.y] > this.ai.VAR_SUPPLY_75PERCENT_RANGE && (double) this.ai.game.Data.UnitObj[index4].SupplyIn < (double) this.ai.game.Data.UnitObj[index4].SupplyInReq * 0.6)
                          flag3 = false;
                        if (flag3)
                        {
                          if (this.ai.game.Data.UnitObj[index4].TempTopUnit)
                          {
                            num40 += (int) Math.Round((double) num40 * ((double) this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.GetRealX(index1), index2 + this.Top].LandscapeType].TempDefenseBonus / 100.0));
                            if (this.MoveFromAttack[index14, tdata2_2].Value[index1, index2].onmap)
                            {
                              int num44 = this.ai.game.HandyFunctionsObj.HexFacing(this.GetRealX(index1), index2 + this.Top, 0, this.GetRealX(this.MoveFromAttack[index14, tdata2_2].Value[index1, index2].x), this.MoveFromAttack[index14, tdata2_2].Value[index1, index2].y + this.Top, 0);
                              int index20 = this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index1), index2 + this.Top].RiverType[num44 - 1];
                              if (index20 > -1)
                                num40 += (int) Math.Round((double) num40 * ((double) this.ai.game.Data.RiverTypeObj[index20].TempDefenseBonus / 100.0));
                            }
                          }
                          else if ((double) this.UnitOffensiveModifier(index4) > 0.0)
                          {
                            num40 += (int) Math.Round((double) num40 * (double) this.UnitOffensiveModifier(index4) * ((double) this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.GetRealX(index1), index2 + this.Top].LandscapeType].TempDefenseBonus / 100.0));
                            if (this.MoveFromAttack[index14, tdata2_2].Value[index1, index2].onmap)
                            {
                              int num45 = this.ai.game.HandyFunctionsObj.HexFacing(index1, index2, 0, this.MoveFromAttack[index14, tdata2_2].Value[index1, index2].x, this.MoveFromAttack[index14, tdata2_2].Value[index1, index2].y, 0);
                              int index21 = this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index1), index2 + this.Top].RiverType[num45 - 1];
                              if (index21 > -1)
                                num40 += (int) Math.Round((double) num40 * (double) this.UnitOffensiveModifier(index4) * ((double) this.ai.game.Data.RiverTypeObj[index21].TempDefenseBonus / 100.0));
                            }
                          }
                          if (num40 < num32)
                          {
                            num32 = num40;
                            num33 = index4;
                            coordinate3 = this.MoveFromAttack[index14, tdata2_2].Value[index1, index2];
                            index15 = index14;
                            tdata2_1 = tdata2_2;
                          }
                        }
                      }
                    }
                  }
                  tdata2_2 += 1;
                }
                while (tdata2_2 <= 5);
              }
            }
            if (num32 < 9999)
            {
              int index22 = num33;
              UL.add(index22, index15, tdata2_1);
              int sfCount = this.ai.game.Data.UnitObj[index22].SFCount;
              for (int index23 = 0; index23 <= sfCount; index23 += 1)
              {
                int sf = this.ai.game.Data.UnitObj[index22].SFList[index23];
                num24 += this.ai.game.Data.SFObj[sf].Qty;
              }
              index16 = this.GetMatrixX(this.ai.game.Data.UnitObj[index22].X);
              index17 = this.ai.game.Data.UnitObj[index22].Y - this.Top;
              if (!(this.GetMatrixX(coordinate3.x) == index16 & coordinate3.y + this.Top == index17))
              {
                int[,] numArray3 = numArray1;
                int[,] numArray4 = numArray3;
                int index24 = index16;
                int index25 = index24;
                int index26 = index17;
                int index27 = index26;
                int num46 = numArray3[index24, index26] + this.ai.game.Data.UnitObj[index22].TempUnitPower;
                numArray4[index25, index27] = num46;
                int[,] numArray5 = numArray2;
                int[,] numArray6 = numArray5;
                int x = coordinate3.x;
                int index28 = x;
                int y = coordinate3.y;
                int index29 = y;
                int num47 = numArray5[x, y] + this.ai.game.HandyFunctionsObj.GetUnitStackPts(index22);
                numArray6[index28, index29] = num47;
                this.ai.game.Data.UnitObj[index22].TempX = this.GetRealX(this.MoveFromAttack[index15, tdata2_1].Value[index1, index2].x);
                this.ai.game.Data.UnitObj[index22].TempY = this.MoveFromAttack[index15, tdata2_1].Value[index1, index2].y + this.Top;
              }
              else
              {
                this.ai.game.Data.UnitObj[index22].TempX = this.ai.game.Data.UnitObj[index22].X;
                this.ai.game.Data.UnitObj[index22].TempY = this.ai.game.Data.UnitObj[index22].Y;
              }
              int tempUnitPowerAbs = this.ai.game.Data.UnitObj[index22].TempUnitPowerAbs;
              if (this.ai.VAR_TOPUNIT_STIMULUS > 0)
              {
                int tempType = this.ai.game.Data.UnitObj[index22].TempType;
                if (tempType > -1 & this.ai.game.Data.UnitObj[index22].TempTopUnit)
                {
                  int moveType = this.ai.game.Data.SFTypeObj[tempType].MoveType;
                  if (this.ai.game.Data.LandscapeTypeObj[this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index1), index2 + this.Top].LandscapeType].MoveCost[moveType] <= 33)
                    tempUnitPowerAbs += (int) Math.Round((double) (tempUnitPowerAbs * this.ai.VAR_TOPUNIT_STIMULUS) / 100.0);
                }
              }
              int num48 = (int) Math.Round((double) ((float) tempUnitPowerAbs * this.ai.GetCombatMatrixModifierVersusHex(index22, this.GetRealX(index1), index2 + this.Top)));
              if (!this.ai.game.Data.UnitObj[index22].IsHQ & this.ai.game.Data.UnitObj[index22].HQ > -1)
                num48 += (int) Math.Round((double) (num48 * this.ai.game.HandyFunctionsObj.GetRealHqCombatImprovementPercentage(this.ai.game.Data.UnitObj[index22].HQ)) / 100.0 * ((double) this.ai.game.HandyFunctionsObj.Gethqpow(index22) / 100.0));
              int num49 = 1 * num48 + (int) Math.Round((double) num48 * ((double) this.ai.game.HandyFunctionsObj.GetAverageXp(index22) / 60.0));
              int num50 = (int) Math.Round((double) num49 * 0.1 + (double) num49 * 0.9 * ((double) this.ai.game.HandyFunctionsObj.GetAverageRdn(index22) / 100.0));
              int num51 = (int) Math.Round((double) num50 * 0.3 + (double) num50 * 0.7 * ((double) this.ai.game.HandyFunctionsObj.GetAverageRdn(index22) / 100.0));
              int num52 = (int) Math.Round((double) num51 * 0.1 + (double) num51 * 0.9 * ((double) (100 + this.GetAverageOffensiveMod2(index22)) / 100.0));
              int num53 = num19 + num52;
              int num54 = this.ai.game.HandyFunctionsObj.GetLowestAp(index22) - this.MoveCostAttack[index15, tdata2_1].Value[index1, index2];
              Coordinate coordinate5 = this.MoveFromAttack[index15, tdata2_1].Value[index1, index2];
              int num55 = this.ai.game.HandyFunctionsObj.MoveApCostPreview(index22, this.GetRealX(coordinate5.x), coordinate5.y + this.Top, this.GetRealX(coordinate5.x), coordinate5.y + this.Top, 0, this.GetRealX(index1), index2 + this.Top, 0, true).x;
              if (num55 > 80)
                num55 = 80;
              num12 = num54 + num55;
              if (num12 < 30)
                num52 = (int) Math.Round((double) num52 * 0.2);
              else if (num12 < 40)
                num52 = (int) Math.Round((double) num52 * 0.4);
              else if (num12 < 50)
                num52 = (int) Math.Round((double) num52 * 0.7);
              else if (num12 < 60)
                num52 = (int) Math.Round((double) num52 * 0.9);
              int num56 = num25 + num52;
              if ((double) this.UnitOffensiveModifier(index22) > 0.0)
                index16 = index16;
              if ((double) this.UnitOffensiveModifier(index22) < 0.0)
                index16 = index16;
              num25 = num56 + (int) Math.Round((double) num52 * 0.75 * (double) this.UnitOffensiveModifier(index22));
              num19 = num53 + (int) Math.Round((double) num52 * 0.75 * (double) this.UnitOffensiveModifier(index22));
              num26 = (float) num25 / (float) Math.Max(0.25, (double) val2);
              num20 = (float) num19 / (float) Math.Max(0.25, (double) val2);
              num31 += this.ai.game.HandyFunctionsObj.GetUnitStackPts(index22);
              flag2 = true;
            }
            this.ai.game.EditObj.TempUnitList = UnitList::new();
            int counter6 = UL.counter;
            for (int index30 = 0; index30 <= counter6; index30 += 1)
              this.ai.game.EditObj.TempUnitList.add(UL.unr[index30], tdata2: UL.data2[index30]);
            this.ai.game.EditObj.TargetX = this.GetRealX(index1);
            this.ai.game.EditObj.TargetY = index2 + this.Top;
            this.ai.game.EditObj.OrderX = this.GetRealX(index1);
            this.ai.game.EditObj.OrderY = index2 + this.Top;
            concentricBonus2Prognosis1 = this.ai.game.HandyFunctionsObj.GetConcentricBonus2Prognosis(false, true);
            int num57 = this.ai.game.HandyFunctionsObj.maxAttackStackPrognosis(true);
            if (flag1)
              num57 *= 2;
            this.ai.game.EditObj.TempUnitList = UnitList::new();
            if ((double) concentricBonus2Prognosis1 * (double) num26 >= (double) num13)
            {
              if (val2 > 0)
                ;
              flag2 = false;
            }
            if (!forEncircled & (double) this.front.UnitCountRatio > 0.0)
            {
              if (this.front.OffensiveZone > 0 & this.ai.VAR_OFFENSIVE_ZONE_IS_ALL_OUT_MODE > 0)
              {
                if (this.ai.VAR_OFFENSIVE_ZONE_IS_ALL_OUT_MODE == 2 & (double) num31 > (double) num57 * 1.4 * Math.Max(1.0, Math.Sqrt(1.0 / (double) this.front.UnitCountRatio)))
                  flag2 = false;
                if (this.ai.VAR_OFFENSIVE_ZONE_IS_ALL_OUT_MODE == 1 & (double) num31 > (double) num57 * 1.15 * Math.Max(1.0, Math.Sqrt(1.0 / (double) this.front.UnitCountRatio)))
                  flag2 = false;
              }
              else if ((double) num31 > (double) (num57 * 1) * Math.Max(1.0, Math.Sqrt((double) this.front.UnitCountRatio / 1.0)))
                flag2 = false;
            }
          }
          while (flag2);
          int num58;
          int num59;
          if (val2 > 0)
          {
            int counter7 = this.front.artUnits.counter;
            for (int index31 = 0; index31 <= counter7; index31 += 1)
            {
              index4 = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.artUnits.AIid[index31]);
              int num60 = 2;
              if (this.ai.game.Data.Product >= 6 & index4 > -1)
                num60 = this.ai.game.HandyFunctionsObj.GetMaxArtRange(index4, 0);
              if (this.ai.game.Data.UnitObj[index4].TempLisItemPercentage < 75)
                num60 = 0;
              if (index4 > -1 & num60 > 0 & num60 < 15 && simpleList1.FindNr(index4) == -1)
              {
                int num61 = num60;
                if (num60 > 4)
                  num61 = 4;
                int tweight = 9999;
                int num62 = index1 - (num60 + 1);
                int num63 = index1 + (num60 + 1);
                int tdata1;
                int tdata2_3;
                for (int index32 = num62; index32 <= num63; index32 += 1)
                {
                  int num64 = index2 - (num60 + 1);
                  int num65 = index2 + (num60 + 1);
                  for (int y2 = num64; y2 <= num65; y2 += 1)
                  {
                    if (index32 >= 0 & y2 >= 0 & index32 <= this.Width & y2 <= this.Height && this.MoveCostArtMove[index31].Value[index32, y2] < this.ai.game.HandyFunctionsObj.GetLowestAp(index4) - 10 && this.MoveCostArtMove[index31].Value[index32, y2] * 2 < tweight && this.ai.game.HandyFunctionsObj.Distance(index1, index2, 0, index32, y2, 0) <= num60)
                    {
                      bool flag4 = false;
                      if (this.enemyDistance.Value[index32, y2] > num61 - 1)
                        flag4 = true;
                      if (flag4)
                      {
                        num12 = this.MoveCostArtMove[index31].Value[index32, y2];
                        if (this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index32), y2 + this.Top].UnitCounter == -1)
                          num12 *= 2;
                        else if (this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index32), y2 + this.Top].UnitCounter == 0)
                          num12 *= 1;
                        else if (this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index32), y2 + this.Top].UnitCounter == 1)
                          num12 = (int) Math.Round((double) num12 * 0.66);
                        else if (this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index32), y2 + this.Top].UnitCounter >= 2)
                          num12 = (int) Math.Round((double) num12 * 0.5);
                        if (num12 < tweight)
                        {
                          tweight = num12;
                          tdata1 = index32;
                          tdata2_3 = y2;
                          num58 = index4;
                          coordinate3 = this.MoveFromArtMove[index31].Value[index1, index2];
                          index15 = index31;
                        }
                      }
                    }
                  }
                }
                if (tweight < 9999)
                  simpleList1.Add(index4, tweight, tdata1, tdata2_3);
              }
            }
            simpleList1.Sort();
            bool flag5 = false;
            int counter8 = simpleList1.Counter;
            for (index14 = 0; index14 <= counter8; index14 += 1)
            {
              index4 = simpleList1.Id[index14];
              num59 += this.ai.game.Data.UnitObj[index4].TempUnitPower;
              if ((double) num59 > (double) (val2 + 10) * Math.Sqrt((double) (simpleList1.Counter + 1)) / 3.0)
                flag5 = true;
              if ((double) num59 > (double) num25 * Math.Sqrt((double) (simpleList1.Counter + 1)) / 2.0)
                flag5 = true;
              if ((double) index14 > (double) UL.counter * Math.Sqrt((double) (simpleList1.Counter + 1)))
                flag5 = true;
              if (flag5)
              {
                int counter9 = simpleList1.Counter;
                int num66 = index14 + 1;
                for (int nr = counter9; nr >= num66; nr += -1)
                  simpleList1.RemoveNr(nr);
                break;
              }
            }
            if (num59 > 0)
            {
              num26 = (float) (num25 + num59 * 2) / (float) Math.Max(0.1, (double) val2);
              num20 = (float) (num19 + num59 * 2) / (float) Math.Max(0.1, (double) val2);
            }
          }
          int num67 = 0;
          if (index1 + this.Left == 22 & index2 + this.Top == 8)
            num12 = num12;
          if ((double) num26 > 0.0 & val2 > 0 & UL.counter > -1)
          {
            int counter10 = this.front.artUnits.counter;
            for (int index33 = 0; index33 <= counter10; index33 += 1)
            {
              index4 = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.artUnits.AIid[index33]);
              int maxArtRange = this.ai.game.HandyFunctionsObj.GetMaxArtRange(index4, 0);
              if (index4 > -1 & maxArtRange < 1 && simpleList3.FindNr(index4) == -1)
              {
                int tweight = 9999;
                int num68 = index1 - 1;
                int num69 = index1 + 1;
                for (int index34 = num68; index34 <= num69; index34 += 1)
                {
                  int num70 = index2 - 1;
                  int num71 = index2 + 1;
                  for (int index35 = num70; index35 <= num71; index35 += 1)
                  {
                    if (index34 >= 0 & index35 >= 0 & index34 <= this.Width & index35 <= this.Height && this.ai.game.HandyFunctionsObj.Distance(index1, index2, 0, index34, index35, 0) == 1)
                    {
                      int index36 = this.ai.game.HandyFunctionsObj.HexFacing(index1, index2, 0, index34, index35, 0) - 1;
                      if (this.MoveCostArtAttack[index33, index36].Value[index1, index2] <= this.ai.game.HandyFunctionsObj.GetLowestAp(index4) && this.MoveCostArtAttack[index33, index36].Value[index1, index2] < tweight)
                      {
                        bool flag6 = false;
                        if (this.enemyDistance.Value[index34, index35] > maxArtRange - 1)
                          flag6 = true;
                        if (flag6)
                        {
                          tweight = this.MoveCostArtAttack[index33, index36].Value[index1, index2];
                          num58 = index4;
                          coordinate3 = this.MoveFromArtMove[index33].Value[index1, index2];
                          index15 = index33;
                          tdata2_1 = index36;
                        }
                      }
                    }
                  }
                }
                if (tweight < 9999)
                {
                  simpleList3.Add(index4, tweight, index15, tdata2_1);
                  num67 += this.ai.game.Data.UnitObj[index4].TempUnitPower;
                }
              }
            }
            simpleList3.Sort();
            bool flag7 = false;
            int counter11 = simpleList3.Counter;
            for (index14 = 0; index14 <= counter11; index14 += 1)
            {
              index4 = simpleList3.Id[index14];
              if ((double) index14 > (double) simpleList3.Counter * Math.Sqrt((double) (simpleList3.Counter + 1)))
                flag7 = true;
              if (flag7)
              {
                int counter12 = simpleList3.Counter;
                int num72 = index14 + 1;
                for (int nr = counter12; nr >= num72; nr += -1)
                  simpleList3.RemoveNr(nr);
                break;
              }
            }
            if (simpleList3.Counter > -1)
            {
              num26 *= 2f;
              num20 *= 2f;
            }
          }
          bool flag8 = false;
          float num73 = num26 * concentricBonus2Prognosis1;
          float num74 = num20 * concentricBonus2Prognosis1;
          if (num24 > 0 & num22 > 0 && num24 > num22 * 3)
          {
            float num75 = (float) Math.Sqrt((double) ((float) num24 / (float) (num22 * 3)));
            if ((double) num75 > 1.5)
              num75 = 1.5f + (float) Math.Sqrt((double) num75 - 1.5);
            num73 *= num75;
            num74 *= num75;
          }
          if (forEncircled & stimulateAttack > 0)
            currentMinimal /= 5f;
          if ((double) num73 < (double) currentMinimal & UL.counter > -1 & simpleList1.Counter > -1)
          {
            UL.counter = -1;
            simpleList3.Counter = -1;
          }
          if ((double) num73 < (double) currentMinimal & (double) num73 > 0.0)
            num12 = num12;
          int num76;
          float num77;
          AIMove tempMove;
          if ((double) num73 > (double) currentMinimal | UL.counter == -1 & simpleList1.Counter > -1)
          {
            if (UL.counter == -1 & simpleList1.Counter > -1)
              num76 = num12;
            num77 = num73 / currentMinimal;
            num11 = -1;
            if ((double) num73 > 0.0 & val2 > 0)
              flag8 = flag8;
            if (num59 > 0)
              num59 = num59;
            if (val2 > 0)
              ;
            if (this.map.HexObj[this.GetRealX(index1), index2 + this.Top].UnitCounter > -1)
            {
              int counter13 = UL.counter;
              for (int index37 = 0; index37 <= counter13; index37 += 1)
              {
                index4 = UL.unr[index37];
                if (Strings.InStr(DrawMod.TGame.Data.UnitObj[index4].Name, "Flak") > 0)
                  index4 = index4;
                index15 = UL.data[index37];
                tdata2_1 = UL.data2[index37];
                if (!(this.ai.game.Data.UnitObj[index4].X == this.GetRealX(this.MoveFromAttack[index15, tdata2_1].Value[index1, index2].x) & this.ai.game.Data.UnitObj[index4].Y == this.MoveFromAttack[index15, tdata2_1].Value[index1, index2].y + this.Top))
                {
                  tempMove = AIMove::new();
                  tempMove.UnitAIid = this.ai.game.Data.UnitObj[index4].AIid;
                  tempMove.MoveTo.x = this.GetRealX(this.MoveFromAttack[index15, tdata2_1].Value[index1, index2].x);
                  tempMove.MoveTo.y = this.MoveFromAttack[index15, tdata2_1].Value[index1, index2].y + this.Top;
                  tempMove.MoveTo.onmap = true;
                  this.MoveList.AddMove(ref tempMove);
                }
              }
              int counter14 = simpleList3.Counter;
              for (int index38 = 0; index38 <= counter14; index38 += 1)
              {
                index4 = simpleList3.Id[index38];
                if (Strings.InStr(DrawMod.TGame.Data.UnitObj[index4].Name, "Flak") > 0)
                  index4 = index4;
                index15 = simpleList3.Data1[index38];
                tdata2_1 = simpleList3.Data2[index38];
                if (!(this.ai.game.Data.UnitObj[index4].X == this.GetRealX(this.MoveFromArtAttack[index15, tdata2_1].Value[index1, index2].x) & this.ai.game.Data.UnitObj[index4].Y == this.MoveFromArtAttack[index15, tdata2_1].Value[index1, index2].y + this.Top))
                {
                  tempMove = AIMove::new();
                  tempMove.UnitAIid = this.ai.game.Data.UnitObj[index4].AIid;
                  tempMove.MoveTo.x = this.GetRealX(this.MoveFromArtAttack[index15, tdata2_1].Value[index1, index2].x);
                  tempMove.MoveTo.y = this.MoveFromArtAttack[index15, tdata2_1].Value[index1, index2].y + this.Top;
                  tempMove.MoveTo.onmap = true;
                  this.MoveList.AddMove(ref tempMove);
                }
              }
            }
            int counter15 = UL.counter;
            for (int index39 = 0; index39 <= counter15; index39 += 1)
            {
              if (this.map.HexObj[this.GetRealX(index1), index2 + this.Top].UnitCounter == -1)
              {
                index4 = UL.unr[index39];
                tempMove = AIMove::new();
                tempMove.UnitAIid = this.ai.game.Data.UnitObj[index4].AIid;
                tempMove.MoveTo.x = this.GetRealX(index1);
                tempMove.MoveTo.y = index2 + this.Top;
                tempMove.MoveTo.onmap = true;
                this.MoveList.AddMove(ref tempMove);
              }
              else
              {
                index4 = UL.unr[index39];
                flag8 = true;
                tempMove = AIMove::new();
                if (Strings.InStr(DrawMod.TGame.Data.UnitObj[index4].Name, "Flak") > 0)
                  index4 = index4;
                tempMove.UnitAIid = this.ai.game.Data.UnitObj[index4].AIid;
                tempMove.AttackOn.x = this.GetRealX(index1);
                tempMove.AttackOn.y = index2 + this.Top;
                tempMove.AttackOn.onmap = true;
                this.MoveList.AddMove(ref tempMove);
              }
            }
            int counter16 = simpleList3.Counter;
            for (int index40 = 0; index40 <= counter16; index40 += 1)
            {
              if (this.map.HexObj[this.GetRealX(index1), index2 + this.Top].UnitCounter == -1)
              {
                index4 = simpleList3.Id[index40];
                tempMove = AIMove::new();
                tempMove.UnitAIid = this.ai.game.Data.UnitObj[index4].AIid;
                tempMove.MoveTo.x = this.GetRealX(index1);
                tempMove.MoveTo.y = index2 + this.Top;
                tempMove.MoveTo.onmap = true;
                this.MoveList.AddMove(ref tempMove);
              }
              else
              {
                index4 = simpleList3.Id[index40];
                flag8 = true;
                tempMove = AIMove::new();
                tempMove.UnitAIid = this.ai.game.Data.UnitObj[index4].AIid;
                tempMove.AttackOn.x = this.GetRealX(index1);
                tempMove.AttackOn.y = index2 + this.Top;
                tempMove.AttackOn.onmap = true;
                this.MoveList.AddMove(ref tempMove);
              }
            }
          }
          else if ((double) num74 > (double) currentMinimal & UL.counter > -1)
          {
            if (UL.counter == -1 & simpleList1.Counter > -1)
              num76 = num12;
            num77 = num74 / currentMinimal;
            num11 = -1;
            if (this.map.HexObj[this.GetRealX(index1), index2 + this.Top].UnitCounter > -1)
            {
              int counter17 = UL.counter;
              for (int index41 = 0; index41 <= counter17; index41 += 1)
              {
                index4 = UL.unr[index41];
                index15 = UL.data[index41];
                tdata2_1 = UL.data2[index41];
                if (!(this.ai.game.Data.UnitObj[index4].X == this.GetRealX(this.MoveFromAttack[index15, tdata2_1].Value[index1, index2].x) & this.ai.game.Data.UnitObj[index4].Y == this.MoveFromAttack[index15, tdata2_1].Value[index1, index2].y + this.Top))
                {
                  tempMove = AIMove::new();
                  tempMove.UnitAIid = this.ai.game.Data.UnitObj[index4].AIid;
                  tempMove.MoveTo.x = this.GetRealX(this.MoveFromAttack[index15, tdata2_1].Value[index1, index2].x);
                  tempMove.MoveTo.y = this.MoveFromAttack[index15, tdata2_1].Value[index1, index2].y + this.Top;
                  tempMove.MoveTo.onmap = true;
                  this.MoveList.AddMove(ref tempMove);
                }
              }
            }
          }
          bool flag9 = false;
          if (flag8)
          {
            int num78;
            if ((double) num73 > (double) currentMinimal)
            {
              int counter18 = this.frontList.Counter;
              for (int index42 = 0; index42 <= counter18; index42 += 1)
              {
                if (this.frontList.Front[index42].FrontType == 5 && this.frontList.Front[index42].TargetFrontID == this.front.FrontID)
                {
                  int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.frontList.Front[index42].units.AIid[0]);
                  if (unitByAiid > -1)
                  {
                    int unitAirRangeInHex = this.ai.game.HandyFunctionsObj.GetUnitAirRangeInHex(unitByAiid);
                    if (unitAirRangeInHex == -1)
                    {
                      this.ai.game.HandyFunctionsObj.MakeMovePrediction(unitByAiid, this.ai.game.Data.UnitObj[unitByAiid].X, this.ai.game.Data.UnitObj[unitByAiid].Y, 0, false, PredictAirOnly: true, attack: true, attackoptions: true, onlyThroughOneEnemyHex: true);
                      if (this.ai.game.EditObj.TempValue[0].Value[this.GetRealX(index1), index2 + this.Top] <= this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid))
                      {
                        tempMove = AIMove::new();
                        flag9 = true;
                        num78 += this.ai.game.HandyFunctionsObj.GetUnitStackPtsAir(unitByAiid);
                        tempMove.UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid;
                        tempMove.AttackOn.x = this.GetRealX(index1);
                        tempMove.AttackOn.y = index2 + this.Top;
                        tempMove.IsAir = true;
                        tempMove.AttackOn.onmap = true;
                        this.MoveList.AddMove(ref tempMove);
                        this.MoveList.AirPresent = true;
                        break;
                      }
                    }
                    else if (unitAirRangeInHex > 0 && this.ai.game.HandyFunctionsObj.Distance(this.GetRealX(index1), index2 + this.Top, 0, this.ai.game.Data.UnitObj[unitByAiid].X, this.ai.game.Data.UnitObj[unitByAiid].Y, 0) <= unitAirRangeInHex)
                    {
                      tempMove = AIMove::new();
                      flag9 = true;
                      num78 += this.ai.game.HandyFunctionsObj.GetUnitStackPtsAir(unitByAiid);
                      tempMove.UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid;
                      tempMove.AttackOn.x = this.GetRealX(index1);
                      tempMove.AttackOn.y = index2 + this.Top;
                      tempMove.IsAir = true;
                      tempMove.AttackOn.onmap = true;
                      this.MoveList.AddMove(ref tempMove);
                      this.MoveList.AirPresent = true;
                      break;
                    }
                  }
                }
              }
            }
            if (flag8)
            {
              int counter19 = this.frontList.Counter;
              for (int index43 = 0; index43 <= counter19; index43 += 1)
              {
                if (this.frontList.Front[index43].FrontType == 4 && this.frontList.Front[index43].TargetFrontID == this.front.FrontID)
                {
                  int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.frontList.Front[index43].units.AIid[0]);
                  if (unitByAiid > -1)
                  {
                    int unitAirRangeInHex = this.ai.game.HandyFunctionsObj.GetUnitAirRangeInHex(unitByAiid);
                    bool flag10;
                    int num79;
                    if (unitAirRangeInHex == -1)
                    {
                      this.ai.game.HandyFunctionsObj.MakeMovePrediction(unitByAiid, this.ai.game.Data.UnitObj[unitByAiid].X, this.ai.game.Data.UnitObj[unitByAiid].Y, 0, false, PredictAirOnly: true, attack: true, attackoptions: true, onlyThroughOneEnemyHex: true);
                      if (this.ai.game.EditObj.TempValue[0].Value[this.GetRealX(index1), index2 + this.Top] <= this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid))
                      {
                        tempMove = AIMove::new();
                        flag10 = true;
                        num78 += this.ai.game.HandyFunctionsObj.GetUnitStackPtsAir(unitByAiid);
                        num79 += this.ai.game.Data.UnitObj[unitByAiid].TempUnitPower;
                        tempMove.UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid;
                        tempMove.AttackOn.x = this.GetRealX(index1);
                        tempMove.AttackOn.y = index2 + this.Top;
                        tempMove.IsAir = true;
                        tempMove.AttackOn.onmap = true;
                        this.MoveList.AddMove(ref tempMove);
                        this.MoveList.AirPresent = true;
                        if (num78 > this.ai.VAR_HEX_STACK_AIR || num79 * 2 > val2)
                          break;
                      }
                    }
                    else if (unitAirRangeInHex > 0 && this.ai.game.HandyFunctionsObj.Distance(this.GetRealX(index1), index2 + this.Top, 0, this.ai.game.Data.UnitObj[unitByAiid].X, this.ai.game.Data.UnitObj[unitByAiid].Y, 0) <= unitAirRangeInHex)
                    {
                      tempMove = AIMove::new();
                      flag10 = true;
                      num78 += this.ai.game.HandyFunctionsObj.GetUnitStackPtsAir(unitByAiid);
                      num79 += this.ai.game.Data.UnitObj[unitByAiid].TempUnitPower;
                      tempMove.UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid;
                      tempMove.AttackOn.x = this.GetRealX(index1);
                      tempMove.AttackOn.y = index2 + this.Top;
                      tempMove.IsAir = true;
                      tempMove.AttackOn.onmap = true;
                      this.MoveList.AddMove(ref tempMove);
                      this.MoveList.AirPresent = true;
                      if (num78 > this.ai.VAR_HEX_STACK_AIR || num79 * 2 > val2)
                        break;
                    }
                  }
                }
              }
            }
          }
          if ((double) num73 > (double) currentMinimal | UL.counter == -1 & simpleList1.Counter > -1)
          {
            int counter20 = simpleList1.Counter;
            for (int index44 = 0; index44 <= counter20; index44 += 1)
            {
              if (this.front.FrontID == 210)
                ;
              index4 = simpleList1.Id[index44];
              int tx = simpleList1.Data1[index44];
              int num80 = simpleList1.Data2[index44];
              if (!(this.ai.game.Data.UnitObj[index4].X == this.GetRealX(tx) & this.ai.game.Data.UnitObj[index4].Y == num80 + this.Top))
              {
                tempMove = AIMove::new();
                tempMove.UnitAIid = this.ai.game.Data.UnitObj[index4].AIid;
                tempMove.IsArt = true;
                tempMove.MoveTo.x = this.GetRealX(tx);
                tempMove.MoveTo.y = num80 + this.Top;
                tempMove.MoveTo.onmap = true;
                this.MoveList.ArtPresent = true;
                this.MoveList.AddMove(ref tempMove);
              }
              tempMove = AIMove::new();
              tempMove.UnitAIid = this.ai.game.Data.UnitObj[index4].AIid;
              tempMove.IsArt = true;
              tempMove.AttackOn.x = this.GetRealX(index1);
              tempMove.AttackOn.y = index2 + this.Top;
              tempMove.AttackOn.onmap = true;
              this.MoveList.ArtPresent = true;
              this.MoveList.AddMove(ref tempMove);
            }
          }
          if ((double) num73 < (double) currentMinimal | UL.counter == -1 & simpleList1.Counter == -1 & simpleList2.Counter > -1)
          {
            num1 = 0;
            int num81 = 0;
            int num82 = 0;
            if (simpleList2.Counter > -1)
            {
              int counter21 = simpleList2.Counter;
              for (int index45 = 0; index45 <= counter21; index45 += 1)
              {
                index4 = simpleList2.Id[index45];
                num10 = simpleList2.Data1[index45];
                int num83 = simpleList2.Data2[index45];
                tempMove = AIMove::new();
                tempMove.UnitAIid = this.ai.game.Data.UnitObj[index4].AIid;
                tempMove.IsArt = true;
                tempMove.IsTransportAir = true;
                tempMove.AttackOn.x = this.GetRealX(index1);
                tempMove.AttackOn.y = index2 + this.Top;
                tempMove.AttackOn.onmap = true;
                this.MoveList.ArtPresent = true;
                this.MoveList.AddMove(ref tempMove);
                int index46 = -1;
                int counter22 = this.front.units.counter;
                for (int index47 = 0; index47 <= counter22; index47 += 1)
                {
                  if (this.front.units.unr[index47] == index4)
                  {
                    index46 = index47;
                    break;
                  }
                }
                num81 += this.MoveTempLos[index46].Value[index1, index2];
                num82 += 1;
              }
            }
            if (num82 > 0)
              num1 = (int) Math.Round((double) num81 / (double) num82);
          }
          counter1 = simpleList1.Counter;
          counter2 = UL.counter;
          counter3 = simpleList2.Counter;
          num11 += -1;
        }
        while (num11 >= 1);
      }
      if (this.MoveList.Counter > -1)
      {
        this.Score = (int) Math.Round((double) num2 / 1.5) - stimulateAttack * 2;
        if (this.ai.map.HexObj[this.GetRealX(index1), index2 + this.Top].UnitCounter == -1)
          this.Score = (int) Math.Round((double) this.Score / 1.5);
        if (this.front.Stance == 2)
          this.Score = (int) Math.Round((double) this.Score / 1.5);
        if ((double) this.front.UnitCountRatio < 0.33)
          this.Score *= 2;
        else if ((double) this.front.UnitCountRatio < 0.66)
          this.Score = (int) Math.Round((double) this.Score * 1.7);
        else if ((double) this.front.UnitCountRatio < 0.85)
          this.Score = (int) Math.Round((double) this.Score * 1.4);
        else if ((double) this.front.UnitCountRatio < 1.5)
          this.Score = (int) Math.Round((double) this.Score * 1.2);
        else if ((double) this.front.UnitCountRatio < 2.1)
          this.Score *= 1;
        else
          this.Score = (double) this.front.UnitCountRatio >= 3.5 ? ((double) this.front.UnitCountRatio >= 4.5 ? (int) Math.Round((double) this.Score * 0.7) : (int) Math.Round((double) this.Score * 0.8)) : (int) Math.Round((double) this.Score * 0.9);
        int counter23 = this.MoveList.Counter;
        int num84;
        int num85;
        for (int index48 = 0; index48 <= counter23; index48 += 1)
        {
          int unitAiid = this.MoveList.Move[index48].UnitAIid;
          if (unitAiid > -1)
          {
            int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(unitAiid);
            if (unitByAiid > -1)
            {
              num84 += this.ai.game.HandyFunctionsObj.GetAverageRdn(unitByAiid) * this.ai.game.Data.UnitObj[unitByAiid].TempUnitPowerAbs;
              num85 += this.ai.game.Data.UnitObj[unitByAiid].TempUnitPowerAbs;
            }
          }
        }
        if (num85 > 0)
        {
          float num86 = (float) ((double) num84 / (double) num85 / 100.0);
          this.Score = (int) Math.Round((double) ((float) this.Score * num86));
          this.Score = (int) Math.Round((double) this.Score * 0.33) + (int) Math.Round((double) this.Score * 0.66 * (double) num86);
        }
        if (this.front.Stance == 3)
          this.Score = this.Score * 2 + 50;
        if ((double) this.front.OrigAverageStrength >= 3.5)
          this.Score = (int) Math.Round((double) this.Score * 1.25);
        if ((double) this.front.OrigAverageStrength >= 4.0)
          this.Score = (int) Math.Round((double) this.Score * 1.5);
        if ((double) this.front.OrigAverageStrength >= 4.5)
          this.Score *= 2;
        this.Score = (int) Math.Round((double) this.Score / 1.8);
        if (this.front.Stance == 3)
        {
          if (counter2 < 0 & counter1 > -1 & counter3 < 0)
            this.Score = (int) Math.Round((double) this.Score * 0.66);
          else if (counter2 < 0 & counter3 > -1)
            this.Score = (int) Math.Round((double) this.Score * 0.66 * (double) num1 / 100.0);
        }
        else if (this.front.Stance == 2)
        {
          if (counter2 < 0 & counter1 > -1 & counter3 < 0)
            this.Score = (int) Math.Round((double) this.Score * 0.85);
          else if (counter2 < 0 & counter3 > -1)
            this.Score = (int) Math.Round((double) this.Score * 1.22 * (double) num1 / 100.0);
        }
        this.Score += 0;
      }
      return this.MoveList;
    }

    pub IsLastUnit: bool(int unr, AIFront front)
    {
      int counter = front.units.counter;
      int num;
      for (int index = 0; index <= counter; index += 1)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(front.units.AIid[index]);
        if (unitByAiid > -1 && this.ai.game.Data.UnitObj[unitByAiid].X == this.ai.game.Data.UnitObj[unr].X && this.ai.game.Data.UnitObj[unitByAiid].Y == this.ai.game.Data.UnitObj[unr].Y)
          num += 1;
      }
      return num <= 1;
    }

    pub EvacuateHex: bool(int x, int y)
    {
      int num1 = 0;
      int num2 = 0;
      int num3;
      if (this.Owner.Value[x, y] == 1)
      {
        int index1 = 0;
        do
        {
          Coordinate coordinate1 = this.ai.TempHexNeighbour[x, y, index1];
          if (coordinate1.onmap && coordinate1.x <= this.Width & coordinate1.y <= this.Height)
          {
            if (this.Owner.Value[coordinate1.x, coordinate1.y] == 2)
              num3 += 1;
            else if (this.Owner.Value[coordinate1.x, coordinate1.y] == 1)
            {
              int index2 = 0;
              do
              {
                Coordinate coordinate2 = this.ai.TempHexNeighbour[coordinate1.x, coordinate1.y, index2];
                if (coordinate2.onmap & !(coordinate2.x == coordinate1.x & coordinate2.y == coordinate1.y) & coordinate2.x <= this.Width & coordinate2.y <= this.Height)
                {
                  if (this.Owner.Value[coordinate2.x, coordinate2.y] == 2)
                    num2 += 2;
                  else if (this.Owner.Value[coordinate2.x, coordinate2.y] == 1)
                  {
                    num2 += 2;
                    num1 += 1;
                  }
                  else
                    num2 += 1;
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
          index1 += 1;
        }
        while (index1 <= 5);
      }
      else
        num3 = 0;
      if (num3 >= 5 & (this.front.Stance != 3 | (double) this.front.UnitCountRatio < 0.9) || num3 >= 4 & (double) this.front.UnitCountRatio < 0.57 || num3 >= 3 & (double) this.front.UnitCountRatio < 0.2)
        return true;
      if (num1 > 0 & num3 >= 3)
      {
        float num4 = (float) num1 / (float) num2;
        if ((double) num4 <= 0.25)
          return true;
        if ((double) num4 <= 0.5)
        {
          if (this.front.Stance != 3)
            return true;
        }
        else if ((double) num4 <= 0.75 && this.front.Stance != 3 & this.front.Stance != 2)
          return true;
      }
      return false;
    }

    pub int HexDefendedScore(
      int x,
      int y,
      int withUnit,
      int withoutUnit,
      int otherForcesMovedOut,
      int otherForcesMovedIn,
      bool emphasisOnDistance)
    {
      int num1 = 0;
      if (this.front.FrontID == 101)
        num1 = num1;
      int val2_1;
      if (((withUnit > -1 | withoutUnit > -1 | otherForcesMovedOut > 0 ? 1 : 0) | 1) != 0)
      {
        int val2_2 = this.enemyPressureFull.Value[x, y];
        int num2 = this.troopsstrength.Value[x, y];
        if (withUnit > -1)
          num2 += this.ai.game.Data.UnitObj[withUnit].TempUnitPower;
        if (withoutUnit > -1)
          num2 -= (int) Math.Round((double) this.ai.game.Data.UnitObj[withoutUnit].TempUnitPower * 1.1);
        int num3 = num2 - otherForcesMovedOut + otherForcesMovedIn;
        if (0 > num3)
          num3 = 0;
        if (0 > val2_2)
          val2_2 = 0;
        if (this.front.Stance == 3)
          num3 *= 2;
        if (this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(x), y + this.Top].VP >= 10)
          num3 = (int) Math.Round((double) num3 * 0.4);
        else if (this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(x), y + this.Top].VP >= 5)
          num3 = (int) Math.Round((double) num3 * 0.66);
        int num4 = 999;
        if (val2_2 > 0)
          num4 = (int) Math.Round((double) num3 / (double) Math.Max(1, val2_2) * 100.0);
        int num5 = 999;
        if (this.enemyDistance.Value[x, y] > 0)
        {
          num5 = 125 * this.enemyDistance.Value[x, y];
          int num6 = 9999;
          int tfacing = 1;
          do
          {
            Coordinate coordinate = this.ai.game.HandyFunctionsObj.HexNeighbour(x, y, 0, tfacing);
            if (coordinate.onmap & coordinate.x < this.troopsstrength.Width & coordinate.y < this.troopsstrength.Height)
            {
              int num7 = this.troopsstrength.Value[coordinate.x, coordinate.y];
              int val2_3 = this.enemyPressureFull.Value[coordinate.x, coordinate.y];
              if (val2_3 > 0)
              {
                int num8 = (int) Math.Round((double) num7 / (double) Math.Max(1, val2_3) * 100.0);
                if (num8 < num6)
                  num6 = num8;
              }
            }
            tfacing += 1;
          }
          while (tfacing <= 6);
          if (num6 < num5)
            num5 = (int) Math.Round((double) (num6 + num5) / 2.0);
          if (this.front.Stance == 3)
            num5 = num5 * 2 + 75;
        }
        if (num5 > num4)
          num5 = num4;
        if (this.ai.VAR_EMPHASIS_AGAINST_CONCENTRIC)
        {
          Neighbours neighbours = Neighbours::new();
          int index = 0;
          do
          {
            Coordinate coordinate = this.ai.TempHexNeighbour[this.GetRealX(x), y + this.Top, index];
            if (coordinate.onmap && this.ai.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime != this.ai.game.Data.Turn && this.ai.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime != -1)
              neighbours.data[index] = 1;
            index += 1;
          }
          while (index <= 5);
          HandyFunctionsclass handyFunctionsObj = this.ai.game.HandyFunctionsObj;
          ref Neighbours local1 = ref neighbours;
          bool flag = false;
          ref bool local2 = ref flag;
          float num9 = handyFunctionsObj.GetConcentricBonus(ref local1, ref local2, true);
          if ((double) num9 > 1.0)
          {
            if ((double) num9 >= 1.6)
              num9 = num9;
            num5 = (int) Math.Round((double) ((float) num5 / num9));
          }
        }
        val2_1 = num1 + num5 + 100;
        if (val2_1 < 800)
        {
          int val1 = 50;
          if (this.enemyPressureFull.Value[x, y] < 33)
            val1 = (int) Math.Round((double) (val1 * this.enemyPressureFull.Value[x, y]) / 33.0);
          int num10 = val2_1 - (int) Math.Round((double) (val2_1 * Math.Min(val1, this.FriendlyBottleneckIdealOwnFrontOnly.Value[x, y])) / 100.0);
          val2_1 = num10 - (int) Math.Round((double) (num10 * Math.Min(val1, this.FriendlyBottleneck.Value[x, y])) / 100.0);
          if (this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(x), y + this.Top].Location > -1)
          {
            int val2_4 = val2_1 - (int) Math.Round((double) (Math.Min(val1, val2_1) * Math.Min(val1, this.FriendlyBottleneckIdealOwnFrontOnly.Value[x, y])) / 100.0);
            int val2_5 = val2_4 - (int) Math.Round((double) (Math.Min(val1, val2_4) * Math.Min(val1, this.FriendlyBottleneck.Value[x, y])) / 100.0);
            val2_1 = val2_5 - (int) Math.Round((double) (Math.Min(val1, val2_5) * Math.Min(val1, this.FriendlyBottleneck.Value[x, y])) / 100.0);
          }
        }
      }
      else
        val2_1 = this.FrontArea.Value[x, y] != this.front.FrontID ? num1 + 9999 : (this.ForceRatio.Value[x, y] <= 0 ? (this.Owner.Value[x, y] != 2 ? num1 + 999 : num1 + 0) : num1 + this.ForceRatio.Value[x, y]);
      if (this.front.Stance == 3 & this.Advance.Value[x, y] > 0)
        val2_1 -= (int) Math.Round((double) this.Advance.Value[x, y] / 3.0);
      if (emphasisOnDistance & this.enemyDistance.Value[x, y] > 1)
        val2_1 *= Math.Min(9, Math.Max(1, this.enemyDistance.Value[x, y]));
      else if (this.enemyDistance.Value[x, y] > 1)
        val2_1 = (int) Math.Round((double) val2_1 * Math.Sqrt((double) Math.Min(9, Math.Max(1, this.enemyDistance.Value[x, y]))));
      return val2_1;
    }

    pub int HexDefendImportance(int x, int y)
    {
      int num1 = 0;
      int num2 = Math.Max(0, this.FriendlyBottleneck.Value[x, y] * 2 + 15);
      if (this.front.Stance == 3)
        num2 = (int) Math.Round((double) num2 * 0.1);
      if (this.front.Stance == 2)
        num2 = (int) Math.Round((double) num2 * 0.2);
      int num3 = num2 * 1;
      if (this.enemyDistance.Value[x, y] >= 1)
        num3 = (int) Math.Round((double) num3 / (double) Math.Max(1, this.enemyDistance.Value[x, y]));
      int num4 = num1 + num3;
      int num5 = Math.Max(0, this.FriendlyBottleneckIdealOwnFrontOnly.Value[x, y] * 2 + 15) * 1;
      if (this.front.Stance == 3)
        num5 = (int) Math.Round((double) num5 * 0.5);
      if (this.enemyDistance.Value[x, y] >= 1)
        num5 = (int) Math.Round((double) num5 / (double) Math.Max(2, this.enemyDistance.Value[x, y]));
      int num6 = num4 + num5;
      if (this.EvacuateHex(x, y))
      {
        if (this.front.Stance == 3)
          num6 -= 150;
        else
          num6 -= 250;
      }
      if (this.FrontArea.Value[x, y] != this.front.FrontID & this.FrontAreaForAttack.Value[x, y] != this.front.FrontID)
        num6 -= 200;
      int num7;
      if (this.front.Stance == 3)
      {
        int num8 = this.vpMatrix.Value[x, y];
        if (this.ai.CustomCalls.HasCustumCalls())
          num8 = (int) Math.Round((double) ((float) num8 * this.ai.CustomCalls.CustomRuleTheaterModifiers_VpModifier(x, y)));
        int num9 = (int) Math.Round((double) num8 / 4.0);
        num7 = num6 + num9 + (int) Math.Round((double) (int) Math.Round((double) ((float) (this.ai.map.HexObj[this.GetRealX(x), y + this.Top].VP + this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].AIVP[0].Value[this.GetRealX(x), y + this.Top]) * this.ai.CustomCalls.CustomRuleTheaterModifiers_VpModifier(x, y) * (float) (int) Math.Round(1.0 + (double) this.front.vpScoreAveragePercent / 10.0))) / 20.0);
      }
      else
      {
        int num10 = this.vpMatrix.Value[x, y];
        if (this.ai.CustomCalls.HasCustumCalls())
          num10 = (int) Math.Round((double) ((float) num10 * this.ai.CustomCalls.CustomRuleTheaterModifiers_VpModifier(x, y)));
        num7 = num6 + num10 + (int) Math.Round((double) (int) Math.Round((double) ((float) (this.ai.map.HexObj[this.GetRealX(x), y + this.Top].VP + this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].AIVP[0].Value[this.GetRealX(x), y + this.Top]) * this.ai.CustomCalls.CustomRuleTheaterModifiers_VpModifier(x, y) * (float) (int) Math.Round(3.0 + (double) this.front.vpScoreAveragePercent / 10.0))) / 10.0);
      }
      if (this.ai.map.HexObj[this.GetRealX(x), y + this.Top].Location > -1)
        num7 += 150;
      if (this.front.Stance == 2)
      {
        int tfacing = 1;
        do
        {
          if (this.ai.map.HexObj[this.GetRealX(x), y + this.Top].RiverType[tfacing - 1] > -1)
          {
            Coordinate coordinate = this.ai.game.HandyFunctionsObj.HexNeighbour(this.GetRealX(x), y + this.Top, 0, tfacing);
            if (coordinate.onmap & x > 0 & y > 0 & x < this.Width & y < this.Height && this.enemyDistance.Value[this.GetMatrixX(coordinate.x), coordinate.y - this.Top] >= 0 & this.enemyDistance.Value[x, y] >= 0)
            {
              if (this.enemyDistance.Value[x, y] > this.enemyDistance.Value[this.GetMatrixX(coordinate.x), coordinate.y - this.Top])
                num7 += (int) Math.Round((double) this.ai.game.Data.RiverTypeObj[this.ai.map.HexObj[this.GetRealX(x), y + this.Top].RiverType[tfacing - 1]].TempDefenseBonus / 3.0);
              else if (this.enemyDistance.Value[x, y] < this.enemyDistance.Value[this.GetMatrixX(coordinate.x), coordinate.y - this.Top])
                num7 -= (int) Math.Round((double) this.ai.game.Data.RiverTypeObj[this.ai.map.HexObj[this.GetRealX(x), y + this.Top].RiverType[tfacing - 1]].TempDefenseBonus / 3.0);
            }
          }
          tfacing += 1;
        }
        while (tfacing <= 6);
      }
      if (this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(x), y + this.Top] <= 25)
        num7 += 75;
      else if (this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(x), y + this.Top] <= 50)
        num7 += 50;
      else if (this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(x), y + this.Top] <= 75)
        num7 += 25;
      else if (this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(x), y + this.Top] >= 400)
        num7 -= 75;
      else if (this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(x), y + this.Top] >= 300)
        num7 -= 50;
      else if (this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(x), y + this.Top] >= 200)
        num7 -= 25;
      if (((this.front.Stance == 3 ? 1 : 0) & 0) != 0)
      {
        int num11 = num7 + (int) Math.Round((double) this.Advance.Value[x, y] / 2.0);
        if (this.FrontAreaForAttack.Value[x, y] == this.front.FrontID)
        {
          num11 += this.Advance.Value[x, y];
          if (this.origAdvance.Value[x, y] >= 100)
            num11 += 180;
          else if (this.origAdvance.Value[x, y] >= 85)
            num11 += 150;
          else if (this.origAdvance.Value[x, y] >= 70)
            num11 += 120;
          else if (this.origAdvance.Value[x, y] >= 55)
            num11 += 100;
          else if (this.origAdvance.Value[x, y] >= 40)
            num11 += 65;
          else if (this.origAdvance.Value[x, y] >= 25)
            num11 += 25;
        }
        if (this.FrontAreaForAttack.Value[x, y] == this.front.FrontID)
          num11 += this.Advance.Value[x, y] * 1;
        num7 = num11 + (int) Math.Round((double) this.Advance.Value[x, y] / 2.0);
      }
      if (this.front.Stance == 2)
        num7 += (int) Math.Round((double) this.Advance.Value[x, y] / 3.0);
      if (this.enemyDistance.Value[x, y] == 1)
        num7 += 40;
      if (this.enemyDistance.Value[x, y] == 2)
        num7 += 20;
      if (this.enemyDistance.Value[x, y] == 3)
        num7 += 0;
      if (this.enemyDistance.Value[x, y] == 4)
        num7 -= 20;
      if (this.enemyDistance.Value[x, y] == 5)
        num7 -= 40;
      if (this.enemyDistance.Value[x, y] >= 6)
        num7 -= 80;
      if (this.enemyDistance.Value[x, y] < 0)
        num7 -= 480;
      if (this.Owner.Value[x, y] == 1 & this.ai.map.HexObj[this.GetRealX(x), y + this.Top].VP > 0 && this.currentVP - this.ai.map.HexObj[this.GetRealX(x), y + this.Top].VP <= this.ai.VAR_VP_AT_DEFEAT & this.ai.VAR_VP_AT_DEFEAT > 0)
        num7 += 450;
      if (this.enemyPressureFull.Value[x, y] < 1)
        num7 = (int) Math.Round((double) num7 * 0.1);
      else if (this.enemyPressureFull.Value[x, y] < 5)
        num7 = (int) Math.Round((double) num7 * 0.2);
      else if (this.enemyPressureFull.Value[x, y] < 15)
        num7 = (int) Math.Round((double) num7 * 0.3);
      else if (this.enemyPressureFull.Value[x, y] < 50)
        num7 = (int) Math.Round((double) num7 * 0.6);
      else if (this.enemyPressureFull.Value[x, y] < 100)
        num7 = (int) Math.Round((double) num7 * 0.8);
      return num7;
    }

    pub void SetFallbackMove(
      ref PassHexList passList,
      ref PassHexList tempPassList,
      ref PassHexList tryPassList,
      int maxFallbackHex)
    {
      this.MoveList = AIMoveList::new();
      int num1 = 0;
      this.triedX = -1;
      this.triedY = -1;
      if (this.front.FrontID == 2981)
      {
        int num2 = num2;
      }
      int num3 = 0;
      int counter;
      int unitByAiid;
      int x;
      int y1;
      do
      {
        if (num3 == 0)
          counter = this.front.units.counter;
        if (num3 == 1)
          counter = this.front.artUnits.counter;
        int num4 = counter;
        for (int index = 0; index <= num4; index += 1)
        {
          if (num3 == 0)
            unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index]);
          if (num3 == 1)
            unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.artUnits.AIid[index]);
          int matrixX = this.GetMatrixX(this.ai.game.Data.UnitObj[unitByAiid].X);
          int y2 = this.ai.game.Data.UnitObj[unitByAiid].Y - this.Top;
          if (this.Owner.Value[matrixX, y2] == 1 | this.Owner.Value[matrixX, y2] == 3 && this.FrontArea.Value[matrixX, y2] == this.front.FrontID)
          {
            int num5 = this.troopsstrength.Value[matrixX, y2] * (this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(matrixX), y2 + this.Top].UnitCounter + 1);
            if (num5 > num1 && !passList.Exists(matrixX, y2, 3) && !tempPassList.Exists(matrixX, y2, 3) && !tryPassList.Exists(matrixX, y2, 3))
            {
              num1 = num5;
              x = matrixX;
              y1 = y2;
            }
          }
        }
        num3 += 1;
      }
      while (num3 <= 1);
      if (num1 > 0)
      {
        this.triedX = x;
        this.triedY = y1;
        int num6 = 0;
        do
        {
          if (num6 == 0)
            counter = this.front.units.counter;
          if (num6 == 1)
            counter = this.front.artUnits.counter;
          int num7 = counter;
          for (int index1 = 0; index1 <= num7; index1 += 1)
          {
            if (num6 == 0)
              unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index1]);
            if (num6 == 1)
              unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.artUnits.AIid[index1]);
            if (unitByAiid > -1 && !this.ai.game.Data.UnitObj[unitByAiid].TempProtector)
            {
              int matrixX = this.GetMatrixX(this.ai.game.Data.UnitObj[unitByAiid].X);
              int y1_1 = this.ai.game.Data.UnitObj[unitByAiid].Y - this.Top;
              if (matrixX == x & y1_1 == y1)
              {
                int num8 = 999999;
                int index2 = -1;
                int index3 = -1;
                int width = this.Width;
                for (int index4 = 0; index4 <= width; index4 += 1)
                {
                  int height = this.Height;
                  for (int y2 = 0; y2 <= height; y2 += 1)
                  {
                    if (this.Owner.Value[index4, y2] == 1)
                    {
                      int num9 = 0;
                      switch (num6)
                      {
                        case 0:
                          if (this.MoveCostMove[index1].Value[index4, y2] <= this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid))
                          {
                            num9 = 1;
                            break;
                          }
                          break;
                        case 1:
                          if (this.MoveCostArtMove[index1].Value[index4, y2] <= this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid))
                          {
                            num9 = 1;
                            break;
                          }
                          break;
                      }
                      if (num9 == 1)
                      {
                        int num10 = 0;
                        switch (num6)
                        {
                          case 0:
                            num10 = this.FriendlySupplyAfterEnemyMove.Value[index4, y2] + this.MoveCostMove[index1].Value[index4, y2] + this.FriendlySupply.Value[index4, y2];
                            break;
                          case 1:
                            num10 = this.FriendlySupplyAfterEnemyMove.Value[index4, y2] + this.MoveCostArtMove[index1].Value[index4, y2] + this.FriendlySupply.Value[index4, y2];
                            break;
                        }
                        int num11 = this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index4), y2 + this.Top].UnitCounter + 1;
                        if (index4 == matrixX & y2 == y1_1)
                          --num11;
                        int num12 = num10 + 20 * num11 * num11;
                        if (num12 < num8 && this.ai.game.HandyFunctionsObj.Distance(matrixX, y1_1, 0, index4, y2, 0, 19) <= maxFallbackHex)
                        {
                          if (num6 == 1)
                            num6 = num6;
                          index2 = index4;
                          index3 = y2;
                          num8 = num12;
                        }
                      }
                    }
                  }
                }
                if (index2 > -1 & !(index2 == matrixX & index3 == y1_1))
                {
                  Coordinate coordinate = Coordinate::new();
                  coordinate.x = index2;
                  coordinate.y = index3;
                  coordinate.onmap = true;
                  coordinate.map = 0;
                  int num13 = 0;
                  while (coordinate.onmap & num13 < 99)
                  {
                    switch (num6)
                    {
                      case 0:
                        if (this.MoveFromMove[index1].Value[coordinate.x, coordinate.y].x == matrixX & this.MoveFromMove[index1].Value[coordinate.x, coordinate.y].y == y1_1)
                        {
                          coordinate.onmap = false;
                          continue;
                        }
                        if (this.MoveFromMove[index1].Value[coordinate.x, coordinate.y].onmap & this.MoveFromMove[index1].Value[coordinate.x, coordinate.y].x <= this.Width & this.MoveFromMove[index1].Value[coordinate.x, coordinate.y].y <= this.Height)
                          coordinate = this.MoveFromMove[index1].Value[coordinate.x, coordinate.y];
                        else
                          coordinate.onmap = false;
                        num13 += 1;
                        continue;
                      case 1:
                        if (this.MoveFromArtMove[index1].Value[coordinate.x, coordinate.y].x == matrixX & this.MoveFromArtMove[index1].Value[coordinate.x, coordinate.y].y == y1_1)
                        {
                          coordinate.onmap = false;
                          continue;
                        }
                        if (this.MoveFromArtMove[index1].Value[coordinate.x, coordinate.y].onmap & this.MoveFromArtMove[index1].Value[coordinate.x, coordinate.y].x <= this.Width & this.MoveFromArtMove[index1].Value[coordinate.x, coordinate.y].y <= this.Height)
                          coordinate = this.MoveFromArtMove[index1].Value[coordinate.x, coordinate.y];
                        else
                          coordinate.onmap = false;
                        num13 += 1;
                        continue;
                      default:
                        continue;
                    }
                  }
                  if (!(coordinate.x == matrixX & coordinate.y == y1_1))
                  {
                    AIMove tempMove = AIMove::new();
                    tempMove.UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid;
                    tempMove.MoveTo.x = this.GetRealX(coordinate.x);
                    tempMove.MoveTo.y = coordinate.y + this.Top;
                    tempMove.MoveTo.onmap = true;
                    this.Score = num6 != 1 ? 120 - this.MoveCostMove[index1].Value[index2, index3] : 120 - this.MoveCostArtMove[index1].Value[index2, index3];
                    if (this.front.Stance == 2)
                      this.Score += 50;
                    if (this.front.Stance == 1)
                      this.Score += 100;
                    this.Score = (int) Math.Round((double) this.Score / 5.0);
                    this.MoveList.AddMove(ref tempMove);
                    return;
                  }
                }
              }
            }
          }
          num6 += 1;
        }
        while (num6 <= 1);
        passList.AddCoord(x, y1, 3);
      }
      this.Score = 0;
    }

    pub void SetStrategicMove()
    {
      this.MoveList = AIMoveList::new();
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      aiMatrix.SetAllValuesTo(9999);
      aiMatrix.Value[this.front.targetX, this.front.targetY] = 0;
      aiMatrix.ExpandAsSimplifiedSupplyRouteMatrix(this.ai.VAR_SUPPLY_FRIENDLY_MOVETYPE, ref this.Owner, 1);
      if (this.front.targetX == 64 & this.front.targetY == 89)
      {
        int num1 = num1;
      }
      int counter = this.front.units.counter;
      for (int index1 = 0; index1 <= counter; index1 += 1)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index1]);
        if (unitByAiid > -1 && !this.ai.game.Data.UnitObj[unitByAiid].DidMove & !this.ai.game.Data.UnitObj[unitByAiid].DidAttack && !(this.ai.game.Data.UnitObj[unitByAiid].X == this.front.targetX & this.ai.game.Data.UnitObj[unitByAiid].Y == this.front.targetY))
        {
          int num2 = 9999999;
          int tx = -1;
          int width = this.Width;
          int num3;
          for (int index2 = 0; index2 <= width; index2 += 1)
          {
            int height = this.Height;
            for (int index3 = 0; index3 <= height; index3 += 1)
            {
              if (this.MoveCostMove[index1].Value[index2, index3] <= this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid) && aiMatrix.Value[index2, index3] * 100 + this.MoveCostMove[index1].Value[index2, index3] < num2)
              {
                num2 = aiMatrix.Value[index2, index3] * 100 + this.MoveCostMove[index1].Value[index2, index3];
                tx = index2;
                num3 = index3;
              }
            }
          }
          if (tx > -1)
            this.MoveList.AddMove(ref AIMove::new()
            {
              UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid,
              MoveTo = {
                x = this.GetRealX(tx),
                y = num3 + this.Top,
                onmap = true
              }
            });
        }
      }
    }

    pub void SetDefensiveZoneMove(
      ref PassHexList passList,
      ref PassHexList tempPassList,
      ref PassHexList tryPassList)
    {
      this.MoveList = AIMoveList::new();
      this.Score = 0;
      this.triedX = -1;
      this.triedY = -1;
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      int width1 = this.Width;
      for (int tx = 0; tx <= width1; tx += 1)
      {
        int height = this.Height;
        for (int index = 0; index <= height; index += 1)
        {
          aiMatrix.Value[tx, index] = 9999;
          if (this.ai.VAR_MATRIX_ZONES.Value[this.GetRealX(tx), index + this.Top] + 1000000 == this.front.FrontID && this.Owner.Value[tx, index] == 1)
            aiMatrix.Value[tx, index] = 0;
        }
      }
      aiMatrix.ExpandAsSimplifiedSupplyRouteMatrix(this.ai.VAR_SUPPLY_FRIENDLY_MOVETYPE, ref this.Owner, 1, NoNeutral: true);
      int num1 = 99999;
      int tx1 = -1;
      int counter1 = this.front.units.counter;
      int num2;
      int num3;
      int index1;
      for (int index2 = 0; index2 <= counter1; index2 += 1)
      {
        int unitByAiid1 = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index2]);
        if (unitByAiid1 > -1 && !this.ai.game.Data.UnitObj[unitByAiid1].DidMove & !this.ai.game.Data.UnitObj[unitByAiid1].DidAttack)
        {
          int width2 = this.Width;
          for (int index3 = 0; index3 <= width2; index3 += 1)
          {
            int height = this.Height;
            for (int y = 0; y <= height; y += 1)
            {
              if (!(this.GetRealX(index3) == this.ai.game.Data.UnitObj[unitByAiid1].X & y + this.Top == this.ai.game.Data.UnitObj[unitByAiid1].Y) && this.MoveCostMove[index2].Value[index3, y] <= this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid1) && !passList.Exists(index3, y, 3) && !tempPassList.Exists(index3, y, 3) && !tryPassList.Exists(index3, y, 3))
              {
                int num4 = aiMatrix.Value[index3, y] * 100 + 100;
                bool flag = true;
                if (index3 + this.Left == 136 & y + this.Top == 52)
                  index3 = index3;
                int num5;
                if (this.ai.VAR_MATRIX_ZONES.Value[this.GetRealX(index3), y + this.Top] + 1000000 == this.front.FrontID)
                {
                  num5 = 490000;
                  int num6 = 0;
                  int num7 = 0;
                  if (this.ai.VAR_MATRIX_ZONES.Value[this.ai.game.Data.UnitObj[unitByAiid1].X, this.ai.game.Data.UnitObj[unitByAiid1].Y] + 1000000 == this.front.FrontID)
                  {
                    int counter2 = this.front.units.counter;
                    for (int index4 = 0; index4 <= counter2; index4 += 1)
                    {
                      int unitByAiid2 = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index4]);
                      if (unitByAiid1 != unitByAiid2 && !this.ai.game.Data.UnitObj[unitByAiid2].TempProtector)
                      {
                        if (this.ai.game.Data.UnitObj[unitByAiid2].X == this.ai.game.Data.UnitObj[unitByAiid1].X & this.ai.game.Data.UnitObj[unitByAiid2].Y == this.ai.game.Data.UnitObj[unitByAiid1].Y)
                          num6 += 1;
                        else if (this.ai.game.Data.UnitObj[unitByAiid2].X == this.GetRealX(index3) & this.ai.game.Data.UnitObj[unitByAiid2].Y == y + this.Top)
                          num7 += 1;
                      }
                    }
                    if (num6 <= num7 & num7 > 0)
                      flag = false;
                  }
                  if (flag)
                  {
                    if (num7 == 0)
                    {
                      num4 = (int) Math.Round((double) num4 / 7.0) - 10;
                      num5 = 4000000;
                    }
                    else if (num7 == 1)
                    {
                      num4 = (int) Math.Round((double) num4 / 5.0) - 8;
                      num5 = 2890000;
                    }
                    else if (num7 == 2)
                    {
                      num4 = (int) Math.Round((double) num4 / 3.0) - 6;
                      num5 = 1690000;
                    }
                    else if (num7 >= 3)
                    {
                      num4 = (int) Math.Round((double) num4 / 2.0) - 4;
                      num5 = 1000000;
                    }
                    num4 -= (int) Math.Round(20.0 * ((double) (10 + this.vpMatrix.Value[index3, y]) / 100.0));
                    num5 = (int) Math.Round((double) (num5 * this.vpMatrix.Value[index3, y]) / 10.0);
                  }
                }
                else
                {
                  num5 = 250000;
                  if (this.ai.VAR_MATRIX_ZONES.Value[this.ai.game.Data.UnitObj[unitByAiid1].X, this.ai.game.Data.UnitObj[unitByAiid1].Y] + 1000000 == this.front.FrontID)
                    flag = false;
                }
                if (num4 < num1 & flag)
                {
                  num1 = num4;
                  tx1 = index3;
                  num2 = num5;
                  num3 = y;
                  index1 = unitByAiid1;
                }
              }
            }
          }
        }
      }
      if (tx1 <= -1)
        return;
      this.triedX = tx1;
      this.triedY = num3;
      this.MoveList.AddMove(ref AIMove::new()
      {
        UnitAIid = this.ai.game.Data.UnitObj[index1].AIid,
        MoveTo = {
          x = this.GetRealX(tx1),
          y = num3 + this.Top,
          onmap = true
        }
      });
      this.Score = num2;
    }

    pub void SetReserveMove()
    {
      this.MoveList = AIMoveList::new();
      AIMatrix aiMatrix1 = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      int width1 = this.Width;
      for (int tx = 0; tx <= width1; tx += 1)
      {
        int height = this.Height;
        for (int index = 0; index <= height; index += 1)
        {
          aiMatrix1.Value[tx, index] = 9999;
          if (this.front.TargetFrontID <= 0)
          {
            if (this.ai.frontMatrix.Value[this.GetRealX(tx), index + this.Top] == this.front.FrontID && this.Owner.Value[tx, index] == 1)
              aiMatrix1.Value[tx, index] = 0;
          }
          else if (this.ai.frontMatrix.Value[this.GetRealX(tx), index + this.Top] == this.front.TargetFrontID && this.Owner.Value[tx, index] == 1)
            aiMatrix1.Value[tx, index] = 0;
        }
      }
      if (this.front.TargetFrontID > 0)
      {
        AIFront front = this.frontList.FindFront(this.front.TargetFrontID);
        if (!Information.IsNothing((object) front) && front.Stance == 4 | front.FrontType == 12)
        {
          int num = 0;
          SimpleList neighbourFrontList = front.GetNeighbourFrontList();
          int counter = neighbourFrontList.Counter;
          for (int index = 0; index <= counter; index += 1)
          {
            if (this.frontList.FindFront(neighbourFrontList.Id[index]).Stance == 4)
              num += 1;
          }
          if (num == neighbourFrontList.Counter + 1 & !front.HasFriendlyZeroBorder())
          {
            aiMatrix1.ExpandSpecificValueForSameRegime(0, this.ai.VAR_FRONTLINE_DEPTH);
            aiMatrix1 = aiMatrix1;
          }
          else
          {
            aiMatrix1.ExpandSpecificValueForSameRegime(0, 1);
            aiMatrix1 = aiMatrix1;
          }
        }
      }
      AIMatrix aiMatrix2 = aiMatrix1.Clone();
      int counter1 = this.front.units.counter;
      int num1;
      AIMove tempMove;
      for (int index1 = 0; index1 <= counter1; index1 += 1)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index1]);
        if (unitByAiid > -1)
        {
          AIMatrix aiMatrix3 = aiMatrix2.Clone();
          aiMatrix3.ExpandAsSimplifiedSupplyRouteMatrix(this.ai.game.Data.SFTypeObj[this.ai.game.Data.UnitObj[unitByAiid].TempType].MoveType, ref this.Owner, 1, true, extraForEnemy: 999, nonRoadCostMod: 1.25f);
          if (!(this.front.TargetFrontID > 0 & aiMatrix3.Value[this.GetMatrixX(this.ai.game.Data.UnitObj[unitByAiid].X), this.ai.game.Data.UnitObj[unitByAiid].Y - this.Top] == 0) && !(this.front.FrontType != 2 & this.ai.frontMatrix.Value[this.ai.game.Data.UnitObj[unitByAiid].X, this.ai.game.Data.UnitObj[unitByAiid].Y] == this.front.FrontID))
          {
            int num2 = 99999999;
            int num3 = -1;
            int width2 = this.Width;
            for (int tx = 0; tx <= width2; tx += 1)
            {
              int height = this.Height;
              for (int index2 = 0; index2 <= height; index2 += 1)
              {
                if (this.MoveCostMove[index1].Value[tx, index2] < 999)
                {
                  int num4 = aiMatrix3.Value[tx, index2] * 2;
                  int num5 = Math.Min(10, Math.Max(1, this.enemyDistance.Value[tx, index2]));
                  int num6 = num4 + (int) Math.Round((double) this.MoveCostMove[index1].Value[tx, index2] / 2.0);
                  int num7 = this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(tx), index2 + this.Top].UnitCounter + 1;
                  int num8 = !(num5 >= 1 & num5 <= 2) ? (!(num5 >= 1 & num5 <= 3) ? num6 + num6 * 3 : num6 + 0) : num6 * 2;
                  if (num8 < num2)
                  {
                    num2 = num8;
                    num3 = tx;
                    num1 = index2;
                  }
                }
              }
            }
            if (num3 > -1)
            {
              tempMove = AIMove::new();
              tempMove.UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid;
              Coordinate coordinate;
              coordinate.x = num3;
              coordinate.y = num1;
              coordinate.onmap = true;
              bool flag = true;
              int lowestAp = this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid);
              int num9 = 9999;
              while (coordinate.onmap & flag)
              {
                if (coordinate.x > this.Width | coordinate.y > this.Height)
                  flag = false;
                else if (this.MoveCostMove[index1].Value[coordinate.x, coordinate.y] > lowestAp & this.MoveCostMove[index1].Value[coordinate.x, coordinate.y] < num9)
                {
                  num9 = this.MoveCostMove[index1].Value[coordinate.x, coordinate.y];
                  coordinate = this.MoveFromMove[index1].Value[coordinate.x, coordinate.y];
                }
                else
                  flag = false;
              }
              if (!flag && !(coordinate.x > this.Width | coordinate.y > this.Height) && this.MoveCostMove[index1].Value[coordinate.x, coordinate.y] > 0)
              {
                tempMove.MoveTo.x = this.GetRealX(coordinate.x);
                tempMove.MoveTo.y = coordinate.y + this.Top;
                tempMove.MoveTo.onmap = true;
                this.MoveList.AddMove(ref tempMove);
              }
            }
          }
        }
      }
      int counter2 = this.front.artUnits.counter;
      for (int index3 = 0; index3 <= counter2; index3 += 1)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.artUnits.AIid[index3]);
        if (unitByAiid > -1)
        {
          AIMatrix aiMatrix4 = aiMatrix2.Clone();
          aiMatrix4.ExpandAsSimplifiedSupplyRouteMatrix(this.ai.game.Data.SFTypeObj[this.ai.game.Data.UnitObj[unitByAiid].TempType].MoveType, ref this.Owner, 1, true, extraForEnemy: 999, nonRoadCostMod: 1.1f);
          if (!(this.front.TargetFrontID > 0 & aiMatrix4.Value[this.GetMatrixX(this.ai.game.Data.UnitObj[unitByAiid].X), this.ai.game.Data.UnitObj[unitByAiid].Y - this.Top] == 0) && !(this.front.FrontType != 2 & this.ai.frontMatrix.Value[this.GetMatrixX(this.ai.game.Data.UnitObj[unitByAiid].X), this.ai.game.Data.UnitObj[unitByAiid].Y - this.Top] == this.front.FrontID))
          {
            int num10 = 99999999;
            int num11 = -1;
            if (!Information.IsNothing((object) this.MoveCostArtMove) && index3 <= this.MoveCostArtMove.GetUpperBound(0))
            {
              int width3 = this.Width;
              for (int tx = 0; tx <= width3; tx += 1)
              {
                int height = this.Height;
                for (int index4 = 0; index4 <= height; index4 += 1)
                {
                  if (this.MoveCostArtMove[index3].Value[tx, index4] < 999)
                  {
                    int num12 = aiMatrix4.Value[tx, index4] * 2;
                    int num13 = Math.Min(10, Math.Max(1, this.enemyDistance.Value[tx, index4]));
                    int num14 = num12 + (int) Math.Round((double) this.MoveCostArtMove[index3].Value[tx, index4] / 2.0);
                    int num15 = this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(tx), index4 + this.Top].UnitCounter + 1;
                    if (num15 > 3 & this.front.TargetFrontID == 200)
                      index3 = index3;
                    int num16 = !(num13 >= 1 & num13 <= 3) ? (!(num13 >= 1 & num13 <= 5) ? num14 + num15 * 10 : num14 + num15 * 4 * (num15 + 1)) : num14 + num15 * 10 * (num15 + 1);
                    if (num16 < num10)
                    {
                      num10 = num16;
                      num11 = tx;
                      num1 = index4;
                    }
                  }
                }
              }
            }
            if (num11 > -1)
            {
              tempMove = AIMove::new();
              tempMove.UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid;
              Coordinate coordinate;
              coordinate.x = num11;
              coordinate.y = num1;
              coordinate.onmap = true;
              bool flag = true;
              int lowestAp = this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid);
              while (coordinate.onmap & flag)
              {
                if (coordinate.x > this.Width | coordinate.y > this.Height)
                  flag = false;
                else if (this.MoveCostArtMove[index3].Value[coordinate.x, coordinate.y] > lowestAp)
                  coordinate = this.MoveFromArtMove[index3].Value[coordinate.x, coordinate.y];
                else
                  flag = false;
              }
              if (!flag && !(coordinate.x > this.Width | coordinate.y > this.Height) && this.MoveCostArtMove[index3].Value[coordinate.x, coordinate.y] > 0)
              {
                tempMove.MoveTo.x = this.GetRealX(coordinate.x);
                tempMove.MoveTo.y = coordinate.y + this.Top;
                tempMove.MoveTo.onmap = true;
                this.MoveList.AddMove(ref tempMove);
              }
            }
          }
        }
      }
    }

    pub void SetAirMove()
    {
      this.MoveList = AIMoveList::new();
      AIFront front;
      if (this.front.TargetFrontID > 0)
        front = this.frontList.FindFront(this.front.TargetFrontID);
      int counter1 = this.front.units.counter;
      for (int index1 = 0; index1 <= counter1; index1 += 1)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index1]);
        if (unitByAiid > -1)
        {
          int unr;
          if (this.ai.game.Data.HistoricalUnitObj[this.ai.game.Data.UnitObj[unitByAiid].Historical].ID == 184)
            unr = unr;
          if (!this.ai.game.Data.UnitObj[unitByAiid].DidMove & !this.ai.game.Data.UnitObj[unitByAiid].DidAttack)
          {
            int maxdistance = (int) Math.Round(Math.Floor((double) this.ai.game.HandyFunctionsObj.GetMaxAirRange(unitByAiid) * 0.6));
            int num1 = this.ai.game.HandyFunctionsObj.SE1_GetUnitMinimumAirfieldLevel(unitByAiid);
            if (num1 < 1)
              num1 = 0;
            int num2 = 0;
            int tx = -1;
            int width = this.Width;
            int num3;
            for (int index2 = 0; index2 <= width; index2 += 1)
            {
              int height = this.Height;
              for (int y1 = 0; y1 <= height; y1 += 1)
              {
                if (this.MoveCostMove[index1].Value[index2, y1] <= this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid) * 2 && this.FrontArea.Value[index2, y1] > 0 && this.ai.game.HandyFunctionsObj.IsHexAirfield(this.GetRealX(index2), this.Top + y1, 0) | num1 < 1 & this.ai.game.HandyFunctionsObj.HasHexRoad(this.GetRealX(index2), y1 + this.Top, 0))
                {
                  int num4 = 50 * this.FrontArea.Value[index2, y1];
                  if (num1 > 0)
                  {
                    if (this.enemyDistance.Value[index2, y1] == 0)
                      num4 += 1000;
                    else
                      num4 += this.enemyDistance.Value[index2, y1] * 50;
                    if (this.enemyDistance.Value[index2, y1] == 1)
                      num4 -= 2000;
                    if (this.enemyDistance.Value[index2, y1] == 2)
                      num4 -= 1000;
                    if (this.enemyDistance.Value[index2, y1] == 3)
                      num4 -= 300;
                    if (this.enemyDistance.Value[index2, y1] == 4)
                      num4 -= 80;
                  }
                  else
                  {
                    if (this.enemyDistance.Value[index2, y1] == 1)
                      num4 -= 2000;
                    if (this.enemyDistance.Value[index2, y1] == 2)
                      num4 -= 1200;
                    if (this.enemyDistance.Value[index2, y1] == 3)
                      num4 -= 800;
                    if (this.enemyDistance.Value[index2, y1] == 4)
                      num4 -= 400;
                    if (this.enemyDistance.Value[index2, y1] == 5)
                      num4 -= 100;
                  }
                  if (this.FriendlySupply.Value[index2, y1] > this.ai.VAR_SUPPLY_75PERCENT_RANGE)
                    num4 -= 500;
                  if (this.FriendlySupply.Value[index2, y1] > this.ai.VAR_SUPPLY_50PERCENT_RANGE)
                    num4 -= 1000;
                  if (this.FriendlySupply.Value[index2, y1] > this.ai.VAR_SUPPLY_25PERCENT_RANGE)
                    num4 -= 1500;
                  int num5 = num4 - (int) Math.Round((double) num4 * 0.2 * (double) this.MoveCostMove[index1].Value[index2, y1] / 100.0);
                  if (num5 < 0)
                    num5 = 0;
                  if (this.ai.game.Data.UnitObj[unitByAiid].X == index2 & this.ai.game.Data.UnitObj[unitByAiid].Y == y1)
                    num5 += 100;
                  int num6 = 0;
                  int unitCounter = this.ai.game.Data.MapObj[0].HexObj[index2, y1].UnitCounter;
                  for (int index3 = 0; index3 <= unitCounter; index3 += 1)
                  {
                    unr = this.ai.game.Data.MapObj[0].HexObj[index2, y1].UnitList[index3];
                    if (this.ai.game.HandyFunctionsObj.HasUnitAirSF(unr) & unr != unitByAiid)
                      num6 += 1;
                  }
                  int counter2 = this.MoveList.Counter;
                  for (int index4 = 0; index4 <= counter2; index4 += 1)
                  {
                    if (this.MoveList.Move[index4].MoveTo.x == index2 & this.MoveList.Move[index4].MoveTo.y == y1)
                      num6 += 1;
                  }
                  if (this.ai.game.Data.Turn == 4)
                    index1 = index1;
                  if (num6 > 0)
                    num5 = (int) Math.Round((double) num5 * 0.62) + (int) Math.Round((double) num5 * 0.38 / (double) (num6 + 1));
                  if (!Information.IsNothing((object) front))
                  {
                    int num7 = 0;
                    if (front.units.counter > -1 | front.artUnits.counter > -1)
                    {
                      int num8 = 2 + front.units.counter + front.artUnits.counter;
                      int counter3 = front.units.counter;
                      for (int index5 = 0; index5 <= counter3; index5 += 1)
                      {
                        unr = front.units.unr[index5];
                        if (this.ai.game.HandyFunctionsObj.Distance(index2, y1, 0, this.ai.game.Data.UnitObj[unr].X, this.ai.game.Data.UnitObj[unr].Y, 0, maxdistance) <= maxdistance)
                          num7 += 1;
                      }
                      int counter4 = front.artUnits.counter;
                      for (int index6 = 0; index6 <= counter4; index6 += 1)
                      {
                        unr = front.artUnits.unr[index6];
                        if (this.ai.game.HandyFunctionsObj.Distance(index2, y1, 0, this.ai.game.Data.UnitObj[unr].X, this.ai.game.Data.UnitObj[unr].Y, 0, maxdistance) <= maxdistance)
                          num7 += 1;
                      }
                      num5 = (int) Math.Round((double) num5 * 0.15) + (int) Math.Round((double) num5 * 0.85 * ((double) num7 / (double) num8));
                    }
                  }
                  if (num5 > num2)
                  {
                    num2 = num5;
                    tx = index2;
                    num3 = y1;
                  }
                }
              }
            }
            if (tx > -1)
              this.MoveList.AddMove(ref AIMove::new()
              {
                UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid,
                MoveTo = {
                  x = this.GetRealX(tx),
                  y = num3 + this.Top,
                  onmap = true
                }
              });
          }
        }
      }
    }

    pub void SetAirTransportMove()
    {
      this.MoveList = AIMoveList::new();
      int counter = this.front.units.counter;
      for (int index1 = 0; index1 <= counter; index1 += 1)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index1]);
        if (unitByAiid > -1 && !this.ai.game.Data.UnitObj[unitByAiid].DidMove & !this.ai.game.Data.UnitObj[unitByAiid].DidAttack)
        {
          int num1 = 0;
          int tx = -1;
          int width = this.Width;
          int num2;
          for (int index2 = 0; index2 <= width; index2 += 1)
          {
            int height = this.Height;
            for (int y = 0; y <= height; y += 1)
            {
              if (this.MoveCostMove[index1].Value[index2, y] <= this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid) && this.FrontArea.Value[index2, y] > 0 && this.ai.game.HandyFunctionsObj.IsHexAirfield(this.GetRealX(index2), this.Top + y, 0))
              {
                int num3 = this.FrontArea.Value[index2, y] * 50;
                int num4 = this.enemyDistance.Value[index2, y] != 0 ? num3 + this.enemyDistance.Value[index2, y] * 50 : num3 + 1000;
                if (this.enemyDistance.Value[index2, y] == 1)
                  num4 -= 2000;
                if (this.enemyDistance.Value[index2, y] == 2)
                  num4 -= 1000;
                if (this.enemyDistance.Value[index2, y] == 3)
                  num4 -= 500;
                if (this.FriendlySupply.Value[index2, y] > this.ai.VAR_SUPPLY_75PERCENT_RANGE)
                  num4 -= 500;
                if (this.FriendlySupply.Value[index2, y] > this.ai.VAR_SUPPLY_50PERCENT_RANGE)
                  num4 -= 1000;
                if (this.FriendlySupply.Value[index2, y] > this.ai.VAR_SUPPLY_25PERCENT_RANGE)
                  num4 -= 1500;
                int num5 = num4 + (int) Math.Round((double) (1000f * this.ai.game.HandyFunctionsObj.GetAirFieldStackModifier(index2, y, unitByAiid))) - this.MoveCostMove[index1].Value[index2, y];
                if (this.ai.game.Data.UnitObj[unitByAiid].X == index2 & this.ai.game.Data.UnitObj[unitByAiid].Y == y)
                  num5 += 100;
                if (num5 > num1)
                {
                  num1 = num5;
                  tx = index2;
                  num2 = y;
                }
              }
            }
          }
          if (tx > -1)
          {
            AIMove tempMove = AIMove::new();
            tempMove.UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid;
            tempMove.MoveTo.x = this.GetRealX(tx);
            tempMove.MoveTo.y = num2 + this.Top;
            tempMove.MoveTo.onmap = true;
            Coordinate averageFrontCoordinate = this.frontList.FindFront(this.front.TargetFrontID).GetAverageFrontCoordinate();
            if (averageFrontCoordinate.onmap)
            {
              SimpleList simpleList = SimpleList::new();
              int num6 = averageFrontCoordinate.x - 6;
              int num7 = averageFrontCoordinate.x + 6;
              for (int index3 = num6; index3 <= num7; index3 += 1)
              {
                int num8 = averageFrontCoordinate.y - 6;
                int num9 = averageFrontCoordinate.y + 6;
                for (int index4 = num8; index4 <= num9; index4 += 1)
                {
                  if (index3 >= 0 & index4 >= 0 & index3 <= this.Width & index4 <= this.Height)
                  {
                    int unitCounter = this.ai.map.HexObj[index3, index4].UnitCounter;
                    for (int tid = 0; tid <= unitCounter; tid += 1)
                    {
                      if (this.ai.game.Data.UnitObj[this.ai.map.HexObj[index3, index4].UnitList[tid]].AIGroup == this.front.TargetFrontID)
                      {
                        if (this.ai.game.HandyFunctionsObj.IsHexAirfield(index3, index4, 0))
                          simpleList.Add(tid, this.ai.game.HandyFunctionsObj.Distance(index3, index4, 0, averageFrontCoordinate.x, averageFrontCoordinate.y, 0, 9) - 1000, index3, index4);
                        else
                          simpleList.Add(tid, this.ai.game.HandyFunctionsObj.Distance(index3, index4, 0, averageFrontCoordinate.x, averageFrontCoordinate.y, 0, 9), index3, index4);
                      }
                    }
                  }
                }
              }
              if (simpleList.Counter > -1)
              {
                simpleList.Sort();
                averageFrontCoordinate.x = simpleList.Data1[simpleList.Counter];
                averageFrontCoordinate.y = simpleList.Data2[simpleList.Counter];
              }
              tempMove.AttackOn.onmap = true;
              tempMove.AttackOn.x = averageFrontCoordinate.x;
              tempMove.AttackOn.y = averageFrontCoordinate.y;
              tempMove.IsTransportAir = true;
              tempMove.IsAir = true;
            }
            this.MoveList.AddMove(ref tempMove);
          }
        }
      }
    }

    pub void SetEngineerMove()
    {
      this.MoveList = AIMoveList::new();
      int counter = this.front.units.counter;
      for (int index1 = 0; index1 <= counter; index1 += 1)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index1]);
        if (unitByAiid > -1)
        {
          int tx1;
          int num1;
          bool flag1;
          AIMove tempMove;
          if (!this.ai.game.Data.UnitObj[unitByAiid].DidMove & !this.ai.game.Data.UnitObj[unitByAiid].DidAttack)
          {
            int num2 = 99999;
            tx1 = -1;
            int width1 = this.Width;
            for (int tx2 = 0; tx2 <= width1; tx2 += 1)
            {
              int height = this.Height;
              for (int index2 = 0; index2 <= height; index2 += 1)
              {
                if (this.MoveCostMove[index1].Value[tx2, index2] <= 9999 && this.FrontArea.Value[tx2, index2] > 0 & this.front.HasCoord(this.GetRealX(tx2), index2 + this.Top) && this.ai.game.HandyFunctionsObj.HasHexBrokenBridge(this.GetRealX(tx2), this.Top + index2, 0))
                {
                  AIFront front = this.frontList.FindFront(this.FrontArea.Value[tx2, index2]);
                  bool flag2 = false;
                  if (this.Owner.Value[tx2, index2] == 2)
                  {
                    if (front.Stance == 3)
                      flag2 = true;
                  }
                  else
                  {
                    flag2 = true;
                    if (front.Stance == 1)
                      flag2 = false;
                    if (front.Stance == 4)
                      flag2 = false;
                  }
                  if (flag2)
                  {
                    int num3 = this.MoveCostMove[index1].Value[tx2, index2];
                    if (num3 < num2)
                    {
                      num2 = num3;
                      tx1 = tx2;
                      num1 = index2;
                    }
                  }
                }
              }
            }
            if (tx1 == -1)
            {
              AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
              int num4 = -99999;
              tx1 = -1;
              int width2 = this.Width;
              for (int tx3 = 0; tx3 <= width2; tx3 += 1)
              {
                int height = this.Height;
                for (int index3 = 0; index3 <= height; index3 += 1)
                {
                  if (this.MoveCostMove[index1].Value[tx3, index3] <= 9999 && this.front.HasCoord(this.GetRealX(tx3), index3 + this.Top) && this.ai.game.HandyFunctionsObj.HasHexBridge(this.GetRealX(tx3), this.Top + index3, 0) && this.front.HasCoord(this.GetRealX(tx3), this.Top + index3))
                    aiMatrix.Value[tx3, index3] = 4;
                }
              }
              aiMatrix.ExpandAndRemoveValueForAnyRegime(5);
              int width3 = this.Width;
              for (int tx4 = 0; tx4 <= width3; tx4 += 1)
              {
                int height = this.Height;
                for (int index4 = 0; index4 <= height; index4 += 1)
                {
                  if (this.MoveCostMove[index1].Value[tx4, index4] < 999 && aiMatrix.Value[tx4, index4] > 0)
                  {
                    AIFront front = this.frontList.FindFront(this.FrontArea.Value[tx4, index4]);
                    int num5 = -this.MoveCostMove[index1].Value[tx4, index4] + aiMatrix.Value[tx4, index4] * 25;
                    if (!Information.IsNothing((object) front))
                    {
                      if (front.Stance == 4 | front.Stance == 1)
                      {
                        if (this.enemyDistance.Value[tx4, index4] == 1)
                          num5 -= 800;
                        if (this.enemyDistance.Value[tx4, index4] == 2)
                          num5 -= 500;
                        if (this.enemyDistance.Value[tx4, index4] == 3)
                          num5 -= 250;
                        if (this.enemyDistance.Value[tx4, index4] == 4)
                          num5 -= 100;
                      }
                      else
                      {
                        if (this.enemyDistance.Value[tx4, index4] == 1)
                          num5 -= 400;
                        if (this.enemyDistance.Value[tx4, index4] == 2)
                          num5 -= 200;
                        if (this.enemyDistance.Value[tx4, index4] == 3)
                          num5 -= 100;
                        if (this.enemyDistance.Value[tx4, index4] == 4)
                          num5 -= 50;
                      }
                      if (this.ai.game.HandyFunctionsObj.GetRegime(this.map.HexObj[this.GetRealX(tx4), index4 + this.Top].Regime) != this.ai.GetGameDataTurn())
                        num5 -= 1600;
                      if (num5 > num4)
                      {
                        num4 = num5;
                        tx1 = tx4;
                        flag1 = true;
                        num1 = index4;
                      }
                    }
                  }
                }
              }
            }
            if (tx1 > -1)
            {
              int num6 = -1;
              int index5 = 0;
              while (!(this.ai.map.HexObj[this.GetRealX(tx1), num1 + this.Top].RiverType[index5] > -1 & this.ai.map.HexObj[this.GetRealX(tx1), num1 + this.Top].RoadType[index5] > -1 & !this.ai.map.HexObj[this.GetRealX(tx1), num1 + this.Top].Bridge[index5]))
              {
                index5 += 1;
                if (index5 > 5)
                  goto label_63;
              }
              num6 = index5;
label_63:
              if (!(this.ai.game.Data.UnitObj[unitByAiid].X == tx1 & this.ai.game.Data.UnitObj[unitByAiid].Y == num1))
              {
                Coordinate coordinate1;
                coordinate1.onmap = true;
                coordinate1.x = tx1;
                coordinate1.y = num1;
                int num7 = 0;
                bool flag3;
                while (coordinate1.onmap & coordinate1.x <= this.Width & coordinate1.y <= this.Height & num7 < 99)
                {
                  num7 += 1;
                  if (this.MoveCostMove[index1].Value[coordinate1.x, coordinate1.y] > this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid))
                  {
                    coordinate1 = this.MoveFromMove[index1].Value[coordinate1.x, coordinate1.y];
                    flag3 = true;
                  }
                  else if (flag1 & (this.enemyDistance.Value[coordinate1.x, coordinate1.y] > 0 & this.enemyDistance.Value[coordinate1.x, coordinate1.y] <= 2 | this.ai.game.HandyFunctionsObj.GetRegime(this.map.HexObj[coordinate1.x, coordinate1.y].Regime) != this.ai.GetGameDataTurn()))
                  {
                    Coordinate coordinate2 = this.MoveFromMove[index1].Value[coordinate1.x, coordinate1.y];
                    if (coordinate2.onmap)
                    {
                      if (this.enemyDistance.Value[coordinate2.x, coordinate2.y] < this.enemyDistance.Value[coordinate1.x, coordinate1.y])
                      {
                        coordinate1 = this.MoveFromMove[index1].Value[coordinate1.x, coordinate1.y];
                        flag3 = true;
                      }
                      else
                        break;
                    }
                  }
                  else
                    break;
                }
                tx1 = coordinate1.x;
                num1 = coordinate1.y;
                if (coordinate1.onmap)
                {
                  tempMove = AIMove::new();
                  tempMove.UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid;
                  tempMove.MoveTo.x = this.GetRealX(tx1);
                  tempMove.MoveTo.y = num1 + this.Top;
                  tempMove.MoveTo.onmap = true;
                  tempMove.BridgeToo = num6;
                  this.MoveList.AddMove(ref tempMove);
                }
                if (!flag3 & !flag1)
                {
                  tempMove = AIMove::new();
                  tempMove.UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid;
                  tempMove.BridgeToo = num6;
                  this.MoveList.AddMove(ref tempMove);
                }
              }
              else if (!flag1)
              {
                tempMove = AIMove::new();
                tempMove.UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid;
                tempMove.BridgeToo = num6;
                this.MoveList.AddMove(ref tempMove);
              }
            }
          }
          if (tx1 == -1)
          {
            AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
            aiMatrix.SetAllValuesTo(9999);
            int coordCount = this.front.coordCount;
            for (int index6 = 0; index6 <= coordCount; index6 += 1)
              aiMatrix.Value[this.GetMatrixX(this.front.Coords[index6].x), this.front.Coords[index6].y - this.Top] = 0;
            int num8 = 9999;
            aiMatrix.ExpandAsSimplifiedSupplyRouteMatrix(this.ai.VAR_SUPPLY_FRIENDLY_MOVETYPE, ref this.Owner, 1, true, true);
            int width = this.Width;
            for (int index7 = 0; index7 <= width; index7 += 1)
            {
              int height = this.Height;
              for (int index8 = 0; index8 <= height; index8 += 1)
              {
                if (this.MoveCostMove[index1].Value[index7, index8] <= this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid) && aiMatrix.Value[index7, index8] < num8)
                {
                  num8 = aiMatrix.Value[index7, index8];
                  tx1 = index7;
                  flag1 = true;
                  num1 = index8;
                }
              }
            }
            if (tx1 > -1)
            {
              tempMove = AIMove::new();
              tempMove.UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid;
              tempMove.MoveTo.x = this.GetRealX(tx1);
              tempMove.MoveTo.y = num1 + this.Top;
              tempMove.MoveTo.onmap = true;
              this.MoveList.AddMove(ref tempMove);
            }
          }
          if (tx1 == -1)
            tx1 = tx1;
        }
      }
    }

    pub void SetOrgMove()
    {
      this.MoveList = AIMoveList::new();
      if (this.front.FrontID == 4000)
      {
        int num1 = num1;
      }
      int counter = this.front.orgUnits.counter;
      for (int index1 = 0; index1 <= counter; index1 += 1)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.orgUnits.AIid[index1]);
        if (unitByAiid > -1 && !this.ai.game.Data.UnitObj[unitByAiid].DidMove & !this.ai.game.Data.UnitObj[unitByAiid].DidAttack)
        {
          int num2 = -9999;
          int tx1 = -1;
          int width = this.Width;
          int num3;
          for (int tx2 = 0; tx2 <= width; tx2 += 1)
          {
            int height = this.Height;
            for (int index2 = 0; index2 <= height; index2 += 1)
            {
              if (this.MoveCostOrgMove[index1].Value[tx2, index2] <= this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid))
              {
                int num4 = 0;
                if (this.enemyDistance.Value[tx2, index2] >= 1 & this.enemyDistance.Value[tx2, index2] <= 10)
                  num4 -= 30 * (10 - this.enemyDistance.Value[tx2, index2]);
                if (this.ai.map.HexObj[this.GetRealX(tx2), index2 + this.Top].Location > -1 | this.ai.map.HexObj[this.GetRealX(tx2), index2 + this.Top].VP > 0)
                  num4 += 50;
                if (num4 > num2)
                {
                  num2 = num4;
                  tx1 = tx2;
                  num3 = index2;
                }
              }
            }
          }
          if (tx1 > -1 && !(this.ai.game.Data.UnitObj[unitByAiid].X == tx1 & this.ai.game.Data.UnitObj[unitByAiid].Y == num3))
          {
            Coordinate coordinate;
            coordinate.onmap = true;
            coordinate.x = tx1;
            coordinate.y = num3;
            if (coordinate.onmap)
              this.MoveList.AddMove(ref AIMove::new()
              {
                UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid,
                MoveTo = {
                  x = this.GetRealX(tx1),
                  y = num3 + this.Top,
                  onmap = true
                }
              });
          }
        }
      }
    }

    pub void SetEscapeAttack()
    {
    }

    pub void SetEscapeMove()
    {
      this.MoveList = AIMoveList::new();
      int[,] numArray1 = new int[this.Width + 1, this.Height + 1];
      int counter = this.front.units.counter;
      for (int index1 = 0; index1 <= counter; index1 += 1)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index1]);
        if (unitByAiid > -1 && !this.ai.game.Data.UnitObj[unitByAiid].TempProtector)
        {
          int matrixX1 = this.GetMatrixX(this.ai.game.Data.UnitObj[unitByAiid].X);
          int index2 = this.ai.game.Data.UnitObj[unitByAiid].Y - this.Top;
          int num1 = this.FriendlyBottleneckIdealOwnFrontOnly.Value[matrixX1, index2] * 3;
          if (this.ai.friendlySupplyMatrix.Value[this.GetRealX(matrixX1), index2 + this.Top] <= this.ai.VAR_SUPPLY_MAXIMUM_RANGE)
            num1 = num1 + 100 + (this.ai.VAR_SUPPLY_MAXIMUM_RANGE - this.ai.friendlySupplyMatrix.Value[this.GetRealX(matrixX1), index2 + this.Top]);
          int num2 = this.ai.map.HexObj[this.GetRealX(matrixX1), index2 + this.Top].UnitCounter + numArray1[matrixX1, index2] + 1;
          if (num2 > 12)
            num1 = (int) Math.Round((double) num1 * 0.3);
          else if (num2 > 9)
            num1 = (int) Math.Round((double) num1 * 0.5);
          else if (num2 > 6)
            num1 = (int) Math.Round((double) num1 * 0.7);
          else if (num2 > 3)
            num1 = (int) Math.Round((double) num1 * 0.85);
          int num3 = num1;
          int tx1 = -1;
          int width = this.Width;
          int num4;
          for (int tx2 = 0; tx2 <= width; tx2 += 1)
          {
            int height = this.Height;
            for (int index3 = 0; index3 <= height; index3 += 1)
            {
              if (this.MoveCostMove[index1].Value[tx2, index3] <= this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid) + 100)
              {
                bool flag = false;
                Coordinate coordinate;
                coordinate.onmap = true;
                coordinate.x = tx2;
                for (coordinate.y = index3; coordinate.onmap & coordinate.x <= this.Width & coordinate.y <= this.Height; coordinate = this.MoveFromMove[index1].Value[coordinate.x, coordinate.y])
                {
                  if (this.Owner.Value[coordinate.x, coordinate.y] == 2 && this.troopsstrength.Value[coordinate.x, coordinate.y] > 0)
                    flag = true;
                }
                if (!flag)
                {
                  int num5 = this.FriendlyBottleneckIdealOwnFrontOnly.Value[tx2, index3] * 3;
                  if (this.ai.friendlySupplyMatrix.Value[this.GetRealX(tx2), index3 + this.Top] <= this.ai.VAR_SUPPLY_75PERCENT_RANGE)
                    num5 += 600;
                  else if (this.ai.friendlySupplyMatrix.Value[this.GetRealX(tx2), index3 + this.Top] <= this.ai.VAR_SUPPLY_50PERCENT_RANGE)
                    num5 += 300;
                  else if (this.ai.friendlySupplyMatrix.Value[this.GetRealX(tx2), index3 + this.Top] <= this.ai.VAR_SUPPLY_25PERCENT_RANGE)
                    num5 = num5 + 100 + (this.ai.VAR_SUPPLY_MAXIMUM_RANGE - this.ai.friendlySupplyMatrix.Value[this.GetRealX(tx2), index3 + this.Top]);
                  int num6 = this.ai.map.HexObj[this.GetRealX(tx2), index3 + this.Top].UnitCounter + numArray1[tx2, index3] + 1;
                  if (num6 > 12)
                    num5 = (int) Math.Round((double) num5 * 0.3);
                  else if (num6 > 9)
                    num5 = (int) Math.Round((double) num5 * 0.5);
                  else if (num6 > 6)
                    num5 = (int) Math.Round((double) num5 * 0.7);
                  else if (num6 > 3)
                    num5 = (int) Math.Round((double) num5 * 0.85);
                  if (num5 > num3)
                  {
                    num3 = num5;
                    tx1 = tx2;
                    num4 = index3;
                  }
                }
              }
            }
          }
          if (tx1 > -1 && !(this.ai.game.Data.UnitObj[unitByAiid].X == this.GetRealX(tx1) & this.ai.game.Data.UnitObj[unitByAiid].Y == num4 + this.Top))
          {
            Coordinate coordinate;
            coordinate.onmap = true;
            coordinate.x = tx1;
            coordinate.y = num4;
            if (coordinate.onmap)
            {
              AIMove tempMove = AIMove::new();
              tempMove.UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid;
              tempMove.MoveTo.x = this.GetRealX(tx1);
              tempMove.MoveTo.y = num4 + this.Top;
              int[,] numArray2 = numArray1;
              int[,] numArray3 = numArray2;
              int index4 = tx1;
              int index5 = index4;
              int index6 = num4;
              int index7 = index6;
              int num7 = numArray2[index4, index6] + 1;
              numArray3[index5, index7] = num7;
              int[,] numArray4 = numArray1;
              int[,] numArray5 = numArray4;
              int matrixX2 = this.GetMatrixX(this.ai.game.Data.UnitObj[unitByAiid].X);
              int index8 = matrixX2;
              int index9 = this.ai.game.Data.UnitObj[unitByAiid].Y - this.Top;
              int index10 = index9;
              int num8 = numArray4[matrixX2, index9] - 1;
              numArray5[index8, index10] = num8;
              tempMove.MoveTo.onmap = true;
              this.MoveList.AddMove(ref tempMove);
            }
          }
        }
      }
    }

    pub void SetProtectorMove(int unr, int besti, int bestx, int besty)
    {
      this.MoveList = AIMoveList::new();
      int[,] numArray1 = new int[this.Width + 1, this.Height + 1];
      if (bestx <= -1 || this.GetMatrixX(this.ai.game.Data.UnitObj[unr].X) == bestx & this.ai.game.Data.UnitObj[unr].Y - this.Top == besty)
        return;
      Coordinate coordinate;
      coordinate.onmap = true;
      coordinate.x = bestx;
      coordinate.y = besty;
      for (int index = 0; coordinate.onmap & coordinate.x > -1 & coordinate.y > -1 & coordinate.x <= this.Width & coordinate.y <= this.Height & index < 99; coordinate = this.MoveFromMove[besti].Value[coordinate.x, coordinate.y])
      {
        index += 1;
        if (this.MoveCostMove[besti].Value[coordinate.x, coordinate.y] <= this.ai.game.HandyFunctionsObj.GetLowestAp(unr))
          break;
      }
      bestx = coordinate.x;
      besty = coordinate.y;
      if (!coordinate.onmap)
        return;
      AIMove tempMove = AIMove::new();
      tempMove.UnitAIid = this.ai.game.Data.UnitObj[unr].AIid;
      tempMove.MoveTo.x = this.GetRealX(bestx);
      tempMove.MoveTo.y = besty + this.Top;
      int[,] numArray2 = numArray1;
      int[,] numArray3 = numArray2;
      int index1 = bestx;
      int index2 = index1;
      int index3 = besty;
      int index4 = index3;
      int num1 = numArray2[index1, index3] + 1;
      numArray3[index2, index4] = num1;
      int[,] numArray4 = numArray1;
      int[,] numArray5 = numArray4;
      int matrixX = this.GetMatrixX(this.ai.game.Data.UnitObj[unr].X);
      int index5 = matrixX;
      int index6 = this.ai.game.Data.UnitObj[unr].Y - this.Top;
      int index7 = index6;
      int num2 = numArray4[matrixX, index6] - 1;
      numArray5[index5, index7] = num2;
      tempMove.MoveTo.onmap = true;
      this.MoveList.AddMove(ref tempMove);
    }

    pub void SetNavyMove()
    {
      this.MoveList = AIMoveList::new();
      if (this.front.targetX == -1)
        return;
      int counter = this.front.units.counter;
      for (int index1 = 0; index1 <= counter; index1 += 1)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index1]);
        if (unitByAiid > -1)
        {
          int num1 = 99999;
          int tx = -1;
          bool flag1 = false;
          Coordinate coordinate;
          if (this.ai.map.HexObj[this.front.targetX, this.front.targetY].Regime == -1)
          {
            bool flag2 = true;
            if (this.ai.map.HexObj[this.front.targetX, this.front.targetY].UnitCounter > -1)
            {
              if (this.ai.game.Data.UnitObj[this.ai.map.HexObj[this.front.targetX, this.front.targetY].UnitList[0]].Regime == this.ai.game.Data.Turn)
                flag2 = false;
            }
            else
              flag2 = false;
            if (!flag2)
            {
              int tfacing = 1;
              do
              {
                coordinate = this.ai.game.HandyFunctionsObj.HexNeighbour(this.front.targetX, this.front.targetY, 0, tfacing);
                if (coordinate.onmap & coordinate.x <= this.Width & coordinate.y <= this.Height && this.ai.map.HexObj[coordinate.x, coordinate.y].UnitCounter > -1 && this.ai.game.Data.UnitObj[this.ai.map.HexObj[coordinate.x, coordinate.y].UnitList[0]].Regime != this.ai.game.Data.Turn)
                {
                  this.front.targetX = coordinate.x;
                  this.front.targetY = coordinate.y;
                  this.ai.game.Data.UnitObj[unitByAiid].DidMove = false;
                }
                tfacing += 1;
              }
              while (tfacing <= 6);
            }
          }
          if (!this.ai.game.Data.UnitObj[unitByAiid].DidMove)
          {
            int index2 = 0;
            while (this.MoveCostAttack[index1, index2].Value[this.front.targetX, this.front.targetY] > this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid))
            {
              index2 += 1;
              if (index2 > 5)
                goto label_24;
            }
            AIMove tempMove = AIMove::new();
            tempMove.UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid;
            if (this.ai.game.HandyFunctionsObj.HasHexNavyUnit(this.front.targetX, this.front.targetY))
            {
              tempMove.AttackOn.x = this.front.targetX;
              tempMove.AttackOn.y = this.front.targetY;
              tempMove.AttackOn.onmap = true;
            }
            else
              tempMove.AttackOn.onmap = false;
            this.MoveList.AddMove(ref tempMove);
            coordinate = this.MoveFromAttack[index1, index2].Value[tempMove.AttackOn.x, tempMove.AttackOn.y];
            if (coordinate.onmap)
            {
              tempMove.MoveTo.x = coordinate.x;
              tempMove.MoveTo.y = coordinate.y;
              tempMove.MoveTo.onmap = true;
            }
            flag1 = true;
label_24:
            if (!flag1)
            {
              int width = this.Width;
              int num2;
              for (int x1 = 0; x1 <= width; x1 += 1)
              {
                int height = this.Height;
                for (int y1 = 0; y1 <= height; y1 += 1)
                {
                  if (this.MoveCostMove[index1].Value[x1, y1] <= this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid))
                  {
                    int num3 = this.ai.game.HandyFunctionsObj.Distance(x1, y1, 0, this.front.targetX, this.front.targetY, 0, 99);
                    bool flag3 = true;
                    if (this.map.HexObj[x1, y1].UnitCounter > -1 && this.ai.game.Data.UnitObj[this.map.HexObj[x1, y1].UnitList[0]].Regime != this.ai.game.Data.Turn)
                      flag3 = false;
                    if (flag3 && num3 < num1)
                    {
                      num1 = num3;
                      tx = x1;
                      num2 = y1;
                    }
                  }
                }
              }
              if (tx > -1 && !(this.ai.game.Data.UnitObj[unitByAiid].X == tx & this.ai.game.Data.UnitObj[unitByAiid].Y == num2))
              {
                coordinate.onmap = true;
                coordinate.x = tx;
                coordinate.y = num2;
                if (coordinate.onmap)
                {
                  tempMove = AIMove::new();
                  tempMove.UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid;
                  tempMove.MoveTo.x = this.GetRealX(tx);
                  tempMove.MoveTo.y = num2 + this.Top;
                  tempMove.MoveTo.onmap = true;
                  this.MoveList.AddMove(ref tempMove);
                }
              }
            }
          }
        }
      }
    }

    pub void SetDefendMove(
      ref PassHexList passList,
      ref PassHexList tempPassList,
      ref PassHexList tryPassList,
      int stimulateDefend,
      bool MoveToFrontline = false,
      ref SimpleList excludeUnitAiId = null,
      int extraMoveIncentive = 0)
    {
      this.MoveList = AIMoveList::new();
      int num1 = 1;
      int num2 = 99999;
      this.triedX = -1;
      this.triedY = -1;
      if (this.front.FrontID == 4)
      {
        int num3 = num3;
      }
      float num4 = 4f;
      if (this.front.Stance == 2)
        num4 = 1.25f;
      if (this.front.FrontID == 651)
      {
        int num5 = num5;
      }
      int width = this.Width;
      int index1;
      int index2;
      int y1;
      for (index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int y2 = 0; y2 <= height; y2 += 1)
        {
          if (24 == index2 + this.Left & 16 == y1 + this.Top)
            index1 = index1;
          if (this.Owner.Value[index1, y2] == 1 | this.Owner.Value[index1, y2] == 3 | (this.Owner.Value[index1, y2] == 2 | this.Owner.Value[index1, y2] == 0) & this.allTroops.Value[index1, y2] == 0 & this.troopsstrength.Value[index1, y2] == 0 && this.FrontArea.Value[index1, y2] == this.front.FrontID | this.FrontAreaForAttack.Value[index1, y2] == this.front.FrontID && this.Owner.Value[index1, y2] == 1 | this.TroopsReach.Value[index1, y2] > 0)
          {
            int num6 = (int) Math.Round((double) (this.HexDefendedScore(index1, y2, -1, -1, 0, 0, true) - this.HexDefendImportance(index1, y2)) / 10.0);
            if (MoveToFrontline)
              num6 += (int) Math.Round(Math.Pow((double) ((this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index1), y2 + this.Top].UnitCounter + 1) * 5), 2.0));
            if (num6 < num2 && !passList.Exists(index1, y2, 2) && !tempPassList.Exists(index1, y2, 2) && !tryPassList.Exists(index1, y2, 2))
            {
              bool flag = false;
              int counter = this.front.units.counter;
              for (int index3 = 0; index3 <= counter; index3 += 1)
              {
                if (this.front.units.unr[index3] > -1 && this.MoveCostMove[index3].Value[index1, y2] < 999)
                {
                  if (Information.IsNothing((object) excludeUnitAiId))
                    flag = true;
                  else if (excludeUnitAiId.FindNr(this.front.units.AIid[index3]) == -1)
                    flag = true;
                }
              }
              if (flag)
              {
                if (this.Owner.Value[index1, y2] == 2 && this.ai.CustomCalls.TargetRegimeRelationIsActuallyNotWar(this.ai.game.Data.Turn, this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index1), y2 + this.Top].Regime, true))
                  num6 = -99999;
                if (num6 > -99999)
                {
                  num2 = num6;
                  index2 = index1;
                  y1 = y2;
                }
              }
            }
          }
        }
      }
      int num7 = 0;
      if (num2 < 9999)
      {
        this.triedX = index2;
        this.triedY = y1;
        if (this.enemyDistance.Value[this.triedX, this.triedY] > 5)
          index2 = index2;
        UnitList unitList = UnitList::new();
        int[,] numArray1 = new int[this.Width + 1, this.Height + 1];
        bool flag1;
        do
        {
          flag1 = false;
          int num8 = 9999999;
          int counter = this.front.units.counter;
          int otherForcesMovedIn;
          int index4;
          Coordinate coordinate;
          int tdata;
          for (int index5 = 0; index5 <= counter; index5 += 1)
          {
            int index6 = this.front.units.unr[index5];
            if (!Information.IsNothing((object) excludeUnitAiId) && excludeUnitAiId.FindNr(this.front.units.AIid[index5]) > -1)
              index6 = -1;
            if (index6 > -1 && !Information.IsNothing((object) this.ai.game.Data.UnitObj[index6].tempCoords) && this.ai.game.Data.UnitObj[index6].tempCoords.FindSlot(index2 + this.Left, y1 + this.Top, 0) > -1)
              index6 = -1;
            if (index6 > -1)
            {
              if (index6 == 171 | index6 == 125)
                index6 = index6;
              if (index6 == 220)
                index6 = index6;
              if (!unitList.CheckIfPresent(index6) & !(this.GetRealX(index2) == DrawMod.TGame.Data.UnitObj[index6].X & y1 + this.Top == DrawMod.TGame.Data.UnitObj[index6].Y) && this.MoveCostMove[index5].Value[index2, y1] < 999 & !this.ai.game.Data.UnitObj[index6].TempAIForbidsMove)
              {
                int num9 = this.MoveCostMove[index5].Value[index2, y1] - this.ai.game.HandyFunctionsObj.GetLowestAp(index6);
                bool flag2 = true;
                if (extraMoveIncentive > 0)
                  flag2 = false;
                if (flag2 && !(index2 == this.GetMatrixX(this.ai.game.Data.UnitObj[index6].X) & y1 == this.ai.game.Data.UnitObj[index6].Y - this.Top))
                {
                  num9 += (int) Math.Round((double) ((float) this.ai.game.HandyFunctionsObj.GetAverageEntrench(index6) / num4));
                  if (this.front.Stance == 2 && this.enemyDistance.Value[this.GetMatrixX(this.ai.game.Data.UnitObj[index6].X), this.ai.game.Data.UnitObj[index6].Y - this.Top] == 1)
                    num9 = num9 + (int) Math.Round((double) ((float) this.ai.game.HandyFunctionsObj.GetAverageEntrench(index6) / num4)) + (int) Math.Round((double) ((float) this.ai.game.HandyFunctionsObj.GetAverageEntrench(index6) / num4));
                }
                if ((extraMoveIncentive > 0 | num9 < num8) & !(this.ai.game.Data.UnitObj[index6].TempProtector & extraMoveIncentive < 1))
                {
                  if (index2 + this.Left == 50 & y1 + this.Top == 5)
                    index1 = index1;
                  int index7 = this.GetMatrixX(this.ai.game.Data.UnitObj[index6].X);
                  int y3 = this.ai.game.Data.UnitObj[index6].Y - this.Top;
                  if (!MoveToFrontline | !this.ai.game.Data.UnitObj[index6].DidMove & !this.ai.game.Data.UnitObj[index6].DidAttack | this.FrontArea.Value[index7, y3] != this.front.FrontID)
                  {
                    bool flag3 = true;
                    if (MoveToFrontline && this.enemyPressureFull.Value[index7, y3] > this.enemyPressureFull.Value[index2, y1])
                      flag3 = false;
                    if (num2 < 0)
                      flag3 = true;
                    else if (this.ai.game.Data.UnitObj[index6].FreeCombatY > -1)
                      flag3 = true;
                    if (flag3 && !(index7 == index2 & y3 == y1))
                    {
                      int num10 = this.HexDefendedScore(index7, y3, -1, index6, numArray1[index7, y3], 0, false);
                      int num11 = this.HexDefendedScore(index7, y3, -1, -1, 0, 0, false);
                      int num12 = this.HexDefendImportance(index7, y3);
                      int num13 = num10 - num12;
                      int num14 = num11 - num12;
                      if (this.friendlySupplyIdeal.Value[index7, y3] > this.ai.VAR_SUPPLY_25PERCENT_RANGE)
                        num13 += 200;
                      if (this.friendlySupplyIdeal.Value[index7, y3] > this.ai.VAR_SUPPLY_50PERCENT_RANGE)
                        num13 += 100;
                      if (this.friendlySupplyIdeal.Value[index7, y3] > this.ai.VAR_SUPPLY_75PERCENT_RANGE)
                        num13 += 50;
                      if (this.friendlySupplyIdeal.Value[index7, y3] > this.ai.VAR_SUPPLY_25PERCENT_RANGE)
                        num13 *= 2;
                      if (this.friendlySupplyIdeal.Value[index7, y3] > this.ai.VAR_SUPPLY_50PERCENT_RANGE)
                        num13 = (int) Math.Round((double) num13 * 1.5);
                      if (this.friendlySupplyIdeal.Value[index7, y3] > this.ai.VAR_SUPPLY_75PERCENT_RANGE)
                        num13 = (int) Math.Round((double) num13 * 1.25);
                      int num15 = this.HexDefendedScore(index2, y1, index6, -1, 0, otherForcesMovedIn, false);
                      int num16 = this.HexDefendedScore(index2, y1, -1, -1, 0, 0, false);
                      int num17 = this.HexDefendImportance(index2, y1);
                      int num18 = num15 - num17;
                      int val2 = num16 - num17;
                      if (index6 == 118)
                        index6 = index6;
                      if (index7 + this.Left == 8 & y3 + this.Top == 6 & index2 == 7 & y1 == 5 & index6 == 118)
                        index7 = index7;
                      if (this.friendlySupplyIdeal.Value[index2, y1] > this.ai.VAR_SUPPLY_25PERCENT_RANGE)
                        num18 += 200;
                      if (this.friendlySupplyIdeal.Value[index2, y1] > this.ai.VAR_SUPPLY_50PERCENT_RANGE)
                        num18 += 100;
                      if (this.friendlySupplyIdeal.Value[index2, y1] > this.ai.VAR_SUPPLY_75PERCENT_RANGE)
                        num18 += 50;
                      if (this.friendlySupplyIdeal.Value[index2, y1] > this.ai.VAR_SUPPLY_25PERCENT_RANGE)
                        num18 *= 2;
                      if (this.friendlySupplyIdeal.Value[index2, y1] > this.ai.VAR_SUPPLY_50PERCENT_RANGE)
                        num18 = (int) Math.Round((double) num18 * 1.5);
                      if (this.friendlySupplyIdeal.Value[index2, y1] > this.ai.VAR_SUPPLY_75PERCENT_RANGE)
                        num18 = (int) Math.Round((double) num18 * 1.25);
                      if (num13 > 0)
                        num13 -= (int) Math.Round((double) num13 / 20.0 * (double) this.CountUnitsWithSameHistoricalNearHex(index6, this.GetRealX(index7), y3 + this.Top));
                      int val1 = num18 - (int) Math.Round((double) num18 / 20.0 * (double) this.CountUnitsWithSameHistoricalNearHex(index6, this.GetRealX(index2), y1 + this.Top));
                      if (this.ai.game.HandyFunctionsObj.GetHexStackPts(this.GetRealX(index2), y1 + this.Top, 0) + this.ai.game.HandyFunctionsObj.GetUnitStackPts(index6) > this.ai.VAR_HEX_STACK_REGULAR)
                        val1 = (int) Math.Round((double) (val1 * (this.ai.game.HandyFunctionsObj.GetHexStackPts(this.GetRealX(index2), y1 + this.Top, 0) + this.ai.game.HandyFunctionsObj.GetUnitStackPts(index6))) / ((double) this.ai.VAR_HEX_STACK_REGULAR * 1.25));
                      int num19 = stimulateDefend;
                      if (extraMoveIncentive < 1 && this.front.Stance == 2 & this.FrontArea.Value[index7, y3] == this.front.FrontID && this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index7), y3 + this.Top].UnitCounter <= 0)
                      {
                        if (this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(index7), y3 + this.Top] < this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(index2), y1 + this.Top])
                        {
                          if (this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(index7), y3 + this.Top] <= 50 & this.LowestRetreatModifierAllowed <= 50)
                            num19 = -9999999;
                        }
                        else if (this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(index7), y3 + this.Top] - 25 <= this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(index2), y1 + this.Top] && this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(index7), y3 + this.Top] <= 50 & this.LowestRetreatModifierAllowed <= 50)
                        {
                          if (this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index7), y3 + this.Top].Location > -1 && this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(index2), y1 + this.Top].Location == -1)
                            num19 = -9999999;
                          if (this.ai.game.HandyFunctionsObj.GetAverageEntrench(index6) >= 100)
                            num19 = -9999999;
                          if (this.ai.game.HandyFunctionsObj.HasHexBridge(this.GetRealX(index7), y3 + this.Top, 0) | this.ai.game.HandyFunctionsObj.HasHexBrokenBridge(this.GetRealX(index7), y3 + this.Top, 0) && !this.ai.game.HandyFunctionsObj.HasHexBridge(this.GetRealX(index2), y1 + this.Top, 0) & !this.ai.game.HandyFunctionsObj.HasHexBrokenBridge(this.GetRealX(index2), y1 + this.Top, 0))
                            num19 = -9999999;
                        }
                      }
                      if (this.enemyDistance.Value[index7, y3] <= this.enemyDistance.Value[index2, y1])
                      {
                        int averageEntrench = this.ai.game.HandyFunctionsObj.GetAverageEntrench(index6);
                        if (num13 > 100 & val1 > 100 & averageEntrench > 50)
                        {
                          int num20 = averageEntrench - 50;
                          float num21;
                          if (this.front.Stance == 3)
                          {
                            num21 = (float) (num13 + val1 - 200) / 500f;
                            if ((double) num21 > 1.0)
                              num21 = 1f;
                          }
                          else
                          {
                            num21 = (float) (num13 + val1 - 200) / 200f;
                            if ((double) num21 > 2.0)
                              num21 = 2f;
                          }
                          val1 += (int) Math.Round((double) (num21 * (float) num20));
                        }
                      }
                      float num22 = 1f;
                      int num23 = stimulateDefend;
                      int num24 = Math.Abs(num13 - num14);
                      int num25 = Math.Abs(val1 - val2);
                      int num26 = Math.Abs(num14 - val2);
                      if (num26 > 0)
                      {
                        if (num24 < 1)
                          num24 = 1;
                        if (num25 < 1)
                          num25 = 1;
                        if (num25 > num24)
                        {
                          int num27 = (num26 - (int) Math.Round((double) (num26 * num24) / (double) num25)) * 2;
                          if (num27 < 500)
                            index5 = index5;
                          if (num27 > 0)
                          {
                            num23 += Math.Abs(num27);
                            if (this.Owner.Value[index2, y1] == 2)
                              val1 = Math.Min(val1, val2);
                          }
                        }
                      }
                      if (this.front.Stance == 3 & num23 == 0)
                      {
                        int num28 = Math.Abs(num13 - val2);
                        int num29 = Math.Abs(num14 - val1);
                        int num30 = Math.Abs(num14 - val2);
                        if (num30 > 0)
                        {
                          if (num28 < 1)
                            num28 = 1;
                          if (num29 < 1)
                            num29 = 1;
                          if (num29 > num28)
                          {
                            int num31 = (num30 - (int) Math.Round((double) (num30 * num28) / (double) num29)) * 2;
                            if (num31 < 500)
                              index5 = index5;
                            if (num31 > 0)
                            {
                              num23 += Math.Abs(num31);
                              val1 = Math.Min(val1, val2);
                            }
                          }
                        }
                      }
                      if (num19 >= 0 && (double) (num13 + num23 + extraMoveIncentive) * (double) num22 >= (double) val1)
                      {
                        num8 = num9;
                        index4 = index6;
                        coordinate = this.MoveFromMove[index5].Value[index2, y1];
                        tdata = index5;
                      }
                    }
                  }
                }
              }
            }
          }
          if (num8 < 999)
          {
            num7 += num8;
            unitList.add(index4, tdata);
            int x = this.ai.game.Data.UnitObj[index4].X;
            int y4 = this.ai.game.Data.UnitObj[index4].Y;
            if (!(coordinate.x + this.Left == x & coordinate.y + this.Top == y4))
            {
              int[,] numArray2 = numArray1;
              int[,] numArray3 = numArray2;
              int matrixX = this.GetMatrixX(x);
              int index8 = matrixX;
              int index9 = y4 - this.Top;
              int index10 = index9;
              int num32 = numArray2[matrixX, index9] + this.ai.game.Data.UnitObj[index4].TempUnitPower;
              numArray3[index8, index10] = num32;
            }
            otherForcesMovedIn += (int) Math.Round((double) this.ai.game.Data.UnitObj[index4].TempUnitPower / ((double) Math.Max(100, 60 + this.ai.game.HandyFunctionsObj.GetAverageEntrench(index4)) / 100.0));
            flag1 = true;
          }
          if (unitList.counter + 1 >= num1)
            flag1 = false;
        }
        while (flag1);
        if (unitList.counter == -1 & index2 + this.Left == 17 & y1 + this.Top == 8 & this.front.FrontID == 1749)
          ;
        if (unitList.counter > -1)
        {
          int counter = unitList.counter;
          for (int index11 = 0; index11 <= counter; index11 += 1)
          {
            int unr = unitList.unr[index11];
            int index12 = unitList.data[index11];
            Coordinate coordinate;
            coordinate.onmap = true;
            coordinate.x = index2;
            coordinate.y = y1;
            int tx = index2;
            int num33 = y1;
            if (MoveToFrontline)
            {
              for (int index13 = 0; coordinate.onmap & coordinate.x > -1 & coordinate.y > -1 & coordinate.x <= this.Width & coordinate.y <= this.Height & index13 < 99; coordinate = this.MoveFromMove[index12].Value[coordinate.x, coordinate.y])
              {
                index13 += 1;
                if (this.MoveCostMove[index12].Value[coordinate.x, coordinate.y] <= this.ai.game.HandyFunctionsObj.GetLowestAp(unr))
                  break;
              }
              index2 = coordinate.x;
              y1 = coordinate.y;
            }
            if (coordinate.onmap)
            {
              if (this.GetRealX(index2) == this.ai.game.Data.UnitObj[unr].X & y1 + this.Top == this.ai.game.Data.UnitObj[unr].Y)
                this.ai.game.Data.UnitObj[unr].TempAIForbidsMove = true;
              AIMove tempMove = AIMove::new();
              if (unr == 150)
                unr = unr;
              tempMove.UnitAIid = this.ai.game.Data.UnitObj[unr].AIid;
              tempMove.MoveTo.x = this.GetRealX(index2);
              tempMove.MoveTo.y = y1 + this.Top;
              tempMove.MoveTo.onmap = true;
              if (MoveToFrontline & tx > -1)
              {
                tempMove.finalTo.x = this.GetRealX(tx);
                tempMove.finalTo.y = num33 + this.Top;
                tempMove.finalTo.onmap = true;
              }
              this.MoveList.AddMove(ref tempMove);
            }
          }
        }
        else
          passList.AddCoord(index2, y1, 2);
      }
      if (this.MoveList.Counter <= -1)
        return;
      if (this.front.Stance == 2)
        num2 += 2 * num7;
      if (this.front.Stance == 3)
        num2 += 1 * num7;
      if (num2 > 200)
        num2 = 200 + (int) Math.Round(Math.Sqrt((double) (num2 - 200)) * 10.0);
      if (num2 > 400)
        num2 = 400 + (int) Math.Round(Math.Sqrt((double) (num2 - 400)) * 2.0);
      this.Score = 500 - num2 - stimulateDefend * 2;
      this.Score = !MoveToFrontline ? (int) Math.Round((double) this.Score / 5.0) : (int) Math.Round((double) this.Score / 4.0);
      if (0 > this.Score)
        this.Score = 0;
      this.Score += 0;
    }

    pub void SetDefendArtMove(
      ref PassHexList passList,
      ref PassHexList tempPassList,
      ref PassHexList tryPassList,
      int stimulateDefend,
      bool MoveToFrontline = false)
    {
      this.MoveList = AIMoveList::new();
      int num1 = 9999;
      this.triedX = -1;
      this.triedY = -1;
      int num2 = 2;
      int unr1;
      if (DrawMod.TGame.Data.Product >= 6)
      {
        num2 = 99;
        int counter = this.front.artUnits.counter;
        for (int index = 0; index <= counter; index += 1)
        {
          unr1 = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.artUnits.AIid[index]);
          if (unr1 > -1 && this.ai.game.Data.UnitObj[unr1].TempCategory == 2)
          {
            int maxArtRange = DrawMod.TGame.HandyFunctionsObj.GetMaxArtRange(unr1, 0);
            if (maxArtRange < num2)
              num2 = maxArtRange;
          }
        }
        if (num2 < 1)
          num2 = 1;
      }
      int width = this.Width;
      int index1;
      int y1;
      for (int x = 0; x <= width; x += 1)
      {
        int height = this.Height;
        for (int y2 = 0; y2 <= height; y2 += 1)
        {
          if (this.Owner.Value[x, y2] == 1 && this.FrontArea.Value[x, y2] == this.front.FrontID | this.FrontAreaForAttack.Value[x, y2] == this.front.FrontID & this.allTroops.Value[x, y2] == 0)
          {
            int num3 = 0;
            if (num2 >= 1)
              num3 = this.enemyDistance.Value[x, y2] != num2 ? (this.enemyDistance.Value[x, y2] >= num2 ? (this.enemyDistance.Value[x, y2] != num2 + 1 ? (this.enemyDistance.Value[x, y2] != num2 + 2 ? (this.enemyDistance.Value[x, y2] != num2 + 3 ? 300 : 200) : 100) : 50) : 200) : 0;
            if (this.ai.game.Data.MapObj[0].HexObj[x, y2].UnitCounter == 0)
              num3 -= 60;
            else if (this.ai.game.Data.MapObj[0].HexObj[x, y2].UnitCounter == 1)
              num3 -= 110;
            else if (this.ai.game.Data.MapObj[0].HexObj[x, y2].UnitCounter == 2)
              num3 -= 140;
            else if (this.ai.game.Data.MapObj[0].HexObj[x, y2].UnitCounter > 2)
              num3 -= 160;
            unr1 = num3 - (int) Math.Round((double) this.HexDefendImportance(x, y2) / 10.0);
            if (unr1 < num1 && !passList.Exists(x, y2, 2) && !tempPassList.Exists(x, y2, 2) && !tryPassList.Exists(x, y2, 2))
            {
              bool flag = false;
              int counter = this.front.artUnits.counter;
              for (int index2 = 0; index2 <= counter; index2 += 1)
              {
                int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.artUnits.AIid[index2]);
                if (!MoveToFrontline | !this.ai.game.Data.UnitObj[unitByAiid].DidMove & !this.ai.game.Data.UnitObj[unitByAiid].DidAttack)
                {
                  if (this.MoveCostArtMove[index2].Value[x, y2] <= DrawMod.TGame.HandyFunctionsObj.GetLowestAp(unitByAiid))
                    flag = true;
                  else if (this.MoveCostArtMove[index2].Value[x, y2] < 999)
                  {
                    flag = true;
                    unr1 += 2 * this.MoveCostArtMove[index2].Value[x, y2];
                  }
                  else
                    flag = false;
                }
              }
              if (unr1 < num1 && flag)
              {
                num1 = unr1;
                index1 = x;
                y1 = y2;
              }
            }
          }
        }
      }
      if (num1 < 9999)
      {
        this.triedX = index1;
        this.triedY = y1;
        if (this.enemyDistance.Value[this.triedX, this.triedY] > 5)
          index1 = index1;
        UnitList unitList = UnitList::new();
        int[,] numArray = new int[this.Width + 1, this.Height + 1];
        do
        {
          int num4 = 9999;
          int counter = this.front.artUnits.counter;
          int tunr;
          int tdata;
          for (int index3 = 0; index3 <= counter; index3 += 1)
          {
            int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.artUnits.AIid[index3]);
            if (unitByAiid > -1 && this.ai.game.Data.UnitObj[unitByAiid].TempCategory == 2)
            {
              int num5 = 2;
              if (DrawMod.TGame.Data.Product >= 6)
              {
                num5 = DrawMod.TGame.HandyFunctionsObj.GetMaxArtRange(unitByAiid, 0);
                if (num5 < 1)
                  num5 = 1;
              }
              if (!unitList.CheckIfPresent(unitByAiid) && this.MoveCostArtMove[index3].Value[index1, y1] < num4 && !MoveToFrontline | !this.ai.game.Data.UnitObj[unitByAiid].DidMove & !this.ai.game.Data.UnitObj[unitByAiid].DidAttack)
              {
                int matrixX = this.GetMatrixX(this.ai.game.Data.UnitObj[unitByAiid].X);
                int y3 = this.ai.game.Data.UnitObj[unitByAiid].Y - this.Top;
                if (!(matrixX == index1 & y3 == y1))
                {
                  if (num5 >= 1)
                    unr1 = this.enemyDistance.Value[matrixX, y3] != num5 ? (this.enemyDistance.Value[matrixX, y3] >= num5 ? (this.enemyDistance.Value[matrixX, y3] != num5 + 1 ? (this.enemyDistance.Value[matrixX, y3] != num5 + 2 ? (this.enemyDistance.Value[matrixX, y3] != num5 + 3 ? 300 : 200) : 100) : 50) : 200) : 0;
                  if (this.ai.game.Data.MapObj[0].HexObj[matrixX, y3].UnitCounter == 0)
                    unr1 -= 60;
                  else if (this.ai.game.Data.MapObj[0].HexObj[matrixX, y3].UnitCounter == 1)
                    unr1 -= 100;
                  else if (this.ai.game.Data.MapObj[0].HexObj[matrixX, y3].UnitCounter == 2)
                    unr1 -= 130;
                  else if (this.ai.game.Data.MapObj[0].HexObj[matrixX, y3].UnitCounter > 2)
                    unr1 -= 145;
                  unr1 = unr1 - (int) Math.Round((double) this.HexDefendImportance(matrixX, y3) / 10.0) - (int) Math.Round((double) this.MoveCostArtMove[index3].Value[index1, y1] / 5.0);
                  int num6 = unr1;
                  if (num1 < num6 & num4 > this.MoveCostArtMove[index3].Value[index1, y1])
                  {
                    num4 = this.MoveCostArtMove[index3].Value[index1, y1];
                    tunr = unitByAiid;
                    Coordinate coordinate = this.MoveFromArtMove[index3].Value[index1, y1];
                    tdata = index3;
                  }
                }
              }
            }
          }
          if (num4 < 999)
            unitList.add(tunr, tdata);
        }
        while (false);
        if (unitList.counter > -1)
        {
          int counter = unitList.counter;
          for (int index4 = 0; index4 <= counter; index4 += 1)
          {
            int unr2 = unitList.unr[index4];
            int num7 = unitList.data[index4];
            Coordinate coordinate;
            coordinate.onmap = true;
            coordinate.x = index1;
            coordinate.y = y1;
            if (MoveToFrontline)
            {
              for (int index5 = 0; coordinate.onmap & index5 < 99; coordinate = this.MoveFromArtMove[index4].Value[coordinate.x, coordinate.y])
              {
                index5 += 1;
                if (this.MoveCostArtMove[index4].Value[coordinate.x, coordinate.y] <= this.ai.game.HandyFunctionsObj.GetLowestAp(unr2))
                  break;
              }
              index1 = coordinate.x;
              y1 = coordinate.y;
            }
            if (coordinate.onmap)
            {
              this.MoveList.AddMove(ref AIMove::new()
              {
                UnitAIid = this.ai.game.Data.UnitObj[unr2].AIid,
                IsArt = true,
                MoveTo = {
                  x = this.GetRealX(index1),
                  y = y1 + this.Top,
                  onmap = true
                }
              });
              this.MoveList.ArtPresent = true;
            }
          }
        }
        else
          passList.AddCoord(index1, y1, 2);
      }
      if (this.MoveList.Counter <= -1)
        return;
      this.Score = 200 - num1 - stimulateDefend * 2;
      if (0 <= this.Score)
        return;
      this.Score = 0;
    }

    pub void SetDefendFlakMove(
      ref PassHexList passList,
      ref PassHexList tempPassList,
      ref PassHexList tryPassList,
      int stimulateDefend,
      bool MoveToFrontline = false)
    {
      this.MoveList = AIMoveList::new();
      int num1 = 9999;
      this.triedX = -1;
      this.triedY = -1;
      int num2 = 2;
      int unr1;
      if (DrawMod.TGame.Data.Product >= 6)
      {
        num2 = 99;
        int counter = this.front.artUnits.counter;
        for (int index = 0; index <= counter; index += 1)
        {
          unr1 = this.front.artUnits.unr[index];
          if (unr1 > -1 && this.ai.game.Data.UnitObj[unr1].TempCategory == 5)
          {
            int maxAaRange = DrawMod.TGame.HandyFunctionsObj.GetMaxAARange(unr1);
            if (maxAaRange < num2)
              num2 = maxAaRange;
          }
        }
        if (num2 < 1)
          num2 = 0;
      }
      if (num2 == 99)
        return;
      int width = this.Width;
      int index1;
      int y1;
      for (int index2 = 0; index2 <= width; index2 += 1)
      {
        int height = this.Height;
        for (int y2 = 0; y2 <= height; y2 += 1)
        {
          if (this.Owner.Value[index2, y2] == 1 && this.FrontArea.Value[index2, y2] == this.front.FrontID | this.FrontAreaForAttack.Value[index2, y2] == this.front.FrontID & this.allTroops.Value[index2, y2] == 0)
          {
            int num3 = 700;
            if (num2 >= 1 && this.enemyDistance.Value[index2, y2] < num2 + 1)
              num3 += 200;
            if (this.ai.game.Data.MapObj[0].HexObj[index2, y2].UnitCounter == 0)
              num3 -= 60;
            else if (this.ai.game.Data.MapObj[0].HexObj[index2, y2].UnitCounter == 1)
              num3 -= 110;
            else if (this.ai.game.Data.MapObj[0].HexObj[index2, y2].UnitCounter == 2)
              num3 -= 140;
            else if (this.ai.game.Data.MapObj[0].HexObj[index2, y2].UnitCounter > 2)
              num3 -= 160;
            int num4 = 0;
            if (this.front.units.counter > -1)
            {
              int counter = this.front.units.counter;
              for (int index3 = 0; index3 <= counter; index3 += 1)
              {
                int index4 = this.front.units.unr[index3];
                if (index4 > -1 && this.ai.game.HandyFunctionsObj.Distance(this.GetRealX(index2), y2 + this.Top, 0, this.ai.game.Data.UnitObj[index4].X, this.ai.game.Data.UnitObj[index4].Y, 0) <= num2)
                  num4 += 1;
              }
              num3 -= (int) Math.Round((double) num3 * 0.75 * (double) num4 / (double) (this.front.units.counter + 1));
            }
            unr1 = num3 - (int) Math.Round((double) this.HexDefendImportance(index2, y2) / 10.0);
            if (unr1 < num1 && !passList.Exists(index2, y2, 2) && !tempPassList.Exists(index2, y2, 2) && !tryPassList.Exists(index2, y2, 2))
            {
              bool flag = false;
              int counter = this.front.artUnits.counter;
              for (int index5 = 0; index5 <= counter; index5 += 1)
              {
                int unr2 = this.front.artUnits.unr[index5];
                if (!MoveToFrontline | !this.ai.game.Data.UnitObj[unr2].DidMove & !this.ai.game.Data.UnitObj[unr2].DidAttack)
                {
                  if (this.MoveCostArtMove[index5].Value[index2, y2] <= DrawMod.TGame.HandyFunctionsObj.GetLowestAp(unr2))
                    flag = true;
                  else if (this.MoveCostArtMove[index5].Value[index2, y2] < 999)
                  {
                    flag = true;
                    unr1 += 2 * this.MoveCostArtMove[index5].Value[index2, y2];
                  }
                  else
                    flag = false;
                }
              }
              if (unr1 < num1 && flag)
              {
                num1 = unr1;
                index1 = index2;
                y1 = y2;
              }
            }
          }
        }
      }
      if (num1 < 9999)
      {
        this.triedX = index1;
        this.triedY = y1;
        if (this.enemyDistance.Value[this.triedX, this.triedY] > 5)
          index1 = index1;
        UnitList unitList = UnitList::new();
        int[,] numArray = new int[this.Width + 1, this.Height + 1];
        do
        {
          int num5 = 9999;
          int counter = this.front.artUnits.counter;
          int tunr;
          int tdata;
          for (int index6 = 0; index6 <= counter; index6 += 1)
          {
            int index7 = this.front.artUnits.unr[index6];
            if (index7 > -1 && this.ai.game.Data.UnitObj[index7].TempCategory == 5)
            {
              int num6 = 2;
              if (DrawMod.TGame.Data.Product >= 6)
              {
                num6 = DrawMod.TGame.HandyFunctionsObj.GetMaxAARange(index7);
                if (num6 < 1)
                  num6 = 0;
              }
              if (!unitList.CheckIfPresent(index7) && this.MoveCostArtMove[index6].Value[index1, y1] < num5 && !MoveToFrontline | !this.ai.game.Data.UnitObj[index7].DidMove & !this.ai.game.Data.UnitObj[index7].DidAttack)
              {
                int matrixX = this.GetMatrixX(this.ai.game.Data.UnitObj[index7].X);
                int y3 = this.ai.game.Data.UnitObj[index7].Y - this.Top;
                if (!(matrixX == index1 & y3 == y1))
                {
                  if (num6 >= 1 && this.enemyDistance.Value[matrixX, y3] < num6 + 1)
                    unr1 = 200;
                  unr1 = unr1 - (int) Math.Round((double) this.HexDefendImportance(matrixX, y3) / 10.0) - (int) Math.Round((double) this.MoveCostArtMove[index6].Value[index1, y1] / 5.0);
                  if (num5 > this.MoveCostArtMove[index6].Value[index1, y1])
                  {
                    num5 = this.MoveCostArtMove[index6].Value[index1, y1];
                    tunr = index7;
                    Coordinate coordinate = this.MoveFromArtMove[index6].Value[index1, y1];
                    tdata = index6;
                  }
                }
              }
            }
          }
          if (num5 < 999)
            unitList.add(tunr, tdata);
        }
        while (false);
        if (unitList.counter > -1)
        {
          int counter = unitList.counter;
          for (int index8 = 0; index8 <= counter; index8 += 1)
          {
            int unr3 = unitList.unr[index8];
            int num7 = unitList.data[index8];
            Coordinate coordinate;
            coordinate.onmap = true;
            coordinate.x = index1;
            coordinate.y = y1;
            if (MoveToFrontline)
            {
              for (int index9 = 0; coordinate.onmap & index9 < 99; coordinate = this.MoveFromArtMove[index8].Value[coordinate.x, coordinate.y])
              {
                index9 += 1;
                if (this.MoveCostArtMove[index8].Value[coordinate.x, coordinate.y] <= this.ai.game.HandyFunctionsObj.GetLowestAp(unr3))
                  break;
              }
              index1 = coordinate.x;
              y1 = coordinate.y;
            }
            if (coordinate.onmap)
            {
              this.MoveList.AddMove(ref AIMove::new()
              {
                UnitAIid = this.ai.game.Data.UnitObj[unr3].AIid,
                IsArt = true,
                MoveTo = {
                  x = this.GetRealX(index1),
                  y = y1 + this.Top,
                  onmap = true
                }
              });
              this.MoveList.ArtPresent = true;
            }
          }
        }
        else
          passList.AddCoord(index1, y1, 2);
      }
      if (this.MoveList.Counter <= -1)
        return;
      this.Score = 200 - num1 - stimulateDefend * 2;
      if (0 <= this.Score)
        return;
      this.Score = 0;
    }

    pub void SetRetreatDefendMove(
      ref PassHexList passList,
      ref PassHexList tempPassList,
      ref PassHexList tryPassList,
      int stimulateDefend,
      bool MoveToFrontline = false,
      int MaxDist = 3,
      bool blockAlreadyMoved = false)
    {
      this.MoveList = AIMoveList::new();
      this.triedX = -1;
      this.triedY = -1;
      DC2AIClass ai = this.ai;
      AITheater aiTheater = this;
      ref AITheater local1 = ref aiTheater;
      ref AIMatrix local2 = ref this.Owner;
      int frontId = this.front.FrontID;
      AIMatrix aiMatrix1 = ai.SetFrontAreaMatrix(ref local1, ref local2, frontId, true);
      int counter1 = this.frontList.Counter;
      for (int index = 0; index <= counter1; index += 1)
      {
        if (this.frontList.Front[index].Stance == 1 | this.frontList.Front[index].Stance == 4)
          aiMatrix1.SetValueXToValueY(this.frontList.Front[index].FrontID, this.front.FrontID);
      }
      aiMatrix1.SetAllValuesNotValueXTo(0, this.front.FrontID);
      aiMatrix1.SetValueXToValueY(this.front.FrontID, 1);
      aiMatrix1.ExpandAndAddValueForSameRegime(99);
      aiMatrix1.RemoveValuesByMask(this.Owner, 2);
      aiMatrix1.MultiplyAllValues(1000);
      aiMatrix1.RemoveValuesByMask(this.enemyDistance, 1);
      AIMatrix aiMatrix2 = aiMatrix1.AverageValuesForSameRegime(5, this.Owner);
      int num1 = 0;
      int num2 = 999999;
      int num3 = 0;
      int num4 = 0;
      int num5 = 0;
      int width1 = this.Width;
      for (int index1 = 0; index1 <= width1; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (this.FriendlySupply.Value[index1, index2] < this.ai.VAR_SUPPLY_25PERCENT_RANGE && this.enemyDistance.Value[index1, index2] >= 1 & this.enemyDistance.Value[index1, index2] <= 5)
          {
            if (this.FrontArea.Value[index1, index2] == this.front.FrontID)
            {
              if (aiMatrix2.Value[index1, index2] > num1)
                num1 = aiMatrix2.Value[index1, index2];
              if (aiMatrix2.Value[index1, index2] > 0 & aiMatrix2.Value[index1, index2] < num2)
                num2 = aiMatrix2.Value[index1, index2];
            }
            if (aiMatrix2.Value[index1, index2] > num3)
              num3 = aiMatrix2.Value[index1, index2];
            if (this.enemyDistance.Value[index1, index2] == 1 & aiMatrix2.Value[index1, index2] > 0)
            {
              num4 += aiMatrix2.Value[index1, index2];
              num5 += 1;
            }
          }
        }
      }
      if (num1 == 0)
      {
        int width2 = this.Width;
        for (int index3 = 0; index3 <= width2; index3 += 1)
        {
          int height = this.Height;
          for (int index4 = 0; index4 <= height; index4 += 1)
          {
            if (this.FrontArea.Value[index3, index4] == this.front.FrontID)
            {
              if (aiMatrix2.Value[index3, index4] > num1)
                num1 = aiMatrix2.Value[index3, index4];
              if (aiMatrix2.Value[index3, index4] > 0 & aiMatrix2.Value[index3, index4] < num2)
                num2 = aiMatrix2.Value[index3, index4];
            }
            if (aiMatrix2.Value[index3, index4] > num3)
              num3 = aiMatrix2.Value[index3, index4];
          }
        }
      }
      if (num5 > 0)
        num4 = (int) Math.Round((double) num4 / (double) num5);
      if ((double) num2 < (double) num1 / 4.0)
        num2 = (int) Math.Round((double) num1 / 4.0);
      if ((double) num2 < (double) num4 / 4.0)
        num2 = (int) Math.Round((double) num4 / 4.0);
      if ((double) num2 < (double) num3 / 24.0 & num1 * 3 < num3)
        num2 = (int) Math.Round((double) num3 / 24.0);
      int num6 = num2 + 100;
      if (this.front.FrontID == 232)
        ;
      int num7 = -9999;
      int counter2 = this.front.units.counter;
      int index5;
      int y1;
      for (int index6 = 0; index6 <= counter2; index6 += 1)
      {
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index6]);
        int matrixX = this.GetMatrixX(this.ai.game.Data.UnitObj[unitByAiid].X);
        int y2 = this.ai.game.Data.UnitObj[unitByAiid].Y - this.Top;
        if (!blockAlreadyMoved | !this.ai.game.Data.UnitObj[unitByAiid].DidMove && this.Owner.Value[matrixX, y2] == 1 | this.Owner.Value[matrixX, y2] == 3 & !this.ai.game.Data.UnitObj[unitByAiid].TempProtector && this.enemyDistance.Value[matrixX, y2] < MaxDist)
        {
          int num8 = this.enemyPressureFull.Value[matrixX, y2] + (int) Math.Round((double) this.EnemyPressure.Value[matrixX, y2] / 2.0);
          int num9 = num8 + (int) Math.Round((double) (num8 * this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(matrixX), y2 + this.Top]) / 400.0);
          if (this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(matrixX), y2 + this.Top].UnitCounter >= 0)
            num9 += (int) Math.Round((double) num9 * 0.25 * Math.Sqrt((double) (this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(matrixX), y2 + this.Top].UnitCounter + 1)));
          if (num9 > num7 && !passList.Exists(matrixX, y2, 2) && !tempPassList.Exists(matrixX, y2, 2) && !tryPassList.Exists(matrixX, y2, 2))
          {
            num7 = num9;
            index5 = matrixX;
            y1 = y2;
          }
        }
      }
      int num10 = 0;
      if (num7 > -9999)
      {
        num10 = num7;
        this.triedX = index5;
        this.triedY = y1;
        if (index5 == 18 & y1 == 15)
          index5 = index5;
        int counter3 = this.front.units.counter;
        for (int index7 = 0; index7 <= counter3; index7 += 1)
        {
          int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index7]);
          if (unitByAiid > -1)
          {
            int matrixX = this.GetMatrixX(this.ai.game.Data.UnitObj[unitByAiid].X);
            int index8 = this.ai.game.Data.UnitObj[unitByAiid].Y - this.Top;
            int num11 = -1;
            if (!blockAlreadyMoved | !this.ai.game.Data.UnitObj[unitByAiid].DidMove && matrixX == index5 & index8 == y1 & !this.ai.game.Data.UnitObj[unitByAiid].TempProtector)
            {
              int num12 = 99999999;
              int num13 = -1;
              int num14 = -1;
              int width3 = this.Width;
              for (int x = 0; x <= width3; x += 1)
              {
                int height = this.Height;
                for (int y3 = 0; y3 <= height; y3 += 1)
                {
                  if (this.Owner.Value[x, y3] == 1 && this.MoveCostMove[index7].Value[x, y3] <= 999)
                  {
                    Coordinate coordinate = Coordinate::new();
                    coordinate.x = x;
                    coordinate.y = y3;
                    coordinate.onmap = true;
                    coordinate.map = 0;
                    for (int index9 = 0; coordinate.onmap & index9 < 99 & coordinate.x <= this.Width & coordinate.y <= this.Height; index9 += 1)
                    {
                      if (this.MoveFromMove[index7].Value[coordinate.x, coordinate.y].x == matrixX & this.MoveFromMove[index7].Value[coordinate.x, coordinate.y].y == index8)
                        coordinate.onmap = false;
                      else if (this.MoveFromMove[index7].Value[coordinate.x, coordinate.y].onmap & this.MoveFromMove[index7].Value[coordinate.x, coordinate.y].x <= this.Width & this.MoveFromMove[index7].Value[coordinate.x, coordinate.y].y <= this.Height)
                        coordinate = this.MoveFromMove[index7].Value[coordinate.x, coordinate.y];
                      else
                        coordinate.onmap = false;
                    }
                    if (this.MoveCostMove[index7].Value[coordinate.x, coordinate.y] <= 999 && this.enemyDistance.Value[coordinate.x, coordinate.y] <= MaxDist)
                    {
                      int num15 = 250;
                      if (this.enemyDistance.Value[x, y3] == 1)
                        num15 = 250;
                      else if (this.enemyDistance.Value[x, y3] == 2)
                        num15 = 240;
                      else if (this.enemyDistance.Value[x, y3] == 3)
                        num15 = 230;
                      else if (this.enemyDistance.Value[x, y3] == 4)
                        num15 = 220;
                      else if (this.enemyDistance.Value[x, y3] >= 5)
                        num15 = 210;
                      if (num15 < 100)
                        num15 = 100;
                      if (num15 > 400)
                        num15 = 400;
                      int d = (int) Math.Round(Math.Sqrt((double) this.troopsstrength.Value[coordinate.x, coordinate.y]));
                      if (coordinate.x == matrixX & coordinate.y == index8)
                      {
                        d -= this.ai.game.Data.UnitObj[unitByAiid].TempUnitPowerAbs;
                        if (d < 0)
                          d = 0;
                      }
                      if (d > 0)
                        num15 += (int) Math.Round(Math.Sqrt((double) d));
                      if (this.EvacuateHex(x, y3))
                        num15 *= 3;
                      if (this.EvacuateHex(coordinate.x, coordinate.y))
                        num15 = (int) Math.Round((double) num15 * 1.3);
                      int num16 = num6 <= 0 ? num15 * 5 : ((double) aiMatrix2.Value[x, y3] >= (double) num6 * 0.5 ? ((double) aiMatrix2.Value[x, y3] >= (double) num6 * 0.65 ? ((double) aiMatrix2.Value[x, y3] >= (double) num6 * 0.8 ? ((double) aiMatrix2.Value[x, y3] >= (double) num6 * 0.95 ? ((double) aiMatrix2.Value[x, y3] >= (double) num6 * 1.1 ? ((double) aiMatrix2.Value[x, y3] >= (double) num6 * 1.25 ? ((double) aiMatrix2.Value[x, y3] >= (double) num6 * 1.5 ? ((double) aiMatrix2.Value[x, y3] >= (double) num6 * 1.75 ? (aiMatrix2.Value[x, y3] >= num6 * 2 ? ((double) aiMatrix2.Value[x, y3] >= (double) num6 * 2.5 ? ((double) aiMatrix2.Value[x, y3] >= (double) num6 * 3.5 ? ((double) aiMatrix2.Value[x, y3] >= (double) num6 * 4.5 ? (aiMatrix2.Value[x, y3] >= num6 * 6 ? (aiMatrix2.Value[x, y3] >= num6 * 8 ? num15 * 4 : (int) Math.Round((double) num15 * 2.5)) : (int) Math.Round((double) num15 * 1.5)) : (int) Math.Round((double) num15 * 1.0)) : (int) Math.Round((double) num15 * 0.5)) : (int) Math.Round((double) num15 * 1.25)) : num15 * 2) : (int) Math.Round((double) num15 * 2.75)) : (int) Math.Round((double) num15 * 3.5)) : (int) Math.Round((double) num15 * 4.25)) : num15 * 5) : num15 * 9) : num15 * 13) : num15 * 16) : num15 * 21);
                      if (!this.front.RealRetreat)
                      {
                        if (this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(coordinate.x), coordinate.y + this.Top] <= 25)
                          num16 += Math.Abs(num16) * 2;
                        else if (this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(coordinate.x), coordinate.y + this.Top] <= 50)
                          num16 += Math.Abs(num16) * 1;
                        else if (this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(coordinate.x), coordinate.y + this.Top] <= 75)
                          num16 += Math.Abs((int) Math.Round((double) num16 * 0.5));
                        if (this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(index5), y1 + this.Top] < this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(coordinate.x), coordinate.y + this.Top] && this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(index5), y1 + this.Top] <= 50 & this.LowestRetreatModifierAllowed <= 50 && (double) this.front.UnitCountRatio >= 0.4 | this.front.Strength != 1 | this.front.units.counter >= this.ai.VAR_FRONTLINE_MAX_LENGTH)
                          num16 = -99999;
                      }
                      if (aiMatrix2.Value[x, y3] > aiMatrix2.Value[matrixX, index8] && this.enemyDistance.Value[x, y3] > this.enemyDistance.Value[matrixX, index8] & this.enemyDistance.Value[index5, y1] >= 1)
                      {
                        int unitCounter = this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(coordinate.x), coordinate.y + this.Top].UnitCounter;
                        if (coordinate.x == matrixX & coordinate.y == index8)
                          --unitCounter;
                        if (unitCounter >= 0)
                          num16 += Math.Abs((int) Math.Round((double) num16 * Math.Sqrt((double) (1 * (unitCounter + 2)))));
                      }
                      if (this.MoveCostMove[index7].Value[coordinate.x, coordinate.y] == 0)
                        num16 = num16;
                      int num17 = num16 + this.MoveCostMove[index7].Value[x, y3] * 2;
                      if (num17 > -9999 & num17 < num12)
                      {
                        num13 = x;
                        num14 = y3;
                        num12 = num17;
                      }
                    }
                  }
                }
              }
              if (num13 > -1 & !(matrixX == num13 & index8 == num14))
              {
                Coordinate coordinate = Coordinate::new();
                coordinate.x = num13;
                coordinate.y = num14;
                coordinate.onmap = true;
                coordinate.map = 0;
                int num18 = 0;
                while (coordinate.onmap & num18 < 99)
                {
                  if (this.MoveFromMove[index7].Value[coordinate.x, coordinate.y].x == matrixX & this.MoveFromMove[index7].Value[coordinate.x, coordinate.y].y == index8)
                  {
                    coordinate.onmap = false;
                  }
                  else
                  {
                    if (this.MoveFromMove[index7].Value[coordinate.x, coordinate.y].onmap & this.MoveFromMove[index7].Value[coordinate.x, coordinate.y].x <= this.Width & this.MoveFromMove[index7].Value[coordinate.x, coordinate.y].y <= this.Height)
                      coordinate = this.MoveFromMove[index7].Value[coordinate.x, coordinate.y];
                    else
                      coordinate.onmap = false;
                    num18 += 1;
                  }
                }
                if (!(coordinate.x == matrixX & coordinate.y == index8))
                {
                  AIMove tempMove = AIMove::new();
                  tempMove.UnitAIid = this.ai.game.Data.UnitObj[unitByAiid].AIid;
                  tempMove.MoveTo.x = this.GetRealX(coordinate.x);
                  tempMove.MoveTo.y = coordinate.y + this.Top;
                  tempMove.MoveTo.onmap = true;
                  this.Score = 1000 - (int) Math.Round(Math.Sqrt((double) (num12 * 100)));
                  this.MoveList.AddMove(ref tempMove);
                  return;
                }
                num11 = num13;
              }
              else
                num11 = num13;
            }
          }
        }
        passList.AddCoord(index5, y1, 2);
      }
      this.Score = 0;
    }

    pub void SetDefendMoveBACKUP(ref PassHexList passList)
    {
      this.MoveList = AIMoveList::new();
      int num1 = 1;
      int num2 = -9999;
      int width = this.Width;
      int index1;
      int y1;
      for (int x = 0; x <= width; x += 1)
      {
        int height = this.Height;
        for (int y2 = 0; y2 <= height; y2 += 1)
        {
          if (this.Owner.Value[x, y2] == 1 && this.FrontArea.Value[x, y2] == this.front.FrontID && this.EnemyPressure.Value[x, y2] > 0)
          {
            int num3 = 0 + (int) Math.Round(100.0 * (10.0 / (double) this.ForceRatio.Value[x, y2]));
            if (num3 > num2 && !passList.Exists(x, y2, 2) && !this.EvacuateHex(x, y2))
            {
              num2 = num3;
              index1 = x;
              y1 = y2;
            }
          }
        }
      }
      if (num2 > -1)
      {
        UnitList unitList = UnitList::new();
        int num4 = this.troopsstrength.Value[index1, y1];
        int[,] numArray1 = new int[this.Width + 1, this.Height + 1];
        bool flag1;
        do
        {
          flag1 = false;
          int num5 = 9999;
          int counter = this.front.units.counter;
          int num6;
          int tunr;
          Coordinate coordinate;
          int tdata;
          for (int index2 = 0; index2 <= counter; index2 += 1)
          {
            int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index2]);
            if (unitByAiid > -1 && !unitList.CheckIfPresent(unitByAiid) && this.MoveCostMove[index2].Value[index1, y1] < num5)
            {
              int matrixX = this.GetMatrixX(this.ai.game.Data.UnitObj[unitByAiid].X);
              int y3 = this.ai.game.Data.UnitObj[unitByAiid].Y - this.Top;
              if (!(matrixX == index1 & y3 == y1))
              {
                bool flag2 = true;
                int num7 = this.EnemyPressure.Value[matrixX, y3];
                int num8 = this.troopsstrength.Value[matrixX, y3] - this.ai.game.Data.UnitObj[unitByAiid].TempUnitPower - numArray1[matrixX, y3];
                int num9 = num7 <= 0 ? 999 : (int) Math.Round((double) num8 / (double) num7 * 100.0);
                int num10 = this.EnemyPressure.Value[index1, y1];
                int num11 = this.troopsstrength.Value[index1, y1] + num6 + this.ai.game.Data.UnitObj[unitByAiid].TempUnitPower;
                int num12 = num10 <= 0 ? 999 : (int) Math.Round((double) num11 / (double) num10 * 100.0);
                if (num9 < num12)
                  flag2 = false;
                if (this.troopsstrength.Value[index1, y1] == 0 & num8 > 0)
                  flag2 = true;
                if (this.troopsstrength.Value[index1, y1] == 0 & num8 == 0 && this.FriendlyBottleneck.Value[index1, y1] > this.FriendlyBottleneck.Value[matrixX, y3])
                  flag2 = true;
                if (this.troopsstrength.Value[index1, y1] > 0 & this.FriendlyBottleneck.Value[index1, y1] > 35 & num8 == 0 && (double) this.FriendlyBottleneck.Value[index1, y1] / 3.0 > (double) this.FriendlyBottleneck.Value[matrixX, y3] && this.ForceRatio.Value[index1, y1] < 50)
                  flag2 = true;
                if (this.troopsstrength.Value[index1, y1] == 0 & this.FriendlyBottleneck.Value[matrixX, y3] > 35 && (double) this.FriendlyBottleneck.Value[matrixX, y3] / 3.0 > (double) this.FriendlyBottleneck.Value[index1, y1] && this.ForceRatio.Value[matrixX, y3] < 50)
                  flag2 = false;
                if (this.EvacuateHex(matrixX, y3) & num6 == 0)
                  flag2 = true;
                if (flag2)
                {
                  num5 = this.MoveCostMove[index2].Value[index1, y1];
                  tunr = unitByAiid;
                  coordinate = this.MoveFromMove[index2].Value[index1, y1];
                  tdata = index2;
                }
              }
            }
          }
          if (num5 < 999)
          {
            unitList.add(tunr, tdata);
            int matrixX = this.GetMatrixX(this.ai.game.Data.UnitObj[tunr].X);
            int num13 = this.ai.game.Data.UnitObj[tunr].Y - this.Top;
            if (!(coordinate.x == matrixX & coordinate.y == num13))
            {
              int[,] numArray2 = numArray1;
              int[,] numArray3 = numArray2;
              int index3 = matrixX;
              int index4 = index3;
              int index5 = num13;
              int index6 = index5;
              int num14 = numArray2[index3, index5] + this.ai.game.Data.UnitObj[tunr].TempUnitPower;
              numArray3[index4, index6] = num14;
            }
            num6 += this.ai.game.Data.UnitObj[tunr].TempUnitPower;
            flag1 = true;
          }
          if (unitList.counter + 1 >= num1)
            flag1 = false;
        }
        while (flag1);
        if (unitList.counter > -1)
        {
          int counter = unitList.counter;
          for (int index7 = 0; index7 <= counter; index7 += 1)
          {
            int index8 = unitList.unr[index7];
            int num15 = unitList.data[index7];
            this.MoveList.AddMove(ref AIMove::new()
            {
              UnitAIid = this.ai.game.Data.UnitObj[index8].AIid,
              MoveTo = {
                x = this.GetRealX(index1),
                y = y1 + this.Top,
                onmap = true
              }
            });
          }
        }
        else
          passList.AddCoord(index1, y1, 2);
      }
      if (this.MoveList.Counter <= -1)
        return;
      this.Score = num2;
      if (this.front.Stance != 2)
        return;
      this.Score *= 2;
    }

    pub void ImplementMoveList()
    {
      int counter1 = this.MoveList.Counter;
      for (int index1 = 0; index1 <= counter1; index1 += 1)
      {
        int index2 = -1;
        AIMove aiMove = this.MoveList.Move[index1];
        bool flag1 = false;
        int num1 = index1 + 1;
        int counter2 = this.MoveList.Counter;
        for (int index3 = num1; index3 <= counter2; index3 += 1)
        {
          if (this.MoveList.Move[index3].UnitAIid == aiMove.UnitAIid && this.MoveList.Move[index3].MoveTo.onmap & aiMove.MoveTo.onmap)
          {
            int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index3].UnitAIid);
            flag1 = true;
            if (this.ai.game.Data.MapObj[0].HexObj[this.ai.game.Data.UnitObj[unitByAiid].X, this.ai.game.Data.UnitObj[unitByAiid].Y].UnitCounter == 0)
              flag1 = flag1;
          }
        }
        int counter3 = this.front.units.counter;
        for (int index4 = 0; index4 <= counter3; index4 += 1)
        {
          if (this.front.units.AIid[index4] == this.MoveList.Move[index1].UnitAIid)
            index2 = index4;
        }
        if (!Information.IsNothing((object) aiMove.MoveTo) & index2 > -1 && aiMove.MoveTo.onmap)
        {
          int unitByAiid1 = this.ai.game.HandyFunctionsObj.GetUnitByAIid(aiMove.UnitAIid);
          int matrixX1 = this.GetMatrixX(this.ai.game.Data.UnitObj[unitByAiid1].X);
          int index5 = this.ai.game.Data.UnitObj[unitByAiid1].Y - this.Top;
          if (unitByAiid1 > -1 & !aiMove.IsAir && matrixX1 <= this.Width & index5 <= this.Height & matrixX1 >= 0 & index5 >= 0 & !(matrixX1 == this.GetMatrixX(aiMove.MoveTo.x) & index5 == aiMove.MoveTo.y - this.Top))
          {
            int num2 = 0;
            if (index2 > -1 && this.GetMatrixX(aiMove.MoveTo.x) >= 0 & this.GetMatrixX(aiMove.MoveTo.x) <= this.Width & aiMove.MoveTo.y - this.Top >= 0 & aiMove.MoveTo.y - this.Top <= this.Height && this.ai.game.HandyFunctionsObj.GetLowestAp(unitByAiid1) >= this.MoveCostMove[index2].Value[this.GetMatrixX(aiMove.MoveTo.x), aiMove.MoveTo.y - this.Top])
              num2 = 1;
            if (num2 == 1)
            {
              int tempUnitPowerAbs = this.ai.game.Data.UnitObj[unitByAiid1].TempUnitPowerAbs;
              int num3 = 0;
              int unitCounter = this.ai.game.Data.MapObj[0].HexObj[this.ai.game.Data.UnitObj[unitByAiid1].X, this.ai.game.Data.UnitObj[unitByAiid1].Y].UnitCounter;
              for (int index6 = 0; index6 <= unitCounter; index6 += 1)
              {
                int unit = this.ai.game.Data.MapObj[0].HexObj[this.ai.game.Data.UnitObj[unitByAiid1].X, this.ai.game.Data.UnitObj[unitByAiid1].Y].UnitList[index6];
                bool flag2 = true;
                int counter4 = this.MoveList.Counter;
                for (int index7 = 0; index7 <= counter4; index7 += 1)
                {
                  if (unit == this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index7].UnitAIid) && this.MoveList.Move[index7].MoveTo.onmap && !(this.MoveList.Move[index7].MoveTo.x == this.GetRealX(matrixX1) & this.MoveList.Move[index7].MoveTo.y == index5 + this.Top))
                    flag2 = false;
                }
                if (flag2)
                  num3 += this.ai.game.Data.UnitObj[unit].TempUnitPowerAbs;
              }
              int counter5 = this.MoveList.Counter;
              for (int index8 = 0; index8 <= counter5; index8 += 1)
              {
                bool flag3 = false;
                int unitByAiid2 = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index8].UnitAIid);
                if (this.MoveList.Move[index8].MoveTo.onmap && unitByAiid1 != unitByAiid2 && this.MoveList.Move[index8].MoveTo.x == this.GetRealX(matrixX1) & this.MoveList.Move[index8].MoveTo.y == index5 + this.Top)
                {
                  bool flag4 = false;
                  int num4 = index8 + 1;
                  int counter6 = this.MoveList.Counter;
                  for (int index9 = num4; index9 <= counter6; index9 += 1)
                  {
                    if (this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index8].UnitAIid) == unitByAiid2 && !(this.MoveList.Move[index8].MoveTo.x == this.GetRealX(matrixX1) & this.MoveList.Move[index8].MoveTo.y == index5 + this.Top))
                      flag4 = true;
                  }
                  if (!flag4)
                    flag3 = true;
                }
                if (flag3)
                  num3 += this.ai.game.Data.UnitObj[unitByAiid2].TempUnitPowerAbs;
              }
              if (!flag1)
              {
                if (aiMove.finalTo.onmap)
                {
                  int[,] numArray1 = this.allTroops.Value;
                  int[,] numArray2 = numArray1;
                  int index10 = matrixX1;
                  int index11 = index10;
                  int index12 = index5;
                  int index13 = index12;
                  int num5 = numArray1[index10, index12] - tempUnitPowerAbs;
                  numArray2[index11, index13] = num5;
                  if (this.allTroops.Value[matrixX1, index5] > num3)
                    this.allTroops.Value[matrixX1, index5] = num3;
                  if (0 > this.allTroops.Value[matrixX1, index5])
                    this.allTroops.Value[matrixX1, index5] = 0;
                  int[,] numArray3 = this.allTroops.Value;
                  int[,] numArray4 = numArray3;
                  int matrixX2 = this.GetMatrixX(aiMove.MoveTo.x);
                  int index14 = matrixX2;
                  int index15 = aiMove.MoveTo.y - this.Top;
                  int index16 = index15;
                  int num6 = numArray3[matrixX2, index15] + (int) Math.Round((double) tempUnitPowerAbs / 2.0);
                  numArray4[index14, index16] = num6;
                  int[,] numArray5 = this.allTroops.Value;
                  int[,] numArray6 = numArray5;
                  int matrixX3 = this.GetMatrixX(aiMove.finalTo.x);
                  int index17 = matrixX3;
                  int index18 = aiMove.finalTo.y - this.Top;
                  int index19 = index18;
                  int num7 = numArray5[matrixX3, index18] + (int) Math.Round((double) tempUnitPowerAbs / 2.0);
                  numArray6[index17, index19] = num7;
                }
                else
                {
                  int[,] numArray7 = this.allTroops.Value;
                  int[,] numArray8 = numArray7;
                  int index20 = matrixX1;
                  int index21 = index20;
                  int index22 = index5;
                  int index23 = index22;
                  int num8 = numArray7[index20, index22] - tempUnitPowerAbs;
                  numArray8[index21, index23] = num8;
                  if (this.allTroops.Value[matrixX1, index5] > num3)
                    this.allTroops.Value[matrixX1, index5] = num3;
                  if (0 > this.allTroops.Value[matrixX1, index5])
                    this.allTroops.Value[matrixX1, index5] = 0;
                  int[,] numArray9 = this.allTroops.Value;
                  int[,] numArray10 = numArray9;
                  int matrixX4 = this.GetMatrixX(aiMove.MoveTo.x);
                  int index24 = matrixX4;
                  int index25 = aiMove.MoveTo.y - this.Top;
                  int index26 = index25;
                  int num9 = numArray9[matrixX4, index25] + tempUnitPowerAbs;
                  numArray10[index24, index26] = num9;
                }
              }
              Coordinate coordinate;
              coordinate.x = this.GetMatrixX(aiMove.MoveTo.x);
              coordinate.y = aiMove.MoveTo.y - this.Top;
              coordinate.onmap = true;
              if (aiMove.finalTo.onmap)
              {
                coordinate.x = this.GetMatrixX(aiMove.finalTo.x);
                coordinate.y = aiMove.finalTo.y - this.Top;
                coordinate.onmap = true;
              }
              int num10 = 0;
              while (coordinate.onmap)
              {
                num10 += 1;
                int x = coordinate.x;
                int y = coordinate.y;
                if (x <= this.Width & y <= this.Height)
                {
                  this.Owner.Value[x, y] = 1;
                  if (!Information.IsNothing((object) this.FriendlySupply) && this.FriendlySupply.Value[matrixX1, index5] < this.FriendlySupply.Value[x, y])
                    this.FriendlySupply.Value[x, y] = this.FriendlySupply.Value[matrixX1, index5];
                  coordinate = this.MoveFromMove[index2].Value[coordinate.x, coordinate.y];
                }
                else
                  coordinate.onmap = false;
                if (coordinate.x == matrixX1 & coordinate.y == index5)
                  coordinate.onmap = false;
                if (num10 > 999)
                  break;
              }
            }
          }
        }
      }
      int counter7 = this.MoveList.Counter;
      for (int index27 = 0; index27 <= counter7; index27 += 1)
      {
        AIMove aiMove = this.MoveList.Move[index27];
        if (!Information.IsNothing((object) aiMove.AttackOn) && aiMove.AttackOn.onmap)
        {
          if (aiMove.AttackOn.x == 19 & aiMove.AttackOn.y == 7)
            index27 = index27;
          if (this.Owner.Value[this.GetMatrixX(aiMove.AttackOn.x), aiMove.AttackOn.y - this.Top] == 2)
          {
            this.allTroops.Value[this.GetMatrixX(aiMove.AttackOn.x), aiMove.AttackOn.y - this.Top] = 0;
            this.Owner.Value[this.GetMatrixX(aiMove.AttackOn.x), aiMove.AttackOn.y - this.Top] = 1;
          }
          int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(aiMove.UnitAIid);
          int matrixX5 = this.GetMatrixX(this.ai.game.Data.UnitObj[unitByAiid].X);
          int index28 = this.ai.game.Data.UnitObj[unitByAiid].Y - this.Top;
          if (!aiMove.IsAir)
          {
            int tempUnitPowerAbs = this.ai.game.Data.UnitObj[unitByAiid].TempUnitPowerAbs;
            if (matrixX5 >= 0 & index28 >= 0 & matrixX5 <= this.Width & index28 <= this.Height && 0 > this.allTroops.Value[matrixX5, index28])
              this.allTroops.Value[matrixX5, index28] = 0;
            int matrixX6 = this.GetMatrixX(aiMove.AttackOn.x);
            int num11 = aiMove.AttackOn.y - this.Top;
            if (matrixX6 >= 0 & num11 >= 0 & matrixX6 <= this.Width & num11 <= this.Height)
            {
              int[,] numArray11 = this.allTroops.Value;
              int[,] numArray12 = numArray11;
              int index29 = matrixX6;
              int index30 = index29;
              int index31 = num11;
              int index32 = index31;
              int num12 = numArray11[index29, index31] + tempUnitPowerAbs;
              numArray12[index30, index32] = num12;
            }
          }
        }
      }
    }

    pub int GetAverageOffensiveMod2(int unr)
    {
      if (this.ai.game.Data.UnitObj[unr].SFCount <= -1)
        return 0;
      int sfCount1 = this.ai.game.Data.UnitObj[unr].SFCount;
      int num1;
      int num2;
      for (int index = 0; index <= sfCount1; index += 1)
      {
        int sf = this.ai.game.Data.UnitObj[unr].SFList[index];
        num1 += this.ai.game.Data.SFObj[sf].Qty * this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].PowerPts * this.ai.game.Data.SFObj[sf].OffMod;
        num2 += this.ai.game.Data.SFObj[sf].Qty * this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].PowerPts;
      }
      if (num2 == 0)
        num2 = 1;
      if ((double) this.ai.game.Data.RuleVar[434] < 1.0 | this.ai.game.Data.Product < 6)
        return (int) Math.Round((double) num1 / (double) num2);
      int sfCount2 = this.ai.game.Data.UnitObj[unr].SFCount;
      int num3;
      int num4;
      float num5;
      int num6;
      float num7;
      int num8;
      for (int index = 0; index <= sfCount2; index += 1)
      {
        int sf = this.ai.game.Data.UnitObj[unr].SFList[index];
        int num9 = (int) Math.Round(10.0 * 1.25);
        int num10 = (int) Math.Round((double) ((float) (this.ai.game.Data.SFObj[sf].Qty * 100) * this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].TempAvgCombatMatrixAtt));
        num3 += (int) Math.Round((double) (this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].SupplyForAttack * 10) / (double) num9 * (double) this.ai.game.Data.SFObj[sf].Qty);
        if (this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].FuelForAttack > 0)
        {
          num4 += this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].FuelForAttack * num9 * this.ai.game.Data.SFObj[sf].Qty;
          num5 += this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].OutOfFuelDefense * (float) num10;
          num6 += num10;
        }
        num7 += this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].OutOfSupplyDefense * (float) num10;
        num8 += num10;
      }
      int num11 = (int) Math.Round((double) num1 / (double) num2);
      if (num8 > 0)
        num7 /= (float) num8;
      if (num6 > 0)
        num5 /= (float) num6;
      int num12 = num3 <= 0 ? 100 : (int) Math.Round(100.0 * Math.Min(1.0, (double) this.ai.game.Data.UnitObj[unr].Supply / (double) num3));
      if (num12 < 100)
        num12 += (int) Math.Round((double) ((float) (100 - num12) * num7));
      if ((double) this.ai.game.Data.RuleVar[435] > 0.0 & num4 > 0)
      {
        if (num12 < 80 & num12 > 30)
          num12 = num12;
        float num13 = (float) num6 / (float) num8;
        if ((double) num13 < 1.0)
          num13 *= num5;
        int num14 = num12;
        num12 = (int) Math.Round((double) num13 * (double) num14 * Math.Min(1.0, (double) this.ai.game.Data.UnitObj[unr].Fuel / (double) num4)) + (int) Math.Round((double) ((1f - num13) * (float) num14));
      }
      return num11 + num12 - 100;
    }

    pub int GetAverageDefensiveMod2(int unr)
    {
      if (this.ai.game.Data.UnitObj[unr].SFCount <= -1)
        return 0;
      int sfCount1 = this.ai.game.Data.UnitObj[unr].SFCount;
      int num1;
      int num2;
      for (int index = 0; index <= sfCount1; index += 1)
      {
        int sf = this.ai.game.Data.UnitObj[unr].SFList[index];
        num1 += this.ai.game.Data.SFObj[sf].Qty * this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].PowerPts * this.ai.game.Data.SFObj[sf].DefMod;
        num2 += this.ai.game.Data.SFObj[sf].Qty * this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].PowerPts;
      }
      if (num2 == 0)
        num2 = 1;
      if ((double) this.ai.game.Data.RuleVar[434] < 1.0 | this.ai.game.Data.Product < 6)
        return (int) Math.Round((double) num1 / (double) num2);
      int sfCount2 = this.ai.game.Data.UnitObj[unr].SFCount;
      int num3;
      int num4;
      float num5;
      int num6;
      float num7;
      int num8;
      for (int index = 0; index <= sfCount2; index += 1)
      {
        int sf = this.ai.game.Data.UnitObj[unr].SFList[index];
        int num9 = 10;
        int num10 = (int) Math.Round((double) ((float) (this.ai.game.Data.SFObj[sf].Qty * 100) * this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].TempAvgCombatMatrixDef));
        num3 += (int) Math.Round((double) (this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].SupplyForAttackDef * 20) / (double) num9 * (double) this.ai.game.Data.SFObj[sf].Qty);
        if (this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].FuelForAttackDef > 0)
        {
          num4 += this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].FuelForAttackDef * num9 * this.ai.game.Data.SFObj[sf].Qty;
          num5 += this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].OutOfFuelDefense * (float) num10;
          num6 += num10;
        }
        num7 += this.ai.game.Data.SFTypeObj[this.ai.game.Data.SFObj[sf].Type].OutOfSupplyDefense * (float) num10;
        num8 += num10;
      }
      int num11 = (int) Math.Round((double) num1 / (double) num2);
      if (num8 > 0)
        num7 /= (float) num8;
      if (num6 > 0)
        num5 /= (float) num6;
      int num12 = num3 <= 0 ? 100 : (int) Math.Round(100.0 * Math.Min(1.0, (double) this.ai.game.Data.UnitObj[unr].Supply / (double) num3));
      if (num12 < 100)
        num12 += (int) Math.Round((double) ((float) (100 - num12) * num7));
      if ((double) this.ai.game.Data.RuleVar[435] > 0.0 & num4 > 0)
      {
        float num13 = (float) num6 / (float) num8;
        if ((double) num13 < 1.0)
          num13 *= num5;
        int num14 = num12;
        num12 = (int) Math.Round((double) num13 * (double) num14 * Math.Min(1.0, (double) this.ai.game.Data.UnitObj[unr].Fuel / (double) num4)) + (int) Math.Round((double) ((1f - num13) * (float) num14));
      }
      return num11 + num12 - 100;
    }

    pub void ResetOwner()
    {
      int width = this.Owner.Width;
      int height = this.Owner.Height;
      int[,] numArray1 = new int[width + 1, height + 1];
      int num1 = width;
      for (int tx = 0; tx <= num1; tx += 1)
      {
        int num2 = height;
        for (int index1 = 0; index1 <= num2; index1 += 1)
        {
          int realX = this.GetRealX(tx);
          int index2 = index1 + this.Top;
          numArray1[tx, index1] = 0;
          int num3 = 0;
          int num4 = 0;
          if (this.ai.game.Data.MapObj[0].HexObj[realX, index2].Location2 > -1)
          {
            if (this.ai.game.Data.LocTypeObj[this.ai.game.Data.LocObj[this.ai.game.Data.MapObj[0].HexObj[realX, index2].Location2].Type].isSupplyBase)
              num3 = 1;
            if (this.ai.game.Data.LocTypeObj[this.ai.game.Data.LocObj[this.ai.game.Data.MapObj[0].HexObj[realX, index2].Location2].Type].isSupplySource)
              num3 = 1;
          }
          if (this.ai.game.Data.MapObj[0].HexObj[realX, index2].VP > 0)
            num3 = 1;
          else if (this.ai.game.Data.LandscapeTypeObj[this.ai.game.Data.MapObj[0].HexObj[realX, index2].LandscapeType].FuzzyOwnerAssured)
            num3 = 1;
          else if (this.allTroops.Value[tx, index1] > 0 & this.Owner.Value[tx, index1] == 1)
          {
            int num5 = 1;
            num3 = 1;
            num4 = num5;
          }
          else if (this.allTroops.Value[tx, index1] > 0)
          {
            int num6 = 2;
            num3 = 1;
            num4 = num6;
          }
          if (num3 == 1 && this.Owner.Value[tx, index1] > 0)
          {
            numArray1[tx, index1] = this.Owner.Value[tx, index1];
            if (num4 > 0)
              numArray1[tx, index1] = num4;
          }
        }
      }
      bool flag1 = true;
      int num7 = -1;
      int[,] numArray2 = new int[width + 1, height + 1];
      int num8 = width;
      Coordinate coordinate;
      while (flag1)
      {
        num7 += 1;
        flag1 = false;
        int num9 = 1;
        do
        {
          int num10 = num8;
          for (int index3 = 0; index3 <= num10; index3 += 1)
          {
            int num11 = height;
            for (int index4 = 0; index4 <= num11; index4 += 1)
            {
              int index5 = index3 + this.Left;
              int index6 = index4 + this.Top;
              if (numArray2[index3, index4] == num7 && numArray1[index3, index4] > 0 && numArray1[index3, index4] == 1 & num9 == 2 | numArray1[index3, index4] != 1 & num9 == 1)
              {
                int num12 = 1;
                do
                {
                  coordinate = this.ai.TempHexNeighbour[index3, index4, num12 - 1];
                  if (coordinate.onmap & coordinate.x <= this.Width & coordinate.y <= this.Height && numArray2[coordinate.x, coordinate.y] == 0 && num9 == 1 | num9 == 2 && numArray1[coordinate.x, coordinate.y] == 0 && this.ai.game.Data.MapObj[0].HexObj[index5, index6].RoadType[num12 - 1] > -1)
                  {
                    numArray1[coordinate.x, coordinate.y] = numArray1[index3, index4];
                    flag1 = true;
                    numArray2[coordinate.x, coordinate.y] = num7 + 1;
                  }
                  num12 += 1;
                }
                while (num12 <= 6);
              }
            }
          }
          num9 += 1;
        }
        while (num9 <= 2);
        if (num7 > 9999)
          break;
      }
      bool flag2 = true;
      int num13 = -1;
      int[,] numArray3 = new int[num8 + 1, height + 1];
      while (flag2)
      {
        num13 += 1;
        flag2 = false;
        int num14 = 1;
        do
        {
          int num15 = num8;
          for (int index7 = 0; index7 <= num15; index7 += 1)
          {
            int num16 = height;
            for (int index8 = 0; index8 <= num16; index8 += 1)
            {
              int num17 = index7 + this.Left;
              int num18 = index8 + this.Top;
              if (numArray3[index7, index8] == num13 && numArray1[index7, index8] > 0 && numArray1[index7, index8] == 1 & num14 == 2 | numArray1[index7, index8] != 1 & num14 == 1)
              {
                int num19 = 1;
                do
                {
                  coordinate = this.ai.TempHexNeighbour[index7, index8, num19 - 1];
                  if (coordinate.onmap & coordinate.x <= this.Width & coordinate.y <= this.Height && numArray3[coordinate.x, coordinate.y] == 0 && num14 == 1 | num14 == 2 && numArray1[coordinate.x, coordinate.y] == 0)
                  {
                    numArray1[coordinate.x, coordinate.y] = numArray1[index7, index8];
                    flag2 = true;
                    numArray3[coordinate.x, coordinate.y] = num13 + 1;
                  }
                  num19 += 1;
                }
                while (num19 <= 6);
              }
            }
          }
          num14 += 1;
        }
        while (num14 <= 2);
        if (num13 > 9999)
          break;
      }
      int num20 = num8;
      for (int index9 = 0; index9 <= num20; index9 += 1)
      {
        int num21 = height;
        for (int index10 = 0; index10 <= num21; index10 += 1)
          this.Owner.Value[index9, index10] = numArray1[index9, index10];
      }
    }

    pub isUnitThatNeedsProtection: bool(int unr) => this.ai.game.Data.UnitObj[unr].TempCategory == 2 || this.ai.game.Data.UnitObj[unr].TempCategory == 5 || this.ai.game.Data.UnitObj[unr].TempCategory2 == 14 || this.ai.game.Data.UnitObj[unr].TempCategory == 14 || this.ai.game.Data.UnitObj[unr].TempTopUnit;

    pub isUnitThatProtects: bool(int protectsUnr, int unr) => this.ai.game.Data.UnitObj[protectsUnr].TempTopUnit ? this.ai.game.Data.UnitObj[unr].TempCategory == 5 || this.ai.game.Data.UnitObj[unr].TempCategory != 2 && this.ai.game.Data.UnitObj[unr].TempCategory2 != 14 && this.ai.game.Data.UnitObj[unr].TempCategory != 14 && !this.ai.game.Data.UnitObj[unr].TempTopUnit : this.ai.game.Data.UnitObj[unr].TempCategory != 2 && this.ai.game.Data.UnitObj[unr].TempCategory != 5 && this.ai.game.Data.UnitObj[unr].TempCategory2 != 14 && this.ai.game.Data.UnitObj[unr].TempCategory != 14;

    pub string SetScore(bool doLog, bool IsAttack = false, int AttackX = -1, int AttackY = -1)
    {
      int stringListById = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0));
      int num1 = (int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById].GetData(0, 56, 2)));
      AIMatrix aiMatrix1 = this.allTroops.Clone();
      if (this.MoveList.Counter == -1 & AttackX != -2)
      {
        this.Score = -9999999;
        return "NO MOVES = NO SCORE";
      }
      this.Score = (int) Math.Round(Math.Sqrt((double) this.Score) + Math.Sqrt((double) this.Score)) + 1000;
      if (AttackX == -2)
        AttackX = -1;
      this.enemyDistance = this.Owner.Clone();
      this.enemyDistance.RemoveValuesByMask(this.Owner, 1);
      this.enemyDistance.ExpandAndAddValueForAnyRegime(19);
      this.enemyDistance.SetAllValuesSubtractWith(2);
      AIMatrix tSupply1 = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      AIMatrix tSupply2 = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      AIMatrix vp = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      float num2 = 0.0f;
      float num3 = 0.0f;
      int counter1 = this.front.units.counter;
      int index1;
      int index2;
      int tdata1;
      for (index1 = 0; index1 <= counter1; index1 += 1)
      {
        int id = this.front.units.AIid[index1];
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(id);
        int matrixX = this.GetMatrixX(this.ai.game.Data.UnitObj[unitByAiid].X);
        int index3 = this.ai.game.Data.UnitObj[unitByAiid].Y - this.Top;
        index2 = matrixX;
        tdata1 = index3;
        int counter2 = this.MoveList.Counter;
        for (int index4 = 0; index4 <= counter2; index4 += 1)
        {
          AIMove aiMove = this.MoveList.Move[index4];
          if (aiMove.UnitAIid == id)
          {
            if (aiMove.finalTo.onmap)
            {
              index2 = this.GetMatrixX(aiMove.finalTo.x);
              tdata1 = aiMove.finalTo.y - this.Top;
            }
            else if (aiMove.MoveTo.onmap)
            {
              index2 = this.GetMatrixX(aiMove.MoveTo.x);
              tdata1 = aiMove.MoveTo.y - this.Top;
            }
          }
        }
        if (index2 == -1)
        {
          index2 = matrixX;
          tdata1 = index3;
        }
        num2 += (float) (int) Math.Round((double) (this.enemyDistance.Value[matrixX, index3] * 100 * Math.Max(0, 100 - this.Advance.Value[matrixX, index3])) / 100.0);
        num3 += (float) (int) Math.Round((double) (this.enemyDistance.Value[index2, tdata1] * 100 * Math.Max(0, 100 - this.Advance.Value[index2, tdata1])) / 100.0);
      }
      this.finalOrigEnemyUnits = 0;
      int num4 = 0;
      int width1 = this.Width;
      for (int tx = 0; tx <= width1; tx += 1)
      {
        int height = this.Height;
        for (int index5 = 0; index5 <= height; index5 += 1)
        {
          if (this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(tx), this.Top + index5].UnitCounter > -1 && this.FrontArea.Value[tx, index5] == this.front.FrontID & this.Owner.Value[tx, index5] == 2)
            this.finalOrigEnemyUnits += this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(tx), this.Top + index5].UnitCounter + 1;
          if (this.FrontArea.Value[tx, index5] == this.front.FrontID & this.Owner.Value[tx, index5] == 1)
            num4 += this.allTroops.Value[tx, index5];
          int regimeCounter = this.ai.game.Data.RegimeCounter;
          for (int Index = 2; Index <= regimeCounter; Index += 1)
          {
            if (this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(tx), this.Top + index5].get_ZocPts(Index) > 0 && Index != this.ai.game.Data.Turn && this.ai.game.Data.RegimeObj[Index].RegimeRel[this.ai.game.Data.Turn] == 0)
            {
              int[,] numArray1 = vp.Value;
              int[,] numArray2 = numArray1;
              int index6 = tx;
              int index7 = index6;
              int index8 = index5;
              int index9 = index8;
              int num5 = numArray1[index6, index8] + 1;
              numArray2[index7, index9] = num5;
            }
          }
          int[,] numArray3 = vp.Value;
          int[,] numArray4 = numArray3;
          int index10 = tx;
          int index11 = index10;
          int index12 = index5;
          int index13 = index12;
          int num6 = numArray3[index10, index12] + this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(tx), this.Top + index5].VP;
          numArray4[index11, index13] = num6;
          int[,] numArray5 = vp.Value;
          int[,] numArray6 = numArray5;
          int index14 = tx;
          int index15 = index14;
          int index16 = index5;
          int index17 = index16;
          int num7 = numArray5[index14, index16] + this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].AIVP[0].Value[this.GetRealX(tx), this.Top + index5];
          numArray6[index15, index17] = num7;
        }
      }
      if (num1 > 0 | Information.IsNothing((object) this.FriendlySupply))
        this.Setsupplymatrix(ref tSupply1, ref this.Owner, 1);
      else
        tSupply1 = this.FriendlySupply.Clone();
      this.finalEncRatio5 = this.GetTroopsRatioOutOfSupply(ref tSupply1, ref this.allTroops, ref this.Owner, 1);
      this.finalEncRatio6 = this.GetTroopsFrontRatioOutOfSupply(ref tSupply1, ref this.allTroops, ref this.Owner, 1);
      AIMatrix tOwner = this.Owner.Clone();
      AIMatrix tTroops = this.allTroops.Clone().AverageAndDivideValuesForSameRegime_NotForVP(1, vp, tOwner, OnlyOwnerX: 1, dividy: 150).AverageAndDivideValuesForSameRegime(1, tOwner, OnlyOwnerX: 2, dividy: 2);
      int initialFrontAreaHexes1 = this.GetInitialFrontAreaHexes(ref tTroops, ref tOwner, 1);
      this.GetEnemyMove(4f, true, ref tOwner, ref tTroops, 1, false);
      this.GetEnemyMove(2f, false, ref tOwner, ref tTroops, 1, false);
      float ratioOutOfSupply1;
      float ratioOutOfSupply2;
      if (num1 > 0)
      {
        this.Setsupplymatrix(ref tSupply1, ref tOwner, 1);
        ratioOutOfSupply1 = this.GetTroopsRatioOutOfSupply(ref tSupply1, ref tTroops, ref tOwner, 1);
        ratioOutOfSupply2 = this.GetTroopsFrontRatioOutOfSupply(ref tSupply1, ref tTroops, ref tOwner, 1);
      }
      int initialFrontAreaHexes2 = this.GetInitialFrontAreaHexes(ref tTroops, ref tOwner, 1);
      int initialHexes1 = this.GetInitialHexes(ref tTroops, ref tOwner, 1);
      if (this.front.Stance == 1)
        this.FriendlySupplyAfterEnemyMove = tSupply1.Clone();
      if (this.ai.CustomCalls.CustomIsMinor())
      {
        this.GetEnemyMove(2f, true, ref tOwner, ref tTroops, 1, false);
        this.GetEnemyMove(4f, true, ref tOwner, ref tTroops, 1, false);
      }
      else
      {
        this.GetEnemyMove(4f, true, ref tOwner, ref tTroops, 1, false);
        this.GetEnemyMove(6f, true, ref tOwner, ref tTroops, 1, false);
      }
      float ratioOutOfSupply3;
      float ratioOutOfSupply4;
      if (num1 > 0)
      {
        this.Setsupplymatrix(ref tSupply1, ref tOwner, 1);
        ratioOutOfSupply3 = this.GetTroopsRatioOutOfSupply(ref tSupply1, ref tTroops, ref tOwner, 1);
        ratioOutOfSupply4 = this.GetTroopsFrontRatioOutOfSupply(ref tSupply1, ref tTroops, ref tOwner, 1);
      }
      int initialFrontAreaHexes3 = this.GetInitialFrontAreaHexes(ref tTroops, ref tOwner, 1);
      int initialHexes2 = this.GetInitialHexes(ref tTroops, ref tOwner, 1);
      if (this.ai.CustomCalls.CustomIsMinor())
      {
        this.GetEnemyMove(4f, true, ref tOwner, ref tTroops, 1, false);
        this.GetEnemyMove(6f, true, ref tOwner, ref tTroops, 1, false);
      }
      else
      {
        this.GetEnemyMove(8f, true, ref tOwner, ref tTroops, 1, false);
        this.GetEnemyMove(12f, true, ref tOwner, ref tTroops, 1, false);
      }
      int width2 = this.Width;
      for (int index18 = 0; index18 <= width2; index18 += 1)
      {
        int height = this.Height;
        for (int index19 = 0; index19 <= height; index19 += 1)
        {
          if (this.Owner.Value[index18, index19] == 2 & aiMatrix1.Value[index18, index19] > 0)
          {
            int index20 = 0;
            do
            {
              Coordinate coordinate = this.ai.TempHexNeighbour[index18, index19, index20];
              if (coordinate.onmap && coordinate.x >= 0 & coordinate.y >= 0 & coordinate.x <= this.Width & coordinate.y <= this.Height)
              {
                if (this.FriendlyBottleneckIdealOwnFrontOnly.Value[coordinate.x, coordinate.y] > 75)
                {
                  if (this.Owner.Value[coordinate.x, coordinate.y] == 1 && aiMatrix1.Value[index18, index19] > aiMatrix1.Value[coordinate.x, coordinate.y] * 4)
                    this.Owner.Value[coordinate.x, coordinate.y] = 2;
                }
                else if (this.FriendlyBottleneckIdealOwnFrontOnly.Value[coordinate.x, coordinate.y] > 32 && this.Owner.Value[coordinate.x, coordinate.y] == 1 && aiMatrix1.Value[index18, index19] > aiMatrix1.Value[coordinate.x, coordinate.y] * 8)
                  this.Owner.Value[coordinate.x, coordinate.y] = 2;
              }
              index20 += 1;
            }
            while (index20 <= 5);
          }
        }
      }
      this.Setsupplymatrix(ref tSupply1, ref tOwner, 1);
      this.Setsupplymatrix(ref tSupply2, ref tOwner, 2);
      this.finalEncRatio1 = this.GetTroopsRatioOutOfSupply(ref tSupply1, ref tTroops, ref tOwner, 1);
      this.finalEncRatio2 = this.GetTroopsFrontRatioOutOfSupply(ref tSupply1, ref tTroops, ref tOwner, 1);
      if (num1 > 0)
      {
        this.finalEncRatio1 = (float) (((double) ratioOutOfSupply1 * 3.0 + (double) ratioOutOfSupply3 * 2.0 + (double) this.finalEncRatio1) / 6.0);
        this.finalEncRatio2 = (float) (((double) ratioOutOfSupply2 * 3.0 + (double) ratioOutOfSupply4 * 2.0 + (double) this.finalEncRatio2) / 6.0);
      }
      this.finalEncRatio3 = this.GetTroopsRatioOutOfSupply(ref tSupply2, ref this.troopsstrength, ref this.Owner, 2);
      this.finalEncRatio4 = this.GetTroopsFrontRatioOutOfSupply(ref tSupply2, ref this.troopsstrength, ref this.Owner, 2);
      this.finalHexes = this.GetInitialFrontAreaHexes(ref tTroops, ref tOwner, 1);
      this.finalHexesTot = this.GetInitialHexes(ref tTroops, ref tOwner, 1);
      this.finalHexes = (int) Math.Round((double) (initialFrontAreaHexes1 * 8 + initialFrontAreaHexes2 * 4 + initialFrontAreaHexes3 * 2 + this.finalHexes) / 15.0);
      this.finalHexesTot = (int) Math.Round((double) (initialHexes1 * 4 + initialHexes2 * 2 + this.finalHexesTot) / 7.0);
      if (this.front.FrontID == 1689)
        index1 = index1;
      float num8;
      float num9;
      if (this.front.Stance == 3)
      {
        if ((double) this.front.UnitCountRatio > 1.0)
        {
          num8 = (float) (((double) this.initEncRatio1 - (double) this.finalEncRatio1) * 1.0);
          num9 = (float) (((double) this.initEncRatio2 - (double) this.finalEncRatio2) * (1.0 / (double) this.front.UnitCountRatio));
        }
        else
        {
          num8 = (float) (((double) this.initEncRatio1 - (double) this.finalEncRatio1) * 2.0);
          num9 = (float) (((double) this.initEncRatio2 - (double) this.finalEncRatio2) * 2.0);
        }
      }
      else
      {
        num8 = (float) (((double) this.initEncRatio1 - (double) this.finalEncRatio1) * 3.0);
        num9 = (float) (((double) this.initEncRatio2 - (double) this.finalEncRatio2) * 9.0);
      }
      float num10 = this.initEncRatio5 - this.finalEncRatio5;
      float num11 = this.initEncRatio6 - this.finalEncRatio6;
      if ((double) num10 < -1.0)
        index1 = index1;
      float num12 = 0.0f;
      if (this.InitHexes < 1)
        this.InitHexes = 1;
      if (this.initHexesTot < 1)
        this.initHexesTot = 1;
      int num13 = Math.Min(this.InitHexes, this.finalHexes) - 100;
      if (num13 < 0)
        num13 = 0;
      int num14 = (int) Math.Round((double) num13 * 0.95);
      int num15 = this.InitHexes - num14;
      this.finalHexes -= num14;
      float num16 = num12 + ((float) this.finalHexes / (float) num15 - 1f);
      if ((double) num16 > 0.0)
        ;
      int num17 = Math.Min(this.initHexesTot, this.finalHexesTot) - 100;
      if (num17 < 0)
        num17 = 0;
      int num18 = (int) Math.Round((double) num17 * 0.95);
      int num19 = this.initHexesTot - num18;
      this.finalHexesTot -= num18;
      float num20 = (float) (5.0 * ((double) ((float) this.finalHexesTot / (float) num19) - 1.0));
      if (this.front.Stance == 3)
        num16 *= 3f;
      float num21 = num20 * 0.25f;
      if ((double) num8 < 0.0)
        num21 = num21 * (float) (1.0 - Math.Min(0.9, (double) Math.Abs(num8))) * (float) (1.0 - Math.Min(0.9, (double) Math.Abs(num8)));
      if ((double) num9 < 0.0)
      {
        num16 = num16 * (float) (1.0 - Math.Min(0.9, (double) Math.Abs(num9 / 4f))) * (float) (1.0 - Math.Min(0.9, (double) Math.Abs(num9 / 4f)));
        if ((double) num16 > 0.0)
          num16 = 0.0f;
      }
      if (this.front.Stance == 3)
      {
        num10 *= 1f;
        num11 *= 1f;
        num16 *= 2f;
        num21 *= 2f;
      }
      else if (this.front.Stance == 2)
      {
        num10 *= 2f;
        num11 *= 2f;
      }
      int num22 = 1;
      if (IsAttack && this.enemySupply.Value[AttackX, AttackY] > this.ai.VAR_SUPPLY_MAXIMUM_RANGE)
        num22 = 0;
      float num23;
      float num24;
      if (num22 == 1)
      {
        float num25;
        num23 = num25 - (float) (3.0 * ((double) this.initEncRatio3 - (double) this.finalEncRatio3));
        float num26;
        num24 = num26 - (float) (3.0 * ((double) this.initEncRatio4 - (double) this.finalEncRatio4));
      }
      string str1;
      str2: String = str1 + "BefMoveOwnAllOut: " + num10.ToString() + ", BefMoveOwnFrTrOut: " + num11.ToString() + "AftMoveOwnAllOut: " + num8.ToString() + ", AftMoveOwnFrTrOut: " + num9.ToString() + ", EnmAllOut: " + num23.ToString() + ", EnmFrOut: " + num24.ToString() + ", HexTot: " + num21.ToString() + ", HexFr: " + num16.ToString() + ". ";
      float num27 = num8 + num9 + num16 + num21 + num23 + num24 + num10 + num11;
      str3: String = str2 + "*" + this.initOrigEnemyUnits.ToString() + "/" + this.finalOrigEnemyUnits.ToString();
      float num28;
      if (this.initOrigEnemyUnits > this.finalOrigEnemyUnits)
      {
        if (this.finalOrigEnemyUnits >= 1)
        {
          num28 = (float) Math.Sqrt((double) this.initOrigEnemyUnits / (double) this.finalOrigEnemyUnits);
          str3 = str3 + " * EnmUnitHexTaken: *" + num28.ToString();
          if ((double) num28 > 3.0)
            num28 = 3f;
          num27 += (float) (3.0 * ((double) Math.Abs(num27 * num28) - (double) Math.Abs(num27)));
        }
        else
        {
          float num29 = 3f * (float) Math.Sqrt((double) (1 + this.initOrigEnemyUnits));
          if ((double) num29 > 3.0)
            num29 = 3f;
          str3 = str3 + " * EnmUnitHexTaken: *" + num29.ToString();
          num27 += (float) (1.0 * ((double) Math.Abs(num27 * num29) - (double) Math.Abs(num27)));
        }
      }
      int num30 = 0;
      int width3 = this.Width;
      for (int index21 = 0; index21 <= width3; index21 += 1)
      {
        int height = this.Height;
        for (int index22 = 0; index22 <= height; index22 += 1)
        {
          if (this.FrontArea.Value[index21, index22] == this.front.FrontID & tOwner.Value[index21, index22] == 1)
            num30 += tTroops.Value[index21, index22];
        }
      }
      if (num4 > num30 & num4 > 0)
      {
        num28 = 1f - (float) num30 / (float) num4;
        str3 = str3 + " * FriendlyUnitsLost: *" + num28.ToString();
        num28 *= 0.75f;
        num27 -= Math.Abs(num27 * num28);
        if ((double) num16 > 0.0)
          num27 -= Math.Abs(num16 * 2f * num28);
        if ((double) num21 > 0.0)
          num27 -= Math.Abs(num21 * 2f * num28);
      }
      if (this.front.FrontID > 10000)
        str3 = str3;
      if (this.front.DefensiveZone > 0)
      {
        SimpleList simpleList = SimpleList::new();
        float num31 = 0.0f;
        int num32 = 0;
        int num33 = 0;
        int counter3 = this.front.units.counter;
        for (int index23 = 0; index23 <= counter3; index23 += 1)
        {
          int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index23]);
          if (unitByAiid > -1)
          {
            index2 = this.ai.game.Data.UnitObj[unitByAiid].X;
            tdata1 = this.ai.game.Data.UnitObj[unitByAiid].Y;
            int counter4 = this.MoveList.Counter;
            for (int index24 = 0; index24 <= counter4; index24 += 1)
            {
              if (this.MoveList.Move[index24].UnitAIid == this.front.units.AIid[index23] && this.MoveList.Move[index24].MoveTo.onmap)
              {
                index2 = this.MoveList.Move[index24].MoveTo.x;
                tdata1 = this.MoveList.Move[index24].MoveTo.y;
              }
            }
            if (this.ai.VAR_MATRIX_ZONES.Value[index2, tdata1] + 1000000 == this.front.FrontID)
            {
              num32 += 1;
              if (simpleList.FindNr(index2, tdata1) > -1)
              {
                int[] weight = simpleList.Weight;
                int[] numArray = weight;
                int nr = simpleList.FindNr(index2, tdata1);
                int index25 = nr;
                int num34 = weight[nr] + 1;
                numArray[index25] = num34;
              }
              else
                simpleList.Add(index2, 1, tdata1, CheckExistence: false);
            }
            else
              num33 += 1;
          }
        }
        if (num32 + num33 > 0)
          num31 = (float) (6.0 * ((double) num32 / (double) (num32 + num33)));
        if (simpleList.Counter > -1)
        {
          int index26 = 9999;
          int[] numArray7 = new int[22];
          int num35 = 0;
          int num36 = 0;
          int width4 = this.Width;
          for (int tx = 0; tx <= width4; tx += 1)
          {
            int height = this.Height;
            for (int index27 = 0; index27 <= height; index27 += 1)
            {
              if (this.ai.VAR_MATRIX_ZONES.Value[this.GetRealX(tx), index27 + this.Top] + 1000000 == this.front.FrontID)
              {
                int num37 = 0;
                int counter5 = simpleList.Counter;
                for (int index28 = 0; index28 <= counter5; index28 += 1)
                {
                  index2 = simpleList.Id[index28];
                  tdata1 = simpleList.Data1[index28];
                  if (index2 == this.GetMatrixX(tx) & tdata1 == index27 + this.Top)
                  {
                    index26 = simpleList.Weight[index28];
                    num37 += simpleList.Weight[index28];
                  }
                }
                if (num37 == 0)
                {
                  index26 = 0;
                  num36 += 1;
                }
                else
                  num35 += 1;
                if (index26 < 20)
                {
                  int[] numArray8 = numArray7;
                  int[] numArray9 = numArray8;
                  int index29 = index26;
                  int index30 = index29;
                  int num38 = numArray8[index29] + 1;
                  numArray9[index30] = num38;
                }
              }
            }
          }
          if (index26 < 20)
          {
            if (num36 == 0)
              num36 = num36;
            num31 = (float) ((double) num31 * 0.5 + (double) num31 * 0.5 * ((double) num35 / (double) (num35 + num36)));
            int num39 = numArray7[index26];
            for (int index31 = 1; index31 <= num39; index31 += 1)
              num31 = (float) ((double) num31 * 0.8 + (double) num31 * 0.2 * (double) index26);
          }
        }
        str3 = str3 + " ,DefZ-Extra:+" + num31.ToString();
        num27 += num31;
      }
      float a = num27 * 1000f;
      if ((double) num2 > (double) num3)
      {
        float num40 = (float) ((double) num2 / (double) num3 - 1.0) * 5f;
        if ((double) num40 > 0.2)
          num40 = num40;
        if ((double) num40 > 1.0)
          num40 = 1f;
        if ((double) num40 < 0.0)
          num40 = 0.0f;
        if (this.front.Stance == 3)
          a += (float) (150.0 * (double) num40 + (double) num40 * (double) Math.Abs(a) * 0.349999994039536);
        else
          a += (float) (30.0 * (double) num40 + (double) num40 * (double) a * 0.100000001490116);
      }
      if (this.front.Stance == 3 && this.ai.VAR_DC4_ATTACKUNIT_IS_IMPORTANT)
      {
        int counter6 = this.MoveList.Counter;
        for (int index32 = 0; index32 <= counter6; index32 += 1)
        {
          if (this.MoveList.Move[index32].AttackOn.onmap && this.front.units.FindAiIDSlot(this.MoveList.Move[index32].UnitAIid) > -1)
          {
            int num41 = (int) Math.Round((double) (33 + (int) Math.Round((double) (100 * this.origAllTroops.Value[this.GetMatrixX(this.MoveList.Move[index32].AttackOn.x), this.MoveList.Move[index32].AttackOn.y - this.Top]) / (double) this.front.enemyPower)) / 2.0);
            float num42 = (float) ((this.front.Stance != 3 ? (double) Math.Max(150f, Math.Abs(a / 30f)) : (double) Math.Max(50f, Math.Abs(a / 15f))) * (double) num41 / 100.0);
            str3 = str3 + " ,AttackTakingPlaceBonus: +" + num42.ToString();
            a += num42;
            break;
          }
        }
        int counter7 = this.MoveList.Counter;
        for (int index33 = 0; index33 <= counter7; index33 += 1)
        {
          if (this.MoveList.Move[index33].AttackOn.onmap && this.front.artUnits.FindAiIDSlot(this.MoveList.Move[index33].UnitAIid) > -1)
          {
            int num43 = 25;
            float num44 = (float) ((double) Math.Max(50f, Math.Abs(a / 20f)) * (double) num43 / 100.0);
            str3 = str3 + " ,ArtilleryAttackTakingPlaceBonus: +" + num44.ToString();
            a += num44;
            break;
          }
        }
      }
      float num45 = a;
      int num46 = 1;
      do
      {
        AIUnitList aiUnitList;
        if (num46 == 1)
          aiUnitList = this.front.artUnits;
        if (num46 == 2)
          aiUnitList = this.front.units;
        int counter8 = aiUnitList.counter;
        for (int index34 = 0; index34 <= counter8; index34 += 1)
        {
          int unitByAiid1 = this.ai.game.HandyFunctionsObj.GetUnitByAIid(aiUnitList.AIid[index34]);
          if (unitByAiid1 > -1 && this.isUnitThatNeedsProtection(unitByAiid1))
          {
            int num47 = 0;
            int x1 = this.ai.game.Data.UnitObj[unitByAiid1].X;
            int y1 = this.ai.game.Data.UnitObj[unitByAiid1].Y;
            int counter9 = this.MoveList.Counter;
            for (int index35 = 0; index35 <= counter9; index35 += 1)
            {
              if (this.MoveList.Move[index35].MoveTo.onmap && unitByAiid1 == this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index35].UnitAIid))
              {
                x1 = this.MoveList.Move[index35].MoveTo.x;
                y1 = this.MoveList.Move[index35].MoveTo.y;
              }
            }
            int counter10 = this.MoveList.Counter;
            for (int index36 = 0; index36 <= counter10; index36 += 1)
            {
              int unitByAiid2 = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index36].UnitAIid);
              if (this.isUnitThatProtects(unitByAiid1, unitByAiid2) && this.MoveList.Move[index36].MoveTo.onmap)
              {
                int x2 = this.MoveList.Move[index36].MoveTo.x;
                int y2 = this.MoveList.Move[index36].MoveTo.y;
                if (x2 == x1 & y2 == y1)
                  num47 += this.ai.game.Data.UnitObj[unitByAiid2].TempUnitPowerAbs;
              }
            }
            int unitCounter = this.ai.game.Data.MapObj[0].HexObj[x1, y1].UnitCounter;
            for (int index37 = 0; index37 <= unitCounter; index37 += 1)
            {
              int unr = this.ai.game.Data.MapObj[0].HexObj[x1, y1].UnitList[index37];
              if (this.isUnitThatProtects(unitByAiid1, unr) && this.ai.game.Data.UnitObj[unr].X == x1 & this.ai.game.Data.UnitObj[unr].Y == y1)
              {
                int counter11 = this.MoveList.Counter;
                for (int index38 = 0; index38 <= counter11; index38 += 1)
                {
                  if (this.MoveList.Move[index38].MoveTo.onmap && unr == this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index38].UnitAIid))
                  {
                    unr = -1;
                    break;
                  }
                }
                if (unr > -1)
                  num47 += this.ai.game.Data.UnitObj[unr].TempUnitPowerAbs;
              }
            }
            float num48 = 0.33f;
            if (this.GetMatrixX(x1) <= this.Width & this.GetMatrixX(x1) >= 0 && y1 - this.Top <= this.Height & y1 - this.Top >= 0)
              num48 = this.enemyDistance.Value[this.GetMatrixX(x1), y1 - this.Top] > 1 ? (this.enemyDistance.Value[this.GetMatrixX(x1), y1 - this.Top] > 2 ? (this.enemyDistance.Value[this.GetMatrixX(x1), y1 - this.Top] > 3 ? (this.enemyDistance.Value[this.GetMatrixX(x1), y1 - this.Top] > 4 ? (this.enemyDistance.Value[this.GetMatrixX(x1), y1 - this.Top] > 5 ? (this.enemyDistance.Value[this.GetMatrixX(x1), y1 - this.Top] > 6 ? 0.0f : 0.0f) : 0.0f) : 0.0f) : 0.2f) : 0.5f) : 0.95f;
            if (x1 == 20 & y1 == 11)
              ;
            float num49 = num48;
            float num50 = num48 / (float) Math.Sqrt((double) (aiUnitList.counter + 1));
            int tempUnitPowerAbs = this.ai.game.Data.UnitObj[unitByAiid1].TempUnitPowerAbs;
            if ((double) num50 > 0.0 & tempUnitPowerAbs > 0)
            {
              if (num47 > 0)
              {
                if (num47 > tempUnitPowerAbs * 2)
                  a = a + Math.Abs((float) (0.1 * (double) tempUnitPowerAbs * ((double) num50 * 1.0))) + 100f * num49;
                else if (num47 > tempUnitPowerAbs * 1)
                  a = a + Math.Abs((float) (0.1 * (double) tempUnitPowerAbs * ((double) num50 * 0.5))) + 50f * num49;
                else if ((double) num47 <= (double) tempUnitPowerAbs * 0.25)
                  a = a - Math.Abs((float) (0.1 * (double) tempUnitPowerAbs * ((double) num50 * 0.25))) - 50f * num49;
              }
              else
                a = a - Math.Abs((float) (0.1 * (double) tempUnitPowerAbs * ((double) num50 * 1.0))) - 200f * num49;
            }
          }
        }
        num46 += 1;
      }
      while (num46 <= 2);
      int num51;
      if ((double) a != (double) num45)
      {
        num51 = (int) Math.Round((double) (a - num45));
        str3 = str3 + " ,Art(+Pz)UnitsProtection: " + num51.ToString();
      }
      int counter12 = this.MoveList.Counter;
      for (int index39 = 0; index39 <= counter12; index39 += 1)
      {
        int unr = -1;
        if (this.MoveList.Move[index39].MoveTo.onmap)
        {
          index2 = this.GetMatrixX(this.MoveList.Move[index39].MoveTo.x);
          tdata1 = this.MoveList.Move[index39].MoveTo.y - this.Top;
          unr = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index39].UnitAIid);
          int num52 = index39 + 1;
          int counter13 = this.MoveList.Counter;
          for (int index40 = num52; index40 <= counter13; index40 += 1)
          {
            if (unr == this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index40].UnitAIid) && this.MoveList.Move[index40].MoveTo.onmap & !this.MoveList.Move[index40].AttackOn.onmap)
              unr = -1;
          }
        }
        int num53;
        if (unr > -1 & !this.MoveList.Move[index39].AttackOn.onmap)
        {
          num51 = this.ai.game.HandyFunctionsObj.GetHexStackPts(this.GetRealX(index2), tdata1 + this.Top, 0) + this.ai.game.HandyFunctionsObj.GetUnitStackPts(unr);
          if (num51 > this.ai.VAR_HEX_STACK_REGULAR)
          {
            str4: String = str3;
            num53 = 25 + (int) Math.Round(Math.Abs((double) a * ((double) num51 / (double) this.ai.VAR_HEX_STACK_REGULAR - 1.0)) / Math.Sqrt((double) this.front.units.counter));
            str5: String = num53.ToString();
            str3 = str4 + "*OverStack: -" + str5;
            a -= (float) (25 + (int) Math.Round(Math.Abs((double) a * ((double) num51 / (double) this.ai.VAR_HEX_STACK_REGULAR - 1.0)) / Math.Sqrt((double) this.front.units.counter)));
          }
        }
        if (unr > -1)
        {
          if (this.front.DefensiveZone > 0 & this.ai.VAR_MATRIX_ZONES.Value[this.ai.game.Data.UnitObj[unr].X, this.ai.game.Data.UnitObj[unr].Y] + 1000000 != this.front.FrontID)
          {
            if (this.ai.VAR_MATRIX_ZONES.Value[this.GetRealX(index2), tdata1 + this.Top] + 1000000 == this.front.FrontID)
            {
              a += (float) (1000 + (int) Math.Round((double) Math.Abs(this.Score) * 0.3));
            }
            else
            {
              Coordinate averageFrontCoordinate = this.front.GetAverageFrontCoordinate(this.front.FrontID - 1000000);
              num51 = this.ai.game.HandyFunctionsObj.Distance(this.GetMatrixX(index2), tdata1 + this.Top, 0, averageFrontCoordinate.x, averageFrontCoordinate.y, 0);
              int num54 = this.ai.game.HandyFunctionsObj.Distance(this.ai.game.Data.UnitObj[unr].X, this.ai.game.Data.UnitObj[unr].Y, 0, averageFrontCoordinate.x, averageFrontCoordinate.y, 0);
              a += (float) ((num54 - num51) * (400 + (int) Math.Round((double) Math.Abs(this.Score) * 0.2)));
            }
          }
          if (this.front.DefensiveZone > 0 & this.ai.VAR_MATRIX_ZONES.Value[this.ai.game.Data.UnitObj[unr].X, this.ai.game.Data.UnitObj[unr].Y] + 1000000 == this.front.FrontID && this.ai.VAR_MATRIX_ZONES.Value[this.GetRealX(index2), tdata1 + this.Top] + 1000000 != this.front.FrontID)
            a -= (float) (600 + (int) Math.Round((double) Math.Abs(this.Score) * 0.3));
        }
        if (unr > -1 & index2 <= this.Width & tdata1 <= this.Height)
        {
          if (Operators.CompareString(Strings.LCase(this.ai.game.Data.UnitObj[unr].Name), Strings.LCase("14th pz div"), false) == 0)
            index2 = index2;
          int matrixX = this.GetMatrixX(this.ai.game.Data.UnitObj[unr].X);
          int index41 = this.ai.game.Data.UnitObj[unr].Y - this.Top;
          num51 = this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(matrixX), index41 + this.Top];
          int num55 = this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(index2), tdata1 + this.Top];
          if (this.front.FrontType == 1 & this.front.Stance == 2 && this.FrontArea.Value[matrixX, index41] == this.front.FrontID & this.FrontArea.Value[index2, tdata1] == this.front.FrontID)
          {
            if (num51 <= 50 & num55 >= 200)
            {
              str6: String = str3;
              num53 = 225 + (int) Math.Round(Math.Abs((double) a * 0.5) / Math.Sqrt(Math.Sqrt((double) this.front.units.counter)));
              str7: String = num53.ToString();
              str3 = str6 + "*MoveFromIdealHoldIntoBIGRetreatProne: -" + str7;
              a -= (float) (225 + (int) Math.Round(Math.Abs((double) a * 0.5) / Math.Sqrt(Math.Sqrt((double) this.front.units.counter))));
            }
            else if (num51 <= 50 & num55 > num51)
            {
              str8: String = str3;
              num53 = 25 + (int) Math.Round(Math.Abs((double) a * 0.15) / Math.Sqrt(Math.Sqrt((double) this.front.units.counter)));
              str9: String = num53.ToString();
              str3 = str8 + "*MoveToMoreRetreatProne: -" + str9;
              a -= (float) (25 + (int) Math.Round(Math.Abs((double) a * 0.15) / Math.Sqrt(Math.Sqrt((double) this.front.units.counter))));
            }
            else if (num51 > num55)
            {
              str10: String = str3;
              num53 = num51 - num55 + (int) Math.Round(Math.Abs((double) a * 0.15) / Math.Sqrt(Math.Sqrt((double) this.front.units.counter)));
              str11: String = num53.ToString();
              str3 = str10 + "*MoveIntoLessRetreatProne: " + str11;
              a += (float) (num51 - num55 + (int) Math.Round(Math.Abs((double) a * 0.15) / Math.Sqrt(Math.Sqrt((double) this.front.units.counter))));
            }
          }
          if (tSupply1.Value[matrixX, index41] > this.ai.VAR_SUPPLY_MAXIMUM_RANGE & this.FriendlySupply.Value[matrixX, index41] > this.ai.VAR_SUPPLY_MAXIMUM_RANGE && tSupply1.Value[index2, tdata1] < this.ai.VAR_SUPPLY_25PERCENT_RANGE)
          {
            str12: String = str3;
            num53 = 350 + (int) Math.Round(Math.Abs((double) a * 0.5) / (double) this.front.units.counter);
            str13: String = num53.ToString();
            str3 = str12 + "*MoveIntoSup: +" + str13;
            a += (float) (50 + (int) Math.Round(Math.Abs((double) a * 0.5) / (double) this.front.units.counter));
          }
          if (tSupply1.Value[index2, tdata1] < this.ai.VAR_SUPPLY_25PERCENT_RANGE)
          {
            int index42 = 0;
            do
            {
              Coordinate coordinate = this.ai.TempHexNeighbour[this.GetMatrixX(index2), tdata1 + this.Top, index42];
              if (coordinate.onmap && this.ai.frontMatrix.Value[coordinate.x, coordinate.y] != this.front.FrontID)
              {
                AIFront front = this.frontList.FindFront(this.ai.frontMatrix.Value[coordinate.x, coordinate.y]);
                if (!Information.IsNothing((object) front) && front.FrontType == 11 | front.FrontType == 12)
                {
                  if (this.ai.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].UnitCounter > -1)
                  {
                    str14: String = str3;
                    num53 = 550 + (int) Math.Round(Math.Abs((double) a * 0.8) / (double) this.front.units.counter);
                    str15: String = num53.ToString();
                    str3 = str14 + "*ContactWithEncircledUnit: +" + str15;
                    a += (float) (550 + (int) Math.Round(Math.Abs((double) a * 0.8) / (double) this.front.units.counter));
                  }
                  else
                  {
                    str16: String = str3;
                    num53 = 350 + (int) Math.Round(Math.Abs((double) a * 0.5) / (double) this.front.units.counter);
                    str17: String = num53.ToString();
                    str3 = str16 + "*ContactWithEncircledHex: +" + str17;
                    a += (float) (350 + (int) Math.Round(Math.Abs((double) a * 0.5) / (double) this.front.units.counter));
                  }
                }
              }
              index42 += 1;
            }
            while (index42 <= 5);
          }
          if (tSupply1.Value[matrixX, index41] > this.ai.VAR_SUPPLY_MAXIMUM_RANGE & this.FriendlySupply.Value[matrixX, index41] > this.ai.VAR_SUPPLY_MAXIMUM_RANGE && tSupply1.Value[index2, tdata1] < this.ai.VAR_SUPPLY_25PERCENT_RANGE)
          {
            str18: String = str3;
            num53 = 350 + (int) Math.Round(Math.Abs((double) a * 0.5) / (double) this.front.units.counter);
            str19: String = num53.ToString();
            str3 = str18 + "*MoveIntoSup: +" + str19;
            a += (float) (50 + (int) Math.Round(Math.Abs((double) a * 0.5) / (double) this.front.units.counter));
          }
          if (tSupply1.Value[index2, tdata1] > this.ai.VAR_SUPPLY_MAXIMUM_RANGE & tOwner.Value[index2, tdata1] == 1 && tSupply1.Value[matrixX, index41] < this.ai.VAR_SUPPLY_25PERCENT_RANGE)
          {
            if (this.ai.GetRegime(this.ai.map.HexObj[this.GetRealX(index2), tdata1 + this.Top].Regime) != this.ai.GetGameDataTurn() & this.front.Stance == 3)
            {
              str20: String = str3;
              num53 = 225 + (int) Math.Round(Math.Abs((double) a * 0.5) / Math.Sqrt(Math.Sqrt((double) this.front.units.counter)));
              str21: String = num53.ToString();
              str3 = str20 + "*MoveOutOfSup: -" + str21;
              a -= (float) (25 + (int) Math.Round(Math.Abs((double) a * 0.5) / Math.Sqrt(Math.Sqrt((double) this.front.units.counter))));
            }
            else if (this.front.Stance == 3)
            {
              str22: String = str3;
              num53 = 225 + (int) Math.Round(Math.Abs((double) a * 0.5) / Math.Sqrt(Math.Sqrt((double) this.front.units.counter)));
              str23: String = num53.ToString();
              str3 = str22 + "*MoveOutOfSup: -" + str23;
              a -= (float) (25 + (int) Math.Round(Math.Abs((double) a * 0.5) / Math.Sqrt(Math.Sqrt((double) this.front.units.counter))));
            }
            else
            {
              str24: String = str3;
              num53 = 250 + (int) Math.Round(Math.Abs((double) a * 0.5) / Math.Sqrt(Math.Sqrt((double) this.front.units.counter)));
              str25: String = num53.ToString();
              str3 = str24 + "*MoveOutOfSup: -" + str25;
              a -= (float) (50 + (int) Math.Round(Math.Abs((double) a * 0.5) / Math.Sqrt(Math.Sqrt((double) this.front.units.counter))));
            }
          }
          if (this.friendlySupplyIdeal.Value[index2, tdata1] >= 999 & tOwner.Value[index2, tdata1] == 1)
          {
            str26: String = str3;
            num53 = 50 + (int) Math.Round((double) (Math.Abs(a) / (float) this.front.units.counter));
            str27: String = num53.ToString();
            str3 = str26 + "*MoveOutOfIDEALSup: -" + str27;
            a -= (float) (50 + (int) Math.Round((double) (Math.Abs(a) / (float) this.front.units.counter)));
          }
        }
      }
      this.Score += (int) Math.Round((double) a);
      if (this.front.FrontType == 13)
      {
        AIMatrix aiMatrix2 = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
        int val2 = 0;
        int num56 = 0;
        int counter14 = this.front.units.counter;
        for (int index43 = 0; index43 <= counter14; index43 += 1)
        {
          val2 += 1;
          int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index43]);
          if (unitByAiid > -1)
          {
            num51 = this.ai.game.HandyFunctionsObj.GetMaxAARange(unitByAiid);
            num51 += 1;
            int x = this.ai.game.Data.UnitObj[unitByAiid].X;
            int y = this.ai.game.Data.UnitObj[unitByAiid].Y;
            int counter15 = this.MoveList.Counter;
            for (int index44 = 0; index44 <= counter15; index44 += 1)
            {
              if (this.MoveList.Move[index44].UnitAIid == this.front.units.AIid[index43] && this.MoveList.Move[index44].MoveTo.onmap)
              {
                x = this.MoveList.Move[index44].MoveTo.x;
                y = this.MoveList.Move[index44].MoveTo.y;
              }
            }
            int matrixX = this.GetMatrixX(x);
            int index45 = y - this.Top;
            if (this.FrontArea.Value[matrixX, index45] == this.front.TargetFrontID)
            {
              if (num51 > aiMatrix2.Value[matrixX, index45])
                aiMatrix2.Value[matrixX, index45] = num51;
              if (this.ai.game.Data.MapObj[0].HexObj[x, y].UnitCounter > -1)
              {
                int unitCounter = this.ai.game.Data.MapObj[0].HexObj[x, y].UnitCounter;
                for (int index46 = 0; index46 <= unitCounter; index46 += 1)
                {
                  if (this.ai.game.Data.UnitObj[this.ai.game.Data.MapObj[0].HexObj[x, y].UnitList[index46]].TempCategory == 1)
                  {
                    num56 += 1;
                    break;
                  }
                }
              }
            }
          }
        }
        aiMatrix2.ExpandValueWithoutConditionsDimishWithOneAndOverwriteSmaller(9);
        num51 = 0;
        int width5 = this.Width;
        for (int tx = 0; tx <= width5; tx += 1)
        {
          int height = this.Height;
          for (int index47 = 0; index47 <= height; index47 += 1)
          {
            if (this.Owner.Value[tx, index47] == 1 & aiMatrix2.Value[tx, index47] > 0)
            {
              int realX = this.GetRealX(tx);
              int index48 = index47 + this.Top;
              if (this.ai.game.Data.MapObj[0].HexObj[realX, index48].UnitCounter > -1)
              {
                int unitCounter = this.ai.game.Data.MapObj[0].HexObj[realX, index48].UnitCounter;
                for (int index49 = 0; index49 <= unitCounter; index49 += 1)
                {
                  int unit = this.ai.game.Data.MapObj[0].HexObj[realX, index48].UnitList[index49];
                  if (this.ai.game.Data.UnitObj[unit].Regime == this.ai.game.Data.Turn)
                  {
                    if (this.ai.game.Data.UnitObj[unit].TempCategory != 5)
                    {
                      if (this.ai.game.Data.UnitObj[unit].TempCategory == 2)
                        num51 += 4;
                      else if (this.ai.game.Data.UnitObj[unit].TempCategory == 1)
                        num51 += 2;
                      else if (this.ai.game.Data.UnitObj[unit].TempCategory == 3 | this.ai.game.Data.UnitObj[unit].TempCategory == 13)
                        num51 += 4;
                      else if (this.ai.game.Data.UnitObj[unit].TempCategory2 == 14 | this.ai.game.Data.UnitObj[unit].TempCategory == 14)
                        num51 += 4;
                      else
                        num51 += 1;
                    }
                    if (this.ai.game.Data.UnitObj[unit].AIGroup == this.front.TargetFrontID)
                      num51 *= 3;
                  }
                }
              }
            }
          }
        }
        if (num51 > 0)
          this.Score += (int) Math.Round(0.2 * (double) (num51 * 125)) + (int) Math.Round(0.8 * ((double) num56 / (double) Math.Min(1, val2)) * (double) (num51 * 125));
      }
      if ((double) this.initEncRatio1 - (double) this.finalEncRatio1 < 0.0)
      {
        if ((double) this.initEncRatio1 - (double) this.finalEncRatio1 < -0.3)
          this.Score -= 6000;
        else if ((double) this.initEncRatio1 - (double) this.finalEncRatio1 < -0.2)
          this.Score -= 4000;
        else if ((double) this.initEncRatio1 - (double) this.finalEncRatio1 < -0.1)
          this.Score -= 2000;
        else
          this.Score -= 1000;
      }
      if (!this.ai.VAR_DEBUG_ON)
        str3 = "x";
      if (this.ai.VAR_DEBUG_ON & this.MoveList.Counter > -1)
      {
        str3 += "..... UNITS: ";
        int counter16 = this.MoveList.Counter;
        for (int index50 = 0; index50 <= counter16; index50 += 1)
        {
          if (this.MoveList.Move[index50].MoveTo.onmap)
          {
            this.GetMatrixX(this.MoveList.Move[index50].MoveTo.x);
            int num57 = this.MoveList.Move[index50].MoveTo.y - this.Top;
            int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index50].UnitAIid);
            str3 = str3 + this.ai.game.Data.UnitObj[unitByAiid].Name + ",";
          }
        }
      }
      if (this.Score == 1)
        this.Score = this.Score;
      if (this.MoveList.Counter > 0 && this.MoveList.Move[0].MoveTo.x == 39 & this.MoveList.Move[0].MoveTo.y == 32)
        this.Score = this.Score;
      return str3;
    }

    pub string BACKUP_SetScore(bool doLog, bool IsAttack = false, int AttackX = -1, int AttackY = -1)
    {
      this.Score = 0;
      if (this.MoveList.Counter == -1 & AttackX != -2)
      {
        this.Score = -9999999;
        return "NO MOVES = NO SCORE";
      }
      int num1;
      if (this.front.FrontID == 792)
        num1 = num1;
      if (AttackX == -2)
        AttackX = -1;
      this.enemyDistance = this.Owner.Clone();
      this.enemyDistance.RemoveValuesByMask(this.Owner, 1);
      this.enemyDistance.ExpandAndAddValueForAnyRegime(19);
      this.enemyDistance.SetAllValuesSubtractWith(2);
      AIMatrix vp = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      AIMatrix tSupply1 = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      AIMatrix tSupply2 = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      float num2 = 0.0f;
      float num3 = 0.0f;
      int num4 = 0;
      int num5 = 0;
      int counter1 = this.front.units.counter;
      int index1;
      int index2;
      int tdata1;
      for (index1 = 0; index1 <= counter1; index1 += 1)
      {
        int id = this.front.units.AIid[index1];
        int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(id);
        int matrixX = this.GetMatrixX(this.ai.game.Data.UnitObj[unitByAiid].X);
        int index3 = this.ai.game.Data.UnitObj[unitByAiid].Y - this.Top;
        index2 = matrixX;
        tdata1 = index3;
        int counter2 = this.MoveList.Counter;
        for (int index4 = 0; index4 <= counter2; index4 += 1)
        {
          AIMove aiMove = this.MoveList.Move[index4];
          if (aiMove.UnitAIid == id)
          {
            if (aiMove.finalTo.onmap)
            {
              index2 = this.GetMatrixX(aiMove.finalTo.x);
              tdata1 = aiMove.finalTo.y - this.Top;
            }
            else if (aiMove.MoveTo.onmap)
            {
              index2 = this.GetMatrixX(aiMove.MoveTo.x);
              tdata1 = aiMove.MoveTo.y - this.Top;
            }
            else if (aiMove.AttackOn.onmap)
            {
              index2 = this.GetMatrixX(aiMove.AttackOn.x);
              tdata1 = aiMove.AttackOn.y - this.Top;
            }
          }
        }
        if (index2 == -1)
        {
          index2 = matrixX;
          tdata1 = index3;
        }
        num2 += (float) (int) Math.Round((double) (this.enemyDistance.Value[matrixX, index3] * 100 * Math.Max(0, 100 - this.Advance.Value[matrixX, index3])) / 100.0);
        num3 += (float) (int) Math.Round((double) (this.enemyDistance.Value[index2, tdata1] * 100 * Math.Max(0, 100 - this.Advance.Value[index2, tdata1])) / 100.0);
      }
      this.finalOrigEnemyUnits = 0;
      int num6 = 0;
      int width1 = this.Width;
      for (int tx = 0; tx <= width1; tx += 1)
      {
        int height = this.Height;
        for (int index5 = 0; index5 <= height; index5 += 1)
        {
          if (this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(tx), this.Top + index5].UnitCounter > -1 && this.FrontArea.Value[tx, index5] == this.front.FrontID & this.Owner.Value[tx, index5] == 2)
            this.finalOrigEnemyUnits += this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(tx), this.Top + index5].UnitCounter + 1;
          if (this.FrontArea.Value[tx, index5] == this.front.FrontID & this.Owner.Value[tx, index5] == 1)
            num6 += this.allTroops.Value[tx, index5];
          if (this.Owner.Value[tx, index5] == 1)
            num4 += this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(tx), this.Top + index5].VP;
          int[,] numArray1 = vp.Value;
          int[,] numArray2 = numArray1;
          int index6 = tx;
          int index7 = index6;
          int index8 = index5;
          int index9 = index8;
          int num7 = numArray1[index6, index8] + this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(tx), this.Top + index5].VP;
          numArray2[index7, index9] = num7;
          int[,] numArray3 = vp.Value;
          int[,] numArray4 = numArray3;
          int index10 = tx;
          int index11 = index10;
          int index12 = index5;
          int index13 = index12;
          int num8 = numArray3[index10, index12] + this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].AIVP[0].Value[this.GetRealX(tx), this.Top + index5];
          numArray4[index11, index13] = num8;
        }
      }
      if ((double) this.ai.game.Data.RuleVar[455] > 0.0)
        this.ResetOwner();
      this.Setsupplymatrix(ref tSupply1, ref this.Owner, 1);
      tSupply1.Clone();
      if (this.front.FrontID == 722)
        num1 = index1;
      this.finalEncRatio5 = this.GetTroopsRatioOutOfSupply(ref tSupply1, ref this.allTroops, ref this.Owner, 1);
      this.finalEncRatio6 = this.GetTroopsFrontRatioOutOfSupply(ref tSupply1, ref this.allTroops, ref this.Owner, 1);
      AIMatrix tOwner = this.Owner.Clone();
      AIMatrix tTroops = this.allTroops.Clone().AverageAndDivideValuesForSameRegime_NotForVP(1, vp, tOwner, OnlyOwnerX: 1, dividy: 60).AverageValuesForSameRegime(2, tOwner, OnlyOwnerX: 2);
      int initialFrontAreaHexes = this.GetInitialFrontAreaHexes(ref tTroops, ref tOwner, 1);
      if (this.ai.VAR_ENEMYMOVE_PROGNOSIS_MODE <= 2)
      {
        if ((double) this.front.UnitCountRatio < 1.25 & this.front.Stance == 2)
        {
          this.GetEnemyMove(5f, true, ref tOwner, ref tTroops, 1, false);
          this.GetEnemyMove(10f, true, ref tOwner, ref tTroops, 1, false);
        }
        else if ((double) this.front.UnitCountRatio < 0.75)
          this.GetEnemyMove(5f, true, ref tOwner, ref tTroops, 1, false);
        else
          this.GetEnemyMove(5f, true, ref tOwner, ref tTroops, 1, false);
      }
      if (this.ai.CustomCalls.CustomDoStrategicIterations())
      {
        this.GetEnemyMove(10f, true, ref tOwner, ref tTroops, 1, false);
        this.Setsupplymatrix(ref tSupply1, ref tOwner, 1);
      }
      float ratioOutOfSupply1 = this.GetTroopsRatioOutOfSupply(ref tSupply1, ref tTroops, ref tOwner, 1);
      float ratioOutOfSupply2 = this.GetTroopsFrontRatioOutOfSupply(ref tSupply1, ref tTroops, ref tOwner, 1);
      this.GetEnemyMove(6f, true, ref tOwner, ref tTroops, 1, false);
      this.GetEnemyMove(24f, true, ref tOwner, ref tTroops, 1, false);
      if (this.front.Stance == 1)
      {
        this.Setsupplymatrix(ref tSupply1, ref tOwner, 1);
        this.FriendlySupplyAfterEnemyMove = tSupply1.Clone();
      }
      float ratioOutOfSupply3 = this.GetTroopsRatioOutOfSupply(ref tSupply1, ref tTroops, ref tOwner, 1);
      float ratioOutOfSupply4 = this.GetTroopsFrontRatioOutOfSupply(ref tSupply1, ref tTroops, ref tOwner, 1);
      if ((double) this.front.UnitCountRatio <= 1.0)
        this.GetEnemyMove(20f, true, ref tOwner, ref tTroops, 1, false);
      this.Setsupplymatrix(ref tSupply2, ref tOwner, 2);
      this.Setsupplymatrix(ref tSupply1, ref tOwner, 1);
      this.finalEncRatio1 = this.GetTroopsRatioOutOfSupply(ref tSupply1, ref tTroops, ref tOwner, 1);
      this.finalEncRatio2 = this.GetTroopsFrontRatioOutOfSupply(ref tSupply1, ref tTroops, ref tOwner, 1);
      this.finalEncRatio1 = (float) (((double) ratioOutOfSupply1 + (double) ratioOutOfSupply3 + (double) this.finalEncRatio1) / 3.0);
      this.finalEncRatio2 = (float) (((double) ratioOutOfSupply2 + (double) ratioOutOfSupply4 + (double) this.finalEncRatio2) / 3.0);
      this.finalEncRatio3 = this.GetTroopsRatioOutOfSupply(ref tSupply2, ref this.troopsstrength, ref this.Owner, 2);
      this.finalEncRatio4 = this.GetTroopsFrontRatioOutOfSupply(ref tSupply2, ref this.troopsstrength, ref this.Owner, 2);
      this.finalHexes = this.GetInitialFrontAreaHexes(ref tTroops, ref tOwner, 1);
      this.finalHexesTot = this.GetInitialHexes(ref tTroops, ref tOwner, 1);
      float num9;
      float num10;
      if (this.front.Stance == 3)
      {
        if ((double) this.front.UnitCountRatio > 1.0)
        {
          num9 = (float) (((double) this.initEncRatio1 - (double) this.finalEncRatio1) * (3.0 / (double) this.front.UnitCountRatio));
          num10 = (float) (((double) this.initEncRatio2 - (double) this.finalEncRatio2) * (3.0 / (double) this.front.UnitCountRatio));
        }
        else
        {
          num9 = (float) (((double) this.initEncRatio1 - (double) this.finalEncRatio1) * 3.0);
          num10 = (float) (((double) this.initEncRatio2 - (double) this.finalEncRatio2) * 3.0);
        }
      }
      else
      {
        num9 = (float) (((double) this.initEncRatio1 - (double) this.finalEncRatio1) * 3.0);
        num10 = (float) (((double) this.initEncRatio2 - (double) this.finalEncRatio2) * 3.0);
      }
      float num11 = this.initEncRatio5 - this.finalEncRatio5;
      float num12 = this.initEncRatio6 - this.finalEncRatio6;
      float num13 = 0.0f;
      if (this.InitHexes < 1)
        this.InitHexes = 1;
      if (this.initHexesTot < 1)
        this.initHexesTot = 1;
      if (this.front.Stance == 3)
        num13 = (float) (3.0 * (double) ((float) (initialFrontAreaHexes + this.finalHexes) / 2f / (float) this.InitHexes) - 1.0);
      float num14 = num13 + (float) (3.0 * (double) ((float) this.finalHexes / (float) this.InitHexes) - 1.0);
      float num15 = (float) (3.0 * ((double) ((float) this.finalHexesTot / (float) this.initHexesTot) - 1.0));
      if ((double) num14 > 0.0)
        num14 = (float) (int) Math.Round((double) num14 * 3.5);
      if ((double) num15 > 0.0)
        num15 = (float) (int) Math.Round((double) num15 * 1.5);
      if ((double) num9 < 0.0)
        num15 = num15 * (float) (1.0 - Math.Min(0.9, (double) Math.Abs(num9))) * (float) (1.0 - Math.Min(0.9, (double) Math.Abs(num9)));
      if ((double) num10 < 0.0)
      {
        num14 = num14 * (float) (1.0 - Math.Min(0.9, (double) Math.Abs(num10 / 4f))) * (float) (1.0 - Math.Min(0.9, (double) Math.Abs(num10 / 4f)));
        if ((double) num14 > 0.0)
          num14 = 0.0f;
      }
      int num16 = 1;
      if (IsAttack && this.enemySupply.Value[AttackX, AttackY] > this.ai.VAR_SUPPLY_MAXIMUM_RANGE)
        num16 = 0;
      float num17;
      float num18;
      if (num16 == 1)
      {
        float num19;
        num17 = num19 - (this.initEncRatio3 - this.finalEncRatio3);
        float num20;
        num18 = num20 - (this.initEncRatio4 - this.finalEncRatio4);
      }
      string str1;
      str2: String = str1 + "BefMoveOwnAllOut: " + num11.ToString() + ", BefMoveOwnFrTrOut: " + num12.ToString() + "AftMoveOwnAllOut: " + num9.ToString() + ", AftMoveOwnFrTrOut: " + num10.ToString() + ", EnmAllOut: " + num17.ToString() + ", EnmFrOut: " + num18.ToString() + ", HexTot: " + num15.ToString() + ", HexFr: " + num14.ToString() + ". ";
      float num21 = num9 + num10 + num14 + num15 + num17 + num18 + num11 + num12;
      str3: String = str2 + "*" + this.initOrigEnemyUnits.ToString() + "/" + this.finalOrigEnemyUnits.ToString();
      float num22;
      if (this.initOrigEnemyUnits > this.finalOrigEnemyUnits)
      {
        if (this.finalOrigEnemyUnits >= 1)
        {
          float num23 = (float) Math.Sqrt((double) this.initOrigEnemyUnits / (double) this.finalOrigEnemyUnits);
          str3 = str3 + " * EnmUnitHexTaken: *" + num23.ToString();
          if ((double) num23 > 3.0)
            num23 = 3f;
          num21 += (float) (3.0 * ((double) Math.Abs(num21 * num23) - (double) Math.Abs(num21)));
        }
        else
        {
          num22 = 3f * (float) Math.Sqrt((double) (1 + this.initOrigEnemyUnits));
          if ((double) num22 > 3.0)
            num22 = 3f;
          str3 = str3 + " * EnmUnitHexTaken: *" + num22.ToString();
          num21 += (float) (1.0 * ((double) Math.Abs(num21 * num22) - (double) Math.Abs(num21)));
        }
      }
      int num24 = 0;
      int width2 = this.Width;
      for (int tx = 0; tx <= width2; tx += 1)
      {
        int height = this.Height;
        for (int index14 = 0; index14 <= height; index14 += 1)
        {
          if (this.FrontArea.Value[tx, index14] == this.front.FrontID & tOwner.Value[tx, index14] == 1)
            num24 += tTroops.Value[tx, index14];
          if (this.Owner.Value[tx, index14] == 1)
            num5 += this.ai.game.Data.MapObj[0].HexObj[this.GetRealX(tx), this.Top + index14].VP;
        }
      }
      if (num6 > num24 & num6 > 0)
      {
        num22 = 1f - (float) num24 / (float) num6;
        str3 = str3 + " * FriendlyUnitsLost: *" + num22.ToString();
        num22 *= 0.75f;
        num21 -= Math.Abs(num21 * num22);
        if ((double) num14 > 0.0)
          num21 -= Math.Abs(num14 * 2f * num22);
        if ((double) num15 > 0.0)
          num21 -= Math.Abs(num15 * 2f * num22);
      }
      if (this.front.FrontID > 10000)
        str3 = str3;
      if (this.front.DefensiveZone > 0)
      {
        SimpleList simpleList = SimpleList::new();
        float num25 = 0.0f;
        int num26 = 0;
        int num27 = 0;
        int counter3 = this.front.units.counter;
        for (int index15 = 0; index15 <= counter3; index15 += 1)
        {
          int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index15]);
          if (unitByAiid > -1)
          {
            index2 = this.ai.game.Data.UnitObj[unitByAiid].X;
            tdata1 = this.ai.game.Data.UnitObj[unitByAiid].Y;
            int counter4 = this.MoveList.Counter;
            for (int index16 = 0; index16 <= counter4; index16 += 1)
            {
              if (this.MoveList.Move[index16].UnitAIid == this.front.units.AIid[index15] && this.MoveList.Move[index16].MoveTo.onmap)
              {
                index2 = this.MoveList.Move[index16].MoveTo.x;
                tdata1 = this.MoveList.Move[index16].MoveTo.y;
              }
            }
            if (this.ai.VAR_MATRIX_ZONES.Value[index2, tdata1] + 1000000 == this.front.FrontID)
            {
              num26 += 1;
              if (simpleList.FindNr(index2, tdata1) > -1)
              {
                int[] weight = simpleList.Weight;
                int[] numArray = weight;
                int nr = simpleList.FindNr(index2, tdata1);
                int index17 = nr;
                int num28 = weight[nr] + 1;
                numArray[index17] = num28;
              }
              else
                simpleList.Add(index2, 1, tdata1, CheckExistence: false);
            }
            else
              num27 += 1;
          }
        }
        if (num26 + num27 > 0)
          num25 = (float) (6.0 * ((double) num26 / (double) (num26 + num27)));
        if (simpleList.Counter > -1)
        {
          int index18 = 9999;
          int[] numArray5 = new int[22];
          int num29 = 0;
          int num30 = 0;
          int width3 = this.Width;
          for (int tx = 0; tx <= width3; tx += 1)
          {
            int height = this.Height;
            for (int index19 = 0; index19 <= height; index19 += 1)
            {
              if (this.ai.VAR_MATRIX_ZONES.Value[this.GetRealX(tx), index19 + this.Top] + 1000000 == this.front.FrontID)
              {
                int num31 = 0;
                int counter5 = simpleList.Counter;
                for (int index20 = 0; index20 <= counter5; index20 += 1)
                {
                  index2 = simpleList.Id[index20];
                  tdata1 = simpleList.Data1[index20];
                  if (index2 == tx + this.Left & tdata1 == index19 + this.Top)
                  {
                    index18 = simpleList.Weight[index20];
                    num31 += simpleList.Weight[index20];
                  }
                }
                if (num31 == 0)
                {
                  index18 = 0;
                  num30 += 1;
                }
                else
                  num29 += 1;
                if (index18 < 20)
                {
                  int[] numArray6 = numArray5;
                  int[] numArray7 = numArray6;
                  int index21 = index18;
                  int index22 = index21;
                  int num32 = numArray6[index21] + 1;
                  numArray7[index22] = num32;
                }
              }
            }
          }
          if (index18 < 20)
          {
            if (num30 == 0)
              num30 = num30;
            num25 = (float) ((double) num25 * 0.5 + (double) num25 * 0.5 * ((double) num29 / (double) (num29 + num30)));
            int num33 = numArray5[index18];
            for (int index23 = 1; index23 <= num33; index23 += 1)
              num25 = (float) ((double) num25 * 0.8 + (double) num25 * 0.2 * (double) index18);
          }
        }
        str3 = str3 + " ,DefZ-Extra:+" + num25.ToString();
        num21 += num25;
      }
      float a = num21 * 1000f;
      if ((double) num2 > (double) num3)
      {
        float num34 = (float) ((double) num2 / (double) num3 - 1.0) * (float) (5 + this.front.units.counter + 1);
        if ((double) num34 > 0.2)
          num34 = num34;
        if ((double) num34 > 1.0)
          num34 = 1f;
        if ((double) num34 < 0.0)
          num34 = 0.0f;
        if (this.front.Stance == 3)
          a += (float) (150.0 * (double) num34 + (double) num34 * (double) Math.Abs(a) * 0.349999994039536);
        else
          a += (float) (30.0 * (double) num34 + (double) num34 * (double) a * 0.100000001490116);
      }
      if (this.front.Stance == 3 && this.ai.VAR_DC4_ATTACKUNIT_IS_IMPORTANT)
      {
        int counter6 = this.MoveList.Counter;
        for (int index24 = 0; index24 <= counter6; index24 += 1)
        {
          if (this.MoveList.Move[index24].AttackOn.onmap && this.front.units.FindAiIDSlot(this.MoveList.Move[index24].UnitAIid) > -1)
          {
            int num35 = (int) Math.Round((double) (33 + (int) Math.Round((double) (100 * this.origAllTroops.Value[this.GetMatrixX(this.MoveList.Move[index24].AttackOn.x), this.MoveList.Move[index24].AttackOn.y - this.Top]) / (double) this.front.enemyPower)) / 2.0);
            float num36 = (float) ((this.front.Stance != 3 ? (double) Math.Max(150f, Math.Abs(a / 30f)) : (double) Math.Max(50f, Math.Abs(a / 15f))) * (double) num35 / 100.0);
            str3 = str3 + " ,AttackTakingPlaceBonus: +" + num36.ToString();
            a += num36;
            break;
          }
        }
        int counter7 = this.MoveList.Counter;
        for (int index25 = 0; index25 <= counter7; index25 += 1)
        {
          if (this.MoveList.Move[index25].AttackOn.onmap && this.front.artUnits.FindAiIDSlot(this.MoveList.Move[index25].UnitAIid) > -1)
          {
            int num37 = 25;
            float num38 = (float) ((double) Math.Max(50f, Math.Abs(a / 20f)) * (double) num37 / 100.0);
            str3 = str3 + " ,ArtilleryAttackTakingPlaceBonus: +" + num38.ToString();
            a += num38;
            break;
          }
        }
      }
      int counter8 = this.front.artUnits.counter;
      int num39;
      for (int index26 = 0; index26 <= counter8; index26 += 1)
      {
        int unitByAiid1 = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.artUnits.AIid[index26]);
        if (unitByAiid1 > -1 && this.ai.game.Data.UnitObj[unitByAiid1].TempCategory == 2)
        {
          int num40 = 0;
          num39 = 0;
          int x1 = this.ai.game.Data.UnitObj[unitByAiid1].X;
          int y1 = this.ai.game.Data.UnitObj[unitByAiid1].Y;
          int counter9 = this.MoveList.Counter;
          for (int index27 = 0; index27 <= counter9; index27 += 1)
          {
            if (this.MoveList.Move[index27].MoveTo.onmap && unitByAiid1 == this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index27].UnitAIid))
            {
              x1 = this.MoveList.Move[index27].MoveTo.x;
              y1 = this.MoveList.Move[index27].MoveTo.y;
            }
          }
          int counter10 = this.MoveList.Counter;
          for (int index28 = 0; index28 <= counter10; index28 += 1)
          {
            int unitByAiid2 = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index28].UnitAIid);
            if (this.ai.game.Data.UnitObj[unitByAiid2].TempCategory != 2 & this.ai.game.Data.UnitObj[unitByAiid2].TempCategory2 != 14 && this.MoveList.Move[index28].MoveTo.onmap)
            {
              int x2 = this.MoveList.Move[index28].MoveTo.x;
              int y2 = this.MoveList.Move[index28].MoveTo.y;
              if (x2 == x1 & y2 == y1)
                num40 += this.ai.game.Data.UnitObj[unitByAiid2].TempUnitPowerAbs;
            }
          }
          int unitCounter = this.ai.game.Data.MapObj[0].HexObj[x1, y1].UnitCounter;
          for (int index29 = 0; index29 <= unitCounter; index29 += 1)
          {
            int index30 = this.ai.game.Data.MapObj[0].HexObj[x1, y1].UnitList[index29];
            if (this.ai.game.Data.UnitObj[index30].TempCategory != 2 & this.ai.game.Data.UnitObj[index30].TempCategory2 != 14 && this.ai.game.Data.UnitObj[index30].X == x1 & this.ai.game.Data.UnitObj[index30].Y == y1)
            {
              int counter11 = this.MoveList.Counter;
              for (int index31 = 0; index31 <= counter11; index31 += 1)
              {
                if (this.MoveList.Move[index31].MoveTo.onmap && index30 == this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index31].UnitAIid))
                {
                  index30 = -1;
                  break;
                }
              }
              if (index30 > -1)
                num40 += this.ai.game.Data.UnitObj[index30].TempUnitPowerAbs;
            }
          }
          float num41 = 0.33f;
          if (this.GetMatrixX(x1) <= this.Width & this.GetMatrixX(x1) >= 0 && y1 - this.Top <= this.Height & y1 - this.Top >= 0)
            num41 = this.enemyDistance.Value[this.GetMatrixX(x1), y1 - this.Top] > 1 ? (this.enemyDistance.Value[this.GetMatrixX(x1), y1 - this.Top] > 2 ? (this.enemyDistance.Value[this.GetMatrixX(x1), y1 - this.Top] > 3 ? (this.enemyDistance.Value[this.GetMatrixX(x1), y1 - this.Top] > 4 ? (this.enemyDistance.Value[this.GetMatrixX(x1), y1 - this.Top] > 5 ? (this.enemyDistance.Value[this.GetMatrixX(x1), y1 - this.Top] > 6 ? 0.0f : 0.25f) : 0.4f) : 0.55f) : 0.7f) : 0.8f) : 0.95f;
          float num42 = num41 / (float) Math.Sqrt((double) (this.front.artUnits.counter + 1));
          if ((double) num42 > 0.0)
          {
            if (num40 > 0)
            {
              int num43 = this.ai.game.Data.UnitObj[unitByAiid1].TempUnitPowerAbs + 250;
              if (num40 > num43 * 2)
                a = a + Math.Abs((float) (1 * num43) * (num42 * 1.5f)) + 250f * num42;
              else if (num40 > num43 * 1)
                a = a + Math.Abs((float) (1 * num43) * num42) + 150f * num42;
              else if (num40 <= num43)
                a = a - Math.Abs((float) (1 * num43) * (num42 * 1.5f)) - 150f * num42;
            }
            else
            {
              int num44 = this.ai.game.Data.UnitObj[unitByAiid1].TempUnitPowerAbs + 250;
              a = a - Math.Abs((float) (1 * num44) * (num42 * 3f)) - 250f * num42;
            }
          }
        }
      }
      int counter12 = this.front.units.counter;
      for (int index32 = 0; index32 <= counter12; index32 += 1)
      {
        int unitByAiid3 = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.front.units.AIid[index32]);
        if (unitByAiid3 > -1 && this.ai.game.Data.UnitObj[unitByAiid3].TempCategory2 == 14)
        {
          int num45 = 0;
          num39 = 0;
          int x3 = this.ai.game.Data.UnitObj[unitByAiid3].X;
          int y3 = this.ai.game.Data.UnitObj[unitByAiid3].Y;
          int counter13 = this.MoveList.Counter;
          for (int index33 = 0; index33 <= counter13; index33 += 1)
          {
            if (this.MoveList.Move[index33].MoveTo.onmap && unitByAiid3 == this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index33].UnitAIid))
            {
              x3 = this.MoveList.Move[index33].MoveTo.x;
              y3 = this.MoveList.Move[index33].MoveTo.y;
            }
          }
          int counter14 = this.MoveList.Counter;
          for (int index34 = 0; index34 <= counter14; index34 += 1)
          {
            int unitByAiid4 = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index34].UnitAIid);
            if (this.ai.game.Data.UnitObj[unitByAiid4].TempCategory != 2 & this.ai.game.Data.UnitObj[unitByAiid4].TempCategory2 != 14 && this.MoveList.Move[index34].MoveTo.onmap)
            {
              int x4 = this.MoveList.Move[index34].MoveTo.x;
              int y4 = this.MoveList.Move[index34].MoveTo.y;
              if (x4 == x3 & y4 == y3)
                num45 += this.ai.game.Data.UnitObj[unitByAiid4].TempUnitPowerAbs;
            }
          }
          int unitCounter = this.ai.game.Data.MapObj[0].HexObj[x3, y3].UnitCounter;
          for (int index35 = 0; index35 <= unitCounter; index35 += 1)
          {
            int index36 = this.ai.game.Data.MapObj[0].HexObj[x3, y3].UnitList[index35];
            if (this.ai.game.Data.UnitObj[index36].TempCategory != 2 & this.ai.game.Data.UnitObj[index36].TempCategory2 != 14 && this.ai.game.Data.UnitObj[index36].X == x3 & this.ai.game.Data.UnitObj[index36].Y == y3)
            {
              int counter15 = this.MoveList.Counter;
              for (int index37 = 0; index37 <= counter15; index37 += 1)
              {
                if (this.MoveList.Move[index37].MoveTo.onmap && index36 == this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index37].UnitAIid))
                {
                  index36 = -1;
                  break;
                }
              }
              if (index36 > -1)
                num45 += this.ai.game.Data.UnitObj[index36].TempUnitPowerAbs;
            }
          }
          float num46 = 0.33f;
          if (this.GetMatrixX(x3) <= this.Width & this.GetMatrixX(x3) >= 0 && y3 - this.Top <= this.Height & y3 - this.Top >= 0)
            num46 = this.enemyDistance.Value[this.GetMatrixX(x3), y3 - this.Top] > 1 ? (this.enemyDistance.Value[this.GetMatrixX(x3), y3 - this.Top] > 2 ? (this.enemyDistance.Value[this.GetMatrixX(x3), y3 - this.Top] > 3 ? (this.enemyDistance.Value[this.GetMatrixX(x3), y3 - this.Top] > 4 ? (this.enemyDistance.Value[this.GetMatrixX(x3), y3 - this.Top] > 5 ? (this.enemyDistance.Value[this.GetMatrixX(x3), y3 - this.Top] > 6 ? 0.0f : 0.25f) : 0.4f) : 0.55f) : 0.7f) : 0.8f) : 0.95f;
          if ((double) num46 > 0.0)
          {
            if (num45 > 0)
            {
              int num47 = this.ai.game.Data.UnitObj[unitByAiid3].TempUnitPowerAbs + 250;
              if (num45 > num47 * 2)
                a = a + Math.Abs((float) (1 * num47) * (num46 * 1.5f)) + 250f * num46;
              else if (num45 > num47 * 1)
                a = a + Math.Abs((float) (1 * num47) * num46) + 150f * num46;
              else if (num45 <= num47)
                a = a - Math.Abs((float) (1 * num47) * (num46 * 1.5f)) - 150f * num46;
            }
            else
            {
              int num48 = this.ai.game.Data.UnitObj[unitByAiid3].TempUnitPowerAbs + 250;
              a = a - Math.Abs((float) (1 * num48) * (num46 * 3f)) - 250f * num46;
            }
          }
        }
      }
      int counter16 = this.MoveList.Counter;
      int num49;
      for (int index38 = 0; index38 <= counter16; index38 += 1)
      {
        int unr = -1;
        if (this.MoveList.Move[index38].MoveTo.onmap)
        {
          index2 = this.GetMatrixX(this.MoveList.Move[index38].MoveTo.x);
          tdata1 = this.MoveList.Move[index38].MoveTo.y - this.Top;
          unr = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index38].UnitAIid);
          int num50 = index38 + 1;
          int counter17 = this.MoveList.Counter;
          for (int index39 = num50; index39 <= counter17; index39 += 1)
          {
            if (unr == this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index39].UnitAIid) && this.MoveList.Move[index39].MoveTo.onmap & !this.MoveList.Move[index39].AttackOn.onmap)
              unr = -1;
          }
        }
        if (unr > -1 & !this.MoveList.Move[index38].AttackOn.onmap & this.front.units.counter > -1)
        {
          int num51 = this.ai.game.HandyFunctionsObj.GetHexStackPts(this.GetRealX(index2), tdata1 + this.Top, 0) + this.ai.game.HandyFunctionsObj.GetUnitStackPts(unr);
          if (num51 > this.ai.VAR_HEX_STACK_REGULAR)
          {
            str4: String = str3;
            num49 = 25 + (int) Math.Round(Math.Abs((double) a * ((double) num51 / (double) this.ai.VAR_HEX_STACK_REGULAR - 1.0)) / Math.Sqrt((double) (this.front.units.counter + 1)));
            str5: String = num49.ToString();
            str3 = str4 + "*OverStack: -" + str5;
            a -= (float) (25 + (int) Math.Round(Math.Abs((double) a * ((double) num51 / (double) this.ai.VAR_HEX_STACK_REGULAR - 1.0)) / Math.Sqrt((double) (this.front.units.counter + 1))));
          }
        }
        if (unr > -1)
        {
          if (this.front.DefensiveZone > 0 & this.ai.VAR_MATRIX_ZONES.Value[this.ai.game.Data.UnitObj[unr].X, this.ai.game.Data.UnitObj[unr].Y] + 1000000 != this.front.FrontID)
          {
            if (this.ai.VAR_MATRIX_ZONES.Value[this.GetRealX(index2), tdata1 + this.Top] + 1000000 == this.front.FrontID)
            {
              a += (float) (1000 + (int) Math.Round((double) Math.Abs(this.Score) * 0.3));
            }
            else
            {
              Coordinate averageFrontCoordinate = this.front.GetAverageFrontCoordinate(this.front.FrontID - 1000000);
              int num52 = this.ai.game.HandyFunctionsObj.Distance(index2 + this.Left, tdata1 + this.Top, 0, averageFrontCoordinate.x, averageFrontCoordinate.y, 0);
              int num53 = this.ai.game.HandyFunctionsObj.Distance(this.ai.game.Data.UnitObj[unr].X, this.ai.game.Data.UnitObj[unr].Y, 0, averageFrontCoordinate.x, averageFrontCoordinate.y, 0);
              a += (float) ((num53 - num52) * (400 + (int) Math.Round((double) Math.Abs(this.Score) * 0.2)));
            }
          }
          if (this.front.DefensiveZone > 0 & this.ai.VAR_MATRIX_ZONES.Value[this.ai.game.Data.UnitObj[unr].X, this.ai.game.Data.UnitObj[unr].Y] + 1000000 == this.front.FrontID && this.ai.VAR_MATRIX_ZONES.Value[this.GetRealX(index2), tdata1 + this.Top] + 1000000 != this.front.FrontID)
            a -= (float) (600 + (int) Math.Round((double) Math.Abs(this.Score) * 0.3));
        }
        if (unr > -1 & index2 <= this.Width & tdata1 <= this.Height & this.front.units.counter > -1)
        {
          if (Operators.CompareString(Strings.LCase(this.ai.game.Data.UnitObj[unr].Name), Strings.LCase("14th pz div"), false) == 0)
            index2 = index2;
          int matrixX = this.GetMatrixX(this.ai.game.Data.UnitObj[unr].X);
          int index40 = this.ai.game.Data.UnitObj[unr].Y - this.Top;
          int num54 = this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(matrixX), index40 + this.Top];
          int num55 = this.ai.VAR_MATRIX_RETREAT.Value[this.GetRealX(index2), tdata1 + this.Top];
          if (tSupply1.Value[matrixX, index40] > this.ai.VAR_SUPPLY_MAXIMUM_RANGE & this.FriendlySupply.Value[matrixX, index40] > this.ai.VAR_SUPPLY_MAXIMUM_RANGE && tSupply1.Value[index2, tdata1] < this.ai.VAR_SUPPLY_25PERCENT_RANGE)
          {
            str6: String = str3;
            num49 = 350 + (int) Math.Round(Math.Abs((double) a * 0.5) / (double) this.front.units.counter);
            str7: String = num49.ToString();
            str3 = str6 + "*MoveIntoSup: +" + str7;
            a += (float) (50 + (int) Math.Round(Math.Abs((double) a * 0.5) / (double) this.front.units.counter));
          }
          if (tSupply1.Value[index2, tdata1] > this.ai.VAR_SUPPLY_MAXIMUM_RANGE & tOwner.Value[index2, tdata1] == 1 && tSupply1.Value[matrixX, index40] < this.ai.VAR_SUPPLY_25PERCENT_RANGE)
          {
            if (this.ai.GetRegime(this.ai.map.HexObj[this.GetRealX(index2), tdata1 + this.Top].Regime) != this.ai.GetGameDataTurn() & this.front.Stance == 3)
            {
              str8: String = str3;
              num49 = 225 + (int) Math.Round(Math.Abs((double) a * 0.5) / Math.Sqrt(Math.Sqrt((double) (this.front.units.counter + 1))));
              str9: String = num49.ToString();
              str3 = str8 + "*MoveOutOfSup: -" + str9;
              a -= (float) (25 + (int) Math.Round(Math.Abs((double) a * 0.5) / Math.Sqrt(Math.Sqrt((double) (this.front.units.counter + 1)))));
            }
            else if (this.front.Stance == 3)
            {
              str10: String = str3;
              num49 = 225 + (int) Math.Round(Math.Abs((double) a * 0.5) / Math.Sqrt(Math.Sqrt((double) (this.front.units.counter + 1))));
              str11: String = num49.ToString();
              str3 = str10 + "*MoveOutOfSup: -" + str11;
              a -= (float) (25 + (int) Math.Round(Math.Abs((double) a * 0.5) / Math.Sqrt(Math.Sqrt((double) (this.front.units.counter + 1)))));
            }
            else
            {
              str12: String = str3;
              num49 = 250 + (int) Math.Round(Math.Abs((double) a * 0.5) / Math.Sqrt(Math.Sqrt((double) (this.front.units.counter + 1))));
              str13: String = num49.ToString();
              str3 = str12 + "*MoveOutOfSup: -" + str13;
              a -= (float) (50 + (int) Math.Round(Math.Abs((double) a * 0.5) / Math.Sqrt(Math.Sqrt((double) (this.front.units.counter + 1)))));
            }
          }
          if (this.friendlySupplyIdeal.Value[index2, tdata1] >= 999 & tOwner.Value[index2, tdata1] == 1)
          {
            str14: String = str3;
            num49 = 50 + (int) Math.Round((double) (Math.Abs(a) / (float) this.front.units.counter));
            str15: String = num49.ToString();
            str3 = str14 + "*MoveOutOfIDEALSup: -" + str15;
            a -= (float) (50 + (int) Math.Round((double) (Math.Abs(a) / (float) this.front.units.counter)));
          }
        }
      }
      if (num5 > num4)
      {
        str16: String = str3;
        num49 = num5 - num4;
        str17: String = num49.ToString();
        str3 = str16 + "*More VP: +" + str17;
        a += (float) (50 * (num5 - num4));
      }
      if (num5 < num4)
      {
        str18: String = str3;
        num49 = num4 - num5;
        str19: String = num49.ToString();
        str3 = str18 + "*Less VP: +" + str19;
        a -= (float) (50 * (num4 - num5));
      }
      this.Score += (int) Math.Round((double) a);
      if ((double) this.initEncRatio1 - (double) this.finalEncRatio1 < 0.0)
      {
        if ((double) this.initEncRatio1 - (double) this.finalEncRatio1 < -0.3)
          this.Score -= 6000;
        else if ((double) this.initEncRatio1 - (double) this.finalEncRatio1 < -0.2)
          this.Score -= 4000;
        else if ((double) this.initEncRatio1 - (double) this.finalEncRatio1 < -0.1)
          this.Score -= 2000;
        else
          this.Score -= 1000;
      }
      if (!this.ai.VAR_DEBUG_ON)
        str3 = "x";
      if (this.ai.VAR_DEBUG_ON & this.MoveList.Counter > -1)
      {
        str3 += "..... UNITS: ";
        int counter18 = this.MoveList.Counter;
        for (int index41 = 0; index41 <= counter18; index41 += 1)
        {
          if (this.MoveList.Move[index41].MoveTo.onmap)
          {
            this.GetMatrixX(this.MoveList.Move[index41].MoveTo.x);
            int num56 = this.MoveList.Move[index41].MoveTo.y - this.Top;
            int unitByAiid = this.ai.game.HandyFunctionsObj.GetUnitByAIid(this.MoveList.Move[index41].UnitAIid);
            str3 = str3 + this.ai.game.Data.UnitObj[unitByAiid].Name + ",";
          }
        }
      }
      if (this.Score == 1)
        this.Score = this.Score;
      if (this.MoveList.Counter > 0 && this.MoveList.Move[0].MoveTo.x == 39 & this.MoveList.Move[0].MoveTo.y == 32)
        this.Score = this.Score;
      return str3;
    }
  }
}
