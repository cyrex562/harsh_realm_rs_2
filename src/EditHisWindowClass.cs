// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.EditHisWindowClass
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
  public class EditHisWindowClass : WindowClass
  {
    private int locNr;
    private int BNameId;
    private int BNameTextId;
    private int BPopId;
    private int BPopTextId;
    private int BPplId;
    private int BPplTextId;
    private int BRemoveId;
    private int BRemoveTextid;
    private int apoolid;
    private int apoolbid;
    private int impid;
    private int expid;
    private int a1id;
    private int a1bid;
    private int a2id;
    private int a2bid;
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
    private int x1id;
    private int x1bid;
    private int x2id;
    private int x2bid;
    private int x3id;
    private int x3bid;
    private int x4id;
    private int x4bid;
    private int x5id;
    private int x5bid;
    private int x6id;
    private int x6bid;
    private int x7id;
    private int x7bid;
    private int xx7id;
    private int xx7bid;
    private int a10id;
    private int a10bid;
    private int a11id;
    private int a11bid;
    private int aa11id;
    private int aa11bid;
    private int ab11id;
    private int ab11bid;
    private int a12id;
    private int a12bid;
    private int a13id;
    private int a13bid;
    private int a14id;
    private int a14bid;
    private int a15id;
    private int a15bid;
    private int a16id;
    private int a16bid;
    private int a20id;
    private int a20bid;
    private int a17id;
    private int a17bid;
    private int a18id;
    private int a18bid;
    private int a19id;
    private int a19bid;
    private int a21id;
    private int a21bid;
    private int v19id;
    private int v19bid;
    private int v21id;
    private int v21bid;
    private int v22id;
    private int v22bid;
    private int v23id;
    private int v23bid;
    private int v20id;
    private int v20bid;
    private int a22id;
    private int a22bid;
    private int a221id;
    private int a221bid;
    private int a23id;
    private int a23bid;
    private int a24id;
    private int a24bid;
    private int a25id;
    private int a25bid;
    private int a26id;
    private int a26bid;
    private int a27id;
    private int a27bid;
    private int a28id;
    private int a28bid;
    private int a29id;
    private int a29bid;
    private int a30id;
    private int a30bid;
    private int a31id;
    private int a31bid;
    private int a32id;
    private int a32bid;
    private int a320id;
    private int a320bid;
    private int a33id;
    private int a33bid;
    private int a38id;
    private int a38bid;
    private int a34id;
    private int a34bid;
    private int a35id;
    private int a35bid;
    private int a36id;
    private int a36bid;
    private int a37id;
    private int a37bid;
    private int a39id;
    private int a39bid;
    private int a40id;
    private int a40bid;
    private int a440id;
    private int a440bid;
    private int a41id;
    private int a41bid;
    private int a42id;
    private int a42bid;
    private int a43id;
    private int a43bid;
    private int a45id;
    private int a45bid;
    private int asid;
    private int asidb;
    private int a44id;
    private int HisListId;
    private ListClass HisListObj;
    private int LibListId;
    private ListClass LibListObj;
    private int VarListId;
    private ListClass VarListObj;
    private int DeckListId;
    private ListClass deckListObj;
    private int AutoListId;
    private ListClass AutoListObj;
    private int BAddHisId;
    private int bUpId;
    private int bDownId;
    private int BAddHisTextId;
    private int SPListId;
    private ListClass SPListObj;
    private int BRemoveHisId;
    private int BRemoveHisTextId;
    private int libnr;
    private int detailnr;
    private int detailnr2;
    private int detailnr3;
    private int detailnr4;
    private int detailnr5;
    private int detailnr6;
    private int DescBox;
    private string ss;

    public EditHisWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Historical Units (&officers)")
    {
      this.locNr = !(this.game.SelectX > -1 & this.game.SelectY > -1) ? -1 : this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location;
      this.detailnr = -1;
      this.libnr = -1;
      this.detailnr2 = -1;
      this.detailnr3 = -1;
      this.detailnr4 = -1;
      this.detailnr5 = -1;
      this.MakeHisList();
      this.showinfo();
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      switch (nr)
      {
        case 13:
          WindowReturnClass windowReturnClass2 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.BAddHisId)] + 1, this.SubPartY[this.SubpartNr(this.BAddHisId)] + 1, 1);
          windowReturnClass2.SetFlag(true);
          return windowReturnClass2;
        case 38:
          --this.detailnr;
          if (this.detailnr < 0)
            this.detailnr = 0;
          if (this.game.Data.HistoricalUnitCounter == -1)
            this.detailnr = -1;
          this.showinfo();
          windowReturnClass1.SetFlag(true);
          return windowReturnClass1;
        case 40:
          ++this.detailnr;
          if (this.detailnr > this.game.Data.HistoricalUnitCounter)
            this.detailnr = this.game.Data.HistoricalUnitCounter;
          this.showinfo();
          windowReturnClass1.SetFlag(true);
          return windowReturnClass1;
        case 77:
          WindowReturnClass windowReturnClass3 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.x5id)] + 1, this.SubPartY[this.SubpartNr(this.x5id)] + 1, 1);
          windowReturnClass3.SetFlag(true);
          return windowReturnClass3;
        case 83:
          WindowReturnClass windowReturnClass4 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.a11id)] + 1, this.SubPartY[this.SubpartNr(this.a11id)] + 1, 1);
          windowReturnClass4.SetFlag(true);
          return windowReturnClass4;
        case 84:
          if (this.detailnr > -1)
          {
            this.game.Data.HistoricalUnitObj[this.detailnr].TempVar3 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Tempvar3")));
            this.game.Data.HistoricalUnitObj[this.detailnr].TempVar4 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Tempvar4")));
            this.game.Data.HistoricalUnitObj[this.detailnr].TempVar5 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Tempvar5")));
          }
          this.showinfo();
          windowReturnClass1.SetFlag(true);
          return windowReturnClass1;
        default:
          return windowReturnClass1;
      }
    }

    public void MakeHisList()
    {
      int[] numArray1 = new int[this.game.Data.HistoricalUnitCounter + 1];
      int unitCounter = this.game.Data.UnitCounter;
      for (int index1 = 0; index1 <= unitCounter; ++index1)
      {
        if (this.game.Data.UnitObj[index1].Historical > -1)
        {
          int[] numArray2 = numArray1;
          int[] numArray3 = numArray2;
          int historical = this.game.Data.UnitObj[index1].Historical;
          int index2 = historical;
          int num = numArray2[historical] + 1;
          numArray3[index2] = num;
        }
      }
      if (this.HisListId > 0)
        this.RemoveSubPart(this.HisListId);
      if (this.BAddHisId > 0)
        this.RemoveSubPart(this.BAddHisId);
      if (this.BAddHisTextId > 0)
        this.RemoveSubPart(this.BAddHisTextId);
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
        if (this.libnr == index)
          num1 = num2;
        this.LibListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.LibraryObj[index].name, index);
      }
      if (this.libnr == -1)
        num1 = 0;
      ListClass libListObj = this.LibListObj;
      int tlistselect1 = num1;
      GameClass game1 = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(libListObj, 16, 200, tlistselect1, game1, tHeader: "Libraries", tbackbitmap: (ref local1), bbx: 5, bby: 50, overruleFont: (ref local2));
      this.LibListId = this.AddSubPart(ref tsubpart1, 5, 50, 200, 304, 0);
      if (this.game.Data.HistoricalUnitCounter > -1)
      {
        this.HisListObj = new ListClass();
        int num3 = -1;
        int num4 = -1;
        int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
        for (int index = 0; index <= historicalUnitCounter; ++index)
        {
          if (this.game.Data.HistoricalUnitObj[index].LibId.libSlot == this.libnr | this.libnr == -1)
          {
            ++num4;
            string tvalue;
            if (this.game.Data.HistoricalUnitObj[index].Type == 1)
              tvalue = "1.Ind";
            if (this.game.Data.HistoricalUnitObj[index].Type == 2)
              tvalue = "2.Div";
            if (this.game.Data.HistoricalUnitObj[index].Type == 5)
              tvalue = "5.Corps";
            if (this.game.Data.HistoricalUnitObj[index].Type == 6)
              tvalue = "6.Army";
            if (this.game.Data.HistoricalUnitObj[index].Type == 7)
              tvalue = "7.AG";
            if (this.game.Data.HistoricalUnitObj[index].Type == 8)
              tvalue = "8.High";
            string tvalue4 = Strings.Trim(Conversion.Str((object) numArray1[index]));
            string tvalue3 = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[index].TempRegime));
            string tvalue2 = Conversion.Str((object) this.game.Data.HistoricalUnitObj[index].SmallGfx) + "," + Conversion.Str((object) this.game.Data.HistoricalUnitObj[index].Counter) + "," + this.game.Data.HistoricalUnitObj[index].CounterString;
            if (!this.game.Data.HistoricalUnitObj[index].Model)
            {
              if (this.game.Data.HistoricalUnitObj[index].ModelMaster > -1)
                this.HisListObj.add(Strings.Trim(Conversion.Str((object) index)) + ") ID=" + Conversion.Str((object) this.game.Data.HistoricalUnitObj[index].ID) + ", " + this.game.Data.HistoricalUnitObj[index].Name + " (" + this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[index].ModelMaster].Name + ")", index, tvalue, tvalue2, tvalue3, tvalue4);
              else
                this.HisListObj.add(Strings.Trim(Conversion.Str((object) index)) + ") ID=" + Conversion.Str((object) this.game.Data.HistoricalUnitObj[index].ID) + ", " + this.game.Data.HistoricalUnitObj[index].Name, index, tvalue, tvalue2, tvalue3, tvalue4);
            }
            else
              this.HisListObj.add(Strings.Trim(Conversion.Str((object) index)) + ") ID=" + Conversion.Str((object) this.game.Data.HistoricalUnitObj[index].ID) + ", MODEL " + this.game.Data.HistoricalUnitObj[index].Name, index, tvalue, tvalue2, tvalue3, tvalue4);
            if (this.detailnr == index)
              num3 = num4;
          }
        }
        if (num3 == -1)
          this.detailnr = -1;
        ListClass hisListObj = this.HisListObj;
        int tlistselect2 = num3;
        GameClass game2 = this.game;
        ref Bitmap local3 = ref this.OwnBitmap;
        font = (Font) null;
        ref Font local4 = ref font;
        SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(hisListObj, 16, 580, tlistselect2, game2, tHeader: "HisUnits ID+Name                                                                    Level           SmlGf,Nato,Sh        Regime      Units", tShowPair: true, tValueWidth: 250, tbackbitmap: (ref local3), bbx: 215, bby: 50, overruleFont: (ref local4));
        this.HisListId = this.AddSubPart(ref tsubpart2, 215, 50, 580, 304, 0);
      }
      if (this.BAddHisId > 0)
        this.RemoveSubPart(this.BAddHisId);
      if (this.BAddHisTextId > 0)
        this.RemoveSubPart(this.BAddHisTextId);
      this.ss = "Click to add another Historical Unit";
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.BAddHisId = this.AddSubPart(ref tsubpart3, 830, 50, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Add Historic Unit", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BAddHisTextId = this.AddSubPart(ref tsubpart4, 880, 50, 300, 20, 0);
    }

    public override void DoRefresh()
    {
      this.MakeHisList();
      this.showinfo();
    }

    private void showinfo()
    {
      if (this.bUpId > 0)
        this.RemoveSubPart(this.bUpId);
      if (this.bDownId > 0)
        this.RemoveSubPart(this.bDownId);
      if (this.impid > 0)
        this.RemoveSubPart(this.impid);
      if (this.expid > 0)
        this.RemoveSubPart(this.expid);
      if (this.BRemoveHisId > 0)
        this.RemoveSubPart(this.BRemoveHisId);
      if (this.BRemoveHisTextId > 0)
        this.RemoveSubPart(this.BRemoveHisTextId);
      if (this.BNameId > 0)
        this.RemoveSubPart(this.BNameId);
      if (this.BNameTextId > 0)
        this.RemoveSubPart(this.BNameTextId);
      if (this.BPopId > 0)
        this.RemoveSubPart(this.BPopId);
      if (this.BPopTextId > 0)
        this.RemoveSubPart(this.BPopTextId);
      if (this.BPplId > 0)
        this.RemoveSubPart(this.BPplId);
      if (this.BPplTextId > 0)
        this.RemoveSubPart(this.BPplTextId);
      if (this.BRemoveId > 0)
        this.RemoveSubPart(this.BRemoveId);
      if (this.BRemoveTextid > 0)
        this.RemoveSubPart(this.BRemoveTextid);
      if (this.DescBox > 0)
        this.RemoveSubPart(this.DescBox);
      if (this.AutoListId > 0)
        this.RemoveSubPart(this.AutoListId);
      if (this.DeckListId > 0)
        this.RemoveSubPart(this.DeckListId);
      if (this.VarListId > 0)
        this.RemoveSubPart(this.VarListId);
      if (this.SPListId > 0)
        this.RemoveSubPart(this.SPListId);
      if (this.x1id > 0)
        this.RemoveSubPart(this.x1id);
      if (this.x1bid > 0)
        this.RemoveSubPart(this.x1bid);
      if (this.x2id > 0)
        this.RemoveSubPart(this.x2id);
      if (this.x2bid > 0)
        this.RemoveSubPart(this.x2bid);
      if (this.x3id > 0)
        this.RemoveSubPart(this.x3id);
      if (this.x3bid > 0)
        this.RemoveSubPart(this.x3bid);
      if (this.x4id > 0)
        this.RemoveSubPart(this.x4id);
      if (this.x4bid > 0)
        this.RemoveSubPart(this.x4bid);
      if (this.x5id > 0)
        this.RemoveSubPart(this.x5id);
      if (this.x5bid > 0)
        this.RemoveSubPart(this.x5bid);
      if (this.x6id > 0)
        this.RemoveSubPart(this.x6id);
      if (this.x6bid > 0)
        this.RemoveSubPart(this.x6bid);
      if (this.x7id > 0)
        this.RemoveSubPart(this.x7id);
      if (this.x7bid > 0)
        this.RemoveSubPart(this.x7bid);
      if (this.xx7id > 0)
        this.RemoveSubPart(this.xx7id);
      if (this.xx7bid > 0)
        this.RemoveSubPart(this.xx7bid);
      if (this.apoolid > 0)
        this.RemoveSubPart(this.apoolid);
      if (this.apoolbid > 0)
        this.RemoveSubPart(this.apoolbid);
      if (this.a1id > 0)
        this.RemoveSubPart(this.a1id);
      if (this.a1bid > 0)
        this.RemoveSubPart(this.a1bid);
      if (this.a2id > 0)
        this.RemoveSubPart(this.a2id);
      if (this.a2bid > 0)
        this.RemoveSubPart(this.a2bid);
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
      if (this.x7id > 0)
        this.RemoveSubPart(this.x7id);
      if (this.x7bid > 0)
        this.RemoveSubPart(this.x7bid);
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
      if (this.a12id > 0)
        this.RemoveSubPart(this.a12id);
      if (this.a12bid > 0)
        this.RemoveSubPart(this.a12bid);
      if (this.a11id > 0)
        this.RemoveSubPart(this.a11id);
      if (this.a11bid > 0)
        this.RemoveSubPart(this.a11bid);
      if (this.aa11id > 0)
        this.RemoveSubPart(this.aa11id);
      if (this.aa11bid > 0)
        this.RemoveSubPart(this.aa11bid);
      if (this.ab11id > 0)
        this.RemoveSubPart(this.ab11id);
      if (this.ab11bid > 0)
        this.RemoveSubPart(this.ab11bid);
      if (this.a13id > 0)
        this.RemoveSubPart(this.a13id);
      if (this.a13bid > 0)
        this.RemoveSubPart(this.a13bid);
      if (this.a14id > 0)
        this.RemoveSubPart(this.a14id);
      if (this.a14bid > 0)
        this.RemoveSubPart(this.a14bid);
      if (this.a15id > 0)
        this.RemoveSubPart(this.a15id);
      if (this.a15bid > 0)
        this.RemoveSubPart(this.a15bid);
      if (this.a16id > 0)
        this.RemoveSubPart(this.a16id);
      if (this.a16bid > 0)
        this.RemoveSubPart(this.a16bid);
      if (this.a17id > 0)
        this.RemoveSubPart(this.a17id);
      if (this.a17bid > 0)
        this.RemoveSubPart(this.a17bid);
      if (this.a18id > 0)
        this.RemoveSubPart(this.a18id);
      if (this.a44id > 0)
        this.RemoveSubPart(this.a44id);
      if (this.a18bid > 0)
        this.RemoveSubPart(this.a18bid);
      if (this.a19id > 0)
        this.RemoveSubPart(this.a19id);
      if (this.a19bid > 0)
        this.RemoveSubPart(this.a19bid);
      if (this.a20id > 0)
        this.RemoveSubPart(this.a20id);
      if (this.a20bid > 0)
        this.RemoveSubPart(this.a20bid);
      if (this.a21id > 0)
        this.RemoveSubPart(this.a21id);
      if (this.a21bid > 0)
        this.RemoveSubPart(this.a21bid);
      if (this.v19id > 0)
        this.RemoveSubPart(this.v19id);
      if (this.v19bid > 0)
        this.RemoveSubPart(this.v19bid);
      if (this.v20id > 0)
        this.RemoveSubPart(this.v20id);
      if (this.v20bid > 0)
        this.RemoveSubPart(this.v20bid);
      if (this.v21id > 0)
        this.RemoveSubPart(this.v21id);
      if (this.v21bid > 0)
        this.RemoveSubPart(this.v21bid);
      if (this.v22id > 0)
        this.RemoveSubPart(this.v22id);
      if (this.v22bid > 0)
        this.RemoveSubPart(this.v22bid);
      if (this.v23id > 0)
        this.RemoveSubPart(this.v23id);
      if (this.v23bid > 0)
        this.RemoveSubPart(this.v23bid);
      if (this.a22id > 0)
        this.RemoveSubPart(this.a22id);
      if (this.a22bid > 0)
        this.RemoveSubPart(this.a22bid);
      if (this.a221id > 0)
        this.RemoveSubPart(this.a221id);
      if (this.a221bid > 0)
        this.RemoveSubPart(this.a221bid);
      if (this.a23id > 0)
        this.RemoveSubPart(this.a23id);
      if (this.a23bid > 0)
        this.RemoveSubPart(this.a23bid);
      if (this.a24id > 0)
        this.RemoveSubPart(this.a24id);
      if (this.a24bid > 0)
        this.RemoveSubPart(this.a24bid);
      if (this.a25id > 0)
        this.RemoveSubPart(this.a25id);
      if (this.a25bid > 0)
        this.RemoveSubPart(this.a25bid);
      if (this.a26id > 0)
        this.RemoveSubPart(this.a26id);
      if (this.a26bid > 0)
        this.RemoveSubPart(this.a26bid);
      if (this.a27id > 0)
        this.RemoveSubPart(this.a27id);
      if (this.a27bid > 0)
        this.RemoveSubPart(this.a27bid);
      if (this.a28id > 0)
        this.RemoveSubPart(this.a28id);
      if (this.a28bid > 0)
        this.RemoveSubPart(this.a28bid);
      if (this.a29id > 0)
        this.RemoveSubPart(this.a29id);
      if (this.a29bid > 0)
        this.RemoveSubPart(this.a29bid);
      if (this.a30id > 0)
        this.RemoveSubPart(this.a30id);
      if (this.a30bid > 0)
        this.RemoveSubPart(this.a30bid);
      if (this.a31id > 0)
        this.RemoveSubPart(this.a31id);
      if (this.a31bid > 0)
        this.RemoveSubPart(this.a31bid);
      if (this.a32id > 0)
        this.RemoveSubPart(this.a32id);
      if (this.a320id > 0)
        this.RemoveSubPart(this.a320id);
      if (this.a32bid > 0)
        this.RemoveSubPart(this.a32bid);
      if (this.a320bid > 0)
        this.RemoveSubPart(this.a320bid);
      if (this.a33id > 0)
        this.RemoveSubPart(this.a33id);
      if (this.a33bid > 0)
        this.RemoveSubPart(this.a33bid);
      if (this.a34id > 0)
        this.RemoveSubPart(this.a34id);
      if (this.a34bid > 0)
        this.RemoveSubPart(this.a34bid);
      if (this.a35id > 0)
        this.RemoveSubPart(this.a35id);
      if (this.a35bid > 0)
        this.RemoveSubPart(this.a35bid);
      if (this.a36id > 0)
        this.RemoveSubPart(this.a36id);
      if (this.a36bid > 0)
        this.RemoveSubPart(this.a36bid);
      if (this.a37id > 0)
        this.RemoveSubPart(this.a37id);
      if (this.a37bid > 0)
        this.RemoveSubPart(this.a37bid);
      if (this.a38id > 0)
        this.RemoveSubPart(this.a38id);
      if (this.a38bid > 0)
        this.RemoveSubPart(this.a38bid);
      if (this.a39id > 0)
        this.RemoveSubPart(this.a39id);
      if (this.a39bid > 0)
        this.RemoveSubPart(this.a39bid);
      if (this.a40id > 0)
        this.RemoveSubPart(this.a40id);
      if (this.a40bid > 0)
        this.RemoveSubPart(this.a40bid);
      if (this.a440id > 0)
        this.RemoveSubPart(this.a440id);
      if (this.a440bid > 0)
        this.RemoveSubPart(this.a440bid);
      if (this.a41id > 0)
        this.RemoveSubPart(this.a41id);
      if (this.a41bid > 0)
        this.RemoveSubPart(this.a41bid);
      if (this.a42id > 0)
        this.RemoveSubPart(this.a42id);
      if (this.a42bid > 0)
        this.RemoveSubPart(this.a42bid);
      if (this.a43id > 0)
        this.RemoveSubPart(this.a43id);
      if (this.a43bid > 0)
        this.RemoveSubPart(this.a43bid);
      if (this.a45id > 0)
        this.RemoveSubPart(this.a45id);
      if (this.a45bid > 0)
        this.RemoveSubPart(this.a45bid);
      if (this.asid > 0)
        this.RemoveSubPart(this.asid);
      if (this.asidb > 0)
        this.RemoveSubPart(this.asidb);
      this.MakeHisList();
      if (this.detailnr > -1)
      {
        this.ss = "Change Shortname (# or short name displayed on unit counter)";
        SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a11id = this.AddSubPart(ref tsubpart1, 830, 100, 32, 16, 1);
        SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Sh", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 20, false, tDescript: this.ss);
        this.a11bid = this.AddSubPart(ref tsubpart2, 865, 100, 30, 20, 0);
        this.ss = "Just change the nato counter (you can find these graphics and their number in the systemgraphics/nato directory)";
        SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.aa11id = this.AddSubPart(ref tsubpart3, 895, 100, 32, 16, 1);
        SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Nat", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 20, false, tDescript: this.ss);
        this.aa11bid = this.AddSubPart(ref tsubpart4, 930, 100, 30, 20, 0);
        this.ss = "Change Type";
        SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a12id = this.AddSubPart(ref tsubpart5, 960, 100, 32, 16, 1);
        SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("Typ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 40, 20, false, tDescript: this.ss);
        this.a12bid = this.AddSubPart(ref tsubpart6, 995, 99, 40, 20, 0);
        this.ss = "Just change the small graphic used (instead of nato)";
        SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.ab11id = this.AddSubPart(ref tsubpart7, 1030, 100, 32, 16, 1);
        SubPartClass tsubpart8 = (SubPartClass) new TextPartClass("Sml", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 20, false, tDescript: this.ss);
        this.ab11bid = this.AddSubPart(ref tsubpart8, 1065, 100, 30, 20, 0);
      }
      if (this.detailnr > -1)
      {
        this.ss = "Move HisUnit Up (just for sorting purposes)";
        if (this.detailnr > 0)
        {
          SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONUP, tDescript: this.ss);
          this.bUpId = this.AddSubPart(ref tsubpart, 830, 80, 32, 16, 1);
        }
        this.ss = "Move HisUnit Down (just for sorting purposes)";
        if (this.detailnr < this.game.Data.HistoricalUnitCounter)
        {
          SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONDOWN, tDescript: this.ss);
          this.bDownId = this.AddSubPart(ref tsubpart, 865, 80, 32, 16, 1);
        }
        this.ss = "Remove Historical Unit";
        SubPartClass tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.BRemoveHisId = this.AddSubPart(ref tsubpart9, 900, 80, 32, 16, 1);
        this.ss = "Export NATO (+names as reference)";
        SubPartClass tsubpart10 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
        this.expid = this.AddSubPart(ref tsubpart10, 935, 80, 32, 16, 1);
        this.ss = "Import NATO (only number before first ',')";
        SubPartClass tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
        this.impid = this.AddSubPart(ref tsubpart11, 970, 80, 32, 16, 1);
        this.ss = "Assign to library";
        SubPartClass tsubpart12 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.asid = this.AddSubPart(ref tsubpart12, 1005, 80, 32, 16, 1);
      }
      this.ss = "Clear All Historical Units";
      SubPartClass tsubpart13 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.a13id = this.AddSubPart(ref tsubpart13, 830, 120, 32, 16, 1);
      SubPartClass tsubpart14 = (SubPartClass) new TextPartClass("ClearAll", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.a13bid = this.AddSubPart(ref tsubpart14, 860, 119, 60, 20, 0);
      this.ss = "Auto-Create Historical Units";
      SubPartClass tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.a14id = this.AddSubPart(ref tsubpart15, 930, 120, 32, 16, 1);
      SubPartClass tsubpart16 = (SubPartClass) new TextPartClass("Auto-Create", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.a14bid = this.AddSubPart(ref tsubpart16, 960, 119, 300, 20, 0);
      this.ss = "Sort Historical units 1st on regime, then on Level in OOB";
      SubPartClass tsubpart17 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.a15id = this.AddSubPart(ref tsubpart17, 830, 140, 32, 16, 1);
      SubPartClass tsubpart18 = (SubPartClass) new TextPartClass("Sort", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.a15bid = this.AddSubPart(ref tsubpart18, 860, 139, 60, 20, 0);
      this.ss = "Set regime of historical unit";
      SubPartClass tsubpart19 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a16id = this.AddSubPart(ref tsubpart19, 930, 140, 32, 16, 1);
      SubPartClass tsubpart20 = (SubPartClass) new TextPartClass("Regime", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.a16bid = this.AddSubPart(ref tsubpart20, 960, 139, 300, 20, 0);
      string str1 = "";
      SubPartClass tsubpart21;
      if (this.detailnr > -1)
      {
        int unitCounter = this.game.Data.UnitCounter;
        for (int index = 0; index <= unitCounter; ++index)
        {
          if (this.game.Data.UnitObj[index].Historical == this.detailnr)
            str1 = str1 + this.game.Data.UnitObj[index].Name + "(" + Conversion.Str((object) this.game.Data.UnitObj[index].X) + "," + Conversion.Str((object) this.game.Data.UnitObj[index].Y) + "), reg = " + Conversion.Str((object) this.game.Data.UnitObj[index].Regime) + "\r\n";
        }
        GameClass game = this.game;
        int twidth = Math.Min(300, this.game.ScreenWidth - 830);
        Font tfont = new Font(this.game.FontCol.Families[1], 10f, FontStyle.Regular, GraphicsUnit.Pixel);
        string tText = str1;
        Color white = Color.White;
        Bitmap bitmap = (Bitmap) null;
        ref Bitmap local = ref bitmap;
        tsubpart21 = (SubPartClass) new TextAreaClass(game, twidth, 3, tfont, "Map units attached", true, tText, white, tbackbitmap: (ref local));
        this.DescBox = this.AddSubPart(ref tsubpart21, 830, 160, Math.Min(300, this.game.ScreenWidth - 830), 48, 0);
      }
      if (this.detailnr > -1)
      {
        if (this.game.Data.HistoricalUnitObj[this.detailnr].SmallGfx > -1)
        {
          tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[this.detailnr].SmallGfx], tDescript: "the NATO graphic of the historical unit", tResizeX: 38, tresizeY: 38);
          this.a44id = this.AddSubPart(ref tsubpart21, 20, 345, 38, 38, 1);
        }
        else if (this.game.Data.HistoricalUnitObj[this.detailnr].Counter > 0 && this.game.Data.HistoricalUnitObj[this.detailnr].Counter > -1)
        {
          tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.NATO[this.game.Data.HistoricalUnitObj[this.detailnr].Counter], tDescript: "the NATO graphic of the historical unit", tResizeX: 38, tresizeY: 38);
          this.a44id = this.AddSubPart(ref tsubpart21, 20, 345, 38, 38, 1);
        }
        this.ss = "Click to change the people of this historical unit. (important for officers and HQs)";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.x7id = this.AddSubPart(ref tsubpart21, 10, 420, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("People = " + this.game.Data.HistoricalUnitObj[this.detailnr].People.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
        this.x7bid = this.AddSubPart(ref tsubpart21, 50, 419, 150, 20, 0);
        this.ss = "Click to change Gfx People overrule use (only graphical not rule implications)";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.xx7id = this.AddSubPart(ref tsubpart21, 220, 420, 32, 16, 1);
        if (this.game.Data.HistoricalUnitObj[this.detailnr].UsePeopleGfx > -1)
        {
          tsubpart21 = (SubPartClass) new TextPartClass("GfxPeopleUse = " + this.game.Data.HistoricalUnitObj[this.detailnr].UsePeopleGfx.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
          this.xx7bid = this.AddSubPart(ref tsubpart21, 250, 419, 150, 20, 0);
        }
        else
        {
          tsubpart21 = (SubPartClass) new TextPartClass("GfxPeopleUse = -1", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
          this.xx7bid = this.AddSubPart(ref tsubpart21, 250, 419, 150, 20, 0);
        }
        this.ss = "Click to set if AI will be allowed to split this group (only for HQs)";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a39id = this.AddSubPart(ref tsubpart21, 10, 440, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("NoSplit = " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].NoSplit), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 100, 20, false, tDescript: this.ss);
        this.a39bid = this.AddSubPart(ref tsubpart21, 50, 440, 100, 20, 0);
        this.ss = "Click to change name of the historical unit selected...";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a25id = this.AddSubPart(ref tsubpart21, 10, 460, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("Name = " + this.game.Data.HistoricalUnitObj[this.detailnr].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
        this.a25bid = this.AddSubPart(ref tsubpart21, 50, 459, 350, 20, 0);
        this.ss = "Click to set as part of an AI model list.";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a440id = this.AddSubPart(ref tsubpart21, 610, 660, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("AIZoneListNr = " + this.game.Data.HistoricalUnitObj[this.detailnr].AIlist.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a440bid = this.AddSubPart(ref tsubpart21, 650, 659, 150, 20, 0);
        this.ss = "Set if Historical Unit is a Model Unit";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.x1id = this.AddSubPart(ref tsubpart21, 10, 480, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("Model=" + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].Model), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 100, 20, false, tDescript: this.ss);
        this.x1bid = this.AddSubPart(ref tsubpart21, 50, 479, 100, 20, 0);
        this.ss = "Set the maximum number of units with this model to be present. -1=unlimited. 0=none can be created in game by player";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a41id = this.AddSubPart(ref tsubpart21, 150, 480, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("MaxPresent=" + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].MaxPresent), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 120, 20, false, tDescript: this.ss);
        this.a41bid = this.AddSubPart(ref tsubpart21, 190, 479, 120, 20, 0);
        this.ss = "Set color blender -255 to +255, it adds or diminishes from the counter color";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.x2id = this.AddSubPart(ref tsubpart21, 410, 540, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("Color = " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].Red) + "," + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].Green) + "," + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].Blue), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.x2bid = this.AddSubPart(ref tsubpart21, 450, 539, 200, 20, 0);
        this.SPListObj = new ListClass();
        int index = 0;
        do
        {
          string str2 = Conversion.Str((object) index) + ") ";
          this.SPListObj.add(this.game.Data.HistoricalUnitObj[this.detailnr].SubParts[index] <= -1 ? (this.game.Data.HistoricalUnitObj[this.detailnr].Designation[index] <= -1 ? str2 + " -" : str2 + "No Predef" + ", " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].DesignationSmall[index]) + ", " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].Designation[index])) : str2 + this.game.Data.UnitObj[this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[this.detailnr].SubParts[index])].Name + ", " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].DesignationSmall[index]) + ", " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].Designation[index]), index);
          ++index;
        }
        while (index <= 9);
        ListClass spListObj = this.SPListObj;
        int detailnr5 = this.detailnr5;
        GameClass game1 = this.game;
        Bitmap bitmap1 = (Bitmap) null;
        ref Bitmap local1 = ref bitmap1;
        Font font1 = (Font) null;
        ref Font local2 = ref font1;
        tsubpart21 = (SubPartClass) new ListSubPartClass(spListObj, 3, 400, detailnr5, game1, tHeader: "Subpart Units             smallGfx,Nato", tbackbitmap: (ref local1), overruleFont: (ref local2));
        this.SPListId = this.AddSubPart(ref tsubpart21, 410, 360, 400, 80, 0);
        if (this.detailnr5 > -1)
        {
          this.ss = "Remove Subpart";
          tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
          this.x3id = this.AddSubPart(ref tsubpart21, 410, 460, 32, 16, 1);
          tsubpart21 = (SubPartClass) new TextPartClass("Remove Subpart", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.x3bid = this.AddSubPart(ref tsubpart21, 440, 459, 100, 20, 0);
          this.ss = "Set Subpart";
          tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.x4id = this.AddSubPart(ref tsubpart21, 570, 460, 32, 16, 1);
          tsubpart21 = (SubPartClass) new TextPartClass("Set Subpart", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.x4bid = this.AddSubPart(ref tsubpart21, 600, 459, 100, 20, 0);
        }
        if (!this.game.Data.HistoricalUnitObj[this.detailnr].Model)
        {
          this.ss = "Set this Unit to a specific Model";
          tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.x5id = this.AddSubPart(ref tsubpart21, 10, 400, 32, 16, 1);
          if (this.game.Data.HistoricalUnitObj[this.detailnr].ModelMaster > -1)
          {
            tsubpart21 = (SubPartClass) new TextPartClass("His.Units Model: " + this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[this.detailnr].ModelMaster].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
            this.x5bid = this.AddSubPart(ref tsubpart21, 50, 399, 300, 20, 0);
          }
          else
          {
            tsubpart21 = (SubPartClass) new TextPartClass("His.Units Model: Not set!", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
            this.x5bid = this.AddSubPart(ref tsubpart21, 50, 399, 300, 20, 0);
          }
        }
        this.VarListObj = new ListClass();
        int hisVarCount = this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount;
        for (int tdata = 0; tdata <= hisVarCount; ++tdata)
        {
          string tname;
          if (this.game.Data.HistoricalUnitObj[this.detailnr].HisVarSmall[tdata] > -1)
            tname = "Type " + this.game.Data.HistoricalUnitObj[this.detailnr].HisVarType[tdata].ToString() + " = " + this.game.Data.HistoricalUnitObj[this.detailnr].HisVarValue[tdata].ToString() + " (smallgfx" + this.game.Data.HistoricalUnitObj[this.detailnr].HisVarSmall[tdata].ToString() + ")";
          else
            tname = "Type " + this.game.Data.HistoricalUnitObj[this.detailnr].HisVarType[tdata].ToString() + " = " + this.game.Data.HistoricalUnitObj[this.detailnr].HisVarValue[tdata].ToString() + " (nato" + this.game.Data.HistoricalUnitObj[this.detailnr].HisVarNato[tdata].ToString() + ")";
          this.VarListObj.add(tname, tdata);
        }
        ListClass varListObj = this.VarListObj;
        int detailnr6 = this.detailnr6;
        GameClass game2 = this.game;
        Bitmap bitmap2 = (Bitmap) null;
        ref Bitmap local3 = ref bitmap2;
        Font font2 = (Font) null;
        ref Font local4 = ref font2;
        tsubpart21 = (SubPartClass) new ListSubPartClass(varListObj, 3, 300, detailnr6, game2, tHeader: "HisVar List", tbackbitmap: (ref local3), overruleFont: (ref local4));
        this.VarListId = this.AddSubPart(ref tsubpart21, 50, 504, 300, 80, 0);
        this.ss = "Add hisvar type+value";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.v19id = this.AddSubPart(ref tsubpart21, 50, 592, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("Add", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 60, 20, false, tDescript: this.ss);
        this.v19bid = this.AddSubPart(ref tsubpart21, 90, 591, 60, 20, 0);
        if (this.detailnr6 > -1)
        {
          this.ss = "Remove this hisvar type + value";
          tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
          this.v20id = this.AddSubPart(ref tsubpart21, 190, 592, 32, 16, 1);
          tsubpart21 = (SubPartClass) new TextPartClass("Remove", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 100, 20, false, tDescript: this.ss);
          this.v20bid = this.AddSubPart(ref tsubpart21, 230, 591, 100, 20, 0);
          this.ss = "Change hisvar Type + Value";
          tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.v21id = this.AddSubPart(ref tsubpart21, 50, 612, 32, 16, 1);
          tsubpart21 = (SubPartClass) new TextPartClass("Change all", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 120, 20, false, tDescript: this.ss);
          this.v21bid = this.AddSubPart(ref tsubpart21, 90, 611, 120, 20, 0);
          this.ss = "Change only value";
          tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.v22id = this.AddSubPart(ref tsubpart21, 190, 612, 32, 16, 1);
          tsubpart21 = (SubPartClass) new TextPartClass("Change val", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 100, 20, false, tDescript: this.ss);
          this.v22bid = this.AddSubPart(ref tsubpart21, 230, 611, 100, 20, 0);
          this.ss = "Copy stats from different historical unit";
          tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
          this.v23id = this.AddSubPart(ref tsubpart21, 50, 632, 32, 16, 1);
          tsubpart21 = (SubPartClass) new TextPartClass("Copy", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 100, 20, false, tDescript: this.ss);
          this.v23bid = this.AddSubPart(ref tsubpart21, 90, 631, 100, 20, 0);
        }
        this.ss = "Click to change the political cost of the commander or of the Unit";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a26id = this.AddSubPart(ref tsubpart21, 410, 500, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("PP = " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].PP), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a26bid = this.AddSubPart(ref tsubpart21, 450, 499, 100, 20, 0);
        this.ss = "Click to set the combatmod of the general (0=none, -100 - +999)";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a27id = this.AddSubPart(ref tsubpart21, 570, 500, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("CombatMod = " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].CombatMod), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.a27bid = this.AddSubPart(ref tsubpart21, 600, 499, 200, 20, 0);
        this.ss = "Click to set the moralemod of the general (0=none, -100 - +999)";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a28id = this.AddSubPart(ref tsubpart21, 410, 520, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("MorMod = " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].MoraleMod), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a28bid = this.AddSubPart(ref tsubpart21, 450, 519, 100, 20, 0);
        this.ss = "Click to set the staff pts size the general can maximum command and apply its combat and morale mods too (0=none - 99999)";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a29id = this.AddSubPart(ref tsubpart21, 570, 520, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("Staff= " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].StaffSize), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a29bid = this.AddSubPart(ref tsubpart21, 600, 519, 100, 20, 0);
        this.ss = "Click to set the all Historical Units with Model specified exactly as their Models";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
        this.a30id = this.AddSubPart(ref tsubpart21, 830, 240, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("Set ALL to their MODEL ", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a30bid = this.AddSubPart(ref tsubpart21, 860, 239, 300, 20, 0);
        this.ss = "Click to set the this hist.unit to Fixed";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a31id = this.AddSubPart(ref tsubpart21, 410, 560, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("Fixed =" + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].Fixed), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a31bid = this.AddSubPart(ref tsubpart21, 450, 560, 100, 20, 0);
        this.ss = "Click to set the name Counter of this model to that of another model or historical unit.";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a320id = this.AddSubPart(ref tsubpart21, 570, 540, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("UseModelCounter= " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].UseModelCounter), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a320bid = this.AddSubPart(ref tsubpart21, 600, 540, 200, 20, 0);
        this.ss = "Click to set the numeric name counter, chance to use an older number not used at moment, +if to use romans or not";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a32id = this.AddSubPart(ref tsubpart21, 570, 560, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("Counter= " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].NameCounter) + " O= " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].PercentOldName) + "%, R=" + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].UseRomans), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a32bid = this.AddSubPart(ref tsubpart21, 600, 560, 200, 20, 0);
        this.ss = "Click to set tempvar1";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a34id = this.AddSubPart(ref tsubpart21, 410, 580, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("tv1 = " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].TempVar1), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a34bid = this.AddSubPart(ref tsubpart21, 450, 579, 100, 20, 0);
        this.ss = "Click to set tempvar2";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a35id = this.AddSubPart(ref tsubpart21, 570, 580, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("tv2 = " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].TempVar2), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a35bid = this.AddSubPart(ref tsubpart21, 600, 579, 100, 20, 0);
        this.ss = "Click to set tempvar3";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a36id = this.AddSubPart(ref tsubpart21, 410, 600, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("tv3 = " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].TempVar3), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a36bid = this.AddSubPart(ref tsubpart21, 450, 599, 100, 20, 0);
        this.ss = "Click to set the numeric name counter";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a37id = this.AddSubPart(ref tsubpart21, 570, 600, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("XP = " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].Xp), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a37bid = this.AddSubPart(ref tsubpart21, 600, 599, 100, 20, 0);
        this.ss = "Click to set description";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a38id = this.AddSubPart(ref tsubpart21, 410, 480, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("Descr=" + this.game.Data.HistoricalUnitObj[this.detailnr].Descript, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 100, 20, false, tDescript: this.ss);
        this.a38bid = this.AddSubPart(ref tsubpart21, 450, 480, 100, 20, 0);
        this.ss = "Click to set officer to pool - make sure it is not a historical unit assigned to an actual unit!";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.apoolid = this.AddSubPart(ref tsubpart21, 570, 480, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("Pool=" + this.game.Data.HistoricalUnitObj[this.detailnr].Pool.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
        this.apoolbid = this.AddSubPart(ref tsubpart21, 600, 480, 150, 20, 0);
        this.ss = "Click to set tempvar4";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a42id = this.AddSubPart(ref tsubpart21, 410, 620, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("tv4 = " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].TempVar4), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a42bid = this.AddSubPart(ref tsubpart21, 450, 619, 100, 20, 0);
        this.ss = "Click to set tempvar5";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a43id = this.AddSubPart(ref tsubpart21, 570, 620, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("tv5 = " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].TempVar5), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a43bid = this.AddSubPart(ref tsubpart21, 600, 619, 100, 20, 0);
        this.ss = "Click to set Battlegroup flag.. 0=no, 1=yes";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a45id = this.AddSubPart(ref tsubpart21, 570, 640, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("Battlegroup = " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].BattleGroup), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a45bid = this.AddSubPart(ref tsubpart21, 600, 639, 100, 20, 0);
        if (this.game.Data.HistoricalUnitObj[this.detailnr].LibId.libSlot > -1)
        {
          tsubpart21 = (SubPartClass) new TextPartClass("Lib.Slot: " + this.game.Data.HistoricalUnitObj[this.detailnr].LibId.libSlot.ToString() + ",ID: " + this.game.Data.HistoricalUnitObj[this.detailnr].LibId.id.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 410, 660, false, tDescript: this.ss);
          this.a40bid = this.AddSubPart(ref tsubpart21, 410, 659, 350, 20, 0);
        }
        this.ss = "Set name of commander. No name means no commander.";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a17id = this.AddSubPart(ref tsubpart21, 830, 265, 32, 16, 1);
        if (Operators.CompareString(this.game.Data.HistoricalUnitObj[this.detailnr].CommanderName, "", false) == 0)
        {
          tsubpart21 = (SubPartClass) new TextPartClass("- No Commander -", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.a17bid = this.AddSubPart(ref tsubpart21, 880, 264, 300, 20, 0);
        }
        else
        {
          tsubpart21 = (SubPartClass) new TextPartClass(this.game.Data.HistoricalUnitObj[this.detailnr].CommanderName, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.a17bid = this.AddSubPart(ref tsubpart21, 880, 264, 300, 20, 0);
        }
        this.ss = "Set sprite for commander. No filename means no sprite..";
        if (Operators.CompareString(this.game.Data.HistoricalUnitObj[this.detailnr].CommanderFileName, "", false) == 0)
        {
          tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.a18id = this.AddSubPart(ref tsubpart21, 830, 285, 32, 16, 1);
          tsubpart21 = (SubPartClass) new TextPartClass("- No Sprite -", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.a18bid = this.AddSubPart(ref tsubpart21, 880, 284, 300, 20, 0);
        }
        else
        {
          tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.Data.HistoricalUnitObj[this.detailnr].CommanderSpriteID, tDescript: this.ss, tResizeX: 32, tresizeY: 32);
          this.a18id = this.AddSubPart(ref tsubpart21, 830, 285, 32, 32, 1);
          tsubpart21 = (SubPartClass) new TextPartClass(this.game.Data.HistoricalUnitObj[this.detailnr].CommanderFileName, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.a18bid = this.AddSubPart(ref tsubpart21, 880, 284, 300, 20, 0);
        }
        this.ss = "Set sprite for commander. No filename means no sprite..";
        if (Operators.CompareString(this.game.Data.HistoricalUnitObj[this.detailnr].OverdrawFileName, "", false) == 0)
        {
          tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.a33id = this.AddSubPart(ref tsubpart21, 830, 325, 32, 16, 1);
          tsubpart21 = (SubPartClass) new TextPartClass("- No Sprite -", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.a33bid = this.AddSubPart(ref tsubpart21, 880, 324, 300, 20, 0);
        }
        else
        {
          tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.Data.HistoricalUnitObj[this.detailnr].OverdrawSpriteID, tDescript: this.ss, tResizeX: 32, tresizeY: 32);
          this.a33id = this.AddSubPart(ref tsubpart21, 830, 325, 32, 32, 1);
          tsubpart21 = (SubPartClass) new TextPartClass(this.game.Data.HistoricalUnitObj[this.detailnr].OverdrawFileName, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.a33bid = this.AddSubPart(ref tsubpart21, 880, 324, 300, 20, 0);
        }
        this.deckListObj = new ListClass();
        int deckCardCounter = this.game.Data.HistoricalUnitObj[this.detailnr].DeckCardCounter;
        for (int tdata = 0; tdata <= deckCardCounter; ++tdata)
          this.deckListObj.add(Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].DeckChance[tdata])) + "% on " + this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[this.detailnr].DeckCard[tdata]].Title + " (#" + Conversion.Str((object) this.game.Data.HistoricalUnitObj[this.detailnr].DeckCard[tdata]) + ")", tdata);
        ListClass deckListObj = this.deckListObj;
        int twidth = Math.Min(300, this.game.ScreenWidth - 830);
        int detailnr4 = this.detailnr4;
        GameClass game3 = this.game;
        Bitmap bitmap3 = (Bitmap) null;
        ref Bitmap local5 = ref bitmap3;
        Font font3 = (Font) null;
        ref Font local6 = ref font3;
        tsubpart21 = (SubPartClass) new ListSubPartClass(deckListObj, 4, twidth, detailnr4, game3, tHeader: "Actioncard List", tbackbitmap: (ref local5), overruleFont: (ref local6));
        this.DeckListId = this.AddSubPart(ref tsubpart21, 830, 515, Math.Min(300, this.game.ScreenWidth - 830), 96, 0);
        this.ss = "Add Card";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.a22id = this.AddSubPart(ref tsubpart21, 830, 615, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("Add", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a22bid = this.AddSubPart(ref tsubpart21, 880, 614, 60, 20, 0);
        this.ss = "Copy Cards From";
        tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
        this.a221id = this.AddSubPart(ref tsubpart21, 930, 635, 32, 16, 1);
        tsubpart21 = (SubPartClass) new TextPartClass("Copy", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a221bid = this.AddSubPart(ref tsubpart21, 960, 634, 60, 20, 0);
        if (this.detailnr4 > -1)
        {
          this.ss = "Remove Card";
          tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
          this.a23id = this.AddSubPart(ref tsubpart21, 930, 615, 32, 16, 1);
          tsubpart21 = (SubPartClass) new TextPartClass("Remove", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.a23bid = this.AddSubPart(ref tsubpart21, 960, 614, 300, 20, 0);
          this.ss = "Set Chance %";
          tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.a24id = this.AddSubPart(ref tsubpart21, 830, 635, 32, 16, 1);
          tsubpart21 = (SubPartClass) new TextPartClass("Set%", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.a24bid = this.AddSubPart(ref tsubpart21, 880, 634, 300, 20, 0);
        }
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
                this.libnr = num2;
                this.detailnr = -1;
                this.detailnr3 = -1;
                this.detailnr4 = -1;
                this.showinfo();
              }
              else if (num2 == -2)
              {
                this.libnr = -1;
                this.detailnr = -1;
                this.detailnr3 = -1;
                this.detailnr4 = -1;
                this.showinfo();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.expid)
            {
              StreamWriter text = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_hisunits_nato.txt");
              int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
              for (int index2 = 0; index2 <= historicalUnitCounter; ++index2)
              {
                text.Write(Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[index2].Counter)) + "," + this.game.Data.HistoricalUnitObj[index2].Name);
                text.Write("\r\n");
              }
              text.Close();
              int num3 = (int) Interaction.MsgBox((object) "Export completed correctly", Title: ((object) "Shadow Empire : Planetary Conquest"));
            }
            else if (num1 == this.impid)
            {
              try
              {
                StreamReader streamReader = File.OpenText(this.game.AppPath + "logs/" + this.game.Data.Name + "_hisunits_nato.txt");
                int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
                for (int Number = 0; Number <= historicalUnitCounter; ++Number)
                {
                  try
                  {
                    string str = streamReader.ReadLine();
                    int num4 = Strings.InStr(str, ",") <= 0 ? (int) Math.Round(Conversion.Val(str)) : (int) Math.Round(Conversion.Val(Strings.Left(str, Strings.InStr(str, ","))));
                    this.game.Data.HistoricalUnitObj[Number].Counter = num4;
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    int num5 = (int) Interaction.MsgBox((object) ("Error in line " + Conversion.Str((object) Number)), Title: ((object) "Shadow Empire : Planetary Conquest"));
                    ProjectData.ClearProjectError();
                    break;
                  }
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                int num6 = (int) Interaction.MsgBox((object) "Couldnt find file. make export first.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                ProjectData.ClearProjectError();
              }
              int num7 = (int) Interaction.MsgBox((object) "Import completed correctly", Title: ((object) "Shadow Empire : Planetary Conquest"));
            }
            else
            {
              if (num1 == this.HisListId)
              {
                int num8 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num8 > -1)
                {
                  this.detailnr = num8;
                  this.detailnr3 = -1;
                  this.detailnr4 = -1;
                  this.showinfo();
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.DeckListId)
              {
                int num9 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num9 > -1)
                {
                  this.detailnr4 = num9;
                  this.showinfo();
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.VarListId)
              {
                int num10 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num10 > -1)
                {
                  this.detailnr6 = num10;
                  this.showinfo();
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.SPListId)
              {
                int num11 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num11 > -1)
                {
                  this.detailnr5 = num11;
                  this.showinfo();
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.AutoListId)
              {
                int num12 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num12 > -1)
                {
                  this.detailnr3 = num12;
                  this.showinfo();
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.DescBox)
              {
                this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BRemoveHisId)
              {
                this.game.Data.RemoveHistoricalUnit(this.detailnr);
                this.MakeHisList();
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BAddHisId)
              {
                this.game.Data.AddHistoricalUnit();
                this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].Name = Interaction.InputBox("Give name for historical unit", "Shadow Empire : Planetary Conquest");
                this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].TempRegime = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give regime# for historical unit", "Shadow Empire : Planetary Conquest")));
                this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].LibId.libSlot = this.libnr;
                this.detailnr = this.game.Data.HistoricalUnitCounter;
                this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].Type = 1;
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a16id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 15, this.detailnr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.x1id)
              {
                this.game.Data.HistoricalUnitObj[this.detailnr].Model = !this.game.Data.HistoricalUnitObj[this.detailnr].Model;
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.x2id)
              {
                int num13 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give red.. (-255 to +255)", "Shadow Empire : Planetary Conquest")));
                if (num13 >= -255 & num13 <= (int) byte.MaxValue)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].Red = num13;
                  this.showinfo();
                }
                else
                {
                  int num14 = (int) Interaction.MsgBox((object) "wrong input");
                }
                int num15 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give green.. (-255 to +255)", "Shadow Empire : Planetary Conquest")));
                if (num15 >= -255 & num15 <= (int) byte.MaxValue)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].Green = num15;
                  this.showinfo();
                }
                else
                {
                  int num16 = (int) Interaction.MsgBox((object) "wrong input");
                }
                int num17 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give blue.. (-255 to +255)", "Shadow Empire : Planetary Conquest")));
                if (num17 >= -255 & num17 <= (int) byte.MaxValue)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].Blue = num17;
                  this.showinfo();
                }
                else
                {
                  int num18 = (int) Interaction.MsgBox((object) "wrong input");
                }
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.x3id)
              {
                this.game.Data.HistoricalUnitObj[this.detailnr].SubParts[this.detailnr5] = -1;
                this.game.Data.HistoricalUnitObj[this.detailnr].Designation[this.detailnr5] = -1;
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.x4id)
              {
                int num19 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give slot designation for Small Graphics, overrule counter.. -1=no small counter, use nato instead", "Shadow Empire : Planetary Conquest")));
                if (num19 < 0 | num19 > this.game.Data.SmallPicCounter)
                {
                  num19 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give nato counter number", "Shadow Empire : Planetary Conquest")));
                  this.game.Data.HistoricalUnitObj[this.detailnr].Designation[this.detailnr5] = num19;
                  this.game.Data.HistoricalUnitObj[this.detailnr].DesignationSmall[this.detailnr5] = -1;
                }
                else
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].DesignationSmall[this.detailnr5] = num19;
                  this.game.Data.HistoricalUnitObj[this.detailnr].Designation[this.detailnr5] = -1;
                }
                if (num19 >= -1)
                {
                  new Form3((Form) this.formref).Initialize(this.game.Data, 45, this.detailnr, this.detailnr5);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                int num20 = (int) Interaction.MsgBox((object) "wrong input");
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.x5id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 46, this.detailnr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.aa11id)
              {
                int num21 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give NATO counter #", "Shadow Empire : Planetary Conquest")));
                if (num21 != 0 & num21 >= -1 & num21 <= this.game.NATO.GetUpperBound(0))
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].Counter = num21;
                }
                else
                {
                  int num22 = (int) Interaction.MsgBox((object) "Invalid NATO counter value. Either -1, 1-X");
                }
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.ab11id)
              {
                int num23 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Small Graphic slot", "Shadow Empire : Planetary Conquest")));
                if (num23 >= -1 & num23 <= this.game.Data.SmallPicCounter)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].SmallGfx = num23;
                }
                else
                {
                  int num24 = (int) Interaction.MsgBox((object) "Invalid NATO counter value. Either -1, 1-X");
                }
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a41id)
              {
                int num25 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give MaxPresent", "Shadow Empire : Planetary Conquest")));
                if (num25 >= -1 & num25 <= 99999)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].MaxPresent = num25;
                }
                else
                {
                  int num26 = (int) Interaction.MsgBox((object) "Invalid NATO counter value. Either -1, 1-X");
                }
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a11id)
              {
                this.game.Data.HistoricalUnitObj[this.detailnr].CounterString = Interaction.InputBox("Give Short Name", "Shadow Empire : Planetary Conquest");
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a25id)
              {
                this.game.Data.HistoricalUnitObj[this.detailnr].Name = Interaction.InputBox("Give Name (also sets units names assigned to this historical unit)", "Shadow Empire : Planetary Conquest");
                int unitCounter = this.game.Data.UnitCounter;
                for (int index3 = 0; index3 <= unitCounter; ++index3)
                {
                  if (this.game.Data.UnitObj[index3].Historical == this.detailnr)
                    this.game.Data.UnitObj[index3].Name = this.game.Data.HistoricalUnitObj[this.detailnr].Name;
                }
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a15id)
              {
                this.SortHis();
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a17id)
              {
                this.game.Data.HistoricalUnitObj[this.detailnr].CommanderName = Interaction.InputBox("Give Commander Name", "Shadow Empire : Planetary Conquest");
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.v19id)
              {
                int num27 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give type number", "Shadow Empire : Planetary Conquest")));
                int num28 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give value", "Shadow Empire : Planetary Conquest")));
                int num29 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give small gfx counter graphic #", "Shadow Empire : Planetary Conquest")));
                int num30 = -1;
                if (num29 < 0)
                  num30 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give nato counter graphic #", "Shadow Empire : Planetary Conquest")));
                HistoricalUnitClass[] historicalUnitObj = this.game.Data.HistoricalUnitObj;
                HistoricalUnitClass[] historicalUnitClassArray = historicalUnitObj;
                int detailnr = this.detailnr;
                int index4 = detailnr;
                historicalUnitClassArray[index4].HisVarCount = historicalUnitObj[detailnr].HisVarCount + 1;
                this.game.Data.HistoricalUnitObj[this.detailnr].HisVarType = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[this.detailnr].HisVarType, (Array) new int[this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount + 1]);
                this.game.Data.HistoricalUnitObj[this.detailnr].HisVarValue = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[this.detailnr].HisVarValue, (Array) new int[this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount + 1]);
                this.game.Data.HistoricalUnitObj[this.detailnr].HisVarNato = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[this.detailnr].HisVarNato, (Array) new int[this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount + 1]);
                this.game.Data.HistoricalUnitObj[this.detailnr].HisVarSmall = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[this.detailnr].HisVarSmall, (Array) new int[this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount + 1]);
                this.game.Data.HistoricalUnitObj[this.detailnr].HisVarType[this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount] = num27;
                this.game.Data.HistoricalUnitObj[this.detailnr].HisVarValue[this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount] = num28;
                this.game.Data.HistoricalUnitObj[this.detailnr].HisVarNato[this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount] = num30;
                this.game.Data.HistoricalUnitObj[this.detailnr].HisVarSmall[this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount] = num29;
                this.detailnr6 = this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount;
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.v20id)
              {
                if (this.detailnr6 < this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount)
                {
                  int detailnr6 = this.detailnr6;
                  int num31 = this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount - 1;
                  for (int index5 = detailnr6; index5 <= num31; ++index5)
                  {
                    this.game.Data.HistoricalUnitObj[this.detailnr].HisVarType[index5] = this.game.Data.HistoricalUnitObj[this.detailnr].HisVarType[index5 + 1];
                    this.game.Data.HistoricalUnitObj[this.detailnr].HisVarValue[index5] = this.game.Data.HistoricalUnitObj[this.detailnr].HisVarValue[index5 + 1];
                    this.game.Data.HistoricalUnitObj[this.detailnr].HisVarNato[index5] = this.game.Data.HistoricalUnitObj[this.detailnr].HisVarNato[index5 + 1];
                    this.game.Data.HistoricalUnitObj[this.detailnr].HisVarSmall[index5] = this.game.Data.HistoricalUnitObj[this.detailnr].HisVarSmall[index5 + 1];
                  }
                }
                --this.detailnr6;
                HistoricalUnitClass[] historicalUnitObj = this.game.Data.HistoricalUnitObj;
                HistoricalUnitClass[] historicalUnitClassArray = historicalUnitObj;
                int detailnr = this.detailnr;
                int index6 = detailnr;
                historicalUnitClassArray[index6].HisVarCount = historicalUnitObj[detailnr].HisVarCount - 1;
                if (this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount > -1 & this.detailnr6 == -1)
                  this.detailnr6 = 0;
                if (this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount > -1)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].HisVarType = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[this.detailnr].HisVarType, (Array) new int[this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount + 1]);
                  this.game.Data.HistoricalUnitObj[this.detailnr].HisVarValue = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[this.detailnr].HisVarValue, (Array) new int[this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount + 1]);
                  this.game.Data.HistoricalUnitObj[this.detailnr].HisVarNato = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[this.detailnr].HisVarNato, (Array) new int[this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount + 1]);
                  this.game.Data.HistoricalUnitObj[this.detailnr].HisVarSmall = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[this.detailnr].HisVarSmall, (Array) new int[this.game.Data.HistoricalUnitObj[this.detailnr].HisVarCount + 1]);
                }
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.v21id)
              {
                int num32 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give type number", "Shadow Empire : Planetary Conquest")));
                int num33 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give value", "Shadow Empire : Planetary Conquest")));
                int num34 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give small gfx counter graphic #", "Shadow Empire : Planetary Conquest")));
                int num35 = -1;
                if (num34 < 0)
                  num35 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give nato counter graphic #", "Shadow Empire : Planetary Conquest")));
                this.game.Data.HistoricalUnitObj[this.detailnr].HisVarType[this.detailnr6] = num32;
                this.game.Data.HistoricalUnitObj[this.detailnr].HisVarValue[this.detailnr6] = num33;
                this.game.Data.HistoricalUnitObj[this.detailnr].HisVarNato[this.detailnr6] = num34;
                this.game.Data.HistoricalUnitObj[this.detailnr].HisVarSmall[this.detailnr6] = num34;
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.v22id)
              {
                this.game.Data.HistoricalUnitObj[this.detailnr].HisVarValue[this.detailnr6] = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give value", "Shadow Empire : Planetary Conquest")));
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a20id)
              {
                if (this.detailnr3 < this.game.Data.HistoricalUnitObj[this.detailnr].AutoEventCounter)
                {
                  int detailnr3 = this.detailnr3;
                  int num36 = this.game.Data.HistoricalUnitObj[this.detailnr].AutoEventCounter - 1;
                  for (int index7 = detailnr3; index7 <= num36; ++index7)
                  {
                    this.game.Data.HistoricalUnitObj[this.detailnr].AutoEvent[index7] = this.game.Data.HistoricalUnitObj[this.detailnr].AutoEvent[index7 + 1];
                    this.game.Data.HistoricalUnitObj[this.detailnr].AutoChance[index7] = this.game.Data.HistoricalUnitObj[this.detailnr].AutoChance[index7 + 1];
                  }
                }
                --this.detailnr3;
                HistoricalUnitClass[] historicalUnitObj = this.game.Data.HistoricalUnitObj;
                HistoricalUnitClass[] historicalUnitClassArray = historicalUnitObj;
                int detailnr = this.detailnr;
                int index8 = detailnr;
                historicalUnitClassArray[index8].AutoEventCounter = historicalUnitObj[detailnr].AutoEventCounter - 1;
                if (this.game.Data.HistoricalUnitObj[this.detailnr].AutoEventCounter > -1 & this.detailnr3 == -1)
                  this.detailnr3 = 0;
                if (this.game.Data.HistoricalUnitObj[this.detailnr].AutoEventCounter > -1)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].AutoEvent = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[this.detailnr].AutoEvent, (Array) new int[this.game.Data.HistoricalUnitObj[this.detailnr].AutoEventCounter + 1]);
                  this.game.Data.HistoricalUnitObj[this.detailnr].AutoChance = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[this.detailnr].AutoChance, (Array) new int[this.game.Data.HistoricalUnitObj[this.detailnr].AutoEventCounter + 1]);
                }
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a23id)
              {
                if (this.detailnr4 < this.game.Data.HistoricalUnitObj[this.detailnr].DeckCardCounter)
                {
                  int detailnr4 = this.detailnr4;
                  int num37 = this.game.Data.HistoricalUnitObj[this.detailnr].DeckCardCounter - 1;
                  for (int index9 = detailnr4; index9 <= num37; ++index9)
                  {
                    this.game.Data.HistoricalUnitObj[this.detailnr].DeckCard[index9] = this.game.Data.HistoricalUnitObj[this.detailnr].DeckCard[index9 + 1];
                    this.game.Data.HistoricalUnitObj[this.detailnr].DeckChance[index9] = this.game.Data.HistoricalUnitObj[this.detailnr].DeckChance[index9 + 1];
                  }
                }
                --this.detailnr4;
                HistoricalUnitClass[] historicalUnitObj = this.game.Data.HistoricalUnitObj;
                HistoricalUnitClass[] historicalUnitClassArray = historicalUnitObj;
                int detailnr = this.detailnr;
                int index10 = detailnr;
                historicalUnitClassArray[index10].DeckCardCounter = historicalUnitObj[detailnr].DeckCardCounter - 1;
                if (this.game.Data.HistoricalUnitObj[this.detailnr].DeckCardCounter > -1 & this.detailnr4 == -1)
                  this.detailnr4 = 0;
                if (this.game.Data.HistoricalUnitObj[this.detailnr].DeckCardCounter > -1)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].DeckCard = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[this.detailnr].DeckCard, (Array) new int[this.game.Data.HistoricalUnitObj[this.detailnr].DeckCardCounter + 1]);
                  this.game.Data.HistoricalUnitObj[this.detailnr].DeckChance = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[this.detailnr].DeckChance, (Array) new int[this.game.Data.HistoricalUnitObj[this.detailnr].DeckCardCounter + 1]);
                }
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a21id)
              {
                int num38 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give chance on event occuring.. (0-100)", "Shadow Empire : Planetary Conquest")));
                if (num38 >= 0 & num38 <= 100)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].AutoChance[this.detailnr3] = num38;
                  this.showinfo();
                }
                else
                {
                  int num39 = (int) Interaction.MsgBox((object) "Between 0-100 plz");
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.asid)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 94, this.detailnr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a24id)
              {
                int num40 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give chance on event occuring.. (0-100)", "Shadow Empire : Planetary Conquest")));
                if (num40 >= 0 & num40 <= 100)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].DeckChance[this.detailnr4] = num40;
                  this.showinfo();
                }
                else
                {
                  int num41 = (int) Interaction.MsgBox((object) "Between 0-100 plz");
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a26id)
              {
                int num42 = (int) Math.Round(Conversion.Val(Interaction.InputBox("PP Cost", "Shadow Empire : Planetary Conquest")));
                if (num42 >= -9999 & num42 <= 9999)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].PP = num42;
                  this.showinfo();
                }
                else
                {
                  int num43 = (int) Interaction.MsgBox((object) "Between 0-9999 plz");
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a440id)
              {
                int num44 = (int) Math.Round(Conversion.Val(Interaction.InputBox("AI Zone List Nr #", "Shadow Empire : Planetary Conquest")));
                if (num44 >= 0 & num44 <= 9999)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].AIlist = num44;
                  this.showinfo();
                }
                else
                {
                  int num45 = (int) Interaction.MsgBox((object) "Between 0-9999 plz");
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a39id)
              {
                this.game.Data.HistoricalUnitObj[this.detailnr].NoSplit = !this.game.Data.HistoricalUnitObj[this.detailnr].NoSplit;
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.apoolid)
              {
                this.game.Data.HistoricalUnitObj[this.detailnr].Pool = !this.game.Data.HistoricalUnitObj[this.detailnr].Pool;
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a27id)
              {
                int num46 = (int) Math.Round(Conversion.Val(Interaction.InputBox("CombatMod", "Shadow Empire : Planetary Conquest")));
                if (num46 >= -100 & num46 <= 9999)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].CombatMod = num46;
                  this.showinfo();
                }
                else
                {
                  int num47 = (int) Interaction.MsgBox((object) "Between -100 and 9999 plz");
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a28id)
              {
                int num48 = (int) Math.Round(Conversion.Val(Interaction.InputBox("MoraleMod", "Shadow Empire : Planetary Conquest")));
                if (num48 >= -100 & num48 <= 9999)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].MoraleMod = num48;
                  this.showinfo();
                }
                else
                {
                  int num49 = (int) Interaction.MsgBox((object) "Between -100 and 9999 plz");
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a29id)
              {
                int num50 = (int) Math.Round(Conversion.Val(Interaction.InputBox("StaffSize", "Shadow Empire : Planetary Conquest")));
                if (num50 >= 0 & num50 <= 99999)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].StaffSize = num50;
                  this.showinfo();
                }
                else
                {
                  int num51 = (int) Interaction.MsgBox((object) "Between -100 and 9999 plz");
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a31id)
              {
                this.game.Data.HistoricalUnitObj[this.detailnr].Fixed = !this.game.Data.HistoricalUnitObj[this.detailnr].Fixed;
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a32id)
              {
                int num52 = (int) Math.Round(Conversion.Val(Interaction.InputBox("NameCounter (-1=for not use)", "Shadow Empire : Planetary Conquest")));
                if (num52 >= -1 & num52 <= 99999)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].NameCounter = num52;
                  this.showinfo();
                }
                else
                {
                  int num53 = (int) Interaction.MsgBox((object) "Between 0 and 99999 plz");
                }
                int num54 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Chance on Old number currently not used in % (0=for not use)", "Shadow Empire : Planetary Conquest")));
                if (num54 >= 0 & num54 <= 100)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].PercentOldName = num54;
                  this.showinfo();
                }
                else
                {
                  int num55 = (int) Interaction.MsgBox((object) "Between 0 and 100 plz");
                }
                if ((int) Math.Round(Conversion.Val(Interaction.InputBox("0=use no romans, 1=use romans", "Shadow Empire : Planetary Conquest"))) == 1)
                  this.game.Data.HistoricalUnitObj[this.detailnr].UseRomans = true;
                else
                  this.game.Data.HistoricalUnitObj[this.detailnr].UseRomans = false;
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a34id)
              {
                int num56 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Tempvar", "Shadow Empire : Planetary Conquest")));
                if (num56 >= -99999 & num56 <= 99999)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].TempVar1 = num56;
                  this.showinfo();
                }
                else
                {
                  int num57 = (int) Interaction.MsgBox((object) "Between -99999 and 99999 plz");
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a42id)
              {
                int num58 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Tempvar4", "Shadow Empire : Planetary Conquest")));
                if (num58 >= -99999 & num58 <= 99999)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].TempVar4 = num58;
                  this.showinfo();
                }
                else
                {
                  int num59 = (int) Interaction.MsgBox((object) "Between -99999 and 99999 plz");
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a43id)
              {
                int num60 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Tempvar5", "Shadow Empire : Planetary Conquest")));
                if (num60 >= -99999 & num60 <= 99999)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].TempVar5 = num60;
                  this.showinfo();
                }
                else
                {
                  int num61 = (int) Interaction.MsgBox((object) "Between -99999 and 99999 plz");
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a45id)
              {
                int num62 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Battlegroup flag (0=no,1=yes): ", "Shadow Empire : Planetary Conquest")));
                if (num62 >= 0 & num62 <= 1)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].BattleGroup = num62;
                  this.showinfo();
                }
                else
                {
                  int num63 = (int) Interaction.MsgBox((object) "Either 0 or 1 as value plz.");
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a35id)
              {
                int num64 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Tempvar", "Shadow Empire : Planetary Conquest")));
                if (num64 >= -99999 & num64 <= 99999)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].TempVar2 = num64;
                  this.showinfo();
                }
                else
                {
                  int num65 = (int) Interaction.MsgBox((object) "Between -99999 and 99999 plz");
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a36id)
              {
                int num66 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Tempvar", "Shadow Empire : Planetary Conquest")));
                if (num66 >= -99999 & num66 <= 99999)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].TempVar3 = num66;
                  this.showinfo();
                }
                else
                {
                  int num67 = (int) Interaction.MsgBox((object) "Between -99999 and 99999 plz");
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a37id)
              {
                int num68 = (int) Math.Round(Conversion.Val(Interaction.InputBox("XP", "Shadow Empire : Planetary Conquest")));
                if (num68 >= 0 & num68 <= 99999)
                {
                  this.game.Data.HistoricalUnitObj[this.detailnr].Xp = num68;
                  this.showinfo();
                }
                else
                {
                  int num69 = (int) Interaction.MsgBox((object) "Between 0 and 99999 plz");
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a38id)
              {
                new Form2((Form) this.formref).Initialize(this.game.Data, 6, this.detailnr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a30id)
              {
                int num70 = (int) Interaction.MsgBox((object) "Do you want to OVERWRITE all the units equipment with the BASIC MODELS?? .... advice No..", MsgBoxStyle.YesNo);
                int num71 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Overwite how many first tempvars? 0=none, 1=only tv1, 2=tv1+tv2, etc...", "Shadow Empire : Planetary Conquest")));
                int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
                for (int index11 = 0; index11 <= historicalUnitCounter; ++index11)
                {
                  if (this.game.Data.HistoricalUnitObj[index11].ModelMaster > -1)
                  {
                    int modelMaster = this.game.Data.HistoricalUnitObj[index11].ModelMaster;
                    this.game.Data.HistoricalUnitObj[index11].Counter = this.game.Data.HistoricalUnitObj[modelMaster].Counter;
                    this.game.Data.HistoricalUnitObj[index11].Green = this.game.Data.HistoricalUnitObj[modelMaster].Green;
                    this.game.Data.HistoricalUnitObj[index11].Red = this.game.Data.HistoricalUnitObj[modelMaster].Red;
                    this.game.Data.HistoricalUnitObj[index11].SmallGfx = this.game.Data.HistoricalUnitObj[modelMaster].SmallGfx;
                    this.game.Data.HistoricalUnitObj[index11].Blue = this.game.Data.HistoricalUnitObj[modelMaster].Blue;
                    this.game.Data.HistoricalUnitObj[index11].Type = this.game.Data.HistoricalUnitObj[modelMaster].Type;
                    this.game.Data.HistoricalUnitObj[index11].TempRegime = this.game.Data.HistoricalUnitObj[modelMaster].TempRegime;
                    this.game.Data.HistoricalUnitObj[index11].People = this.game.Data.HistoricalUnitObj[modelMaster].People;
                    this.game.Data.HistoricalUnitObj[index11].UsePeopleGfx = this.game.Data.HistoricalUnitObj[modelMaster].UsePeopleGfx;
                    if (num71 >= 1)
                      this.game.Data.HistoricalUnitObj[index11].TempVar1 = this.game.Data.HistoricalUnitObj[modelMaster].TempVar1;
                    if (num71 >= 2)
                      this.game.Data.HistoricalUnitObj[index11].TempVar2 = this.game.Data.HistoricalUnitObj[modelMaster].TempVar2;
                    if (num71 >= 3)
                      this.game.Data.HistoricalUnitObj[index11].TempVar3 = this.game.Data.HistoricalUnitObj[modelMaster].TempVar3;
                    if (num71 >= 4)
                      this.game.Data.HistoricalUnitObj[index11].TempVar4 = this.game.Data.HistoricalUnitObj[modelMaster].TempVar4;
                    if (num71 >= 5)
                      this.game.Data.HistoricalUnitObj[index11].TempVar5 = this.game.Data.HistoricalUnitObj[modelMaster].TempVar5;
                    int unitCounter1 = this.game.Data.UnitCounter;
                    for (int index12 = 0; index12 <= unitCounter1; ++index12)
                    {
                      if (this.game.Data.UnitObj[index12].Historical == index11)
                        this.game.Data.UnitObj[index12].HistoricalSubPart = -1;
                    }
                    int index13 = 0;
                    do
                    {
                      this.game.Data.HistoricalUnitObj[index11].SubParts[index13] = this.game.Data.HistoricalUnitObj[modelMaster].SubParts[index13];
                      this.game.Data.HistoricalUnitObj[index11].Designation[index13] = this.game.Data.HistoricalUnitObj[modelMaster].Designation[index13];
                      this.game.Data.HistoricalUnitObj[index11].DesignationSmall[index13] = this.game.Data.HistoricalUnitObj[modelMaster].DesignationSmall[index13];
                      if (this.game.Data.HistoricalUnitObj[index11].SubParts[index13] > -1)
                      {
                        int unitCounter2 = this.game.Data.UnitCounter;
                        for (int unr = 0; unr <= unitCounter2; ++unr)
                        {
                          if (this.game.Data.UnitObj[unr].Historical == index11 & this.game.Data.UnitObj[unr].HistoricalSubPart == -1)
                          {
                            this.game.Data.UnitObj[unr].HistoricalSubPart = index13;
                            if (num70 == 6)
                            {
                              int hq = this.game.Data.UnitObj[unr].HQ;
                              DrawMod.TGame.HandyFunctionsObj.CopyUnit(unr, DrawMod.TGame.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[index11].SubParts[index13]), false);
                              this.game.Data.UnitObj[unr].HQ = hq;
                              break;
                            }
                            break;
                          }
                        }
                      }
                      ++index13;
                    }
                    while (index13 <= 9);
                  }
                }
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a18id)
              {
                string s = this.game.HandyFunctionsObj.LoadSomething("All|*.*|Png|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of Commander Sprite. Cancel is set to nothing.", this.game.AppPath + "graphics\\", true);
                if (File.Exists(this.game.AppPath + "graphics/" + s))
                  this.game.Data.HistoricalUnitObj[this.detailnr].ReplaceSprite1(s);
                else
                  this.game.Data.HistoricalUnitObj[this.detailnr].ReplaceSprite1("");
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a33id)
              {
                string s2 = this.game.HandyFunctionsObj.LoadSomething("All|*.*|Png|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of Commander Sprite. Cancel is set to nothing.", this.game.AppPath + "graphics\\", true);
                if (File.Exists(this.game.AppPath + "graphics/" + s2))
                  this.game.Data.HistoricalUnitObj[this.detailnr].ReplaceSprite2(s2);
                else
                  this.game.Data.HistoricalUnitObj[this.detailnr].ReplaceSprite2("");
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a12id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 36, this.detailnr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a320id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 84, this.detailnr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.x7id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 83, this.detailnr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.xx7id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 88, this.detailnr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a19id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 39, this.detailnr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a22id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 40, this.detailnr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a221id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 85, this.detailnr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.v23id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 86, this.detailnr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.bDownId)
              {
                if (this.detailnr > -1)
                {
                  if (this.detailnr < this.game.Data.HistoricalUnitCounter)
                  {
                    HistoricalUnitClass historicalUnitClass = this.game.Data.HistoricalUnitObj[this.detailnr + 1].Clone();
                    this.game.Data.HistoricalUnitObj[this.detailnr + 1] = this.game.Data.HistoricalUnitObj[this.detailnr];
                    this.game.Data.HistoricalUnitObj[this.detailnr] = historicalUnitClass;
                    int unitCounter = this.game.Data.UnitCounter;
                    for (int index14 = 0; index14 <= unitCounter; ++index14)
                    {
                      if (this.game.Data.UnitObj[index14].Historical == this.detailnr)
                        this.game.Data.UnitObj[index14].Historical = this.detailnr + 1;
                      else if (this.game.Data.UnitObj[index14].Historical == this.detailnr + 1)
                        this.game.Data.UnitObj[index14].Historical = this.detailnr;
                    }
                    int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
                    for (int index15 = 0; index15 <= historicalUnitCounter; ++index15)
                    {
                      if (this.game.Data.HistoricalUnitObj[index15].ModelMaster == this.detailnr)
                        this.game.Data.HistoricalUnitObj[index15].ModelMaster = this.detailnr + 1;
                      else if (this.game.Data.HistoricalUnitObj[index15].ModelMaster == this.detailnr + 1)
                        this.game.Data.HistoricalUnitObj[index15].ModelMaster = this.detailnr;
                    }
                  }
                  ++this.detailnr;
                }
                this.MakeHisList();
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.bUpId)
              {
                if (this.detailnr > 0)
                {
                  HistoricalUnitClass historicalUnitClass = this.game.Data.HistoricalUnitObj[this.detailnr - 1].Clone();
                  this.game.Data.HistoricalUnitObj[this.detailnr - 1] = this.game.Data.HistoricalUnitObj[this.detailnr];
                  this.game.Data.HistoricalUnitObj[this.detailnr] = historicalUnitClass;
                  int unitCounter = this.game.Data.UnitCounter;
                  for (int index16 = 0; index16 <= unitCounter; ++index16)
                  {
                    if (this.game.Data.UnitObj[index16].Historical == this.detailnr)
                      this.game.Data.UnitObj[index16].Historical = this.detailnr - 1;
                    else if (this.game.Data.UnitObj[index16].Historical == this.detailnr - 1)
                      this.game.Data.UnitObj[index16].Historical = this.detailnr;
                  }
                  int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
                  for (int index17 = 0; index17 <= historicalUnitCounter; ++index17)
                  {
                    if (this.game.Data.HistoricalUnitObj[index17].ModelMaster == this.detailnr)
                      this.game.Data.HistoricalUnitObj[index17].ModelMaster = this.detailnr - 1;
                    else if (this.game.Data.HistoricalUnitObj[index17].ModelMaster == this.detailnr - 1)
                      this.game.Data.HistoricalUnitObj[index17].ModelMaster = this.detailnr;
                  }
                  --this.detailnr;
                }
                this.MakeHisList();
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BNameId)
              {
                this.game.Data.LocObj[this.locNr].Name = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest");
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BPplId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 16, this.locNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BRemoveId)
              {
                this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location = -1;
                this.game.Data.RemoveLoc(this.locNr);
                this.locNr = -1;
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a1id)
              {
                int num72 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New VP for hex 0-99", "Shadow Empire : Planetary Conquest")));
                if (num72 < 0 | num72 > 99)
                {
                  int num73 = (int) Interaction.MsgBox((object) "Oh.. please.. between 0 and 99!", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                  this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].VP = num72;
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a2id)
              {
                this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Name = Interaction.InputBox("Give new Name for hex...", "Shadow Empire : Planetary Conquest");
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a3id)
              {
                this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LabelText1 = Interaction.InputBox("Give new label for top of hex (label1)", "Shadow Empire : Planetary Conquest");
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a4id)
              {
                this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LabelText2 = Interaction.InputBox("Give new label for top of hex (label1)", "Shadow Empire : Planetary Conquest");
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a5id)
              {
                int num74 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Label Type for top of hex (label1)", "Shadow Empire : Planetary Conquest")));
                if (num74 < 0 | num74 > 10)
                {
                  int num75 = (int) Interaction.MsgBox((object) "Oh.. please.. between 0 and 10 (0=dont show, 1-5 = small font, 6-10 = big font)", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                  this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LabelType1 = num74;
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a6id)
              {
                int num76 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Label Type for bottom of hex (label2)", "Shadow Empire : Planetary Conquest")));
                if (num76 < 0 | num76 > 10)
                {
                  int num77 = (int) Interaction.MsgBox((object) "Oh.. please.. between 0 and 10 (0=dont show, 1-5 = small font, 6-10 = big font)", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                  this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LabelType2 = num76;
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a7id)
              {
                this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LabelType2 = 0;
                this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LabelType1 = 0;
                this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LabelText1 = "";
                this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LabelText2 = "";
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a8id)
              {
                string str = Interaction.InputBox("Give new label multiple hexes (starting on this hex)", "Shadow Empire : Planetary Conquest", this.game.HandyFunctionsObj.GetHexName(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected));
                int usetype = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Label Type for top of hex (label1)", "Shadow Empire : Planetary Conquest")));
                if (usetype > 0 & usetype <= 10 && Strings.Len(str) > 0)
                {
                  this.game.HandyFunctionsObj.MakeSpecificAutoLabels(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, usetype, str, true);
                  int num78 = (int) Interaction.MsgBox((object) "Done");
                }
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a13id)
              {
                for (int historicalUnitCounter = this.game.Data.HistoricalUnitCounter; historicalUnitCounter >= 0; historicalUnitCounter += -1)
                  this.game.Data.RemoveHistoricalUnit(historicalUnitCounter);
                this.game.Data.HistoricalIDCounter = 0;
                this.showinfo();
                this.MakeHisList();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a14id)
              {
                this.AutoDetectHistoricals();
                this.showinfo();
                this.MakeHisList();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a9id)
              {
                int index18 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Hex Side (0=top,1=NE, 2=SE, 3=S, 4=SW, 5=NW)", "Shadow Empire : Planetary Conquest")));
                if (index18 >= 0 & index18 <= 5)
                {
                  int num79 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give RoadType", "Shadow Empire : Planetary Conquest")));
                  if (num79 >= -1 & num79 <= this.game.Data.RoadTypeCounter)
                  {
                    this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].RoadType[index18] = num79;
                    int num80 = (int) Interaction.MsgBox((object) "Done");
                  }
                }
                this.showinfo();
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

    public void AutoDetectHistoricals()
    {
      for (int historicalUnitCounter = this.game.Data.HistoricalUnitCounter; historicalUnitCounter >= 0; historicalUnitCounter += -1)
        this.game.Data.RemoveHistoricalUnit(historicalUnitCounter);
      this.game.Data.HistoricalIDCounter = 0;
      int unitCounter = this.game.Data.UnitCounter;
      for (int unr = 0; unr <= unitCounter; ++unr)
      {
        if (this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].X > -1)
        {
          if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y].Regime > -1)
            this.game.Data.UnitObj[unr].Regime = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y].Regime;
          if (this.game.Data.UnitObj[unr].IsHQ)
          {
            this.game.Data.AddHistoricalUnit();
            int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
            this.game.Data.HistoricalUnitObj[historicalUnitCounter].Name = this.game.Data.UnitObj[unr].Name;
            this.game.Data.HistoricalUnitObj[historicalUnitCounter].Type = 5 + this.game.HandyFunctionsObj.HowmanyHQsBelow(unr);
            this.game.Data.HistoricalUnitObj[historicalUnitCounter].Counter = -1;
            this.game.Data.HistoricalUnitObj[historicalUnitCounter].TempRegime = this.game.Data.UnitObj[unr].Regime;
            if (Strings.InStr(this.game.Data.UnitObj[unr].Name, " ") > 0)
              this.game.Data.HistoricalUnitObj[historicalUnitCounter].CounterString = Strings.Left(this.game.Data.UnitObj[unr].Name, Math.Min(6, Strings.InStr(this.game.Data.UnitObj[unr].Name, " ") - 1));
            else
              this.game.Data.HistoricalUnitObj[historicalUnitCounter].CounterString = Strings.Left(this.game.Data.UnitObj[unr].Name, 6);
            this.game.Data.UnitObj[unr].Historical = historicalUnitCounter;
          }
          else
          {
            int index1 = -1;
            int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
            for (int index2 = 0; index2 <= historicalUnitCounter1; ++index2)
            {
              if (Operators.CompareString(Strings.LCase(Strings.Trim(this.game.Data.HistoricalUnitObj[index2].Name)), Strings.LCase(Strings.Trim(this.game.Data.UnitObj[unr].Name)), false) == 0 && this.game.Data.HistoricalUnitObj[index2].TempRegime == this.game.Data.UnitObj[unr].Regime)
              {
                index1 = index2;
                break;
              }
            }
            if (index1 > -1)
            {
              this.game.Data.HistoricalUnitObj[index1].Type = 2;
              this.game.Data.UnitObj[unr].Historical = index1;
            }
            else
            {
              this.game.Data.AddHistoricalUnit();
              int historicalUnitCounter2 = this.game.Data.HistoricalUnitCounter;
              this.game.Data.HistoricalUnitObj[historicalUnitCounter2].TempRegime = this.game.Data.UnitObj[unr].Regime;
              this.game.Data.HistoricalUnitObj[historicalUnitCounter2].Name = this.game.Data.UnitObj[unr].Name;
              this.game.Data.HistoricalUnitObj[historicalUnitCounter2].Type = 1;
              this.game.Data.HistoricalUnitObj[historicalUnitCounter2].Counter = 6;
              this.game.Data.HistoricalUnitObj[historicalUnitCounter2].CounterString = "";
              int length = this.game.Data.UnitObj[unr].Name.Length;
              for (int Start = 1; Start <= length; ++Start)
              {
                int Number = (int) Math.Round(Conversion.Val(Strings.Mid(this.game.Data.UnitObj[unr].Name, Start)));
                if (Number > 0)
                {
                  this.game.Data.HistoricalUnitObj[historicalUnitCounter2].CounterString = Strings.Trim(Conversion.Str((object) Number));
                  break;
                }
              }
              this.game.Data.UnitObj[unr].Historical = historicalUnitCounter2;
            }
          }
        }
      }
      this.SortHis();
    }

    public void SortHis()
    {
      int num1 = 1;
      while (num1 == 1)
      {
        num1 = 0;
        int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
        for (int index1 = 1; index1 <= historicalUnitCounter1; ++index1)
        {
          int num2 = this.game.Data.HistoricalUnitObj[index1 - 1].TempRegime * 100000 + this.game.Data.HistoricalUnitObj[index1 - 1].Type * 1000;
          if (this.game.Data.HistoricalUnitObj[index1 - 1].Model)
            num2 += 50000;
          int num3 = this.game.Data.HistoricalUnitObj[index1].TempRegime * 100000 + this.game.Data.HistoricalUnitObj[index1].Type * 1000;
          if (this.game.Data.HistoricalUnitObj[index1].Model)
            num3 += 50000;
          if (num2 < num3)
          {
            num1 = 1;
            HistoricalUnitClass historicalUnitClass = this.game.Data.HistoricalUnitObj[index1 - 1].Clone();
            this.game.Data.HistoricalUnitObj[index1 - 1] = this.game.Data.HistoricalUnitObj[index1];
            this.game.Data.HistoricalUnitObj[index1] = historicalUnitClass;
            int unitCounter = this.game.Data.UnitCounter;
            for (int index2 = 0; index2 <= unitCounter; ++index2)
            {
              if (this.game.Data.UnitObj[index2].Historical == index1)
                this.game.Data.UnitObj[index2].Historical = index1 - 1;
              else if (this.game.Data.UnitObj[index2].Historical == index1 - 1)
                this.game.Data.UnitObj[index2].Historical = index1;
            }
            int historicalUnitCounter2 = this.game.Data.HistoricalUnitCounter;
            for (int index3 = 0; index3 <= historicalUnitCounter2; ++index3)
            {
              if (this.game.Data.HistoricalUnitObj[index3].ModelMaster == index1)
                this.game.Data.HistoricalUnitObj[index3].ModelMaster = index1 - 1;
              else if (this.game.Data.HistoricalUnitObj[index3].ModelMaster == index1 - 1)
                this.game.Data.HistoricalUnitObj[index3].ModelMaster = index1;
            }
          }
        }
      }
      int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
      for (int index = 0; index <= historicalUnitCounter; ++index)
        this.game.Data.HistoricalUnitObj[index].LoadSprites();
      this.detailnr = -1;
    }
  }
}
