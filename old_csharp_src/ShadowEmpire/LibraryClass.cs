// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.LibraryClass
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
  public class LibraryClass : ISerializable
  {
    public string name;
    public int version;
    public string creator;
    public string information;
    public string lastFileLocation;

    public LibraryClass()
    {
      this.name = "New Lib";
      this.version = 1;
      this.creator = "Unknown";
      this.information = "No info";
      this.lastFileLocation = "";
    }

    public LibraryClass Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (LibraryClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("name", (object) this.name);
      info.AddValue("version", this.version);
      info.AddValue("creator", (object) this.creator);
      info.AddValue("information", (object) this.information);
      info.AddValue("lastFileLocation", (object) this.lastFileLocation);
    }

    protected LibraryClass(SerializationInfo info, StreamingContext context)
    {
      this.name = info.GetString(nameof (name));
      this.version = info.GetInt32(nameof (version));
      this.creator = info.GetString(nameof (creator));
      this.information = info.GetString(nameof (information));
      this.lastFileLocation = info.GetString(nameof (lastFileLocation));
    }
  }
}
