// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.RiverTypeWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.IO;

namespace WindowsApplication1
{
  public class RiverTypeWindowClass : WindowClass
  {
    private int riverListId;
    private ListClass riverListObj;
    private int BAddriverId;
    private int BAddriverTextId;
    private int BNameId;
    private int BNameTextId;
    private int BCostModId;
    private int BCostModTextid;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int BRemoveriverId;
    private int BRemoveriverTextId;
    private int BDrawId;
    private int b1Id;
    private int BDrawTextId;
    private int txt1;
    private int txt2;
    private int b1TextId;
    public int b3id;
    public int b3textid;
    public int b4id;
    public int b4textid;
    public int b5id;
    public int b5textid;
    public int b6id;
    public int b6textid;
    private ListClass BasicListObj;
    private int BasicListId;
    private int BBasicSpriteId;
    private int BChangeBasicSpriteId;
    private ListClass BasicList2Obj;
    private int BasicList2Id;
    private int ChangeMvId;
    private ListClass BasicList3Obj;
    private int BasicList3Id;
    private int ChangePenaltyId;
    private int riverNr;
    private int TabSheetNr;
    private int DetailNr;
    private string ss;

    public override void DoRefresh() => this.MakeriverTypeItemGUI();

    public RiverTypeWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "River Types")
    {
      this.riverNr = -1;
      this.TabSheetNr = -1;
      this.DetailNr = -1;
      this.MakeriverListGUI(-1);
    }

