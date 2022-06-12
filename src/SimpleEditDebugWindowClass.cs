// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleEditDebugWindowClass
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
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class SimpleEditDebugWindowClass : WindowClass
  {
    private int listId;
    private ListClass listObj;
    private int textId;
    private int text2id;
    private int text3id;
    private int detailnr;
    private int opt4id;
    private int powId;
    private int opt3id;
    private int opt1id;
    private int opt2id;
    private int opt1bid;
    private int outputid;
    private int fuelId;
    private int text4id;
    private int text5id;
    private int opt5id;
    private bool outputFixedSys;
    private string output;

    public SimpleEditDebugWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 50, 9, tDoBorders: 1, tHeaderString: "Debug Options")
    {
      this.detailnr = -1;
      this.DoStuff();
    }

    public void PopUpRefresh() => this.DoStuff();

    public void DoStuff()
    {
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      if (this.fuelId > 0)
        this.RemoveSubPart(this.fuelId);
      if (this.opt1id > 0)
        this.RemoveSubPart(this.opt1id);
      if (this.opt2id > 0)
        this.RemoveSubPart(this.opt2id);
      if (this.opt3id > 0)
        this.RemoveSubPart(this.opt3id);
      if (this.opt4id > 0)
        this.RemoveSubPart(this.opt4id);
      if (this.opt5id > 0)
        this.RemoveSubPart(this.opt5id);
      if (this.textId > 0)
        this.RemoveSubPart(this.textId);
      if (this.text2id > 0)
        this.RemoveSubPart(this.text2id);
      if (this.text3id > 0)
        this.RemoveSubPart(this.text3id);
      if (this.text4id > 0)
        this.RemoveSubPart(this.text4id);
      if (this.text5id > 0)
        this.RemoveSubPart(this.text5id);
      if (this.outputid > 0)
        this.RemoveSubPart(this.outputid);
      if (this.powId > 0)
        this.RemoveSubPart(this.powId);
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.TextContrast = 1;
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 50, -1);
      int y1 = 50;
      string tText1 = "Run this correction algorithm to remove any unassigned duplicate officers. ";
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Duplicates", this.game.MarcFont1, num1 + 25, y1, Color.White);
      int num2 = y1 + 0;
      SubPartClass tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, tText1, 27, ref this.OwnBitmap, num1 + 10, num2, true, true);
      this.text2id = this.AddSubPart(ref tsubpart, num1 + 10, num2, 450, 108, 0);
      int num3 = num2 + 100;
      tsubpart = (SubPartClass) new TextButtonPartClass("Check problems", 160, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.opt1id = this.AddSubPart(ref tsubpart, num1 + 25, num3, 160, 35, 1);
      tsubpart = (SubPartClass) new TextButtonPartClass("Remove problems", 160, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 180 + 25), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.opt1bid = this.AddSubPart(ref tsubpart, num1 + 180 + 25, num3, 160, 35, 1);
      int y2 = num3 + 50;
      string tText2 = "Run these algorithms to obtain specific diagnostics. ";
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Diagnostics", this.game.MarcFont1, num1 + 25, y2, Color.White);
      int num4 = y2 + 0;
      tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, tText2, 27, ref this.OwnBitmap, num1 + 10, num4, true, true);
      this.text2id = this.AddSubPart(ref tsubpart, num1 + 10, num4, 450, 108, 0);
      int num5 = num4 + 70;
      tsubpart = (SubPartClass) new TextButtonPartClass("TroopType Libs", 160, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25), bby: num5, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.opt2id = this.AddSubPart(ref tsubpart, num1 + 25, num5, 160, 35, 1);
      tsubpart = (SubPartClass) new TextButtonPartClass("Memory Use", 160, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 180), bby: num5, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.opt4id = this.AddSubPart(ref tsubpart, num1 + 25 + 180, num5, 160, 35, 1);
      int num6 = num5 + 50;
      tsubpart = (SubPartClass) new TextButtonPartClass("Supply/Fuel Prog.", 160, "Get a prognosis", ref this.OwnBitmap, num1 + 25, num6, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.fuelId = this.AddSubPart(ref tsubpart, num1 + 25, num6, 160, 35, 1);
      tsubpart = (SubPartClass) new TextButtonPartClass("Power Pts", 160, "Get a tally", ref this.OwnBitmap, num1 + 25 + 180, num6, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.powId = this.AddSubPart(ref tsubpart, num1 + 25 + 180, num6, 160, 35, 1);
      int y3 = num6 + 50;
      string tText3 = "Press these buttons to re-connect a masterfile. ";
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Masterfile reconnect", this.game.MarcFont1, num1 + 25, y3, Color.White);
      int num7 = y3 + 0;
      tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, tText3, 27, ref this.OwnBitmap, num1 + 10, num7, true, true);
      this.text3id = this.AddSubPart(ref tsubpart, num1 + 10, num7, 450, 108, 0);
      int num8 = num7 + 70;
      tsubpart = (SubPartClass) new TextButtonPartClass("VR Master", 160, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25), bby: num8, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.opt3id = this.AddSubPart(ref tsubpart, num1 + 25, num8, 160, 35, 1);
      int y4 = num8 + 50;
      string tText4 = "Use these buttons with caution! ";
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Batch Scripts", this.game.MarcFont1, num1 + 25, y4, Color.White);
      int num9 = y4 + 0;
      tsubpart = (SubPartClass) new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, tText4, 27, ref this.OwnBitmap, num1 + 10, num9, true, true);
      this.text3id = this.AddSubPart(ref tsubpart, num1 + 10, num9, 450, 108, 0);
      int num10 = num9 + 70;
      tsubpart = (SubPartClass) new TextButtonPartClass("Mass Move Units", 160, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25), bby: num10, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.opt5id = this.AddSubPart(ref tsubpart, num1 + 25, num10, 160, 35, 1);
      string str = this.output;
      DrawMod.DrawTextColouredMarc(ref objgraphics, "CONSOLE", this.game.MarcFont4, 510 + num1, 70, Color.White);
      if (Operators.CompareString(str, "", false) == 0)
        str = "No output... run a debug function to receive output.";
      if (this.outputFixedSys)
      {
        tsubpart = (SubPartClass) new TextAreaClass2(this.game, (int) Math.Round(Math.Min(800.0, (double) this.game.ScreenWidth / 2.0 - 50.0)), (int) Math.Round((double) Math.Max(120, this.game.ScreenHeight - 260) / 27.0), this.game.MarcFont4b, str, 27, ref this.OwnBitmap, 510 + num1, 80, tDarkerFrame: true);
        this.outputid = this.AddSubPart(ref tsubpart, 510 + num1, 80, (int) Math.Round(Math.Min(800.0, (double) this.game.ScreenWidth / 2.0 - 50.0)), Math.Max(120, this.game.ScreenHeight - 260), 0);
      }
      else
      {
        tsubpart = (SubPartClass) new TextAreaClass2(this.game, (int) Math.Round(Math.Min(800.0, (double) this.game.ScreenWidth / 2.0 - 50.0)), (int) Math.Round((double) Math.Max(120, this.game.ScreenHeight - 260) / 27.0), this.game.MarcFont4, str, 27, ref this.OwnBitmap, 510 + num1, 80);
        this.outputid = this.AddSubPart(ref tsubpart, 510 + num1, 80, (int) Math.Round(Math.Min(800.0, (double) this.game.ScreenWidth / 2.0 - 50.0)), Math.Max(120, this.game.ScreenHeight - 260), 0);
      }
      this.outputFixedSys = false;
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
            int num = this.SubPartID[index];
            if (num == this.outputid)
            {
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.opt1id)
            {
              this.output = "Commencing testing for duplicate officers...\r\n";
              this.output += this.RemoveDuplicateOfficers(true);
              this.output += "\r\n\r\nCommencing testing for logostring issues...\r\n";
              this.output += this.RemoveSFTypeLogoTextRemnants(true);
              this.output += "\r\n\r\nCommencing testing for duplicate troopType libs...\r\n";
              this.output += this.RemoveDuplicateTroopTypeLibs(true);
              this.output += "\r\n\r\nCommencing testing for duplicate troopType inside the same lib...\r\n";
              this.output += this.RemoveDuplicateTroopTypeInSameLib(true);
              this.output += "\r\n\r\nCommencing testing for duplicate historicals...\r\n";
              this.output += this.RemoveDuplicateHistoricals(true);
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.opt2id)
            {
              this.output = "Commencing diagnostics for trooptype libraries...\r\n";
              this.output += this.DiagnosticsTroopTypeLibs();
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.opt5id)
            {
              int deltaX = (int) Math.Round(Conversion.Val(Interaction.InputBox("Delta for X move", "Shadow Empire : Planetary Conquest")));
              int deltaY = (int) Math.Round(Conversion.Val(Interaction.InputBox("Delta for Y move", "Shadow Empire : Planetary Conquest")));
              if (!(deltaX == 0 & deltaY == 0))
              {
                if (Interaction.MsgBox((object) ("Mass Move Delta is " + deltaX.ToString() + "," + deltaY.ToString() + ". Are you sure?"), MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                {
                  this.output = "Commencing mass move units...\r\n";
                  this.output += this.Batch_MassMoveUnits(deltaX, deltaY);
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
              }
            }
            else
            {
              if (num == this.opt4id)
              {
                this.output = "Commencing diagnostics for graphics memory...\r\n";
                this.output += this.DiagnosticsGraphicsMem();
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num == this.fuelId)
              {
                this.output = "Commencing diagnostics for Fuel/Supply usage..\r\n";
                this.output += this.DiagnosticsFuel();
                this.outputFixedSys = true;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num == this.powId)
              {
                this.output = "Commencing diagnostics for Fuel/Supply usage..\r\n";
                this.output += this.DiagnosticsPower();
                this.outputFixedSys = true;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num == this.opt3id)
              {
                this.game.FormRef.Cursor = Cursors.WaitCursor;
                if (Operators.CompareString(this.game.Data.MasterFile, "", false) == 0)
                {
                  this.output = "Masterfile was not set\r\n";
                  this.game.Data.MasterFile = "VR_ruleset.dcxmaster";
                  this.output = "Masterfile is now set too: " + this.game.Data.MasterFile + "\r\n";
                }
                else
                  this.output = "Masterfile was set too: " + this.game.Data.MasterFile + "\r\n";
                this.game.Data.MasterfileReadPeople = false;
                string filename = this.game.AppPath + this.game.ModScenarioDir + "/" + this.game.Data.MasterFile;
                this.game.EditObj.LoadString = "Loading Masterfile";
                this.game.HandyFunctionsObj.LoadMasterFile(filename, alsohistorical: false, LoadGameVars: true, LoadVariants: false);
                this.output = this.output + "Have reset and reloaded masterfile to the VR ruleset masterfile: " + this.game.Data.MasterFile + "\r\n\r\n";
                this.output += "All Ok!";
                BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                this.game.Data.LoadGraphics((Form1) null);
                this.game.FormRef.Cursor = Cursors.Default;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num == this.opt1bid && Interaction.MsgBox((object) "Are you sure?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
              {
                this.game.FormRef.Cursor = Cursors.WaitCursor;
                this.output = "Commencing removing duplicating officers...\r\n";
                this.output += this.RemoveDuplicateOfficers(false);
                this.output += "\r\n\r\nCommencing fixing logostring issues...\r\n";
                this.output += this.RemoveSFTypeLogoTextRemnants(false);
                this.output += "\r\n\r\nCommencing removing duplicate troopType libs...\r\n";
                this.output += this.RemoveDuplicateTroopTypeLibs(false);
                this.output += "\r\n\r\nCommencing removing duplicate troopType inside the same lib...\r\n";
                this.output += this.RemoveDuplicateTroopTypeInSameLib(false);
                this.output += "\r\n\r\nCommencing removing duplicate historicals...\r\n";
                this.output += this.RemoveDuplicateHistoricals(false);
                this.output += "\r\n\r\nFinished.";
                this.game.FormRef.Cursor = Cursors.Default;
                this.DoStuff();
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

    private string Batch_MassMoveUnits(int deltaX, int deltaY)
    {
      string Left = "";
      int y;
      for (int unitCounter1 = this.game.Data.UnitCounter; unitCounter1 >= 0; unitCounter1 += -1)
      {
        if (unitCounter1 <= this.game.Data.UnitCounter && this.game.Data.UnitObj[unitCounter1].PreDef == -1 & this.game.Data.UnitObj[unitCounter1].X > -1)
        {
          int x = this.game.Data.UnitObj[unitCounter1].X;
          y = this.game.Data.UnitObj[unitCounter1].Y;
          int num = x + deltaX;
          y += deltaY;
          if (num >= 0 & y >= 0 & num <= this.game.Data.MapObj[0].MapWidth & y <= this.game.Data.MapObj[0].MapHeight)
          {
            this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unitCounter1].X, this.game.Data.UnitObj[unitCounter1].Y].RemoveUnitFromList(unitCounter1);
            this.game.Data.UnitObj[unitCounter1].X = num;
            this.game.Data.UnitObj[unitCounter1].Y = y;
            this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unitCounter1].X, this.game.Data.UnitObj[unitCounter1].Y].AddUnitToList(unitCounter1);
            Left = Left + "* " + this.game.Data.UnitObj[unitCounter1].Name + " has been moved to " + num.ToString() + "," + y.ToString() + ".\r\n";
          }
          else
          {
            Left = Left + "* " + this.game.Data.UnitObj[unitCounter1].Name + " has been moved off-map and thus been deleted.\r\n";
            this.game.EditObj.UnitSelected = unitCounter1;
            if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName.Length > 0)
            {
              LibIdClass libIdClass = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].OffLibId.Clone();
              this.game.Data.AddHistoricalUnit();
              this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].TempRegime = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].TempRegime;
              this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].People = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].People;
              this.game.ProcessingObj.SwapOfficer(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical, this.game.Data.HistoricalUnitCounter, this.game.EditObj.UnitSelected);
              this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].OffLibId = new LibIdClass();
              this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].LibId = libIdClass;
              this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].Pool = true;
            }
            GameClass gameClass;
            if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].LibId.libSlot == -1)
            {
              this.game.Data.RemoveHistoricalUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical);
              for (int unitCounter2 = this.game.Data.UnitCounter; unitCounter2 >= 0; unitCounter2 += -1)
              {
                if (this.game.Data.UnitObj[unitCounter2].PreDef == -1 & this.game.Data.UnitObj[unitCounter2].Historical == -1)
                {
                  DataClass data = this.game.Data;
                  int nr = unitCounter2;
                  gameClass = (GameClass) null;
                  ref GameClass local = ref gameClass;
                  data.RemoveUnit(nr, ref local);
                }
              }
            }
            else
            {
              int historical = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical;
              for (int unitCounter3 = this.game.Data.UnitCounter; unitCounter3 >= 0; unitCounter3 += -1)
              {
                if (this.game.Data.UnitObj[unitCounter3].Historical == historical)
                {
                  this.game.Data.UnitObj[unitCounter3].Historical = -1;
                  DataClass data = this.game.Data;
                  int nr = unitCounter3;
                  gameClass = (GameClass) null;
                  ref GameClass local = ref gameClass;
                  data.RemoveUnit(nr, ref local);
                }
              }
            }
            this.game.EditObj.UnitSelected = -1;
          }
        }
      }
      for (int unitCounter = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
      {
        if (this.game.Data.UnitObj[unitCounter].PreDef == -1 & this.game.Data.UnitObj[unitCounter].X > -1)
        {
          int x = this.game.Data.UnitObj[unitCounter].X;
          y = this.game.Data.UnitObj[unitCounter].Y;
          if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[x, y].LandscapeType].IsSea)
            this.game.Data.MapObj[0].HexObj[x, y].Regime = this.game.Data.UnitObj[unitCounter].Regime;
        }
      }
      if (Operators.CompareString(Left, "", false) == 0)
        Left = "NO UNITS FOUND";
      return Left;
    }

    private string RemoveDuplicateOfficers(bool testing)
    {
      string Left1 = "";
      int num1;
      for (int historicalUnitCounter = this.game.Data.HistoricalUnitCounter; historicalUnitCounter >= 0; historicalUnitCounter += -1)
      {
        if (this.game.Data.HistoricalUnitObj[historicalUnitCounter].CommanderName.Length > 0 && this.game.Data.HistoricalUnitObj[historicalUnitCounter].OffLibId.libSlot == -1 & !this.game.Data.HistoricalUnitObj[historicalUnitCounter].Pool | this.game.Data.HistoricalUnitObj[historicalUnitCounter].LibId.libSlot == -1 & this.game.Data.HistoricalUnitObj[historicalUnitCounter].Pool)
        {
          string str = Left1 + "COMMANDER WITHOUT LIBRARY '" + this.game.Data.HistoricalUnitObj[historicalUnitCounter].CommanderName + "' (pool=" + this.game.Data.HistoricalUnitObj[historicalUnitCounter].Pool.ToString() + ")...";
          if (testing)
          {
            Left1 = str + " FOUND. \r\n";
          }
          else
          {
            Left1 = str + " DELETED !. \r\n";
            if (this.game.HandyFunctionsObj.GetUnitByHistorical(historicalUnitCounter) > -1)
            {
              this.game.Data.HistoricalUnitObj[historicalUnitCounter].OffLibId.libSlot = -1;
              this.game.Data.HistoricalUnitObj[historicalUnitCounter].OffLibId.id = -1;
              this.game.Data.HistoricalUnitObj[historicalUnitCounter].CommanderName = "";
              this.game.Data.HistoricalUnitObj[historicalUnitCounter].DeckCardCounter = -1;
              this.game.Data.HistoricalUnitObj[historicalUnitCounter].HandCardCounter = -1;
            }
            else
              this.game.Data.RemoveHistoricalUnit(historicalUnitCounter);
          }
          ++num1;
        }
      }
      if (num1 > 0)
        Left1 = (!testing ? Left1 + "TOTAL COMMANDER WITHOUT LIBRARY DELETED = " + num1.ToString() + "\r\n" : Left1 + "TOTAL COMMANDER WITHOUT LIBRARY FOUND = " + num1.ToString() + "\r\n") + "NOTE: If Commanders without historical library get deleted you might want to double check everybody is still present.. or reload officer library.";
      if (Operators.CompareString(Left1, "", false) == 0)
        Left1 = "NO COMMANDER WITHOUT LIBRARY FOUND";
      string str1 = Left1;
      string Left2 = "";
      int num2;
      for (int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter; historicalUnitCounter1 >= 0; historicalUnitCounter1 += -1)
      {
        if (this.game.Data.HistoricalUnitObj[historicalUnitCounter1].CommanderName.Length > 0 && this.game.Data.HistoricalUnitObj[historicalUnitCounter1].OffLibId.libSlot == -1 & this.game.Data.HistoricalUnitObj[historicalUnitCounter1].Pool)
        {
          bool flag = false;
          for (int historicalUnitCounter2 = this.game.Data.HistoricalUnitCounter; historicalUnitCounter2 >= 0; historicalUnitCounter2 += -1)
          {
            if (historicalUnitCounter1 != historicalUnitCounter2 && this.game.Data.HistoricalUnitObj[historicalUnitCounter2].CommanderName.Length > 0)
            {
              if (this.game.Data.HistoricalUnitObj[historicalUnitCounter2].OffLibId.libSlot < 0)
              {
                if (this.game.Data.HistoricalUnitObj[historicalUnitCounter1].LibId.libSlot == this.game.Data.HistoricalUnitObj[historicalUnitCounter2].LibId.libSlot && this.game.Data.HistoricalUnitObj[historicalUnitCounter1].LibId.id == this.game.Data.HistoricalUnitObj[historicalUnitCounter2].LibId.id)
                  flag = true;
              }
              else if (this.game.Data.HistoricalUnitObj[historicalUnitCounter1].LibId.libSlot == this.game.Data.HistoricalUnitObj[historicalUnitCounter2].OffLibId.libSlot && this.game.Data.HistoricalUnitObj[historicalUnitCounter1].LibId.id == this.game.Data.HistoricalUnitObj[historicalUnitCounter2].OffLibId.id)
                flag = true;
            }
          }
          if (flag)
          {
            string str2 = "COMMANDER '" + this.game.Data.HistoricalUnitObj[historicalUnitCounter1].CommanderName + "' (pool=" + this.game.Data.HistoricalUnitObj[historicalUnitCounter1].Pool.ToString() + ")...";
            string str3;
            if (this.game.Data.HistoricalUnitObj[historicalUnitCounter1].LibId.libSlot > -1)
              str3 = str2 + " from library: " + this.game.Data.LibraryObj[this.game.Data.HistoricalUnitObj[historicalUnitCounter1].LibId.libSlot].name + ", id: " + this.game.Data.HistoricalUnitObj[historicalUnitCounter1].LibId.id.ToString();
            else
              str3 = str2 + " (no library)";
            if (testing)
            {
              Left2 = Left2 + "FOUND A DUPLICATE " + str3 + "\r\n";
            }
            else
            {
              Left2 = Left2 + "DELETED DUPLICATE " + str3 + "\r\n";
              this.game.Data.RemoveHistoricalUnit(historicalUnitCounter1);
            }
            ++num2;
          }
        }
      }
      if (num2 > 0)
        Left2 = (!testing ? Left2 + "TOTAL DUPLICATES DELETED = " + num2.ToString() + "\r\n" : Left2 + "TOTAL DUPLICATES FOUND = " + num2.ToString() + "\r\n") + "NOTE: A duplicate in this case is a historical unit slot with commander info, not assigned to a unit, who has a slot with the same library and libraryID in a lower historical slot.";
      if (Operators.CompareString(Left2, "", false) == 0)
        Left2 = "NO DUPLICATES FOUND";
      return str1 + "\r\n" + Left2;
    }

    private string RemoveDuplicateTroopTypeLibs(bool testing)
    {
      string Left = "";
      int num1;
      for (int libraryCounter1 = this.game.Data.LibraryCounter; libraryCounter1 >= 0; libraryCounter1 += -1)
      {
        bool flag = false;
        int num2 = -1;
        for (int libraryCounter2 = this.game.Data.LibraryCounter; libraryCounter2 >= 0; libraryCounter2 += -1)
        {
          if (this.IsTroopTypeLibrary(libraryCounter2) && libraryCounter1 != libraryCounter2 && Operators.CompareString(this.game.Data.LibraryObj[libraryCounter1].name, this.game.Data.LibraryObj[libraryCounter2].name, false) == 0 && this.game.Data.LibraryObj[libraryCounter1].version <= this.game.Data.LibraryObj[libraryCounter2].version)
          {
            num2 = libraryCounter2;
            flag = true;
            break;
          }
        }
        if (flag)
        {
          string str = "TroopType Library '" + this.game.Data.LibraryObj[libraryCounter1].name + "'";
          Left = !testing ? Left + "DELETED DUPLICATE " + str + "\r\n" : Left + "FOUND A DUPLICATE " + str + "\r\n";
          bool[] flagArray = new bool[this.game.Data.SFTypeCounter + 1];
          int unitCounter = this.game.Data.UnitCounter;
          for (int index1 = 0; index1 <= unitCounter; ++index1)
          {
            int sfCount = this.game.Data.UnitObj[index1].SFCount;
            for (int index2 = 0; index2 <= sfCount; ++index2)
            {
              int sf = this.game.Data.UnitObj[index1].SFList[index2];
              int type = this.game.Data.SFObj[sf].Type;
              if (this.game.Data.SFTypeObj[type].LibId.libSlot == libraryCounter1)
              {
                int sfTypeCounter = this.game.Data.SFTypeCounter;
                for (int index3 = 0; index3 <= sfTypeCounter; ++index3)
                {
                  if (this.game.Data.SFTypeObj[index3].LibId.libSlot == num2 && this.game.Data.SFTypeObj[index3].LibId.id == this.game.Data.SFTypeObj[type].LibId.id)
                  {
                    if (testing)
                    {
                      if (!flagArray[type])
                        Left += "* Will redirect ";
                    }
                    else
                    {
                      this.game.Data.SFObj[sf].Type = index3;
                      if (!flagArray[type])
                        Left += "* Redirecting ";
                    }
                    if (!flagArray[type])
                      Left = Left + "TroopType slot " + type.ToString() + ", " + this.game.Data.SFTypeObj[type].Name + " of libSlot " + libraryCounter1.ToString() + " => TroopType slot " + index3.ToString() + ", " + this.game.Data.SFTypeObj[index3].Name + " of libSlot " + num2.ToString();
                    if (!flagArray[type])
                      Left += "\r\n";
                    flagArray[type] = true;
                  }
                }
              }
            }
          }
          if (!testing)
          {
            this.game.Data.RemoveLibrary(libraryCounter1);
            ++num1;
          }
        }
      }
      if (num1 > 0)
        Left = (!testing ? Left + "TOTAL DUPLICATES DELETED = " + num1.ToString() + "\r\n" : Left + "TOTAL DUPLICATES FOUND = " + num1.ToString() + "\r\n") + "NOTE: The duplicate TroopType library with lowest OR same version (but highest in list) will be deleted. Deleting of duplicate troopType libraries with different contents can cause links to be broken and troops to dissapear as a result.";
      if (Operators.CompareString(Left, "", false) == 0)
        Left = "NO DUPLICATES FOUND";
      return Left;
    }

    private string RemoveDuplicateHistoricals(bool testing)
    {
      int num1 = 0;
      string str1 = "";
      for (int historicalUnitCounter = this.game.Data.HistoricalUnitCounter; historicalUnitCounter >= 0; historicalUnitCounter += -1)
      {
        if (this.game.Data.HistoricalUnitObj[historicalUnitCounter].ModelMaster > -1 && this.game.Data.HistoricalUnitObj[historicalUnitCounter].LibId.libSlot == -1 && this.game.HandyFunctionsObj.GetUnitByHistorical(historicalUnitCounter) == -1)
        {
          ++num1;
          string str2 = str1 + "* Found Historical Unit witout library NOT assigned to Map Units [" + this.game.Data.HistoricalUnitObj[historicalUnitCounter].Name + " (" + this.game.Data.HistoricalUnitObj[historicalUnitCounter].ID.ToString() + ")]";
          if (!testing)
            str2 += "<WILL DELETE!>";
          if (!testing)
            this.game.Data.RemoveHistoricalUnit(historicalUnitCounter);
          str1 = str2 + "\r\n";
        }
      }
      int num2 = 0;
      for (int unitCounter = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
      {
        if (this.game.Data.UnitObj[unitCounter].PreDef == -1 & this.game.Data.UnitObj[unitCounter].Historical == -1)
        {
          ++num2;
          string str3 = str1 + "* Found Unit that is not assigned to a historical [" + this.game.Data.UnitObj[unitCounter].Name + " (" + this.game.Data.UnitObj[unitCounter].X.ToString() + "," + this.game.Data.UnitObj[unitCounter].Y.ToString() + ")]";
          if (!testing)
            str3 += "<WILL DELETE!>";
          if (!testing)
          {
            DataClass data = this.game.Data;
            int nr = unitCounter;
            GameClass gameClass = (GameClass) null;
            ref GameClass local = ref gameClass;
            data.RemoveUnit(nr, ref local);
          }
          str1 = str3 + "\r\n";
        }
      }
      for (int historicalUnitCounter = this.game.Data.HistoricalUnitCounter; historicalUnitCounter >= 0; historicalUnitCounter += -1)
      {
        if (this.game.Data.HistoricalUnitObj[historicalUnitCounter].ModelMaster > -1 && this.game.Data.HistoricalUnitObj[historicalUnitCounter].LibId.libSlot > -1 && this.game.HandyFunctionsObj.GetUnitByHistorical(historicalUnitCounter) == -1)
        {
          ++num1;
          string str4 = str1 + "* Found Historical Unit witout library NOT assigned to Map Units [" + this.game.Data.HistoricalUnitObj[historicalUnitCounter].Name + " (" + this.game.Data.HistoricalUnitObj[historicalUnitCounter].ID.ToString() + ")]";
          if (!testing)
            str4 += "<WILL DELETE!>";
          if (!testing)
            this.game.Data.RemoveHistoricalUnit(historicalUnitCounter);
          str1 = str4 + "\r\n";
        }
      }
      int num3 = 0;
      int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
      for (int index1 = 0; index1 <= historicalUnitCounter1; ++index1)
      {
        if (this.game.Data.HistoricalUnitObj[index1].Model)
        {
          bool flag = false;
          string str5 = "";
          int historicalUnitCounter2 = this.game.Data.HistoricalUnitCounter;
          for (int index2 = 0; index2 <= historicalUnitCounter2; ++index2)
          {
            if (this.game.Data.HistoricalUnitObj[index2].Model && index2 >= index1 && this.game.Data.HistoricalUnitObj[index1].LibId.libSlot == this.game.Data.HistoricalUnitObj[index2].LibId.libSlot && Operators.CompareString(this.game.Data.HistoricalUnitObj[index1].Name, this.game.Data.HistoricalUnitObj[index2].Name, false) == 0)
            {
              if (index2 > index1)
                flag = true;
              string str6 = "Libname: -none-";
              if (this.game.Data.HistoricalUnitObj[index2].LibId.libSlot > -1)
                str6 = "Libname: " + this.game.Data.LibraryObj[this.game.Data.HistoricalUnitObj[index2].LibId.libSlot].name + " & LibID=" + this.game.Data.HistoricalUnitObj[index2].LibId.id.ToString();
              str5 = str5 + "(" + str6 + ") ";
            }
          }
          if (flag)
          {
            ++num3;
            str1 = str1 + "* Duplicate name: " + this.game.Data.HistoricalUnitObj[index1].Name + ": " + str5 + "\r\n";
          }
        }
      }
      string str7 = str1 + "\r\n";
      string str8 = (num1 <= 0 ? str7 + "NO NON-LIBRARY HIS.UNITS WITHOUT UNITS FOUND " : (!testing ? str7 + "TOTAL NON-LIBRARY HIS.UNITS WITHOUT UNITS DELETED = " + num1.ToString() : str7 + "TOTAL NON-LIBRARY HIS.UNITS WITHOUT UNITS FOUND = " + num1.ToString())) + "\r\n";
      string str9 = (num2 <= 0 ? str8 + "NO NUNITS ON MAP WITHOUT HISTORICAL ATTACHED FOUND " : (!testing ? str8 + "TOTAL UNITS ON MAP WITHOUT HISTORICAL ATTACHED DELETED = " + num2.ToString() : str8 + "TOTAL UNITS ON MAP WITHOUT HISTORICAL ATTACHED FOUND = " + num2.ToString())) + "\r\n";
      return (num3 <= 0 ? str9 + "NO DOUBLE NAME MODEL HISTORICAL UNITS FOUND" : (!testing ? str9 + "TOTAL DOUBLE NAME MODEL HISTORICAL UNITS FOUND = " + num3.ToString() : str9 + "TOTAL DOUBLE NAME MODEL HISTORICAL UNITS FOUND = " + num3.ToString())) + "\r\n" + "Note: Duplicate names are not neccessarily a problem. Hence they are NOT a problem that will be fixed." + "\r\n";
    }

    private string RemoveDuplicateTroopTypeInSameLib(bool testing)
    {
      bool[] flagArray = new bool[this.game.Data.SFTypeCounter + 1];
      string str1 = "";
      int nr;
      int num;
      for (int libraryCounter = this.game.Data.LibraryCounter; libraryCounter >= 0; libraryCounter += -1)
      {
        if (this.IsTroopTypeLibrary(libraryCounter))
        {
          str1 = str1 + "TroopType Library '" + this.game.Data.LibraryObj[libraryCounter].name + "\r\n";
          int sfTypeCounter1 = this.game.Data.SFTypeCounter;
          for (nr = 0; nr <= sfTypeCounter1; ++nr)
          {
            if (this.game.Data.SFTypeObj[nr].LibId.libSlot == libraryCounter)
            {
              int sfTypeCounter2 = this.game.Data.SFTypeCounter;
              for (int index1 = 0; index1 <= sfTypeCounter2; ++index1)
              {
                if (nr != index1 & index1 > nr && this.game.Data.SFTypeObj[index1].LibId.libSlot == libraryCounter && this.game.Data.SFTypeObj[index1].LibId.id == this.game.Data.SFTypeObj[nr].LibId.id)
                {
                  string str2 = str1 + "* Found duplicate SFType slot#" + nr.ToString() + ", " + this.game.Data.SFTypeObj[nr].Name + ", and slot#" + index1.ToString() + ", " + this.game.Data.SFTypeObj[nr].Name + ".";
                  ++num;
                  flagArray[index1] = true;
                  if (!testing)
                  {
                    int unitCounter = this.game.Data.UnitCounter;
                    for (int index2 = 0; index2 <= unitCounter; ++index2)
                    {
                      int sfCount = this.game.Data.UnitObj[index2].SFCount;
                      for (int index3 = 0; index3 <= sfCount; ++index3)
                      {
                        if (this.game.Data.SFObj[this.game.Data.UnitObj[index2].SFList[index3]].Type == index1)
                        {
                          this.game.Data.SFObj[this.game.Data.UnitObj[index2].SFList[index3]].Type = nr;
                          str2 = str2 + " Re-assigned all references to slot " + index1.ToString() + " to " + nr.ToString();
                        }
                      }
                    }
                  }
                  str1 = str2 + "\r\n";
                }
              }
            }
          }
        }
      }
      if (!testing)
        str1 += "\r\n";
      for (nr = this.game.Data.SFTypeCounter; nr >= 0; nr += -1)
      {
        if (flagArray[nr] & !testing)
        {
          str1 = str1 + "* Removed SFType slot #" + nr.ToString() + "," + this.game.Data.SFTypeObj[nr].Name + "\r\n";
          this.game.Data.RemoveSFType(nr);
        }
      }
      string str3;
      if (num > 0)
      {
        string str4 = str1 + "\r\n";
        str3 = !testing ? str4 + "TOTAL DUPLICATES DELETED = " + num.ToString() : str4 + "TOTAL DUPLICATES FOUND = " + num.ToString();
      }
      else
        str3 = str1 + "NO DUPLICATES FOUND";
      return str3;
    }

    private bool IsTroopTypeLibrary(int libslot)
    {
      int sfTypeCounter = this.game.Data.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter; ++index)
      {
        if (this.game.Data.SFTypeObj[index].LibId.libSlot == libslot)
          return true;
      }
      return false;
    }

    private string DiagnosticsTroopTypeLibs()
    {
      int libraryCounter = this.game.Data.LibraryCounter;
      string str;
      for (int index1 = 0; index1 <= libraryCounter; ++index1)
      {
        bool flag1 = false;
        int sfTypeCounter = this.game.Data.SFTypeCounter;
        for (int index2 = 0; index2 <= sfTypeCounter; ++index2)
        {
          if (this.game.Data.SFTypeObj[index2].LibId.libSlot == index1)
          {
            if (!flag1)
            {
              str = str + "\r\n" + "Library Slot: " + index1.ToString() + ", Name: " + this.game.Data.LibraryObj[index1].name + "\r\n";
              flag1 = true;
            }
            int num = 0;
            int unitCounter = this.game.Data.UnitCounter;
            for (int index3 = 0; index3 <= unitCounter; ++index3)
            {
              bool flag2 = false;
              int sfCount = this.game.Data.UnitObj[index3].SFCount;
              for (int index4 = 0; index4 <= sfCount; ++index4)
              {
                if (this.game.Data.SFObj[this.game.Data.UnitObj[index3].SFList[index4]].Type == index2)
                  flag2 = true;
              }
              if (flag2)
                ++num;
            }
            str = str + "*" + this.game.Data.SFTypeObj[index2].Name + ", slot: " + index2.ToString() + ", libID = " + this.game.Data.SFTypeObj[index2].LibId.id.ToString() + ", unitsUsing: " + num.ToString() + "\r\n";
          }
        }
      }
      return str;
    }

    private string DiagnosticsGraphicsMem()
    {
      string[] strArray = new string[BitmapStore.Counter + 1];
      SimpleList simpleList = new SimpleList();
      string str1;
      string str2 = str1 + "TOTAL MEMORY USAGE" + "\r\n";
      int counter1 = BitmapStore.Counter;
      int index1;
      int num1;
      int num2;
      int num3;
      int num4;
      string str3;
      for (int index2 = 0; index2 <= counter1; ++index2)
      {
        index1 = BitmapStore.GetMemorySize(index2, 0, 1);
        int memorySize1 = BitmapStore.GetMemorySize(index2, 1, 1);
        int memorySize2 = BitmapStore.GetMemorySize(index2, -1, 1);
        int memorySize3 = BitmapStore.GetMemorySize(index2, 0, 2);
        num1 += index1;
        num2 += memorySize1;
        num3 += memorySize2;
        num4 += memorySize3;
        str3 = BitmapStore.tmpFileName[index2] + ": REG: " + index1.ToString() + "K, BIG: " + memorySize1.ToString() + "K, SMALL: " + memorySize2.ToString() + "K, CACHE: " + memorySize3.ToString() + "K";
        strArray[index2] = str3;
        simpleList.Add(index2, index1 + memorySize1 + memorySize2 + memorySize3);
      }
      string str4 = str2 + "BITMAPSTORE REG: " + num1.ToString() + "K, BIG: " + num2.ToString() + "K, SMALL: " + num3.ToString() + "K, CACHE: " + num4.ToString() + "K" + "\r\n";
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this.game.Data);
      index1 = (int) serializationStream.Length;
      serializationStream.Close();
      index1 = (int) Math.Round((double) index1 / 1024.0);
      string str5 = str4 + "DATA: " + index1.ToString() + "K" + "\r\n" + "\r\n" + "BITMAPSTORE DETAILS\r\n";
      simpleList.ReverseSort();
      int counter2 = simpleList.Counter;
      for (int index3 = 0; index3 <= counter2; ++index3)
      {
        index1 = simpleList.Id[index3];
        str5 = str5 + strArray[index1] + "\r\n";
      }
      return str5 + str3;
    }

    private string DiagnosticsFuel()
    {
      SimpleList simpleList1 = new SimpleList();
      SimpleList simpleList2 = new SimpleList();
      int[] numArray1 = new int[this.game.Data.UnitCounter + 1];
      int[] numArray2 = new int[this.game.Data.UnitCounter + 1];
      int[] numArray3 = new int[this.game.Data.UnitCounter + 1];
      int[] numArray4 = new int[this.game.Data.UnitCounter + 1];
      int[] numArray5 = new int[this.game.Data.UnitCounter + 1];
      int[] numArray6 = new int[this.game.Data.UnitCounter + 1];
      int[,] numArray7 = new int[this.game.Data.RegimeCounter + 1 + 1, 100];
      int[,] numArray8 = new int[this.game.Data.RegimeCounter + 1 + 1, 100];
      int[,] numArray9 = new int[this.game.Data.RegimeCounter + 1 + 1, 100];
      int[,] numArray10 = new int[this.game.Data.RegimeCounter + 1 + 1, 100];
      int[,] numArray11 = new int[this.game.Data.RegimeCounter + 1 + 1, 100];
      int[,] numArray12 = new int[this.game.Data.RegimeCounter + 1 + 1, 100];
      int unitCounter1 = this.game.Data.UnitCounter;
      int index1;
      int num1;
      int num2;
      for (index1 = 0; index1 <= unitCounter1; ++index1)
      {
        if (this.game.Data.UnitObj[index1].PreDef == -1)
        {
          int historical = this.game.Data.UnitObj[index1].Historical;
          int regime = this.game.Data.UnitObj[index1].Regime;
          if (historical > -1)
          {
            if (this.game.Data.HistoricalUnitObj[historical].Type >= 5)
              simpleList1.Add(index1, this.game.Data.HistoricalUnitObj[historical].Type);
            int sfCount = this.game.Data.UnitObj[index1].SFCount;
            for (int index2 = 0; index2 <= sfCount; ++index2)
            {
              int sf = this.game.Data.UnitObj[index1].SFList[index2];
              int type = this.game.Data.SFObj[sf].Type;
              int unitGroup = this.game.Data.SFTypeObj[type].UnitGroup;
              int qty = this.game.Data.SFObj[sf].Qty;
              int num3 = this.game.Data.SFTypeObj[type].FuelForAttack * qty * 10;
              int[] numArray13 = numArray1;
              int[] numArray14 = numArray13;
              int index3 = index1;
              int index4 = index3;
              int num4 = numArray13[index3] + num3;
              numArray14[index4] = num4;
              int[,] numArray15 = numArray7;
              int[,] numArray16 = numArray15;
              int index5 = regime;
              int index6 = index5;
              int index7 = unitGroup;
              int index8 = index7;
              int num5 = numArray15[index5, index7] + num3;
              numArray16[index6, index8] = num5;
              int num6 = this.game.Data.SFTypeObj[type].FuelForMove * qty * 10;
              int[] numArray17 = numArray2;
              int[] numArray18 = numArray17;
              int index9 = index1;
              int index10 = index9;
              int num7 = numArray17[index9] + num6;
              numArray18[index10] = num7;
              int[,] numArray19 = numArray8;
              int[,] numArray20 = numArray19;
              int index11 = regime;
              int index12 = index11;
              int index13 = unitGroup;
              int index14 = index13;
              int num8 = numArray19[index11, index13] + num6;
              numArray20[index12, index14] = num8;
              int num9 = this.game.Data.SFTypeObj[type].FuelForAttackDef * qty * 10;
              int[] numArray21 = numArray3;
              int[] numArray22 = numArray21;
              int index15 = index1;
              int index16 = index15;
              int num10 = numArray21[index15] + num9;
              numArray22[index16] = num10;
              int[,] numArray23 = numArray9;
              int[,] numArray24 = numArray23;
              int index17 = regime;
              int index18 = index17;
              int index19 = unitGroup;
              int index20 = index19;
              int num11 = numArray23[index17, index19] + num9;
              numArray24[index18, index20] = num11;
              num1 = 10;
              if (this.game.Data.SFTypeObj[type].EndCombatRound > 0 & this.game.Data.SFTypeObj[type].EndCombatRound < num1)
                num1 = this.game.Data.SFTypeObj[type].EndCombatRound - this.game.Data.SFTypeObj[type].StartCombatRound;
              int num12 = this.game.Data.SFTypeObj[type].SupplyForAttack * qty * num1;
              int[] numArray25 = numArray4;
              int[] numArray26 = numArray25;
              int index21 = index1;
              int index22 = index21;
              int num13 = numArray25[index21] + num12;
              numArray26[index22] = num13;
              int[,] numArray27 = numArray10;
              int[,] numArray28 = numArray27;
              int index23 = regime;
              int index24 = index23;
              int index25 = unitGroup;
              int index26 = index25;
              int num14 = numArray27[index23, index25] + num12;
              numArray28[index24, index26] = num14;
              int num15 = this.game.Data.SFTypeObj[type].SupplyForAttackDef * qty * num1;
              int[] numArray29 = numArray5;
              int[] numArray30 = numArray29;
              int index27 = index1;
              int index28 = index27;
              int num16 = numArray29[index27] + num15;
              numArray30[index28] = num16;
              int[,] numArray31 = numArray11;
              int[,] numArray32 = numArray31;
              int index29 = regime;
              int index30 = index29;
              int index31 = unitGroup;
              int index32 = index31;
              int num17 = numArray31[index29, index31] + num15;
              numArray32[index30, index32] = num17;
              num2 = this.game.Data.SFTypeObj[type].BasicSupplyNeed * qty * 1;
              int[] numArray33 = numArray6;
              int[] numArray34 = numArray33;
              int index33 = index1;
              int index34 = index33;
              int num18 = numArray33[index33] + num2;
              numArray34[index34] = num18;
              int[,] numArray35 = numArray12;
              int[,] numArray36 = numArray35;
              int index35 = regime;
              int index36 = index35;
              int index37 = unitGroup;
              int index38 = index37;
              int num19 = numArray35[index35, index37] + num2;
              numArray36[index36, index38] = num19;
            }
          }
        }
      }
      simpleList1.ReverseSortHighSpeed();
      int regimeCounter = this.game.Data.RegimeCounter;
      string str1;
      for (int index39 = 0; index39 <= regimeCounter; ++index39)
      {
        string str2 = str1 + "\r\n" + "FUEL USAGE CUMULATIVE TOTALS FOR " + this.game.Data.RegimeObj[index39].Name.ToUpper() + "\r\n";
        string str3 = "ALL UNDER HQ";
        string str4 = str3 + Strings.Space(30 - str3.Length);
        string str5 = str2 + str4;
        string str6 = "10R.OFF.COMBAT";
        string str7 = str6 + Strings.Space(15 - str6.Length);
        string str8 = str5 + str7;
        string str9 = "100AP.MOVEMENT";
        string str10 = str9 + Strings.Space(15 - str9.Length);
        string str11 = str8 + str10;
        string str12 = "10R.DEF.COMBAT";
        string str13 = str12 + Strings.Space(15 - str12.Length);
        string str14 = str11 + str13 + "\r\n";
        int counter1 = simpleList1.Counter;
        int num20;
        for (int index40 = -1; index40 <= counter1; ++index40)
        {
          bool flag = false;
          if (index40 > -1)
          {
            index1 = simpleList1.Id[index40];
            if (this.game.Data.UnitObj[index1].Regime == index39)
            {
              flag = true;
              num2 = 0;
              num1 = 0;
              num20 = 0;
              int unitCounter2 = this.game.Data.UnitCounter;
              for (int unr = 0; unr <= unitCounter2; ++unr)
              {
                if (this.game.HandyFunctionsObj.IsUnitInHQChain(unr, index1))
                {
                  num2 += numArray1[unr];
                  num1 += numArray2[unr];
                  num20 += numArray3[unr];
                }
              }
            }
          }
          else
          {
            flag = true;
            num2 = 0;
            num1 = 0;
            num20 = 0;
            int unitCounter3 = this.game.Data.UnitCounter;
            for (int index41 = 0; index41 <= unitCounter3; ++index41)
            {
              if (this.game.Data.UnitObj[index41].Regime == index39 & this.game.Data.UnitObj[index41].PreDef == -1)
              {
                num2 += numArray1[index41];
                num1 += numArray2[index41];
                num20 += numArray3[index41];
              }
            }
          }
          if (flag)
          {
            string str15 = index40 != -1 ? Strings.Left(this.game.Data.UnitObj[index1].Name, 29) : "TOTAL OOB ON MAP";
            string str16 = str15 + Strings.Space(30 - str15.Length);
            string str17 = str14 + str16;
            string str18 = Strings.Left(num2.ToString(), 19);
            string str19 = str18 + Strings.Space(15 - str18.Length);
            string str20 = str17 + str19;
            string str21 = Strings.Left(num1.ToString(), 19);
            string str22 = str21 + Strings.Space(15 - str21.Length);
            string str23 = str20 + str22;
            string str24 = Strings.Left(num20.ToString(), 19);
            string str25 = str24 + Strings.Space(15 - str24.Length);
            str14 = str23 + str25 + "\r\n";
          }
        }
        string str26 = str14 + "\r\n" + "SUPPLY USAGE CUMULATIVE TOTALS FOR " + this.game.Data.RegimeObj[index39].Name.ToUpper() + "\r\n";
        string str27 = "ALL UNDER HQ";
        string str28 = str27 + Strings.Space(30 - str27.Length);
        string str29 = str26 + str28;
        string str30 = "10R.OFF.COMBAT";
        string str31 = str30 + Strings.Space(15 - str30.Length);
        string str32 = str29 + str31;
        string str33 = "10R.DEF.COMBAT";
        string str34 = str33 + Strings.Space(15 - str33.Length);
        string str35 = str32 + str34;
        string str36 = "UPKEEP ONLY";
        string str37 = str36 + Strings.Space(15 - str36.Length);
        string str38 = str35 + str37 + "\r\n";
        int counter2 = simpleList1.Counter;
        for (int index42 = -1; index42 <= counter2; ++index42)
        {
          bool flag = false;
          if (index42 > -1)
          {
            index1 = simpleList1.Id[index42];
            if (this.game.Data.UnitObj[index1].Regime == index39)
            {
              flag = true;
              num2 = 0;
              num1 = 0;
              num20 = 0;
              int unitCounter4 = this.game.Data.UnitCounter;
              for (int unr = 0; unr <= unitCounter4; ++unr)
              {
                if (this.game.HandyFunctionsObj.IsUnitInHQChain(unr, index1))
                {
                  num2 += numArray4[unr];
                  num1 += numArray5[unr];
                  num20 += numArray6[unr];
                }
              }
            }
          }
          else
          {
            flag = true;
            num2 = 0;
            num1 = 0;
            num20 = 0;
            int unitCounter5 = this.game.Data.UnitCounter;
            for (int index43 = 0; index43 <= unitCounter5; ++index43)
            {
              if (this.game.Data.UnitObj[index43].Regime == index39 & this.game.Data.UnitObj[index43].PreDef == -1)
              {
                num2 += numArray4[index43];
                num1 += numArray5[index43];
                num20 += numArray6[index43];
              }
            }
          }
          if (flag)
          {
            string str39 = index42 != -1 ? Strings.Left(this.game.Data.UnitObj[index1].Name, 29) : "TOTAL OOB ON MAP";
            string str40 = str39 + Strings.Space(30 - str39.Length);
            string str41 = str38 + str40;
            string str42 = Strings.Left(num2.ToString(), 19);
            string str43 = str42 + Strings.Space(15 - str42.Length);
            string str44 = str41 + str43;
            string str45 = Strings.Left(num1.ToString(), 19);
            string str46 = str45 + Strings.Space(15 - str45.Length);
            string str47 = str44 + str46;
            string str48 = Strings.Left(num20.ToString(), 19);
            string str49 = str48 + Strings.Space(15 - str48.Length);
            str38 = str47 + str49 + "\r\n";
          }
        }
        string str50 = str38 + "\r\n" + "FUEL USAGE CUMULATIVE TOTALS FOR " + this.game.Data.RegimeObj[index39].Name.ToUpper() + "\r\n";
        string str51 = "UNIT GROUP";
        string str52 = str51 + Strings.Space(30 - str51.Length);
        string str53 = str50 + str52;
        string str54 = "10R.OFF.COMBAT";
        string str55 = str54 + Strings.Space(15 - str54.Length);
        string str56 = str53 + str55;
        string str57 = "100AP.MOVEMENT";
        string str58 = str57 + Strings.Space(15 - str57.Length);
        string str59 = str56 + str58;
        string str60 = "10R.DEF.COMBAT";
        string str61 = str60 + Strings.Space(15 - str60.Length);
        string str62 = str59 + str61 + "\r\n";
        int index44 = 0;
        do
        {
          bool flag = false;
          int num21 = 0;
          int num22 = 0;
          int num23 = 0;
          int num24 = num21 + numArray7[index39, index44];
          int num25 = num22 + numArray8[index39, index44];
          int num26 = num23 + numArray9[index39, index44];
          if (num24 > 0 | num25 > 0 | num26 > 0)
            flag = true;
          if (flag & this.game.Data.TempString[400 + index44].Length > 1)
          {
            string str63 = Strings.Left(this.game.Data.TempString[400 + index44], 29);
            string str64 = str63 + Strings.Space(30 - str63.Length);
            string str65 = str62 + str64;
            string str66 = Strings.Left(num24.ToString(), 19);
            string str67 = str66 + Strings.Space(15 - str66.Length);
            string str68 = str65 + str67;
            string str69 = Strings.Left(num25.ToString(), 19);
            string str70 = str69 + Strings.Space(15 - str69.Length);
            string str71 = str68 + str70;
            string str72 = Strings.Left(num26.ToString(), 19);
            string str73 = str72 + Strings.Space(15 - str72.Length);
            str62 = str71 + str73 + "\r\n";
          }
          ++index44;
        }
        while (index44 <= 99);
        string str74 = str62 + "\r\n" + "SUPPLY USAGE CUMULATIVE TOTALS FOR " + this.game.Data.RegimeObj[index39].Name.ToUpper() + "\r\n";
        string str75 = "UNIT GROUP";
        string str76 = str75 + Strings.Space(30 - str75.Length);
        string str77 = str74 + str76;
        string str78 = "10R.OFF.COMBAT";
        string str79 = str78 + Strings.Space(15 - str78.Length);
        string str80 = str77 + str79;
        string str81 = "10R.DEF.COMBAT";
        string str82 = str81 + Strings.Space(15 - str81.Length);
        string str83 = str80 + str82;
        string str84 = "UPKEEP";
        string str85 = str84 + Strings.Space(15 - str84.Length);
        string str86 = str83 + str85 + "\r\n";
        int index45 = 0;
        do
        {
          bool flag = false;
          int num27 = 0;
          int num28 = 0;
          int num29 = 0;
          num2 = num27 + numArray10[index39, index45];
          num1 = num28 + numArray11[index39, index45];
          num20 = num29 + numArray12[index39, index45];
          if (num2 > 0 | num1 > 0 | num20 > 0)
            flag = true;
          if (flag & this.game.Data.TempString[400 + index45].Length > 1)
          {
            string str87 = Strings.Left(this.game.Data.TempString[400 + index45], 29);
            string str88 = str87 + Strings.Space(30 - str87.Length);
            string str89 = str86 + str88;
            string str90 = Strings.Left(num2.ToString(), 19);
            string str91 = str90 + Strings.Space(15 - str90.Length);
            string str92 = str89 + str91;
            string str93 = Strings.Left(num1.ToString(), 19);
            string str94 = str93 + Strings.Space(15 - str93.Length);
            string str95 = str92 + str94;
            string str96 = Strings.Left(num20.ToString(), 19);
            string str97 = str96 + Strings.Space(15 - str96.Length);
            str86 = str95 + str97 + "\r\n";
          }
          ++index45;
        }
        while (index45 <= 99);
        string str98 = str86 + "\r\n" + "FUEL USAGE PER UNIT FOR " + this.game.Data.RegimeObj[index39].Name.ToUpper() + "\r\n";
        string str99 = "UNIT";
        string str100 = str99 + Strings.Space(30 - str99.Length);
        string str101 = str98 + str100;
        string str102 = "10R.OFF.COMBAT";
        string str103 = str102 + Strings.Space(15 - str102.Length);
        string str104 = str101 + str103;
        string str105 = "100AP.MOVEMENT";
        string str106 = str105 + Strings.Space(15 - str105.Length);
        string str107 = str104 + str106;
        string str108 = "10R.DEF.COMBAT";
        string str109 = str108 + Strings.Space(15 - str108.Length);
        string str110 = str107 + str109 + "\r\n";
        int unitCounter6 = this.game.Data.UnitCounter;
        for (int index46 = 0; index46 <= unitCounter6; ++index46)
        {
          bool flag = false;
          index1 = index46;
          if (this.game.Data.UnitObj[index1].Regime == index39 & this.game.Data.UnitObj[index1].PreDef == -1)
          {
            flag = true;
            int num30 = 0;
            int num31 = 0;
            int num32 = 0;
            num2 = num30 + numArray1[index46];
            num1 = num31 + numArray2[index46];
            num20 = num32 + numArray3[index46];
          }
          if (flag)
          {
            string str111 = Strings.Left(this.game.Data.UnitObj[index1].Name, 29);
            string str112 = str111 + Strings.Space(30 - str111.Length);
            string str113 = str110 + str112;
            string str114 = Strings.Left(num2.ToString(), 19);
            string str115 = str114 + Strings.Space(15 - str114.Length);
            string str116 = str113 + str115;
            string str117 = Strings.Left(num1.ToString(), 19);
            string str118 = str117 + Strings.Space(15 - str117.Length);
            string str119 = str116 + str118;
            string str120 = Strings.Left(num20.ToString(), 19);
            string str121 = str120 + Strings.Space(15 - str120.Length);
            str110 = str119 + str121 + "\r\n";
          }
        }
        string str122 = str110 + "\r\n" + "SUPPLY USAGE PER UNIT FOR " + this.game.Data.RegimeObj[index39].Name.ToUpper() + "\r\n";
        string str123 = "UNIT";
        string str124 = str123 + Strings.Space(30 - str123.Length);
        string str125 = str122 + str124;
        string str126 = "10R.OFF.COMBAT";
        string str127 = str126 + Strings.Space(15 - str126.Length);
        string str128 = str125 + str127;
        string str129 = "10R.DEF.COMBAT";
        string str130 = str129 + Strings.Space(15 - str129.Length);
        string str131 = str128 + str130;
        string str132 = "UPKEEP ONLY";
        string str133 = str132 + Strings.Space(15 - str132.Length);
        str1 = str131 + str133 + "\r\n";
        int unitCounter7 = this.game.Data.UnitCounter;
        for (int index47 = 0; index47 <= unitCounter7; ++index47)
        {
          bool flag = false;
          if (index47 > -1)
          {
            index1 = index47;
            if (this.game.Data.UnitObj[index1].Regime == index39 & this.game.Data.UnitObj[index1].PreDef == -1)
            {
              flag = true;
              int num33 = 0;
              int num34 = 0;
              int num35 = 0;
              num2 = num33 + numArray4[index47];
              num1 = num34 + numArray5[index47];
              num20 = num35 + numArray6[index47];
            }
          }
          if (flag)
          {
            string str134 = Strings.Left(this.game.Data.UnitObj[index1].Name, 29);
            string str135 = str134 + Strings.Space(30 - str134.Length);
            string str136 = str1 + str135;
            string str137 = Strings.Left(num2.ToString(), 19);
            string str138 = str137 + Strings.Space(15 - str137.Length);
            string str139 = str136 + str138;
            string str140 = Strings.Left(num1.ToString(), 19);
            string str141 = str140 + Strings.Space(15 - str140.Length);
            string str142 = str139 + str141;
            string str143 = Strings.Left(num20.ToString(), 19);
            string str144 = str143 + Strings.Space(15 - str143.Length);
            str1 = str142 + str144 + "\r\n";
          }
        }
      }
      return str1;
    }

    private string DiagnosticsPower()
    {
      SimpleList simpleList1 = new SimpleList();
      SimpleList simpleList2 = new SimpleList();
      int[] numArray1 = new int[this.game.Data.UnitCounter + 1];
      int unitCounter1 = this.game.Data.UnitCounter;
      int index1;
      int num1;
      for (index1 = 0; index1 <= unitCounter1; ++index1)
      {
        if (this.game.Data.UnitObj[index1].PreDef == -1)
        {
          int historical = this.game.Data.UnitObj[index1].Historical;
          int regime = this.game.Data.UnitObj[index1].Regime;
          if (historical > -1)
          {
            if (this.game.Data.HistoricalUnitObj[historical].Type >= 5)
              simpleList1.Add(index1, this.game.Data.HistoricalUnitObj[historical].Type);
            int sfCount = this.game.Data.UnitObj[index1].SFCount;
            for (int index2 = 0; index2 <= sfCount; ++index2)
            {
              int sf = this.game.Data.UnitObj[index1].SFList[index2];
              int type = this.game.Data.SFObj[sf].Type;
              int unitGroup = this.game.Data.SFTypeObj[type].UnitGroup;
              int qty = this.game.Data.SFObj[sf].Qty;
              num1 = this.game.Data.SFTypeObj[type].PowerPts * qty;
              int[] numArray2 = numArray1;
              int[] numArray3 = numArray2;
              int index3 = index1;
              int index4 = index3;
              int num2 = numArray2[index3] + num1;
              numArray3[index4] = num2;
            }
          }
        }
      }
      simpleList1.ReverseSortHighSpeed();
      int regimeCounter1 = this.game.Data.RegimeCounter;
      string str1;
      for (int index5 = 0; index5 <= regimeCounter1; ++index5)
      {
        string str2 = str1 + "\r\n" + "POWER CUMULATIVE TOTALS FOR " + this.game.Data.RegimeObj[index5].Name.ToUpper() + "\r\n";
        string str3 = "ALL UNDER HQ";
        string str4 = str3 + Strings.Space(30 - str3.Length);
        string str5 = str2 + str4;
        string str6 = "POWER PTS";
        string str7 = str6 + Strings.Space(15 - str6.Length);
        str1 = str5 + str7 + "\r\n";
        int counter = simpleList1.Counter;
        for (int index6 = -1; index6 <= counter; ++index6)
        {
          bool flag = false;
          int num3;
          int num4;
          if (index6 > -1)
          {
            index1 = simpleList1.Id[index6];
            if (this.game.Data.UnitObj[index1].Regime == index5)
            {
              flag = true;
              num1 = 0;
              num3 = 0;
              num4 = 0;
              int unitCounter2 = this.game.Data.UnitCounter;
              for (int unr = 0; unr <= unitCounter2; ++unr)
              {
                if (this.game.HandyFunctionsObj.IsUnitInHQChain(unr, index1))
                  num1 += numArray1[unr];
              }
            }
          }
          else
          {
            flag = true;
            num1 = 0;
            num3 = 0;
            num4 = 0;
            int unitCounter3 = this.game.Data.UnitCounter;
            for (int index7 = 0; index7 <= unitCounter3; ++index7)
            {
              if (this.game.Data.UnitObj[index7].Regime == index5 & this.game.Data.UnitObj[index7].PreDef == -1)
                num1 += numArray1[index7];
            }
          }
          if (flag)
          {
            string str8 = index6 != -1 ? Strings.Left(this.game.Data.UnitObj[index1].Name, 29) : "TOTAL POWER";
            string str9 = str8 + Strings.Space(30 - str8.Length);
            string str10 = str1 + str9;
            string str11 = Strings.Left(num1.ToString(), 19);
            string str12 = str11 + Strings.Space(15 - str11.Length);
            str1 = str10 + str12 + "\r\n";
          }
        }
      }
      string str13 = str1 + "\r\n";
      int num5 = 0;
      int[] numArray4 = new int[100];
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index8 = 0; index8 <= mapWidth; ++index8)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index9 = 0; index9 <= mapHeight; ++index9)
        {
          num5 += this.game.Data.MapObj[0].HexObj[index8, index9].VP;
          if (this.game.Data.MapObj[0].HexObj[index8, index9].Regime > -1)
          {
            int[] numArray5 = numArray4;
            int[] numArray6 = numArray5;
            int regime = this.game.Data.MapObj[0].HexObj[index8, index9].Regime;
            int index10 = regime;
            int num6 = numArray5[regime] + this.game.Data.MapObj[0].HexObj[index8, index9].VP;
            numArray6[index10] = num6;
          }
        }
      }
      string str14 = str13 + "TOTAL VP ON MAP: " + num5.ToString() + "\r\n";
      int regimeCounter2 = this.game.Data.RegimeCounter;
      for (int index11 = 0; index11 <= regimeCounter2; ++index11)
        str14 = str14 + "Held by " + this.game.Data.RegimeObj[index11].Name + " : " + numArray4[index11].ToString() + "\r\n";
      return str14;
    }

    private string RemoveSFTypeLogoTextRemnants(bool testing)
    {
      string Left = "";
      int num;
      for (int sfTypeCounter = this.game.Data.SFTypeCounter; sfTypeCounter >= 0; sfTypeCounter += -1)
      {
        bool flag = false;
        int index = 99;
        do
        {
          if (!Information.IsNothing((object) this.game.Data.SFTypeObj[sfTypeCounter].LogoString[index]) && this.game.Data.SFTypeObj[sfTypeCounter].LogoString[index].Length > 0)
          {
            if (Strings.InStr(this.game.Data.SFTypeObj[sfTypeCounter].LogoString[index], "'") > 0)
              flag = true;
            if (Strings.InStr(this.game.Data.SFTypeObj[sfTypeCounter].LogoString[index], "\"") > 0)
              flag = true;
          }
          if (flag)
          {
            string str = "SFTYPE#" + sfTypeCounter.ToString() + ", LOGOSTRING#" + index.ToString() + " : " + this.game.Data.SFTypeObj[sfTypeCounter].LogoString[index];
            if (testing)
            {
              Left = Left + "FOUND A LOGO TEXT ISSUE " + str + "\r\n";
            }
            else
            {
              Left = Left + "FIXED A LOGO TEXT ISSUE " + str + "\r\n";
              this.game.Data.SFTypeObj[sfTypeCounter].LogoString[index].Replace("'", "");
              this.game.Data.SFTypeObj[sfTypeCounter].LogoString[index] = this.game.Data.SFTypeObj[sfTypeCounter].LogoString[index].Replace("\"", "");
            }
            ++num;
          }
          index += -1;
        }
        while (index >= 0);
      }
      if (num > 0)
        Left = (!testing ? Left + "TOTAL SFTTYPE LOGO TEXT ISSUES DELETED = " + num.ToString() + "\r\n" : Left + "TOTAL SFTTYPE LOGO TEXT ISSUES FOUND = " + num.ToString() + "\r\n") + "NOTE: logo text issue is the finding of a weird character like ' in a SFType Logostring. ";
      if (Operators.CompareString(Left, "", false) == 0)
        Left = "NO SFTTYPE LOGO TEXT ISSUES FOUND";
      return Left;
    }
  }
}
