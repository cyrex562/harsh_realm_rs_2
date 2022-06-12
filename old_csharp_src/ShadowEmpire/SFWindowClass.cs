// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SFWindowClass
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
  public class SFWindowClass : WindowClass
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

    public SFWindowClass(ref GameClass tGame)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND2MARC)
    {
      this.ChainHq = new int[3];
      this.tempBlink = 0.0f;
      this.sfnr = -1;
      this.comparenr = -1;
      this.game.EditObj.SFCompare = -1;
      this.game.EditObj.CurrentDescript = "";
      this.unr = -1;
      if (this.game.EditObj.SFSelected > -1)
      {
        if (this.game.EditObj.SFSelected > this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount)
        {
          this.passenger = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].PassengerList[this.game.EditObj.SFSelected - (1 + this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount)];
          this.sfnr = -1;
          this.sftyp = -1;
        }
        else
        {
          this.sfnr = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFList[this.game.EditObj.SFSelected];
          this.sftyp = this.game.Data.SFObj[this.sfnr].Type;
          this.unr = this.game.EditObj.UnitSelected;
          this.passenger = -1;
        }
      }
      else
      {
        this.sftyp = this.game.EditObj.SFTypeSelected;
        this.sfnr = -1;
      }
      this.ChainHq[0] = -1;
      this.HQselect = -1;
      this.ChainHq[1] = -1;
      this.ChainHq[2] = -1;
      if (this.sfnr > -1 && this.game.HandyFunctionsObj.CanUpgrade(this.sfnr, this.unr))
      {
        if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
        {
          this.ChainHq[0] = this.game.EditObj.UnitSelected;
          this.HQselect = this.game.EditObj.UnitSelected;
          int hq1 = this.game.Data.UnitObj[this.ChainHq[0]].HQ;
          if (hq1 > -1 && this.game.Data.UnitObj[hq1].X > -1)
          {
            this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, (int) Math.Round((double) this.game.Data.RuleVar[99]), 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y, this.game.Data.UnitObj[this.unr].Map, allowshoredrop: true);
            if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq1].Map].Value[this.game.Data.UnitObj[hq1].X, this.game.Data.UnitObj[hq1].Y] <= (double) this.game.Data.RuleVar[53])
            {
              this.ChainHq[1] = hq1;
              int hq2 = this.game.Data.UnitObj[this.ChainHq[1]].HQ;
              if (hq2 > -1 && this.game.Data.UnitObj[hq2].X > -1 && (double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq2].Map].Value[this.game.Data.UnitObj[hq2].X, this.game.Data.UnitObj[hq2].Y] <= (double) this.game.Data.RuleVar[53])
                this.ChainHq[2] = hq2;
            }
          }
        }
        else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ > -1 && this.game.Data.UnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ].X > -1)
        {
          this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, (int) Math.Round((double) this.game.Data.RuleVar[99]), 99, (int) Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y, this.game.Data.UnitObj[this.unr].Map, allowshoredrop: true);
          int hq3 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ;
          if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq3].Map].Value[this.game.Data.UnitObj[hq3].X, this.game.Data.UnitObj[hq3].Y] <= (double) this.game.Data.RuleVar[53])
          {
            this.ChainHq[0] = hq3;
            this.HQselect = hq3;
            int hq4 = this.game.Data.UnitObj[this.ChainHq[0]].HQ;
            if (hq4 > -1 && this.game.Data.UnitObj[hq4].X > -1 && (double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq4].Map].Value[this.game.Data.UnitObj[hq4].X, this.game.Data.UnitObj[hq4].Y] <= (double) this.game.Data.RuleVar[53])
            {
              this.ChainHq[1] = hq4;
              int hq5 = this.game.Data.UnitObj[this.ChainHq[1]].HQ;
              if (hq5 > -1 && this.game.Data.UnitObj[hq5].X > -1 && (double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq5].Map].Value[this.game.Data.UnitObj[hq5].X, this.game.Data.UnitObj[hq5].Y] <= (double) this.game.Data.RuleVar[53])
                this.ChainHq[2] = hq5;
            }
          }
        }
      }
      this.StatTyp = 1;
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
      this.comparenr = this.game.EditObj.SFCompare;
      int num1;
      int y1;
      if (this.comparenr > -1)
      {
        num1 = 180;
        y1 = 50;
      }
      else
      {
        num1 = 349;
        y1 = 50;
      }
      int index1;
      int index2;
      if (this.sftyp > -1)
      {
        index1 = this.sftyp;
        index2 = this.game.Data.Turn <= -1 ? 0 : this.game.Data.RegimeObj[this.game.Data.Turn].People;
      }
      else
        index1 = -1;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (index1 > -1)
      {
        string str1 = "";
        if (this.sfnr > -1)
        {
          index1 = this.game.Data.SFObj[this.sfnr].Type;
          index2 = this.game.Data.SFObj[this.sfnr].People;
          if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn)
          {
            str1 = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Qty)) + "x ";
            if (this.game.Data.SFTypeObj[index1].Ratio > 1)
              str1 = str1 + " " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[index1].Ratio)) + "x ";
          }
        }
        string str2;
        int index3;
        int index4;
        int index5;
        if (index1 > -1)
        {
          string name = this.game.Data.SFTypeObj[index1].Name;
          int index6;
          if (this.game.Data.RegimeObj[index6].ExtraGraphicUse > -1)
          {
            int extraCounter = this.game.Data.SFTypeObj[index1].ExtraCounter;
            for (int index7 = 0; index7 <= extraCounter; ++index7)
            {
              if (this.game.Data.SFTypeObj[index1].ExtraCode[index7] == this.game.Data.RegimeObj[index6].ExtraGraphicUse)
                name = this.game.Data.SFTypeObj[index1].ExtraName[index7];
            }
          }
          else if (index2 > -1 & this.sfnr > -1 && this.game.Data.PeopleObj[this.game.Data.SFObj[this.sfnr].People].ExtraGraphicUse > -1)
          {
            int extraCounter = this.game.Data.SFTypeObj[index1].ExtraCounter;
            for (int index8 = 0; index8 <= extraCounter; ++index8)
            {
              if (this.game.Data.SFTypeObj[index1].ExtraCode[index8] == this.game.Data.PeopleObj[index2].ExtraGraphicUse)
                name = this.game.Data.SFTypeObj[index1].ExtraName[index8];
            }
          }
          str2 = name;
          string str3 = str1 + name;
          index6 = 0;
          index3 = this.sfnr <= -1 ? this.game.Data.Turn : this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime;
          int picSpriteId = this.game.Data.SFTypeObj[index1].PicSpriteID;
          int sidewaysSpriteId = this.game.Data.SFTypeObj[index1].SidewaysSpriteID;
          if (this.game.Data.RegimeObj[index3].ExtraGraphicUse > -1)
          {
            int extraCounter = this.game.Data.SFTypeObj[index1].ExtraCounter;
            for (int index9 = 0; index9 <= extraCounter; ++index9)
            {
              if (this.game.Data.SFTypeObj[index1].ExtraCode[index9] == this.game.Data.RegimeObj[index3].ExtraGraphicUse)
              {
                picSpriteId = this.game.Data.SFTypeObj[index1].ExtraPicSpriteID[index9];
                sidewaysSpriteId = this.game.Data.SFTypeObj[index1].ExtraSidewaysSpriteID[index9];
              }
            }
          }
          else if (index2 > -1 && this.game.Data.PeopleObj[index2].ExtraGraphicUse > -1)
          {
            int extraCounter = this.game.Data.SFTypeObj[index1].ExtraCounter;
            for (int index10 = 0; index10 <= extraCounter; ++index10)
            {
              if (this.game.Data.SFTypeObj[index1].ExtraCode[index10] == this.game.Data.PeopleObj[index2].ExtraGraphicUse)
              {
                picSpriteId = this.game.Data.SFTypeObj[index1].ExtraPicSpriteID[index10];
                sidewaysSpriteId = this.game.Data.SFTypeObj[index1].ExtraSidewaysSpriteID[index10];
              }
            }
          }
          ref Graphics local1 = ref Expression;
          rectangle1 = new Rectangle(num1, y1, 322, 14);
          Rectangle rect1 = rectangle1;
          rectangle2 = new Rectangle(num1, y1 + 14, 322, 23);
          Rectangle rect2 = rectangle2;
          string txt2 = str3;
          DrawMod.MakeFullBoxVic2(ref local1, rect1, "SELECTED SUBFORMATION(TYPE)", rect2, txt2);
          int x1 = num1;
          int y2 = y1 + 47;
          if ((double) this.game.Data.RuleVar[869] >= 1.0)
          {
            index4 = (int) Math.Round((double) this.game.Data.RuleVar[873]);
            index5 = 0;
            if ((double) this.game.Data.RuleVar[848] > 0.0 & this.game.Data.SFTypeObj[index1].Theater == 2)
            {
              index4 = (int) Math.Round((double) this.game.Data.RuleVar[848]);
              index5 = 0;
            }
            if ((double) this.game.Data.RuleVar[872] > 0.0 & this.game.Data.SFTypeObj[index1].Theater == 1)
            {
              index4 = (int) Math.Round((double) this.game.Data.RuleVar[872]);
              index5 = 0;
            }
            if ((double) this.game.Data.RuleVar[869] == 3.0)
            {
              int nr = this.game.Data.LandscapeTypeObj[index4].BasicPicID[index5];
              ref Graphics local2 = ref Expression;
              Bitmap bitmap = BitmapStore.GetBitmap(nr);
              ref Bitmap local3 = ref bitmap;
              rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr));
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(x1, y2, 192, 144);
              Rectangle destrect = rectangle1;
              DrawMod.DrawSimplePart2(ref local2, ref local3, srcrect, destrect);
            }
            else
            {
              if ((double) this.game.Data.RuleVar[869] == 1.0)
              {
                int nr = this.game.Data.LandscapeTypeObj[index4].SidewaysSPriteID1[index5];
                ref Graphics local4 = ref Expression;
                Bitmap bitmap = BitmapStore.GetBitmap(nr);
                ref Bitmap local5 = ref bitmap;
                rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr));
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(x1, y2, 192, 144);
                Rectangle destrect = rectangle1;
                DrawMod.DrawSimplePart2(ref local4, ref local5, srcrect, destrect);
              }
              int nr1 = this.game.Data.LandscapeTypeObj[index4].SidewaysSPriteID2[index5];
              ref Graphics local6 = ref Expression;
              Bitmap bitmap1 = BitmapStore.GetBitmap(nr1);
              ref Bitmap local7 = ref bitmap1;
              rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr1));
              Rectangle srcrect1 = rectangle2;
              rectangle1 = new Rectangle(x1, y2, 192, 144);
              Rectangle destrect1 = rectangle1;
              DrawMod.DrawSimplePart2(ref local6, ref local7, srcrect1, destrect1);
            }
          }
          int index11 = index3;
          int red = this.game.Data.RegimeObj[index11].Red;
          int green = this.game.Data.RegimeObj[index11].Green;
          int blue = this.game.Data.RegimeObj[index11].Blue;
          switch (this.game.Data.SFTypeObj[index1].BaseColor)
          {
            case 0:
              ref Graphics local8 = ref Expression;
              Bitmap bitmap2 = BitmapStore.GetBitmap(picSpriteId);
              ref Bitmap local9 = ref bitmap2;
              int x2 = x1;
              int y3 = y2;
              DrawMod.DrawScaled(ref local8, ref local9, x2, y3, 192, 144);
              break;
            case 1:
              ref Graphics local10 = ref Expression;
              Bitmap bitmap3 = BitmapStore.GetBitmap(picSpriteId);
              ref Bitmap local11 = ref bitmap3;
              int x3 = x1;
              int y4 = y2;
              int width1 = BitmapStore.GetWidth(picSpriteId);
              int origh1 = BitmapStore.Getheight(picSpriteId);
              double r1 = (double) ((float) red / 256f);
              double g1 = (double) ((float) green / 256f);
              double b1 = (double) ((float) blue / 256f);
              DrawMod.DrawScaledColorized2(ref local10, ref local11, x3, y4, 192, 144, width1, origh1, (float) r1, (float) g1, (float) b1, 1f);
              break;
            case 2:
              int red2 = this.game.Data.RegimeObj[index11].Red2;
              int green2 = this.game.Data.RegimeObj[index11].Green2;
              int blue2 = this.game.Data.RegimeObj[index11].Blue2;
              ref Graphics local12 = ref Expression;
              Bitmap bitmap4 = BitmapStore.GetBitmap(picSpriteId);
              ref Bitmap local13 = ref bitmap4;
              int x4 = x1;
              int y5 = y2;
              int width2 = BitmapStore.GetWidth(picSpriteId);
              int origh2 = BitmapStore.Getheight(picSpriteId);
              double r2 = (double) ((float) red2 / 256f);
              double g2 = (double) ((float) green2 / 256f);
              double b2 = (double) ((float) blue2 / 256f);
              DrawMod.DrawScaledColorized2(ref local12, ref local13, x4, y5, 192, 144, width2, origh2, (float) r2, (float) g2, (float) b2, 1f);
              break;
            case 3:
              int red3 = this.game.Data.RegimeObj[index11].Red3;
              int green3 = this.game.Data.RegimeObj[index11].Green3;
              int blue3 = this.game.Data.RegimeObj[index11].Blue3;
              ref Graphics local14 = ref Expression;
              Bitmap bitmap5 = BitmapStore.GetBitmap(picSpriteId);
              ref Bitmap local15 = ref bitmap5;
              int x5 = x1;
              int y6 = y2;
              int width3 = BitmapStore.GetWidth(picSpriteId);
              int origh3 = BitmapStore.Getheight(picSpriteId);
              double r3 = (double) ((float) red3 / 256f);
              double g3 = (double) ((float) green3 / 256f);
              double b3 = (double) ((float) blue3 / 256f);
              DrawMod.DrawScaledColorized2(ref local14, ref local15, x5, y6, 192, 144, width3, origh3, (float) r3, (float) g3, (float) b3, 1f);
              break;
            case 4:
              int red4 = this.game.Data.RegimeObj[index11].Red4;
              int green4 = this.game.Data.RegimeObj[index11].Green4;
              int blue4 = this.game.Data.RegimeObj[index11].Blue4;
              ref Graphics local16 = ref Expression;
              Bitmap bitmap6 = BitmapStore.GetBitmap(picSpriteId);
              ref Bitmap local17 = ref bitmap6;
              int x6 = x1;
              int y7 = y2;
              int width4 = BitmapStore.GetWidth(picSpriteId);
              int origh4 = BitmapStore.Getheight(picSpriteId);
              double r4 = (double) ((float) red4 / 256f);
              double g4 = (double) ((float) green4 / 256f);
              double b4 = (double) ((float) blue4 / 256f);
              DrawMod.DrawScaledColorized2(ref local16, ref local17, x6, y7, 192, 144, width4, origh4, (float) r4, (float) g4, (float) b4, 1f);
              break;
            case 5:
              ref Graphics local18 = ref Expression;
              Bitmap bitmap7 = BitmapStore.GetBitmap(picSpriteId);
              ref Bitmap local19 = ref bitmap7;
              int x7 = x1;
              int y8 = y2;
              int width5 = BitmapStore.GetWidth(picSpriteId);
              int origh5 = BitmapStore.Getheight(picSpriteId);
              double r5 = (double) ((float) (red + 392) / 1024f);
              double g5 = (double) ((float) (green + 392) / 1024f);
              double b5 = (double) ((float) (blue + 392) / 1024f);
              DrawMod.DrawScaledColorized2(ref local18, ref local19, x7, y8, 192, 144, width5, origh5, (float) r5, (float) g5, (float) b5, 1f);
              break;
            case 6:
              ref Graphics local20 = ref Expression;
              Bitmap bitmap8 = BitmapStore.GetBitmap(picSpriteId);
              ref Bitmap local21 = ref bitmap8;
              int x8 = x1;
              int y9 = y2;
              int width6 = BitmapStore.GetWidth(picSpriteId);
              int origh6 = BitmapStore.Getheight(picSpriteId);
              double r6 = (double) ((float) (red + 80) / 512f);
              double g6 = (double) ((float) (green + 200) / 512f);
              double b6 = (double) ((float) (blue + 80) / 512f);
              DrawMod.DrawScaledColorized2(ref local20, ref local21, x8, y9, 192, 144, width6, origh6, (float) r6, (float) g6, (float) b6, 1f);
              break;
          }
          if ((double) this.game.Data.RuleVar[870] > 0.0 & !Information.IsNothing((object) BitmapStore.GetBitmap(sidewaysSpriteId)))
          {
            ref Graphics local22 = ref Expression;
            Bitmap bitmap9 = BitmapStore.GetBitmap(sidewaysSpriteId);
            ref Bitmap local23 = ref bitmap9;
            int x9 = x1;
            int y10 = y2;
            DrawMod.DrawScaled(ref local22, ref local23, x9, y10, 192, 144);
          }
          if ((double) this.game.Data.RuleVar[869] >= 1.0 & (double) this.game.Data.RuleVar[869] < 3.0)
          {
            int nr = this.game.Data.LandscapeTypeObj[index4].SidewaysSPriteID3[index5];
            ref Graphics local24 = ref Expression;
            Bitmap bitmap10 = BitmapStore.GetBitmap(nr);
            ref Bitmap local25 = ref bitmap10;
            rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr));
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(x1, y2, 192, 144);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local24, ref local25, srcrect, destrect);
          }
          DrawMod.DrawRectangle(ref Expression, num1, y1 + 47, 192, 144, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
        }
        if (this.sfnr > -1)
        {
          this.OptionsList2Obj = new ATListClass();
          int tdata;
          this.OptionsList2Obj.add("AP", tdata, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Ap)));
          this.OptionsList2Obj.add("RDN", tdata, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Rdn)));
          this.OptionsList2Obj.add("EXP", tdata, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Xp)));
          this.OptionsList2Obj.add("MOR", tdata, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Mor)));
          this.OptionsList2Obj.add("ENT", tdata, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].CurrentEntrench)));
          this.OptionsList2Obj.add("OFF", tdata, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].OffMod)) + "%");
          this.OptionsList2Obj.add("DEF", tdata, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].DefMod)) + "%");
          float num2 = -1f;
          if (this.game.EditObj.UnitSelected > -1 & this.sfnr > -1 && this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].Theater == 2)
          {
            num2 = (double) this.game.HandyFunctionsObj.GetAirFieldStackModifier(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y) >= 1.0 ? 1f : (float) (0.33 + 0.66 * (double) this.game.HandyFunctionsObj.GetAirFieldStackModifier(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y));
            if ((double) num2 < 1.0)
            {
              string tvalue = Strings.Trim(Conversion.Str((object) -(int) Math.Round(100.0 - 100.0 * (double) num2))) + "%";
              this.OptionsList2Obj.add("AIRSTK", tdata, tvalue);
            }
            else
              this.OptionsList2Obj.add("AIRSTK", tdata, "0%");
          }
          if ((double) num2 == -1.0)
            this.OptionsList2Obj.add("AIRSTK", tdata, "0%");
          this.OptionsList2Obj.add("EP", tdata, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].EP)));
          this.OptionsList2Obj.add("PPL", tdata, Strings.Left(this.game.Data.PeopleObj[this.game.Data.SFObj[this.sfnr].People].Name, 7));
          if (this.game.Data.SFObj[this.sfnr].MoveType > -1)
            this.OptionsList2Obj.add("MOVE", tdata, this.game.Data.TempString[this.game.Data.SFObj[this.sfnr].MoveType]);
          else
            this.OptionsList2Obj.add("MOVE", tdata, "normal");
          if (this.OptionsList2Id > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsList2Id)].Refresh(this.OptionsList2Obj, -1);
            this.SubPartFlag[this.SubpartNr(this.OptionsList2Id)] = true;
          }
          else
          {
            SubPartClass tsubpart2 = (SubPartClass) new ATListSubPartClass(this.OptionsList2Obj, 10, 125, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 75, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: (num1 + 200), bby: (y1 + 47));
            this.OptionsList2Id = this.AddSubPart(ref tsubpart2, num1 + 200, y1 + 47, 125, 176, 0);
          }
        }
        if (this.comparenr == -1)
        {
          SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Compare", 125, "Allows you to compare with a different subformation type", ref this.OwnBitmap, num1 + 403, y1 + 115);
          this.but7id = this.AddSubPart(ref tsubpart3, num1 + 403, y1 + 115, 125, 35, 1);
        }
        else
        {
          SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Change Compare", 125, "Allows you to compare with a different subformation type", ref this.OwnBitmap, num1 + 623, y1 + 115);
          this.but7id = this.AddSubPart(ref tsubpart4, num1 + 623, y1 + 115, 125, 35, 1);
        }
        int index12;
        if (this.comparenr > -1)
        {
          num1 = 570;
          y1 = 50;
          index12 = this.comparenr;
          index2 = this.game.Data.Turn <= -1 ? 0 : this.game.Data.RegimeObj[this.game.Data.Turn].People;
        }
        else
          index12 = -1;
        if (this.comparenr > -1)
        {
          string str4 = "";
          if (index12 > -1)
          {
            string name = this.game.Data.SFTypeObj[index12].Name;
            if (this.game.Data.RegimeObj[index3].ExtraGraphicUse > -1)
            {
              int extraCounter = this.game.Data.SFTypeObj[index12].ExtraCounter;
              for (int index13 = 0; index13 <= extraCounter; ++index13)
              {
                if (this.game.Data.SFTypeObj[index12].ExtraCode[index13] == this.game.Data.RegimeObj[index3].ExtraGraphicUse)
                  name = this.game.Data.SFTypeObj[index12].ExtraName[index13];
              }
            }
            else if (index2 > -1 && this.game.Data.PeopleObj[index2].ExtraGraphicUse > -1)
            {
              int extraCounter = this.game.Data.SFTypeObj[index12].ExtraCounter;
              for (int index14 = 0; index14 <= extraCounter; ++index14)
              {
                if (this.game.Data.SFTypeObj[index12].ExtraCode[index14] == this.game.Data.PeopleObj[index2].ExtraGraphicUse)
                  name = this.game.Data.SFTypeObj[index12].ExtraName[index14];
              }
            }
            string str5 = str4 + name;
            int turn = this.game.Data.Turn;
            int picSpriteId = this.game.Data.SFTypeObj[index12].PicSpriteID;
            int sidewaysSpriteId = this.game.Data.SFTypeObj[index12].SidewaysSpriteID;
            if (this.game.Data.RegimeObj[turn].ExtraGraphicUse > -1)
            {
              int extraCounter = this.game.Data.SFTypeObj[index12].ExtraCounter;
              for (int index15 = 0; index15 <= extraCounter; ++index15)
              {
                if (this.game.Data.SFTypeObj[index12].ExtraCode[index15] == this.game.Data.RegimeObj[turn].ExtraGraphicUse)
                {
                  picSpriteId = this.game.Data.SFTypeObj[index12].ExtraPicSpriteID[index15];
                  sidewaysSpriteId = this.game.Data.SFTypeObj[index12].ExtraSidewaysSpriteID[index15];
                }
              }
            }
            else if (index2 > -1 && this.game.Data.PeopleObj[index2].ExtraGraphicUse > -1)
            {
              int extraCounter = this.game.Data.SFTypeObj[index12].ExtraCounter;
              for (int index16 = 0; index16 <= extraCounter; ++index16)
              {
                if (this.game.Data.SFTypeObj[index12].ExtraCode[index16] == this.game.Data.PeopleObj[index2].ExtraGraphicUse)
                {
                  picSpriteId = this.game.Data.SFTypeObj[index12].ExtraPicSpriteID[index16];
                  sidewaysSpriteId = this.game.Data.SFTypeObj[index12].ExtraSidewaysSpriteID[index16];
                }
              }
            }
            ref Graphics local26 = ref Expression;
            rectangle2 = new Rectangle(num1, y1, 192, 14);
            Rectangle rect1 = rectangle2;
            rectangle1 = new Rectangle(num1, y1 + 14, 192, 23);
            Rectangle rect2 = rectangle1;
            string txt2 = str5;
            DrawMod.MakeFullBoxVic2(ref local26, rect1, "COMPARISON SUBFORMATIONTYPE", rect2, txt2);
            int index17 = turn;
            int red = this.game.Data.RegimeObj[index17].Red;
            int green = this.game.Data.RegimeObj[index17].Green;
            int blue = this.game.Data.RegimeObj[index17].Blue;
            int baseColor = this.game.Data.SFTypeObj[index12].BaseColor;
            int x10 = num1;
            int y11 = y1 + 47;
            if ((double) this.game.Data.RuleVar[869] >= 1.0)
            {
              index4 = (int) Math.Round((double) this.game.Data.RuleVar[873]);
              index5 = 0;
              if ((double) this.game.Data.RuleVar[848] > 0.0 & this.game.Data.SFTypeObj[index12].Theater == 2)
              {
                index4 = (int) Math.Round((double) this.game.Data.RuleVar[848]);
                index5 = 0;
              }
              if ((double) this.game.Data.RuleVar[872] > 0.0 & this.game.Data.SFTypeObj[index12].Theater == 1)
              {
                index4 = (int) Math.Round((double) this.game.Data.RuleVar[872]);
                index5 = 0;
              }
              if ((double) this.game.Data.RuleVar[869] == 3.0)
              {
                int nr = this.game.Data.LandscapeTypeObj[index4].BasicPicID[index5];
                ref Graphics local27 = ref Expression;
                Bitmap bitmap = BitmapStore.GetBitmap(nr);
                ref Bitmap local28 = ref bitmap;
                rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr));
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(x10, y11, 192, 144);
                Rectangle destrect = rectangle1;
                DrawMod.DrawSimplePart2(ref local27, ref local28, srcrect, destrect);
              }
              else
              {
                if ((double) this.game.Data.RuleVar[869] == 1.0)
                {
                  int nr = this.game.Data.LandscapeTypeObj[index4].SidewaysSPriteID1[index5];
                  ref Graphics local29 = ref Expression;
                  Bitmap bitmap = BitmapStore.GetBitmap(nr);
                  ref Bitmap local30 = ref bitmap;
                  rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr));
                  Rectangle srcrect = rectangle2;
                  rectangle1 = new Rectangle(x10, y11, 192, 144);
                  Rectangle destrect = rectangle1;
                  DrawMod.DrawSimplePart2(ref local29, ref local30, srcrect, destrect);
                }
                int nr2 = this.game.Data.LandscapeTypeObj[index4].SidewaysSPriteID2[index5];
                ref Graphics local31 = ref Expression;
                Bitmap bitmap11 = BitmapStore.GetBitmap(nr2);
                ref Bitmap local32 = ref bitmap11;
                rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr2));
                Rectangle srcrect2 = rectangle2;
                rectangle1 = new Rectangle(x10, y11, 192, 144);
                Rectangle destrect2 = rectangle1;
                DrawMod.DrawSimplePart2(ref local31, ref local32, srcrect2, destrect2);
              }
            }
            switch (baseColor)
            {
              case 0:
                ref Graphics local33 = ref Expression;
                Bitmap bitmap12 = BitmapStore.GetBitmap(picSpriteId);
                ref Bitmap local34 = ref bitmap12;
                int x11 = x10;
                int y12 = y11;
                DrawMod.DrawScaled(ref local33, ref local34, x11, y12, 192, 144);
                break;
              case 1:
                ref Graphics local35 = ref Expression;
                Bitmap bitmap13 = BitmapStore.GetBitmap(picSpriteId);
                ref Bitmap local36 = ref bitmap13;
                int x12 = x10;
                int y13 = y11;
                int width7 = BitmapStore.GetWidth(picSpriteId);
                int origh7 = BitmapStore.Getheight(picSpriteId);
                double r7 = (double) ((float) red / 256f);
                double g7 = (double) ((float) green / 256f);
                double b7 = (double) ((float) blue / 256f);
                DrawMod.DrawScaledColorized2(ref local35, ref local36, x12, y13, 192, 144, width7, origh7, (float) r7, (float) g7, (float) b7, 1f);
                break;
              case 2:
                int red2 = this.game.Data.RegimeObj[index17].Red2;
                int green2 = this.game.Data.RegimeObj[index17].Green2;
                int blue2 = this.game.Data.RegimeObj[index17].Blue2;
                ref Graphics local37 = ref Expression;
                Bitmap bitmap14 = BitmapStore.GetBitmap(picSpriteId);
                ref Bitmap local38 = ref bitmap14;
                int x13 = x10;
                int y14 = y11;
                int width8 = BitmapStore.GetWidth(picSpriteId);
                int origh8 = BitmapStore.Getheight(picSpriteId);
                double r8 = (double) ((float) red2 / 256f);
                double g8 = (double) ((float) green2 / 256f);
                double b8 = (double) ((float) blue2 / 256f);
                DrawMod.DrawScaledColorized2(ref local37, ref local38, x13, y14, 192, 144, width8, origh8, (float) r8, (float) g8, (float) b8, 1f);
                break;
              case 3:
                int red3 = this.game.Data.RegimeObj[index17].Red3;
                int green3 = this.game.Data.RegimeObj[index17].Green3;
                int blue3 = this.game.Data.RegimeObj[index17].Blue3;
                ref Graphics local39 = ref Expression;
                Bitmap bitmap15 = BitmapStore.GetBitmap(picSpriteId);
                ref Bitmap local40 = ref bitmap15;
                int x14 = x10;
                int y15 = y11;
                int width9 = BitmapStore.GetWidth(picSpriteId);
                int origh9 = BitmapStore.Getheight(picSpriteId);
                double r9 = (double) ((float) red3 / 256f);
                double g9 = (double) ((float) green3 / 256f);
                double b9 = (double) ((float) blue3 / 256f);
                DrawMod.DrawScaledColorized2(ref local39, ref local40, x14, y15, 192, 144, width9, origh9, (float) r9, (float) g9, (float) b9, 1f);
                break;
              case 4:
                int red4 = this.game.Data.RegimeObj[index17].Red4;
                int green4 = this.game.Data.RegimeObj[index17].Green4;
                int blue4 = this.game.Data.RegimeObj[index17].Blue4;
                ref Graphics local41 = ref Expression;
                Bitmap bitmap16 = BitmapStore.GetBitmap(picSpriteId);
                ref Bitmap local42 = ref bitmap16;
                int x15 = x10;
                int y16 = y11;
                int width10 = BitmapStore.GetWidth(picSpriteId);
                int origh10 = BitmapStore.Getheight(picSpriteId);
                double r10 = (double) ((float) red4 / 256f);
                double g10 = (double) ((float) green4 / 256f);
                double b10 = (double) ((float) blue4 / 256f);
                DrawMod.DrawScaledColorized2(ref local41, ref local42, x15, y16, 192, 144, width10, origh10, (float) r10, (float) g10, (float) b10, 1f);
                break;
              case 5:
                ref Graphics local43 = ref Expression;
                Bitmap bitmap17 = BitmapStore.GetBitmap(picSpriteId);
                ref Bitmap local44 = ref bitmap17;
                int x16 = x10;
                int y17 = y11;
                int width11 = BitmapStore.GetWidth(picSpriteId);
                int origh11 = BitmapStore.Getheight(picSpriteId);
                double r11 = (double) ((float) (red + 392) / 1024f);
                double g11 = (double) ((float) (green + 392) / 1024f);
                double b11 = (double) ((float) (blue + 392) / 1024f);
                DrawMod.DrawScaledColorized2(ref local43, ref local44, x16, y17, 192, 144, width11, origh11, (float) r11, (float) g11, (float) b11, 1f);
                break;
              case 6:
                ref Graphics local45 = ref Expression;
                Bitmap bitmap18 = BitmapStore.GetBitmap(picSpriteId);
                ref Bitmap local46 = ref bitmap18;
                int x17 = x10;
                int y18 = y11;
                int width12 = BitmapStore.GetWidth(picSpriteId);
                int origh12 = BitmapStore.Getheight(picSpriteId);
                double r12 = (double) ((float) (red + 80) / 512f);
                double g12 = (double) ((float) (green + 200) / 512f);
                double b12 = (double) ((float) (blue + 80) / 512f);
                DrawMod.DrawScaledColorized2(ref local45, ref local46, x17, y18, 192, 144, width12, origh12, (float) r12, (float) g12, (float) b12, 1f);
                break;
            }
            if ((double) this.game.Data.RuleVar[870] > 0.0 & !Information.IsNothing((object) BitmapStore.GetBitmap(sidewaysSpriteId)))
            {
              ref Graphics local47 = ref Expression;
              Bitmap bitmap19 = BitmapStore.GetBitmap(sidewaysSpriteId);
              ref Bitmap local48 = ref bitmap19;
              int x18 = x10;
              int y19 = y11;
              DrawMod.DrawScaled(ref local47, ref local48, x18, y19, 192, 144);
            }
            if ((double) this.game.Data.RuleVar[869] >= 1.0 & (double) this.game.Data.RuleVar[869] < 3.0)
            {
              int nr = this.game.Data.LandscapeTypeObj[index4].SidewaysSPriteID3[index5];
              ref Graphics local49 = ref Expression;
              Bitmap bitmap20 = BitmapStore.GetBitmap(nr);
              ref Bitmap local50 = ref bitmap20;
              rectangle2 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr));
              Rectangle srcrect = rectangle2;
              rectangle1 = new Rectangle(x10, y11, 192, 144);
              Rectangle destrect = rectangle1;
              DrawMod.DrawSimplePart2(ref local49, ref local50, srcrect, destrect);
            }
            DrawMod.DrawRectangle(ref Expression, num1, y1 + 47, 192, 144, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
          }
        }
        int sftyp1 = this.sftyp;
        int num3 = 300;
        int num4 = 15;
        SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("Text & Upgrade", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (num4 + 170 - 85), bby: num3, tred: (this.StatMode == 0));
        this.tab1id = this.AddSubPart(ref tsubpart5, num4 + 170 - 85, num3, 150, 35, 1);
        SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("General Stats", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (num4 + 340 - 85), bby: num3, tred: (this.StatMode == 1));
        this.tab2id = this.AddSubPart(ref tsubpart6, num4 + 340 - 85, num3, 150, 35, 1);
        SubPartClass tsubpart7 = (SubPartClass) new TextButtonPartClass("Combat Stats", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (num4 + 510 - 85), bby: num3, tred: (this.StatMode == 2));
        this.tab3id = this.AddSubPart(ref tsubpart7, num4 + 510 - 85, num3, 150, 35, 1);
        SubPartClass tsubpart8 = (SubPartClass) new TextButtonPartClass("Prevent Rules", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (num4 + 680 - 85), bby: num3, tred: (this.StatMode == 4));
        this.tab5id = this.AddSubPart(ref tsubpart8, num4 + 680 - 85, num3, 150, 35, 1);
        SubPartClass tsubpart9 = (SubPartClass) new TextButtonPartClass("Landscape Stats", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (num4 + 850 - 85), bby: num3, tred: (this.StatMode == 3));
        this.tab4id = this.AddSubPart(ref tsubpart9, num4 + 850 - 85, num3, 150, 35, 1);
        DrawMod.DrawBlock(ref Expression, num4 + 50, num3 + 55, 890, 355, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
        DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref Expression, num4 + 50, num3 + 55, 890, 355, -1, -1);
        if (this.StatMode == 0)
        {
          int num5 = 0;
          int num6 = 50;
          int num7 = 130;
          int sftyp2 = this.sftyp;
          bool flag;
          if (this.sfnr > -1)
          {
            if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType].IsSea)
            {
              this.detailnr = -1;
              int num8 = 0;
              if (this.game.Data.SFTypeObj[sftyp2].UpgradeToo > -1)
              {
                int upgradeToo = this.game.Data.SFTypeObj[sftyp2].UpgradeToo;
                if (this.game.HandyFunctionsObj.CanUpgrade(this.sfnr, this.unr))
                {
                  if (this.HQselect > -1)
                  {
                    string name = this.game.Data.SFTypeObj[upgradeToo].Name;
                    ref Graphics local51 = ref Expression;
                    rectangle2 = new Rectangle(num6 + 30, num7 + (int) byte.MaxValue, 192, 14);
                    Rectangle rect1_1 = rectangle2;
                    rectangle1 = new Rectangle(num6 + 30, num7 + 268, 192, 23);
                    Rectangle rect2_1 = rectangle1;
                    string txt2_1 = name;
                    DrawMod.MakeFullBoxVic2(ref local51, rect1_1, "UPGRADEABLE TOO", rect2_1, txt2_1);
                    flag = true;
                    num7 -= 30;
                    string str6 = this.game.Data.UnitObj[this.HQselect].Name;
                    if (Strings.Len(str6) > 18)
                      str6 = Strings.Left(str6, 18);
                    ref Graphics local52 = ref Expression;
                    rectangle2 = new Rectangle(num6 + 250, num7 + 360, 192, 14);
                    Rectangle rect1_2 = rectangle2;
                    rectangle1 = new Rectangle(num6 + 250, num7 + 374, 192, 23);
                    Rectangle rect2_2 = rectangle1;
                    string txt2_2 = str6;
                    DrawMod.MakeFullBoxVic2(ref local52, rect1_2, "SELECTED HQ", rect2_2, txt2_2);
                    string str7 = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.HQSupply(this.HQselect)));
                    ref Graphics local53 = ref Expression;
                    rectangle2 = new Rectangle(num6 + 250, num7 + 400, 192, 14);
                    Rectangle rect1_3 = rectangle2;
                    rectangle1 = new Rectangle(num6 + 250, num7 + 414, 192, 23);
                    Rectangle rect2_3 = rectangle1;
                    string txt2_3 = str7;
                    DrawMod.MakeFullBoxVic2(ref local53, rect1_3, "SUPPLY AVAILABLE", rect2_3, txt2_3);
                    int picSpriteId = this.game.Data.SFTypeObj[upgradeToo].PicSpriteID;
                    int sidewaysSpriteId = this.game.Data.SFTypeObj[upgradeToo].SidewaysSpriteID;
                    int index18 = !(this.sfnr > -1 & this.game.EditObj.UnitSelected > -1) ? this.game.Data.Turn : this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime;
                    if (this.game.Data.RegimeObj[index18].ExtraGraphicUse > -1)
                    {
                      int extraCounter = this.game.Data.SFTypeObj[upgradeToo].ExtraCounter;
                      for (int index19 = 0; index19 <= extraCounter; ++index19)
                      {
                        if (this.game.Data.SFTypeObj[upgradeToo].ExtraCode[index19] == this.game.Data.RegimeObj[index18].ExtraGraphicUse)
                        {
                          picSpriteId = this.game.Data.SFTypeObj[upgradeToo].ExtraPicSpriteID[index19];
                          sidewaysSpriteId = this.game.Data.SFTypeObj[upgradeToo].ExtraSidewaysSpriteID[index19];
                        }
                      }
                    }
                    else if (index2 > -1 && this.game.Data.PeopleObj[index2].ExtraGraphicUse > -1)
                    {
                      int extraCounter = this.game.Data.SFTypeObj[upgradeToo].ExtraCounter;
                      for (int index20 = 0; index20 <= extraCounter; ++index20)
                      {
                        if (this.game.Data.SFTypeObj[upgradeToo].ExtraCode[index20] == this.game.Data.PeopleObj[index2].ExtraGraphicUse)
                        {
                          picSpriteId = this.game.Data.SFTypeObj[upgradeToo].ExtraPicSpriteID[index20];
                          sidewaysSpriteId = this.game.Data.SFTypeObj[upgradeToo].ExtraSidewaysSpriteID[index20];
                        }
                      }
                    }
                    ref Graphics local54 = ref Expression;
                    Bitmap bitmap21 = BitmapStore.GetBitmap(picSpriteId);
                    ref Bitmap local55 = ref bitmap21;
                    int x19 = num6 + 30;
                    int y20 = num7 + 330;
                    DrawMod.DrawScaled(ref local54, ref local55, x19, y20, 192, 144);
                    ref Graphics local56 = ref Expression;
                    Bitmap bitmap22 = BitmapStore.GetBitmap(sidewaysSpriteId);
                    ref Bitmap local57 = ref bitmap22;
                    int x20 = num6 + 30;
                    int y21 = num7 + 330;
                    DrawMod.DrawScaled(ref local56, ref local57, x20, y21, 192, 144);
                    ref Graphics local58 = ref Expression;
                    rectangle2 = new Rectangle(num6 + 248, num7 + 287, 192, 14);
                    Rectangle rect1_4 = rectangle2;
                    rectangle1 = new Rectangle(num6 + 248, num7 + 301, 192, 50);
                    Rectangle rect2_4 = rectangle1;
                    DrawMod.MakeFullBoxVic2(ref local58, rect1_4, "AVAILABLE HQS", rect2_4, "");
                    if (this.ChainHq[0] > -1)
                    {
                      bool forcehighlight = false;
                      if (this.HQselect == this.ChainHq[0] & this.HQselect != -1)
                        forcehighlight = true;
                      SubPartClass tsubpart10 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawUnit(this.ChainHq[0], forcehighlight), this.game.Data.UnitObj[this.ChainHq[0]].Name);
                      this.hqbut0 = this.AddSubPart(ref tsubpart10, num6 + 260, num7 + 308, 36, 36, 0);
                      if (forcehighlight)
                        DrawMod.DrawRectangle(ref Expression, num6 + 258, num7 + 306, 40, 40, (int) byte.MaxValue, 0, 0, (int) byte.MaxValue, 2);
                    }
                    if (this.ChainHq[1] > -1)
                    {
                      bool forcehighlight = false;
                      if (this.HQselect == this.ChainHq[1] & this.HQselect != -1)
                        forcehighlight = true;
                      SubPartClass tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawUnit(this.ChainHq[1], forcehighlight), this.game.Data.UnitObj[this.ChainHq[1]].Name);
                      this.hqbut1 = this.AddSubPart(ref tsubpart11, num6 + 300, num7 + 308, 36, 36, 0);
                      if (forcehighlight)
                        DrawMod.DrawRectangle(ref Expression, num6 + 298, num7 + 306, 40, 40, (int) byte.MaxValue, 0, 0, (int) byte.MaxValue, 2);
                    }
                    if (this.ChainHq[2] > -1)
                    {
                      bool forcehighlight = false;
                      if (this.HQselect == this.ChainHq[2] & this.HQselect != -1)
                        forcehighlight = true;
                      SubPartClass tsubpart12 = (SubPartClass) new ButtonPartClass(this.game.CustomBitmapObj.DrawUnit(this.ChainHq[2], forcehighlight), this.game.Data.UnitObj[this.ChainHq[2]].Name);
                      this.hqbut2 = this.AddSubPart(ref tsubpart12, num6 + 340, num7 + 308, 36, 36, 0);
                      if (forcehighlight)
                        DrawMod.DrawRectangle(ref Expression, num6 + 338, num7 + 306, 40, 40, (int) byte.MaxValue, 0, 0, (int) byte.MaxValue, 2);
                    }
                    this.detailnr = upgradeToo;
                    num8 = this.game.HandyFunctionsObj.CanUpgradeMax(this.sfnr, this.unr, this.HQselect);
                    if (num8 == -1)
                      num8 = 0;
                    if (num8 > this.game.Data.SFObj[this.sfnr].Qty)
                      num8 = this.game.Data.SFObj[this.sfnr].Qty;
                    num5 = 1;
                  }
                  else
                  {
                    string str8 = "No HQ in supply range.";
                    ref Graphics local = ref Expression;
                    rectangle2 = new Rectangle(num6 + 30, num7 + (int) byte.MaxValue, 192, 14);
                    Rectangle rect1 = rectangle2;
                    rectangle1 = new Rectangle(num6 + 30, num7 + 268, 192, 23);
                    Rectangle rect2 = rectangle1;
                    string txt2 = str8;
                    DrawMod.MakeFullBoxVic2(ref local, rect1, "UPGRADEABLE TOO", rect2, txt2);
                    num5 = 1;
                  }
                }
              }
              if (this.detailnr > -1 & num8 > 0 & this.HQselect > -1)
              {
                if (this.game.HandyFunctionsObj.CanUpgradeCost(this.sfnr, this.unr, this.detailnr2) <= this.game.HandyFunctionsObj.HQSupply(this.HQselect))
                {
                  SubPartClass tsubpart13 = (SubPartClass) new TextButtonPartClass("Do Upgrade", 120, tBackbitmap: (ref this.OwnBitmap), bbx: (num6 + 340), bby: (num7 + 504));
                  this.but3id = this.AddSubPart(ref tsubpart13, num6 + 340, num7 + 504, 120, 35, 1);
                }
                string str9 = Conversion.Str((object) Conversion.Int((float) this.game.Data.SFTypeObj[sftyp2].UpgradeCost / this.game.Data.RuleVar[77])) + " X " + Conversion.Str((object) this.detailnr2) + " = " + Conversion.Str((object) this.game.HandyFunctionsObj.CanUpgradeCost(this.sfnr, this.unr, this.detailnr2));
                ref Graphics local59 = ref Expression;
                rectangle2 = new Rectangle(num6 + 250, num7 + 440, 192, 14);
                Rectangle rect1 = rectangle2;
                rectangle1 = new Rectangle(num6 + 250, num7 + 454, 192, 23);
                Rectangle rect2 = rectangle1;
                string txt2 = str9;
                DrawMod.MakeFullBoxVic2(ref local59, rect1, "SUPPLY COST", rect2, txt2);
                flag = true;
                if (this.detailnr2 > num8)
                  this.detailnr2 = num8;
                GameClass game = this.game;
                string tsuffix = " of " + Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Qty));
                int tmaxval = num8;
                int detailnr2 = this.detailnr2;
                Bitmap bitmap = (Bitmap) null;
                ref Bitmap local60 = ref bitmap;
                SubPartClass tsubpart14 = (SubPartClass) new NumberSliderSubPartClass2(game, "Upgrade ", tsuffix, 300, 0, tmaxval, detailnr2, tbackbitmap: (ref local60));
                this.sliderid = this.AddSubPart(ref tsubpart14, num6 + 30, num7 + 500, 300, 40, 0);
              }
              SubPartClass tsubpart15 = (SubPartClass) new TextButtonPartClass("Disband", 100, tBackbitmap: (ref this.OwnBitmap), bbx: (num6 + 30), bby: 660);
              this.but2id = this.AddSubPart(ref tsubpart15, num6 + 30, 660, 100, 35, 1);
            }
            if (num5 == 0 && this.game.Data.SFTypeObj[sftyp2].UpgradeToo > -1)
            {
              int upgradeToo = this.game.Data.SFTypeObj[sftyp2].UpgradeToo;
              int picSpriteId = this.game.Data.SFTypeObj[this.game.Data.SFTypeObj[sftyp2].UpgradeToo].PicSpriteID;
              int index21 = !(this.sfnr > -1 & this.game.EditObj.UnitSelected > -1) ? this.game.Data.Turn : this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime;
              if (this.game.Data.Turn == index21)
              {
                if (this.game.Data.RegimeObj[index21].ExtraGraphicUse > -1)
                {
                  int extraCounter = this.game.Data.SFTypeObj[upgradeToo].ExtraCounter;
                  for (int index22 = 0; index22 <= extraCounter; ++index22)
                  {
                    if (this.game.Data.SFTypeObj[upgradeToo].ExtraCode[index22] == this.game.Data.RegimeObj[index21].ExtraGraphicUse)
                      picSpriteId = this.game.Data.SFTypeObj[upgradeToo].ExtraPicSpriteID[index22];
                  }
                }
                else if (index2 > -1 && this.game.Data.PeopleObj[index2].ExtraGraphicUse > -1)
                {
                  int extraCounter = this.game.Data.SFTypeObj[upgradeToo].ExtraCounter;
                  for (int index23 = 0; index23 <= extraCounter; ++index23)
                  {
                    if (this.game.Data.SFTypeObj[upgradeToo].ExtraCode[index23] == this.game.Data.PeopleObj[index2].ExtraGraphicUse)
                      picSpriteId = this.game.Data.SFTypeObj[upgradeToo].ExtraPicSpriteID[index23];
                  }
                }
                flag = true;
                string name1 = this.game.Data.SFTypeObj[this.game.Data.SFTypeObj[sftyp2].UpgradeToo].Name;
                ref Graphics local61 = ref Expression;
                rectangle2 = new Rectangle(num6 + 30, num7 + (int) byte.MaxValue, 192, 14);
                Rectangle rect1_5 = rectangle2;
                rectangle1 = new Rectangle(num6 + 30, num7 + 268, 192, 23);
                Rectangle rect2_5 = rectangle1;
                string txt2_4 = name1;
                DrawMod.MakeFullBoxVic2(ref local61, rect1_5, "COULD BE UPGRADED TOO", rect2_5, txt2_4);
                int y22 = num7 - 30 + (int) byte.MaxValue + 30;
                if (this.game.Data.SFTypeObj[sftyp2].UpgradeXP > 0)
                {
                  string str10 = Conversion.Str((object) this.game.Data.SFTypeObj[sftyp2].UpgradeXP);
                  ref Graphics local62 = ref Expression;
                  rectangle2 = new Rectangle(num6 + 260, y22, 192, 14);
                  Rectangle rect1_6 = rectangle2;
                  rectangle1 = new Rectangle(num6 + 260, y22 + 14, 192, 23);
                  Rectangle rect2_6 = rectangle1;
                  string txt2_5 = str10;
                  DrawMod.MakeFullBoxVic2(ref local62, rect1_6, "Minimum XP needed", rect2_6, txt2_5);
                  y22 += 40;
                }
                int index24 = -1;
                int itemTypeCounter = this.game.Data.ItemTypeCounter;
                for (int index25 = 0; index25 <= itemTypeCounter; ++index25)
                {
                  if (this.game.Data.ItemTypeObj[index25].IsSFType == this.game.Data.SFTypeObj[sftyp2].UpgradeToo)
                  {
                    index24 = index25;
                    break;
                  }
                }
                if (index24 > -1)
                {
                  int index26 = 0;
                  do
                  {
                    if (this.game.Data.ItemTypeObj[index24].ResFieldNeeded[index26] > -1)
                    {
                      string name2 = this.game.Data.ResearchObj[this.game.Data.ItemTypeObj[index24].ResFieldNeeded[index26]].Name;
                      ref Graphics local63 = ref Expression;
                      rectangle2 = new Rectangle(num6 + 260, y22, 192, 14);
                      Rectangle rect1_7 = rectangle2;
                      rectangle1 = new Rectangle(num6 + 260, y22 + 14, 192, 23);
                      Rectangle rect2_7 = rectangle1;
                      string txt2_6 = name2;
                      DrawMod.MakeFullBoxVic2(ref local63, rect1_7, "RESEARCH NEED FOR UPGRADE", rect2_7, txt2_6);
                      y22 += 40;
                    }
                    ++index26;
                  }
                  while (index26 <= 4);
                }
                string str11 = Conversion.Str((object) Conversion.Int((float) this.game.Data.SFTypeObj[sftyp2].UpgradeCost / this.game.Data.RuleVar[77]));
                ref Graphics local64 = ref Expression;
                rectangle2 = new Rectangle(num6 + 260, y22, 192, 14);
                Rectangle rect1_8 = rectangle2;
                rectangle1 = new Rectangle(num6 + 260, y22 + 14, 192, 23);
                Rectangle rect2_8 = rectangle1;
                string txt2_7 = str11;
                DrawMod.MakeFullBoxVic2(ref local64, rect1_8, "UPGRADE SUPPLY COST", rect2_8, txt2_7);
              }
            }
          }
          if (sftyp2 > -1)
          {
            if (flag)
            {
              int num9 = 550;
              int num10 = 385;
              DrawMod.DrawPaperSheet(ref Expression, num9 - 20, num10 - 10, 415, 320);
              SubPartClass tsubpart16 = (SubPartClass) new PaperAreaClass(this.game, 365, 14, (Font) null, "Description", false, str2 + "\r\n\r\n" + this.game.Data.SFTypeObj[sftyp2].Description, this.game.VicColor8, tItemSize: 20, tbackbitmap: (ref this.OwnBitmap), bbx: num9, bby: num10);
              this.descid = this.AddSubPart(ref tsubpart16, num9, num10, 365, 300, 0);
            }
            else
            {
              int num11 = 220;
              int num12 = 385;
              DrawMod.DrawPaperSheet(ref Expression, num11 - 20, num12 - 10, 630, 320);
              SubPartClass tsubpart17 = (SubPartClass) new PaperAreaClass(this.game, 580, 14, (Font) null, "Description", false, str2 + "\r\n\r\n" + this.game.Data.SFTypeObj[sftyp2].Description, this.game.VicColor8, tItemSize: 20, tbackbitmap: (ref this.OwnBitmap), bbx: num11, bby: num12);
              this.descid = this.AddSubPart(ref tsubpart17, num11, num12, 580, 300, 0);
            }
          }
        }
      }
      int sftyp3 = this.sftyp;
      string str12;
      if (this.StatMode == 1 & sftyp3 > -1)
      {
        int num13 = 150;
        int num14 = 385;
        this.OptionsList3Obj = new ATListClass();
        str12 = "";
        string tvalue2_1 = "";
        string tvalue1 = this.game.Data.TempString[this.game.Data.SFTypeObj[sftyp3].UnitGroup + 400];
        if (this.comparenr > -1)
          tvalue2_1 = this.game.Data.TempString[this.game.Data.SFTypeObj[this.comparenr].UnitGroup + 400];
        this.OptionsList3Obj.add("SFTypeGroup", -1, tvalue1, tvalue2_1);
        str12 = "";
        string tvalue2_2 = "";
        string tvalue2 = this.game.Data.TempString[this.game.Data.SFTypeObj[sftyp3].MoveType + 0];
        if (this.comparenr > -1)
          tvalue2_2 = this.game.Data.TempString[this.game.Data.SFTypeObj[this.comparenr].MoveType + 0];
        this.OptionsList3Obj.add("MoveType", -1, tvalue2, tvalue2_2);
        str12 = "";
        string tvalue2_3 = "";
        string tvalue3 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].SupplyCarry));
        if (this.comparenr > -1)
          tvalue2_3 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].SupplyCarry));
        this.OptionsList3Obj.add("Supply Carry", -1, tvalue3, tvalue2_3);
        str12 = "";
        string tvalue2_4 = "";
        string tvalue4 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].BasicSupplyNeed));
        if (this.comparenr > -1)
          tvalue2_4 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].BasicSupplyNeed));
        this.OptionsList3Obj.add("Supply Consum", -1, tvalue4, tvalue2_4);
        str12 = "";
        string tvalue2_5 = "";
        string tvalue5 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].Cap));
        if (this.game.Data.SFTypeObj[sftyp3].Theater > 0)
          tvalue5 = "0";
        if (this.comparenr > -1)
          tvalue2_5 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].Cap));
        if (this.comparenr > -1 && this.game.Data.SFTypeObj[this.comparenr].Theater > 0)
          tvalue2_5 = "0";
        this.OptionsList3Obj.add("Land.Tr.Cap", -1, tvalue5, tvalue2_5);
        str12 = "";
        string tvalue2_6 = "";
        string tvalue6 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].Cap));
        if (this.game.Data.SFTypeObj[sftyp3].Theater != 1)
          tvalue6 = "0";
        if (this.comparenr > -1)
          tvalue2_6 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].Cap));
        if (this.comparenr > -1 && this.game.Data.SFTypeObj[this.comparenr].Theater != 1)
          tvalue2_6 = "0";
        this.OptionsList3Obj.add("Sea.Tr.Cap", -1, tvalue6, tvalue2_6);
        str12 = "";
        string tvalue2_7 = "";
        string tvalue7 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].RailCap));
        if (this.comparenr > -1)
          tvalue2_7 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].RailCap));
        this.OptionsList3Obj.add("Rail.Tr.Cap", -1, tvalue7, tvalue2_7);
        str12 = "";
        string tvalue2_8 = "";
        string tvalue8 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].Theater));
        if (this.comparenr > -1)
          tvalue2_8 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].Theater));
        this.OptionsList3Obj.add("Theater", -1, tvalue8, tvalue2_8);
        str12 = "";
        string tvalue2_9 = "";
        string tvalue9 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].Weight));
        if (this.comparenr > -1)
          tvalue2_9 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].Weight));
        this.OptionsList3Obj.add("Weight", -1, tvalue9, tvalue2_9);
        str12 = "";
        string tvalue2_10 = "";
        string tvalue10 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].CarryCap));
        if (this.comparenr > -1)
          tvalue2_10 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].CarryCap));
        this.OptionsList3Obj.add("Carry Cap.", -1, tvalue10, tvalue2_10);
        str12 = "";
        string tvalue2_11 = "";
        string tvalue11 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].MoveRedux));
        if (this.comparenr > -1)
          tvalue2_11 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].MoveRedux));
        this.OptionsList3Obj.add("Move Redux", -1, tvalue11, tvalue2_11);
        str12 = "";
        string tvalue2_12 = "";
        string tvalue12 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].ReconPts));
        if (this.comparenr > -1)
          tvalue2_12 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].ReconPts));
        this.OptionsList3Obj.add("Recon Points", -1, tvalue12, tvalue2_12);
        str12 = "";
        string tvalue2_13 = "";
        string tvalue13 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].ZOCPts));
        if (this.comparenr > -1)
          tvalue2_13 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].ZOCPts));
        this.OptionsList3Obj.add("ZOC Points", -1, tvalue13, tvalue2_13);
        str12 = "";
        string tvalue2_14 = "";
        string tvalue14 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].HidePts));
        if (this.comparenr > -1)
          tvalue2_14 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].HidePts));
        this.OptionsList3Obj.add("Hide Points", -1, tvalue14, tvalue2_14);
        str12 = "";
        string tvalue2_15 = "";
        string tvalue15 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].CanDoParadrop));
        if (this.comparenr > -1)
          tvalue2_15 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].CanDoParadrop));
        this.OptionsList3Obj.add("Paradrop", -1, tvalue15, tvalue2_15);
        str12 = "";
        string tvalue2_16 = "";
        string tvalue16 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].EP));
        if (this.comparenr > -1)
          tvalue2_16 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].EP));
        this.OptionsList3Obj.add("Engineer Pts", -1, tvalue16, tvalue2_16);
        str12 = "";
        string tvalue2_17 = "";
        string tvalue17 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].StaffPts));
        if (this.comparenr > -1)
          tvalue2_17 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].StaffPts));
        this.OptionsList3Obj.add("Staff Pts", -1, tvalue17, tvalue2_17);
        if (this.OptionsList3Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
        }
        else
        {
          SubPartClass tsubpart18 = (SubPartClass) new ATListSubPartClass(this.OptionsList3Obj, 16, 330, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 230, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num13, bby: num14);
          this.OptionsList3Id = this.AddSubPart(ref tsubpart18, num13, num14, 330, 272, 0);
        }
        int num15 = 540;
        int num16 = 385;
        this.OptionsList4Obj = new ATListClass();
        str12 = "";
        string tvalue2_18 = "";
        string tvalue18 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].StaffCombatMod));
        if (this.comparenr > -1)
          tvalue2_18 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].StaffCombatMod));
        this.OptionsList4Obj.add("Staff Com Mod", -1, tvalue18, tvalue2_18);
        str12 = "";
        string tvalue2_19 = "";
        string tvalue19 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].StaffMoraleMod));
        if (this.comparenr > -1)
          tvalue2_19 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].StaffMoraleMod));
        this.OptionsList4Obj.add("Staff Mor Mod", -1, tvalue19, tvalue2_19);
        str12 = "";
        string tvalue2_20 = "";
        string tvalue20 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].BlowBridgePts));
        if (this.comparenr > -1)
          tvalue2_20 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].BlowBridgePts));
        this.OptionsList4Obj.add("Blow Pts", -1, tvalue20, tvalue2_20);
        str12 = "";
        string tvalue2_21 = "";
        string tvalue21 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].AntiSupply));
        if (this.comparenr > -1)
          tvalue2_21 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].AntiSupply));
        this.OptionsList4Obj.add("AntiSup Pts Land", -1, tvalue21, tvalue2_21);
        str12 = "";
        string tvalue2_22 = "";
        string tvalue22 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].AntiSupplySea));
        if (this.comparenr > -1)
          tvalue2_22 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].AntiSupplySea));
        this.OptionsList4Obj.add("AntiSup Pts Sea", -1, tvalue22, tvalue2_22);
        str12 = "";
        string tvalue2_23 = "";
        string tvalue23 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].AntiSupplyRange));
        if (this.comparenr > -1)
          tvalue2_23 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].AntiSupplyRange));
        this.OptionsList4Obj.add("AntiSup Range", -1, tvalue23, tvalue2_23);
        str12 = "";
        string tvalue2_24 = "";
        string tvalue24 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].ConsiderCarry));
        if (this.comparenr > -1)
          tvalue2_24 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].ConsiderCarry));
        this.OptionsList4Obj.add("Consider Carry", -1, tvalue24, tvalue2_24);
        str12 = "";
        string tvalue2_25 = "";
        string tvalue25 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].AirCarrierCap));
        if (this.comparenr > -1)
          tvalue2_25 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].AirCarrierCap));
        this.OptionsList4Obj.add("Aircar.CarryCap", -1, tvalue25, tvalue2_25);
        str12 = "";
        string tvalue2_26 = "";
        string tvalue26 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].ApMod));
        if (this.comparenr > -1)
          tvalue2_26 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].ApMod));
        this.OptionsList4Obj.add("AP Mod", -1, tvalue26, tvalue2_26);
        str12 = "";
        string tvalue2_27 = "";
        string tvalue27 = !(this.game.Data.SFTypeObj[sftyp3].FuelRegimeVar > 0 & this.game.Data.SFTypeObj[sftyp3].FuelForMove + this.game.Data.SFTypeObj[sftyp3].FuelForAttack + this.game.Data.SFTypeObj[sftyp3].FuelForAttackDef > 0) ? "None" : Strings.Trim(this.game.Data.RegimeSlotName[this.game.Data.SFTypeObj[sftyp3].FuelRegimeVar]);
        if (this.comparenr > -1)
          tvalue2_27 = !(this.game.Data.SFTypeObj[this.comparenr].FuelRegimeVar >= 0 & this.game.Data.SFTypeObj[this.comparenr].FuelForMove + this.game.Data.SFTypeObj[this.comparenr].FuelForAttack + this.game.Data.SFTypeObj[this.comparenr].FuelForAttackDef > 0) ? "None" : Strings.Trim(this.game.Data.RegimeSlotName[this.game.Data.SFTypeObj[this.comparenr].FuelRegimeVar]);
        this.OptionsList4Obj.add("Fuel Type", -1, tvalue27, tvalue2_27);
        str12 = "";
        string tvalue2_28 = "";
        string tvalue28 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].FuelForMove));
        if (this.comparenr > -1)
          tvalue2_28 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].FuelForMove));
        this.OptionsList4Obj.add("Fuel for Move", -1, tvalue28, tvalue2_28);
        str12 = "";
        string tvalue2_29 = "";
        string tvalue29 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].FuelForAttack));
        if (this.comparenr > -1)
          tvalue2_29 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].FuelForAttack));
        this.OptionsList4Obj.add("Fuel for Attack", -1, tvalue29, tvalue2_29);
        str12 = "";
        string tvalue2_30 = "";
        string tvalue30 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].FuelForAttackDef));
        if (this.comparenr > -1)
          tvalue2_30 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].FuelForAttackDef));
        this.OptionsList4Obj.add("Fuel for Defense", -1, tvalue30, tvalue2_30);
        str12 = "";
        string tvalue2_31 = "";
        string tvalue31 = "* " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].OutOfFuelAttack));
        if (this.comparenr > -1)
          tvalue2_31 = "* " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].OutOfFuelAttack));
        this.OptionsList4Obj.add("Out of fuel Att", -1, tvalue31, tvalue2_31);
        str12 = "";
        string tvalue2_32 = "";
        string tvalue32 = "* " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].OutOfFuelDefense));
        if (this.comparenr > -1)
          tvalue2_32 = "* " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].OutOfFuelDefense));
        this.OptionsList4Obj.add("Out of fuel Def", -1, tvalue32, tvalue2_32);
        str12 = "";
        string tvalue2_33 = "";
        string tvalue33 = "/ " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].OutOfFuelMove));
        if (this.comparenr > -1)
          tvalue2_33 = "/ " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].OutOfFuelMove));
        this.OptionsList4Obj.add("Out of fuel Mov", -1, tvalue33, tvalue2_33);
        str12 = "";
        string tvalue2_34 = "";
        string tvalue34 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].AntiStrucPts));
        if (this.comparenr > -1)
          tvalue2_34 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].AntiStrucPts));
        this.OptionsList4Obj.add("Anti-Struc Pts", -1, tvalue34, tvalue2_34);
        if (this.OptionsList4Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList4Id)].Refresh(this.OptionsList4Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList4Id)] = true;
        }
        else
        {
          SubPartClass tsubpart19 = (SubPartClass) new ATListSubPartClass(this.OptionsList4Obj, 16, 330, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 230, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num15, bby: num16);
          this.OptionsList4Id = this.AddSubPart(ref tsubpart19, num15, num16, 330, 272, 0);
        }
      }
      int sftyp4 = this.sftyp;
      if (this.StatMode == 2 & sftyp4 > -1)
      {
        int num17 = 150;
        int num18 = 385;
        this.OptionsList3Obj = new ATListClass();
        str12 = "";
        string tvalue2_35 = "";
        string tvalue35 = Conversions.ToString(this.game.Data.SFTypeObj[sftyp4].Initiative);
        if (this.comparenr > -1)
          tvalue2_35 = Conversions.ToString(this.game.Data.SFTypeObj[this.comparenr].Initiative);
        this.OptionsList3Obj.add("Initiative Att", -1, tvalue35, tvalue2_35);
        str12 = "";
        string tvalue2_36 = "";
        string tvalue36 = Conversions.ToString(this.game.Data.SFTypeObj[sftyp4].InitiativeDef);
        if (this.comparenr > -1)
          tvalue2_36 = Conversions.ToString(this.game.Data.SFTypeObj[this.comparenr].InitiativeDef);
        this.OptionsList3Obj.add("Initiative Def", -1, tvalue36, tvalue2_36);
        str12 = "";
        string tvalue2_37 = "";
        string tvalue37 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].Attacks));
        if (this.comparenr > -1)
          tvalue2_37 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].Attacks));
        this.OptionsList3Obj.add("Attacks", -1, tvalue37, tvalue2_37);
        str12 = "";
        string tvalue2_38 = "";
        string tvalue38 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].MaxAttacked));
        if (this.comparenr > -1)
          tvalue2_38 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].MaxAttacked));
        this.OptionsList3Obj.add("Max Attacked", -1, tvalue38, tvalue2_38);
        str12 = "";
        string tvalue2_39 = "";
        string tvalue39 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].Frontage));
        if (this.comparenr > -1)
          tvalue2_39 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].Frontage));
        this.OptionsList3Obj.add("Stack Pts", -1, tvalue39, tvalue2_39);
        str12 = "";
        string tvalue2_40 = "";
        string tvalue40 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].BackBench));
        if (this.comparenr > -1)
          tvalue2_40 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].BackBench));
        this.OptionsList3Obj.add("Rear Area", -1, tvalue40, tvalue2_40);
        str12 = "";
        string tvalue2_41 = "";
        string tvalue41 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].ArtRange));
        if (this.comparenr > -1)
          tvalue2_41 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].ArtRange));
        this.OptionsList3Obj.add("Art Range", -1, tvalue41, tvalue2_41);
        str12 = "";
        string tvalue2_42 = "";
        string tvalue42 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].FavTargetTries));
        if (this.comparenr > -1)
          tvalue2_42 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].FavTargetTries));
        this.OptionsList3Obj.add("Fav.Target.Tries", -1, tvalue42, tvalue2_42);
        str12 = "";
        string tvalue2_43 = "";
        string tvalue43 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].AARange));
        if (this.comparenr > -1)
          tvalue2_43 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].AARange));
        this.OptionsList3Obj.add("AA Range", -1, tvalue43, tvalue2_43);
        str12 = "";
        string tvalue2_44 = "";
        string tvalue44 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].KillPercent));
        int index27 = sftyp4;
        if (this.game.Data.SFTypeObj[index27].ArtSFType > -1)
        {
          int artSfType = this.game.Data.SFTypeObj[index27].ArtSFType;
          tvalue44 = tvalue44 + " (" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[artSfType].KillPercent)) + ")";
        }
        else if (this.game.Data.SFTypeObj[index27].ArtRange > 0)
          tvalue44 = tvalue44 + " (" + tvalue44 + ")";
        if (this.comparenr > -1)
        {
          tvalue2_44 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].KillPercent));
          int comparenr = this.comparenr;
          if (this.game.Data.SFTypeObj[comparenr].ArtSFType > -1)
          {
            int artSfType = this.game.Data.SFTypeObj[comparenr].ArtSFType;
            tvalue2_44 = tvalue2_44 + " (" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[artSfType].KillPercent)) + ")";
          }
          else if (this.game.Data.SFTypeObj[comparenr].ArtRange > 0)
            tvalue2_44 = tvalue2_44 + " (" + tvalue2_44 + ")";
        }
        this.OptionsList3Obj.add("Hit->Kill%", -1, tvalue44, tvalue2_44);
        str12 = "";
        string tvalue2_45 = "";
        string tvalue45 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].RetreatPercent));
        int index28 = sftyp4;
        if (this.game.Data.SFTypeObj[index28].ArtSFType > -1)
        {
          int artSfType = this.game.Data.SFTypeObj[index28].ArtSFType;
          tvalue45 = tvalue45 + " (" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[artSfType].RetreatPercent)) + ")";
        }
        else if (this.game.Data.SFTypeObj[index28].ArtRange > 0)
          tvalue45 = tvalue45 + " (" + tvalue45 + ")";
        if (this.comparenr > -1)
        {
          tvalue2_45 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].RetreatPercent));
          int comparenr = this.comparenr;
          if (this.game.Data.SFTypeObj[comparenr].ArtSFType > -1)
          {
            int artSfType = this.game.Data.SFTypeObj[comparenr].ArtSFType;
            tvalue2_45 = tvalue2_45 + " (" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[artSfType].RetreatPercent)) + ")";
          }
          else if (this.game.Data.SFTypeObj[comparenr].ArtRange > 0)
            tvalue2_45 = tvalue2_45 + " (" + tvalue2_45 + ")";
        }
        this.OptionsList3Obj.add("Hit->Retreat%", -1, tvalue45, tvalue2_45);
        str12 = "";
        string tvalue2_46 = "";
        string tvalue46 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].FirstRoundPenaltyMod));
        if (this.comparenr > -1)
          tvalue2_46 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].FirstRoundPenaltyMod));
        this.OptionsList3Obj.add("1stRnd pen.mod", -1, tvalue46, tvalue2_46);
        str12 = "";
        string tvalue2_47 = "";
        string tvalue47 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].EntrenchPower));
        if (this.comparenr > -1)
          tvalue2_47 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].EntrenchPower));
        this.OptionsList3Obj.add("Entrench Pow", -1, tvalue47, tvalue2_47);
        str12 = "";
        string tvalue2_48 = "";
        string tvalue48 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].PowerPts));
        if (this.comparenr > -1)
          tvalue2_48 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].PowerPts));
        this.OptionsList3Obj.add("Power Points", -1, tvalue48, tvalue2_48);
        str12 = "";
        string tvalue2_49 = "";
        string tvalue49 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].RdnLossPerAttack));
        if (this.comparenr > -1)
          tvalue2_49 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].RdnLossPerAttack));
        this.OptionsList3Obj.add("RdnLos.p.attack", -1, tvalue49, tvalue2_49);
        str12 = "";
        string tvalue2_50 = "";
        string tvalue50 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].AutoDestroy)) + "/" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].AutoDestroy2));
        if (this.comparenr > -1)
          tvalue2_50 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].AutoDestroy)) + "/" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].AutoDestroy));
        this.OptionsList3Obj.add("AutoDestroy", -1, tvalue50, tvalue2_50);
        str12 = "";
        string tvalue2_51 = "";
        string tvalue51 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].KilltoRetreatChance));
        if (this.comparenr > -1)
          tvalue2_51 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].KilltoRetreatChance));
        this.OptionsList3Obj.add("Kill becomes rtr", -1, tvalue51, tvalue2_51);
        if (this.OptionsList3Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
        }
        else
        {
          SubPartClass tsubpart20 = (SubPartClass) new ATListSubPartClass(this.OptionsList3Obj, 17, 250, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 150, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num17, bby: num18);
          this.OptionsList3Id = this.AddSubPart(ref tsubpart20, num17, num18, 300, 288, 0);
        }
        this.combatListObj = new ATListClass();
        int index29 = sftyp4;
        SimpleList simpleList1 = new SimpleList();
        int tid1 = 0;
        do
        {
          if (this.game.Data.SFTypeObj[index29].FavTarget[tid1] > 0)
            simpleList1.Add(tid1, 1000 * this.game.Data.SFTypeObj[index29].FavTarget[tid1] - tid1);
          else if (this.comparenr > -1)
          {
            if (this.game.Data.SFTypeObj[this.comparenr].FavTarget[tid1] > 0)
              simpleList1.Add(tid1, 100 * this.game.Data.SFTypeObj[this.comparenr].FavTarget[tid1] - 9999 - tid1);
            else
              simpleList1.Add(tid1, -9999 - tid1);
          }
          else
            simpleList1.Add(tid1, -9999 - tid1);
          ++tid1;
        }
        while (tid1 <= 99);
        simpleList1.Sort();
        int Number1 = 0;
        int num19 = 9999999;
        if (this.comparenr > -1)
          this.combatListObj.add("TARGET GROUP", -1, "ATT", "HP", "ATT", "HP");
        else
          this.combatListObj.add("TARGET GROUP", -1, "ATT", "HP");
        for (int counter = simpleList1.Counter; counter >= 0; counter += -1)
        {
          str12 = "";
          if (simpleList1.Weight[counter] < num19 - 99)
          {
            ++Number1;
            num19 = simpleList1.Weight[counter];
          }
          string tname = Strings.Trim(Conversion.Str((object) Number1)) + ". " + this.game.Data.TempString[400 + simpleList1.Id[counter]];
          string tvalue52 = Strings.Trim(Conversion.Str((object) (this.game.Data.SFTypeObj[index29].AttackPower[simpleList1.Id[counter]] * this.game.Data.SFTypeObj[index29].Attacks))) + "/" + Strings.Trim(Conversion.Str((object) (this.game.Data.SFTypeObj[index29].AttackPowerDef[simpleList1.Id[counter]] * this.game.Data.SFTypeObj[index29].Attacks)));
          string tvalue2_52 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[index29].HitPoints[simpleList1.Id[counter]])) + "/" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[index29].HitPointsDef[simpleList1.Id[counter]]));
          string tvalue3;
          string tvalue4;
          if (this.comparenr > -1)
          {
            tvalue3 = Strings.Trim(Conversion.Str((object) (this.game.Data.SFTypeObj[this.comparenr].AttackPower[simpleList1.Id[counter]] * this.game.Data.SFTypeObj[this.comparenr].Attacks))) + "/" + Strings.Trim(Conversion.Str((object) (this.game.Data.SFTypeObj[this.comparenr].AttackPowerDef[simpleList1.Id[counter]] * this.game.Data.SFTypeObj[this.comparenr].Attacks)));
            tvalue4 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].HitPoints[simpleList1.Id[counter]])) + "/" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].HitPointsDef[simpleList1.Id[counter]]));
          }
          if (this.comparenr > -1)
            this.combatListObj.add(tname, counter, tvalue52, tvalue2_52, tvalue3, tvalue4);
          else
            this.combatListObj.add(tname, counter, tvalue52, tvalue2_52);
        }
        int num20 = 450;
        int num21 = 385;
        if (this.combatListId > 0)
        {
          this.SubPartList[this.SubpartNr(this.combatListId)].Refresh(this.combatListObj, -1);
          this.SubPartFlag[this.SubpartNr(this.combatListId)] = true;
        }
        else if (this.game.Data.SFTypeObj[index29].ArtRange > 0)
        {
          SubPartClass tsubpart21 = (SubPartClass) new ATListSubPartClass(this.combatListObj, 8, 430, -1, this.game, true, "AttackPoints / Hitpoints", tShowPair: true, tValueWidth: 300, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num20, bby: num21);
          this.combatListId = this.AddSubPart(ref tsubpart21, num20, num21, 380, 144, 0);
        }
        else
        {
          SubPartClass tsubpart22 = (SubPartClass) new ATListSubPartClass(this.combatListObj, 8, 430, -1, this.game, true, "AttackPoints / Hitpoints", tShowPair: true, tValueWidth: 300, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num20, bby: num21);
          this.combatListId = this.AddSubPart(ref tsubpart22, num20, num21, 380, 144, 0);
        }
        this.combatList2Obj = new ATListClass();
        int index30 = sftyp4;
        if (this.game.Data.SFTypeObj[sftyp4].ArtRange > 0)
        {
          SimpleList simpleList2 = new SimpleList();
          int tid2 = 0;
          do
          {
            if (this.game.Data.SFTypeObj[index30].FavArtTarget[tid2] > 0)
              simpleList2.Add(tid2, 1000 * this.game.Data.SFTypeObj[index30].FavArtTarget[tid2] - tid2);
            else if (this.comparenr > -1 && this.game.Data.SFTypeObj[this.comparenr].FavArtTarget[tid2] > 0)
              simpleList2.Add(tid2, 100 * this.game.Data.SFTypeObj[this.comparenr].FavArtTarget[tid2] - 9999 - tid2);
            ++tid2;
          }
          while (tid2 <= 99);
          simpleList2.Sort();
          if (this.comparenr > -1)
            this.combatList2Obj.add("ARTILLERY TARGET GROUP", -1, "ART ATT", "ART ATT");
          else
            this.combatList2Obj.add("ARTILLERY TARGET GROUP", -1, "ART ATT");
          int Number2 = 0;
          int num22 = -1;
          for (int counter = simpleList2.Counter; counter >= 0; counter += -1)
          {
            str12 = "";
            if (simpleList2.Weight[counter] > num22 - 99)
            {
              ++Number2;
              num22 = simpleList2.Weight[counter];
            }
            string tname = Strings.Trim(Conversion.Str((object) Number2)) + ". " + this.game.Data.TempString[400 + simpleList2.Id[counter]];
            string tvalue53 = Strings.Trim(Conversion.Str((object) (Conversions.ToInteger(this.game.Data.SFTypeObj[index30].AttackArt[simpleList2.Id[counter]]) * this.game.Data.SFTypeObj[index30].Attacks)));
            if (this.comparenr > -1)
            {
              string tvalue2_53 = Strings.Trim(Conversion.Str((object) (Conversions.ToInteger(this.game.Data.SFTypeObj[this.comparenr].AttackArt[simpleList2.Id[counter]]) * this.game.Data.SFTypeObj[this.comparenr].Attacks)));
              this.combatList2Obj.add(tname, counter, tvalue53, tvalue2_53);
            }
            else
              this.combatList2Obj.add(tname, counter, tvalue53);
          }
          int num23 = 450;
          int num24 = 540;
          if (this.combatList2Id > 0)
          {
            this.SubPartList[this.SubpartNr(this.combatList2Id)].Refresh(this.combatList2Obj, -1);
            this.SubPartFlag[this.SubpartNr(this.combatList2Id)] = true;
          }
          else
          {
            SubPartClass tsubpart23 = (SubPartClass) new ATListSubPartClass(this.combatList2Obj, 8, 430, -1, this.game, true, "AttackPoints / Hitpoints", tShowPair: true, tValueWidth: 220, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num23, bby: num24);
            this.combatList2Id = this.AddSubPart(ref tsubpart23, num23, num24, 380, 144, 0);
          }
        }
      }
      if (this.StatMode == 3)
      {
        this.OptionsListObj = new ATListClass();
        this.OptionsList4Obj = new ATListClass();
        this.OptionsList3Obj = new ATListClass();
        int index31 = sftyp4;
        if (this.comparenr > -1)
        {
          this.OptionsListObj.add("LANDSCAPE", -1, "AP", "ENTR", "AP", "ENTR");
          this.OptionsList4Obj.add("ROAD TYPE", -1, "AP", "AP");
          this.OptionsList3Obj.add("RIVER TYPE", -1, "AP", "AP");
        }
        else
        {
          this.OptionsListObj.add("LANDSCAPE", -1, "AP", "ENTR");
          this.OptionsList4Obj.add("ROAD TYPE", -1, "AP");
          this.OptionsList3Obj.add("RIVER TYPE", -1, "AP");
        }
        int landscapeTypeCounter1 = this.game.Data.LandscapeTypeCounter;
        for (int tdata = 0; tdata <= landscapeTypeCounter1; ++tdata)
        {
          str12 = "";
          string name = this.game.Data.LandscapeTypeObj[tdata].Name;
          int num25 = this.game.Data.LandscapeTypeObj[tdata].MoveCost[this.game.Data.SFTypeObj[index31].MoveType];
          string tvalue = Strings.Trim(Conversion.Str((object) (int) Math.Round((double) (int) Math.Round((double) num25 - Conversion.Int((double) num25 * ((double) this.game.Data.SFTypeObj[index31].MoveRedux / 100.0))) * ((double) this.game.Data.MoveTypePenalty[this.game.Data.SFTypeObj[index31].MoveType] / 100.0)))) + "ap";
          string tvalue2 = Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[tdata].DefBonus[this.game.Data.SFTypeObj[index31].UnitGroup])) + "-" + Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[tdata].DefBonusMax[this.game.Data.SFTypeObj[index31].UnitGroup]));
          if (this.comparenr > -1)
          {
            int num26 = this.game.Data.LandscapeTypeObj[tdata].MoveCost[this.game.Data.SFTypeObj[this.comparenr].MoveType];
            string tvalue3 = Strings.Trim(Conversion.Str((object) (int) Math.Round((double) (int) Math.Round((double) num26 - Conversion.Int((double) num26 * ((double) this.game.Data.SFTypeObj[this.comparenr].MoveRedux / 100.0))) * ((double) this.game.Data.MoveTypePenalty[this.game.Data.SFTypeObj[this.comparenr].MoveType] / 100.0)))) + "ap";
            string tvalue4 = Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[tdata].DefBonus[this.game.Data.SFTypeObj[this.comparenr].UnitGroup])) + "-" + Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[tdata].DefBonusMax[this.game.Data.SFTypeObj[this.comparenr].UnitGroup]));
            this.OptionsListObj.add(name, tdata, tvalue, tvalue2, tvalue3, tvalue4);
          }
          else
            this.OptionsListObj.add(name, tdata, tvalue, tvalue2);
        }
        int roadTypeCounter = this.game.Data.RoadTypeCounter;
        string str13;
        string str14;
        for (int index32 = 0; index32 <= roadTypeCounter; ++index32)
        {
          string name = this.game.Data.RoadTypeObj[index32].Name;
          int num27 = this.game.Data.RoadTypeObj[index32].MoveCostOverrule[this.game.Data.SFTypeObj[index31].MoveType];
          string tvalue = Strings.Trim(Conversion.Str((object) (int) Math.Round((double) (int) Math.Round((double) num27 - Conversion.Int((double) num27 * ((double) this.game.Data.SFTypeObj[index31].MoveRedux / 100.0))) * ((double) this.game.Data.MoveTypePenalty[this.game.Data.SFTypeObj[index31].MoveType] / 100.0)))) + "ap";
          str13 = "-";
          if (this.comparenr > -1)
          {
            int num28 = this.game.Data.RoadTypeObj[index32].MoveCostOverrule[this.game.Data.SFTypeObj[this.comparenr].MoveType];
            string tvalue2 = Strings.Trim(Conversion.Str((object) (int) Math.Round((double) (int) Math.Round((double) num28 - Conversion.Int((double) num28 * ((double) this.game.Data.SFTypeObj[this.comparenr].MoveRedux / 100.0))) * ((double) this.game.Data.MoveTypePenalty[this.game.Data.SFTypeObj[this.comparenr].MoveType] / 100.0)))) + "ap";
            str14 = "-";
            this.OptionsList4Obj.add(name, 1000 + index32, tvalue, tvalue2);
          }
          else
            this.OptionsList4Obj.add(name, 1000 + index32, tvalue);
        }
        int riverTypeCounter1 = this.game.Data.RiverTypeCounter;
        for (int index33 = 0; index33 <= riverTypeCounter1; ++index33)
        {
          string name = this.game.Data.RiverTypeObj[index33].Name;
          int Number3 = this.game.Data.RiverTypeObj[index33].MovePenalty[this.game.Data.SFTypeObj[index31].MoveType];
          string str15 = "";
          if (Number3 > 0)
            str15 = "+";
          string tvalue = str15 + Strings.Trim(Conversion.Str((object) Number3)) + "ap";
          str13 = "-";
          if (this.comparenr > -1)
          {
            int Number4 = this.game.Data.RiverTypeObj[index33].MovePenalty[this.game.Data.SFTypeObj[this.comparenr].MoveType];
            string str16 = "";
            if (Number4 > 0)
              str16 = "+";
            string tvalue2 = str16 + Strings.Trim(Conversion.Str((object) Number4)) + "ap";
            str14 = "-";
            this.OptionsList3Obj.add(name, 2000 + index33, tvalue, tvalue2);
          }
          else
            this.OptionsList3Obj.add(name, 2000 + index33, tvalue);
        }
        int num29 = 110;
        int num30 = 385;
        if (this.OptionsListId > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
        }
        else
        {
          SubPartClass tsubpart24 = (SubPartClass) new ATListSubPartClass(this.OptionsListObj, 9, 400, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 260, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num29, bby: num30);
          this.OptionsListId = this.AddSubPart(ref tsubpart24, num29, num30, 400, 160, 0);
        }
        int num31 = num30 + 170;
        if (this.OptionsList4Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList4Id)].Refresh(this.OptionsList4Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList4Id)] = true;
        }
        else
        {
          SubPartClass tsubpart25 = (SubPartClass) new ATListSubPartClass(this.OptionsList4Obj, 3, 400, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 260, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num29, bby: num31);
          this.OptionsList4Id = this.AddSubPart(ref tsubpart25, num29, num31, 400, 64, 0);
        }
        int num32 = num31 + 74;
        if (this.OptionsList3Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
        }
        else
        {
          SubPartClass tsubpart26 = (SubPartClass) new ATListSubPartClass(this.OptionsList3Obj, 3, 400, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 260, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num29, bby: num32);
          this.OptionsList3Id = this.AddSubPart(ref tsubpart26, num29, num32, 400, 64, 0);
        }
        this.OptionsList6Obj = new ATListClass();
        this.combatList2Obj = new ATListClass();
        if (this.comparenr > -1)
        {
          this.OptionsList6Obj.add("LANDSCAPE", -1, "ATT", "DEF", "ATT", "DEF");
          this.combatList2Obj.add("RIVER TYPE", -1, "ATT", "DEF", "ATT", "DEF");
        }
        else
        {
          this.OptionsList6Obj.add("LANDSCAPE", -1, "ATT", "DEF");
          this.combatList2Obj.add("RIVER TYPE", -1, "ATT", "DEF");
        }
        int landscapeTypeCounter2 = this.game.Data.LandscapeTypeCounter;
        for (int tdata = 0; tdata <= landscapeTypeCounter2; ++tdata)
        {
          str12 = "";
          string name = this.game.Data.LandscapeTypeObj[tdata].Name;
          int Number5 = (int) Math.Round((double) (Conversion.Int(this.game.Data.SFTypeObj[sftyp4].CombatModAtt[tdata] * 100f) - 100f));
          string tvalue = Number5 != 0 ? Strings.Trim(Conversion.Str((object) Number5)) + "%" : "-";
          int artSfType1 = this.game.Data.SFTypeObj[sftyp4].ArtSFType;
          if (artSfType1 > -1)
          {
            int Number6 = (int) Math.Round((double) (Conversion.Int(this.game.Data.SFTypeObj[artSfType1].CombatModAtt[tdata] * 100f) - 100f));
            tvalue = Number6 != 0 ? tvalue + " (" + Strings.Trim(Conversion.Str((object) Number6)) + "%)" : tvalue + " (-)";
          }
          int Number7 = (int) Math.Round((double) (Conversion.Int(this.game.Data.SFTypeObj[sftyp4].CombatModDef[tdata] * 100f) - 100f));
          string tvalue2 = Number7 != 0 ? Strings.Trim(Conversion.Str((object) Number7)) + "%" : "-";
          int artSfType2 = this.game.Data.SFTypeObj[sftyp4].ArtSFType;
          if (artSfType2 > -1)
          {
            int Number8 = (int) Math.Round((double) (Conversion.Int(this.game.Data.SFTypeObj[artSfType2].CombatModDef[tdata] * 100f) - 100f));
            tvalue2 = Number8 != 0 ? tvalue2 + " (" + Strings.Trim(Conversion.Str((object) Number8)) + "%)" : tvalue2 + " (-)";
          }
          if (this.comparenr > -1)
          {
            int Number9 = (int) Math.Round((double) (Conversion.Int(this.game.Data.SFTypeObj[this.comparenr].CombatModAtt[tdata] * 100f) - 100f));
            string tvalue3 = Number9 != 0 ? Strings.Trim(Conversion.Str((object) Number9)) + "%" : "-";
            int artSfType3 = this.game.Data.SFTypeObj[this.comparenr].ArtSFType;
            if (artSfType3 > -1)
            {
              int Number10 = (int) Math.Round((double) (Conversion.Int(this.game.Data.SFTypeObj[artSfType3].CombatModAtt[tdata] * 100f) - 100f));
              tvalue3 = Number10 != 0 ? tvalue3 + " (" + Strings.Trim(Conversion.Str((object) Number10)) + "%)" : tvalue3 + " (-)";
            }
            int Number11 = (int) Math.Round((double) (Conversion.Int(this.game.Data.SFTypeObj[this.comparenr].CombatModDef[tdata] * 100f) - 100f));
            string tvalue4 = Number11 != 0 ? Strings.Trim(Conversion.Str((object) Number11)) + "%" : "-";
            int artSfType4 = this.game.Data.SFTypeObj[this.comparenr].ArtSFType;
            if (artSfType4 > -1)
            {
              int Number12 = (int) Math.Round((double) (Conversion.Int(this.game.Data.SFTypeObj[artSfType4].CombatModDef[tdata] * 100f) - 100f));
              tvalue4 = Number12 != 0 ? tvalue4 + " (" + Strings.Trim(Conversion.Str((object) Number12)) + "%)" : tvalue4 + " (-)";
            }
            this.OptionsList6Obj.add(name, tdata, tvalue, tvalue2, tvalue3, tvalue4);
          }
          else
            this.OptionsList6Obj.add(name, tdata, tvalue, tvalue2);
        }
        int riverTypeCounter2 = this.game.Data.RiverTypeCounter;
        for (int index34 = 0; index34 <= riverTypeCounter2; ++index34)
        {
          string name = this.game.Data.RiverTypeObj[index34].Name;
          int Number13 = (int) Math.Round((double) Conversion.Int(this.game.Data.RiverTypeObj[index34].AttackPenalty[this.game.Data.SFTypeObj[sftyp4].UnitGroup] * 100f));
          string tvalue = Number13 <= 0 ? "-" : "-" + Strings.Trim(Conversion.Str((object) Number13)) + "%";
          string tvalue2 = "-";
          if (this.comparenr > -1)
          {
            int Number14 = (int) Math.Round((double) Conversion.Int(this.game.Data.RiverTypeObj[index34].AttackPenalty[this.game.Data.SFTypeObj[this.comparenr].UnitGroup] * 100f));
            string tvalue3 = Number14 <= 0 ? "-" : "-" + Strings.Trim(Conversion.Str((object) Number14)) + "%";
            string tvalue4 = "-";
            this.combatList2Obj.add(name, 2000 + index34, tvalue, tvalue2, tvalue3, tvalue4);
          }
          else
            this.combatList2Obj.add(name, 2000 + index34, tvalue, tvalue2);
        }
        int num33 = 520;
        int num34 = 385;
        if (this.OptionsList6Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList6Id)].Refresh(this.OptionsList6Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList6Id)] = true;
        }
        else
        {
          SubPartClass tsubpart27 = (SubPartClass) new ATListSubPartClass(this.OptionsList6Obj, 13, 400, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 260, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num33, bby: num34);
          this.OptionsList6Id = this.AddSubPart(ref tsubpart27, num33, num34, 400, 224, 0);
        }
        int num35 = 520;
        int num36 = num34 + 244;
        if (this.combatList2Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.combatList2Id)].Refresh(this.combatList2Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.combatList2Id)] = true;
        }
        else
        {
          SubPartClass tsubpart28 = (SubPartClass) new ATListSubPartClass(this.combatList2Obj, 3, 400, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 260, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num35, bby: num36);
          this.combatList2Id = this.AddSubPart(ref tsubpart28, num35, num36, 400, 64, 0);
        }
      }
      if (this.StatMode == 4)
      {
        int num37 = 0;
        int sftyp5 = this.sftyp;
        int num38 = 190;
        int num39 = 385;
        this.OptionsListObj = new ATListClass();
        int preventCounter = this.game.Data.SFTypeObj[sftyp5].PreventCounter;
        for (int tdata = 0; tdata <= preventCounter; ++tdata)
        {
          if (this.game.Data.SFTypeObj[sftyp5].PreventChance[tdata] > 0)
          {
            ++num37;
            if (num37 == 1)
              this.OptionsListObj.add("PREVENT HIT ON", -1, "WHEN ATT BY", "PRIORITY", "CHANCE", "PTS COST");
            str12 = "";
            string tname = this.game.Data.SFTypeObj[sftyp5].PreventHitOn[tdata] <= -1 ? "ALL" : this.game.Data.TempString[400 + this.game.Data.SFTypeObj[sftyp5].PreventHitOn[tdata]];
            string tvalue = this.game.Data.SFTypeObj[sftyp5].PreventHitFrom[tdata] <= -1 ? "ALL" : this.game.Data.TempString[400 + this.game.Data.SFTypeObj[sftyp5].PreventHitFrom[tdata]];
            string tvalue2 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp5].PreventPriority[tdata]));
            string tvalue3 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp5].PreventChance[tdata])) + "%";
            string tvalue4 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp5].PreventPoints[tdata]));
            this.OptionsListObj.add(tname, tdata, tvalue, tvalue2, tvalue3, tvalue4);
          }
        }
        if (num37 > 0)
        {
          if (this.OptionsListId > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, -1);
            this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
          }
          else
          {
            SubPartClass tsubpart29 = (SubPartClass) new ATListSubPartClass(this.OptionsListObj, 9, 600, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 460, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num38, bby: num39);
            this.OptionsListId = this.AddSubPart(ref tsubpart29, num38, num39, 600, 160, 0);
          }
          num39 += 175;
        }
        int x21 = 340;
        ref Graphics local65 = ref Expression;
        rectangle2 = new Rectangle(x21, num39, 300, 14);
        Rectangle rect1_9 = rectangle2;
        rectangle1 = new Rectangle(x21, num39 + 14, 300, 23);
        Rectangle rect2_9 = rectangle1;
        string txt2_8 = Conversions.ToString(this.game.Data.SFTypeObj[sftyp5].MaxPreventPointsUsed);
        DrawMod.MakeFullBoxVic2(ref local65, rect1_9, "MAX PREVENT PTS GIVEN TO OTHERS", rect2_9, txt2_8);
        int x22 = 340;
        int y23 = num39 + 55;
        ref Graphics local66 = ref Expression;
        rectangle2 = new Rectangle(x22, y23, 300, 14);
        Rectangle rect1_10 = rectangle2;
        rectangle1 = new Rectangle(x22, y23 + 14, 300, 23);
        Rectangle rect2_10 = rectangle1;
        string txt2_9 = Conversions.ToString(this.game.Data.SFTypeObj[sftyp5].MaxPreventPointsGiven);
        DrawMod.MakeFullBoxVic2(ref local66, rect1_10, "MAX PREVENT PTS RECEIVED BY PREVENTERS", rect2_10, txt2_9);
      }
      if (this.sfnr == -1 & this.sftyp == -1 && this.passenger > -1)
      {
        SubPartClass tsubpart30 = (SubPartClass) new UnitHeaderPartClass(this.passenger, this.game);
        this.TempText1 = this.AddSubPart(ref tsubpart30, 360, 150, 225, 200, 0);
        if (this.game.Data.UnitObj[this.passenger].Historical > -1 & this.game.Data.UnitObj[this.passenger].IsHQ)
        {
          if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.passenger].Historical].CommanderSpriteID > -1)
            ;
        }
        else
        {
          DrawMod.DrawBlock(ref Expression, 160, 380, 680, 240, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
          DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref Expression, 160, 380, 680, 240, -1, -1);
          SubPartClass tsubpart31 = (SubPartClass) new UnitSFPartClass(this.passenger, this.game);
          this.temptext4 = this.AddSubPart(ref tsubpart31, 190, 400, 620, 200, 0);
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
              num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.combatList2Id)
            {
              num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
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
                    int num3 = (int) Interaction.MsgBox((object) orderResult.ErrorString, Title: ((object) "Shadow Empire : Planetary Conquest"));
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
                  int num4 = (int) Interaction.MsgBox((object) "You can only upgrade ALL because there is already 8 subformations in unit.");
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
