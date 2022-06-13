// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ResearchClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.Serialization;

namespace WindowsApplication1
{
  [Serializable]
  pub class ResearchClass : ISerializable
  {
    pub Name: String;
    pub Text: String;
    pub int[] PointCost;
    pub SFTypePic: i32;
    pub PreReq: i32;
    pub PreReq2: i32;
    pub Blocks: i32;
    pub TechLevel: i32;
    pub CostType: i32;
    pub UpgradeCost: i32;

    pub virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Name", (object) this.Name);
      info.AddValue("Text", (object) this.Text);
      info.AddValue("PointCost", (object) this.PointCost);
      info.AddValue("SFTypePic", this.SFTypePic);
      info.AddValue("PreReq", this.PreReq);
      info.AddValue("PreReq2", this.PreReq2);
      info.AddValue("Blocks", this.Blocks);
      info.AddValue("TechLevel", this.TechLevel);
      info.AddValue("CostType", this.CostType);
      info.AddValue("UpgradeCost", this.UpgradeCost);
    }

    protected ResearchClass(SerializationInfo info, StreamingContext context)
    {
      this.PointCost = new int[100];
      this.Name = info.GetString(nameof (Name));
      this.Text = info.GetString(nameof (Text));
      this.PointCost = (int[]) info.GetValue(nameof (PointCost), this.PointCost.GetType());
      this.PointCost = (int[]) Utils.CopyArray((Array) this.PointCost, (Array) new int[100]);
      this.SFTypePic = info.GetInt32(nameof (SFTypePic));
      this.PreReq = info.GetInt32(nameof (PreReq));
      this.PreReq2 = info.GetInt32(nameof (PreReq2));
      this.Blocks = info.GetInt32(nameof (Blocks));
      this.TechLevel = info.GetInt32(nameof (TechLevel));
      try
      {
        this.CostType = info.GetInt32(nameof (CostType));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.CostType = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.UpgradeCost = info.GetInt32(nameof (UpgradeCost));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.UpgradeCost = -1;
        ProjectData.ClearProjectError();
      }
    }

    pub ResearchClass(int hardcoded)
    {
      this.PointCost = new int[100];
      if (hardcoded != 0)
        return;
      this.Name = "A default Research Field";
      this.Text = "Description...";
      let mut index: i32 = 0;
      do
      {
        this.PointCost[index] = 10;
        index += 1;
      }
      while (index <= 19);
      this.SFTypePic = -1;
      this.UpgradeCost = -1;
      this.PreReq = -1;
      this.PreReq2 = -1;
      this.CostType = -1;
      this.Blocks = -1;
      this.TechLevel = -1;
    }

    pub void Kill()
    {
    }

    pub void LoadSprites()
    {
    }
  }
}
