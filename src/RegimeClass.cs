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
  public class RegimeClass : ISerializable
  {
    public string Name;
    public int id;
    public int Red;
    public int Green;
    public int Blue;
    public int Red2;
    public int Green2;
    public int Blue2;
    public int Red3;
    public int Green3;
    public int Blue3;
    public int Red4;
    public int Green4;
    public int Blue4;
    public int People;
    public int[] RegimeSlot;
    public int[] LastTempRegimeSlotPredict;
    public int[] TempRegimeSlotPredict;
    public int[] TempRegimeSlotIncrease;
    public int TempPPIncrease;
    public bool HQSpriteOverrule;
    public int BaseMorale;
    public int ResPts;
    public int ResFieldCounter;
    public bool[] ResField;
    public int RegimeCounter;
    public int[] RegimeRel;
    public int[] RegimeOffer;
    public int MapCount;
    public MapMatrix2[] HistoryOwner;
    public MapMatrix2[] HistoryForce;
    public MapMatrix2[] HistorySFType;
    public MapMatrix2[] HistoryHis;
    public MapMatrix2[] HistoryDepth;
    public MapMatrix2[] Trafic;
    public MapMatrix2[] Trafic2;
    public MapMatrix2[] AIVP;
    public MapMatrix2[] AIPower;
    public MapMatrix2[] AIDefense;
    public int AIStance;
    public MapMatrix2[] OldAINarrow;
    public int AIHelpMove;
    public int AIHelpCombat;
    public int AIHelpStrategic;
    public HistoryStepClass[] HistoryStep;
    public int HistoryStepCounter;
    public int MessCounter;
    public string[] MessString;
    public int[] MessBackPic;
    public int[] MessFrontPic;
    public string[] MessWav;
    public int[] MesStyle;
    public string[] MesNote;
    public string[] MesNote2;
    public string[] MesName;
    public int[] MesGroup;
    public bool[] MesHideFromStart;
    public bool[] MesHideFromTab;
    public int[] MesChosen;
    public bool AI;
    public int AIid;
    public bool Sleep;
    public string PassWord;
    public string UnitName;
    public int UnitNumber;
    public string HQName;
    public int HQNumber;
    public int[,] SLoss;
    public int[,] SKills;
    public int[,] SProd;
    public int[,] SPresent;
    public int[,,] LisPoints;
    public Bitmap HexBack;
    public int PlanCounter;
    public AIPlanClass[] PlanObj;
    public Bitmap TempCounter;
    public Bitmap TempCounterHigh;
    public Bitmap TempCounterBig;
    public Bitmap TempCounterBigHigh;
    public Bitmap TempCountersmall;
    public Bitmap TempCountersmallHigh;
    public Bitmap TempRegimeColor;
    public Bitmap TempRegimeColorSmall;
    public Bitmap TempRegimeColorBig;
    public bool DipBlock;
    public int SASSupplyLost;
    public int SASSupplyKilled;
    public int[] SASProdLost;
    public int[] SASKilled;
    public int AISavedPP;
    public float AIConservative;
    public int ProdBonus;
    public int ActionCardCounter;
    public int[] ActionCard;
    public int ActionCardHistoryCounter;
    public int[] ActionCardHistory;
    public int[] ActionCardHistoryRound;
    public int[,] ExtraStat;
    public string NationalIconSpriteName;
    public int NationalIconSprite;
    public string RoundelSpriteName;
    public int RoundelIconSprite;
    public string RoundelSpriteName2;
    public int RoundelIconSprite2;
    public string HQSpriteFileName;
    public int HQSpriteNr;
    public string HQSpriteFileName2;
    public int HQSpriteNr2;
    public string BannerSpriteFileName;
    public int BannerSpriteNr;
    public string BannerSpriteFileName2;
    public int BannerSpriteNr2;
    public string SymbolSpriteName;
    public int SymbolSpriteNr;
    public int ExtraGraphicUse;
    public int FirstRound;
    public bool LoadTransferUnit;
    public bool LoadTransferHistorical;
    public int LoadAreaSlot;
    public int LoadPerHex;
    public bool LoadResearchTransfer;
    public int RandomCode;
    public int LastVersion;
    public int OfficerPool;
    public int AIGroupCounter;
    public string[] AIGroupName;
    public int[] AIGroupType;
    public int[] AIGroupHis;
    public int[] AIGroupLastAttack;
    public int[] AIGroupLastDefend;
    public int[] AIGroupLastFollowUp;
    public int[] AIGroupLastFallBack;
    public int[] AICorpsTopGroup;
    public int UberRegime;
    public bool Mirror;
    public int Version;
    public string subVersion;
    public int PbemPlayer;
    public bool UseAlternateActionCardPics;
    public int FerryEffectivity;
    public bool hideFromList;
    public LibIdClass libId;
    public bool TempSelectable;
    public bool minimumDataUsage;

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
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

    public void AddPlan()
    {
      ++this.PlanCounter;
      this.PlanObj = (AIPlanClass[]) Utils.CopyArray((Array) this.PlanObj, (Array) new AIPlanClass[this.PlanCounter + 1]);
      this.PlanObj[this.PlanCounter] = new AIPlanClass();
    }

    public void RemovePlan(int nr)
    {
      if (nr < this.PlanCounter)
      {
        int num1 = nr;
        int num2 = this.PlanCounter - 1;
        for (int index = num1; index <= num2; ++index)
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
      int mapWidth = DrawMod.TGame.Data.MapWidth;
      int mapHeight = DrawMod.TGame.Data.MapHeight;
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
        this.libId = new LibIdClass();
        this.libId = (LibIdClass) info.GetValue("LibId", this.libId.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.libId = new LibIdClass();
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

    public RegimeClass Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (RegimeClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    public RegimeClass(
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
      this.Red = (int) byte.MaxValue;
      this.Green = 128;
      this.Blue = 0;
      this.subVersion = "";
      this.Red2 = (int) byte.MaxValue;
      this.Green2 = (int) byte.MaxValue;
      this.Blue2 = (int) byte.MaxValue;
      this.HQSpriteFileName = "systemgraphics/trans.bmp";
      this.HQSpriteFileName2 = "systemgraphics/trans.bmp";
      this.BannerSpriteFileName = "systemgraphics/trans.bmp";
      this.BannerSpriteFileName2 = "systemgraphics/trans.bmp";
      this.SymbolSpriteName = "systemgraphics/trans.bmp";
      int index1 = 0;
      do
      {
        this.RegimeSlot[index1] = -1;
        ++index1;
      }
      while (index1 <= 499);
      this.BaseMorale = 100;
      this.RegimeCounter = tregimecounter;
      this.RegimeRel = new int[this.RegimeCounter + 1];
      this.RegimeOffer = new int[this.RegimeCounter + 1];
      int regimeCounter = this.RegimeCounter;
      for (int index2 = 0; index2 <= regimeCounter; ++index2)
        this.RegimeRel[index2] = 1;
      this.ResFieldCounter = trescounter;
      this.ResField = new bool[this.ResFieldCounter + 1];
      int resFieldCounter = this.ResFieldCounter;
      for (int index3 = 0; index3 <= resFieldCounter; ++index3)
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
        int mapCount = this.MapCount;
        for (int index4 = 0; index4 <= mapCount; ++index4)
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
      this.libId = new LibIdClass();
    }

    public void AddMap(int w, int h)
    {
      ++this.MapCount;
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

    public void RemoveMap(int nr)
    {
      if (nr < this.MapCount)
      {
        int num1 = nr;
        int num2 = this.MapCount - 1;
        for (int index = num1; index <= num2; ++index)
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

    public void AddResField()
    {
      ++this.ResFieldCounter;
      this.ResField = (bool[]) Utils.CopyArray((Array) this.ResField, (Array) new bool[this.ResFieldCounter + 1]);
      this.ResField[this.ResFieldCounter] = false;
    }

    public void RemoveResField(int nr)
    {
      if (nr < this.ResFieldCounter)
      {
        int num1 = nr;
        int num2 = this.ResFieldCounter - 1;
        for (int index = num1; index <= num2; ++index)
          this.ResField[index] = this.ResField[index + 1];
      }
      --this.ResFieldCounter;
      if (this.ResFieldCounter <= -1)
        return;
      this.ResField = (bool[]) Utils.CopyArray((Array) this.ResField, (Array) new bool[this.ResFieldCounter + 1]);
    }

    public void AddRegime()
    {
      ++this.RegimeCounter;
      this.RegimeRel = (int[]) Utils.CopyArray((Array) this.RegimeRel, (Array) new int[this.RegimeCounter + 1]);
      this.RegimeOffer = (int[]) Utils.CopyArray((Array) this.RegimeOffer, (Array) new int[this.RegimeCounter + 1]);
      this.RegimeRel[this.RegimeCounter] = 1;
    }

    public void Removeregime(int nr)
    {
      if (nr < this.RegimeCounter)
      {
        int num1 = nr;
        int num2 = this.RegimeCounter - 1;
        for (int index = num1; index <= num2; ++index)
          this.RegimeRel[index] = this.RegimeRel[index + 1];
      }
      --this.RegimeCounter;
      if (this.RegimeCounter <= -1)
        return;
      this.RegimeRel = (int[]) Utils.CopyArray((Array) this.RegimeRel, (Array) new int[this.RegimeCounter + 1]);
    }

    public void AddActionCard(int nr)
    {
      ++this.ActionCardCounter;
      this.ActionCard = (int[]) Utils.CopyArray((Array) this.ActionCard, (Array) new int[this.ActionCardCounter + 1]);
      this.ActionCard[this.ActionCardCounter] = nr;
    }

    public void RemoveActionCard(int nr)
    {
      if (nr < this.ActionCardCounter)
      {
        int num1 = nr;
        int num2 = this.ActionCardCounter - 1;
        for (int index = num1; index <= num2; ++index)
          this.ActionCard[index] = this.ActionCard[index + 1];
      }
      --this.ActionCardCounter;
      if (this.ActionCardCounter <= -1)
        return;
      this.ActionCard = (int[]) Utils.CopyArray((Array) this.ActionCard, (Array) new int[this.ActionCardCounter + 1]);
    }

    public void AddActionCardHistory(int nr, int round)
    {
      ++this.ActionCardHistoryCounter;
      this.ActionCardHistory = (int[]) Utils.CopyArray((Array) this.ActionCardHistory, (Array) new int[this.ActionCardHistoryCounter + 1]);
      this.ActionCardHistoryRound = (int[]) Utils.CopyArray((Array) this.ActionCardHistoryRound, (Array) new int[this.ActionCardHistoryCounter + 1]);
      this.ActionCardHistory[this.ActionCardHistoryCounter] = nr;
      this.ActionCardHistoryRound[this.ActionCardHistoryCounter] = round;
    }

    public void RemoveActionCardHistory(int nr)
    {
      if (nr < this.ActionCardHistoryCounter)
      {
        int num1 = nr;
        int num2 = this.ActionCardHistoryCounter - 1;
        for (int index = num1; index <= num2; ++index)
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

    public void DoTempCounterBig() => this.DoTempCounterAnySize(1);

    public void DoTempCounter() => this.DoTempCounterAnySize(0);

    public void DoTempCounterSmall() => this.DoTempCounterAnySize(-1);

    public void doTempRegimeHighlight(bool lighter = false)
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
      ref Graphics local1 = ref graphics1;
      Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.WHITEHEX, 1);
      ref Bitmap local2 = ref bitmap2;
      double r1 = (double) num1;
      double g1 = (double) num2;
      double b1 = (double) num3;
      double a1 = (double) num4;
      DrawMod.Draw(ref local1, ref local2, 0, 0, (float) r1, (float) g1, (float) b1, (float) a1);
      this.TempRegimeColorBig = bitmap1;
      graphics1.Dispose();
      Bitmap bitmap3 = new Bitmap(64, 48);
      bitmap3.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics2 = Graphics.FromImage((Image) bitmap3);
      graphics2.Clear(Color.Transparent);
      ref Graphics local3 = ref graphics2;
      Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.WHITEHEX);
      ref Bitmap local4 = ref bitmap4;
      double r2 = (double) num1;
      double g2 = (double) num2;
      double b2 = (double) num3;
      double a2 = (double) num4;
      DrawMod.Draw(ref local3, ref local4, 0, 0, (float) r2, (float) g2, (float) b2, (float) a2);
      this.TempRegimeColor = bitmap3;
      graphics2.Dispose();
      Bitmap bitmap5 = new Bitmap(32, 24);
      bitmap5.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics3 = Graphics.FromImage((Image) bitmap5);
      graphics3.Clear(Color.Transparent);
      ref Graphics local5 = ref graphics3;
      Bitmap bitmap6 = BitmapStore.GetBitmap(DrawMod.TGame.WHITEHEX, -1);
      ref Bitmap local6 = ref bitmap6;
      double r3 = (double) num1;
      double g3 = (double) num2;
      double b3 = (double) num3;
      double a3 = (double) num4;
      DrawMod.Draw(ref local5, ref local6, 0, 0, (float) r3, (float) g3, (float) b3, (float) a3);
      this.TempRegimeColorSmall = bitmap5;
      graphics3.Dispose();
    }

    public void DoTempCounterAnySize(int sizey)
    {
      int landscapeTypeCounter = DrawMod.TGame.Data.LandscapeTypeCounter;
      int num1 = 76;
      int num2 = 75;
      int num3 = 128;
      int num4 = 96;
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
      string str1 = "systemgraphics/defaultcounterbig.png";
      if (sizey == -1)
        str1 = "systemgraphics/defaultcountersmall.png";
      if (sizey == 0)
        str1 = "systemgraphics/defaultcounter.png";
      string graphicsDirectory = DrawMod.TGame.ModSystemGraphicsDirectory;
      if (Strings.Len(graphicsDirectory) > 1)
        str1 = str1.Replace("systemgraphics", graphicsDirectory);
      Bitmap objBitmap;
      if (File.Exists(BitmapStore.GraphicsPath + str1))
      {
        objBitmap = new Bitmap(BitmapStore.GraphicsPath + str1);
      }
      else
      {
        string str2 = "systemgraphics/defaultcounterbig.png";
        if (sizey == -1)
          str2 = "systemgraphics/defaultcountersmall.png";
        if (sizey == 0)
          str2 = "systemgraphics/defaultcounter.png";
        objBitmap = new Bitmap(BitmapStore.GraphicsPath + str2);
      }
      objBitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      int num14 = objBitmap.Height - 1;
      Color pixel1;
      for (int y = 0; y <= num14; ++y)
      {
        int num15 = objBitmap.Width - 1;
        for (int x = 0; x <= num15; ++x)
        {
          pixel1 = objBitmap.GetPixel(x, y);
          int red = (int) Math.Round((double) ((float) pixel1.R * num5));
          int green = (int) Math.Round((double) ((float) pixel1.G * num6));
          int blue = (int) Math.Round((double) ((float) pixel1.B * num7));
          objBitmap.SetPixel(x, y, Color.FromArgb((int) pixel1.A, red, green, blue));
        }
      }
      Graphics objGraphics = Graphics.FromImage((Image) bitmap1);
      objGraphics.Clear(Color.Transparent);
      int num16 = landscapeTypeCounter;
      for (int index = 0; index <= num16; ++index)
        DrawMod.DrawSimple(ref objGraphics, ref objBitmap, index * num1, 0);
      objGraphics.Dispose();
      Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.WHITEHEX, 1);
      float num17 = 0.4f;
      float num18 = 0.6f;
      int num19 = landscapeTypeCounter;
      Rectangle rectangle1;
      Rectangle rectangle2;
      Color pixel2;
      for (int index1 = 0; index1 <= num19; ++index1)
      {
        if (DrawMod.TGame.Data.LandscapeTypeObj[index1].PreHexPicID > 0 & Strings.InStr(DrawMod.TGame.Data.LandscapeTypeObj[index1].PreHexPicFileName, "trans") < 1 & Strings.InStr(DrawMod.TGame.Data.LandscapeTypeObj[index1].PreHexPicFileName, "blackhex") < 1)
        {
          bool flag = false;
          int num20 = index1 - 1;
          for (int index2 = 0; index2 <= num20; ++index2)
          {
            if (DrawMod.TGame.Data.LandscapeTypeObj[index2].UsePreHexTexture && DrawMod.TGame.Data.LandscapeTypeObj[index1].PreHexTextureID == DrawMod.TGame.Data.LandscapeTypeObj[index2].PreHexTextureID)
            {
              flag = true;
              Graphics graphics = Graphics.FromImage((Image) bitmap1);
              graphics.CompositingMode = CompositingMode.SourceCopy;
              ref Graphics local1 = ref graphics;
              ref Bitmap local2 = ref bitmap1;
              rectangle1 = new Rectangle(num1 * index2, 0, num1, num1);
              Rectangle srcrect = rectangle1;
              rectangle2 = new Rectangle(num1 * index1, 0, num1, num1);
              Rectangle destrect = rectangle2;
              DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
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
              int num23 = num2;
              for (int y = 0; y <= num23; ++y)
              {
                int num24 = num2;
                for (int index3 = 0; index3 <= num24; ++index3)
                {
                  pixel2 = bitmap3.GetPixel(index3 + 26, y);
                  num21 += (long) ((int) Math.Round((double) ((int) pixel2.G + (int) pixel2.B + (int) pixel2.R) / 3.0) * (int) Math.Round((double) pixel2.A / 16.0));
                  num22 += (long) (int) Math.Round((double) pixel2.A / 16.0);
                }
              }
              int num25 = (int) Math.Round((double) num21 / (double) num22);
              int num26 = num2;
              for (int y1 = 0; y1 <= num26; ++y1)
              {
                int num27 = num2;
                for (int x1 = 0; x1 <= num27; ++x1)
                {
                  pixel1 = bitmap1.GetPixel(x1, y1);
                  pixel2 = bitmap3.GetPixel(x1 + 26, y1);
                  int r = (int) pixel2.R;
                  int g = (int) pixel2.G;
                  int b = (int) pixel2.B;
                  int a1 = (int) pixel2.A;
                  int num28 = (int) Math.Round((double) (r + b + g) / 3.0);
                  int num29;
                  int num30;
                  int num31;
                  if (num28 > num25)
                  {
                    num29 = (int) Math.Round((double) pixel1.G + (double) (Math.Min((int) pixel1.G * 2, (int) byte.MaxValue) - (int) pixel1.G) * ((double) (num28 - num25) / (double) byte.MaxValue));
                    num30 = (int) Math.Round((double) pixel1.R + (double) (Math.Min((int) pixel1.R * 2, (int) byte.MaxValue) - (int) pixel1.R) * ((double) (num28 - num25) / (double) byte.MaxValue));
                    num31 = (int) Math.Round((double) pixel1.B + (double) (Math.Min((int) pixel1.B * 2, (int) byte.MaxValue) - (int) pixel1.B) * ((double) (num28 - num25) / (double) byte.MaxValue));
                  }
                  else
                  {
                    num29 = (int) Math.Round((double) pixel1.G - (double) Math.Min((int) pixel1.G * 2, (int) byte.MaxValue) * ((double) (num25 - num28) / (double) byte.MaxValue));
                    num30 = (int) Math.Round((double) pixel1.R - (double) Math.Min((int) pixel1.R * 2, (int) byte.MaxValue) * ((double) (num25 - num28) / (double) byte.MaxValue));
                    num31 = (int) Math.Round((double) pixel1.B - (double) Math.Min((int) pixel1.B * 2, (int) byte.MaxValue) * ((double) (num25 - num28) / (double) byte.MaxValue));
                  }
                  int val2_1 = (int) Math.Round((double) g * (double) num17 + (double) num29 * (double) num18);
                  int val2_2 = (int) Math.Round((double) b * (double) num17 + (double) num31 * (double) num18);
                  int val2_3 = (int) Math.Round((double) r * (double) num17 + (double) num30 * (double) num18);
                  if (pixel2.A == (byte) 0)
                  {
                    val2_1 = (int) pixel1.G;
                    val2_2 = (int) pixel1.B;
                    val2_3 = (int) pixel1.R;
                  }
                  else if (pixel2.A < byte.MaxValue)
                  {
                    val2_1 = (int) Math.Round((double) val2_1 * ((double) a1 / (double) byte.MaxValue) + (double) pixel1.G * ((double) ((int) byte.MaxValue - a1) / (double) byte.MaxValue));
                    val2_2 = (int) Math.Round((double) val2_2 * ((double) a1 / (double) byte.MaxValue) + (double) pixel1.B * ((double) ((int) byte.MaxValue - a1) / (double) byte.MaxValue));
                    val2_3 = (int) Math.Round((double) val2_3 * ((double) a1 / (double) byte.MaxValue) + (double) pixel1.R * ((double) ((int) byte.MaxValue - a1) / (double) byte.MaxValue));
                  }
                  int a2 = (int) pixel1.A;
                  int red = Math.Max(0, Math.Min((int) byte.MaxValue, val2_3));
                  int green = Math.Max(0, Math.Min((int) byte.MaxValue, val2_1));
                  int blue = Math.Max(0, Math.Min((int) byte.MaxValue, val2_2));
                  int x2 = x1 + index1 * num1;
                  int y2 = y1;
                  bitmap1.SetPixel(x2, y2, Color.FromArgb(a2, red, green, blue));
                }
              }
            }
          }
        }
        else if (DrawMod.TGame.Data.LandscapeTypeObj[index1].UseSheet & !Information.IsNothing((object) BitmapStore.GetBitmap(DrawMod.TGame.Data.LandscapeTypeObj[index1].SheetSpriteID)))
        {
          bool flag = false;
          int num32 = index1 - 1;
          for (int index4 = 0; index4 <= num32; ++index4)
          {
            if (DrawMod.TGame.Data.LandscapeTypeObj[index4].UsePreHexTexture && DrawMod.TGame.Data.LandscapeTypeObj[index1].PreHexTextureID == DrawMod.TGame.Data.LandscapeTypeObj[index4].PreHexTextureID)
            {
              flag = true;
              Graphics graphics = Graphics.FromImage((Image) bitmap1);
              graphics.CompositingMode = CompositingMode.SourceCopy;
              ref Graphics local3 = ref graphics;
              ref Bitmap local4 = ref bitmap1;
              rectangle2 = new Rectangle(num1 * index4, 0, num1, num1);
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(num1 * index1, 0, num1, num1);
              Rectangle destrect = rectangle1;
              DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
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
              int num35 = num2;
              for (int y = 0; y <= num35; ++y)
              {
                int num36 = num2;
                for (int index5 = 0; index5 <= num36; ++index5)
                {
                  pixel2 = bitmap4.GetPixel(index5 + 26, y);
                  num33 += (long) ((int) Math.Round((double) ((int) pixel2.G + (int) pixel2.B + (int) pixel2.R) / 3.0) * (int) Math.Round((double) pixel2.A / 16.0));
                  num34 += (long) (int) Math.Round((double) pixel2.A / 16.0);
                }
              }
              int num37 = (int) Math.Round((double) num33 / (double) num34);
              int num38 = num2;
              for (int y3 = 0; y3 <= num38; ++y3)
              {
                int num39 = num2;
                for (int x3 = 0; x3 <= num39; ++x3)
                {
                  pixel1 = bitmap1.GetPixel(x3, y3);
                  pixel2 = bitmap4.GetPixel(x3 + 256 + 26, y3 + 960);
                  int r = (int) pixel2.R;
                  int g = (int) pixel2.G;
                  int b = (int) pixel2.B;
                  int num40 = (int) Math.Round((double) (r + b + g) / 3.0);
                  int num41;
                  int num42;
                  int num43;
                  if (num40 > num37)
                  {
                    num41 = (int) Math.Round((double) pixel1.G + (double) (Math.Min((int) pixel1.G * 2, (int) byte.MaxValue) - (int) pixel1.G) * ((double) (num40 - num37) / (double) byte.MaxValue));
                    num42 = (int) Math.Round((double) pixel1.R + (double) (Math.Min((int) pixel1.R * 2, (int) byte.MaxValue) - (int) pixel1.R) * ((double) (num40 - num37) / (double) byte.MaxValue));
                    num43 = (int) Math.Round((double) pixel1.B + (double) (Math.Min((int) pixel1.B * 2, (int) byte.MaxValue) - (int) pixel1.B) * ((double) (num40 - num37) / (double) byte.MaxValue));
                  }
                  else
                  {
                    num41 = (int) Math.Round((double) pixel1.G - (double) Math.Min((int) pixel1.G * 2, (int) byte.MaxValue) * ((double) (num37 - num40) / (double) byte.MaxValue));
                    num42 = (int) Math.Round((double) pixel1.R - (double) Math.Min((int) pixel1.R * 2, (int) byte.MaxValue) * ((double) (num37 - num40) / (double) byte.MaxValue));
                    num43 = (int) Math.Round((double) pixel1.B - (double) Math.Min((int) pixel1.B * 2, (int) byte.MaxValue) * ((double) (num37 - num40) / (double) byte.MaxValue));
                  }
                  int val2_4 = (int) Math.Round((double) g * 0.25 + (double) num41 * 0.75);
                  int val2_5 = (int) Math.Round((double) b * 0.25 + (double) num43 * 0.75);
                  int val2_6 = (int) Math.Round((double) r * 0.25 + (double) num42 * 0.75);
                  int a = (int) pixel1.A;
                  int red = Math.Max(0, Math.Min((int) byte.MaxValue, val2_6));
                  int green = Math.Max(0, Math.Min((int) byte.MaxValue, val2_4));
                  int blue = Math.Max(0, Math.Min((int) byte.MaxValue, val2_5));
                  int x4 = x3 + index1 * num1;
                  int y4 = y3;
                  bitmap1.SetPixel(x4, y4, Color.FromArgb(a, red, green, blue));
                }
              }
            }
          }
        }
        else if (DrawMod.TGame.Data.LandscapeTypeObj[index1].UsePreHexTexture)
        {
          int preHexTextureId = DrawMod.TGame.Data.LandscapeTypeObj[index1].PreHexTextureID;
          bool flag = false;
          int num44 = index1 - 1;
          for (int index6 = 0; index6 <= num44; ++index6)
          {
            if (DrawMod.TGame.Data.LandscapeTypeObj[index6].UsePreHexTexture && DrawMod.TGame.Data.LandscapeTypeObj[index1].PreHexTextureID == DrawMod.TGame.Data.LandscapeTypeObj[index6].PreHexTextureID)
            {
              flag = true;
              Graphics graphics = Graphics.FromImage((Image) bitmap1);
              graphics.CompositingMode = CompositingMode.SourceCopy;
              ref Graphics local5 = ref graphics;
              ref Bitmap local6 = ref bitmap1;
              rectangle2 = new Rectangle(num1 * index6, 0, num1, num1);
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(num1 * index1, 0, num1, num1);
              Rectangle destrect = rectangle1;
              DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect, destrect);
              graphics.Dispose();
              break;
            }
          }
          if (!flag)
          {
            int count = 49152;
            byte[] dst = new byte[count - 1 + 1];
            int num45 = (0 + BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal) % BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal * 8 + (0 + BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal) % BitmapStore.simpleByteCacheObj[preHexTextureId].cacheTotal;
            Buffer.BlockCopy((Array) BitmapStore.simpleByteCacheObj[preHexTextureId].cacheBig, num45 * count, (Array) dst, 0, count);
            int index7 = 0;
            int num46 = 0;
            int num47 = 0;
            int num48 = bitmap2.Height - 1;
            for (int index8 = 0; index8 <= num48; ++index8)
            {
              int num49 = bitmap2.Width - 1;
              for (int index9 = 0; index9 <= num49; ++index9)
              {
                if (index9 <= num2 & index8 <= num2)
                {
                  index7 += 4;
                  int num50 = (int) dst[index7];
                  int num51 = (int) dst[index7 + 1];
                  int num52 = (int) dst[index7 + 2];
                  num46 += (int) Math.Round((double) (num50 + num51 + num52) / 3.0);
                  ++num47;
                }
              }
            }
            int num53 = (int) Math.Round((double) num46 / (double) num47);
            int index10 = 0;
            int num54 = bitmap2.Height - 1;
            for (int y5 = 0; y5 <= num54; ++y5)
            {
              int num55 = bitmap2.Width - 1;
              for (int index11 = 0; index11 <= num55; ++index11)
              {
                if (index11 <= num2 & y5 <= num2)
                {
                  pixel1 = bitmap1.GetPixel(index11 + index1 * num1, y5);
                  int num56 = (int) dst[index10];
                  int num57 = (int) dst[index10 + 1];
                  int num58 = (int) dst[index10 + 2];
                  int num59 = (int) Math.Round((double) (num57 + num56 + num58) / 3.0);
                  int num60;
                  int num61;
                  int num62;
                  if (num59 > num53)
                  {
                    num60 = (int) Math.Round((double) pixel1.G + (double) (Math.Min((int) pixel1.G * 2, (int) byte.MaxValue) - (int) pixel1.G) * ((double) (num59 - num53) / (double) byte.MaxValue));
                    num61 = (int) Math.Round((double) pixel1.R + (double) (Math.Min((int) pixel1.R * 2, (int) byte.MaxValue) - (int) pixel1.R) * ((double) (num59 - num53) / (double) byte.MaxValue));
                    num62 = (int) Math.Round((double) pixel1.B + (double) (Math.Min((int) pixel1.B * 2, (int) byte.MaxValue) - (int) pixel1.B) * ((double) (num59 - num53) / (double) byte.MaxValue));
                  }
                  else
                  {
                    num60 = (int) Math.Round((double) pixel1.G - (double) Math.Min((int) pixel1.G * 2, (int) byte.MaxValue) * ((double) (num53 - num59) / (double) byte.MaxValue));
                    num61 = (int) Math.Round((double) pixel1.R - (double) Math.Min((int) pixel1.R * 2, (int) byte.MaxValue) * ((double) (num53 - num59) / (double) byte.MaxValue));
                    num62 = (int) Math.Round((double) pixel1.B - (double) Math.Min((int) pixel1.B * 2, (int) byte.MaxValue) * ((double) (num53 - num59) / (double) byte.MaxValue));
                  }
                  int num63 = (int) Math.Round((double) num57 * 0.14 + (double) num58 * 0.7 + (double) num56 * 0.1);
                  int val2_7 = (int) Math.Round((double) num63 * 0.4 + (double) num60 * 0.75);
                  int val2_8 = (int) Math.Round((double) num63 * 0.4 + (double) num62 * 0.75);
                  int val2_9 = (int) Math.Round((double) num63 * 0.4 + (double) num61 * 0.75);
                  int a = (int) pixel1.A;
                  int red = Math.Max(0, Math.Min((int) byte.MaxValue, val2_9));
                  int green = Math.Max(0, Math.Min((int) byte.MaxValue, val2_7));
                  int blue = Math.Max(0, Math.Min((int) byte.MaxValue, val2_8));
                  int x = index11 + index1 * num1;
                  int y6 = y5;
                  bitmap1.SetPixel(x, y6, Color.FromArgb((int) pixel1.A, red, green, blue));
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
            int num64 = 0;
            int num65 = 0;
            int num66 = num2;
            for (int y = 0; y <= num66; ++y)
            {
              int num67 = num2;
              for (int index12 = 0; index12 <= num67; ++index12)
              {
                pixel2 = bitmap5.GetPixel(index12 + 26, y);
                num64 += (int) Math.Round((double) (byte) ((uint) (byte) ((uint) pixel2.G + (uint) pixel2.B) + (uint) pixel2.R) / 3.0) * (int) Math.Round((double) pixel2.A / 16.0);
                num65 += (int) Math.Round((double) pixel2.A / 16.0);
              }
            }
            int num68 = (int) Math.Round((double) num64 / (double) num65);
            int num69 = num2;
            for (int y7 = 0; y7 <= num69; ++y7)
            {
              int num70 = num2;
              for (int x5 = 0; x5 <= num70; ++x5)
              {
                pixel1 = bitmap1.GetPixel(x5, y7);
                pixel2 = bitmap5.GetPixel(x5 + 26, y7);
                int r = (int) pixel2.R;
                int g = (int) pixel2.G;
                int b = (int) pixel2.B;
                int num71 = (int) Math.Round((double) (r + b + g) / 3.0);
                int num72;
                int num73;
                int num74;
                if (num71 > num68)
                {
                  num72 = (int) Math.Round((double) pixel1.G + (double) (Math.Min((int) pixel1.G * 2, (int) byte.MaxValue) - (int) pixel1.G) * ((double) (num71 - num68) / 128.0));
                  num73 = (int) Math.Round((double) pixel1.R + (double) (Math.Min((int) pixel1.R * 2, (int) byte.MaxValue) - (int) pixel1.R) * ((double) (num71 - num68) / 128.0));
                  num74 = (int) Math.Round((double) pixel1.B + (double) (Math.Min((int) pixel1.B * 2, (int) byte.MaxValue) - (int) pixel1.B) * ((double) (num71 - num68) / 128.0));
                }
                else
                {
                  num72 = (int) Math.Round((double) pixel1.G - (double) Math.Min((int) pixel1.G * 2, (int) byte.MaxValue) * ((double) (num68 - num71) / 128.0));
                  num73 = (int) Math.Round((double) pixel1.R - (double) Math.Min((int) pixel1.R * 2, (int) byte.MaxValue) * ((double) (num68 - num71) / 128.0));
                  num74 = (int) Math.Round((double) pixel1.B - (double) Math.Min((int) pixel1.B * 2, (int) byte.MaxValue) * ((double) (num68 - num71) / 128.0));
                }
                int val2_10 = (int) Math.Round((double) g * 0.25 + (double) num72 * 0.75);
                int val2_11 = (int) Math.Round((double) b * 0.25 + (double) num74 * 0.75);
                int val2_12 = (int) Math.Round((double) r * 0.25 + (double) num73 * 0.75);
                int a = (int) pixel1.A;
                int red = Math.Max(0, Math.Min((int) byte.MaxValue, val2_12));
                int green = Math.Max(0, Math.Min((int) byte.MaxValue, val2_10));
                int blue = Math.Max(0, Math.Min((int) byte.MaxValue, val2_11));
                int x6 = x5 + index1 * num1;
                int y8 = y7;
                bitmap1.SetPixel(x6, y8, Color.FromArgb(a, red, green, blue));
              }
            }
          }
        }
        else
        {
          int num75 = num75;
        }
      }
      Bitmap bitmap6 = new Bitmap(bitmap1.Width, bitmap1.Height);
      bitmap6.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics1 = Graphics.FromImage((Image) bitmap6);
      graphics1.CompositingMode = CompositingMode.SourceCopy;
      ref Graphics local7 = ref graphics1;
      ref Bitmap local8 = ref bitmap1;
      rectangle2 = new Rectangle(0, 0, bitmap1.Width, bitmap1.Height);
      Rectangle srcrect1 = rectangle2;
      rectangle1 = new Rectangle(0, 0, bitmap1.Width, bitmap1.Height);
      Rectangle destrect1 = rectangle1;
      DrawMod.DrawSimplePart2ColouredNew(ref local7, ref local8, srcrect1, destrect1, 0.9f, 0.9f, 0.9f, 1f);
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

    public void Kill()
    {
      this.TempCounter = (Bitmap) null;
      BitmapStore.RemoveBitmapNr(this.NationalIconSprite);
      BitmapStore.RemoveBitmapNr(this.HQSpriteNr);
    }

    public void LoadSprites()
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

    public void ReplaceNationalSprite(string filename)
    {
      this.NationalIconSpriteName = filename;
      this.NationalIconSprite = BitmapStore.ReloadFile(this.NationalIconSprite, filename, IsBig: true);
    }

    public void ReplaceRoundelSprite(string filename)
    {
      this.RoundelSpriteName = filename;
      this.RoundelIconSprite = BitmapStore.ReloadFile(this.RoundelIconSprite, filename);
    }

    public void ReplaceBannerSprite(string filename)
    {
      this.BannerSpriteFileName = filename;
      this.BannerSpriteNr = BitmapStore.ReloadFile(this.BannerSpriteNr, filename);
    }

    public void ReplaceSymbolSprite(string filename)
    {
      this.SymbolSpriteName = filename;
      this.SymbolSpriteNr = BitmapStore.ReloadFile(this.SymbolSpriteNr, filename);
    }

    public void ReplaceHQSprite(string filename)
    {
      this.HQSpriteFileName = filename;
      this.HQSpriteNr = BitmapStore.AddFile(this.HQSpriteFileName, false, true);
      if (DrawMod.TGame.Data.Product >= 7)
        return;
      this.DoTempCounter();
    }

    public void ReplaceRoundelSprite2(string filename)
    {
      this.RoundelSpriteName2 = filename;
      this.RoundelIconSprite2 = BitmapStore.ReloadFile(this.RoundelIconSprite2, filename);
    }

    public void ReplaceHQSprite2(string filename)
    {
      this.HQSpriteFileName2 = filename;
      this.HQSpriteNr2 = BitmapStore.AddFile(this.HQSpriteFileName2, false, true);
      if (DrawMod.TGame.Data.Product >= 7)
        return;
      this.DoTempCounter();
    }

    public void ReplaceBannerSprite2(string filename)
    {
      this.BannerSpriteFileName2 = filename;
      this.BannerSpriteNr2 = BitmapStore.ReloadFile(this.BannerSpriteNr2, filename);
    }
  }
}
