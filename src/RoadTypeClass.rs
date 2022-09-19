// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.RoadTypeClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic.CompilerServices;
// usingSystem;
// usingSystem.Runtime.Serialization;

namespace WindowsApplication1
{
  [Serializable]
  pub class RoadTypeClass : ISerializable
  {
    pub Name: String;
    pub string[] BasicSpriteFileName;
    pub BasicSpriteID: Vec<i32>;
    pub MoveCostOverrule: Vec<i32>;
    pub EPCost: i32;
    pub Thickness: i32;
    pub LayerSpriteID: Vec<i32>;
    pub string[] LayerSpriteFileName;
    pub SpecialLayer: bool;
    pub FirstDrawOther: i32;
    pub SheetFileName: String;
    pub SheetSpriteID: i32;
    pub UseSheet: bool;
    pub Transparent: bool;
    pub Category: i32;
    pub string[] BridgeOverruleSpriteFileName;
    pub BridgeOverruleSpriteID: Vec<i32>;
    pub BridgeOverrule: bool;
    pub useCenter6: bool;
    pub center6spriteId: i32;
    pub center6spriteFileName: String;
    pub trafficPoints: i32;

    pub virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Name",  this.Name);
      info.AddValue("BasicSpriteFileName",  this.BasicSpriteFileName);
      info.AddValue("MoveCostOverrule",  this.MoveCostOverrule);
      info.AddValue("EPCost", this.EPCost);
      info.AddValue("Thickness", this.Thickness);
      info.AddValue("LayerSpriteFileName",  this.LayerSpriteFileName);
      info.AddValue("SpecialLayer", this.SpecialLayer);
      info.AddValue("FirstDrawOther", this.FirstDrawOther);
      info.AddValue("SheetFileName",  this.SheetFileName);
      info.AddValue("UseSheet", this.UseSheet);
      info.AddValue("Transparent", this.Transparent);
      info.AddValue("Category", this.Category);
      info.AddValue("BridgeOverrule", this.BridgeOverrule);
      info.AddValue("BridgeOverruleSpriteFileName",  this.BridgeOverruleSpriteFileName);
      info.AddValue("BridgeOverruleSpriteID",  this.BridgeOverruleSpriteID);
      info.AddValue("useCenter6", this.useCenter6);
      info.AddValue("center6spriteFileName",  this.center6spriteFileName);
      info.AddValue("trafficPoints", this.trafficPoints);
    }

