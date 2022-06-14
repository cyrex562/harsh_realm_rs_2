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
  pub class SFWindowClass : WindowClass
  {
     int TempText1;
     int temptext2;
     int temptext3;
     int temptext4;
     int temptext5;
     int temptext6;
     int temptext7;
     int temptext8;
     int temptext9;
     int temptext10;
     int TempText11;
     int temptext12;
     int temptext13;
     int temptext14;
     int temptext15;
     int temptext16;
     int temptext17;
     int temptext18;
     int temptext19;
     int temptext20;
     int TempText21;
     int temptext22;
     int temptext23;
     int temptext24;
     int temptext25;
     int temptext26;
     int temptext27;
     int temptext28;
     int temptext29;
     int temptext30;
     int TempText31;
     int temptext32;
     int temptext33;
     int temptext34;
     int temptext35;
     int temptext36;
     int temptext37;
     int temptext38;
     int temptext39;
     int temptext40;
     int temptext41;
     int temptext42;
     int temptext43;
     int temptext44;
     int temptext45;
     int temptext46;
     int LogoListId;
     int but1id;
     int tab1id;
     int tab2id;
     int tab3id;
     int tab4id;
     int tab5id;
     int but1textid;
     int but1bid;
     int hqbut0;
     int hqbut1;
     int hqbut2;
     int but2id;
     int but2textid;
     int but3id;
     int but3textid;
     int but4id;
     int but4textid;
     int but5id;
     int but5textid;
     int but6id;
     int but6textid;
     int but7id;
     int quitid;
     int but7textid;
     int descid;
     int comparenr;
     int sliderid;
     int logolist2id;
     int logolist3id;
     float tempBlink;
     int unr;
     int sfnr;
     int sftyp;
     int detailnr;
     int detailnr2;
     int detailtype;
     int ammount;
     bool hqreach;
     int passenger;
     int OptionsListId;
     ATListClass OptionsListObj;
     int OptionsList2Id;
     ATListClass OptionsList2Obj;
     int OptionsList3Id;
     ATListClass OptionsList3Obj;
     int OptionsList4Id;
     ATListClass OptionsList4Obj;
     int OptionsList5Id;
     ATListClass OptionsList5Obj;
     int OptionsList6Id;
     ATListClass OptionsList6Obj;
     int combatListId;
     ATListClass combatListObj;
     int combatList2Id;
     ATListClass combatList2Obj;
     int StatTyp;
     int StatMode;
     int[] ChainHq;
     int HQselect;
     int infoid;

    pub handleTimer: WindowReturnClass() => WindowReturnClass::new();

    pub void DoRefresh()
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

    pub SFWindowClass( GameClass tGame)
      : base( tGame, 1024, 768, BackSprite: tGame.BACKGROUND2MARC)
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
          let mut hq1: i32 = this.game.Data.UnitObj[this.ChainHq[0]].HQ;
          if (hq1 > -1 && this.game.Data.UnitObj[hq1].X > -1)
          {
            this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime,  Math.Round((double) this.game.Data.RuleVar[99]), 99,  Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y, this.game.Data.UnitObj[this.unr].Map, allowshoredrop: true);
            if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq1].Map].Value[this.game.Data.UnitObj[hq1].X, this.game.Data.UnitObj[hq1].Y] <= (double) this.game.Data.RuleVar[53])
            {
              this.ChainHq[1] = hq1;
              let mut hq2: i32 = this.game.Data.UnitObj[this.ChainHq[1]].HQ;
              if (hq2 > -1 && this.game.Data.UnitObj[hq2].X > -1 && (double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq2].Map].Value[this.game.Data.UnitObj[hq2].X, this.game.Data.UnitObj[hq2].Y] <= (double) this.game.Data.RuleVar[53])
                this.ChainHq[2] = hq2;
            }
          }
        }
        else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ > -1 && this.game.Data.UnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ].X > -1)
        {
          this.game.HandyFunctionsObj.MakeMovePrediction2(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime,  Math.Round((double) this.game.Data.RuleVar[99]), 99,  Math.Round((double) this.game.Data.RuleVar[3]), this.game.Data.UnitObj[this.unr].X, this.game.Data.UnitObj[this.unr].Y, this.game.Data.UnitObj[this.unr].Map, allowshoredrop: true);
          let mut hq3: i32 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ;
          if ((double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq3].Map].Value[this.game.Data.UnitObj[hq3].X, this.game.Data.UnitObj[hq3].Y] <= (double) this.game.Data.RuleVar[53])
          {
            this.ChainHq[0] = hq3;
            this.HQselect = hq3;
            let mut hq4: i32 = this.game.Data.UnitObj[this.ChainHq[0]].HQ;
            if (hq4 > -1 && this.game.Data.UnitObj[hq4].X > -1 && (double) this.game.EditObj.TempValue[this.game.Data.UnitObj[hq4].Map].Value[this.game.Data.UnitObj[hq4].X, this.game.Data.UnitObj[hq4].Y] <= (double) this.game.Data.RuleVar[53])
            {
              this.ChainHq[1] = hq4;
              let mut hq5: i32 = this.game.Data.UnitObj[this.ChainHq[1]].HQ;
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

    pub void DoStuff()
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
      let mut tsubpart1: SubPartClass =  ButtonPartClass::new(this.game.BUTTONQUIT);
      this.but1id = this.AddSubPart( tsubpart1, 952, 22, 32, 32, 1);
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
        str1: String = "";
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
          name: String = this.game.Data.SFTypeObj[index1].Name;
          int index6;
          if (this.game.Data.RegimeObj[index6].ExtraGraphicUse > -1)
          {
            let mut extraCounter: i32 = this.game.Data.SFTypeObj[index1].ExtraCounter;
            for (let mut index7: i32 = 0; index7 <= extraCounter; index7 += 1)
            {
              if (this.game.Data.SFTypeObj[index1].ExtraCode[index7] == this.game.Data.RegimeObj[index6].ExtraGraphicUse)
                name = this.game.Data.SFTypeObj[index1].ExtraName[index7];
            }
          }
          else if (index2 > -1 & this.sfnr > -1 && this.game.Data.PeopleObj[this.game.Data.SFObj[this.sfnr].People].ExtraGraphicUse > -1)
          {
            let mut extraCounter: i32 = this.game.Data.SFTypeObj[index1].ExtraCounter;
            for (let mut index8: i32 = 0; index8 <= extraCounter; index8 += 1)
            {
              if (this.game.Data.SFTypeObj[index1].ExtraCode[index8] == this.game.Data.PeopleObj[index2].ExtraGraphicUse)
                name = this.game.Data.SFTypeObj[index1].ExtraName[index8];
            }
          }
          str2 = name;
          str3: String = str1 + name;
          index6 = 0;
          index3 = this.sfnr <= -1 ? this.game.Data.Turn : this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime;
          let mut picSpriteId: i32 = this.game.Data.SFTypeObj[index1].PicSpriteID;
          let mut sidewaysSpriteId: i32 = this.game.Data.SFTypeObj[index1].SidewaysSpriteID;
          if (this.game.Data.RegimeObj[index3].ExtraGraphicUse > -1)
          {
            let mut extraCounter: i32 = this.game.Data.SFTypeObj[index1].ExtraCounter;
            for (let mut index9: i32 = 0; index9 <= extraCounter; index9 += 1)
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
            let mut extraCounter: i32 = this.game.Data.SFTypeObj[index1].ExtraCounter;
            for (let mut index10: i32 = 0; index10 <= extraCounter; index10 += 1)
            {
              if (this.game.Data.SFTypeObj[index1].ExtraCode[index10] == this.game.Data.PeopleObj[index2].ExtraGraphicUse)
              {
                picSpriteId = this.game.Data.SFTypeObj[index1].ExtraPicSpriteID[index10];
                sidewaysSpriteId = this.game.Data.SFTypeObj[index1].ExtraSidewaysSpriteID[index10];
              }
            }
          }
           let mut local1: &Graphics = &Expression;
          rectangle1 = Rectangle::new(num1, y1, 322, 14);
          let mut rect1: &Rectangle = &rectangle1
          rectangle2 = Rectangle::new(num1, y1 + 14, 322, 23);
          let mut rect2: &Rectangle = &rectangle2
          txt2: String = str3;
          DrawMod.MakeFullBoxVic2( local1, rect1, "SELECTED SUBFORMATION(TYPE)", rect2, txt2);
          let mut x1: i32 = num1;
          let mut y2: i32 = y1 + 47;
          if ((double) this.game.Data.RuleVar[869] >= 1.0)
          {
            index4 =  Math.Round((double) this.game.Data.RuleVar[873]);
            index5 = 0;
            if ((double) this.game.Data.RuleVar[848] > 0.0 & this.game.Data.SFTypeObj[index1].Theater == 2)
            {
              index4 =  Math.Round((double) this.game.Data.RuleVar[848]);
              index5 = 0;
            }
            if ((double) this.game.Data.RuleVar[872] > 0.0 & this.game.Data.SFTypeObj[index1].Theater == 1)
            {
              index4 =  Math.Round((double) this.game.Data.RuleVar[872]);
              index5 = 0;
            }
            if ((double) this.game.Data.RuleVar[869] == 3.0)
            {
              let mut nr: i32 = this.game.Data.LandscapeTypeObj[index4].BasicPicID[index5];
               let mut local2: &Graphics = &Expression;
              Bitmap bitmap = BitmapStore.GetBitmap(nr);
               let mut local3: &Bitmap = &bitmap;
              rectangle2 = Rectangle::new(0, 0, 138, BitmapStore.Getheight(nr));
              let mut srcrect: &Rectangle = &rectangle2
              rectangle1 = Rectangle::new(x1, y2, 192, 144);
              let mut destrect: &Rectangle = &rectangle1
              DrawMod.DrawSimplePart2( local2,  local3, srcrect, destrect);
            }
            else
            {
              if ((double) this.game.Data.RuleVar[869] == 1.0)
              {
                let mut nr: i32 = this.game.Data.LandscapeTypeObj[index4].SidewaysSPriteID1[index5];
                 let mut local4: &Graphics = &Expression;
                Bitmap bitmap = BitmapStore.GetBitmap(nr);
                 let mut local5: &Bitmap = &bitmap;
                rectangle2 = Rectangle::new(0, 0, 138, BitmapStore.Getheight(nr));
                let mut srcrect: &Rectangle = &rectangle2
                rectangle1 = Rectangle::new(x1, y2, 192, 144);
                let mut destrect: &Rectangle = &rectangle1
                DrawMod.DrawSimplePart2( local4,  local5, srcrect, destrect);
              }
              let mut nr1: i32 = this.game.Data.LandscapeTypeObj[index4].SidewaysSPriteID2[index5];
               let mut local6: &Graphics = &Expression;
              Bitmap bitmap1 = BitmapStore.GetBitmap(nr1);
               let mut local7: &Bitmap = &bitmap1;
              rectangle2 = Rectangle::new(0, 0, 138, BitmapStore.Getheight(nr1));
              let mut srcrect1: &Rectangle = &rectangle2
              rectangle1 = Rectangle::new(x1, y2, 192, 144);
              let mut destrect1: &Rectangle = &rectangle1
              DrawMod.DrawSimplePart2( local6,  local7, srcrect1, destrect1);
            }
          }
          let mut index11: i32 = index3;
          let mut red: i32 = this.game.Data.RegimeObj[index11].Red;
          let mut green: i32 = this.game.Data.RegimeObj[index11].Green;
          let mut blue: i32 = this.game.Data.RegimeObj[index11].Blue;
          switch (this.game.Data.SFTypeObj[index1].BaseColor)
          {
            case 0:
               let mut local8: &Graphics = &Expression;
              Bitmap bitmap2 = BitmapStore.GetBitmap(picSpriteId);
               let mut local9: &Bitmap = &bitmap2;
              let mut x2: i32 = x1;
              let mut y3: i32 = y2;
              DrawMod.DrawScaled( local8,  local9, x2, y3, 192, 144);
              break;
            case 1:
               let mut local10: &Graphics = &Expression;
              Bitmap bitmap3 = BitmapStore.GetBitmap(picSpriteId);
               let mut local11: &Bitmap = &bitmap3;
              let mut x3: i32 = x1;
              let mut y4: i32 = y2;
              let mut width1: i32 = BitmapStore.GetWidth(picSpriteId);
              let mut origh1: i32 = BitmapStore.Getheight(picSpriteId);
              double r1 = (double) ((float) red / 256f);
              double g1 = (double) ((float) green / 256f);
              double b1 = (double) ((float) blue / 256f);
              DrawMod.DrawScaledColorized2( local10,  local11, x3, y4, 192, 144, width1, origh1, (float) r1, (float) g1, (float) b1, 1f);
              break;
            case 2:
              let mut red2: i32 = this.game.Data.RegimeObj[index11].Red2;
              let mut green2: i32 = this.game.Data.RegimeObj[index11].Green2;
              let mut blue2: i32 = this.game.Data.RegimeObj[index11].Blue2;
               let mut local12: &Graphics = &Expression;
              Bitmap bitmap4 = BitmapStore.GetBitmap(picSpriteId);
               let mut local13: &Bitmap = &bitmap4;
              let mut x4: i32 = x1;
              let mut y5: i32 = y2;
              let mut width2: i32 = BitmapStore.GetWidth(picSpriteId);
              let mut origh2: i32 = BitmapStore.Getheight(picSpriteId);
              double r2 = (double) ((float) red2 / 256f);
              double g2 = (double) ((float) green2 / 256f);
              double b2 = (double) ((float) blue2 / 256f);
              DrawMod.DrawScaledColorized2( local12,  local13, x4, y5, 192, 144, width2, origh2, (float) r2, (float) g2, (float) b2, 1f);
              break;
            case 3:
              let mut red3: i32 = this.game.Data.RegimeObj[index11].Red3;
              let mut green3: i32 = this.game.Data.RegimeObj[index11].Green3;
              let mut blue3: i32 = this.game.Data.RegimeObj[index11].Blue3;
               let mut local14: &Graphics = &Expression;
              Bitmap bitmap5 = BitmapStore.GetBitmap(picSpriteId);
               let mut local15: &Bitmap = &bitmap5;
              let mut x5: i32 = x1;
              let mut y6: i32 = y2;
              let mut width3: i32 = BitmapStore.GetWidth(picSpriteId);
              let mut origh3: i32 = BitmapStore.Getheight(picSpriteId);
              double r3 = (double) ((float) red3 / 256f);
              double g3 = (double) ((float) green3 / 256f);
              double b3 = (double) ((float) blue3 / 256f);
              DrawMod.DrawScaledColorized2( local14,  local15, x5, y6, 192, 144, width3, origh3, (float) r3, (float) g3, (float) b3, 1f);
              break;
            case 4:
              let mut red4: i32 = this.game.Data.RegimeObj[index11].Red4;
              let mut green4: i32 = this.game.Data.RegimeObj[index11].Green4;
              let mut blue4: i32 = this.game.Data.RegimeObj[index11].Blue4;
               let mut local16: &Graphics = &Expression;
              Bitmap bitmap6 = BitmapStore.GetBitmap(picSpriteId);
               let mut local17: &Bitmap = &bitmap6;
              let mut x6: i32 = x1;
              let mut y7: i32 = y2;
              let mut width4: i32 = BitmapStore.GetWidth(picSpriteId);
              let mut origh4: i32 = BitmapStore.Getheight(picSpriteId);
              double r4 = (double) ((float) red4 / 256f);
              double g4 = (double) ((float) green4 / 256f);
              double b4 = (double) ((float) blue4 / 256f);
              DrawMod.DrawScaledColorized2( local16,  local17, x6, y7, 192, 144, width4, origh4, (float) r4, (float) g4, (float) b4, 1f);
              break;
            case 5:
               let mut local18: &Graphics = &Expression;
              Bitmap bitmap7 = BitmapStore.GetBitmap(picSpriteId);
               let mut local19: &Bitmap = &bitmap7;
              let mut x7: i32 = x1;
              let mut y8: i32 = y2;
              let mut width5: i32 = BitmapStore.GetWidth(picSpriteId);
              let mut origh5: i32 = BitmapStore.Getheight(picSpriteId);
              double r5 = (double) ((float) (red + 392) / 1024f);
              double g5 = (double) ((float) (green + 392) / 1024f);
              double b5 = (double) ((float) (blue + 392) / 1024f);
              DrawMod.DrawScaledColorized2( local18,  local19, x7, y8, 192, 144, width5, origh5, (float) r5, (float) g5, (float) b5, 1f);
              break;
            case 6:
               let mut local20: &Graphics = &Expression;
              Bitmap bitmap8 = BitmapStore.GetBitmap(picSpriteId);
               let mut local21: &Bitmap = &bitmap8;
              let mut x8: i32 = x1;
              let mut y9: i32 = y2;
              let mut width6: i32 = BitmapStore.GetWidth(picSpriteId);
              let mut origh6: i32 = BitmapStore.Getheight(picSpriteId);
              double r6 = (double) ((float) (red + 80) / 512f);
              double g6 = (double) ((float) (green + 200) / 512f);
              double b6 = (double) ((float) (blue + 80) / 512f);
              DrawMod.DrawScaledColorized2( local20,  local21, x8, y9, 192, 144, width6, origh6, (float) r6, (float) g6, (float) b6, 1f);
              break;
          }
          if ((double) this.game.Data.RuleVar[870] > 0.0 & !Information.IsNothing((object) BitmapStore.GetBitmap(sidewaysSpriteId)))
          {
             let mut local22: &Graphics = &Expression;
            Bitmap bitmap9 = BitmapStore.GetBitmap(sidewaysSpriteId);
             let mut local23: &Bitmap = &bitmap9;
            let mut x9: i32 = x1;
            let mut y10: i32 = y2;
            DrawMod.DrawScaled( local22,  local23, x9, y10, 192, 144);
          }
          if ((double) this.game.Data.RuleVar[869] >= 1.0 & (double) this.game.Data.RuleVar[869] < 3.0)
          {
            let mut nr: i32 = this.game.Data.LandscapeTypeObj[index4].SidewaysSPriteID3[index5];
             let mut local24: &Graphics = &Expression;
            Bitmap bitmap10 = BitmapStore.GetBitmap(nr);
             let mut local25: &Bitmap = &bitmap10;
            rectangle2 = Rectangle::new(0, 0, 138, BitmapStore.Getheight(nr));
            let mut srcrect: &Rectangle = &rectangle2
            rectangle1 = Rectangle::new(x1, y2, 192, 144);
            let mut destrect: &Rectangle = &rectangle1
            DrawMod.DrawSimplePart2( local24,  local25, srcrect, destrect);
          }
          DrawMod.DrawRectangle( Expression, num1, y1 + 47, 192, 144,  this.game.VicColor3.R,  this.game.VicColor3.G,  this.game.VicColor3.B,  this.game.VicColor3.A);
        }
        if (this.sfnr > -1)
        {
          this.OptionsList2Obj = ATListClass::new();
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
              tvalue: String = Strings.Trim(Conversion.Str((object) - Math.Round(100.0 - 100.0 * (double) num2))) + "%";
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
            let mut tsubpart2: SubPartClass =  new ATListSubPartClass(this.OptionsList2Obj, 10, 125, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 75, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: (num1 + 200), bby: (y1 + 47));
            this.OptionsList2Id = this.AddSubPart( tsubpart2, num1 + 200, y1 + 47, 125, 176, 0);
          }
        }
        if (this.comparenr == -1)
        {
          let mut tsubpart3: SubPartClass =  new TextButtonPartClass("Compare", 125, "Allows you to compare with a different subformation type",  this.OwnBitmap, num1 + 403, y1 + 115);
          this.but7id = this.AddSubPart( tsubpart3, num1 + 403, y1 + 115, 125, 35, 1);
        }
        else
        {
          let mut tsubpart4: SubPartClass =  new TextButtonPartClass("Change Compare", 125, "Allows you to compare with a different subformation type",  this.OwnBitmap, num1 + 623, y1 + 115);
          this.but7id = this.AddSubPart( tsubpart4, num1 + 623, y1 + 115, 125, 35, 1);
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
          str4: String = "";
          if (index12 > -1)
          {
            name: String = this.game.Data.SFTypeObj[index12].Name;
            if (this.game.Data.RegimeObj[index3].ExtraGraphicUse > -1)
            {
              let mut extraCounter: i32 = this.game.Data.SFTypeObj[index12].ExtraCounter;
              for (let mut index13: i32 = 0; index13 <= extraCounter; index13 += 1)
              {
                if (this.game.Data.SFTypeObj[index12].ExtraCode[index13] == this.game.Data.RegimeObj[index3].ExtraGraphicUse)
                  name = this.game.Data.SFTypeObj[index12].ExtraName[index13];
              }
            }
            else if (index2 > -1 && this.game.Data.PeopleObj[index2].ExtraGraphicUse > -1)
            {
              let mut extraCounter: i32 = this.game.Data.SFTypeObj[index12].ExtraCounter;
              for (let mut index14: i32 = 0; index14 <= extraCounter; index14 += 1)
              {
                if (this.game.Data.SFTypeObj[index12].ExtraCode[index14] == this.game.Data.PeopleObj[index2].ExtraGraphicUse)
                  name = this.game.Data.SFTypeObj[index12].ExtraName[index14];
              }
            }
            str5: String = str4 + name;
            let mut turn: i32 = this.game.Data.Turn;
            let mut picSpriteId: i32 = this.game.Data.SFTypeObj[index12].PicSpriteID;
            let mut sidewaysSpriteId: i32 = this.game.Data.SFTypeObj[index12].SidewaysSpriteID;
            if (this.game.Data.RegimeObj[turn].ExtraGraphicUse > -1)
            {
              let mut extraCounter: i32 = this.game.Data.SFTypeObj[index12].ExtraCounter;
              for (let mut index15: i32 = 0; index15 <= extraCounter; index15 += 1)
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
              let mut extraCounter: i32 = this.game.Data.SFTypeObj[index12].ExtraCounter;
              for (let mut index16: i32 = 0; index16 <= extraCounter; index16 += 1)
              {
                if (this.game.Data.SFTypeObj[index12].ExtraCode[index16] == this.game.Data.PeopleObj[index2].ExtraGraphicUse)
                {
                  picSpriteId = this.game.Data.SFTypeObj[index12].ExtraPicSpriteID[index16];
                  sidewaysSpriteId = this.game.Data.SFTypeObj[index12].ExtraSidewaysSpriteID[index16];
                }
              }
            }
             let mut local26: &Graphics = &Expression;
            rectangle2 = Rectangle::new(num1, y1, 192, 14);
            let mut rect1: &Rectangle = &rectangle2
            rectangle1 = Rectangle::new(num1, y1 + 14, 192, 23);
            let mut rect2: &Rectangle = &rectangle1
            txt2: String = str5;
            DrawMod.MakeFullBoxVic2( local26, rect1, "COMPARISON SUBFORMATIONTYPE", rect2, txt2);
            let mut index17: i32 = turn;
            let mut red: i32 = this.game.Data.RegimeObj[index17].Red;
            let mut green: i32 = this.game.Data.RegimeObj[index17].Green;
            let mut blue: i32 = this.game.Data.RegimeObj[index17].Blue;
            let mut baseColor: i32 = this.game.Data.SFTypeObj[index12].BaseColor;
            let mut x10: i32 = num1;
            let mut y11: i32 = y1 + 47;
            if ((double) this.game.Data.RuleVar[869] >= 1.0)
            {
              index4 =  Math.Round((double) this.game.Data.RuleVar[873]);
              index5 = 0;
              if ((double) this.game.Data.RuleVar[848] > 0.0 & this.game.Data.SFTypeObj[index12].Theater == 2)
              {
                index4 =  Math.Round((double) this.game.Data.RuleVar[848]);
                index5 = 0;
              }
              if ((double) this.game.Data.RuleVar[872] > 0.0 & this.game.Data.SFTypeObj[index12].Theater == 1)
              {
                index4 =  Math.Round((double) this.game.Data.RuleVar[872]);
                index5 = 0;
              }
              if ((double) this.game.Data.RuleVar[869] == 3.0)
              {
                let mut nr: i32 = this.game.Data.LandscapeTypeObj[index4].BasicPicID[index5];
                 let mut local27: &Graphics = &Expression;
                Bitmap bitmap = BitmapStore.GetBitmap(nr);
                 let mut local28: &Bitmap = &bitmap;
                rectangle2 = Rectangle::new(0, 0, 138, BitmapStore.Getheight(nr));
                let mut srcrect: &Rectangle = &rectangle2
                rectangle1 = Rectangle::new(x10, y11, 192, 144);
                let mut destrect: &Rectangle = &rectangle1
                DrawMod.DrawSimplePart2( local27,  local28, srcrect, destrect);
              }
              else
              {
                if ((double) this.game.Data.RuleVar[869] == 1.0)
                {
                  let mut nr: i32 = this.game.Data.LandscapeTypeObj[index4].SidewaysSPriteID1[index5];
                   let mut local29: &Graphics = &Expression;
                  Bitmap bitmap = BitmapStore.GetBitmap(nr);
                   let mut local30: &Bitmap = &bitmap;
                  rectangle2 = Rectangle::new(0, 0, 138, BitmapStore.Getheight(nr));
                  let mut srcrect: &Rectangle = &rectangle2
                  rectangle1 = Rectangle::new(x10, y11, 192, 144);
                  let mut destrect: &Rectangle = &rectangle1
                  DrawMod.DrawSimplePart2( local29,  local30, srcrect, destrect);
                }
                let mut nr2: i32 = this.game.Data.LandscapeTypeObj[index4].SidewaysSPriteID2[index5];
                 let mut local31: &Graphics = &Expression;
                Bitmap bitmap11 = BitmapStore.GetBitmap(nr2);
                 let mut local32: &Bitmap = &bitmap11;
                rectangle2 = Rectangle::new(0, 0, 138, BitmapStore.Getheight(nr2));
                let mut srcrect2: &Rectangle = &rectangle2
                rectangle1 = Rectangle::new(x10, y11, 192, 144);
                let mut destrect2: &Rectangle = &rectangle1
                DrawMod.DrawSimplePart2( local31,  local32, srcrect2, destrect2);
              }
            }
            switch (baseColor)
            {
              case 0:
                 let mut local33: &Graphics = &Expression;
                Bitmap bitmap12 = BitmapStore.GetBitmap(picSpriteId);
                 let mut local34: &Bitmap = &bitmap12;
                let mut x11: i32 = x10;
                let mut y12: i32 = y11;
                DrawMod.DrawScaled( local33,  local34, x11, y12, 192, 144);
                break;
              case 1:
                 let mut local35: &Graphics = &Expression;
                Bitmap bitmap13 = BitmapStore.GetBitmap(picSpriteId);
                 let mut local36: &Bitmap = &bitmap13;
                let mut x12: i32 = x10;
                let mut y13: i32 = y11;
                let mut width7: i32 = BitmapStore.GetWidth(picSpriteId);
                let mut origh7: i32 = BitmapStore.Getheight(picSpriteId);
                double r7 = (double) ((float) red / 256f);
                double g7 = (double) ((float) green / 256f);
                double b7 = (double) ((float) blue / 256f);
                DrawMod.DrawScaledColorized2( local35,  local36, x12, y13, 192, 144, width7, origh7, (float) r7, (float) g7, (float) b7, 1f);
                break;
              case 2:
                let mut red2: i32 = this.game.Data.RegimeObj[index17].Red2;
                let mut green2: i32 = this.game.Data.RegimeObj[index17].Green2;
                let mut blue2: i32 = this.game.Data.RegimeObj[index17].Blue2;
                 let mut local37: &Graphics = &Expression;
                Bitmap bitmap14 = BitmapStore.GetBitmap(picSpriteId);
                 let mut local38: &Bitmap = &bitmap14;
                let mut x13: i32 = x10;
                let mut y14: i32 = y11;
                let mut width8: i32 = BitmapStore.GetWidth(picSpriteId);
                let mut origh8: i32 = BitmapStore.Getheight(picSpriteId);
                double r8 = (double) ((float) red2 / 256f);
                double g8 = (double) ((float) green2 / 256f);
                double b8 = (double) ((float) blue2 / 256f);
                DrawMod.DrawScaledColorized2( local37,  local38, x13, y14, 192, 144, width8, origh8, (float) r8, (float) g8, (float) b8, 1f);
                break;
              case 3:
                let mut red3: i32 = this.game.Data.RegimeObj[index17].Red3;
                let mut green3: i32 = this.game.Data.RegimeObj[index17].Green3;
                let mut blue3: i32 = this.game.Data.RegimeObj[index17].Blue3;
                 let mut local39: &Graphics = &Expression;
                Bitmap bitmap15 = BitmapStore.GetBitmap(picSpriteId);
                 let mut local40: &Bitmap = &bitmap15;
                let mut x14: i32 = x10;
                let mut y15: i32 = y11;
                let mut width9: i32 = BitmapStore.GetWidth(picSpriteId);
                let mut origh9: i32 = BitmapStore.Getheight(picSpriteId);
                double r9 = (double) ((float) red3 / 256f);
                double g9 = (double) ((float) green3 / 256f);
                double b9 = (double) ((float) blue3 / 256f);
                DrawMod.DrawScaledColorized2( local39,  local40, x14, y15, 192, 144, width9, origh9, (float) r9, (float) g9, (float) b9, 1f);
                break;
              case 4:
                let mut red4: i32 = this.game.Data.RegimeObj[index17].Red4;
                let mut green4: i32 = this.game.Data.RegimeObj[index17].Green4;
                let mut blue4: i32 = this.game.Data.RegimeObj[index17].Blue4;
                 let mut local41: &Graphics = &Expression;
                Bitmap bitmap16 = BitmapStore.GetBitmap(picSpriteId);
                 let mut local42: &Bitmap = &bitmap16;
                let mut x15: i32 = x10;
                let mut y16: i32 = y11;
                let mut width10: i32 = BitmapStore.GetWidth(picSpriteId);
                let mut origh10: i32 = BitmapStore.Getheight(picSpriteId);
                double r10 = (double) ((float) red4 / 256f);
                double g10 = (double) ((float) green4 / 256f);
                double b10 = (double) ((float) blue4 / 256f);
                DrawMod.DrawScaledColorized2( local41,  local42, x15, y16, 192, 144, width10, origh10, (float) r10, (float) g10, (float) b10, 1f);
                break;
              case 5:
                 let mut local43: &Graphics = &Expression;
                Bitmap bitmap17 = BitmapStore.GetBitmap(picSpriteId);
                 let mut local44: &Bitmap = &bitmap17;
                let mut x16: i32 = x10;
                let mut y17: i32 = y11;
                let mut width11: i32 = BitmapStore.GetWidth(picSpriteId);
                let mut origh11: i32 = BitmapStore.Getheight(picSpriteId);
                double r11 = (double) ((float) (red + 392) / 1024f);
                double g11 = (double) ((float) (green + 392) / 1024f);
                double b11 = (double) ((float) (blue + 392) / 1024f);
                DrawMod.DrawScaledColorized2( local43,  local44, x16, y17, 192, 144, width11, origh11, (float) r11, (float) g11, (float) b11, 1f);
                break;
              case 6:
                 let mut local45: &Graphics = &Expression;
                Bitmap bitmap18 = BitmapStore.GetBitmap(picSpriteId);
                 let mut local46: &Bitmap = &bitmap18;
                let mut x17: i32 = x10;
                let mut y18: i32 = y11;
                let mut width12: i32 = BitmapStore.GetWidth(picSpriteId);
                let mut origh12: i32 = BitmapStore.Getheight(picSpriteId);
                double r12 = (double) ((float) (red + 80) / 512f);
                double g12 = (double) ((float) (green + 200) / 512f);
                double b12 = (double) ((float) (blue + 80) / 512f);
                DrawMod.DrawScaledColorized2( local45,  local46, x17, y18, 192, 144, width12, origh12, (float) r12, (float) g12, (float) b12, 1f);
                break;
            }
            if ((double) this.game.Data.RuleVar[870] > 0.0 & !Information.IsNothing((object) BitmapStore.GetBitmap(sidewaysSpriteId)))
            {
               let mut local47: &Graphics = &Expression;
              Bitmap bitmap19 = BitmapStore.GetBitmap(sidewaysSpriteId);
               let mut local48: &Bitmap = &bitmap19;
              let mut x18: i32 = x10;
              let mut y19: i32 = y11;
              DrawMod.DrawScaled( local47,  local48, x18, y19, 192, 144);
            }
            if ((double) this.game.Data.RuleVar[869] >= 1.0 & (double) this.game.Data.RuleVar[869] < 3.0)
            {
              let mut nr: i32 = this.game.Data.LandscapeTypeObj[index4].SidewaysSPriteID3[index5];
               let mut local49: &Graphics = &Expression;
              Bitmap bitmap20 = BitmapStore.GetBitmap(nr);
               let mut local50: &Bitmap = &bitmap20;
              rectangle2 = Rectangle::new(0, 0, 138, BitmapStore.Getheight(nr));
              let mut srcrect: &Rectangle = &rectangle2
              rectangle1 = Rectangle::new(x10, y11, 192, 144);
              let mut destrect: &Rectangle = &rectangle1
              DrawMod.DrawSimplePart2( local49,  local50, srcrect, destrect);
            }
            DrawMod.DrawRectangle( Expression, num1, y1 + 47, 192, 144,  this.game.VicColor3.R,  this.game.VicColor3.G,  this.game.VicColor3.B,  this.game.VicColor3.A);
          }
        }
        let mut sftyp1: i32 = this.sftyp;
        let mut num3: i32 = 300;
        let mut num4: i32 = 15;
        let mut tsubpart5: SubPartClass =  new TextButtonPartClass("Text & Upgrade", 150, tBackbitmap: ( this.OwnBitmap), bbx: (num4 + 170 - 85), bby: num3, tred: (this.StatMode == 0));
        this.tab1id = this.AddSubPart( tsubpart5, num4 + 170 - 85, num3, 150, 35, 1);
        let mut tsubpart6: SubPartClass =  new TextButtonPartClass("General Stats", 150, tBackbitmap: ( this.OwnBitmap), bbx: (num4 + 340 - 85), bby: num3, tred: (this.StatMode == 1));
        this.tab2id = this.AddSubPart( tsubpart6, num4 + 340 - 85, num3, 150, 35, 1);
        let mut tsubpart7: SubPartClass =  new TextButtonPartClass("Combat Stats", 150, tBackbitmap: ( this.OwnBitmap), bbx: (num4 + 510 - 85), bby: num3, tred: (this.StatMode == 2));
        this.tab3id = this.AddSubPart( tsubpart7, num4 + 510 - 85, num3, 150, 35, 1);
        let mut tsubpart8: SubPartClass =  new TextButtonPartClass("Prevent Rules", 150, tBackbitmap: ( this.OwnBitmap), bbx: (num4 + 680 - 85), bby: num3, tred: (this.StatMode == 4));
        this.tab5id = this.AddSubPart( tsubpart8, num4 + 680 - 85, num3, 150, 35, 1);
        let mut tsubpart9: SubPartClass =  new TextButtonPartClass("Landscape Stats", 150, tBackbitmap: ( this.OwnBitmap), bbx: (num4 + 850 - 85), bby: num3, tred: (this.StatMode == 3));
        this.tab4id = this.AddSubPart( tsubpart9, num4 + 850 - 85, num3, 150, 35, 1);
        DrawMod.DrawBlock( Expression, num4 + 50, num3 + 55, 890, 355,  this.game.VicColor4.R,  this.game.VicColor4.G,  this.game.VicColor4.B,  this.game.VicColor4.A);
        DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  Expression, num4 + 50, num3 + 55, 890, 355, -1, -1);
        if (this.StatMode == 0)
        {
          let mut num5: i32 = 0;
          let mut num6: i32 = 50;
          let mut num7: i32 = 130;
          let mut sftyp2: i32 = this.sftyp;
          bool flag;
          if (this.sfnr > -1)
          {
            if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn && !this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType].IsSea)
            {
              this.detailnr = -1;
              let mut num8: i32 = 0;
              if (this.game.Data.SFTypeObj[sftyp2].UpgradeToo > -1)
              {
                let mut upgradeToo: i32 = this.game.Data.SFTypeObj[sftyp2].UpgradeToo;
                if (this.game.HandyFunctionsObj.CanUpgrade(this.sfnr, this.unr))
                {
                  if (this.HQselect > -1)
                  {
                    name: String = this.game.Data.SFTypeObj[upgradeToo].Name;
                     let mut local51: &Graphics = &Expression;
                    rectangle2 = Rectangle::new(num6 + 30, num7 +  byte.MaxValue, 192, 14);
                    let mut rect1_1: &Rectangle = &rectangle2
                    rectangle1 = Rectangle::new(num6 + 30, num7 + 268, 192, 23);
                    let mut rect2_1: &Rectangle = &rectangle1
                    txt2_1: String = name;
                    DrawMod.MakeFullBoxVic2( local51, rect1_1, "UPGRADEABLE TOO", rect2_1, txt2_1);
                    flag = true;
                    num7 -= 30;
                    str6: String = this.game.Data.UnitObj[this.HQselect].Name;
                    if (Strings.Len(str6) > 18)
                      str6 = Strings.Left(str6, 18);
                     let mut local52: &Graphics = &Expression;
                    rectangle2 = Rectangle::new(num6 + 250, num7 + 360, 192, 14);
                    let mut rect1_2: &Rectangle = &rectangle2
                    rectangle1 = Rectangle::new(num6 + 250, num7 + 374, 192, 23);
                    let mut rect2_2: &Rectangle = &rectangle1
                    txt2_2: String = str6;
                    DrawMod.MakeFullBoxVic2( local52, rect1_2, "SELECTED HQ", rect2_2, txt2_2);
                    str7: String = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.HQSupply(this.HQselect)));
                     let mut local53: &Graphics = &Expression;
                    rectangle2 = Rectangle::new(num6 + 250, num7 + 400, 192, 14);
                    let mut rect1_3: &Rectangle = &rectangle2
                    rectangle1 = Rectangle::new(num6 + 250, num7 + 414, 192, 23);
                    let mut rect2_3: &Rectangle = &rectangle1
                    txt2_3: String = str7;
                    DrawMod.MakeFullBoxVic2( local53, rect1_3, "SUPPLY AVAILABLE", rect2_3, txt2_3);
                    let mut picSpriteId: i32 = this.game.Data.SFTypeObj[upgradeToo].PicSpriteID;
                    let mut sidewaysSpriteId: i32 = this.game.Data.SFTypeObj[upgradeToo].SidewaysSpriteID;
                    let mut index18: i32 = !(this.sfnr > -1 & this.game.EditObj.UnitSelected > -1) ? this.game.Data.Turn : this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime;
                    if (this.game.Data.RegimeObj[index18].ExtraGraphicUse > -1)
                    {
                      let mut extraCounter: i32 = this.game.Data.SFTypeObj[upgradeToo].ExtraCounter;
                      for (let mut index19: i32 = 0; index19 <= extraCounter; index19 += 1)
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
                      let mut extraCounter: i32 = this.game.Data.SFTypeObj[upgradeToo].ExtraCounter;
                      for (let mut index20: i32 = 0; index20 <= extraCounter; index20 += 1)
                      {
                        if (this.game.Data.SFTypeObj[upgradeToo].ExtraCode[index20] == this.game.Data.PeopleObj[index2].ExtraGraphicUse)
                        {
                          picSpriteId = this.game.Data.SFTypeObj[upgradeToo].ExtraPicSpriteID[index20];
                          sidewaysSpriteId = this.game.Data.SFTypeObj[upgradeToo].ExtraSidewaysSpriteID[index20];
                        }
                      }
                    }
                     let mut local54: &Graphics = &Expression;
                    Bitmap bitmap21 = BitmapStore.GetBitmap(picSpriteId);
                     let mut local55: &Bitmap = &bitmap21;
                    let mut x19: i32 = num6 + 30;
                    let mut y20: i32 = num7 + 330;
                    DrawMod.DrawScaled( local54,  local55, x19, y20, 192, 144);
                     let mut local56: &Graphics = &Expression;
                    Bitmap bitmap22 = BitmapStore.GetBitmap(sidewaysSpriteId);
                     let mut local57: &Bitmap = &bitmap22;
                    let mut x20: i32 = num6 + 30;
                    let mut y21: i32 = num7 + 330;
                    DrawMod.DrawScaled( local56,  local57, x20, y21, 192, 144);
                     let mut local58: &Graphics = &Expression;
                    rectangle2 = Rectangle::new(num6 + 248, num7 + 287, 192, 14);
                    let mut rect1_4: &Rectangle = &rectangle2
                    rectangle1 = Rectangle::new(num6 + 248, num7 + 301, 192, 50);
                    let mut rect2_4: &Rectangle = &rectangle1
                    DrawMod.MakeFullBoxVic2( local58, rect1_4, "AVAILABLE HQS", rect2_4, "");
                    if (this.ChainHq[0] > -1)
                    {
                      bool forcehighlight = false;
                      if (this.HQselect == this.ChainHq[0] & this.HQselect != -1)
                        forcehighlight = true;
                      let mut tsubpart10: SubPartClass =  ButtonPartClass::new(this.game.CustomBitmapObj.DrawUnit(this.ChainHq[0], forcehighlight), this.game.Data.UnitObj[this.ChainHq[0]].Name);
                      this.hqbut0 = this.AddSubPart( tsubpart10, num6 + 260, num7 + 308, 36, 36, 0);
                      if (forcehighlight)
                        DrawMod.DrawRectangle( Expression, num6 + 258, num7 + 306, 40, 40,  byte.MaxValue, 0, 0,  byte.MaxValue, 2);
                    }
                    if (this.ChainHq[1] > -1)
                    {
                      bool forcehighlight = false;
                      if (this.HQselect == this.ChainHq[1] & this.HQselect != -1)
                        forcehighlight = true;
                      let mut tsubpart11: SubPartClass =  ButtonPartClass::new(this.game.CustomBitmapObj.DrawUnit(this.ChainHq[1], forcehighlight), this.game.Data.UnitObj[this.ChainHq[1]].Name);
                      this.hqbut1 = this.AddSubPart( tsubpart11, num6 + 300, num7 + 308, 36, 36, 0);
                      if (forcehighlight)
                        DrawMod.DrawRectangle( Expression, num6 + 298, num7 + 306, 40, 40,  byte.MaxValue, 0, 0,  byte.MaxValue, 2);
                    }
                    if (this.ChainHq[2] > -1)
                    {
                      bool forcehighlight = false;
                      if (this.HQselect == this.ChainHq[2] & this.HQselect != -1)
                        forcehighlight = true;
                      let mut tsubpart12: SubPartClass =  ButtonPartClass::new(this.game.CustomBitmapObj.DrawUnit(this.ChainHq[2], forcehighlight), this.game.Data.UnitObj[this.ChainHq[2]].Name);
                      this.hqbut2 = this.AddSubPart( tsubpart12, num6 + 340, num7 + 308, 36, 36, 0);
                      if (forcehighlight)
                        DrawMod.DrawRectangle( Expression, num6 + 338, num7 + 306, 40, 40,  byte.MaxValue, 0, 0,  byte.MaxValue, 2);
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
                    str8: String = "No HQ in supply range.";
                     let mut local: &Graphics = &Expression;
                    rectangle2 = Rectangle::new(num6 + 30, num7 +  byte.MaxValue, 192, 14);
                    let mut rect1: &Rectangle = &rectangle2
                    rectangle1 = Rectangle::new(num6 + 30, num7 + 268, 192, 23);
                    let mut rect2: &Rectangle = &rectangle1
                    txt2: String = str8;
                    DrawMod.MakeFullBoxVic2( local, rect1, "UPGRADEABLE TOO", rect2, txt2);
                    num5 = 1;
                  }
                }
              }
              if (this.detailnr > -1 & num8 > 0 & this.HQselect > -1)
              {
                if (this.game.HandyFunctionsObj.CanUpgradeCost(this.sfnr, this.unr, this.detailnr2) <= this.game.HandyFunctionsObj.HQSupply(this.HQselect))
                {
                  let mut tsubpart13: SubPartClass =  new TextButtonPartClass("Do Upgrade", 120, tBackbitmap: ( this.OwnBitmap), bbx: (num6 + 340), bby: (num7 + 504));
                  this.but3id = this.AddSubPart( tsubpart13, num6 + 340, num7 + 504, 120, 35, 1);
                }
                str9: String = Conversion.Str((object) Conversion.Int((float) this.game.Data.SFTypeObj[sftyp2].UpgradeCost / this.game.Data.RuleVar[77])) + " X " + Conversion.Str((object) this.detailnr2) + " = " + Conversion.Str((object) this.game.HandyFunctionsObj.CanUpgradeCost(this.sfnr, this.unr, this.detailnr2));
                 let mut local59: &Graphics = &Expression;
                rectangle2 = Rectangle::new(num6 + 250, num7 + 440, 192, 14);
                let mut rect1: &Rectangle = &rectangle2
                rectangle1 = Rectangle::new(num6 + 250, num7 + 454, 192, 23);
                let mut rect2: &Rectangle = &rectangle1
                txt2: String = str9;
                DrawMod.MakeFullBoxVic2( local59, rect1, "SUPPLY COST", rect2, txt2);
                flag = true;
                if (this.detailnr2 > num8)
                  this.detailnr2 = num8;
                let mut game: GameClass = this.game;
                tsuffix: String = " of " + Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Qty));
                let mut tmaxval: i32 = num8;
                let mut detailnr2: i32 = this.detailnr2;
                Bitmap bitmap = (Bitmap) null;
                 let mut local60: &Bitmap = &bitmap;
                let mut tsubpart14: SubPartClass =  new NumberSliderSubPartClass2(game, "Upgrade ", tsuffix, 300, 0, tmaxval, detailnr2, tbackbitmap: ( local60));
                this.sliderid = this.AddSubPart( tsubpart14, num6 + 30, num7 + 500, 300, 40, 0);
              }
              let mut tsubpart15: SubPartClass =  new TextButtonPartClass("Disband", 100, tBackbitmap: ( this.OwnBitmap), bbx: (num6 + 30), bby: 660);
              this.but2id = this.AddSubPart( tsubpart15, num6 + 30, 660, 100, 35, 1);
            }
            if (num5 == 0 && this.game.Data.SFTypeObj[sftyp2].UpgradeToo > -1)
            {
              let mut upgradeToo: i32 = this.game.Data.SFTypeObj[sftyp2].UpgradeToo;
              let mut picSpriteId: i32 = this.game.Data.SFTypeObj[this.game.Data.SFTypeObj[sftyp2].UpgradeToo].PicSpriteID;
              let mut index21: i32 = !(this.sfnr > -1 & this.game.EditObj.UnitSelected > -1) ? this.game.Data.Turn : this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime;
              if (this.game.Data.Turn == index21)
              {
                if (this.game.Data.RegimeObj[index21].ExtraGraphicUse > -1)
                {
                  let mut extraCounter: i32 = this.game.Data.SFTypeObj[upgradeToo].ExtraCounter;
                  for (let mut index22: i32 = 0; index22 <= extraCounter; index22 += 1)
                  {
                    if (this.game.Data.SFTypeObj[upgradeToo].ExtraCode[index22] == this.game.Data.RegimeObj[index21].ExtraGraphicUse)
                      picSpriteId = this.game.Data.SFTypeObj[upgradeToo].ExtraPicSpriteID[index22];
                  }
                }
                else if (index2 > -1 && this.game.Data.PeopleObj[index2].ExtraGraphicUse > -1)
                {
                  let mut extraCounter: i32 = this.game.Data.SFTypeObj[upgradeToo].ExtraCounter;
                  for (let mut index23: i32 = 0; index23 <= extraCounter; index23 += 1)
                  {
                    if (this.game.Data.SFTypeObj[upgradeToo].ExtraCode[index23] == this.game.Data.PeopleObj[index2].ExtraGraphicUse)
                      picSpriteId = this.game.Data.SFTypeObj[upgradeToo].ExtraPicSpriteID[index23];
                  }
                }
                flag = true;
                name1: String = this.game.Data.SFTypeObj[this.game.Data.SFTypeObj[sftyp2].UpgradeToo].Name;
                 let mut local61: &Graphics = &Expression;
                rectangle2 = Rectangle::new(num6 + 30, num7 +  byte.MaxValue, 192, 14);
                let mut rect1_5: &Rectangle = &rectangle2
                rectangle1 = Rectangle::new(num6 + 30, num7 + 268, 192, 23);
                let mut rect2_5: &Rectangle = &rectangle1
                txt2_4: String = name1;
                DrawMod.MakeFullBoxVic2( local61, rect1_5, "COULD BE UPGRADED TOO", rect2_5, txt2_4);
                let mut y22: i32 = num7 - 30 +  byte.MaxValue + 30;
                if (this.game.Data.SFTypeObj[sftyp2].UpgradeXP > 0)
                {
                  str10: String = Conversion.Str((object) this.game.Data.SFTypeObj[sftyp2].UpgradeXP);
                   let mut local62: &Graphics = &Expression;
                  rectangle2 = Rectangle::new(num6 + 260, y22, 192, 14);
                  let mut rect1_6: &Rectangle = &rectangle2
                  rectangle1 = Rectangle::new(num6 + 260, y22 + 14, 192, 23);
                  let mut rect2_6: &Rectangle = &rectangle1
                  txt2_5: String = str10;
                  DrawMod.MakeFullBoxVic2( local62, rect1_6, "Minimum XP needed", rect2_6, txt2_5);
                  y22 += 40;
                }
                let mut index24: i32 = -1;
                let mut itemTypeCounter: i32 = this.game.Data.ItemTypeCounter;
                for (let mut index25: i32 = 0; index25 <= itemTypeCounter; index25 += 1)
                {
                  if (this.game.Data.ItemTypeObj[index25].IsSFType == this.game.Data.SFTypeObj[sftyp2].UpgradeToo)
                  {
                    index24 = index25;
                    break;
                  }
                }
                if (index24 > -1)
                {
                  let mut index26: i32 = 0;
                  do
                  {
                    if (this.game.Data.ItemTypeObj[index24].ResFieldNeeded[index26] > -1)
                    {
                      name2: String = this.game.Data.ResearchObj[this.game.Data.ItemTypeObj[index24].ResFieldNeeded[index26]].Name;
                       let mut local63: &Graphics = &Expression;
                      rectangle2 = Rectangle::new(num6 + 260, y22, 192, 14);
                      let mut rect1_7: &Rectangle = &rectangle2
                      rectangle1 = Rectangle::new(num6 + 260, y22 + 14, 192, 23);
                      let mut rect2_7: &Rectangle = &rectangle1
                      txt2_6: String = name2;
                      DrawMod.MakeFullBoxVic2( local63, rect1_7, "RESEARCH NEED FOR UPGRADE", rect2_7, txt2_6);
                      y22 += 40;
                    }
                    index26 += 1;
                  }
                  while (index26 <= 4);
                }
                str11: String = Conversion.Str((object) Conversion.Int((float) this.game.Data.SFTypeObj[sftyp2].UpgradeCost / this.game.Data.RuleVar[77]));
                 let mut local64: &Graphics = &Expression;
                rectangle2 = Rectangle::new(num6 + 260, y22, 192, 14);
                let mut rect1_8: &Rectangle = &rectangle2
                rectangle1 = Rectangle::new(num6 + 260, y22 + 14, 192, 23);
                let mut rect2_8: &Rectangle = &rectangle1
                txt2_7: String = str11;
                DrawMod.MakeFullBoxVic2( local64, rect1_8, "UPGRADE SUPPLY COST", rect2_8, txt2_7);
              }
            }
          }
          if (sftyp2 > -1)
          {
            if (flag)
            {
              let mut num9: i32 = 550;
              let mut num10: i32 = 385;
              DrawMod.DrawPaperSheet( Expression, num9 - 20, num10 - 10, 415, 320);
              let mut tsubpart16: SubPartClass =  new PaperAreaClass(this.game, 365, 14,  null, "Description", false, str2 + "\r\n\r\n" + this.game.Data.SFTypeObj[sftyp2].Description, this.game.VicColor8, tItemSize: 20, tbackbitmap: ( this.OwnBitmap), bbx: num9, bby: num10);
              this.descid = this.AddSubPart( tsubpart16, num9, num10, 365, 300, 0);
            }
            else
            {
              let mut num11: i32 = 220;
              let mut num12: i32 = 385;
              DrawMod.DrawPaperSheet( Expression, num11 - 20, num12 - 10, 630, 320);
              let mut tsubpart17: SubPartClass =  new PaperAreaClass(this.game, 580, 14,  null, "Description", false, str2 + "\r\n\r\n" + this.game.Data.SFTypeObj[sftyp2].Description, this.game.VicColor8, tItemSize: 20, tbackbitmap: ( this.OwnBitmap), bbx: num11, bby: num12);
              this.descid = this.AddSubPart( tsubpart17, num11, num12, 580, 300, 0);
            }
          }
        }
      }
      let mut sftyp3: i32 = this.sftyp;
      string str12;
      if (this.StatMode == 1 & sftyp3 > -1)
      {
        let mut num13: i32 = 150;
        let mut num14: i32 = 385;
        this.OptionsList3Obj = ATListClass::new();
        str12 = "";
        tvalue2_1: String = "";
        tvalue1: String = this.game.Data.TempString[this.game.Data.SFTypeObj[sftyp3].UnitGroup + 400];
        if (this.comparenr > -1)
          tvalue2_1 = this.game.Data.TempString[this.game.Data.SFTypeObj[this.comparenr].UnitGroup + 400];
        this.OptionsList3Obj.add("SFTypeGroup", -1, tvalue1, tvalue2_1);
        str12 = "";
        tvalue2_2: String = "";
        tvalue2: String = this.game.Data.TempString[this.game.Data.SFTypeObj[sftyp3].MoveType + 0];
        if (this.comparenr > -1)
          tvalue2_2 = this.game.Data.TempString[this.game.Data.SFTypeObj[this.comparenr].MoveType + 0];
        this.OptionsList3Obj.add("MoveType", -1, tvalue2, tvalue2_2);
        str12 = "";
        tvalue2_3: String = "";
        tvalue3: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].SupplyCarry));
        if (this.comparenr > -1)
          tvalue2_3 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].SupplyCarry));
        this.OptionsList3Obj.add("Supply Carry", -1, tvalue3, tvalue2_3);
        str12 = "";
        tvalue2_4: String = "";
        tvalue4: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].BasicSupplyNeed));
        if (this.comparenr > -1)
          tvalue2_4 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].BasicSupplyNeed));
        this.OptionsList3Obj.add("Supply Consum", -1, tvalue4, tvalue2_4);
        str12 = "";
        tvalue2_5: String = "";
        tvalue5: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].Cap));
        if (this.game.Data.SFTypeObj[sftyp3].Theater > 0)
          tvalue5 = "0";
        if (this.comparenr > -1)
          tvalue2_5 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].Cap));
        if (this.comparenr > -1 && this.game.Data.SFTypeObj[this.comparenr].Theater > 0)
          tvalue2_5 = "0";
        this.OptionsList3Obj.add("Land.Tr.Cap", -1, tvalue5, tvalue2_5);
        str12 = "";
        tvalue2_6: String = "";
        tvalue6: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].Cap));
        if (this.game.Data.SFTypeObj[sftyp3].Theater != 1)
          tvalue6 = "0";
        if (this.comparenr > -1)
          tvalue2_6 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].Cap));
        if (this.comparenr > -1 && this.game.Data.SFTypeObj[this.comparenr].Theater != 1)
          tvalue2_6 = "0";
        this.OptionsList3Obj.add("Sea.Tr.Cap", -1, tvalue6, tvalue2_6);
        str12 = "";
        tvalue2_7: String = "";
        tvalue7: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].RailCap));
        if (this.comparenr > -1)
          tvalue2_7 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].RailCap));
        this.OptionsList3Obj.add("Rail.Tr.Cap", -1, tvalue7, tvalue2_7);
        str12 = "";
        tvalue2_8: String = "";
        tvalue8: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].Theater));
        if (this.comparenr > -1)
          tvalue2_8 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].Theater));
        this.OptionsList3Obj.add("Theater", -1, tvalue8, tvalue2_8);
        str12 = "";
        tvalue2_9: String = "";
        tvalue9: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].Weight));
        if (this.comparenr > -1)
          tvalue2_9 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].Weight));
        this.OptionsList3Obj.add("Weight", -1, tvalue9, tvalue2_9);
        str12 = "";
        tvalue2_10: String = "";
        tvalue10: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].CarryCap));
        if (this.comparenr > -1)
          tvalue2_10 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].CarryCap));
        this.OptionsList3Obj.add("Carry Cap.", -1, tvalue10, tvalue2_10);
        str12 = "";
        tvalue2_11: String = "";
        tvalue11: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].MoveRedux));
        if (this.comparenr > -1)
          tvalue2_11 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].MoveRedux));
        this.OptionsList3Obj.add("Move Redux", -1, tvalue11, tvalue2_11);
        str12 = "";
        tvalue2_12: String = "";
        tvalue12: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].ReconPts));
        if (this.comparenr > -1)
          tvalue2_12 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].ReconPts));
        this.OptionsList3Obj.add("Recon Points", -1, tvalue12, tvalue2_12);
        str12 = "";
        tvalue2_13: String = "";
        tvalue13: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].ZOCPts));
        if (this.comparenr > -1)
          tvalue2_13 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].ZOCPts));
        this.OptionsList3Obj.add("ZOC Points", -1, tvalue13, tvalue2_13);
        str12 = "";
        tvalue2_14: String = "";
        tvalue14: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].HidePts));
        if (this.comparenr > -1)
          tvalue2_14 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].HidePts));
        this.OptionsList3Obj.add("Hide Points", -1, tvalue14, tvalue2_14);
        str12 = "";
        tvalue2_15: String = "";
        tvalue15: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].CanDoParadrop));
        if (this.comparenr > -1)
          tvalue2_15 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].CanDoParadrop));
        this.OptionsList3Obj.add("Paradrop", -1, tvalue15, tvalue2_15);
        str12 = "";
        tvalue2_16: String = "";
        tvalue16: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].EP));
        if (this.comparenr > -1)
          tvalue2_16 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].EP));
        this.OptionsList3Obj.add("Engineer Pts", -1, tvalue16, tvalue2_16);
        str12 = "";
        tvalue2_17: String = "";
        tvalue17: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].StaffPts));
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
          let mut tsubpart18: SubPartClass =  new ATListSubPartClass(this.OptionsList3Obj, 16, 330, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 230, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: num13, bby: num14);
          this.OptionsList3Id = this.AddSubPart( tsubpart18, num13, num14, 330, 272, 0);
        }
        let mut num15: i32 = 540;
        let mut num16: i32 = 385;
        this.OptionsList4Obj = ATListClass::new();
        str12 = "";
        tvalue2_18: String = "";
        tvalue18: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].StaffCombatMod));
        if (this.comparenr > -1)
          tvalue2_18 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].StaffCombatMod));
        this.OptionsList4Obj.add("Staff Com Mod", -1, tvalue18, tvalue2_18);
        str12 = "";
        tvalue2_19: String = "";
        tvalue19: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].StaffMoraleMod));
        if (this.comparenr > -1)
          tvalue2_19 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].StaffMoraleMod));
        this.OptionsList4Obj.add("Staff Mor Mod", -1, tvalue19, tvalue2_19);
        str12 = "";
        tvalue2_20: String = "";
        tvalue20: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].BlowBridgePts));
        if (this.comparenr > -1)
          tvalue2_20 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].BlowBridgePts));
        this.OptionsList4Obj.add("Blow Pts", -1, tvalue20, tvalue2_20);
        str12 = "";
        tvalue2_21: String = "";
        tvalue21: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].AntiSupply));
        if (this.comparenr > -1)
          tvalue2_21 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].AntiSupply));
        this.OptionsList4Obj.add("AntiSup Pts Land", -1, tvalue21, tvalue2_21);
        str12 = "";
        tvalue2_22: String = "";
        tvalue22: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].AntiSupplySea));
        if (this.comparenr > -1)
          tvalue2_22 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].AntiSupplySea));
        this.OptionsList4Obj.add("AntiSup Pts Sea", -1, tvalue22, tvalue2_22);
        str12 = "";
        tvalue2_23: String = "";
        tvalue23: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].AntiSupplyRange));
        if (this.comparenr > -1)
          tvalue2_23 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].AntiSupplyRange));
        this.OptionsList4Obj.add("AntiSup Range", -1, tvalue23, tvalue2_23);
        str12 = "";
        tvalue2_24: String = "";
        tvalue24: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].ConsiderCarry));
        if (this.comparenr > -1)
          tvalue2_24 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].ConsiderCarry));
        this.OptionsList4Obj.add("Consider Carry", -1, tvalue24, tvalue2_24);
        str12 = "";
        tvalue2_25: String = "";
        tvalue25: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].AirCarrierCap));
        if (this.comparenr > -1)
          tvalue2_25 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].AirCarrierCap));
        this.OptionsList4Obj.add("Aircar.CarryCap", -1, tvalue25, tvalue2_25);
        str12 = "";
        tvalue2_26: String = "";
        tvalue26: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].ApMod));
        if (this.comparenr > -1)
          tvalue2_26 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].ApMod));
        this.OptionsList4Obj.add("AP Mod", -1, tvalue26, tvalue2_26);
        str12 = "";
        tvalue2_27: String = "";
        tvalue27: String = !(this.game.Data.SFTypeObj[sftyp3].FuelRegimeVar > 0 & this.game.Data.SFTypeObj[sftyp3].FuelForMove + this.game.Data.SFTypeObj[sftyp3].FuelForAttack + this.game.Data.SFTypeObj[sftyp3].FuelForAttackDef > 0) ? "None" : Strings.Trim(this.game.Data.RegimeSlotName[this.game.Data.SFTypeObj[sftyp3].FuelRegimeVar]);
        if (this.comparenr > -1)
          tvalue2_27 = !(this.game.Data.SFTypeObj[this.comparenr].FuelRegimeVar >= 0 & this.game.Data.SFTypeObj[this.comparenr].FuelForMove + this.game.Data.SFTypeObj[this.comparenr].FuelForAttack + this.game.Data.SFTypeObj[this.comparenr].FuelForAttackDef > 0) ? "None" : Strings.Trim(this.game.Data.RegimeSlotName[this.game.Data.SFTypeObj[this.comparenr].FuelRegimeVar]);
        this.OptionsList4Obj.add("Fuel Type", -1, tvalue27, tvalue2_27);
        str12 = "";
        tvalue2_28: String = "";
        tvalue28: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].FuelForMove));
        if (this.comparenr > -1)
          tvalue2_28 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].FuelForMove));
        this.OptionsList4Obj.add("Fuel for Move", -1, tvalue28, tvalue2_28);
        str12 = "";
        tvalue2_29: String = "";
        tvalue29: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].FuelForAttack));
        if (this.comparenr > -1)
          tvalue2_29 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].FuelForAttack));
        this.OptionsList4Obj.add("Fuel for Attack", -1, tvalue29, tvalue2_29);
        str12 = "";
        tvalue2_30: String = "";
        tvalue30: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].FuelForAttackDef));
        if (this.comparenr > -1)
          tvalue2_30 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].FuelForAttackDef));
        this.OptionsList4Obj.add("Fuel for Defense", -1, tvalue30, tvalue2_30);
        str12 = "";
        tvalue2_31: String = "";
        tvalue31: String = "* " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].OutOfFuelAttack));
        if (this.comparenr > -1)
          tvalue2_31 = "* " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].OutOfFuelAttack));
        this.OptionsList4Obj.add("Out of fuel Att", -1, tvalue31, tvalue2_31);
        str12 = "";
        tvalue2_32: String = "";
        tvalue32: String = "* " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].OutOfFuelDefense));
        if (this.comparenr > -1)
          tvalue2_32 = "* " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].OutOfFuelDefense));
        this.OptionsList4Obj.add("Out of fuel Def", -1, tvalue32, tvalue2_32);
        str12 = "";
        tvalue2_33: String = "";
        tvalue33: String = "/ " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].OutOfFuelMove));
        if (this.comparenr > -1)
          tvalue2_33 = "/ " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].OutOfFuelMove));
        this.OptionsList4Obj.add("Out of fuel Mov", -1, tvalue33, tvalue2_33);
        str12 = "";
        tvalue2_34: String = "";
        tvalue34: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp3].AntiStrucPts));
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
          let mut tsubpart19: SubPartClass =  new ATListSubPartClass(this.OptionsList4Obj, 16, 330, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 230, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: num15, bby: num16);
          this.OptionsList4Id = this.AddSubPart( tsubpart19, num15, num16, 330, 272, 0);
        }
      }
      let mut sftyp4: i32 = this.sftyp;
      if (this.StatMode == 2 & sftyp4 > -1)
      {
        let mut num17: i32 = 150;
        let mut num18: i32 = 385;
        this.OptionsList3Obj = ATListClass::new();
        str12 = "";
        tvalue2_35: String = "";
        tvalue35: String = Conversions.ToString(this.game.Data.SFTypeObj[sftyp4].Initiative);
        if (this.comparenr > -1)
          tvalue2_35 = Conversions.ToString(this.game.Data.SFTypeObj[this.comparenr].Initiative);
        this.OptionsList3Obj.add("Initiative Att", -1, tvalue35, tvalue2_35);
        str12 = "";
        tvalue2_36: String = "";
        tvalue36: String = Conversions.ToString(this.game.Data.SFTypeObj[sftyp4].InitiativeDef);
        if (this.comparenr > -1)
          tvalue2_36 = Conversions.ToString(this.game.Data.SFTypeObj[this.comparenr].InitiativeDef);
        this.OptionsList3Obj.add("Initiative Def", -1, tvalue36, tvalue2_36);
        str12 = "";
        tvalue2_37: String = "";
        tvalue37: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].Attacks));
        if (this.comparenr > -1)
          tvalue2_37 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].Attacks));
        this.OptionsList3Obj.add("Attacks", -1, tvalue37, tvalue2_37);
        str12 = "";
        tvalue2_38: String = "";
        tvalue38: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].MaxAttacked));
        if (this.comparenr > -1)
          tvalue2_38 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].MaxAttacked));
        this.OptionsList3Obj.add("Max Attacked", -1, tvalue38, tvalue2_38);
        str12 = "";
        tvalue2_39: String = "";
        tvalue39: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].Frontage));
        if (this.comparenr > -1)
          tvalue2_39 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].Frontage));
        this.OptionsList3Obj.add("Stack Pts", -1, tvalue39, tvalue2_39);
        str12 = "";
        tvalue2_40: String = "";
        tvalue40: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].BackBench));
        if (this.comparenr > -1)
          tvalue2_40 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].BackBench));
        this.OptionsList3Obj.add("Rear Area", -1, tvalue40, tvalue2_40);
        str12 = "";
        tvalue2_41: String = "";
        tvalue41: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].ArtRange));
        if (this.comparenr > -1)
          tvalue2_41 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].ArtRange));
        this.OptionsList3Obj.add("Art Range", -1, tvalue41, tvalue2_41);
        str12 = "";
        tvalue2_42: String = "";
        tvalue42: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].FavTargetTries));
        if (this.comparenr > -1)
          tvalue2_42 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].FavTargetTries));
        this.OptionsList3Obj.add("Fav.Target.Tries", -1, tvalue42, tvalue2_42);
        str12 = "";
        tvalue2_43: String = "";
        tvalue43: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].AARange));
        if (this.comparenr > -1)
          tvalue2_43 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].AARange));
        this.OptionsList3Obj.add("AA Range", -1, tvalue43, tvalue2_43);
        str12 = "";
        tvalue2_44: String = "";
        tvalue44: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].KillPercent));
        let mut index27: i32 = sftyp4;
        if (this.game.Data.SFTypeObj[index27].ArtSFType > -1)
        {
          let mut artSfType: i32 = this.game.Data.SFTypeObj[index27].ArtSFType;
          tvalue44 = tvalue44 + " (" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[artSfType].KillPercent)) + ")";
        }
        else if (this.game.Data.SFTypeObj[index27].ArtRange > 0)
          tvalue44 = tvalue44 + " (" + tvalue44 + ")";
        if (this.comparenr > -1)
        {
          tvalue2_44 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].KillPercent));
          let mut comparenr: i32 = this.comparenr;
          if (this.game.Data.SFTypeObj[comparenr].ArtSFType > -1)
          {
            let mut artSfType: i32 = this.game.Data.SFTypeObj[comparenr].ArtSFType;
            tvalue2_44 = tvalue2_44 + " (" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[artSfType].KillPercent)) + ")";
          }
          else if (this.game.Data.SFTypeObj[comparenr].ArtRange > 0)
            tvalue2_44 = tvalue2_44 + " (" + tvalue2_44 + ")";
        }
        this.OptionsList3Obj.add("Hit->Kill%", -1, tvalue44, tvalue2_44);
        str12 = "";
        tvalue2_45: String = "";
        tvalue45: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].RetreatPercent));
        let mut index28: i32 = sftyp4;
        if (this.game.Data.SFTypeObj[index28].ArtSFType > -1)
        {
          let mut artSfType: i32 = this.game.Data.SFTypeObj[index28].ArtSFType;
          tvalue45 = tvalue45 + " (" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[artSfType].RetreatPercent)) + ")";
        }
        else if (this.game.Data.SFTypeObj[index28].ArtRange > 0)
          tvalue45 = tvalue45 + " (" + tvalue45 + ")";
        if (this.comparenr > -1)
        {
          tvalue2_45 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].RetreatPercent));
          let mut comparenr: i32 = this.comparenr;
          if (this.game.Data.SFTypeObj[comparenr].ArtSFType > -1)
          {
            let mut artSfType: i32 = this.game.Data.SFTypeObj[comparenr].ArtSFType;
            tvalue2_45 = tvalue2_45 + " (" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[artSfType].RetreatPercent)) + ")";
          }
          else if (this.game.Data.SFTypeObj[comparenr].ArtRange > 0)
            tvalue2_45 = tvalue2_45 + " (" + tvalue2_45 + ")";
        }
        this.OptionsList3Obj.add("Hit->Retreat%", -1, tvalue45, tvalue2_45);
        str12 = "";
        tvalue2_46: String = "";
        tvalue46: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].FirstRoundPenaltyMod));
        if (this.comparenr > -1)
          tvalue2_46 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].FirstRoundPenaltyMod));
        this.OptionsList3Obj.add("1stRnd pen.mod", -1, tvalue46, tvalue2_46);
        str12 = "";
        tvalue2_47: String = "";
        tvalue47: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].EntrenchPower));
        if (this.comparenr > -1)
          tvalue2_47 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].EntrenchPower));
        this.OptionsList3Obj.add("Entrench Pow", -1, tvalue47, tvalue2_47);
        str12 = "";
        tvalue2_48: String = "";
        tvalue48: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].PowerPts));
        if (this.comparenr > -1)
          tvalue2_48 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].PowerPts));
        this.OptionsList3Obj.add("Power Points", -1, tvalue48, tvalue2_48);
        str12 = "";
        tvalue2_49: String = "";
        tvalue49: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].RdnLossPerAttack));
        if (this.comparenr > -1)
          tvalue2_49 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].RdnLossPerAttack));
        this.OptionsList3Obj.add("RdnLos.p.attack", -1, tvalue49, tvalue2_49);
        str12 = "";
        tvalue2_50: String = "";
        tvalue50: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].AutoDestroy)) + "/" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].AutoDestroy2));
        if (this.comparenr > -1)
          tvalue2_50 = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].AutoDestroy)) + "/" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].AutoDestroy));
        this.OptionsList3Obj.add("AutoDestroy", -1, tvalue50, tvalue2_50);
        str12 = "";
        tvalue2_51: String = "";
        tvalue51: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp4].KilltoRetreatChance));
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
          let mut tsubpart20: SubPartClass =  new ATListSubPartClass(this.OptionsList3Obj, 17, 250, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 150, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: num17, bby: num18);
          this.OptionsList3Id = this.AddSubPart( tsubpart20, num17, num18, 300, 288, 0);
        }
        this.combatListObj = ATListClass::new();
        let mut index29: i32 = sftyp4;
        SimpleList simpleList1 = SimpleList::new();
        let mut tid1: i32 = 0;
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
          tid1 += 1;
        }
        while (tid1 <= 99);
        simpleList1.Sort();
        let mut Number1: i32 = 0;
        let mut num19: i32 = 9999999;
        if (this.comparenr > -1)
          this.combatListObj.add("TARGET GROUP", -1, "ATT", "HP", "ATT", "HP");
        else
          this.combatListObj.add("TARGET GROUP", -1, "ATT", "HP");
        for (let mut counter: i32 = simpleList1.Counter; counter >= 0; counter += -1)
        {
          str12 = "";
          if (simpleList1.Weight[counter] < num19 - 99)
          {
            Number1 += 1;
            num19 = simpleList1.Weight[counter];
          }
          tname: String = Strings.Trim(Conversion.Str((object) Number1)) + ". " + this.game.Data.TempString[400 + simpleList1.Id[counter]];
          tvalue52: String = Strings.Trim(Conversion.Str((object) (this.game.Data.SFTypeObj[index29].AttackPower[simpleList1.Id[counter]] * this.game.Data.SFTypeObj[index29].Attacks))) + "/" + Strings.Trim(Conversion.Str((object) (this.game.Data.SFTypeObj[index29].AttackPowerDef[simpleList1.Id[counter]] * this.game.Data.SFTypeObj[index29].Attacks)));
          tvalue2_52: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[index29].HitPoints[simpleList1.Id[counter]])) + "/" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[index29].HitPointsDef[simpleList1.Id[counter]]));
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
        let mut num20: i32 = 450;
        let mut num21: i32 = 385;
        if (this.combatListId > 0)
        {
          this.SubPartList[this.SubpartNr(this.combatListId)].Refresh(this.combatListObj, -1);
          this.SubPartFlag[this.SubpartNr(this.combatListId)] = true;
        }
        else if (this.game.Data.SFTypeObj[index29].ArtRange > 0)
        {
          let mut tsubpart21: SubPartClass =  new ATListSubPartClass(this.combatListObj, 8, 430, -1, this.game, true, "AttackPoints / Hitpoints", tShowPair: true, tValueWidth: 300, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: num20, bby: num21);
          this.combatListId = this.AddSubPart( tsubpart21, num20, num21, 380, 144, 0);
        }
        else
        {
          let mut tsubpart22: SubPartClass =  new ATListSubPartClass(this.combatListObj, 8, 430, -1, this.game, true, "AttackPoints / Hitpoints", tShowPair: true, tValueWidth: 300, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: num20, bby: num21);
          this.combatListId = this.AddSubPart( tsubpart22, num20, num21, 380, 144, 0);
        }
        this.combatList2Obj = ATListClass::new();
        let mut index30: i32 = sftyp4;
        if (this.game.Data.SFTypeObj[sftyp4].ArtRange > 0)
        {
          SimpleList simpleList2 = SimpleList::new();
          let mut tid2: i32 = 0;
          do
          {
            if (this.game.Data.SFTypeObj[index30].FavArtTarget[tid2] > 0)
              simpleList2.Add(tid2, 1000 * this.game.Data.SFTypeObj[index30].FavArtTarget[tid2] - tid2);
            else if (this.comparenr > -1 && this.game.Data.SFTypeObj[this.comparenr].FavArtTarget[tid2] > 0)
              simpleList2.Add(tid2, 100 * this.game.Data.SFTypeObj[this.comparenr].FavArtTarget[tid2] - 9999 - tid2);
            tid2 += 1;
          }
          while (tid2 <= 99);
          simpleList2.Sort();
          if (this.comparenr > -1)
            this.combatList2Obj.add("ARTILLERY TARGET GROUP", -1, "ART ATT", "ART ATT");
          else
            this.combatList2Obj.add("ARTILLERY TARGET GROUP", -1, "ART ATT");
          let mut Number2: i32 = 0;
          let mut num22: i32 = -1;
          for (let mut counter: i32 = simpleList2.Counter; counter >= 0; counter += -1)
          {
            str12 = "";
            if (simpleList2.Weight[counter] > num22 - 99)
            {
              Number2 += 1;
              num22 = simpleList2.Weight[counter];
            }
            tname: String = Strings.Trim(Conversion.Str((object) Number2)) + ". " + this.game.Data.TempString[400 + simpleList2.Id[counter]];
            tvalue53: String = Strings.Trim(Conversion.Str((object) (Conversions.ToInteger(this.game.Data.SFTypeObj[index30].AttackArt[simpleList2.Id[counter]]) * this.game.Data.SFTypeObj[index30].Attacks)));
            if (this.comparenr > -1)
            {
              tvalue2_53: String = Strings.Trim(Conversion.Str((object) (Conversions.ToInteger(this.game.Data.SFTypeObj[this.comparenr].AttackArt[simpleList2.Id[counter]]) * this.game.Data.SFTypeObj[this.comparenr].Attacks)));
              this.combatList2Obj.add(tname, counter, tvalue53, tvalue2_53);
            }
            else
              this.combatList2Obj.add(tname, counter, tvalue53);
          }
          let mut num23: i32 = 450;
          let mut num24: i32 = 540;
          if (this.combatList2Id > 0)
          {
            this.SubPartList[this.SubpartNr(this.combatList2Id)].Refresh(this.combatList2Obj, -1);
            this.SubPartFlag[this.SubpartNr(this.combatList2Id)] = true;
          }
          else
          {
            let mut tsubpart23: SubPartClass =  new ATListSubPartClass(this.combatList2Obj, 8, 430, -1, this.game, true, "AttackPoints / Hitpoints", tShowPair: true, tValueWidth: 220, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: num23, bby: num24);
            this.combatList2Id = this.AddSubPart( tsubpart23, num23, num24, 380, 144, 0);
          }
        }
      }
      if (this.StatMode == 3)
      {
        this.OptionsListObj = ATListClass::new();
        this.OptionsList4Obj = ATListClass::new();
        this.OptionsList3Obj = ATListClass::new();
        let mut index31: i32 = sftyp4;
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
        let mut landscapeTypeCounter1: i32 = this.game.Data.LandscapeTypeCounter;
        for (let mut tdata: i32 = 0; tdata <= landscapeTypeCounter1; tdata += 1)
        {
          str12 = "";
          name: String = this.game.Data.LandscapeTypeObj[tdata].Name;
          let mut num25: i32 = this.game.Data.LandscapeTypeObj[tdata].MoveCost[this.game.Data.SFTypeObj[index31].MoveType];
          tvalue: String = Strings.Trim(Conversion.Str((object)  Math.Round((double)  Math.Round((double) num25 - Conversion.Int((double) num25 * ((double) this.game.Data.SFTypeObj[index31].MoveRedux / 100.0))) * ((double) this.game.Data.MoveTypePenalty[this.game.Data.SFTypeObj[index31].MoveType] / 100.0)))) + "ap";
          tvalue2: String = Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[tdata].DefBonus[this.game.Data.SFTypeObj[index31].UnitGroup])) + "-" + Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[tdata].DefBonusMax[this.game.Data.SFTypeObj[index31].UnitGroup]));
          if (this.comparenr > -1)
          {
            let mut num26: i32 = this.game.Data.LandscapeTypeObj[tdata].MoveCost[this.game.Data.SFTypeObj[this.comparenr].MoveType];
            tvalue3: String = Strings.Trim(Conversion.Str((object)  Math.Round((double)  Math.Round((double) num26 - Conversion.Int((double) num26 * ((double) this.game.Data.SFTypeObj[this.comparenr].MoveRedux / 100.0))) * ((double) this.game.Data.MoveTypePenalty[this.game.Data.SFTypeObj[this.comparenr].MoveType] / 100.0)))) + "ap";
            tvalue4: String = Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[tdata].DefBonus[this.game.Data.SFTypeObj[this.comparenr].UnitGroup])) + "-" + Strings.Trim(Conversion.Str((object) this.game.Data.LandscapeTypeObj[tdata].DefBonusMax[this.game.Data.SFTypeObj[this.comparenr].UnitGroup]));
            this.OptionsListObj.add(name, tdata, tvalue, tvalue2, tvalue3, tvalue4);
          }
          else
            this.OptionsListObj.add(name, tdata, tvalue, tvalue2);
        }
        let mut roadTypeCounter: i32 = this.game.Data.RoadTypeCounter;
        string str13;
        string str14;
        for (let mut index32: i32 = 0; index32 <= roadTypeCounter; index32 += 1)
        {
          name: String = this.game.Data.RoadTypeObj[index32].Name;
          let mut num27: i32 = this.game.Data.RoadTypeObj[index32].MoveCostOverrule[this.game.Data.SFTypeObj[index31].MoveType];
          tvalue: String = Strings.Trim(Conversion.Str((object)  Math.Round((double)  Math.Round((double) num27 - Conversion.Int((double) num27 * ((double) this.game.Data.SFTypeObj[index31].MoveRedux / 100.0))) * ((double) this.game.Data.MoveTypePenalty[this.game.Data.SFTypeObj[index31].MoveType] / 100.0)))) + "ap";
          str13 = "-";
          if (this.comparenr > -1)
          {
            let mut num28: i32 = this.game.Data.RoadTypeObj[index32].MoveCostOverrule[this.game.Data.SFTypeObj[this.comparenr].MoveType];
            tvalue2: String = Strings.Trim(Conversion.Str((object)  Math.Round((double)  Math.Round((double) num28 - Conversion.Int((double) num28 * ((double) this.game.Data.SFTypeObj[this.comparenr].MoveRedux / 100.0))) * ((double) this.game.Data.MoveTypePenalty[this.game.Data.SFTypeObj[this.comparenr].MoveType] / 100.0)))) + "ap";
            str14 = "-";
            this.OptionsList4Obj.add(name, 1000 + index32, tvalue, tvalue2);
          }
          else
            this.OptionsList4Obj.add(name, 1000 + index32, tvalue);
        }
        let mut riverTypeCounter1: i32 = this.game.Data.RiverTypeCounter;
        for (let mut index33: i32 = 0; index33 <= riverTypeCounter1; index33 += 1)
        {
          name: String = this.game.Data.RiverTypeObj[index33].Name;
          let mut Number3: i32 = this.game.Data.RiverTypeObj[index33].MovePenalty[this.game.Data.SFTypeObj[index31].MoveType];
          str15: String = "";
          if (Number3 > 0)
            str15 = "+";
          tvalue: String = str15 + Strings.Trim(Conversion.Str((object) Number3)) + "ap";
          str13 = "-";
          if (this.comparenr > -1)
          {
            let mut Number4: i32 = this.game.Data.RiverTypeObj[index33].MovePenalty[this.game.Data.SFTypeObj[this.comparenr].MoveType];
            str16: String = "";
            if (Number4 > 0)
              str16 = "+";
            tvalue2: String = str16 + Strings.Trim(Conversion.Str((object) Number4)) + "ap";
            str14 = "-";
            this.OptionsList3Obj.add(name, 2000 + index33, tvalue, tvalue2);
          }
          else
            this.OptionsList3Obj.add(name, 2000 + index33, tvalue);
        }
        let mut num29: i32 = 110;
        let mut num30: i32 = 385;
        if (this.OptionsListId > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
        }
        else
        {
          let mut tsubpart24: SubPartClass =  new ATListSubPartClass(this.OptionsListObj, 9, 400, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 260, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: num29, bby: num30);
          this.OptionsListId = this.AddSubPart( tsubpart24, num29, num30, 400, 160, 0);
        }
        let mut num31: i32 = num30 + 170;
        if (this.OptionsList4Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList4Id)].Refresh(this.OptionsList4Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList4Id)] = true;
        }
        else
        {
          let mut tsubpart25: SubPartClass =  new ATListSubPartClass(this.OptionsList4Obj, 3, 400, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 260, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: num29, bby: num31);
          this.OptionsList4Id = this.AddSubPart( tsubpart25, num29, num31, 400, 64, 0);
        }
        let mut num32: i32 = num31 + 74;
        if (this.OptionsList3Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
        }
        else
        {
          let mut tsubpart26: SubPartClass =  new ATListSubPartClass(this.OptionsList3Obj, 3, 400, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 260, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: num29, bby: num32);
          this.OptionsList3Id = this.AddSubPart( tsubpart26, num29, num32, 400, 64, 0);
        }
        this.OptionsList6Obj = ATListClass::new();
        this.combatList2Obj = ATListClass::new();
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
        let mut landscapeTypeCounter2: i32 = this.game.Data.LandscapeTypeCounter;
        for (let mut tdata: i32 = 0; tdata <= landscapeTypeCounter2; tdata += 1)
        {
          str12 = "";
          name: String = this.game.Data.LandscapeTypeObj[tdata].Name;
          let mut Number5: i32 =  Math.Round((double) (Conversion.Int(this.game.Data.SFTypeObj[sftyp4].CombatModAtt[tdata] * 100f) - 100f));
          tvalue: String = Number5 != 0 ? Strings.Trim(Conversion.Str((object) Number5)) + "%" : "-";
          let mut artSfType1: i32 = this.game.Data.SFTypeObj[sftyp4].ArtSFType;
          if (artSfType1 > -1)
          {
            let mut Number6: i32 =  Math.Round((double) (Conversion.Int(this.game.Data.SFTypeObj[artSfType1].CombatModAtt[tdata] * 100f) - 100f));
            tvalue = Number6 != 0 ? tvalue + " (" + Strings.Trim(Conversion.Str((object) Number6)) + "%)" : tvalue + " (-)";
          }
          let mut Number7: i32 =  Math.Round((double) (Conversion.Int(this.game.Data.SFTypeObj[sftyp4].CombatModDef[tdata] * 100f) - 100f));
          tvalue2: String = Number7 != 0 ? Strings.Trim(Conversion.Str((object) Number7)) + "%" : "-";
          let mut artSfType2: i32 = this.game.Data.SFTypeObj[sftyp4].ArtSFType;
          if (artSfType2 > -1)
          {
            let mut Number8: i32 =  Math.Round((double) (Conversion.Int(this.game.Data.SFTypeObj[artSfType2].CombatModDef[tdata] * 100f) - 100f));
            tvalue2 = Number8 != 0 ? tvalue2 + " (" + Strings.Trim(Conversion.Str((object) Number8)) + "%)" : tvalue2 + " (-)";
          }
          if (this.comparenr > -1)
          {
            let mut Number9: i32 =  Math.Round((double) (Conversion.Int(this.game.Data.SFTypeObj[this.comparenr].CombatModAtt[tdata] * 100f) - 100f));
            tvalue3: String = Number9 != 0 ? Strings.Trim(Conversion.Str((object) Number9)) + "%" : "-";
            let mut artSfType3: i32 = this.game.Data.SFTypeObj[this.comparenr].ArtSFType;
            if (artSfType3 > -1)
            {
              let mut Number10: i32 =  Math.Round((double) (Conversion.Int(this.game.Data.SFTypeObj[artSfType3].CombatModAtt[tdata] * 100f) - 100f));
              tvalue3 = Number10 != 0 ? tvalue3 + " (" + Strings.Trim(Conversion.Str((object) Number10)) + "%)" : tvalue3 + " (-)";
            }
            let mut Number11: i32 =  Math.Round((double) (Conversion.Int(this.game.Data.SFTypeObj[this.comparenr].CombatModDef[tdata] * 100f) - 100f));
            tvalue4: String = Number11 != 0 ? Strings.Trim(Conversion.Str((object) Number11)) + "%" : "-";
            let mut artSfType4: i32 = this.game.Data.SFTypeObj[this.comparenr].ArtSFType;
            if (artSfType4 > -1)
            {
              let mut Number12: i32 =  Math.Round((double) (Conversion.Int(this.game.Data.SFTypeObj[artSfType4].CombatModDef[tdata] * 100f) - 100f));
              tvalue4 = Number12 != 0 ? tvalue4 + " (" + Strings.Trim(Conversion.Str((object) Number12)) + "%)" : tvalue4 + " (-)";
            }
            this.OptionsList6Obj.add(name, tdata, tvalue, tvalue2, tvalue3, tvalue4);
          }
          else
            this.OptionsList6Obj.add(name, tdata, tvalue, tvalue2);
        }
        let mut riverTypeCounter2: i32 = this.game.Data.RiverTypeCounter;
        for (let mut index34: i32 = 0; index34 <= riverTypeCounter2; index34 += 1)
        {
          name: String = this.game.Data.RiverTypeObj[index34].Name;
          let mut Number13: i32 =  Math.Round((double) Conversion.Int(this.game.Data.RiverTypeObj[index34].AttackPenalty[this.game.Data.SFTypeObj[sftyp4].UnitGroup] * 100f));
          tvalue: String = Number13 <= 0 ? "-" : "-" + Strings.Trim(Conversion.Str((object) Number13)) + "%";
          tvalue2: String = "-";
          if (this.comparenr > -1)
          {
            let mut Number14: i32 =  Math.Round((double) Conversion.Int(this.game.Data.RiverTypeObj[index34].AttackPenalty[this.game.Data.SFTypeObj[this.comparenr].UnitGroup] * 100f));
            tvalue3: String = Number14 <= 0 ? "-" : "-" + Strings.Trim(Conversion.Str((object) Number14)) + "%";
            tvalue4: String = "-";
            this.combatList2Obj.add(name, 2000 + index34, tvalue, tvalue2, tvalue3, tvalue4);
          }
          else
            this.combatList2Obj.add(name, 2000 + index34, tvalue, tvalue2);
        }
        let mut num33: i32 = 520;
        let mut num34: i32 = 385;
        if (this.OptionsList6Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList6Id)].Refresh(this.OptionsList6Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList6Id)] = true;
        }
        else
        {
          let mut tsubpart27: SubPartClass =  new ATListSubPartClass(this.OptionsList6Obj, 13, 400, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 260, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: num33, bby: num34);
          this.OptionsList6Id = this.AddSubPart( tsubpart27, num33, num34, 400, 224, 0);
        }
        let mut num35: i32 = 520;
        let mut num36: i32 = num34 + 244;
        if (this.combatList2Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.combatList2Id)].Refresh(this.combatList2Obj, -1);
          this.SubPartFlag[this.SubpartNr(this.combatList2Id)] = true;
        }
        else
        {
          let mut tsubpart28: SubPartClass =  new ATListSubPartClass(this.combatList2Obj, 3, 400, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 260, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: num35, bby: num36);
          this.combatList2Id = this.AddSubPart( tsubpart28, num35, num36, 400, 64, 0);
        }
      }
      if (this.StatMode == 4)
      {
        let mut num37: i32 = 0;
        let mut sftyp5: i32 = this.sftyp;
        let mut num38: i32 = 190;
        let mut num39: i32 = 385;
        this.OptionsListObj = ATListClass::new();
        let mut preventCounter: i32 = this.game.Data.SFTypeObj[sftyp5].PreventCounter;
        for (let mut tdata: i32 = 0; tdata <= preventCounter; tdata += 1)
        {
          if (this.game.Data.SFTypeObj[sftyp5].PreventChance[tdata] > 0)
          {
            num37 += 1;
            if (num37 == 1)
              this.OptionsListObj.add("PREVENT HIT ON", -1, "WHEN ATT BY", "PRIORITY", "CHANCE", "PTS COST");
            str12 = "";
            tname: String = this.game.Data.SFTypeObj[sftyp5].PreventHitOn[tdata] <= -1 ? "ALL" : this.game.Data.TempString[400 + this.game.Data.SFTypeObj[sftyp5].PreventHitOn[tdata]];
            tvalue: String = this.game.Data.SFTypeObj[sftyp5].PreventHitFrom[tdata] <= -1 ? "ALL" : this.game.Data.TempString[400 + this.game.Data.SFTypeObj[sftyp5].PreventHitFrom[tdata]];
            tvalue2: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp5].PreventPriority[tdata]));
            tvalue3: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp5].PreventChance[tdata])) + "%";
            tvalue4: String = Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[sftyp5].PreventPoints[tdata]));
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
            let mut tsubpart29: SubPartClass =  new ATListSubPartClass(this.OptionsListObj, 9, 600, -1, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 460, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: num38, bby: num39);
            this.OptionsListId = this.AddSubPart( tsubpart29, num38, num39, 600, 160, 0);
          }
          num39 += 175;
        }
        let mut x21: i32 = 340;
         let mut local65: &Graphics = &Expression;
        rectangle2 = Rectangle::new(x21, num39, 300, 14);
        let mut rect1_9: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(x21, num39 + 14, 300, 23);
        let mut rect2_9: &Rectangle = &rectangle1
        txt2_8: String = Conversions.ToString(this.game.Data.SFTypeObj[sftyp5].MaxPreventPointsUsed);
        DrawMod.MakeFullBoxVic2( local65, rect1_9, "MAX PREVENT PTS GIVEN TO OTHERS", rect2_9, txt2_8);
        let mut x22: i32 = 340;
        let mut y23: i32 = num39 + 55;
         let mut local66: &Graphics = &Expression;
        rectangle2 = Rectangle::new(x22, y23, 300, 14);
        let mut rect1_10: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(x22, y23 + 14, 300, 23);
        let mut rect2_10: &Rectangle = &rectangle1
        txt2_9: String = Conversions.ToString(this.game.Data.SFTypeObj[sftyp5].MaxPreventPointsGiven);
        DrawMod.MakeFullBoxVic2( local66, rect1_10, "MAX PREVENT PTS RECEIVED BY PREVENTERS", rect2_10, txt2_9);
      }
      if (this.sfnr == -1 & this.sftyp == -1 && this.passenger > -1)
      {
        let mut tsubpart30: SubPartClass =  new UnitHeaderPartClass(this.passenger, this.game);
        this.TempText1 = this.AddSubPart( tsubpart30, 360, 150, 225, 200, 0);
        if (this.game.Data.UnitObj[this.passenger].Historical > -1 & this.game.Data.UnitObj[this.passenger].IsHQ)
        {
          if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.passenger].Historical].CommanderSpriteID > -1)
            ;
        }
        else
        {
          DrawMod.DrawBlock( Expression, 160, 380, 680, 240,  this.game.VicColor4.R,  this.game.VicColor4.G,  this.game.VicColor4.B,  this.game.VicColor4.A);
          DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  Expression, 160, 380, 680, 240, -1, -1);
          let mut tsubpart31: SubPartClass =  new UnitSFPartClass(this.passenger, this.game);
          this.temptext4 = this.AddSubPart( tsubpart31, 190, 400, 620, 200, 0);
        }
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    pub object ReturnSFSpriteNr(int typ, int regnr, int pplnr)
    {
      let mut symbolSpriteId: i32 = this.game.Data.SFTypeObj[typ].SymbolSpriteID;
      if (regnr > -1)
      {
        if (this.game.Data.RegimeObj[regnr].ExtraGraphicUse > -1)
        {
          let mut extraCounter: i32 = this.game.Data.SFTypeObj[typ].ExtraCounter;
          for (let mut index: i32 = 0; index <= extraCounter; index += 1)
          {
            if (this.game.Data.SFTypeObj[typ].ExtraCode[index] == this.game.Data.RegimeObj[regnr].ExtraGraphicUse)
              symbolSpriteId = this.game.Data.SFTypeObj[typ].ExtraSymbolSpriteID[index];
          }
        }
        else if (pplnr > -1 && this.game.Data.PeopleObj[pplnr].ExtraGraphicUse > -1)
        {
          let mut extraCounter: i32 = this.game.Data.SFTypeObj[typ].ExtraCounter;
          for (let mut index: i32 = 0; index <= extraCounter; index += 1)
          {
            if (this.game.Data.SFTypeObj[typ].ExtraCode[index] == this.game.Data.PeopleObj[pplnr].ExtraGraphicUse)
              symbolSpriteId = this.game.Data.SFTypeObj[typ].ExtraSymbolSpriteID[index];
          }
        }
      }
      else if (this.game.Data.PeopleObj[pplnr].ExtraGraphicUse > -1)
      {
        let mut extraCounter: i32 = this.game.Data.SFTypeObj[typ].ExtraCounter;
        for (let mut index: i32 = 0; index <= extraCounter; index += 1)
        {
          if (this.game.Data.SFTypeObj[typ].ExtraCode[index] == this.game.Data.PeopleObj[pplnr].ExtraGraphicUse)
            symbolSpriteId = this.game.Data.SFTypeObj[typ].ExtraSymbolSpriteID[index];
        }
      }
      return (object) symbolSpriteId;
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      try
      {
        if (nr == 27 | nr == 32)
        {
          this.game.EditObj.TempCoordList = CoordList::new();
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

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
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
              this.game.EditObj.TempCoordList = CoordList::new();
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
              Form3::new( this.formref).Initialize(this.game.Data, 74, -1);
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
                  SoundMod.PlayAWave(this.game.AppPath + "sound/disband.wav",  this.game.EditObj);
                OrderResult orderResult = this.game.ProcessingObj.DoDisband(this.game.EditObj.UnitSelected, this.sfnr);
                if (orderResult.OK)
                {
                  if (orderResult.ErrorString.Length > 1)
                  {
                    let mut num3: i32 =  Interaction.MsgBox((object) orderResult.ErrorString, Title: ((object) "Shadow Empire : Planetary Conquest"));
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
                  let mut num4: i32 =  Interaction.MsgBox((object) "You can only upgrade ALL because there is already 8 subformations in unit.");
                  return windowReturnClass;
                }
                OrderResult orderResult = this.game.ProcessingObj.DoUpgrade(this.game.EditObj.UnitSelected, this.sfnr, this.detailnr2, this.HQselect);
                if (this.game.EditObj.SoundOn)
                  SoundMod.PlayAWave(this.game.AppPath + "sound/building.wav",  this.game.EditObj);
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
