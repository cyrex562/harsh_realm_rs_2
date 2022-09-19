// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SFWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingMicrosoft.VisualBasic.CompilerServices;
// usingSystem;
// usingSystem.Drawing;
// usingSystem.Windows.Forms;

namespace WindowsApplication1
{
  pub class SFWindowClass2 : WindowClass
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

    pub SFWindowClass2( GameClass tGame)
      : base( tGame, 880, 580, 8)
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
      this.ClearMouse();
      this.NewBackGroundAndClearAll(880, 580, -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
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
      DrawMod.DrawMessFrame( this.OwnBitmap,  graphics, 0, 0, 880, 580, watermark);
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
          str1 = Strings.Trim(Conversion.Str( this.game.Data.SFObj[this.sfnr].Qty)) + "x ";
          if (this.game.Data.SFTypeObj[typ].Ratio > 1)
            str1 = str1 + " " + Strings.Trim(Conversion.Str( this.game.Data.SFTypeObj[typ].Ratio)) + "x ";
        }
      }
      int regnr;
      int num1;
      int num2;
      Rectangle rectangle1;
      Rectangle trect;
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
        str2: String = str1 + name;
        SizeF sizeF1 = SizeF::new();
        if (this.comparenr == -1)
        {
          SizeF sizeF2 = graphics.MeasureString(name + " trooptype details", this.game.MarcFont1);
          DrawMod.DrawTextColouredMarc( graphics, name + " trooptype details", this.game.MarcFont1, 417 -  Math.Round( (sizeF2.Width / 2f)), 19, Color.White);
        }
        index1 = 0;
        regnr = this.sfnr <= -1 ? this.game.Data.Turn : this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime;
        let mut picSpriteId: i32 = this.game.Data.SFTypeObj[typ].PicSpriteID;
        if (this.game.Data.RegimeObj[regnr].ExtraGraphicUse > -1)
        {
          let mut extraCounter: i32 = this.game.Data.SFTypeObj[typ].ExtraCounter;
          for (let mut index7: i32 = 0; index7 <= extraCounter; index7 += 1)
          {
            if (this.game.Data.SFTypeObj[typ].ExtraCode[index7] == this.game.Data.RegimeObj[regnr].ExtraGraphicUse)
              picSpriteId = this.game.Data.SFTypeObj[typ].ExtraPicSpriteID[index7];
          }
        }
        else if (pplnr > -1 && this.game.Data.PeopleObj[pplnr].ExtraGraphicUse > -1)
        {
          let mut extraCounter: i32 = this.game.Data.SFTypeObj[typ].ExtraCounter;
          for (let mut index8: i32 = 0; index8 <= extraCounter; index8 += 1)
          {
            if (this.game.Data.SFTypeObj[typ].ExtraCode[index8] == this.game.Data.PeopleObj[pplnr].ExtraGraphicUse)
              picSpriteId = this.game.Data.SFTypeObj[typ].ExtraPicSpriteID[index8];
          }
        }
        if (typ > -1)
        {
          num1 = 450;
          let mut num3: i32 = 20;
          if (this.comparenr > -1)
          {
            num1 = 160;
            num2 = 450;
          }
          if (this.comparenr > -1)
          {
            let mut sidewaysSpriteId1: i32 = this.game.Data.SFTypeObj[typ].SidewaysSpriteID;
            DrawMod.DrawBlockGradient2( graphics, num1 + 60, num3, 139, 79, this.game.MarcCol1, this.game.MarcCol2);
             let mut local1: &Graphics = &graphics;
            Bitmap bitmap1 = BitmapStore.GetBitmap(sidewaysSpriteId1);
             let mut local2: &Bitmap = &bitmap1;
            Rectangle rectangle2 = Rectangle::new(0, 0, BitmapStore.GetWidth(sidewaysSpriteId1), BitmapStore.Getheight(sidewaysSpriteId1));
            let mut srcrect1: &Rectangle = &rectangle2
            rectangle1 = Rectangle::new(num1 + 60, num3, 140, 80);
            let mut destrect1: &Rectangle = &rectangle1
            DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
            DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  graphics, num1 + 60, num3, 140, 80, -1, -1);
            let mut sidewaysSpriteId2: i32 = this.game.Data.SFTypeObj[this.comparenr].SidewaysSpriteID;
            DrawMod.DrawBlockGradient2( graphics, num2 + 60, num3, 139, 79, this.game.MarcCol1, this.game.MarcCol2);
             let mut local3: &Graphics = &graphics;
            Bitmap bitmap2 = BitmapStore.GetBitmap(sidewaysSpriteId2);
             let mut local4: &Bitmap = &bitmap2;
            rectangle1 = Rectangle::new(0, 0, BitmapStore.GetWidth(sidewaysSpriteId2), BitmapStore.Getheight(sidewaysSpriteId2));
            let mut srcrect2: &Rectangle = &rectangle1
            rectangle2 = Rectangle::new(num2 + 60, num3, 140, 80);
            let mut destrect2: &Rectangle = &rectangle2
            DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
            DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  graphics, num2 + 60, num3, 140, 80, -1, -1);
          }
          else if (this.comparenr == -1)
          {
            let mut sidewaysSpriteId: i32 = this.game.Data.SFTypeObj[typ].SidewaysSpriteID;
            if (this.game.Data.SFTypeObj[typ].Theater == 0 || this.game.Data.SFTypeObj[typ].Theater == 1 || this.game.Data.SFTypeObj[typ].Theater != 2)
              ;
            let mut x: i32 = num1 - 310;
            let mut y: i32 = 77;
            let mut index9: i32 =  Math.Round( this.game.Data.RuleVar[873]);
            let mut index10: i32 = 0;
            if ( this.game.Data.RuleVar[848] > 0.0 & this.game.Data.SFTypeObj[typ].Theater == 2)
            {
              index9 =  Math.Round( this.game.Data.RuleVar[848]);
              index10 = 0;
            }
            if ( this.game.Data.RuleVar[872] > 0.0 & this.game.Data.SFTypeObj[typ].Theater == 1)
            {
              index9 =  Math.Round( this.game.Data.RuleVar[872]);
              index10 = 0;
            }
            let mut nr1: i32 = this.game.Data.LandscapeTypeObj[index9].BasicPicID[index10];
             let mut local5: &Graphics = &graphics;
            Bitmap bitmap3 = BitmapStore.GetBitmap(nr1);
             let mut local6: &Bitmap = &bitmap3;
            rectangle1 = Rectangle::new(0, 0, 138, BitmapStore.Getheight(nr1));
            let mut srcrect3: &Rectangle = &rectangle1
            trect = Rectangle::new(x, y, 280, 160);
            let mut destrect3: &Rectangle = &trect
            DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
            let mut nr2: i32 = this.game.Data.LandscapeTypeObj[index9].SidewaysSPriteID1[index10];
             let mut local7: &Graphics = &graphics;
            Bitmap bitmap4 = BitmapStore.GetBitmap(nr2);
             let mut local8: &Bitmap = &bitmap4;
            rectangle1 = Rectangle::new(0, 0, 138, BitmapStore.Getheight(nr2));
            let mut srcrect4: &Rectangle = &rectangle1
            trect = Rectangle::new(x, y, 280, 160);
            let mut destrect4: &Rectangle = &trect
            DrawMod.DrawSimplePart2( local7,  local8, srcrect4, destrect4);
            if (this.game.Data.SFTypeObj[typ].Theater != 2)
            {
              let mut nr3: i32 = this.game.Data.LandscapeTypeObj[index9].SidewaysSPriteID2[index10];
               let mut local9: &Graphics = &graphics;
              Bitmap bitmap5 = BitmapStore.GetBitmap(nr3);
               let mut local10: &Bitmap = &bitmap5;
              rectangle1 = Rectangle::new(0, 0, 138, BitmapStore.Getheight(nr3));
              let mut srcrect5: &Rectangle = &rectangle1
              trect = Rectangle::new(x, y, 280, 160);
              let mut destrect5: &Rectangle = &trect
              DrawMod.DrawSimplePart2( local9,  local10, srcrect5, destrect5);
            }
             let mut local11: &Graphics = &graphics;
            Bitmap bitmap6 = BitmapStore.GetBitmap(sidewaysSpriteId);
             let mut local12: &Bitmap = &bitmap6;
            rectangle1 = Rectangle::new(0, 0, BitmapStore.GetWidth(sidewaysSpriteId), BitmapStore.Getheight(sidewaysSpriteId));
            let mut srcrect6: &Rectangle = &rectangle1
            trect = Rectangle::new(x, y, 280, 160);
            let mut destrect6: &Rectangle = &trect
            DrawMod.DrawSimplePart2( local11,  local12, srcrect6, destrect6);
            if (this.game.Data.SFTypeObj[typ].Theater != 2)
            {
              let mut nr4: i32 = this.game.Data.LandscapeTypeObj[index9].SidewaysSPriteID3[index10];
               let mut local13: &Graphics = &graphics;
              Bitmap bitmap7 = BitmapStore.GetBitmap(nr4);
               let mut local14: &Bitmap = &bitmap7;
              rectangle1 = Rectangle::new(0, 0, 138, BitmapStore.Getheight(nr4));
              let mut srcrect7: &Rectangle = &rectangle1
              trect = Rectangle::new(x, y, 280, 160);
              let mut destrect7: &Rectangle = &trect
              DrawMod.DrawSimplePart2( local13,  local14, srcrect7, destrect7);
            }
            DrawMod.DrawFrame( this.OwnBitmap,  this.BackBitmap,  graphics, x, y, 280, 160, -1, -1);
          }
        }
      }
      str3: String = this.game.Data.SFTypeObj[typ].Description;
      if (Strings.InStr(str3, "[tab]") == 0)
        str3 = "[tab]" + this.game.Data.SFTypeObj[typ].Name + " : Troop type description," + str3 + "[/tab]";
      let mut tsubpart1: SubPartClass =  new TextAreaClass2(this.game, 560,  Math.Round(Conversion.Int(160.0 / 17.0)), this.game.MarcFont8, str3, 17,  this.OwnBitmap, 300, 290);
      this.descid = this.AddSubPart( tsubpart1, 300, 290, 560,  Math.Round((Conversion.Int(160.0 / 17.0) + 1.0) * 17.0), 0);
      StringListClass tListobj1 = new StringListClass(1);
      let mut index11: i32 = -1;
      let mut num4: i32 = -1;
      tListobj1.AddCol(0, "");
      tListobj1.AddCol(0, "");
      tListobj1.AddCol(0, "");
      tListobj1.AddCol(0, "");
      tListobj1.TempColumBmp[0] = Conversions.ToString(this.ReturnSFSpriteNr(typ, regnr, pplnr));
      tListobj1.ColumnName[1] = this.game.Data.SFTypeObj[typ].Ratio <= 1 ? Strings.UCase(this.game.Data.SFTypeObj[typ].Name) : Strings.UCase(this.game.Data.SFTypeObj[typ].Name) + " (" + Strings.Trim(Conversion.Str( this.game.Data.SFTypeObj[typ].Ratio)) + "x)";
      let mut index12: i32 = 0;
      do
      {
        if (Strings.Len(this.game.Data.SFTypeObj[typ].LogoString[index12]) > 0 && Operators.CompareString(this.game.Data.SFTypeObj[typ].LogoString[index12], "0", false) != 0)
        {
          if ((num4 + 10) % 2 > 0)
          {
            index11 += 1;
            num4 += 1;
            tListobj1.AddRow(tListobj1.Length);
            if ( this.game.Data.RuleVar[947] == 1.0)
            {
              if (Strings.Len(this.game.Data.TempString[1000 + index12]) > 0)
              {
                tListobj1.TempBmp[index11, 0] = this.game.Data.SmallPicNr[Conversions.ToInteger(this.game.Data.TempString[1000 + index12])];
                tListobj1.TempDesc[index11, 0] = this.game.Data.TempString[1100 + index12];
              }
            }
            else if (Strings.Len(this.game.Data.TempString[1000 + index12]) > 0)
            {
              tListobj1.TempBmp[index11, 0] = this.game.NATO[Conversions.ToInteger(this.game.Data.TempString[1000 + index12])];
              tListobj1.TempDesc[index11, 0] = this.game.Data.TempString[1100 + index12];
            }
            tListobj1.Data[index11, 1] = this.game.Data.SFTypeObj[typ].LogoString[index12];
            tListobj1.TempDesc[index11, 1] = this.game.Data.TempString[1100 + index12];
          }
          else
          {
            num4 += 1;
            if ( this.game.Data.RuleVar[947] == 1.0)
            {
              if (Strings.Len(this.game.Data.TempString[1000 + index12]) > 0)
              {
                tListobj1.TempBmp[index11, 2] = this.game.Data.SmallPicNr[Conversions.ToInteger(this.game.Data.TempString[1000 + index12])];
                tListobj1.TempDesc[index11, 2] = this.game.Data.TempString[1100 + index12];
              }
            }
            else if (Strings.Len(this.game.Data.TempString[1000 + index12]) > 0)
            {
              tListobj1.TempBmp[index11, 2] = this.game.NATO[Conversions.ToInteger(this.game.Data.TempString[1000 + index12])];
              tListobj1.TempDesc[index11, 2] = this.game.Data.TempString[1100 + index12];
            }
            tListobj1.Data[index11, 3] = this.game.Data.SFTypeObj[typ].LogoString[index12];
            tListobj1.TempDesc[index11, 3] = this.game.Data.TempString[1100 + index12];
          }
        }
        index12 += 1;
      }
      while (index12 <= 99);
      let mut tlistsize1: i32 = 4;
      let mut num5: i32 = 110;
      if (this.comparenr == -1)
        num5 = 77;
      let mut tsubpart2: SubPartClass =  new MatrixSubPartClass(tListobj1, tlistsize1, 260, -1, -1, this.game, tbackbitmap: ( this.OwnBitmap), bbx: num1, bby: num5, trowheight: 26, tfontsize: 18, tfontoffsety: 2, tnolines: true, tMarcy: true, tMinColValue: 40);
      this.LogoListId = this.AddSubPart( tsubpart2, num1, num5, 260, (tlistsize1 + 3) * 26, 0);
      if (this.comparenr > -1)
      {
        StringListClass tListobj2 = new StringListClass(1);
        let mut index13: i32 = -1;
        let mut num6: i32 = -1;
        tListobj2.AddCol(0, "");
        tListobj2.AddCol(0, "");
        tListobj2.AddCol(0, "");
        tListobj2.AddCol(0, "");
        tListobj2.TempColumBmp[0] = Conversions.ToString(this.ReturnSFSpriteNr(this.comparenr, regnr, pplnr));
        tListobj2.ColumnName[1] = this.game.Data.SFTypeObj[this.comparenr].Ratio <= 1 ? Strings.UCase(this.game.Data.SFTypeObj[this.comparenr].Name) : Strings.UCase(this.game.Data.SFTypeObj[this.comparenr].Name) + " (" + Strings.Trim(Conversion.Str( this.game.Data.SFTypeObj[this.comparenr].Ratio)) + "x)";
        let mut index14: i32 = 0;
        do
        {
          if (Strings.Len(this.game.Data.SFTypeObj[this.comparenr].LogoString[index14]) > 0 && Operators.CompareString(this.game.Data.SFTypeObj[this.comparenr].LogoString[index14], "0", false) != 0)
          {
            if ((num6 + 10) % 2 > 0)
            {
              index13 += 1;
              num6 += 1;
              tListobj2.AddRow(tListobj2.Length);
              if ( this.game.Data.RuleVar[947] == 1.0)
              {
                if (Strings.Len(this.game.Data.TempString[1000 + index14]) > 0)
                {
                  tListobj2.TempBmp[index13, 0] = this.game.Data.SmallPicNr[Conversions.ToInteger(this.game.Data.TempString[1000 + index14])];
                  tListobj2.TempDesc[index13, 0] = this.game.Data.TempString[1100 + index14];
                }
              }
              else if (Strings.Len(this.game.Data.TempString[1000 + index14]) > 0)
              {
                tListobj2.TempBmp[index13, 0] = this.game.NATO[Conversions.ToInteger(this.game.Data.TempString[1000 + index14])];
                tListobj2.TempDesc[index13, 0] = this.game.Data.TempString[1100 + index14];
              }
              tListobj2.Data[index13, 1] = this.game.Data.SFTypeObj[this.comparenr].LogoString[index14];
              tListobj2.TempDesc[index13, 1] = this.game.Data.TempString[1100 + index14];
            }
            else
            {
              num6 += 1;
              if ( this.game.Data.RuleVar[947] == 1.0)
              {
                if (Strings.Len(this.game.Data.TempString[1000 + index14]) > 0)
                {
                  tListobj2.TempBmp[index13, 2] = this.game.Data.SmallPicNr[Conversions.ToInteger(this.game.Data.TempString[1000 + index14])];
                  tListobj2.TempDesc[index13, 2] = this.game.Data.TempString[1100 + index14];
                }
              }
              else if (Strings.Len(this.game.Data.TempString[1000 + index14]) > 0)
              {
                tListobj2.TempBmp[index13, 2] = this.game.NATO[Conversions.ToInteger(this.game.Data.TempString[1000 + index14])];
                tListobj2.TempDesc[index13, 2] = this.game.Data.TempString[1100 + index14];
              }
              tListobj2.Data[index13, 3] = this.game.Data.SFTypeObj[this.comparenr].LogoString[index14];
              tListobj2.TempDesc[index13, 3] = this.game.Data.TempString[1100 + index14];
            }
          }
          index14 += 1;
        }
        while (index14 <= 99);
        let mut tlistsize2: i32 = 4;
        let mut tsubpart3: SubPartClass =  new MatrixSubPartClass(tListobj2, tlistsize2, 260, -1, -1, this.game, tbackbitmap: ( this.OwnBitmap), bbx: num2, bby: 110, trowheight: 26, tfontsize: 18, tfontoffsety: 2, tnolines: true, tMarcy: true, tMinColValue: 40);
        this.logolist3id = this.AddSubPart( tsubpart3, num2, 110, 260, (tlistsize2 + 3) * 26, 0);
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
          float num7 = this.game.Data.PeopleObj[this.game.Data.SFObj[this.sfnr].People].BattleForMod[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.UnitObj[this.unr].Regime].People].PeopleGroup];
          if ( num7 > 1.0 |  num7 < 1.0)
          {
            let mut Number: i32 =  Math.Round( ((num7 - 1f) * 100f));
            tvalue: String = Strings.Trim(Conversion.Str( Number)) + "%";
            if (Number >= 0)
              tvalue = "+" + tvalue;
            this.OptionsList3Obj.add("People Combat Bonus", -1, tvalue);
          }
          this.OptionsList3Obj.add("Class", -1, this.game.Data.TempString[400 + this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].UnitGroup]);
          if (reconMinusHide.x == 3)
          {
            this.OptionsList3Obj.add("Qty", -1, Strings.Trim(Conversion.Str( (this.game.Data.SFObj[this.sfnr].Qty * this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].Ratio))));
            this.OptionsList3Obj.add("Readiness", -1, Strings.Trim(Conversion.Str( this.game.Data.SFObj[this.sfnr].Rdn)));
            this.OptionsList3Obj.add("Morale", -1, Strings.Trim(Conversion.Str( this.game.Data.SFObj[this.sfnr].Mor)));
            this.OptionsList3Obj.add("Experience", -1, Strings.Trim(Conversion.Str( this.game.Data.SFObj[this.sfnr].Xp)));
            this.OptionsList3Obj.add("Entrenchment", -1, Strings.Trim(Conversion.Str( this.game.Data.SFObj[this.sfnr].CurrentEntrench)));
            this.OptionsList3Obj.add("Action Points", -1, Strings.Trim(Conversion.Str( this.game.Data.SFObj[this.sfnr].Ap)));
            this.OptionsList3Obj.add("Engineer Points", -1, Strings.Trim(Conversion.Str( this.game.Data.SFObj[this.sfnr].EP)));
            this.OptionsList3Obj.add("Ratio", -1, "x" + Strings.Trim(Conversion.Str( this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].Ratio)));
            this.OptionsList3Obj.add("Individuals", -1, Strings.Trim(Conversion.Str( this.game.Data.SFObj[this.sfnr].Qty)));
            this.OptionsList3Obj.add("Weight/Carry", -1, Strings.Trim(Conversion.Str( this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].Weight)) + "/" + Strings.Trim(Conversion.Str( this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].CarryCap)));
          }
          if (this.OptionsList3Id > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, -1);
            this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
          }
          else
          {
            ListClass optionsList3Obj = this.OptionsList3Obj;
            let mut game: GameClass = this.game;
             Bitmap local15 =  this.OwnBitmap;
            Font font =  null;
             Font local16 =  font;
            let mut tsubpart4: SubPartClass =  new ListSubPartClass(optionsList3Obj, 11, 260, -1, game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 100, tdotopandbottom: false, tbackbitmap: ( local15), bbx: 20, bby: 308, tMarcStyle: true, overruleFont: ( local16));
            this.OptionsList3Id = this.AddSubPart( tsubpart4, 20, 308, 260, 192, 0);
          }
          DrawMod.DrawTextColouredMarc( graphics, "SELECTED TROOPS STATS", this.game.MarcFont5, 90, 291, Color.White);
          rectangle1 = Rectangle::new(20, 335, 290, 144);
          trect = rectangle1;
          this.AddMouse( trect, "", "The troops in the slot you clicked\r\nhave their own detailed stats.");
        }
      }
      let mut tsubpart5: SubPartClass =  new TextButtonPartClass("OK", 150, "Click to return to main screen.",  this.OwnBitmap,  Math.Round( this.OwnBitmap.Width / 2.0 + 15.0), 515, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.but1id = this.AddSubPart( tsubpart5,  Math.Round( this.OwnBitmap.Width / 2.0 + 15.0), 515, 150, 40, 1);
      let mut tsubpart6: SubPartClass =  new TextButtonPartClass("COMPARE", 150, "Click to select another trooptype to compare stats with.",  this.OwnBitmap,  Math.Round( this.OwnBitmap.Width / 2.0 - 175.0), 515, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.but7id = this.AddSubPart( tsubpart6,  Math.Round( this.OwnBitmap.Width / 2.0 - 175.0), 515, 150, 40, 1);
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
      return  symbolSpriteId;
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
