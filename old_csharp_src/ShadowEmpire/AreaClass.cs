// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.AreaClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsApplication1
{
  [Serializable]
  public class AreaClass : ISerializable
  {
    public string Name;
    public int Slot;
    public int Code;
    public int ID;

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Name", (object) this.Name);
      info.AddValue("Slot", this.Slot);
      info.AddValue("Code", this.Code);
      info.AddValue("ID", this.ID);
    }

    protected AreaClass(SerializationInfo info, StreamingContext context)
    {
      this.Name = info.GetString(nameof (Name));
      this.Slot = info.GetInt32(nameof (Slot));
      this.Code = info.GetInt32(nameof (Code));
      this.ID = info.GetInt32(nameof (ID));
    }

    public AreaClass()
    {
      this.Name = "New Area";
      this.Slot = -1;
      this.Code = -1;
    }

    public AreaClass Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (AreaClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }
  }
}
