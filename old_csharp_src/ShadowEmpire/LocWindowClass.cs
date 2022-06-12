// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.LocWindowClass
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
  public class LocWindowClass : WindowClass
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
    private int BRemoveAreaId;
    private int BAddAreaId;
    private int BAreaId;
    private int bareatextid;
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
    private int a10id;
    private int a10bid;
    private int a11id;
    private int a11bid;
    private int aa11id;
    private int aa11bid;
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
    private int a22id;
    private int a22bid;
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
    private int HisListId;
    private ListClass HisListObj;
    private int AreaListId;
    private ListClass AreaListObj;
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
    private int detailnr;
    private int detailnr2;
    private int detailnr3;
    private int detailnr4;
    private int detailnr5;
    private int DescBox;
    private string ss;

    public LocWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Hex")
    {
      this.locNr = !(this.game.SelectX > -1 & this.game.SelectY > -1) ? -1 : this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location;
      this.detailnr = -1;
      this.detailnr2 = -1;
      this.detailnr3 = -1;
      this.detailnr4 = -1;
      this.detailnr5 = -1;
      this.MakeAreaList();
      this.showinfo();
    }

    public void MakeAreaList()
    {
      if (this.AreaListId > 0)
        this.RemoveSubPart(this.AreaListId);
      if (this.BAddAreaId > 0)
        this.RemoveSubPart(this.BAddAreaId);
      if (this.BRemoveAreaId > 0)
        this.RemoveSubPart(this.BRemoveAreaId);
      if (this.game.Data.AreaCounter > -1)
      {
        this.AreaListObj = new ListClass();
        int num1 = -1;
        int num2 = -1;
        int areaCounter = this.game.Data.AreaCounter;
        for (int tdata = 0; tdata <= areaCounter; ++tdata)
        {
          ++num2;
          string str = "(" + this.game.Data.AreaObj[tdata].Slot.ToString() + "," + this.game.Data.AreaObj[tdata].Code.ToString() + ")";
          this.AreaListObj.add(Conversion.Str((object) this.game.Data.AreaObj[tdata].ID) + ") " + this.game.Data.AreaObj[tdata].Name + str, tdata);
          if (this.detailnr2 == tdata)
            num1 = num2;
        }
        if (num1 == -1)
          this.detailnr2 = -1;
        ListClass areaListObj = this.AreaListObj;
        int tlistselect = num1;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(areaListObj, 15, 300, tlistselect, game, tHeader: "Areas", tbackbitmap: (ref local1), bbx: 10, bby: 400, overruleFont: (ref local2));
        this.AreaListId = this.AddSubPart(ref tsubpart, 10, 400, 300, 288, 0);
      }
      if (this.BAddAreaId > 0)
        this.RemoveSubPart(this.BAddAreaId);
      this.ss = "Click to add another Area";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.BAddAreaId = this.AddSubPart(ref tsubpart1, 330, 450, 32, 16, 1);
    }

    public override void DoRefresh()
    {
      this.MakeAreaList();
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
      if (this.BRemoveAreaId > 0)
        this.RemoveSubPart(this.BRemoveAreaId);
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
      if (this.BAreaId > 0)
        this.RemoveSubPart(this.BAreaId);
      if (this.bareatextid > 0)
        this.RemoveSubPart(this.bareatextid);
      if (this.DescBox > 0)
        this.RemoveSubPart(this.DescBox);
      if (this.AutoListId > 0)
        this.RemoveSubPart(this.AutoListId);
      if (this.DeckListId > 0)
        this.RemoveSubPart(this.DeckListId);
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
      if (this.a22id > 0)
        this.RemoveSubPart(this.a22id);
      if (this.a22bid > 0)
        this.RemoveSubPart(this.a22bid);
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
      if (this.a32bid > 0)
        this.RemoveSubPart(this.a32bid);
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
      this.MakeAreaList();
      if (this.detailnr2 > -1)
      {
        this.ss = "Remove Area";
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.BRemoveAreaId = this.AddSubPart(ref tsubpart, 330, 490, 32, 16, 1);
      }
      SubPartClass tsubpart1;
      if (this.locNr > -1)
      {
        this.ss = "Click to change the name of the location in this hex";
        SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BNameId = this.AddSubPart(ref tsubpart2, 10, 50, 32, 16, 1);
        tsubpart1 = (SubPartClass) new TextPartClass(this.game.Data.LocObj[this.locNr].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.BNameTextId = this.AddSubPart(ref tsubpart1, 50, 49, 300, 20, 0);
        this.ss = "Click to remove the location from this hex. Note that the landscapetype will stay as it was!";
        tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.BRemoveId = this.AddSubPart(ref tsubpart1, 10, 70, 32, 16, 1);
        tsubpart1 = (SubPartClass) new TextPartClass("Remove Loc from Hex", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.BRemoveTextid = this.AddSubPart(ref tsubpart1, 50, 69, 300, 20, 0);
        this.ss = "Click to change the people that this location belongs too";
        tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BPplId = this.AddSubPart(ref tsubpart1, 10, 90, 32, 16, 1);
        tsubpart1 = (SubPartClass) new TextPartClass(this.game.Data.PeopleObj[this.game.Data.LocObj[this.locNr].People].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.BPplTextId = this.AddSubPart(ref tsubpart1, 50, 89, 300, 20, 0);
      }
      this.ss = "Click to draw on the map a certain areacode slot with a certain value";
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONDRAW, tDescript: this.ss);
      this.BAreaId = this.AddSubPart(ref tsubpart1, 10, 140, 32, 16, 1);
      tsubpart1 = (SubPartClass) new TextPartClass("Set Area Code Values", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.bareatextid = this.AddSubPart(ref tsubpart1, 50, 139, 300, 20, 0);
      this.ss = "Click to change the small label for this hex.";
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a12id = this.AddSubPart(ref tsubpart1, 10, 170, 32, 16, 1);
      if (Operators.CompareString(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].SmallLabel, "", false) == 0)
      {
        tsubpart1 = (SubPartClass) new TextPartClass("SmallLabel: -none set-", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a12bid = this.AddSubPart(ref tsubpart1, 50, 169, 300, 20, 0);
      }
      else
      {
        tsubpart1 = (SubPartClass) new TextPartClass("SmallLabel:" + this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].SmallLabel, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.a12bid = this.AddSubPart(ref tsubpart1, 50, 169, 300, 20, 0);
      }
      this.ss = "Click to change the small label type for this hex. 00=normal, 10=top, 20=bottom, x0 = white, x1=red, x2=green, x3=blue, x4=yellow, x5=light blue. example: 12=  top+green, 4=center yellow";
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a13id = this.AddSubPart(ref tsubpart1, 410, 170, 32, 16, 1);
      tsubpart1 = (SubPartClass) new TextPartClass("SmallLabelType:" + this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].SmallLabelType.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.a13bid = this.AddSubPart(ref tsubpart1, 450, 169, 300, 20, 0);
      this.ss = "Click to change the number of Victory Points on this hex.";
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a1id = this.AddSubPart(ref tsubpart1, 10, 190, 32, 16, 1);
      tsubpart1 = (SubPartClass) new TextPartClass("Hex VP:" + Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].VP), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.a1bid = this.AddSubPart(ref tsubpart1, 50, 189, 300, 20, 0);
      this.ss = "Click to change the name of the Hex (Location name overrules this name)";
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a2id = this.AddSubPart(ref tsubpart1, 10, 210, 32, 16, 1);
      tsubpart1 = (SubPartClass) new TextPartClass("Name:" + this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.a2bid = this.AddSubPart(ref tsubpart1, 50, 209, 300, 20, 0);
      this.ss = "Click to set Text Label 1 (top of hex)";
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a3id = this.AddSubPart(ref tsubpart1, 10, 230, 32, 16, 1);
      tsubpart1 = (SubPartClass) new TextPartClass("Label1:" + this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LabelText1, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.a3bid = this.AddSubPart(ref tsubpart1, 50, 229, 300, 20, 0);
      this.ss = "Click to set Text Label 2 (bottom of hex)";
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a4id = this.AddSubPart(ref tsubpart1, 10, 250, 32, 16, 1);
      tsubpart1 = (SubPartClass) new TextPartClass("Label2:" + this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LabelText2, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.a4bid = this.AddSubPart(ref tsubpart1, 50, 249, 300, 20, 0);
      this.ss = "Click to set Type of Label for Label 1 (top of hex)";
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a5id = this.AddSubPart(ref tsubpart1, 10, 270, 32, 16, 1);
      tsubpart1 = (SubPartClass) new TextPartClass("Type1:" + Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LabelType1), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.a5bid = this.AddSubPart(ref tsubpart1, 50, 269, 300, 20, 0);
      this.ss = "Click to set Type of Label for Label 2 (bottom of hex)";
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a6id = this.AddSubPart(ref tsubpart1, 10, 290, 32, 16, 1);
      tsubpart1 = (SubPartClass) new TextPartClass("Type2:" + Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LabelType2), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.a6bid = this.AddSubPart(ref tsubpart1, 50, 289, 300, 20, 0);
      this.ss = "Click to clear";
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.a7id = this.AddSubPart(ref tsubpart1, 10, 320, 32, 16, 1);
      tsubpart1 = (SubPartClass) new TextPartClass("Clear all label info for this hex", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.a7bid = this.AddSubPart(ref tsubpart1, 50, 319, 300, 20, 0);
      this.ss = "Click to set multi hex label";
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.a8id = this.AddSubPart(ref tsubpart1, 10, 350, 32, 16, 1);
      tsubpart1 = (SubPartClass) new TextPartClass("Set Multihex label", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.a8bid = this.AddSubPart(ref tsubpart1, 50, 349, 300, 20, 0);
      this.ss = "Click to set roads to go off map or to remove off map bits if no corresponding road.";
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.a9id = this.AddSubPart(ref tsubpart1, 10, 380, 32, 16, 1);
      string txt = "Do Roads Offmap (";
      int index = 0;
      do
      {
        string str = txt + this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].RoadType[index].ToString();
        txt = index >= 5 ? str + ")" : str + ",";
        ++index;
      }
      while (index <= 5);
      tsubpart1 = (SubPartClass) new TextPartClass(txt, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 600, 20, false, tDescript: this.ss);
      this.a9bid = this.AddSubPart(ref tsubpart1, 50, 379, 300, 20, 0);
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
            if (num1 == this.AreaListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.detailnr2 = num2;
                this.showinfo();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BRemoveAreaId)
            {
              this.game.Data.RemoveArea(this.detailnr2);
              --this.detailnr2;
              this.MakeAreaList();
              this.showinfo();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddAreaId)
            {
              this.game.Data.AddArea();
              this.game.Data.AreaObj[this.game.Data.AreaCounter].Slot = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Area Slot # 0-9..", "Shadow Empire : Planetary Conquest")));
              this.game.Data.AreaObj[this.game.Data.AreaCounter].Code = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give value/code..", "Shadow Empire : Planetary Conquest")));
              this.game.Data.AreaObj[this.game.Data.AreaCounter].Name = Interaction.InputBox("Give name for area", "Shadow Empire : Planetary Conquest");
              this.MakeAreaList();
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
            if (num1 == this.BAreaId)
            {
              this.game.EditObj.PencilType = 9;
              int num3 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Area Slot # 0-9..", "Shadow Empire : Planetary Conquest")));
              if (num3 > -1 & num3 < 10)
              {
                this.game.EditObj.PencilData1 = num3;
                int num4 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Area Code to Set..", "Shadow Empire : Planetary Conquest")));
                if (num4 > -2 & num4 < 99999)
                {
                  this.game.EditObj.PencilData2 = num4;
                  windowReturnClass.AddCommand(1, 13);
                  windowReturnClass.AddCommand(2, 13);
                  this.showinfo();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
              }
            }
            else
            {
              if (num1 == this.a1id)
              {
                int num5 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give New VP for hex 0-99", "Shadow Empire : Planetary Conquest")));
                if (num5 < 0 | num5 > 99)
                {
                  int num6 = (int) Interaction.MsgBox((object) "Oh.. please.. between 0 and 99!", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                  this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].VP = num5;
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
              if (num1 == this.a12id)
              {
                this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].SmallLabel = Interaction.InputBox("Give new small Label text..", "Shadow Empire : Planetary Conquest");
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a13id)
              {
                string str = Interaction.InputBox("Give new small Label type.. 00=normal, 10=top, 20=bottom, x0 = white, x1=red, x2=green, x3=blue, x4=yellow, x5=light blue... ", "Shadow Empire : Planetary Conquest");
                if (Operators.CompareString(str, "", false) != 0)
                  this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].SmallLabelType = (int) Math.Round(Conversion.Val(str));
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
                int num7 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Label Type for top of hex (label1)", "Shadow Empire : Planetary Conquest")));
                if (num7 < 0 | num7 > 10)
                {
                  int num8 = (int) Interaction.MsgBox((object) "Oh.. please.. between 0 and 10 (0=dont show, 1-5 = small font, 6-10 = big font)", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                  this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LabelType1 = num7;
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a6id)
              {
                int num9 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Label Type for bottom of hex (label2)", "Shadow Empire : Planetary Conquest")));
                if (num9 < 0 | num9 > 10)
                {
                  int num10 = (int) Interaction.MsgBox((object) "Oh.. please.. between 0 and 10 (0=dont show, 1-5 = small font, 6-10 = big font)", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                  this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LabelType2 = num9;
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
                  int num11 = (int) Interaction.MsgBox((object) "Done");
                }
                this.showinfo();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a9id)
              {
                int index2 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Hex Side (0=top,1=NE, 2=SE, 3=S, 4=SW, 5=NW)", "Shadow Empire : Planetary Conquest")));
                if (index2 >= 0 & index2 <= 5)
                {
                  object Left = (object) Conversion.Val(Interaction.InputBox("Give RoadType", "Shadow Empire : Planetary Conquest"));
                  if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreaterEqual(Left, (object) -1, false), Operators.CompareObjectLessEqual(Left, (object) this.game.Data.RoadTypeCounter, false))))
                  {
                    this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].RoadType[index2] = Conversions.ToInteger(Left);
                    int num12 = (int) Interaction.MsgBox((object) "Done");
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
  }
}
