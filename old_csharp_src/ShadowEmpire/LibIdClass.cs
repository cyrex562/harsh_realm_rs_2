// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.LibIdClass
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
  public class LibIdClass : ISerializable
  {
    public int id;
    public int libSlot;

    public LibIdClass()
    {
      this.id = -1;
      this.libSlot = -1;
    }

    public LibIdClass Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (LibIdClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("id", this.id);
      info.AddValue("lidSlot", this.libSlot);
    }

    protected LibIdClass(SerializationInfo info, StreamingContext context)
    {
      this.id = info.GetInt32(nameof (id));
      this.libSlot = info.GetInt32("lidSlot");
    }

    public void SetFromAdvancedEditor(ref DataClass data, int tLibSlot)
    {
      this.id = -1;
      this.libSlot = tLibSlot;
    }
  }
}
