// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.LocTypeWindowClass
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
  public class LocTypeWindowClass : WindowClass
  {
    private int LocTypeListId;
    private ListClass LocTypeListObj;
    private int BAddLocTypeId;
    private int BAddLocTypeTextId;
    private int BAddLocType2Id;
    private int BAddLocTypeText2Id;
    private int BNameId;
    private int BNameTextId;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int BRemoveLocTypeId;
    private int BRemoveLocTypeTextId;
    private int BRemoveLocTypeId2;
    private int BRemoveLocTypeTextId2;
    private int BDrawId;
    private int BDrawTextId;
    private int descid;
    private int desctxtid;
    private int upgradeid;
    private int upgradetextid;
    private int repairid;
    private int repairtextid;
    private int BLTNrId;
    private int BLTTextId;
    private int BLTSpriteId;
    private int BLTSpriteTextId;
    private int BuildGroundListId;
    private ListClass BuildGroundListObj;
    private int ChangeBGId;
    private int ChangeBGText;
    private int B1Id;
    private int B1TextId;
    private int B2Id;
    private int B2TextId;
    private int B5Id;
    private int B5TextId;
    private int B6Id;
    private int B6TextId;
    private int b7id;
    private int b7textid;
    private int b8id;
    private int b8textid;
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
    private int a10Id;
    private int a10TextId;
    private int a11Id;
    private int a11TextId;
    private int a12Id;
    private int a12TextId;
    private int a13Id;
    private int a13TextId;
    private int a14Id;
    private int a14TextId;
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
    private int B21Id;
    private int B21TextId;
    private int B22Id;
    private int B22TextId;
    private int B23Id;
    private int B23TextId;
    private int B24Id;
    private int B24TextId;
    private int B25Id;
    private int B25TextId;
    private int B26Id;
    private int B26TextId;
    private int B27Id;
    private int B27TextId;
    private int B28Id;
    private int B28TextId;
    private int B29Id;
    private int B29TextId;
    private int B30Id;
    private int B30TextId;
    private int B31Id;
    private int B31TextId;
    private int B32Id;
    private int B32TextId;
    private int B33Id;
    private int B33TextId;
    private int B34Id;
    private int B34TextId;
    private int B35Id;
    private int B35TextId;
    private int B40Id;
    private int B40TextId;
    private int B41Id;
    private int B41TextId;
    private int B42Id;
    private int B42TextId;
    private int B43Id;
    private int B43TextId;
    private int B44Id;
    private int B44TextId;
    private int B45Id;
    private int B45TextId;
    private int B46Id;
    private int B46TextId;
    private int B47Id;
    private int B47TextId;
    private int B48Id;
    private int B48TextId;
    private int B49Id;
    private int B49TextId;
    private int B50Id;
    private int B50TextId;
    private int[] Bitemid;
    private int[] bitemtextid;
    private int[] Bupgid;
    private int[] bupgtextid;
    private int[] ResId;
    private int[] VarTypeId;
    private int[] VarQtyId;
    private int[] RestxtId;
    private int[] VarTypetxtId;
    private int[] VarQtytxtId;
    private int PGListId;
    private ListClass PGListObj;
    private int B3Id;
    private int B3TextId;
    private int IGListId;
    private ListClass IGListObj;
    private int B4Id;
    private int B4TextId;
    private int LTListId;
    private ListClass LTListObj;
    private int B20Id;
    private int B20TextId;
    private int LocTypeNr;
    private int TabSheetNr;
    private int DetailNr;
    private string ss;

    public LocTypeWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Location Types")
    {
      this.Bitemid = new int[5];
      this.bitemtextid = new int[5];
      this.Bupgid = new int[5];
      this.bupgtextid = new int[5];
      this.ResId = new int[5];
      this.VarTypeId = new int[5];
      this.VarQtyId = new int[5];
      this.RestxtId = new int[5];
      this.VarTypetxtId = new int[5];
      this.VarQtytxtId = new int[5];
      this.LocTypeNr = -1;
      this.TabSheetNr = -1;
      this.DetailNr = -1;
      this.MakeLocTypeListGUI(-1);
    }

    public override void DoRefresh() => this.MakeLocTypeTypeItemGUI();

    private void MakeLocTypeListGUI(int tLocTypenr)
    {
      if (this.LocTypeListId > 0)
        this.RemoveSubPart(this.LocTypeListId);
      SubPartClass tsubpart;
      if (this.game.Data.LocTypeCounter > -1)
      {
        this.LocTypeListObj = new ListClass();
        int locTypeCounter = this.game.Data.LocTypeCounter;
        for (int index = 0; index <= locTypeCounter; ++index)
          this.LocTypeListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.LocTypeObj[index].Name, index);
        ListClass locTypeListObj = this.LocTypeListObj;
        int tlistselect = tLocTypenr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        tsubpart = (SubPartClass) new ListSubPartClass(locTypeListObj, 9, 200, tlistselect, game, tHeader: "LocTypes", tbackbitmap: (ref local1), bbx: 10, bby: 50, overruleFont: (ref local2));
        this.LocTypeListId = this.AddSubPart(ref tsubpart, 10, 50, 200, 192, 0);
        this.LocTypeNr = tLocTypenr;
        this.MakeLocTypeTypeItemGUI();
      }
      else
      {
        this.LocTypeNr = tLocTypenr;
        this.MakeLocTypeTypeItemGUI();
      }
      if (this.BAddLocTypeId > 0)
        this.RemoveSubPart(this.BAddLocTypeId);
      if (this.BAddLocTypeTextId > 0)
        this.RemoveSubPart(this.BAddLocTypeTextId);
      this.ss = "Click to add another location type";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.BAddLocTypeId = this.AddSubPart(ref tsubpart, 10, 250, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      tsubpart = (SubPartClass) new TextPartClass("Add LocType", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BAddLocTypeTextId = this.AddSubPart(ref tsubpart, 50, 249, 300, 20, 0);
    }

    private void MakeLocTypeTypeItemGUI()
    {
      if (this.BNameId > 0)
        this.RemoveSubPart(this.BNameId);
      if (this.BNameTextId > 0)
        this.RemoveSubPart(this.BNameTextId);
      if (this.BRemoveLocTypeId > 0)
        this.RemoveSubPart(this.BRemoveLocTypeId);
      if (this.BRemoveLocTypeTextId > 0)
        this.RemoveSubPart(this.BRemoveLocTypeTextId);
      if (this.BRemoveLocTypeId2 > 0)
        this.RemoveSubPart(this.BRemoveLocTypeId2);
      if (this.BRemoveLocTypeTextId2 > 0)
        this.RemoveSubPart(this.BRemoveLocTypeTextId2);
      if (this.BDrawId > 0)
        this.RemoveSubPart(this.BDrawId);
      if (this.BDrawTextId > 0)
        this.RemoveSubPart(this.BDrawTextId);
      if (this.OptionsListId > 0)
        this.RemoveSubPart(this.OptionsListId);
      if (this.BAddLocType2Id > 0)
        this.RemoveSubPart(this.BAddLocType2Id);
      if (this.BAddLocTypeText2Id > 0)
        this.RemoveSubPart(this.BAddLocTypeText2Id);
      if (this.LocTypeNr > -1)
      {
        this.ss = "Click to add a copy of selected loctype to the bottom of the list";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          if (Strings.Len(this.game.Data.MasterFile) == 0)
          {
            SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
            this.BAddLocType2Id = this.AddSubPart(ref tsubpart, 10, 270, 32, 16, 1);
          }
          if (Strings.Len(this.game.Data.MasterFile) == 0)
          {
            SubPartClass tsubpart = (SubPartClass) new TextPartClass("Add Loctype Copy", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
            this.BAddLocTypeText2Id = this.AddSubPart(ref tsubpart, 50, 269, 300, 20, 0);
          }
        }
        this.ss = "Click to change the name of the loctype";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.BNameId = this.AddSubPart(ref tsubpart, 370, 50, 32, 16, 1);
        }
        SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Name: " + this.game.Data.LocTypeObj[this.LocTypeNr].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.BNameTextId = this.AddSubPart(ref tsubpart1, 410, 49, 400, 20, 0);
        this.ss = "Click to remove this loctype";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
          this.BRemoveLocTypeId = this.AddSubPart(ref tsubpart2, 10, 290, 32, 16, 1);
        }
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("Remove this L.Type", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.BRemoveLocTypeTextId = this.AddSubPart(ref tsubpart3, 50, 289, 200, 20, 0);
        }
        this.ss = "Click to remove ALL loctype";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
          this.BRemoveLocTypeId2 = this.AddSubPart(ref tsubpart4, 10, 330, 32, 16, 1);
        }
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart5 = (SubPartClass) new TextPartClass("Remove ALL", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.BRemoveLocTypeTextId2 = this.AddSubPart(ref tsubpart5, 50, 329, 200, 20, 0);
        }
        this.ss = "Click to use this loctype for drawing on the map.";
        SubPartClass tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONDRAW, tDescript: this.ss);
        this.BDrawId = this.AddSubPart(ref tsubpart6, 10, 310, 32, 16, 1);
        SubPartClass tsubpart7 = (SubPartClass) new TextPartClass("Select as pencil", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BDrawTextId = this.AddSubPart(ref tsubpart7, 50, 309, 200, 20, 0);
        this.OptionsListObj = new ListClass();
        this.OptionsListObj.add("Graphics", 0);
        this.OptionsListObj.add("Statistics", 2);
        ListClass optionsListObj = this.OptionsListObj;
        int tabSheetNr = this.TabSheetNr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart8 = (SubPartClass) new ListSubPartClass(optionsListObj, 7, 300, tabSheetNr, game, tHeader: "Property Sheets", tbackbitmap: (ref local1), bbx: 370, bby: 90, overruleFont: (ref local2));
        this.OptionsListId = this.AddSubPart(ref tsubpart8, 370, 90, 300, 160, 0);
      }
      this.maketabsheet();
    }

    private void maketabsheet()
    {
      if (this.BLTNrId > 0)
        this.RemoveSubPart(this.BLTNrId);
      if (this.BLTTextId > 0)
        this.RemoveSubPart(this.BLTTextId);
      if (this.BLTSpriteId > 0)
        this.RemoveSubPart(this.BLTSpriteId);
      if (this.BLTSpriteTextId > 0)
        this.RemoveSubPart(this.BLTSpriteTextId);
      if (this.BuildGroundListId > 0)
        this.RemoveSubPart(this.BuildGroundListId);
      if (this.ChangeBGId > 0)
        this.RemoveSubPart(this.ChangeBGId);
      if (this.ChangeBGText > 0)
        this.RemoveSubPart(this.ChangeBGText);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
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
      if (this.b7id > 0)
        this.RemoveSubPart(this.b7id);
      if (this.b7textid > 0)
        this.RemoveSubPart(this.b7textid);
      if (this.b8id > 0)
        this.RemoveSubPart(this.b8id);
      if (this.b8textid > 0)
        this.RemoveSubPart(this.b8textid);
      if (this.B9Id > 0)
        this.RemoveSubPart(this.B9Id);
      if (this.B9TextId > 0)
        this.RemoveSubPart(this.B9TextId);
      if (this.a10Id > 0)
        this.RemoveSubPart(this.a10Id);
      if (this.a10TextId > 0)
        this.RemoveSubPart(this.a10TextId);
      if (this.a11Id > 0)
        this.RemoveSubPart(this.a11Id);
      if (this.a11TextId > 0)
        this.RemoveSubPart(this.a11TextId);
      if (this.a12Id > 0)
        this.RemoveSubPart(this.a12Id);
      if (this.a12TextId > 0)
        this.RemoveSubPart(this.a12TextId);
      if (this.a13Id > 0)
        this.RemoveSubPart(this.a13Id);
      if (this.a13TextId > 0)
        this.RemoveSubPart(this.a13TextId);
      if (this.a14Id > 0)
        this.RemoveSubPart(this.a14Id);
      if (this.a14TextId > 0)
        this.RemoveSubPart(this.a14TextId);
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
      if (this.B13Id > 0)
        this.RemoveSubPart(this.B13Id);
      if (this.B13TextId > 0)
        this.RemoveSubPart(this.B13TextId);
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
      if (this.B21Id > 0)
        this.RemoveSubPart(this.B21Id);
      if (this.B21TextId > 0)
        this.RemoveSubPart(this.B21TextId);
      if (this.B22Id > 0)
        this.RemoveSubPart(this.B22Id);
      if (this.B22TextId > 0)
        this.RemoveSubPart(this.B22TextId);
      if (this.B23Id > 0)
        this.RemoveSubPart(this.B23Id);
      if (this.B23TextId > 0)
        this.RemoveSubPart(this.B23TextId);
      if (this.B24Id > 0)
        this.RemoveSubPart(this.B24Id);
      if (this.B24TextId > 0)
        this.RemoveSubPart(this.B24TextId);
      if (this.B25Id > 0)
        this.RemoveSubPart(this.B25Id);
      if (this.B25TextId > 0)
        this.RemoveSubPart(this.B25TextId);
      if (this.B26Id > 0)
        this.RemoveSubPart(this.B26Id);
      if (this.B26TextId > 0)
        this.RemoveSubPart(this.B26TextId);
      if (this.B27Id > 0)
        this.RemoveSubPart(this.B27Id);
      if (this.B27TextId > 0)
        this.RemoveSubPart(this.B27TextId);
      if (this.B28Id > 0)
        this.RemoveSubPart(this.B28Id);
      if (this.B28TextId > 0)
        this.RemoveSubPart(this.B28TextId);
      if (this.B29Id > 0)
        this.RemoveSubPart(this.B29Id);
      if (this.B29TextId > 0)
        this.RemoveSubPart(this.B29TextId);
      if (this.B30Id > 0)
        this.RemoveSubPart(this.B30Id);
      if (this.B30TextId > 0)
        this.RemoveSubPart(this.B30TextId);
      if (this.B31Id > 0)
        this.RemoveSubPart(this.B31Id);
      if (this.B31TextId > 0)
        this.RemoveSubPart(this.B31TextId);
      if (this.B32Id > 0)
        this.RemoveSubPart(this.B32Id);
      if (this.B32TextId > 0)
        this.RemoveSubPart(this.B32TextId);
      if (this.B33Id > 0)
        this.RemoveSubPart(this.B33Id);
      if (this.B33TextId > 0)
        this.RemoveSubPart(this.B33TextId);
      if (this.B34Id > 0)
        this.RemoveSubPart(this.B34Id);
      if (this.B34TextId > 0)
        this.RemoveSubPart(this.B34TextId);
      if (this.B35Id > 0)
        this.RemoveSubPart(this.B35Id);
      if (this.B35TextId > 0)
        this.RemoveSubPart(this.B35TextId);
      if (this.PGListId > 0)
        this.RemoveSubPart(this.PGListId);
      if (this.IGListId > 0)
        this.RemoveSubPart(this.IGListId);
      if (this.LTListId > 0)
        this.RemoveSubPart(this.LTListId);
      if (this.upgradeid > 0)
        this.RemoveSubPart(this.upgradeid);
      if (this.upgradetextid > 0)
        this.RemoveSubPart(this.upgradetextid);
      if (this.repairid > 0)
        this.RemoveSubPart(this.repairid);
      if (this.repairtextid > 0)
        this.RemoveSubPart(this.repairtextid);
      if (this.B40Id > 0)
        this.RemoveSubPart(this.B40Id);
      if (this.B40TextId > 0)
        this.RemoveSubPart(this.B40TextId);
      if (this.B41Id > 0)
        this.RemoveSubPart(this.B41Id);
      if (this.B41TextId > 0)
        this.RemoveSubPart(this.B41TextId);
      if (this.B42Id > 0)
        this.RemoveSubPart(this.B42Id);
      if (this.B42TextId > 0)
        this.RemoveSubPart(this.B42TextId);
      if (this.B43Id > 0)
        this.RemoveSubPart(this.B40Id);
      if (this.B43TextId > 0)
        this.RemoveSubPart(this.B43TextId);
      if (this.B44Id > 0)
        this.RemoveSubPart(this.B44Id);
      if (this.B44TextId > 0)
        this.RemoveSubPart(this.B44TextId);
      if (this.B45Id > 0)
        this.RemoveSubPart(this.B45Id);
      if (this.B45TextId > 0)
        this.RemoveSubPart(this.B45TextId);
      if (this.B46Id > 0)
        this.RemoveSubPart(this.B46Id);
      if (this.B46TextId > 0)
        this.RemoveSubPart(this.B46TextId);
      if (this.B47Id > 0)
        this.RemoveSubPart(this.B47Id);
      if (this.B47TextId > 0)
        this.RemoveSubPart(this.B47TextId);
      if (this.B48Id > 0)
        this.RemoveSubPart(this.B48Id);
      if (this.B48TextId > 0)
        this.RemoveSubPart(this.B48TextId);
      if (this.B49Id > 0)
        this.RemoveSubPart(this.B49Id);
      if (this.B49TextId > 0)
        this.RemoveSubPart(this.B49TextId);
      if (this.B50Id > 0)
        this.RemoveSubPart(this.B50Id);
      if (this.B50TextId > 0)
        this.RemoveSubPart(this.B50TextId);
      int index = 0;
      do
      {
        if (this.Bitemid[index] > 0)
          this.RemoveSubPart(this.Bitemid[index]);
        if (this.bitemtextid[index] > 0)
          this.RemoveSubPart(this.bitemtextid[index]);
        if (this.Bupgid[index] > 0)
          this.RemoveSubPart(this.Bupgid[index]);
        if (this.bupgtextid[index] > 0)
          this.RemoveSubPart(this.bupgtextid[index]);
        if (this.ResId[index] > 0)
          this.RemoveSubPart(this.ResId[index]);
        if (this.VarTypeId[index] > 0)
          this.RemoveSubPart(this.VarTypeId[index]);
        if (this.VarQtyId[index] > 0)
          this.RemoveSubPart(this.VarQtyId[index]);
        if (this.RestxtId[index] > 0)
          this.RemoveSubPart(this.RestxtId[index]);
        if (this.VarTypetxtId[index] > 0)
          this.RemoveSubPart(this.VarTypetxtId[index]);
        if (this.VarQtytxtId[index] > 0)
          this.RemoveSubPart(this.VarQtytxtId[index]);
        ++index;
      }
      while (index <= 4);
      if (this.descid > 0)
        this.RemoveSubPart(this.descid);
      if (this.desctxtid > 0)
        this.RemoveSubPart(this.desctxtid);
      if (!(this.LocTypeNr > -1 & this.TabSheetNr > -1))
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
      if (this.TabSheetNr == 5)
        this.maketabsheetnr5();
      if (this.TabSheetNr == 6)
        this.maketabsheetnr6();
      if (this.TabSheetNr != 7)
        return;
      this.maketabsheetnr7();
    }

    private void maketabsheetnr0()
    {
      this.ss = "Click to set to which landscapetype is used to set hex to when this locationtype is constructed";
      string str1 = Conversions.ToString(this.game.Data.LocTypeObj[this.LocTypeNr].OverdrawLTNr);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BLTNrId = this.AddSubPart(ref tsubpart, 10, 360, 32, 16, 1);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("LT# on construct: " + str1, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.BLTTextId = this.AddSubPart(ref tsubpart1, 50, 359, 400, 20, 0);
      SubPartClass tsubpart2;
      if (this.game.Data.LocTypeObj[this.LocTypeNr].OverdrawLTNr > -1)
      {
        this.ss = "Click to set which sprite of that landscapetype is used to set hex to when this locationtype is constructed";
        string str2 = Conversions.ToString(this.game.Data.LocTypeObj[this.LocTypeNr].OverdrawSpriteNr);
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.BLTSpriteId = this.AddSubPart(ref tsubpart3, 10, 390, 32, 16, 1);
        }
        tsubpart2 = (SubPartClass) new TextPartClass("Sprite# on construct: " + str2, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BLTSpriteTextId = this.AddSubPart(ref tsubpart2, 50, 389, 400, 20, 0);
      }
      this.ss = "Click to set the Small graphic and/or NATO graphic for the loctype.  The extra graphic will always be overdrawn on the hex.";
      string str3 = this.game.Data.LocTypeObj[this.LocTypeNr].ExtraGraphic <= 0 ? (this.game.Data.LocTypeObj[this.LocTypeNr].SmallGraphic <= 0 ? "-none-" : "small #" + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].SmallGraphic)) : "nato #" + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].ExtraGraphic);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B24Id = this.AddSubPart(ref tsubpart2, 10, 420, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("ExtraGraphic#: " + str3, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B24TextId = this.AddSubPart(ref tsubpart2, 50, 419, 400, 20, 0);
      if (this.game.Data.Product < 7)
        return;
      this.ss = "";
      string str4 = this.game.Data.LocTypeObj[this.LocTypeNr].SmallGraphicSpecialMode.ToString();
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B33Id = this.AddSubPart(ref tsubpart2, 10, 460, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("SpecialModeType: " + str4, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B33TextId = this.AddSubPart(ref tsubpart2, 50, 459, 400, 20, 0);
      string str5 = this.game.Data.LocTypeObj[this.LocTypeNr].SmallGraphicSpecialData.ToString();
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B34Id = this.AddSubPart(ref tsubpart2, 10, 480, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("SpecialModeData: " + str5, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B34TextId = this.AddSubPart(ref tsubpart2, 50, 479, 400, 20, 0);
    }

    private void maketabsheetnr0b()
    {
    }

    private void maketabsheetnr1()
    {
      this.BuildGroundListObj = new ListClass();
      int index = 0;
      do
      {
        this.BuildGroundListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.TempString[index + 100] + " = " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].BuildgroundType[index]), index);
        ++index;
      }
      while (index <= 99);
      ListClass buildGroundListObj = this.BuildGroundListObj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(buildGroundListObj, 10, 300, detailNr, game, tHeader: "Can be build on", tbackbitmap: (ref local1), bbx: 10, bby: 350, overruleFont: (ref local2));
      this.BuildGroundListId = this.AddSubPart(ref tsubpart, 10, 350, 300, 208, 0);
      if (this.DetailNr > 99)
        this.DetailNr = -1;
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr1b();
    }

    private void maketabsheetnr1b()
    {
      string txt = "Buildable? = " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].BuildgroundType[this.DetailNr]);
      if (this.ChangeBGId > 0)
        this.RemoveSubPart(this.ChangeBGId);
      if (this.ChangeBGText > 0)
        this.RemoveSubPart(this.ChangeBGText);
      this.ss = "Toggle if this loctype can be build on this groundtype";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.ChangeBGId = this.AddSubPart(ref tsubpart, 400, 350, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass(txt, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.ChangeBGText = this.AddSubPart(ref tsubpart1, 450, 350, 200, 20, 0);
    }

    private void maketabsheetnr6()
    {
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.descid = this.AddSubPart(ref tsubpart, 10, 380, 32, 16, 1);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("descript: " + this.game.Data.LocTypeObj[this.LocTypeNr].Description, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 800, 20, false, tDescript: this.ss);
      this.desctxtid = this.AddSubPart(ref tsubpart1, 50, 380, 800, 20, 0);
      int index1 = 0;
      do
      {
        this.ss = "";
        string str1 = this.game.Data.LocTypeObj[this.LocTypeNr].Research[index1] <= -1 ? "-1" : this.game.Data.ResearchObj[this.game.Data.LocTypeObj[this.LocTypeNr].Research[index1]].Name;
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          int[] resId = this.ResId;
          int index2 = index1;
          tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          int num = this.AddSubPart(ref tsubpart1, 10, 410 + index1 * 20, 32, 16, 1);
          resId[index2] = num;
        }
        int[] restxtId = this.RestxtId;
        int index3 = index1;
        tsubpart1 = (SubPartClass) new TextPartClass("Research: " + str1, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        int num1 = this.AddSubPart(ref tsubpart1, 50, 410 + index1 * 20 - 1, 200, 20, 0);
        restxtId[index3] = num1;
        this.ss = "";
        string str2 = this.game.Data.LocTypeObj[this.LocTypeNr].VarType[index1] <= -1 ? "-1" : this.game.Data.RegimeSlotName[this.game.Data.LocTypeObj[this.LocTypeNr].VarType[index1]];
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          int[] varTypeId = this.VarTypeId;
          int index4 = index1;
          tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          int num2 = this.AddSubPart(ref tsubpart1, 10, 530 + index1 * 20, 32, 16, 1);
          varTypeId[index4] = num2;
        }
        int[] varTypetxtId = this.VarTypetxtId;
        int index5 = index1;
        tsubpart1 = (SubPartClass) new TextPartClass("VarType: " + str2, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        int num3 = this.AddSubPart(ref tsubpart1, 50, 530 + index1 * 20 - 1, 200, 20, 0);
        varTypetxtId[index5] = num3;
        this.ss = "";
        string str3 = Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].VarQty[index1]);
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          int[] varQtyId = this.VarQtyId;
          int index6 = index1;
          tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          int num4 = this.AddSubPart(ref tsubpart1, 310, 530 + index1 * 20, 32, 16, 1);
          varQtyId[index6] = num4;
        }
        int[] varQtytxtId = this.VarQtytxtId;
        int index7 = index1;
        tsubpart1 = (SubPartClass) new TextPartClass("Qty: " + str3, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        int num5 = this.AddSubPart(ref tsubpart1, 350, 530 + index1 * 20 - 1, 200, 20, 0);
        varQtytxtId[index7] = num5;
        ++index1;
      }
      while (index1 <= 4);
    }

    private void maketabsheetnr2()
    {
      this.ss = "Click to toggle on/off if this locationtype has port functionality";
      if (this.game.Data.LocTypeObj[this.LocTypeNr].IsPort)
      {
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONFLAGGED, tDescript: this.ss);
          this.b7id = this.AddSubPart(ref tsubpart, 10, 430, 32, 16, 1);
        }
      }
      else if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONUNFLAGGED, tDescript: this.ss);
        this.b7id = this.AddSubPart(ref tsubpart, 10, 430, 32, 16, 1);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Is Port: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].IsPort), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 50, false, tDescript: this.ss);
      this.b7textid = this.AddSubPart(ref tsubpart1, 50, 429, 200, 20, 0);
      this.ss = "Click to toggle on/off if this locationtype has airfield functionality";
      if (this.game.Data.LocTypeObj[this.LocTypeNr].IsAirfield)
      {
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONFLAGGED, tDescript: this.ss);
          this.b8id = this.AddSubPart(ref tsubpart2, 10, 450, 32, 16, 1);
        }
      }
      else if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONUNFLAGGED, tDescript: this.ss);
        this.b8id = this.AddSubPart(ref tsubpart3, 10, 450, 32, 16, 1);
      }
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Is Airfield: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].IsAirfield), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 50, false, tDescript: this.ss);
      this.b8textid = this.AddSubPart(ref tsubpart4, 50, 449, 200, 20, 0);
      this.ss = "Click to set the number of structural points this loctype has";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B9Id = this.AddSubPart(ref tsubpart5, 10, 470, 32, 16, 1);
      }
      SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("Struc.Points: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].StructuralPts), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B9TextId = this.AddSubPart(ref tsubpart6, 50, 469, 200, 20, 0);
      this.ss = "Click to set the LandscapeType that will appear if locationtype is destroyed. -1 means its structural points can go to 0 but loc cant be destroyed. -2=it can be destroyed but LT is not morphed";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B10Id = this.AddSubPart(ref tsubpart7, 10, 490, 32, 16, 1);
      }
      SubPartClass tsubpart8 = (SubPartClass) new TextPartClass("OnDestruct: LT: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].OnDestructLT), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B10TextId = this.AddSubPart(ref tsubpart8, 50, 489, 200, 20, 0);
      SubPartClass tsubpart9;
      if (this.game.Data.LocTypeObj[this.LocTypeNr].OnDestructLT > -1)
      {
        this.ss = "Click to set the LandscapeType Sprite that will appear if locationtype is destroyed";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart10 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.B11Id = this.AddSubPart(ref tsubpart10, 10, 510, 32, 16, 1);
        }
        tsubpart9 = (SubPartClass) new TextPartClass("OnDestruct: SpriteNr: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].OnDestructSpriteNr), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.B11TextId = this.AddSubPart(ref tsubpart9, 50, 509, 200, 20, 0);
      }
      this.ss = "TopAirStack=0 means that unlimited aircraft can be stationed on airfield. >0 = ideal ammount of stack points stationed on airfield.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B31Id = this.AddSubPart(ref tsubpart9, 10, 530, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("TopAirStack: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].TopAirStack), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B31TextId = this.AddSubPart(ref tsubpart9, 50, 529, 200, 20, 0);
      this.ss = "Logistical Bonus";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B32Id = this.AddSubPart(ref tsubpart9, 10, 550, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("Logistical Bonus: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].Logistical), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B32TextId = this.AddSubPart(ref tsubpart9, 50, 549, 200, 20, 0);
      if (this.game.Data.Product >= 5)
      {
        this.ss = "Use Small Label";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.B35Id = this.AddSubPart(ref tsubpart9, 10, 570, 32, 16, 1);
        }
        tsubpart9 = (SubPartClass) new TextPartClass("Use Small Label: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].useSmallLabel), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.B35TextId = this.AddSubPart(ref tsubpart9, 50, 569, 200, 20, 0);
      }
      this.ss = "Click to give the number of autorecovering structural points per round";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B14Id = this.AddSubPart(ref tsubpart9, 410, 390, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("AutoRecoverPts: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].AutoRecoverPts), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B14TextId = this.AddSubPart(ref tsubpart9, 450, 389, 200, 20, 0);
      this.ss = "Click to set the LocationType Group this loctype belongs to";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B15Id = this.AddSubPart(ref tsubpart9, 410, 410, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("LocTypeGroup: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].LocTypeGroup), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B15TextId = this.AddSubPart(ref tsubpart9, 450, 409, 200, 20, 0);
      this.ss = "Click to toggle on/off if this loctype is buildable by a player";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B16Id = this.AddSubPart(ref tsubpart9, 410, 430, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("Buildable " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].Buildable), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B16TextId = this.AddSubPart(ref tsubpart9, 450, 429, 200, 20, 0);
      this.ss = "Click to toggle on/off if this loctypes structuralpoints can be damaged in anyway";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B19Id = this.AddSubPart(ref tsubpart9, 410, 470, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("Invincible: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].Invincible), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B19TextId = this.AddSubPart(ref tsubpart9, 450, 469, 200, 20, 0);
      this.ss = "Click to set number of supply points, expressed in prodpoints, it costs to build this loctype";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B21Id = this.AddSubPart(ref tsubpart9, 410, 490, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("SupplyCost in ProdPoints: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].SupplyCost), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B21TextId = this.AddSubPart(ref tsubpart9, 450, 489, 200, 20, 0);
      this.ss = "Click to set Slot neccessary to construct on specific hex";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B25Id = this.AddSubPart(ref tsubpart9, 410, 550, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("Slot: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].SlotType), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B25TextId = this.AddSubPart(ref tsubpart9, 450, 549, 200, 20, 0);
      this.ss = "Click to set Slot value to construct on specific hex";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B26Id = this.AddSubPart(ref tsubpart9, 410, 570, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("SlotValue: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].SlotValue), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B26TextId = this.AddSubPart(ref tsubpart9, 450, 569, 200, 20, 0);
      this.ss = "The specified LandscapeType will be used for entrench+combatmod and picture overdraw!";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B27Id = this.AddSubPart(ref tsubpart9, 410, 590, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("LT Use: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].PictureLT) + "," + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].PictureSprite), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B27TextId = this.AddSubPart(ref tsubpart9, 450, 589, 200, 20, 0);
      this.ss = "Click to set if people of new location of this type get ovverruled by a slot to set people";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B28Id = this.AddSubPart(ref tsubpart9, 410, 610, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("SetPeopleToSlotX: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].SetPeopleToSlotX), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B28TextId = this.AddSubPart(ref tsubpart9, 450, 609, 200, 20, 0);
      this.ss = "Click to set NoHQ. If true you cannot specify a HQ and only regimevar production will be executed.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B29Id = this.AddSubPart(ref tsubpart9, 710, 390, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("NoHQ: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].NoHQ), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B29TextId = this.AddSubPart(ref tsubpart9, 750, 389, 200, 20, 0);
      this.ss = "Hide from Map Editor";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B48Id = this.AddSubPart(ref tsubpart9, 710, 370, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("editorBlock: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].editorBlock), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B48TextId = this.AddSubPart(ref tsubpart9, 750, 369, 200, 20, 0);
      this.ss = "Supply Base Settings. Is it?";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B40Id = this.AddSubPart(ref tsubpart9, 710, 410, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("IsSupplyBase: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].isSupplyBase), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B40TextId = this.AddSubPart(ref tsubpart9, 750, 409, 200, 20, 0);
      this.ss = "Supply Base Settings. Max Supply Store.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B41Id = this.AddSubPart(ref tsubpart9, 710, 430, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("Max Supply Store: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].maxSupply), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B41TextId = this.AddSubPart(ref tsubpart9, 750, 429, 200, 20, 0);
      this.ss = "Supply Base Settings. Max Fuel Store";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B42Id = this.AddSubPart(ref tsubpart9, 710, 450, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("Max Fuel Store: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].maxFuel), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B42TextId = this.AddSubPart(ref tsubpart9, 750, 449, 200, 20, 0);
      this.ss = "Supply Base Settings. Max Evacuate % of max stores per turn";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B43Id = this.AddSubPart(ref tsubpart9, 710, 470, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("MaxEvacuate%: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].maxEvacuate), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B43TextId = this.AddSubPart(ref tsubpart9, 750, 469, 200, 20, 0);
      this.ss = "Supply Base Settings. Max Destroy % of max stores per turn";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B44Id = this.AddSubPart(ref tsubpart9, 710, 490, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("MaxDestroy%: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].maxDestroy), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B44TextId = this.AddSubPart(ref tsubpart9, 750, 489, 200, 20, 0);
      this.ss = "Supply Base Settings. Needs City Level";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B45Id = this.AddSubPart(ref tsubpart9, 710, 510, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("Needs City Level: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].needsCityLevel), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B45TextId = this.AddSubPart(ref tsubpart9, 750, 509, 200, 20, 0);
      this.ss = "Supply Base Settings. Has City Level ";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B46Id = this.AddSubPart(ref tsubpart9, 710, 530, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("City Level: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].cityLevel), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B46TextId = this.AddSubPart(ref tsubpart9, 750, 529, 200, 20, 0);
      this.ss = "Supply Base Settings. Outer Supply Range in AP ";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B47Id = this.AddSubPart(ref tsubpart9, 710, 550, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("SupplyRange: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].supplyRange), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B47TextId = this.AddSubPart(ref tsubpart9, 750, 549, 200, 20, 0);
      this.ss = "Supply Source. Is it?";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B50Id = this.AddSubPart(ref tsubpart9, 710, 570, 32, 16, 1);
      }
      tsubpart9 = (SubPartClass) new TextPartClass("IsSupplySource: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].isSupplySource), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B50TextId = this.AddSubPart(ref tsubpart9, 750, 569, 200, 20, 0);
    }

    private void maketabsheetnr7()
    {
      this.ss = "The priority. Highest priority will be constructed first.";
      SubPartClass tsubpart;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a10Id = this.AddSubPart(ref tsubpart, 10, 410, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("AI Priority: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].AIPriority), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.a10TextId = this.AddSubPart(ref tsubpart, 50, 409, 400, 20, 0);
      this.ss = "Points can be subtracted or added by specified event. -1=no event. Tempvar0 is set to LocType# for called event.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a11Id = this.AddSubPart(ref tsubpart, 10, 430, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("AI Prio Mod Event: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].AIEvent), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.a11TextId = this.AddSubPart(ref tsubpart, 50, 429, 400, 20, 0);
      this.ss = "If -1 no event is called and AI decideds on loc itself. If >-1 then event must set AreaXY. Tempvar0 is set to loctype# for called event.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a12Id = this.AddSubPart(ref tsubpart, 10, 450, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("AI Loc Event: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].AILocEvent), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.a12TextId = this.AddSubPart(ref tsubpart, 50, 449, 400, 20, 0);
      this.ss = "If TRUE the AI will consider to construct this locationtype if Priority>0. If FALSE the AI will not construct.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a13Id = this.AddSubPart(ref tsubpart, 10, 470, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("AI Can Free Build: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].AICanBuild), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.a13TextId = this.AddSubPart(ref tsubpart, 50, 469, 400, 20, 0);
      this.ss = "-=1 no event. This event is called directly after building of the loctype. Tempvar 0 is set as loctype for called event.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a14Id = this.AddSubPart(ref tsubpart, 10, 490, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("AIAfterBuildEvent: " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].AIAfterBuildEvent), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.a14TextId = this.AddSubPart(ref tsubpart, 50, 489, 400, 20, 0);
    }

    private void maketabsheetnr3()
    {
      this.PGListObj = new ListClass();
      if (this.DetailNr < -1 | this.DetailNr > 99)
        this.DetailNr = -1;
      int index = 0;
      do
      {
        this.PGListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.TempString[index + 200] + " = " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].PeopleGroup[index]), index);
        ++index;
      }
      while (index <= 99);
      ListClass pgListObj = this.PGListObj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(pgListObj, 6, 200, detailNr, game, tHeader: "Can build / Must Own to Prod", tbackbitmap: (ref local1), bbx: 10, bby: 350, overruleFont: (ref local2));
      this.PGListId = this.AddSubPart(ref tsubpart1, 10, 350, 200, 144, 0);
      this.ss = "Click to set all peoplegroups for all loctypes to true";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B23Id = this.AddSubPart(ref tsubpart2, 10, 520, 32, 16, 1);
      }
      SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("Set all true", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B23TextId = this.AddSubPart(ref tsubpart3, 50, 519, 200, 20, 0);
      this.maketabsheet3b();
    }

    private void maketabsheet3b()
    {
      if (this.DetailNr <= -1)
        return;
      this.ss = "Click to toggle if selected peoplegroup can build this loctype ";
      SubPartClass tsubpart;
      if (Strings.Len(this.game.Data.MasterFile) == 0 | !this.game.Data.MasterfileReadPeople)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B3Id = this.AddSubPart(ref tsubpart, 310, 350, 32, 16, 1);
      }
      if (!(Strings.Len(this.game.Data.MasterFile) == 0 | !this.game.Data.MasterfileReadPeople))
        return;
      tsubpart = (SubPartClass) new TextPartClass("Change Value", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B3TextId = this.AddSubPart(ref tsubpart, 350, 349, 200, 20, 0);
    }

    private void maketabsheetnr4()
    {
      this.IGListObj = new ListClass();
      if (this.DetailNr < -1 | this.DetailNr > 99)
        this.DetailNr = -1;
      int index = 0;
      do
      {
        this.IGListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.TempString[index + 300] + " = " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].ItemGroup[index]), index);
        ++index;
      }
      while (index <= 99);
      ListClass igListObj = this.IGListObj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(igListObj, 6, 200, detailNr, game, tHeader: "Can build itemgroup", tbackbitmap: (ref local1), bbx: 10, bby: 350, overruleFont: (ref local2));
      this.IGListId = this.AddSubPart(ref tsubpart, 10, 350, 200, 144, 0);
      this.maketabsheet4b();
    }

    private void maketabsheet4b()
    {
      if (this.DetailNr <= -1)
        return;
      this.ss = "Click to toggle on/off if selected itemgroup can be constructed in this loctype";
      SubPartClass tsubpart;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B4Id = this.AddSubPart(ref tsubpart, 310, 350, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      tsubpart = (SubPartClass) new TextPartClass("Change Value", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B4TextId = this.AddSubPart(ref tsubpart, 350, 349, 200, 20, 0);
    }

    private void maketabsheetnr5()
    {
      this.LTListObj = new ListClass();
      if (this.DetailNr < -1 | this.DetailNr > 99)
        this.DetailNr = -1;
      int index = 0;
      do
      {
        this.LTListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.TempString[index + 500] + " = " + Conversion.Str((object) this.game.Data.LocTypeObj[this.LocTypeNr].MinDistance[index]), index);
        ++index;
      }
      while (index <= 99);
      ListClass ltListObj = this.LTListObj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(ltListObj, 6, 200, detailNr, game, tHeader: "Minimum Distances", tbackbitmap: (ref local1), bbx: 10, bby: 350, overruleFont: (ref local2));
      this.LTListId = this.AddSubPart(ref tsubpart, 10, 350, 200, 144, 0);
      this.maketabsheet5b();
    }

    private void maketabsheet5b()
    {
      if (this.DetailNr <= -1)
        return;
      this.ss = "Click to set minimum distance current loctype must be away from other loctypes of selected group in order to be allowed to be build";
      SubPartClass tsubpart;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B20Id = this.AddSubPart(ref tsubpart, 310, 350, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      tsubpart = (SubPartClass) new TextPartClass("Change Value", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B20TextId = this.AddSubPart(ref tsubpart, 350, 349, 200, 20, 0);
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
label_236:
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num1 = this.SubPartID[index1];
            if (num1 == this.LocTypeListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.LocTypeNr = num2;
                this.MakeLocTypeTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddLocTypeId)
            {
              this.game.Data.AddLocType();
              this.MakeLocTypeListGUI(this.LocTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddLocType2Id)
            {
              int locTypeNr = this.LocTypeNr;
              this.game.Data.AddLocType();
              this.game.Data.LocTypeObj[this.game.Data.LocTypeCounter] = this.game.Data.LocTypeObj[locTypeNr].Clone();
              this.game.Data.LocTypeObj[this.game.Data.LocTypeCounter].LoadSprites();
              this.MakeLocTypeListGUI(this.LocTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.descid)
            {
              new Form2((Form) this.formref).Initialize(this.game.Data, 8, this.LocTypeNr);
              this.MakeLocTypeListGUI(this.LocTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BNameId)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].Name = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest", this.game.Data.LocTypeObj[this.LocTypeNr].Name);
              this.MakeLocTypeListGUI(this.LocTypeNr);
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
                this.maketabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BRemoveLocTypeId)
            {
              this.game.Data.RemoveLocType(this.LocTypeNr);
              this.MakeLocTypeListGUI(-1);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BRemoveLocTypeId2)
            {
              for (int locTypeCounter = this.game.Data.LocTypeCounter; locTypeCounter >= 0; locTypeCounter += -1)
                this.game.Data.RemoveLocType(locTypeCounter);
              this.MakeLocTypeListGUI(-1);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BDrawId)
            {
              this.game.EditObj.PencilType = 4;
              this.game.EditObj.PencilData1 = this.LocTypeNr;
              windowReturnClass.AddCommand(1, 13);
              windowReturnClass.AddCommand(2, 13);
              this.MakeLocTypeListGUI(this.LocTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B33Id)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].SmallGraphicSpecialMode = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Special Mode", "Shadow Empire : Planetary Conquest")));
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B34Id)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].SmallGraphicSpecialData = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Special DATA value", "Shadow Empire : Planetary Conquest")));
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B24Id)
            {
              int num4 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give SMALL graphic, please. (-1=none)", "Shadow Empire : Planetary Conquest")));
              if (num4 >= 0 & num4 <= this.game.Data.SmallPicCounter)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].SmallGraphic = num4;
                this.game.Data.LocTypeObj[this.LocTypeNr].ExtraGraphic = -1;
              }
              else
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].SmallGraphic = -1;
                int num5 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give NATO graphic, please. (-1=none)", "Shadow Empire : Planetary Conquest")));
                if (num5 >= -1 & num5 <= this.game.NATO.GetUpperBound(0))
                {
                  this.game.Data.LocTypeObj[this.LocTypeNr].ExtraGraphic = num5;
                }
                else
                {
                  int num6 = (int) Interaction.MsgBox((object) ("Invalid input. number between -1 and " + Conversion.Str((object) this.game.NATO.GetUpperBound(0))), Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BLTNrId)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 8, this.LocTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B29Id)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].NoHQ = !this.game.Data.LocTypeObj[this.LocTypeNr].NoHQ;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B30Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 80, this.LocTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a10Id)
            {
              int num7 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give AI Priority.", "Shadow Empire : Planetary Conquest")));
              if (num7 >= -999999 & num7 < 999999)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].AIPriority = num7;
              }
              else
              {
                int num8 = (int) Interaction.MsgBox((object) "Invalid input. number between -99999 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a11Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 75, this.LocTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a12Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 76, this.LocTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a13Id)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].AICanBuild = !this.game.Data.LocTypeObj[this.LocTypeNr].AICanBuild;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a14Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 81, this.LocTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BLTSpriteId)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 9, this.LocTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BuildGroundListId)
            {
              int num9 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num9 > -1)
              {
                this.DetailNr = num9;
                this.maketabsheetnr1b();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeBGId)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].BuildgroundType[this.DetailNr] = !this.game.Data.LocTypeObj[this.LocTypeNr].BuildgroundType[this.DetailNr];
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B40Id)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].isSupplyBase = !this.game.Data.LocTypeObj[this.LocTypeNr].isSupplyBase;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B50Id)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].isSupplySource = !this.game.Data.LocTypeObj[this.LocTypeNr].isSupplySource;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B48Id)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].editorBlock = !this.game.Data.LocTypeObj[this.LocTypeNr].editorBlock;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B23Id)
            {
              int locTypeCounter = this.game.Data.LocTypeCounter;
              for (int index2 = 0; index2 <= locTypeCounter; ++index2)
              {
                int index3 = 0;
                do
                {
                  this.game.Data.LocTypeObj[index2].PeopleGroup[index3] = true;
                  ++index3;
                }
                while (index3 <= 99);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B6Id)
            {
              int num10 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give ProdMax, please.", "Shadow Empire : Planetary Conquest")));
              if (num10 > -1 & num10 < 99999)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].MaxProd = num10;
              }
              else
              {
                int num11 = (int) Interaction.MsgBox((object) "Invalid input. number between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B41Id)
            {
              int num12 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Max Supply", "Shadow Empire : Planetary Conquest")));
              if (num12 > -1 & num12 < 99999)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].maxSupply = num12;
              }
              else
              {
                int num13 = (int) Interaction.MsgBox((object) "Invalid input. number between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B42Id)
            {
              int num14 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Max Fuel", "Shadow Empire : Planetary Conquest")));
              if (num14 > -1 & num14 < 99999)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].maxFuel = num14;
              }
              else
              {
                int num15 = (int) Interaction.MsgBox((object) "Invalid input. number between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B43Id)
            {
              int num16 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Max Evacuation %", "Shadow Empire : Planetary Conquest")));
              if (num16 >= 0 & num16 <= 100)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].maxEvacuate = num16;
              }
              else
              {
                int num17 = (int) Interaction.MsgBox((object) "Invalid input. number between 0 and 100", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B44Id)
            {
              int num18 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Max Destroy %", "Shadow Empire : Planetary Conquest")));
              if (num18 >= 0 & num18 <= 100)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].maxDestroy = num18;
              }
              else
              {
                int num19 = (int) Interaction.MsgBox((object) "Invalid input. number between 0 and 100", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B45Id)
            {
              int num20 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Needs City Level", "Shadow Empire : Planetary Conquest")));
              if (num20 > -1 & num20 < 99999)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].needsCityLevel = num20;
              }
              else
              {
                int num21 = (int) Interaction.MsgBox((object) "Invalid input. number between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B46Id)
            {
              int num22 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Is City Level", "Shadow Empire : Planetary Conquest")));
              if (num22 > -1 & num22 < 99999)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].cityLevel = num22;
              }
              else
              {
                int num23 = (int) Interaction.MsgBox((object) "Invalid input. number between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B47Id)
            {
              int num24 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Outer Supply Range", "Shadow Empire : Planetary Conquest")));
              if (num24 > -1 & num24 < 9999)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].supplyRange = num24;
              }
              else
              {
                int num25 = (int) Interaction.MsgBox((object) "Invalid input. number between 0 and 9999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B25Id)
            {
              int num26 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give slot 0-9, please. (-1=no condition)", "Shadow Empire : Planetary Conquest")));
              if (num26 >= -1 & num26 <= 9)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].SlotType = num26;
              }
              else
              {
                int num27 = (int) Interaction.MsgBox((object) "Invalid input. number between -1 and 9", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B28Id)
            {
              int num28 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give slot 0-9, please. (-1=no condition)", "Shadow Empire : Planetary Conquest")));
              if (num28 >= -1 & num28 <= 9)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].SetPeopleToSlotX = num28;
              }
              else
              {
                int num29 = (int) Interaction.MsgBox((object) "Invalid input. number between -1 and 9", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B31Id)
            {
              int num30 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give top airstack. 0=unlimited", "Shadow Empire : Planetary Conquest")));
              if (num30 >= 0 & num30 <= 99999)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].TopAirStack = num30;
              }
              else
              {
                int num31 = (int) Interaction.MsgBox((object) "Invalid input. number between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B35Id)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].useSmallLabel = !this.game.Data.LocTypeObj[this.LocTypeNr].useSmallLabel;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B32Id)
            {
              int num32 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Logistical Bonus", "Shadow Empire : Planetary Conquest")));
              if (num32 >= 0 & num32 <= 99999)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].Logistical = num32;
              }
              else
              {
                int num33 = (int) Interaction.MsgBox((object) "Invalid input. number between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B26Id)
            {
              int num34 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give slot value", "Shadow Empire : Planetary Conquest")));
              if (num34 >= -99999 & num34 <= 99999)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].SlotValue = num34;
              }
              else
              {
                int num35 = (int) Interaction.MsgBox((object) "Invalid input. number between -9999 and 9999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B27Id)
            {
              int num36 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give picture LT (-1=none)", "Shadow Empire : Planetary Conquest")));
              if (num36 >= -1 & num36 <= this.game.Data.LandscapeTypeCounter)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].PictureLT = num36;
                if (num36 > -1)
                {
                  int num37 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give sprite LT (-1=none)", "Shadow Empire : Planetary Conquest")));
                  if (num37 >= -1 & num37 <= this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.LocTypeNr].PictureLT].BasicSpriteCounter)
                  {
                    this.game.Data.LocTypeObj[this.LocTypeNr].PictureSprite = num37;
                  }
                  else
                  {
                    int num38 = (int) Interaction.MsgBox((object) "Invalid input. Not a valid sprite", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                }
                else
                  this.game.Data.LocTypeObj[this.LocTypeNr].PictureSprite = 0;
                this.maketabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              int num39 = (int) Interaction.MsgBox((object) "Invalid input. Not a valid LT", Title: ((object) "Shadow Empire : Planetary Conquest"));
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B5Id)
            {
              int num40 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give ZOrder, please.", "Shadow Empire : Planetary Conquest")));
              if (num40 > -1 & num40 < 99999)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].ZOrder = num40;
              }
              else
              {
                int num41 = (int) Interaction.MsgBox((object) "Invalid input. number between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B9Id)
            {
              int num42 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Struc.Pts, please.", "Shadow Empire : Planetary Conquest")));
              if (num42 > -1 & num42 < 99999)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].StructuralPts = num42;
              }
              else
              {
                int num43 = (int) Interaction.MsgBox((object) "Invalid input. number between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B10Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 10, this.LocTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B11Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 11, this.LocTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.upgradeid)
            {
              int num44 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give LocType # to which it can upgrade please. (-1=none)", "Shadow Empire : Planetary Conquest")));
              if (num44 >= -1 & num44 <= this.game.Data.LocTypeCounter)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].UpgradeNr = num44;
              }
              else
              {
                int num45 = (int) Interaction.MsgBox((object) "Invalid input. between -1 and LocTypeCounter plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.repairid)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].Repairable = !this.game.Data.LocTypeObj[this.LocTypeNr].Repairable;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B14Id)
            {
              int num46 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give AutoRecov.pts, please.", "Shadow Empire : Planetary Conquest")));
              if (num46 > -1 & num46 <= 99999)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].AutoRecoverPts = num46;
              }
              else
              {
                int num47 = (int) Interaction.MsgBox((object) "Invalid input. between 0 and 99999 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B15Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 12, this.LocTypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B18Id)
            {
              int num48 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give EP COst, please.", "Shadow Empire : Planetary Conquest")));
              if (num48 > -1 & num48 <= 9999)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].EPCost = num48;
              }
              else
              {
                int num49 = (int) Interaction.MsgBox((object) "Invalid input. between 0 and 9999 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B16Id)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].Buildable = !this.game.Data.LocTypeObj[this.LocTypeNr].Buildable;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B19Id)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].Invincible = !this.game.Data.LocTypeObj[this.LocTypeNr].Invincible;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b7id)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].IsPort = !this.game.Data.LocTypeObj[this.LocTypeNr].IsPort;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b8id)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].IsAirfield = !this.game.Data.LocTypeObj[this.LocTypeNr].IsAirfield;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.PGListId)
            {
              int num50 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num50 > -1)
              {
                this.DetailNr = num50;
                this.maketabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B3Id)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].PeopleGroup[this.DetailNr] = !this.game.Data.LocTypeObj[this.LocTypeNr].PeopleGroup[this.DetailNr];
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.IGListId)
            {
              int num51 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num51 > -1)
              {
                this.DetailNr = num51;
                this.maketabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B4Id)
            {
              this.game.Data.LocTypeObj[this.LocTypeNr].ItemGroup[this.DetailNr] = !this.game.Data.LocTypeObj[this.LocTypeNr].ItemGroup[this.DetailNr];
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.LTListId)
            {
              int num52 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num52 > -1)
              {
                this.DetailNr = num52;
                this.maketabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B20Id)
            {
              int num53 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give LocTypeGroup, please.", "Shadow Empire : Planetary Conquest")));
              if (num53 >= -1 & num53 <= 99)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].MinDistance[this.DetailNr] = num53;
              }
              else
              {
                int num54 = (int) Interaction.MsgBox((object) "Invalid input. between -1 and 99 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B21Id)
            {
              int num55 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give SupplyCost in ProdPoints please", "Shadow Empire : Planetary Conquest")));
              if (num55 >= -1 & num55 <= 99999)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].SupplyCost = num55;
              }
              else
              {
                int num56 = (int) Interaction.MsgBox((object) "Invalid input. between -1 and 99999 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B22Id)
            {
              int num57 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give PolPoint cost please", "Shadow Empire : Planetary Conquest")));
              if (num57 >= 0 & num57 <= 99999)
              {
                this.game.Data.LocTypeObj[this.LocTypeNr].PPCost = num57;
              }
              else
              {
                int num58 = (int) Interaction.MsgBox((object) "Invalid input. between 0 and 99999 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            int tnr2 = 0;
            while (this.SubPartID[index1] != this.ResId[tnr2])
            {
              if (this.SubPartID[index1] == this.VarTypeId[tnr2])
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 73, this.LocTypeNr, tnr2);
                this.maketabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.SubPartID[index1] == this.VarQtyId[tnr2])
              {
                int num59 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give qty", "Shadow Empire : Planetary Conquest")));
                this.game.Data.LocTypeObj[this.LocTypeNr].VarQty[tnr2] = num59;
                this.maketabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              ++tnr2;
              if (tnr2 > 4)
                goto label_236;
            }
            new Form3((Form) this.formref).Initialize(this.game.Data, 72, this.LocTypeNr, tnr2);
            this.maketabsheet();
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
