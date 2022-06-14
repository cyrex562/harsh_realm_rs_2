// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.BridgeClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.Serialization;

namespace WindowsApplication1
{
  [Serializable]
  pub class BridgeClass : ISerializable
  {
    pub string[] BasicSpriteFileName;
    pub int[] BasicSpriteID;
    pub string[] AlternateSpriteFileName;
    pub int[] AlternateSpriteID;
    pub AlternateIfRoadType: i32;
    pub AlternateIfRoadType2: i32;
    pub AlternateIfRoadType3: i32;
    pub AlternateIfRoadType4: i32;
    pub EPCost: i32;

    pub virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("BasicSpriteFileName", (object) this.BasicSpriteFileName);
      info.AddValue("AlternateSpriteFileName", (object) this.AlternateSpriteFileName);
      info.AddValue("EPCost", this.EPCost);
      info.AddValue("AlternateIfRoadType", this.AlternateIfRoadType);
      info.AddValue("AlternateIfRoadType2", this.AlternateIfRoadType2);
      info.AddValue("AlternateIfRoadType3", this.AlternateIfRoadType3);
      info.AddValue("AlternateIfRoadType4", this.AlternateIfRoadType4);
    }

    protected BridgeClass(SerializationInfo info, StreamingContext context)
    {
      this.BasicSpriteFileName = new string[6];
      this.BasicSpriteID = new int[6];
      this.AlternateSpriteFileName = new string[6];
      this.AlternateSpriteID = new int[6];
      this.BasicSpriteFileName = (string[]) info.GetValue(nameof (BasicSpriteFileName), this.BasicSpriteFileName.GetType());
      this.EPCost = info.GetInt32(nameof (EPCost));
      try
      {
        this.AlternateIfRoadType = info.GetInt32(nameof (AlternateIfRoadType));
        this.AlternateSpriteFileName = (string[]) info.GetValue(nameof (AlternateSpriteFileName), this.AlternateSpriteFileName.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.AlternateSpriteFileName[0] = "systemgraphics/trans.bmp";
        this.AlternateSpriteFileName[1] = "systemgraphics/trans.bmp";
        this.AlternateSpriteFileName[2] = "systemgraphics/trans.bmp";
        this.AlternateSpriteFileName[3] = "systemgraphics/trans.bmp";
        this.AlternateSpriteFileName[4] = "systemgraphics/trans.bmp";
        this.AlternateSpriteFileName[5] = "systemgraphics/trans.bmp";
        this.AlternateIfRoadType = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.AlternateIfRoadType2 = info.GetInt32(nameof (AlternateIfRoadType2));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.AlternateIfRoadType2 = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.AlternateIfRoadType3 = info.GetInt32(nameof (AlternateIfRoadType3));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.AlternateIfRoadType3 = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.AlternateIfRoadType4 = info.GetInt32(nameof (AlternateIfRoadType4));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.AlternateIfRoadType4 = -1;
        ProjectData.ClearProjectError();
      }
    }

    pub BridgeClass(int hardcoded)
    {
      this.BasicSpriteFileName = new string[6];
      this.BasicSpriteID = new int[6];
      this.AlternateSpriteFileName = new string[6];
      this.AlternateSpriteID = new int[6];
      if (hardcoded == 0)
      {
        this.BasicSpriteFileName[0] = "systemgraphics/trans.bmp";
        this.BasicSpriteFileName[1] = "systemgraphics/trans.bmp";
        this.BasicSpriteFileName[2] = "systemgraphics/trans.bmp";
        this.BasicSpriteFileName[3] = "systemgraphics/trans.bmp";
        this.BasicSpriteFileName[4] = "systemgraphics/trans.bmp";
        this.BasicSpriteFileName[5] = "systemgraphics/trans.bmp";
        this.AlternateSpriteFileName[0] = "systemgraphics/trans.bmp";
        this.AlternateSpriteFileName[1] = "systemgraphics/trans.bmp";
        this.AlternateSpriteFileName[2] = "systemgraphics/trans.bmp";
        this.AlternateSpriteFileName[3] = "systemgraphics/trans.bmp";
        this.AlternateSpriteFileName[4] = "systemgraphics/trans.bmp";
        this.AlternateSpriteFileName[5] = "systemgraphics/trans.bmp";
      }
      this.AlternateIfRoadType = -1;
      this.AlternateIfRoadType2 = -1;
      this.AlternateIfRoadType3 = -1;
      this.AlternateIfRoadType4 = -1;
    }

    pub void Kill()
    {
      let mut index: i32 =  0;
      do
      {
        BitmapStore.RemoveBitmapNr(this.BasicSpriteID[index]);
        index += 1;
      }
      while (index <= 5);
    }

    pub void ReplaceBasicSprite(int nr, string filename)
    {
      this.BasicSpriteFileName[nr] = filename;
      this.BasicSpriteID[nr] = BitmapStore.ReloadFile(this.BasicSpriteID[nr], filename, IsBig: true);
    }

    pub void ReplaceAlternateSprite(int nr, string filename)
    {
      this.AlternateSpriteFileName[nr] = filename;
      this.AlternateSpriteID[nr] = BitmapStore.ReloadFile(this.AlternateSpriteID[nr], filename, IsBig: true);
    }

    pub void LoadSprites()
    {
      let mut index: i32 =  0;
      do
      {
        this.BasicSpriteID[index] = BitmapStore.AddFile(this.BasicSpriteFileName[index], false, true);
        this.AlternateSpriteID[index] = BitmapStore.AddFile(this.AlternateSpriteFileName[index], false, true);
        index += 1;
      }
      while (index <= 5);
    }
  }
}
