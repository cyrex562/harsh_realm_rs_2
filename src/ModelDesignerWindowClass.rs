// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ModelDesignerWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
  pub class ModelDesignerWindowClass : WindowClass
  {
     int TempText1;
     int temptext2;
     int temptext3;
     int temptext4;
     int temptext5;
     int temptext6;
     int temptext7;
     int temptext8;
     int temptext9;
     int temptext10;
     int TempText11;
     int temptext12;
     int temptext13;
     int temptext14;
     int temptext15;
     int temptext16;
     int temptext17;
     int temptext18;
     int temptext19;
     int temptext20;
     int TempText21;
     int temptext22;
     int temptext23;
     int temptext24;
     int temptext25;
     int temptext26;
     int temptext27;
     int temptext28;
     int temptext29;
     int temptext30;
     int TempText31;
     int temptext32;
     int temptext33;
     int temptext34;
     int temptext35;
     int temptext36;
     int temptext37;
     int temptext38;
     int temptext39;
     int temptext40;
     int temptext41;
     int temptext42;
     int temptext43;
     int temptext44;
     int temptext45;
     int temptext46;
     int but1id;
     int but1textid;
     int but1bid;
     int hqbut0;
     int hqbut1;
     int hqbut2;
     int but2id;
     int but2textid;
     int but3id;
     int but3textid;
     int but4id;
     int but4textid;
     int but5id;
     int but5textid;
     int but6id;
     int but6textid;
     int but7id;
     int but7textid;
     int descid;
     int sliderid;
     float tempBlink;
     int unr;
     int sfnr;
     int sftyp;
     int detailnr;
     int detailnr2;
     int detailnr3;
     int detailtype;
     int ammount;
     bool hqreach;
     int passenger;
     int OptionsListId;
     ListClass OptionsListObj;
     int OptionsList2Id;
     ListClass OptionsList2Obj;
     int OptionsList3Id;
     ListClass OptionsList3Obj;
     int OptionsList4Id;
     ListClass OptionsList4Obj;
     int OptionsList5Id;
     ListClass OptionsList5Obj;
     int OptionsList6Id;
     ListClass OptionsList6Obj;
     int combatListId;
     ListClass combatListObj;
     int combatList2Id;
     ListClass combatList2Obj;
     int StatTyp;
     int StatMode;
     int[] ChainHq;
     int HQselect;

    pub ModelDesignerWindowClass( GameClass tGame)
      : base( tGame, 1024, 768, BackSprite: tGame.BACKGROUND2MARC)
    {
      this.ChainHq = new int[3];
      this.detailnr3 = -1;
      this.detailnr = -1;
      this.detailnr2 = -1;
      this.DoStuff();
    }

    pub void DoStuff()
    {
      this.NewBackGroundAndClearAll(1024, 768, this.game.BACKGROUND2MARC);
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.TempText1 > 0)
        this.RemoveSubPart(this.TempText1);
      if (this.temptext2 > 0)
        this.RemoveSubPart(this.temptext2);
      if (this.temptext3 > 0)
        this.RemoveSubPart(this.temptext3);
      if (this.temptext4 > 0)
        this.RemoveSubPart(this.temptext4);
      if (this.temptext5 > 0)
        this.RemoveSubPart(this.temptext5);
      if (this.temptext6 > 0)
        this.RemoveSubPart(this.temptext6);
      if (this.temptext7 > 0)
        this.RemoveSubPart(this.temptext7);
      if (this.temptext8 > 0)
        this.RemoveSubPart(this.temptext8);
      if (this.temptext9 > 0)
        this.RemoveSubPart(this.temptext9);
      if (this.temptext10 > 0)
        this.RemoveSubPart(this.temptext10);
      if (this.TempText11 > 0)
        this.RemoveSubPart(this.TempText11);
      if (this.but1id > 0)
        this.RemoveSubPart(this.but1id);
      if (this.but1bid > 0)
        this.RemoveSubPart(this.but1bid);
      if (this.but1textid > 0)
        this.RemoveSubPart(this.but1textid);
      if (this.but2id > 0)
        this.RemoveSubPart(this.but2id);
      if (this.but2textid > 0)
        this.RemoveSubPart(this.but2textid);
      if (this.but3id > 0)
        this.RemoveSubPart(this.but3id);
      if (this.but3textid > 0)
        this.RemoveSubPart(this.but3textid);
      if (this.but4id > 0)
        this.RemoveSubPart(this.but4id);
      if (this.but4textid > 0)
        this.RemoveSubPart(this.but4textid);
      if (this.but5id > 0)
        this.RemoveSubPart(this.but5id);
      if (this.but5textid > 0)
        this.RemoveSubPart(this.but5textid);
      if (this.but6id > 0)
        this.RemoveSubPart(this.but6id);
      if (this.but6textid > 0)
        this.RemoveSubPart(this.but6textid);
      if (this.but7id > 0)
        this.RemoveSubPart(this.but7id);
      if (this.but7textid > 0)
        this.RemoveSubPart(this.but7textid);
      if (this.sliderid > 0)
        this.RemoveSubPart(this.sliderid);
      DrawMod.DrawText( objgraphics, "Model Designer", Font::new("Arial", 28f, FontStyle.Bold, GraphicsUnit.Pixel), 10, 10);
      this.OptionsListObj = ListClass::new();
      let mut num1: i32 = -1;
      let mut tlistselect1: i32 = -1;
      let mut historicalUnitCounter: i32 = this.game.Data.HistoricalUnitCounter;
      for (let mut tdata: i32 = 0; tdata <= historicalUnitCounter; tdata += 1)
      {
        if (this.game.Data.HistoricalUnitObj[tdata].TempRegime == this.game.Data.Turn & this.game.Data.HistoricalUnitObj[tdata].Model)
        {
          num1 += 1;
          if (this.detailnr == tdata)
            tlistselect1 = num1;
          if (this.game.Data.HistoricalUnitObj[tdata].Fixed)
            this.OptionsListObj.add(this.game.Data.HistoricalUnitObj[tdata].Name, tdata, Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[tdata].PP)) + "pp", "-", Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[tdata].Counter)));
          else
            this.OptionsListObj.add(this.game.Data.HistoricalUnitObj[tdata].Name, tdata, Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[tdata].PP)) + "pp", "Fixed", Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[tdata].Counter)));
        }
      }
      if (this.OptionsListId > 0)
      {
        this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect1);
        this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
      }
      else
      {
        ListClass optionsListObj = this.OptionsListObj;
        let mut tlistselect2: i32 = tlistselect1;
        let mut game: GameClass = this.game;
         Bitmap local1 =  this.OwnBitmap;
        Font font =  null;
         Font local2 =  font;
        let mut tsubpart: SubPartClass =  new ListSubPartClass(optionsListObj, 15, 300, tlistselect2, game, tHeader: "Models", tShowPair: true, tValueWidth: 160, tbackbitmap: ( local1), bbx: 20, bby: 50, overruleFont: ( local2));
        this.OptionsListId = this.AddSubPart( tsubpart, 20, 50, 300, 288, 0);
      }
      let mut tsubpart1: SubPartClass =  new TextButtonPartClass("Add", 100, tBackbitmap: ( this.OwnBitmap), bbx: 340, bby: 70);
      this.TempText1 = this.AddSubPart( tsubpart1, 340, 70, 100, 35, 1);
      if (this.detailnr > -1)
      {
        if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
        {
          let mut tsubpart2: SubPartClass =  new TextButtonPartClass("Delete", 100, tBackbitmap: ( this.OwnBitmap), bbx: 340, bby: 120, tinactive: true);
          this.temptext2 = this.AddSubPart( tsubpart2, 340, 120, 100, 35, 0);
        }
        else
        {
          let mut tsubpart3: SubPartClass =  new TextButtonPartClass("Delete", 100, tBackbitmap: ( this.OwnBitmap), bbx: 340, bby: 120);
          this.temptext2 = this.AddSubPart( tsubpart3, 340, 120, 100, 35, 1);
        }
        if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
        {
          let mut tsubpart4: SubPartClass =  new TextButtonPartClass("Name", 100, tBackbitmap: ( this.OwnBitmap), bbx: 340, bby: 170, tinactive: true);
          this.temptext3 = this.AddSubPart( tsubpart4, 340, 170, 150, 35, 0);
        }
        else
        {
          let mut tsubpart5: SubPartClass =  new TextButtonPartClass("Name", 100, tBackbitmap: ( this.OwnBitmap), bbx: 340, bby: 170);
          this.temptext3 = this.AddSubPart( tsubpart5, 340, 170, 100, 35, 1);
        }
        if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
        {
          let mut tsubpart6: SubPartClass =  new TextButtonPartClass("Counter", 100, tBackbitmap: ( this.OwnBitmap), bbx: 340, bby: 220, tinactive: true);
          this.TempText11 = this.AddSubPart( tsubpart6, 340, 220, 150, 35, 0);
        }
        else
        {
          let mut tsubpart7: SubPartClass =  new TextButtonPartClass("Counter", 100, tBackbitmap: ( this.OwnBitmap), bbx: 340, bby: 220);
          this.TempText11 = this.AddSubPart( tsubpart7, 340, 220, 100, 35, 1);
        }
        this.OptionsList2Obj = ListClass::new();
        let mut num2: i32 = -1;
        let mut tlistselect3: i32 = -1;
        let mut tdata: i32 = 0;
        do
        {
          if (this.game.Data.HistoricalUnitObj[this.detailnr].SubParts[tdata] > -1)
          {
            num2 += 1;
            let mut preDef: i32 = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[this.detailnr].SubParts[tdata]);
            if (this.detailnr2 == tdata)
              tlistselect3 = num2;
            this.OptionsList2Obj.add(this.game.Data.UnitObj[preDef].Name, tdata, Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].Designation[tdata])));
          }
          tdata += 1;
        }
        while (tdata <= 9);
        if (this.OptionsList2Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList2Id)].Refresh(this.OptionsList2Obj, tlistselect3);
          this.SubPartFlag[this.SubpartNr(this.OptionsList2Id)] = true;
        }
        else
        {
          ListClass optionsList2Obj = this.OptionsList2Obj;
          let mut tlistselect4: i32 = tlistselect3;
          let mut game: GameClass = this.game;
          tHeader: String = this.game.Data.HistoricalUnitObj[this.detailnr].Name + " Sub Unit Models";
           Bitmap local3 =  this.OwnBitmap;
          Font font =  null;
           Font local4 =  font;
          let mut tsubpart8: SubPartClass =  new ListSubPartClass(optionsList2Obj, 15, 300, tlistselect4, game, tHeader: tHeader, tShowPair: true, tbackbitmap: ( local3), bbx: 520, bby: 50, overruleFont: ( local4));
          this.OptionsList2Id = this.AddSubPart( tsubpart8, 520, 50, 300, 288, 0);
        }
      }
      if (this.detailnr > -1 && this.detailnr2 > -1)
      {
        if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
        {
          let mut tsubpart9: SubPartClass =  new TextButtonPartClass("Name", 100, tBackbitmap: ( this.OwnBitmap), bbx: 840, bby: 70, tinactive: true);
          this.temptext4 = this.AddSubPart( tsubpart9, 840, 70, 100, 35, 0);
        }
        else
        {
          let mut tsubpart10: SubPartClass =  new TextButtonPartClass("Name", 100, tBackbitmap: ( this.OwnBitmap), bbx: 840, bby: 70);
          this.temptext4 = this.AddSubPart( tsubpart10, 840, 70, 100, 35, 1);
        }
        if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
        {
          let mut tsubpart11: SubPartClass =  new TextButtonPartClass("Overdraw", 100, tBackbitmap: ( this.OwnBitmap), bbx: 840, bby: 120, tinactive: true);
          this.temptext5 = this.AddSubPart( tsubpart11, 840, 120, 100, 35, 0);
        }
        else
        {
          let mut tsubpart12: SubPartClass =  new TextButtonPartClass("Overdraw", 100, tBackbitmap: ( this.OwnBitmap), bbx: 840, bby: 120);
          this.temptext5 = this.AddSubPart( tsubpart12, 840, 120, 100, 35, 1);
        }
        this.OptionsList3Obj = ListClass::new();
        let mut num3: i32 = -1;
        let mut tlistselect5: i32 = -1;
        let mut preDef: i32 = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[this.detailnr].SubParts[this.detailnr2]);
        let mut sfCount: i32 = this.game.Data.UnitObj[preDef].SFCount;
        for (let mut index: i32 = 0; index <= sfCount; index += 1)
        {
          num3 += 1;
          let mut sf: i32 = this.game.Data.UnitObj[preDef].SFList[index];
          if (this.detailnr3 == sf)
            tlistselect5 = num3;
          tvalue: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sf].Qty)) + " X " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Ratio)) + " = " + Strings.Trim(Conversion.Str((object) (this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Ratio)));
          this.OptionsList3Obj.add(Strings.Trim(Conversion.Str((object) (this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Ratio))) + "x " + this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Name, sf, tvalue, this.game.Data.PeopleObj[this.game.Data.SFObj[sf].People].Name);
        }
        if (this.OptionsList3Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, tlistselect5);
          this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
        }
        else
        {
          ListClass optionsList3Obj = this.OptionsList3Obj;
          let mut tlistselect6: i32 = tlistselect5;
          let mut game: GameClass = this.game;
          tHeader: String = this.game.Data.UnitObj[preDef].Name + " composition";
           Bitmap local5 =  this.OwnBitmap;
          Font font =  null;
           Font local6 =  font;
          let mut tsubpart13: SubPartClass =  new ListSubPartClass(optionsList3Obj, 10, 600, tlistselect6, game, tHeader: tHeader, tShowPair: true, tValueWidth: 350, tbackbitmap: ( local5), bbx: 20, bby: 400, overruleFont: ( local6));
          this.OptionsList3Id = this.AddSubPart( tsubpart13, 20, 400, 600, 208, 0);
        }
        if (this.game.Data.UnitObj[preDef].SFCount < 7)
        {
          if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
          {
            let mut tsubpart14: SubPartClass =  new TextButtonPartClass("Add", 100, tBackbitmap: ( this.OwnBitmap), bbx: 640, bby: 420, tinactive: true);
            this.temptext6 = this.AddSubPart( tsubpart14, 640, 420, 100, 35, 0);
          }
          else
          {
            let mut tsubpart15: SubPartClass =  new TextButtonPartClass("Add", 100, tBackbitmap: ( this.OwnBitmap), bbx: 640, bby: 420);
            this.temptext6 = this.AddSubPart( tsubpart15, 640, 420, 100, 35, 1);
          }
        }
        else
        {
          let mut tsubpart16: SubPartClass =  new TextButtonPartClass("Add", 100, tBackbitmap: ( this.OwnBitmap), bbx: 640, bby: 420, tinactive: true);
          this.temptext6 = this.AddSubPart( tsubpart16, 640, 420, 100, 35, 0);
        }
        if (this.detailnr3 > -1)
        {
          if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
          {
            let mut tsubpart17: SubPartClass =  new TextButtonPartClass("Delete", 100, tBackbitmap: ( this.OwnBitmap), bbx: 640, bby: 470, tinactive: true);
            this.temptext7 = this.AddSubPart( tsubpart17, 640, 470, 100, 35, 0);
          }
          else
          {
            let mut tsubpart18: SubPartClass =  new TextButtonPartClass("Delete", 100, tBackbitmap: ( this.OwnBitmap), bbx: 640, bby: 470);
            this.temptext7 = this.AddSubPart( tsubpart18, 640, 470, 100, 35, 1);
          }
          if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
          {
            let mut tsubpart19: SubPartClass =  new TextButtonPartClass("People", 100, tBackbitmap: ( this.OwnBitmap), bbx: 640, bby: 520, tinactive: true);
            this.temptext8 = this.AddSubPart( tsubpart19, 640, 520, 100, 35, 0);
          }
          else
          {
            let mut tsubpart20: SubPartClass =  new TextButtonPartClass("People", 100, tBackbitmap: ( this.OwnBitmap), bbx: 640, bby: 520);
            this.temptext8 = this.AddSubPart( tsubpart20, 640, 520, 100, 35, 1);
          }
          if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
          {
            let mut tsubpart21: SubPartClass =  new TextButtonPartClass("SFType", 100, tBackbitmap: ( this.OwnBitmap), bbx: 640, bby: 520, tinactive: true);
            this.temptext9 = this.AddSubPart( tsubpart21, 640, 570, 100, 35, 0);
          }
          else
          {
            let mut tsubpart22: SubPartClass =  new TextButtonPartClass("SFType", 100, tBackbitmap: ( this.OwnBitmap), bbx: 640, bby: 520);
            this.temptext9 = this.AddSubPart( tsubpart22, 640, 570, 100, 35, 1);
          }
          if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
          {
            let mut tsubpart23: SubPartClass =  new TextButtonPartClass("Qty", 100, tBackbitmap: ( this.OwnBitmap), bbx: 640, bby: 620, tinactive: true);
            this.temptext10 = this.AddSubPart( tsubpart23, 640, 620, 100, 35, 0);
          }
          else
          {
            let mut tsubpart24: SubPartClass =  new TextButtonPartClass("Qty", 100, tBackbitmap: ( this.OwnBitmap), bbx: 640, bby: 620);
            this.temptext10 = this.AddSubPart( tsubpart24, 640, 620, 100, 35, 1);
          }
        }
      }
      let mut tsubpart25: SubPartClass =  new SteveButtonPartClass(this.game.BACKBUTTON, tBackbitmap: ( this.OwnBitmap), bbx: 20, bby: 710);
      this.but1id = this.AddSubPart( tsubpart25, 20, 710, 35, 35, 1);
      if (Information.IsNothing((object) objgraphics))
        return;
      objgraphics.Dispose();
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      try
      {
        if (nr == 27 | nr == 32)
        {
          this.game.EditObj.OrderType = 0;
          this.game.EditObj.TempCoordList = CoordList::new();
          windowReturnClass.AddCommand(3, 3);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return windowReturnClass;
    }

    pub void DoRefresh() => this.DoStuff();

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
            if (num1 == this.TempText11)
            {
              let mut num2: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give new overdraw graphic # (0-" + Conversion.Str((object) this.game.NATO.GetUpperBound(0)) + ")", "Shadow Empire : Planetary Conquest")));
              if (num2 < 0 | num2 > this.game.NATO.GetUpperBound(0))
              {
                let mut num3: i32 =  Interaction.MsgBox((object) "Overdraw change aborted. Wrong input.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                return windowReturnClass;
              }
              this.game.Data.HistoricalUnitObj[this.detailnr].Counter = num2;
              let mut historicalUnitCounter: i32 = this.game.Data.HistoricalUnitCounter;
              for (let mut index2: i32 = 0; index2 <= historicalUnitCounter; index2 += 1)
              {
                if (this.game.Data.HistoricalUnitObj[index2].ModelMaster == this.detailnr)
                  this.game.Data.HistoricalUnitObj[index2].Counter = num2;
              }
              this.DoStuff();
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.temptext10)
            {
              let mut num4: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give new qty ( before multiplication )", "Shadow Empire : Planetary Conquest")));
              if (num4 < 0 | num4 > 99)
              {
                let mut num5: i32 =  Interaction.MsgBox((object) "Overdraw change aborted. Min 1, Max 99. Wrong input.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                return windowReturnClass;
              }
              this.game.Data.SFObj[this.detailnr3].Qty = num4;
              this.DoStuff();
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.temptext9)
            {
              Form3::new( this.formref).Initialize(this.game.Data, 6, this.detailnr3);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.temptext8)
            {
              Form3::new( this.formref).Initialize(this.game.Data, 7, this.detailnr3);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.temptext6)
            {
              this.game.Data.AddSF(this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[this.detailnr].SubParts[this.detailnr2]));
              this.game.Data.SFObj[this.game.Data.SFCounter].Type = 0;
              this.game.Data.SFObj[this.game.Data.SFCounter].People = this.game.Data.RegimeObj[this.game.Data.Turn].People;
              this.game.Data.SFObj[this.game.Data.SFCounter].Qty = 1;
              this.DoStuff();
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            int preDef;
            if (num1 == this.temptext7)
            {
              preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[this.detailnr].SubParts[this.detailnr2]);
              this.game.Data.RemoveSF(this.detailnr3);
              this.DoStuff();
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.temptext5)
            {
              let mut num6: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give new overdraw graphic # (0-" + Conversion.Str((object) this.game.NATO.GetUpperBound(0)) + ")", "Shadow Empire : Planetary Conquest")));
              if (num6 < 0 | num6 > this.game.NATO.GetUpperBound(0))
              {
                let mut num7: i32 =  Interaction.MsgBox((object) "Overdraw change aborted. Wrong input.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                return windowReturnClass;
              }
              preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[this.detailnr].SubParts[this.detailnr2]);
              this.game.Data.HistoricalUnitObj[this.detailnr].Designation[this.detailnr2] = num6;
              this.DoStuff();
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.temptext4)
            {
              str: String = Interaction.InputBox("Give new name for this subunit model", "Shadow Empire : Planetary Conquest");
              this.game.Data.UnitObj[this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[this.detailnr].SubParts[this.detailnr2])].Name = str;
              this.DoStuff();
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.temptext3)
            {
              this.game.Data.HistoricalUnitObj[this.detailnr].Name = Interaction.InputBox("Give new name for this model", "Shadow Empire : Planetary Conquest");
              this.DoStuff();
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.temptext2)
            {
              if (Interaction.MsgBox((object) "Are you sure you want to delete this model? If you do any units with this model will be put to ad-hoc status.", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
              {
                this.game.Data.RemoveHistoricalUnit(this.detailnr);
                this.detailnr = -1;
                this.detailnr2 = -2;
                this.detailnr3 = -3;
              }
              this.DoStuff();
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.TempText1)
            {
              if (Interaction.MsgBox((object) "Add a HQ?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
              {
                int num8;
                int historicalUnitCounter;
                if ((double) this.game.Data.RuleVar[348] == 1.0)
                {
                  num8 =  Math.Round(Conversion.Val(Interaction.InputBox("Level of the HQ? (1=Corps, 2=Army, 3=Armygroup, 4=Highest)", "Shadow Empire : Planetary Conquest")));
                  if (num8 < 1 | num8 > 4)
                  {
                    let mut num9: i32 =  Interaction.MsgBox((object) "Adding aborted. Wrong input.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    return windowReturnClass;
                  }
                  this.game.Data.AddHistoricalUnit();
                  historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
                  this.game.Data.HistoricalUnitObj[historicalUnitCounter].Type = 4 + num8;
                  this.game.Data.HistoricalUnitObj[historicalUnitCounter].CounterString = "";
                }
                else
                {
                  this.game.Data.AddHistoricalUnit();
                  historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
                  this.game.Data.HistoricalUnitObj[historicalUnitCounter].Type = 5;
                  this.game.Data.HistoricalUnitObj[historicalUnitCounter].CounterString = "";
                }
                switch (num8)
                {
                  case 1:
                    this.game.Data.HistoricalUnitObj[historicalUnitCounter].Name = "New Corps";
                    break;
                  case 2:
                    this.game.Data.HistoricalUnitObj[historicalUnitCounter].Name = "New Army";
                    break;
                  case 3:
                    this.game.Data.HistoricalUnitObj[historicalUnitCounter].Name = "New Armygroup";
                    break;
                  default:
                    this.game.Data.HistoricalUnitObj[historicalUnitCounter].Name = "New High Command";
                    break;
                }
                this.game.Data.HistoricalUnitObj[historicalUnitCounter].Model = true;
                this.game.Data.HistoricalUnitObj[historicalUnitCounter].TempRegime = this.game.Data.Turn;
                this.game.Data.HistoricalUnitObj[historicalUnitCounter].PP = 5 * num8;
                this.game.Data.AddUnit(-1, -1, -1);
                let mut unitCounter: i32 = this.game.Data.UnitCounter;
                this.game.Data.UnitObj[unitCounter].PreDef = this.game.HandyFunctionsObj.GetNextPreDefNr();
                this.game.Data.UnitObj[unitCounter].Regime = this.game.Data.Turn;
                this.game.Data.HistoricalUnitObj[historicalUnitCounter].SubParts[0] = this.game.Data.UnitObj[unitCounter].PreDef;
                this.game.Data.UnitObj[unitCounter].Name = "HQ Subunit";
              }
              else
              {
                let mut num10: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Number of subunits? (1-4)", "Shadow Empire : Planetary Conquest")));
                if (num10 < 1 | num10 > 4)
                {
                  let mut num11: i32 =  Interaction.MsgBox((object) "Adding aborted. Wrong input.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  return windowReturnClass;
                }
                this.game.Data.AddHistoricalUnit();
                let mut historicalUnitCounter: i32 = this.game.Data.HistoricalUnitCounter;
                this.game.Data.HistoricalUnitObj[historicalUnitCounter].Type = 1;
                if (num10 > 1)
                  this.game.Data.HistoricalUnitObj[historicalUnitCounter].Type = 2;
                this.game.Data.HistoricalUnitObj[historicalUnitCounter].CounterString = "";
                this.game.Data.HistoricalUnitObj[historicalUnitCounter].Model = true;
                switch (num10)
                {
                  case 1:
                    this.game.Data.HistoricalUnitObj[historicalUnitCounter].Name = "New Independent Unit";
                    break;
                  case 2:
                    this.game.Data.HistoricalUnitObj[historicalUnitCounter].Name = "New Brigade";
                    break;
                  default:
                    this.game.Data.HistoricalUnitObj[historicalUnitCounter].Name = "New Division";
                    break;
                }
                this.game.Data.HistoricalUnitObj[historicalUnitCounter].PP = 1 * num10;
                this.game.Data.HistoricalUnitObj[historicalUnitCounter].TempRegime = this.game.Data.Turn;
                let mut num12: i32 = num10;
                for (let mut index3: i32 = 1; index3 <= num12; index3 += 1)
                {
                  this.game.Data.AddUnit(-1, -1, -1);
                  let mut unitCounter: i32 = this.game.Data.UnitCounter;
                  this.game.Data.UnitObj[unitCounter].PreDef = this.game.HandyFunctionsObj.GetNextPreDefNr();
                  this.game.Data.UnitObj[unitCounter].Regime = this.game.Data.Turn;
                  this.game.Data.HistoricalUnitObj[historicalUnitCounter].SubParts[index3 - 1] = this.game.Data.UnitObj[unitCounter].PreDef;
                  if (index3 == 1)
                    this.game.Data.UnitObj[unitCounter].Name = "1st Regiment Subunit";
                  if (index3 == 2)
                    this.game.Data.UnitObj[unitCounter].Name = "2nd Regiment Subunit";
                  if (index3 == 3)
                    this.game.Data.UnitObj[unitCounter].Name = "3th Regiment Subunit";
                  if (index3 == 4)
                    this.game.Data.UnitObj[unitCounter].Name = "4th Regiment Subunit";
                }
              }
              this.DoStuff();
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsListId)
            {
              let mut num13: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              if (num13 > -1)
              {
                this.detailnr = num13;
                if (this.OptionsList2Id > 0)
                {
                  this.RemoveSubPart(this.OptionsList2Id);
                  this.OptionsList2Id = 0;
                }
                this.detailnr2 = -1;
              }
              else
                this.detailnr = -1;
              this.DoStuff();
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsList2Id)
            {
              let mut num14: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              if (num14 > -1)
              {
                this.detailnr2 = num14;
                if (this.OptionsList3Id > 0)
                {
                  this.RemoveSubPart(this.OptionsList3Id);
                  this.OptionsList3Id = 0;
                }
                this.detailnr3 = -1;
              }
              else
                this.detailnr2 = -1;
              this.DoStuff();
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsList3Id)
            {
              let mut num15: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.detailnr3 = num15 <= -1 ? -1 : num15;
              this.DoStuff();
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.but1id)
            {
              this.game.EditObj.OrderType = 0;
              this.game.EditObj.TempCoordList = CoordList::new();
              windowReturnClass.AddCommand(3, 3);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 != this.sliderid)
              return windowReturnClass;
            this.detailnr2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1], b);
            this.DoStuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
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
