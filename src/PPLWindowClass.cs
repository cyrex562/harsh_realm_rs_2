// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.PPLWindowClass
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
  public class PPLWindowClass : WindowClass
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

    public PPLWindowClass(ref GameClass tGame)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND2MARC)
    {
      this.ChainHq = new int[3];
      this.tempBlink = 0.0f;
      this.game.EditObj.CurrentDescript = "";
      this.unr = -1;
      this.ppl = this.game.EditObj.PeopleSelected;
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
      int num1 = 270;
      int y = 50;
      string name = this.game.Data.PeopleObj[this.ppl].Name;
      ref Graphics local1 = ref Expression;
      Rectangle rect1_1 = new Rectangle(num1, y, 192, 14);
      Rectangle rectangle1 = new Rectangle(num1, y + 14, 192, 23);
      Rectangle rect2_1 = rectangle1;
      string txt2 = name;
      DrawMod.MakeFullBoxVic2(ref local1, rect1_1, "SELECTED PEOPLE", rect2_1, txt2);
      SubPartClass tsubpart2;
      if (this.game.Data.PeopleObj[this.ppl].SFIll > -1)
      {
        tsubpart2 = (SubPartClass) new SFButtonPartClass(this.game.Data.PeopleObj[this.ppl].SFIll, this.game.Data.PeopleObj[this.ppl].SFExtra, 192, 144);
        this.temptext39 = this.AddSubPart(ref tsubpart2, num1, y + 47, 192, 144, 0);
      }
      else
        DrawMod.DrawBlock(ref Expression, num1, y + 47, 192, 144, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
      DrawMod.DrawRectangle(ref Expression, num1 - 1, y + 46, 193, 145, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
      int num2 = 522;
      int num3 = 60;
      this.combatListObj = new ATListClass();
      int peopleCounter1 = this.game.Data.PeopleCounter;
      for (int tdata = 0; tdata <= peopleCounter1; ++tdata)
        this.combatListObj.add(this.game.Data.PeopleObj[tdata].Name, tdata);
      if (this.combatListId > 0)
      {
        this.SubPartList[this.SubpartNr(this.combatListId)].Refresh(this.combatListObj, this.ppl);
        this.SubPartFlag[this.SubpartNr(this.combatListId)] = true;
      }
      else
      {
        tsubpart2 = (SubPartClass) new ATListSubPartClass(this.combatListObj, 11, 225, this.ppl, this.game, true, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num2, bby: num3);
        this.combatListId = this.AddSubPart(ref tsubpart2, num2, num3, 225, 192, 0);
      }
      int num4 = 265;
      int num5 = 96;
      tsubpart2 = (SubPartClass) new TextButtonPartClass("General Stats", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (num5 + 170), bby: num4, tred: (this.StatMode == 0));
      this.tab1id = this.AddSubPart(ref tsubpart2, num5 + 170, num4, 150, 35, 1);
      tsubpart2 = (SubPartClass) new TextButtonPartClass("Production Mods", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (num5 + 340), bby: num4, tred: (this.StatMode == 1));
      this.tab2id = this.AddSubPart(ref tsubpart2, num5 + 340, num4, 150, 35, 1);
      tsubpart2 = (SubPartClass) new TextButtonPartClass("Item Types", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (num5 + 510), bby: num4, tred: (this.StatMode == 2));
      this.tab3id = this.AddSubPart(ref tsubpart2, num5 + 510, num4, 150, 35, 1);
      DrawMod.DrawBlock(ref Expression, 65, num4 + 55, 890, 355, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
      DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref Expression, 65, num4 + 55, 890, 355, -1, -1);
      Rectangle rectangle2;
      if (this.StatMode == 0)
      {
        int num6 = 115;
        int num7 = 375;
        this.OptionsList3Obj = new ATListClass();
        ref Graphics local2 = ref Expression;
        rectangle1 = new Rectangle(num6, num7 - 14, 330, 13);
        Rectangle rect1_2 = rectangle1;
        string txt1 = Strings.UCase("Under People      Morale            Bat.For Mod    Ba.Vs Mod");
        Rectangle rect2_2 = rectangle2;
        DrawMod.MakeFullBoxVic2(ref local2, rect1_2, txt1, rect2_2, "");
        int peopleCounter2 = this.game.Data.PeopleCounter;
        for (int index = 0; index <= peopleCounter2; ++index)
        {
          int peopleGroup = this.game.Data.PeopleObj[index].PeopleGroup;
          this.OptionsList3Obj.add(this.game.Data.PeopleObj[index].Name, -1, Strings.Trim(Conversion.Str((object) this.game.Data.PeopleObj[this.ppl].BaseMorale[peopleGroup])), Strings.Trim(Conversion.Str((object) this.game.Data.PeopleObj[this.ppl].BattleForMod[peopleGroup])), Strings.Trim(Conversion.Str((object) this.game.Data.PeopleObj[this.ppl].BattleVSMod[peopleGroup])));
        }
        if (this.OptionsList3Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
        }
        else
        {
          tsubpart2 = (SubPartClass) new ATListSubPartClass(this.OptionsList3Obj, 15, 330, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 230, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num6, bby: num7);
          this.OptionsList3Id = this.AddSubPart(ref tsubpart2, num6, num7, 330, 256, 0);
        }
        int num8 = 530;
        int num9 = 390;
        string tText = this.game.Data.PeopleObj[this.ppl].Name + "\r\n\r\n" + this.game.Data.PeopleObj[this.ppl].Description;
        DrawMod.DrawPaperSheet(ref Expression, num8 - 20, num9 - 10, 390, 220);
        tsubpart2 = (SubPartClass) new PaperAreaClass(this.game, 360, 10, (Font) null, "Description", false, tText, this.game.VicColor8, tItemSize: 20, tbackbitmap: (ref this.OwnBitmap), bbx: num8, bby: num9);
        this.descid = this.AddSubPart(ref tsubpart2, num8, num9, 360, 220, 0);
      }
      if (this.StatMode == 1)
      {
        int num10 = 200;
        int num11 = 375;
        this.OptionsList4Obj = new ATListClass();
        ref Graphics local3 = ref Expression;
        rectangle1 = new Rectangle(num10, num11 - 14, 730, 13);
        Rectangle rect1_3 = rectangle1;
        string txt1 = Strings.UCase("Under Regime People                          ProdMod 1                 ProdMod 2                ProdMod 3               ProdMod4");
        Rectangle rect2_3 = rectangle2;
        DrawMod.MakeFullBoxVic2(ref local3, rect1_3, txt1, rect2_3, "");
        int peopleCounter3 = this.game.Data.PeopleCounter;
        for (int index = 0; index <= peopleCounter3; ++index)
        {
          int peopleGroup = this.game.Data.PeopleObj[index].PeopleGroup;
          this.OptionsList4Obj.add(this.game.Data.PeopleObj[index].Name, -1, Strings.Trim(Conversion.Str((object) this.game.Data.PeopleObj[this.ppl].ProdMod[peopleGroup])), Strings.Trim(Conversion.Str((object) this.game.Data.PeopleObj[this.ppl].ProdMod2[peopleGroup])), Strings.Trim(Conversion.Str((object) this.game.Data.PeopleObj[this.ppl].ProdMod3[peopleGroup])), Strings.Trim(Conversion.Str((object) this.game.Data.PeopleObj[this.ppl].ProdMod4[peopleGroup])));
        }
        if (this.OptionsList4Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList4Id)].Refresh(this.OptionsList4Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList4Id)] = true;
        }
        else
        {
          tsubpart2 = (SubPartClass) new ATListSubPartClass(this.OptionsList4Obj, 15, 630, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 430, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num10, bby: num11);
          this.OptionsList4Id = this.AddSubPart(ref tsubpart2, num10, num11, 630, 256, 0);
        }
      }
      if (this.StatMode == 2)
      {
        int num12 = 200;
        int num13 = 375;
        this.OptionsList4Obj = new ATListClass();
        ref Graphics local4 = ref Expression;
        rectangle1 = new Rectangle(num12, num13 - 14, 730, 13);
        Rectangle rect1_4 = rectangle1;
        string txt1 = Strings.UCase("ItemType                                              ProdMod                                                      People Overrule");
        Rectangle rect2_4 = rectangle2;
        DrawMod.MakeFullBoxVic2(ref local4, rect1_4, txt1, rect2_4, "");
        int itemTypeCounter = this.game.Data.ItemTypeCounter;
        for (int index = 0; index <= itemTypeCounter; ++index)
          this.OptionsList4Obj.add(this.game.Data.ItemTypeObj[index].Name, -1, this.game.Data.ItemTypeObj[index].UseProdMod > 1 ? Strings.Trim(Conversion.Str((object) this.game.Data.ItemTypeObj[index].UseProdMod)) : "1", this.game.Data.ItemTypeObj[index].PeopleMod <= 0 ? "none" : this.game.Data.PeopleObj[this.game.Data.ItemTypeObj[index].PeopleMod].Name);
        if (this.OptionsList4Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList4Id)].Refresh(this.OptionsList4Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList4Id)] = true;
        }
        else
        {
          tsubpart2 = (SubPartClass) new ATListSubPartClass(this.OptionsList4Obj, 15, 630, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 430, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num12, bby: num13);
          this.OptionsList4Id = this.AddSubPart(ref tsubpart2, num12, num13, 630, 256, 0);
        }
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
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
                this.ppl = num3;
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
