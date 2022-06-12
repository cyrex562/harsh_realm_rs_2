﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SFTypeClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsApplication1
{
  [Serializable]
  public class SFTypeClass : ISerializable
  {
    public string Name;
    public string Description;
    public int Id;
    public string PicFileName;
    public int PicSpriteID;
    public string SidewaysFileName;
    public int SidewaysSpriteID;
    public string SymbolFileName;
    public int SymbolSpriteID;
    public string SymbolColBigFileName;
    public int SymbolColBigSpriteID;
    public string SymbolColBigFileName2;
    public int SymbolColBigSprite2ID;
    public string SymbolFileName2;
    public int SymbolSprite2ID;
    public int SymbolGroup;
    public int SymbolWeight;
    public bool SymbolOverrule;
    public int ExtraCounter;
    public string[] ExtraPicFileName;
    public int[] ExtraPicSpriteID;
    public string[] ExtraSidewaysFileName;
    public int[] ExtraSidewaysSpriteID;
    public string[] ExtraSymbolFileName;
    public int[] ExtraSymbolSpriteID;
    public string[] ExtraSymbolFileName2;
    public int[] ExtraSymbolSprite2ID;
    public string[] ExtraSymbolColBigFileName;
    public int[] ExtraSymbolColBigSpriteID;
    public string[] ExtraSymbolColBigFileName2;
    public int[] ExtraSymbolColBigSprite2ID;
    public int[] ExtraCode;
    public string[] ExtraName;
    public int BaseColor;
    public int MoveType;
    public int SupplyCarry;
    public bool[] PeopleGroup;
    public int Cap;
    public int RailCap;
    public int BasicSupplyNeed;
    public int UnitGroup;
    public int Theater;
    public int Weight;
    public int Frontage;
    public int EntrenchPower;
    public int DefPower;
    public int Initiative;
    public int InitiativeDef;
    public int MaxAttacked;
    public int Attacks;
    public bool BackBench;
    public int ArtRange;
    public int[] FavTarget;
    public int[] FavArtTarget;
    public int FavTargetTries;
    public int[] AttackPower;
    public int[] AttackPowerDef;
    public object[] AttackArt;
    public bool CanDoParadrop;
    public int KillPercent;
    public int EquipPercent;
    public int RetreatPercent;
    public int RdnLossPerAttack;
    public bool AutoDestroy;
    public bool AutoDestroy2;
    public int CarryCap;
    public int AirCarrierCap;
    public int PowerPts;
    public int AntiStrucPts;
    public int ReconPts;
    public int HidePts;
    public int ZOCPts;
    public float ApMod;
    public int EP;
    public string MoveWAV;
    public string BattleWAV;
    public int MoveRedux;
    public int targettedByRangedChance;
    public int CopyDataFrom;
    public int CopyDataFromBackup;
    public float[] CombatModAtt;
    public float[] CombatModDef;
    public int[] ExtraRecon;
    public int StaffPts;
    public float StaffCombatMod;
    public float StaffMoraleMod;
    public int UpgradeToo;
    public int UpgradeCost;
    public int UpgradeXP;
    public int AARange;
    public int BlowBridgePts;
    public int KilltoRetreatChance;
    public int[] AIRoleScore;
    public int AIMobNeedScore;
    public int AntiSupply;
    public int AntiSupplySea;
    public int AntiSupplyRange;
    public int ReadinessLoss;
    public int KillIsRegVar;
    public bool FreeAir;
    public int SlotNumber;
    public int Ratio;
    public bool Unique;
    public int DepletingHitpointRule;
    public int StartCombatRound;
    public int EndCombatRound;
    public int AirAPRule;
    public int ReinforcementType;
    public int ReinforcementType2;
    public int ReinforcementType3;
    public bool DontReturnFromHQ;
    public bool ConsiderCarry;
    public float FirstRoundPenaltyMod;
    public bool ModelIsBase;
    public int ModelLevel;
    public string ModelName;
    public int ModelMark;
    public int[] ModelLastState;
    public int ModelVersion;
    public int ModelID;
    public int[] ModelPossibleImp;
    public int ModelCostType;
    public int ModelCost;
    public float ModelCostPerLevel;
    public float ModelCostPerSameModel;
    public int ModelBaseModel;
    public int[] ModelResearch;
    public int ModelNewEvent;
    public int ModelNameList;
    public bool ModelAllowUpgrade;
    public int[] ModelImproveEvent;
    public bool ModelAllowImprovements;
    public float ModelImproveCostMod;
    public float ModelCostPerSameImp;
    public bool[] ModelAutoImprovement;
    public int ModelExtraResearch;
    public int ModelRegime;
    public bool ModelInitialForAll;
    public int ModelInitialEvent;
    public int ModelItemType;
    public float ModelSFTypeUpgrade;
    public int TempUpgradeCost;
    public int TempImproveCost;
    public int TempNewCost;
    public int TempFieldCount;
    public int TempNewLevels;
    public int TempUpgradeLevels;
    public int TempImprovementFields;
    public int TempAlterationCost;
    public int TempAlterationCount;
    public bool[] TempAlterationPossible;
    public float TempAvgCombatMatrixAtt;
    public float TempAvgCombatMatrixDef;
    public string[] LogoString;
    public int PreventCounter;
    public int[] PreventHitOn;
    public int[] PreventHitFrom;
    public int[] PreventChance;
    public int[] PreventPoints;
    public int[] PreventPriority;
    public int MaxPreventPointsUsed;
    public int MaxPreventPointsGiven;
    public int[] HitPoints;
    public int[] HitPointsDef;
    public int FuelRegimeVar;
    public int FuelForMove;
    public float OutOfFuelMove;
    public int FuelForAttack;
    public float OutOfFuelAttack;
    public float OutOfFuelDefense;
    public int FuelForAttackDef;
    public int SupplyForAttack;
    public float OutOfSupplyAttack;
    public float OutOfSupplyDefense;
    public int SupplyForAttackDef;
    public int FuelCarry;
    public int ModelVariantCounter;
    public string[] ModelVariantName;
    public int[] ModelVariantCheck;
    public int[] ModelVariantExec;
    public int[] artCode;
    public int[] SFTypeVar;
    public int ArtSFType;
    public int UsePeopleGraphics;
    public bool DontShowInList;
    public int StockpileUsedPerRound;
    public int StockpileMax;
    public int StockpileMaxIn;
    public float StockpileDepletedMod;
    public int SupplyMaxIn;
    public float ChanceOnDeathIfMakeHit;
    public int directRange;
    public int directModFirstHex;
    public int directModPerHex;
    public int heightLevelDiff;
    public int scrapable;
    public int manpower;
    public int manpowerCarry;
    public LibIdClass LibId;

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Name", (object) this.Name);
      info.AddValue("Description", (object) this.Description);
      info.AddValue("PicFileName", (object) this.PicFileName);
      info.AddValue("SymbolFileName", (object) this.SymbolFileName);
      info.AddValue("SymbolFileName2", (object) this.SymbolFileName2);
      info.AddValue("SymbolGroup", this.SymbolGroup);
      info.AddValue("SymbolWeight", this.SymbolWeight);
      info.AddValue("MoveType", this.MoveType);
      info.AddValue("SupplyCarry", this.SupplyCarry);
      info.AddValue("PeopleGroup", (object) this.PeopleGroup);
      info.AddValue("LandCap", this.Cap);
      info.AddValue("BasicSupplyNeed", this.BasicSupplyNeed);
      info.AddValue("UnitGroup", this.UnitGroup);
      info.AddValue("Theater", this.Theater);
      info.AddValue("Weight", this.Weight);
      info.AddValue("DefPower", this.DefPower);
      info.AddValue("Initiative", this.Initiative);
      info.AddValue("Attacks", this.Attacks);
      info.AddValue("MaxAttacked", this.MaxAttacked);
      info.AddValue("Frontage", this.Frontage);
      info.AddValue("Backbench", this.BackBench);
      info.AddValue("ArtRange", this.ArtRange);
      info.AddValue("FavTarget", (object) this.FavTarget);
      info.AddValue("FavTargetTries", this.FavTargetTries);
      info.AddValue("AttackPower", (object) this.AttackPower);
      info.AddValue("AttackPowerDef", (object) this.AttackPowerDef);
      info.AddValue("SymbolOverrule", this.SymbolOverrule);
      info.AddValue("DepletingHitpointRule", this.DepletingHitpointRule);
      info.AddValue("StartCombatRound", this.StartCombatRound);
      info.AddValue("EndCombatRound", this.EndCombatRound);
      info.AddValue("CarryCap", this.CarryCap);
      info.AddValue("EntrenchPower", this.EntrenchPower);
      info.AddValue("PowerPts", this.PowerPts);
      info.AddValue("ReconPts", this.ReconPts);
      info.AddValue("HidePts", this.HidePts);
      info.AddValue("ZOCPts", this.ZOCPts);
      info.AddValue("CanDoParadrop", this.CanDoParadrop);
      info.AddValue("AntiStrucPts", this.AntiStrucPts);
      info.AddValue("AirCarrierCap", this.AirCarrierCap);
      info.AddValue("ApMod", this.ApMod);
      info.AddValue("KillPercent", this.KillPercent);
      info.AddValue("EquipPercent", this.EquipPercent);
      info.AddValue("RetreatPercent", this.RetreatPercent);
      info.AddValue("InitiativeDef", this.InitiativeDef);
      info.AddValue("RdnLossPerAttack", this.RdnLossPerAttack);
      info.AddValue("AutoDestroy", this.AutoDestroy);
      info.AddValue("EP", this.EP);
      info.AddValue("MoveWAV", (object) this.MoveWAV);
      info.AddValue("BattleWAV", (object) this.BattleWAV);
      info.AddValue("CopyDataFrom", this.CopyDataFrom);
      info.AddValue("CopyDataFromBackup", this.CopyDataFromBackup);
      info.AddValue("CombatModAtt", (object) this.CombatModAtt);
      info.AddValue("CombatModDef", (object) this.CombatModDef);
      info.AddValue("StaffPts", this.StaffPts);
      info.AddValue("StaffMoraleMod", this.StaffMoraleMod);
      info.AddValue("StaffCombatMod", this.StaffCombatMod);
      info.AddValue("ÜpgradeToo", this.UpgradeToo);
      info.AddValue("UpgradeCost", this.UpgradeCost);
      info.AddValue("UpgradeXP", this.UpgradeXP);
      info.AddValue("MoveRedux", this.MoveRedux);
      info.AddValue("AARange", this.AARange);
      info.AddValue("FavArtTarget", (object) this.FavArtTarget);
      info.AddValue("AttackArt", (object) this.AttackArt);
      info.AddValue("BlowBridgePts", this.BlowBridgePts);
      info.AddValue("AIRoleScore", (object) this.AIRoleScore);
      info.AddValue("AIMobNeedScore", this.AIMobNeedScore);
      info.AddValue("KilltoRetreatChance", this.KilltoRetreatChance);
      info.AddValue("AntiSupply", this.AntiSupply);
      info.AddValue("AntiSupplySea", this.AntiSupplySea);
      info.AddValue("AntiSupplyRange", this.AntiSupplyRange);
      info.AddValue("ReadinessLoss", this.ReadinessLoss);
      info.AddValue("RailCap", this.RailCap);
      info.AddValue("KillIsRegVar", this.KillIsRegVar);
      info.AddValue("ExtraCounter", this.ExtraCounter);
      info.AddValue("ExtraPicFileName", (object) this.ExtraPicFileName);
      info.AddValue("ExtraSymbolFileName", (object) this.ExtraSymbolFileName);
      info.AddValue("ExtraSymbolFileName2", (object) this.ExtraSymbolFileName2);
      info.AddValue("ExtraCode", (object) this.ExtraCode);
      info.AddValue("AutoDestroy2", this.AutoDestroy2);
      info.AddValue("ExtraName", (object) this.ExtraName);
      info.AddValue("SlotNumber", this.SlotNumber);
      info.AddValue("FreeAir", this.FreeAir);
      info.AddValue("Ratio", this.Ratio);
      info.AddValue("ExtraRecon", (object) this.ExtraRecon);
      info.AddValue("Unique", this.Unique);
      info.AddValue("AirAPRule", this.AirAPRule);
      info.AddValue("ReinforcementType", this.ReinforcementType);
      info.AddValue("ReinforcementType2", this.ReinforcementType2);
      info.AddValue("ReinforcementType3", this.ReinforcementType3);
      info.AddValue("DontReturnFromHQ", this.DontReturnFromHQ);
      info.AddValue("ConsiderCarry", this.ConsiderCarry);
      info.AddValue("FirstRoundPenaltyMod", this.FirstRoundPenaltyMod);
      info.AddValue("rcount", this.ModelLastState.GetUpperBound(0));
      info.AddValue("ModelIsBase", this.ModelIsBase);
      info.AddValue("ModelLevel", this.ModelLevel);
      info.AddValue("ModelName", (object) this.ModelName);
      info.AddValue("ModelMark", this.ModelMark);
      info.AddValue("ModelLastState", (object) this.ModelLastState);
      info.AddValue("ModelVersion", this.ModelVersion);
      info.AddValue("ModelID", this.ModelID);
      info.AddValue("ModelPossibleImp", (object) this.ModelPossibleImp);
      info.AddValue("ModelCostType", this.ModelCostType);
      info.AddValue("ModelCost", this.ModelCost);
      info.AddValue("ModelCostPerLevel", this.ModelCostPerLevel);
      info.AddValue("ModelCostPerSameModel", this.ModelCostPerSameModel);
      info.AddValue("ModelBaseModel", this.ModelBaseModel);
      info.AddValue("ModelResearch", (object) this.ModelResearch);
      info.AddValue("ModelNewEvent", this.ModelNewEvent);
      info.AddValue("ModelNameList", this.ModelNameList);
      info.AddValue("ModelAllowUpgrade", this.ModelAllowUpgrade);
      info.AddValue("ModelImproveEvent", (object) this.ModelImproveEvent);
      info.AddValue("ModelAllowImprovements", this.ModelAllowImprovements);
      info.AddValue("ModelImproveCostMod", this.ModelImproveCostMod);
      info.AddValue("ModelCostPerSameImp", this.ModelCostPerSameImp);
      info.AddValue("ModelAutoImprovement", (object) this.ModelAutoImprovement);
      info.AddValue("ModelRegime", this.ModelRegime);
      info.AddValue("ModelInitialForAll", this.ModelInitialForAll);
      info.AddValue("ModelInitialEvent", this.ModelInitialEvent);
      info.AddValue("ModelItemType", this.ModelItemType);
      info.AddValue("LogoString", (object) this.LogoString);
      info.AddValue("PreventCounter", this.PreventCounter);
      info.AddValue("MaxPreventPointsUsed", this.MaxPreventPointsUsed);
      info.AddValue("MaxPreventPointsGiven", this.MaxPreventPointsGiven);
      info.AddValue("PreventHitOn", (object) this.PreventHitOn);
      info.AddValue("PreventHitFrom", (object) this.PreventHitFrom);
      info.AddValue("PreventPriority", (object) this.PreventPriority);
      info.AddValue("PreventChance", (object) this.PreventChance);
      info.AddValue("PreventPoints", (object) this.PreventPoints);
      info.AddValue("HitPoints", (object) this.HitPoints);
      info.AddValue("HitPointsDef", (object) this.HitPointsDef);
      info.AddValue("ModelExtraResearch", this.ModelExtraResearch);
      info.AddValue("FuelRegimeVar", this.FuelRegimeVar);
      info.AddValue("FuelForMove", this.FuelForMove);
      info.AddValue("OutOfFuelMove", this.OutOfFuelMove);
      info.AddValue("FuelForAttack", this.FuelForAttack);
      info.AddValue("OutOfFuelAttack", this.OutOfFuelAttack);
      info.AddValue("OutOfFuelDefense", this.OutOfFuelDefense);
      info.AddValue("FuelForAttackDef", this.FuelForAttackDef);
      info.AddValue("SupplyForAttack", this.SupplyForAttack);
      info.AddValue("OutOfSupplyAttack", this.OutOfSupplyAttack);
      info.AddValue("OutOfSupplyDefense", this.OutOfSupplyDefense);
      info.AddValue("SupplyForAttackDef", this.SupplyForAttackDef);
      info.AddValue("FuelCarry", this.FuelCarry);
      info.AddValue("ModelSFTypeUpgrade", this.ModelSFTypeUpgrade);
      info.AddValue("ModelVariantCounter", this.ModelVariantCounter);
      info.AddValue("ModelVariantCheck", (object) this.ModelVariantCheck);
      info.AddValue("ModelVariantExec", (object) this.ModelVariantExec);
      info.AddValue("ModelVariantName", (object) this.ModelVariantName);
      info.AddValue("SFTypeVar", (object) this.SFTypeVar);
      info.AddValue("artCode", (object) this.artCode);
      info.AddValue("ArtSFType", this.ArtSFType);
      info.AddValue("UsePeopleGraphics", this.UsePeopleGraphics);
      info.AddValue("SidewaysFileName", (object) this.SidewaysFileName);
      info.AddValue("DontShowInList", this.DontShowInList);
      info.AddValue("BaseColor", this.BaseColor);
      info.AddValue("ExtraSidewaysFileName", (object) this.ExtraSidewaysFileName);
      info.AddValue("ExtraSymbolColBigFileName", (object) this.ExtraSymbolColBigFileName);
      info.AddValue("SymbolColBigFileName", (object) this.SymbolColBigFileName);
      info.AddValue("ExtraSymbolColBigFileName2", (object) this.ExtraSymbolColBigFileName2);
      info.AddValue("SymbolColBigFileName2", (object) this.SymbolColBigFileName2);
      info.AddValue("StockpileUsedPerRound", this.StockpileUsedPerRound);
      info.AddValue("StockpileMax", this.StockpileMax);
      info.AddValue("StockpileMaxIn", this.StockpileMaxIn);
      info.AddValue("SupplyMaxIn", this.SupplyMaxIn);
      info.AddValue("StockpileDepletedMod", this.StockpileDepletedMod);
      info.AddValue("ChanceOnDeathIfMakeHit", this.ChanceOnDeathIfMakeHit);
      info.AddValue("LibId", (object) this.LibId);
      info.AddValue("Id", this.Id);
      info.AddValue("heightLevelDiff", this.heightLevelDiff);
      info.AddValue("directRange", this.directRange);
      info.AddValue("directModFirstHex", this.directModFirstHex);
      info.AddValue("directModPerHex", this.directModPerHex);
      info.AddValue("targettedByRangedChance", this.targettedByRangedChance);
      info.AddValue("scrapable", this.scrapable);
    }

    protected SFTypeClass(SerializationInfo info, StreamingContext context)
    {
      this.ExtraPicFileName = new string[1];
      this.ExtraPicSpriteID = new int[1];
      this.ExtraSidewaysFileName = new string[1];
      this.ExtraSidewaysSpriteID = new int[1];
      this.ExtraSymbolFileName = new string[1];
      this.ExtraSymbolSpriteID = new int[1];
      this.ExtraSymbolFileName2 = new string[1];
      this.ExtraSymbolSprite2ID = new int[1];
      this.ExtraSymbolColBigFileName = new string[1];
      this.ExtraSymbolColBigSpriteID = new int[1];
      this.ExtraSymbolColBigFileName2 = new string[1];
      this.ExtraSymbolColBigSprite2ID = new int[1];
      this.ExtraCode = new int[1];
      this.ExtraName = new string[1];
      this.PeopleGroup = new bool[100];
      this.FavTarget = new int[100];
      this.FavArtTarget = new int[100];
      this.AttackPower = new int[100];
      this.AttackPowerDef = new int[100];
      this.AttackArt = new object[100];
      this.CombatModAtt = new float[1];
      this.CombatModDef = new float[1];
      this.ExtraRecon = new int[1];
      this.AIRoleScore = new int[50];
      this.ModelLastState = new int[2];
      this.ModelPossibleImp = new int[2];
      this.ModelResearch = new int[10];
      this.ModelImproveEvent = new int[2];
      this.ModelAutoImprovement = new bool[2];
      this.TempAlterationPossible = new bool[2];
      this.LogoString = new string[100];
      this.PreventHitOn = new int[2];
      this.PreventHitFrom = new int[2];
      this.PreventChance = new int[2];
      this.PreventPoints = new int[2];
      this.PreventPriority = new int[2];
      this.HitPoints = new int[100];
      this.HitPointsDef = new int[100];
      this.ModelVariantName = new string[1];
      this.ModelVariantCheck = new int[1];
      this.ModelVariantExec = new int[1];
      this.artCode = new int[10];
      this.SFTypeVar = new int[100];
      this.Name = info.GetString(nameof (Name));
      this.Description = info.GetString(nameof (Description));
      this.PicFileName = info.GetString(nameof (PicFileName));
      this.SymbolFileName = info.GetString(nameof (SymbolFileName));
      try
      {
        this.SymbolFileName2 = info.GetString(nameof (SymbolFileName2));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.SymbolFileName2 = this.SymbolFileName;
        ProjectData.ClearProjectError();
      }
      this.SymbolGroup = info.GetInt32(nameof (SymbolGroup));
      this.SymbolWeight = info.GetInt32(nameof (SymbolWeight));
      this.MoveType = info.GetInt32(nameof (MoveType));
      this.SupplyCarry = info.GetInt32(nameof (SupplyCarry));
      this.PeopleGroup = (bool[]) info.GetValue(nameof (PeopleGroup), this.PeopleGroup.GetType());
      this.PeopleGroup = (bool[]) Utils.CopyArray((Array) this.PeopleGroup, (Array) new bool[100]);
      this.Cap = info.GetInt32("LandCap");
      this.BasicSupplyNeed = info.GetInt32(nameof (BasicSupplyNeed));
      this.UnitGroup = info.GetInt32(nameof (UnitGroup));
      this.Theater = info.GetInt32(nameof (Theater));
      this.Weight = info.GetInt32(nameof (Weight));
      this.DefPower = info.GetInt32(nameof (DefPower));
      this.Initiative = info.GetInt32(nameof (Initiative));
      this.Attacks = info.GetInt32(nameof (Attacks));
      this.MaxAttacked = info.GetInt32(nameof (MaxAttacked));
      this.Frontage = info.GetInt32(nameof (Frontage));
      this.BackBench = (uint) info.GetInt32("Backbench") > 0U;
      this.ArtRange = info.GetInt32(nameof (ArtRange));
      this.FavTarget = (int[]) info.GetValue(nameof (FavTarget), this.FavTarget.GetType());
      this.FavTarget = (int[]) Utils.CopyArray((Array) this.FavTarget, (Array) new int[100]);
      this.FavTargetTries = info.GetInt32(nameof (FavTargetTries));
      this.AttackPower = (int[]) info.GetValue(nameof (AttackPower), this.AttackPower.GetType());
      this.AttackPower = (int[]) Utils.CopyArray((Array) this.AttackPower, (Array) new int[100]);
      this.AttackPowerDef = (int[]) info.GetValue(nameof (AttackPowerDef), this.AttackPowerDef.GetType());
      this.AttackPowerDef = (int[]) Utils.CopyArray((Array) this.AttackPowerDef, (Array) new int[100]);
      this.SymbolOverrule = info.GetBoolean(nameof (SymbolOverrule));
      this.CarryCap = info.GetInt32(nameof (CarryCap));
      this.EntrenchPower = info.GetInt32(nameof (EntrenchPower));
      this.PowerPts = info.GetInt32(nameof (PowerPts));
      this.ReconPts = info.GetInt32(nameof (ReconPts));
      this.HidePts = info.GetInt32(nameof (HidePts));
      this.ZOCPts = info.GetInt32(nameof (ZOCPts));
      this.CanDoParadrop = info.GetBoolean(nameof (CanDoParadrop));
      this.AntiStrucPts = info.GetInt32(nameof (AntiStrucPts));
      this.AirCarrierCap = info.GetInt32(nameof (AirCarrierCap));
      this.ApMod = info.GetSingle(nameof (ApMod));
      this.KillPercent = info.GetInt32(nameof (KillPercent));
      this.RetreatPercent = info.GetInt32(nameof (RetreatPercent));
      this.EquipPercent = info.GetInt32(nameof (EquipPercent));
      this.InitiativeDef = info.GetInt32(nameof (InitiativeDef));
      this.RdnLossPerAttack = info.GetInt32(nameof (RdnLossPerAttack));
      this.AutoDestroy = info.GetBoolean(nameof (AutoDestroy));
      this.CombatModAtt = (float[]) info.GetValue(nameof (CombatModAtt), this.CombatModAtt.GetType());
      this.CombatModDef = (float[]) info.GetValue(nameof (CombatModDef), this.CombatModDef.GetType());
      if (DrawMod.TGame.Data.Version < 158)
      {
        try
        {
          this.AutoDestroy2 = info.GetBoolean(nameof (AutoDestroy2));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.AutoDestroy2 = false;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.ExtraRecon = (int[]) info.GetValue(nameof (ExtraRecon), this.ExtraRecon.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.ExtraRecon = new int[this.CombatModDef.GetUpperBound(0) + 1];
          ProjectData.ClearProjectError();
        }
      }
      else
      {
        this.AutoDestroy2 = info.GetBoolean(nameof (AutoDestroy2));
        this.ExtraRecon = (int[]) info.GetValue(nameof (ExtraRecon), this.ExtraRecon.GetType());
      }
      if (this.ExtraRecon.GetUpperBound(0) == 0)
        this.ExtraRecon = new int[this.CombatModDef.GetUpperBound(0) + 1];
      this.EP = info.GetInt32(nameof (EP));
      this.MoveWAV = info.GetString(nameof (MoveWAV));
      this.BattleWAV = info.GetString(nameof (BattleWAV));
      this.CopyDataFrom = info.GetInt32(nameof (CopyDataFrom));
      try
      {
        this.CopyDataFromBackup = info.GetInt32(nameof (CopyDataFromBackup));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.CopyDataFromBackup = -1;
        ProjectData.ClearProjectError();
      }
      this.StaffPts = info.GetInt32(nameof (StaffPts));
      this.StaffCombatMod = info.GetSingle(nameof (StaffCombatMod));
      this.StaffMoraleMod = info.GetSingle(nameof (StaffMoraleMod));
      this.UpgradeToo = info.GetInt32("ÜpgradeToo");
      this.UpgradeCost = info.GetInt32(nameof (UpgradeCost));
      this.UpgradeXP = info.GetInt32(nameof (UpgradeXP));
      this.MoveRedux = info.GetInt32(nameof (MoveRedux));
      this.AARange = info.GetInt32(nameof (AARange));
      this.FavArtTarget = (int[]) info.GetValue(nameof (FavArtTarget), this.FavArtTarget.GetType());
      this.AttackArt = (object[]) info.GetValue(nameof (AttackArt), this.AttackArt.GetType());
      this.AIRoleScore = (int[]) info.GetValue(nameof (AIRoleScore), this.AIRoleScore.GetType());
      this.AIMobNeedScore = info.GetInt32(nameof (AIMobNeedScore));
      this.BlowBridgePts = info.GetInt32(nameof (BlowBridgePts));
      this.KilltoRetreatChance = info.GetInt32(nameof (KilltoRetreatChance));
      this.AntiSupply = info.GetInt32(nameof (AntiSupply));
      this.AntiSupplyRange = info.GetInt32(nameof (AntiSupplyRange));
      this.AntiSupplySea = info.GetInt32(nameof (AntiSupplySea));
      this.ReadinessLoss = info.GetInt32(nameof (ReadinessLoss));
      this.RailCap = info.GetInt32(nameof (RailCap));
      this.KillIsRegVar = info.GetInt32(nameof (KillIsRegVar));
      int index1 = 0;
      do
      {
        if (Information.IsNothing(RuntimeHelpers.GetObjectValue(this.AttackArt[index1])))
          this.AttackArt[index1] = (object) 0;
        ++index1;
      }
      while (index1 <= 99);
      this.ExtraCounter = info.GetInt32(nameof (ExtraCounter));
      if (this.ExtraCounter > -1)
      {
        this.ExtraPicFileName = new string[this.ExtraCounter + 1];
        this.ExtraPicSpriteID = new int[this.ExtraCounter + 1];
        this.ExtraSymbolFileName = new string[this.ExtraCounter + 1];
        this.ExtraSymbolSpriteID = new int[this.ExtraCounter + 1];
        this.ExtraSymbolFileName2 = new string[this.ExtraCounter + 1];
        this.ExtraSymbolSprite2ID = new int[this.ExtraCounter + 1];
        this.ExtraCode = new int[this.ExtraCounter + 1];
        this.ExtraName = new string[this.ExtraCounter + 1];
        this.ExtraSidewaysFileName = new string[this.ExtraCounter + 1];
        this.ExtraSidewaysSpriteID = new int[this.ExtraCounter + 1];
        this.ExtraSymbolColBigFileName = new string[this.ExtraCounter + 1];
        this.ExtraSymbolColBigSpriteID = new int[this.ExtraCounter + 1];
        this.ExtraSymbolColBigFileName2 = new string[this.ExtraCounter + 1];
        this.ExtraSymbolColBigSprite2ID = new int[this.ExtraCounter + 1];
        this.ExtraPicFileName = (string[]) info.GetValue(nameof (ExtraPicFileName), this.ExtraPicFileName.GetType());
        this.ExtraSymbolFileName = (string[]) info.GetValue(nameof (ExtraSymbolFileName), this.ExtraSymbolFileName.GetType());
        this.ExtraCode = (int[]) info.GetValue(nameof (ExtraCode), this.ExtraCode.GetType());
        if (DrawMod.TGame.Data.Version < 130)
        {
          int extraCounter1 = this.ExtraCounter;
          for (int index2 = 0; index2 <= extraCounter1; ++index2)
            this.ExtraName[index2] = this.Name;
          int extraCounter2 = this.ExtraCounter;
          for (int index3 = 0; index3 <= extraCounter2; ++index3)
          {
            this.ExtraSymbolFileName2 = (string[]) this.ExtraSymbolFileName.Clone();
            this.ExtraSidewaysFileName = (string[]) this.ExtraPicFileName.Clone();
            this.ExtraSymbolColBigFileName[index3] = "systemgraphics/trans.bmp";
            this.ExtraSymbolColBigFileName2[index3] = "systemgraphics/trans.bmp";
          }
        }
        else
        {
          try
          {
            this.ExtraSymbolFileName2 = (string[]) info.GetValue(nameof (ExtraSymbolFileName2), this.ExtraSymbolFileName2.GetType());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.ExtraSymbolFileName2 = (string[]) this.ExtraSymbolFileName.Clone();
            ProjectData.ClearProjectError();
          }
          try
          {
            this.ExtraSidewaysFileName = (string[]) info.GetValue(nameof (ExtraSidewaysFileName), this.ExtraSidewaysFileName.GetType());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.ExtraSidewaysFileName = (string[]) this.ExtraPicFileName.Clone();
            ProjectData.ClearProjectError();
          }
          try
          {
            this.ExtraSymbolColBigFileName = (string[]) info.GetValue(nameof (ExtraSymbolColBigFileName), this.ExtraSymbolColBigFileName.GetType());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            int extraCounter = this.ExtraCounter;
            for (int index4 = 0; index4 <= extraCounter; ++index4)
              this.ExtraSymbolColBigFileName[index4] = "systemgraphics/trans.bmp";
            ProjectData.ClearProjectError();
          }
          try
          {
            this.ExtraSymbolColBigFileName2 = (string[]) info.GetValue(nameof (ExtraSymbolColBigFileName2), this.ExtraSymbolColBigFileName2.GetType());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            int extraCounter = this.ExtraCounter;
            for (int index5 = 0; index5 <= extraCounter; ++index5)
              this.ExtraSymbolColBigFileName2[index5] = "systemgraphics/trans.bmp";
            ProjectData.ClearProjectError();
          }
          if (DrawMod.TGame.Data.Version < 158)
          {
            try
            {
              this.ExtraName = (string[]) info.GetValue(nameof (ExtraName), this.ExtraName.GetType());
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              int extraCounter = this.ExtraCounter;
              for (int index6 = 0; index6 <= extraCounter; ++index6)
                this.ExtraName[index6] = this.Name;
              ProjectData.ClearProjectError();
            }
          }
          else
            this.ExtraName = (string[]) info.GetValue(nameof (ExtraName), this.ExtraName.GetType());
        }
      }
      else
      {
        this.ExtraPicFileName = new string[1];
        this.ExtraPicSpriteID = new int[1];
        this.ExtraSymbolFileName = new string[1];
        this.ExtraSymbolSpriteID = new int[1];
        this.ExtraSymbolColBigFileName = new string[1];
        this.ExtraSymbolColBigSpriteID = new int[1];
        this.ExtraSymbolColBigFileName2 = new string[1];
        this.ExtraSymbolColBigSprite2ID = new int[1];
        this.ExtraCode = new int[1];
        this.ExtraName = new string[1];
        this.ExtraSidewaysFileName = new string[1];
        this.ExtraSidewaysSpriteID = new int[1];
      }
      int index7 = 0;
      do
      {
        this.HitPoints[index7] = this.DefPower;
        ++index7;
      }
      while (index7 <= 99);
      int index8 = 0;
      do
      {
        this.HitPointsDef[index8] = this.HitPoints[index8];
        ++index8;
      }
      while (index8 <= 99);
      if (DrawMod.TGame.Data.Version < 130)
      {
        this.ConsiderCarry = false;
        this.FreeAir = false;
        this.SlotNumber = -1;
        this.Ratio = 1;
        this.Unique = false;
        this.AirAPRule = -1;
        this.ReinforcementType = -1;
        this.ReinforcementType2 = -1;
        this.ReinforcementType3 = -1;
        this.DontReturnFromHQ = false;
        int index9 = 0;
        do
        {
          this.ModelResearch[index9] = -1;
          ++index9;
        }
        while (index9 <= 9);
        this.ArtSFType = -1;
        int index10 = 0;
        do
        {
          this.HitPointsDef[index10] = this.HitPoints[index10];
          ++index10;
        }
        while (index10 <= 99);
        this.FuelRegimeVar = -1;
        this.OutOfSupplyAttack = 1f;
        this.OutOfFuelDefense = 1f;
        this.OutOfFuelMove = 1f;
        this.OutOfFuelAttack = 1f;
        this.OutOfFuelDefense = 1f;
        this.UsePeopleGraphics = 0;
        this.ArtSFType = -1;
        this.SidewaysFileName = "systemgraphics/trans.bmp";
        this.FirstRoundPenaltyMod = 1f;
        this.ModelRegime = -1;
        this.ModelInitialEvent = -1;
        this.ModelItemType = -1;
        this.ModelInitialForAll = false;
        this.ModelExtraResearch = -1;
        this.LogoString = new string[100];
        this.PreventCounter = -1;
        this.ModelSFTypeUpgrade = 1f;
        this.ModelVariantCounter = -1;
        this.ModelVariantName = new string[1];
        this.ModelVariantExec = new int[1];
        this.ModelVariantCheck = new int[1];
        this.SFTypeVar = new int[100];
        this.ArtSFType = -1;
        this.UsePeopleGraphics = 0;
        this.SidewaysFileName = "systemgraphics/trans.bmp";
        this.SymbolColBigFileName = "systemgraphics/trans.bmp";
        this.SymbolColBigFileName2 = "systemgraphics/trans.bmp";
        this.DontShowInList = false;
        this.artCode = new int[10];
      }
      else if (DrawMod.TGame.Data.Version < 162)
      {
        try
        {
          this.ConsiderCarry = info.GetBoolean(nameof (ConsiderCarry));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.ConsiderCarry = false;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.SlotNumber = info.GetInt32(nameof (SlotNumber));
          this.FreeAir = info.GetBoolean(nameof (FreeAir));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.FreeAir = false;
          this.SlotNumber = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.Ratio = info.GetInt32(nameof (Ratio));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.Ratio = 1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.Unique = info.GetBoolean(nameof (Unique));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.Unique = false;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.AirAPRule = info.GetInt32(nameof (AirAPRule));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.AirAPRule = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.ReinforcementType = info.GetInt32(nameof (ReinforcementType));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.ReinforcementType = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.ReinforcementType2 = info.GetInt32(nameof (ReinforcementType2));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.ReinforcementType2 = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.ReinforcementType3 = info.GetInt32(nameof (ReinforcementType3));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.ReinforcementType3 = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.DontReturnFromHQ = info.GetBoolean(nameof (DontReturnFromHQ));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.DontReturnFromHQ = false;
          ProjectData.ClearProjectError();
        }
        int index11 = 0;
        do
        {
          this.ModelResearch[index11] = -1;
          ++index11;
        }
        while (index11 <= 9);
        this.ArtSFType = -1;
        int index12 = 0;
        do
        {
          this.HitPointsDef[index12] = this.HitPoints[index12];
          ++index12;
        }
        while (index12 <= 99);
        this.FuelRegimeVar = -1;
        this.OutOfSupplyAttack = 1f;
        this.OutOfSupplyDefense = 1f;
        this.OutOfFuelMove = 1f;
        this.OutOfFuelAttack = 1f;
        this.OutOfFuelDefense = 1f;
        this.UsePeopleGraphics = 0;
        this.ArtSFType = -1;
        this.SidewaysFileName = "systemgraphics/trans.bmp";
        this.FirstRoundPenaltyMod = 1f;
        this.ModelRegime = -1;
        this.ModelInitialEvent = -1;
        this.ModelItemType = -1;
        this.ModelInitialForAll = false;
        this.ModelExtraResearch = -1;
        this.LogoString = new string[100];
        this.PreventCounter = -1;
        this.ModelSFTypeUpgrade = 1f;
        this.ModelVariantCounter = -1;
        this.ModelVariantName = new string[1];
        this.ModelVariantExec = new int[1];
        this.ModelVariantCheck = new int[1];
        this.SFTypeVar = new int[100];
        this.ArtSFType = -1;
        this.UsePeopleGraphics = 0;
        this.SidewaysFileName = "systemgraphics/trans.bmp";
        this.SymbolColBigFileName = "systemgraphics/trans.bmp";
        this.SymbolColBigFileName2 = "systemgraphics/trans.bmp";
        this.DontShowInList = false;
        this.artCode = new int[10];
      }
      else
      {
        this.ConsiderCarry = info.GetBoolean(nameof (ConsiderCarry));
        this.SlotNumber = info.GetInt32(nameof (SlotNumber));
        this.FreeAir = info.GetBoolean(nameof (FreeAir));
        this.Ratio = info.GetInt32(nameof (Ratio));
        this.Unique = info.GetBoolean(nameof (Unique));
        this.AirAPRule = info.GetInt32(nameof (AirAPRule));
        this.ReinforcementType = info.GetInt32(nameof (ReinforcementType));
        try
        {
          this.ReinforcementType2 = info.GetInt32(nameof (ReinforcementType2));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.ReinforcementType2 = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.ReinforcementType3 = info.GetInt32(nameof (ReinforcementType3));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.ReinforcementType3 = -1;
          ProjectData.ClearProjectError();
        }
        this.DontReturnFromHQ = info.GetBoolean(nameof (DontReturnFromHQ));
        try
        {
          this.FirstRoundPenaltyMod = info.GetSingle(nameof (FirstRoundPenaltyMod));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.FirstRoundPenaltyMod = 1f;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.ChanceOnDeathIfMakeHit = info.GetSingle(nameof (ChanceOnDeathIfMakeHit));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.ChanceOnDeathIfMakeHit = 0.0f;
          ProjectData.ClearProjectError();
        }
        try
        {
          index8 = info.GetInt32("rcount");
          this.ModelLastState = new int[index8 + 1];
          this.ModelPossibleImp = new int[index8 + 1];
          this.ModelImproveEvent = new int[index8 + 1];
          this.ModelIsBase = info.GetBoolean(nameof (ModelIsBase));
          this.ModelLevel = info.GetInt32(nameof (ModelLevel));
          this.ModelName = info.GetString(nameof (ModelName));
          this.ModelMark = info.GetInt32(nameof (ModelMark));
          this.ModelLastState = (int[]) info.GetValue(nameof (ModelLastState), this.ModelLastState.GetType());
          this.ModelVersion = info.GetInt32(nameof (ModelVersion));
          this.ModelID = info.GetInt32(nameof (ModelID));
          this.ModelPossibleImp = (int[]) info.GetValue(nameof (ModelPossibleImp), this.ModelPossibleImp.GetType());
          this.ModelCostType = info.GetInt32(nameof (ModelCostType));
          this.ModelCost = info.GetInt32(nameof (ModelCost));
          this.ModelCostPerLevel = info.GetSingle(nameof (ModelCostPerLevel));
          this.ModelCostPerSameModel = info.GetSingle(nameof (ModelCostPerSameModel));
          this.ModelBaseModel = info.GetInt32(nameof (ModelBaseModel));
          this.ModelResearch = (int[]) info.GetValue(nameof (ModelResearch), this.ModelResearch.GetType());
          this.ModelNewEvent = info.GetInt32(nameof (ModelNewEvent));
          this.ModelNameList = info.GetInt32(nameof (ModelNameList));
          this.ModelAllowUpgrade = info.GetBoolean(nameof (ModelAllowUpgrade));
          this.ModelImproveEvent = (int[]) info.GetValue(nameof (ModelImproveEvent), this.ModelImproveEvent.GetType());
          this.ModelAllowImprovements = info.GetBoolean(nameof (ModelAllowImprovements));
          this.ModelImproveCostMod = info.GetSingle(nameof (ModelImproveCostMod));
          this.ModelCostPerSameImp = info.GetSingle(nameof (ModelCostPerSameImp));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int index13 = 0;
          do
          {
            this.ModelResearch[index13] = -1;
            ++index13;
          }
          while (index13 <= 9);
          ProjectData.ClearProjectError();
        }
        try
        {
          this.ModelRegime = info.GetInt32(nameof (ModelRegime));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.ModelRegime = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.ModelAutoImprovement = new bool[index8 + 1];
          this.ModelAutoImprovement = (bool[]) info.GetValue(nameof (ModelAutoImprovement), this.ModelAutoImprovement.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
        try
        {
          this.ModelInitialForAll = info.GetBoolean(nameof (ModelInitialForAll));
          this.ModelInitialEvent = info.GetInt32(nameof (ModelInitialEvent));
          this.ModelItemType = info.GetInt32(nameof (ModelItemType));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.ModelInitialEvent = -1;
          this.ModelItemType = -1;
          this.ModelInitialForAll = false;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.ModelExtraResearch = info.GetInt32(nameof (ModelExtraResearch));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.ModelExtraResearch = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.LogoString = (string[]) info.GetValue(nameof (LogoString), this.LogoString.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.LogoString = new string[100];
          ProjectData.ClearProjectError();
        }
        try
        {
          this.PreventCounter = info.GetInt32(nameof (PreventCounter));
          this.MaxPreventPointsUsed = info.GetInt32(nameof (MaxPreventPointsUsed));
          this.MaxPreventPointsGiven = info.GetInt32(nameof (MaxPreventPointsGiven));
          this.PreventHitOn = new int[this.PreventCounter + 1];
          this.PreventHitFrom = new int[this.PreventCounter + 1];
          this.PreventPriority = new int[this.PreventCounter + 1];
          this.PreventChance = new int[this.PreventCounter + 1];
          this.PreventPoints = new int[this.PreventCounter + 1];
          this.PreventHitOn = (int[]) info.GetValue(nameof (PreventHitOn), this.PreventHitOn.GetType());
          this.PreventHitFrom = (int[]) info.GetValue(nameof (PreventHitFrom), this.PreventHitFrom.GetType());
          this.PreventPriority = (int[]) info.GetValue(nameof (PreventPriority), this.PreventPriority.GetType());
          this.PreventChance = (int[]) info.GetValue(nameof (PreventChance), this.PreventChance.GetType());
          this.PreventPoints = (int[]) info.GetValue(nameof (PreventPoints), this.PreventPoints.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.PreventCounter = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.HitPoints = (int[]) info.GetValue(nameof (HitPoints), this.HitPoints.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int index14 = 0;
          do
          {
            this.HitPoints[index14] = this.DefPower;
            ++index14;
          }
          while (index14 <= 99);
          ProjectData.ClearProjectError();
        }
        try
        {
          this.HitPointsDef = (int[]) info.GetValue(nameof (HitPointsDef), this.HitPointsDef.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int index15 = 0;
          do
          {
            this.HitPointsDef[index15] = this.HitPoints[index15];
            ++index15;
          }
          while (index15 <= 99);
          ProjectData.ClearProjectError();
        }
        try
        {
          this.FuelRegimeVar = info.GetInt32(nameof (FuelRegimeVar));
          this.FuelForMove = info.GetInt32(nameof (FuelForMove));
          this.OutOfFuelMove = info.GetSingle(nameof (OutOfFuelMove));
          this.FuelForAttack = info.GetInt32(nameof (FuelForAttack));
          this.OutOfFuelAttack = info.GetSingle(nameof (OutOfFuelAttack));
          this.OutOfFuelDefense = info.GetSingle(nameof (OutOfFuelDefense));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.FuelRegimeVar = -1;
          this.FuelForMove = 0;
          this.OutOfFuelMove = 1f;
          this.FuelForAttack = 0;
          this.OutOfFuelAttack = 1f;
          this.OutOfFuelDefense = 1f;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.FuelForAttackDef = info.GetInt32(nameof (FuelForAttackDef));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.FuelForAttackDef = 0;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.SupplyForAttackDef = info.GetInt32(nameof (SupplyForAttackDef));
          this.SupplyForAttack = info.GetInt32(nameof (SupplyForAttack));
          this.OutOfSupplyAttack = info.GetSingle(nameof (OutOfSupplyAttack));
          this.OutOfSupplyDefense = info.GetSingle(nameof (OutOfSupplyDefense));
          this.FuelCarry = info.GetInt32(nameof (FuelCarry));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.SupplyForAttackDef = 0;
          this.SupplyForAttack = 0;
          this.OutOfSupplyAttack = 1f;
          this.OutOfSupplyDefense = 1f;
          this.FuelCarry = 0;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.ModelSFTypeUpgrade = info.GetSingle(nameof (ModelSFTypeUpgrade));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.ModelSFTypeUpgrade = 1f;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.ModelVariantCounter = info.GetInt32(nameof (ModelVariantCounter));
          if (this.ModelVariantCounter > -1)
          {
            this.ModelVariantName = new string[this.ModelVariantCounter + 1];
            this.ModelVariantExec = new int[this.ModelVariantCounter + 1];
            this.ModelVariantCheck = new int[this.ModelVariantCounter + 1];
          }
          else
          {
            this.ModelVariantName = new string[1];
            this.ModelVariantExec = new int[1];
            this.ModelVariantCheck = new int[1];
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.ModelVariantCounter = -1;
          this.ModelVariantName = new string[1];
          this.ModelVariantExec = new int[1];
          this.ModelVariantCheck = new int[1];
          ProjectData.ClearProjectError();
        }
        try
        {
          this.ModelVariantName = (string[]) info.GetValue(nameof (ModelVariantName), this.ModelVariantName.GetType());
          this.ModelVariantCheck = (int[]) info.GetValue(nameof (ModelVariantCheck), this.ModelVariantCheck.GetType());
          this.ModelVariantExec = (int[]) info.GetValue(nameof (ModelVariantExec), this.ModelVariantExec.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
        try
        {
          this.SFTypeVar = (int[]) info.GetValue(nameof (SFTypeVar), this.SFTypeVar.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.SFTypeVar = new int[100];
          ProjectData.ClearProjectError();
        }
        try
        {
          this.artCode = (int[]) info.GetValue(nameof (artCode), this.artCode.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.artCode = new int[10];
          ProjectData.ClearProjectError();
        }
        try
        {
          this.ArtSFType = info.GetInt32(nameof (ArtSFType));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.ArtSFType = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.UsePeopleGraphics = info.GetInt32(nameof (UsePeopleGraphics));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.UsePeopleGraphics = 0;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.SidewaysFileName = info.GetString(nameof (SidewaysFileName));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.SidewaysFileName = "systemgraphics/trans.bmp";
          ProjectData.ClearProjectError();
        }
        try
        {
          this.SymbolColBigFileName = info.GetString(nameof (SymbolColBigFileName));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.SymbolColBigFileName = "systemgraphics/trans.bmp";
          ProjectData.ClearProjectError();
        }
        try
        {
          this.SymbolColBigFileName2 = info.GetString(nameof (SymbolColBigFileName2));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.SymbolColBigFileName2 = "systemgraphics/trans.bmp";
          ProjectData.ClearProjectError();
        }
        try
        {
          this.DontShowInList = info.GetBoolean(nameof (DontShowInList));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.DontShowInList = false;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.StockpileDepletedMod = info.GetSingle(nameof (StockpileDepletedMod));
          this.StockpileMax = info.GetInt32(nameof (StockpileMax));
          this.StockpileMaxIn = info.GetInt32(nameof (StockpileMaxIn));
          this.SupplyMaxIn = info.GetInt32(nameof (SupplyMaxIn));
          this.StockpileUsedPerRound = info.GetInt32(nameof (StockpileUsedPerRound));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
        try
        {
          this.DepletingHitpointRule = info.GetInt32(nameof (DepletingHitpointRule));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.DepletingHitpointRule = 0;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.StartCombatRound = info.GetInt32(nameof (StartCombatRound));
          this.EndCombatRound = info.GetInt32(nameof (EndCombatRound));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.StartCombatRound = 0;
          this.EndCombatRound = 0;
          ProjectData.ClearProjectError();
        }
      }
      try
      {
        this.LibId = new LibIdClass();
        this.LibId = (LibIdClass) info.GetValue(nameof (LibId), this.LibId.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.LibId = new LibIdClass();
        this.LibId.id = -1;
        this.LibId.libSlot = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.Id = info.GetInt32(nameof (Id));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Id = -1;
        ProjectData.ClearProjectError();
      }
      if (DrawMod.TGame.Data.Version < 130)
      {
        this.BaseColor = 0;
      }
      else
      {
        try
        {
          this.BaseColor = info.GetInt32(nameof (BaseColor));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.BaseColor = 0;
          ProjectData.ClearProjectError();
        }
      }
      try
      {
        this.heightLevelDiff = info.GetInt32(nameof (heightLevelDiff));
        this.directRange = info.GetInt32(nameof (directRange));
        this.directModFirstHex = info.GetInt32(nameof (directModFirstHex));
        this.directModPerHex = info.GetInt32(nameof (directModPerHex));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.directRange = 0;
        this.heightLevelDiff = 0;
        this.directModFirstHex = 0;
        this.directModPerHex = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.targettedByRangedChance = info.GetInt32(nameof (targettedByRangedChance));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.targettedByRangedChance = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.scrapable = info.GetInt32(nameof (scrapable));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.scrapable = 0;
        ProjectData.ClearProjectError();
      }
      if (this.Ratio != 0)
        return;
      this.Ratio = 1;
    }

    public SFTypeClass(int hardcoded, int ltcount, int rcount)
    {
      this.ExtraPicFileName = new string[1];
      this.ExtraPicSpriteID = new int[1];
      this.ExtraSidewaysFileName = new string[1];
      this.ExtraSidewaysSpriteID = new int[1];
      this.ExtraSymbolFileName = new string[1];
      this.ExtraSymbolSpriteID = new int[1];
      this.ExtraSymbolFileName2 = new string[1];
      this.ExtraSymbolSprite2ID = new int[1];
      this.ExtraSymbolColBigFileName = new string[1];
      this.ExtraSymbolColBigSpriteID = new int[1];
      this.ExtraSymbolColBigFileName2 = new string[1];
      this.ExtraSymbolColBigSprite2ID = new int[1];
      this.ExtraCode = new int[1];
      this.ExtraName = new string[1];
      this.PeopleGroup = new bool[100];
      this.FavTarget = new int[100];
      this.FavArtTarget = new int[100];
      this.AttackPower = new int[100];
      this.AttackPowerDef = new int[100];
      this.AttackArt = new object[100];
      this.CombatModAtt = new float[1];
      this.CombatModDef = new float[1];
      this.ExtraRecon = new int[1];
      this.AIRoleScore = new int[50];
      this.ModelLastState = new int[2];
      this.ModelPossibleImp = new int[2];
      this.ModelResearch = new int[10];
      this.ModelImproveEvent = new int[2];
      this.ModelAutoImprovement = new bool[2];
      this.TempAlterationPossible = new bool[2];
      this.LogoString = new string[100];
      this.PreventHitOn = new int[2];
      this.PreventHitFrom = new int[2];
      this.PreventChance = new int[2];
      this.PreventPoints = new int[2];
      this.PreventPriority = new int[2];
      this.HitPoints = new int[100];
      this.HitPointsDef = new int[100];
      this.ModelVariantName = new string[1];
      this.ModelVariantCheck = new int[1];
      this.ModelVariantExec = new int[1];
      this.artCode = new int[10];
      this.SFTypeVar = new int[100];
      this.ModelVariantCounter = -1;
      this.ArtSFType = -1;
      this.scrapable = 0;
      this.manpower = 0;
      this.manpowerCarry = 0;
      this.targettedByRangedChance = 0;
      this.LibId = new LibIdClass();
      this.SidewaysFileName = "systemgraphics/trans.bmp";
      this.Name = "Default SubFormation Type";
      this.PicFileName = "systemgraphics/trans.bmp";
      this.SymbolFileName = "systemgraphics/trans.bmp";
      this.SymbolFileName2 = "systemgraphics/trans.bmp";
      this.SymbolColBigFileName = "systemgraphics/trans.bmp";
      this.SymbolColBigFileName2 = "systemgraphics/trans.bmp";
      this.SymbolGroup = -1;
      this.FirstRoundPenaltyMod = 1f;
      this.SymbolWeight = 0;
      this.ModelExtraResearch = -1;
      this.CopyDataFrom = -1;
      this.CopyDataFromBackup = -1;
      this.KillIsRegVar = -1;
      this.ModelRegime = -1;
      this.PreventCounter = -1;
      this.ReinforcementType = -1;
      this.ReinforcementType2 = -1;
      this.ReinforcementType3 = -1;
      this.StaffPts = 0;
      this.ModelSFTypeUpgrade = 1f;
      this.ApMod = 1f;
      this.FuelRegimeVar = -1;
      this.FuelForMove = 0;
      this.OutOfFuelMove = 1f;
      this.FuelForAttack = 0;
      this.FuelForAttackDef = 0;
      this.SupplyForAttack = 0;
      this.SupplyForAttackDef = 0;
      this.OutOfSupplyAttack = 1f;
      this.OutOfSupplyDefense = 1f;
      this.OutOfFuelAttack = 1f;
      this.OutOfFuelDefense = 1f;
      this.DepletingHitpointRule = 0;
      this.StartCombatRound = 0;
      this.EndCombatRound = 0;
      int index1 = 0;
      do
      {
        this.PeopleGroup[index1] = false;
        ++index1;
      }
      while (index1 <= 19);
      if (ltcount > -1)
      {
        this.CombatModDef = new float[ltcount + 1];
        this.CombatModAtt = new float[ltcount + 1];
        this.ExtraRecon = new int[ltcount + 1];
        int num = ltcount;
        for (int index2 = 0; index2 <= num; ++index2)
        {
          this.CombatModDef[index2] = 1f;
          this.CombatModAtt[index2] = 1f;
          this.ExtraRecon[index2] = 0;
        }
      }
      int index3 = 0;
      do
      {
        this.AttackArt[index3] = (object) 0;
        ++index3;
      }
      while (index3 <= 99);
      this.UpgradeToo = -1;
      this.UpgradeCost = 0;
      this.UpgradeXP = 0;
      this.ExtraCounter = -1;
      this.SlotNumber = -1;
      this.AirAPRule = -1;
      this.Ratio = 1;
      if (rcount > -1)
      {
        this.ModelLastState = new int[rcount + 1];
        this.ModelPossibleImp = new int[rcount + 1];
        this.ModelImproveEvent = new int[rcount + 1];
        this.ModelAutoImprovement = new bool[rcount + 1];
      }
      int index4 = 0;
      do
      {
        this.ModelResearch[index4] = -1;
        ++index4;
      }
      while (index4 <= 9);
      this.ModelItemType = -1;
      this.ModelInitialEvent = -1;
      this.directRange = 0;
      this.directModFirstHex = 0;
      this.directModPerHex = 0;
      this.heightLevelDiff = 0;
    }

    public void AddResField()
    {
      this.ModelLastState = (int[]) Utils.CopyArray((Array) this.ModelLastState, (Array) new int[this.ModelLastState.GetUpperBound(0) + 1 + 1]);
      this.ModelPossibleImp = (int[]) Utils.CopyArray((Array) this.ModelPossibleImp, (Array) new int[this.ModelLastState.GetUpperBound(0) + 1 + 1]);
      this.ModelImproveEvent = (int[]) Utils.CopyArray((Array) this.ModelImproveEvent, (Array) new int[this.ModelLastState.GetUpperBound(0) + 1 + 1]);
      this.ModelAutoImprovement = (bool[]) Utils.CopyArray((Array) this.ModelAutoImprovement, (Array) new bool[this.ModelLastState.GetUpperBound(0) + 1 + 1]);
    }

    public void RemoveResField(int nr)
    {
      if (nr < this.ModelLastState.GetUpperBound(0))
      {
        int num1 = nr;
        int num2 = this.ModelLastState.GetUpperBound(0) - 1;
        for (int index = num1; index <= num2; ++index)
        {
          this.ModelLastState[index] = this.ModelLastState[index + 1];
          this.ModelPossibleImp[index] = this.ModelPossibleImp[index + 1];
          this.ModelImproveEvent[index] = this.ModelImproveEvent[index + 1];
        }
      }
      if (this.ModelLastState.GetUpperBound(0) <= 0)
        return;
      this.ModelLastState = (int[]) Utils.CopyArray((Array) this.ModelLastState, (Array) new int[this.ModelLastState.GetUpperBound(0) - 1 + 1]);
      this.ModelPossibleImp = (int[]) Utils.CopyArray((Array) this.ModelPossibleImp, (Array) new int[this.ModelPossibleImp.GetUpperBound(0) - 1 + 1]);
      this.ModelImproveEvent = (int[]) Utils.CopyArray((Array) this.ModelImproveEvent, (Array) new int[this.ModelImproveEvent.GetUpperBound(0) - 1 + 1]);
    }

    public SFTypeClass Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (SFTypeClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    public void ReplaceSymbolSprite(string s)
    {
      this.SymbolFileName = s;
      this.SymbolSpriteID = BitmapStore.ReloadFile(this.SymbolSpriteID, s, IsBig: true);
    }

    public void ReplaceColBigSymbolSprite(string s)
    {
      this.SymbolColBigFileName = s;
      this.SymbolColBigSpriteID = BitmapStore.ReloadFile(this.SymbolColBigSpriteID, s);
    }

    public void ReplaceColBigSymbolSprite2(string s)
    {
      this.SymbolColBigFileName2 = s;
      this.SymbolColBigSprite2ID = BitmapStore.ReloadFile(this.SymbolColBigSprite2ID, s);
    }

    public void ReplaceSymbolSprite2(string s)
    {
      this.SymbolFileName2 = s;
      this.SymbolSprite2ID = BitmapStore.ReloadFile(this.SymbolSprite2ID, s);
    }

    public void ReplacePicSprite(string s)
    {
      this.PicFileName = s;
      this.PicSpriteID = BitmapStore.ReloadFile(this.PicSpriteID, s);
    }

    public void ReplaceSidewaysSprite(string s)
    {
      this.SidewaysFileName = s;
      this.SidewaysSpriteID = BitmapStore.ReloadFile(this.SidewaysSpriteID, s);
    }

    public void Kill()
    {
      BitmapStore.RemoveBitmapNr(this.SymbolSpriteID);
      BitmapStore.RemoveBitmapNr(this.SymbolSprite2ID);
      BitmapStore.RemoveBitmapNr(this.PicSpriteID);
      BitmapStore.RemoveBitmapNr(this.SidewaysSpriteID);
      BitmapStore.RemoveBitmapNr(this.SymbolColBigSpriteID);
      BitmapStore.RemoveBitmapNr(this.SymbolColBigSprite2ID);
      int extraCounter = this.ExtraCounter;
      for (int index = 0; index <= extraCounter; ++index)
      {
        BitmapStore.RemoveBitmapNr(this.ExtraPicSpriteID[index]);
        BitmapStore.RemoveBitmapNr(this.ExtraSidewaysSpriteID[index]);
        BitmapStore.RemoveBitmapNr(this.ExtraSymbolSpriteID[index]);
        BitmapStore.RemoveBitmapNr(this.ExtraSymbolSprite2ID[index]);
        BitmapStore.RemoveBitmapNr(this.ExtraSymbolColBigSpriteID[index]);
        BitmapStore.RemoveBitmapNr(this.ExtraSymbolColBigSprite2ID[index]);
      }
    }

    public void LoadSprites()
    {
      this.SymbolSpriteID = BitmapStore.AddFile(this.SymbolFileName, false, true);
      this.SymbolSprite2ID = BitmapStore.AddFile(this.SymbolFileName2, false);
      this.PicSpriteID = BitmapStore.AddFile(this.PicFileName, false);
      this.SidewaysSpriteID = BitmapStore.AddFile(this.SidewaysFileName, false);
      this.SymbolColBigSpriteID = BitmapStore.AddFile(this.SymbolColBigFileName, false);
      this.SymbolColBigSprite2ID = BitmapStore.AddFile(this.SymbolColBigFileName2, false);
      int extraCounter = this.ExtraCounter;
      for (int index = 0; index <= extraCounter; ++index)
      {
        this.ExtraPicSpriteID[index] = BitmapStore.AddFile(this.ExtraPicFileName[index], false);
        this.ExtraSidewaysSpriteID[index] = BitmapStore.AddFile(this.ExtraSidewaysFileName[index], false);
        this.ExtraSymbolSpriteID[index] = BitmapStore.AddFile(this.ExtraSymbolFileName[index], false, true);
        this.ExtraSymbolSprite2ID[index] = BitmapStore.AddFile(this.ExtraSymbolFileName2[index], false);
        this.ExtraSymbolColBigSpriteID[index] = BitmapStore.AddFile(this.ExtraSymbolColBigFileName[index], false);
        this.ExtraSymbolColBigSprite2ID[index] = BitmapStore.AddFile(this.ExtraSymbolColBigFileName2[index], false);
      }
    }

    public void AddExtraSprite()
    {
      ++this.ExtraCounter;
      this.ExtraPicFileName = (string[]) Utils.CopyArray((Array) this.ExtraPicFileName, (Array) new string[this.ExtraCounter + 1]);
      this.ExtraPicSpriteID = (int[]) Utils.CopyArray((Array) this.ExtraPicSpriteID, (Array) new int[this.ExtraCounter + 1]);
      this.ExtraSidewaysFileName = (string[]) Utils.CopyArray((Array) this.ExtraSidewaysFileName, (Array) new string[this.ExtraCounter + 1]);
      this.ExtraSidewaysSpriteID = (int[]) Utils.CopyArray((Array) this.ExtraSidewaysSpriteID, (Array) new int[this.ExtraCounter + 1]);
      this.ExtraSymbolFileName = (string[]) Utils.CopyArray((Array) this.ExtraSymbolFileName, (Array) new string[this.ExtraCounter + 1]);
      this.ExtraSymbolFileName2 = (string[]) Utils.CopyArray((Array) this.ExtraSymbolFileName2, (Array) new string[this.ExtraCounter + 1]);
      this.ExtraSymbolSpriteID = (int[]) Utils.CopyArray((Array) this.ExtraSymbolSpriteID, (Array) new int[this.ExtraCounter + 1]);
      this.ExtraSymbolSprite2ID = (int[]) Utils.CopyArray((Array) this.ExtraSymbolSprite2ID, (Array) new int[this.ExtraCounter + 1]);
      this.ExtraSymbolColBigFileName = (string[]) Utils.CopyArray((Array) this.ExtraSymbolColBigFileName, (Array) new string[this.ExtraCounter + 1]);
      this.ExtraSymbolColBigSpriteID = (int[]) Utils.CopyArray((Array) this.ExtraSymbolColBigSpriteID, (Array) new int[this.ExtraCounter + 1]);
      this.ExtraSymbolColBigFileName2 = (string[]) Utils.CopyArray((Array) this.ExtraSymbolColBigFileName2, (Array) new string[this.ExtraCounter + 1]);
      this.ExtraSymbolColBigSprite2ID = (int[]) Utils.CopyArray((Array) this.ExtraSymbolColBigSprite2ID, (Array) new int[this.ExtraCounter + 1]);
      this.ExtraCode = (int[]) Utils.CopyArray((Array) this.ExtraCode, (Array) new int[this.ExtraCounter + 1]);
      this.ExtraName = (string[]) Utils.CopyArray((Array) this.ExtraName, (Array) new string[this.ExtraCounter + 1]);
      this.ExtraPicFileName[this.ExtraCounter] = this.PicFileName;
      this.ExtraPicSpriteID[this.ExtraCounter] = BitmapStore.AddFile(this.ExtraPicFileName[this.ExtraCounter], false);
      this.ExtraSidewaysFileName[this.ExtraCounter] = this.PicFileName;
      this.ExtraSidewaysSpriteID[this.ExtraCounter] = BitmapStore.AddFile(this.ExtraPicFileName[this.ExtraCounter], false);
      this.ExtraSymbolFileName[this.ExtraCounter] = this.SymbolFileName;
      this.ExtraSymbolSpriteID[this.ExtraCounter] = BitmapStore.AddFile(this.ExtraSymbolFileName[this.ExtraCounter], false, true);
      this.ExtraSymbolFileName2[this.ExtraCounter] = "systemgraphics/trans.bmp";
      this.ExtraSymbolSprite2ID[this.ExtraCounter] = BitmapStore.AddFile(this.ExtraSymbolFileName2[this.ExtraCounter], false);
      this.ExtraSymbolColBigFileName[this.ExtraCounter] = "systemgraphics/trans.bmp";
      this.ExtraSymbolColBigSpriteID[this.ExtraCounter] = BitmapStore.AddFile(this.ExtraSymbolColBigFileName[this.ExtraCounter], false);
      this.ExtraSymbolColBigFileName2[this.ExtraCounter] = "systemgraphics/trans.bmp";
      this.ExtraSymbolColBigSprite2ID[this.ExtraCounter] = BitmapStore.AddFile(this.ExtraSymbolColBigFileName2[this.ExtraCounter], false);
      int num1;
      if (this.ExtraCounter > 0)
      {
        num1 = 1;
        int num2 = this.ExtraCounter - 1;
        for (int index = 0; index <= num2; ++index)
        {
          if (this.ExtraCode[index] >= num1)
            num1 = this.ExtraCode[index] + 1;
        }
      }
      else
        num1 = 1;
      this.ExtraCode[this.ExtraCounter] = num1;
    }

    public void RemoveExtraSprite(int nr)
    {
      if (this.ExtraCounter > nr)
      {
        int num1 = nr;
        int num2 = this.ExtraCounter - 1;
        for (int index = num1; index <= num2; ++index)
        {
          this.ExtraPicFileName[nr] = this.ExtraPicFileName[nr + 1];
          this.ExtraPicSpriteID[nr] = this.ExtraPicSpriteID[nr + 1];
          this.ExtraSymbolFileName[nr] = this.ExtraSymbolFileName[nr + 1];
          this.ExtraSymbolFileName2[nr] = this.ExtraSymbolFileName2[nr + 1];
          this.ExtraSymbolSpriteID[nr] = this.ExtraSymbolSpriteID[nr + 1];
          this.ExtraSymbolSprite2ID[nr] = this.ExtraSymbolSprite2ID[nr + 1];
          this.ExtraSidewaysFileName[nr] = this.ExtraSidewaysFileName[nr + 1];
          this.ExtraSidewaysSpriteID[nr] = this.ExtraSidewaysSpriteID[nr + 1];
          this.ExtraSymbolColBigFileName[nr] = this.ExtraSymbolColBigFileName[nr + 1];
          this.ExtraSymbolColBigSpriteID[nr] = this.ExtraSymbolColBigSpriteID[nr + 1];
          this.ExtraSymbolColBigFileName2[nr] = this.ExtraSymbolColBigFileName2[nr + 1];
          this.ExtraSymbolColBigSprite2ID[nr] = this.ExtraSymbolColBigSprite2ID[nr + 1];
          this.ExtraCode[nr] = this.ExtraCode[nr + 1];
        }
        --this.ExtraCounter;
        this.ExtraPicFileName = (string[]) Utils.CopyArray((Array) this.ExtraPicFileName, (Array) new string[this.ExtraCounter + 1]);
        this.ExtraPicSpriteID = (int[]) Utils.CopyArray((Array) this.ExtraPicSpriteID, (Array) new int[this.ExtraCounter + 1]);
        this.ExtraSymbolFileName = (string[]) Utils.CopyArray((Array) this.ExtraSymbolFileName, (Array) new string[this.ExtraCounter + 1]);
        this.ExtraSymbolFileName2 = (string[]) Utils.CopyArray((Array) this.ExtraSymbolFileName2, (Array) new string[this.ExtraCounter + 1]);
        this.ExtraSymbolSpriteID = (int[]) Utils.CopyArray((Array) this.ExtraSymbolSpriteID, (Array) new int[this.ExtraCounter + 1]);
        this.ExtraSymbolSprite2ID = (int[]) Utils.CopyArray((Array) this.ExtraSymbolSprite2ID, (Array) new int[this.ExtraCounter + 1]);
        this.ExtraCode = (int[]) Utils.CopyArray((Array) this.ExtraCode, (Array) new int[this.ExtraCounter + 1]);
        this.ExtraSidewaysFileName = (string[]) Utils.CopyArray((Array) this.ExtraSidewaysFileName, (Array) new string[this.ExtraCounter + 1]);
        this.ExtraSidewaysSpriteID = (int[]) Utils.CopyArray((Array) this.ExtraSidewaysSpriteID, (Array) new int[this.ExtraCounter + 1]);
        this.ExtraSymbolColBigFileName = (string[]) Utils.CopyArray((Array) this.ExtraSymbolColBigFileName, (Array) new string[this.ExtraCounter + 1]);
        this.ExtraSymbolColBigSpriteID = (int[]) Utils.CopyArray((Array) this.ExtraSymbolColBigSpriteID, (Array) new int[this.ExtraCounter + 1]);
        this.ExtraSymbolColBigFileName2 = (string[]) Utils.CopyArray((Array) this.ExtraSymbolColBigFileName2, (Array) new string[this.ExtraCounter + 1]);
        this.ExtraSymbolColBigSprite2ID = (int[]) Utils.CopyArray((Array) this.ExtraSymbolColBigSprite2ID, (Array) new int[this.ExtraCounter + 1]);
      }
      else
      {
        --this.ExtraCounter;
        this.ExtraPicFileName = (string[]) Utils.CopyArray((Array) this.ExtraPicFileName, (Array) new string[this.ExtraCounter + 1]);
        this.ExtraPicSpriteID = (int[]) Utils.CopyArray((Array) this.ExtraPicSpriteID, (Array) new int[this.ExtraCounter + 1]);
        this.ExtraSymbolFileName = (string[]) Utils.CopyArray((Array) this.ExtraSymbolFileName, (Array) new string[this.ExtraCounter + 1]);
        this.ExtraSymbolFileName2 = (string[]) Utils.CopyArray((Array) this.ExtraSymbolFileName2, (Array) new string[this.ExtraCounter + 1]);
        this.ExtraSymbolSpriteID = (int[]) Utils.CopyArray((Array) this.ExtraSymbolSpriteID, (Array) new int[this.ExtraCounter + 1]);
        this.ExtraSymbolSprite2ID = (int[]) Utils.CopyArray((Array) this.ExtraSymbolSprite2ID, (Array) new int[this.ExtraCounter + 1]);
        this.ExtraCode = (int[]) Utils.CopyArray((Array) this.ExtraCode, (Array) new int[this.ExtraCounter + 1]);
        this.ExtraSidewaysFileName = (string[]) Utils.CopyArray((Array) this.ExtraSidewaysFileName, (Array) new string[this.ExtraCounter + 1]);
        this.ExtraSidewaysSpriteID = (int[]) Utils.CopyArray((Array) this.ExtraSidewaysSpriteID, (Array) new int[this.ExtraCounter + 1]);
        this.ExtraSymbolColBigFileName = (string[]) Utils.CopyArray((Array) this.ExtraSymbolColBigFileName, (Array) new string[this.ExtraCounter + 1]);
        this.ExtraSymbolColBigSpriteID = (int[]) Utils.CopyArray((Array) this.ExtraSymbolColBigSpriteID, (Array) new int[this.ExtraCounter + 1]);
        this.ExtraSymbolColBigFileName2 = (string[]) Utils.CopyArray((Array) this.ExtraSymbolColBigFileName2, (Array) new string[this.ExtraCounter + 1]);
        this.ExtraSymbolColBigSprite2ID = (int[]) Utils.CopyArray((Array) this.ExtraSymbolColBigSprite2ID, (Array) new int[this.ExtraCounter + 1]);
      }
    }

    public void ReplaceExtraPic(int nr, string filename)
    {
      this.ExtraPicFileName[nr] = filename;
      this.ExtraPicSpriteID[nr] = BitmapStore.ReloadFile(this.ExtraPicSpriteID[nr], this.ExtraPicFileName[nr]);
    }

    public void ReplaceExtraSideways(int nr, string filename)
    {
      this.ExtraSidewaysFileName[nr] = filename;
      this.ExtraSidewaysSpriteID[nr] = BitmapStore.ReloadFile(this.ExtraSidewaysSpriteID[nr], this.ExtraSidewaysFileName[nr]);
    }

    public void ReplaceExtraSymbol(int nr, string filename)
    {
      this.ExtraSymbolFileName[nr] = filename;
      this.ExtraSymbolSpriteID[nr] = BitmapStore.ReloadFile(this.ExtraSymbolSpriteID[nr], this.ExtraSymbolFileName[nr], IsBig: true);
    }

    public void ReplaceExtraColBigSymbol(int nr, string filename)
    {
      this.ExtraSymbolColBigFileName[nr] = filename;
      this.ExtraSymbolColBigSpriteID[nr] = BitmapStore.ReloadFile(this.ExtraSymbolColBigSpriteID[nr], this.ExtraSymbolColBigFileName[nr]);
    }

    public void ReplaceExtraColBigSymbol2(int nr, string filename)
    {
      this.ExtraSymbolColBigFileName2[nr] = filename;
      this.ExtraSymbolColBigSprite2ID[nr] = BitmapStore.ReloadFile(this.ExtraSymbolColBigSprite2ID[nr], this.ExtraSymbolColBigFileName2[nr]);
    }

    public void ReplaceExtraSymbol2(int nr, string filename)
    {
      this.ExtraSymbolFileName2[nr] = filename;
      this.ExtraSymbolSprite2ID[nr] = BitmapStore.ReloadFile(this.ExtraSymbolSprite2ID[nr], this.ExtraSymbolFileName2[nr]);
    }
  }
}
