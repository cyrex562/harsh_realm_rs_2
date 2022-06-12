// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.HistoryStepClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.Serialization;

namespace WindowsApplication1
{
  [Serializable]
  public class HistoryStepClass : ISerializable
  {
    public int Regime;
    public int X;
    public int Y;
    public int Map;
    public int Ownership;
    public int Force;
    public int SFType;
    public int[] AttackDirection;
    public int AttackOtherType;
    public int StepNr;
    public string InfoString;
    public int His;
    public int Depth;
    public int LossCounter;
    public int[] LossSFType;
    public int[] LossAttacker;
    public int[] LossOK;
    public int[] LossDEAD;
    public int LossRegimeWin;
    public int LossAttReg;
    public int LossDefReg;

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Regime", this.Regime);
      info.AddValue("X", this.X);
      info.AddValue("Y", this.Y);
      info.AddValue("Map", this.Map);
      info.AddValue("Ownership", this.Ownership);
      info.AddValue("Force", this.Force);
      info.AddValue("SFType", this.SFType);
      info.AddValue("AttackDirection", (object) this.AttackDirection);
      info.AddValue("AttackOtherType", this.AttackOtherType);
      info.AddValue("StepNr", this.StepNr);
      info.AddValue("LossCounter", this.LossCounter);
      info.AddValue("LossSFType", (object) this.LossSFType);
      info.AddValue("LossOK", (object) this.LossOK);
      info.AddValue("LossDEAD", (object) this.LossDEAD);
      info.AddValue("LossAttacker", (object) this.LossAttacker);
      info.AddValue("LossRegimeWin", this.LossRegimeWin);
      info.AddValue("LossDefReg", this.LossDefReg);
      info.AddValue("LossAttReg", this.LossAttReg);
      info.AddValue("InfoString", (object) this.InfoString);
      info.AddValue("His", this.His);
      info.AddValue("Depth", this.Depth);
    }

    protected HistoryStepClass(SerializationInfo info, StreamingContext context)
    {
      this.AttackDirection = new int[6];
      this.LossSFType = new int[1];
      this.LossAttacker = new int[1];
      this.LossOK = new int[1];
      this.LossDEAD = new int[1];
      this.Regime = info.GetInt32(nameof (Regime));
      this.X = info.GetInt32(nameof (X));
      this.Y = info.GetInt32(nameof (Y));
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
      this.Ownership = info.GetInt32(nameof (Ownership));
      this.Force = info.GetInt32(nameof (Force));
      this.SFType = info.GetInt32(nameof (SFType));
      this.AttackDirection = (int[]) info.GetValue(nameof (AttackDirection), this.AttackDirection.GetType());
      this.AttackOtherType = info.GetInt32(nameof (AttackOtherType));
      this.StepNr = info.GetInt32(nameof (StepNr));
      this.LossCounter = info.GetInt32(nameof (LossCounter));
      if (this.LossCounter > -1)
      {
        this.LossSFType = new int[this.LossCounter + 1];
        this.LossAttacker = new int[this.LossCounter + 1];
        this.LossOK = new int[this.LossCounter + 1];
        this.LossDEAD = new int[this.LossCounter + 1];
      }
      else
      {
        this.LossSFType = new int[1];
        this.LossAttacker = new int[1];
        this.LossOK = new int[1];
        this.LossDEAD = new int[1];
      }
      this.LossSFType = (int[]) info.GetValue(nameof (LossSFType), this.LossSFType.GetType());
      this.LossAttacker = (int[]) info.GetValue(nameof (LossAttacker), this.LossAttacker.GetType());
      this.LossOK = (int[]) info.GetValue(nameof (LossOK), this.LossOK.GetType());
      this.LossDEAD = (int[]) info.GetValue(nameof (LossDEAD), this.LossDEAD.GetType());
      this.LossRegimeWin = info.GetInt32(nameof (LossRegimeWin));
      this.LossDefReg = info.GetInt32(nameof (LossDefReg));
      this.LossAttReg = info.GetInt32(nameof (LossAttReg));
      this.InfoString = info.GetString(nameof (InfoString));
      try
      {
        this.His = info.GetInt32(nameof (His));
        this.Depth = info.GetInt32(nameof (Depth));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.His = -1;
        this.Depth = -1;
        ProjectData.ClearProjectError();
      }
    }

    public HistoryStepClass(int hardcoded)
    {
      this.AttackDirection = new int[6];
      this.LossSFType = new int[1];
      this.LossAttacker = new int[1];
      this.LossOK = new int[1];
      this.LossDEAD = new int[1];
      this.AttackOtherType = -1;
    }
  }
}
