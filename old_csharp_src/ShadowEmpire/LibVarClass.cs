// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.LibVarClass
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
  public class LibVarClass : ISerializable
  {
    public NewEnums.LibVarType type;
    public LibIdClass libId;
    public string name;
    public NewEnums.LibVarValueType valueType;
    public LibIdClass instanceId;
    public int value;
    public string valueText;
    public string information;

    public LibVarClass(int tlibSlot)
    {
      this.type = NewEnums.LibVarType.General;
      this.libId = new LibIdClass();
      this.libId.libSlot = tlibSlot;
      this.libId.id = -1;
      this.valueType = NewEnums.LibVarValueType.Number;
      this.value = 0;
      this.valueText = "";
      this.instanceId = new LibIdClass();
      this.instanceId.libSlot = -1;
      this.instanceId.id = -1;
    }

    public LibVarClass Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (LibVarClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }

    public string GetValue(ref DataClass Data, bool ForEvent = false)
    {
      string str = this.value.ToString();
      if (this.valueType == NewEnums.LibVarValueType.Number)
        return this.value.ToString();
      if (this.valueType == NewEnums.LibVarValueType.YesNo)
        return !ForEvent ? (this.value != 1 ? "No" : "Yes") : (this.value != 1 ? "0" : "1");
      if (this.valueType == NewEnums.LibVarValueType.Text)
        return this.valueText;
      if (this.valueType == NewEnums.LibVarValueType.DateString)
      {
        string Left = this.valueText;
        if (ForEvent)
        {
          if (Operators.CompareString(Left, "", false) == 0)
            Left = "0";
        }
        else if (Operators.CompareString(Left, "", false) == 0)
          Left = "-not set-";
        return Left;
      }
      if (this.valueType == NewEnums.LibVarValueType.HistoricalUnitId | this.valueType == NewEnums.LibVarValueType.HistoricalUnitModelId)
        str = !(this.value > -1 & this.value <= Data.HistoricalUnitCounter) ? (this.value <= Data.HistoricalUnitCounter ? (this.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : Data.HistoricalUnitObj[this.value].Name;
      if (this.valueType == NewEnums.LibVarValueType.OfficerId)
        str = !(this.value > -1 & this.value <= Data.HistoricalUnitCounter) ? (this.value <= Data.HistoricalUnitCounter ? (this.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : Data.HistoricalUnitObj[this.value].CommanderName;
      if (this.valueType == NewEnums.LibVarValueType.LandscapeId)
        str = !(this.value > -1 & this.value <= Data.LandscapeTypeCounter) ? (this.value <= Data.LandscapeTypeCounter ? (this.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : Data.LandscapeTypeObj[this.value].Name;
      if (this.valueType == NewEnums.LibVarValueType.EventPicId)
        str = !(this.value > -1 & this.value <= Data.EventPicCounter) ? (this.value <= Data.EventPicCounter ? (this.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : Data.EventPicName[this.value];
      if (this.valueType == NewEnums.LibVarValueType.SmallGfxId)
        str = !(this.value > -1 & this.value <= Data.SmallPicCounter) ? (this.value <= Data.SmallPicCounter ? (this.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : Data.SmallPicName[this.value];
      if (this.valueType == NewEnums.LibVarValueType.PeopleId)
        str = !(this.value > -1 & this.value <= Data.PeopleCounter) ? (this.value <= Data.PeopleCounter ? (this.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : Data.PeopleObj[this.value].Name;
      if (this.valueType == NewEnums.LibVarValueType.RiverId)
        str = !(this.value > -1 & this.value <= Data.RiverTypeCounter) ? (this.value <= Data.RiverTypeCounter ? (this.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : Data.RiverTypeObj[this.value].Name;
      if (this.valueType == NewEnums.LibVarValueType.RoadId)
        str = !(this.value > -1 & this.value <= Data.RoadTypeCounter) ? (this.value <= Data.RoadTypeCounter ? (this.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : Data.RoadTypeObj[this.value].Name;
      if (this.valueType == NewEnums.LibVarValueType.SFTypeId)
        str = !(this.value > -1 & this.value <= Data.SFTypeCounter) ? (this.value <= Data.SFTypeCounter ? (this.value != -1 ? "Invalid value" : "None/All") : "Non-existing!") : Data.SFTypeObj[this.value].Name;
      if (this.valueType == NewEnums.LibVarValueType.YesNo)
        str = this.value <= 0 ? "No" : "Yes";
      if (ForEvent && this.value == -1)
        return "-1";
      return ForEvent ? Conversions.ToString(this.value) : str;
    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("type", (int) this.type);
      info.AddValue("libId", (object) this.libId);
      info.AddValue("name", (object) this.name);
      info.AddValue("valueType", (int) this.valueType);
      info.AddValue("value", this.value);
      info.AddValue("valueText", (object) this.valueText);
      if (this.libId.id == -1)
        info.AddValue("information", (object) this.information);
      info.AddValue("instanceId", (object) this.instanceId);
    }

    protected LibVarClass(SerializationInfo info, StreamingContext context)
    {
      this.type = (NewEnums.LibVarType) info.GetInt32(nameof (type));
      this.libId = new LibIdClass();
      this.libId = (LibIdClass) info.GetValue(nameof (libId), this.libId.GetType());
      this.name = info.GetString(nameof (name));
      this.valueType = (NewEnums.LibVarValueType) info.GetInt32(nameof (valueType));
      this.value = info.GetInt32(nameof (value));
      this.valueText = info.GetString(nameof (valueText));
      if (this.libId.id == -1)
        this.information = info.GetString(nameof (information));
      try
      {
        this.instanceId = new LibIdClass();
        this.instanceId = (LibIdClass) info.GetValue(nameof (instanceId), this.instanceId.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.instanceId = new LibIdClass();
        this.instanceId.libSlot = -1;
        this.instanceId.id = -1;
        ProjectData.ClearProjectError();
      }
    }
  }
}
