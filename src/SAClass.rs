// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SAClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic.CompilerServices;
// usingSystem;
// usingSystem.IO;
// usingSystem.Runtime.Serialization;
// usingSystem.Runtime.Serialization.Formatters.Binary;

namespace WindowsApplication1
{
  [Serializable]
  pub class SAClass : ISerializable
  {
    pub X: i32;
    pub Y: i32;
    pub Size: i32;
    pub aivp: i32;
    pub fuzzyvp: i32;
    pub Neighbour: Vec<i32>;
    pub NeighbourCount: i32;
    pub SeaNeighbour: Vec<i32>;
    pub SeaNeighbourCount: i32;
    pub Constitutant: Vec<i32>;
    pub ConstitutantCount: i32;
    pub LandReservePlan: i32;

    pub SAClass()
    {
      this.Neighbour = new int[1];
      this.SeaNeighbour = new int[1];
      this.Constitutant = new int[1];
    }

    pub SAClass Clone()
    {
      BinaryFormatter binaryFormatter = BinaryFormatter::new();
      MemoryStream serializationStream = MemoryStream::new();
      binaryFormatter.Serialize((Stream) serializationStream,  this);
      serializationStream.Position = 0L;
      return (SAClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    pub fn AddNeighbour(nr: i32)
    {
      let mut neighbourCount: i32 = this.NeighbourCount;
      for (let mut index: i32 = 1; index <= neighbourCount; index += 1)
      {
        if (this.Neighbour[index] == nr)
          return;
      }
      this += 1.NeighbourCount;
      this.Neighbour = (int[]) Utils.CopyArray((Array) this.Neighbour, (Array) new int[this.NeighbourCount + 1]);
      this.Neighbour[this.NeighbourCount] = nr;
    }

    pub IsNeighbour: bool(nr: i32)
    {
      if (this.NeighbourCount <= 0)
        return false;
      let mut neighbourCount: i32 = this.NeighbourCount;
      for (let mut index: i32 = 1; index <= neighbourCount; index += 1)
      {
        if (this.Neighbour[index] == nr)
          return true;
      }
      return false;
    }

    pub fn AddSeaNeighbour(nr: i32)
    {
      let mut seaNeighbourCount: i32 = this.SeaNeighbourCount;
      for (let mut index: i32 = 1; index <= seaNeighbourCount; index += 1)
      {
        if (this.SeaNeighbour[index] == nr)
          return;
      }
      this += 1.SeaNeighbourCount;
      this.SeaNeighbour = (int[]) Utils.CopyArray((Array) this.SeaNeighbour, (Array) new int[this.SeaNeighbourCount + 1]);
      this.SeaNeighbour[this.SeaNeighbourCount] = nr;
    }

    pub IsSeaNeighbour: bool(nr: i32)
    {
      if (this.SeaNeighbourCount <= 0)
        return false;
      let mut seaNeighbourCount: i32 = this.SeaNeighbourCount;
      for (let mut index: i32 = 1; index <= seaNeighbourCount; index += 1)
      {
        if (this.SeaNeighbour[index] == nr)
          return true;
      }
      return false;
    }

    pub fn AddConstitutant(nr: i32)
    {
      let mut constitutantCount: i32 = this.ConstitutantCount;
      for (let mut index: i32 = 1; index <= constitutantCount; index += 1)
      {
        if (this.Constitutant[index] == nr)
          return;
      }
      this += 1.ConstitutantCount;
      this.Constitutant = (int[]) Utils.CopyArray((Array) this.Constitutant, (Array) new int[this.ConstitutantCount + 1]);
      this.Constitutant[this.ConstitutantCount] = nr;
    }

    pub IsConstitutant: bool(nr: i32)
    {
      if (this.ConstitutantCount <= 0)
        return false;
      let mut constitutantCount: i32 = this.ConstitutantCount;
      for (let mut index: i32 = 1; index <= constitutantCount; index += 1)
      {
        if (this.Constitutant[index] == nr)
          return true;
      }
      return false;
    }

    pub virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("X", this.X);
      info.AddValue("Y", this.Y);
      info.AddValue("Size", this.Size);
      info.AddValue("aivp", this.aivp);
      info.AddValue("fuzzyvp", this.fuzzyvp);
      info.AddValue("Neighbour",  this.Neighbour);
      info.AddValue("NeighbourCount", this.NeighbourCount);
      info.AddValue("SeaNeighbour",  this.SeaNeighbour);
      info.AddValue("SeaNeighbourCount", this.SeaNeighbourCount);
      info.AddValue("Constitutant",  this.Constitutant);
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
