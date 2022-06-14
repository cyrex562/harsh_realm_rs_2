// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleEditUnitWindowClass
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
  pub class SimpleEditUnitWindowClass : WindowClass
  {
     int listId;
     ListClass listObj;
     int loadMapId;
     int loadMapIdB;
     int importId;
     int textId;
     int detailnr;
     int currentStep;
     int standing1;
     int standing2;
     ListClass VPListOBj;
     int VPListId;
     int AddUnitModel;
     int AddUnit;
     int AddUnitModelB;
     int cancelid;
     int AddUnitB;
     int ChangeCounterUnit;
     int ChangeCounterUnitB;
     int RemoveUnit;
     int MoveUnit;
     int MoveUnitB;
     int HqUnit;
     int HqUnitB;
     int RemoveUnitB;
     int AddVPIdb;
     int SetCommander;
     int SetCommanderB;
     int changeColor;
     int changeColorB;

    pub SimpleEditUnitWindowClass( GameClass tGame)
      : base( tGame, tGame.ScreenWidth, 300, 9, tDoBorders: 1, tHeaderString: "Units")
    {
      this.detailnr = -1;
      this.game.EditObj.TempHisModelUnit = -1;
      this.game.EditObj.TempHisUnit = -1;
      this.game.EditObj.TempRandom = -1;
      this.DoStuff();
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false)
    {
      windowReturnClass1: WindowReturnClass = WindowReturnClass::new();
      if (nr == 77 & this.game.EditObj.UnitSelected > -1 & this.SubpartNr(this.MoveUnit) > 0)
      {
        windowReturnClass2: WindowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.MoveUnit)] + 1, this.SubPartY[this.SubpartNr(this.MoveUnit)] + 1, 1);
        windowReturnClass2.SetFlag(true);
        return windowReturnClass2;
      }
      if (nr == 72 & this.game.EditObj.UnitSelected > -1 & this.SubpartNr(this.HqUnit) > 0)
      {
        windowReturnClass3: WindowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.HqUnit)] + 1, this.SubPartY[this.SubpartNr(this.HqUnit)] + 1, 1);
        windowReturnClass3.SetFlag(true);
        return windowReturnClass3;
      }
      if (!((nr == 13 | nr == 32) & this.game.EditObj.UnitSelected > -1 & this.SubpartNr(this.cancelid) > 0))
        return windowReturnClass1;
      windowReturnClass4: WindowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.cancelid)] + 1, this.SubPartY[this.SubpartNr(this.cancelid)] + 1, 1);
      windowReturnClass4.SetFlag(true);
      return windowReturnClass4;
    }

    pub void DoRefresh()
    {
      if (this.game.EditObj.TempHisModelUnit > -1)
      {
        this.game.ProcessingObj.AddNewUnitBasedOnHistorical(this.game.SelectX, this.game.SelectY, 0, this.game.Data.HistoricalUnitObj[this.game.EditObj.TempHisModelUnit].TempRegime, this.game.EditObj.TempHisModelUnit, freePPnoUnit: true, populateUnit: true);
        this.game.EditObj.UnitSelected = this.game.Data.UnitCounter;
        this.game.EditObj.TempHisModelUnit = -1;
      }
      if (this.game.EditObj.TempHisUnit > -1)
      {
        let mut tempRegime: i32 = this.game.Data.HistoricalUnitObj[this.game.EditObj.TempHisUnit].TempRegime;
        this.game.EventRelatedObj.ExecAddHistoricalUnit(this.game.SelectX, this.game.SelectY, this.game.Data.HistoricalUnitObj[this.game.EditObj.TempHisUnit].ID, 0, "");
        this.game.EditObj.UnitSelected = this.game.Data.UnitCounter;
        this.game.EditObj.TempHisUnit = -1;
      }
      if (this.game.EditObj.TempRandom > -1)
      {
        if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName.Length > 0)
        {
          LibIdClass libIdClass1 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].OffLibId.Clone();
          LibIdClass libIdClass2 = this.game.Data.HistoricalUnitObj[this.game.EditObj.TempRandom].LibId.Clone();
          this.game.ProcessingObj.SwapOfficer(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical, this.game.EditObj.TempRandom, this.game.EditObj.UnitSelected);
          this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].OffLibId = libIdClass2;
          this.game.Data.HistoricalUnitObj[this.game.EditObj.TempRandom].LibId = libIdClass1.Clone();
          this.game.Data.HistoricalUnitObj[this.game.EditObj.TempRandom].OffLibId = LibIdClass::new();
          this.game.Data.HistoricalUnitObj[this.game.EditObj.TempRandom].Pool = true;
        }
        else
        {
          LibIdClass libIdClass = this.game.Data.HistoricalUnitObj[this.game.EditObj.TempRandom].LibId.Clone();
          this.game.ProcessingObj.SwapOfficer(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical, this.game.EditObj.TempRandom, this.game.EditObj.UnitSelected);
          this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].OffLibId = libIdClass;
        }
        this.game.EditObj.TempRandom = -1;
      }
      else if (this.game.EditObj.TempRandom == -2 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName.Length > 0)
      {
        LibIdClass libIdClass = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].OffLibId.Clone();
        this.game.Data.AddHistoricalUnit();
        this.game.ProcessingObj.SwapOfficer(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical, this.game.Data.HistoricalUnitCounter, this.game.EditObj.UnitSelected);
        this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].OffLibId = LibIdClass::new();
        this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].LibId = libIdClass.Clone();
        this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].Pool = true;
        this.game.EditObj.TempRandom = -1;
      }
      this.DoStuff();
    }

    pub void DoStuff()
    {
      let mut num1: i32 =  Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      graphics.TextContrast = 1;
      this.ClearMouse();
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 350, -1);
      DrawMod.DrawBlock( graphics, 2, 294, DrawMod.TGame.ScreenWidth - 4, 4, 0, 0, 0, 128);
      if (this.VPListId > 0)
      {
        this.RemoveSubPart(this.VPListId);
        this.VPListId = 0;
      }
      if (this.AddUnitModel > 0)
      {
        this.RemoveSubPart(this.AddUnitModel);
        this.AddUnitModel = 0;
      }
      if (this.AddUnit > 0)
      {
        this.RemoveSubPart(this.AddUnit);
        this.AddUnit = 0;
      }
      if (this.RemoveUnit > 0)
      {
        this.RemoveSubPart(this.RemoveUnit);
        this.RemoveUnit = 0;
      }
      if (this.RemoveUnitB > 0)
      {
        this.RemoveSubPart(this.RemoveUnitB);
        this.RemoveUnitB = 0;
      }
      if (this.ChangeCounterUnit > 0)
      {
        this.RemoveSubPart(this.ChangeCounterUnit);
        this.ChangeCounterUnit = 0;
      }
      if (this.ChangeCounterUnitB > 0)
      {
        this.RemoveSubPart(this.ChangeCounterUnitB);
        this.ChangeCounterUnitB = 0;
      }
      if (this.AddUnitModelB > 0)
      {
        this.RemoveSubPart(this.AddUnitModelB);
        this.AddUnitModelB = 0;
      }
      if (this.AddUnitB > 0)
      {
        this.RemoveSubPart(this.AddUnitB);
        this.AddUnitB = 0;
      }
      if (this.AddVPIdb > 0)
      {
        this.RemoveSubPart(this.AddVPIdb);
        this.AddVPIdb = 0;
      }
      if (this.SetCommander > 0)
      {
        this.RemoveSubPart(this.SetCommander);
        this.SetCommander = 0;
      }
      if (this.SetCommanderB > 0)
      {
        this.RemoveSubPart(this.SetCommanderB);
        this.SetCommanderB = 0;
      }
      if (this.MoveUnit > 0)
      {
        this.RemoveSubPart(this.MoveUnit);
        this.MoveUnit = 0;
      }
      if (this.HqUnit > 0)
      {
        this.RemoveSubPart(this.HqUnit);
        this.HqUnit = 0;
      }
      if (this.HqUnitB > 0)
      {
        this.RemoveSubPart(this.HqUnitB);
        this.HqUnitB = 0;
      }
      if (this.MoveUnitB > 0)
      {
        this.RemoveSubPart(this.MoveUnitB);
        this.MoveUnitB = 0;
      }
      if (this.HqUnitB > 0)
      {
        this.RemoveSubPart(this.HqUnitB);
        this.HqUnitB = 0;
      }
      if (this.importId > 0)
      {
        this.RemoveSubPart(this.importId);
        this.importId = 0;
      }
      if (this.cancelid > 0)
      {
        this.RemoveSubPart(this.cancelid);
        this.cancelid = 0;
      }
      if (this.changeColor > 0)
      {
        this.RemoveSubPart(this.changeColor);
        this.changeColor = 0;
      }
      if (this.changeColorB > 0)
      {
        this.RemoveSubPart(this.changeColorB);
        this.changeColorB = 0;
      }
      if (this.standing1 > 0)
      {
        this.RemoveSubPart(this.standing1);
        this.standing1 = 0;
      }
      if (this.standing2 > 0)
      {
        this.RemoveSubPart(this.standing2);
        this.standing2 = 0;
      }
      this.VPListOBj = ListClass::new();
      let mut num2: i32 = num1 + 250;
      let mut y: i32 = 55;
      string tDescript;
      SubPartClass tsubpart1;
      if (this.game.SelectX > -1 & this.game.SelectY > -1)
      {
        let mut num3: i32 = -1;
        let mut num4: i32 = -1;
        let mut unitCounter: i32 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter;
        for (let mut index: i32 = 0; index <= unitCounter; index += 1)
        {
          let mut unit: i32 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitList[index];
          num4 += 1;
          this.VPListOBj.add(index.ToString() + "," + this.game.Data.UnitObj[unit].Name, unit);
          if (this.game.EditObj.UnitSelected == unit)
            num3 = num4;
        }
        if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter == -1)
          this.VPListOBj.add("no units on hex", -1);
        ListClass vpListObj = this.VPListOBj;
        let mut tlistselect: i32 = num3;
        let mut game: GameClass = this.game;
         Bitmap local1 =  this.OwnBitmap;
        let mut bbx: i32 = 10 + num1;
        Font font =  null;
         Font local2 =  font;
        let mut tsubpart2: SubPartClass =  new ListSubPartClass(vpListObj, 10, 200, tlistselect, game, true, "Units in Hex", false, tValueWidth: 0, tdotopandbottom: false, tbackbitmap: ( local1), bbx: bbx, bby: 52, tMarcStyle: true, overruleFont: ( local2));
        this.VPListId = this.AddSubPart( tsubpart2, 10 + num1, 52, 200, 176, 0);
        bool flag = true;
        if (this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName.Length > 0)
          flag = false;
        if (flag)
        {
          DrawMod.DrawTextColouredMarc( graphics, "Selected hex:", this.game.MarcFont4, num2 + 400, y + 50, Color.White);
          DrawMod.DrawTextColouredMarc( graphics, this.game.SelectX.ToString() + "," + this.game.SelectY.ToString() + "," + this.game.HandyFunctionsObj.GetHexName(this.game.SelectX, this.game.SelectY, 0), this.game.MarcFont3, num2 + 400, y + 70, Color.White);
        }
        if (this.game.EditObj.UnitSelected > -1)
        {
          DrawMod.DrawTextColouredMarc( graphics, "Selected unit:", this.game.MarcFont4, num2, y, Color.White);
          let mut historical: i32 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical;
          ttext: String = "Unit slot: " + this.game.EditObj.UnitSelected.ToString() + "\r\n";
          if (historical > -1)
            ttext = ttext + "Historical slot: " + historical.ToString() + "\r\n" + "Historical ID: " + this.game.Data.HistoricalUnitObj[historical].ID.ToString() + "\r\n";
          Rectangle trect = Rectangle::new(num2, y, 200, 20);
          this.AddMouse( trect, "Selected unit", ttext);
          DrawMod.DrawTextColouredMarc( graphics, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Name, this.game.MarcFont3, num2, y + 20, Color.White);
          DrawMod.DrawTextColouredMarc( graphics, "Units model:", this.game.MarcFont4, num2, y + 50, Color.White);
          string tstring1;
          if (historical > -1)
          {
            let mut modelMaster: i32 = this.game.Data.HistoricalUnitObj[historical].ModelMaster;
            if (modelMaster > -1)
            {
              let mut num5: i32 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HistoricalSubPart + 1;
              tstring1 = this.game.Data.HistoricalUnitObj[modelMaster].Name;
              if (!this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
              {
                tstring1 = tstring1 + " (sub-part " + num5.ToString() + ")";
              }
              else
              {
                if (this.game.Data.HistoricalUnitObj[modelMaster].Type == 5)
                  tstring1 += " (lowest level HQ)";
                if (this.game.Data.HistoricalUnitObj[modelMaster].Type == 6)
                  tstring1 += " (medium level HQ)";
                if (this.game.Data.HistoricalUnitObj[modelMaster].Type == 7)
                  tstring1 += " (high level HQ)";
                if (this.game.Data.HistoricalUnitObj[modelMaster].Type == 8)
                  tstring1 += " (supreme level HQ)";
              }
            }
            else
              tstring1 = "Warning! unit not set to a model";
          }
          else
            tstring1 = "Warning! unit is not a historical unit";
          DrawMod.DrawTextColouredMarc( graphics, tstring1, this.game.MarcFont3, num2, y + 70, Color.White);
          DrawMod.DrawTextColouredMarc( graphics, "is HQ:", this.game.MarcFont4, num2 + 400, y, Color.White);
          tstring2: String = "Yes";
          if (!this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
            tstring2 = "No";
          DrawMod.DrawTextColouredMarc( graphics, tstring2, this.game.MarcFont3, num2 + 400, y + 20, Color.White);
          DrawMod.DrawTextColouredMarc( graphics, "Assigned to HQ:", this.game.MarcFont4, num2 + 500, y, Color.White);
          tstring3: String = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ != -1 ? this.game.Data.UnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ].Name : "None";
          DrawMod.DrawTextColouredMarc( graphics, tstring3, this.game.MarcFont3, num2 + 500, y + 20, Color.White);
          if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName.Length > 0)
          {
            DrawMod.DrawTextColouredMarc( graphics, "Commander:", this.game.MarcFont4, num2 + 400, y + 50, Color.White);
            tstring4: String = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName;
            let mut people: i32 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].People;
            if (people > -1)
              tstring4 = tstring4 + " (" + this.game.Data.PeopleObj[people].Name + ")";
            DrawMod.DrawTextColouredMarc( graphics, tstring4, this.game.MarcFont3, num2 + 400, y + 70, Color.White);
          }
        }
        else
        {
          DrawMod.DrawTextColouredMarc( graphics, "Selected unit:", this.game.MarcFont4, num2, y, Color.White);
          DrawMod.DrawTextColouredMarc( graphics, "none", this.game.MarcFont3, num2, y + 20, Color.White);
        }
        if (this.game.EditObj.OrderType >= 1)
        {
          DrawMod.DrawTextColouredMarc( graphics, "Currently executing an order.", this.game.MarcFont4, num2 + 400, y + 50, Color.White);
          tDescript = "Cancel order";
          tsubpart1 =  new TextButtonPartClass("Cancel order", 250, tDescript,  this.OwnBitmap, num2 + 400, y + 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.cancelid = this.AddSubPart( tsubpart1, num2 + 400, y + 100, 250, 35, 1);
        }
        else if (this.game.EditObj.UnitSelected > -1)
        {
          if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
          {
            let mut tsubpart3: SubPartClass =  new TextButtonPartClass("Set Commander", 250, "Change commander",  this.OwnBitmap, num2 + 400, y + 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.SetCommander = this.AddSubPart( tsubpart3, num2 + 400, y + 100, 250, 35, 1);
            let mut tsubpart4: SubPartClass =  new TextButtonPartClass("Change color", 155, "Click to change color of HQ.",  this.OwnBitmap, num2 + 190, y + 180, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.changeColor = this.AddSubPart( tsubpart4, num2 + 190, y + 180, 155, 35, 1);
          }
          else
          {
            let mut tsubpart5: SubPartClass =  new TextButtonPartClass("Set Commander", 250, "You can only set commander for a HQ",  this.OwnBitmap, num2 + 400, y + 100, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.SetCommanderB = this.AddSubPart( tsubpart5, num2 + 400, y + 100, 250, 35, 0);
            let mut tsubpart6: SubPartClass =  new TextButtonPartClass("Change color", 155, "You can only change color of HQ.",  this.OwnBitmap, num2 + 190, y + 180, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.changeColorB = this.AddSubPart( tsubpart6, num2 + 190, y + 180, 155, 35, 0);
          }
          let mut tsubpart7: SubPartClass =  new TextButtonPartClass("Move Unit [M]", 250, tBackbitmap: ( this.OwnBitmap), bbx: (num2 + 400), bby: (y + 140), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.MoveUnit = this.AddSubPart( tsubpart7, num2 + 400, y + 140, 250, 35, 1);
          let mut tsubpart8: SubPartClass =  new TextButtonPartClass("Set HQ [H]", 250, tBackbitmap: ( this.OwnBitmap), bbx: (num2 + 400), bby: (y + 180), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.HqUnit = this.AddSubPart( tsubpart8, num2 + 400, y + 180, 250, 35, 1);
          tsubpart1 =  new TextButtonPartClass("Remove unit", 155, "Click to remove this unit.",  this.OwnBitmap, num2, y + 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.RemoveUnit = this.AddSubPart( tsubpart1, num2, y + 100, 155, 35, 1);
          tsubpart1 =  new TextButtonPartClass("Change counter", 155, "Click to change the Number and the Shortname of the selected unit.",  this.OwnBitmap, num2 + 190, y + 140, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.ChangeCounterUnit = this.AddSubPart( tsubpart1, num2 + 190, y + 140, 155, 35, 1);
          tDescript = "Change Standing Order: Retreat Percentage. Will change setting for current unit and all subordinates. 100% is fight till the end. 25% retreat asap. ";
          tsubpart1 =  new TextButtonPartClass("Rtr:" + (100 - this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SODefendPercent).ToString(), 90, tDescript,  this.OwnBitmap, num2 - 240, y + 180, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.standing1 = this.AddSubPart( tsubpart1, num2 - 240, y + 180, 90, 35, 1);
          if (this.game.HandyFunctionsObj.HasUnitAirSF(this.game.EditObj.UnitSelected))
          {
            tDescript = "Change Standing Order: Intercept Percentage. Will change setting for current unit and all subordinates. % specifies the minimum readiness needed to allow intercept missions. ";
            str: String = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop.ToString();
            if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop == 100)
              str = "Nev.";
            tsubpart1 =  new TextButtonPartClass("Intc:" + str, 90, tDescript,  this.OwnBitmap, num2 - 140, y + 180, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.standing2 = this.AddSubPart( tsubpart1, num2 - 140, y + 180, 90, 35, 1);
          }
        }
        else
        {
          let mut tsubpart9: SubPartClass =  new TextButtonPartClass("Remove unit", 155, "No unit selected",  this.OwnBitmap, num2, y + 100, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.RemoveUnitB = this.AddSubPart( tsubpart9, num2, y + 100, 155, 35, 0);
          let mut tsubpart10: SubPartClass =  new TextButtonPartClass("Move Unit", 250, "No unit selected",  this.OwnBitmap, num2 + 400, y + 140, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.MoveUnitB = this.AddSubPart( tsubpart10, num2 + 400, y + 140, 250, 35, 0);
          tsubpart1 =  new TextButtonPartClass("Set HQ", 250, "No unit selected",  this.OwnBitmap, num2 + 400, y + 180, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.HqUnitB = this.AddSubPart( tsubpart1, num2 + 400, y + 180, 250, 35, 0);
          tsubpart1 =  new TextButtonPartClass("Change counter", 155, "No unit selected",  this.OwnBitmap, num2 + 190, y + 140, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.ChangeCounterUnitB = this.AddSubPart( tsubpart1, num2 + 190, y + 140, 155, 35, 0);
          tsubpart1 =  new TextButtonPartClass("Change color", 155, "No unit selected",  this.OwnBitmap, num2 + 190, y + 180, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.changeColorB = this.AddSubPart( tsubpart1, num2 + 190, y + 180, 155, 35, 0);
        }
      }
      else
      {
        DrawMod.DrawTextColouredMarc( graphics, "Selected hex:", this.game.MarcFont4, num2, y, Color.White);
        DrawMod.DrawTextColouredMarc( graphics, "None", this.game.MarcFont3, num2, y + 20, Color.White);
      }
      if (this.game.EditObj.OrderType <= 0)
      {
        if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType].IsSea & this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1)
        {
          tsubpart1 =  new TextButtonPartClass("Add unit model", 155, "Click to add a unit to this hex, based on a historical unit model, but a fresh non-yet existing instance of it.",  this.OwnBitmap, num2, y + 140, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.AddUnitModel = this.AddSubPart( tsubpart1, num2, y + 140, 155, 35, 1);
          tDescript = "Click to add a pre-defined historical unit, not yet on map, on the map";
          tsubpart1 =  new TextButtonPartClass("Add unit", 155, tDescript,  this.OwnBitmap, num2, y + 180, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.AddUnit = this.AddSubPart( tsubpart1, num2, y + 180, 155, 35, 1);
        }
        else
        {
          tDescript = "Can only place on friendly hex";
          tsubpart1 =  new TextButtonPartClass("Add unit model", 155, tDescript,  this.OwnBitmap, num2, y + 140, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.AddUnitModelB = this.AddSubPart( tsubpart1, num2, y + 140, 155, 35, 1);
          tsubpart1 =  new TextButtonPartClass("Add unit", 155, tDescript,  this.OwnBitmap, num2, y + 180, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.AddUnitB = this.AddSubPart( tsubpart1, num2, y + 180, 250, 35, 1);
        }
      }
      if (this.game.EditObj.UnitSelected == -1 | this.game.EditObj.OrderType > 0)
      {
        tsubpart1 =  new TextButtonPartClass("Remove unit", 155, tDescript,  this.OwnBitmap, num2, y + 100, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RemoveUnitB = this.AddSubPart( tsubpart1, num2, y + 100, 155, 35, 1);
      }
      tsubpart1 =  new TextButtonPartClass("Import Units", 155, "Allows you to import the units placed on the map in another scenario. This will remove all your current units and assigned officers. This only works if you have loaded the neccessary officer and historical unit libraries that are used by the units you are trying to import. Also this will overwrite the hex ownership. ",  this.OwnBitmap, num2 + 190, y + 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.importId = this.AddSubPart( tsubpart1, num2 + 190, y + 100, 155, 35, 1);
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 = this.SubPartCounter;
        for (let mut index1: i32 = 0; index1 <= subPartCounter; index1 += 1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            let mut num1: i32 = this.SubPartID[index1];
            if (num1 == this.VPListId)
            {
              let mut index2: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (index2 > -1)
              {
                this.game.EditObj.UnitSelected = index2;
                let mut x1: i32 = this.game.Data.UnitObj[index2].X;
                let mut y1: i32 = this.game.Data.UnitObj[index2].Y;
                this.game.SelectX = x1;
                this.game.SelectY = y1;
                this.game.HandyFunctionsObj.CenterOnXY(x1, y1, true);
                windowReturnClass.AddCommand(4, 12);
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.AddUnitModel)
            {
              this.game.EditObj.TempHisModelUnit = -1;
              this.game.EditObj.TempHisUnit = -1;
              this.game.EditObj.TempRandom = -1;
              Form3::new( this.formref).Initialize(this.game.Data, 100, this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime, 0, this.game);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.standing1)
            {
              let mut unitCounter1: i32 = this.game.Data.UnitCounter;
              for (let mut index3: i32 = 0; index3 <= unitCounter1; index3 += 1)
              {
                if (this.game.Data.UnitObj[index3].Historical == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical & (this.game.Data.Round == 0 | this.game.Data.UnitObj[index3].Regime == this.game.Data.Turn))
                {
                  if (this.game.Data.UnitObj[index3].SODefendPercent == 0)
                    this.game.Data.UnitObj[index3].SODefendPercent = 25;
                  else if (this.game.Data.UnitObj[index3].SODefendPercent == 25)
                    this.game.Data.UnitObj[index3].SODefendPercent = 50;
                  else if (this.game.Data.UnitObj[index3].SODefendPercent == 50)
                    this.game.Data.UnitObj[index3].SODefendPercent = 75;
                  else
                    this.game.Data.UnitObj[index3].SODefendPercent = 0;
                }
              }
              let mut unitCounter2: i32 = this.game.Data.UnitCounter;
              for (let mut unr: i32 = 0; unr <= unitCounter2; unr += 1)
              {
                if (this.game.HandyFunctionsObj.IsUnitInHQChain(unr, this.game.EditObj.UnitSelected))
                  this.game.Data.UnitObj[unr].SODefendPercent = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SODefendPercent;
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.standing2)
            {
              if (this.game.Data.Round == 0 | this.game.Data.Turn == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime && this.game.HandyFunctionsObj.HasUnitAirSF(this.game.EditObj.UnitSelected))
              {
                if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop == 25)
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = 100;
                else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop == 50)
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = 25;
                else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop == 75)
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = 50;
                else
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = 75;
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.AddUnit)
            {
              this.game.EditObj.TempHisModelUnit = -1;
              this.game.EditObj.TempHisUnit = -1;
              this.game.EditObj.TempRandom = -1;
              Form3::new( this.formref).Initialize(this.game.Data, 101, 0, 0, this.game);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.SetCommander)
            {
              this.game.EditObj.TempHisModelUnit = -1;
              this.game.EditObj.TempHisUnit = -1;
              this.game.EditObj.TempRandom = -1;
              Form3::new( this.formref).Initialize(this.game.Data, 103, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, 0, this.game);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.HqUnit)
            {
              this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
              Form3::new( this.formref).Initialize(this.game.Data, 82, this.game.EditObj.OrderUnit, tGame: this.game);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.importId)
            {
              this.Import();
              this.DoStuff();
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.changeColor)
            {
              ColorDialog colorDialog = ColorDialog::new();
              colorDialog.Color = Color.FromArgb( byte.MaxValue, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Red, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Green, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Blue);
              if (colorDialog.ShowDialog() == DialogResult.OK)
              {
                UnitClass unitClass1 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected];
                Color color = colorDialog.Color;
                let mut b1: i32 =  color.B;
                unitClass1.Blue = b1;
                UnitClass unitClass2 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected];
                color = colorDialog.Color;
                let mut g: i32 =  color.G;
                unitClass2.Green = g;
                this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Red =  colorDialog.Color.R;
              }
              this.DoStuff();
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.MoveUnit)
            {
              this.game.EditObj.OrderType = 1;
              this.game.EditObj.TempCoordList = this.game.HandyFunctionsObj.MakeMovePrediction(this.game.EditObj.UnitSelected, this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, attackoptions: true, ismove: true);
              this.game.EditObj.TempCoordList.RemoveCoord(0);
              this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
              this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
              windowReturnClass.AddCommand(4, 12);
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.cancelid)
            {
              switch (this.game.EditObj.OrderType)
              {
                case 1:
                case 48:
                  this.game.EditObj.OrderType = 0;
                  if (this.game.EditObj.TempCoordList.counter < 3)
                    this.game.EditObj.TempCoordList = CoordList::new();
                  this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                  this.game.SelectX = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X;
                  this.game.SelectY = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y;
                  this.game.EditObj.MapSelected = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Map;
                  windowReturnClass.AddCommand(4, 12);
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                case 3:
                  this.game.EditObj.OrderType = 0;
                  this.game.EditObj.TempCoordList = CoordList::new();
                  this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                  this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
                  windowReturnClass.AddCommand(4, 12);
                  this.game.SelectX = this.game.EditObj.OrderX;
                  this.game.SelectY = this.game.EditObj.OrderY;
                  this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                  if (this.game.Data.Round == 0)
                    this.game.Data.Turn = -1;
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                default:
                  continue;
              }
            }
            else if (num1 == this.ChangeCounterUnit)
            {
              let mut historical: i32 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical;
              if (historical > -1)
              {
                str1: String = Interaction.InputBox("Give new name for unit", "Shadow Empire : Planetary Conquest", this.game.Data.HistoricalUnitObj[historical].Name.ToString());
                str2: String = Interaction.InputBox("Give new short name of unit", "Shadow Empire : Planetary Conquest", this.game.Data.HistoricalUnitObj[historical].CounterString);
                if (str1.Length > 0)
                  this.game.Data.HistoricalUnitObj[historical].Name = str1;
                this.game.Data.HistoricalUnitObj[historical].CounterString = str2;
                if (Operators.CompareString(Conversion.Val(str2).ToString(), str2, false) == 0)
                {
                  double a = Conversion.Val(str2);
                  if (this.game.Data.HistoricalUnitObj[historical].ModelMaster > -1 && a > (double) this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[historical].ModelMaster].NameCounter)
                    this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[historical].ModelMaster].NameCounter =  Math.Round(a);
                }
                let mut unitCounter: i32 = this.game.Data.UnitCounter;
                for (let mut index4: i32 = 0; index4 <= unitCounter; index4 += 1)
                {
                  if (this.game.Data.UnitObj[index4].Historical == historical)
                    this.game.Data.UnitObj[index4].Name = this.game.Data.HistoricalUnitObj[historical].Name;
                }
                windowReturnClass.AddCommand(4, 12);
                this.game.SelectX = this.game.EditObj.OrderX;
                this.game.SelectY = this.game.EditObj.OrderY;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              let mut num2: i32 =  Interaction.MsgBox((object) "Unit is not set to a historical unit.");
            }
            else if (num1 == this.RemoveUnit)
            {
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
              if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].LibId.libSlot == -1)
              {
                this.game.Data.RemoveHistoricalUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical);
                for (let mut unitCounter: i32 = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
                {
                  if (this.game.Data.UnitObj[unitCounter].PreDef == -1 & this.game.Data.UnitObj[unitCounter].Historical == -1)
                  {
                    data: DataClass = this.game.Data;
                    let mut nr: i32 = unitCounter;
                    let mut gameClass: GameClass = (GameClass) null;
                     let mut local: GameClass =  gameClass;
                    data.RemoveUnit(nr,  local);
                  }
                }
              }
              else
              {
                let mut historical: i32 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical;
                for (let mut unitCounter: i32 = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
                {
                  if (this.game.Data.UnitObj[unitCounter].Historical == historical)
                  {
                    this.game.Data.UnitObj[unitCounter].Historical = -1;
                    data: DataClass = this.game.Data;
                    let mut nr: i32 = unitCounter;
                    let mut gameClass: GameClass = (GameClass) null;
                     let mut local: GameClass =  gameClass;
                    data.RemoveUnit(nr,  local);
                  }
                }
              }
              this.game.EditObj.UnitSelected = -1;
              windowReturnClass.AddCommand(4, 12);
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    pub void Import()
    {
      str: String = "";
      path: String = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to import units/assigned officers from...", this.game.AppPath + this.game.ModScenarioDir, false);
      if (!File.Exists(path))
        return;
      let mut num1: i32 =  Interaction.MsgBox((object) "Ok hold on... this can take some time", Title: ((object) "Shadow Empire : Planetary Conquest"));
      this.game.FormRef.Cursor = Cursors.WaitCursor;
      this.game.EditObj.TempFileName = path;
      tempFileName: String = this.game.EditObj.TempFileName;
      this.game.HandyFunctionsObj.Unzip(tempFileName);
      dataClass1: DataClass = new DataClass(DontLoadGraphics: true);
      dataClass2: DataClass = DataClass.deserialize(tempFileName);
      this.game.HandyFunctionsObj.ZipFile(tempFileName);
      bool[] flagArray = new bool[dataClass2.UnitCounter + 1];
      if (dataClass2.MapObj[0].MapWidth > this.game.Data.MapObj[0].MapWidth | dataClass2.MapObj[0].MapHeight > this.game.Data.MapObj[0].MapHeight)
        str = "Map of import is larger than your current map.";
      if (str.Length == 0)
      {
        let mut unitCounter: i32 = dataClass2.UnitCounter;
        for (let mut index1: i32 = 0; index1 <= unitCounter; index1 += 1)
        {
          if (dataClass2.UnitObj[index1].PreDef == -1)
          {
            let mut historical: i32 = dataClass2.UnitObj[index1].Historical;
            if (dataClass2.HistoricalUnitObj[historical].CommanderName.Length > 0)
            {
              let mut libSlot: i32 = dataClass2.HistoricalUnitObj[historical].OffLibId.libSlot;
              if (libSlot > -1)
              {
                bool flag = false;
                if (this.game.Data.FindLibrary(dataClass2.LibraryObj[libSlot].name) > -1)
                {
                  let mut historicalUnitCounter: i32 = this.game.Data.HistoricalUnitCounter;
                  for (let mut index2: i32 = 0; index2 <= historicalUnitCounter; index2 += 1)
                  {
                    if (this.game.Data.HistoricalUnitObj[index2].LibId.id == dataClass2.HistoricalUnitObj[historical].OffLibId.id)
                      flag = true;
                    if (this.game.Data.HistoricalUnitObj[index2].OffLibId.id == dataClass2.HistoricalUnitObj[historical].OffLibId.id)
                      flag = true;
                  }
                  if (!flag)
                    str = str + "Current scenario's library: " + dataClass2.LibraryObj[libSlot].name + " is missing definition for officer: " + dataClass2.HistoricalUnitObj[historical].CommanderName;
                }
                else
                  str = str + "Current scenario missing library: " + dataClass2.LibraryObj[libSlot].name;
              }
              else
                str = str + dataClass2.HistoricalUnitObj[historical].CommanderName + "";
            }
            if (dataClass2.HistoricalUnitObj[historical].LibId.libSlot > -1)
            {
              let mut libSlot: i32 = dataClass2.HistoricalUnitObj[historical].LibId.libSlot;
              if (libSlot > -1)
              {
                bool flag = false;
                if (this.game.Data.FindLibrary(dataClass2.LibraryObj[libSlot].name) > -1)
                {
                  let mut historicalUnitCounter: i32 = this.game.Data.HistoricalUnitCounter;
                  for (let mut index3: i32 = 0; index3 <= historicalUnitCounter; index3 += 1)
                  {
                    if (this.game.Data.HistoricalUnitObj[index3].LibId.id == dataClass2.HistoricalUnitObj[historical].LibId.id)
                      flag = true;
                  }
                  if (!flag)
                    str = str + "Current scenario's library: " + dataClass2.LibraryObj[libSlot].name + " is missing definition for hist.unit: " + dataClass2.HistoricalUnitObj[historical].Name;
                }
                else
                  str = str + "Current scenario missing library: " + dataClass2.LibraryObj[libSlot].name;
              }
              else
                str = str + "Current scenario missing library: " + dataClass2.LibraryObj[libSlot].name;
            }
            else if (dataClass2.HistoricalUnitObj[historical].ModelMaster > -1)
            {
              let mut modelMaster: i32 = dataClass2.HistoricalUnitObj[historical].ModelMaster;
              if (modelMaster > -1)
              {
                if (dataClass2.HistoricalUnitObj[modelMaster].LibId.libSlot > -1)
                {
                  let mut libSlot: i32 = dataClass2.HistoricalUnitObj[modelMaster].LibId.libSlot;
                  if (libSlot > -1)
                  {
                    bool flag = false;
                    if (this.game.Data.FindLibrary(dataClass2.LibraryObj[libSlot].name) > -1)
                    {
                      let mut historicalUnitCounter: i32 = this.game.Data.HistoricalUnitCounter;
                      for (let mut index4: i32 = 0; index4 <= historicalUnitCounter; index4 += 1)
                      {
                        if (this.game.Data.HistoricalUnitObj[index4].LibId.id == dataClass2.HistoricalUnitObj[modelMaster].LibId.id)
                          flag = true;
                      }
                      if (!flag)
                        str = str + "Current scenario's library: " + dataClass2.LibraryObj[libSlot].name + " is missing definition for hist.unit model: " + dataClass2.HistoricalUnitObj[modelMaster].Name;
                    }
                    else
                      str = str + "Current scenario missing library: " + dataClass2.LibraryObj[libSlot].name;
                  }
                  else
                    str = str + "Current scenario missing library: " + dataClass2.LibraryObj[libSlot].name;
                }
                else
                  str = str + "Unit " + dataClass2.UnitObj[index1].Name + " using model that does not use a library.";
              }
              else
                str = str + "Unit " + dataClass2.UnitObj[index1].Name + " without library and without model.";
            }
          }
          if (str.Length > 0)
            break;
        }
      }
      if (str.Length == 0)
      {
        let mut mapWidth: i32 = dataClass2.MapObj[0].MapWidth;
        for (let mut index5: i32 = 0; index5 <= mapWidth; index5 += 1)
        {
          let mut mapHeight: i32 = dataClass2.MapObj[0].MapHeight;
          for (let mut index6: i32 = 0; index6 <= mapHeight; index6 += 1)
          {
            let mut num2: i32 = dataClass2.MapObj[0].HexObj[index5, index6].Regime <= -1 ? -1 : this.game.Data.FindRegimeFromSameLib( dataClass2.RegimeObj[dataClass2.MapObj[0].HexObj[index5, index6].Regime], "");
            this.game.Data.MapObj[0].HexObj[index5, index6].Regime = num2;
          }
        }
      }
      if (str.Length == 0)
      {
        for (let mut unitCounter: i32 = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
        {
          if (this.game.Data.UnitObj[unitCounter].PreDef == -1)
          {
            if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unitCounter].Historical].OffLibId.libSlot > -1)
            {
              let mut tempRegime: i32 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unitCounter].Historical].TempRegime;
              LibIdClass libIdClass = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unitCounter].Historical].OffLibId.Clone();
              this.game.Data.AddHistoricalUnit();
              this.game.ProcessingObj.SwapOfficer(this.game.Data.UnitObj[unitCounter].Regime, this.game.Data.UnitObj[unitCounter].Historical, this.game.Data.HistoricalUnitCounter, unitCounter);
              this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unitCounter].Historical].OffLibId = LibIdClass::new();
              this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].LibId = libIdClass;
              this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].Pool = true;
              this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unitCounter].Historical].TempRegime = tempRegime;
            }
            data: DataClass = this.game.Data;
            let mut nr: i32 = unitCounter;
            let mut gameClass: GameClass = (GameClass) null;
             let mut local: GameClass =  gameClass;
            data.RemoveUnit(nr,  local);
          }
        }
        for (let mut historicalUnitCounter: i32 = this.game.Data.HistoricalUnitCounter; historicalUnitCounter >= 0; historicalUnitCounter += -1)
        {
          if (this.game.Data.HistoricalUnitObj[historicalUnitCounter].LibId.libSlot == -1)
            this.game.Data.RemoveHistoricalUnit(historicalUnitCounter);
        }
      }
      if (str.Length == 0)
      {
        let mut unitCounter1: i32 = dataClass2.UnitCounter;
        for (let mut index7: i32 = 0; index7 <= unitCounter1; index7 += 1)
        {
          if (dataClass2.UnitObj[index7].PreDef == -1 & !flagArray[index7])
          {
            let mut historical: i32 = dataClass2.UnitObj[index7].Historical;
            if (dataClass2.HistoricalUnitObj[historical].LibId.libSlot > -1)
            {
              this.game.Data.FindRegimeFromSameLib( dataClass2.RegimeObj[dataClass2.HistoricalUnitObj[historical].TempRegime], dataClass2.LibraryObj[dataClass2.HistoricalUnitObj[historical].LibId.libSlot].name);
              let mut historicalFromSameLib: i32 = this.game.Data.FindHistoricalFromSameLib( dataClass2.HistoricalUnitObj[historical], dataClass2.LibraryObj[dataClass2.HistoricalUnitObj[historical].LibId.libSlot].name);
              this.game.EventRelatedObj.ExecAddHistoricalUnit(dataClass2.UnitObj[index7].X, dataClass2.UnitObj[index7].Y, this.game.Data.HistoricalUnitObj[historicalFromSameLib].ID, 0, "");
              let mut unitCounter2: i32 = dataClass2.UnitCounter;
              for (let mut index8: i32 = 0; index8 <= unitCounter2; index8 += 1)
              {
                if (dataClass2.UnitObj[index8].Historical == dataClass2.UnitObj[index7].Historical)
                {
                  flagArray[index8] = true;
                  for (let mut unitCounter3: i32 = this.game.Data.MapObj[0].HexObj[dataClass2.UnitObj[index7].X, dataClass2.UnitObj[index7].Y].UnitCounter; unitCounter3 >= 0; unitCounter3 += -1)
                  {
                    let mut unit: i32 = this.game.Data.MapObj[0].HexObj[dataClass2.UnitObj[index7].X, dataClass2.UnitObj[index7].Y].UnitList[unitCounter3];
                    if (this.game.Data.UnitObj[unit].Historical == historicalFromSameLib & this.game.Data.UnitObj[unit].HistoricalSubPart == dataClass2.UnitObj[index8].HistoricalSubPart)
                    {
                      this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unit].X, this.game.Data.UnitObj[unit].Y].RemoveUnitFromList(unit);
                      this.game.Data.MapObj[0].HexObj[dataClass2.UnitObj[index8].X, dataClass2.UnitObj[index8].Y].AddUnitToList(unit);
                    }
                  }
                }
              }
            }
            else
            {
              let mut regimeFromSameLib: i32 = this.game.Data.FindRegimeFromSameLib( dataClass2.RegimeObj[dataClass2.HistoricalUnitObj[historical].TempRegime], "");
              let mut modelMaster: i32 = dataClass2.HistoricalUnitObj[historical].ModelMaster;
              let mut historicalFromSameLib: i32 = this.game.Data.FindHistoricalFromSameLib( dataClass2.HistoricalUnitObj[modelMaster], dataClass2.LibraryObj[dataClass2.HistoricalUnitObj[modelMaster].LibId.libSlot].name);
              this.game.ProcessingObj.AddNewUnitBasedOnHistorical(dataClass2.UnitObj[index7].X, dataClass2.UnitObj[index7].Y, 0, regimeFromSameLib, historicalFromSameLib, freePPnoUnit: true, populateUnit: true);
              let mut historicalUnitCounter: i32 = this.game.Data.HistoricalUnitCounter;
              let mut unitCounter4: i32 = dataClass2.UnitCounter;
              for (let mut index9: i32 = 0; index9 <= unitCounter4; index9 += 1)
              {
                if (dataClass2.UnitObj[index9].Historical == dataClass2.UnitObj[index7].Historical)
                {
                  flagArray[index9] = true;
                  for (let mut unitCounter5: i32 = this.game.Data.MapObj[0].HexObj[dataClass2.UnitObj[index7].X, dataClass2.UnitObj[index7].Y].UnitCounter; unitCounter5 >= 0; unitCounter5 += -1)
                  {
                    let mut unit: i32 = this.game.Data.MapObj[0].HexObj[dataClass2.UnitObj[index7].X, dataClass2.UnitObj[index7].Y].UnitList[unitCounter5];
                    if (this.game.Data.UnitObj[unit].Historical == historicalUnitCounter & this.game.Data.UnitObj[unit].HistoricalSubPart == dataClass2.UnitObj[index9].HistoricalSubPart)
                    {
                      this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unit].X, this.game.Data.UnitObj[unit].Y].RemoveUnitFromList(unit);
                      this.game.Data.MapObj[0].HexObj[dataClass2.UnitObj[index9].X, dataClass2.UnitObj[index9].Y].AddUnitToList(unit);
                      this.game.Data.UnitObj[unit].X = dataClass2.UnitObj[index9].X;
                      this.game.Data.UnitObj[unit].Y = dataClass2.UnitObj[index9].Y;
                      this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unit].Historical].Counter = dataClass2.HistoricalUnitObj[dataClass2.UnitObj[index9].Historical].Counter;
                      this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unit].Historical].CounterString = dataClass2.HistoricalUnitObj[dataClass2.UnitObj[index9].Historical].CounterString;
                      break;
                    }
                  }
                }
              }
            }
            if (dataClass2.HistoricalUnitObj[historical].OffLibId.libSlot > -1)
            {
              let mut historicalBySameLib: i32 = this.game.Data.FindOffHistoricalBySameLib( dataClass2.HistoricalUnitObj[historical], dataClass2.LibraryObj[dataClass2.HistoricalUnitObj[historical].OffLibId.libSlot].name);
              LibIdClass libIdClass = this.game.Data.HistoricalUnitObj[historicalBySameLib].LibId.Clone();
              this.game.ProcessingObj.SwapOfficer(this.game.Data.UnitObj[this.game.Data.UnitCounter].Regime, this.game.Data.UnitObj[this.game.Data.UnitCounter].Historical, historicalBySameLib, this.game.Data.UnitCounter);
              this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.Data.UnitCounter].Historical].OffLibId = libIdClass.Clone();
            }
          }
        }
      }
      if (str.Length == 0)
      {
        let mut historicalUnitCounter1: i32 = this.game.Data.HistoricalUnitCounter;
        for (let mut index10: i32 = 0; index10 <= historicalUnitCounter1; index10 += 1)
        {
          if (this.game.Data.HistoricalUnitObj[index10].Model)
          {
            let mut historicalUnitCounter2: i32 = dataClass2.HistoricalUnitCounter;
            for (let mut index11: i32 = 0; index11 <= historicalUnitCounter2; index11 += 1)
            {
              if (dataClass2.HistoricalUnitObj[index11].Model && Operators.CompareString(this.game.Data.LibraryObj[this.game.Data.HistoricalUnitObj[index10].LibId.libSlot].name, dataClass2.LibraryObj[dataClass2.HistoricalUnitObj[index11].LibId.libSlot].name, false) == 0 && this.game.Data.HistoricalUnitObj[index10].LibId.id == dataClass2.HistoricalUnitObj[index11].LibId.id)
                this.game.Data.HistoricalUnitObj[index10].NameCounter = dataClass2.HistoricalUnitObj[index11].NameCounter;
            }
          }
        }
      }
      dataClass1 = (DataClass) null;
      this.game.EditObj.UnitSelected = -1;
      this.game.EditObj.OldUnit = -1;
      this.game.FormRef.Cursor = Cursors.Default;
      if (str.Length > 0)
      {
        let mut num3: i32 =  Interaction.MsgBox((object) ("ERROR IN IMPORT: " + str), Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      else
      {
        let mut num4: i32 =  Interaction.MsgBox((object) "Import completed succesfully", Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
    }
  }
}
