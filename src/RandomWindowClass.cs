// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.RandomWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class RandomWindowClass : WindowClass
  {
    private int BStartGameID;
    private int BLoadGameID;
    private int BLadderID;
    private int BSaveGameID;
    private int BEditorID;
    private int TempText;
    private int TempText2;
    private int txt1;
    private int txt2;
    private int tab1;
    private int tab2;
    private int tabmode;
    private int txt3;
    private int shrowd;
    private int doshrowd;
    private int maploop;
    private int singlestart;
    private int dosinglestart;
    private int dostats;
    private int optimize;
    private int dooptimize;
    private int optimizetext;
    private int oldkingdomtext;
    private int domaploop;
    private int dooldkingdom;
    private int oldkingdom;
    private int maplooptext;
    private int doallied;
    private int allied;
    private int alliedtext;
    private int shrowdtext;
    private int mirror;
    private int domirror;
    private int mirrortext;
    private int blockcenter;
    private int dofirsttech;
    private int firsttech;
    private int firsttechtext;
    private int doblockcenter;
    private int blockcentertext;
    private int opt1;
    private int opt2;
    private int opt3;
    private int opt4;
    private int opt5;
    private int opt6;
    private int opt7;
    private int opt8;
    private int opt9;
    private int opt10;
    private int opt11;
    private int opt12;
    private int cancelID;
    private int o1;
    private int o2;
    private int o3;
    private int o16;
    private int o17;
    private int o4;
    private int o5;
    private int o18;
    private int o6;
    private int o7;
    private int o8;
    private int o9;
    private int o10;
    private int o11;
    private int o12;
    private int o13;
    private int o14;
    private int o15;
    private int o19;
    private int w1;
    private int w2;
    private int w3;
    private int w4;
    private int w5;
    private int w6;
    private int w7;
    private int w8;
    private int w9;
    private int w10;
    private int w11;
    private int w12;
    private int w13;
    private int w14;
    private int w15;
    private int w16;
    private int w17;
    private int w21;
    private int r1;
    private int r2;
    private int r3;
    private int r4;
    private int r5;
    private int r6;
    private int r7;
    private int r8;
    private int r9;
    private int r10;
    private int r11;
    private int r12;
    private int r13;
    private int r14;
    private int r15;
    private int r16;
    private int r17;
    private int r21;
    private int r26;
    private int r27;
    private int r28;
    private int h1;
    private int h2;
    private int h3;
    private int h4;
    private int h5;
    private int h6;
    private int h7;
    private int h8;
    private int h9;
    private int h10;
    private int h11;
    private int h12;
    private int optr1;
    private int optr2;
    private int optr3;
    private int optr4;
    private int optr5;
    private int optr6;
    private int optr7;
    private int optr8;
    private int z1;
    private int z2;
    private int Srawuse;
    private ListClass RegimeListObj;
    private int RegimeListId;
    private float tempBlink;
    private int detailnr;
    private int totvp;
    private int opt1v;
    private int opt2v;
    private int opt3v;
    private int opt4v;
    private int opt5v;
    private int opt6v;
    private int opt7v;
    private int opt8v;
    private int opt9v;
    private int opt10v;
    private int opt11v;
    private int opt12v;
    private int WATER;
    private int[] TownSize;
    private bool[] TownCapitol;
    private int GRASS;
    private int HIGHMOUNTAIN;
    private int LOWMOUNTAIN;
    private int LIGHTFOREST;
    private int HEAVYFOREST;
    private int SMALLRIVER;
    private int URBAN;
    private int LIGHTURBAN;
    private int FARMLAND;
    private int BIGRIVER;
    private int SWAMP;
    private int landcur;
    private int mountaincur;
    private int forestcur;
    private int rivercur;
    private int[] tempx;
    private int[] tempy;
    private int tempcount;
    private string[] namelist;
    private int namecount;
    private string domasterfile;
    private int masterfile;
    private int masterfiletext;
    private string Flag1;
    private string Flag1b;
    private int[,,] curriv;
    private int[,,] rivstep;
    private Coordinate[,,] nextrivstep;
    private int RESOURCESLOT;
    private int Sworldsize;
    private int Splayer;
    private int Swater;
    private int Sclimate;
    private int Scrate;
    private int Spop;
    private int Sraw;
    private int[] RegFavClimate;
    private int[] Regid;
    private object[,] town;
    private object[,] town2;

    public RandomWindowClass(ref GameClass tGame, bool Marc)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND2MARC)
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

    public RandomWindowClass(ref GameClass tGame)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND2MARC)
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

    public void RandomSetup()
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

    public void DoStuffShort()
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
      SubPartClass tsubpart1 = (SubPartClass) new ATTextPartClass("Make Random Scenario Gold", this.game.VicFont8, 810, 35, true, tBlackBack: true);
      this.TempText = this.AddSubPart(ref tsubpart1, 100, 19, 850, 35, 0);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Basic settings", 150, tBackbitmap: (ref this.OwnBitmap), bbx: 300, bby: 700, tred: (this.tabmode == 0));
      this.tab1 = this.AddSubPart(ref tsubpart2, 300, 700, 150, 35, 1);
      SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Extra settings", 150, tBackbitmap: (ref this.OwnBitmap), bbx: 500, bby: 700, tred: (this.tabmode == 1));
      this.tab2 = this.AddSubPart(ref tsubpart3, 500, 700, 150, 35, 1);
      DrawMod.DrawBlock(ref Expression, 35, 80, 935, 590, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) Math.Round((double) this.game.VicColor4.A / 2.0));
      DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref Expression, 35, 80, 935, 590, -1, -1);
      SubPartClass tsubpart4;
      if (this.tabmode == 0)
      {
        Font vicFont2 = this.game.VicFont2;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "noworldsize") > 0)
        {
          this.Sworldsize = 0;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "WORLD SIZE", this.game.VicFont1, 100, 97, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart5 = (SubPartClass) new SteveRadioPartClass(0, this.Sworldsize == 0, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 130);
          this.o1 = this.AddSubPart(ref tsubpart5, 100, 130, 35, 35, 1);
          SubPartClass tsubpart6 = (SubPartClass) new SteveRadioPartClass(0, this.Sworldsize == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 170);
          this.o2 = this.AddSubPart(ref tsubpart6, 100, 170, 35, 35, 1);
          SubPartClass tsubpart7 = (SubPartClass) new SteveRadioPartClass(0, this.Sworldsize == 2, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 210);
          this.o3 = this.AddSubPart(ref tsubpart7, 100, 210, 35, 35, 1);
          SubPartClass tsubpart8 = (SubPartClass) new SteveRadioPartClass(0, this.Sworldsize == 3, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 250);
          this.o4 = this.AddSubPart(ref tsubpart8, 100, 250, 35, 35, 1);
          SubPartClass tsubpart9 = (SubPartClass) new SteveRadioPartClass(0, this.Sworldsize == 4, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 290);
          this.o5 = this.AddSubPart(ref tsubpart9, 100, 290, 35, 35, 1);
          SubPartClass tsubpart10 = (SubPartClass) new SteveRadioPartClass(0, this.Sworldsize == 5, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 330);
          this.o6 = this.AddSubPart(ref tsubpart10, 100, 330, 35, 35, 1);
          DrawMod.DrawTextVic2(ref Expression, "SMALL", vicFont2, 150, 138, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "MEDIUM", vicFont2, 150, 178, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "LARGE", vicFont2, 150, 218, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "X-LARGE", vicFont2, 150, 258, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "XX-LARGE", vicFont2, 150, 298, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "UNPLAYABLY LARGE", vicFont2, 150, 338, this.game.VicColor2, this.game.VicColor2Shade);
        }
        DrawMod.DrawTextVic2(ref Expression, "PLAYERS", this.game.VicFont1, 370, 97, this.game.VicColor2, this.game.VicColor2Shade);
        int num = 14;
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
          SubPartClass tsubpart11 = (SubPartClass) new SteveRadioPartClass(0, this.Splayer == 0, tBackbitmap: (ref this.OwnBitmap), bbx: 370, bby: 130);
          this.w1 = this.AddSubPart(ref tsubpart11, 370, 130, 35, 35, 1);
        }
        if (num >= 3)
        {
          SubPartClass tsubpart12 = (SubPartClass) new SteveRadioPartClass(0, this.Splayer == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 370, bby: 170);
          this.w2 = this.AddSubPart(ref tsubpart12, 370, 170, 35, 35, 1);
        }
        if (num >= 4)
        {
          SubPartClass tsubpart13 = (SubPartClass) new SteveRadioPartClass(0, this.Splayer == 2, tBackbitmap: (ref this.OwnBitmap), bbx: 370, bby: 210);
          this.w3 = this.AddSubPart(ref tsubpart13, 370, 210, 35, 35, 1);
        }
        if (num >= 5)
        {
          SubPartClass tsubpart14 = (SubPartClass) new SteveRadioPartClass(0, this.Splayer == 3, tBackbitmap: (ref this.OwnBitmap), bbx: 370, bby: 250);
          this.w4 = this.AddSubPart(ref tsubpart14, 370, 250, 35, 35, 1);
        }
        if (num >= 6)
        {
          SubPartClass tsubpart15 = (SubPartClass) new SteveRadioPartClass(0, this.Splayer == 4, tBackbitmap: (ref this.OwnBitmap), bbx: 370, bby: 290);
          this.w5 = this.AddSubPart(ref tsubpart15, 370, 290, 35, 35, 1);
        }
        if (num >= 7)
        {
          SubPartClass tsubpart16 = (SubPartClass) new SteveRadioPartClass(0, this.Splayer == 5, tBackbitmap: (ref this.OwnBitmap), bbx: 370, bby: 330);
          this.w6 = this.AddSubPart(ref tsubpart16, 370, 330, 35, 35, 1);
        }
        if (num >= 8)
        {
          SubPartClass tsubpart17 = (SubPartClass) new SteveRadioPartClass(0, this.Splayer == 6, tBackbitmap: (ref this.OwnBitmap), bbx: 530, bby: 130);
          this.w11 = this.AddSubPart(ref tsubpart17, 530, 130, 35, 35, 1);
        }
        if (num >= 9)
        {
          SubPartClass tsubpart18 = (SubPartClass) new SteveRadioPartClass(0, this.Splayer == 7, tBackbitmap: (ref this.OwnBitmap), bbx: 530, bby: 170);
          this.w12 = this.AddSubPart(ref tsubpart18, 530, 170, 35, 35, 1);
        }
        if (num >= 10)
        {
          SubPartClass tsubpart19 = (SubPartClass) new SteveRadioPartClass(0, this.Splayer == 8, tBackbitmap: (ref this.OwnBitmap), bbx: 530, bby: 210);
          this.w13 = this.AddSubPart(ref tsubpart19, 530, 210, 35, 35, 1);
        }
        if (num >= 11)
        {
          SubPartClass tsubpart20 = (SubPartClass) new SteveRadioPartClass(0, this.Splayer == 9, tBackbitmap: (ref this.OwnBitmap), bbx: 530, bby: 250);
          this.w14 = this.AddSubPart(ref tsubpart20, 530, 250, 35, 35, 1);
        }
        if (num >= 12)
        {
          SubPartClass tsubpart21 = (SubPartClass) new SteveRadioPartClass(0, this.Splayer == 10, tBackbitmap: (ref this.OwnBitmap), bbx: 530, bby: 290);
          this.w15 = this.AddSubPart(ref tsubpart21, 530, 290, 35, 35, 1);
        }
        if (num >= 13)
        {
          SubPartClass tsubpart22 = (SubPartClass) new SteveRadioPartClass(0, this.Splayer == 11, tBackbitmap: (ref this.OwnBitmap), bbx: 530, bby: 330);
          this.w16 = this.AddSubPart(ref tsubpart22, 530, 330, 35, 35, 1);
        }
        if (num >= 14)
        {
          SubPartClass tsubpart23 = (SubPartClass) new SteveRadioPartClass(0, this.Splayer == 12, tBackbitmap: (ref this.OwnBitmap), bbx: 530, bby: 370);
          this.w17 = this.AddSubPart(ref tsubpart23, 530, 370, 35, 35, 1);
        }
        if (num >= 2)
          DrawMod.DrawTextVic2(ref Expression, "2 PLAYER", vicFont2, 420, 138, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 3)
          DrawMod.DrawTextVic2(ref Expression, "3 PLAYER", vicFont2, 420, 178, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 4)
          DrawMod.DrawTextVic2(ref Expression, "4 PLAYER", vicFont2, 420, 218, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 5)
          DrawMod.DrawTextVic2(ref Expression, "5 PLAYER", vicFont2, 420, 258, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 6)
          DrawMod.DrawTextVic2(ref Expression, "6 PLAYER", vicFont2, 420, 298, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 7)
          DrawMod.DrawTextVic2(ref Expression, "7 PLAYER", vicFont2, 420, 338, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 8)
          DrawMod.DrawTextVic2(ref Expression, "8 PLAYER", vicFont2, 580, 138, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 9)
          DrawMod.DrawTextVic2(ref Expression, "9 PLAYER", vicFont2, 580, 178, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 10)
          DrawMod.DrawTextVic2(ref Expression, "10 PLAYER", vicFont2, 580, 218, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 11)
          DrawMod.DrawTextVic2(ref Expression, "11 PLAYER", vicFont2, 580, 258, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 12)
          DrawMod.DrawTextVic2(ref Expression, "12 PLAYER", vicFont2, 580, 298, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 13)
          DrawMod.DrawTextVic2(ref Expression, "13 PLAYER", vicFont2, 580, 338, this.game.VicColor2, this.game.VicColor2Shade);
        if (num >= 14)
          DrawMod.DrawTextVic2(ref Expression, "14 PLAYER", vicFont2, 580, 378, this.game.VicColor2, this.game.VicColor2Shade);
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "noworldtype") > 0)
        {
          this.Swater = 0;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "WORLD TYPE", this.game.VicFont1, 750, 97, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart24 = (SubPartClass) new SteveRadioPartClass(0, this.Swater == 0, tBackbitmap: (ref this.OwnBitmap), bbx: 750, bby: 130);
          this.h1 = this.AddSubPart(ref tsubpart24, 750, 130, 35, 35, 1);
          SubPartClass tsubpart25 = (SubPartClass) new SteveRadioPartClass(0, this.Swater == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 750, bby: 170);
          this.h2 = this.AddSubPart(ref tsubpart25, 750, 170, 35, 35, 1);
          SubPartClass tsubpart26 = (SubPartClass) new SteveRadioPartClass(0, this.Swater == 2, tBackbitmap: (ref this.OwnBitmap), bbx: 750, bby: 210);
          this.h3 = this.AddSubPart(ref tsubpart26, 750, 210, 35, 35, 1);
          SubPartClass tsubpart27 = (SubPartClass) new SteveRadioPartClass(0, this.Swater == 3, tBackbitmap: (ref this.OwnBitmap), bbx: 750, bby: 250);
          this.h4 = this.AddSubPart(ref tsubpart27, 750, 250, 35, 35, 1);
          SubPartClass tsubpart28 = (SubPartClass) new SteveRadioPartClass(0, this.Swater == 4, tBackbitmap: (ref this.OwnBitmap), bbx: 750, bby: 290);
          this.h5 = this.AddSubPart(ref tsubpart28, 750, 290, 35, 35, 1);
          SubPartClass tsubpart29 = (SubPartClass) new SteveRadioPartClass(0, this.Swater == 5, tBackbitmap: (ref this.OwnBitmap), bbx: 750, bby: 330);
          this.h6 = this.AddSubPart(ref tsubpart29, 750, 330, 35, 35, 1);
          DrawMod.DrawTextVic2(ref Expression, "NO OCEANS", vicFont2, 800, 138, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "LAND WORLD", vicFont2, 800, 178, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "NORMAL WORLD", vicFont2, 800, 218, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "BIG OCEANS", vicFont2, 800, 258, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "OCEANIA", vicFont2, 800, 298, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "WATER WORLD", vicFont2, 800, 338, this.game.VicColor2, this.game.VicColor2Shade);
        }
        DrawMod.DrawTextVic2(ref Expression, "OPTIONS", this.game.VicFont1, 100, 417, this.game.VicColor2, this.game.VicColor2Shade);
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nomaploop") <= 0)
        {
          DrawMod.DrawTextVic2(ref Expression, "MAP LOOP", vicFont2, 150, 458, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart30 = (SubPartClass) new SteveRadioPartClass(0, this.domaploop == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 450);
          this.o7 = this.AddSubPart(ref tsubpart30, 100, 450, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nomirrorish") > 0)
        {
          this.domirror = 0;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "MIRRORISH", vicFont2, 150, 498, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart31 = (SubPartClass) new SteveRadioPartClass(0, this.domirror == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 490);
          this.o8 = this.AddSubPart(ref tsubpart31, 100, 490, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "noshrowd") > 0)
        {
          this.doshrowd = 0;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "SHROUD", vicFont2, 150, 538, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart32 = (SubPartClass) new SteveRadioPartClass(0, this.doshrowd == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 530);
          this.o9 = this.AddSubPart(ref tsubpart32, 100, 530, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "no1townstart") > 0)
        {
          this.dosinglestart = 0;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "1 TOWN START", vicFont2, 150, 578, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart33 = (SubPartClass) new SteveRadioPartClass(0, this.dosinglestart == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 570);
          this.o10 = this.AddSubPart(ref tsubpart33, 100, 570, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nocostlyresearch") > 0)
        {
          this.opt11v = 100;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "COSTLY RESEARCH", vicFont2, 150, 618, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart34 = (SubPartClass) new SteveRadioPartClass(0, this.opt11v == 300, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 610);
          this.o19 = this.AddSubPart(ref tsubpart34, 100, 610, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nostoneage") > 0)
        {
          this.dofirsttech = 1;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "STONE AGE", vicFont2, 350, 458, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart35 = (SubPartClass) new SteveRadioPartClass(0, this.dofirsttech == 0, tBackbitmap: (ref this.OwnBitmap), bbx: 300, bby: 450);
          this.o12 = this.AddSubPart(ref tsubpart35, 300, 450, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nocrates") > 0)
        {
          this.Scrate = 1;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "CRATES", vicFont2, 350, 488, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "HIDDEN AI", vicFont2, 350, 508, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart36 = (SubPartClass) new SteveRadioPartClass(0, this.Scrate == 0, tBackbitmap: (ref this.OwnBitmap), bbx: 300, bby: 490);
          this.o13 = this.AddSubPart(ref tsubpart36, 300, 490, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nohiddenstats") > 0)
        {
          this.dostats = 1;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "HIDDEN STATS", vicFont2, 350, 538, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart37 = (SubPartClass) new SteveRadioPartClass(0, this.dostats == 0, tBackbitmap: (ref this.OwnBitmap), bbx: 300, bby: 530);
          this.o14 = this.AddSubPart(ref tsubpart37, 300, 530, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "noaiallied") > 0)
        {
          this.doallied = 0;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "AI ALLIED", vicFont2, 350, 578, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart38 = (SubPartClass) new SteveRadioPartClass(0, this.doallied == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 300, bby: 570);
          this.o15 = this.AddSubPart(ref tsubpart38, 300, 570, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nouseresources") > 0)
        {
          this.Srawuse = 0;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "USE RESOURCES", vicFont2, 350, 618, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart39 = (SubPartClass) new SteveRadioPartClass(0, this.Srawuse == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 300, bby: 610);
          this.z1 = this.AddSubPart(ref tsubpart39, 300, 610, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "noroads") > 0)
        {
          this.opt9v = 0;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "NO ROADS", vicFont2, 550, 458, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart40 = (SubPartClass) new SteveRadioPartClass(0, this.opt9v == 0, tBackbitmap: (ref this.OwnBitmap), bbx: 500, bby: 450);
          this.o11 = this.AddSubPart(ref tsubpart40, 500, 450, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nowildlands") > 0)
        {
          this.Spop = 0;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "WILD LAND", vicFont2, 550, 498, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart41 = (SubPartClass) new SteveRadioPartClass(0, this.Spop == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 500, bby: 490);
          this.o16 = this.AddSubPart(ref tsubpart41, 500, 490, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nodepletedlands") > 0)
        {
          this.Sraw = 0;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "DEPLETED LAND", vicFont2, 550, 538, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart42 = (SubPartClass) new SteveRadioPartClass(0, this.Sraw == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 500, bby: 530);
          this.o17 = this.AddSubPart(ref tsubpart42, 500, 530, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nodesertedlands") > 0)
        {
          this.Spop = 0;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "DESERTED LANDS", vicFont2, 550, 578, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart43 = (SubPartClass) new SteveRadioPartClass(0, this.Spop == 2, tBackbitmap: (ref this.OwnBitmap), bbx: 500, bby: 570);
          this.o18 = this.AddSubPart(ref tsubpart43, 500, 570, 35, 35, 1);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nochangemaster") <= 0)
        {
          tsubpart4 = (SubPartClass) new SteveRadioPartClass(0, false, tBackbitmap: (ref this.OwnBitmap), bbx: 500, bby: 610);
          this.z2 = this.AddSubPart(ref tsubpart4, 500, 610, 35, 35, 1);
          DrawMod.DrawTextVic2(ref Expression, Strings.Left(this.domasterfile, Math.Min(Strings.Len(this.domasterfile), 14)), vicFont2, 550, 618, this.game.VicColor2, this.game.VicColor2Shade);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "noweather") > 0)
        {
          this.Sclimate = 0;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "CLIMATE", this.game.VicFont1, 750, 417, this.game.VicColor2, this.game.VicColor2Shade);
          tsubpart4 = (SubPartClass) new SteveRadioPartClass(0, this.Sclimate == 0, tBackbitmap: (ref this.OwnBitmap), bbx: 750, bby: 450);
          this.w7 = this.AddSubPart(ref tsubpart4, 750, 450, 35, 35, 1);
          tsubpart4 = (SubPartClass) new SteveRadioPartClass(0, this.Sclimate == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 750, bby: 490);
          this.w8 = this.AddSubPart(ref tsubpart4, 750, 490, 35, 35, 1);
          tsubpart4 = (SubPartClass) new SteveRadioPartClass(0, this.Sclimate == 2, tBackbitmap: (ref this.OwnBitmap), bbx: 750, bby: 530);
          this.w9 = this.AddSubPart(ref tsubpart4, 750, 530, 35, 35, 1);
          tsubpart4 = (SubPartClass) new SteveRadioPartClass(0, this.Sclimate == 3, tBackbitmap: (ref this.OwnBitmap), bbx: 750, bby: 570);
          this.w10 = this.AddSubPart(ref tsubpart4, 750, 570, 35, 35, 1);
          tsubpart4 = (SubPartClass) new SteveRadioPartClass(0, this.Sclimate == 4, tBackbitmap: (ref this.OwnBitmap), bbx: 750, bby: 610);
          this.w21 = this.AddSubPart(ref tsubpart4, 750, 610, 35, 35, 1);
          DrawMod.DrawTextVic2(ref Expression, "NO CLIMATE", vicFont2, 800, 460, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "FULL RANGE", vicFont2, 800, 500, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "ARCTIC-TEMPERATE", vicFont2, 800, 540, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "SUBTROPIC-TROPIC", vicFont2, 800, 580, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "TEMPERATE", vicFont2, 800, 620, this.game.VicColor2, this.game.VicColor2Shade);
        }
      }
      else if (this.tabmode == 1)
      {
        Font vicFont2 = this.game.VicFont2;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nocontinentalsize") > 0)
        {
          this.optr1 = 0;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "CONTINENTAL SIZE", this.game.VicFont1, 100, 97, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart44 = (SubPartClass) new SteveRadioPartClass(0, this.optr1 == -2, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 130);
          this.r1 = this.AddSubPart(ref tsubpart44, 100, 130, 35, 35, 1);
          SubPartClass tsubpart45 = (SubPartClass) new SteveRadioPartClass(0, this.optr1 == -1, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 170);
          this.r2 = this.AddSubPart(ref tsubpart45, 100, 170, 35, 35, 1);
          SubPartClass tsubpart46 = (SubPartClass) new SteveRadioPartClass(0, this.optr1 == 0, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 210);
          this.r3 = this.AddSubPart(ref tsubpart46, 100, 210, 35, 35, 1);
          SubPartClass tsubpart47 = (SubPartClass) new SteveRadioPartClass(0, this.optr1 == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 250);
          this.r4 = this.AddSubPart(ref tsubpart47, 100, 250, 35, 35, 1);
          SubPartClass tsubpart48 = (SubPartClass) new SteveRadioPartClass(0, this.optr1 == 2, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 290);
          this.r5 = this.AddSubPart(ref tsubpart48, 100, 290, 35, 35, 1);
          DrawMod.DrawTextVic2(ref Expression, "TINY", vicFont2, 150, 138, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "SMALL", vicFont2, 150, 178, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "NORMAL", vicFont2, 150, 218, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "BIG", vicFont2, 150, 258, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "PANGEAIC", vicFont2, 150, 298, this.game.VicColor2, this.game.VicColor2Shade);
        }
        int num = 50;
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nohumidity") > 0)
        {
          this.optr2 = 0;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "HUMIDITY", this.game.VicFont1, 370 + num, 97, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart49 = (SubPartClass) new SteveRadioPartClass(0, this.optr2 == -2, tBackbitmap: (ref this.OwnBitmap), bbx: (370 + num), bby: 130);
          this.r6 = this.AddSubPart(ref tsubpart49, 370 + num, 130, 35, 35, 1);
          SubPartClass tsubpart50 = (SubPartClass) new SteveRadioPartClass(0, this.optr2 == -1, tBackbitmap: (ref this.OwnBitmap), bbx: (370 + num), bby: 170);
          this.r7 = this.AddSubPart(ref tsubpart50, 370 + num, 170, 35, 35, 1);
          SubPartClass tsubpart51 = (SubPartClass) new SteveRadioPartClass(0, this.optr2 == 0, tBackbitmap: (ref this.OwnBitmap), bbx: (370 + num), bby: 210);
          this.r8 = this.AddSubPart(ref tsubpart51, 370 + num, 210, 35, 35, 1);
          SubPartClass tsubpart52 = (SubPartClass) new SteveRadioPartClass(0, this.optr2 == 1, tBackbitmap: (ref this.OwnBitmap), bbx: (370 + num), bby: 250);
          this.r9 = this.AddSubPart(ref tsubpart52, 370 + num, 250, 35, 35, 1);
          SubPartClass tsubpart53 = (SubPartClass) new SteveRadioPartClass(0, this.optr2 == 2, tBackbitmap: (ref this.OwnBitmap), bbx: (370 + num), bby: 290);
          this.r10 = this.AddSubPart(ref tsubpart53, 370 + num, 290, 35, 35, 1);
          DrawMod.DrawTextVic2(ref Expression, "ARID WORLD", vicFont2, 420 + num, 138, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "DRY WORLD", vicFont2, 420 + num, 178, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "NORMAL", vicFont2, 420 + num, 218, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "WET WORLD", vicFont2, 420 + num, 258, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "RAIN WORLD", vicFont2, 420 + num, 298, this.game.VicColor2, this.game.VicColor2Shade);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nogeologicalage") > 0)
        {
          this.optr3 = 0;
        }
        else
        {
          DrawMod.DrawTextVic2(ref Expression, "GEOLOGICAL AGE", this.game.VicFont1, 750, 97, this.game.VicColor2, this.game.VicColor2Shade);
          SubPartClass tsubpart54 = (SubPartClass) new SteveRadioPartClass(0, this.optr3 == -2, tBackbitmap: (ref this.OwnBitmap), bbx: 750, bby: 130);
          this.r11 = this.AddSubPart(ref tsubpart54, 750, 130, 35, 35, 1);
          SubPartClass tsubpart55 = (SubPartClass) new SteveRadioPartClass(0, this.optr3 == -1, tBackbitmap: (ref this.OwnBitmap), bbx: 750, bby: 170);
          this.r12 = this.AddSubPart(ref tsubpart55, 750, 170, 35, 35, 1);
          SubPartClass tsubpart56 = (SubPartClass) new SteveRadioPartClass(0, this.optr3 == 0, tBackbitmap: (ref this.OwnBitmap), bbx: 750, bby: 210);
          this.r13 = this.AddSubPart(ref tsubpart56, 750, 210, 35, 35, 1);
          SubPartClass tsubpart57 = (SubPartClass) new SteveRadioPartClass(0, this.optr3 == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 750, bby: 250);
          this.r14 = this.AddSubPart(ref tsubpart57, 750, 250, 35, 35, 1);
          SubPartClass tsubpart58 = (SubPartClass) new SteveRadioPartClass(0, this.optr3 == 2, tBackbitmap: (ref this.OwnBitmap), bbx: 750, bby: 290);
          this.r15 = this.AddSubPart(ref tsubpart58, 750, 290, 35, 35, 1);
          DrawMod.DrawTextVic2(ref Expression, "VERY YOUNG", vicFont2, 800, 138, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "YOUNG", vicFont2, 800, 178, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "NORMAL", vicFont2, 800, 218, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "OLD", vicFont2, 800, 258, this.game.VicColor2, this.game.VicColor2Shade);
          DrawMod.DrawTextVic2(ref Expression, "ANCIENT", vicFont2, 800, 298, this.game.VicColor2, this.game.VicColor2Shade);
        }
        DrawMod.DrawTextVic2(ref Expression, "EXTRA OPTIONS", this.game.VicFont1, 100, 417, this.game.VicColor2, this.game.VicColor2Shade);
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nolimitedroads") > 0)
        {
          this.optr4 = 0;
        }
        else
        {
          SubPartClass tsubpart59 = (SubPartClass) new SteveRadioPartClass(0, this.optr4 == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 450);
          this.r16 = this.AddSubPart(ref tsubpart59, 100, 450, 35, 35, 1);
          DrawMod.DrawTextVic2(ref Expression, "LIMITED INITIAL ROADS", vicFont2, 150, 458, this.game.VicColor2, this.game.VicColor2Shade);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nonaturalcoastlines") > 0)
        {
          this.optr5 = 0;
        }
        else
        {
          SubPartClass tsubpart60 = (SubPartClass) new SteveRadioPartClass(0, this.optr5 == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 490);
          this.r17 = this.AddSubPart(ref tsubpart60, 100, 490, 35, 35, 1);
          DrawMod.DrawTextVic2(ref Expression, "NATURAL COASTLINES", vicFont2, 150, 498, this.game.VicColor2, this.game.VicColor2Shade);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nonofarm") > 0)
        {
          this.optr6 = 0;
        }
        else
        {
          SubPartClass tsubpart61 = (SubPartClass) new SteveRadioPartClass(0, this.optr6 == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 530);
          this.r26 = this.AddSubPart(ref tsubpart61, 100, 530, 35, 35, 1);
          DrawMod.DrawTextVic2(ref Expression, "NO FARMLANDS", vicFont2, 150, 538, this.game.VicColor2, this.game.VicColor2Shade);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nonosuburb") > 0)
        {
          this.optr7 = 0;
        }
        else
        {
          SubPartClass tsubpart62 = (SubPartClass) new SteveRadioPartClass(0, this.optr7 == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 570);
          this.r27 = this.AddSubPart(ref tsubpart62, 100, 570, 35, 35, 1);
          DrawMod.DrawTextVic2(ref Expression, "NO SUBURBS", vicFont2, 150, 578, this.game.VicColor2, this.game.VicColor2Shade);
        }
        if (Strings.InStr(this.game.EditObj.RandomSettingsFromMod, "nohigherprodcost") > 0)
        {
          this.optr8 = 0;
        }
        else
        {
          SubPartClass tsubpart63 = (SubPartClass) new SteveRadioPartClass(0, this.optr8 == 1, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 610);
          this.r28 = this.AddSubPart(ref tsubpart63, 100, 610, 35, 35, 1);
          DrawMod.DrawTextVic2(ref Expression, "HIGHER PROD. COST", vicFont2, 150, 618, this.game.VicColor2, this.game.VicColor2Shade);
        }
      }
      tsubpart4 = (SubPartClass) new TextButtonPartClass("Make", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 880, bby: 700);
      this.BStartGameID = this.AddSubPart(ref tsubpart4, 880, 700, 100, 35, 1);
      tsubpart4 = (SubPartClass) new SteveButtonPartClass(this.game.BACKBUTTON, tBackbitmap: (ref this.OwnBitmap), bbx: 30, bby: 700);
      this.cancelID = this.AddSubPart(ref tsubpart4, 30, 700, 35, 35, 1);
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    public void DoStuff()
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
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("Make Random Scenario", new Font("Arial Black", 19f, FontStyle.Regular, GraphicsUnit.Pixel), 450, 27, false, tBlackBack: true);
        this.TempText = this.AddSubPart(ref tsubpart, 200, 19, 150, 16, 0);
        tsubpart = (SubPartClass) new NumberSliderSubPartClass3(this.game, "Width= ", " hex ", 400, 10, 100, this.opt1v, tbackbitmap: (ref this.OwnBitmap), bbx: 200, bby: 100);
        this.opt1 = this.AddSubPart(ref tsubpart, 200, 100, 400, 22, 0);
        tsubpart = (SubPartClass) new NumberSliderSubPartClass3(this.game, "Towns= ", "x ", 400, 0, 100, this.opt8v, tbackbitmap: (ref this.OwnBitmap), bbx: 200, bby: 390);
        this.opt8 = this.AddSubPart(ref tsubpart, 200, 390, 400, 22, 0);
        tsubpart = (SubPartClass) new NumberSliderSubPartClass3(this.game, "Height= ", " hex ", 400, 10, 100, this.opt2v, tbackbitmap: (ref this.OwnBitmap), bbx: 200, bby: 140);
        this.opt2 = this.AddSubPart(ref tsubpart, 200, 140, 400, 22, 0);
        tsubpart = (SubPartClass) new NumberSliderSubPartClass3(this.game, "Roads= level ", "", 400, 0, 5, this.opt9v, tbackbitmap: (ref this.OwnBitmap), bbx: 200, bby: 430);
        this.opt9 = this.AddSubPart(ref tsubpart, 200, 430, 400, 22, 0);
        tsubpart = (SubPartClass) new NumberSliderSubPartClass3(this.game, "Players= ", " regimes ", 400, 2, 10, this.opt3v, tbackbitmap: (ref this.OwnBitmap), bbx: 200, bby: 180);
        this.opt3 = this.AddSubPart(ref tsubpart, 200, 180, 400, 22, 0);
        tsubpart = (SubPartClass) new NumberSliderSubPartClass3(this.game, "City Size= ", "", 400, 1, 4, this.opt10v, tbackbitmap: (ref this.OwnBitmap), bbx: 200, bby: 470);
        this.opt10 = this.AddSubPart(ref tsubpart, 200, 470, 400, 22, 0);
        tsubpart = (SubPartClass) new NumberSliderSubPartClass3(this.game, "Land = ", "%", 400, 10, 100, this.opt4v, tbackbitmap: (ref this.OwnBitmap), bbx: 200, bby: 220);
        this.opt4 = this.AddSubPart(ref tsubpart, 200, 220, 400, 22, 0);
        tsubpart = (SubPartClass) new NumberSliderSubPartClass3(this.game, "Research mod= ", "% ", 400, 20, 500, this.opt11v, tbackbitmap: (ref this.OwnBitmap), bbx: 200, bby: 510);
        this.opt11 = this.AddSubPart(ref tsubpart, 200, 510, 400, 22, 0);
        tsubpart = (SubPartClass) new NumberSliderSubPartClass3(this.game, "Rivers = ", "% ", 400, 0, 100, this.opt5v, tbackbitmap: (ref this.OwnBitmap), bbx: 200, bby: 260);
        this.opt5 = this.AddSubPart(ref tsubpart, 200, 260, 400, 22, 0);
        tsubpart = (SubPartClass) new NumberSliderSubPartClass3(this.game, "Swamp= level", "", 400, 0, 100, this.opt12v, tbackbitmap: (ref this.OwnBitmap), bbx: 200, bby: 550);
        this.opt12 = this.AddSubPart(ref tsubpart, 200, 550, 400, 22, 0);
        tsubpart = (SubPartClass) new NumberSliderSubPartClass3(this.game, "Forests = level ", "", 400, 0, 100, this.opt6v, tbackbitmap: (ref this.OwnBitmap), bbx: 200, bby: 300);
        this.opt6 = this.AddSubPart(ref tsubpart, 200, 300, 400, 22, 0);
        tsubpart = (SubPartClass) new NumberSliderSubPartClass3(this.game, "Mountains = level ", "", 400, 0, 100, this.opt7v, tbackbitmap: (ref this.OwnBitmap), bbx: 200, bby: 340);
        this.opt7 = this.AddSubPart(ref tsubpart, 200, 340, 400, 22, 0);
        if (this.dooptimize == 0)
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 260);
          this.optimize = this.AddSubPart(ref tsubpart, 700, 220, 35, 35, 1);
        }
        else
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 260);
          this.optimize = this.AddSubPart(ref tsubpart, 700, 220, 35, 35, 1);
        }
        tsubpart = (SubPartClass) new TextPartClass("Optimize for AI", new Font("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
        this.optimizetext = this.AddSubPart(ref tsubpart, 750, 229, 150, 16, 0);
        if (this.dooldkingdom == 0)
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 260);
          this.oldkingdom = this.AddSubPart(ref tsubpart, 700, 260, 35, 35, 1);
        }
        else
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 260);
          this.oldkingdom = this.AddSubPart(ref tsubpart, 700, 260, 35, 35, 1);
        }
        tsubpart = (SubPartClass) new TextPartClass("People's Republic", new Font("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
        this.oldkingdomtext = this.AddSubPart(ref tsubpart, 750, 269, 150, 16, 0);
        if (this.domaploop == 0)
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 300);
          this.maploop = this.AddSubPart(ref tsubpart, 700, 300, 35, 35, 1);
        }
        else
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 300);
          this.maploop = this.AddSubPart(ref tsubpart, 700, 300, 35, 35, 1);
        }
        tsubpart = (SubPartClass) new TextPartClass("Map Loop", new Font("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
        this.maplooptext = this.AddSubPart(ref tsubpart, 750, 309, 150, 16, 0);
        if (this.doshrowd == 0)
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 340);
          this.shrowd = this.AddSubPart(ref tsubpart, 700, 340, 35, 35, 1);
        }
        else
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 340);
          this.shrowd = this.AddSubPart(ref tsubpart, 700, 340, 35, 35, 1);
        }
        tsubpart = (SubPartClass) new TextPartClass("Shrouded Map", new Font("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
        this.shrowdtext = this.AddSubPart(ref tsubpart, 750, 349, 150, 16, 0);
        if (this.opt3v == 2)
        {
          if (this.domirror == 0)
          {
            tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 380);
            this.mirror = this.AddSubPart(ref tsubpart, 700, 380, 35, 35, 1);
          }
          else
          {
            tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 380);
            this.mirror = this.AddSubPart(ref tsubpart, 700, 380, 35, 35, 1);
          }
          tsubpart = (SubPartClass) new TextPartClass("Mirror Map", new Font("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
          this.mirrortext = this.AddSubPart(ref tsubpart, 750, 389, 150, 16, 0);
        }
        else
          this.domirror = 0;
        if (this.doblockcenter == 0)
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 420);
          this.blockcenter = this.AddSubPart(ref tsubpart, 700, 420, 35, 35, 1);
        }
        else
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 420);
          this.blockcenter = this.AddSubPart(ref tsubpart, 700, 420, 35, 35, 1);
        }
        tsubpart = (SubPartClass) new TextPartClass("Block Center", new Font("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
        this.blockcentertext = this.AddSubPart(ref tsubpart, 750, 429, 150, 16, 0);
        if (this.dofirsttech == 0)
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 460);
          this.firsttech = this.AddSubPart(ref tsubpart, 700, 460, 35, 35, 1);
        }
        else
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 460);
          this.firsttech = this.AddSubPart(ref tsubpart, 700, 460, 35, 35, 1);
        }
        tsubpart = (SubPartClass) new TextPartClass("Full 1st Level Tech", new Font("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
        this.firsttechtext = this.AddSubPart(ref tsubpart, 750, 469, 150, 16, 0);
        if (this.doallied == 0)
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 460);
          this.allied = this.AddSubPart(ref tsubpart, 700, 500, 35, 35, 1);
        }
        else
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 460);
          this.allied = this.AddSubPart(ref tsubpart, 700, 500, 35, 35, 1);
        }
        tsubpart = (SubPartClass) new TextPartClass("Allied AIs", new Font("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
        this.alliedtext = this.AddSubPart(ref tsubpart, 750, 509, 150, 16, 0);
        Bitmap bitmap = (Bitmap) null;
        tsubpart = (SubPartClass) new TextButtonPartClass("M", 35, tBackbitmap: (ref bitmap));
        this.masterfile = this.AddSubPart(ref tsubpart, 700, 540, 35, 35, 1);
        tsubpart = (SubPartClass) new TextPartClass("MASTER: " + this.domasterfile, new Font("Times New Roman", 11f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 16, false);
        this.masterfiletext = this.AddSubPart(ref tsubpart, 750, 549, 150, 16, 0);
        tsubpart = (SubPartClass) new TextButtonPartClass("Make", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 50, bby: 485);
        this.BStartGameID = this.AddSubPart(ref tsubpart, 460, 700, 100, 35, 1);
        tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.BACKBUTTON, tBackbitmap: (ref this.OwnBitmap), bbx: 30, bby: 700);
        this.cancelID = this.AddSubPart(ref tsubpart, 30, 700, 35, 35, 1);
      }
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num1 = this.SubPartID[index];
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
              int num2 = (int) Interaction.MsgBox((object) "A random ladder map is succesfully made!", Title: ((object) "Shadow Empire : Planetary Conquest"));
              this.game.FormRef.Cursor = Cursors.Default;
              this.game.Data.EditPass = "Heinrici45";
              this.game.Data.Description = "";
              this.game.Data.Description += "This scenario is generated for competitive play. The winner is the player who has most points at the start of round 10. If both players have the same amount of points, a draw is declared.";
              this.game.Data.Description += "\r\n\r\nPlayers earn points by capturing victory point locations as well as destroying enemy troops. Each victory point held is worth 100 points. Each enemy power point destroyed is worth 1 point.";
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
                  this.opt6v = (int) Math.Round(30.0 + (double) VBMath.Rnd() * 40.0);
                }
                if (this.Swater == 1)
                {
                  this.opt4v = 80;
                  this.opt5v = 45;
                  this.opt12v = 10;
                  this.opt6v = (int) Math.Round(40.0 + (double) VBMath.Rnd() * 30.0);
                }
                if (this.Swater == 2)
                {
                  this.opt4v = 66;
                  this.opt5v = 52;
                  this.opt12v = 12;
                  this.opt6v = (int) Math.Round(45.0 + (double) VBMath.Rnd() * 20.0);
                }
                if (this.Swater == 3)
                {
                  this.opt4v = 50;
                  this.opt5v = 60;
                  this.opt12v = 15;
                  this.opt7v = (int) Math.Round(50.0 + (double) VBMath.Rnd() * 10.0);
                }
                if (this.Swater == 4)
                {
                  this.opt4v = 35;
                  this.opt5v = 70;
                  this.opt12v = 18;
                  this.opt7v = (int) Math.Round(55.0 + (double) VBMath.Rnd() * 10.0);
                }
                if (this.Swater == 5)
                {
                  this.opt4v = 20;
                  this.opt5v = 80;
                  this.opt12v = 20;
                  this.opt7v = (int) Math.Round(60.0 + (double) VBMath.Rnd() * 10.0);
                }
                if (this.Sworldsize == 0)
                {
                  this.opt1v = 40;
                  this.opt2v = 20;
                  this.opt8v = 7;
                  this.opt5v = (int) Math.Round((double) this.opt5v / 8.0);
                }
                if (this.Sworldsize == 1)
                {
                  this.opt1v = 60;
                  this.opt2v = 30;
                  this.opt8v = 14;
                  this.opt5v = (int) Math.Round((double) this.opt5v / 5.0);
                }
                if (this.Sworldsize == 2)
                {
                  this.opt1v = 70;
                  this.opt2v = 40;
                  this.opt8v = 30;
                  this.opt5v = (int) Math.Round((double) this.opt5v / 2.0);
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
                  this.opt8v = (int) Math.Round((double) this.opt8v * 1.3);
                if (this.Swater == 1)
                  this.opt8v = (int) Math.Round((double) this.opt8v * 1.2);
                if (this.Swater == 2)
                  this.opt8v *= 1;
                if (this.Swater == 3)
                  this.opt8v = (int) Math.Round((double) this.opt8v * 0.8);
                if (this.Swater == 4)
                  this.opt8v = (int) Math.Round((double) this.opt8v * 0.66);
                if (this.Swater == 5)
                  this.opt8v = (int) Math.Round((double) this.opt8v * 0.5);
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
                  this.opt8v = (int) Math.Round((double) this.opt8v / 2.0);
                  this.opt6v = (int) Math.Round((double) this.opt6v * 1.5);
                  this.opt7v = (int) Math.Round((double) this.opt7v * 1.33);
                }
                if (this.Spop == 2)
                {
                  this.opt8v = (int) Math.Round((double) this.opt8v / 4.0);
                  this.opt6v = (int) Math.Round((double) this.opt6v * 1.5);
                  this.opt7v = (int) Math.Round((double) this.opt7v * 1.33);
                }
                if (this.domaploop == 0)
                  this.doblockcenter = 1;
                this.opt6v = (int) Math.Round(20.0 + (double) VBMath.Rnd() * 20.0);
                this.opt7v = (int) Math.Round(20.0 + (double) VBMath.Rnd() * 20.0);
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
                  this.opt5v = (int) Math.Round((double) this.opt5v / 3.0);
                  this.opt12v = (int) Math.Round((double) this.opt12v / 5.0);
                  this.opt6v = (int) Math.Round((double) this.opt6v / 4.0);
                }
                if (this.optr2 == 1)
                {
                  this.opt5v = (int) Math.Round((double) this.opt5v * 1.5);
                  this.opt12v *= 2;
                  this.opt6v += 10;
                  this.opt6v = (int) Math.Round((double) this.opt6v * 1.5);
                }
                if (this.optr2 == 2)
                {
                  this.opt5v = (int) Math.Round((double) this.opt5v * 2.2);
                  this.opt12v *= 3;
                  this.opt6v += 20;
                  this.opt6v = (int) Math.Round((double) this.opt6v * 2.2);
                }
                if (this.optr3 == -2)
                {
                  this.opt7v += 20;
                  this.opt7v = (int) Math.Round((double) this.opt7v * 3.2);
                }
                if (this.optr3 == -1)
                {
                  this.opt7v += 10;
                  this.opt7v = (int) Math.Round((double) this.opt7v * 1.8);
                }
                if (this.optr3 == 1)
                  this.opt7v = (int) Math.Round((double) this.opt7v / 1.8);
                if (this.optr3 == 2)
                  this.opt7v = (int) Math.Round((double) this.opt7v / 3.2);
                this.domasterfile = this.game.EditObj.RandomUseMaster;
                this.dooldkingdom = 0;
                this.dooptimize = 0;
              }
              this.game.FormRef.Cursor = Cursors.WaitCursor;
              this.MakeRandomMap();
              if ((double) this.game.Data.RuleVar[418] > 0.0)
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
                string str = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a masterfile to use...", this.game.AppPath + this.game.ModScenarioDir, true);
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
                int num3 = (int) Interaction.MsgBox((object) "Aborted.", Title: ((object) "Shadow Empire : Planetary Conquest"));
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

    public void MakeRandomMap()
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
          ++this.opt1v;
        if (this.opt2v % 2 == 0)
          ++this.opt2v;
        if (this.opt8v % 2 > 0)
          ++this.opt8v;
      }
      int opt1v = this.opt1v;
      int opt2v = this.opt2v;
      int opt3v = this.opt3v;
      int opt4v = this.opt4v;
      this.landcur = 0;
      int num1 = (int) Math.Round(Conversion.Int((double) opt4v / 5.0 * ((double) this.opt7v / 100.0)));
      this.mountaincur = 0;
      this.game.SelectX = 0;
      this.game.SelectY = 0;
      this.rivercur = 0;
      int num2 = this.opt5v;
      if (this.domirror == 1)
        num2 = (int) Math.Round(Conversion.Int((double) num2 / 2.0));
      this.game.Data = new DataClass();
      this.game.Data.MapObj = new MapClass[1];
      if ((opt1v + 10) % 2 == 0 & this.domaploop == 1)
        ++opt1v;
      this.game.Data.MapObj[0] = new MapClass(0, 0, opt1v, opt2v);
      if (this.domaploop == 1)
        this.game.Data.MapObj[0].MapLoop = true;
      this.game.Data.MasterfileReadPeople = true;
      this.game.HandyFunctionsObj.LoadMasterFile(this.game.AppPath + this.game.ModScenarioDir + "/" + this.domasterfile, LoadDescription: this.game.EditObj.ShortRandomScreen);
      this.game.Data.FOWOn = true;
      if ((double) this.game.Data.RuleVar[418] < 1.0)
      {
        int num3 = (int) Interaction.MsgBox((object) "The selected masterfile cannot be used to make a random game.", Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      else
      {
        if (opt1v + opt2v <= 100)
          ;
        BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
        this.game.Data.LoadGraphics((Form1) null);
        if ((double) this.game.Data.RuleVar[560] > 0.0 & this.Scrate == 1)
          this.game.Data.GameSlot[(int) Math.Round((double) this.game.Data.RuleVar[560])] = 1;
        if (this.Scrate == 1)
          this.game.Data.RuleVar[496] = 0.0f;
        if (this.doshrowd == 1)
          this.game.Data.CreatedWithShrowd = true;
        else
          this.game.Data.CreatedWithShrowd = false;
        this.WATER = (int) Math.Round((double) this.game.Data.RuleVar[401]);
        this.GRASS = (int) Math.Round((double) this.game.Data.RuleVar[402]);
        this.HIGHMOUNTAIN = (int) Math.Round((double) this.game.Data.RuleVar[403]);
        this.LOWMOUNTAIN = (int) Math.Round((double) this.game.Data.RuleVar[404]);
        this.LIGHTFOREST = (int) Math.Round((double) this.game.Data.RuleVar[405]);
        this.HEAVYFOREST = (int) Math.Round((double) this.game.Data.RuleVar[406]);
        this.SMALLRIVER = (int) Math.Round((double) this.game.Data.RuleVar[407]);
        this.BIGRIVER = (int) Math.Round((double) this.game.Data.RuleVar[408]);
        this.SWAMP = (int) Math.Round((double) this.game.Data.RuleVar[417]);
        this.URBAN = (double) this.game.Data.RuleVar[444] <= 0.0 ? (int) Math.Round((double) this.game.Data.RuleVar[402]) : (int) Math.Round((double) this.game.Data.RuleVar[444]);
        this.LIGHTURBAN = !((double) this.game.Data.RuleVar[445] > 0.0 & this.optr7 == 0) ? (int) Math.Round((double) this.game.Data.RuleVar[402]) : (int) Math.Round((double) this.game.Data.RuleVar[445]);
        this.FARMLAND = !((double) this.game.Data.RuleVar[446] > 0.0 & this.optr6 == 0) ? (int) Math.Round((double) this.game.Data.RuleVar[402]) : (int) Math.Round((double) this.game.Data.RuleVar[446]);
        if (this.optr2 == -2)
          this.FARMLAND = this.GRASS;
        int num4 = opt1v;
        for (int index1 = 0; index1 <= num4; ++index1)
        {
          int num5 = opt2v;
          for (int index2 = 0; index2 <= num5; ++index2)
          {
            if (this.opt4v == 100 | this.WATER == -1)
              this.game.Data.MapObj[0].HexObj[index1, index2] = new HexClass(this.GRASS, 0, 0);
            else
              this.game.Data.MapObj[0].HexObj[index1, index2] = new HexClass(this.WATER, 0, 0);
          }
        }
        if (this.optr8 > 0)
        {
          int itemTypeCounter = this.game.Data.ItemTypeCounter;
          for (int index3 = 0; index3 <= itemTypeCounter; ++index3)
          {
            ItemTypeClass[] itemTypeObj = this.game.Data.ItemTypeObj;
            ItemTypeClass[] itemTypeClassArray = itemTypeObj;
            int index4 = index3;
            int index5 = index4;
            itemTypeClassArray[index5].ProdWeight = itemTypeObj[index4].ProdWeight * 3;
          }
        }
        if ((double) this.game.Data.RuleVar[481] > 0.0)
          this.MakeClimates();
        this.game.Data.AddRegime();
        this.game.Data.RemoveRegime(0);
        int num6 = DrawMod.RandyNumber.Next(0, 9);
        int index6 = opt3v - 1;
        int num7 = index6;
        if (num7 < 6)
          num7 = 6;
        if (num7 > 6 & num7 < 13)
          num7 = 13;
        int num8 = num7;
        for (int index7 = 0; index7 <= num8; ++index7)
          this.Regid[index7] = index7;
        VBMath.Randomize();
        int num9 = 0;
        do
        {
          int num10 = num7;
          for (int index8 = 0; index8 <= num10; ++index8)
          {
            int index9 = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) (num7 + 1)));
            int num11 = this.Regid[index8];
            this.Regid[index8] = this.Regid[index9];
            this.Regid[index9] = num11;
          }
          ++num9;
        }
        while (num9 <= 10);
        if ((double) this.game.Data.RuleVar[496] > 0.0)
        {
          ++index6;
          int num12 = num7 + 1;
          this.Regid[index6] = index6;
        }
        int num13 = index6;
        for (int regnr = 0; regnr <= num13; ++regnr)
        {
          if (regnr > 0 | this.game.Data.RegimeCounter < regnr)
            this.game.Data.AddRegime();
          this.game.Data.RegimeObj[regnr].Name = this.GetRandomRegimeName(regnr);
          this.game.Data.RegimeObj[regnr].People = 0;
          if ((double) this.game.Data.RuleVar[496] > 0.0 & index6 == regnr)
          {
            this.game.Data.RegimeObj[regnr].People = (int) Math.Round((double) this.game.Data.RuleVar[497]);
            this.game.Data.RegimeObj[regnr].DipBlock = true;
            this.game.Data.RegimeObj[regnr].Sleep = true;
          }
          if ((double) this.game.Data.RuleVar[457] == 0.0)
            this.game.Data.RegimeObj[regnr].ResPts = 20;
          else
            this.game.Data.RegimeObj[regnr].ResPts = (int) Math.Round((double) this.game.Data.RuleVar[457]);
          this.game.Data.RegimeObj[regnr].UnitName = "Division";
          this.game.Data.RegimeObj[regnr].HQName = "HQ";
          int num14 = 1;
          int d = 0;
          while (num14 == 1)
          {
            num14 = 0;
            ++d;
            this.game.Data.RegimeObj[regnr].Red = DrawMod.RandyNumber.Next(0, 235) + 20;
            this.game.Data.RegimeObj[regnr].Blue = DrawMod.RandyNumber.Next(0, 235) + 20;
            this.game.Data.RegimeObj[regnr].Green = DrawMod.RandyNumber.Next(0, 235) + 20;
            if ((double) (Math.Abs(this.game.Data.RegimeObj[regnr].Red - 0) + Math.Abs(this.game.Data.RegimeObj[regnr].Green - 0) + Math.Abs(this.game.Data.RegimeObj[regnr].Blue - 155)) <= 400.0 / Math.Sqrt(Math.Sqrt((double) d)) & d < 999)
              num14 = 1;
            int num15 = regnr;
            for (int index10 = 0; index10 <= num15; ++index10)
            {
              if (index10 != regnr)
              {
                if ((double) (Math.Abs(this.game.Data.RegimeObj[regnr].Red - this.game.Data.RegimeObj[index10].Red) + Math.Abs(this.game.Data.RegimeObj[regnr].Green - this.game.Data.RegimeObj[index10].Green) + Math.Abs(this.game.Data.RegimeObj[regnr].Blue - this.game.Data.RegimeObj[index10].Blue)) <= 400.0 / Math.Sqrt(Math.Sqrt((double) d)) & d < 999)
                  num14 = 1;
                if (Math.Abs(this.game.Data.RegimeObj[regnr].Red + this.game.Data.RegimeObj[regnr].Green + this.game.Data.RegimeObj[regnr].Blue) < 210 & d < 999)
                  num14 = 1;
              }
            }
          }
          this.game.Data.RegimeObj[regnr].Red2 = (int) byte.MaxValue;
          this.game.Data.RegimeObj[regnr].Green2 = (int) byte.MaxValue;
          this.game.Data.RegimeObj[regnr].Blue2 = (int) byte.MaxValue;
          this.game.Data.RegimeObj[regnr].TempCounter = (Bitmap) null;
          this.game.Data.RegimeObj[regnr].TempCounterHigh = (Bitmap) null;
          ++num6;
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
          if ((double) this.game.Data.RuleVar[423] != 0.0)
          {
            num6 = this.Regid[regnr];
            if (num6 > 6)
              num6 -= 7;
            if ((double) this.game.Data.RuleVar[496] > 0.0 & regnr == this.opt3v)
            {
              this.game.Data.RegimeObj[regnr].ExtraGraphicUse = (int) Math.Round((double) this.game.Data.RuleVar[495]);
              if ((double) this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[regnr].OfficerPool = (int) Math.Round((double) this.game.Data.RuleVar[494]);
            }
            else if ((double) this.game.Data.RuleVar[491] != 0.0 & num6 == 6)
            {
              this.game.Data.RegimeObj[regnr].ExtraGraphicUse = (int) Math.Round((double) this.game.Data.RuleVar[491]);
              if ((double) this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[regnr].OfficerPool = (int) Math.Round((double) this.game.Data.RuleVar[490]);
            }
            else if ((double) this.game.Data.RuleVar[487] != 0.0 & num6 == 5)
            {
              this.game.Data.RegimeObj[regnr].ExtraGraphicUse = (int) Math.Round((double) this.game.Data.RuleVar[487]);
              if ((double) this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[regnr].OfficerPool = (int) Math.Round((double) this.game.Data.RuleVar[486]);
            }
            else if ((double) this.game.Data.RuleVar[483] != 0.0 & num6 == 4)
            {
              this.game.Data.RegimeObj[regnr].ExtraGraphicUse = (int) Math.Round((double) this.game.Data.RuleVar[483]);
              if ((double) this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[regnr].OfficerPool = (int) Math.Round((double) this.game.Data.RuleVar[482]);
            }
            else if ((double) this.game.Data.RuleVar[467] != 0.0 & num6 == 3)
            {
              this.game.Data.RegimeObj[regnr].ExtraGraphicUse = (int) Math.Round((double) this.game.Data.RuleVar[467]);
              if ((double) this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[regnr].OfficerPool = (int) Math.Round((double) this.game.Data.RuleVar[466]);
            }
            else if ((double) this.game.Data.RuleVar[433] != 0.0 & num6 == 2)
            {
              this.game.Data.RegimeObj[regnr].ExtraGraphicUse = (int) Math.Round((double) this.game.Data.RuleVar[433]);
              if ((double) this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[regnr].OfficerPool = (int) Math.Round((double) this.game.Data.RuleVar[432]);
            }
            else if ((double) this.game.Data.RuleVar[428] != 0.0 & num6 == 1)
            {
              this.game.Data.RegimeObj[regnr].ExtraGraphicUse = (int) Math.Round((double) this.game.Data.RuleVar[428]);
              if ((double) this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[regnr].OfficerPool = (int) Math.Round((double) this.game.Data.RuleVar[427]);
            }
            else
            {
              this.game.Data.RegimeObj[regnr].ExtraGraphicUse = (int) Math.Round((double) this.game.Data.RuleVar[423]);
              if ((double) this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[regnr].OfficerPool = (int) Math.Round((double) this.game.Data.RuleVar[422]);
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
          int index11 = opt3v;
          this.game.Data.RegimeObj[index11].Name = "People's Republic";
          this.game.Data.RegimeObj[index11].People = this.game.Data.PeopleCounter;
          this.game.Data.RegimeObj[index11].ResPts = this.opt10v * this.opt8v + 20;
          this.game.Data.RegimeObj[index11].UnitName = "Division";
          this.game.Data.RegimeObj[index11].HQName = "HQ";
          this.game.Data.RegimeObj[index11].Red = (int) byte.MaxValue;
          this.game.Data.RegimeObj[index11].Blue = 120;
          this.game.Data.RegimeObj[index11].Green = 120;
          this.game.Data.RegimeObj[index11].Red2 = (int) byte.MaxValue;
          this.game.Data.RegimeObj[index11].Green2 = (int) byte.MaxValue;
          this.game.Data.RegimeObj[index11].Blue2 = (int) byte.MaxValue;
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
        while ((double) this.landcur <= (double) (opt1v * opt2v) * ((double) opt4v / 100.0))
        {
          int num16 = 0;
          int num17 = opt1v;
          for (int x = 0; x <= num17; ++x)
          {
            int num18 = opt2v;
            for (int y = 0; y <= num18; ++y)
            {
              if (num16 == 0)
              {
                VBMath.Randomize();
                x = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) (opt1v + 1)));
                y = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) (opt2v + 1)));
              }
              int sizy = (double) VBMath.Rnd() <= 0.98 ? ((double) VBMath.Rnd() <= 0.9 ? ((double) VBMath.Rnd() <= 0.6 ? (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) opt4v)) : (int) Math.Round(Conversion.Int((double) VBMath.Rnd() * (double) VBMath.Rnd() * ((double) opt1v / 2.0 + (double) opt2v / 2.0)))) : (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * VBMath.Rnd() * (float) (opt1v + opt2v)))) : (int) Math.Round(Conversion.Int((double) VBMath.Rnd() * (double) VBMath.Rnd() * ((double) (opt1v + opt2v) * ((double) opt4v / 10.0))));
              if (this.optr1 == -2)
                sizy = (int) Math.Round((double) sizy / 5.0);
              if (this.optr1 == -1)
                sizy = (int) Math.Round((double) sizy / 2.5);
              if (this.optr1 == 1)
                sizy = (int) Math.Round((double) sizy * 2.5);
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
          int num19 = 0;
          while ((double) this.mountaincur <= (double) (opt1v * opt2v) * ((double) num1 / 100.0) & num19 < 1000)
          {
            int num20 = 0;
            int num21 = opt1v;
            for (int x = 0; x <= num21; ++x)
            {
              int num22 = opt2v;
              for (int y = 0; y <= num22; ++y)
              {
                if (num20 == 0)
                {
                  VBMath.Randomize();
                  x = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) (opt1v + 1)));
                  y = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) (opt2v + 1)));
                  num20 = 1;
                }
                int landscapeType = this.game.Data.MapObj[0].HexObj[x, y].LandscapeType;
                if (landscapeType == this.GRASS | landscapeType == this.LIGHTFOREST | landscapeType == this.HEAVYFOREST | landscapeType == this.SWAMP)
                {
                  int x2;
                  int y2;
                  if ((double) VBMath.Rnd() > 0.5)
                  {
                    x2 = (int) Math.Round((double) x + Conversion.Int((double) VBMath.Rnd() * ((double) (opt1v + opt2v) / 25.0)));
                    y2 = (int) Math.Round((double) ((float) y + Conversion.Int(VBMath.Rnd() * 2f)));
                  }
                  else
                  {
                    y2 = (int) Math.Round((double) y + Math.Max(2.0, Conversion.Int((double) VBMath.Rnd() * ((double) (opt1v + opt2v) / 60.0))));
                    x2 = (int) Math.Round((double) ((float) x + Math.Max(1f, Conversion.Int(VBMath.Rnd() * 1f))));
                  }
                  if (this.optr3 == -1)
                  {
                    if ((double) VBMath.Rnd() < 0.5)
                      x -= 3;
                    if ((double) VBMath.Rnd() < 0.5)
                      y -= 3;
                    if ((double) VBMath.Rnd() < 0.5)
                      x2 += 3;
                    if ((double) VBMath.Rnd() < 0.5)
                      y2 += 3;
                  }
                  if (this.optr3 == -2)
                  {
                    if ((double) VBMath.Rnd() < 0.5)
                      x -= 7;
                    if ((double) VBMath.Rnd() < 0.5)
                      y -= 7;
                    if ((double) VBMath.Rnd() < 0.5)
                      x2 += 7;
                    if ((double) VBMath.Rnd() < 0.5)
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
                  ++num19;
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
          int mapWidth = this.game.Data.MapObj[0].MapWidth;
          for (int index12 = 0; index12 <= mapWidth; ++index12)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index13 = 0; index13 <= mapHeight; ++index13)
            {
              int index14 = 0;
              do
              {
                this.nextrivstep[index12, index13, index14].x = -1;
                ++index14;
              }
              while (index14 <= 5);
            }
          }
          this.MakeHeightTable();
          int num23 = 0;
          while ((double) this.rivercur <= (double) (num2 * (this.game.Data.MapObj[0].MapWidth * this.game.Data.MapObj[0].MapHeight)) / 1000.0 & num23 < 6 * this.game.Data.MapObj[0].MapWidth * this.game.Data.MapObj[0].MapHeight)
          {
            VBMath.Randomize();
            int index15 = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) (opt1v + 1)));
            int index16 = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) (opt2v + 1)));
            int z1 = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * 6f));
            ++num23;
            if (this.domirror == 1 & (double) index15 >= (double) this.game.Data.MapObj[0].MapWidth / 2.0)
              index15 = -1;
            if (index15 > -1)
            {
              int tfacing = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(index15, index16, 0, tfacing);
                if (coordinate.onmap && this.game.HandyFunctionsObj.HasHexRiver(coordinate.x, coordinate.y, 0))
                  index15 = -1;
                ++tfacing;
              }
              while (tfacing <= 6);
              if (index15 > -1 & index15 > 2 & index16 > 2 & index15 < this.game.Data.MapObj[0].MapWidth - 2 & index16 < this.game.Data.MapObj[0].MapHeight - 2 && !this.game.HandyFunctionsObj.HasHexRiver(index15, index16, 0) && this.game.Data.MapObj[0].HexObj[index15, index16].LandscapeType == this.LOWMOUNTAIN | this.game.Data.MapObj[0].HexObj[index15, index16].LandscapeType == this.HIGHMOUNTAIN)
              {
                int num24 = 0;
                int index17 = 0;
                do
                {
                  if (this.game.Data.MapObj[0].HexObj[index15, index16].RiverType[index17] > -1)
                    ++num24;
                  ++index17;
                }
                while (index17 <= 5);
                if (num24 == 0)
                {
                  ++this.rivercur;
                  num23 = 0;
                  if ((double) this.game.Data.RuleVar[450] == 0.0)
                  {
                    this.DrawARiver(index15, index16, z1);
                  }
                  else
                  {
                    this.DrawARiver2(index15, index16, z1);
                    float num25 = 0.8f;
                    while ((double) VBMath.Rnd() < (double) num25)
                    {
                      num25 /= 2f;
                      index15 = (double) VBMath.Rnd() >= 0.5 ? (int) Math.Round((double) ((float) (index15 + 2) + VBMath.Rnd() * 2f)) : (int) Math.Round((double) ((float) (index15 - 2) + VBMath.Rnd() * 2f));
                      index16 = (double) VBMath.Rnd() >= 0.5 ? (int) Math.Round((double) ((float) (index16 + 2) + VBMath.Rnd() * 2f)) : (int) Math.Round((double) ((float) (index16 - 2) + VBMath.Rnd() * 2f));
                      int z2 = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * 6f));
                      if (index15 > 1 & index16 > 1 & index15 < this.game.Data.MapObj[0].MapWidth & index16 < this.game.Data.MapObj[0].MapHeight)
                        this.DrawARiver2(index15, index16, z2);
                      else
                        num25 = 0.0f;
                    }
                  }
                  if (this.optr2 == 1 & (double) VBMath.Rnd() > 0.33)
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
        if ((double) this.opt8v > (double) this.landcur / 10.0)
          this.opt8v = (int) Math.Round(Conversion.Int((double) this.landcur / 10.0));
        this.PlaceTowns(opt1v, opt2v);
        this.EnsureMountainPasses();
        this.DoSwamps();
        this.PlaceRegimes(opt1v, opt2v, opt3v);
        this.RESOURCESLOT = -1;
        if (this.Srawuse == 1 && (double) this.game.Data.RuleVar[452] > 0.0)
          this.PlaceResources();
        if (this.dooptimize > 0)
          this.OptimizeForAI();
        this.PlaceRegimes2();
        if (this.Srawuse == 1 && (double) this.game.Data.RuleVar[452] > 0.0)
          this.EqualizeResources();
        if (this.Srawuse == 0)
        {
          this.game.Data.RuleVar[452] = 0.0f;
          this.game.Data.RuleVar[822] = -1f;
          this.game.Data.RuleVar[823] = 0.0f;
          this.game.Data.RuleVar[824] = 0.0f;
          int index18 = 0;
          do
          {
            this.game.Data.RegimeSlotShow[index18] = false;
            ++index18;
          }
          while (index18 <= 499);
          int itemTypeCounter = this.game.Data.ItemTypeCounter;
          for (int index19 = 0; index19 <= itemTypeCounter; ++index19)
          {
            int index20 = 0;
            do
            {
              this.game.Data.ItemTypeObj[index19].RegimeSlotsCost[index20] = -1;
              this.game.Data.ItemTypeObj[index19].RegimeSlotsCostQty[index20] = 0;
              ++index20;
            }
            while (index20 <= 4);
          }
          int sfTypeCounter = this.game.Data.SFTypeCounter;
          for (int index21 = 0; index21 <= sfTypeCounter; ++index21)
          {
            this.game.Data.SFTypeObj[index21].FuelRegimeVar = -1;
            this.game.Data.SFTypeObj[index21].FuelForMove = 0;
            this.game.Data.SFTypeObj[index21].FuelForAttack = 0;
            this.game.Data.SFTypeObj[index21].OutOfFuelAttack = 0.0f;
            this.game.Data.SFTypeObj[index21].OutOfFuelDefense = 0.0f;
            this.game.Data.SFTypeObj[index21].OutOfFuelMove = 0.0f;
          }
        }
        this.game.Data.VPWin = (int) Math.Round(Conversion.Int((double) this.totvp * 0.8));
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
        int regimeCounter1 = this.game.Data.RegimeCounter;
        int index22;
        for (index22 = 0; index22 <= regimeCounter1; ++index22)
        {
          if (this.game.Data.NoAIAdvice)
            this.game.Data.RegimeObj[index22].AI = false;
          else
            this.game.Data.RegimeObj[index22].AI = true;
          int regimeCounter2 = this.game.Data.RegimeCounter;
          for (int index23 = 0; index23 <= regimeCounter2; ++index23)
          {
            if (index22 == index23)
              this.game.Data.RegimeObj[index22].RegimeRel[index23] = 1;
            else if ((double) this.game.Data.RuleVar[461] == 1.0)
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
          int regimeCounter3 = this.game.Data.RegimeCounter;
          for (index22 = 0; index22 <= regimeCounter3; ++index22)
          {
            int researchCounter = this.game.Data.ResearchCounter;
            for (int index24 = 0; index24 <= researchCounter; ++index24)
            {
              if (this.game.Data.ResearchObj[index24].TechLevel == 1)
                this.game.Data.RegimeObj[index22].ResField[index24] = true;
            }
          }
        }
        int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
        for (int index25 = 0; index25 <= mapWidth1; ++index25)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index26 = 0; index26 <= mapHeight; ++index26)
          {
            if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index25, index26].LandscapeType].IsSea)
            {
              int index27 = 0;
              do
              {
                if (this.game.Data.MapObj[0].HexObj[index25, index26].RiverType[index27] > -1)
                {
                  this.game.Data.MapObj[0].HexObj[index25, index26].RiverType[index27] = -1;
                  coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index25, index26, this.game.EditObj.MapSelected, index27 + 1);
                  if (coordinate.onmap)
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RiverType[this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, coordinate.map, index25, index26, 0) - 1] = -1;
                }
                ++index27;
              }
              while (index27 <= 5);
            }
          }
        }
        int num26 = 10;
        int num27 = 10;
        int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
        for (int x1 = 0; x1 <= mapWidth2; ++x1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int y1 = 0; y1 <= mapHeight; ++y1)
          {
            if (this.game.Data.MapObj[0].HexObj[x1, y1].Location > -1)
            {
              int num28 = 0;
              float num29 = 0.0f;
              int num30 = 0;
              float num31 = 0.0f;
              int num32 = 0;
              float num33 = 0.0f;
              int num34 = 0;
              float num35 = 0.0f;
              if ((double) this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x1, y1].Location].Type == (double) this.game.Data.RuleVar[413])
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
              if ((double) this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x1, y1].Location].Type == (double) this.game.Data.RuleVar[414])
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
              if ((double) this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x1, y1].Location].Type == (double) this.game.Data.RuleVar[415])
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
              if ((double) this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x1, y1].Location].Type == (double) this.game.Data.RuleVar[416])
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
              if ((double) this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x1, y1].Location].Type == (double) this.game.Data.RuleVar[410])
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
              int num36 = x1 - num26;
              int num37 = x1 + num26;
              for (int x2 = num36; x2 <= num37; ++x2)
              {
                int num38 = y1 - num27;
                int num39 = y1 + num27;
                for (int y2 = num38; y2 <= num39; ++y2)
                {
                  if (x2 >= 0 & y2 >= 0 & x2 <= this.game.Data.MapObj[0].MapWidth & y2 <= this.game.Data.MapObj[0].MapHeight)
                  {
                    if (this.domirror == 1)
                    {
                      int num40 = (int) Math.Round(Conversion.Int((double) (this.game.Data.MapObj[0].MapWidth + 1) / 2.0));
                      int num41 = (int) Math.Round(Conversion.Int((double) (this.game.Data.MapObj[0].MapHeight + 1) / 2.0));
                      int num42 = y2 < num41 ? (y2 >= num41 ? num41 : this.game.Data.MapObj[0].MapHeight - y2) : this.game.Data.MapObj[0].MapHeight - y2;
                      int num43 = x2 < num40 ? (x2 >= num40 ? x2 : this.game.Data.MapObj[0].MapWidth - x2) : this.game.Data.MapObj[0].MapWidth - x2;
                    }
                    int num44 = this.game.HandyFunctionsObj.Distance(x1, y1, 0, x2, y2, 0);
                    int landscapeType = this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType;
                    if (landscapeType == this.GRASS | landscapeType == this.LIGHTFOREST | landscapeType == this.HEAVYFOREST | landscapeType == this.SWAMP | landscapeType == this.FARMLAND | landscapeType == this.LOWMOUNTAIN | landscapeType == this.HIGHMOUNTAIN)
                    {
                      if ((double) VBMath.Rnd() <= (double) num29 & num44 <= num28 | (double) num44 <= Conversion.Int((double) num28 / 2.0))
                      {
                        this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = (int) Math.Round((double) this.game.Data.RuleVar[444]);
                        this.game.Data.MapObj[0].HexObj[x2, y2].SpriteNr = (int) Math.Round((double) this.game.Data.RuleVar[447]);
                        if ((double) this.game.Data.RuleVar[463] > 0.0)
                          this.game.Data.MapObj[0].HexObj[x2, y2].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[463])] = this.game.Data.MapObj[0].HexObj[x1, y1].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[463])];
                      }
                      else if ((double) VBMath.Rnd() <= (double) num31 & num44 <= num30 & !(landscapeType == this.HEAVYFOREST & (double) VBMath.Rnd() < 0.25 | landscapeType == this.HIGHMOUNTAIN | landscapeType == this.LOWMOUNTAIN & (double) VBMath.Rnd() < 0.5))
                      {
                        this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.LIGHTURBAN;
                        this.game.Data.MapObj[0].HexObj[x2, y2].SpriteNr = 0;
                        if ((double) this.game.Data.RuleVar[463] > 0.0)
                          this.game.Data.MapObj[0].HexObj[x2, y2].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[463])] = this.game.Data.MapObj[0].HexObj[x1, y1].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[463])];
                      }
                      else if ((double) VBMath.Rnd() <= (double) num33 & num44 <= num32 & !(landscapeType == this.HEAVYFOREST & (double) VBMath.Rnd() < 0.4 | landscapeType == this.HIGHMOUNTAIN | landscapeType == this.LOWMOUNTAIN & (double) VBMath.Rnd() < 0.3))
                      {
                        this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.FARMLAND;
                        this.game.Data.MapObj[0].HexObj[x2, y2].SpriteNr = 0;
                      }
                      else if ((double) VBMath.Rnd() <= (double) num35 & num44 <= num34 & !(landscapeType == this.HEAVYFOREST & (double) VBMath.Rnd() < 0.6 | landscapeType == this.HIGHMOUNTAIN | landscapeType == this.LOWMOUNTAIN & (double) VBMath.Rnd() < 0.1))
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
        int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
        for (int cx = 0; cx <= mapWidth3; ++cx)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int cy = 0; cy <= mapHeight; ++cy)
          {
            int landscapeType1 = this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType;
            if (landscapeType1 == this.HEAVYFOREST & (double) this.game.Data.RuleVar[448] == 1.0)
            {
              int tfacing = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap)
                {
                  int landscapeType2 = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType;
                  if (landscapeType2 == this.GRASS | landscapeType2 == this.SWAMP | landscapeType2 == this.LIGHTURBAN | landscapeType2 == this.FARMLAND)
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType = this.LIGHTFOREST;
                }
                ++tfacing;
              }
              while (tfacing <= 6);
            }
            if (landscapeType1 == this.HIGHMOUNTAIN & (double) this.game.Data.RuleVar[449] == 1.0)
            {
              int tfacing = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap)
                {
                  int landscapeType3 = this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType;
                  if (landscapeType3 == this.GRASS | landscapeType3 == this.SWAMP | landscapeType3 == this.LIGHTURBAN | landscapeType3 == this.LIGHTFOREST | landscapeType3 == this.HEAVYFOREST | landscapeType3 == this.FARMLAND)
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType = this.LOWMOUNTAIN;
                }
                ++tfacing;
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
          int num45 = opt1v;
          for (int x = 0; x <= num45; ++x)
          {
            int num46 = opt2v;
            for (int y = 0; y <= num46; ++y)
            {
              if (this.game.Data.MapObj[0].HexObj[x, y].Location > -1 & this.game.Data.MapObj[0].HexObj[x, y].VP > 0)
                this.MakeRoads(x, y, this.opt9v, false);
            }
          }
          int num47 = opt1v;
          for (int x = 0; x <= num47; ++x)
          {
            int num48 = opt2v;
            for (int y = 0; y <= num48; ++y)
            {
              if (this.game.Data.MapObj[0].HexObj[x, y].Location > -1 & this.game.Data.MapObj[0].HexObj[x, y].VP > 0 && (double) this.game.Data.RuleVar[461] == 1.0 & this.optr4 == 0)
                this.MakeRoads(x, y, this.opt9v, true);
            }
          }
          int num49 = opt1v;
          for (int x = 0; x <= num49; ++x)
          {
            int num50 = opt2v;
            for (int y = 0; y <= num50; ++y)
            {
              if (this.game.Data.MapObj[0].HexObj[x, y].Location > -1 && (double) this.game.Data.RuleVar[475] > 0.0 & this.optr4 == 0)
                this.MakeRoads2(x, y, this.opt9v);
            }
          }
        }
        if ((double) this.game.Data.RuleVar[451] == 0.0 && this.optr5 == 0)
          this.HarbourAssurance();
        if (this.opt9v > 0)
        {
          int num51 = opt1v;
          for (int x = 0; x <= num51; ++x)
          {
            int num52 = opt2v;
            for (int y = 0; y <= num52; ++y)
            {
              if (this.RESOURCESLOT > -1 && this.game.Data.MapObj[0].HexObj[x, y].AreaCode[this.RESOURCESLOT] > 0)
                this.MakeRoads(x, y, this.opt9v, false);
              if ((double) this.game.Data.RuleVar[445] > 0.0 & this.optr4 == 0 && (double) this.game.Data.MapObj[0].HexObj[x, y].LandscapeType == (double) this.game.Data.RuleVar[445])
                this.MakeRoads(x, y, this.opt9v, false, true);
            }
          }
        }
        this.EnsureMountainPasses2();
        this.PlaceRegimes3();
        if ((double) this.game.Data.RuleVar[419] > 0.0 & (double) this.game.Data.RuleVar[419] < 6.0)
          this.game.HandyFunctionsObj.MakeAutoLabels((int) Math.Round((double) this.game.Data.RuleVar[419]));
        if ((double) this.game.Data.RuleVar[420] > -1.0 & (double) this.game.Data.RuleVar[421] > 0.0 && this.dooldkingdom > 0)
        {
          int mapWidth4 = this.game.Data.MapObj[0].MapWidth;
          for (int x = 0; x <= mapWidth4; ++x)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int y = 0; y <= mapHeight; ++y)
            {
              if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[x, y].LandscapeType].IsSea && this.game.Data.MapObj[0].HexObj[x, y].Regime == -1)
              {
                this.game.Data.MapObj[0].HexObj[x, y].Regime = this.game.Data.RegimeCounter;
                if (this.game.Data.MapObj[0].HexObj[x, y].Location > -1)
                {
                  int location = this.game.Data.MapObj[0].HexObj[x, y].Location;
                  int unr = this.game.Data.AddUnit(x, y, 0);
                  this.game.Data.UnitObj[unr].Name = "Garrison";
                  this.game.Data.UnitObj[unr].Regime = index22 - 1;
                  this.game.Data.UnitObj[unr].Supply = 500;
                  this.game.Data.UnitObj[unr].SOSupReqPercent = 100;
                  this.game.Data.UnitObj[unr].IsHQ = false;
                  this.game.Data.LocObj[location].HQ = -1;
                  int index28 = this.game.Data.AddSF(unr);
                  this.game.Data.SFObj[index28].Type = (int) Math.Round((double) this.game.Data.RuleVar[420]);
                  this.game.Data.SFObj[index28].Qty = (int) Math.Round((double) this.game.Data.RuleVar[421]);
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
        this.game.Data.ResMod = (int) Math.Round((double) this.game.Data.RuleVar[464]);
        if ((double) this.game.Data.RuleVar[464] == 0.0)
          this.game.Data.ResMod = 150000;
        this.game.Data.ResMod *= this.game.Data.RegimeCounter;
        this.game.Data.ResCostMod = this.game.Data.RuleVar[465];
        if ((double) this.game.Data.RuleVar[465] == 0.0)
          this.game.Data.ResCostMod = 1f;
        this.game.Data.ResCostMod *= (float) this.opt11v / 100f;
        string description = this.game.Data.Description;
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
        if ((double) this.game.Data.RuleVar[496] < 1.0)
          this.game.Data.Description = "A " + Strings.Trim(Conversion.Str((object) (this.game.Data.RegimeCounter + 1))) + " player scenario.\r\n";
        else
          this.game.Data.Description = "A " + Strings.Trim(Conversion.Str((object) this.game.Data.RegimeCounter)) + " player scenario + a hidden AI regime to control any potential 'revolutionary' forces.\r\n";
        if (this.dooldkingdom == 1)
        {
          DataClass data = this.game.Data;
          data.Description = data.Description + "The People's Republic holds almost all initial territory, but it is weak and only produces 25% of what other regimes can produce. You need " + Strings.Trim(Conversion.Str((object) this.game.Data.VPWin)) + " Victory Points (100% of total) to win.\r\n";
        }
        else
        {
          DataClass data = this.game.Data;
          data.Description = data.Description + "You need " + Strings.Trim(Conversion.Str((object) this.game.Data.VPWin)) + " Victory Points (80% of total) to win.\r\n";
        }
        if (this.game.Data.DoAllied)
          this.game.Data.Description += "\r\nAll AI regimes will ally when game starts.\r\n";
        DataClass data1 = this.game.Data;
        data1.Description = data1.Description + Strings.Trim(Conversion.Str((object) this.opt4v)) + "% of map is land.\r\n";
        DataClass data2 = this.game.Data;
        data2.Description = data2.Description + "There are about " + Strings.Trim(Conversion.Str((object) this.opt8v)) + " towns on the map, excluding start cities. The size level of the towns is " + Strings.Trim(Conversion.Str((object) this.opt10v)) + "\r\n";
        DataClass data3 = this.game.Data;
        data3.Description = data3.Description + "River level is " + Strings.Trim(Conversion.Str((object) this.opt5v)) + ". " + Strings.Trim(Conversion.Str((object) this.opt6v)) + "% of land should be forest and " + Strings.Trim(Conversion.Str((object) this.opt7v)) + "% of land should be mountain.\r\n";
        if (this.opt11v > 100)
        {
          DataClass data4 = this.game.Data;
          data4.Description = data4.Description + "Research is " + Strings.Trim(Conversion.Str((object) (this.opt11v - 100))) + "% more expensive than normally expected.\r\n";
        }
        else if (this.opt11v < 100)
        {
          DataClass data5 = this.game.Data;
          data5.Description = data5.Description + "Research is " + Strings.Trim(Conversion.Str((object) (100 - this.opt11v))) + "% cheaper than you would normally expect.\r\n";
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
        DataClass data6 = this.game.Data;
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
        if ((double) this.game.Data.RuleVar[499] > 0.0)
          this.game.Data.GameSlot[(int) Math.Round((double) this.game.Data.RuleVar[499])] = 1;
        if ((double) this.game.Data.RuleVar[480] > 0.0)
          this.game.EventRelatedObj.DoCheckSpecificEvent((int) Math.Round((double) this.game.Data.RuleVar[480]));
        this.SmallIslands();
        int mapWidth5 = this.game.Data.MapObj[0].MapWidth;
        for (int cx = 0; cx <= mapWidth5; ++cx)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int cy = 0; cy <= mapHeight; ++cy)
          {
            int index29 = 0;
            do
            {
              if (this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index29] > -1)
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, index29 + 1);
                if (coordinate.onmap)
                {
                  int index30 = index29 + 3;
                  if (index30 > 5)
                    index30 -= 6;
                  this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RiverType[index30] = this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index29];
                }
              }
              ++index29;
            }
            while (index29 <= 5);
          }
        }
        int regimeCounter4 = this.game.Data.RegimeCounter;
        for (int index31 = 0; index31 <= regimeCounter4; ++index31)
        {
          this.game.Data.RegimeObj[index31].LoadSprites();
          this.game.Data.RegimeObj[index31].DoTempCounter();
        }
        int mapWidth6 = this.game.Data.MapObj[0].MapWidth;
        for (int index32 = 0; index32 <= mapWidth6; ++index32)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index33 = 0; index33 <= mapHeight; ++index33)
          {
            if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index32, index33].LandscapeType].IsSea)
              this.game.Data.MapObj[0].HexObj[index32, index33].Regime = -1;
          }
        }
        int regimeCounter5 = this.game.Data.RegimeCounter;
        for (int index34 = 0; index34 <= regimeCounter5; ++index34)
        {
          if (Strings.InStr(this.game.Data.RegimeObj[index34].Name, "<x>") > 0)
          {
            int num53 = 0;
            int num54 = 0;
            int num55 = 0;
            string newValue = "";
            int mapWidth7 = this.game.Data.MapObj[0].MapWidth;
            for (int index35 = 0; index35 <= mapWidth7; ++index35)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index36 = 0; index36 <= mapHeight; ++index36)
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

    public void SmallIslands()
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int cx = 0; cx <= mapWidth; ++cx)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int cy = 0; cy <= mapHeight; ++cy)
        {
          if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType].IsSea)
          {
            int num1 = 0;
            int tfacing1 = 1;
            Coordinate coordinate;
            do
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing1);
              if (coordinate.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                ++num1;
              ++tfacing1;
            }
            while (tfacing1 <= 6);
            if (num1 == 0)
            {
              int num2 = (int) Math.Round(2.0 + Conversion.Int((double) VBMath.Rnd() * 1.99));
label_15:
              if (num2 > 0)
              {
                int tfacing2 = 1;
                do
                {
                  coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing2);
                  if (coordinate.onmap & num2 > 0 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                  {
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType = this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType;
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime = this.game.Data.MapObj[0].HexObj[cx, cy].Regime;
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].SpriteNr = this.game.Data.MapObj[0].HexObj[cx, cy].SpriteNr;
                    int index = 0;
                    do
                    {
                      this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].AreaCode[index] = this.game.Data.MapObj[0].HexObj[cx, cy].AreaCode[index];
                      ++index;
                    }
                    while (index <= 9);
                    --num2;
                  }
                  ++tfacing2;
                }
                while (tfacing2 <= 6);
                goto label_15;
              }
            }
          }
        }
      }
    }

    public void MakeClimates()
    {
      int index1 = (int) Math.Round((double) this.game.Data.RuleVar[481]);
      int num1 = 3;
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      if ((double) this.game.Data.RuleVar[498] > 0.0 & this.Sclimate == 0)
        this.game.Data.GameSlot[(int) Math.Round((double) this.game.Data.RuleVar[498])] = 1;
      int num2;
      int num3;
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
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index2 = 0; index2 <= mapWidth1; ++index2)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index3 = 0; index3 <= mapHeight; ++index3)
        {
          int num4 = num3 + 1;
          for (int index4 = 1; index4 <= num4; ++index4)
          {
            if ((double) index3 <= (double) this.game.Data.MapObj[0].MapHeight * ((double) index4 / (double) num3 + 1.0) && (double) index3 >= (double) this.game.Data.MapObj[0].MapHeight * ((double) (index4 - 1) / (double) (num3 + 1)))
              this.game.Data.MapObj[0].HexObj[index2, index3].AreaCode[index1] = num2 + index4 - 1;
          }
        }
      }
      int num5 = (int) Math.Round(Conversion.Int((double) this.game.Data.MapObj[0].MapWidth / 25.0));
      if (num5 == 0)
        num5 = 1;
      if (!(this.Sclimate == 1 | this.Sclimate == 3))
        return;
      int num6 = num5;
      for (int index5 = 1; index5 <= num6; ++index5)
      {
        int num7;
        int num8;
        if (this.Sclimate == 1)
        {
          num7 = (int) Math.Round((double) this.game.Data.MapObj[0].MapHeight * 0.625);
          num8 = (int) Math.Round((double) this.game.Data.MapObj[0].MapHeight * 0.875);
        }
        else if (this.Sclimate == 3)
        {
          num7 = (int) Math.Round((double) this.game.Data.MapObj[0].MapHeight * (5.0 / 16.0));
          num8 = (int) Math.Round((double) this.game.Data.MapObj[0].MapHeight * (11.0 / 16.0));
        }
        if (this.optr2 == 0)
        {
          int num9 = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) (this.game.Data.MapObj[0].MapWidth - 12)));
          int num10 = (int) Math.Round((double) ((float) num9 + Conversion.Int((float) (2.0 + (double) VBMath.Rnd() * 20.0))));
          int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
          for (int index6 = 0; index6 <= mapWidth2; ++index6)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index7 = 0; index7 <= mapHeight; ++index7)
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
          int num11 = 0;
          int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
          int mapWidth4 = this.game.Data.MapObj[0].MapWidth;
          for (int index8 = 0; index8 <= mapWidth4; ++index8)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index9 = 0; index9 <= mapHeight; ++index9)
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
          num7 = (int) Math.Round((double) (0 + num7) / 2.0);
          num8 = (int) Math.Round((double) (num8 + this.game.Data.MapObj[0].MapHeight) / 2.0);
          int num12 = 0;
          int mapWidth5 = this.game.Data.MapObj[0].MapWidth;
          int mapWidth6 = this.game.Data.MapObj[0].MapWidth;
          for (int index10 = 0; index10 <= mapWidth6; ++index10)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index11 = 0; index11 <= mapHeight; ++index11)
            {
              if (index10 >= num12 & index10 <= mapWidth5 && index11 >= num7 & index11 <= num8)
              {
                this.game.Data.MapObj[0].HexObj[index10, index11].AreaCode[index1] = 99;
                numArray[index10, index11] = 1;
              }
            }
          }
        }
        int num13 = 1;
        do
        {
          int mapWidth7 = this.game.Data.MapObj[0].MapWidth;
          for (int cx = 0; cx <= mapWidth7; ++cx)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int cy = 0; cy <= mapHeight; ++cy)
            {
              if (this.game.Data.MapObj[0].HexObj[cx, cy].AreaCode[index1] == 99 & numArray[cx, cy] == num13)
              {
                int tfacing = 1;
                do
                {
                  Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                  if (coordinate.onmap && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].AreaCode[index1] != 99 & numArray[coordinate.x, coordinate.y] < num13)
                  {
                    numArray[coordinate.x, coordinate.y] = num13;
                    if ((double) VBMath.Rnd() > 0.5)
                    {
                      numArray[coordinate.x, coordinate.y] = num13 + 1;
                      this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].AreaCode[index1] = 99;
                    }
                  }
                  ++tfacing;
                }
                while (tfacing <= 6);
              }
            }
          }
          ++num13;
        }
        while (num13 <= 4);
      }
    }

    public void PlaceResources()
    {
      SimpleList simpleList = new SimpleList();
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[452]));
      if (stringListById == -1)
        return;
      this.game.AIObj.InitFindContinent();
      int length = this.game.Data.StringListObj[stringListById].Length;
      for (int index1 = 0; index1 <= length; ++index1)
      {
        int integer1 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 0]);
        int integer2 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 1]);
        int integer3 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 2]);
        int integer4 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 3]);
        int integer5 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 4]);
        if (this.RESOURCESLOT == -1)
          this.RESOURCESLOT = integer5;
        int integer6 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 5]);
        int integer7 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 6]);
        int integer8 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 7]);
        int integer9 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index1, 8]);
        string str = this.game.Data.StringListObj[stringListById].Data[index1, 9];
        int num1 = this.game.HandyFunctionsObj.CountLandHexesOnMap(0);
        int num2 = (int) Math.Round(Conversion.Int((double) integer9 * ((double) num1 / 1000.0)));
        int regimeCounter = this.game.Data.RegimeCounter;
        int index2;
        Coordinate coordinate;
        for (int index3 = 0; index3 <= regimeCounter; ++index3)
        {
          int num3 = 0;
          int num4 = integer8;
          if (this.Sraw == 1)
            num4 = (int) Math.Round((double) num4 / 2.0);
          if (integer8 % 2 > 0 & (double) VBMath.Rnd() > 0.5)
            ++num4;
          int mapWidth = this.game.Data.MapObj[0].MapWidth;
          int index4;
          for (index4 = 0; index4 <= mapWidth; ++index4)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (index2 = 0; index2 <= mapHeight; ++index2)
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
            int x2 = index4;
            int y2 = index2;
            int num5 = 0;
            while (num4 > 0 & num5 < 9999)
            {
              ++num5;
              int index5 = (int) Math.Round((double) ((float) (x2 - integer7) + VBMath.Rnd() * 2f * (float) integer7));
              index2 = (int) Math.Round((double) ((float) (y2 - integer7) + VBMath.Rnd() * 2f * (float) integer7));
              int num6 = 0;
              int tfacing = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(index5, index2, 0, tfacing);
                if (coordinate.onmap && this.game.HandyFunctionsObj.IsHexHarbourOrSea(coordinate.x, coordinate.y, coordinate.map))
                  ++num6;
                ++tfacing;
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
              int num7 = 0;
              while (num4 > 0 & num7 < 9999)
              {
                ++num7;
                int index6 = (int) Math.Round((double) ((float) (x2 - integer7) + VBMath.Rnd() * 2f * (float) integer7));
                index2 = (int) Math.Round((double) ((float) (y2 - integer7) + VBMath.Rnd() * 2f * (float) integer7));
                int num8 = 0;
                int tfacing = 1;
                do
                {
                  coordinate = this.game.HandyFunctionsObj.HexNeighbour(index6, index2, 0, tfacing);
                  if (coordinate.onmap && this.game.HandyFunctionsObj.IsHexHarbourOrSea(coordinate.x, coordinate.y, coordinate.map))
                    ++num8;
                  ++tfacing;
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
        int num9 = 0;
        int num10 = -1;
        int num11 = num2;
        if (this.Sraw == 1)
          num11 = (int) Math.Round((double) num11 / 2.0);
        if (num2 % 2 > 0 & (double) VBMath.Rnd() > 0.5)
          ++num11;
        if (num11 > 0)
        {
          while (num11 > 0 & num9 < 9999)
          {
            int index7 = -1;
            int index8 = -1;
            long num12 = 0;
            ++num9;
            int num13 = 1;
            int index9;
            do
            {
              index9 = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) (this.game.Data.MapObj[0].MapWidth + 1)));
              index2 = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) (this.game.Data.MapObj[0].MapHeight + 1)));
              int num14 = 0;
              int tfacing = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(index9, index2, 0, tfacing);
                if (coordinate.onmap && this.game.HandyFunctionsObj.IsHexHarbourOrSea(coordinate.x, coordinate.y, coordinate.map))
                  ++num14;
                ++tfacing;
              }
              while (tfacing <= 6);
              if (num14 >= 1)
                index9 = -1;
              if (index9 >= 0 & index2 >= 0 & index9 <= this.game.Data.MapObj[0].MapWidth & index2 <= this.game.Data.MapObj[0].MapHeight && this.game.Data.MapObj[0].HexObj[index9, index2].LandscapeType == integer1 | integer1 == -1 && this.game.Data.MapObj[0].HexObj[index9, index2].SpriteNr == integer2 | integer2 == -1 && this.game.Data.MapObj[0].HexObj[index9, index2].Location == -1 && this.game.Data.MapObj[0].HexObj[index9, index2].SpecialType <= -1)
              {
                int num15 = 999;
                int mapWidth = this.game.Data.MapObj[0].MapWidth;
                for (int x2 = 0; x2 <= mapWidth; ++x2)
                {
                  int mapHeight = this.game.Data.MapObj[0].MapHeight;
                  for (int y2 = 0; y2 <= mapHeight; ++y2)
                  {
                    if (this.game.Data.MapObj[0].HexObj[x2, y2].AreaCode[integer5] == integer6)
                    {
                      int num16 = this.game.HandyFunctionsObj.Distance(index9, index2, 0, x2, y2, 0, 20);
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
              ++num13;
            }
            while (num13 <= 100);
            if (index7 > -1)
            {
              int num17;
              if (this.domirror == 1)
              {
                if (num10 == -1)
                {
                  int num18 = (int) Math.Round(Conversion.Int((double) (this.game.Data.MapObj[0].MapWidth + 1) / 2.0));
                  int num19 = (int) Math.Round(Conversion.Int((double) (this.game.Data.MapObj[0].MapHeight + 1) / 2.0));
                  int num20 = index2 < num19 ? (index2 >= num19 ? num19 : this.game.Data.MapObj[0].MapHeight - index8) : this.game.Data.MapObj[0].MapHeight - index8;
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
          int num21 = 0;
          while (num11 > 0 & integer1 > -1 & integer2 > -1 & num21 < 9999)
          {
            int num22 = num21 + 1;
            int index10 = -1;
            int index11 = -1;
            long num23 = 0;
            num21 = num22 + 1;
            int num24 = 1;
            do
            {
              int index12 = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) (this.game.Data.MapObj[0].MapWidth + 1)));
              index2 = (int) Math.Round((double) Conversion.Int(VBMath.Rnd() * (float) (this.game.Data.MapObj[0].MapHeight + 1)));
              int num25 = 0;
              int tfacing = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbour(index12, index2, 0, tfacing);
                if (coordinate.onmap && this.game.HandyFunctionsObj.IsHexHarbourOrSea(coordinate.x, coordinate.y, coordinate.map))
                  ++num25;
                ++tfacing;
              }
              while (tfacing <= 6);
              if (num25 >= 1)
                index12 = -1;
              if (index12 >= 0 & index2 >= 0 & index12 <= this.game.Data.MapObj[0].MapWidth & index2 <= this.game.Data.MapObj[0].MapHeight && this.game.Data.MapObj[0].HexObj[index12, index2].Location == -1 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index12, index2].LandscapeType].IsSea && this.game.Data.MapObj[0].HexObj[index12, index2].SpecialType <= -1)
              {
                int num26 = 999;
                int mapWidth = this.game.Data.MapObj[0].MapWidth;
                for (int x2 = 0; x2 <= mapWidth; ++x2)
                {
                  int mapHeight = this.game.Data.MapObj[0].MapHeight;
                  for (int y2 = 0; y2 <= mapHeight; ++y2)
                  {
                    if (this.game.Data.MapObj[0].HexObj[x2, y2].AreaCode[integer5] == integer6)
                    {
                      int num27 = this.game.HandyFunctionsObj.Distance(index12, index2, 0, x2, y2, 0, 20);
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
              ++num24;
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

    public void EqualizeResources()
    {
      SimpleList simpleList1 = new SimpleList();
      int[,] numArray1 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int[] numArray2 = new int[this.game.Data.RegimeCounter + 1];
      int num1 = (int) Math.Round((double) this.game.Data.RuleVar[481]);
      int num2;
      while (num2 == 0 & num1 > 0)
      {
        num2 = 1;
        int[] numArray3 = new int[this.game.Data.RegimeCounter + 1];
        int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
        for (int index1 = 0; index1 <= mapWidth1; ++index1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index2 = 0; index2 <= mapHeight; ++index2)
          {
            int index3 = 0;
            do
            {
              if (this.game.Data.MapObj[0].HexObj[index1, index2].AreaCode[index3] > 0 & index3 != num1 && this.game.Data.MapObj[0].HexObj[index1, index2].Regime > -1)
              {
                int[] numArray4 = numArray3;
                int[] numArray5 = numArray4;
                int regime = this.game.Data.MapObj[0].HexObj[index1, index2].Regime;
                int index4 = regime;
                int num3 = numArray4[regime] + 1;
                numArray5[index4] = num3;
              }
              ++index3;
            }
            while (index3 <= 9);
          }
        }
        int num4 = 999999;
        int num5 = -1;
        int num6 = -1;
        int num7 = -1;
        int regimeCounter = this.game.Data.RegimeCounter;
        if (this.Scrate < 1)
          --regimeCounter;
        int num8 = regimeCounter;
        for (int index = 0; index <= num8; ++index)
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
        int tid = 0;
        if (num5 > num4)
        {
          SimpleList simpleList2 = new SimpleList();
          int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
          for (int tdata1 = 0; tdata1 <= mapWidth2; ++tdata1)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int tdata2 = 0; tdata2 <= mapHeight; ++tdata2)
            {
              int index = 0;
              do
              {
                if (this.game.Data.MapObj[0].HexObj[tdata1, tdata2].AreaCode[index] > 0 & index != num1 && this.game.Data.MapObj[0].HexObj[tdata1, tdata2].Regime == num7)
                {
                  ++tid;
                  simpleList2.Add(tid, 1, tdata1, tdata2);
                }
                ++index;
              }
              while (index <= 9);
            }
          }
          if (simpleList2.Counter > -1)
          {
            int index5 = (int) Math.Round((double) (VBMath.Rnd() * (float) (simpleList2.Counter + 1)));
            int index6 = simpleList2.Data1[index5];
            int index7 = simpleList2.Data2[index5];
            this.game.Data.MapObj[0].HexObj[index6, index7].SpecialType = -1;
            this.game.Data.MapObj[0].HexObj[index6, index7].SpecialSprite = -1;
            int index8 = 0;
            do
            {
              if (num1 != index8 | num1 == 0)
                this.game.Data.MapObj[0].HexObj[index6, index7].AreaCode[index8] = 0;
              ++index8;
            }
            while (index8 <= 9);
            this.game.Data.MapObj[0].HexObj[index6, index7].Name = "";
            num2 = 0;
          }
        }
      }
    }

    public void DoSwamps()
    {
      SimpleList simpleList = new SimpleList();
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      if (this.opt12v <= 0)
        return;
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType == this.GRASS | this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType == this.LIGHTFOREST | this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType == this.HEAVYFOREST)
          {
            int num1 = 0;
            int tfacing = 1;
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
                int num2 = index1 - 3;
                int num3 = index1 + 3;
                for (int x2 = num2; x2 <= num3; ++x2)
                {
                  int num4 = index2 - 3;
                  int num5 = index2 + 3;
                  for (int y2 = num4; y2 <= num5; ++y2)
                  {
                    if (x2 >= 0 & y2 >= 0 && x2 <= this.game.Data.MapObj[0].MapWidth & y2 <= this.game.Data.MapObj[0].MapHeight)
                    {
                      if (this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType == this.LOWMOUNTAIN)
                        num1 = (int) Math.Round((double) num1 - 5.0 / Math.Pow((double) this.game.HandyFunctionsObj.Distance(index1, index2, 0, x2, y2, 0), 2.0));
                      if (this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType == this.HIGHMOUNTAIN)
                        num1 = (int) Math.Round((double) num1 - 10.0 / Math.Pow((double) this.game.HandyFunctionsObj.Distance(index1, index2, 0, x2, y2, 0), 2.0));
                    }
                  }
                }
              }
              ++tfacing;
            }
            while (tfacing <= 6);
            if (num1 > 0)
            {
              int num6 = (int) Math.Round((double) num1 * ((double) this.opt12v / 10.0));
              if ((double) VBMath.Rnd() * (double) num6 > (double) VBMath.Rnd() * 100.0)
                this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType = this.SWAMP;
            }
          }
        }
      }
    }

    public void EnsureMountainPasses()
    {
      SimpleList simpleList = new SimpleList();
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType == this.HIGHMOUNTAIN)
          {
            if (this.game.HandyFunctionsObj.HasHexRoad(index1, index2, 0))
            {
              this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType = this.LOWMOUNTAIN;
            }
            else
            {
              int num1 = 0;
              int tfacing1 = 1;
              Coordinate coordinate;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index1, index2, 0, tfacing1);
                if (coordinate.onmap && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType == this.HIGHMOUNTAIN)
                  ++num1;
                ++tfacing1;
              }
              while (tfacing1 <= 6);
              if (num1 > 1)
              {
                int num2 = (int) Math.Round((double) Conversion.Int((float) ((double) VBMath.Rnd() * (double) num1 + 1.0)));
                int num3 = 0;
                int tfacing2 = 1;
                do
                {
                  coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index1, index2, 0, tfacing2);
                  if (coordinate.onmap && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType == this.HIGHMOUNTAIN)
                  {
                    ++num3;
                    if (num3 == num2)
                      this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType = this.LOWMOUNTAIN;
                  }
                  ++tfacing2;
                }
                while (tfacing2 <= 6);
              }
            }
          }
        }
      }
    }

    public void EnsureMountainPasses2()
    {
      SimpleList simpleList = new SimpleList();
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int x = 0; x <= mapWidth; ++x)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int y = 0; y <= mapHeight; ++y)
        {
          if (this.game.Data.MapObj[0].HexObj[x, y].LandscapeType == this.HIGHMOUNTAIN && this.game.HandyFunctionsObj.HasHexRoad(x, y, 0))
            this.game.Data.MapObj[0].HexObj[x, y].LandscapeType = this.LOWMOUNTAIN;
        }
      }
    }

    public void HarbourAssurance()
    {
      SimpleList simpleList = new SimpleList();
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      if (this.opt4v == 100)
        return;
      int num1 = 1;
      while (num1 == 1)
      {
        num1 = 0;
        this.game.AIObj.InitAIOnlyDim();
        this.game.AIObj.InitFindContinent();
        int continentCount = this.game.AIObj.ContinentCount;
        for (int index1 = 1; index1 <= continentCount; ++index1)
        {
          int num2 = 0;
          int num3 = 0;
          int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
          Coordinate coordinate;
          for (int cx = 0; cx <= mapWidth1; ++cx)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int cy = 0; cy <= mapHeight; ++cy)
            {
              if (this.game.Data.MapObj[0].HexObj[cx, cy].Location > -1 && this.game.AIObj.HexContinent[cx, cy] == index1)
              {
                int num4 = 0;
                ++num2;
                int tfacing = 1;
                do
                {
                  coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, 0, tfacing);
                  if (coordinate.onmap && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                    num4 = 1;
                  ++tfacing;
                }
                while (tfacing <= 6);
                if (num4 > 0)
                  ++num3;
              }
            }
          }
          if (num2 > 0 & (num3 == 0 | (double) num3 < (double) num2 / 3.0) & this.game.AIObj.ContinentCount > 1)
          {
            num1 = 1;
            int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
            for (int index2 = 0; index2 <= mapWidth2; ++index2)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index3 = 0; index3 <= mapHeight; ++index3)
                numArray[index2, index3] = 0;
            }
            int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
            for (int index4 = 0; index4 <= mapWidth3; ++index4)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index5 = 0; index5 <= mapHeight; ++index5)
              {
                if (this.game.Data.MapObj[0].HexObj[index4, index5].Location == -1 && this.game.AIObj.HexContinent[index4, index5] == index1)
                {
                  int num5 = 0;
                  numArray[index4, index5] = 1;
                  int tfacing1 = 1;
                  do
                  {
                    coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index4, index5, 0, tfacing1);
                    if (coordinate.onmap && numArray[coordinate.x, coordinate.y] == 0 && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                      num5 = 1;
                    ++tfacing1;
                  }
                  while (tfacing1 <= 6);
                  int index6 = 0;
                  do
                  {
                    if (this.game.Data.MapObj[0].HexObj[index4, index5].RoadType[index6] > -1)
                      num5 = 0;
                    ++index6;
                  }
                  while (index6 <= 5);
                  if (num5 > 0)
                  {
                    this.game.Data.MapObj[0].HexObj[index4, index5].LandscapeType = (int) Math.Round((double) this.game.Data.RuleVar[401]);
                    int tfacing2 = 1;
                    do
                    {
                      coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index4, index5, 0, tfacing2);
                      if (coordinate.onmap)
                      {
                        this.game.Data.MapObj[0].HexObj[index4, index5].RiverType[tfacing2 - 1] = -1;
                        this.game.Data.MapObj[0].HexObj[index4, index5].RoadType[tfacing2 - 1] = -1;
                        this.game.Data.MapObj[0].HexObj[index4, index5].Bridge[tfacing2 - 1] = false;
                        int index7 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index4, index5, 0) - 1;
                        this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RiverType[index7] = -1;
                        this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RoadType[index7] = -1;
                        this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Bridge[index7] = false;
                      }
                      ++tfacing2;
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

    public void MirrorTheMap()
    {
      SimpleList simpleList = new SimpleList();
      int[] numArray1 = new int[6];
      int[] numArray2 = new int[10];
      int num1 = (int) Math.Round(Conversion.Int((double) this.game.Data.MapObj[0].MapWidth / 2.0));
      int num2 = (int) Math.Round(Conversion.Int((double) (this.game.Data.MapObj[0].MapHeight + 1) / 2.0));
      int num3 = 3;
      int num4 = num1;
      for (int index1 = 0; index1 <= num4; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (index1 != this.game.Data.MapObj[0].MapWidth - index1)
          {
            int index3 = index2 < num2 ? (index2 >= num2 ? num2 : this.game.Data.MapObj[0].MapHeight - index2) : this.game.Data.MapObj[0].MapHeight - index2;
            int index4 = 0;
            do
            {
              numArray2[index4] = this.game.Data.MapObj[0].HexObj[this.game.Data.MapObj[0].MapWidth - index1, index2].AreaCode[index4];
              ++index4;
            }
            while (index4 <= 9);
            this.game.Data.MapObj[0].HexObj[this.game.Data.MapObj[0].MapWidth - index1, index2] = this.game.Data.MapObj[0].HexObj[index1, index3].Clone();
            int index5 = 0;
            do
            {
              this.game.Data.MapObj[0].HexObj[this.game.Data.MapObj[0].MapWidth - index1, index2].AreaCode[index5] = numArray2[index5];
              ++index5;
            }
            while (index5 <= 9);
            int index6 = 0;
            do
            {
              numArray1[index6] = this.game.Data.MapObj[0].HexObj[this.game.Data.MapObj[0].MapWidth - index1, index2].RiverType[index6];
              ++index6;
            }
            while (index6 <= 5);
            int index7 = 0;
            do
            {
              int index8 = index7 + num3;
              if (index8 > 5)
                index8 -= 6;
              this.game.Data.MapObj[0].HexObj[this.game.Data.MapObj[0].MapWidth - index1, index2].RiverType[index7] = numArray1[index8];
              ++index7;
            }
            while (index7 <= 5);
          }
        }
      }
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index9 = 0; index9 <= mapWidth; ++index9)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index10 = 0; index10 <= mapHeight; ++index10)
        {
          int index11 = 0;
          do
          {
            if (this.game.Data.MapObj[0].HexObj[index9, index10].RiverType[index11] > -1)
            {
              Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index9, index10, 0, index11 + 1);
              if (coordinate.onmap)
              {
                int index12 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index9, index10, 0) - 1;
                if (this.game.Data.MapObj[0].HexObj[index9, index10].RiverType[index11] != this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RiverType[index12])
                  this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RiverType[index12] = this.game.Data.MapObj[0].HexObj[index9, index10].RiverType[index11];
              }
            }
            ++index11;
          }
          while (index11 <= 5);
        }
      }
    }

    public void MakeRoads2(int x, int y, int roads)
    {
      int movetype = (int) Math.Round((double) this.game.Data.RuleVar[99]);
      if ((double) this.game.Data.RuleVar[478] > 0.0)
        movetype = (int) Math.Round((double) this.game.Data.RuleVar[478]);
      if (this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x, y].Location].Type].MaxProd < 2000)
        return;
      this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.MapObj[0].HexObj[x, y].Regime, movetype, 0, roads * 250, x, y, 0, false, muststartonairfield: false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true, NoBridgePenalty: true);
      SimpleList simpleList = new SimpleList();
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index = 0; index <= mapWidth; ++index)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int tdata2 = 0; tdata2 <= mapHeight; ++tdata2)
        {
          if (!(index == x & tdata2 == y) && this.game.Data.MapObj[0].HexObj[index, tdata2].Location > -1 && this.game.EditObj.TempValue[0].Value[index, tdata2] < 150 && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index, tdata2].Location].Type].MaxProd >= 2000)
            simpleList.Add(index, (int) Math.Round((double) (VBMath.Rnd() * (float) this.game.EditObj.TempValue[0].Value[index, tdata2])), index, tdata2);
        }
      }
      if (simpleList.Counter <= -1)
        return;
      simpleList.Sort();
      int counter = simpleList.Counter;
      for (int index1 = 0; index1 <= counter; ++index1)
      {
        if (index1 < roads + 15)
        {
          this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.MapObj[0].HexObj[x, y].Regime, movetype, 0, roads * 250, simpleList.Data1[index1], simpleList.Data2[index1], 0, false, muststartonairfield: false, SeaBlock: true, BlockAllSea: true, NoBridgePenalty: true, BridgeAP: 40);
          int index2 = x;
          int y1;
          for (int index3 = y; !(index2 == simpleList.Data1[index1] & index3 == simpleList.Data2[index1]); index3 = y1)
          {
            int tfacing1 = -1;
            int num1 = 9999;
            int tfacing2 = 1;
            Coordinate coordinate;
            do
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index2, index3, 0, tfacing2);
              if (coordinate.onmap && this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y] < num1)
              {
                num1 = this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y];
                tfacing1 = tfacing2;
              }
              ++tfacing2;
            }
            while (tfacing2 <= 6);
            coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index2, index3, 0, tfacing1);
            int index4 = tfacing1 - 1;
            int index5 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index2, index3, 0) - 1;
            this.game.Data.MapObj[0].HexObj[index2, index3].RoadType[index4] = (int) Math.Round((double) this.game.Data.RuleVar[475]);
            this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RoadType[index5] = (int) Math.Round((double) this.game.Data.RuleVar[475]);
            if (this.game.Data.MapObj[0].HexObj[index2, index3].RiverType[index4] > -1)
            {
              this.game.Data.MapObj[0].HexObj[index2, index3].Bridge[index4] = true;
              this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Bridge[index5] = true;
            }
            int x1 = coordinate.x;
            y1 = coordinate.y;
            if (this.domirror == 1)
            {
              int num2 = (int) Math.Round(Conversion.Int((double) (this.game.Data.MapObj[0].MapWidth + 1) / 2.0));
              int num3 = (int) Math.Round(Conversion.Int((double) (this.game.Data.MapObj[0].MapHeight + 1) / 2.0));
              int index6 = index3 < num3 ? (index3 >= num3 ? num3 : this.game.Data.MapObj[0].MapHeight - index3) : this.game.Data.MapObj[0].MapHeight - index3;
              int index7 = index2 < num2 ? (index2 >= num2 ? num2 : this.game.Data.MapObj[0].MapWidth - index2) : this.game.Data.MapObj[0].MapWidth - index2;
              int tfacing3 = index4 + 1 + 3;
              if (tfacing3 > 6)
                tfacing3 -= 6;
              coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index7, index6, 0, tfacing3);
              int index8 = tfacing3 - 1;
              int index9 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index7, index6, 0) - 1;
              this.game.Data.MapObj[0].HexObj[index7, index6].RoadType[index8] = (int) Math.Round((double) this.game.Data.RuleVar[475]);
              this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RoadType[index9] = (int) Math.Round((double) this.game.Data.RuleVar[475]);
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

    public void MakeRoads(int x, int y, int roads, bool secondroads, bool verysmall = false)
    {
      int movetype = (int) Math.Round((double) this.game.Data.RuleVar[99]);
      if ((double) this.game.Data.RuleVar[478] > 0.0)
        movetype = (int) Math.Round((double) this.game.Data.RuleVar[478]);
      if (verysmall)
        this.game.HandyFunctionsObj.MakeMovePrediction2(0, movetype, 0, 30, x, y, 0, false, false, muststartonairfield: false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true, NoBridgePenalty: true, BridgeAP: 10, MaxDistance: 4);
      else
        this.game.HandyFunctionsObj.MakeMovePrediction2(0, movetype, 0, roads * 250, x, y, 0, false, false, muststartonairfield: false, NoAPPenalties: true, SeaBlock: true, BlockAllSea: true, NoBridgePenalty: true, BridgeAP: 40, MaxDistance: 32);
      SimpleList simpleList = new SimpleList();
      int MaxDistance = 9999;
      int num1 = roads;
      if ((double) this.game.Data.RuleVar[474] == 1.0)
      {
        num1 = 99;
        MaxDistance = 15;
      }
      if (!secondroads)
      {
        num1 = roads;
        MaxDistance = 32;
      }
      int locCounter = this.game.Data.LocCounter;
      for (int index = 0; index <= locCounter; ++index)
      {
        int x1 = this.game.Data.LocObj[index].X;
        int y1 = this.game.Data.LocObj[index].Y;
        if (!(x1 == x & y1 == y) && this.game.Data.MapObj[0].HexObj[x1, y1].VP > 0)
        {
          if (this.game.EditObj.TempValue[0].Value[x1, y1] < 600 & !secondroads)
            simpleList.Add(x1, (int) Math.Round((double) (VBMath.Rnd() * (float) this.game.EditObj.TempValue[0].Value[x1, y1])), x1, y1);
          if (this.game.EditObj.TempValue[0].Value[x1, y1] < 200 & secondroads)
            simpleList.Add(x1, (int) Math.Round((double) (VBMath.Rnd() * (float) this.game.EditObj.TempValue[0].Value[x1, y1])), x1, y1);
        }
      }
      if (simpleList.Counter <= -1)
        return;
      simpleList.Sort();
      int counter = simpleList.Counter;
      for (int index1 = 0; index1 <= counter; ++index1)
      {
        if (index1 < num1)
        {
          if (!(index1 < roads & !secondroads) && index1 <= 10 & secondroads)
            this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.MapObj[0].HexObj[x, y].Regime, movetype, 0, roads * 350, simpleList.Data1[index1], simpleList.Data2[index1], 0, false, muststartonairfield: false, SeaBlock: true, BlockAllSea: true, NoBridgePenalty: true, overruleRoadType: 0, BridgeAP: 40, MaxDistance: MaxDistance);
          if (this.game.EditObj.TempValue[0].Value[x, y] < 9999 & secondroads | this.game.EditObj.TempValue[0].Value[simpleList.Data1[index1], simpleList.Data2[index1]] < 9999 & !secondroads)
          {
            int num2 = 1;
            if (index1 >= roads)
            {
              if (secondroads)
              {
                int num3 = this.game.EditObj.TempValue[0].Value[x, y];
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
                int index2 = x;
                int y2;
                for (int index3 = y; !(index2 == simpleList.Data1[index1] & index3 == simpleList.Data2[index1]); index3 = y2)
                {
                  int tfacing1 = -1;
                  int num4 = 9999;
                  int tfacing2 = 1;
                  do
                  {
                    coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index2, index3, 0, tfacing2);
                    if (coordinate.onmap && this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y] < num4)
                    {
                      num4 = this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y];
                      tfacing1 = tfacing2;
                    }
                    ++tfacing2;
                  }
                  while (tfacing2 <= 6);
                  coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index2, index3, 0, tfacing1);
                  int index4 = tfacing1 - 1;
                  int index5 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index2, index3, 0) - 1;
                  this.game.Data.MapObj[0].HexObj[index2, index3].RoadType[index4] = (int) Math.Round((double) this.game.Data.RuleVar[409]);
                  this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RoadType[index5] = (int) Math.Round((double) this.game.Data.RuleVar[409]);
                  if (this.game.Data.MapObj[0].HexObj[index2, index3].RiverType[index4] > -1)
                  {
                    this.game.Data.MapObj[0].HexObj[index2, index3].Bridge[index4] = true;
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Bridge[index5] = true;
                  }
                  int x2 = coordinate.x;
                  y2 = coordinate.y;
                  if (this.domirror == 1)
                  {
                    int num5 = (int) Math.Round(Conversion.Int((double) (this.game.Data.MapObj[0].MapWidth + 1) / 2.0));
                    int num6 = (int) Math.Round(Conversion.Int((double) (this.game.Data.MapObj[0].MapHeight + 1) / 2.0));
                    int index6 = index3 < num6 ? (index3 >= num6 ? num6 : this.game.Data.MapObj[0].MapHeight - index3) : this.game.Data.MapObj[0].MapHeight - index3;
                    int index7 = index2 < num5 ? (index2 >= num5 ? num5 : this.game.Data.MapObj[0].MapWidth - index2) : this.game.Data.MapObj[0].MapWidth - index2;
                    int tfacing3 = index4 + 1 + 3;
                    if (tfacing3 > 6)
                      tfacing3 -= 6;
                    coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index7, index6, 0, tfacing3);
                    int index8 = tfacing3 - 1;
                    int index9 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index7, index6, 0) - 1;
                    this.game.Data.MapObj[0].HexObj[index7, index6].RoadType[index8] = (int) Math.Round((double) this.game.Data.RuleVar[409]);
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RoadType[index9] = (int) Math.Round((double) this.game.Data.RuleVar[409]);
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
                int index10 = simpleList.Data1[index1];
                int y3;
                for (int index11 = simpleList.Data2[index1]; !(index10 == x & index11 == y); index11 = y3)
                {
                  int tfacing4 = -1;
                  int num7 = 9999;
                  int tfacing5 = 1;
                  do
                  {
                    coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index10, index11, 0, tfacing5);
                    if (coordinate.onmap && this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y] < num7)
                    {
                      num7 = this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y];
                      tfacing4 = tfacing5;
                    }
                    ++tfacing5;
                  }
                  while (tfacing5 <= 6);
                  coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index10, index11, 0, tfacing4);
                  int index12 = tfacing4 - 1;
                  int index13 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index10, index11, 0) - 1;
                  this.game.Data.MapObj[0].HexObj[index10, index11].RoadType[index12] = (int) Math.Round((double) this.game.Data.RuleVar[409]);
                  this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RoadType[index13] = (int) Math.Round((double) this.game.Data.RuleVar[409]);
                  if (this.game.Data.MapObj[0].HexObj[index10, index11].RiverType[index12] > -1)
                  {
                    this.game.Data.MapObj[0].HexObj[index10, index11].Bridge[index12] = true;
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Bridge[index13] = true;
                  }
                  int x3 = coordinate.x;
                  y3 = coordinate.y;
                  if (this.domirror == 1)
                  {
                    int num8 = (int) Math.Round(Conversion.Int((double) (this.game.Data.MapObj[0].MapWidth + 1) / 2.0));
                    int num9 = (int) Math.Round(Conversion.Int((double) (this.game.Data.MapObj[0].MapHeight + 1) / 2.0));
                    int index14 = index11 < num9 ? (index11 >= num9 ? num9 : this.game.Data.MapObj[0].MapHeight - index11) : this.game.Data.MapObj[0].MapHeight - index11;
                    int index15 = index10 < num8 ? (index10 >= num8 ? num8 : this.game.Data.MapObj[0].MapWidth - index10) : this.game.Data.MapObj[0].MapWidth - index10;
                    int tfacing6 = index12 + 1 + 3;
                    if (tfacing6 > 6)
                      tfacing6 -= 6;
                    coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index15, index14, 0, tfacing6);
                    int index16 = tfacing6 - 1;
                    int index17 = this.game.HandyFunctionsObj.HexFacing(coordinate.x, coordinate.y, 0, index15, index14, 0) - 1;
                    this.game.Data.MapObj[0].HexObj[index15, index14].RoadType[index16] = (int) Math.Round((double) this.game.Data.RuleVar[409]);
                    this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RoadType[index17] = (int) Math.Round((double) this.game.Data.RuleVar[409]);
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

    public void PlaceRegimes(int x, int y, int regmax)
    {
      int num1 = -1;
      if (this.doblockcenter == 1)
      {
        this.tempcount = 1;
        this.tempx[1] = (int) Math.Round(Conversion.Int((double) this.game.Data.MapObj[0].MapWidth / 2.0));
        this.tempy[1] = (int) Math.Round(Conversion.Int((double) this.game.Data.MapObj[0].MapHeight / 2.0));
      }
      int num2 = regmax;
      for (int index1 = 1; index1 <= num2; ++index1)
      {
        int num3 = 0;
        int predef = 0;
        while (num3 == 0)
        {
          int num4 = 0;
          int num5 = 0;
          int num6 = 0;
          int num7 = 0;
          Coordinate coordinate;
          while (num7 < 1000)
          {
            int index2 = (int) Math.Round((double) (Conversion.Int(VBMath.Rnd() * (float) (x - 5)) + 3f));
            int index3 = (int) Math.Round((double) (Conversion.Int(VBMath.Rnd() * (float) (y - 5)) + 3f));
            ++num7;
            if (this.game.Data.MapObj[0].HexObj[index2, index3].LandscapeType == this.GRASS | this.game.Data.MapObj[0].HexObj[index2, index3].LandscapeType == this.LIGHTFOREST | predef > 10 && this.game.Data.MapObj[0].HexObj[index2, index3].Location == -1)
            {
              if (this.tempcount == 0)
              {
                num4 = index2;
                num5 = index3;
              }
              else
              {
                int num8 = 999;
                int tempcount = this.tempcount;
                for (int index4 = 0; index4 <= tempcount; ++index4)
                {
                  int num9 = this.game.HandyFunctionsObj.Distance(index2, index3, 0, this.tempx[index4], this.tempy[index4], 0);
                  if (this.game.Data.MapObj[0].HexObj[this.tempx[index4], this.tempy[index4]].Regime > -1)
                    num9 = (int) Math.Round(Conversion.Int((double) num9 / 3.0));
                  if (num9 < num8)
                    num8 = num9;
                }
                if ((double) this.game.Data.RuleVar[481] > 0.0)
                {
                  if (this.game.Data.MapObj[0].HexObj[index2, index3].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[481])] == this.RegFavClimate[index1 - 1] & this.RegFavClimate[index1 - 1] > 0)
                  {
                    num8 *= 20;
                  }
                  else
                  {
                    if (this.game.Data.MapObj[0].HexObj[index2, index3].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[481])] == 99)
                      num8 = -1;
                    if (this.game.Data.MapObj[0].HexObj[index2, index3].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[481])] == 1)
                      num8 = -1;
                  }
                }
                int num10 = 0;
                int tfacing = 1;
                do
                {
                  coordinate = this.game.HandyFunctionsObj.HexNeighbour(index2, index3, 0, tfacing);
                  if (coordinate.onmap && this.game.HandyFunctionsObj.IsHexHarbourOrSea(coordinate.x, coordinate.y, coordinate.map))
                    ++num10;
                  ++tfacing;
                }
                while (tfacing <= 6);
                if (num10 >= 5)
                  num8 = (int) Math.Round((double) num8 / 40.0);
                if (num8 > num6)
                {
                  num6 = num8;
                  num4 = index2;
                  num5 = index3;
                }
              }
            }
          }
          int index5 = num4;
          int index6 = num5;
          ++predef;
          int num11;
          if (this.domirror == 1)
          {
            if (num1 == -1)
            {
              int num12 = (int) Math.Round(Conversion.Int((double) (this.game.Data.MapObj[0].MapWidth + 1) / 2.0));
              int num13 = (int) Math.Round(Conversion.Int((double) (this.game.Data.MapObj[0].MapHeight + 1) / 2.0));
              int num14 = index6 < num13 ? (index6 >= num13 ? num13 : this.game.Data.MapObj[0].MapHeight - index6) : this.game.Data.MapObj[0].MapHeight - index6;
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
            ++this.tempcount;
            this.tempx[this.tempcount] = index5;
            this.tempy[this.tempcount] = index6;
            this.game.Data.AddLoc(index5, index6, 0);
            int locCounter = this.game.Data.LocCounter;
            this.game.Data.LocObj[locCounter].People = 0;
            if ((this.Regid[index1 - 1] + 22) % 7 == 1)
            {
              this.game.Data.LocObj[locCounter].People = (int) Math.Round((double) this.game.Data.RuleVar[458]);
              this.game.Data.RegimeObj[index1 - 1].People = (int) Math.Round((double) this.game.Data.RuleVar[458]);
              if ((double) this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[index1 - 1].OfficerPool = (int) Math.Round((double) this.game.Data.RuleVar[422]);
            }
            else if ((this.Regid[index1 - 1] + 22) % 7 == 2)
            {
              this.game.Data.LocObj[locCounter].People = (int) Math.Round((double) this.game.Data.RuleVar[459]);
              this.game.Data.RegimeObj[index1 - 1].People = (int) Math.Round((double) this.game.Data.RuleVar[459]);
              if ((double) this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[index1 - 1].OfficerPool = (int) Math.Round((double) this.game.Data.RuleVar[427]);
            }
            else if ((this.Regid[index1 - 1] + 22) % 7 == 3)
            {
              this.game.Data.LocObj[locCounter].People = (int) Math.Round((double) this.game.Data.RuleVar[460]);
              this.game.Data.RegimeObj[index1 - 1].People = (int) Math.Round((double) this.game.Data.RuleVar[460]);
              if ((double) this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[index1 - 1].OfficerPool = (int) Math.Round((double) this.game.Data.RuleVar[432]);
            }
            else if ((this.Regid[index1 - 1] + 22) % 7 == 4)
            {
              this.game.Data.LocObj[locCounter].People = (int) Math.Round((double) this.game.Data.RuleVar[469]);
              this.game.Data.RegimeObj[index1 - 1].People = (int) Math.Round((double) this.game.Data.RuleVar[469]);
              if ((double) this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[index1 - 1].OfficerPool = (int) Math.Round((double) this.game.Data.RuleVar[466]);
            }
            else if ((this.Regid[index1 - 1] + 22) % 7 == 5)
            {
              this.game.Data.LocObj[locCounter].People = (int) Math.Round((double) this.game.Data.RuleVar[485]);
              this.game.Data.RegimeObj[index1 - 1].People = (int) Math.Round((double) this.game.Data.RuleVar[485]);
              if ((double) this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[index1 - 1].OfficerPool = (int) Math.Round((double) this.game.Data.RuleVar[482]);
            }
            else if ((this.Regid[index1 - 1] + 22) % 7 == 6)
            {
              this.game.Data.LocObj[locCounter].People = (int) Math.Round((double) this.game.Data.RuleVar[489]);
              this.game.Data.RegimeObj[index1 - 1].People = (int) Math.Round((double) this.game.Data.RuleVar[489]);
              if ((double) this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[index1 - 1].OfficerPool = (int) Math.Round((double) this.game.Data.RuleVar[486]);
            }
            else
            {
              this.game.Data.LocObj[locCounter].People = (int) Math.Round((double) this.game.Data.RuleVar[493]);
              this.game.Data.RegimeObj[index1 - 1].People = (int) Math.Round((double) this.game.Data.RuleVar[493]);
              if ((double) this.game.Data.RuleVar[422] > 0.0)
                this.game.Data.RegimeObj[index1 - 1].OfficerPool = (int) Math.Round((double) this.game.Data.RuleVar[490]);
            }
            this.game.Data.LocObj[locCounter].Name = "temp";
            int index7 = (int) Math.Round((double) this.game.Data.RuleVar[410]);
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
            int unr = this.game.Data.AddUnit(index5, index6, 0);
            this.game.Data.UnitObj[unr].Name = "Supreme HQ";
            if ((double) this.game.Data.RuleVar[343] == 1.0)
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
            int index8 = this.game.Data.AddSF(unr);
            this.game.Data.SFObj[index8].Type = (int) Math.Round((double) this.game.Data.RuleVar[411]);
            this.game.Data.SFObj[index8].Qty = (int) Math.Round((double) this.game.Data.RuleVar[412]);
            this.game.Data.SFObj[index8].Rdn = 100;
            this.game.Data.SFObj[index8].People = this.game.Data.RegimeObj[index1 - 1].People;
            this.game.Data.SFObj[index8].Xp = 25;
            this.game.Data.SFObj[index8].Mor = 50;
            if ((double) this.game.Data.RuleVar[476] > 0.0)
            {
              int index9 = this.game.Data.AddSF(unr);
              this.game.Data.SFObj[index9].Type = (int) Math.Round((double) this.game.Data.RuleVar[476]);
              this.game.Data.SFObj[index9].Qty = (int) Math.Round((double) this.game.Data.RuleVar[477]);
              this.game.Data.SFObj[index9].Rdn = 100;
              this.game.Data.SFObj[index9].People = 0;
              this.game.Data.SFObj[index9].Xp = 25;
              this.game.Data.SFObj[index9].Mor = 50;
            }
            num3 = 1;
            int num15 = 0;
            do
            {
              if ((double) this.game.Data.RuleVar[453 + num15] > 0.0)
              {
                predef = (int) Math.Round((double) this.game.Data.RuleVar[453 + num15]);
                this.game.EventRelatedObj.ExecAddUnit(predef, index5, index6, index1 - 1, "");
              }
              ++num15;
            }
            while (num15 <= 3);
            int tfacing = 1;
            do
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index5, index6, 0, tfacing);
              if (coordinate.onmap && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime = index1 - 1;
              ++tfacing;
            }
            while (tfacing <= 6);
          }
        }
      }
    }

    public void PlaceRegimes2()
    {
      if ((double) this.game.Data.RuleVar[461] != 1.0)
        return;
      SimpleList[] simpleListArray = new SimpleList[this.game.Data.RegimeCounter + 1];
      int[] numArray1 = new int[this.game.Data.RegimeCounter + 1];
      bool[] flagArray = new bool[this.game.Data.LocCounter + 1];
      int num1 = 1;
      int regimeCounter = this.game.Data.RegimeCounter;
      if ((double) this.game.Data.RuleVar[496] > 0.0)
        --regimeCounter;
      while (num1 == 1)
      {
        num1 = 0;
        int num2 = regimeCounter;
        for (int index1 = 0; index1 <= num2; ++index1)
        {
          simpleListArray[index1] = new SimpleList();
          int locCounter1 = this.game.Data.LocCounter;
          for (int tid = 0; tid <= locCounter1; ++tid)
          {
            if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[tid].X, this.game.Data.LocObj[tid].Y].Regime == -1)
            {
              int tweight = 9999;
              int num3 = -1;
              int locCounter2 = this.game.Data.LocCounter;
              for (int index2 = 0; index2 <= locCounter2; ++index2)
              {
                if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index2].X, this.game.Data.LocObj[index2].Y].Regime == index1)
                {
                  int num4 = this.game.HandyFunctionsObj.Distance(this.game.Data.LocObj[tid].X, this.game.Data.LocObj[tid].Y, 0, this.game.Data.LocObj[index2].X, this.game.Data.LocObj[index2].Y, 0, 999);
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
        int num5 = 0;
        int num6 = regimeCounter - 1;
        for (int index = 0; index <= num6; ++index)
        {
          if (numArray1[index] != numArray1[index + 1])
            num5 = 1;
        }
        int num7;
        if (num5 == 0)
          ++num7;
        int num8 = 0;
        int num9 = regimeCounter;
        for (int index3 = 0; index3 <= num9; ++index3)
        {
          if (simpleListArray[index3].Counter > -1 & numArray1[index3] < num7)
          {
            simpleListArray[index3].Sort();
            int counter = simpleListArray[index3].Counter;
            for (int index4 = 0; index4 <= counter; ++index4)
            {
              int tid = simpleListArray[index3].Id[index4];
              if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[tid].X, this.game.Data.LocObj[tid].Y].Regime == -1 & !flagArray[tid])
              {
                this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[tid].X, this.game.Data.LocObj[tid].Y].Regime = index3;
                num1 = 1;
                flagArray[tid] = true;
                int[] numArray2 = numArray1;
                int[] numArray3 = numArray2;
                int index5 = index3;
                int index6 = index5;
                int num10 = numArray2[index5] + this.game.Data.LocTypeObj[this.game.Data.LocObj[tid].Type].MaxProd;
                numArray3[index6] = num10;
                if ((this.Regid[index3] + 22) % 7 == 1)
                  this.game.Data.LocObj[tid].People = (int) Math.Round((double) this.game.Data.RuleVar[458]);
                else if ((this.Regid[index3] + 22) % 7 == 2)
                  this.game.Data.LocObj[tid].People = (int) Math.Round((double) this.game.Data.RuleVar[459]);
                else if ((this.Regid[index3] + 22) % 7 == 3)
                  this.game.Data.LocObj[tid].People = (int) Math.Round((double) this.game.Data.RuleVar[460]);
                else if ((this.Regid[index3] + 22) % 7 == 4)
                  this.game.Data.LocObj[tid].People = (int) Math.Round((double) this.game.Data.RuleVar[469]);
                else if ((this.Regid[index3] + 22) % 7 == 5)
                  this.game.Data.LocObj[tid].People = (int) Math.Round((double) this.game.Data.RuleVar[485]);
                else if ((this.Regid[index3] + 22) % 7 == 6)
                  this.game.Data.LocObj[tid].People = (int) Math.Round((double) this.game.Data.RuleVar[489]);
                else
                  this.game.Data.LocObj[tid].People = (int) Math.Round((double) this.game.Data.RuleVar[493]);
                if (numArray1[index3] > num7)
                  num7 = numArray1[index3];
                int num11 = regimeCounter;
                for (int index7 = 0; index7 <= num11; ++index7)
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
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index8 = 0; index8 <= mapWidth1; ++index8)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index9 = 0; index9 <= mapHeight; ++index9)
        {
          this.town2[index8, index9] = (object) 0;
          this.town[index8, index9] = (object) -1;
          if (this.game.Data.MapObj[0].HexObj[index8, index9].Regime > -1)
          {
            this.town[index8, index9] = (object) this.game.Data.MapObj[0].HexObj[index8, index9].Regime;
            this.town2[index8, index9] = (object) 1;
          }
        }
      }
      int Right = 0;
      int num12 = 10;
      while (num12 > 0)
      {
        ++Right;
        --num12;
        int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
        for (int cx = 0; cx <= mapWidth2; ++cx)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int cy = 0; cy <= mapHeight; ++cy)
          {
            if (Operators.ConditionalCompareObjectEqual(this.town2[cx, cy], (object) Right, false))
            {
              int tfacing = 1;
              do
              {
                Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap && Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(this.town[coordinate.x, coordinate.y], (object) -1, false), Operators.CompareObjectEqual(this.town[coordinate.x, coordinate.y], this.town[cx, cy], false))))
                {
                  if (this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                  {
                    if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectLess((object) (Right + 6), this.town2[coordinate.x, coordinate.y], false), Operators.CompareObjectEqual(this.town2[coordinate.x, coordinate.y], (object) 0, false))))
                    {
                      this.town2[coordinate.x, coordinate.y] = (object) (Right + 6);
                      this.town[coordinate.x, coordinate.y] = RuntimeHelpers.GetObjectValue(this.town[cx, cy]);
                      num12 = 10;
                    }
                  }
                  else if (this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[tfacing - 1] > -1)
                  {
                    if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectLess((object) (Right + 3), this.town2[coordinate.x, coordinate.y], false), Operators.CompareObjectEqual(this.town2[coordinate.x, coordinate.y], (object) 0, false))))
                    {
                      this.town2[coordinate.x, coordinate.y] = (object) (Right + 3);
                      this.town[coordinate.x, coordinate.y] = RuntimeHelpers.GetObjectValue(this.town[cx, cy]);
                      num12 = 10;
                    }
                  }
                  else if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectLess((object) (Right + 1), this.town2[coordinate.x, coordinate.y], false), Operators.CompareObjectEqual(this.town2[coordinate.x, coordinate.y], (object) 0, false))))
                  {
                    this.town2[coordinate.x, coordinate.y] = (object) (Right + 1);
                    this.town[coordinate.x, coordinate.y] = RuntimeHelpers.GetObjectValue(this.town[cx, cy]);
                    num12 = 10;
                  }
                }
                ++tfacing;
              }
              while (tfacing <= 6);
            }
          }
        }
      }
      int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
      for (int index10 = 0; index10 <= mapWidth3; ++index10)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index11 = 0; index11 <= mapHeight; ++index11)
        {
          if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index10, index11].LandscapeType].IsSea)
            this.game.Data.MapObj[0].HexObj[index10, index11].Regime = Conversions.ToInteger(this.town[index10, index11]);
        }
      }
    }

    public void PlaceRegimes3()
    {
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int x = 0; x <= mapWidth1; ++x)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int y = 0; y <= mapHeight; ++y)
        {
          if (this.game.Data.MapObj[0].HexObj[x, y].Location > -1 | this.game.Data.MapObj[0].HexObj[x, y].LandscapeType == this.LIGHTURBAN)
          {
            if ((double) this.game.Data.RuleVar[463] > 0.0)
              this.game.Data.MapObj[0].HexObj[x, y].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[463])] = -1;
            if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[x, y].LandscapeType].IsSea)
            {
              int regnr = this.game.Data.MapObj[0].HexObj[x, y].Regime;
              if ((double) this.game.Data.RuleVar[461] == 1.0 && regnr == -1)
                regnr = Conversions.ToInteger(this.town[x, y]);
              if ((double) this.game.Data.RuleVar[463] > 0.0 & regnr > -1)
              {
                if ((this.Regid[regnr] + 22) % 7 == 1)
                  this.game.Data.MapObj[0].HexObj[x, y].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[463])] = (int) Math.Round((double) this.game.Data.RuleVar[458]);
                else if ((this.Regid[regnr] + 22) % 7 == 2)
                  this.game.Data.MapObj[0].HexObj[x, y].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[463])] = (int) Math.Round((double) this.game.Data.RuleVar[459]);
                else if ((this.Regid[regnr] + 22) % 7 == 3)
                  this.game.Data.MapObj[0].HexObj[x, y].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[463])] = (int) Math.Round((double) this.game.Data.RuleVar[460]);
                else if ((this.Regid[regnr] + 22) % 7 == 4)
                  this.game.Data.MapObj[0].HexObj[x, y].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[463])] = (int) Math.Round((double) this.game.Data.RuleVar[469]);
                else if ((this.Regid[regnr] + 22) % 7 == 5)
                  this.game.Data.MapObj[0].HexObj[x, y].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[463])] = (int) Math.Round((double) this.game.Data.RuleVar[485]);
                else if ((this.Regid[regnr] + 22) % 7 == 6)
                  this.game.Data.MapObj[0].HexObj[x, y].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[463])] = (int) Math.Round((double) this.game.Data.RuleVar[489]);
                else
                  this.game.Data.MapObj[0].HexObj[x, y].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[463])] = (int) Math.Round((double) this.game.Data.RuleVar[493]);
              }
              int location = this.game.Data.MapObj[0].HexObj[x, y].Location;
              if (location > -1 & regnr > -1)
              {
                if ((this.Regid[regnr] + 22) % 7 == 1 & this.game.Data.RegimeCounter == regnr & (double) this.game.Data.RuleVar[496] >= 1.0)
                  this.game.Data.LocObj[location].People = (int) Math.Round((double) this.game.Data.RuleVar[497]);
                else if ((this.Regid[regnr] + 22) % 7 == 1)
                  this.game.Data.LocObj[location].People = (int) Math.Round((double) this.game.Data.RuleVar[458]);
                else if ((this.Regid[regnr] + 22) % 7 == 2)
                  this.game.Data.LocObj[location].People = (int) Math.Round((double) this.game.Data.RuleVar[459]);
                else if ((this.Regid[regnr] + 22) % 7 == 3)
                  this.game.Data.LocObj[location].People = (int) Math.Round((double) this.game.Data.RuleVar[460]);
                else if ((this.Regid[regnr] + 22) % 7 == 4)
                  this.game.Data.LocObj[location].People = (int) Math.Round((double) this.game.Data.RuleVar[469]);
                else if ((this.Regid[regnr] + 22) % 7 == 5)
                  this.game.Data.LocObj[location].People = (int) Math.Round((double) this.game.Data.RuleVar[485]);
                else if ((this.Regid[regnr] + 22) % 7 == 6)
                  this.game.Data.LocObj[location].People = (int) Math.Round((double) this.game.Data.RuleVar[489]);
                else
                  this.game.Data.LocObj[location].People = (int) Math.Round((double) this.game.Data.RuleVar[493]);
              }
              if (location > -1)
                this.game.Data.LocObj[location].Name = this.GetRandomName(this.TownSize[location], this.game.Data.LocObj[location].People, this.TownCapitol[location]);
              if (location > -1 & regnr > -1 && this.dosinglestart == 0 && this.game.Data.MapObj[0].HexObj[x, y].Regime > -1 & (double) this.game.Data.RuleVar[462] > 0.0)
              {
                this.game.EventRelatedObj.ExecAddUnit((int) Math.Round((double) this.game.Data.RuleVar[462]), x, y, this.game.Data.MapObj[0].HexObj[x, y].Regime, this.game.Data.LocObj[location].Name + " Garrison");
                if ((double) this.game.Data.RuleVar[470] > 0.0)
                  this.game.EventRelatedObj.ExecAddUnit((int) Math.Round((double) this.game.Data.RuleVar[470]), x, y, this.game.Data.MapObj[0].HexObj[x, y].Regime, this.game.Data.LocObj[location].Name + " Garrison");
                if ((double) this.game.Data.RuleVar[471] > 0.0)
                  this.game.EventRelatedObj.ExecAddUnit((int) Math.Round((double) this.game.Data.RuleVar[471]), x, y, this.game.Data.MapObj[0].HexObj[x, y].Regime, this.game.Data.LocObj[location].Name + " Garrison");
                if ((double) this.game.Data.RuleVar[472] > 0.0)
                  this.game.EventRelatedObj.ExecAddUnit((int) Math.Round((double) this.game.Data.RuleVar[472]), x, y, this.game.Data.MapObj[0].HexObj[x, y].Regime, this.game.Data.LocObj[location].Name + " Garrison");
                this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.MapObj[0].HexObj[x, y].Regime, (int) Math.Round((double) this.game.Data.RuleVar[99]), 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), x, y, 0);
                int num1 = -1;
                int num2 = 9999;
                int unitCounter = this.game.Data.UnitCounter;
                for (int index = 0; index <= unitCounter; ++index)
                {
                  if (this.game.Data.UnitObj[index].IsHQ & this.game.Data.UnitObj[index].PreDef == -1 & this.game.Data.UnitObj[index].Regime == regnr && (double) this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y] <= (double) this.game.Data.RuleVar[51] && this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y] < num2)
                  {
                    num2 = this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y];
                    num1 = index;
                  }
                }
                int hq = this.game.Data.UnitObj[this.game.Data.UnitCounter].HQ;
                if (num1 == -1)
                {
                  int unr = this.game.Data.AddUnit(x, y, 0);
                  this.game.Data.UnitObj[unr].Name = this.game.Data.LocObj[location].Name + " HQ";
                  if ((double) this.game.Data.RuleVar[343] == 1.0)
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
                  int index = this.game.Data.AddSF(unr);
                  this.game.Data.SFObj[index].Type = (int) Math.Round((double) this.game.Data.RuleVar[411]);
                  this.game.Data.SFObj[index].Qty = (int) Math.Round((double) this.game.Data.RuleVar[412]);
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
        int unitCounter1 = this.game.Data.UnitCounter;
        for (int hq1 = 0; hq1 <= unitCounter1; ++hq1)
        {
          if (this.game.Data.UnitObj[hq1].PreDef == -1)
          {
            int x = this.game.Data.UnitObj[hq1].X;
            int y = this.game.Data.UnitObj[hq1].Y;
            int hq2 = this.game.Data.UnitObj[hq1].HQ;
            int sfCount = this.game.Data.UnitObj[hq1].SFCount;
            for (int index = 0; index <= sfCount; ++index)
              this.game.Data.SFObj[this.game.Data.UnitObj[hq1].SFList[index]].People = this.game.Data.RegimeObj[this.game.Data.UnitObj[hq1].Regime].People;
            if (hq2 > -1)
            {
              this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.MapObj[0].HexObj[x, y].Regime, (int) Math.Round((double) this.game.Data.RuleVar[0]), 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), x, y, 0);
              int unitCounter2 = this.game.Data.UnitCounter;
              for (int unr = 0; unr <= unitCounter2; ++unr)
              {
                if (unr != hq1 && !this.game.HandyFunctionsObj.IsUnitInHQChain(unr, hq1) & (double) this.game.HandyFunctionsObj.HowmanyHQsAbove(unr) < (double) this.game.Data.RuleVar[304] && this.game.Data.UnitObj[unr].IsHQ & this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].Regime == this.game.Data.UnitObj[hq1].Regime && this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[hq2].X, this.game.Data.UnitObj[hq2].Y] > this.game.EditObj.TempValue[0].Value[this.game.Data.UnitObj[unr].X, this.game.Data.UnitObj[unr].Y])
                  this.game.Data.UnitObj[hq1].HQ = unr;
              }
            }
          }
        }
        int unitCounter3 = this.game.Data.UnitCounter;
        for (int unr = 0; unr <= unitCounter3; ++unr)
        {
          if (this.game.Data.UnitObj[unr].PreDef == -1 && !this.game.Data.UnitObj[unr].IsHQ && this.game.Data.UnitObj[unr].HQ > -1)
          {
            UnitClass[] unitObj = this.game.Data.UnitObj;
            UnitClass[] unitClassArray = unitObj;
            int hq = this.game.Data.UnitObj[unr].HQ;
            int index = hq;
            unitClassArray[index].Supply = unitObj[hq].Supply + this.game.HandyFunctionsObj.UnitSupplyUse(unr) * 2;
          }
        }
      }
      if (this.dosinglestart != 1)
        return;
      int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth2; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
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

    public void OptimizeForAI()
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType].IsSea && this.game.Data.MapObj[0].HexObj[index1, index2].Location == -1)
          {
            int num1 = 0;
            int num2 = index1 - 6;
            int num3 = index1 + 6;
            for (int x2 = num2; x2 <= num3; ++x2)
            {
              int num4 = index2 - 6;
              int num5 = index2 + 6;
              for (int y2 = num4; y2 <= num5; ++y2)
              {
                if (x2 >= 0 & y2 >= 0 & x2 <= this.game.Data.MapObj[0].MapWidth & y2 <= this.game.Data.MapObj[0].MapHeight && this.game.Data.MapObj[0].HexObj[x2, y2].Location > -1 && this.game.HandyFunctionsObj.Distance(index1, index2, 0, x2, y2, 0) <= 4 && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType].IsSea)
                  ++num1;
              }
            }
            if (num1 == 0)
            {
              this.game.Data.AddLoc(index1, index2, 0);
              this.game.Data.LocObj[this.game.Data.LocCounter].Name = this.GetRandomName(1, -1);
              this.game.Data.LocObj[this.game.Data.LocCounter].Type = (int) Math.Round((double) this.game.Data.RuleVar[413]);
              if (this.game.Data.LocTypeObj[(int) Math.Round((double) this.game.Data.RuleVar[413])].AutoProd > -1)
              {
                this.game.Data.LocObj[this.game.Data.LocCounter].ProdPercent[0] = 100;
                this.game.Data.LocObj[this.game.Data.LocCounter].Production[0] = this.game.Data.LocTypeObj[(int) Math.Round((double) this.game.Data.RuleVar[413])].AutoProd;
              }
              this.game.Data.MapObj[0].HexObj[index1, index2].VP = 1;
              ++this.totvp;
              this.game.Data.LocObj[this.game.Data.LocCounter].People = 0;
              this.game.Data.LocObj[this.game.Data.LocCounter].StructuralPts = this.game.Data.LocTypeObj[(int) Math.Round((double) this.game.Data.RuleVar[413])].StructuralPts;
              this.game.Data.MapObj[0].HexObj[index1, index2].Location = this.game.Data.LocCounter;
              this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType = this.game.Data.LocTypeObj[(int) Math.Round((double) this.game.Data.RuleVar[413])].OverdrawLTNr;
              this.game.Data.MapObj[0].HexObj[index1, index2].SpriteNr = this.game.Data.LocTypeObj[(int) Math.Round((double) this.game.Data.RuleVar[413])].OverdrawSpriteNr;
            }
          }
        }
      }
    }

    public void PlaceTowns(int x, int y, int overrule = -1)
    {
      if ((double) this.game.Data.RuleVar[413] == -1.0 || (double) this.game.Data.RuleVar[414] == -1.0 || (double) this.game.Data.RuleVar[415] == -1.0 || (double) this.game.Data.RuleVar[416] == -1.0)
        return;
      this.tempcount = 0;
      int num1 = -1;
      int num2 = 100;
      if ((double) this.game.Data.RuleVar[479] == 1.0)
        num2 = (int) Math.Round((double) this.game.Data.RuleVar[479]);
      this.opt8v += this.game.Data.RegimeCounter + 1 - this.opt8v % (this.game.Data.RegimeCounter + 1);
      int opt8v = this.opt8v;
      for (int index1 = 1; index1 <= opt8v; ++index1)
      {
        int num3 = 0;
        while (num3 == 0)
        {
          int num4 = 0;
          int num5 = 0;
          int num6 = 0;
          int num7 = 0;
          while (num7 < num2 | num6 <= 2)
          {
            int index2 = (int) Math.Round((double) (Conversion.Int(VBMath.Rnd() * (float) (x - 3)) + 2f));
            int index3 = (int) Math.Round((double) (Conversion.Int(VBMath.Rnd() * (float) (y - 3)) + 2f));
            int num8 = 0;
            int tfacing1 = 1;
            Coordinate coordinate;
            do
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbour(index2, index3, 0, tfacing1);
              if (coordinate.onmap && this.game.HandyFunctionsObj.IsHexHarbourOrSea(coordinate.x, coordinate.y, coordinate.map))
                ++num8;
              ++tfacing1;
            }
            while (tfacing1 <= 6);
            if (num8 >= 5)
              index2 = -1;
            if ((double) this.game.Data.RuleVar[481] > 0.0 & index2 > -1)
            {
              if (this.game.Data.MapObj[0].HexObj[index2, index3].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[481])] == 99 & (double) VBMath.Rnd() < 0.95)
                index2 = -1;
              else if (!(this.Sclimate == 2 | this.Sclimate == 3) & this.game.Data.MapObj[0].HexObj[index2, index3].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[481])] == 1 & (double) VBMath.Rnd() < 0.8)
                index2 = -1;
              else if (!(this.Sclimate == 2 | this.Sclimate == 3) & this.game.Data.MapObj[0].HexObj[index2, index3].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[481])] == 4 & (double) VBMath.Rnd() < 0.5)
                index2 = -1;
            }
            if (index2 > -1 && (this.game.Data.MapObj[0].HexObj[index2, index3].LandscapeType == this.GRASS | this.game.Data.MapObj[0].HexObj[index2, index3].LandscapeType == this.LIGHTFOREST) & this.game.Data.MapObj[0].HexObj[index2, index3].Location == -1)
            {
              ++num7;
              if (this.tempcount == 0)
              {
                num4 = index2;
                num5 = index3;
                num6 = 99;
              }
              else
              {
                int num9 = 99;
                int tempcount = this.tempcount;
                for (int index4 = 0; index4 <= tempcount; ++index4)
                {
                  int num10 = this.game.HandyFunctionsObj.Distance(index2, index3, 0, this.tempx[index4], this.tempy[index4], 0);
                  if (num10 < num9)
                    num9 = num10;
                }
                if (Operators.CompareString(this.domasterfile, "OFFICIAL LADDER/Ladder.ptmaster", false) == 0)
                {
                  int tfacing2 = 1;
                  do
                  {
                    coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(index2, index3, 0, tfacing2);
                    if (coordinate.onmap && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime != this.game.Data.MapObj[0].HexObj[index2, index3].Regime && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime != -1)
                      num9 = 1;
                    ++tfacing2;
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
          int x1 = num4;
          int y1 = num5;
          int num11;
          if (this.domirror == 1)
          {
            if (num1 == -1)
            {
              int num12 = (int) Math.Round(Conversion.Int((double) (this.game.Data.MapObj[0].MapWidth + 1) / 2.0));
              int num13 = (int) Math.Round(Conversion.Int((double) (this.game.Data.MapObj[0].MapHeight + 1) / 2.0));
              int num14 = y1 < num13 ? (y1 >= num13 ? num13 : this.game.Data.MapObj[0].MapHeight - y1) : this.game.Data.MapObj[0].MapHeight - y1;
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
            ++this.tempcount;
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
            int index5;
            if ((double) num19 <= (double) num15)
            {
              index5 = (int) Math.Round((double) this.game.Data.RuleVar[413]);
              this.TownSize[this.game.Data.LocCounter] = 0;
              this.game.Data.LocObj[this.game.Data.LocCounter].Name = "";
            }
            else if ((double) num20 <= (double) num16)
            {
              this.TownSize[this.game.Data.LocCounter] = 1;
              index5 = (int) Math.Round((double) this.game.Data.RuleVar[414]);
              this.game.Data.LocObj[this.game.Data.LocCounter].Name = "";
            }
            else if ((double) num21 <= (double) num17)
            {
              this.TownSize[this.game.Data.LocCounter] = 2;
              index5 = (int) Math.Round((double) this.game.Data.RuleVar[415]);
              this.game.Data.LocObj[this.game.Data.LocCounter].Name = "";
            }
            else if ((double) num22 <= (double) num18)
            {
              this.TownSize[this.game.Data.LocCounter] = 3;
              index5 = (int) Math.Round((double) this.game.Data.RuleVar[416]);
              this.game.Data.LocObj[this.game.Data.LocCounter].Name = "";
            }
            if (overrule > -1)
              index5 = overrule;
            int num23;
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
            ++this.totvp;
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

    public void MakeLakes(int x, int y)
    {
      int num1 = x;
      for (int cx = 0; cx <= num1; ++cx)
      {
        int num2 = y;
        for (int cy = 0; cy <= num2; ++cy)
        {
          int num3 = 0;
          int index1 = 0;
          Coordinate coordinate;
          do
          {
            if (this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index1] > -1)
            {
              ++num3;
            }
            else
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, 0, index1 + 1);
              if (coordinate.onmap && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea)
                ++num3;
            }
            ++index1;
          }
          while (index1 <= 5);
          if (num3 == 6)
          {
            int index2 = 0;
            do
            {
              this.game.Data.MapObj[0].HexObj[cx, cy].RiverType[index2] = -1;
              coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, 0, index2 + 1);
              if (coordinate.onmap)
              {
                int index3 = index2 + 3;
                if (index3 > 5)
                  index3 -= 6;
                this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].RiverType[index3] = -1;
              }
              ++index2;
            }
            while (index2 <= 5);
            this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType = this.WATER;
          }
        }
      }
    }

    public string GetRandomRegimeName(int regnr)
    {
      string[] strArray = new string[1001];
      Random random = new Random();
      this.Flag1 = "";
      this.Flag1b = "";
      this.RegFavClimate = (int[]) Utils.CopyArray((Array) this.RegFavClimate, (Array) new int[this.game.Data.RegimeCounter + 1]);
      string Right;
      int num1;
      if ((double) this.game.Data.RuleVar[424] > 0.0)
      {
        int num2;
        while (num2 < 100)
        {
          ++num2;
          if ((double) this.game.Data.RuleVar[496] > 0.0 & regnr == this.opt3v)
          {
            int randomFromStringList = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[496])));
            Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[496]))].Data[randomFromStringList, 1];
            this.Flag1 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[496]))].Data[randomFromStringList, 2];
            this.Flag1b = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[496]))].Data[randomFromStringList, 3];
            this.RegFavClimate[regnr] = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[496]))].Data[randomFromStringList, 4]);
            this.game.Data.RegimeObj[regnr].People = (int) Math.Round((double) this.game.Data.RuleVar[497]);
          }
          else if ((double) this.game.Data.RuleVar[492] > 0.0 & (this.Regid[regnr] + 1 == 7 | this.Regid[regnr] + 1 == 14))
          {
            int randomFromStringList = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[492])));
            Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[492]))].Data[randomFromStringList, 1];
            this.Flag1 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[492]))].Data[randomFromStringList, 2];
            this.Flag1b = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[492]))].Data[randomFromStringList, 3];
            this.RegFavClimate[regnr] = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[492]))].Data[randomFromStringList, 4]);
          }
          else if ((double) this.game.Data.RuleVar[488] > 0.0 & (this.Regid[regnr] + 1 == 6 | this.Regid[regnr] + 1 == 13))
          {
            int randomFromStringList = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[488])));
            Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[488]))].Data[randomFromStringList, 1];
            this.Flag1 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[488]))].Data[randomFromStringList, 2];
            this.Flag1b = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[488]))].Data[randomFromStringList, 3];
            this.RegFavClimate[regnr] = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[488]))].Data[randomFromStringList, 4]);
          }
          else if ((double) this.game.Data.RuleVar[484] > 0.0 & (this.Regid[regnr] + 1 == 5 | this.Regid[regnr] + 1 == 12))
          {
            int randomFromStringList = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[484])));
            Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[484]))].Data[randomFromStringList, 1];
            this.Flag1 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[484]))].Data[randomFromStringList, 2];
            this.Flag1b = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[484]))].Data[randomFromStringList, 3];
            this.RegFavClimate[regnr] = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[484]))].Data[randomFromStringList, 4]);
          }
          else if ((double) this.game.Data.RuleVar[468] > 0.0 & (this.Regid[regnr] + 1 == 4 | this.Regid[regnr] + 1 == 11))
          {
            int randomFromStringList = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[468])));
            Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[468]))].Data[randomFromStringList, 1];
            this.Flag1 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[468]))].Data[randomFromStringList, 2];
            this.Flag1b = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[468]))].Data[randomFromStringList, 3];
            this.RegFavClimate[regnr] = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[468]))].Data[randomFromStringList, 4]);
          }
          else if ((double) this.game.Data.RuleVar[434] > 0.0 & (this.Regid[regnr] + 1 == 3 | this.Regid[regnr] + 1 == 10))
          {
            int randomFromStringList = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[434])));
            Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[434]))].Data[randomFromStringList, 1];
            this.Flag1 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[434]))].Data[randomFromStringList, 2];
            this.Flag1b = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[434]))].Data[randomFromStringList, 3];
            this.RegFavClimate[regnr] = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[434]))].Data[randomFromStringList, 4]);
          }
          else if ((double) this.game.Data.RuleVar[429] > 0.0 & (this.Regid[regnr] + 1 == 2 | this.Regid[regnr] + 1 == 9))
          {
            int randomFromStringList = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[429])));
            Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[429]))].Data[randomFromStringList, 1];
            this.Flag1 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[429]))].Data[randomFromStringList, 2];
            this.Flag1b = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[429]))].Data[randomFromStringList, 3];
            this.RegFavClimate[regnr] = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[429]))].Data[randomFromStringList, 4]);
          }
          else if ((double) this.game.Data.RuleVar[429] > 0.0 & (this.Regid[regnr] + 1 == 1 | this.Regid[regnr] + 1 == 8))
          {
            int randomFromStringList = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[424])));
            Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[424]))].Data[randomFromStringList, 1];
            this.Flag1 = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[424]))].Data[randomFromStringList, 2];
            this.Flag1b = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[424]))].Data[randomFromStringList, 3];
            this.RegFavClimate[regnr] = Conversions.ToInteger(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[424]))].Data[randomFromStringList, 4]);
          }
          num1 = 0;
          int regimeCounter = this.game.Data.RegimeCounter;
          for (int index = 0; index <= regimeCounter; ++index)
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
        string str = strArray[Conversion.Int(random.Next(0, 40))];
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
        int namecount = this.namecount;
        for (int index = 0; index <= namecount; ++index)
        {
          if (Operators.CompareString(this.namelist[index], Right, false) == 0)
          {
            num1 = 0;
            break;
          }
        }
      }
      ++this.namecount;
      this.namelist[this.namecount] = Right;
      return Right;
    }

    public string GetRandomName(int townsize, int townppl, bool IsCapitol = false)
    {
      string[] strArray = new string[10000];
      Random random = new Random();
      string Right;
      if ((double) this.game.Data.RuleVar[440 + townsize] > 0.0)
      {
        int num1;
        while (num1 < 1000)
        {
          ++num1;
          int index1 = 440 + townsize;
          if (IsCapitol & (double) this.game.Data.RuleVar[500] > 0.0)
            index1 = 500;
          int index2 = this.game.ProcessingObj.GetRandomFromStringList(this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[index1])));
          Right = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[index1]))].Data[index2, 1];
          if (townppl > -1 && (double) townppl != Conversion.Val(Strings.Trim(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[index1]))].Data[index2, 2])))
            index2 = -1;
          if (index2 > -1)
          {
            int num2 = 0;
            int locCounter = this.game.Data.LocCounter;
            for (int index3 = 0; index3 <= locCounter; ++index3)
            {
              if (Operators.CompareString(this.game.Data.LocObj[index3].Name, Right, false) == 0)
                num2 = 1;
            }
            if (num2 == 0)
              return Right;
          }
        }
      }
      int num3 = 0;
      while (num3 == 0)
      {
        Right = "";
        int num4 = 0;
        int index4;
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
        int num5 = 0;
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
          int index5 = Conversion.Int(DrawMod.RandyNumber.Next(0, 40));
          string str = Right + strArray[index5];
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
        if ((double) VBMath.Rnd() < 0.3)
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
        int namecount = this.namecount;
        for (int index6 = 0; index6 <= namecount; ++index6)
        {
          if (Operators.CompareString(this.namelist[index6], Right, false) == 0)
          {
            num3 = 0;
            break;
          }
        }
      }
      ++this.namecount;
      this.namelist[this.namecount] = Right;
      return Right;
    }

    public void DrawARiverAddRiver(int x, int y, int z, int steppy, int ox, int oy, int oz)
    {
      object[,] objArray = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      if (this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] == -1)
        this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] = this.SMALLRIVER;
      else
        this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] = this.BIGRIVER;
      Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(x, y, 0, z + 1);
      if (coordinate.onmap)
      {
        int index = z + 3;
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
      int index1 = oz + 3;
      if (index1 > 5)
        index1 -= 6;
      this.nextrivstep[coordinate.x, coordinate.y, index1].x = x;
      this.nextrivstep[coordinate.x, coordinate.y, index1].y = y;
      this.nextrivstep[coordinate.x, coordinate.y, index1].data1 = z;
    }

    public void TraceRiver(int x, int y, int z, int ox, int oy, int oz)
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      Coordinate coordinate;
      coordinate.onmap = false;
      int num1 = 1;
      int num2 = 0;
      while (num1 == 1 & num2 < 200)
      {
        num1 = 0;
        ++num2;
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

    public void DrawARiver2(int x, int y, int z)
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.curriv = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 6];
      int index1 = z + 1;
      if (index1 > 5)
        index1 = 0;
      if (this.game.Data.MapObj[0].HexObj[x, y].RiverType[index1] > -1)
        return;
      int index2 = z - 1;
      if (index2 < 0)
        index2 = 5;
      if (this.game.Data.MapObj[0].HexObj[x, y].RiverType[index2] > -1)
        return;
      Coordinate coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(x, y, 0, z);
      if (coordinate1.onmap)
      {
        int num = z + 3;
        if (num > 5)
          num -= 6;
        int index3 = num + 1;
        if (index3 > 5)
          index3 = 0;
        if (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RiverType[index3] > -1)
          return;
        int index4 = num - 1;
        if (index4 < 0)
          index4 = 5;
        if (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RiverType[index4] > -1)
          return;
      }
      int num1 = 1;
      if (this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] == this.BIGRIVER)
        return;
      this.DrawARiverAddRiver(x, y, z, 0, -1, -1, -1);
      numArray[x, y] = 1;
      coordinate1 = this.game.HandyFunctionsObj.HexNeighbour(x, y, 0, z + 1);
      if (coordinate1.onmap)
        numArray[coordinate1.x, coordinate1.y] = 1;
      int steppy;
      while (this.game.EditObj.TempValue[0].Value[x, y] > 0 & steppy < 200)
      {
        num1 = 0;
        ++steppy;
        numArray[x, y] = 1;
        int num2 = 999999;
        Coordinate coordinate2;
        coordinate2.onmap = false;
        int num3 = 0;
        int num4;
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
          ++num3;
        }
        while (num3 <= 5);
        if (!coordinate2.onmap)
          break;
        int num5 = 0;
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
        int index5 = z;
        if (num5 == 1)
          ++index5;
        if (num5 == 2)
          --index5;
        if (index5 > 5)
          index5 -= 6;
        if (0 > index5)
          index5 += 6;
        if (this.game.Data.MapObj[0].HexObj[x, y].RiverType[index5] > -1 & this.curriv[x, y, index5] > 0)
          num5 = num5 != 1 ? 1 : 2;
        int num6 = 0;
        while (num6 == 0)
        {
          int ox1 = x;
          int oy1 = y;
          int oz1 = z;
          if (num5 == 1)
            ++z;
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
            int ox2 = x;
            int oy2 = y;
            int oz2 = z;
            z += 3;
            if (z > 5)
              z -= 6;
            if (num5 == 1)
              --z;
            if (num5 == 2)
              ++z;
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

    public void DrawARiver(int x, int y, int z)
    {
      object[,,] objArray = new object[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1, 6];
      float num1 = VBMath.Rnd();
      int num2 = 0;
      do
      {
        ++num2;
        if (this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] == -1)
        {
          if ((double) num1 < 0.6)
            this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] = this.SMALLRIVER;
          else
            this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] = this.BIGRIVER;
          objArray[x, y, z] = (object) 1;
        }
        else
        {
          this.game.Data.MapObj[0].HexObj[x, y].RiverType[z] = this.BIGRIVER;
          objArray[x, y, z] = (object) 1;
        }
        if (this.game.EditObj.TempValue[0].Value[x, y] > 1)
        {
          int[,] numArray1 = this.game.EditObj.TempValue[0].Value;
          int[,] numArray2 = numArray1;
          int index1 = x;
          int index2 = index1;
          int index3 = y;
          int index4 = index3;
          int num3 = numArray1[index1, index3] - 1;
          numArray2[index2, index4] = num3;
        }
        Coordinate coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, z + 1);
        int index5 = z + 3;
        if (index5 > 5)
          index5 -= 6;
        if (coordinate1.onmap)
        {
          if (this.game.EditObj.TempValue[0].Value[coordinate1.x, coordinate1.y] > 1)
          {
            int[,] numArray3 = this.game.EditObj.TempValue[0].Value;
            int[,] numArray4 = numArray3;
            int x1 = coordinate1.x;
            int index6 = x1;
            int y1 = coordinate1.y;
            int index7 = y1;
            int num4 = numArray3[x1, y1] - 1;
            numArray4[index6, index7] = num4;
          }
          if (this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RiverType[index5] == -1)
          {
            if ((double) num1 < 0.6)
              this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RiverType[index5] = this.SMALLRIVER;
            else
              this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RiverType[index5] = this.BIGRIVER;
            objArray[coordinate1.x, coordinate1.y, index5] = (object) 1;
          }
          else
          {
            this.game.Data.MapObj[0].HexObj[coordinate1.x, coordinate1.y].RiverType[index5] = this.BIGRIVER;
            objArray[coordinate1.x, coordinate1.y, index5] = (object) 1;
          }
        }
        int num5 = this.game.EditObj.TempValue[0].Value[x, y];
        int num6 = z - 1;
        if (0 > num6)
          num6 = 5;
        coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, num6 + 1);
        int num7 = 999999;
        if (coordinate1.onmap)
          num7 = this.game.EditObj.TempValue[0].Value[coordinate1.x, coordinate1.y];
        int num8 = z;
        coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, num8 + 1);
        int num9 = 999999;
        if (coordinate1.onmap)
          num9 = this.game.EditObj.TempValue[0].Value[coordinate1.x, coordinate1.y];
        int num10 = z + 1;
        if (num10 > 5)
          num10 = 0;
        coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, num10 + 1);
        int num11 = 999999;
        if (coordinate1.onmap)
          num11 = this.game.EditObj.TempValue[0].Value[coordinate1.x, coordinate1.y];
        int num12 = 0;
        int num13 = 0;
        int num14 = 0;
        int num15 = 0;
        int index8 = z - 1;
        if (0 > index8)
          index8 = 5;
        if (Operators.ConditionalCompareObjectEqual(objArray[x, y, index8], (object) 1, false))
          num12 = 200000;
        coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, z + 1);
        if (coordinate1.onmap)
        {
          int num16 = z + 3;
          if (num16 > 5)
            num16 -= 6;
          int index9 = num16 + 1;
          if (index9 > 5)
            index9 = 0;
          if (Operators.ConditionalCompareObjectEqual(objArray[coordinate1.x, coordinate1.y, index9], (object) 1, false))
            num13 = 200000;
          int num17 = z + 3;
          if (num17 > 5)
            num17 -= 6;
          int index10 = num17 - 1;
          if (index10 < 0)
            index10 = 5;
          if (Operators.ConditionalCompareObjectEqual(objArray[coordinate1.x, coordinate1.y, index10], (object) 1, false))
            num14 = 200000;
        }
        int index11 = z + 1;
        if (5 < index11)
          index11 = 0;
        if (Operators.ConditionalCompareObjectEqual(objArray[x, y, index11], (object) 1, false))
          num15 = 200000;
        int num18 = 0;
        int num19 = 999999;
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
          int num20 = num5 + num11 + num15;
          num18 = 4;
        }
        if (num5 == 0 | num7 == 0 | num9 == 0 | num11 == 0 || num5 >= 999999 | num7 >= 999999 | num9 >= 999999 | num11 >= 999999)
          return;
        Coordinate coordinate2;
        if (num18 == 1)
        {
          coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, z + 1);
          int num21 = z + 3;
          if (num21 > 5)
            num21 -= 6;
          int index12 = num21 + 1;
          if (index12 > 5)
            index12 = 0;
          objArray[coordinate1.x, coordinate1.y, index12] = (object) 1;
          coordinate2 = this.game.HandyFunctionsObj.HexNeighbourSameMap(coordinate1.x, coordinate1.y, 0, index12 + 1);
          int index13 = index12 + 3;
          if (index13 > 5)
            index13 -= 6;
          objArray[coordinate2.x, coordinate2.y, index13] = (object) 1;
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
          int index14 = z - 1;
          if (0 > index14)
            index14 = 5;
          objArray[x, y, index14] = (object) 1;
          coordinate2 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, index14 + 1);
          int index15 = index14 + 3;
          if (index15 > 5)
            index15 -= 6;
          objArray[coordinate2.x, coordinate2.y, index15] = (object) 1;
        }
        if (num18 == 2)
        {
          coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, z + 1);
          int num22 = z + 3;
          if (num22 > 5)
            num22 -= 6;
          x = coordinate1.x;
          y = coordinate1.y;
          z = num22;
          ++z;
          if (z > 5)
            z = 0;
        }
        if (num18 == 3)
        {
          int index16 = z + 1;
          if (index16 > 5)
            index16 = 0;
          objArray[x, y, index16] = (object) 1;
          coordinate2 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, index16 + 1);
          int index17 = index16 + 3;
          if (index17 > 5)
            index17 -= 6;
          objArray[coordinate2.x, coordinate2.y, index17] = (object) 1;
        }
        if (num18 == 3)
        {
          coordinate1 = this.game.HandyFunctionsObj.HexNeighbourSameMap(x, y, 0, z + 1);
          int num23 = z + 3;
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
          int num24 = z + 3;
          if (num24 > 5)
            num24 -= 6;
          int index18 = num24 - 1;
          if (index18 < 0)
            index18 = 5;
          objArray[coordinate1.x, coordinate1.y, index18] = (object) 1;
          coordinate2 = this.game.HandyFunctionsObj.HexNeighbourSameMap(coordinate1.x, coordinate1.y, 0, index18 + 1);
          int index19 = index18 + 3;
          if (index19 > 5)
            index19 -= 6;
          objArray[coordinate2.x, coordinate2.y, index19] = (object) 1;
        }
        if (num18 == 4)
        {
          ++z;
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

    public void MakeHeightTable()
    {
      this.game.EditObj.TempValue = new MapMatrix2[1];
      this.game.EditObj.TempValue2 = new MapMatrix2[1];
      this.game.EditObj.TempValue[0] = new MapMatrix2(this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight);
      this.game.EditObj.TempValue2[0] = new MapMatrix2(this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight);
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          this.game.EditObj.TempValue[0].Value[index1, index2] = 0;
          if (this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType == this.LOWMOUNTAIN)
            this.game.EditObj.TempValue[0].Value[index1, index2] = 20000;
          else if (this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType == this.HIGHMOUNTAIN)
            this.game.EditObj.TempValue[0].Value[index1, index2] = 50000;
          else if (this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType == this.WATER)
            this.game.EditObj.TempValue[0].Value[index1, index2] = 0;
          else if ((double) VBMath.Rnd() < 0.99 | this.opt4v < 100 | this.game.Data.MapObj[0].HexObj[index1, index2].Regime > -1 | this.game.Data.MapObj[0].HexObj[index1, index2].Location > -1)
          {
            this.game.EditObj.TempValue[0].Value[index1, index2] = (int) Math.Round((double) (8000f + Conversion.Int(VBMath.Rnd() * 10000f)));
          }
          else
          {
            this.game.EditObj.TempValue[0].Value[index1, index2] = 0;
            this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType = this.WATER;
          }
          if ((double) this.game.Data.RuleVar[481] > 0.0 && this.game.Data.MapObj[0].HexObj[index1, index2].AreaCode[(int) Math.Round((double) this.game.Data.RuleVar[481])] == 99)
          {
            int[,] numArray1 = this.game.EditObj.TempValue[0].Value;
            int[,] numArray2 = numArray1;
            int index3 = index1;
            int index4 = index3;
            int index5 = index2;
            int index6 = index5;
            int num1 = numArray1[index3, index5] * 2;
            numArray2[index4, index6] = num1;
            int[,] numArray3 = this.game.EditObj.TempValue[0].Value;
            int[,] numArray4 = numArray3;
            int index7 = index1;
            int index8 = index7;
            int index9 = index2;
            int index10 = index9;
            int num2 = numArray3[index7, index9] + 5000;
            numArray4[index8, index10] = num2;
          }
          if (this.domirror == 1)
          {
            int num = (int) Math.Round((double) this.game.Data.MapObj[0].MapWidth / 2.0);
            if (index1 >= num - 1 & index1 <= num + 1)
              this.game.EditObj.TempValue[0].Value[index1, index2] = 20000;
          }
          if (index1 == 0 | index2 == 0)
            this.game.EditObj.TempValue[0].Value[index1, index2] = 0;
          if (index1 == this.game.Data.MapObj[0].MapWidth | index2 == this.game.Data.MapObj[0].MapHeight)
            this.game.EditObj.TempValue[0].Value[index1, index2] = 0;
        }
      }
      int num3 = 0;
      Coordinate coordinate;
      do
      {
        ++num3;
        int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
        for (int cx = 0; cx <= mapWidth2; ++cx)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int cy = 0; cy <= mapHeight; ++cy)
          {
            if (this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType != this.WATER)
            {
              int num4 = 0;
              int num5 = 0;
              int tfacing = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, 0, tfacing);
                if (coordinate.onmap)
                {
                  ++num5;
                  num4 += this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y];
                }
                ++tfacing;
              }
              while (tfacing <= 6);
              if (num5 > 0 & num4 > num5)
              {
                int num6 = (int) Math.Round(Conversion.Int((double) num4 / (double) num5));
                if (num6 < 1)
                  num6 = 1;
                this.game.EditObj.TempValue2[0].Value[cx, cy] = num6;
              }
              else
                this.game.EditObj.TempValue2[0].Value[cx, cy] = this.game.EditObj.TempValue[0].Value[cx, cy];
              if (this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType == this.LOWMOUNTAIN)
                this.game.EditObj.TempValue2[0].Value[cx, cy] = (int) Math.Round((double) (this.game.EditObj.TempValue2[0].Value[cx, cy] + 20000) / 2.0);
              else if (this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType == this.HIGHMOUNTAIN)
                this.game.EditObj.TempValue2[0].Value[cx, cy] = (int) Math.Round((double) (this.game.EditObj.TempValue2[0].Value[cx, cy] + 50000) / 2.0);
            }
          }
        }
        int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
        for (int index11 = 0; index11 <= mapWidth3; ++index11)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index12 = 0; index12 <= mapHeight; ++index12)
            this.game.EditObj.TempValue[0].Value[index11, index12] = this.game.EditObj.TempValue2[0].Value[index11, index12];
        }
      }
      while (num3 < 50);
      int mapWidth4 = this.game.Data.MapObj[0].MapWidth;
      for (int index13 = 0; index13 <= mapWidth4; ++index13)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index14 = 0; index14 <= mapHeight; ++index14)
        {
          if ((double) this.game.Data.RuleVar[450] == 1.0)
            this.game.EditObj.TempValue[0].Value[index13, index14] = (int) Math.Round(0.95 * (double) this.game.EditObj.TempValue[0].Value[index13, index14] + 0.1 * (double) this.game.EditObj.TempValue[0].Value[index13, index14] * (double) VBMath.Rnd());
          if (this.game.Data.MapObj[0].HexObj[index13, index14].LandscapeType == this.WATER)
            this.game.EditObj.TempValue[0].Value[index13, index14] = 0;
          else if (this.game.EditObj.TempValue[0].Value[index13, index14] <= 25)
            this.game.EditObj.TempValue[0].Value[index13, index14] = 25;
        }
      }
      if (this.domirror != 0)
        return;
      int mapWidth5 = this.game.Data.MapObj[0].MapWidth;
      for (int cx = 0; cx <= mapWidth5; ++cx)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int cy = 0; cy <= mapHeight; ++cy)
        {
          if ((double) VBMath.Rnd() < 0.07)
          {
            if (this.game.EditObj.TempValue[0].Value[cx, cy] != 0)
            {
              int tfacing = 1;
              do
              {
                coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, 0, tfacing);
                if (this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y] != 0)
                {
                  if (coordinate.onmap)
                    this.game.EditObj.TempValue[0].Value[coordinate.x, coordinate.y] = Conversion.Int(this.game.EditObj.TempValue[0].Value[cx, cy]);
                  this.game.EditObj.TempValue[0].Value[cx, cy] = Conversion.Int(this.game.EditObj.TempValue[0].Value[cx, cy]);
                }
                ++tfacing;
              }
              while (tfacing <= 6);
            }
          }
          else
            this.game.EditObj.TempValue[0].Value[cx, cy] = (int) Math.Round(Conversion.Int((double) VBMath.Rnd() * 0.1 * (double) this.game.EditObj.TempValue[0].Value[cx, cy]) + Conversion.Int(0.95 * (double) this.game.EditObj.TempValue[0].Value[cx, cy]));
        }
      }
    }

    public void MakeLandBlob(int x, int y, int sizy)
    {
      int num1 = 0;
      this.game.Data.MapObj[0].HexObj[x, y].LandscapeType = this.GRASS;
      ++this.landcur;
      if ((double) VBMath.Rnd() * 100.0 < (double) this.opt6v)
        num1 = (double) VBMath.Rnd() >= 0.3 ? ((double) VBMath.Rnd() >= 0.5 ? 3 : 2) : 1;
      int num2;
      do
      {
        num2 = 0;
        int num3;
        ++num3;
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int x2 = 0; x2 <= mapWidth; ++x2)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int y2 = 0; y2 <= mapHeight; ++y2)
          {
            if (this.game.HandyFunctionsObj.Distance(x, y, 0, x2, y2, 0) == num3)
            {
              float num4 = VBMath.Rnd() * 0.5f;
              if ((double) Conversion.Int((float) ((double) VBMath.Rnd() * ((double) sizy * (double) num4) + (double) sizy * (1.0 - (double) num4))) > (double) (num3 * num3) && this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType == this.WATER | this.opt4v == 100 | this.WATER == -1)
              {
                switch (num1)
                {
                  case 1:
                    num2 = 1;
                    if ((double) VBMath.Rnd() < 0.8)
                    {
                      this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.HEAVYFOREST;
                      break;
                    }
                    if ((double) VBMath.Rnd() < 0.4)
                    {
                      this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.LIGHTFOREST;
                      break;
                    }
                    this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.GRASS;
                    break;
                  case 2:
                    num2 = 1;
                    if ((double) VBMath.Rnd() < 0.6)
                    {
                      this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.LIGHTFOREST;
                      break;
                    }
                    if ((double) VBMath.Rnd() < 0.6)
                    {
                      this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.HEAVYFOREST;
                      break;
                    }
                    this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.GRASS;
                    break;
                  case 3:
                    num2 = 1;
                    if ((double) VBMath.Rnd() < 0.6)
                    {
                      this.game.Data.MapObj[0].HexObj[x2, y2].LandscapeType = this.LIGHTFOREST;
                      break;
                    }
                    if ((double) VBMath.Rnd() < 0.1)
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
                ++this.landcur;
              }
            }
          }
        }
      }
      while (num2 == 1);
    }

    public void MakeMountainRange(int x, int y, int x2, int y2)
    {
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      Coordinate coordinate;
      for (int cx = 0; cx <= mapWidth1; ++cx)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int cy = 0; cy <= mapHeight; ++cy)
        {
          if (this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType == this.GRASS && cx >= x & cy >= y & cx <= x2 & cy <= y2)
          {
            int num = 1;
            int tfacing = 1;
            do
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, 0, tfacing);
              if (coordinate.onmap && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType == this.WATER)
                num = 0;
              ++tfacing;
            }
            while (tfacing <= 6);
            if (num == 1)
            {
              if ((double) VBMath.Rnd() < 0.66)
              {
                this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType = this.HIGHMOUNTAIN;
                ++this.mountaincur;
              }
              else
              {
                this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType = this.LOWMOUNTAIN;
                ++this.mountaincur;
              }
            }
          }
        }
      }
      int num1;
      ++num1;
      int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
      for (int cx = 0; cx <= mapWidth2; ++cx)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int cy = 0; cy <= mapHeight; ++cy)
        {
          if (this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType == this.GRASS && cx >= x - 1 & cy >= y - 1 & cx <= x2 + 1 & cy <= y2 + 1)
          {
            int num2 = 0;
            int tfacing = 1;
            do
            {
              coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, 0, tfacing);
              if (coordinate.onmap && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType == this.HIGHMOUNTAIN)
                num2 = 1;
              ++tfacing;
            }
            while (tfacing <= 6);
            if (num2 == 1 && (double) VBMath.Rnd() > 0.5)
            {
              this.game.Data.MapObj[0].HexObj[cx, cy].LandscapeType = this.LOWMOUNTAIN;
              ++this.mountaincur;
            }
          }
        }
      }
    }

    public void FinalizeLadder()
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.game.Data.AddPeople();
      this.game.Data.PeopleObj[this.game.Data.PeopleCounter].PeopleGroup = 1;
      this.game.Data.PeopleObj[this.game.Data.PeopleCounter].Name = "2nd Player";
      this.game.Data.RegimeObj[1].People = 1;
      this.game.Data.TempString[200] = "Universals";
      this.game.Data.TempString[201] = "2nd Player";
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int x = 0; x <= mapWidth; ++x)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int y = 0; y <= mapHeight; ++y)
        {
          int regime = this.game.Data.MapObj[0].HexObj[x, y].Regime;
          if (regime > -1)
          {
            int location = this.game.Data.MapObj[0].HexObj[x, y].Location;
            if (location > -1)
            {
              this.game.Data.LocObj[location].HQ = regime;
              this.game.Data.LocObj[location].ProdPercent[0] = 100;
              this.game.Data.LocObj[location].Production[0] = 1;
              int unr = this.game.Data.AddUnit(x, y, 0);
              this.game.Data.UnitObj[unr].Name = "Garrison Unit";
              this.game.Data.UnitObj[unr].Regime = regime;
              this.game.Data.UnitObj[unr].Supply = 80;
              this.game.Data.UnitObj[unr].SOSupReqPercent = 100;
              this.game.Data.UnitObj[unr].IsHQ = false;
              this.game.Data.UnitObj[unr].HQ = regime;
              int index = this.game.Data.AddSF(unr);
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

    public void FinalizeLadderPre()
    {
      int[,] numArray = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
          numArray[index1, index2] = -1;
      }
      int num1 = 1;
      do
      {
        int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
        for (int index3 = 0; index3 <= mapWidth2; ++index3)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index4 = 0; index4 <= mapHeight; ++index4)
          {
            if (this.game.Data.MapObj[0].HexObj[index3, index4].Regime == num1)
              numArray[index3, index4] = 0;
          }
        }
        num1 += -1;
      }
      while (num1 >= 0);
      int num2 = 0;
      do
      {
        int num3 = 1;
        do
        {
          int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
          for (int cx = 0; cx <= mapWidth3; ++cx)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int cy = 0; cy <= mapHeight; ++cy)
            {
              if (this.game.Data.MapObj[0].HexObj[cx, cy].Regime == num3 & numArray[cx, cy] == num2)
              {
                int tfacing = 1;
                do
                {
                  Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(cx, cy, 0, tfacing);
                  if (coordinate.onmap & numArray[coordinate.x, coordinate.y] == -1)
                  {
                    if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea && this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime == -1)
                      this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime = num3;
                    numArray[coordinate.x, coordinate.y] = num2 + 1;
                  }
                  ++tfacing;
                }
                while (tfacing <= 6);
              }
            }
          }
          num3 += -1;
        }
        while (num3 >= 0);
        ++num2;
      }
      while (num2 <= 20);
    }
  }
}
