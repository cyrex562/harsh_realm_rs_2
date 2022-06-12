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
  public class SFWindowClass3 : WindowClass
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

    public SFWindowClass3(ref GameClass tGame)
      : base(ref tGame, 880, 768, 8)
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
      Color marcCol1 = this.game.MarcCol1;
      Color marcCol2 = this.game.MarcCol2;
      Color c2_1 = Color.FromArgb(200, 40, 25, 15);
      Color c1 = Color.FromArgb(100, 80, 50, 29);
      Color c2_2 = Color.FromArgb(200, 120, 75, 45);
      this.ClearMouse();
      this.NewBackGroundAndClearAll(880, 768, -1);
      Graphics graphics1 = Graphics.FromImage((Image) this.OwnBitmap);
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
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref graphics1, 0, 0, 880, 768, watermark);
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
      string str2;
      int regnr;
      int num1;
      int num2;
      int num3;
      Rectangle rectangle1;
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
        str2 = str1 + name;
        SizeF sizeF = new SizeF();
        index1 = 0;
        regnr = this.sfnr <= -1 ? this.game.Data.Turn : this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime;
        num1 = this.game.Data.SFTypeObj[typ].PicSpriteID;
        if (this.game.Data.RegimeObj[regnr].ExtraGraphicUse > -1)
        {
          int extraCounter = this.game.Data.SFTypeObj[typ].ExtraCounter;
          for (int index7 = 0; index7 <= extraCounter; ++index7)
          {
            if (this.game.Data.SFTypeObj[typ].ExtraCode[index7] == this.game.Data.RegimeObj[regnr].ExtraGraphicUse)
              num1 = this.game.Data.SFTypeObj[typ].ExtraPicSpriteID[index7];
          }
        }
        else if (pplnr > -1 && this.game.Data.PeopleObj[pplnr].ExtraGraphicUse > -1)
        {
          int extraCounter = this.game.Data.SFTypeObj[typ].ExtraCounter;
          for (int index8 = 0; index8 <= extraCounter; ++index8)
          {
            if (this.game.Data.SFTypeObj[typ].ExtraCode[index8] == this.game.Data.PeopleObj[pplnr].ExtraGraphicUse)
              num1 = this.game.Data.SFTypeObj[typ].ExtraPicSpriteID[index8];
          }
        }
        if (typ > -1)
        {
          num2 = 540;
          int num4 = 20;
          if (this.comparenr > -1)
          {
            num2 = 160;
            num3 = 450;
          }
          if (this.comparenr > -1)
          {
            int sidewaysSpriteId1 = this.game.Data.SFTypeObj[typ].SidewaysSpriteID;
            DrawMod.DrawBlockGradient2(ref graphics1, num2 + 60, num4, 139, 79, c1, c2_2);
            ref Graphics local1 = ref graphics1;
            Bitmap bitmap1 = BitmapStore.GetBitmap(sidewaysSpriteId1);
            ref Bitmap local2 = ref bitmap1;
            int sftypenr = typ;
            int ppl1 = pplnr;
            int tx1 = num2 + 60;
            int ty1 = num4;
            DrawMod.DrawWithArtCode(ref local1, ref local2, 420, 240, sftypenr, ppl1, tx1, ty1, 140, 80);
            DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref graphics1, num2 + 60, num4, 140, 80, -1, -1);
            int sidewaysSpriteId2 = this.game.Data.SFTypeObj[this.comparenr].SidewaysSpriteID;
            DrawMod.DrawBlockGradient2(ref graphics1, num3 + 60, num4, 139, 79, c1, c2_2);
            ref Graphics local3 = ref graphics1;
            Bitmap bitmap2 = BitmapStore.GetBitmap(sidewaysSpriteId2);
            ref Bitmap local4 = ref bitmap2;
            int comparenr = this.comparenr;
            int ppl2 = pplnr;
            int tx2 = num3 + 60;
            int ty2 = num4;
            DrawMod.DrawWithArtCode(ref local3, ref local4, 420, 240, comparenr, ppl2, tx2, ty2, 140, 80);
            DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref graphics1, num3 + 60, num4, 140, 80, -1, -1);
          }
          else if (this.comparenr == -1)
          {
            int sidewaysSpriteId = this.game.Data.SFTypeObj[typ].SidewaysSpriteID;
            if (this.game.Data.SFTypeObj[typ].Theater == 0 || this.game.Data.SFTypeObj[typ].Theater == 1 || this.game.Data.SFTypeObj[typ].Theater != 2)
              ;
            int num5 = 74;
            int num6 = 36;
            Rectangle rectangle2;
            if (this.game.SelectX > -1 & this.sfnr > -1 & this.game.SelectY > -1)
            {
              int landscapeType = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType;
              int newGfxSkyEventPic = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxSkyEventPic;
              int newGfxSkyX = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxSkyX;
              int newGfxSkyY = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxSkyY;
              if (newGfxSkyEventPic > -1)
              {
                ref Graphics local5 = ref graphics1;
                Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[newGfxSkyEventPic]);
                ref Bitmap local6 = ref bitmap;
                rectangle2 = new Rectangle(newGfxSkyX * 420, newGfxSkyY * 240, 420, 240);
                Rectangle srcrect = rectangle2;
                rectangle1 = new Rectangle(num5, num6, 420, 240);
                Rectangle destrect = rectangle1;
                DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect, destrect);
              }
              int backgroundEventPic1 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxBackgroundEventPic;
              int newGfxBackgroundX = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxBackgroundX;
              int newGfxBackgroundY = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxBackgroundY;
              if (backgroundEventPic1 > -1)
              {
                ref Graphics local7 = ref graphics1;
                Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[backgroundEventPic1]);
                ref Bitmap local8 = ref bitmap;
                rectangle1 = new Rectangle(newGfxBackgroundX * 420, newGfxBackgroundY * 240, 420, 240);
                Rectangle srcrect = rectangle1;
                rectangle2 = new Rectangle(num5, num6, 420, 240);
                Rectangle destrect = rectangle2;
                DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect, destrect);
              }
              int backgroundEventPic2 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxWeatherBackgroundEventPic;
              int weatherBackgroundX = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxWeatherBackgroundX;
              int weatherBackgroundY = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxWeatherBackgroundY;
              if (backgroundEventPic2 > -1)
              {
                ref Graphics local9 = ref graphics1;
                Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[backgroundEventPic2]);
                ref Bitmap local10 = ref bitmap;
                rectangle1 = new Rectangle(weatherBackgroundX * 420, weatherBackgroundY * 240, 420, 240);
                Rectangle srcrect = rectangle1;
                rectangle2 = new Rectangle(num5, num6, 420, 240);
                Rectangle destrect = rectangle2;
                DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
              }
            }
            else
            {
              DrawMod.DrawBlockGradient2(ref graphics1, num5, num6, 419, 239, Color.Transparent, c2_2);
              DrawMod.DrawBlockGradient2(ref graphics1, num5, num6 + 160, 419, 79, c1, c2_1);
            }
            Graphics graphics2 = graphics1;
            rectangle1 = new Rectangle(num5, num6, 420, 240);
            Rectangle rect1 = rectangle1;
            graphics2.SetClip(rect1);
            if (this.game.Data.RegimeObj[this.game.Data.UnitObj[this.unr].Regime].Mirror)
            {
              Matrix matrix = new Matrix();
              matrix.Scale(-1f, 1f);
              matrix.Translate((float) -(2 * num5 + 420), 0.0f);
              graphics1.Transform = matrix;
              ref Graphics local11 = ref graphics1;
              Bitmap bitmap = BitmapStore.GetBitmap(sidewaysSpriteId);
              ref Bitmap local12 = ref bitmap;
              int sftypenr = typ;
              int ppl = pplnr;
              int tx = num5;
              int ty = num6 + 28;
              DrawMod.DrawWithArtCode(ref local11, ref local12, 420, 240, sftypenr, ppl, tx, ty, 420, 240);
              graphics1.ResetTransform();
            }
            else
            {
              ref Graphics local13 = ref graphics1;
              Bitmap bitmap = BitmapStore.GetBitmap(sidewaysSpriteId);
              ref Bitmap local14 = ref bitmap;
              int sftypenr = typ;
              int ppl = pplnr;
              int tx = num5;
              int ty = num6 + 28;
              DrawMod.DrawWithArtCode(ref local13, ref local14, 420, 240, sftypenr, ppl, tx, ty, 420, 240);
            }
            Graphics graphics3 = graphics1;
            rectangle1 = new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height);
            Rectangle rect2 = rectangle1;
            graphics3.SetClip(rect2);
            if (this.game.SelectX > -1 & this.sfnr > -1 & this.game.SelectY > -1)
            {
              int landscapeType = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType;
              int foregroundEventPic1 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxForegroundEventPic;
              int newGfxForegroundX = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxForegroundX;
              int newGfxForegroundY = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxForegroundY;
              if (foregroundEventPic1 > -1)
              {
                ref Graphics local15 = ref graphics1;
                Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[foregroundEventPic1]);
                ref Bitmap local16 = ref bitmap;
                rectangle1 = new Rectangle(newGfxForegroundX * 420, newGfxForegroundY * 240, 420, 240);
                Rectangle srcrect = rectangle1;
                rectangle2 = new Rectangle(num5, num6, 420, 240);
                Rectangle destrect = rectangle2;
                DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect, destrect);
              }
              int foregroundEventPic2 = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxWeatherForegroundEventPic;
              int weatherForegroundX = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxWeatherForegroundX;
              int weatherForegroundY = this.game.Data.LandscapeTypeObj[landscapeType].NewGfxWeatherForegroundY;
              if (foregroundEventPic2 > -1)
              {
                ref Graphics local17 = ref graphics1;
                Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[foregroundEventPic2]);
                ref Bitmap local18 = ref bitmap;
                rectangle1 = new Rectangle(weatherForegroundX * 420, weatherForegroundY * 240, 420, 240);
                Rectangle srcrect = rectangle1;
                rectangle2 = new Rectangle(num5, num6, 420, 240);
                Rectangle destrect = rectangle2;
                DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect, destrect);
              }
            }
            if (this.comparenr == -1)
              sizeF = graphics1.MeasureString(name, this.game.MarcFont1);
          }
        }
      }
      string str3 = this.game.Data.SFTypeObj[typ].Description;
      if (Strings.InStr(str3, "[tab]") == 0)
        str3 = "[tab]" + this.game.Data.SFTypeObj[typ].Name + " (" + this.game.Data.TempString[400 + this.game.Data.SFTypeObj[typ].UnitGroup] + ")," + str3 + "[/tab]";
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 560, (int) Math.Round(Conversion.Int(160.0 / 17.0)), this.game.MarcFont8, str3, 17, ref this.OwnBitmap, 300, 290);
      this.descid = this.AddSubPart(ref tsubpart1, 300, 290, 560, (int) Math.Round((Conversion.Int(160.0 / 17.0) + 2.0) * 17.0), 0);
      string tvalue2_1 = "";
      this.OptionsList2Obj = new ListClass();
      string tvalue1 = this.game.Data.SFTypeObj[typ].SupplyCarry.ToString();
      if (this.comparenr > -1)
        tvalue2_1 = this.game.Data.SFTypeObj[this.comparenr].SupplyCarry.ToString();
      this.OptionsList2Obj.add("Supply max organic storage", -1, tvalue1, tvalue2_1);
      string tvalue2 = this.game.Data.SFTypeObj[typ].BasicSupplyNeed.ToString();
      if (this.comparenr > -1)
        tvalue2_1 = this.game.Data.SFTypeObj[this.comparenr].BasicSupplyNeed.ToString();
      this.OptionsList2Obj.add("Basic Supply use", -1, tvalue2, tvalue2_1);
      int num7 = 10;
      if (this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].EndCombatRound > 0 & this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].EndCombatRound < num7)
        num7 = this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].EndCombatRound - this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].StartCombatRound;
      string tvalue3 = Math.Round((double) this.game.Data.SFTypeObj[typ].SupplyForAttack / (double) num7, 2).ToString();
      int num8 = 10;
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
      string tvalue4 = num9.ToString();
      if (this.comparenr > -1)
      {
        num9 = Math.Round((double) this.game.Data.SFTypeObj[this.comparenr].SupplyForAttackDef / (double) num8, 2);
        tvalue2_1 = num9.ToString();
      }
      this.OptionsList2Obj.add("Supply per Def Combat round", -1, tvalue4, tvalue2_1);
      string tvalue5 = this.game.Data.SFTypeObj[typ].SupplyMaxIn.ToString();
      if (this.comparenr > -1)
        tvalue2_1 = this.game.Data.SFTypeObj[this.comparenr].SupplyMaxIn.ToString();
      this.OptionsList2Obj.add("Supply max Replenish per turn", -1, tvalue5, tvalue2_1);
      string tvalue6 = "";
      string tvalue2_2 = "";
      this.OptionsList2Obj.add("----", -1, tvalue6, tvalue2_2);
      string tvalue7 = this.game.Data.SFTypeObj[typ].FuelCarry.ToString();
      if (this.comparenr > -1)
        tvalue2_2 = this.game.Data.SFTypeObj[this.comparenr].FuelCarry.ToString();
      this.OptionsList2Obj.add("Fuel max organic storage", -1, tvalue7, tvalue2_2);
      string tvalue8 = this.game.Data.SFTypeObj[typ].FuelForMove.ToString();
      if (this.comparenr > -1)
        tvalue2_2 = this.game.Data.SFTypeObj[this.comparenr].FuelForMove.ToString();
      this.OptionsList2Obj.add("Fuel for 10AP Move", -1, tvalue8, tvalue2_2);
      string tvalue9 = this.game.Data.SFTypeObj[typ].FuelForAttack.ToString();
      if (this.comparenr > -1)
        tvalue2_2 = this.game.Data.SFTypeObj[this.comparenr].FuelForAttack.ToString();
      this.OptionsList2Obj.add("Fuel per Off Combat Round", -1, tvalue9, tvalue2_2);
      string tvalue10 = this.game.Data.SFTypeObj[typ].FuelForAttackDef.ToString();
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
        GameClass game = this.game;
        ref Bitmap local19 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local20 = ref font;
        SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(optionsList2Obj, 9, 260, -1, game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 100, tdotopandbottom: false, tbackbitmap: (ref local19), bbx: 300, bby: 520, tMarcStyle: true, overruleFont: (ref local20));
        this.OptionsList2Id = this.AddSubPart(ref tsubpart2, 300, 520, 260, 160, 0);
      }
      DrawMod.DrawTextColouredMarc(ref graphics1, "SUPPLY & FUEL STATS", this.game.MarcFont5, 300, 500, Color.White);
      bool flag = false;
      if (this.game.Data.SFTypeObj[typ].ArtRange > 0 | this.game.Data.SFTypeObj[typ].directRange > 0)
        flag = true;
      if (this.comparenr > -1 && this.game.Data.SFTypeObj[this.comparenr].ArtRange > 0 | this.game.Data.SFTypeObj[this.comparenr].directRange > 0)
        flag = true;
      this.OptionsList4Obj = new ListClass();
      if (flag)
      {
        num1 = 0;
        int val2 = Math.Max(this.game.Data.SFTypeObj[typ].ArtRange, this.game.Data.SFTypeObj[typ].directRange);
        if (this.comparenr > -1)
          val2 = Math.Max(Math.Max(this.game.Data.SFTypeObj[this.comparenr].ArtRange, this.game.Data.SFTypeObj[this.comparenr].directRange), val2);
        int num10 = Math.Min(9, val2);
        for (int index9 = 1; index9 <= num10; ++index9)
        {
          int num11 = 0;
          str2 = "";
          if (this.game.Data.SFTypeObj[typ].ArtRange >= index9)
            num11 = 100;
          else if (this.game.Data.SFTypeObj[typ].directRange >= index9)
          {
            num11 = this.game.Data.SFTypeObj[typ].directModFirstHex;
            int num12 = index9;
            for (int index10 = 2; index10 <= num12; ++index10)
              num11 = (int) Math.Round(Math.Floor((double) (num11 * this.game.Data.SFTypeObj[typ].directModPerHex) / 100.0));
          }
          string tvalue11 = num11.ToString() + "%";
          string tvalue2_3 = "";
          if (this.comparenr > -1)
          {
            int num13 = 0;
            if (this.game.Data.SFTypeObj[this.comparenr].ArtRange >= index9)
              num13 = 100;
            else if (this.game.Data.SFTypeObj[this.comparenr].directRange >= index9)
            {
              num13 = this.game.Data.SFTypeObj[this.comparenr].directModFirstHex;
              int num14 = index9;
              for (int index11 = 2; index11 <= num14; ++index11)
                num13 = (int) Math.Round(Math.Floor((double) (num13 * this.game.Data.SFTypeObj[this.comparenr].directModPerHex) / 100.0));
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
        GameClass game = this.game;
        ref Bitmap local21 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local22 = ref font;
        SubPartClass tsubpart3 = (SubPartClass) new ListSubPartClass(optionsList4Obj, 9, 260, -1, game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 100, tdotopandbottom: false, tbackbitmap: (ref local21), bbx: 600, bby: 520, tMarcStyle: true, overruleFont: (ref local22));
        this.OptionsList4Id = this.AddSubPart(ref tsubpart3, 600, 520, 260, 160, 0);
      }
      DrawMod.DrawTextColouredMarc(ref graphics1, "RANGED WEAPONS", this.game.MarcFont5, 600, 500, Color.White);
      StringListClass tListobj1 = new StringListClass(1);
      int index12 = -1;
      int num15 = -1;
      tListobj1.AddCol(0, "");
      tListobj1.AddCol(0, "");
      tListobj1.AddCol(0, "");
      tListobj1.AddCol(0, "");
      if ((double) this.game.Data.RuleVar[492] < 1.0)
        tListobj1.TempColumBmp[0] = Conversions.ToString(this.ReturnSFSpriteNr(typ, regnr, pplnr));
      tListobj1.ColumnName[1] = this.game.Data.SFTypeObj[typ].Ratio <= 1 ? Strings.UCase(this.game.Data.SFTypeObj[typ].Name) + " stats" : Strings.UCase(this.game.Data.SFTypeObj[typ].Name) + " (" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[typ].Ratio)) + "x) stats";
      int index13 = 0;
      do
      {
        if (Strings.Len(this.game.Data.SFTypeObj[typ].LogoString[index13]) > 0 && Operators.CompareString(this.game.Data.SFTypeObj[typ].LogoString[index13], "0", false) != 0)
        {
          if ((num15 + 10) % 2 > 0)
          {
            ++index12;
            ++num15;
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
            ++num15;
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
        ++index13;
      }
      while (index13 <= 99);
      int tlistsize1 = 4;
      int num16 = 110;
      if (this.comparenr == -1)
        num16 = 77;
      SubPartClass tsubpart4 = (SubPartClass) new MatrixSubPartClass(tListobj1, tlistsize1, 260, -1, -1, this.game, tbackbitmap: (ref this.OwnBitmap), bbx: num2, bby: num16, trowheight: 26, tfontsize: 18, tfontoffsety: 2, tnolines: true, tMarcy: true, tMinColValue: 40);
      this.LogoListId = this.AddSubPart(ref tsubpart4, num2, num16, 260, (tlistsize1 + 3) * 26, 0);
      if (this.comparenr > -1)
      {
        StringListClass tListobj2 = new StringListClass(1);
        int index14 = -1;
        int num17 = -1;
        tListobj2.AddCol(0, "");
        tListobj2.AddCol(0, "");
        tListobj2.AddCol(0, "");
        tListobj2.AddCol(0, "");
        if ((double) this.game.Data.RuleVar[492] < 1.0)
          tListobj2.TempColumBmp[0] = Conversions.ToString(this.ReturnSFSpriteNr(this.comparenr, regnr, pplnr));
        tListobj2.ColumnName[1] = this.game.Data.SFTypeObj[this.comparenr].Ratio <= 1 ? Strings.UCase(this.game.Data.SFTypeObj[this.comparenr].Name) : Strings.UCase(this.game.Data.SFTypeObj[this.comparenr].Name) + " (" + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.comparenr].Ratio)) + "x)";
        int index15 = 0;
        do
        {
          if (Strings.Len(this.game.Data.SFTypeObj[this.comparenr].LogoString[index15]) > 0 && Operators.CompareString(this.game.Data.SFTypeObj[this.comparenr].LogoString[index15], "0", false) != 0)
          {
            if ((num17 + 10) % 2 > 0)
            {
              ++index14;
              ++num17;
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
              ++num17;
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
          ++index15;
        }
        while (index15 <= 99);
        int tlistsize2 = 4;
        SubPartClass tsubpart5 = (SubPartClass) new MatrixSubPartClass(tListobj2, tlistsize2, 260, -1, -1, this.game, tbackbitmap: (ref this.OwnBitmap), bbx: num3, bby: 110, trowheight: 26, tfontsize: 18, tfontoffsety: 2, tnolines: true, tMarcy: true, tMinColValue: 40);
        this.logolist3id = this.AddSubPart(ref tsubpart5, num3, 110, 260, (tlistsize2 + 3) * 26, 0);
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
          float num18 = this.game.Data.PeopleObj[this.game.Data.SFObj[this.sfnr].People].BattleForMod[this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.UnitObj[this.unr].Regime].People].PeopleGroup];
          if ((double) num18 > 1.0 | (double) num18 < 1.0)
          {
            int Number = (int) Math.Round((double) ((num18 - 1f) * 100f));
            string tvalue12 = Strings.Trim(Conversion.Str((object) Number)) + "%";
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
            this.OptionsList3Obj.add("Base Morale", -1, ((int) Math.Round((double) this.game.Data.PeopleObj[pplnr].BaseMorale[this.game.Data.RegimeObj[regnr].People] * ((double) this.game.Data.RegimeObj[regnr].BaseMorale / 100.0))).ToString());
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
            string tvalue13 = this.game.Data.TempString[this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].MoveType];
            this.OptionsList3Obj.add("Move Type", -1, tvalue13);
            int num19 = this.game.Data.transportMovementType[this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].MoveType];
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
              this.OptionsList3Obj.add("Staff Combat Mod", -1, ((int) Math.Round((double) (100f * this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].StaffCombatMod))).ToString() + "%");
              this.OptionsList3Obj.add("Staff Morale Mod", -1, ((int) Math.Round((double) (100f * this.game.Data.SFTypeObj[this.game.Data.SFObj[this.sfnr].Type].StaffMoraleMod))).ToString() + "%");
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
            GameClass game = this.game;
            ref Bitmap local23 = ref this.OwnBitmap;
            Font font = (Font) null;
            ref Font local24 = ref font;
            SubPartClass tsubpart6 = (SubPartClass) new ListSubPartClass(optionsList3Obj, 22, 260, -1, game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 100, tdotopandbottom: false, tbackbitmap: (ref local23), bbx: 20, bby: 308, tMarcStyle: true, overruleFont: (ref local24));
            this.OptionsList3Id = this.AddSubPart(ref tsubpart6, 20, 308, 260, 460, 0);
          }
          DrawMod.DrawTextColouredMarc(ref graphics1, "SELECTED TROOPS STATS", this.game.MarcFont5, 90, 291, Color.White);
          rectangle1 = new Rectangle(20, 335, 290, 144);
          Rectangle trect = rectangle1;
          this.AddMouse(ref trect, "", "The troops in the slot you clicked\r\nhave their own detailed stats.");
        }
      }
      SubPartClass tsubpart7 = (SubPartClass) new TextButtonPartClass("OK", 150, "Click to return to main screen.", ref this.OwnBitmap, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + 15.0), 703, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.but1id = this.AddSubPart(ref tsubpart7, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 + 15.0), 703, 150, 40, 1);
      tsubpart7 = (SubPartClass) new TextButtonPartClass("COMPARE", 150, "Click to select another trooptype to compare stats with.", ref this.OwnBitmap, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 - 175.0), 703, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.but7id = this.AddSubPart(ref tsubpart7, (int) Math.Round((double) this.OwnBitmap.Width / 2.0 - 175.0), 703, 150, 40, 1);
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
