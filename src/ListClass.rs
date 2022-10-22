// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ListClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic.CompilerServices;
// usingSystem;
// usingSystem.Drawing;

// namespace WindowsApplication1
// {
    #[derive(Default,Debug,Clone,Copy)]
  pub struct ListClass
  {
    pub ListCount: i32;
    pub ListName: Vec<String>;
    pub ListData: Vec<i32>;
    pub ListValue: Vec<String>;
    pub ListValue2: Vec<String>;
    pub ListValue3: Vec<String>;
    pub ListValue4: Vec<String>;
    pub ListColor: Vec<i32>;
    pub Bitmap[] ListBmp;
    pub ListWeight: Vec<i32>;

    pub ListClass()
    {
      self.ListName = new string[1];
      self.ListData = new int[1];
      self.ListValue = new string[1];
      self.ListValue2 = new string[1];
      self.ListValue3 = new string[1];
      self.ListValue4 = new string[1];
      self.ListColor = new int[1];
      self.ListBmp = new Bitmap[1];
      self.ListWeight = new int[1];
      self.ListCount = -1;
    }

    pub void add(
      string tname,
      tdata: i32,
      tvalue: String = "",
      tvalue2: String = "",
      tvalue3: String = "",
      tvalue4: String = "",
      let mut tcol: i32 =  -1,
      tbmp: Bitmap = null,
      let mut tWeight: i32 =  -1)
    {
      if (self.ListCount > 4999)
        return;
      this += 1.ListCount;
      self.ListName = (string[]) Utils.CopyArray((Array) self.ListName, (Array) new string[self.ListCount + 1]);
      self.ListData = (int[]) Utils.CopyArray((Array) self.ListData, (Array) new int[self.ListCount + 1]);
      self.ListValue = (string[]) Utils.CopyArray((Array) self.ListValue, (Array) new string[self.ListCount + 1]);
      self.ListValue2 = (string[]) Utils.CopyArray((Array) self.ListValue2, (Array) new string[self.ListCount + 1]);
      self.ListValue3 = (string[]) Utils.CopyArray((Array) self.ListValue3, (Array) new string[self.ListCount + 1]);
      self.ListValue4 = (string[]) Utils.CopyArray((Array) self.ListValue4, (Array) new string[self.ListCount + 1]);
      self.ListColor = (int[]) Utils.CopyArray((Array) self.ListColor, (Array) new int[self.ListCount + 1]);
      self.ListBmp = (Bitmap[]) Utils.CopyArray((Array) self.ListBmp, (Array) new Bitmap[self.ListCount + 1]);
      self.ListWeight = (int[]) Utils.CopyArray((Array) self.ListWeight, (Array) new int[self.ListCount + 1]);
      self.ListName[self.ListCount] = tname;
      self.ListData[self.ListCount] = tdata;
      self.ListValue[self.ListCount] = tvalue;
      self.ListValue2[self.ListCount] = tvalue2;
      self.ListValue3[self.ListCount] = tvalue3;
      self.ListValue4[self.ListCount] = tvalue4;
      self.ListColor[self.ListCount] = tcol;
      self.ListBmp[self.ListCount] = tbmp;
      self.ListWeight[self.ListCount] = tWeight;
    }

    pub fn Sort()
    {
      if (self.ListCount < 1)
        return;
      let mut num1: i32 =  self.ListCount - 1;
      for (let mut index1: i32 =  0; index1 <= num1; index1 += 1)
      {
        let mut num2: i32 =  self.ListCount - 1;
        for (let mut index2: i32 =  0; index2 <= num2; index2 += 1)
        {
          if (Operators.CompareString(self.ListName[index2], self.ListName[index2 + 1], false) > 0)
          {
            str1: String = self.ListName[index2 + 1];
            let mut num3: i32 =  self.ListData[index2 + 1];
            str2: String = self.ListValue[index2 + 1];
            str3: String = self.ListValue2[index2 + 1];
            str4: String = self.ListValue3[index2 + 1];
            str5: String = self.ListValue4[index2 + 1];
            bitmap: Bitmap = self.ListBmp[index2 + 1];
            self.ListName[index2 + 1] = self.ListName[index2];
            self.ListData[index2 + 1] = self.ListData[index2];
            self.ListBmp[index2 + 1] = self.ListBmp[index2];
            self.ListValue[index2 + 1] = self.ListValue[index2];
            self.ListValue2[index2 + 1] = self.ListValue2[index2];
            self.ListValue3[index2 + 1] = self.ListValue3[index2];
            self.ListValue4[index2 + 1] = self.ListValue4[index2];
            self.ListName[index2] = str1;
            self.ListData[index2] = num3;
            self.ListBmp[index2] = bitmap;
            self.ListValue[index2] = str2;
            self.ListValue2[index2] = str3;
            self.ListValue3[index2] = str4;
            self.ListValue4[index2] = str5;
          }
        }
      }
    }

    pub SortWithRef: i32(TempInt: i32)
    {
      object Counter;
      object LoopForResult1;
      object CounterResult1;
      if (self.ListCount < 1 || !ObjectFlowControl.ForLoopControl.ForLoopInitObj(Counter,  0,  (self.ListCount - 1),  1,  LoopForResult1,  CounterResult1))
        return TempInt;
      do
      {
        object CounterResult2;
        object LoopForResult2;
        if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(CounterResult2,  0,  (self.ListCount - 1),  1,  LoopForResult2,  CounterResult2))
        {
          do
          {
            if (Operators.CompareString(self.ListName[Conversions.ToInteger(CounterResult2)], self.ListName[Conversions.ToInteger(Operators.AddObject(CounterResult2,  1))], false) > 0)
            {
              str1: String = self.ListName[Conversions.ToInteger(Operators.AddObject(CounterResult2,  1))];
              object obj =  self.ListData[Conversions.ToInteger(Operators.AddObject(CounterResult2,  1))];
              str2: String = self.ListValue[Conversions.ToInteger(Operators.AddObject(CounterResult2,  1))];
              str3: String = self.ListValue2[Conversions.ToInteger(Operators.AddObject(CounterResult2,  1))];
              str4: String = self.ListValue3[Conversions.ToInteger(Operators.AddObject(CounterResult2,  1))];
              str5: String = self.ListValue4[Conversions.ToInteger(Operators.AddObject(CounterResult2,  1))];
              if (Operators.ConditionalCompareObjectEqual( TempInt, Operators.AddObject(CounterResult2,  1), false))
                TempInt = Conversions.ToInteger(CounterResult2);
              else if (Operators.ConditionalCompareObjectEqual( TempInt, CounterResult2, false))
                TempInt = Conversions.ToInteger(Operators.AddObject(CounterResult2,  1));
              bitmap: Bitmap = self.ListBmp[Conversions.ToInteger(Operators.AddObject(CounterResult2,  1))];
              self.ListName[Conversions.ToInteger(Operators.AddObject(CounterResult2,  1))] = self.ListName[Conversions.ToInteger(CounterResult2)];
              self.ListData[Conversions.ToInteger(Operators.AddObject(CounterResult2,  1))] = self.ListData[Conversions.ToInteger(CounterResult2)];
              self.ListValue[Conversions.ToInteger(Operators.AddObject(CounterResult2,  1))] = self.ListValue[Conversions.ToInteger(CounterResult2)];
              self.ListValue2[Conversions.ToInteger(Operators.AddObject(CounterResult2,  1))] = self.ListValue2[Conversions.ToInteger(CounterResult2)];
              self.ListValue3[Conversions.ToInteger(Operators.AddObject(CounterResult2,  1))] = self.ListValue3[Conversions.ToInteger(CounterResult2)];
              self.ListValue4[Conversions.ToInteger(Operators.AddObject(CounterResult2,  1))] = self.ListValue4[Conversions.ToInteger(CounterResult2)];
              self.ListName[Conversions.ToInteger(CounterResult2)] = str1;
              self.ListData[Conversions.ToInteger(CounterResult2)] = Conversions.ToInteger(obj);
              self.ListBmp[Conversions.ToInteger(CounterResult2)] = bitmap;
              self.ListValue[Conversions.ToInteger(CounterResult2)] = str2;
              self.ListValue2[Conversions.ToInteger(CounterResult2)] = str3;
              self.ListValue3[Conversions.ToInteger(CounterResult2)] = str4;
              self.ListValue4[Conversions.ToInteger(CounterResult2)] = str5;
            }
          }
          while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult2, LoopForResult2,  CounterResult2));
        }
      }
      while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult1, LoopForResult1,  CounterResult1));
      return TempInt;
    }

    pub SortWithRefOnWeightAndName: i32(TempInt: i32)
    {
      if (self.ListCount < 1)
      {
        num: i32;
        return num;
      }
      let mut num1: i32 =  self.ListCount - 1;
      for (let mut index1: i32 =  0; index1 <= num1; index1 += 1)
      {
        let mut num2: i32 =  self.ListCount - 1;
        for (let mut index2: i32 =  0; index2 <= num2; index2 += 1)
        {
          if (self.ListWeight[index2] > self.ListWeight[index2 + 1] | self.ListWeight[index2] == self.ListWeight[index2 + 1] & Operators.CompareString(self.ListName[index2], self.ListName[index2 + 1], false) > 0)
          {
            str1: String = self.ListName[index2 + 1];
            let mut num3: i32 =  self.ListData[index2 + 1];
            str2: String = self.ListValue[index2 + 1];
            str3: String = self.ListValue2[index2 + 1];
            str4: String = self.ListValue3[index2 + 1];
            str5: String = self.ListValue4[index2 + 1];
            let mut num4: i32 =  self.ListWeight[index2 + 1];
            if (TempInt == index2 + 1)
              TempInt = index2;
            else if (TempInt == index2)
              TempInt = index2 + 1;
            bitmap: Bitmap = self.ListBmp[index2 + 1];
            self.ListName[index2 + 1] = self.ListName[index2];
            self.ListData[index2 + 1] = self.ListData[index2];
            self.ListValue[index2 + 1] = self.ListValue[index2];
            self.ListValue2[index2 + 1] = self.ListValue2[index2];
            self.ListValue3[index2 + 1] = self.ListValue3[index2];
            self.ListValue4[index2 + 1] = self.ListValue4[index2];
            self.ListWeight[index2 + 1] = self.ListWeight[index2];
            self.ListName[index2] = str1;
            self.ListData[index2] = num3;
            self.ListValue[index2] = str2;
            self.ListValue2[index2] = str3;
            self.ListValue3[index2] = str4;
            self.ListValue4[index2] = str5;
            self.ListWeight[index2] = num4;
            self.ListBmp[index2] = bitmap;
          }
        }
      }
      return TempInt;
    }

    pub SortOnWeight: i32(TempInt: i32)
    {
      if (self.ListCount < 1)
      {
        num: i32;
        return num;
      }
      let mut num1: i32 =  self.ListCount - 1;
      for (let mut index1: i32 =  0; index1 <= num1; index1 += 1)
      {
        let mut num2: i32 =  self.ListCount - 1;
        for (let mut index2: i32 =  0; index2 <= num2; index2 += 1)
        {
          if (self.ListWeight[index2] < self.ListWeight[index2 + 1])
          {
            str1: String = self.ListName[index2 + 1];
            let mut num3: i32 =  self.ListData[index2 + 1];
            str2: String = self.ListValue[index2 + 1];
            str3: String = self.ListValue2[index2 + 1];
            str4: String = self.ListValue3[index2 + 1];
            str5: String = self.ListValue4[index2 + 1];
            let mut num4: i32 =  self.ListWeight[index2 + 1];
            if (TempInt == index2 + 1)
              TempInt = index2;
            else if (TempInt == index2)
              TempInt = index2 + 1;
            bitmap: Bitmap = self.ListBmp[index2 + 1];
            self.ListName[index2 + 1] = self.ListName[index2];
            self.ListData[index2 + 1] = self.ListData[index2];
            self.ListValue[index2 + 1] = self.ListValue[index2];
            self.ListValue2[index2 + 1] = self.ListValue2[index2];
            self.ListValue3[index2 + 1] = self.ListValue3[index2];
            self.ListValue4[index2 + 1] = self.ListValue4[index2];
            self.ListWeight[index2 + 1] = self.ListWeight[index2];
            self.ListName[index2] = str1;
            self.ListData[index2] = num3;
            self.ListValue[index2] = str2;
            self.ListValue2[index2] = str3;
            self.ListValue3[index2] = str4;
            self.ListValue4[index2] = str5;
            self.ListWeight[index2] = num4;
            self.ListBmp[index2] = bitmap;
          }
        }
      }
      return TempInt;
    }
  }
// }
