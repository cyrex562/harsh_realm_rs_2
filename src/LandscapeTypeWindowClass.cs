// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.LandscapeTypeWindowClass
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
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class LandscapeTypeWindowClass : WindowClass
  {
    private int LTListId;
    private ListClass LTListObj;
    private int BAddLTId;
    private int BAddLTTextId;
    private int BCloneLTId;
    private int BCloneLTTextId;
    private int BNameId;
    private int BNameTextId;
    private int TxtId;
    private int TxtStrId;
    private int BSLId;
    private int BSLTextId;
    private int BSL2Id;
    private int BSL2TextId;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int BRemoveLtId;
    private int BRemoveLtTextId;
    private int BBuildRoadId;
    private int BBuildRoadTextId;
    private int e1id;
    private int e1textid;
    private int e2id;
    private int e2textid;
    private int e3id;
    private int e3textid;
    private int e4id;
    private int e4textid;
    private int e5id;
    private int e5textid;
    private int e6id;
    private int e6textid;
    private int e7id;
    private int e7textid;
    private int e7bid;
    private int e7btextid;
    private int e8id;
    private int e8textid;
    private int e9id;
    private int e9textid;
    private int e10id;
    private int e10textid;
    private int e11id;
    private int e11textid;
    private int e12id;
    private int e12textid;
    private int e13id;
    private int e13textid;
    private int e14id;
    private int e14textid;
    private int e15id;
    private int e15textid;
    private int e77id;
    private int e77textid;
    private int e80id;
    private int e80textid;
    private int e81id;
    private int e81textid;
    private int e82id;
    private int e82textid;
    private int e83id;
    private int e83textid;
    private int e84id;
    private int e84textid;
    private int e85id;
    private int e85textid;
    private int e86id;
    private int e86textid;
    private int e87id;
    private int e87textid;
    private ListClass BasicListObj;
    private int BasicListId;
    private int BBasicSpriteId;
    private int BBasicSpriteId2;
    private int bbasicspriteid3;
    private int BBasicPicId;
    private int BPreHexPicId;
    private int BChangePreHexPicId;
    private int BChangeBasicSpriteId;
    private int BChangeBasicSpriteId2;
    private int Bchangebasicspriteid3;
    private int BChangeBasicPicId;
    private int BPlotLastId;
    private int BPlotLastTextId;
    private int BRandomId;
    private int BRandomTextId;
    private int BAddBasicId;
    private int BAddBasicTextId;
    private int BRemoveBasicId;
    private int BRemoveBasicTextId;
    private int BDrawId;
    private int BDrawTextId;
    private ListClass MoveListObj;
    private int MoveListId;
    private int BMoveCostId;
    private int BChangeMoveCostId;
    private int BBuildGroundId;
    private int BBuildGroundTextId;
    private int BIsSeaId;
    private int BIsSeaTextId;
    private int c1id;
    private int c1textid;
    private int c2id;
    private int c2textid;
    private int c3id;
    private int c3textid;
    private int c4id;
    private int c4textid;
    private int c5id;
    private int c5textid;
    private int c6id;
    private int c6textid;
    private ListClass SpecialListObj;
    private int SpecialListId;
    private int BSpecialSpriteId;
    private int BChangeSpecialSpriteId;
    private int CombatListId;
    private ListClass CombatListObj;
    private int b19id;
    private int b19textid;
    private int b20id;
    private int b20textid;
    private int b18id;
    private int b18textid;
    private int b21id;
    private int b21textid;
    private int killoverrideId;
    private int addoverrideId;
    private int addoverrideID2;
    private int killoverrideId2;
    private int zoverrideId;
    private int zoverridetextId;
    private ListClass SpecialList2Obj;
    private ListClass specialList3Obj;
    private int SpecialList2Id;
    private int speciallist3id;
    private int i1id;
    private int i2id;
    private int i3id;
    private int i1change;
    private int i2change;
    private int i3change;
    private int LTNr;
    private int TabSheetNr;
    private int DetailNr;
    private int Detailnr2;
    private int OverIsTopId;
    private int OverIsTopTextId;
    private string ss;

    public LandscapeTypeWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Landscape Types")
    {
      this.LTNr = -1;
      this.TabSheetNr = -1;
      this.DetailNr = -1;
      this.Detailnr2 = -1;
      this.MakeLTListGUI(-1);
    }

    public override void DoRefresh() => this.MakeLandscapeTypeItemGUI();

    private void MakeLTListGUI(int tltnr)
    {
      if (this.game.Data.LandscapeTypeCounter > -1)
      {
        this.LTListObj = new ListClass();
        int landscapeTypeCounter = this.game.Data.LandscapeTypeCounter;
        for (int index = 0; index <= landscapeTypeCounter; ++index)
          this.LTListObj.add(Strings.Trim(Conversion.Str((object) index)) + ") " + this.game.Data.LandscapeTypeObj[index].Name, index);
        if (this.LTListId > 0)
          this.RemoveSubPart(this.LTListId);
        ListClass ltListObj = this.LTListObj;
        int tlistselect = tltnr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(ltListObj, 9, 200, tlistselect, game, tHeader: "LandscapeTypes", tbackbitmap: (ref local1), bbx: 10, bby: 50, overruleFont: (ref local2));
        this.LTListId = this.AddSubPart(ref tsubpart, 10, 50, 200, 192, 0);
        this.LTNr = tltnr;
        this.MakeLandscapeTypeItemGUI();
      }
      else
      {
        if (this.LTListId > 0)
          this.RemoveSubPart(this.LTListId);
        this.LTNr = -1;
        this.MakeLandscapeTypeItemGUI();
      }
      if (this.BAddLTId > 0)
        this.RemoveSubPart(this.BAddLTId);
      if (this.BAddLTTextId > 0)
        this.RemoveSubPart(this.BAddLTTextId);
      if (this.BCloneLTId > 0)
        this.RemoveSubPart(this.BCloneLTId);
      if (this.BCloneLTTextId > 0)
        this.RemoveSubPart(this.BCloneLTTextId);
      SubPartClass tsubpart1;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        this.ss = "Click to add a clone of current selection";
        tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.BCloneLTId = this.AddSubPart(ref tsubpart1, 10, 250, 32, 16, 1);
        tsubpart1 = (SubPartClass) new TextPartClass("Add Landscape Clone", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.BCloneLTTextId = this.AddSubPart(ref tsubpart1, 50, 249, 300, 20, 0);
        this.ss = "Click to add a completly new landscapetype";
        tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.BAddLTId = this.AddSubPart(ref tsubpart1, 10, 270, 32, 16, 1);
        tsubpart1 = (SubPartClass) new TextPartClass("Add LandscapeType", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.BAddLTTextId = this.AddSubPart(ref tsubpart1, 50, 269, 300, 20, 0);
      }
      if (this.e7id > 0)
        this.RemoveSubPart(this.e7id);
      if (this.e7textid > 0)
        this.RemoveSubPart(this.e7textid);
      if (this.e7bid > 0)
        this.RemoveSubPart(this.e7bid);
      if (this.e7btextid > 0)
        this.RemoveSubPart(this.e7btextid);
      this.ss = "";
      this.ss = "EXPERT USE ONLY. Is a special function that can deconstruct files with all 64 sprites drawn onto in to seperate files.";
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.e7id = this.AddSubPart(ref tsubpart1, 10, 310, 32, 16, 1);
      tsubpart1 = (SubPartClass) new TextPartClass("Deconstr.sheet", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
      this.e7textid = this.AddSubPart(ref tsubpart1, 50, 309, 150, 20, 0);
      this.ss = "EXPERT USE ONLY. Is a special function that can construct files with all 64 seperate 64 sprites assembled into a fred tilesheet";
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.e7bid = this.AddSubPart(ref tsubpart1, 240, 310, 32, 16, 1);
      tsubpart1 = (SubPartClass) new TextPartClass("Constr.sheet", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
      this.e7btextid = this.AddSubPart(ref tsubpart1, 280, 309, 150, 20, 0);
      this.ss = "EXPERT USE ONLY. Is a special function that loads all graphics files in memory and redraws and save them in 32bppPArgb pixelformat.";
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.e77id = this.AddSubPart(ref tsubpart1, 240, 330, 32, 16, 1);
      tsubpart1 = (SubPartClass) new TextPartClass("Harmonize PixForm", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
      this.e77textid = this.AddSubPart(ref tsubpart1, 280, 329, 150, 20, 0);
      this.ss = "EXPERT USE ONLY. Is a specialized function that can remove pixels outside the hex area.";
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.e14id = this.AddSubPart(ref tsubpart1, 10, 330, 32, 16, 1);
      tsubpart1 = (SubPartClass) new TextPartClass("Remove Edges", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.e14textid = this.AddSubPart(ref tsubpart1, 50, 329, 200, 20, 0);
    }

    private void MakeLandscapeTypeItemGUI()
    {
      if (this.BNameId > 0)
        this.RemoveSubPart(this.BNameId);
      if (this.BNameTextId > 0)
        this.RemoveSubPart(this.BNameTextId);
      if (this.BSLId > 0)
        this.RemoveSubPart(this.BSLId);
      if (this.BSLTextId > 0)
        this.RemoveSubPart(this.BSLTextId);
      if (this.BSL2Id > 0)
        this.RemoveSubPart(this.BSL2Id);
      if (this.BSL2TextId > 0)
        this.RemoveSubPart(this.BSL2TextId);
      if (this.BRemoveLtId > 0)
        this.RemoveSubPart(this.BRemoveLtId);
      if (this.BRemoveLtTextId > 0)
        this.RemoveSubPart(this.BRemoveLtTextId);
      if (this.OptionsListId > 0)
        this.RemoveSubPart(this.OptionsListId);
      if (this.BBuildRoadId > 0)
        this.RemoveSubPart(this.BBuildRoadId);
      if (this.BBuildRoadTextId > 0)
        this.RemoveSubPart(this.BBuildRoadTextId);
      if (this.e1id > 0)
        this.RemoveSubPart(this.e1id);
      if (this.e1textid > 0)
        this.RemoveSubPart(this.e1textid);
      if (this.e2id > 0)
        this.RemoveSubPart(this.e2id);
      if (this.e2textid > 0)
        this.RemoveSubPart(this.e2textid);
      if (this.e3id > 0)
        this.RemoveSubPart(this.e3id);
      if (this.e3textid > 0)
        this.RemoveSubPart(this.e3textid);
      if (this.c4id > 0)
        this.RemoveSubPart(this.c4id);
      if (this.c4textid > 0)
        this.RemoveSubPart(this.c4textid);
      if (this.c5id > 0)
        this.RemoveSubPart(this.c5id);
      if (this.c5textid > 0)
        this.RemoveSubPart(this.c5textid);
      if (this.c6id > 0)
        this.RemoveSubPart(this.c6id);
      if (this.c6textid > 0)
        this.RemoveSubPart(this.c6textid);
      if (this.e4id > 0)
        this.RemoveSubPart(this.e4id);
      if (this.e4textid > 0)
        this.RemoveSubPart(this.e4textid);
      if (this.e5id > 0)
        this.RemoveSubPart(this.e5id);
      if (this.e5textid > 0)
        this.RemoveSubPart(this.e5textid);
      if (this.e6id > 0)
        this.RemoveSubPart(this.e6id);
      if (this.e6textid > 0)
        this.RemoveSubPart(this.e6textid);
      if (this.e8id > 0)
        this.RemoveSubPart(this.e8id);
      if (this.e8textid > 0)
        this.RemoveSubPart(this.e8textid);
      if (this.e9id > 0)
        this.RemoveSubPart(this.e9id);
      if (this.e9textid > 0)
        this.RemoveSubPart(this.e9textid);
      if (this.e80id > 0)
        this.RemoveSubPart(this.e80id);
      if (this.e80textid > 0)
        this.RemoveSubPart(this.e80textid);
      if (this.e81id > 0)
        this.RemoveSubPart(this.e81id);
      if (this.e81textid > 0)
        this.RemoveSubPart(this.e81textid);
      if (this.e82id > 0)
        this.RemoveSubPart(this.e82id);
      if (this.e82textid > 0)
        this.RemoveSubPart(this.e82textid);
      if (this.e83id > 0)
        this.RemoveSubPart(this.e83id);
      if (this.e83textid > 0)
        this.RemoveSubPart(this.e83textid);
      if (this.e10id > 0)
        this.RemoveSubPart(this.e10id);
      if (this.e10textid > 0)
        this.RemoveSubPart(this.e10textid);
      if (this.e11id > 0)
        this.RemoveSubPart(this.e11id);
      if (this.e11textid > 0)
        this.RemoveSubPart(this.e11textid);
      if (this.e12id > 0)
        this.RemoveSubPart(this.e12id);
      if (this.e12textid > 0)
        this.RemoveSubPart(this.e12textid);
      if (this.e13id > 0)
        this.RemoveSubPart(this.e13id);
      if (this.e13textid > 0)
        this.RemoveSubPart(this.e13textid);
      if (this.e15id > 0)
        this.RemoveSubPart(this.e15id);
      if (this.e15textid > 0)
        this.RemoveSubPart(this.e15textid);
      if (this.e84id > 0)
        this.RemoveSubPart(this.e84id);
      if (this.e84textid > 0)
        this.RemoveSubPart(this.e84textid);
      if (this.e85id > 0)
        this.RemoveSubPart(this.e85id);
      if (this.e85textid > 0)
        this.RemoveSubPart(this.e85textid);
      if (this.e86id > 0)
        this.RemoveSubPart(this.e86id);
      if (this.e86textid > 0)
        this.RemoveSubPart(this.e86textid);
      if (this.e87id > 0)
        this.RemoveSubPart(this.e87id);
      if (this.e87textid > 0)
        this.RemoveSubPart(this.e87textid);
      if (this.BPreHexPicId > 0)
        this.RemoveSubPart(this.BPreHexPicId);
      if (this.BChangePreHexPicId > 0)
        this.RemoveSubPart(this.BChangePreHexPicId);
      if (this.TxtId > 0)
        this.RemoveSubPart(this.TxtId);
      if (this.TxtStrId > 0)
        this.RemoveSubPart(this.TxtStrId);
      if (this.OverIsTopId > 0)
        this.RemoveSubPart(this.OverIsTopId);
      if (this.OverIsTopTextId > 0)
        this.RemoveSubPart(this.OverIsTopTextId);
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 100, -1);
      this.FlagAll();
      if (this.LTNr > -1)
      {
        this.ss = "Click to change the name of this LandscapeType";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.BNameId = this.AddSubPart(ref tsubpart, 370, 50, 32, 16, 1);
        }
        SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Name: " + this.game.Data.LandscapeTypeObj[this.LTNr].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BNameTextId = this.AddSubPart(ref tsubpart1, 410, 49, 200, 20, 0);
        this.ss = "Click to change the description of this LandscapeType";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.TxtId = this.AddSubPart(ref tsubpart2, 650, 50, 32, 16, 1);
        }
        SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("Description", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.TxtStrId = this.AddSubPart(ref tsubpart3, 700, 49, 200, 20, 0);
        if (this.game.Data.LandscapeTypeObj[this.LTNr].SpecialLayer)
        {
          this.ss = "Click to remove SpecialLayer.";
          if (Strings.Len(this.game.Data.MasterFile) == 0)
          {
            SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
            this.BSLId = this.AddSubPart(ref tsubpart4, 370, 70, 32, 16, 1);
          }
        }
        else
        {
          this.ss = "Click to activate SpecialLayer. Which enables you to set the 64 sprites for this LT. You will be prompted where to import files from.";
          if (Strings.Len(this.game.Data.MasterFile) == 0)
          {
            SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
            this.BSLId = this.AddSubPart(ref tsubpart5, 370, 70, 32, 16, 1);
          }
        }
        SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("x64", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 50, false, tDescript: this.ss);
        this.BSLTextId = this.AddSubPart(ref tsubpart6, 410, 69, 80, 20, 0);
        if (this.game.Data.LandscapeTypeObj[this.LTNr].SpecialLayer6)
        {
          this.ss = "Click to remove first 6 sprite use only limit.";
          if (Strings.Len(this.game.Data.MasterFile) == 0)
          {
            SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONFLAGGED, tDescript: this.ss);
            this.BSL2Id = this.AddSubPart(ref tsubpart7, 490, 70, 32, 16, 1);
          }
        }
        else
        {
          this.ss = "Click to add first 6 sprites use only limit";
          if (Strings.Len(this.game.Data.MasterFile) == 0)
          {
            SubPartClass tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONUNFLAGGED, tDescript: this.ss);
            this.BSL2Id = this.AddSubPart(ref tsubpart8, 490, 70, 32, 16, 1);
          }
        }
        SubPartClass tsubpart9 = (SubPartClass) new TextPartClass("x6", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 50, false, tDescript: this.ss);
        this.BSL2TextId = this.AddSubPart(ref tsubpart9, 540, 69, 80, 20, 0);
        this.ss = "Click to set AIBlock. 0=none , 1=yes.. means AI will not try to move through this lt";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart10 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.e2id = this.AddSubPart(ref tsubpart10, 370, 130, 32, 16, 1);
        }
        SubPartClass tsubpart11 = (SubPartClass) new TextPartClass("AIBlock: " + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].AIBlock), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e2textid = this.AddSubPart(ref tsubpart11, 410, 129, 200, 20, 0);
        this.ss = "Click to toggle on/off if a unit can be paradropped on a hex with this landscape";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.e3id = this.AddSubPart(ref tsubpart11, 610, 130, 32, 16, 1);
        }
        tsubpart11 = (SubPartClass) new TextPartClass("CanParadrop: " + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].CanParadrop), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e3textid = this.AddSubPart(ref tsubpart11, 650, 129, 200, 20, 0);
        this.ss = "Click to toggle on/off if a unit can be amphibiously unloaded on a hex with this landscape";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.e5id = this.AddSubPart(ref tsubpart11, 610, 90, 32, 16, 1);
        }
        tsubpart11 = (SubPartClass) new TextPartClass("CanAmph: " + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].CanAmph), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e5textid = this.AddSubPart(ref tsubpart11, 650, 89, 200, 20, 0);
        this.ss = "Click to set color for landscapetype on minimap. press cancel for no color.";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.e6id = this.AddSubPart(ref tsubpart11, 850, 150, 32, 16, 1);
        }
        tsubpart11 = (SubPartClass) new TextPartClass("Color: " + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].Red) + "," + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].Green) + "," + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].Blue), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e6textid = this.AddSubPart(ref tsubpart11, 890, 149, 200, 20, 0);
        if (this.game.Data.Product >= 6)
        {
          this.ss = "Click to set the number of Obstruct Points for the Landscape. Only used with Advanced Recon Rules.";
          if (Strings.Len(this.game.Data.MasterFile) == 0)
          {
            tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
            this.e86id = this.AddSubPart(ref tsubpart11, 850, 130, 32, 16, 1);
          }
          tsubpart11 = (SubPartClass) new TextPartClass("Obstruct: " + this.game.Data.LandscapeTypeObj[this.LTNr].Obstruction.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.e86textid = this.AddSubPart(ref tsubpart11, 890, 129, 200, 20, 0);
        }
        this.ss = "If Interior style=false the 6/64 special sprites will be portrayd on neighbour hexes. Otherwise in own hex. Interior cannot use 6, only 64";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.e8id = this.AddSubPart(ref tsubpart11, 850, 180, 32, 16, 1);
        }
        tsubpart11 = (SubPartClass) new TextPartClass("Interior Drawing Style = " + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].Interior), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e8textid = this.AddSubPart(ref tsubpart11, 880, 179, 200, 20, 0);
        this.ss = "Will use specified landscapetype 6/64 special sprites as exterior transitions. even if this landscape is set on Interior itself. ";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.e9id = this.AddSubPart(ref tsubpart11, 850, 200, 32, 16, 1);
        }
        if (this.game.Data.LandscapeTypeObj[this.LTNr].ExtraExterior == -1)
        {
          tsubpart11 = (SubPartClass) new TextPartClass("ExtraExterior = -1", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.e9textid = this.AddSubPart(ref tsubpart11, 880, 199, 200, 20, 0);
        }
        else
        {
          tsubpart11 = (SubPartClass) new TextPartClass("ExtraExterior = " + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].ExtraExterior) + "," + this.game.Data.LandscapeTypeObj[this.game.Data.LandscapeTypeObj[this.LTNr].ExtraExterior].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.e9textid = this.AddSubPart(ref tsubpart11, 880, 199, 200, 20, 0);
        }
        this.ss = "If Extra Exterior=True then the Interior transition will consider the hex with the exterior transition the same landscape";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.e10id = this.AddSubPart(ref tsubpart11, 850, 220, 32, 16, 1);
        }
        if (this.game.Data.LandscapeTypeObj[this.LTNr].ExtraExteriorSame)
        {
          tsubpart11 = (SubPartClass) new TextPartClass("ExtraExteriorSame = True", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.e10textid = this.AddSubPart(ref tsubpart11, 880, 219, 200, 20, 0);
        }
        else
        {
          tsubpart11 = (SubPartClass) new TextPartClass("ExtraExteriorSame = False ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.e10textid = this.AddSubPart(ref tsubpart11, 880, 219, 200, 20, 0);
        }
        this.ss = "Blacked Out LT doesnt show frontiers or map edges";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.e11id = this.AddSubPart(ref tsubpart11, 850, 240, 32, 16, 1);
        }
        if (this.game.Data.LandscapeTypeObj[this.LTNr].BlackedOut)
        {
          tsubpart11 = (SubPartClass) new TextPartClass("BlackedOut = True", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.e11textid = this.AddSubPart(ref tsubpart11, 880, 239, 200, 20, 0);
        }
        else
        {
          tsubpart11 = (SubPartClass) new TextPartClass("BlackedOut = False ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.e11textid = this.AddSubPart(ref tsubpart11, 880, 239, 200, 20, 0);
        }
        this.ss = "Use PreHex borders defined in LT X. -1=dont use.";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.e12id = this.AddSubPart(ref tsubpart11, 850, 260, 32, 16, 1);
        }
        tsubpart11 = (SubPartClass) new TextPartClass("PreHexBorder=" + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].PreHexBorder), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e12textid = this.AddSubPart(ref tsubpart11, 880, 259, 200, 20, 0);
        this.ss = "If LT shows up in info or editor paint selection windows ingame or not.";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.e13id = this.AddSubPart(ref tsubpart11, 850, 280, 32, 16, 1);
        }
        tsubpart11 = (SubPartClass) new TextPartClass("DontShowInList=" + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].DontShowInList), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e13textid = this.AddSubPart(ref tsubpart11, 880, 279, 200, 20, 0);
        this.ss = "If NoPortReq=true it means that supply movement between land<>sea does not suffer rulevar82 penalty for having no port present.";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.e15id = this.AddSubPart(ref tsubpart11, 850, 300, 32, 16, 1);
        }
        tsubpart11 = (SubPartClass) new TextPartClass("NoPortReq=" + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].NoPortReq), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e15textid = this.AddSubPart(ref tsubpart11, 880, 299, 200, 20, 0);
        if (this.game.Data.Product >= 7)
        {
          this.ss = "";
          if (Strings.Len(this.game.Data.MasterFile) == 0)
          {
            tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
            this.e85id = this.AddSubPart(ref tsubpart11, 850, 320, 32, 16, 1);
          }
          tsubpart11 = (SubPartClass) new TextPartClass("PreHexBorderOwnZ=" + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].usePreHexBorderOwnZ), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.e85textid = this.AddSubPart(ref tsubpart11, 880, 319, 200, 20, 0);
        }
        this.ss = "Set tranparent true/false (usefull in combination with overlay map graphic)";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.c6id = this.AddSubPart(ref tsubpart11, 850, 340, 32, 16, 1);
        }
        tsubpart11 = (SubPartClass) new TextPartClass("Transparent=" + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].Transparent), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.c6textid = this.AddSubPart(ref tsubpart11, 880, 339, 200, 20, 0);
        this.ss = "Experimental: Use Pre Hex Texture?";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.e80id = this.AddSubPart(ref tsubpart11, 850, 390, 32, 16, 1);
        }
        tsubpart11 = (SubPartClass) new TextPartClass("UsePreHexTexture=" + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].UsePreHexTexture), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e80textid = this.AddSubPart(ref tsubpart11, 880, 389, 400, 20, 0);
        this.ss = this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureFileName;
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.e81id = this.AddSubPart(ref tsubpart11, 850, 370, 32, 16, 1);
        }
        tsubpart11 = (SubPartClass) new TextPartClass("PreHexTextureFile=" + this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureFileName, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.e81textid = this.AddSubPart(ref tsubpart11, 880, 369, 400, 20, 0);
        this.ss = Conversions.ToString(this.game.Data.LandscapeTypeObj[this.LTNr].UsePreHexBorderTexture);
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.e82id = this.AddSubPart(ref tsubpart11, 850, 410, 32, 16, 1);
        }
        tsubpart11 = (SubPartClass) new TextPartClass("UsePreHexBordersTex=" + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].UsePreHexBorderTexture), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.e82textid = this.AddSubPart(ref tsubpart11, 880, 409, 400, 20, 0);
        this.ss = "";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.e83id = this.AddSubPart(ref tsubpart11, 850, 430, 32, 16, 1);
        }
        tsubpart11 = (SubPartClass) new TextPartClass("UsePreHexTextureAndRegularPreHex=" + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].UsePreHexTextureAndRegularPreHex), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 600, 20, false, tDescript: this.ss);
        this.e83textid = this.AddSubPart(ref tsubpart11, 880, 429, 600, 20, 0);
        if (this.game.Data.Product >= 6)
        {
          this.ss = "";
          if (Strings.Len(this.game.Data.MasterFile) == 0)
          {
            tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
            this.e87id = this.AddSubPart(ref tsubpart11, 850, 470, 32, 16, 1);
          }
          tsubpart11 = (SubPartClass) new TextPartClass("FuzzyOwnerAssured=" + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].FuzzyOwnerAssured), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 600, 20, false, tDescript: this.ss);
          this.e87textid = this.AddSubPart(ref tsubpart11, 880, 469, 600, 20, 0);
        }
        if (this.game.Data.LandscapeTypeCounter > 0)
        {
          this.ss = "Click to remove this landscapetype";
          if (Strings.Len(this.game.Data.MasterFile) == 0)
          {
            tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
            this.BRemoveLtId = this.AddSubPart(ref tsubpart11, 10, 290, 32, 16, 1);
          }
          if (Strings.Len(this.game.Data.MasterFile) == 0)
          {
            tsubpart11 = (SubPartClass) new TextPartClass("Remove", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
            this.BRemoveLtTextId = this.AddSubPart(ref tsubpart11, 50, 289, 200, 20, 0);
          }
        }
        this.OptionsListObj = new ListClass();
        this.OptionsListObj.add("Sprites", 0);
        this.OptionsListObj.add("Movecost + Stats", 1);
        if (this.game.Data.LandscapeTypeObj[this.LTNr].SpecialLayer | this.game.Data.LandscapeTypeObj[this.LTNr].UseSheet)
        {
          this.OptionsListObj.add("64 Special Sprites", 2);
          this.OptionsListObj.add("Graphic overrides", 3);
        }
        else
        {
          this.OptionsListObj.add("64 Special Sprites", 2);
          this.OptionsListObj.add("Graphic overrides", 3);
        }
        this.OptionsListObj.add("Entrench per Unitgroup", 4);
        this.OptionsListObj.add("Landscape Layers", 5);
        ListClass optionsListObj = this.OptionsListObj;
        int tabSheetNr = this.TabSheetNr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        tsubpart11 = (SubPartClass) new ListSubPartClass(optionsListObj, 4, 300, tabSheetNr, game, tHeader: "Property Sheets", tbackbitmap: (ref local1), bbx: 370, bby: 150, overruleFont: (ref local2));
        this.OptionsListId = this.AddSubPart(ref tsubpart11, 370, 150, 300, 112, 0);
        this.ss = "Click to change the prehex sprite. current file = " + this.game.Data.LandscapeTypeObj[this.LTNr].PreHexPicFileName;
        tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.Data.LandscapeTypeObj[this.LTNr].PreHexPicID, tDescript: this.ss, tResizeX: 64, tresizeY: 48);
        this.BPreHexPicId = this.AddSubPart(ref tsubpart11, 410, 270, 64, 48, 0);
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
          this.BChangePreHexPicId = this.AddSubPart(ref tsubpart11, 370, 270, 32, 16, 1);
        }
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
      if (this.BBasicSpriteId2 > 0)
        this.RemoveSubPart(this.BBasicSpriteId2);
      if (this.BChangeBasicSpriteId2 > 0)
        this.RemoveSubPart(this.BChangeBasicSpriteId2);
      if (this.bbasicspriteid3 > 0)
        this.RemoveSubPart(this.bbasicspriteid3);
      if (this.Bchangebasicspriteid3 > 0)
        this.RemoveSubPart(this.Bchangebasicspriteid3);
      if (this.BBasicPicId > 0)
        this.RemoveSubPart(this.BBasicPicId);
      if (this.BChangeBasicPicId > 0)
        this.RemoveSubPart(this.BChangeBasicPicId);
      if (this.SpecialListId > 0)
        this.RemoveSubPart(this.SpecialListId);
      if (this.BSpecialSpriteId > 0)
        this.RemoveSubPart(this.BSpecialSpriteId);
      if (this.BChangeSpecialSpriteId > 0)
        this.RemoveSubPart(this.BChangeSpecialSpriteId);
      if (this.BAddBasicId > 0)
        this.RemoveSubPart(this.BAddBasicId);
      if (this.BAddBasicTextId > 0)
        this.RemoveSubPart(this.BAddBasicTextId);
      if (this.BRemoveBasicId > 0)
        this.RemoveSubPart(this.BRemoveBasicId);
      if (this.BRemoveBasicTextId > 0)
        this.RemoveSubPart(this.BRemoveBasicTextId);
      if (this.BDrawId > 0)
        this.RemoveSubPart(this.BDrawId);
      if (this.BDrawTextId > 0)
        this.RemoveSubPart(this.BDrawTextId);
      if (this.i1id > 0)
        this.RemoveSubPart(this.i1id);
      if (this.i1change > 0)
        this.RemoveSubPart(this.i1change);
      if (this.i2id > 0)
        this.RemoveSubPart(this.i2id);
      if (this.i2change > 0)
        this.RemoveSubPart(this.i2change);
      if (this.i3id > 0)
        this.RemoveSubPart(this.i3id);
      if (this.i3change > 0)
        this.RemoveSubPart(this.i3change);
      if (this.MoveListId > 0)
        this.RemoveSubPart(this.MoveListId);
      if (this.BMoveCostId > 0)
        this.RemoveSubPart(this.BMoveCostId);
      if (this.BChangeMoveCostId > 0)
        this.RemoveSubPart(this.BChangeMoveCostId);
      if (this.BBuildGroundId > 0)
        this.RemoveSubPart(this.BBuildGroundId);
      if (this.BBuildGroundTextId > 0)
        this.RemoveSubPart(this.BBuildGroundTextId);
      if (this.BPlotLastId > 0)
        this.RemoveSubPart(this.BPlotLastId);
      if (this.BPlotLastTextId > 0)
        this.RemoveSubPart(this.BPlotLastTextId);
      if (this.BIsSeaId > 0)
        this.RemoveSubPart(this.BIsSeaId);
      if (this.BIsSeaTextId > 0)
        this.RemoveSubPart(this.BIsSeaTextId);
      if (this.b18id > 0)
        this.RemoveSubPart(this.b18id);
      if (this.b18textid > 0)
        this.RemoveSubPart(this.b18textid);
      if (this.b19id > 0)
        this.RemoveSubPart(this.b19id);
      if (this.b19textid > 0)
        this.RemoveSubPart(this.b19textid);
      if (this.b20id > 0)
        this.RemoveSubPart(this.b20id);
      if (this.b20textid > 0)
        this.RemoveSubPart(this.b20textid);
      if (this.CombatListId > 0)
        this.RemoveSubPart(this.CombatListId);
      if (this.c1id > 0)
        this.RemoveSubPart(this.c1id);
      if (this.c1textid > 0)
        this.RemoveSubPart(this.c1textid);
      if (this.c2id > 0)
        this.RemoveSubPart(this.c2id);
      if (this.c2textid > 0)
        this.RemoveSubPart(this.c2textid);
      if (this.c3id > 0)
        this.RemoveSubPart(this.c3id);
      if (this.c3textid > 0)
        this.RemoveSubPart(this.c3textid);
      if (this.killoverrideId > 0)
        this.RemoveSubPart(this.killoverrideId);
      if (this.addoverrideId > 0)
        this.RemoveSubPart(this.addoverrideId);
      if (this.killoverrideId2 > 0)
        this.RemoveSubPart(this.killoverrideId2);
      if (this.addoverrideID2 > 0)
        this.RemoveSubPart(this.addoverrideID2);
      if (this.zoverrideId > 0)
        this.RemoveSubPart(this.zoverrideId);
      if (this.zoverridetextId > 0)
        this.RemoveSubPart(this.zoverridetextId);
      if (this.SpecialList2Id > 0)
        this.RemoveSubPart(this.SpecialList2Id);
      if (this.speciallist3id > 0)
        this.RemoveSubPart(this.speciallist3id);
      if (this.BRandomId > 0)
        this.RemoveSubPart(this.BRandomId);
      if (this.BRandomTextId > 0)
        this.RemoveSubPart(this.BRandomTextId);
      if (this.OverIsTopId > 0)
        this.RemoveSubPart(this.OverIsTopId);
      if (this.OverIsTopTextId > 0)
        this.RemoveSubPart(this.OverIsTopTextId);
      if (!(this.LTNr > -1 & this.TabSheetNr > -1))
        return;
      if (this.TabSheetNr == 0)
        this.maketabsheetnr0();
      if (this.TabSheetNr == 1)
        this.maketabsheetnr1();
      if (this.TabSheetNr == 2)
        this.maketabsheetnr2();
      if (this.TabSheetNr == 3)
        this.maketabsheetnr3();
      if (this.TabSheetNr == 4)
        this.maketabsheetnr4();
      if (this.TabSheetNr != 5)
        return;
      this.maketabsheetnr5();
    }

    private void maketabsheetnr5()
    {
      if (this.game.Data.LandscapeTypeObj[this.LTNr].BasicSpriteCounter <= -1)
        return;
      this.BasicListObj = new ListClass();
      int basicSpriteCounter = this.game.Data.LandscapeTypeObj[this.LTNr].BasicSpriteCounter;
      for (int tdata = 0; tdata <= basicSpriteCounter; ++tdata)
        this.BasicListObj.add(this.game.Data.LandscapeTypeObj[this.LTNr].BasicSpriteFileName[tdata], tdata);
      ListClass basicListObj = this.BasicListObj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(basicListObj, 10, 300, detailNr, game, tHeader: "Sprites", tbackbitmap: (ref local1), bbx: 10, bby: 350, overruleFont: (ref local2));
      this.BasicListId = this.AddSubPart(ref tsubpart, 10, 350, 300, 208, 0);
      if (this.DetailNr > this.game.Data.LandscapeTypeObj[this.LTNr].BasicSpriteCounter)
        this.DetailNr = -1;
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr5b();
    }

    private void maketabsheetnr5b()
    {
      if (this.i1id > 0)
        this.RemoveSubPart(this.i1id);
      if (this.i1change > 0)
        this.RemoveSubPart(this.i1change);
      if (this.i2id > 0)
        this.RemoveSubPart(this.i2id);
      if (this.i2change > 0)
        this.RemoveSubPart(this.i2change);
      if (this.i3id > 0)
        this.RemoveSubPart(this.i3id);
      if (this.i3change > 0)
        this.RemoveSubPart(this.i3change);
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.Data.LandscapeTypeObj[this.LTNr].SidewaysSPriteID1[this.DetailNr], tDescript: "1st (sky layer)", tResizeX: 100, tresizeY: 41);
      this.i1id = this.AddSubPart(ref tsubpart1, 410, 350, 140, 80, 1);
      SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(BitmapStore.GetBitmap(this.game.BUTTONBLUE), "1st (sky layer)");
      this.i1change = this.AddSubPart(ref tsubpart2, 410, 450, 32, 16, 1);
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.Data.LandscapeTypeObj[this.LTNr].SidewaysSPriteID2[this.DetailNr], tDescript: "2nd (back layer)", tResizeX: 100, tresizeY: 41);
      this.i2id = this.AddSubPart(ref tsubpart3, 610, 350, 140, 80, 1);
      SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(BitmapStore.GetBitmap(this.game.BUTTONBLUE), "2nd (back layer)");
      this.i2change = this.AddSubPart(ref tsubpart4, 610, 450, 32, 16, 1);
      SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.Data.LandscapeTypeObj[this.LTNr].SidewaysSPriteID3[this.DetailNr], tDescript: "3rd (front layer)", tResizeX: 100, tresizeY: 41);
      this.i3id = this.AddSubPart(ref tsubpart5, 810, 350, 140, 80, 1);
      SubPartClass tsubpart6 = (SubPartClass) new ButtonPartClass(BitmapStore.GetBitmap(this.game.BUTTONBLUE), "3rd (front layer)");
      this.i3change = this.AddSubPart(ref tsubpart6, 810, 450, 32, 16, 1);
    }

    private void maketabsheetnr0()
    {
      if (this.game.Data.LandscapeTypeObj[this.LTNr].BasicSpriteCounter > -1)
      {
        this.BasicListObj = new ListClass();
        int basicSpriteCounter = this.game.Data.LandscapeTypeObj[this.LTNr].BasicSpriteCounter;
        for (int tdata = 0; tdata <= basicSpriteCounter; ++tdata)
          this.BasicListObj.add(this.game.Data.LandscapeTypeObj[this.LTNr].BasicSpriteFileName[tdata], tdata);
        ListClass basicListObj = this.BasicListObj;
        int detailNr = this.DetailNr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(basicListObj, 10, 300, detailNr, game, tHeader: "Sprites", tbackbitmap: (ref local1), bbx: 10, bby: 350, overruleFont: (ref local2));
        this.BasicListId = this.AddSubPart(ref tsubpart, 10, 350, 300, 208, 0);
        if (this.DetailNr > this.game.Data.LandscapeTypeObj[this.LTNr].BasicSpriteCounter)
          this.DetailNr = -1;
        if (this.DetailNr > -1)
          this.maketabsheetnr0b();
      }
      this.ss = "Click to add a sprite to selected landscapetype";
      SubPartClass tsubpart1;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.BAddBasicId = this.AddSubPart(ref tsubpart1, 10, 580, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      tsubpart1 = (SubPartClass) new TextPartClass("Add Sprite", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.BAddBasicTextId = this.AddSubPart(ref tsubpart1, 50, 579, 200, 20, 0);
    }

    private void maketabsheetnr0b()
    {
      if (this.BBasicSpriteId > 0)
        this.RemoveSubPart(this.BBasicSpriteId);
      if (this.BChangeBasicSpriteId > 0)
        this.RemoveSubPart(this.BChangeBasicSpriteId);
      this.ss = "Click to change the sprite";
      SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.Data.LandscapeTypeObj[this.LTNr].BasicSpriteID[this.DetailNr], tDescript: this.ss, tResizeX: 64, tresizeY: 48);
      this.BBasicSpriteId = this.AddSubPart(ref tsubpart, 400, 350, 64, 48, 0);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
        this.BChangeBasicSpriteId = this.AddSubPart(ref tsubpart, 400, 410, 32, 16, 1);
      }
      this.ss = "Click to change the optional graphic that is optionally drawn over the sprite at end of drawing";
      if (this.BBasicSpriteId2 > 0)
        this.RemoveSubPart(this.BBasicSpriteId2);
      if (this.BChangeBasicSpriteId2 > 0)
        this.RemoveSubPart(this.BChangeBasicSpriteId2);
      tsubpart = (SubPartClass) new ButtonPartClass(this.game.Data.LandscapeTypeObj[this.LTNr].BasicSpriteID2[this.DetailNr], tDescript: this.ss, tResizeX: 64, tresizeY: 48);
      this.BBasicSpriteId2 = this.AddSubPart(ref tsubpart, 470, 350, 64, 48, 0);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
        this.BChangeBasicSpriteId2 = this.AddSubPart(ref tsubpart, 470, 410, 32, 16, 1);
      }
      this.ss = "Click to change the optional OverIsTop graphics optionally drawn over the hex above the landscape";
      if (this.bbasicspriteid3 > 0)
        this.RemoveSubPart(this.bbasicspriteid3);
      if (this.Bchangebasicspriteid3 > 0)
        this.RemoveSubPart(this.Bchangebasicspriteid3);
      tsubpart = (SubPartClass) new ButtonPartClass(this.game.Data.LandscapeTypeObj[this.LTNr].BasicSpriteID3[this.DetailNr], tDescript: this.ss, tResizeX: 64, tresizeY: 48);
      this.bbasicspriteid3 = this.AddSubPart(ref tsubpart, 540, 350, 64, 48, 0);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
        this.Bchangebasicspriteid3 = this.AddSubPart(ref tsubpart, 540, 410, 32, 16, 1);
      }
      this.ss = "Click to change the artistic picture representing this sprite for this landscapetype";
      if (this.BBasicPicId > 0)
        this.RemoveSubPart(this.BBasicPicId);
      if (this.BChangeBasicPicId > 0)
        this.RemoveSubPart(this.BChangeBasicPicId);
      tsubpart = (SubPartClass) new ButtonPartClass(this.game.Data.LandscapeTypeObj[this.LTNr].BasicPicID[this.DetailNr], tDescript: this.ss, tResizeX: 363, tresizeY: 150);
      this.BBasicPicId = this.AddSubPart(ref tsubpart, 400, 450, 363, 150, 0);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
        this.BChangeBasicPicId = this.AddSubPart(ref tsubpart, 780, 500, 32, 16, 1);
      }
      this.ss = "Click to toggle on/off the optional drawing over of the optional graphic";
      if (this.BPlotLastId > 0)
        this.RemoveSubPart(this.BPlotLastId);
      if (this.BPlotLastTextId > 0)
        this.RemoveSubPart(this.BPlotLastTextId);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BPlotLastId = this.AddSubPart(ref tsubpart, 640, 350, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("PlotLast:" + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].PlotLast[this.DetailNr]), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 110, 20, false, tDescript: this.ss);
      this.BPlotLastTextId = this.AddSubPart(ref tsubpart, 690, 349, 110, 20, 0);
      if (this.game.Data.Product >= 7)
      {
        this.ss = "Click to toggle on/off the optional drawing before the River";
        if (this.e84id > 0)
          this.RemoveSubPart(this.e84id);
        if (this.e84textid > 0)
          this.RemoveSubPart(this.e84textid);
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.e84id = this.AddSubPart(ref tsubpart, 640, 370, 32, 16, 1);
        }
        tsubpart = (SubPartClass) new TextPartClass("BeforeRiv:" + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].PlotBeforeRiver[this.DetailNr]), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 110, 20, false, tDescript: this.ss);
        this.e84textid = this.AddSubPart(ref tsubpart, 690, 369, 110, 20, 0);
      }
      this.ss = "OverIsTop graphics is used as overdraw on the hex above it = true/false. If overistop=true 64 border sprites dont work.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.OverIsTopId = this.AddSubPart(ref tsubpart, 640, 330, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("OverIsTop:" + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].OverIsTop[this.DetailNr]), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 110, 20, false, tDescript: this.ss);
      this.OverIsTopTextId = this.AddSubPart(ref tsubpart, 690, 329, 110, 20, 0);
      if (this.BRemoveBasicId > 0)
        this.RemoveSubPart(this.BRemoveBasicId);
      if (this.BRemoveBasicTextId > 0)
        this.RemoveSubPart(this.BRemoveBasicTextId);
      if (this.game.Data.LandscapeTypeObj[this.LTNr].BasicSpriteCounter > 0)
      {
        this.ss = "Click to remove the selected sprite";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
          this.BRemoveBasicId = this.AddSubPart(ref tsubpart, 10, 600, 32, 16, 1);
        }
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart = (SubPartClass) new TextPartClass("Remove this Basic Sprite", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.BRemoveBasicTextId = this.AddSubPart(ref tsubpart, 50, 599, 200, 20, 0);
        }
      }
      if (this.BDrawId > 0)
        this.RemoveSubPart(this.BDrawId);
      if (this.BDrawTextId > 0)
        this.RemoveSubPart(this.BDrawTextId);
      this.ss = "Click to select this sprite for drawing on the map";
      tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONDRAW, tDescript: this.ss);
      this.BDrawId = this.AddSubPart(ref tsubpart, 10, 620, 32, 16, 1);
      tsubpart = (SubPartClass) new TextPartClass("Select as pencil", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.BDrawTextId = this.AddSubPart(ref tsubpart, 50, 619, 200, 20, 0);
    }

    private void maketabsheetnr1()
    {
      this.MoveListObj = new ListClass();
      int index = 0;
      do
      {
        this.MoveListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.TempString[index] + " = " + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].MoveCost[index]), index);
        ++index;
      }
      while (index <= 99);
      int num = (int) Math.Round((double) Math.Max(0, this.game.ScreenHeight - 800) / 16.0);
      ListClass moveListObj = this.MoveListObj;
      int tlistsize = 10 + num;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(moveListObj, tlistsize, 300, detailNr, game, tHeader: "Movecost for MoveTypes", tbackbitmap: (ref local1), bbx: 10, bby: 350, overruleFont: (ref local2));
      this.MoveListId = this.AddSubPart(ref tsubpart1, 10, 350, 300, (13 + num) * 16, 0);
      if (this.DetailNr > 99)
        this.DetailNr = -1;
      if (this.DetailNr > -1)
        this.maketabsheetnr1b();
      this.ss = "Click to set the Buildground Type";
      SubPartClass tsubpart2;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BBuildGroundId = this.AddSubPart(ref tsubpart2, 410, 350, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("BuildGround =" + this.game.Data.TempString[100 + this.game.Data.LandscapeTypeObj[this.LTNr].BuildGround], new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.BBuildGroundTextId = this.AddSubPart(ref tsubpart2, 450, 349, 200, 20, 0);
      this.ss = "Click to set if landscapetype is 'sea' or not.";
      if (this.game.Data.LandscapeTypeObj[this.LTNr].IsSea)
      {
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONFLAGGED, tDescript: this.ss);
          this.BIsSeaId = this.AddSubPart(ref tsubpart2, 410, 380, 32, 16, 1);
        }
      }
      else if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONUNFLAGGED, tDescript: this.ss);
        this.BIsSeaId = this.AddSubPart(ref tsubpart2, 410, 380, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("Is Sea", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 50, false, tDescript: this.ss);
      this.BIsSeaTextId = this.AddSubPart(ref tsubpart2, 450, 379, 200, 20, 0);
      this.ss = "Set the hide points a unit in this landscapetype gets.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c3id = this.AddSubPart(ref tsubpart2, 410, 440, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("HidePTs =" + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].HidePts), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c3textid = this.AddSubPart(ref tsubpart2, 450, 439, 200, 20, 0);
    }

    private void maketabsheetnr1b()
    {
      string txt = "Move Cost = " + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].MoveCost[this.DetailNr]);
      if (this.BMoveCostId > 0)
        this.RemoveSubPart(this.BMoveCostId);
      if (this.BChangeMoveCostId > 0)
        this.RemoveSubPart(this.BChangeMoveCostId);
      this.ss = "Click to set new movecost for this movetype for this landscape type in Action Points";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BChangeMoveCostId = this.AddSubPart(ref tsubpart, 400, 490, 32, 16, 1);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass(txt, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.BMoveCostId = this.AddSubPart(ref tsubpart1, 450, 490, 200, 20, 0);
    }

    private void maketabsheetnr2()
    {
      if (!this.game.Data.LandscapeTypeObj[this.LTNr].SpecialLayer)
        return;
      if (!this.game.Data.LandscapeTypeObj[this.LTNr].UseSheet)
      {
        if (this.game.Data.LandscapeTypeObj[this.LTNr].UsePreHexBorderTexture)
          return;
        this.SpecialListObj = new ListClass();
        int tdata = 0;
        do
        {
          this.SpecialListObj.add(this.game.Data.LandscapeTypeObj[this.LTNr].LayerSpriteFileName[tdata + 1], tdata);
          ++tdata;
        }
        while (tdata <= 63);
        ListClass specialListObj = this.SpecialListObj;
        int detailNr = this.DetailNr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(specialListObj, 15, 300, detailNr, game, tHeader: "64 Special Sprites", tbackbitmap: (ref local1), bbx: 10, bby: 350, overruleFont: (ref local2));
        this.SpecialListId = this.AddSubPart(ref tsubpart, 10, 350, 300, 288, 0);
        if (this.DetailNr > 63)
          this.DetailNr = -1;
        if (this.DetailNr <= -1)
          return;
        this.maketabsheetnr2b();
      }
      else if (this.game.Data.LandscapeTypeObj[this.LTNr].UsePreHexBorderTexture | this.game.Data.LandscapeTypeObj[this.LTNr].UsePreHexTexture)
      {
        this.ss = "the fred sheet you are currently using. filename = " + this.game.Data.LandscapeTypeObj[this.LTNr].SheetFileName;
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BIsSeaTextId = this.AddSubPart(ref tsubpart, 10, 350, 32, 16, 1);
      }
      else
      {
        this.ss = "the fred sheet you are currently using. filename = " + this.game.Data.LandscapeTypeObj[this.LTNr].SheetFileName;
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID, tDescript: this.ss);
        this.BIsSeaTextId = this.AddSubPart(ref tsubpart, 10, 350, BitmapStore.GetWidth(this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID), BitmapStore.Getheight(this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID), 0);
      }
    }

    private void maketabsheetnr2b()
    {
      if (this.BSpecialSpriteId > 0)
        this.RemoveSubPart(this.BSpecialSpriteId);
      if (this.BChangeSpecialSpriteId > 0)
        this.RemoveSubPart(this.BChangeSpecialSpriteId);
      this.ss = "Click to replace a single selected special sprite. Advice: disable specialsprites, enable again and select dir to input all 64 from.";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.Data.LandscapeTypeObj[this.LTNr].LayerSpriteID[this.DetailNr + 1], tDescript: this.ss);
      this.BSpecialSpriteId = this.AddSubPart(ref tsubpart1, 400, 350, 64, 48, 0);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
        this.BChangeSpecialSpriteId = this.AddSubPart(ref tsubpart2, 400, 410, 32, 16, 1);
      }
      this.ss = "Click to set color for landscapetype on minimap. press cancel for no color.";
    }

    public void maketabsheetnr3()
    {
      if (this.killoverrideId > 0)
        this.RemoveSubPart(this.killoverrideId);
      if (this.addoverrideId > 0)
        this.RemoveSubPart(this.addoverrideId);
      if (this.killoverrideId2 > 0)
        this.RemoveSubPart(this.killoverrideId2);
      if (this.addoverrideID2 > 0)
        this.RemoveSubPart(this.addoverrideID2);
      if (this.zoverrideId > 0)
        this.RemoveSubPart(this.zoverrideId);
      if (this.zoverridetextId > 0)
        this.RemoveSubPart(this.zoverridetextId);
      if (this.SpecialList2Id > 0)
        this.RemoveSubPart(this.SpecialList2Id);
      if (this.speciallist3id > 0)
        this.RemoveSubPart(this.speciallist3id);
      this.SpecialList2Obj = new ListClass();
      if (this.game.Data.LandscapeTypeObj[this.LTNr].OverridesCount > -1)
      {
        int overridesCount = this.game.Data.LandscapeTypeObj[this.LTNr].OverridesCount;
        for (int tdata = 0; tdata <= overridesCount; ++tdata)
          this.SpecialList2Obj.add(Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].OverridesType[tdata]) + ") " + this.game.Data.LandscapeTypeObj[this.game.Data.LandscapeTypeObj[this.LTNr].OverridesType[tdata]].Name, tdata);
        if (this.DetailNr > this.game.Data.LandscapeTypeObj[this.LTNr].OverridesCount)
          this.DetailNr = this.game.Data.LandscapeTypeObj[this.LTNr].OverridesCount;
        ListClass specialList2Obj = this.SpecialList2Obj;
        int detailNr = this.DetailNr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(specialList2Obj, 15, 300, detailNr, game, tHeader: "Graphic overrides", tbackbitmap: (ref local1), bbx: 10, bby: 350, overruleFont: (ref local2));
        this.SpecialList2Id = this.AddSubPart(ref tsubpart, 10, 350, 300, 288, 0);
      }
      if (this.DetailNr > -1)
      {
        this.ss = "Remove the override of this landscapetype over selected landscapetype";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
          this.killoverrideId = this.AddSubPart(ref tsubpart, 400, 410, 32, 16, 1);
        }
      }
      this.ss = "Click to add a landscapetype that is overriden by the selected landscapetype";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.addoverrideId = this.AddSubPart(ref tsubpart, 400, 430, 32, 16, 1);
      }
      this.ss = "Set the Z-order for override.. the higher the score the later another hex will be overriden.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.zoverrideId = this.AddSubPart(ref tsubpart, 400, 450, 32, 16, 1);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("z=" + Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].OverridesZ), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.zoverridetextId = this.AddSubPart(ref tsubpart1, 450, 450, 200, 20, 0);
      this.specialList3Obj = new ListClass();
      if (this.game.Data.LandscapeTypeObj[this.LTNr].OverridesCount2 > -1)
      {
        int overridesCount2 = this.game.Data.LandscapeTypeObj[this.LTNr].OverridesCount2;
        for (int tdata = 0; tdata <= overridesCount2; ++tdata)
          this.specialList3Obj.add(Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].OverridesType2[tdata]) + ") " + this.game.Data.LandscapeTypeObj[this.game.Data.LandscapeTypeObj[this.LTNr].OverridesType2[tdata]].Name, tdata);
        if (this.Detailnr2 > this.game.Data.LandscapeTypeObj[this.LTNr].OverridesCount2)
          this.Detailnr2 = this.game.Data.LandscapeTypeObj[this.LTNr].OverridesCount2;
        ListClass specialList3Obj = this.specialList3Obj;
        int detailnr2 = this.Detailnr2;
        GameClass game = this.game;
        ref Bitmap local3 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local4 = ref font;
        tsubpart1 = (SubPartClass) new ListSubPartClass(specialList3Obj, 15, 300, detailnr2, game, tHeader: "Overrides for ExtraExterior", tbackbitmap: (ref local3), bbx: 10, bby: 350, overruleFont: (ref local4));
        this.speciallist3id = this.AddSubPart(ref tsubpart1, 510, 350, 300, 288, 0);
      }
      if (this.Detailnr2 > -1)
      {
        this.ss = "Remove the override of this landscapetype over selected landscapetype";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
          this.killoverrideId2 = this.AddSubPart(ref tsubpart1, 900, 410, 32, 16, 1);
        }
      }
      this.ss = "Click to add a landscapetype that is overriden by the selected landscapetype";
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.addoverrideID2 = this.AddSubPart(ref tsubpart1, 900, 430, 32, 16, 1);
    }

    public void maketabsheetnr4()
    {
      this.CombatListObj = new ListClass();
      if (this.DetailNr < -1 | this.DetailNr > 99)
        this.DetailNr = -1;
      int index = 0;
      do
      {
        string str1 = "";
        string Expression1 = Conversion.Str((object) index) + ") " + this.game.Data.TempString[index + 400];
        if (Strings.Len(Expression1) > 20)
          Expression1 = Strings.Left(str1, 15);
        string str2 = str1 + Expression1 + Strings.Space(20 - Strings.Len(Expression1));
        string Expression2 = "AutoEntr=" + Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].DefBonus[index]));
        this.CombatListObj.add(str2 + Expression2 + Strings.Space(15 - Strings.Len(Expression2)) + ("MaxEntr=" + Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].DefBonusMax[index]))), index);
        ++index;
      }
      while (index <= 99);
      ListClass combatListObj = this.CombatListObj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(combatListObj, 11, 580, detailNr, game, true, "Entrench per Unitgroup", tbackbitmap: (ref local1), bbx: 10, bby: 360, overruleFont: (ref local2));
      this.CombatListId = this.AddSubPart(ref tsubpart, 10, 360, 580, 224, 0);
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr4b();
    }

    public void maketabsheetnr4b()
    {
      this.ss = "Click to change the AutoEntrench the selected unitgroup will receive in this landscape";
      string str1 = Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].DefBonus[this.DetailNr]));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b18id = this.AddSubPart(ref tsubpart, 610, 340, 32, 16, 1);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("AutoEntrench: " + str1, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b18textid = this.AddSubPart(ref tsubpart1, 650, 339, 400, 20, 0);
      this.ss = "Click to change the Maximum Entrench level the selected unitgroup can attain in this landscape";
      string str2 = Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.LTNr].DefBonusMax[this.DetailNr]));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b19id = this.AddSubPart(ref tsubpart2, 610, 360, 32, 16, 1);
      }
      SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("MaxEntrench: " + str2, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b19textid = this.AddSubPart(ref tsubpart3, 650, 359, 400, 20, 0);
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
            if (num1 == this.LTListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.LTNr = num2;
                this.MakeLandscapeTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddLTId)
            {
              this.game.Data.AddLandscapeType();
              this.MakeLTListGUI(this.LTNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BCloneLTId)
            {
              if (this.LTNr > -1)
              {
                this.game.Data.AddLandscapeType();
                this.game.Data.LandscapeTypeObj[this.game.Data.LandscapeTypeCounter] = this.game.Data.LandscapeTypeObj[this.LTNr].Clone();
                this.game.Data.LandscapeTypeObj[this.game.Data.LandscapeTypeCounter].LoadSprites();
                int sfTypeCounter = this.game.Data.SFTypeCounter;
                for (int index2 = 0; index2 <= sfTypeCounter; ++index2)
                {
                  this.game.Data.SFTypeObj[index2].CombatModAtt = (float[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[index2].CombatModAtt, (Array) new float[this.game.Data.LandscapeTypeCounter + 1]);
                  this.game.Data.SFTypeObj[index2].CombatModDef = (float[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[index2].CombatModDef, (Array) new float[this.game.Data.LandscapeTypeCounter + 1]);
                  this.game.Data.SFTypeObj[index2].ExtraRecon = (int[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[index2].ExtraRecon, (Array) new int[this.game.Data.LandscapeTypeCounter + 1]);
                  this.game.Data.SFTypeObj[index2].CombatModAtt[this.game.Data.LandscapeTypeCounter] = this.game.Data.SFTypeObj[index2].CombatModAtt[this.LTNr];
                  this.game.Data.SFTypeObj[index2].CombatModDef[this.game.Data.LandscapeTypeCounter] = this.game.Data.SFTypeObj[index2].CombatModDef[this.LTNr];
                  this.game.Data.SFTypeObj[index2].ExtraRecon[this.game.Data.LandscapeTypeCounter] = this.game.Data.SFTypeObj[index2].ExtraRecon[this.LTNr];
                }
                this.MakeLTListGUI(this.LTNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              int num3 = (int) Interaction.MsgBox((object) "You have to select an existing LT before you can make a clone.", Title: ((object) "Shadow Empire : Planetary Conquest"));
            }
            else
            {
              if (num1 == this.BNameId)
              {
                this.game.Data.LandscapeTypeObj[this.LTNr].Name = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest");
                this.MakeLTListGUI(this.LTNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BBuildRoadId)
              {
                this.game.Data.LandscapeTypeObj[this.LTNr].CanBuildRoad = !this.game.Data.LandscapeTypeObj[this.LTNr].CanBuildRoad;
                this.MakeLTListGUI(this.LTNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.e6id)
              {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.Color = this.game.Data.LandscapeTypeObj[this.LTNr].Red <= -1 ? Color.FromArgb((int) byte.MaxValue, 128, 128, 128) : Color.FromArgb((int) byte.MaxValue, this.game.Data.LandscapeTypeObj[this.LTNr].Red, this.game.Data.LandscapeTypeObj[this.LTNr].Green, this.game.Data.LandscapeTypeObj[this.LTNr].Blue);
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                  LandscapeTypeClass landscapeTypeClass1 = this.game.Data.LandscapeTypeObj[this.LTNr];
                  Color color = colorDialog.Color;
                  int r = (int) color.R;
                  landscapeTypeClass1.Red = r;
                  LandscapeTypeClass landscapeTypeClass2 = this.game.Data.LandscapeTypeObj[this.LTNr];
                  color = colorDialog.Color;
                  int g = (int) color.G;
                  landscapeTypeClass2.Green = g;
                  LandscapeTypeClass landscapeTypeClass3 = this.game.Data.LandscapeTypeObj[this.LTNr];
                  color = colorDialog.Color;
                  int b1 = (int) color.B;
                  landscapeTypeClass3.Blue = b1;
                }
                else
                {
                  this.game.Data.LandscapeTypeObj[this.LTNr].Red = -1;
                  this.game.Data.LandscapeTypeObj[this.LTNr].Green = -1;
                  this.game.Data.LandscapeTypeObj[this.LTNr].Blue = -1;
                }
                this.MakeLTListGUI(this.LTNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.e1id)
              {
                float num4 = (float) Conversion.Val(Interaction.InputBox("Give Road cost modifier *X (0.5 or 2 or 2.5)", "Shadow Empire : Planetary Conquest"));
                if ((double) num4 >= 0.0 & (double) num4 < 1000.0)
                {
                  this.game.Data.LandscapeTypeObj[this.LTNr].RoadCostModifier = num4;
                }
                else
                {
                  int num5 = (int) Interaction.MsgBox((object) "between 0-999 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeLTListGUI(this.LTNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.e2id)
              {
                int num6 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give AI Block", "Shadow Empire : Planetary Conquest")));
                if (num6 >= 0 & num6 < 1000)
                {
                  this.game.Data.LandscapeTypeObj[this.LTNr].AIBlock = num6;
                }
                else
                {
                  int num7 = (int) Interaction.MsgBox((object) "between 0-999 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeLTListGUI(this.LTNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.e86id)
              {
                int num8 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Obstruct", "Shadow Empire : Planetary Conquest")));
                if (num8 >= 0 & num8 <= 100)
                {
                  this.game.Data.LandscapeTypeObj[this.LTNr].Obstruction = num8;
                }
                else
                {
                  int num9 = (int) Interaction.MsgBox((object) "between 0-100 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeLTListGUI(this.LTNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.e3id)
              {
                this.game.Data.LandscapeTypeObj[this.LTNr].CanParadrop = !this.game.Data.LandscapeTypeObj[this.LTNr].CanParadrop;
                this.MakeLTListGUI(this.LTNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.OverIsTopId)
              {
                this.game.Data.LandscapeTypeObj[this.LTNr].OverIsTop[this.DetailNr] = !this.game.Data.LandscapeTypeObj[this.LTNr].OverIsTop[this.DetailNr];
                this.MakeLTListGUI(this.LTNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.e5id)
              {
                this.game.Data.LandscapeTypeObj[this.LTNr].CanAmph = !this.game.Data.LandscapeTypeObj[this.LTNr].CanAmph;
                this.MakeLTListGUI(this.LTNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.e4id)
              {
                this.game.HandyFunctionsObj.randomizeLT();
                int num10 = (int) Interaction.MsgBox((object) "Done");
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.e8id)
              {
                this.game.Data.LandscapeTypeObj[this.LTNr].Interior = !this.game.Data.LandscapeTypeObj[this.LTNr].Interior;
                this.MakeLandscapeTypeItemGUI();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.e10id)
              {
                this.game.Data.LandscapeTypeObj[this.LTNr].ExtraExteriorSame = !this.game.Data.LandscapeTypeObj[this.LTNr].ExtraExteriorSame;
                this.MakeLandscapeTypeItemGUI();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.e11id)
              {
                this.game.Data.LandscapeTypeObj[this.LTNr].BlackedOut = !this.game.Data.LandscapeTypeObj[this.LTNr].BlackedOut;
                this.MakeLandscapeTypeItemGUI();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.c6id)
              {
                this.game.Data.LandscapeTypeObj[this.LTNr].Transparent = !this.game.Data.LandscapeTypeObj[this.LTNr].Transparent;
                this.MakeLandscapeTypeItemGUI();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BSL2Id)
              {
                if (this.game.Data.LandscapeTypeObj[this.LTNr].SpecialLayer)
                {
                  this.game.Data.LandscapeTypeObj[this.LTNr].SpecialLayer6 = !this.game.Data.LandscapeTypeObj[this.LTNr].SpecialLayer6;
                }
                else
                {
                  int num11 = (int) Interaction.MsgBox((object) "You can only set if Special Layer is active", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                if (this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureID > -1)
                {
                  BitmapStore.simpleByteCacheObj[this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureID] = (SimpleByteCache) null;
                  BitmapStore.simpleByteCacheSet[this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureID] = false;
                }
                if (this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID > -1)
                {
                  BitmapStore.simpleByteCacheObj[this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID] = (SimpleByteCache) null;
                  BitmapStore.simpleByteCacheSet[this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID] = false;
                }
                this.MakeLandscapeTypeItemGUI();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BSLId)
              {
                this.game.Data.LandscapeTypeObj[this.LTNr].SpecialLayer = !this.game.Data.LandscapeTypeObj[this.LTNr].SpecialLayer;
                if (!this.game.Data.LandscapeTypeObj[this.LTNr].SpecialLayer)
                {
                  this.game.Data.LandscapeTypeObj[this.LTNr].UseSheet = false;
                  this.game.Data.LandscapeTypeObj[this.LTNr].SheetFileName = "systemgraphics/trans.bmp";
                }
                if (this.game.Data.LandscapeTypeObj[this.LTNr].SpecialLayer)
                {
                  if (Interaction.MsgBox((object) "Use full 64 sprites?", MsgBoxStyle.YesNo) == MsgBoxResult.No)
                  {
                    this.game.Data.LandscapeTypeObj[this.LTNr].SpecialLayer6 = true;
                  }
                  else
                  {
                    this.game.Data.LandscapeTypeObj[this.LTNr].SpecialLayer6 = false;
                    if (Interaction.MsgBox((object) "Use Fred SpriteSheet?", MsgBoxStyle.YesNo) == MsgBoxResult.No)
                      this.game.Data.LandscapeTypeObj[this.LTNr].UseSheet = false;
                    else
                      this.game.Data.LandscapeTypeObj[this.LTNr].UseSheet = true;
                  }
                  if (!this.game.Data.LandscapeTypeObj[this.LTNr].UseSheet)
                  {
                    if (Interaction.MsgBox((object) "Auto Load those files?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                    {
                      string extstring = Interaction.InputBox("Give a graphical extension: .jpg, .png, .bmp");
                      string dirstring = Interaction.InputBox("Give a directory name under the graphics directory", "Shadow Empire : Planetary Conquest");
                      if (File.Exists(this.game.AppPath + "graphics/" + dirstring + "/a1" + extstring))
                      {
                        this.game.Data.LandscapeTypeObj[this.LTNr].SheetFileName = "systemgraphics/trans.bmp";
                        this.game.Data.LandscapeTypeObj[this.LTNr].AutoLoadSpecial(dirstring, extstring);
                        this.MakeLTListGUI(this.LTNr);
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      int num12 = (int) Interaction.MsgBox((object) "Could not find this dir... give it like 'sea' or 'africa/desert', make sure a1 is present.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                  }
                  else
                  {
                    string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select normal sized sheet (big & small will be auto-linked)", this.game.AppPath + "graphics\\", true);
                    if (File.Exists(this.game.AppPath + "graphics/" + filename))
                    {
                      this.game.Data.LandscapeTypeObj[this.LTNr].ReplaceSpriteSheet(filename);
                      this.MakeLTListGUI(this.LTNr);
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    int num13 = (int) Interaction.MsgBox((object) "Could not find this file... ", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                }
                if (this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureID > -1)
                {
                  BitmapStore.simpleByteCacheObj[this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureID] = (SimpleByteCache) null;
                  BitmapStore.simpleByteCacheSet[this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureID] = false;
                }
                if (this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID > -1)
                {
                  BitmapStore.simpleByteCacheObj[this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID] = (SimpleByteCache) null;
                  BitmapStore.simpleByteCacheSet[this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID] = false;
                }
                this.MakeLandscapeTypeItemGUI();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.OptionsListId)
              {
                int num14 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num14 > -1)
                {
                  this.TabSheetNr = num14;
                  this.maketabsheet();
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BRemoveLtId)
              {
                this.game.Data.RemoveLandscapeType(this.LTNr);
                this.LTNr = -1;
                this.MakeLTListGUI(-1);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BasicListId)
              {
                int num15 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num15 > -1)
                {
                  this.DetailNr = num15;
                  if (this.TabSheetNr == 0)
                    this.maketabsheetnr0b();
                  if (this.TabSheetNr == 5)
                    this.maketabsheetnr5b();
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.e7id)
              {
                string str = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select New Tileset to deconstruct in 62 parts, instead of 64,... g1 is not overwritten. a1 is created empty if not present.", this.game.AppPath + "graphics\\", true);
                if (File.Exists(this.game.AppPath + "graphics/" + str))
                {
                  this.DeconstructTileset(this.game.AppPath + "graphics/" + str);
                }
                else
                {
                  int num16 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.maketabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.e7bid)
              {
                this.ConstructTileset(this.game.HandyFunctionsObj.SaveSomething("Png|*.png", "Select New Tileset to deconstruct in 62 parts, instead of 64,... g1 is not overwritten. a1 is created empty if not present.", this.game.AppPath + "graphics\\", true));
                this.maketabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.e77id)
              {
                if (Interaction.MsgBox((object) "Are you sure? (keep in mind can take a while)", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                {
                  this.ClearPixelFormat();
                  int num17 = (int) Interaction.MsgBox((object) "Finished!", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
              }
              else
              {
                if (num1 == this.i1change)
                {
                  string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select File For new sideways sprite:", this.game.AppPath + "graphics\\", true);
                  if (File.Exists(this.game.AppPath + "graphics/" + filename))
                  {
                    this.game.Data.LandscapeTypeObj[this.LTNr].ReplaceSidewaysSprite1(filename, this.DetailNr);
                  }
                  else
                  {
                    int num18 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.i2change)
                {
                  string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select File For new sideways 2 sprite:", this.game.AppPath + "graphics\\", true);
                  if (File.Exists(this.game.AppPath + "graphics/" + filename))
                  {
                    this.game.Data.LandscapeTypeObj[this.LTNr].ReplaceSidewaysSprite2(filename, this.DetailNr);
                  }
                  else
                  {
                    int num19 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.i3change)
                {
                  string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select File For new sideways 3 sprite:", this.game.AppPath + "graphics\\", true);
                  if (File.Exists(this.game.AppPath + "graphics/" + filename))
                  {
                    this.game.Data.LandscapeTypeObj[this.LTNr].ReplaceSidewaysSprite3(filename, this.DetailNr);
                  }
                  else
                  {
                    int num20 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BAddBasicId)
                {
                  string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select File For New Basic Sprite:", this.game.AppPath + "graphics\\", true);
                  string picfilename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select File For New Basic Picture:", this.game.AppPath + "graphics\\", true);
                  if (File.Exists(this.game.AppPath + "graphics/" + filename) & File.Exists(this.game.AppPath + "graphics/" + picfilename))
                  {
                    this.game.Data.LandscapeTypeObj[this.LTNr].AddBasicSprite(filename, picfilename);
                  }
                  else
                  {
                    int num21 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BChangePreHexPicId)
                {
                  string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select File For New PreHex Sprite:", this.game.AppPath + "graphics\\", true);
                  if (File.Exists(this.game.AppPath + "graphics/" + filename))
                  {
                    this.game.Data.LandscapeTypeObj[this.LTNr].ReplacePreHexPicSprite(filename);
                    if (!Information.IsNothing((object) this.game.Data.LandscapeTypeObj[this.LTNr].TempHexBitmap))
                    {
                      this.game.Data.LandscapeTypeObj[this.LTNr].TempHexBitmap.Dispose();
                      this.game.Data.LandscapeTypeObj[this.LTNr].TempHexBitmap = (Bitmap) null;
                    }
                  }
                  else
                  {
                    int num22 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BChangeBasicSpriteId)
                {
                  string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select File For New Basic Sprite:", this.game.AppPath + "graphics\\", true);
                  if (File.Exists(this.game.AppPath + "graphics/" + filename))
                  {
                    this.game.Data.LandscapeTypeObj[this.LTNr].ReplaceBasicSprite(this.DetailNr, filename);
                  }
                  else
                  {
                    int num23 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BChangeBasicSpriteId2)
                {
                  string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select File For New Basic Sprite:", this.game.AppPath + "graphics\\", true);
                  if (File.Exists(this.game.AppPath + "graphics/" + filename))
                  {
                    this.game.Data.LandscapeTypeObj[this.LTNr].ReplaceBasicSprite2(this.DetailNr, filename);
                  }
                  else
                  {
                    int num24 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.Bchangebasicspriteid3)
                {
                  string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select File For New Basic Sprite:", this.game.AppPath + "graphics\\", true);
                  if (File.Exists(this.game.AppPath + "graphics/" + filename))
                  {
                    this.game.Data.LandscapeTypeObj[this.LTNr].ReplaceBasicSprite3(this.DetailNr, filename);
                  }
                  else
                  {
                    int num25 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.e80id)
                {
                  this.game.Data.LandscapeTypeObj[this.LTNr].UsePreHexTexture = !this.game.Data.LandscapeTypeObj[this.LTNr].UsePreHexTexture;
                  if (this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureID > -1)
                  {
                    BitmapStore.simpleByteCacheObj[this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureID] = (SimpleByteCache) null;
                    BitmapStore.simpleByteCacheSet[this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureID] = false;
                  }
                  if (this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID > -1)
                  {
                    BitmapStore.simpleByteCacheObj[this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID] = (SimpleByteCache) null;
                    BitmapStore.simpleByteCacheSet[this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID] = false;
                  }
                  this.MakeLandscapeTypeItemGUI();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.e82id)
                {
                  this.game.Data.LandscapeTypeObj[this.LTNr].UsePreHexBorderTexture = !this.game.Data.LandscapeTypeObj[this.LTNr].UsePreHexBorderTexture;
                  if (this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureID > -1)
                  {
                    BitmapStore.simpleByteCacheObj[this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureID] = (SimpleByteCache) null;
                    BitmapStore.simpleByteCacheSet[this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureID] = false;
                  }
                  if (this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID > -1)
                  {
                    BitmapStore.simpleByteCacheObj[this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID] = (SimpleByteCache) null;
                    BitmapStore.simpleByteCacheSet[this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID] = false;
                  }
                  this.MakeLandscapeTypeItemGUI();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.e83id)
                {
                  this.game.Data.LandscapeTypeObj[this.LTNr].UsePreHexTextureAndRegularPreHex = !this.game.Data.LandscapeTypeObj[this.LTNr].UsePreHexTextureAndRegularPreHex;
                  this.MakeLandscapeTypeItemGUI();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.e81id)
                {
                  string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select File For New Texture:", this.game.AppPath + "graphics\\", true);
                  if (File.Exists(this.game.AppPath + "graphics/" + filename))
                  {
                    this.game.Data.LandscapeTypeObj[this.LTNr].ReplacePreHexTexture(filename);
                  }
                  else
                  {
                    int num26 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  if (this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureID > -1)
                  {
                    BitmapStore.simpleByteCacheObj[this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureID] = (SimpleByteCache) null;
                    BitmapStore.simpleByteCacheSet[this.game.Data.LandscapeTypeObj[this.LTNr].PreHexTextureID] = false;
                  }
                  if (this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID > -1)
                  {
                    BitmapStore.simpleByteCacheObj[this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID] = (SimpleByteCache) null;
                    BitmapStore.simpleByteCacheSet[this.game.Data.LandscapeTypeObj[this.LTNr].SheetSpriteID] = false;
                  }
                  this.MakeLandscapeTypeItemGUI();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BRandomId)
                {
                  int num27 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new random value >0. -1=none", "Shadow Empire : Planetary Conquest")));
                  if (num27 >= -1 & num27 < 999)
                  {
                    this.game.Data.LandscapeTypeObj[this.LTNr].BasicSpriteRandom[this.DetailNr] = num27;
                  }
                  else
                  {
                    int num28 = (int) Interaction.MsgBox((object) "between -1 and 999 plz.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BPlotLastId)
                {
                  this.game.Data.LandscapeTypeObj[this.LTNr].PlotLast[this.DetailNr] = !this.game.Data.LandscapeTypeObj[this.LTNr].PlotLast[this.DetailNr];
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.e84id)
                {
                  this.game.Data.LandscapeTypeObj[this.LTNr].PlotBeforeRiver[this.DetailNr] = !this.game.Data.LandscapeTypeObj[this.LTNr].PlotBeforeRiver[this.DetailNr];
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BChangeBasicPicId)
                {
                  string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp|Jpg|*.jpg", "Select File For New Basic Picture:", this.game.AppPath + "graphics\\", true);
                  if (File.Exists(this.game.AppPath + "graphics/" + filename))
                  {
                    this.game.Data.LandscapeTypeObj[this.LTNr].ReplacePicSprite(this.DetailNr, filename);
                  }
                  else
                  {
                    int num29 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BRemoveBasicId)
                {
                  this.game.Data.RemoveLandscapeBasicSprite(this.LTNr, this.DetailNr);
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BDrawId)
                {
                  this.game.EditObj.PencilType = 1;
                  this.game.EditObj.PencilData1 = this.LTNr;
                  this.game.EditObj.PencilData2 = this.DetailNr;
                  windowReturnClass.AddCommand(4, 13);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.SpecialListId)
                {
                  int num30 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.SubPartFlag[index1] = true;
                  if (num30 > -1)
                  {
                    this.DetailNr = num30;
                    this.maketabsheetnr2b();
                  }
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.SpecialList2Id)
                {
                  int num31 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.SubPartFlag[index1] = true;
                  if (num31 > -1)
                  {
                    this.DetailNr = num31;
                    this.maketabsheetnr3();
                  }
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.speciallist3id)
                {
                  int num32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.SubPartFlag[index1] = true;
                  if (num32 > -1)
                  {
                    this.Detailnr2 = num32;
                    this.maketabsheetnr3();
                  }
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.zoverrideId)
                {
                  int num33 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new Z-Override Value (899=the sprites of this lt are drawn after overdraw, >900=override even overdraws)", "Shadow Empire : Planetary Conquest")));
                  if (num33 >= -1 & num33 <= 999)
                  {
                    this.game.Data.LandscapeTypeObj[this.LTNr].OverridesZ = num33;
                  }
                  else
                  {
                    int num34 = (int) Interaction.MsgBox((object) "between 0-999 plz.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  this.maketabsheetnr3();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.killoverrideId)
                {
                  this.game.Data.LandscapeTypeObj[this.LTNr].RemoveOverride(this.DetailNr);
                  this.maketabsheetnr3();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.addoverrideId)
                {
                  new Form3((Form) this.formref).Initialize(this.game.Data, 2, this.LTNr);
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.killoverrideId2)
                {
                  if (this.Detailnr2 > -1)
                  {
                    this.game.Data.LandscapeTypeObj[this.LTNr].RemoveOverride2(this.Detailnr2);
                    this.maketabsheetnr3();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                }
                else
                {
                  if (num1 == this.addoverrideID2)
                  {
                    new Form3((Form) this.formref).Initialize(this.game.Data, 62, this.LTNr);
                    this.maketabsheet();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.TxtId)
                  {
                    new Form2((Form) this.formref).Initialize(this.game.Data, 10, this.LTNr);
                    this.MakeLandscapeTypeItemGUI();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.e9id)
                  {
                    new Form3((Form) this.formref).Initialize(this.game.Data, 61, this.LTNr);
                    this.maketabsheet();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.MoveListId)
                  {
                    int num35 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                    this.SubPartFlag[index1] = true;
                    if (num35 > -1)
                    {
                      this.DetailNr = num35;
                      this.maketabsheetnr1b();
                    }
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.BChangeSpecialSpriteId)
                  {
                    string filename = Interaction.InputBox("Give File Name For Replacement of selected Special Sprite #" + Conversion.Str((object) (this.DetailNr + 1)) + ":", "Shadow Empire : Planetary Conquest");
                    if (File.Exists(this.game.AppPath + "graphics/" + filename))
                    {
                      this.game.Data.LandscapeTypeObj[this.LTNr].ReplaceSpecialSprite(this.DetailNr + 1, filename);
                    }
                    else
                    {
                      int num36 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    this.maketabsheet();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.BChangeMoveCostId)
                  {
                    int num37 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Move cost#" + Conversion.Str((object) this.DetailNr) + ":", "Shadow Empire : Planetary Conquest")));
                    if (num37 > -1 & num37 < 10000)
                      this.game.Data.LandscapeTypeObj[this.LTNr].MoveCost[this.DetailNr] = num37;
                    this.maketabsheet();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.e14id)
                  {
                    if (Interaction.MsgBox((object) "Are you sure? Changes will be irreversible. All (32xX)x24, (64xX)x48 and (128xX)x96 sized .png files will be changed. Also all fred sprite sheets will be changed. formats: 192x264, 384x528 and 768x1056 ", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                    {
                      string str = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Select File. The directory it is in and all its subdirectories (1 level deep only) will be checked.", this.game.AppPath, false);
                      if (File.Exists(str))
                      {
                        int num38 = (int) Interaction.MsgBox((object) "Ok hold on... this can take some time.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        this.ClearPixels(str);
                      }
                      else
                      {
                        int num39 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    this.maketabsheet();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 != this.e14id)
                  {
                    if (num1 == this.e12id)
                    {
                      int num40 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give LTnr to use for borders for prehex sprite. -1=dont use", "Shadow Empire : Planetary Conquest")));
                      if (num40 >= -1 & num40 <= this.game.Data.LandscapeTypeCounter)
                        this.game.Data.LandscapeTypeObj[this.LTNr].PreHexBorder = num40;
                      this.MakeLandscapeTypeItemGUI();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.c4id)
                    {
                      int num41 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give LTnr to use. -1=dont use", "Shadow Empire : Planetary Conquest")));
                      if (num41 >= -1 & num41 <= this.game.Data.LandscapeTypeCounter)
                        this.game.Data.LandscapeTypeObj[this.LTNr].NavyOverride = num41;
                      this.MakeLandscapeTypeItemGUI();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.c5id)
                    {
                      int num42 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give LTnr to use. -1=dont use", "Shadow Empire : Planetary Conquest")));
                      if (num42 >= -1 & num42 <= this.game.Data.LandscapeTypeCounter)
                        this.game.Data.LandscapeTypeObj[this.LTNr].AirOverride = num42;
                      this.MakeLandscapeTypeItemGUI();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.e13id)
                    {
                      this.game.Data.LandscapeTypeObj[this.LTNr].DontShowInList = !this.game.Data.LandscapeTypeObj[this.LTNr].DontShowInList;
                      this.MakeLandscapeTypeItemGUI();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.e15id)
                    {
                      this.game.Data.LandscapeTypeObj[this.LTNr].NoPortReq = !this.game.Data.LandscapeTypeObj[this.LTNr].NoPortReq;
                      this.MakeLandscapeTypeItemGUI();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.e85id)
                    {
                      this.game.Data.LandscapeTypeObj[this.LTNr].usePreHexBorderOwnZ = !this.game.Data.LandscapeTypeObj[this.LTNr].usePreHexBorderOwnZ;
                      this.MakeLandscapeTypeItemGUI();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.e87id)
                    {
                      this.game.Data.LandscapeTypeObj[this.LTNr].FuzzyOwnerAssured = !this.game.Data.LandscapeTypeObj[this.LTNr].FuzzyOwnerAssured;
                      this.MakeLandscapeTypeItemGUI();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.BBuildGroundId)
                    {
                      new Form3((Form) this.formref).Initialize(this.game.Data, 1, this.LTNr, this.game.Data.LandscapeTypeObj[this.LTNr].BuildGround);
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.BIsSeaId)
                    {
                      this.game.Data.LandscapeTypeObj[this.LTNr].IsSea = !this.game.Data.LandscapeTypeObj[this.LTNr].IsSea;
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.CombatListId)
                    {
                      int num43 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                      this.SubPartFlag[index1] = true;
                      if (num43 > -1)
                      {
                        this.DetailNr = num43;
                        this.maketabsheet();
                      }
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.b18id)
                    {
                      float num44 = (float) Conversion.Val(Interaction.InputBox("Give new auto-entrench.", "Shadow Empire : Planetary Conquest"));
                      if ((double) num44 < 0.0 | (double) num44 > 999.0)
                      {
                        int num45 = (int) Interaction.MsgBox((object) "Between 0 and 999.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      else
                        this.game.Data.LandscapeTypeObj[this.LTNr].DefBonus[this.DetailNr] = num44;
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.b19id)
                    {
                      float num46 = (float) Conversion.Val(Interaction.InputBox("Give new max-entrench.", "Shadow Empire : Planetary Conquest"));
                      if ((double) num46 < 0.0 | (double) num46 > 999.0)
                      {
                        int num47 = (int) Interaction.MsgBox((object) "Between 0 and 999.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      else
                        this.game.Data.LandscapeTypeObj[this.LTNr].DefBonusMax[this.DetailNr] = num46;
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.c3id)
                    {
                      int num48 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new hidepts.", "Shadow Empire : Planetary Conquest")));
                      float num49;
                      if (num48 < 0 | (double) num49 > 999.0)
                      {
                        int num50 = (int) Interaction.MsgBox((object) "Between 0 and 999 please.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      else
                        this.game.Data.LandscapeTypeObj[this.LTNr].HidePts = num48;
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                  }
                }
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

    public void ConstructTileset2(string s)
    {
      string[] strArray = new string[65];
      Bitmap bitmap = new Bitmap(1280, 1280);
      bitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics objGraphics = Graphics.FromImage((Image) bitmap);
      objGraphics.CompositingMode = CompositingMode.SourceCopy;
      int num1 = 131;
      int num2 = 99;
      int index = 1;
      do
      {
        if (this.game.Data.LandscapeTypeObj[this.LTNr].LayerSpriteID[index] > 0)
          objGraphics.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.LandscapeTypeObj[this.LTNr].LayerSpriteID[index], 1), 2 + this.game.SHEETX[index] * num1, 2 + this.game.SHEETY[index] * num2);
        ++index;
      }
      while (index <= 64);
      objGraphics.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.LandscapeTypeObj[this.LTNr].PreHexPicID, 1), 2, 2 + 11 * num2);
      int num3 = 0;
      do
      {
        DrawMod.drawLine(ref objGraphics, num3 * num1, 0, num3 * num1, 2 + 11 * num2 - 2, 0, (int) byte.MaxValue, 0, (int) byte.MaxValue);
        ++num3;
      }
      while (num3 <= 6);
      int num4 = 0;
      do
      {
        DrawMod.drawLine(ref objGraphics, 0, num4 * num2, 2 + 6 * num1 - 2, num4 * num2, 0, (int) byte.MaxValue, 0, (int) byte.MaxValue);
        ++num4;
      }
      while (num4 <= 11);
      DrawMod.drawLine(ref objGraphics, 0, 12 * num2, 2 + 12 * num1 - 2, 12 * num2, 0, (int) byte.MaxValue, 0, (int) byte.MaxValue);
      FileStream fileStream = new FileStream(s, FileMode.Create);
      bitmap.Save((Stream) fileStream, ImageFormat.Png);
      fileStream.Close();
      objGraphics.Dispose();
      bitmap.Dispose();
    }

    public void ConstructTileset(string s)
    {
      string[] strArray = new string[65];
      if (Interaction.MsgBox((object) "Make alternate vicFormat?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
      {
        this.ConstructTileset2(s);
      }
      else
      {
        Bitmap bitmap1 = new Bitmap(384, 528);
        bitmap1.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics graphics1 = Graphics.FromImage((Image) bitmap1);
        graphics1.CompositingMode = CompositingMode.SourceCopy;
        int num1 = 64;
        int num2 = 48;
        int index1 = 1;
        do
        {
          graphics1.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.LandscapeTypeObj[this.LTNr].LayerSpriteID[index1]), this.game.SHEETX[index1] * num1, this.game.SHEETY[index1] * num2);
          ++index1;
        }
        while (index1 <= 64);
        FileStream fileStream1 = new FileStream(this.game.AppPath + "graphics/" + s, FileMode.Create);
        bitmap1.Save((Stream) fileStream1, ImageFormat.Png);
        fileStream1.Close();
        graphics1.Dispose();
        Bitmap bitmap2 = new Bitmap(768, 1056);
        bitmap2.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics graphics2 = Graphics.FromImage((Image) bitmap2);
        graphics2.CompositingMode = CompositingMode.SourceCopy;
        int num3 = 128;
        int num4 = 96;
        int index2 = 1;
        do
        {
          graphics2.DrawImage((Image) BitmapStore.GetBitmap(this.game.Data.LandscapeTypeObj[this.LTNr].LayerSpriteID[index2], 1), this.game.SHEETX[index2] * num3, this.game.SHEETY[index2] * num4);
          ++index2;
        }
        while (index2 <= 64);
        FileStream fileStream2 = new FileStream(this.game.AppPath + "graphics/" + s.Replace(".png", "_big.png"), FileMode.Create);
        bitmap2.Save((Stream) fileStream2, ImageFormat.Png);
        fileStream2.Close();
        graphics2.Dispose();
        bitmap2.Dispose();
      }
    }

    public void DeconstructTileset(string s)
    {
      string[] strArray = new string[65];
      int num1 = 1;
      int num2;
      do
      {
        num2 = num1;
        num1 = Strings.InStr(num1 + 1, s, "\\");
      }
      while (num1 > 0);
      string str1 = Strings.Left(s, num2 - 1);
      string str2 = ".png";
      strArray[1] = str1 + "/a1" + str2;
      strArray[2] = str1 + "/b1" + str2;
      strArray[3] = str1 + "/b2" + str2;
      strArray[4] = str1 + "/b3" + str2;
      strArray[5] = str1 + "/b4" + str2;
      strArray[6] = str1 + "/b5" + str2;
      strArray[7] = str1 + "/b6" + str2;
      strArray[8] = str1 + "/c1" + str2;
      strArray[9] = str1 + "/c7" + str2;
      strArray[10] = str1 + "/c13" + str2;
      strArray[11] = str1 + "/c11" + str2;
      strArray[12] = str1 + "/c6" + str2;
      strArray[13] = str1 + "/c2" + str2;
      strArray[14] = str1 + "/c8" + str2;
      strArray[15] = str1 + "/c14" + str2;
      strArray[16] = str1 + "/c12" + str2;
      strArray[17] = str1 + "/c3" + str2;
      strArray[18] = str1 + "/c9" + str2;
      strArray[19] = str1 + "/c15" + str2;
      strArray[20] = str1 + "/c4" + str2;
      strArray[21] = str1 + "/c10" + str2;
      strArray[22] = str1 + "/c5" + str2;
      strArray[23] = str1 + "/d1" + str2;
      strArray[24] = str1 + "/d7" + str2;
      strArray[25] = str1 + "/d13" + str2;
      strArray[26] = str1 + "/d6" + str2;
      strArray[27] = str1 + "/d15" + str2;
      strArray[28] = str1 + "/d19" + str2;
      strArray[29] = str1 + "/d12" + str2;
      strArray[30] = str1 + "/d10" + str2;
      strArray[31] = str1 + "/d18" + str2;
      strArray[32] = str1 + "/d5" + str2;
      strArray[33] = str1 + "/d2" + str2;
      strArray[34] = str1 + "/d8" + str2;
      strArray[35] = str1 + "/d14" + str2;
      strArray[36] = str1 + "/d16" + str2;
      strArray[37] = str1 + "/d20" + str2;
      strArray[38] = str1 + "/d11" + str2;
      strArray[39] = str1 + "/d3" + str2;
      strArray[40] = str1 + "/d9" + str2;
      strArray[41] = str1 + "/d17" + str2;
      strArray[42] = str1 + "/d4" + str2;
      strArray[43] = str1 + "/e5" + str2;
      strArray[44] = str1 + "/e10" + str2;
      strArray[45] = str1 + "/e4" + str2;
      strArray[46] = str1 + "/e15" + str2;
      strArray[47] = str1 + "/e9" + str2;
      strArray[48] = str1 + "/e3" + str2;
      strArray[49] = str1 + "/e6" + str2;
      strArray[50] = str1 + "/e11" + str2;
      strArray[51] = str1 + "/e13" + str2;
      strArray[52] = str1 + "/e7" + str2;
      strArray[53] = str1 + "/e12" + str2;
      strArray[54] = str1 + "/e1" + str2;
      strArray[55] = str1 + "/e14" + str2;
      strArray[56] = str1 + "/e8" + str2;
      strArray[57] = str1 + "/e2" + str2;
      strArray[58] = str1 + "/f6" + str2;
      strArray[59] = str1 + "/f5" + str2;
      strArray[60] = str1 + "/f4" + str2;
      strArray[61] = str1 + "/f3" + str2;
      strArray[62] = str1 + "/f2" + str2;
      strArray[63] = str1 + "/f1" + str2;
      strArray[64] = str1 + "/g1" + str2;
      Bitmap bitmap1 = new Bitmap(s);
      bitmap1.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Bitmap bitmap2;
      int width;
      int height;
      if (bitmap1.Width < 500)
      {
        bitmap2 = new Bitmap(64, 48);
        width = 64;
        height = 48;
      }
      else
      {
        bitmap2 = new Bitmap(128, 96);
        width = 128;
        height = 96;
      }
      bitmap2.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics = Graphics.FromImage((Image) bitmap2);
      graphics.CompositingMode = CompositingMode.SourceCopy;
      if (!File.Exists(strArray[1]))
      {
        graphics.Clear(Color.Transparent);
        FileStream fileStream = new FileStream(strArray[1], FileMode.Create);
        bitmap2.Save((Stream) fileStream, ImageFormat.Png);
        fileStream.Close();
      }
      int num3 = 0;
      do
      {
        int num4 = 0;
        do
        {
          graphics.DrawImage((Image) bitmap1, new Rectangle(0, 0, width, height), new Rectangle(num4 * width, num3 * height, width, height), GraphicsUnit.Pixel);
          int index = 2 + num3 * 6 + num4;
          if (File.Exists(strArray[index]))
            File.Delete(strArray[index]);
          FileStream fileStream = new FileStream(strArray[index], FileMode.Create);
          bitmap2.Save((Stream) fileStream, ImageFormat.Png);
          fileStream.Close();
          if (!(num3 == 10 & num4 > 1))
            ++num4;
          else
            break;
        }
        while (num4 <= 5);
        ++num3;
      }
      while (num3 <= 10);
    }

    public void ClearPixels(string s)
    {
      s = s.Replace("\\", "/");
      int num1 = 0;
      while (Strings.InStr(num1 + 1, s, "/") > 0)
        num1 = Strings.InStr(num1 + 1, s, "/");
      s = Strings.Left(s, num1 - 1);
      int Number1 = 0;
      int Number2 = 0;
      DirectoryInfo directoryInfo = new DirectoryInfo(s);
      foreach (FileInfo file in directoryInfo.GetFiles("*.png"))
      {
        if (Strings.InStr(file.Name, ".png") > 0)
        {
          ++Number1;
          this.ClearPixelsOperation(s + "/" + file.Name);
        }
      }
      foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
      {
        ++Number2;
        foreach (FileInfo file in new DirectoryInfo(s + "/" + directory.Name).GetFiles("*.png"))
        {
          if (Strings.InStr(directory.Name, ".png") > 0)
          {
            ++Number1;
            this.ClearPixelsOperation(s + "/" + directory.Name + "/" + file.Name);
          }
        }
      }
      int num2 = (int) Interaction.MsgBox((object) ("Finished. Revised " + Strings.Trim(Conversion.Str((object) Number1)) + " files in " + Strings.Trim(Conversion.Str((object) Number2)) + " directories."), Title: ((object) "Shadow Empire : Planetary Conquest"));
    }

    public void ClearPixelsOperation(string s)
    {
      Bitmap bitmap1 = (Bitmap) Image.FromStream((Stream) new MemoryStream(File.ReadAllBytes(s)));
      bitmap1.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Bitmap bitmap2;
      int num1;
      if (bitmap1.Width % 32 == 0 & bitmap1.Height == 24)
      {
        bitmap2 = BitmapStore.GetBitmap(this.game.SHADEDHEX, -1);
        num1 = 32;
      }
      else if (bitmap1.Width % 64 == 0 & bitmap1.Height == 48)
      {
        bitmap2 = BitmapStore.GetBitmap(this.game.SHADEDHEX);
        num1 = 64;
      }
      else if (bitmap1.Width % 128 == 0 & bitmap1.Height == 96)
      {
        Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.SHADEDHEX, 1);
        int num2 = 128;
        int num3 = bitmap3.Height - 1;
        for (int y = 0; y <= num3; ++y)
        {
          int num4 = bitmap1.Width - 1;
          for (int x1 = 0; x1 <= num4; ++x1)
          {
            int x2 = (num2 + x1) % num2;
            Color pixel1 = bitmap3.GetPixel(x2, y);
            Color pixel2;
            if (x2 == 0)
            {
              pixel2 = bitmap1.GetPixel(x1, y);
              if (pixel2.A > (byte) 80 & pixel2.R > (byte) 100 & pixel2.B > (byte) 100 & pixel2.G > (byte) 100)
              {
                pixel1 = bitmap1.GetPixel(x1 + 1, y);
                if (pixel1.A <= (byte) 5)
                  bitmap1.SetPixel(x1, y, Color.FromArgb(0, 0, 0, 0));
              }
              else if (pixel1.A == (byte) 0)
                bitmap1.SetPixel(x1, y, Color.FromArgb(0, 0, 0, 0));
            }
            else if (x2 == num2 - 1)
            {
              pixel2 = bitmap1.GetPixel(x1, y);
              if (pixel2.A > (byte) 80 & pixel2.R > (byte) 100 & pixel2.B > (byte) 100 & pixel2.G > (byte) 100)
              {
                pixel1 = bitmap1.GetPixel(x1 - 1, y);
                if (pixel1.A <= (byte) 5)
                  bitmap1.SetPixel(x1, y, Color.FromArgb(0, 0, 0, 0));
              }
              else if (pixel1.A == (byte) 0)
                bitmap1.SetPixel(x1, y, Color.FromArgb(0, 0, 0, 0));
            }
            else if (pixel1.A == (byte) 0)
              bitmap1.SetPixel(x1, y, Color.FromArgb(0, 0, 0, 0));
          }
        }
      }
      else
      {
        Bitmap bitmap4;
        int num5;
        int num6;
        if (bitmap1.Width == 192 & bitmap1.Height == 264)
        {
          bitmap4 = BitmapStore.GetBitmap(this.game.SHADEDHEX, -1);
          num5 = 32;
          num6 = 24;
        }
        else if (bitmap1.Width == 384 & bitmap1.Height == 528)
        {
          bitmap4 = BitmapStore.GetBitmap(this.game.SHADEDHEX);
          num5 = 64;
          num6 = 48;
        }
        else if (bitmap1.Width == 768 & bitmap1.Height == 1056)
        {
          bitmap4 = BitmapStore.GetBitmap(this.game.SHADEDHEX, 1);
          num5 = 128;
          num6 = 96;
        }
        else if (bitmap1.Width >= 768 & bitmap1.Height >= 1056 & bitmap1.Width % 128 == 0 & bitmap1.Height % 96 == 0)
        {
          bitmap4 = BitmapStore.GetBitmap(this.game.SHADEDHEX, 1);
          num5 = 128;
          num6 = 96;
        }
        else
        {
          if (!(bitmap1.Width >= 768 & bitmap1.Height == 1200 & bitmap1.Width % 128 == 0))
            return;
          bitmap4 = BitmapStore.GetBitmap(this.game.SHADEDHEX, 1);
          num5 = 128;
          num6 = 96;
        }
        int num7 = bitmap4.Height - 1;
        for (int y1 = 0; y1 <= num7; ++y1)
        {
          int num8 = bitmap1.Width - 1;
          for (int x3 = 0; x3 <= num8; ++x3)
          {
            int x4 = (num5 + x3) % num5;
            int y2 = (num6 + y1) % num6;
            Color pixel3 = bitmap4.GetPixel(x4, y2);
            Color pixel4;
            if (pixel3.A == (byte) 0)
              bitmap1.SetPixel(x3, y1, Color.FromArgb(0, 0, 0, 0));
            else if (x4 == 0)
            {
              pixel4 = bitmap1.GetPixel(x3, y1);
              if (pixel4.A > (byte) 80 & pixel4.R > (byte) 100 & pixel4.B > (byte) 100 & pixel4.G > (byte) 100)
              {
                pixel3 = bitmap1.GetPixel(x3 + 1, y1);
                if (pixel3.A <= (byte) 15)
                  bitmap1.SetPixel(x3, y1, Color.FromArgb(0, 0, 0, 0));
              }
              else if (pixel3.A == (byte) 0)
                bitmap1.SetPixel(x3, y1, Color.FromArgb(0, 0, 0, 0));
            }
            else if (x4 == num5 - 1)
            {
              pixel4 = bitmap1.GetPixel(x3, y1);
              if (pixel4.A > (byte) 80 & pixel4.R > (byte) 100 & pixel4.B > (byte) 100 & pixel4.G > (byte) 100)
              {
                pixel3 = bitmap1.GetPixel(x3 - 1, y1);
                if (pixel3.A <= (byte) 15)
                  bitmap1.SetPixel(x3, y1, Color.FromArgb(0, 0, 0, 0));
              }
              else if (pixel3.A == (byte) 0)
                bitmap1.SetPixel(x3, y1, Color.FromArgb(0, 0, 0, 0));
            }
            else if (pixel3.A == (byte) 0)
              bitmap1.SetPixel(x3, y1, Color.FromArgb(0, 0, 0, 0));
          }
        }
      }
      if (File.Exists(s))
        File.Delete(s);
      FileStream fileStream = new FileStream(s, FileMode.Create);
      bitmap1.Save((Stream) fileStream, ImageFormat.Png);
      fileStream.Close();
      bitmap1.Dispose();
      bitmap2 = (Bitmap) null;
    }

    public void ClearPixelFormat()
    {
      int counter = BitmapStore.Counter;
      int Number;
      for (int index = 0; index <= counter; ++index)
      {
        string str1 = this.game.AppPath + "graphics/" + BitmapStore.tmpFileName[index];
        if (File.Exists(str1))
          this.SetPixelFormatOperations(str1);
        string str2 = this.game.AppPath + "graphics/" + BitmapStore.MakeBigString(BitmapStore.tmpFileName[index]);
        if (File.Exists(str2))
          this.SetPixelFormatOperations(str2);
        string str3 = this.game.AppPath + "graphics/" + BitmapStore.MakeSmallString(BitmapStore.tmpFileName[index]);
        if (File.Exists(str3))
          this.SetPixelFormatOperations(str3);
        ++Number;
      }
      int num = (int) Interaction.MsgBox((object) ("Finished. Revised " + Strings.Trim(Conversion.Str((object) Number)) + " files in "), Title: ((object) "Shadow Empire : Planetary Conquest"));
    }

    public void SetPixelFormatOperations(string s)
    {
      Bitmap bitmap1 = (Bitmap) Image.FromStream((Stream) new MemoryStream(File.ReadAllBytes(s)));
      bitmap1.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height, PixelFormat.Format32bppPArgb);
      Graphics graphics = Graphics.FromImage((Image) bitmap2);
      graphics.DrawImageUnscaled((Image) bitmap1, 0, 0);
      graphics.Dispose();
      try
      {
        if (File.Exists(s))
          File.Delete(s);
        FileStream fileStream = new FileStream(s, FileMode.Create);
        if (Strings.InStr(s, ".png") > 0)
          bitmap2.Save((Stream) fileStream, ImageFormat.Png);
        else if (Strings.InStr(s, ".bmp") > 0)
          bitmap2.Save((Stream) fileStream, ImageFormat.Bmp);
        else if (Strings.InStr(s, ".jpg") > 0)
          bitmap2.Save((Stream) fileStream, ImageFormat.Jpeg);
        else
          bitmap2.Save((Stream) fileStream, ImageFormat.Png);
        fileStream.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      bitmap1.Dispose();
      bitmap2.Dispose();
    }
  }
}
