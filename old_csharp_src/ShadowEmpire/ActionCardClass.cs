// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ActionCardClass
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
  public class ActionCardClass : ISerializable
  {
    public string Title;
    public int ColorScheme;
    public string Text;
    public string MouseOver;
    public int PPCost;
    public int ExecuteEvent;
    public int AILabel;
    public int AILabel2;
    public int aILabel3;
    public int EventPicNr;
    public int AlternateEventPicNr;
    public int TempVar0;
    public int TempVar1;
    public int AreaSlot;
    public int AreaValue;
    public int PreExecuteEvent;
    public bool UnitSelect;
    public int Nato;
    public int SmallGfx;
    public int HisVarCostType;
    public int HisVarCostQty;
    public int Category;
    public int LimitedShow;
    public LibIdClass LibId;
    public bool IgnorePopupIfNoSelect;
    public int quickButton;
    public int quickSmall;
    public int customCostType;
    public int customCostQty;

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Title", (object) this.Title);
      info.AddValue("ColorScheme", this.ColorScheme);
      info.AddValue("Text", (object) this.Text);
      info.AddValue("PPCost", this.PPCost);
      info.AddValue("ExecuteEvent", this.ExecuteEvent);
      info.AddValue("AILabel", this.AILabel);
      info.AddValue("AILabel2", this.AILabel2);
      info.AddValue("AILabel3", this.aILabel3);
      info.AddValue("EventPicNr", this.EventPicNr);
      info.AddValue("TempVar0", this.TempVar0);
      info.AddValue("TempVar1", this.TempVar1);
      info.AddValue("AreaSlot", this.AreaSlot);
      info.AddValue("AreaValue", this.AreaValue);
      info.AddValue("PreExecuteEvent", this.PreExecuteEvent);
      info.AddValue("UnitSelect", this.UnitSelect);
      info.AddValue("Nato", this.Nato);
      info.AddValue("MouseOver", (object) this.MouseOver);
      info.AddValue("HisVarCostType", this.HisVarCostType);
      info.AddValue("HisVarCostQty", this.HisVarCostQty);
      info.AddValue("Category", this.Category);
      info.AddValue("AlternateEventPicNr", this.AlternateEventPicNr);
      info.AddValue("LimitedShow", this.LimitedShow);
      info.AddValue("ourid", (object) this.LibId);
      info.AddValue("SmallGfx", this.SmallGfx);
      info.AddValue("IgnorePopupIfNoSelect", this.IgnorePopupIfNoSelect);
      info.AddValue("QuickSmall", this.quickSmall);
      info.AddValue("QuickButton", this.quickButton);
      info.AddValue("customCostType", this.customCostType);
      info.AddValue("customCostQty", this.customCostQty);
    }

    protected ActionCardClass(SerializationInfo info, StreamingContext context)
    {
      this.Title = info.GetString(nameof (Title));
      this.ColorScheme = info.GetInt32(nameof (ColorScheme));
      this.Text = info.GetString(nameof (Text));
      this.PPCost = info.GetInt32(nameof (PPCost));
      this.ExecuteEvent = info.GetInt32(nameof (ExecuteEvent));
      this.AILabel = info.GetInt32(nameof (AILabel));
      this.EventPicNr = info.GetInt32(nameof (EventPicNr));
      try
      {
        this.TempVar0 = info.GetInt32(nameof (TempVar0));
        this.TempVar1 = info.GetInt32(nameof (TempVar1));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.TempVar0 = -1;
        this.TempVar1 = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.AreaSlot = info.GetInt32(nameof (AreaSlot));
        this.AreaValue = info.GetInt32(nameof (AreaValue));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.AreaSlot = -1;
        this.AreaValue = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.PreExecuteEvent = info.GetInt32(nameof (PreExecuteEvent));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.PreExecuteEvent = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.UnitSelect = info.GetBoolean(nameof (UnitSelect));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.UnitSelect = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.Nato = info.GetInt32(nameof (Nato));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Nato = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.MouseOver = info.GetString(nameof (MouseOver));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.MouseOver = "";
        ProjectData.ClearProjectError();
      }
      try
      {
        this.HisVarCostType = info.GetInt32(nameof (HisVarCostType));
        this.HisVarCostQty = info.GetInt32(nameof (HisVarCostQty));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.HisVarCostQty = 0;
        this.HisVarCostType = -1;
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
        this.AlternateEventPicNr = info.GetInt32(nameof (AlternateEventPicNr));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.AlternateEventPicNr = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.LimitedShow = info.GetInt32(nameof (LimitedShow));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.LimitedShow = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.AILabel2 = info.GetInt32(nameof (AILabel2));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.AILabel2 = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.aILabel3 = info.GetInt32("AILabel3");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.aILabel3 = 0;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.LibId = new LibIdClass();
        this.LibId = (LibIdClass) info.GetValue("ourid", this.LibId.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.LibId = new LibIdClass();
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
        this.IgnorePopupIfNoSelect = info.GetBoolean(nameof (IgnorePopupIfNoSelect));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.IgnorePopupIfNoSelect = false;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.quickButton = info.GetInt32("QuickButton");
        this.quickSmall = info.GetInt32("QuickSmall");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.quickButton = 0;
        this.quickSmall = -1;
        ProjectData.ClearProjectError();
      }
      try
      {
        this.customCostType = info.GetInt32(nameof (customCostType));
        this.customCostQty = info.GetInt32(nameof (customCostQty));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.customCostType = 0;
        this.customCostQty = 0;
        ProjectData.ClearProjectError();
      }
    }

    public ActionCardClass()
    {
      this.Title = "Empty Historical";
      this.MouseOver = "";
      this.EventPicNr = -1;
      this.SmallGfx = -1;
      this.LibId = new LibIdClass();
      this.ColorScheme = 0;
      this.ExecuteEvent = -1;
      this.TempVar0 = -1;
      this.TempVar1 = -1;
      this.AILabel2 = 0;
      this.AreaSlot = -1;
      this.AreaValue = -1;
      this.PreExecuteEvent = -1;
      this.Nato = -1;
      this.HisVarCostQty = 0;
      this.HisVarCostType = -1;
      this.Category = -1;
      this.quickSmall = -1;
      this.quickButton = 0;
      this.customCostQty = 0;
      this.customCostType = 0;
    }

    public ActionCardClass Clone()
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this);
      serializationStream.Position = 0L;
      return (ActionCardClass) binaryFormatter.Deserialize((Stream) serializationStream);
    }
  }
}
