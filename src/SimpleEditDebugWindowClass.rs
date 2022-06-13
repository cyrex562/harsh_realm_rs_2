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
  pub class SimpleEditDebugWindowClass : WindowClass
  {
     int listId;
     ListClass listObj;
     int textId;
     int text2id;
     int text3id;
     int detailnr;
     int opt4id;
     int powId;
     int opt3id;
     int opt1id;
     int opt2id;
     int opt1bid;
     int outputid;
     int fuelId;
     int text4id;
     int text5id;
     int opt5id;
     bool outputFixedSys;
     string output;

    pub SimpleEditDebugWindowClass( GameClass tGame)
      : base( tGame, tGame.ScreenWidth, tGame.ScreenHeight - 50, 9, tDoBorders: 1, tHeaderString: "Debug Options")
    {
      this.detailnr = -1;
      this.DoStuff();
    }

    pub void PopUpRefresh() => this.DoStuff();

    pub void DoStuff()
    {
      let mut num1: i32 =  Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
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
      let mut y1: i32 = 50;
      tText1: String = "Run this correction algorithm to remove any unassigned duplicate officers. ";
      DrawMod.DrawTextColouredMarc( objgraphics, "Duplicates", this.game.MarcFont1, num1 + 25, y1, Color.White);
      let mut num2: i32 = y1 + 0;
      let mut tsubpart: SubPartClass =  new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, tText1, 27,  this.OwnBitmap, num1 + 10, num2, true, true);
      this.text2id = this.AddSubPart( tsubpart, num1 + 10, num2, 450, 108, 0);
      let mut num3: i32 = num2 + 100;
      tsubpart =  new TextButtonPartClass("Check problems", 160, tBackbitmap: ( this.OwnBitmap), bbx: (num1 + 25), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.opt1id = this.AddSubPart( tsubpart, num1 + 25, num3, 160, 35, 1);
      tsubpart =  new TextButtonPartClass("Remove problems", 160, tBackbitmap: ( this.OwnBitmap), bbx: (num1 + 180 + 25), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.opt1bid = this.AddSubPart( tsubpart, num1 + 180 + 25, num3, 160, 35, 1);
      let mut y2: i32 = num3 + 50;
      tText2: String = "Run these algorithms to obtain specific diagnostics. ";
      DrawMod.DrawTextColouredMarc( objgraphics, "Diagnostics", this.game.MarcFont1, num1 + 25, y2, Color.White);
      let mut num4: i32 = y2 + 0;
      tsubpart =  new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, tText2, 27,  this.OwnBitmap, num1 + 10, num4, true, true);
      this.text2id = this.AddSubPart( tsubpart, num1 + 10, num4, 450, 108, 0);
      let mut num5: i32 = num4 + 70;
      tsubpart =  new TextButtonPartClass("TroopType Libs", 160, tBackbitmap: ( this.OwnBitmap), bbx: (num1 + 25), bby: num5, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.opt2id = this.AddSubPart( tsubpart, num1 + 25, num5, 160, 35, 1);
      tsubpart =  new TextButtonPartClass("Memory Use", 160, tBackbitmap: ( this.OwnBitmap), bbx: (num1 + 25 + 180), bby: num5, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.opt4id = this.AddSubPart( tsubpart, num1 + 25 + 180, num5, 160, 35, 1);
      let mut num6: i32 = num5 + 50;
      tsubpart =  new TextButtonPartClass("Supply/Fuel Prog.", 160, "Get a prognosis",  this.OwnBitmap, num1 + 25, num6, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.fuelId = this.AddSubPart( tsubpart, num1 + 25, num6, 160, 35, 1);
      tsubpart =  new TextButtonPartClass("Power Pts", 160, "Get a tally",  this.OwnBitmap, num1 + 25 + 180, num6, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.powId = this.AddSubPart( tsubpart, num1 + 25 + 180, num6, 160, 35, 1);
      let mut y3: i32 = num6 + 50;
      tText3: String = "Press these buttons to re-connect a masterfile. ";
      DrawMod.DrawTextColouredMarc( objgraphics, "Masterfile reconnect", this.game.MarcFont1, num1 + 25, y3, Color.White);
      let mut num7: i32 = y3 + 0;
      tsubpart =  new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, tText3, 27,  this.OwnBitmap, num1 + 10, num7, true, true);
      this.text3id = this.AddSubPart( tsubpart, num1 + 10, num7, 450, 108, 0);
      let mut num8: i32 = num7 + 70;
      tsubpart =  new TextButtonPartClass("VR Master", 160, tBackbitmap: ( this.OwnBitmap), bbx: (num1 + 25), bby: num8, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.opt3id = this.AddSubPart( tsubpart, num1 + 25, num8, 160, 35, 1);
      let mut y4: i32 = num8 + 50;
      tText4: String = "Use these buttons with caution! ";
      DrawMod.DrawTextColouredMarc( objgraphics, "Batch Scripts", this.game.MarcFont1, num1 + 25, y4, Color.White);
      let mut num9: i32 = y4 + 0;
      tsubpart =  new TextAreaClass2(this.game, 450, 4, this.game.MarcFont3, tText4, 27,  this.OwnBitmap, num1 + 10, num9, true, true);
      this.text3id = this.AddSubPart( tsubpart, num1 + 10, num9, 450, 108, 0);
      let mut num10: i32 = num9 + 70;
      tsubpart =  new TextButtonPartClass("Mass Move Units", 160, tBackbitmap: ( this.OwnBitmap), bbx: (num1 + 25), bby: num10, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.opt5id = this.AddSubPart( tsubpart, num1 + 25, num10, 160, 35, 1);
      str: String = this.output;
      DrawMod.DrawTextColouredMarc( objgraphics, "CONSOLE", this.game.MarcFont4, 510 + num1, 70, Color.White);
      if (Operators.CompareString(str, "", false) == 0)
        str = "No output... run a debug function to receive output.";
      if (this.outputFixedSys)
      {
        tsubpart =  new TextAreaClass2(this.game,  Math.Round(Math.Min(800.0, (double) this.game.ScreenWidth / 2.0 - 50.0)),  Math.Round((double) Math.Max(120, this.game.ScreenHeight - 260) / 27.0), this.game.MarcFont4b, str, 27,  this.OwnBitmap, 510 + num1, 80, tDarkerFrame: true);
        this.outputid = this.AddSubPart( tsubpart, 510 + num1, 80,  Math.Round(Math.Min(800.0, (double) this.game.ScreenWidth / 2.0 - 50.0)), Math.Max(120, this.game.ScreenHeight - 260), 0);
      }
      else
      {
        tsubpart =  new TextAreaClass2(this.game,  Math.Round(Math.Min(800.0, (double) this.game.ScreenWidth / 2.0 - 50.0)),  Math.Round((double) Math.Max(120, this.game.ScreenHeight - 260) / 27.0), this.game.MarcFont4, str, 27,  this.OwnBitmap, 510 + num1, 80);
        this.outputid = this.AddSubPart( tsubpart, 510 + num1, 80,  Math.Round(Math.Min(800.0, (double) this.game.ScreenWidth / 2.0 - 50.0)), Math.Max(120, this.game.ScreenHeight - 260), 0);
      }
      this.outputFixedSys = false;
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 = this.SubPartCounter;
        for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            let mut num: i32 = this.SubPartID[index];
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
              let mut deltaX: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Delta for X move", "Shadow Empire : Planetary Conquest")));
              let mut deltaY: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Delta for Y move", "Shadow Empire : Planetary Conquest")));
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
                filename: String = this.game.AppPath + this.game.ModScenarioDir + "/" + this.game.Data.MasterFile;
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

     string Batch_MassMoveUnits(int deltaX, int deltaY)
    {
      Left: String = "";
      int y;
      for (let mut unitCounter1: i32 = this.game.Data.UnitCounter; unitCounter1 >= 0; unitCounter1 += -1)
      {
        if (unitCounter1 <= this.game.Data.UnitCounter && this.game.Data.UnitObj[unitCounter1].PreDef == -1 & this.game.Data.UnitObj[unitCounter1].X > -1)
        {
          let mut x: i32 = this.game.Data.UnitObj[unitCounter1].X;
          y = this.game.Data.UnitObj[unitCounter1].Y;
          let mut num: i32 = x + deltaX;
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
              this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].OffLibId = LibIdClass::new();
              this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].LibId = libIdClass;
              this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].Pool = true;
            }
            GameClass gameClass;
            if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].LibId.libSlot == -1)
            {
              this.game.Data.RemoveHistoricalUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical);
              for (let mut unitCounter2: i32 = this.game.Data.UnitCounter; unitCounter2 >= 0; unitCounter2 += -1)
              {
                if (this.game.Data.UnitObj[unitCounter2].PreDef == -1 & this.game.Data.UnitObj[unitCounter2].Historical == -1)
                {
                  data: DataClass = this.game.Data;
                  let mut nr: i32 = unitCounter2;
                  gameClass = (GameClass) null;
                   let mut local: GameClass =  gameClass;
                  data.RemoveUnit(nr,  local);
                }
              }
            }
            else
            {
              let mut historical: i32 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical;
              for (let mut unitCounter3: i32 = this.game.Data.UnitCounter; unitCounter3 >= 0; unitCounter3 += -1)
              {
                if (this.game.Data.UnitObj[unitCounter3].Historical == historical)
                {
                  this.game.Data.UnitObj[unitCounter3].Historical = -1;
                  data: DataClass = this.game.Data;
                  let mut nr: i32 = unitCounter3;
                  gameClass = (GameClass) null;
                   let mut local: GameClass =  gameClass;
                  data.RemoveUnit(nr,  local);
                }
              }
            }
            this.game.EditObj.UnitSelected = -1;
          }
        }
      }
      for (let mut unitCounter: i32 = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
      {
        if (this.game.Data.UnitObj[unitCounter].PreDef == -1 & this.game.Data.UnitObj[unitCounter].X > -1)
        {
          let mut x: i32 = this.game.Data.UnitObj[unitCounter].X;
          y = this.game.Data.UnitObj[unitCounter].Y;
          if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[x, y].LandscapeType].IsSea)
            this.game.Data.MapObj[0].HexObj[x, y].Regime = this.game.Data.UnitObj[unitCounter].Regime;
        }
      }
      if (Operators.CompareString(Left, "", false) == 0)
        Left = "NO UNITS FOUND";
      return Left;
    }

     string RemoveDuplicateOfficers(bool testing)
    {
      Left1: String = "";
      int num1;
      for (let mut historicalUnitCounter: i32 = this.game.Data.HistoricalUnitCounter; historicalUnitCounter >= 0; historicalUnitCounter += -1)
      {
        if (this.game.Data.HistoricalUnitObj[historicalUnitCounter].CommanderName.Length > 0 && this.game.Data.HistoricalUnitObj[historicalUnitCounter].OffLibId.libSlot == -1 & !this.game.Data.HistoricalUnitObj[historicalUnitCounter].Pool | this.game.Data.HistoricalUnitObj[historicalUnitCounter].LibId.libSlot == -1 & this.game.Data.HistoricalUnitObj[historicalUnitCounter].Pool)
        {
          str: String = Left1 + "COMMANDER WITHOUT LIBRARY '" + this.game.Data.HistoricalUnitObj[historicalUnitCounter].CommanderName + "' (pool=" + this.game.Data.HistoricalUnitObj[historicalUnitCounter].Pool.ToString() + ")...";
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
          num1 += 1;
        }
      }
      if (num1 > 0)
        Left1 = (!testing ? Left1 + "TOTAL COMMANDER WITHOUT LIBRARY DELETED = " + num1.ToString() + "\r\n" : Left1 + "TOTAL COMMANDER WITHOUT LIBRARY FOUND = " + num1.ToString() + "\r\n") + "NOTE: If Commanders without historical library get deleted you might want to double check everybody is still present.. or reload officer library.";
      if (Operators.CompareString(Left1, "", false) == 0)
        Left1 = "NO COMMANDER WITHOUT LIBRARY FOUND";
      str1: String = Left1;
      Left2: String = "";
      int num2;
      for (let mut historicalUnitCounter1: i32 = this.game.Data.HistoricalUnitCounter; historicalUnitCounter1 >= 0; historicalUnitCounter1 += -1)
      {
        if (this.game.Data.HistoricalUnitObj[historicalUnitCounter1].CommanderName.Length > 0 && this.game.Data.HistoricalUnitObj[historicalUnitCounter1].OffLibId.libSlot == -1 & this.game.Data.HistoricalUnitObj[historicalUnitCounter1].Pool)
        {
          bool flag = false;
          for (let mut historicalUnitCounter2: i32 = this.game.Data.HistoricalUnitCounter; historicalUnitCounter2 >= 0; historicalUnitCounter2 += -1)
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
            str2: String = "COMMANDER '" + this.game.Data.HistoricalUnitObj[historicalUnitCounter1].CommanderName + "' (pool=" + this.game.Data.HistoricalUnitObj[historicalUnitCounter1].Pool.ToString() + ")...";
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
            num2 += 1;
          }
        }
      }
      if (num2 > 0)
        Left2 = (!testing ? Left2 + "TOTAL DUPLICATES DELETED = " + num2.ToString() + "\r\n" : Left2 + "TOTAL DUPLICATES FOUND = " + num2.ToString() + "\r\n") + "NOTE: A duplicate in this case is a historical unit slot with commander info, not assigned to a unit, who has a slot with the same library and libraryID in a lower historical slot.";
      if (Operators.CompareString(Left2, "", false) == 0)
        Left2 = "NO DUPLICATES FOUND";
      return str1 + "\r\n" + Left2;
    }

     string RemoveDuplicateTroopTypeLibs(bool testing)
    {
      Left: String = "";
      int num1;
      for (let mut libraryCounter1: i32 = this.game.Data.LibraryCounter; libraryCounter1 >= 0; libraryCounter1 += -1)
      {
        bool flag = false;
        let mut num2: i32 = -1;
        for (let mut libraryCounter2: i32 = this.game.Data.LibraryCounter; libraryCounter2 >= 0; libraryCounter2 += -1)
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
          str: String = "TroopType Library '" + this.game.Data.LibraryObj[libraryCounter1].name + "'";
          Left = !testing ? Left + "DELETED DUPLICATE " + str + "\r\n" : Left + "FOUND A DUPLICATE " + str + "\r\n";
          bool[] flagArray = new bool[this.game.Data.SFTypeCounter + 1];
          let mut unitCounter: i32 = this.game.Data.UnitCounter;
          for (let mut index1: i32 = 0; index1 <= unitCounter; index1 += 1)
          {
            let mut sfCount: i32 = this.game.Data.UnitObj[index1].SFCount;
            for (let mut index2: i32 = 0; index2 <= sfCount; index2 += 1)
            {
              let mut sf: i32 = this.game.Data.UnitObj[index1].SFList[index2];
              let mut type: i32 = this.game.Data.SFObj[sf].Type;
              if (this.game.Data.SFTypeObj[type].LibId.libSlot == libraryCounter1)
              {
                let mut sfTypeCounter: i32 = this.game.Data.SFTypeCounter;
                for (let mut index3: i32 = 0; index3 <= sfTypeCounter; index3 += 1)
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
            num1 += 1;
          }
        }
      }
      if (num1 > 0)
        Left = (!testing ? Left + "TOTAL DUPLICATES DELETED = " + num1.ToString() + "\r\n" : Left + "TOTAL DUPLICATES FOUND = " + num1.ToString() + "\r\n") + "NOTE: The duplicate TroopType library with lowest OR same version (but highest in list) will be deleted. Deleting of duplicate troopType libraries with different contents can cause links to be broken and troops to dissapear as a result.";
      if (Operators.CompareString(Left, "", false) == 0)
        Left = "NO DUPLICATES FOUND";
      return Left;
    }

     string RemoveDuplicateHistoricals(bool testing)
    {
      let mut num1: i32 = 0;
      str1: String = "";
      for (let mut historicalUnitCounter: i32 = this.game.Data.HistoricalUnitCounter; historicalUnitCounter >= 0; historicalUnitCounter += -1)
      {
        if (this.game.Data.HistoricalUnitObj[historicalUnitCounter].ModelMaster > -1 && this.game.Data.HistoricalUnitObj[historicalUnitCounter].LibId.libSlot == -1 && this.game.HandyFunctionsObj.GetUnitByHistorical(historicalUnitCounter) == -1)
        {
          num1 += 1;
          str2: String = str1 + "* Found Historical Unit witout library NOT assigned to Map Units [" + this.game.Data.HistoricalUnitObj[historicalUnitCounter].Name + " (" + this.game.Data.HistoricalUnitObj[historicalUnitCounter].ID.ToString() + ")]";
          if (!testing)
            str2 += "<WILL DELETE!>";
          if (!testing)
            this.game.Data.RemoveHistoricalUnit(historicalUnitCounter);
          str1 = str2 + "\r\n";
        }
      }
      let mut num2: i32 = 0;
      for (let mut unitCounter: i32 = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
      {
        if (this.game.Data.UnitObj[unitCounter].PreDef == -1 & this.game.Data.UnitObj[unitCounter].Historical == -1)
        {
          num2 += 1;
          str3: String = str1 + "* Found Unit that is not assigned to a historical [" + this.game.Data.UnitObj[unitCounter].Name + " (" + this.game.Data.UnitObj[unitCounter].X.ToString() + "," + this.game.Data.UnitObj[unitCounter].Y.ToString() + ")]";
          if (!testing)
            str3 += "<WILL DELETE!>";
          if (!testing)
          {
            data: DataClass = this.game.Data;
            let mut nr: i32 = unitCounter;
            let mut gameClass: GameClass = (GameClass) null;
             let mut local: GameClass =  gameClass;
            data.RemoveUnit(nr,  local);
          }
          str1 = str3 + "\r\n";
        }
      }
      for (let mut historicalUnitCounter: i32 = this.game.Data.HistoricalUnitCounter; historicalUnitCounter >= 0; historicalUnitCounter += -1)
      {
        if (this.game.Data.HistoricalUnitObj[historicalUnitCounter].ModelMaster > -1 && this.game.Data.HistoricalUnitObj[historicalUnitCounter].LibId.libSlot > -1 && this.game.HandyFunctionsObj.GetUnitByHistorical(historicalUnitCounter) == -1)
        {
          num1 += 1;
          str4: String = str1 + "* Found Historical Unit witout library NOT assigned to Map Units [" + this.game.Data.HistoricalUnitObj[historicalUnitCounter].Name + " (" + this.game.Data.HistoricalUnitObj[historicalUnitCounter].ID.ToString() + ")]";
          if (!testing)
            str4 += "<WILL DELETE!>";
          if (!testing)
            this.game.Data.RemoveHistoricalUnit(historicalUnitCounter);
          str1 = str4 + "\r\n";
        }
      }
      let mut num3: i32 = 0;
      let mut historicalUnitCounter1: i32 = this.game.Data.HistoricalUnitCounter;
      for (let mut index1: i32 = 0; index1 <= historicalUnitCounter1; index1 += 1)
      {
        if (this.game.Data.HistoricalUnitObj[index1].Model)
        {
          bool flag = false;
          str5: String = "";
          let mut historicalUnitCounter2: i32 = this.game.Data.HistoricalUnitCounter;
          for (let mut index2: i32 = 0; index2 <= historicalUnitCounter2; index2 += 1)
          {
            if (this.game.Data.HistoricalUnitObj[index2].Model && index2 >= index1 && this.game.Data.HistoricalUnitObj[index1].LibId.libSlot == this.game.Data.HistoricalUnitObj[index2].LibId.libSlot && Operators.CompareString(this.game.Data.HistoricalUnitObj[index1].Name, this.game.Data.HistoricalUnitObj[index2].Name, false) == 0)
            {
              if (index2 > index1)
                flag = true;
              str6: String = "Libname: -none-";
              if (this.game.Data.HistoricalUnitObj[index2].LibId.libSlot > -1)
                str6 = "Libname: " + this.game.Data.LibraryObj[this.game.Data.HistoricalUnitObj[index2].LibId.libSlot].name + " & LibID=" + this.game.Data.HistoricalUnitObj[index2].LibId.id.ToString();
              str5 = str5 + "(" + str6 + ") ";
            }
          }
          if (flag)
          {
            num3 += 1;
            str1 = str1 + "* Duplicate name: " + this.game.Data.HistoricalUnitObj[index1].Name + ": " + str5 + "\r\n";
          }
        }
      }
      str7: String = str1 + "\r\n";
      str8: String = (num1 <= 0 ? str7 + "NO NON-LIBRARY HIS.UNITS WITHOUT UNITS FOUND " : (!testing ? str7 + "TOTAL NON-LIBRARY HIS.UNITS WITHOUT UNITS DELETED = " + num1.ToString() : str7 + "TOTAL NON-LIBRARY HIS.UNITS WITHOUT UNITS FOUND = " + num1.ToString())) + "\r\n";
      str9: String = (num2 <= 0 ? str8 + "NO NUNITS ON MAP WITHOUT HISTORICAL ATTACHED FOUND " : (!testing ? str8 + "TOTAL UNITS ON MAP WITHOUT HISTORICAL ATTACHED DELETED = " + num2.ToString() : str8 + "TOTAL UNITS ON MAP WITHOUT HISTORICAL ATTACHED FOUND = " + num2.ToString())) + "\r\n";
      return (num3 <= 0 ? str9 + "NO DOUBLE NAME MODEL HISTORICAL UNITS FOUND" : (!testing ? str9 + "TOTAL DOUBLE NAME MODEL HISTORICAL UNITS FOUND = " + num3.ToString() : str9 + "TOTAL DOUBLE NAME MODEL HISTORICAL UNITS FOUND = " + num3.ToString())) + "\r\n" + "Note: Duplicate names are not neccessarily a problem. Hence they are NOT a problem that will be fixed." + "\r\n";
    }

     string RemoveDuplicateTroopTypeInSameLib(bool testing)
    {
      bool[] flagArray = new bool[this.game.Data.SFTypeCounter + 1];
      str1: String = "";
      int nr;
      int num;
      for (let mut libraryCounter: i32 = this.game.Data.LibraryCounter; libraryCounter >= 0; libraryCounter += -1)
      {
        if (this.IsTroopTypeLibrary(libraryCounter))
        {
          str1 = str1 + "TroopType Library '" + this.game.Data.LibraryObj[libraryCounter].name + "\r\n";
          let mut sfTypeCounter1: i32 = this.game.Data.SFTypeCounter;
          for (nr = 0; nr <= sfTypeCounter1; nr += 1)
          {
            if (this.game.Data.SFTypeObj[nr].LibId.libSlot == libraryCounter)
            {
              let mut sfTypeCounter2: i32 = this.game.Data.SFTypeCounter;
              for (let mut index1: i32 = 0; index1 <= sfTypeCounter2; index1 += 1)
              {
                if (nr != index1 & index1 > nr && this.game.Data.SFTypeObj[index1].LibId.libSlot == libraryCounter && this.game.Data.SFTypeObj[index1].LibId.id == this.game.Data.SFTypeObj[nr].LibId.id)
                {
                  str2: String = str1 + "* Found duplicate SFType slot#" + nr.ToString() + ", " + this.game.Data.SFTypeObj[nr].Name + ", and slot#" + index1.ToString() + ", " + this.game.Data.SFTypeObj[nr].Name + ".";
                  num += 1;
                  flagArray[index1] = true;
                  if (!testing)
                  {
                    let mut unitCounter: i32 = this.game.Data.UnitCounter;
                    for (let mut index2: i32 = 0; index2 <= unitCounter; index2 += 1)
                    {
                      let mut sfCount: i32 = this.game.Data.UnitObj[index2].SFCount;
                      for (let mut index3: i32 = 0; index3 <= sfCount; index3 += 1)
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
        str4: String = str1 + "\r\n";
        str3 = !testing ? str4 + "TOTAL DUPLICATES DELETED = " + num.ToString() : str4 + "TOTAL DUPLICATES FOUND = " + num.ToString();
      }
      else
        str3 = str1 + "NO DUPLICATES FOUND";
      return str3;
    }

     bool IsTroopTypeLibrary(int libslot)
    {
      let mut sfTypeCounter: i32 = this.game.Data.SFTypeCounter;
      for (let mut index: i32 = 0; index <= sfTypeCounter; index += 1)
      {
        if (this.game.Data.SFTypeObj[index].LibId.libSlot == libslot)
          return true;
      }
      return false;
    }

     string DiagnosticsTroopTypeLibs()
    {
      let mut libraryCounter: i32 = this.game.Data.LibraryCounter;
      string str;
      for (let mut index1: i32 = 0; index1 <= libraryCounter; index1 += 1)
      {
        bool flag1 = false;
        let mut sfTypeCounter: i32 = this.game.Data.SFTypeCounter;
        for (let mut index2: i32 = 0; index2 <= sfTypeCounter; index2 += 1)
        {
          if (this.game.Data.SFTypeObj[index2].LibId.libSlot == index1)
          {
            if (!flag1)
            {
              str = str + "\r\n" + "Library Slot: " + index1.ToString() + ", Name: " + this.game.Data.LibraryObj[index1].name + "\r\n";
              flag1 = true;
            }
            let mut num: i32 = 0;
            let mut unitCounter: i32 = this.game.Data.UnitCounter;
            for (let mut index3: i32 = 0; index3 <= unitCounter; index3 += 1)
            {
              bool flag2 = false;
              let mut sfCount: i32 = this.game.Data.UnitObj[index3].SFCount;
              for (let mut index4: i32 = 0; index4 <= sfCount; index4 += 1)
              {
                if (this.game.Data.SFObj[this.game.Data.UnitObj[index3].SFList[index4]].Type == index2)
                  flag2 = true;
              }
              if (flag2)
                num += 1;
            }
            str = str + "*" + this.game.Data.SFTypeObj[index2].Name + ", slot: " + index2.ToString() + ", libID = " + this.game.Data.SFTypeObj[index2].LibId.id.ToString() + ", unitsUsing: " + num.ToString() + "\r\n";
          }
        }
      }
      return str;
    }

     string DiagnosticsGraphicsMem()
    {
      string[] strArray = new string[BitmapStore.Counter + 1];
      SimpleList simpleList = SimpleList::new();
      string str1;
      str2: String = str1 + "TOTAL MEMORY USAGE" + "\r\n";
      let mut counter1: i32 = BitmapStore.Counter;
      int index1;
      int num1;
      int num2;
      int num3;
      int num4;
      string str3;
      for (let mut index2: i32 = 0; index2 <= counter1; index2 += 1)
      {
        index1 = BitmapStore.GetMemorySize(index2, 0, 1);
        let mut memorySize1: i32 = BitmapStore.GetMemorySize(index2, 1, 1);
        let mut memorySize2: i32 = BitmapStore.GetMemorySize(index2, -1, 1);
        let mut memorySize3: i32 = BitmapStore.GetMemorySize(index2, 0, 2);
        num1 += index1;
        num2 += memorySize1;
        num3 += memorySize2;
        num4 += memorySize3;
        str3 = BitmapStore.tmpFileName[index2] + ": REG: " + index1.ToString() + "K, BIG: " + memorySize1.ToString() + "K, SMALL: " + memorySize2.ToString() + "K, CACHE: " + memorySize3.ToString() + "K";
        strArray[index2] = str3;
        simpleList.Add(index2, index1 + memorySize1 + memorySize2 + memorySize3);
      }
      str4: String = str2 + "BITMAPSTORE REG: " + num1.ToString() + "K, BIG: " + num2.ToString() + "K, SMALL: " + num3.ToString() + "K, CACHE: " + num4.ToString() + "K" + "\r\n";
      BinaryFormatter binaryFormatter = BinaryFormatter::new();
      MemoryStream serializationStream = MemoryStream::new();
      binaryFormatter.Serialize((Stream) serializationStream, (object) this.game.Data);
      index1 =  serializationStream.Length;
      serializationStream.Close();
      index1 =  Math.Round((double) index1 / 1024.0);
      str5: String = str4 + "DATA: " + index1.ToString() + "K" + "\r\n" + "\r\n" + "BITMAPSTORE DETAILS\r\n";
      simpleList.ReverseSort();
      let mut counter2: i32 = simpleList.Counter;
      for (let mut index3: i32 = 0; index3 <= counter2; index3 += 1)
      {
        index1 = simpleList.Id[index3];
        str5 = str5 + strArray[index1] + "\r\n";
      }
      return str5 + str3;
    }

     string DiagnosticsFuel()
    {
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
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
      let mut unitCounter1: i32 = this.game.Data.UnitCounter;
      int index1;
      int num1;
      int num2;
      for (index1 = 0; index1 <= unitCounter1; index1 += 1)
      {
        if (this.game.Data.UnitObj[index1].PreDef == -1)
        {
          let mut historical: i32 = this.game.Data.UnitObj[index1].Historical;
          let mut regime: i32 = this.game.Data.UnitObj[index1].Regime;
          if (historical > -1)
          {
            if (this.game.Data.HistoricalUnitObj[historical].Type >= 5)
              simpleList1.Add(index1, this.game.Data.HistoricalUnitObj[historical].Type);
            let mut sfCount: i32 = this.game.Data.UnitObj[index1].SFCount;
            for (let mut index2: i32 = 0; index2 <= sfCount; index2 += 1)
            {
              let mut sf: i32 = this.game.Data.UnitObj[index1].SFList[index2];
              let mut type: i32 = this.game.Data.SFObj[sf].Type;
              let mut unitGroup: i32 = this.game.Data.SFTypeObj[type].UnitGroup;
              let mut qty: i32 = this.game.Data.SFObj[sf].Qty;
              let mut num3: i32 = this.game.Data.SFTypeObj[type].FuelForAttack * qty * 10;
              int[] numArray13 = numArray1;
              int[] numArray14 = numArray13;
              let mut index3: i32 = index1;
              let mut index4: i32 = index3;
              let mut num4: i32 = numArray13[index3] + num3;
              numArray14[index4] = num4;
              int[,] numArray15 = numArray7;
              int[,] numArray16 = numArray15;
              let mut index5: i32 = regime;
              let mut index6: i32 = index5;
              let mut index7: i32 = unitGroup;
              let mut index8: i32 = index7;
              let mut num5: i32 = numArray15[index5, index7] + num3;
              numArray16[index6, index8] = num5;
              let mut num6: i32 = this.game.Data.SFTypeObj[type].FuelForMove * qty * 10;
              int[] numArray17 = numArray2;
              int[] numArray18 = numArray17;
              let mut index9: i32 = index1;
              let mut index10: i32 = index9;
              let mut num7: i32 = numArray17[index9] + num6;
              numArray18[index10] = num7;
              int[,] numArray19 = numArray8;
              int[,] numArray20 = numArray19;
              let mut index11: i32 = regime;
              let mut index12: i32 = index11;
              let mut index13: i32 = unitGroup;
              let mut index14: i32 = index13;
              let mut num8: i32 = numArray19[index11, index13] + num6;
              numArray20[index12, index14] = num8;
              let mut num9: i32 = this.game.Data.SFTypeObj[type].FuelForAttackDef * qty * 10;
              int[] numArray21 = numArray3;
              int[] numArray22 = numArray21;
              let mut index15: i32 = index1;
              let mut index16: i32 = index15;
              let mut num10: i32 = numArray21[index15] + num9;
              numArray22[index16] = num10;
              int[,] numArray23 = numArray9;
              int[,] numArray24 = numArray23;
              let mut index17: i32 = regime;
              let mut index18: i32 = index17;
              let mut index19: i32 = unitGroup;
              let mut index20: i32 = index19;
              let mut num11: i32 = numArray23[index17, index19] + num9;
              numArray24[index18, index20] = num11;
              num1 = 10;
              if (this.game.Data.SFTypeObj[type].EndCombatRound > 0 & this.game.Data.SFTypeObj[type].EndCombatRound < num1)
                num1 = this.game.Data.SFTypeObj[type].EndCombatRound - this.game.Data.SFTypeObj[type].StartCombatRound;
              let mut num12: i32 = this.game.Data.SFTypeObj[type].SupplyForAttack * qty * num1;
              int[] numArray25 = numArray4;
              int[] numArray26 = numArray25;
              let mut index21: i32 = index1;
              let mut index22: i32 = index21;
              let mut num13: i32 = numArray25[index21] + num12;
              numArray26[index22] = num13;
              int[,] numArray27 = numArray10;
              int[,] numArray28 = numArray27;
              let mut index23: i32 = regime;
              let mut index24: i32 = index23;
              let mut index25: i32 = unitGroup;
              let mut index26: i32 = index25;
              let mut num14: i32 = numArray27[index23, index25] + num12;
              numArray28[index24, index26] = num14;
              let mut num15: i32 = this.game.Data.SFTypeObj[type].SupplyForAttackDef * qty * num1;
              int[] numArray29 = numArray5;
              int[] numArray30 = numArray29;
              let mut index27: i32 = index1;
              let mut index28: i32 = index27;
              let mut num16: i32 = numArray29[index27] + num15;
              numArray30[index28] = num16;
              int[,] numArray31 = numArray11;
              int[,] numArray32 = numArray31;
              let mut index29: i32 = regime;
              let mut index30: i32 = index29;
              let mut index31: i32 = unitGroup;
              let mut index32: i32 = index31;
              let mut num17: i32 = numArray31[index29, index31] + num15;
              numArray32[index30, index32] = num17;
              num2 = this.game.Data.SFTypeObj[type].BasicSupplyNeed * qty * 1;
              int[] numArray33 = numArray6;
              int[] numArray34 = numArray33;
              let mut index33: i32 = index1;
              let mut index34: i32 = index33;
              let mut num18: i32 = numArray33[index33] + num2;
              numArray34[index34] = num18;
              int[,] numArray35 = numArray12;
              int[,] numArray36 = numArray35;
              let mut index35: i32 = regime;
              let mut index36: i32 = index35;
              let mut index37: i32 = unitGroup;
              let mut index38: i32 = index37;
              let mut num19: i32 = numArray35[index35, index37] + num2;
              numArray36[index36, index38] = num19;
            }
          }
        }
      }
      simpleList1.ReverseSortHighSpeed();
      let mut regimeCounter: i32 = this.game.Data.RegimeCounter;
      string str1;
      for (let mut index39: i32 = 0; index39 <= regimeCounter; index39 += 1)
      {
        str2: String = str1 + "\r\n" + "FUEL USAGE CUMULATIVE TOTALS FOR " + this.game.Data.RegimeObj[index39].Name.ToUpper() + "\r\n";
        str3: String = "ALL UNDER HQ";
        str4: String = str3 + Strings.Space(30 - str3.Length);
        str5: String = str2 + str4;
        str6: String = "10R.OFF.COMBAT";
        str7: String = str6 + Strings.Space(15 - str6.Length);
        str8: String = str5 + str7;
        str9: String = "100AP.MOVEMENT";
        str10: String = str9 + Strings.Space(15 - str9.Length);
        str11: String = str8 + str10;
        str12: String = "10R.DEF.COMBAT";
        str13: String = str12 + Strings.Space(15 - str12.Length);
        str14: String = str11 + str13 + "\r\n";
        let mut counter1: i32 = simpleList1.Counter;
        int num20;
        for (let mut index40: i32 = -1; index40 <= counter1; index40 += 1)
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
              let mut unitCounter2: i32 = this.game.Data.UnitCounter;
              for (let mut unr: i32 = 0; unr <= unitCounter2; unr += 1)
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
            let mut unitCounter3: i32 = this.game.Data.UnitCounter;
            for (let mut index41: i32 = 0; index41 <= unitCounter3; index41 += 1)
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
            str15: String = index40 != -1 ? Strings.Left(this.game.Data.UnitObj[index1].Name, 29) : "TOTAL OOB ON MAP";
            str16: String = str15 + Strings.Space(30 - str15.Length);
            str17: String = str14 + str16;
            str18: String = Strings.Left(num2.ToString(), 19);
            str19: String = str18 + Strings.Space(15 - str18.Length);
            str20: String = str17 + str19;
            str21: String = Strings.Left(num1.ToString(), 19);
            str22: String = str21 + Strings.Space(15 - str21.Length);
            str23: String = str20 + str22;
            str24: String = Strings.Left(num20.ToString(), 19);
            str25: String = str24 + Strings.Space(15 - str24.Length);
            str14 = str23 + str25 + "\r\n";
          }
        }
        str26: String = str14 + "\r\n" + "SUPPLY USAGE CUMULATIVE TOTALS FOR " + this.game.Data.RegimeObj[index39].Name.ToUpper() + "\r\n";
        str27: String = "ALL UNDER HQ";
        str28: String = str27 + Strings.Space(30 - str27.Length);
        str29: String = str26 + str28;
        str30: String = "10R.OFF.COMBAT";
        str31: String = str30 + Strings.Space(15 - str30.Length);
        str32: String = str29 + str31;
        str33: String = "10R.DEF.COMBAT";
        str34: String = str33 + Strings.Space(15 - str33.Length);
        str35: String = str32 + str34;
        str36: String = "UPKEEP ONLY";
        str37: String = str36 + Strings.Space(15 - str36.Length);
        str38: String = str35 + str37 + "\r\n";
        let mut counter2: i32 = simpleList1.Counter;
        for (let mut index42: i32 = -1; index42 <= counter2; index42 += 1)
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
              let mut unitCounter4: i32 = this.game.Data.UnitCounter;
              for (let mut unr: i32 = 0; unr <= unitCounter4; unr += 1)
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
            let mut unitCounter5: i32 = this.game.Data.UnitCounter;
            for (let mut index43: i32 = 0; index43 <= unitCounter5; index43 += 1)
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
            str39: String = index42 != -1 ? Strings.Left(this.game.Data.UnitObj[index1].Name, 29) : "TOTAL OOB ON MAP";
            str40: String = str39 + Strings.Space(30 - str39.Length);
            str41: String = str38 + str40;
            str42: String = Strings.Left(num2.ToString(), 19);
            str43: String = str42 + Strings.Space(15 - str42.Length);
            str44: String = str41 + str43;
            str45: String = Strings.Left(num1.ToString(), 19);
            str46: String = str45 + Strings.Space(15 - str45.Length);
            str47: String = str44 + str46;
            str48: String = Strings.Left(num20.ToString(), 19);
            str49: String = str48 + Strings.Space(15 - str48.Length);
            str38 = str47 + str49 + "\r\n";
          }
        }
        str50: String = str38 + "\r\n" + "FUEL USAGE CUMULATIVE TOTALS FOR " + this.game.Data.RegimeObj[index39].Name.ToUpper() + "\r\n";
        str51: String = "UNIT GROUP";
        str52: String = str51 + Strings.Space(30 - str51.Length);
        str53: String = str50 + str52;
        str54: String = "10R.OFF.COMBAT";
        str55: String = str54 + Strings.Space(15 - str54.Length);
        str56: String = str53 + str55;
        str57: String = "100AP.MOVEMENT";
        str58: String = str57 + Strings.Space(15 - str57.Length);
        str59: String = str56 + str58;
        str60: String = "10R.DEF.COMBAT";
        str61: String = str60 + Strings.Space(15 - str60.Length);
        str62: String = str59 + str61 + "\r\n";
        let mut index44: i32 = 0;
        do
        {
          bool flag = false;
          let mut num21: i32 = 0;
          let mut num22: i32 = 0;
          let mut num23: i32 = 0;
          let mut num24: i32 = num21 + numArray7[index39, index44];
          let mut num25: i32 = num22 + numArray8[index39, index44];
          let mut num26: i32 = num23 + numArray9[index39, index44];
          if (num24 > 0 | num25 > 0 | num26 > 0)
            flag = true;
          if (flag & this.game.Data.TempString[400 + index44].Length > 1)
          {
            str63: String = Strings.Left(this.game.Data.TempString[400 + index44], 29);
            str64: String = str63 + Strings.Space(30 - str63.Length);
            str65: String = str62 + str64;
            str66: String = Strings.Left(num24.ToString(), 19);
            str67: String = str66 + Strings.Space(15 - str66.Length);
            str68: String = str65 + str67;
            str69: String = Strings.Left(num25.ToString(), 19);
            str70: String = str69 + Strings.Space(15 - str69.Length);
            str71: String = str68 + str70;
            str72: String = Strings.Left(num26.ToString(), 19);
            str73: String = str72 + Strings.Space(15 - str72.Length);
            str62 = str71 + str73 + "\r\n";
          }
          index44 += 1;
        }
        while (index44 <= 99);
        str74: String = str62 + "\r\n" + "SUPPLY USAGE CUMULATIVE TOTALS FOR " + this.game.Data.RegimeObj[index39].Name.ToUpper() + "\r\n";
        str75: String = "UNIT GROUP";
        str76: String = str75 + Strings.Space(30 - str75.Length);
        str77: String = str74 + str76;
        str78: String = "10R.OFF.COMBAT";
        str79: String = str78 + Strings.Space(15 - str78.Length);
        str80: String = str77 + str79;
        str81: String = "10R.DEF.COMBAT";
        str82: String = str81 + Strings.Space(15 - str81.Length);
        str83: String = str80 + str82;
        str84: String = "UPKEEP";
        str85: String = str84 + Strings.Space(15 - str84.Length);
        str86: String = str83 + str85 + "\r\n";
        let mut index45: i32 = 0;
        do
        {
          bool flag = false;
          let mut num27: i32 = 0;
          let mut num28: i32 = 0;
          let mut num29: i32 = 0;
          num2 = num27 + numArray10[index39, index45];
          num1 = num28 + numArray11[index39, index45];
          num20 = num29 + numArray12[index39, index45];
          if (num2 > 0 | num1 > 0 | num20 > 0)
            flag = true;
          if (flag & this.game.Data.TempString[400 + index45].Length > 1)
          {
            str87: String = Strings.Left(this.game.Data.TempString[400 + index45], 29);
            str88: String = str87 + Strings.Space(30 - str87.Length);
            str89: String = str86 + str88;
            str90: String = Strings.Left(num2.ToString(), 19);
            str91: String = str90 + Strings.Space(15 - str90.Length);
            str92: String = str89 + str91;
            str93: String = Strings.Left(num1.ToString(), 19);
            str94: String = str93 + Strings.Space(15 - str93.Length);
            str95: String = str92 + str94;
            str96: String = Strings.Left(num20.ToString(), 19);
            str97: String = str96 + Strings.Space(15 - str96.Length);
            str86 = str95 + str97 + "\r\n";
          }
          index45 += 1;
        }
        while (index45 <= 99);
        str98: String = str86 + "\r\n" + "FUEL USAGE PER UNIT FOR " + this.game.Data.RegimeObj[index39].Name.ToUpper() + "\r\n";
        str99: String = "UNIT";
        str100: String = str99 + Strings.Space(30 - str99.Length);
        str101: String = str98 + str100;
        str102: String = "10R.OFF.COMBAT";
        str103: String = str102 + Strings.Space(15 - str102.Length);
        str104: String = str101 + str103;
        str105: String = "100AP.MOVEMENT";
        str106: String = str105 + Strings.Space(15 - str105.Length);
        str107: String = str104 + str106;
        str108: String = "10R.DEF.COMBAT";
        str109: String = str108 + Strings.Space(15 - str108.Length);
        str110: String = str107 + str109 + "\r\n";
        let mut unitCounter6: i32 = this.game.Data.UnitCounter;
        for (let mut index46: i32 = 0; index46 <= unitCounter6; index46 += 1)
        {
          bool flag = false;
          index1 = index46;
          if (this.game.Data.UnitObj[index1].Regime == index39 & this.game.Data.UnitObj[index1].PreDef == -1)
          {
            flag = true;
            let mut num30: i32 = 0;
            let mut num31: i32 = 0;
            let mut num32: i32 = 0;
            num2 = num30 + numArray1[index46];
            num1 = num31 + numArray2[index46];
            num20 = num32 + numArray3[index46];
          }
          if (flag)
          {
            str111: String = Strings.Left(this.game.Data.UnitObj[index1].Name, 29);
            str112: String = str111 + Strings.Space(30 - str111.Length);
            str113: String = str110 + str112;
            str114: String = Strings.Left(num2.ToString(), 19);
            str115: String = str114 + Strings.Space(15 - str114.Length);
            str116: String = str113 + str115;
            str117: String = Strings.Left(num1.ToString(), 19);
            str118: String = str117 + Strings.Space(15 - str117.Length);
            str119: String = str116 + str118;
            str120: String = Strings.Left(num20.ToString(), 19);
            str121: String = str120 + Strings.Space(15 - str120.Length);
            str110 = str119 + str121 + "\r\n";
          }
        }
        str122: String = str110 + "\r\n" + "SUPPLY USAGE PER UNIT FOR " + this.game.Data.RegimeObj[index39].Name.ToUpper() + "\r\n";
        str123: String = "UNIT";
        str124: String = str123 + Strings.Space(30 - str123.Length);
        str125: String = str122 + str124;
        str126: String = "10R.OFF.COMBAT";
        str127: String = str126 + Strings.Space(15 - str126.Length);
        str128: String = str125 + str127;
        str129: String = "10R.DEF.COMBAT";
        str130: String = str129 + Strings.Space(15 - str129.Length);
        str131: String = str128 + str130;
        str132: String = "UPKEEP ONLY";
        str133: String = str132 + Strings.Space(15 - str132.Length);
        str1 = str131 + str133 + "\r\n";
        let mut unitCounter7: i32 = this.game.Data.UnitCounter;
        for (let mut index47: i32 = 0; index47 <= unitCounter7; index47 += 1)
        {
          bool flag = false;
          if (index47 > -1)
          {
            index1 = index47;
            if (this.game.Data.UnitObj[index1].Regime == index39 & this.game.Data.UnitObj[index1].PreDef == -1)
            {
              flag = true;
              let mut num33: i32 = 0;
              let mut num34: i32 = 0;
              let mut num35: i32 = 0;
              num2 = num33 + numArray4[index47];
              num1 = num34 + numArray5[index47];
              num20 = num35 + numArray6[index47];
            }
          }
          if (flag)
          {
            str134: String = Strings.Left(this.game.Data.UnitObj[index1].Name, 29);
            str135: String = str134 + Strings.Space(30 - str134.Length);
            str136: String = str1 + str135;
            str137: String = Strings.Left(num2.ToString(), 19);
            str138: String = str137 + Strings.Space(15 - str137.Length);
            str139: String = str136 + str138;
            str140: String = Strings.Left(num1.ToString(), 19);
            str141: String = str140 + Strings.Space(15 - str140.Length);
            str142: String = str139 + str141;
            str143: String = Strings.Left(num20.ToString(), 19);
            str144: String = str143 + Strings.Space(15 - str143.Length);
            str1 = str142 + str144 + "\r\n";
          }
        }
      }
      return str1;
    }

     string DiagnosticsPower()
    {
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
      int[] numArray1 = new int[this.game.Data.UnitCounter + 1];
      let mut unitCounter1: i32 = this.game.Data.UnitCounter;
      int index1;
      int num1;
      for (index1 = 0; index1 <= unitCounter1; index1 += 1)
      {
        if (this.game.Data.UnitObj[index1].PreDef == -1)
        {
          let mut historical: i32 = this.game.Data.UnitObj[index1].Historical;
          let mut regime: i32 = this.game.Data.UnitObj[index1].Regime;
          if (historical > -1)
          {
            if (this.game.Data.HistoricalUnitObj[historical].Type >= 5)
              simpleList1.Add(index1, this.game.Data.HistoricalUnitObj[historical].Type);
            let mut sfCount: i32 = this.game.Data.UnitObj[index1].SFCount;
            for (let mut index2: i32 = 0; index2 <= sfCount; index2 += 1)
            {
              let mut sf: i32 = this.game.Data.UnitObj[index1].SFList[index2];
              let mut type: i32 = this.game.Data.SFObj[sf].Type;
              let mut unitGroup: i32 = this.game.Data.SFTypeObj[type].UnitGroup;
              let mut qty: i32 = this.game.Data.SFObj[sf].Qty;
              num1 = this.game.Data.SFTypeObj[type].PowerPts * qty;
              int[] numArray2 = numArray1;
              int[] numArray3 = numArray2;
              let mut index3: i32 = index1;
              let mut index4: i32 = index3;
              let mut num2: i32 = numArray2[index3] + num1;
              numArray3[index4] = num2;
            }
          }
        }
      }
      simpleList1.ReverseSortHighSpeed();
      let mut regimeCounter1: i32 = this.game.Data.RegimeCounter;
      string str1;
      for (let mut index5: i32 = 0; index5 <= regimeCounter1; index5 += 1)
      {
        str2: String = str1 + "\r\n" + "POWER CUMULATIVE TOTALS FOR " + this.game.Data.RegimeObj[index5].Name.ToUpper() + "\r\n";
        str3: String = "ALL UNDER HQ";
        str4: String = str3 + Strings.Space(30 - str3.Length);
        str5: String = str2 + str4;
        str6: String = "POWER PTS";
        str7: String = str6 + Strings.Space(15 - str6.Length);
        str1 = str5 + str7 + "\r\n";
        let mut counter: i32 = simpleList1.Counter;
        for (let mut index6: i32 = -1; index6 <= counter; index6 += 1)
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
              let mut unitCounter2: i32 = this.game.Data.UnitCounter;
              for (let mut unr: i32 = 0; unr <= unitCounter2; unr += 1)
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
            let mut unitCounter3: i32 = this.game.Data.UnitCounter;
            for (let mut index7: i32 = 0; index7 <= unitCounter3; index7 += 1)
            {
              if (this.game.Data.UnitObj[index7].Regime == index5 & this.game.Data.UnitObj[index7].PreDef == -1)
                num1 += numArray1[index7];
            }
          }
          if (flag)
          {
            str8: String = index6 != -1 ? Strings.Left(this.game.Data.UnitObj[index1].Name, 29) : "TOTAL POWER";
            str9: String = str8 + Strings.Space(30 - str8.Length);
            str10: String = str1 + str9;
            str11: String = Strings.Left(num1.ToString(), 19);
            str12: String = str11 + Strings.Space(15 - str11.Length);
            str1 = str10 + str12 + "\r\n";
          }
        }
      }
      str13: String = str1 + "\r\n";
      let mut num5: i32 = 0;
      int[] numArray4 = new int[100];
      let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut index8: i32 = 0; index8 <= mapWidth; index8 += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut index9: i32 = 0; index9 <= mapHeight; index9 += 1)
        {
          num5 += this.game.Data.MapObj[0].HexObj[index8, index9].VP;
          if (this.game.Data.MapObj[0].HexObj[index8, index9].Regime > -1)
          {
            int[] numArray5 = numArray4;
            int[] numArray6 = numArray5;
            let mut regime: i32 = this.game.Data.MapObj[0].HexObj[index8, index9].Regime;
            let mut index10: i32 = regime;
            let mut num6: i32 = numArray5[regime] + this.game.Data.MapObj[0].HexObj[index8, index9].VP;
            numArray6[index10] = num6;
          }
        }
      }
      str14: String = str13 + "TOTAL VP ON MAP: " + num5.ToString() + "\r\n";
      let mut regimeCounter2: i32 = this.game.Data.RegimeCounter;
      for (let mut index11: i32 = 0; index11 <= regimeCounter2; index11 += 1)
        str14 = str14 + "Held by " + this.game.Data.RegimeObj[index11].Name + " : " + numArray4[index11].ToString() + "\r\n";
      return str14;
    }

     string RemoveSFTypeLogoTextRemnants(bool testing)
    {
      Left: String = "";
      int num;
      for (let mut sfTypeCounter: i32 = this.game.Data.SFTypeCounter; sfTypeCounter >= 0; sfTypeCounter += -1)
      {
        bool flag = false;
        let mut index: i32 = 99;
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
            str: String = "SFTYPE#" + sfTypeCounter.ToString() + ", LOGOSTRING#" + index.ToString() + " : " + this.game.Data.SFTypeObj[sfTypeCounter].LogoString[index];
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
            num += 1;
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
