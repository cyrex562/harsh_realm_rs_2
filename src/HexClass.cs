// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.HexClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsApplication1
{
  [Serializable]
  public class HexClass : ISerializable
  {
    public int LandscapeType;
    public int SpriteNr;
    public int[] RoadType;
    public int[] RiverType;
    public int Regime;
    public int UnitCounter;
    public int[] UnitList;
    public int Location;
    public int Location2;
    public int SpecialType;
    public int SpecialSprite;
    public int SpecialType2;
    public int SpecialSprite2;
    public int SpecialType3;
    public int SpecialSprite3;
    public int DammageVisible;
    public bool[] Bridge;
    public int RegimeCount;
    public int RegimeFullCount;
    public int[] tAPPenalty;
    public int[] AreaCode;
    public int HexLibVarCounter;
    public int[] HexLibVarSlotNr;
    public int[] HexLibVarValue;
    public int DammageToInfra;
    public int[] tDammagePerRegime;
    public int[] tSeeNow;
    public int[] tLastLT;
    public int[] tLastSpr;
    public int[] tLastReg;
    public int[] tReconPts;
    public int[] tZOCPts;
    public int[] tPowerPointsKilled;
    public int[] tSupplyKilled;
    public int[] tPowerPointsLost;
    public int[] tSupplyLost;
    public int MaxRecon;
    public int MaxLos;
    public int MaxObstruct;
    public int VP;
    public string Name;
    public string LabelText1;
    public string LabelText2;
    public int LabelType1;
    public int LabelType2;
    public int CardUponConquest;
    public int[] tBattleStack;
    public int[] tBattlePenalty;
    public int[] tBattleStackAir;
    public int[] tBattleStackArt;
    public int[] ConnectionX;
    public int[] ConnectionY;
    public int ConnectionCount;
    public int[] ConnectionMap;
    public int TempOwner;
    public int TempPowerAbove;
    public int TempPowerMulti;
    public int TempGuiFrontZone;
    public int OrigOwner;
    public int randomOverrule;
    public string SmallLabel;
    public int SmallLabelType;
    public int[] LISpoints;
    public int[] LIShistory;
    public int[] LIStotalHistory;
    public int[] LISorganic;
    public int[] LISpull;
    public int[] LISorganicPercentage;
    public int[] tempOldLISpoints;
    public int[] tempPreviewLIS;
    public int[] tempPreviewAssetLIS;
    public int[] tempPreviewPull;
    public int[] tempPreviewRoadPull;
    public SimpleList tempLISjumps;
    public int HeightLevel;
    public int FuzzyBlock;
    public WindowsApplication1.UnitList tempInterceptList;
    public bool tempFireListEntry;
    public bool tempSelectable;
    public int tempDc4_var1;

    public int get_SeeNow(int Index) => Index > this.RegimeFullCount ? 1 : this.tSeeNow[Index];

    public void set_SeeNow(int Index, int value)
    {
      if (Index > this.RegimeFullCount)
        return;
      this.tSeeNow[Index] = value;
    }

    public int get_LastLT(int Index) => Index > this.RegimeFullCount ? this.LandscapeType : this.tLastLT[Index];

    public void set_LastLT(int Index, int value)
    {
      if (Index > this.RegimeFullCount)
        return;
      this.tLastLT[Index] = value;
    }

    public int get_APPenalty(int Index) => Index > this.RegimeFullCount ? 0 : this.tAPPenalty[Index];

    public void set_APPenalty(int Index, int value)
    {
      if (Index > this.RegimeFullCount)
        return;
      this.tAPPenalty[Index] = value;
    }

    public int get_DammagePerRegime(int Index) => Index > this.RegimeFullCount ? 0 : this.tDammagePerRegime[Index];

    public void set_DammagePerRegime(int Index, int value)
    {
      if (Index > this.RegimeFullCount)
        return;
      this.tDammagePerRegime[Index] = value;
    }

    public int get_LastReg(int Index) => Index > this.RegimeFullCount ? this.Regime : this.tLastReg[Index];

    public void set_LastReg(int Index, int value)
    {
      if (Index > this.RegimeFullCount)
        return;
      this.tLastReg[Index] = value;
    }

    public int get_BattleStack(int Index) => Index > this.RegimeFullCount ? 0 : this.tBattleStack[Index];

    public void set_BattleStack(int Index, int value)
    {
      if (Index > this.RegimeFullCount)
        return;
      this.tBattleStack[Index] = value;
    }

    public int get_BattleStackAir(int Index) => Index > this.RegimeFullCount ? 0 : this.tBattleStackAir[Index];

    public void set_BattleStackAir(int Index, int value)
    {
      if (Index > this.RegimeFullCount)
        return;
      this.tBattleStackAir[Index] = value;
    }

    public int get_BattleStackArt(int Index) => Index > this.RegimeFullCount ? 0 : this.tBattleStackArt[Index];

    public void set_BattleStackArt(int Index, int value)
    {
      if (Index > this.RegimeFullCount)
        return;
      this.tBattleStackArt[Index] = value;
    }

    public int get_LastSpr(int Index) => Index > this.RegimeFullCount ? this.SpriteNr : this.tLastSpr[Index];

    public void set_LastSpr(int Index, int value)
    {
      if (Index > this.RegimeFullCount)
        return;
      this.tLastSpr[Index] = value;
    }

    public int get_PowerPointsKilled(int Index) => Index > this.RegimeFullCount ? 0 : this.tPowerPointsKilled[Index];

    public void set_PowerPointsKilled(int Index, int value)
    {
      if (Index > this.RegimeFullCount)
        return;
      this.tPowerPointsKilled[Index] = value;
    }

    public int get_PowerPointsLost(int Index) => Index > this.RegimeFullCount ? 0 : this.tPowerPointsLost[Index];

    public void set_PowerPointsLost(int Index, int value)
    {
      if (Index > this.RegimeFullCount)
        return;
      this.tPowerPointsLost[Index] = value;
    }

    public int get_SupplyLost(int Index) => Index > this.RegimeFullCount ? 0 : this.tSupplyLost[Index];

    public void set_SupplyLost(int Index, int value)
    {
      if (Index > this.RegimeFullCount)
        return;
      this.tSupplyLost[Index] = value;
    }

    public int get_SupplyKilled(int Index) => Index > this.RegimeFullCount ? 0 : this.tSupplyKilled[Index];

    public void set_SupplyKilled(int Index, int value)
    {
      if (Index > this.RegimeFullCount)
        return;
      this.tSupplyKilled[Index] = value;
    }

    public int get_BattlePenalty(int Index) => Index > this.RegimeFullCount ? 0 : this.tBattlePenalty[Index];

    public void set_BattlePenalty(int Index, int value)
    {
      if (Index > this.RegimeFullCount)
        return;
      this.tBattlePenalty[Index] = value;
    }

    public int get_ReconPts(int Index) => this.tReconPts[Index];

    public void set_ReconPts(int Index, int value) => this.tReconPts[Index] = value;

    public int get_ZocPts(int Index) => this.tZOCPts[Index];

    public void set_ZocPts(int Index, int value) => this.tZOCPts[Index] = value;

    public HexClass(int lt, int regcount, int fullRegCount)
    {
      this.RoadType = new int[6];
      this.RiverType = new int[6];
      this.UnitList = new int[1];
      this.Bridge = new bool[6];
      this.tAPPenalty = new int[1];
      this.AreaCode = new int[10];
      this.HexLibVarSlotNr = new int[1];
      this.HexLibVarValue = new int[1];
      this.tDammagePerRegime = new int[1];
      this.tSeeNow = new int[1];
      this.tLastLT = new int[1];
      this.tLastSpr = new int[1];
      this.tLastReg = new int[1];
      this.tReconPts = new int[1];
      this.tZOCPts = new int[1];
      this.tPowerPointsKilled = new int[1];
      this.tSupplyKilled = new int[1];
      this.tPowerPointsLost = new int[1];
      this.tSupplyLost = new int[1];
      this.tBattleStack = new int[1];
      this.tBattlePenalty = new int[1];
      this.tBattleStackAir = new int[1];
      this.tBattleStackArt = new int[1];
      this.ConnectionX = new int[1];
      this.ConnectionY = new int[1];
      this.ConnectionMap = new int[1];
      this.LISpoints = new int[9];
      this.LIShistory = new int[9];
      this.LIStotalHistory = new int[9];
      this.LISorganic = new int[9];
      this.LISpull = new int[9];
      this.LISorganicPercentage = new int[9];
      this.tempOldLISpoints = new int[9];
      this.tempPreviewLIS = new int[9];
      this.tempPreviewAssetLIS = new int[9];
      this.tempPreviewPull = new int[9];
      this.tempPreviewRoadPull = new int[9];
      this.LandscapeType = lt;
      this.SpriteNr = 0;
      this.SpecialSprite = -1;
      this.SpecialSprite2 = -1;
      this.SpecialSprite3 = -1;
      this.SpecialType = -1;
      this.tempInterceptList = (WindowsApplication1.UnitList) null;
      this.SpecialType2 = -1;
      this.SpecialType3 = -1;
      this.Regime = -1;
      this.Location = -1;
      this.TempOwner = -1;
      this.Location2 = -1;
      this.OrigOwner = -1;
      this.HexLibVarCounter = -1;
      this.SmallLabel = "";
      this.ConnectionCount = -1;
      this.SmallLabelType = 0;
      this.randomOverrule = -1;
      this.HeightLevel = 0;
      this.TempGuiFrontZone = 0;
      this.FuzzyBlock = 0;
      this.MaxLos = 0;
      this.MaxObstruct = 0;
      int index1 = 0;
      do
      {
        this.RoadType[index1] = -1;
        this.Bridge[index1] = false;
        this.RiverType[index1] = -1;
        ++index1;
      }
      while (index1 <= 5);
      this.UnitCounter = -1;
      this.RegimeCount = regcount;
      this.RegimeFullCount = fullRegCount;
      if (fullRegCount > 0)
      {
        this.tSeeNow = new int[fullRegCount + 1];
        this.tLastLT = new int[fullRegCount + 1];
        this.tAPPenalty = new int[fullRegCount + 1];
        this.tLastSpr = new int[fullRegCount + 1];
        this.tLastReg = new int[fullRegCount + 1];
        this.tPowerPointsKilled = new int[fullRegCount + 1];
        this.tSupplyKilled = new int[fullRegCount + 1];
        this.tDammagePerRegime = new int[fullRegCount + 1];
        this.tPowerPointsLost = new int[fullRegCount + 1];
        this.tSupplyLost = new int[fullRegCount + 1];
        this.tBattleStack = new int[fullRegCount + 1];
        this.tBattleStackAir = new int[fullRegCount + 1];
        this.tBattleStackArt = new int[fullRegCount + 1];
        this.tBattlePenalty = new int[fullRegCount + 1];
      }
      int num1 = fullRegCount;
      for (int index2 = 0; index2 <= num1; ++index2)
      {
        this.tSeeNow[index2] = 0;
        this.tLastLT[index2] = -1;
        this.tLastSpr[index2] = -1;
        this.tLastReg[index2] = -1;
        this.tPowerPointsKilled[index2] = 0;
        this.tSupplyKilled[index2] = 0;
        this.tDammagePerRegime[index2] = 0;
        this.tPowerPointsLost[index2] = 0;
        this.tSupplyLost[index2] = 0;
        this.tBattleStack[index2] = 0;
        this.tBattleStackAir[index2] = 0;
        this.tBattleStackArt[index2] = 0;
        this.tBattlePenalty[index2] = 0;
      }
      if (regcount > 0)
      {
        this.tReconPts = new int[regcount + 1];
        this.tZOCPts = new int[regcount + 1];
      }
      int num2 = regcount;
      for (int Index = 0; Index <= num2; ++Index)
      {
        this.set_ReconPts(Index, 0);
        this.set_ZocPts(Index, 0);
      }
      this.LabelType1 = 0;
      this.LabelType2 = 0;
      this.CardUponConquest = -1;
    }

    public HexClass Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (HexClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    public void StreamRead(ref BinaryReader br)
    {
      int num = br.ReadInt32();
      this.LandscapeType = br.ReadInt32();
      this.SpriteNr = br.ReadInt32();
      int index1 = 0;
      do
      {
        this.RoadType[index1] = br.ReadInt32();
        this.RiverType[index1] = br.ReadInt32();
        this.Bridge[index1] = br.ReadBoolean();
        ++index1;
      }
      while (index1 <= 5);
      this.Regime = br.ReadInt32();
      this.UnitCounter = br.ReadInt32();
      if (this.UnitCounter > -1)
        this.UnitList = new int[this.UnitCounter + 1];
      int unitCounter = this.UnitCounter;
      for (int index2 = 0; index2 <= unitCounter; ++index2)
        this.UnitList[index2] = br.ReadInt32();
      this.Location = br.ReadInt32();
      this.DammageToInfra = br.ReadInt32();
      this.DammageVisible = br.ReadInt32();
      this.VP = br.ReadInt32();
      this.Name = br.ReadString();
      this.RegimeCount = br.ReadInt32();
      if (num >= 16)
        this.RegimeFullCount = br.ReadInt32();
      if (num < 16)
      {
        this.RegimeFullCount = this.RegimeCount;
        if (this.RegimeCount > -1)
        {
          this.tAPPenalty = new int[this.RegimeCount + 1];
          this.tSeeNow = new int[this.RegimeCount + 1];
          this.tLastLT = new int[this.RegimeCount + 1];
          this.tLastSpr = new int[this.RegimeCount + 1];
          this.tLastReg = new int[this.RegimeCount + 1];
          this.tReconPts = new int[this.RegimeCount + 1];
          this.tZOCPts = new int[this.RegimeCount + 1];
          this.tPowerPointsKilled = new int[this.RegimeCount + 1];
          this.tSupplyKilled = new int[this.RegimeCount + 1];
          this.tDammagePerRegime = new int[this.RegimeCount + 1];
          this.tPowerPointsLost = new int[this.RegimeCount + 1];
          this.tSupplyLost = new int[this.RegimeCount + 1];
          this.tBattleStack = new int[this.RegimeCount + 1];
          this.tBattleStackAir = new int[this.RegimeCount + 1];
          this.tBattleStackArt = new int[this.RegimeCount + 1];
          this.tBattlePenalty = new int[this.RegimeCount + 1];
        }
        int regimeCount = this.RegimeCount;
        for (int index3 = 0; index3 <= regimeCount; ++index3)
        {
          this.tAPPenalty[index3] = br.ReadInt32();
          this.tSeeNow[index3] = br.ReadInt32();
          this.tLastLT[index3] = br.ReadInt32();
          this.tLastSpr[index3] = br.ReadInt32();
          this.tLastReg[index3] = br.ReadInt32();
          this.tReconPts[index3] = br.ReadInt32();
          this.tZOCPts[index3] = br.ReadInt32();
          this.tPowerPointsKilled[index3] = br.ReadInt32();
          this.tSupplyKilled[index3] = br.ReadInt32();
          this.tDammagePerRegime[index3] = br.ReadInt32();
          this.tPowerPointsLost[index3] = br.ReadInt32();
          this.tSupplyLost[index3] = br.ReadInt32();
          this.tBattleStack[index3] = br.ReadInt32();
          this.tBattleStackAir[index3] = br.ReadInt32();
          this.tBattleStackArt[index3] = br.ReadInt32();
          this.tBattlePenalty[index3] = br.ReadInt32();
        }
      }
      if (num >= 16)
      {
        if (this.RegimeCount > -1)
        {
          this.tReconPts = new int[this.RegimeCount + 1];
          this.tZOCPts = new int[this.RegimeCount + 1];
        }
        int regimeCount = this.RegimeCount;
        for (int Index = 0; Index <= regimeCount; ++Index)
        {
          this.set_ReconPts(Index, br.ReadInt32());
          this.set_ZocPts(Index, br.ReadInt32());
        }
        if (this.RegimeFullCount > -1)
        {
          this.tAPPenalty = new int[this.RegimeCount + 1];
          this.tSeeNow = new int[this.RegimeCount + 1];
          this.tLastLT = new int[this.RegimeCount + 1];
          this.tLastSpr = new int[this.RegimeCount + 1];
          this.tLastReg = new int[this.RegimeCount + 1];
          this.tPowerPointsKilled = new int[this.RegimeCount + 1];
          this.tSupplyKilled = new int[this.RegimeCount + 1];
          this.tDammagePerRegime = new int[this.RegimeCount + 1];
          this.tPowerPointsLost = new int[this.RegimeCount + 1];
          this.tSupplyLost = new int[this.RegimeCount + 1];
          this.tBattleStack = new int[this.RegimeCount + 1];
          this.tBattleStackAir = new int[this.RegimeCount + 1];
          this.tBattleStackArt = new int[this.RegimeCount + 1];
          this.tBattlePenalty = new int[this.RegimeCount + 1];
        }
        int regimeFullCount = this.RegimeFullCount;
        for (int index4 = 0; index4 <= regimeFullCount; ++index4)
        {
          this.tAPPenalty[index4] = br.ReadInt32();
          this.tSeeNow[index4] = br.ReadInt32();
          this.tLastLT[index4] = br.ReadInt32();
          this.tLastSpr[index4] = br.ReadInt32();
          this.tLastReg[index4] = br.ReadInt32();
          this.tPowerPointsKilled[index4] = br.ReadInt32();
          this.tSupplyKilled[index4] = br.ReadInt32();
          this.tDammagePerRegime[index4] = br.ReadInt32();
          this.tPowerPointsLost[index4] = br.ReadInt32();
          this.tSupplyLost[index4] = br.ReadInt32();
          this.tBattleStack[index4] = br.ReadInt32();
          this.tBattleStackAir[index4] = br.ReadInt32();
          this.tBattleStackArt[index4] = br.ReadInt32();
          this.tBattlePenalty[index4] = br.ReadInt32();
        }
      }
      int index5 = 0;
      do
      {
        this.AreaCode[index5] = br.ReadInt32();
        ++index5;
      }
      while (index5 <= 9);
      this.MaxRecon = br.ReadInt32();
      this.LabelText1 = br.ReadString();
      this.LabelType1 = br.ReadInt32();
      this.LabelText2 = br.ReadString();
      this.LabelType2 = br.ReadInt32();
      this.SmallLabel = num <= 2 ? "" : br.ReadString();
      this.SmallLabelType = num <= 3 ? 0 : br.ReadInt32();
      this.randomOverrule = num <= 4 ? -1 : br.ReadInt32();
      this.CardUponConquest = br.ReadInt32();
      this.ConnectionCount = br.ReadInt32();
      if (this.ConnectionCount > -1)
      {
        this.ConnectionX = new int[this.ConnectionCount + 1];
        this.ConnectionY = new int[this.ConnectionCount + 1];
        this.ConnectionMap = new int[this.ConnectionCount + 1];
      }
      int connectionCount = this.ConnectionCount;
      for (int index6 = 0; index6 <= connectionCount; ++index6)
      {
        this.ConnectionX[index6] = br.ReadInt32();
        this.ConnectionY[index6] = br.ReadInt32();
        this.ConnectionMap[index6] = br.ReadInt32();
      }
      this.SpecialType = br.ReadInt32();
      this.SpecialSprite = br.ReadInt32();
      this.OrigOwner = br.ReadInt32();
      if (num > 1)
      {
        this.HexLibVarCounter = br.ReadInt32();
        if (this.HexLibVarCounter > -1)
        {
          this.HexLibVarSlotNr = new int[this.HexLibVarCounter + 1];
          this.HexLibVarValue = new int[this.HexLibVarCounter + 1];
        }
        else
        {
          this.HexLibVarSlotNr = new int[1];
          this.HexLibVarValue = new int[1];
        }
        int hexLibVarCounter = this.HexLibVarCounter;
        for (int index7 = 0; index7 <= hexLibVarCounter; ++index7)
        {
          this.HexLibVarSlotNr[index7] = br.ReadInt32();
          this.HexLibVarValue[index7] = br.ReadInt32();
        }
      }
      if (num > 9)
        this.HeightLevel = br.ReadInt32();
      if (num > 10)
      {
        this.MaxLos = br.ReadInt32();
        this.MaxObstruct = br.ReadInt32();
      }
      if (num > 11)
        this.FuzzyBlock = br.ReadInt32();
      this.Location2 = num <= 14 ? -1 : br.ReadInt32();
      if (num > 5)
      {
        int index8 = 0;
        do
        {
          this.LISpoints[index8] = br.ReadInt32();
          this.LIShistory[index8] = br.ReadInt32();
          if (num > 6)
            this.LIStotalHistory[index8] = br.ReadInt32();
          if (num > 7)
            this.LISorganic[index8] = br.ReadInt32();
          if (num > 7)
            this.LISorganicPercentage[index8] = br.ReadInt32();
          if (num > 16)
            this.LISpull[index8] = br.ReadInt32();
          ++index8;
        }
        while (index8 <= 8);
      }
      if (num <= 8)
        return;
      this.SpecialType2 = br.ReadInt32();
      this.SpecialSprite2 = br.ReadInt32();
      this.SpecialType3 = br.ReadInt32();
      this.SpecialSprite3 = br.ReadInt32();
    }

    public void StreamWrite(ref BinaryWriter bw)
    {
      bw.Write(17);
      bw.Write(this.LandscapeType);
      bw.Write(this.SpriteNr);
      int index1 = 0;
      do
      {
        bw.Write(this.RoadType[index1]);
        bw.Write(this.RiverType[index1]);
        bw.Write(this.Bridge[index1]);
        ++index1;
      }
      while (index1 <= 5);
      bw.Write(this.Regime);
      bw.Write(this.UnitCounter);
      int unitCounter = this.UnitCounter;
      for (int index2 = 0; index2 <= unitCounter; ++index2)
        bw.Write(this.UnitList[index2]);
      bw.Write(this.Location);
      bw.Write(this.DammageToInfra);
      bw.Write(this.DammageVisible);
      bw.Write(this.VP);
      if (Information.IsNothing((object) this.Name))
        this.Name = "";
      bw.Write(this.Name);
      bw.Write(this.RegimeCount);
      bw.Write(this.RegimeFullCount);
      int regimeCount = this.RegimeCount;
      for (int Index = 0; Index <= regimeCount; ++Index)
      {
        bw.Write(this.get_ReconPts(Index));
        bw.Write(this.get_ZocPts(Index));
      }
      int regimeFullCount = this.RegimeFullCount;
      for (int Index = 0; Index <= regimeFullCount; ++Index)
      {
        bw.Write(this.get_APPenalty(Index));
        bw.Write(this.tSeeNow[Index]);
        bw.Write(this.get_LastLT(Index));
        bw.Write(this.get_LastSpr(Index));
        bw.Write(this.get_LastReg(Index));
        bw.Write(this.get_PowerPointsKilled(Index));
        bw.Write(this.get_SupplyKilled(Index));
        bw.Write(this.get_DammagePerRegime(Index));
        bw.Write(this.get_PowerPointsLost(Index));
        bw.Write(this.get_SupplyLost(Index));
        bw.Write(this.get_BattleStack(Index));
        bw.Write(this.get_BattleStackAir(Index));
        bw.Write(this.get_BattleStackArt(Index));
        bw.Write(this.get_BattlePenalty(Index));
      }
      int index3 = 0;
      do
      {
        bw.Write(this.AreaCode[index3]);
        ++index3;
      }
      while (index3 <= 9);
      bw.Write(this.MaxRecon);
      if (Information.IsNothing((object) this.LabelText1))
        this.LabelText1 = "";
      if (Information.IsNothing((object) this.LabelText2))
        this.LabelText2 = "";
      bw.Write(this.LabelText1);
      bw.Write(this.LabelType1);
      bw.Write(this.LabelText2);
      bw.Write(this.LabelType2);
      bw.Write(this.SmallLabel);
      bw.Write(this.SmallLabelType);
      bw.Write(this.randomOverrule);
      bw.Write(this.CardUponConquest);
      bw.Write(this.ConnectionCount);
      int connectionCount = this.ConnectionCount;
      for (int index4 = 0; index4 <= connectionCount; ++index4)
      {
        bw.Write(this.ConnectionX[index4]);
        bw.Write(this.ConnectionY[index4]);
        bw.Write(this.ConnectionMap[index4]);
      }
      bw.Write(this.SpecialType);
      bw.Write(this.SpecialSprite);
      bw.Write(this.OrigOwner);
      bw.Write(this.HexLibVarCounter);
      int hexLibVarCounter = this.HexLibVarCounter;
      for (int index5 = 0; index5 <= hexLibVarCounter; ++index5)
      {
        bw.Write(this.HexLibVarSlotNr[index5]);
        bw.Write(this.HexLibVarValue[index5]);
      }
      bw.Write(this.HeightLevel);
      bw.Write(this.MaxLos);
      bw.Write(this.MaxRecon);
      bw.Write(this.FuzzyBlock);
      bw.Write(this.Location2);
      int index6 = 0;
      do
      {
        bw.Write(this.LISpoints[index6]);
        bw.Write(this.LIShistory[index6]);
        bw.Write(this.LIStotalHistory[index6]);
        bw.Write(this.LISorganic[index6]);
        bw.Write(this.LISorganicPercentage[index6]);
        bw.Write(this.LISpull[index6]);
        ++index6;
      }
      while (index6 <= 8);
      bw.Write(this.SpecialType2);
      bw.Write(this.SpecialSprite2);
      bw.Write(this.SpecialType3);
      bw.Write(this.SpecialSprite3);
    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("LandscapeType", this.LandscapeType);
      info.AddValue("SpriteNr", this.SpriteNr);
      info.AddValue("RoadType", (object) this.RoadType);
      info.AddValue("Regime", this.Regime);
      info.AddValue("UnitCounter", this.UnitCounter);
      info.AddValue("UnitList", (object) this.UnitList);
      info.AddValue("Location", this.Location);
      info.AddValue("Location2", this.Location2);
      info.AddValue("RiverType", (object) this.RiverType);
      info.AddValue("DammageToInfra", this.DammageToInfra);
      info.AddValue("DammageVisible", this.DammageVisible);
      info.AddValue("Bridge", (object) this.Bridge);
      info.AddValue("APPenalty", (object) this.tAPPenalty);
      info.AddValue("RegimeCount", this.RegimeCount);
      info.AddValue("RegimeFullCount", this.RegimeFullCount);
      info.AddValue("SeeNow", (object) this.tSeeNow);
      info.AddValue("LastLT", (object) this.tLastLT);
      info.AddValue("LastSpr", (object) this.tLastSpr);
      info.AddValue("LastReg", (object) this.tLastReg);
      info.AddValue("ReconPts", (object) this.tReconPts);
      info.AddValue("ZOCPts", (object) this.tZOCPts);
      info.AddValue("VP", this.VP);
      info.AddValue("Name", (object) this.Name);
      info.AddValue("AreaCode", (object) this.AreaCode);
      info.AddValue("PowerPointsKilled", (object) this.tPowerPointsKilled);
      info.AddValue("SupplyKilled", (object) this.tSupplyKilled);
      info.AddValue("DammagePerRegime", (object) this.tDammagePerRegime);
      info.AddValue("PowerPointsLost", (object) this.tPowerPointsLost);
      info.AddValue("SupplyLost", (object) this.tSupplyLost);
      info.AddValue("MaxRecon", this.MaxRecon);
      info.AddValue("LabelText1", (object) this.LabelText1);
      info.AddValue("LabelType1", this.LabelType1);
      info.AddValue("LabelText2", (object) this.LabelText2);
      info.AddValue("LabelType2", this.LabelType2);
      info.AddValue("CardUponConquest", this.CardUponConquest);
      info.AddValue("BattleStack", (object) this.tBattleStack);
      info.AddValue("BattleStackAir", (object) this.tBattleStackAir);
      info.AddValue("BattleStackArt", (object) this.tBattleStackArt);
      info.AddValue("BattlePenalty", (object) this.tBattlePenalty);
      info.AddValue("ConnectionCount", this.ConnectionCount);
      info.AddValue("ConnectionX", (object) this.ConnectionX);
      info.AddValue("ConnectionY", (object) this.ConnectionY);
      info.AddValue("ConnectionMap", (object) this.ConnectionMap);
      info.AddValue("SpecialType", this.SpecialType);
      info.AddValue("SpecialSprite", this.SpecialSprite);
      info.AddValue("SpecialType2", this.SpecialType2);
      info.AddValue("SpecialSprite2", this.SpecialSprite2);
      info.AddValue("SpecialType3", this.SpecialType3);
      info.AddValue("SpecialSprite3", this.SpecialSprite3);
      info.AddValue("OrigOwner", this.OrigOwner);
      info.AddValue("HexLibVarCounter", this.HexLibVarCounter);
      info.AddValue("HexLibVarSlotNr", (object) this.HexLibVarSlotNr);
      info.AddValue("HexLibVarValue", (object) this.HexLibVarValue);
      info.AddValue("SmallLabel", (object) this.SmallLabel);
      info.AddValue("HeightLevel", this.HeightLevel);
    }

    protected HexClass(SerializationInfo info, StreamingContext context)
    {
      this.RoadType = new int[6];
      this.RiverType = new int[6];
      this.UnitList = new int[1];
      this.Bridge = new bool[6];
      this.tAPPenalty = new int[1];
      this.AreaCode = new int[10];
      this.HexLibVarSlotNr = new int[1];
      this.HexLibVarValue = new int[1];
      this.tDammagePerRegime = new int[1];
      this.tSeeNow = new int[1];
      this.tLastLT = new int[1];
      this.tLastSpr = new int[1];
      this.tLastReg = new int[1];
      this.tReconPts = new int[1];
      this.tZOCPts = new int[1];
      this.tPowerPointsKilled = new int[1];
      this.tSupplyKilled = new int[1];
      this.tPowerPointsLost = new int[1];
      this.tSupplyLost = new int[1];
      this.tBattleStack = new int[1];
      this.tBattlePenalty = new int[1];
      this.tBattleStackAir = new int[1];
      this.tBattleStackArt = new int[1];
      this.ConnectionX = new int[1];
      this.ConnectionY = new int[1];
      this.ConnectionMap = new int[1];
      this.LISpoints = new int[9];
      this.LIShistory = new int[9];
      this.LIStotalHistory = new int[9];
      this.LISorganic = new int[9];
      this.LISpull = new int[9];
      this.LISorganicPercentage = new int[9];
      this.tempOldLISpoints = new int[9];
      this.tempPreviewLIS = new int[9];
      this.tempPreviewAssetLIS = new int[9];
      this.tempPreviewPull = new int[9];
      this.tempPreviewRoadPull = new int[9];
      this.LandscapeType = info.GetInt32(nameof (LandscapeType));
      if (this.LandscapeType == -1)
        this.LandscapeType = 0;
      this.SpriteNr = info.GetInt32(nameof (SpriteNr));
      this.RoadType = (int[]) info.GetValue(nameof (RoadType), this.RoadType.GetType());
      this.Regime = info.GetInt32(nameof (Regime));
      this.UnitCounter = info.GetInt32(nameof (UnitCounter));
      this.UnitList = this.UnitCounter <= -1 ? new int[1] : new int[this.UnitCounter + 1];
      this.UnitList = (int[]) info.GetValue(nameof (UnitList), this.UnitList.GetType());
      this.Location = info.GetInt32(nameof (Location));
      try
      {
        this.Location2 = info.GetInt32(nameof (Location2));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Location2 = -1;
        ProjectData.ClearProjectError();
      }
      this.RiverType = (int[]) info.GetValue(nameof (RiverType), this.RiverType.GetType());
      this.DammageToInfra = info.GetInt32(nameof (DammageToInfra));
      this.Bridge = (bool[]) info.GetValue(nameof (Bridge), this.Bridge.GetType());
      this.RegimeCount = info.GetInt32(nameof (RegimeCount));
      try
      {
        this.RegimeFullCount = info.GetInt32(nameof (RegimeFullCount));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.RegimeFullCount = this.RegimeCount;
        ProjectData.ClearProjectError();
      }
      if (DrawMod.TGame.Data.Version < 130)
      {
        this.tBattleStack = new int[this.RegimeCount + 1];
        this.tBattlePenalty = new int[this.RegimeCount + 1];
        this.tAPPenalty = new int[this.RegimeCount + 1];
        this.tBattleStackArt = new int[this.RegimeCount + 1];
        this.tBattleStackAir = new int[this.RegimeCount + 1];
      }
      else if (DrawMod.TGame.Data.Version < 158)
      {
        try
        {
          this.tAPPenalty = new int[this.RegimeCount + 1];
          this.tBattleStack = new int[this.RegimeCount + 1];
          this.tBattlePenalty = new int[this.RegimeCount + 1];
          this.tAPPenalty = (int[]) info.GetValue(nameof (APPenalty), this.tAPPenalty.GetType());
          this.tBattleStack = (int[]) info.GetValue(nameof (BattleStack), this.tBattleStack.GetType());
          this.tBattlePenalty = (int[]) info.GetValue(nameof (BattlePenalty), this.tBattlePenalty.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.tBattleStack = new int[this.RegimeCount + 1];
          this.tBattlePenalty = new int[this.RegimeCount + 1];
          this.tAPPenalty = new int[this.RegimeCount + 1];
          ProjectData.ClearProjectError();
        }
        this.tBattleStackArt = new int[this.RegimeCount + 1];
        this.tBattleStackAir = new int[this.RegimeCount + 1];
      }
      else if (DrawMod.TGame.Data.Version < 177)
      {
        this.tAPPenalty = new int[this.RegimeCount + 1];
        this.tBattleStack = new int[this.RegimeCount + 1];
        this.tBattleStackArt = new int[this.RegimeCount + 1];
        this.tBattleStackAir = new int[this.RegimeCount + 1];
        this.tBattlePenalty = new int[this.RegimeCount + 1];
        this.tAPPenalty = (int[]) info.GetValue(nameof (APPenalty), this.tAPPenalty.GetType());
        this.tBattleStack = (int[]) info.GetValue(nameof (BattleStack), this.tBattleStack.GetType());
        this.tBattlePenalty = (int[]) info.GetValue(nameof (BattlePenalty), this.tBattlePenalty.GetType());
      }
      else
      {
        this.tAPPenalty = new int[this.RegimeCount + 1];
        this.tBattleStack = new int[this.RegimeCount + 1];
        this.tBattleStackArt = new int[this.RegimeCount + 1];
        this.tBattleStackAir = new int[this.RegimeCount + 1];
        this.tBattlePenalty = new int[this.RegimeCount + 1];
        this.tAPPenalty = (int[]) info.GetValue(nameof (APPenalty), this.tAPPenalty.GetType());
        this.tBattleStack = (int[]) info.GetValue(nameof (BattleStack), this.tBattleStack.GetType());
        this.tBattleStackAir = (int[]) info.GetValue(nameof (BattleStackAir), this.tBattleStackAir.GetType());
        this.tBattleStackArt = (int[]) info.GetValue(nameof (BattleStackArt), this.tBattleStackArt.GetType());
        this.tBattlePenalty = (int[]) info.GetValue(nameof (BattlePenalty), this.tBattlePenalty.GetType());
      }
      this.tSeeNow = new int[this.RegimeCount + 1];
      this.tLastLT = new int[this.RegimeCount + 1];
      this.tLastSpr = new int[this.RegimeCount + 1];
      this.tLastReg = new int[this.RegimeCount + 1];
      this.tReconPts = new int[this.RegimeCount + 1];
      this.tZOCPts = new int[this.RegimeCount + 1];
      this.tSeeNow = (int[]) info.GetValue(nameof (SeeNow), this.tSeeNow.GetType());
      this.tLastLT = (int[]) info.GetValue(nameof (LastLT), this.tLastLT.GetType());
      this.tLastSpr = (int[]) info.GetValue(nameof (LastSpr), this.tLastSpr.GetType());
      this.tLastReg = (int[]) info.GetValue(nameof (LastReg), this.tLastReg.GetType());
      this.tReconPts = (int[]) info.GetValue(nameof (ReconPts), this.tReconPts.GetType());
      this.tZOCPts = (int[]) info.GetValue("ZOCPts", this.tZOCPts.GetType());
      this.VP = info.GetInt32(nameof (VP));
      this.Name = info.GetString(nameof (Name));
      this.AreaCode = (int[]) info.GetValue(nameof (AreaCode), this.AreaCode.GetType());
      this.DammageVisible = info.GetInt32(nameof (DammageVisible));
      this.tPowerPointsKilled = new int[this.RegimeCount + 1];
      this.tSupplyKilled = new int[this.RegimeCount + 1];
      this.tDammagePerRegime = new int[this.RegimeCount + 1];
      this.tPowerPointsLost = new int[this.RegimeCount + 1];
      this.tSupplyLost = new int[this.RegimeCount + 1];
      this.tDammagePerRegime = (int[]) info.GetValue(nameof (DammagePerRegime), this.tDammagePerRegime.GetType());
      this.tPowerPointsKilled = (int[]) info.GetValue(nameof (PowerPointsKilled), this.tPowerPointsKilled.GetType());
      this.tSupplyKilled = (int[]) info.GetValue(nameof (SupplyKilled), this.tSupplyKilled.GetType());
      this.tPowerPointsLost = (int[]) info.GetValue(nameof (PowerPointsLost), this.tPowerPointsLost.GetType());
      this.tSupplyLost = (int[]) info.GetValue(nameof (SupplyLost), this.tSupplyLost.GetType());
      this.MaxRecon = info.GetInt32(nameof (MaxRecon));
      if (DrawMod.TGame.Data.Version > 100)
      {
        this.LabelText1 = info.GetString(nameof (LabelText1));
        this.LabelText2 = info.GetString(nameof (LabelText2));
        this.LabelType1 = info.GetInt32(nameof (LabelType1));
        this.LabelType2 = info.GetInt32(nameof (LabelType2));
      }
      else
      {
        this.LabelType1 = 0;
        this.LabelType2 = 0;
        this.LabelText1 = "";
        this.LabelText2 = "";
      }
      if (DrawMod.TGame.Data.Version < 130)
        this.CardUponConquest = -1;
      else if (DrawMod.TGame.Data.Version < 158)
      {
        try
        {
          this.CardUponConquest = info.GetInt32(nameof (CardUponConquest));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.CardUponConquest = -1;
          ProjectData.ClearProjectError();
        }
      }
      else
        this.CardUponConquest = info.GetInt32(nameof (CardUponConquest));
      if (DrawMod.TGame.Data.Version < 130)
        this.ConnectionCount = -1;
      else if (DrawMod.TGame.Data.Version < 158)
      {
        try
        {
          this.ConnectionCount = info.GetInt32(nameof (ConnectionCount));
          if (this.ConnectionCount > -1)
          {
            this.ConnectionX = new int[this.ConnectionCount + 1];
            this.ConnectionY = new int[this.ConnectionCount + 1];
            this.ConnectionMap = new int[this.ConnectionCount + 1];
            this.ConnectionX = (int[]) info.GetValue(nameof (ConnectionX), this.ConnectionX.GetType());
            this.ConnectionY = (int[]) info.GetValue(nameof (ConnectionY), this.ConnectionY.GetType());
            this.ConnectionMap = (int[]) info.GetValue(nameof (ConnectionMap), this.ConnectionMap.GetType());
          }
          else
          {
            this.ConnectionX = new int[1];
            this.ConnectionY = new int[1];
            this.ConnectionMap = new int[1];
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.ConnectionCount = -1;
          ProjectData.ClearProjectError();
        }
      }
      else
      {
        this.ConnectionCount = info.GetInt32(nameof (ConnectionCount));
        if (this.ConnectionCount > -1)
        {
          this.ConnectionX = new int[this.ConnectionCount + 1];
          this.ConnectionY = new int[this.ConnectionCount + 1];
          this.ConnectionMap = new int[this.ConnectionCount + 1];
          this.ConnectionX = (int[]) info.GetValue(nameof (ConnectionX), this.ConnectionX.GetType());
          this.ConnectionY = (int[]) info.GetValue(nameof (ConnectionY), this.ConnectionY.GetType());
          this.ConnectionMap = (int[]) info.GetValue(nameof (ConnectionMap), this.ConnectionMap.GetType());
        }
        else
        {
          this.ConnectionX = new int[1];
          this.ConnectionY = new int[1];
          this.ConnectionMap = new int[1];
        }
      }
      this.TempOwner = -1;
      this.SpecialType2 = -1;
      this.SpecialSprite2 = -1;
      this.SpecialType3 = -1;
      this.SpecialSprite3 = -1;
      if (DrawMod.TGame.Data.Version < 130)
      {
        this.SpecialType = -1;
        this.SpecialSprite = -1;
      }
      else if (DrawMod.TGame.Data.Version < 162)
      {
        try
        {
          this.SpecialType = info.GetInt32(nameof (SpecialType));
          this.SpecialSprite = info.GetInt32(nameof (SpecialSprite));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.SpecialType = -1;
          this.SpecialSprite = -1;
          ProjectData.ClearProjectError();
        }
      }
      else
      {
        this.SpecialType = info.GetInt32(nameof (SpecialType));
        this.SpecialSprite = info.GetInt32(nameof (SpecialSprite));
        try
        {
          this.SpecialType2 = info.GetInt32(nameof (SpecialType2));
          this.SpecialSprite2 = info.GetInt32(nameof (SpecialSprite2));
          this.SpecialType3 = info.GetInt32(nameof (SpecialType3));
          this.SpecialSprite3 = info.GetInt32(nameof (SpecialSprite3));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
      }
      if (DrawMod.TGame.Data.Version < 130)
        this.OrigOwner = -1;
      else if (DrawMod.TGame.Data.Version < 178)
      {
        try
        {
          this.OrigOwner = info.GetInt32(nameof (OrigOwner));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.OrigOwner = -1;
          ProjectData.ClearProjectError();
        }
      }
      else
        this.OrigOwner = info.GetInt32(nameof (OrigOwner));
      try
      {
        this.HexLibVarCounter = info.GetInt32(nameof (HexLibVarCounter));
        if (this.HexLibVarCounter > -1)
        {
          this.HexLibVarSlotNr = new int[this.HexLibVarCounter + 1];
          this.HexLibVarValue = new int[this.HexLibVarCounter + 1];
        }
        else
        {
          this.HexLibVarSlotNr = new int[1];
          this.HexLibVarValue = new int[1];
        }
        this.HexLibVarSlotNr = (int[]) info.GetValue(nameof (HexLibVarSlotNr), this.HexLibVarSlotNr.GetType());
        this.HexLibVarValue = (int[]) info.GetValue(nameof (HexLibVarValue), this.HexLibVarValue.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.HexLibVarCounter = -1;
        this.HexLibVarSlotNr = new int[1];
        this.HexLibVarValue = new int[1];
        ProjectData.ClearProjectError();
      }
      try
      {
        this.SmallLabel = info.GetString(nameof (SmallLabel));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.SmallLabel = "";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.HeightLevel = Conversions.ToInteger(info.GetString(nameof (HeightLevel)));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.HeightLevel = 0;
        ProjectData.ClearProjectError();
      }
    }

    public void Addconnection(int x, int y, int map)
    {
      ++this.ConnectionCount;
      this.ConnectionX = (int[]) Utils.CopyArray((Array) this.ConnectionX, (Array) new int[this.ConnectionCount + 1]);
      this.ConnectionY = (int[]) Utils.CopyArray((Array) this.ConnectionY, (Array) new int[this.ConnectionCount + 1]);
      this.ConnectionMap = (int[]) Utils.CopyArray((Array) this.ConnectionMap, (Array) new int[this.ConnectionCount + 1]);
      this.ConnectionX[this.ConnectionCount] = x;
      this.ConnectionY[this.ConnectionCount] = y;
      this.ConnectionMap[this.ConnectionCount] = map;
    }

    public void RemoveConnection(int nr)
    {
      if (this.ConnectionCount > 0)
      {
        if (nr < this.ConnectionCount)
        {
          int num1 = nr;
          int num2 = this.ConnectionCount - 1;
          for (int index = num1; index <= num2; ++index)
          {
            this.ConnectionX[index] = this.ConnectionX[index + 1];
            this.ConnectionY[index] = this.ConnectionY[index + 1];
            this.ConnectionMap[index] = this.ConnectionMap[index + 1];
          }
        }
        --this.ConnectionCount;
        this.ConnectionX = (int[]) Utils.CopyArray((Array) this.ConnectionX, (Array) new int[this.ConnectionCount + 1]);
        this.ConnectionY = (int[]) Utils.CopyArray((Array) this.ConnectionY, (Array) new int[this.ConnectionCount + 1]);
        this.ConnectionMap = (int[]) Utils.CopyArray((Array) this.ConnectionMap, (Array) new int[this.ConnectionCount + 1]);
      }
      else
      {
        --this.ConnectionCount;
        this.ConnectionX = new int[1];
        this.ConnectionY = new int[1];
        this.ConnectionMap = new int[1];
      }
    }

    public int GetHexLibVarValue(int tSlotNr)
    {
      int hexLibVarCounter = this.HexLibVarCounter;
      for (int index = 0; index <= hexLibVarCounter; ++index)
      {
        if (this.HexLibVarSlotNr[index] == tSlotNr)
          return this.HexLibVarValue[index];
      }
      return 0;
    }

    public bool HasHexLibVarValue(int tSlotNr)
    {
      int hexLibVarCounter = this.HexLibVarCounter;
      for (int index = 0; index <= hexLibVarCounter; ++index)
      {
        if (this.HexLibVarSlotNr[index] == tSlotNr)
          return true;
      }
      return false;
    }

    public void SetHexLibVarValue(int tSlotNr, int tValue)
    {
      int hexLibVarCounter = this.HexLibVarCounter;
      for (int nr = 0; nr <= hexLibVarCounter; ++nr)
      {
        if (this.HexLibVarSlotNr[nr] == tSlotNr)
        {
          this.HexLibVarValue[nr] = tValue;
          if (tValue != 0)
            return;
          this.RemoveHexLibVar(nr);
          return;
        }
      }
      if (tValue == 0)
        return;
      this.AddHexLibVar(tSlotNr, tValue);
    }

    public void AddHexLibVar(int tLibVarSlotNr, int tValue)
    {
      ++this.HexLibVarCounter;
      this.HexLibVarSlotNr = (int[]) Utils.CopyArray((Array) this.HexLibVarSlotNr, (Array) new int[this.HexLibVarCounter + 1]);
      this.HexLibVarValue = (int[]) Utils.CopyArray((Array) this.HexLibVarValue, (Array) new int[this.HexLibVarCounter + 1]);
      this.HexLibVarSlotNr[this.HexLibVarCounter] = tLibVarSlotNr;
      this.HexLibVarValue[this.HexLibVarCounter] = tValue;
    }

    public void RemoveHexLibVarSlotNr(int slotnr)
    {
      if (this.HexLibVarCounter <= -1)
        return;
      int nr = -1;
      int hexLibVarCounter = this.HexLibVarCounter;
      for (int index = 0; index <= hexLibVarCounter; ++index)
      {
        if (slotnr == this.HexLibVarSlotNr[index])
        {
          nr = index;
          break;
        }
      }
      if (nr <= -1)
        return;
      this.RemoveHexLibVar(nr);
    }

    public void RemoveHexLibVar(int nr)
    {
      if (nr == -1)
        return;
      if (this.HexLibVarCounter > 0)
      {
        if (nr < this.HexLibVarCounter)
        {
          int num1 = nr;
          int num2 = this.HexLibVarCounter - 1;
          for (int index = num1; index <= num2; ++index)
          {
            this.HexLibVarSlotNr[index] = this.HexLibVarSlotNr[index + 1];
            this.HexLibVarValue[index] = this.HexLibVarValue[index + 1];
          }
        }
        --this.HexLibVarCounter;
        this.HexLibVarSlotNr = (int[]) Utils.CopyArray((Array) this.HexLibVarSlotNr, (Array) new int[this.HexLibVarCounter + 1]);
        this.HexLibVarValue = (int[]) Utils.CopyArray((Array) this.HexLibVarValue, (Array) new int[this.HexLibVarCounter + 1]);
      }
      else
      {
        this.HexLibVarCounter = -1;
        this.HexLibVarSlotNr = (int[]) Utils.CopyArray((Array) this.HexLibVarSlotNr, (Array) new int[1]);
        this.HexLibVarValue = (int[]) Utils.CopyArray((Array) this.HexLibVarValue, (Array) new int[1]);
      }
    }

    public void redimRegime(int tRegimeCount, int tRegimeFullCount)
    {
      this.RegimeCount = tRegimeCount;
      this.RegimeFullCount = tRegimeFullCount;
      this.tSeeNow = (int[]) Utils.CopyArray((Array) this.tSeeNow, (Array) new int[this.RegimeFullCount + 1]);
      this.tLastLT = (int[]) Utils.CopyArray((Array) this.tLastLT, (Array) new int[this.RegimeFullCount + 1]);
      this.tAPPenalty = (int[]) Utils.CopyArray((Array) this.tAPPenalty, (Array) new int[this.RegimeFullCount + 1]);
      this.tLastSpr = (int[]) Utils.CopyArray((Array) this.tLastSpr, (Array) new int[this.RegimeFullCount + 1]);
      this.tLastReg = (int[]) Utils.CopyArray((Array) this.tLastReg, (Array) new int[this.RegimeFullCount + 1]);
      this.tReconPts = (int[]) Utils.CopyArray((Array) this.tReconPts, (Array) new int[this.RegimeCount + 1]);
      this.tZOCPts = (int[]) Utils.CopyArray((Array) this.tZOCPts, (Array) new int[this.RegimeCount + 1]);
      this.tPowerPointsKilled = (int[]) Utils.CopyArray((Array) this.tPowerPointsKilled, (Array) new int[this.RegimeFullCount + 1]);
      this.tSupplyKilled = (int[]) Utils.CopyArray((Array) this.tSupplyKilled, (Array) new int[this.RegimeFullCount + 1]);
      this.tDammagePerRegime = (int[]) Utils.CopyArray((Array) this.tDammagePerRegime, (Array) new int[this.RegimeFullCount + 1]);
      this.tPowerPointsLost = (int[]) Utils.CopyArray((Array) this.tPowerPointsLost, (Array) new int[this.RegimeFullCount + 1]);
      this.tSupplyLost = (int[]) Utils.CopyArray((Array) this.tSupplyLost, (Array) new int[this.RegimeFullCount + 1]);
      this.tBattleStack = (int[]) Utils.CopyArray((Array) this.tBattleStack, (Array) new int[this.RegimeFullCount + 1]);
      this.tBattleStackAir = (int[]) Utils.CopyArray((Array) this.tBattleStackAir, (Array) new int[this.RegimeFullCount + 1]);
      this.tBattleStackArt = (int[]) Utils.CopyArray((Array) this.tBattleStackArt, (Array) new int[this.RegimeFullCount + 1]);
      this.tBattlePenalty = (int[]) Utils.CopyArray((Array) this.tBattlePenalty, (Array) new int[this.RegimeFullCount + 1]);
    }

    public void UNUSED_addnewregime(int nr, bool fullRegime, bool noRedimNecc = false)
    {
      ++this.RegimeCount;
      if (nr < 2)
        fullRegime = true;
      if (fullRegime)
        ++this.RegimeFullCount;
      if (noRedimNecc)
      {
        this.tSeeNow = new int[this.RegimeFullCount + 1];
        this.tLastLT = new int[this.RegimeFullCount + 1];
        this.tAPPenalty = new int[this.RegimeFullCount + 1];
        this.tLastSpr = new int[this.RegimeFullCount + 1];
        this.tLastReg = new int[this.RegimeFullCount + 1];
        this.tReconPts = new int[this.RegimeCount + 1];
        this.tZOCPts = new int[this.RegimeCount + 1];
        this.tPowerPointsKilled = new int[this.RegimeFullCount + 1];
        this.tSupplyKilled = new int[this.RegimeFullCount + 1];
        this.tDammagePerRegime = new int[this.RegimeFullCount + 1];
        this.tPowerPointsLost = new int[this.RegimeFullCount + 1];
        this.tSupplyLost = new int[this.RegimeFullCount + 1];
        this.tBattleStack = new int[this.RegimeFullCount + 1];
        this.tBattleStackAir = new int[this.RegimeFullCount + 1];
        this.tBattleStackArt = new int[this.RegimeFullCount + 1];
        this.tBattlePenalty = new int[this.RegimeFullCount + 1];
      }
      else
      {
        this.tSeeNow = (int[]) Utils.CopyArray((Array) this.tSeeNow, (Array) new int[this.RegimeFullCount + 1]);
        this.tLastLT = (int[]) Utils.CopyArray((Array) this.tLastLT, (Array) new int[this.RegimeFullCount + 1]);
        this.tAPPenalty = (int[]) Utils.CopyArray((Array) this.tAPPenalty, (Array) new int[this.RegimeFullCount + 1]);
        this.tLastSpr = (int[]) Utils.CopyArray((Array) this.tLastSpr, (Array) new int[this.RegimeFullCount + 1]);
        this.tLastReg = (int[]) Utils.CopyArray((Array) this.tLastReg, (Array) new int[this.RegimeFullCount + 1]);
        this.tReconPts = (int[]) Utils.CopyArray((Array) this.tReconPts, (Array) new int[this.RegimeCount + 1]);
        this.tZOCPts = (int[]) Utils.CopyArray((Array) this.tZOCPts, (Array) new int[this.RegimeCount + 1]);
        this.tPowerPointsKilled = (int[]) Utils.CopyArray((Array) this.tPowerPointsKilled, (Array) new int[this.RegimeFullCount + 1]);
        this.tSupplyKilled = (int[]) Utils.CopyArray((Array) this.tSupplyKilled, (Array) new int[this.RegimeFullCount + 1]);
        this.tDammagePerRegime = (int[]) Utils.CopyArray((Array) this.tDammagePerRegime, (Array) new int[this.RegimeFullCount + 1]);
        this.tPowerPointsLost = (int[]) Utils.CopyArray((Array) this.tPowerPointsLost, (Array) new int[this.RegimeFullCount + 1]);
        this.tSupplyLost = (int[]) Utils.CopyArray((Array) this.tSupplyLost, (Array) new int[this.RegimeFullCount + 1]);
        this.tBattleStack = (int[]) Utils.CopyArray((Array) this.tBattleStack, (Array) new int[this.RegimeFullCount + 1]);
        this.tBattleStackAir = (int[]) Utils.CopyArray((Array) this.tBattleStackAir, (Array) new int[this.RegimeFullCount + 1]);
        this.tBattleStackArt = (int[]) Utils.CopyArray((Array) this.tBattleStackArt, (Array) new int[this.RegimeFullCount + 1]);
        this.tBattlePenalty = (int[]) Utils.CopyArray((Array) this.tBattlePenalty, (Array) new int[this.RegimeFullCount + 1]);
      }
      if (!fullRegime)
        return;
      this.tSeeNow[this.RegimeFullCount] = 0;
    }

    public void removeregime(bool fullRegime, int nr)
    {
      if (nr <= this.RegimeFullCount)
        fullRegime = true;
      if (nr <= 2)
        fullRegime = true;
      if (this.RegimeCount > 0)
      {
        if (nr < this.RegimeCount)
        {
          int num1 = nr;
          int num2 = this.RegimeCount - 1;
          for (int Index = num1; Index <= num2; ++Index)
          {
            this.set_ReconPts(Index, this.get_ReconPts(Index + 1));
            this.set_ZocPts(Index, this.get_ZocPts(Index + 1));
          }
        }
        if (nr < this.RegimeFullCount)
        {
          int num3 = nr;
          int num4 = this.RegimeFullCount - 1;
          for (int Index = num3; Index <= num4; ++Index)
          {
            this.tSeeNow[Index] = this.tSeeNow[Index + 1];
            this.set_LastLT(Index, this.get_LastLT(Index + 1));
            this.set_LastSpr(Index, this.get_LastSpr(Index + 1));
            this.set_LastReg(Index, this.get_LastReg(Index + 1));
            this.set_PowerPointsKilled(Index, this.get_PowerPointsKilled(Index + 1));
            this.set_SupplyKilled(Index, this.get_SupplyKilled(Index + 1));
            this.set_DammagePerRegime(Index, this.get_DammagePerRegime(Index + 1));
            this.set_PowerPointsLost(Index, this.get_PowerPointsLost(Index + 1));
            this.set_SupplyLost(Index, this.get_SupplyLost(Index + 1));
            this.set_APPenalty(Index, this.get_APPenalty(Index + 1));
            this.set_BattleStack(Index, this.get_BattleStack(Index + 1));
            this.set_BattleStackAir(Index, this.get_BattleStackAir(Index + 1));
            this.set_BattleStackArt(Index, this.get_BattleStackArt(Index + 1));
            this.set_BattlePenalty(Index, this.get_BattlePenalty(Index + 1));
          }
        }
        --this.RegimeCount;
        this.tReconPts = (int[]) Utils.CopyArray((Array) this.tReconPts, (Array) new int[this.RegimeCount + 1]);
        this.tZOCPts = (int[]) Utils.CopyArray((Array) this.tZOCPts, (Array) new int[this.RegimeCount + 1]);
        if (!fullRegime)
          return;
        --this.RegimeFullCount;
        this.tSeeNow = (int[]) Utils.CopyArray((Array) this.tSeeNow, (Array) new int[this.RegimeFullCount + 1]);
        this.tLastLT = (int[]) Utils.CopyArray((Array) this.tLastLT, (Array) new int[this.RegimeFullCount + 1]);
        this.tLastSpr = (int[]) Utils.CopyArray((Array) this.tLastSpr, (Array) new int[this.RegimeFullCount + 1]);
        this.tLastReg = (int[]) Utils.CopyArray((Array) this.tLastReg, (Array) new int[this.RegimeFullCount + 1]);
        this.tSupplyKilled = (int[]) Utils.CopyArray((Array) this.tSupplyKilled, (Array) new int[this.RegimeFullCount + 1]);
        this.tPowerPointsKilled = (int[]) Utils.CopyArray((Array) this.tPowerPointsKilled, (Array) new int[this.RegimeFullCount + 1]);
        this.tDammagePerRegime = (int[]) Utils.CopyArray((Array) this.tDammagePerRegime, (Array) new int[this.RegimeFullCount + 1]);
        this.tPowerPointsLost = (int[]) Utils.CopyArray((Array) this.tPowerPointsLost, (Array) new int[this.RegimeFullCount + 1]);
        this.tSupplyLost = (int[]) Utils.CopyArray((Array) this.tSupplyLost, (Array) new int[this.RegimeFullCount + 1]);
        this.tAPPenalty = (int[]) Utils.CopyArray((Array) this.tAPPenalty, (Array) new int[this.RegimeFullCount + 1]);
        this.tBattleStack = (int[]) Utils.CopyArray((Array) this.tBattleStack, (Array) new int[this.RegimeFullCount + 1]);
        this.tBattleStackAir = (int[]) Utils.CopyArray((Array) this.tBattleStackAir, (Array) new int[this.RegimeFullCount + 1]);
        this.tBattleStackArt = (int[]) Utils.CopyArray((Array) this.tBattleStackArt, (Array) new int[this.RegimeFullCount + 1]);
        this.tBattlePenalty = (int[]) Utils.CopyArray((Array) this.tBattlePenalty, (Array) new int[this.RegimeFullCount + 1]);
      }
      else
      {
        this.RegimeCount = -1;
        this.tSeeNow = new int[1];
        this.tLastLT = new int[1];
        this.tLastSpr = new int[1];
        this.tLastReg = new int[1];
        this.tReconPts = new int[1];
        this.tZOCPts = new int[1];
        this.tSupplyKilled = new int[1];
        this.tPowerPointsKilled = new int[1];
        this.tDammagePerRegime = new int[1];
        this.tPowerPointsLost = new int[1];
        this.tSupplyLost = new int[1];
        this.tAPPenalty = new int[1];
        this.tBattleStack = new int[1];
        this.tBattleStackAir = new int[1];
        this.tBattleStackArt = new int[1];
        this.tBattlePenalty = new int[1];
      }
    }

    public void AddUnitToList(int nr)
    {
      if (this.UnitCounter < -1)
        this.UnitCounter = -1;
      ++this.UnitCounter;
      this.UnitList = (int[]) Utils.CopyArray((Array) this.UnitList, (Array) new int[this.UnitCounter + 1]);
      if (this.UnitCounter > 0)
      {
        for (int unitCounter = this.UnitCounter; unitCounter >= 1; unitCounter += -1)
          this.UnitList[unitCounter] = this.UnitList[unitCounter - 1];
      }
      this.UnitList[0] = nr;
    }

    public void RemoveUnitFromList(int nr)
    {
      int num1 = -1;
      int unitCounter = this.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.UnitList[index] == nr)
          num1 = index;
      }
      if (num1 <= -1)
        return;
      if (num1 < this.UnitCounter)
      {
        int num2 = num1;
        int num3 = this.UnitCounter - 1;
        for (int index = num2; index <= num3; ++index)
          this.UnitList[index] = this.UnitList[index + 1];
      }
      --this.UnitCounter;
      this.UnitList = (int[]) Utils.CopyArray((Array) this.UnitList, (Array) new int[this.UnitCounter + 1]);
    }
  }
}
