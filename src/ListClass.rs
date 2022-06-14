// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ListClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class ListClass
  {
    pub ListCount: i32;
    pub string[] ListName;
    pub int[] ListData;
    pub string[] ListValue;
    pub string[] ListValue2;
    pub string[] ListValue3;
    pub string[] ListValue4;
    pub int[] ListColor;
    pub Bitmap[] ListBmp;
    pub int[] ListWeight;

    pub ListClass()
    {
      this.ListName = new string[1];
      this.ListData = new int[1];
      this.ListValue = new string[1];
      this.ListValue2 = new string[1];
      this.ListValue3 = new string[1];
      this.ListValue4 = new string[1];
      this.ListColor = new int[1];
      this.ListBmp = new Bitmap[1];
      this.ListWeight = new int[1];
      this.ListCount = -1;
    }

    pub void add(
      string tname,
      int tdata,
      tvalue: String = "",
      tvalue2: String = "",
      tvalue3: String = "",
      tvalue4: String = "",
      let mut tcol: i32 =  -1,
      Bitmap tbmp = null,
      let mut tWeight: i32 =  -1)
    {
      if (this.ListCount > 4999)
        return;
      this += 1.ListCount;
      this.ListName = (string[]) Utils.CopyArray((Array) this.ListName, (Array) new string[this.ListCount + 1]);
      this.ListData = (int[]) Utils.CopyArray((Array) this.ListData, (Array) new int[this.ListCount + 1]);
      this.ListValue = (string[]) Utils.CopyArray((Array) this.ListValue, (Array) new string[this.ListCount + 1]);
      this.ListValue2 = (string[]) Utils.CopyArray((Array) this.ListValue2, (Array) new string[this.ListCount + 1]);
      this.ListValue3 = (string[]) Utils.CopyArray((Array) this.ListValue3, (Array) new string[this.ListCount + 1]);
      this.ListValue4 = (string[]) Utils.CopyArray((Array) this.ListValue4, (Array) new string[this.ListCount + 1]);
      this.ListColor = (int[]) Utils.CopyArray((Array) this.ListColor, (Array) new int[this.ListCount + 1]);
      this.ListBmp = (Bitmap[]) Utils.CopyArray((Array) this.ListBmp, (Array) new Bitmap[this.ListCount + 1]);
      this.ListWeight = (int[]) Utils.CopyArray((Array) this.ListWeight, (Array) new int[this.ListCount + 1]);
      this.ListName[this.ListCount] = tname;
      this.ListData[this.ListCount] = tdata;
      this.ListValue[this.ListCount] = tvalue;
      this.ListValue2[this.ListCount] = tvalue2;
      this.ListValue3[this.ListCount] = tvalue3;
      this.ListValue4[this.ListCount] = tvalue4;
      this.ListColor[this.ListCount] = tcol;
      this.ListBmp[this.ListCount] = tbmp;
      this.ListWeight[this.ListCount] = tWeight;
    }

    pub void Sort()
    {
      if (this.ListCount < 1)
        return;
      let mut num1: i32 =  this.ListCount - 1;
      for (let mut index1: i32 =  0; index1 <= num1; index1 += 1)
      {
        let mut num2: i32 =  this.ListCount - 1;
        for (let mut index2: i32 =  0; index2 <= num2; index2 += 1)
        {
          if (Operators.CompareString(this.ListName[index2], this.ListName[index2 + 1], false) > 0)
          {
            str1: String = this.ListName[index2 + 1];
            let mut num3: i32 =  this.ListData[index2 + 1];
            str2: String = this.ListValue[index2 + 1];
            str3: String = this.ListValue2[index2 + 1];
            str4: String = this.ListValue3[index2 + 1];
            str5: String = this.ListValue4[index2 + 1];
            Bitmap bitmap = this.ListBmp[index2 + 1];
            this.ListName[index2 + 1] = this.ListName[index2];
            this.ListData[index2 + 1] = this.ListData[index2];
            this.ListBmp[index2 + 1] = this.ListBmp[index2];
            this.ListValue[index2 + 1] = this.ListValue[index2];
            this.ListValue2[index2 + 1] = this.ListValue2[index2];
            this.ListValue3[index2 + 1] = this.ListValue3[index2];
            this.ListValue4[index2 + 1] = this.ListValue4[index2];
            this.ListName[index2] = str1;
            this.ListData[index2] = num3;
            this.ListBmp[index2] = bitmap;
            this.ListValue[index2] = str2;
            this.ListValue2[index2] = str3;
            this.ListValue3[index2] = str4;
            this.ListValue4[index2] = str5;
          }
        }
      }
    }

    pub int SortWithRef(int TempInt)
    {
      object Counter;
      object LoopForResult1;
      object CounterResult1;
      if (this.ListCount < 1 || !ObjectFlowControl.ForLoopControl.ForLoopInitObj(Counter, (object) 0, (object) (this.ListCount - 1), (object) 1,  LoopForResult1,  CounterResult1))
        return TempInt;
      do
      {
        object CounterResult2;
        object LoopForResult2;
        if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(CounterResult2, (object) 0, (object) (this.ListCount - 1), (object) 1,  LoopForResult2,  CounterResult2))
        {
          do
          {
            if (Operators.CompareString(this.ListName[Conversions.ToInteger(CounterResult2)], this.ListName[Conversions.ToInteger(Operators.AddObject(CounterResult2, (object) 1))], false) > 0)
            {
              str1: String = this.ListName[Conversions.ToInteger(Operators.AddObject(CounterResult2, (object) 1))];
              object obj = (object) this.ListData[Conversions.ToInteger(Operators.AddObject(CounterResult2, (object) 1))];
              str2: String = this.ListValue[Conversions.ToInteger(Operators.AddObject(CounterResult2, (object) 1))];
              str3: String = this.ListValue2[Conversions.ToInteger(Operators.AddObject(CounterResult2, (object) 1))];
              str4: String = this.ListValue3[Conversions.ToInteger(Operators.AddObject(CounterResult2, (object) 1))];
              str5: String = this.ListValue4[Conversions.ToInteger(Operators.AddObject(CounterResult2, (object) 1))];
              if (Operators.ConditionalCompareObjectEqual((object) TempInt, Operators.AddObject(CounterResult2, (object) 1), false))
                TempInt = Conversions.ToInteger(CounterResult2);
              else if (Operators.ConditionalCompareObjectEqual((object) TempInt, CounterResult2, false))
                TempInt = Conversions.ToInteger(Operators.AddObject(CounterResult2, (object) 1));
              Bitmap bitmap = this.ListBmp[Conversions.ToInteger(Operators.AddObject(CounterResult2, (object) 1))];
              this.ListName[Conversions.ToInteger(Operators.AddObject(CounterResult2, (object) 1))] = this.ListName[Conversions.ToInteger(CounterResult2)];
              this.ListData[Conversions.ToInteger(Operators.AddObject(CounterResult2, (object) 1))] = this.ListData[Conversions.ToInteger(CounterResult2)];
              this.ListValue[Conversions.ToInteger(Operators.AddObject(CounterResult2, (object) 1))] = this.ListValue[Conversions.ToInteger(CounterResult2)];
              this.ListValue2[Conversions.ToInteger(Operators.AddObject(CounterResult2, (object) 1))] = this.ListValue2[Conversions.ToInteger(CounterResult2)];
              this.ListValue3[Conversions.ToInteger(Operators.AddObject(CounterResult2, (object) 1))] = this.ListValue3[Conversions.ToInteger(CounterResult2)];
              this.ListValue4[Conversions.ToInteger(Operators.AddObject(CounterResult2, (object) 1))] = this.ListValue4[Conversions.ToInteger(CounterResult2)];
              this.ListName[Conversions.ToInteger(CounterResult2)] = str1;
              this.ListData[Conversions.ToInteger(CounterResult2)] = Conversions.ToInteger(obj);
              this.ListBmp[Conversions.ToInteger(CounterResult2)] = bitmap;
              this.ListValue[Conversions.ToInteger(CounterResult2)] = str2;
              this.ListValue2[Conversions.ToInteger(CounterResult2)] = str3;
              this.ListValue3[Conversions.ToInteger(CounterResult2)] = str4;
              this.ListValue4[Conversions.ToInteger(CounterResult2)] = str5;
            }
          }
          while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult2, LoopForResult2,  CounterResult2));
        }
      }
      while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult1, LoopForResult1,  CounterResult1));
      return TempInt;
    }

    pub int SortWithRefOnWeightAndName(int TempInt)
    {
      if (this.ListCount < 1)
      {
        int num;
        return num;
      }
      let mut num1: i32 =  this.ListCount - 1;
      for (let mut index1: i32 =  0; index1 <= num1; index1 += 1)
      {
        let mut num2: i32 =  this.ListCount - 1;
        for (let mut index2: i32 =  0; index2 <= num2; index2 += 1)
        {
          if (this.ListWeight[index2] > this.ListWeight[index2 + 1] | this.ListWeight[index2] == this.ListWeight[index2 + 1] & Operators.CompareString(this.ListName[index2], this.ListName[index2 + 1], false) > 0)
          {
            str1: String = this.ListName[index2 + 1];
            let mut num3: i32 =  this.ListData[index2 + 1];
            str2: String = this.ListValue[index2 + 1];
            str3: String = this.ListValue2[index2 + 1];
            str4: String = this.ListValue3[index2 + 1];
            str5: String = this.ListValue4[index2 + 1];
            let mut num4: i32 =  this.ListWeight[index2 + 1];
            if (TempInt == index2 + 1)
              TempInt = index2;
            else if (TempInt == index2)
              TempInt = index2 + 1;
            Bitmap bitmap = this.ListBmp[index2 + 1];
            this.ListName[index2 + 1] = this.ListName[index2];
            this.ListData[index2 + 1] = this.ListData[index2];
            this.ListValue[index2 + 1] = this.ListValue[index2];
            this.ListValue2[index2 + 1] = this.ListValue2[index2];
            this.ListValue3[index2 + 1] = this.ListValue3[index2];
            this.ListValue4[index2 + 1] = this.ListValue4[index2];
            this.ListWeight[index2 + 1] = this.ListWeight[index2];
            this.ListName[index2] = str1;
            this.ListData[index2] = num3;
            this.ListValue[index2] = str2;
            this.ListValue2[index2] = str3;
            this.ListValue3[index2] = str4;
            this.ListValue4[index2] = str5;
            this.ListWeight[index2] = num4;
            this.ListBmp[index2] = bitmap;
          }
        }
      }
      return TempInt;
    }

    pub int SortOnWeight(int TempInt)
    {
      if (this.ListCount < 1)
      {
        int num;
        return num;
      }
      let mut num1: i32 =  this.ListCount - 1;
      for (let mut index1: i32 =  0; index1 <= num1; index1 += 1)
      {
        let mut num2: i32 =  this.ListCount - 1;
        for (let mut index2: i32 =  0; index2 <= num2; index2 += 1)
        {
          if (this.ListWeight[index2] < this.ListWeight[index2 + 1])
          {
            str1: String = this.ListName[index2 + 1];
            let mut num3: i32 =  this.ListData[index2 + 1];
            str2: String = this.ListValue[index2 + 1];
            str3: String = this.ListValue2[index2 + 1];
            str4: String = this.ListValue3[index2 + 1];
            str5: String = this.ListValue4[index2 + 1];
            let mut num4: i32 =  this.ListWeight[index2 + 1];
            if (TempInt == index2 + 1)
              TempInt = index2;
            else if (TempInt == index2)
              TempInt = index2 + 1;
            Bitmap bitmap = this.ListBmp[index2 + 1];
            this.ListName[index2 + 1] = this.ListName[index2];
            this.ListData[index2 + 1] = this.ListData[index2];
            this.ListValue[index2 + 1] = this.ListValue[index2];
            this.ListValue2[index2 + 1] = this.ListValue2[index2];
            this.ListValue3[index2 + 1] = this.ListValue3[index2];
            this.ListValue4[index2 + 1] = this.ListValue4[index2];
            this.ListWeight[index2 + 1] = this.ListWeight[index2];
            this.ListName[index2] = str1;
            this.ListData[index2] = num3;
            this.ListValue[index2] = str2;
            this.ListValue2[index2] = str3;
            this.ListValue3[index2] = str4;
            this.ListValue4[index2] = str5;
            this.ListWeight[index2] = num4;
            this.ListBmp[index2] = bitmap;
          }
        }
      }
      return TempInt;
    }
  }
}
