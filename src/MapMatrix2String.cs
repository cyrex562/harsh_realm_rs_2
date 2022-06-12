﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MapMatrix2String
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
  public class MapMatrix2String : ISerializable
  {
    public int Width;
    public int Height;
    public string[,] Value;

    public MapMatrix2 Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (MapMatrix2) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Width", this.Width);
      info.AddValue("Height", this.Height);
      info.AddValue("Value", (object) this.Value);
    }

    protected MapMatrix2String(SerializationInfo info, StreamingContext context)
    {
      this.Value = new string[1, 1];
      this.Width = info.GetInt32(nameof (Width));
      this.Height = info.GetInt32(nameof (Height));
      this.Value = new string[this.Width + 1, this.Height + 1];
      this.Value = (string[,]) info.GetValue(nameof (Value), this.Value.GetType());
    }

    public MapMatrix2String(int w, int h)
    {
      this.Value = new string[1, 1];
      this.Width = w;
      this.Height = h;
      this.Value = new string[this.Width + 1, this.Height + 1];
    }
  }
}
