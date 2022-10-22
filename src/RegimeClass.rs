// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.RegimeClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingMicrosoft.VisualBasic.CompilerServices;
// usingSystem;
// usingSystem.Drawing;
// usingSystem.Drawing.Drawing2D;
// usingSystem.IO;
// usingSystem.Runtime.Serialization;
// usingSystem.Runtime.Serialization.Formatters.Binary;

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
    pub RegimeSlot: Vec<i32>;
    pub LastTempRegimeSlotPredict: Vec<i32>;
    pub TempRegimeSlotPredict: Vec<i32>;
    pub TempRegimeSlotIncrease: Vec<i32>;
    pub TempPPIncrease: i32;
    pub HQSpriteOverrule: bool;
    pub BaseMorale: i32;
    pub ResPts: i32;
    pub ResFieldCounter: i32;
    pub ResField: Vec<bool>;
    pub RegimeCounter: i32;
    pub RegimeRel: Vec<i32>;
    pub RegimeOffer: Vec<i32>;
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
    pub MessString: Vec<String>;
    pub MessBackPic: Vec<i32>;
    pub MessFrontPic: Vec<i32>;
    pub MessWav: Vec<String>;
    pub MesStyle: Vec<i32>;
    pub MesNote: Vec<String>;
    pub MesNote2: Vec<String>;
    pub MesName: Vec<String>;
    pub MesGroup: Vec<i32>;
    pub MesHideFromStart: Vec<bool>;
    pub MesHideFromTab: Vec<bool>;
    pub MesChosen: Vec<i32>;
    pub AI: bool;
    pub AIid: i32;
    pub Sleep: bool;
    pub PassWord: String;
    pub UnitName: String;
    pub UnitNumber: i32;
    pub HQName: String;
    pub HQNumber: i32;
    pub SLoss: Vec<i32>;
    pub SKills: Vec<i32>;
    pub SProd: Vec<i32>;
    pub SPresent: Vec<i32>;
    pub int[,,] LisPoints;
    pub HexBack: Bitmap;
    pub PlanCounter: i32;
    pub PlanObj: Vec<AIPlanClass>;
    pub TempCounter: Bitmap;
    pub TempCounterHigh: Bitmap;
    pub TempCounterBig: Bitmap;
    pub TempCounterBigHigh: Bitmap;
    pub TempCountersmall: Bitmap;
    pub TempCountersmallHigh: Bitmap;
    pub TempRegimeColor: Bitmap;
    pub TempRegimeColorSmall: Bitmap;
    pub TempRegimeColorBig: Bitmap;
    pub DipBlock: bool;
    pub SASSupplyLost: i32;
    pub SASSupplyKilled: i32;
    pub SASProdLost: Vec<i32>;
    pub SASKilled: Vec<i32>;
    pub AISavedPP: i32;
    pub float AIConservative;
    pub ProdBonus: i32;
    pub ActionCardCounter: i32;
    pub ActionCard: Vec<i32>;
    pub ActionCardHistoryCounter: i32;
    pub ActionCardHistory: Vec<i32>;
    pub ActionCardHistoryRound: Vec<i32>;
    pub ExtraStat: Vec<i32>;
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
    pub AIGroupName: Vec<String>;
    pub AIGroupType: Vec<i32>;
    pub AIGroupHis: Vec<i32>;
    pub AIGroupLastAttack: Vec<i32>;
    pub AIGroupLastDefend: Vec<i32>;
    pub AIGroupLastFollowUp: Vec<i32>;
    pub AIGroupLastFallBack: Vec<i32>;
    pub AICorpsTopGroup: Vec<i32>;
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
      info.AddValue("Name",  this.Name);
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
      info.AddValue("RegimeSlot",  this.RegimeSlot);
      info.AddValue("HQSpriteFileName",  this.HQSpriteFileName);
      info.AddValue("HQSpriteFileName2",  this.HQSpriteFileName2);
      info.AddValue("BaseMorale", this.BaseMorale);
      info.AddValue("ResPts", this.ResPts);
      info.AddValue("ResFieldCounter", this.ResFieldCounter);
      info.AddValue("ResField",  this.ResField);
      info.AddValue("RegimeCounter", this.RegimeCounter);
      info.AddValue("RegimeRel",  this.RegimeRel);
      info.AddValue("RegimeOffer",  this.RegimeOffer);
      info.AddValue("MapCount", this.MapCount);
      info.AddValue("HistoryOwner",  this.HistoryOwner);
      info.AddValue("HistorySFType",  this.HistorySFType);
      info.AddValue("HistoryForce",  this.HistoryForce);
      info.AddValue("HistoryHis",  this.HistoryHis);
      info.AddValue("HistoryDepth",  this.HistoryDepth);
      info.AddValue("HistoryStep",  this.HistoryStep);
      info.AddValue("HistoryStepCounter", this.HistoryStepCounter);
      info.AddValue("MessCounter", this.MessCounter);
      info.AddValue("MessString",  this.MessString);
      info.AddValue("MessBackPic",  this.MessBackPic);
      info.AddValue("MessFrontPic",  this.MessFrontPic);
      info.AddValue("MessWav",  this.MessWav);
      info.AddValue("MesStyle",  this.MesStyle);
      info.AddValue("MesNote",  this.MesNote);
      info.AddValue("MesNote2",  this.MesNote2);
      info.AddValue("MesName",  this.MesName);
      info.AddValue("MesGroup",  this.MesGroup);
      info.AddValue("MesChosen",  this.MesChosen);
      info.AddValue("MesHideFromStart",  this.MesHideFromStart);
      info.AddValue("MesHideFromTab",  this.MesHideFromTab);
      info.AddValue("AI", this.AI);
      info.AddValue("AIid", this.AIid);
      info.AddValue("Sleep", this.Sleep);
      info.AddValue("PassWord",  this.PassWord);
      info.AddValue("UnitName",  this.UnitName);
      info.AddValue("UnitNumber", this.UnitNumber);
      info.AddValue("HQName",  this.HQName);
      info.AddValue("HQNumber", this.HQNumber);
      info.AddValue("SLoss",  this.SLoss);
      info.AddValue("SKills",  this.SKills);
      info.AddValue("SProd",  this.SProd);
      info.AddValue("SPresent",  this.SPresent);
      info.AddValue("DipBlock", this.DipBlock);
      info.AddValue("SASSupplyLost", this.SASSupplyLost);
      info.AddValue("SASSupplyKilled", this.SASSupplyKilled);
      info.AddValue("SASProdLost",  this.SASProdLost);
      info.AddValue("SASKilled",  this.SASKilled);
      info.AddValue("HQSpriteOverrule", this.HQSpriteOverrule);
      info.AddValue("PlanCounter", this.PlanCounter);
      info.AddValue("PlanObj",  this.PlanObj);
      info.AddValue("ProdBonus", this.ProdBonus);
      info.AddValue("AIVP",  this.AIVP);
      info.AddValue("Trafic",  this.Trafic);
      info.AddValue("Trafic2",  this.Trafic2);
      info.AddValue("AIPower",  this.AIPower);
      info.AddValue("AIDefense",  this.AIDefense);
      info.AddValue("ActionCardCounter", this.ActionCardCounter);
      info.AddValue("ActionCard",  this.ActionCard);
      info.AddValue("ActionCardHistoryCounter", this.ActionCardHistoryCounter);
      info.AddValue("ActionCardHistory",  this.ActionCardHistory);
      info.AddValue("ActionCardHistoryRound",  this.ActionCardHistoryRound);
      info.AddValue("AIConservative", this.AIConservative);
      info.AddValue("ExtraStat",  this.ExtraStat);
      info.AddValue("NationalIconSpriteName",  this.NationalIconSpriteName);
      info.AddValue("RoundelSpriteName",  this.RoundelSpriteName);
      info.AddValue("RoundelSpriteName2",  this.RoundelSpriteName2);
      info.AddValue("BannerSpriteFileName",  this.BannerSpriteFileName);
      info.AddValue("BannerSpriteFileName2",  this.BannerSpriteFileName2);
      info.AddValue("SymbolSpriteName",  this.SymbolSpriteName);
      info.AddValue("ExtraGraphicUse", this.ExtraGraphicUse);
      info.AddValue("FirstRound", this.FirstRound);
      info.AddValue("RandomCode", this.RandomCode);
      info.AddValue("AIGroupCounter", this.AIGroupCounter);
      info.AddValue("AIGroupHis",  this.AIGroupHis);
      info.AddValue("AIGroupType",  this.AIGroupType);
      info.AddValue("AIGroupLastAttack",  this.AIGroupLastAttack);
      info.AddValue("AIGroupLastDefend",  this.AIGroupLastDefend);
      info.AddValue("AIGroupLastFollowUp",  this.AIGroupLastFollowUp);
      info.AddValue("AIGroupLastFallBack",  this.AIGroupLastFallBack);
      info.AddValue("AICorpsTopGroup",  this.AICorpsTopGroup);
      info.AddValue("AIGroupName",  this.AIGroupName);
      info.AddValue("OfficerPool", this.OfficerPool);
      info.AddValue("UberRegime", this.UberRegime);
      info.AddValue("Mirror", this.Mirror);
      info.AddValue("Version", this.Version);
      info.AddValue("subVersion",  this.subVersion);
      info.AddValue("LoadTransferHistorical", this.LoadTransferHistorical);
      info.AddValue("OldAINarrow",  this.OldAINarrow);
      info.AddValue("AIHelpMove", this.AIHelpMove);
      info.AddValue("AIHelpCombat", this.AIHelpCombat);
      info.AddValue("AIHelpStrategic", this.AIHelpStrategic);
      info.AddValue("PBEMPlayer", this.PbemPlayer);
      info.AddValue("UseAlternateActionCardPics", this.UseAlternateActionCardPics);
      info.AddValue("FerryEffectivity", this.FerryEffectivity);
      info.AddValue("LibId",  this.libId);
      info.AddValue("Id", this.id);
      info.AddValue("hideFromList", this.hideFromList);
      info.AddValue("minimumDataUsage", this.minimumDataUsage);
    }

    pub fn AddPlan()
    {
      this += 1.PlanCounter;
      this.PlanObj = (AIPlanClass[]) Utils.CopyArray((Array) this.PlanObj, (Array) new AIPlanClass[this.PlanCounter + 1]);
      this.PlanObj[this.PlanCounter] = AIPlanClass::new();
    }

    pub fn RemovePlan(nr: i32)
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
      numArray1: Vec<i32> = new int[mapWidth + 1, mapHeight + 1];
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
          numArray2: Vec<i32> = new int[mapWidth + 1, mapHeight + 1];
          numArray3: Vec<i32> = (int[,]) info.GetValue(nameof (HistoryOwner), numArray2.GetType());
          this.HistoryOwner[0] = new MapMatrix2(mapWidth, mapHeight);
          this.HistoryOwner[0].Value = numArray3;
          numArray4: Vec<i32> = new int[mapWidth + 1, mapHeight + 1];
          numArray5: Vec<i32> = (int[,]) info.GetValue(nameof (HistoryForce), numArray4.GetType());
          this.HistoryForce[0] = new MapMatrix2(mapWidth, mapHeight);
          this.HistoryForce[0].Value = numArray5;
          numArray6: Vec<i32> = new int[mapWidth + 1, mapHeight + 1];
          numArray7: Vec<i32> = (int[,]) info.GetValue(nameof (HistorySFType), numArray6.GetType());
          this.HistorySFType[0] = new MapMatrix2(mapWidth, mapHeight);
          this.HistorySFType[0].Value = numArray7;
          try
          {
            numArray8: Vec<i32> = new int[mapWidth + 1, mapHeight + 1];
            numArray9: Vec<i32> = (int[,]) info.GetValue(nameof (HistoryHis), numArray8.GetType());
            this.HistoryHis[0] = new MapMatrix2(mapWidth, mapHeight);
            this.HistoryHis[0].Value = numArray9;
            numArray10: Vec<i32> = new int[mapWidth + 1, mapHeight + 1];
            numArray11: Vec<i32> = (int[,]) info.GetValue(nameof (HistoryDepth), numArray10.GetType());
            this.HistoryDepth[0] = new MapMatrix2(mapWidth, mapHeight);
            this.HistoryDepth[0].Value = numArray11;
          }
          catch (Exception ex2)
          {
            ProjectData.SetProjectError(ex2);
            this.HistoryHis = new MapMatrix2[1];
            this.HistoryDepth = new MapMatrix2[1];
            numArray12: Vec<i32> = new int[mapWidth + 1, mapHeight + 1];
            this.HistoryHis[0] = new MapMatrix2(mapWidth, mapHeight);
            this.HistoryHis[0].Value = numArray12;
            this.HistoryDepth[0] = new MapMatrix2(mapWidth, mapHeight);
            this.HistoryDepth[0].Value = numArray12;
            ProjectData.ClearProjectError();
          }
          try
          {
            numArray13: Vec<i32> = new int[mapWidth + 1, mapHeight + 1];
            numArray14: Vec<i32> = (int[,]) info.GetValue(nameof (AIVP), numArray13.GetType());
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
            numArray15: Vec<i32> = new int[mapWidth + 1, mapHeight + 1];
            numArray16: Vec<i32> = (int[,]) info.GetValue(nameof (Trafic), numArray15.GetType());
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
            numArray17: Vec<i32> = new int[mapWidth + 1, mapHeight + 1];
            numArray18: Vec<i32> = (int[,]) info.GetValue(nameof (Trafic2), numArray17.GetType());
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
            numArray19: Vec<i32> = new int[mapWidth + 1, mapHeight + 1];
            numArray20: Vec<i32> = (int[,]) info.GetValue(nameof (AIPower), numArray19.GetType());
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
            numArray21: Vec<i32> = new int[mapWidth + 1, mapHeight + 1];
            numArray22: Vec<i32> = (int[,]) info.GetValue(nameof (AIDefense), numArray21.GetType());
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
      if ( this.AIConservative <= 0.0)
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
      binaryFormatter.Serialize((Stream) serializationStream,  this);
      serializationStream.Position = 0L;
      return (RegimeClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    pub RegimeClass(
      hardcoded: i32,
      tregimecounter: i32,
      trescounter: i32,
      tData: DataClass,
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

    pub fn AddMap(w: i32, h: i32)
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

    pub fn RemoveMap(nr: i32)
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

    pub fn AddResField()
    {
      this += 1.ResFieldCounter;
      this.ResField = (bool[]) Utils.CopyArray((Array) this.ResField, (Array) new bool[this.ResFieldCounter + 1]);
      this.ResField[this.ResFieldCounter] = false;
    }

    pub fn RemoveResField(nr: i32)
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

    pub fn AddRegime()
    {
      this += 1.RegimeCounter;
      this.RegimeRel = (int[]) Utils.CopyArray((Array) this.RegimeRel, (Array) new int[this.RegimeCounter + 1]);
      this.RegimeOffer = (int[]) Utils.CopyArray((Array) this.RegimeOffer, (Array) new int[this.RegimeCounter + 1]);
      this.RegimeRel[this.RegimeCounter] = 1;
    }

    pub fn Removeregime(nr: i32)
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

    pub fn AddActionCard(nr: i32)
    {
      this += 1.ActionCardCounter;
      this.ActionCard = (int[]) Utils.CopyArray((Array) this.ActionCard, (Array) new int[this.ActionCardCounter + 1]);
      this.ActionCard[this.ActionCardCounter] = nr;
    }

    pub fn RemoveActionCard(nr: i32)
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

    pub fn AddActionCardHistory(nr: i32, round: i32)
    {
      this += 1.ActionCardHistoryCounter;
      this.ActionCardHistory = (int[]) Utils.CopyArray((Array) this.ActionCardHistory, (Array) new int[this.ActionCardHistoryCounter + 1]);
      this.ActionCardHistoryRound = (int[]) Utils.CopyArray((Array) this.ActionCardHistoryRound, (Array) new int[this.ActionCardHistoryCounter + 1]);
      this.ActionCardHistory[this.ActionCardHistoryCounter] = nr;
      this.ActionCardHistoryRound[this.ActionCardHistoryCounter] = round;
    }

    pub fn RemoveActionCardHistory(nr: i32)
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

    pub fn DoTempCounterBig() => this.DoTempCounterAnySize(1);

    pub fn DoTempCounter() => this.DoTempCounterAnySize(0);

    pub fn DoTempCounterSmall() => this.DoTempCounterAnySize(-1);

    pub fn doTempRegimeHighlight(bool lighter = false)
    {
      float num1 =  ( this.Red / 512.0 - 0.9);
      float num2 =  ( this.Green / 512.0 - 0.9);
      float num3 =  ( this.Blue / 512.0 - 0.9);
      float num4 = 0.25f;
      if (lighter)
        num4 = 0.1f;
      bitmap1: Bitmap = new Bitmap(128, 96);
      bitmap1.SetResolution( DrawMod.DPIx,  DrawMod.DPIy);
      Graphics graphics1 = Graphics.FromImage((Image) bitmap1);
      graphics1.Clear(Color.Transparent);
       let mut local1: &Graphics = &graphics1;
      bitmap2: Bitmap = BitmapStore.GetBitmap(DrawMod.TGame.WHITEHEX, 1);
       let mut local2: &Bitmap = &bitmap2;
      double r1 =  num1;
      double g1 =  num2;
      double b1 =  num3;
      double a1 =  num4;
      DrawMod.Draw( local1,  local2, 0, 0,  r1,  g1,  b1,  a1);
      this.TempRegimeColorBig = bitmap1;
      graphics1.Dispose();
      bitmap3: Bitmap = new Bitmap(64, 48);
      bitmap3.SetResolution( DrawMod.DPIx,  DrawMod.DPIy);
      Graphics graphics2 = Graphics.FromImage((Image) bitmap3);
      graphics2.Clear(Color.Transparent);
       let mut local3: &Graphics = &graphics2;
      bitmap4: Bitmap = BitmapStore.GetBitmap(DrawMod.TGame.WHITEHEX);
       let mut local4: &Bitmap = &bitmap4;
      double r2 =  num1;
      double g2 =  num2;
      double b2 =  num3;
      double a2 =  num4;
      DrawMod.Draw( local3,  local4, 0, 0,  r2,  g2,  b2,  a2);
      this.TempRegimeColor = bitmap3;
      graphics2.Dispose();
      bitmap5: Bitmap = new Bitmap(32, 24);
      bitmap5.SetResolution( DrawMod.DPIx,  DrawMod.DPIy);
      Graphics graphics3 = Graphics.FromImage((Image) bitmap5);
      graphics3.Clear(Color.Transparent);
       let mut local5: &Graphics = &graphics3;
      bitmap6: Bitmap = BitmapStore.GetBitmap(DrawMod.TGame.WHITEHEX, -1);
       let mut local6: &Bitmap = &bitmap6;
      double r3 =  num1;
      double g3 =  num2;
      double b3 =  num3;
      double a3 =  num4;
      DrawMod.Draw( local5,  local6, 0, 0,  r3,  g3,  b3,  a3);
      this.TempRegimeColorSmall = bitmap5;
      graphics3.Dispose();
    }

    pub fn DoTempCounterAnySize(sizey: i32)
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
      float num5 =  this.Red /  byte.MaxValue;
      float num6 =  this.Green /  byte.MaxValue;
      float num7 =  this.Blue /  byte.MaxValue;
      float num8 =  (1.0 * ( num5 / (( num6 +  num7) / 2.0)));
      float num9 =  (1.0 * ( num6 / (( num5 +  num7) / 2.0)));
      float num10 =  (1.0 * ( num7 / (( num6 +  num5) / 2.0)));
      float num11 =  ((1.0 +  num8) / 2.0);
      float num12 =  ((1.0 +  num9) / 2.0);
      float num13 =  ((1.0 +  num10) / 2.0);
      bitmap1: Bitmap = new Bitmap(num1 * (landscapeTypeCounter + 1), num1);
      bitmap1.SetResolution( DrawMod.DPIx,  DrawMod.DPIy);
      str1: String = "systemgraphics/defaultcounterbig.png";
      if (sizey == -1)
        str1 = "systemgraphics/defaultcountersmall.png";
      if (sizey == 0)
        str1 = "systemgraphics/defaultcounter.png";
      graphicsDirectory: String = DrawMod.TGame.ModSystemGraphicsDirectory;
      if (Strings.Len(graphicsDirectory) > 1)
        str1 = str1.Replace("systemgraphics", graphicsDirectory);
      objBitmap: Bitmap;
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
      objBitmap.SetResolution( DrawMod.DPIx,  DrawMod.DPIy);
      let mut num14: i32 = objBitmap.Height - 1;
      pixel1: Color;
      for (let mut y: i32 = 0; y <= num14; y += 1)
      {
        let mut num15: i32 = objBitmap.Width - 1;
        for (let mut x: i32 = 0; x <= num15; x += 1)
        {
          pixel1 = objBitmap.GetPixel(x, y);
          let mut red: i32 =  Math.Round( ( pixel1.R * num5));
          let mut green: i32 =  Math.Round( ( pixel1.G * num6));
          let mut blue: i32 =  Math.Round( ( pixel1.B * num7));
          objBitmap.SetPixel(x, y, Color.FromArgb( pixel1.A, red, green, blue));
        }
      }
      Graphics objGraphics = Graphics.FromImage((Image) bitmap1);
      objGraphics.Clear(Color.Transparent);
      let mut num16: i32 = landscapeTypeCounter;
      for (let mut index: i32 = 0; index <= num16; index += 1)
        DrawMod.DrawSimple( objGraphics,  objBitmap, index * num1, 0);
      objGraphics.Dispose();
      bitmap2: Bitmap = BitmapStore.GetBitmap(DrawMod.TGame.WHITEHEX, 1);
      float num17 = 0.4f;
      float num18 = 0.6f;
      let mut num19: i32 = landscapeTypeCounter;
      Rectangle rectangle1;
      Rectangle rectangle2;
      pixel2: Color;
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
            bitmap3: Bitmap = BitmapStore.GetBitmap(DrawMod.TGame.Data.LandscapeTypeObj[index1].PreHexPicID, 1);
            if (!Information.IsNothing( bitmap3))
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
                  num21 += (long) ( Math.Round( ( pixel2.G +  pixel2.B +  pixel2.R) / 3.0) *  Math.Round( pixel2.A / 16.0));
                  num22 += (long)  Math.Round( pixel2.A / 16.0);
                }
              }
              let mut num25: i32 =  Math.Round( num21 /  num22);
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
                  let mut num28: i32 =  Math.Round( (r + b + g) / 3.0);
                  num29: i32;
                  num30: i32;
                  num31: i32;
                  if (num28 > num25)
                  {
                    num29 =  Math.Round( pixel1.G +  (Math.Min( pixel1.G * 2,  byte.MaxValue) -  pixel1.G) * ( (num28 - num25) /  byte.MaxValue));
                    num30 =  Math.Round( pixel1.R +  (Math.Min( pixel1.R * 2,  byte.MaxValue) -  pixel1.R) * ( (num28 - num25) /  byte.MaxValue));
                    num31 =  Math.Round( pixel1.B +  (Math.Min( pixel1.B * 2,  byte.MaxValue) -  pixel1.B) * ( (num28 - num25) /  byte.MaxValue));
                  }
                  else
                  {
                    num29 =  Math.Round( pixel1.G -  Math.Min( pixel1.G * 2,  byte.MaxValue) * ( (num25 - num28) /  byte.MaxValue));
                    num30 =  Math.Round( pixel1.R -  Math.Min( pixel1.R * 2,  byte.MaxValue) * ( (num25 - num28) /  byte.MaxValue));
                    num31 =  Math.Round( pixel1.B -  Math.Min( pixel1.B * 2,  byte.MaxValue) * ( (num25 - num28) /  byte.MaxValue));
                  }
                  let mut val2_1: i32 =  Math.Round( g *  num17 +  num29 *  num18);
                  let mut val2_2: i32 =  Math.Round( b *  num17 +  num31 *  num18);
                  let mut val2_3: i32 =  Math.Round( r *  num17 +  num30 *  num18);
                  if (pixel2.A == (byte) 0)
                  {
                    val2_1 =  pixel1.G;
                    val2_2 =  pixel1.B;
                    val2_3 =  pixel1.R;
                  }
                  else if (pixel2.A < byte.MaxValue)
                  {
                    val2_1 =  Math.Round( val2_1 * ( a1 /  byte.MaxValue) +  pixel1.G * ( ( byte.MaxValue - a1) /  byte.MaxValue));
                    val2_2 =  Math.Round( val2_2 * ( a1 /  byte.MaxValue) +  pixel1.B * ( ( byte.MaxValue - a1) /  byte.MaxValue));
                    val2_3 =  Math.Round( val2_3 * ( a1 /  byte.MaxValue) +  pixel1.R * ( ( byte.MaxValue - a1) /  byte.MaxValue));
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
        else if (DrawMod.TGame.Data.LandscapeTypeObj[index1].UseSheet & !Information.IsNothing( BitmapStore.GetBitmap(DrawMod.TGame.Data.LandscapeTypeObj[index1].SheetSpriteID)))
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
            bitmap4: Bitmap = BitmapStore.GetBitmap(DrawMod.TGame.Data.LandscapeTypeObj[index1].SheetSpriteID, 1);
            if (!Information.IsNothing( bitmap4))
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
                  num33 += (long) ( Math.Round( ( pixel2.G +  pixel2.B +  pixel2.R) / 3.0) *  Math.Round( pixel2.A / 16.0));
                  num34 += (long)  Math.Round( pixel2.A / 16.0);
                }
              }
              let mut num37: i32 =  Math.Round( num33 /  num34);
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
                  let mut num40: i32 =  Math.Round( (r + b + g) / 3.0);
                  num41: i32;
                  num42: i32;
                  num43: i32;
                  if (num40 > num37)
                  {
                    num41 =  Math.Round( pixel1.G +  (Math.Min( pixel1.G * 2,  byte.MaxValue) -  pixel1.G) * ( (num40 - num37) /  byte.MaxValue));
                    num42 =  Math.Round( pixel1.R +  (Math.Min( pixel1.R * 2,  byte.MaxValue) -  pixel1.R) * ( (num40 - num37) /  byte.MaxValue));
                    num43 =  Math.Round( pixel1.B +  (Math.Min( pixel1.B * 2,  byte.MaxValue) -  pixel1.B) * ( (num40 - num37) /  byte.MaxValue));
                  }
                  else
                  {
                    num41 =  Math.Round( pixel1.G -  Math.Min( pixel1.G * 2,  byte.MaxValue) * ( (num37 - num40) /  byte.MaxValue));
                    num42 =  Math.Round( pixel1.R -  Math.Min( pixel1.R * 2,  byte.MaxValue) * ( (num37 - num40) /  byte.MaxValue));
                    num43 =  Math.Round( pixel1.B -  Math.Min( pixel1.B * 2,  byte.MaxValue) * ( (num37 - num40) /  byte.MaxValue));
                  }
                  let mut val2_4: i32 =  Math.Round( g * 0.25 +  num41 * 0.75);
                  let mut val2_5: i32 =  Math.Round( b * 0.25 +  num43 * 0.75);
                  let mut val2_6: i32 =  Math.Round( r * 0.25 +  num42 * 0.75);
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
                  num46 +=  Math.Round( (num50 + num51 + num52) / 3.0);
                  num47 += 1;
                }
              }
            }
            let mut num53: i32 =  Math.Round( num46 /  num47);
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
                  let mut num59: i32 =  Math.Round( (num57 + num56 + num58) / 3.0);
                  num60: i32;
                  num61: i32;
                  num62: i32;
                  if (num59 > num53)
                  {
                    num60 =  Math.Round( pixel1.G +  (Math.Min( pixel1.G * 2,  byte.MaxValue) -  pixel1.G) * ( (num59 - num53) /  byte.MaxValue));
                    num61 =  Math.Round( pixel1.R +  (Math.Min( pixel1.R * 2,  byte.MaxValue) -  pixel1.R) * ( (num59 - num53) /  byte.MaxValue));
                    num62 =  Math.Round( pixel1.B +  (Math.Min( pixel1.B * 2,  byte.MaxValue) -  pixel1.B) * ( (num59 - num53) /  byte.MaxValue));
                  }
                  else
                  {
                    num60 =  Math.Round( pixel1.G -  Math.Min( pixel1.G * 2,  byte.MaxValue) * ( (num53 - num59) /  byte.MaxValue));
                    num61 =  Math.Round( pixel1.R -  Math.Min( pixel1.R * 2,  byte.MaxValue) * ( (num53 - num59) /  byte.MaxValue));
                    num62 =  Math.Round( pixel1.B -  Math.Min( pixel1.B * 2,  byte.MaxValue) * ( (num53 - num59) /  byte.MaxValue));
                  }
                  let mut num63: i32 =  Math.Round( num57 * 0.14 +  num58 * 0.7 +  num56 * 0.1);
                  let mut val2_7: i32 =  Math.Round( num63 * 0.4 +  num60 * 0.75);
                  let mut val2_8: i32 =  Math.Round( num63 * 0.4 +  num62 * 0.75);
                  let mut val2_9: i32 =  Math.Round( num63 * 0.4 +  num61 * 0.75);
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
          bitmap5: Bitmap = BitmapStore.GetBitmap(DrawMod.TGame.Data.LandscapeTypeObj[index1].LayerSpriteID[0], 1);
          if (!Information.IsNothing( bitmap5))
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
                num64 +=  Math.Round( (byte) ((uint) (byte) ((uint) pixel2.G + (uint) pixel2.B) + (uint) pixel2.R) / 3.0) *  Math.Round( pixel2.A / 16.0);
                num65 +=  Math.Round( pixel2.A / 16.0);
              }
            }
            let mut num68: i32 =  Math.Round( num64 /  num65);
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
                let mut num71: i32 =  Math.Round( (r + b + g) / 3.0);
                num72: i32;
                num73: i32;
                num74: i32;
                if (num71 > num68)
                {
                  num72 =  Math.Round( pixel1.G +  (Math.Min( pixel1.G * 2,  byte.MaxValue) -  pixel1.G) * ( (num71 - num68) / 128.0));
                  num73 =  Math.Round( pixel1.R +  (Math.Min( pixel1.R * 2,  byte.MaxValue) -  pixel1.R) * ( (num71 - num68) / 128.0));
                  num74 =  Math.Round( pixel1.B +  (Math.Min( pixel1.B * 2,  byte.MaxValue) -  pixel1.B) * ( (num71 - num68) / 128.0));
                }
                else
                {
                  num72 =  Math.Round( pixel1.G -  Math.Min( pixel1.G * 2,  byte.MaxValue) * ( (num68 - num71) / 128.0));
                  num73 =  Math.Round( pixel1.R -  Math.Min( pixel1.R * 2,  byte.MaxValue) * ( (num68 - num71) / 128.0));
                  num74 =  Math.Round( pixel1.B -  Math.Min( pixel1.B * 2,  byte.MaxValue) * ( (num68 - num71) / 128.0));
                }
                let mut val2_10: i32 =  Math.Round( g * 0.25 +  num72 * 0.75);
                let mut val2_11: i32 =  Math.Round( b * 0.25 +  num74 * 0.75);
                let mut val2_12: i32 =  Math.Round( r * 0.25 +  num73 * 0.75);
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
      bitmap6: Bitmap = new Bitmap(bitmap1.Width, bitmap1.Height);
      bitmap6.SetResolution( DrawMod.DPIx,  DrawMod.DPIy);
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

    pub fn Kill()
    {
      this.TempCounter = (Bitmap) null;
      BitmapStore.RemoveBitmapNr(this.NationalIconSprite);
      BitmapStore.RemoveBitmapNr(this.HQSpriteNr);
    }

    pub fn LoadSprites()
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

    pub fn ReplaceNationalSprite(string filename)
    {
      this.NationalIconSpriteName = filename;
      this.NationalIconSprite = BitmapStore.ReloadFile(this.NationalIconSprite, filename, IsBig: true);
    }

    pub fn ReplaceRoundelSprite(string filename)
    {
      this.RoundelSpriteName = filename;
      this.RoundelIconSprite = BitmapStore.ReloadFile(this.RoundelIconSprite, filename);
    }

    pub fn ReplaceBannerSprite(string filename)
    {
      this.BannerSpriteFileName = filename;
      this.BannerSpriteNr = BitmapStore.ReloadFile(this.BannerSpriteNr, filename);
    }

    pub fn ReplaceSymbolSprite(string filename)
    {
      this.SymbolSpriteName = filename;
      this.SymbolSpriteNr = BitmapStore.ReloadFile(this.SymbolSpriteNr, filename);
    }

    pub fn ReplaceHQSprite(string filename)
    {
      this.HQSpriteFileName = filename;
      this.HQSpriteNr = BitmapStore.AddFile(this.HQSpriteFileName, false, true);
      if (DrawMod.TGame.Data.Product >= 7)
        return;
      this.DoTempCounter();
    }

    pub fn ReplaceRoundelSprite2(string filename)
    {
      this.RoundelSpriteName2 = filename;
      this.RoundelIconSprite2 = BitmapStore.ReloadFile(this.RoundelIconSprite2, filename);
    }

    pub fn ReplaceHQSprite2(string filename)
    {
      this.HQSpriteFileName2 = filename;
      this.HQSpriteNr2 = BitmapStore.AddFile(this.HQSpriteFileName2, false, true);
      if (DrawMod.TGame.Data.Product >= 7)
        return;
      this.DoTempCounter();
    }

    pub fn ReplaceBannerSprite2(string filename)
    {
      this.BannerSpriteFileName2 = filename;
      this.BannerSpriteNr2 = BitmapStore.ReloadFile(this.BannerSpriteNr2, filename);
    }
  }
}
