// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SFWindowClass2
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
  public class SFWindowClass2 : WindowClass
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
    private ListClass OptionsListObj;
    private int OptionsList2Id;
    private ListClass OptionsList2Obj;
    private int OptionsList3Id;
    private ListClass OptionsList3Obj;
    private int OptionsList4Id;
    private ListClass OptionsList4Obj;
    private int OptionsList5Id;
    private ListClass OptionsList5Obj;
    private int OptionsList6Id;
    private ListClass OptionsList6Obj;
    private int combatListId;
    private ListClass combatListObj;
    private int combatList2Id;
    private ListClass combatList2Obj;
    private int StatTyp;
    private int StatMode;
    private int[] ChainHq;
    private int HQselect;
    private int infoid;

    public override void DoRefresh()
    {
      this.comparenr = this.game.EditObj.SFCompare;
      this.DoStuff();
    }

    public override void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter <= -1)
        return;
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
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

    public SFWindowClass2(ref GameClass tGame)
      : base(ref tGame, 880, 580, 8)
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

    public void DoStuff()
    {
      this.ClearMouse();
      this.NewBackGroundAndClearAll(880, 580, -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      int watermark = -1;
      int index1;
      if (this.sfnr > -1)
      {
        int type = this.game.Data.SFObj[this.sfnr].Type;
        int people = this.game.Data.SFObj[this.sfnr].People;
        watermark = this.game.Data.SFTypeObj[type].PicSpriteID;
        if (this.game.Data.RegimeObj[index1].ExtraGraphicUse > -1)
        {
          int extraCounter = this.game.Data.SFTypeObj[type].ExtraCounter;
          for (int index2 = 0; index2 <= extraCounter; ++index2)
          {
            if (this.game.Data.SFTypeObj[type].ExtraCode[index2] == this.game.Data.RegimeObj[index1].ExtraGraphicUse)
              watermark = this.game.Data.SFTypeObj[type].ExtraPicSpriteID[index2];
          }
        }
        else if (people > -1 && this.game.Data.PeopleObj[people].ExtraGraphicUse > -1)
        {
          int extraCounter = this.game.Data.SFTypeObj[type].ExtraCounter;
          for (int index3 = 0; index3 <= extraCounter; ++index3)
          {
            if (this.game.Data.SFTypeObj[type].ExtraCode[index3] == this.game.Data.PeopleObj[people].ExtraGraphicUse)
              watermark = this.game.Data.SFTypeObj[type].ExtraPicSpriteID[index3];
          }
        }
      }
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref graphics, 0, 0, 880, 580, watermark);
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
      int typ = this.sftyp;
      int pplnr = this.game.Data.Turn <= -1 ? 0 : this.game.Data.RegimeObj[this.game.Data.Turn].People;
      string str1 = "";
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
      int regnr;
      int num1;
      int num2;
      Rectangle rectangle1;
      Rectangle trect;
      if (typ > -1)
      {
        string name = this.game.Data.SFTypeObj[typ].Name;
        if (this.game.Data.RegimeObj[index1].ExtraGraphicUse > -1)
        {
          int extraCounter = this.game.Data.SFTypeObj[typ].ExtraCounter;
          for (int index4 = 0; index4 <= extraCounter; ++index4)
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
          int extraCounter = this.game.Data.SFTypeObj[typ].ExtraCounter;
          for (int index6 = 0; index6 <= extraCounter; ++index6)
          {
            if (this.game.Data.SFTypeObj[typ].ExtraCode[index6] == this.game.Data.PeopleObj[pplnr].ExtraGraphicUse)
              name = this.game.Data.SFTypeObj[typ].ExtraName[index6];
          }
        }
        string str2 = str1 + name;
        SizeF sizeF1 = new SizeF();
        if (this.comparenr == -1)
        {
          SizeF sizeF2 = graphics.MeasureString(name + " trooptype details", this.game.MarcFont1);
          DrawMod.DrawTextColouredMarc(ref graphics, name + " trooptype details", this.game.MarcFont1, 417 - (int) Math.Round((double) (sizeF2.Width / 2f)), 19, Color.White);
        }
        index1 = 0;
        regnr = this.sfnr <= -1 ? this.game.Data.Turn : this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime;
        int picSpriteId = this.game.Data.SFTypeObj[typ].PicSpriteID;
        if (this.game.Data.RegimeObj[regnr].ExtraGraphicUse > -1)
        {
          int extraCounter = this.game.Data.SFTypeObj[typ].ExtraCounter;
          for (int index7 = 0; index7 <= extraCounter; ++index7)
          {
            if (this.game.Data.SFTypeObj[typ].ExtraCode[index7] == this.game.Data.RegimeObj[regnr].ExtraGraphicUse)
              picSpriteId = this.game.Data.SFTypeObj[typ].ExtraPicSpriteID[index7];
          }
        }
        else if (pplnr > -1 && this.game.Data.PeopleObj[pplnr].ExtraGraphicUse > -1)
        {
          int extraCounter = this.game.Data.SFTypeObj[typ].ExtraCounter;
          for (int index8 = 0; index8 <= extraCounter; ++index8)
          {
            if (this.game.Data.SFTypeObj[typ].ExtraCode[index8] == this.game.Data.PeopleObj[pplnr].ExtraGraphicUse)
              picSpriteId = this.game.Data.SFTypeObj[typ].ExtraPicSpriteID[index8];
          }
        }
        if (typ > -1)
        {
          num1 = 450;
          int num3 = 20;
          if (this.comparenr > -1)
          {
            num1 = 160;
            num2 = 450;
          }
          if (this.comparenr > -1)
          {
            int sidewaysSpriteId1 = this.game.Data.SFTypeObj[typ].SidewaysSpriteID;
            DrawMod.DrawBlockGradient2(ref graphics, num1 + 60, num3, 139, 79, this.game.MarcCol1, this.game.MarcCol2);
            ref Graphics local1 = ref graphics;
            Bitmap bitmap1 = BitmapStore.GetBitmap(sidewaysSpriteId1);
            ref Bitmap local2 = ref bitmap1;
            Rectangle rectangle2 = new Rectangle(0, 0, BitmapStore.GetWidth(sidewaysSpriteId1), BitmapStore.Getheight(sidewaysSpriteId1));
            Rectangle srcrect1 = rectangle2;
            rectangle1 = new Rectangle(num1 + 60, num3, 140, 80);
            Rectangle destrect1 = rectangle1;
            DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
            DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref graphics, num1 + 60, num3, 140, 80, -1, -1);
            int sidewaysSpriteId2 = this.game.Data.SFTypeObj[this.comparenr].SidewaysSpriteID;
            DrawMod.DrawBlockGradient2(ref graphics, num2 + 60, num3, 139, 79, this.game.MarcCol1, this.game.MarcCol2);
            ref Graphics local3 = ref graphics;
            Bitmap bitmap2 = BitmapStore.GetBitmap(sidewaysSpriteId2);
            ref Bitmap local4 = ref bitmap2;
            rectangle1 = new Rectangle(0, 0, BitmapStore.GetWidth(sidewaysSpriteId2), BitmapStore.Getheight(sidewaysSpriteId2));
            Rectangle srcrect2 = rectangle1;
            rectangle2 = new Rectangle(num2 + 60, num3, 140, 80);
            Rectangle destrect2 = rectangle2;
            DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
            DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref graphics, num2 + 60, num3, 140, 80, -1, -1);
          }
          else if (this.comparenr == -1)
          {
            int sidewaysSpriteId = this.game.Data.SFTypeObj[typ].SidewaysSpriteID;
            if (this.game.Data.SFTypeObj[typ].Theater == 0 || this.game.Data.SFTypeObj[typ].Theater == 1 || this.game.Data.SFTypeObj[typ].Theater != 2)
              ;
            int x = num1 - 310;
            int y = 77;
            int index9 = (int) Math.Round((double) this.game.Data.RuleVar[873]);
            int index10 = 0;
            if ((double) this.game.Data.RuleVar[848] > 0.0 & this.game.Data.SFTypeObj[typ].Theater == 2)
            {
              index9 = (int) Math.Round((double) this.game.Data.RuleVar[848]);
              index10 = 0;
            }
            if ((double) this.game.Data.RuleVar[872] > 0.0 & this.game.Data.SFTypeObj[typ].Theater == 1)
            {
              index9 = (int) Math.Round((double) this.game.Data.RuleVar[872]);
              index10 = 0;
            }
            int nr1 = this.game.Data.LandscapeTypeObj[index9].BasicPicID[index10];
            ref Graphics local5 = ref graphics;
            Bitmap bitmap3 = BitmapStore.GetBitmap(nr1);
            ref Bitmap local6 = ref bitmap3;
            rectangle1 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr1));
            Rectangle srcrect3 = rectangle1;
            trect = new Rectangle(x, y, 280, 160);
            Rectangle destrect3 = trect;
            DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
            int nr2 = this.game.Data.LandscapeTypeObj[index9].SidewaysSPriteID1[index10];
            ref Graphics local7 = ref graphics;
            Bitmap bitmap4 = BitmapStore.GetBitmap(nr2);
            ref Bitmap local8 = ref bitmap4;
            rectangle1 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr2));
            Rectangle srcrect4 = rectangle1;
            trect = new Rectangle(x, y, 280, 160);
            Rectangle destrect4 = trect;
            DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
            if (this.game.Data.SFTypeObj[typ].Theater != 2)
            {
              int nr3 = this.game.Data.LandscapeTypeObj[index9].SidewaysSPriteID2[index10];
              ref Graphics local9 = ref graphics;
              Bitmap bitmap5 = BitmapStore.GetBitmap(nr3);
              ref Bitmap local10 = ref bitmap5;
              rectangle1 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr3));
              Rectangle srcrect5 = rectangle1;
              trect = new Rectangle(x, y, 280, 160);
              Rectangle destrect5 = trect;
              DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
            }
            ref Graphics local11 = ref graphics;
            Bitmap bitmap6 = BitmapStore.GetBitmap(sidewaysSpriteId);
            ref Bitmap local12 = ref bitmap6;
            rectangle1 = new Rectangle(0, 0, BitmapStore.GetWidth(sidewaysSpriteId), BitmapStore.Getheight(sidewaysSpriteId));
            Rectangle srcrect6 = rectangle1;
            trect = new Rectangle(x, y, 280, 160);
            Rectangle destrect6 = trect;
            DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
            if (this.game.Data.SFTypeObj[typ].Theater != 2)
            {
              int nr4 = this.game.Data.LandscapeTypeObj[index9].SidewaysSPriteID3[index10];
              ref Graphics local13 = ref graphics;
              Bitmap bitmap7 = BitmapStore.GetBitmap(nr4);
              ref Bitmap local14 = ref bitmap7;
              rectangle1 = new Rectangle(0, 0, 138, BitmapStore.Getheight(nr4));
              Rectangle srcrect7 = rectangle1;
              trect = new Rectangle(x, y, 280, 160);
              Rectangle destrect7 = trect;
              DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
            }
            DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref graphics, x, y, 280, 160, -1, -1);
          }
        }
      }
      string str3 = this.game.Data.SFTypeObj[typ].Description;
      if (Strings.InStr(str3, "[tab]") == 0)
        str3 = "[tab]" + this.game.Data.SFTypeObj[typ].Name + " : Troop type description," + str3 + "[/tab]";
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 560, (int) Math.Round(Conversion.Int(160.0 / 17.0)), this.game.MarcFont8, str3, 17, ref this.OwnBitmap, 300, 290);
      this.descid = this.AddSubPart(ref tsubpart1, 300, 290, 560, (int) Math.Round((Conversion.Int(160.0 / 17.0) + 1.0) * 17.0), 0);
      StringListClass tListobj1 = new StringListClass(1);
      int index11 = -1;
      int num4 = -1;
      tListobj1.AddCol(0, "");
      tListobj1.AddCol(0, "");
      tListobj1.AddCol(0, "");
      tListobj1.AddCol(0, "");
      tListobj1.TempColumBmp[0] = Conversions.ToString(this.ReturnSFSpriteNr(typ, regnr, pplnr));
      tListobj1.ColumnName[1] = this.game.Data.SFTypeObj[typ].Ratio <= 1 ? Strings.UCase(this.game.Data.SFTypeObj[typ].Name) : Strings.UCase(this.game.Data.SFTypeObj[typ].Name) + " (" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[typ].Ratio)) + "x)";
      int index12 = 0;
      do
      {
        if (Strings.Len(this.game.Data.SFTypeObj[typ].LogoString[index12]) > 0 && Operators.CompareString(this.game.Data.SFTypeObj[typ].LogoString[index12], "0", false) != 0)
        {
          if ((num4 + 10) % 2 > 0)
          {
            ++index11;
            ++num4;
            tListobj1.AddRow(tListobj1.Length);
            if ((double) this.game.Data.RuleVar[947] == 1.0)
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
            ++num4;
            if ((double) this.game.Data.RuleVar[947] == 1.0)
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
        ++index12;
      }
      while (index12 <= 99);
      int tlistsize1 = 4;
      int num5 = 110;
      if (this.comparenr == -1)
        num5 = 77;
      SubPartClass tsubpart2 = (SubPartClass) new MatrixSubPartClass(tListobj1, tlistsize1, 260, -1, -1, this.game, tbackbitmap: (ref this.OwnBitmap), bbx: num1, bby: num5, trowheight: 26, tfontsize: 18, tfontoffsety: 2, tnolines: true, tMarcy: true, tMinColValue: 40);
      this.LogoListId = this.AddSubPart(ref tsubpart2, num1, num5, 260, (tlistsize1 + 3) * 26, 0);
      if (this.comparenr > -1)
      {
        StringListClass tListobj2 = new StringListClass(1);
        int index13 = -1;
        int num6 = -1;
        tListobj2.AddCol(0, "");
        tListobj2.AddCol(0, "");
        tListobj2.AddCol(0, "");
        tListobj2.AddCol(0, "");
        tListobj2.TempColumBmp[0] = Conversions.ToString(this.ReturnSFSpriteNr(this.comparenr, regnr, pplnr));
        tListobj2.ColumnName[1] = this.game.Data.SFTypeObj[this.comparenr].Ratio <= 1 ? Strings.UCase(this.game.Data.SFTypeObj[this.comparenr].Name) : Strings.UCase(this.game.Data.SFTypeObj[this.comparenr].Name) + " (" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].Ratio)) + "x)";
        int index14 = 0;
        do
        {
          if (Strings.Len(this.game.Data.SFTypeObj[this.comparenr].LogoString[index14]) > 0 && Operators.CompareString(this.game.Data.SFTypeObj[this.comparenr].LogoString[index14], "0", false) != 0)
          {
            if ((num6 + 10) % 2 > 0)
            {
              ++index13;
              ++num6;
              tListobj2.AddRow(tListobj2.Length);
              if ((double) this.game.Data.RuleVar[947] == 1.0)
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
              ++num6;
              if ((double) this.game.Data.RuleVar[947] == 1.0)
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
          ++index14;
        }
        while (index14 <= 99);
        int tlistsize2 = 4;
        SubPartClass tsubpart3 = (SubPartClass) new MatrixSubPartClass(tListobj2, tlistsize2, 260, -1, -1, this.game, tbackbitmap: (ref this.OwnBitmap), bbx: num2, bby: 110, trowheight: 26, tfontsize: 18, tfontoffsety: 2, tnolines: true, tMarcy: true, tMinColValue: 40);
        this.logolist3id = this.AddSubPart(ref tsubpart3, num2, 110, 260, (tlistsize2 + 3) * 26, 0);
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
          this.OptionsList3Obj = new ListClass();
          this.OptionsList3Obj.add("People", -1, this.game.Data.PeopleObj[this.game.Data.SFObj[this.sfnr].People].Name);
          float num7 = this.game.Data.PeopleObj[this.game.Data.SFObj[this.sfnr].People].BattleForMod[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.UnitObj[this.unr].Regime].People].PeopleGroup];
          if ((double) num7 > 1.0 | (double) num7 < 1.0)
          {
            int Number = (int) Math.Round((double) ((num7 - 1f) * 100f));
            string tvalue = Strings.Trim(Conversion.Str((object) Number)) + "%";
            if (Number >= 0)
              tvalue = "+" + tvalue;
            this.OptionsList3Obj.add("People Combat Bonus", -1, tvalue);
          }
          this.OptionsList3Obj.add("Class", -1, this.game.Data.TempString[400 + this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].UnitGroup]);
          if (reconMinusHide.x == 3)
          {
            this.OptionsList3Obj.add("Qty", -1, Strings.Trim(Conversion.Str((object) (this.game.Data.SFObj[this.sfnr].Qty * this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].Ratio))));
            this.OptionsList3Obj.add("Readiness", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Rdn)));
            this.OptionsList3Obj.add("Morale", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Mor)));
            this.OptionsList3Obj.add("Experience", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Xp)));
            this.OptionsList3Obj.add("Entrenchment", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].CurrentEntrench)));
            this.OptionsList3Obj.add("Action Points", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Ap)));
            this.OptionsList3Obj.add("Engineer Points", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].EP)));
            this.OptionsList3Obj.add("Ratio", -1, "x" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].Ratio)));
            this.OptionsList3Obj.add("Individuals", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[this.sfnr].Qty)));
            this.OptionsList3Obj.add("Weight/Carry", -1, Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].Weight)) + "/" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].CarryCap)));
          }
          if (this.OptionsList3Id > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, -1);
            this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
          }
          else
          {
            ListClass optionsList3Obj = this.OptionsList3Obj;
            GameClass game = this.game;
            ref Bitmap local15 = ref this.OwnBitmap;
            Font font = (Font) null;
            ref Font local16 = ref font;
            SubPartClass tsubpart4 = (SubPartClass) new ListSubPartClass(optionsList3Obj, 11, 260, -1, game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 100, tdotopandbottom: false, tbackbitmap: (ref local15), bbx: 20, bby: 308, tMarcStyle: true, overruleFont: (ref local16));
            this.OptionsList3Id = this.AddSubPart(ref tsubpart4, 20, 308, 260, 192, 0);
          }
          DrawMod.DrawTextColouredMarc(ref graphics, "SELECTED TROOPS STATS", this.game.MarcFont5, 90, 291, Color.White);
          rectangle1 = new Rectangle(20, 335, 290, 144);
          trect = rectangle1;
          this.AddMouse(ref trect, "", "The troops in the slot you clicked\r\nhave their own detailed stats.");
        }
      }
      SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("OK", 150, "Click to return to main screen.", ref this.OwnBitmap, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + 15.0), 515, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.but1id = this.AddSubPart(ref tsubpart5, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + 15.0), 515, 150, 40, 1);
      SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("COMPARE", 150, "Click to select another trooptype to compare stats with.", ref this.OwnBitmap, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 - 175.0), 515, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.but7id = this.AddSubPart(ref tsubpart6, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 - 175.0), 515, 150, 40, 1);
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
            new Form3((Form) this.formref).Initialize(this.game.Data, 74, -1);
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
