// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.HistoricalUnitClass
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
  public class HistoricalUnitClass : ISerializable
  {
    public string Name;
    public int Type;
    public int ID;
    public int Counter;
    public string CounterString;
    public int TempDefend;
    public int TempAttack;
    public int TempStance;
    public int TempTargetX;
    public int TempTargetY;
    public int TempTargetAttackX;
    public int TempTargetAttackY;
    public int TempRegime;
    public bool NoSplit;
    public bool UseRomans;
    public int MaxPresent;
    public int StartSize;
    public int SmallGfx;
    public string CommanderName;
    public string CommanderFileName;
    public int CommanderSpriteID;
    public string OverdrawFileName;
    public int OverdrawSpriteID;
    public int DeckCardCounter;
    public int[] DeckCard;
    public int[] DeckChance;
    public int AutoEventCounter;
    public int[] AutoEvent;
    public int[] AutoChance;
    public int HandCardCounter;
    public int[] HandCard;
    public int PP;
    public bool Fixed;
    public int NameCounter;
    public int NameCounterBackup;
    public int PercentOldName;
    public int CombatMod;
    public int MoraleMod;
    public int StaffSize;
    public bool Model;
    public bool Pool;
    public int Red;
    public int Green;
    public int Blue;
    public int[] SubParts;
    public int[] Designation;
    public int[] DesignationSmall;
    public int BattleGroup;
    public int AIlist;
    public int ModelMaster;
    public string Descript;
    public int Xp;
    public int TempVar1;
    public int TempVar2;
    public int TempVar3;
    public int TempVar4;
    public int TempVar5;
    public int People;
    public int UsePeopleGfx;
    public int Level1;
    public int Level2;
    public int Level3;
    public int HisVarCount;
    public int[] HisVarType;
    public int[] HisVarValue;
    public int[] HisVarNato;
    public int[] HisVarSmall;
    public int UseModelCounter;
    public LibIdClass LibId;
    public LibIdClass OffLibId;

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Name", (object) this.Name);
      info.AddValue("Type", this.Type);
      info.AddValue("ID", this.ID);
      info.AddValue("Counter", this.Counter);
      info.AddValue("CounterString", (object) this.CounterString);
      info.AddValue("TempRegime", this.TempRegime);
      info.AddValue("CommanderName", (object) this.CommanderName);
      info.AddValue("CommanderFileName", (object) this.CommanderFileName);
      info.AddValue("OverdrawFileName", (object) this.OverdrawFileName);
      info.AddValue("DeckCardCounter", this.DeckCardCounter);
      info.AddValue("DeckCard", (object) this.DeckCard);
      info.AddValue("DeckChance", (object) this.DeckChance);
      info.AddValue("AutoEventCounter", this.AutoEventCounter);
      info.AddValue("AutoEvent", (object) this.AutoEvent);
      info.AddValue("AutoChance", (object) this.AutoChance);
      info.AddValue("HandCardCounter", this.HandCardCounter);
      info.AddValue("HandCard", (object) this.HandCard);
      info.AddValue("PP", this.PP);
      info.AddValue("Model", this.Model);
      info.AddValue("Red", this.Red);
      info.AddValue("Green", this.Green);
      info.AddValue("Blue", this.Blue);
      info.AddValue("SubParts", (object) this.SubParts);
      info.AddValue("Designation", (object) this.Designation);
      info.AddValue("NoSplit", this.NoSplit);
      info.AddValue("CombatMod", this.CombatMod);
      info.AddValue("MoraleMod", this.MoraleMod);
      info.AddValue("StaffSize", this.StaffSize);
      info.AddValue("ModelMaster", this.ModelMaster);
      info.AddValue("NameCounter", this.NameCounter);
      info.AddValue("NameCounterBackup", this.NameCounterBackup);
      info.AddValue("Fixed", this.Fixed);
      info.AddValue("Pool", this.Pool);
      info.AddValue("Descript", (object) this.Descript);
      info.AddValue("Xp", this.Xp);
      info.AddValue("TempVar1", this.TempVar1);
      info.AddValue("TempVar2", this.TempVar2);
      info.AddValue("TempVar3", this.TempVar3);
      info.AddValue("TempVar4", this.TempVar4);
      info.AddValue("TempVar5", this.TempVar5);
      info.AddValue("StartSize", this.StartSize);
      info.AddValue("AIList", this.AIlist);
      info.AddValue("Level1", this.Level1);
      info.AddValue("Level2", this.Level2);
      info.AddValue("Level3", this.Level3);
      info.AddValue("HisVarCount", this.HisVarCount);
      info.AddValue("HisVarType", (object) this.HisVarType);
      info.AddValue("HisVarValue", (object) this.HisVarValue);
      info.AddValue("HisVarNato", (object) this.HisVarNato);
      info.AddValue("HisVarSmall", (object) this.HisVarSmall);
      info.AddValue("People", this.People);
      info.AddValue("MaxPresent", this.MaxPresent);
      info.AddValue("PercentOldName", this.PercentOldName);
      info.AddValue("UseRomans", this.UseRomans);
      info.AddValue("UseModelCounter", this.UseModelCounter);
      info.AddValue("UsePeopleGfx", this.UsePeopleGfx);
      info.AddValue("LibId", (object) this.LibId);
      info.AddValue("OffLibId", (object) this.OffLibId);
      info.AddValue("SmallGfx", this.SmallGfx);
      info.AddValue("DesignationSmall", (object) this.DesignationSmall);
      info.AddValue("Battlegroup", this.BattleGroup);
    }

    protected HistoricalUnitClass(SerializationInfo info, StreamingContext context)
    {
      this.DeckCard = new int[2];
      this.DeckChance = new int[2];
      this.AutoEvent = new int[2];
      this.AutoChance = new int[2];
      this.HandCard = new int[2];
      this.SubParts = new int[10];
      this.Designation = new int[10];
      this.DesignationSmall = new int[10];
      this.HisVarType = new int[1];
      this.HisVarValue = new int[1];
      this.HisVarNato = new int[1];
      this.HisVarSmall = new int[1];
      this.Name = info.GetString(nameof (Name));
      this.Type = info.GetInt32(nameof (Type));
      this.ID = info.GetInt32(nameof (ID));
      this.Counter = info.GetInt32(nameof (Counter));
      this.CounterString = info.GetString(nameof (CounterString));
      if (DrawMod.TGame.Data.Version < 158)
      {
        try
        {
          this.TempRegime = info.GetInt32(nameof (TempRegime));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.TempRegime = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.StartSize = info.GetInt32(nameof (StartSize));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.StartSize = 0;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.OverdrawFileName = info.GetString(nameof (OverdrawFileName));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.OverdrawFileName = "";
          ProjectData.ClearProjectError();
        }
        try
        {
          this.CommanderName = info.GetString(nameof (CommanderName));
          this.CommanderFileName = info.GetString(nameof (CommanderFileName));
          this.DeckCardCounter = info.GetInt32(nameof (DeckCardCounter));
          this.DeckCard = new int[this.DeckCardCounter + 1];
          this.DeckChance = new int[this.DeckCardCounter + 1];
          this.DeckCard = (int[]) info.GetValue(nameof (DeckCard), this.DeckCard.GetType());
          this.DeckChance = (int[]) info.GetValue(nameof (DeckChance), this.DeckChance.GetType());
          this.AutoEventCounter = info.GetInt32(nameof (AutoEventCounter));
          this.AutoEvent = new int[this.AutoEventCounter + 1];
          this.AutoChance = new int[this.AutoEventCounter + 1];
          this.AutoEvent = (int[]) info.GetValue(nameof (AutoEvent), this.AutoEvent.GetType());
          this.AutoChance = (int[]) info.GetValue(nameof (AutoChance), this.AutoChance.GetType());
          this.HandCardCounter = info.GetInt32(nameof (HandCardCounter));
          this.HandCard = new int[this.HandCardCounter + 1];
          this.HandCard = (int[]) info.GetValue(nameof (HandCard), this.HandCard.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.DeckCardCounter = -1;
          this.AutoEventCounter = -1;
          this.HandCardCounter = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.PP = info.GetInt32(nameof (PP));
          this.Model = info.GetBoolean(nameof (Model));
          this.Red = info.GetInt32(nameof (Red));
          this.Green = info.GetInt32(nameof (Green));
          this.Blue = info.GetInt32(nameof (Blue));
          this.SubParts = (int[]) info.GetValue(nameof (SubParts), this.SubParts.GetType());
          this.Designation = (int[]) info.GetValue(nameof (Designation), this.Designation.GetType());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.PP = 0;
          this.Model = false;
          this.Red = 0;
          this.Green = 0;
          this.Blue = 0;
          int index = 0;
          do
          {
            this.SubParts[index] = -1;
            this.Designation[index] = -1;
            ++index;
          }
          while (index <= 9);
          ProjectData.ClearProjectError();
        }
        try
        {
          this.CombatMod = info.GetInt32(nameof (CombatMod));
          this.MoraleMod = info.GetInt32(nameof (MoraleMod));
          this.StaffSize = info.GetInt32(nameof (StaffSize));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.CombatMod = 0;
          this.MoraleMod = 0;
          this.StaffSize = 0;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.ModelMaster = info.GetInt32(nameof (ModelMaster));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.ModelMaster = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.Fixed = info.GetBoolean(nameof (Fixed));
          this.NameCounter = info.GetInt32(nameof (NameCounter));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.Fixed = false;
          this.NameCounter = 0;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.NameCounterBackup = info.GetInt32(nameof (NameCounterBackup));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.NameCounterBackup = -1;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.Pool = info.GetBoolean(nameof (Pool));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.Pool = false;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.NoSplit = info.GetBoolean(nameof (NoSplit));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.NoSplit = false;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.Descript = info.GetString(nameof (Descript));
          this.Xp = info.GetInt32(nameof (Xp));
          this.TempVar1 = info.GetInt32(nameof (TempVar1));
          this.TempVar2 = info.GetInt32(nameof (TempVar2));
          this.TempVar3 = info.GetInt32(nameof (TempVar3));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.Descript = "";
          this.Xp = 0;
          this.TempVar1 = 0;
          this.TempVar2 = 0;
          this.TempVar3 = 0;
          ProjectData.ClearProjectError();
        }
        this.TempVar4 = 0;
        this.TempVar5 = 0;
      }
      else
      {
        this.TempRegime = info.GetInt32(nameof (TempRegime));
        this.StartSize = info.GetInt32(nameof (StartSize));
        this.OverdrawFileName = info.GetString(nameof (OverdrawFileName));
        this.CommanderName = info.GetString(nameof (CommanderName));
        if (Information.IsNothing((object) this.CommanderName))
          this.CommanderName = "";
        this.CommanderFileName = info.GetString(nameof (CommanderFileName));
        this.DeckCardCounter = info.GetInt32(nameof (DeckCardCounter));
        if (this.DeckCardCounter > -1)
        {
          this.DeckCard = new int[this.DeckCardCounter + 1];
          this.DeckChance = new int[this.DeckCardCounter + 1];
        }
        else
        {
          this.DeckCard = new int[1];
          this.DeckChance = new int[1];
        }
        this.DeckCard = (int[]) info.GetValue(nameof (DeckCard), this.DeckCard.GetType());
        this.DeckChance = (int[]) info.GetValue(nameof (DeckChance), this.DeckChance.GetType());
        this.AutoEventCounter = info.GetInt32(nameof (AutoEventCounter));
        if (this.AutoEventCounter > -1)
        {
          this.AutoEvent = new int[this.AutoEventCounter + 1];
          this.AutoChance = new int[this.AutoEventCounter + 1];
        }
        else
        {
          this.AutoEvent = new int[1];
          this.AutoChance = new int[1];
        }
        this.AutoEvent = (int[]) info.GetValue(nameof (AutoEvent), this.AutoEvent.GetType());
        this.AutoChance = (int[]) info.GetValue(nameof (AutoChance), this.AutoChance.GetType());
        this.HandCardCounter = info.GetInt32(nameof (HandCardCounter));
        this.HandCard = new int[this.HandCardCounter + 1];
        this.HandCard = (int[]) info.GetValue(nameof (HandCard), this.HandCard.GetType());
        this.PP = info.GetInt32(nameof (PP));
        this.Model = info.GetBoolean(nameof (Model));
        this.Red = info.GetInt32(nameof (Red));
        this.Green = info.GetInt32(nameof (Green));
        this.Blue = info.GetInt32(nameof (Blue));
        this.SubParts = (int[]) info.GetValue(nameof (SubParts), this.SubParts.GetType());
        this.Designation = (int[]) info.GetValue(nameof (Designation), this.Designation.GetType());
        this.CombatMod = info.GetInt32(nameof (CombatMod));
        this.MoraleMod = info.GetInt32(nameof (MoraleMod));
        this.StaffSize = info.GetInt32(nameof (StaffSize));
        this.ModelMaster = info.GetInt32(nameof (ModelMaster));
        this.Fixed = info.GetBoolean(nameof (Fixed));
        this.NameCounter = info.GetInt32(nameof (NameCounter));
        try
        {
          this.NameCounterBackup = info.GetInt32(nameof (NameCounterBackup));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.NameCounterBackup = -1;
          ProjectData.ClearProjectError();
        }
        this.Pool = info.GetBoolean(nameof (Pool));
        this.NoSplit = info.GetBoolean(nameof (NoSplit));
        this.Descript = info.GetString(nameof (Descript));
        this.Xp = info.GetInt32(nameof (Xp));
        this.TempVar1 = info.GetInt32(nameof (TempVar1));
        this.TempVar2 = info.GetInt32(nameof (TempVar2));
        this.TempVar3 = info.GetInt32(nameof (TempVar3));
      }
      if (DrawMod.TGame.Data.Version < 180)
      {
        this.AIlist = info.GetInt32("AIList");
        this.Level1 = info.GetInt32(nameof (Level1));
        this.Level2 = info.GetInt32(nameof (Level2));
        this.Level3 = info.GetInt32(nameof (Level3));
      }
      else
      {
        try
        {
          this.AIlist = info.GetInt32("AIList");
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.AIlist = 0;
          ProjectData.ClearProjectError();
        }
        try
        {
          this.Level1 = info.GetInt32(nameof (Level1));
          this.Level2 = info.GetInt32(nameof (Level2));
          this.Level3 = info.GetInt32(nameof (Level3));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.Level1 = 0;
          this.Level2 = 0;
          this.Level3 = 0;
          ProjectData.ClearProjectError();
        }
      }
      if (DrawMod.TGame.Data.Version > 200)
      {
        try
        {
          this.TempVar4 = info.GetInt32(nameof (TempVar4));
          this.TempVar5 = info.GetInt32(nameof (TempVar5));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.TempVar4 = 0;
          this.TempVar5 = 0;
          ProjectData.ClearProjectError();
        }
      }
      this.CommanderSpriteID = -1;
      try
      {
        this.HisVarCount = info.GetInt32(nameof (HisVarCount));
        this.HisVarType = new int[this.HisVarCount + 1];
        this.HisVarValue = new int[this.HisVarCount + 1];
        this.HisVarNato = new int[this.HisVarCount + 1];
        this.HisVarType = (int[]) info.GetValue(nameof (HisVarType), this.HisVarType.GetType());
        this.HisVarValue = (int[]) info.GetValue(nameof (HisVarValue), this.HisVarValue.GetType());
        this.HisVarNato = (int[]) info.GetValue(nameof (HisVarNato), this.HisVarNato.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.HisVarCount = -1;
        this.HisVarType = new int[1];
        this.HisVarValue = new int[1];
        this.HisVarNato = new int[1];
        ProjectData.ClearProjectError();
      }
      try
      {
        this.HisVarSmall = new int[this.HisVarCount + 1];
        this.HisVarSmall = (int[]) info.GetValue(nameof (HisVarSmall), this.HisVarNato.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.HisVarSmall = new int[this.HisVarCount + 1];
        int hisVarCount = this.HisVarCount;
        for (int index = 0; index <= hisVarCount; ++index)
          this.HisVarSmall[index] = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.People = info.GetInt32(nameof (People));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.People = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.MaxPresent = info.GetInt32(nameof (MaxPresent));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.MaxPresent = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.PercentOldName = info.GetInt32(nameof (PercentOldName));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.PercentOldName = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.UseRomans = info.GetBoolean(nameof (UseRomans));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.UseRomans = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.UseModelCounter = info.GetInt32(nameof (UseModelCounter));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.UseModelCounter = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.UsePeopleGfx = info.GetInt32(nameof (UsePeopleGfx));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.UsePeopleGfx = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.LibId = new LibIdClass();
        this.LibId = (LibIdClass) info.GetValue(nameof (LibId), this.LibId.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.LibId = new LibIdClass();
        ProjectData.ClearProjectError();
      }
      try
      {
        this.OffLibId = new LibIdClass();
        this.OffLibId = (LibIdClass) info.GetValue(nameof (OffLibId), this.OffLibId.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.OffLibId = new LibIdClass();
        ProjectData.ClearProjectError();
      }
      try
      {
        this.SmallGfx = info.GetInt32(nameof (SmallGfx));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.SmallGfx = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.DesignationSmall = (int[]) info.GetValue(nameof (DesignationSmall), this.DesignationSmall.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.DesignationSmall = new int[10];
        ProjectData.ClearProjectError();
      }
      try
      {
        this.BattleGroup = info.GetInt32("Battlegroup");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.BattleGroup = 0;
        ProjectData.ClearProjectError();
      }
    }

    public HistoricalUnitClass()
    {
      this.DeckCard = new int[2];
      this.DeckChance = new int[2];
      this.AutoEvent = new int[2];
      this.AutoChance = new int[2];
      this.HandCard = new int[2];
      this.SubParts = new int[10];
      this.Designation = new int[10];
      this.DesignationSmall = new int[10];
      this.HisVarType = new int[1];
      this.HisVarValue = new int[1];
      this.HisVarNato = new int[1];
      this.HisVarSmall = new int[1];
      this.Name = "Empty Historical";
      this.Type = 1;
      this.SmallGfx = -1;
      this.CounterString = "";
      this.TempRegime = -1;
      this.NameCounter = 0;
      this.NameCounterBackup = -1;
      this.Fixed = false;
      this.People = -1;
      this.MaxPresent = -1;
      this.BattleGroup = 0;
      this.HisVarCount = -1;
      this.DeckCardCounter = -1;
      this.AutoEventCounter = -1;
      this.HandCardCounter = -1;
      this.OverdrawSpriteID = -1;
      this.CommanderSpriteID = -1;
      this.TempAttack = -1;
      this.TempDefend = -1;
      this.CommanderName = "";
      this.TempStance = -1;
      this.UseRomans = false;
      this.UseModelCounter = -1;
      this.PP = 0;
      this.Descript = "";
      this.Xp = 0;
      this.TempVar1 = 0;
      this.TempVar2 = 0;
      this.TempVar3 = 0;
      this.TempVar4 = 0;
      this.TempVar5 = 0;
      this.Model = false;
      this.Pool = false;
      this.ModelMaster = -1;
      this.UsePeopleGfx = -1;
      this.Red = 0;
      this.Green = 0;
      this.Blue = 0;
      int index = 0;
      do
      {
        this.SubParts[index] = -1;
        this.Designation[index] = -1;
        this.DesignationSmall[index] = -1;
        ++index;
      }
      while (index <= 9);
      this.PercentOldName = 0;
      this.LibId = new LibIdClass();
      this.OffLibId = new LibIdClass();
    }

    public void LoadSprites()
    {
      this.CommanderSpriteID = Operators.CompareString(this.CommanderFileName, "", false) == 0 ? -1 : BitmapStore.AddFile(this.CommanderFileName, false);
      if (Operators.CompareString(this.OverdrawFileName, "", false) != 0)
        this.OverdrawSpriteID = BitmapStore.AddFile(this.OverdrawFileName, false);
      else
        this.OverdrawSpriteID = -1;
    }

    public int GiveHisVarValue(int typ)
    {
      int hisVarCount = this.HisVarCount;
      for (int index = 0; index <= hisVarCount; ++index)
      {
        if (this.HisVarType[index] == typ)
          return this.HisVarValue[index];
      }
      return 0;
    }

    public void SetHisVarValue(int typ, int value, int smallGfx)
    {
      int hisVarCount = this.HisVarCount;
      for (int index = 0; index <= hisVarCount; ++index)
      {
        if (this.HisVarType[index] == typ)
        {
          this.HisVarValue[index] = value;
          this.HisVarSmall[index] = smallGfx;
          return;
        }
      }
      ++this.HisVarCount;
      this.HisVarNato = (int[]) Utils.CopyArray((Array) this.HisVarNato, (Array) new int[this.HisVarCount + 1]);
      this.HisVarSmall = (int[]) Utils.CopyArray((Array) this.HisVarSmall, (Array) new int[this.HisVarCount + 1]);
      this.HisVarType = (int[]) Utils.CopyArray((Array) this.HisVarType, (Array) new int[this.HisVarCount + 1]);
      this.HisVarValue = (int[]) Utils.CopyArray((Array) this.HisVarValue, (Array) new int[this.HisVarCount + 1]);
      this.HisVarType[this.HisVarCount] = typ;
      this.HisVarValue[this.HisVarCount] = value;
      this.HisVarNato[this.HisVarCount] = 0;
      this.HisVarSmall[this.HisVarCount] = smallGfx;
    }

    public void SetHisVarValue(int typ, int value)
    {
      int hisVarCount = this.HisVarCount;
      int index;
      for (index = 0; index <= hisVarCount; ++index)
      {
        if (this.HisVarType[index] == typ)
        {
          this.HisVarValue[index] = value;
          return;
        }
      }
      ++this.HisVarCount;
      this.HisVarNato = (int[]) Utils.CopyArray((Array) this.HisVarNato, (Array) new int[index + 1]);
      this.HisVarSmall = (int[]) Utils.CopyArray((Array) this.HisVarSmall, (Array) new int[index + 1]);
      this.HisVarType = (int[]) Utils.CopyArray((Array) this.HisVarType, (Array) new int[index + 1]);
      this.HisVarValue = (int[]) Utils.CopyArray((Array) this.HisVarValue, (Array) new int[index + 1]);
      this.HisVarType[this.HisVarCount] = typ;
      this.HisVarValue[this.HisVarCount] = value;
      this.HisVarNato[this.HisVarCount] = 0;
      this.HisVarSmall[this.HisVarCount] = -1;
    }

    public void ReplaceSprite1(string s)
    {
      if (Operators.CompareString(s, "", false) == 0)
      {
        this.CommanderFileName = "";
        if (this.CommanderSpriteID <= -1)
          return;
        BitmapStore.RemoveBitmapNr(this.CommanderSpriteID);
        this.CommanderSpriteID = -1;
      }
      else if (Operators.CompareString(this.CommanderFileName, "", false) == 0)
      {
        this.CommanderFileName = s;
        this.CommanderSpriteID = BitmapStore.AddFile(s, false);
      }
      else
      {
        this.CommanderFileName = s;
        this.CommanderSpriteID = BitmapStore.ReloadFile(this.CommanderSpriteID, this.CommanderFileName);
      }
    }

    public void ReplaceSprite2(string s2)
    {
      if (Operators.CompareString(s2, "", false) == 0)
      {
        this.OverdrawFileName = "";
        if (this.OverdrawSpriteID <= -1)
          return;
        BitmapStore.RemoveBitmapNr(this.OverdrawSpriteID);
        this.OverdrawSpriteID = -1;
      }
      else if (Operators.CompareString(this.OverdrawFileName, "", false) == 0)
      {
        this.OverdrawFileName = s2;
        this.OverdrawSpriteID = BitmapStore.AddFile(s2, false);
      }
      else
      {
        this.OverdrawFileName = s2;
        this.OverdrawSpriteID = BitmapStore.ReloadFile(this.OverdrawSpriteID, this.OverdrawFileName);
      }
    }

    public HistoricalUnitClass Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (HistoricalUnitClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }
  }
}
