// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.RandomWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingMicrosoft.VisualBasic.CompilerServices;
// usingSystem;
// usingSystem.Drawing;
// usingSystem.Drawing.Drawing2D;
// usingSystem.Drawing.Text;
// usingSystem.IO;
// usingSystem.Runtime.CompilerServices;
// usingSystem.Windows.Forms;

namespace WindowsApplication1
{
  pub class RandomWindowClass : WindowClass
  {
     BStartGameID: i32;
     BLoadGameID: i32;
     BLadderID: i32;
     BSaveGameID: i32;
     BEditorID: i32;
     TempText: i32;
     TempText2: i32;
     txt1: i32;
     txt2: i32;
     tab1: i32;
     tab2: i32;
     tabmode: i32;
     txt3: i32;
     shrowd: i32;
     doshrowd: i32;
     maploop: i32;
     singlestart: i32;
     dosinglestart: i32;
     dostats: i32;
     optimize: i32;
     dooptimize: i32;
     optimizetext: i32;
     oldkingdomtext: i32;
     domaploop: i32;
     dooldkingdom: i32;
     oldkingdom: i32;
     maplooptext: i32;
     doallied: i32;
     allied: i32;
     alliedtext: i32;
     shrowdtext: i32;
     mirror: i32;
     domirror: i32;
     mirrortext: i32;
     blockcenter: i32;
     dofirsttech: i32;
     firsttech: i32;
     firsttechtext: i32;
     doblockcenter: i32;
     blockcentertext: i32;
     opt1: i32;
     opt2: i32;
     opt3: i32;
     opt4: i32;
     opt5: i32;
     opt6: i32;
     opt7: i32;
     opt8: i32;
     opt9: i32;
     opt10: i32;
     opt11: i32;
     opt12: i32;
     cancelID: i32;
     o1: i32;
     o2: i32;
     o3: i32;
     o16: i32;
     o17: i32;
     o4: i32;
     o5: i32;
     o18: i32;
     o6: i32;
     o7: i32;
     o8: i32;
     o9: i32;
     o10: i32;
     o11: i32;
     o12: i32;
     o13: i32;
     o14: i32;
     o15: i32;
     o19: i32;
     w1: i32;
     w2: i32;
     w3: i32;
     w4: i32;
     w5: i32;
     w6: i32;
     w7: i32;
     w8: i32;
     w9: i32;
     w10: i32;
     w11: i32;
     w12: i32;
     w13: i32;
     w14: i32;
     w15: i32;
     w16: i32;
     w17: i32;
     w21: i32;
     r1: i32;
     r2: i32;
     r3: i32;
     r4: i32;
     r5: i32;
     r6: i32;
     r7: i32;
     r8: i32;
     r9: i32;
     r10: i32;
     r11: i32;
     r12: i32;
     r13: i32;
     r14: i32;
     r15: i32;
     r16: i32;
     r17: i32;
     r21: i32;
     r26: i32;
     r27: i32;
     r28: i32;
     h1: i32;
     h2: i32;
     h3: i32;
     h4: i32;
     h5: i32;
     h6: i32;
     h7: i32;
     h8: i32;
     h9: i32;
     h10: i32;
     h11: i32;
     h12: i32;
     optr1: i32;
     optr2: i32;
     optr3: i32;
     optr4: i32;
     optr5: i32;
     optr6: i32;
     optr7: i32;
     optr8: i32;
     z1: i32;
     z2: i32;
     Srawuse: i32;
     ListClass RegimeListObj;
     RegimeListId: i32;
     float tempBlink;
     detailnr: i32;
     totvp: i32;
     opt1v: i32;
     opt2v: i32;
     opt3v: i32;
     opt4v: i32;
     opt5v: i32;
     opt6v: i32;
     opt7v: i32;
     opt8v: i32;
     opt9v: i32;
     opt10v: i32;
     opt11v: i32;
     opt12v: i32;
     WATER: i32;
     int[] TownSize;
     bool[] TownCapitol;
     GRASS: i32;
     HIGHMOUNTAIN: i32;
     LOWMOUNTAIN: i32;
     LIGHTFOREST: i32;
     HEAVYFOREST: i32;
     SMALLRIVER: i32;
     URBAN: i32;
     LIGHTURBAN: i32;
     FARMLAND: i32;
     BIGRIVER: i32;
     SWAMP: i32;
     landcur: i32;
     mountaincur: i32;
     forestcur: i32;
     rivercur: i32;
     int[] tempx;
     int[] tempy;
     tempcount: i32;
     namelist: Vec<String>;
     namecount: i32;
     string domasterfile;
     masterfile: i32;
     masterfiletext: i32;
     string Flag1;
     string Flag1b;
     int[,,] curriv;
     int[,,] rivstep;
     Coordinate[,,] nextrivstep;
     RESOURCESLOT: i32;
     Sworldsize: i32;
     Splayer: i32;
     Swater: i32;
     Sclimate: i32;
     Scrate: i32;
     Spop: i32;
     Sraw: i32;
     int[] RegFavClimate;
     int[] Regid;
     object[,] town;
     object[,] town2;

    pub RandomWindowClass( tGame: GameClass, bool Marc)
      : base( tGame, 1024, 768, BackSprite: tGame.BACKGROUND2MARC)
    {
      this.TownSize = new int[10000];
      this.TownCapitol = new bool[10000];
      this.tempx = new int[1001];
      this.tempy = new int[1001];
      this.namelist = new string[1001];
      this.curriv = new int[2, 2, 2];
      this.rivstep = new int[2, 2, 2];
      this.nextrivstep = new Coordinate[2, 2, 2];
      this.RegFavClimate = new int[100];
      this.Regid = new int[100];
      this.town = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.town2 = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.RandomSetup();
      this.DoStuff();
    }

    pub RandomWindowClass( tGame: GameClass)
      : base( tGame, 1024, 768, BackSprite: tGame.BACKGROUND2MARC)
    {
      this.TownSize = new int[10000];
      this.TownCapitol = new bool[10000];
      this.tempx = new int[1001];
      this.tempy = new int[1001];
      this.namelist = new string[1001];
      this.curriv = new int[2, 2, 2];
      this.rivstep = new int[2, 2, 2];
      this.nextrivstep = new Coordinate[2, 2, 2];
      this.RegFavClimate = new int[100];
      this.Regid = new int[100];
      this.town = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.town2 = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.RandomSetup();
      this.DoStuff();
    }

    pub fn RandomSetup()
    {
      this.tempBlink = 0.0f;
      this.detailnr = -1;
      this.opt1v = 20;
      this.opt2v = 20;
      this.opt3v = 2;
      this.opt4v = 100;
      this.opt5v = 0;
      this.opt6v = 30;
      this.opt7v = 25;
      this.opt8v = 5;
      this.opt9v = 2;
      this.opt10v = 2;
      this.opt11v = 100;
      this.doshrowd = 0;
      this.domirror = 0;
      this.dofirsttech = 1;
      this.doallied = 0;
      this.domaploop = 0;
      this.doblockcenter = 0;
      this.domasterfile = this.game.EditObj.RandomUseMaster;
      this.dooldkingdom = 0;
      this.dooptimize = 0;
      this.singlestart = 0;
      this.dosinglestart = 0;
      this.dostats = 1;
      this.Scrate = 1;
      this.Spop = 0;
      this.Sraw = 0;
      this.Srawuse = 1;
      if (this.game.EditObj.ranmem == 1)
      {
        this.optr1 = this.game.EditObj.ranr1;
        this.optr2 = this.game.EditObj.ranr2;
        this.optr3 = this.game.EditObj.ranr3;
        this.optr4 = this.game.EditObj.ranr4;
        this.optr5 = this.game.EditObj.ranr5;
        this.optr6 = this.game.EditObj.ranr6;
        this.optr7 = this.game.EditObj.ranr7;
        this.optr8 = this.game.EditObj.ranr8;
        this.opt1v = this.game.EditObj.ran1;
        this.opt2v = this.game.EditObj.ran2;
        this.opt3v = this.game.EditObj.ran3;
        this.opt4v = this.game.EditObj.ran4;
        this.opt5v = this.game.EditObj.ran5;
        this.opt6v = this.game.EditObj.ran6;
        this.opt7v = this.game.EditObj.ran7;
        this.opt8v = this.game.EditObj.ran8;
        this.opt9v = this.game.EditObj.ran9;
        this.opt10v = this.game.EditObj.ran10;
        this.opt11v = this.game.EditObj.ran11;
        this.opt12v = this.game.EditObj.ran12;
        this.doshrowd = this.game.EditObj.randoshrowd;
        this.domirror = this.game.EditObj.randomirror;
        this.doblockcenter = this.game.EditObj.randoblockcenter;
        this.dofirsttech = this.game.EditObj.randofirsttech;
        this.doallied = this.game.EditObj.randoallied;
        this.domaploop = this.game.EditObj.randomaploop;
        this.dooldkingdom = this.game.EditObj.ranoldkingdom;
        this.dooptimize = this.game.EditObj.ranoptimize;
        this.dosinglestart = this.game.EditObj.ransinglestart;
        this.Sworldsize = this.game.EditObj.ransworldsize;
        this.Splayer = this.game.EditObj.ransplayer;
        this.Swater = this.game.EditObj.ranswater;
        this.Sclimate = this.game.EditObj.ransclimate;
        this.Scrate = this.game.EditObj.ranscrate;
        this.Spop = this.game.EditObj.ranpop;
        this.Sraw = this.game.EditObj.ranraw;
        this.dostats = this.game.EditObj.ranstats;
        this.Srawuse = this.game.EditObj.ranrawuse;
      }
      this.game.EditObj.ranr1 = this.optr1;
      this.game.EditObj.ranr2 = this.optr2;
      this.game.EditObj.ranr3 = this.optr3;
      this.game.EditObj.ranr4 = this.optr4;
      this.game.EditObj.ranr5 = this.optr5;
      this.game.EditObj.ranr6 = this.optr6;
      this.game.EditObj.ranr7 = this.optr7;
      this.game.EditObj.ranr8 = this.optr8;
      this.game.EditObj.ran1 = this.opt1v;
      this.game.EditObj.ran2 = this.opt2v;
      this.game.EditObj.ran3 = this.opt3v;
      this.game.EditObj.ran4 = this.opt4v;
      this.game.EditObj.ran5 = this.opt5v;
      this.game.EditObj.ran6 = this.opt6v;
      this.game.EditObj.ran7 = this.opt7v;
      this.game.EditObj.ran8 = this.opt8v;
      this.game.EditObj.ran9 = this.opt9v;
      this.game.EditObj.ran10 = this.opt10v;
      this.game.EditObj.ran11 = this.opt11v;
      this.game.EditObj.ran12 = this.opt12v;
      this.game.EditObj.randomaploop = this.domaploop;
      this.game.EditObj.randoshrowd = this.doshrowd;
      this.game.EditObj.randomirror = this.domirror;
      this.game.EditObj.randoblockcenter = this.doblockcenter;
      this.game.EditObj.randofirsttech = this.dofirsttech;
      this.game.EditObj.ranmasterfile = this.domasterfile;
      this.game.EditObj.randoallied = this.doallied;
      this.game.EditObj.ranoldkingdom = this.dooldkingdom;
      this.game.EditObj.ranoptimize = this.dooptimize;
      this.game.EditObj.ransinglestart = this.dosinglestart;
      this.game.EditObj.ransworldsize = this.Sworldsize;
      this.game.EditObj.ransplayer = this.Splayer;
      this.game.EditObj.ranswater = this.Swater;
      this.game.EditObj.ransclimate = this.Sclimate;
      this.game.EditObj.ranscrate = this.Scrate;
      this.game.EditObj.ranstats = this.dostats;
      this.game.EditObj.ranraw = this.Sraw;
      this.game.EditObj.ranpop = this.Spop;
      this.game.EditObj.ranrawuse = this.Srawuse;
    }

