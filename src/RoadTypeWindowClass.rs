// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.RoadTypeWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace WindowsApplication1
{
  pub class RoadTypeWindowClass : WindowClass
  {
     int RoadListId;
     ListClass RoadListObj;
     int BAddRoadId;
     int BAddRoadTextId;
     int BNameId;
     int BNameTextId;
     int B2Id;
     int B2TextId;
     int B3Id;
     int B3TextId;
     int B4Id;
     int B4TextId;
     int B5Id;
     int B5TextId;
     int B6Id;
     int B6TextId;
     int B7Id;
     int B7TextId;
     int OptionsListId;
     ListClass OptionsListObj;
     int BRemoveRoadId;
     int BRemoveRoadTextId;
     int BDrawId;
     int BDrawTextId;
     ListClass BasicListObj;
     int BasicListId;
     int b1id;
     int b1textid;
     int BBasicSpriteId;
     int BChangeBasicSpriteId;
     ListClass BasicList2Obj;
     int BasicList2Id;
     int ChangeMvId;
     int[] Bitemid;
     int[] bitemtextid;
     int BEP;
     int BEPText;
     int txt1;
     int bthick;
     int bthicktext;
     int bother;
     int bothertext;
     int BridgeId;
     int BridgeTextId;
     ListClass BridgeListObj;
     int BridgeListId;
     int BBridgeSpriteId;
     int BChangeBridgeSpriteId;
     int BChangeBridgeSpriteId2;
     int RoadNr;
     int TabSheetNr;
     int DetailNr;
     int BridgeNr;
     string ss;

    pub RoadTypeWindowClass( GameClass tGame)
      : base( tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Road Types")
    {
      this.Bitemid = new int[5];
      this.bitemtextid = new int[5];
      this.RoadNr = -1;
      this.TabSheetNr = -1;
      this.DetailNr = -1;
      this.BridgeNr = -1;
      this.MakeRoadListGUI(-1);
    }

    pub void DoRefresh() => this.MakeRoadTypeItemGUI();

     void MakeRoadListGUI(int tRoadnr)
    {
      if (this.RoadListId > 0)
        this.RemoveSubPart(this.RoadListId);
      SubPartClass tsubpart;
      if (this.game.Data.RoadTypeCounter > -1)
      {
        this.RoadListObj = ListClass::new();
        let mut roadTypeCounter: i32 = this.game.Data.RoadTypeCounter;
        for (let mut index: i32 = 0; index <= roadTypeCounter; index += 1)
          this.RoadListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.RoadTypeObj[index].Name, index);
        ListClass roadListObj = this.RoadListObj;
        let mut tlistselect: i32 = tRoadnr;
        let mut game: GameClass = this.game;
         Bitmap local1 =  this.OwnBitmap;
        Font font =  null;
         Font local2 =  font;
        tsubpart =  new ListSubPartClass(roadListObj, 9, 200, tlistselect, game, tHeader: "Road Types", tbackbitmap: ( local1), bbx: 10, bby: 50, overruleFont: ( local2));
        this.RoadListId = this.AddSubPart( tsubpart, 10, 50, 200, 192, 0);
        this.RoadNr = tRoadnr;
        this.MakeRoadTypeItemGUI();
      }
      else
      {
        this.RoadNr = tRoadnr;
        this.MakeRoadTypeItemGUI();
      }
      if (this.BAddRoadId > 0)
        this.RemoveSubPart(this.BAddRoadId);
      if (this.BAddRoadTextId > 0)
        this.RemoveSubPart(this.BAddRoadTextId);
      this.ss = "Click to add a new RoadType";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart =  ButtonPartClass::new(this.game.BUTTONPLUS, tDescript: this.ss);
        this.BAddRoadId = this.AddSubPart( tsubpart, 10, 270, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      tsubpart =  TextPartClass::new("Add Road Type", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BAddRoadTextId = this.AddSubPart( tsubpart, 50, 269, 300, 20, 0);
    }

     void MakeRoadTypeItemGUI()
    {
      if (this.BNameId > 0)
        this.RemoveSubPart(this.BNameId);
      if (this.BNameTextId > 0)
        this.RemoveSubPart(this.BNameTextId);
      if (this.BRemoveRoadId > 0)
        this.RemoveSubPart(this.BRemoveRoadId);
      if (this.BRemoveRoadTextId > 0)
        this.RemoveSubPart(this.BRemoveRoadTextId);
      if (this.BDrawId > 0)
        this.RemoveSubPart(this.BDrawId);
      if (this.BDrawTextId > 0)
        this.RemoveSubPart(this.BDrawTextId);
      if (this.OptionsListId > 0)
        this.RemoveSubPart(this.OptionsListId);
      let mut index: i32 = 0;
      do
      {
        if (this.Bitemid[index] > 0)
          this.RemoveSubPart(this.Bitemid[index]);
        if (this.bitemtextid[index] > 0)
          this.RemoveSubPart(this.bitemtextid[index]);
        index += 1;
      }
      while (index <= 4);
      if (this.BasicListId > 0)
        this.RemoveSubPart(this.BasicListId);
      if (this.BBasicSpriteId > 0)
        this.RemoveSubPart(this.BBasicSpriteId);
      if (this.BChangeBasicSpriteId > 0)
        this.RemoveSubPart(this.BChangeBasicSpriteId);
      if (this.BridgeListId > 0)
        this.RemoveSubPart(this.BridgeListId);
      if (this.BBridgeSpriteId > 0)
        BitmapStore.RemoveBitmapNr(this.BBridgeSpriteId);
      if (this.BChangeBridgeSpriteId > 0)
        this.RemoveSubPart(this.BChangeBridgeSpriteId);
      if (this.BChangeBridgeSpriteId2 > 0)
        this.RemoveSubPart(this.BChangeBridgeSpriteId2);
      if (this.BridgeId > 0)
        this.RemoveSubPart(this.BridgeId);
      if (this.BridgeTextId > 0)
        this.RemoveSubPart(this.BridgeTextId);
      if (this.BasicList2Id > 0)
        this.RemoveSubPart(this.BasicList2Id);
      if (this.ChangeMvId > 0)
        this.RemoveSubPart(this.ChangeMvId);
      if (this.BEP > 0)
        this.RemoveSubPart(this.BEP);
      if (this.BEPText > 0)
        this.RemoveSubPart(this.BEPText);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
      if (this.B6Id > 0)
        this.RemoveSubPart(this.B6Id);
      if (this.B6TextId > 0)
        this.RemoveSubPart(this.B6TextId);
      if (this.B7Id > 0)
        this.RemoveSubPart(this.B7Id);
      if (this.B7TextId > 0)
        this.RemoveSubPart(this.B7TextId);
      if (this.bthick > 0)
        this.RemoveSubPart(this.bthick);
      if (this.bthicktext > 0)
        this.RemoveSubPart(this.bthicktext);
      if (this.bother > 0)
        this.RemoveSubPart(this.bother);
      if (this.bothertext > 0)
        this.RemoveSubPart(this.bothertext);
      if (this.RoadNr > -1)
      {
        this.ss = "Click to change the name of this roadtype";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          let mut tsubpart: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.BNameId = this.AddSubPart( tsubpart, 370, 50, 32, 16, 1);
        }
        let mut tsubpart1: SubPartClass =  TextPartClass::new("Name: " + this.game.Data.RoadTypeObj[this.RoadNr].Name, Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.BNameTextId = this.AddSubPart( tsubpart1, 410, 49, 400, 20, 0);
        this.ss = "Click to set transparent settings (works well in combi with overlay map)";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          let mut tsubpart2: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.B2Id = this.AddSubPart( tsubpart2, 370, 70, 32, 16, 1);
        }
        let mut tsubpart3: SubPartClass =  TextPartClass::new("Transparent: " + Conversion.Str((object) this.game.Data.RoadTypeObj[this.RoadNr].Transparent), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B2TextId = this.AddSubPart( tsubpart3, 410, 69, 400, 20, 0);
        this.ss = "Click to remove this roadtype";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 =  ButtonPartClass::new(this.game.BUTTONKILL, tDescript: this.ss);
          this.BRemoveRoadId = this.AddSubPart( tsubpart3, 10, 290, 32, 16, 1);
        }
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 =  TextPartClass::new("Remove this RoadType", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.BRemoveRoadTextId = this.AddSubPart( tsubpart3, 50, 289, 200, 20, 0);
        }
        this.ss = "Click to use this road type for drawing on the map";
        tsubpart3 =  ButtonPartClass::new(this.game.BUTTONDRAW, tDescript: this.ss);
        this.BDrawId = this.AddSubPart( tsubpart3, 10, 310, 32, 16, 1);
        tsubpart3 =  TextPartClass::new("Select as pencil", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BDrawTextId = this.AddSubPart( tsubpart3, 50, 309, 200, 20, 0);
        this.OptionsListObj = ListClass::new();
        this.OptionsListObj.add("Sprites", 0);
        this.OptionsListObj.add("Movecost for Road", 1);
        this.OptionsListObj.add("Details", 2);
        ListClass optionsListObj = this.OptionsListObj;
        let mut tabSheetNr: i32 = this.TabSheetNr;
        let mut game: GameClass = this.game;
         Bitmap local1 =  this.OwnBitmap;
        Font font =  null;
         Font local2 =  font;
        tsubpart3 =  new ListSubPartClass(optionsListObj, 4, 300, tabSheetNr, game, tHeader: "Property Sheets", tbackbitmap: ( local1), bbx: 370, bby: 140, overruleFont: ( local2));
        this.OptionsListId = this.AddSubPart( tsubpart3, 370, 140, 300, 112, 0);
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
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
      if (this.BEP > 0)
        this.RemoveSubPart(this.BEP);
      if (this.BEPText > 0)
        this.RemoveSubPart(this.BEPText);
      if (this.b1id > 0)
        this.RemoveSubPart(this.b1id);
      if (this.b1textid > 0)
        this.RemoveSubPart(this.b1textid);
      if (this.txt1 > 0)
        this.RemoveSubPart(this.txt1);
      if (this.B5Id > 0)
        this.RemoveSubPart(this.B5Id);
      if (this.B5TextId > 0)
        this.RemoveSubPart(this.B5TextId);
      if (this.B4Id > 0)
        this.RemoveSubPart(this.B4Id);
      if (this.B4TextId > 0)
        this.RemoveSubPart(this.B4TextId);
      if (this.B6Id > 0)
        this.RemoveSubPart(this.B6Id);
      if (this.B6TextId > 0)
        this.RemoveSubPart(this.B6TextId);
      if (this.B7Id > 0)
        this.RemoveSubPart(this.B7Id);
      if (this.B7TextId > 0)
        this.RemoveSubPart(this.B7TextId);
      if (this.BridgeListId > 0)
        this.RemoveSubPart(this.BridgeListId);
      if (this.BBridgeSpriteId > 0)
        this.RemoveSubPart(this.BBridgeSpriteId);
      if (this.BChangeBridgeSpriteId > 0)
        this.RemoveSubPart(this.BChangeBridgeSpriteId);
      if (this.BridgeId > 0)
        this.RemoveSubPart(this.BridgeId);
      if (this.BridgeTextId > 0)
        this.RemoveSubPart(this.BridgeTextId);
      if (!(this.RoadNr > -1 & this.TabSheetNr > -1))
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
      if (this.ChangeMvId > 0)
        this.RemoveSubPart(this.ChangeMvId);
      if (this.b1id > 0)
        this.RemoveSubPart(this.b1id);
      if (this.b1textid > 0)
        this.RemoveSubPart(this.b1textid);
      if (this.txt1 > 0)
        this.RemoveSubPart(this.txt1);
      if (this.B5Id > 0)
        this.RemoveSubPart(this.B5Id);
      if (this.B5TextId > 0)
        this.RemoveSubPart(this.B5TextId);
      if (this.B4Id > 0)
        this.RemoveSubPart(this.B4Id);
      if (this.B4TextId > 0)
        this.RemoveSubPart(this.B4TextId);
      this.ss = "";
      string txt1;
      if (this.game.Data.RoadTypeObj[this.RoadNr].SpecialLayer)
      {
        txt1 = "Change to 6 sprites";
        this.ss = "Click to go back to old 6 sprite mode";
      }
      else
      {
        txt1 = "Change to 64 sprites";
        this.ss = "Click to x64 sprite mode just as with landscape type borders";
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        let mut tsubpart: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLUE, tDescript: this.ss);
        this.b1id = this.AddSubPart( tsubpart, 500, 350, 32, 16, 1);
      }
      let mut tsubpart1: SubPartClass =  TextPartClass::new(txt1, Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.b1textid = this.AddSubPart( tsubpart1, 550, 349, 400, 20, 0);
      if (this.txt1 > 0)
        this.RemoveSubPart(this.txt1);
      if (!this.game.Data.RoadTypeObj[this.RoadNr].SpecialLayer)
      {
        this.BasicListObj = ListClass::new();
        let mut tdata: i32 = 0;
        do
        {
          this.BasicListObj.add(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteFileName[tdata], tdata);
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
        txt2: String = "Currently using a set of 64 sprites.";
        if (!this.game.Data.RoadTypeObj[this.RoadNr].UseSheet)
        {
          let mut tsubpart3: SubPartClass =  TextPartClass::new(txt2, Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 250, 20, false, tDescript: this.ss);
          this.txt1 = this.AddSubPart( tsubpart3, 10, 398, 250, 20, 1);
        }
        else
        {
          this.ss = "the fred sheet you are currently using. filename = " + this.game.Data.RoadTypeObj[this.RoadNr].SheetFileName;
          let mut tsubpart4: SubPartClass =  ButtonPartClass::new(this.game.Data.RoadTypeObj[this.RoadNr].SheetSpriteID, tDescript: this.ss);
          this.txt1 = this.AddSubPart( tsubpart4, 10, 400, BitmapStore.GetWidth(this.game.Data.RoadTypeObj[this.RoadNr].SheetSpriteID), BitmapStore.Getheight(this.game.Data.RoadTypeObj[this.RoadNr].SheetSpriteID), 1);
        }
      }
    }

     void maketabsheetnr0b()
    {
      if (this.BBasicSpriteId > 0)
        this.RemoveSubPart(this.BBasicSpriteId);
      if (this.BChangeBasicSpriteId > 0)
        this.RemoveSubPart(this.BChangeBasicSpriteId);
      if (this.B5Id > 0)
        this.RemoveSubPart(this.B5Id);
      if (this.B5TextId > 0)
        this.RemoveSubPart(this.B5TextId);
      if (this.B4Id > 0)
        this.RemoveSubPart(this.B4Id);
      if (this.B4TextId > 0)
        this.RemoveSubPart(this.B4TextId);
      if (this.B7Id > 0)
        this.RemoveSubPart(this.B7Id);
      if (this.B7TextId > 0)
        this.RemoveSubPart(this.B7TextId);
      this.ss = "Click to change the sprite to another graphic";
      let mut tsubpart1: SubPartClass =  ButtonPartClass::new(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[this.DetailNr], tDescript: this.ss);
      this.BBasicSpriteId = this.AddSubPart( tsubpart1, 400, 350, 64, 48, 0);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        let mut tsubpart2: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BChangeBasicSpriteId = this.AddSubPart( tsubpart2, 400, 410, 32, 16, 1);
      }
      if (this.game.Data.Product < 7)
        return;
      this.ss = "";
      let mut tsubpart3: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.B4Id = this.AddSubPart( tsubpart3, 410, 610, 32, 16, 1);
      let mut tsubpart4: SubPartClass =  TextPartClass::new("Center6use=" + Conversion.Str((object) this.game.Data.RoadTypeObj[this.RoadNr].useCenter6), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B4TextId = this.AddSubPart( tsubpart4, 450, 609, 400, 20, 0);
      tsubpart4 =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.B5Id = this.AddSubPart( tsubpart4, 410, 630, 32, 16, 1);
      tsubpart4 =  TextPartClass::new("Center6sprite=" + this.game.Data.RoadTypeObj[this.RoadNr].center6spriteFileName, Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B5TextId = this.AddSubPart( tsubpart4, 450, 629, 400, 20, 0);
      tsubpart4 =  ButtonPartClass::new(this.game.BUTTONBLUE, tDescript: this.ss);
      this.B7Id = this.AddSubPart( tsubpart4, 410, 650, 32, 16, 1);
      tsubpart4 =  TextPartClass::new("Render to 64 sheet", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B7TextId = this.AddSubPart( tsubpart4, 450, 649, 400, 20, 0);
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
        this.BasicList2Obj.add(this.game.Data.TempString[index] + "(" + Conversion.Str((object) index) + ") = " + Conversion.Str((object) this.game.Data.RoadTypeObj[this.RoadNr].MoveCostOverrule[index]) + "ap", index);
        index += 1;
      }
      while (index <= 99);
      ListClass basicList2Obj = this.BasicList2Obj;
      let mut detailNr: i32 = this.DetailNr;
      let mut game: GameClass = this.game;
       Bitmap local1 =  this.OwnBitmap;
      Font font =  null;
       Font local2 =  font;
      let mut tsubpart: SubPartClass =  new ListSubPartClass(basicList2Obj, 10, 300, detailNr, game, tHeader: "MoveCost for MoveTypes", tbackbitmap: ( local1), bbx: 10, bby: 350, overruleFont: ( local2));
      this.BasicList2Id = this.AddSubPart( tsubpart, 10, 350, 300, 208, 0);
      if (this.DetailNr > 99)
        this.DetailNr = -1;
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr1b();
    }

     void maketabsheetnr1b()
    {
      this.ss = "Click to change move cost for selected movetype in AP";
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      let mut tsubpart: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.ChangeMvId = this.AddSubPart( tsubpart, 400, 410, 32, 16, 1);
    }

     void maketabsheetnr2()
    {
      this.ss = "Click to set the thickness in pixel of the line used to draw road on str.map.";
      SubPartClass tsubpart;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.bthick = this.AddSubPart( tsubpart, 10, 370, 32, 16, 1);
      }
      tsubpart =  TextPartClass::new("Thickness=" + Conversion.Str((object) this.game.Data.RoadTypeObj[this.RoadNr].Thickness), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.bthicktext = this.AddSubPart( tsubpart, 50, 369, 400, 20, 0);
      this.ss = "Click to set that first this roadtype is drawn as another roadtype. -1= do not use.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.bother = this.AddSubPart( tsubpart, 10, 390, 32, 16, 1);
      }
      tsubpart =  TextPartClass::new("FirstOtherRoad=" + Conversion.Str((object) this.game.Data.RoadTypeObj[this.RoadNr].FirstDrawOther), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.bothertext = this.AddSubPart( tsubpart, 50, 389, 400, 20, 0);
      this.ss = "-1= do not use. Roadtypes that have the same category will flow into eachother with hex rendering.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B3Id = this.AddSubPart( tsubpart, 10, 410, 32, 16, 1);
      }
      tsubpart =  TextPartClass::new("Category=" + Conversion.Str((object) this.game.Data.RoadTypeObj[this.RoadNr].Category), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B3TextId = this.AddSubPart( tsubpart, 50, 409, 400, 20, 0);
      this.ss = "0= do not use. ";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B6Id = this.AddSubPart( tsubpart, 10, 430, 32, 16, 1);
      }
      tsubpart =  TextPartClass::new("Traffic Points=" + Conversion.Str((object) this.game.Data.RoadTypeObj[this.RoadNr].trafficPoints), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B6TextId = this.AddSubPart( tsubpart, 50, 429, 400, 20, 0);
      this.ss = "if set to TRUE the sprites defined below will be used to render the bridge, instead of those specified in the bridge tab.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BridgeId = this.AddSubPart( tsubpart, 10, 470, 32, 16, 1);
      }
      tsubpart =  TextPartClass::new("Overrule Bridge Gfx =" + Conversion.Str((object) this.game.Data.RoadTypeObj[this.RoadNr].BridgeOverrule), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.BridgeTextId = this.AddSubPart( tsubpart, 50, 469, 400, 20, 0);
      this.BridgeListObj = ListClass::new();
      let mut tdata: i32 = 0;
      do
      {
        this.BridgeListObj.add(this.game.Data.RoadTypeObj[this.RoadNr].BridgeOverruleSpriteFileName[tdata], tdata);
        tdata += 1;
      }
      while (tdata <= 5);
      ListClass bridgeListObj = this.BridgeListObj;
      let mut bridgeNr: i32 = this.BridgeNr;
      let mut game: GameClass = this.game;
       Bitmap local1 =  this.OwnBitmap;
      Font font =  null;
       Font local2 =  font;
      tsubpart =  new ListSubPartClass(bridgeListObj, 7, 400, bridgeNr, game, tHeader: "Sprites", tbackbitmap: ( local1), bbx: 10, bby: 550, overruleFont: ( local2));
      this.BridgeListId = this.AddSubPart( tsubpart, 10, 550, 400, 160, 0);
      if (this.BridgeNr > 5)
        this.BridgeNr = -1;
      if (this.BridgeNr <= -1)
        return;
      this.maketabsheetnr2b();
    }

     void maketabsheetnr2b()
    {
      if (this.BBridgeSpriteId > 0)
        this.RemoveSubPart(this.BBridgeSpriteId);
      if (this.BChangeBridgeSpriteId > 0)
        this.RemoveSubPart(this.BChangeBridgeSpriteId);
      if (this.BChangeBridgeSpriteId2 > 0)
        this.RemoveSubPart(this.BChangeBridgeSpriteId2);
      this.ss = "Click to change the sprite to another graphic";
      let mut tsubpart1: SubPartClass =  ButtonPartClass::new(this.game.Data.RoadTypeObj[this.RoadNr].BridgeOverruleSpriteID[this.BridgeNr], tDescript: this.ss);
      this.BBridgeSpriteId = this.AddSubPart( tsubpart1, 500, 450, 64, 48, 0);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        let mut tsubpart2: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BChangeBridgeSpriteId = this.AddSubPart( tsubpart2, 500, 510, 32, 16, 1);
      }
      this.ss = "Import settings from another roadType";
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      let mut tsubpart3: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLUE, tDescript: this.ss);
      this.BChangeBridgeSpriteId2 = this.AddSubPart( tsubpart3, 500, 610, 32, 16, 1);
    }

    pub void ConstructTileset(string s)
    {
      string[] strArray = new string[65];
      Bitmap bitmap1 = new Bitmap(384, 528);
      bitmap1.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics1 = Graphics.FromImage((Image) bitmap1);
      graphics1.Clear(Color.Transparent);
      graphics1.CompositingMode = CompositingMode.SourceOver;
      let mut num1: i32 = 64;
      let mut num2: i32 = 48;
      let mut index1: i32 = 0;
      int num3;
      do
      {
        let mut index2: i32 = 0;
        do
        {
          let mut index3: i32 = 0;
          do
          {
            let mut index4: i32 = 0;
            do
            {
              let mut index5: i32 = 0;
              do
              {
                let mut index6: i32 = 0;
                do
                {
                  let mut num4: i32 = 0;
                  let mut index7: i32 = this.game.SPRITE64[index1, index2, index3, index4, index5, index6];
                  if (index1 > 0 | index2 > 0 | index3 > 0 | index4 > 0 | index5 > 0 | index6 > 0)
                    graphics1.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].center6spriteId), this.game.SHEETX[index7] * num1, this.game.SHEETY[index7] * num2);
                  if (index1 == 1)
                  {
                    graphics1.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[0]), this.game.SHEETX[index7] * num1, this.game.SHEETY[index7] * num2);
                    num4 += 1;
                  }
                  if (index2 == 1)
                  {
                    graphics1.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[1]), this.game.SHEETX[index7] * num1, this.game.SHEETY[index7] * num2);
                    num4 += 1;
                  }
                  if (index3 == 1)
                  {
                    graphics1.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[2]), this.game.SHEETX[index7] * num1, this.game.SHEETY[index7] * num2);
                    num4 += 1;
                  }
                  if (index4 == 1)
                  {
                    graphics1.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[3]), this.game.SHEETX[index7] * num1, this.game.SHEETY[index7] * num2);
                    num4 += 1;
                  }
                  if (index5 == 1)
                  {
                    graphics1.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[4]), this.game.SHEETX[index7] * num1, this.game.SHEETY[index7] * num2);
                    num4 += 1;
                  }
                  if (index6 == 1)
                  {
                    graphics1.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[5]), this.game.SHEETX[index7] * num1, this.game.SHEETY[index7] * num2);
                    num3 = num4 + 1;
                  }
                  index6 += 1;
                }
                while (index6 <= 1);
                index5 += 1;
              }
              while (index5 <= 1);
              index4 += 1;
            }
            while (index4 <= 1);
            index3 += 1;
          }
          while (index3 <= 1);
          index2 += 1;
        }
        while (index2 <= 1);
        index1 += 1;
      }
      while (index1 <= 1);
      FileStream fileStream1 = new FileStream(s, FileMode.Create);
      bitmap1.Save((Stream) fileStream1, ImageFormat.Png);
      fileStream1.Close();
      graphics1.Dispose();
      Bitmap bitmap2 = new Bitmap(768, 1056);
      bitmap2.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics2 = Graphics.FromImage((Image) bitmap2);
      graphics2.Clear(Color.Transparent);
      graphics2.CompositingMode = CompositingMode.SourceOver;
      let mut num5: i32 = 128;
      let mut num6: i32 = 96;
      let mut index8: i32 = 0;
      do
      {
        let mut index9: i32 = 0;
        do
        {
          let mut index10: i32 = 0;
          do
          {
            let mut index11: i32 = 0;
            do
            {
              let mut index12: i32 = 0;
              do
              {
                let mut index13: i32 = 0;
                do
                {
                  let mut num7: i32 = 0;
                  let mut index14: i32 = this.game.SPRITE64[index8, index9, index10, index11, index12, index13];
                  if (index8 > 0 | index9 > 0 | index10 > 0 | index11 > 0 | index12 > 0 | index13 > 0)
                    graphics2.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].center6spriteId, 1), this.game.SHEETX[index14] * num5, this.game.SHEETY[index14] * num6);
                  if (index8 == 1)
                  {
                    graphics2.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[0], 1), this.game.SHEETX[index14] * num5, this.game.SHEETY[index14] * num6);
                    num7 += 1;
                  }
                  if (index9 == 1)
                  {
                    graphics2.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[1], 1), this.game.SHEETX[index14] * num5, this.game.SHEETY[index14] * num6);
                    num7 += 1;
                  }
                  if (index10 == 1)
                  {
                    graphics2.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[2], 1), this.game.SHEETX[index14] * num5, this.game.SHEETY[index14] * num6);
                    num7 += 1;
                  }
                  if (index11 == 1)
                  {
                    graphics2.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[3], 1), this.game.SHEETX[index14] * num5, this.game.SHEETY[index14] * num6);
                    num7 += 1;
                  }
                  if (index12 == 1)
                  {
                    graphics2.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[4], 1), this.game.SHEETX[index14] * num5, this.game.SHEETY[index14] * num6);
                    num7 += 1;
                  }
                  if (index13 == 1)
                  {
                    graphics2.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[5], 1), this.game.SHEETX[index14] * num5, this.game.SHEETY[index14] * num6);
                    num3 = num7 + 1;
                  }
                  index13 += 1;
                }
                while (index13 <= 1);
                index12 += 1;
              }
              while (index12 <= 1);
              index11 += 1;
            }
            while (index11 <= 1);
            index10 += 1;
          }
          while (index10 <= 1);
          index9 += 1;
        }
        while (index9 <= 1);
        index8 += 1;
      }
      while (index8 <= 1);
      FileStream fileStream2 = new FileStream(s.Replace(".png", "_big.png"), FileMode.Create);
      bitmap2.Save((Stream) fileStream2, ImageFormat.Png);
      fileStream2.Close();
      graphics2.Dispose();
      bitmap2.Dispose();
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
            if (num1 == this.RoadListId)
            {
              let mut num2: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.RoadNr = num2;
                this.MakeRoadTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddRoadId)
            {
              this.game.Data.AddRoadType();
              this.MakeRoadListGUI(this.RoadNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BNameId)
            {
              this.game.Data.RoadTypeObj[this.RoadNr].Name = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest");
              this.MakeRoadListGUI(this.RoadNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsListId)
            {
              let mut num3: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num3 > -1)
              {
                this.TabSheetNr = num3;
                this.MakeRoadTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BRemoveRoadId)
            {
              this.game.Data.RemoveRoadType(this.RoadNr);
              this.MakeRoadListGUI(-1);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BasicListId)
            {
              let mut num4: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num4 > -1)
              {
                this.DetailNr = num4;
                this.maketabsheetnr0b();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BridgeListId)
            {
              let mut num5: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num5 > -1)
              {
                this.BridgeNr = num5;
                this.maketabsheetnr2b();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BasicList2Id)
            {
              let mut num6: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num6 > -1)
              {
                this.DetailNr = num6;
                this.maketabsheetnr1b();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeMvId)
            {
              let mut num7: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give new ap overrule please", "Shadow Empire : Planetary Conquest")));
              if (num7 > 0 & num7 <= 9999)
              {
                this.game.Data.RoadTypeObj[this.RoadNr].MoveCostOverrule[this.DetailNr] = num7;
              }
              else
              {
                let mut num8: i32 =  Interaction.MsgBox((object) "Value between 1 and 10000 please...", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BChangeBridgeSpriteId2)
            {
              str: String = Interaction.InputBox("Give roadtype slot # to copy ", "Shadow Empire : Planetary Conquest");
              let mut index2: i32 =  Math.Round(Conversion.Val(str));
              if (!Information.IsNothing((object) str) && str.Length > 0 & index2 >= 0 & index2 <= this.game.Data.RoadTypeCounter)
              {
                this.game.Data.RoadTypeObj[this.RoadNr].BridgeOverrule = this.game.Data.RoadTypeObj[index2].BridgeOverrule;
                let mut nr: i32 = 0;
                do
                {
                  if (Operators.CompareString(this.game.Data.RoadTypeObj[index2].BridgeOverruleSpriteFileName[nr], this.game.Data.RoadTypeObj[this.RoadNr].BridgeOverruleSpriteFileName[nr], false) != 0)
                    this.game.Data.RoadTypeObj[this.RoadNr].ReplaceBridgeOverruleSprite(nr, this.game.Data.RoadTypeObj[index2].BridgeOverruleSpriteFileName[nr]);
                  nr += 1;
                }
                while (nr <= 5);
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BChangeBasicSpriteId)
            {
              filename: String = this.game.HandyFunctionsObj.LoadSomething("Png (*.Png)|*.png|Bitmaps (*.bmp)|*.bmp", "Select File For Road Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.RoadTypeObj[this.RoadNr].ReplaceBasicSprite(this.DetailNr, filename);
              }
              else
              {
                let mut num9: i32 =  Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B5Id)
            {
              filename: String = this.game.HandyFunctionsObj.LoadSomething("Png (*.Png)|*.png|Bitmaps (*.bmp)|*.bmp", "Select File For center6 sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.RoadTypeObj[this.RoadNr].ReplaceCenter6(filename);
              }
              else
              {
                let mut num10: i32 =  Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B7Id)
            {
              this.ConstructTileset(this.game.HandyFunctionsObj.SaveSomething("Png|*.png", "Give savename for new tileset.", "", false));
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BChangeBridgeSpriteId)
            {
              filename: String = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select File For Road Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.RoadTypeObj[this.RoadNr].ReplaceBridgeOverruleSprite(this.BridgeNr, filename);
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
              this.game.EditObj.PencilType = 2;
              this.game.EditObj.PencilData1 = this.RoadNr;
              windowReturnClass.AddCommand(1, 13);
              windowReturnClass.AddCommand(2, 13);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B2Id)
            {
              this.game.Data.RoadTypeObj[this.RoadNr].Transparent = !this.game.Data.RoadTypeObj[this.RoadNr].Transparent;
              this.MakeRoadTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BridgeId)
            {
              this.game.Data.RoadTypeObj[this.RoadNr].BridgeOverrule = !this.game.Data.RoadTypeObj[this.RoadNr].BridgeOverrule;
              this.MakeRoadTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B4Id)
            {
              this.game.Data.RoadTypeObj[this.RoadNr].useCenter6 = !this.game.Data.RoadTypeObj[this.RoadNr].useCenter6;
              this.MakeRoadTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BEP)
            {
              let mut num12: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("TYPE: Give new EP cost", "Shadow Empire : Planetary Conquest")));
              if (num12 > -1 & num12 < 999999)
                this.game.Data.RoadTypeObj[this.RoadNr].EPCost = num12;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B6Id)
            {
              let mut num13: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give new Traffic Points", "Shadow Empire : Planetary Conquest")));
              if (num13 > -1 & num13 < 999999)
                this.game.Data.RoadTypeObj[this.RoadNr].trafficPoints = num13;
              this.MakeRoadTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B3Id)
            {
              let mut num14: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give road category# (-1=none)", "Shadow Empire : Planetary Conquest")));
              if (num14 >= -1 & num14 < 999999)
                this.game.Data.RoadTypeObj[this.RoadNr].Category = num14;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.bthick)
            {
              let mut num15: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give new pixel thickness", "Shadow Empire : Planetary Conquest")));
              if (num15 > 0 & num15 < 10)
                this.game.Data.RoadTypeObj[this.RoadNr].Thickness = num15;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.bother)
            {
              let mut num16: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give first draw other road nr#. -1=dont use", "Shadow Empire : Planetary Conquest")));
              if (num16 >= -1 & num16 <= this.game.Data.RoadTypeCounter)
                this.game.Data.RoadTypeObj[this.RoadNr].FirstDrawOther = num16;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b1id)
            {
              this.game.Data.RoadTypeObj[this.RoadNr].SpecialLayer = !this.game.Data.RoadTypeObj[this.RoadNr].SpecialLayer;
              if (!this.game.Data.RoadTypeObj[this.RoadNr].SpecialLayer)
              {
                this.game.Data.RoadTypeObj[this.RoadNr].UseSheet = false;
                this.game.Data.RoadTypeObj[this.RoadNr].SheetFileName = "systemgraphics/trans.bmp";
              }
              if (this.game.Data.RoadTypeObj[this.RoadNr].SpecialLayer)
              {
                if (Interaction.MsgBox((object) "Use Fred SpriteSheet?", MsgBoxStyle.YesNo) == MsgBoxResult.No)
                  this.game.Data.RoadTypeObj[this.RoadNr].UseSheet = false;
                else
                  this.game.Data.RoadTypeObj[this.RoadNr].UseSheet = true;
                if (!this.game.Data.RoadTypeObj[this.RoadNr].UseSheet)
                {
                  extstring: String = Interaction.InputBox("Give a graphical extension: .jpg, .png, .bmp");
                  dirstring: String = Interaction.InputBox("Give a directory name under the graphics directory", "Shadow Empire : Planetary Conquest");
                  if (File.Exists(this.game.AppPath + "graphics/" + dirstring + "/a1" + extstring))
                  {
                    this.game.Data.RoadTypeObj[this.RoadNr].AutoLoadSpecial(dirstring, extstring);
                    this.maketabsheet();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  this.game.Data.RoadTypeObj[this.RoadNr].SpecialLayer = false;
                  let mut num17: i32 =  Interaction.MsgBox((object) "Could not find this dir... give it like 'sea' or 'africa/desert', make sure a1 is present.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                {
                  filename: String = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select normal sized sheet (big & small will be auto-linked)", this.game.AppPath + "graphics\\", true);
                  if (File.Exists(this.game.AppPath + "graphics/" + filename))
                  {
                    this.game.Data.RoadTypeObj[this.RoadNr].ReplaceSpriteSheet(filename);
                    this.maketabsheet();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  let mut num18: i32 =  Interaction.MsgBox((object) "Could not find this file... ", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
              }
              this.maketabsheet();
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
