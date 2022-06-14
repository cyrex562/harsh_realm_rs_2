// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.RegimeClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsApplication1
{
  [Serializable]
  pub class RegimeClass : ISerializable
  {
    pub Name: String;
    pub id: i32;
    pub Red: i32;
    pub Green: i32;
    pub Blue: i32;
    pub Red2: i32;
    pub Green2: i32;
    pub Blue2: i32;
    pub Red3: i32;
    pub Green3: i32;
    pub Blue3: i32;
    pub Red4: i32;
    pub Green4: i32;
    pub Blue4: i32;
    pub People: i32;
    pub int[] RegimeSlot;
    pub int[] LastTempRegimeSlotPredict;
    pub int[] TempRegimeSlotPredict;
    pub int[] TempRegimeSlotIncrease;
    pub TempPPIncrease: i32;
    pub HQSpriteOverrule: bool;
    pub BaseMorale: i32;
    pub ResPts: i32;
    pub ResFieldCounter: i32;
    pub bool[] ResField;
    pub RegimeCounter: i32;
    pub int[] RegimeRel;
    pub int[] RegimeOffer;
    pub MapCount: i32;
    pub MapMatrix2[] HistoryOwner;
    pub MapMatrix2[] HistoryForce;
    pub MapMatrix2[] HistorySFType;
    pub MapMatrix2[] HistoryHis;
    pub MapMatrix2[] HistoryDepth;
    pub MapMatrix2[] Trafic;
    pub MapMatrix2[] Trafic2;
    pub MapMatrix2[] AIVP;
    pub MapMatrix2[] AIPower;
    pub MapMatrix2[] AIDefense;
    pub AIStance: i32;
    pub MapMatrix2[] OldAINarrow;
    pub AIHelpMove: i32;
    pub AIHelpCombat: i32;
    pub AIHelpStrategic: i32;
    pub HistoryStepClass[] HistoryStep;
    pub HistoryStepCounter: i32;
    pub MessCounter: i32;
    pub string[] MessString;
    pub int[] MessBackPic;
    pub int[] MessFrontPic;
    pub string[] MessWav;
    pub int[] MesStyle;
    pub string[] MesNote;
    pub string[] MesNote2;
    pub string[] MesName;
    pub int[] MesGroup;
    pub bool[] MesHideFromStart;
    pub bool[] MesHideFromTab;
    pub int[] MesChosen;
    pub AI: bool;
    pub AIid: i32;
    pub Sleep: bool;
    pub PassWord: String;
    pub UnitName: String;
    pub UnitNumber: i32;
    pub HQName: String;
    pub HQNumber: i32;
    pub int[,] SLoss;
    pub int[,] SKills;
    pub int[,] SProd;
    pub int[,] SPresent;
    pub int[,,] LisPoints;
    pub Bitmap HexBack;
    pub PlanCounter: i32;
    pub AIPlanClass[] PlanObj;
    pub Bitmap TempCounter;
    pub Bitmap TempCounterHigh;
    pub Bitmap TempCounterBig;
    pub Bitmap TempCounterBigHigh;
    pub Bitmap TempCountersmall;
    pub Bitmap TempCountersmallHigh;
    pub Bitmap TempRegimeColor;
    pub Bitmap TempRegimeColorSmall;
    pub Bitmap TempRegimeColorBig;
    pub DipBlock: bool;
    pub SASSupplyLost: i32;
    pub SASSupplyKilled: i32;
    pub int[] SASProdLost;
    pub int[] SASKilled;
    pub AISavedPP: i32;
    pub float AIConservative;
    pub ProdBonus: i32;
    pub ActionCardCounter: i32;
    pub int[] ActionCard;
    pub ActionCardHistoryCounter: i32;
    pub int[] ActionCardHistory;
    pub int[] ActionCardHistoryRound;
    pub int[,] ExtraStat;
    pub NationalIconSpriteName: String;
    pub NationalIconSprite: i32;
    pub RoundelSpriteName: String;
    pub RoundelIconSprite: i32;
    pub RoundelSpriteName2: String;
    pub RoundelIconSprite2: i32;
    pub HQSpriteFileName: String;
    pub HQSpriteNr: i32;
    pub HQSpriteFileName2: String;
    pub HQSpriteNr2: i32;
    pub BannerSpriteFileName: String;
    pub BannerSpriteNr: i32;
    pub BannerSpriteFileName2: String;
    pub BannerSpriteNr2: i32;
    pub SymbolSpriteName: String;
    pub SymbolSpriteNr: i32;
    pub ExtraGraphicUse: i32;
    pub FirstRound: i32;
    pub LoadTransferUnit: bool;
    pub LoadTransferHistorical: bool;
    pub LoadAreaSlot: i32;
    pub LoadPerHex: i32;
    pub LoadResearchTransfer: bool;
    pub RandomCode: i32;
    pub LastVersion: i32;
    pub OfficerPool: i32;
    pub AIGroupCounter: i32;
    pub string[] AIGroupName;
    pub int[] AIGroupType;
    pub int[] AIGroupHis;
    pub int[] AIGroupLastAttack;
    pub int[] AIGroupLastDefend;
    pub int[] AIGroupLastFollowUp;
    pub int[] AIGroupLastFallBack;
    pub int[] AICorpsTopGroup;
    pub UberRegime: i32;
    pub Mirror: bool;
    pub Version: i32;
    pub subVersion: String;
    pub PbemPlayer: i32;
    pub UseAlternateActionCardPics: bool;
    pub FerryEffectivity: i32;
    pub hideFromList: bool;
    pub LibIdClass libId;
    pub TempSelectable: bool;
    pub minimumDataUsage: bool;

    pub virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Name", (object) this.Name);
      info.AddValue("Red", this.Red);
      info.AddValue("Green", this.Green);
      info.AddValue("Blue", this.Blue);
      info.AddValue("Red2", this.Red2);
      info.AddValue("Green2", this.Green2);
      info.AddValue("Blue2", this.Blue2);
      info.AddValue("Red3", this.Red3);
      info.AddValue("Green3", this.Green3);
      info.AddValue("Blue3", this.Blue3);
      info.AddValue("Red4", this.Red4);
      info.AddValue("Green4", this.Green4);
      info.AddValue("Blue4", this.Blue4);
      info.AddValue("People", this.People);
      info.AddValue("RegimeSlot", (object) this.RegimeSlot);
      info.AddValue("HQSpriteFileName", (object) this.HQSpriteFileName);
      info.AddValue("HQSpriteFileName2", (object) this.HQSpriteFileName2);
      info.AddValue("BaseMorale", this.BaseMorale);
      info.AddValue("ResPts", this.ResPts);
      info.AddValue("ResFieldCounter", this.ResFieldCounter);
      info.AddValue("ResField", (object) this.ResField);
      info.AddValue("RegimeCounter", this.RegimeCounter);
      info.AddValue("RegimeRel", (object) this.RegimeRel);
      info.AddValue("RegimeOffer", (object) this.RegimeOffer);
      info.AddValue("MapCount", this.MapCount);
      info.AddValue("HistoryOwner", (object) this.HistoryOwner);
      info.AddValue("HistorySFType", (object) this.HistorySFType);
      info.AddValue("HistoryForce", (object) this.HistoryForce);
      info.AddValue("HistoryHis", (object) this.HistoryHis);
      info.AddValue("HistoryDepth", (object) this.HistoryDepth);
      info.AddValue("HistoryStep", (object) this.HistoryStep);
      info.AddValue("HistoryStepCounter", this.HistoryStepCounter);
      info.AddValue("MessCounter", this.MessCounter);
      info.AddValue("MessString", (object) this.MessString);
      info.AddValue("MessBackPic", (object) this.MessBackPic);
      info.AddValue("MessFrontPic", (object) this.MessFrontPic);
      info.AddValue("MessWav", (object) this.MessWav);
      info.AddValue("MesStyle", (object) this.MesStyle);
      info.AddValue("MesNote", (object) this.MesNote);
      info.AddValue("MesNote2", (object) this.MesNote2);
      info.AddValue("MesName", (object) this.MesName);
      info.AddValue("MesGroup", (object) this.MesGroup);
      info.AddValue("MesChosen", (object) this.MesChosen);
      info.AddValue("MesHideFromStart", (object) this.MesHideFromStart);
      info.AddValue("MesHideFromTab", (object) this.MesHideFromTab);
      info.AddValue("AI", this.AI);
      info.AddValue("AIid", this.AIid);
      info.AddValue("Sleep", this.Sleep);
      info.AddValue("PassWord", (object) this.PassWord);
      info.AddValue("UnitName", (object) this.UnitName);
      info.AddValue("UnitNumber", this.UnitNumber);
      info.AddValue("HQName", (object) this.HQName);
      info.AddValue("HQNumber", this.HQNumber);
      info.AddValue("SLoss", (object) this.SLoss);
      info.AddValue("SKills", (object) this.SKills);
      info.AddValue("SProd", (object) this.SProd);
      info.AddValue("SPresent", (object) this.SPresent);
      info.AddValue("DipBlock", this.DipBlock);
      info.AddValue("SASSupplyLost", this.SASSupplyLost);
      info.AddValue("SASSupplyKilled", this.SASSupplyKilled);
      info.AddValue("SASProdLost", (object) this.SASProdLost);
      info.AddValue("SASKilled", (object) this.SASKilled);
      info.AddValue("HQSpriteOverrule", this.HQSpriteOverrule);
      info.AddValue("PlanCounter", this.PlanCounter);
      info.AddValue("PlanObj", (object) this.PlanObj);
      info.AddValue("ProdBonus", this.ProdBonus);
      info.AddValue("AIVP", (object) this.AIVP);
      info.AddValue("Trafic", (object) this.Trafic);
      info.AddValue("Trafic2", (object) this.Trafic2);
      info.AddValue("AIPower", (object) this.AIPower);
      info.AddValue("AIDefense", (object) this.AIDefense);
      info.AddValue("ActionCardCounter", this.ActionCardCounter);
      info.AddValue("ActionCard", (object) this.ActionCard);
      info.AddValue("ActionCardHistoryCounter", this.ActionCardHistoryCounter);
      info.AddValue("ActionCardHistory", (object) this.ActionCardHistory);
      info.AddValue("ActionCardHistoryRound", (object) this.ActionCardHistoryRound);
      info.AddValue("AIConservative", this.AIConservative);
      info.AddValue("ExtraStat", (object) this.ExtraStat);
      info.AddValue("NationalIconSpriteName", (object) this.NationalIconSpriteName);
      info.AddValue("RoundelSpriteName", (object) this.RoundelSpriteName);
      info.AddValue("RoundelSpriteName2", (object) this.RoundelSpriteName2);
      info.AddValue("BannerSpriteFileName", (object) this.BannerSpriteFileName);
      info.AddValue("BannerSpriteFileName2", (object) this.BannerSpriteFileName2);
      info.AddValue("SymbolSpriteName", (object) this.SymbolSpriteName);
      info.AddValue("ExtraGraphicUse", this.ExtraGraphicUse);
      info.AddValue("FirstRound", this.FirstRound);
      info.AddValue("RandomCode", this.RandomCode);
      info.AddValue("AIGroupCounter", this.AIGroupCounter);
      info.AddValue("AIGroupHis", (object) this.AIGroupHis);
      info.AddValue("AIGroupType", (object) this.AIGroupType);
      info.AddValue("AIGroupLastAttack", (object) this.AIGroupLastAttack);
      info.AddValue("AIGroupLastDefend", (object) this.AIGroupLastDefend);
      info.AddValue("AIGroupLastFollowUp", (object) this.AIGroupLastFollowUp);
      info.AddValue("AIGroupLastFallBack", (object) this.AIGroupLastFallBack);
      info.AddValue("AICorpsTopGroup", (object) this.AICorpsTopGroup);
      info.AddValue("AIGroupName", (object) this.AIGroupName);
      info.AddValue("OfficerPool", this.OfficerPool);
      info.AddValue("UberRegime", this.UberRegime);
      info.AddValue("Mirror", this.Mirror);
      info.AddValue("Version", this.Version);
      info.AddValue("subVersion", (object) this.subVersion);
      info.AddValue("LoadTransferHistorical", this.LoadTransferHistorical);
      info.AddValue("OldAINarrow", (object) this.OldAINarrow);
      info.AddValue("AIHelpMove", this.AIHelpMove);
      info.AddValue("AIHelpCombat", this.AIHelpCombat);
      info.AddValue("AIHelpStrategic", this.AIHelpStrategic);
      info.AddValue("PBEMPlayer", this.PbemPlayer);
      info.AddValue("UseAlternateActionCardPics", this.UseAlternateActionCardPics);
      info.AddValue("FerryEffectivity", this.FerryEffectivity);
      info.AddValue("LibId", (object) this.libId);
      info.AddValue("Id", this.id);
      info.AddValue("hideFromList", this.hideFromList);
      info.AddValue("minimumDataUsage", this.minimumDataUsage);
    }

    pub void AddPlan()
    {
      this += 1.PlanCounter;
      this.PlanObj = (AIPlanClass[]) Utils.CopyArray((Array) this.PlanObj, (Array) new AIPlanClass[this.PlanCounter + 1]);
      this.PlanObj[this.PlanCounter] = AIPlanClass::new();
    }

    pub void RemovePlan(int nr)
    {
      if (nr < this.PlanCounter)
      {
        let mut num1: i32 = nr;
        let mut num2: i32 = this.PlanCounter - 1;
        for (let mut index: i32 = num1; index <= num2; index += 1)
          this.PlanObj[index] = this.PlanObj[index + 1];
      }
      --this.PlanCounter;
      this.PlanObj = (AIPlanClass[]) Utils.CopyArray((Array) this.PlanObj, (Array) new AIPlanClass[this.PlanCounter + 1]);
    }

    protected RegimeClass(SerializationInfo info, StreamingContext context)
    {
      this.RegimeSlot = new int[500];
      this.LastTempRegimeSlotPredict = new int[500];
      this.TempRegimeSlotPredict = new int[500];
      this.TempRegimeSlotIncrease = new int[500];
      this.ResField = new bool[1];
      this.RegimeRel = new int[1];
      this.RegimeOffer = new int[1];
      this.HistoryOwner = new MapMatrix2[1];
      this.HistoryForce = new MapMatrix2[1];
      this.HistorySFType = new MapMatrix2[1];
      this.HistoryHis = new MapMatrix2[1];
      this.HistoryDepth = new MapMatrix2[1];
      this.Trafic = new MapMatrix2[1];
      this.Trafic2 = new MapMatrix2[1];
      this.AIVP = new MapMatrix2[1];
      this.AIPower = new MapMatrix2[1];
      this.AIDefense = new MapMatrix2[1];
      this.OldAINarrow = new MapMatrix2[1];
      this.HistoryStep = new HistoryStepClass[1];
      this.MessString = new string[1];
      this.MessBackPic = new int[1];
      this.MessFrontPic = new int[1];
      this.MessWav = new string[1];
      this.MesStyle = new int[1];
      this.MesNote = new string[1];
      this.MesNote2 = new string[1];
      this.MesName = new string[1];
      this.MesGroup = new int[1];
      this.MesHideFromStart = new bool[1];
      this.MesHideFromTab = new bool[1];
      this.MesChosen = new int[1];
      this.SLoss = new int[1, 1];
      this.SKills = new int[1, 1];
      this.SProd = new int[1, 1];
      this.SPresent = new int[1, 1];
      this.LisPoints = new int[1, 1, 7];
      this.PlanObj = new AIPlanClass[1];
      this.SASProdLost = new int[1];
      this.SASKilled = new int[1];
      this.ActionCard = new int[1];
      this.ActionCardHistory = new int[1];
      this.ActionCardHistoryRound = new int[1];
      this.ExtraStat = new int[3, 1];
      this.AIGroupName = new string[1];
      this.AIGroupType = new int[1];
      this.AIGroupHis = new int[1];
      this.AIGroupLastAttack = new int[1];
      this.AIGroupLastDefend = new int[1];
      this.AIGroupLastFollowUp = new int[1];
      this.AIGroupLastFallBack = new int[1];
      this.AICorpsTopGroup = new int[1];
      this.Name = info.GetString(nameof (Name));
      this.Red = info.GetInt32(nameof (Red));
      this.Green = info.GetInt32(nameof (Green));
      this.Blue = info.GetInt32(nameof (Blue));
      this.Red2 = info.GetInt32(nameof (Red2));
      this.Green2 = info.GetInt32(nameof (Green2));
      this.Blue2 = info.GetInt32(nameof (Blue2));
      try
      {
        this.Red3 = info.GetInt32(nameof (Red3));
        this.Green3 = info.GetInt32(nameof (Green3));
        this.Blue3 = info.GetInt32(nameof (Blue3));
        this.Red4 = info.GetInt32(nameof (Red4));
        this.Green4 = info.GetInt32(nameof (Green4));
        this.Blue4 = info.GetInt32(nameof (Blue4));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      this.People = info.GetInt32(nameof (People));
      this.RegimeSlot = (int[]) info.GetValue(nameof (RegimeSlot), this.RegimeSlot.GetType());
      this.HQSpriteFileName = info.GetString(nameof (HQSpriteFileName));
      try
      {
        this.HQSpriteFileName2 = info.GetString(nameof (HQSpriteFileName2));
        this.BannerSpriteFileName = info.GetString(nameof (BannerSpriteFileName));
        this.BannerSpriteFileName2 = info.GetString(nameof (BannerSpriteFileName2));
        this.SymbolSpriteName = info.GetString(nameof (SymbolSpriteName));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.HQSpriteFileName2 = "systemgraphics/trans.bmp";
        this.BannerSpriteFileName = "systemgraphics/trans.bmp";
        this.BannerSpriteFileName2 = "systemgraphics/trans.bmp";
        this.SymbolSpriteName = "systemgraphics/trans.bmp";
        ProjectData.ClearProjectError();
      }
      this.BaseMorale = info.GetInt32(nameof (BaseMorale));
      this.ResPts = info.GetInt32(nameof (ResPts));
      this.ResFieldCounter = info.GetInt32(nameof (ResFieldCounter));
      this.ResField = this.ResFieldCounter <= -1 ? new bool[1] : new bool[this.ResFieldCounter + 1];
      this.ResField = (bool[]) info.GetValue(nameof (ResField), this.ResField.GetType());
      this.RegimeCounter = info.GetInt32(nameof (RegimeCounter));
      if (this.RegimeCounter > -1)
      {
        this.RegimeRel = new int[this.RegimeCounter + 1];
        this.RegimeOffer = new int[this.RegimeCounter + 1];
      }
      else
      {
        this.RegimeRel = new int[1];
        this.RegimeOffer = new int[1];
      }
      this.RegimeRel = (int[]) info.GetValue(nameof (RegimeRel), this.RegimeRel.GetType());
      try
      {
        this.RegimeOffer = (int[]) info.GetValue(nameof (RegimeOffer), this.RegimeOffer.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      this.AI = info.GetBoolean(nameof (AI));
      this.Sleep = info.GetBoolean(nameof (Sleep));
      this.HistoryStepCounter = info.GetInt32(nameof (HistoryStepCounter));
      this.HistoryStep = this.HistoryStepCounter <= -1 ? new HistoryStepClass[1] : new HistoryStepClass[this.HistoryStepCounter + 1];
      this.HistoryStep = (HistoryStepClass[]) info.GetValue(nameof (HistoryStep), this.HistoryStep.GetType());
      try
      {
        this.UberRegime = info.GetInt32(nameof (UberRegime));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.UberRegime = -1;
        ProjectData.ClearProjectError();
      }
      let mut mapWidth: i32 = DrawMod.TGame.Data.MapWidth;
      let mut mapHeight: i32 = DrawMod.TGame.Data.MapHeight;
      int[,] numArray1 = new int[mapWidth + 1, mapHeight + 1];
      try
      {
        this.MapCount = info.GetInt32(nameof (MapCount));
        this.HistoryOwner = new MapMatrix2[this.MapCount + 1];
        this.HistoryForce = new MapMatrix2[this.MapCount + 1];
        this.HistorySFType = new MapMatrix2[this.MapCount + 1];
        this.HistoryHis = new MapMatrix2[this.MapCount + 1];
        this.HistoryDepth = new MapMatrix2[this.MapCount + 1];
        this.AIVP = new MapMatrix2[this.MapCount + 1];
        this.AIPower = new MapMatrix2[this.MapCount + 1];
        this.AIDefense = new MapMatrix2[this.MapCount + 1];
        this.HistoryOwner = (MapMatrix2[]) info.GetValue(nameof (HistoryOwner), this.HistoryOwner.GetType());
        this.HistoryForce = (MapMatrix2[]) info.GetValue(nameof (HistoryForce), this.HistoryForce.GetType());
        this.HistorySFType = (MapMatrix2[]) info.GetValue(nameof (HistorySFType), this.HistorySFType.GetType());
        this.HistoryHis = (MapMatrix2[]) info.GetValue(nameof (HistoryHis), this.HistoryHis.GetType());
        this.HistoryDepth = (MapMatrix2[]) info.GetValue(nameof (HistoryDepth), this.HistoryDepth.GetType());
        this.AIVP = (MapMatrix2[]) info.GetValue(nameof (AIVP), this.AIVP.GetType());
        this.AIPower = (MapMatrix2[]) info.GetValue(nameof (AIPower), this.AIPower.GetType());
        try
        {
          this.AIDefense = (MapMatrix2[]) info.GetValue(nameof (AIDefense), this.AIPower.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
        this.Trafic = new MapMatrix2[this.MapCount + 1];
        try
        {
          this.Trafic = (MapMatrix2[]) info.GetValue(nameof (Trafic), this.Trafic.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.Trafic[0] = new MapMatrix2(mapWidth, mapHeight);
          ProjectData.ClearProjectError();
        }
        this.Trafic2 = new MapMatrix2[this.MapCount + 1];
        try
        {
          this.Trafic2 = (MapMatrix2[]) info.GetValue(nameof (Trafic2), this.Trafic2.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.Trafic2[0] = new MapMatrix2(mapWidth, mapHeight);
          ProjectData.ClearProjectError();
        }
      }
      catch (Exception ex1)
      {
        ProjectData.SetProjectError(ex1);
        this.MapCount = 0;
        this.HistoryOwner = new MapMatrix2[1];
        this.HistoryForce = new MapMatrix2[1];
        this.HistorySFType = new MapMatrix2[1];
        this.HistoryHis = new MapMatrix2[1];
        this.HistoryDepth = new MapMatrix2[1];
        this.AIVP = new MapMatrix2[1];
        this.AIPower = new MapMatrix2[1];
        this.AIDefense = new MapMatrix2[1];
        if (mapWidth > -1 & mapHeight > -1)
        {
          int[,] numArray2 = new int[mapWidth + 1, mapHeight + 1];
          int[,] numArray3 = (int[,]) info.GetValue(nameof (HistoryOwner), numArray2.GetType());
          this.HistoryOwner[0] = new MapMatrix2(mapWidth, mapHeight);
          this.HistoryOwner[0].Value = numArray3;
          int[,] numArray4 = new int[mapWidth + 1, mapHeight + 1];
          int[,] numArray5 = (int[,]) info.GetValue(nameof (HistoryForce), numArray4.GetType());
          this.HistoryForce[0] = new MapMatrix2(mapWidth, mapHeight);
          this.HistoryForce[0].Value = numArray5;
          int[,] numArray6 = new int[mapWidth + 1, mapHeight + 1];
          int[,] numArray7 = (int[,]) info.GetValue(nameof (HistorySFType), numArray6.GetType());
          this.HistorySFType[0] = new MapMatrix2(mapWidth, mapHeight);
          this.HistorySFType[0].Value = numArray7;
          try
          {
            int[,] numArray8 = new int[mapWidth + 1, mapHeight + 1];
            int[,] numArray9 = (int[,]) info.GetValue(nameof (HistoryHis), numArray8.GetType());
            this.HistoryHis[0] = new MapMatrix2(mapWidth, mapHeight);
            this.HistoryHis[0].Value = numArray9;
            int[,] numArray10 = new int[mapWidth + 1, mapHeight + 1];
            int[,] numArray11 = (int[,]) info.GetValue(nameof (HistoryDepth), numArray10.GetType());
            this.HistoryDepth[0] = new MapMatrix2(mapWidth, mapHeight);
            this.HistoryDepth[0].Value = numArray11;
          }
          catch (Exception ex2)
          {
            ProjectData.SetProjectError(ex2);
            this.HistoryHis = new MapMatrix2[1];
            this.HistoryDepth = new MapMatrix2[1];
            int[,] numArray12 = new int[mapWidth + 1, mapHeight + 1];
            this.HistoryHis[0] = new MapMatrix2(mapWidth, mapHeight);
            this.HistoryHis[0].Value = numArray12;
            this.HistoryDepth[0] = new MapMatrix2(mapWidth, mapHeight);
            this.HistoryDepth[0].Value = numArray12;
            ProjectData.ClearProjectError();
          }
          try
          {
            int[,] numArray13 = new int[mapWidth + 1, mapHeight + 1];
            int[,] numArray14 = (int[,]) info.GetValue(nameof (AIVP), numArray13.GetType());
            this.AIVP[0] = new MapMatrix2(mapWidth, mapHeight);
            this.AIVP[0].Value = numArray14;
          }
          catch (Exception ex3)
          {
            ProjectData.SetProjectError(ex3);
            this.AIVP[0] = new MapMatrix2(mapWidth, mapHeight);
            ProjectData.ClearProjectError();
          }
          try
          {
            int[,] numArray15 = new int[mapWidth + 1, mapHeight + 1];
            int[,] numArray16 = (int[,]) info.GetValue(nameof (Trafic), numArray15.GetType());
            this.Trafic[0] = new MapMatrix2(mapWidth, mapHeight);
            this.Trafic[0].Value = numArray16;
          }
          catch (Exception ex4)
          {
            ProjectData.SetProjectError(ex4);
            this.Trafic[0] = new MapMatrix2(mapWidth, mapHeight);
            ProjectData.ClearProjectError();
          }
          try
          {
            int[,] numArray17 = new int[mapWidth + 1, mapHeight + 1];
            int[,] numArray18 = (int[,]) info.GetValue(nameof (Trafic2), numArray17.GetType());
            this.Trafic2[0] = new MapMatrix2(mapWidth, mapHeight);
            this.Trafic2[0].Value = numArray18;
          }
          catch (Exception ex5)
          {
            ProjectData.SetProjectError(ex5);
            this.Trafic2[0] = new MapMatrix2(mapWidth, mapHeight);
            ProjectData.ClearProjectError();
          }
          try
          {
            int[,] numArray19 = new int[mapWidth + 1, mapHeight + 1];
            int[,] numArray20 = (int[,]) info.GetValue(nameof (AIPower), numArray19.GetType());
            this.AIPower[0] = new MapMatrix2(mapWidth, mapHeight);
            this.AIPower[0].Value = numArray20;
          }
          catch (Exception ex6)
          {
            ProjectData.SetProjectError(ex6);
            this.AIPower[0] = new MapMatrix2(mapWidth, mapHeight);
            ProjectData.ClearProjectError();
          }
          try
          {
            int[,] numArray21 = new int[mapWidth + 1, mapHeight + 1];
            int[,] numArray22 = (int[,]) info.GetValue(nameof (AIDefense), numArray21.GetType());
            this.AIDefense[0] = new MapMatrix2(mapWidth, mapHeight);
            this.AIDefense[0].Value = numArray22;
          }
          catch (Exception ex7)
          {
            ProjectData.SetProjectError(ex7);
            this.AIDefense[0] = new MapMatrix2(mapWidth, mapHeight);
            ProjectData.ClearProjectError();
          }
        }
        ProjectData.ClearProjectError();
      }
      try
      {
        this.LoadTransferHistorical = info.GetBoolean(nameof (LoadTransferHistorical));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.LoadTransferHistorical = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.OfficerPool = info.GetInt32(nameof (OfficerPool));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.OfficerPool = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.OldAINarrow[0] = new MapMatrix2(mapWidth, mapHeight);
        this.OldAINarrow = (MapMatrix2[]) info.GetValue(nameof (OldAINarrow), this.OldAINarrow.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.OldAINarrow[0] = new MapMatrix2(mapWidth, mapHeight);
        ProjectData.ClearProjectError();
      }
      try
      {
        this.Mirror = info.GetBoolean(nameof (Mirror));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Mirror = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.Version = info.GetInt32(nameof (Version));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Version = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.subVersion = info.GetString(nameof (subVersion));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.subVersion = "";
        ProjectData.ClearProjectError();
      }
      this.MessCounter = info.GetInt32(nameof (MessCounter));
      if (this.MessCounter > -1)
      {
        this.MessString = new string[this.MessCounter + 1];
        this.MessBackPic = new int[this.MessCounter + 1];
        this.MessFrontPic = new int[this.MessCounter + 1];
        this.MessWav = new string[this.MessCounter + 1];
        this.MesStyle = new int[this.MessCounter + 1];
        this.MesNote = new string[this.MessCounter + 1];
        this.MesNote2 = new string[this.MessCounter + 1];
        this.MesGroup = new int[this.MessCounter + 1];
        this.MesName = new string[this.MessCounter + 1];
        this.MesChosen = new int[this.MessCounter + 1];
        this.MesHideFromStart = new bool[this.MessCounter + 1];
        this.MesHideFromTab = new bool[this.MessCounter + 1];
      }
      else
      {
        this.MessString = new string[1];
        this.MessBackPic = new int[1];
        this.MessFrontPic = new int[1];
        this.MessWav = new string[1];
        this.MesStyle = new int[1];
        this.MesNote = new string[1];
        this.MesNote2 = new string[1];
        this.MesGroup = new int[1];
        this.MesName = new string[1];
        this.MesChosen = new int[1];
        this.MesHideFromStart = new bool[1];
        this.MesHideFromTab = new bool[1];
      }
      this.MessString = (string[]) info.GetValue(nameof (MessString), this.MessString.GetType());
      this.MessBackPic = (int[]) info.GetValue(nameof (MessBackPic), this.MessBackPic.GetType());
      this.MessFrontPic = (int[]) info.GetValue(nameof (MessFrontPic), this.MessFrontPic.GetType());
      try
      {
        this.MessWav = (string[]) info.GetValue(nameof (MessWav), this.MessWav.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      try
      {
        this.MesStyle = (int[]) info.GetValue(nameof (MesStyle), this.MesStyle.GetType());
        this.MesNote = (string[]) info.GetValue(nameof (MesNote), this.MesNote.GetType());
        this.MesNote2 = (string[]) info.GetValue(nameof (MesNote2), this.MesNote2.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      try
      {
        this.MesName = (string[]) info.GetValue(nameof (MesName), this.MesName.GetType());
        this.MesGroup = (int[]) info.GetValue(nameof (MesGroup), this.MesGroup.GetType());
        this.MesChosen = (int[]) info.GetValue(nameof (MesChosen), this.MesChosen.GetType());
        this.MesHideFromStart = (bool[]) info.GetValue(nameof (MesHideFromStart), this.MesHideFromStart.GetType());
        this.MesHideFromTab = (bool[]) info.GetValue(nameof (MesHideFromTab), this.MesHideFromTab.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      this.AIid = info.GetInt32(nameof (AIid));
      this.PassWord = info.GetString(nameof (PassWord));
      this.UnitName = info.GetString(nameof (UnitName));
      this.UnitNumber = info.GetInt32(nameof (UnitNumber));
      this.HQName = info.GetString(nameof (HQName));
      this.HQNumber = info.GetInt32(nameof (HQNumber));
      this.SLoss = (int[,]) info.GetValue(nameof (SLoss), this.SLoss.GetType());
      this.SKills = (int[,]) info.GetValue(nameof (SKills), this.SKills.GetType());
      this.SProd = (int[,]) info.GetValue(nameof (SProd), this.SProd.GetType());
      try
      {
        this.SPresent = (int[,]) info.GetValue(nameof (SPresent), this.SPresent.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.SPresent = new int[this.SLoss.GetUpperBound(0) + 1, this.SLoss.GetUpperBound(1) + 1];
        ProjectData.ClearProjectError();
      }
      if (this.SProd.GetUpperBound(0) < this.SKills.GetUpperBound(0))
        this.SProd = new int[this.SLoss.GetUpperBound(0) + 1, this.SLoss.GetUpperBound(1) + 1];
      this.DipBlock = info.GetBoolean(nameof (DipBlock));
      this.SASSupplyLost = info.GetInt32(nameof (SASSupplyLost));
      this.SASSupplyKilled = info.GetInt32(nameof (SASSupplyKilled));
      this.SASProdLost = (int[]) info.GetValue(nameof (SASProdLost), this.SASProdLost.GetType());
      this.SASKilled = (int[]) info.GetValue(nameof (SASKilled), this.SASKilled.GetType());
      this.HQSpriteOverrule = info.GetBoolean(nameof (HQSpriteOverrule));
      this.ProdBonus = info.GetInt32(nameof (ProdBonus));
      this.ActionCardCounter = info.GetInt32(nameof (ActionCardCounter));
      this.ActionCardHistoryCounter = info.GetInt32(nameof (ActionCardHistoryCounter));
      if (this.ActionCardCounter > -1)
      {
        this.ActionCard = new int[this.ActionCardCounter + 1];
        this.ActionCard = (int[]) info.GetValue(nameof (ActionCard), this.ActionCard.GetType());
      }
      else
      {
        this.ActionCardCounter = -1;
        this.ActionCard = new int[1];
      }
      if (this.ActionCardHistoryCounter > -1)
      {
        this.ActionCardHistory = new int[this.ActionCardHistoryCounter + 1];
        this.ActionCardHistoryRound = new int[this.ActionCardHistoryCounter + 1];
        this.ActionCardHistory = (int[]) info.GetValue(nameof (ActionCardHistory), this.ActionCardHistory.GetType());
        this.ActionCardHistoryRound = (int[]) info.GetValue(nameof (ActionCardHistoryRound), this.ActionCardHistoryRound.GetType());
      }
      else
      {
        this.ActionCardHistoryCounter = -1;
        this.ActionCardHistory = new int[1];
        this.ActionCardHistoryRound = new int[1];
      }
      this.AISavedPP = 0;
      this.AIConservative = info.GetSingle(nameof (AIConservative));
      if ((double) this.AIConservative <= 0.0)
        this.AIConservative = 1f;
      this.ExtraStat = (int[,]) info.GetValue(nameof (ExtraStat), this.ExtraStat.GetType());
      this.NationalIconSpriteName = info.GetString(nameof (NationalIconSpriteName));
      this.ExtraGraphicUse = info.GetInt32(nameof (ExtraGraphicUse));
      try
      {
        this.FirstRound = info.GetInt32(nameof (FirstRound));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.FirstRound = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.RandomCode = info.GetInt32(nameof (RandomCode));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.RandomCode = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.AIGroupCounter = info.GetInt32(nameof (AIGroupCounter));
        this.AIGroupHis = (int[]) info.GetValue(nameof (AIGroupHis), this.AIGroupHis.GetType());
        this.AIGroupType = (int[]) info.GetValue(nameof (AIGroupType), this.AIGroupType.GetType());
        this.AIGroupName = (string[]) info.GetValue(nameof (AIGroupName), this.AIGroupName.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.AIGroupCounter = -1;
        ProjectData.ClearProjectError();
      }
      if (this.AIGroupCounter > -1)
      {
        try
        {
          this.AIGroupLastAttack = (int[]) info.GetValue(nameof (AIGroupLastAttack), this.AIGroupLastAttack.GetType());
          this.AIGroupLastDefend = (int[]) info.GetValue(nameof (AIGroupLastDefend), this.AIGroupLastDefend.GetType());
          this.AIGroupLastFallBack = (int[]) info.GetValue(nameof (AIGroupLastFallBack), this.AIGroupLastFallBack.GetType());
          this.AIGroupLastFollowUp = (int[]) info.GetValue(nameof (AIGroupLastFollowUp), this.AIGroupLastFollowUp.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.AIGroupLastAttack = new int[this.AIGroupCounter + 1];
          this.AIGroupLastDefend = new int[this.AIGroupCounter + 1];
          this.AIGroupLastFollowUp = new int[this.AIGroupCounter + 1];
          this.AIGroupLastFallBack = new int[this.AIGroupCounter + 1];
          ProjectData.ClearProjectError();
        }
        try
        {
          this.AICorpsTopGroup = (int[]) info.GetValue(nameof (AICorpsTopGroup), this.AICorpsTopGroup.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.AICorpsTopGroup = new int[this.AIGroupCounter + 1];
          ProjectData.ClearProjectError();
        }
      }
      try
      {
        this.AIHelpMove = info.GetInt32(nameof (AIHelpMove));
        this.AIHelpCombat = info.GetInt32(nameof (AIHelpCombat));
        this.AIHelpStrategic = info.GetInt32(nameof (AIHelpStrategic));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.AIHelpMove = 0;
        this.AIHelpCombat = 0;
        this.AIHelpStrategic = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.RoundelSpriteName = info.GetString(nameof (RoundelSpriteName));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.RoundelSpriteName = "systemgraphics/trans.bmp";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.RoundelSpriteName2 = info.GetString(nameof (RoundelSpriteName2));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.RoundelSpriteName2 = "systemgraphics/trans.bmp";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.PbemPlayer = info.GetInt32("PBEMPlayer");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.PbemPlayer = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.UseAlternateActionCardPics = (uint) info.GetInt32(nameof (UseAlternateActionCardPics)) > 0U;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.UseAlternateActionCardPics = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.FerryEffectivity = info.GetInt32(nameof (FerryEffectivity));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.FerryEffectivity = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.libId = LibIdClass::new();
        this.libId = (LibIdClass) info.GetValue("LibId", this.libId.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.libId = LibIdClass::new();
        ProjectData.ClearProjectError();
      }
      try
      {
        this.id = info.GetInt32("Id");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.id = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.hideFromList = info.GetBoolean(nameof (hideFromList));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.hideFromList = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.minimumDataUsage = info.GetBoolean(nameof (minimumDataUsage));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.minimumDataUsage = false;
        ProjectData.ClearProjectError();
      }
      if (!(this.Sleep | this.AI))
        return;
      this.HistoryStepCounter = -1;
      this.HistoryStep = new HistoryStepClass[1];
    }

    pub RegimeClass Clone()
    {
      BinaryFormatter binaryFormatter = BinaryFormatter::new();
      MemoryStream serializationStream = MemoryStream::new();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (RegimeClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    pub RegimeClass(
      int hardcoded,
      int tregimecounter,
      int trescounter,
      DataClass tData,
      bool tminimalDataUsage = false)
    {
      this.RegimeSlot = new int[500];
      this.LastTempRegimeSlotPredict = new int[500];
      this.TempRegimeSlotPredict = new int[500];
      this.TempRegimeSlotIncrease = new int[500];
      this.ResField = new bool[1];
      this.RegimeRel = new int[1];
      this.RegimeOffer = new int[1];
      this.HistoryOwner = new MapMatrix2[1];
      this.HistoryForce = new MapMatrix2[1];
      this.HistorySFType = new MapMatrix2[1];
      this.HistoryHis = new MapMatrix2[1];
      this.HistoryDepth = new MapMatrix2[1];
      this.Trafic = new MapMatrix2[1];
      this.Trafic2 = new MapMatrix2[1];
      this.AIVP = new MapMatrix2[1];
      this.AIPower = new MapMatrix2[1];
      this.AIDefense = new MapMatrix2[1];
      this.OldAINarrow = new MapMatrix2[1];
      this.HistoryStep = new HistoryStepClass[1];
      this.MessString = new string[1];
      this.MessBackPic = new int[1];
      this.MessFrontPic = new int[1];
      this.MessWav = new string[1];
      this.MesStyle = new int[1];
      this.MesNote = new string[1];
      this.MesNote2 = new string[1];
      this.MesName = new string[1];
      this.MesGroup = new int[1];
      this.MesHideFromStart = new bool[1];
      this.MesHideFromTab = new bool[1];
      this.MesChosen = new int[1];
      this.SLoss = new int[1, 1];
      this.SKills = new int[1, 1];
      this.SProd = new int[1, 1];
      this.SPresent = new int[1, 1];
      this.LisPoints = new int[1, 1, 7];
      this.PlanObj = new AIPlanClass[1];
      this.SASProdLost = new int[1];
      this.SASKilled = new int[1];
      this.ActionCard = new int[1];
      this.ActionCardHistory = new int[1];
      this.ActionCardHistoryRound = new int[1];
      this.ExtraStat = new int[3, 1];
      this.AIGroupName = new string[1];
      this.AIGroupType = new int[1];
      this.AIGroupHis = new int[1];
      this.AIGroupLastAttack = new int[1];
      this.AIGroupLastDefend = new int[1];
      this.AIGroupLastFollowUp = new int[1];
      this.AIGroupLastFallBack = new int[1];
      this.AICorpsTopGroup = new int[1];
      this.RoundelSpriteName = "systemgraphics/trans.bmp";
      this.RoundelSpriteName2 = "systemgraphics/trans.bmp";
      this.UberRegime = -1;
      this.Name = "Default Regime";
      this.Red =  byte.MaxValue;
      this.Green = 128;
      this.Blue = 0;
      this.subVersion = "";
      this.Red2 =  byte.MaxValue;
      this.Green2 =  byte.MaxValue;
      this.Blue2 =  byte.MaxValue;
      this.HQSpriteFileName = "systemgraphics/trans.bmp";
      this.HQSpriteFileName2 = "systemgraphics/trans.bmp";
      this.BannerSpriteFileName = "systemgraphics/trans.bmp";
      this.BannerSpriteFileName2 = "systemgraphics/trans.bmp";
      this.SymbolSpriteName = "systemgraphics/trans.bmp";
      let mut index1: i32 = 0;
      do
      {
        this.RegimeSlot[index1] = -1;
        index1 += 1;
      }
      while (index1 <= 499);
      this.BaseMorale = 100;
      this.RegimeCounter = tregimecounter;
      this.RegimeRel = new int[this.RegimeCounter + 1];
      this.RegimeOffer = new int[this.RegimeCounter + 1];
      let mut regimeCounter: i32 = this.RegimeCounter;
      for (let mut index2: i32 = 0; index2 <= regimeCounter; index2 += 1)
        this.RegimeRel[index2] = 1;
      this.ResFieldCounter = trescounter;
      this.ResField = new bool[this.ResFieldCounter + 1];
      let mut resFieldCounter: i32 = this.ResFieldCounter;
      for (let mut index3: i32 = 0; index3 <= resFieldCounter; index3 += 1)
        this.ResField[index3] = false;
      this.HistoryStepCounter = -1;
      this.MapCount = tData.MapCounter;
      this.HistoryOwner = new MapMatrix2[this.MapCount + 1];
      this.HistoryForce = new MapMatrix2[this.MapCount + 1];
      this.HistorySFType = new MapMatrix2[this.MapCount + 1];
      this.HistoryHis = new MapMatrix2[this.MapCount + 1];
      this.HistoryDepth = new MapMatrix2[this.MapCount + 1];
      this.AIVP = new MapMatrix2[this.MapCount + 1];
      this.Trafic = new MapMatrix2[this.MapCount + 1];
      this.Trafic2 = new MapMatrix2[this.MapCount + 1];
      this.AIPower = new MapMatrix2[this.MapCount + 1];
      this.AIDefense = new MapMatrix2[this.MapCount + 1];
      this.minimumDataUsage = tminimalDataUsage;
      if (!this.minimumDataUsage)
      {
        let mut mapCount: i32 = this.MapCount;
        for (let mut index4: i32 = 0; index4 <= mapCount; index4 += 1)
        {
          this.HistoryOwner[index4] = new MapMatrix2(tData.MapObj[index4].MapWidth, tData.MapObj[index4].MapHeight);
          this.HistoryForce[index4] = new MapMatrix2(tData.MapObj[index4].MapWidth, tData.MapObj[index4].MapHeight);
          this.HistorySFType[index4] = new MapMatrix2(tData.MapObj[index4].MapWidth, tData.MapObj[index4].MapHeight);
          this.HistoryHis[index4] = new MapMatrix2(tData.MapObj[index4].MapWidth, tData.MapObj[index4].MapHeight);
          this.HistoryDepth[index4] = new MapMatrix2(tData.MapObj[index4].MapWidth, tData.MapObj[index4].MapHeight);
          this.AIVP[index4] = new MapMatrix2(tData.MapObj[index4].MapWidth, tData.MapObj[index4].MapHeight);
          this.Trafic[index4] = new MapMatrix2(tData.MapObj[index4].MapWidth, tData.MapObj[index4].MapHeight);
          this.Trafic2[index4] = new MapMatrix2(tData.MapObj[index4].MapWidth, tData.MapObj[index4].MapHeight);
          this.AIPower[index4] = new MapMatrix2(tData.MapObj[index4].MapWidth, tData.MapObj[index4].MapHeight);
          this.AIDefense[index4] = new MapMatrix2(tData.MapObj[index4].MapWidth, tData.MapObj[index4].MapHeight);
        }
      }
      this.Sleep = false;
      this.ActionCardCounter = -1;
      this.ActionCardHistoryCounter = -1;
      this.AIConservative = 1f;
      this.NationalIconSpriteName = "systemgraphics/trans.bmp";
      this.ExtraGraphicUse = -1;
      this.OfficerPool = -1;
      this.libId = LibIdClass::new();
    }

    pub void AddMap(int w, int h)
    {
      this += 1.MapCount;
      this.HistoryOwner = (MapMatrix2[]) Utils.CopyArray((Array) this.HistoryOwner, (Array) new MapMatrix2[this.MapCount + 1]);
      this.HistoryForce = (MapMatrix2[]) Utils.CopyArray((Array) this.HistoryForce, (Array) new MapMatrix2[this.MapCount + 1]);
      this.HistorySFType = (MapMatrix2[]) Utils.CopyArray((Array) this.HistorySFType, (Array) new MapMatrix2[this.MapCount + 1]);
      this.HistoryHis = (MapMatrix2[]) Utils.CopyArray((Array) this.HistoryHis, (Array) new MapMatrix2[this.MapCount + 1]);
      this.HistoryDepth = (MapMatrix2[]) Utils.CopyArray((Array) this.HistoryDepth, (Array) new MapMatrix2[this.MapCount + 1]);
      this.AIVP = (MapMatrix2[]) Utils.CopyArray((Array) this.AIVP, (Array) new MapMatrix2[this.MapCount + 1]);
      this.Trafic = (MapMatrix2[]) Utils.CopyArray((Array) this.Trafic, (Array) new MapMatrix2[this.MapCount + 1]);
      this.Trafic2 = (MapMatrix2[]) Utils.CopyArray((Array) this.Trafic2, (Array) new MapMatrix2[this.MapCount + 1]);
      this.AIPower = (MapMatrix2[]) Utils.CopyArray((Array) this.AIPower, (Array) new MapMatrix2[this.MapCount + 1]);
      this.AIDefense = (MapMatrix2[]) Utils.CopyArray((Array) this.AIDefense, (Array) new MapMatrix2[this.MapCount + 1]);
      this.HistoryOwner[this.MapCount] = new MapMatrix2(w, h);
      this.HistoryForce[this.MapCount] = new MapMatrix2(w, h);
      this.HistorySFType[this.MapCount] = new MapMatrix2(w, h);
      this.HistoryHis[this.MapCount] = new MapMatrix2(w, h);
      this.HistoryDepth[this.MapCount] = new MapMatrix2(w, h);
      this.AIVP[this.MapCount] = new MapMatrix2(w, h);
      this.Trafic[this.MapCount] = new MapMatrix2(w, h);
      this.Trafic2[this.MapCount] = new MapMatrix2(w, h);
      this.AIPower[this.MapCount] = new MapMatrix2(w, h);
      this.AIDefense[this.MapCount] = new MapMatrix2(w, h);
    }

    pub void RemoveMap(int nr)
    {
      if (nr < this.MapCount)
      {
        let mut num1: i32 = nr;
        let mut num2: i32 = this.MapCount - 1;
        for (let mut index: i32 = num1; index <= num2; index += 1)
        {
          this.HistoryOwner[index] = this.HistoryOwner[index + 1];
          this.HistoryForce[index] = this.HistoryForce[index + 1];
          this.HistorySFType[index] = this.HistorySFType[index + 1];
          this.HistoryHis[index] = this.HistoryHis[index + 1];
          this.HistoryDepth[index] = this.HistoryDepth[index + 1];
          this.AIVP[index] = this.AIVP[index + 1];
          this.Trafic[index] = this.Trafic[index + 1];
          this.Trafic2[index] = this.Trafic2[index + 1];
          this.AIPower[index] = this.AIPower[index + 1];
          this.AIDefense[index] = this.AIDefense[index + 1];
        }
      }
      --this.MapCount;
      if (this.MapCount <= -1)
        return;
      this.HistoryOwner = (MapMatrix2[]) Utils.CopyArray((Array) this.HistoryOwner, (Array) new MapMatrix2[this.MapCount + 1]);
      this.HistoryForce = (MapMatrix2[]) Utils.CopyArray((Array) this.HistoryForce, (Array) new MapMatrix2[this.MapCount + 1]);
      this.HistorySFType = (MapMatrix2[]) Utils.CopyArray((Array) this.HistorySFType, (Array) new MapMatrix2[this.MapCount + 1]);
      this.HistoryHis = (MapMatrix2[]) Utils.CopyArray((Array) this.HistoryHis, (Array) new MapMatrix2[this.MapCount + 1]);
      this.HistoryDepth = (MapMatrix2[]) Utils.CopyArray((Array) this.HistoryDepth, (Array) new MapMatrix2[this.MapCount + 1]);
      this.AIVP = (MapMatrix2[]) Utils.CopyArray((Array) this.AIVP, (Array) new MapMatrix2[this.MapCount + 1]);
      this.Trafic = (MapMatrix2[]) Utils.CopyArray((Array) this.Trafic, (Array) new MapMatrix2[this.MapCount + 1]);
      this.Trafic2 = (MapMatrix2[]) Utils.CopyArray((Array) this.Trafic2, (Array) new MapMatrix2[this.MapCount + 1]);
      this.AIPower = (MapMatrix2[]) Utils.CopyArray((Array) this.AIPower, (Array) new MapMatrix2[this.MapCount + 1]);
      this.AIDefense = (MapMatrix2[]) Utils.CopyArray((Array) this.AIDefense, (Array) new MapMatrix2[this.MapCount + 1]);
    }

    pub void AddResField()
    {
      this += 1.ResFieldCounter;
      this.ResField = (bool[]) Utils.CopyArray((Array) this.ResField, (Array) new bool[this.ResFieldCounter + 1]);
      this.ResField[this.ResFieldCounter] = false;
    }

    pub void RemoveResField(int nr)
    {
      if (nr < this.ResFieldCounter)
      {
        let mut num1: i32 = nr;
        let mut num2: i32 = this.ResFieldCounter - 1;
        for (let mut index: i32 = num1; index <= num2; index += 1)
          this.ResField[index] = this.ResField[index + 1];
      }
      --this.ResFieldCounter;
      if (this.ResFieldCounter <= -1)
        return;
      this.ResField = (bool[]) Utils.CopyArray((Array) this.ResField, (Array) new bool[this.ResFieldCounter + 1]);
    }

    pub void AddRegime()
    {
      this += 1.RegimeCounter;
      this.RegimeRel = (int[]) Utils.CopyArray((Array) this.RegimeRel, (Array) new int[this.RegimeCounter + 1]);
      this.RegimeOffer = (int[]) Utils.CopyArray((Array) this.RegimeOffer, (Array) new int[this.RegimeCounter + 1]);
      this.RegimeRel[this.RegimeCounter] = 1;
    }

    pub void Removeregime(int nr)
    {
      if (nr < this.RegimeCounter)
      {
        let mut num1: i32 = nr;
        let mut num2: i32 = this.RegimeCounter - 1;
        for (let mut index: i32 = num1; index <= num2; index += 1)
          this.RegimeRel[index] = this.RegimeRel[index + 1];
      }
      --this.RegimeCounter;
      if (this.RegimeCounter <= -1)
        return;
      this.RegimeRel = (int[]) Utils.CopyArray((Array) this.RegimeRel, (Array) new int[this.RegimeCounter + 1]);
    }

    pub void AddActionCard(int nr)
    {
      this += 1.ActionCardCounter;
      this.ActionCard = (int[]) Utils.CopyArray((Array) this.ActionCard, (Array) new int[this.ActionCardCounter + 1]);
      this.ActionCard[this.ActionCardCounter] = nr;
    }

    pub void RemoveActionCard(int nr)
    {
      if (nr < this.ActionCardCounter)
      {
        let mut num1: i32 = nr;
        let mut num2: i32 = this.ActionCardCounter - 1;
        for (let mut index: i32 = num1; index <= num2; index += 1)
          this.ActionCard[index] = this.ActionCard[index + 1];
      }
      --this.ActionCardCounter;
      if (this.ActionCardCounter <= -1)
        return;
      this.ActionCard = (int[]) Utils.CopyArray((Array) this.ActionCard, (Array) new int[this.ActionCardCounter + 1]);
    }

    pub void AddActionCardHistory(int nr, int round)
    {
      this += 1.ActionCardHistoryCounter;
      this.ActionCardHistory = (int[]) Utils.CopyArray((Array) this.ActionCardHistory, (Array) new int[this.ActionCardHistoryCounter + 1]);
      this.ActionCardHistoryRound = (int[]) Utils.CopyArray((Array) this.ActionCardHistoryRound, (Array) new int[this.ActionCardHistoryCounter + 1]);
      this.ActionCardHistory[this.ActionCardHistoryCounter] = nr;
      this.ActionCardHistoryRound[this.ActionCardHistoryCounter] = round;
    }

    pub void RemoveActionCardHistory(int nr)
    {
      if (nr < this.ActionCardHistoryCounter)
      {
        let mut num1: i32 = nr;
        let mut num2: i32 = this.ActionCardHistoryCounter - 1;
        for (let mut index: i32 = num1; index <= num2; index += 1)
        {
          this.ActionCardHistory[index] = this.ActionCardHistory[index + 1];
          this.ActionCardHistoryRound[index] = this.ActionCardHistoryRound[index + 1];
        }
      }
      --this.ActionCardHistoryCounter;
      if (this.ActionCardHistoryCounter <= -1)
        return;
      this.ActionCardHistory = (int[]) Utils.CopyArray((Array) this.ActionCardHistory, (Array) new int[this.RegimeCounter + 1]);
      this.ActionCardHistoryRound = (int[]) Utils.CopyArray((Array) this.ActionCardHistoryRound, (Array) new int[this.RegimeCounter + 1]);
    }

    pub void DoTempCounterBig() => this.DoTempCounterAnySize(1);

    pub void DoTempCounter() => this.DoTempCounterAnySize(0);

    pub void DoTempCounterSmall() => this.DoTempCounterAnySize(-1);

    pub void doTempRegimeHighlight(bool lighter = false)
    {
      float num1 = (float) ((double) this.Red / 512.0 - 0.9);
      float num2 = (float) ((double) this.Green / 512.0 - 0.9);
      float num3 = (float) ((double) this.Blue / 512.0 - 0.9);
      float num4 = 0.25f;
      if (lighter)
        num4 = 0.1f;
      Bitmap bitmap1 = new Bitmap(128, 96);
      bitmap1.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics1 = Graphics.FromImage((Image) bitmap1);
      graphics1.Clear(Color.Transparent);
       let mut local1: &Graphics = &graphics1;
      Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.WHITEHEX, 1);
       let mut local2: &Bitmap = &bitmap2;
      double r1 = (double) num1;
      double g1 = (double) num2;
      double b1 = (double) num3;
      double a1 = (double) num4;
      DrawMod.Draw( local1,  local2, 0, 0, (float) r1, (float) g1, (float) b1, (float) a1);
      this.TempRegimeColorBig = bitmap1;
      graphics1.Dispose();
      Bitmap bitmap3 = new Bitmap(64, 48);
      bitmap3.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics2 = Graphics.FromImage((Image) bitmap3);
      graphics2.Clear(Color.Transparent);
       let mut local3: &Graphics = &graphics2;
      Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.WHITEHEX);
       let mut local4: &Bitmap = &bitmap4;
      double r2 = (double) num1;
      double g2 = (double) num2;
      double b2 = (double) num3;
      double a2 = (double) num4;
      DrawMod.Draw( local3,  local4, 0, 0, (float) r2, (float) g2, (float) b2, (float) a2);
      this.TempRegimeColor = bitmap3;
      graphics2.Dispose();
      Bitmap bitmap5 = new Bitmap(32, 24);
      bitmap5.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics3 = Graphics.FromImage((Image) bitmap5);
      graphics3.Clear(Color.Transparent);
       let mut local5: &Graphics = &graphics3;
      Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.WHITEHEX, -1);
       let mut local6: &Bitmap = &bitmap6;
      double r3 = (double) num1;
      double g3 = (double) num2;
      double b3 = (double) num3;
      double a3 = (double) num4;
      DrawMod.Draw( local5,  local6, 0, 0, (float) r3, (float) g3, (float) b3, (float) a3);
      this.TempRegimeColorSmall = bitmap5;
      graphics3.Dispose();
    }

    pub void DoTempCounterAnySize(int sizey)
    {
      let mut landscapeTypeCounter: i32 = DrawMod.TGame.Data.LandscapeTypeCounter;
      let mut num1: i32 = 76;
      let mut num2: i32 = 75;
      let mut num3: i32 = 128;
      let mut num4: i32 = 96;
      switch (sizey)
      {
        case -1:
          num2 = 18;
          num1 = 19;
          num4 = 24;
          num3 = 32;
          break;
        case 0:
          num2 = 37;
          num1 = 38;
          num4 = 48;
          num3 = 64;
          break;
      }
      float num5 = (float) this.Red / (float) byte.MaxValue;
      float num6 = (float) this.Green / (float) byte.MaxValue;
      float num7 = (float) this.Blue / (float) byte.MaxValue;
      float num8 = (float) (1.0 * ((double) num5 / (((double) num6 + (double) num7) / 2.0)));
      float num9 = (float) (1.0 * ((double) num6 / (((double) num5 + (double) num7) / 2.0)));
      float num10 = (float) (1.0 * ((double) num7 / (((double) num6 + (double) num5) / 2.0)));
      float num11 = (float) ((1.0 + (double) num8) / 2.0);
      float num12 = (float) ((1.0 + (double) num9) / 2.0);
      float num13 = (float) ((1.0 + (double) num10) / 2.0);
      Bitmap bitmap1 = new Bitmap(num1 * (landscapeTypeCounter + 1), num1);
      bitmap1.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      str1: String = "systemgraphics/defaultcounterbig.png";
      if (sizey == -1)
        str1 = "systemgraphics/defaultcountersmall.png";
      if (sizey == 0)
        str1 = "systemgraphics/defaultcounter.png";
      graphicsDirectory: String = DrawMod.TGame.ModSystemGraphicsDirectory;
      if (Strings.Len(graphicsDirectory) > 1)
        str1 = str1.Replace("systemgraphics", graphicsDirectory);
      Bitmap objBitmap;
      if (File.Exists(BitmapStore.GraphicsPath + str1))
      {
        objBitmap = new Bitmap(BitmapStore.GraphicsPath + str1);
      }
      else
      {
        str2: String = "systemgraphics/defaultcounterbig.png";
        if (sizey == -1)
          str2 = "systemgraphics/defaultcountersmall.png";
        if (sizey == 0)
          str2 = "systemgraphics/defaultcounter.png";
        objBitmap = new Bitmap(BitmapStore.GraphicsPath + str2);
      }
      objBitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      let mut num14: i32 = objBitmap.Height - 1;
      Color pixel1;
      for (let mut y: i32 = 0; y <= num14; y += 1)
      {
        let mut num15: i32 = objBitmap.Width - 1;
        for (let mut x: i32 = 0; x <= num15; x += 1)
        {
          pixel1 = objBitmap.GetPixel(x, y);
          let mut red: i32 =  Math.Round((double) ((float) pixel1.R * num5));
          let mut green: i32 =  Math.Round((double) ((float) pixel1.G * num6));
          let mut blue: i32 =  Math.Round((double) ((float) pixel1.B * num7));
          objBitmap.SetPixel(x, y, Color.FromArgb( pixel1.A, red, green, blue));
        }
      }
      Graphics objGraphics = Graphics.FromImage((Image) bitmap1);
      objGraphics.Clear(Color.Transparent);
      let mut num16: i32 = landscapeTypeCounter;
      for (let mut index: i32 = 0; index <= num16; index += 1)
        DrawMod.DrawSimple( objGraphics,  objBitmap, index * num1, 0);
      objGraphics.Dispose();
      Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.WHITEHEX, 1);
      float num17 = 0.4f;
      float num18 = 0.6f;
      let mut num19: i32 = landscapeTypeCounter;
      Rectangle rectangle1;
      Rectangle rectangle2;
      Color pixel2;
      for (let mut index1: i32 = 0; index1 <= num19; index1 += 1)
      {
        if (DrawMod.TGame.Data.LandscapeTypeObj[index1].PreHexPicID > 0 & Strings.InStr(DrawMod.TGame.Data.LandscapeTypeObj[index1].PreHexPicFileName, "trans") < 1 & Strings.InStr(DrawMod.TGame.Data.LandscapeTypeObj[index1].PreHexPicFileName, "blackhex") < 1)
        {
          bool flag = false;
          let mut num20: i32 = index1 - 1;
          for (let mut index2: i32 = 0; index2 <= num20; index2 += 1)
          {
            if (DrawMod.TGame.Data.LandscapeTypeObj[index2].UsePreHexTexture && DrawMod.TGame.Data.LandscapeTypeObj[index1].PreHexTextureID == DrawMod.TGame.Data.LandscapeTypeObj[index2].PreHexTextureID)
            {
              flag = true;
              Graphics graphics = Graphics.FromImage((Image) bitmap1);
              graphics.CompositingMode = CompositingMode.SourceCopy;
               let mut local1: &Graphics = &graphics;
               let mut local2: &Bitmap = &bitmap1;
              rectangle1 = Rectangle::new(num1 * index2, 0, num1, num1);
              let mut srcrect: &Rectangle = &rectangle1
              rectangle2 = Rectangle::new(num1 * index1, 0, num1, num1);
              let mut destrect: &Rectangle = &rectangle2
              DrawMod.DrawSimplePart2( local1,  local2, srcrect, destrect);
              graphics.Dispose();
              break;
            }
          }
          if (!flag)
          {
            Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.Data.LandscapeTypeObj[index1].PreHexPicID, 1);
            if (!Information.IsNothing((object) bitmap3))
            {
              long num21 = 0;
              long num22 = 0;
              let mut num23: i32 = num2;
              for (let mut y: i32 = 0; y <= num23; y += 1)
              {
                let mut num24: i32 = num2;
                for (let mut index3: i32 = 0; index3 <= num24; index3 += 1)
                {
                  pixel2 = bitmap3.GetPixel(index3 + 26, y);
                  num21 += (long) ( Math.Round((double) ( pixel2.G +  pixel2.B +  pixel2.R) / 3.0) *  Math.Round((double) pixel2.A / 16.0));
                  num22 += (long)  Math.Round((double) pixel2.A / 16.0);
                }
              }
              let mut num25: i32 =  Math.Round((double) num21 / (double) num22);
              let mut num26: i32 = num2;
              for (let mut y1: i32 = 0; y1 <= num26; y1 += 1)
              {
                let mut num27: i32 = num2;
                for (let mut x1: i32 = 0; x1 <= num27; x1 += 1)
                {
                  pixel1 = bitmap1.GetPixel(x1, y1);
                  pixel2 = bitmap3.GetPixel(x1 + 26, y1);
                  let mut r: i32 =  pixel2.R;
                  let mut g: i32 =  pixel2.G;
                  let mut b: i32 =  pixel2.B;
                  let mut a1: i32 =  pixel2.A;
                  let mut num28: i32 =  Math.Round((double) (r + b + g) / 3.0);
                  int num29;
                  int num30;
                  int num31;
                  if (num28 > num25)
                  {
                    num29 =  Math.Round((double) pixel1.G + (double) (Math.Min( pixel1.G * 2,  byte.MaxValue) -  pixel1.G) * ((double) (num28 - num25) / (double) byte.MaxValue));
                    num30 =  Math.Round((double) pixel1.R + (double) (Math.Min( pixel1.R * 2,  byte.MaxValue) -  pixel1.R) * ((double) (num28 - num25) / (double) byte.MaxValue));
                    num31 =  Math.Round((double) pixel1.B + (double) (Math.Min( pixel1.B * 2,  byte.MaxValue) -  pixel1.B) * ((double) (num28 - num25) / (double) byte.MaxValue));
                  }
                  else
                  {
                    num29 =  Math.Round((double) pixel1.G - (double) Math.Min( pixel1.G * 2,  byte.MaxValue) * ((double) (num25 - num28) / (double) byte.MaxValue));
                    num30 =  Math.Round((double) pixel1.R - (double) Math.Min( pixel1.R * 2,  byte.MaxValue) * ((double) (num25 - num28) / (double) byte.MaxValue));
                    num31 =  Math.Round((double) pixel1.B - (double) Math.Min( pixel1.B * 2,  byte.MaxValue) * ((double) (num25 - num28) / (double) byte.MaxValue));
                  }
                  let mut val2_1: i32 =  Math.Round((double) g * (double) num17 + (double) num29 * (double) num18);
                  let mut val2_2: i32 =  Math.Round((double) b * (double) num17 + (double) num31 * (double) num18);
                  let mut val2_3: i32 =  Math.Round((double) r * (double) num17 + (double) num30 * (double) num18);
                  if (pixel2.A == (byte) 0)
                  {
                    val2_1 =  pixel1.G;
                    val2_2 =  pixel1.B;
                    val2_3 =  pixel1.R;
                  }
                  else if (pixel2.A < byte.MaxValue)
                  {
                    val2_1 =  Math.Round((double) val2_1 * ((double) a1 / (double) byte.MaxValue) + (double) pixel1.G * ((double) ( byte.MaxValue - a1) / (double) byte.MaxValue));
                    val2_2 =  Math.Round((double) val2_2 * ((double) a1 / (double) byte.MaxValue) + (double) pixel1.B * ((double) ( byte.MaxValue - a1) / (double) byte.MaxValue));
                    val2_3 =  Math.Round((double) val2_3 * ((double) a1 / (double) byte.MaxValue) + (double) pixel1.R * ((double) ( byte.MaxValue - a1) / (double) byte.MaxValue));
                  }
                  let mut a2: i32 =  pixel1.A;
                  let mut red: i32 = Math.Max(0, Math.Min( byte.MaxValue, val2_3));
                  let mut green: i32 = Math.Max(0, Math.Min( byte.MaxValue, val2_1));
                  let mut blue: i32 = Math.Max(0, Math.Min( byte.MaxValue, val2_2));
                  let mut x2: i32 = x1 + index1 * num1;
                  let mut y2: i32 = y1;
                  bitmap1.SetPixel(x2, y2, Color.FromArgb(a2, red, green, blue));
                }
              }
            }
          }
        }
        else if (DrawMod.TGame.Data.LandscapeTypeObj[index1].UseSheet & !Information.IsNothing((object) BitmapStore.GetBitmap(DrawMod.TGame.Data.LandscapeTypeObj[index1].SheetSpriteID)))
        {
          bool flag = false;
          let mut num32: i32 = index1 - 1;
          for (let mut index4: i32 = 0; index4 <= num32; index4 += 1)
          {
            if (DrawMod.TGame.Data.LandscapeTypeObj[index4].UsePreHexTexture && DrawMod.TGame.Data.LandscapeTypeObj[index1].PreHexTextureID == DrawMod.TGame.Data.LandscapeTypeObj[index4].PreHexTextureID)
            {
              flag = true;
              Graphics graphics = Graphics.FromImage((Image) bitmap1);
              graphics.CompositingMode = CompositingMode.SourceCopy;
               let mut local3: &Graphics = &graphics;
               let mut local4: &Bitmap = &bitmap1;
              rectangle2 = Rectangle::new(num1 * index4, 0, num1, num1);
              let mut srcrect: &Rectangle = &rectangle2
              rectangle1 = Rectangle::new(num1 * index1, 0, num1, num1);
              let mut destrect: &Rectangle = &rectangle1
              DrawMod.DrawSimplePart2( local3,  local4, srcrect, destrect);
              graphics.Dispose();
              break;
            }
          }
          if (!flag)
          {
            Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.Data.LandscapeTypeObj[index1].SheetSpriteID, 1);
            if (!Information.IsNothing((object) bitmap4))
            {
              long num33 = 0;
              long num34 = 0;
              let mut num35: i32 = num2;
              for (let mut y: i32 = 0; y <= num35; y += 1)
              {
                let mut num36: i32 = num2;
                for (let mut index5: i32 = 0; index5 <= num36; index5 += 1)
                {
                  pixel2 = bitmap4.GetPixel(index5 + 26, y);
                  num33 += (long) ( Math.Round((double) ( pixel2.G +  pixel2.B +  pixel2.R) / 3.0) *  Math.Round((double) pixel2.A / 16.0));
                  num34 += (long)  Math.Round((double) pixel2.A / 16.0);
                }
              }
              let mut num37: i32 =  Math.Round((double) num33 / (double) num34);
              let mut num38: i32 = num2;
              for (let mut y3: i32 = 0; y3 <= num38; y3 += 1)
              {
                let mut num39: i32 = num2;
                for (let mut x3: i32 = 0; x3 <= num39; x3 += 1)
                {
                  pixel1 = bitmap1.GetPixel(x3, y3);
                  pixel2 = bitmap4.GetPixel(x3 + 256 + 26, y3 + 960);
                  let mut r: i32 =  pixel2.R;
                  let mut g: i32 =  pixel2.G;
                  let mut b: i32 =  pixel2.B;
                  let mut num40: i32 =  Math.Round((double) (r + b + g) / 3.0);
                  int num41;
                  int num42;
                  int num43;
                  if (num40 > num37)
                  {
                    num41 =  Math.Round((double) pixel1.G + (double) (Math.Min( pixel1.G * 2,  byte.MaxValue) -  pixel1.G) * ((double) (num40 - num37) / (double) byte.MaxValue));
                    num42 =  Math.Round((double) pixel1.R + (double) (Math.Min( pixel1.R * 2,  byte.MaxValue) -  pixel1.R) * ((double) (num40 - num37) / (double) byte.MaxValue));
                    num43 =  Math.Round((double) pixel1.B + (double) (Math.Min( pixel1.B * 2,  byte.MaxValue) -  pixel1.B) * ((double) (num40 - num37) / (double) byte.MaxValue));
                  }
                  else
                  {
                    num41 =  Math.Round((double) pixel1.G - (double) Math.Min( pixel1.G * 2,  byte.MaxValue) * ((double) (num37 - num40) / (double) byte.MaxValue));
                    num42 =  Math.Round((double) pixel1.R - (double) Math.Min( pixel1.R * 2,  byte.MaxValue) * ((double) (num37 - num40) / (double) byte.MaxValue));
                    num43 =  Math.Round((double) pixel1.B - (double) Math.Min( pixel1.B * 2,  byte.MaxValue) * ((double) (num37 - num40) / (double) byte.MaxValue));
                  }
                  let mut val2_4: i32 =  Math.Round((double) g * 0.25 + (double) num41 * 0.75);
                  let mut val2_5: i32 =  Math.Round((double) b * 0.25 + (double) num43 * 0.75);
                  let mut val2_6: i32 =  Math.Round((double) r * 0.25 + (double) num42 * 0.75);
                  let mut a: i32 =  pixel1.A;
                  let mut red: i32 = Math.Max(0, Math.Min( byte.MaxValue, val2_6));
                  let mut green: i32 = Math.Max(0, Math.Min( byte.MaxValue, val2_4));
                  let mut blue: i32 = Math.Max(0, Math.Min( byte.MaxValue, val2_5));
                  let mut x4: i32 = x3 + index1 * num1;
                  let mut y4: i32 = y3;
                  bitmap1.SetPixel(x4, y4, Color.FromArgb(a, red, green, blue));
                }
              }
            }
          }
        }
        else if (DrawMod.TGame.Data.LandscapeTypeObj[index1].UsePreHexTexture)
        {
          let mut preHexTextureId: i32 = DrawMod.TGame.Data.LandscapeTypeObj[index1].PreHexTextureID;
          bool flag = false;
          let mut num44: i32 = index1 - 1;
          for (let mut index6: i32 = 0; index6 <= num44; index6 += 1)
          {
            if (DrawMod.TGame.Data.LandscapeTypeObj[index6].UsePreHexTexture && DrawMod.TGame.Data.LandscapeTypeObj[index1].PreHexTextureID == DrawMod.TGame.Data.LandscapeTypeObj[index6].PreHexTextureID)
            {
              flag = true;
              Graphics graphics = Graphics.FromImage((Image) bitmap1);
              graphics.CompositingMode = CompositingMode.SourceCopy;
               let mut local5: &Graphics = &graphics;
               let mut local6: &Bitmap = &bitmap1;
              rectangle2 = Rectangle::new(num1 * index6, 0, num1, num1);
              let mut srcrect: &Rectangle = &rectangle2
              rectangle1 = Rectangle::new(num1 * index1, 0, num1, num1);
              let mut destrect: &Rectangle = &rectangle1
              DrawMod.DrawSimplePart2( local5,  local6, srcrect, destrect);
              graphics.Dispose();
              break;
            }
          }
          if (!flag)
          {
            let mut count: i32 = 49152;
            byte[] dst = new byte[count - 1 + 1];
            let mut num45: i32 = (0 + BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal) % BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal * 8 + (0 + BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal) % BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal;
            Buffer.BlockCopy((Array) BitmapStore.simpleByteCacheObj[preHexTextureId].cacheBig, num45 * count, (Array) dst, 0, count);
            let mut index7: i32 = 0;
            let mut num46: i32 = 0;
            let mut num47: i32 = 0;
            let mut num48: i32 = bitmap2.Height - 1;
            for (let mut index8: i32 = 0; index8 <= num48; index8 += 1)
            {
              let mut num49: i32 = bitmap2.Width - 1;
              for (let mut index9: i32 = 0; index9 <= num49; index9 += 1)
              {
                if (index9 <= num2 & index8 <= num2)
                {
                  index7 += 4;
                  let mut num50: i32 =  dst[index7];
                  let mut num51: i32 =  dst[index7 + 1];
                  let mut num52: i32 =  dst[index7 + 2];
                  num46 +=  Math.Round((double) (num50 + num51 + num52) / 3.0);
                  num47 += 1;
                }
              }
            }
            let mut num53: i32 =  Math.Round((double) num46 / (double) num47);
            let mut index10: i32 = 0;
            let mut num54: i32 = bitmap2.Height - 1;
            for (let mut y5: i32 = 0; y5 <= num54; y5 += 1)
            {
              let mut num55: i32 = bitmap2.Width - 1;
              for (let mut index11: i32 = 0; index11 <= num55; index11 += 1)
              {
                if (index11 <= num2 & y5 <= num2)
                {
                  pixel1 = bitmap1.GetPixel(index11 + index1 * num1, y5);
                  let mut num56: i32 =  dst[index10];
                  let mut num57: i32 =  dst[index10 + 1];
                  let mut num58: i32 =  dst[index10 + 2];
                  let mut num59: i32 =  Math.Round((double) (num57 + num56 + num58) / 3.0);
                  int num60;
                  int num61;
                  int num62;
                  if (num59 > num53)
                  {
                    num60 =  Math.Round((double) pixel1.G + (double) (Math.Min( pixel1.G * 2,  byte.MaxValue) -  pixel1.G) * ((double) (num59 - num53) / (double) byte.MaxValue));
                    num61 =  Math.Round((double) pixel1.R + (double) (Math.Min( pixel1.R * 2,  byte.MaxValue) -  pixel1.R) * ((double) (num59 - num53) / (double) byte.MaxValue));
                    num62 =  Math.Round((double) pixel1.B + (double) (Math.Min( pixel1.B * 2,  byte.MaxValue) -  pixel1.B) * ((double) (num59 - num53) / (double) byte.MaxValue));
                  }
                  else
                  {
                    num60 =  Math.Round((double) pixel1.G - (double) Math.Min( pixel1.G * 2,  byte.MaxValue) * ((double) (num53 - num59) / (double) byte.MaxValue));
                    num61 =  Math.Round((double) pixel1.R - (double) Math.Min( pixel1.R * 2,  byte.MaxValue) * ((double) (num53 - num59) / (double) byte.MaxValue));
                    num62 =  Math.Round((double) pixel1.B - (double) Math.Min( pixel1.B * 2,  byte.MaxValue) * ((double) (num53 - num59) / (double) byte.MaxValue));
                  }
                  let mut num63: i32 =  Math.Round((double) num57 * 0.14 + (double) num58 * 0.7 + (double) num56 * 0.1);
                  let mut val2_7: i32 =  Math.Round((double) num63 * 0.4 + (double) num60 * 0.75);
                  let mut val2_8: i32 =  Math.Round((double) num63 * 0.4 + (double) num62 * 0.75);
                  let mut val2_9: i32 =  Math.Round((double) num63 * 0.4 + (double) num61 * 0.75);
                  let mut a: i32 =  pixel1.A;
                  let mut red: i32 = Math.Max(0, Math.Min( byte.MaxValue, val2_9));
                  let mut green: i32 = Math.Max(0, Math.Min( byte.MaxValue, val2_7));
                  let mut blue: i32 = Math.Max(0, Math.Min( byte.MaxValue, val2_8));
                  let mut x: i32 = index11 + index1 * num1;
                  let mut y6: i32 = y5;
                  bitmap1.SetPixel(x, y6, Color.FromArgb( pixel1.A, red, green, blue));
                }
                index10 += 4;
              }
            }
          }
        }
        else if (!DrawMod.TGame.Data.LandscapeTypeObj[index1].UseSheet & DrawMod.TGame.Data.LandscapeTypeObj[index1].LayerSpriteID[0] > 0)
        {
          Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.Data.LandscapeTypeObj[index1].LayerSpriteID[0], 1);
          if (!Information.IsNothing((object) bitmap5))
          {
            let mut num64: i32 = 0;
            let mut num65: i32 = 0;
            let mut num66: i32 = num2;
            for (let mut y: i32 = 0; y <= num66; y += 1)
            {
              let mut num67: i32 = num2;
              for (let mut index12: i32 = 0; index12 <= num67; index12 += 1)
              {
                pixel2 = bitmap5.GetPixel(index12 + 26, y);
                num64 +=  Math.Round((double) (byte) ((uint) (byte) ((uint) pixel2.G + (uint) pixel2.B) + (uint) pixel2.R) / 3.0) *  Math.Round((double) pixel2.A / 16.0);
                num65 +=  Math.Round((double) pixel2.A / 16.0);
              }
            }
            let mut num68: i32 =  Math.Round((double) num64 / (double) num65);
            let mut num69: i32 = num2;
            for (let mut y7: i32 = 0; y7 <= num69; y7 += 1)
            {
              let mut num70: i32 = num2;
              for (let mut x5: i32 = 0; x5 <= num70; x5 += 1)
              {
                pixel1 = bitmap1.GetPixel(x5, y7);
                pixel2 = bitmap5.GetPixel(x5 + 26, y7);
                let mut r: i32 =  pixel2.R;
                let mut g: i32 =  pixel2.G;
                let mut b: i32 =  pixel2.B;
                let mut num71: i32 =  Math.Round((double) (r + b + g) / 3.0);
                int num72;
                int num73;
                int num74;
                if (num71 > num68)
                {
                  num72 =  Math.Round((double) pixel1.G + (double) (Math.Min( pixel1.G * 2,  byte.MaxValue) -  pixel1.G) * ((double) (num71 - num68) / 128.0));
                  num73 =  Math.Round((double) pixel1.R + (double) (Math.Min( pixel1.R * 2,  byte.MaxValue) -  pixel1.R) * ((double) (num71 - num68) / 128.0));
                  num74 =  Math.Round((double) pixel1.B + (double) (Math.Min( pixel1.B * 2,  byte.MaxValue) -  pixel1.B) * ((double) (num71 - num68) / 128.0));
                }
                else
                {
                  num72 =  Math.Round((double) pixel1.G - (double) Math.Min( pixel1.G * 2,  byte.MaxValue) * ((double) (num68 - num71) / 128.0));
                  num73 =  Math.Round((double) pixel1.R - (double) Math.Min( pixel1.R * 2,  byte.MaxValue) * ((double) (num68 - num71) / 128.0));
                  num74 =  Math.Round((double) pixel1.B - (double) Math.Min( pixel1.B * 2,  byte.MaxValue) * ((double) (num68 - num71) / 128.0));
                }
                let mut val2_10: i32 =  Math.Round((double) g * 0.25 + (double) num72 * 0.75);
                let mut val2_11: i32 =  Math.Round((double) b * 0.25 + (double) num74 * 0.75);
                let mut val2_12: i32 =  Math.Round((double) r * 0.25 + (double) num73 * 0.75);
                let mut a: i32 =  pixel1.A;
                let mut red: i32 = Math.Max(0, Math.Min( byte.MaxValue, val2_12));
                let mut green: i32 = Math.Max(0, Math.Min( byte.MaxValue, val2_10));
                let mut blue: i32 = Math.Max(0, Math.Min( byte.MaxValue, val2_11));
                let mut x6: i32 = x5 + index1 * num1;
                let mut y8: i32 = y7;
                bitmap1.SetPixel(x6, y8, Color.FromArgb(a, red, green, blue));
              }
            }
          }
        }
        else
        {
          let mut num75: i32 = num75;
        }
      }
      Bitmap bitmap6 = new Bitmap(bitmap1.Width, bitmap1.Height);
      bitmap6.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics1 = Graphics.FromImage((Image) bitmap6);
      graphics1.CompositingMode = CompositingMode.SourceCopy;
       let mut local7: &Graphics = &graphics1;
       let mut local8: &Bitmap = &bitmap1;
      rectangle2 = Rectangle::new(0, 0, bitmap1.Width, bitmap1.Height);
      let mut srcrect1: &Rectangle = &rectangle2
      rectangle1 = Rectangle::new(0, 0, bitmap1.Width, bitmap1.Height);
      let mut destrect1: &Rectangle = &rectangle1
      DrawMod.DrawSimplePart2ColouredNew( local7,  local8, srcrect1, destrect1, 0.9f, 0.9f, 0.9f, 1f);
      graphics1.Dispose();
      graphics1 = (Graphics) null;
      switch (sizey)
      {
        case -1:
          this.TempCountersmall = bitmap1;
          this.TempCountersmallHigh = bitmap6;
          break;
        case 0:
          this.TempCounter = bitmap1;
          this.TempCounterHigh = bitmap6;
          break;
        case 1:
          this.TempCounterBig = bitmap1;
          this.TempCounterBigHigh = bitmap6;
          break;
      }
    }

    pub void Kill()
    {
      this.TempCounter = (Bitmap) null;
      BitmapStore.RemoveBitmapNr(this.NationalIconSprite);
      BitmapStore.RemoveBitmapNr(this.HQSpriteNr);
    }

    pub void LoadSprites()
    {
      this.HQSpriteNr = BitmapStore.AddFile(this.HQSpriteFileName, false, true);
      this.HQSpriteNr2 = BitmapStore.AddFile(this.HQSpriteFileName2, false, true);
      this.TempCounter = (Bitmap) null;
      this.NationalIconSprite = BitmapStore.AddFile(this.NationalIconSpriteName, false, true);
      this.RoundelIconSprite = BitmapStore.AddFile(this.RoundelSpriteName, false);
      this.RoundelIconSprite2 = BitmapStore.AddFile(this.RoundelSpriteName2, false);
      this.BannerSpriteNr = BitmapStore.AddFile(this.BannerSpriteFileName, false);
      this.BannerSpriteNr2 = BitmapStore.AddFile(this.BannerSpriteFileName2, false);
      this.SymbolSpriteNr = BitmapStore.AddFile(this.SymbolSpriteName, false);
    }

    pub void ReplaceNationalSprite(string filename)
    {
      this.NationalIconSpriteName = filename;
      this.NationalIconSprite = BitmapStore.ReloadFile(this.NationalIconSprite, filename, IsBig: true);
    }

    pub void ReplaceRoundelSprite(string filename)
    {
      this.RoundelSpriteName = filename;
      this.RoundelIconSprite = BitmapStore.ReloadFile(this.RoundelIconSprite, filename);
    }

    pub void ReplaceBannerSprite(string filename)
    {
      this.BannerSpriteFileName = filename;
      this.BannerSpriteNr = BitmapStore.ReloadFile(this.BannerSpriteNr, filename);
    }

    pub void ReplaceSymbolSprite(string filename)
    {
      this.SymbolSpriteName = filename;
      this.SymbolSpriteNr = BitmapStore.ReloadFile(this.SymbolSpriteNr, filename);
    }

    pub void ReplaceHQSprite(string filename)
    {
      this.HQSpriteFileName = filename;
      this.HQSpriteNr = BitmapStore.AddFile(this.HQSpriteFileName, false, true);
      if (DrawMod.TGame.Data.Product >= 7)
        return;
      this.DoTempCounter();
    }

    pub void ReplaceRoundelSprite2(string filename)
    {
      this.RoundelSpriteName2 = filename;
      this.RoundelIconSprite2 = BitmapStore.ReloadFile(this.RoundelIconSprite2, filename);
    }

    pub void ReplaceHQSprite2(string filename)
    {
      this.HQSpriteFileName2 = filename;
      this.HQSpriteNr2 = BitmapStore.AddFile(this.HQSpriteFileName2, false, true);
      if (DrawMod.TGame.Data.Product >= 7)
        return;
      this.DoTempCounter();
    }

    pub void ReplaceBannerSprite2(string filename)
    {
      this.BannerSpriteFileName2 = filename;
      this.BannerSpriteNr2 = BitmapStore.ReloadFile(this.BannerSpriteNr2, filename);
    }
  }
}
