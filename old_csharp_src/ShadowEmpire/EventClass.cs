// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.EventClass
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
  public class EventClass : ISerializable
  {
    public string Name;
    public int CheckMode;
    public int CommandCounter;
    public CommandClass[] CommandList;
    public bool Blocked;
    public int Category;
    public LibIdClass LibId;
    public bool AllowExecute;
    public int Id;
    public int Priority;

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Name", (object) this.Name);
      info.AddValue("CheckMode", this.CheckMode);
      info.AddValue("CommandCounter", this.CommandCounter);
      info.AddValue("CommandList", (object) this.CommandList);
      info.AddValue("Blocked", this.Blocked);
      info.AddValue("Category", this.Category);
      info.AddValue("LibId", (object) this.LibId);
      info.AddValue("AllowExecute", this.AllowExecute);
      info.AddValue("Id", this.Id);
      info.AddValue("Priority", this.Priority);
    }

    protected EventClass(SerializationInfo info, StreamingContext context)
    {
      this.CommandList = new CommandClass[1];
      this.Name = info.GetString(nameof (Name));
      this.CheckMode = info.GetInt32(nameof (CheckMode));
      this.CommandCounter = info.GetInt32(nameof (CommandCounter));
      this.CommandList = (CommandClass[]) info.GetValue(nameof (CommandList), this.CommandList.GetType());
      try
      {
        this.Blocked = info.GetBoolean(nameof (Blocked));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Blocked = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.Category = info.GetInt32(nameof (Category));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Category = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.LibId = new LibIdClass();
        this.LibId = (LibIdClass) info.GetValue(nameof (LibId), this.LibId.GetType());
        this.AllowExecute = info.GetBoolean(nameof (AllowExecute));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.LibId = new LibIdClass();
        this.AllowExecute = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.Id = info.GetInt32(nameof (Id));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Id = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.Priority = info.GetInt32(nameof (Priority));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Priority = 0;
        ProjectData.ClearProjectError();
      }
    }

    public EventClass(int hardcoded)
    {
      this.CommandList = new CommandClass[1];
      this.CommandCounter = -1;
      this.Name = "New Event";
      this.Blocked = false;
      this.LibId = new LibIdClass();
      this.Category = -1;
      this.Priority = 0;
    }

    public void AddCommand(int insert = -1)
    {
      ++this.CommandCounter;
      this.CommandList = (CommandClass[]) Utils.CopyArray((Array) this.CommandList, (Array) new CommandClass[this.CommandCounter + 1]);
      this.CommandList[this.CommandCounter] = new CommandClass(0);
      if (insert <= -1 || insert >= this.CommandCounter - 1)
        return;
      int commandCounter = this.CommandCounter;
      int num = insert + 2;
      for (int index = commandCounter; index >= num; index += -1)
        this.CommandList[index] = this.CommandList[index - 1];
      this.CommandList[insert + 1] = new CommandClass(0);
    }

    public void Commanddown(int nr)
    {
      if (nr >= this.CommandCounter)
        return;
      CommandClass commandClass = this.CommandList[nr].Clone();
      this.CommandList[nr] = this.CommandList[nr + 1].Clone();
      this.CommandList[nr + 1] = commandClass;
    }

    public void Commandup(int nr)
    {
      if (nr <= 0)
        return;
      CommandClass commandClass = this.CommandList[nr].Clone();
      this.CommandList[nr] = this.CommandList[nr - 1].Clone();
      this.CommandList[nr - 1] = commandClass;
    }

    public void RemoveCommand(int nr)
    {
      if (nr < this.CommandCounter)
      {
        int num1 = nr;
        int num2 = this.CommandCounter - 1;
        for (int index = num1; index <= num2; ++index)
          this.CommandList[index] = this.CommandList[index + 1].Clone();
      }
      --this.CommandCounter;
      if (this.CommandCounter == -1)
        return;
      this.CommandList = (CommandClass[]) Utils.CopyArray((Array) this.CommandList, (Array) new CommandClass[this.CommandCounter + 1]);
    }

    public EventClass Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (EventClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }
  }
}
