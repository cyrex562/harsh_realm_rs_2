// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SFWindowClass3
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsApplication1
{
  pub class SFWindowClass3 : WindowClass
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
     ListClass OptionsListObj;
     int OptionsList2Id;
     ListClass OptionsList2Obj;
     int OptionsList3Id;
     ListClass OptionsList3Obj;
     int OptionsList4Id;
     ListClass OptionsList4Obj;
     int OptionsList5Id;
     ListClass OptionsList5Obj;
     int OptionsList6Id;
     ListClass OptionsList6Obj;
     int combatListId;
     ListClass combatListObj;
     int combatList2Id;
     ListClass combatList2Obj;
     int StatTyp;
     int StatMode;
     int[] ChainHq;
     int HQselect;
     int infoid;

    pub void DoRefresh()
    {
      this.comparenr = this.game.EditObj.SFCompare;
      this.DoStuff();
    }

    pub void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter <= -1)
        return;
      let mut subPartCounter: i32 = this.SubPartCounter;
      for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
      {
        if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
        {
          this.SubPartList[index].DescriptInfo(x - this.SubPartX[index], y - this.SubPartY[index]);
          if (Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
          {
            if (this.SubPartID[index] != this.LogoListId & this.SubPartID[index] != this.logolist3id)
              this.game.EditObj.TipButton = true;
            this.game.EditObj.TipTitle = "";
            this.game.EditObj.TipText = this.SubPartList[index].Descript;
            break;
          }
        }
      }
    }

    pub SFWindowClass3( GameClass tGame)
      : base( tGame, 880, 768, 8)
    {
      this.ChainHq = new int[3];
      this.tempBlink = 0.0f;
      this.sfnr = -1;
      this.comparenr = -1;
      this.game.EditObj.SFCompare = -1;
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
      this.DoStuff();
    }

    pub void DoStuff()
    {
      Color marcCol1 = this.game.MarcCol1;
      Color marcCol2 = this.game.MarcCol2;
      Color c2_1 = Color.FromArgb(200, 40, 25, 15);
      Color c1 = Color.FromArgb(100, 80, 50, 29);
      Color c2_2 = Color.FromArgb(200, 120, 75, 45);
      this.ClearMouse();
      this.NewBackGroundAndClearAll(880, 768, -1);
      Graphics graphics1 = Graphics.FromImage((Image) this.OwnBitmap);
      let mut watermark: i32 = -1;
      int index1;
      if (this.sfnr > -1)
      {
        let mut type: i32 = this.game.Data.SFObj[this.sfnr].Type;
        let mut people: i32 = this.game.Data.SFObj[this.sfnr].People;
        watermark = this.game.Data.SFTypeObj[type].PicSpriteID;
        if (this.game.Data.RegimeObj[index1].ExtraGraphicUse > -1)
        {
          let mut extraCounter: i32 = this.game.Data.SFTypeObj[type].ExtraCounter;
          for (let mut index2: i32 = 0; index2 <= extraCounter; index2 += 1)
          {
            if (this.game.Data.SFTypeObj[type].ExtraCode[index2] == this.game.Data.RegimeObj[index1].ExtraGraphicUse)
              watermark = this.game.Data.SFTypeObj[type].ExtraPicSpriteID[index2];
          }
        }
        else if (people > -1 && this.game.Data.PeopleObj[people].ExtraGraphicUse > -1)
        {
          let mut extraCounter: i32 = this.game.Data.SFTypeObj[type].ExtraCounter;
          for (let mut index3: i32 = 0; index3 <= extraCounter; index3 += 1)
          {
            if (this.game.Data.SFTypeObj[type].ExtraCode[index3] == this.game.Data.PeopleObj[people].ExtraGraphicUse)
              watermark = this.game.Data.SFTypeObj[type].ExtraPicSpriteID[index3];
          }
        }
      }
      DrawMod.DrawMessFrame( this.OwnBitmap,  graphics1, 0, 0, 880, 768, watermark);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
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
      if (this.but7id > 0)
        this.RemoveSubPart(this.but7id);
      if (this.but7textid > 0)
        this.RemoveSubPart(this.but7textid);
      if (this.descid > 0)
        this.RemoveSubPart(this.descid);
      let mut typ: i32 = this.sftyp;
      let mut pplnr: i32 = this.game.Data.Turn <= -1 ? 0 : this.game.Data.RegimeObj[this.game.Data.Turn].People;
      str1: String = "";
      if (this.sfnr > -1)
      {
        typ = this.game.Data.SFObj[this.sfnr].Type;
        pplnr = this.game.Data.SFObj[this.sfnr].People;
        if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn)
        {
          str1 = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Qty)) + "x ";
          if (this.game.Data.SFTypeObj[typ].Ratio > 1)
            str1 = str1 + " " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[typ].Ratio)) + "x ";
        }
      }
      string str2;
      int regnr;
      int num1;
      int num2;
      int num3;
      Rectangle rectangle1;
      if (typ > -1)
      {
        name: String = this.game.Data.SFTypeObj[typ].Name;
        if (this.game.Data.RegimeObj[index1].ExtraGraphicUse > -1)
        {
          let mut extraCounter: i32 = this.game.Data.SFTypeObj[typ].ExtraCounter;
          for (let mut index4: i32 = 0; index4 <= extraCounter; index4 += 1)
          {
            if (this.game.Data.SFTypeObj[typ].ExtraCode[index4] == this.game.Data.RegimeObj[index1].ExtraGraphicUse)
            {
              int index5;
              name = this.game.Data.SFTypeObj[index5].ExtraName[index4];
            }
          }
        }
        else if (pplnr > -1 & this.sfnr > -1 && this.game.Data.PeopleObj[this.game.Data.SFObj[this.sfnr].People].ExtraGraphicUse > -1)
        {
          let mut extraCounter: i32 = this.game.Data.SFTypeObj[typ].ExtraCounter;
          for (let mut index6: i32 = 0; index6 <= extraCounter; index6 += 1)
          {
            if (this.game.Data.SFTypeObj[typ].ExtraCode[index6] == this.game.Data.PeopleObj[pplnr].ExtraGraphicUse)
              name = this.game.Data.SFTypeObj[typ].ExtraName[index6];
          }
        }
        str2 = str1 + name;
        SizeF sizeF = SizeF::new();
        index1 = 0;
        regnr = this.sfnr <= -1 ? this.game.Data.Turn : this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime;
        num1 = this.game.Data.SFTypeObj[typ].PicSpriteID;
        if (this.game.Data.RegimeObj[regnr].ExtraGraphicUse > -1)
        {
          let mut extraCounter: i32 = this.game.Data.SFTypeObj[typ].ExtraCounter;
          for (let mut index7: i32 = 0; index7 <= extraCounter; index7 += 1)
          {
            if (this.game.Data.SFTypeObj[typ].ExtraCode[index7] == this.game.Data.RegimeObj[regnr].ExtraGraphicUse)
              num1 = this.game.Data.SFTypeObj[typ].ExtraPicSpriteID[index7];
          }
        }
        else if (pplnr > -1 && this.game.Data.PeopleObj[pplnr].ExtraGraphicUse > -1)
        {
          let mut extraCounter: i32 = this.game.Data.SFTypeObj[typ].ExtraCounter;
          for (let mut index8: i32 = 0; index8 <= extraCounter; index8 += 1)
          {
            if (this.game.Data.SFTypeObj[typ].ExtraCode[index8] == this.game.Data.PeopleObj[pplnr].ExtraGraphicUse)
              num1 = this.game.Data.SFTypeObj[typ].ExtraPicSpriteID[index8];
          }
        }
        if (typ > -1)
        {
          num2 = 540;
          let mut num4: i32 = 20;
          if (this.comparenr > -1)
          {
            num2 = 160;
            num3 = 450;
          }
          if (this.comparenr > -1)
          {
            let mut sidewaysSpriteId1: i32 = this.game.Data.SFTypeObj[typ].SidewaysSpriteID;
            DrawMod.DrawBlockGradient2( graphics1, num2 + 60, num4, 139, 79, c1, c2_2);
             let mut local1: &Graphics = &graphics1;
            Bitmap bitmap1 = BitmapStore.GetBitmap(sidewaysSpriteId1);
             let mut local2: &Bitmap = &bitmap1;
            let mut sftypenr: i32 = typ;
            let mut ppl1: i32 = pplnr;
            let mut tx1: i32 = num2 + 60;
            let mut ty1: i32 = num4;
            DrawMod.DrawWithArtCode( local1,  local2, 420, 240, sftypenr, ppl1, tx1, ty1, 140, 80);
            DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  graphics1, num2 + 60, num4, 140, 80, -1, -1);
            let mut sidewaysSpriteId2: i32 = this.game.Data.SFTypeObj[this.comparenr].SidewaysSpriteID;
            DrawMod.DrawBlockGradient2( graphics1, num3 + 60, num4, 139, 79, c1, c2_2);
             let mut local3: &Graphics = &graphics1;
            Bitmap bitmap2 = BitmapStore.GetBitmap(sidewaysSpriteId2);
             let mut local4: &Bitmap = &bitmap2;
            let mut comparenr: i32 = this.comparenr;
            let mut ppl2: i32 = pplnr;
            let mut tx2: i32 = num3 + 60;
            let mut ty2: i32 = num4;
            DrawMod.DrawWithArtCode( local3,  local4, 420, 240, comparenr, ppl2, tx2, ty2, 140, 80);
            DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  graphics1, num3 + 60, num4, 140, 80, -1, -1);
          }
          else if (this.comparenr == -1)
          {
            let mut sidewaysSpriteId: i32 = this.game.Data.SFTypeObj[typ].SidewaysSpriteID;
            if (this.game.Data.SFTypeObj[typ].Theater == 0 || this.game.Data.SFTypeObj[typ].Theater == 1 || this.game.Data.SFTypeObj[typ].Theater != 2)
              ;
            let mut num5: i32 = 74;
            let mut num6: i32 = 36;
            Rectangle rectangle2;
            if (this.game.SelectX > -1 & this.sfnr > -1 & this.game.SelectY > -1)
            {
              let mut landscapeType: i32 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType;
              let mut newGfxSkyEventPic: i32 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxSkyEventPic;
              let mut newGfxSkyX: i32 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxSkyX;
              let mut newGfxSkyY: i32 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxSkyY;
              if (newGfxSkyEventPic > -1)
              {
                 let mut local5: &Graphics = &graphics1;
                Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[newGfxSkyEventPic]);
                 let mut local6: &Bitmap = &bitmap;
                rectangle2 = Rectangle::new(newGfxSkyX * 420, newGfxSkyY * 240, 420, 240);
                let mut srcrect: &Rectangle = &rectangle2
                rectangle1 = Rectangle::new(num5, num6, 420, 240);
                let mut destrect: &Rectangle = &rectangle1
                DrawMod.DrawSimplePart2( local5,  local6, srcrect, destrect);
              }
              let mut backgroundEventPic1: i32 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxBackgroundEventPic;
              let mut newGfxBackgroundX: i32 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxBackgroundX;
              let mut newGfxBackgroundY: i32 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxBackgroundY;
              if (backgroundEventPic1 > -1)
              {
                 let mut local7: &Graphics = &graphics1;
                Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[backgroundEventPic1]);
                 let mut local8: &Bitmap = &bitmap;
                rectangle1 = Rectangle::new(newGfxBackgroundX * 420, newGfxBackgroundY * 240, 420, 240);
                let mut srcrect: &Rectangle = &rectangle1
                rectangle2 = Rectangle::new(num5, num6, 420, 240);
                let mut destrect: &Rectangle = &rectangle2
                DrawMod.DrawSimplePart2( local7,  local8, srcrect, destrect);
              }
              let mut backgroundEventPic2: i32 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxWeatherBackgroundEventPic;
              let mut weatherBackgroundX: i32 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxWeatherBackgroundX;
              let mut weatherBackgroundY: i32 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxWeatherBackgroundY;
              if (backgroundEventPic2 > -1)
              {
                 let mut local9: &Graphics = &graphics1;
                Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[backgroundEventPic2]);
                 let mut local10: &Bitmap = &bitmap;
                rectangle1 = Rectangle::new(weatherBackgroundX * 420, weatherBackgroundY * 240, 420, 240);
                let mut srcrect: &Rectangle = &rectangle1
                rectangle2 = Rectangle::new(num5, num6, 420, 240);
                let mut destrect: &Rectangle = &rectangle2
                DrawMod.DrawSimplePart2( local9,  local10, srcrect, destrect);
              }
            }
            else
            {
              DrawMod.DrawBlockGradient2( graphics1, num5, num6, 419, 239, Color.Transparent, c2_2);
              DrawMod.DrawBlockGradient2( graphics1, num5, num6 + 160, 419, 79, c1, c2_1);
            }
            Graphics graphics2 = graphics1;
            rectangle1 = Rectangle::new(num5, num6, 420, 240);
            let mut rect1: &Rectangle = &rectangle1
            graphics2.SetClip(rect1);
            if (this.game.Data.RegimeObj[this.game.Data.UnitObj[this.unr].Regime].Mirror)
            {
              Matrix matrix = Matrix::new();
              matrix.Scale(-1f, 1f);
              matrix.Translate((float) -(2 * num5 + 420), 0.0f);
              graphics1.Transform = matrix;
               let mut local11: &Graphics = &graphics1;
              Bitmap bitmap = BitmapStore.GetBitmap(sidewaysSpriteId);
               let mut local12: &Bitmap = &bitmap;
              let mut sftypenr: i32 = typ;
              let mut ppl: i32 = pplnr;
              let mut tx: i32 = num5;
              let mut ty: i32 = num6 + 28;
              DrawMod.DrawWithArtCode( local11,  local12, 420, 240, sftypenr, ppl, tx, ty, 420, 240);
              graphics1.ResetTransform();
            }
            else
            {
               let mut local13: &Graphics = &graphics1;
              Bitmap bitmap = BitmapStore.GetBitmap(sidewaysSpriteId);
               let mut local14: &Bitmap = &bitmap;
              let mut sftypenr: i32 = typ;
              let mut ppl: i32 = pplnr;
              let mut tx: i32 = num5;
              let mut ty: i32 = num6 + 28;
              DrawMod.DrawWithArtCode( local13,  local14, 420, 240, sftypenr, ppl, tx, ty, 420, 240);
            }
            Graphics graphics3 = graphics1;
            rectangle1 = Rectangle::new(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height);
            let mut rect2: &Rectangle = &rectangle1
            graphics3.SetClip(rect2);
            if (this.game.SelectX > -1 & this.sfnr > -1 & this.game.SelectY > -1)
            {
              let mut landscapeType: i32 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType;
              let mut foregroundEventPic1: i32 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxForegroundEventPic;
              let mut newGfxForegroundX: i32 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxForegroundX;
              let mut newGfxForegroundY: i32 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxForegroundY;
              if (foregroundEventPic1 > -1)
              {
                 let mut local15: &Graphics = &graphics1;
                Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[foregroundEventPic1]);
                 let mut local16: &Bitmap = &bitmap;
                rectangle1 = Rectangle::new(newGfxForegroundX * 420, newGfxForegroundY * 240, 420, 240);
                let mut srcrect: &Rectangle = &rectangle1
                rectangle2 = Rectangle::new(num5, num6, 420, 240);
                let mut destrect: &Rectangle = &rectangle2
                DrawMod.DrawSimplePart2( local15,  local16, srcrect, destrect);
              }
              let mut foregroundEventPic2: i32 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxWeatherForegroundEventPic;
              let mut weatherForegroundX: i32 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxWeatherForegroundX;
              let mut weatherForegroundY: i32 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxWeatherForegroundY;
              if (foregroundEventPic2 > -1)
              {
                 let mut local17: &Graphics = &graphics1;
                Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[foregroundEventPic2]);
                 let mut local18: &Bitmap = &bitmap;
                rectangle1 = Rectangle::new(weatherForegroundX * 420, weatherForegroundY * 240, 420, 240);
                let mut srcrect: &Rectangle = &rectangle1
                rectangle2 = Rectangle::new(num5, num6, 420, 240);
                let mut destrect: &Rectangle = &rectangle2
                DrawMod.DrawSimplePart2( local17,  local18, srcrect, destrect);
              }
            }
            if (this.comparenr == -1)
              sizeF = graphics1.MeasureString(name, this.game.MarcFont1);
          }
        }
      }
      str3: String = this.game.Data.SFTypeObj[typ].Description;
      if (Strings.InStr(str3, "[tab]") == 0)
        str3 = "[tab]" + this.game.Data.SFTypeObj[typ].Name + " (" + this.game.Data.TempString[400 + this.game.Data.SFTypeObj[typ].UnitGroup] + ")," + str3 + "[/tab]";
      let mut tsubpart1: SubPartClass =  new TextAreaClass2(this.game, 560,  Math.Round(Conversion.Int(160.0 / 17.0)), this.game.MarcFont8, str3, 17,  this.OwnBitmap, 300, 290);
      this.descid = this.AddSubPart( tsubpart1, 300, 290, 560,  Math.Round((Conversion.Int(160.0 / 17.0) + 2.0) * 17.0), 0);
      tvalue2_1: String = "";
      this.OptionsList2Obj = ListClass::new();
      tvalue1: String = this.game.Data.SFTypeObj[typ].SupplyCarry.ToString();
      if (this.comparenr > -1)
        tvalue2_1 = this.game.Data.SFTypeObj[this.comparenr].SupplyCarry.ToString();
      this.OptionsList2Obj.add("Supply max organic storage", -1, tvalue1, tvalue2_1);
      tvalue2: String = this.game.Data.SFTypeObj[typ].BasicSupplyNeed.ToString();
      if (this.comparenr > -1)
        tvalue2_1 = this.game.Data.SFTypeObj[this.comparenr].BasicSupplyNeed.ToString();
      this.OptionsList2Obj.add("Basic Supply use", -1, tvalue2, tvalue2_1);
      let mut num7: i32 = 10;
      if (this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].EndCombatRound > 0 & this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].EndCombatRound < num7)
        num7 = this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].EndCombatRound - this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].StartCombatRound;
      tvalue3: String = Math.Round((double) this.game.Data.SFTypeObj[typ].SupplyForAttack / (double) num7, 2).ToString();
      let mut num8: i32 = 10;
      double num9;
      if (this.comparenr > -1)
      {
        if (this.game.Data.SFTypeObj[this.comparenr].EndCombatRound > 0 & this.game.Data.SFTypeObj[this.comparenr].EndCombatRound < num7)
          num8 = this.game.Data.SFTypeObj[this.comparenr].EndCombatRound - this.game.Data.SFTypeObj[this.comparenr].StartCombatRound;
        num9 = Math.Round((double) this.game.Data.SFTypeObj[this.comparenr].SupplyForAttack / (double) num8, 2);
        tvalue2_1 = num9.ToString();
      }
      this.OptionsList2Obj.add("Supply per Off Combat round", -1, tvalue3, tvalue2_1);
      num9 = Math.Round((double) this.game.Data.SFTypeObj[typ].SupplyForAttackDef / (double) num7, 2);
      tvalue4: String = num9.ToString();
      if (this.comparenr > -1)
      {
        num9 = Math.Round((double) this.game.Data.SFTypeObj[this.comparenr].SupplyForAttackDef / (double) num8, 2);
        tvalue2_1 = num9.ToString();
      }
      this.OptionsList2Obj.add("Supply per Def Combat round", -1, tvalue4, tvalue2_1);
      tvalue5: String = this.game.Data.SFTypeObj[typ].SupplyMaxIn.ToString();
      if (this.comparenr > -1)
        tvalue2_1 = this.game.Data.SFTypeObj[this.comparenr].SupplyMaxIn.ToString();
      this.OptionsList2Obj.add("Supply max Replenish per turn", -1, tvalue5, tvalue2_1);
      tvalue6: String = "";
      tvalue2_2: String = "";
      this.OptionsList2Obj.add("----", -1, tvalue6, tvalue2_2);
      tvalue7: String = this.game.Data.SFTypeObj[typ].FuelCarry.ToString();
      if (this.comparenr > -1)
        tvalue2_2 = this.game.Data.SFTypeObj[this.comparenr].FuelCarry.ToString();
      this.OptionsList2Obj.add("Fuel max organic storage", -1, tvalue7, tvalue2_2);
      tvalue8: String = this.game.Data.SFTypeObj[typ].FuelForMove.ToString();
      if (this.comparenr > -1)
        tvalue2_2 = this.game.Data.SFTypeObj[this.comparenr].FuelForMove.ToString();
      this.OptionsList2Obj.add("Fuel for 10AP Move", -1, tvalue8, tvalue2_2);
      tvalue9: String = this.game.Data.SFTypeObj[typ].FuelForAttack.ToString();
      if (this.comparenr > -1)
        tvalue2_2 = this.game.Data.SFTypeObj[this.comparenr].FuelForAttack.ToString();
      this.OptionsList2Obj.add("Fuel per Off Combat Round", -1, tvalue9, tvalue2_2);
      tvalue10: String = this.game.Data.SFTypeObj[typ].FuelForAttackDef.ToString();
      if (this.comparenr > -1)
        tvalue2_2 = this.game.Data.SFTypeObj[this.comparenr].FuelForAttackDef.ToString();
      this.OptionsList2Obj.add("Fuel per Def Combat Round", -1, tvalue10, tvalue2_2);
      if (this.OptionsList2Id > 0)
      {
        this.SubPartList[this.SubpartNr(this.OptionsList2Id)].Refresh(this.OptionsList2Obj, -1);
        this.SubPartFlag[this.SubpartNr(this.OptionsList2Id)] = true;
      }
      else
      {
        ListClass optionsList2Obj = this.OptionsList2Obj;
        let mut game: GameClass = this.game;
         Bitmap local19 =  this.OwnBitmap;
        Font font =  null;
         Font local20 =  font;
        let mut tsubpart2: SubPartClass =  new ListSubPartClass(optionsList2Obj, 9, 260, -1, game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 100, tdotopandbottom: false, tbackbitmap: ( local19), bbx: 300, bby: 520, tMarcStyle: true, overruleFont: ( local20));
        this.OptionsList2Id = this.AddSubPart( tsubpart2, 300, 520, 260, 160, 0);
      }
      DrawMod.DrawTextColouredMarc( graphics1, "SUPPLY & FUEL STATS", this.game.MarcFont5, 300, 500, Color.White);
      bool flag = false;
      if (this.game.Data.SFTypeObj[typ].ArtRange > 0 | this.game.Data.SFTypeObj[typ].directRange > 0)
        flag = true;
      if (this.comparenr > -1 && this.game.Data.SFTypeObj[this.comparenr].ArtRange > 0 | this.game.Data.SFTypeObj[this.comparenr].directRange > 0)
        flag = true;
      this.OptionsList4Obj = ListClass::new();
      if (flag)
      {
        num1 = 0;
        let mut val2: i32 = Math.Max(this.game.Data.SFTypeObj[typ].ArtRange, this.game.Data.SFTypeObj[typ].directRange);
        if (this.comparenr > -1)
          val2 = Math.Max(Math.Max(this.game.Data.SFTypeObj[this.comparenr].ArtRange, this.game.Data.SFTypeObj[this.comparenr].directRange), val2);
        let mut num10: i32 = Math.Min(9, val2);
        for (let mut index9: i32 = 1; index9 <= num10; index9 += 1)
        {
          let mut num11: i32 = 0;
          str2 = "";
          if (this.game.Data.SFTypeObj[typ].ArtRange >= index9)
            num11 = 100;
          else if (this.game.Data.SFTypeObj[typ].directRange >= index9)
          {
            num11 = this.game.Data.SFTypeObj[typ].directModFirstHex;
            let mut num12: i32 = index9;
            for (let mut index10: i32 = 2; index10 <= num12; index10 += 1)
              num11 =  Math.Round(Math.Floor((double) (num11 * this.game.Data.SFTypeObj[typ].directModPerHex) / 100.0));
          }
          tvalue11: String = num11.ToString() + "%";
          tvalue2_3: String = "";
          if (this.comparenr > -1)
          {
            let mut num13: i32 = 0;
            if (this.game.Data.SFTypeObj[this.comparenr].ArtRange >= index9)
              num13 = 100;
            else if (this.game.Data.SFTypeObj[this.comparenr].directRange >= index9)
            {
              num13 = this.game.Data.SFTypeObj[this.comparenr].directModFirstHex;
              let mut num14: i32 = index9;
              for (let mut index11: i32 = 2; index11 <= num14; index11 += 1)
                num13 =  Math.Round(Math.Floor((double) (num13 * this.game.Data.SFTypeObj[this.comparenr].directModPerHex) / 100.0));
            }
            tvalue2_3 = num13.ToString() + "%";
          }
          if (index9 == 9 & val2 > 9)
            this.OptionsList4Obj.add("Range " + index9.ToString() + "+", -1, tvalue11, tvalue2_3);
          else
            this.OptionsList4Obj.add("Range " + index9.ToString(), -1, tvalue11, tvalue2_3);
        }
      }
      if (this.OptionsList4Id > 0)
      {
        this.SubPartList[this.SubpartNr(this.OptionsList4Id)].Refresh(this.OptionsList4Obj, -1);
        this.SubPartFlag[this.SubpartNr(this.OptionsList4Id)] = true;
      }
      else
      {
        ListClass optionsList4Obj = this.OptionsList4Obj;
        let mut game: GameClass = this.game;
         Bitmap local21 =  this.OwnBitmap;
        Font font =  null;
         Font local22 =  font;
        let mut tsubpart3: SubPartClass =  new ListSubPartClass(optionsList4Obj, 9, 260, -1, game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 100, tdotopandbottom: false, tbackbitmap: ( local21), bbx: 600, bby: 520, tMarcStyle: true, overruleFont: ( local22));
        this.OptionsList4Id = this.AddSubPart( tsubpart3, 600, 520, 260, 160, 0);
      }
      DrawMod.DrawTextColouredMarc( graphics1, "RANGED WEAPONS", this.game.MarcFont5, 600, 500, Color.White);
      StringListClass tListobj1 = new StringListClass(1);
      let mut index12: i32 = -1;
      let mut num15: i32 = -1;
      tListobj1.AddCol(0, "");
      tListobj1.AddCol(0, "");
      tListobj1.AddCol(0, "");
      tListobj1.AddCol(0, "");
      if ((double) this.game.Data.RuleVar[492] < 1.0)
        tListobj1.TempColumBmp[0] = Conversions.ToString(this.ReturnSFSpriteNr(typ, regnr, pplnr));
      tListobj1.ColumnName[1] = this.game.Data.SFTypeObj[typ].Ratio <= 1 ? Strings.UCase(this.game.Data.SFTypeObj[typ].Name) + " stats" : Strings.UCase(this.game.Data.SFTypeObj[typ].Name) + " (" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[typ].Ratio)) + "x) stats";
      let mut index13: i32 = 0;
      do
      {
        if (Strings.Len(this.game.Data.SFTypeObj[typ].LogoString[index13]) > 0 && Operators.CompareString(this.game.Data.SFTypeObj[typ].LogoString[index13], "0", false) != 0)
        {
          if ((num15 + 10) % 2 > 0)
          {
            index12 += 1;
            num15 += 1;
            tListobj1.AddRow(tListobj1.Length);
            if ((double) this.game.Data.RuleVar[947] == 1.0)
            {
              if (Strings.Len(this.game.Data.TempString[1000 + index13]) > 0)
              {
                tListobj1.TempBmp[index12, 0] = this.game.Data.SmallPicNr[Conversions.ToInteger(this.game.Data.TempString[1000 + index13])];
                tListobj1.TempDesc[index12, 0] = this.game.Data.TempString[1100 + index13];
              }
            }
            else if (Strings.Len(this.game.Data.TempString[1000 + index13]) > 0)
            {
              tListobj1.TempBmp[index12, 0] = this.game.NATO[Conversions.ToInteger(this.game.Data.TempString[1000 + index13])];
              tListobj1.TempDesc[index12, 0] = this.game.Data.TempString[1100 + index13];
            }
            tListobj1.Data[index12, 1] = this.game.Data.SFTypeObj[typ].LogoString[index13];
            tListobj1.TempDesc[index12, 1] = this.game.Data.TempString[1100 + index13];
          }
          else
          {
            num15 += 1;
            if ((double) this.game.Data.RuleVar[947] == 1.0)
            {
              if (Strings.Len(this.game.Data.TempString[1000 + index13]) > 0)
              {
                tListobj1.TempBmp[index12, 2] = this.game.Data.SmallPicNr[Conversions.ToInteger(this.game.Data.TempString[1000 + index13])];
                tListobj1.TempDesc[index12, 2] = this.game.Data.TempString[1100 + index13];
              }
            }
            else if (Strings.Len(this.game.Data.TempString[1000 + index13]) > 0)
            {
              tListobj1.TempBmp[index12, 2] = this.game.NATO[Conversions.ToInteger(this.game.Data.TempString[1000 + index13])];
              tListobj1.TempDesc[index12, 2] = this.game.Data.TempString[1100 + index13];
            }
            tListobj1.Data[index12, 3] = this.game.Data.SFTypeObj[typ].LogoString[index13];
            tListobj1.TempDesc[index12, 3] = this.game.Data.TempString[1100 + index13];
          }
        }
        index13 += 1;
      }
      while (index13 <= 99);
      let mut tlistsize1: i32 = 4;
      let mut num16: i32 = 110;
      if (this.comparenr == -1)
        num16 = 77;
      let mut tsubpart4: SubPartClass =  new MatrixSubPartClass(tListobj1, tlistsize1, 260, -1, -1, this.game, tbackbitmap: ( this.OwnBitmap), bbx: num2, bby: num16, trowheight: 26, tfontsize: 18, tfontoffsety: 2, tnolines: true, tMarcy: true, tMinColValue: 40);
      this.LogoListId = this.AddSubPart( tsubpart4, num2, num16, 260, (tlistsize1 + 3) * 26, 0);
      if (this.comparenr > -1)
      {
        StringListClass tListobj2 = new StringListClass(1);
        let mut index14: i32 = -1;
        let mut num17: i32 = -1;
        tListobj2.AddCol(0, "");
        tListobj2.AddCol(0, "");
        tListobj2.AddCol(0, "");
        tListobj2.AddCol(0, "");
        if ((double) this.game.Data.RuleVar[492] < 1.0)
          tListobj2.TempColumBmp[0] = Conversions.ToString(this.ReturnSFSpriteNr(this.comparenr, regnr, pplnr));
        tListobj2.ColumnName[1] = this.game.Data.SFTypeObj[this.comparenr].Ratio <= 1 ? Strings.UCase(this.game.Data.SFTypeObj[this.comparenr].Name) : Strings.UCase(this.game.Data.SFTypeObj[this.comparenr].Name) + " (" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].Ratio)) + "x)";
        let mut index15: i32 = 0;
        do
        {
          if (Strings.Len(this.game.Data.SFTypeObj[this.comparenr].LogoString[index15]) > 0 && Operators.CompareString(this.game.Data.SFTypeObj[this.comparenr].LogoString[index15], "0", false) != 0)
          {
            if ((num17 + 10) % 2 > 0)
            {
              index14 += 1;
              num17 += 1;
              tListobj2.AddRow(tListobj2.Length);
              if ((double) this.game.Data.RuleVar[947] == 1.0)
              {
                if (Strings.Len(this.game.Data.TempString[1000 + index15]) > 0)
                {
                  tListobj2.TempBmp[index14, 0] = this.game.Data.SmallPicNr[Conversions.ToInteger(this.game.Data.TempString[1000 + index15])];
                  tListobj2.TempDesc[index14, 0] = this.game.Data.TempString[1100 + index15];
                }
              }
              else if (Strings.Len(this.game.Data.TempString[1000 + index15]) > 0)
              {
                tListobj2.TempBmp[index14, 0] = this.game.NATO[Conversions.ToInteger(this.game.Data.TempString[1000 + index15])];
                tListobj2.TempDesc[index14, 0] = this.game.Data.TempString[1100 + index15];
              }
              tListobj2.Data[index14, 1] = this.game.Data.SFTypeObj[this.comparenr].LogoString[index15];
              tListobj2.TempDesc[index14, 1] = this.game.Data.TempString[1100 + index15];
            }
            else
            {
              num17 += 1;
              if ((double) this.game.Data.RuleVar[947] == 1.0)
              {
                if (Strings.Len(this.game.Data.TempString[1000 + index15]) > 0)
                {
                  tListobj2.TempBmp[index14, 2] = this.game.Data.SmallPicNr[Conversions.ToInteger(this.game.Data.TempString[1000 + index15])];
                  tListobj2.TempDesc[index14, 2] = this.game.Data.TempString[1100 + index15];
                }
              }
              else if (Strings.Len(this.game.Data.TempString[1000 + index15]) > 0)
              {
                tListobj2.TempBmp[index14, 2] = this.game.NATO[Conversions.ToInteger(this.game.Data.TempString[1000 + index15])];
                tListobj2.TempDesc[index14, 2] = this.game.Data.TempString[1100 + index15];
              }
              tListobj2.Data[index14, 3] = this.game.Data.SFTypeObj[this.comparenr].LogoString[index15];
              tListobj2.TempDesc[index14, 3] = this.game.Data.TempString[1100 + index15];
            }
          }
          index15 += 1;
        }
        while (index15 <= 99);
        let mut tlistsize2: i32 = 4;
        let mut tsubpart5: SubPartClass =  new MatrixSubPartClass(tListobj2, tlistsize2, 260, -1, -1, this.game, tbackbitmap: ( this.OwnBitmap), bbx: num3, bby: 110, trowheight: 26, tfontsize: 18, tfontoffsety: 2, tnolines: true, tMarcy: true, tMinColValue: 40);
        this.logolist3id = this.AddSubPart( tsubpart5, num3, 110, 260, (tlistsize2 + 3) * 26, 0);
      }
      if (this.sfnr > -1)
      {
        Coordinate reconMinusHide;
        if (this.unr > -1)
        {
          if (this.game.Data.UnitObj[this.unr].Regime == this.game.Data.Turn | this.game.Data.Round == 0)
            reconMinusHide.x = 3;
          else
            reconMinusHide = this.game.HandyFunctionsObj.GetReconMinusHide(this.unr, this.game.Data.Turn);
        }
        else
          reconMinusHide.x = 3;
        if (reconMinusHide.x >= 2)
        {
          this.OptionsList3Obj = ListClass::new();
          this.OptionsList3Obj.add("People", -1, this.game.Data.PeopleObj[this.game.Data.SFObj[this.sfnr].People].Name);
          float num18 = this.game.Data.PeopleObj[this.game.Data.SFObj[this.sfnr].People].BattleForMod[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.UnitObj[this.unr].Regime].People].PeopleGroup];
          if ((double) num18 > 1.0 | (double) num18 < 1.0)
          {
            let mut Number: i32 =  Math.Round((double) ((num18 - 1f) * 100f));
            tvalue12: String = Strings.Trim(Conversion.Str((object) Number)) + "%";
            if (Number >= 0)
              tvalue12 = "+" + tvalue12;
            this.OptionsList3Obj.add("People Combat Bonus", -1, tvalue12);
          }
          if (reconMinusHide.x == 3)
          {
            this.OptionsList3Obj.add("Qty", -1, Strings.Trim(Conversion.Str((object) (this.game.Data.SFObj[this.sfnr].Qty * this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].Ratio))));
            this.OptionsList3Obj.add("Readiness", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Rdn)));
            this.OptionsList3Obj.add("Morale", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Mor)));
            str2 = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Mor));
            this.OptionsList3Obj.add("Base Morale", -1, ( Math.Round((double) this.game.Data.PeopleObj[pplnr].BaseMorale[this.game.Data.RegimeObj[regnr].People] * ((double) this.game.Data.RegimeObj[regnr].BaseMorale / 100.0))).ToString());
            this.OptionsList3Obj.add("Experience", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Xp)));
            this.OptionsList3Obj.add("Current entrenchment", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].CurrentEntrench)));
            this.OptionsList3Obj.add("Entrenchment Cap.", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].EntrenchPower)));
            this.OptionsList3Obj.add("Action Points", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Ap)));
            this.OptionsList3Obj.add("Engineer Points", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].EP)));
            this.OptionsList3Obj.add("Recon Points", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].ReconPts)));
            this.OptionsList3Obj.add("ZOC Points", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].ZOCPts)));
            this.OptionsList3Obj.add("Height cost modifier", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].heightLevelDiff)) + "%");
            this.OptionsList3Obj.add("EP per Turn", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].EP)));
            this.OptionsList3Obj.add("Ratio", -1, "x" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].Ratio)));
            this.OptionsList3Obj.add("Individuals", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Qty)));
            this.OptionsList3Obj.add("Weight/Carry", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].Weight)) + "/" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].CarryCap)));
            this.OptionsList3Obj.add("Manpower/Carry", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].manpower)) + "/" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].manpowerCarry)));
            tvalue13: String = this.game.Data.TempString[this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].MoveType];
            this.OptionsList3Obj.add("Move Type", -1, tvalue13);
            let mut num19: i32 = this.game.Data.transportMovementType[this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].MoveType];
            if (num19 == 0)
              tvalue13 = "Neither";
            if (num19 == 1)
              tvalue13 = "Transporter";
            if (num19 == 2)
              tvalue13 = "Transportable";
            this.OptionsList3Obj.add("Transport Type", -1, tvalue13);
            this.OptionsList3Obj.add("Power Points", -1, this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].PowerPts.ToString());
            this.OptionsList3Obj.add("Rear Area 'backbench'", -1, this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].BackBench.ToString());
            this.OptionsList3Obj.add("Attacks", -1, this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].Attacks.ToString());
            this.OptionsList3Obj.add("Unit Group", -1, this.game.Data.TempString[400 + this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].UnitGroup]);
            this.OptionsList3Obj.add("TargetChance%", -1, this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].targettedByRangedChance.ToString());
            this.OptionsList3Obj.add("Hide Points", -1, this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].HidePts.ToString());
            this.OptionsList3Obj.add("Favorite Tries", -1, this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].FavTargetTries.ToString());
            this.OptionsList3Obj.add("Out of fuel AP multiplier", -1, this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].OutOfFuelMove.ToString() + "x");
            this.OptionsList3Obj.add("Rdn loss for 100AP moved", -1, this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].ReadinessLoss.ToString());
            if (this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].StaffPts > 0)
            {
              this.OptionsList3Obj.add("Staff Points", -1, this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].StaffPts.ToString());
              this.OptionsList3Obj.add("Staff Combat Mod", -1, ( Math.Round((double) (100f * this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].StaffCombatMod))).ToString() + "%");
              this.OptionsList3Obj.add("Staff Morale Mod", -1, ( Math.Round((double) (100f * this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].StaffMoraleMod))).ToString() + "%");
            }
            this.OptionsList3Obj.add("Attack startup penalty", -1, (this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].FirstRoundPenaltyMod * 100f).ToString() + "%");
            this.OptionsList3Obj.add("Max attacked", -1, this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].MaxAttacked.ToString() + "%");
          }
          this.OptionsList3Obj.Sort();
          if (this.OptionsList3Id > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, -1);
            this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
          }
          else
          {
            ListClass optionsList3Obj = this.OptionsList3Obj;
            let mut game: GameClass = this.game;
             Bitmap local23 =  this.OwnBitmap;
            Font font =  null;
             Font local24 =  font;
            let mut tsubpart6: SubPartClass =  new ListSubPartClass(optionsList3Obj, 22, 260, -1, game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 100, tdotopandbottom: false, tbackbitmap: ( local23), bbx: 20, bby: 308, tMarcStyle: true, overruleFont: ( local24));
            this.OptionsList3Id = this.AddSubPart( tsubpart6, 20, 308, 260, 460, 0);
          }
          DrawMod.DrawTextColouredMarc( graphics1, "SELECTED TROOPS STATS", this.game.MarcFont5, 90, 291, Color.White);
          rectangle1 = Rectangle::new(20, 335, 290, 144);
          let mut trect: &Rectangle = &rectangle1
          this.AddMouse( trect, "", "The troops in the slot you clicked\r\nhave their own detailed stats.");
        }
      }
      let mut tsubpart7: SubPartClass =  new TextButtonPartClass("OK", 150, "Click to return to main screen.",  this.OwnBitmap,  Math.Round((double) this.OwnBitmap.Width / 2.0 + 15.0), 703, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.but1id = this.AddSubPart( tsubpart7,  Math.Round((double) this.OwnBitmap.Width / 2.0 + 15.0), 703, 150, 40, 1);
      tsubpart7 =  new TextButtonPartClass("COMPARE", 150, "Click to select another trooptype to compare stats with.",  this.OwnBitmap,  Math.Round((double) this.OwnBitmap.Width / 2.0 - 175.0), 703, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.but7id = this.AddSubPart( tsubpart7,  Math.Round((double) this.OwnBitmap.Width / 2.0 - 175.0), 703, 150, 40, 1);
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
          windowReturnClass.AddCommand(6, 0);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
        if (nr == 40)
        {
          this.SubPartList[this.SubpartNr(this.descid)].ShiftDown();
          this.SubPartFlag[this.SubpartNr(this.descid)] = true;
          windowReturnClass.SetFlag(true);
        }
        if (nr == 38)
        {
          this.SubPartList[this.SubpartNr(this.descid)].ShiftUp();
          this.SubPartFlag[this.SubpartNr(this.descid)] = true;
          windowReturnClass.SetFlag(true);
        }
        if (nr == 37)
        {
          this.SubPartList[this.SubpartNr(this.descid)].ShiftLeft();
          this.SubPartFlag[this.SubpartNr(this.descid)] = true;
          windowReturnClass.SetFlag(true);
        }
        if (nr == 39)
        {
          this.SubPartList[this.SubpartNr(this.descid)].ShiftRight();
          this.SubPartFlag[this.SubpartNr(this.descid)] = true;
          windowReturnClass.SetFlag(true);
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
            int num2;
            if (num1 == this.LogoListId)
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
            if (num1 == this.descid)
            {
              num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.but1id || num1 == this.but1bid)
            {
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 != this.but7id)
              return windowReturnClass;
            Form3::new( this.formref).Initialize(this.game.Data, 74, -1);
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
  }
}
