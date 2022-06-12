// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.EditUnitWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class EditUnitWindowClass : WindowClass
  {
    private int LibListId;
    private int LibNr;
    private ListClass LibListObj;
    private int UnitListId;
    private ListClass UnitListObj;
    private int BAddUnitId;
    private int BAddUnitTextId;
    private int UnitList2Id;
    private ListClass UnitList2Obj;
    private int BAddUnit2Id;
    private int BAddUnit2TextId;
    private int BNameId;
    private int BNameTextId;
    private int BRemoveUnitId;
    private int BRemoveUnitTextId;
    private int SFListId;
    private ListClass SFListObj;
    private int BAddSFId;
    private int BaddSFTextId;
    private int BRemoveSFId;
    private int BRemoveSFTextid;
    private int BHQId;
    private int BHQTextId;
    private int a3id;
    private int a3bid;
    private int a4id;
    private int a4bid;
    private int a5id;
    private int a5bid;
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
    private int BTypeId;
    private int BTypeTextId;
    private int SFTypeListId;
    private ListClass SFTypeListObj;
    private int BQtyID;
    private int BQtyTextId;
    private int BRdnId;
    private int BRdnTextId;
    private int BXpId;
    private int BXpTextId;
    private int BPeopleId;
    private int BPeopleTextId;
    private int BSupplyId;
    private int BSupplyTextId;
    private int BMorId;
    private int BMorTextId;
    private int bmovid;
    private int bmovtextid;
    private int BEntrId;
    private int BEntrTextId;
    private int UnitNr;
    private int SFNr;
    private int SFTypeNr;
    private string ss;

    public EditUnitWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Units in Hex and Units Predefined ")
    {
      this.UnitNr = -1;
      this.LibNr = -1;
      this.SFNr = -1;
      this.SFTypeNr = -1;
      this.MakeUnitListGUI(-1);
    }

    public override void DoRefresh() => this.MakeUnitTypeItemGUI();

    private void MakeUnitListGUI(int tUnitnr)
    {
      if (this.UnitListId > 0)
        this.RemoveSubPart(this.UnitListId);
      if (this.LibListId > 0)
        this.RemoveSubPart(this.LibListId);
      this.UnitNr = tUnitnr;
      int num1 = -1;
      Font font;
      if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > -1)
      {
        this.UnitListObj = new ListClass();
        int unitCounter = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter;
        for (int index = 0; index <= unitCounter; ++index)
        {
          int unit = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitList[index];
          if (unit == tUnitnr)
            num1 = index;
          this.UnitListObj.add("-" + this.game.Data.UnitObj[unit].Name + "(#" + unit.ToString() + ")", unit);
        }
        ListClass unitListObj = this.UnitListObj;
        int tlistselect = num1;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(unitListObj, 3, 300, tlistselect, game, tHeader: "Units in Hex", tbackbitmap: (ref local1), bbx: 10, bby: 55, overruleFont: (ref local2));
        this.UnitListId = this.AddSubPart(ref tsubpart, 10, 55, 300, 96, 0);
        if (num1 > -1)
          this.MakeUnitTypeItemGUI();
      }
      else if (num1 > -1)
        this.MakeUnitTypeItemGUI();
      this.LibListObj = new ListClass();
      this.LibListObj.add("All", -2);
      int num2 = -1;
      int num3 = 0;
      int libraryCounter = this.game.Data.LibraryCounter;
      for (int index = 0; index <= libraryCounter; ++index)
      {
        ++num3;
        if (this.LibNr == index)
          num2 = num3;
        this.LibListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.LibraryObj[index].name, index);
      }
      if (this.LibNr == -1)
        num2 = 0;
      ListClass libListObj = this.LibListObj;
      int tlistselect1 = num2;
      GameClass game1 = this.game;
      ref Bitmap local3 = ref this.OwnBitmap;
      font = (Font) null;
      ref Font local4 = ref font;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(libListObj, 5, 200, tlistselect1, game1, tHeader: "Libraries", tbackbitmap: (ref local3), bbx: 10, bby: 180, overruleFont: (ref local4));
      this.LibListId = this.AddSubPart(ref tsubpart1, 10, 180, 300, 128, 0);
      if (this.UnitList2Id > 0)
        this.RemoveSubPart(this.UnitList2Id);
      this.UnitNr = tUnitnr;
      int num4 = -1;
      this.UnitList2Obj = new ListClass();
      int num5 = -1;
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter1; ++index1)
      {
        if (this.game.Data.UnitObj[index1].LibId.libSlot == this.LibNr | this.LibNr == -1)
        {
          int index2 = index1;
          if (this.game.Data.UnitObj[index2].PreDef > -1)
          {
            ++num5;
            if (index2 == tUnitnr)
              num4 = num5;
            this.UnitList2Obj.add("#" + Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[index2].PreDef)) + ") " + this.game.Data.UnitObj[index2].Name + " (" + Conversion.Str((object) index2) + ")", index2);
          }
        }
      }
      ListClass unitList2Obj = this.UnitList2Obj;
      int tlistselect2 = num4;
      GameClass game2 = this.game;
      ref Bitmap local5 = ref this.OwnBitmap;
      font = (Font) null;
      ref Font local6 = ref font;
      SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(unitList2Obj, 5, 300, tlistselect2, game2, tHeader: "Predefined Units", tbackbitmap: (ref local5), bbx: 10, bby: 324, overruleFont: (ref local6));
      this.UnitList2Id = this.AddSubPart(ref tsubpart2, 10, 324, 300, 128, 0);
      this.MakeUnitTypeItemGUI();
      if (this.BAddUnitId > 0)
        this.RemoveSubPart(this.BAddUnitId);
      if (this.BAddUnitTextId > 0)
        this.RemoveSubPart(this.BAddUnitTextId);
      if (this.BAddUnit2Id > 0)
        this.RemoveSubPart(this.BAddUnit2Id);
      if (this.BAddUnit2TextId > 0)
        this.RemoveSubPart(this.BAddUnit2TextId);
      this.ss = "Click to add a unit in this hex";
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.BAddUnitId = this.AddSubPart(ref tsubpart3, 10, 480, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Add Unit in Hex", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BAddUnitTextId = this.AddSubPart(ref tsubpart4, 50, 479, 300, 20, 0);
      this.ss = "Click to add a predefined unit. These can be used by events.";
      SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.BAddUnit2Id = this.AddSubPart(ref tsubpart5, 10, 500, 32, 16, 1);
      SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("Add PreDef Unit", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BAddUnit2TextId = this.AddSubPart(ref tsubpart6, 50, 499, 300, 20, 0);
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
      if (this.SFListId > 0)
        this.RemoveSubPart(this.SFListId);
      if (this.BAddSFId > 0)
        this.RemoveSubPart(this.BAddSFId);
      if (this.BaddSFTextId > 0)
        this.RemoveSubPart(this.BaddSFTextId);
      if (this.BRemoveSFId > 0)
        this.RemoveSubPart(this.BRemoveSFId);
      if (this.BRemoveSFTextid > 0)
        this.RemoveSubPart(this.BRemoveSFTextid);
      if (this.BHQId > 0)
        this.RemoveSubPart(this.BHQId);
      if (this.BHQTextId > 0)
        this.RemoveSubPart(this.BHQTextId);
      if (this.BSupplyId > 0)
        this.RemoveSubPart(this.BSupplyId);
      if (this.BSupplyTextId > 0)
        this.RemoveSubPart(this.BSupplyTextId);
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
      this.ss = "Click to import predef units from another file";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.a8id = this.AddSubPart(ref tsubpart1, 10, 540, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Import PreDef Units", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.a8bid = this.AddSubPart(ref tsubpart2, 50, 539, 300, 20, 0);
      this.ss = "Click to delete all units (you can make exception for predef units)";
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
      this.a10id = this.AddSubPart(ref tsubpart3, 10, 560, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Delete all units", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.a10bid = this.AddSubPart(ref tsubpart4, 50, 559, 300, 20, 0);
      if (this.UnitNr > -1)
      {
        this.ss = "Click to change the name of the unit";
        SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BNameId = this.AddSubPart(ref tsubpart5, 370, 50, 32, 16, 1);
        SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("Name: " + this.game.Data.UnitObj[this.UnitNr].Name + " (#" + Strings.Trim(Conversion.Str((object) this.UnitNr)) + ")", new Font("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 250, 20, false, tDescript: this.ss);
        this.BNameTextId = this.AddSubPart(ref tsubpart6, 410, 49, 200, 20, 0);
        this.ss = "Click to toggle if it is a unit or a HQ";
        tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BHQId = this.AddSubPart(ref tsubpart6, 370, 70, 32, 16, 1);
        tsubpart6 = (SubPartClass) new TextPartClass("HQ: " + Conversion.Str((object) this.game.Data.UnitObj[this.UnitNr].IsHQ), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BHQTextId = this.AddSubPart(ref tsubpart6, 410, 69, 200, 20, 0);
        this.ss = "Click to change the coloration it is a HQ";
        tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a3id = this.AddSubPart(ref tsubpart6, 650, 50, 32, 16, 1);
        tsubpart6 = (SubPartClass) new TextPartClass("Change Coloration of Unit" + this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a3bid = this.AddSubPart(ref tsubpart6, 700, 49, 300, 20, 0);
        this.ss = "Click to make this unit identical to a unit id# to be specified";
        tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
        this.a4id = this.AddSubPart(ref tsubpart6, 650, 70, 32, 16, 1);
        tsubpart6 = (SubPartClass) new TextPartClass("Make Copy of other #", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a4bid = this.AddSubPart(ref tsubpart6, 700, 69, 300, 20, 0);
        if (this.game.Data.UnitObj[this.UnitNr].PreDef > -1)
        {
          this.ss = "Click to assign to a library";
          tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
          this.a11id = this.AddSubPart(ref tsubpart6, 650, 90, 32, 16, 1);
          tsubpart6 = (SubPartClass) new TextPartClass("Assign to Library", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.a11bid = this.AddSubPart(ref tsubpart6, 700, 89, 300, 20, 0);
        }
        this.ss = "Click to set owner of unit";
        tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a9id = this.AddSubPart(ref tsubpart6, 650, 130, 32, 16, 1);
        tsubpart6 = (SubPartClass) new TextPartClass("Owner = " + Conversion.Str((object) this.game.Data.UnitObj[this.UnitNr].Regime), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a9bid = this.AddSubPart(ref tsubpart6, 700, 129, 300, 20, 0);
        if (this.game.Data.UnitObj[this.UnitNr].PreDef == -1)
        {
          string str1;
          if (this.game.Data.UnitObj[this.UnitNr].Historical == -1)
          {
            str1 = "none";
          }
          else
          {
            int historical = this.game.Data.UnitObj[this.UnitNr].Historical;
            string str2;
            if (this.game.Data.HistoricalUnitObj[historical].Type == 1)
              str2 = "(Ind)";
            if (this.game.Data.HistoricalUnitObj[historical].Type == 2)
              str2 = "(Div)";
            if (this.game.Data.HistoricalUnitObj[historical].Type == 5)
              str2 = "(Corps)";
            if (this.game.Data.HistoricalUnitObj[historical].Type == 6)
              str2 = "(Army)";
            if (this.game.Data.HistoricalUnitObj[historical].Type == 7)
              str2 = "(ArmGrp)";
            if (this.game.Data.HistoricalUnitObj[historical].Type == 8)
              str2 = "(HighCom)";
            str1 = this.game.Data.HistoricalUnitObj[historical].Name + " " + str2;
            this.ss = "Click to set historical subpart";
            tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
            this.a7id = this.AddSubPart(ref tsubpart6, 650, 110, 32, 16, 1);
            tsubpart6 = (SubPartClass) new TextPartClass("Subpart = " + Conversion.Str((object) this.game.Data.UnitObj[this.UnitNr].HistoricalSubPart), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
            this.a7bid = this.AddSubPart(ref tsubpart6, 700, 109, 300, 20, 0);
          }
          if (this.game.Data.UnitObj[this.UnitNr].Historical > -1)
            this.ss = "Set as historical unit (HisNr#" + this.game.Data.UnitObj[this.UnitNr].Historical.ToString() + " ID#" + this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.UnitNr].Historical].ID.ToString() + ")";
          else
            this.ss = "Set as historical unit (" + this.game.Data.UnitObj[this.UnitNr].Historical.ToString() + ")";
          tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.a6id = this.AddSubPart(ref tsubpart6, 650, 90, 32, 16, 1);
          tsubpart6 = (SubPartClass) new TextPartClass(this.ss, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.a6bid = this.AddSubPart(ref tsubpart6, 700, 89, 300, 20, 0);
        }
        if (this.game.Data.UnitObj[this.UnitNr].PreDef > -1)
        {
          this.ss = "Click to place a copy of this predef type on the map";
          tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONDRAW, tDescript: this.ss);
          this.a5id = this.AddSubPart(ref tsubpart6, 10, 520, 32, 16, 1);
          tsubpart6 = (SubPartClass) new TextPartClass("Place this predef on map", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.a5bid = this.AddSubPart(ref tsubpart6, 50, 519, 300, 20, 0);
        }
        this.ss = "Click to set the initial ammount of supply points. In settings you can do a mass action though...";
        tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BSupplyId = this.AddSubPart(ref tsubpart6, 370, 90, 32, 16, 1);
        tsubpart6 = (SubPartClass) new TextPartClass("Supply Pts: " + Conversion.Str((object) this.game.Data.UnitObj[this.UnitNr].Supply), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BSupplyTextId = this.AddSubPart(ref tsubpart6, 410, 89, 200, 20, 0);
        this.ss = "Click to remove this unit.";
        tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.BRemoveUnitId = this.AddSubPart(ref tsubpart6, 710, 330, 32, 16, 1);
        tsubpart6 = (SubPartClass) new TextPartClass("Remove this Unit", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BRemoveUnitTextId = this.AddSubPart(ref tsubpart6, 750, 329, 200, 20, 0);
        if (this.game.Data.UnitObj[this.UnitNr].SFCount > -1)
        {
          this.SFListObj = new ListClass();
          int num = -1;
          int sfCount = this.game.Data.UnitObj[this.UnitNr].SFCount;
          for (int index = 0; index <= sfCount; ++index)
          {
            int sf = this.game.Data.UnitObj[this.UnitNr].SFList[index];
            if (this.SFNr == sf)
              num = index;
            int type = this.game.Data.SFObj[sf].Type;
            this.SFListObj.add(type <= -1 ? "Empty SubFormation" : Conversion.Str((object) this.game.Data.SFObj[sf].Qty) + "x " + this.game.Data.SFTypeObj[type].Name, sf);
          }
          if (num == -1)
            this.SFNr = -1;
          ListClass sfListObj = this.SFListObj;
          int tlistselect = num;
          GameClass game = this.game;
          ref Bitmap local1 = ref this.OwnBitmap;
          Font font = (Font) null;
          ref Font local2 = ref font;
          tsubpart6 = (SubPartClass) new ListSubPartClass(sfListObj, 5, 250, tlistselect, game, tHeader: "Subformations in Unit", tbackbitmap: (ref local1), bbx: 370, bby: 120, overruleFont: (ref local2));
          this.SFListId = this.AddSubPart(ref tsubpart6, 370, 120, 250, 128, 0);
        }
        else
          this.SFNr = -1;
        this.ss = "Click to add a subformation to this unit";
        tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.BAddSFId = this.AddSubPart(ref tsubpart6, 370, 280, 32, 16, 1);
        tsubpart6 = (SubPartClass) new TextPartClass("Add SubFormation", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.BaddSFTextId = this.AddSubPart(ref tsubpart6, 410, 279, 300, 20, 0);
        if (this.SFNr > -1)
        {
          this.ss = "Click to remove selected subformation from this unit";
          tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
          this.BRemoveSFId = this.AddSubPart(ref tsubpart6, 370, 300, 32, 16, 1);
          tsubpart6 = (SubPartClass) new TextPartClass("Remove SubFormation", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.BRemoveSFTextid = this.AddSubPart(ref tsubpart6, 410, 299, 300, 20, 0);
        }
      }
      this.SpecialSFSheet();
    }

    public void SpecialSFSheet()
    {
      if (this.BTypeId > 0)
        this.RemoveSubPart(this.BTypeId);
      if (this.BTypeTextId > 0)
        this.RemoveSubPart(this.BTypeTextId);
      if (this.SFTypeListId > 0)
        this.RemoveSubPart(this.SFTypeListId);
      if (this.BQtyID > 0)
        this.RemoveSubPart(this.BQtyID);
      if (this.BQtyTextId > 0)
        this.RemoveSubPart(this.BQtyTextId);
      if (this.BRdnId > 0)
        this.RemoveSubPart(this.BRdnId);
      if (this.BRdnTextId > 0)
        this.RemoveSubPart(this.BRdnTextId);
      if (this.BXpId > 0)
        this.RemoveSubPart(this.BXpId);
      if (this.BXpTextId > 0)
        this.RemoveSubPart(this.BXpTextId);
      if (this.BMorId > 0)
        this.RemoveSubPart(this.BMorId);
      if (this.BMorTextId > 0)
        this.RemoveSubPart(this.BMorTextId);
      if (this.BPeopleId > 0)
        this.RemoveSubPart(this.BPeopleId);
      if (this.BPeopleTextId > 0)
        this.RemoveSubPart(this.BPeopleTextId);
      if (this.BEntrId > 0)
        this.RemoveSubPart(this.BEntrId);
      if (this.BEntrTextId > 0)
        this.RemoveSubPart(this.BEntrTextId);
      if (this.bmovid > 0)
        this.RemoveSubPart(this.bmovid);
      if (this.bmovtextid > 0)
        this.RemoveSubPart(this.bmovtextid);
      if (this.SFNr <= -1)
        return;
      int type = this.game.Data.SFObj[this.SFNr].Type;
      string str1 = type <= -1 ? "Empty" : this.game.Data.SFTypeObj[type].Name;
      this.ss = "Click to select the subformationtype of this subformation";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.BTypeId = this.AddSubPart(ref tsubpart1, 710, 360, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("SFType: " + str1, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BTypeTextId = this.AddSubPart(ref tsubpart2, 750, 359, 300, 20, 0);
      this.ss = "Click to set the qty of this subformationtype in this subformation";
      string str2 = Conversion.Str((object) this.game.Data.SFObj[this.SFNr].Qty);
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.BQtyID = this.AddSubPart(ref tsubpart3, 710, 385, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Qty: " + str2, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BQtyTextId = this.AddSubPart(ref tsubpart4, 750, 384, 300, 20, 0);
      this.ss = "Click to set the Readiness level of these troops";
      tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.BRdnId = this.AddSubPart(ref tsubpart4, 710, 405, 32, 16, 1);
      tsubpart4 = (SubPartClass) new TextPartClass("Rdn: " + Conversion.Str((object) this.game.Data.SFObj[this.SFNr].Rdn), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BRdnTextId = this.AddSubPart(ref tsubpart4, 750, 404, 300, 20, 0);
      this.ss = "Click to set the experience level of these troops";
      tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.BXpId = this.AddSubPart(ref tsubpart4, 710, 430, 32, 16, 1);
      tsubpart4 = (SubPartClass) new TextPartClass("Xp: " + Conversion.Str((object) this.game.Data.SFObj[this.SFNr].Xp), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BXpTextId = this.AddSubPart(ref tsubpart4, 750, 429, 300, 20, 0);
      this.ss = "Click to set the people these troops belong too";
      tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.BPeopleId = this.AddSubPart(ref tsubpart4, 410, 360, 32, 16, 1);
      tsubpart4 = (SubPartClass) new TextPartClass("People: " + this.game.Data.PeopleObj[this.game.Data.SFObj[this.SFNr].People].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BPeopleTextId = this.AddSubPart(ref tsubpart4, 450, 359, 300, 20, 0);
      this.ss = "Click to set the morale of this subformation";
      tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.BMorId = this.AddSubPart(ref tsubpart4, 410, 385, 32, 16, 1);
      tsubpart4 = (SubPartClass) new TextPartClass("Morale: " + Conversion.Str((object) this.game.Data.SFObj[this.SFNr].Mor), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BMorTextId = this.AddSubPart(ref tsubpart4, 450, 384, 300, 20, 0);
      this.ss = "Click to set the entrenchment of this subformation.. In settings there is a mass option that sets to auto-entrench";
      tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.BEntrId = this.AddSubPart(ref tsubpart4, 410, 405, 32, 16, 1);
      tsubpart4 = (SubPartClass) new TextPartClass("Entrench: " + Conversion.Str((object) this.game.Data.SFObj[this.SFNr].CurrentEntrench), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BEntrTextId = this.AddSubPart(ref tsubpart4, 450, 404, 300, 20, 0);
      this.ss = "Click to set the movementtype overrule. -1= keep standard movement. >-1 is overrule with specific type";
      tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.bmovid = this.AddSubPart(ref tsubpart4, 410, 430, 32, 16, 1);
      if (this.game.Data.SFObj[this.SFNr].MoveType == -1)
      {
        tsubpart4 = (SubPartClass) new TextPartClass("MoveType: DEFAULT", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.bmovtextid = this.AddSubPart(ref tsubpart4, 450, 429, 300, 20, 0);
      }
      else
      {
        tsubpart4 = (SubPartClass) new TextPartClass("MoveType: " + this.game.Data.TempString[0 + this.game.Data.SFObj[this.SFNr].MoveType], new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.bmovtextid = this.AddSubPart(ref tsubpart4, 450, 429, 300, 20, 0);
      }
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
            if (num1 == this.LibListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.LibNr = num2;
                this.UnitNr = -1;
                this.MakeUnitListGUI(this.UnitNr);
              }
              else if (num2 == -2)
              {
                this.LibNr = -1;
                this.UnitNr = -1;
                this.MakeUnitListGUI(this.UnitNr);
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
              int integer;
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1)
              {
                this.game.ProcessingObj.NewUnit(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, false, this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime);
              }
              else
              {
                integer = Conversions.ToInteger(Interaction.InputBox("Give Regime Nr"));
                if (integer >= -1 & integer <= this.game.Data.RegimeCounter)
                  this.game.ProcessingObj.NewUnit(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, false, integer);
              }
              this.UnitNr = this.game.Data.UnitCounter;
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1)
                this.game.Data.UnitObj[this.UnitNr].Regime = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime;
              else
                this.game.Data.UnitObj[this.UnitNr].Regime = integer;
              this.MakeUnitListGUI(this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.UnitList2Id)
            {
              int num4 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num4 > -1)
              {
                this.UnitNr = num4;
                this.MakeUnitTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.bmovid)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 44, this.SFNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddUnit2Id)
            {
              this.UnitNr = this.game.Data.AddUnit(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1)
              {
                this.game.Data.UnitObj[this.UnitNr].Regime = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime;
              }
              else
              {
                int integer = Conversions.ToInteger(Interaction.InputBox("Give Regime Nr"));
                if (integer > -1 & integer <= this.game.Data.RegimeCounter)
                  this.game.Data.UnitObj[this.UnitNr].Regime = integer;
              }
              this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].RemoveUnitFromList(this.UnitNr);
              this.game.Data.UnitObj[this.UnitNr].PreDef = this.game.HandyFunctionsObj.GetNextPreDefNr();
              this.game.Data.UnitObj[this.UnitNr].X = -1;
              this.game.Data.UnitObj[this.UnitNr].Y = -1;
              this.MakeUnitListGUI(this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a3id)
            {
              ColorDialog colorDialog = new ColorDialog();
              colorDialog.Color = Color.FromArgb((int) byte.MaxValue, this.game.Data.UnitObj[this.UnitNr].Red, this.game.Data.UnitObj[this.UnitNr].Green, this.game.Data.UnitObj[this.UnitNr].Blue);
              if (colorDialog.ShowDialog() == DialogResult.OK)
              {
                UnitClass unitClass1 = this.game.Data.UnitObj[this.UnitNr];
                Color color = colorDialog.Color;
                int r = (int) color.R;
                unitClass1.Red = r;
                UnitClass unitClass2 = this.game.Data.UnitObj[this.UnitNr];
                color = colorDialog.Color;
                int g = (int) color.G;
                unitClass2.Green = g;
                UnitClass unitClass3 = this.game.Data.UnitObj[this.UnitNr];
                color = colorDialog.Color;
                int b1 = (int) color.B;
                unitClass3.Blue = b1;
              }
              this.MakeUnitListGUI(this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a8id)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("All files (*.*)|*.*", "Pick a PT file please...", this.game.AppPath, true);
              if (File.Exists(this.game.AppPath + filename))
              {
                if (Interaction.MsgBox((object) "Also overwrite historical units?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                  this.game.HandyFunctionsObj.ImportPreDefUnitsOnly(filename, true);
                else
                  this.game.HandyFunctionsObj.ImportPreDefUnitsOnly(filename);
                BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                this.game.Data.LoadGraphics((Form1) null);
                int num5 = (int) Interaction.MsgBox((object) "Predef units (if any available) have been imported!", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                int num6 = (int) Interaction.MsgBox((object) "Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.MakeUnitListGUI(this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a4id)
            {
              string str = Conversions.ToString(Conversion.Val(Interaction.InputBox("Give unit number# to copy from", "Shadow Empire : Planetary Conquest")));
              if (Operators.CompareString(str, "", false) != 0)
              {
                int funr = (int) Math.Round(Conversion.Val(str));
                if (funr > -1 & funr <= this.game.Data.UnitCounter)
                {
                  this.game.HandyFunctionsObj.CopyUnit(this.UnitNr, funr, false);
                }
                else
                {
                  int num7 = (int) Interaction.MsgBox((object) "Unit # does not exist. Sorry.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
              }
              this.MakeUnitListGUI(this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a5id)
            {
              int integer;
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1)
              {
                this.game.ProcessingObj.NewUnit(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, false, this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime);
              }
              else
              {
                integer = Conversions.ToInteger(Interaction.InputBox("Give Regime Nr"));
                if (integer > -1 & integer <= this.game.Data.RegimeCounter)
                  this.game.ProcessingObj.NewUnit(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, false, integer);
              }
              int unitNr = this.UnitNr;
              this.UnitNr = this.game.Data.UnitCounter;
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1)
                this.game.Data.UnitObj[this.UnitNr].Regime = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime;
              else
                this.game.Data.UnitObj[this.UnitNr].Regime = integer;
              this.game.HandyFunctionsObj.CopyUnit(this.UnitNr, unitNr);
              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.UnitObj[this.UnitNr].X, this.game.Data.UnitObj[this.UnitNr].Y].Regime, (int) Math.Round((double) this.game.Data.RuleVar[99]), 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[this.UnitNr].X, this.game.Data.UnitObj[this.UnitNr].Y, 0, false, muststartonairfield: false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true);
              SimpleList simpleList = new SimpleList();
              int unitCounter = this.game.Data.UnitCounter;
              for (int tid = 0; tid <= unitCounter; ++tid)
              {
                if (this.game.Data.UnitObj[tid].X > -1 && this.game.Data.UnitObj[tid].Regime == this.game.Data.UnitObj[this.UnitNr].Regime && this.game.Data.UnitObj[tid].IsHQ & tid != this.UnitNr && this.game.EditObj.TempValue[this.game.Data.UnitObj[tid].Map].Value[this.game.Data.UnitObj[tid].X, this.game.Data.UnitObj[tid].Y] < 9999)
                  simpleList.Add(tid, this.game.EditObj.TempValue[this.game.Data.UnitObj[tid].Map].Value[this.game.Data.UnitObj[tid].X, this.game.Data.UnitObj[tid].Y]);
              }
              if (simpleList.Counter > -1)
              {
                simpleList.Sort();
                int num8 = simpleList.Id[0];
                if (num8 > -1)
                  this.game.Data.UnitObj[this.UnitNr].HQ = num8;
              }
              this.UnitNr = unitNr;
              this.MakeUnitListGUI(this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BNameId)
            {
              string str = Interaction.InputBox("Give new name, please.", "Give Name");
              this.game.Data.UnitObj[this.UnitNr].Name = str;
              if (this.game.Data.UnitObj[this.UnitNr].Historical > -1 && Interaction.MsgBox((object) "Set all of same historical unit to same name?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
              {
                int unitCounter = this.game.Data.UnitCounter;
                for (int index2 = 0; index2 <= unitCounter; ++index2)
                {
                  if (this.game.Data.UnitObj[index2].Historical == this.game.Data.UnitObj[this.UnitNr].Historical)
                    this.game.Data.UnitObj[index2].Name = str;
                }
              }
              this.MakeUnitListGUI(this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a10id)
            {
              bool flag = false;
              if (Interaction.MsgBox((object) "Also delete predef units?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                flag = true;
              int num9 = (int) Interaction.MsgBox((object) "Ok hold on!! this can take some while", Title: ((object) "Shadow Empire : Planetary Conquest"));
              this.game.FormRef.Cursor = Cursors.WaitCursor;
              for (int unitCounter = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
              {
                if (this.game.Data.UnitObj[unitCounter].PreDef == -1 | flag)
                {
                  DataClass data = this.game.Data;
                  int nr = unitCounter;
                  GameClass gameClass = (GameClass) null;
                  ref GameClass local = ref gameClass;
                  data.RemoveUnit(nr, ref local);
                }
              }
              this.UnitNr = -1;
              this.game.FormRef.Cursor = Cursors.Default;
              int num10 = (int) Interaction.MsgBox((object) "Done!", Title: ((object) "Shadow Empire : Planetary Conquest"));
              this.MakeUnitListGUI(this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BSupplyId)
            {
              int num11 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new supply pts ammount, please.", "Shadow Empire : Planetary Conquest")));
              if (num11 > -1)
              {
                this.game.Data.UnitObj[this.UnitNr].Supply = num11;
              }
              else
              {
                int num12 = (int) Interaction.MsgBox((object) "Must be positive number.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.MakeUnitListGUI(this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a11id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 95, this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BRemoveUnitId)
            {
              if (this.game.Data.UnitObj[this.UnitNr].PassengerCounter > -1)
              {
                int num13 = (int) Interaction.MsgBox((object) "No can do. Unit has passengers. remove them first.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                return windowReturnClass;
              }
              this.game.EditObj.UnitSelected = -1;
              if (this.game.Data.UnitObj[this.UnitNr].SFCount > -1)
              {
                for (int sfCount = this.game.Data.UnitObj[this.UnitNr].SFCount; sfCount >= 0; sfCount += -1)
                  this.game.Data.RemoveSF(this.game.Data.UnitObj[this.UnitNr].SFList[sfCount]);
              }
              this.game.EditObj.UnitSelected = -1;
              this.game.Data.RemoveUnit(this.UnitNr, ref this.game);
              this.UnitNr = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter <= -1 ? -1 : this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0];
              this.SFNr = -1;
              this.MakeUnitListGUI(this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.SFListId)
            {
              int num14 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num14 > -1)
              {
                this.SFNr = num14;
                this.MakeUnitTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddSFId)
            {
              this.SFNr = this.game.Data.AddSF(this.UnitNr);
              this.game.Data.SFObj[this.SFNr].Type = 0;
              this.game.Data.SFObj[this.SFNr].Rdn = 100;
              this.game.Data.SFObj[this.SFNr].Xp = 0;
              if (this.game.Data.UnitObj[this.UnitNr].Regime > -1)
              {
                this.game.Data.SFObj[this.SFNr].People = this.game.Data.RegimeObj[this.game.Data.UnitObj[this.UnitNr].Regime].People;
                this.game.Data.SFObj[this.SFNr].Mor = this.game.Data.PeopleObj[this.game.Data.SFObj[this.SFNr].People].BaseMorale[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.UnitObj[this.UnitNr].Regime].People].PeopleGroup];
              }
              else
              {
                this.game.Data.SFObj[this.SFNr].People = 0;
                this.game.Data.SFObj[this.SFNr].Mor = this.game.Data.PeopleObj[this.game.Data.SFObj[this.SFNr].People].BaseMorale[0];
              }
              this.MakeUnitTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BRemoveSFId)
            {
              this.game.Data.RemoveSF(this.SFNr);
              this.SFNr = -1;
              this.MakeUnitTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.SFTypeListId)
            {
              int num15 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num15 > -1)
              {
                this.SFTypeNr = num15;
                this.SpecialSFSheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BQtyID)
            {
              int num16 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Qty for this Subformation:", "Shadow Empire : Planetary Conquest")));
              if (num16 < 1 | num16 > 9999)
              {
                int num17 = (int) Interaction.MsgBox((object) "Cancelled. You should have entered a value between 1 and 9999.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                this.game.Data.SFObj[this.SFNr].Qty = num16;
                this.MakeUnitTypeItemGUI();
                windowReturnClass.SetFlag(true);
              }
              return windowReturnClass;
            }
            if (num1 == this.BRdnId)
            {
              int num18 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Rdn for this Subformation:", "Shadow Empire : Planetary Conquest")));
              if (num18 < 10 | num18 > 100)
              {
                int num19 = (int) Interaction.MsgBox((object) "Cancelled. You should have entered a value between 10 and 100.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                this.game.Data.SFObj[this.SFNr].Rdn = num18;
                this.MakeUnitTypeItemGUI();
                windowReturnClass.SetFlag(true);
              }
              return windowReturnClass;
            }
            if (num1 == this.BXpId)
            {
              int num20 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Xp for this Subformation:", "Shadow Empire : Planetary Conquest")));
              if (num20 < 0 | num20 > 300)
              {
                int num21 = (int) Interaction.MsgBox((object) "Cancelled. You should have entered a value between 10 and 300.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                this.game.Data.SFObj[this.SFNr].Xp = num20;
                this.MakeUnitTypeItemGUI();
                windowReturnClass.SetFlag(true);
              }
              return windowReturnClass;
            }
            if (num1 == this.BMorId)
            {
              int num22 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Morale for this Subformation:", "Shadow Empire : Planetary Conquest")));
              if (num22 < 1 | num22 > 100)
              {
                int num23 = (int) Interaction.MsgBox((object) "Cancelled. You should have entered a value between 1 and 100.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                this.game.Data.SFObj[this.SFNr].Mor = num22;
                this.MakeUnitTypeItemGUI();
                windowReturnClass.SetFlag(true);
              }
              return windowReturnClass;
            }
            if (num1 == this.a9id)
            {
              int num24 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Regime #", "Shadow Empire : Planetary Conquest")));
              if (num24 < -1 | num24 > this.game.Data.RegimeCounter)
              {
                int num25 = (int) Interaction.MsgBox((object) "Cancelled. Not a valid regime.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                this.game.Data.UnitObj[this.UnitNr].Regime = num24;
                this.MakeUnitListGUI(this.UnitNr);
                windowReturnClass.SetFlag(true);
              }
              return windowReturnClass;
            }
            if (num1 == this.BEntrId)
            {
              int num26 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Entrench for this Subformation:", "Shadow Empire : Planetary Conquest")));
              if (num26 < 0 | num26 > 999)
              {
                int num27 = (int) Interaction.MsgBox((object) "Cancelled. You should have entered a value between 1 and 999.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                this.game.Data.SFObj[this.SFNr].CurrentEntrench = num26;
                this.MakeUnitTypeItemGUI();
                windowReturnClass.SetFlag(true);
              }
              return windowReturnClass;
            }
            if (num1 == this.a6id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 37, this.UnitNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a7id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 48, this.UnitNr, this.game.Data.UnitObj[this.UnitNr].Historical);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BPeopleId)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 7, this.SFNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BTypeId)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 6, this.SFNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BHQId)
            {
              this.game.Data.UnitObj[this.UnitNr].IsHQ = !this.game.Data.UnitObj[this.UnitNr].IsHQ;
              this.MakeUnitListGUI(this.UnitNr);
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
