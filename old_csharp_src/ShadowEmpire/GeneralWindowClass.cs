// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.GeneralWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class GeneralWindowClass : WindowClass
  {
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int StringListId;
    private ListClass StringListObj;
    private int libListId;
    private ListClass libListObj;
    private int StringList2Id;
    private ListClass StringList2Obj;
    private int exp1id;
    private int exp1textid;
    private int rrid;
    private int rrtextid;
    private int B1Id;
    private int B1TextId;
    private int B2Id;
    private int B2TextId;
    private int B3Id;
    private int B3TextId;
    private int b4id;
    private int b4textid;
    private int a1Id;
    private int a1TextId;
    private int a2Id;
    private int a2TextId;
    private int a3Id;
    private int a3TextId;
    private int a4Id;
    private int a4TextId;
    private int a5Id;
    private int a5TextId;
    private int a6Id;
    private int a6TextId;
    private int a7Id;
    private int a7TextId;
    private int a8Id;
    private int a8TextId;
    private int a9Id;
    private int a9TextId;
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
    private int a15Id;
    private int a15TextId;
    private int a16Id;
    private int a16TextId;
    private int a17Id;
    private int a17TextId;
    private int a18Id;
    private int a18TextId;
    private int a19Id;
    private int a19TextId;
    private int a20Id;
    private int a20TextId;
    private int a21Id;
    private int a21TextId;
    private int a22Id;
    private int a22TextId;
    private int a22bId;
    private int a22bTextId;
    private int a23Id;
    private int a23TextId;
    private int a23bId;
    private int a23bTextId;
    private int a24Id;
    private int a24TextId;
    private int a25Id;
    private int a25TextId;
    private int a26Id;
    private int a26TextId;
    private int a27Id;
    private int a27TextId;
    private int a28Id;
    private int a28TextId;
    private int a29Id;
    private int a29TextId;
    private int a30Id;
    private int a30TextId;
    private int a31Id;
    private int a31TextId;
    private int a32Id;
    private int a32TextId;
    private int a33Id;
    private int a33TextId;
    private int a34Id;
    private int a34TextId;
    private int a35id;
    private int a35TextId;
    private int a36id;
    private int a36TextId;
    private int a36bid;
    private int a36bTextId;
    private int a37id;
    private int a37TextId;
    private int a38id;
    private int a38TextId;
    private int a38bid;
    private int a38bTextId;
    private int a39id;
    private int a39TextId;
    private int a40id;
    private int a40TextId;
    private int a41id;
    private int a41TextId;
    private int a42id;
    private int a42TextId;
    private int a43id;
    private int a43TextId;
    private int a44id;
    private int a44TextId;
    private int a45id;
    private int a45TextId;
    private int a46id;
    private int a46TextId;
    private int a47id;
    private int a47TextId;
    private int a48id;
    private int a48TextId;
    private int a49id;
    private int a49TextId;
    private int a50id;
    private int a50TextId;
    private int a51id;
    private int a51TextId;
    private int a52id;
    private int a52TextId;
    private int a53id;
    private int a53TextId;
    private int p1id;
    private int p1TextId;
    private int p2id;
    private int p2TextId;
    private int p3id;
    private int p3TextId;
    private int p4id;
    private int p4TextId;
    private int l1id;
    private int l1TextId;
    private int l2id;
    private int l2TextId;
    private int[] vari;
    private int[] variText;
    private int[] vare;
    private int rl1id;
    private int rl2id;
    private int rl1TextId;
    private int rl2TextId;
    private int rl3id;
    private int rl3TextId;
    private int rRemoveId;
    private int addId;
    private int RemoveId;
    private int LoadId;
    private int ChangeId;
    private int PicId;
    private int TabSheetNr;
    private int libNr;
    private int DetailNr;
    private int detailnr2;
    private string ss;
    private int SheetCount;
    private string[] SheetName;
    private Rectangle[] SheetRect;

    public GeneralWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Settings")
    {
      this.vari = new int[12];
      this.variText = new int[12];
      this.vare = new int[12];
      this.SheetName = new string[2];
      this.SheetRect = new Rectangle[2];
      this.TabSheetNr = -1;
      this.DetailNr = -1;
      this.detailnr2 = -1;
      this.libNr = -1;
      this.MakeFirst();
    }

    public override void DoRefresh() => this.MakeFirst();

    private void MakeFirst()
    {
      if (this.OptionsListId > 0)
        this.RemoveSubPart(this.OptionsListId);
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
      if (this.exp1id > 0)
        this.RemoveSubPart(this.exp1id);
      if (this.exp1textid > 0)
        this.RemoveSubPart(this.exp1textid);
      if (this.a1Id > 0)
        this.RemoveSubPart(this.a1Id);
      if (this.a1TextId > 0)
        this.RemoveSubPart(this.a1TextId);
      if (this.p1id > 0)
        this.RemoveSubPart(this.p1id);
      if (this.p1TextId > 0)
        this.RemoveSubPart(this.p1TextId);
      if (this.p2id > 0)
        this.RemoveSubPart(this.p2id);
      if (this.p2TextId > 0)
        this.RemoveSubPart(this.p2TextId);
      if (this.p3id > 0)
        this.RemoveSubPart(this.p3id);
      if (this.p3TextId > 0)
        this.RemoveSubPart(this.p3TextId);
      if (this.p4id > 0)
        this.RemoveSubPart(this.p4id);
      if (this.p4TextId > 0)
        this.RemoveSubPart(this.p4TextId);
      if (this.l1id > 0)
        this.RemoveSubPart(this.l1id);
      if (this.l1TextId > 0)
        this.RemoveSubPart(this.l1TextId);
      if (this.l2id > 0)
        this.RemoveSubPart(this.l2id);
      if (this.l2TextId > 0)
        this.RemoveSubPart(this.l2TextId);
      if (this.a2Id > 0)
        this.RemoveSubPart(this.a2Id);
      if (this.a2TextId > 0)
        this.RemoveSubPart(this.a2TextId);
      if (this.a3Id > 0)
        this.RemoveSubPart(this.a3Id);
      if (this.a3TextId > 0)
        this.RemoveSubPart(this.a3TextId);
      if (this.a4Id > 0)
        this.RemoveSubPart(this.a4Id);
      if (this.a4TextId > 0)
        this.RemoveSubPart(this.a4TextId);
      if (this.a5Id > 0)
        this.RemoveSubPart(this.a5Id);
      if (this.a5TextId > 0)
        this.RemoveSubPart(this.a5TextId);
      if (this.a6Id > 0)
        this.RemoveSubPart(this.a6Id);
      if (this.a6TextId > 0)
        this.RemoveSubPart(this.a6TextId);
      if (this.a7Id > 0)
        this.RemoveSubPart(this.a7Id);
      if (this.a7TextId > 0)
        this.RemoveSubPart(this.a7TextId);
      if (this.a8Id > 0)
        this.RemoveSubPart(this.a8Id);
      if (this.a8TextId > 0)
        this.RemoveSubPart(this.a8TextId);
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
      if (this.a15Id > 0)
        this.RemoveSubPart(this.a15Id);
      if (this.a15TextId > 0)
        this.RemoveSubPart(this.a15TextId);
      if (this.a16Id > 0)
        this.RemoveSubPart(this.a16Id);
      if (this.a16TextId > 0)
        this.RemoveSubPart(this.a16TextId);
      if (this.a17Id > 0)
        this.RemoveSubPart(this.a17Id);
      if (this.a17TextId > 0)
        this.RemoveSubPart(this.a17TextId);
      if (this.a18Id > 0)
        this.RemoveSubPart(this.a18Id);
      if (this.a18TextId > 0)
        this.RemoveSubPart(this.a18TextId);
      if (this.a19Id > 0)
        this.RemoveSubPart(this.a19Id);
      if (this.a19TextId > 0)
        this.RemoveSubPart(this.a19TextId);
      if (this.a20Id > 0)
        this.RemoveSubPart(this.a20Id);
      if (this.a20TextId > 0)
        this.RemoveSubPart(this.a20TextId);
      if (this.a21Id > 0)
        this.RemoveSubPart(this.a21Id);
      if (this.a21TextId > 0)
        this.RemoveSubPart(this.a21TextId);
      if (this.a22Id > 0)
        this.RemoveSubPart(this.a22Id);
      if (this.a22TextId > 0)
        this.RemoveSubPart(this.a22TextId);
      if (this.a22bId > 0)
        this.RemoveSubPart(this.a22bId);
      if (this.a22bTextId > 0)
        this.RemoveSubPart(this.a22bTextId);
      if (this.a23Id > 0)
        this.RemoveSubPart(this.a23Id);
      if (this.a23TextId > 0)
        this.RemoveSubPart(this.a23TextId);
      if (this.a23bId > 0)
        this.RemoveSubPart(this.a23bId);
      if (this.a23bTextId > 0)
        this.RemoveSubPart(this.a23bTextId);
      if (this.a24Id > 0)
        this.RemoveSubPart(this.a24Id);
      if (this.a24TextId > 0)
        this.RemoveSubPart(this.a24TextId);
      if (this.a25Id > 0)
        this.RemoveSubPart(this.a25Id);
      if (this.a25TextId > 0)
        this.RemoveSubPart(this.a25TextId);
      if (this.a26Id > 0)
        this.RemoveSubPart(this.a26Id);
      if (this.a26TextId > 0)
        this.RemoveSubPart(this.a26TextId);
      if (this.a27Id > 0)
        this.RemoveSubPart(this.a27Id);
      if (this.a27TextId > 0)
        this.RemoveSubPart(this.a27TextId);
      if (this.a28Id > 0)
        this.RemoveSubPart(this.a28Id);
      if (this.a28TextId > 0)
        this.RemoveSubPart(this.a28TextId);
      if (this.a29Id > 0)
        this.RemoveSubPart(this.a29Id);
      if (this.a29TextId > 0)
        this.RemoveSubPart(this.a29TextId);
      if (this.a30Id > 0)
        this.RemoveSubPart(this.a30Id);
      if (this.a30TextId > 0)
        this.RemoveSubPart(this.a30TextId);
      if (this.a31Id > 0)
        this.RemoveSubPart(this.a31Id);
      if (this.a31TextId > 0)
        this.RemoveSubPart(this.a31TextId);
      if (this.a32Id > 0)
        this.RemoveSubPart(this.a32Id);
      if (this.a32TextId > 0)
        this.RemoveSubPart(this.a32TextId);
      if (this.a33Id > 0)
        this.RemoveSubPart(this.a33Id);
      if (this.a33TextId > 0)
        this.RemoveSubPart(this.a33TextId);
      if (this.a34Id > 0)
        this.RemoveSubPart(this.a34Id);
      if (this.a34TextId > 0)
        this.RemoveSubPart(this.a34TextId);
      if (this.a35id > 0)
        this.RemoveSubPart(this.a35id);
      if (this.a35TextId > 0)
        this.RemoveSubPart(this.a35TextId);
      if (this.a36id > 0)
        this.RemoveSubPart(this.a36id);
      if (this.a36TextId > 0)
        this.RemoveSubPart(this.a36TextId);
      if (this.a36bid > 0)
        this.RemoveSubPart(this.a36bid);
      if (this.a36bTextId > 0)
        this.RemoveSubPart(this.a36bTextId);
      if (this.a37id > 0)
        this.RemoveSubPart(this.a37id);
      if (this.a37TextId > 0)
        this.RemoveSubPart(this.a37TextId);
      if (this.a38id > 0)
        this.RemoveSubPart(this.a38id);
      if (this.a38TextId > 0)
        this.RemoveSubPart(this.a38TextId);
      if (this.a38bid > 0)
        this.RemoveSubPart(this.a38bid);
      if (this.a38bTextId > 0)
        this.RemoveSubPart(this.a38bTextId);
      if (this.a39id > 0)
        this.RemoveSubPart(this.a39id);
      if (this.a39TextId > 0)
        this.RemoveSubPart(this.a39TextId);
      if (this.a40id > 0)
        this.RemoveSubPart(this.a40id);
      if (this.a40TextId > 0)
        this.RemoveSubPart(this.a40TextId);
      if (this.a41id > 0)
        this.RemoveSubPart(this.a41id);
      if (this.a41TextId > 0)
        this.RemoveSubPart(this.a41TextId);
      if (this.a42id > 0)
        this.RemoveSubPart(this.a42id);
      if (this.a42TextId > 0)
        this.RemoveSubPart(this.a42TextId);
      if (this.a43id > 0)
        this.RemoveSubPart(this.a43id);
      if (this.a43TextId > 0)
        this.RemoveSubPart(this.a43TextId);
      if (this.a44id > 0)
        this.RemoveSubPart(this.a44id);
      if (this.a44TextId > 0)
        this.RemoveSubPart(this.a44TextId);
      if (this.a45id > 0)
        this.RemoveSubPart(this.a45id);
      if (this.a45TextId > 0)
        this.RemoveSubPart(this.a45TextId);
      if (this.a46id > 0)
        this.RemoveSubPart(this.a46id);
      if (this.a46TextId > 0)
        this.RemoveSubPart(this.a46TextId);
      if (this.a47id > 0)
        this.RemoveSubPart(this.a47id);
      if (this.a47TextId > 0)
        this.RemoveSubPart(this.a47TextId);
      if (this.a48id > 0)
        this.RemoveSubPart(this.a48id);
      if (this.a48TextId > 0)
        this.RemoveSubPart(this.a48TextId);
      if (this.a49id > 0)
        this.RemoveSubPart(this.a49id);
      if (this.a49TextId > 0)
        this.RemoveSubPart(this.a49TextId);
      if (this.a50id > 0)
        this.RemoveSubPart(this.a50id);
      if (this.a50TextId > 0)
        this.RemoveSubPart(this.a50TextId);
      if (this.a51id > 0)
        this.RemoveSubPart(this.a51id);
      if (this.a51TextId > 0)
        this.RemoveSubPart(this.a51TextId);
      if (this.a52id > 0)
        this.RemoveSubPart(this.a52id);
      if (this.a52TextId > 0)
        this.RemoveSubPart(this.a52TextId);
      if (this.a53id > 0)
        this.RemoveSubPart(this.a53id);
      if (this.a53TextId > 0)
        this.RemoveSubPart(this.a53TextId);
      if (this.rrid > 0)
        this.RemoveSubPart(this.rrid);
      if (this.rrtextid > 0)
        this.RemoveSubPart(this.rrtextid);
      int index = 0;
      do
      {
        if (this.vari[index] > 0)
          this.RemoveSubPart(this.vari[index]);
        if (this.vare[index] > 0)
          this.RemoveSubPart(this.vare[index]);
        if (this.variText[index] > 0)
          this.RemoveSubPart(this.variText[index]);
        ++index;
      }
      while (index <= 11);
      this.OptionsListObj = new ListClass();
      this.OptionsListObj.add("Group Names", 0);
      this.OptionsListObj.add("GameSlots 0-499", 1);
      this.OptionsListObj.add("RegimeSlot Names 0-499", 2);
      this.OptionsListObj.add("RuleVars", 3);
      this.OptionsListObj.add("EventPics", 4);
      this.OptionsListObj.add("Scn Variants", 5);
      this.OptionsListObj.add("Import & Other Settings", 6);
      this.OptionsListObj.add("SmallGfx", 7);
      this.OptionsListObj.add("Reinforcement Types", 8);
      ListClass optionsListObj = this.OptionsListObj;
      int tabSheetNr = this.TabSheetNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(optionsListObj, 4, 300, tabSheetNr, game, tHeader: "Property Sheets", tbackbitmap: (ref local1), bbx: 10, bby: 50, overruleFont: (ref local2));
      this.OptionsListId = this.AddSubPart(ref tsubpart1, 10, 50, 300, 112, 0);
      this.ss = "Click to set the name for this scenario.. not the filename but the title";
      SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a1Id = this.AddSubPart(ref tsubpart2, 350, 210, 32, 16, 1);
      SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("Scn.Name: " + this.game.Data.Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a1TextId = this.AddSubPart(ref tsubpart3, 390, 209, 200, 20, 0);
      this.ss = "Click to toggle initial setting for fog of war on/off";
      SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a3Id = this.AddSubPart(ref tsubpart4, 350, 70, 32, 16, 1);
      SubPartClass tsubpart5 = (SubPartClass) new TextPartClass("FOW: " + Conversion.Str((object) this.game.Data.FOWOn), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a3TextId = this.AddSubPart(ref tsubpart5, 390, 69, 200, 20, 0);
      this.ss = "Click to set a Load Password on this file. Leave blank for none. Use for scenarios only accesible through campaign.";
      SubPartClass tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a4Id = this.AddSubPart(ref tsubpart6, 350, 90, 32, 16, 1);
      SubPartClass tsubpart7 = (SubPartClass) new TextPartClass("LoadPass: " + this.game.Data.LoadPass, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a4TextId = this.AddSubPart(ref tsubpart7, 390, 89, 200, 20, 0);
      this.ss = "Click to set an Edit Password on this file. Leave blank for none. Use if you dont want players to be able to see AI or events in advance.";
      SubPartClass tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a5Id = this.AddSubPart(ref tsubpart8, 350, 110, 32, 16, 1);
      SubPartClass tsubpart9 = (SubPartClass) new TextPartClass("EditPass: " + this.game.Data.EditPass, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a5TextId = this.AddSubPart(ref tsubpart9, 390, 109, 200, 20, 0);
      this.ss = "Click to set a Masterfile for this scenario. Press Cancel in file browser to disable the masterfile ";
      SubPartClass tsubpart10 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.a6Id = this.AddSubPart(ref tsubpart10, 350, 130, 32, 16, 1);
      SubPartClass tsubpart11 = (SubPartClass) new TextPartClass((this.game.Data.MasterFile.Length <= 1 ? "NO MASTERFILE " : "MASTERFILE: ") + this.game.Data.MasterFile, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a6TextId = this.AddSubPart(ref tsubpart11, 390, 129, 200, 20, 0);
      this.ss = "Set the ammount of Victory Points needed to win. -1 = no victory point condition win";
      SubPartClass tsubpart12 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a7Id = this.AddSubPart(ref tsubpart12, 350, 150, 32, 16, 1);
      SubPartClass tsubpart13 = (SubPartClass) new TextPartClass("VP Win: " + Conversion.Str((object) this.game.Data.VPWin), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a7TextId = this.AddSubPart(ref tsubpart13, 390, 149, 200, 20, 0);
      this.ss = "Click and specify exact task answering 4 questions";
      SubPartClass tsubpart14 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a33Id = this.AddSubPart(ref tsubpart14, 350, 190, 32, 16, 1);
      SubPartClass tsubpart15 = (SubPartClass) new TextPartClass("Autoset Staff and Officer Staff", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a33TextId = this.AddSubPart(ref tsubpart15, 390, 189, 200, 20, 0);
      this.ss = "Click to add hexes to the right of the map";
      SubPartClass tsubpart16 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.a10Id = this.AddSubPart(ref tsubpart16, 350, 250, 32, 16, 1);
      SubPartClass tsubpart17 = (SubPartClass) new TextPartClass("Add/Remove Width (x)", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a10TextId = this.AddSubPart(ref tsubpart17, 390, 249, 200, 20, 0);
      this.ss = "Click to add hexes to the bottom of the map";
      SubPartClass tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.a11Id = this.AddSubPart(ref tsubpart18, 350, 270, 32, 16, 1);
      SubPartClass tsubpart19 = (SubPartClass) new TextPartClass("Add/Remove Height (y)", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a11TextId = this.AddSubPart(ref tsubpart19, 390, 269, 200, 20, 0);
      this.ss = "Click to set all units on ap 100, auto entrench, rdn 100 and full supply";
      SubPartClass tsubpart20 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.a13Id = this.AddSubPart(ref tsubpart20, 650, 50, 32, 16, 1);
      SubPartClass tsubpart21 = (SubPartClass) new TextPartClass("Set SF,LOCs READY!", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a13TextId = this.AddSubPart(ref tsubpart21, 700, 49, 200, 20, 0);
      this.ss = "May not be changed!";
      SubPartClass tsubpart22 = (SubPartClass) new TextPartClass("Start Regime=" + Conversion.Str((object) (this.game.Data.Turn + 1)), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a12TextId = this.AddSubPart(ref tsubpart22, 700, 69, 200, 20, 0);
      this.ss = "Click to start a completly new scenario without masterfile. Current one will be lost";
      SubPartClass tsubpart23 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
      this.a14Id = this.AddSubPart(ref tsubpart23, 650, 90, 32, 16, 1);
      SubPartClass tsubpart24 = (SubPartClass) new TextPartClass("NEW!", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a14TextId = this.AddSubPart(ref tsubpart24, 700, 89, 200, 20, 0);
      this.ss = "Click to toggle round number or date system. If date system you will be able to set start date ddmmyyyy and round increases in days";
      SubPartClass tsubpart25 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a15Id = this.AddSubPart(ref tsubpart25, 650, 110, 32, 16, 1);
      SubPartClass tsubpart26 = (SubPartClass) new TextPartClass(this.game.Data.AlternateRound <= -1 ? "No Alternate Round System" : "Round: " + this.game.Data.StartData.ToString() + ", +days:" + Conversion.Str((object) this.game.Data.AlternateRound), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.a15TextId = this.AddSubPart(ref tsubpart26, 700, 109, 400, 20, 0);
      this.ss = "Click to set the briefing for this scenario.";
      SubPartClass tsubpart27 = (SubPartClass) new TextPartClass("Scn.Desc: " + this.game.Data.Description, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a17TextId = this.AddSubPart(ref tsubpart27, 700, 149, 200, 20, 0);
      SubPartClass tsubpart28 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a17Id = this.AddSubPart(ref tsubpart28, 650, 149, 32, 16, 1);
      this.ss = "Click to load bmp or jpg to overlay over/under the whole hexmap. Use the '1' shortkey in editor to switch between display modes. Loadoverlay setting is saved!";
      SubPartClass tsubpart29 = (SubPartClass) new TextPartClass("Improved Load Overlay", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a19TextId = this.AddSubPart(ref tsubpart29, 700, 189, 200, 20, 0);
      SubPartClass tsubpart30 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.a19Id = this.AddSubPart(ref tsubpart30, 650, 189, 32, 16, 1);
      this.ss = "Simple text field to be displayed very small on scenario setup screen. To help check versioning.";
      SubPartClass tsubpart31 = (SubPartClass) new TextPartClass("Version: " + this.game.Data.scenarioVersion, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.a53TextId = this.AddSubPart(ref tsubpart31, 700, 209, 400, 20, 0);
      SubPartClass tsubpart32 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.a53id = this.AddSubPart(ref tsubpart32, 650, 209, 32, 16, 1);
      if (this.game.SuperAdminRights)
      {
        this.ss = "Click to set product # (not for public use!)";
        SubPartClass tsubpart33 = (SubPartClass) new TextPartClass("Set Product# (" + Strings.Trim(Conversion.Str((object) this.game.Data.Product)) + ")", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.a34TextId = this.AddSubPart(ref tsubpart33, 700, 229, 200, 20, 0);
        SubPartClass tsubpart34 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.a34Id = this.AddSubPart(ref tsubpart34, 650, 229, 32, 16, 1);
      }
      this.ss = "Click to toggle play choice on/off. If no play choice players cannot set which regime is human and which is AI and scenario settings in this have to be used.";
      SubPartClass tsubpart35 = (SubPartClass) new TextPartClass("NoPlayChoice:" + Conversion.Str((object) this.game.Data.NoPlayChoice), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a24TextId = this.AddSubPart(ref tsubpart35, 700, 249, 200, 20, 0);
      SubPartClass tsubpart36 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a24Id = this.AddSubPart(ref tsubpart36, 650, 249, 32, 16, 1);
      this.ss = "Click to toggle if NO AI advice is given. If this is true then the player is not allowed to let AIs play.";
      tsubpart36 = (SubPartClass) new TextPartClass("NoAIAdvice:" + Conversion.Str((object) this.game.Data.NoAIAdvice), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a25TextId = this.AddSubPart(ref tsubpart36, 700, 269, 200, 20, 0);
      tsubpart36 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a25Id = this.AddSubPart(ref tsubpart36, 650, 269, 32, 16, 1);
      this.ss = "Click to set ScenarioDir. Leave '' to use default 'scenarios' dir.";
      tsubpart36 = (SubPartClass) new TextPartClass("ScenarioDir='" + this.game.Data.ScenarioDir + "'", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a36TextId = this.AddSubPart(ref tsubpart36, 700, 289, 200, 20, 0);
      tsubpart36 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.a36id = this.AddSubPart(ref tsubpart36, 650, 289, 32, 16, 1);
      this.ss = "Click to set SoundDir. Leave '' to use default 'sound' dir.";
      tsubpart36 = (SubPartClass) new TextPartClass("SoundDir='" + this.game.Data.SoundDir + "'", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a36bTextId = this.AddSubPart(ref tsubpart36, 400, 289, 200, 20, 0);
      tsubpart36 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.a36bid = this.AddSubPart(ref tsubpart36, 350, 289, 32, 16, 1);
      this.ss = "Click to set name of designer.";
      tsubpart36 = (SubPartClass) new TextPartClass("Designer:" + this.game.Data.Designer, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a26TextId = this.AddSubPart(ref tsubpart36, 390, 229, 200, 20, 0);
      tsubpart36 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a26Id = this.AddSubPart(ref tsubpart36, 350, 229, 32, 16, 1);
      this.ss = "Click to Auto Set Map Lables. All hexes with a name will receive a map label.";
      tsubpart36 = (SubPartClass) new TextPartClass("Auto Set Map Lables", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a28TextId = this.AddSubPart(ref tsubpart36, 50, 209, 200, 20, 0);
      tsubpart36 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.a28Id = this.AddSubPart(ref tsubpart36, 10, 209, 32, 16, 1);
      this.ss = "Click to Clear All Map Lables";
      tsubpart36 = (SubPartClass) new TextPartClass("Clear Map Lables", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a29TextId = this.AddSubPart(ref tsubpart36, 50, 229, 200, 20, 0);
      tsubpart36 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.a29Id = this.AddSubPart(ref tsubpart36, 10, 229, 32, 16, 1);
      if (this.game.Data.UseAI == 1)
      {
        tsubpart36 = (SubPartClass) new TextPartClass("Dc1 AI", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.a30TextId = this.AddSubPart(ref tsubpart36, 50, 249, 200, 20, 0);
      }
      else
      {
        tsubpart36 = (SubPartClass) new TextPartClass("Dc2 AI", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.a30TextId = this.AddSubPart(ref tsubpart36, 50, 249, 200, 20, 0);
      }
      tsubpart36 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a30Id = this.AddSubPart(ref tsubpart36, 10, 249, 32, 16, 1);
      this.ss = "Click to export a .dczip file that can be used by a player to install your scenario";
      tsubpart36 = (SubPartClass) new TextPartClass("Package .dczip file", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.exp1textid = this.AddSubPart(ref tsubpart36, 390, 49, 200, 20, 0);
      tsubpart36 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.exp1id = this.AddSubPart(ref tsubpart36, 350, 49, 32, 16, 1);
      this.ss = "Click to change if this is a campaign room scenario or not";
      if (this.game.Data.CampaignRoom == -1)
      {
        tsubpart36 = (SubPartClass) new TextPartClass("Normal Scenario (non campaign room)", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.a31TextId = this.AddSubPart(ref tsubpart36, 50, 269, 200, 20, 0);
      }
      else
      {
        tsubpart36 = (SubPartClass) new TextPartClass("Campaign Room,card=#" + Conversion.Str((object) this.game.Data.CampaignRoom), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.a31TextId = this.AddSubPart(ref tsubpart36, 50, 269, 200, 20, 0);
      }
      tsubpart36 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a31Id = this.AddSubPart(ref tsubpart36, 10, 269, 32, 16, 1);
      this.ss = "Set to empty string not to overrule systemgraphics. Set to alternate directory inside the graphics directory to do. missing gfx are loaded at old loc.";
      tsubpart36 = (SubPartClass) new TextPartClass("SystemGfx Overrule='" + this.game.Data.SystemGfx + "'", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a32TextId = this.AddSubPart(ref tsubpart36, 50, 189, 200, 20, 0);
      tsubpart36 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.a32Id = this.AddSubPart(ref tsubpart36, 10, 189, 32, 16, 1);
      this.ss = "Click to export Text Logfiles. Gives a variety of feedback for the modder/scn designer. will be put in logs/ directory.";
      tsubpart36 = (SubPartClass) new TextPartClass("Export Text Logfiles", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a35TextId = this.AddSubPart(ref tsubpart36, 50, 169, 200, 20, 0);
      tsubpart36 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.a35id = this.AddSubPart(ref tsubpart36, 10, 169, 32, 16, 1);
      this.maketabsheet();
    }

    private void maketabsheet()
    {
      if (this.a22Id > 0)
        this.RemoveSubPart(this.a22Id);
      if (this.a22TextId > 0)
        this.RemoveSubPart(this.a22TextId);
      if (this.a22bId > 0)
        this.RemoveSubPart(this.a22bId);
      if (this.a22bTextId > 0)
        this.RemoveSubPart(this.a22bTextId);
      if (this.a23Id > 0)
        this.RemoveSubPart(this.a23Id);
      if (this.a23TextId > 0)
        this.RemoveSubPart(this.a23TextId);
      if (this.a23bId > 0)
        this.RemoveSubPart(this.a23bId);
      if (this.a23bTextId > 0)
        this.RemoveSubPart(this.a23bTextId);
      if (this.a38id > 0)
        this.RemoveSubPart(this.a38id);
      if (this.a38TextId > 0)
        this.RemoveSubPart(this.a38TextId);
      if (this.a38bid > 0)
        this.RemoveSubPart(this.a38bid);
      if (this.a38bTextId > 0)
        this.RemoveSubPart(this.a38bTextId);
      if (this.a39id > 0)
        this.RemoveSubPart(this.a39id);
      if (this.a39TextId > 0)
        this.RemoveSubPart(this.a39TextId);
      if (this.a40id > 0)
        this.RemoveSubPart(this.a40id);
      if (this.a40TextId > 0)
        this.RemoveSubPart(this.a40TextId);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.b4id > 0)
        this.RemoveSubPart(this.b4id);
      if (this.b4textid > 0)
        this.RemoveSubPart(this.b4textid);
      if (this.StringListId > 0)
        this.RemoveSubPart(this.StringListId);
      if (this.libListId > 0)
        this.RemoveSubPart(this.libListId);
      if (this.StringList2Id > 0)
        this.RemoveSubPart(this.StringList2Id);
      if (this.addId > 0)
        this.RemoveSubPart(this.addId);
      if (this.RemoveId > 0)
        this.RemoveSubPart(this.RemoveId);
      if (this.LoadId > 0)
        this.RemoveSubPart(this.LoadId);
      if (this.PicId > 0)
        this.RemoveSubPart(this.PicId);
      if (this.rrid > 0)
        this.RemoveSubPart(this.rrid);
      if (this.rrtextid > 0)
        this.RemoveSubPart(this.rrtextid);
      if (this.ChangeId > 0)
        this.RemoveSubPart(this.ChangeId);
      int index = 0;
      do
      {
        if (this.vari[index] > 0)
          this.RemoveSubPart(this.vari[index]);
        if (this.variText[index] > 0)
          this.RemoveSubPart(this.variText[index]);
        ++index;
      }
      while (index <= 11);
      if (this.rl1id > 0)
        this.RemoveSubPart(this.rl1id);
      if (this.rl1TextId > 0)
        this.RemoveSubPart(this.rl1TextId);
      if (this.rl2id > 0)
        this.RemoveSubPart(this.rl2id);
      if (this.rl2TextId > 0)
        this.RemoveSubPart(this.rl2TextId);
      if (this.rl3id > 0)
        this.RemoveSubPart(this.rl3id);
      if (this.rl3TextId > 0)
        this.RemoveSubPart(this.rl3TextId);
      if (this.rRemoveId > 0)
        this.RemoveSubPart(this.rRemoveId);
      if (this.TabSheetNr <= -1)
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
      if (this.TabSheetNr == 7)
        this.maketabsheetnr7();
      if (this.TabSheetNr != 8)
        return;
      this.maketabsheetnr8();
    }

    private void maketabsheetnr6()
    {
      this.ss = "Click to import only historical units from a file of choice";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.a37id = this.AddSubPart(ref tsubpart1, 10, 300, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Import Historical Units", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a37TextId = this.AddSubPart(ref tsubpart2, 50, 299, 400, 20, 0);
      this.ss = "Click to set file to loadable in editor when in progress.";
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a39id = this.AddSubPart(ref tsubpart3, 10, 320, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Loadable=" + Conversion.Str((object) this.game.Data.Loadable), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a39TextId = this.AddSubPart(ref tsubpart4, 50, 319, 400, 20, 0);
      this.ss = "Actually load a saved game file. This can only be a savegame from a scenario that had Loadable=True. ";
      SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.a40id = this.AddSubPart(ref tsubpart5, 10, 340, 32, 16, 1);
      SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("Load a saved game", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a40TextId = this.AddSubPart(ref tsubpart6, 50, 339, 400, 20, 0);
      this.ss = "Click to only import SFTypes from another file of choice";
      SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.a41id = this.AddSubPart(ref tsubpart7, 10, 360, 32, 16, 1);
      SubPartClass tsubpart8 = (SubPartClass) new TextPartClass("Import SFTypes", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a41TextId = this.AddSubPart(ref tsubpart8, 50, 359, 400, 20, 0);
      this.ss = "Click to only import LocTypes from another file of choice";
      SubPartClass tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.a48id = this.AddSubPart(ref tsubpart9, 10, 500, 32, 16, 1);
      SubPartClass tsubpart10 = (SubPartClass) new TextPartClass("Import LocTypes", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a48TextId = this.AddSubPart(ref tsubpart10, 50, 499, 400, 20, 0);
      this.ss = "Click to only import Landscape Types from another file of choice";
      SubPartClass tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.a49id = this.AddSubPart(ref tsubpart11, 10, 520, 32, 16, 1);
      SubPartClass tsubpart12 = (SubPartClass) new TextPartClass("Import LandscapeTypes", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a49TextId = this.AddSubPart(ref tsubpart12, 50, 519, 400, 20, 0);
      this.ss = "Click to only import Landscape Types from another file of choice";
      SubPartClass tsubpart13 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.a50id = this.AddSubPart(ref tsubpart13, 10, 540, 32, 16, 1);
      SubPartClass tsubpart14 = (SubPartClass) new TextPartClass("Import Gamevars", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a50TextId = this.AddSubPart(ref tsubpart14, 50, 539, 400, 20, 0);
      this.ss = "Click to load from a file of choice.";
      SubPartClass tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.a52id = this.AddSubPart(ref tsubpart15, 10, 560, 32, 16, 1);
      SubPartClass tsubpart16 = (SubPartClass) new TextPartClass("Import Map", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a52TextId = this.AddSubPart(ref tsubpart16, 50, 559, 400, 20, 0);
      this.ss = "Click to import AND ovewrite your pre-def units AND normal units [be careful]";
      SubPartClass tsubpart17 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.a51id = this.AddSubPart(ref tsubpart17, 10, 580, 32, 16, 1);
      SubPartClass tsubpart18 = (SubPartClass) new TextPartClass("Import Units", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a51TextId = this.AddSubPart(ref tsubpart18, 50, 579, 200, 20, 0);
      this.ss = "Click to save all non system graphics in a tempgraphics directory.";
      SubPartClass tsubpart19 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.a43id = this.AddSubPart(ref tsubpart19, 10, 400, 32, 16, 1);
      SubPartClass tsubpart20 = (SubPartClass) new TextPartClass("Save all non-system gfx", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a43TextId = this.AddSubPart(ref tsubpart20, 50, 399, 400, 20, 0);
      this.ss = "Click to set a ruleset name. (is inheritied from any masterfile if any)";
      SubPartClass tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a44id = this.AddSubPart(ref tsubpart21, 10, 420, 32, 16, 1);
      SubPartClass tsubpart22 = (SubPartClass) new TextPartClass("RuleSet: " + this.game.Data.RuleSetName, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.a44TextId = this.AddSubPart(ref tsubpart22, 50, 419, 400, 20, 0);
      this.ss = "Click to export a PDF with info on OOBs. THIS FUNCTION IS EXPERIMENTAL AND MIGHT NOT WORK WITH CUSTOM SCENARIOS";
      SubPartClass tsubpart23 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.p1id = this.AddSubPart(ref tsubpart23, 510, 450, 32, 16, 1);
      SubPartClass tsubpart24 = (SubPartClass) new TextPartClass("Export PDF Book : OOBs", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.p1TextId = this.AddSubPart(ref tsubpart24, 550, 449, 400, 20, 0);
      this.ss = "Click to export a PDF with reinforcement schedule. THIS FUNCTION IS EXPERIMENTAL AND MIGHT NOT WORK WITH CUSTOM SCENARIOS";
      SubPartClass tsubpart25 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.p2id = this.AddSubPart(ref tsubpart25, 510, 470, 32, 16, 1);
      SubPartClass tsubpart26 = (SubPartClass) new TextPartClass("Export PDF Book: Reinforcements", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.p2TextId = this.AddSubPart(ref tsubpart26, 550, 469, 400, 20, 0);
      this.ss = "Click to make a string replace in file referenes of graphics";
      SubPartClass tsubpart27 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.p3id = this.AddSubPart(ref tsubpart27, 510, 510, 32, 16, 1);
      SubPartClass tsubpart28 = (SubPartClass) new TextPartClass("Replace in graphic file string", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.p3TextId = this.AddSubPart(ref tsubpart28, 550, 509, 400, 20, 0);
      this.ss = "Click to make a string replace in file referenes of sounds";
      SubPartClass tsubpart29 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.p4id = this.AddSubPart(ref tsubpart29, 510, 530, 32, 16, 1);
      SubPartClass tsubpart30 = (SubPartClass) new TextPartClass("Replace in sound file string", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.p4TextId = this.AddSubPart(ref tsubpart30, 550, 529, 400, 20, 0);
    }

    private void maketabsheetnr0()
    {
      this.StringListObj = new ListClass();
      if (this.game.Data.StringCounter < 1500)
      {
        this.game.Data.StringCounter = 1500;
        this.game.Data.TempString = (string[]) Utils.CopyArray((Array) this.game.Data.TempString, (Array) new string[this.game.Data.StringCounter + 1]);
      }
      int num1 = this.game.Data.StringCounter - 1;
      for (int index = 0; index <= num1; ++index)
      {
        string str = "";
        int num2 = 0;
        if (index >= 0 & index <= 99)
        {
          str = "MoveGroup";
          num2 = 0;
        }
        if (index >= 100 & index <= 199)
        {
          str = "LandscapeGroup";
          num2 = 100;
        }
        if (index >= 200 & index <= 299)
        {
          str = "PeopleGroup";
          num2 = 200;
        }
        if (index >= 300 & index <= 399)
        {
          str = "ItemGroup";
          num2 = 300;
        }
        if (index >= 400 & index <= 499)
        {
          str = "SFTypeGroup";
          num2 = 400;
        }
        if (index >= 500 & index <= 599)
        {
          str = "LocTypeGroup";
          num2 = 500;
        }
        if (index >= 600 & index <= 699)
        {
          str = "SFTypeVarName";
          num2 = 600;
        }
        if (index == 700)
          str = "Extra Statistic Name 1";
        if (index == 701)
          str = "Extra Statistic Name 2";
        if (index == 702)
          str = "Extra Statistic Name 3";
        if (index == 705)
          str = "Card Category Name 1";
        if (index == 706)
          str = "Card Category Name 2";
        if (index == 707)
          str = "Card Category Name 3";
        if (index == 708)
          str = "Card Category Name 4";
        if (index == 709)
          str = "Card Category Name 5";
        if (index >= 710 & index <= 720)
        {
          str = "AreaSlot ";
          num2 = 710;
        }
        if (index == 721)
        {
          str = "FrontZonesHexLibVarName";
          num2 = 721;
        }
        if (index == 722)
        {
          str = "FrontZonesLibraryName";
          num2 = 722;
        }
        if (index == 723)
        {
          str = "FrontZonesUnitLibVarName";
          num2 = 723;
        }
        if (index == 724)
        {
          str = "FrontZonesExemptUnitLibVarValue";
          num2 = 724;
        }
        if (index == 725)
        {
          str = "FrontZonesExemptUnitLibVarLibraryName";
          num2 = 725;
        }
        if (index == 726)
        {
          str = "library name";
          num2 = 726;
        }
        if (index == 727)
        {
          str = "library var name InterceptMod";
          num2 = 727;
        }
        if (index == 730)
        {
          str = "Alternate Music Prefs Label";
          num2 = 730;
        }
        if (index == 731)
        {
          str = "TopBar Stringlist col1 name";
          num2 = 731;
        }
        if (index == 732)
        {
          str = "TopBar Stringlist col1 abbrev";
          num2 = 732;
        }
        if (index == 733)
        {
          str = "TopBar Stringlist col1 mouseover";
          num2 = 733;
        }
        if (index == 741)
        {
          str = "FreeZonesHexLibVarName";
          num2 = 741;
        }
        if (index == 740)
        {
          str = "FreeZonesLibraryName";
          num2 = 740;
        }
        if (index == 743)
        {
          str = "Zones HexLibVarName";
          num2 = 743;
        }
        if (index == 742)
        {
          str = "Zones LibraryName";
          num2 = 742;
        }
        if (index == 745)
        {
          str = "Scenario Version";
          num2 = 745;
        }
        if (index == 746)
        {
          str = "LIS hislibvar library name";
          num2 = 746;
        }
        if (index == 747)
        {
          str = "LIS hislibvar library name";
          num2 = 747;
        }
        if (index == 748)
        {
          str = "library name";
          num2 = 748;
        }
        if (index == 749)
        {
          str = "library var name InterceptRangeMod";
          num2 = 749;
        }
        if (index >= 750 & index <= 799)
        {
          str = "-SYSTEM USAGE-";
          num2 = 750;
        }
        if (index >= 1000)
        {
          str = "SFtype Small Gfx Number";
          num2 = 1000;
        }
        if (index >= 1100)
        {
          str = "SFtype Logo Name/Mouse Over";
          num2 = 1100;
        }
        if (index >= 1200)
        {
          str = "HisVar Type Mouse Over";
          num2 = 1200;
        }
        if (index >= 1300)
        {
          str = "HisVar Small Gfx Number";
          num2 = 1300;
        }
        if (index >= 1400)
        {
          str = "HisVar Show with unit (0/1) ";
          num2 = 1400;
        }
        if (index >= 800 & index <= 899)
        {
          str = "Event Group";
          num2 = 800;
        }
        if (index >= 900 & index <= 999)
        {
          str = "Movement Sound Override";
          num2 = 900;
        }
        this.StringListObj.add("[" + Strings.Trim(Conversion.Str((object) index)) + "] " + str + Conversion.Str((object) (index - num2)) + ") " + this.game.Data.TempString[index], index);
      }
      if (this.DetailNr > this.game.Data.StringCounter)
        this.DetailNr = -1;
      ListClass stringListObj = this.StringListObj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(stringListObj, 19, 300, detailNr, game, tHeader: "Group Names", tbackbitmap: (ref local1), bbx: 10, bby: 300, overruleFont: (ref local2));
      this.StringListId = this.AddSubPart(ref tsubpart, 10, 300, 300, 352, 0);
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr0b();
    }

    private void maketabsheetnr0b()
    {
      this.ss = "Click to change a groupname";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.B1Id = this.AddSubPart(ref tsubpart1, 350, 340, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Change String", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B1TextId = this.AddSubPart(ref tsubpart2, 390, 339, 400, 20, 0);
      if (!(this.DetailNr >= 750 & this.DetailNr <= 799))
        return;
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.rrid = this.AddSubPart(ref tsubpart3, 350, 380, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Reinf-Rate = " + this.game.Data.ReinfRatio[this.DetailNr - 750].ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.rrtextid = this.AddSubPart(ref tsubpart4, 390, 379, 400, 20, 0);
    }

    private void maketabsheetnr1()
    {
      this.StringListObj = new ListClass();
      int index = 0;
      do
      {
        this.StringListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.GameSlotName[index] + " = " + Conversion.Str((object) this.game.Data.GameSlot[index]), index);
        ++index;
      }
      while (index <= 499);
      if (this.DetailNr > this.game.Data.StringCounter)
        this.DetailNr = -1;
      ListClass stringListObj = this.StringListObj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(stringListObj, 12, 300, detailNr, game, tHeader: "Gameslot Names", tbackbitmap: (ref local1), bbx: 10, bby: 300, overruleFont: (ref local2));
      this.StringListId = this.AddSubPart(ref tsubpart, 10, 300, 300, 240, 0);
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr1b();
    }

    private void maketabsheetnr1b()
    {
      this.ss = "Click to change the name of this gameslot";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.B1Id = this.AddSubPart(ref tsubpart1, 350, 340, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Change String", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B1TextId = this.AddSubPart(ref tsubpart2, 390, 339, 200, 20, 0);
      this.ss = "Click to change the initial value of this gameslot";
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.B2Id = this.AddSubPart(ref tsubpart3, 350, 370, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Change Value", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B2TextId = this.AddSubPart(ref tsubpart4, 390, 369, 200, 20, 0);
      this.ss = "Click to toggle on/off if this gameslot value can be seen by the players in diplomatics/strategic window";
      SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a22Id = this.AddSubPart(ref tsubpart5, 350, 420, 32, 16, 1);
      SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("ShowGameVars=" + Conversion.Str((object) this.game.Data.GameSlotShow[this.DetailNr]), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a22TextId = this.AddSubPart(ref tsubpart6, 390, 419, 200, 20, 0);
      this.ss = "0= no nato sprite (20x20 pix max)";
      SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a38bid = this.AddSubPart(ref tsubpart7, 350, 440, 32, 16, 1);
      SubPartClass tsubpart8 = (SubPartClass) new TextPartClass("NATO=" + Conversion.Str((object) this.game.Data.GameSlotNato[this.DetailNr]) + ", SmallGfx=" + Conversion.Str((object) this.game.Data.GameSlotSmallGfx[this.DetailNr]), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a38bTextId = this.AddSubPart(ref tsubpart8, 390, 439, 200, 20, 0);
    }

    private void maketabsheetnr2()
    {
      this.StringListObj = new ListClass();
      int index = 0;
      do
      {
        this.StringListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.RegimeSlotName[index], index);
        ++index;
      }
      while (index <= 499);
      if (this.DetailNr > this.game.Data.StringCounter)
        this.DetailNr = -1;
      ListClass stringListObj = this.StringListObj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(stringListObj, 12, 300, detailNr, game, tHeader: "Regimeslots", tbackbitmap: (ref local1), bbx: 10, bby: 300, overruleFont: (ref local2));
      this.StringListId = this.AddSubPart(ref tsubpart, 10, 300, 300, 240, 0);
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr2b();
    }

    private void maketabsheetnr2b()
    {
      this.ss = "Click to change the name of this regimeslot. (you can set the values in the regime screen)";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.B1Id = this.AddSubPart(ref tsubpart1, 350, 340, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Change String", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B1TextId = this.AddSubPart(ref tsubpart2, 390, 339, 200, 20, 0);
      this.ss = "Click to toggle on/off if the player can see the value of this regimeslot in the resource window";
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a23Id = this.AddSubPart(ref tsubpart3, 350, 400, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Show=" + Conversion.Str((object) this.game.Data.RegimeSlotShow[this.DetailNr]), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a23TextId = this.AddSubPart(ref tsubpart4, 390, 399, 200, 20, 0);
      this.ss = "0= no nato sprite (20x20 pix max)";
      SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a38id = this.AddSubPart(ref tsubpart5, 350, 440, 32, 16, 1);
      SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("NATO=" + Conversion.Str((object) this.game.Data.RegimeSlotNato[this.DetailNr]) + ",SmallGfx=" + Conversion.Str((object) this.game.Data.RegimeSlotSmallGfx[this.DetailNr]), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a38TextId = this.AddSubPart(ref tsubpart6, 390, 439, 200, 20, 0);
      this.ss = "See the value of this regimeslot in the regime info list. 0=default (same as show1), 1=all, 2=only self, 3=self+allies, -1=hidden always";
      SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.a23bId = this.AddSubPart(ref tsubpart7, 350, 460, 32, 16, 1);
      SubPartClass tsubpart8 = (SubPartClass) new TextPartClass("Show2=" + Conversion.Str((object) this.game.Data.RegimeSlotShow2[this.DetailNr]), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.a23bTextId = this.AddSubPart(ref tsubpart8, 390, 459, 200, 20, 0);
    }

    private void maketabsheetnr3()
    {
      this.StringList2Obj = new ListClass();
      int num1 = -1;
      int num2 = -1;
      int tdata = 1;
      do
      {
        ++num1;
        string tname = "";
        if (tdata == 1)
          tname = "Movement types & Ranges";
        if (tdata == 2)
          tname = "ZOC, Recon & Autoconquer";
        if (tdata == 3)
          tname = "Supply";
        if (tdata == 4)
          tname = "Bridge,Road,River & AP";
        if (tdata == 5)
          tname = "Readiness";
        if (tdata == 6)
          tname = "Experience,Morale & EP";
        if (tdata == 7)
          tname = "Political Points + Strict OOB rules";
        if (tdata == 8)
          tname = "HQ Power";
        if (tdata == 9)
          tname = "Combat Calculations";
        if (tdata == 10)
          tname = "Artifical Intelligence";
        if (tdata == 11)
          tname = "Random Map Instructions";
        if (tdata == 12)
          tname = "Enable/Disable features";
        if (tdata == 13)
          tname = "Extra Statistics";
        if (tdata == 14)
          tname = "Engine Graphics";
        if (tdata == 15)
          tname = "Allies & Diplomatics & Hex Sharing";
        if (tdata == 16)
          tname = "Direct Production, Autoreinforce, Officerpool";
        if (tdata == 17)
          tname = "Experimental Functionality";
        if (tdata == 18)
          tname = "DC1 AI";
        if (tdata == 19)
          tname = "DC2 AI";
        if (tdata == 20)
          tname = "Simple/Intermediate Editor";
        if (tdata == 21)
          tname = "Height, Los, Dc4 Gen features";
        if (tdata == 22)
          tname = "LIS, UDS, Se1 Gen features";
        if (tname.Length > 0)
          this.StringList2Obj.add(tname, tdata);
        if (tdata == this.detailnr2)
          num2 = num1;
        ++tdata;
      }
      while (tdata <= 22);
      if (this.detailnr2 > 35)
        this.detailnr2 = -1;
      ListClass stringList2Obj = this.StringList2Obj;
      int tlistselect1 = num2;
      GameClass game1 = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(stringList2Obj, 18, 250, tlistselect1, game1, tHeader: "Rulevar Groups", tbackbitmap: (ref local1), bbx: 10, bby: 300, overruleFont: (ref local2));
      this.StringList2Id = this.AddSubPart(ref tsubpart1, 10, 300, 250, 336, 0);
      this.StringListObj = new ListClass();
      int num3 = -1;
      int num4 = -1;
      int ruleCounter = this.game.Data.RuleCounter;
      for (int index = 0; index <= ruleCounter; ++index)
      {
        if ((this.game.Data.RuleGroup[index] == this.detailnr2 | this.game.Data.RuleGroup2[index] == this.detailnr2) & this.game.Data.RuleString[index].Length > 1)
        {
          ++num3;
          this.StringListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.RuleString[index] + " = " + Conversion.Str((object) this.game.Data.RuleVar[index]), index);
          if (index == this.DetailNr)
            num4 = num3;
        }
      }
      if (this.DetailNr > this.game.Data.RuleCounter)
        this.DetailNr = -1;
      ListClass stringListObj = this.StringListObj;
      int twidth = 700 + (this.game.ScreenWidth - 1024);
      int tlistselect2 = num4;
      GameClass game2 = this.game;
      ref Bitmap local3 = ref this.OwnBitmap;
      font = (Font) null;
      ref Font local4 = ref font;
      SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(stringListObj, 13, twidth, tlistselect2, game2, tHeader: "Rulevars", tbackbitmap: (ref local3), bbx: 300, bby: 345, overruleFont: (ref local4));
      this.StringListId = this.AddSubPart(ref tsubpart2, 300, 345, 700 + (this.game.ScreenWidth - 1024), 256, 0);
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr3b();
    }

    private void maketabsheetnr3b()
    {
      this.ss = "Click to change the value of a rulevar";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.b4id = this.AddSubPart(ref tsubpart1, 300, 620, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Change Rule Value", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b4textid = this.AddSubPart(ref tsubpart2, 350, 619, 400, 20, 0);
    }

    private void maketabsheetnr4()
    {
      this.libListObj = new ListClass();
      int num1;
      Font font;
      SubPartClass tsubpart;
      if (this.game.Data.LibraryCounter > -1)
      {
        num1 = -1;
        int num2 = 0;
        this.libListObj.add("All", -2);
        if (this.libNr == -1)
          num1 = 0;
        int libraryCounter = this.game.Data.LibraryCounter;
        for (int index = 0; index <= libraryCounter; ++index)
        {
          ++num2;
          this.libListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.LibraryObj[index].name, index);
          if (this.libNr == index)
            num1 = num2;
        }
        int num3 = 0;
        if (this.game.ScreenHeight > 800)
          num3 = (int) Math.Round((double) (this.game.ScreenHeight - 800) / 16.0);
        if (this.libNr > this.game.Data.LibraryCounter)
          this.libNr = -1;
        ListClass libListObj = this.libListObj;
        int tlistsize = 12 + num3;
        int tlistselect = num1;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        font = (Font) null;
        ref Font local2 = ref font;
        tsubpart = (SubPartClass) new ListSubPartClass(libListObj, tlistsize, 300, tlistselect, game, tHeader: "Libraries", tbackbitmap: (ref local1), bbx: 910, bby: 300, overruleFont: (ref local2));
        this.libListId = this.AddSubPart(ref tsubpart, 910, 300, 300, (15 + num3) * 16, 0);
      }
      else
        this.libNr = -1;
      this.StringListObj = new ListClass();
      if (this.game.Data.EventPicCounter > -1)
      {
        num1 = -1;
        int num4 = -1;
        int eventPicCounter = this.game.Data.EventPicCounter;
        for (int index = 0; index <= eventPicCounter; ++index)
        {
          int num5 = 0;
          if (this.libNr == -1)
            num5 = 1;
          else if (this.game.Data.eventPicLibId[index].libSlot == this.libNr)
            num5 = 1;
          if (num5 == 1)
          {
            ++num4;
            this.StringListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.EventPicName[index], index);
            if (this.DetailNr == index)
              num1 = num4;
          }
        }
      }
      int num6 = 0;
      if (this.game.ScreenHeight > 800)
        num6 = (int) Math.Round((double) (this.game.ScreenHeight - 800) / 16.0);
      if (this.DetailNr > this.game.Data.EventPicCounter)
        this.DetailNr = -1;
      ListClass stringListObj = this.StringListObj;
      int tlistsize1 = 12 + num6;
      int tlistselect1 = num1;
      GameClass game1 = this.game;
      ref Bitmap local3 = ref this.OwnBitmap;
      font = (Font) null;
      ref Font local4 = ref font;
      tsubpart = (SubPartClass) new ListSubPartClass(stringListObj, tlistsize1, 300, tlistselect1, game1, tHeader: "Event graphics", tbackbitmap: (ref local3), bbx: 10, bby: 300, overruleFont: (ref local4));
      this.StringListId = this.AddSubPart(ref tsubpart, 10, 300, 300, (15 + num6) * 16, 0);
      if (this.DetailNr > -1)
        this.maketabsheetnr4b();
      this.ss = "Click to add a new graphics for events";
      tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.addId = this.AddSubPart(ref tsubpart, 350, 340, 32, 16, 1);
    }

    private void maketabsheetnr4b()
    {
      if (this.l1id > 0)
        this.RemoveSubPart(this.l1id);
      if (this.l1TextId > 0)
        this.RemoveSubPart(this.l1TextId);
      if (this.l2id > 0)
        this.RemoveSubPart(this.l2id);
      if (this.l2TextId > 0)
        this.RemoveSubPart(this.l2TextId);
      if (this.RemoveId > 0)
        this.RemoveSubPart(this.RemoveId);
      if (this.LoadId > 0)
        this.RemoveSubPart(this.LoadId);
      if (this.PicId > 0)
        this.RemoveSubPart(this.PicId);
      this.ss = "Click to remove event graphic. Please realize that events could get screwed up by doing so";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
      this.RemoveId = this.AddSubPart(ref tsubpart1, 350, 370, 32, 16, 1);
      this.ss = "Click to change the event graphic.";
      SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.LoadId = this.AddSubPart(ref tsubpart2, 350, 400, 32, 16, 1);
      int num = this.game.Data.EventPicNr[this.DetailNr];
      int w = BitmapStore.GetWidth(num);
      int h = BitmapStore.Getheight(num);
      if (w > 500 & this.game.Data.LibraryCounter > -1)
      {
        h = (int) Math.Round((double) (h * 500) / (double) w);
        w = 500;
      }
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(num);
      this.PicId = this.AddSubPart(ref tsubpart3, 350, 430, w, h, 1);
      this.ss = "You need to set these to library if they are used by events. Otherwise they dont get imported.";
      string str = "None";
      if (this.game.Data.eventPicLibId[this.DetailNr].libSlot > -1)
        str = this.game.Data.LibraryObj[this.game.Data.eventPicLibId[this.DetailNr].libSlot].name + ", LibID = " + this.game.Data.eventPicLibId[this.DetailNr].id.ToString();
      SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.l1id = this.AddSubPart(ref tsubpart4, 500, 370, 32, 16, 1);
      SubPartClass tsubpart5 = (SubPartClass) new TextPartClass("Library: " + str, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 600, 20, false, tDescript: this.ss);
      this.l1TextId = this.AddSubPart(ref tsubpart5, 550, 369, 600, 20, 0);
    }

    private void maketabsheetnr7()
    {
      this.StringListObj = new ListClass();
      if (this.game.Data.SmallPicCounter > -1)
      {
        int smallPicCounter = this.game.Data.SmallPicCounter;
        for (int index = 0; index <= smallPicCounter; ++index)
          this.StringListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.SmallPicName[index], index);
      }
      if (this.DetailNr > this.game.Data.SmallPicCounter)
        this.DetailNr = -1;
      ListClass stringListObj = this.StringListObj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(stringListObj, 12, 300, detailNr, game, tHeader: "Small Gfx", tbackbitmap: (ref local1), bbx: 10, bby: 300, overruleFont: (ref local2));
      this.StringListId = this.AddSubPart(ref tsubpart1, 10, 300, 300, 240, 0);
      if (this.DetailNr > -1)
        this.maketabsheetnr7b();
      this.ss = "Click to add a new small graphics";
      SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.addId = this.AddSubPart(ref tsubpart2, 350, 340, 32, 16, 1);
    }

    private void maketabsheetnr7b()
    {
      if (this.l1id > 0)
        this.RemoveSubPart(this.l1id);
      if (this.l1TextId > 0)
        this.RemoveSubPart(this.l1TextId);
      if (this.l2id > 0)
        this.RemoveSubPart(this.l2id);
      if (this.l2TextId > 0)
        this.RemoveSubPart(this.l2TextId);
      if (this.RemoveId > 0)
        this.RemoveSubPart(this.RemoveId);
      if (this.LoadId > 0)
        this.RemoveSubPart(this.LoadId);
      if (this.PicId > 0)
        this.RemoveSubPart(this.PicId);
      this.ss = "Click to remove small gfx.";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
      this.RemoveId = this.AddSubPart(ref tsubpart1, 350, 370, 32, 16, 1);
      this.ss = "Click to change the small gfx.";
      SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.LoadId = this.AddSubPart(ref tsubpart2, 350, 400, 32, 16, 1);
      int num = this.game.Data.SmallPicNr[this.DetailNr];
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(num);
      this.PicId = this.AddSubPart(ref tsubpart3, 350, 430, BitmapStore.GetWidth(num), BitmapStore.Getheight(num), 1);
      string str = "None";
      this.ss = "You need to set these to library if they are used by events. Otherwise they dont get imported.";
      if (this.game.Data.SmallLibId[this.DetailNr].libSlot > -1)
        str = this.game.Data.LibraryObj[this.game.Data.SmallLibId[this.DetailNr].libSlot].name + "(libID= " + this.game.Data.SmallLibId[this.DetailNr].id.ToString() + ")";
      SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.l2id = this.AddSubPart(ref tsubpart4, 500, 370, 32, 16, 1);
      SubPartClass tsubpart5 = (SubPartClass) new TextPartClass("Library: " + str, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 500, 20, false, tDescript: this.ss);
      this.l2TextId = this.AddSubPart(ref tsubpart5, 550, 369, 500, 20, 0);
    }

    private void maketabsheetnr8()
    {
      this.StringListObj = new ListClass();
      if (this.game.Data.ReinfCounter > -1)
      {
        int reinfCounter = this.game.Data.ReinfCounter;
        for (int index = 0; index <= reinfCounter; ++index)
          this.StringListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.ReinfName[index] + "(ratio= " + this.game.Data.ReinfRatio[index].ToString() + " , id= " + this.game.Data.ReinfId[index].ToString() + ", libSlot= " + this.game.Data.ReinfLibId[index].libSlot.ToString() + ", libSlotid=" + this.game.Data.ReinfLibId[index].id.ToString() + ")", index);
      }
      if (this.DetailNr > this.game.Data.ReinfCounter)
        this.DetailNr = -1;
      ListClass stringListObj = this.StringListObj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(stringListObj, 12, 550, detailNr, game, tHeader: "Reinforcement Types", tbackbitmap: (ref local1), bbx: 10, bby: 340, overruleFont: (ref local2));
      this.StringListId = this.AddSubPart(ref tsubpart, 10, 340, 550, 240, 0);
      if (this.DetailNr > -1)
        this.maketabsheetnr8b();
      this.ss = "Click to add a new reinf.type";
      tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.addId = this.AddSubPart(ref tsubpart, 650, 340, 32, 16, 1);
    }

    private void maketabsheetnr8b()
    {
      if (this.rl1id > 0)
        this.RemoveSubPart(this.rl1id);
      if (this.rl1TextId > 0)
        this.RemoveSubPart(this.rl1TextId);
      if (this.rl2id > 0)
        this.RemoveSubPart(this.rl2id);
      if (this.rl2TextId > 0)
        this.RemoveSubPart(this.rl2TextId);
      if (this.rl3id > 0)
        this.RemoveSubPart(this.rl3id);
      if (this.rl3TextId > 0)
        this.RemoveSubPart(this.rl3TextId);
      if (this.rRemoveId > 0)
        this.RemoveSubPart(this.rRemoveId);
      this.ss = "Click to remove reinf.type";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
      this.rRemoveId = this.AddSubPart(ref tsubpart1, 650, 370, 32, 16, 1);
      this.ss = "Change reinf. type name + ratio";
      SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.rl1id = this.AddSubPart(ref tsubpart2, 650, 390, 32, 16, 1);
      SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("Change name+ratio", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.rl1TextId = this.AddSubPart(ref tsubpart3, 700, 389, 400, 20, 0);
      string str1 = "None";
      this.ss = "Change library. (not recommended to use)";
      if (this.game.Data.ReinfLibId[this.DetailNr].libSlot > -1)
        str1 = this.game.Data.LibraryObj[this.game.Data.ReinfLibId[this.DetailNr].libSlot].name;
      SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.rl2id = this.AddSubPart(ref tsubpart4, 800, 370, 32, 16, 1);
      SubPartClass tsubpart5 = (SubPartClass) new TextPartClass("Library: " + str1, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.rl2TextId = this.AddSubPart(ref tsubpart5, 850, 369, 400, 20, 0);
      string str2 = this.game.Data.ReinfId[this.DetailNr].ToString();
      this.ss = "Change ID";
      tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.rl3id = this.AddSubPart(ref tsubpart5, 800, 410, 32, 16, 1);
      tsubpart5 = (SubPartClass) new TextPartClass("ID: " + str2, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.rl3TextId = this.AddSubPart(ref tsubpart5, 850, 409, 400, 20, 0);
    }

    private void maketabsheetnr5()
    {
      int index1 = 0;
      do
      {
        string tDescript = "Click to set which game variable can be changed as a variant of scenario in setup (-1=n/a)";
        int[] vari = this.vari;
        int index2 = index1;
        SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: tDescript);
        int num1 = this.AddSubPart(ref tsubpart1, 20, 330 + index1 * 20, 32, 16, 1);
        vari[index2] = num1;
        int[] vare = this.vare;
        int index3 = index1;
        SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: "Click to change the event coupled to this variant");
        int num2 = this.AddSubPart(ref tsubpart2, 500, 330 + index1 * 20, 32, 16, 1);
        vare[index3] = num2;
        string txt;
        if (this.game.Data.Variants[index1] == -1)
          txt = "No Variant Option";
        else
          txt = "Option (slot=" + Strings.Trim(Conversion.Str((object) this.game.Data.Variants[index1])) + ", ev=" + Conversion.Str((object) this.game.Data.VariantEvent[index1]) + ") slotname= " + this.game.Data.GameSlotName[this.game.Data.Variants[index1]];
        int[] variText = this.variText;
        int index4 = index1;
        SubPartClass tsubpart3 = (SubPartClass) new TextPartClass(txt, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: tDescript);
        int num3 = this.AddSubPart(ref tsubpart3, 60, 330 + index1 * 20, 400, 20, 0);
        variText[index4] = num3;
        ++index1;
      }
      while (index1 <= 11);
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
label_645:
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num1 = this.SubPartID[index1];
            if (num1 == this.OptionsListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.TabSheetNr = num2;
                this.DetailNr = -1;
                this.MakeFirst();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a36id)
            {
              this.game.Data.ScenarioDir = Interaction.InputBox("Give New Scenario Dir", "Shadow Empire : Planetary Conquest");
              this.MakeFirst();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a36bid)
            {
              this.game.Data.SoundDir = Interaction.InputBox("Give New Sound Dir", "Shadow Empire : Planetary Conquest");
              this.MakeFirst();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B3Id)
            {
              this.game.Data.SetDefaultRules();
              this.MakeFirst();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.StringListId)
            {
              int num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num3 > -1)
              {
                this.DetailNr = num3;
                this.maketabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.libListId)
            {
              int num4 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num4 > -1 | num4 == -2)
              {
                if (num4 == -2)
                  num4 = -1;
                this.libNr = num4;
                this.maketabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.StringList2Id)
            {
              int num5 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num5 > -1)
              {
                this.detailnr2 = num5;
                this.maketabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B1Id)
            {
              string str = Interaction.InputBox("Give New String Name", "Shadow Empire : Planetary Conquest");
              if (this.TabSheetNr == 0)
                this.game.Data.TempString[this.DetailNr] = str;
              if (this.TabSheetNr == 1)
                this.game.Data.GameSlotName[this.DetailNr] = str;
              if (this.TabSheetNr == 2)
                this.game.Data.RegimeSlotName[this.DetailNr] = str;
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b4id)
            {
              float num6 = (float) Conversion.Val(Interaction.InputBox("Give Value", "Shadow Empire : Planetary Conquest"));
              if ((double) num6 > -2.0 & (double) num6 < 999999.0)
              {
                this.game.Data.RuleVar[this.DetailNr] = num6;
              }
              else
              {
                int num7 = (int) Interaction.MsgBox((object) "Value out of bounds -1 to 999999", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a1Id)
            {
              this.game.Data.Name = Interaction.InputBox("Give New Scenario Name", "Shadow Empire : Planetary Conquest");
              this.MakeFirst();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a53id)
            {
              this.game.Data.scenarioVersion = Interaction.InputBox("Give New Scenario Version String", "Shadow Empire : Planetary Conquest", this.game.Data.scenarioVersion);
              this.MakeFirst();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.rl1id)
            {
              this.game.Data.ReinfName[this.DetailNr] = Interaction.InputBox("Give new name", "Shadow Empire : Planetary Conquest");
              this.game.Data.ReinfRatio[this.DetailNr] = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new ratio", "Shadow Empire : Planetary Conquest")));
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a44id)
            {
              this.game.Data.RuleSetName = Interaction.InputBox("Give New Ruleset Name", "Shadow Empire : Planetary Conquest");
              this.MakeFirst();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a32Id)
            {
              this.game.Data.SystemGfx = Interaction.InputBox("Give New System Gfx Overload Directory", "Shadow Empire : Planetary Conquest");
              BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
              this.game.Data.LoadGraphics((Form1) null);
              this.MakeFirst();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.p1id)
            {
              this.game.FormRef.Cursor = Cursors.WaitCursor;
              this.PdfUnitModels();
              this.game.FormRef.Cursor = Cursors.Default;
              int num8 = (int) Interaction.MsgBox((object) "Done!", Title: ((object) "Shadow Empire : Planetary Conquest"));
              this.MakeFirst();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.p2id)
            {
              this.game.FormRef.Cursor = Cursors.WaitCursor;
              this.PdfReinforcements();
              this.game.FormRef.Cursor = Cursors.Default;
              int num9 = (int) Interaction.MsgBox((object) "Done!", Title: ((object) "Shadow Empire : Planetary Conquest"));
              this.MakeFirst();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a30Id)
            {
              if (this.game.Data.UseAI == 1)
                this.game.Data.UseAI = 2;
              else
                this.game.Data.UseAI = 1;
              this.MakeFirst();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.l1id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 107, this.DetailNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.l2id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 108, this.DetailNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.rl2id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 129, this.DetailNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.rl3id)
            {
              this.game.Data.ReinfId[this.DetailNr] = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new ID", "Shadow Empire : Planetary Conquest")));
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a31Id)
            {
              if (this.game.Data.CampaignRoom == -1)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 38, 0);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              this.game.Data.CampaignRoom = -1;
              this.MakeFirst();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a19Id)
            {
              string str = this.game.HandyFunctionsObj.LoadSomething("All files (*.*)|*.*", "Pick a graphic... press cancel to delete the overlay graphic. graphic selected must be in graphics directory", this.game.AppPath + "graphics/", true);
              if (File.Exists(this.game.AppPath + "graphics/" + str))
              {
                this.game.Data.PermanentOverlayName = str;
                this.game.Data.PermanentOverlayUse = true;
                this.game.Data.LoadSprites();
              }
              else
              {
                int num10 = (int) Interaction.MsgBox((object) "Could not find graphic. Make sure its located inside the ''graphics'' directory", Title: ((object) "Shadow Empire : Planetary Conquest"));
                this.game.Data.PermanentOverlayUse = false;
                this.game.Data.PermanentOverlayName = "systemgraphics/trans.bmp";
                this.game.Data.LoadSprites();
              }
            }
            else
            {
              if (num1 == this.a17Id)
              {
                new Form2((Form) this.formref).Initialize(this.game.Data, 2, -1);
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a2Id)
              {
                this.game.Data.ShrowdOn = !this.game.Data.ShrowdOn;
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a22Id)
              {
                this.game.Data.GameSlotShow[this.DetailNr] = !this.game.Data.GameSlotShow[this.DetailNr];
                this.maketabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a22bId)
              {
                this.game.Data.GameSlotShow2[this.DetailNr] = !this.game.Data.GameSlotShow2[this.DetailNr];
                this.maketabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a38id)
              {
                int num11 = (int) Math.Round(Conversion.Val(Interaction.InputBox("NATO number, 0=cancel", "Shadow Empire : Planetary Conquest")));
                if (num11 > -1 & num11 <= this.game.NATO.GetUpperBound(0))
                  this.game.Data.RegimeSlotNato[this.DetailNr] = num11;
                int num12 = (int) Math.Round(Conversion.Val(Interaction.InputBox("SmallGfx number, -1=cancel (is smallgfx>-1 it will overrule any NATO setting)", "Shadow Empire : Planetary Conquest")));
                if (num12 >= -1 & num12 <= this.game.Data.SmallPicCounter)
                  this.game.Data.RegimeSlotSmallGfx[this.DetailNr] = num12;
                this.maketabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a38bid)
              {
                int num13 = (int) Math.Round(Conversion.Val(Interaction.InputBox("NATO number, 0=cancel", "Shadow Empire : Planetary Conquest")));
                if (num13 > -1 & num13 <= this.game.NATO.GetUpperBound(0))
                  this.game.Data.GameSlotNato[this.DetailNr] = num13;
                int num14 = (int) Math.Round(Conversion.Val(Interaction.InputBox("SmallGfx number, -1=cancel (is smallgfx>-1 it will overrule any NATO setting)", "Shadow Empire : Planetary Conquest")));
                if (num14 >= -1 & num14 <= this.game.Data.SmallPicCounter)
                  this.game.Data.GameSlotSmallGfx[this.DetailNr] = num14;
                this.maketabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a23Id)
              {
                this.game.Data.RegimeSlotShow[this.DetailNr] = !this.game.Data.RegimeSlotShow[this.DetailNr];
                this.maketabsheet();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a3Id)
              {
                this.game.Data.FOWOn = !this.game.Data.FOWOn;
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a24Id)
              {
                this.game.Data.NoPlayChoice = !this.game.Data.NoPlayChoice;
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a25Id)
              {
                this.game.Data.NoAIAdvice = !this.game.Data.NoAIAdvice;
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a4Id)
              {
                this.game.Data.LoadPass = Interaction.InputBox("Give Load Password", "Shadow Empire : Planetary Conquest");
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a26Id)
              {
                this.game.Data.Designer = Interaction.InputBox("Give Designer Name", "Shadow Empire : Planetary Conquest");
                this.game.Data.Designer2 = Interaction.InputBox("Give 2nd Designer Name", "Shadow Empire : Planetary Conquest");
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a5Id)
              {
                this.game.Data.EditPass = Interaction.InputBox("Give Edit Password", "Shadow Empire : Planetary Conquest");
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a37id)
              {
                string filename = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to load...", this.game.AppPath, true);
                if (File.Exists(this.game.AppPath + filename))
                {
                  this.game.HandyFunctionsObj.LoadHistoricalUnits(filename);
                  int num15 = (int) Interaction.MsgBox((object) "Succesfull", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.game.Data.LoadGraphics((Form1) null);
                }
                else
                {
                  int num16 = (int) Interaction.MsgBox((object) "Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a41id)
              {
                string filename = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to load from...", this.game.AppPath, true);
                if (File.Exists(this.game.AppPath + filename))
                {
                  this.game.HandyFunctionsObj.LoadSFTypes(filename);
                  int num17 = (int) Interaction.MsgBox((object) "Succesfull", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.game.Data.LoadGraphics((Form1) null);
                }
                else
                {
                  int num18 = (int) Interaction.MsgBox((object) "Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a46id)
              {
                string filename = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to load from...", this.game.AppPath, true);
                if (File.Exists(this.game.AppPath + filename))
                {
                  this.game.HandyFunctionsObj.LoadItemTypes(filename);
                  int num19 = (int) Interaction.MsgBox((object) "Succesfull", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.game.Data.LoadGraphics((Form1) null);
                }
                else
                {
                  int num20 = (int) Interaction.MsgBox((object) "Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a47id)
              {
                string filename = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to load from...", this.game.AppPath, true);
                if (File.Exists(this.game.AppPath + filename))
                {
                  this.game.HandyFunctionsObj.LoadResearch(filename);
                  int num21 = (int) Interaction.MsgBox((object) "Succesfull", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.game.Data.LoadGraphics((Form1) null);
                }
                else
                {
                  int num22 = (int) Interaction.MsgBox((object) "Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a48id)
              {
                string filename = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to load from...", this.game.AppPath, true);
                if (File.Exists(this.game.AppPath + filename))
                {
                  this.game.HandyFunctionsObj.LoadLocTypes(filename);
                  int num23 = (int) Interaction.MsgBox((object) "Succesfull", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.game.Data.LoadGraphics((Form1) null);
                }
                else
                {
                  int num24 = (int) Interaction.MsgBox((object) "Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a49id)
              {
                string filename = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to load from...", this.game.AppPath, true);
                if (File.Exists(this.game.AppPath + filename))
                {
                  this.game.HandyFunctionsObj.LoadLandscapeTypes(filename);
                  int num25 = (int) Interaction.MsgBox((object) "Succesfull", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.game.Data.LoadGraphics((Form1) null);
                }
                else
                {
                  int num26 = (int) Interaction.MsgBox((object) "Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a51id)
              {
                string filename = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to load from...", this.game.AppPath, true);
                if (File.Exists(this.game.AppPath + filename))
                {
                  this.game.HandyFunctionsObj.LoadUnitsByFullOverwrite(filename);
                  int num27 = (int) Interaction.MsgBox((object) "Succesfull", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.game.Data.LoadGraphics((Form1) null);
                }
                else
                {
                  int num28 = (int) Interaction.MsgBox((object) "Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a50id)
              {
                string filename = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to load from...", this.game.AppPath, true);
                if (File.Exists(this.game.AppPath + filename))
                {
                  this.game.HandyFunctionsObj.LoadGameVars(filename);
                  int num29 = (int) Interaction.MsgBox((object) "Succesfull", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.game.Data.LoadGraphics((Form1) null);
                }
                else
                {
                  int num30 = (int) Interaction.MsgBox((object) "Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a52id)
              {
                string filename = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to load from...", this.game.AppPath, true);
                if (File.Exists(this.game.AppPath + filename))
                {
                  this.game.HandyFunctionsObj.LoadMap(filename);
                  int num31 = (int) Interaction.MsgBox((object) "Succesfull", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                {
                  int num32 = (int) Interaction.MsgBox((object) "Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a6Id)
              {
                string str = this.game.HandyFunctionsObj.LoadSomething("SE1 Master file(*.se1master)|*.se1master", "Pick a masterfile please...", this.game.AppPath + this.game.ModScenarioDir, false);
                if (File.Exists(str))
                {
                  this.game.Data.MasterfileReadPeople = true;
                  bool alsohistorical = Interaction.MsgBox((object) "Read Historical units too?... Not reading them works only in the editor import like now!", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes;
                  bool LoadGameVars = Interaction.MsgBox((object) "Read gamevars 0-399 (never 400-499)?.... reading them only works in editor import like now", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes;
                  bool LoadVariants = Interaction.MsgBox((object) "Read variants? ..... not reading them only works in editor import like now.", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes;
                  this.game.FormRef.Cursor = Cursors.WaitCursor;
                  this.game.HandyFunctionsObj.LoadMasterFile(str, alsohistorical: alsohistorical, LoadGameVars: LoadGameVars, LoadVariants: LoadVariants);
                  BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                  this.game.Data.LoadGraphics((Form1) null);
                  int num33 = (int) Interaction.MsgBox((object) "Scenario has gotten all input from it's masterfile", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.game.Data.MasterFile = this.game.HandyFunctionsObj.ReturnShortMaster(str);
                  this.game.FormRef.Cursor = Cursors.Default;
                  if (Interaction.MsgBox((object) "Do you want to keep this file as a masterfile attached to your scenario? (or was it just for import data)", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                  {
                    int num34 = (int) Interaction.MsgBox((object) "Masterfile stays attached", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    int num35 = (int) Interaction.MsgBox((object) "Masterfile is not attached (we just imported data)", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    this.game.Data.MasterFile = "";
                  }
                }
                else
                {
                  int num36 = (int) Interaction.MsgBox((object) "Masterfile has been removed", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.game.Data.MasterFile = "";
                }
                this.MakeFirst();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.a40id)
              {
                string str = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a file...", this.game.AppPath_SAVEGAMES, false);
                if (File.Exists(str))
                {
                  this.game.FormRef.Cursor = Cursors.WaitCursor;
                  this.game.EditObj.TutMode = false;
                  if (this.game.Data.UseAI == 1)
                    this.game.NewAIObj.LastRegime = -1;
                  this.game.SelectX = -1;
                  this.game.SelectY = -1;
                  this.game.Data = new DataClass();
                  GC.Collect();
                  Application.DoEvents();
                  this.game.HandyFunctionsObj.Unzip(str);
                  this.game.Data = DataClass.deserialize(str);
                  this.game.HandyFunctionsObj.ZipFile(str);
                  if (!this.game.Data.Loadable & !this.game.SuperAdminRights)
                  {
                    int num37 = (int) Interaction.MsgBox((object) "Sorry. This saved game is not loadable. we'll quit the editor now.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    this.game.EditObj.ShowInitialMenu = true;
                    this.game.FormRef.Cursor = Cursors.Default;
                    windowReturnClass.AddCommand(3, 1);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  this.game.Data.Round = 0;
                  this.game.Data.Turn = 0;
                  if ((double) this.game.Data.RuleVar[344] == 1.0 & this.game.EditObj.HideUnit == 0)
                    this.game.EditObj.HideUnit = 2;
                  this.game.EditObj.TempValue = new MapMatrix2[this.game.Data.MapCounter + 1];
                  this.game.EditObj.TempValue2 = new MapMatrix2[this.game.Data.MapCounter + 1];
                  int mapCounter = this.game.Data.MapCounter;
                  for (int index2 = 0; index2 <= mapCounter; ++index2)
                  {
                    this.game.EditObj.TempValue[index2] = new MapMatrix2(this.game.Data.MapObj[index2].MapWidth, this.game.Data.MapObj[index2].MapHeight);
                    this.game.EditObj.TempValue2[index2] = new MapMatrix2(this.game.Data.MapObj[index2].MapWidth, this.game.Data.MapObj[index2].MapHeight);
                  }
                  if (Strings.Len(this.game.Data.LoadPass) > 0)
                  {
                    this.game.FormRef.Cursor = Cursors.Default;
                    if (Operators.CompareString(Strings.LCase(Interaction.InputBox("This File is protected by a load password. Please give it in order to load it.", "Shadow Empire : Planetary Conquest")), Strings.LCase(this.game.Data.LoadPass), false) == 0)
                    {
                      int num38 = (int) Interaction.MsgBox((object) "You are cleared.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    else
                    {
                      int num39 = (int) Interaction.MsgBox((object) "Wrong Password. You cannot Load this file. Exiting whole app.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      ProjectData.EndApp();
                    }
                  }
                  BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                  this.game.Data.LoadGraphics((Form1) null);
                  this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 200, 150, false);
                  this.game.EditObj.StratMap = new Bitmap(this.game.ScreenWidth, this.game.ScreenHeight - 265);
                  this.game.EditObj.StratMap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
                  this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.StratMap, this.game.ScreenWidth, this.game.ScreenHeight - 265, false, true, false);
                  this.game.FormRef.Cursor = Cursors.Default;
                  int num40 = (int) Interaction.MsgBox((object) "Saved game is loaded. Round set to 0. Turn set to 0.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.game.EditObj.MiddleWindow = true;
                  this.MakeFirst();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
              }
              else
              {
                if (num1 == this.a7Id)
                {
                  int num41 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give VP Win Condition. -1 for no VP win.", "Shadow Empire : Planetary Conquest")));
                  if (num41 < -1 | num41 > 9999)
                  {
                    int num42 = (int) Interaction.MsgBox((object) "Between -1 and 9999 please.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                    this.game.Data.VPWin = num41;
                  this.MakeFirst();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.rrid)
                {
                  int num43 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new reinf.ratio. standard = 1 ", "Shadow Empire : Planetary Conquest")));
                  if (num43 < 1 | num43 > 99999)
                  {
                    int num44 = (int) Interaction.MsgBox((object) "Between 1 and 99999.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                    this.game.Data.ReinfRatio[this.DetailNr - 750] = num43;
                  this.MakeFirst();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.a23bId)
                {
                  int num45 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give show value. 0=default.1=show all.2=only self.3=self+allies.-1=nobody", "Shadow Empire : Planetary Conquest")));
                  if (num45 < -1 | num45 > 3)
                  {
                    int num46 = (int) Interaction.MsgBox((object) "Between -1 and 3 please.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                    this.game.Data.RegimeSlotShow2[this.DetailNr] = num45;
                  this.MakeFirst();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.a8Id)
                {
                  this.game.Data.PasswordsOn = !this.game.Data.PasswordsOn;
                  this.MakeFirst();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.a27Id)
                {
                  this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop = !this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop;
                  if ((this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 10) % 2 == 0)
                  {
                    this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop = false;
                    int num47 = (int) Interaction.MsgBox((object) "Mapwidth must be an even number of hexes in order to allow maploop.");
                  }
                  this.MakeFirst();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.a28Id)
                {
                  int usetype = (int) Math.Round(Conversion.Val(Interaction.InputBox("Use color (1=white, 2= blue, 3=black, 4=red, 5=yellow)", "Shadow Empire : Planetary Conquest")));
                  if (usetype > 0 & usetype < 6)
                  {
                    this.game.HandyFunctionsObj.MakeAutoLabels(usetype);
                    int num48 = (int) Interaction.MsgBox((object) "Done. Set labels on map based on names of hexes and locations.");
                  }
                }
                else if (num1 == this.a29Id)
                {
                  int mapWidth = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
                  for (int index3 = 0; index3 <= mapWidth; ++index3)
                  {
                    int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
                    for (int index4 = 0; index4 <= mapHeight; ++index4)
                    {
                      this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index3, index4].LabelText1 = "";
                      this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index3, index4].LabelText2 = "";
                      this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index3, index4].LabelType1 = 0;
                      this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index3, index4].LabelType2 = 0;
                    }
                  }
                  int num49 = (int) Interaction.MsgBox((object) "Removed all labels");
                }
                else
                {
                  if (num1 == this.a10Id)
                  {
                    int tempint = (int) Math.Round(Conversion.Val(Interaction.InputBox("Add/Remove howmany x? Give negative value for removing", "Shadow Empire : Planetary Conquest")));
                    int num50 = (int) Interaction.MsgBox((object) "At right side of map? (no = on left side)", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest");
                    if (tempint > 0 & tempint < 100)
                    {
                      if (num50 == 6)
                      {
                        this.game.HandyFunctionsObj.AddXToMap(tempint);
                        int num51 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      else if ((Math.Abs(tempint) + 10) % 2 == 0)
                      {
                        this.game.HandyFunctionsObj.AddXToMapLeft(tempint);
                        int num52 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      else
                      {
                        int num53 = (int) Interaction.MsgBox((object) "Some misconfiguration. Make sure adding width left of map must be even number.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                    }
                    else if (tempint < 0 & Math.Abs(tempint) < this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
                    {
                      if (num50 == 6)
                      {
                        this.game.HandyFunctionsObj.RemoveXToMap(Math.Abs(tempint));
                        int num54 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      else if ((Math.Abs(tempint) + 10) % 2 == 0)
                      {
                        this.game.HandyFunctionsObj.RemoveXToMapLeft(Math.Abs(tempint));
                        int num55 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      else
                      {
                        int num56 = (int) Interaction.MsgBox((object) "Some misconfiguration. Make sure removing width left of map must be even number.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                    }
                    else
                    {
                      int num57 = (int) Interaction.MsgBox((object) "between 0 and 100 please", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    if ((this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 10) % 2 == 0 & this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop)
                    {
                      this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop = false;
                      int num58 = (int) Interaction.MsgBox((object) "Mapwidth must be an even number of hexes in order to allow maploop. Switched of maploop");
                    }
                    this.MakeFirst();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.a11Id)
                  {
                    int tempint = (int) Math.Round(Conversion.Val(Interaction.InputBox("Add howmany y?", "Shadow Empire : Planetary Conquest")));
                    int num59 = (int) Interaction.MsgBox((object) "At bottom side of map? (no = on top side)", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest");
                    if (tempint > 0 & tempint < 100)
                    {
                      switch (num59)
                      {
                        case 6:
                          this.game.HandyFunctionsObj.AddYToMap(tempint);
                          int num60 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                          break;
                        case 7:
                          this.game.HandyFunctionsObj.AddYToMapLeft(tempint);
                          int num61 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                          break;
                        default:
                          int num62 = (int) Interaction.MsgBox((object) "Some misconfiguration. Make sure adding width left of map must be even number.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                          break;
                      }
                    }
                    else if (tempint < 0 & Math.Abs(tempint) < this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
                    {
                      switch (num59)
                      {
                        case 6:
                          this.game.HandyFunctionsObj.RemoveYToMap(Math.Abs(tempint));
                          int num63 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                          break;
                        case 7:
                          this.game.HandyFunctionsObj.RemoveYToMapLeft(Math.Abs(tempint));
                          int num64 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                          break;
                        default:
                          int num65 = (int) Interaction.MsgBox((object) "Some misconfiguration. Make sure removing width left of map must be even number.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                          break;
                      }
                    }
                    else
                    {
                      int num66 = (int) Interaction.MsgBox((object) "between 0 and 100 please", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    this.MakeFirst();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.a12Id)
                  {
                    int num67 = (int) Math.Round(Conversion.Val(Interaction.InputBox("You should keep this value at '0' if at all possible. Higher values are considered 'beta status'. Regime that has to start?", "Shadow Empire : Planetary Conquest")));
                    if (num67 > -1 & num67 <= this.game.Data.RegimeCounter)
                      this.game.Data.Turn = num67 - 1;
                    this.MakeFirst();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.a34Id)
                  {
                    if (this.game.SuperAdminRights)
                      this.game.Data.Product = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Product #", "Shadow Empire : Planetary Conquest")));
                    else if (Operators.CompareString(Interaction.InputBox("This setting is not for public use. sorry. press enter.", "Shadow Empire : Planetary Conquest"), "ChristalClear", false) == 0)
                      this.game.Data.Product = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Product #", "Shadow Empire : Planetary Conquest")));
                    this.MakeFirst();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.a33Id)
                  {
                    bool flag1;
                    if (Interaction.MsgBox((object) "add staff until same ammount as needed by troops ", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                      flag1 = true;
                    bool flag2;
                    if (Interaction.MsgBox((object) "remove staff as well if more then troops need? ", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                      flag2 = true;
                    bool flag3;
                    if (Interaction.MsgBox((object) "add staff until same ammount as officer staff level? ", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                      flag3 = true;
                    bool flag4;
                    if (Interaction.MsgBox((object) "adjust staff officer staff level to staff present in HQ? ", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                      flag4 = true;
                    int unitCounter = this.game.Data.UnitCounter;
                    for (int unr = 0; unr <= unitCounter; ++unr)
                    {
                      if (this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].IsHQ && this.game.HandyFunctionsObj.GetStaffPoints(unr) > 0)
                      {
                        int num68 = 0;
                        if (flag1)
                        {
                          while (num68 == 0 & (double) this.game.HandyFunctionsObj.GetStaffPoints(unr) < 1.0 * (double) this.game.HandyFunctionsObj.GetStaffNeeded(unr))
                          {
                            num68 = 1;
                            int sfCount = this.game.Data.UnitObj[unr].SFCount;
                            for (int index5 = 0; index5 <= sfCount; ++index5)
                            {
                              int sf = this.game.Data.UnitObj[unr].SFList[index5];
                              if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].StaffPts > 0)
                              {
                                this.game.HandyFunctionsObj.AddTroops3(unr, this.game.Data.SFObj[sf].Type, this.game.Data.SFObj[sf].People, 1, this.game.Data.SFObj[sf].Xp, this.game.Data.SFObj[sf].Rdn, this.game.Data.SFObj[sf].Ap, this.game.Data.SFObj[sf].Mor, Ep: this.game.Data.SFObj[sf].MoveType);
                                num68 = 0;
                                break;
                              }
                            }
                          }
                        }
                        int num69 = 0;
                        if (flag2)
                        {
                          while (num69 == 0 & (double) this.game.HandyFunctionsObj.GetStaffPoints(unr) > 1.05 * (double) this.game.HandyFunctionsObj.GetStaffNeeded(unr))
                          {
                            num69 = 1;
                            int sfCount = this.game.Data.UnitObj[unr].SFCount;
                            for (int index6 = 0; index6 <= sfCount; ++index6)
                            {
                              int sf = this.game.Data.UnitObj[unr].SFList[index6];
                              if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].StaffPts > 0 && this.game.Data.SFObj[sf].Qty > 2)
                              {
                                this.game.HandyFunctionsObj.RemoveTroops(unr, this.game.Data.SFObj[sf].Type, this.game.Data.SFObj[sf].People, 1, this.game.Data.SFObj[sf].MoveType);
                                num69 = 0;
                                break;
                              }
                            }
                          }
                        }
                        int num70 = 0;
                        if (flag3)
                        {
                          while (num70 == 0 & (double) this.game.HandyFunctionsObj.GetStaffPoints(unr) < 1.0 * (double) this.game.HandyFunctionsObj.GetStaffNeeded(unr))
                          {
                            num70 = 1;
                            int sfCount = this.game.Data.UnitObj[unr].SFCount;
                            for (int index7 = 0; index7 <= sfCount; ++index7)
                            {
                              int sf = this.game.Data.UnitObj[unr].SFList[index7];
                              if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].StaffPts > 0)
                              {
                                this.game.HandyFunctionsObj.AddTroops3(unr, this.game.Data.SFObj[sf].Type, this.game.Data.SFObj[sf].People, 1, this.game.Data.SFObj[sf].Xp, this.game.Data.SFObj[sf].Rdn, this.game.Data.SFObj[sf].Ap, this.game.Data.SFObj[sf].Mor, MoveType: this.game.Data.SFObj[sf].MoveType);
                                num70 = 0;
                                break;
                              }
                            }
                          }
                        }
                        if (flag4 && this.game.Data.UnitObj[unr].Historical > -1)
                        {
                          int historical = this.game.Data.UnitObj[unr].Historical;
                          this.game.Data.HistoricalUnitObj[historical].StaffSize = this.game.HandyFunctionsObj.GetStaffNeeded(unr);
                          HistoricalUnitClass[] historicalUnitObj = this.game.Data.HistoricalUnitObj;
                          HistoricalUnitClass[] historicalUnitClassArray = historicalUnitObj;
                          int index8 = historical;
                          int index9 = index8;
                          historicalUnitClassArray[index9].StaffSize = historicalUnitObj[index8].StaffSize + (50 - this.game.Data.HistoricalUnitObj[historical].StaffSize % 50);
                        }
                      }
                    }
                    int num71 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    this.MakeFirst();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.a13Id)
                  {
                    this.game.HandyFunctionsObj.SetAllReady(true);
                    this.MakeFirst();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.a35id)
                  {
                    StreamWriter text1 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_Description.txt");
                    text1.Write(this.game.Data.Name);
                    text1.Write("\r\n");
                    text1.Write("\r\n");
                    text1.Write(this.game.Data.Description);
                    text1.Close();
                    StreamWriter text2 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_ActionCards.txt");
                    int actionCardCounter1 = this.game.Data.ActionCardCounter;
                    for (int index10 = 0; index10 <= actionCardCounter1; ++index10)
                    {
                      if (Strings.InStr(this.game.Data.ActionCardObj[index10].Title, "Empty") <= 0)
                      {
                        text2.Write(this.game.Data.ActionCardObj[index10].Title);
                        text2.Write("\r\n");
                        text2.Write(this.game.Data.ActionCardObj[index10].Text);
                        text2.Write("\r\n");
                        text2.Write("\r\n");
                      }
                    }
                    text2.Close();
                    StreamWriter text3 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_SFTypes.txt");
                    int sfTypeCounter1 = this.game.Data.SFTypeCounter;
                    for (int index11 = 0; index11 <= sfTypeCounter1; ++index11)
                    {
                      text3.Write(this.game.Data.SFTypeObj[index11].Name);
                      text3.Write("\r\n");
                      text3.Write(this.game.Data.SFTypeObj[index11].Description);
                      text3.Write("\r\n");
                      text3.Write("\r\n");
                    }
                    text3.Close();
                    StreamWriter text4 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_SFTypes_SupplyStats.csv");
                    string str1 = "Based-on,SupplyCarry,SupplyMaxIn,BasicSupplyNeed,SupplyForAttack_100AP,SupplyForDefense_100AP,FuelCarry,FuelForMove_10AP,FuelForAttack_10AP,FuelForDefense_10AP";
                    text4.Write(str1);
                    text4.Write("\r\n");
                    int sfTypeCounter2 = this.game.Data.SFTypeCounter;
                    for (int index12 = 0; index12 <= sfTypeCounter2; ++index12)
                    {
                      string str2 = this.game.Data.SFTypeObj[index12].Name + "," + this.game.Data.SFTypeObj[index12].SupplyCarry.ToString() + "," + this.game.Data.SFTypeObj[index12].SupplyMaxIn.ToString() + "," + this.game.Data.SFTypeObj[index12].BasicSupplyNeed.ToString() + "," + this.game.Data.SFTypeObj[index12].SupplyForAttack.ToString() + "," + this.game.Data.SFTypeObj[index12].SupplyForAttackDef.ToString() + "," + this.game.Data.SFTypeObj[index12].FuelCarry.ToString() + "," + this.game.Data.SFTypeObj[index12].FuelForMove.ToString() + "," + this.game.Data.SFTypeObj[index12].FuelForAttack.ToString() + "," + this.game.Data.SFTypeObj[index12].FuelForAttackDef.ToString();
                      text4.Write(str2);
                      text4.Write("\r\n");
                    }
                    text4.Close();
                    StreamWriter text5 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_shortSFTypes.txt");
                    int sfTypeCounter3 = this.game.Data.SFTypeCounter;
                    for (int Number = 0; Number <= sfTypeCounter3; ++Number)
                    {
                      text5.Write(Strings.Trim(Conversion.Str((object) Number)) + ", " + this.game.Data.SFTypeObj[Number].Name);
                      text5.Write("\r\n");
                    }
                    text5.Close();
                    StreamWriter text6 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_historicalunitsmodels.txt");
                    int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
                    for (int Number = 0; Number <= historicalUnitCounter1; ++Number)
                    {
                      if (this.game.Data.HistoricalUnitObj[Number].Model)
                      {
                        text6.Write(Strings.Trim(Conversion.Str((object) Number)) + ", " + this.game.Data.HistoricalUnitObj[Number].Name);
                        text6.Write("\r\n");
                      }
                    }
                    text6.Close();
                    StreamWriter text7 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_rulevarchangesinevents.txt");
                    int eventCounter1 = this.game.Data.EventCounter;
                    for (int Number = 0; Number <= eventCounter1; ++Number)
                    {
                      int commandCounter = this.game.Data.EventObj[Number].CommandCounter;
                      for (int index13 = 0; index13 <= commandCounter; ++index13)
                      {
                        if (this.game.Data.EventObj[Number].CommandList[index13].type == 3 && Conversions.ToDouble(this.game.Data.EventObj[Number].CommandList[index13].Data[0, 1]) == 31.0)
                        {
                          int integer = Conversions.ToInteger(this.game.Data.EventObj[Number].CommandList[index13].Data[0, 5]);
                          if (integer > -1)
                          {
                            text7.Write(Conversion.Str((object) integer) + ") " + this.game.Data.RuleString[integer] + " => in mess: " + Conversion.Str((object) Number) + ") " + this.game.Data.EventObj[Number].Name);
                            text7.Write("\r\n");
                          }
                        }
                      }
                    }
                    text7.Close();
                    StreamWriter text8 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_messagepicturesused.txt");
                    int eventCounter2 = this.game.Data.EventCounter;
                    for (int Number = 0; Number <= eventCounter2; ++Number)
                    {
                      int commandCounter = this.game.Data.EventObj[Number].CommandCounter;
                      for (int index14 = 0; index14 <= commandCounter; ++index14)
                      {
                        if (this.game.Data.EventObj[Number].CommandList[index14].type == 3 && Conversions.ToDouble(this.game.Data.EventObj[Number].CommandList[index14].Data[0, 1]) == 11.0)
                        {
                          int integer = Conversions.ToInteger(this.game.Data.EventObj[Number].CommandList[index14].Data[0, 14]);
                          if (integer > -1 & integer < this.game.Data.EventPicCounter)
                          {
                            text8.Write(Conversion.Str((object) integer) + ") " + this.game.Data.EventPicName[integer] + " => in mess: " + Conversion.Str((object) Number) + ") " + this.game.Data.EventObj[Number].Name);
                            text8.Write("\r\n");
                          }
                        }
                      }
                    }
                    text8.Write("\r\n");
                    text8.Write("\r\n");
                    text8.Write("EVENT PICTURES IN MEMORY:");
                    text8.Write("\r\n");
                    int eventPicCounter = this.game.Data.EventPicCounter;
                    for (int index15 = 0; index15 <= eventPicCounter; ++index15)
                    {
                      if (Strings.InStr(this.game.Data.EventPicName[index15], "empty") <= 0)
                      {
                        text8.Write(this.game.Data.EventPicName[index15]);
                        text8.Write("\r\n");
                      }
                    }
                    text8.Write("\r\n");
                    text8.Write("\r\n");
                    text8.Write("ACTION CARDS USE WHICH EVENT PICTURES:");
                    text8.Write("\r\n");
                    int actionCardCounter2 = this.game.Data.ActionCardCounter;
                    for (int Number = 0; Number <= actionCardCounter2; ++Number)
                    {
                      int eventPicNr = this.game.Data.ActionCardObj[Number].EventPicNr;
                      if (eventPicNr > -1)
                      {
                        text8.Write("Card " + Conversion.Str((object) Number) + " : " + Conversion.Str((object) eventPicNr) + ") " + this.game.Data.EventPicName[eventPicNr]);
                        text8.Write("\r\n");
                      }
                    }
                    text8.Close();
                    StreamWriter text9 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_currentgraphicsloaded.txt");
                    int counter1 = BitmapStore.Counter;
                    for (int index16 = 0; index16 <= counter1; ++index16)
                    {
                      text9.Write(BitmapStore.tmpFileName[index16] + ", (" + Conversion.Str((object) BitmapStore.tmpOverloadCounter[index16]) + "x), Big=" + Conversion.Str((object) BitmapStore.tmpIsBig[index16]) + ", System=" + Conversion.Str((object) BitmapStore.tmpIsSystem[index16]));
                      text9.Write("\r\n");
                    }
                    text9.Close();
                    StreamWriter text10 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_unitnames.txt");
                    int unitCounter1 = this.game.Data.UnitCounter;
                    for (int index17 = 0; index17 <= unitCounter1; ++index17)
                    {
                      if (this.game.Data.UnitObj[index17].Historical > -1)
                        text10.Write(this.game.Data.UnitObj[index17].Name + "( " + this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index17].Historical].Name + ")");
                      else
                        text10.Write(this.game.Data.UnitObj[index17].Name + "( - )");
                      text10.Write("\r\n");
                    }
                    text10.Close();
                    StreamWriter text11 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_onMapOrderOfBattle.txt");
                    int regimeCounter1 = this.game.Data.RegimeCounter;
                    for (int index18 = 0; index18 <= regimeCounter1; ++index18)
                    {
                      text11.Write(this.game.Data.RegimeObj[index18].Name);
                      text11.Write("\r\n");
                      text11.Write("-----------------------------------------------------");
                      text11.Write("\r\n");
                      int unitCounter2 = this.game.Data.UnitCounter;
                      for (int index19 = 0; index19 <= unitCounter2; ++index19)
                      {
                        if (this.game.Data.UnitObj[index19].IsHQ & this.game.Data.UnitObj[index19].PreDef == -1 && this.game.Data.UnitObj[index19].Regime == index18)
                        {
                          text11.Write(this.game.Data.UnitObj[index19].Name.ToUpper());
                          text11.Write("\r\n");
                          int unitCounter3 = this.game.Data.UnitCounter;
                          for (int index20 = 0; index20 <= unitCounter3; ++index20)
                          {
                            if (!this.game.Data.UnitObj[index20].IsHQ & this.game.Data.UnitObj[index20].PreDef == -1 && this.game.Data.UnitObj[index20].HQ == index19)
                            {
                              text11.Write(" - " + this.game.Data.UnitObj[index20].Name);
                              text11.Write("\r\n");
                            }
                          }
                        }
                      }
                      text11.Write("-----------------------------------------------------");
                      text11.Write("\r\n");
                    }
                    text11.Close();
                    StreamWriter text12 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_missingsystemgraphics.txt");
                    int counter2 = BitmapStore.Counter;
                    for (int nr = 0; nr <= counter2; ++nr)
                    {
                      if (BitmapStore.tmpIsSystem[nr] && BitmapStore.GetWidth(nr) == 1 & BitmapStore.Getheight(nr) == 1)
                      {
                        text12.Write("\r\n");
                        text12.Write(BitmapStore.tmpFileName[nr]);
                      }
                    }
                    text12.Close();
                    StreamWriter text13 = File.CreateText(this.game.AppPath + "logs/checks.txt");
                    int checkTypeCount = this.game.Data.CheckTypeCount;
                    for (int Number = 0; Number <= checkTypeCount; ++Number)
                    {
                      if (!Information.IsNothing((object) this.game.Data.CheckTypeNames[Number]) && this.game.Data.CheckCategory[Number] > 0 & this.game.Data.CheckTypeNames[Number].Length > 1)
                      {
                        string str3 = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.game.Data.CheckTypeNames[Number] + "(";
                        int num72 = this.game.Data.CheckTypeVarCount[Number];
                        for (int index21 = 1; index21 <= num72; ++index21)
                        {
                          if (index21 > 1)
                            str3 += ",";
                          str3 = str3 + "[" + this.game.Data.CheckTypeVarName[Number, index21] + "]";
                        }
                        string str4 = str3 + ")";
                        if (!Information.IsNothing((object) this.game.Data.CheckDesc[Number]) && this.game.Data.CheckDesc[Number].Length > 1)
                          str4 = str4 + " : " + this.game.Data.CheckDesc[Number];
                        text13.Write(str4);
                        text13.Write("\r\n");
                      }
                    }
                    text13.Close();
                    StreamWriter text14 = File.CreateText(this.game.AppPath + "logs/execs.txt");
                    int execTypeCount1 = this.game.Data.ExecTypeCount;
                    for (int Number = 0; Number <= execTypeCount1; ++Number)
                    {
                      if (!Information.IsNothing((object) this.game.Data.ExecTypeNames[Number]) && this.game.Data.ExecCategory[Number] > 0 & this.game.Data.ExecTypeNames[Number].Length > 1)
                      {
                        string str5 = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.game.Data.ExecTypeNames[Number] + "(";
                        int num73 = this.game.Data.ExecTypeVarCount[Number];
                        for (int index22 = 1; index22 <= num73; ++index22)
                        {
                          if (index22 > 1)
                            str5 += ",";
                          str5 = str5 + "[" + this.game.Data.ExecTypeVarName[Number, index22] + "]";
                        }
                        string str6 = str5 + ")";
                        if (!Information.IsNothing((object) this.game.Data.ExecDesc[Number]) && this.game.Data.ExecDesc[Number].Length > 1)
                          str6 = str6 + " : " + this.game.Data.ExecDesc[Number];
                        text14.Write(str6);
                        text14.Write("\r\n");
                      }
                    }
                    text14.Close();
                    StreamWriter text15 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_historicalunitnames.txt");
                    int historicalUnitCounter2 = this.game.Data.HistoricalUnitCounter;
                    for (int index23 = 0; index23 <= historicalUnitCounter2; ++index23)
                    {
                      string str7 = "" + this.game.Data.HistoricalUnitObj[index23].Name + "," + this.game.Data.HistoricalUnitObj[index23].Type.ToString() + "," + this.game.Data.HistoricalUnitObj[index23].ID.ToString();
                      if (this.game.Data.HistoricalUnitObj[index23].LibId.libSlot > -1)
                        str7 = str7 + "," + this.game.Data.LibraryObj[this.game.Data.HistoricalUnitObj[index23].LibId.libSlot].name + "," + this.game.Data.HistoricalUnitObj[index23].LibId.id.ToString();
                      text15.Write(str7);
                      text15.Write("\r\n");
                    }
                    text15.Close();
                    StreamWriter text16 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_temp3temp4temp5systemDC2_historicalunits.txt");
                    int regimeCounter2 = this.game.Data.RegimeCounter;
                    for (int index24 = 0; index24 <= regimeCounter2; ++index24)
                    {
                      text16.WriteLine(this.game.Data.RegimeObj[index24].Name);
                      text16.WriteLine();
                      SimpleList simpleList = new SimpleList();
                      int historicalUnitCounter3 = this.game.Data.HistoricalUnitCounter;
                      for (int tid = 0; tid <= historicalUnitCounter3; ++tid)
                      {
                        if (this.game.Data.HistoricalUnitObj[tid].TempVar3 > 0 & this.game.Data.HistoricalUnitObj[tid].TempRegime == index24 & !this.game.Data.HistoricalUnitObj[tid].Model)
                          simpleList.Add(tid, this.game.Data.HistoricalUnitObj[tid].TempVar3 * 1000000 + this.game.Data.HistoricalUnitObj[tid].TempVar4 * 100 + this.game.Data.HistoricalUnitObj[tid].TempVar5 * 1, this.game.Data.HistoricalUnitObj[tid].TempVar3, this.game.Data.HistoricalUnitObj[tid].TempVar4, this.game.Data.HistoricalUnitObj[tid].TempVar5);
                      }
                      simpleList.Sort();
                      while (simpleList.Counter > -1)
                      {
                        int num74 = simpleList.Weight[0];
                        text16.Write(simpleList.Data3[0].ToString() + "-" + this.game.HandyFunctionsObj.GetMonth(simpleList.Data2[0]) + "-" + simpleList.Data1[0].ToString());
                        text16.WriteLine();
                        for (int counter3 = simpleList.Counter; counter3 >= 0; counter3 += -1)
                        {
                          if (num74 == simpleList.Weight[counter3])
                          {
                            text16.WriteLine("-" + this.game.Data.HistoricalUnitObj[simpleList.Id[counter3]].Name);
                            simpleList.RemoveNr(counter3);
                          }
                        }
                        text16.WriteLine();
                      }
                    }
                    text16.Close();
                    StreamWriter text17 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_presentscenariographics.txt");
                    int counter4 = BitmapStore.Counter;
                    for (int index25 = 0; index25 <= counter4; ++index25)
                    {
                      if (!BitmapStore.tmpIsSystem[index25])
                      {
                        text17.Write("\r\n");
                        text17.Write(BitmapStore.tmpFileName[index25]);
                      }
                    }
                    text17.Close();
                    StreamWriter text18 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_locationnames.txt");
                    int mapWidth = this.game.Data.MapObj[0].MapWidth;
                    for (int Number1 = 0; Number1 <= mapWidth; ++Number1)
                    {
                      int mapHeight = this.game.Data.MapObj[0].MapHeight;
                      for (int Number2 = 0; Number2 <= mapHeight; ++Number2)
                      {
                        int location = this.game.Data.MapObj[0].HexObj[Number1, Number2].Location;
                        if (location > -1)
                        {
                          text18.Write("LOC: " + this.game.Data.LocObj[location].Name + "   (" + Conversion.Str((object) Number1) + "," + Conversion.Str((object) Number2) + ", " + this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].Name + ")");
                          text18.Write("\r\n");
                        }
                        else if (!Information.IsNothing((object) this.game.Data.MapObj[0].HexObj[Number1, Number2].Name) && this.game.Data.MapObj[0].HexObj[Number1, Number2].Name.Length > 1)
                        {
                          text18.Write("HEX: " + this.game.Data.MapObj[0].HexObj[Number1, Number2].Name + "   (" + Conversion.Str((object) Number1) + "," + Conversion.Str((object) Number2) + ")");
                          text18.Write("\r\n");
                        }
                      }
                    }
                    text18.Close();
                    StreamWriter text19 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_commandernames.txt");
                    int historicalUnitCounter4 = this.game.Data.HistoricalUnitCounter;
                    for (int index26 = 0; index26 <= historicalUnitCounter4; ++index26)
                    {
                      if (Strings.Len(this.game.Data.HistoricalUnitObj[index26].CommanderName) > 1)
                      {
                        text19.Write(this.game.Data.HistoricalUnitObj[index26].CommanderName + ", " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[index26].CombatMod) + ", " + Conversion.Str((object) this.game.Data.HistoricalUnitObj[index26].PP));
                        text19.Write("\r\n");
                        text19.Write("\r\n");
                        text19.Write(this.game.Data.HistoricalUnitObj[index26].Descript);
                        text19.Write("\r\n");
                        text19.Write("\r\n");
                      }
                    }
                    text19.Close();
                    StreamWriter text20 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_landscapetypes_linkedgraphics.txt");
                    int landscapeTypeCounter = this.game.Data.LandscapeTypeCounter;
                    for (int index27 = 0; index27 <= landscapeTypeCounter; ++index27)
                    {
                      text20.Write(this.game.Data.LandscapeTypeObj[index27].Name);
                      text20.Write("\r\n");
                      text20.Write("PreHexPicFileName = " + this.game.Data.LandscapeTypeObj[index27].PreHexPicFileName);
                      int basicSpriteCounter = this.game.Data.LandscapeTypeObj[index27].BasicSpriteCounter;
                      for (int Number = 0; Number <= basicSpriteCounter; ++Number)
                      {
                        text20.Write("\r\n");
                        text20.Write("\r\n");
                        text20.Write("SPRITE#" + Strings.Trim(Conversion.Str((object) Number)));
                        text20.Write("\r\n");
                        text20.Write("BasicPicFile = " + this.game.Data.LandscapeTypeObj[index27].BasicPicFileName[Number]);
                        text20.Write("\r\n");
                        text20.Write("SidewaysSprite1 = " + this.game.Data.LandscapeTypeObj[index27].SidewaysSpriteFileName1[Number]);
                        text20.Write("\r\n");
                        text20.Write("SidewaysSprite2 = " + this.game.Data.LandscapeTypeObj[index27].SidewaysSpriteFileName2[Number]);
                        text20.Write("\r\n");
                        text20.Write("SidewaysSprite3 = " + this.game.Data.LandscapeTypeObj[index27].SidewaysSpriteFileName3[Number]);
                        text20.Write("\r\n");
                        text20.Write("BasicSpriteFile = " + this.game.Data.LandscapeTypeObj[index27].BasicSpriteFileName[Number]);
                        text20.Write("\r\n");
                        text20.Write("BasicSpriteFile2 = " + this.game.Data.LandscapeTypeObj[index27].BasicSpriteFileName2[Number]);
                        text20.Write("\r\n");
                        text20.Write("BasicSpriteFile3 = " + this.game.Data.LandscapeTypeObj[index27].BasicSpriteFileName3[Number]);
                      }
                      text20.Write("\r\n");
                      text20.Write("\r\n");
                    }
                    text20.Close();
                    StreamWriter text21 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_SFTypes_linkedgraphics.txt");
                    int sfTypeCounter4 = this.game.Data.SFTypeCounter;
                    for (int index28 = 0; index28 <= sfTypeCounter4; ++index28)
                    {
                      text21.Write(this.game.Data.SFTypeObj[index28].Name);
                      text21.Write("\r\n");
                      text21.Write("PicFile = " + this.game.Data.SFTypeObj[index28].PicFileName);
                      text21.Write("\r\n");
                      text21.Write("PicFile2 = " + this.game.Data.SFTypeObj[index28].SidewaysFileName);
                      text21.Write("\r\n");
                      text21.Write("Big Symbol 1 = " + this.game.Data.SFTypeObj[index28].SymbolColBigFileName);
                      text21.Write("\r\n");
                      text21.Write("Big Symbol 2 = " + this.game.Data.SFTypeObj[index28].SymbolColBigFileName2);
                      text21.Write("\r\n");
                      text21.Write("Extra Symbol 1= " + this.game.Data.SFTypeObj[index28].SymbolFileName);
                      int extraCounter = this.game.Data.SFTypeObj[index28].ExtraCounter;
                      for (int Number = 0; Number <= extraCounter; ++Number)
                      {
                        text21.Write("\r\n");
                        text21.Write("\r\n");
                        text21.Write("EXTRA SLOT#" + Strings.Trim(Conversion.Str((object) Number)));
                        text21.Write("\r\n");
                        text21.Write("PicFile = " + this.game.Data.SFTypeObj[index28].ExtraPicFileName[Number]);
                        text21.Write("\r\n");
                        text21.Write("PicFile2 = " + this.game.Data.SFTypeObj[index28].ExtraSidewaysFileName[Number]);
                        text21.Write("\r\n");
                        text21.Write("Big Symbol 1 = " + this.game.Data.SFTypeObj[index28].ExtraSymbolColBigFileName[Number]);
                        text21.Write("\r\n");
                        text21.Write("Big Symbol 2 = " + this.game.Data.SFTypeObj[index28].ExtraSymbolColBigFileName2[Number]);
                        text21.Write("\r\n");
                        text21.Write("Extra Symbol 1= " + this.game.Data.SFTypeObj[index28].ExtraSymbolFileName[Number]);
                      }
                      text21.Write("\r\n");
                      text21.Write("\r\n");
                    }
                    text21.Close();
                    StreamWriter text22 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_Regimes_linkedgraphics.txt");
                    int regimeCounter3 = this.game.Data.RegimeCounter;
                    for (int index29 = 0; index29 <= regimeCounter3; ++index29)
                    {
                      text22.Write(this.game.Data.RegimeObj[index29].Name);
                      text22.Write("\r\n");
                      text22.Write("PicFile = " + this.game.Data.RegimeObj[index29].HQSpriteFileName);
                      text22.Write("\r\n");
                      text22.Write("PicFile = " + this.game.Data.RegimeObj[index29].NationalIconSpriteName);
                      text22.Write("\r\n");
                      text22.Write("\r\n");
                      text22.Write("\r\n");
                    }
                    text22.Close();
                    StreamWriter text23 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_RoadType_linkedgraphics.txt");
                    int roadTypeCounter = this.game.Data.RoadTypeCounter;
                    bool flag;
                    for (int index30 = 0; index30 <= roadTypeCounter; ++index30)
                    {
                      text23.Write(this.game.Data.RoadTypeObj[index30].Name);
                      text23.Write("\r\n");
                      text23.Write("SheetFileName" + flag.ToString() + " = " + this.game.Data.RoadTypeObj[index30].SheetFileName);
                      text23.Write("\r\n");
                      int index31 = 0;
                      do
                      {
                        text23.Write("BasicSpriteFileName= " + this.game.Data.RoadTypeObj[index30].BasicSpriteFileName[index31].ToString());
                        text23.Write("\r\n");
                        ++index31;
                      }
                      while (index31 <= 5);
                      text23.Write("\r\n");
                      text23.Write("\r\n");
                    }
                    text23.Close();
                    StreamWriter text24 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_RiverType_linkedgraphics.txt");
                    int riverTypeCounter = this.game.Data.RiverTypeCounter;
                    for (int index32 = 0; index32 <= riverTypeCounter; ++index32)
                    {
                      text24.Write(this.game.Data.RiverTypeObj[index32].Name);
                      text24.Write("\r\n");
                      text24.Write("SheetFileName" + flag.ToString() + " = " + this.game.Data.RiverTypeObj[index32].SheetFileName);
                      text24.Write("\r\n");
                      int index33 = 0;
                      do
                      {
                        text24.Write("BasicSpriteFileName= " + this.game.Data.RiverTypeObj[index32].BasicSpriteFileName[index33].ToString());
                        text24.Write("\r\n");
                        ++index33;
                      }
                      while (index33 <= 5);
                      text24.Write("\r\n");
                      text24.Write("\r\n");
                    }
                    text24.Close();
                    StreamWriter text25 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_Bridge_linkedgraphics.txt");
                    int index34 = 0;
                    do
                    {
                      text25.Write("BasicSpriteFileName= " + this.game.Data.BridgeObj[0].BasicSpriteFileName[index34].ToString());
                      text25.Write("AlternateSpriteFileName= " + this.game.Data.BridgeObj[0].AlternateSpriteFileName[index34].ToString());
                      text25.Write("\r\n");
                      ++index34;
                    }
                    while (index34 <= 5);
                    text25.Write("\r\n");
                    text25.Write("\r\n");
                    text25.Close();
                    StreamWriter text26 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_Events.txt");
                    int eventCounter3 = this.game.Data.EventCounter;
                    for (int index35 = 0; index35 <= eventCounter3; ++index35)
                    {
                      int commandCounter = this.game.Data.EventObj[index35].CommandCounter;
                      for (int Number = 0; Number <= commandCounter; ++Number)
                      {
                        if (Strings.Len(this.game.Data.EventObj[index35].CommandList[Number].DataString) > 1 && Conversions.ToInteger(this.game.Data.EventObj[index35].CommandList[Number].Data[0, 1]) == 11)
                        {
                          text26.Write("EVENT: " + this.game.Data.EventObj[index35].Name + ", Line " + Conversion.Str((object) Number));
                          text26.Write("\r\n");
                          text26.Write(this.game.Data.EventObj[index35].CommandList[Number].DataString);
                          text26.Write("\r\n");
                          text26.Write("\r\n");
                        }
                      }
                    }
                    text26.Close();
                    StreamWriter text27 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_Execs.txt");
                    int execTypeCount2 = this.game.Data.ExecTypeCount;
                    for (int index36 = 0; index36 <= execTypeCount2; ++index36)
                    {
                      string str8 = this.game.Data.ExecTypeNames[index36] + "(";
                      int num75 = this.game.Data.ExecTypeVarCount[index36];
                      for (int index37 = 1; index37 <= num75; ++index37)
                      {
                        if (index37 > 1)
                          str8 += ",";
                        str8 += this.game.Data.ExecTypeVarName[index36, index37];
                      }
                      string str9 = str8 + ")";
                      text27.Write(str9);
                      text27.Write("\r\n");
                    }
                    text27.Close();
                    StreamWriter text28 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_Rulevars.txt");
                    int Number3 = 0;
                    do
                    {
                      if (this.game.Data.RuleGroup[Number3] > 0 & this.game.Data.RuleString[Number3].Length > 1)
                      {
                        string str10 = Strings.Trim(Conversion.Str((object) Number3)) + "," + Strings.Trim(Conversion.Str((object) this.game.Data.RuleVar[Number3])) + "," + this.game.Data.RuleString[Number3];
                        text28.Write(str10);
                        text28.Write("\r\n");
                      }
                      ++Number3;
                    }
                    while (Number3 <= 999);
                    text28.Close();
                    StreamWriter text29 = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_Stringlists.txt");
                    int stringListCounter = this.game.Data.StringListCounter;
                    for (int index38 = 0; index38 <= stringListCounter; ++index38)
                    {
                      string str11 = this.game.Data.StringListObj[index38].Name + "(" + index38.ToString() + ") = ";
                      string str12 = this.game.Data.StringListObj[index38].Length.ToString() + " ..... " + str11;
                      text29.Write(str12);
                      text29.Write("\r\n");
                    }
                    text29.Close();
                  }
                  else if (num1 == this.a14Id)
                  {
                    string str13 = Interaction.InputBox("Give width of map in hexes (20-200)", "Shadow Empire : Planetary Conquest");
                    int twidth = Operators.CompareString(Strings.Trim(str13), "", false) == 0 ? 0 : Conversions.ToInteger(str13);
                    string str14 = Interaction.InputBox("Give height of map in hexes (20-200)", "Shadow Empire : Planetary Conquest");
                    int theight = Operators.CompareString(Strings.Trim(str14), "", false) == 0 ? 0 : Conversions.ToInteger(str14);
                    if (twidth < 20 | theight < 20 | twidth > 200 | theight > 200)
                    {
                      int num76 = (int) Interaction.MsgBox((object) "Cannot comply. Width and Height must be between 5 and 100", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    else
                    {
                      this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
                      this.game.Data = new DataClass(twidth, theight);
                      this.game.SelectX = 0;
                      this.game.SelectY = 0;
                      this.game.CornerX = 0;
                      this.game.CornerY = 0;
                      this.game.EditObj.MiddleWindow = true;
                      this.MakeFirst();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                  }
                  else
                  {
                    if (num1 == this.a15Id)
                    {
                      int num77 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Alternate system? -1=no, otherwise give #of days for a round (31=1 month steps)", "Shadow Empire : Planetary Conquest")));
                      if (num77 >= -1 & num77 < 9999)
                      {
                        this.game.Data.AlternateRound = num77;
                        if (num77 > -1)
                        {
                          int year = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Start Year..", "Shadow Empire : Planetary Conquest")));
                          int month = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Start Month..", "Shadow Empire : Planetary Conquest")));
                          int day = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Start Day of the Month..", "Shadow Empire : Planetary Conquest")));
                          if (month > 0 & year < 9999 & year > 0 & day > 0)
                          {
                            try
                            {
                              this.game.Data.StartData = new DateTime(year, month, day);
                            }
                            catch (Exception ex)
                            {
                              ProjectData.SetProjectError(ex);
                              int num78 = (int) Interaction.MsgBox((object) "cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                              this.game.Data.AlternateRound = -1;
                              ProjectData.ClearProjectError();
                            }
                          }
                          else
                          {
                            int num79 = (int) Interaction.MsgBox((object) "cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                            this.game.Data.AlternateRound = -1;
                          }
                        }
                      }
                      else
                      {
                        int num80 = (int) Interaction.MsgBox((object) "cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      this.MakeFirst();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.a42id)
                    {
                      this.MakeSheet();
                      this.MakeFirst();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.a43id)
                    {
                      int counter = BitmapStore.Counter;
                      for (int index39 = 0; index39 <= counter; ++index39)
                      {
                        if (!BitmapStore.tmpIsSystem[index39] & BitmapStore.tmpOverloadCounter[index39] > 0)
                        {
                          if (!Directory.Exists(this.game.AppPath + "tempgraphics"))
                            Directory.CreateDirectory(this.game.AppPath + "tempgraphics");
                          int num81 = 0;
                          do
                          {
                            if (num81 == 0 | BitmapStore.tmpIsBig[index39])
                            {
                              string str15 = BitmapStore.tmpFileName[index39].Replace("//", "/").Replace("\\\\", "\\").Replace("\\", "/");
                              string path = this.game.AppPath + "tempgraphics/";
                              int num82 = 1;
                              int num83 = 0;
                              while (num82 == 1)
                              {
                                num82 = 0;
                                int num84 = Strings.InStr(str15, "/");
                                if (num84 > 0)
                                {
                                  num82 = 1;
                                  ++num83;
                                  string str16 = Strings.Left(str15, num84 - 1);
                                  str15 = Strings.Right(str15, Strings.Len(str15) - num84);
                                  if (num83 > 1)
                                    path += "/";
                                  path += str16;
                                  if (num83 == 1)
                                  {
                                    switch (num81)
                                    {
                                      case 1:
                                        path += "BIG";
                                        break;
                                      case 2:
                                        path += "SMALL";
                                        break;
                                    }
                                  }
                                  if (!Directory.Exists(path))
                                    Directory.CreateDirectory(path);
                                }
                              }
                            }
                            ++num81;
                          }
                          while (num81 <= 2);
                          File.Copy(this.game.AppPath + "graphics/" + BitmapStore.tmpFileName[index39], this.game.AppPath + "tempgraphics/" + BitmapStore.tmpFileName[index39], true);
                          if (BitmapStore.tmpIsBig[index39])
                          {
                            string str17 = BitmapStore.MakeBigString(BitmapStore.tmpFileName[index39]);
                            File.Copy(this.game.AppPath + "graphics/" + str17, this.game.AppPath + "tempgraphics/" + str17, true);
                            string str18 = BitmapStore.MakeSmallString(BitmapStore.tmpFileName[index39]);
                            File.Copy(this.game.AppPath + "graphics/" + str18, this.game.AppPath + "tempgraphics/" + str18, true);
                          }
                        }
                      }
                      this.CopyDirectory(this.game.AppPath + "graphics/systemgraphics", this.game.AppPath + "tempgraphics/systemgraphics", true);
                      this.CopyDirectory(this.game.AppPath + "graphics/systemgraphicsBIG", this.game.AppPath + "tempgraphics/systemgraphicsBIG", true);
                      this.CopyDirectory(this.game.AppPath + "graphics/systemgraphicsSMALL", this.game.AppPath + "tempgraphics/systemgraphicsSMALL", true);
                      if (this.game.Data.SystemGfx.Length > 0 & Operators.CompareString(this.game.Data.SystemGfx, "systemgraphics", false) != 0)
                      {
                        try
                        {
                          Directory.Delete(this.game.AppPath + "tempgraphics/systemgraphics/natocounters", true);
                          Directory.Delete(this.game.AppPath + "tempgraphics/systemgraphicsBIG/natocounters", true);
                          Directory.Delete(this.game.AppPath + "tempgraphics/systemgraphicsSMALL/natocounters", true);
                        }
                        catch (Exception ex)
                        {
                          ProjectData.SetProjectError(ex);
                          ProjectData.ClearProjectError();
                        }
                        this.CopyDirectory(this.game.AppPath + "graphics/" + this.game.Data.SystemGfx, this.game.AppPath + "tempgraphics/systemgraphics", true);
                        this.CopyDirectory(this.game.AppPath + "graphics/" + this.game.Data.SystemGfx + "BIG", this.game.AppPath + "tempgraphics/systemgraphicsBIG", true);
                        this.CopyDirectory(this.game.AppPath + "graphics/" + this.game.Data.SystemGfx + "SMALL", this.game.AppPath + "tempgraphics/systemgraphicsSMALL", true);
                      }
                      this.MakeFirst();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.a16Id)
                    {
                      float num85 = (float) Conversion.Val(Interaction.InputBox("Give Value", "Shadow Empire : Planetary Conquest"));
                      if ((double) num85 > 0.1 & (double) num85 < 999.0)
                      {
                        this.game.Data.ResCostMod = num85;
                      }
                      else
                      {
                        int num86 = (int) Interaction.MsgBox((object) "Value out of bounds: 0.1 to 999x specified cost", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      this.MakeFirst();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.a39id)
                    {
                      this.game.Data.Loadable = !this.game.Data.Loadable;
                      this.MakeFirst();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.p4id)
                    {
                      string oldValue = Interaction.InputBox("Give String to replace", "Shadow Empire : Planetary Conquest");
                      string newValue = Interaction.InputBox("Give String to replace with", "Shadow Empire : Planetary Conquest");
                      this.game.FormRef.Cursor = Cursors.WaitCursor;
                      int sfTypeCounter = this.game.Data.SFTypeCounter;
                      for (int index40 = 0; index40 <= sfTypeCounter; ++index40)
                      {
                        if (!Information.IsNothing((object) this.game.Data.SFTypeObj[index40].MoveWAV))
                          this.game.Data.SFTypeObj[index40].MoveWAV = this.game.Data.SFTypeObj[index40].MoveWAV.Replace(oldValue, newValue);
                        if (!Information.IsNothing((object) this.game.Data.SFTypeObj[index40].BattleWAV))
                          this.game.Data.SFTypeObj[index40].BattleWAV = this.game.Data.SFTypeObj[index40].BattleWAV.Replace(oldValue, newValue);
                      }
                      this.game.FormRef.Cursor = Cursors.Default;
                      int num87 = (int) Interaction.MsgBox((object) "Changed", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    else if (num1 == this.p3id)
                    {
                      string oldValue = Interaction.InputBox("Give String to replace", "Shadow Empire : Planetary Conquest");
                      string newValue = Interaction.InputBox("Give String to replace with", "Shadow Empire : Planetary Conquest");
                      this.game.FormRef.Cursor = Cursors.WaitCursor;
                      int smallPicCounter = this.game.Data.SmallPicCounter;
                      for (int index41 = 0; index41 <= smallPicCounter; ++index41)
                        this.game.Data.SmallPicName[index41] = this.game.Data.SmallPicName[index41].Replace(oldValue, newValue);
                      int eventPicCounter = this.game.Data.EventPicCounter;
                      for (int index42 = 0; index42 <= eventPicCounter; ++index42)
                        this.game.Data.EventPicName[index42] = this.game.Data.EventPicName[index42].Replace(oldValue, newValue);
                      int landscapeTypeCounter = this.game.Data.LandscapeTypeCounter;
                      for (int index43 = 0; index43 <= landscapeTypeCounter; ++index43)
                      {
                        this.game.Data.LandscapeTypeObj[index43].PreHexPicFileName = this.game.Data.LandscapeTypeObj[index43].PreHexPicFileName.Replace(oldValue, newValue);
                        this.game.Data.LandscapeTypeObj[index43].SheetFileName = this.game.Data.LandscapeTypeObj[index43].SheetFileName.Replace(oldValue, newValue);
                        b = 0;
                        do
                        {
                          if (!Information.IsNothing((object) this.game.Data.LandscapeTypeObj[index43].LayerSpriteFileName[b]))
                            this.game.Data.LandscapeTypeObj[index43].LayerSpriteFileName[b] = this.game.Data.LandscapeTypeObj[index43].LayerSpriteFileName[b].Replace(oldValue, newValue);
                          ++b;
                        }
                        while (b <= 64);
                        int basicSpriteCounter = this.game.Data.LandscapeTypeObj[index43].BasicSpriteCounter;
                        for (b = 0; b <= basicSpriteCounter; ++b)
                        {
                          this.game.Data.LandscapeTypeObj[index43].BasicSpriteFileName[b] = this.game.Data.LandscapeTypeObj[index43].BasicSpriteFileName[b].Replace(oldValue, newValue);
                          this.game.Data.LandscapeTypeObj[index43].BasicSpriteFileName2[b] = this.game.Data.LandscapeTypeObj[index43].BasicSpriteFileName2[b].Replace(oldValue, newValue);
                          this.game.Data.LandscapeTypeObj[index43].BasicSpriteFileName3[b] = this.game.Data.LandscapeTypeObj[index43].BasicSpriteFileName3[b].Replace(oldValue, newValue);
                          this.game.Data.LandscapeTypeObj[index43].BasicPicFileName[b] = this.game.Data.LandscapeTypeObj[index43].BasicPicFileName[b].Replace(oldValue, newValue);
                          this.game.Data.LandscapeTypeObj[index43].SidewaysSpriteFileName1[b] = this.game.Data.LandscapeTypeObj[index43].SidewaysSpriteFileName1[b].Replace(oldValue, newValue);
                          this.game.Data.LandscapeTypeObj[index43].SidewaysSpriteFileName2[b] = this.game.Data.LandscapeTypeObj[index43].SidewaysSpriteFileName2[b].Replace(oldValue, newValue);
                          this.game.Data.LandscapeTypeObj[index43].SidewaysSpriteFileName3[b] = this.game.Data.LandscapeTypeObj[index43].SidewaysSpriteFileName3[b].Replace(oldValue, newValue);
                        }
                      }
                      int roadTypeCounter = this.game.Data.RoadTypeCounter;
                      for (int index44 = 0; index44 <= roadTypeCounter; ++index44)
                      {
                        this.game.Data.RoadTypeObj[index44].SheetFileName = this.game.Data.RoadTypeObj[index44].SheetFileName.Replace(oldValue, newValue);
                        b = 0;
                        do
                        {
                          if (!Information.IsNothing((object) this.game.Data.RoadTypeObj[index44].LayerSpriteFileName[b]))
                            this.game.Data.RoadTypeObj[index44].LayerSpriteFileName[b] = this.game.Data.RoadTypeObj[index44].LayerSpriteFileName[b].Replace(oldValue, newValue);
                          ++b;
                        }
                        while (b <= 64);
                      }
                      int riverTypeCounter = this.game.Data.RiverTypeCounter;
                      for (int index45 = 0; index45 <= riverTypeCounter; ++index45)
                      {
                        this.game.Data.RiverTypeObj[index45].SheetFileName = this.game.Data.RiverTypeObj[index45].SheetFileName.Replace(oldValue, newValue);
                        b = 0;
                        do
                        {
                          if (!Information.IsNothing((object) this.game.Data.RiverTypeObj[index45].LayerSpriteFileName[b]))
                            this.game.Data.RiverTypeObj[index45].LayerSpriteFileName[b] = this.game.Data.RiverTypeObj[index45].LayerSpriteFileName[b].Replace(oldValue, newValue);
                          ++b;
                        }
                        while (b <= 64);
                      }
                      b = 0;
                      do
                      {
                        this.game.Data.BridgeObj[0].BasicSpriteFileName[b] = this.game.Data.BridgeObj[0].BasicSpriteFileName[b].Replace(oldValue, newValue);
                        this.game.Data.BridgeObj[0].AlternateSpriteFileName[b] = this.game.Data.BridgeObj[0].AlternateSpriteFileName[b].Replace(oldValue, newValue);
                        ++b;
                      }
                      while (b <= 5);
                      int sfTypeCounter = this.game.Data.SFTypeCounter;
                      for (int index46 = 0; index46 <= sfTypeCounter; ++index46)
                      {
                        int extraCounter = this.game.Data.SFTypeObj[index46].ExtraCounter;
                        for (b = 0; b <= extraCounter; ++b)
                        {
                          this.game.Data.SFTypeObj[index46].ExtraSidewaysFileName[b] = this.game.Data.SFTypeObj[index46].ExtraSidewaysFileName[b].Replace(oldValue, newValue);
                          this.game.Data.SFTypeObj[index46].ExtraPicFileName[b] = this.game.Data.SFTypeObj[index46].ExtraPicFileName[b].Replace(oldValue, newValue);
                          this.game.Data.SFTypeObj[index46].ExtraSymbolColBigFileName[b] = this.game.Data.SFTypeObj[index46].ExtraSymbolColBigFileName[b].Replace(oldValue, newValue);
                          this.game.Data.SFTypeObj[index46].ExtraSymbolColBigFileName2[b] = this.game.Data.SFTypeObj[index46].ExtraSymbolColBigFileName2[b].Replace(oldValue, newValue);
                          this.game.Data.SFTypeObj[index46].ExtraSymbolFileName[b] = this.game.Data.SFTypeObj[index46].ExtraSymbolFileName[b].Replace(oldValue, newValue);
                          this.game.Data.SFTypeObj[index46].ExtraSymbolFileName2[b] = this.game.Data.SFTypeObj[index46].ExtraSymbolFileName2[b].Replace(oldValue, newValue);
                        }
                        this.game.Data.SFTypeObj[index46].SidewaysFileName = this.game.Data.SFTypeObj[index46].SidewaysFileName.Replace(oldValue, newValue);
                        this.game.Data.SFTypeObj[index46].PicFileName = this.game.Data.SFTypeObj[index46].PicFileName.Replace(oldValue, newValue);
                        this.game.Data.SFTypeObj[index46].SymbolColBigFileName = this.game.Data.SFTypeObj[index46].SymbolColBigFileName.Replace(oldValue, newValue);
                        this.game.Data.SFTypeObj[index46].SymbolColBigFileName2 = this.game.Data.SFTypeObj[index46].SymbolColBigFileName2.Replace(oldValue, newValue);
                        this.game.Data.SFTypeObj[index46].SymbolFileName = this.game.Data.SFTypeObj[index46].SymbolFileName.Replace(oldValue, newValue);
                        this.game.Data.SFTypeObj[index46].SymbolFileName2 = this.game.Data.SFTypeObj[index46].SymbolFileName2.Replace(oldValue, newValue);
                      }
                      int peopleCounter = this.game.Data.PeopleCounter;
                      for (int index47 = 0; index47 <= peopleCounter; ++index47)
                      {
                        this.game.Data.PeopleObj[index47].SidewaysFileName = this.game.Data.PeopleObj[index47].SidewaysFileName.Replace(oldValue, newValue);
                        this.game.Data.PeopleObj[index47].NationalFileName = this.game.Data.PeopleObj[index47].NationalFileName.Replace(oldValue, newValue);
                      }
                      int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
                      for (int index48 = 0; index48 <= historicalUnitCounter; ++index48)
                      {
                        if (Information.IsNothing((object) this.game.Data.HistoricalUnitObj[index48].CommanderFileName))
                          this.game.Data.HistoricalUnitObj[index48].CommanderFileName = "";
                        if (Information.IsNothing((object) this.game.Data.HistoricalUnitObj[index48].OverdrawFileName))
                          this.game.Data.HistoricalUnitObj[index48].OverdrawFileName = "";
                        this.game.Data.HistoricalUnitObj[index48].CommanderFileName = this.game.Data.HistoricalUnitObj[index48].CommanderFileName.Replace(oldValue, newValue);
                        this.game.Data.HistoricalUnitObj[index48].OverdrawFileName = this.game.Data.HistoricalUnitObj[index48].OverdrawFileName.Replace(oldValue, newValue);
                      }
                      this.game.Data.LoadGraphics(this.formref);
                      this.game.FormRef.Cursor = Cursors.Default;
                      int num88 = (int) Interaction.MsgBox((object) "Changed and reloaded", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    else
                    {
                      if (num1 == this.a20Id)
                      {
                        float num89 = (float) Conversion.Val(Interaction.InputBox("Give Value", "Shadow Empire : Planetary Conquest"));
                        if ((double) num89 > 0.1 & (double) num89 < 999.0)
                        {
                          this.game.Data.SupplyMultiplier = num89;
                        }
                        else
                        {
                          int num90 = (int) Interaction.MsgBox((object) "Value out of bounds: 0.1 to 999x specified cost", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        }
                        this.MakeFirst();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.a21Id)
                      {
                        float num91 = (float) Conversion.Val(Interaction.InputBox("Give Value", "Shadow Empire : Planetary Conquest"));
                        if ((double) num91 > 0.1 & (double) num91 < 999.0)
                        {
                          this.game.Data.PPMultiplier = num91;
                        }
                        else
                        {
                          int num92 = (int) Interaction.MsgBox((object) "Value out of bounds: 0.1 to 999x specified cost", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        }
                        this.MakeFirst();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.a18Id)
                      {
                        int num93 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give ResMod value representing ideal prodpower", "Shadow Empire : Planetary Conquest")));
                        float num94;
                        if (num93 >= -1 & (double) num94 < 999999.0)
                        {
                          this.game.Data.ResMod = num93;
                        }
                        else
                        {
                          int num95 = (int) Interaction.MsgBox((object) "Value out of bounds: 0 to 999.999 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        }
                        this.MakeFirst();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.B2Id)
                      {
                        int num96 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Value", "Shadow Empire : Planetary Conquest")));
                        if (num96 > -2 & num96 < 999999)
                        {
                          if (this.TabSheetNr == 1)
                            this.game.Data.GameSlot[this.DetailNr] = num96;
                        }
                        else
                        {
                          int num97 = (int) Interaction.MsgBox((object) "Value out of bounds -1 to 999999", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        }
                        this.maketabsheet();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.exp1id)
                      {
                        this.game.HandyFunctionsObj.Export();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.addId)
                      {
                        if (this.TabSheetNr == 8)
                        {
                          this.game.Data.AddReinf(Interaction.InputBox("Give name of new reinf. type", "Shadow Empire : Planetary Conquest"));
                          this.maketabsheet();
                          windowReturnClass.SetFlag(true);
                          return windowReturnClass;
                        }
                        if (this.TabSheetNr == 7)
                        {
                          string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps|*.bmp|Jpegs|*.jpg", "Select File For New Small Picture:", this.game.AppPath + "graphics\\", true);
                          if (File.Exists(this.game.AppPath + "graphics/" + filename))
                          {
                            this.game.Data.AddSmallPic(filename);
                          }
                          else
                          {
                            int num98 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                          }
                          this.maketabsheet();
                          windowReturnClass.SetFlag(true);
                          return windowReturnClass;
                        }
                        string filename1 = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps|*.bmp|Jpegs|*.jpg", "Select File For New Event Picture:", this.game.AppPath + "graphics\\", true);
                        if (File.Exists(this.game.AppPath + "graphics/" + filename1))
                        {
                          this.game.Data.AddEventPic(filename1);
                        }
                        else
                        {
                          int num99 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        }
                        this.maketabsheet();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.LoadId)
                      {
                        if (this.TabSheetNr == 7)
                        {
                          string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps|*.bmp|Jpegs|*.jpg", "Select File For New Small Picture:", this.game.AppPath + "graphics\\", true);
                          if (File.Exists(this.game.AppPath + "graphics/" + filename))
                          {
                            this.game.Data.SmallPicReplaceprite(this.DetailNr, filename);
                          }
                          else
                          {
                            int num100 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                          }
                          this.maketabsheet();
                          windowReturnClass.SetFlag(true);
                          return windowReturnClass;
                        }
                        string filename2 = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps|*.bmp|Jpegs|*.jpg", "Select File For New Event Picture:", this.game.AppPath + "graphics\\", true);
                        if (File.Exists(this.game.AppPath + "graphics/" + filename2))
                        {
                          this.game.Data.EventPicReplaceprite(this.DetailNr, filename2);
                        }
                        else
                        {
                          int num101 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        }
                        this.maketabsheet();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.rRemoveId)
                      {
                        this.game.Data.RemoveReinf(this.DetailNr);
                        this.maketabsheet();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.RemoveId)
                      {
                        if (this.TabSheetNr == 7)
                        {
                          this.game.Data.RemoveSmallPic(this.DetailNr);
                          this.maketabsheet();
                          windowReturnClass.SetFlag(true);
                          return windowReturnClass;
                        }
                        this.game.Data.RemoveEventPic(this.DetailNr);
                        this.maketabsheet();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                    }
                  }
                }
              }
            }
            int tnr = 0;
            while (this.SubPartID[index1] != this.vari[tnr])
            {
              if (this.SubPartID[index1] == this.vare[tnr])
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 58, tnr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              ++tnr;
              if (tnr > 11)
                goto label_645;
            }
            new Form3((Form) this.formref).Initialize(this.game.Data, 25, tnr);
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

    public bool CopyDirectory(string Src, string Dest, bool bQuiet = false)
    {
      if (!Directory.Exists(Src))
        throw new DirectoryNotFoundException("The directory " + Src + " does not exists");
      if (Directory.Exists(Dest) && !bQuiet && MessageBox.Show("directory " + Dest + " already exists.\r\nIf you continue, any files with the same name will be overwritten", "Continue?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
      {
        bool flag;
        return flag;
      }
      if (Operators.CompareString(Dest.Substring(Dest.Length - 1, 1), Conversions.ToString(Path.DirectorySeparatorChar), false) != 0)
        Dest += Conversions.ToString(Path.DirectorySeparatorChar);
      if (!Directory.Exists(Dest))
        Directory.CreateDirectory(Dest);
      foreach (string fileSystemEntry in Directory.GetFileSystemEntries(Src))
      {
        if (Directory.Exists(fileSystemEntry))
          this.CopyDirectory(fileSystemEntry, Dest + Path.GetFileName(fileSystemEntry), true);
        else
          File.Copy(fileSystemEntry, Dest + Path.GetFileName(fileSystemEntry), true);
      }
      return true;
    }

    public void MakeSheet()
    {
      string str1 = Interaction.InputBox("Give a directory under the graphics dir please", "Shadow Empire : Planetary Conquest");
      if (!Directory.Exists(this.game.AppPath + "graphics/" + str1))
      {
        int num1 = (int) Interaction.MsgBox((object) "Dir does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      else
      {
        this.SheetCount = 0;
        this.RecursiveSearch(this.game.AppPath + "graphics/" + str1);
        if (this.SheetCount < 1)
        {
          int num2 = (int) Interaction.MsgBox((object) "No files found");
        }
        else
        {
          Bitmap[] bitmapArray = new Bitmap[this.SheetCount + 1];
          int sheetCount1 = this.SheetCount;
          for (int index1 = 1; index1 <= sheetCount1 && index1 <= this.SheetCount; ++index1)
          {
            bitmapArray[index1] = new Bitmap(this.game.AppPath + "graphics/" + this.SheetName[index1]);
            bitmapArray[index1].SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
            if (bitmapArray[index1].GetPixel(0, 0) == Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue))
              bitmapArray[index1].MakeTransparent(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue));
            if (bitmapArray[index1].Height <= 96)
            {
              this.SheetRect[index1] = new Rectangle(-1, -1, bitmapArray[index1].Width, bitmapArray[index1].Height);
            }
            else
            {
              int num3 = index1;
              int num4 = this.SheetCount - 1;
              for (int index2 = num3; index2 <= num4; ++index2)
              {
                this.SheetName[index2] = this.SheetName[index2 + 1];
                this.SheetRect[index2] = this.SheetRect[index2 + 1];
              }
              --this.SheetCount;
              --index1;
            }
          }
          int sheetCount2 = this.SheetCount;
          int index3;
          for (index3 = 1; index3 <= sheetCount2; ++index3)
          {
            int num5 = this.SheetRect[index3].Width * this.SheetRect[index3].Height;
            int num6 = index3 - 1;
            for (int index4 = 1; index4 <= num6; ++index4)
            {
              if (this.SheetRect[index4].Width * this.SheetRect[index4].Height > num5)
              {
                Bitmap bitmap = bitmapArray[index3];
                Rectangle rectangle = this.SheetRect[index3];
                string str2 = this.SheetName[index3];
                bitmapArray[index3] = bitmapArray[index4];
                this.SheetRect[index3] = this.SheetRect[index4];
                this.SheetName[index3] = this.SheetName[index4];
                bitmapArray[index4] = bitmap;
                this.SheetRect[index4] = rectangle;
                this.SheetName[index4] = str2;
              }
            }
          }
          int num7 = index3;
          int num8 = 0;
          int num9 = 0;
          int sheetCount3;
          int width;
          int height;
          Rectangle rectangle1;
          for (sheetCount3 = this.SheetCount; sheetCount3 >= 1; sheetCount3 += -1)
          {
            if (this.SheetRect[sheetCount3].X == -1)
            {
              int num10 = 0;
              while (num10 == 0)
              {
                int x = 0;
                int num11 = 0;
                do
                {
                  int y = 0;
                  if (num8 > 0)
                  {
                    x += num8;
                    num8 = 0;
                  }
                  else
                    x += 10;
                  if (x > width)
                    num11 = 9999999;
                  int num12 = 0;
                  do
                  {
                    if (num9 > 0)
                    {
                      y += num9;
                      num9 = 0;
                    }
                    else
                      y += 10;
                    if (y > height)
                      num12 = 9999999;
                    if (this.SheetRect[sheetCount3].Width + x <= width && this.SheetRect[sheetCount3].Height + y <= height)
                    {
                      num10 = 1;
                      int sheetCount4 = this.SheetCount;
                      for (int index5 = 1; index5 <= sheetCount4; ++index5)
                      {
                        if (this.SheetRect[index5].X > -1)
                        {
                          rectangle1 = Rectangle.Intersect(this.SheetRect[index5], new Rectangle(x, y, this.SheetRect[sheetCount3].Width, this.SheetRect[sheetCount3].Height));
                          if (rectangle1.Width > 0)
                          {
                            num10 = 0;
                            Rectangle a = this.SheetRect[index5];
                            rectangle1 = new Rectangle(x, y, this.SheetRect[sheetCount3].Width, this.SheetRect[sheetCount3].Height);
                            Rectangle b = rectangle1;
                            Rectangle rectangle2 = Rectangle.Intersect(a, b);
                            num8 = rectangle2.Width;
                            num9 = rectangle2.Width;
                            break;
                          }
                        }
                      }
                    }
                    if (num10 == 1)
                    {
                      this.SheetRect[sheetCount3].X = x;
                      this.SheetRect[sheetCount3].Y = y;
                      break;
                    }
                    ++num12;
                  }
                  while (num12 <= 99999);
                  if (num10 != 1)
                    ++num11;
                  else
                    break;
                }
                while (num11 <= 99999);
                if (num10 == 0)
                {
                  if (this.SheetRect[sheetCount3].Width > width)
                    width += 10;
                  else if (this.SheetRect[sheetCount3].Height > height)
                  {
                    height += 10;
                  }
                  else
                  {
                    int num13;
                    if (num13 == 0)
                    {
                      num13 = 1;
                      width += 10;
                    }
                    else
                    {
                      num13 = 0;
                      height += 10;
                    }
                  }
                }
              }
            }
          }
          num7 = sheetCount3;
          Bitmap tmpbmp = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
          tmpbmp.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
          Graphics graphics = Graphics.FromImage((Image) tmpbmp);
          graphics.CompositingMode = CompositingMode.SourceCopy;
          int sheetCount5 = this.SheetCount;
          int index6;
          for (index6 = 1; index6 <= sheetCount5; ++index6)
          {
            ref Graphics local1 = ref graphics;
            ref Bitmap local2 = ref bitmapArray[index6];
            rectangle1 = new Rectangle(0, 0, this.SheetRect[index6].Width, this.SheetRect[index6].Height);
            Rectangle srcrect = rectangle1;
            Rectangle destrect = this.SheetRect[index6];
            DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
          }
          graphics.CompositingMode = CompositingMode.SourceOver;
          this.game.HandyFunctionsObj.SaveBitmapAsPing(tmpbmp, BitmapStore.GraphicsPath + str1 + "/sheet.png");
          num7 = index6;
          StreamWriter text = File.CreateText(BitmapStore.GraphicsPath + str1 + "/sheet.txt");
          text.WriteLine(this.SheetCount);
          int sheetCount6 = this.SheetCount;
          for (int index7 = 1; index7 <= sheetCount6; ++index7)
          {
            text.WriteLine(this.SheetName[index7]);
            text.WriteLine(this.SheetRect[index7].X);
            text.WriteLine(this.SheetRect[index7].Y);
            text.WriteLine(this.SheetRect[index7].Width);
            text.WriteLine(this.SheetRect[index7].Height);
          }
          text.Close();
          int num14 = (int) Interaction.MsgBox((object) ("Written " + Strings.Trim(Conversion.Str((object) this.SheetCount)) + " files in a sheet."), Title: ((object) "Shadow Empire : Planetary Conquest"));
        }
      }
    }

    public bool RecursiveSearch(string path)
    {
      foreach (FileSystemInfo fileSystemInfo in new DirectoryInfo(path).GetFileSystemInfos())
      {
        if (fileSystemInfo.Attributes == FileAttributes.Directory)
          this.RecursiveSearch(fileSystemInfo.FullName);
        else if (Strings.InStr(Strings.LCase(fileSystemInfo.Name), ".png") > 0 | Strings.InStr(Strings.LCase(fileSystemInfo.Name), ".jpg") > 0 | Strings.InStr(Strings.LCase(fileSystemInfo.Name), ".bmp") > 0)
        {
          ++this.SheetCount;
          this.SheetName = (string[]) Utils.CopyArray((Array) this.SheetName, (Array) new string[this.SheetCount + 1]);
          this.SheetRect = (Rectangle[]) Utils.CopyArray((Array) this.SheetRect, (Array) new Rectangle[this.SheetCount + 1]);
          this.SheetName[this.SheetCount] = fileSystemInfo.FullName;
          this.SheetName[this.SheetCount] = Strings.Right(fileSystemInfo.FullName, Strings.Len(fileSystemInfo.FullName) - Strings.Len(this.game.AppPath + "graphics/"));
        }
      }
      return true;
    }

    public void PdfUnitModels()
    {
      bool flag1 = false;
      if (Interaction.MsgBox((object) "Also read reinforcements from tv3,4,5 variables (like in vanilla Case Blue)?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
        flag1 = true;
      string str1 = Interaction.InputBox("Give version number please, or leave blank", "Shadow Empire : Planetary Conquest");
      string str2 = Interaction.InputBox("Give title", "Shadow Empire : Planetary Conquest");
      ListClass listClass = new ListClass();
      int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
      for (int tdata = 0; tdata <= historicalUnitCounter1; ++tdata)
      {
        if (this.game.Data.HistoricalUnitObj[tdata].Model & this.game.Data.HistoricalUnitObj[tdata].Name.Length > 0 & Strings.InStr(this.game.Data.HistoricalUnitObj[tdata].Name, "depreciated") <= 0 && this.game.Data.HistoricalUnitObj[tdata].SubParts[0] > -1 && this.game.Data.UnitObj[this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[tdata].SubParts[0])].SFCount > -1)
        {
          int people = this.game.Data.SFObj[this.game.Data.UnitObj[this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[tdata].SubParts[0])].SFList[0]].People;
          listClass.add(this.game.Data.HistoricalUnitObj[tdata].Name, tdata, tWeight: (this.game.Data.HistoricalUnitObj[tdata].TempRegime * 500000 + (10 - this.game.Data.HistoricalUnitObj[tdata].Type) * 10000 + people * 100));
        }
      }
      listClass.SortWithRefOnWeightAndName(0);
      if (listClass.ListCount < 0)
        return;
      string[] strArray1 = new string[listClass.ListCount + 1];
      SimpleList simpleList1 = new SimpleList();
      int listCount1 = listClass.ListCount;
      for (int index1 = 0; index1 <= listCount1; ++index1)
      {
        int num = listClass.ListData[index1];
        strArray1[index1] = "";
        int historicalUnitCounter2 = this.game.Data.HistoricalUnitCounter;
        for (int tid = 0; tid <= historicalUnitCounter2; ++tid)
        {
          if (this.game.Data.HistoricalUnitObj[tid].ModelMaster == num & !this.game.Data.HistoricalUnitObj[tid].Model)
          {
            bool flag2 = false;
            int unitCounter = this.game.Data.UnitCounter;
            for (int index2 = 0; index2 <= unitCounter; ++index2)
            {
              if (this.game.Data.UnitObj[index2].X > -1 & this.game.Data.UnitObj[index2].Historical == tid)
                flag2 = true;
            }
            if (flag2)
            {
              if (Conversion.Val(this.game.Data.HistoricalUnitObj[tid].CounterString) == 0.0)
                simpleList1.Add(tid, this.game.Data.HistoricalUnitObj[tid].NameCounter);
              else
                simpleList1.Add(tid, (int) Math.Round(Conversion.Val(this.game.Data.HistoricalUnitObj[tid].CounterString)));
            }
          }
        }
        simpleList1.Sort();
        int counter = simpleList1.Counter;
        for (int index3 = 0; index3 <= counter; ++index3)
        {
          int index4 = simpleList1.Id[index3];
          if (this.game.Data.HistoricalUnitObj[index4].ModelMaster == num & !this.game.Data.HistoricalUnitObj[index4].Model)
          {
            bool flag3 = false;
            int unitCounter = this.game.Data.UnitCounter;
            for (int index5 = 0; index5 <= unitCounter; ++index5)
            {
              if (this.game.Data.UnitObj[index5].X > -1 & this.game.Data.UnitObj[index5].Historical == index4)
                flag3 = true;
            }
            if (flag3)
            {
              if (Operators.CompareString(strArray1[index1], "", false) == 0)
              {
                string[] strArray2 = strArray1;
                string[] strArray3 = strArray2;
                int index6 = index1;
                int index7 = index6;
                string str3 = strArray2[index6] + this.game.Data.HistoricalUnitObj[index4].Name;
                strArray3[index7] = str3;
              }
              else
              {
                string[] strArray4 = strArray1;
                string[] strArray5 = strArray4;
                int index8 = index1;
                int index9 = index8;
                string str4 = strArray4[index8] + ", " + this.game.Data.HistoricalUnitObj[index4].Name;
                strArray5[index9] = str4;
              }
            }
          }
        }
        strArray1[index1] = Operators.CompareString(strArray1[index1], "", false) == 0 ? "Starting units: -" : "Starting units: " + strArray1[index1] + ".";
      }
      string[] strArray6 = new string[listClass.ListCount + 1];
      if (flag1)
      {
        SimpleList simpleList2 = new SimpleList();
        int listCount2 = listClass.ListCount;
        for (int index10 = 0; index10 <= listCount2; ++index10)
        {
          int num = listClass.ListData[index10];
          strArray6[index10] = "";
          int historicalUnitCounter3 = this.game.Data.HistoricalUnitCounter;
          for (int tid = 0; tid <= historicalUnitCounter3; ++tid)
          {
            if (this.game.Data.HistoricalUnitObj[tid].ModelMaster == num & !this.game.Data.HistoricalUnitObj[tid].Model & this.game.Data.HistoricalUnitObj[tid].TempVar3 > 0 & this.game.Data.HistoricalUnitObj[tid].TempVar4 > 0 & this.game.Data.HistoricalUnitObj[tid].TempVar5 > 0 && this.game.Data.HistoricalUnitObj[tid].TempVar4 <= 12 & this.game.Data.HistoricalUnitObj[tid].TempVar5 <= 31 && DateTime.Compare(new DateTime(this.game.Data.HistoricalUnitObj[tid].TempVar3, this.game.Data.HistoricalUnitObj[tid].TempVar4, this.game.Data.HistoricalUnitObj[tid].TempVar5), this.game.Data.StartData) >= 0)
            {
              bool flag4 = false;
              int unitCounter = this.game.Data.UnitCounter;
              for (int index11 = 0; index11 <= unitCounter; ++index11)
              {
                if (this.game.Data.UnitObj[index11].X > -1 & this.game.Data.UnitObj[index11].Historical == tid)
                  flag4 = true;
              }
              if (!flag4)
                simpleList2.Add(tid, this.game.Data.HistoricalUnitObj[tid].TempVar3 * 10000 + this.game.Data.HistoricalUnitObj[tid].TempVar4 * 100 + this.game.Data.HistoricalUnitObj[tid].TempVar5 * 1);
            }
          }
          simpleList2.Sort();
          int counter = simpleList2.Counter;
          for (int index12 = 0; index12 <= counter; ++index12)
          {
            int index13 = simpleList2.Id[index12];
            if (this.game.Data.HistoricalUnitObj[index13].ModelMaster == num & !this.game.Data.HistoricalUnitObj[index13].Model)
            {
              if (Operators.CompareString(strArray6[index10], "", false) == 0)
              {
                string[] strArray7 = strArray6;
                string[] strArray8 = strArray7;
                int index14 = index10;
                int index15 = index14;
                string str5 = strArray7[index14] + this.game.Data.HistoricalUnitObj[index13].Name + "(" + this.game.Data.HistoricalUnitObj[index13].TempVar5.ToString() + " " + Strings.Left(this.game.HandyFunctionsObj.GetMonth(this.game.Data.HistoricalUnitObj[index13].TempVar4), 3) + " " + this.game.Data.HistoricalUnitObj[index13].TempVar3.ToString() + ")";
                strArray8[index15] = str5;
              }
              else
              {
                string[] strArray9 = strArray6;
                string[] strArray10 = strArray9;
                int index16 = index10;
                int index17 = index16;
                string str6 = strArray9[index16] + ", " + this.game.Data.HistoricalUnitObj[index13].Name + "(" + this.game.Data.HistoricalUnitObj[index13].TempVar5.ToString() + " " + Strings.Left(this.game.HandyFunctionsObj.GetMonth(this.game.Data.HistoricalUnitObj[index13].TempVar4), 3) + " " + this.game.Data.HistoricalUnitObj[index13].TempVar3.ToString() + ")";
                strArray10[index17] = str6;
              }
            }
          }
          strArray6[index10] = Operators.CompareString(strArray6[index10], "", false) == 0 ? "Reinforcement units: -" : "Reinforcement units: " + strArray6[index10] + ".";
        }
      }
      PdfDocument pdfDocument = new PdfDocument();
      XFont xfont1 = new XFont("Arial", 8.0, XFontStyle.Italic);
      XFont xfont2 = new XFont("Arial", 10.0, XFontStyle.Regular);
      XFont xfont3 = new XFont("Arial", 8.0, XFontStyle.Regular);
      XFont xfont4 = new XFont("Arial", 20.0, XFontStyle.Bold);
      XFont xfont5 = new XFont("Arial", 40.0, XFontStyle.Bold);
      XPen xpen = new XPen(XColors.Black, 2.0);
      XPen pen = new XPen(XColors.Gray, 4.0);
      XBrush xbrush1 = (XBrush) new XSolidBrush(XColors.Gray);
      XBrush xbrush2 = (XBrush) new XSolidBrush(XColors.DarkGray);
      XBrush xbrush3 = (XBrush) new XSolidBrush(XColors.Black);
      XBrush xbrush4 = (XBrush) new XSolidBrush(XColor.FromArgb((int) byte.MaxValue, 220, 220, 240));
      XBrush xbrush5 = (XBrush) new XSolidBrush(XColor.FromArgb((int) byte.MaxValue, 170, 170, (int) byte.MaxValue));
      PdfPage pdfPage1 = pdfDocument.AddPage();
      pdfPage1.Size = PageSize.A4;
      XGraphics xgraphics1 = XGraphics.FromPdfPage(pdfPage1);
      string str7 = str2;
      XGraphics xgraphics2 = xgraphics1;
      string text1 = str7;
      XFont font1 = xfont4;
      XBrush brush1 = xbrush3;
      XRect xrect = new XRect(0.0, 40.0, (double) pdfPage1.Width, (double) pdfPage1.Height + 40.0);
      XRect layoutRectangle1 = xrect;
      XStringFormat center1 = XStringFormats.Center;
      xgraphics2.DrawString(text1, font1, brush1, layoutRectangle1, center1);
      string str8 = "Order of Battle Guide";
      XGraphics xgraphics3 = xgraphics1;
      string text2 = str8;
      XFont font2 = xfont5;
      XBrush brush2 = xbrush3;
      xrect = new XRect(0.0, -40.0, (double) pdfPage1.Width, (double) pdfPage1.Height - 40.0);
      XRect layoutRectangle2 = xrect;
      XStringFormat center2 = XStringFormats.Center;
      xgraphics3.DrawString(text2, font2, brush2, layoutRectangle2, center2);
      string str9 = "for";
      XGraphics xgraphics4 = xgraphics1;
      string text3 = str9;
      XFont font3 = xfont4;
      XBrush brush3 = xbrush3;
      xrect = new XRect(0.0, 0.0, (double) pdfPage1.Width, (double) pdfPage1.Height + 0.0);
      XRect layoutRectangle3 = xrect;
      XStringFormat center3 = XStringFormats.Center;
      xgraphics4.DrawString(text3, font3, brush3, layoutRectangle3, center3);
      string str10 = str1;
      XGraphics xgraphics5 = xgraphics1;
      string text4 = str10;
      XFont font4 = xfont2;
      XBrush brush4 = xbrush3;
      xrect = new XRect(0.0, 80.0, (double) pdfPage1.Width, (double) pdfPage1.Height + 80.0);
      XRect layoutRectangle4 = xrect;
      XStringFormat center4 = XStringFormats.Center;
      xgraphics5.DrawString(text4, font4, brush4, layoutRectangle4, center4);
      string title = "Order of Battle Guide for " + str2;
      PdfOutline pdfOutline = pdfDocument.Outlines.Add(title, pdfPage1, true, PdfOutlineStyle.Bold, XColors.DarkGray);
      PdfPage pdfPage2 = pdfDocument.AddPage();
      pdfPage2.Size = PageSize.A4;
      XGraphics xgraphics6 = XGraphics.FromPdfPage(pdfPage2);
      string str11 = "INDEX";
      int num1 = 0;
      int num2 = 0;
      XGraphics xgraphics7 = xgraphics6;
      string text5 = str11;
      XFont font5 = xfont4;
      XBrush brush5 = xbrush3;
      xrect = new XRect(0.0, 0.0, (double) pdfPage2.Width, 40.0);
      XRect layoutRectangle5 = xrect;
      XStringFormat center5 = XStringFormats.Center;
      xgraphics7.DrawString(text5, font5, brush5, layoutRectangle5, center5);
      int listCount3 = listClass.ListCount;
      for (int index = 0; index <= listCount3; ++index)
      {
        ++num2;
        string str12 = this.game.Data.HistoricalUnitObj[listClass.ListData[index]].Name;
        if (str12.Length > 20)
          str12 = Strings.Left(str12, 20);
        if (num2 > 1 + (int) Math.Round((double) listClass.ListCount / 3.0))
        {
          num2 = 1;
          ++num1;
        }
        XGraphics xgraphics8 = xgraphics6;
        string text6 = str12;
        XFont font6 = xfont3;
        XBrush brush6 = xbrush3;
        xrect = new XRect((double) (40 + num1 * 180), (double) (35 + num2 * 10), 110.0, 10.0);
        XRect layoutRectangle6 = xrect;
        XStringFormat topLeft = XStringFormats.TopLeft;
        xgraphics8.DrawString(text6, font6, brush6, layoutRectangle6, topLeft);
        XGraphics xgraphics9 = xgraphics6;
        string text7 = (index + 3).ToString();
        XFont font7 = xfont3;
        XBrush brush7 = xbrush3;
        xrect = new XRect((double) (40 + num1 * 180 + 115), (double) (35 + num2 * 10), 30.0, 10.0);
        XRect layoutRectangle7 = xrect;
        XStringFormat topCenter = XStringFormats.TopCenter;
        xgraphics9.DrawString(text7, font7, brush7, layoutRectangle7, topCenter);
      }
      pdfOutline.Outlines.Add("Index", pdfPage2, true);
      int listCount4 = listClass.ListCount;
      for (int index18 = 0; index18 <= listCount4; ++index18)
      {
        int hisnr = listClass.ListData[index18];
        int red = this.game.Data.RegimeObj[this.game.Data.HistoricalUnitObj[hisnr].TempRegime].Red;
        int green = this.game.Data.RegimeObj[this.game.Data.HistoricalUnitObj[hisnr].TempRegime].Green;
        int blue = this.game.Data.RegimeObj[this.game.Data.HistoricalUnitObj[hisnr].TempRegime].Blue;
        xbrush4 = (XBrush) new XSolidBrush(XColor.FromArgb((int) byte.MaxValue, (int) Math.Round((double) red + (double) ((int) byte.MaxValue - red) * 0.85), (int) Math.Round((double) green + (double) ((int) byte.MaxValue - green) * 0.85), (int) Math.Round((double) blue + (double) ((int) byte.MaxValue - blue) * 0.85)));
        XBrush brush8 = (XBrush) new XSolidBrush(XColor.FromArgb((int) byte.MaxValue, (int) Math.Round((double) red + (double) ((int) byte.MaxValue - red) * 0.75), (int) Math.Round((double) green + (double) ((int) byte.MaxValue - green) * 0.75), (int) Math.Round((double) blue + (double) ((int) byte.MaxValue - blue) * 0.75)));
        PdfPage pdfPage3 = pdfDocument.AddPage();
        pdfPage3.Size = PageSize.A4;
        xgraphics6 = XGraphics.FromPdfPage(pdfPage3);
        XGraphics xgraphics10 = xgraphics6;
        string text8 = "ORDER OF BATTLE GUIDE : " + Strings.UCase(str2);
        XFont font8 = xfont1;
        XBrush brush9 = xbrush1;
        xrect = new XRect(0.0, 5.0, (double) pdfPage3.Width, 10.0);
        XRect layoutRectangle8 = xrect;
        XStringFormat center6 = XStringFormats.Center;
        xgraphics10.DrawString(text8, font8, brush9, layoutRectangle8, center6);
        string name1 = this.game.Data.HistoricalUnitObj[hisnr].Name;
        pdfOutline.Outlines.Add(name1, pdfPage3, true);
        XGraphics xgraphics11 = xgraphics6;
        string text9 = name1;
        XFont font9 = xfont4;
        XBrush brush10 = xbrush3;
        xrect = new XRect(0.0, 30.0, (double) pdfPage3.Width, 30.0);
        XRect layoutRectangle9 = xrect;
        XStringFormat center7 = XStringFormats.Center;
        xgraphics11.DrawString(text9, font9, brush10, layoutRectangle9, center7);
        int historicalsSubUnitCount1 = this.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(hisnr);
        string str13 = historicalsSubUnitCount1 != 1 ? "formation has " + historicalsSubUnitCount1.ToString() + " subunits." : "formation has " + historicalsSubUnitCount1.ToString() + " subunit.";
        XGraphics xgraphics12 = xgraphics6;
        string text10 = str13;
        XFont font10 = xfont2;
        XBrush brush11 = xbrush3;
        xrect = new XRect(0.0, 70.0, (double) pdfPage3.Width, 15.0);
        XRect layoutRectangle10 = xrect;
        XStringFormat center8 = XStringFormats.Center;
        xgraphics12.DrawString(text10, font10, brush11, layoutRectangle10, center8);
        int num3 = 95;
        int num4 = 0;
        int historicalsSubUnitCount2 = this.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(hisnr);
        for (int index19 = 0; index19 <= historicalsSubUnitCount2; ++index19)
        {
          int num5 = 0;
          if (this.game.Data.HistoricalUnitObj[hisnr].SubParts[index19] > -1)
          {
            int preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[hisnr].SubParts[index19]);
            if (preDef > -1)
            {
              num5 = 10 * (this.game.Data.UnitObj[preDef].SFCount + 1) + 8;
              if (num5 < 92)
                num5 = 92;
            }
          }
          num4 += num5;
        }
        int height1 = num4 + 10;
        xgraphics6.DrawRoundedRectangle(pen, brush8, 40, num3, 515, height1, 20, 20);
        xgraphics6.DrawLine(pen, 257.5, (double) num3, 257.5, (double) (num3 + height1));
        int index20 = 0;
        int num6;
        do
        {
          if (this.game.Data.HistoricalUnitObj[hisnr].SubParts[index20] > -1)
          {
            int preDef = this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[hisnr].SubParts[index20]);
            if (preDef > -1)
            {
              num3 += 3;
              if (index20 > 0 & num6 < 90)
                num3 += 90 - num6;
              if (index20 > 0 & index20 < this.game.HandyFunctionsObj.GetHistoricalsSubUnitCount(hisnr))
              {
                xgraphics6.DrawLine(pen, 40, num3, 555, num3);
                num3 += 4;
              }
              num6 = 4;
              int x1 = 90;
              int width1 = 158;
              int height2 = 10;
              if (this.game.Data.HistoricalUnitObj[hisnr].TempRegime > -1)
              {
                XImage image = XImage.FromGdiPlusImage((Image) this.game.CustomBitmapObj.DrawBigCounter(this.game.Data.HistoricalUnitObj[hisnr].TempRegime));
                xgraphics6.DrawImage(image, x1, num3 + 15);
              }
              if (this.game.Data.HistoricalUnitObj[hisnr].Counter > -1 & this.game.Data.HistoricalUnitObj[hisnr].Type < 5)
              {
                XImage image = XImage.FromGdiPlusImage((Image) BitmapStore.GetBitmap(this.game.NATO[this.game.Data.HistoricalUnitObj[hisnr].Counter], 1));
                xgraphics6.DrawImage(image, x1 - 5, num3 + 15);
              }
              else if (this.game.Data.HistoricalUnitObj[hisnr].Type >= 5)
              {
                if (this.game.Data.HistoricalUnitObj[hisnr].Counter > 0)
                {
                  XImage image = XImage.FromGdiPlusImage((Image) BitmapStore.GetBitmap(this.game.NATO[this.game.Data.HistoricalUnitObj[hisnr].Counter], 1));
                  xgraphics6.DrawImage(image, x1 - 5, num3 + 15);
                }
                else
                {
                  XImage image = XImage.FromGdiPlusImage((Image) BitmapStore.GetBitmap(this.game.Data.RegimeObj[this.game.Data.HistoricalUnitObj[hisnr].TempRegime].HQSpriteNr, 1));
                  xgraphics6.DrawImage(image, x1 - 5, num3 + 15);
                }
              }
              string name2 = this.game.Data.UnitObj[preDef].Name;
              XGraphics xgraphics13 = xgraphics6;
              string text11 = name2;
              XFont font11 = xfont2;
              XBrush brush12 = xbrush3;
              xrect = new XRect((double) x1, (double) num3, (double) width1, (double) height2);
              XRect layoutRectangle11 = xrect;
              XStringFormat topLeft1 = XStringFormats.TopLeft;
              xgraphics13.DrawString(text11, font11, brush12, layoutRectangle11, topLeft1);
              int x2 = 308;
              int width2 = 158;
              int height3 = 10;
              int sfCount = this.game.Data.UnitObj[preDef].SFCount;
              for (int index21 = 0; index21 <= sfCount; ++index21)
              {
                int sf = this.game.Data.UnitObj[preDef].SFList[index21];
                int type = this.game.Data.SFObj[sf].Type;
                string str14 = (this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].Ratio).ToString() + "x " + this.game.Data.ReinfName[this.game.Data.SFTypeObj[type].ReinforcementType] + " (" + this.game.Data.PeopleObj[this.game.Data.SFObj[sf].People].Name + ")";
                XGraphics xgraphics14 = xgraphics6;
                string text12 = str14;
                XFont font12 = xfont2;
                XBrush brush13 = xbrush3;
                xrect = new XRect((double) x2, (double) num3, (double) width2, (double) height3);
                XRect layoutRectangle12 = xrect;
                XStringFormat topLeft2 = XStringFormats.TopLeft;
                xgraphics14.DrawString(text12, font12, brush13, layoutRectangle12, topLeft2);
                num3 += 10;
                num6 += 10;
              }
            }
          }
          ++index20;
        }
        while (index20 <= 9);
        if (num6 < 92)
          num3 += 92 - num6;
        int y1 = num3 + 30;
        int x3 = 40;
        int width3 = 700;
        int height4 = 15;
        GameClass game1 = this.game;
        Font tfont1 = new Font(this.game.FontCol.Families[1], 8f, FontStyle.Regular);
        string tText1 = strArray1[index18];
        Bitmap bitmap1 = (Bitmap) null;
        ref Bitmap local1 = ref bitmap1;
        TextAreaClass2 textAreaClass2_1 = new TextAreaClass2(game1, 740, 5, tfont1, tText1, tbackbitmap: (ref local1));
        int listCount5 = textAreaClass2_1.ListObj[0].ListCount;
        for (int index22 = 0; index22 <= listCount5; ++index22)
        {
          XGraphics xgraphics15 = xgraphics6;
          string text13 = textAreaClass2_1.ListObj[0].ListName[index22];
          XFont font13 = xfont3;
          XBrush brush14 = xbrush3;
          xrect = new XRect((double) x3, (double) y1, (double) width3, (double) height4);
          XRect layoutRectangle13 = xrect;
          XStringFormat topLeft = XStringFormats.TopLeft;
          xgraphics15.DrawString(text13, font13, brush14, layoutRectangle13, topLeft);
          y1 += 8;
        }
        int y2 = y1 + 8;
        int x4 = 40;
        int width4 = 700;
        int height5 = 15;
        GameClass game2 = this.game;
        Font tfont2 = new Font(this.game.FontCol.Families[1], 8f, FontStyle.Regular);
        string tText2 = strArray6[index18];
        Bitmap bitmap2 = (Bitmap) null;
        ref Bitmap local2 = ref bitmap2;
        TextAreaClass2 textAreaClass2_2 = new TextAreaClass2(game2, 740, 5, tfont2, tText2, tbackbitmap: (ref local2));
        int listCount6 = textAreaClass2_2.ListObj[0].ListCount;
        for (int index23 = 0; index23 <= listCount6; ++index23)
        {
          XGraphics xgraphics16 = xgraphics6;
          string text14 = textAreaClass2_2.ListObj[0].ListName[index23];
          XFont font14 = xfont3;
          XBrush brush15 = xbrush3;
          xrect = new XRect((double) x4, (double) y2, (double) width4, (double) height5);
          XRect layoutRectangle14 = xrect;
          XStringFormat topLeft = XStringFormats.TopLeft;
          xgraphics16.DrawString(text14, font14, brush15, layoutRectangle14, topLeft);
          y2 += 8;
        }
        XGraphics xgraphics17 = xgraphics6;
        string text15 = "page " + pdfDocument.PageCount.ToString();
        XFont font15 = xfont1;
        XBrush brush16 = xbrush1;
        xrect = new XRect(0.0, pdfPage3.Height.Value - 15.0, (double) pdfPage3.Width, 10.0);
        XRect layoutRectangle15 = xrect;
        XStringFormat center9 = XStringFormats.Center;
        xgraphics17.DrawString(text15, font15, brush16, layoutRectangle15, center9);
      }
      xgraphics6.Dispose();
      string path = this.game.AppPath + "logs/" + str2 + "_orderofbattleguide.pdf";
      pdfDocument.Save(path);
      pdfDocument.Dispose();
    }

    public void PdfReinforcements()
    {
      string str1 = Interaction.InputBox("Give version number please, or leave blank", "Shadow Empire : Planetary Conquest");
      string str2 = Interaction.InputBox("Give title", "Shadow Empire : Planetary Conquest");
      SimpleList[] simpleListArray = new SimpleList[this.game.Data.RegimeCounter + 1];
      int regimeCounter1 = this.game.Data.RegimeCounter;
      for (int index = 0; index <= regimeCounter1; ++index)
      {
        simpleListArray[index] = new SimpleList();
        int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
        for (int tid = 0; tid <= historicalUnitCounter; ++tid)
        {
          if (this.game.Data.HistoricalUnitObj[tid].TempVar3 > 0 & this.game.Data.HistoricalUnitObj[tid].TempRegime == index & !this.game.Data.HistoricalUnitObj[tid].Model && this.game.Data.HistoricalUnitObj[tid].TempVar4 > 0 & this.game.Data.HistoricalUnitObj[tid].TempVar4 <= 12 & this.game.Data.HistoricalUnitObj[tid].TempVar5 > 0 & this.game.Data.HistoricalUnitObj[tid].TempVar5 <= 31 && DateTime.Compare(new DateTime(this.game.Data.HistoricalUnitObj[tid].TempVar3, this.game.Data.HistoricalUnitObj[tid].TempVar4, this.game.Data.HistoricalUnitObj[tid].TempVar5), this.game.Data.StartData) >= 0)
            simpleListArray[index].Add(tid, this.game.Data.HistoricalUnitObj[tid].TempVar3 * 1000000 + this.game.Data.HistoricalUnitObj[tid].TempVar4 * 100 + this.game.Data.HistoricalUnitObj[tid].TempVar5 * 1, this.game.Data.HistoricalUnitObj[tid].TempVar3, this.game.Data.HistoricalUnitObj[tid].TempVar4, this.game.Data.HistoricalUnitObj[tid].TempVar5);
        }
        simpleListArray[index].Sort();
      }
      PdfDocument pdfDocument = new PdfDocument();
      XFont xfont1 = new XFont("Arial", 8.0, XFontStyle.Italic);
      XFont xfont2 = new XFont("Arial", 10.0, XFontStyle.Regular);
      XFont xfont3 = new XFont("Arial", 10.0, XFontStyle.Bold);
      XFont xfont4 = new XFont("Arial", 8.0, XFontStyle.Regular);
      XFont xfont5 = new XFont("Arial", 20.0, XFontStyle.Bold);
      XFont xfont6 = new XFont("Arial", 40.0, XFontStyle.Bold);
      XPen xpen1 = new XPen(XColors.Black, 2.0);
      XPen xpen2 = new XPen(XColors.Gray, 4.0);
      XBrush xbrush1 = (XBrush) new XSolidBrush(XColors.Gray);
      XBrush xbrush2 = (XBrush) new XSolidBrush(XColors.DarkGray);
      XBrush xbrush3 = (XBrush) new XSolidBrush(XColors.Black);
      XBrush xbrush4 = (XBrush) new XSolidBrush(XColor.FromArgb((int) byte.MaxValue, 220, 220, 240));
      XBrush xbrush5 = (XBrush) new XSolidBrush(XColor.FromArgb((int) byte.MaxValue, 170, 170, (int) byte.MaxValue));
      PdfPage pdfPage1 = pdfDocument.AddPage();
      pdfPage1.Size = PageSize.A4;
      XGraphics xgraphics1 = XGraphics.FromPdfPage(pdfPage1);
      string str3 = str2;
      XGraphics xgraphics2 = xgraphics1;
      string text1 = str3;
      XFont font1 = xfont5;
      XBrush brush1 = xbrush3;
      XRect xrect = new XRect(0.0, 40.0, (double) pdfPage1.Width, (double) pdfPage1.Height + 40.0);
      XRect layoutRectangle1 = xrect;
      XStringFormat center1 = XStringFormats.Center;
      xgraphics2.DrawString(text1, font1, brush1, layoutRectangle1, center1);
      string str4 = "Reinforcement Units Guide";
      XGraphics xgraphics3 = xgraphics1;
      string text2 = str4;
      XFont font2 = xfont6;
      XBrush brush2 = xbrush3;
      xrect = new XRect(0.0, -40.0, (double) pdfPage1.Width, (double) pdfPage1.Height - 40.0);
      XRect layoutRectangle2 = xrect;
      XStringFormat center2 = XStringFormats.Center;
      xgraphics3.DrawString(text2, font2, brush2, layoutRectangle2, center2);
      string str5 = "for";
      XGraphics xgraphics4 = xgraphics1;
      string text3 = str5;
      XFont font3 = xfont5;
      XBrush brush3 = xbrush3;
      xrect = new XRect(0.0, 0.0, (double) pdfPage1.Width, (double) pdfPage1.Height + 0.0);
      XRect layoutRectangle3 = xrect;
      XStringFormat center3 = XStringFormats.Center;
      xgraphics4.DrawString(text3, font3, brush3, layoutRectangle3, center3);
      string str6 = str1;
      XGraphics xgraphics5 = xgraphics1;
      string text4 = str6;
      XFont font4 = xfont2;
      XBrush brush4 = xbrush3;
      xrect = new XRect(0.0, 80.0, (double) pdfPage1.Width, (double) pdfPage1.Height + 80.0);
      XRect layoutRectangle4 = xrect;
      XStringFormat center4 = XStringFormats.Center;
      xgraphics5.DrawString(text4, font4, brush4, layoutRectangle4, center4);
      string title = "Reinforcement Units Guide for " + str2;
      PdfOutline pdfOutline = pdfDocument.Outlines.Add(title, pdfPage1, true, PdfOutlineStyle.Bold, XColors.DarkGray);
      int regimeCounter2 = this.game.Data.RegimeCounter;
      for (int index = 0; index <= regimeCounter2; ++index)
      {
        if (simpleListArray[index].Counter > -1)
        {
          int red = this.game.Data.RegimeObj[index].Red;
          int green = this.game.Data.RegimeObj[index].Green;
          int blue = this.game.Data.RegimeObj[index].Blue;
          xbrush4 = (XBrush) new XSolidBrush(XColor.FromArgb((int) byte.MaxValue, (int) Math.Round((double) red + (double) ((int) byte.MaxValue - red) * 0.85), (int) Math.Round((double) green + (double) ((int) byte.MaxValue - green) * 0.85), (int) Math.Round((double) blue + (double) ((int) byte.MaxValue - blue) * 0.85)));
          xbrush5 = (XBrush) new XSolidBrush(XColor.FromArgb((int) byte.MaxValue, (int) Math.Round((double) red + (double) ((int) byte.MaxValue - red) * 0.75), (int) Math.Round((double) green + (double) ((int) byte.MaxValue - green) * 0.75), (int) Math.Round((double) blue + (double) ((int) byte.MaxValue - blue) * 0.75)));
          PdfPage pdfPage2 = pdfDocument.AddPage();
          pdfPage2.Size = PageSize.A4;
          xgraphics1 = XGraphics.FromPdfPage(pdfPage2);
          XGraphics xgraphics6 = xgraphics1;
          string text5 = "REINFORCEMENT UNITS GUIDE : " + Strings.UCase(str2);
          XFont font5 = xfont1;
          XBrush brush5 = xbrush1;
          xrect = new XRect(0.0, 5.0, (double) pdfPage2.Width, 10.0);
          XRect layoutRectangle5 = xrect;
          XStringFormat center5 = XStringFormats.Center;
          xgraphics6.DrawString(text5, font5, brush5, layoutRectangle5, center5);
          XGraphics xgraphics7 = xgraphics1;
          string text6 = "page " + pdfDocument.PageCount.ToString();
          XFont font6 = xfont1;
          XBrush brush6 = xbrush1;
          ref XRect local1 = ref xrect;
          XUnit height = pdfPage2.Height;
          double y1 = height.Value - 15.0;
          double width1 = (double) pdfPage2.Width;
          local1 = new XRect(0.0, y1, width1, 10.0);
          XRect layoutRectangle6 = xrect;
          XStringFormat center6 = XStringFormats.Center;
          xgraphics7.DrawString(text6, font6, brush6, layoutRectangle6, center6);
          pdfOutline.Outlines.Add(this.game.Data.RegimeObj[index].Name, pdfPage2, true);
          XGraphics xgraphics8 = xgraphics1;
          string name = this.game.Data.RegimeObj[index].Name;
          XFont font7 = xfont5;
          XBrush brush7 = xbrush3;
          xrect = new XRect(40.0, 25.0, (double) pdfPage2.Width, 30.0);
          XRect layoutRectangle7 = xrect;
          XStringFormat topLeft1 = XStringFormats.TopLeft;
          xgraphics8.DrawString(name, font7, brush7, layoutRectangle7, topLeft1);
          int y2 = 40;
          int x = 40;
          simpleListArray[index].Sort();
          while (simpleListArray[index].Counter > -1)
          {
            int y3 = y2 + 20;
            int num = simpleListArray[index].Weight[0];
            string str7 = simpleListArray[index].Data3[0].ToString() + "-" + this.game.HandyFunctionsObj.GetMonth(simpleListArray[index].Data2[0]) + "-" + simpleListArray[index].Data1[0].ToString();
            XGraphics xgraphics9 = xgraphics1;
            string text7 = str7;
            XFont font8 = xfont3;
            XBrush brush8 = xbrush3;
            xrect = new XRect((double) x, (double) y3, (double) pdfPage2.Width, 10.0);
            XRect layoutRectangle8 = xrect;
            XStringFormat topLeft2 = XStringFormats.TopLeft;
            xgraphics9.DrawString(text7, font8, brush8, layoutRectangle8, topLeft2);
            y2 = y3 + 10;
            for (int counter = simpleListArray[index].Counter; counter >= 0; counter += -1)
            {
              if (num == simpleListArray[index].Weight[counter])
              {
                y2 += 10;
                string str8 = "-" + this.game.Data.HistoricalUnitObj[simpleListArray[index].Id[counter]].Name;
                XGraphics xgraphics10 = xgraphics1;
                string text8 = str8;
                XFont font9 = xfont2;
                XBrush brush9 = xbrush3;
                xrect = new XRect((double) x, (double) y2, (double) pdfPage2.Width, 10.0);
                XRect layoutRectangle9 = xrect;
                XStringFormat topLeft3 = XStringFormats.TopLeft;
                xgraphics10.DrawString(text8, font9, brush9, layoutRectangle9, topLeft3);
                simpleListArray[index].RemoveNr(counter);
                if (y2 > 780 & x < 300)
                {
                  y2 = 20;
                  x = 320;
                }
                else if (y2 > 780 & x > 300)
                {
                  y2 = 20;
                  x = 40;
                  pdfPage2 = pdfDocument.AddPage();
                  pdfPage2.Size = PageSize.A4;
                  xgraphics1 = XGraphics.FromPdfPage(pdfPage2);
                  XGraphics xgraphics11 = xgraphics1;
                  string text9 = "REINFORCEMENT UNITS GUIDE : " + Strings.UCase(str2);
                  XFont font10 = xfont1;
                  XBrush brush10 = xbrush1;
                  xrect = new XRect(0.0, 5.0, (double) pdfPage2.Width, 10.0);
                  XRect layoutRectangle10 = xrect;
                  XStringFormat center7 = XStringFormats.Center;
                  xgraphics11.DrawString(text9, font10, brush10, layoutRectangle10, center7);
                  XGraphics xgraphics12 = xgraphics1;
                  string text10 = "page " + pdfDocument.PageCount.ToString();
                  XFont font11 = xfont1;
                  XBrush brush11 = xbrush1;
                  ref XRect local2 = ref xrect;
                  height = pdfPage2.Height;
                  double y4 = height.Value - 15.0;
                  double width2 = (double) pdfPage2.Width;
                  local2 = new XRect(0.0, y4, width2, 10.0);
                  XRect layoutRectangle11 = xrect;
                  XStringFormat center8 = XStringFormats.Center;
                  xgraphics12.DrawString(text10, font11, brush11, layoutRectangle11, center8);
                }
              }
            }
            if (y2 > 720 & x < 300)
            {
              y2 = 20;
              x = 320;
            }
            else if (y2 > 720 & x > 300)
            {
              y2 = 20;
              x = 40;
              pdfPage2 = pdfDocument.AddPage();
              pdfPage2.Size = PageSize.A4;
              xgraphics1 = XGraphics.FromPdfPage(pdfPage2);
              XGraphics xgraphics13 = xgraphics1;
              string text11 = "HISTORICAL REINFORCEMENT SCHEDULE BOOKLET FOR " + Strings.UCase(this.game.Data.Name.ToString());
              XFont font12 = xfont1;
              XBrush brush12 = xbrush1;
              xrect = new XRect(0.0, 5.0, (double) pdfPage2.Width, 10.0);
              XRect layoutRectangle12 = xrect;
              XStringFormat center9 = XStringFormats.Center;
              xgraphics13.DrawString(text11, font12, brush12, layoutRectangle12, center9);
              XGraphics xgraphics14 = xgraphics1;
              string text12 = "page " + pdfDocument.PageCount.ToString();
              XFont font13 = xfont1;
              XBrush brush13 = xbrush1;
              ref XRect local3 = ref xrect;
              height = pdfPage2.Height;
              double y5 = height.Value - 15.0;
              double width3 = (double) pdfPage2.Width;
              local3 = new XRect(0.0, y5, width3, 10.0);
              XRect layoutRectangle13 = xrect;
              XStringFormat center10 = XStringFormats.Center;
              xgraphics14.DrawString(text12, font13, brush13, layoutRectangle13, center10);
            }
          }
        }
      }
      xgraphics1.Dispose();
      string path = this.game.AppPath + "logs/" + str2 + "_reinforcementtroopsguide.pdf";
      pdfDocument.Save(path);
      pdfDocument.Dispose();
    }
  }
}
