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
  pub class RiverTypeWindowClass : WindowClass
  {
     int riverListId;
     ListClass riverListObj;
     int BAddriverId;
     int BAddriverTextId;
     int BNameId;
     int BNameTextId;
     int BCostModId;
     int BCostModTextid;
     int OptionsListId;
     ListClass OptionsListObj;
     int BRemoveriverId;
     int BRemoveriverTextId;
     int BDrawId;
     int b1Id;
     int BDrawTextId;
     int txt1;
     int txt2;
     int b1TextId;
    pub b3id: i32;
    pub b3textid: i32;
    pub b4id: i32;
    pub b4textid: i32;
    pub b5id: i32;
    pub b5textid: i32;
    pub b6id: i32;
    pub b6textid: i32;
     ListClass BasicListObj;
     int BasicListId;
     int BBasicSpriteId;
     int BChangeBasicSpriteId;
     ListClass BasicList2Obj;
     int BasicList2Id;
     int ChangeMvId;
     ListClass BasicList3Obj;
     int BasicList3Id;
     int ChangePenaltyId;
     int riverNr;
     int TabSheetNr;
     int DetailNr;
     string ss;

    pub void DoRefresh() => this.MakeriverTypeItemGUI();

    pub RiverTypeWindowClass( GameClass tGame)
      : base( tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "River Types")
    {
      this.riverNr = -1;
      this.TabSheetNr = -1;
      this.DetailNr = -1;
      this.MakeriverListGUI(-1);
    }

     void MakeriverListGUI(int trivernr)
    {
      if (this.riverListId > 0)
        this.RemoveSubPart(this.riverListId);
      SubPartClass tsubpart;
      if (this.game.Data.RiverTypeCounter > -1)
      {
        this.riverListObj = ListClass::new();
        let mut riverTypeCounter: i32 = this.game.Data.RiverTypeCounter;
        for (let mut index: i32 = 0; index <= riverTypeCounter; index += 1)
          this.riverListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.RiverTypeObj[index].Name, index);
        ListClass riverListObj = this.riverListObj;
        let mut tlistselect: i32 = trivernr;
        let mut game: GameClass = this.game;
         Bitmap local1 =  this.OwnBitmap;
        Font font =  null;
         Font local2 =  font;
        tsubpart =  new ListSubPartClass(riverListObj, 9, 200, tlistselect, game, tHeader: "River Types", tbackbitmap: ( local1), bbx: 10, bby: 50, overruleFont: ( local2));
        this.riverListId = this.AddSubPart( tsubpart, 10, 50, 200, 192, 0);
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
        tsubpart =  ButtonPartClass::new(this.game.BUTTONPLUS, tDescript: this.ss);
        this.BAddriverId = this.AddSubPart( tsubpart, 10, 270, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      tsubpart =  TextPartClass::new("Add river Type", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BAddriverTextId = this.AddSubPart( tsubpart, 50, 269, 300, 20, 0);
    }

     void MakeriverTypeItemGUI()
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
          let mut tsubpart: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.BNameId = this.AddSubPart( tsubpart, 370, 50, 32, 16, 1);
        }
        let mut tsubpart1: SubPartClass =  TextPartClass::new("Name: " + this.game.Data.RiverTypeObj[this.riverNr].Name, Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.BNameTextId = this.AddSubPart( tsubpart1, 410, 49, 400, 20, 0);
        this.ss = "Click to change the modifier for the EP cost to build a bridge over this rivertype and the modifier for the structural points. dc3: set to -1 to never place bridge over this river type";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          let mut tsubpart2: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.BCostModId = this.AddSubPart( tsubpart2, 370, 70, 32, 16, 1);
        }
        let mut tsubpart3: SubPartClass =  TextPartClass::new("BridgeCostMod: " + Conversion.Str((object) this.game.Data.RiverTypeObj[this.riverNr].BridgeCostModifier), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.BCostModTextid = this.AddSubPart( tsubpart3, 410, 69, 400, 20, 0);
        this.ss = "Click to change transparent setting (works best in combination with overlay map)";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.b3id = this.AddSubPart( tsubpart3, 370, 90, 32, 16, 1);
        }
        tsubpart3 =  TextPartClass::new("Transparent: " + Conversion.Str((object) this.game.Data.RiverTypeObj[this.riverNr].Transparent), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.b3textid = this.AddSubPart( tsubpart3, 410, 89, 400, 20, 0);
        this.ss = "Click to change the thickness for mini/strat. map";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.b6id = this.AddSubPart( tsubpart3, 370, 110, 32, 16, 1);
        }
        tsubpart3 =  TextPartClass::new("Thickness: " + Conversion.Str((object) this.game.Data.RiverTypeObj[this.riverNr].Thickness), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.b6textid = this.AddSubPart( tsubpart3, 410, 109, 400, 20, 0);
        this.ss = "Click to set to Snake Mode drawing style";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.b4id = this.AddSubPart( tsubpart3, 770, 90, 32, 16, 1);
        }
        tsubpart3 =  TextPartClass::new("SnakeMode: " + Conversion.Str((object) this.game.Data.RiverTypeObj[this.riverNr].snakeMode), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.b4textid = this.AddSubPart( tsubpart3, 810, 89, 400, 20, 0);
        this.ss = "Click to set draw mode in editor.";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.b5id = this.AddSubPart( tsubpart3, 770, 70, 32, 16, 1);
        }
        tsubpart3 =  TextPartClass::new("drawInteriorOnly: " + Conversion.Str((object) this.game.Data.RiverTypeObj[this.riverNr].drawInteriorOnly), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.b5textid = this.AddSubPart( tsubpart3, 810, 69, 400, 20, 0);
        this.ss = "Click to remove this rivertype";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 =  ButtonPartClass::new(this.game.BUTTONKILL, tDescript: this.ss);
          this.BRemoveriverId = this.AddSubPart( tsubpart3, 10, 290, 32, 16, 1);
        }
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 =  TextPartClass::new("Remove this RiverType", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.BRemoveriverTextId = this.AddSubPart( tsubpart3, 50, 289, 200, 20, 0);
        }
        this.ss = "Click to use this rivertype to draw on the map.";
        tsubpart3 =  ButtonPartClass::new(this.game.BUTTONDRAW, tDescript: this.ss);
        this.BDrawId = this.AddSubPart( tsubpart3, 10, 310, 32, 16, 1);
        tsubpart3 =  TextPartClass::new("Select as pencil", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BDrawTextId = this.AddSubPart( tsubpart3, 50, 309, 200, 20, 0);
        this.OptionsListObj = ListClass::new();
        this.OptionsListObj.add("Sprites", 0);
        this.OptionsListObj.add("Move-over River Penalties", 1);
        this.OptionsListObj.add("Attack-over River Penalties", 2);
        ListClass optionsListObj = this.OptionsListObj;
        let mut tabSheetNr: i32 = this.TabSheetNr;
        let mut game: GameClass = this.game;
         Bitmap local1 =  this.OwnBitmap;
        Font font =  null;
         Font local2 =  font;
        tsubpart3 =  new ListSubPartClass(optionsListObj, 3, 300, tabSheetNr, game, tHeader: "Property Sheets", tbackbitmap: ( local1), bbx: 370, bby: 140, overruleFont: ( local2));
        this.OptionsListId = this.AddSubPart( tsubpart3, 370, 140, 300, 96, 0);
      }
      this.maketabsheet();
    }

     void maketabsheet()
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

     void maketabsheetnr0()
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
        let mut tsubpart: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLUE, tDescript: this.ss);
        this.b1Id = this.AddSubPart( tsubpart, 500, 350, 32, 16, 1);
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
      let mut tsubpart1: SubPartClass =  TextPartClass::new(txt1, Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.b1TextId = this.AddSubPart( tsubpart1, 550, 349, 400, 20, 0);
      if (this.txt1 > 0)
        this.RemoveSubPart(this.txt1);
      if (!this.game.Data.RiverTypeObj[this.riverNr].SpecialLayer)
      {
        if (this.game.Data.LandscapeTypeObj[this.riverNr].BasicSpriteCounter <= -1)
          return;
        this.BasicListObj = ListClass::new();
        let mut tdata: i32 = 0;
        do
        {
          this.BasicListObj.add(this.game.Data.RiverTypeObj[this.riverNr].BasicSpriteFileName[tdata], tdata);
          tdata += 1;
        }
        while (tdata <= 5);
        ListClass basicListObj = this.BasicListObj;
        let mut detailNr: i32 = this.DetailNr;
        let mut game: GameClass = this.game;
         Bitmap local1 =  this.OwnBitmap;
        Font font =  null;
         Font local2 =  font;
        let mut tsubpart2: SubPartClass =  new ListSubPartClass(basicListObj, 10, 300, detailNr, game, tHeader: "Sprites", tbackbitmap: ( local1), bbx: 10, bby: 350, overruleFont: ( local2));
        this.BasicListId = this.AddSubPart( tsubpart2, 10, 350, 300, 208, 0);
        if (this.DetailNr > 5)
          this.DetailNr = -1;
        if (this.DetailNr <= -1)
          return;
        this.maketabsheetnr0b();
      }
      else
      {
        txt2: String = "Currently using a set of 64 sprites. Gfx: " + this.game.Data.RiverTypeObj[this.riverNr].LayerSpriteFileName[1];
        if (!this.game.Data.RiverTypeObj[this.riverNr].UseSheet)
        {
          let mut tsubpart3: SubPartClass =  TextPartClass::new(txt2, Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 550, 20, false, tDescript: this.ss);
          this.txt1 = this.AddSubPart( tsubpart3, 10, 398, 550, 20, 0);
        }
        else
        {
          this.ss = "the fred sheet you are currently using. filename = " + this.game.Data.RiverTypeObj[this.riverNr].SheetFileName;
          let mut tsubpart4: SubPartClass =  ButtonPartClass::new(this.game.Data.RiverTypeObj[this.riverNr].SheetSpriteID, tDescript: this.ss);
          this.txt1 = this.AddSubPart( tsubpart4, 10, 400, BitmapStore.GetWidth(this.game.Data.RiverTypeObj[this.riverNr].SheetSpriteID), BitmapStore.Getheight(this.game.Data.RiverTypeObj[this.riverNr].SheetSpriteID), 0);
        }
      }
    }

     void maketabsheetnr0b()
    {
      if (this.BBasicSpriteId > 0)
        this.RemoveSubPart(this.BBasicSpriteId);
      if (this.BChangeBasicSpriteId > 0)
        this.RemoveSubPart(this.BChangeBasicSpriteId);
      this.ss = "Click to change the selected sprite";
      let mut tsubpart1: SubPartClass =  ButtonPartClass::new(this.game.Data.RiverTypeObj[this.riverNr].BasicSpriteID[this.DetailNr], tDescript: this.ss);
      this.BBasicSpriteId = this.AddSubPart( tsubpart1, 400, 350, BitmapStore.GetBitmap(this.game.Data.RiverTypeObj[this.riverNr].BasicSpriteID[this.DetailNr]).Width, 48, 0);
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      let mut tsubpart2: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.BChangeBasicSpriteId = this.AddSubPart( tsubpart2, 400, 410, 32, 16, 1);
    }

     void maketabsheetnr1()
    {
      if (this.BasicList2Id > 0)
        this.RemoveSubPart(this.BasicList2Id);
      if (this.ChangeMvId > 0)
        this.RemoveSubPart(this.ChangeMvId);
      this.BasicList2Obj = ListClass::new();
      let mut index: i32 = 0;
      do
      {
        this.BasicList2Obj.add(this.game.Data.TempString[index] + "(" + Conversion.Str((object) index) + ") = " + Conversion.Str((object) this.game.Data.RiverTypeObj[this.riverNr].MovePenalty[index]) + "ap", index);
        index += 1;
      }
      while (index <= 99);
      ListClass basicList2Obj = this.BasicList2Obj;
      let mut detailNr: i32 = this.DetailNr;
      let mut game: GameClass = this.game;
       Bitmap local1 =  this.OwnBitmap;
      Font font =  null;
       Font local2 =  font;
      let mut tsubpart: SubPartClass =  new ListSubPartClass(basicList2Obj, 10, 300, detailNr, game, tHeader: "Move-over River Penalties", tbackbitmap: ( local1), bbx: 10, bby: 350, overruleFont: ( local2));
      this.BasicList2Id = this.AddSubPart( tsubpart, 10, 350, 300, 208, 0);
      if (this.DetailNr > 99)
        this.DetailNr = -1;
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr1b();
    }

     void maketabsheetnr1b()
    {
      if (this.ChangeMvId > 0)
        this.RemoveSubPart(this.ChangeMvId);
      this.ss = "Click to change the move penalty for crossing this river without a bridge over it";
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      let mut tsubpart: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.ChangeMvId = this.AddSubPart( tsubpart, 400, 410, 32, 16, 1);
    }

     void maketabsheetnr2()
    {
      if (this.BasicList3Id > 0)
        this.RemoveSubPart(this.BasicList3Id);
      if (this.ChangePenaltyId > 0)
        this.RemoveSubPart(this.ChangePenaltyId);
      this.BasicList3Obj = ListClass::new();
      let mut index: i32 = 0;
      do
      {
        this.BasicList3Obj.add(this.game.Data.TempString[index + 400] + "(" + Conversion.Str((object) index) + ") = " + Conversion.Str((object) this.game.Data.RiverTypeObj[this.riverNr].AttackPenalty[index]), index);
        index += 1;
      }
      while (index <= 99);
      ListClass basicList3Obj = this.BasicList3Obj;
      let mut detailNr: i32 = this.DetailNr;
      let mut game: GameClass = this.game;
       Bitmap local1 =  this.OwnBitmap;
      Font font =  null;
       Font local2 =  font;
      let mut tsubpart: SubPartClass =  new ListSubPartClass(basicList3Obj, 10, 300, detailNr, game, tHeader: "Attack-over River Penalties", tbackbitmap: ( local1), bbx: 10, bby: 350, overruleFont: ( local2));
      this.BasicList3Id = this.AddSubPart( tsubpart, 10, 350, 300, 208, 0);
      if (this.DetailNr > 39)
        this.DetailNr = -1;
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr2b();
    }

     void maketabsheetnr2b()
    {
      if (this.ChangePenaltyId > 0)
        this.RemoveSubPart(this.ChangePenaltyId);
      this.ss = "Click to change the attack penalty for unitgroup for attacking over river (for with bridge see rulevar(5)) example: 0.4=-40% 0=no mod";
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      let mut tsubpart: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.ChangePenaltyId = this.AddSubPart( tsubpart, 400, 410, 32, 16, 1);
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
            if (num1 == this.riverListId)
            {
              let mut num2: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
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
                let mut num4: i32 =  Interaction.MsgBox((object) "Between -1 and 999 please. You can use 0.5 or 3.5 like values.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.RiverTypeObj[this.riverNr].BridgeCostModifier = num3;
              if ((double) num3 == -1.0)
              {
                let mut num5: i32 = 0;
                let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
                for (let mut index2: i32 = 0; index2 <= mapWidth; index2 += 1)
                {
                  let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
                  for (let mut index3: i32 = 0; index3 <= mapHeight; index3 += 1)
                  {
                    let mut index4: i32 = 0;
                    do
                    {
                      if (this.game.Data.MapObj[0].HexObj[index2, index3].RiverType[index4] == this.riverNr && this.game.Data.MapObj[0].HexObj[index2, index3].Bridge[index4])
                      {
                        num5 += 1;
                        this.game.Data.MapObj[0].HexObj[index2, index3].Bridge[index4] = false;
                      }
                      index4 += 1;
                    }
                    while (index4 <= 5);
                  }
                }
                if (num5 > 0)
                {
                  let mut num6: i32 =  Interaction.MsgBox((object) ("Removed " + num5.ToString() + " bridges that were across this river type."), Title: ((object) "Shadow Empire : Planetary Conquest"));
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
              let mut num7: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give new thickness please", "Shadow Empire : Planetary Conquest")));
              if (num7 >= 0 & num7 <= 9)
              {
                this.game.Data.RiverTypeObj[this.riverNr].Thickness = num7;
                this.MakeriverListGUI(this.riverNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              let mut num8: i32 =  Interaction.MsgBox((object) "Thickness must be in range 0-9.", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
                let mut num9: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
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
                let mut num10: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
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
                filename: String = this.game.HandyFunctionsObj.LoadSomething("Bitmaps (*.bmp)|*.bmp|Png|*.png", "Select File For River Sprite:", this.game.AppPath + "graphics\\", true);
                if (File.Exists(this.game.AppPath + "graphics/" + filename))
                {
                  this.game.Data.RiverTypeObj[this.riverNr].ReplaceBasicSprite(this.DetailNr, filename);
                }
                else
                {
                  let mut num11: i32 =  Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
                let mut num12: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
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
                let mut num13: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give new ap overrule please", "Shadow Empire : Planetary Conquest")));
                if (num13 > -1 & num13 <= 9999)
                {
                  this.game.Data.RiverTypeObj[this.riverNr].MovePenalty[this.DetailNr] = num13;
                }
                else
                {
                  let mut num14: i32 =  Interaction.MsgBox((object) "Value between 0 and 10000 please...", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.maketabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BasicList3Id)
              {
                let mut num15: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
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
                  let mut num17: i32 =  Interaction.MsgBox((object) "Between 0 and 1 please. You can use 0.5 or 0.87 like values.", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
                    extstring: String = Interaction.InputBox("Give a graphical extension: .jpg, .png, .bmp");
                    dirstring: String = Interaction.InputBox("Give a directory name under the graphics directory", "Shadow Empire : Planetary Conquest");
                    if (File.Exists(this.game.AppPath + "graphics/" + dirstring + "/a1" + extstring))
                    {
                      this.game.Data.RiverTypeObj[this.riverNr].AutoLoadSpecial(dirstring, extstring);
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    this.game.Data.RiverTypeObj[this.riverNr].SpecialLayer = false;
                    let mut num18: i32 =  Interaction.MsgBox((object) "Could not find this dir... give it like 'sea' or 'africa/desert', make sure a1 is present.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    filename: String = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select normal sized sheet (big & small will be auto-linked)", this.game.AppPath + "graphics\\", true);
                    if (File.Exists(this.game.AppPath + "graphics/" + filename))
                    {
                      this.game.Data.RiverTypeObj[this.riverNr].ReplaceSpriteSheet(filename);
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    let mut num19: i32 =  Interaction.MsgBox((object) "Could not find this file... ", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
