// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.StringListClass
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
  public class StringListClass : ISerializable
  {
    public string Name;
    public int Length;
    public int Width;
    public string[,] Data;
    public string[] ColumnName;
    public int ID;
    public int[,] TempBmp;
    public string[] TempColumBmp;
    public string[,] TempDesc;
    public int[] LookUpCol;
    public int LookUpId;
    public int LookUpLabel;
    public bool[] logEnabled;
    public LibIdClass LibId;
    public string Description;
    public bool Editable;
    public NewEnums.LibVarValueType[] ColValueType;
    public int[] ColSort;
    public int[] ColWidth;
    public int[] SSID;

    public StringListClass Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (StringListClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Name", (object) this.Name);
      info.AddValue("ColumnName", (object) this.ColumnName);
      info.AddValue("Length", this.Length);
      info.AddValue("Width", this.Width);
      info.AddValue("Data", (object) this.Data);
      info.AddValue("ID", this.ID);
      info.AddValue("LibId", (object) this.LibId);
      info.AddValue("Description", (object) this.Description);
      info.AddValue("ColValueType", (object) this.ColValueType);
      info.AddValue("Editable", this.Editable);
      info.AddValue("LookUpCol", (object) this.LookUpCol);
      info.AddValue("LookUpId", this.LookUpId);
      info.AddValue("LookUpLabel", this.LookUpLabel);
      info.AddValue("ColSort", (object) this.ColSort);
      info.AddValue("ColWidth", (object) this.ColWidth);
      info.AddValue("logEnabled", (object) this.logEnabled);
      info.AddValue("SSID", (object) this.SSID);
    }

    public int GetRandomId(int idInCol, int weightInCol)
    {
      SimpleList simpleList = new SimpleList();
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if (Conversions.ToDouble(this.Data[index, weightInCol]) > 0.0)
          simpleList.Add(Conversions.ToInteger(this.Data[index, idInCol]), Conversions.ToInteger(this.Data[index, weightInCol]));
      }
      if (simpleList.Counter <= -1)
        return -1;
      int index1 = DrawMod.RandyNumber.Next(0, simpleList.Counter + 1);
      return simpleList.Id[index1];
    }

    public int GetHighestValue(int col, bool return0ifNoneFound = false)
    {
      int highestValue = -99999;
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, col])) > highestValue)
          highestValue = (int) Math.Round(Conversion.Val(this.Data[index, col]));
      }
      if (return0ifNoneFound && highestValue == -99999)
        highestValue = 0;
      return highestValue;
    }

    public bool FindValue(int col, int tval)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, col])) == tval)
          return true;
      }
      return false;
    }

    public bool FindValue2(int col, string tval, int col2, string tval2)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if (Operators.CompareString(Strings.LCase(this.Data[index, col]), Strings.LCase(tval), false) == 0 && Operators.CompareString(Strings.LCase(this.Data[index, col2]), Strings.LCase(tval2), false) == 0)
          return true;
      }
      return false;
    }

    public bool FindValue2(int col, int tval, int col2, int tval2)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if (Conversions.ToDouble(Strings.LCase(this.Data[index, col])) == (double) tval && Conversions.ToDouble(Strings.LCase(this.Data[index, col2])) == (double) tval2)
          return true;
      }
      return false;
    }

    public int FindRow(int col, int tval)
    {
      int length = this.Length;
      for (int row = 0; row <= length; ++row)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[row, col])) == tval)
          return row;
      }
      return -1;
    }

    public int FindRow(int col, string tval)
    {
      int length = this.Length;
      for (int row = 0; row <= length; ++row)
      {
        if (Operators.CompareString(Strings.LCase(this.Data[row, col]), Strings.LCase(tval), false) == 0)
          return row;
      }
      return -1;
    }

    public int FindRow2(int col, int tval, int col2, int tval2)
    {
      int length = this.Length;
      for (int row2 = 0; row2 <= length; ++row2)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[row2, col])) == tval && (int) Math.Round(Conversion.Val(this.Data[row2, col2])) == tval2)
          return row2;
      }
      return -1;
    }

    public int FindRow3(int col, int tval, int col2, int tval2, int col3, int tval3)
    {
      int length = this.Length;
      for (int row3 = 0; row3 <= length; ++row3)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[row3, col])) == tval && (int) Math.Round(Conversion.Val(this.Data[row3, col2])) == tval2 && (int) Math.Round(Conversion.Val(this.Data[row3, col3])) == tval3)
          return row3;
      }
      return -1;
    }

    public bool FindValue(int col, int tval, int col2, int tval2)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, col])) == tval && (int) Math.Round(Conversion.Val(this.Data[index, col2])) == tval2)
          return true;
      }
      return false;
    }

    public string GetData(int idInCol, int idValue, int returnCol)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue)
          return this.Data[index, returnCol];
      }
      return Conversions.ToString(-1);
    }

    public int GetDataCount(int idInCol, int idValue)
    {
      int length = this.Length;
      int dataCount;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue)
          ++dataCount;
      }
      return dataCount;
    }

    public int GetData2Count(int idInCol, int idValue, int idInCol2, int idValue2)
    {
      int length = this.Length;
      int data2Count;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue && (int) Math.Round(Conversion.Val(this.Data[index, idInCol2])) == idValue2)
          ++data2Count;
      }
      return data2Count;
    }

    public int GetDataCountWeight(int idInCol, int idValue, int weightCol)
    {
      int length = this.Length;
      int dataCountWeight;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue)
          dataCountWeight += (int) Math.Round(Conversion.Val(this.Data[index, weightCol]));
      }
      return dataCountWeight;
    }

    public int GetData2CountWeight(
      int idInCol,
      int idValue,
      int idInCol2,
      int idValue2,
      int weightCol)
    {
      int length = this.Length;
      int data2CountWeight;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue && (int) Math.Round(Conversion.Val(this.Data[index, idInCol2])) == idValue2)
          data2CountWeight += (int) Math.Round(Conversion.Val(this.Data[index, weightCol]));
      }
      return data2CountWeight;
    }

    public int GetData3CountWeight(
      int idInCol,
      int idValue,
      int idInCol2,
      int idValue2,
      int idInCol3,
      int idValue3,
      int weightCol)
    {
      int length = this.Length;
      int data3CountWeight;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue && (int) Math.Round(Conversion.Val(this.Data[index, idInCol2])) == idValue2 && (int) Math.Round(Conversion.Val(this.Data[index, idInCol3])) == idValue3)
          data3CountWeight += (int) Math.Round(Conversion.Val(this.Data[index, weightCol]));
      }
      return data3CountWeight;
    }

    public int GetData4CountWeight(
      int idInCol,
      int idValue,
      int idInCol2,
      int idValue2,
      int idInCol3,
      int idValue3,
      int idInCol4,
      int idValue4,
      int weightCol)
    {
      int length = this.Length;
      int data4CountWeight;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue && (int) Math.Round(Conversion.Val(this.Data[index, idInCol2])) == idValue2 && (int) Math.Round(Conversion.Val(this.Data[index, idInCol3])) == idValue3 && (int) Math.Round(Conversion.Val(this.Data[index, idInCol4])) == idValue4)
          data4CountWeight += (int) Math.Round(Conversion.Val(this.Data[index, weightCol]));
      }
      return data4CountWeight;
    }

    public string GetData(int idInCol, string idValue, int returnCol)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if (Operators.CompareString(Strings.LCase(this.Data[index, idInCol]), Strings.LCase(idValue), false) == 0)
          return this.Data[index, returnCol];
      }
      return Conversions.ToString(0);
    }

    public string GetData2(int idInCol, int idValue, int idInCol2, int idValue2, int returnCol)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue && (int) Math.Round(Conversion.Val(this.Data[index, idInCol2])) == idValue2)
          return this.Data[index, returnCol];
      }
      return "0";
    }

    public string GetData2(
      int idInCol,
      string idValue,
      int idInCol2,
      int idValue2,
      int returnCol)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if (Operators.CompareString(this.Data[index, idInCol], idValue, false) == 0 && (int) Math.Round(Conversion.Val(this.Data[index, idInCol2])) == idValue2)
          return this.Data[index, returnCol];
      }
      return "0";
    }

    public string GetData3(
      int idInCol,
      int idValue,
      int idInCol2,
      int idValue2,
      int idInCol3,
      string idValue3,
      int returnCol)
    {
      if (this.Length == -1)
        return "0";
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue && (int) Math.Round(Conversion.Val(this.Data[index, idInCol2])) == idValue2 && Operators.CompareString(Strings.LCase(this.Data[index, idInCol3]), Strings.LCase(idValue3), false) == 0)
          return this.Data[index, returnCol];
      }
      return "0";
    }

    public string GetData3(
      int idInCol,
      int idValue,
      int idInCol2,
      string idValue2,
      int idInCol3,
      int idValue3,
      int returnCol)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue && Operators.CompareString(Strings.LCase(this.Data[index, idInCol2]), Strings.LCase(idValue2), false) == 0 && (int) Math.Round(Conversion.Val(this.Data[index, idInCol3])) == idValue3)
          return this.Data[index, returnCol];
      }
      return "0";
    }

    public string GetData3(
      int idInCol,
      string idValue,
      int idInCol2,
      string idValue2,
      int idInCol3,
      string idValue3,
      int returnCol)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if (Operators.CompareString(Strings.LCase(this.Data[index, idInCol]), Strings.LCase(idValue), false) == 0 && Operators.CompareString(Strings.LCase(this.Data[index, idInCol2]), Strings.LCase(idValue2), false) == 0 && Operators.CompareString(Strings.LCase(this.Data[index, idInCol3]), Strings.LCase(idValue3), false) == 0)
          return this.Data[index, returnCol];
      }
      return "0";
    }

    public string GetData4(
      int idInCol,
      int idValue,
      int idInCol2,
      int idValue2,
      int idInCol3,
      int idValue3,
      int idInCol4,
      int idValue4,
      int returnCol)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue && (int) Math.Round(Conversion.Val(this.Data[index, idInCol2])) == idValue2 && (int) Math.Round(Conversion.Val(this.Data[index, idInCol3])) == idValue3 && (int) Math.Round(Conversion.Val(this.Data[index, idInCol4])) == idValue4)
          return this.Data[index, returnCol];
      }
      return "0";
    }

    public string GetData5(
      int idInCol,
      int idValue,
      int idInCol2,
      int idValue2,
      int idInCol3,
      int idValue3,
      int idInCol4,
      int idValue4,
      int idInCol5,
      int idValue5,
      int returnCol)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue && (int) Math.Round(Conversion.Val(this.Data[index, idInCol2])) == idValue2 && (int) Math.Round(Conversion.Val(this.Data[index, idInCol3])) == idValue3 && (int) Math.Round(Conversion.Val(this.Data[index, idInCol4])) == idValue4 && (int) Math.Round(Conversion.Val(this.Data[index, idInCol5])) == idValue5)
          return this.Data[index, returnCol];
      }
      return "0";
    }

    public string GetData4(
      int idInCol,
      string idValue,
      int idInCol2,
      string idValue2,
      int idInCol3,
      string idValue3,
      int idInCol4,
      string idValue4,
      int returnCol)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if (Operators.CompareString(Strings.LCase(this.Data[index, idInCol]), Strings.LCase(idValue), false) == 0 && Operators.CompareString(Strings.LCase(this.Data[index, idInCol2]), Strings.LCase(idValue2), false) == 0 && Operators.CompareString(Strings.LCase(this.Data[index, idInCol3]), Strings.LCase(idValue3), false) == 0 && Operators.CompareString(Strings.LCase(this.Data[index, idInCol4]), Strings.LCase(idValue4), false) == 0)
          return this.Data[index, returnCol];
      }
      return "0";
    }

    public string GetData3(
      int idInCol,
      int idValue,
      int idInCol2,
      int idValue2,
      int idInCol3,
      int idValue3,
      int returnCol)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue && (int) Math.Round(Conversion.Val(this.Data[index, idInCol2])) == idValue2 && (int) Math.Round(Conversion.Val(this.Data[index, idInCol3])) == idValue3)
          return this.Data[index, returnCol];
      }
      return "0";
    }

    public string GetData2(
      int idInCol,
      int idValue,
      int idInCol2,
      string idValue2,
      int returnCol)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue && Operators.CompareString(Strings.LCase(this.Data[index, idInCol2]), Strings.LCase(idValue2), false) == 0)
          return this.Data[index, returnCol];
      }
      return "0";
    }

    public void AddRowWithData(
      string s0,
      string s1 = "",
      string s2 = "",
      string s3 = "",
      string s4 = "",
      string s5 = "",
      string s6 = "",
      string s7 = "",
      string s8 = "",
      string s9 = "",
      string s10 = "",
      string s11 = "",
      string s12 = "",
      string s13 = "",
      string s14 = "",
      string s15 = "",
      string s16 = "",
      string s17 = "",
      string s18 = "",
      string s19 = "",
      string s20 = "")
    {
      if (this.Length == -1)
        this.Length = this.Length;
      this.AddRowFast(this.Length);
      this.SetRowData(this.Length, s0, s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18, s19, s20);
    }

    public void AddRowWithData(string s0, string s1, string s2, string s3, string s4)
    {
      this.AddRowFast(this.Length);
      this.SetRowData(this.Length, s0, s1, s2, s3, s4);
    }

    public void AddRowWithDataFast(string s0, string s1, string s2, string s3, string s4)
    {
      this.AddRowFast(this.Length);
      this.SetRowData(this.Length, s0, s1, s2, s3, s4);
    }

    public void SetRowData(int rowNr, string s0, string s1, string s2, string s3, string s4)
    {
      this.Data[rowNr, 0] = s0;
      this.Data[rowNr, 1] = s1;
      this.Data[rowNr, 2] = s2;
      this.Data[rowNr, 3] = s3;
      if (this.Width < 4)
        return;
      this.Data[rowNr, 4] = s4;
    }

    public void SetRowData(
      int rowNr,
      string s0,
      string s1 = "",
      string s2 = "",
      string s3 = "",
      string s4 = "",
      string s5 = "",
      string s6 = "",
      string s7 = "",
      string s8 = "",
      string s9 = "",
      string s10 = "",
      string s11 = "",
      string s12 = "",
      string s13 = "",
      string s14 = "",
      string s15 = "",
      string s16 = "",
      string s17 = "",
      string s18 = "",
      string s19 = "",
      string s20 = "")
    {
      if (this.Width >= 0)
        this.Data[rowNr, 0] = s0;
      if (this.Width >= 1)
        this.Data[rowNr, 1] = s1;
      if (this.Width >= 2)
        this.Data[rowNr, 2] = s2;
      if (this.Width >= 3)
        this.Data[rowNr, 3] = s3;
      if (this.Width >= 4)
        this.Data[rowNr, 4] = s4;
      if (this.Width >= 5)
        this.Data[rowNr, 5] = s5;
      if (this.Width >= 6)
        this.Data[rowNr, 6] = s6;
      if (this.Width >= 7)
        this.Data[rowNr, 7] = s7;
      if (this.Width >= 8)
        this.Data[rowNr, 8] = s8;
      if (this.Width >= 9)
        this.Data[rowNr, 9] = s9;
      if (this.Width >= 10)
        this.Data[rowNr, 10] = s10;
      if (this.Width >= 11)
        this.Data[rowNr, 11] = s11;
      if (this.Width >= 12)
        this.Data[rowNr, 12] = s12;
      if (this.Width >= 13)
        this.Data[rowNr, 13] = s13;
      if (this.Width >= 14)
        this.Data[rowNr, 14] = s14;
      if (this.Width >= 15)
        this.Data[rowNr, 15] = s15;
      if (this.Width >= 16)
        this.Data[rowNr, 16] = s16;
      if (this.Width >= 17)
        this.Data[rowNr, 17] = s17;
      if (this.Width >= 18)
        this.Data[rowNr, 18] = s18;
      if (this.Width >= 19)
        this.Data[rowNr, 19] = s19;
      if (this.Width < 20)
        return;
      this.Data[rowNr, 20] = s20;
    }

    public void SetData(int idInCol, int idValue, int setCol, int setValue, bool allowAdd = false)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue)
        {
          this.Data[index, setCol] = setValue.ToString();
          return;
        }
      }
      if (!allowAdd)
        return;
      this.AddRow(this.Length);
      this.Data[this.Length, idInCol] = idValue.ToString();
      this.Data[this.Length, setCol] = setValue.ToString();
    }

    public void SetData(int idInCol, string idValue, int setCol, int setValue, bool allowAdd = false)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if (Operators.CompareString(Strings.LCase(this.Data[index, idInCol]), Strings.LCase(idValue), false) == 0)
        {
          this.Data[index, setCol] = setValue.ToString();
          return;
        }
      }
      if (!allowAdd)
        return;
      this.AddRow(this.Length);
      this.Data[this.Length, idInCol] = idValue;
      this.Data[this.Length, setCol] = setValue.ToString();
    }

    public void SetData(int idInCol, string idValue, int setCol, string setValue, bool allowAdd = false)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if (Operators.CompareString(Strings.LCase(this.Data[index, idInCol]), Strings.LCase(idValue), false) == 0)
        {
          this.Data[index, setCol] = setValue;
          return;
        }
      }
      if (!allowAdd)
        return;
      this.AddRow(this.Length);
      this.Data[this.Length, idInCol] = idValue;
      this.Data[this.Length, setCol] = setValue;
    }

    public void SetData2(
      int idInCol,
      int idValue,
      int idInCol2,
      int idValue2,
      int setCol,
      int setValue,
      bool allowAdd = false)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue && (int) Math.Round(Conversion.Val(this.Data[index, idInCol2])) == idValue2)
        {
          this.Data[index, setCol] = setValue.ToString();
          return;
        }
      }
      if (!allowAdd)
        return;
      this.AddRow(this.Length);
      this.Data[this.Length, idInCol] = idValue.ToString();
      this.Data[this.Length, idInCol2] = idValue2.ToString();
      this.Data[this.Length, setCol] = setValue.ToString();
    }

    public void SetData3(
      int idInCol,
      int idValue,
      int idInCol2,
      int idValue2,
      int idInCol3,
      int idValue3,
      int setCol,
      int setValue,
      bool allowAdd = false)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue && (int) Math.Round(Conversion.Val(this.Data[index, idInCol2])) == idValue2 && (int) Math.Round(Conversion.Val(this.Data[index, idInCol3])) == idValue3)
        {
          this.Data[index, setCol] = setValue.ToString();
          return;
        }
      }
      if (!allowAdd)
        return;
      this.AddRow(this.Length);
      this.Data[this.Length, idInCol] = idValue.ToString();
      this.Data[this.Length, idInCol2] = idValue2.ToString();
      this.Data[this.Length, idInCol3] = idValue3.ToString();
      this.Data[this.Length, setCol] = setValue.ToString();
    }

    public void SetData3(
      int idInCol,
      int idValue,
      int idInCol2,
      int idValue2,
      int idInCol3,
      string idValue3,
      int setCol,
      int setValue,
      bool allowAdd = false)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue && (int) Math.Round(Conversion.Val(this.Data[index, idInCol2])) == idValue2 && Operators.CompareString(Strings.LCase(this.Data[index, idInCol3]), Strings.LCase(idValue3), false) == 0)
        {
          this.Data[index, setCol] = setValue.ToString();
          return;
        }
      }
      if (!allowAdd)
        return;
      this.AddRow(this.Length);
      this.Data[this.Length, idInCol] = idValue.ToString();
      this.Data[this.Length, idInCol2] = idValue2.ToString();
      this.Data[this.Length, idInCol3] = idValue3.ToString();
      this.Data[this.Length, setCol] = setValue.ToString();
    }

    public void SetData4(
      int idInCol,
      int idValue,
      int idInCol2,
      int idValue2,
      int idInCol3,
      int idValue3,
      int idInCol4,
      int idValue4,
      int setCol,
      int setValue,
      bool allowAdd = false)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue && (int) Math.Round(Conversion.Val(this.Data[index, idInCol2])) == idValue2 && (int) Math.Round(Conversion.Val(this.Data[index, idInCol3])) == idValue3 && (int) Math.Round(Conversion.Val(this.Data[index, idInCol4])) == idValue4)
        {
          this.Data[index, setCol] = setValue.ToString();
          return;
        }
      }
      if (!allowAdd)
        return;
      this.AddRow(this.Length);
      this.Data[this.Length, idInCol] = idValue.ToString();
      this.Data[this.Length, idInCol2] = idValue2.ToString();
      this.Data[this.Length, idInCol3] = idValue3.ToString();
      this.Data[this.Length, idInCol4] = idValue4.ToString();
      this.Data[this.Length, setCol] = setValue.ToString();
    }

    public void SetData4(
      int idInCol,
      string idValue,
      int idInCol2,
      string idValue2,
      int idInCol3,
      string idValue3,
      int idInCol4,
      string idValue4,
      int setCol,
      int setValue,
      bool allowAdd = false)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if (Operators.CompareString(Strings.LCase(this.Data[index, idInCol]), Strings.LCase(idValue), false) == 0 && Operators.CompareString(Strings.LCase(this.Data[index, idInCol2]), Strings.LCase(idValue2), false) == 0 && Operators.CompareString(Strings.LCase(this.Data[index, idInCol3]), Strings.LCase(idValue3), false) == 0 && Operators.CompareString(Strings.LCase(this.Data[index, idInCol4]), Strings.LCase(idValue4), false) == 0)
        {
          this.Data[index, setCol] = setValue.ToString();
          return;
        }
      }
      if (!allowAdd)
        return;
      this.AddRow(this.Length);
      this.Data[this.Length, idInCol] = idValue;
      this.Data[this.Length, idInCol2] = idValue2;
      this.Data[this.Length, idInCol3] = idValue3;
      this.Data[this.Length, idInCol4] = idValue4;
      this.Data[this.Length, setCol] = Conversions.ToString(setValue);
    }

    public void SetData2(
      int idInCol,
      int idValue,
      int idInCol2,
      string idValue2,
      int setCol,
      int setValue,
      bool allowAdd = false)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue && Operators.CompareString(Strings.LCase(this.Data[index, idInCol2]), Strings.LCase(idValue2), false) == 0)
        {
          this.Data[index, setCol] = setValue.ToString();
          return;
        }
      }
      if (!allowAdd)
        return;
      this.AddRow(this.Length);
      this.Data[this.Length, idInCol] = idValue.ToString();
      this.Data[this.Length, idInCol2] = idValue2;
      this.Data[this.Length, setCol] = setValue.ToString();
    }

    public void SetData(int idInCol, int idValue, int setCol, string setValue, bool allowAdd = false)
    {
      int length = this.Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.Data[index, idInCol])) == idValue)
        {
          this.Data[index, setCol] = setValue;
          return;
        }
      }
      if (!allowAdd)
        return;
      this.AddRow(this.Length);
      this.Data[this.Length, idInCol] = idValue.ToString();
      this.Data[this.Length, setCol] = setValue;
    }

    protected StringListClass(SerializationInfo info, StreamingContext context)
    {
      this.Data = new string[1, 1];
      this.ColumnName = new string[1];
      this.TempBmp = new int[1, 1];
      this.TempColumBmp = new string[1];
      this.TempDesc = new string[1, 1];
      this.LookUpCol = new int[1];
      this.logEnabled = new bool[1];
      this.ColValueType = new NewEnums.LibVarValueType[1];
      this.ColSort = new int[1];
      this.ColWidth = new int[1];
      this.SSID = new int[1];
      this.Name = info.GetString(nameof (Name));
      this.Length = info.GetInt32(nameof (Length));
      this.Width = info.GetInt32(nameof (Width));
      this.Data = new string[this.Length + 1, this.Width + 1];
      this.TempBmp = new int[this.Length + 1, this.Width + 1];
      this.TempDesc = new string[this.Length + 1, this.Width + 1];
      this.ColumnName = new string[this.Width + 1];
      this.logEnabled = new bool[this.Width + 1];
      this.ColSort = new int[this.Width + 1];
      this.ColWidth = new int[this.Width + 1];
      this.TempColumBmp = new string[this.Width + 1];
      this.Data = (string[,]) info.GetValue(nameof (Data), this.Data.GetType());
      this.ColumnName = (string[]) info.GetValue(nameof (ColumnName), this.ColumnName.GetType());
      try
      {
        this.logEnabled = (bool[]) info.GetValue(nameof (logEnabled), this.logEnabled.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int width = this.Width;
        for (int index = 0; index <= width; ++index)
          this.logEnabled[index] = false;
        ProjectData.ClearProjectError();
      }
      this.ID = info.GetInt32(nameof (ID));
      int upperBound1 = this.Data.GetUpperBound(0);
      for (int index1 = 0; index1 <= upperBound1; ++index1)
      {
        int upperBound2 = this.Data.GetUpperBound(1);
        for (int index2 = 0; index2 <= upperBound2; ++index2)
        {
          if (Information.IsNothing((object) this.Data[index1, index2]))
            this.Data[index1, index2] = "";
        }
      }
      this.ColValueType = new NewEnums.LibVarValueType[this.Width + 1];
      try
      {
        this.LibId = new LibIdClass();
        this.LibId = (LibIdClass) info.GetValue(nameof (LibId), this.LibId.GetType());
        this.Description = info.GetString(nameof (Description));
        this.ColValueType = (NewEnums.LibVarValueType[]) info.GetValue(nameof (ColValueType), this.ColValueType.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.LibId = new LibIdClass();
        this.Description = "No description";
        int width = this.Width;
        for (int index = 0; index <= width; ++index)
          this.ColValueType[index] = NewEnums.LibVarValueType.Text;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.Editable = info.GetBoolean(nameof (Editable));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Editable = true;
        ProjectData.ClearProjectError();
      }
      this.LookUpCol = new int[this.Width + 1];
      try
      {
        this.LookUpId = info.GetInt32(nameof (LookUpId));
        this.LookUpLabel = info.GetInt32(nameof (LookUpLabel));
        this.LookUpCol = (int[]) info.GetValue(nameof (LookUpCol), this.LookUpCol.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.LookUpId = -1;
        this.LookUpLabel = -1;
        int width = this.Width;
        for (int index = 0; index <= width; ++index)
          this.LookUpCol[index] = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.ColSort = (int[]) info.GetValue(nameof (ColSort), this.ColSort.GetType());
        this.ColWidth = (int[]) info.GetValue(nameof (ColWidth), this.ColWidth.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      this.SSID = new int[this.Width + 1];
      try
      {
        this.SSID = (int[]) info.GetValue(nameof (SSID), this.SSID.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int width = this.Width;
        for (int index = 0; index <= width; ++index)
          this.SSID[index] = 0;
        ProjectData.ClearProjectError();
      }
    }

    public StringListClass(int tid)
    {
      this.Data = new string[1, 1];
      this.ColumnName = new string[1];
      this.TempBmp = new int[1, 1];
      this.TempColumBmp = new string[1];
      this.TempDesc = new string[1, 1];
      this.LookUpCol = new int[1];
      this.logEnabled = new bool[1];
      this.ColValueType = new NewEnums.LibVarValueType[1];
      this.ColSort = new int[1];
      this.ColWidth = new int[1];
      this.SSID = new int[1];
      this.Length = -1;
      this.ID = tid;
      this.Name = "New Stringlist";
      this.Width = -1;
      this.Data = new string[1, 1];
      this.ColumnName = new string[1];
      this.ColSort = new int[1];
      this.ColWidth = new int[1];
      this.LookUpCol = new int[1];
      this.SSID = new int[1];
      this.ColValueType = new NewEnums.LibVarValueType[1];
      this.logEnabled = new bool[1];
      this.Data[0, 0] = "";
      this.ColumnName[0] = "";
      this.logEnabled[0] = false;
      this.LibId = new LibIdClass();
      this.Description = "No description";
      int width = this.Width;
      for (int index = 0; index <= width; ++index)
        this.ColValueType[index] = NewEnums.LibVarValueType.Text;
      this.Editable = true;
      this.LookUpCol[0] = -1;
      this.LookUpId = -1;
      this.LookUpLabel = -1;
      this.SSID[0] = 0;
    }

    public void ClearAllRows()
    {
      this.Length = -1;
      this.Data = new string[this.Width + 1, 1];
    }

    public void Clear()
    {
      while (this.Length > -1)
        this.RemoveRow(this.Length);
      while (this.Width > -1)
        this.RemoveCol(this.Width);
    }

    public LibVarClass GetValue(ref DataClass tData, int row, int col, int useLibSlot = -1)
    {
      LibVarClass libVarClass = new LibVarClass(-1);
      if (col > -1)
      {
        if (this.LookUpCol[col] > 0)
        {
          int stringListById = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(this.LookUpCol[col]);
          string str1 = this.Data[row, col];
          int num1 = (int) Math.Round(Conversion.Val(str1));
          if (stringListById > -1 && tData.StringListObj[stringListById].LookUpId > -1 & tData.StringListObj[stringListById].LookUpLabel > -1)
          {
            if (Strings.InStr(str1, "[") > 0 & Strings.InStr(str1, "]") > 0)
            {
              string str2 = "";
              while (Strings.InStr(str1, "[") > 0 & Strings.InStr(str1, "]") > Strings.InStr(str1, "["))
              {
                int num2 = Strings.InStr(str1, "[");
                int num3 = Strings.InStr(str1, "]");
                int num4 = (int) Math.Round(Conversion.Val(Strings.Mid(str1, num2 + 1, num3 - num2 - 1)));
                string str3 = "";
                int length = DrawMod.TGame.Data.StringListObj[stringListById].Length;
                for (int index = 0; index <= length; ++index)
                {
                  if ((int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById].Data[index, tData.StringListObj[stringListById].LookUpId])) == num4)
                  {
                    str3 = "[" + num4.ToString() + "] " + DrawMod.TGame.Data.StringListObj[stringListById].Data[index, tData.StringListObj[stringListById].LookUpLabel];
                    break;
                  }
                }
                str1 = Strings.Mid(str1, num3 + 1);
                if (str3.Length > 16)
                  str3 = Strings.Left(str3, 16);
                if (str2.Length > 0)
                  str2 += ",";
                str2 += str3;
              }
              if (str2.Length > 0)
              {
                libVarClass.valueType = NewEnums.LibVarValueType.Text;
                libVarClass.value = -1;
                libVarClass.valueText = str2;
                return libVarClass;
              }
            }
            else
            {
              int length = DrawMod.TGame.Data.StringListObj[stringListById].Length;
              for (int index = 0; index <= length; ++index)
              {
                if ((int) Math.Round(Conversion.Val(DrawMod.TGame.Data.StringListObj[stringListById].Data[index, tData.StringListObj[stringListById].LookUpId])) == num1)
                {
                  libVarClass.valueType = NewEnums.LibVarValueType.Text;
                  libVarClass.value = -1;
                  libVarClass.valueText = "[" + num1.ToString() + "] " + DrawMod.TGame.Data.StringListObj[stringListById].Data[index, tData.StringListObj[stringListById].LookUpLabel];
                  return libVarClass;
                }
              }
            }
          }
          libVarClass.valueType = NewEnums.LibVarValueType.Text;
          libVarClass.value = -1;
          libVarClass.valueText = this.Data[row, col];
          return libVarClass;
        }
        if (this.ColValueType[col] == NewEnums.LibVarValueType.Number)
        {
          libVarClass.valueType = NewEnums.LibVarValueType.Number;
          libVarClass.value = (int) Math.Round(Conversion.Val(this.Data[row, col]));
          libVarClass.valueText = this.Data[row, col];
        }
        else if (this.ColValueType[col] == NewEnums.LibVarValueType.DateString)
        {
          libVarClass.valueType = NewEnums.LibVarValueType.DateString;
          libVarClass.value = -1;
          libVarClass.valueText = this.Data[row, col];
        }
        else if (this.ColValueType[col] == NewEnums.LibVarValueType.Text)
        {
          libVarClass.valueType = NewEnums.LibVarValueType.Text;
          libVarClass.value = -1;
          libVarClass.valueText = this.Data[row, col];
        }
        else if (this.ColValueType[col] == NewEnums.LibVarValueType.RegimeId)
        {
          libVarClass.value = (int) Math.Round(Conversion.Val(this.Data[row, col]));
          libVarClass.valueType = NewEnums.LibVarValueType.RegimeId;
          if (libVarClass.value == 0 & Strings.InStr(this.Data[row, col], "0") < 1)
          {
            libVarClass.value = -1;
            this.Data[row, col] = "-1";
          }
          libVarClass.valueText = !(libVarClass.value > -1 & libVarClass.value <= tData.RegimeCounter) ? (libVarClass.value <= tData.RegimeCounter ? (libVarClass.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : tData.RegimeObj[libVarClass.value].Name;
        }
        else if (this.ColValueType[col] == NewEnums.LibVarValueType.HistoricalUnitId | this.ColValueType[col] == NewEnums.LibVarValueType.HistoricalUnitModelId)
        {
          libVarClass.value = (int) Math.Round(Conversion.Val(this.Data[row, col]));
          libVarClass.valueType = this.ColValueType[col];
          if (libVarClass.value == 0 & Strings.InStr(this.Data[row, col], "0") < 1)
          {
            libVarClass.value = -1;
            this.Data[row, col] = "-1";
          }
          libVarClass.valueText = !(libVarClass.value > -1 & libVarClass.value <= tData.HistoricalUnitCounter) ? (libVarClass.value <= tData.HistoricalUnitCounter ? (libVarClass.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : tData.HistoricalUnitObj[libVarClass.value].Name;
        }
        else if (this.ColValueType[col] == NewEnums.LibVarValueType.OfficerId)
        {
          libVarClass.value = (int) Math.Round(Conversion.Val(this.Data[row, col]));
          libVarClass.valueType = this.ColValueType[col];
          if (libVarClass.value == 0 & Strings.InStr(this.Data[row, col], "0") < 1)
          {
            libVarClass.value = -1;
            this.Data[row, col] = "-1";
          }
          libVarClass.valueText = !(libVarClass.value > -1 & libVarClass.value <= tData.HistoricalUnitCounter) ? (libVarClass.value <= tData.HistoricalUnitCounter ? (libVarClass.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : tData.HistoricalUnitObj[libVarClass.value].CommanderName;
        }
        else if (this.ColValueType[col] == NewEnums.LibVarValueType.LandscapeId)
        {
          libVarClass.value = (int) Math.Round(Conversion.Val(this.Data[row, col]));
          libVarClass.valueType = NewEnums.LibVarValueType.LandscapeId;
          if (libVarClass.value == 0 & Strings.InStr(this.Data[row, col], "0") < 1)
          {
            libVarClass.value = -1;
            this.Data[row, col] = "-1";
          }
          libVarClass.valueText = !(libVarClass.value > -1 & libVarClass.value <= tData.LandscapeTypeCounter) ? (libVarClass.value <= tData.LandscapeTypeCounter ? (libVarClass.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : tData.LandscapeTypeObj[libVarClass.value].Name;
        }
        else if (this.ColValueType[col] == NewEnums.LibVarValueType.ActionCardId)
        {
          libVarClass.value = (int) Math.Round(Conversion.Val(this.Data[row, col]));
          libVarClass.valueType = NewEnums.LibVarValueType.ActionCardId;
          if (libVarClass.value == 0 & Strings.InStr(this.Data[row, col], "0") < 1)
          {
            libVarClass.value = -1;
            this.Data[row, col] = "-1";
          }
          libVarClass.valueText = !(libVarClass.value > -1 & libVarClass.value <= tData.ActionCardCounter) ? (libVarClass.value <= tData.ActionCardCounter ? (libVarClass.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : tData.ActionCardObj[libVarClass.value].Title;
        }
        else if (this.ColValueType[col] == NewEnums.LibVarValueType.EventPicId)
        {
          libVarClass.value = (int) Math.Round(Conversion.Val(this.Data[row, col]));
          libVarClass.valueType = NewEnums.LibVarValueType.EventPicId;
          if (useLibSlot > -1 & DrawMod.TGame.Data.Product == 7)
          {
            if (libVarClass.value == 0 & Strings.InStr(this.Data[row, col], "0") < 1)
            {
              libVarClass.value = -1;
              this.Data[row, col] = "-1";
            }
            if (libVarClass.value > -1)
            {
              int eventPic = tData.FindEventPic(libVarClass.value, tData.LibraryObj[useLibSlot].name);
              libVarClass.valueText = eventPic <= -1 ? "Invalid value" : tData.EventPicName[eventPic];
            }
            else
              libVarClass.valueText = libVarClass.value != -1 ? "Invalid value" : "None/All";
          }
          else
          {
            if (libVarClass.value == 0 & Strings.InStr(this.Data[row, col], "0") < 1)
            {
              libVarClass.value = -1;
              this.Data[row, col] = "-1";
            }
            libVarClass.valueText = !(libVarClass.value > -1 & libVarClass.value <= tData.EventPicCounter) ? (libVarClass.value <= tData.EventPicCounter ? (libVarClass.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : tData.EventPicName[libVarClass.value];
          }
        }
        else if (this.ColValueType[col] == NewEnums.LibVarValueType.SmallGfxId)
        {
          libVarClass.value = (int) Math.Round(Conversion.Val(this.Data[row, col]));
          libVarClass.valueType = NewEnums.LibVarValueType.SmallGfxId;
          if (libVarClass.value == 0 & Strings.InStr(this.Data[row, col], "0") < 1)
          {
            libVarClass.value = -1;
            this.Data[row, col] = "-1";
          }
          libVarClass.valueText = !(libVarClass.value > -1 & libVarClass.value <= tData.SmallPicCounter) ? (libVarClass.value <= tData.SmallPicCounter ? (libVarClass.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : tData.SmallPicName[libVarClass.value];
        }
        else if (this.ColValueType[col] == NewEnums.LibVarValueType.PeopleId)
        {
          libVarClass.value = (int) Math.Round(Conversion.Val(this.Data[row, col]));
          libVarClass.valueType = NewEnums.LibVarValueType.PeopleId;
          if (libVarClass.value == 0 & Strings.InStr(this.Data[row, col], "0") < 1)
          {
            libVarClass.value = -1;
            this.Data[row, col] = "-1";
          }
          libVarClass.valueText = !(libVarClass.value > -1 & libVarClass.value <= tData.PeopleCounter) ? (libVarClass.value <= tData.PeopleCounter ? (libVarClass.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : tData.PeopleObj[libVarClass.value].Name;
        }
        else if (this.ColValueType[col] == NewEnums.LibVarValueType.RiverId)
        {
          libVarClass.value = (int) Math.Round(Conversion.Val(this.Data[row, col]));
          libVarClass.valueType = NewEnums.LibVarValueType.RiverId;
          if (libVarClass.value == 0 & Strings.InStr(this.Data[row, col], "0") < 1)
          {
            libVarClass.value = -1;
            this.Data[row, col] = "-1";
          }
          libVarClass.valueText = !(libVarClass.value > -1 & libVarClass.value <= tData.RiverTypeCounter) ? (libVarClass.value <= tData.RiverTypeCounter ? (libVarClass.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : tData.RiverTypeObj[libVarClass.value].Name;
        }
        else if (this.ColValueType[col] == NewEnums.LibVarValueType.RoadId)
        {
          libVarClass.value = (int) Math.Round(Conversion.Val(this.Data[row, col]));
          libVarClass.valueType = NewEnums.LibVarValueType.RoadId;
          if (libVarClass.value == 0 & Strings.InStr(this.Data[row, col], "0") < 1)
          {
            libVarClass.value = -1;
            this.Data[row, col] = "-1";
          }
          libVarClass.valueText = !(libVarClass.value > -1 & libVarClass.value <= tData.RoadTypeCounter) ? (libVarClass.value <= tData.RoadTypeCounter ? (libVarClass.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : tData.RoadTypeObj[libVarClass.value].Name;
        }
        else if (this.ColValueType[col] == NewEnums.LibVarValueType.SFTypeId)
        {
          libVarClass.value = (int) Math.Round(Conversion.Val(this.Data[row, col]));
          libVarClass.valueType = NewEnums.LibVarValueType.SFTypeId;
          if (libVarClass.value == 0 & Strings.InStr(this.Data[row, col], "0") < 1)
          {
            libVarClass.value = -1;
            this.Data[row, col] = "-1";
          }
          libVarClass.valueText = !(libVarClass.value > -1 & libVarClass.value <= tData.SFTypeCounter) ? (libVarClass.value <= tData.SFTypeCounter ? (libVarClass.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : tData.SFTypeObj[libVarClass.value].Name;
        }
        else if (this.ColValueType[col] == NewEnums.LibVarValueType.LocationTypeId)
        {
          libVarClass.value = (int) Math.Round(Conversion.Val(this.Data[row, col]));
          libVarClass.valueType = NewEnums.LibVarValueType.LocationTypeId;
          if (libVarClass.value == 0 & Strings.InStr(this.Data[row, col], "0") < 1)
          {
            libVarClass.value = -1;
            this.Data[row, col] = "-1";
          }
          libVarClass.valueText = !(libVarClass.value > -1 & libVarClass.value <= tData.LocTypeCounter) ? (libVarClass.value <= tData.LocTypeCounter ? (libVarClass.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : tData.LocTypeObj[libVarClass.value].Name;
        }
        else if (this.ColValueType[col] == NewEnums.LibVarValueType.YesNo)
        {
          libVarClass.value = (int) Math.Round(Conversion.Val(this.Data[row, col]));
          libVarClass.valueType = NewEnums.LibVarValueType.YesNo;
          libVarClass.valueText = libVarClass.value != 1 ? "No" : "Yes";
        }
      }
      return libVarClass;
    }

    public void SetItem(int row, int col, string s)
    {
      while (row > this.Length)
        this.AddRow(this.Length);
      int num;
      if (col > this.Width)
      {
        this.Width = col;
        num = 1;
      }
      if (num == 1)
        this.Data = (string[,]) Utils.CopyArray((Array) this.Data, (Array) new string[this.Length + 1, this.Width + 1]);
      if (num == 1)
        this.TempBmp = (int[,]) Utils.CopyArray((Array) this.TempBmp, (Array) new int[this.Length + 1, this.Width + 1]);
      if (num == 1)
        this.TempDesc = (string[,]) Utils.CopyArray((Array) this.TempDesc, (Array) new string[this.Length + 1, this.Width + 1]);
      if (num == 1)
        this.ColValueType = (NewEnums.LibVarValueType[]) Utils.CopyArray((Array) this.ColValueType, (Array) new NewEnums.LibVarValueType[this.Width + 1]);
      if (num == 1)
        this.ColumnName = (string[]) Utils.CopyArray((Array) this.ColumnName, (Array) new string[this.Width + 1]);
      if (num == 1)
        this.ColSort = (int[]) Utils.CopyArray((Array) this.ColSort, (Array) new int[this.Width + 1]);
      if (num == 1)
        this.ColWidth = (int[]) Utils.CopyArray((Array) this.ColWidth, (Array) new int[this.Width + 1]);
      this.Data[row, col] = s;
    }

    public void SetColName(int col, string s)
    {
      int num;
      if (col > this.Width)
      {
        this.Width = col;
        num = 1;
      }
      if (num == 1)
      {
        this.Data = (string[,]) Utils.CopyArray((Array) this.Data, (Array) new string[this.Length + 1, this.Width + 1]);
        this.logEnabled = (bool[]) Utils.CopyArray((Array) this.logEnabled, (Array) new bool[this.Width + 1]);
        this.ColumnName = (string[]) Utils.CopyArray((Array) this.ColumnName, (Array) new string[this.Width + 1]);
        this.ColSort = (int[]) Utils.CopyArray((Array) this.ColSort, (Array) new int[this.Width + 1]);
        this.ColWidth = (int[]) Utils.CopyArray((Array) this.ColWidth, (Array) new int[this.Width + 1]);
      }
      if (num == 1)
      {
        this.TempBmp = (int[,]) Utils.CopyArray((Array) this.TempBmp, (Array) new int[this.Length + 1, this.Width + 1]);
        this.TempColumBmp = (string[]) Utils.CopyArray((Array) this.TempColumBmp, (Array) new string[this.Width + 1]);
      }
      if (num == 1)
        this.TempDesc = (string[,]) Utils.CopyArray((Array) this.TempDesc, (Array) new string[this.Length + 1, this.Width + 1]);
      if (num == 1)
        this.ColValueType = (NewEnums.LibVarValueType[]) Utils.CopyArray((Array) this.ColValueType, (Array) new NewEnums.LibVarValueType[this.Width + 1]);
      this.ColumnName[col] = s;
      this.logEnabled[col] = false;
    }

    public void Sort(int col)
    {
      this.ColSort[col] = this.ColSort[col] > 1 ? 1 : 2;
      bool flag1 = true;
      while (flag1)
      {
        flag1 = false;
        int num1 = this.Length - 1;
        for (int index1 = 0; index1 <= num1; ++index1)
        {
          bool flag2 = false;
          string str1 = this.Data[index1, col];
          string str2 = this.Data[index1 + 1, col];
          int num2 = Strings.InStr(str1, "#");
          int num3 = Strings.InStr(num2 + 1, str1, "#");
          if (num2 > 0 & num3 > 0)
            str1 = Strings.Mid(str1, num2 + 1, num3 - num2 - 1);
          int num4 = Strings.InStr(str2, "#");
          int num5 = Strings.InStr(num4 + 1, str2, "#");
          if (num4 > 0 & num5 > 0)
            str2 = Strings.Mid(str2, num4 + 1, num5 - num4 - 1);
          if (this.ColValueType[col] == NewEnums.LibVarValueType.Number)
          {
            if (this.ColSort[col] == 1)
            {
              if ((int) Math.Round(Conversion.Val(str1)) > (int) Math.Round(Conversion.Val(str2)))
                flag2 = true;
            }
            else if (this.ColSort[col] == 2 && (int) Math.Round(Conversion.Val(str1)) < (int) Math.Round(Conversion.Val(str2)))
              flag2 = true;
          }
          if (this.ColValueType[col] == NewEnums.LibVarValueType.Text)
          {
            if (this.ColSort[col] == 1)
            {
              if (string.Compare(str1, str2) == -1)
                flag2 = true;
            }
            else if (this.ColSort[col] == 2 && string.Compare(str2, str1) == -1)
              flag2 = true;
          }
          if (flag2)
          {
            flag1 = true;
            int width = this.Width;
            for (int index2 = 0; index2 <= width; ++index2)
            {
              string str3 = this.Data[index1, index2];
              int num6 = this.TempBmp[index1, index2];
              string str4 = this.TempDesc[index1, index2];
              this.Data[index1, index2] = this.Data[index1 + 1, index2];
              this.TempBmp[index1, index2] = this.TempBmp[index1 + 1, index2];
              this.TempDesc[index1, index2] = this.TempDesc[index1 + 1, index2];
              this.Data[index1 + 1, index2] = str3;
              this.TempBmp[index1 + 1, index2] = num6;
              this.TempDesc[index1 + 1, index2] = str4;
            }
          }
        }
      }
    }

    public void RemoveRow(int row)
    {
      object[,] objArray = new object[this.Length + 1, this.Width + 1];
      int length1 = this.Length;
      for (int index1 = 0; index1 <= length1; ++index1)
      {
        int width = this.Width;
        for (int index2 = 0; index2 <= width; ++index2)
          objArray[index1, index2] = (object) this.Data[index1, index2];
      }
      if (row < this.Length)
      {
        int num1 = row;
        int num2 = this.Length - 1;
        for (int index3 = num1; index3 <= num2; ++index3)
        {
          int width = this.Width;
          for (int index4 = 0; index4 <= width; ++index4)
            objArray[index3, index4] = (object) this.Data[index3 + 1, index4];
        }
      }
      --this.Length;
      this.Data = new string[this.Length + 1, this.Width + 1];
      int length2 = this.Length;
      for (int index5 = 0; index5 <= length2; ++index5)
      {
        int width = this.Width;
        for (int index6 = 0; index6 <= width; ++index6)
          this.Data[index5, index6] = Conversions.ToString(objArray[index5, index6]);
      }
    }

    public void RemoveMultipleRow(bool[] flaggy)
    {
      object[,] objArray = new object[this.Length + 1, this.Width + 1];
      int index1 = -1;
      int num = 0;
      int length1 = this.Length;
      for (int index2 = 0; index2 <= length1; ++index2)
      {
        if (!flaggy[index2])
        {
          ++index1;
          int width = this.Width;
          for (int index3 = 0; index3 <= width; ++index3)
            objArray[index1, index3] = (object) this.Data[index2, index3];
        }
        else
          ++num;
      }
      this.Length -= num;
      if (this.Length > -1)
      {
        this.Data = new string[this.Length + 1, this.Width + 1];
        this.TempBmp = new int[this.Length + 1, this.Width + 1];
        this.TempDesc = new string[this.Length + 1, this.Width + 1];
        int length2 = this.Length;
        for (int index4 = 0; index4 <= length2; ++index4)
        {
          int width = this.Width;
          for (int index5 = 0; index5 <= width; ++index5)
            this.Data[index4, index5] = Conversions.ToString(objArray[index4, index5]);
        }
      }
      else
      {
        this.Data = new string[1, this.Width + 1];
        this.TempBmp = new int[1, this.Width + 1];
        this.TempDesc = new string[1, this.Width + 1];
        this.Length = -1;
      }
    }

    public void RemoveCol(int col)
    {
      object[,] objArray = new object[this.Length + 1, this.Width + 1];
      int length1 = this.Length;
      for (int index1 = 0; index1 <= length1; ++index1)
      {
        int width = this.Width;
        for (int index2 = 0; index2 <= width; ++index2)
          objArray[index1, index2] = (object) this.Data[index1, index2];
      }
      if (col < this.Width)
      {
        int length2 = this.Length;
        for (int index3 = 0; index3 <= length2; ++index3)
        {
          int num1 = col;
          int num2 = this.Width - 1;
          for (int index4 = num1; index4 <= num2; ++index4)
            objArray[index3, index4] = (object) this.Data[index3, index4 + 1];
        }
        int num3 = col;
        int num4 = this.Width - 1;
        for (int index = num3; index <= num4; ++index)
        {
          this.ColumnName[index] = this.ColumnName[index + 1];
          this.logEnabled[index] = this.logEnabled[index + 1];
          this.ColSort[index] = this.ColSort[index + 1];
          this.ColWidth[index] = this.ColWidth[index + 1];
          this.ColValueType[index] = this.ColValueType[index + 1];
          this.LookUpCol[index] = this.LookUpCol[index + 1];
        }
      }
      --this.Width;
      this.ColumnName = (string[]) Utils.CopyArray((Array) this.ColumnName, (Array) new string[this.Width + 1]);
      this.logEnabled = (bool[]) Utils.CopyArray((Array) this.logEnabled, (Array) new bool[this.Width + 1]);
      this.ColSort = (int[]) Utils.CopyArray((Array) this.ColSort, (Array) new int[this.Width + 1]);
      this.ColWidth = (int[]) Utils.CopyArray((Array) this.ColWidth, (Array) new int[this.Width + 1]);
      this.LookUpCol = (int[]) Utils.CopyArray((Array) this.LookUpCol, (Array) new int[this.Width + 1]);
      this.SSID = (int[]) Utils.CopyArray((Array) this.SSID, (Array) new int[this.Width + 1]);
      this.ColValueType = (NewEnums.LibVarValueType[]) Utils.CopyArray((Array) this.ColValueType, (Array) new NewEnums.LibVarValueType[this.Width + 1]);
      this.Data = new string[this.Length + 1, this.Width + 1];
      int length3 = this.Length;
      for (int index5 = 0; index5 <= length3; ++index5)
      {
        int width = this.Width;
        for (int index6 = 0; index6 <= width; ++index6)
          this.Data[index5, index6] = Conversions.ToString(objArray[index5, index6]);
      }
    }

    public void AddRow(int row)
    {
      if (row >= this.Length)
      {
        this.AddRowFast(row);
      }
      else
      {
        object[,] objArray1 = new object[this.Length + 1 + 1, this.Width + 1];
        object[,] objArray2 = new object[this.Length + 1 + 1, this.Width + 1];
        object[,] objArray3 = new object[this.Length + 1 + 1, this.Width + 1];
        int length1 = this.Length;
        for (int index1 = 0; index1 <= length1; ++index1)
        {
          int width = this.Width;
          for (int index2 = 0; index2 <= width; ++index2)
          {
            objArray1[index1, index2] = (object) this.Data[index1, index2];
            objArray2[index1, index2] = (object) this.TempBmp[index1, index2];
            objArray3[index1, index2] = (object) this.TempDesc[index1, index2];
          }
        }
        if (row < this.Length)
        {
          ++this.Length;
          this.Data = new string[this.Length + 1, this.Width + 1];
          this.TempBmp = new int[this.Length + 1, this.Width + 1];
          this.TempDesc = new string[this.Length + 1, this.Width + 1];
          int num1 = this.Length - 1;
          for (int index3 = 0; index3 <= num1; ++index3)
          {
            int width = this.Width;
            for (int index4 = 0; index4 <= width; ++index4)
            {
              this.Data[index3, index4] = Conversions.ToString(objArray1[index3, index4]);
              this.TempBmp[index3, index4] = Conversions.ToInteger(objArray2[index3, index4]);
              this.TempDesc[index3, index4] = Conversions.ToString(objArray3[index3, index4]);
            }
          }
          int length2 = this.Length;
          int num2 = row + 2;
          for (int index5 = length2; index5 >= num2; index5 += -1)
          {
            int width = this.Width;
            for (int index6 = 0; index6 <= width; ++index6)
            {
              this.Data[index5, index6] = Conversions.ToString(objArray1[index5 - 1, index6]);
              this.TempBmp[index5, index6] = Conversions.ToInteger(objArray2[index5 - 1, index6]);
              this.TempDesc[index5, index6] = Conversions.ToString(objArray3[index5 - 1, index6]);
            }
          }
          int width1 = this.Width;
          for (int index = 0; index <= width1; ++index)
          {
            this.Data[row + 1, index] = "";
            this.TempBmp[row + 1, index] = 0;
            this.TempDesc[row + 1, index] = "";
          }
        }
        else
        {
          ++this.Length;
          this.Data = new string[this.Length + 1, this.Width + 1];
          this.TempBmp = new int[this.Length + 1, this.Width + 1];
          this.TempDesc = new string[this.Length + 1, this.Width + 1];
          int num = this.Length - 1;
          for (int index7 = 0; index7 <= num; ++index7)
          {
            int width = this.Width;
            for (int index8 = 0; index8 <= width; ++index8)
            {
              this.Data[index7, index8] = Conversions.ToString(objArray1[index7, index8]);
              this.TempBmp[index7, index8] = Conversions.ToInteger(objArray2[index7, index8]);
              this.TempDesc[index7, index8] = Conversions.ToString(objArray3[index7, index8]);
            }
          }
          int width2 = this.Width;
          for (int index = 0; index <= width2; ++index)
          {
            this.Data[this.Length, index] = "";
            this.TempBmp[row + 1, index] = 0;
            this.TempDesc[row + 1, index] = "";
          }
        }
        int upperBound1 = this.Data.GetUpperBound(0);
        for (int index9 = 0; index9 <= upperBound1; ++index9)
        {
          int upperBound2 = this.Data.GetUpperBound(1);
          for (int index10 = 0; index10 <= upperBound2; ++index10)
          {
            if (Information.IsNothing((object) this.Data[index9, index10]))
              this.Data[index9, index10] = "";
          }
        }
      }
    }

    public void AddRowFast(int row)
    {
      if (row < this.Length)
      {
        int num1 = (int) Interaction.MsgBox((object) "Error, can only add at end of list with AddRowFast");
      }
      else
      {
        if (this.Length >= this.Data.GetUpperBound(0) | this.Data.GetUpperBound(1) < this.Width)
        {
          object[,] objArray1 = new object[this.Length + 1 + 1, this.Width + 1];
          object[,] objArray2 = new object[this.Length + 1 + 1, this.Width + 1];
          object[,] objArray3 = new object[this.Length + 1 + 1, this.Width + 1];
          int length = this.Length;
          for (int index1 = 0; index1 <= length; ++index1)
          {
            int width = this.Width;
            for (int index2 = 0; index2 <= width; ++index2)
            {
              objArray1[index1, index2] = (object) this.Data[index1, index2];
              objArray2[index1, index2] = (object) this.TempBmp[index1, index2];
              objArray3[index1, index2] = (object) this.TempDesc[index1, index2];
            }
          }
          ++this.Length;
          if (this.Length >= 100000)
          {
            this.Data = new string[this.Length + 100000 + 1, this.Width + 1];
            this.TempBmp = new int[this.Length + 100000 + 1, this.Width + 1];
            this.TempDesc = new string[this.Length + 100000 + 1, this.Width + 1];
          }
          else if (this.Length >= 30000)
          {
            this.Data = new string[this.Length + 30000 + 1, this.Width + 1];
            this.TempBmp = new int[this.Length + 30000 + 1, this.Width + 1];
            this.TempDesc = new string[this.Length + 30000 + 1, this.Width + 1];
          }
          else if (this.Length >= 10000)
          {
            this.Data = new string[this.Length + 10000 + 1, this.Width + 1];
            this.TempBmp = new int[this.Length + 10000 + 1, this.Width + 1];
            this.TempDesc = new string[this.Length + 10000 + 1, this.Width + 1];
          }
          else if (this.Length >= 1000)
          {
            this.Data = new string[this.Length + 1000 + 1, this.Width + 1];
            this.TempBmp = new int[this.Length + 1000 + 1, this.Width + 1];
            this.TempDesc = new string[this.Length + 1000 + 1, this.Width + 1];
          }
          else
          {
            this.Data = new string[this.Length + 100 + 1, this.Width + 1];
            this.TempBmp = new int[this.Length + 100 + 1, this.Width + 1];
            this.TempDesc = new string[this.Length + 100 + 1, this.Width + 1];
          }
          int num2 = this.Length - 1;
          for (int index3 = 0; index3 <= num2; ++index3)
          {
            int width = this.Width;
            for (int index4 = 0; index4 <= width; ++index4)
            {
              this.Data[index3, index4] = Conversions.ToString(objArray1[index3, index4]);
              this.TempBmp[index3, index4] = Conversions.ToInteger(objArray2[index3, index4]);
              this.TempDesc[index3, index4] = Conversions.ToString(objArray3[index3, index4]);
            }
          }
        }
        else
          ++this.Length;
        int width1 = this.Width;
        for (int index = 0; index <= width1; ++index)
        {
          if (this.TempBmp.Length < this.Data.Length)
          {
            this.TempBmp = new int[this.Length + 1, this.Width + 1];
            this.TempDesc = new string[this.Length + 1, this.Width + 1];
          }
          this.Data[this.Length, index] = "";
          this.TempBmp[this.Length, index] = 0;
          this.TempDesc[this.Length, index] = "";
        }
      }
    }

    public void AddCol(int col, string tname = "New Col")
    {
      this.ColumnName = (string[]) Utils.CopyArray((Array) this.ColumnName, (Array) new string[this.Width + 1 + 1]);
      this.logEnabled = (bool[]) Utils.CopyArray((Array) this.logEnabled, (Array) new bool[this.Width + 1 + 1]);
      this.ColSort = (int[]) Utils.CopyArray((Array) this.ColSort, (Array) new int[this.Width + 1 + 1]);
      this.ColWidth = (int[]) Utils.CopyArray((Array) this.ColWidth, (Array) new int[this.Width + 1 + 1]);
      this.LookUpCol = (int[]) Utils.CopyArray((Array) this.LookUpCol, (Array) new int[this.Width + 1 + 1]);
      this.SSID = (int[]) Utils.CopyArray((Array) this.SSID, (Array) new int[this.Width + 1 + 1]);
      this.ColValueType = (NewEnums.LibVarValueType[]) Utils.CopyArray((Array) this.ColValueType, (Array) new NewEnums.LibVarValueType[this.Width + 1 + 1]);
      this.TempColumBmp = (string[]) Utils.CopyArray((Array) this.TempColumBmp, (Array) new string[this.Width + 1 + 1]);
      object[,] objArray = new object[this.Length + 1 + 1, this.Width + 1];
      int length1 = this.Length;
      for (int index1 = 0; index1 <= length1; ++index1)
      {
        int width = this.Width;
        for (int index2 = 0; index2 <= width; ++index2)
          objArray[index1, index2] = (object) this.Data[index1, index2];
      }
      if (col + 1 < this.Width)
      {
        ++this.Width;
        if (this.Length > -1)
          this.Data = (string[,]) Utils.CopyArray((Array) this.Data, (Array) new string[this.Data.GetUpperBound(0) + 1, this.Width + 1]);
        if (this.Length > -1)
          this.TempBmp = (int[,]) Utils.CopyArray((Array) this.TempBmp, (Array) new int[this.TempBmp.GetUpperBound(0) + 1, this.Width + 1]);
        if (this.Length > -1)
          this.TempDesc = (string[,]) Utils.CopyArray((Array) this.TempDesc, (Array) new string[this.TempDesc.GetUpperBound(0) + 1, this.Width + 1]);
        int length2 = this.Length;
        for (int index3 = 0; index3 <= length2; ++index3)
        {
          int width = this.Width;
          int num = col + 2;
          for (int index4 = width; index4 >= num; index4 += -1)
            this.Data[index3, index4] = Conversions.ToString(objArray[index3, index4 - 1]);
        }
        int width1 = this.Width;
        int num1 = col + 2;
        for (int index = width1; index >= num1; index += -1)
        {
          this.ColumnName[index] = this.ColumnName[index - 1];
          this.logEnabled[index] = this.logEnabled[index - 1];
          this.ColSort[index] = this.ColSort[index - 1];
          this.ColWidth[index] = this.ColWidth[index - 1];
          this.ColValueType[index] = this.ColValueType[index - 1];
        }
        int length3 = this.Length;
        for (int index = 0; index <= length3; ++index)
          this.Data[index, col + 1] = "";
        this.ColumnName[col + 1] = tname;
        this.logEnabled[col + 1] = false;
        this.ColValueType[col + 1] = NewEnums.LibVarValueType.Text;
      }
      else
      {
        ++this.Width;
        if (this.Length > -1)
          this.Data = (string[,]) Utils.CopyArray((Array) this.Data, (Array) new string[this.Data.GetUpperBound(0) + 1, this.Width + 1]);
        if (this.Length > -1)
          this.TempBmp = (int[,]) Utils.CopyArray((Array) this.TempBmp, (Array) new int[this.TempBmp.GetUpperBound(0) + 1, this.Width + 1]);
        if (this.Length > -1)
          this.TempDesc = (string[,]) Utils.CopyArray((Array) this.TempDesc, (Array) new string[this.TempDesc.GetUpperBound(0) + 1, this.Width + 1]);
        int length4 = this.Length;
        for (int index = 0; index <= length4; ++index)
          this.Data[index, this.Width] = "";
        this.ColumnName[this.Width] = tname;
        this.logEnabled[this.Width] = false;
        this.ColValueType[this.Width] = NewEnums.LibVarValueType.Text;
      }
      int upperBound1 = this.Data.GetUpperBound(0);
      for (int index5 = 0; index5 <= upperBound1; ++index5)
      {
        int upperBound2 = this.Data.GetUpperBound(1);
        for (int index6 = 0; index6 <= upperBound2; ++index6)
        {
          if (Information.IsNothing((object) this.Data[index5, index6]))
            this.Data[index5, index6] = "";
        }
      }
    }
  }
}
