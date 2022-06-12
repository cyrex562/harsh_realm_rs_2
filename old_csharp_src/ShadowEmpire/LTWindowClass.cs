// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.LTWindowClass
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
  public class LTWindowClass : WindowClass
  {
    private int TempText1;
    private int temptext2;
    private int temptext3;
    private int temptext4;
    private int temptext5;
    private int temptext6;
    private int temptext7;
    private int temptext8;
    private int temptext9;
    private int temptext10;
    private int TempText11;
    private int temptext12;
    private int temptext13;
    private int temptext14;
    private int temptext15;
    private int temptext16;
    private int temptext17;
    private int temptext18;
    private int temptext19;
    private int temptext20;
    private int TempText21;
    private int temptext22;
    private int temptext23;
    private int temptext24;
    private int temptext25;
    private int temptext26;
    private int temptext27;
    private int temptext28;
    private int temptext29;
    private int temptext30;
    private int TempText31;
    private int temptext32;
    private int temptext33;
    private int temptext34;
    private int temptext35;
    private int temptext36;
    private int temptext37;
    private int temptext38;
    private int temptext39;
    private int temptext40;
    private int temptext41;
    private int temptext42;
    private int temptext43;
    private int temptext44;
    private int temptext45;
    private int temptext46;
    private int LogoListId;
    private int but1id;
    private int tab1id;
    private int tab2id;
    private int tab3id;
    private int tab4id;
    private int tab5id;
    private int but1textid;
    private int but1bid;
    private int hqbut0;
    private int hqbut1;
    private int hqbut2;
    private int but2id;
    private int but2textid;
    private int but3id;
    private int but3textid;
    private int but4id;
    private int but4textid;
    private int but5id;
    private int but5textid;
    private int but6id;
    private int but6textid;
    private int but7id;
    private int quitid;
    private int but7textid;
    private int descid;
    private int comparenr;
    private int sliderid;
    private int logolist2id;
    private int logolist3id;
    private float tempBlink;
    private int unr;
    private int sfnr;
    private int sftyp;
    private int detailnr;
    private int detailnr2;
    private int detailtype;
    private int ammount;
    private bool hqreach;
    private int passenger;
    private int OptionsListId;
    private ATListClass OptionsListObj;
    private int OptionsList2Id;
    private ATListClass OptionsList2Obj;
    private int OptionsList3Id;
    private ATListClass OptionsList3Obj;
    private int OptionsList4Id;
    private ATListClass OptionsList4Obj;
    private int OptionsList5Id;
    private ATListClass OptionsList5Obj;
    private int OptionsList6Id;
    private ATListClass OptionsList6Obj;
    private int combatListId;
    private ATListClass combatListObj;
    private int combatList2Id;
    private ATListClass combatList2Obj;
    private int StatTyp;
    private int StatMode;
    private int[] ChainHq;
    private int HQselect;
    private int infoid;
    private int ltnr;
    private int locnr;
    private int ppl;
    private int spnr;

    public override WindowReturnClass handleTimer() => new WindowReturnClass();

    public override void DoRefresh()
    {
      this.comparenr = this.game.EditObj.SFCompare;
      if (this.descid > 0)
      {
        this.RemoveSubPart(this.descid);
        this.descid = 0;
      }
      if (this.OptionsListId > 0)
      {
        this.RemoveSubPart(this.OptionsListId);
        this.OptionsListId = 0;
      }
      if (this.OptionsList2Id > 0)
      {
        this.RemoveSubPart(this.OptionsList2Id);
        this.OptionsList2Id = 0;
      }
      if (this.OptionsList3Id > 0)
      {
        this.RemoveSubPart(this.OptionsList3Id);
        this.OptionsList3Id = 0;
      }
      if (this.OptionsList4Id > 0)
      {
        this.RemoveSubPart(this.OptionsList4Id);
        this.OptionsList4Id = 0;
      }
      if (this.OptionsList5Id > 0)
      {
        this.RemoveSubPart(this.OptionsList5Id);
        this.OptionsList5Id = 0;
      }
      if (this.OptionsList6Id > 0)
      {
        this.RemoveSubPart(this.OptionsList6Id);
        this.OptionsList6Id = 0;
      }
      if (this.combatListId > 0)
      {
        this.RemoveSubPart(this.combatListId);
        this.combatListId = 0;
      }
      if (this.combatList2Id > 0)
      {
        this.RemoveSubPart(this.combatList2Id);
        this.combatList2Id = 0;
      }
      this.DoStuff();
    }

    public LTWindowClass(ref GameClass tGame)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND2MARC)
    {
      this.ChainHq = new int[3];
      this.tempBlink = 0.0f;
      this.game.EditObj.CurrentDescript = "";
      this.unr = -1;
      this.ppl = -1;
      if (this.game.SelectX > -1)
      {
        this.ltnr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType;
        this.spnr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].SpriteNr;
        this.locnr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location;
        if (this.locnr > -1)
          this.ppl = this.game.Data.LocObj[this.locnr].People;
        if (this.locnr > -1)
        {
          this.locnr = this.game.Data.LocObj[this.locnr].Type;
          this.ppl = this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location].People;
        }
      }
      if (this.game.EditObj.LocTypeSelected > -1)
      {
        this.locnr = this.game.EditObj.LocTypeSelected;
        this.game.EditObj.LocTypeSelected = -1;
      }
      this.StatMode = 0;
      this.detailnr = -1;
      this.detailnr2 = 0;
      this.DoStuff();
    }

    public void DoStuff()
    {
      this.NewBackGroundAndClearAll(1024, 768, this.game.BACKGROUND2MARC);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.TempText1 > 0)
        this.RemoveSubPart(this.TempText1);
      if (this.temptext2 > 0)
        this.RemoveSubPart(this.temptext2);
      if (this.temptext3 > 0)
        this.RemoveSubPart(this.temptext3);
      if (this.temptext4 > 0)
        this.RemoveSubPart(this.temptext4);
      if (this.temptext5 > 0)
        this.RemoveSubPart(this.temptext5);
      if (this.temptext6 > 0)
        this.RemoveSubPart(this.temptext6);
      if (this.temptext7 > 0)
        this.RemoveSubPart(this.temptext7);
      if (this.temptext8 > 0)
        this.RemoveSubPart(this.temptext8);
      if (this.temptext9 > 0)
        this.RemoveSubPart(this.temptext9);
      if (this.temptext10 > 0)
        this.RemoveSubPart(this.temptext10);
      if (this.TempText11 > 0)
        this.RemoveSubPart(this.TempText11);
      if (this.temptext12 > 0)
        this.RemoveSubPart(this.temptext12);
      if (this.temptext13 > 0)
        this.RemoveSubPart(this.temptext13);
      if (this.temptext14 > 0)
        this.RemoveSubPart(this.temptext14);
      if (this.temptext15 > 0)
        this.RemoveSubPart(this.temptext15);
      if (this.temptext16 > 0)
        this.RemoveSubPart(this.temptext16);
      if (this.temptext17 > 0)
        this.RemoveSubPart(this.temptext17);
      if (this.temptext18 > 0)
        this.RemoveSubPart(this.temptext18);
      if (this.temptext19 > 0)
        this.RemoveSubPart(this.temptext19);
      if (this.temptext20 > 0)
        this.RemoveSubPart(this.temptext20);
      if (this.TempText21 > 0)
        this.RemoveSubPart(this.TempText21);
      if (this.temptext22 > 0)
        this.RemoveSubPart(this.temptext22);
      if (this.temptext23 > 0)
        this.RemoveSubPart(this.temptext23);
      if (this.temptext24 > 0)
        this.RemoveSubPart(this.temptext24);
      if (this.temptext25 > 0)
        this.RemoveSubPart(this.temptext25);
      if (this.temptext26 > 0)
        this.RemoveSubPart(this.temptext26);
      if (this.temptext27 > 0)
        this.RemoveSubPart(this.temptext27);
      if (this.temptext28 > 0)
        this.RemoveSubPart(this.temptext28);
      if (this.temptext29 > 0)
        this.RemoveSubPart(this.temptext29);
      if (this.temptext30 > 0)
        this.RemoveSubPart(this.temptext30);
      if (this.TempText31 > 0)
        this.RemoveSubPart(this.TempText31);
      if (this.temptext32 > 0)
        this.RemoveSubPart(this.temptext32);
      if (this.temptext33 > 0)
        this.RemoveSubPart(this.temptext33);
      if (this.temptext34 > 0)
        this.RemoveSubPart(this.temptext34);
      if (this.temptext35 > 0)
        this.RemoveSubPart(this.temptext35);
      if (this.temptext36 > 0)
        this.RemoveSubPart(this.temptext36);
      if (this.temptext37 > 0)
        this.RemoveSubPart(this.temptext37);
      if (this.temptext38 > 0)
        this.RemoveSubPart(this.temptext38);
      if (this.temptext39 > 0)
        this.RemoveSubPart(this.temptext39);
      if (this.temptext40 > 0)
        this.RemoveSubPart(this.temptext40);
      if (this.temptext41 > 0)
        this.RemoveSubPart(this.temptext41);
      if (this.temptext42 > 0)
        this.RemoveSubPart(this.temptext42);
      if (this.temptext43 > 0)
        this.RemoveSubPart(this.temptext43);
      if (this.temptext44 > 0)
        this.RemoveSubPart(this.temptext44);
      if (this.temptext45 > 0)
        this.RemoveSubPart(this.temptext45);
      if (this.temptext46 > 0)
        this.RemoveSubPart(this.temptext46);
      if (this.hqbut0 > 0)
        this.RemoveSubPart(this.hqbut0);
      if (this.hqbut1 > 0)
        this.RemoveSubPart(this.hqbut1);
      if (this.hqbut2 > 0)
        this.RemoveSubPart(this.hqbut2);
      if (this.LogoListId > 0)
        this.RemoveSubPart(this.LogoListId);
      if (this.logolist2id > 0)
        this.RemoveSubPart(this.logolist2id);
      if (this.logolist3id > 0)
        this.RemoveSubPart(this.logolist3id);
      if (this.but1id > 0)
        this.RemoveSubPart(this.but1id);
      if (this.but1bid > 0)
        this.RemoveSubPart(this.but1bid);
      if (this.but1textid > 0)
        this.RemoveSubPart(this.but1textid);
      if (this.but2id > 0)
        this.RemoveSubPart(this.but2id);
      if (this.but2textid > 0)
        this.RemoveSubPart(this.but2textid);
      if (this.but3id > 0)
        this.RemoveSubPart(this.but3id);
      if (this.but3textid > 0)
        this.RemoveSubPart(this.but3textid);
      if (this.but4id > 0)
        this.RemoveSubPart(this.but4id);
      if (this.but4textid > 0)
        this.RemoveSubPart(this.but4textid);
      if (this.but5id > 0)
        this.RemoveSubPart(this.but5id);
      if (this.but5textid > 0)
        this.RemoveSubPart(this.but5textid);
      if (this.but6id > 0)
        this.RemoveSubPart(this.but6id);
      if (this.but6textid > 0)
        this.RemoveSubPart(this.but6textid);
      if (this.but7id > 0)
        this.RemoveSubPart(this.but7id);
      if (this.but7textid > 0)
        this.RemoveSubPart(this.but7textid);
      if (this.sliderid > 0)
        this.RemoveSubPart(this.sliderid);
      if (this.descid > 0)
        this.RemoveSubPart(this.descid);
      if (this.tab1id > 0)
        this.RemoveSubPart(this.tab1id);
      if (this.tab2id > 0)
        this.RemoveSubPart(this.tab2id);
      if (this.tab3id > 0)
        this.RemoveSubPart(this.tab3id);
      if (this.tab4id > 0)
        this.RemoveSubPart(this.tab4id);
      if (this.tab5id > 0)
        this.RemoveSubPart(this.tab5id);
      if (this.quitid > 0)
        this.RemoveSubPart(this.quitid);
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONQUIT);
      this.but1id = this.AddSubPart(ref tsubpart1, 952, 22, 32, 32, 1);
      int x1 = 296;
      int y1 = 50;
      string name1 = this.game.Data.LandscapeTypeObj[this.ltnr].Name;
      ref Graphics local1 = ref Expression;
      Rectangle rectangle1 = new Rectangle(x1, y1, 192, 14);
      Rectangle rect1_1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(x1, y1 + 14, 192, 23);
      Rectangle rect2_1 = rectangle2;
      string txt2_1 = name1;
      DrawMod.MakeFullBoxVic2(ref local1, rect1_1, "SELECTED LANDSCAPE TYPE", rect2_1, txt2_1);
      int x2 = 532;
      int y2 = 50;
      string str1 = this.locnr <= -1 ? "No Location Type selected" : this.game.Data.LocTypeObj[this.locnr].Name;
      ref Graphics local2 = ref Expression;
      rectangle2 = new Rectangle(x2, y2, 192, 14);
      Rectangle rect1_2 = rectangle2;
      rectangle1 = new Rectangle(x2, y2 + 14, 192, 23);
      Rectangle rect2_2 = rectangle1;
      string txt2_2 = str1;
      DrawMod.MakeFullBoxVic2(ref local2, rect1_2, "SELECTED LOCATION TYPE", rect2_2, txt2_2);
      int num1 = 384;
      DrawMod.DrawRectangle(ref Expression, num1 - 1, y2 + 66, 251, 104, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
      this.spnr = 0;
      int num2 = num1;
      int num3 = y2 + 67;
      if (this.ltnr > -1 & this.spnr > -1)
      {
        if ((double) this.game.Data.RuleVar[869] == 0.0 | (double) this.game.Data.RuleVar[869] == 3.0)
        {
          int nr = this.game.Data.LandscapeTypeObj[this.ltnr].BasicPicID[this.spnr];
          ref Graphics local3 = ref Expression;
          Bitmap bitmap = BitmapStore.GetBitmap(nr);
          ref Bitmap local4 = ref bitmap;
          int x3 = num2;
          int y3 = num3;
          DrawMod.DrawScaled(ref local3, ref local4, x3, y3, 250, 103);
        }
        else
        {
          if ((double) this.game.Data.RuleVar[869] == 1.0)
          {
            int nr = this.game.Data.LandscapeTypeObj[this.ltnr].SidewaysSPriteID1[this.spnr];
            ref Graphics local5 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(nr);
            ref Bitmap local6 = ref bitmap;
            int x4 = num2;
            int y4 = num3;
            DrawMod.DrawScaled(ref local5, ref local6, x4, y4, 250, 103);
          }
          int nr1 = this.game.Data.LandscapeTypeObj[this.ltnr].SidewaysSPriteID2[this.spnr];
          ref Graphics local7 = ref Expression;
          Bitmap bitmap1 = BitmapStore.GetBitmap(nr1);
          ref Bitmap local8 = ref bitmap1;
          int x5 = num2;
          int y5 = num3;
          DrawMod.DrawScaled(ref local7, ref local8, x5, y5, 250, 103);
          int nr2 = this.game.Data.LandscapeTypeObj[this.ltnr].SidewaysSPriteID3[this.spnr];
          ref Graphics local9 = ref Expression;
          Bitmap bitmap2 = BitmapStore.GetBitmap(nr2);
          ref Bitmap local10 = ref bitmap2;
          int x6 = num2;
          int y6 = num3;
          DrawMod.DrawScaled(ref local9, ref local10, x6, y6, 250, 103);
        }
        if (this.locnr > -1 && this.game.Data.LocTypeObj[this.locnr].PictureLT > -1)
        {
          if ((double) this.game.Data.RuleVar[869] == 0.0 | (double) this.game.Data.RuleVar[869] == 3.0)
          {
            int nr = this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.locnr].PictureLT].BasicPicID[this.game.Data.LocTypeObj[this.locnr].PictureSprite];
            ref Graphics local11 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(nr);
            ref Bitmap local12 = ref bitmap;
            int x7 = num2;
            int y7 = num3;
            DrawMod.DrawScaled(ref local11, ref local12, x7, y7, 250, 103);
          }
          else
          {
            if ((double) this.game.Data.RuleVar[869] == 1.0)
            {
              int nr = this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.locnr].PictureLT].SidewaysSPriteID1[this.game.Data.LocTypeObj[this.locnr].PictureSprite];
              ref Graphics local13 = ref Expression;
              Bitmap bitmap = BitmapStore.GetBitmap(nr);
              ref Bitmap local14 = ref bitmap;
              int x8 = num2;
              int y8 = num3;
              DrawMod.DrawScaled(ref local13, ref local14, x8, y8, 250, 103);
            }
            int nr3 = this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.locnr].PictureLT].SidewaysSPriteID2[this.game.Data.LocTypeObj[this.locnr].PictureSprite];
            ref Graphics local15 = ref Expression;
            Bitmap bitmap3 = BitmapStore.GetBitmap(nr3);
            ref Bitmap local16 = ref bitmap3;
            int x9 = num2;
            int y9 = num3;
            DrawMod.DrawScaled(ref local15, ref local16, x9, y9, 250, 103);
            int nr4 = this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.locnr].PictureLT].SidewaysSPriteID3[this.game.Data.LocTypeObj[this.locnr].PictureSprite];
            ref Graphics local17 = ref Expression;
            Bitmap bitmap4 = BitmapStore.GetBitmap(nr4);
            ref Bitmap local18 = ref bitmap4;
            int x10 = num2;
            int y10 = num3;
            DrawMod.DrawScaled(ref local17, ref local18, x10, y10, 250, 103);
          }
        }
      }
      int num4 = 60;
      int num5 = 60;
      this.combatListObj = new ATListClass();
      int num6 = -1;
      int tlistselect = -1;
      int landscapeTypeCounter1 = this.game.Data.LandscapeTypeCounter;
      string str2;
      string str3;
      for (int tdata = 0; tdata <= landscapeTypeCounter1; ++tdata)
      {
        if (!this.game.Data.LandscapeTypeObj[tdata].DontShowInList)
        {
          str2 = "";
          str3 = "";
          ++num6;
          if (this.ltnr == tdata)
            tlistselect = num6;
          this.combatListObj.add(this.game.Data.LandscapeTypeObj[tdata].Name, tdata);
        }
      }
      if (this.combatListId > 0)
      {
        this.SubPartList[this.SubpartNr(this.combatListId)].Refresh(this.combatListObj, tlistselect);
        this.SubPartFlag[this.SubpartNr(this.combatListId)] = true;
      }
      else
      {
        SubPartClass tsubpart2 = (SubPartClass) new ATListSubPartClass(this.combatListObj, 11, 225, tlistselect, this.game, true, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num4, bby: num5);
        this.combatListId = this.AddSubPart(ref tsubpart2, num4, num5, 225, 192, 0);
      }
      int num7 = 745;
      int num8 = 60;
      this.combatList2Obj = new ATListClass();
      this.combatList2Obj.add("None", 9999);
      int locTypeCounter1 = this.game.Data.LocTypeCounter;
      for (int tdata = 0; tdata <= locTypeCounter1; ++tdata)
      {
        str2 = "";
        str3 = "";
        this.combatList2Obj.add(this.game.Data.LocTypeObj[tdata].Name, tdata);
      }
      SubPartClass tsubpart3;
      if (this.combatList2Id > 0)
      {
        this.SubPartList[this.SubpartNr(this.combatList2Id)].Refresh(this.combatList2Obj, this.locnr + 1);
        this.SubPartFlag[this.SubpartNr(this.combatList2Id)] = true;
      }
      else
      {
        tsubpart3 = (SubPartClass) new ATListSubPartClass(this.combatList2Obj, 11, 225, this.locnr + 1, this.game, true, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num7, bby: num8);
        this.combatList2Id = this.AddSubPart(ref tsubpart3, num7, num8, 225, 192, 0);
      }
      int num9 = 300;
      int num10 = 15;
      if (this.locnr > -1)
        num10 -= 85;
      tsubpart3 = (SubPartClass) new TextButtonPartClass("General Stats", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (num10 + 170), bby: num9, tred: (this.StatMode == 0));
      this.tab1id = this.AddSubPart(ref tsubpart3, num10 + 170, num9, 150, 35, 1);
      tsubpart3 = (SubPartClass) new TextButtonPartClass("Entrench Stats", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (num10 + 340), bby: num9, tred: (this.StatMode == 1));
      this.tab2id = this.AddSubPart(ref tsubpart3, num10 + 340, num9, 150, 35, 1);
      tsubpart3 = (SubPartClass) new TextButtonPartClass("Combat Mods", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (num10 + 510), bby: num9, tred: (this.StatMode == 2));
      this.tab3id = this.AddSubPart(ref tsubpart3, num10 + 510, num9, 150, 35, 1);
      tsubpart3 = (SubPartClass) new TextButtonPartClass("Movement Stats", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (num10 + 680), bby: num9, tred: (this.StatMode == 3));
      this.tab4id = this.AddSubPart(ref tsubpart3, num10 + 680, num9, 150, 35, 1);
      if (this.locnr > -1)
      {
        tsubpart3 = (SubPartClass) new TextButtonPartClass("Location Details", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (num10 + 850), bby: num9, tred: (this.StatMode == 4));
        this.tab5id = this.AddSubPart(ref tsubpart3, num10 + 850, num9, 150, 35, 1);
        num10 += 85;
      }
      else if (this.StatMode == 4)
        this.StatMode = 0;
      DrawMod.DrawBlock(ref Expression, num10 + 50, num9 + 55, 890, 355, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
      DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref Expression, num10 + 50, num9 + 55, 890, 355, -1, -1);
      int num11;
      int num12;
      int num13;
      Rectangle rectangle3;
      if (this.StatMode == 0)
      {
        num11 = -1;
        num12 = -1;
        num13 = 0;
        int num14 = 150;
        int num15 = 401;
        if (this.locnr == -1)
          num14 = 347;
        this.OptionsList3Obj = new ATListClass();
        str2 = "";
        str3 = "";
        this.OptionsList3Obj.add("Can Build Road", -1, Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.ltnr].CanBuildRoad)));
        str2 = "";
        str3 = "";
        this.OptionsList3Obj.add("Can Amphibious", -1, Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.ltnr].CanAmph)));
        str2 = "";
        str3 = "";
        this.OptionsList3Obj.add("Can Paradrop", -1, Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.ltnr].CanParadrop)));
        str2 = "";
        str3 = "";
        this.OptionsList3Obj.add("Road Cost Mod", -1, Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.ltnr].RoadCostModifier)));
        str2 = "";
        str3 = "";
        this.OptionsList3Obj.add("LandscapeType Group", -1, this.game.Data.TempString[this.game.Data.LandscapeTypeObj[this.ltnr].BuildGround + 100]);
        str2 = "";
        str3 = "";
        this.OptionsList3Obj.add("Is Sea", -1, Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.ltnr].IsSea)));
        str2 = "";
        str3 = "";
        this.OptionsList3Obj.add("Hide Points", -1, Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.ltnr].HidePts)));
        if (this.OptionsList3Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
        }
        else
        {
          tsubpart3 = (SubPartClass) new ATListSubPartClass(this.OptionsList3Obj, 6, 330, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 165, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num14, bby: num15);
          this.OptionsList3Id = this.AddSubPart(ref tsubpart3, num14, num15, 330, 112, 0);
        }
        ref Graphics local19 = ref Expression;
        rectangle2 = new Rectangle(num14, num15 - 14, 330, 13);
        Rectangle rect1_3 = rectangle2;
        Rectangle rect2_3 = rectangle3;
        DrawMod.MakeFullBoxVic2(ref local19, rect1_3, "LANDSCAPE GENERAL STATS", rect2_3, "");
        if (this.locnr > -1)
        {
          int num16 = 150;
          int num17 = 546;
          this.OptionsList4Obj = new ATListClass();
          str2 = "";
          str3 = "";
          this.OptionsList4Obj.add("Loc on Destruct", -1, !(this.game.Data.LocTypeObj[this.locnr].OnDestructLT > -1 & !this.game.Data.LocTypeObj[this.locnr].Invincible) ? "Indestructable" : this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.locnr].OnDestructLT].Name);
          str2 = "";
          str3 = "";
          string tvalue = Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.locnr].IsAirfield));
          if (this.game.Data.LocTypeObj[this.locnr].IsAirfield)
            tvalue = this.game.Data.LocTypeObj[this.locnr].TopAirStack <= 0 ? tvalue + ", unlimited stacking" : tvalue + ", max stack " + Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.locnr].TopAirStack));
          this.OptionsList4Obj.add("Is Airfield", -1, tvalue);
          str2 = "";
          str3 = "";
          this.OptionsList4Obj.add("Is Port", -1, Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.locnr].IsPort)));
          str2 = "";
          str3 = "";
          this.OptionsList4Obj.add("Buildable", -1, Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.locnr].Buildable)));
          str2 = "";
          str3 = "";
          this.OptionsList4Obj.add("Effect on LT", -1, this.game.Data.LocTypeObj[this.locnr].PictureLT <= -1 ? "No effect on LT" : "Adds to LT mods");
          str2 = "";
          str3 = "";
          this.OptionsList4Obj.add("Structural Points", -1, Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.locnr].StructuralPts)));
          str2 = "";
          str3 = "";
          this.OptionsList4Obj.add("Auto Repair", -1, Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.locnr].AutoRecoverPts)));
          str2 = "";
          str3 = "";
          this.OptionsList4Obj.add("Is Upgrade", -1, this.game.Data.LocTypeObj[this.locnr].UpgradeNr <= -1 ? "No" : "Yes, from " + this.game.Data.LocTypeObj[this.game.Data.LocTypeObj[this.locnr].UpgradeNr].Name);
          str2 = "";
          str3 = "";
          this.OptionsList4Obj.add("Production Points", -1, Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.locnr].MaxProd)));
          ref Graphics local20 = ref Expression;
          rectangle2 = new Rectangle(num16, num17 - 14, 330, 13);
          Rectangle rect1_4 = rectangle2;
          Rectangle rect2_4 = rectangle3;
          DrawMod.MakeFullBoxVic2(ref local20, rect1_4, "LOCATION TYPE GENERAL STATS", rect2_4, "");
          if (this.OptionsList4Id > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsList4Id)].Refresh(this.OptionsList4Obj, -1);
            this.SubPartFlag[this.SubpartNr(this.OptionsList4Id)] = true;
          }
          else
          {
            tsubpart3 = (SubPartClass) new ATListSubPartClass(this.OptionsList4Obj, 8, 330, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 165, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num16, bby: num17);
            this.OptionsList4Id = this.AddSubPart(ref tsubpart3, num16, num17, 330, 144, 0);
          }
        }
        string str4 = "";
        if (this.locnr > -1)
          str4 = str4 + this.game.Data.LocTypeObj[this.locnr].Name + "\r\n\r\n" + this.game.Data.LocTypeObj[this.locnr].Description + "\r\n\r\n";
        string tText = str4 + this.game.Data.LandscapeTypeObj[this.ltnr].Name + "\r\n\r\n" + this.game.Data.LandscapeTypeObj[this.ltnr].Description;
        if (this.locnr > -1)
        {
          int num18 = 530;
          int num19 = 411;
          DrawMod.DrawPaperSheet(ref Expression, num18 - 20, num19 - 10, 390, 280);
          tsubpart3 = (SubPartClass) new PaperAreaClass(this.game, 360, 13, (Font) null, "Description", false, tText, this.game.VicColor8, tItemSize: 20, tbackbitmap: (ref this.OwnBitmap), bbx: num18, bby: num19);
          this.descid = this.AddSubPart(ref tsubpart3, num18, num19, 360, 280, 0);
        }
        else
        {
          int num20 = 230;
          int num21 = 545;
          DrawMod.DrawPaperSheet(ref Expression, num20 - 20, num21 - 10, 590, 160);
          tsubpart3 = (SubPartClass) new PaperAreaClass(this.game, 560, 7, (Font) null, "Description", false, tText, this.game.VicColor8, tItemSize: 20, tbackbitmap: (ref this.OwnBitmap), bbx: num20, bby: num21);
          this.descid = this.AddSubPart(ref tsubpart3, num20, num21, 560, 160, 0);
        }
      }
      string tvalue3;
      string tvalue4;
      if (this.StatMode == 1)
      {
        int index1 = -1;
        if (this.locnr > -1 && this.game.Data.LocTypeObj[this.locnr].PictureLT > -1)
          index1 = this.game.Data.LocTypeObj[this.locnr].PictureLT;
        int num22 = 200;
        int num23 = 405;
        this.OptionsList3Obj = new ATListClass();
        if (index1 > -1)
        {
          ref Graphics local21 = ref Expression;
          rectangle2 = new Rectangle(num22, num23 - 14, 730, 13);
          Rectangle rect1_5 = rectangle2;
          Rectangle rect2_5 = rectangle3;
          DrawMod.MakeFullBoxVic2(ref local21, rect1_5, "                                                                               LANDSCAPE TYPE STATS                              LOCATION TYPE STATS", rect2_5, "");
          this.OptionsList3Obj.add("SUBFORMATION TYPE GROUP", -1, "AUTO ENTR", "MAX ENTR", "AUTO ENTR", "MAX ENTR");
        }
        else
          this.OptionsList3Obj.add("SUBFORMATION TYPE GROUP", -1, "AUTO ENTR", "MAX ENTR");
        int index2 = 0;
        do
        {
          if (!Information.IsNothing((object) this.game.Data.TempString[400 + index2]) && this.game.Data.TempString[400 + index2].Length > 1)
          {
            string tname = this.game.Data.TempString[400 + index2];
            string tvalue = Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.ltnr].DefBonus[index2]));
            string tvalue2 = Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.ltnr].DefBonusMax[index2]));
            if (index1 > -1)
            {
              tvalue3 = "+" + Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[index1].DefBonus[index2]));
              tvalue4 = "+" + Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[index1].DefBonusMax[index2]));
            }
            if (index1 > -1)
              this.OptionsList3Obj.add(tname, -1, tvalue, tvalue2, tvalue3, tvalue4);
            else
              this.OptionsList3Obj.add(tname, -1, tvalue, tvalue2);
          }
          ++index2;
        }
        while (index2 <= 99);
        if (this.OptionsList3Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
        }
        else
        {
          tsubpart3 = (SubPartClass) new ATListSubPartClass(this.OptionsList3Obj, 15, 630, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 430, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num22, bby: num23);
          this.OptionsList3Id = this.AddSubPart(ref tsubpart3, num22, num23, 630, 256, 0);
        }
      }
      if (this.StatMode == 2)
      {
        int index3 = -1;
        if (this.locnr > -1 && this.game.Data.LocTypeObj[this.locnr].PictureLT > -1)
          index3 = this.game.Data.LocTypeObj[this.locnr].PictureLT;
        int num24 = 200;
        int num25 = 405;
        this.OptionsList3Obj = new ATListClass();
        if (index3 > -1)
        {
          ref Graphics local22 = ref Expression;
          rectangle2 = new Rectangle(num24, num25 - 14, 730, 13);
          Rectangle rect1_6 = rectangle2;
          Rectangle rect2_6 = rectangle3;
          DrawMod.MakeFullBoxVic2(ref local22, rect1_6, "                                                                               LANDSCAPE TYPE STATS                              LOCATION TYPE STATS", rect2_6, "");
          this.OptionsList3Obj.add("SUBFORMATION TYPE", -1, "OFF MOD", "DEF MOD", "OFF MOD", "DEF MOD");
        }
        else
          this.OptionsList3Obj.add("SUBFORMATION TYPE", -1, "OFF MOD", "DEF MOD");
        int sfTypeCounter = this.game.Data.SFTypeCounter;
        for (int index4 = 0; index4 <= sfTypeCounter; ++index4)
        {
          if (!this.game.Data.SFTypeObj[index4].DontShowInList)
          {
            int num26 = 0;
            if ((double) this.game.Data.SFTypeObj[index4].CombatModAtt[this.ltnr] != 1.0)
              num26 = 1;
            if ((double) this.game.Data.SFTypeObj[index4].CombatModDef[this.ltnr] != 1.0)
              num26 = 1;
            if (index3 > -1)
            {
              if ((double) this.game.Data.SFTypeObj[index4].CombatModAtt[index3] != 1.0)
                num26 = 1;
              if ((double) this.game.Data.SFTypeObj[index4].CombatModDef[index3] != 1.0)
                num26 = 1;
            }
            if (num26 == 1)
            {
              string name2 = this.game.Data.SFTypeObj[index4].Name;
              string tvalue = "* " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[index4].CombatModAtt[this.ltnr]));
              string tvalue2 = "* " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[index4].CombatModDef[this.ltnr]));
              if (index3 > -1)
              {
                tvalue3 = "* " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[index4].CombatModAtt[index3]));
                tvalue4 = "* " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[index4].CombatModDef[index3]));
              }
              if (index3 > -1)
                this.OptionsList3Obj.add(name2, -1, tvalue, tvalue2, tvalue3, tvalue4);
              else
                this.OptionsList3Obj.add(name2, -1, tvalue, tvalue2);
            }
          }
        }
        if (this.OptionsList3Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
        }
        else
        {
          tsubpart3 = (SubPartClass) new ATListSubPartClass(this.OptionsList3Obj, 15, 630, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 430, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num24, bby: num25);
          this.OptionsList3Id = this.AddSubPart(ref tsubpart3, num24, num25, 630, 256, 0);
        }
      }
      if (this.StatMode == 3)
      {
        int num27 = -1;
        if (this.locnr > -1 && this.game.Data.LocTypeObj[this.locnr].PictureLT > -1)
          num27 = this.game.Data.LocTypeObj[this.locnr].PictureLT;
        int num28 = 300;
        int num29 = 405;
        this.OptionsList3Obj = new ATListClass();
        this.OptionsList3Obj.add("MOVEMENT TYPE", -1, "AP COST");
        int index = 0;
        do
        {
          if (this.game.Data.TempString[index].Length > 1)
            this.OptionsList3Obj.add(this.game.Data.TempString[index], -1, Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[this.ltnr].MoveCost[index])));
          ++index;
        }
        while (index <= 99);
        ref Graphics local23 = ref Expression;
        rectangle2 = new Rectangle(num28, num29 - 14, 730, 13);
        Rectangle rect1_7 = rectangle2;
        Rectangle rect2_7 = rectangle3;
        DrawMod.MakeFullBoxVic2(ref local23, rect1_7, "LANDSCAPE TYPE MOVEMENT COSTS", rect2_7, "");
        if (this.OptionsList3Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
        }
        else
        {
          tsubpart3 = (SubPartClass) new ATListSubPartClass(this.OptionsList3Obj, 15, 430, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 230, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num28, bby: num29);
          this.OptionsList3Id = this.AddSubPart(ref tsubpart3, num28, num29, 430, 256, 0);
        }
      }
      if (this.StatMode == 4 & this.locnr > -1)
      {
        num11 = -1;
        num12 = -1;
        num13 = 0;
        int num30 = 150;
        int num31 = 401;
        this.OptionsList3Obj = new ATListClass();
        str2 = "";
        str3 = "";
        this.OptionsList3Obj.add("Buildable", -1, Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.locnr].Buildable)));
        str2 = "";
        str3 = "";
        string tvalue;
        if ((double) this.game.Data.RuleVar[902] == 1.0)
        {
          tvalue = "No";
        }
        else
        {
          tvalue = "No";
          if (this.game.Data.LocTypeObj[this.locnr].EPCost > 0)
            tvalue = "Yes, EP cost " + Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.locnr].EPCost));
        }
        this.OptionsList3Obj.add("Repairable", -1, tvalue);
        if (this.game.Data.LocTypeObj[this.locnr].Buildable)
        {
          str2 = "";
          str3 = "";
          this.OptionsList3Obj.add("Is Upgrade", -1, this.game.Data.LocTypeObj[this.locnr].UpgradeNr <= -1 ? "No" : "Yes, from " + this.game.Data.LocTypeObj[this.game.Data.LocTypeObj[this.locnr].UpgradeNr].Name);
          int index5 = 0;
          do
          {
            if (this.game.Data.LocTypeObj[this.locnr].Research[index5] > -1)
            {
              str2 = "";
              str3 = "";
              this.OptionsList3Obj.add("Research Req", -1, this.game.Data.ResearchObj[this.game.Data.LocTypeObj[this.locnr].Research[index5]].Name);
            }
            ++index5;
          }
          while (index5 <= 4);
          if (this.game.Data.LocTypeObj[this.locnr].EPCost > 0)
            this.OptionsList3Obj.add("EP Cost", -1, Conversions.ToString(this.game.Data.LocTypeObj[this.locnr].EPCost));
          if (this.game.Data.LocTypeObj[this.locnr].PPCost > 0)
            this.OptionsList3Obj.add("PP Cost", -1, Conversions.ToString(this.game.Data.LocTypeObj[this.locnr].PPCost));
          if (this.game.Data.LocTypeObj[this.locnr].SupplyCost > 0)
            this.OptionsList3Obj.add("Supply Cost", -1, Conversions.ToString((int) Math.Round((double) ((float) this.game.Data.LocTypeObj[this.locnr].SupplyCost / this.game.Data.RuleVar[77]))));
          int index6 = 0;
          do
          {
            if (this.game.Data.LocTypeObj[this.locnr].VarQty[index6] > 0 | this.game.Data.LocTypeObj[this.locnr].VarType[index6] > -1)
              this.OptionsList3Obj.add(this.game.Data.RegimeSlotName[this.game.Data.LocTypeObj[this.locnr].VarType[index6]], -1, Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.locnr].VarQty[index6])));
            ++index6;
          }
          while (index6 <= 4);
        }
        ref Graphics local24 = ref Expression;
        rectangle2 = new Rectangle(num30, num31 - 14, 330, 13);
        Rectangle rect1_8 = rectangle2;
        Rectangle rect2_8 = rectangle3;
        DrawMod.MakeFullBoxVic2(ref local24, rect1_8, "BUILDING REQUIREMENTS", rect2_8, "");
        if (this.OptionsList3Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
        }
        else
        {
          tsubpart3 = (SubPartClass) new ATListSubPartClass(this.OptionsList3Obj, 6, 330, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 240, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num30, bby: num31);
          this.OptionsList3Id = this.AddSubPart(ref tsubpart3, num30, num31, 330, 112, 0);
        }
        int num32 = 150;
        int num33 = 546;
        this.OptionsList4Obj = new ATListClass();
        int index7 = 0;
        do
        {
          if (!Information.IsNothing((object) this.game.Data.TempString[300 + index7]) && this.game.Data.TempString[300 + index7].Length > 1 & this.game.Data.LocTypeObj[this.locnr].ItemGroup[index7])
          {
            str2 = "";
            str3 = "";
            this.OptionsList4Obj.add(this.game.Data.TempString[300 + index7], -1);
          }
          ++index7;
        }
        while (index7 <= 99);
        ref Graphics local25 = ref Expression;
        rectangle2 = new Rectangle(num32, num33 - 14, 330, 13);
        Rectangle rect1_9 = rectangle2;
        Rectangle rect2_9 = rectangle3;
        DrawMod.MakeFullBoxVic2(ref local25, rect1_9, "PRODUCABLE ITEM TYPE GROUPS", rect2_9, "");
        if (this.OptionsList4Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList4Id)].Refresh(this.OptionsList4Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList4Id)] = true;
        }
        else
        {
          tsubpart3 = (SubPartClass) new ATListSubPartClass(this.OptionsList4Obj, 7, 330, -1, this.game, true, tHighlight: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num32, bby: num33);
          this.OptionsList4Id = this.AddSubPart(ref tsubpart3, num32, num33, 330, 128, 0);
        }
        int num34 = 550;
        int num35 = 401;
        this.OptionsList5Obj = new ATListClass();
        int index8 = 0;
        do
        {
          if (!Information.IsNothing((object) this.game.Data.TempString[200 + index8]) && this.game.Data.TempString[200 + index8].Length > 1 & this.game.Data.LocTypeObj[this.locnr].PeopleGroup[index8])
          {
            str2 = "";
            str3 = "";
            this.OptionsList5Obj.add(this.game.Data.TempString[200 + index8], -1);
          }
          ++index8;
        }
        while (index8 <= 99);
        ref Graphics local26 = ref Expression;
        rectangle2 = new Rectangle(num34, num35 - 14, 330, 13);
        Rectangle rect1_10 = rectangle2;
        Rectangle rect2_10 = rectangle3;
        DrawMod.MakeFullBoxVic2(ref local26, rect1_10, "REGIME PEOPLES ALLOWED", rect2_10, "");
        if (this.OptionsList5Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList5Id)].Refresh(this.OptionsList5Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList5Id)] = true;
        }
        else
        {
          tsubpart3 = (SubPartClass) new ATListSubPartClass(this.OptionsList5Obj, 6, 160, -1, this.game, true, tHighlight: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num34, bby: num35);
          this.OptionsList5Id = this.AddSubPart(ref tsubpart3, num34, num35, 160, 112, 0);
        }
        int num36 = 720;
        int num37 = 401;
        int num38 = 0;
        this.OptionsList6Obj = new ATListClass();
        int index9 = 0;
        do
        {
          if (this.game.Data.LocTypeObj[this.locnr].MinDistance[index9] > 0)
          {
            int locTypeCounter2 = this.game.Data.LocTypeCounter;
            for (int index10 = 0; index10 <= locTypeCounter2; ++index10)
            {
              if (this.game.Data.LocTypeObj[this.locnr].MinDistance[this.game.Data.LocTypeObj[index10].LocTypeGroup] > 1)
              {
                ++num38;
                this.OptionsList6Obj.add(this.game.Data.LocTypeObj[index10].Name, -1, Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.locnr].MinDistance[this.game.Data.LocTypeObj[index10].LocTypeGroup])));
              }
            }
          }
          ++index9;
        }
        while (index9 <= 99);
        if (num38 == 0)
          this.OptionsList6Obj.add("No min. distances", -1);
        ref Graphics local27 = ref Expression;
        rectangle2 = new Rectangle(num36, num37 - 14, 330, 13);
        Rectangle rect1_11 = rectangle2;
        Rectangle rect2_11 = rectangle3;
        DrawMod.MakeFullBoxVic2(ref local27, rect1_11, "MIN.DISTANCE NEED", rect2_11, "");
        if (this.OptionsList6Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList6Id)].Refresh(this.OptionsList6Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList6Id)] = true;
        }
        else
        {
          tsubpart3 = (SubPartClass) new ATListSubPartClass(this.OptionsList6Obj, 6, 160, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 40, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num36, bby: num37);
          this.OptionsList6Id = this.AddSubPart(ref tsubpart3, num36, num37, 160, 112, 0);
        }
        int num39 = 550;
        int num40 = 546;
        if (this.game.Data.LocTypeObj[this.locnr].Buildable)
        {
          this.OptionsListObj = new ATListClass();
          int index11 = 0;
          do
          {
            if (this.game.Data.LocTypeObj[this.locnr].BuildgroundType[index11])
            {
              int landscapeTypeCounter2 = this.game.Data.LandscapeTypeCounter;
              for (int index12 = 0; index12 <= landscapeTypeCounter2; ++index12)
              {
                if (this.game.Data.LandscapeTypeObj[index12].BuildGround == index11 & !this.game.Data.LandscapeTypeObj[index12].DontShowInList)
                {
                  ++num38;
                  this.OptionsListObj.add(this.game.Data.LandscapeTypeObj[index12].Name, -1);
                }
              }
            }
            ++index11;
          }
          while (index11 <= 99);
          ref Graphics local28 = ref Expression;
          rectangle2 = new Rectangle(num39, num40 - 14, 330, 13);
          Rectangle rect1_12 = rectangle2;
          Rectangle rect2_12 = rectangle3;
          DrawMod.MakeFullBoxVic2(ref local28, rect1_12, "BUILDABLE LANDSC.TYPES", rect2_12, "");
          if (this.OptionsListId > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, -1);
            this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
          }
          else
          {
            tsubpart3 = (SubPartClass) new ATListSubPartClass(this.OptionsListObj, 6, 160, -1, this.game, true, tHighlight: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num39, bby: num40);
            this.OptionsListId = this.AddSubPart(ref tsubpart3, num39, num40, 160, 112, 0);
          }
        }
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    public object ReturnSFSpriteNr(int typ, int regnr, int pplnr)
    {
      int symbolSpriteId = this.game.Data.SFTypeObj[typ].SymbolSpriteID;
      if (regnr > -1)
      {
        if (this.game.Data.RegimeObj[regnr].ExtraGraphicUse > -1)
        {
          int extraCounter = this.game.Data.SFTypeObj[typ].ExtraCounter;
          for (int index = 0; index <= extraCounter; ++index)
          {
            if (this.game.Data.SFTypeObj[typ].ExtraCode[index] == this.game.Data.RegimeObj[regnr].ExtraGraphicUse)
              symbolSpriteId = this.game.Data.SFTypeObj[typ].ExtraSymbolSpriteID[index];
          }
        }
        else if (pplnr > -1 && this.game.Data.PeopleObj[pplnr].ExtraGraphicUse > -1)
        {
          int extraCounter = this.game.Data.SFTypeObj[typ].ExtraCounter;
          for (int index = 0; index <= extraCounter; ++index)
          {
            if (this.game.Data.SFTypeObj[typ].ExtraCode[index] == this.game.Data.PeopleObj[pplnr].ExtraGraphicUse)
              symbolSpriteId = this.game.Data.SFTypeObj[typ].ExtraSymbolSpriteID[index];
          }
        }
      }
      else if (this.game.Data.PeopleObj[pplnr].ExtraGraphicUse > -1)
      {
        int extraCounter = this.game.Data.SFTypeObj[typ].ExtraCounter;
        for (int index = 0; index <= extraCounter; ++index)
        {
          if (this.game.Data.SFTypeObj[typ].ExtraCode[index] == this.game.Data.PeopleObj[pplnr].ExtraGraphicUse)
            symbolSpriteId = this.game.Data.SFTypeObj[typ].ExtraSymbolSpriteID[index];
        }
      }
      return (object) symbolSpriteId;
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr == 27 | nr == 32)
        {
          this.game.EditObj.TempCoordList = new CoordList();
          windowReturnClass.AddCommand(6, 0);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return windowReturnClass;
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
            if (num1 == this.tab1id)
            {
              this.StatMode = 0;
              this.DoRefresh();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.tab2id)
            {
              this.StatMode = 1;
              this.DoRefresh();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.tab3id)
            {
              this.StatMode = 2;
              this.DoRefresh();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.tab4id)
            {
              this.StatMode = 3;
              this.DoRefresh();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.tab5id)
            {
              this.StatMode = 4;
              this.DoRefresh();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.quitid)
            {
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            int num2;
            if (num1 == this.OptionsListId)
            {
              num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.LogoListId)
            {
              num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.logolist2id)
            {
              num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.logolist3id)
            {
              num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsList2Id)
            {
              num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsList3Id)
            {
              num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.descid)
            {
              num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsList4Id)
            {
              num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsList5Id)
            {
              num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsList6Id)
            {
              num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.combatListId)
            {
              int num3 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              if (num3 > -1)
              {
                this.ltnr = num3;
                this.DoRefresh();
              }
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.combatList2Id)
            {
              int num4 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              if (num4 > -1)
              {
                this.locnr = num4;
                if (this.locnr == 9999)
                  this.locnr = -1;
                this.DoRefresh();
              }
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.but1id || num1 == this.but1bid)
            {
              this.game.EditObj.TempCoordList = new CoordList();
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.hqbut0)
            {
              this.HQselect = this.ChainHq[0];
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.hqbut1)
            {
              this.HQselect = this.ChainHq[1];
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.but7id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 74, -1);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.hqbut2)
            {
              this.HQselect = this.ChainHq[2];
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.but2id)
            {
              if (Interaction.MsgBox((object) "Are you sure you want to disband this subformation?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
              {
                if (this.game.EditObj.SoundOn)
                  SoundMod.PlayAWave(this.game.AppPath + "sound/disband.wav", ref this.game.EditObj);
                OrderResult orderResult = this.game.ProcessingObj.DoDisband(this.game.EditObj.UnitSelected, this.sfnr);
                if (orderResult.OK)
                {
                  if (orderResult.ErrorString.Length > 1)
                  {
                    int num5 = (int) Interaction.MsgBox((object) orderResult.ErrorString, Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  windowReturnClass.AddCommand(6, 0);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
              }
            }
            else
            {
              if (num1 == this.sliderid)
              {
                this.detailnr2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.but3id)
              {
                if (!this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ & this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount > 6 && this.game.Data.SFObj[this.sfnr].Qty != this.detailnr2)
                {
                  int num6 = (int) Interaction.MsgBox((object) "You can only upgrade ALL because there is already 8 subformations in unit.");
                  return windowReturnClass;
                }
                OrderResult orderResult = this.game.ProcessingObj.DoUpgrade(this.game.EditObj.UnitSelected, this.sfnr, this.detailnr2, this.HQselect);
                if (this.game.EditObj.SoundOn)
                  SoundMod.PlayAWave(this.game.AppPath + "sound/building.wav", ref this.game.EditObj);
                if (orderResult.OK)
                {
                  windowReturnClass.AddCommand(6, 0);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
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
  }
}