    pub fn DoStuffShort()
    {
      if (this.o1 > 0)
        this.RemoveSubPart(this.o1);
      if (this.o2 > 0)
        this.RemoveSubPart(this.o2);
      if (this.o3 > 0)
        this.RemoveSubPart(this.o3);
      if (this.o4 > 0)
        this.RemoveSubPart(this.o4);
      if (this.o5 > 0)
        this.RemoveSubPart(this.o5);
      if (this.o6 > 0)
        this.RemoveSubPart(this.o6);
      if (this.o7 > 0)
        this.RemoveSubPart(this.o7);
      if (this.o8 > 0)
        this.RemoveSubPart(this.o8);
      if (this.o9 > 0)
        this.RemoveSubPart(this.o9);
      if (this.o10 > 0)
        this.RemoveSubPart(this.o10);
      if (this.o11 > 0)
        this.RemoveSubPart(this.o11);
      if (this.o12 > 0)
        this.RemoveSubPart(this.o12);
      if (this.o13 > 0)
        this.RemoveSubPart(this.o13);
      if (this.o14 > 0)
        this.RemoveSubPart(this.o14);
      if (this.o15 > 0)
        this.RemoveSubPart(this.o15);
      if (this.o16 > 0)
        this.RemoveSubPart(this.o16);
      if (this.o17 > 0)
        this.RemoveSubPart(this.o17);
      if (this.o18 > 0)
        this.RemoveSubPart(this.o18);
      if (this.o19 > 0)
        this.RemoveSubPart(this.o19);
      if (this.h1 > 0)
        this.RemoveSubPart(this.h1);
      if (this.h2 > 0)
        this.RemoveSubPart(this.h2);
      if (this.h3 > 0)
        this.RemoveSubPart(this.h3);
      if (this.h4 > 0)
        this.RemoveSubPart(this.h4);
      if (this.h5 > 0)
        this.RemoveSubPart(this.h5);
      if (this.h6 > 0)
        this.RemoveSubPart(this.h6);
      if (this.h7 > 0)
        this.RemoveSubPart(this.h7);
      if (this.h8 > 0)
        this.RemoveSubPart(this.h8);
      if (this.h9 > 0)
        this.RemoveSubPart(this.h9);
      if (this.h10 > 0)
        this.RemoveSubPart(this.h10);
      if (this.h11 > 0)
        this.RemoveSubPart(this.h11);
      if (this.h12 > 0)
        this.RemoveSubPart(this.h12);
      if (this.z1 > 0)
        this.RemoveSubPart(this.z1);
      if (this.z2 > 0)
        this.RemoveSubPart(this.z2);
      if (this.w1 > 0)
        this.RemoveSubPart(this.w1);
      if (this.w2 > 0)
        this.RemoveSubPart(this.w2);
      if (this.w3 > 0)
        this.RemoveSubPart(this.w3);
      if (this.w4 > 0)
        this.RemoveSubPart(this.w4);
      if (this.w5 > 0)
        this.RemoveSubPart(this.w5);
      if (this.w6 > 0)
        this.RemoveSubPart(this.w6);
      if (this.w7 > 0)
        this.RemoveSubPart(this.w7);
      if (this.w8 > 0)
        this.RemoveSubPart(this.w8);
      if (this.w9 > 0)
        this.RemoveSubPart(this.w9);
      if (this.w10 > 0)
        this.RemoveSubPart(this.w10);
      if (this.w21 > 0)
        this.RemoveSubPart(this.w21);
      if (this.w11 > 0)
        this.RemoveSubPart(this.w11);
      if (this.w12 > 0)
        this.RemoveSubPart(this.w12);
      if (this.w13 > 0)
        this.RemoveSubPart(this.w13);
      if (this.w14 > 0)
        this.RemoveSubPart(this.w14);
      if (this.w15 > 0)
        this.RemoveSubPart(this.w15);
      if (this.w16 > 0)
        this.RemoveSubPart(this.w16);
      if (this.w17 > 0)
        this.RemoveSubPart(this.w17);
      if (this.r1 > 0)
        this.RemoveSubPart(this.r1);
      if (this.r2 > 0)
        this.RemoveSubPart(this.r2);
      if (this.r3 > 0)
        this.RemoveSubPart(this.r3);
      if (this.r4 > 0)
        this.RemoveSubPart(this.r4);
      if (this.r5 > 0)
        this.RemoveSubPart(this.r5);
      if (this.r6 > 0)
        this.RemoveSubPart(this.r6);
      if (this.r7 > 0)
        this.RemoveSubPart(this.r7);
      if (this.r8 > 0)
        this.RemoveSubPart(this.r8);
      if (this.r9 > 0)
        this.RemoveSubPart(this.r9);
      if (this.r10 > 0)
        this.RemoveSubPart(this.r10);
      if (this.r21 > 0)
        this.RemoveSubPart(this.r21);
      if (this.r11 > 0)
        this.RemoveSubPart(this.r11);
      if (this.r12 > 0)
        this.RemoveSubPart(this.r12);
      if (this.r13 > 0)
        this.RemoveSubPart(this.r13);
      if (this.r14 > 0)
        this.RemoveSubPart(this.r14);
      if (this.r15 > 0)
        this.RemoveSubPart(this.r15);
      if (this.r16 > 0)
        this.RemoveSubPart(this.r16);
      if (this.r17 > 0)
        this.RemoveSubPart(this.r17);
      if (this.r26 > 0)
        this.RemoveSubPart(this.r26);
      if (this.r27 > 0)
        this.RemoveSubPart(this.r27);
      if (this.r28 > 0)
        this.RemoveSubPart(this.r28);
      if (this.tab1 > 0)
        this.RemoveSubPart(this.tab1);
      if (this.tab2 > 0)
        this.RemoveSubPart(this.tab2);
      if (this.BStartGameID > 0)
        this.RemoveSubPart(this.BStartGameID);
      if (this.cancelID > 0)
        this.RemoveSubPart(this.cancelID);
      if (this.TempText > 0)
        this.RemoveSubPart(this.TempText);
      if (this.game.ModIntroType == 0)
        this.NewBackGroundAndClearAll(1024, 768, this.game.BACKGROUND2MARC);
      else
        this.NewBackGroundAndClearAll(1024, 768, this.game.BACKGROUND1MARC);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      Expression.SmoothingMode = SmoothingMode.AntiAlias;
      Expression.TextRenderingHint = TextRenderingHint.AntiAlias;
      Expression.TextContrast = 1;
      let mut tsubpart1: SubPartClass =  new ATTextPartClass("Make Random Scenario Gold", this.game.VicFont8, 810, 35, true, tBlackBack: true);
      this.TempText = this.AddSubPart( tsubpart1, 100, 19, 850, 35, 0);
      let mut tsubpart2: SubPartClass =  new TextButtonPartClass("Basic settings", 150, tBackbitmap: ( this.OwnBitmap), bbx: 300, bby: 700, tred: (this.tabmode == 0));
      this.tab1 = this.AddSubPart( tsubpart2, 300, 700, 150, 35, 1);
      let mut tsubpart3: SubPartClass =  new TextButtonPartClass("Extra settings", 150, tBackbitmap: ( this.OwnBitmap), bbx: 500, bby: 700, tred: (this.tabmode == 1));
      this.tab2 = this.AddSubPart( tsubpart3, 500, 700, 150, 35, 1);
      DrawMod.DrawBlock( Expression, 35, 80, 935, 590,  this.game.VicColor4.R,  this.game.VicColor4.G,  this.game.VicColor4.B,  Math.Round( this.game.VicColor4.A / 2.0));
      DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  Expression, 35, 80, 935, 590, -1, -1);
      SubPartClass tsubpart4;
      if (this.tabmode == 0)
      {
        vicFont2: Font = this.game.VicFont2;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "noworldsize") > 0)
        {
          this.Sworldsize = 0;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "WORLD SIZE", this.game.VicFont1, 100, 97, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart5: SubPartClass =  new SteveRadioPartClass(0, this.Sworldsize == 0, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 130);
          this.o1 = this.AddSubPart( tsubpart5, 100, 130, 35, 35, 1);
          let mut tsubpart6: SubPartClass =  new SteveRadioPartClass(0, this.Sworldsize == 1, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 170);
          this.o2 = this.AddSubPart( tsubpart6, 100, 170, 35, 35, 1);
          let mut tsubpart7: SubPartClass =  new SteveRadioPartClass(0, this.Sworldsize == 2, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 210);
          this.o3 = this.AddSubPart( tsubpart7, 100, 210, 35, 35, 1);
          let mut tsubpart8: SubPartClass =  new SteveRadioPartClass(0, this.Sworldsize == 3, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 250);
          this.o4 = this.AddSubPart( tsubpart8, 100, 250, 35, 35, 1);
          let mut tsubpart9: SubPartClass =  new SteveRadioPartClass(0, this.Sworldsize == 4, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 290);
          this.o5 = this.AddSubPart( tsubpart9, 100, 290, 35, 35, 1);
          let mut tsubpart10: SubPartClass =  new SteveRadioPartClass(0, this.Sworldsize == 5, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 330);
          this.o6 = this.AddSubPart( tsubpart10, 100, 330, 35, 35, 1);
          DrawMod.DrawTextVic2( Expression, "SMALL", vicFont2, 150, 138, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "MEDIUM", vicFont2, 150, 178, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "LARGE", vicFont2, 150, 218, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "X-LARGE", vicFont2, 150, 258, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "XX-LARGE", vicFont2, 150, 298, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "UNPLAYABLY LARGE", vicFont2, 150, 338, this.game.VicColor2, this.game.VicColor2Shade);
        }
        DrawMod.DrawTextVic2( Expression, "PLAYERS", this.game.VicFont1, 370, 97, this.game.VicColor2, this.game.VicColor2Shade);
        let mut num: i32 = 14;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "maxplayer02") > 0)
          num = 2;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "maxplayer03") > 0)
          num = 3;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "maxplayer04") > 0)
          num = 4;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "maxplayer05") > 0)
          num = 5;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "maxplayer06") > 0)
          num = 6;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "maxplayer07") > 0)
          num = 7;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "maxplayer08") > 0)
          num = 8;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "maxplayer09") > 0)
          num = 9;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "maxplayer10") > 0)
          num = 10;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "maxplayer11") > 0)
          num = 11;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "maxplayer12") > 0)
          num = 12;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "maxplayer13") > 0)
          num = 13;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "maxplayer14") > 0)
          num = 14;
        if (num >= 2)
        {
          let mut tsubpart11: SubPartClass =  new SteveRadioPartClass(0, this.Splayer == 0, tBackbitmap: ( this.OwnBitmap), bbx: 370, bby: 130);
          this.w1 = this.AddSubPart( tsubpart11, 370, 130, 35, 35, 1);
        }
        if (num >= 3)
        {
          let mut tsubpart12: SubPartClass =  new SteveRadioPartClass(0, this.Splayer == 1, tBackbitmap: ( this.OwnBitmap), bbx: 370, bby: 170);
          this.w2 = this.AddSubPart( tsubpart12, 370, 170, 35, 35, 1);
        }
        if (num >= 4)
        {
          let mut tsubpart13: SubPartClass =  new SteveRadioPartClass(0, this.Splayer == 2, tBackbitmap: ( this.OwnBitmap), bbx: 370, bby: 210);
          this.w3 = this.AddSubPart( tsubpart13, 370, 210, 35, 35, 1);
        }
        if (num >= 5)
        {
          let mut tsubpart14: SubPartClass =  new SteveRadioPartClass(0, this.Splayer == 3, tBackbitmap: ( this.OwnBitmap), bbx: 370, bby: 250);
          this.w4 = this.AddSubPart( tsubpart14, 370, 250, 35, 35, 1);
        }
        if (num >= 6)
        {
          let mut tsubpart15: SubPartClass =  new SteveRadioPartClass(0, this.Splayer == 4, tBackbitmap: ( this.OwnBitmap), bbx: 370, bby: 290);
          this.w5 = this.AddSubPart( tsubpart15, 370, 290, 35, 35, 1);
        }
        if (num >= 7)
        {
          let mut tsubpart16: SubPartClass =  new SteveRadioPartClass(0, this.Splayer == 5, tBackbitmap: ( this.OwnBitmap), bbx: 370, bby: 330);
          this.w6 = this.AddSubPart( tsubpart16, 370, 330, 35, 35, 1);
        }
        if (num >= 8)
        {
          let mut tsubpart17: SubPartClass =  new SteveRadioPartClass(0, this.Splayer == 6, tBackbitmap: ( this.OwnBitmap), bbx: 530, bby: 130);
          this.w11 = this.AddSubPart( tsubpart17, 530, 130, 35, 35, 1);
        }
        if (num >= 9)
        {
          let mut tsubpart18: SubPartClass =  new SteveRadioPartClass(0, this.Splayer == 7, tBackbitmap: ( this.OwnBitmap), bbx: 530, bby: 170);
          this.w12 = this.AddSubPart( tsubpart18, 530, 170, 35, 35, 1);
        }
        if (num >= 10)
        {
          let mut tsubpart19: SubPartClass =  new SteveRadioPartClass(0, this.Splayer == 8, tBackbitmap: ( this.OwnBitmap), bbx: 530, bby: 210);
          this.w13 = this.AddSubPart( tsubpart19, 530, 210, 35, 35, 1);
        }
        if (num >= 11)
        {
          let mut tsubpart20: SubPartClass =  new SteveRadioPartClass(0, this.Splayer == 9, tBackbitmap: ( this.OwnBitmap), bbx: 530, bby: 250);
          this.w14 = this.AddSubPart( tsubpart20, 530, 250, 35, 35, 1);
        }
        if (num >= 12)
        {
          let mut tsubpart21: SubPartClass =  new SteveRadioPartClass(0, this.Splayer == 10, tBackbitmap: ( this.OwnBitmap), bbx: 530, bby: 290);
          this.w15 = this.AddSubPart( tsubpart21, 530, 290, 35, 35, 1);
        }
        if (num >= 13)
        {
          let mut tsubpart22: SubPartClass =  new SteveRadioPartClass(0, this.Splayer == 11, tBackbitmap: ( this.OwnBitmap), bbx: 530, bby: 330);
          this.w16 = this.AddSubPart( tsubpart22, 530, 330, 35, 35, 1);
        }
        if (num >= 14)
        {
          let mut tsubpart23: SubPartClass =  new SteveRadioPartClass(0, this.Splayer == 12, tBackbitmap: ( this.OwnBitmap), bbx: 530, bby: 370);
          this.w17 = this.AddSubPart( tsubpart23, 530, 370, 35, 35, 1);
        }
        if (num >= 2)
          DrawMod.DrawTextVic2( Expression, "2 PLAYER", vicFont2, 420, 138, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 3)
          DrawMod.DrawTextVic2( Expression, "3 PLAYER", vicFont2, 420, 178, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 4)
          DrawMod.DrawTextVic2( Expression, "4 PLAYER", vicFont2, 420, 218, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 5)
          DrawMod.DrawTextVic2( Expression, "5 PLAYER", vicFont2, 420, 258, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 6)
          DrawMod.DrawTextVic2( Expression, "6 PLAYER", vicFont2, 420, 298, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 7)
          DrawMod.DrawTextVic2( Expression, "7 PLAYER", vicFont2, 420, 338, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 8)
          DrawMod.DrawTextVic2( Expression, "8 PLAYER", vicFont2, 580, 138, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 9)
          DrawMod.DrawTextVic2( Expression, "9 PLAYER", vicFont2, 580, 178, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 10)
          DrawMod.DrawTextVic2( Expression, "10 PLAYER", vicFont2, 580, 218, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 11)
          DrawMod.DrawTextVic2( Expression, "11 PLAYER", vicFont2, 580, 258, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 12)
          DrawMod.DrawTextVic2( Expression, "12 PLAYER", vicFont2, 580, 298, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 13)
          DrawMod.DrawTextVic2( Expression, "13 PLAYER", vicFont2, 580, 338, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 14)
          DrawMod.DrawTextVic2( Expression, "14 PLAYER", vicFont2, 580, 378, this.game.VicColor2, this.game.VicColor2Shade);
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "noworldtype") > 0)
        {
          this.Swater = 0;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "WORLD TYPE", this.game.VicFont1, 750, 97, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart24: SubPartClass =  new SteveRadioPartClass(0, this.Swater == 0, tBackbitmap: ( this.OwnBitmap), bbx: 750, bby: 130);
          this.h1 = this.AddSubPart( tsubpart24, 750, 130, 35, 35, 1);
          let mut tsubpart25: SubPartClass =  new SteveRadioPartClass(0, this.Swater == 1, tBackbitmap: ( this.OwnBitmap), bbx: 750, bby: 170);
          this.h2 = this.AddSubPart( tsubpart25, 750, 170, 35, 35, 1);
          let mut tsubpart26: SubPartClass =  new SteveRadioPartClass(0, this.Swater == 2, tBackbitmap: ( this.OwnBitmap), bbx: 750, bby: 210);
          this.h3 = this.AddSubPart( tsubpart26, 750, 210, 35, 35, 1);
          let mut tsubpart27: SubPartClass =  new SteveRadioPartClass(0, this.Swater == 3, tBackbitmap: ( this.OwnBitmap), bbx: 750, bby: 250);
          this.h4 = this.AddSubPart( tsubpart27, 750, 250, 35, 35, 1);
          let mut tsubpart28: SubPartClass =  new SteveRadioPartClass(0, this.Swater == 4, tBackbitmap: ( this.OwnBitmap), bbx: 750, bby: 290);
          this.h5 = this.AddSubPart( tsubpart28, 750, 290, 35, 35, 1);
          let mut tsubpart29: SubPartClass =  new SteveRadioPartClass(0, this.Swater == 5, tBackbitmap: ( this.OwnBitmap), bbx: 750, bby: 330);
          this.h6 = this.AddSubPart( tsubpart29, 750, 330, 35, 35, 1);
          DrawMod.DrawTextVic2( Expression, "NO OCEANS", vicFont2, 800, 138, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "LAND WORLD", vicFont2, 800, 178, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "NORMAL WORLD", vicFont2, 800, 218, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "BIG OCEANS", vicFont2, 800, 258, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "OCEANIA", vicFont2, 800, 298, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "WATER WORLD", vicFont2, 800, 338, this.game.VicColor2, this.game.VicColor2Shade);
        }
        DrawMod.DrawTextVic2( Expression, "OPTIONS", this.game.VicFont1, 100, 417, this.game.VicColor2, this.game.VicColor2Shade);
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nomaploop") <= 0)
        {
          DrawMod.DrawTextVic2( Expression, "MAP LOOP", vicFont2, 150, 458, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart30: SubPartClass =  new SteveRadioPartClass(0, this.domaploop == 1, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 450);
          this.o7 = this.AddSubPart( tsubpart30, 100, 450, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nomirrorish") > 0)
        {
          this.domirror = 0;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "MIRRORISH", vicFont2, 150, 498, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart31: SubPartClass =  new SteveRadioPartClass(0, this.domirror == 1, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 490);
          this.o8 = this.AddSubPart( tsubpart31, 100, 490, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "noshrowd") > 0)
        {
          this.doshrowd = 0;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "SHROUD", vicFont2, 150, 538, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart32: SubPartClass =  new SteveRadioPartClass(0, this.doshrowd == 1, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 530);
          this.o9 = this.AddSubPart( tsubpart32, 100, 530, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "no1townstart") > 0)
        {
          this.dosinglestart = 0;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "1 TOWN START", vicFont2, 150, 578, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart33: SubPartClass =  new SteveRadioPartClass(0, this.dosinglestart == 1, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 570);
          this.o10 = this.AddSubPart( tsubpart33, 100, 570, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nocostlyresearch") > 0)
        {
          this.opt11v = 100;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "COSTLY RESEARCH", vicFont2, 150, 618, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart34: SubPartClass =  new SteveRadioPartClass(0, this.opt11v == 300, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 610);
          this.o19 = this.AddSubPart( tsubpart34, 100, 610, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nostoneage") > 0)
        {
          this.dofirsttech = 1;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "STONE AGE", vicFont2, 350, 458, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart35: SubPartClass =  new SteveRadioPartClass(0, this.dofirsttech == 0, tBackbitmap: ( this.OwnBitmap), bbx: 300, bby: 450);
          this.o12 = this.AddSubPart( tsubpart35, 300, 450, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nocrates") > 0)
        {
          this.Scrate = 1;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "CRATES", vicFont2, 350, 488, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "HIDDEN AI", vicFont2, 350, 508, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart36: SubPartClass =  new SteveRadioPartClass(0, this.Scrate == 0, tBackbitmap: ( this.OwnBitmap), bbx: 300, bby: 490);
          this.o13 = this.AddSubPart( tsubpart36, 300, 490, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nohiddenstats") > 0)
        {
          this.dostats = 1;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "HIDDEN STATS", vicFont2, 350, 538, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart37: SubPartClass =  new SteveRadioPartClass(0, this.dostats == 0, tBackbitmap: ( this.OwnBitmap), bbx: 300, bby: 530);
          this.o14 = this.AddSubPart( tsubpart37, 300, 530, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "noaiallied") > 0)
        {
          this.doallied = 0;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "AI ALLIED", vicFont2, 350, 578, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart38: SubPartClass =  new SteveRadioPartClass(0, this.doallied == 1, tBackbitmap: ( this.OwnBitmap), bbx: 300, bby: 570);
          this.o15 = this.AddSubPart( tsubpart38, 300, 570, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nouseresources") > 0)
        {
          this.Srawuse = 0;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "USE RESOURCES", vicFont2, 350, 618, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart39: SubPartClass =  new SteveRadioPartClass(0, this.Srawuse == 1, tBackbitmap: ( this.OwnBitmap), bbx: 300, bby: 610);
          this.z1 = this.AddSubPart( tsubpart39, 300, 610, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "noroads") > 0)
        {
          this.opt9v = 0;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "NO ROADS", vicFont2, 550, 458, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart40: SubPartClass =  new SteveRadioPartClass(0, this.opt9v == 0, tBackbitmap: ( this.OwnBitmap), bbx: 500, bby: 450);
          this.o11 = this.AddSubPart( tsubpart40, 500, 450, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nowildlands") > 0)
        {
          this.Spop = 0;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "WILD LAND", vicFont2, 550, 498, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart41: SubPartClass =  new SteveRadioPartClass(0, this.Spop == 1, tBackbitmap: ( this.OwnBitmap), bbx: 500, bby: 490);
          this.o16 = this.AddSubPart( tsubpart41, 500, 490, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nodepletedlands") > 0)
        {
          this.Sraw = 0;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "DEPLETED LAND", vicFont2, 550, 538, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart42: SubPartClass =  new SteveRadioPartClass(0, this.Sraw == 1, tBackbitmap: ( this.OwnBitmap), bbx: 500, bby: 530);
          this.o17 = this.AddSubPart( tsubpart42, 500, 530, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nodesertedlands") > 0)
        {
          this.Spop = 0;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "DESERTED LANDS", vicFont2, 550, 578, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart43: SubPartClass =  new SteveRadioPartClass(0, this.Spop == 2, tBackbitmap: ( this.OwnBitmap), bbx: 500, bby: 570);
          this.o18 = this.AddSubPart( tsubpart43, 500, 570, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nochangemaster") <= 0)
        {
          tsubpart4 =  new SteveRadioPartClass(0, false, tBackbitmap: ( this.OwnBitmap), bbx: 500, bby: 610);
          this.z2 = this.AddSubPart( tsubpart4, 500, 610, 35, 35, 1);
          DrawMod.DrawTextVic2( Expression, Strings.Left(this.domasterfile, Math.Min(Strings.Len(this.domasterfile), 14)), vicFont2, 550, 618, this.game.VicColor2, this.game.VicColor2Shade);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "noweather") > 0)
        {
          this.Sclimate = 0;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "CLIMATE", this.game.VicFont1, 750, 417, this.game.VicColor2, this.game.VicColor2Shade);
          tsubpart4 =  new SteveRadioPartClass(0, this.Sclimate == 0, tBackbitmap: ( this.OwnBitmap), bbx: 750, bby: 450);
          this.w7 = this.AddSubPart( tsubpart4, 750, 450, 35, 35, 1);
          tsubpart4 =  new SteveRadioPartClass(0, this.Sclimate == 1, tBackbitmap: ( this.OwnBitmap), bbx: 750, bby: 490);
          this.w8 = this.AddSubPart( tsubpart4, 750, 490, 35, 35, 1);
          tsubpart4 =  new SteveRadioPartClass(0, this.Sclimate == 2, tBackbitmap: ( this.OwnBitmap), bbx: 750, bby: 530);
          this.w9 = this.AddSubPart( tsubpart4, 750, 530, 35, 35, 1);
          tsubpart4 =  new SteveRadioPartClass(0, this.Sclimate == 3, tBackbitmap: ( this.OwnBitmap), bbx: 750, bby: 570);
          this.w10 = this.AddSubPart( tsubpart4, 750, 570, 35, 35, 1);
          tsubpart4 =  new SteveRadioPartClass(0, this.Sclimate == 4, tBackbitmap: ( this.OwnBitmap), bbx: 750, bby: 610);
          this.w21 = this.AddSubPart( tsubpart4, 750, 610, 35, 35, 1);
          DrawMod.DrawTextVic2( Expression, "NO CLIMATE", vicFont2, 800, 460, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "FULL RANGE", vicFont2, 800, 500, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "ARCTIC-TEMPERATE", vicFont2, 800, 540, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "SUBTROPIC-TROPIC", vicFont2, 800, 580, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "TEMPERATE", vicFont2, 800, 620, this.game.VicColor2, this.game.VicColor2Shade);
        }
      }
      else if (this.tabmode == 1)
      {
        vicFont2: Font = this.game.VicFont2;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nocontinentalsize") > 0)
        {
          this.optr1 = 0;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "CONTINENTAL SIZE", this.game.VicFont1, 100, 97, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart44: SubPartClass =  new SteveRadioPartClass(0, this.optr1 == -2, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 130);
          this.r1 = this.AddSubPart( tsubpart44, 100, 130, 35, 35, 1);
          let mut tsubpart45: SubPartClass =  new SteveRadioPartClass(0, this.optr1 == -1, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 170);
          this.r2 = this.AddSubPart( tsubpart45, 100, 170, 35, 35, 1);
          let mut tsubpart46: SubPartClass =  new SteveRadioPartClass(0, this.optr1 == 0, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 210);
          this.r3 = this.AddSubPart( tsubpart46, 100, 210, 35, 35, 1);
          let mut tsubpart47: SubPartClass =  new SteveRadioPartClass(0, this.optr1 == 1, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 250);
          this.r4 = this.AddSubPart( tsubpart47, 100, 250, 35, 35, 1);
          let mut tsubpart48: SubPartClass =  new SteveRadioPartClass(0, this.optr1 == 2, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 290);
          this.r5 = this.AddSubPart( tsubpart48, 100, 290, 35, 35, 1);
          DrawMod.DrawTextVic2( Expression, "TINY", vicFont2, 150, 138, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "SMALL", vicFont2, 150, 178, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "NORMAL", vicFont2, 150, 218, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "BIG", vicFont2, 150, 258, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "PANGEAIC", vicFont2, 150, 298, this.game.VicColor2, this.game.VicColor2Shade);
        }
        let mut num: i32 = 50;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nohumidity") > 0)
        {
          this.optr2 = 0;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "HUMIDITY", this.game.VicFont1, 370 + num, 97, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart49: SubPartClass =  new SteveRadioPartClass(0, this.optr2 == -2, tBackbitmap: ( this.OwnBitmap), bbx: (370 + num), bby: 130);
          this.r6 = this.AddSubPart( tsubpart49, 370 + num, 130, 35, 35, 1);
          let mut tsubpart50: SubPartClass =  new SteveRadioPartClass(0, this.optr2 == -1, tBackbitmap: ( this.OwnBitmap), bbx: (370 + num), bby: 170);
          this.r7 = this.AddSubPart( tsubpart50, 370 + num, 170, 35, 35, 1);
          let mut tsubpart51: SubPartClass =  new SteveRadioPartClass(0, this.optr2 == 0, tBackbitmap: ( this.OwnBitmap), bbx: (370 + num), bby: 210);
          this.r8 = this.AddSubPart( tsubpart51, 370 + num, 210, 35, 35, 1);
          let mut tsubpart52: SubPartClass =  new SteveRadioPartClass(0, this.optr2 == 1, tBackbitmap: ( this.OwnBitmap), bbx: (370 + num), bby: 250);
          this.r9 = this.AddSubPart( tsubpart52, 370 + num, 250, 35, 35, 1);
          let mut tsubpart53: SubPartClass =  new SteveRadioPartClass(0, this.optr2 == 2, tBackbitmap: ( this.OwnBitmap), bbx: (370 + num), bby: 290);
          this.r10 = this.AddSubPart( tsubpart53, 370 + num, 290, 35, 35, 1);
          DrawMod.DrawTextVic2( Expression, "ARID WORLD", vicFont2, 420 + num, 138, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "DRY WORLD", vicFont2, 420 + num, 178, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "NORMAL", vicFont2, 420 + num, 218, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "WET WORLD", vicFont2, 420 + num, 258, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "RAIN WORLD", vicFont2, 420 + num, 298, this.game.VicColor2, this.game.VicColor2Shade);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nogeologicalage") > 0)
        {
          this.optr3 = 0;
        }
        else
        {
          DrawMod.DrawTextVic2( Expression, "GEOLOGICAL AGE", this.game.VicFont1, 750, 97, this.game.VicColor2, this.game.VicColor2Shade);
          let mut tsubpart54: SubPartClass =  new SteveRadioPartClass(0, this.optr3 == -2, tBackbitmap: ( this.OwnBitmap), bbx: 750, bby: 130);
          this.r11 = this.AddSubPart( tsubpart54, 750, 130, 35, 35, 1);
          let mut tsubpart55: SubPartClass =  new SteveRadioPartClass(0, this.optr3 == -1, tBackbitmap: ( this.OwnBitmap), bbx: 750, bby: 170);
          this.r12 = this.AddSubPart( tsubpart55, 750, 170, 35, 35, 1);
          let mut tsubpart56: SubPartClass =  new SteveRadioPartClass(0, this.optr3 == 0, tBackbitmap: ( this.OwnBitmap), bbx: 750, bby: 210);
          this.r13 = this.AddSubPart( tsubpart56, 750, 210, 35, 35, 1);
          let mut tsubpart57: SubPartClass =  new SteveRadioPartClass(0, this.optr3 == 1, tBackbitmap: ( this.OwnBitmap), bbx: 750, bby: 250);
          this.r14 = this.AddSubPart( tsubpart57, 750, 250, 35, 35, 1);
          let mut tsubpart58: SubPartClass =  new SteveRadioPartClass(0, this.optr3 == 2, tBackbitmap: ( this.OwnBitmap), bbx: 750, bby: 290);
          this.r15 = this.AddSubPart( tsubpart58, 750, 290, 35, 35, 1);
          DrawMod.DrawTextVic2( Expression, "VERY YOUNG", vicFont2, 800, 138, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "YOUNG", vicFont2, 800, 178, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "NORMAL", vicFont2, 800, 218, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "OLD", vicFont2, 800, 258, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2( Expression, "ANCIENT", vicFont2, 800, 298, this.game.VicColor2, this.game.VicColor2Shade);
        }
        DrawMod.DrawTextVic2( Expression, "EXTRA OPTIONS", this.game.VicFont1, 100, 417, this.game.VicColor2, this.game.VicColor2Shade);
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nolimitedroads") > 0)
        {
          this.optr4 = 0;
        }
        else
        {
          let mut tsubpart59: SubPartClass =  new SteveRadioPartClass(0, this.optr4 == 1, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 450);
          this.r16 = this.AddSubPart( tsubpart59, 100, 450, 35, 35, 1);
          DrawMod.DrawTextVic2( Expression, "LIMITED INITIAL ROADS", vicFont2, 150, 458, this.game.VicColor2, this.game.VicColor2Shade);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nonaturalcoastlines") > 0)
        {
          this.optr5 = 0;
        }
        else
        {
          let mut tsubpart60: SubPartClass =  new SteveRadioPartClass(0, this.optr5 == 1, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 490);
          this.r17 = this.AddSubPart( tsubpart60, 100, 490, 35, 35, 1);
          DrawMod.DrawTextVic2( Expression, "NATURAL COASTLINES", vicFont2, 150, 498, this.game.VicColor2, this.game.VicColor2Shade);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nonofarm") > 0)
        {
          this.optr6 = 0;
        }
        else
        {
          let mut tsubpart61: SubPartClass =  new SteveRadioPartClass(0, this.optr6 == 1, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 530);
          this.r26 = this.AddSubPart( tsubpart61, 100, 530, 35, 35, 1);
          DrawMod.DrawTextVic2( Expression, "NO FARMLANDS", vicFont2, 150, 538, this.game.VicColor2, this.game.VicColor2Shade);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nonosuburb") > 0)
        {
          this.optr7 = 0;
        }
        else
        {
          let mut tsubpart62: SubPartClass =  new SteveRadioPartClass(0, this.optr7 == 1, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 570);
          this.r27 = this.AddSubPart( tsubpart62, 100, 570, 35, 35, 1);
          DrawMod.DrawTextVic2( Expression, "NO SUBURBS", vicFont2, 150, 578, this.game.VicColor2, this.game.VicColor2Shade);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nohigherprodcost") > 0)
        {
          this.optr8 = 0;
        }
        else
        {
          let mut tsubpart63: SubPartClass =  new SteveRadioPartClass(0, this.optr8 == 1, tBackbitmap: ( this.OwnBitmap), bbx: 100, bby: 610);
          this.r28 = this.AddSubPart( tsubpart63, 100, 610, 35, 35, 1);
          DrawMod.DrawTextVic2( Expression, "HIGHER PROD. COST", vicFont2, 150, 618, this.game.VicColor2, this.game.VicColor2Shade);
        }
      }
      tsubpart4 =  new TextButtonPartClass("Make", 100, tBackbitmap: ( this.OwnBitmap), bbx: 880, bby: 700);
      this.BStartGameID = this.AddSubPart( tsubpart4, 880, 700, 100, 35, 1);
      tsubpart4 =  new SteveButtonPartClass(this.game.BACKBUTTON, tBackbitmap: ( this.OwnBitmap), bbx: 30, bby: 700);
      this.cancelID = this.AddSubPart( tsubpart4, 30, 700, 35, 35, 1);
      if (Information.IsNothing( Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    pub fn DoStuff()
    {
      if (this.game.EditObj.ShortRandomScreen)
      {
        this.DoStuffShort();
      }
      else
      {
        if (this.TempText > 0)
          this.RemoveSubPart(this.TempText);
        if (this.TempText2 > 0)
          this.RemoveSubPart(this.TempText2);
        if (this.BStartGameID > 0)
          this.RemoveSubPart(this.BStartGameID);
        if (this.BLoadGameID > 0)
          this.RemoveSubPart(this.BLoadGameID);
        if (this.BEditorID > 0)
          this.RemoveSubPart(this.BEditorID);
        if (this.RegimeListId > 0)
          this.RemoveSubPart(this.RegimeListId);
        if (this.allied > 0)
          this.RemoveSubPart(this.allied);
        if (this.alliedtext > 0)
          this.RemoveSubPart(this.alliedtext);
        if (this.optimize > 0)
          this.RemoveSubPart(this.optimize);
        if (this.optimizetext > 0)
          this.RemoveSubPart(this.optimizetext);
        if (this.opt1 > 0)
          this.RemoveSubPart(this.opt1);
        if (this.txt1 > 0)
          this.RemoveSubPart(this.txt1);
        if (this.opt2 > 0)
          this.RemoveSubPart(this.opt2);
        if (this.txt2 > 0)
          this.RemoveSubPart(this.txt2);
        if (this.opt3 > 0)
          this.RemoveSubPart(this.opt3);
        if (this.txt3 > 0)
          this.RemoveSubPart(this.txt3);
        if (this.opt4 > 0)
          this.RemoveSubPart(this.opt4);
        if (this.opt5 > 0)
          this.RemoveSubPart(this.opt5);
        if (this.opt6 > 0)
          this.RemoveSubPart(this.opt6);
        if (this.opt7 > 0)
          this.RemoveSubPart(this.opt7);
        if (this.opt8 > 0)
          this.RemoveSubPart(this.opt8);
        if (this.opt9 > 0)
          this.RemoveSubPart(this.opt9);
        if (this.opt10 > 0)
          this.RemoveSubPart(this.opt10);
        if (this.opt11 > 0)
          this.RemoveSubPart(this.opt11);
        if (this.opt12 > 0)
          this.RemoveSubPart(this.opt12);
        if (this.cancelID > 0)
          this.RemoveSubPart(this.cancelID);
        if (this.shrowd > 0)
          this.RemoveSubPart(this.shrowd);
        if (this.shrowdtext > 0)
          this.RemoveSubPart(this.shrowdtext);
        if (this.mirror > 0)
          this.RemoveSubPart(this.mirror);
        if (this.mirrortext > 0)
          this.RemoveSubPart(this.mirrortext);
        if (this.blockcenter > 0)
          this.RemoveSubPart(this.blockcenter);
        if (this.blockcentertext > 0)
          this.RemoveSubPart(this.blockcentertext);
        if (this.firsttech > 0)
          this.RemoveSubPart(this.firsttech);
        if (this.firsttechtext > 0)
          this.RemoveSubPart(this.firsttechtext);
        if (this.masterfile > 0)
          this.RemoveSubPart(this.masterfile);
        if (this.masterfiletext > 0)
          this.RemoveSubPart(this.masterfiletext);
        if (this.maploop > 0)
          this.RemoveSubPart(this.maploop);
        if (this.maplooptext > 0)
          this.RemoveSubPart(this.maplooptext);
        if (this.oldkingdom > 0)
          this.RemoveSubPart(this.oldkingdom);
        if (this.oldkingdomtext > 0)
          this.RemoveSubPart(this.oldkingdomtext);
        let mut tsubpart: SubPartClass =  TextPartClass::new("Make Random Scenario", Font::new("Arial Black", 19f, FontStyle.Regular, GraphicsUnit.Pixel), 450, 27, false, tBlackBack: true);
        this.TempText = this.AddSubPart( tsubpart, 200, 19, 150, 16, 0);
        tsubpart =  new NumberSliderSubPartClass3(this.game, "Width= ", " hex ", 400, 10, 100, this.opt1v, tbackbitmap: ( this.OwnBitmap), bbx: 200, bby: 100);
        this.opt1 = this.AddSubPart( tsubpart, 200, 100, 400, 22, 0);
        tsubpart =  new NumberSliderSubPartClass3(this.game, "Towns= ", "x ", 400, 0, 100, this.opt8v, tbackbitmap: ( this.OwnBitmap), bbx: 200, bby: 390);
        this.opt8 = this.AddSubPart( tsubpart, 200, 390, 400, 22, 0);
        tsubpart =  new NumberSliderSubPartClass3(this.game, "Height= ", " hex ", 400, 10, 100, this.opt2v, tbackbitmap: ( this.OwnBitmap), bbx: 200, bby: 140);
        this.opt2 = this.AddSubPart( tsubpart, 200, 140, 400, 22, 0);
        tsubpart =  new NumberSliderSubPartClass3(this.game, "Roads= level ", "", 400, 0, 5, this.opt9v, tbackbitmap: ( this.OwnBitmap), bbx: 200, bby: 430);
        this.opt9 = this.AddSubPart( tsubpart, 200, 430, 400, 22, 0);
        tsubpart =  new NumberSliderSubPartClass3(this.game, "Players= ", " regimes ", 400, 2, 10, this.opt3v, tbackbitmap: ( this.OwnBitmap), bbx: 200, bby: 180);
        this.opt3 = this.AddSubPart( tsubpart, 200, 180, 400, 22, 0);
        tsubpart =  new NumberSliderSubPartClass3(this.game, "City Size= ", "", 400, 1, 4, this.opt10v, tbackbitmap: ( this.OwnBitmap), bbx: 200, bby: 470);
        this.opt10 = this.AddSubPart( tsubpart, 200, 470, 400, 22, 0);
        tsubpart =  new NumberSliderSubPartClass3(this.game, "Land = ", "%", 400, 10, 100, this.opt4v, tbackbitmap: ( this.OwnBitmap), bbx: 200, bby: 220);
        this.opt4 = this.AddSubPart( tsubpart, 200, 220, 400, 22, 0);
        tsubpart =  new NumberSliderSubPartClass3(this.game, "Research mod= ", "% ", 400, 20, 500, this.opt11v, tbackbitmap: ( this.OwnBitmap), bbx: 200, bby: 510);
        this.opt11 = this.AddSubPart( tsubpart, 200, 510, 400, 22, 0);
        tsubpart =  new NumberSliderSubPartClass3(this.game, "Rivers = ", "% ", 400, 0, 100, this.opt5v, tbackbitmap: ( this.OwnBitmap), bbx: 200, bby: 260);
        this.opt5 = this.AddSubPart( tsubpart, 200, 260, 400, 22, 0);
        tsubpart =  new NumberSliderSubPartClass3(this.game, "Swamp= level", "", 400, 0, 100, this.opt12v, tbackbitmap: ( this.OwnBitmap), bbx: 200, bby: 550);
        this.opt12 = this.AddSubPart( tsubpart, 200, 550, 400, 22, 0);
        tsubpart =  new NumberSliderSubPartClass3(this.game, "Forests = level ", "", 400, 0, 100, this.opt6v, tbackbitmap: ( this.OwnBitmap), bbx: 200, bby: 300);
        this.opt6 = this.AddSubPart( tsubpart, 200, 300, 400, 22, 0);
        tsubpart =  new NumberSliderSubPartClass3(this.game, "Mountains = level ", "", 400, 0, 100, this.opt7v, tbackbitmap: ( this.OwnBitmap), bbx: 200, bby: 340);
        this.opt7 = this.AddSubPart( tsubpart, 200, 340, 400, 22, 0);
        if (this.dooptimize == 0)
        {
          tsubpart =  new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: ( this.OwnBitmap), bbx: 700, bby: 260);
          this.optimize = this.AddSubPart( tsubpart, 700, 220, 35, 35, 1);
        }
        else
        {
          tsubpart =  new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: ( this.OwnBitmap), bbx: 700, bby: 260);
          this.optimize = this.AddSubPart( tsubpart, 700, 220, 35, 35, 1);
        }
        tsubpart =  TextPartClass::new("Optimize for AI", Font::new("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
        this.optimizetext = this.AddSubPart( tsubpart, 750, 229, 150, 16, 0);
        if (this.dooldkingdom == 0)
        {
          tsubpart =  new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: ( this.OwnBitmap), bbx: 700, bby: 260);
          this.oldkingdom = this.AddSubPart( tsubpart, 700, 260, 35, 35, 1);
        }
        else
        {
          tsubpart =  new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: ( this.OwnBitmap), bbx: 700, bby: 260);
          this.oldkingdom = this.AddSubPart( tsubpart, 700, 260, 35, 35, 1);
        }
        tsubpart =  TextPartClass::new("People's Republic", Font::new("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
        this.oldkingdomtext = this.AddSubPart( tsubpart, 750, 269, 150, 16, 0);
        if (this.domaploop == 0)
        {
          tsubpart =  new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: ( this.OwnBitmap), bbx: 700, bby: 300);
          this.maploop = this.AddSubPart( tsubpart, 700, 300, 35, 35, 1);
        }
        else
        {
          tsubpart =  new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: ( this.OwnBitmap), bbx: 700, bby: 300);
          this.maploop = this.AddSubPart( tsubpart, 700, 300, 35, 35, 1);
        }
        tsubpart =  TextPartClass::new("Map Loop", Font::new("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
        this.maplooptext = this.AddSubPart( tsubpart, 750, 309, 150, 16, 0);
        if (this.doshrowd == 0)
        {
          tsubpart =  new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: ( this.OwnBitmap), bbx: 700, bby: 340);
          this.shrowd = this.AddSubPart( tsubpart, 700, 340, 35, 35, 1);
        }
        else
        {
          tsubpart =  new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: ( this.OwnBitmap), bbx: 700, bby: 340);
          this.shrowd = this.AddSubPart( tsubpart, 700, 340, 35, 35, 1);
        }
        tsubpart =  TextPartClass::new("Shrouded Map", Font::new("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
        this.shrowdtext = this.AddSubPart( tsubpart, 750, 349, 150, 16, 0);
        if (this.opt3v == 2)
        {
          if (this.domirror == 0)
          {
            tsubpart =  new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: ( this.OwnBitmap), bbx: 700, bby: 380);
            this.mirror = this.AddSubPart( tsubpart, 700, 380, 35, 35, 1);
          }
          else
          {
            tsubpart =  new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: ( this.OwnBitmap), bbx: 700, bby: 380);
            this.mirror = this.AddSubPart( tsubpart, 700, 380, 35, 35, 1);
          }
          tsubpart =  TextPartClass::new("Mirror Map", Font::new("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
          this.mirrortext = this.AddSubPart( tsubpart, 750, 389, 150, 16, 0);
        }
        else
          this.domirror = 0;
        if (this.doblockcenter == 0)
        {
          tsubpart =  new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: ( this.OwnBitmap), bbx: 700, bby: 420);
          this.blockcenter = this.AddSubPart( tsubpart, 700, 420, 35, 35, 1);
        }
        else
        {
          tsubpart =  new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: ( this.OwnBitmap), bbx: 700, bby: 420);
          this.blockcenter = this.AddSubPart( tsubpart, 700, 420, 35, 35, 1);
        }
        tsubpart =  TextPartClass::new("Block Center", Font::new("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
        this.blockcentertext = this.AddSubPart( tsubpart, 750, 429, 150, 16, 0);
        if (this.dofirsttech == 0)
        {
          tsubpart =  new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: ( this.OwnBitmap), bbx: 700, bby: 460);
          this.firsttech = this.AddSubPart( tsubpart, 700, 460, 35, 35, 1);
        }
        else
        {
          tsubpart =  new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: ( this.OwnBitmap), bbx: 700, bby: 460);
          this.firsttech = this.AddSubPart( tsubpart, 700, 460, 35, 35, 1);
        }
        tsubpart =  TextPartClass::new("Full 1st Level Tech", Font::new("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
        this.firsttechtext = this.AddSubPart( tsubpart, 750, 469, 150, 16, 0);
        if (this.doallied == 0)
        {
          tsubpart =  new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: ( this.OwnBitmap), bbx: 700, bby: 460);
          this.allied = this.AddSubPart( tsubpart, 700, 500, 35, 35, 1);
        }
        else
        {
          tsubpart =  new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: ( this.OwnBitmap), bbx: 700, bby: 460);
          this.allied = this.AddSubPart( tsubpart, 700, 500, 35, 35, 1);
        }
        tsubpart =  TextPartClass::new("Allied AIs", Font::new("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
        this.alliedtext = this.AddSubPart( tsubpart, 750, 509, 150, 16, 0);
        bitmap: Bitmap = (Bitmap) null;
        tsubpart =  new TextButtonPartClass("M", 35, tBackbitmap: ( bitmap));
        this.masterfile = this.AddSubPart( tsubpart, 700, 540, 35, 35, 1);
        tsubpart =  TextPartClass::new("MASTER: " + this.domasterfile, Font::new("Times New Roman", 11f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
        this.masterfiletext = this.AddSubPart( tsubpart, 750, 549, 150, 16, 0);
        tsubpart =  new TextButtonPartClass("Make", 100, tBackbitmap: ( this.OwnBitmap), bbx: 50, bby: 485);
        this.BStartGameID = this.AddSubPart( tsubpart, 460, 700, 100, 35, 1);
        tsubpart =  new SteveButtonPartClass(this.game.BACKBUTTON, tBackbitmap: ( this.OwnBitmap), bbx: 30, bby: 700);
        this.cancelID = this.AddSubPart( tsubpart, 30, 700, 35, 35, 1);
      }
    }

    pub HandleMouseClick: WindowReturnClass(x: i32, y: i32, b: i32)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 = this.SubPartCounter;
        for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            let mut num1: i32 = this.SubPartID[index];
            if (num1 == this.cancelID)
            {
              windowReturnClass.AddCommand(1, 49);
              windowReturnClass.AddCommand(2, 55);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.tab1)
            {
              this.tabmode = 0;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.tab2)
            {
              this.tabmode = 1;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BLadderID)
            {
              this.game.FormRef.Cursor = Cursors.WaitCursor;
              this.opt1v = 17;
              this.opt8v = 8;
              this.opt2v = 13;
              this.opt3v = 2;
              this.opt10v = 1;
              this.opt4v = 90;
              this.opt11v = 100;
              this.opt5v = 10;
              this.opt12v = 25;
              this.opt6v = 40;
              this.opt7v = 40;
              this.dooldkingdom = 0;
              this.domaploop = 0;
              this.doshrowd = 0;
              this.domirror = 1;
              this.doblockcenter = 1;
              this.doallied = 0;
              this.domasterfile = "OFFICIAL LADDER/Ladder.ptmaster";
              this.MakeRandomMap();
              let mut num2: i32 =  Interaction.MsgBox( "A random ladder map is succesfully made!", Title: ( "Shadow Empire : Planetary Conquest"));
              this.game.FormRef.Cursor = Cursors.Default;
              this.game.Data.EditPass = "Heinrici45";
              this.game.Data.Description = "";
              this.game.Data.Description += "This scenario is generated for competitive play. The winner is the player who has most points at the start of round 10. If both players have the same amount of points, a draw is declared.";
              this.game.Data.Description += "\r\n\r\nPlayers earn points by capturing victory polocations: i32 as well as destroying enemy troops. Each victory poheld: i32 is worth 100 points. Each enemy power podestroyed: i32 is worth 1 point.";
              this.game.Data.Description += "\r\n\r\nBoth players start with 5 producing towns, 1 HQ and a few border divisions.";
              this.game.Data.Description += "\r\n\r\nThe 2nd player has 50% extra production for the production arriving at the start of the second round to offset his disadvantage in being the second player to move.\r\n\r\nGood Luck!";
              this.game.Data.Name = "Random Ladder Scenario";
              this.game.Data.FOWOn = true;
              this.game.Data.PBEM = true;
              this.game.Data.PasswordsOn = true;
              this.game.Data.RegimeObj[0].ResPts = 0;
              this.game.Data.RegimeObj[1].ResPts = 0;
              this.FinalizeLadder();
              this.game.EditObj.ShownWelcome = true;
              windowReturnClass.AddCommand(3, 1);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BStartGameID)
            {
              if (this.game.EditObj.ShortRandomScreen)
              {
                if (!(this.opt11v == 100 | this.opt11v == 300))
                  this.opt11v = 100;
                if (this.Swater == 0)
                {
                  this.opt4v = 100;
                  this.opt5v = 30;
                  this.opt12v = 5;
                  this.opt6v =  Math.Round(30.0 +  VBMath.Rnd() * 40.0);
                }
                if (this.Swater == 1)
                {
                  this.opt4v = 80;
                  this.opt5v = 45;
                  this.opt12v = 10;
                  this.opt6v =  Math.Round(40.0 +  VBMath.Rnd() * 30.0);
                }
                if (this.Swater == 2)
                {
                  this.opt4v = 66;
                  this.opt5v = 52;
                  this.opt12v = 12;
                  this.opt6v =  Math.Round(45.0 +  VBMath.Rnd() * 20.0);
                }
                if (this.Swater == 3)
                {
                  this.opt4v = 50;
                  this.opt5v = 60;
                  this.opt12v = 15;
                  this.opt7v =  Math.Round(50.0 +  VBMath.Rnd() * 10.0);
                }
                if (this.Swater == 4)
                {
                  this.opt4v = 35;
                  this.opt5v = 70;
                  this.opt12v = 18;
                  this.opt7v =  Math.Round(55.0 +  VBMath.Rnd() * 10.0);
                }
                if (this.Swater == 5)
                {
                  this.opt4v = 20;
                  this.opt5v = 80;
                  this.opt12v = 20;
                  this.opt7v =  Math.Round(60.0 +  VBMath.Rnd() * 10.0);
                }
                if (this.Sworldsize == 0)
                {
                  this.opt1v = 40;
                  this.opt2v = 20;
                  this.opt8v = 7;
                  this.opt5v =  Math.Round( this.opt5v / 8.0);
                }
                if (this.Sworldsize == 1)
                {
                  this.opt1v = 60;
                  this.opt2v = 30;
                  this.opt8v = 14;
                  this.opt5v =  Math.Round( this.opt5v / 5.0);
                }
                if (this.Sworldsize == 2)
                {
                  this.opt1v = 70;
                  this.opt2v = 40;
                  this.opt8v = 30;
                  this.opt5v =  Math.Round( this.opt5v / 2.0);
                }
                if (this.Sworldsize == 3)
                {
                  this.opt1v = 90;
                  this.opt2v = 60;
                  this.opt8v = 50;
                  this.opt5v = this.opt5v;
                }
                if (this.Sworldsize == 4)
                {
                  this.opt1v = 130;
                  this.opt2v = 90;
                  this.opt8v = 110;
                  this.opt5v *= 3;
                }
                if (this.Sworldsize == 5)
                {
                  this.opt1v = 170;
                  this.opt2v = 120;
                  this.opt8v = 150;
                  this.opt5v *= 5;
                }
                if (this.Swater == 0)
                  this.opt8v =  Math.Round( this.opt8v * 1.3);
                if (this.Swater == 1)
                  this.opt8v =  Math.Round( this.opt8v * 1.2);
                if (this.Swater == 2)
                  this.opt8v *= 1;
                if (this.Swater == 3)
                  this.opt8v =  Math.Round( this.opt8v * 0.8);
                if (this.Swater == 4)
                  this.opt8v =  Math.Round( this.opt8v * 0.66);
                if (this.Swater == 5)
                  this.opt8v =  Math.Round( this.opt8v * 0.5);
                if (this.Splayer == 0)
                  this.opt3v = 2;
                if (this.Splayer == 1)
                  this.opt3v = 3;
                if (this.Splayer == 2)
                  this.opt3v = 4;
                if (this.Splayer == 3)
                  this.opt3v = 5;
                if (this.Splayer == 4)
                  this.opt3v = 6;
                if (this.Splayer == 5)
                  this.opt3v = 7;
                if (this.Splayer == 6)
                  this.opt3v = 8;
                if (this.Splayer == 7)
                  this.opt3v = 9;
                if (this.Splayer == 8)
                  this.opt3v = 10;
                if (this.Splayer == 9)
                  this.opt3v = 11;
                if (this.Splayer == 10)
                  this.opt3v = 12;
                if (this.Splayer == 11)
                  this.opt3v = 13;
                if (this.Splayer == 12)
                  this.opt3v = 14;
                if (this.Spop == 1)
                {
                  this.opt8v =  Math.Round( this.opt8v / 2.0);
                  this.opt6v =  Math.Round( this.opt6v * 1.5);
                  this.opt7v =  Math.Round( this.opt7v * 1.33);
                }
                if (this.Spop == 2)
                {
                  this.opt8v =  Math.Round( this.opt8v / 4.0);
                  this.opt6v =  Math.Round( this.opt6v * 1.5);
                  this.opt7v =  Math.Round( this.opt7v * 1.33);
                }
                if (this.domaploop == 0)
                  this.doblockcenter = 1;
                this.opt6v =  Math.Round(20.0 +  VBMath.Rnd() * 20.0);
                this.opt7v =  Math.Round(20.0 +  VBMath.Rnd() * 20.0);
                this.opt10v = 2;
                this.opt12v = 30;
                if (this.optr2 == -2)
                {
                  this.opt5v = 0;
                  this.opt12v = 0;
                  this.opt6v = 0;
                }
                if (this.optr2 == -1)
                {
                  this.opt5v =  Math.Round( this.opt5v / 3.0);
                  this.opt12v =  Math.Round( this.opt12v / 5.0);
                  this.opt6v =  Math.Round( this.opt6v / 4.0);
                }
                if (this.optr2 == 1)
                {
                  this.opt5v =  Math.Round( this.opt5v * 1.5);
                  this.opt12v *= 2;
                  this.opt6v += 10;
                  this.opt6v =  Math.Round( this.opt6v * 1.5);
                }
                if (this.optr2 == 2)
                {
                  this.opt5v =  Math.Round( this.opt5v * 2.2);
                  this.opt12v *= 3;
                  this.opt6v += 20;
                  this.opt6v =  Math.Round( this.opt6v * 2.2);
                }
                if (this.optr3 == -2)
                {
                  this.opt7v += 20;
                  this.opt7v =  Math.Round( this.opt7v * 3.2);
                }
                if (this.optr3 == -1)
                {
                  this.opt7v += 10;
                  this.opt7v =  Math.Round( this.opt7v * 1.8);
                }
                if (this.optr3 == 1)
                  this.opt7v =  Math.Round( this.opt7v / 1.8);
                if (this.optr3 == 2)
                  this.opt7v =  Math.Round( this.opt7v / 3.2);
                this.domasterfile = this.game.EditObj.RandomUseMaster;
                this.dooldkingdom = 0;
                this.dooptimize = 0;
              }
              this.game.FormRef.Cursor = Cursors.WaitCursor;
              this.MakeRandomMap();
              if ( this.game.Data.RuleVar[418] > 0.0)
              {
                this.game.FormRef.Cursor = Cursors.Default;
                this.game.EditObj.ShownWelcome = true;
                windowReturnClass.AddCommand(3, 1);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              this.game.FormRef.Cursor = Cursors.Default;
            }
            else
            {
              if (num1 == this.opt1)
              {
                this.opt1v = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
                this.game.EditObj.ran1 = this.opt1v;
                this.game.EditObj.ranmem = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt2)
              {
                this.opt2v = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
                this.game.EditObj.ran2 = this.opt2v;
                this.game.EditObj.ranmem = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt3)
              {
                this.opt3v = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
                if (this.opt3v != 2)
                  this.domirror = 0;
                this.game.EditObj.ran3 = this.opt3v;
                this.game.EditObj.ranmem = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt4)
              {
                this.opt4v = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
                this.game.EditObj.ran4 = this.opt4v;
                this.game.EditObj.ranmem = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt5)
              {
                this.opt5v = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
                this.game.EditObj.ran5 = this.opt5v;
                this.game.EditObj.ranmem = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt6)
              {
                this.opt6v = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
                this.game.EditObj.ran6 = this.opt6v;
                this.game.EditObj.ranmem = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt7)
              {
                this.opt7v = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
                this.game.EditObj.ran7 = this.opt7v;
                this.game.EditObj.ranmem = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt8)
              {
                this.opt8v = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
                this.game.EditObj.ran8 = this.opt8v;
                this.game.EditObj.ranmem = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt9)
              {
                this.opt9v = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
                this.game.EditObj.ran9 = this.opt9v;
                this.game.EditObj.ranmem = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt10)
              {
                this.opt10v = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
                this.game.EditObj.ran10 = this.opt10v;
                this.game.EditObj.ranmem = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt11)
              {
                this.opt11v = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
                this.game.EditObj.ran11 = this.opt11v;
                this.game.EditObj.ranmem = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt12)
              {
                this.opt12v = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
                this.game.EditObj.ran12 = this.opt12v;
                this.game.EditObj.ranmem = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.optimize)
              {
                if (this.dooptimize == 0)
                {
                  this.dooptimize = 1;
                  this.game.EditObj.ranoptimize = 1;
                  this.game.EditObj.ranmem = 1;
                }
                else
                {
                  this.dooptimize = 0;
                  this.game.EditObj.ranoptimize = 0;
                  this.game.EditObj.ranmem = 1;
                }
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.shrowd)
              {
                if (this.doshrowd == 0)
                {
                  this.doshrowd = 1;
                  this.game.EditObj.randoshrowd = 1;
                  this.game.EditObj.ranmem = 1;
                }
                else
                {
                  this.doshrowd = 0;
                  this.game.EditObj.randoshrowd = 0;
                  this.game.EditObj.ranmem = 1;
                }
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.allied)
              {
                if (this.doallied == 0)
                {
                  this.doallied = 1;
                  this.game.EditObj.randoallied = 1;
                  this.game.EditObj.ranmem = 1;
                }
                else
                {
                  this.doallied = 0;
                  this.game.EditObj.randoallied = 0;
                  this.game.EditObj.ranmem = 1;
                }
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.mirror)
              {
                if (this.domirror == 0)
                {
                  this.domirror = 1;
                  this.game.EditObj.randomirror = 1;
                  this.game.EditObj.ranmem = 1;
                }
                else
                {
                  this.domirror = 0;
                  this.game.EditObj.randomirror = 0;
                  this.game.EditObj.ranmem = 1;
                }
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.firsttech)
              {
                if (this.dofirsttech == 0)
                {
                  this.dofirsttech = 1;
                  this.game.EditObj.randofirsttech = 1;
                  this.game.EditObj.ranmem = 1;
                }
                else
                {
                  this.dofirsttech = 0;
                  this.game.EditObj.randofirsttech = 0;
                  this.game.EditObj.ranmem = 1;
                }
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.z1)
              {
                this.Srawuse = this.Srawuse != 0 ? 0 : 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r1)
              {
                this.optr1 = -2;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r2)
              {
                this.optr1 = -1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r3)
              {
                this.optr1 = 0;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r4)
              {
                this.optr1 = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r5)
              {
                this.optr1 = 2;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r6)
              {
                this.optr2 = -2;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r7)
              {
                this.optr2 = -1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r8)
              {
                this.optr2 = 0;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r9)
              {
                this.optr2 = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r10)
              {
                this.optr2 = 2;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r11)
              {
                this.optr3 = -2;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r12)
              {
                this.optr3 = -1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r13)
              {
                this.optr3 = 0;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r14)
              {
                this.optr3 = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r15)
              {
                this.optr3 = 2;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r26)
              {
                this.optr6 = this.optr6 != 0 ? 0 : 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r27)
              {
                this.optr7 = this.optr7 != 0 ? 0 : 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r28)
              {
                this.optr8 = this.optr8 != 0 ? 0 : 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o1)
              {
                this.Sworldsize = 0;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o2)
              {
                this.Sworldsize = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o3)
              {
                this.Sworldsize = 2;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o4)
              {
                this.Sworldsize = 3;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o5)
              {
                this.Sworldsize = 4;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o6)
              {
                this.Sworldsize = 5;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r16)
              {
                this.optr4 = this.optr4 != 0 ? 0 : 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.r17)
              {
                this.optr5 = this.optr5 != 0 ? 0 : 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o7)
              {
                this.domaploop = this.domaploop != 0 ? 0 : 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o8)
              {
                this.domirror = this.domirror != 0 ? 0 : 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o19)
              {
                this.opt11v = this.opt11v != 300 ? 300 : 100;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o9)
              {
                this.doshrowd = this.doshrowd != 0 ? 0 : 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o10)
              {
                this.dosinglestart = this.dosinglestart != 0 ? 0 : 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o12)
              {
                this.dofirsttech = this.dofirsttech != 0 ? 0 : 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o18)
              {
                this.Spop = !(this.Spop == 0 | this.Spop == 1) ? 0 : 2;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o16)
              {
                this.Spop = !(this.Spop == 0 | this.Spop == 2) ? 0 : 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o17)
              {
                this.Sraw = this.Sraw != 0 ? 0 : 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o13)
              {
                if (this.Scrate == 0)
                {
                  this.Scrate = 1;
                }
                else
                {
                  this.Scrate = 0;
                  this.dosinglestart = 1;
                }
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o14)
              {
                this.dostats = this.dostats != 0 ? 0 : 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o15)
              {
                this.doallied = this.doallied != 0 ? 0 : 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.o11)
              {
                this.opt9v = this.opt9v != 0 ? 0 : 4;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w1)
              {
                this.Splayer = 0;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w2)
              {
                this.Splayer = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w3)
              {
                this.Splayer = 2;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w4)
              {
                this.Splayer = 3;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w5)
              {
                this.Splayer = 4;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w6)
              {
                this.Splayer = 5;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w11)
              {
                this.Splayer = 6;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w12)
              {
                this.Splayer = 7;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w13)
              {
                this.Splayer = 8;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w14)
              {
                this.Splayer = 9;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w15)
              {
                this.Splayer = 10;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w16)
              {
                this.Splayer = 11;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w17)
              {
                this.Splayer = 12;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w7)
              {
                this.Sclimate = 0;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w8)
              {
                this.Sclimate = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w9)
              {
                this.Sclimate = 2;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w10)
              {
                this.Sclimate = 3;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.w21)
              {
                this.Sclimate = 4;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.h1)
              {
                this.Swater = 0;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.h2)
              {
                this.Swater = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.h3)
              {
                this.Swater = 2;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.h4)
              {
                this.Swater = 3;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.h5)
              {
                this.Swater = 4;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.h6)
              {
                this.Swater = 5;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.maploop)
              {
                if (this.domaploop == 0)
                {
                  this.domaploop = 1;
                  this.game.EditObj.randomaploop = 1;
                  this.game.EditObj.ranmem = 1;
                }
                else
                {
                  this.domaploop = 0;
                  this.game.EditObj.randomaploop = 0;
                  this.game.EditObj.ranmem = 1;
                }
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.oldkingdom)
              {
                if (this.dooldkingdom == 0)
                {
                  this.dooldkingdom = 1;
                  this.game.EditObj.ranoldkingdom = 1;
                  this.game.EditObj.ranmem = 1;
                }
                else
                {
                  this.dooldkingdom = 0;
                  this.game.EditObj.ranoldkingdom = 0;
                  this.game.EditObj.ranmem = 1;
                }
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.blockcenter)
              {
                if (this.doblockcenter == 0)
                {
                  this.doblockcenter = 1;
                  this.game.EditObj.randoblockcenter = 1;
                  this.game.EditObj.ranmem = 1;
                }
                else
                {
                  this.doblockcenter = 0;
                  this.game.EditObj.randoblockcenter = 0;
                  this.game.EditObj.ranmem = 1;
                }
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.z2 || num1 == this.masterfile)
              {
                str: String = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a masterfile to use...", this.game.AppPath + this.game.ModScenarioDir, true);
                if (File.Exists(this.game.AppPath + this.game.ModScenarioDir + str))
                {
                  this.domasterfile = str;
                  this.game.EditObj.ranmasterfile = this.domasterfile;
                  this.game.EditObj.RandomUseMaster = this.domasterfile;
                  this.game.EditObj.ranmem = 1;
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                let mut num3: i32 =  Interaction.MsgBox( "Aborted.", Title: ( "Shadow Empire : Planetary Conquest"));
              }
            }
            return windowReturnClass;
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    pub fn MakeRandomMap()
    {
      this.game.EditObj.ranmem = 1;
      this.game.EditObj.ranr1 = this.optr1;
      this.game.EditObj.ranr2 = this.optr2;
      this.game.EditObj.ranr3 = this.optr3;
      this.game.EditObj.ranr4 = this.optr4;
      this.game.EditObj.ranr5 = this.optr5;
      this.game.EditObj.ranr6 = this.optr6;
      this.game.EditObj.ranr7 = this.optr7;
      this.game.EditObj.ranr8 = this.optr8;
      this.game.EditObj.ran1 = this.opt1v;
      this.game.EditObj.ran2 = this.opt2v;
      this.game.EditObj.ran3 = this.opt3v;
      this.game.EditObj.ran4 = this.opt4v;
      this.game.EditObj.ran5 = this.opt5v;
      this.game.EditObj.ran6 = this.opt6v;
      this.game.EditObj.ran7 = this.opt7v;
      this.game.EditObj.ran8 = this.opt8v;
      this.game.EditObj.ran9 = this.opt9v;
      this.game.EditObj.ran10 = this.opt10v;
      this.game.EditObj.ran11 = this.opt11v;
      this.game.EditObj.ran12 = this.opt12v;
      this.game.EditObj.randomaploop = this.domaploop;
      this.game.EditObj.randoshrowd = this.doshrowd;
      this.game.EditObj.randomirror = this.domirror;
      this.game.EditObj.randoblockcenter = this.doblockcenter;
      this.game.EditObj.randofirsttech = this.dofirsttech;
      this.game.EditObj.ranmasterfile = this.domasterfile;
      this.game.EditObj.randoallied = this.doallied;
      this.game.EditObj.ranoldkingdom = this.dooldkingdom;
      this.game.EditObj.ranoptimize = this.dooptimize;
      this.game.EditObj.ransinglestart = this.dosinglestart;
      this.game.EditObj.ransworldsize = this.Sworldsize;
      this.game.EditObj.ransplayer = this.Splayer;
      this.game.EditObj.ranswater = this.Swater;
      this.game.EditObj.ransclimate = this.Sclimate;
      this.game.EditObj.ranscrate = this.Scrate;
      this.game.EditObj.ranstats = this.dostats;
      this.game.EditObj.ranpop = this.Spop;
      this.game.EditObj.ranraw = this.Sraw;
      if (this.domirror == 1)
      {
        if (this.opt1v % 2 == 0)
          this += 1.opt1v;
        if (this.opt2v % 2 == 0)
          this += 1.opt2v;
        if (this.opt8v % 2 > 0)
          this += 1.opt8v;
      }
      let mut opt1v: i32 = this.opt1v;
      let mut opt2v: i32 = this.opt2v;
      let mut opt3v: i32 = this.opt3v;
      let mut opt4v: i32 = this.opt4v;
      this.landcur = 0;
      let mut num1: i32 =  Math.Round(Conversion.Int( opt4v / 5.0 * ( this.opt7v / 100.0)));
      this.mountaincur = 0;
      this.game.SelectX = 0;
      this.game.SelectY = 0;
      this.rivercur = 0;
      let mut num2: i32 = this.opt5v;
      if (this.domirror == 1)
        num2 =  Math.Round(Conversion.Int( num2 / 2.0));
      this.game.Data = DataClass::new();
      this.game.Data.MapObj = new MapClass[1];
      if ((opt1v + 10) % 2 == 0 & this.domaploop == 1)
        opt1v += 1;
      this.game.Data.MapObj[0] = new MapClass(0, 0, opt1v, opt2v);
      if (this.domaploop == 1)
        this.game.Data.MapObj[0].MapLoop = true;
      this.game.Data.MasterfileReadPeople = true;
      this.game.HandyFunctionsObj.LoadMasterFile(this.game.AppPath + this.game.ModScenarioDir + "/" + this.domasterfile, LoadDescription: this.game.EditObj.ShortRandomScreen);
      this.game.Data.FOWOn = true;
      if ( this.game.Data.RuleVar[418] < 1.0)
      {
        let mut num3: i32 =  Interaction.MsgBox( "The selected masterfile cannot be used to make a random game.", Title: ( "Shadow Empire : Planetary Conquest"));
      }
      else
      {
        if (opt1v + opt2v <= 100)
          ;
        BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
        this.game.Data.LoadGraphics((Form1) null);
        if ( this.game.Data.RuleVar[560] > 0.0 & this.Scrate == 1)
          this.game.Data.GameSlot[ Math.Round( this.game.Data.RuleVar[560])] = 1;
        if (this.Scrate == 1)
          this.game.Data.RuleVar[496] = 0.0f;
        if (this.doshrowd == 1)
          this.game.Data.CreatedWithShrowd = true;
        else
          this.game.Data.CreatedWithShrowd = false;
        this.WATER =  Math.Round( this.game.Data.RuleVar[401]);
        this.GRASS =  Math.Round( this.game.Data.RuleVar[402]);
        this.HIGHMOUNTAIN =  Math.Round( this.game.Data.RuleVar[403]);
        this.LOWMOUNTAIN =  Math.Round( this.game.Data.RuleVar[404]);
        this.LIGHTFOREST =  Math.Round( this.game.Data.RuleVar[405]);
        this.HEAVYFOREST =  Math.Round( this.game.Data.RuleVar[406]);
        this.SMALLRIVER =  Math.Round( this.game.Data.RuleVar[407]);
        this.BIGRIVER =  Math.Round( this.game.Data.RuleVar[408]);
        this.SWAMP =  Math.Round( this.game.Data.RuleVar[417]);
        this.URBAN =  this.game.Data.RuleVar[444] <= 0.0 ?  Math.Round( this.game.Data.RuleVar[402]) :  Math.Round( this.game.Data.RuleVar[444]);
        this.LIGHTURBAN = !( this.game.Data.RuleVar[445] > 0.0 & this.optr7 == 0) ?  Math.Round( this.game.Data.RuleVar[402]) :  Math.Round( this.game.Data.RuleVar[445]);
        this.FARMLAND = !( this.game.Data.RuleVar[446] > 0.0 & this.optr6 == 0) ?  Math.Round( this.game.Data.RuleVar[402]) :  Math.Round( this.game.Data.RuleVar[446]);
        if (this.optr2 == -2)
          this.FARMLAND = this.GRASS;
        let mut num4: i32 = opt1v;
        for (let mut index1: i32 = 0; index1 <= num4; index1 += 1)
        {
          let mut num5: i32 = opt2v;
          for (let mut index2: i32 = 0; index2 <= num5; index2 += 1)
          {
            if (this.opt4v == 100 | this.WATER == -1)
              this.game.Data.MapObj[0].HexObj[index1, index2] = new HexClass(this.GRASS, 0, 0);
            else
              this.game.Data.MapObj[0].HexObj[index1, index2] = new HexClass(this.WATER, 0, 0);
          }
        }
        if (this.optr8 > 0)
        {
          let mut itemTypeCounter: i32 = this.game.Data.ItemTypeCounter;
          for (let mut index3: i32 = 0; index3 <= itemTypeCounter; index3 += 1)
          {
            ItemTypeClass[] itemTypeObj = this.game.Data.ItemTypeObj;
            ItemTypeClass[] itemTypeClassArray = itemTypeObj;
            let mut index4: i32 = index3;
            let mut index5: i32 = index4;
            itemTypeClassArray[index5].ProdWeight = itemTypeObj[index4].ProdWeight * 3;
          }
        }
        if ( this.game.Data.RuleVar[481] > 0.0)
          this.MakeClimates();
        this.game.Data.AddRegime();
        this.game.Data.RemoveRegime(0);
        let mut num6: i32 = DrawMod.RandyNumber.Next(0, 9);
        let mut index6: i32 = opt3v - 1;
        let mut num7: i32 = index6;
        if (num7 < 6)
          num7 = 6;
        if (num7 > 6 & num7 < 13)
          num7 = 13;
        let mut num8: i32 = num7;
        for (let mut index7: i32 = 0; index7 <= num8; index7 += 1)
          this.Regid[index7] = index7;
        VBMath.Randomize();
        let mut num9: i32 = 0;
        do
        {
          let mut num10: i32 = num7;
          for (let mut index8: i32 = 0; index8 <= num10; index8 += 1)
          {
            let mut index9: i32 =  Math.Round( Conversion.Int(VBMath.Rnd() *  (num7 + 1)));
            let mut num11: i32 = this.Regid[index8];
            this.Regid[index8] = this.Regid[index9];
            this.Regid[index9] = num11;
          }
          num9 += 1;
        }
        while (num9 <= 10);
        if ( this.game.Data.RuleVar[496] > 0.0)
        {
          index6 += 1;
          let mut num12: i32 = num7 + 1;
          this.Regid[index6] = index6;
        }
        let mut num13: i32 = index6;
        for (let mut regnr: i32 = 0; regnr <= num13; regnr += 1)
        {
          if (regnr > 0 | this.game.Data.RegimeCounter < regnr)
            this.game.Data.AddRegime();
          this.game.Data.RegimeObj[regnr].Name = this.GetRandomRegimeName(regnr);
          this.game.Data.RegimeObj[regnr].People = 0;
          if ( this.game.Data.RuleVar[496] > 0.0 & index6 == regnr)
          {
            this.game.Data.RegimeObj[regnr].People =  Math.Round( this.game.Data.RuleVar[497]);
            this.game.Data.RegimeObj[regnr].DipBlock = true;
            this.game.Data.RegimeObj[regnr].Sleep = true;
          }
          if ( this.game.Data.RuleVar[457] == 0.0)
            this.game.Data.RegimeObj[regnr].ResPts = 20;
          else
            this.game.Data.RegimeObj[regnr].ResPts =  Math.Round( this.game.Data.RuleVar[457]);
          this.game.Data.RegimeObj[regnr].UnitName = "Division";
          this.game.Data.RegimeObj[regnr].HQName = "HQ";
          let mut num14: i32 = 1;
          let mut d: i32 = 0;
          while (num14 == 1)
          {
            num14 = 0;
            d += 1;
            this.game.Data.RegimeObj[regnr].Red = DrawMod.RandyNumber.Next(0, 235) + 20;
            this.game.Data.RegimeObj[regnr].Blue = DrawMod.RandyNumber.Next(0, 235) + 20;
            this.game.Data.RegimeObj[regnr].Green = DrawMod.RandyNumber.Next(0, 235) + 20;
            if ( (Math.Abs(this.game.Data.RegimeObj[regnr].Red - 0) + Math.Abs(this.game.Data.RegimeObj[regnr].Green - 0) + Math.Abs(this.game.Data.RegimeObj[regnr].Blue - 155)) <= 400.0 / Math.Sqrt(Math.Sqrt( d)) & d < 999)
              num14 = 1;
            let mut num15: i32 = regnr;
            for (let mut index10: i32 = 0; index10 <= num15; index10 += 1)
            {
              if (index10 != regnr)
              {
                if ( (Math.Abs(this.game.Data.RegimeObj[regnr].Red - this.game.Data.RegimeObj[index10].Red) + Math.Abs(this.game.Data.RegimeObj[regnr].Green - this.game.Data.RegimeObj[index10].Green) + Math.Abs(this.game.Data.RegimeObj[regnr].Blue - this.game.Data.RegimeObj[index10].Blue)) <= 400.0 / Math.Sqrt(Math.Sqrt( d)) & d < 999)
                  num14 = 1;
                if (Math.Abs(this.game.Data.RegimeObj[regnr].Red + this.game.Data.RegimeObj[regnr].Green + this.game.Data.RegimeObj[regnr].Blue) < 210 & d < 999)
                  num14 = 1;
              }
            }
          }
          this.game.Data.RegimeObj[regnr].Red2 =  byte.MaxValue;
          this.game.Data.RegimeObj[regnr].Green2 =  byte.MaxValue;
          this.game.Data.RegimeObj[regnr].Blue2 =  byte.MaxValue;
          this.game.Data.RegimeObj[regnr].TempCounter = (Bitmap) null;
          this.game.Data.RegimeObj[regnr].TempCounterHigh = (Bitmap) null;
          num6 += 1;
          if (Strings.Len(this.Flag1) == 0 & Strings.Len(this.Flag1b) == 0)
          {
            if (num6 == 1 | num6 == 13)
            {
              this.game.Data.RegimeObj[regnr].ReplaceHQSprite("default/national/Fantasy01Flag.png");
              this.game.Data.RegimeObj[regnr].ReplaceNationalSprite("default/national/Fantasy01ID.png");
            }
            if (num6 == 2 | num6 == 14)
            {
              this.game.Data.RegimeObj[regnr].ReplaceHQSprite("default/national/Fantasy02Flag.png");
              this.game.Data.RegimeObj[regnr].ReplaceNationalSprite("default/national/Fantasy02ID.png");
            }
            if (num6 == 3 | num6 == 15)
            {
              this.game.Data.RegimeObj[regnr].ReplaceHQSprite("default/national/Fantasy03Flag.png");
              this.game.Data.RegimeObj[regnr].ReplaceNationalSprite("default/national/Fantasy03ID.png");
            }
            if (num6 == 4 | num6 == 16)
            {
              this.game.Data.RegimeObj[regnr].ReplaceHQSprite("default/national/Fantasy04Flag.png");
              this.game.Data.RegimeObj[regnr].ReplaceNationalSprite("default/national/Fantasy04ID.png");
            }
            if (num6 == 5 | num6 == 17)
            {
              this.game.Data.RegimeObj[regnr].ReplaceHQSprite("default/national/Fantasy05Flag.png");
              this.game.Data.RegimeObj[regnr].ReplaceNationalSprite("default/national/Fantasy05ID.png");
            }
            if (num6 == 6 | num6 == 18)
            {
              this.game.Data.RegimeObj[regnr].ReplaceHQSprite("default/national/Fantasy06Flag.png");
              this.game.Data.RegimeObj[regnr].ReplaceNationalSprite("default/national/Fantasy06ID.png");
            }
            if (num6 == 7 | num6 == 19)
            {
              this.game.Data.RegimeObj[regnr].ReplaceHQSprite("default/national/BalkanFlag.png");
              this.game.Data.RegimeObj[regnr].ReplaceNationalSprite("default/national/BalkanID.png");
            }
            if (num6 == 8 | num6 == 20)
            {
              this.game.Data.RegimeObj[regnr].ReplaceHQSprite("default/national/CaliphateFlag.png");
              this.game.Data.RegimeObj[regnr].ReplaceNationalSprite("default/national/CaliphateID.png");
            }
            if (num6 == 9 | num6 == 21)
            {
              this.game.Data.RegimeObj[regnr].ReplaceHQSprite("default/national/EuroFlag.png");
              this.game.Data.RegimeObj[regnr].ReplaceNationalSprite("default/national/EuroID.png");
            }
            if (num6 == 10 | num6 == 22)
            {
              this.game.Data.RegimeObj[regnr].ReplaceHQSprite("default/national/starsandbarsFlag.png");
              this.game.Data.RegimeObj[regnr].ReplaceNationalSprite("default/national/starsandbarsID.png");
            }
            if (num6 == 11)
            {
              this.game.Data.RegimeObj[regnr].ReplaceHQSprite("default/national/secessionFlag.png");
              this.game.Data.RegimeObj[regnr].ReplaceNationalSprite("default/national/secessionID.png");
            }
            if (num6 == 12)
            {
              this.game.Data.RegimeObj[regnr].ReplaceHQSprite("default/national/FloridaFlag.png");
              this.game.Data.RegimeObj[regnr].ReplaceNationalSprite("default/national/FloridaID.png");
            }
          }
          else
          {
            this.game.Data.RegimeObj[regnr].ReplaceHQSprite(this.Flag1);
            this.game.Data.RegimeObj[regnr].ReplaceNationalSprite(this.Flag1b);
          }
          if ( this.game.Data.RuleVar[423] != 0.0)
          {
            num6 = this.Regid[regnr];
            if (num6 > 6)
              num6 -= 7;
            if ( this.game.Data.RuleVar[496] > 0.0 & regnr == this.opt3v)
            {
              this.game.Data.RegimeObj[regnr].ExtraGraphicUse =  Math.Round( this.game.Data.RuleVar[495]);
              if ( this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[regnr].OfficerPool =  Math.Round( this.game.Data.RuleVar[494]);
            }
            else if ( this.game.Data.RuleVar[491] != 0.0 & num6 == 6)
            {
              this.game.Data.RegimeObj[regnr].ExtraGraphicUse =  Math.Round( this.game.Data.RuleVar[491]);
              if ( this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[regnr].OfficerPool =  Math.Round( this.game.Data.RuleVar[490]);
            }
            else if ( this.game.Data.RuleVar[487] != 0.0 & num6 == 5)
            {
              this.game.Data.RegimeObj[regnr].ExtraGraphicUse =  Math.Round( this.game.Data.RuleVar[487]);
              if ( this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[regnr].OfficerPool =  Math.Round( this.game.Data.RuleVar[486]);
            }
            else if ( this.game.Data.RuleVar[483] != 0.0 & num6 == 4)
            {
              this.game.Data.RegimeObj[regnr].ExtraGraphicUse =  Math.Round( this.game.Data.RuleVar[483]);
              if ( this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[regnr].OfficerPool =  Math.Round( this.game.Data.RuleVar[482]);
            }
            else if ( this.game.Data.RuleVar[467] != 0.0 & num6 == 3)
            {
              this.game.Data.RegimeObj[regnr].ExtraGraphicUse =  Math.Round( this.game.Data.RuleVar[467]);
              if ( this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[regnr].OfficerPool =  Math.Round( this.game.Data.RuleVar[466]);
            }
            else if ( this.game.Data.RuleVar[433] != 0.0 & num6 == 2)
            {
              this.game.Data.RegimeObj[regnr].ExtraGraphicUse =  Math.Round( this.game.Data.RuleVar[433]);
              if ( this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[regnr].OfficerPool =  Math.Round( this.game.Data.RuleVar[432]);
            }
            else if ( this.game.Data.RuleVar[428] != 0.0 & num6 == 1)
            {
              this.game.Data.RegimeObj[regnr].ExtraGraphicUse =  Math.Round( this.game.Data.RuleVar[428]);
              if ( this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[regnr].OfficerPool =  Math.Round( this.game.Data.RuleVar[427]);
            }
            else
            {
              this.game.Data.RegimeObj[regnr].ExtraGraphicUse =  Math.Round( this.game.Data.RuleVar[423]);
              if ( this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[regnr].OfficerPool =  Math.Round( this.game.Data.RuleVar[422]);
            }
          }
          else if (DrawMod.RandyNumber.Next(0, 100) > 50)
            this.game.Data.RegimeObj[regnr].ExtraGraphicUse = -1;
          else if (this.game.Data.SFTypeObj[0].ExtraCounter > 1)
            this.game.Data.RegimeObj[regnr].ExtraGraphicUse = 2;
          else
            this.game.Data.RegimeObj[regnr].ExtraGraphicUse = -1;
          this.game.Data.RegimeObj[regnr].HQSpriteOverrule = true;
        }
        if (this.dooldkingdom > 0)
        {
          this.game.Data.AddPeople();
          this.game.Data.PeopleObj[this.game.Data.PeopleCounter].PeopleGroup = 99;
          this.game.Data.PeopleObj[this.game.Data.PeopleCounter].Name = "People's Republic";
          this.game.Data.PeopleObj[0].ProdMod[99] = 0.25f;
          this.game.Data.PeopleObj[0].BattleForMod[99] = 1f;
          this.game.Data.PeopleObj[0].BaseMorale[99] = 50;
          this.game.Data.PeopleObj[0].BattleVSMod[99] = 1f;
          this.game.Data.AddRegime();
          let mut index11: i32 = opt3v;
          this.game.Data.RegimeObj[index11].Name = "People's Republic";
          this.game.Data.RegimeObj[index11].People = this.game.Data.PeopleCounter;
          this.game.Data.RegimeObj[index11].ResPts = this.opt10v * this.opt8v + 20;
          this.game.Data.RegimeObj[index11].UnitName = "Division";
          this.game.Data.RegimeObj[index11].HQName = "HQ";
          this.game.Data.RegimeObj[index11].Red =  byte.MaxValue;
          this.game.Data.RegimeObj[index11].Blue = 120;
          this.game.Data.RegimeObj[index11].Green = 120;
          this.game.Data.RegimeObj[index11].Red2 =  byte.MaxValue;
          this.game.Data.RegimeObj[index11].Green2 =  byte.MaxValue;
          this.game.Data.RegimeObj[index11].Blue2 =  byte.MaxValue;
          this.game.Data.RegimeObj[index11].TempCounter = (Bitmap) null;
          this.game.Data.RegimeObj[index11].TempCounterHigh = (Bitmap) null;
          this.game.Data.RegimeObj[index11].ReplaceHQSprite("default/national/Flag Soviet.png");
          this.game.Data.RegimeObj[index11].ReplaceNationalSprite("default/national/National ID Soviet.png");
          if (this.game.Data.SFTypeObj[0].ExtraCounter > 0)
            this.game.Data.RegimeObj[index11].ExtraGraphicUse = 1;
          else
            this.game.Data.RegimeObj[index11].ExtraGraphicUse = -1;
          this.game.Data.RegimeObj[index11].HQSpriteOverrule = true;
        }
        while ( this.landcur <=  (opt1v * opt2v) * ( opt4v / 100.0))
        {
          let mut num16: i32 = 0;
          let mut num17: i32 = opt1v;
          for (let mut x: i32 = 0; x <= num17; x += 1)
          {
            let mut num18: i32 = opt2v;
            for (let mut y: i32 = 0; y <= num18; y += 1)
            {
              if (num16 == 0)
              {
                VBMath.Randomize();
                x =  Math.Round( Conversion.Int(VBMath.Rnd() *  (opt1v + 1)));
                y =  Math.Round( Conversion.Int(VBMath.Rnd() *  (opt2v + 1)));
              }
              let mut sizy: i32 =  VBMath.Rnd() <= 0.98 ? ( VBMath.Rnd() <= 0.9 ? ( VBMath.Rnd() <= 0.6 ?  Math.Round( Conversion.Int(VBMath.Rnd() *  opt4v)) :  Math.Round(Conversion.Int( VBMath.Rnd() *  VBMath.Rnd() * ( opt1v / 2.0 +  opt2v / 2.0)))) :  Math.Round( Conversion.Int(VBMath.Rnd() * VBMath.Rnd() *  (opt1v + opt2v)))) :  Math.Round(Conversion.Int( VBMath.Rnd() *  VBMath.Rnd() * ( (opt1v + opt2v) * ( opt4v / 10.0))));
              if (this.optr1 == -2)
                sizy =  Math.Round( sizy / 5.0);
              if (this.optr1 == -1)
                sizy =  Math.Round( sizy / 2.5);
              if (this.optr1 == 1)
                sizy =  Math.Round( sizy * 2.5);
              if (this.optr1 == 2)
                sizy *= 5;
              if (sizy < 1)
                sizy = 1;
              this.MakeLandBlob(x, y, sizy);
              num16 = 2;
              if (num16 == 2)
                break;
            }
            if (num16 == 2)
              break;
          }
        }
        if (this.HIGHMOUNTAIN > -1 & this.LOWMOUNTAIN > -1 && this.opt7v > 0)
        {
          let mut num19: i32 = 0;
          while ( this.mountaincur <=  (opt1v * opt2v) * ( num1 / 100.0) & num19 < 1000)
          {
            let mut num20: i32 = 0;
            let mut num21: i32 = opt1v;
            for (let mut x: i32 = 0; x <= num21; x += 1)
            {
              let mut num22: i32 = opt2v;
              for (let mut y: i32 = 0; y <= num22; y += 1)
              {
                if (num20 == 0)
                {
                  VBMath.Randomize();
                  x =  Math.Round( Conversion.Int(VBMath.Rnd() *  (opt1v + 1)));
                  y =  Math.Round( Conversion.Int(VBMath.Rnd() *  (opt2v + 1)));
                  num20 = 1;
                }
                let mut landscapeType: i32 = this.game.Data.MapObj[0].HexObj[x, y].LandscapeType;
                if (landscapeType == this.GRASS | landscapeType == this.LIGHTFOREST | landscapeType == this.HEAVYFOREST | landscapeType == this.SWAMP)
                {
                  x2: i32;
                  y2: i32;
                  if ( VBMath.Rnd() > 0.5)
                  {
                    x2 =  Math.Round( x + Conversion.Int( VBMath.Rnd() * ( (opt1v + opt2v) / 25.0)));
                    y2 =  Math.Round( ( y + Conversion.Int(VBMath.Rnd() * 2f)));
                  }
                  else
                  {
                    y2 =  Math.Round( y + Math.Max(2.0, Conversion.Int( VBMath.Rnd() * ( (opt1v + opt2v) / 60.0))));
                    x2 =  Math.Round( ( x + Math.Max(1f, Conversion.Int(VBMath.Rnd() * 1f))));
                  }
                  if (this.optr3 == -1)
                  {
                    if ( VBMath.Rnd() < 0.5)
                      x -= 3;
                    if ( VBMath.Rnd() < 0.5)
                      y -= 3;
                    if ( VBMath.Rnd() < 0.5)
                      x2 += 3;
                    if ( VBMath.Rnd() < 0.5)
                      y2 += 3;
                  }
                  if (this.optr3 == -2)
                  {
                    if ( VBMath.Rnd() < 0.5)
                      x -= 7;
                    if ( VBMath.Rnd() < 0.5)
                      y -= 7;
                    if ( VBMath.Rnd() < 0.5)
                      x2 += 7;
                    if ( VBMath.Rnd() < 0.5)
                      y2 += 7;
                  }
                  if (x < 0)
                    x = 0;
                  if (y < 0)
                    y = 0;
                  if (x2 > this.game.Data.MapObj[0].MapWidth)
                    x2 = this.game.Data.MapObj[0].MapWidth;
                  if (y2 > this.game.Data.MapObj[0].MapHeight)
                    y2 = this.game.Data.MapObj[0].MapHeight;
                  this.MakeMountainRange(x, y, x2, y2);
                  num20 = 2;
                  num19 += 1;
                }
                if (num20 == 2)
                  break;
              }
              if (num20 == 2)
                break;
            }
          }
        }
        Coordinate coordinate;
        if (this.SMALLRIVER > -1 & this.BIGRIVER > -1 && this.opt5v > 0)
        {
          this.rivstep = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 7];
          this.nextrivstep = new Coordinate[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 7];
          let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
          for (let mut index12: i32 = 0; index12 <= mapWidth; index12 += 1)
          {
            let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
            for (let mut index13: i32 = 0; index13 <= mapHeight; index13 += 1)
            {
              let mut index14: i32 = 0;
              do
              {
                this.nextrivstep[index12, index13, index14].x = -1;
                index14 += 1;
              }
              while (index14 <= 5);
            }
          }
          this.MakeHeightTable();
          let mut num23: i32 = 0;
          while ( this.rivercur <=  (num2 * (this.game.Data.MapObj[0].MapWidth * this.game.Data.MapObj[0].MapHeight)) / 1000.0 & num23 < 6 * this.game.Data.MapObj[0].MapWidth * this.game.Data.MapObj[0].MapHeight)
          {
            VBMath.Randomize();
            let mut index15: i32 =  Math.Round( Conversion.Int(VBMath.Rnd() *  (opt1v + 1)));
            let mut index16: i32 =  Math.Round( Conversion.Int(VBMath.Rnd() *  (opt2v + 1)));
            let mut z1: i32 =  Math.Round( Conversion.Int(VBMath.Rnd() * 6f));
            num23 += 1;
            if (this.domirror == 1 &  index15 >=  this.game.Data.MapObj[0].MapWidth / 2.0)
              index15 = -1;
            if (index15 > -1)
            {
              let mut tfacing: i32 = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(index15, index16, 0, tfacing);
                if (coordinate.onmap && this.game.HandyFunctionsObj.HasHexRiver(coordinate.x, coordinate.y, 0))
                  index15 = -1;
                tfacing += 1;
              }
              while (tfacing <= 6);
              if (index15 > -1 & index15 > 2 & index16 > 2 & index15 < this.game.Data.MapObj[0].MapWidth - 2 & index16 < this.game.Data.MapObj[0].MapHeight - 2 && !this.game.HandyFunctionsObj.HasHexRiver(index15, index16, 0) && this.game.Data.MapObj[0].HexObj[index15, index16].LandscapeType == this.LOWMOUNTAIN | this.game.Data.MapObj[0].HexObj[index15, index16].LandscapeType == this.HIGHMOUNTAIN)
              {
                let mut num24: i32 = 0;
                let mut index17: i32 = 0;
                do
                {
                  if (this.game.Data.MapObj[0].HexObj[index15, index16].RiverType[index17] > -1)
                    num24 += 1;
                  index17 += 1;
                }
                while (index17 <= 5);
                if (num24 == 0)
                {
                  this += 1.rivercur;
                  num23 = 0;
                  if ( this.game.Data.RuleVar[450] == 0.0)
                  {
                    this.DrawARiver(index15, index16, z1);
                  }
                  else
                  {
                    this.DrawARiver2(index15, index16, z1);
                    float num25 = 0.8f;
                    while ( VBMath.Rnd() <  num25)
                    {
                      num25 /= 2f;
                      index15 =  VBMath.Rnd() >= 0.5 ?  Math.Round( ( (index15 + 2) + VBMath.Rnd() * 2f)) :  Math.Round( ( (index15 - 2) + VBMath.Rnd() * 2f));
                      index16 =  VBMath.Rnd() >= 0.5 ?  Math.Round( ( (index16 + 2) + VBMath.Rnd() * 2f)) :  Math.Round( ( (index16 - 2) + VBMath.Rnd() * 2f));
                      let mut z2: i32 =  Math.Round( Conversion.Int(VBMath.Rnd() * 6f));
                      if (index15 > 1 & index16 > 1 & index15 < this.game.Data.MapObj[0].MapWidth & index16 < this.game.Data.MapObj[0].MapHeight)
                        this.DrawARiver2(index15, index16, z2);
                      else
                        num25 = 0.0f;
                    }
                  }
                  if (this.optr2 == 1 &  VBMath.Rnd() > 0.33)
                    this.MakeLakes(opt1v, opt2v);
                  else if (this.optr2 == 2)
                    this.MakeLakes(opt1v, opt2v);
                }
              }
            }
          }
        }
        if (this.domirror == 1)
          this.MirrorTheMap();
        if ( this.opt8v >  this.landcur / 10.0)
          this.opt8v =  Math.Round(Conversion.Int( this.landcur / 10.0));
        this.PlaceTowns(opt1v, opt2v);
        this.EnsureMountainPasses();
        this.DoSwamps();
        this.PlaceRegimes(opt1v, opt2v, opt3v);
        this.RESOURCESLOT = -1;
        if (this.Srawuse == 1 &&  this.game.Data.RuleVar[452] > 0.0)
          this.PlaceResources();
        if (this.dooptimize > 0)
          this.OptimizeForAI();
        this.PlaceRegimes2();
        if (this.Srawuse == 1 &&  this.game.Data.RuleVar[452] > 0.0)
          this.EqualizeResources();
        if (this.Srawuse == 0)
        {
          this.game.Data.RuleVar[452] = 0.0f;
          this.game.Data.RuleVar[822] = -1f;
          this.game.Data.RuleVar[823] = 0.0f;
          this.game.Data.RuleVar[824] = 0.0f;
          let mut index18: i32 = 0;
          do
          {
            this.game.Data.RegimeSlotShow[index18] = false;
            index18 += 1;
          }
          while (index18 <= 499);
          let mut itemTypeCounter: i32 = this.game.Data.ItemTypeCounter;
          for (let mut index19: i32 = 0; index19 <= itemTypeCounter; index19 += 1)
          {
            let mut index20: i32 = 0;
            do
            {
              this.game.Data.ItemTypeObj[index19].RegimeSlotsCost[index20] = -1;
              this.game.Data.ItemTypeObj[index19].RegimeSlotsCostQty[index20] = 0;
              index20 += 1;
            }
            while (index20 <= 4);
          }
          let mut sfTypeCounter: i32 = this.game.Data.SFTypeCounter;
          for (let mut index21: i32 = 0; index21 <= sfTypeCounter; index21 += 1)
          {
            this.game.Data.SFTypeObj[index21].FuelRegimeVar = -1;
            this.game.Data.SFTypeObj[index21].FuelForMove = 0;
            this.game.Data.SFTypeObj[index21].FuelForAttack = 0;
            this.game.Data.SFTypeObj[index21].OutOfFuelAttack = 0.0f;
            this.game.Data.SFTypeObj[index21].OutOfFuelDefense = 0.0f;
            this.game.Data.SFTypeObj[index21].OutOfFuelMove = 0.0f;
          }
        }
        this.game.Data.VPWin =  Math.Round(Conversion.Int( this.totvp * 0.8));
        if (this.dooldkingdom > 0)
          this.game.Data.VPWin = this.totvp;
        if (this.totvp == opt3v)
          this.game.Data.VPWin = opt3v;
        this.game.Data.MasterFile = this.domasterfile;
        this.game.Data.ASOn = true;
        if (this.doshrowd == 1)
        {
          this.game.Data.FOWOn = true;
          this.game.Data.ShrowdOn = true;
        }
        let mut regimeCounter1: i32 = this.game.Data.RegimeCounter;
        index22: i32;
        for (index22 = 0; index22 <= regimeCounter1; index22 += 1)
        {
          if (this.game.Data.NoAIAdvice)
            this.game.Data.RegimeObj[index22].AI = false;
          else
            this.game.Data.RegimeObj[index22].AI = true;
          let mut regimeCounter2: i32 = this.game.Data.RegimeCounter;
          for (let mut index23: i32 = 0; index23 <= regimeCounter2; index23 += 1)
          {
            if (index22 == index23)
              this.game.Data.RegimeObj[index22].RegimeRel[index23] = 1;
            else if ( this.game.Data.RuleVar[461] == 1.0)
              this.game.Data.RegimeObj[index22].RegimeRel[index23] = 1;
            else
              this.game.Data.RegimeObj[index22].RegimeRel[index23] = 0;
          }
        }
        this.game.Data.RegimeObj[0].AI = false;
        if (this.doallied == 1)
          this.game.Data.DoAllied = true;
        else
          this.game.Data.DoAllied = false;
        if (this.dofirsttech == 1)
        {
          let mut regimeCounter3: i32 = this.game.Data.RegimeCounter;
          for (index22 = 0; index22 <= regimeCounter3; index22 += 1)
          {
            let mut researchCounter: i32 = this.game.Data.ResearchCounter;
            for (let mut index24: i32 = 0; index24 <= researchCounter; index24 += 1)
            {
              if (this.game.Data.ResearchObj[index24].TechLevel == 1)
                this.game.Data.RegimeObj[index22].ResField[index24] = true;
            }
          }
        }
        let mut mapWidth1: i32 = this.game.Data.MapObj[0].MapWidth;
        for (let mut index25: i32 = 0; index25 <= mapWidth1; index25 += 1)
        {
          let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
          for (let mut index26: i32 = 0; index26 <= mapHeight; index26 += 1)
          {
            if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index25, index26].LandscapeType].IsSea)
            {
              let mut index27: i32 = 0;
              do
              {
                if (this.game.Data.MapObj[0].HexObj[index25, index26].RiverType[index27] > -1)
                {
                  this.game.Data.MapObj[0].HexObj[index25, index26].RiverType[index27] = -1;
                  coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index25, index26, this.game.EditObj.MapSelected, index27 + 1);
                  if (coordinate.onmap)
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RiverType[this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, coordinate.map, index25, index26, 0) - 1] = -1;
                }
                index27 += 1;
              }
              while (index27 <= 5);
            }
          }
        }
        let mut num26: i32 = 10;
        let mut num27: i32 = 10;
        let mut mapWidth2: i32 = this.game.Data.MapObj[0].MapWidth;
        for (let mut x1: i32 = 0; x1 <= mapWidth2; x1 += 1)
        {
          let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
          for (let mut y1: i32 = 0; y1 <= mapHeight; y1 += 1)
          {
            if (this.game.Data.MapObj[0].HexObj[x1, y1].Location > -1)
            {
              let mut num28: i32 = 0;
              float num29 = 0.0f;
              let mut num30: i32 = 0;
              float num31 = 0.0f;
              let mut num32: i32 = 0;
              float num33 = 0.0f;
              let mut num34: i32 = 0;
              float num35 = 0.0f;
              if ( this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x1, y1].Location].Type ==  this.game.Data.RuleVar[413])
              {
                num28 = 0;
                num29 = 0.0f;
                num30 = 1;
                num31 = 0.1f;
                num32 = 1;
                num33 = 1f;
                num34 = 2;
                num35 = 0.2f;
              }
              if ( this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x1, y1].Location].Type ==  this.game.Data.RuleVar[414])
              {
                num28 = 0;
                num29 = 0.0f;
                num30 = 1;
                num31 = 0.2f;
                num32 = 1;
                num33 = 1f;
                num34 = 3;
                num35 = 0.2f;
              }
              if ( this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x1, y1].Location].Type ==  this.game.Data.RuleVar[415])
              {
                num28 = 0;
                num29 = 0.0f;
                num30 = 1;
                num31 = 0.3f;
                num32 = 1;
                num33 = 1f;
                num34 = 3;
                num35 = 0.5f;
              }
              if ( this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x1, y1].Location].Type ==  this.game.Data.RuleVar[416])
              {
                num28 = 0;
                num29 = 0.0f;
                num30 = 1;
                num31 = 0.35f;
                num32 = 2;
                num33 = 1f;
                num34 = 5;
                num35 = 0.2f;
              }
              if ( this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x1, y1].Location].Type ==  this.game.Data.RuleVar[410])
              {
                num28 = 0;
                num29 = 0.0f;
                num30 = 1;
                num31 = 0.4f;
                num32 = 2;
                num33 = 1f;
                num34 = 5;
                num35 = 0.2f;
              }
              let mut num36: i32 = x1 - num26;
              let mut num37: i32 = x1 + num26;
              for (let mut x2: i32 = num36; x2 <= num37; x2 += 1)
              {
                let mut num38: i32 = y1 - num27;
                let mut num39: i32 = y1 + num27;
                for (let mut y2: i32 = num38; y2 <= num39; y2 += 1)
                {
                  if (x2 >= 0 & y2 >= 0 & x2 <= this.game.Data.MapObj[0].MapWidth & y2 <= this.game.Data.MapObj[0].MapHeight)
                  {
                    if (this.domirror == 1)
                    {
                      let mut num40: i32 =  Math.Round(Conversion.Int( (this.game.Data.MapObj[0].MapWidth + 1) / 2.0));
                      let mut num41: i32 =  Math.Round(Conversion.Int( (this.game.Data.MapObj[0].MapHeight + 1) / 2.0));
                      let mut num42: i32 = y2 < num41 ? (y2 >= num41 ? num41 : this.game.Data.MapObj[0].MapHeight - y2) : this.game.Data.MapObj[0].MapHeight - y2;
                      let mut num43: i32 = x2 < num40 ? (x2 >= num40 ? x2 : this.game.Data.MapObj[0].MapWidth - x2) : this.game.Data.MapObj[0].MapWidth - x2;
                    }
                    let mut num44: i32 = this.game.HandyFunctionsObj.Distance(x1, y1, 0, x2, y2, 0);
                    let mut landscapeType: i32 = this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType;
                    if (landscapeType == this.GRASS | landscapeType == this.LIGHTFOREST | landscapeType == this.HEAVYFOREST | landscapeType == this.SWAMP | landscapeType == this.FARMLAND | landscapeType == this.LOWMOUNTAIN | landscapeType == this.HIGHMOUNTAIN)
                    {
                      if ( VBMath.Rnd() <=  num29 & num44 <= num28 |  num44 <= Conversion.Int( num28 / 2.0))
                      {
                        this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType =  Math.Round( this.game.Data.RuleVar[444]);
                        this.game.Data.MapObj[0].HexObj[x2, y2].SpriteNr =  Math.Round( this.game.Data.RuleVar[447]);
                        if ( this.game.Data.RuleVar[463] > 0.0)
                          this.game.Data.MapObj[0].HexObj[x2, y2].AreaCode[ Math.Round( this.game.Data.RuleVar[463])] = this.game.Data.MapObj[0].HexObj[x1, y1].AreaCode[ Math.Round( this.game.Data.RuleVar[463])];
                      }
                      else if ( VBMath.Rnd() <=  num31 & num44 <= num30 & !(landscapeType == this.HEAVYFOREST &  VBMath.Rnd() < 0.25 | landscapeType == this.HIGHMOUNTAIN | landscapeType == this.LOWMOUNTAIN &  VBMath.Rnd() < 0.5))
                      {
                        this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.LIGHTURBAN;
                        this.game.Data.MapObj[0].HexObj[x2, y2].SpriteNr = 0;
                        if ( this.game.Data.RuleVar[463] > 0.0)
                          this.game.Data.MapObj[0].HexObj[x2, y2].AreaCode[ Math.Round( this.game.Data.RuleVar[463])] = this.game.Data.MapObj[0].HexObj[x1, y1].AreaCode[ Math.Round( this.game.Data.RuleVar[463])];
                      }
                      else if ( VBMath.Rnd() <=  num33 & num44 <= num32 & !(landscapeType == this.HEAVYFOREST &  VBMath.Rnd() < 0.4 | landscapeType == this.HIGHMOUNTAIN | landscapeType == this.LOWMOUNTAIN &  VBMath.Rnd() < 0.3))
                      {
                        this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.FARMLAND;
                        this.game.Data.MapObj[0].HexObj[x2, y2].SpriteNr = 0;
                      }
                      else if ( VBMath.Rnd() <=  num35 & num44 <= num34 & !(landscapeType == this.HEAVYFOREST &  VBMath.Rnd() < 0.6 | landscapeType == this.HIGHMOUNTAIN | landscapeType == this.LOWMOUNTAIN &  VBMath.Rnd() < 0.1))
                      {
                        this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.FARMLAND;
                        this.game.Data.MapObj[0].HexObj[x2, y2].SpriteNr = 0;
                      }
                      if (this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType == -1)
                      {
                        this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.GRASS;
                        this.game.Data.MapObj[0].HexObj[x2, y2].SpriteNr = 0;
                      }
                    }
                  }
                }
              }
            }
          }
        }
        let mut mapWidth3: i32 = this.game.Data.MapObj[0].MapWidth;
        for (let mut cx: i32 = 0; cx <= mapWidth3; cx += 1)
        {
          let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
          for (let mut cy: i32 = 0; cy <= mapHeight; cy += 1)
          {
            let mut landscapeType1: i32 = this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType;
            if (landscapeType1 == this.HEAVYFOREST &  this.game.Data.RuleVar[448] == 1.0)
            {
              let mut tfacing: i32 = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap)
                {
                  let mut landscapeType2: i32 = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType;
                  if (landscapeType2 == this.GRASS | landscapeType2 == this.SWAMP | landscapeType2 == this.LIGHTURBAN | landscapeType2 == this.FARMLAND)
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType = this.LIGHTFOREST;
                }
                tfacing += 1;
              }
              while (tfacing <= 6);
            }
            if (landscapeType1 == this.HIGHMOUNTAIN &  this.game.Data.RuleVar[449] == 1.0)
            {
              let mut tfacing: i32 = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap)
                {
                  let mut landscapeType3: i32 = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType;
                  if (landscapeType3 == this.GRASS | landscapeType3 == this.SWAMP | landscapeType3 == this.LIGHTURBAN | landscapeType3 == this.LIGHTFOREST | landscapeType3 == this.HEAVYFOREST | landscapeType3 == this.FARMLAND)
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType = this.LOWMOUNTAIN;
                }
                tfacing += 1;
              }
              while (tfacing <= 6);
            }
          }
        }
        this.game.HandyFunctionsObj.randomizeLT();
        if (this.optr4 == 1 & this.opt9v > 1)
          this.opt9v = 1;
        if (this.opt9v > 0)
        {
          let mut num45: i32 = opt1v;
          for (let mut x: i32 = 0; x <= num45; x += 1)
          {
            let mut num46: i32 = opt2v;
            for (let mut y: i32 = 0; y <= num46; y += 1)
            {
              if (this.game.Data.MapObj[0].HexObj[x, y].Location > -1 & this.game.Data.MapObj[0].HexObj[x, y].VP > 0)
                this.MakeRoads(x, y, this.opt9v, false);
            }
          }
          let mut num47: i32 = opt1v;
          for (let mut x: i32 = 0; x <= num47; x += 1)
          {
            let mut num48: i32 = opt2v;
            for (let mut y: i32 = 0; y <= num48; y += 1)
            {
              if (this.game.Data.MapObj[0].HexObj[x, y].Location > -1 & this.game.Data.MapObj[0].HexObj[x, y].VP > 0 &&  this.game.Data.RuleVar[461] == 1.0 & this.optr4 == 0)
                this.MakeRoads(x, y, this.opt9v, true);
            }
          }
          let mut num49: i32 = opt1v;
          for (let mut x: i32 = 0; x <= num49; x += 1)
          {
            let mut num50: i32 = opt2v;
            for (let mut y: i32 = 0; y <= num50; y += 1)
            {
              if (this.game.Data.MapObj[0].HexObj[x, y].Location > -1 &&  this.game.Data.RuleVar[475] > 0.0 & this.optr4 == 0)
                this.MakeRoads2(x, y, this.opt9v);
            }
          }
        }
        if ( this.game.Data.RuleVar[451] == 0.0 && this.optr5 == 0)
          this.HarbourAssurance();
        if (this.opt9v > 0)
        {
          let mut num51: i32 = opt1v;
          for (let mut x: i32 = 0; x <= num51; x += 1)
          {
            let mut num52: i32 = opt2v;
            for (let mut y: i32 = 0; y <= num52; y += 1)
            {
              if (this.RESOURCESLOT > -1 && this.game.Data.MapObj[0].HexObj[x, y].AreaCode[this.RESOURCESLOT] > 0)
                this.MakeRoads(x, y, this.opt9v, false);
              if ( this.game.Data.RuleVar[445] > 0.0 & this.optr4 == 0 &&  this.game.Data.MapObj[0].HexObj[x, y].LandscapeType ==  this.game.Data.RuleVar[445])
                this.MakeRoads(x, y, this.opt9v, false, true);
            }
          }
        }
        this.EnsureMountainPasses2();
        this.PlaceRegimes3();
        if ( this.game.Data.RuleVar[419] > 0.0 &  this.game.Data.RuleVar[419] < 6.0)
          this.game.HandyFunctionsObj.MakeAutoLabels( Math.Round( this.game.Data.RuleVar[419]));
        if ( this.game.Data.RuleVar[420] > -1.0 &  this.game.Data.RuleVar[421] > 0.0 && this.dooldkingdom > 0)
        {
          let mut mapWidth4: i32 = this.game.Data.MapObj[0].MapWidth;
          for (let mut x: i32 = 0; x <= mapWidth4; x += 1)
          {
            let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
            for (let mut y: i32 = 0; y <= mapHeight; y += 1)
            {
              if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[x, y].LandscapeType].IsSea && this.game.Data.MapObj[0].HexObj[x, y].Regime == -1)
              {
                this.game.Data.MapObj[0].HexObj[x, y].Regime = this.game.Data.RegimeCounter;
                if (this.game.Data.MapObj[0].HexObj[x, y].Location > -1)
                {
                  let mut location: i32 = this.game.Data.MapObj[0].HexObj[x, y].Location;
                  let mut unr: i32 = this.game.Data.AddUnit(x, y, 0);
                  this.game.Data.UnitObj[unr].Name = "Garrison";
                  this.game.Data.UnitObj[unr].Regime = index22 - 1;
                  this.game.Data.UnitObj[unr].Supply = 500;
                  this.game.Data.UnitObj[unr].SOSupReqPercent = 100;
                  this.game.Data.UnitObj[unr].IsHQ = false;
                  this.game.Data.LocObj[location].HQ = -1;
                  let mut index28: i32 = this.game.Data.AddSF(unr);
                  this.game.Data.SFObj[index28].Type =  Math.Round( this.game.Data.RuleVar[420]);
                  this.game.Data.SFObj[index28].Qty =  Math.Round( this.game.Data.RuleVar[421]);
                  this.game.Data.SFObj[index28].Rdn = 100;
                  this.game.Data.SFObj[index28].People = 0;
                  this.game.Data.SFObj[index28].Xp = 25;
                  this.game.Data.SFObj[index28].Mor = 50;
                }
              }
            }
          }
        }
        this.game.Data.SupplyMultiplier = 1f;
        this.game.Data.PPMultiplier = 1f;
        this.game.Data.ResMod =  Math.Round( this.game.Data.RuleVar[464]);
        if ( this.game.Data.RuleVar[464] == 0.0)
          this.game.Data.ResMod = 150000;
        this.game.Data.ResMod *= this.game.Data.RegimeCounter;
        this.game.Data.ResCostMod = this.game.Data.RuleVar[465];
        if ( this.game.Data.RuleVar[465] == 0.0)
          this.game.Data.ResCostMod = 1f;
        this.game.Data.ResCostMod *=  this.opt11v / 100f;
        description: String = this.game.Data.Description;
        if (this.game.EditObj.ShortRandomScreen)
        {
          this.game.Data.Designer = "Random Algorithm Gold";
          this.game.Data.Name = "Random Scenario Gold";
        }
        else
        {
          this.game.Data.Designer = "Classic Random Alg.";
          this.game.Data.Name = "Classic Random Scn.";
        }
        if ( this.game.Data.RuleVar[496] < 1.0)
          this.game.Data.Description = "A " + Strings.Trim(Conversion.Str( (this.game.Data.RegimeCounter + 1))) + " player scenario.\r\n";
        else
          this.game.Data.Description = "A " + Strings.Trim(Conversion.Str( this.game.Data.RegimeCounter)) + " player scenario + a hidden AI regime to control any potential 'revolutionary' forces.\r\n";
        if (this.dooldkingdom == 1)
        {
          data: DataClass = this.game.Data;
          data.Description = data.Description + "The People's Republic holds almost all initial territory, but it is weak and only produces 25% of what other regimes can produce. You need " + Strings.Trim(Conversion.Str( this.game.Data.VPWin)) + " Victory Points (100% of total) to win.\r\n";
        }
        else
        {
          data: DataClass = this.game.Data;
          data.Description = data.Description + "You need " + Strings.Trim(Conversion.Str( this.game.Data.VPWin)) + " Victory Points (80% of total) to win.\r\n";
        }
        if (this.game.Data.DoAllied)
          this.game.Data.Description += "\r\nAll AI regimes will ally when game starts.\r\n";
        data1: DataClass = this.game.Data;
        data1.Description = data1.Description + Strings.Trim(Conversion.Str( this.opt4v)) + "% of map is land.\r\n";
        data2: DataClass = this.game.Data;
        data2.Description = data2.Description + "There are about " + Strings.Trim(Conversion.Str( this.opt8v)) + " towns on the map, excluding start cities. The size level of the towns is " + Strings.Trim(Conversion.Str( this.opt10v)) + "\r\n";
        data3: DataClass = this.game.Data;
        data3.Description = data3.Description + "River level is " + Strings.Trim(Conversion.Str( this.opt5v)) + ". " + Strings.Trim(Conversion.Str( this.opt6v)) + "% of land should be forest and " + Strings.Trim(Conversion.Str( this.opt7v)) + "% of land should be mountain.\r\n";
        if (this.opt11v > 100)
        {
          data4: DataClass = this.game.Data;
          data4.Description = data4.Description + "Research is " + Strings.Trim(Conversion.Str( (this.opt11v - 100))) + "% more expensive than normally expected.\r\n";
        }
        else if (this.opt11v < 100)
        {
          data5: DataClass = this.game.Data;
          data5.Description = data5.Description + "Research is " + Strings.Trim(Conversion.Str( (100 - this.opt11v))) + "% cheaper than you would normally expect.\r\n";
        }
        this.game.Data.Description += "\r\n";
        if (this.domirror == 1)
        {
          this.game.Data.Description += "This is a mirror map.";
          this.game.Data.Description += "\r\n";
        }
        if (this.doblockcenter == 1)
        {
          this.game.Data.Description += "BlockCenter has been used for placing regimes.";
          this.game.Data.Description += "\r\n";
        }
        if (this.game.Data.CreatedWithShrowd)
          this.game.Data.Description += "This random game was created with a shroud of darkness. The creator cannot have seen the map in advance.";
        else
          this.game.Data.Description += "This game was not created with shroud of darkness. Keep in mind that the creator might have peeked how the map looks if you play with shroud on.";
        this.game.Data.Description += "\r\n";
        data6: DataClass = this.game.Data;
        data6.Description = data6.Description + "Created with the masterfile: " + this.domasterfile;
        if (Operators.CompareString(this.domasterfile, "advanced.ptmaster", false) == 0)
        {
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "SEASONS";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "If this option is activated. There will be 8 rounds of clear wheater. Followed by 2 rounds of mud. Followed by 4 rounds of winter. Followed by 2 rounds of mud. Then the cycle repeats. Mud halves movement of mechanized land troops and stops movement of air forces (caused by rain). Giving a small break to players with no air supriority. Winter halves the offensive strength of all land troops, but not of air or navy forces.";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "REBELLIONS";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "If this option is activated there is a 2% chance per town per round that rebels will appear near a town in question. If they do the rebels arrive in small level I infantry forces. Between 20-50 individuals.";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "FACTORIES";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "If enabled you will be able to build factories on plain,light forest and heavy forest hexes. Factories must be build at least 3 hexes appart from eachother. AI will not use this option.";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "HARDCORE LOGISTICS";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "If enabled then trucks will be double the price they normally are. Trains will be available. They are equal to trucks but they can carry only 5 troops themselves (trucks=20), they offer the same landcap though. Naval movement speed will be doubled. And most importantly your production can only arrive in the hex where it is produced. This means you will have to build HQs in every producing town. And do a lot of manual transferring. Supply still flows for free from HQ to HQ. (AI is not affected by this rule)";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "NUCLEAR OPTION";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "Allows you to research and build nuclear bombers and tactical nukes. Nuclear Bomber will waste any location except nuclear bunkers and underground factories. Nuclear bombers do not directly attack troops. Bombers will destroy infrastructure (almost always) completly and leave fallout. Tactical nukes will target troops and do relativly limited infrastructural dammage. Fallout spreads out every round. The radiation level on a hex is equal to the troops you will lose. Radiation levels drop 1 every round. The only protection from radiation is having your troops in the same hex as a nuclear bunker or an underground factory. However those locationtypes are expensive to build. The AI will not use nukes. It is advisable to also play with factories on if you play with the nuclear variant. ";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "IMMEDIATE NUCLEAR TECH";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "Game starts with every player possesing the Nuclear I researchfield (to build simple nuclear bombers).";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "DIPLOMATICS";
          this.game.Data.Description += "\r\n";
          this.game.Data.Description += "More multiplayer fun. Game starts with every player at war. But with this option turned on you can offer and make peace. Also there are cards to give PP grants to other players. All statistics which are normally hidden about casualties, kills and production are visible for everybody. Also you can share your recon with your allies if you feel like it.";
        }
        if ((uint) this.dostats > 0U)
          this.game.Data.RuleVar[313] = 1f;
        if ( this.game.Data.RuleVar[499] > 0.0)
          this.game.Data.GameSlot[ Math.Round( this.game.Data.RuleVar[499])] = 1;
        if ( this.game.Data.RuleVar[480] > 0.0)
          this.game.EventRelatedObj.DoCheckSpecificEvent( Math.Round( this.game.Data.RuleVar[480]));
        this.SmallIslands();
        let mut mapWidth5: i32 = this.game.Data.MapObj[0].MapWidth;
        for (let mut cx: i32 = 0; cx <= mapWidth5; cx += 1)
        {
          let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
          for (let mut cy: i32 = 0; cy <= mapHeight; cy += 1)
          {
            let mut index29: i32 = 0;
            do
            {
              if (this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index29] > -1)
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, index29 + 1);
                if (coordinate.onmap)
                {
                  let mut index30: i32 = index29 + 3;
                  if (index30 > 5)
                    index30 -= 6;
                  this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RiverType[index30] = this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index29];
                }
              }
              index29 += 1;
            }
            while (index29 <= 5);
          }
        }
        let mut regimeCounter4: i32 = this.game.Data.RegimeCounter;
        for (let mut index31: i32 = 0; index31 <= regimeCounter4; index31 += 1)
        {
          this.game.Data.RegimeObj[index31].LoadSprites();
          this.game.Data.RegimeObj[index31].DoTempCounter();
        }
        let mut mapWidth6: i32 = this.game.Data.MapObj[0].MapWidth;
        for (let mut index32: i32 = 0; index32 <= mapWidth6; index32 += 1)
        {
          let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
          for (let mut index33: i32 = 0; index33 <= mapHeight; index33 += 1)
          {
            if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index32, index33].LandscapeType].IsSea)
              this.game.Data.MapObj[0].HexObj[index32, index33].Regime = -1;
          }
        }
        let mut regimeCounter5: i32 = this.game.Data.RegimeCounter;
        for (let mut index34: i32 = 0; index34 <= regimeCounter5; index34 += 1)
        {
          if (Strings.InStr(this.game.Data.RegimeObj[index34].Name, "<x>") > 0)
          {
            let mut num53: i32 = 0;
            let mut num54: i32 = 0;
            let mut num55: i32 = 0;
            newValue: String = "";
            let mut mapWidth7: i32 = this.game.Data.MapObj[0].MapWidth;
            for (let mut index35: i32 = 0; index35 <= mapWidth7; index35 += 1)
            {
              let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
              for (let mut index36: i32 = 0; index36 <= mapHeight; index36 += 1)
              {
                if (this.game.Data.MapObj[0].HexObj[index35, index36].Regime == index34 && this.game.Data.MapObj[0].HexObj[index35, index36].VP > num53 & this.game.Data.MapObj[0].HexObj[index35, index36].Location > -1)
                {
                  num53 = this.game.Data.MapObj[0].HexObj[index35, index36].VP;
                  num54 = index35;
                  num55 = index36;
                  newValue = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index35, index36].Location].Name;
                }
              }
            }
            this.game.Data.RegimeObj[index34].Name = this.game.Data.RegimeObj[index34].Name.Replace("<x>", newValue);
          }
        }
      }
    }

    pub fn SmallIslands()
    {
      let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut cx: i32 = 0; cx <= mapWidth; cx += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut cy: i32 = 0; cy <= mapHeight; cy += 1)
        {
          if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType].IsSea)
          {
            let mut num1: i32 = 0;
            let mut tfacing1: i32 = 1;
            Coordinate coordinate;
            do
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing1);
              if (coordinate.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                num1 += 1;
              tfacing1 += 1;
            }
            while (tfacing1 <= 6);
            if (num1 == 0)
            {
              let mut num2: i32 =  Math.Round(2.0 + Conversion.Int( VBMath.Rnd() * 1.99));
label_15:
              if (num2 > 0)
              {
                let mut tfacing2: i32 = 1;
                do
                {
                  coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing2);
                  if (coordinate.onmap & num2 > 0 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                  {
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType = this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType;
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime = this.game.Data.MapObj[0].HexObj[cx, cy].Regime;
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].SpriteNr = this.game.Data.MapObj[0].HexObj[cx, cy].SpriteNr;
                    let mut index: i32 = 0;
                    do
                    {
                      this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].AreaCode[index] = this.game.Data.MapObj[0].HexObj[cx, cy].AreaCode[index];
                      index += 1;
                    }
                    while (index <= 9);
                    --num2;
                  }
                  tfacing2 += 1;
                }
                while (tfacing2 <= 6);
                goto label_15;
              }
            }
          }
        }
      }
    }

    pub fn MakeClimates()
    {
      let mut index1: i32 =  Math.Round( this.game.Data.RuleVar[481]);
      let mut num1: i32 = 3;
      numArray: Vec<i32> = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      if ( this.game.Data.RuleVar[498] > 0.0 & this.Sclimate == 0)
        this.game.Data.GameSlot[ Math.Round( this.game.Data.RuleVar[498])] = 1;
      num2: i32;
      num3: i32;
      if (this.Sclimate == 0)
      {
        num2 = 2;
        num1 = 2;
        num3 = 0;
      }
      if (this.Sclimate == 1)
      {
        num2 = 1;
        num1 = 3;
        num3 = 3;
      }
      if (this.Sclimate == 2)
      {
        num2 = 1;
        num1 = 2;
        num3 = 1;
      }
      if (this.Sclimate == 3)
      {
        num2 = 3;
        num1 = 4;
        num3 = 1;
      }
      if (this.Sclimate == 4)
      {
        num2 = 2;
        num1 = 2;
        num3 = 0;
      }
      let mut mapWidth1: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut index2: i32 = 0; index2 <= mapWidth1; index2 += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut index3: i32 = 0; index3 <= mapHeight; index3 += 1)
        {
          let mut num4: i32 = num3 + 1;
          for (let mut index4: i32 = 1; index4 <= num4; index4 += 1)
          {
            if ( index3 <=  this.game.Data.MapObj[0].MapHeight * ( index4 /  num3 + 1.0) &&  index3 >=  this.game.Data.MapObj[0].MapHeight * ( (index4 - 1) /  (num3 + 1)))
              this.game.Data.MapObj[0].HexObj[index2, index3].AreaCode[index1] = num2 + index4 - 1;
          }
        }
      }
      let mut num5: i32 =  Math.Round(Conversion.Int( this.game.Data.MapObj[0].MapWidth / 25.0));
      if (num5 == 0)
        num5 = 1;
      if (!(this.Sclimate == 1 | this.Sclimate == 3))
        return;
      let mut num6: i32 = num5;
      for (let mut index5: i32 = 1; index5 <= num6; index5 += 1)
      {
        num7: i32;
        num8: i32;
        if (this.Sclimate == 1)
        {
          num7 =  Math.Round( this.game.Data.MapObj[0].MapHeight * 0.625);
          num8 =  Math.Round( this.game.Data.MapObj[0].MapHeight * 0.875);
        }
        else if (this.Sclimate == 3)
        {
          num7 =  Math.Round( this.game.Data.MapObj[0].MapHeight * (5.0 / 16.0));
          num8 =  Math.Round( this.game.Data.MapObj[0].MapHeight * (11.0 / 16.0));
        }
        if (this.optr2 == 0)
        {
          let mut num9: i32 =  Math.Round( Conversion.Int(VBMath.Rnd() *  (this.game.Data.MapObj[0].MapWidth - 12)));
          let mut num10: i32 =  Math.Round( ( num9 + Conversion.Int( (2.0 +  VBMath.Rnd() * 20.0))));
          let mut mapWidth2: i32 = this.game.Data.MapObj[0].MapWidth;
          for (let mut index6: i32 = 0; index6 <= mapWidth2; index6 += 1)
          {
            let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
            for (let mut index7: i32 = 0; index7 <= mapHeight; index7 += 1)
            {
              if (index6 >= num9 & index6 <= num10 && index7 >= num7 & index7 <= num8)
              {
                this.game.Data.MapObj[0].HexObj[index6, index7].AreaCode[index1] = 99;
                numArray[index6, index7] = 1;
              }
            }
          }
        }
        else if (this.optr2 == -1)
        {
          let mut num11: i32 = 0;
          let mut mapWidth3: i32 = this.game.Data.MapObj[0].MapWidth;
          let mut mapWidth4: i32 = this.game.Data.MapObj[0].MapWidth;
          for (let mut index8: i32 = 0; index8 <= mapWidth4; index8 += 1)
          {
            let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
            for (let mut index9: i32 = 0; index9 <= mapHeight; index9 += 1)
            {
              if (index8 >= num11 & index8 <= mapWidth3 && index9 >= num7 & index9 <= num8)
              {
                this.game.Data.MapObj[0].HexObj[index8, index9].AreaCode[index1] = 99;
                numArray[index8, index9] = 1;
              }
            }
          }
        }
        else if (this.optr2 == -2)
        {
          num7 =  Math.Round( (0 + num7) / 2.0);
          num8 =  Math.Round( (num8 + this.game.Data.MapObj[0].MapHeight) / 2.0);
          let mut num12: i32 = 0;
          let mut mapWidth5: i32 = this.game.Data.MapObj[0].MapWidth;
          let mut mapWidth6: i32 = this.game.Data.MapObj[0].MapWidth;
          for (let mut index10: i32 = 0; index10 <= mapWidth6; index10 += 1)
          {
            let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
            for (let mut index11: i32 = 0; index11 <= mapHeight; index11 += 1)
            {
              if (index10 >= num12 & index10 <= mapWidth5 && index11 >= num7 & index11 <= num8)
              {
                this.game.Data.MapObj[0].HexObj[index10, index11].AreaCode[index1] = 99;
                numArray[index10, index11] = 1;
              }
            }
          }
        }
        let mut num13: i32 = 1;
        do
        {
          let mut mapWidth7: i32 = this.game.Data.MapObj[0].MapWidth;
          for (let mut cx: i32 = 0; cx <= mapWidth7; cx += 1)
          {
            let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
            for (let mut cy: i32 = 0; cy <= mapHeight; cy += 1)
            {
              if (this.game.Data.MapObj[0].HexObj[cx, cy].AreaCode[index1] == 99 & numArray[cx, cy] == num13)
              {
                let mut tfacing: i32 = 1;
                do
                {
                  Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                  if (coordinate.onmap && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].AreaCode[index1] != 99 & numArray[coordinate.x, coordinate.y] < num13)
                  {
                    numArray[coordinate.x, coordinate.y] = num13;
                    if ( VBMath.Rnd() > 0.5)
                    {
                      numArray[coordinate.x, coordinate.y] = num13 + 1;
                      this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].AreaCode[index1] = 99;
                    }
                  }
                  tfacing += 1;
                }
                while (tfacing <= 6);
              }
            }
          }
          num13 += 1;
        }
        while (num13 <= 4);
      }
    }

    pub fn PlaceResources()
    {
      SimpleList simpleList = SimpleList::new();
      numArray: Vec<i32> = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      let mut stringListById: i32 = this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[452]));
      if (stringListById == -1)
        return;
      this.game.AIObj.InitFindContinent();
      let mut length: i32 = this.game.Data.StringListObj[stringListById].Length;
      for (let mut index1: i32 = 0; index1 <= length; index1 += 1)
      {
        let mut integer1: i32 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 0]);
        let mut integer2: i32 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 1]);
        let mut integer3: i32 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 2]);
        let mut integer4: i32 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 3]);
        let mut integer5: i32 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 4]);
        if (this.RESOURCESLOT == -1)
          this.RESOURCESLOT = integer5;
        let mut integer6: i32 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 5]);
        let mut integer7: i32 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 6]);
        let mut integer8: i32 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 7]);
        let mut integer9: i32 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 8]);
        str: String = this.game.Data.StringListObj[stringListById].Data[index1, 9];
        let mut num1: i32 = this.game.HandyFunctionsObj.CountLandHexesOnMap(0);
        let mut num2: i32 =  Math.Round(Conversion.Int( integer9 * ( num1 / 1000.0)));
        let mut regimeCounter: i32 = this.game.Data.RegimeCounter;
        index2: i32;
        Coordinate coordinate;
        for (let mut index3: i32 = 0; index3 <= regimeCounter; index3 += 1)
        {
          let mut num3: i32 = 0;
          let mut num4: i32 = integer8;
          if (this.Sraw == 1)
            num4 =  Math.Round( num4 / 2.0);
          if (integer8 % 2 > 0 &  VBMath.Rnd() > 0.5)
            num4 += 1;
          let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
          index4: i32;
          for (index4 = 0; index4 <= mapWidth; index4 += 1)
          {
            let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
            for (index2 = 0; index2 <= mapHeight; index2 += 1)
            {
              if (this.game.Data.MapObj[0].HexObj[index4, index2].Regime == index3)
              {
                num3 = 1;
                break;
              }
            }
            if (num3 == 1)
              break;
          }
          if (num3 == 1)
          {
            let mut x2: i32 = index4;
            let mut y2: i32 = index2;
            let mut num5: i32 = 0;
            while (num4 > 0 & num5 < 9999)
            {
              num5 += 1;
              let mut index5: i32 =  Math.Round( ( (x2 - integer7) + VBMath.Rnd() * 2f *  integer7));
              index2 =  Math.Round( ( (y2 - integer7) + VBMath.Rnd() * 2f *  integer7));
              let mut num6: i32 = 0;
              let mut tfacing: i32 = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(index5, index2, 0, tfacing);
                if (coordinate.onmap && this.game.HandyFunctionsObj.IsHexHarbourOrSea(coordinate.x, coordinate.y, coordinate.map))
                  num6 += 1;
                tfacing += 1;
              }
              while (tfacing <= 6);
              if (num6 >= 1)
                index5 = -1;
              if (index5 >= 0 & index2 >= 0 & index5 <= this.game.Data.MapObj[0].MapWidth & index2 <= this.game.Data.MapObj[0].MapHeight && this.game.Data.MapObj[0].HexObj[index5, index2].LandscapeType == integer1 | integer1 == -1 && this.game.Data.MapObj[0].HexObj[index5, index2].SpriteNr == integer2 | integer2 == -1 && this.game.AIObj.HexContinent[index5, index2] == this.game.AIObj.HexContinent[x2, y2] && this.game.Data.MapObj[0].HexObj[index5, index2].Location == -1 && this.game.Data.MapObj[0].HexObj[index5, index2].SpecialType <= -1 && this.game.HandyFunctionsObj.Distance(index5, index2, 0, x2, y2, 0) <= integer7)
              {
                --num4;
                this.game.Data.MapObj[0].HexObj[index5, index2].SpecialType = integer3;
                this.game.Data.MapObj[0].HexObj[index5, index2].SpecialSprite = integer4;
                this.game.Data.MapObj[0].HexObj[index5, index2].AreaCode[integer5] = integer6;
                this.game.Data.MapObj[0].HexObj[index5, index2].Name = str;
              }
            }
            if (num4 > 0 & integer1 > -1 & integer2 > -1)
            {
              let mut num7: i32 = 0;
              while (num4 > 0 & num7 < 9999)
              {
                num7 += 1;
                let mut index6: i32 =  Math.Round( ( (x2 - integer7) + VBMath.Rnd() * 2f *  integer7));
                index2 =  Math.Round( ( (y2 - integer7) + VBMath.Rnd() * 2f *  integer7));
                let mut num8: i32 = 0;
                let mut tfacing: i32 = 1;
                do
                {
                  coordinate = this.game.HandyFunctionsObj.HexNeighbour(index6, index2, 0, tfacing);
                  if (coordinate.onmap && this.game.HandyFunctionsObj.IsHexHarbourOrSea(coordinate.x, coordinate.y, coordinate.map))
                    num8 += 1;
                  tfacing += 1;
                }
                while (tfacing <= 6);
                if (num8 >= 1)
                  index6 = -1;
                if (index6 >= 0 & index2 >= 0 & index6 <= this.game.Data.MapObj[0].MapWidth & index2 <= this.game.Data.MapObj[0].MapHeight && this.game.AIObj.HexContinent[index6, index2] == this.game.AIObj.HexContinent[x2, y2] && this.game.Data.MapObj[0].HexObj[index6, index2].Location == -1 && this.game.Data.MapObj[0].HexObj[index6, index2].SpecialType <= -1 && this.game.HandyFunctionsObj.Distance(index6, index2, 0, x2, y2, 0) <= integer7)
                {
                  --num4;
                  this.game.Data.MapObj[0].HexObj[index6, index2].SpecialType = integer3;
                  this.game.Data.MapObj[0].HexObj[index6, index2].SpecialSprite = integer4;
                  this.game.Data.MapObj[0].HexObj[index6, index2].LandscapeType = integer1;
                  this.game.Data.MapObj[0].HexObj[index6, index2].SpriteNr = integer2;
                  this.game.Data.MapObj[0].HexObj[index6, index2].AreaCode[integer5] = integer6;
                  this.game.Data.MapObj[0].HexObj[index6, index2].Name = str;
                }
              }
            }
          }
        }
        let mut num9: i32 = 0;
        let mut num10: i32 = -1;
        let mut num11: i32 = num2;
        if (this.Sraw == 1)
          num11 =  Math.Round( num11 / 2.0);
        if (num2 % 2 > 0 &  VBMath.Rnd() > 0.5)
          num11 += 1;
        if (num11 > 0)
        {
          while (num11 > 0 & num9 < 9999)
          {
            let mut index7: i32 = -1;
            let mut index8: i32 = -1;
            long num12 = 0;
            num9 += 1;
            let mut num13: i32 = 1;
            index9: i32;
            do
            {
              index9 =  Math.Round( Conversion.Int(VBMath.Rnd() *  (this.game.Data.MapObj[0].MapWidth + 1)));
              index2 =  Math.Round( Conversion.Int(VBMath.Rnd() *  (this.game.Data.MapObj[0].MapHeight + 1)));
              let mut num14: i32 = 0;
              let mut tfacing: i32 = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(index9, index2, 0, tfacing);
                if (coordinate.onmap && this.game.HandyFunctionsObj.IsHexHarbourOrSea(coordinate.x, coordinate.y, coordinate.map))
                  num14 += 1;
                tfacing += 1;
              }
              while (tfacing <= 6);
              if (num14 >= 1)
                index9 = -1;
              if (index9 >= 0 & index2 >= 0 & index9 <= this.game.Data.MapObj[0].MapWidth & index2 <= this.game.Data.MapObj[0].MapHeight && this.game.Data.MapObj[0].HexObj[index9, index2].LandscapeType == integer1 | integer1 == -1 && this.game.Data.MapObj[0].HexObj[index9, index2].SpriteNr == integer2 | integer2 == -1 && this.game.Data.MapObj[0].HexObj[index9, index2].Location == -1 && this.game.Data.MapObj[0].HexObj[index9, index2].SpecialType <= -1)
              {
                let mut num15: i32 = 999;
                let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
                for (let mut x2: i32 = 0; x2 <= mapWidth; x2 += 1)
                {
                  let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
                  for (let mut y2: i32 = 0; y2 <= mapHeight; y2 += 1)
                  {
                    if (this.game.Data.MapObj[0].HexObj[x2, y2].AreaCode[integer5] == integer6)
                    {
                      let mut num16: i32 = this.game.HandyFunctionsObj.Distance(index9, index2, 0, x2, y2, 0, 20);
                      if (num16 < num15)
                        num15 = num16;
                    }
                  }
                }
                if ((long) num15 > num12 & num15 > 4)
                {
                  num12 = (long) num15;
                  index7 = index9;
                  index8 = index2;
                }
              }
              num13 += 1;
            }
            while (num13 <= 100);
            if (index7 > -1)
            {
              num17: i32;
              if (this.domirror == 1)
              {
                if (num10 == -1)
                {
                  let mut num18: i32 =  Math.Round(Conversion.Int( (this.game.Data.MapObj[0].MapWidth + 1) / 2.0));
                  let mut num19: i32 =  Math.Round(Conversion.Int( (this.game.Data.MapObj[0].MapHeight + 1) / 2.0));
                  let mut num20: i32 = index2 < num19 ? (index2 >= num19 ? num19 : this.game.Data.MapObj[0].MapHeight - index8) : this.game.Data.MapObj[0].MapHeight - index8;
                  num10 = index9 < num18 ? (index9 >= num18 ? num18 : this.game.Data.MapObj[0].MapWidth - index7) : this.game.Data.MapObj[0].MapWidth - index7;
                  num17 = num20;
                }
                else
                {
                  index7 = num10;
                  index8 = num17;
                  num10 = -1;
                  num17 = -1;
                }
              }
              --num11;
              this.game.Data.MapObj[0].HexObj[index7, index8].SpecialType = integer3;
              this.game.Data.MapObj[0].HexObj[index7, index8].SpecialSprite = integer4;
              this.game.Data.MapObj[0].HexObj[index7, index8].AreaCode[integer5] = integer6;
              this.game.Data.MapObj[0].HexObj[index7, index8].Name = str;
            }
          }
        }
        if (num11 > 0)
        {
          let mut num21: i32 = 0;
          while (num11 > 0 & integer1 > -1 & integer2 > -1 & num21 < 9999)
          {
            let mut num22: i32 = num21 + 1;
            let mut index10: i32 = -1;
            let mut index11: i32 = -1;
            long num23 = 0;
            num21 = num22 + 1;
            let mut num24: i32 = 1;
            do
            {
              let mut index12: i32 =  Math.Round( Conversion.Int(VBMath.Rnd() *  (this.game.Data.MapObj[0].MapWidth + 1)));
              index2 =  Math.Round( Conversion.Int(VBMath.Rnd() *  (this.game.Data.MapObj[0].MapHeight + 1)));
              let mut num25: i32 = 0;
              let mut tfacing: i32 = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(index12, index2, 0, tfacing);
                if (coordinate.onmap && this.game.HandyFunctionsObj.IsHexHarbourOrSea(coordinate.x, coordinate.y, coordinate.map))
                  num25 += 1;
                tfacing += 1;
              }
              while (tfacing <= 6);
              if (num25 >= 1)
                index12 = -1;
              if (index12 >= 0 & index2 >= 0 & index12 <= this.game.Data.MapObj[0].MapWidth & index2 <= this.game.Data.MapObj[0].MapHeight && this.game.Data.MapObj[0].HexObj[index12, index2].Location == -1 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index12, index2].LandscapeType].IsSea && this.game.Data.MapObj[0].HexObj[index12, index2].SpecialType <= -1)
              {
                let mut num26: i32 = 999;
                let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
                for (let mut x2: i32 = 0; x2 <= mapWidth; x2 += 1)
                {
                  let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
                  for (let mut y2: i32 = 0; y2 <= mapHeight; y2 += 1)
                  {
                    if (this.game.Data.MapObj[0].HexObj[x2, y2].AreaCode[integer5] == integer6)
                    {
                      let mut num27: i32 = this.game.HandyFunctionsObj.Distance(index12, index2, 0, x2, y2, 0, 20);
                      if (num27 < num26)
                        num26 = num27;
                    }
                  }
                }
                if ((long) num26 > num23)
                {
                  num23 = (long) num26;
                  index10 = index12;
                  index11 = index2;
                }
              }
              num24 += 1;
            }
            while (num24 <= 1000);
            if (index10 > -1)
            {
              --num11;
              this.game.Data.MapObj[0].HexObj[index10, index11].SpecialType = integer3;
              this.game.Data.MapObj[0].HexObj[index10, index11].SpecialSprite = integer4;
              this.game.Data.MapObj[0].HexObj[index10, index11].LandscapeType = integer1;
              this.game.Data.MapObj[0].HexObj[index10, index11].SpriteNr = integer2;
              this.game.Data.MapObj[0].HexObj[index10, index11].AreaCode[integer5] = integer6;
              this.game.Data.MapObj[0].HexObj[index10, index11].Name = str;
            }
          }
        }
      }
    }

    pub fn EqualizeResources()
    {
      SimpleList simpleList1 = SimpleList::new();
      numArray1: Vec<i32> = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[] numArray2 = new int[this.game.Data.RegimeCounter + 1];
      let mut num1: i32 =  Math.Round( this.game.Data.RuleVar[481]);
      num2: i32;
      while (num2 == 0 & num1 > 0)
      {
        num2 = 1;
        int[] numArray3 = new int[this.game.Data.RegimeCounter + 1];
        let mut mapWidth1: i32 = this.game.Data.MapObj[0].MapWidth;
        for (let mut index1: i32 = 0; index1 <= mapWidth1; index1 += 1)
        {
          let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
          for (let mut index2: i32 = 0; index2 <= mapHeight; index2 += 1)
          {
            let mut index3: i32 = 0;
            do
            {
              if (this.game.Data.MapObj[0].HexObj[index1, index2].AreaCode[index3] > 0 & index3 != num1 && this.game.Data.MapObj[0].HexObj[index1, index2].Regime > -1)
              {
                int[] numArray4 = numArray3;
                int[] numArray5 = numArray4;
                let mut regime: i32 = this.game.Data.MapObj[0].HexObj[index1, index2].Regime;
                let mut index4: i32 = regime;
                let mut num3: i32 = numArray4[regime] + 1;
                numArray5[index4] = num3;
              }
              index3 += 1;
            }
            while (index3 <= 9);
          }
        }
        let mut num4: i32 = 999999;
        let mut num5: i32 = -1;
        let mut num6: i32 = -1;
        let mut num7: i32 = -1;
        let mut regimeCounter: i32 = this.game.Data.RegimeCounter;
        if (this.Scrate < 1)
          --regimeCounter;
        let mut num8: i32 = regimeCounter;
        for (let mut index: i32 = 0; index <= num8; index += 1)
        {
          if (numArray3[index] < num4 & numArray3[index] > 0)
          {
            num4 = numArray3[index];
            num6 = index;
          }
          if (numArray3[index] > num5)
          {
            num5 = numArray3[index];
            num7 = index;
          }
        }
        let mut tid: i32 = 0;
        if (num5 > num4)
        {
          SimpleList simpleList2 = SimpleList::new();
          let mut mapWidth2: i32 = this.game.Data.MapObj[0].MapWidth;
          for (let mut tdata1: i32 = 0; tdata1 <= mapWidth2; tdata1 += 1)
          {
            let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
            for (let mut tdata2: i32 = 0; tdata2 <= mapHeight; tdata2 += 1)
            {
              let mut index: i32 = 0;
              do
              {
                if (this.game.Data.MapObj[0].HexObj[tdata1, tdata2].AreaCode[index] > 0 & index != num1 && this.game.Data.MapObj[0].HexObj[tdata1, tdata2].Regime == num7)
                {
                  tid += 1;
                  simpleList2.Add(tid, 1, tdata1, tdata2);
                }
                index += 1;
              }
              while (index <= 9);
            }
          }
          if (simpleList2.Counter > -1)
          {
            let mut index5: i32 =  Math.Round( (VBMath.Rnd() *  (simpleList2.Counter + 1)));
            let mut index6: i32 = simpleList2.Data1[index5];
            let mut index7: i32 = simpleList2.Data2[index5];
            this.game.Data.MapObj[0].HexObj[index6, index7].SpecialType = -1;
            this.game.Data.MapObj[0].HexObj[index6, index7].SpecialSprite = -1;
            let mut index8: i32 = 0;
            do
            {
              if (num1 != index8 | num1 == 0)
                this.game.Data.MapObj[0].HexObj[index6, index7].AreaCode[index8] = 0;
              index8 += 1;
            }
            while (index8 <= 9);
            this.game.Data.MapObj[0].HexObj[index6, index7].Name = "";
            num2 = 0;
          }
        }
      }
    }

    pub fn DoSwamps()
    {
      SimpleList simpleList = SimpleList::new();
      numArray: Vec<i32> = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      if (this.opt12v <= 0)
        return;
      let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut index1: i32 = 0; index1 <= mapWidth; index1 += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut index2: i32 = 0; index2 <= mapHeight; index2 += 1)
        {
          if (this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType == this.GRASS | this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType == this.LIGHTFOREST | this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType == this.HEAVYFOREST)
          {
            let mut num1: i32 = 0;
            let mut tfacing: i32 = 1;
            do
            {
              Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index1, index2, this.game.EditObj.MapSelected, tfacing);
              if (coordinate.onmap)
              {
                if (this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType == this.WATER)
                  num1 += 6;
                if (this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType == this.SWAMP)
                  num1 += 3;
                if (this.game.Data.MapObj[0].HexObj[index1, index2].RiverType[tfacing - 1] == this.SMALLRIVER)
                  num1 += 10;
                if (this.game.Data.MapObj[0].HexObj[index1, index2].RiverType[tfacing - 1] == this.BIGRIVER)
                  num1 += 20;
                let mut num2: i32 = index1 - 3;
                let mut num3: i32 = index1 + 3;
                for (let mut x2: i32 = num2; x2 <= num3; x2 += 1)
                {
                  let mut num4: i32 = index2 - 3;
                  let mut num5: i32 = index2 + 3;
                  for (let mut y2: i32 = num4; y2 <= num5; y2 += 1)
                  {
                    if (x2 >= 0 & y2 >= 0 && x2 <= this.game.Data.MapObj[0].MapWidth & y2 <= this.game.Data.MapObj[0].MapHeight)
                    {
                      if (this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType == this.LOWMOUNTAIN)
                        num1 =  Math.Round( num1 - 5.0 / Math.Pow( this.game.HandyFunctionsObj.Distance(index1, index2, 0, x2, y2, 0), 2.0));
                      if (this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType == this.HIGHMOUNTAIN)
                        num1 =  Math.Round( num1 - 10.0 / Math.Pow( this.game.HandyFunctionsObj.Distance(index1, index2, 0, x2, y2, 0), 2.0));
                    }
                  }
                }
              }
              tfacing += 1;
            }
            while (tfacing <= 6);
            if (num1 > 0)
            {
              let mut num6: i32 =  Math.Round( num1 * ( this.opt12v / 10.0));
              if ( VBMath.Rnd() *  num6 >  VBMath.Rnd() * 100.0)
                this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType = this.SWAMP;
            }
          }
        }
      }
    }

    pub fn EnsureMountainPasses()
    {
      SimpleList simpleList = SimpleList::new();
      numArray: Vec<i32> = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut index1: i32 = 0; index1 <= mapWidth; index1 += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut index2: i32 = 0; index2 <= mapHeight; index2 += 1)
        {
          if (this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType == this.HIGHMOUNTAIN)
          {
            if (this.game.HandyFunctionsObj.HasHexRoad(index1, index2, 0))
            {
              this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType = this.LOWMOUNTAIN;
            }
            else
            {
              let mut num1: i32 = 0;
              let mut tfacing1: i32 = 1;
              Coordinate coordinate;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index1, index2, 0, tfacing1);
                if (coordinate.onmap && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType == this.HIGHMOUNTAIN)
                  num1 += 1;
                tfacing1 += 1;
              }
              while (tfacing1 <= 6);
              if (num1 > 1)
              {
                let mut num2: i32 =  Math.Round( Conversion.Int( ( VBMath.Rnd() *  num1 + 1.0)));
                let mut num3: i32 = 0;
                let mut tfacing2: i32 = 1;
                do
                {
                  coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index1, index2, 0, tfacing2);
                  if (coordinate.onmap && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType == this.HIGHMOUNTAIN)
                  {
                    num3 += 1;
                    if (num3 == num2)
                      this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType = this.LOWMOUNTAIN;
                  }
                  tfacing2 += 1;
                }
                while (tfacing2 <= 6);
              }
            }
          }
        }
      }
    }

    pub fn EnsureMountainPasses2()
    {
      SimpleList simpleList = SimpleList::new();
      numArray: Vec<i32> = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut x: i32 = 0; x <= mapWidth; x += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut y: i32 = 0; y <= mapHeight; y += 1)
        {
          if (this.game.Data.MapObj[0].HexObj[x, y].LandscapeType == this.HIGHMOUNTAIN && this.game.HandyFunctionsObj.HasHexRoad(x, y, 0))
            this.game.Data.MapObj[0].HexObj[x, y].LandscapeType = this.LOWMOUNTAIN;
        }
      }
    }

    pub fn HarbourAssurance()
    {
      SimpleList simpleList = SimpleList::new();
      numArray: Vec<i32> = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      if (this.opt4v == 100)
        return;
      let mut num1: i32 = 1;
      while (num1 == 1)
      {
        num1 = 0;
        this.game.AIObj.InitAIOnlyDim();
        this.game.AIObj.InitFindContinent();
        let mut continentCount: i32 = this.game.AIObj.ContinentCount;
        for (let mut index1: i32 = 1; index1 <= continentCount; index1 += 1)
        {
          let mut num2: i32 = 0;
          let mut num3: i32 = 0;
          let mut mapWidth1: i32 = this.game.Data.MapObj[0].MapWidth;
          Coordinate coordinate;
          for (let mut cx: i32 = 0; cx <= mapWidth1; cx += 1)
          {
            let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
            for (let mut cy: i32 = 0; cy <= mapHeight; cy += 1)
            {
              if (this.game.Data.MapObj[0].HexObj[cx, cy].Location > -1 && this.game.AIObj.HexContinent[cx, cy] == index1)
              {
                let mut num4: i32 = 0;
                num2 += 1;
                let mut tfacing: i32 = 1;
                do
                {
                  coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, 0, tfacing);
                  if (coordinate.onmap && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                    num4 = 1;
                  tfacing += 1;
                }
                while (tfacing <= 6);
                if (num4 > 0)
                  num3 += 1;
              }
            }
          }
          if (num2 > 0 & (num3 == 0 |  num3 <  num2 / 3.0) & this.game.AIObj.ContinentCount > 1)
          {
            num1 = 1;
            let mut mapWidth2: i32 = this.game.Data.MapObj[0].MapWidth;
            for (let mut index2: i32 = 0; index2 <= mapWidth2; index2 += 1)
            {
              let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
              for (let mut index3: i32 = 0; index3 <= mapHeight; index3 += 1)
                numArray[index2, index3] = 0;
            }
            let mut mapWidth3: i32 = this.game.Data.MapObj[0].MapWidth;
            for (let mut index4: i32 = 0; index4 <= mapWidth3; index4 += 1)
            {
              let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
              for (let mut index5: i32 = 0; index5 <= mapHeight; index5 += 1)
              {
                if (this.game.Data.MapObj[0].HexObj[index4, index5].Location == -1 && this.game.AIObj.HexContinent[index4, index5] == index1)
                {
                  let mut num5: i32 = 0;
                  numArray[index4, index5] = 1;
                  let mut tfacing1: i32 = 1;
                  do
                  {
                    coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index4, index5, 0, tfacing1);
                    if (coordinate.onmap && numArray[coordinate.x, coordinate.y] == 0 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                      num5 = 1;
                    tfacing1 += 1;
                  }
                  while (tfacing1 <= 6);
                  let mut index6: i32 = 0;
                  do
                  {
                    if (this.game.Data.MapObj[0].HexObj[index4, index5].RoadType[index6] > -1)
                      num5 = 0;
                    index6 += 1;
                  }
                  while (index6 <= 5);
                  if (num5 > 0)
                  {
                    this.game.Data.MapObj[0].HexObj[index4, index5].LandscapeType =  Math.Round( this.game.Data.RuleVar[401]);
                    let mut tfacing2: i32 = 1;
                    do
                    {
                      coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index4, index5, 0, tfacing2);
                      if (coordinate.onmap)
                      {
                        this.game.Data.MapObj[0].HexObj[index4, index5].RiverType[tfacing2 - 1] = -1;
                        this.game.Data.MapObj[0].HexObj[index4, index5].RoadType[tfacing2 - 1] = -1;
                        this.game.Data.MapObj[0].HexObj[index4, index5].Bridge[tfacing2 - 1] = false;
                        let mut index7: i32 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index4, index5, 0) - 1;
                        this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RiverType[index7] = -1;
                        this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RoadType[index7] = -1;
                        this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Bridge[index7] = false;
                      }
                      tfacing2 += 1;
                    }
                    while (tfacing2 <= 6);
                  }
                }
              }
            }
          }
        }
      }
    }

    pub fn MirrorTheMap()
    {
      SimpleList simpleList = SimpleList::new();
      int[] numArray1 = new int[6];
      int[] numArray2 = new int[10];
      let mut num1: i32 =  Math.Round(Conversion.Int( this.game.Data.MapObj[0].MapWidth / 2.0));
      let mut num2: i32 =  Math.Round(Conversion.Int( (this.game.Data.MapObj[0].MapHeight + 1) / 2.0));
      let mut num3: i32 = 3;
      let mut num4: i32 = num1;
      for (let mut index1: i32 = 0; index1 <= num4; index1 += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut index2: i32 = 0; index2 <= mapHeight; index2 += 1)
        {
          if (index1 != this.game.Data.MapObj[0].MapWidth - index1)
          {
            let mut index3: i32 = index2 < num2 ? (index2 >= num2 ? num2 : this.game.Data.MapObj[0].MapHeight - index2) : this.game.Data.MapObj[0].MapHeight - index2;
            let mut index4: i32 = 0;
            do
            {
              numArray2[index4] = this.game.Data.MapObj[0].HexObj[this.game.Data.MapObj[0].MapWidth - index1, index2].AreaCode[index4];
              index4 += 1;
            }
            while (index4 <= 9);
            this.game.Data.MapObj[0].HexObj[this.game.Data.MapObj[0].MapWidth - index1, index2] = this.game.Data.MapObj[0].HexObj[index1, index3].Clone();
            let mut index5: i32 = 0;
            do
            {
              this.game.Data.MapObj[0].HexObj[this.game.Data.MapObj[0].MapWidth - index1, index2].AreaCode[index5] = numArray2[index5];
              index5 += 1;
            }
            while (index5 <= 9);
            let mut index6: i32 = 0;
            do
            {
              numArray1[index6] = this.game.Data.MapObj[0].HexObj[this.game.Data.MapObj[0].MapWidth - index1, index2].RiverType[index6];
              index6 += 1;
            }
            while (index6 <= 5);
            let mut index7: i32 = 0;
            do
            {
              let mut index8: i32 = index7 + num3;
              if (index8 > 5)
                index8 -= 6;
              this.game.Data.MapObj[0].HexObj[this.game.Data.MapObj[0].MapWidth - index1, index2].RiverType[index7] = numArray1[index8];
              index7 += 1;
            }
            while (index7 <= 5);
          }
        }
      }
      let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut index9: i32 = 0; index9 <= mapWidth; index9 += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut index10: i32 = 0; index10 <= mapHeight; index10 += 1)
        {
          let mut index11: i32 = 0;
          do
          {
            if (this.game.Data.MapObj[0].HexObj[index9, index10].RiverType[index11] > -1)
            {
              Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index9, index10, 0, index11 + 1);
              if (coordinate.onmap)
              {
                let mut index12: i32 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index9, index10, 0) - 1;
                if (this.game.Data.MapObj[0].HexObj[index9, index10].RiverType[index11] != this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RiverType[index12])
                  this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RiverType[index12] = this.game.Data.MapObj[0].HexObj[index9, index10].RiverType[index11];
              }
            }
            index11 += 1;
          }
          while (index11 <= 5);
        }
      }
    }

    pub fn MakeRoads2(x: i32, y: i32, roads: i32)
    {
      let mut movetype: i32 =  Math.Round( this.game.Data.RuleVar[99]);
      if ( this.game.Data.RuleVar[478] > 0.0)
        movetype =  Math.Round( this.game.Data.RuleVar[478]);
      if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x, y].Location].Type].MaxProd < 2000)
        return;
      this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.MapObj[0].HexObj[x, y].Regime, movetype, 0, roads * 250, x, y, 0, false, muststartonairfield: false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true, NoBridgePenalty: true);
      SimpleList simpleList = SimpleList::new();
      let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut index: i32 = 0; index <= mapWidth; index += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut tdata2: i32 = 0; tdata2 <= mapHeight; tdata2 += 1)
        {
          if (!(index == x & tdata2 == y) && this.game.Data.MapObj[0].HexObj[index, tdata2].Location > -1 && this.game.EditObj.TempValue[0].Value[index, tdata2] < 150 && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index, tdata2].Location].Type].MaxProd >= 2000)
            simpleList.Add(index,  Math.Round( (VBMath.Rnd() *  this.game.EditObj.TempValue[0].Value[index, tdata2])), index, tdata2);
        }
      }
      if (simpleList.Counter <= -1)
        return;
      simpleList.Sort();
      let mut counter: i32 = simpleList.Counter;
      for (let mut index1: i32 = 0; index1 <= counter; index1 += 1)
      {
        if (index1 < roads + 15)
        {
          this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.MapObj[0].HexObj[x, y].Regime, movetype, 0, roads * 250, simpleList.Data1[index1], simpleList.Data2[index1], 0, false, muststartonairfield: false, SeaBlock: true, BlockAllSea: true, NoBridgePenalty: true, BridgeAP: 40);
          let mut index2: i32 = x;
          y1: i32;
          for (let mut index3: i32 = y; !(index2 == simpleList.Data1[index1] & index3 == simpleList.Data2[index1]); index3 = y1)
          {
            let mut tfacing1: i32 = -1;
            let mut num1: i32 = 9999;
            let mut tfacing2: i32 = 1;
            Coordinate coordinate;
            do
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index2, index3, 0, tfacing2);
              if (coordinate.onmap && this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y] < num1)
              {
                num1 = this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y];
                tfacing1 = tfacing2;
              }
              tfacing2 += 1;
            }
            while (tfacing2 <= 6);
            coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index2, index3, 0, tfacing1);
            let mut index4: i32 = tfacing1 - 1;
            let mut index5: i32 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index2, index3, 0) - 1;
            this.game.Data.MapObj[0].HexObj[index2, index3].RoadType[index4] =  Math.Round( this.game.Data.RuleVar[475]);
            this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RoadType[index5] =  Math.Round( this.game.Data.RuleVar[475]);
            if (this.game.Data.MapObj[0].HexObj[index2, index3].RiverType[index4] > -1)
            {
              this.game.Data.MapObj[0].HexObj[index2, index3].Bridge[index4] = true;
              this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Bridge[index5] = true;
            }
            let mut x1: i32 = coordinate.x;
            y1 = coordinate.y;
            if (this.domirror == 1)
            {
              let mut num2: i32 =  Math.Round(Conversion.Int( (this.game.Data.MapObj[0].MapWidth + 1) / 2.0));
              let mut num3: i32 =  Math.Round(Conversion.Int( (this.game.Data.MapObj[0].MapHeight + 1) / 2.0));
              let mut index6: i32 = index3 < num3 ? (index3 >= num3 ? num3 : this.game.Data.MapObj[0].MapHeight - index3) : this.game.Data.MapObj[0].MapHeight - index3;
              let mut index7: i32 = index2 < num2 ? (index2 >= num2 ? num2 : this.game.Data.MapObj[0].MapWidth - index2) : this.game.Data.MapObj[0].MapWidth - index2;
              let mut tfacing3: i32 = index4 + 1 + 3;
              if (tfacing3 > 6)
                tfacing3 -= 6;
              coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index7, index6, 0, tfacing3);
              let mut index8: i32 = tfacing3 - 1;
              let mut index9: i32 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index7, index6, 0) - 1;
              this.game.Data.MapObj[0].HexObj[index7, index6].RoadType[index8] =  Math.Round( this.game.Data.RuleVar[475]);
              this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RoadType[index9] =  Math.Round( this.game.Data.RuleVar[475]);
              if (this.game.Data.MapObj[0].HexObj[index7, index6].RiverType[index8] > -1)
              {
                this.game.Data.MapObj[0].HexObj[index7, index6].Bridge[index8] = true;
                this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Bridge[index9] = true;
              }
            }
            index2 = x1;
          }
        }
      }
    }

    pub fn MakeRoads(x: i32, y: i32, roads: i32, bool secondroads, bool verysmall = false)
    {
      let mut movetype: i32 =  Math.Round( this.game.Data.RuleVar[99]);
      if ( this.game.Data.RuleVar[478] > 0.0)
        movetype =  Math.Round( this.game.Data.RuleVar[478]);
      if (verysmall)
        this.game.HandyFunctionsObj.MakeMovePrediction2(0, movetype, 0, 30, x, y, 0, false, false, muststartonairfield: false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true, NoBridgePenalty: true, BridgeAP: 10, MaxDistance: 4);
      else
        this.game.HandyFunctionsObj.MakeMovePrediction2(0, movetype, 0, roads * 250, x, y, 0, false, false, muststartonairfield: false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true, NoBridgePenalty: true, BridgeAP: 40, MaxDistance: 32);
      SimpleList simpleList = SimpleList::new();
      let mut MaxDistance: i32 = 9999;
      let mut num1: i32 = roads;
      if ( this.game.Data.RuleVar[474] == 1.0)
      {
        num1 = 99;
        MaxDistance = 15;
      }
      if (!secondroads)
      {
        num1 = roads;
        MaxDistance = 32;
      }
      let mut locCounter: i32 = this.game.Data.LocCounter;
      for (let mut index: i32 = 0; index <= locCounter; index += 1)
      {
        let mut x1: i32 = this.game.Data.LocObj[index].X;
        let mut y1: i32 = this.game.Data.LocObj[index].Y;
        if (!(x1 == x & y1 == y) && this.game.Data.MapObj[0].HexObj[x1, y1].VP > 0)
        {
          if (this.game.EditObj.TempValue[0].Value[x1, y1] < 600 & !secondroads)
            simpleList.Add(x1,  Math.Round( (VBMath.Rnd() *  this.game.EditObj.TempValue[0].Value[x1, y1])), x1, y1);
          if (this.game.EditObj.TempValue[0].Value[x1, y1] < 200 & secondroads)
            simpleList.Add(x1,  Math.Round( (VBMath.Rnd() *  this.game.EditObj.TempValue[0].Value[x1, y1])), x1, y1);
        }
      }
      if (simpleList.Counter <= -1)
        return;
      simpleList.Sort();
      let mut counter: i32 = simpleList.Counter;
      for (let mut index1: i32 = 0; index1 <= counter; index1 += 1)
      {
        if (index1 < num1)
        {
          if (!(index1 < roads & !secondroads) && index1 <= 10 & secondroads)
            this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.MapObj[0].HexObj[x, y].Regime, movetype, 0, roads * 350, simpleList.Data1[index1], simpleList.Data2[index1], 0, false, muststartonairfield: false, SeaBlock: true, BlockAllSea: true, NoBridgePenalty: true, overruleRoadType: 0, BridgeAP: 40, MaxDistance: MaxDistance);
          if (this.game.EditObj.TempValue[0].Value[x, y] < 9999 & secondroads | this.game.EditObj.TempValue[0].Value[simpleList.Data1[index1], simpleList.Data2[index1]] < 9999 & !secondroads)
          {
            let mut num2: i32 = 1;
            if (index1 >= roads)
            {
              if (secondroads)
              {
                let mut num3: i32 = this.game.EditObj.TempValue[0].Value[x, y];
                this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.MapObj[0].HexObj[x, y].Regime, movetype, 0, roads * 350, simpleList.Data1[index1], simpleList.Data2[index1], 0, false, SeaBlock: true, BlockAllSea: true, NoBridgePenalty: true, BridgeAP: 40, MaxDistance: MaxDistance);
                if (this.game.EditObj.TempValue[0].Value[x, y] < num3 + 18 | this.game.EditObj.TempValue[0].Value[x, y] > roads * 350)
                  num2 = 0;
                if (num2 == 1)
                  this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.MapObj[0].HexObj[x, y].Regime, movetype, 0, roads * 350, simpleList.Data1[index1], simpleList.Data2[index1], 0, false, SeaBlock: true, BlockAllSea: true, NoBridgePenalty: true, overruleRoadType: 0, BridgeAP: 40, MaxDistance: MaxDistance);
              }
              else
                num2 = 0;
            }
            Coordinate coordinate;
            if (num2 == 1)
            {
              if (secondroads)
              {
                let mut index2: i32 = x;
                y2: i32;
                for (let mut index3: i32 = y; !(index2 == simpleList.Data1[index1] & index3 == simpleList.Data2[index1]); index3 = y2)
                {
                  let mut tfacing1: i32 = -1;
                  let mut num4: i32 = 9999;
                  let mut tfacing2: i32 = 1;
                  do
                  {
                    coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index2, index3, 0, tfacing2);
                    if (coordinate.onmap && this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y] < num4)
                    {
                      num4 = this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y];
                      tfacing1 = tfacing2;
                    }
                    tfacing2 += 1;
                  }
                  while (tfacing2 <= 6);
                  coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index2, index3, 0, tfacing1);
                  let mut index4: i32 = tfacing1 - 1;
                  let mut index5: i32 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index2, index3, 0) - 1;
                  this.game.Data.MapObj[0].HexObj[index2, index3].RoadType[index4] =  Math.Round( this.game.Data.RuleVar[409]);
                  this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RoadType[index5] =  Math.Round( this.game.Data.RuleVar[409]);
                  if (this.game.Data.MapObj[0].HexObj[index2, index3].RiverType[index4] > -1)
                  {
                    this.game.Data.MapObj[0].HexObj[index2, index3].Bridge[index4] = true;
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Bridge[index5] = true;
                  }
                  let mut x2: i32 = coordinate.x;
                  y2 = coordinate.y;
                  if (this.domirror == 1)
                  {
                    let mut num5: i32 =  Math.Round(Conversion.Int( (this.game.Data.MapObj[0].MapWidth + 1) / 2.0));
                    let mut num6: i32 =  Math.Round(Conversion.Int( (this.game.Data.MapObj[0].MapHeight + 1) / 2.0));
                    let mut index6: i32 = index3 < num6 ? (index3 >= num6 ? num6 : this.game.Data.MapObj[0].MapHeight - index3) : this.game.Data.MapObj[0].MapHeight - index3;
                    let mut index7: i32 = index2 < num5 ? (index2 >= num5 ? num5 : this.game.Data.MapObj[0].MapWidth - index2) : this.game.Data.MapObj[0].MapWidth - index2;
                    let mut tfacing3: i32 = index4 + 1 + 3;
                    if (tfacing3 > 6)
                      tfacing3 -= 6;
                    coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index7, index6, 0, tfacing3);
                    let mut index8: i32 = tfacing3 - 1;
                    let mut index9: i32 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index7, index6, 0) - 1;
                    this.game.Data.MapObj[0].HexObj[index7, index6].RoadType[index8] =  Math.Round( this.game.Data.RuleVar[409]);
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RoadType[index9] =  Math.Round( this.game.Data.RuleVar[409]);
                    if (this.game.Data.MapObj[0].HexObj[index7, index6].RiverType[index8] > -1)
                    {
                      this.game.Data.MapObj[0].HexObj[index7, index6].Bridge[index8] = true;
                      this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Bridge[index9] = true;
                    }
                  }
                  index2 = x2;
                }
              }
              else
              {
                let mut index10: i32 = simpleList.Data1[index1];
                y3: i32;
                for (let mut index11: i32 = simpleList.Data2[index1]; !(index10 == x & index11 == y); index11 = y3)
                {
                  let mut tfacing4: i32 = -1;
                  let mut num7: i32 = 9999;
                  let mut tfacing5: i32 = 1;
                  do
                  {
                    coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index10, index11, 0, tfacing5);
                    if (coordinate.onmap && this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y] < num7)
                    {
                      num7 = this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y];
                      tfacing4 = tfacing5;
                    }
                    tfacing5 += 1;
                  }
                  while (tfacing5 <= 6);
                  coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index10, index11, 0, tfacing4);
                  let mut index12: i32 = tfacing4 - 1;
                  let mut index13: i32 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index10, index11, 0) - 1;
                  this.game.Data.MapObj[0].HexObj[index10, index11].RoadType[index12] =  Math.Round( this.game.Data.RuleVar[409]);
                  this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RoadType[index13] =  Math.Round( this.game.Data.RuleVar[409]);
                  if (this.game.Data.MapObj[0].HexObj[index10, index11].RiverType[index12] > -1)
                  {
                    this.game.Data.MapObj[0].HexObj[index10, index11].Bridge[index12] = true;
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Bridge[index13] = true;
                  }
                  let mut x3: i32 = coordinate.x;
                  y3 = coordinate.y;
                  if (this.domirror == 1)
                  {
                    let mut num8: i32 =  Math.Round(Conversion.Int( (this.game.Data.MapObj[0].MapWidth + 1) / 2.0));
                    let mut num9: i32 =  Math.Round(Conversion.Int( (this.game.Data.MapObj[0].MapHeight + 1) / 2.0));
                    let mut index14: i32 = index11 < num9 ? (index11 >= num9 ? num9 : this.game.Data.MapObj[0].MapHeight - index11) : this.game.Data.MapObj[0].MapHeight - index11;
                    let mut index15: i32 = index10 < num8 ? (index10 >= num8 ? num8 : this.game.Data.MapObj[0].MapWidth - index10) : this.game.Data.MapObj[0].MapWidth - index10;
                    let mut tfacing6: i32 = index12 + 1 + 3;
                    if (tfacing6 > 6)
                      tfacing6 -= 6;
                    coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index15, index14, 0, tfacing6);
                    let mut index16: i32 = tfacing6 - 1;
                    let mut index17: i32 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index15, index14, 0) - 1;
                    this.game.Data.MapObj[0].HexObj[index15, index14].RoadType[index16] =  Math.Round( this.game.Data.RuleVar[409]);
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RoadType[index17] =  Math.Round( this.game.Data.RuleVar[409]);
                    if (this.game.Data.MapObj[0].HexObj[index15, index14].RiverType[index16] > -1)
                    {
                      this.game.Data.MapObj[0].HexObj[index15, index14].Bridge[index16] = true;
                      this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Bridge[index17] = true;
                    }
                  }
                  index10 = x3;
                }
              }
            }
            this.game.HandyFunctionsObj.RedimTempValue(9999);
          }
        }
      }
    }

    pub fn PlaceRegimes(x: i32, y: i32, regmax: i32)
    {
      let mut num1: i32 = -1;
      if (this.doblockcenter == 1)
      {
        this.tempcount = 1;
        this.tempx[1] =  Math.Round(Conversion.Int( this.game.Data.MapObj[0].MapWidth / 2.0));
        this.tempy[1] =  Math.Round(Conversion.Int( this.game.Data.MapObj[0].MapHeight / 2.0));
      }
      let mut num2: i32 = regmax;
      for (let mut index1: i32 = 1; index1 <= num2; index1 += 1)
      {
        let mut num3: i32 = 0;
        let mut predef: i32 = 0;
        while (num3 == 0)
        {
          let mut num4: i32 = 0;
          let mut num5: i32 = 0;
          let mut num6: i32 = 0;
          let mut num7: i32 = 0;
          Coordinate coordinate;
          while (num7 < 1000)
          {
            let mut index2: i32 =  Math.Round( (Conversion.Int(VBMath.Rnd() *  (x - 5)) + 3f));
            let mut index3: i32 =  Math.Round( (Conversion.Int(VBMath.Rnd() *  (y - 5)) + 3f));
            num7 += 1;
            if (this.game.Data.MapObj[0].HexObj[index2, index3].LandscapeType == this.GRASS | this.game.Data.MapObj[0].HexObj[index2, index3].LandscapeType == this.LIGHTFOREST | predef > 10 && this.game.Data.MapObj[0].HexObj[index2, index3].Location == -1)
            {
              if (this.tempcount == 0)
              {
                num4 = index2;
                num5 = index3;
              }
              else
              {
                let mut num8: i32 = 999;
                let mut tempcount: i32 = this.tempcount;
                for (let mut index4: i32 = 0; index4 <= tempcount; index4 += 1)
                {
                  let mut num9: i32 = this.game.HandyFunctionsObj.Distance(index2, index3, 0, this.tempx[index4], this.tempy[index4], 0);
                  if (this.game.Data.MapObj[0].HexObj[this.tempx[index4], this.tempy[index4]].Regime > -1)
                    num9 =  Math.Round(Conversion.Int( num9 / 3.0));
                  if (num9 < num8)
                    num8 = num9;
                }
                if ( this.game.Data.RuleVar[481] > 0.0)
                {
                  if (this.game.Data.MapObj[0].HexObj[index2, index3].AreaCode[ Math.Round( this.game.Data.RuleVar[481])] == this.RegFavClimate[index1 - 1] & this.RegFavClimate[index1 - 1] > 0)
                  {
                    num8 *= 20;
                  }
                  else
                  {
                    if (this.game.Data.MapObj[0].HexObj[index2, index3].AreaCode[ Math.Round( this.game.Data.RuleVar[481])] == 99)
                      num8 = -1;
                    if (this.game.Data.MapObj[0].HexObj[index2, index3].AreaCode[ Math.Round( this.game.Data.RuleVar[481])] == 1)
                      num8 = -1;
                  }
                }
                let mut num10: i32 = 0;
                let mut tfacing: i32 = 1;
                do
                {
                  coordinate = this.game.HandyFunctionsObj.HexNeighbour(index2, index3, 0, tfacing);
                  if (coordinate.onmap && this.game.HandyFunctionsObj.IsHexHarbourOrSea(coordinate.x, coordinate.y, coordinate.map))
                    num10 += 1;
                  tfacing += 1;
                }
                while (tfacing <= 6);
                if (num10 >= 5)
                  num8 =  Math.Round( num8 / 40.0);
                if (num8 > num6)
                {
                  num6 = num8;
                  num4 = index2;
                  num5 = index3;
                }
              }
            }
          }
          let mut index5: i32 = num4;
          let mut index6: i32 = num5;
          predef += 1;
          num11: i32;
          if (this.domirror == 1)
          {
            if (num1 == -1)
            {
              let mut num12: i32 =  Math.Round(Conversion.Int( (this.game.Data.MapObj[0].MapWidth + 1) / 2.0));
              let mut num13: i32 =  Math.Round(Conversion.Int( (this.game.Data.MapObj[0].MapHeight + 1) / 2.0));
              let mut num14: i32 = index6 < num13 ? (index6 >= num13 ? num13 : this.game.Data.MapObj[0].MapHeight - index6) : this.game.Data.MapObj[0].MapHeight - index6;
              num1 = index5 < num12 ? (index5 >= num12 ? num12 : this.game.Data.MapObj[0].MapWidth - index5) : this.game.Data.MapObj[0].MapWidth - index5;
              num11 = num14;
            }
            else
            {
              index5 = num1;
              index6 = num11;
              num1 = -1;
              num11 = -2;
            }
          }
          if (predef > 10 | num11 == -2 & this.domirror == 1 | this.game.Data.MapObj[0].HexObj[index5, index6].LandscapeType == this.GRASS | this.game.Data.MapObj[0].HexObj[index5, index6].LandscapeType == this.LIGHTFOREST && this.game.Data.MapObj[0].HexObj[index5, index6].Location == -1)
          {
            this += 1.tempcount;
            this.tempx[this.tempcount] = index5;
            this.tempy[this.tempcount] = index6;
            this.game.Data.AddLoc(index5, index6, 0);
            let mut locCounter: i32 = this.game.Data.LocCounter;
            this.game.Data.LocObj[locCounter].People = 0;
            if ((this.Regid[index1 - 1] + 22) % 7 == 1)
            {
              this.game.Data.LocObj[locCounter].People =  Math.Round( this.game.Data.RuleVar[458]);
              this.game.Data.RegimeObj[index1 - 1].People =  Math.Round( this.game.Data.RuleVar[458]);
              if ( this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[index1 - 1].OfficerPool =  Math.Round( this.game.Data.RuleVar[422]);
            }
            else if ((this.Regid[index1 - 1] + 22) % 7 == 2)
            {
              this.game.Data.LocObj[locCounter].People =  Math.Round( this.game.Data.RuleVar[459]);
              this.game.Data.RegimeObj[index1 - 1].People =  Math.Round( this.game.Data.RuleVar[459]);
              if ( this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[index1 - 1].OfficerPool =  Math.Round( this.game.Data.RuleVar[427]);
            }
            else if ((this.Regid[index1 - 1] + 22) % 7 == 3)
            {
              this.game.Data.LocObj[locCounter].People =  Math.Round( this.game.Data.RuleVar[460]);
              this.game.Data.RegimeObj[index1 - 1].People =  Math.Round( this.game.Data.RuleVar[460]);
              if ( this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[index1 - 1].OfficerPool =  Math.Round( this.game.Data.RuleVar[432]);
            }
            else if ((this.Regid[index1 - 1] + 22) % 7 == 4)
            {
              this.game.Data.LocObj[locCounter].People =  Math.Round( this.game.Data.RuleVar[469]);
              this.game.Data.RegimeObj[index1 - 1].People =  Math.Round( this.game.Data.RuleVar[469]);
              if ( this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[index1 - 1].OfficerPool =  Math.Round( this.game.Data.RuleVar[466]);
            }
            else if ((this.Regid[index1 - 1] + 22) % 7 == 5)
            {
              this.game.Data.LocObj[locCounter].People =  Math.Round( this.game.Data.RuleVar[485]);
              this.game.Data.RegimeObj[index1 - 1].People =  Math.Round( this.game.Data.RuleVar[485]);
              if ( this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[index1 - 1].OfficerPool =  Math.Round( this.game.Data.RuleVar[482]);
            }
            else if ((this.Regid[index1 - 1] + 22) % 7 == 6)
            {
              this.game.Data.LocObj[locCounter].People =  Math.Round( this.game.Data.RuleVar[489]);
              this.game.Data.RegimeObj[index1 - 1].People =  Math.Round( this.game.Data.RuleVar[489]);
              if ( this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[index1 - 1].OfficerPool =  Math.Round( this.game.Data.RuleVar[486]);
            }
            else
            {
              this.game.Data.LocObj[locCounter].People =  Math.Round( this.game.Data.RuleVar[493]);
              this.game.Data.RegimeObj[index1 - 1].People =  Math.Round( this.game.Data.RuleVar[493]);
              if ( this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[index1 - 1].OfficerPool =  Math.Round( this.game.Data.RuleVar[490]);
            }
            this.game.Data.LocObj[locCounter].Name = "temp";
            let mut index7: i32 =  Math.Round( this.game.Data.RuleVar[410]);
            this.game.Data.LocObj[locCounter].Type = index7;
            if (this.game.Data.LocTypeObj[index7].AutoProd > -1)
            {
              this.game.Data.LocObj[locCounter].ProdPercent[0] = 100;
              this.game.Data.LocObj[locCounter].Production[0] = this.game.Data.LocTypeObj[index7].AutoProd;
            }
            this.TownSize[locCounter] = 3;
            this.TownCapitol[locCounter] = true;
            this.game.Data.MapObj[0].HexObj[index5, index6].VP = 4;
            this.totvp += 4;
            this.game.Data.LocObj[locCounter].StructuralPts = this.game.Data.LocTypeObj[index7].StructuralPts;
            this.game.Data.MapObj[0].HexObj[index5, index6].Location = locCounter;
            if (this.game.Data.LocTypeObj[index7].OverdrawLTNr > -1)
            {
              this.game.Data.MapObj[0].HexObj[index5, index6].LandscapeType = this.game.Data.LocTypeObj[index7].OverdrawLTNr;
              this.game.Data.MapObj[0].HexObj[index5, index6].SpriteNr = this.game.Data.LocTypeObj[index7].OverdrawSpriteNr;
            }
            this.game.Data.MapObj[0].HexObj[index5, index6].Regime = index1 - 1;
            let mut unr: i32 = this.game.Data.AddUnit(index5, index6, 0);
            this.game.Data.UnitObj[unr].Name = "Supreme HQ";
            if ( this.game.Data.RuleVar[343] == 1.0)
            {
              this.game.Data.AddHistoricalUnit();
              this.game.Data.UnitObj[unr].Historical = this.game.Data.HistoricalUnitCounter;
              this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].TempRegime = index1 - 1;
              this.game.ProcessingObj.RecruitOfficer(index1 - 1, false, this.game.Data.HistoricalUnitCounter);
            }
            this.game.Data.UnitObj[unr].Regime = index1 - 1;
            this.game.Data.UnitObj[unr].Supply = 500;
            this.game.Data.UnitObj[unr].SOSupReqPercent = 100;
            this.game.Data.UnitObj[unr].IsHQ = true;
            this.game.Data.LocObj[locCounter].HQ = unr;
            let mut index8: i32 = this.game.Data.AddSF(unr);
            this.game.Data.SFObj[index8].Type =  Math.Round( this.game.Data.RuleVar[411]);
            this.game.Data.SFObj[index8].Qty =  Math.Round( this.game.Data.RuleVar[412]);
            this.game.Data.SFObj[index8].Rdn = 100;
            this.game.Data.SFObj[index8].People = this.game.Data.RegimeObj[index1 - 1].People;
            this.game.Data.SFObj[index8].Xp = 25;
            this.game.Data.SFObj[index8].Mor = 50;
            if ( this.game.Data.RuleVar[476] > 0.0)
            {
              let mut index9: i32 = this.game.Data.AddSF(unr);
              this.game.Data.SFObj[index9].Type =  Math.Round( this.game.Data.RuleVar[476]);
              this.game.Data.SFObj[index9].Qty =  Math.Round( this.game.Data.RuleVar[477]);
              this.game.Data.SFObj[index9].Rdn = 100;
              this.game.Data.SFObj[index9].People = 0;
              this.game.Data.SFObj[index9].Xp = 25;
              this.game.Data.SFObj[index9].Mor = 50;
            }
            num3 = 1;
            let mut num15: i32 = 0;
            do
            {
              if ( this.game.Data.RuleVar[453 + num15] > 0.0)
              {
                predef =  Math.Round( this.game.Data.RuleVar[453 + num15]);
                this.game.EventRelatedObj.ExecAddUnit(predef, index5, index6, index1 - 1, "");
              }
              num15 += 1;
            }
            while (num15 <= 3);
            let mut tfacing: i32 = 1;
            do
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index5, index6, 0, tfacing);
              if (coordinate.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime = index1 - 1;
              tfacing += 1;
            }
            while (tfacing <= 6);
          }
        }
      }
    }

    pub fn PlaceRegimes2()
    {
      if ( this.game.Data.RuleVar[461] != 1.0)
        return;
      SimpleList[] simpleListArray = new SimpleList[this.game.Data.RegimeCounter + 1];
      int[] numArray1 = new int[this.game.Data.RegimeCounter + 1];
      bool[] flagArray = new bool[this.game.Data.LocCounter + 1];
      let mut num1: i32 = 1;
      let mut regimeCounter: i32 = this.game.Data.RegimeCounter;
      if ( this.game.Data.RuleVar[496] > 0.0)
        --regimeCounter;
      while (num1 == 1)
      {
        num1 = 0;
        let mut num2: i32 = regimeCounter;
        for (let mut index1: i32 = 0; index1 <= num2; index1 += 1)
        {
          simpleListArray[index1] = SimpleList::new();
          let mut locCounter1: i32 = this.game.Data.LocCounter;
          for (let mut tid: i32 = 0; tid <= locCounter1; tid += 1)
          {
            if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[tid].X, this.game.Data.LocObj[tid].Y].Regime == -1)
            {
              let mut tweight: i32 = 9999;
              let mut num3: i32 = -1;
              let mut locCounter2: i32 = this.game.Data.LocCounter;
              for (let mut index2: i32 = 0; index2 <= locCounter2; index2 += 1)
              {
                if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index2].X, this.game.Data.LocObj[index2].Y].Regime == index1)
                {
                  let mut num4: i32 = this.game.HandyFunctionsObj.Distance(this.game.Data.LocObj[tid].X, this.game.Data.LocObj[tid].Y, 0, this.game.Data.LocObj[index2].X, this.game.Data.LocObj[index2].Y, 0, 999);
                  if (num4 < tweight)
                  {
                    tweight = num4;
                    num3 = index2;
                  }
                }
              }
              if (num3 > -1)
                simpleListArray[index1].Add(tid, tweight);
            }
          }
        }
        let mut num5: i32 = 0;
        let mut num6: i32 = regimeCounter - 1;
        for (let mut index: i32 = 0; index <= num6; index += 1)
        {
          if (numArray1[index] != numArray1[index + 1])
            num5 = 1;
        }
        num7: i32;
        if (num5 == 0)
          num7 += 1;
        let mut num8: i32 = 0;
        let mut num9: i32 = regimeCounter;
        for (let mut index3: i32 = 0; index3 <= num9; index3 += 1)
        {
          if (simpleListArray[index3].Counter > -1 & numArray1[index3] < num7)
          {
            simpleListArray[index3].Sort();
            let mut counter: i32 = simpleListArray[index3].Counter;
            for (let mut index4: i32 = 0; index4 <= counter; index4 += 1)
            {
              let mut tid: i32 = simpleListArray[index3].Id[index4];
              if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[tid].X, this.game.Data.LocObj[tid].Y].Regime == -1 & !flagArray[tid])
              {
                this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[tid].X, this.game.Data.LocObj[tid].Y].Regime = index3;
                num1 = 1;
                flagArray[tid] = true;
                int[] numArray2 = numArray1;
                int[] numArray3 = numArray2;
                let mut index5: i32 = index3;
                let mut index6: i32 = index5;
                let mut num10: i32 = numArray2[index5] + this.game.Data.LocTypeObj[this.game.Data.LocObj[tid].Type].MaxProd;
                numArray3[index6] = num10;
                if ((this.Regid[index3] + 22) % 7 == 1)
                  this.game.Data.LocObj[tid].People =  Math.Round( this.game.Data.RuleVar[458]);
                else if ((this.Regid[index3] + 22) % 7 == 2)
                  this.game.Data.LocObj[tid].People =  Math.Round( this.game.Data.RuleVar[459]);
                else if ((this.Regid[index3] + 22) % 7 == 3)
                  this.game.Data.LocObj[tid].People =  Math.Round( this.game.Data.RuleVar[460]);
                else if ((this.Regid[index3] + 22) % 7 == 4)
                  this.game.Data.LocObj[tid].People =  Math.Round( this.game.Data.RuleVar[469]);
                else if ((this.Regid[index3] + 22) % 7 == 5)
                  this.game.Data.LocObj[tid].People =  Math.Round( this.game.Data.RuleVar[485]);
                else if ((this.Regid[index3] + 22) % 7 == 6)
                  this.game.Data.LocObj[tid].People =  Math.Round( this.game.Data.RuleVar[489]);
                else
                  this.game.Data.LocObj[tid].People =  Math.Round( this.game.Data.RuleVar[493]);
                if (numArray1[index3] > num7)
                  num7 = numArray1[index3];
                let mut num11: i32 = regimeCounter;
                for (let mut index7: i32 = 0; index7 <= num11; index7 += 1)
                  simpleListArray[index7].Remove(tid);
                num8 = 1;
                break;
              }
            }
          }
        }
      }
      this.town = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.town2 = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      let mut mapWidth1: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut index8: i32 = 0; index8 <= mapWidth1; index8 += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut index9: i32 = 0; index9 <= mapHeight; index9 += 1)
        {
          this.town2[index8, index9] =  0;
          this.town[index8, index9] =  -1;
          if (this.game.Data.MapObj[0].HexObj[index8, index9].Regime > -1)
          {
            this.town[index8, index9] =  this.game.Data.MapObj[0].HexObj[index8, index9].Regime;
            this.town2[index8, index9] =  1;
          }
        }
      }
      let mut Right: i32 = 0;
      let mut num12: i32 = 10;
      while (num12 > 0)
      {
        Right += 1;
        --num12;
        let mut mapWidth2: i32 = this.game.Data.MapObj[0].MapWidth;
        for (let mut cx: i32 = 0; cx <= mapWidth2; cx += 1)
        {
          let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
          for (let mut cy: i32 = 0; cy <= mapHeight; cy += 1)
          {
            if (Operators.ConditionalCompareObjectEqual(this.town2[cx, cy],  Right, false))
            {
              let mut tfacing: i32 = 1;
              do
              {
                Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap && Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(this.town[coordinate.x, coordinate.y],  -1, false), Operators.CompareObjectEqual(this.town[coordinate.x, coordinate.y], this.town[cx, cy], false))))
                {
                  if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                  {
                    if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectLess( (Right + 6), this.town2[coordinate.x, coordinate.y], false), Operators.CompareObjectEqual(this.town2[coordinate.x, coordinate.y],  0, false))))
                    {
                      this.town2[coordinate.x, coordinate.y] =  (Right + 6);
                      this.town[coordinate.x, coordinate.y] = RuntimeHelpers.GetObjectValue(this.town[cx, cy]);
                      num12 = 10;
                    }
                  }
                  else if (this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[tfacing - 1] > -1)
                  {
                    if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectLess( (Right + 3), this.town2[coordinate.x, coordinate.y], false), Operators.CompareObjectEqual(this.town2[coordinate.x, coordinate.y],  0, false))))
                    {
                      this.town2[coordinate.x, coordinate.y] =  (Right + 3);
                      this.town[coordinate.x, coordinate.y] = RuntimeHelpers.GetObjectValue(this.town[cx, cy]);
                      num12 = 10;
                    }
                  }
                  else if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectLess( (Right + 1), this.town2[coordinate.x, coordinate.y], false), Operators.CompareObjectEqual(this.town2[coordinate.x, coordinate.y],  0, false))))
                  {
                    this.town2[coordinate.x, coordinate.y] =  (Right + 1);
                    this.town[coordinate.x, coordinate.y] = RuntimeHelpers.GetObjectValue(this.town[cx, cy]);
                    num12 = 10;
                  }
                }
                tfacing += 1;
              }
              while (tfacing <= 6);
            }
          }
        }
      }
      let mut mapWidth3: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut index10: i32 = 0; index10 <= mapWidth3; index10 += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut index11: i32 = 0; index11 <= mapHeight; index11 += 1)
        {
          if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index10, index11].LandscapeType].IsSea)
            this.game.Data.MapObj[0].HexObj[index10, index11].Regime = Conversions.ToInteger(this.town[index10, index11]);
        }
      }
    }

    pub fn PlaceRegimes3()
    {
      let mut mapWidth1: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut x: i32 = 0; x <= mapWidth1; x += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut y: i32 = 0; y <= mapHeight; y += 1)
        {
          if (this.game.Data.MapObj[0].HexObj[x, y].Location > -1 | this.game.Data.MapObj[0].HexObj[x, y].LandscapeType == this.LIGHTURBAN)
          {
            if ( this.game.Data.RuleVar[463] > 0.0)
              this.game.Data.MapObj[0].HexObj[x, y].AreaCode[ Math.Round( this.game.Data.RuleVar[463])] = -1;
            if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[x, y].LandscapeType].IsSea)
            {
              let mut regnr: i32 = this.game.Data.MapObj[0].HexObj[x, y].Regime;
              if ( this.game.Data.RuleVar[461] == 1.0 && regnr == -1)
                regnr = Conversions.ToInteger(this.town[x, y]);
              if ( this.game.Data.RuleVar[463] > 0.0 & regnr > -1)
              {
                if ((this.Regid[regnr] + 22) % 7 == 1)
                  this.game.Data.MapObj[0].HexObj[x, y].AreaCode[ Math.Round( this.game.Data.RuleVar[463])] =  Math.Round( this.game.Data.RuleVar[458]);
                else if ((this.Regid[regnr] + 22) % 7 == 2)
                  this.game.Data.MapObj[0].HexObj[x, y].AreaCode[ Math.Round( this.game.Data.RuleVar[463])] =  Math.Round( this.game.Data.RuleVar[459]);
                else if ((this.Regid[regnr] + 22) % 7 == 3)
                  this.game.Data.MapObj[0].HexObj[x, y].AreaCode[ Math.Round( this.game.Data.RuleVar[463])] =  Math.Round( this.game.Data.RuleVar[460]);
                else if ((this.Regid[regnr] + 22) % 7 == 4)
                  this.game.Data.MapObj[0].HexObj[x, y].AreaCode[ Math.Round( this.game.Data.RuleVar[463])] =  Math.Round( this.game.Data.RuleVar[469]);
                else if ((this.Regid[regnr] + 22) % 7 == 5)
                  this.game.Data.MapObj[0].HexObj[x, y].AreaCode[ Math.Round( this.game.Data.RuleVar[463])] =  Math.Round( this.game.Data.RuleVar[485]);
                else if ((this.Regid[regnr] + 22) % 7 == 6)
                  this.game.Data.MapObj[0].HexObj[x, y].AreaCode[ Math.Round( this.game.Data.RuleVar[463])] =  Math.Round( this.game.Data.RuleVar[489]);
                else
                  this.game.Data.MapObj[0].HexObj[x, y].AreaCode[ Math.Round( this.game.Data.RuleVar[463])] =  Math.Round( this.game.Data.RuleVar[493]);
              }
              let mut location: i32 = this.game.Data.MapObj[0].HexObj[x, y].Location;
              if (location > -1 & regnr > -1)
              {
                if ((this.Regid[regnr] + 22) % 7 == 1 & this.game.Data.RegimeCounter == regnr &  this.game.Data.RuleVar[496] >= 1.0)
                  this.game.Data.LocObj[location].People =  Math.Round( this.game.Data.RuleVar[497]);
                else if ((this.Regid[regnr] + 22) % 7 == 1)
                  this.game.Data.LocObj[location].People =  Math.Round( this.game.Data.RuleVar[458]);
                else if ((this.Regid[regnr] + 22) % 7 == 2)
                  this.game.Data.LocObj[location].People =  Math.Round( this.game.Data.RuleVar[459]);
                else if ((this.Regid[regnr] + 22) % 7 == 3)
                  this.game.Data.LocObj[location].People =  Math.Round( this.game.Data.RuleVar[460]);
                else if ((this.Regid[regnr] + 22) % 7 == 4)
                  this.game.Data.LocObj[location].People =  Math.Round( this.game.Data.RuleVar[469]);
                else if ((this.Regid[regnr] + 22) % 7 == 5)
                  this.game.Data.LocObj[location].People =  Math.Round( this.game.Data.RuleVar[485]);
                else if ((this.Regid[regnr] + 22) % 7 == 6)
                  this.game.Data.LocObj[location].People =  Math.Round( this.game.Data.RuleVar[489]);
                else
                  this.game.Data.LocObj[location].People =  Math.Round( this.game.Data.RuleVar[493]);
              }
              if (location > -1)
                this.game.Data.LocObj[location].Name = this.GetRandomName(this.TownSize[location], this.game.Data.LocObj[location].People, this.TownCapitol[location]);
              if (location > -1 & regnr > -1 && this.dosinglestart == 0 && this.game.Data.MapObj[0].HexObj[x, y].Regime > -1 &  this.game.Data.RuleVar[462] > 0.0)
              {
                this.game.EventRelatedObj.ExecAddUnit( Math.Round( this.game.Data.RuleVar[462]), x, y, this.game.Data.MapObj[0].HexObj[x, y].Regime, this.game.Data.LocObj[location].Name + " Garrison");
                if ( this.game.Data.RuleVar[470] > 0.0)
                  this.game.EventRelatedObj.ExecAddUnit( Math.Round( this.game.Data.RuleVar[470]), x, y, this.game.Data.MapObj[0].HexObj[x, y].Regime, this.game.Data.LocObj[location].Name + " Garrison");
                if ( this.game.Data.RuleVar[471] > 0.0)
                  this.game.EventRelatedObj.ExecAddUnit( Math.Round( this.game.Data.RuleVar[471]), x, y, this.game.Data.MapObj[0].HexObj[x, y].Regime, this.game.Data.LocObj[location].Name + " Garrison");
                if ( this.game.Data.RuleVar[472] > 0.0)
                  this.game.EventRelatedObj.ExecAddUnit( Math.Round( this.game.Data.RuleVar[472]), x, y, this.game.Data.MapObj[0].HexObj[x, y].Regime, this.game.Data.LocObj[location].Name + " Garrison");
                this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.MapObj[0].HexObj[x, y].Regime,  Math.Round( this.game.Data.RuleVar[99]), 99,  Math.Round( this.game.Data.RuleVar[3]), x, y, 0);
                let mut num1: i32 = -1;
                let mut num2: i32 = 9999;
                let mut unitCounter: i32 = this.game.Data.UnitCounter;
                for (let mut index: i32 = 0; index <= unitCounter; index += 1)
                {
                  if (this.game.Data.UnitObj[index].IsHQ & this.game.Data.UnitObj[index].PreDef == -1 & this.game.Data.UnitObj[index].Regime == regnr &&  this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y] <=  this.game.Data.RuleVar[51] && this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y] < num2)
                  {
                    num2 = this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y];
                    num1 = index;
                  }
                }
                let mut hq: i32 = this.game.Data.UnitObj[this.game.Data.UnitCounter].HQ;
                if (num1 == -1)
                {
                  let mut unr: i32 = this.game.Data.AddUnit(x, y, 0);
                  this.game.Data.UnitObj[unr].Name = this.game.Data.LocObj[location].Name + " HQ";
                  if ( this.game.Data.RuleVar[343] == 1.0)
                  {
                    this.game.Data.AddHistoricalUnit();
                    this.game.Data.UnitObj[unr].Historical = this.game.Data.HistoricalUnitCounter;
                    this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].TempRegime = regnr - 1;
                    this.game.ProcessingObj.RecruitOfficer(regnr, false, this.game.Data.HistoricalUnitCounter);
                  }
                  this.game.Data.UnitObj[unr].Regime = regnr;
                  this.game.Data.UnitObj[unr].Supply = 50;
                  this.game.Data.UnitObj[unr].SOSupReqPercent = 100;
                  this.game.Data.UnitObj[unr].IsHQ = true;
                  this.game.Data.UnitObj[unr].HQ = hq;
                  this.game.Data.LocObj[location].HQ = unr;
                  let mut index: i32 = this.game.Data.AddSF(unr);
                  this.game.Data.SFObj[index].Type =  Math.Round( this.game.Data.RuleVar[411]);
                  this.game.Data.SFObj[index].Qty =  Math.Round( this.game.Data.RuleVar[412]);
                  this.game.Data.SFObj[index].Rdn = 100;
                  this.game.Data.SFObj[index].People = this.game.Data.RegimeObj[regnr].People;
                  this.game.Data.SFObj[index].Xp = 25;
                  this.game.Data.SFObj[index].Mor = 50;
                }
                else
                  this.game.Data.LocObj[location].HQ = num1;
              }
            }
          }
        }
      }
      if (this.dosinglestart == 0)
      {
        let mut unitCounter1: i32 = this.game.Data.UnitCounter;
        for (let mut hq1: i32 = 0; hq1 <= unitCounter1; hq1 += 1)
        {
          if (this.game.Data.UnitObj[hq1].PreDef == -1)
          {
            let mut x: i32 = this.game.Data.UnitObj[hq1].X;
            let mut y: i32 = this.game.Data.UnitObj[hq1].Y;
            let mut hq2: i32 = this.game.Data.UnitObj[hq1].HQ;
            let mut sfCount: i32 = this.game.Data.UnitObj[hq1].SFCount;
            for (let mut index: i32 = 0; index <= sfCount; index += 1)
              this.game.Data.SFObj[this.game.Data.UnitObj[hq1].SFList[index]].People = this.game.Data.RegimeObj[this.game.Data.UnitObj[hq1].Regime].People;
            if (hq2 > -1)
            {
              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.MapObj[0].HexObj[x, y].Regime,  Math.Round( this.game.Data.RuleVar[0]), 99,  Math.Round( this.game.Data.RuleVar[3]), x, y, 0);
              let mut unitCounter2: i32 = this.game.Data.UnitCounter;
              for (let mut unr: i32 = 0; unr <= unitCounter2; unr += 1)
              {
                if (unr != hq1 && !this.game.HandyFunctionsObj.IsUnitInHQChain(unr, hq1) &  this.game.HandyFunctionsObj.HowmanyHQsAbove(unr) <  this.game.Data.RuleVar[304] && this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].Regime == this.game.Data.UnitObj[hq1].Regime && this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[hq2].X, this.game.Data.UnitObj[hq2].Y] > this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y])
                  this.game.Data.UnitObj[hq1].HQ = unr;
              }
            }
          }
        }
        let mut unitCounter3: i32 = this.game.Data.UnitCounter;
        for (let mut unr: i32 = 0; unr <= unitCounter3; unr += 1)
        {
          if (this.game.Data.UnitObj[unr].PreDef == -1 && !this.game.Data.UnitObj[unr].IsHQ && this.game.Data.UnitObj[unr].HQ > -1)
          {
            UnitClass[] unitObj = this.game.Data.UnitObj;
            UnitClass[] unitClassArray = unitObj;
            let mut hq: i32 = this.game.Data.UnitObj[unr].HQ;
            let mut index: i32 = hq;
            unitClassArray[index].Supply = unitObj[hq].Supply + this.game.HandyFunctionsObj.UnitSupplyUse(unr) * 2;
          }
        }
      }
      if (this.dosinglestart != 1)
        return;
      let mut mapWidth2: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut index1: i32 = 0; index1 <= mapWidth2; index1 += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut index2: i32 = 0; index2 <= mapHeight; index2 += 1)
        {
          if (this.game.Data.MapObj[0].HexObj[index1, index2].Location > -1)
          {
            if (!this.TownCapitol[this.game.Data.MapObj[0].HexObj[index1, index2].Location])
              this.game.Data.MapObj[0].HexObj[index1, index2].Regime = -1;
          }
          else
            this.game.Data.MapObj[0].HexObj[index1, index2].Regime = -1;
        }
      }
    }

    pub fn OptimizeForAI()
    {
      let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut index1: i32 = 0; index1 <= mapWidth; index1 += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut index2: i32 = 0; index2 <= mapHeight; index2 += 1)
        {
          if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType].IsSea && this.game.Data.MapObj[0].HexObj[index1, index2].Location == -1)
          {
            let mut num1: i32 = 0;
            let mut num2: i32 = index1 - 6;
            let mut num3: i32 = index1 + 6;
            for (let mut x2: i32 = num2; x2 <= num3; x2 += 1)
            {
              let mut num4: i32 = index2 - 6;
              let mut num5: i32 = index2 + 6;
              for (let mut y2: i32 = num4; y2 <= num5; y2 += 1)
              {
                if (x2 >= 0 & y2 >= 0 & x2 <= this.game.Data.MapObj[0].MapWidth & y2 <= this.game.Data.MapObj[0].MapHeight && this.game.Data.MapObj[0].HexObj[x2, y2].Location > -1 && this.game.HandyFunctionsObj.Distance(index1, index2, 0, x2, y2, 0) <= 4 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType].IsSea)
                  num1 += 1;
              }
            }
            if (num1 == 0)
            {
              this.game.Data.AddLoc(index1, index2, 0);
              this.game.Data.LocObj[this.game.Data.LocCounter].Name = this.GetRandomName(1, -1);
              this.game.Data.LocObj[this.game.Data.LocCounter].Type =  Math.Round( this.game.Data.RuleVar[413]);
              if (this.game.Data.LocTypeObj[ Math.Round( this.game.Data.RuleVar[413])].AutoProd > -1)
              {
                this.game.Data.LocObj[this.game.Data.LocCounter].ProdPercent[0] = 100;
                this.game.Data.LocObj[this.game.Data.LocCounter].Production[0] = this.game.Data.LocTypeObj[ Math.Round( this.game.Data.RuleVar[413])].AutoProd;
              }
              this.game.Data.MapObj[0].HexObj[index1, index2].VP = 1;
              this += 1.totvp;
              this.game.Data.LocObj[this.game.Data.LocCounter].People = 0;
              this.game.Data.LocObj[this.game.Data.LocCounter].StructuralPts = this.game.Data.LocTypeObj[ Math.Round( this.game.Data.RuleVar[413])].StructuralPts;
              this.game.Data.MapObj[0].HexObj[index1, index2].Location = this.game.Data.LocCounter;
              this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType = this.game.Data.LocTypeObj[ Math.Round( this.game.Data.RuleVar[413])].OverdrawLTNr;
              this.game.Data.MapObj[0].HexObj[index1, index2].SpriteNr = this.game.Data.LocTypeObj[ Math.Round( this.game.Data.RuleVar[413])].OverdrawSpriteNr;
            }
          }
        }
      }
    }

    pub fn PlaceTowns(x: i32, y: i32, let mut overrule: i32 = -1)
    {
      if ( this.game.Data.RuleVar[413] == -1.0 ||  this.game.Data.RuleVar[414] == -1.0 ||  this.game.Data.RuleVar[415] == -1.0 ||  this.game.Data.RuleVar[416] == -1.0)
        return;
      this.tempcount = 0;
      let mut num1: i32 = -1;
      let mut num2: i32 = 100;
      if ( this.game.Data.RuleVar[479] == 1.0)
        num2 =  Math.Round( this.game.Data.RuleVar[479]);
      this.opt8v += this.game.Data.RegimeCounter + 1 - this.opt8v % (this.game.Data.RegimeCounter + 1);
      let mut opt8v: i32 = this.opt8v;
      for (let mut index1: i32 = 1; index1 <= opt8v; index1 += 1)
      {
        let mut num3: i32 = 0;
        while (num3 == 0)
        {
          let mut num4: i32 = 0;
          let mut num5: i32 = 0;
          let mut num6: i32 = 0;
          let mut num7: i32 = 0;
          while (num7 < num2 | num6 <= 2)
          {
            let mut index2: i32 =  Math.Round( (Conversion.Int(VBMath.Rnd() *  (x - 3)) + 2f));
            let mut index3: i32 =  Math.Round( (Conversion.Int(VBMath.Rnd() *  (y - 3)) + 2f));
            let mut num8: i32 = 0;
            let mut tfacing1: i32 = 1;
            Coordinate coordinate;
            do
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbour(index2, index3, 0, tfacing1);
              if (coordinate.onmap && this.game.HandyFunctionsObj.IsHexHarbourOrSea(coordinate.x, coordinate.y, coordinate.map))
                num8 += 1;
              tfacing1 += 1;
            }
            while (tfacing1 <= 6);
            if (num8 >= 5)
              index2 = -1;
            if ( this.game.Data.RuleVar[481] > 0.0 & index2 > -1)
            {
              if (this.game.Data.MapObj[0].HexObj[index2, index3].AreaCode[ Math.Round( this.game.Data.RuleVar[481])] == 99 &  VBMath.Rnd() < 0.95)
                index2 = -1;
              else if (!(this.Sclimate == 2 | this.Sclimate == 3) & this.game.Data.MapObj[0].HexObj[index2, index3].AreaCode[ Math.Round( this.game.Data.RuleVar[481])] == 1 &  VBMath.Rnd() < 0.8)
                index2 = -1;
              else if (!(this.Sclimate == 2 | this.Sclimate == 3) & this.game.Data.MapObj[0].HexObj[index2, index3].AreaCode[ Math.Round( this.game.Data.RuleVar[481])] == 4 &  VBMath.Rnd() < 0.5)
                index2 = -1;
            }
            if (index2 > -1 && (this.game.Data.MapObj[0].HexObj[index2, index3].LandscapeType == this.GRASS | this.game.Data.MapObj[0].HexObj[index2, index3].LandscapeType == this.LIGHTFOREST) & this.game.Data.MapObj[0].HexObj[index2, index3].Location == -1)
            {
              num7 += 1;
              if (this.tempcount == 0)
              {
                num4 = index2;
                num5 = index3;
                num6 = 99;
              }
              else
              {
                let mut num9: i32 = 99;
                let mut tempcount: i32 = this.tempcount;
                for (let mut index4: i32 = 0; index4 <= tempcount; index4 += 1)
                {
                  let mut num10: i32 = this.game.HandyFunctionsObj.Distance(index2, index3, 0, this.tempx[index4], this.tempy[index4], 0);
                  if (num10 < num9)
                    num9 = num10;
                }
                if (Operators.CompareString(this.domasterfile, "OFFICIAL LADDER/Ladder.ptmaster", false) == 0)
                {
                  let mut tfacing2: i32 = 1;
                  do
                  {
                    coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index2, index3, 0, tfacing2);
                    if (coordinate.onmap && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime != this.game.Data.MapObj[0].HexObj[index2, index3].Regime && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime != -1)
                      num9 = 1;
                    tfacing2 += 1;
                  }
                  while (tfacing2 <= 6);
                }
                if (num9 > num6)
                {
                  num6 = num9;
                  num4 = index2;
                  num5 = index3;
                }
              }
            }
          }
          let mut x1: i32 = num4;
          let mut y1: i32 = num5;
          num11: i32;
          if (this.domirror == 1)
          {
            if (num1 == -1)
            {
              let mut num12: i32 =  Math.Round(Conversion.Int( (this.game.Data.MapObj[0].MapWidth + 1) / 2.0));
              let mut num13: i32 =  Math.Round(Conversion.Int( (this.game.Data.MapObj[0].MapHeight + 1) / 2.0));
              let mut num14: i32 = y1 < num13 ? (y1 >= num13 ? num13 : this.game.Data.MapObj[0].MapHeight - y1) : this.game.Data.MapObj[0].MapHeight - y1;
              num1 = x1 < num12 ? (x1 >= num12 ? num12 : this.game.Data.MapObj[0].MapWidth - x1) : this.game.Data.MapObj[0].MapWidth - x1;
              num11 = num14;
            }
            else
            {
              x1 = num1;
              y1 = num11;
              num1 = -1;
              num11 = -1;
            }
          }
          if (this.game.Data.MapObj[0].HexObj[x1, y1].LandscapeType == this.GRASS | this.game.Data.MapObj[0].HexObj[x1, y1].LandscapeType == this.LIGHTFOREST && this.game.Data.MapObj[0].HexObj[x1, y1].Location == -1)
          {
            this += 1.tempcount;
            this.tempx[this.tempcount] = x1;
            this.tempy[this.tempcount] = y1;
            this.game.Data.AddLoc(x1, y1, 0);
            float num15;
            float num16;
            float num17;
            float num18;
            if (this.opt10v == 1)
            {
              num15 = 0.75f;
              num16 = 0.8f;
              num17 = 1f;
              num18 = 2f;
            }
            if (this.opt10v == 2)
            {
              num15 = 0.66f;
              num16 = 0.66f;
              num17 = 2f;
              num18 = 2f;
            }
            if (this.opt10v == 3)
            {
              num15 = 0.25f;
              num16 = 0.5f;
              num17 = 0.5f;
              num18 = 1f;
            }
            if (this.opt10v == 4)
            {
              num15 = 0.0f;
              num16 = 0.4f;
              num17 = 0.4f;
              num18 = 1f;
            }
            float num19 = VBMath.Rnd();
            float num20 = VBMath.Rnd();
            float num21 = VBMath.Rnd();
            float num22 = VBMath.Rnd();
            index5: i32;
            if ( num19 <=  num15)
            {
              index5 =  Math.Round( this.game.Data.RuleVar[413]);
              this.TownSize[this.game.Data.LocCounter] = 0;
              this.game.Data.LocObj[this.game.Data.LocCounter].Name = "";
            }
            else if ( num20 <=  num16)
            {
              this.TownSize[this.game.Data.LocCounter] = 1;
              index5 =  Math.Round( this.game.Data.RuleVar[414]);
              this.game.Data.LocObj[this.game.Data.LocCounter].Name = "";
            }
            else if ( num21 <=  num17)
            {
              this.TownSize[this.game.Data.LocCounter] = 2;
              index5 =  Math.Round( this.game.Data.RuleVar[415]);
              this.game.Data.LocObj[this.game.Data.LocCounter].Name = "";
            }
            else if ( num22 <=  num18)
            {
              this.TownSize[this.game.Data.LocCounter] = 3;
              index5 =  Math.Round( this.game.Data.RuleVar[416]);
              this.game.Data.LocObj[this.game.Data.LocCounter].Name = "";
            }
            if (overrule > -1)
              index5 = overrule;
            num23: i32;
            if (num1 == -1 & this.domirror == 1)
              index5 = num23;
            else
              num23 = index5;
            this.game.Data.LocObj[this.game.Data.LocCounter].Type = index5;
            if (this.game.Data.LocTypeObj[index5].AutoProd > -1)
            {
              this.game.Data.LocObj[this.game.Data.LocCounter].ProdPercent[0] = 100;
              this.game.Data.LocObj[this.game.Data.LocCounter].Production[0] = this.game.Data.LocTypeObj[index5].AutoProd;
            }
            this.game.Data.MapObj[0].HexObj[x1, y1].VP = 1;
            this += 1.totvp;
            this.game.Data.LocObj[this.game.Data.LocCounter].People = 0;
            this.game.Data.LocObj[this.game.Data.LocCounter].StructuralPts = this.game.Data.LocTypeObj[index5].StructuralPts;
            this.game.Data.MapObj[0].HexObj[x1, y1].Location = this.game.Data.LocCounter;
            if (this.game.Data.LocTypeObj[index5].OverdrawLTNr > -1)
            {
              this.game.Data.MapObj[0].HexObj[x1, y1].LandscapeType = this.game.Data.LocTypeObj[index5].OverdrawLTNr;
              this.game.Data.MapObj[0].HexObj[x1, y1].SpriteNr = this.game.Data.LocTypeObj[index5].OverdrawSpriteNr;
            }
            num3 = 1;
          }
        }
      }
    }

    pub fn MakeLakes(x: i32, y: i32)
    {
      let mut num1: i32 = x;
      for (let mut cx: i32 = 0; cx <= num1; cx += 1)
      {
        let mut num2: i32 = y;
        for (let mut cy: i32 = 0; cy <= num2; cy += 1)
        {
          let mut num3: i32 = 0;
          let mut index1: i32 = 0;
          Coordinate coordinate;
          do
          {
            if (this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index1] > -1)
            {
              num3 += 1;
            }
            else
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, 0, index1 + 1);
              if (coordinate.onmap && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                num3 += 1;
            }
            index1 += 1;
          }
          while (index1 <= 5);
          if (num3 == 6)
          {
            let mut index2: i32 = 0;
            do
            {
              this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index2] = -1;
              coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, 0, index2 + 1);
              if (coordinate.onmap)
              {
                let mut index3: i32 = index2 + 3;
                if (index3 > 5)
                  index3 -= 6;
                this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RiverType[index3] = -1;
              }
              index2 += 1;
            }
            while (index2 <= 5);
            this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType = this.WATER;
          }
        }
      }
    }

    pub string GetRandomRegimeName(regnr: i32)
    {
      strArray: Vec<String> = new string[1001];
      Random random = Random::new();
      this.Flag1 = "";
      this.Flag1b = "";
      this.RegFavClimate = (int[]) Utils.CopyArray((Array) this.RegFavClimate, (Array) new int[this.game.Data.RegimeCounter + 1]);
      string Right;
      num1: i32;
      if ( this.game.Data.RuleVar[424] > 0.0)
      {
        num2: i32;
        while (num2 < 100)
        {
          num2 += 1;
          if ( this.game.Data.RuleVar[496] > 0.0 & regnr == this.opt3v)
          {
            let mut randomFromStringList: i32 = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[496])));
            Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[496]))].Data[randomFromStringList, 1];
            this.Flag1 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[496]))].Data[randomFromStringList, 2];
            this.Flag1b = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[496]))].Data[randomFromStringList, 3];
            this.RegFavClimate[regnr] = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[496]))].Data[randomFromStringList, 4]);
            this.game.Data.RegimeObj[regnr].People =  Math.Round( this.game.Data.RuleVar[497]);
          }
          else if ( this.game.Data.RuleVar[492] > 0.0 & (this.Regid[regnr] + 1 == 7 | this.Regid[regnr] + 1 == 14))
          {
            let mut randomFromStringList: i32 = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[492])));
            Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[492]))].Data[randomFromStringList, 1];
            this.Flag1 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[492]))].Data[randomFromStringList, 2];
            this.Flag1b = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[492]))].Data[randomFromStringList, 3];
            this.RegFavClimate[regnr] = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[492]))].Data[randomFromStringList, 4]);
          }
          else if ( this.game.Data.RuleVar[488] > 0.0 & (this.Regid[regnr] + 1 == 6 | this.Regid[regnr] + 1 == 13))
          {
            let mut randomFromStringList: i32 = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[488])));
            Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[488]))].Data[randomFromStringList, 1];
            this.Flag1 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[488]))].Data[randomFromStringList, 2];
            this.Flag1b = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[488]))].Data[randomFromStringList, 3];
            this.RegFavClimate[regnr] = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[488]))].Data[randomFromStringList, 4]);
          }
          else if ( this.game.Data.RuleVar[484] > 0.0 & (this.Regid[regnr] + 1 == 5 | this.Regid[regnr] + 1 == 12))
          {
            let mut randomFromStringList: i32 = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[484])));
            Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[484]))].Data[randomFromStringList, 1];
            this.Flag1 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[484]))].Data[randomFromStringList, 2];
            this.Flag1b = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[484]))].Data[randomFromStringList, 3];
            this.RegFavClimate[regnr] = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[484]))].Data[randomFromStringList, 4]);
          }
          else if ( this.game.Data.RuleVar[468] > 0.0 & (this.Regid[regnr] + 1 == 4 | this.Regid[regnr] + 1 == 11))
          {
            let mut randomFromStringList: i32 = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[468])));
            Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[468]))].Data[randomFromStringList, 1];
            this.Flag1 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[468]))].Data[randomFromStringList, 2];
            this.Flag1b = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[468]))].Data[randomFromStringList, 3];
            this.RegFavClimate[regnr] = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[468]))].Data[randomFromStringList, 4]);
          }
          else if ( this.game.Data.RuleVar[434] > 0.0 & (this.Regid[regnr] + 1 == 3 | this.Regid[regnr] + 1 == 10))
          {
            let mut randomFromStringList: i32 = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[434])));
            Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[434]))].Data[randomFromStringList, 1];
            this.Flag1 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[434]))].Data[randomFromStringList, 2];
            this.Flag1b = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[434]))].Data[randomFromStringList, 3];
            this.RegFavClimate[regnr] = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[434]))].Data[randomFromStringList, 4]);
          }
          else if ( this.game.Data.RuleVar[429] > 0.0 & (this.Regid[regnr] + 1 == 2 | this.Regid[regnr] + 1 == 9))
          {
            let mut randomFromStringList: i32 = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[429])));
            Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[429]))].Data[randomFromStringList, 1];
            this.Flag1 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[429]))].Data[randomFromStringList, 2];
            this.Flag1b = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[429]))].Data[randomFromStringList, 3];
            this.RegFavClimate[regnr] = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[429]))].Data[randomFromStringList, 4]);
          }
          else if ( this.game.Data.RuleVar[429] > 0.0 & (this.Regid[regnr] + 1 == 1 | this.Regid[regnr] + 1 == 8))
          {
            let mut randomFromStringList: i32 = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[424])));
            Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[424]))].Data[randomFromStringList, 1];
            this.Flag1 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[424]))].Data[randomFromStringList, 2];
            this.Flag1b = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[424]))].Data[randomFromStringList, 3];
            this.RegFavClimate[regnr] = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[424]))].Data[randomFromStringList, 4]);
          }
          num1 = 0;
          let mut regimeCounter: i32 = this.game.Data.RegimeCounter;
          for (let mut index: i32 = 0; index <= regimeCounter; index += 1)
          {
            if (Operators.CompareString(this.game.Data.RegimeObj[index].Name, Right, false) == 0)
              num1 = 1;
          }
          if (num1 == 0)
            return Right;
        }
      }
      while (num1 == 0)
      {
        strArray[0] = "Fascist";
        strArray[1] = "Dark";
        strArray[2] = "Light";
        strArray[3] = "Holy";
        strArray[4] = "Anamistic";
        strArray[5] = "Democratic";
        strArray[6] = "Hard";
        strArray[7] = "Deep";
        strArray[8] = "Syndicated";
        strArray[9] = "Communist";
        strArray[10] = "Free";
        strArray[11] = "Slave";
        strArray[12] = "Cyborg";
        strArray[13] = "Scientific";
        strArray[14] = "Christian";
        strArray[15] = "Muslim";
        strArray[16] = "Hindu";
        strArray[17] = "Human";
        strArray[18] = "Golden";
        strArray[19] = "Twisted";
        strArray[20] = "Trinity";
        strArray[21] = "Twilight";
        strArray[22] = "Cross";
        strArray[23] = "Shiite";
        strArray[24] = "Suni";
        strArray[25] = "Reformed";
        strArray[26] = "Workers";
        strArray[27] = "Liberal";
        strArray[28] = "Wired";
        strArray[29] = "Outlaw";
        strArray[30] = "Joined";
        strArray[31] = "Old";
        strArray[32] = "Constituted";
        strArray[33] = "Agnostic";
        strArray[34] = "Reformed";
        strArray[35] = "Reformed";
        strArray[36] = "First";
        strArray[37] = "Second";
        strArray[38] = "Third";
        strArray[39] = "Anarchic";
        strArray[40] = "Central";
        str: String = strArray[Conversion.Int(random.Next(0, 40))];
        strArray[0] = " Core";
        strArray[1] = " Alliance";
        strArray[2] = " Force";
        strArray[3] = " Army";
        strArray[4] = " Territory";
        strArray[5] = " Realm";
        strArray[6] = " Federation";
        strArray[7] = " Bond";
        strArray[8] = " Corporation";
        strArray[9] = " Front";
        strArray[10] = " Kingdom";
        strArray[11] = " State";
        strArray[12] = " Country";
        strArray[13] = " Marines";
        strArray[14] = " Killers";
        strArray[15] = " Team";
        strArray[16] = " Union";
        strArray[17] = " Party";
        strArray[18] = " Colony";
        strArray[19] = " Company";
        strArray[20] = " Gang";
        strArray[21] = " Empire";
        strArray[22] = " County";
        strArray[23] = " League";
        strArray[24] = " Org";
        strArray[25] = " Conglomerate";
        strArray[26] = " Autocracy";
        strArray[27] = " Commune";
        strArray[28] = " Brothers";
        strArray[29] = " Church";
        strArray[30] = " Society";
        strArray[31] = " Confederation";
        strArray[32] = " State";
        strArray[33] = " Movement";
        strArray[34] = " Congress";
        strArray[35] = " Imperium";
        strArray[36] = " Chiefdom";
        strArray[37] = " County";
        strArray[38] = " Barony";
        strArray[39] = " Settlement";
        strArray[40] = " Oligarchy";
        Right = str + strArray[Conversion.Int(random.Next(0, 40))];
        num1 = 1;
        let mut namecount: i32 = this.namecount;
        for (let mut index: i32 = 0; index <= namecount; index += 1)
        {
          if (Operators.CompareString(this.namelist[index], Right, false) == 0)
          {
            num1 = 0;
            break;
          }
        }
      }
      this += 1.namecount;
      this.namelist[this.namecount] = Right;
      return Right;
    }

    pub string GetRandomName(townsize: i32, townppl: i32, bool IsCapitol = false)
    {
      strArray: Vec<String> = new string[10000];
      Random random = Random::new();
      string Right;
      if ( this.game.Data.RuleVar[440 + townsize] > 0.0)
      {
        num1: i32;
        while (num1 < 1000)
        {
          num1 += 1;
          let mut index1: i32 = 440 + townsize;
          if (IsCapitol &  this.game.Data.RuleVar[500] > 0.0)
            index1 = 500;
          let mut index2: i32 = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[index1])));
          Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[index1]))].Data[index2, 1];
          if (townppl > -1 &&  townppl != Conversion.Val(Strings.Trim(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID( Math.Round( this.game.Data.RuleVar[index1]))].Data[index2, 2])))
            index2 = -1;
          if (index2 > -1)
          {
            let mut num2: i32 = 0;
            let mut locCounter: i32 = this.game.Data.LocCounter;
            for (let mut index3: i32 = 0; index3 <= locCounter; index3 += 1)
            {
              if (Operators.CompareString(this.game.Data.LocObj[index3].Name, Right, false) == 0)
                num2 = 1;
            }
            if (num2 == 0)
              return Right;
          }
        }
      }
      let mut num3: i32 = 0;
      while (num3 == 0)
      {
        Right = "";
        let mut num4: i32 = 0;
        index4: i32;
        if (DrawMod.RandyNumber.Next(0, 100) < 20)
        {
          strArray[0] = "High ";
          strArray[1] = "Low ";
          strArray[2] = "First ";
          strArray[3] = "New ";
          strArray[4] = "Old ";
          strArray[5] = "Far ";
          strArray[6] = "Top ";
          strArray[7] = "North ";
          strArray[8] = "Lake ";
          strArray[9] = "Camp ";
          strArray[10] = "Fort ";
          strArray[11] = "Keep ";
          strArray[12] = "Base ";
          strArray[13] = "Central ";
          strArray[14] = "Inner ";
          strArray[15] = "Outer ";
          strArray[16] = "Major ";
          strArray[17] = "Minor ";
          strArray[18] = "Second";
          strArray[19] = "Our";
          strArray[20] = "Purple";
          strArray[21] = "Yellow";
          strArray[22] = "Blue";
          strArray[23] = "Mount";
          strArray[24] = "Tar";
          strArray[25] = "Tin";
          num4 = 1;
          index4 += Conversion.Int(DrawMod.RandyNumber.Next(0, 25));
          Right += strArray[index4];
        }
        let mut num5: i32 = 0;
        if (DrawMod.RandyNumber.Next(0, 100) < 50)
        {
          strArray[0] = "Glory";
          strArray[1] = "Timber";
          strArray[2] = "Arion";
          strArray[3] = "Beaver";
          strArray[4] = "Boat";
          strArray[5] = "Choron";
          strArray[6] = "Deflec";
          strArray[7] = "Ennix";
          strArray[8] = "Fairsight";
          strArray[9] = "Gargoyle";
          strArray[10] = "Heaven";
          strArray[11] = "Orion";
          strArray[12] = "Palmtree";
          strArray[13] = "Flower";
          strArray[14] = "Cowsy";
          strArray[15] = "Deserdo";
          strArray[16] = "Frenchy";
          strArray[17] = "Hardskin";
          strArray[18] = "Ranger";
          strArray[19] = "Deepmist";
          strArray[20] = "Bluelight";
          strArray[21] = "Reddawn";
          strArray[22] = "Greenberry";
          strArray[23] = "Goldmine";
          strArray[24] = "Silver";
          strArray[25] = "Italian";
          strArray[26] = "Fachatto";
          strArray[27] = "Rainback";
          strArray[28] = "Heartlong";
          strArray[29] = "Schuman";
          strArray[30] = "Karl Marx";
          strArray[31] = "Bushbane";
          strArray[32] = "Darkon";
          strArray[33] = "Elfas";
          strArray[34] = "Voroth";
          strArray[35] = "Kinsman";
          strArray[36] = "Lightsky";
          strArray[37] = "Mozart";
          strArray[38] = "Balbo";
          strArray[39] = "Kinskey";
          strArray[40] = "Fallow";
          strArray[41] = "Hollow";
          strArray[42] = "Beech";
          strArray[43] = "Rotown";
          strArray[44] = "Weather";
          strArray[45] = "Valley";
          strArray[46] = "Triad";
          strArray[47] = "Dragon";
          strArray[48] = "Unicorn";
          strArray[49] = "Buffalo";
          strArray[50] = "Morning";
          strArray[51] = "Granite";
          strArray[52] = "Potato";
          strArray[53] = "Quicksilver";
          strArray[54] = "Palmas";
          strArray[55] = "Sandbeach";
          strArray[56] = "Crystaline";
          strArray[57] = "Nighttown";
          strArray[58] = "Darking";
          strArray[59] = "Madding";
          strArray[60] = "Paramac";
          strArray[61] = "Twinning";
          strArray[62] = "Bellow";
          strArray[63] = "Groundhawk";
          strArray[64] = "Pinetree";
          strArray[65] = "Albatross";
          strArray[66] = "Kirkee";
          strArray[67] = "Pottam";
          strArray[68] = "Hotten";
          strArray[69] = "Fard";
          strArray[70] = "Elephant";
          strArray[71] = "Minister";
          strArray[72] = "Parliament";
          strArray[73] = "Satin";
          strArray[74] = "Platen";
          strArray[75] = "Eagle";
          strArray[76] = "Watcher";
          strArray[77] = "Caven";
          strArray[78] = "Mansion";
          strArray[79] = "Rock";
          strArray[80] = "Frontier";
          Right += strArray[Conversion.Int(DrawMod.RandyNumber.Next(0, 80))];
          num5 = 1;
        }
        if (!((DrawMod.RandyNumber.Next(0, 100) < 60 | num5 == 1) & num5 != 0 | num4 == 1))
        {
          strArray[0] = "Deep";
          strArray[1] = "Tree";
          strArray[2] = "Sun";
          strArray[3] = "Wax";
          strArray[4] = "Lilly";
          strArray[5] = "Blue";
          strArray[6] = "Aard";
          strArray[7] = "Bee";
          strArray[8] = "Stone";
          strArray[9] = "Glass";
          strArray[10] = "Down";
          strArray[11] = "Fin";
          strArray[12] = "Weed";
          strArray[13] = "Queens";
          strArray[14] = "Kings";
          strArray[15] = "Love";
          strArray[16] = "Mins";
          strArray[17] = "Tir";
          strArray[18] = "Horse";
          strArray[19] = "Dip";
          strArray[20] = "Water";
          strArray[21] = "Doop";
          strArray[22] = "Bush";
          strArray[23] = "Moon";
          strArray[24] = "Stiff";
          strArray[25] = "Rose";
          strArray[26] = "Green";
          strArray[27] = "Glor";
          strArray[28] = "Krin";
          strArray[29] = "Dirt";
          strArray[30] = "Metal";
          strArray[31] = "Up";
          strArray[32] = "Mirk";
          strArray[33] = "Cult";
          strArray[34] = "Lords";
          strArray[35] = "Pearl";
          strArray[36] = "Hate";
          strArray[37] = "Por";
          strArray[38] = "Zul";
          strArray[39] = "Cattle";
          strArray[40] = "Tin";
          strArray[41] = "Land";
          let mut index5: i32 = Conversion.Int(DrawMod.RandyNumber.Next(0, 40));
          str: String = Right + strArray[index5];
          strArray[0] = "castle";
          strArray[1] = "house";
          strArray[2] = "work";
          strArray[3] = "dam";
          strArray[4] = "ton";
          strArray[5] = "hold";
          strArray[6] = "keep";
          strArray[7] = "pin";
          strArray[8] = "lor";
          strArray[9] = "aleen";
          strArray[10] = "fish";
          strArray[11] = "road";
          strArray[12] = "square";
          strArray[13] = "sight";
          strArray[14] = "fresh";
          strArray[15] = "brick";
          strArray[16] = "keen";
          strArray[17] = "ly";
          strArray[18] = "rod";
          strArray[19] = "desert";
          strArray[20] = "forest";
          strArray[21] = "wall";
          strArray[22] = "market";
          strArray[23] = "sleep";
          strArray[24] = "flow";
          strArray[25] = "mok";
          strArray[26] = "fall";
          strArray[27] = "stuff";
          strArray[28] = "pouch";
          strArray[29] = "varn";
          strArray[30] = "elath";
          strArray[31] = "beatle";
          strArray[32] = "path";
          strArray[33] = "center";
          strArray[34] = "cellar";
          strArray[35] = "salt";
          strArray[36] = "timber";
          strArray[37] = "ion";
          strArray[38] = "sky";
          strArray[39] = "staff";
          strArray[40] = "meadows";
          strArray[41] = "wood";
          index4 = Conversion.Int(DrawMod.RandyNumber.Next(0, 40));
          Right = str + strArray[index4];
        }
        if ( VBMath.Rnd() < 0.3)
        {
          strArray[0] = " Ville";
          strArray[1] = " Town";
          strArray[2] = " Hope";
          strArray[3] = "crossing";
          strArray[4] = "cross";
          strArray[5] = " Soul";
          strArray[6] = "hill";
          strArray[7] = "field";
          strArray[8] = "ford";
          strArray[9] = "shire";
          strArray[10] = " End";
          strArray[11] = " Denn";
          strArray[12] = " Fir";
          strArray[13] = " Varn";
          strArray[14] = "ing";
          strArray[15] = "gate";
          strArray[16] = " View";
          strArray[17] = " Hole";
          strArray[18] = "stream";
          strArray[19] = "s View";
          strArray[20] = " Dream";
          index4 = Conversion.Int(DrawMod.RandyNumber.Next(0, 20));
          Right += strArray[index4];
        }
        num3 = 1;
        let mut namecount: i32 = this.namecount;
        for (let mut index6: i32 = 0; index6 <= namecount; index6 += 1)
        {
          if (Operators.CompareString(this.namelist[index6], Right, false) == 0)
          {
            num3 = 0;
            break;
          }
        }
      }
      this += 1.namecount;
      this.namelist[this.namecount] = Right;
      return Right;
    }

    pub fn DrawARiverAddRiver(x: i32, y: i32, z: i32, steppy: i32, ox: i32, oy: i32, oz: i32)
    {
      object[,] objArray = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      if (this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] == -1)
        this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] = this.SMALLRIVER;
      else
        this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] = this.BIGRIVER;
      Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(x, y, 0, z + 1);
      if (coordinate.onmap)
      {
        let mut index: i32 = z + 3;
        if (index > 5)
          index -= 6;
        this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RiverType[index] = this.game.Data.MapObj[0].HexObj[x, y].RiverType[z];
        if (steppy > -1)
          this.curriv[coordinate.x, coordinate.y, index] = 1;
        if (steppy > -1)
          this.rivstep[coordinate.x, coordinate.y, index] = steppy;
      }
      if (steppy > -1)
        this.curriv[x, y, z] = 1;
      if (steppy > -1)
        this.rivstep[x, y, z] = steppy;
      if (ox <= -1)
        return;
      this.nextrivstep[ox, oy, oz].x = x;
      this.nextrivstep[ox, oy, oz].y = y;
      this.nextrivstep[ox, oy, oz].data1 = z;
      coordinate = this.game.HandyFunctionsObj.HexNeighbour(ox, oy, 0, oz + 1);
      if (!coordinate.onmap)
        return;
      let mut index1: i32 = oz + 3;
      if (index1 > 5)
        index1 -= 6;
      this.nextrivstep[coordinate.x, coordinate.y, index1].x = x;
      this.nextrivstep[coordinate.x, coordinate.y, index1].y = y;
      this.nextrivstep[coordinate.x, coordinate.y, index1].data1 = z;
    }

    pub fn TraceRiver(x: i32, y: i32, z: i32, ox: i32, oy: i32, oz: i32)
    {
      numArray: Vec<i32> = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      Coordinate coordinate;
      coordinate.onmap = false;
      let mut num1: i32 = 1;
      let mut num2: i32 = 0;
      while (num1 == 1 & num2 < 200)
      {
        num1 = 0;
        num2 += 1;
        this.DrawARiverAddRiver(x, y, z, -1, ox, oy, oz);
        if (this.nextrivstep[x, y, z].x > -1)
        {
          num1 = 1;
          ox = x;
          oy = y;
          oz = z;
          x = this.nextrivstep[ox, oy, oz].x;
          y = this.nextrivstep[ox, oy, oz].y;
          z = this.nextrivstep[ox, oy, oz].data1;
        }
      }
    }

    pub fn DrawARiver2(x: i32, y: i32, z: i32)
    {
      numArray: Vec<i32> = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.curriv = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 6];
      let mut index1: i32 = z + 1;
      if (index1 > 5)
        index1 = 0;
      if (this.game.Data.MapObj[0].HexObj[x, y].RiverType[index1] > -1)
        return;
      let mut index2: i32 = z - 1;
      if (index2 < 0)
        index2 = 5;
      if (this.game.Data.MapObj[0].HexObj[x, y].RiverType[index2] > -1)
        return;
      Coordinate coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(x, y, 0, z);
      if (coordinate1.onmap)
      {
        let mut num: i32 = z + 3;
        if (num > 5)
          num -= 6;
        let mut index3: i32 = num + 1;
        if (index3 > 5)
          index3 = 0;
        if (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RiverType[index3] > -1)
          return;
        let mut index4: i32 = num - 1;
        if (index4 < 0)
          index4 = 5;
        if (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RiverType[index4] > -1)
          return;
      }
      let mut num1: i32 = 1;
      if (this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] == this.BIGRIVER)
        return;
      this.DrawARiverAddRiver(x, y, z, 0, -1, -1, -1);
      numArray[x, y] = 1;
      coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(x, y, 0, z + 1);
      if (coordinate1.onmap)
        numArray[coordinate1.x, coordinate1.y] = 1;
      steppy: i32;
      while (this.game.EditObj.TempValue[0].Value[x, y] > 0 & steppy < 200)
      {
        num1 = 0;
        steppy += 1;
        numArray[x, y] = 1;
        let mut num2: i32 = 999999;
        Coordinate coordinate2;
        coordinate2.onmap = false;
        let mut num3: i32 = 0;
        num4: i32;
        do
        {
          coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(x, y, 0, num3 + 1);
          if (coordinate1.onmap & num3 != z && this.game.EditObj.TempValue[0].Value[coordinate1.x, coordinate1.y] < num2 && numArray[coordinate1.x, coordinate1.y] < 1)
          {
            num2 = this.game.EditObj.TempValue[0].Value[coordinate1.x, coordinate1.y];
            coordinate2.x = coordinate1.x;
            coordinate2.y = coordinate1.y;
            coordinate2.onmap = coordinate1.onmap;
            num4 = num3;
          }
          num3 += 1;
        }
        while (num3 <= 5);
        if (!coordinate2.onmap)
          break;
        let mut num5: i32 = 0;
        if (z == 0 & num4 <= 2)
          num5 = 1;
        if (z == 0 & num4 > 3)
          num5 = 2;
        if (z == 1 & num4 <= 3)
          num5 = 1;
        if (z == 2 & num4 <= 4)
          num5 = 1;
        if (z == 3 & num4 <= 5)
          num5 = 1;
        if (z == 4 & (num4 == 5 | num4 == 0))
          num5 = 1;
        if (z == 5 & (num4 == 0 | num4 == 1))
          num5 = 1;
        if (z == 1 & (num4 == 5 | num4 == 0))
          num5 = 2;
        if (z == 2 & num4 <= 1)
          num5 = 2;
        if (z == 3 & (num4 == 1 | num4 == 2))
          num5 = 2;
        if (z == 4 & (num4 == 2 | num4 == 3))
          num5 = 2;
        if (z == 5 & (num4 == 3 | num4 == 4))
          num5 = 2;
        if (num5 == 0)
          num5 = (x + y) % 2 != 0 ? 2 : 1;
        let mut index5: i32 = z;
        if (num5 == 1)
          index5 += 1;
        if (num5 == 2)
          --index5;
        if (index5 > 5)
          index5 -= 6;
        if (0 > index5)
          index5 += 6;
        if (this.game.Data.MapObj[0].HexObj[x, y].RiverType[index5] > -1 & this.curriv[x, y, index5] > 0)
          num5 = num5 != 1 ? 1 : 2;
        let mut num6: i32 = 0;
        while (num6 == 0)
        {
          let mut ox1: i32 = x;
          let mut oy1: i32 = y;
          let mut oz1: i32 = z;
          if (num5 == 1)
            z += 1;
          if (num5 == 2)
            --z;
          if (z > 5)
            z -= 6;
          if (0 > z)
            z += 6;
          coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(x, y, 0, z + 1);
          if (!coordinate1.onmap)
            return;
          if (this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] > -1 & this.curriv[x, y, z] == 0)
          {
            this.TraceRiver(x, y, z, ox1, oy1, oz1);
            return;
          }
          this.DrawARiverAddRiver(x, y, z, steppy, ox1, oy1, oz1);
          numArray[coordinate1.x, coordinate1.y] = 1;
          if (coordinate1.x == coordinate2.x & coordinate1.y == coordinate2.y)
          {
            let mut ox2: i32 = x;
            let mut oy2: i32 = y;
            let mut oz2: i32 = z;
            z += 3;
            if (z > 5)
              z -= 6;
            if (num5 == 1)
              --z;
            if (num5 == 2)
              z += 1;
            if (z > 5)
              z -= 6;
            if (0 > z)
              z += 6;
            x = coordinate2.x;
            y = coordinate2.y;
            if (this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] > -1 & this.curriv[x, y, z] == 0)
            {
              this.TraceRiver(x, y, z, ox2, oy2, oz2);
              return;
            }
            this.DrawARiverAddRiver(x, y, z, steppy, ox2, oy2, oz2);
            coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(x, y, 0, z + 1);
            if (coordinate1.onmap)
              numArray[coordinate1.x, coordinate1.y] = 1;
            num6 = 1;
          }
        }
      }
    }

    pub fn DrawARiver(x: i32, y: i32, z: i32)
    {
      object[,,] objArray = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 6];
      float num1 = VBMath.Rnd();
      let mut num2: i32 = 0;
      do
      {
        num2 += 1;
        if (this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] == -1)
        {
          if ( num1 < 0.6)
            this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] = this.SMALLRIVER;
          else
            this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] = this.BIGRIVER;
          objArray[x, y, z] =  1;
        }
        else
        {
          this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] = this.BIGRIVER;
          objArray[x, y, z] =  1;
        }
        if (this.game.EditObj.TempValue[0].Value[x, y] > 1)
        {
          numArray1: Vec<i32> = this.game.EditObj.TempValue[0].Value;
          numArray2: Vec<i32> = numArray1;
          let mut index1: i32 = x;
          let mut index2: i32 = index1;
          let mut index3: i32 = y;
          let mut index4: i32 = index3;
          let mut num3: i32 = numArray1[index1, index3] - 1;
          numArray2[index2, index4] = num3;
        }
        Coordinate coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, z + 1);
        let mut index5: i32 = z + 3;
        if (index5 > 5)
          index5 -= 6;
        if (coordinate1.onmap)
        {
          if (this.game.EditObj.TempValue[0].Value[coordinate1.x, coordinate1.y] > 1)
          {
            numArray3: Vec<i32> = this.game.EditObj.TempValue[0].Value;
            numArray4: Vec<i32> = numArray3;
            let mut x1: i32 = coordinate1.x;
            let mut index6: i32 = x1;
            let mut y1: i32 = coordinate1.y;
            let mut index7: i32 = y1;
            let mut num4: i32 = numArray3[x1, y1] - 1;
            numArray4[index6, index7] = num4;
          }
          if (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RiverType[index5] == -1)
          {
            if ( num1 < 0.6)
              this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RiverType[index5] = this.SMALLRIVER;
            else
              this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RiverType[index5] = this.BIGRIVER;
            objArray[coordinate1.x, coordinate1.y, index5] =  1;
          }
          else
          {
            this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RiverType[index5] = this.BIGRIVER;
            objArray[coordinate1.x, coordinate1.y, index5] =  1;
          }
        }
        let mut num5: i32 = this.game.EditObj.TempValue[0].Value[x, y];
        let mut num6: i32 = z - 1;
        if (0 > num6)
          num6 = 5;
        coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, num6 + 1);
        let mut num7: i32 = 999999;
        if (coordinate1.onmap)
          num7 = this.game.EditObj.TempValue[0].Value[coordinate1.x, coordinate1.y];
        let mut num8: i32 = z;
        coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, num8 + 1);
        let mut num9: i32 = 999999;
        if (coordinate1.onmap)
          num9 = this.game.EditObj.TempValue[0].Value[coordinate1.x, coordinate1.y];
        let mut num10: i32 = z + 1;
        if (num10 > 5)
          num10 = 0;
        coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, num10 + 1);
        let mut num11: i32 = 999999;
        if (coordinate1.onmap)
          num11 = this.game.EditObj.TempValue[0].Value[coordinate1.x, coordinate1.y];
        let mut num12: i32 = 0;
        let mut num13: i32 = 0;
        let mut num14: i32 = 0;
        let mut num15: i32 = 0;
        let mut index8: i32 = z - 1;
        if (0 > index8)
          index8 = 5;
        if (Operators.ConditionalCompareObjectEqual(objArray[x, y, index8],  1, false))
          num12 = 200000;
        coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, z + 1);
        if (coordinate1.onmap)
        {
          let mut num16: i32 = z + 3;
          if (num16 > 5)
            num16 -= 6;
          let mut index9: i32 = num16 + 1;
          if (index9 > 5)
            index9 = 0;
          if (Operators.ConditionalCompareObjectEqual(objArray[coordinate1.x, coordinate1.y, index9],  1, false))
            num13 = 200000;
          let mut num17: i32 = z + 3;
          if (num17 > 5)
            num17 -= 6;
          let mut index10: i32 = num17 - 1;
          if (index10 < 0)
            index10 = 5;
          if (Operators.ConditionalCompareObjectEqual(objArray[coordinate1.x, coordinate1.y, index10],  1, false))
            num14 = 200000;
        }
        let mut index11: i32 = z + 1;
        if (5 < index11)
          index11 = 0;
        if (Operators.ConditionalCompareObjectEqual(objArray[x, y, index11],  1, false))
          num15 = 200000;
        let mut num18: i32 = 0;
        let mut num19: i32 = 999999;
        if (num5 + num7 + num12 < num19)
        {
          num19 = num5 + num7 + num12;
          num18 = 1;
        }
        if (num7 + num9 + num13 < num19)
        {
          num19 = num7 + num9 + num13;
          num18 = 2;
        }
        if (num9 + num11 + num14 < num19)
        {
          num19 = num9 + num11 + num14;
          num18 = 3;
        }
        if (num5 + num11 + num15 < num19)
        {
          let mut num20: i32 = num5 + num11 + num15;
          num18 = 4;
        }
        if (num5 == 0 | num7 == 0 | num9 == 0 | num11 == 0 || num5 >= 999999 | num7 >= 999999 | num9 >= 999999 | num11 >= 999999)
          return;
        Coordinate coordinate2;
        if (num18 == 1)
        {
          coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, z + 1);
          let mut num21: i32 = z + 3;
          if (num21 > 5)
            num21 -= 6;
          let mut index12: i32 = num21 + 1;
          if (index12 > 5)
            index12 = 0;
          objArray[coordinate1.x, coordinate1.y, index12] =  1;
          coordinate2 = this.game.HandyFunctionsObj.HexNeighbourSameMap(coordinate1.x, coordinate1.y, 0, index12 + 1);
          let mut index13: i32 = index12 + 3;
          if (index13 > 5)
            index13 -= 6;
          objArray[coordinate2.x, coordinate2.y, index13] =  1;
        }
        if (num18 == 1)
        {
          --z;
          if (0 > z)
            z = 5;
          x = x;
          y = y;
        }
        if (num18 == 2)
        {
          let mut index14: i32 = z - 1;
          if (0 > index14)
            index14 = 5;
          objArray[x, y, index14] =  1;
          coordinate2 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, index14 + 1);
          let mut index15: i32 = index14 + 3;
          if (index15 > 5)
            index15 -= 6;
          objArray[coordinate2.x, coordinate2.y, index15] =  1;
        }
        if (num18 == 2)
        {
          coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, z + 1);
          let mut num22: i32 = z + 3;
          if (num22 > 5)
            num22 -= 6;
          x = coordinate1.x;
          y = coordinate1.y;
          z = num22;
          z += 1;
          if (z > 5)
            z = 0;
        }
        if (num18 == 3)
        {
          let mut index16: i32 = z + 1;
          if (index16 > 5)
            index16 = 0;
          objArray[x, y, index16] =  1;
          coordinate2 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, index16 + 1);
          let mut index17: i32 = index16 + 3;
          if (index17 > 5)
            index17 -= 6;
          objArray[coordinate2.x, coordinate2.y, index17] =  1;
        }
        if (num18 == 3)
        {
          coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, z + 1);
          let mut num23: i32 = z + 3;
          if (num23 > 5)
            num23 -= 6;
          x = coordinate1.x;
          y = coordinate1.y;
          z = num23;
          --z;
          if (z < 0)
            z = 5;
        }
        if (num18 == 4)
        {
          coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, z + 1);
          let mut num24: i32 = z + 3;
          if (num24 > 5)
            num24 -= 6;
          let mut index18: i32 = num24 - 1;
          if (index18 < 0)
            index18 = 5;
          objArray[coordinate1.x, coordinate1.y, index18] =  1;
          coordinate2 = this.game.HandyFunctionsObj.HexNeighbourSameMap(coordinate1.x, coordinate1.y, 0, index18 + 1);
          let mut index19: i32 = index18 + 3;
          if (index19 > 5)
            index19 -= 6;
          objArray[coordinate2.x, coordinate2.y, index19] =  1;
        }
        if (num18 == 4)
        {
          z += 1;
          if (z > 5)
            z = 0;
          x = x;
          y = y;
        }
      }
      while (num2 < 75);
      this.game.Data.MapObj[0].HexObj[x, y].LandscapeType = this.WATER;
      this.game.EditObj.TempValue[0].Value[x, y] = 0;
    }

    pub fn MakeHeightTable()
    {
      this.game.EditObj.TempValue = new MapMatrix2[1];
      this.game.EditObj.TempValue2 = new MapMatrix2[1];
      this.game.EditObj.TempValue[0] = new MapMatrix2(this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight);
      this.game.EditObj.TempValue2[0] = new MapMatrix2(this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight);
      let mut mapWidth1: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut index1: i32 = 0; index1 <= mapWidth1; index1 += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut index2: i32 = 0; index2 <= mapHeight; index2 += 1)
        {
          this.game.EditObj.TempValue[0].Value[index1, index2] = 0;
          if (this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType == this.LOWMOUNTAIN)
            this.game.EditObj.TempValue[0].Value[index1, index2] = 20000;
          else if (this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType == this.HIGHMOUNTAIN)
            this.game.EditObj.TempValue[0].Value[index1, index2] = 50000;
          else if (this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType == this.WATER)
            this.game.EditObj.TempValue[0].Value[index1, index2] = 0;
          else if ( VBMath.Rnd() < 0.99 | this.opt4v < 100 | this.game.Data.MapObj[0].HexObj[index1, index2].Regime > -1 | this.game.Data.MapObj[0].HexObj[index1, index2].Location > -1)
          {
            this.game.EditObj.TempValue[0].Value[index1, index2] =  Math.Round( (8000f + Conversion.Int(VBMath.Rnd() * 10000f)));
          }
          else
          {
            this.game.EditObj.TempValue[0].Value[index1, index2] = 0;
            this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType = this.WATER;
          }
          if ( this.game.Data.RuleVar[481] > 0.0 && this.game.Data.MapObj[0].HexObj[index1, index2].AreaCode[ Math.Round( this.game.Data.RuleVar[481])] == 99)
          {
            numArray1: Vec<i32> = this.game.EditObj.TempValue[0].Value;
            numArray2: Vec<i32> = numArray1;
            let mut index3: i32 = index1;
            let mut index4: i32 = index3;
            let mut index5: i32 = index2;
            let mut index6: i32 = index5;
            let mut num1: i32 = numArray1[index3, index5] * 2;
            numArray2[index4, index6] = num1;
            numArray3: Vec<i32> = this.game.EditObj.TempValue[0].Value;
            numArray4: Vec<i32> = numArray3;
            let mut index7: i32 = index1;
            let mut index8: i32 = index7;
            let mut index9: i32 = index2;
            let mut index10: i32 = index9;
            let mut num2: i32 = numArray3[index7, index9] + 5000;
            numArray4[index8, index10] = num2;
          }
          if (this.domirror == 1)
          {
            let mut num: i32 =  Math.Round( this.game.Data.MapObj[0].MapWidth / 2.0);
            if (index1 >= num - 1 & index1 <= num + 1)
              this.game.EditObj.TempValue[0].Value[index1, index2] = 20000;
          }
          if (index1 == 0 | index2 == 0)
            this.game.EditObj.TempValue[0].Value[index1, index2] = 0;
          if (index1 == this.game.Data.MapObj[0].MapWidth | index2 == this.game.Data.MapObj[0].MapHeight)
            this.game.EditObj.TempValue[0].Value[index1, index2] = 0;
        }
      }
      let mut num3: i32 = 0;
      Coordinate coordinate;
      do
      {
        num3 += 1;
        let mut mapWidth2: i32 = this.game.Data.MapObj[0].MapWidth;
        for (let mut cx: i32 = 0; cx <= mapWidth2; cx += 1)
        {
          let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
          for (let mut cy: i32 = 0; cy <= mapHeight; cy += 1)
          {
            if (this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType != this.WATER)
            {
              let mut num4: i32 = 0;
              let mut num5: i32 = 0;
              let mut tfacing: i32 = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, 0, tfacing);
                if (coordinate.onmap)
                {
                  num5 += 1;
                  num4 += this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y];
                }
                tfacing += 1;
              }
              while (tfacing <= 6);
              if (num5 > 0 & num4 > num5)
              {
                let mut num6: i32 =  Math.Round(Conversion.Int( num4 /  num5));
                if (num6 < 1)
                  num6 = 1;
                this.game.EditObj.TempValue2[0].Value[cx, cy] = num6;
              }
              else
                this.game.EditObj.TempValue2[0].Value[cx, cy] = this.game.EditObj.TempValue[0].Value[cx, cy];
              if (this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType == this.LOWMOUNTAIN)
                this.game.EditObj.TempValue2[0].Value[cx, cy] =  Math.Round( (this.game.EditObj.TempValue2[0].Value[cx, cy] + 20000) / 2.0);
              else if (this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType == this.HIGHMOUNTAIN)
                this.game.EditObj.TempValue2[0].Value[cx, cy] =  Math.Round( (this.game.EditObj.TempValue2[0].Value[cx, cy] + 50000) / 2.0);
            }
          }
        }
        let mut mapWidth3: i32 = this.game.Data.MapObj[0].MapWidth;
        for (let mut index11: i32 = 0; index11 <= mapWidth3; index11 += 1)
        {
          let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
          for (let mut index12: i32 = 0; index12 <= mapHeight; index12 += 1)
            this.game.EditObj.TempValue[0].Value[index11, index12] = this.game.EditObj.TempValue2[0].Value[index11, index12];
        }
      }
      while (num3 < 50);
      let mut mapWidth4: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut index13: i32 = 0; index13 <= mapWidth4; index13 += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut index14: i32 = 0; index14 <= mapHeight; index14 += 1)
        {
          if ( this.game.Data.RuleVar[450] == 1.0)
            this.game.EditObj.TempValue[0].Value[index13, index14] =  Math.Round(0.95 *  this.game.EditObj.TempValue[0].Value[index13, index14] + 0.1 *  this.game.EditObj.TempValue[0].Value[index13, index14] *  VBMath.Rnd());
          if (this.game.Data.MapObj[0].HexObj[index13, index14].LandscapeType == this.WATER)
            this.game.EditObj.TempValue[0].Value[index13, index14] = 0;
          else if (this.game.EditObj.TempValue[0].Value[index13, index14] <= 25)
            this.game.EditObj.TempValue[0].Value[index13, index14] = 25;
        }
      }
      if (this.domirror != 0)
        return;
      let mut mapWidth5: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut cx: i32 = 0; cx <= mapWidth5; cx += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut cy: i32 = 0; cy <= mapHeight; cy += 1)
        {
          if ( VBMath.Rnd() < 0.07)
          {
            if (this.game.EditObj.TempValue[0].Value[cx, cy] != 0)
            {
              let mut tfacing: i32 = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, 0, tfacing);
                if (this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y] != 0)
                {
                  if (coordinate.onmap)
                    this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y] = Conversion.Int(this.game.EditObj.TempValue[0].Value[cx, cy]);
                  this.game.EditObj.TempValue[0].Value[cx, cy] = Conversion.Int(this.game.EditObj.TempValue[0].Value[cx, cy]);
                }
                tfacing += 1;
              }
              while (tfacing <= 6);
            }
          }
          else
            this.game.EditObj.TempValue[0].Value[cx, cy] =  Math.Round(Conversion.Int( VBMath.Rnd() * 0.1 *  this.game.EditObj.TempValue[0].Value[cx, cy]) + Conversion.Int(0.95 *  this.game.EditObj.TempValue[0].Value[cx, cy]));
        }
      }
    }

    pub fn MakeLandBlob(x: i32, y: i32, sizy: i32)
    {
      let mut num1: i32 = 0;
      this.game.Data.MapObj[0].HexObj[x, y].LandscapeType = this.GRASS;
      this += 1.landcur;
      if ( VBMath.Rnd() * 100.0 <  this.opt6v)
        num1 =  VBMath.Rnd() >= 0.3 ? ( VBMath.Rnd() >= 0.5 ? 3 : 2) : 1;
      num2: i32;
      do
      {
        num2 = 0;
        num3: i32;
        num3 += 1;
        let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
        for (let mut x2: i32 = 0; x2 <= mapWidth; x2 += 1)
        {
          let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
          for (let mut y2: i32 = 0; y2 <= mapHeight; y2 += 1)
          {
            if (this.game.HandyFunctionsObj.Distance(x, y, 0, x2, y2, 0) == num3)
            {
              float num4 = VBMath.Rnd() * 0.5f;
              if ( Conversion.Int( ( VBMath.Rnd() * ( sizy *  num4) +  sizy * (1.0 -  num4))) >  (num3 * num3) && this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType == this.WATER | this.opt4v == 100 | this.WATER == -1)
              {
                switch (num1)
                {
                  case 1:
                    num2 = 1;
                    if ( VBMath.Rnd() < 0.8)
                    {
                      this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.HEAVYFOREST;
                      break;
                    }
                    if ( VBMath.Rnd() < 0.4)
                    {
                      this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.LIGHTFOREST;
                      break;
                    }
                    this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.GRASS;
                    break;
                  case 2:
                    num2 = 1;
                    if ( VBMath.Rnd() < 0.6)
                    {
                      this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.LIGHTFOREST;
                      break;
                    }
                    if ( VBMath.Rnd() < 0.6)
                    {
                      this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.HEAVYFOREST;
                      break;
                    }
                    this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.GRASS;
                    break;
                  case 3:
                    num2 = 1;
                    if ( VBMath.Rnd() < 0.6)
                    {
                      this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.LIGHTFOREST;
                      break;
                    }
                    if ( VBMath.Rnd() < 0.1)
                    {
                      this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.LIGHTFOREST;
                      break;
                    }
                    this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.GRASS;
                    break;
                  default:
                    num2 = 1;
                    this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.GRASS;
                    break;
                }
                this += 1.landcur;
              }
            }
          }
        }
      }
      while (num2 == 1);
    }

    pub fn MakeMountainRange(x: i32, y: i32, x2: i32, y2: i32)
    {
      let mut mapWidth1: i32 = this.game.Data.MapObj[0].MapWidth;
      Coordinate coordinate;
      for (let mut cx: i32 = 0; cx <= mapWidth1; cx += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut cy: i32 = 0; cy <= mapHeight; cy += 1)
        {
          if (this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType == this.GRASS && cx >= x & cy >= y & cx <= x2 & cy <= y2)
          {
            let mut num: i32 = 1;
            let mut tfacing: i32 = 1;
            do
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, 0, tfacing);
              if (coordinate.onmap && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType == this.WATER)
                num = 0;
              tfacing += 1;
            }
            while (tfacing <= 6);
            if (num == 1)
            {
              if ( VBMath.Rnd() < 0.66)
              {
                this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType = this.HIGHMOUNTAIN;
                this += 1.mountaincur;
              }
              else
              {
                this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType = this.LOWMOUNTAIN;
                this += 1.mountaincur;
              }
            }
          }
        }
      }
      num1: i32;
      num1 += 1;
      let mut mapWidth2: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut cx: i32 = 0; cx <= mapWidth2; cx += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut cy: i32 = 0; cy <= mapHeight; cy += 1)
        {
          if (this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType == this.GRASS && cx >= x - 1 & cy >= y - 1 & cx <= x2 + 1 & cy <= y2 + 1)
          {
            let mut num2: i32 = 0;
            let mut tfacing: i32 = 1;
            do
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, 0, tfacing);
              if (coordinate.onmap && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType == this.HIGHMOUNTAIN)
                num2 = 1;
              tfacing += 1;
            }
            while (tfacing <= 6);
            if (num2 == 1 &&  VBMath.Rnd() > 0.5)
            {
              this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType = this.LOWMOUNTAIN;
              this += 1.mountaincur;
            }
          }
        }
      }
    }

    pub fn FinalizeLadder()
    {
      numArray: Vec<i32> = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.game.Data.AddPeople();
      this.game.Data.PeopleObj[this.game.Data.PeopleCounter].PeopleGroup = 1;
      this.game.Data.PeopleObj[this.game.Data.PeopleCounter].Name = "2nd Player";
      this.game.Data.RegimeObj[1].People = 1;
      this.game.Data.TempString[200] = "Universals";
      this.game.Data.TempString[201] = "2nd Player";
      let mut mapWidth: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut x: i32 = 0; x <= mapWidth; x += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut y: i32 = 0; y <= mapHeight; y += 1)
        {
          let mut regime: i32 = this.game.Data.MapObj[0].HexObj[x, y].Regime;
          if (regime > -1)
          {
            let mut location: i32 = this.game.Data.MapObj[0].HexObj[x, y].Location;
            if (location > -1)
            {
              this.game.Data.LocObj[location].HQ = regime;
              this.game.Data.LocObj[location].ProdPercent[0] = 100;
              this.game.Data.LocObj[location].Production[0] = 1;
              let mut unr: i32 = this.game.Data.AddUnit(x, y, 0);
              this.game.Data.UnitObj[unr].Name = "Garrison Unit";
              this.game.Data.UnitObj[unr].Regime = regime;
              this.game.Data.UnitObj[unr].Supply = 80;
              this.game.Data.UnitObj[unr].SOSupReqPercent = 100;
              this.game.Data.UnitObj[unr].IsHQ = false;
              this.game.Data.UnitObj[unr].HQ = regime;
              let mut index: i32 = this.game.Data.AddSF(unr);
              this.game.Data.SFObj[index].Type = 0;
              this.game.Data.SFObj[index].Qty = 20;
              this.game.Data.SFObj[index].Rdn = 100;
              this.game.Data.SFObj[index].People = 0;
              this.game.Data.SFObj[index].Xp = 25;
              this.game.Data.SFObj[index].Mor = 50;
            }
          }
        }
      }
    }

    pub fn FinalizeLadderPre()
    {
      numArray: Vec<i32> = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      let mut mapWidth1: i32 = this.game.Data.MapObj[0].MapWidth;
      for (let mut index1: i32 = 0; index1 <= mapWidth1; index1 += 1)
      {
        let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
        for (let mut index2: i32 = 0; index2 <= mapHeight; index2 += 1)
          numArray[index1, index2] = -1;
      }
      let mut num1: i32 = 1;
      do
      {
        let mut mapWidth2: i32 = this.game.Data.MapObj[0].MapWidth;
        for (let mut index3: i32 = 0; index3 <= mapWidth2; index3 += 1)
        {
          let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
          for (let mut index4: i32 = 0; index4 <= mapHeight; index4 += 1)
          {
            if (this.game.Data.MapObj[0].HexObj[index3, index4].Regime == num1)
              numArray[index3, index4] = 0;
          }
        }
        num1 += -1;
      }
      while (num1 >= 0);
      let mut num2: i32 = 0;
      do
      {
        let mut num3: i32 = 1;
        do
        {
          let mut mapWidth3: i32 = this.game.Data.MapObj[0].MapWidth;
          for (let mut cx: i32 = 0; cx <= mapWidth3; cx += 1)
          {
            let mut mapHeight: i32 = this.game.Data.MapObj[0].MapHeight;
            for (let mut cy: i32 = 0; cy <= mapHeight; cy += 1)
            {
              if (this.game.Data.MapObj[0].HexObj[cx, cy].Regime == num3 & numArray[cx, cy] == num2)
              {
                let mut tfacing: i32 = 1;
                do
                {
                  Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, 0, tfacing);
                  if (coordinate.onmap & numArray[coordinate.x, coordinate.y] == -1)
                  {
                    if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime == -1)
                      this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime = num3;
                    numArray[coordinate.x, coordinate.y] = num2 + 1;
                  }
                  tfacing += 1;
                }
                while (tfacing <= 6);
              }
            }
          }
          num3 += -1;
        }
        while (num3 >= 0);
        num2 += 1;
      }
      while (num2 <= 20);
    }
  }
}