    protected RoadTypeClass(SerializationInfo info, StreamingContext context)
    {
      this.BasicSpriteFileName = new string[6];
      this.BasicSpriteID = new int[6];
      this.MoveCostOverrule = new int[100];
      this.LayerSpriteID = new int[65];
      this.LayerSpriteFileName = new string[65];
      this.BridgeOverruleSpriteFileName = new string[6];
      this.BridgeOverruleSpriteID = new int[6];
      this.Name = info.GetString(nameof (Name));
      this.BasicSpriteFileName = (string[]) info.GetValue(nameof (BasicSpriteFileName), this.BasicSpriteFileName.GetType());
      this.MoveCostOverrule = (int[]) info.GetValue(nameof (MoveCostOverrule), this.MoveCostOverrule.GetType());
      this.MoveCostOverrule = (int[]) Utils.CopyArray((Array) this.MoveCostOverrule, (Array) new int[100]);
      this.EPCost = info.GetInt32(nameof (EPCost));
      try
      {
        this.Thickness = info.GetInt32(nameof (Thickness));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Thickness = 1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.useCenter6 = info.GetBoolean(nameof (useCenter6));
        this.center6spriteFileName = info.GetString(nameof (center6spriteFileName));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.useCenter6 = false;
        this.center6spriteFileName = "systemgraphics/trans.bmp";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.LayerSpriteFileName = (string[]) info.GetValue(nameof (LayerSpriteFileName), this.LayerSpriteFileName.GetType());
        this.SpecialLayer = info.GetBoolean(nameof (SpecialLayer));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.LayerSpriteFileName = new string[65];
        this.SpecialLayer = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.FirstDrawOther = info.GetInt32(nameof (FirstDrawOther));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.FirstDrawOther = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.SheetFileName = info.GetString(nameof (SheetFileName));
        this.UseSheet = info.GetBoolean(nameof (UseSheet));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.SheetFileName = "systemgraphics/trans.bmp";
        this.UseSheet = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.Transparent = info.GetBoolean(nameof (Transparent));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Transparent = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.Category = info.GetInt32(nameof (Category));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Category = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.BridgeOverrule = info.GetBoolean(nameof (BridgeOverrule));
        this.BridgeOverruleSpriteFileName = (string[]) info.GetValue(nameof (BridgeOverruleSpriteFileName), this.BridgeOverruleSpriteFileName.GetType());
        this.BridgeOverruleSpriteID = (int[]) info.GetValue(nameof (BridgeOverruleSpriteID), this.BridgeOverruleSpriteID.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.BridgeOverrule = false;
        this.BridgeOverruleSpriteFileName = new string[6];
        this.BridgeOverruleSpriteID = new int[6];
        let mut index: i32 = 0;
        do
        {
          this.BridgeOverruleSpriteFileName[index] = "systemgraphics/trans.bmp";
          index += 1;
        }
        while (index <= 5);
        ProjectData.ClearProjectError();
      }
      try
      {
        this.trafficPoints = info.GetInt32(nameof (trafficPoints));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.trafficPoints = 0;
        ProjectData.ClearProjectError();
      }
    }

    pub void AutoLoadSpecial(string dirstring, string extstring)
    {
      this.LayerSpriteFileName[1] = dirstring + "/a1" + extstring;
      this.LayerSpriteFileName[2] = dirstring + "/b1" + extstring;
      this.LayerSpriteFileName[3] = dirstring + "/b2" + extstring;
      this.LayerSpriteFileName[4] = dirstring + "/b3" + extstring;
      this.LayerSpriteFileName[5] = dirstring + "/b4" + extstring;
      this.LayerSpriteFileName[6] = dirstring + "/b5" + extstring;
      this.LayerSpriteFileName[7] = dirstring + "/b6" + extstring;
      this.LayerSpriteFileName[8] = dirstring + "/c1" + extstring;
      this.LayerSpriteFileName[9] = dirstring + "/c2" + extstring;
      this.LayerSpriteFileName[10] = dirstring + "/c3" + extstring;
      this.LayerSpriteFileName[11] = dirstring + "/c4" + extstring;
      this.LayerSpriteFileName[12] = dirstring + "/c5" + extstring;
      this.LayerSpriteFileName[13] = dirstring + "/c6" + extstring;
      this.LayerSpriteFileName[14] = dirstring + "/c7" + extstring;
      this.LayerSpriteFileName[15] = dirstring + "/c8" + extstring;
      this.LayerSpriteFileName[16] = dirstring + "/c9" + extstring;
      this.LayerSpriteFileName[17] = dirstring + "/c10" + extstring;
      this.LayerSpriteFileName[18] = dirstring + "/c11" + extstring;
      this.LayerSpriteFileName[19] = dirstring + "/c12" + extstring;
      this.LayerSpriteFileName[20] = dirstring + "/c13" + extstring;
      this.LayerSpriteFileName[21] = dirstring + "/c14" + extstring;
      this.LayerSpriteFileName[22] = dirstring + "/c15" + extstring;
      this.LayerSpriteFileName[23] = dirstring + "/d1" + extstring;
      this.LayerSpriteFileName[24] = dirstring + "/d2" + extstring;
      this.LayerSpriteFileName[25] = dirstring + "/d3" + extstring;
      this.LayerSpriteFileName[26] = dirstring + "/d4" + extstring;
      this.LayerSpriteFileName[27] = dirstring + "/d5" + extstring;
      this.LayerSpriteFileName[28] = dirstring + "/d6" + extstring;
      this.LayerSpriteFileName[29] = dirstring + "/d7" + extstring;
      this.LayerSpriteFileName[30] = dirstring + "/d8" + extstring;
      this.LayerSpriteFileName[31] = dirstring + "/d9" + extstring;
      this.LayerSpriteFileName[32] = dirstring + "/d10" + extstring;
      this.LayerSpriteFileName[33] = dirstring + "/d11" + extstring;
      this.LayerSpriteFileName[34] = dirstring + "/d12" + extstring;
      this.LayerSpriteFileName[35] = dirstring + "/d13" + extstring;
      this.LayerSpriteFileName[36] = dirstring + "/d14" + extstring;
      this.LayerSpriteFileName[37] = dirstring + "/d15" + extstring;
      this.LayerSpriteFileName[38] = dirstring + "/d16" + extstring;
      this.LayerSpriteFileName[39] = dirstring + "/d17" + extstring;
      this.LayerSpriteFileName[40] = dirstring + "/d18" + extstring;
      this.LayerSpriteFileName[41] = dirstring + "/d19" + extstring;
      this.LayerSpriteFileName[42] = dirstring + "/d20" + extstring;
      this.LayerSpriteFileName[43] = dirstring + "/e1" + extstring;
      this.LayerSpriteFileName[44] = dirstring + "/e2" + extstring;
      this.LayerSpriteFileName[45] = dirstring + "/e3" + extstring;
      this.LayerSpriteFileName[46] = dirstring + "/e4" + extstring;
      this.LayerSpriteFileName[47] = dirstring + "/e5" + extstring;
      this.LayerSpriteFileName[48] = dirstring + "/e6" + extstring;
      this.LayerSpriteFileName[49] = dirstring + "/e7" + extstring;
      this.LayerSpriteFileName[50] = dirstring + "/e8" + extstring;
      this.LayerSpriteFileName[51] = dirstring + "/e9" + extstring;
      this.LayerSpriteFileName[52] = dirstring + "/e10" + extstring;
      this.LayerSpriteFileName[53] = dirstring + "/e11" + extstring;
      this.LayerSpriteFileName[54] = dirstring + "/e12" + extstring;
      this.LayerSpriteFileName[55] = dirstring + "/e13" + extstring;
      this.LayerSpriteFileName[56] = dirstring + "/e14" + extstring;
      this.LayerSpriteFileName[57] = dirstring + "/e15" + extstring;
      this.LayerSpriteFileName[58] = dirstring + "/f1" + extstring;
      this.LayerSpriteFileName[59] = dirstring + "/f2" + extstring;
      this.LayerSpriteFileName[60] = dirstring + "/f3" + extstring;
      this.LayerSpriteFileName[61] = dirstring + "/f4" + extstring;
      this.LayerSpriteFileName[62] = dirstring + "/f5" + extstring;
      this.LayerSpriteFileName[63] = dirstring + "/f6" + extstring;
      this.LayerSpriteFileName[64] = dirstring + "/g1" + extstring;
      this.ReloadSpecialSprites();
    }

    pub RoadTypeClass(int hardcoded)
    {
      this.BasicSpriteFileName = new string[6];
      this.BasicSpriteID = new int[6];
      this.MoveCostOverrule = new int[100];
      this.LayerSpriteID = new int[65];
      this.LayerSpriteFileName = new string[65];
      this.BridgeOverruleSpriteFileName = new string[6];
      this.BridgeOverruleSpriteID = new int[6];
      this.FirstDrawOther = -1;
      this.Category = -1;
      this.trafficPoints = 0;
      if (hardcoded == 0)
      {
        this.Name = "Default Road";
        this.BasicSpriteFileName[0] = "systemgraphics/trans.bmp";
        this.BasicSpriteFileName[1] = "systemgraphics/trans.bmp";
        this.BasicSpriteFileName[2] = "systemgraphics/trans.bmp";
        this.BasicSpriteFileName[3] = "systemgraphics/trans.bmp";
        this.BasicSpriteFileName[4] = "systemgraphics/trans.bmp";
        this.BasicSpriteFileName[5] = "systemgraphics/trans.bmp";
        this.EPCost = -1;
      }
      this.useCenter6 = false;
      this.center6spriteFileName = "systemgraphics/trans.bmp";
      this.SheetFileName = "systemgraphics/trans.bmp";
      this.UseSheet = false;
      this.BridgeOverrule = false;
      this.BridgeOverruleSpriteFileName = new string[6];
      this.BridgeOverruleSpriteID = new int[6];
      let mut index: i32 = 0;
      do
      {
        this.BridgeOverruleSpriteFileName[index] = "systemgraphics/trans.bmp";
        index += 1;
      }
      while (index <= 5);
    }

    pub void Kill()
    {
      let mut index1: i32 = 0;
      do
      {
        BitmapStore.RemoveBitmapNr(this.BasicSpriteID[index1]);
        index1 += 1;
      }
      while (index1 <= 5);
      if (!this.SpecialLayer || this.UseSheet)
        return;
      let mut index2: i32 = 1;
      do
      {
        BitmapStore.RemoveBitmapNr(this.LayerSpriteID[index2]);
        index2 += 1;
      }
      while (index2 <= 64);
    }

    pub void ReplaceCenter6(string filename)
    {
      this.center6spriteFileName = filename;
      this.center6spriteId = BitmapStore.ReloadFile(this.center6spriteId, filename, IsBig: true);
    }

    pub void ReplaceBasicSprite(int nr, string filename)
    {
      this.BasicSpriteFileName[nr] = filename;
      this.BasicSpriteID[nr] = BitmapStore.ReloadFile(this.BasicSpriteID[nr], filename, IsBig: true);
    }

    pub void ReplaceBridgeOverruleSprite(int nr, string filename)
    {
      this.BridgeOverruleSpriteFileName[nr] = filename;
      this.BridgeOverruleSpriteID[nr] = BitmapStore.ReloadFile(this.BridgeOverruleSpriteID[nr], filename, IsBig: true);
    }

    pub void ReloadSpecialSprites()
    {
      let mut index: i32 = 1;
      do
      {
        this.LayerSpriteID[index] = this.LayerSpriteID[index] <= 0 ? BitmapStore.AddFile(this.LayerSpriteFileName[index], false, true) : BitmapStore.ReloadFile(this.LayerSpriteID[index], this.LayerSpriteFileName[index], IsBig: true);
        index += 1;
      }
      while (index <= 64);
    }

    pub void ReplaceSpriteSheet(string filename)
    {
      this.SheetFileName = filename;
      this.SheetSpriteID = BitmapStore.ReloadFile(this.SheetSpriteID, this.SheetFileName, IsBig: true);
    }

    pub void LoadSprites()
    {
      this.center6spriteId = BitmapStore.AddFile(this.center6spriteFileName, false, true);
      let mut index1: i32 = 0;
      do
      {
        this.BasicSpriteID[index1] = BitmapStore.AddFile(this.BasicSpriteFileName[index1], false, true);
        this.BridgeOverruleSpriteID[index1] = BitmapStore.AddFile(this.BridgeOverruleSpriteFileName[index1], false, true);
        index1 += 1;
      }
      while (index1 <= 5);
      if (this.SpecialLayer && !this.UseSheet)
      {
        let mut index2: i32 = 1;
        do
        {
          this.LayerSpriteID[index2] = BitmapStore.AddFile(this.LayerSpriteFileName[index2], false, true);
          index2 += 1;
        }
        while (index2 <= 64);
      }
      this.SheetSpriteID = BitmapStore.AddFile(this.SheetFileName, false, true);
    }
  }
}
