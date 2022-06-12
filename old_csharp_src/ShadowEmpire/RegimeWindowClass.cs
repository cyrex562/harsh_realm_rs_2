// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.RegimeWindowClass
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
  public class RegimeWindowClass : WindowClass
  {
    private int LibListId;
    private int LibNr;
    private ListClass LibListObj;
    private int regimeListId;
    private ListClass regimeListObj;
    private int BAddregimeId;
    private int BAddregimeTextId;
    private int BNameId;
    private int BNameTextId;
    private int BRedId;
    private int BRedTextId;
    private int BRed2Id;
    private int BRed2TextId;
    private int BRed3Id;
    private int BRed3TextId;
    private int BRed4Id;
    private int BRed4TextId;
    private int BMorId;
    private int BMorTextId;
    private int BAIId;
    private int BAITextID;
    private int PbemId;
    private int PbemTextId;
    private int BRemoveregimeId;
    private int BRemoveregimeTextId;
    private int BDrawId;
    private int BDrawTextId;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int BResId;
    private int BResTextId;
    private int BPolId;
    private int BPolTextId;
    private int clid;
    private int cltextid;
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
    private int altid;
    private int alttextid;
    private int B1Id;
    private int B1TextId;
    private int BSymbolId;
    private int BChangeSymbolId;
    private int NatIconId;
    private int NatIconPic;
    private int RoundelId;
    private int RoundelPic;
    private int stringListId;
    private ListClass stringListObj;
    private int B2Id;
    private int B2TextId;
    private int ResListId;
    private ListClass ResListObj;
    private int b3Id;
    private int B3TextId;
    private int b5Id;
    private int B5TextId;
    private int dipListId;
    private ListClass dipListObj;
    private int b4Id;
    private int B4TextId;
    private int regimeNr;
    private int TabSheetNr;
    private int DetailNr;
    private int HighId;
    private int LowId;
    private string ss;

    public RegimeWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Regimes")
    {
      this.regimeNr = -1;
      this.TabSheetNr = -1;
      this.LibNr = -1;
      this.DetailNr = -1;
      this.MakeregimeListGUI(-1);
    }

    public override void DoRefresh()
    {
      if (this.regimeNr > -1)
        this.LibNr = this.game.Data.RegimeObj[this.regimeNr].libId.libSlot;
      this.MakeregimeListGUI(this.regimeNr);
    }

    private void MakeregimeListGUI(int tregimenr)
    {
      if (this.regimeListId > 0)
        this.RemoveSubPart(this.regimeListId);
      if (this.LibListId > 0)
        this.RemoveSubPart(this.LibListId);
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
      Font font1 = (Font) null;
      ref Font local2 = ref font1;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(libListObj, 7, 200, tlistselect1, game1, tHeader: "Libraries", tbackbitmap: (ref local1), bbx: 10, bby: 40, overruleFont: (ref local2));
      this.LibListId = this.AddSubPart(ref tsubpart1, 10, 40, 200, 160, 0);
      int num3 = -1;
      int num4 = -1;
      if (this.game.Data.RegimeCounter > -1)
      {
        this.regimeListObj = new ListClass();
        int regimeCounter = this.game.Data.RegimeCounter;
        for (int index = 0; index <= regimeCounter; ++index)
        {
          if (this.game.Data.RegimeObj[index].libId.libSlot == this.LibNr | this.LibNr == -1)
          {
            this.regimeListObj.add(Strings.Trim(Conversion.Str((object) index)) + ") " + this.game.Data.RegimeObj[index].Name + "(id=" + this.game.Data.RegimeObj[index].id.ToString() + ")", index);
            ++num3;
            if (this.LibNr == index)
              num4 = num3;
          }
        }
        ListClass regimeListObj = this.regimeListObj;
        int tlistselect2 = num4;
        GameClass game2 = this.game;
        ref Bitmap local3 = ref this.OwnBitmap;
        Font font2 = (Font) null;
        ref Font local4 = ref font2;
        SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(regimeListObj, 3, 200, tlistselect2, game2, tHeader: "Regimes", tbackbitmap: (ref local3), bbx: 10, bby: 210, overruleFont: (ref local4));
        this.regimeListId = this.AddSubPart(ref tsubpart2, 10, 210, 200, 80, 0);
        this.regimeNr = tregimenr;
        this.MakeregimeTypeItemGUI();
      }
      else
      {
        this.regimeNr = tregimenr;
        this.MakeregimeTypeItemGUI();
      }
      if (this.BAddregimeId > 0)
        this.RemoveSubPart(this.BAddregimeId);
      if (this.BAddregimeTextId > 0)
        this.RemoveSubPart(this.BAddregimeTextId);
      this.ss = "Click to add a regime";
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.BAddregimeId = this.AddSubPart(ref tsubpart3, 610, 70, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Add Regime", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BAddregimeTextId = this.AddSubPart(ref tsubpart4, 650, 69, 300, 20, 0);
    }

    private void MakeregimeTypeItemGUI()
    {
      if (this.BNameId > 0)
        this.RemoveSubPart(this.BNameId);
      if (this.BNameTextId > 0)
        this.RemoveSubPart(this.BNameTextId);
      if (this.BRedId > 0)
        this.RemoveSubPart(this.BRedId);
      if (this.BRedTextId > 0)
        this.RemoveSubPart(this.BRedTextId);
      if (this.clid > 0)
        this.RemoveSubPart(this.clid);
      if (this.cltextid > 0)
        this.RemoveSubPart(this.cltextid);
      if (this.BRed2Id > 0)
        this.RemoveSubPart(this.BRed2Id);
      if (this.BRed2TextId > 0)
        this.RemoveSubPart(this.BRed2TextId);
      if (this.BRed3Id > 0)
        this.RemoveSubPart(this.BRed3Id);
      if (this.BRed3TextId > 0)
        this.RemoveSubPart(this.BRed3TextId);
      if (this.BRed4Id > 0)
        this.RemoveSubPart(this.BRed4Id);
      if (this.BRed4TextId > 0)
        this.RemoveSubPart(this.BRed4TextId);
      if (this.BRemoveregimeId > 0)
        this.RemoveSubPart(this.BRemoveregimeId);
      if (this.BRemoveregimeTextId > 0)
        this.RemoveSubPart(this.BRemoveregimeTextId);
      if (this.BDrawId > 0)
        this.RemoveSubPart(this.BDrawId);
      if (this.BDrawTextId > 0)
        this.RemoveSubPart(this.BDrawTextId);
      if (this.OptionsListId > 0)
        this.RemoveSubPart(this.OptionsListId);
      if (this.BMorId > 0)
        this.RemoveSubPart(this.BMorId);
      if (this.BMorTextId > 0)
        this.RemoveSubPart(this.BMorTextId);
      if (this.altid > 0)
        this.RemoveSubPart(this.altid);
      if (this.alttextid > 0)
        this.RemoveSubPart(this.alttextid);
      if (this.BResId > 0)
        this.RemoveSubPart(this.BResId);
      if (this.BPolId > 0)
        this.RemoveSubPart(this.BPolId);
      if (this.BResTextId > 0)
        this.RemoveSubPart(this.BResTextId);
      if (this.BPolTextId > 0)
        this.RemoveSubPart(this.BPolTextId);
      if (this.BAIId > 0)
        this.RemoveSubPart(this.BAIId);
      if (this.BAITextID > 0)
        this.RemoveSubPart(this.BAITextID);
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
      if (this.e8id > 0)
        this.RemoveSubPart(this.e8id);
      if (this.e8textid > 0)
        this.RemoveSubPart(this.e8textid);
      if (this.e9id > 0)
        this.RemoveSubPart(this.e9id);
      if (this.e9textid > 0)
        this.RemoveSubPart(this.e9textid);
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
      if (this.PbemId > 0)
        this.RemoveSubPart(this.PbemId);
      if (this.PbemTextId > 0)
        this.RemoveSubPart(this.PbemTextId);
      if (this.NatIconId > 0)
        this.RemoveSubPart(this.NatIconId);
      if (this.NatIconPic > 0)
        this.RemoveSubPart(this.NatIconPic);
      if (this.RoundelId > 0)
        this.RemoveSubPart(this.RoundelId);
      if (this.RoundelPic > 0)
        this.RemoveSubPart(this.RoundelPic);
      if (this.HighId > 0)
        this.RemoveSubPart(this.HighId);
      if (this.LowId > 0)
        this.RemoveSubPart(this.LowId);
      if (this.regimeNr > -1)
      {
        this.ss = "Click to change the name of the regime";
        SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BNameId = this.AddSubPart(ref tsubpart1, 370, 220, 32, 16, 1);
        SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Name: " + this.game.Data.RegimeObj[this.regimeNr].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BNameTextId = this.AddSubPart(ref tsubpart2, 410, 219, 200, 20, 0);
        this.ss = "Click to change the color of the counters and backgrounds of this regime";
        SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BRedId = this.AddSubPart(ref tsubpart3, 370, 50, 32, 16, 1);
        SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawHistoryForce(this.regimeNr, -1, -1));
        this.BRedTextId = this.AddSubPart(ref tsubpart4, 410, 49, 38, 38, 0);
        this.ss = "Click to change the color of the sprite and text on the counters, and over backgrounds";
        SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BRed2Id = this.AddSubPart(ref tsubpart5, 370, 120, 32, 16, 1);
        if (this.game.Data.SFTypeCounter > -1)
        {
          SubPartClass tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawHistoryForce(this.regimeNr, 50, 0));
          this.BRed2TextId = this.AddSubPart(ref tsubpart6, 410, 119, 200, 20, 0);
        }
        this.ss = "Click to set basemorale for regime. 100 means the basemorale of a people is not modified. 50 means basemorale of a people will be 50% lower.";
        SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BMorId = this.AddSubPart(ref tsubpart7, 370, 180, 32, 16, 1);
        SubPartClass tsubpart8 = (SubPartClass) new TextPartClass("BaseMorale: " + Conversion.Str((object) this.game.Data.RegimeObj[this.regimeNr].BaseMorale), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BMorTextId = this.AddSubPart(ref tsubpart8, 410, 179, 200, 20, 0);
        this.ss = "Click to set the political points this regime starts with";
        tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BResId = this.AddSubPart(ref tsubpart8, 370, 200, 32, 16, 1);
        tsubpart8 = (SubPartClass) new TextPartClass("Pol.Pts: " + Conversion.Str((object) this.game.Data.RegimeObj[this.regimeNr].ResPts), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BResTextId = this.AddSubPart(ref tsubpart8, 410, 199, 200, 20, 0);
        this.ss = "Click to set if this regime is an AI as default or not";
        tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BAIId = this.AddSubPart(ref tsubpart8, 370, 240, 32, 16, 1);
        tsubpart8 = (SubPartClass) new TextPartClass("is AI: " + Conversion.Str((object) this.game.Data.RegimeObj[this.regimeNr].AI), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BAITextID = this.AddSubPart(ref tsubpart8, 410, 239, 200, 20, 0);
        this.ss = "Click to set if this regime is sleeping. (sleeping means it wont be able to play until an event wakes it)";
        tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.e5id = this.AddSubPart(ref tsubpart8, 670, 220, 32, 16, 1);
        tsubpart8 = (SubPartClass) new TextPartClass("Sleeping: " + Conversion.Str((object) this.game.Data.RegimeObj[this.regimeNr].Sleep), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e5textid = this.AddSubPart(ref tsubpart8, 710, 219, 200, 20, 0);
        this.ss = "Click to set the PBEM++ Player for this regime. 0=auto set, 1=player 1, 2=player 2";
        tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.PbemId = this.AddSubPart(ref tsubpart8, 670, 240, 32, 16, 1);
        tsubpart8 = (SubPartClass) new TextPartClass("PBEM++ player: " + Conversion.Str((object) this.game.Data.RegimeObj[this.regimeNr].PbemPlayer), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.PbemTextId = this.AddSubPart(ref tsubpart8, 710, 239, 200, 20, 0);
        this.ss = "Set to true if regime uses Alternative actioncard pictures";
        tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.altid = this.AddSubPart(ref tsubpart8, 670, 260, 32, 16, 1);
        tsubpart8 = (SubPartClass) new TextPartClass("Alt.ActionCardPics: " + Conversion.Str((object) this.game.Data.RegimeObj[this.regimeNr].UseAlternateActionCardPics), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.alttextid = this.AddSubPart(ref tsubpart8, 710, 259, 200, 20, 0);
        this.ss = "Click to set all subformations of this regime to its current people!";
        tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
        this.e9id = this.AddSubPart(ref tsubpart8, 670, 170, 32, 16, 1);
        tsubpart8 = (SubPartClass) new TextPartClass("Set All SF Ppl", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e9textid = this.AddSubPart(ref tsubpart8, 710, 169, 200, 20, 0);
        this.ss = "Click to remove a regime";
        tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.BRemoveregimeId = this.AddSubPart(ref tsubpart8, 610, 90, 32, 16, 1);
        tsubpart8 = (SubPartClass) new TextPartClass("Remove ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BRemoveregimeTextId = this.AddSubPart(ref tsubpart8, 650, 89, 200, 20, 0);
        this.ss = "Click to change Lib";
        tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.clid = this.AddSubPart(ref tsubpart8, 850, 90, 32, 16, 1);
        tsubpart8 = (SubPartClass) new TextPartClass("Set Library", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.cltextid = this.AddSubPart(ref tsubpart8, 890, 89, 200, 20, 0);
        if (this.regimeNr < this.game.Data.RegimeCounter)
        {
          tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONDOWN, tDescript: "Move down list");
          this.HighId = this.AddSubPart(ref tsubpart8, 10, 330, 32, 16, 1);
        }
        if (this.regimeNr > 0)
        {
          tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONUP, tDescript: "Move Up List");
          this.LowId = this.AddSubPart(ref tsubpart8, 50, 330, 32, 16, 1);
        }
        this.ss = "Click to use this regime for drawing on the map";
        tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONDRAW, tDescript: this.ss);
        this.BDrawId = this.AddSubPart(ref tsubpart8, 610, 110, 32, 16, 1);
        tsubpart8 = (SubPartClass) new TextPartClass("Select as pencil", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BDrawTextId = this.AddSubPart(ref tsubpart8, 650, 109, 200, 20, 0);
        this.OptionsListObj = new ListClass();
        this.OptionsListObj.add("Statistics", 0);
        this.OptionsListObj.add("RegimeSlots", 1);
        this.OptionsListObj.add("Diplomatic Relations", 2);
        ListClass optionsListObj = this.OptionsListObj;
        int tabSheetNr = this.TabSheetNr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        tsubpart8 = (SubPartClass) new ListSubPartClass(optionsListObj, 5, 300, tabSheetNr, game, tHeader: "Property Sheets", tbackbitmap: (ref local1), bbx: 370, bby: 262, overruleFont: (ref local2));
        this.OptionsListId = this.AddSubPart(ref tsubpart8, 370, 262, 300, 128, 0);
      }
      this.maketabsheet();
    }

    private void maketabsheet()
    {
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.b3Id > 0)
        this.RemoveSubPart(this.b3Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
      if (this.b4Id > 0)
        this.RemoveSubPart(this.b4Id);
      if (this.B4TextId > 0)
        this.RemoveSubPart(this.B4TextId);
      if (this.b5Id > 0)
        this.RemoveSubPart(this.b5Id);
      if (this.B5TextId > 0)
        this.RemoveSubPart(this.B5TextId);
      if (this.e8id > 0)
        this.RemoveSubPart(this.e8id);
      if (this.e8textid > 0)
        this.RemoveSubPart(this.e8textid);
      if (this.stringListId > 0)
        this.RemoveSubPart(this.stringListId);
      if (this.ResListId > 0)
        this.RemoveSubPart(this.ResListId);
      if (this.BSymbolId > 0)
        this.RemoveSubPart(this.BSymbolId);
      if (this.BChangeSymbolId > 0)
        this.RemoveSubPart(this.BChangeSymbolId);
      if (this.NatIconId > 0)
        this.RemoveSubPart(this.NatIconId);
      if (this.NatIconPic > 0)
        this.RemoveSubPart(this.NatIconPic);
      if (this.RoundelId > 0)
        this.RemoveSubPart(this.RoundelId);
      if (this.RoundelPic > 0)
        this.RemoveSubPart(this.RoundelPic);
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
      if (this.dipListId > 0)
        this.RemoveSubPart(this.dipListId);
      if (!(this.regimeNr > -1 & this.TabSheetNr > -1))
        return;
      if (this.TabSheetNr == 0)
        this.maketabsheetnr0();
      if (this.TabSheetNr == 1)
        this.maketabsheetnr1();
      if (this.TabSheetNr != 2)
        return;
      this.maketabsheetnr4();
    }

    private void maketabsheetnr0()
    {
      this.ss = "Click to select which people rule this regime. (is important for people basemorale and production)";
      string name = this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.regimeNr].People].Name;
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.B1Id = this.AddSubPart(ref tsubpart1, 10, 380, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("People: " + name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B1TextId = this.AddSubPart(ref tsubpart2, 50, 379, 400, 20, 0);
      this.ss = "Click to change the HQ sprite";
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.Data.RegimeObj[this.regimeNr].HQSpriteNr, tDescript: this.ss);
      this.BSymbolId = this.AddSubPart(ref tsubpart3, 10, 410, 31, 31, 0);
      SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.BChangeSymbolId = this.AddSubPart(ref tsubpart4, 50, 410, 32, 16, 1);
      this.ss = "Click to select if this HQ sprite should have its colours adjusted for the regimes color.";
      SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.e8id = this.AddSubPart(ref tsubpart5, 10, 450, 32, 16, 1);
      SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("HQSymbolOverrule: " + Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.regimeNr].HQSpriteOverrule)), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.e8textid = this.AddSubPart(ref tsubpart6, 50, 449, 400, 20, 0);
      this.ss = "Click to change the National Icon of this regime";
      SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.Data.RegimeObj[this.regimeNr].NationalIconSprite, tDescript: this.ss);
      this.NatIconPic = this.AddSubPart(ref tsubpart7, 10, 490, 10, 10, 0);
      SubPartClass tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.NatIconId = this.AddSubPart(ref tsubpart8, 50, 490, 32, 16, 1);
      this.ss = "Click to set UberRegime for this Regime.";
      SubPartClass tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.e12id = this.AddSubPart(ref tsubpart9, 10, 580, 32, 16, 1);
      SubPartClass tsubpart10;
      if (this.game.Data.RegimeObj[this.regimeNr].UberRegime == -1)
      {
        tsubpart10 = (SubPartClass) new TextPartClass("UberRegime: -1 (none)", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e12textid = this.AddSubPart(ref tsubpart10, 50, 579, 400, 20, 0);
      }
      else
      {
        SubPartClass tsubpart11 = (SubPartClass) new TextPartClass("UberRegime: " + this.game.Data.RegimeObj[this.game.Data.RegimeObj[this.regimeNr].UberRegime].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e12textid = this.AddSubPart(ref tsubpart11, 50, 579, 400, 20, 0);
      }
      this.ss = "Click to set if SFType sprites should be mirrored for this regime";
      tsubpart10 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.e13id = this.AddSubPart(ref tsubpart10, 10, 610, 32, 16, 1);
      tsubpart10 = (SubPartClass) new TextPartClass("Mirror: " + Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.regimeNr].Mirror)), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.e13textid = this.AddSubPart(ref tsubpart10, 50, 609, 400, 20, 0);
      this.ss = "Click to change the Roundel Icon of this regime";
      tsubpart10 = (SubPartClass) new ButtonPartClass(this.game.Data.RegimeObj[this.regimeNr].RoundelIconSprite, tDescript: this.ss, tResizeX: 20, tresizeY: 20);
      this.RoundelPic = this.AddSubPart(ref tsubpart10, 10, 630, 10, 10, 0);
      tsubpart10 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.RoundelId = this.AddSubPart(ref tsubpart10, 50, 630, 32, 16, 1);
    }

    private void maketabsheetnr1()
    {
      this.stringListObj = new ListClass();
      int index = 0;
      do
      {
        this.stringListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.RegimeSlotName[index] + " = " + Conversion.Str((object) this.game.Data.RegimeObj[this.regimeNr].RegimeSlot[index]), index);
        ++index;
      }
      while (index <= 499);
      if (this.DetailNr > this.game.Data.StringCounter)
        this.DetailNr = -1;
      ListClass stringListObj = this.stringListObj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(stringListObj, 12, 300, detailNr, game, tHeader: "Regimeslots", tbackbitmap: (ref local1), bbx: 10, bby: 400, overruleFont: (ref local2));
      this.stringListId = this.AddSubPart(ref tsubpart, 10, 400, 300, 240, 0);
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr1b();
    }

    private void maketabsheetnr1b()
    {
      this.ss = "Click to change value of regimeslots. Regimeslots can be used in events. Their names can be set in settings";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.B2Id = this.AddSubPart(ref tsubpart1, 350, 400, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Change Value", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B2TextId = this.AddSubPart(ref tsubpart2, 390, 399, 400, 20, 0);
    }

    private void maketabsheetnr3()
    {
      this.ResListObj = new ListClass();
      if (this.game.Data.ResearchCounter <= -1)
        return;
      int researchCounter = this.game.Data.ResearchCounter;
      for (int index = 0; index <= researchCounter; ++index)
        this.ResListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.ResearchObj[index].Name + " = " + Conversion.Str((object) this.game.Data.RegimeObj[this.regimeNr].ResField[index]), index);
      if (this.DetailNr > this.game.Data.ResearchCounter)
        this.DetailNr = -1;
      ListClass resListObj = this.ResListObj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(resListObj, 12, 300, detailNr, game, tHeader: "Regimes Research", tbackbitmap: (ref local1), bbx: 10, bby: 400, overruleFont: (ref local2));
      this.ResListId = this.AddSubPart(ref tsubpart, 10, 400, 300, 240, 0);
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr3b();
    }

    private void maketabsheetnr3b()
    {
      this.ss = "Click to enable or disable a researchfield for this regime";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.b3Id = this.AddSubPart(ref tsubpart1, 350, 400, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Change Value", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B3TextId = this.AddSubPart(ref tsubpart2, 390, 399, 400, 20, 0);
      this.ss = "Click here to set all research up to lvl X on.. and above off";
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.b5Id = this.AddSubPart(ref tsubpart3, 350, 450, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Set research to lvl", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B5TextId = this.AddSubPart(ref tsubpart4, 390, 449, 400, 20, 0);
    }

    private void maketabsheetnr4()
    {
      this.dipListObj = new ListClass();
      if (this.game.Data.RegimeCounter <= -1)
        return;
      int regimeCounter = this.game.Data.RegimeCounter;
      for (int index = 0; index <= regimeCounter; ++index)
        this.dipListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.RegimeObj[index].Name + " = " + Conversion.Str((object) this.game.Data.RegimeObj[this.regimeNr].RegimeRel[index]), index);
      if (this.DetailNr > this.game.Data.RegimeCounter)
        this.DetailNr = -1;
      ListClass dipListObj = this.dipListObj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(dipListObj, 12, 300, detailNr, game, tHeader: "Dip", tbackbitmap: (ref local1), bbx: 10, bby: 400, overruleFont: (ref local2));
      this.dipListId = this.AddSubPart(ref tsubpart, 10, 400, 300, 240, 0);
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr4b();
    }

    private void maketabsheetnr4b()
    {
      this.ss = "Click to change diplomatic relation of selected regime with this regime";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.b4Id = this.AddSubPart(ref tsubpart1, 350, 400, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Change Value", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B4TextId = this.AddSubPart(ref tsubpart2, 390, 399, 400, 20, 0);
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
                this.regimeNr = -1;
                this.MakeregimeListGUI(this.regimeNr);
              }
              else if (num2 == -2)
              {
                this.LibNr = -1;
                this.regimeNr = -1;
                this.MakeregimeListGUI(this.regimeNr);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.regimeListId)
            {
              int num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num3 > -1)
              {
                this.regimeNr = num3;
                this.MakeregimeTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddregimeId)
            {
              this.game.Data.AddRegime();
              this.MakeregimeListGUI(this.regimeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BNameId)
            {
              this.game.Data.RegimeObj[this.regimeNr].Name = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest");
              this.MakeregimeListGUI(this.regimeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BMorId)
            {
              int num4 = (int) Math.Round(Conversion.Int(Conversion.Val(Conversions.ToString(Conversion.Val(Interaction.InputBox("Give new base morale please.", "Shadow Empire : Planetary Conquest"))))));
              if (num4 > -1 & num4 < 300)
              {
                this.game.Data.RegimeObj[this.regimeNr].BaseMorale = num4;
                this.MakeregimeListGUI(this.regimeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              int num5 = (int) Interaction.MsgBox((object) "Wrong input. between 0-300 please. Cancelled.", Title: ((object) "Shadow Empire : Planetary Conquest"));
            }
            else if (num1 == this.BResId)
            {
              int num6 = (int) Math.Round(Conversion.Int(Conversion.Val(Conversions.ToString(Conversion.Val(Interaction.InputBox("Give new political pts please.", "Shadow Empire : Planetary Conquest"))))));
              if (num6 > -1 & num6 < 9999)
              {
                this.game.Data.RegimeObj[this.regimeNr].ResPts = num6;
                this.MakeregimeListGUI(this.regimeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              int num7 = (int) Interaction.MsgBox((object) "Wrong input. between 0-9999 please. Cancelled.", Title: ((object) "Shadow Empire : Planetary Conquest"));
            }
            else
            {
              if (num1 == this.BAIId)
              {
                this.game.Data.RegimeObj[this.regimeNr].AI = !this.game.Data.RegimeObj[this.regimeNr].AI;
                this.MakeregimeListGUI(this.regimeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.altid)
              {
                this.game.Data.RegimeObj[this.regimeNr].UseAlternateActionCardPics = !this.game.Data.RegimeObj[this.regimeNr].UseAlternateActionCardPics;
                this.MakeregimeListGUI(this.regimeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.e5id)
              {
                this.game.Data.RegimeObj[this.regimeNr].Sleep = !this.game.Data.RegimeObj[this.regimeNr].Sleep;
                this.MakeregimeListGUI(this.regimeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.PbemId)
              {
                int num8 = (int) Math.Round(Conversion.Int(Conversion.Val(Conversions.ToString(Conversion.Val(Interaction.InputBox("Give new PBEM++ player please. 0=auto/no-overrule. 1=player 1, 2=player 2. Remember PBEM++ games always should have 2 human players! no more no less.", "Shadow Empire : Planetary Conquest"))))));
                if (num8 >= 0 & num8 < 3)
                {
                  this.game.Data.RegimeObj[this.regimeNr].PbemPlayer = num8;
                  this.MakeregimeListGUI(this.regimeNr);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                int num9 = (int) Interaction.MsgBox((object) "Wrong input. between 0-2 please. Cancelled.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                if (num1 == this.clid)
                {
                  new Form3((Form) this.formref).Initialize(this.game.Data, 97, this.regimeNr);
                  this.MakeregimeListGUI(this.regimeNr);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BRedId)
                {
                  ColorDialog colorDialog = new ColorDialog();
                  colorDialog.Color = Color.FromArgb((int) byte.MaxValue, this.game.Data.RegimeObj[this.regimeNr].Red, this.game.Data.RegimeObj[this.regimeNr].Green, this.game.Data.RegimeObj[this.regimeNr].Blue);
                  if (colorDialog.ShowDialog() == DialogResult.OK)
                  {
                    RegimeClass regimeClass1 = this.game.Data.RegimeObj[this.regimeNr];
                    Color color = colorDialog.Color;
                    int r = (int) color.R;
                    regimeClass1.Red = r;
                    RegimeClass regimeClass2 = this.game.Data.RegimeObj[this.regimeNr];
                    color = colorDialog.Color;
                    int g = (int) color.G;
                    regimeClass2.Green = g;
                    RegimeClass regimeClass3 = this.game.Data.RegimeObj[this.regimeNr];
                    color = colorDialog.Color;
                    int b1 = (int) color.B;
                    regimeClass3.Blue = b1;
                    this.game.Data.RegimeObj[this.regimeNr].HexBack = (Bitmap) null;
                    this.game.Data.RegimeObj[this.regimeNr].TempCounter = (Bitmap) null;
                  }
                  this.MakeregimeListGUI(this.regimeNr);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BRed3Id)
                {
                  ColorDialog colorDialog = new ColorDialog();
                  colorDialog.Color = Color.FromArgb((int) byte.MaxValue, this.game.Data.RegimeObj[this.regimeNr].Red3, this.game.Data.RegimeObj[this.regimeNr].Green3, this.game.Data.RegimeObj[this.regimeNr].Blue3);
                  if (colorDialog.ShowDialog() == DialogResult.OK)
                  {
                    RegimeClass regimeClass4 = this.game.Data.RegimeObj[this.regimeNr];
                    Color color = colorDialog.Color;
                    int r = (int) color.R;
                    regimeClass4.Red3 = r;
                    RegimeClass regimeClass5 = this.game.Data.RegimeObj[this.regimeNr];
                    color = colorDialog.Color;
                    int g = (int) color.G;
                    regimeClass5.Green3 = g;
                    RegimeClass regimeClass6 = this.game.Data.RegimeObj[this.regimeNr];
                    color = colorDialog.Color;
                    int b2 = (int) color.B;
                    regimeClass6.Blue3 = b2;
                  }
                  this.MakeregimeListGUI(this.regimeNr);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BRed4Id)
                {
                  ColorDialog colorDialog = new ColorDialog();
                  colorDialog.Color = Color.FromArgb((int) byte.MaxValue, this.game.Data.RegimeObj[this.regimeNr].Red4, this.game.Data.RegimeObj[this.regimeNr].Green4, this.game.Data.RegimeObj[this.regimeNr].Blue4);
                  if (colorDialog.ShowDialog() == DialogResult.OK)
                  {
                    RegimeClass regimeClass7 = this.game.Data.RegimeObj[this.regimeNr];
                    Color color = colorDialog.Color;
                    int r = (int) color.R;
                    regimeClass7.Red4 = r;
                    RegimeClass regimeClass8 = this.game.Data.RegimeObj[this.regimeNr];
                    color = colorDialog.Color;
                    int g = (int) color.G;
                    regimeClass8.Green4 = g;
                    RegimeClass regimeClass9 = this.game.Data.RegimeObj[this.regimeNr];
                    color = colorDialog.Color;
                    int b3 = (int) color.B;
                    regimeClass9.Blue4 = b3;
                  }
                  this.MakeregimeListGUI(this.regimeNr);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BRed2Id)
                {
                  ColorDialog colorDialog = new ColorDialog();
                  colorDialog.Color = Color.FromArgb((int) byte.MaxValue, this.game.Data.RegimeObj[this.regimeNr].Red2, this.game.Data.RegimeObj[this.regimeNr].Green2, this.game.Data.RegimeObj[this.regimeNr].Blue2);
                  if (colorDialog.ShowDialog() == DialogResult.OK)
                  {
                    RegimeClass regimeClass10 = this.game.Data.RegimeObj[this.regimeNr];
                    Color color = colorDialog.Color;
                    int r = (int) color.R;
                    regimeClass10.Red2 = r;
                    RegimeClass regimeClass11 = this.game.Data.RegimeObj[this.regimeNr];
                    color = colorDialog.Color;
                    int g = (int) color.G;
                    regimeClass11.Green2 = g;
                    RegimeClass regimeClass12 = this.game.Data.RegimeObj[this.regimeNr];
                    color = colorDialog.Color;
                    int b4 = (int) color.B;
                    regimeClass12.Blue2 = b4;
                    this.game.Data.RegimeObj[this.regimeNr].HexBack = (Bitmap) null;
                    this.game.Data.RegimeObj[this.regimeNr].TempCounter = (Bitmap) null;
                  }
                  this.MakeregimeListGUI(this.regimeNr);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BRemoveregimeId)
                {
                  this.game.EditObj.UnitSelected = -1;
                  this.game.Data.RemoveRegime(this.regimeNr);
                  this.MakeregimeListGUI(-1);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.HighId)
                {
                  this.game.EditObj.UnitSelected = -1;
                  this.game.Data.MoveRegimeHigher(this.regimeNr);
                  ++this.regimeNr;
                  this.MakeregimeListGUI(this.regimeNr);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.LowId)
                {
                  this.game.EditObj.UnitSelected = -1;
                  this.game.Data.MoveRegimeLower(this.regimeNr);
                  --this.regimeNr;
                  this.MakeregimeListGUI(this.regimeNr);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BDrawId)
                {
                  this.game.EditObj.PencilType = 3;
                  this.game.EditObj.PencilData1 = this.regimeNr;
                  windowReturnClass.AddCommand(4, 13);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsListId)
                {
                  int num10 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.SubPartFlag[index1] = true;
                  if (num10 > -1)
                  {
                    this.TabSheetNr = num10;
                    this.maketabsheet();
                  }
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.B1Id)
                {
                  new Form3((Form) this.formref).Initialize(this.game.Data, 3, this.regimeNr);
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.e11id)
                {
                  new Form3((Form) this.formref).Initialize(this.game.Data, 55, this.regimeNr);
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.e12id)
                {
                  new Form3((Form) this.formref).Initialize(this.game.Data, 57, this.regimeNr);
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.stringListId)
                {
                  int num11 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.SubPartFlag[index1] = true;
                  if (num11 > -1)
                  {
                    this.DetailNr = num11;
                    this.maketabsheet();
                  }
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.ResListId)
                {
                  int num12 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.SubPartFlag[index1] = true;
                  if (num12 > -1)
                  {
                    this.DetailNr = num12;
                    this.maketabsheet();
                  }
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.dipListId)
                {
                  int num13 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.SubPartFlag[index1] = true;
                  if (num13 > -1)
                  {
                    this.DetailNr = num13;
                    this.maketabsheet();
                  }
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.B2Id)
                {
                  int num14 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new people #, please.", "Shadow Empire : Planetary Conquest")));
                  if (num14 >= -1 & num14 <= 999999)
                  {
                    this.game.Data.RegimeObj[this.regimeNr].RegimeSlot[this.DetailNr] = num14;
                    this.maketabsheet();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  int num15 = (int) Interaction.MsgBox((object) "Wrong input. Cancelled.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else if (num1 == this.e10id)
                {
                  int num16 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give extra graphic #, please.", "Shadow Empire : Planetary Conquest")));
                  if (num16 >= -1 & num16 <= 999999)
                  {
                    this.game.Data.RegimeObj[this.regimeNr].ExtraGraphicUse = num16;
                    this.maketabsheet();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  int num17 = (int) Interaction.MsgBox((object) "Wrong input. Cancelled.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                {
                  if (num1 == this.b3Id)
                  {
                    this.game.Data.RegimeObj[this.regimeNr].ResField[this.DetailNr] = !this.game.Data.RegimeObj[this.regimeNr].ResField[this.DetailNr];
                    this.maketabsheet();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.b5Id)
                  {
                    int num18 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give research level for this regime...", "Shadow Empire : Planetary Conquest")));
                    if (num18 >= -1 & num18 <= 999999)
                    {
                      int researchCounter = this.game.Data.ResearchCounter;
                      for (int index2 = 0; index2 <= researchCounter; ++index2)
                      {
                        if (this.game.Data.ResearchObj[index2].TechLevel <= num18 & this.game.Data.ResearchObj[index2].TechLevel > 0)
                          this.game.Data.RegimeObj[this.regimeNr].ResField[index2] = true;
                        else
                          this.game.Data.RegimeObj[this.regimeNr].ResField[index2] = false;
                      }
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    int num19 = (int) Interaction.MsgBox((object) "Wrong input. Cancelled.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else if (num1 == this.b4Id)
                  {
                    if (this.DetailNr != this.regimeNr)
                    {
                      int num20 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new relation please. 0=war, 1=peace, 2=allied ", "Shadow Empire : Planetary Conquest")));
                      if (num20 < 0 | num20 > 2)
                      {
                        int num21 = (int) Interaction.MsgBox((object) "Beep. Not allowed. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      else
                      {
                        this.game.Data.RegimeObj[this.regimeNr].RegimeRel[this.DetailNr] = num20;
                        this.game.Data.RegimeObj[this.DetailNr].RegimeRel[this.regimeNr] = num20;
                        this.maketabsheet();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                    }
                    else
                    {
                      int num22 = (int) Interaction.MsgBox((object) "You cannot change relation with your self", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                  }
                  else
                  {
                    if (num1 == this.BChangeSymbolId)
                    {
                      string filename = this.game.HandyFunctionsObj.LoadSomething("Png (*.png)|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of HQ Symbol Sprite:", this.game.AppPath + "graphics\\", true);
                      if (File.Exists(this.game.AppPath + "graphics/" + filename))
                      {
                        this.game.Data.RegimeObj[this.regimeNr].ReplaceHQSprite(filename);
                      }
                      else
                      {
                        int num23 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.NatIconId)
                    {
                      string filename = this.game.HandyFunctionsObj.LoadSomething("Png (*.png)|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of National Identifier of this regime:", this.game.AppPath + "graphics\\", true);
                      if (File.Exists(this.game.AppPath + "graphics/" + filename))
                      {
                        this.game.Data.RegimeObj[this.regimeNr].ReplaceNationalSprite(filename);
                      }
                      else
                      {
                        int num24 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.RoundelId)
                    {
                      string filename = this.game.HandyFunctionsObj.LoadSomething("Png (*.png)|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of National Identifier of this regime:", this.game.AppPath + "graphics\\", true);
                      if (File.Exists(this.game.AppPath + "graphics/" + filename))
                      {
                        this.game.Data.RegimeObj[this.regimeNr].ReplaceRoundelSprite(filename);
                      }
                      else
                      {
                        int num25 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.e1id)
                    {
                      this.game.Data.RegimeObj[this.regimeNr].UnitName = Interaction.InputBox("Give new UnitName.", "Shadow Empire : Planetary Conquest");
                      this.MakeregimeListGUI(this.regimeNr);
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.e2id)
                    {
                      int num26 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new Unit Counter.", "Shadow Empire : Planetary Conquest")));
                      if (num26 > -1)
                      {
                        this.game.Data.RegimeObj[this.regimeNr].UnitNumber = num26;
                        this.MakeregimeListGUI(this.regimeNr);
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      int num27 = (int) Interaction.MsgBox((object) "Invalid input", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    else
                    {
                      if (num1 == this.e3id)
                      {
                        this.game.Data.RegimeObj[this.regimeNr].HQName = Interaction.InputBox("Give new HQName.", "Shadow Empire : Planetary Conquest");
                        this.MakeregimeListGUI(this.regimeNr);
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.e9id)
                      {
                        int unitCounter = this.game.Data.UnitCounter;
                        for (int index3 = 0; index3 <= unitCounter; ++index3)
                        {
                          if (this.game.Data.UnitObj[index3].Regime == this.regimeNr)
                          {
                            int sfCount = this.game.Data.UnitObj[index3].SFCount;
                            for (int index4 = 0; index4 <= sfCount; ++index4)
                              this.game.Data.SFObj[this.game.Data.UnitObj[index3].SFList[index4]].People = this.game.Data.RegimeObj[this.regimeNr].People;
                          }
                        }
                        int num28 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      else if (num1 == this.e4id)
                      {
                        int num29 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new HQ Counter.", "Shadow Empire : Planetary Conquest")));
                        if (num29 > -1)
                        {
                          this.game.Data.RegimeObj[this.regimeNr].HQNumber = num29;
                          this.MakeregimeListGUI(this.regimeNr);
                          windowReturnClass.SetFlag(true);
                          return windowReturnClass;
                        }
                        int num30 = (int) Interaction.MsgBox((object) "Invalid input", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      else
                      {
                        if (num1 == this.e7id)
                        {
                          this.game.Data.RegimeObj[this.regimeNr].DipBlock = !this.game.Data.RegimeObj[this.regimeNr].DipBlock;
                          this.MakeregimeListGUI(this.regimeNr);
                          windowReturnClass.SetFlag(true);
                          return windowReturnClass;
                        }
                        if (num1 == this.e8id)
                        {
                          this.game.Data.RegimeObj[this.regimeNr].HQSpriteOverrule = !this.game.Data.RegimeObj[this.regimeNr].HQSpriteOverrule;
                          this.MakeregimeListGUI(this.regimeNr);
                          windowReturnClass.SetFlag(true);
                          return windowReturnClass;
                        }
                        if (num1 == this.e13id)
                        {
                          this.game.Data.RegimeObj[this.regimeNr].Mirror = !this.game.Data.RegimeObj[this.regimeNr].Mirror;
                          this.MakeregimeListGUI(this.regimeNr);
                          windowReturnClass.SetFlag(true);
                          return windowReturnClass;
                        }
                      }
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
  }
}
