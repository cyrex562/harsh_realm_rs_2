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
  public class ModelDesignerWindowClass : WindowClass
  {
    private int TempText1;
    private int temptext2;
    private int temptext3;
    private int temptext4;
    private int temptext5;
    private int temptext6;
    private int temptext7;
    private int temptext8;
    private int temptext9;
    private int temptext10;
    private int TempText11;
    private int temptext12;
    private int temptext13;
    private int temptext14;
    private int temptext15;
    private int temptext16;
    private int temptext17;
    private int temptext18;
    private int temptext19;
    private int temptext20;
    private int TempText21;
    private int temptext22;
    private int temptext23;
    private int temptext24;
    private int temptext25;
    private int temptext26;
    private int temptext27;
    private int temptext28;
    private int temptext29;
    private int temptext30;
    private int TempText31;
    private int temptext32;
    private int temptext33;
    private int temptext34;
    private int temptext35;
    private int temptext36;
    private int temptext37;
    private int temptext38;
    private int temptext39;
    private int temptext40;
    private int temptext41;
    private int temptext42;
    private int temptext43;
    private int temptext44;
    private int temptext45;
    private int temptext46;
    private int but1id;
    private int but1textid;
    private int but1bid;
    private int hqbut0;
    private int hqbut1;
    private int hqbut2;
    private int but2id;
    private int but2textid;
    private int but3id;
    private int but3textid;
    private int but4id;
    private int but4textid;
    private int but5id;
    private int but5textid;
    private int but6id;
    private int but6textid;
    private int but7id;
    private int but7textid;
    private int descid;
    private int sliderid;
    private float tempBlink;
    private int unr;
    private int sfnr;
    private int sftyp;
    private int detailnr;
    private int detailnr2;
    private int detailnr3;
    private int detailtype;
    private int ammount;
    private bool hqreach;
    private int passenger;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int OptionsList2Id;
    private ListClass OptionsList2Obj;
    private int OptionsList3Id;
    private ListClass OptionsList3Obj;
    private int OptionsList4Id;
    private ListClass OptionsList4Obj;
    private int OptionsList5Id;
    private ListClass OptionsList5Obj;
    private int OptionsList6Id;
    private ListClass OptionsList6Obj;
    private int combatListId;
    private ListClass combatListObj;
    private int combatList2Id;
    private ListClass combatList2Obj;
    private int StatTyp;
    private int StatMode;
    private int[] ChainHq;
    private int HQselect;

    public ModelDesignerWindowClass(ref GameClass tGame)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND2MARC)
    {
      this.ChainHq = new int[3];
      this.detailnr3 = -1;
      this.detailnr = -1;
      this.detailnr2 = -1;
      this.DoStuff();
    }

    public void DoStuff()
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
      DrawMod.DrawText(ref objgraphics, "Model Designer", new Font("Arial", 28f, FontStyle.Bold, GraphicsUnit.Pixel), 10, 10);
      this.OptionsListObj = new ListClass();
      int num1 = -1;
      int tlistselect1 = -1;
      int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
      for (int tdata = 0; tdata <= historicalUnitCounter; ++tdata)
      {
        if (this.game.Data.HistoricalUnitObj[tdata].TempRegime == this.game.Data.Turn & this.game.Data.HistoricalUnitObj[tdata].Model)
        {
          ++num1;
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
        int tlistselect2 = tlistselect1;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(optionsListObj, 15, 300, tlistselect2, game, tHeader: "Models", tShowPair: true, tValueWidth: 160, tbackbitmap: (ref local1), bbx: 20, bby: 50, overruleFont: (ref local2));
        this.OptionsListId = this.AddSubPart(ref tsubpart, 20, 50, 300, 288, 0);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Add", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 340, bby: 70);
      this.TempText1 = this.AddSubPart(ref tsubpart1, 340, 70, 100, 35, 1);
      if (this.detailnr > -1)
      {
        if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
        {
          SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Delete", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 340, bby: 120, tinactive: true);
          this.temptext2 = this.AddSubPart(ref tsubpart2, 340, 120, 100, 35, 0);
        }
        else
        {
          SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Delete", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 340, bby: 120);
          this.temptext2 = this.AddSubPart(ref tsubpart3, 340, 120, 100, 35, 1);
        }
        if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
        {
          SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Name", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 340, bby: 170, tinactive: true);
          this.temptext3 = this.AddSubPart(ref tsubpart4, 340, 170, 150, 35, 0);
        }
        else
        {
          SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("Name", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 340, bby: 170);
          this.temptext3 = this.AddSubPart(ref tsubpart5, 340, 170, 100, 35, 1);
        }
        if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
        {
          SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("Counter", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 340, bby: 220, tinactive: true);
          this.TempText11 = this.AddSubPart(ref tsubpart6, 340, 220, 150, 35, 0);
        }
        else
        {
          SubPartClass tsubpart7 = (SubPartClass) new TextButtonPartClass("Counter", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 340, bby: 220);
          this.TempText11 = this.AddSubPart(ref tsubpart7, 340, 220, 100, 35, 1);
        }
        this.OptionsList2Obj = new ListClass();
        int num2 = -1;
        int tlistselect3 = -1;
        int tdata = 0;
        do
        {
          if (this.game.Data.HistoricalUnitObj[this.detailnr].SubParts[tdata] > -1)
          {
            ++num2;
            int preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[this.detailnr].SubParts[tdata]);
            if (this.detailnr2 == tdata)
              tlistselect3 = num2;
            this.OptionsList2Obj.add(this.game.Data.UnitObj[preDef].Name, tdata, Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].Designation[tdata])));
          }
          ++tdata;
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
          int tlistselect4 = tlistselect3;
          GameClass game = this.game;
          string tHeader = this.game.Data.HistoricalUnitObj[this.detailnr].Name + " Sub Unit Models";
          ref Bitmap local3 = ref this.OwnBitmap;
          Font font = (Font) null;
          ref Font local4 = ref font;
          SubPartClass tsubpart8 = (SubPartClass) new ListSubPartClass(optionsList2Obj, 15, 300, tlistselect4, game, tHeader: tHeader, tShowPair: true, tbackbitmap: (ref local3), bbx: 520, bby: 50, overruleFont: (ref local4));
          this.OptionsList2Id = this.AddSubPart(ref tsubpart8, 520, 50, 300, 288, 0);
        }
      }
      if (this.detailnr > -1 && this.detailnr2 > -1)
      {
        if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
        {
          SubPartClass tsubpart9 = (SubPartClass) new TextButtonPartClass("Name", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 840, bby: 70, tinactive: true);
          this.temptext4 = this.AddSubPart(ref tsubpart9, 840, 70, 100, 35, 0);
        }
        else
        {
          SubPartClass tsubpart10 = (SubPartClass) new TextButtonPartClass("Name", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 840, bby: 70);
          this.temptext4 = this.AddSubPart(ref tsubpart10, 840, 70, 100, 35, 1);
        }
        if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
        {
          SubPartClass tsubpart11 = (SubPartClass) new TextButtonPartClass("Overdraw", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 840, bby: 120, tinactive: true);
          this.temptext5 = this.AddSubPart(ref tsubpart11, 840, 120, 100, 35, 0);
        }
        else
        {
          SubPartClass tsubpart12 = (SubPartClass) new TextButtonPartClass("Overdraw", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 840, bby: 120);
          this.temptext5 = this.AddSubPart(ref tsubpart12, 840, 120, 100, 35, 1);
        }
        this.OptionsList3Obj = new ListClass();
        int num3 = -1;
        int tlistselect5 = -1;
        int preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[this.detailnr].SubParts[this.detailnr2]);
        int sfCount = this.game.Data.UnitObj[preDef].SFCount;
        for (int index = 0; index <= sfCount; ++index)
        {
          ++num3;
          int sf = this.game.Data.UnitObj[preDef].SFList[index];
          if (this.detailnr3 == sf)
            tlistselect5 = num3;
          string tvalue = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sf].Qty)) + " X " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Ratio)) + " = " + Strings.Trim(Conversion.Str((object) (this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Ratio)));
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
          int tlistselect6 = tlistselect5;
          GameClass game = this.game;
          string tHeader = this.game.Data.UnitObj[preDef].Name + " composition";
          ref Bitmap local5 = ref this.OwnBitmap;
          Font font = (Font) null;
          ref Font local6 = ref font;
          SubPartClass tsubpart13 = (SubPartClass) new ListSubPartClass(optionsList3Obj, 10, 600, tlistselect6, game, tHeader: tHeader, tShowPair: true, tValueWidth: 350, tbackbitmap: (ref local5), bbx: 20, bby: 400, overruleFont: (ref local6));
          this.OptionsList3Id = this.AddSubPart(ref tsubpart13, 20, 400, 600, 208, 0);
        }
        if (this.game.Data.UnitObj[preDef].SFCount < 7)
        {
          if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
          {
            SubPartClass tsubpart14 = (SubPartClass) new TextButtonPartClass("Add", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 640, bby: 420, tinactive: true);
            this.temptext6 = this.AddSubPart(ref tsubpart14, 640, 420, 100, 35, 0);
          }
          else
          {
            SubPartClass tsubpart15 = (SubPartClass) new TextButtonPartClass("Add", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 640, bby: 420);
            this.temptext6 = this.AddSubPart(ref tsubpart15, 640, 420, 100, 35, 1);
          }
        }
        else
        {
          SubPartClass tsubpart16 = (SubPartClass) new TextButtonPartClass("Add", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 640, bby: 420, tinactive: true);
          this.temptext6 = this.AddSubPart(ref tsubpart16, 640, 420, 100, 35, 0);
        }
        if (this.detailnr3 > -1)
        {
          if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
          {
            SubPartClass tsubpart17 = (SubPartClass) new TextButtonPartClass("Delete", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 640, bby: 470, tinactive: true);
            this.temptext7 = this.AddSubPart(ref tsubpart17, 640, 470, 100, 35, 0);
          }
          else
          {
            SubPartClass tsubpart18 = (SubPartClass) new TextButtonPartClass("Delete", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 640, bby: 470);
            this.temptext7 = this.AddSubPart(ref tsubpart18, 640, 470, 100, 35, 1);
          }
          if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
          {
            SubPartClass tsubpart19 = (SubPartClass) new TextButtonPartClass("People", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 640, bby: 520, tinactive: true);
            this.temptext8 = this.AddSubPart(ref tsubpart19, 640, 520, 100, 35, 0);
          }
          else
          {
            SubPartClass tsubpart20 = (SubPartClass) new TextButtonPartClass("People", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 640, bby: 520);
            this.temptext8 = this.AddSubPart(ref tsubpart20, 640, 520, 100, 35, 1);
          }
          if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
          {
            SubPartClass tsubpart21 = (SubPartClass) new TextButtonPartClass("SFType", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 640, bby: 520, tinactive: true);
            this.temptext9 = this.AddSubPart(ref tsubpart21, 640, 570, 100, 35, 0);
          }
          else
          {
            SubPartClass tsubpart22 = (SubPartClass) new TextButtonPartClass("SFType", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 640, bby: 520);
            this.temptext9 = this.AddSubPart(ref tsubpart22, 640, 570, 100, 35, 1);
          }
          if (!this.game.Data.HistoricalUnitObj[this.detailnr].Fixed)
          {
            SubPartClass tsubpart23 = (SubPartClass) new TextButtonPartClass("Qty", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 640, bby: 620, tinactive: true);
            this.temptext10 = this.AddSubPart(ref tsubpart23, 640, 620, 100, 35, 0);
          }
          else
          {
            SubPartClass tsubpart24 = (SubPartClass) new TextButtonPartClass("Qty", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 640, bby: 620);
            this.temptext10 = this.AddSubPart(ref tsubpart24, 640, 620, 100, 35, 1);
          }
        }
      }
      SubPartClass tsubpart25 = (SubPartClass) new SteveButtonPartClass(this.game.BACKBUTTON, tBackbitmap: (ref this.OwnBitmap), bbx: 20, bby: 710);
      this.but1id = this.AddSubPart(ref tsubpart25, 20, 710, 35, 35, 1);
      if (Information.IsNothing((object) objgraphics))
        return;
      objgraphics.Dispose();
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr == 27 | nr == 32)
        {
          this.game.EditObj.OrderType = 0;
          this.game.EditObj.TempCoordList = new CoordList();
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

    public override void DoRefresh() => this.DoStuff();

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num1 = this.SubPartID[index1];
            if (num1 == this.TempText11)
            {
              int num2 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new overdraw graphic # (0-" + Conversion.Str((object) this.game.NATO.GetUpperBound(0)) + ")", "Shadow Empire : Planetary Conquest")));
              if (num2 < 0 | num2 > this.game.NATO.GetUpperBound(0))
              {
                int num3 = (int) Interaction.MsgBox((object) "Overdraw change aborted. Wrong input.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                return windowReturnClass;
              }
              this.game.Data.HistoricalUnitObj[this.detailnr].Counter = num2;
              int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
              for (int index2 = 0; index2 <= historicalUnitCounter; ++index2)
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
              int num4 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new qty ( before multiplication )", "Shadow Empire : Planetary Conquest")));
              if (num4 < 0 | num4 > 99)
              {
                int num5 = (int) Interaction.MsgBox((object) "Overdraw change aborted. Min 1, Max 99. Wrong input.", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
              new Form3((Form) this.formref).Initialize(this.game.Data, 6, this.detailnr3);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.temptext8)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 7, this.detailnr3);
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
              int num6 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new overdraw graphic # (0-" + Conversion.Str((object) this.game.NATO.GetUpperBound(0)) + ")", "Shadow Empire : Planetary Conquest")));
              if (num6 < 0 | num6 > this.game.NATO.GetUpperBound(0))
              {
                int num7 = (int) Interaction.MsgBox((object) "Overdraw change aborted. Wrong input.", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
              string str = Interaction.InputBox("Give new name for this subunit model", "Shadow Empire : Planetary Conquest");
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
                  num8 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Level of the HQ? (1=Corps, 2=Army, 3=Armygroup, 4=Highest)", "Shadow Empire : Planetary Conquest")));
                  if (num8 < 1 | num8 > 4)
                  {
                    int num9 = (int) Interaction.MsgBox((object) "Adding aborted. Wrong input.", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
                int unitCounter = this.game.Data.UnitCounter;
                this.game.Data.UnitObj[unitCounter].PreDef = this.game.HandyFunctionsObj.GetNextPreDefNr();
                this.game.Data.UnitObj[unitCounter].Regime = this.game.Data.Turn;
                this.game.Data.HistoricalUnitObj[historicalUnitCounter].SubParts[0] = this.game.Data.UnitObj[unitCounter].PreDef;
                this.game.Data.UnitObj[unitCounter].Name = "HQ Subunit";
              }
              else
              {
                int num10 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Number of subunits? (1-4)", "Shadow Empire : Planetary Conquest")));
                if (num10 < 1 | num10 > 4)
                {
                  int num11 = (int) Interaction.MsgBox((object) "Adding aborted. Wrong input.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  return windowReturnClass;
                }
                this.game.Data.AddHistoricalUnit();
                int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
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
                int num12 = num10;
                for (int index3 = 1; index3 <= num12; ++index3)
                {
                  this.game.Data.AddUnit(-1, -1, -1);
                  int unitCounter = this.game.Data.UnitCounter;
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
              int num13 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
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
              int num14 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
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
              int num15 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.detailnr3 = num15 <= -1 ? -1 : num15;
              this.DoStuff();
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.but1id)
            {
              this.game.EditObj.OrderType = 0;
              this.game.EditObj.TempCoordList = new CoordList();
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
