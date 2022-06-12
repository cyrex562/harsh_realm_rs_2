// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.CommandClass
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
  public class CommandClass : ISerializable
  {
    public int type;
    public string[,] Data;
    public string DataString;

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Type", this.type);
      if (DrawMod.TGame.Data.Version > 407)
      {
        int index1 = 0;
        string str;
        do
        {
          int index2 = 0;
          do
          {
            str = str + "®" + this.Data[index1, index2];
            ++index2;
          }
          while (index2 <= 30);
          ++index1;
        }
        while (index1 <= 2);
        info.AddValue("s", (object) str);
      }
      else
        info.AddValue("Data", (object) this.Data);
      info.AddValue("DataString", (object) this.DataString);
    }

    protected CommandClass(SerializationInfo info, StreamingContext context)
    {
      this.Data = new string[3, 31];
      int[,] numArray1 = new int[3, 31];
      this.type = info.GetInt32("Type");
      try
      {
        if (DrawMod.TGame.Data.Version > 407)
        {
          string str1 = info.GetString("s");
          int Start1 = 1;
          int index1 = 0;
          do
          {
            int index2 = 0;
            do
            {
              int num = Strings.InStr(Start1, str1, "®", CompareMethod.Text);
              int Start2 = Strings.InStr(num + 1, str1, "®", CompareMethod.Text);
              string str2 = "";
              if (num > 0)
              {
                if (Start2 > 0)
                {
                  str2 = Strings.Mid(str1, num + 1, Start2 - num - 1);
                  str1 = Strings.Mid(str1, Start2);
                }
                else
                {
                  str2 = Strings.Mid(str1, num + 1);
                  str1 = "";
                }
              }
              this.Data[index1, index2] = str2;
              ++index2;
            }
            while (index2 <= 30);
            ++index1;
          }
          while (index1 <= 2);
        }
        else
        {
          try
          {
            this.Data = (string[,]) info.GetValue(nameof (Data), this.Data.GetType());
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            numArray1 = (int[,]) info.GetValue(nameof (Data), numArray1.GetType());
            int index3 = 0;
            do
            {
              int index4 = 0;
              do
              {
                this.Data[index3, index4] = Strings.Trim(Conversion.Str((object) numArray1[index3, index4]));
                ++index4;
              }
              while (index4 <= 30);
              ++index3;
            }
            while (index3 <= 2);
            ProjectData.ClearProjectError();
          }
        }
      }
      catch (Exception ex1)
      {
        ProjectData.SetProjectError(ex1);
        try
        {
          this.Data = (string[,]) info.GetValue(nameof (Data), this.Data.GetType());
        }
        catch (Exception ex2)
        {
          ProjectData.SetProjectError(ex2);
          int[,] numArray2 = (int[,]) info.GetValue(nameof (Data), numArray1.GetType());
          int index5 = 0;
          do
          {
            int index6 = 0;
            do
            {
              this.Data[index5, index6] = Strings.Trim(Conversion.Str((object) numArray2[index5, index6]));
              ++index6;
            }
            while (index6 <= 30);
            ++index5;
          }
          while (index5 <= 2);
          ProjectData.ClearProjectError();
        }
        ProjectData.ClearProjectError();
      }
      this.DataString = info.GetString(nameof (DataString));
    }

    public CommandClass Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (CommandClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    public CommandClass(int hardcoded)
    {
      this.Data = new string[3, 31];
      this.type = 0;
    }
  }
}
