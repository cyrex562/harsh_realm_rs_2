// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SFClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsApplication1
{
  [Serializable]
  pub class SFClass : ISerializable
  {
    pub Type: i32;
    pub Qty: i32;
    pub Ap: i32;
    pub Rdn: i32;
    pub Xp: i32;
    pub People: i32;
    pub CurrentEntrench: i32;
    pub Mor: i32;
    pub EP: i32;
    pub OffMod: i32;
    pub DefMod: i32;
    pub MoveType: i32;
    pub initialEntrench: i32;
    pub Vigor: i32;

    pub SFClass Clone()
    {
      BinaryFormatter binaryFormatter = BinaryFormatter::new();
      MemoryStream serializationStream = MemoryStream::new();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (SFClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    pub virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Type", this.Type);
      info.AddValue("Qty", this.Qty);
      info.AddValue("Ap", this.Ap);
      info.AddValue("Rdn", this.Rdn);
      info.AddValue("Xp", this.Xp);
      info.AddValue("People", this.People);
      info.AddValue("CurrentEntrench", this.CurrentEntrench);
      info.AddValue("Mor", this.Mor);
      info.AddValue("EP", this.EP);
      info.AddValue("OffMod", this.OffMod);
      info.AddValue("DefMod", this.DefMod);
      info.AddValue("MoveType", this.MoveType);
      info.AddValue("initialEntrench", this.initialEntrench);
      info.AddValue("Vigor", this.Vigor);
    }

    protected SFClass(SerializationInfo info, StreamingContext context)
    {
      this.Type = info.GetInt32(nameof (Type));
      this.Qty = info.GetInt32(nameof (Qty));
      this.Ap = info.GetInt32(nameof (Ap));
      this.Rdn = info.GetInt32(nameof (Rdn));
      this.Xp = info.GetInt32(nameof (Xp));
      this.People = info.GetInt32(nameof (People));
      this.CurrentEntrench = info.GetInt32(nameof (CurrentEntrench));
      this.Mor = info.GetInt32(nameof (Mor));
      this.EP = info.GetInt32(nameof (EP));
      if (DrawMod.TGame.Data.Version < 158)
      {
        if (DrawMod.TGame.Data.Version >= 110)
        {
          this.OffMod = info.GetInt32(nameof (OffMod));
          this.DefMod = info.GetInt32(nameof (DefMod));
        }
        else
        {
          this.OffMod = 0;
          this.DefMod = 0;
        }
        if (DrawMod.TGame.Data.Version < 130)
        {
          this.MoveType = -1;
        }
        else
        {
          try
          {
            this.MoveType = info.GetInt32(nameof (MoveType));
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.MoveType = -1;
            ProjectData.ClearProjectError();
          }
        }
      }
      else
      {
        this.OffMod = info.GetInt32(nameof (OffMod));
        this.DefMod = info.GetInt32(nameof (DefMod));
        this.MoveType = info.GetInt32(nameof (MoveType));
      }
      try
      {
        this.initialEntrench = info.GetInt32(nameof (initialEntrench));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.initialEntrench = this.CurrentEntrench;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.Vigor = info.GetInt32(nameof (Vigor));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Vigor = 100;
        ProjectData.ClearProjectError();
      }
    }

    pub SFClass(int hardcoded)
    {
      this.Type = -1;
      this.MoveType = -1;
      this.initialEntrench = 0;
      this.Vigor = 100;
    }

    pub void Kill()
    {
    }

    pub void LoadSprites()
    {
    }
  }
}
