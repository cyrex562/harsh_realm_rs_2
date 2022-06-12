// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MapMatrix2Coordinate
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
  public class MapMatrix2Coordinate : ISerializable
  {
    public int Width;
    public int Height;
    public Coordinate[,] Value;

    public MapMatrix2Coordinate Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (MapMatrix2Coordinate) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Width", this.Width);
      info.AddValue("Height", this.Height);
      if (this.Width <= -1)
        return;
      int[,] numArray1 = new int[this.Width + 1, this.Height + 1];
      int[,] numArray2 = new int[this.Width + 1, this.Height + 1];
      int[,] numArray3 = new int[this.Width + 1, this.Height + 1];
      int[,] numArray4 = new int[this.Width + 1, this.Height + 1];
      int[,] numArray5 = new int[this.Width + 1, this.Height + 1];
      bool[,] flagArray = new bool[this.Width + 1, this.Height + 1];
      int width = this.Width;
      for (int index1 = 0; index1 <= width; ++index1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; ++index2)
        {
          numArray1[index1, index2] = this.Value[index1, index2].x;
          numArray2[index1, index2] = this.Value[index1, index2].y;
          numArray3[index1, index2] = this.Value[index1, index2].map;
          numArray4[index1, index2] = this.Value[index1, index2].data1;
          numArray5[index1, index2] = this.Value[index1, index2].data2;
          flagArray[index1, index2] = this.Value[index1, index2].onmap;
        }
      }
      info.AddValue("t1", (object) numArray1);
      info.AddValue("t2", (object) numArray2);
      info.AddValue("t3", (object) numArray3);
      info.AddValue("t4", (object) numArray4);
      info.AddValue("t5", (object) numArray5);
      info.AddValue("t6", (object) flagArray);
    }

    protected MapMatrix2Coordinate(SerializationInfo info, StreamingContext context)
    {
      this.Value = new Coordinate[1, 1];
      this.Width = info.GetInt32(nameof (Width));
      this.Height = info.GetInt32(nameof (Height));
      this.Value = new Coordinate[this.Width + 1, this.Height + 1];
      if (this.Width <= 0)
        return;
      int[,] numArray1 = new int[this.Width + 1, this.Height + 1];
      int[,] numArray2 = new int[this.Width + 1, this.Height + 1];
      int[,] numArray3 = new int[this.Width + 1, this.Height + 1];
      int[,] numArray4 = new int[this.Width + 1, this.Height + 1];
      int[,] numArray5 = new int[this.Width + 1, this.Height + 1];
      bool[,] flagArray1 = new bool[this.Width + 1, this.Height + 1];
      if (this.Width <= -1)
        return;
      int[,] numArray6 = (int[,]) info.GetValue("t1", numArray1.GetType());
      int[,] numArray7 = (int[,]) info.GetValue("t2", numArray2.GetType());
      int[,] numArray8 = (int[,]) info.GetValue("t3", numArray3.GetType());
      int[,] numArray9 = (int[,]) info.GetValue("t4", numArray4.GetType());
      int[,] numArray10 = (int[,]) info.GetValue("t5", numArray5.GetType());
      bool[,] flagArray2 = (bool[,]) info.GetValue("t6", flagArray1.GetType());
      int width = this.Width;
      for (int index1 = 0; index1 <= width; ++index1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; ++index2)
        {
          this.Value[index1, index2].x = numArray6[index1, index2];
          this.Value[index1, index2].y = numArray7[index1, index2];
          this.Value[index1, index2].map = numArray8[index1, index2];
          this.Value[index1, index2].data1 = numArray9[index1, index2];
          this.Value[index1, index2].data2 = numArray10[index1, index2];
          this.Value[index1, index2].onmap = flagArray2[index1, index2];
        }
      }
    }

    public MapMatrix2Coordinate(int w, int h)
    {
      this.Value = new Coordinate[1, 1];
      this.Width = w;
      this.Height = h;
      this.Value = new Coordinate[this.Width + 1, this.Height + 1];
    }
  }
}
