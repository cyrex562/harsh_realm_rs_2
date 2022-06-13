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
  pub class LibraryClass : ISerializable
  {
    pub name: String;
    pub version: i32;
    pub creator: String;
    pub information: String;
    pub lastFileLocation: String;

    pub LibraryClass()
    {
      this.name = "New Lib";
      this.version = 1;
      this.creator = "Unknown";
      this.information = "No info";
      this.lastFileLocation = "";
    }

    pub LibraryClass Clone()
    {
      BinaryFormatter binaryFormatter = BinaryFormatter::new();
      MemoryStream serializationStream = MemoryStream::new();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (LibraryClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    pub virtual void GetObjectData(SerializationInfo info, StreamingContext context)
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
