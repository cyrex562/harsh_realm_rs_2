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
  public class RoadTypeWindowClass : WindowClass
  {
    private int RoadListId;
    private ListClass RoadListObj;
    private int BAddRoadId;
    private int BAddRoadTextId;
    private int BNameId;
    private int BNameTextId;
    private int B2Id;
    private int B2TextId;
    private int B3Id;
    private int B3TextId;
    private int B4Id;
    private int B4TextId;
    private int B5Id;
    private int B5TextId;
    private int B6Id;
    private int B6TextId;
    private int B7Id;
    private int B7TextId;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int BRemoveRoadId;
    private int BRemoveRoadTextId;
    private int BDrawId;
    private int BDrawTextId;
    private ListClass BasicListObj;
    private int BasicListId;
    private int b1id;
    private int b1textid;
    private int BBasicSpriteId;
    private int BChangeBasicSpriteId;
    private ListClass BasicList2Obj;
    private int BasicList2Id;
    private int ChangeMvId;
    private int[] Bitemid;
    private int[] bitemtextid;
    private int BEP;
    private int BEPText;
    private int txt1;
    private int bthick;
    private int bthicktext;
    private int bother;
    private int bothertext;
    private int BridgeId;
    private int BridgeTextId;
    private ListClass BridgeListObj;
    private int BridgeListId;
    private int BBridgeSpriteId;
    private int BChangeBridgeSpriteId;
    private int BChangeBridgeSpriteId2;
    private int RoadNr;
    private int TabSheetNr;
    private int DetailNr;
    private int BridgeNr;
    private string ss;

    public RoadTypeWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Road Types")
    {
      this.Bitemid = new int[5];
      this.bitemtextid = new int[5];
      this.RoadNr = -1;
      this.TabSheetNr = -1;
      this.DetailNr = -1;
      this.BridgeNr = -1;
      this.MakeRoadListGUI(-1);
    }

    public override void DoRefresh() => this.MakeRoadTypeItemGUI();

    private void MakeRoadListGUI(int tRoadnr)
    {
      if (this.RoadListId > 0)
        this.RemoveSubPart(this.RoadListId);
      SubPartClass tsubpart;
      if (this.game.Data.RoadTypeCounter > -1)
      {
        this.RoadListObj = new ListClass();
        int roadTypeCounter = this.game.Data.RoadTypeCounter;
        for (int index = 0; index <= roadTypeCounter; ++index)
          this.RoadListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.RoadTypeObj[index].Name, index);
        ListClass roadListObj = this.RoadListObj;
        int tlistselect = tRoadnr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        tsubpart = (SubPartClass) new ListSubPartClass(roadListObj, 9, 200, tlistselect, game, tHeader: "Road Types", tbackbitmap: (ref local1), bbx: 10, bby: 50, overruleFont: (ref local2));
        this.RoadListId = this.AddSubPart(ref tsubpart, 10, 50, 200, 192, 0);
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
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.BAddRoadId = this.AddSubPart(ref tsubpart, 10, 270, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      tsubpart = (SubPartClass) new TextPartClass("Add Road Type", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BAddRoadTextId = this.AddSubPart(ref tsubpart, 50, 269, 300, 20, 0);
    }

    private void MakeRoadTypeItemGUI()
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
      int index = 0;
      do
      {
        if (this.Bitemid[index] > 0)
          this.RemoveSubPart(this.Bitemid[index]);
        if (this.bitemtextid[index] > 0)
          this.RemoveSubPart(this.bitemtextid[index]);
        ++index;
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
          SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.BNameId = this.AddSubPart(ref tsubpart, 370, 50, 32, 16, 1);
        }
        SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Name: " + this.game.Data.RoadTypeObj[this.RoadNr].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.BNameTextId = this.AddSubPart(ref tsubpart1, 410, 49, 400, 20, 0);
        this.ss = "Click to set transparent settings (works well in combi with overlay map)";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.B2Id = this.AddSubPart(ref tsubpart2, 370, 70, 32, 16, 1);
        }
        SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("Transparent: " + Conversion.Str((object) this.game.Data.RoadTypeObj[this.RoadNr].Transparent), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B2TextId = this.AddSubPart(ref tsubpart3, 410, 69, 400, 20, 0);
        this.ss = "Click to remove this roadtype";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
          this.BRemoveRoadId = this.AddSubPart(ref tsubpart3, 10, 290, 32, 16, 1);
        }
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart3 = (SubPartClass) new TextPartClass("Remove this RoadType", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.BRemoveRoadTextId = this.AddSubPart(ref tsubpart3, 50, 289, 200, 20, 0);
        }
        this.ss = "Click to use this road type for drawing on the map";
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONDRAW, tDescript: this.ss);
        this.BDrawId = this.AddSubPart(ref tsubpart3, 10, 310, 32, 16, 1);
        tsubpart3 = (SubPartClass) new TextPartClass("Select as pencil", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BDrawTextId = this.AddSubPart(ref tsubpart3, 50, 309, 200, 20, 0);
        this.OptionsListObj = new ListClass();
        this.OptionsListObj.add("Sprites", 0);
        this.OptionsListObj.add("Movecost for Road", 1);
        this.OptionsListObj.add("Details", 2);
        ListClass optionsListObj = this.OptionsListObj;
        int tabSheetNr = this.TabSheetNr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        tsubpart3 = (SubPartClass) new ListSubPartClass(optionsListObj, 4, 300, tabSheetNr, game, tHeader: "Property Sheets", tbackbitmap: (ref local1), bbx: 370, bby: 140, overruleFont: (ref local2));
        this.OptionsListId = this.AddSubPart(ref tsubpart3, 370, 140, 300, 112, 0);
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

    private void maketabsheetnr0()
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
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
        this.b1id = this.AddSubPart(ref tsubpart, 500, 350, 32, 16, 1);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass(txt1, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.b1textid = this.AddSubPart(ref tsubpart1, 550, 349, 400, 20, 0);
      if (this.txt1 > 0)
        this.RemoveSubPart(this.txt1);
      if (!this.game.Data.RoadTypeObj[this.RoadNr].SpecialLayer)
      {
        this.BasicListObj = new ListClass();
        int tdata = 0;
        do
        {
          this.BasicListObj.add(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteFileName[tdata], tdata);
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
        string txt2 = "Currently using a set of 64 sprites.";
        if (!this.game.Data.RoadTypeObj[this.RoadNr].UseSheet)
        {
          SubPartClass tsubpart3 = (SubPartClass) new TextPartClass(txt2, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 250, 20, false, tDescript: this.ss);
          this.txt1 = this.AddSubPart(ref tsubpart3, 10, 398, 250, 20, 1);
        }
        else
        {
          this.ss = "the fred sheet you are currently using. filename = " + this.game.Data.RoadTypeObj[this.RoadNr].SheetFileName;
          SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.Data.RoadTypeObj[this.RoadNr].SheetSpriteID, tDescript: this.ss);
          this.txt1 = this.AddSubPart(ref tsubpart4, 10, 400, BitmapStore.GetWidth(this.game.Data.RoadTypeObj[this.RoadNr].SheetSpriteID), BitmapStore.Getheight(this.game.Data.RoadTypeObj[this.RoadNr].SheetSpriteID), 1);
        }
      }
    }

    private void maketabsheetnr0b()
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
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[this.DetailNr], tDescript: this.ss);
      this.BBasicSpriteId = this.AddSubPart(ref tsubpart1, 400, 350, 64, 48, 0);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BChangeBasicSpriteId = this.AddSubPart(ref tsubpart2, 400, 410, 32, 16, 1);
      }
      if (this.game.Data.Product < 7)
        return;
      this.ss = "";
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.B4Id = this.AddSubPart(ref tsubpart3, 410, 610, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Center6use=" + Conversion.Str((object) this.game.Data.RoadTypeObj[this.RoadNr].useCenter6), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B4TextId = this.AddSubPart(ref tsubpart4, 450, 609, 400, 20, 0);
      tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.B5Id = this.AddSubPart(ref tsubpart4, 410, 630, 32, 16, 1);
      tsubpart4 = (SubPartClass) new TextPartClass("Center6sprite=" + this.game.Data.RoadTypeObj[this.RoadNr].center6spriteFileName, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B5TextId = this.AddSubPart(ref tsubpart4, 450, 629, 400, 20, 0);
      tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.B7Id = this.AddSubPart(ref tsubpart4, 410, 650, 32, 16, 1);
      tsubpart4 = (SubPartClass) new TextPartClass("Render to 64 sheet", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B7TextId = this.AddSubPart(ref tsubpart4, 450, 649, 400, 20, 0);
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
        this.BasicList2Obj.add(this.game.Data.TempString[index] + "(" + Conversion.Str((object) index) + ") = " + Conversion.Str((object) this.game.Data.RoadTypeObj[this.RoadNr].MoveCostOverrule[index]) + "ap", index);
        ++index;
      }
      while (index <= 99);
      ListClass basicList2Obj = this.BasicList2Obj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(basicList2Obj, 10, 300, detailNr, game, tHeader: "MoveCost for MoveTypes", tbackbitmap: (ref local1), bbx: 10, bby: 350, overruleFont: (ref local2));
      this.BasicList2Id = this.AddSubPart(ref tsubpart, 10, 350, 300, 208, 0);
      if (this.DetailNr > 99)
        this.DetailNr = -1;
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr1b();
    }

    private void maketabsheetnr1b()
    {
      this.ss = "Click to change move cost for selected movetype in AP";
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.ChangeMvId = this.AddSubPart(ref tsubpart, 400, 410, 32, 16, 1);
    }

    private void maketabsheetnr2()
    {
      this.ss = "Click to set the thickness in pixel of the line used to draw road on str.map.";
      SubPartClass tsubpart;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.bthick = this.AddSubPart(ref tsubpart, 10, 370, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("Thickness=" + Conversion.Str((object) this.game.Data.RoadTypeObj[this.RoadNr].Thickness), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.bthicktext = this.AddSubPart(ref tsubpart, 50, 369, 400, 20, 0);
      this.ss = "Click to set that first this roadtype is drawn as another roadtype. -1= do not use.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.bother = this.AddSubPart(ref tsubpart, 10, 390, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("FirstOtherRoad=" + Conversion.Str((object) this.game.Data.RoadTypeObj[this.RoadNr].FirstDrawOther), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.bothertext = this.AddSubPart(ref tsubpart, 50, 389, 400, 20, 0);
      this.ss = "-1= do not use. Roadtypes that have the same category will flow into eachother with hex rendering.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B3Id = this.AddSubPart(ref tsubpart, 10, 410, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("Category=" + Conversion.Str((object) this.game.Data.RoadTypeObj[this.RoadNr].Category), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B3TextId = this.AddSubPart(ref tsubpart, 50, 409, 400, 20, 0);
      this.ss = "0= do not use. ";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B6Id = this.AddSubPart(ref tsubpart, 10, 430, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("Traffic Points=" + Conversion.Str((object) this.game.Data.RoadTypeObj[this.RoadNr].trafficPoints), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B6TextId = this.AddSubPart(ref tsubpart, 50, 429, 400, 20, 0);
      this.ss = "if set to TRUE the sprites defined below will be used to render the bridge, instead of those specified in the bridge tab.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BridgeId = this.AddSubPart(ref tsubpart, 10, 470, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("Overrule Bridge Gfx =" + Conversion.Str((object) this.game.Data.RoadTypeObj[this.RoadNr].BridgeOverrule), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.BridgeTextId = this.AddSubPart(ref tsubpart, 50, 469, 400, 20, 0);
      this.BridgeListObj = new ListClass();
      int tdata = 0;
      do
      {
        this.BridgeListObj.add(this.game.Data.RoadTypeObj[this.RoadNr].BridgeOverruleSpriteFileName[tdata], tdata);
        ++tdata;
      }
      while (tdata <= 5);
      ListClass bridgeListObj = this.BridgeListObj;
      int bridgeNr = this.BridgeNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      tsubpart = (SubPartClass) new ListSubPartClass(bridgeListObj, 7, 400, bridgeNr, game, tHeader: "Sprites", tbackbitmap: (ref local1), bbx: 10, bby: 550, overruleFont: (ref local2));
      this.BridgeListId = this.AddSubPart(ref tsubpart, 10, 550, 400, 160, 0);
      if (this.BridgeNr > 5)
        this.BridgeNr = -1;
      if (this.BridgeNr <= -1)
        return;
      this.maketabsheetnr2b();
    }

    private void maketabsheetnr2b()
    {
      if (this.BBridgeSpriteId > 0)
        this.RemoveSubPart(this.BBridgeSpriteId);
      if (this.BChangeBridgeSpriteId > 0)
        this.RemoveSubPart(this.BChangeBridgeSpriteId);
      if (this.BChangeBridgeSpriteId2 > 0)
        this.RemoveSubPart(this.BChangeBridgeSpriteId2);
      this.ss = "Click to change the sprite to another graphic";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.Data.RoadTypeObj[this.RoadNr].BridgeOverruleSpriteID[this.BridgeNr], tDescript: this.ss);
      this.BBridgeSpriteId = this.AddSubPart(ref tsubpart1, 500, 450, 64, 48, 0);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BChangeBridgeSpriteId = this.AddSubPart(ref tsubpart2, 500, 510, 32, 16, 1);
      }
      this.ss = "Import settings from another roadType";
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.BChangeBridgeSpriteId2 = this.AddSubPart(ref tsubpart3, 500, 610, 32, 16, 1);
    }

    public void ConstructTileset(string s)
    {
      string[] strArray = new string[65];
      Bitmap bitmap1 = new Bitmap(384, 528);
      bitmap1.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics1 = Graphics.FromImage((Image) bitmap1);
      graphics1.Clear(Color.Transparent);
      graphics1.CompositingMode = CompositingMode.SourceOver;
      int num1 = 64;
      int num2 = 48;
      int index1 = 0;
      int num3;
      do
      {
        int index2 = 0;
        do
        {
          int index3 = 0;
          do
          {
            int index4 = 0;
            do
            {
              int index5 = 0;
              do
              {
                int index6 = 0;
                do
                {
                  int num4 = 0;
                  int index7 = this.game.SPRITE64[index1, index2, index3, index4, index5, index6];
                  if (index1 > 0 | index2 > 0 | index3 > 0 | index4 > 0 | index5 > 0 | index6 > 0)
                    graphics1.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].center6spriteId), this.game.SHEETX[index7] * num1, this.game.SHEETY[index7] * num2);
                  if (index1 == 1)
                  {
                    graphics1.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[0]), this.game.SHEETX[index7] * num1, this.game.SHEETY[index7] * num2);
                    ++num4;
                  }
                  if (index2 == 1)
                  {
                    graphics1.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[1]), this.game.SHEETX[index7] * num1, this.game.SHEETY[index7] * num2);
                    ++num4;
                  }
                  if (index3 == 1)
                  {
                    graphics1.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[2]), this.game.SHEETX[index7] * num1, this.game.SHEETY[index7] * num2);
                    ++num4;
                  }
                  if (index4 == 1)
                  {
                    graphics1.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[3]), this.game.SHEETX[index7] * num1, this.game.SHEETY[index7] * num2);
                    ++num4;
                  }
                  if (index5 == 1)
                  {
                    graphics1.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[4]), this.game.SHEETX[index7] * num1, this.game.SHEETY[index7] * num2);
                    ++num4;
                  }
                  if (index6 == 1)
                  {
                    graphics1.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[5]), this.game.SHEETX[index7] * num1, this.game.SHEETY[index7] * num2);
                    num3 = num4 + 1;
                  }
                  ++index6;
                }
                while (index6 <= 1);
                ++index5;
              }
              while (index5 <= 1);
              ++index4;
            }
            while (index4 <= 1);
            ++index3;
          }
          while (index3 <= 1);
          ++index2;
        }
        while (index2 <= 1);
        ++index1;
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
      int num5 = 128;
      int num6 = 96;
      int index8 = 0;
      do
      {
        int index9 = 0;
        do
        {
          int index10 = 0;
          do
          {
            int index11 = 0;
            do
            {
              int index12 = 0;
              do
              {
                int index13 = 0;
                do
                {
                  int num7 = 0;
                  int index14 = this.game.SPRITE64[index8, index9, index10, index11, index12, index13];
                  if (index8 > 0 | index9 > 0 | index10 > 0 | index11 > 0 | index12 > 0 | index13 > 0)
                    graphics2.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].center6spriteId, 1), this.game.SHEETX[index14] * num5, this.game.SHEETY[index14] * num6);
                  if (index8 == 1)
                  {
                    graphics2.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[0], 1), this.game.SHEETX[index14] * num5, this.game.SHEETY[index14] * num6);
                    ++num7;
                  }
                  if (index9 == 1)
                  {
                    graphics2.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[1], 1), this.game.SHEETX[index14] * num5, this.game.SHEETY[index14] * num6);
                    ++num7;
                  }
                  if (index10 == 1)
                  {
                    graphics2.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[2], 1), this.game.SHEETX[index14] * num5, this.game.SHEETY[index14] * num6);
                    ++num7;
                  }
                  if (index11 == 1)
                  {
                    graphics2.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[3], 1), this.game.SHEETX[index14] * num5, this.game.SHEETY[index14] * num6);
                    ++num7;
                  }
                  if (index12 == 1)
                  {
                    graphics2.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[4], 1), this.game.SHEETX[index14] * num5, this.game.SHEETY[index14] * num6);
                    ++num7;
                  }
                  if (index13 == 1)
                  {
                    graphics2.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.RoadTypeObj[this.RoadNr].BasicSpriteID[5], 1), this.game.SHEETX[index14] * num5, this.game.SHEETY[index14] * num6);
                    num3 = num7 + 1;
                  }
                  ++index13;
                }
                while (index13 <= 1);
                ++index12;
              }
              while (index12 <= 1);
              ++index11;
            }
            while (index11 <= 1);
            ++index10;
          }
          while (index10 <= 1);
          ++index9;
        }
        while (index9 <= 1);
        ++index8;
      }
      while (index8 <= 1);
      FileStream fileStream2 = new FileStream(s.Replace(".png", "_big.png"), FileMode.Create);
      bitmap2.Save((Stream) fileStream2, ImageFormat.Png);
      fileStream2.Close();
      graphics2.Dispose();
      bitmap2.Dispose();
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
            if (num1 == this.RoadListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
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
              int num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
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
              int num4 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
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
              int num5 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
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
              int num6 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
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
              int num7 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new ap overrule please", "Shadow Empire : Planetary Conquest")));
              if (num7 > 0 & num7 <= 9999)
              {
                this.game.Data.RoadTypeObj[this.RoadNr].MoveCostOverrule[this.DetailNr] = num7;
              }
              else
              {
                int num8 = (int) Interaction.MsgBox((object) "Value between 1 and 10000 please...", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BChangeBridgeSpriteId2)
            {
              string str = Interaction.InputBox("Give roadtype slot # to copy ", "Shadow Empire : Planetary Conquest");
              int index2 = (int) Math.Round(Conversion.Val(str));
              if (!Information.IsNothing((object) str) && str.Length > 0 & index2 >= 0 & index2 <= this.game.Data.RoadTypeCounter)
              {
                this.game.Data.RoadTypeObj[this.RoadNr].BridgeOverrule = this.game.Data.RoadTypeObj[index2].BridgeOverrule;
                int nr = 0;
                do
                {
                  if (Operators.CompareString(this.game.Data.RoadTypeObj[index2].BridgeOverruleSpriteFileName[nr], this.game.Data.RoadTypeObj[this.RoadNr].BridgeOverruleSpriteFileName[nr], false) != 0)
                    this.game.Data.RoadTypeObj[this.RoadNr].ReplaceBridgeOverruleSprite(nr, this.game.Data.RoadTypeObj[index2].BridgeOverruleSpriteFileName[nr]);
                  ++nr;
                }
                while (nr <= 5);
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BChangeBasicSpriteId)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png (*.Png)|*.png|Bitmaps (*.bmp)|*.bmp", "Select File For Road Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.RoadTypeObj[this.RoadNr].ReplaceBasicSprite(this.DetailNr, filename);
              }
              else
              {
                int num9 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B5Id)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png (*.Png)|*.png|Bitmaps (*.bmp)|*.bmp", "Select File For center6 sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.RoadTypeObj[this.RoadNr].ReplaceCenter6(filename);
              }
              else
              {
                int num10 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select File For Road Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.RoadTypeObj[this.RoadNr].ReplaceBridgeOverruleSprite(this.BridgeNr, filename);
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
              int num12 = (int) Math.Round(Conversion.Val(Interaction.InputBox("TYPE: Give new EP cost", "Shadow Empire : Planetary Conquest")));
              if (num12 > -1 & num12 < 999999)
                this.game.Data.RoadTypeObj[this.RoadNr].EPCost = num12;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B6Id)
            {
              int num13 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new Traffic Points", "Shadow Empire : Planetary Conquest")));
              if (num13 > -1 & num13 < 999999)
                this.game.Data.RoadTypeObj[this.RoadNr].trafficPoints = num13;
              this.MakeRoadTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B3Id)
            {
              int num14 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give road category# (-1=none)", "Shadow Empire : Planetary Conquest")));
              if (num14 >= -1 & num14 < 999999)
                this.game.Data.RoadTypeObj[this.RoadNr].Category = num14;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.bthick)
            {
              int num15 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new pixel thickness", "Shadow Empire : Planetary Conquest")));
              if (num15 > 0 & num15 < 10)
                this.game.Data.RoadTypeObj[this.RoadNr].Thickness = num15;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.bother)
            {
              int num16 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give first draw other road nr#. -1=dont use", "Shadow Empire : Planetary Conquest")));
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
                  string extstring = Interaction.InputBox("Give a graphical extension: .jpg, .png, .bmp");
                  string dirstring = Interaction.InputBox("Give a directory name under the graphics directory", "Shadow Empire : Planetary Conquest");
                  if (File.Exists(this.game.AppPath + "graphics/" + dirstring + "/a1" + extstring))
                  {
                    this.game.Data.RoadTypeObj[this.RoadNr].AutoLoadSpecial(dirstring, extstring);
                    this.maketabsheet();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  this.game.Data.RoadTypeObj[this.RoadNr].SpecialLayer = false;
                  int num17 = (int) Interaction.MsgBox((object) "Could not find this dir... give it like 'sea' or 'africa/desert', make sure a1 is present.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                {
                  string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select normal sized sheet (big & small will be auto-linked)", this.game.AppPath + "graphics\\", true);
                  if (File.Exists(this.game.AppPath + "graphics/" + filename))
                  {
                    this.game.Data.RoadTypeObj[this.RoadNr].ReplaceSpriteSheet(filename);
                    this.maketabsheet();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  int num18 = (int) Interaction.MsgBox((object) "Could not find this file... ", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
