// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ActionCardWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class ActionCardWindowClass : WindowClass
  {
    private int UnitListId;
    private ListClass UnitListObj;
    private int libListId;
    private ListClass libListObj;
    private int UnitList2Id;
    private ListClass UnitList2Obj;
    private int BAddUnitId;
    private int cloneid;
    private int clonetextid;
    private int BAddUnitTextId;
    private int BNameId;
    private int BNameTextId;
    private int BRemoveUnitId;
    private int BRemoveUnitTextId;
    private int b1id;
    private int b1bid;
    private int b2id;
    private int b2bid;
    private int b3id;
    private int b3bid;
    private int b4id;
    private int b4bid;
    private int a1id;
    private int a1bid;
    private int a2id;
    private int a2bid;
    private int a3id;
    private int a3bid;
    private int a4id;
    private int a4bid;
    private int a5id;
    private int a5bid;
    private int aa4id;
    private int aa4bid;
    private int aa5id;
    private int aa5bid;
    private int a6id;
    private int a6bid;
    private int a7id;
    private int a7bid;
    private int a8id;
    private int a8bid;
    private int a9id;
    private int a9bid;
    private int a10id;
    private int a10bid;
    private int a11id;
    private int a11bid;
    private int a12id;
    private int a12bid;
    private int a13id;
    private int a13bid;
    private int aa13id;
    private int aa13bid;
    private int a14id;
    private int a14bid;
    private int a15id;
    private int a15bid;
    private int a16id;
    private int a16bid;
    private int a17id;
    private int a17bid;
    private int a18id;
    private int a18bid;
    private int a19id;
    private int a19bid;
    private int a20id;
    private int a20bid;
    private int a21id;
    private int a21bid;
    private int a22id;
    private int a22bid;
    private int a23id;
    private int a23bid;
    private int UnitNr;
    private int ceilingnr;
    private int x1id;
    private int x2id;
    private int x3id;
    private int libnr;
    private string ss;

    public ActionCardWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Action Cards")
    {
      this.UnitNr = -1;
      this.ceilingnr = -1;
      this.libnr = -1;
      this.MakeUnitListGUI();
    }

    public override void DoRefresh() => this.MakeUnitTypeItemGUI();

    private void MakeUnitListGUI()
    {
      if (this.UnitListId > 0)
        this.RemoveSubPart(this.UnitListId);
      if (this.libListId > 0)
        this.RemoveSubPart(this.libListId);
      this.libListObj = new ListClass();
      this.libListObj.add("All", -2);
      int num1 = -1;
      int num2 = 0;
      int libraryCounter = this.game.Data.LibraryCounter;
      for (int index = 0; index <= libraryCounter; ++index)
      {
        ++num2;
        if (this.libnr == index)
          num1 = num2;
        this.libListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.LibraryObj[index].name, index);
      }
      if (this.libnr == -1)
        num1 = 0;
      ListClass libListObj = this.libListObj;
      int tlistselect1 = num1;
      GameClass game1 = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font1 = (Font) null;
      ref Font local2 = ref font1;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(libListObj, 9, 200, tlistselect1, game1, tHeader: "Libraries", tbackbitmap: (ref local1), bbx: 10, bby: 55, overruleFont: (ref local2));
      this.libListId = this.AddSubPart(ref tsubpart1, 10, 55, 200, 192, 0);
      int num3 = -1;
      int num4 = -1;
      if (this.game.Data.ActionCardCounter > -1)
      {
        this.UnitListObj = new ListClass();
        int actionCardCounter = this.game.Data.ActionCardCounter;
        for (int index = 0; index <= actionCardCounter; ++index)
        {
          if (this.game.Data.ActionCardObj[index].LibId.libSlot == this.libnr | this.libnr == -1)
          {
            ++num4;
            this.UnitListObj.add(Strings.Trim(Conversion.Str((object) index)) + ") " + this.game.Data.ActionCardObj[index].Title, index);
            if (this.UnitNr == index)
              num3 = num4;
          }
        }
        ListClass unitListObj = this.UnitListObj;
        int tlistselect2 = num3;
        GameClass game2 = this.game;
        ref Bitmap local3 = ref this.OwnBitmap;
        Font font2 = (Font) null;
        ref Font local4 = ref font2;
        SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(unitListObj, 20, 300, tlistselect2, game2, tHeader: "Action Cards", tbackbitmap: (ref local3), bbx: 10, bby: 277, overruleFont: (ref local4));
        this.UnitListId = this.AddSubPart(ref tsubpart2, 10, 277, 300, 352, 0);
        if (this.UnitNr > -1)
          this.MakeUnitTypeItemGUI();
      }
      if (this.BAddUnitId > 0)
        this.RemoveSubPart(this.BAddUnitId);
      if (this.BAddUnitTextId > 0)
        this.RemoveSubPart(this.BAddUnitTextId);
      if (this.b2id > 0)
        this.RemoveSubPart(this.b2id);
      if (this.b2bid > 0)
        this.RemoveSubPart(this.b2bid);
      this.ss = "Click to add an action card";
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.BAddUnitId = this.AddSubPart(ref tsubpart3, 320, 60, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Add Action Card", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.BAddUnitTextId = this.AddSubPart(ref tsubpart4, 350, 59, 200, 20, 0);
      this.ss = "Click to import ALL actioncards from a different scenario";
      SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.b2id = this.AddSubPart(ref tsubpart5, 620, 60, 32, 16, 1);
      SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("Import ALL cards", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b2bid = this.AddSubPart(ref tsubpart6, 650, 59, 200, 20, 0);
    }

    private void MakeUnitTypeItemGUI()
    {
      if (this.BNameId > 0)
        this.RemoveSubPart(this.BNameId);
      if (this.BNameTextId > 0)
        this.RemoveSubPart(this.BNameTextId);
      if (this.BRemoveUnitId > 0)
        this.RemoveSubPart(this.BRemoveUnitId);
      if (this.BRemoveUnitTextId > 0)
        this.RemoveSubPart(this.BRemoveUnitTextId);
      if (this.cloneid > 0)
        this.RemoveSubPart(this.cloneid);
      if (this.clonetextid > 0)
        this.RemoveSubPart(this.clonetextid);
      if (this.x1id > 0)
        this.RemoveSubPart(this.x1id);
      if (this.x2id > 0)
        this.RemoveSubPart(this.x2id);
      if (this.x3id > 0)
        this.RemoveSubPart(this.x3id);
      if (this.b1id > 0)
        this.RemoveSubPart(this.b1id);
      if (this.b1bid > 0)
        this.RemoveSubPart(this.b1bid);
      if (this.b3id > 0)
        this.RemoveSubPart(this.b3id);
      if (this.b3bid > 0)
        this.RemoveSubPart(this.b3bid);
      if (this.b4id > 0)
        this.RemoveSubPart(this.b4id);
      if (this.b4bid > 0)
        this.RemoveSubPart(this.b4bid);
      if (this.a1id > 0)
        this.RemoveSubPart(this.a1id);
      if (this.a1bid > 0)
        this.RemoveSubPart(this.a1bid);
      if (this.a2id > 0)
        this.RemoveSubPart(this.a2id);
      if (this.a2bid > 0)
        this.RemoveSubPart(this.a2bid);
      if (this.a3id > 0)
        this.RemoveSubPart(this.a3id);
      if (this.a3bid > 0)
        this.RemoveSubPart(this.a3bid);
      if (this.a4id > 0)
        this.RemoveSubPart(this.a4id);
      if (this.a4bid > 0)
        this.RemoveSubPart(this.a4bid);
      if (this.a5id > 0)
        this.RemoveSubPart(this.a5id);
      if (this.a5bid > 0)
        this.RemoveSubPart(this.a5bid);
      if (this.aa4id > 0)
        this.RemoveSubPart(this.aa4id);
      if (this.aa4bid > 0)
        this.RemoveSubPart(this.aa4bid);
      if (this.aa5id > 0)
        this.RemoveSubPart(this.aa5id);
      if (this.aa5bid > 0)
        this.RemoveSubPart(this.aa5bid);
      if (this.a6id > 0)
        this.RemoveSubPart(this.a6id);
      if (this.a6bid > 0)
        this.RemoveSubPart(this.a6bid);
      if (this.a7id > 0)
        this.RemoveSubPart(this.a7id);
      if (this.a7bid > 0)
        this.RemoveSubPart(this.a7bid);
      if (this.a8id > 0)
        this.RemoveSubPart(this.a8id);
      if (this.a8bid > 0)
        this.RemoveSubPart(this.a8bid);
      if (this.a9id > 0)
        this.RemoveSubPart(this.a9id);
      if (this.a9bid > 0)
        this.RemoveSubPart(this.a9bid);
      if (this.a10id > 0)
        this.RemoveSubPart(this.a10id);
      if (this.a10bid > 0)
        this.RemoveSubPart(this.a10bid);
      if (this.a11id > 0)
        this.RemoveSubPart(this.a11id);
      if (this.a11bid > 0)
        this.RemoveSubPart(this.a11bid);
      if (this.a12id > 0)
        this.RemoveSubPart(this.a12id);
      if (this.a12bid > 0)
        this.RemoveSubPart(this.a12bid);
      if (this.a13id > 0)
        this.RemoveSubPart(this.a13id);
      if (this.a13bid > 0)
        this.RemoveSubPart(this.a13bid);
      if (this.aa13id > 0)
        this.RemoveSubPart(this.aa13id);
      if (this.aa13bid > 0)
        this.RemoveSubPart(this.aa13bid);
      if (this.a14id > 0)
        this.RemoveSubPart(this.a14id);
      if (this.a14bid > 0)
        this.RemoveSubPart(this.a14bid);
      if (this.a15id > 0)
        this.RemoveSubPart(this.a15id);
      if (this.a15bid > 0)
        this.RemoveSubPart(this.a15bid);
      if (this.a16id > 0)
        this.RemoveSubPart(this.a16id);
      if (this.a16bid > 0)
        this.RemoveSubPart(this.a16bid);
      if (this.a17id > 0)
        this.RemoveSubPart(this.a17id);
      if (this.a17bid > 0)
        this.RemoveSubPart(this.a17bid);
      if (this.a18id > 0)
        this.RemoveSubPart(this.a18id);
      if (this.a18bid > 0)
        this.RemoveSubPart(this.a18bid);
      if (this.a19id > 0)
        this.RemoveSubPart(this.a19id);
      if (this.a19bid > 0)
        this.RemoveSubPart(this.a19bid);
      if (this.a20id > 0)
        this.RemoveSubPart(this.a20id);
      if (this.a20bid > 0)
        this.RemoveSubPart(this.a20bid);
      if (this.a21id > 0)
        this.RemoveSubPart(this.a21id);
      if (this.a21bid > 0)
        this.RemoveSubPart(this.a21bid);
      if (this.a22id > 0)
        this.RemoveSubPart(this.a22id);
      if (this.a22bid > 0)
        this.RemoveSubPart(this.a22bid);
      if (this.a23id > 0)
        this.RemoveSubPart(this.a23id);
      if (this.a23bid > 0)
        this.RemoveSubPart(this.a23bid);
      if (this.UnitList2Id > 0)
        this.RemoveSubPart(this.UnitList2Id);
      if (this.UnitNr <= -1)
        return;
      this.ss = "";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.BNameId = this.AddSubPart(ref tsubpart1, 320, 200, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Title: " + this.game.Data.ActionCardObj[this.UnitNr].Title + " (#" + Strings.Trim(Conversion.Str((object) this.UnitNr)) + ")", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 500, 20, false, tDescript: this.ss);
      this.BNameTextId = this.AddSubPart(ref tsubpart2, 350, 199, 500, 20, 0);
      this.ss = "";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a1id = this.AddSubPart(ref tsubpart2, 320, 240, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("PPCost: " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].PPCost), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 500, 20, false, tDescript: this.ss);
      this.a1bid = this.AddSubPart(ref tsubpart2, 350, 239, 500, 20, 0);
      this.ss = "";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a2id = this.AddSubPart(ref tsubpart2, 320, 220, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Text: " + this.game.Data.ActionCardObj[this.UnitNr].Text, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 500, 20, false, tDescript: this.ss);
      this.a2bid = this.AddSubPart(ref tsubpart2, 350, 219, 500, 20, 0);
      this.ss = "";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a3id = this.AddSubPart(ref tsubpart2, 320, 260, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("ExecuteEvent: " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].ExecuteEvent), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 500, 20, false, tDescript: this.ss);
      this.a3bid = this.AddSubPart(ref tsubpart2, 350, 259, 500, 20, 0);
      this.ss = "Give event pic # to set the picture used by the actioncards";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a4id = this.AddSubPart(ref tsubpart2, 320, 280, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("EventPicNr: " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].EventPicNr), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a4bid = this.AddSubPart(ref tsubpart2, 350, 279, 200, 20, 0);
      if (this.game.Data.ActionCardObj[this.UnitNr].EventPicNr > -1 & this.game.Data.ActionCardObj[this.UnitNr].EventPicNr <= this.game.Data.EventPicCounter)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[this.UnitNr].EventPicNr], tResizeX: 150, tresizeY: 150);
        this.aa5id = this.AddSubPart(ref tsubpart2, 350, 500, 150, 150, 0);
      }
      this.ss = "Regimes with AlternativeActionCardPics=true use this alterantive event pic #";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.aa4id = this.AddSubPart(ref tsubpart2, 620, 280, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Alt. EventPicNr: " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].AlternateEventPicNr), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.aa4bid = this.AddSubPart(ref tsubpart2, 650, 279, 200, 20, 0);
      if (this.game.Data.ActionCardObj[this.UnitNr].EventPicNr > -1 & this.game.Data.ActionCardObj[this.UnitNr].EventPicNr <= this.game.Data.EventPicCounter && this.game.Data.ActionCardObj[this.UnitNr].AlternateEventPicNr > -1)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.Data.EventPicNr[this.game.Data.ActionCardObj[this.UnitNr].AlternateEventPicNr], tResizeX: 150, tresizeY: 150);
        this.aa5bid = this.AddSubPart(ref tsubpart2, 650, 500, 150, 150, 0);
      }
      this.ss = "";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a5id = this.AddSubPart(ref tsubpart2, 320, 300, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("ColorScheme: " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].ColorScheme), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 500, 20, false, tDescript: this.ss);
      this.a5bid = this.AddSubPart(ref tsubpart2, 350, 299, 500, 20, 0);
      this.ss = "If this card is with a historicalunit officer the AI will play the card randomly if 0. >0 it will play event to determine target unit(areax) or hex(areax,areay)";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a6id = this.AddSubPart(ref tsubpart2, 320, 320, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("AILabel: " + (Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].AILabel) + ", " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].AILabel2) + ", " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].aILabel3)), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 500, 20, false, tDescript: this.ss);
      this.a6bid = this.AddSubPart(ref tsubpart2, 350, 319, 500, 20, 0);
      this.ss = "tempvar0,tempvar1 will be passed to event.";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a12id = this.AddSubPart(ref tsubpart2, 320, 340, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("TempVar0: " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].TempVar0), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 100, 20, false, tDescript: this.ss);
      this.a12bid = this.AddSubPart(ref tsubpart2, 350, 339, 100, 20, 0);
      this.ss = "tempvar0,tempvar1 will be passed to event.";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a13id = this.AddSubPart(ref tsubpart2, 480, 340, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("TempVar1: " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].TempVar1), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 100, 20, false, tDescript: this.ss);
      this.a13bid = this.AddSubPart(ref tsubpart2, 510, 339, 100, 20, 0);
      this.ss = "do nothing special=0, 1=only show card with corps, 2=only show card with army or higher";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.aa13id = this.AddSubPart(ref tsubpart2, 320, 360, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("LimitedOfficerShow: " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].LimitedShow), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.aa13bid = this.AddSubPart(ref tsubpart2, 350, 359, 300, 20, 0);
      this.ss = "Specify -1 if card has no hisvar cost of any kind";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.b3id = this.AddSubPart(ref tsubpart2, 620, 340, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("HisVarType: " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].HisVarCostType), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b3bid = this.AddSubPart(ref tsubpart2, 650, 339, 200, 20, 0);
      this.ss = "Specify the cost in points for the HisVarType specified. ";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.b4id = this.AddSubPart(ref tsubpart2, 620, 360, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("HisVarCost: " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].HisVarCostQty), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b4bid = this.AddSubPart(ref tsubpart2, 650, 359, 200, 20, 0);
      this.ss = "Defining the highlighted hexes for user pic. User selection will be passed as tempvar2,tempvar3 to event.";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a14id = this.AddSubPart(ref tsubpart2, 320, 380, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("AreaSlot: " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].AreaSlot), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 500, 20, false, tDescript: this.ss);
      this.a14bid = this.AddSubPart(ref tsubpart2, 350, 379, 500, 20, 0);
      this.ss = "Defining the highlighted hexes for user pic. User selection will be passed as tempvar2,tempvar3 to event.";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a15id = this.AddSubPart(ref tsubpart2, 320, 400, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("AreaValue: " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].AreaValue), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 500, 20, false, tDescript: this.ss);
      this.a15bid = this.AddSubPart(ref tsubpart2, 350, 399, 500, 20, 0);
      this.ss = "-1=for none. Pre Execute event is executed the moment before you select something on the popup. Use to define selectable zones. Or set Selectable Units";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a16id = this.AddSubPart(ref tsubpart2, 320, 420, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("PreExecuteEvent: " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].PreExecuteEvent), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a16bid = this.AddSubPart(ref tsubpart2, 350, 419, 200, 20, 0);
      this.ss = "Determines if this event will give you a popup to select a unit.";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a17id = this.AddSubPart(ref tsubpart2, 320, 440, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("SelectUnit: " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].UnitSelect), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 500, 20, false, tDescript: this.ss);
      this.a17bid = this.AddSubPart(ref tsubpart2, 350, 439, 500, 20, 0);
      this.ss = "The minisprite is used to draw the small officer cards. but you dont have to specify. -1=dont use.";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a18id = this.AddSubPart(ref tsubpart2, 320, 460, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Nato Mini Sprite: " + Conversion.Str((object) this.game.Data.ActionCardObj[this.UnitNr].Nato), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 500, 20, false, tDescript: this.ss);
      this.a18bid = this.AddSubPart(ref tsubpart2, 350, 459, 500, 20, 0);
      this.ss = "The mouse over text will appear if new GUI is used and card is right clicked.";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a19id = this.AddSubPart(ref tsubpart2, 320, 480, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Mouse Over " + this.game.Data.ActionCardObj[this.UnitNr].MouseOver, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 250, 20, false, tDescript: this.ss);
      this.a19bid = this.AddSubPart(ref tsubpart2, 350, 479, 250, 20, 0);
      this.ss = "Card Category. Also see rulevar 905 to activate this in GUI. ";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a20id = this.AddSubPart(ref tsubpart2, 620, 420, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Category =" + this.game.Data.ActionCardObj[this.UnitNr].Category.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a20bid = this.AddSubPart(ref tsubpart2, 650, 419, 200, 20, 0);
      this.ss = "Change library";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a21id = this.AddSubPart(ref tsubpart2, 620, 440, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Set Library" + this.game.Data.ActionCardObj[this.UnitNr].LibId.libSlot.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a21bid = this.AddSubPart(ref tsubpart2, 650, 439, 200, 20, 0);
      this.ss = "Set Small Gfx.  ";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a22id = this.AddSubPart(ref tsubpart2, 620, 460, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Small Gfx =" + this.game.Data.ActionCardObj[this.UnitNr].SmallGfx.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a22bid = this.AddSubPart(ref tsubpart2, 650, 459, 200, 20, 0);
      this.ss = "Ignore Popup if no selection possible of either units or hexes. The actual event can read if its skipped by calling CheckPopupSkipped().  ";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a23id = this.AddSubPart(ref tsubpart2, 620, 480, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("IgnorePopupIfNoSel =" + this.game.Data.ActionCardObj[this.UnitNr].IgnorePopupIfNoSelect.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a23bid = this.AddSubPart(ref tsubpart2, 650, 479, 200, 20, 0);
      this.ss = "Click to remove this action card.";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
      this.BRemoveUnitId = this.AddSubPart(ref tsubpart2, 320, 80, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Remove this Action Card", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.BRemoveUnitTextId = this.AddSubPart(ref tsubpart2, 350, 79, 200, 20, 0);
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawActionCardMarc2(0, this.UnitNr));
      this.x1id = this.AddSubPart(ref tsubpart2, 830, 100, 190, 266, 0);
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawActionCardMarc2(0, this.UnitNr, size: 2));
      this.x2id = this.AddSubPart(ref tsubpart2, 830, 400, 105, 147, 0);
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawActionCardMarc2(0, this.UnitNr, size: 3));
      this.x3id = this.AddSubPart(ref tsubpart2, 830, 600, 33, 46, 0);
    }

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
            if (num1 == this.libListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.libnr = num2;
                this.UnitNr = -1;
                this.MakeUnitListGUI();
              }
              else if (num2 == -2)
              {
                this.libnr = -1;
                this.UnitNr = -1;
                this.MakeUnitListGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.UnitListId)
            {
              int num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num3 > -1)
              {
                this.UnitNr = num3;
                this.MakeUnitTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddUnitId)
            {
              this.game.Data.AddActionCard();
              this.UnitNr = this.game.Data.ActionCardCounter;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a1id)
            {
              int num4 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Set PPCost", "Shadow Empire : Planetary Conquest")));
              if (num4 > -9999 & num4 < 9999)
                this.game.Data.ActionCardObj[this.UnitNr].PPCost = num4;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a12id)
            {
              int num5 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Set TempVar0 (-1=dont set)", "Shadow Empire : Planetary Conquest")));
              if (num5 > -99999 & num5 < 99999)
                this.game.Data.ActionCardObj[this.UnitNr].TempVar0 = num5;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b2id)
            {
              string str = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to load all stringlists from...", this.game.AppPath + "scenarios\\", false);
              if (File.Exists(str))
              {
                this.game.HandyFunctionsObj.Unzip(str);
                DataClass dataClass = DataClass.deserialize(str);
                this.game.HandyFunctionsObj.ZipFile(str);
                int actionCardCounter = dataClass.ActionCardCounter;
                for (int index2 = 0; index2 <= actionCardCounter; ++index2)
                {
                  this.game.Data.AddActionCard();
                  this.game.Data.ActionCardObj[this.game.Data.ActionCardCounter] = dataClass.ActionCardObj[index2].Clone();
                }
                this.UnitNr = this.game.Data.ActionCardCounter;
                this.MakeUnitListGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a13id)
            {
              int num6 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Set TempVar1 (-1=dont set)", "Shadow Empire : Planetary Conquest")));
              if (num6 > -99999 & num6 < 99999)
                this.game.Data.ActionCardObj[this.UnitNr].TempVar1 = num6;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a14id)
            {
              int num7 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Set Areaslot(-1=dont set)", "Shadow Empire : Planetary Conquest")));
              if (num7 > -99999 & num7 < 99999)
                this.game.Data.ActionCardObj[this.UnitNr].AreaSlot = num7;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.aa13id)
            {
              int num8 = (int) Math.Round(Conversion.Val(Interaction.InputBox("0,1 or 2", "Shadow Empire : Planetary Conquest")));
              if (num8 >= 0 & num8 <= 2)
                this.game.Data.ActionCardObj[this.UnitNr].LimitedShow = num8;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a23id)
            {
              this.game.Data.ActionCardObj[this.UnitNr].IgnorePopupIfNoSelect = !this.game.Data.ActionCardObj[this.UnitNr].IgnorePopupIfNoSelect;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a15id)
            {
              int num9 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Set Areavalue(-1=dont set)", "Shadow Empire : Planetary Conquest")));
              if (num9 > -99999 & num9 < 99999)
                this.game.Data.ActionCardObj[this.UnitNr].AreaValue = num9;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a18id)
            {
              int num10 = (int) Math.Round(Conversion.Val(Interaction.InputBox("NATO Sprite? (-1=dont set)", "Shadow Empire : Planetary Conquest")));
              if (num10 >= -1 & num10 <= this.game.NATO.GetUpperBound(0))
                this.game.Data.ActionCardObj[this.UnitNr].Nato = num10;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a22id)
            {
              int num11 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Small Gfx nr? (-1=dont set)", "Shadow Empire : Planetary Conquest")));
              if (num11 >= -1 & num11 <= this.game.Data.SmallPicCounter)
                this.game.Data.ActionCardObj[this.UnitNr].SmallGfx = num11;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b3id)
            {
              int num12 = (int) Math.Round(Conversion.Val(Interaction.InputBox("HisVar Type (-1=none)", "Shadow Empire : Planetary Conquest")));
              if (num12 >= -1 & num12 <= 99)
                this.game.Data.ActionCardObj[this.UnitNr].HisVarCostType = num12;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b4id)
            {
              int num13 = (int) Math.Round(Conversion.Val(Interaction.InputBox("HisVar Qty", "Shadow Empire : Planetary Conquest")));
              if (num13 >= -1 & num13 <= 99)
                this.game.Data.ActionCardObj[this.UnitNr].HisVarCostQty = num13;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a17id)
            {
              this.game.Data.ActionCardObj[this.UnitNr].UnitSelect = !this.game.Data.ActionCardObj[this.UnitNr].UnitSelect;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a2id)
            {
              new Form2((Form) this.formref).Initialize(this.game.Data, 4, this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a19id)
            {
              new Form2((Form) this.formref).Initialize(this.game.Data, 9, this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a3id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 31, this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a21id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 109, this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a16id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 35, this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a4id)
            {
              int num14 = (int) Math.Round(Conversion.Val(Interaction.InputBox("set eventPICTURE nr (-1=none)", "Shadow Empire : Planetary Conquest")));
              if (num14 > -2 & num14 <= this.game.Data.EventPicCounter)
                this.game.Data.ActionCardObj[this.UnitNr].EventPicNr = num14;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.aa4id)
            {
              int num15 = (int) Math.Round(Conversion.Val(Interaction.InputBox("set alt. eventPICTURE nr (-1=none)", "Shadow Empire : Planetary Conquest")));
              if (num15 > -2 & num15 <= this.game.Data.EventPicCounter)
                this.game.Data.ActionCardObj[this.UnitNr].AlternateEventPicNr = num15;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a20id)
            {
              int num16 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give category # (-1=none, 1-5=category#)", "Shadow Empire : Planetary Conquest")));
              if (num16 > -2 & num16 <= 5)
                this.game.Data.ActionCardObj[this.UnitNr].Category = num16;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a5id)
            {
              int num17 = (int) Math.Round(Conversion.Val(Interaction.InputBox("set colorscheme nr (0,1,2,3,4)", "Shadow Empire : Planetary Conquest")));
              if (num17 > -1 & num17 <= 999)
                this.game.Data.ActionCardObj[this.UnitNr].ColorScheme = num17;
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a6id)
            {
              int num18 = (int) Math.Round(Conversion.Val(Interaction.InputBox("set hardcoded ai label (0-99999)", "Shadow Empire : Planetary Conquest")));
              if (num18 > -1 & num18 <= 99999)
              {
                this.game.Data.ActionCardObj[this.UnitNr].AILabel = num18;
                this.game.Data.ActionCardObj[this.UnitNr].AILabel2 = 0;
                this.game.Data.ActionCardObj[this.UnitNr].aILabel3 = 0;
                int num19 = (int) Math.Round(Conversion.Val(Interaction.InputBox("set hardcoded ai label 2 nr (0-99999)", "Shadow Empire : Planetary Conquest")));
                if (num19 > -1 & num19 <= 99999)
                {
                  this.game.Data.ActionCardObj[this.UnitNr].AILabel2 = num19;
                  int num20 = (int) Math.Round(Conversion.Val(Interaction.InputBox("set hardcoded ai label 3 nr (0-99999)", "Shadow Empire : Planetary Conquest")));
                  if (num20 > -1 & num20 <= 99999)
                    this.game.Data.ActionCardObj[this.UnitNr].aILabel3 = num20;
                }
              }
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BNameId)
            {
              this.game.Data.ActionCardObj[this.UnitNr].Title = Interaction.InputBox("Give new name, please.", "Give Name", this.game.Data.ActionCardObj[this.UnitNr].Title);
              this.MakeUnitListGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BRemoveUnitId && this.UnitNr > -1)
            {
              this.game.Data.RemoveActionCard(this.UnitNr);
              --this.UnitNr;
              this.MakeUnitListGUI();
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
  }
}
