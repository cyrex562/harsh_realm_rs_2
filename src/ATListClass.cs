// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ATListClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class ATListClass
  {
    public int ListCount;
    public string[] ListName;
    public int[] ListData;
    public string[] ListValue;
    public string[] ListValue2;
    public string[] ListValue3;
    public string[] ListValue4;
    public int[] ListColor;
    public Bitmap[] ListBmp;
    public int[] ListR;
    public int[] ListG;
    public int[] ListB;

    public ATListClass()
    {
      this.ListName = new string[1];
      this.ListData = new int[1];
      this.ListValue = new string[1];
      this.ListValue2 = new string[1];
      this.ListValue3 = new string[1];
      this.ListValue4 = new string[1];
      this.ListColor = new int[1];
      this.ListBmp = new Bitmap[1];
      this.ListR = new int[1];
      this.ListG = new int[1];
      this.ListB = new int[1];
      this.ListCount = -1;
    }

    public void add(
      string tname,
      int tdata,
      string tvalue = "",
      string tvalue2 = "",
      string tvalue3 = "",
      string tvalue4 = "",
      int tcol = -1,
      Bitmap tbmp = null,
      int tr = -1,
      int tg = -1,
      int tb = -1)
    {
      ++this.ListCount;
      this.ListName = (string[]) Utils.CopyArray((Array) this.ListName, (Array) new string[this.ListCount + 1]);
      this.ListData = (int[]) Utils.CopyArray((Array) this.ListData, (Array) new int[this.ListCount + 1]);
      this.ListValue = (string[]) Utils.CopyArray((Array) this.ListValue, (Array) new string[this.ListCount + 1]);
      this.ListValue2 = (string[]) Utils.CopyArray((Array) this.ListValue2, (Array) new string[this.ListCount + 1]);
      this.ListValue3 = (string[]) Utils.CopyArray((Array) this.ListValue3, (Array) new string[this.ListCount + 1]);
      this.ListValue4 = (string[]) Utils.CopyArray((Array) this.ListValue4, (Array) new string[this.ListCount + 1]);
      this.ListColor = (int[]) Utils.CopyArray((Array) this.ListColor, (Array) new int[this.ListCount + 1]);
      this.ListBmp = (Bitmap[]) Utils.CopyArray((Array) this.ListBmp, (Array) new Bitmap[this.ListCount + 1]);
      this.ListR = (int[]) Utils.CopyArray((Array) this.ListR, (Array) new int[this.ListCount + 1]);
      this.ListG = (int[]) Utils.CopyArray((Array) this.ListG, (Array) new int[this.ListCount + 1]);
      this.ListB = (int[]) Utils.CopyArray((Array) this.ListB, (Array) new int[this.ListCount + 1]);
      this.ListName[this.ListCount] = tname;
      this.ListData[this.ListCount] = tdata;
      this.ListValue[this.ListCount] = tvalue;
      this.ListValue2[this.ListCount] = tvalue2;
      this.ListValue3[this.ListCount] = tvalue3;
      this.ListValue4[this.ListCount] = tvalue4;
      this.ListColor[this.ListCount] = tcol;
      this.ListBmp[this.ListCount] = tbmp;
      this.ListR[this.ListCount] = tr;
      this.ListG[this.ListCount] = tg;
      this.ListB[this.ListCount] = tb;
    }

    public void Sort()
    {
      if (this.ListCount < 1)
        return;
      int num1 = this.ListCount - 1;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        int num2 = this.ListCount - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          if (Operators.CompareString(this.ListName[index2], this.ListName[index2 + 1], false) > 0)
          {
            string str1 = this.ListName[index2 + 1];
            int num3 = this.ListData[index2 + 1];
            string str2 = this.ListValue[index2 + 1];
            string str3 = this.ListValue2[index2 + 1];
            string str4 = this.ListValue3[index2 + 1];
            string str5 = this.ListValue4[index2 + 1];
            this.ListName[index2 + 1] = this.ListName[index2];
            this.ListData[index2 + 1] = this.ListData[index2];
            this.ListValue[index2 + 1] = this.ListValue[index2];
            this.ListValue2[index2 + 1] = this.ListValue2[index2];
            this.ListValue3[index2 + 1] = this.ListValue3[index2];
            this.ListValue4[index2 + 1] = this.ListValue4[index2];
            this.ListName[index2] = str1;
            this.ListData[index2] = num3;
            this.ListValue[index2] = str2;
            this.ListValue2[index2] = str3;
            this.ListValue3[index2] = str4;
            this.ListValue4[index2] = str5;
          }
        }
      }
    }

    public int SortWithRef(int TempInt)
    {
      if (this.ListCount < 1)
      {
        int num;
        return num;
      }
      int num1 = this.ListCount - 1;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        int num2 = this.ListCount - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          if (Operators.CompareString(this.ListName[index2], this.ListName[index2 + 1], false) > 0)
          {
            string str = this.ListName[index2 + 1];
            int num3 = this.ListData[index2 + 1];
            if (TempInt == index2 + 1)
              TempInt = index2;
            else if (TempInt == index2)
              TempInt = index2 + 1;
            this.ListName[index2 + 1] = this.ListName[index2];
            this.ListData[index2 + 1] = this.ListData[index2];
            this.ListName[index2] = str;
            this.ListData[index2] = num3;
          }
        }
      }
      return TempInt;
    }
  }
}
