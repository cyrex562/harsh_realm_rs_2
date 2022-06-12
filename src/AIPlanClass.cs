// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.AIPlanClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.Serialization;

namespace WindowsApplication1
{
  [Serializable]
  public class AIPlanClass : ISerializable
  {
    public int Type;
    public SAClass FromArea;
    public SAClass TooArea;
    public SAClass RetreatTooArea;
    public int FlankCoverCounter;
    public SAClass[] FlankCover;
    public int WeightStrategic;
    public float WeightEnemyForce;
    public float WeightEnemyForceUnMod;
    public float WeightFriendlyForce;
    public int ProdPts;
    public int FrontSize;
    public int Stand;
    public int FriendlyUnitCount;
    public int EnemyUnitCount;
    public int LandTransferMobility;
    public int SeaTransferMobility;
    public int StrategicEnemyForce;
    public int CurrentBackRoad;
    public int MetaChainNr;
    public int SeaStand;
    public int SeaTarget;
    public int FriendlyAir;
    public int EnemyAir;
    public int EnemyTroops;
    public int PossibleAPCost;
    public int CurrentAPCost;
    public int AverageUnitAPCost;
    public int FriendlyNavy;
    public int EnemyNavy;
    public int RiverLine;
    public int HQ;
    public int AssemblyArea;
    public int ProdPtsInRange;

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Type", this.Type);
      info.AddValue("FromArea", (object) this.FromArea);
      info.AddValue("TooArea", (object) this.TooArea);
      info.AddValue("HQ", this.HQ);
      info.AddValue("SeaTarget", this.SeaTarget);
    }

    protected AIPlanClass(SerializationInfo info, StreamingContext context)
    {
      this.FlankCover = new SAClass[1];
      this.Type = info.GetInt32(nameof (Type));
      try
      {
        this.FromArea = (SAClass) info.GetValue(nameof (FromArea), typeof (SAClass));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.FromArea = (SAClass) null;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.TooArea = (SAClass) info.GetValue(nameof (TooArea), typeof (SAClass));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.TooArea = (SAClass) null;
        ProjectData.ClearProjectError();
      }
      this.HQ = info.GetInt32(nameof (HQ));
      this.SeaTarget = info.GetInt32(nameof (SeaTarget));
    }

    public AIPlanClass()
    {
      this.FlankCover = new SAClass[1];
      this.HQ = -1;
    }

    public void AddFlankCover(SAClass nr)
    {
      ++this.FlankCoverCounter;
      this.FlankCover = (SAClass[]) Utils.CopyArray((Array) this.FlankCover, (Array) new SAClass[this.FlankCoverCounter + 1]);
      this.FlankCover[this.FlankCoverCounter] = nr.Clone();
    }
  }
}
