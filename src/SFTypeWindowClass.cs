// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SFTypeWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class SFTypeWindowClass : WindowClass
  {
    private int SFtypeListId;
    private ListClass SFtypeListObj;
    private int LibListId;
    private int LibNr;
    private ListClass LibListObj;
    private int BAddSFtypeId;
    private int BAddSFtypeTextId;
    private int BAddSFtype2Id;
    private int BAddSFtypeText2Id;
    private int BNameId;
    private int BNameTextId;
    private int BRemoveSFtypeId;
    private int BRemoveSFtypeTextId;
    private int BRemoveSFtypeId2;
    private int BRemoveSFtypeTextId2;
    private ListClass TabListObj;
    private int TabListId;
    private int BSymbolId;
    private int BChangeSymbolId;
    private int BSymbol2Id;
    private int BChangeSymbol2Id;
    private int BPicId;
    private int bChangePicId;
    private int BSymbolGroupId;
    private int BSymbolGroupTextId;
    private int BSymbolWeightId;
    private int BSymbolWeightTextId;
    private int BSymbolOverRuleId;
    private int BSymbolOverRuleTextId;
    private int BMoveTypeId;
    private int BMoveTypeTextId;
    private int B1Id;
    private int B1TextId;
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
    private int B8Id;
    private int B8TextId;
    private int b9id;
    private int b9textid;
    private int b18id;
    private int b18textid;
    private int b10id;
    private int b10textid;
    private int b11id;
    private int b11textid;
    private int b12id;
    private int b12textid;
    private int b13id;
    private int b13textid;
    private int b14id;
    private int b14textid;
    private int b15id;
    private int b15textid;
    private int b16id;
    private int b16textid;
    private int b17id;
    private int b17textid;
    private int b19id;
    private int b19textid;
    private int b20id;
    private int b20textid;
    private int b21id;
    private int b21textid;
    private int b22id;
    private int b22textid;
    private int b23id;
    private int b23textid;
    private int b24id;
    private int b24textid;
    private int b25id;
    private int b25textid;
    private int b26id;
    private int b26textid;
    private int b27id;
    private int b27textid;
    private int b28id;
    private int b28textid;
    private int b29id;
    private int b29textid;
    private int b30id;
    private int b30textid;
    private int b31id;
    private int b31textid;
    private int b32id;
    private int b32textid;
    private int b33id;
    private int b33textid;
    private int b34id;
    private int b34textid;
    private int b35id;
    private int b35textid;
    private int b36id;
    private int b36textid;
    private int b37id;
    private int b37textid;
    private int b38id;
    private int b38textid;
    private int b39id;
    private int b39textid;
    private int a1id;
    private int a1textid;
    private int a2id;
    private int a2textid;
    private int a3id;
    private int a3textid;
    private int a4id;
    private int a4textid;
    private int a5id;
    private int a5textid;
    private int a6id;
    private int a6textid;
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
    private int c7id;
    private int c7textid;
    private int c8id;
    private int c8textid;
    private int c11id;
    private int c11textid;
    private int c12id;
    private int c12textid;
    private int c13id;
    private int c13textid;
    private int c14id;
    private int c14textid;
    private int c15id;
    private int c15textid;
    private int c16id;
    private int c16textid;
    private int c17id;
    private int c17textid;
    private int c18id;
    private int c18textid;
    private int c19id;
    private int c19textid;
    private int c20id;
    private int c20textid;
    private int c21id;
    private int c21textid;
    private int d1id;
    private int d1textid;
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
    private int f1id;
    private int f1textid;
    private int f2id;
    private int f2textid;
    private int f3id;
    private int f3textid;
    private int g1id;
    private int g1textid;
    private int g2id;
    private int g2textid;
    private int g3id;
    private int g3textid;
    private int g4id;
    private int g4textid;
    private int g5id;
    private int g5textid;
    private int g6id;
    private int g6textid;
    private int g7id;
    private int g7textid;
    private int g8id;
    private int g8textid;
    private int g9id;
    private int g9textid;
    private int g10id;
    private int g10textid;
    private int g11id;
    private int g11textid;
    private int g12id;
    private int g12textid;
    private int g13id;
    private int g13textid;
    private int g14id;
    private int g14textid;
    private int g15id;
    private int g15textid;
    private int g16id;
    private int g16textid;
    private int g17id;
    private int g17textid;
    private int g18id;
    private int g18textid;
    private int g19id;
    private int g19textid;
    private int g20id;
    private int g20textid;
    private int g21id;
    private int g21textid;
    private int g22id;
    private int g22textid;
    private int g23id;
    private int g23textid;
    private int g24id;
    private int g24textid;
    private int h1id;
    private int h1textid;
    private int h2id;
    private int h2textid;
    private int h3id;
    private int h3textid;
    private int h4id;
    private int h4textid;
    private int h5id;
    private int h5textid;
    private int h6id;
    private int h6textid;
    private int p1id;
    private int p1textid;
    private int p2id;
    private int p2textid;
    private int p3id;
    private int p3textid;
    private int p4id;
    private int p4textid;
    private int p5id;
    private int p5textid;
    private int p6id;
    private int p6textid;
    private int p7id;
    private int p7textid;
    private int p8id;
    private int p8textid;
    private int p9id;
    private int p9textid;
    private int vp1id;
    private int vp1textid;
    private int vp2id;
    private int vp2textid;
    private int vp3id;
    private int vp3textid;
    private int vp4id;
    private int vp4textid;
    private int vp5id;
    private int vp5textid;
    private int vp6id;
    private int vp6textid;
    private int t1id;
    private int t1textid;
    private int w1id;
    private int w1textid;
    private int w1bid;
    private int w1btextid;
    private int w2id;
    private int w2textid;
    private int w2bid;
    private int w2btextid;
    private int w3id;
    private int w3textid;
    private int w133id;
    private int w133textid;
    private int w4id;
    private int w4textid;
    private int w5id;
    private int w5textid;
    private int w6id;
    private int w6textid;
    private int x1id;
    private int x1textid;
    private int x2id;
    private int x2textid;
    private int x3id;
    private int x3textid;
    private int x4id;
    private int x4textid;
    private int x5id;
    private int x5textid;
    private int x6id;
    private int x6textid;
    private int w7id;
    private int w7textid;
    private int w8id;
    private int w8textid;
    private int w9id;
    private int w9textid;
    private int w9bid;
    private int w9btextid;
    private int v1id;
    private int v1textid;
    private int v2id;
    private int v2textid;
    private int j1id;
    private int j1textid;
    private int j2id;
    private int j2textid;
    private int v3id;
    private int v3textid;
    private int v4id;
    private int v4textid;
    private int v5id;
    private int v5textid;
    private int v6id;
    private int v6textid;
    private int v7id;
    private int v7textid;
    private int v8id;
    private int v8textid;
    private int v9id;
    private int v9textid;
    private int copyid;
    private int copytextid;
    private int v10id;
    private int v10textid;
    private int v11id;
    private int v11textid;
    private int v12id;
    private int v12textid;
    private int v13id;
    private int v13textid;
    private int v14id;
    private int v14textid;
    private int v15id;
    private int v15textid;
    private int v16id;
    private int v16textid;
    private int v17id;
    private int v17textid;
    private int v18id;
    private int v18textid;
    private int v19id;
    private int v19textid;
    private int v20id;
    private int v20textid;
    private int v21id;
    private int v21textid;
    private int v22id;
    private int v22textid;
    private int v23id;
    private int v23textid;
    private int w10id;
    private int w10textid;
    private int w11id;
    private int w11textid;
    private int w12id;
    private int w12textid;
    private int w13id;
    private int w13textid;
    private int w14id;
    private int w14textid;
    private int w15id;
    private int w15textid;
    private int w16id;
    private int w16textid;
    private int w17id;
    private int w17textid;
    private int y1id;
    private int y1textid;
    private int y2id;
    private int y2textid;
    private int y3id;
    private int y3textid;
    private int y4id;
    private int y5id;
    private int clibid;
    private int clibtextid;
    private int y6id;
    private int y6textid;
    private int y7id;
    private int y7btextid;
    private int y7textid;
    private int y8id;
    private int y8btextid;
    private int y8textid;
    private int PGListId;
    private int ExtraListId;
    private int LogoListId;
    private int PreventListId;
    private int VariantListId;
    private ListClass PGListObj;
    private ListClass ExtraListObj;
    private ListClass LogoListObj;
    private ListClass PreventListObj;
    private ListClass VariantListObj;
    private int CombatListId;
    private int combatlist3id;
    private int combatlist4id;
    private ListClass CombatListObj;
    private int CombatList2Id;
    private int ResListId;
    private ListClass CombatList2Obj;
    private ListClass CombatList3Obj;
    private ListClass CombatList4Obj;
    private ListClass ResListObj;
    private int SFtypeNr;
    private int TabSheetNr;
    private int detailnr2;
    private int detailnr;
    private string ss;

    public SFTypeWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Subformation Types")
    {
      this.SFtypeNr = -1;
      this.LibNr = -1;
      this.MakeSFtypeListGUI(-1);
      this.TabSheetNr = -1;
      this.detailnr = -1;
      this.detailnr2 = -1;
      tGame.EditObj.TempSelected = -1;
      tGame.EditObj.TempCopy = -1;
    }

    public override void DoRefresh()
    {
      if (this.game.EditObj.TempSelected > -1)
      {
        this.SFtypeNr = this.game.EditObj.TempSelected;
        this.detailnr = this.SFtypeNr;
        this.game.EditObj.TempSelected = -1;
      }
      if (this.game.EditObj.TempCopy > -1)
      {
        SFTypeClass sfTypeClass = this.game.Data.SFTypeObj[this.SFtypeNr].Clone();
        this.game.Data.SFTypeObj[this.SFtypeNr] = this.game.Data.SFTypeObj[this.game.EditObj.TempCopy].Clone();
        this.game.Data.SFTypeObj[this.SFtypeNr].Name = sfTypeClass.Name;
        this.game.Data.SFTypeObj[this.SFtypeNr].ExtraCounter = sfTypeClass.ExtraCounter;
        this.game.Data.SFTypeObj[this.SFtypeNr].ExtraCode = (int[]) sfTypeClass.ExtraCode.Clone();
        this.game.Data.SFTypeObj[this.SFtypeNr].ExtraName = (string[]) sfTypeClass.ExtraName.Clone();
        this.game.Data.SFTypeObj[this.SFtypeNr].ExtraPicFileName = (string[]) sfTypeClass.ExtraPicFileName.Clone();
        this.game.Data.SFTypeObj[this.SFtypeNr].ExtraSidewaysFileName = (string[]) sfTypeClass.ExtraSidewaysFileName.Clone();
        this.game.Data.SFTypeObj[this.SFtypeNr].ExtraSymbolColBigFileName = (string[]) sfTypeClass.ExtraSymbolColBigFileName.Clone();
        this.game.Data.SFTypeObj[this.SFtypeNr].ExtraSymbolColBigFileName2 = (string[]) sfTypeClass.ExtraSymbolColBigFileName2.Clone();
        this.game.Data.SFTypeObj[this.SFtypeNr].ExtraSymbolFileName = (string[]) sfTypeClass.ExtraSymbolFileName.Clone();
        this.game.Data.SFTypeObj[this.SFtypeNr].ExtraSymbolFileName2 = (string[]) sfTypeClass.ExtraSymbolFileName2.Clone();
        this.game.Data.SFTypeObj[this.SFtypeNr].ExtraPicSpriteID = (int[]) sfTypeClass.ExtraPicSpriteID.Clone();
        this.game.Data.SFTypeObj[this.SFtypeNr].ExtraSidewaysSpriteID = (int[]) sfTypeClass.ExtraSidewaysSpriteID.Clone();
        this.game.Data.SFTypeObj[this.SFtypeNr].ExtraSymbolColBigSprite2ID = (int[]) sfTypeClass.ExtraSymbolColBigSprite2ID.Clone();
        this.game.Data.SFTypeObj[this.SFtypeNr].ExtraSymbolColBigSpriteID = (int[]) sfTypeClass.ExtraSymbolColBigSpriteID.Clone();
        this.game.Data.SFTypeObj[this.SFtypeNr].ExtraSymbolSprite2ID = (int[]) sfTypeClass.ExtraSymbolSprite2ID.Clone();
        this.game.Data.SFTypeObj[this.SFtypeNr].ExtraSymbolSpriteID = (int[]) sfTypeClass.ExtraSymbolSpriteID.Clone();
        this.game.Data.SFTypeObj[this.SFtypeNr].PicFileName = sfTypeClass.PicFileName;
        this.game.Data.SFTypeObj[this.SFtypeNr].SidewaysFileName = sfTypeClass.SidewaysFileName;
        this.game.Data.SFTypeObj[this.SFtypeNr].SymbolColBigFileName = sfTypeClass.SymbolColBigFileName;
        this.game.Data.SFTypeObj[this.SFtypeNr].SymbolColBigFileName2 = sfTypeClass.SymbolColBigFileName2;
        this.game.Data.SFTypeObj[this.SFtypeNr].SymbolFileName = sfTypeClass.SymbolFileName;
        this.game.Data.SFTypeObj[this.SFtypeNr].SymbolFileName2 = sfTypeClass.SymbolFileName2;
        this.game.Data.SFTypeObj[this.SFtypeNr].Id = sfTypeClass.Id;
        this.game.Data.SFTypeObj[this.SFtypeNr].LoadSprites();
        this.game.EditObj.TempCopy = -1;
      }
      this.MakeSFtypeListGUI(this.SFtypeNr);
      this.MakeSFtypeTypeItemGUI();
    }

    private void MakeSFtypeListGUI(int tSFtypenr)
    {
      if (this.SFtypeListId > 0)
        this.RemoveSubPart(this.SFtypeListId);
      this.LibListObj = new ListClass();
      this.LibListObj.add("All", -2);
      int num1 = -1;
      int num2 = 0;
      int libraryCounter = this.game.Data.LibraryCounter;
      for (int index = 0; index <= libraryCounter; ++index)
      {
        ++num2;
        if (this.LibNr == index)
          num1 = num2;
        this.LibListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.LibraryObj[index].name, index);
      }
      if (this.LibNr == -1)
        num1 = 0;
      ListClass libListObj = this.LibListObj;
      int tlistselect1 = num1;
      GameClass game1 = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(libListObj, 9, 200, tlistselect1, game1, tHeader: "Libraries", tbackbitmap: (ref local1), bbx: 10, bby: 38, overruleFont: (ref local2));
      this.LibListId = this.AddSubPart(ref tsubpart1, 10, 38, 200, 192, 0);
      this.MakeSFtypeTypeItemGUI();
      int num3 = -1;
      int num4 = -1;
      if (this.game.Data.SFTypeCounter > -1)
      {
        this.SFtypeListObj = new ListClass();
        int sfTypeCounter = this.game.Data.SFTypeCounter;
        for (int index = 0; index <= sfTypeCounter; ++index)
        {
          if (this.LibNr == -1 | this.LibNr == this.game.Data.SFTypeObj[index].LibId.libSlot)
          {
            ++num4;
            if (index == tSFtypenr)
              num3 = num4;
            this.SFtypeListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.SFTypeObj[index].Name + "(id=" + this.game.Data.SFTypeObj[index].Id.ToString() + ")", index);
          }
        }
        ListClass sftypeListObj = this.SFtypeListObj;
        int tlistselect2 = num3;
        GameClass game2 = this.game;
        ref Bitmap local3 = ref this.OwnBitmap;
        font = (Font) null;
        ref Font local4 = ref font;
        SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(sftypeListObj, 9, 200, tlistselect2, game2, tHeader: "SFTypes", tbackbitmap: (ref local3), bbx: 220, bby: 38, overruleFont: (ref local4));
        this.SFtypeListId = this.AddSubPart(ref tsubpart2, 220, 38, 200, 192, 0);
        this.SFtypeNr = tSFtypenr;
        this.MakeSFtypeTypeItemGUI();
      }
      else
      {
        this.SFtypeNr = tSFtypenr;
        this.MakeSFtypeTypeItemGUI();
      }
      if (this.BAddSFtypeId > 0)
        this.RemoveSubPart(this.BAddSFtypeId);
      if (this.BAddSFtypeTextId > 0)
        this.RemoveSubPart(this.BAddSFtypeTextId);
      if (this.BAddSFtype2Id > 0)
        this.RemoveSubPart(this.BAddSFtype2Id);
      if (this.BAddSFtypeText2Id > 0)
        this.RemoveSubPart(this.BAddSFtypeText2Id);
      this.ss = "Add a new SFType. Will be added at the end of the list.";
      SubPartClass tsubpart3;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.BAddSFtypeId = this.AddSubPart(ref tsubpart3, 10, 270, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new TextPartClass("Add SFtype Type", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 170, 20, false, tDescript: this.ss);
        this.BAddSFtypeTextId = this.AddSubPart(ref tsubpart3, 50, 269, 170, 20, 0);
      }
      if (this.SFtypeNr <= -1)
        return;
      this.ss = "Add a copy of the currently selected SFType.. will be added at the end of the list.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.BAddSFtype2Id = this.AddSubPart(ref tsubpart3, 10, 250, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      tsubpart3 = (SubPartClass) new TextPartClass("Add SFtype Copy", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 170, 20, false, tDescript: this.ss);
      this.BAddSFtypeText2Id = this.AddSubPart(ref tsubpart3, 50, 249, 170, 20, 0);
    }

    private void MakeSFtypeTypeItemGUI()
    {
      if (this.BNameId > 0)
        this.RemoveSubPart(this.BNameId);
      if (this.BNameTextId > 0)
        this.RemoveSubPart(this.BNameTextId);
      if (this.BRemoveSFtypeId > 0)
        this.RemoveSubPart(this.BRemoveSFtypeId);
      if (this.BRemoveSFtypeTextId > 0)
        this.RemoveSubPart(this.BRemoveSFtypeTextId);
      if (this.BRemoveSFtypeId2 > 0)
        this.RemoveSubPart(this.BRemoveSFtypeId2);
      if (this.BRemoveSFtypeTextId2 > 0)
        this.RemoveSubPart(this.BRemoveSFtypeTextId2);
      if (this.TabListId > 0)
        this.RemoveSubPart(this.TabListId);
      if (this.g22id > 0)
        this.RemoveSubPart(this.g22id);
      if (this.g22textid > 0)
        this.RemoveSubPart(this.g22textid);
      if (this.x1id > 0)
        this.RemoveSubPart(this.x1id);
      if (this.x1textid > 0)
        this.RemoveSubPart(this.x1textid);
      if (this.x2id > 0)
        this.RemoveSubPart(this.x2id);
      if (this.x2textid > 0)
        this.RemoveSubPart(this.x2textid);
      if (this.x3id > 0)
        this.RemoveSubPart(this.x3id);
      if (this.x3textid > 0)
        this.RemoveSubPart(this.x3textid);
      if (this.x4id > 0)
        this.RemoveSubPart(this.x4id);
      if (this.x4textid > 0)
        this.RemoveSubPart(this.x4textid);
      if (this.x5id > 0)
        this.RemoveSubPart(this.x5id);
      if (this.x5textid > 0)
        this.RemoveSubPart(this.x5textid);
      if (this.x6id > 0)
        this.RemoveSubPart(this.x6id);
      if (this.x6textid > 0)
        this.RemoveSubPart(this.x6textid);
      if (this.clibid > 0)
        this.RemoveSubPart(this.clibid);
      if (this.clibtextid > 0)
        this.RemoveSubPart(this.clibtextid);
      if (this.SFtypeNr > -1)
      {
        if (this.SFtypeNr < this.game.Data.SFTypeCounter)
        {
          this.ss = "Move up";
          if (Strings.Len(this.game.Data.MasterFile) == 0)
          {
            SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONDOWN, tDescript: this.ss);
            this.x4id = this.AddSubPart(ref tsubpart, 250, 290, 32, 16, 1);
          }
        }
        if (this.SFtypeNr > 0)
        {
          this.ss = "Move down";
          if (Strings.Len(this.game.Data.MasterFile) == 0)
          {
            SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONUP, tDescript: this.ss);
            this.x5id = this.AddSubPart(ref tsubpart, 300, 290, 32, 16, 1);
          }
        }
        this.ss = "Replace all SFs with this Type with another SFType";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
          this.x6id = this.AddSubPart(ref tsubpart, 250, 230, 32, 16, 1);
        }
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new TextPartClass("Replace all instances", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.x6textid = this.AddSubPart(ref tsubpart, 290, 229, 200, 20, 0);
        }
        this.ss = "Set Library for this SfType";
        string txt = "Set Lib (.LibSlot=" + this.game.Data.SFTypeObj[this.SFtypeNr].LibId.libSlot.ToString() + ".LibId=" + this.game.Data.SFTypeObj[this.SFtypeNr].LibId.id.ToString() + ")";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
          this.clibid = this.AddSubPart(ref tsubpart, 500, 230, 32, 16, 1);
        }
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new TextPartClass(txt, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.clibtextid = this.AddSubPart(ref tsubpart, 550, 229, 300, 20, 0);
        }
        this.ss = "Add a new SFType";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
          this.x1id = this.AddSubPart(ref tsubpart, 250, 270, 32, 16, 1);
        }
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new TextPartClass("Select SFType to View", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.x1textid = this.AddSubPart(ref tsubpart, 290, 269, 200, 20, 0);
        }
        this.ss = "Copy the stats from a selected other SFType";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
          this.x2id = this.AddSubPart(ref tsubpart, 250, 250, 32, 16, 1);
        }
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new TextPartClass("Copy Stats from other SFType", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.x2textid = this.AddSubPart(ref tsubpart, 290, 249, 200, 20, 0);
        }
        this.ss = "Click to change the name of this SFType";
        if (!Information.IsNothing((object) this.game.Data.SFTypeObj[this.SFtypeNr].LibId))
          this.ss = this.ss + " lib: LibSlot: " + this.game.Data.SFTypeObj[this.SFtypeNr].LibId.libSlot.ToString() + ", id: " + this.game.Data.SFTypeObj[this.SFtypeNr].LibId.id.ToString();
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.BNameId = this.AddSubPart(ref tsubpart, 10, 230, 32, 16, 1);
        }
        SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Name: " + this.game.Data.SFTypeObj[this.SFtypeNr].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 180, 20, false, tDescript: this.ss);
        this.BNameTextId = this.AddSubPart(ref tsubpart1, 50, 230, 400, 20, 0);
        this.ss = "Click to remove this SFType from the list";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
          this.BRemoveSFtypeId = this.AddSubPart(ref tsubpart2, 10, 290, 32, 16, 1);
        }
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("Remove this SFType", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.BRemoveSFtypeTextId = this.AddSubPart(ref tsubpart3, 50, 289, 200, 20, 0);
        }
        this.ss = "Click All SFTypes from the list";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
          this.BRemoveSFtypeId2 = this.AddSubPart(ref tsubpart4, 10, 310, 32, 16, 1);
        }
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart5 = (SubPartClass) new TextPartClass("Remove ALL", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.BRemoveSFtypeTextId2 = this.AddSubPart(ref tsubpart5, 50, 309, 200, 20, 0);
        }
        this.TabListObj = new ListClass();
        int num1 = -1;
        this.TabListObj.add("Graphics", 0);
        int num2 = num1 + 1;
        int num3;
        if (this.TabSheetNr == 0)
          num3 = num2;
        this.TabListObj.add("Statistics 1", 1);
        int num4 = num2 + 1;
        if (this.TabSheetNr == 1)
          num3 = num4;
        this.TabListObj.add("Statistics 2", 2);
        int num5 = num4 + 1;
        if (this.TabSheetNr == 2)
          num3 = num5;
        this.TabListObj.add("Combat Detail Stats", 3);
        int num6 = num5 + 1;
        if (this.TabSheetNr == 3)
          num3 = num6;
        this.TabListObj.add("Combat Landscape Mods", 4);
        int num7 = num6 + 1;
        if (this.TabSheetNr == 4)
          num3 = num7;
        this.TabListObj.add("AI Role Scores", 6);
        int num8 = num7 + 1;
        if (this.TabSheetNr == 6)
          num3 = num8;
        this.TabListObj.add("Logo Values", 7);
        int num9 = num8 + 1;
        if (this.TabSheetNr == 7)
          num3 = num9;
        this.TabListObj.add("Prevent List", 8);
        int num10 = num9 + 1;
        if (this.TabSheetNr == 8)
          num3 = num10;
        this.TabListObj.add("Fuel + Stockpile + Adv.Supply", 9);
        int num11 = num10 + 1;
        if (this.TabSheetNr == 9)
          num3 = num11;
        ListClass tabListObj = this.TabListObj;
        int tlistselect = num3;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart6 = (SubPartClass) new ListSubPartClass(tabListObj, 9, 200, tlistselect, game, tHeader: "Propery Sheets", tbackbitmap: (ref local1), bbx: 430, bby: 38, overruleFont: (ref local2));
        this.TabListId = this.AddSubPart(ref tsubpart6, 430, 38, 200, 192, 0);
      }
      this.Tabsheet();
    }

    private void Tabsheet()
    {
      if (this.BSymbolId > 0)
        this.RemoveSubPart(this.BSymbolId);
      if (this.BChangeSymbolId > 0)
        this.RemoveSubPart(this.BChangeSymbolId);
      if (this.BSymbol2Id > 0)
        this.RemoveSubPart(this.BSymbol2Id);
      if (this.BChangeSymbol2Id > 0)
        this.RemoveSubPart(this.BChangeSymbol2Id);
      if (this.BPicId > 0)
        this.RemoveSubPart(this.BPicId);
      if (this.bChangePicId > 0)
        this.RemoveSubPart(this.bChangePicId);
      if (this.BSymbolGroupId > 0)
        this.RemoveSubPart(this.BSymbolGroupId);
      if (this.BSymbolGroupTextId > 0)
        this.RemoveSubPart(this.BSymbolGroupTextId);
      if (this.BSymbolWeightId > 0)
        this.RemoveSubPart(this.BSymbolWeightId);
      if (this.BSymbolWeightTextId > 0)
        this.RemoveSubPart(this.BSymbolWeightTextId);
      if (this.BSymbolOverRuleId > 0)
        this.RemoveSubPart(this.BSymbolOverRuleId);
      if ((uint) this.BSymbolOverRuleTextId > 0U)
        this.RemoveSubPart(this.BSymbolOverRuleTextId);
      if (this.ResListId > 0)
        this.RemoveSubPart(this.ResListId);
      if (this.ExtraListId > 0)
        this.RemoveSubPart(this.ExtraListId);
      if (this.PGListId > 0)
        this.RemoveSubPart(this.PGListId);
      if (this.CombatListId > 0)
        this.RemoveSubPart(this.CombatListId);
      if (this.CombatList2Id > 0)
        this.RemoveSubPart(this.CombatList2Id);
      if (this.combatlist3id > 0)
        this.RemoveSubPart(this.combatlist3id);
      if (this.combatlist4id > 0)
        this.RemoveSubPart(this.combatlist4id);
      if (this.x3id > 0)
        this.RemoveSubPart(this.x3id);
      if (this.x3textid > 0)
        this.RemoveSubPart(this.x3textid);
      if (this.y1id > 0)
        this.RemoveSubPart(this.y1id);
      if (this.y1textid > 0)
        this.RemoveSubPart(this.y1textid);
      if (this.y3id > 0)
        this.RemoveSubPart(this.y3id);
      if (this.y4id > 0)
        this.RemoveSubPart(this.y4id);
      if (this.y5id > 0)
        this.RemoveSubPart(this.y5id);
      if (this.y6id > 0)
        this.RemoveSubPart(this.y6id);
      if (this.y6textid > 0)
        this.RemoveSubPart(this.y6textid);
      if (this.y7id > 0)
        this.RemoveSubPart(this.y7id);
      if (this.y7textid > 0)
        this.RemoveSubPart(this.y7textid);
      if (this.y7btextid > 0)
        this.RemoveSubPart(this.y7btextid);
      if (this.y8btextid > 0)
        this.RemoveSubPart(this.y8btextid);
      if (this.y8id > 0)
        this.RemoveSubPart(this.y8id);
      if (this.y8textid > 0)
        this.RemoveSubPart(this.y8textid);
      if (this.y3textid > 0)
        this.RemoveSubPart(this.y3textid);
      if (this.j1id > 0)
        this.RemoveSubPart(this.j1id);
      if (this.j1textid > 0)
        this.RemoveSubPart(this.j1textid);
      if (this.LogoListId > 0)
        this.RemoveSubPart(this.LogoListId);
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
      if (this.b9id > 0)
        this.RemoveSubPart(this.b9id);
      if (this.b9textid > 0)
        this.RemoveSubPart(this.b9textid);
      if (this.BMoveTypeId > 0)
        this.RemoveSubPart(this.BMoveTypeId);
      if (this.BMoveTypeTextId > 0)
        this.RemoveSubPart(this.BMoveTypeTextId);
      if (this.b10id > 0)
        this.RemoveSubPart(this.b10id);
      if (this.b10textid > 0)
        this.RemoveSubPart(this.b10textid);
      if (this.b11id > 0)
        this.RemoveSubPart(this.b11id);
      if (this.b11textid > 0)
        this.RemoveSubPart(this.b11textid);
      if (this.b12id > 0)
        this.RemoveSubPart(this.b12id);
      if (this.b12textid > 0)
        this.RemoveSubPart(this.b12textid);
      if (this.b13id > 0)
        this.RemoveSubPart(this.b13id);
      if (this.b13textid > 0)
        this.RemoveSubPart(this.b13textid);
      if (this.b14id > 0)
        this.RemoveSubPart(this.b14id);
      if (this.b14textid > 0)
        this.RemoveSubPart(this.b14textid);
      if (this.b15id > 0)
        this.RemoveSubPart(this.b15id);
      if (this.b15textid > 0)
        this.RemoveSubPart(this.b15textid);
      if (this.b16id > 0)
        this.RemoveSubPart(this.b16id);
      if (this.b16textid > 0)
        this.RemoveSubPart(this.b16textid);
      if (this.b17id > 0)
        this.RemoveSubPart(this.b17id);
      if (this.b17textid > 0)
        this.RemoveSubPart(this.b17textid);
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
      if (this.b21id > 0)
        this.RemoveSubPart(this.b21id);
      if (this.b21textid > 0)
        this.RemoveSubPart(this.b21textid);
      if (this.b22id > 0)
        this.RemoveSubPart(this.b22id);
      if (this.b22textid > 0)
        this.RemoveSubPart(this.b22textid);
      if (this.b23id > 0)
        this.RemoveSubPart(this.b23id);
      if (this.b23textid > 0)
        this.RemoveSubPart(this.b23textid);
      if (this.b24id > 0)
        this.RemoveSubPart(this.b24id);
      if (this.b24textid > 0)
        this.RemoveSubPart(this.b24textid);
      if (this.b25id > 0)
        this.RemoveSubPart(this.b25id);
      if (this.b25textid > 0)
        this.RemoveSubPart(this.b25textid);
      if (this.b26id > 0)
        this.RemoveSubPart(this.b26id);
      if (this.b26textid > 0)
        this.RemoveSubPart(this.b26textid);
      if (this.b27id > 0)
        this.RemoveSubPart(this.b27id);
      if (this.b27textid > 0)
        this.RemoveSubPart(this.b27textid);
      if (this.b28id > 0)
        this.RemoveSubPart(this.b28id);
      if (this.b29id > 0)
        this.RemoveSubPart(this.b29id);
      if (this.b29textid > 0)
        this.RemoveSubPart(this.b29textid);
      if (this.b30id > 0)
        this.RemoveSubPart(this.b30id);
      if (this.b30textid > 0)
        this.RemoveSubPart(this.b30textid);
      if (this.b31id > 0)
        this.RemoveSubPart(this.b31id);
      if (this.b31textid > 0)
        this.RemoveSubPart(this.b31textid);
      if (this.b32id > 0)
        this.RemoveSubPart(this.b32id);
      if (this.b32textid > 0)
        this.RemoveSubPart(this.b32textid);
      if (this.b33id > 0)
        this.RemoveSubPart(this.b33id);
      if (this.b33textid > 0)
        this.RemoveSubPart(this.b33textid);
      if (this.b34id > 0)
        this.RemoveSubPart(this.b34id);
      if (this.b34textid > 0)
        this.RemoveSubPart(this.b34textid);
      if (this.b35id > 0)
        this.RemoveSubPart(this.b35id);
      if (this.b35textid > 0)
        this.RemoveSubPart(this.b35textid);
      if (this.b36id > 0)
        this.RemoveSubPart(this.b36id);
      if (this.b36textid > 0)
        this.RemoveSubPart(this.b36textid);
      if (this.b37id > 0)
        this.RemoveSubPart(this.b37id);
      if (this.b37textid > 0)
        this.RemoveSubPart(this.b37textid);
      if (this.b38id > 0)
        this.RemoveSubPart(this.b38id);
      if (this.b38textid > 0)
        this.RemoveSubPart(this.b38textid);
      if (this.b39id > 0)
        this.RemoveSubPart(this.b39id);
      if (this.b39textid > 0)
        this.RemoveSubPart(this.b39textid);
      if (this.a1id > 0)
        this.RemoveSubPart(this.a1id);
      if (this.a1textid > 0)
        this.RemoveSubPart(this.a1textid);
      if (this.a2id > 0)
        this.RemoveSubPart(this.a2id);
      if (this.a2textid > 0)
        this.RemoveSubPart(this.a2textid);
      if (this.a3id > 0)
        this.RemoveSubPart(this.a3id);
      if (this.a3textid > 0)
        this.RemoveSubPart(this.a3textid);
      if (this.a4id > 0)
        this.RemoveSubPart(this.a4id);
      if (this.a4textid > 0)
        this.RemoveSubPart(this.a4textid);
      if (this.a5id > 0)
        this.RemoveSubPart(this.a5id);
      if (this.a5textid > 0)
        this.RemoveSubPart(this.a5textid);
      if (this.a6id > 0)
        this.RemoveSubPart(this.a6id);
      if (this.a6textid > 0)
        this.RemoveSubPart(this.a6textid);
      if (this.t1id > 0)
        this.RemoveSubPart(this.t1id);
      if (this.t1textid > 0)
        this.RemoveSubPart(this.t1textid);
      if (this.c11id > 0)
        this.RemoveSubPart(this.c11id);
      if (this.c11textid > 0)
        this.RemoveSubPart(this.c11textid);
      if (this.c12id > 0)
        this.RemoveSubPart(this.c12id);
      if (this.c12textid > 0)
        this.RemoveSubPart(this.c12textid);
      if (this.c13id > 0)
        this.RemoveSubPart(this.c13id);
      if (this.c13textid > 0)
        this.RemoveSubPart(this.c13textid);
      if (this.c14id > 0)
        this.RemoveSubPart(this.c14id);
      if (this.c14textid > 0)
        this.RemoveSubPart(this.c14textid);
      if (this.c15id > 0)
        this.RemoveSubPart(this.c15id);
      if (this.c15textid > 0)
        this.RemoveSubPart(this.c15textid);
      if (this.c16id > 0)
        this.RemoveSubPart(this.c16id);
      if (this.c16textid > 0)
        this.RemoveSubPart(this.c16textid);
      if (this.c17id > 0)
        this.RemoveSubPart(this.c17id);
      if (this.c17textid > 0)
        this.RemoveSubPart(this.c17textid);
      if (this.c18id > 0)
        this.RemoveSubPart(this.c18id);
      if (this.c18textid > 0)
        this.RemoveSubPart(this.c18textid);
      if (this.c19id > 0)
        this.RemoveSubPart(this.c19id);
      if (this.c19textid > 0)
        this.RemoveSubPart(this.c19textid);
      if (this.c20id > 0)
        this.RemoveSubPart(this.c20id);
      if (this.c20textid > 0)
        this.RemoveSubPart(this.c20textid);
      if (this.c21id > 0)
        this.RemoveSubPart(this.c21id);
      if (this.c21textid > 0)
        this.RemoveSubPart(this.c21textid);
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
      if (this.c7id > 0)
        this.RemoveSubPart(this.c7id);
      if (this.c7textid > 0)
        this.RemoveSubPart(this.c7textid);
      if (this.c8id > 0)
        this.RemoveSubPart(this.c8id);
      if (this.c8textid > 0)
        this.RemoveSubPart(this.c8textid);
      if (this.d1id > 0)
        this.RemoveSubPart(this.d1id);
      if (this.d1textid > 0)
        this.RemoveSubPart(this.d1textid);
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
      if (this.e7id > 0)
        this.RemoveSubPart(this.e7id);
      if (this.e7textid > 0)
        this.RemoveSubPart(this.e7textid);
      if (this.f1id > 0)
        this.RemoveSubPart(this.f1id);
      if (this.f1textid > 0)
        this.RemoveSubPart(this.f1textid);
      if (this.f2id > 0)
        this.RemoveSubPart(this.f2id);
      if (this.f2textid > 0)
        this.RemoveSubPart(this.f2textid);
      if (this.f3id > 0)
        this.RemoveSubPart(this.f3id);
      if (this.f3textid > 0)
        this.RemoveSubPart(this.f3textid);
      if (this.v1id > 0)
        this.RemoveSubPart(this.v1id);
      if (this.v1textid > 0)
        this.RemoveSubPart(this.v1textid);
      if (this.v2id > 0)
        this.RemoveSubPart(this.v2id);
      if (this.v2textid > 0)
        this.RemoveSubPart(this.v2textid);
      if (this.v3id > 0)
        this.RemoveSubPart(this.v3id);
      if (this.v3textid > 0)
        this.RemoveSubPart(this.v3textid);
      if (this.v4id > 0)
        this.RemoveSubPart(this.v4id);
      if (this.v4textid > 0)
        this.RemoveSubPart(this.v4textid);
      if (this.v5id > 0)
        this.RemoveSubPart(this.v5id);
      if (this.v5textid > 0)
        this.RemoveSubPart(this.v5textid);
      if (this.v6id > 0)
        this.RemoveSubPart(this.v6id);
      if (this.v6textid > 0)
        this.RemoveSubPart(this.v6textid);
      if (this.v7id > 0)
        this.RemoveSubPart(this.v7id);
      if (this.v7textid > 0)
        this.RemoveSubPart(this.v7textid);
      if (this.v8id > 0)
        this.RemoveSubPart(this.v8id);
      if (this.v8textid > 0)
        this.RemoveSubPart(this.v8textid);
      if (this.v9id > 0)
        this.RemoveSubPart(this.v9id);
      if (this.v9textid > 0)
        this.RemoveSubPart(this.v9textid);
      if (this.v10id > 0)
        this.RemoveSubPart(this.v10id);
      if (this.v10textid > 0)
        this.RemoveSubPart(this.v10textid);
      if (this.v11id > 0)
        this.RemoveSubPart(this.v11id);
      if (this.v11textid > 0)
        this.RemoveSubPart(this.v11textid);
      if (this.v12id > 0)
        this.RemoveSubPart(this.v12id);
      if (this.v12textid > 0)
        this.RemoveSubPart(this.v12textid);
      if (this.v13id > 0)
        this.RemoveSubPart(this.v13id);
      if (this.v13textid > 0)
        this.RemoveSubPart(this.v13textid);
      if (this.v14id > 0)
        this.RemoveSubPart(this.v14id);
      if (this.v14textid > 0)
        this.RemoveSubPart(this.v14textid);
      if (this.v15id > 0)
        this.RemoveSubPart(this.v15id);
      if (this.v15textid > 0)
        this.RemoveSubPart(this.v15textid);
      if (this.v16id > 0)
        this.RemoveSubPart(this.v16id);
      if (this.v16textid > 0)
        this.RemoveSubPart(this.v16textid);
      if (this.v17id > 0)
        this.RemoveSubPart(this.v17id);
      if (this.v17textid > 0)
        this.RemoveSubPart(this.v17textid);
      if (this.v18id > 0)
        this.RemoveSubPart(this.v18id);
      if (this.v18textid > 0)
        this.RemoveSubPart(this.v18textid);
      if (this.v19id > 0)
        this.RemoveSubPart(this.v19id);
      if (this.v19textid > 0)
        this.RemoveSubPart(this.v19textid);
      if (this.v20id > 0)
        this.RemoveSubPart(this.v20id);
      if (this.v20textid > 0)
        this.RemoveSubPart(this.v20textid);
      if (this.v21id > 0)
        this.RemoveSubPart(this.v21id);
      if (this.v21textid > 0)
        this.RemoveSubPart(this.v21textid);
      if (this.v22id > 0)
        this.RemoveSubPart(this.v22id);
      if (this.v22textid > 0)
        this.RemoveSubPart(this.v22textid);
      if (this.v23id > 0)
        this.RemoveSubPart(this.v23id);
      if (this.v23textid > 0)
        this.RemoveSubPart(this.v23textid);
      if (this.y2id > 0)
        this.RemoveSubPart(this.y2id);
      if (this.g1id > 0)
        this.RemoveSubPart(this.g1id);
      if (this.g1textid > 0)
        this.RemoveSubPart(this.g1textid);
      if (this.g2id > 0)
        this.RemoveSubPart(this.g2id);
      if (this.g2textid > 0)
        this.RemoveSubPart(this.g2textid);
      if (this.g3id > 0)
        this.RemoveSubPart(this.g3id);
      if (this.g3textid > 0)
        this.RemoveSubPart(this.g3textid);
      if (this.g4id > 0)
        this.RemoveSubPart(this.g4id);
      if (this.g4textid > 0)
        this.RemoveSubPart(this.g4textid);
      if (this.g5id > 0)
        this.RemoveSubPart(this.g5id);
      if (this.g5textid > 0)
        this.RemoveSubPart(this.g5textid);
      if (this.g6id > 0)
        this.RemoveSubPart(this.g6id);
      if (this.g6textid > 0)
        this.RemoveSubPart(this.g6textid);
      if (this.g7id > 0)
        this.RemoveSubPart(this.g7id);
      if (this.g7textid > 0)
        this.RemoveSubPart(this.g7textid);
      if (this.g8id > 0)
        this.RemoveSubPart(this.g8id);
      if (this.g8textid > 0)
        this.RemoveSubPart(this.g8textid);
      if (this.g9id > 0)
        this.RemoveSubPart(this.g9id);
      if (this.g9textid > 0)
        this.RemoveSubPart(this.g9textid);
      if (this.g10id > 0)
        this.RemoveSubPart(this.g10id);
      if (this.g10textid > 0)
        this.RemoveSubPart(this.g10textid);
      if (this.g11id > 0)
        this.RemoveSubPart(this.g11id);
      if (this.g11textid > 0)
        this.RemoveSubPart(this.g11textid);
      if (this.g12id > 0)
        this.RemoveSubPart(this.g12id);
      if (this.g12textid > 0)
        this.RemoveSubPart(this.g12textid);
      if (this.g13id > 0)
        this.RemoveSubPart(this.g13id);
      if (this.g13textid > 0)
        this.RemoveSubPart(this.g13textid);
      if (this.g14id > 0)
        this.RemoveSubPart(this.g14id);
      if (this.g14textid > 0)
        this.RemoveSubPart(this.g14textid);
      if (this.g15id > 0)
        this.RemoveSubPart(this.g15id);
      if (this.g15textid > 0)
        this.RemoveSubPart(this.g15textid);
      if (this.g16id > 0)
        this.RemoveSubPart(this.g16id);
      if (this.g16textid > 0)
        this.RemoveSubPart(this.g16textid);
      if (this.g17id > 0)
        this.RemoveSubPart(this.g17id);
      if (this.g17textid > 0)
        this.RemoveSubPart(this.g17textid);
      if (this.g18id > 0)
        this.RemoveSubPart(this.g18id);
      if (this.g18textid > 0)
        this.RemoveSubPart(this.g18textid);
      if (this.g19id > 0)
        this.RemoveSubPart(this.g19id);
      if (this.g19textid > 0)
        this.RemoveSubPart(this.g19textid);
      if (this.g20id > 0)
        this.RemoveSubPart(this.g20id);
      if (this.g20textid > 0)
        this.RemoveSubPart(this.g20textid);
      if (this.g21id > 0)
        this.RemoveSubPart(this.g21id);
      if (this.g21textid > 0)
        this.RemoveSubPart(this.g21textid);
      if (this.g23id > 0)
        this.RemoveSubPart(this.g23id);
      if (this.g23textid > 0)
        this.RemoveSubPart(this.g23textid);
      if (this.g24id > 0)
        this.RemoveSubPart(this.g24id);
      if (this.g24textid > 0)
        this.RemoveSubPart(this.g24textid);
      if (this.h1id > 0)
        this.RemoveSubPart(this.h1id);
      if (this.h1textid > 0)
        this.RemoveSubPart(this.h1textid);
      if (this.h2id > 0)
        this.RemoveSubPart(this.h2id);
      if (this.h2textid > 0)
        this.RemoveSubPart(this.h2textid);
      if (this.h3id > 0)
        this.RemoveSubPart(this.h3id);
      if (this.h3textid > 0)
        this.RemoveSubPart(this.h3textid);
      if (this.h4id > 0)
        this.RemoveSubPart(this.h4id);
      if (this.h4textid > 0)
        this.RemoveSubPart(this.h4textid);
      if (this.h5id > 0)
        this.RemoveSubPart(this.h5id);
      if (this.h5textid > 0)
        this.RemoveSubPart(this.h5textid);
      if (this.h6id > 0)
        this.RemoveSubPart(this.h6id);
      if (this.h6textid > 0)
        this.RemoveSubPart(this.h6textid);
      if (this.copyid > 0)
        this.RemoveSubPart(this.copyid);
      if (this.copytextid > 0)
        this.RemoveSubPart(this.copytextid);
      if (this.p1id > 0)
        this.RemoveSubPart(this.p1id);
      if (this.p1textid > 0)
        this.RemoveSubPart(this.p1textid);
      if (this.p2id > 0)
        this.RemoveSubPart(this.p2id);
      if (this.p2textid > 0)
        this.RemoveSubPart(this.p2textid);
      if (this.p3id > 0)
        this.RemoveSubPart(this.p3id);
      if (this.p3textid > 0)
        this.RemoveSubPart(this.p3textid);
      if (this.p4id > 0)
        this.RemoveSubPart(this.p4id);
      if (this.p4textid > 0)
        this.RemoveSubPart(this.p4textid);
      if (this.p5id > 0)
        this.RemoveSubPart(this.p5id);
      if (this.p5textid > 0)
        this.RemoveSubPart(this.p5textid);
      if (this.p6id > 0)
        this.RemoveSubPart(this.p6id);
      if (this.p6textid > 0)
        this.RemoveSubPart(this.p6textid);
      if (this.p7id > 0)
        this.RemoveSubPart(this.p7id);
      if (this.p7textid > 0)
        this.RemoveSubPart(this.p7textid);
      if (this.p8id > 0)
        this.RemoveSubPart(this.p8id);
      if (this.p8textid > 0)
        this.RemoveSubPart(this.p8textid);
      if (this.p9id > 0)
        this.RemoveSubPart(this.p9id);
      if (this.p9textid > 0)
        this.RemoveSubPart(this.p9textid);
      if (this.vp1id > 0)
        this.RemoveSubPart(this.vp1id);
      if (this.vp1textid > 0)
        this.RemoveSubPart(this.vp1textid);
      if (this.vp2id > 0)
        this.RemoveSubPart(this.vp2id);
      if (this.vp2textid > 0)
        this.RemoveSubPart(this.vp2textid);
      if (this.vp3id > 0)
        this.RemoveSubPart(this.vp3id);
      if (this.vp3textid > 0)
        this.RemoveSubPart(this.vp3textid);
      if (this.vp4id > 0)
        this.RemoveSubPart(this.vp4id);
      if (this.vp4textid > 0)
        this.RemoveSubPart(this.vp4textid);
      if (this.vp5id > 0)
        this.RemoveSubPart(this.vp5id);
      if (this.vp5textid > 0)
        this.RemoveSubPart(this.vp5textid);
      if (this.vp6id > 0)
        this.RemoveSubPart(this.vp6id);
      if (this.vp6textid > 0)
        this.RemoveSubPart(this.vp6textid);
      if (this.w1id > 0)
        this.RemoveSubPart(this.w1id);
      if (this.w1textid > 0)
        this.RemoveSubPart(this.w1textid);
      if (this.w1bid > 0)
        this.RemoveSubPart(this.w1bid);
      if (this.w1btextid > 0)
        this.RemoveSubPart(this.w1btextid);
      if (this.w2id > 0)
        this.RemoveSubPart(this.w2id);
      if (this.w2textid > 0)
        this.RemoveSubPart(this.w2textid);
      if (this.w2bid > 0)
        this.RemoveSubPart(this.w2bid);
      if (this.w2btextid > 0)
        this.RemoveSubPart(this.w2btextid);
      if (this.w3id > 0)
        this.RemoveSubPart(this.w3id);
      if (this.w3textid > 0)
        this.RemoveSubPart(this.w3textid);
      if (this.w133id > 0)
        this.RemoveSubPart(this.w133id);
      if (this.w133textid > 0)
        this.RemoveSubPart(this.w133textid);
      if (this.w4id > 0)
        this.RemoveSubPart(this.w4id);
      if (this.w4textid > 0)
        this.RemoveSubPart(this.w4textid);
      if (this.w5id > 0)
        this.RemoveSubPart(this.w5id);
      if (this.w5textid > 0)
        this.RemoveSubPart(this.w5textid);
      if (this.w6id > 0)
        this.RemoveSubPart(this.w6id);
      if (this.w6textid > 0)
        this.RemoveSubPart(this.w6textid);
      if (this.w7id > 0)
        this.RemoveSubPart(this.w7id);
      if (this.w7textid > 0)
        this.RemoveSubPart(this.w7textid);
      if (this.w8id > 0)
        this.RemoveSubPart(this.w8id);
      if (this.w8textid > 0)
        this.RemoveSubPart(this.w8textid);
      if (this.w9id > 0)
        this.RemoveSubPart(this.w9id);
      if (this.w9textid > 0)
        this.RemoveSubPart(this.w9textid);
      if (this.w9bid > 0)
        this.RemoveSubPart(this.w9bid);
      if (this.w9btextid > 0)
        this.RemoveSubPart(this.w9btextid);
      if (this.w10id > 0)
        this.RemoveSubPart(this.w10id);
      if (this.w10textid > 0)
        this.RemoveSubPart(this.w10textid);
      if (this.w11id > 0)
        this.RemoveSubPart(this.w11id);
      if (this.w11textid > 0)
        this.RemoveSubPart(this.w11textid);
      if (this.w12id > 0)
        this.RemoveSubPart(this.w12id);
      if (this.w12textid > 0)
        this.RemoveSubPart(this.w12textid);
      if (this.w13id > 0)
        this.RemoveSubPart(this.w13id);
      if (this.w13textid > 0)
        this.RemoveSubPart(this.w13textid);
      if (this.w14id > 0)
        this.RemoveSubPart(this.w14id);
      if (this.w14textid > 0)
        this.RemoveSubPart(this.w14textid);
      if (this.w16id > 0)
        this.RemoveSubPart(this.w16id);
      if (this.w15textid > 0)
        this.RemoveSubPart(this.w15textid);
      if (this.w15id > 0)
        this.RemoveSubPart(this.w15id);
      if (this.w16textid > 0)
        this.RemoveSubPart(this.w16textid);
      if (this.w17id > 0)
        this.RemoveSubPart(this.w17id);
      if (this.w17textid > 0)
        this.RemoveSubPart(this.w17textid);
      if (this.VariantListId > 0)
        this.RemoveSubPart(this.VariantListId);
      if (this.PreventListId > 0)
        this.RemoveSubPart(this.PreventListId);
      if (this.SFtypeNr <= -1)
        return;
      if (this.TabSheetNr == 0)
        this.tabsheet0();
      if (this.TabSheetNr == 1)
        this.tabsheet1();
      if (this.TabSheetNr == 2)
        this.tabsheet2();
      if (this.TabSheetNr == 3)
        this.tabsheet3();
      if (this.TabSheetNr == 4)
        this.tabsheet4();
      if (this.TabSheetNr == 5)
        this.tabsheet5();
      if (this.TabSheetNr == 6)
        this.tabsheet6();
      if (this.TabSheetNr == 7)
        this.tabsheet7();
      if (this.TabSheetNr == 8)
        this.tabsheet8();
      if (this.TabSheetNr == 9)
        this.tabsheet9();
      if (this.TabSheetNr != 10)
        return;
      this.tabsheet10();
    }

    private void tabsheet0()
    {
      this.ss = "COUNTER SYMBOL - Click to change the graphics used to symoblize this sftype on a counter of a unit";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.Data.SFTypeObj[this.SFtypeNr].SymbolSpriteID, tDescript: this.ss);
      this.BSymbolId = this.AddSubPart(ref tsubpart1, 10, 360, 31, 31, 0);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
        this.BChangeSymbolId = this.AddSubPart(ref tsubpart2, 50, 360, 32, 16, 1);
      }
      this.ss = "MOVE+COMBAT SYMOBL - Click to change the graphics used to symoblize this sftype on a counter of a unit";
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.Data.SFTypeObj[this.SFtypeNr].SymbolSprite2ID, tDescript: this.ss);
      this.BSymbol2Id = this.AddSubPart(ref tsubpart3, 110, 360, 31, 31, 0);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
        this.BChangeSymbol2Id = this.AddSubPart(ref tsubpart4, 150, 360, 32, 16, 1);
      }
      this.ss = "Let People overdraw a gfx over this sftype. 0=dont. 1=yes in front of eqp. 2=behind eqp";
      SubPartClass tsubpart5 = (SubPartClass) new TextPartClass("UsePplGfx=" + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].UsePeopleGraphics), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 100, 20, false, tDescript: this.ss);
      this.y3textid = this.AddSubPart(ref tsubpart5, 250, 360, 100, 20, 0);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.y3id = this.AddSubPart(ref tsubpart6, 210, 360, 32, 16, 1);
      }
      this.ss = "Illustration Graphic - Sideways Sprite";
      SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.Data.SFTypeObj[this.SFtypeNr].SidewaysSpriteID, tDescript: this.ss, tResizeX: 70, tresizeY: 40);
      this.y4id = this.AddSubPart(ref tsubpart7, 180, 400, 70, 40, 0);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
        this.y5id = this.AddSubPart(ref tsubpart8, 260, 400, 32, 16, 1);
      }
      this.ss = "Click to change the artistic graphic for this sftype";
      SubPartClass tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.Data.SFTypeObj[this.SFtypeNr].PicSpriteID, tDescript: this.ss, tResizeX: 96, tresizeY: 72);
      this.BPicId = this.AddSubPart(ref tsubpart9, 10, 400, 96, 72, 0);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart10 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
        this.bChangePicId = this.AddSubPart(ref tsubpart10, 140, 400, 32, 16, 1);
      }
      this.ss = "Click to assign the sftype a symbolgroup number, used for pre-calculation which symbolgroup is shown in mixed unit";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BSymbolGroupId = this.AddSubPart(ref tsubpart11, 10, 540, 32, 16, 1);
      }
      SubPartClass tsubpart12 = (SubPartClass) new TextPartClass("Symbol Group: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].SymbolGroup), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.BSymbolGroupTextId = this.AddSubPart(ref tsubpart12, 50, 539, 400, 20, 0);
      this.ss = "Click to assign the sftype as symbolweight, the more weight the earlier it prevails as symbol shown in mixed unit";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart13 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BSymbolWeightId = this.AddSubPart(ref tsubpart13, 10, 570, 32, 16, 1);
      }
      SubPartClass tsubpart14 = (SubPartClass) new TextPartClass("Symbol Weight: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].SymbolWeight), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.BSymbolWeightTextId = this.AddSubPart(ref tsubpart14, 50, 569, 400, 20, 0);
      this.ss = "Click to toggle symbol overrule on or off. A symboloverrule means that this symbol will not be cloured as regime pen colour.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BSymbolOverRuleId = this.AddSubPart(ref tsubpart15, 10, 600, 32, 16, 1);
      }
      SubPartClass tsubpart16 = (SubPartClass) new TextPartClass("OverRule Symbol: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].SymbolOverrule), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.BSymbolOverRuleTextId = this.AddSubPart(ref tsubpart16, 50, 599, 400, 20, 0);
    }

    private void tabsheet1()
    {
      this.ss = "Click to set the MoveType of this SubformationType";
      string str1 = this.game.Data.TempString[this.game.Data.SFTypeObj[this.SFtypeNr].MoveType];
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BMoveTypeId = this.AddSubPart(ref tsubpart, 10, 340, 32, 16, 1);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Move Type: " + str1, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.BMoveTypeTextId = this.AddSubPart(ref tsubpart1, 50, 339, 400, 20, 0);
      this.ss = "Click to set how much supply sftype can maximally hold with it without using carrycap";
      string str2 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].SupplyCarry);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B1Id = this.AddSubPart(ref tsubpart2, 10, 380, 32, 16, 1);
      }
      SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("Supply Carry: " + str2, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B1TextId = this.AddSubPart(ref tsubpart3, 50, 379, 400, 20, 0);
      this.ss = "Click to set howmuch supply the sftype can maximally consume per round";
      string str3 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].BasicSupplyNeed);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B6Id = this.AddSubPart(ref tsubpart4, 10, 460, 32, 16, 1);
      }
      SubPartClass tsubpart5 = (SubPartClass) new TextPartClass("Basic Supply Need: " + str3, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B6TextId = this.AddSubPart(ref tsubpart5, 50, 459, 200, 20, 0);
      this.ss = "Click to set the UnitGroup of this sftype. Is used for combatdetail stats and landscape entrench stats.";
      string str4 = this.game.Data.TempString[400 + this.game.Data.SFTypeObj[this.SFtypeNr].UnitGroup] + "(" + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].UnitGroup) + ")";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B7Id = this.AddSubPart(ref tsubpart6, 10, 480, 32, 16, 1);
      }
      SubPartClass tsubpart7 = (SubPartClass) new TextPartClass("SFType Group: " + str4, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B7TextId = this.AddSubPart(ref tsubpart7, 50, 479, 200, 20, 0);
      this.ss = "Click to set ammount of reconpoints";
      string str5 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ReconPts);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.f1id = this.AddSubPart(ref tsubpart8, 10, 500, 32, 16, 1);
      }
      SubPartClass tsubpart9 = (SubPartClass) new TextPartClass("ReconPts: " + str5, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.f1textid = this.AddSubPart(ref tsubpart9, 50, 500, 200, 20, 0);
      this.ss = "Click to set ammount of hidepoints. Specifying the minimal number of reconpoints needed to see this sftype.";
      string str6 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].HidePts);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart10 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.f2id = this.AddSubPart(ref tsubpart10, 10, 520, 32, 16, 1);
      }
      SubPartClass tsubpart11 = (SubPartClass) new TextPartClass("HidePts: " + str6, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.f2textid = this.AddSubPart(ref tsubpart11, 50, 520, 200, 20, 0);
      this.ss = "Click to set the number of Zone of Controll points";
      string str7 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ZOCPts);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart12 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.f3id = this.AddSubPart(ref tsubpart12, 10, 540, 32, 16, 1);
      }
      SubPartClass tsubpart13 = (SubPartClass) new TextPartClass("ZOCPts: " + str7, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.f3textid = this.AddSubPart(ref tsubpart13, 50, 540, 200, 20, 0);
      this.ss = "Click to toggle on/off if the sftype can be used for paradropping. Without paradrop airlift is always still possible";
      string str8 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].CanDoParadrop);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart14 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g1id = this.AddSubPart(ref tsubpart14, 10, 560, 32, 16, 1);
      }
      SubPartClass tsubpart15 = (SubPartClass) new TextPartClass("CanDoParadrop: " + str8, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.g1textid = this.AddSubPart(ref tsubpart15, 50, 560, 200, 20, 0);
      this.ss = "Click to set the number of anti-struc points per combatround this sftype can maximally do";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart16 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g2id = this.AddSubPart(ref tsubpart16, 10, 580, 32, 16, 1);
      }
      SubPartClass tsubpart17 = (SubPartClass) new TextPartClass("AntiStrucPts: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].AntiStrucPts), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.g2textid = this.AddSubPart(ref tsubpart17, 50, 580, 200, 20, 0);
      this.ss = "Click to set the Theater type of this sftype. 0=land, 1=navy and 2=air";
      string str9 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].Theater);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B8Id = this.AddSubPart(ref tsubpart18, 310, 360, 32, 16, 1);
      }
      SubPartClass tsubpart19 = (SubPartClass) new TextPartClass("Theater: " + str9, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B8TextId = this.AddSubPart(ref tsubpart19, 350, 359, 200, 20, 0);
      this.ss = "Click to set the weight of this sftype. Is used in mobility determination calcs and transfers/str.transfers";
      string str10 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].Weight);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart20 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b9id = this.AddSubPart(ref tsubpart20, 310, 380, 32, 16, 1);
      }
      SubPartClass tsubpart21 = (SubPartClass) new TextPartClass("Weight: " + str10, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b9textid = this.AddSubPart(ref tsubpart21, 350, 379, 200, 20, 0);
      this.ss = "Click to set how much weight points this sftype can carry/mobilize";
      string str11 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].CarryCap);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart22 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.d1id = this.AddSubPart(ref tsubpart22, 310, 400, 32, 16, 1);
      }
      SubPartClass tsubpart23 = (SubPartClass) new TextPartClass("CarryCap: " + str11, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.d1textid = this.AddSubPart(ref tsubpart23, 350, 399, 200, 20, 0);
      this.ss = "Click to set howmany entrench points this sftype generates at start of every turn";
      string str12 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].EntrenchPower);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart24 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.e1id = this.AddSubPart(ref tsubpart24, 310, 420, 32, 16, 1);
      }
      SubPartClass tsubpart25 = (SubPartClass) new TextPartClass("EntrenchPower: " + str12, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.e1textid = this.AddSubPart(ref tsubpart25, 350, 419, 200, 20, 0);
      this.ss = "Click to set the powerpoints of this sftype. Very important for experience calculations! Used to display counter strenght.";
      string str13 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].PowerPts);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart26 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.e3id = this.AddSubPart(ref tsubpart26, 310, 460, 32, 16, 1);
      }
      SubPartClass tsubpart27 = (SubPartClass) new TextPartClass("PowerPts: " + str13, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.e3textid = this.AddSubPart(ref tsubpart27, 350, 459, 200, 20, 0);
      this.ss = "Click to set the percentage of movement cost reduction this sftype will get on its movetype costs. Example: 40 is 40% less AP cost";
      string str14 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].MoveRedux);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart28 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b24id = this.AddSubPart(ref tsubpart28, 310, 640, 32, 16, 1);
      }
      SubPartClass tsubpart29 = (SubPartClass) new TextPartClass("MoveRedux: " + str14, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b24textid = this.AddSubPart(ref tsubpart29, 350, 639, 200, 20, 0);
      this.ss = "Click to set a possible actionpoint mod. Making it possible to give this sftype more or less than 100ap if fully ready.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart30 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g4id = this.AddSubPart(ref tsubpart30, 610, 240, 32, 16, 1);
      }
      SubPartClass tsubpart31 = (SubPartClass) new TextPartClass("ActionPoint Mod: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ApMod), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.g4textid = this.AddSubPart(ref tsubpart31, 650, 239, 200, 20, 0);
      this.ss = "Click to set howmuch absolute readiness points this sfype loses with each attack";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart32 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g6id = this.AddSubPart(ref tsubpart32, 610, 260, 32, 16, 1);
      }
      SubPartClass tsubpart33 = (SubPartClass) new TextPartClass("RdnLossPerAttack: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].RdnLossPerAttack), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.g6textid = this.AddSubPart(ref tsubpart33, 650, 259, 200, 20, 0);
      this.ss = "Click to toggle on/off if this sftype should autodestroy after having finished one full combatround.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart34 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g7id = this.AddSubPart(ref tsubpart34, 610, 280, 32, 16, 1);
      }
      SubPartClass tsubpart35 = (SubPartClass) new TextPartClass("AutoDestroy: Att=" + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].AutoDestroy) + ", Def=" + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].AutoDestroy2), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.g7textid = this.AddSubPart(ref tsubpart35, 650, 279, 200, 20, 0);
      this.ss = "Click to set the ammount of engineer points this sftype will get every round";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart36 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g8id = this.AddSubPart(ref tsubpart36, 610, 300, 32, 16, 1);
      }
      SubPartClass tsubpart37 = (SubPartClass) new TextPartClass("EP: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].EP), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.g8textid = this.AddSubPart(ref tsubpart37, 650, 299, 200, 20, 0);
      this.ss = "Click to choose the sound that has to be played when the sftype moves";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart38 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g10id = this.AddSubPart(ref tsubpart38, 610, 340, 32, 16, 1);
      }
      SubPartClass tsubpart39 = (SubPartClass) new TextPartClass("MoveWAV: " + this.game.Data.SFTypeObj[this.SFtypeNr].MoveWAV, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.g10textid = this.AddSubPart(ref tsubpart39, 650, 339, 200, 20, 0);
      this.ss = "Click to choose the sound that has to be played when the sftype fights";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart40 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g11id = this.AddSubPart(ref tsubpart40, 610, 360, 32, 16, 1);
      }
      SubPartClass tsubpart41 = (SubPartClass) new TextPartClass("BattleWAV: " + this.game.Data.SFTypeObj[this.SFtypeNr].BattleWAV, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.g11textid = this.AddSubPart(ref tsubpart41, 650, 359, 200, 20, 0);
      this.ss = "Click to set the number of staff points this sftype has. 1 Staffpoints is needed for each Powerpoint under command.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart42 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g15id = this.AddSubPart(ref tsubpart42, 610, 400, 32, 16, 1);
      }
      SubPartClass tsubpart43 = (SubPartClass) new TextPartClass("StaffPts: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].StaffPts), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.g15textid = this.AddSubPart(ref tsubpart43, 650, 399, 200, 20, 0);
      this.ss = "Click to set the anti-struc points generated by this sftype when attempting to blow a bridge";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart44 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g17id = this.AddSubPart(ref tsubpart44, 610, 420, 32, 16, 1);
      }
      SubPartClass tsubpart45 = (SubPartClass) new TextPartClass("BlowBridgePts: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].BlowBridgePts), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.g17textid = this.AddSubPart(ref tsubpart45, 650, 419, 200, 20, 0);
      this.ss = "Click to set the percentage chance a kill against this sftype is mutated into a retreat.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart46 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g18id = this.AddSubPart(ref tsubpart46, 610, 440, 32, 16, 1);
      }
      SubPartClass tsubpart47 = (SubPartClass) new TextPartClass("KillToRetr%(in def): " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].KilltoRetreatChance), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.g18textid = this.AddSubPart(ref tsubpart47, 650, 439, 200, 20, 0);
      this.ss = "Click if the sftype has staff points to set the max combat modifier for units under a hq with this sftype.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart48 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b29id = this.AddSubPart(ref tsubpart48, 610, 460, 32, 16, 1);
      }
      SubPartClass tsubpart49 = (SubPartClass) new TextPartClass("StaffCombatMod: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].StaffCombatMod), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b29textid = this.AddSubPart(ref tsubpart49, 650, 459, 200, 20, 0);
      this.ss = "Click if the sftype has staff points to set the max morale modifier for units under a hq with this sftype.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart50 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b30id = this.AddSubPart(ref tsubpart50, 610, 480, 32, 16, 1);
      }
      SubPartClass tsubpart51 = (SubPartClass) new TextPartClass("StaffMoraleMod: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].StaffMoraleMod), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b30textid = this.AddSubPart(ref tsubpart51, 650, 479, 200, 20, 0);
      this.ss = "Click to set the antisupply points this sftype has versus land hexes.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart52 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g19id = this.AddSubPart(ref tsubpart52, 610, 500, 32, 16, 1);
      }
      SubPartClass tsubpart53 = (SubPartClass) new TextPartClass("AntiSupplyPts: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].AntiSupply), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.g19textid = this.AddSubPart(ref tsubpart53, 650, 499, 200, 20, 0);
      this.ss = "Click to set how far in Action Points these anti supply points are in effect";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart54 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g20id = this.AddSubPart(ref tsubpart54, 610, 520, 32, 16, 1);
      }
      SubPartClass tsubpart55 = (SubPartClass) new TextPartClass("AntiSupplyRange: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].AntiSupplyRange), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.g20textid = this.AddSubPart(ref tsubpart55, 650, 519, 200, 20, 0);
      this.ss = "Click the antisupply points this sftype has versus sea hexes";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart56 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g21id = this.AddSubPart(ref tsubpart56, 610, 540, 32, 16, 1);
      }
      SubPartClass tsubpart57 = (SubPartClass) new TextPartClass("AntiSupplySea: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].AntiSupplySea), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.g21textid = this.AddSubPart(ref tsubpart57, 650, 539, 200, 20, 0);
      this.ss = "Click to set an absolute readiness loss points for every 100ap spent. (50 ap spent is half specified loss)";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart58 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b32id = this.AddSubPart(ref tsubpart58, 610, 560, 32, 16, 1);
      }
      SubPartClass tsubpart59 = (SubPartClass) new TextPartClass("Abs.Rdnloss100ap: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ReadinessLoss), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 250, 20, false, tDescript: this.ss);
      this.b32textid = this.AddSubPart(ref tsubpart59, 650, 559, 250, 20, 0);
      this.ss = "Click to set railcap pts..";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart60 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b33id = this.AddSubPart(ref tsubpart60, 610, 580, 32, 16, 1);
      }
      SubPartClass tsubpart61 = (SubPartClass) new TextPartClass("Railcap: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].RailCap), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b33textid = this.AddSubPart(ref tsubpart61, 650, 579, 200, 20, 0);
      this.ss = "Click to set regimevar of regime that kills 1 of this sftype to be raised by 1. -1=no regvar raise.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart62 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.h5id = this.AddSubPart(ref tsubpart62, 610, 600, 32, 16, 1);
      }
      SubPartClass tsubpart63 = (SubPartClass) new TextPartClass("KillIsRegVar: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].KillIsRegVar), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.h5textid = this.AddSubPart(ref tsubpart63, 650, 599, 200, 20, 0);
      this.ss = "Click to set which Slot Number of the hex attacked by this SFType should be increased by 1 for each attack in each combatround";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart64 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b34id = this.AddSubPart(ref tsubpart64, 610, 620, 32, 16, 1);
      }
      SubPartClass tsubpart65 = (SubPartClass) new TextPartClass("OnAttackSetSlot: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].SlotNumber), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b34textid = this.AddSubPart(ref tsubpart65, 650, 619, 200, 20, 0);
      this.ss = "Click to set the ratio. 0=no ratio. But for example 2 shows player 2 times as many as their are individuals. Use for historicity purposes.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart66 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.w6id = this.AddSubPart(ref tsubpart66, 310, 560, 32, 16, 1);
      }
      SubPartClass tsubpart67 = (SubPartClass) new TextPartClass("Ratio: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].Ratio), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.w6textid = this.AddSubPart(ref tsubpart67, 350, 559, 200, 20, 0);
      this.ss = "Click to set Air AP Overrule cost. Leave -1 to keep standard functionality. >-1 means thats the ap cost to move into any hex.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart68 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.x3id = this.AddSubPart(ref tsubpart68, 310, 580, 32, 16, 1);
      }
      SubPartClass tsubpart69 = (SubPartClass) new TextPartClass("AirOverrule: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].AirAPRule), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.x3textid = this.AddSubPart(ref tsubpart69, 350, 579, 200, 20, 0);
      this.ss = "Click to set CopyFromSFType stat. This is only used by some scripts like those who interprent in the Trooptype Editor.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart70 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.w7id = this.AddSubPart(ref tsubpart70, 910, 120, 32, 16, 1);
      }
      if (this.game.Data.SFTypeObj[this.SFtypeNr].CopyDataFrom > -1)
      {
        SubPartClass tsubpart71 = (SubPartClass) new TextPartClass("CopyFromSFType: " + this.game.Data.SFTypeObj[this.game.Data.SFTypeObj[this.SFtypeNr].CopyDataFrom].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.w7textid = this.AddSubPart(ref tsubpart71, 950, 119, 200, 20, 0);
      }
      else
      {
        SubPartClass tsubpart72 = (SubPartClass) new TextPartClass("CopyFromSFType: NONE", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.w7textid = this.AddSubPart(ref tsubpart72, 950, 119, 200, 20, 0);
      }
      this.ss = "Click to select reinforcement type. Current Type#: " + this.game.Data.SFTypeObj[this.SFtypeNr].ReinforcementType.ToString();
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart73 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.w9id = this.AddSubPart(ref tsubpart73, 310, 440, 32, 16, 1);
      }
      if (this.game.Data.SFTypeObj[this.SFtypeNr].ReinforcementType > -1)
      {
        SubPartClass tsubpart74 = (SubPartClass) new TextPartClass("ReinforcementType: " + this.game.Data.ReinfName[this.game.Data.SFTypeObj[this.SFtypeNr].ReinforcementType], new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.w9textid = this.AddSubPart(ref tsubpart74, 350, 439, 200, 20, 0);
      }
      else
      {
        SubPartClass tsubpart75 = (SubPartClass) new TextPartClass("ReinforcementType: NONE", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.w9textid = this.AddSubPart(ref tsubpart75, 350, 439, 200, 20, 0);
      }
      this.ss = "Click to set if in auto-reinforce phase this unit type should never be returned from a HQ (do for trucks and trains)";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart76 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.w10id = this.AddSubPart(ref tsubpart76, 310, 600, 32, 16, 1);
      }
      SubPartClass tsubpart77 = (SubPartClass) new TextPartClass("DontReturnFromHQ: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].DontReturnFromHQ), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.w10textid = this.AddSubPart(ref tsubpart77, 350, 599, 200, 20, 0);
      this.ss = "Click to set ConsiderCarry true/false. If false then this sftype weight is added to the prognose weight statistic of a unit it is part of.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart78 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.w12id = this.AddSubPart(ref tsubpart78, 310, 540, 32, 16, 1);
      }
      SubPartClass tsubpart79 = (SubPartClass) new TextPartClass("ConsiderCarry: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ConsiderCarry), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.w12textid = this.AddSubPart(ref tsubpart79, 350, 539, 200, 20, 0);
      this.ss = "Click to reduce the penalty this SFType gets in the first 2 rounds of combat. 1 =full rulevar penalty. 0.5=half, 0=none.";
      if (Strings.Len(this.game.Data.MasterFile) == 0 | !this.game.Data.MasterfileReadPeople)
      {
        SubPartClass tsubpart80 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b36id = this.AddSubPart(ref tsubpart80, 310, 500, 32, 16, 1);
      }
      SubPartClass tsubpart81 = (SubPartClass) new TextPartClass("FirstRoundPenaltyMod: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].FirstRoundPenaltyMod), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b36textid = this.AddSubPart(ref tsubpart81, 350, 499, 200, 20, 0);
      this.ss = "Click to set show/hide in info window lists";
      if (Strings.Len(this.game.Data.MasterFile) == 0 | !this.game.Data.MasterfileReadPeople)
      {
        SubPartClass tsubpart82 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g24id = this.AddSubPart(ref tsubpart82, 910, 180, 32, 16, 1);
      }
      SubPartClass tsubpart83 = (SubPartClass) new TextPartClass("DontShowInList: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].DontShowInList), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.g24textid = this.AddSubPart(ref tsubpart83, 950, 179, 200, 20, 0);
      if (this.game.Data.Product >= 6)
      {
        this.ss = "Click to change Start and End Combat Round";
        if (Strings.Len(this.game.Data.MasterFile) == 0 | !this.game.Data.MasterfileReadPeople)
        {
          SubPartClass tsubpart84 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.w14id = this.AddSubPart(ref tsubpart84, 910, 200, 32, 16, 1);
        }
        SubPartClass tsubpart85 = (SubPartClass) new TextPartClass("Start+End Combat Round: " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].StartCombatRound) + "," + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].EndCombatRound), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.w14textid = this.AddSubPart(ref tsubpart85, 950, 199, 200, 20, 0);
      }
      this.ss = "Click to select secondary reinforcement type. Be careful with this and read docs since its functionality is very limited.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart86 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.w9bid = this.AddSubPart(ref tsubpart86, 310, 520, 32, 16, 1);
      }
      if (this.game.Data.SFTypeObj[this.SFtypeNr].ReinforcementType2 > -1)
      {
        SubPartClass tsubpart87 = (SubPartClass) new TextPartClass("2nd ReinforcementType: " + this.game.Data.ReinfName[this.game.Data.SFTypeObj[this.SFtypeNr].ReinforcementType2], new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.w9btextid = this.AddSubPart(ref tsubpart87, 350, 519, 200, 20, 0);
      }
      else
      {
        SubPartClass tsubpart88 = (SubPartClass) new TextPartClass("2nd ReinforcementType: NONE", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.w9btextid = this.AddSubPart(ref tsubpart88, 350, 519, 200, 20, 0);
      }
      this.tabsheet1b();
    }

    public void tabsheet1b()
    {
      if (this.B4Id > 0)
        this.RemoveSubPart(this.B4Id);
      if (this.B4TextId > 0)
        this.RemoveSubPart(this.B4TextId);
      if (this.detailnr <= -1)
        return;
      this.ss = "Click to toggle on/off if this sftype can be recruited from selected peoplegroup";
      if (Strings.Len(this.game.Data.MasterFile) == 0 | !this.game.Data.MasterfileReadPeople)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B4Id = this.AddSubPart(ref tsubpart, 10, 620, 32, 16, 1);
      }
      if (!(Strings.Len(this.game.Data.MasterFile) == 0 | !this.game.Data.MasterfileReadPeople))
        return;
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Change Value", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B4TextId = this.AddSubPart(ref tsubpart1, 50, 619, 400, 20, 0);
    }

    public void tabsheet2()
    {
      this.ss = "Click to set the initiative of this sftype if attacking and if defending";
      string str1 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].Initiative) + " / " + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].InitiativeDef);
      SubPartClass tsubpart;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b11id = this.AddSubPart(ref tsubpart, 10, 380, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("Initiative: " + str1, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b11textid = this.AddSubPart(ref tsubpart, 50, 379, 200, 20, 0);
      this.ss = "Click to set the number of attacks this sftype can do every combatround (10 ap per combatround)";
      string str2 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].Attacks);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b12id = this.AddSubPart(ref tsubpart, 10, 400, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("Attacks: " + str2, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b12textid = this.AddSubPart(ref tsubpart, 50, 399, 200, 20, 0);
      this.ss = "Click to set the max number of times this sftype can be attacked before these attacks get penalties";
      string str3 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].MaxAttacked);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b13id = this.AddSubPart(ref tsubpart, 10, 420, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("MaxAttacked: " + str3, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b13textid = this.AddSubPart(ref tsubpart, 50, 419, 200, 20, 0);
      this.ss = "Click to set the stackpoints this sftype consumes";
      string str4 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].Frontage);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b14id = this.AddSubPart(ref tsubpart, 10, 440, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("Stack Pts: " + str4, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b14textid = this.AddSubPart(ref tsubpart, 50, 439, 200, 20, 0);
      this.ss = "Click to toggle on/off if this sftype is a rear area sftype (instead of frontline)";
      string str5 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].BackBench);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b15id = this.AddSubPart(ref tsubpart, 10, 460, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("Rear Area: " + str5, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b15textid = this.AddSubPart(ref tsubpart, 50, 459, 200, 20, 0);
      this.ss = "Click to set artillery range. Range of 0 means it has no artillery capability.";
      string str6 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ArtRange);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b16id = this.AddSubPart(ref tsubpart, 10, 480, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("Art.Range: " + str6, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b16textid = this.AddSubPart(ref tsubpart, 50, 479, 200, 20, 0);
      this.ss = "Click to set the number of random enemy individuals the sftype can browse through to select a best opponent.";
      string str7 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].FavTargetTries);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b17id = this.AddSubPart(ref tsubpart, 10, 500, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("FavTarget Tries: " + str7, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b17textid = this.AddSubPart(ref tsubpart, 50, 499, 200, 20, 0);
      this.ss = "Click to set the range of the Anti-Air power of this sftype.";
      string str8 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].AARange);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g16id = this.AddSubPart(ref tsubpart, 10, 520, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("AARange: " + str8, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.g16textid = this.AddSubPart(ref tsubpart, 50, 519, 400, 20, 0);
      this.ss = "Click to set the percentchance that a hit by this sftype is a kill";
      string str9 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].KillPercent)) + "% on target";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b20id = this.AddSubPart(ref tsubpart, 10, 540, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("Kill%: " + str9, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b20textid = this.AddSubPart(ref tsubpart, 50, 539, 200, 20, 0);
      this.ss = "Click to set the percentchance that a hit by this sftype is a retreat for the attacked individual";
      string str10 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].RetreatPercent)) + "% on target";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b22id = this.AddSubPart(ref tsubpart, 10, 560, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("Retreat%: " + str10, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b22textid = this.AddSubPart(ref tsubpart, 50, 559, 400, 20, 0);
      this.ss = "Click to change the description of the sftype.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b27id = this.AddSubPart(ref tsubpart, 310, 360, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new TextPartClass("Change Description", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.b27textid = this.AddSubPart(ref tsubpart, 350, 359, 200, 20, 0);
      }
      this.ss = "Click to let this SFType use the LandscapeMod table of another SFType for artillery attacks.";
      string str11 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ArtSFType);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.w13id = this.AddSubPart(ref tsubpart, 10, 580, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("Artillery Mod Sftyp: " + str11, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.w13textid = this.AddSubPart(ref tsubpart, 50, 579, 200, 20, 0);
      this.ss = "If ind. scores a RETREAT or KILL hit on enemy (that consumed supply last turn) it has a 0.x chance to get killed. 0.05=5% chance. Only done for att side! ";
      string str12 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ChanceOnDeathIfMakeHit) + "%";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.w133id = this.AddSubPart(ref tsubpart, 10, 600, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("ChanceOnDeathIfMakeHit: " + str12, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 250, 20, false, tDescript: this.ss);
      this.w133textid = this.AddSubPart(ref tsubpart, 50, 599, 250, 20, 0);
      this.ss = "";
      string str13 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].directRange);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.w15id = this.AddSubPart(ref tsubpart, 10, 620, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("DirectRange: " + str13, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 250, 20, false, tDescript: this.ss);
      this.w15textid = this.AddSubPart(ref tsubpart, 50, 619, 250, 20, 0);
      this.ss = "";
      string str14 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].directModFirstHex);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.w16id = this.AddSubPart(ref tsubpart, 10, 640, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("DirectModFirstHex: " + str14, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 250, 20, false, tDescript: this.ss);
      this.w16textid = this.AddSubPart(ref tsubpart, 50, 639, 250, 20, 0);
      this.ss = "";
      string str15 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].directModPerHex);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.w17id = this.AddSubPart(ref tsubpart, 10, 660, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("DirectModPerHex: " + str15, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 250, 20, false, tDescript: this.ss);
      this.w17textid = this.AddSubPart(ref tsubpart, 50, 659, 250, 20, 0);
      string tText = this.game.Data.SFTypeObj[this.SFtypeNr].Description;
      if (this.game.Data.Product >= 7)
      {
        int index = 0;
        do
        {
          if (this.game.Data.SFTypeObj[this.SFtypeNr].SFTypeVar[index] > 0)
            tText = tText + "\r\n" + "SFTYPEVAR_" + index.ToString() + "=" + this.game.Data.SFTypeObj[this.SFtypeNr].SFTypeVar[index].ToString();
          ++index;
        }
        while (index <= 99);
      }
      tsubpart = (SubPartClass) new TextAreaClass(this.game, 650, 10, new Font("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), "Description", false, tText, Color.White, tbackbitmap: (ref this.OwnBitmap), bbx: 310, bby: 390);
      this.b28id = this.AddSubPart(ref tsubpart, 310, 390, 650, 208, 0);
    }

    public void tabsheet9()
    {
      this.ss = "Which regimevar # is used as fuel resource";
      string str1 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].FuelRegimeVar);
      SubPartClass tsubpart;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c2id = this.AddSubPart(ref tsubpart, 10, 380, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("FuelRegimeVar: " + str1, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c2textid = this.AddSubPart(ref tsubpart, 50, 379, 200, 20, 0);
      this.ss = "For every 10AP the SFType moves it needs this QTY of fuel.";
      string str2 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].FuelForMove);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c3id = this.AddSubPart(ref tsubpart, 10, 400, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("FuelForMove(10ap): " + str2, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c3textid = this.AddSubPart(ref tsubpart, 50, 399, 200, 20, 0);
      this.ss = "If the fuel is not available movement cost will be multiplied.. 2=double movement cost. 3=3x movement cost ";
      string str3 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].OutOfFuelMove);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c4id = this.AddSubPart(ref tsubpart, 10, 420, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("OutOfFuelMove: " + str3, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c4textid = this.AddSubPart(ref tsubpart, 50, 419, 200, 20, 0);
      this.ss = "For every combatround (10AP) the SFType needs this QTY of fuel/";
      string str4 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].FuelForAttack) + "/" + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].FuelForAttackDef);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c5id = this.AddSubPart(ref tsubpart, 10, 440, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("FuelForAttack(10ap): " + str4, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c5textid = this.AddSubPart(ref tsubpart, 50, 439, 200, 20, 0);
      this.ss = "If fuel is not available in a given combatround and the SFType is attacking. Its strength will be modified by X. 0.5=halved.";
      string str5 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].OutOfFuelAttack);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c6id = this.AddSubPart(ref tsubpart, 10, 460, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("OutOfFuelAttack: " + str5, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c6textid = this.AddSubPart(ref tsubpart, 50, 459, 200, 20, 0);
      this.ss = "If fuel is not available in a given combatround and the SFType is defending. Its strength will be modified by X. 0.5=halved.";
      string str6 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].OutOfFuelDefense);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c7id = this.AddSubPart(ref tsubpart, 10, 480, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("OutOfFuelDefense: " + str6, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c7textid = this.AddSubPart(ref tsubpart, 50, 479, 200, 20, 0);
      this.ss = "Copy fuel stats from specified SFType number";
      Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].OutOfFuelDefense);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
        this.y2id = this.AddSubPart(ref tsubpart, 10, 520, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("Copy fuel stats from..", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.y1textid = this.AddSubPart(ref tsubpart, 50, 519, 200, 20, 0);
      this.ss = "Howmuch supply is taken out of the stockpile per round of attack. 0=no stockpile rule.";
      string str7 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].StockpileUsedPerRound);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c12id = this.AddSubPart(ref tsubpart, 410, 380, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("StockUsePerRound: " + str7, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c12textid = this.AddSubPart(ref tsubpart, 450, 379, 200, 20, 0);
      this.ss = "Maximum size of the stockpile";
      string str8 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].StockpileMax);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c13id = this.AddSubPart(ref tsubpart, 410, 400, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("StockPileMax: " + str8, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c13textid = this.AddSubPart(ref tsubpart, 450, 399, 200, 20, 0);
      this.ss = "0=no maximum/rule not used. Otherwise maximum stockpile supply request in per round.";
      string str9 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].StockpileMaxIn);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c14id = this.AddSubPart(ref tsubpart, 410, 420, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("StockPileMaxIn: " + str9, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c14textid = this.AddSubPart(ref tsubpart, 450, 419, 200, 20, 0);
      this.ss = "Any attack made by this sftype, artillery or otherwise is modified with out of stockmod when no stockpile left.";
      string str10 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].StockpileDepletedMod);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c15id = this.AddSubPart(ref tsubpart, 410, 440, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("OutofStockMod): " + str10, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c15textid = this.AddSubPart(ref tsubpart, 450, 439, 200, 20, 0);
      this.ss = "0=no maximum/rule not used. Otherwise its the maximum supply request in per round.";
      string str11 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].SupplyMaxIn);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c16id = this.AddSubPart(ref tsubpart, 410, 480, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("SupplyMaxIn " + str11, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c16textid = this.AddSubPart(ref tsubpart, 450, 479, 200, 20, 0);
      this.ss = ".";
      string str12 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].SupplyForAttack);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c17id = this.AddSubPart(ref tsubpart, 710, 380, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("SupplyForAttack: " + str12, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c17textid = this.AddSubPart(ref tsubpart, 750, 379, 200, 20, 0);
      this.ss = ".";
      string str13 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].SupplyForAttackDef);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c18id = this.AddSubPart(ref tsubpart, 710, 400, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("SupplyForAttackDef: " + str13, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c18textid = this.AddSubPart(ref tsubpart, 750, 399, 200, 20, 0);
      this.ss = ".";
      string str14 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].OutOfSupplyAttack);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c19id = this.AddSubPart(ref tsubpart, 710, 420, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("OutOfSupplyAttack: " + str14, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c19textid = this.AddSubPart(ref tsubpart, 750, 419, 200, 20, 0);
      this.ss = ".";
      string str15 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].OutOfSupplyDefense);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c20id = this.AddSubPart(ref tsubpart, 710, 440, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("OutOfSupplyDefense: " + str15, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c20textid = this.AddSubPart(ref tsubpart, 750, 439, 200, 20, 0);
      this.ss = ".";
      string str16 = Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].FuelCarry);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.c21id = this.AddSubPart(ref tsubpart, 710, 480, 32, 16, 1);
      }
      tsubpart = (SubPartClass) new TextPartClass("FuelCarry: " + str16, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.c21textid = this.AddSubPart(ref tsubpart, 750, 479, 200, 20, 0);
    }

    public void tabsheet3()
    {
      this.CombatListObj = new ListClass();
      if (this.detailnr < -1 | this.detailnr > 99)
        this.detailnr = -1;
      int index = 0;
      do
      {
        string str1 = "";
        string str2 = Conversion.Str((object) index) + ") " + this.game.Data.TempString[index + 400];
        if (Strings.Len(str2) > 15)
          str2 = Strings.Left(str2, 15);
        string str3 = str1 + str2 + Strings.Space(25 - Strings.Len(str2));
        string Expression1 = "Fav=" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].FavTarget[index]));
        string str4 = str3 + Expression1 + Strings.Space(12 - Strings.Len(Expression1));
        string Expression2 = "Pow=" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].AttackPower[index]));
        string str5 = str4 + Expression2 + Strings.Space(12 - Strings.Len(Expression2));
        string Expression3 = "PowDef=" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].AttackPowerDef[index]));
        string str6 = str5 + Expression3 + Strings.Space(12 - Strings.Len(Expression3));
        string Expression4 = "ArtPow=" + Strings.Trim(Conversion.Str(RuntimeHelpers.GetObjectValue(this.game.Data.SFTypeObj[this.SFtypeNr].AttackArt[index])));
        string str7 = str6 + Expression4 + Strings.Space(12 - Strings.Len(Expression4));
        string Expression5 = "ArtFav=" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].FavArtTarget[index]));
        string str8 = str7 + Expression5 + Strings.Space(12 - Strings.Len(Expression5));
        string Expression6 = "HitPts=" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].HitPoints[index]));
        this.CombatListObj.add(str8 + Expression6 + Strings.Space(12 - Strings.Len(Expression6)) + ("HitPtsDef=" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].HitPointsDef[index]))), index);
        ++index;
      }
      while (index <= 99);
      if (this.game.ScreenHeight >= 800)
      {
        ListClass combatListObj = this.CombatListObj;
        int detailnr = this.detailnr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(combatListObj, 16, 880, detailnr, game, true, tbackbitmap: (ref local1), bbx: 10, bby: 340, overruleFont: (ref local2));
        this.CombatListId = this.AddSubPart(ref tsubpart, 10, 340, 880, 304, 0);
      }
      else
      {
        ListClass combatListObj = this.CombatListObj;
        int detailnr = this.detailnr;
        GameClass game = this.game;
        ref Bitmap local3 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local4 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(combatListObj, 12, 880, detailnr, game, true, tbackbitmap: (ref local3), bbx: 10, bby: 340, overruleFont: (ref local4));
        this.CombatListId = this.AddSubPart(ref tsubpart, 10, 340, 880, 240, 0);
      }
      if (this.detailnr <= -1)
        return;
      this.tabsheet3b();
    }

    public void tabsheet3b()
    {
      this.ss = "Click to set how favourite this unitgroup is as a target for this sftype. the higher the more favourite.";
      string str1 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].FavTarget[this.detailnr]));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b18id = this.AddSubPart(ref tsubpart, 910, 340, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("Fav: " + str1, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.b18textid = this.AddSubPart(ref tsubpart, 950, 339, 400, 20, 0);
      }
      this.ss = "Click to set the attackpower of this sftype in offense versus this unitgroup.";
      string str2 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].AttackPower[this.detailnr]));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b19id = this.AddSubPart(ref tsubpart, 910, 360, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("Pow: " + str2, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.b19textid = this.AddSubPart(ref tsubpart, 950, 359, 400, 20, 0);
      }
      this.ss = "Click to set the attackpower of this sftype in defense versus this unitgroup.";
      string str3 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].AttackPowerDef[this.detailnr]));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b23id = this.AddSubPart(ref tsubpart, 910, 380, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("PowDef: " + str3, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.b23textid = this.AddSubPart(ref tsubpart, 950, 379, 400, 20, 0);
      }
      this.ss = "Click to set the attackpower of this sftype versus this unitgroup if it does an artillery attack";
      string str4 = Strings.Trim(Conversion.Str(RuntimeHelpers.GetObjectValue(this.game.Data.SFTypeObj[this.SFtypeNr].AttackArt[this.detailnr])));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b25id = this.AddSubPart(ref tsubpart, 910, 400, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("ArtPow: " + str4, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.b25textid = this.AddSubPart(ref tsubpart, 950, 399, 400, 20, 0);
      }
      this.ss = "Click to set how favourite this unitgroup is as a target for an artillery attack of this sftype. the higher the more favourite.";
      string str5 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].FavArtTarget[this.detailnr]));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b26id = this.AddSubPart(ref tsubpart, 910, 420, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("ArtFav: " + str5, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.b26textid = this.AddSubPart(ref tsubpart, 950, 419, 400, 20, 0);
      }
      this.ss = "Click to set hitpoints when attacking a hex.";
      string str6 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].HitPoints[this.detailnr]));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b37id = this.AddSubPart(ref tsubpart, 910, 440, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("HitPoints: " + str6, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.b37textid = this.AddSubPart(ref tsubpart, 950, 439, 400, 20, 0);
      }
      this.ss = "Click to set hitpoints when defending a hex.";
      string str7 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].HitPointsDef[this.detailnr]));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b38id = this.AddSubPart(ref tsubpart, 910, 460, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("HitPointsDef: " + str7, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.b38textid = this.AddSubPart(ref tsubpart, 950, 459, 400, 20, 0);
      }
      this.ss = "Click to copy the stats in this table from another SFtype.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
        this.copyid = this.AddSubPart(ref tsubpart, 910, 480, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("Copy combattable from ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.copytextid = this.AddSubPart(ref tsubpart, 950, 479, 400, 20, 0);
      }
      this.ss = "Click to set all att/def hitpoints in 1 go.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
        this.y1id = this.AddSubPart(ref tsubpart, 910, 500, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Set ALL hitpoints ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.y1textid = this.AddSubPart(ref tsubpart1, 950, 499, 400, 20, 0);
    }

    public void tabsheet4()
    {
      this.CombatList2Obj = new ListClass();
      if (this.detailnr < -1 | this.detailnr > this.game.Data.LandscapeTypeCounter)
        this.detailnr = -1;
      int landscapeTypeCounter = this.game.Data.LandscapeTypeCounter;
      for (int index = 0; index <= landscapeTypeCounter; ++index)
      {
        string str1 = "";
        string Expression1 = Conversion.Str((object) index) + ") " + this.game.Data.LandscapeTypeObj[index].Name;
        if (Strings.Len(Expression1) > 30)
          Expression1 = Strings.Left(str1, 15);
        string str2 = str1 + Expression1 + Strings.Space(29 - Math.Min(28, Strings.Len(Expression1)));
        string Expression2 = "Att=" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].CombatModAtt[index]));
        string str3 = str2 + Expression2 + Strings.Space(13 - Strings.Len(Expression2));
        string Expression3 = "Def=" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].CombatModDef[index]));
        string tname = str3 + Expression3 + Strings.Space(13 - Strings.Len(Expression3));
        if ((double) this.game.Data.RuleVar[900] > 0.0)
        {
          string str4 = "ExtraRecon=" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ExtraRecon[index]));
          tname += str4;
        }
        this.CombatList2Obj.add(tname, index);
      }
      ListClass combatList2Obj = this.CombatList2Obj;
      int detailnr = this.detailnr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(combatList2Obj, 12, 580, detailnr, game, true, tbackbitmap: (ref local1), bbx: 10, bby: 340, overruleFont: (ref local2));
      this.CombatList2Id = this.AddSubPart(ref tsubpart, 10, 340, 580, 240, 0);
      if (this.detailnr <= -1)
        return;
      this.tabsheet4b();
    }

    public void tabsheet4b()
    {
      this.ss = "Click to set the modifier for this sftype if it attacks this landscape. 1=no mod, 0.5=half power, 1.5=+50% power";
      string str1 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].CombatModAtt[this.detailnr]));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g13id = this.AddSubPart(ref tsubpart, 610, 340, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("Att: " + str1, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.g13textid = this.AddSubPart(ref tsubpart, 650, 339, 400, 20, 0);
      }
      this.ss = "Click to set the modifier for this sftype if it defends in this landscape. 1=no mod, 0.5=half power, 1.5=+50% power";
      string str2 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].CombatModDef[this.detailnr]));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.g14id = this.AddSubPart(ref tsubpart, 610, 360, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("Def: " + str2, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.g14textid = this.AddSubPart(ref tsubpart, 650, 359, 400, 20, 0);
      }
      if ((double) this.game.Data.RuleVar[900] > 0.0)
      {
        this.ss = "Click to set the recon value this SFType has if it looks through a special connection. Only for its main hex to direct connections.";
        string str3 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ExtraRecon[this.detailnr]));
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.g23id = this.AddSubPart(ref tsubpart, 610, 380, 32, 16, 1);
        }
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new TextPartClass("ExtRec: " + str3, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
          this.g23textid = this.AddSubPart(ref tsubpart, 650, 379, 400, 20, 0);
        }
      }
      this.ss = "Click to set these att and def modifiers for all sftypes with the same unitgroup.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
        this.w8id = this.AddSubPart(ref tsubpart, 610, 400, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("Set for all (unitgroup)", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.w8textid = this.AddSubPart(ref tsubpart, 650, 399, 400, 20, 0);
      }
      this.ss = "Click to set these att and def modifiers for all sftypes with the same unitgroup.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
        this.b39id = this.AddSubPart(ref tsubpart, 610, 420, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("Set for all (reinfgroup)", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.b39textid = this.AddSubPart(ref tsubpart, 650, 419, 400, 20, 0);
      }
      this.ss = "Click to copy from a specific SFType #";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
        this.t1id = this.AddSubPart(ref tsubpart, 610, 450, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Copy from SFType #", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.t1textid = this.AddSubPart(ref tsubpart1, 650, 449, 400, 20, 0);
    }

    public void tabsheet7()
    {
      if (this.detailnr2 > 99)
        this.detailnr2 = -1;
      this.LogoListObj = new ListClass();
      int index = 0;
      do
      {
        this.LogoListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.TempString[1100 + index] + " = '" + this.game.Data.SFTypeObj[this.SFtypeNr].LogoString[index] + "'" + " , nato=" + this.game.Data.TempString[1000 + index], index);
        ++index;
      }
      while (index <= 99);
      ListClass logoListObj = this.LogoListObj;
      int detailnr2 = this.detailnr2;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(logoListObj, 10, 350, detailnr2, game, true, "Logostrings", tbackbitmap: (ref local1), bbx: 10, bby: 340, overruleFont: (ref local2));
      this.LogoListId = this.AddSubPart(ref tsubpart1, 10, 340, 350, 208, 0);
      if (this.detailnr2 <= -1)
        return;
      this.ss = "Set string , no string is no stat and it will not be shown.";
      SubPartClass tsubpart2;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.j1id = this.AddSubPart(ref tsubpart2, 10, 570, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("Set string ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.j1textid = this.AddSubPart(ref tsubpart2, 50, 569, 400, 20, 0);
    }

    public void tabsheet8()
    {
      if (this.detailnr2 > this.game.Data.SFTypeObj[this.SFtypeNr].PreventCounter)
        this.detailnr2 = -1;
      this.PreventListObj = new ListClass();
      int preventCounter = this.game.Data.SFTypeObj[this.SFtypeNr].PreventCounter;
      for (int index = 0; index <= preventCounter; ++index)
      {
        string str1 = Conversion.Str((object) index) + ") ";
        string str2 = this.game.Data.SFTypeObj[this.SFtypeNr].PreventHitOn[index] <= -1 ? "ALL" : this.game.Data.TempString[400 + this.game.Data.SFTypeObj[this.SFtypeNr].PreventHitOn[index]];
        if (Strings.Len(str2) > 12)
          str2 = Strings.Left(str2, 12);
        string str3 = str1 + str2 + Strings.Space(15 - Strings.Len(str2));
        string str4 = this.game.Data.SFTypeObj[this.SFtypeNr].PreventHitFrom[index] <= -1 ? "ALL" : this.game.Data.TempString[400 + this.game.Data.SFTypeObj[this.SFtypeNr].PreventHitFrom[index]];
        if (Strings.Len(str4) > 12)
          str4 = Strings.Left(str4, 12);
        string str5 = str3 + str4 + Strings.Space(15 - Strings.Len(str4));
        string Expression1 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].PreventPriority[index]));
        string str6 = str5 + Expression1 + Strings.Space(10 - Strings.Len(Expression1));
        string Expression2 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].PreventChance[index])) + "%";
        this.PreventListObj.add(str6 + Expression2 + Strings.Space(10 - Strings.Len(Expression2)) + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].PreventPoints[index])), index);
      }
      ListClass preventListObj = this.PreventListObj;
      int detailnr2 = this.detailnr2;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(preventListObj, 9, 450, detailnr2, game, true, "#  ON               FROM            PRIORITY    CHANCE   POINTS", tbackbitmap: (ref local1), bbx: 10, bby: 340, overruleFont: (ref local2));
      this.PreventListId = this.AddSubPart(ref tsubpart1, 10, 340, 450, 192, 0);
      SubPartClass tsubpart2;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.p1id = this.AddSubPart(ref tsubpart2, 10, 550, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("add a prevent ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.p1textid = this.AddSubPart(ref tsubpart2, 50, 549, 400, 20, 0);
      if (this.detailnr2 > -1)
      {
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
          this.p2id = this.AddSubPart(ref tsubpart2, 10, 570, 32, 16, 1);
        }
        tsubpart2 = (SubPartClass) new TextPartClass("remove this prevent ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.p2textid = this.AddSubPart(ref tsubpart2, 50, 569, 400, 20, 0);
        this.ss = "";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.p3id = this.AddSubPart(ref tsubpart2, 510, 340, 32, 16, 1);
        }
        tsubpart2 = (SubPartClass) new TextPartClass("Set Prevent Hit On", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.p3textid = this.AddSubPart(ref tsubpart2, 550, 339, 400, 20, 0);
        this.ss = "";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.p4id = this.AddSubPart(ref tsubpart2, 510, 360, 32, 16, 1);
        }
        tsubpart2 = (SubPartClass) new TextPartClass("Set Prevent Hit From", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.p4textid = this.AddSubPart(ref tsubpart2, 550, 359, 400, 20, 0);
        this.ss = "";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.p5id = this.AddSubPart(ref tsubpart2, 510, 380, 32, 16, 1);
        }
        tsubpart2 = (SubPartClass) new TextPartClass("Set Prevent Priority", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.p5textid = this.AddSubPart(ref tsubpart2, 550, 379, 400, 20, 0);
        this.ss = "";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.p6id = this.AddSubPart(ref tsubpart2, 510, 400, 32, 16, 1);
        }
        tsubpart2 = (SubPartClass) new TextPartClass("Set Prevent Chance", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.p6textid = this.AddSubPart(ref tsubpart2, 550, 399, 400, 20, 0);
        this.ss = "";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.p7id = this.AddSubPart(ref tsubpart2, 510, 420, 32, 16, 1);
        }
        tsubpart2 = (SubPartClass) new TextPartClass("Set Prevent Points", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.p7textid = this.AddSubPart(ref tsubpart2, 550, 419, 400, 20, 0);
      }
      this.ss = "How many prevent points can this sftype provide to sheltering other sftypes";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.p8id = this.AddSubPart(ref tsubpart2, 810, 340, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("MaxPrvPointsUsed=" + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].MaxPreventPointsUsed), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.p8textid = this.AddSubPart(ref tsubpart2, 850, 339, 400, 20, 0);
      this.ss = "How many preventers pts can this sftype use to be prevented it self by another sftype";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.p9id = this.AddSubPart(ref tsubpart2, 810, 360, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("MaxPrvPointsGiven" + Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].MaxPreventPointsGiven), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.p9textid = this.AddSubPart(ref tsubpart2, 850, 359, 400, 20, 0);
    }

    public void tabsheet10()
    {
      if (this.detailnr2 > this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCounter)
        this.detailnr2 = -1;
      this.VariantListObj = new ListClass();
      int modelVariantCounter = this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCounter;
      for (int index = 0; index <= modelVariantCounter; ++index)
      {
        string str1 = Conversion.Str((object) index) + ") ";
        string str2 = this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantName[index];
        if (Strings.Len(str2) > 28)
          str2 = Strings.Left(str2, 28);
        string str3 = str1 + str2 + Strings.Space(30 - Strings.Len(str2));
        string Expression = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCheck[index]));
        this.VariantListObj.add(str3 + Expression + Strings.Space(10 - Strings.Len(Expression)) + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantExec[index])), index);
      }
      ListClass variantListObj = this.VariantListObj;
      int detailnr2 = this.detailnr2;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(variantListObj, 9, 450, detailnr2, game, true, "#  ALTERATION NAME              CHECK    EXEC", tbackbitmap: (ref local1), bbx: 10, bby: 340, overruleFont: (ref local2));
      this.VariantListId = this.AddSubPart(ref tsubpart1, 10, 340, 450, 192, 0);
      SubPartClass tsubpart2;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.vp1id = this.AddSubPart(ref tsubpart2, 10, 550, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("add an alteration ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.vp1textid = this.AddSubPart(ref tsubpart2, 50, 549, 400, 20, 0);
      if (this.detailnr2 <= -1)
        return;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.vp2id = this.AddSubPart(ref tsubpart2, 10, 570, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("remove this alteration ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.vp2textid = this.AddSubPart(ref tsubpart2, 50, 569, 400, 20, 0);
      this.ss = "";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.vp3id = this.AddSubPart(ref tsubpart2, 510, 340, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("Set Name", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.vp3textid = this.AddSubPart(ref tsubpart2, 550, 339, 400, 20, 0);
      this.ss = "";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.vp4id = this.AddSubPart(ref tsubpart2, 510, 360, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("Set Check", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.vp4textid = this.AddSubPart(ref tsubpart2, 550, 359, 400, 20, 0);
      this.ss = "";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.vp5id = this.AddSubPart(ref tsubpart2, 510, 380, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("Set Exec", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.vp5textid = this.AddSubPart(ref tsubpart2, 550, 379, 400, 20, 0);
    }

    public void tabsheet5()
    {
      if (this.detailnr2 > this.game.Data.ResearchCounter)
        this.detailnr2 = -1;
      this.ResListObj = new ListClass();
      int researchCounter = this.game.Data.ResearchCounter;
      for (int index1 = 0; index1 <= researchCounter; ++index1)
      {
        string str1 = "";
        string str2 = Conversion.Str((object) index1) + ") " + this.game.Data.ResearchObj[index1].Name;
        if (Strings.Len(str2) > 17)
          str2 = Strings.Left(str2, 17);
        string str3 = str1 + str2 + Strings.Space(19 - Strings.Len(str2));
        string Expression1 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelLastState[index1]));
        string str4 = str3 + Expression1 + Strings.Space(5 - Strings.Len(Expression1));
        string Expression2 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelPossibleImp[index1]));
        string str5 = str4 + Expression2 + Strings.Space(5 - Strings.Len(Expression2));
        string Expression3 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelImproveEvent[index1]));
        string str6 = str5 + Expression3 + Strings.Space(5 - Strings.Len(Expression3));
        int Number = 0;
        int index2 = 1;
        while (this.game.Data.SFTypeObj[this.SFtypeNr].ModelResearch[index2] != index1)
        {
          ++index2;
          if (index2 > 9)
            goto label_9;
        }
        Number = index2;
label_9:
        string Expression4 = Strings.Trim(Conversion.Str((object) Number));
        this.ResListObj.add(str6 + Expression4 + Strings.Space(3 - Strings.Len(Expression4)) + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelAutoImprovement[index1])), index1);
      }
      ListClass resListObj = this.ResListObj;
      int detailnr2 = this.detailnr2;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(resListObj, 10, 350, detailnr2, game, true, "NAME           ST   POS   EV   RES  AUTO", tbackbitmap: (ref local1), bbx: 10, bby: 340, overruleFont: (ref local2));
      this.ResListId = this.AddSubPart(ref tsubpart1, 10, 340, 350, 208, 0);
      SubPartClass tsubpart2;
      if (this.detailnr2 > -1)
      {
        this.ss = "Set ModelLastState";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.v1id = this.AddSubPart(ref tsubpart3, 10, 570, 32, 16, 1);
        }
        tsubpart2 = (SubPartClass) new TextPartClass("Set Modellaststate ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.v1textid = this.AddSubPart(ref tsubpart2, 50, 569, 400, 20, 0);
        this.ss = "Set Possible Improvement";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.v2id = this.AddSubPart(ref tsubpart2, 10, 590, 32, 16, 1);
        }
        tsubpart2 = (SubPartClass) new TextPartClass("Set Possible Improvement ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.v2textid = this.AddSubPart(ref tsubpart2, 50, 589, 400, 20, 0);
        this.ss = "Set Improve Event";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.v3id = this.AddSubPart(ref tsubpart2, 10, 610, 32, 16, 1);
        }
        tsubpart2 = (SubPartClass) new TextPartClass("Set Improve Event ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.v3textid = this.AddSubPart(ref tsubpart2, 50, 609, 400, 20, 0);
        this.ss = "Set Research for Level";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.v4id = this.AddSubPart(ref tsubpart2, 10, 630, 32, 16, 1);
        }
        tsubpart2 = (SubPartClass) new TextPartClass("Set Research for Level ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.v4textid = this.AddSubPart(ref tsubpart2, 50, 629, 400, 20, 0);
        this.ss = "Change if it is auto-improvement field";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.v16id = this.AddSubPart(ref tsubpart2, 10, 650, 32, 16, 1);
        }
        tsubpart2 = (SubPartClass) new TextPartClass("ModelAutoimprovement ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.v16textid = this.AddSubPart(ref tsubpart2, 50, 649, 400, 20, 0);
      }
      this.ss = "";
      string str7 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelIsBase));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v5id = this.AddSubPart(ref tsubpart2, 410, 340, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("ModelisBase = " + str7, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.v5textid = this.AddSubPart(ref tsubpart2, 450, 339, 400, 20, 0);
      this.ss = "";
      string str8 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelCostType));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v6id = this.AddSubPart(ref tsubpart2, 410, 360, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("ModelCostType = " + str8, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.v6textid = this.AddSubPart(ref tsubpart2, 450, 359, 400, 20, 0);
      this.ss = "";
      string str9 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelCost));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v7id = this.AddSubPart(ref tsubpart2, 410, 380, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("ModelCost = " + str9, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.v7textid = this.AddSubPart(ref tsubpart2, 450, 379, 400, 20, 0);
      this.ss = "";
      string str10 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelCostPerLevel));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v8id = this.AddSubPart(ref tsubpart2, 410, 400, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("ModelCostPerLevel = " + str10, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.v8textid = this.AddSubPart(ref tsubpart2, 450, 399, 400, 20, 0);
      this.ss = "";
      string str11 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelCostPerSameModel));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v9id = this.AddSubPart(ref tsubpart2, 410, 420, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("ModelCostPerSameModel= " + str11, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.v9textid = this.AddSubPart(ref tsubpart2, 450, 419, 400, 20, 0);
      this.ss = "";
      string str12 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelNewEvent));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v10id = this.AddSubPart(ref tsubpart2, 410, 440, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("ModelNewEvent = " + str12, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.v10textid = this.AddSubPart(ref tsubpart2, 450, 439, 400, 20, 0);
      this.ss = "";
      string str13 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelNameList));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v11id = this.AddSubPart(ref tsubpart2, 410, 460, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("ModelNameList strlID= " + str13, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.v11textid = this.AddSubPart(ref tsubpart2, 450, 459, 400, 20, 0);
      this.ss = "";
      string str14 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelAllowUpgrade));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v12id = this.AddSubPart(ref tsubpart2, 410, 480, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("ModelAllowUpgrade = " + str14, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.v12textid = this.AddSubPart(ref tsubpart2, 450, 479, 400, 20, 0);
      this.ss = "";
      string str15 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelAllowImprovements));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v13id = this.AddSubPart(ref tsubpart2, 710, 340, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("ModelAllowImprovements= " + str15, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.v13textid = this.AddSubPart(ref tsubpart2, 750, 339, 400, 20, 0);
      this.ss = "";
      string str16 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelImproveCostMod));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v14id = this.AddSubPart(ref tsubpart2, 710, 360, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("ModelImproveCost= " + str16, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.v14textid = this.AddSubPart(ref tsubpart2, 750, 359, 400, 20, 0);
      this.ss = "";
      string str17 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelItemType));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v15id = this.AddSubPart(ref tsubpart2, 710, 380, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("Modelitemtype= " + str17, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.v15textid = this.AddSubPart(ref tsubpart2, 750, 379, 400, 20, 0);
      this.ss = "";
      string str18 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelRegime));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v17id = this.AddSubPart(ref tsubpart2, 710, 420, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("Modelregime= " + str18, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.v17textid = this.AddSubPart(ref tsubpart2, 750, 419, 400, 20, 0);
      this.ss = "You need to have this research before you can make a NEW of this basemodel.";
      string str19 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelResearch[0]));
      if (this.game.Data.SFTypeObj[this.SFtypeNr].ModelResearch[0] > -1)
        str19 = this.game.Data.ResearchObj[this.game.Data.SFTypeObj[this.SFtypeNr].ModelResearch[0]].Name;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v18id = this.AddSubPart(ref tsubpart2, 710, 440, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("Modelresearch(0)= " + str19, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.v18textid = this.AddSubPart(ref tsubpart2, 750, 439, 400, 20, 0);
      this.ss = "";
      string str20 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelInitialForAll));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v19id = this.AddSubPart(ref tsubpart2, 710, 460, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("ModelInitialForAll= " + str20, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.v19textid = this.AddSubPart(ref tsubpart2, 750, 459, 400, 20, 0);
      string str21 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelInitialEvent));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v20id = this.AddSubPart(ref tsubpart2, 710, 480, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("ModelInitialevent= " + str21, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.v20textid = this.AddSubPart(ref tsubpart2, 750, 479, 400, 20, 0);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.v21id = this.AddSubPart(ref tsubpart2, 710, 500, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("Copy all Model settings from #", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.v21textid = this.AddSubPart(ref tsubpart2, 750, 499, 400, 20, 0);
      string str22 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelExtraResearch));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v22id = this.AddSubPart(ref tsubpart2, 710, 520, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("ModelExtraResearch=" + str22, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.v22textid = this.AddSubPart(ref tsubpart2, 750, 519, 400, 20, 0);
      this.ss = "Modifies the setting of upgrade cost for upgrading an SFType in the field for an old model. 1=normal";
      string str23 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].ModelSFTypeUpgrade));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.v23id = this.AddSubPart(ref tsubpart2, 710, 540, 32, 16, 1);
      }
      tsubpart2 = (SubPartClass) new TextPartClass("ModelSFTypeUpgrade=" + str23, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.v23textid = this.AddSubPart(ref tsubpart2, 750, 539, 400, 20, 0);
    }

    public void tabsheet5b()
    {
    }

    public void tabsheet6()
    {
      this.CombatList4Obj = new ListClass();
      if (this.detailnr < -1 | this.detailnr > 99)
        this.detailnr = -1;
      int num1 = -1;
      int num2 = -1;
      int index = 1;
      do
      {
        string str = "";
        string Expression = Conversion.Str((object) index) + ") ";
        if (index == 1)
          Expression += "Staff";
        if (index == 2)
          Expression += "";
        if (index == 3)
          Expression += "";
        if (index == 4)
          Expression += "";
        if (index == 5)
          Expression += "Engineer";
        if (index == 6)
          Expression += "Infantry";
        if (index == 7)
          Expression += "Inf-Support";
        if (index == 8)
          Expression += "Artillery";
        if (index == 9)
          Expression += "Mobilizer";
        if (index == 10)
          Expression += "Armour";
        if (index == 11)
          Expression += "";
        if (index == 12)
          Expression += "AA";
        if (index == 13)
          Expression += "Fighter";
        if (index == 14)
          Expression += "Bomber Tactical";
        if (index == 15)
          Expression += "";
        if (index == 16)
          Expression += "";
        if (index == 17)
          Expression += "Cargoship";
        if (index == 18)
          Expression += "Naval Supriority";
        if (index == 19)
          Expression += "Raider";
        if (index == 20)
          Expression += "";
        if (index == 21)
          Expression += "";
        if (index == 22)
          Expression += "";
        if (Strings.Len(Expression) > 30)
          Expression = Strings.Left(str, 15);
        string tname = str + Expression + Strings.Space(30 - Strings.Len(Expression)) + ("Score=" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].AIRoleScore[index])));
        ++num2;
        if (this.detailnr == index)
          num1 = num2;
        this.CombatList4Obj.add(tname, index);
        ++index;
      }
      while (index <= 49);
      ListClass combatList4Obj = this.CombatList4Obj;
      int tlistselect = num1;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(combatList4Obj, 12, 580, tlistselect, game, true, tbackbitmap: (ref local1), bbx: 10, bby: 340, overruleFont: (ref local2));
      this.combatlist4id = this.AddSubPart(ref tsubpart, 10, 340, 580, 240, 0);
      if (this.detailnr <= -1)
        return;
      this.tabsheet6b();
    }

    public void tabsheet6b()
    {
      this.ss = "Set the AIRolescore for this sftype. Basicly you set 100 at the role it is supposed to be used at.";
      string str = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].AIRoleScore[this.detailnr]));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.h3id = this.AddSubPart(ref tsubpart, 610, 340, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("AIRoleScore: " + str, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.h3textid = this.AddSubPart(ref tsubpart, 650, 339, 400, 20, 0);
      }
      this.ss = "Set the AIRolescore for this sftype. And all with the same Unitgroup";
      Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.SFtypeNr].AIRoleScore[this.detailnr]));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
        this.w11id = this.AddSubPart(ref tsubpart, 610, 380, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Set for all", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.w11textid = this.AddSubPart(ref tsubpart1, 650, 379, 400, 20, 0);
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
            if (num1 == this.SFtypeListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.SFtypeNr = num2;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                this.MakeSFtypeTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.LibListId)
            {
              int num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num3 > -1)
              {
                this.LibNr = num3;
                this.SFtypeNr = -1;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                this.MakeSFtypeTypeItemGUI();
              }
              else if (num3 == -2)
              {
                this.LibNr = -1;
                this.SFtypeNr = -1;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                this.MakeSFtypeTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.TabListId)
            {
              int num4 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num4 > -1)
              {
                this.TabSheetNr = num4;
                this.MakeSFtypeTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ExtraListId)
            {
              int num5 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num5 > -1)
              {
                this.detailnr = num5;
                this.Tabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ResListId)
            {
              int num6 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num6 > -1)
              {
                this.detailnr2 = num6;
                this.Tabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.LogoListId)
            {
              int num7 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num7 > -1)
              {
                this.detailnr2 = num7;
                this.Tabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.PreventListId)
            {
              int num8 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num8 > -1)
              {
                this.detailnr2 = num8;
                this.Tabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.VariantListId)
            {
              int num9 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num9 > -1)
              {
                this.detailnr2 = num9;
                this.Tabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.p1id)
            {
              SFTypeClass[] sfTypeObj = this.game.Data.SFTypeObj;
              SFTypeClass[] sfTypeClassArray = sfTypeObj;
              int sftypeNr = this.SFtypeNr;
              int index2 = sftypeNr;
              sfTypeClassArray[index2].PreventCounter = sfTypeObj[sftypeNr].PreventCounter + 1;
              this.game.Data.SFTypeObj[this.SFtypeNr].PreventHitOn = (int[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[this.SFtypeNr].PreventHitOn, (Array) new int[this.game.Data.SFTypeObj[this.SFtypeNr].PreventCounter + 1]);
              this.game.Data.SFTypeObj[this.SFtypeNr].PreventHitFrom = (int[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[this.SFtypeNr].PreventHitFrom, (Array) new int[this.game.Data.SFTypeObj[this.SFtypeNr].PreventCounter + 1]);
              this.game.Data.SFTypeObj[this.SFtypeNr].PreventPriority = (int[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[this.SFtypeNr].PreventPriority, (Array) new int[this.game.Data.SFTypeObj[this.SFtypeNr].PreventCounter + 1]);
              this.game.Data.SFTypeObj[this.SFtypeNr].PreventChance = (int[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[this.SFtypeNr].PreventChance, (Array) new int[this.game.Data.SFTypeObj[this.SFtypeNr].PreventCounter + 1]);
              this.game.Data.SFTypeObj[this.SFtypeNr].PreventPoints = (int[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[this.SFtypeNr].PreventPoints, (Array) new int[this.game.Data.SFTypeObj[this.SFtypeNr].PreventCounter + 1]);
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.vp1id)
            {
              SFTypeClass[] sfTypeObj = this.game.Data.SFTypeObj;
              SFTypeClass[] sfTypeClassArray = sfTypeObj;
              int sftypeNr = this.SFtypeNr;
              int index3 = sftypeNr;
              sfTypeClassArray[index3].ModelVariantCounter = sfTypeObj[sftypeNr].ModelVariantCounter + 1;
              this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantName = (string[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantName, (Array) new string[this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCounter + 1]);
              this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCheck = (int[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCheck, (Array) new int[this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCounter + 1]);
              this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantExec = (int[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantExec, (Array) new int[this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCounter + 1]);
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.p2id)
            {
              if (this.game.Data.SFTypeObj[this.SFtypeNr].PreventCounter > 0)
              {
                int detailnr2 = this.detailnr2;
                int num10 = this.game.Data.SFTypeObj[this.SFtypeNr].PreventCounter - 1;
                for (int index4 = detailnr2; index4 <= num10; ++index4)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].PreventHitOn[index4] = this.game.Data.SFTypeObj[this.SFtypeNr].PreventHitOn[index4 + 1];
                  this.game.Data.SFTypeObj[this.SFtypeNr].PreventHitFrom[index4] = this.game.Data.SFTypeObj[this.SFtypeNr].PreventHitFrom[index4 + 1];
                  this.game.Data.SFTypeObj[this.SFtypeNr].PreventPriority[index4] = this.game.Data.SFTypeObj[this.SFtypeNr].PreventPriority[index4 + 1];
                  this.game.Data.SFTypeObj[this.SFtypeNr].PreventChance[index4] = this.game.Data.SFTypeObj[this.SFtypeNr].PreventChance[index4 + 1];
                  this.game.Data.SFTypeObj[this.SFtypeNr].PreventPoints[index4] = this.game.Data.SFTypeObj[this.SFtypeNr].PreventPoints[index4 + 1];
                }
              }
              --this.game.Data.SFTypeObj[this.SFtypeNr].PreventCounter;
              if (this.game.Data.SFTypeObj[this.SFtypeNr].PreventCounter > -1)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].PreventHitOn = (int[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[this.SFtypeNr].PreventHitOn, (Array) new int[this.game.Data.SFTypeObj[this.SFtypeNr].PreventCounter + 1]);
                this.game.Data.SFTypeObj[this.SFtypeNr].PreventHitFrom = (int[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[this.SFtypeNr].PreventHitFrom, (Array) new int[this.game.Data.SFTypeObj[this.SFtypeNr].PreventCounter + 1]);
                this.game.Data.SFTypeObj[this.SFtypeNr].PreventPriority = (int[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[this.SFtypeNr].PreventPriority, (Array) new int[this.game.Data.SFTypeObj[this.SFtypeNr].PreventCounter + 1]);
                this.game.Data.SFTypeObj[this.SFtypeNr].PreventChance = (int[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[this.SFtypeNr].PreventChance, (Array) new int[this.game.Data.SFTypeObj[this.SFtypeNr].PreventCounter + 1]);
                this.game.Data.SFTypeObj[this.SFtypeNr].PreventPoints = (int[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[this.SFtypeNr].PreventPoints, (Array) new int[this.game.Data.SFTypeObj[this.SFtypeNr].PreventCounter + 1]);
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.vp2id)
            {
              if (this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCounter > 0)
              {
                int detailnr2 = this.detailnr2;
                int num11 = this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCounter - 1;
                for (int index5 = detailnr2; index5 <= num11; ++index5)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantName[index5] = this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantName[index5 + 1];
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCheck[index5] = this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCheck[index5 + 1];
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantExec[index5] = this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantExec[index5 + 1];
                }
              }
              --this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCounter;
              if (this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCounter > -1)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantName = (string[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantName, (Array) new string[this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCounter + 1]);
                this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCheck = (int[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCheck, (Array) new int[this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCounter + 1]);
                this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantExec = (int[]) Utils.CopyArray((Array) this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantExec, (Array) new int[this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantCounter + 1]);
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.y3id)
            {
              if (this.game.Data.SFTypeObj[this.SFtypeNr].UsePeopleGraphics == 0)
                this.game.Data.SFTypeObj[this.SFtypeNr].UsePeopleGraphics = 1;
              else if (this.game.Data.SFTypeObj[this.SFtypeNr].UsePeopleGraphics == 1)
                this.game.Data.SFTypeObj[this.SFtypeNr].UsePeopleGraphics = 2;
              else
                this.game.Data.SFTypeObj[this.SFtypeNr].UsePeopleGraphics = 0;
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.copyid)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 70, this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.p3id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 68, this.SFtypeNr, this.detailnr2);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.vp3id)
            {
              this.game.Data.SFTypeObj[this.SFtypeNr].ModelVariantName[this.detailnr2] = Interaction.InputBox("Give name", "Shadow Empire : Planetary Conquest");
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.p4id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 69, this.SFtypeNr, this.detailnr2);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.vp4id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 77, this.SFtypeNr, this.detailnr2);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.vp5id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 78, this.SFtypeNr, this.detailnr2);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.p5id)
            {
              int num12 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Prevent Priority.", "Shadow Empire : Planetary Conquest")));
              if (num12 >= -1 & num12 < 9999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].PreventPriority[this.detailnr2] = num12;
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num13 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between -1 and 9999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.p6id)
            {
              int num14 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Prevent Chance in %.", "Shadow Empire : Planetary Conquest")));
              if (num14 >= 0 & num14 <= 100)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].PreventChance[this.detailnr2] = num14;
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num15 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 100", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.p7id)
            {
              int num16 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Prevent Points.", "Shadow Empire : Planetary Conquest")));
              if (num16 >= 0 & num16 <= 9999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].PreventPoints[this.detailnr2] = num16;
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num17 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 9999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.p8id)
            {
              int num18 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Max Prevent Points Used. (0=cannot use any)", "Shadow Empire : Planetary Conquest")));
              if (num18 >= 0 & num18 <= 99999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].MaxPreventPointsUsed = num18;
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num19 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.p9id)
            {
              int num20 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Max Prevent Points Given. (0=cannot use any)", "Shadow Empire : Planetary Conquest")));
              if (num20 >= 0 & num20 <= 99999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].MaxPreventPointsGiven = num20;
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num21 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.x1id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 42, this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.x2id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 43, this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.x3id)
            {
              int num22 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Air Overrule AP Cost (-1=default).", "Shadow Empire : Planetary Conquest")));
              if (num22 >= -1 & num22 < 9999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].AirAPRule = num22;
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num23 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between -1 and 9999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.x4id)
            {
              SFTypeClass sfTypeClass = this.game.Data.SFTypeObj[this.SFtypeNr].Clone();
              this.game.Data.SFTypeObj[this.SFtypeNr] = this.game.Data.SFTypeObj[this.SFtypeNr + 1].Clone();
              this.game.Data.SFTypeObj[this.SFtypeNr + 1] = sfTypeClass;
              this.game.Data.ChangeSFTypeNr(this.SFtypeNr, 9999);
              this.game.Data.ChangeSFTypeNr(this.SFtypeNr + 1, this.SFtypeNr);
              this.game.Data.ChangeSFTypeNr(9999, this.SFtypeNr + 1);
              this.game.Data.SFTypeObj[this.SFtypeNr].LoadSprites();
              this.game.Data.SFTypeObj[this.SFtypeNr + 1].LoadSprites();
              ++this.SFtypeNr;
              this.SubPartFlag[this.SubpartNr(this.SFtypeListId)] = true;
              this.MakeSFtypeListGUI(this.SFtypeNr);
              this.MakeSFtypeTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.x5id)
            {
              SFTypeClass sfTypeClass = this.game.Data.SFTypeObj[this.SFtypeNr].Clone();
              this.game.Data.SFTypeObj[this.SFtypeNr] = this.game.Data.SFTypeObj[this.SFtypeNr - 1].Clone();
              this.game.Data.SFTypeObj[this.SFtypeNr - 1] = sfTypeClass;
              this.game.Data.ChangeSFTypeNr(this.SFtypeNr, 9999);
              this.game.Data.ChangeSFTypeNr(this.SFtypeNr - 1, this.SFtypeNr);
              this.game.Data.ChangeSFTypeNr(9999, this.SFtypeNr - 1);
              this.game.Data.SFTypeObj[this.SFtypeNr].LoadSprites();
              this.game.Data.SFTypeObj[this.SFtypeNr - 1].LoadSprites();
              --this.SFtypeNr;
              this.SubPartFlag[this.SubpartNr(this.SFtypeListId)] = true;
              this.MakeSFtypeListGUI(this.SFtypeNr);
              this.MakeSFtypeTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.clibid)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 93, this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.x6id)
            {
              int num24 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give SFType to replace with.", "Shadow Empire : Planetary Conquest")));
              if (num24 >= 0 & num24 <= this.game.Data.SFTypeCounter)
              {
                int sfCounter = this.game.Data.SFCounter;
                int Number;
                for (int index6 = 0; index6 <= sfCounter; ++index6)
                {
                  if (this.game.Data.SFObj[index6].Type == this.SFtypeNr)
                  {
                    this.game.Data.SFObj[index6].Type = num24;
                    ++Number;
                  }
                }
                int num25 = (int) Interaction.MsgBox((object) ("Made " + Conversion.Str((object) Number) + " conversions throughout all the subformations in the units."));
              }
              else
              {
                int num26 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and SFTypeCounter", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.y5id)
            {
              string s = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp|Jpg|*.jpg", "Give File Name For Replacement of sideways sprite", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + s))
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ReplaceSidewaysSprite(s);
              }
              else
              {
                int num27 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.w1id)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp|Jpg|*.jpg", "Give File Name For Replacement of extra Pic Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ReplaceExtraPic(this.detailnr, filename);
              }
              else
              {
                int num28 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.w1bid)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp|Jpg|*.jpg", "Give File Name For Replacement of extra Pic Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ReplaceExtraSideways(this.detailnr, filename);
              }
              else
              {
                int num29 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.w10id)
            {
              this.game.Data.SFTypeObj[this.SFtypeNr].DontReturnFromHQ = !this.game.Data.SFTypeObj[this.SFtypeNr].DontReturnFromHQ;
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.w12id)
            {
              this.game.Data.SFTypeObj[this.SFtypeNr].ConsiderCarry = !this.game.Data.SFTypeObj[this.SFtypeNr].ConsiderCarry;
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.w8id)
            {
              int num30 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Set for unitgroup# ", "Shadow Empire : Planetary Conquest")));
              int sfTypeCounter = this.game.Data.SFTypeCounter;
              for (int index7 = 0; index7 <= sfTypeCounter; ++index7)
              {
                if (this.game.Data.SFTypeObj[index7].UnitGroup == num30)
                {
                  int upperBound = this.game.Data.SFTypeObj[index7].CombatModAtt.GetUpperBound(0);
                  for (int index8 = 0; index8 <= upperBound; ++index8)
                  {
                    this.game.Data.SFTypeObj[index7].CombatModAtt[index8] = this.game.Data.SFTypeObj[this.SFtypeNr].CombatModAtt[index8];
                    this.game.Data.SFTypeObj[index7].CombatModDef[index8] = this.game.Data.SFTypeObj[this.SFtypeNr].CombatModDef[index8];
                    this.game.Data.SFTypeObj[index7].ExtraRecon[index8] = this.game.Data.SFTypeObj[this.SFtypeNr].ExtraRecon[index8];
                  }
                }
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b39id)
            {
              int sfTypeCounter = this.game.Data.SFTypeCounter;
              for (int index9 = 0; index9 <= sfTypeCounter; ++index9)
              {
                if (this.game.Data.SFTypeObj[index9].ReinforcementType == this.game.Data.SFTypeObj[this.SFtypeNr].ReinforcementType)
                {
                  int upperBound = this.game.Data.SFTypeObj[index9].CombatModAtt.GetUpperBound(0);
                  for (int index10 = 0; index10 <= upperBound; ++index10)
                  {
                    this.game.Data.SFTypeObj[index9].CombatModAtt[index10] = this.game.Data.SFTypeObj[this.SFtypeNr].CombatModAtt[index10];
                    this.game.Data.SFTypeObj[index9].CombatModDef[index10] = this.game.Data.SFTypeObj[this.SFtypeNr].CombatModDef[index10];
                    this.game.Data.SFTypeObj[index9].ExtraRecon[index10] = this.game.Data.SFTypeObj[this.SFtypeNr].ExtraRecon[index10];
                  }
                }
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.t1id)
            {
              int index11 = (int) Math.Round(Conversion.Int(Conversion.Val(Interaction.InputBox("Give SFType# to copy from", "Shadow Empire : Planetary Conquest"))));
              if (index11 > -1 & index11 <= this.game.Data.SFTypeCounter)
              {
                int sftypeNr = this.SFtypeNr;
                int upperBound = this.game.Data.SFTypeObj[sftypeNr].CombatModAtt.GetUpperBound(0);
                for (int index12 = 0; index12 <= upperBound; ++index12)
                {
                  this.game.Data.SFTypeObj[sftypeNr].CombatModAtt[index12] = this.game.Data.SFTypeObj[index11].CombatModAtt[index12];
                  this.game.Data.SFTypeObj[sftypeNr].CombatModDef[index12] = this.game.Data.SFTypeObj[index11].CombatModDef[index12];
                  this.game.Data.SFTypeObj[sftypeNr].ExtraRecon[index12] = this.game.Data.SFTypeObj[index11].ExtraRecon[index12];
                }
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.w2id)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of extra Symbol Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ReplaceExtraSymbol(this.detailnr, filename);
              }
              else
              {
                int num31 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.y8id)
            {
              string filename1 = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of extra Symbol Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename1))
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ReplaceExtraColBigSymbol(this.detailnr, filename1);
              }
              else
              {
                int num32 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              string filename2 = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Give SECOND File Name For Replacement of extra Symbol Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename2))
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ReplaceExtraColBigSymbol2(this.detailnr, filename2);
              }
              else
              {
                int num33 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.w2bid)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of extra Symbol Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ReplaceExtraSymbol2(this.detailnr, filename);
              }
              else
              {
                int num34 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.y2id)
            {
              int index13 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give SFType to Copy From .", "Shadow Empire : Planetary Conquest")));
              if (index13 >= 0 & index13 <= this.game.Data.SFTypeCounter)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].FuelForAttack = this.game.Data.SFTypeObj[index13].FuelForAttack;
                this.game.Data.SFTypeObj[this.SFtypeNr].FuelForAttackDef = this.game.Data.SFTypeObj[index13].FuelForAttackDef;
                this.game.Data.SFTypeObj[this.SFtypeNr].FuelForMove = this.game.Data.SFTypeObj[index13].FuelForMove;
                this.game.Data.SFTypeObj[this.SFtypeNr].FuelRegimeVar = this.game.Data.SFTypeObj[index13].FuelRegimeVar;
                this.game.Data.SFTypeObj[this.SFtypeNr].OutOfFuelAttack = this.game.Data.SFTypeObj[index13].OutOfFuelAttack;
                this.game.Data.SFTypeObj[this.SFtypeNr].OutOfFuelDefense = this.game.Data.SFTypeObj[index13].OutOfFuelDefense;
                this.game.Data.SFTypeObj[this.SFtypeNr].OutOfFuelMove = this.game.Data.SFTypeObj[index13].OutOfFuelMove;
                this.Tabsheet();
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num35 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 1 and 9999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.w3id)
            {
              int num36 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Code for selected extra graphics.", "Shadow Empire : Planetary Conquest")));
              if (num36 > 0 & num36 < 9999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ExtraCode[this.detailnr] = num36;
                this.Tabsheet();
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num37 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 1 and 9999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.h6id)
            {
              this.game.Data.SFTypeObj[this.SFtypeNr].ExtraName[this.detailnr] = Interaction.InputBox("Give Name.", "Shadow Empire : Planetary Conquest");
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.w4id)
            {
              this.game.Data.SFTypeObj[this.SFtypeNr].RemoveExtraSprite(this.detailnr);
              this.detailnr = -1;
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.w5id)
            {
              this.game.Data.SFTypeObj[this.SFtypeNr].AddExtraSprite();
              this.detailnr = this.game.Data.SFTypeObj[this.SFtypeNr].ExtraCounter;
              this.Tabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b28id)
            {
              this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddSFtypeId)
            {
              this.game.Data.AddSFType();
              this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].LibId.libSlot = this.LibNr;
              this.MakeSFtypeListGUI(this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddSFtype2Id)
            {
              int sftypeNr = this.SFtypeNr;
              this.game.Data.AddSFType();
              int id = this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].Id;
              this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter] = this.game.Data.SFTypeObj[sftypeNr].Clone();
              this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].Id = id;
              this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].LoadSprites();
              this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].LibId.libSlot = this.LibNr;
              this.MakeSFtypeListGUI(this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BNameId)
            {
              this.game.Data.SFTypeObj[this.SFtypeNr].Name = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest");
              this.MakeSFtypeListGUI(this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.j1id)
            {
              this.game.Data.SFTypeObj[this.SFtypeNr].LogoString[this.detailnr2] = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest");
              this.MakeSFtypeListGUI(this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BRemoveSFtypeId)
            {
              this.game.Data.RemoveSFType(this.SFtypeNr);
              if (this.game.Data.SFTypeCounter < this.SFtypeNr)
                this.SFtypeNr = this.game.Data.SFTypeCounter;
              this.MakeSFtypeListGUI(this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BRemoveSFtypeId2)
            {
              for (int sfTypeCounter = this.game.Data.SFTypeCounter; sfTypeCounter >= 0; sfTypeCounter += -1)
                this.game.Data.RemoveSFType(sfTypeCounter);
              this.SFtypeNr = -1;
              this.MakeSFtypeListGUI(-1);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BChangeSymbolId)
            {
              string s = this.game.HandyFunctionsObj.LoadSomething("Pings (*.Png)|*.png|Bmp|*.bmp", "Give File Name For Replacement of Symbol Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + s))
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ReplaceSymbolSprite(s);
              }
              else
              {
                int num38 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.MakeSFtypeListGUI(this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.y7id)
            {
              string s = this.game.HandyFunctionsObj.LoadSomething("Pings (*.Png)|*.png|Bmp|*.bmp", "Give File Name For Replacement of Symbol Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + s))
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ReplaceColBigSymbolSprite(s);
              }
              else
              {
                int num39 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.MakeSFtypeListGUI(this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BChangeSymbol2Id)
            {
              string s = this.game.HandyFunctionsObj.LoadSomething("Pings (*.Png)|*.png|Bmp|*.bmp", "Give File Name For Replacement of Symbol Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + s))
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ReplaceSymbolSprite2(s);
              }
              else
              {
                int num40 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.MakeSFtypeListGUI(this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.bChangePicId)
            {
              string s = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp|Jpg|*.jpg", "Give File Name For Replacement of Picture Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + s))
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ReplacePicSprite(s);
              }
              else
              {
                int num41 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.MakeSFtypeListGUI(this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BSymbolGroupId)
            {
              int num42 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new Symbol Group Number, please.", "Shadow Empire : Planetary Conquest")));
              if (num42 > -2 & num42 < 100)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].SymbolGroup = num42;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num43 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between -1 and 99", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.BSymbolOverRuleId)
            {
              this.game.Data.SFTypeObj[this.SFtypeNr].SymbolOverrule = !this.game.Data.SFTypeObj[this.SFtypeNr].SymbolOverrule;
              this.MakeSFtypeListGUI(this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b35id)
            {
              this.game.Data.SFTypeObj[this.SFtypeNr].FreeAir = !this.game.Data.SFTypeObj[this.SFtypeNr].FreeAir;
              this.MakeSFtypeListGUI(this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BMoveTypeId)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 4, this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BSymbolWeightId)
            {
              int num44 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new Symbol Weight, please.", "Shadow Empire : Planetary Conquest")));
              if (num44 > -1 & num44 < 10000)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].SymbolWeight = num44;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num45 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 9999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.B1Id)
            {
              int num46 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Supply Carry, please.", "Shadow Empire : Planetary Conquest")));
              if (num46 > -2 & num46 < 99999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].SupplyCarry = num46;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num47 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between -1 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b33id)
            {
              int num48 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give RailCap pts", "Shadow Empire : Planetary Conquest")));
              if (num48 > -1 & num48 <= 10000)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].RailCap = num48;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num49 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 10000", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b31id)
            {
              int num50 = (int) Interaction.MsgBox((object) "For all, or only selected peoplegroup", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest");
              int num51 = (int) Interaction.MsgBox((object) "Set true? yes=true.. no=false", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest");
              int sfTypeCounter = this.game.Data.SFTypeCounter;
              for (int index14 = 0; index14 <= sfTypeCounter; ++index14)
              {
                int index15 = 0;
                do
                {
                  if (num50 == 6)
                  {
                    if (this.detailnr > -1)
                    {
                      if (num51 == 6)
                        this.game.Data.SFTypeObj[index14].PeopleGroup[this.detailnr] = true;
                      else
                        this.game.Data.SFTypeObj[index14].PeopleGroup[this.detailnr] = false;
                    }
                  }
                  else if (num51 == 6)
                    this.game.Data.SFTypeObj[index14].PeopleGroup[index15] = true;
                  else
                    this.game.Data.SFTypeObj[index14].PeopleGroup[index15] = false;
                  ++index15;
                }
                while (index15 <= 99);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.h3id)
            {
              int num52 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New RoleScore, please.", "Shadow Empire : Planetary Conquest")));
              if (num52 > -1 & num52 < 9999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].AIRoleScore[this.detailnr] = num52;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num53 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 9999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.w11id)
            {
              int num54 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New RoleScore (will set for all with same unitgroup), please.", "Shadow Empire : Planetary Conquest")));
              if (num54 > -1 & num54 < 9999)
              {
                int sfTypeCounter = this.game.Data.SFTypeCounter;
                for (int index16 = 0; index16 <= sfTypeCounter; ++index16)
                {
                  if (this.game.Data.SFTypeObj[index16].UnitGroup == this.game.Data.SFTypeObj[this.SFtypeNr].UnitGroup)
                    this.game.Data.SFTypeObj[index16].AIRoleScore[this.detailnr] = num54;
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num55 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 9999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.B5Id)
            {
              int num56 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New LandCap, please.", "Shadow Empire : Planetary Conquest")));
              if (num56 > -1 & num56 < 9999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].Cap = num56;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num57 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 9999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.y6id)
            {
              int num58 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Color Morph value.", "Shadow Empire : Planetary Conquest")));
              if (num58 > -1 & num58 < 7)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].BaseColor = num58;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num59 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 4", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.B6Id)
            {
              int num60 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Basic Supply Need, please.", "Shadow Empire : Planetary Conquest")));
              if (num60 > -1 & num60 < 9999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].BasicSupplyNeed = num60;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num61 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 9999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b32id)
            {
              int num62 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New absolute readiness loss per 100ap please.", "Shadow Empire : Planetary Conquest")));
              if (num62 > -1 & num62 <= 100)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ReadinessLoss = num62;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num63 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 100", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.B7Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 5, this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B8Id)
            {
              int num64 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Theater #, please.", "Shadow Empire : Planetary Conquest")));
              if (num64 > -1 & num64 < 3)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].Theater = num64;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num65 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 2", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b9id)
            {
              int num66 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Weight, please.", "Shadow Empire : Planetary Conquest")));
              if (num66 > 0 & num66 < 999999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].Weight = num66;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num67 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 1 and 999999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b10id)
            {
              int num68 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New DefPower for ATTACK HEX, please.", "Shadow Empire : Planetary Conquest")));
              if (num68 > 0 & num68 < 999999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].DefPower = num68;
              }
              else
              {
                int num69 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 1 and 999999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.MakeSFtypeListGUI(this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b11id)
            {
              int num70 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Initiative for ATTACK HEX, please.", "Shadow Empire : Planetary Conquest")));
              if (num70 > 0 & num70 < 999999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].Initiative = num70;
              }
              else
              {
                int num71 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 1 and 999999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              int num72 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Initiative for DEFEND HEX, please.", "Shadow Empire : Planetary Conquest")));
              if (num72 > 0 & num72 < 999999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].InitiativeDef = num72;
              }
              else
              {
                int num73 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 1 and 999999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.MakeSFtypeListGUI(this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b12id)
            {
              int num74 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Attacks, please.", "Shadow Empire : Planetary Conquest")));
              if (num74 > -1 & num74 <= 9999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].Attacks = num74;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num75 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 1 and 99", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b13id)
            {
              int num76 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New MaxAttacked, please.", "Shadow Empire : Planetary Conquest")));
              if (num76 > 0 & num76 < 999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].MaxAttacked = num76;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num77 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 1 and 999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b14id)
            {
              int num78 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Frontage, please.", "Shadow Empire : Planetary Conquest")));
              if (num78 > -1 & num78 < 999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].Frontage = num78;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num79 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b15id)
            {
              this.game.Data.SFTypeObj[this.SFtypeNr].BackBench = !this.game.Data.SFTypeObj[this.SFtypeNr].BackBench;
              this.MakeSFtypeListGUI(this.SFtypeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b16id)
            {
              int num80 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New ArtRange, please.", "Shadow Empire : Planetary Conquest")));
              if (num80 > -1 & num80 < 99)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ArtRange = num80;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num81 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.w13id)
            {
              int num82 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New SFType # used to look up landscape mods for artillery attack.", "Shadow Empire : Planetary Conquest")));
              if (num82 >= -1 & num82 < this.game.Data.SFTypeCounter)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ArtSFType = num82;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num83 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between -1 and maxLT", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b17id)
            {
              int num84 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New FavTarget Tries, please.", "Shadow Empire : Planetary Conquest")));
              if (num84 > 0 & num84 < 999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].FavTargetTries = num84;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num85 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 1 and 999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b18id)
            {
              int num86 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Fav Target score, please.", "Shadow Empire : Planetary Conquest")));
              if (num86 > -1 & num86 < 999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].FavTarget[this.detailnr] = num86;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num87 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b19id)
            {
              int num88 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Attack Power score, please.", "Shadow Empire : Planetary Conquest")));
              if (num88 > -1 & num88 < 9990)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].AttackPower[this.detailnr] = num88;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num89 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 9990", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b23id)
            {
              int num90 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Attack Def Power score, please.", "Shadow Empire : Planetary Conquest")));
              if (num90 > -1 & num90 < 9990)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].AttackPowerDef[this.detailnr] = num90;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num91 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 9990", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b25id)
            {
              int num92 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Art Attack score, please.", "Shadow Empire : Planetary Conquest")));
              if (num92 > -1 & num92 < 9990)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].AttackArt[this.detailnr] = (object) num92;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num93 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 9990", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b26id)
            {
              int num94 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Artillery Fav score, please.", "Shadow Empire : Planetary Conquest")));
              if (num94 > -1 & num94 < 9990)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].FavArtTarget[this.detailnr] = num94;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num95 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 9990", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b37id)
            {
              int num96 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give hitpoints", "Shadow Empire : Planetary Conquest")));
              if (num96 > -1 & num96 < 99999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].HitPoints[this.detailnr] = num96;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num97 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b38id)
            {
              int num98 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give def hitpoints", "Shadow Empire : Planetary Conquest")));
              if (num98 > -1 & num98 < 99999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].HitPointsDef[this.detailnr] = num98;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num99 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.w15id)
            {
              int num100 = (int) Math.Round(Conversion.Val(Interaction.InputBox("DirectRange", "Shadow Empire : Planetary Conquest")));
              if (num100 > -1 & num100 < 99999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].directRange = num100;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num101 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.w16id)
            {
              int num102 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Direct Mod 1st Hex", "Shadow Empire : Planetary Conquest")));
              if (num102 > -1 & num102 < 99999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].directModFirstHex = num102;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num103 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.w17id)
            {
              int num104 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Direct Mod 2nd+ Hex", "Shadow Empire : Planetary Conquest")));
              if (num104 > -1 & num104 < 99999)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].directModPerHex = num104;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num105 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.y1id)
            {
              int num106 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give def hitpoints", "Shadow Empire : Planetary Conquest")));
              if (num106 > -1 & num106 < 99999)
              {
                int index17 = 0;
                do
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].HitPointsDef[index17] = num106;
                  this.game.Data.SFTypeObj[this.SFtypeNr].HitPoints[index17] = num106;
                  ++index17;
                }
                while (index17 <= 99);
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num107 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b20id)
            {
              int num108 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Kill % chance please.", "Shadow Empire : Planetary Conquest")));
              if (num108 > -1 & num108 < 101)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].KillPercent = num108;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num109 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 100%", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b21id)
            {
              int num110 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give  Equipment Kill % chance, please.", "Shadow Empire : Planetary Conquest")));
              if (num110 > -1 & num110 < 101)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].EquipPercent = num110;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num111 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 100%", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b22id)
            {
              int num112 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Retreat % chance, please.", "Shadow Empire : Planetary Conquest")));
              if (num112 > -1 & num112 < 101)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].RetreatPercent = num112;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num113 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 100%", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b34id)
            {
              int num114 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give slot# (-1 = dont set any slot).", "Shadow Empire : Planetary Conquest")));
              if (num114 >= -1 & num114 <= 9)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].SlotNumber = num114;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num115 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between -1 and 9", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.b24id)
            {
              int num116 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Move Redux in %, please.", "Shadow Empire : Planetary Conquest")));
              if (num116 > -101 & num116 < 101)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].MoveRedux = num116;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num117 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 100%", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              return windowReturnClass;
            }
            if (num1 == this.PGListId)
            {
              int num118 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num118 > -1)
              {
                this.detailnr = num118;
                this.Tabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.CombatListId)
            {
              int num119 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num119 > -1)
              {
                this.detailnr = num119;
                this.Tabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.CombatList2Id)
            {
              int num120 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num120 > -1)
              {
                this.detailnr = num120;
                this.Tabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.combatlist3id)
            {
              int num121 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num121 > -1)
              {
                this.detailnr = num121;
                this.Tabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.combatlist4id)
            {
              int num122 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num122 > -1)
              {
                this.detailnr = num122;
                this.Tabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B4Id)
            {
              if (this.detailnr > -1)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].PeopleGroup[this.detailnr] = !this.game.Data.SFTypeObj[this.SFtypeNr].PeopleGroup[this.detailnr];
                this.Tabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else
            {
              if (num1 == this.d1id)
              {
                int num123 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New CarryCap, please.", "Shadow Empire : Planetary Conquest")));
                if (num123 > -1 & num123 < 99999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].CarryCap = num123;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num124 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.e1id)
              {
                int num125 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New EntrenchPower, please.", "Shadow Empire : Planetary Conquest")));
                if (num125 > -1 & num125 < 901)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].EntrenchPower = num125;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num126 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 900", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.e5id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 26, this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w9id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 51, this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w9bid)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 89, this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.e6id)
              {
                int num127 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Upgrade cost in ProdPts, please. (rulevar77 how much prodpts = 1 supply)", "Shadow Empire : Planetary Conquest")));
                if (num127 > -1 & num127 <= 99999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].UpgradeCost = num127;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num128 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 - 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.e7id)
              {
                int num129 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Upgrade XP needed, please.", "Shadow Empire : Planetary Conquest")));
                if (num129 > -1 & num129 <= 999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].UpgradeXP = num129;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num130 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 - 999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.e3id)
              {
                int num131 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New PowerPts, please.", "Shadow Empire : Planetary Conquest")));
                if (num131 > -1 & num131 < 999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].PowerPts = num131;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num132 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.w6id)
              {
                int num133 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New ratio, please.", "Shadow Empire : Planetary Conquest")));
                if (num133 > -1 & num133 < 999999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].Ratio = num133;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num134 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 999999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.w7id)
              {
                int num135 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new copyFrom sftype slot.", "Shadow Empire : Planetary Conquest")));
                if (num135 >= -1 & num135 <= this.game.Data.SFTypeCounter)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].CopyDataFrom = num135;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num136 = (int) Interaction.MsgBox((object) "Cancelled. Value must be valid sftype slot", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.v19id)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ModelInitialForAll = !this.game.Data.SFTypeObj[this.SFtypeNr].ModelInitialForAll;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.f1id)
              {
                int num137 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Recon Pts, please.", "Shadow Empire : Planetary Conquest")));
                if (num137 > -1 & num137 < 999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ReconPts = num137;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num138 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.f2id)
              {
                int num139 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Hide Pts, please.", "Shadow Empire : Planetary Conquest")));
                if (num139 > -1 & num139 < 999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].HidePts = num139;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num140 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.v1id)
              {
                int num141 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Last State. 1=got it. 0=not", "Shadow Empire : Planetary Conquest")));
                if (num141 >= 0 & num141 <= 1)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelLastState[this.detailnr2] = num141;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num142 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 1", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.v2id)
              {
                int num143 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Possible Improvement. 1=gives impr. 0=not", "Shadow Empire : Planetary Conquest")));
                if (num143 >= 0 & num143 <= 1)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelPossibleImp[this.detailnr2] = num143;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num144 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 1", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.c2id)
              {
                int num145 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give regimevar used for fuel (-1=none)", "Shadow Empire : Planetary Conquest")));
                if (num145 >= -1 & num145 <= 400)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].FuelRegimeVar = num145;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num146 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 1", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.c3id)
              {
                int num147 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give fuel needed for move (10 ap or minimum cost)", "Shadow Empire : Planetary Conquest")));
                if (num147 >= 0 & num147 <= 99999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].FuelForMove = num147;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num148 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.c12id)
              {
                int num149 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give stockpile used per round", "Shadow Empire : Planetary Conquest")));
                if (num149 >= 0 & num149 <= 99999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].StockpileUsedPerRound = num149;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num150 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.c13id)
              {
                int num151 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give stockpile max size", "Shadow Empire : Planetary Conquest")));
                if (num151 >= 0 & num151 <= 99999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].StockpileMax = num151;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num152 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.c14id)
              {
                int num153 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give stockpile max in", "Shadow Empire : Planetary Conquest")));
                if (num153 >= 0 & num153 <= 99999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].StockpileMaxIn = num153;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num154 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.c15id)
              {
                float num155 = (float) Conversion.Val(Interaction.InputBox("Give attack value modifier if out of stockpile", "Shadow Empire : Planetary Conquest"));
                if ((double) num155 >= 0.0 & (double) num155 <= 99999.0)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].StockpileDepletedMod = num155;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num156 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0.0 and 99999.0", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.c16id)
              {
                int num157 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give max (regular) supply in", "Shadow Empire : Planetary Conquest")));
                if (num157 >= 0 & num157 <= 99999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].SupplyMaxIn = num157;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num158 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.c17id)
              {
                int num159 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Supply for 100AP of offensive combat", "Shadow Empire : Planetary Conquest")));
                if (num159 >= 0 & num159 <= 99999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].SupplyForAttack = num159;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num160 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.c18id)
              {
                int num161 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Supply for 100AP of defensive combat", "Shadow Empire : Planetary Conquest")));
                if (num161 >= 0 & num161 <= 99999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].SupplyForAttackDef = num161;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num162 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.c19id)
              {
                float num163 = (float) Conversion.Val(Interaction.InputBox("Give attack value modifier if out of supply", "Shadow Empire : Planetary Conquest"));
                if ((double) num163 >= 0.0 & (double) num163 <= 99999.0)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].OutOfSupplyAttack = num163;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num164 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0.0 and 99999.0", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.c20id)
              {
                float num165 = (float) Conversion.Val(Interaction.InputBox("Give attack value modifier if out of supply", "Shadow Empire : Planetary Conquest"));
                if ((double) num165 >= 0.0 & (double) num165 <= 99999.0)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].OutOfSupplyDefense = num165;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num166 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0.0 and 99999.0", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.c21id)
              {
                int num167 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Fuel Carry Pts", "Shadow Empire : Planetary Conquest")));
                if (num167 >= 0 & num167 <= 99999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].FuelCarry = num167;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num168 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.c5id)
              {
                int num169 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give fuel needed for 1 combatround in OFFENSE", "Shadow Empire : Planetary Conquest")));
                int num170 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give fuel needed for 1 combatround in DEFENSE", "Shadow Empire : Planetary Conquest")));
                if (num169 >= 0 & num169 <= 99999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].FuelForAttack = num169;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                if (num170 >= 0 & num170 <= 99999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].FuelForAttackDef = num170;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                return windowReturnClass;
              }
              if (num1 == this.v3id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 63, this.SFtypeNr, this.detailnr2);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.v4id)
              {
                int index18 = (int) Math.Round(Conversion.Val(Interaction.InputBox("For which level is this research necc. 0-9 (0=for none)", "Shadow Empire : Planetary Conquest")));
                if (index18 >= 0 & index18 <= 9)
                {
                  int index19 = 1;
                  do
                  {
                    if (this.game.Data.SFTypeObj[this.SFtypeNr].ModelResearch[index19] == this.detailnr2)
                      this.game.Data.SFTypeObj[this.SFtypeNr].ModelResearch[index19] = -1;
                    ++index19;
                  }
                  while (index19 <= 9);
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelResearch[index18] = this.detailnr2;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num171 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 9", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.v5id)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ModelIsBase = !this.game.Data.SFTypeObj[this.SFtypeNr].ModelIsBase;
                this.Tabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.v6id)
              {
                int num172 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New ModelCostType. -1=PP. 0-499=regvar ", "Shadow Empire : Planetary Conquest")));
                if (num172 >= -1 & num172 <= 499)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelCostType = num172;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num173 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between -1 and 499", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.v17id)
              {
                int num174 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Model Regime. -1=all ", "Shadow Empire : Planetary Conquest")));
                if (num174 >= -2 & num174 <= this.game.Data.RegimeCounter)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelRegime = num174;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num175 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between -1 and regimecounter", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.v18id)
              {
                int num176 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Research(0). (-1 no need) ", "Shadow Empire : Planetary Conquest")));
                if (num176 >= -1 & num176 <= this.game.Data.ResearchCounter)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelResearch[0] = num176;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num177 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between -1 and researchcounter", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.v7id)
              {
                int num178 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New Cost 0-99999 ", "Shadow Empire : Planetary Conquest")));
                if (num178 >= 0 & num178 <= 99999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelCost = num178;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num179 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.c4id)
              {
                float num180 = (float) Conversion.Val(Interaction.InputBox("Give Out of Fuel Move Modifier. 0.x-x.x ", "Shadow Empire : Planetary Conquest"));
                if ((double) num180 >= 0.0 & (double) num180 <= 99999.0)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].OutOfFuelMove = num180;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num181 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.c6id)
              {
                float num182 = (float) Conversion.Val(Interaction.InputBox("Give Out of Fuel Attack Modifier 0.x-x.x ", "Shadow Empire : Planetary Conquest"));
                if ((double) num182 >= 0.0 & (double) num182 <= 99999.0)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].OutOfFuelAttack = num182;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num183 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.w133id)
              {
                float num184 = (float) Conversion.Val(Interaction.InputBox("Give new 0.0-1.0 score", "Shadow Empire : Planetary Conquest"));
                if ((double) num184 >= 0.0 & (double) num184 <= 1.0)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ChanceOnDeathIfMakeHit = num184;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num185 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0.0 and 1.0", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.c7id)
              {
                float num186 = (float) Conversion.Val(Interaction.InputBox("Give Out of Fuel Defend Modifier 0.x-x.x ", "Shadow Empire : Planetary Conquest"));
                if ((double) num186 >= 0.0 & (double) num186 <= 99999.0)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].OutOfFuelDefense = num186;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num187 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.v8id)
              {
                float num188 = (float) Conversion.Val(Interaction.InputBox("Give New Cost modifier per level. 0.x-x.x ", "Shadow Empire : Planetary Conquest"));
                if ((double) num188 >= 0.0 & (double) num188 <= 99999.0)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelCostPerLevel = num188;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num189 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.v9id)
              {
                float num190 = (float) Conversion.Val(Interaction.InputBox("Give New Cost modifier per same model. 0.x-x.x ", "Shadow Empire : Planetary Conquest"));
                if ((double) num190 >= 0.0 & (double) num190 <= 99999.0)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelCostPerSameModel = num190;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num191 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.v10id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 64, this.SFtypeNr, this.detailnr2);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.v11id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 65, this.SFtypeNr, this.detailnr2);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.v20id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 66, this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.v15id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 67, this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.v22id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 71, this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.v12id)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ModelAllowUpgrade = !this.game.Data.SFTypeObj[this.SFtypeNr].ModelAllowUpgrade;
                this.Tabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.v13id)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ModelAllowImprovements = !this.game.Data.SFTypeObj[this.SFtypeNr].ModelAllowImprovements;
                this.Tabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.v21id)
              {
                int index20 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give SFType # to copy from. (-1=cancel)", "Shadow Empire : Planetary Conquest")));
                if (index20 > -1 & index20 <= this.game.Data.SFTypeCounter)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelImproveCostMod = this.game.Data.SFTypeObj[index20].ModelImproveCostMod;
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelInitialEvent = this.game.Data.SFTypeObj[index20].ModelInitialEvent;
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelInitialForAll = this.game.Data.SFTypeObj[index20].ModelInitialForAll;
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelIsBase = this.game.Data.SFTypeObj[index20].ModelIsBase;
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelNewEvent = this.game.Data.SFTypeObj[index20].ModelNewEvent;
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelAllowUpgrade = this.game.Data.SFTypeObj[index20].ModelAllowUpgrade;
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelAllowImprovements = this.game.Data.SFTypeObj[index20].ModelAllowImprovements;
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelCostPerLevel = this.game.Data.SFTypeObj[index20].ModelCostPerLevel;
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelCostPerSameImp = this.game.Data.SFTypeObj[index20].ModelCostPerSameImp;
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelCostPerSameModel = this.game.Data.SFTypeObj[index20].ModelCostPerSameModel;
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelCost = this.game.Data.SFTypeObj[index20].ModelCost;
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelExtraResearch = this.game.Data.SFTypeObj[index20].ModelExtraResearch;
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelSFTypeUpgrade = this.game.Data.SFTypeObj[index20].ModelSFTypeUpgrade;
                  int researchCounter = this.game.Data.ResearchCounter;
                  for (int index21 = 0; index21 <= researchCounter; ++index21)
                  {
                    this.game.Data.SFTypeObj[this.SFtypeNr].ModelAutoImprovement[index21] = this.game.Data.SFTypeObj[index20].ModelAutoImprovement[index21];
                    this.game.Data.SFTypeObj[this.SFtypeNr].ModelLastState[index21] = this.game.Data.SFTypeObj[index20].ModelLastState[index21];
                    this.game.Data.SFTypeObj[this.SFtypeNr].ModelPossibleImp[index21] = this.game.Data.SFTypeObj[index20].ModelPossibleImp[index21];
                    this.game.Data.SFTypeObj[this.SFtypeNr].ModelImproveEvent[index21] = this.game.Data.SFTypeObj[index20].ModelImproveEvent[index21];
                  }
                  int index22 = 0;
                  do
                  {
                    this.game.Data.SFTypeObj[this.SFtypeNr].ModelResearch[index22] = this.game.Data.SFTypeObj[index20].ModelResearch[index22];
                    ++index22;
                  }
                  while (index22 <= 9);
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num192 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.v14id)
              {
                float num193 = (float) Conversion.Val(Interaction.InputBox("Give New Cost modifier for improvement. 0.x-x.x ", "Shadow Empire : Planetary Conquest"));
                if ((double) num193 >= 0.0 & (double) num193 <= 99999.0)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelImproveCostMod = num193;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num194 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.v23id)
              {
                float num195 = (float) Conversion.Val(Interaction.InputBox("Give New modifier 0.x-x.x ", "Shadow Empire : Planetary Conquest"));
                if ((double) num195 >= 0.0 & (double) num195 <= 99999.0)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ModelSFTypeUpgrade = num195;
                  this.Tabsheet();
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num196 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.v16id)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].ModelAutoImprovement[this.detailnr2] = !this.game.Data.SFTypeObj[this.SFtypeNr].ModelAutoImprovement[this.detailnr2];
                this.Tabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.f3id)
              {
                int num197 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New ZOC Pts, please.", "Shadow Empire : Planetary Conquest")));
                if (num197 > -1 & num197 < 999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ZOCPts = num197;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num198 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.g1id)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].CanDoParadrop = !this.game.Data.SFTypeObj[this.SFtypeNr].CanDoParadrop;
                this.Tabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.g2id)
              {
                int num199 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New AntiStruc Pts, please.", "Shadow Empire : Planetary Conquest")));
                if (num199 > -1 & num199 < 99999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].AntiStrucPts = num199;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num200 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.w14id)
              {
                int num201 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new Start Round (0=normal), please.", "Shadow Empire : Planetary Conquest")));
                if (num201 > -1 & num201 < 9)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].StartCombatRound = num201;
                }
                else
                {
                  int num202 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 9", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                int num203 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new End Round (0=normal), please.", "Shadow Empire : Planetary Conquest")));
                if (num203 > -1 & num203 < 9)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].EndCombatRound = num203;
                }
                else
                {
                  int num204 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 9", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.g3id)
              {
                int num205 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New AirCarrierCap, please.", "Shadow Empire : Planetary Conquest")));
                if (num205 > -1 & num205 < 99999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].AirCarrierCap = num205;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num206 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 99999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.g24id)
              {
                this.game.Data.SFTypeObj[this.SFtypeNr].DontShowInList = !this.game.Data.SFTypeObj[this.SFtypeNr].DontShowInList;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              int num207;
              if (num1 == this.b36id)
              {
                float num208 = (float) Conversion.Val(Interaction.InputBox("Give First Rounds Penalty Mod, please (0.0(gone)-1.0(normal)).", "Shadow Empire : Planetary Conquest"));
                if ((double) num208 >= 0.0 & num207 <= 1)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].FirstRoundPenaltyMod = num208;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num209 = (int) Interaction.MsgBox((object) "Cancelled. Value must be equal/between 0.0 and 1.0", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.g4id)
              {
                float num210 = (float) Conversion.Val(Interaction.InputBox("Give New Ap Mod, please.", "Shadow Empire : Planetary Conquest"));
                if ((double) num210 > 0.0 & num207 < 10)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ApMod = num210;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num211 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0.0 and 10.0", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.g6id)
              {
                int num212 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New RdnLossPerAttack, please.", "Shadow Empire : Planetary Conquest")));
                if (num212 >= 0 & num212 <= 100)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].RdnLossPerAttack = num212;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num213 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 100", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.g7id)
              {
                if (MsgBoxResult.Yes == Interaction.MsgBox((object) "AutoDestroy in Attack?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest"))
                  this.game.Data.SFTypeObj[this.SFtypeNr].AutoDestroy = true;
                else
                  this.game.Data.SFTypeObj[this.SFtypeNr].AutoDestroy = false;
                if (MsgBoxResult.Yes == Interaction.MsgBox((object) "AutoDestroy in Defense?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest"))
                  this.game.Data.SFTypeObj[this.SFtypeNr].AutoDestroy2 = true;
                else
                  this.game.Data.SFTypeObj[this.SFtypeNr].AutoDestroy2 = false;
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.g8id)
              {
                int num214 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give EP pts, please.", "Shadow Empire : Planetary Conquest")));
                if (num214 >= 0 & num214 <= 9999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].EP = num214;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num215 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 9999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.g9id)
              {
                int num216 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give ACap Service percentage, please.", "Shadow Empire : Planetary Conquest")));
                if (num216 >= 0 & num216 <= 100)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].EP = num216;
                  this.MakeSFtypeListGUI(this.SFtypeNr);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num217 = (int) Interaction.MsgBox((object) "Cancelled. Value must be between 0 and 100", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                return windowReturnClass;
              }
              if (num1 == this.g10id)
              {
                string Left = "";
                if (!Information.IsNothing((object) DrawMod.TGame) && !Information.IsNothing((object) DrawMod.TGame.Data.SoundDir))
                  Left = DrawMod.TGame.Data.SoundDir;
                if (Operators.CompareString(Left, "", false) == 0)
                  Left = DrawMod.TGame.ModSoundDir;
                string str = this.game.HandyFunctionsObj.LoadSomething("WAVs (*.wav)|*.wav", "Select File For Move Sound", this.game.AppPath + Left + "\\", true);
                if (File.Exists(this.game.AppPath + Left + "\\" + str))
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].MoveWAV = str;
                  SoundMod.PlayAWave(this.game.AppPath + Left + "\\" + this.game.Data.SFTypeObj[this.SFtypeNr].MoveWAV, ref this.game.EditObj);
                }
                else
                {
                  int num218 = (int) Interaction.MsgBox((object) "File does not exist. wav set to no sound.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.game.Data.SFTypeObj[this.SFtypeNr].MoveWAV = "";
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.g11id)
              {
                string Left = "";
                if (!Information.IsNothing((object) DrawMod.TGame) && !Information.IsNothing((object) DrawMod.TGame.Data.SoundDir))
                  Left = DrawMod.TGame.Data.SoundDir;
                if (Operators.CompareString(Left, "", false) == 0)
                  Left = DrawMod.TGame.ModSoundDir;
                string str = this.game.HandyFunctionsObj.LoadSomething("WAVs (*.wav)|*.wav", "Select File For Battle Sound", this.game.AppPath + Left + "\\", true);
                if (File.Exists(this.game.AppPath + Left + "\\" + str))
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].BattleWAV = str;
                  SoundMod.PlayAWave(this.game.AppPath + Left + "\\" + this.game.Data.SFTypeObj[this.SFtypeNr].BattleWAV, ref this.game.EditObj);
                }
                else
                {
                  int num219 = (int) Interaction.MsgBox((object) "File does not exist. wav set to no sound.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.game.Data.SFTypeObj[this.SFtypeNr].BattleWAV = "";
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.g13id)
              {
                float num220 = (float) Conversion.Val(Interaction.InputBox("Give att mod.", "Shadow Empire : Planetary Conquest"));
                if ((double) num220 >= 0.0 & (double) num220 <= 999.0)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].CombatModAtt[this.detailnr] = num220;
                }
                else
                {
                  int num221 = (int) Interaction.MsgBox((object) "Value between 0 - 999 plz.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.g14id)
              {
                float num222 = (float) Conversion.Val(Interaction.InputBox("Give def mod.", "Shadow Empire : Planetary Conquest"));
                if ((double) num222 >= 0.0 & (double) num222 <= 999.0)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].CombatModDef[this.detailnr] = num222;
                }
                else
                {
                  int num223 = (int) Interaction.MsgBox((object) "Value between 0 - 999 plz.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.g23id)
              {
                int num224 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give extra recon", "Shadow Empire : Planetary Conquest")));
                if (num224 >= 0 & num224 <= 9999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].ExtraRecon[this.detailnr] = num224;
                }
                else
                {
                  int num225 = (int) Interaction.MsgBox((object) "Value between 0 - 9999 plz.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.b29id)
              {
                float num226 = (float) Conversion.Val(Interaction.InputBox("Give staffcombatmod... 0.0=none, 1.0=100%", "Shadow Empire : Planetary Conquest"));
                if ((double) num226 >= 0.0 & (double) num226 <= 999.0)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].StaffCombatMod = num226;
                }
                else
                {
                  int num227 = (int) Interaction.MsgBox((object) "Value between 0 - 999 plz.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.b30id)
              {
                float num228 = (float) Conversion.Val(Interaction.InputBox("Give staffmoralemod... 0.0=none, 1.0=100%", "Shadow Empire : Planetary Conquest"));
                if ((double) num228 >= 0.0 & (double) num228 <= 999.0)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].StaffMoraleMod = num228;
                }
                else
                {
                  int num229 = (int) Interaction.MsgBox((object) "Value between 0 - 999 plz.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.g15id)
              {
                int num230 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give # of staff pts.", "Shadow Empire : Planetary Conquest")));
                if (num230 > -1 & num230 <= 9999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].StaffPts = num230;
                }
                else
                {
                  int num231 = (int) Interaction.MsgBox((object) "btween 0-9999 pls", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.g16id)
              {
                int num232 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give AA Range. 1=distance 1, 2=distance 2", "Shadow Empire : Planetary Conquest")));
                if (num232 > -1 & num232 <= 99)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].AARange = num232;
                }
                else
                {
                  int num233 = (int) Interaction.MsgBox((object) "btween 0-99 pls", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.g17id)
              {
                int num234 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give # of blowbridge pts.", "Shadow Empire : Planetary Conquest")));
                if (num234 > -1 & num234 <= 9999)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].BlowBridgePts = num234;
                }
                else
                {
                  int num235 = (int) Interaction.MsgBox((object) "btween 0-9999 pls", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.g18id)
              {
                int num236 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Kill to Retreat chance (0-100).", "Shadow Empire : Planetary Conquest")));
                if (num236 > -1 & num236 <= 100)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].KilltoRetreatChance = num236;
                }
                else
                {
                  int num237 = (int) Interaction.MsgBox((object) "btween 0-100 pls", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.g19id)
              {
                int num238 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Anti Supply Pts versus LAnd.", "Shadow Empire : Planetary Conquest")));
                if (num238 > -1 & num238 <= 10009)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].AntiSupply = num238;
                }
                else
                {
                  int num239 = (int) Interaction.MsgBox((object) "btween 0-10009 pls", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.g21id)
              {
                int num240 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Anti Supply Pts versus Sea.", "Shadow Empire : Planetary Conquest")));
                if (num240 > -1 & num240 <= 10009)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].AntiSupplySea = num240;
                }
                else
                {
                  int num241 = (int) Interaction.MsgBox((object) "btween 0-19000 pls", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.g20id)
              {
                int num242 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Anti Supply Range in AP", "Shadow Empire : Planetary Conquest")));
                if (num242 > -1 & num242 <= 1090)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].AntiSupplyRange = num242;
                }
                else
                {
                  int num243 = (int) Interaction.MsgBox((object) "btween 0-1000 pls", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.h5id)
              {
                int num244 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Kill is RegVar #", "Shadow Empire : Planetary Conquest")));
                if (num244 >= -1 & num244 <= 499)
                {
                  this.game.Data.SFTypeObj[this.SFtypeNr].KillIsRegVar = num244;
                }
                else
                {
                  int num245 = (int) Interaction.MsgBox((object) "btween 0-499 pls.. or -1 for none", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeSFtypeListGUI(this.SFtypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.b27id)
              {
                new Form2((Form) this.formref).Initialize(this.game.Data, 1, this.SFtypeNr);
                this.MakeSFtypeListGUI(this.SFtypeNr);
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
