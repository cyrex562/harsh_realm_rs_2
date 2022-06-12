// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleList
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsApplication1
{
  [Serializable]
  public class SimpleList : ISerializable
  {
    public int Counter;
    public int MaxCounter;
    public int[] Id;
    public int[] Weight;
    public int[] Data1;
    public int[] Data2;
    public int[] Data3;
    public int[] Data4;
    public int[] Data5;

    public SimpleList()
    {
      this.Id = new int[11];
      this.Weight = new int[11];
      this.Data1 = new int[11];
      this.Data2 = new int[11];
      this.Data3 = new int[11];
      this.Data4 = new int[11];
      this.Data5 = new int[11];
      this.Counter = -1;
      this.MaxCounter = 10;
    }

    public SimpleList Clone()
    {
      if (this.Counter == -1)
        return new SimpleList();
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (SimpleList) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Counter", this.Counter);
      info.AddValue("MaxCounter", this.MaxCounter);
      info.AddValue("Id", (object) this.Id);
      info.AddValue("Weight", (object) this.Weight);
      info.AddValue("Data1", (object) this.Data1);
      info.AddValue("Data2", (object) this.Data2);
      info.AddValue("Data3", (object) this.Data3);
      info.AddValue("Data4", (object) this.Data4);
      info.AddValue("Data5", (object) this.Data5);
    }

    protected SimpleList(SerializationInfo info, StreamingContext context)
    {
      this.Id = new int[11];
      this.Weight = new int[11];
      this.Data1 = new int[11];
      this.Data2 = new int[11];
      this.Data3 = new int[11];
      this.Data4 = new int[11];
      this.Data5 = new int[11];
      this.Counter = info.GetInt32(nameof (Counter));
      this.MaxCounter = info.GetInt32(nameof (MaxCounter));
      this.Id = new int[this.MaxCounter + 1];
      this.Weight = new int[this.MaxCounter + 1];
      this.Data1 = new int[this.MaxCounter + 1];
      this.Data2 = new int[this.MaxCounter + 1];
      this.Data3 = new int[this.MaxCounter + 1];
      this.Data4 = new int[this.MaxCounter + 1];
      this.Data5 = new int[this.MaxCounter + 1];
      this.Id = (int[]) info.GetValue(nameof (Id), this.Id.GetType());
      this.Weight = (int[]) info.GetValue(nameof (Weight), this.Weight.GetType());
      this.Data1 = (int[]) info.GetValue(nameof (Data1), this.Data1.GetType());
      this.Data2 = (int[]) info.GetValue(nameof (Data2), this.Data2.GetType());
      this.Data3 = (int[]) info.GetValue(nameof (Data3), this.Data3.GetType());
      this.Data4 = (int[]) info.GetValue(nameof (Data4), this.Data4.GetType());
      this.Data5 = (int[]) info.GetValue(nameof (Data5), this.Data5.GetType());
    }

    public void Remove(int tid)
    {
      int nr = this.FindNr(tid);
      if (nr == -1)
        return;
      if (nr < this.Counter)
      {
        int num1 = nr;
        int num2 = this.Counter - 1;
        for (int index = num1; index <= num2; ++index)
        {
          this.Id[index] = this.Id[index + 1];
          this.Weight[index] = this.Weight[index + 1];
          this.Data1[index] = this.Data1[index + 1];
          this.Data2[index] = this.Data2[index + 1];
          this.Data3[index] = this.Data3[index + 1];
          this.Data4[index] = this.Data4[index + 1];
          this.Data5[index] = this.Data5[index + 1];
        }
      }
      --this.Counter;
    }

    public void ReverseWeights()
    {
      int num1 = 999999;
      int counter1 = this.Counter;
      int num2;
      for (int index = 0; index <= counter1; ++index)
      {
        if (this.Weight[index] > num2)
          num2 = this.Weight[index];
        if (num1 > this.Weight[index])
          num1 = this.Weight[index];
      }
      int counter2 = this.Counter;
      for (int index = 0; index <= counter2; ++index)
      {
        this.Weight[index] = num2 - this.Weight[index];
        if (num1 > this.Weight[index])
          this.Weight[index] = num1;
      }
    }

    public void removeWeight0orLower()
    {
      for (int counter = this.Counter; counter >= 0; counter += -1)
      {
        if (this.Weight[counter] <= 0)
          this.RemoveNr(counter);
      }
    }

    public int GetRandomIdbasedOnWeight()
    {
      int counter1 = this.Counter;
      int num1;
      for (int index = 0; index <= counter1; ++index)
        num1 += this.Weight[index];
      if (num1 < 1)
        return -1;
      int num2 = (int) Math.Round((double) (1f + Conversion.Int(VBMath.Rnd() * (float) num1)));
      int num3 = 0;
      int counter2 = this.Counter;
      for (int index = 0; index <= counter2; ++index)
      {
        num3 += this.Weight[index];
        if (num2 <= num3)
          return this.Id[index];
      }
      return -1;
    }

    public int GetRandomIdbasedOnWeightWithSeed(object tseed)
    {
      Random random = new Random(Conversions.ToInteger(tseed));
      int counter1 = this.Counter;
      int num1;
      for (int index = 0; index <= counter1; ++index)
        num1 += this.Weight[index];
      int num2;
      if (num1 < 1)
      {
        int num3 = this.Counter + 1;
        int num4 = (int) Math.Round(1.0 + Conversion.Int((double) random.Next(0, 1000) / 1000.0 * (double) num3));
        int num5 = 0;
        num2 = -1;
        int counter2 = this.Counter;
        for (int index = 0; index <= counter2; ++index)
        {
          ++num5;
          if (num4 <= num5)
            return this.Id[index];
        }
        return -1;
      }
      int num6 = (int) Math.Round(1.0 + Conversion.Int((double) random.Next(0, 1000) / 1000.0 * (double) num1));
      int num7 = 0;
      num2 = -1;
      int counter3 = this.Counter;
      for (int index = 0; index <= counter3; ++index)
      {
        num7 += this.Weight[index];
        if (num6 <= num7)
          return this.Id[index];
      }
      return -1;
    }

    public int GetRandomSlotbasedOnWeightWithSeed(object tseed)
    {
      Random random = new Random(Conversions.ToInteger(tseed));
      int counter1 = this.Counter;
      int num1;
      for (int index = 0; index <= counter1; ++index)
        num1 += this.Weight[index];
      int num2;
      if (this.Counter > -1 & num1 == 0)
      {
        int num3 = (int) Math.Round(1.0 + Conversion.Int((double) random.Next(0, 1000) / 1000.0 * 1.0));
        int num4 = 0;
        num2 = -1;
        int counter2 = this.Counter;
        for (int onWeightWithSeed = 0; onWeightWithSeed <= counter2; ++onWeightWithSeed)
        {
          ++num4;
          if (num3 <= 1)
            return onWeightWithSeed;
        }
        return this.Counter;
      }
      if (num1 < 1)
        return -1;
      int num5 = (int) Math.Round(1.0 + Conversion.Int((double) random.Next(0, 1000) / 1000.0 * (double) num1));
      int num6 = 0;
      num2 = -1;
      int counter3 = this.Counter;
      for (int onWeightWithSeed = 0; onWeightWithSeed <= counter3; ++onWeightWithSeed)
      {
        num6 += this.Weight[onWeightWithSeed];
        if (num5 <= num6)
          return onWeightWithSeed;
      }
      return this.Counter > -1 ? this.Counter : -1;
    }

    public void RemoveNr(int nr)
    {
      if (nr < 0 || nr > this.Counter)
        return;
      if (nr < this.Counter)
      {
        int num1 = nr;
        int num2 = this.Counter - 1;
        for (int index = num1; index <= num2; ++index)
        {
          this.Id[index] = this.Id[index + 1];
          this.Weight[index] = this.Weight[index + 1];
          this.Data1[index] = this.Data1[index + 1];
          this.Data2[index] = this.Data2[index + 1];
          this.Data3[index] = this.Data3[index + 1];
          this.Data4[index] = this.Data4[index + 1];
          this.Data5[index] = this.Data5[index + 1];
        }
      }
      --this.Counter;
    }

    public void MultiplyWeight(int multi)
    {
      int counter = this.Counter;
      for (int index = 0; index <= counter; ++index)
        this.Weight[index] = this.Weight[index] * multi;
    }

    public void AddWeight(ref SimpleList SL)
    {
      if (Information.IsNothing((object) SL) || SL.Counter == -1)
        return;
      int counter = SL.Counter;
      for (int index = 0; index <= counter; ++index)
        this.AddWeight(SL.Id[index], SL.Weight[index]);
    }

    public void AddWeightBlind(ref SimpleList SL)
    {
      if (Information.IsNothing((object) SL) || SL.Counter == -1)
        return;
      int counter = SL.Counter;
      for (int index = 0; index <= counter; ++index)
        this.AddBlind(SL.Id[index], SL.Weight[index]);
    }

    public void RemoveWeight(ref SimpleList SL)
    {
      int counter = SL.Counter;
      for (int index = 0; index <= counter; ++index)
        this.RemoveWeight(SL.Id[index], SL.Weight[index]);
    }

    public bool CanRemoveWeight(ref SimpleList SL)
    {
      int counter = SL.Counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (this.FindWeight(SL.Id[index]) < SL.Weight[index])
          return false;
      }
      return true;
    }

    public void MultiplyWeight(int tid, float multi)
    {
      int nr = this.FindNr(tid);
      if (nr == -1)
        return;
      this.Weight[nr] = (int) Math.Round((double) ((float) this.Weight[nr] * multi));
    }

    public void AddWeight(
      int tid,
      int tweight,
      int tdata1 = 0,
      int tdata2 = 0,
      int tdata3 = 0,
      int tdata4 = 0,
      int tdata5 = 0,
      bool CheckExistence = true,
      bool CheckData1Existence = false,
      bool CheckData2Existence = false)
    {
      int nr;
      if (CheckExistence)
      {
        nr = this.FindNr(tid);
        if (nr == -1)
        {
          CheckExistence = false;
          CheckData1Existence = false;
          CheckData2Existence = false;
        }
      }
      if (CheckData1Existence)
      {
        if (CheckExistence)
        {
          nr = this.FindNr(tid, tdata1);
          if (nr == -1)
          {
            CheckExistence = false;
            CheckData1Existence = false;
            CheckData2Existence = false;
          }
        }
        else
        {
          nr = this.FindNr(-1, tdata1);
          if (nr == -1)
          {
            CheckExistence = false;
            CheckData1Existence = false;
            CheckData2Existence = false;
          }
        }
      }
      if (CheckData2Existence)
      {
        if (CheckExistence & CheckData1Existence)
        {
          nr = this.FindNr(tid, tdata1, tdata2);
          if (nr == -1)
          {
            CheckExistence = false;
            CheckData1Existence = false;
            CheckData2Existence = false;
          }
        }
        else
        {
          nr = this.FindNr(-1, tdata2: tdata2);
          if (nr == -1)
          {
            CheckExistence = false;
            CheckData1Existence = false;
            CheckData2Existence = false;
          }
        }
      }
      if (CheckExistence | CheckData1Existence | CheckData2Existence)
      {
        this.Id[nr] = tid;
        int[] weight = this.Weight;
        int[] numArray = weight;
        int index1 = nr;
        int index2 = index1;
        int num = weight[index1] + tweight;
        numArray[index2] = num;
        if (tdata1 > 0)
          this.Data1[nr] = tdata1;
        if (tdata2 > 0)
          this.Data2[nr] = tdata2;
        if (tdata3 > 0)
          this.Data3[nr] = tdata3;
        if (tdata4 > 0)
          this.Data4[nr] = tdata4;
        if (tdata5 <= 0)
          return;
        this.Data5[nr] = tdata5;
      }
      else
      {
        ++this.Counter;
        if (this.Counter > this.MaxCounter)
        {
          this.MaxCounter += 100;
          this.Id = (int[]) Utils.CopyArray((Array) this.Id, (Array) new int[this.MaxCounter + 1]);
          this.Weight = (int[]) Utils.CopyArray((Array) this.Weight, (Array) new int[this.MaxCounter + 1]);
          this.Data1 = (int[]) Utils.CopyArray((Array) this.Data1, (Array) new int[this.MaxCounter + 1]);
          this.Data2 = (int[]) Utils.CopyArray((Array) this.Data2, (Array) new int[this.MaxCounter + 1]);
          this.Data3 = (int[]) Utils.CopyArray((Array) this.Data3, (Array) new int[this.MaxCounter + 1]);
          this.Data4 = (int[]) Utils.CopyArray((Array) this.Data4, (Array) new int[this.MaxCounter + 1]);
          this.Data5 = (int[]) Utils.CopyArray((Array) this.Data5, (Array) new int[this.MaxCounter + 1]);
        }
        this.Id[this.Counter] = tid;
        this.Weight[this.Counter] = tweight;
        this.Data1[this.Counter] = tdata1;
        this.Data2[this.Counter] = tdata2;
        this.Data3[this.Counter] = tdata3;
        this.Data4[this.Counter] = tdata4;
        this.Data5[this.Counter] = tdata5;
      }
    }

    public void AddData(int tid, int tdataNr, int tvalue)
    {
      int nr = this.FindNr(tid);
      if (nr > -1)
      {
        this.Id[nr] = tid;
        if (tdataNr == 1)
        {
          int[] data1 = this.Data1;
          int[] numArray = data1;
          int index1 = nr;
          int index2 = index1;
          int num = data1[index1] + tvalue;
          numArray[index2] = num;
        }
        if (tdataNr == 2)
        {
          int[] data2 = this.Data2;
          int[] numArray = data2;
          int index3 = nr;
          int index4 = index3;
          int num = data2[index3] + tvalue;
          numArray[index4] = num;
        }
        if (tdataNr == 3)
        {
          int[] data3 = this.Data3;
          int[] numArray = data3;
          int index5 = nr;
          int index6 = index5;
          int num = data3[index5] + tvalue;
          numArray[index6] = num;
        }
        if (tdataNr == 4)
        {
          int[] data4 = this.Data4;
          int[] numArray = data4;
          int index7 = nr;
          int index8 = index7;
          int num = data4[index7] + tvalue;
          numArray[index8] = num;
        }
        if (tdataNr != 5)
          return;
        int[] data5 = this.Data5;
        int[] numArray1 = data5;
        int index9 = nr;
        int index10 = index9;
        int num1 = data5[index9] + tvalue;
        numArray1[index10] = num1;
      }
      else
      {
        ++this.Counter;
        if (this.Counter > this.MaxCounter)
        {
          this.MaxCounter += 100;
          this.Id = (int[]) Utils.CopyArray((Array) this.Id, (Array) new int[this.MaxCounter + 1]);
          this.Weight = (int[]) Utils.CopyArray((Array) this.Weight, (Array) new int[this.MaxCounter + 1]);
          this.Data1 = (int[]) Utils.CopyArray((Array) this.Data1, (Array) new int[this.MaxCounter + 1]);
          this.Data2 = (int[]) Utils.CopyArray((Array) this.Data2, (Array) new int[this.MaxCounter + 1]);
          this.Data3 = (int[]) Utils.CopyArray((Array) this.Data3, (Array) new int[this.MaxCounter + 1]);
          this.Data4 = (int[]) Utils.CopyArray((Array) this.Data4, (Array) new int[this.MaxCounter + 1]);
          this.Data5 = (int[]) Utils.CopyArray((Array) this.Data5, (Array) new int[this.MaxCounter + 1]);
        }
        this.Id[this.Counter] = tid;
        if (tdataNr == 1)
        {
          int[] data1 = this.Data1;
          int[] numArray = data1;
          int counter = this.Counter;
          int index = counter;
          int num = data1[counter] + tvalue;
          numArray[index] = num;
        }
        if (tdataNr == 2)
        {
          int[] data2 = this.Data2;
          int[] numArray = data2;
          int counter = this.Counter;
          int index = counter;
          int num = data2[counter] + tvalue;
          numArray[index] = num;
        }
        if (tdataNr == 3)
        {
          int[] data3 = this.Data3;
          int[] numArray = data3;
          int counter = this.Counter;
          int index = counter;
          int num = data3[counter] + tvalue;
          numArray[index] = num;
        }
        if (tdataNr == 4)
        {
          int[] data4 = this.Data4;
          int[] numArray = data4;
          int counter = this.Counter;
          int index = counter;
          int num = data4[counter] + tvalue;
          numArray[index] = num;
        }
        if (tdataNr != 5)
          return;
        int[] data5 = this.Data5;
        int[] numArray2 = data5;
        int counter1 = this.Counter;
        int index11 = counter1;
        int num2 = data5[counter1] + tvalue;
        numArray2[index11] = num2;
      }
    }

    public void RemoveWeight(
      int tid,
      int tweight,
      int tdata1 = 0,
      int tdata2 = 0,
      int tdata3 = 0,
      int tdata4 = 0,
      int tdata5 = 0,
      bool CheckExistence = true,
      bool CheckData1Existence = false)
    {
      int nr;
      if (CheckExistence)
      {
        nr = this.FindNr(tid);
        if (nr == -1)
          CheckExistence = false;
      }
      if (CheckData1Existence)
      {
        nr = this.FindNr(-1, tdata1);
        if (nr == -1)
          CheckData1Existence = false;
      }
      if (CheckExistence | CheckData1Existence)
      {
        this.Id[nr] = tid;
        int[] weight = this.Weight;
        int[] numArray = weight;
        int index1 = nr;
        int index2 = index1;
        int num = weight[index1] - tweight;
        numArray[index2] = num;
        this.Data1[nr] = tdata1;
        this.Data2[nr] = tdata2;
        this.Data3[nr] = tdata3;
        this.Data4[nr] = tdata4;
        this.Data5[nr] = tdata5;
      }
      else
      {
        ++this.Counter;
        if (this.Counter > this.MaxCounter)
        {
          this.MaxCounter += 100;
          this.Id = (int[]) Utils.CopyArray((Array) this.Id, (Array) new int[this.MaxCounter + 1]);
          this.Weight = (int[]) Utils.CopyArray((Array) this.Weight, (Array) new int[this.MaxCounter + 1]);
          this.Data1 = (int[]) Utils.CopyArray((Array) this.Data1, (Array) new int[this.MaxCounter + 1]);
          this.Data2 = (int[]) Utils.CopyArray((Array) this.Data2, (Array) new int[this.MaxCounter + 1]);
          this.Data3 = (int[]) Utils.CopyArray((Array) this.Data3, (Array) new int[this.MaxCounter + 1]);
          this.Data4 = (int[]) Utils.CopyArray((Array) this.Data4, (Array) new int[this.MaxCounter + 1]);
          this.Data5 = (int[]) Utils.CopyArray((Array) this.Data5, (Array) new int[this.MaxCounter + 1]);
          this.Weight[this.Counter] = 0;
        }
        else
          this.Weight[this.Counter] = 0;
        this.Id[this.Counter] = tid;
        int[] weight = this.Weight;
        int[] numArray = weight;
        int counter = this.Counter;
        int index = counter;
        int num = weight[counter] - tweight;
        numArray[index] = num;
        this.Data1[this.Counter] = tdata1;
        this.Data2[this.Counter] = tdata2;
        this.Data3[this.Counter] = tdata3;
        this.Data4[this.Counter] = tdata4;
        this.Data5[this.Counter] = tdata5;
      }
    }

    public void Add(
      int tid,
      int tweight,
      int tdata1 = 0,
      int tdata2 = 0,
      int tdata3 = 0,
      int tdata4 = 0,
      int tdata5 = 0,
      bool CheckExistence = true,
      bool CheckData1Existence = false)
    {
      int nr;
      if (CheckExistence)
      {
        nr = this.FindNr(tid);
        if (nr == -1)
          CheckExistence = false;
      }
      if (CheckData1Existence)
      {
        nr = this.FindNr(-1, tdata1);
        if (nr == -1)
        {
          CheckData1Existence = false;
          CheckExistence = false;
        }
      }
      if (CheckExistence | CheckData1Existence)
      {
        this.Id[nr] = tid;
        this.Weight[nr] = tweight;
        this.Data1[nr] = tdata1;
        this.Data2[nr] = tdata2;
        this.Data3[nr] = tdata3;
        this.Data4[nr] = tdata4;
        this.Data5[nr] = tdata4;
      }
      else
      {
        ++this.Counter;
        if (this.Counter > this.MaxCounter)
        {
          this.MaxCounter += 100;
          this.Id = (int[]) Utils.CopyArray((Array) this.Id, (Array) new int[this.MaxCounter + 1]);
          this.Weight = (int[]) Utils.CopyArray((Array) this.Weight, (Array) new int[this.MaxCounter + 1]);
          this.Data1 = (int[]) Utils.CopyArray((Array) this.Data1, (Array) new int[this.MaxCounter + 1]);
          this.Data2 = (int[]) Utils.CopyArray((Array) this.Data2, (Array) new int[this.MaxCounter + 1]);
          this.Data3 = (int[]) Utils.CopyArray((Array) this.Data3, (Array) new int[this.MaxCounter + 1]);
          this.Data4 = (int[]) Utils.CopyArray((Array) this.Data4, (Array) new int[this.MaxCounter + 1]);
          this.Data5 = (int[]) Utils.CopyArray((Array) this.Data5, (Array) new int[this.MaxCounter + 1]);
        }
        this.Id[this.Counter] = tid;
        this.Weight[this.Counter] = tweight;
        this.Data1[this.Counter] = tdata1;
        this.Data2[this.Counter] = tdata2;
        this.Data3[this.Counter] = tdata3;
        this.Data4[this.Counter] = tdata4;
        this.Data5[this.Counter] = tdata5;
      }
    }

    public void AddBlind(int tid, int tweight)
    {
      ++this.Counter;
      if (this.Counter > this.MaxCounter)
      {
        this.MaxCounter += 100;
        this.Id = (int[]) Utils.CopyArray((Array) this.Id, (Array) new int[this.MaxCounter + 1]);
        this.Weight = (int[]) Utils.CopyArray((Array) this.Weight, (Array) new int[this.MaxCounter + 1]);
      }
      this.Id[this.Counter] = tid;
      this.Weight[this.Counter] = tweight;
    }

    public int FindNr(int tid, int tdata1 = -1, int tdata2 = -1, int tdata3 = -1, int tdata4 = -1, int tWeight = -1)
    {
      if (this.Counter < 0)
        return -1;
      int counter = this.Counter;
      for (int nr = 0; nr <= counter; ++nr)
      {
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        int num5 = 0;
        int num6 = 0;
        if (this.Id[nr] == tid | tid == -1)
          num2 = 1;
        if (this.Weight[nr] == tWeight | tWeight == -1)
          num6 = 1;
        if (this.Data1[nr] == tdata1 | tdata1 == -1)
          num1 = 1;
        if (this.Data2[nr] == tdata2 | tdata2 == -1)
          num3 = 1;
        if (this.Data3[nr] == tdata3 | tdata3 == -1)
          num4 = 1;
        if (this.Data4[nr] == tdata4 | tdata4 == -1)
          num5 = 1;
        if (num2 == 1 & num1 == 1 & num3 == 1 & num4 == 1 & num5 == 1 & num6 == 1)
          return nr;
      }
      return -1;
    }

    public int FindWeight(int tid, int tdata1 = -1, int tdata2 = -1, int tdata3 = -1, int tdata4 = -1, int tWeight = -1)
    {
      int nr = this.FindNr(tid, tdata1, tdata2, tdata3, tdata4);
      return nr > -1 ? this.Weight[nr] : 0;
    }

    public int totalWeight()
    {
      if (this.Counter < 0)
        return 0;
      int num = 0;
      int counter = this.Counter;
      for (int index = 0; index <= counter; ++index)
        num += this.Weight[index];
      return num;
    }

    public int FindData(int tid, int tDataSlot)
    {
      int nr = this.FindNr(tid);
      if (nr <= -1)
        return 0;
      switch (tDataSlot)
      {
        case 1:
          return this.Data1[nr];
        case 2:
          return this.Data2[nr];
        case 3:
          return this.Data3[nr];
        case 4:
          return this.Data4[nr];
        case 5:
          return this.Data5[nr];
        default:
          int data;
          return data;
      }
    }

    public void Percentify()
    {
      int num1 = 0;
      int num2 = 0;
      int counter1 = this.Counter;
      for (int index = 0; index <= counter1; ++index)
      {
        num1 += this.Weight[index];
        if (this.Weight[index] > num2)
          num2 = this.Weight[index];
      }
      int counter2 = this.Counter;
      for (int index = 0; index <= counter2; ++index)
      {
        int num3 = 0;
        if (num2 > 0)
          num3 = (int) Math.Round(Math.Ceiling((double) (100 * this.Weight[index]) / (double) num2));
        this.Weight[index] = num3;
      }
    }

    public void Sort()
    {
      if (this.Counter < 1)
        return;
      int num1 = this.Counter - 1;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        int num2 = 0;
        int num3 = this.Counter - 1;
        for (int index2 = 0; index2 <= num3; ++index2)
        {
          if (this.Weight[index2] > this.Weight[index2 + 1])
          {
            num2 = 1;
            int num4 = this.Weight[index2 + 1];
            int num5 = this.Id[index2 + 1];
            int num6 = this.Data1[index2 + 1];
            int num7 = this.Data2[index2 + 1];
            int num8 = this.Data3[index2 + 1];
            int num9 = this.Data4[index2 + 1];
            int num10 = this.Data5[index2 + 1];
            this.Weight[index2 + 1] = this.Weight[index2];
            this.Id[index2 + 1] = this.Id[index2];
            this.Data1[index2 + 1] = this.Data1[index2];
            this.Data2[index2 + 1] = this.Data2[index2];
            this.Data3[index2 + 1] = this.Data3[index2];
            this.Data4[index2 + 1] = this.Data4[index2];
            this.Data5[index2 + 1] = this.Data5[index2];
            this.Weight[index2] = num4;
            this.Id[index2] = num5;
            this.Data1[index2] = num6;
            this.Data2[index2] = num7;
            this.Data3[index2] = num8;
            this.Data4[index2] = num9;
            this.Data5[index2] = num10;
          }
        }
        if (num2 == 0)
          break;
      }
    }

    public void ReverseSort()
    {
      if (this.Counter < 1)
        return;
      int num1 = this.Counter - 1;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        int num2 = 0;
        int num3 = this.Counter - 1;
        for (int index2 = 0; index2 <= num3; ++index2)
        {
          if (this.Weight[index2] < this.Weight[index2 + 1])
          {
            num2 = 1;
            int num4 = this.Weight[index2 + 1];
            int num5 = this.Id[index2 + 1];
            int num6 = this.Data1[index2 + 1];
            int num7 = this.Data2[index2 + 1];
            int num8 = this.Data3[index2 + 1];
            int num9 = this.Data4[index2 + 1];
            int num10 = this.Data5[index2 + 1];
            this.Weight[index2 + 1] = this.Weight[index2];
            this.Id[index2 + 1] = this.Id[index2];
            this.Data1[index2 + 1] = this.Data1[index2];
            this.Data2[index2 + 1] = this.Data2[index2];
            this.Data3[index2 + 1] = this.Data3[index2];
            this.Data4[index2 + 1] = this.Data4[index2];
            this.Data5[index2 + 1] = this.Data5[index2];
            this.Weight[index2] = num4;
            this.Id[index2] = num5;
            this.Data1[index2] = num6;
            this.Data2[index2] = num7;
            this.Data3[index2] = num8;
            this.Data4[index2] = num9;
            this.Data5[index2] = num10;
          }
        }
        if (num2 == 0)
          break;
      }
    }

    public void SortHighSpeed() => this.ReverseSortHighSpeed(true);

    public void ReverseSortHighSpeed(bool normalSort = false)
    {
      int num1 = 9999999;
      int num2 = -9999999;
      int counter1 = this.Counter;
      for (int index = 0; index <= counter1; ++index)
      {
        if (this.Weight[index] > num2)
          num2 = this.Weight[index];
        if (this.Weight[index] < num1)
          num1 = this.Weight[index];
      }
      int num3 = num2 - num1;
      if (num3 < 1)
        return;
      if (num3 > 25000)
      {
        if (normalSort)
          this.Sort();
        else
          this.ReverseSort();
      }
      else
      {
        int[][] numArray1 = new int[num3 + 1 + 1][];
        int counter2 = this.Counter;
        for (int index1 = 0; index1 <= counter2; ++index1)
        {
          if (Information.IsNothing((object) numArray1[this.Weight[index1] - num1]))
          {
            numArray1[this.Weight[index1] - num1] = new int[1];
          }
          else
          {
            int[][] numArray2 = numArray1;
            int[][] numArray3 = numArray2;
            int index2 = this.Weight[index1] - num1;
            int index3 = index2;
            int[] numArray4 = (int[]) Utils.CopyArray((Array) numArray3[index3], (Array) new int[numArray1[this.Weight[index1] - num1].GetUpperBound(0) + 1 + 1]);
            numArray2[index2] = numArray4;
          }
          numArray1[this.Weight[index1] - num1][numArray1[this.Weight[index1] - num1].GetUpperBound(0)] = index1;
        }
        int[] numArray5 = new int[this.Counter + 1 + 1];
        int[] numArray6 = new int[this.Counter + 1 + 1];
        int[] numArray7 = new int[this.Counter + 1 + 1];
        int[] numArray8 = new int[this.Counter + 1 + 1];
        int[] numArray9 = new int[this.Counter + 1 + 1];
        int[] numArray10 = new int[this.Counter + 1 + 1];
        int[] numArray11 = new int[this.Counter + 1 + 1];
        int index4 = -1;
        if (normalSort)
        {
          int num4 = num3;
          for (int index5 = 0; index5 <= num4; ++index5)
          {
            if (!Information.IsNothing((object) numArray1[index5]))
            {
              int upperBound = numArray1[index5].GetUpperBound(0);
              for (int index6 = 0; index6 <= upperBound; ++index6)
              {
                ++index4;
                numArray5[index4] = this.Id[numArray1[index5][index6]];
                numArray6[index4] = this.Weight[numArray1[index5][index6]];
                numArray7[index4] = this.Data1[numArray1[index5][index6]];
                numArray8[index4] = this.Data2[numArray1[index5][index6]];
                numArray9[index4] = this.Data3[numArray1[index5][index6]];
                numArray10[index4] = this.Data4[numArray1[index5][index6]];
                numArray11[index4] = this.Data5[numArray1[index5][index6]];
              }
            }
          }
        }
        else
        {
          for (int index7 = num3; index7 >= 0; index7 += -1)
          {
            if (!Information.IsNothing((object) numArray1[index7]))
            {
              int upperBound = numArray1[index7].GetUpperBound(0);
              for (int index8 = 0; index8 <= upperBound; ++index8)
              {
                ++index4;
                numArray5[index4] = this.Id[numArray1[index7][index8]];
                numArray6[index4] = this.Weight[numArray1[index7][index8]];
                numArray7[index4] = this.Data1[numArray1[index7][index8]];
                numArray8[index4] = this.Data2[numArray1[index7][index8]];
                numArray9[index4] = this.Data3[numArray1[index7][index8]];
                numArray10[index4] = this.Data4[numArray1[index7][index8]];
                numArray11[index4] = this.Data5[numArray1[index7][index8]];
              }
            }
          }
        }
        int num5 = index4;
        for (int index9 = 0; index9 <= num5; ++index9)
        {
          this.Id[index9] = numArray5[index9];
          this.Weight[index9] = numArray6[index9];
          this.Data1[index9] = numArray7[index9];
          this.Data2[index9] = numArray8[index9];
          this.Data3[index9] = numArray9[index9];
          this.Data4[index9] = numArray10[index9];
          this.Data5[index9] = numArray11[index9];
        }
        this.Counter = index4;
      }
    }

    public void SortOnData5()
    {
      if (this.Counter < 1)
        return;
      int num1 = this.Counter - 1;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        int num2 = this.Counter - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          if (this.Data5[index2] > this.Data5[index2 + 1])
          {
            int num3 = this.Weight[index2 + 1];
            int num4 = this.Id[index2 + 1];
            int num5 = this.Data1[index2 + 1];
            int num6 = this.Data2[index2 + 1];
            int num7 = this.Data3[index2 + 1];
            int num8 = this.Data4[index2 + 1];
            int num9 = this.Data5[index2 + 1];
            this.Weight[index2 + 1] = this.Weight[index2];
            this.Id[index2 + 1] = this.Id[index2];
            this.Data1[index2 + 1] = this.Data1[index2];
            this.Data2[index2 + 1] = this.Data2[index2];
            this.Data3[index2 + 1] = this.Data3[index2];
            this.Data4[index2 + 1] = this.Data4[index2];
            this.Data5[index2 + 1] = this.Data5[index2];
            this.Weight[index2] = num3;
            this.Id[index2] = num4;
            this.Data1[index2] = num5;
            this.Data2[index2] = num6;
            this.Data3[index2] = num7;
            this.Data4[index2] = num8;
            this.Data5[index2] = num9;
          }
        }
      }
    }
  }
}
