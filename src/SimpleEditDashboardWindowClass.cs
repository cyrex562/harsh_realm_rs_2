// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleEditDashboardWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class SimpleEditDashboardWindowClass : WindowClass
  {
    private int listId;
    private ListClass listObj;
    private int loadMapId;
    private int exportMapId;
    private int setdateid;
    private int exportid;
    private int setdescriptid;
    private int setnameid;
    private int setdesignid;
    private int loadMapIdB;
    private int saveId;
    private int textId;
    private int text2id;
    private int text3id;
    private int detailnr;
    private int currentStep;

    public SimpleEditDashboardWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 50, 9, tDoBorders: 1, tHeaderString: "Dashboard")
    {
      this.detailnr = -1;
      this.DoStuff();
    }

    public void PopUpRefresh() => this.DoStuff();

    public void DoStuff()
    {
      int val1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      if (this.listId > 0)
        this.RemoveSubPart(this.listId);
      if (this.loadMapId > 0)
        this.RemoveSubPart(this.loadMapId);
      if (this.exportMapId > 0)
        this.RemoveSubPart(this.exportMapId);
      if (this.setdateid > 0)
        this.RemoveSubPart(this.setdateid);
      if (this.loadMapIdB > 0)
        this.RemoveSubPart(this.loadMapIdB);
      if (this.textId > 0)
        this.RemoveSubPart(this.textId);
      if (this.text2id > 0)
        this.RemoveSubPart(this.text2id);
      if (this.text3id > 0)
        this.RemoveSubPart(this.text3id);
      if (this.saveId > 0)
        this.RemoveSubPart(this.saveId);
      if (this.setnameid > 0)
        this.RemoveSubPart(this.setnameid);
      if (this.setdescriptid > 0)
        this.RemoveSubPart(this.setdescriptid);
      if (this.setdesignid > 0)
        this.RemoveSubPart(this.setdesignid);
      if (this.exportid > 0)
        this.RemoveSubPart(this.exportid);
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.TextContrast = 1;
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 50, -1);
      this.listObj = new ListClass();
      this.currentStep = 0;
      this.listObj.add("CHECKLIST ITEM", 0, "IS SET?", "DETAILS");
      if (Information.IsNothing((object) this.game.Data.RuleSetName))
        this.game.Data.RuleSetName = "";
      string ruleSetName = this.game.Data.RuleSetName;
      string str = this.game.Data.scenarioVersionMaster.Length <= 0 ? ruleSetName + " (base version)" : ruleSetName + " (version " + this.game.Data.scenarioVersionMaster + ")";
      if (this.game.Data.RuleSetName.Length > 0)
      {
        this.listObj.add("Ruleset and Master", 1, "set", str);
        if (this.currentStep == 0)
          this.currentStep = 1;
      }
      else
        this.listObj.add("Ruleset and Master", 1, "not set", str);
      if (this.game.Data.MapObj[0].MapWidth == 0 | this.game.Data.MapObj[0].MapHeight == 0)
      {
        this.listObj.add("Map", 2, "not set", "Map:" + this.game.Data.MapObj[0].MapWidth.ToString() + "x" + this.game.Data.MapObj[0].MapHeight.ToString());
      }
      else
      {
        this.listObj.add("Map", 2, "set", "Map:" + this.game.Data.MapObj[0].MapWidth.ToString() + "x" + this.game.Data.MapObj[0].MapHeight.ToString());
        if (this.currentStep == 1)
          this.currentStep = 2;
      }
      int num1 = 0;
      int sfTypeCounter = this.game.Data.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter; ++index)
      {
        if (!this.game.Data.SFTypeObj[index].DontShowInList)
          ++num1;
      }
      if (num1 > 0)
      {
        this.listObj.add("Equipment&Troops Library", 3, "set", "SFTypes:" + num1.ToString());
        if (this.currentStep == 2)
          this.currentStep = 3;
      }
      else
        this.listObj.add("Equipment&Troops Library", 3, "not set", "SFTypes:" + num1.ToString());
      if (this.game.Data.HistoricalUnitCounter > -1)
      {
        this.listObj.add("Historical Library", 4, "set", "HisUnits:" + (this.game.Data.HistoricalUnitCounter + 1).ToString());
        if (this.currentStep == 3)
          this.currentStep = 4;
      }
      else
        this.listObj.add("Historical Library", 4, "not set", "HisUnits:" + (this.game.Data.HistoricalUnitCounter + 1).ToString());
      if (this.game.Data.StartData.Year > 1 & this.game.Data.AlternateRound > 0)
      {
        this.listObj.add("Start Date & round length", 5, "set", this.game.Data.StartData.Day.ToString() + "/" + this.game.Data.StartData.Month.ToString() + "/" + this.game.Data.StartData.Year.ToString() + " +d" + this.game.Data.AlternateRound.ToString());
        if (this.currentStep == 4)
          this.currentStep = 5;
      }
      else if (this.game.Data.StartData.Year > 1 & this.game.Data.AlternateRound2 > 0)
      {
        this.listObj.add("Start Date & round length", 5, "set", this.game.Data.StartData.Day.ToString() + "/" + this.game.Data.StartData.Month.ToString() + "/" + this.game.Data.StartData.Year.ToString() + " " + this.game.Data.StartData.Hour.ToString() + ":00 +h" + this.game.Data.AlternateRound2.ToString());
        if (this.currentStep == 4)
          this.currentStep = 5;
      }
      else
        this.listObj.add("Start Date & round length", 5, "not set");
      if (Operators.CompareString(this.game.Data.Name, "New Scenario", false) != 0 & Operators.CompareString(this.game.Data.Designer, "", false) != 0 & Operators.CompareString(this.game.Data.Description, "This is a blank scenario.", false) != 0)
      {
        this.listObj.add("Scenario Title,Descr,Designer", 6, "set", this.game.Data.Name);
        if (this.currentStep == 5)
          this.currentStep = 6;
      }
      else
        this.listObj.add("Scenario Title,Descr,Designer", 6, "not set");
      int num2 = 0;
      int regimeCounter = this.game.Data.RegimeCounter;
      for (int index1 = 0; index1 <= regimeCounter; ++index1)
      {
        bool flag = false;
        int unitCounter = this.game.Data.UnitCounter;
        for (int index2 = 0; index2 <= unitCounter; ++index2)
        {
          if (this.game.Data.UnitObj[index2].IsHQ & this.game.Data.UnitObj[index2].PreDef == -1 & this.game.Data.UnitObj[index2].X > -1)
            flag = true;
        }
        if (flag)
          ++num2;
      }
      if (num2 >= 2)
      {
        this.listObj.add("2 regimes or more with HQs on map ", 7, "set", num2.ToString());
        if (this.currentStep == 6)
          this.currentStep = 7;
      }
      else
        this.listObj.add("2 regimes or more with HQs on map", 7, "not set", num2.ToString());
      int num3 = 0;
      int num4 = 0;
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index3 = 0; index3 <= mapWidth; ++index3)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index4 = 0; index4 <= mapHeight; ++index4)
        {
          if (this.game.Data.MapObj[0].HexObj[index3, index4].VP > 0)
          {
            ++num3;
            num4 += this.game.Data.MapObj[0].HexObj[index3, index4].VP;
          }
        }
      }
      if (num3 >= 1)
      {
        this.listObj.add("Victory Points on map ", 8, "set", num3.ToString() + "(" + num4.ToString() + ")");
        if (this.currentStep == 7)
          this.currentStep = 8;
      }
      else
        this.listObj.add("Victory Points on map", 8, "not set", num3.ToString());
      int index5 = -1;
      int eventCounter1 = this.game.Data.EventCounter;
      for (int index6 = 0; index6 <= eventCounter1; ++index6)
      {
        int commandCounter = this.game.Data.EventObj[index6].CommandCounter;
        for (int index7 = 0; index7 <= commandCounter; ++index7)
        {
          if (this.game.Data.EventObj[index6].CommandList[index7].type == 3 && Conversions.ToDouble(this.game.Data.EventObj[index6].CommandList[index7].Data[0, 1]) == 30.0)
            index5 = index6;
        }
      }
      if (index5 > -1)
      {
        this.listObj.add("Supply event present", 9, "set", "Event: '" + this.game.Data.EventObj[index5].Name + "'");
        if (this.currentStep == 8)
          this.currentStep = 9;
      }
      else
        this.listObj.add("Supply event present", 9, "not set");
      int index8 = -1;
      int eventCounter2 = this.game.Data.EventCounter;
      for (int index9 = 0; index9 <= eventCounter2; ++index9)
      {
        int commandCounter = this.game.Data.EventObj[index9].CommandCounter;
        for (int index10 = 0; index10 <= commandCounter; ++index10)
        {
          if (this.game.Data.EventObj[index9].CommandList[index10].type == 3 && Conversions.ToDouble(this.game.Data.EventObj[index9].CommandList[index10].Data[0, 1]) == 4.0)
            index8 = index9;
        }
      }
      if (index8 > -1)
      {
        this.listObj.add("Victory event present", 10, "set", "Event: '" + this.game.Data.EventObj[index8].Name + "'");
        if (this.currentStep == 9)
          this.currentStep = 10;
      }
      else
        this.listObj.add("Victory event present", 10, "not set");
      if (0 > -1)
      {
        this.listObj.add("Distribute ready?", 11, "Yes");
        if (this.currentStep == 10)
          this.currentStep = 10;
      }
      else
        this.listObj.add("Distribute ready?", 11, "Don't think so");
      if (this.detailnr == -1)
        this.detailnr = this.currentStep + 1;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(this.listObj, 18, 500 + Math.Max(0, val1 - 50), this.detailnr, this.game, true, "Checklist", false, tShowPair: true, tValueWidth: ((int) Math.Round(260.0 + (double) val1 * 0.8)), tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: (10 + Math.Min(val1, 50)), bby: 72, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
      this.listId = this.AddSubPart(ref tsubpart, 10 + Math.Min(val1, 50), 72, 500 + Math.Max(0, val1 - 50), 504, 0);
      tsubpart = (SubPartClass) new TextButtonPartClass("Save Scenario", 180, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 10), bby: 588, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.saveId = this.AddSubPart(ref tsubpart, val1 + 10, 588, 180, 35, 1);
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Saving also refreshes units rdn,ap,entr, etc.. Save before you play.", this.game.MarcFont4, val1 + 10, 628, Color.White);
      int num5 = this.detailnr - 1;
      if (num5 == 0)
      {
        str = "Changing the Ruleset is not allowed. But the Master will be reloaded every time this scenario is loaded. Or can be manually reloaded through the 'debug tab'.";
        DrawMod.DrawTextColouredMarc(ref objgraphics, "Step 0: Ruleset", this.game.MarcFont1, val1 + 580, 70, Color.White);
        tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, str, 27, ref this.OwnBitmap, val1 + 570, 100, true, true);
        this.textId = this.AddSubPart(ref tsubpart, val1 + 570, 100, 450, 108, 0);
      }
      if (num5 == 1)
      {
        if (this.currentStep > num5)
        {
          string tText1 = "You already have a Map loaded. This step has been completed.";
          DrawMod.DrawTextColouredMarc(ref objgraphics, "Step 1: Load Map", this.game.MarcFont1, val1 + 580, 70, Color.White);
          tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, tText1, 27, ref this.OwnBitmap, val1 + 570, 100, true, true);
          this.textId = this.AddSubPart(ref tsubpart, val1 + 570, 100, 450, 108, 0);
          tsubpart = (SubPartClass) new TextButtonPartClass("Reload Map", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 580), bby: 200, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.loadMapId = this.AddSubPart(ref tsubpart, val1 + 580, 240, 140, 35, 1);
          string tText2 = this.game.Data.MapName + ", version " + this.game.Data.MapVersion.ToString();
          DrawMod.DrawTextColouredMarc(ref objgraphics, "Map name and version", this.game.MarcFont1, val1 + 580, 320, Color.White);
          tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 2, this.game.MarcFont3, tText2, 27, ref this.OwnBitmap, val1 + 570, 320, true, true);
          this.text2id = this.AddSubPart(ref tsubpart, val1 + 570, 320, 450, 54, 0);
          str = this.game.Data.MapDesigner;
          DrawMod.DrawTextColouredMarc(ref objgraphics, "Map designer", this.game.MarcFont1, val1 + 580, 420, Color.White);
          tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 2, this.game.MarcFont3, str, 27, ref this.OwnBitmap, val1 + 570, 420, true, true);
          this.text3id = this.AddSubPart(ref tsubpart, val1 + 570, 420, 450, 54, 0);
        }
        else
        {
          str = "Please select a Map compatible with the chosen ruleset.";
          DrawMod.DrawTextColouredMarc(ref objgraphics, "Step 1: Load Map", this.game.MarcFont1, val1 + 580, 70, Color.White);
          tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, str, 27, ref this.OwnBitmap, val1 + 570, 100, true, true);
          this.textId = this.AddSubPart(ref tsubpart, val1 + 570, 100, 450, 108, 0);
          tsubpart = (SubPartClass) new TextButtonPartClass("Load Map", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 580), bby: 200, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.loadMapId = this.AddSubPart(ref tsubpart, val1 + 580, 240, 140, 35, 1);
        }
      }
      if (num5 == 2)
      {
        str = this.currentStep <= num5 ? "There is no Equipment&Troops Library loaded at the moment. Please go the library section and import at least one Equipment&Troops Library compatible with the chosen ruleset." : "You have already loaded one or more Equipment&Troops Libraries, but you can always load more or remove some.";
        DrawMod.DrawTextColouredMarc(ref objgraphics, "Step 2: Load Equipment", this.game.MarcFont1, val1 + 580, 70, Color.White);
        tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, str, 27, ref this.OwnBitmap, val1 + 570, 100, true, true);
        this.textId = this.AddSubPart(ref tsubpart, val1 + 570, 100, 450, 108, 0);
      }
      if (num5 == 3)
      {
        str = this.currentStep <= num5 ? "There is no Historical Library loaded at the moment. Please go the library section and import at least one Historical Library compatible with the chosen ruleset." : "You have already loaded one or more Historical Libraries, but you can always load more or remove some.";
        DrawMod.DrawTextColouredMarc(ref objgraphics, "Step 3: Load Historicals", this.game.MarcFont1, val1 + 580, 70, Color.White);
        tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, str, 27, ref this.OwnBitmap, val1 + 570, 100, true, true);
        this.textId = this.AddSubPart(ref tsubpart, val1 + 570, 100, 450, 108, 0);
      }
      if (num5 == 4)
      {
        if (this.currentStep > num5)
        {
          if (this.game.Data.AlternateRound > 0)
            str = "Current date for the first round is: '" + this.game.Data.StartData.ToString() + "'. And every round lasts " + this.game.Data.AlternateRound.ToString() + " days. Please feel free to change it.";
          else if (this.game.Data.AlternateRound2 > 0)
            str = "Current date for the first round is: '" + this.game.Data.StartData.ToString() + "'. And every round lasts " + this.game.Data.AlternateRound2.ToString() + " hours. Please feel free to change it.";
        }
        else
          str = "Pease specify a date for the first round.";
        tsubpart = (SubPartClass) new TextButtonPartClass("Set Date", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 580), bby: 280, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.setdateid = this.AddSubPart(ref tsubpart, val1 + 580, 280, 140, 35, 1);
        DrawMod.DrawTextColouredMarc(ref objgraphics, "Step 4: Set start date & round length", this.game.MarcFont1, val1 + 580, 70, Color.White);
        tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, str, 27, ref this.OwnBitmap, val1 + 570, 100, true, true);
        this.textId = this.AddSubPart(ref tsubpart, val1 + 570, 100, 450, 108, 0);
      }
      if (num5 == 5)
      {
        string description = this.game.Data.Description;
        tsubpart = (SubPartClass) new TextButtonPartClass("Change Name", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 580), bby: 140, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.setnameid = this.AddSubPart(ref tsubpart, val1 + 580, 140, 140, 35, 1);
        tsubpart = (SubPartClass) new TextButtonPartClass("Change Descript", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 580), bby: 580, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.setdescriptid = this.AddSubPart(ref tsubpart, val1 + 580, 580, 140, 35, 1);
        tsubpart = (SubPartClass) new TextButtonPartClass("Change Designer", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 580), bby: 300, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.setdesignid = this.AddSubPart(ref tsubpart, val1 + 580, 300, 140, 35, 1);
        DrawMod.DrawTextColouredMarc(ref objgraphics, "Step 5a: Set scenario name", this.game.MarcFont1, val1 + 580, 70, Color.White);
        DrawMod.DrawTextColouredMarc(ref objgraphics, this.game.Data.Name, this.game.MarcFont3, val1 + 580, 110, Color.White);
        DrawMod.DrawTextColouredMarc(ref objgraphics, "Step 5b: Set scenario designer", this.game.MarcFont1, val1 + 580, 230, Color.White);
        if (this.game.Data.Designer.Length > 0)
          DrawMod.DrawTextColouredMarc(ref objgraphics, this.game.Data.Designer, this.game.MarcFont3, val1 + 580, 270, Color.White);
        else
          DrawMod.DrawTextColouredMarc(ref objgraphics, "-Nobody specified-", this.game.MarcFont3, val1 + 580, 270, Color.White);
        DrawMod.DrawTextColouredMarc(ref objgraphics, "Step 5c: Set scenario descript", this.game.MarcFont1, val1 + 580, 390, Color.White);
        tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 4, this.game.MarcFont4, description, 27, ref this.OwnBitmap, val1 + 570, 410);
        this.textId = this.AddSubPart(ref tsubpart, val1 + 570, 410, 450, 108, 0);
      }
      if (num5 == 6)
      {
        string tText = this.currentStep <= num5 ? "Make sure you have loaded a map with regimes defined if you are missing regimes. Make sure you have put some units on the map for each side otherwise. You need to have HQ for each side in order to receive replacement troops and supplies." : "You have at least 2 regimes with a HQ on the map. All set here. ";
        DrawMod.DrawTextColouredMarc(ref objgraphics, "Step 6: Minimal 2 regimes with a HQ on map", this.game.MarcFont1, val1 + 580, 70, Color.White);
        tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, tText, 27, ref this.OwnBitmap, val1 + 570, 100, true, true);
        this.textId = this.AddSubPart(ref tsubpart, val1 + 570, 100, 450, 108, 0);
      }
      if (num5 == 7)
      {
        string tText = this.currentStep <= num5 ? "You need to put some victory points on some hexes on the map." : "You have at least 1 Victory Point set. Make sure you have enough different ones defined to make the AI able to handle it self. Around 1 VP every 64 hexes would be around optimal. Keep in mind that the AI can have different behaviour based on the number of VP on a hex. ";
        DrawMod.DrawTextColouredMarc(ref objgraphics, "Step 7: Victory Points on the map", this.game.MarcFont1, val1 + 580, 70, Color.White);
        tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 8, this.game.MarcFont3, tText, 27, ref this.OwnBitmap, val1 + 570, 100, true, true);
        this.textId = this.AddSubPart(ref tsubpart, val1 + 570, 100, 450, 216, 0);
      }
      if (num5 == 8)
      {
        string tText = this.currentStep <= num5 ? "You need to load a library that includes a supply event. Without supply being delivered to your units this scenario will probably not function as intended." : "Altough a Supply event has been loaded you have to make sure you set the propper input for it in stringlists or libvars in order for it to function properly.";
        DrawMod.DrawTextColouredMarc(ref objgraphics, "Step 8: Supply event present", this.game.MarcFont1, val1 + 580, 70, Color.White);
        tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, tText, 27, ref this.OwnBitmap, val1 + 570, 100, true, true);
        this.textId = this.AddSubPart(ref tsubpart, val1 + 570, 100, 450, 108, 0);
      }
      if (num5 == 9)
      {
        string tText = this.currentStep <= num5 ? "You need to load a library that includes a victory event. Without a victory event being set this scenario will probably be unable to end in victory for any player." : "Altough a Victory event has been loaded you have to make sure you set the propper input for it in stringlists or libvars in order for it to function properly.";
        DrawMod.DrawTextColouredMarc(ref objgraphics, "Step 9: Victory event present", this.game.MarcFont1, val1 + 580, 70, Color.White);
        tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, tText, 27, ref this.OwnBitmap, val1 + 570, 100, true, true);
        this.textId = this.AddSubPart(ref tsubpart, val1 + 570, 100, 450, 108, 0);
      }
      if (num5 != 10)
        return;
      string tText3 = (this.currentStep < num5 ? "There are still some steps that test negative. This might be intended, but my advice is to make sure all steps above are set before distributing." : "Your scenario seems to be ready for distribution. Make sure all the events run well and its play-tested before sharing with others.") + "\r\n" + "\r\n" + "1. Before exporting. Make sure all your custom graphics are in their own custom directories directly under the graphics/ directory and not in the graphics/community or graphics/communitymodgraphics or graphics/systemgraphics directories." + "\r\n" + "\r\n" + "2. Optional. You can add a few custom files like .pdf or .txt as you see fit.. A readme.txt file if included will be presented to the end-user when he imports the zip. Have your list of extra files ready. " + "\r\n" + "\r\n" + "3. Optional. Make a check if you have used any music or sounds that are not installed by default. If so you should have the name of your sound directory ready; which should be directly under graphics/communitysounds/ and should not have any further subdirectories." + "\r\n" + "\r\n" + "4. Ok press the export button below!";
      tsubpart = (SubPartClass) new TextButtonPartClass("Export .dczip", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 580), bby: 620, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.exportid = this.AddSubPart(ref tsubpart, val1 + 580, 620, 140, 35, 1);
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Distributing your scenario", this.game.MarcFont1, val1 + 580, 70, Color.White);
      tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 24, this.game.MarcFont3, tText3, 19, ref this.OwnBitmap, val1 + 570, 100, true, true);
      this.textId = this.AddSubPart(ref tsubpart, val1 + 570, 100, 450, 456, 0);
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num1 = this.SubPartID[index];
            if (num1 == this.listId)
            {
              this.detailnr = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              if (this.detailnr < 1)
                this.detailnr = 1;
              this.DoStuff();
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.setnameid)
            {
              this.game.Data.Name = Interaction.InputBox("Give new scenario name", "Shadow Empire : Planetary Conquest");
              this.DoStuff();
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.setdescriptid)
            {
              new Form2((Form) this.formref).Initialize(this.game.Data, 2, -1);
              return windowReturnClass;
            }
            if (num1 == this.setdesignid)
            {
              this.game.Data.Designer = Interaction.InputBox("Give designer name", "Shadow Empire : Planetary Conquest");
              this.DoStuff();
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.setdateid)
            {
              if (Interaction.MsgBox((object) "Use the normal days system for rounds? (yes = use days, no = use hours)", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
              {
                string str1 = Interaction.InputBox("Give new Day (1-31).", "Shadow Empire : Planetary Conquest");
                if (Conversions.ToInteger(str1) >= 1 & Conversions.ToInteger(str1) <= 31)
                {
                  int integer1 = Conversions.ToInteger(str1);
                  string str2 = Interaction.InputBox("Give new Month (1-12).", "Shadow Empire : Planetary Conquest");
                  if (Conversions.ToInteger(str2) >= 1 & Conversions.ToInteger(str2) <= 12)
                  {
                    int integer2 = Conversions.ToInteger(str2);
                    string str3 = Interaction.InputBox("Give new Year (2-9999).", "Shadow Empire : Planetary Conquest");
                    if (Conversions.ToInteger(str3) >= 2 & Conversions.ToInteger(str3) <= 9999)
                    {
                      int integer3 = Conversions.ToInteger(str3);
                      string str4 = Interaction.InputBox("Give new round length in days (1-999).", "Shadow Empire : Planetary Conquest");
                      if (Conversions.ToInteger(str4) >= 1 & Conversions.ToInteger(str4) <= 9999)
                      {
                        int integer4 = Conversions.ToInteger(str4);
                        this.game.Data.StartData = new DateTime(integer3, integer2, integer1);
                        this.game.Data.AlternateRound2 = -1;
                        this.game.Data.AlternateRound = integer4;
                      }
                      else
                      {
                        int num2 = (int) Interaction.MsgBox((object) "Sorry. Invalid round length.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                    }
                    else
                    {
                      int num3 = (int) Interaction.MsgBox((object) "Sorry. Invalid year.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                  }
                  else
                  {
                    int num4 = (int) Interaction.MsgBox((object) "Sorry. Invalid month.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                }
                else
                {
                  int num5 = (int) Interaction.MsgBox((object) "Sorry. Invalid day of the month.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
              }
              else
              {
                string str5 = Interaction.InputBox("Give new Day (1-31).", "Shadow Empire : Planetary Conquest");
                if (Conversions.ToInteger(str5) >= 1 & Conversions.ToInteger(str5) <= 31)
                {
                  int integer5 = Conversions.ToInteger(str5);
                  string str6 = Interaction.InputBox("Give new Month (1-12).", "Shadow Empire : Planetary Conquest");
                  if (Conversions.ToInteger(str6) >= 1 & Conversions.ToInteger(str6) <= 12)
                  {
                    int integer6 = Conversions.ToInteger(str6);
                    string str7 = Interaction.InputBox("Give new Year (2-9999).", "Shadow Empire : Planetary Conquest");
                    if (Conversions.ToInteger(str7) >= 2 & Conversions.ToInteger(str7) <= 9999)
                    {
                      int integer7 = Conversions.ToInteger(str7);
                      string str8 = Interaction.InputBox("Give new Hour (1-24).", "Shadow Empire : Planetary Conquest");
                      if (Conversions.ToInteger(str8) >= 1 & Conversions.ToInteger(str8) <= 24)
                      {
                        int integer8 = Conversions.ToInteger(str8);
                        string str9 = Interaction.InputBox("Give new round length in hours (1-12).", "Shadow Empire : Planetary Conquest");
                        if (Conversions.ToInteger(str9) >= 1 & Conversions.ToInteger(str9) <= 12)
                        {
                          int integer9 = Conversions.ToInteger(str9);
                          this.game.Data.StartData = new DateTime(integer7, integer6, integer5, integer8, 0, 0);
                          this.game.Data.AlternateRound = -1;
                          this.game.Data.AlternateRound2 = integer9;
                        }
                        else
                        {
                          int num6 = (int) Interaction.MsgBox((object) "Sorry. Invalid round length.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        }
                      }
                      else
                      {
                        int num7 = (int) Interaction.MsgBox((object) "Sorry. Invalid hour.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                    }
                    else
                    {
                      int num8 = (int) Interaction.MsgBox((object) "Sorry. Invalid year.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                  }
                  else
                  {
                    int num9 = (int) Interaction.MsgBox((object) "Sorry. Invalid month.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                }
                else
                {
                  int num10 = (int) Interaction.MsgBox((object) "Sorry. Invalid day of the month.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.saveId)
            {
              string tinitdir;
              if (this.game.Data.Round == 0)
              {
                tinitdir = this.game.AppPath + "scenarios\\";
                if (!Information.IsNothing((object) this.game.Data.ScenarioDir))
                {
                  if (this.game.Data.ScenarioDir.Length > 1)
                    tinitdir = tinitdir.Replace("scenarios", this.game.Data.ScenarioDir);
                  else if (this.game.ModScenarioDir.Length > 1)
                    tinitdir = tinitdir.Replace("scenarios", this.game.ModScenarioDir);
                }
                else if (this.game.ModScenarioDir.Length > 1)
                  tinitdir = tinitdir.Replace("scenarios", this.game.ModScenarioDir);
              }
              else
                tinitdir = "savedgames";
              string str = this.game.Data.Round != 0 ? this.game.HandyFunctionsObj.SaveSomething("SE1 Scenario file (*.se1)|*.se1", "Give save name...", tinitdir, false) : this.game.HandyFunctionsObj.SaveSomething("SE1 Scenario file (*.se1)|*.se1", "Give save name...", tinitdir, false);
              if (Strings.Len(str) >= 2)
              {
                this.game.FormRef.Cursor = Cursors.WaitCursor;
                this.game.HandyFunctionsObj.SetAllReady(false);
                this.game.Data.serialize(str);
                this.game.HandyFunctionsObj.ZipFile(str);
                windowReturnClass.SetFlag(true);
                this.game.FormRef.Cursor = Cursors.Default;
                int num11 = (int) Interaction.MsgBox((object) "Saved", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
            }
            else
            {
              if (num1 == -870624953)
              {
                string str = this.game.HandyFunctionsObj.LoadSomething("SE1 Map file(*.se1map)|*.se1map", "Pick a map to load...", this.game.AppPath + this.game.ModScenarioDir, false);
                this.game.FormRef.Cursor = Cursors.WaitCursor;
                bool flag = File.Exists(str) && (!(this.game.Data.MapObj[0].MapWidth == 0 | this.game.Data.MapObj[0].MapHeight == 0) ? this.game.HandyFunctionsObj.LoadMap(str, true, true) : this.game.HandyFunctionsObj.LoadMap(str, true));
                this.game.FormRef.Cursor = Cursors.Default;
                if (flag)
                {
                  int num12 = (int) Interaction.MsgBox((object) "Loaded map", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                {
                  int num13 = (int) Interaction.MsgBox((object) "Error while loading map", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.detailnr = -1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.loadMapId)
              {
                string path = this.game.HandyFunctionsObj.LoadSomething("SE1 Map file(*.se1map)|*.se1map", "Pick a map to load...", this.game.AppPath + this.game.ModScenarioDir, false);
                if (File.Exists(path))
                {
                  this.game.EditObj.TempFileName = path;
                  this.game.EditObj.PopupValue = 18;
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass.AddCommand(5, 10);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                int num14 = (int) Interaction.MsgBox((object) "Could not find file", Title: ((object) "Shadow Empire : Planetary Conquest"));
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.exportid)
              {
                this.game.HandyFunctionsObj.ExportSimpleEditor();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }
  }
}