    private void MakeriverListGUI(int trivernr)
    {
      if (this.riverListId > 0)
        this.RemoveSubPart(this.riverListId);
      SubPartClass tsubpart;
      if (this.game.Data.RiverTypeCounter > -1)
      {
        this.riverListObj = new ListClass();
        int riverTypeCounter = this.game.Data.RiverTypeCounter;
        for (int index = 0; index <= riverTypeCounter; ++index)
          this.riverListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.RiverTypeObj[index].Name, index);
        ListClass riverListObj = this.riverListObj;
        int tlistselect = trivernr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        tsubpart = (SubPartClass) new ListSubPartClass(riverListObj, 9, 200, tlistselect, game, tHeader: "River Types", tbackbitmap: (ref local1), bbx: 10, bby: 50, overruleFont: (ref local2));
        this.riverListId = this.AddSubPart(ref tsubpart, 10, 50, 200, 192, 0);
        this.riverNr = trivernr;
        this.MakeriverTypeItemGUI();
      }
      else
      {
        this.riverNr = trivernr;
        this.MakeriverTypeItemGUI();
      }
      if (this.BAddriverId > 0)
        this.RemoveSubPart(this.BAddriverId);
      if (this.BAddriverTextId > 0)
        this.RemoveSubPart(this.BAddriverTextId);
      this.ss = "Click to add a river type";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.BAddriverId = this.AddSubPart(ref tsubpart, 10, 270, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      tsubpart = (SubPartClass) new TextPartClass("Add river Type", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BAddriverTextId = this.AddSubPart(ref tsubpart, 50, 269, 300, 20, 0);
    }

    private void MakeriverTypeItemGUI()
    {
      if (this.BNameId > 0)
        this.RemoveSubPart(this.BNameId);
      if (this.BNameTextId > 0)
        this.RemoveSubPart(this.BNameTextId);
      if (this.BCostModId > 0)
        this.RemoveSubPart(this.BCostModId);
      if (this.BCostModTextid > 0)
        this.RemoveSubPart(this.BCostModTextid);
      if (this.BRemoveriverId > 0)
        this.RemoveSubPart(this.BRemoveriverId);
      if (this.BRemoveriverTextId > 0)
        this.RemoveSubPart(this.BRemoveriverTextId);
      if (this.BDrawId > 0)
        this.RemoveSubPart(this.BDrawId);
      if (this.BDrawTextId > 0)
        this.RemoveSubPart(this.BDrawTextId);
      if (this.OptionsListId > 0)
        this.RemoveSubPart(this.OptionsListId);
      if (this.b3id > 0)
        this.RemoveSubPart(this.b3id);
      if (this.b3textid > 0)
        this.RemoveSubPart(this.b3textid);
      if (this.b4id > 0)
        this.RemoveSubPart(this.b4id);
      if (this.b4textid > 0)
        this.RemoveSubPart(this.b4textid);
      if (this.b5id > 0)
        this.RemoveSubPart(this.b5id);
      if (this.b5textid > 0)
        this.RemoveSubPart(this.b5textid);
      if (this.b6id > 0)
        this.RemoveSubPart(this.b6id);
      if (this.b6textid > 0)
        this.RemoveSubPart(this.b6textid);
      if (this.BasicList2Id > 0)
        this.RemoveSubPart(this.BasicList2Id);
      if (this.ChangeMvId > 0)
        this.RemoveSubPart(this.ChangeMvId);
      if (this.BasicList3Id > 0)
        this.RemoveSubPart(this.BasicList3Id);
      if (this.ChangePenaltyId > 0)
        this.RemoveSubPart(this.ChangePenaltyId);
      if (this.riverNr > -1)
      {
        this.ss = "Click to change name of this rivertype";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.BNameId = this.AddSubPart(ref tsubpart, 370, 50, 32, 16, 1);
        }
        SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Name: " + this.game.Data.RiverTypeObj[this.riverNr].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.BNameTextId = this.AddSubPart(ref tsubpart1, 410, 49, 400, 20, 0);
        this.ss = "Click to change the modifier for the EP cost to build a bridge over this rivertype and the modifier for the structural points. dc3: set to -1 to never place bridge over this river type";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.BCostModId = this.AddSubPart(ref tsubpart2, 370, 70, 32, 16, 1);
        }
        SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("BridgeCostMod: " + Conversion.Str((object) this.game.Data.RiverTypeObj[this.riverNr].BridgeCostModifier), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.BCostModTextid = this.AddSubPart(ref tsubpart3, 410, 69, 400, 20, 0);
        this.ss = "Click to change transparent setting (works best in combination with overlay map)";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.b3id = this.AddSubPart(ref tsubpart3, 370, 90, 32, 16, 1);
        }
        tsubpart3 = (SubPartClass) new TextPartClass("Transparent: " + Conversion.Str((object) this.game.Data.RiverTypeObj[this.riverNr].Transparent), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.b3textid = this.AddSubPart(ref tsubpart3, 410, 89, 400, 20, 0);
        this.ss = "Click to change the thickness for mini/strat. map";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.b6id = this.AddSubPart(ref tsubpart3, 370, 110, 32, 16, 1);
        }
        tsubpart3 = (SubPartClass) new TextPartClass("Thickness: " + Conversion.Str((object) this.game.Data.RiverTypeObj[this.riverNr].Thickness), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.b6textid = this.AddSubPart(ref tsubpart3, 410, 109, 400, 20, 0);
        this.ss = "Click to set to Snake Mode drawing style";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.b4id = this.AddSubPart(ref tsubpart3, 770, 90, 32, 16, 1);
        }
        tsubpart3 = (SubPartClass) new TextPartClass("SnakeMode: " + Conversion.Str((object) this.game.Data.RiverTypeObj[this.riverNr].snakeMode), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.b4textid = this.AddSubPart(ref tsubpart3, 810, 89, 400, 20, 0);
        this.ss = "Click to set draw mode in editor.";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.b5id = this.AddSubPart(ref tsubpart3, 770, 70, 32, 16, 1);
        }
        tsubpart3 = (SubPartClass) new TextPartClass("drawInteriorOnly: " + Conversion.Str((object) this.game.Data.RiverTypeObj[this.riverNr].drawInteriorOnly), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.b5textid = this.AddSubPart(ref tsubpart3, 810, 69, 400, 20, 0);
        this.ss = "Click to remove this rivertype";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
          this.BRemoveriverId = this.AddSubPart(ref tsubpart3, 10, 290, 32, 16, 1);
        }
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 = (SubPartClass) new TextPartClass("Remove this RiverType", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.BRemoveriverTextId = this.AddSubPart(ref tsubpart3, 50, 289, 200, 20, 0);
        }
        this.ss = "Click to use this rivertype to draw on the map.";
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONDRAW, tDescript: this.ss);
        this.BDrawId = this.AddSubPart(ref tsubpart3, 10, 310, 32, 16, 1);
        tsubpart3 = (SubPartClass) new TextPartClass("Select as pencil", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BDrawTextId = this.AddSubPart(ref tsubpart3, 50, 309, 200, 20, 0);
        this.OptionsListObj = new ListClass();
        this.OptionsListObj.add("Sprites", 0);
        this.OptionsListObj.add("Move-over River Penalties", 1);
        this.OptionsListObj.add("Attack-over River Penalties", 2);
        ListClass optionsListObj = this.OptionsListObj;
        int tabSheetNr = this.TabSheetNr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        tsubpart3 = (SubPartClass) new ListSubPartClass(optionsListObj, 3, 300, tabSheetNr, game, tHeader: "Property Sheets", tbackbitmap: (ref local1), bbx: 370, bby: 140, overruleFont: (ref local2));
        this.OptionsListId = this.AddSubPart(ref tsubpart3, 370, 140, 300, 96, 0);
      }
      this.maketabsheet();
    }

    private void maketabsheet()
    {
      if (this.BasicListId > 0)
        this.RemoveSubPart(this.BasicListId);
      if (this.BBasicSpriteId > 0)
        this.RemoveSubPart(this.BBasicSpriteId);
      if (this.BChangeBasicSpriteId > 0)
        this.RemoveSubPart(this.BChangeBasicSpriteId);
      if (this.BasicList2Id > 0)
        this.RemoveSubPart(this.BasicList2Id);
      if (this.ChangeMvId > 0)
        this.RemoveSubPart(this.ChangeMvId);
      if (this.BasicList3Id > 0)
        this.RemoveSubPart(this.BasicList3Id);
      if (this.ChangePenaltyId > 0)
        this.RemoveSubPart(this.ChangePenaltyId);
      if (!(this.riverNr > -1 & this.TabSheetNr > -1))
        return;
      if (this.TabSheetNr == 0)
        this.maketabsheetnr0();
      if (this.TabSheetNr == 1)
        this.maketabsheetnr1();
      if (this.TabSheetNr != 2)
        return;
      this.maketabsheetnr2();
    }

    private void maketabsheetnr0()
    {
      if (this.b1Id > 0)
        this.RemoveSubPart(this.b1Id);
      if (this.b1TextId > 0)
        this.RemoveSubPart(this.b1TextId);
      if (this.txt1 > 0)
        this.RemoveSubPart(this.txt1);
      if (this.txt2 > 0)
        this.RemoveSubPart(this.txt2);
      this.ss = "Click to change name of this rivertype";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
        this.b1Id = this.AddSubPart(ref tsubpart, 500, 350, 32, 16, 1);
      }
      string txt1;
      if (this.game.Data.RiverTypeObj[this.riverNr].SpecialLayer)
      {
        txt1 = "Change to 6 sprites";
        this.ss = "Click to change to old style 6 sprite river";
      }
      else
      {
        txt1 = "Change to 64 sprites";
        this.ss = "Click to change to 64 sprite river graphics. ";
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass(txt1, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.b1TextId = this.AddSubPart(ref tsubpart1, 550, 349, 400, 20, 0);
      if (this.txt1 > 0)
        this.RemoveSubPart(this.txt1);
      if (!this.game.Data.RiverTypeObj[this.riverNr].SpecialLayer)
      {
        if (this.game.Data.LandscapeTypeObj[this.riverNr].BasicSpriteCounter <= -1)
          return;
        this.BasicListObj = new ListClass();
        int tdata = 0;
        do
        {
          this.BasicListObj.add(this.game.Data.RiverTypeObj[this.riverNr].BasicSpriteFileName[tdata], tdata);
          ++tdata;
        }
        while (tdata <= 5);
        ListClass basicListObj = this.BasicListObj;
        int detailNr = this.DetailNr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(basicListObj, 10, 300, detailNr, game, tHeader: "Sprites", tbackbitmap: (ref local1), bbx: 10, bby: 350, overruleFont: (ref local2));
        this.BasicListId = this.AddSubPart(ref tsubpart2, 10, 350, 300, 208, 0);
        if (this.DetailNr > 5)
          this.DetailNr = -1;
        if (this.DetailNr <= -1)
          return;
        this.maketabsheetnr0b();
      }
      else
      {
        string txt2 = "Currently using a set of 64 sprites. Gfx: " + this.game.Data.RiverTypeObj[this.riverNr].LayerSpriteFileName[1];
        if (!this.game.Data.RiverTypeObj[this.riverNr].UseSheet)
        {
          SubPartClass tsubpart3 = (SubPartClass) new TextPartClass(txt2, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 550, 20, false, tDescript: this.ss);
          this.txt1 = this.AddSubPart(ref tsubpart3, 10, 398, 550, 20, 0);
        }
        else
        {
          this.ss = "the fred sheet you are currently using. filename = " + this.game.Data.RiverTypeObj[this.riverNr].SheetFileName;
          SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.Data.RiverTypeObj[this.riverNr].SheetSpriteID, tDescript: this.ss);
          this.txt1 = this.AddSubPart(ref tsubpart4, 10, 400, BitmapStore.GetWidth(this.game.Data.RiverTypeObj[this.riverNr].SheetSpriteID), BitmapStore.Getheight(this.game.Data.RiverTypeObj[this.riverNr].SheetSpriteID), 0);
        }
      }
    }

    private void maketabsheetnr0b()
    {
      if (this.BBasicSpriteId > 0)
        this.RemoveSubPart(this.BBasicSpriteId);
      if (this.BChangeBasicSpriteId > 0)
        this.RemoveSubPart(this.BChangeBasicSpriteId);
      this.ss = "Click to change the selected sprite";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.Data.RiverTypeObj[this.riverNr].BasicSpriteID[this.DetailNr], tDescript: this.ss);
      this.BBasicSpriteId = this.AddSubPart(ref tsubpart1, 400, 350, BitmapStore.GetBitmap(this.game.Data.RiverTypeObj[this.riverNr].BasicSpriteID[this.DetailNr]).Width, 48, 0);
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.BChangeBasicSpriteId = this.AddSubPart(ref tsubpart2, 400, 410, 32, 16, 1);
    }

    private void maketabsheetnr1()
    {
      if (this.BasicList2Id > 0)
        this.RemoveSubPart(this.BasicList2Id);
      if (this.ChangeMvId > 0)
        this.RemoveSubPart(this.ChangeMvId);
      this.BasicList2Obj = new ListClass();
      int index = 0;
      do
      {
        this.BasicList2Obj.add(this.game.Data.TempString[index] + "(" + Conversion.Str((object) index) + ") = " + Conversion.Str((object) this.game.Data.RiverTypeObj[this.riverNr].MovePenalty[index]) + "ap", index);
        ++index;
      }
      while (index <= 99);
      ListClass basicList2Obj = this.BasicList2Obj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(basicList2Obj, 10, 300, detailNr, game, tHeader: "Move-over River Penalties", tbackbitmap: (ref local1), bbx: 10, bby: 350, overruleFont: (ref local2));
      this.BasicList2Id = this.AddSubPart(ref tsubpart, 10, 350, 300, 208, 0);
      if (this.DetailNr > 99)
        this.DetailNr = -1;
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr1b();
    }

    private void maketabsheetnr1b()
    {
      if (this.ChangeMvId > 0)
        this.RemoveSubPart(this.ChangeMvId);
      this.ss = "Click to change the move penalty for crossing this river without a bridge over it";
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.ChangeMvId = this.AddSubPart(ref tsubpart, 400, 410, 32, 16, 1);
    }

    private void maketabsheetnr2()
    {
      if (this.BasicList3Id > 0)
        this.RemoveSubPart(this.BasicList3Id);
      if (this.ChangePenaltyId > 0)
        this.RemoveSubPart(this.ChangePenaltyId);
      this.BasicList3Obj = new ListClass();
      int index = 0;
      do
      {
        this.BasicList3Obj.add(this.game.Data.TempString[index + 400] + "(" + Conversion.Str((object) index) + ") = " + Conversion.Str((object) this.game.Data.RiverTypeObj[this.riverNr].AttackPenalty[index]), index);
        ++index;
      }
      while (index <= 99);
      ListClass basicList3Obj = this.BasicList3Obj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(basicList3Obj, 10, 300, detailNr, game, tHeader: "Attack-over River Penalties", tbackbitmap: (ref local1), bbx: 10, bby: 350, overruleFont: (ref local2));
      this.BasicList3Id = this.AddSubPart(ref tsubpart, 10, 350, 300, 208, 0);
      if (this.DetailNr > 39)
        this.DetailNr = -1;
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr2b();
    }

    private void maketabsheetnr2b()
    {
      if (this.ChangePenaltyId > 0)
        this.RemoveSubPart(this.ChangePenaltyId);
      this.ss = "Click to change the attack penalty for unitgroup for attacking over river (for with bridge see rulevar(5)) example: 0.4=-40% 0=no mod";
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.ChangePenaltyId = this.AddSubPart(ref tsubpart, 400, 410, 32, 16, 1);
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
            if (num1 == this.riverListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.riverNr = num2;
                this.MakeriverTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddriverId)
            {
              this.game.Data.AddRiverType();
              this.MakeriverListGUI(this.riverNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BNameId)
            {
              this.game.Data.RiverTypeObj[this.riverNr].Name = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest");
              this.MakeriverListGUI(this.riverNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BCostModId)
            {
              float num3 = (float) Conversion.Val(Interaction.InputBox("Give new attack-over river mod.", "Shadow Empire : Planetary Conquest"));
              if ((double) num3 < -1.0 | (double) num3 > 999.0)
              {
                int num4 = (int) Interaction.MsgBox((object) "Between -1 and 999 please. You can use 0.5 or 3.5 like values.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.RiverTypeObj[this.riverNr].BridgeCostModifier = num3;
              if ((double) num3 == -1.0)
              {
                int num5 = 0;
                int mapWidth = this.game.Data.MapObj[0].MapWidth;
                for (int index2 = 0; index2 <= mapWidth; ++index2)
                {
                  int mapHeight = this.game.Data.MapObj[0].MapHeight;
                  for (int index3 = 0; index3 <= mapHeight; ++index3)
                  {
                    int index4 = 0;
                    do
                    {
                      if (this.game.Data.MapObj[0].HexObj[index2, index3].RiverType[index4] == this.riverNr && this.game.Data.MapObj[0].HexObj[index2, index3].Bridge[index4])
                      {
                        ++num5;
                        this.game.Data.MapObj[0].HexObj[index2, index3].Bridge[index4] = false;
                      }
                      ++index4;
                    }
                    while (index4 <= 5);
                  }
                }
                if (num5 > 0)
                {
                  int num6 = (int) Interaction.MsgBox((object) ("Removed " + num5.ToString() + " bridges that were across this river type."), Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
              }
              this.MakeriverListGUI(this.riverNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b3id)
            {
              this.game.Data.RiverTypeObj[this.riverNr].Transparent = !this.game.Data.RiverTypeObj[this.riverNr].Transparent;
              this.MakeriverListGUI(this.riverNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b6id)
            {
              int num7 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new thickness please", "Shadow Empire : Planetary Conquest")));
              if (num7 >= 0 & num7 <= 9)
              {
                this.game.Data.RiverTypeObj[this.riverNr].Thickness = num7;
                this.MakeriverListGUI(this.riverNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              int num8 = (int) Interaction.MsgBox((object) "Thickness must be in range 0-9.", Title: ((object) "Shadow Empire : Planetary Conquest"));
            }
            else
            {
              if (num1 == this.b4id)
              {
                this.game.Data.RiverTypeObj[this.riverNr].snakeMode = !this.game.Data.RiverTypeObj[this.riverNr].snakeMode;
                this.MakeriverListGUI(this.riverNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.b5id)
              {
                this.game.Data.RiverTypeObj[this.riverNr].drawInteriorOnly = !this.game.Data.RiverTypeObj[this.riverNr].drawInteriorOnly;
                this.MakeriverListGUI(this.riverNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.OptionsListId)
              {
                int num9 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num9 > -1)
                {
                  this.TabSheetNr = num9;
                  this.maketabsheet();
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BRemoveriverId)
              {
                this.game.Data.RemoveRiverType(this.riverNr);
                this.MakeriverListGUI(-1);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BasicListId)
              {
                int num10 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num10 > -1)
                {
                  this.DetailNr = num10;
                  this.maketabsheetnr0b();
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BChangeBasicSpriteId)
              {
                string filename = this.game.HandyFunctionsObj.LoadSomething("Bitmaps (*.bmp)|*.bmp|Png|*.png", "Select File For River Sprite:", this.game.AppPath + "graphics\\", true);
                if (File.Exists(this.game.AppPath + "graphics/" + filename))
                {
                  this.game.Data.RiverTypeObj[this.riverNr].ReplaceBasicSprite(this.DetailNr, filename);
                }
                else
                {
                  int num11 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.maketabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BDrawId)
              {
                this.game.EditObj.PencilType = 5;
                this.game.EditObj.PencilData1 = this.riverNr;
                windowReturnClass.AddCommand(1, 13);
                windowReturnClass.AddCommand(2, 13);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BasicList2Id)
              {
                int num12 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num12 > -1)
                {
                  this.DetailNr = num12;
                  this.maketabsheetnr1b();
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.ChangeMvId)
              {
                int num13 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new ap overrule please", "Shadow Empire : Planetary Conquest")));
                if (num13 > -1 & num13 <= 9999)
                {
                  this.game.Data.RiverTypeObj[this.riverNr].MovePenalty[this.DetailNr] = num13;
                }
                else
                {
                  int num14 = (int) Interaction.MsgBox((object) "Value between 0 and 10000 please...", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.maketabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BasicList3Id)
              {
                int num15 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num15 > -1)
                {
                  this.DetailNr = num15;
                  this.maketabsheetnr2b();
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.ChangePenaltyId)
              {
                float num16 = (float) Conversion.Val(Interaction.InputBox("Give new attack-over river mod.", "Shadow Empire : Planetary Conquest"));
                if ((double) num16 < 0.0 | (double) num16 > 1.0)
                {
                  int num17 = (int) Interaction.MsgBox((object) "Between 0 and 1 please. You can use 0.5 or 0.87 like values.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                  this.game.Data.RiverTypeObj[this.riverNr].AttackPenalty[this.DetailNr] = num16;
                this.maketabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.b1Id)
              {
                this.game.Data.RiverTypeObj[this.riverNr].SpecialLayer = !this.game.Data.RiverTypeObj[this.riverNr].SpecialLayer;
                if (!this.game.Data.RiverTypeObj[this.riverNr].SpecialLayer)
                {
                  this.game.Data.RiverTypeObj[this.riverNr].UseSheet = false;
                  this.game.Data.RiverTypeObj[this.riverNr].SheetFileName = "systemgraphics/trans.bmp";
                }
                if (this.game.Data.RiverTypeObj[this.riverNr].SpecialLayer)
                {
                  if (Interaction.MsgBox((object) "Use Fred SpriteSheet?", MsgBoxStyle.YesNo) == MsgBoxResult.No)
                    this.game.Data.RiverTypeObj[this.riverNr].UseSheet = false;
                  else
                    this.game.Data.RiverTypeObj[this.riverNr].UseSheet = true;
                  if (!this.game.Data.RiverTypeObj[this.riverNr].UseSheet)
                  {
                    string extstring = Interaction.InputBox("Give a graphical extension: .jpg, .png, .bmp");
                    string dirstring = Interaction.InputBox("Give a directory name under the graphics directory", "Shadow Empire : Planetary Conquest");
                    if (File.Exists(this.game.AppPath + "graphics/" + dirstring + "/a1" + extstring))
                    {
                      this.game.Data.RiverTypeObj[this.riverNr].AutoLoadSpecial(dirstring, extstring);
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    this.game.Data.RiverTypeObj[this.riverNr].SpecialLayer = false;
                    int num18 = (int) Interaction.MsgBox((object) "Could not find this dir... give it like 'sea' or 'africa/desert', make sure a1 is present.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select normal sized sheet (big & small will be auto-linked)", this.game.AppPath + "graphics\\", true);
                    if (File.Exists(this.game.AppPath + "graphics/" + filename))
                    {
                      this.game.Data.RiverTypeObj[this.riverNr].ReplaceSpriteSheet(filename);
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    int num19 = (int) Interaction.MsgBox((object) "Could not find this file... ", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                }
                this.maketabsheet();
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
