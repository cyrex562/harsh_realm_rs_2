// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.UnitClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsApplication1
{
  [Serializable]
  public class UnitClass : ISerializable
  {
    public string Name;
    public int SFCount;
    public int[] SFList;
    public int Regime;
    public int HQ;
    public bool IsHQ;
    public int X;
    public int Y;
    public int Map;
    public int LandCap;
    public int NavyCap;
    public int AirCap;
    public bool DidAttack;
    public bool Spotted;
    public bool Identified;
    public int Supply;
    public bool DidMove;
    public bool DidHQ;
    public int offensiveCombat;
    public int defensiveCombat;
    public int MoveAPSpent;
    public int SOInterceptRdnStop;
    public int SODefendPercent;
    public int SOSupReqPercent;
    public int StartIntercept;
    public int SOReplacementPercent;
    public bool SODoAS;
    public int SOInterceptFire;
    public int SOReturnFire;
    public int LastSupplyPercent;
    public int SupplyConsume;
    public int SupplyIn;
    public int Fuel;
    public int FuelRequested;
    public int FuelReceived;
    public int SupplyInReq;
    public int SupplyOut;
    public int SupplyReq;
    public int LandStart;
    public int NavyStart;
    public int AirStart;
    public int LandNeed;
    public int NavyNeed;
    public int AirNeed;
    public int OnBoard;
    public int PassengerCounter;
    public int[] PassengerList;
    public int attachedTo;
    public int TransportCounter;
    public int[] TransportList;
    public int moveMode;
    public int FreeCombatX;
    public int FreeCombatY;
    public int FreeCombatMap;
    public int Red;
    public int Blue;
    public int Green;
    public int PreDef;
    public bool UnitIsGiven;
    public AIPlanClass AIPlanRef;
    public int AIPlanNr;
    public int AIUnitGoal;
    public bool AIMobilize;
    public bool AIDisband;
    public bool AIReserve;
    public int AINavtargetX;
    public int AINavtargetY;
    public int AICutoff;
    public int AISubStrictGroup;
    public bool AIoriginallyEncircled;
    public bool AIoriginallyRetreating;
    public int TempX;
    public int FinalX;
    public int OldX;
    public int TempY;
    public int FinalY;
    public int OldY;
    public int TempSlot;
    public int AIAttack;
    public int AIDefend;
    public int AIFollowup;
    public int AIFallback;
    public int AILeftFlank;
    public int AIRightFlank;
    public int AIGroup;
    public int AIBottleneck;
    public bool IsVirtual;
    public int AIAttackStyle;
    public int SupplyLost;
    public int Reserve;
    public int SetAPToZero;
    public int LastAP;
    public bool LastMove;
    public int TempOldNr;
    public int Historical;
    public int HistoricalSubPart;
    public int TempType;
    public int TempTypeRoad;
    public int TempTheater;
    public int TempCategory;
    public int TempCategory2;
    public int TempArtDam;
    public int TempEncircled;
    public bool TempStrategic;
    public int TempCapType;
    public int TempCapHQ;
    public bool TempAttacked;
    public int TempGroup;
    public string TempAIString;
    public int TempAIGroup;
    public bool TempTopUnit;
    public bool TempProtector;
    public bool TempAIForbidsMove;
    public int TempLisItemPercentage;
    public bool TempJustArrivedFromReserve;
    public int AIid;
    public int TempUnitPower;
    public int TempUnitPowerAbs;
    public int TempUnitAP;
    public float TempCombatImprovePercent;
    public int TempOwner;
    public int StartPower;
    public int AIModel;
    public bool TempUnitSelectable;
    public int FuelUsedMove;
    public int FuelUsedAtt;
    public int FuelUsedDef;
    public int LogCounter;
    public int[] LogType;
    public int[] LogData1;
    public int[] LogData2;
    public int[] LogData3;
    public int StockpileCurrent;
    public ItemList items;
    public SimpleList lisInstructions;
    public SimpleList tempHandledItems;
    public SimpleList tempRequestItems;
    public SimpleList tempMaxItems;
    public int tempLisStartHistory;
    public CoordList tempCoords;
    public ComplexCoordList tempComplexCoords;
    public CoordList prevTurnAiFrontHexes;
    public bool tempCanAttack;
    public bool tempCanAttack2;
    public int apReserve;
    public LibIdClass LibId;
    public int supplyBaseSupplyIn;
    public int supplyBaseFuelIn;
    public int supplyX;
    public int supplyY;
    public int uncertaintyRolls;
    public int uncertaintyRollsCount;
    public int autoMoveX;
    public int autoMoveY;
    public string txtLog;
    public Bitmap tempSFTypeBitmap;
    public long cycleOrder;

    public UnitClass Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      int num = num;
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (UnitClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Name", (object) this.Name);
      info.AddValue("SFCount", this.SFCount);
      info.AddValue("SFList", (object) this.SFList);
      info.AddValue("Regime", this.Regime);
      info.AddValue("Supply", this.Supply);
      info.AddValue("HQ", this.HQ);
      info.AddValue("IsHQ", this.IsHQ);
      info.AddValue("X", this.X);
      info.AddValue("Y", this.Y);
      info.AddValue("LandCap", this.LandCap);
      info.AddValue("NavyCap", this.NavyCap);
      info.AddValue("AirCap", this.AirCap);
      info.AddValue("SOInterceptRdnStop", this.SOInterceptRdnStop);
      info.AddValue("SODefendPercent", this.SODefendPercent);
      info.AddValue("SOSupReqPercent", this.SOSupReqPercent);
      info.AddValue("SOReplacementPercent", this.SOReplacementPercent);
      info.AddValue("LastSupplyPercent", this.LastSupplyPercent);
      info.AddValue("SupplyConsume", this.SupplyConsume);
      info.AddValue("PassengerCounter", this.PassengerCounter);
      info.AddValue("PassengerList", (object) this.PassengerList);
      info.AddValue("FreeCombatX", this.FreeCombatX);
      info.AddValue("FreeCombatY", this.FreeCombatY);
      info.AddValue("FreeCombatMap", this.FreeCombatMap);
      info.AddValue("Red", this.Red);
      info.AddValue("Blue", this.Blue);
      info.AddValue("Green", this.Green);
      info.AddValue("PreDef", this.PreDef);
      info.AddValue("SupplyIn", this.SupplyIn);
      info.AddValue("SupplyInReq", this.SupplyInReq);
      info.AddValue("SupplyOut", this.SupplyOut);
      info.AddValue("SupplyReq", this.SupplyReq);
      info.AddValue("LandStart", this.LandStart);
      info.AddValue("NavyStart", this.NavyStart);
      info.AddValue("AirStart", this.AirStart);
      info.AddValue("LandNeed", this.LandNeed);
      info.AddValue("NavyNeed", this.NavyNeed);
      info.AddValue("AirNeed", this.AirNeed);
      info.AddValue("OnBoard", this.OnBoard);
      info.AddValue("SupplyLost", this.SupplyLost);
      info.AddValue("Reserve", this.Reserve);
      info.AddValue("TransportCounter", this.TransportCounter);
      info.AddValue("TransportList", (object) this.TransportList);
      info.AddValue("attachedTo", this.attachedTo);
      info.AddValue("moveMode", this.moveMode);
      info.AddValue("AIPlanRef", (object) this.AIPlanRef);
      info.AddValue("AIUnitGoal", this.AIUnitGoal);
      info.AddValue("AIMobilize", this.AIMobilize);
      info.AddValue("AINavtargetX", this.AINavtargetX);
      info.AddValue("AINavtargetY", this.AINavtargetY);
      info.AddValue("StartIntercept", this.StartIntercept);
      info.AddValue("SODoAS", this.SODoAS);
      info.AddValue("Historical", this.Historical);
      info.AddValue("HistoricalSubPart", this.HistoricalSubPart);
      info.AddValue("AIAttack", this.AIAttack);
      info.AddValue("AIDefend", this.AIDefend);
      info.AddValue("AIFollowup", this.AIFollowup);
      info.AddValue("AIFallback", this.AIFallback);
      info.AddValue("AILeftFlank", this.AIBottleneck);
      info.AddValue("AIRightFlank", this.AIRightFlank);
      info.AddValue("AIGroup", this.AIGroup);
      info.AddValue("AIAttackStyle", this.AIAttackStyle);
      info.AddValue("StartPower", this.StartPower);
      info.AddValue("DidAttack", this.DidAttack);
      info.AddValue("Spotted", this.Spotted);
      info.AddValue("Identified", this.Identified);
      info.AddValue("Map", this.Map);
      info.AddValue("AIModel", this.AIModel);
      info.AddValue("DidMove", this.DidMove);
      info.AddValue("UnitIsGiven", this.UnitIsGiven);
      info.AddValue("FuelUsedMove", this.FuelUsedMove);
      info.AddValue("FuelUsedAtt", this.FuelUsedAtt);
      info.AddValue("FuelUsedDef", this.FuelUsedDef);
      info.AddValue("LogCounter", this.LogCounter);
      info.AddValue("LogType", (object) this.LogType);
      info.AddValue("LogData1", (object) this.LogData1);
      info.AddValue("LogData2", (object) this.LogData2);
      info.AddValue("LogData3", (object) this.LogData3);
      info.AddValue("StockpileCurrent", this.StockpileCurrent);
      info.AddValue("DidHQ", this.DidHQ);
      info.AddValue("offensiveCombat", this.offensiveCombat);
      info.AddValue("defensiveCombat", this.defensiveCombat);
      info.AddValue("moveApSpent", this.MoveAPSpent);
      info.AddValue("LibId", (object) this.LibId);
      info.AddValue("AISubStrictGroup", this.AISubStrictGroup);
      info.AddValue("SOInterceptFire", this.SOInterceptFire);
      info.AddValue("SOReturnFire", this.SOReturnFire);
      info.AddValue("Fuel", this.Fuel);
      info.AddValue("FuelRequested", this.FuelRequested);
      info.AddValue("FuelReceived", this.FuelReceived);
      info.AddValue("supplyBaseSupplyIn", this.supplyBaseSupplyIn);
      info.AddValue("supplyBaseFuelIn", this.supplyBaseFuelIn);
      if (Information.IsNothing((object) this.items))
        this.items = new ItemList();
      info.AddValue("items", (object) this.items);
      if (Information.IsNothing((object) this.lisInstructions))
        this.lisInstructions = new SimpleList();
      info.AddValue("lisInstructions", (object) this.lisInstructions);
      info.AddValue("ApReserve", this.apReserve);
      info.AddValue("supplyX", this.supplyX);
      info.AddValue("supplyY", this.supplyY);
      info.AddValue("prevTurnAiFrontHexes", (object) this.prevTurnAiFrontHexes);
      info.AddValue("cycleOrder", this.cycleOrder);
    }

    protected UnitClass(SerializationInfo info, StreamingContext context)
    {
      this.SFList = new int[1];
      this.PassengerList = new int[1];
      this.TransportList = new int[1];
      this.moveMode = 0;
      this.LogType = new int[1];
      this.LogData1 = new int[1];
      this.LogData2 = new int[1];
      this.LogData3 = new int[1];
      this.txtLog = "";
      this.Name = info.GetString(nameof (Name));
      this.SFCount = info.GetInt32(nameof (SFCount));
      this.SFList = this.SFCount <= -1 ? new int[1] : new int[this.SFCount + 1];
      this.SFList = (int[]) info.GetValue(nameof (SFList), this.SFList.GetType());
      this.Regime = info.GetInt32(nameof (Regime));
      this.Supply = info.GetInt32(nameof (Supply));
      this.HQ = info.GetInt32(nameof (HQ));
      this.IsHQ = info.GetBoolean(nameof (IsHQ));
      this.X = info.GetInt32(nameof (X));
      this.Y = info.GetInt32(nameof (Y));
      this.LandCap = info.GetInt32(nameof (LandCap));
      this.NavyCap = info.GetInt32(nameof (NavyCap));
      this.AirCap = info.GetInt32(nameof (AirCap));
      this.SOInterceptRdnStop = info.GetInt32(nameof (SOInterceptRdnStop));
      this.SODefendPercent = info.GetInt32(nameof (SODefendPercent));
      this.SOSupReqPercent = info.GetInt32(nameof (SOSupReqPercent));
      this.LastSupplyPercent = info.GetInt32(nameof (LastSupplyPercent));
      this.SupplyConsume = info.GetInt32(nameof (SupplyConsume));
      this.PassengerCounter = info.GetInt32(nameof (PassengerCounter));
      this.PassengerList = this.PassengerCounter <= -1 ? new int[1] : new int[this.PassengerCounter + 1];
      this.PassengerList = (int[]) info.GetValue(nameof (PassengerList), this.PassengerList.GetType());
      this.FreeCombatX = info.GetInt32(nameof (FreeCombatX));
      this.FreeCombatY = info.GetInt32(nameof (FreeCombatY));
      this.Red = info.GetInt32(nameof (Red));
      this.Green = info.GetInt32(nameof (Green));
      this.Blue = info.GetInt32(nameof (Blue));
      this.PreDef = info.GetInt32(nameof (PreDef));
      this.SupplyIn = info.GetInt32(nameof (SupplyIn));
      this.SupplyInReq = info.GetInt32(nameof (SupplyInReq));
      this.SupplyOut = info.GetInt32(nameof (SupplyOut));
      this.SupplyReq = info.GetInt32(nameof (SupplyReq));
      this.LandStart = info.GetInt32(nameof (LandStart));
      this.NavyStart = info.GetInt32(nameof (NavyStart));
      this.AirStart = info.GetInt32(nameof (AirStart));
      this.LandNeed = info.GetInt32(nameof (LandNeed));
      this.NavyNeed = info.GetInt32(nameof (NavyNeed));
      this.AirNeed = info.GetInt32(nameof (AirNeed));
      this.OnBoard = info.GetInt32(nameof (OnBoard));
      this.SupplyLost = info.GetInt32(nameof (SupplyLost));
      this.Reserve = info.GetInt32(nameof (Reserve));
      this.AIPlanRef = (AIPlanClass) info.GetValue(nameof (AIPlanRef), typeof (AIPlanClass));
      this.AIUnitGoal = info.GetInt32(nameof (AIUnitGoal));
      this.AIMobilize = info.GetBoolean(nameof (AIMobilize));
      this.AINavtargetX = info.GetInt32(nameof (AINavtargetX));
      this.AINavtargetY = info.GetInt32(nameof (AINavtargetY));
      this.StartIntercept = info.GetInt32(nameof (StartIntercept));
      this.SODoAS = info.GetBoolean(nameof (SODoAS));
      this.LastMove = false;
      this.LastAP = -1;
      if (DrawMod.TGame.Data.Version < 130)
      {
        this.SOReplacementPercent = 100;
        this.FreeCombatMap = 0;
        this.Historical = -1;
        this.HistoricalSubPart = -1;
        this.AIAttack = -1;
        this.AIDefend = -1;
        this.AILeftFlank = -1;
        this.AIRightFlank = -1;
        this.AIFallback = -1;
        this.AIFollowup = -1;
        this.AIGroup = -1;
        this.AIAttackStyle = 2;
        this.StartPower = 0;
        this.DidAttack = false;
        this.Spotted = false;
        this.Identified = false;
        this.Map = 0;
        this.AIModel = -1;
        this.UnitIsGiven = false;
      }
      else if (DrawMod.TGame.Data.Version < 158)
      {
        try
        {
          this.SOReplacementPercent = info.GetInt32(nameof (SOReplacementPercent));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.SOReplacementPercent = 100;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.FreeCombatMap = info.GetInt32(nameof (FreeCombatMap));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.FreeCombatMap = 0;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.Historical = info.GetInt32(nameof (Historical));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.Historical = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.HistoricalSubPart = info.GetInt32(nameof (HistoricalSubPart));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.HistoricalSubPart = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.AIAttack = info.GetInt32(nameof (AIAttack));
          this.AIDefend = info.GetInt32(nameof (AIDefend));
          this.AIFollowup = info.GetInt32(nameof (AIFollowup));
          this.AIFallback = info.GetInt32(nameof (AIFallback));
          this.AILeftFlank = -1;
          this.AIBottleneck = info.GetInt32(nameof (AILeftFlank));
          this.AIRightFlank = info.GetInt32(nameof (AIRightFlank));
          this.AIGroup = info.GetInt32(nameof (AIGroup));
          this.AIAttackStyle = info.GetInt32(nameof (AIAttackStyle));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.AIAttack = -1;
          this.AIDefend = -1;
          this.AILeftFlank = -1;
          this.AIRightFlank = -1;
          this.AIFallback = -1;
          this.AIFollowup = -1;
          this.AIGroup = -1;
          this.AIAttackStyle = 2;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.StartPower = info.GetInt32(nameof (StartPower));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.StartPower = 0;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.DidAttack = info.GetBoolean(nameof (DidAttack));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.DidAttack = false;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.Spotted = info.GetBoolean(nameof (Spotted));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.Spotted = false;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.Identified = info.GetBoolean(nameof (Identified));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.Identified = false;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.Map = info.GetInt32(nameof (Map));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.Map = 0;
          ProjectData.ClearProjectError();
        }
        this.AIModel = -1;
        this.UnitIsGiven = false;
      }
      else
      {
        this.SOReplacementPercent = info.GetInt32(nameof (SOReplacementPercent));
        this.FreeCombatMap = info.GetInt32(nameof (FreeCombatMap));
        this.Historical = info.GetInt32(nameof (Historical));
        this.HistoricalSubPart = info.GetInt32(nameof (HistoricalSubPart));
        this.AIAttack = info.GetInt32(nameof (AIAttack));
        this.AIDefend = info.GetInt32(nameof (AIDefend));
        this.AIFollowup = info.GetInt32(nameof (AIFollowup));
        this.AIFallback = info.GetInt32(nameof (AIFallback));
        this.AILeftFlank = info.GetInt32(nameof (AILeftFlank));
        this.AIRightFlank = info.GetInt32(nameof (AIRightFlank));
        this.AIGroup = info.GetInt32(nameof (AIGroup));
        this.AIAttackStyle = info.GetInt32(nameof (AIAttackStyle));
        this.StartPower = info.GetInt32(nameof (StartPower));
        this.DidAttack = info.GetBoolean(nameof (DidAttack));
        this.Map = info.GetInt32(nameof (Map));
        try
        {
          this.AIModel = info.GetInt32(nameof (AIModel));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.AIModel = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.DidMove = info.GetBoolean(nameof (DidMove));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.DidMove = false;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.UnitIsGiven = info.GetBoolean(nameof (UnitIsGiven));
          this.FuelUsedMove = info.GetInt32(nameof (FuelUsedMove));
          this.FuelUsedAtt = info.GetInt32(nameof (FuelUsedAtt));
          this.FuelUsedDef = info.GetInt32(nameof (FuelUsedDef));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.UnitIsGiven = false;
          this.FuelUsedMove = 0;
          this.FuelUsedAtt = 0;
          this.FuelUsedDef = 0;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.Spotted = info.GetBoolean(nameof (Spotted));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.Spotted = false;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.Identified = info.GetBoolean(nameof (Identified));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.Identified = false;
          ProjectData.ClearProjectError();
        }
      }
      try
      {
        this.LogCounter = info.GetInt32(nameof (LogCounter));
        this.LogType = new int[this.LogCounter + 1];
        this.LogData1 = new int[this.LogCounter + 1];
        this.LogData2 = new int[this.LogCounter + 1];
        this.LogData3 = new int[this.LogCounter + 1];
        this.LogType = (int[]) info.GetValue(nameof (LogType), this.LogType.GetType());
        this.LogData1 = (int[]) info.GetValue(nameof (LogData1), this.LogData1.GetType());
        this.LogData2 = (int[]) info.GetValue(nameof (LogData2), this.LogData2.GetType());
        this.LogData3 = (int[]) info.GetValue(nameof (LogData3), this.LogData3.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.LogCounter = -1;
        this.LogType = new int[1];
        this.LogData1 = new int[1];
        this.LogData2 = new int[1];
        this.LogData3 = new int[1];
        ProjectData.ClearProjectError();
      }
      try
      {
        this.StockpileCurrent = info.GetInt32(nameof (StockpileCurrent));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.StockpileCurrent = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.DidHQ = info.GetBoolean(nameof (DidHQ));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.DidHQ = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.offensiveCombat = info.GetInt32(nameof (offensiveCombat));
        this.defensiveCombat = info.GetInt32(nameof (defensiveCombat));
        this.MoveAPSpent = info.GetInt32("moveApSpent");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.offensiveCombat = 0;
        this.defensiveCombat = 0;
        this.MoveAPSpent = 0;
        ProjectData.ClearProjectError();
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
        ProjectData.ClearProjectError();
      }
      try
      {
        this.AISubStrictGroup = info.GetInt32(nameof (AISubStrictGroup));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.AISubStrictGroup = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.TransportCounter = info.GetInt32(nameof (TransportCounter));
        this.TransportList = this.TransportCounter <= -1 ? new int[1] : new int[this.TransportCounter + 1];
        this.TransportList = (int[]) info.GetValue(nameof (TransportList), this.TransportList.GetType());
        this.attachedTo = info.GetInt32(nameof (attachedTo));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.TransportCounter = -1;
        this.TransportList = new int[1];
        this.attachedTo = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.moveMode = info.GetInt32(nameof (moveMode));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.moveMode = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        if (Information.IsNothing((object) this.items))
          this.items = new ItemList();
        this.items = (ItemList) info.GetValue(nameof (items), this.items.GetType());
        if (Information.IsNothing((object) this.items))
          this.items = new ItemList();
        if (Information.IsNothing((object) this.lisInstructions))
          this.lisInstructions = new SimpleList();
        this.lisInstructions = (SimpleList) info.GetValue(nameof (lisInstructions), this.lisInstructions.GetType());
        if (Information.IsNothing((object) this.lisInstructions))
          this.lisInstructions = new SimpleList();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.items = new ItemList();
        this.lisInstructions = new SimpleList();
        ProjectData.ClearProjectError();
      }
      try
      {
        this.Fuel = info.GetInt32(nameof (Fuel));
        this.FuelRequested = info.GetInt32(nameof (FuelRequested));
        this.FuelReceived = info.GetInt32(nameof (FuelReceived));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Fuel = 0;
        this.FuelReceived = 0;
        this.FuelRequested = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.supplyBaseSupplyIn = info.GetInt32(nameof (supplyBaseSupplyIn));
        this.supplyBaseFuelIn = info.GetInt32(nameof (supplyBaseFuelIn));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.supplyBaseSupplyIn = 0;
        this.supplyBaseFuelIn = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.SOInterceptFire = info.GetInt32(nameof (SOInterceptFire));
        this.SOReturnFire = info.GetInt32(nameof (SOReturnFire));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.SOInterceptFire = 33;
        this.SOReturnFire = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.apReserve = info.GetInt32("ApReserve");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.apReserve = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.supplyX = info.GetInt32(nameof (supplyX));
        this.supplyY = info.GetInt32(nameof (supplyY));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.supplyX = -1;
        this.supplyY = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.prevTurnAiFrontHexes = new CoordList();
        this.prevTurnAiFrontHexes = (CoordList) info.GetValue(nameof (prevTurnAiFrontHexes), this.prevTurnAiFrontHexes.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.prevTurnAiFrontHexes = (CoordList) null;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.cycleOrder = info.GetInt64(nameof (cycleOrder));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.cycleOrder = 0L;
        ProjectData.ClearProjectError();
      }
      this.TempOwner = -1;
      this.TempCapType = -1;
      this.TempCapHQ = -1;
    }

    public void AddLog(int type, int data1, int data2, int data3)
    {
      int num1 = -1;
      if (Strings.InStr(this.Name, "LVIII") > 0)
        num1 = num1;
      if (type == 605)
        num1 = num1;
      int logCounter = this.LogCounter;
      for (int index = 0; index <= logCounter; ++index)
      {
        if (this.LogType[index] == type & this.LogData1[index] == data1 & this.LogData2[index] == data2)
        {
          num1 = index;
          break;
        }
      }
      if (num1 == -1)
      {
        ++this.LogCounter;
        this.LogType = (int[]) Utils.CopyArray((Array) this.LogType, (Array) new int[this.LogCounter + 1]);
        this.LogData1 = (int[]) Utils.CopyArray((Array) this.LogData1, (Array) new int[this.LogCounter + 1]);
        this.LogData2 = (int[]) Utils.CopyArray((Array) this.LogData2, (Array) new int[this.LogCounter + 1]);
        this.LogData3 = (int[]) Utils.CopyArray((Array) this.LogData3, (Array) new int[this.LogCounter + 1]);
        this.LogType[this.LogCounter] = type;
        this.LogData1[this.LogCounter] = data1;
        this.LogData2[this.LogCounter] = data2;
        this.LogData3[this.LogCounter] = data3;
      }
      else
      {
        int[] logData3 = this.LogData3;
        int[] numArray = logData3;
        int index1 = num1;
        int index2 = index1;
        int num2 = logData3[index1] + data3;
        numArray[index2] = num2;
      }
    }

    public void SetLog(int type, int data1, int data2, int data3)
    {
      int index1 = -1;
      int logCounter = this.LogCounter;
      for (int index2 = 0; index2 <= logCounter; ++index2)
      {
        if (this.LogType[index2] == type & this.LogData1[index2] == data1 & this.LogData2[index2] == data2)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 == -1)
      {
        ++this.LogCounter;
        this.LogType = (int[]) Utils.CopyArray((Array) this.LogType, (Array) new int[this.LogCounter + 1]);
        this.LogData1 = (int[]) Utils.CopyArray((Array) this.LogData1, (Array) new int[this.LogCounter + 1]);
        this.LogData2 = (int[]) Utils.CopyArray((Array) this.LogData2, (Array) new int[this.LogCounter + 1]);
        this.LogData3 = (int[]) Utils.CopyArray((Array) this.LogData3, (Array) new int[this.LogCounter + 1]);
        this.LogType[this.LogCounter] = type;
        this.LogData1[this.LogCounter] = data1;
        this.LogData2[this.LogCounter] = data2;
        this.LogData3[this.LogCounter] = data3;
      }
      else
        this.LogData3[index1] = data3;
    }

    public int CheckLogReturnData3(int type, int data1)
    {
      int logCounter = this.LogCounter;
      for (int index = 0; index <= logCounter; ++index)
      {
        if (this.LogType[index] == type & (this.LogData1[index] == data1 | data1 == -1))
          return this.LogData3[index];
      }
      return 0;
    }

    public void ClearLogs()
    {
      this.LogCounter = -1;
      this.LogType = (int[]) Utils.CopyArray((Array) this.LogType, (Array) new int[1]);
      this.LogData1 = (int[]) Utils.CopyArray((Array) this.LogData1, (Array) new int[1]);
      this.LogData2 = (int[]) Utils.CopyArray((Array) this.LogData2, (Array) new int[1]);
      this.LogData3 = (int[]) Utils.CopyArray((Array) this.LogData3, (Array) new int[1]);
    }

    public void AddSF(int sfnr)
    {
      ++this.SFCount;
      this.SFList = (int[]) Utils.CopyArray((Array) this.SFList, (Array) new int[this.SFCount + 1]);
      this.SFList[this.SFCount] = sfnr;
    }

    public void RemoveSF(int sfnr)
    {
      int sfCount = this.SFCount;
      for (int index1 = 0; index1 <= sfCount; ++index1)
      {
        if (this.SFList[index1] == sfnr)
        {
          if (index1 < this.SFCount)
          {
            int num1 = index1;
            int num2 = this.SFCount - 1;
            for (int index2 = num1; index2 <= num2; ++index2)
              this.SFList[index2] = this.SFList[index2 + 1];
          }
          --this.SFCount;
          this.SFList = (int[]) Utils.CopyArray((Array) this.SFList, (Array) new int[this.SFCount + 1]);
          break;
        }
      }
    }

    public void AddPassenger(int pnr)
    {
      ++this.PassengerCounter;
      this.PassengerList = (int[]) Utils.CopyArray((Array) this.PassengerList, (Array) new int[this.PassengerCounter + 1]);
      this.PassengerList[this.PassengerCounter] = pnr;
    }

    public void RemovePassenger(int pnr)
    {
      int passengerCounter = this.PassengerCounter;
      for (int index1 = 0; index1 <= passengerCounter; ++index1)
      {
        if (this.PassengerList[index1] == pnr)
        {
          if (index1 < this.PassengerCounter)
          {
            int num1 = index1;
            int num2 = this.PassengerCounter - 1;
            for (int index2 = num1; index2 <= num2; ++index2)
              this.PassengerList[index2] = this.PassengerList[index2 + 1];
          }
          --this.PassengerCounter;
          this.PassengerList = (int[]) Utils.CopyArray((Array) this.PassengerList, (Array) new int[this.PassengerCounter + 1]);
          break;
        }
      }
    }

    public void AddTransport(int pnr)
    {
      ++this.TransportCounter;
      this.TransportList = (int[]) Utils.CopyArray((Array) this.TransportList, (Array) new int[this.TransportCounter + 1]);
      this.TransportList[this.TransportCounter] = pnr;
    }

    public void RemoveTransport(int pnr)
    {
      int transportCounter = this.TransportCounter;
      for (int index1 = 0; index1 <= transportCounter; ++index1)
      {
        if (this.TransportList[index1] == pnr)
        {
          if (index1 < this.TransportCounter)
          {
            int num1 = index1;
            int num2 = this.TransportCounter - 1;
            for (int index2 = num1; index2 <= num2; ++index2)
              this.TransportList[index2] = this.TransportList[index2 + 1];
          }
          --this.TransportCounter;
          this.TransportList = (int[]) Utils.CopyArray((Array) this.TransportList, (Array) new int[this.TransportCounter + 1]);
          break;
        }
      }
    }

    public UnitClass(int hardcoded)
    {
      this.SFList = new int[1];
      this.PassengerList = new int[1];
      this.TransportList = new int[1];
      this.moveMode = 0;
      this.LogType = new int[1];
      this.LogData1 = new int[1];
      this.LogData2 = new int[1];
      this.LogData3 = new int[1];
      this.txtLog = "";
      this.Name = "New Unit";
      this.SFCount = -1;
      this.AIModel = -1;
      this.TempGroup = -1;
      this.txtLog = "";
      this.Regime = -1;
      this.HQ = -1;
      this.IsHQ = false;
      this.cycleOrder = 0L;
      this.uncertaintyRolls = 0;
      this.uncertaintyRollsCount = 0;
      this.autoMoveX = -1;
      this.autoMoveY = -1;
      this.supplyX = -1;
      this.supplyY = -1;
      this.TempCapType = -1;
      this.TempCapHQ = -1;
      this.Supply = 0;
      this.PassengerCounter = -1;
      this.TransportCounter = -1;
      this.attachedTo = -1;
      this.moveMode = 0;
      this.OnBoard = -1;
      this.FreeCombatX = -1;
      this.FreeCombatY = -1;
      this.Red = (int) Math.Round((double) VBMath.Rnd() * 215.0 + 40.0);
      this.Green = (int) Math.Round((double) VBMath.Rnd() * 215.0 + 40.0);
      this.Blue = (int) Math.Round((double) VBMath.Rnd() * 215.0 + 40.0);
      this.PreDef = -1;
      this.SODoAS = true;
      this.Historical = -1;
      this.apReserve = 0;
      this.AIAttack = -1;
      this.AIDefend = -1;
      this.AILeftFlank = -1;
      this.AIRightFlank = -1;
      this.AIFallback = -1;
      this.AIFollowup = -1;
      this.SOReplacementPercent = 100;
      this.SOSupReqPercent = 100;
      this.SOInterceptRdnStop = 100;
      this.SODefendPercent = 50;
      this.SupplyConsume = 100;
      this.Map = 0;
      this.TempOwner = -1;
      this.LibId = new LibIdClass();
      this.AISubStrictGroup = -1;
      this.SOInterceptFire = 33;
      this.SOReturnFire = 0;
      this.supplyBaseSupplyIn = 0;
      this.supplyBaseFuelIn = 0;
      this.items = new ItemList();
      this.lisInstructions = new SimpleList();
    }

    public void ResetAI()
    {
      this.AIAttack = -1;
      this.AIDefend = -1;
      this.AILeftFlank = -1;
      this.AIRightFlank = -1;
      this.AIFallback = -1;
      this.AIFollowup = -1;
    }

    public int RealX(ref GameClass game) => this.OnBoard > -1 ? game.Data.UnitObj[this.OnBoard].X : this.X;

    public int RealY(ref GameClass game) => this.OnBoard > -1 ? game.Data.UnitObj[this.OnBoard].Y : this.Y;

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public void Kill()
    {
      if (this.SFCount <= -1)
        return;
      int num = (int) Interaction.MsgBox((object) "Programm attempting to delete Unit with Subformations in it. END.", Title: ((object) "Error"));
      ProjectData.EndApp();
    }

    public void LoadSprites()
    {
    }
  }
}
