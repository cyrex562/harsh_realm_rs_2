// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SAClass
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
  public class SAClass : ISerializable
  {
    public int X;
    public int Y;
    public int Size;
    public int aivp;
    public int fuzzyvp;
    public int[] Neighbour;
    public int NeighbourCount;
    public int[] SeaNeighbour;
    public int SeaNeighbourCount;
    public int[] Constitutant;
    public int ConstitutantCount;
    public int LandReservePlan;

    public SAClass()
    {
      this.Neighbour = new int[1];
      this.SeaNeighbour = new int[1];
      this.Constitutant = new int[1];
    }

    public SAClass Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (SAClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    public void AddNeighbour(int nr)
    {
      int neighbourCount = this.NeighbourCount;
      for (int index = 1; index <= neighbourCount; ++index)
      {
        if (this.Neighbour[index] == nr)
          return;
      }
      ++this.NeighbourCount;
      this.Neighbour = (int[]) Utils.CopyArray((Array) this.Neighbour, (Array) new int[this.NeighbourCount + 1]);
      this.Neighbour[this.NeighbourCount] = nr;
    }

    public bool IsNeighbour(int nr)
    {
      if (this.NeighbourCount <= 0)
        return false;
      int neighbourCount = this.NeighbourCount;
      for (int index = 1; index <= neighbourCount; ++index)
      {
        if (this.Neighbour[index] == nr)
          return true;
      }
      return false;
    }

    public void AddSeaNeighbour(int nr)
    {
      int seaNeighbourCount = this.SeaNeighbourCount;
      for (int index = 1; index <= seaNeighbourCount; ++index)
      {
        if (this.SeaNeighbour[index] == nr)
          return;
      }
      ++this.SeaNeighbourCount;
      this.SeaNeighbour = (int[]) Utils.CopyArray((Array) this.SeaNeighbour, (Array) new int[this.SeaNeighbourCount + 1]);
      this.SeaNeighbour[this.SeaNeighbourCount] = nr;
    }

    public bool IsSeaNeighbour(int nr)
    {
      if (this.SeaNeighbourCount <= 0)
        return false;
      int seaNeighbourCount = this.SeaNeighbourCount;
      for (int index = 1; index <= seaNeighbourCount; ++index)
      {
        if (this.SeaNeighbour[index] == nr)
          return true;
      }
      return false;
    }

    public void AddConstitutant(int nr)
    {
      int constitutantCount = this.ConstitutantCount;
      for (int index = 1; index <= constitutantCount; ++index)
      {
        if (this.Constitutant[index] == nr)
          return;
      }
      ++this.ConstitutantCount;
      this.Constitutant = (int[]) Utils.CopyArray((Array) this.Constitutant, (Array) new int[this.ConstitutantCount + 1]);
      this.Constitutant[this.ConstitutantCount] = nr;
    }

    public bool IsConstitutant(int nr)
    {
      if (this.ConstitutantCount <= 0)
        return false;
      int constitutantCount = this.ConstitutantCount;
      for (int index = 1; index <= constitutantCount; ++index)
      {
        if (this.Constitutant[index] == nr)
          return true;
      }
      return false;
    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("X", this.X);
      info.AddValue("Y", this.Y);
      info.AddValue("Size", this.Size);
      info.AddValue("aivp", this.aivp);
      info.AddValue("fuzzyvp", this.fuzzyvp);
      info.AddValue("Neighbour", (object) this.Neighbour);
      info.AddValue("NeighbourCount", this.NeighbourCount);
      info.AddValue("SeaNeighbour", (object) this.SeaNeighbour);
      info.AddValue("SeaNeighbourCount", this.SeaNeighbourCount);
      info.AddValue("Constitutant", (object) this.Constitutant);
      info.AddValue("ConstitutantCount", this.ConstitutantCount);
      info.AddValue("LandReservePlan", this.LandReservePlan);
    }

    protected SAClass(SerializationInfo info, StreamingContext context)
    {
      this.Neighbour = new int[1];
      this.SeaNeighbour = new int[1];
      this.Constitutant = new int[1];
      this.X = info.GetInt32(nameof (X));
      this.Y = info.GetInt32(nameof (Y));
      this.Size = info.GetInt32(nameof (Size));
      this.aivp = info.GetInt32(nameof (aivp));
      this.fuzzyvp = info.GetInt32(nameof (fuzzyvp));
      this.NeighbourCount = info.GetInt32(nameof (NeighbourCount));
      this.SeaNeighbourCount = info.GetInt32(nameof (SeaNeighbourCount));
      this.ConstitutantCount = info.GetInt32(nameof (ConstitutantCount));
      this.Neighbour = new int[this.NeighbourCount + 1];
      this.SeaNeighbour = new int[this.SeaNeighbourCount + 1];
      this.Constitutant = new int[this.ConstitutantCount + 1];
      this.Neighbour = (int[]) info.GetValue(nameof (Neighbour), this.Neighbour.GetType());
      this.Constitutant = (int[]) info.GetValue(nameof (Constitutant), this.Constitutant.GetType());
      this.LandReservePlan = info.GetInt32(nameof (LandReservePlan));
    }
  }
}
