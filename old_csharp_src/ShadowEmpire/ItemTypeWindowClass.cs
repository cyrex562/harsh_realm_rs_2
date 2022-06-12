// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ItemTypeWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class ItemTypeWindowClass : WindowClass
  {
    private int ItemTypeListId;
    private ListClass ItemTypeListObj;
    private int BAddItemTypeId;
    private int BAddItemTypeTextId;
    private int BNameId;
    private int BNameTextId;
    private int B1Id;
    private int B1TextId;
    private int B2Id;
    private int B2TextId;
    private int B3Id;
    private int B3TextId;
    private int[] Bgameslotid;
    private int[] Bgameslottextid;
    private int[] Bregimeslotid;
    private int[] Bregimeslottextid;
    private int[] Bregimeslotcostid;
    private int[] Bregimeslotcosttextid;
    private int[] Bitemid;
    private int[] bitemtextid;
    private int[] BresId;
    private int[] BResTextId;
    private int BRemoveItemTypeId;
    private int BRemoveItemTypeTextId;
    private int BRemoveItemType2Id;
    private int BRemoveItemTypeText2Id;
    private int BCloneItemTypeId;
    private int BCloneItemTypeTextId;
    private int B4Id;
    private int B4TextId;
    private int B5Id;
    private int B5TextId;
    private int B6Id;
    private int B6TextId;
    private int B7Id;
    private int B7TextId;
    private int B8Id;
    private int B8TextId;
    private int B9Id;
    private int B9TextId;
    private int B10Id;
    private int B10TextId;
    private int B11Id;
    private int B11TextId;
    private int B12Id;
    private int B12TextId;
    private int B13Id;
    private int B13TextId;
    private int B14Id;
    private int B14TextId;
    private int B15Id;
    private int B15TextId;
    private int B16Id;
    private int B16TextId;
    private int B17Id;
    private int B17TextId;
    private int B18Id;
    private int B18TextId;
    private int B19Id;
    private int B19TextId;
    private int B20Id;
    private int B20TextId;
    private int PGListId;
    private ListClass PGListObj;
    private int B3bId;
    private int B3bTextId;
    private int ItemTypeNr;
    private int detailnr;
    private string ss;

    public ItemTypeWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Item Types")
    {
      this.Bgameslotid = new int[5];
      this.Bgameslottextid = new int[5];
      this.Bregimeslotid = new int[5];
      this.Bregimeslottextid = new int[5];
      this.Bregimeslotcostid = new int[5];
      this.Bregimeslotcosttextid = new int[5];
      this.Bitemid = new int[5];
      this.bitemtextid = new int[5];
      this.BresId = new int[5];
      this.BResTextId = new int[5];
      this.ItemTypeNr = -1;
      this.detailnr = -1;
      this.MakeItemTypeListGUI(-1);
    }

    public override void DoRefresh() => this.MakeItemTypeTypeItemGUI();

    private void MakeItemTypeListGUI(int tItemTypenr)
    {
      if (this.ItemTypeListId > 0)
        this.RemoveSubPart(this.ItemTypeListId);
      SubPartClass tsubpart;
      if (this.game.Data.ItemTypeCounter > -1)
      {
        this.ItemTypeListObj = new ListClass();
        int itemTypeCounter = this.game.Data.ItemTypeCounter;
        for (int index = 0; index <= itemTypeCounter; ++index)
          this.ItemTypeListObj.add(Strings.Trim(Conversion.Str((object) index)) + ") " + this.game.Data.ItemTypeObj[index].Name, index);
        ListClass itemTypeListObj = this.ItemTypeListObj;
        int tlistselect = tItemTypenr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        tsubpart = (SubPartClass) new ListSubPartClass(itemTypeListObj, 9, 200, tlistselect, game, tHeader: "Item Types", tbackbitmap: (ref local1), bbx: 10, bby: 50, overruleFont: (ref local2));
        this.ItemTypeListId = this.AddSubPart(ref tsubpart, 10, 50, 200, 192, 0);
        this.ItemTypeNr = tItemTypenr;
        this.MakeItemTypeTypeItemGUI();
      }
      else
      {
        this.ItemTypeNr = tItemTypenr;
        this.MakeItemTypeTypeItemGUI();
      }
      if (this.BAddItemTypeId > 0)
        this.RemoveSubPart(this.BAddItemTypeId);
      if (this.BAddItemTypeTextId > 0)
        this.RemoveSubPart(this.BAddItemTypeTextId);
      this.ss = "Click to add an itemtype to the list";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.BAddItemTypeId = this.AddSubPart(ref tsubpart, 10, 270, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new TextPartClass("Add a ItemType", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.BAddItemTypeTextId = this.AddSubPart(ref tsubpart, 50, 269, 300, 20, 0);
      }
      if (this.B13Id > 0)
        this.RemoveSubPart(this.B13Id);
      if (this.B13TextId > 0)
        this.RemoveSubPart(this.B13TextId);
      this.ss = "Click to set all itemtypes to be non produce-able by all peoplegroups.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
        this.B13Id = this.AddSubPart(ref tsubpart, 10, 250, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("Set All to false", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B13TextId = this.AddSubPart(ref tsubpart, 50, 249, 400, 20, 0);
    }

    private void MakeItemTypeTypeItemGUI()
    {
      if (this.BNameId > 0)
        this.RemoveSubPart(this.BNameId);
      if (this.BNameTextId > 0)
        this.RemoveSubPart(this.BNameTextId);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
      if (this.B3bId > 0)
        this.RemoveSubPart(this.B3bId);
      if (this.B3bTextId > 0)
        this.RemoveSubPart(this.B3bTextId);
      if (this.PGListId > 0)
        this.RemoveSubPart(this.PGListId);
      if (this.B4Id > 0)
        this.RemoveSubPart(this.B4Id);
      if (this.B4TextId > 0)
        this.RemoveSubPart(this.B4TextId);
      if (this.B5Id > 0)
        this.RemoveSubPart(this.B5Id);
      if (this.B5TextId > 0)
        this.RemoveSubPart(this.B5TextId);
      if (this.B6Id > 0)
        this.RemoveSubPart(this.B6Id);
      if (this.B6TextId > 0)
        this.RemoveSubPart(this.B6TextId);
      if (this.B7Id > 0)
        this.RemoveSubPart(this.B7Id);
      if (this.B7TextId > 0)
        this.RemoveSubPart(this.B7TextId);
      if (this.B8Id > 0)
        this.RemoveSubPart(this.B8Id);
      if (this.B8TextId > 0)
        this.RemoveSubPart(this.B8TextId);
      if (this.B9Id > 0)
        this.RemoveSubPart(this.B9Id);
      if (this.B9TextId > 0)
        this.RemoveSubPart(this.B9TextId);
      if (this.B10Id > 0)
        this.RemoveSubPart(this.B10Id);
      if (this.B10TextId > 0)
        this.RemoveSubPart(this.B10TextId);
      if (this.B11Id > 0)
        this.RemoveSubPart(this.B11Id);
      if (this.B11TextId > 0)
        this.RemoveSubPart(this.B11TextId);
      if (this.B12Id > 0)
        this.RemoveSubPart(this.B12Id);
      if (this.B12TextId > 0)
        this.RemoveSubPart(this.B12TextId);
      if (this.B14Id > 0)
        this.RemoveSubPart(this.B14Id);
      if (this.B14TextId > 0)
        this.RemoveSubPart(this.B14TextId);
      if (this.B15Id > 0)
        this.RemoveSubPart(this.B15Id);
      if (this.B15TextId > 0)
        this.RemoveSubPart(this.B15TextId);
      if (this.B16Id > 0)
        this.RemoveSubPart(this.B16Id);
      if (this.B16TextId > 0)
        this.RemoveSubPart(this.B16TextId);
      if (this.B17Id > 0)
        this.RemoveSubPart(this.B17Id);
      if (this.B17TextId > 0)
        this.RemoveSubPart(this.B17TextId);
      if (this.B18Id > 0)
        this.RemoveSubPart(this.B18Id);
      if (this.B18TextId > 0)
        this.RemoveSubPart(this.B18TextId);
      if (this.B19Id > 0)
        this.RemoveSubPart(this.B19Id);
      if (this.B19TextId > 0)
        this.RemoveSubPart(this.B19TextId);
      if (this.B20Id > 0)
        this.RemoveSubPart(this.B20Id);
      if (this.B20TextId > 0)
        this.RemoveSubPart(this.B20TextId);
      int index1 = 0;
      do
      {
        if (this.Bgameslotid[index1] > 0)
          this.RemoveSubPart(this.Bgameslotid[index1]);
        if (this.Bgameslottextid[index1] > 0)
          this.RemoveSubPart(this.Bgameslottextid[index1]);
        if (this.Bregimeslotid[index1] > 0)
          this.RemoveSubPart(this.Bregimeslotid[index1]);
        if (this.Bregimeslottextid[index1] > 0)
          this.RemoveSubPart(this.Bregimeslottextid[index1]);
        if (this.Bregimeslotcostid[index1] > 0)
          this.RemoveSubPart(this.Bregimeslotcostid[index1]);
        if (this.Bregimeslotcosttextid[index1] > 0)
          this.RemoveSubPart(this.Bregimeslotcosttextid[index1]);
        if (this.Bitemid[index1] > 0)
          this.RemoveSubPart(this.Bitemid[index1]);
        if (this.bitemtextid[index1] > 0)
          this.RemoveSubPart(this.bitemtextid[index1]);
        if (this.BresId[index1] > 0)
          this.RemoveSubPart(this.BresId[index1]);
        if (this.BResTextId[index1] > 0)
          this.RemoveSubPart(this.BResTextId[index1]);
        ++index1;
      }
      while (index1 <= 4);
      if (this.BRemoveItemTypeId > 0)
        this.RemoveSubPart(this.BRemoveItemTypeId);
      if (this.BRemoveItemTypeTextId > 0)
        this.RemoveSubPart(this.BRemoveItemTypeTextId);
      if (this.BCloneItemTypeId > 0)
        this.RemoveSubPart(this.BCloneItemTypeId);
      if (this.BCloneItemTypeTextId > 0)
        this.RemoveSubPart(this.BCloneItemTypeTextId);
      if (this.BRemoveItemType2Id > 0)
        this.RemoveSubPart(this.BRemoveItemType2Id);
      if (this.BRemoveItemTypeText2Id > 0)
        this.RemoveSubPart(this.BRemoveItemTypeText2Id);
      if (this.ItemTypeNr <= -1)
        return;
      this.ss = "Click to change the name of this itemtype";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BNameId = this.AddSubPart(ref tsubpart, 370, 50, 32, 16, 1);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Name: " + this.game.Data.ItemTypeObj[this.ItemTypeNr].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.BNameTextId = this.AddSubPart(ref tsubpart1, 410, 49, 400, 20, 0);
      this.ss = "Click to toggle on/off if this is a supply point";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B1Id = this.AddSubPart(ref tsubpart2, 10, 610, 32, 16, 1);
      }
      SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("IsSupply: " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].IsSupply), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B1TextId = this.AddSubPart(ref tsubpart3, 50, 609, 200, 20, 0);
      this.ss = "Click to set the itemtypegroup this itemtype belongs to";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B2Id = this.AddSubPart(ref tsubpart3, 370, 70, 32, 16, 1);
      }
      tsubpart3 = (SubPartClass) new TextPartClass("ItemType Group #: " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].ItemGroup), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B2TextId = this.AddSubPart(ref tsubpart3, 410, 69, 400, 20, 0);
      int index2 = 0;
      do
      {
        this.ss = "Click to set a minimum value that a certain gameslot has to have in order to be able to produce this itemtype. -1=none needed";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          int[] bgameslotid = this.Bgameslotid;
          int index3 = index2;
          tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          int num = this.AddSubPart(ref tsubpart3, 370, 90 + index2 * 20, 32, 16, 1);
          bgameslotid[index3] = num;
        }
        string txt1;
        if (this.game.Data.ItemTypeObj[this.ItemTypeNr].GameSlotsNeeded[index2] > -1)
          txt1 = "GameSlot: " + this.game.Data.GameSlotName[this.game.Data.ItemTypeObj[this.ItemTypeNr].GameSlotsNeeded[index2]] + "(" + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].GameSlotsNeeded[index2]) + ") = " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].GameSlotsNeededQty[index2]);
        else
          txt1 = "No GameSlot Needed";
        int[] bgameslottextid = this.Bgameslottextid;
        int index4 = index2;
        tsubpart3 = (SubPartClass) new TextPartClass(txt1, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        int num1 = this.AddSubPart(ref tsubpart3, 410, 90 + index2 * 20 - 1, 400, 20, 0);
        bgameslottextid[index4] = num1;
        this.ss = "Click to set a minimum value that a certain regimeslot has to have in order to be able to produce this itemtype. -1=none needed";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          int[] bregimeslotid = this.Bregimeslotid;
          int index5 = index2;
          tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          int num2 = this.AddSubPart(ref tsubpart3, 370, 190 + index2 * 20, 32, 16, 1);
          bregimeslotid[index5] = num2;
        }
        string txt2;
        if (this.game.Data.ItemTypeObj[this.ItemTypeNr].RegimeSlotsNeeded[index2] > -1)
          txt2 = "RegimeSlot: " + this.game.Data.RegimeSlotName[this.game.Data.ItemTypeObj[this.ItemTypeNr].RegimeSlotsNeeded[index2]] + "(" + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].RegimeSlotsNeeded[index2]) + ") = " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].RegimeSlotsNeededQty[index2]);
        else
          txt2 = "No RegimeSlot Needed";
        int[] bregimeslottextid = this.Bregimeslottextid;
        int index6 = index2;
        tsubpart3 = (SubPartClass) new TextPartClass(txt2, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        int num3 = this.AddSubPart(ref tsubpart3, 410, 190 + index2 * 20 - 1, 400, 20, 0);
        bregimeslottextid[index6] = num3;
        this.ss = "Click to set a howmuch points from regime variable X this itemtype needs to USE in order to produce it. -1=none needed";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          int[] bregimeslotcostid = this.Bregimeslotcostid;
          int index7 = index2;
          tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          int num4 = this.AddSubPart(ref tsubpart3, 410, 300 + index2 * 20, 32, 16, 1);
          bregimeslotcostid[index7] = num4;
        }
        string txt3;
        if (this.game.Data.ItemTypeObj[this.ItemTypeNr].RegimeSlotsCost[index2] > -1)
          txt3 = "RegimeSlotCost: " + this.game.Data.RegimeSlotName[this.game.Data.ItemTypeObj[this.ItemTypeNr].RegimeSlotsCost[index2]] + "(" + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].RegimeSlotsCost[index2]) + ") = " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].RegimeSlotsCostQty[index2]);
        else
          txt3 = "No RegimeSlotCost Needed";
        int[] bregimeslotcosttextid = this.Bregimeslotcosttextid;
        int index8 = index2;
        tsubpart3 = (SubPartClass) new TextPartClass(txt3, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        int num5 = this.AddSubPart(ref tsubpart3, 450, 300 + index2 * 20 - 1, 400, 20, 0);
        bregimeslotcosttextid[index8] = num5;
        this.ss = "Click to set a researchfield that is neccessary to produce this itemtype";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          int[] bresId = this.BresId;
          int index9 = index2;
          tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          int num6 = this.AddSubPart(ref tsubpart3, 370, 450 + index2 * 20, 32, 16, 1);
          bresId[index9] = num6;
        }
        string txt4;
        if (this.game.Data.ItemTypeObj[this.ItemTypeNr].ResFieldNeeded[index2] > -1)
          txt4 = "ResField: " + this.game.Data.ResearchObj[this.game.Data.ItemTypeObj[this.ItemTypeNr].ResFieldNeeded[index2]].Name + "(" + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].ResFieldNeeded[index2]) + ") ";
        else
          txt4 = "No Research needed";
        int[] bresTextId = this.BResTextId;
        int index10 = index2;
        tsubpart3 = (SubPartClass) new TextPartClass(txt4, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        int num7 = this.AddSubPart(ref tsubpart3, 410, 450 + index2 * 20 - 1, 400, 20, 0);
        bresTextId[index10] = num7;
        ++index2;
      }
      while (index2 <= 4);
      this.ss = "Click to set the production cost of this itemtype in prodpoints";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B5Id = this.AddSubPart(ref tsubpart3, 370, 430, 32, 16, 1);
      }
      tsubpart3 = (SubPartClass) new TextPartClass("Production Cost: " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].ProdWeight), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B5TextId = this.AddSubPart(ref tsubpart3, 410, 429, 400, 20, 0);
      this.ss = "Click to toggle on/off if this itemtype is a Political Point";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B8Id = this.AddSubPart(ref tsubpart3, 370, 550, 32, 16, 1);
      }
      tsubpart3 = (SubPartClass) new TextPartClass("IsPolPt: " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].IsResPt), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B8TextId = this.AddSubPart(ref tsubpart3, 410, 549, 400, 20, 0);
      this.ss = "Click to set a possible production multiplier. Or the ammount of this polpt/supply/sftype that is produced when 1 instance of this itemtype is produced.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B9Id = this.AddSubPart(ref tsubpart3, 370, 570, 32, 16, 1);
      }
      tsubpart3 = (SubPartClass) new TextPartClass("ProdMultiplier: " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].Multiplier), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B9TextId = this.AddSubPart(ref tsubpart3, 410, 569, 400, 20, 0);
      this.ss = "Click to set the SFType that is created when this itemtype is produced. -1=no sftype";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B10Id = this.AddSubPart(ref tsubpart3, 370, 590, 32, 16, 1);
      }
      if (this.game.Data.ItemTypeObj[this.ItemTypeNr].IsSFType == -1)
      {
        tsubpart3 = (SubPartClass) new TextPartClass("IsSFType#: -1", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B10TextId = this.AddSubPart(ref tsubpart3, 410, 589, 400, 20, 0);
      }
      else if (this.game.Data.ItemTypeObj[this.ItemTypeNr].IsSFType <= this.game.Data.SFTypeCounter)
      {
        tsubpart3 = (SubPartClass) new TextPartClass("IsSFType#: " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].IsSFType) + "," + this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[this.ItemTypeNr].IsSFType].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B10TextId = this.AddSubPart(ref tsubpart3, 410, 589, 400, 20, 0);
      }
      this.ss = "Click to set which itemtype should be blocked from the production list if it is possible to produce this itemtype";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B11Id = this.AddSubPart(ref tsubpart3, 370, 610, 32, 16, 1);
      }
      if (this.game.Data.ItemTypeObj[this.ItemTypeNr].Blocks > -1)
      {
        tsubpart3 = (SubPartClass) new TextPartClass("Blocks: " + this.game.Data.ItemTypeObj[this.game.Data.ItemTypeObj[this.ItemTypeNr].Blocks].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B11TextId = this.AddSubPart(ref tsubpart3, 410, 609, 400, 20, 0);
      }
      else
      {
        tsubpart3 = (SubPartClass) new TextPartClass("Blocks: -1", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B11TextId = this.AddSubPart(ref tsubpart3, 410, 609, 400, 20, 0);
      }
      this.ss = "Click to set if producing this itemtype adds 1 point (*multiplier) to a certain regimeslot";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B12Id = this.AddSubPart(ref tsubpart3, 370, 630, 32, 16, 1);
      }
      tsubpart3 = (SubPartClass) new TextPartClass("IsRegimeSlot: " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].IsRegimeSlot), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B12TextId = this.AddSubPart(ref tsubpart3, 410, 629, 400, 20, 0);
      this.ss = "Click to set if graphics of itemtype should be overruled by specific SFType (dummies can be made)";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B14Id = this.AddSubPart(ref tsubpart3, 370, 650, 32, 16, 1);
      }
      tsubpart3 = (SubPartClass) new TextPartClass("UseSFTypeGraphic: " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].UseSFType), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B14TextId = this.AddSubPart(ref tsubpart3, 410, 649, 400, 20, 0);
      this.ss = "extra XP points +/-";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B15Id = this.AddSubPart(ref tsubpart3, 810, 110, 32, 16, 1);
      }
      tsubpart3 = (SubPartClass) new TextPartClass("XpMod: " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].XpMod), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B15TextId = this.AddSubPart(ref tsubpart3, 850, 109, 400, 20, 0);
      this.ss = "extra morale points +/-";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B16Id = this.AddSubPart(ref tsubpart3, 810, 130, 32, 16, 1);
      }
      tsubpart3 = (SubPartClass) new TextPartClass("MorMod: " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].MorMod), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B16TextId = this.AddSubPart(ref tsubpart3, 850, 129, 400, 20, 0);
      this.ss = "-1=no mod";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B17Id = this.AddSubPart(ref tsubpart3, 810, 150, 32, 16, 1);
      }
      tsubpart3 = (SubPartClass) new TextPartClass("PeopleMod: " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].PeopleMod), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B17TextId = this.AddSubPart(ref tsubpart3, 850, 149, 400, 20, 0);
      this.ss = "-1=no mod";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B18Id = this.AddSubPart(ref tsubpart3, 810, 170, 32, 16, 1);
      }
      tsubpart3 = (SubPartClass) new TextPartClass("MoveTypeMod: " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].MoveTypeMod), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B18TextId = this.AddSubPart(ref tsubpart3, 850, 169, 400, 20, 0);
      this.ss = "Set Regime Specific setting. -1=all. >-1 = a specific regime only. -2= none";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B19Id = this.AddSubPart(ref tsubpart3, 810, 190, 32, 16, 1);
      }
      tsubpart3 = (SubPartClass) new TextPartClass("RegimeSpecific: " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].RegimeSpecific), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B19TextId = this.AddSubPart(ref tsubpart3, 850, 189, 400, 20, 0);
      this.ss = "Set Prod Mod to use (1,2,3,4) (old 0=seen as 1)";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B20Id = this.AddSubPart(ref tsubpart3, 810, 210, 32, 16, 1);
      }
      tsubpart3 = (SubPartClass) new TextPartClass("UseProdMod: " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].UseProdMod), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B20TextId = this.AddSubPart(ref tsubpart3, 850, 209, 400, 20, 0);
      this.ss = "Click to remove this itemtype";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.BRemoveItemTypeId = this.AddSubPart(ref tsubpart3, 10, 290, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new TextPartClass("Remove this ItemType", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BRemoveItemTypeTextId = this.AddSubPart(ref tsubpart3, 50, 289, 200, 20, 0);
      }
      this.ss = "Copy this itemtype (put at end of list)";
      if (this.ItemTypeNr > -1)
      {
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
          this.BCloneItemTypeId = this.AddSubPart(ref tsubpart3, 10, 310, 32, 16, 1);
        }
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 = (SubPartClass) new TextPartClass("Copy this ItemType", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.BCloneItemTypeTextId = this.AddSubPart(ref tsubpart3, 50, 309, 200, 20, 0);
        }
      }
      this.ss = "Click to remove ALL itemtypes";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.BRemoveItemType2Id = this.AddSubPart(ref tsubpart3, 10, 330, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new TextPartClass("Remove ALL", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BRemoveItemTypeText2Id = this.AddSubPart(ref tsubpart3, 50, 329, 200, 20, 0);
      }
      this.PGListObj = new ListClass();
      if (this.detailnr < -1 | this.detailnr > 99)
        this.detailnr = -1;
      int index11 = 0;
      do
      {
        this.PGListObj.add(Conversion.Str((object) index11) + ") " + this.game.Data.TempString[index11 + 200] + " = " + Conversion.Str((object) this.game.Data.ItemTypeObj[this.ItemTypeNr].PeopleGroup[index11]), index11);
        ++index11;
      }
      while (index11 <= 99);
      ListClass pgListObj = this.PGListObj;
      int detailnr = this.detailnr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      tsubpart3 = (SubPartClass) new ListSubPartClass(pgListObj, 6, 200, detailnr, game, tHeader: "Who must own?", tbackbitmap: (ref local1), bbx: 10, bby: 350, overruleFont: (ref local2));
      this.PGListId = this.AddSubPart(ref tsubpart3, 10, 350, 200, 144, 0);
      this.maketabsheet3b();
    }

    private void maketabsheet3b()
    {
      if (this.detailnr <= -1)
        return;
      this.ss = "Click to toggle on/off if this peoplegroup has to own the production location in order to build this itemtype";
      if (this.B3bId > 0)
        this.RemoveSubPart(this.B3bId);
      if (this.B3bTextId > 0)
        this.RemoveSubPart(this.B3bTextId);
      if (Strings.Len(this.game.Data.MasterFile) == 0 | !this.game.Data.MasterfileReadPeople)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B3bId = this.AddSubPart(ref tsubpart, 215, 350, 32, 16, 1);
      }
      if (!(Strings.Len(this.game.Data.MasterFile) == 0 | !this.game.Data.MasterfileReadPeople))
        return;
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Change", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 100, 20, false, tDescript: this.ss);
      this.B3bTextId = this.AddSubPart(ref tsubpart1, 250, 349, 200, 20, 0);
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
label_106:
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num1 = this.SubPartID[index1];
            if (num1 == this.ItemTypeListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.ItemTypeNr = num2;
                this.MakeItemTypeTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddItemTypeId)
            {
              this.game.Data.AddItemType();
              this.MakeItemTypeListGUI(this.ItemTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BNameId)
            {
              this.game.Data.ItemTypeObj[this.ItemTypeNr].Name = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest");
              this.MakeItemTypeListGUI(this.ItemTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B1Id)
            {
              this.game.Data.ItemTypeObj[this.ItemTypeNr].IsSupply = !this.game.Data.ItemTypeObj[this.ItemTypeNr].IsSupply;
              this.MakeItemTypeListGUI(this.ItemTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B2Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 17, this.ItemTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B5Id)
            {
              int num3 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new prodweight, please.", "Shadow Empire : Planetary Conquest")));
              if (num3 < 0 | num3 > 99999)
              {
                int num4 = (int) Interaction.MsgBox((object) "Between 0 and 99999 please. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.ItemTypeObj[this.ItemTypeNr].ProdWeight = num3;
              this.MakeItemTypeTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B13Id)
            {
              int itemTypeCounter = this.game.Data.ItemTypeCounter;
              for (int index2 = 0; index2 <= itemTypeCounter; ++index2)
              {
                int index3 = 0;
                do
                {
                  this.game.Data.ItemTypeObj[index2].PeopleGroup[index3] = false;
                  ++index3;
                }
                while (index3 <= 99);
              }
              this.MakeItemTypeTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B8Id)
            {
              this.game.Data.ItemTypeObj[this.ItemTypeNr].IsResPt = !this.game.Data.ItemTypeObj[this.ItemTypeNr].IsResPt;
              this.MakeItemTypeTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B9Id)
            {
              int num5 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new multiplier, please.", "Shadow Empire : Planetary Conquest")));
              if (num5 < 1 | num5 > 99999)
              {
                int num6 = (int) Interaction.MsgBox((object) "Between 1 and 99999 please. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.ItemTypeObj[this.ItemTypeNr].Multiplier = num5;
              this.MakeItemTypeTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B10Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 19, this.ItemTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B14Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 34, this.ItemTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B11Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 20, this.ItemTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B12Id)
            {
              int num7 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give which regime slot is raised +1 please.", "Shadow Empire : Planetary Conquest")));
              if (num7 < -1 | num7 > 499)
              {
                int num8 = (int) Interaction.MsgBox((object) "Between -1 and 499 please. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.ItemTypeObj[this.ItemTypeNr].IsRegimeSlot = num7;
              this.MakeItemTypeTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BRemoveItemTypeId)
            {
              this.game.Data.RemoveItemType(this.ItemTypeNr);
              if (this.ItemTypeNr > this.game.Data.ItemTypeCounter)
                --this.ItemTypeNr;
              this.MakeItemTypeListGUI(this.ItemTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BCloneItemTypeId)
            {
              this.game.Data.AddItemType();
              this.game.Data.ItemTypeObj[this.game.Data.ItemTypeCounter] = this.game.Data.ItemTypeObj[this.ItemTypeNr].Clone();
              this.ItemTypeNr = this.game.Data.ItemTypeCounter;
              this.MakeItemTypeListGUI(this.ItemTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B15Id)
            {
              int num9 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give XP Modifier", "Shadow Empire : Planetary Conquest")));
              if (num9 < -999 | num9 > 999)
              {
                int num10 = (int) Interaction.MsgBox((object) "Between -999 and 999 please. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.ItemTypeObj[this.ItemTypeNr].XpMod = num9;
              this.MakeItemTypeTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B19Id)
            {
              int num11 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Regime Specific (-2=none,-1=all,>-1=reg)", "Shadow Empire : Planetary Conquest")));
              if (num11 <= this.game.Data.RegimeCounter | num11 >= -2)
              {
                this.game.Data.ItemTypeObj[this.ItemTypeNr].RegimeSpecific = num11;
              }
              else
              {
                int num12 = (int) Interaction.MsgBox((object) "Between -2 and regimecount please. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.MakeItemTypeTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B20Id)
            {
              int num13 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Use Prod Mod (1-4). 0=seen as 1", "Shadow Empire : Planetary Conquest")));
              if (num13 <= 4 | num13 >= 1)
              {
                this.game.Data.ItemTypeObj[this.ItemTypeNr].UseProdMod = num13;
              }
              else
              {
                int num14 = (int) Interaction.MsgBox((object) "Between 1 and 4 please. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.MakeItemTypeTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B16Id)
            {
              int num15 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Mor Modifier", "Shadow Empire : Planetary Conquest")));
              if (num15 < -999 | num15 > 999)
              {
                int num16 = (int) Interaction.MsgBox((object) "Between -999 and 999 please. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.ItemTypeObj[this.ItemTypeNr].MorMod = num15;
              this.MakeItemTypeTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B17Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 49, this.ItemTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B18Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 50, this.ItemTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BRemoveItemType2Id)
            {
              for (int itemTypeCounter = this.game.Data.ItemTypeCounter; itemTypeCounter >= 0; itemTypeCounter += -1)
                this.game.Data.RemoveItemType(itemTypeCounter);
              this.ItemTypeNr = -1;
              this.MakeItemTypeListGUI(-1);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.PGListId)
            {
              int num17 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num17 > -1)
              {
                this.detailnr = num17;
                this.MakeItemTypeTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B3bId)
            {
              this.game.Data.ItemTypeObj[this.ItemTypeNr].PeopleGroup[this.detailnr] = !this.game.Data.ItemTypeObj[this.ItemTypeNr].PeopleGroup[this.detailnr];
              this.MakeItemTypeTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            int tnr2 = 0;
            while (this.SubPartID[index1] != this.Bgameslotid[tnr2])
            {
              if (this.SubPartID[index1] == this.Bregimeslotid[tnr2])
              {
                int num18 = (int) Math.Round(Conversion.Val(Interaction.InputBox("TYPE: Give new regimeslot# needed", "Shadow Empire : Planetary Conquest")));
                int num19 = (int) Math.Round(Conversion.Val(Interaction.InputBox("QTY: Give new value needed for this slot", "Shadow Empire : Planetary Conquest")));
                if (num18 < -1 | num18 > 499)
                {
                  int num20 = (int) Interaction.MsgBox((object) "Regime Slot # Between -1 and 499 please..", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                {
                  this.game.Data.ItemTypeObj[this.ItemTypeNr].RegimeSlotsNeeded[tnr2] = num18;
                  this.game.Data.ItemTypeObj[this.ItemTypeNr].RegimeSlotsNeededQty[tnr2] = num19;
                }
                this.MakeItemTypeTypeItemGUI();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.SubPartID[index1] == this.Bregimeslotcostid[tnr2])
              {
                int num21 = (int) Math.Round(Conversion.Val(Interaction.InputBox("TYPE: Give new regimeslot# needed", "Shadow Empire : Planetary Conquest")));
                int num22 = (int) Math.Round(Conversion.Val(Interaction.InputBox("QTY: Give new ammount of points needed from this regimeslot in order to produce", "Shadow Empire : Planetary Conquest")));
                if (num21 < -1 | num21 > 499 & num22 > 0)
                {
                  int num23 = (int) Interaction.MsgBox((object) "Regime Slot # Between -1 and 499 please.. and qty>0", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                {
                  this.game.Data.ItemTypeObj[this.ItemTypeNr].RegimeSlotsCost[tnr2] = num21;
                  this.game.Data.ItemTypeObj[this.ItemTypeNr].RegimeSlotsCostQty[tnr2] = num22;
                }
                this.MakeItemTypeTypeItemGUI();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.SubPartID[index1] == this.BresId[tnr2])
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 18, this.ItemTypeNr, tnr2);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              ++tnr2;
              if (tnr2 > 4)
                goto label_106;
            }
            int num24 = (int) Math.Round(Conversion.Val(Interaction.InputBox("TYPE: Give new gameslot# needed", "Shadow Empire : Planetary Conquest")));
            int num25 = (int) Math.Round(Conversion.Val(Interaction.InputBox("QTY: Give new value needed for this slot", "Shadow Empire : Planetary Conquest")));
            if (num24 < -1 | num24 > 499)
            {
              int num26 = (int) Interaction.MsgBox((object) "Game slot # Between -1 and 499 please..", Title: ((object) "Shadow Empire : Planetary Conquest"));
            }
            else
            {
              this.game.Data.ItemTypeObj[this.ItemTypeNr].GameSlotsNeeded[tnr2] = num24;
              this.game.Data.ItemTypeObj[this.ItemTypeNr].GameSlotsNeededQty[tnr2] = num25;
            }
            this.MakeItemTypeTypeItemGUI();
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
