// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SFDesignWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
  pub class SFDesignWindowClass : WindowClass
  {
     int B1Id;
     int B1TextId;
     int B2Id;
     int B2TextId;
     int B3Id;
     int B3TextId;
     int B4Id;
     int B4TextId;
     int B5Id;
     int B5TextId;
     int B6Id;
     int B6TextId;
     int B7Id;
     int b7bid;
     int B7TextId;
     int B8Id;
     int b8bid;
     int B8TextId;
     int B9Id;
     int b9bid;
     int B9TextId;
     int B10Id;
     int B10TextId;
     int B11Id;
     int B11TextId;
     int off1id;
     int detailnr;
     int optnr;
     int Text1Id;
     int Text2Id;
     int Text3Id;
     int Pic1Id;
     int detailnr2;
     int OrderTextId;
     int OrderText2Id;
     int OrderUpId;
     int OrderDownId;
     int ExtraId;
     int steppy;
     int typpy;
     int OptionsListId;
     ListClass OptionsListObj;
     int OptionsList2Id;
     ListClass OptionsList2Obj;
     bool Hq;

    pub void DoRefresh()
    {
      this.game.HandyFunctionsObj.CalculateSFDesignCosts();
      this.dostuff();
    }

    pub SFDesignWindowClass(
       GameClass tGame,
      Bitmap screenbitmap = null,
      let mut sx: i32 = -1,
      let mut sy: i32 = -1,
      let mut tl1: i32 = -1,
      let mut tl2: i32 = -1)
      : base( tGame, 1024, 200, 99, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.steppy = 0;
      this.typpy = -1;
      this.detailnr = -1;
      this.detailnr2 = -1;
      this.optnr = 1;
      if (tl1 > -1)
      {
        this.optnr = tl1;
        this.detailnr = tl2;
      }
      this.game.HandyFunctionsObj.CalculateSFDesignCosts();
      this.dostuff();
    }

     void dostuff()
    {
      if (this.off1id > 0)
        this.RemoveSubPart(this.off1id);
      if (this.Text1Id > 0)
        this.RemoveSubPart(this.Text1Id);
      if (this.Text2Id > 0)
        this.RemoveSubPart(this.Text2Id);
      if (this.Text3Id > 0)
        this.RemoveSubPart(this.Text3Id);
      if (this.Pic1Id > 0)
        this.RemoveSubPart(this.Pic1Id);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
      if (this.B4Id > 0)
        this.RemoveSubPart(this.B4Id);
      if (this.B4TextId > 0)
        this.RemoveSubPart(this.B4TextId);
      if (this.B5Id > 0)
        this.RemoveSubPart(this.B5Id);
      if (this.B5TextId > 0)
        this.RemoveSubPart(this.B5TextId);
      if (this.B6Id > 0)
        this.RemoveSubPart(this.B6Id);
      if (this.B6TextId > 0)
        this.RemoveSubPart(this.B6TextId);
      if (this.B7Id > 0)
        this.RemoveSubPart(this.B7Id);
      if (this.B8Id > 0)
        this.RemoveSubPart(this.B8Id);
      if (this.B9Id > 0)
        this.RemoveSubPart(this.B9Id);
      if (this.b7bid > 0)
        this.RemoveSubPart(this.b7bid);
      if (this.b8bid > 0)
        this.RemoveSubPart(this.b8bid);
      if (this.b9bid > 0)
        this.RemoveSubPart(this.b9bid);
      if (this.B10Id > 0)
        this.RemoveSubPart(this.B10Id);
      if (this.B11Id > 0)
        this.RemoveSubPart(this.B11Id);
      if (this.OrderUpId > 0)
        this.RemoveSubPart(this.OrderUpId);
      if (this.OrderDownId > 0)
        this.RemoveSubPart(this.OrderDownId);
      if (this.ExtraId > 0)
        this.RemoveSubPart(this.ExtraId);
      if (this.OrderTextId > 0)
        this.RemoveSubPart(this.OrderTextId);
      if (this.OrderText2Id > 0)
        this.RemoveSubPart(this.OrderText2Id);
      if (this.OptionsListId > 0)
        this.RemoveSubPart(this.OptionsListId);
      if (this.OptionsList2Id > 0)
        this.RemoveSubPart(this.OptionsList2Id);
      this.NewBackGroundAndClearAll(1024, 200, -1);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.optnr == 1)
      {
        let mut tsubpart: SubPartClass =  ButtonPartClass::new(this.game.BUTTONFLAGGED);
        this.B1Id = this.AddSubPart( tsubpart, 5, 10, 32, 32, 1);
      }
      else
      {
        let mut tsubpart: SubPartClass =  ButtonPartClass::new(this.game.BUTTONUNFLAGGED);
        this.B1Id = this.AddSubPart( tsubpart, 5, 10, 32, 32, 1);
      }
      let mut tsubpart1: SubPartClass =  TextPartClass::new("All", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 60, 24, false);
      this.B1TextId = this.AddSubPart( tsubpart1, 40, 9, 60, 24, 0);
      if (this.optnr == 2)
      {
        tsubpart1 =  ButtonPartClass::new(this.game.BUTTONFLAGGED);
        this.B2Id = this.AddSubPart( tsubpart1, 5, 40, 32, 32, 1);
      }
      else
      {
        tsubpart1 =  ButtonPartClass::new(this.game.BUTTONUNFLAGGED);
        this.B2Id = this.AddSubPart( tsubpart1, 5, 40, 32, 32, 1);
      }
      tsubpart1 =  TextPartClass::new("New", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 60, 24, false);
      this.B2TextId = this.AddSubPart( tsubpart1, 40, 39, 60, 24, 0);
      if (this.optnr == 3)
      {
        tsubpart1 =  ButtonPartClass::new(this.game.BUTTONFLAGGED);
        this.B3Id = this.AddSubPart( tsubpart1, 5, 70, 32, 32, 1);
      }
      else
      {
        tsubpart1 =  ButtonPartClass::new(this.game.BUTTONUNFLAGGED);
        this.B3Id = this.AddSubPart( tsubpart1, 5, 70, 32, 32, 1);
      }
      tsubpart1 =  TextPartClass::new("Upgrade", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 60, 24, false);
      this.B3TextId = this.AddSubPart( tsubpart1, 40, 69, 60, 24, 0);
      if (this.optnr == 4)
      {
        tsubpart1 =  ButtonPartClass::new(this.game.BUTTONFLAGGED);
        this.B4Id = this.AddSubPart( tsubpart1, 5, 100, 32, 32, 1);
      }
      else
      {
        tsubpart1 =  ButtonPartClass::new(this.game.BUTTONUNFLAGGED);
        this.B4Id = this.AddSubPart( tsubpart1, 5, 100, 32, 32, 1);
      }
      tsubpart1 =  TextPartClass::new("Improve", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 60, 24, false);
      this.B4TextId = this.AddSubPart( tsubpart1, 40, 99, 60, 24, 0);
      this.OptionsListObj = ListClass::new();
      let mut num1: i32 = -1;
      let mut num2: i32 = -1;
      let mut sfTypeCounter1: i32 = this.game.Data.SFTypeCounter;
      for (let mut tdata: i32 = 0; tdata <= sfTypeCounter1; tdata += 1)
      {
        let mut num3: i32 = 1;
        let mut sfTypeCounter2: i32 = this.game.Data.SFTypeCounter;
        for (let mut index: i32 = 0; index <= sfTypeCounter2; index += 1)
        {
          if (this.game.Data.SFTypeObj[index].ModelID == this.game.Data.SFTypeObj[tdata].ModelID && this.game.Data.SFTypeObj[tdata].ModelBaseModel == this.game.Data.SFTypeObj[index].ModelBaseModel && this.game.Data.SFTypeObj[tdata].ModelMark == this.game.Data.SFTypeObj[index].ModelMark && this.game.Data.SFTypeObj[tdata].ModelVersion < this.game.Data.SFTypeObj[index].ModelVersion)
            num3 = 0;
        }
        if (num3 == 1)
        {
          if ((this.optnr == 1 | this.optnr == 2) & this.game.Data.SFTypeObj[tdata].TempNewCost > -1 & (this.game.Data.SFTypeObj[tdata].ModelRegime == this.game.Data.Turn | this.game.Data.SFTypeObj[tdata].ModelRegime == -1))
          {
            num2 += 1;
            this.OptionsListObj.add(this.game.Data.SFTypeObj[tdata].Name, tdata);
            if (this.detailnr == tdata)
              num1 = num2;
          }
          else if (this.optnr == 1 & this.game.Data.SFTypeObj[tdata].ModelID > 0 & this.game.Data.SFTypeObj[tdata].ModelRegime == this.game.Data.Turn)
          {
            num2 += 1;
            this.OptionsListObj.add(this.game.Data.SFTypeObj[tdata].Name, tdata);
            if (this.detailnr == tdata)
              num1 = num2;
          }
          else if (this.optnr == 1 & this.game.Data.SFTypeObj[tdata].TempUpgradeCost > -1 & this.game.Data.SFTypeObj[tdata].ModelRegime == this.game.Data.Turn)
          {
            num2 += 1;
            this.OptionsListObj.add(this.game.Data.SFTypeObj[tdata].Name, tdata);
            if (this.detailnr == tdata)
              num1 = num2;
          }
          else if (this.optnr == 3 & this.game.Data.SFTypeObj[tdata].TempUpgradeCost > -1 & this.game.Data.SFTypeObj[tdata].ModelRegime == this.game.Data.Turn)
          {
            let mut num4: i32 = 1;
            let mut sfTypeCounter3: i32 = this.game.Data.SFTypeCounter;
            for (let mut index: i32 = 0; index <= sfTypeCounter3; index += 1)
            {
              if (this.game.Data.SFTypeObj[index].ModelID == this.game.Data.SFTypeObj[tdata].ModelID & this.game.Data.SFTypeObj[index].ModelVersion > this.game.Data.SFTypeObj[tdata].ModelVersion)
                num4 = 0;
            }
            if (num4 == 1)
            {
              num2 += 1;
              this.OptionsListObj.add(this.game.Data.SFTypeObj[tdata].Name, tdata);
              if (this.detailnr == tdata)
                num1 = num2;
            }
          }
          else if (this.optnr == 4 & this.game.Data.SFTypeObj[tdata].TempImproveCost > -1 & this.game.Data.SFTypeObj[tdata].ModelRegime == this.game.Data.Turn)
          {
            num2 += 1;
            this.OptionsListObj.add(this.game.Data.SFTypeObj[tdata].Name, tdata);
            if (this.detailnr == tdata)
              num1 = num2;
          }
        }
      }
      if (num1 == -1)
        this.detailnr = -1;
      ListClass optionsListObj = this.OptionsListObj;
      let mut tlistselect: i32 = num1;
      let mut game: GameClass = this.game;
       Bitmap local1 =  this.OwnBitmap;
      Font font =  null;
       Font local2 =  font;
      tsubpart1 =  new ListSubPartClass(optionsListObj, 8, 220, tlistselect, game, tHeader: "Subformationtype Models", tShowPair: true, tValueWidth: 100, tbackbitmap: ( local1), bbx: 110, bby: 5, overruleFont: ( local2));
      this.OptionsListId = this.AddSubPart( tsubpart1, 110, 5, 220, 176, 0);
      if (this.detailnr > -1)
      {
        DrawMod.DrawText( Expression, this.game.Data.SFTypeObj[this.detailnr].Name, this.game.GameFont3, 350, 10);
        let mut picSpriteId: i32 = this.game.Data.SFTypeObj[this.detailnr].PicSpriteID;
        if (this.game.Data.RegimeObj[this.game.Data.Turn].ExtraGraphicUse > -1)
        {
          let mut extraCounter: i32 = this.game.Data.SFTypeObj[this.detailnr].ExtraCounter;
          for (let mut index: i32 = 0; index <= extraCounter; index += 1)
          {
            if (this.game.Data.SFTypeObj[this.detailnr].ExtraCode[index] == this.game.Data.RegimeObj[this.game.Data.Turn].ExtraGraphicUse)
              picSpriteId = this.game.Data.SFTypeObj[this.detailnr].ExtraPicSpriteID[index];
          }
        }
         Graphics local3 =  Expression;
        Bitmap bitmap = BitmapStore.GetBitmap(picSpriteId);
         Bitmap local4 =  bitmap;
        DrawMod.DrawScaled( local3,  local4, 350, 30, 100, 75);
        DrawMod.DrawRectangle( Expression, 350, 30, 100, 75, 0, 0, 0,  byte.MaxValue);
        DrawMod.DrawRectangle( Expression, 351, 31, 98, 73,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue);
        tsubpart1 =  new TextButtonPartClass("Info", 70, tBackbitmap: ( this.OwnBitmap), bbx: 350, bby: 115);
        this.B6Id = this.AddSubPart( tsubpart1, 350, 115, 70, 35, 1);
        tText: String = "";
        if (this.game.Data.SFTypeObj[this.detailnr].TempNewCost > -1)
        {
          str1: String = tText + "This is a concept. \r\n" + "Designing a model based on it is possible.\r\n";
          string str2;
          if (this.game.Data.SFTypeObj[this.detailnr].ModelCostType == -1)
            str2 = str1 + "This costs " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempNewCost) + " PP.\r\n";
          else
            str2 = str1 + "This costs " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempNewCost) + " " + this.game.Data.RegimeSlotName[this.game.Data.SFTypeObj[this.detailnr].ModelCostType] + "\r\n";
          tText = str2 + "A new model will use " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempNewLevels) + " new core research levels and " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempImprovementFields) + " improvement research fields.";
        }
        else if (this.game.Data.SFTypeObj[this.detailnr].TempUpgradeCost > -1)
        {
          str3: String = tText + "This is a model you can upgrade. " + "It uses " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelLevel)) + " core research levels. " + "Its Mark " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelMark)) + ". Its Version " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelVersion));
          let mut num5: i32 = 0;
          let mut researchCounter: i32 = this.game.Data.ResearchCounter;
          for (let mut index: i32 = 0; index <= researchCounter; index += 1)
          {
            if (this.game.Data.SFTypeObj[this.detailnr].ModelLastState[index] == 1)
            {
              num5 += 1;
              if (num5 == 1)
                str3 = str3 + "\r\n" + "This model has been improved with: ";
              if (num5 >= 2)
                str3 += ", ";
              str3 += this.game.Data.ResearchObj[index].Name;
            }
          }
          str4: String = str3 + "\r\n";
          string str5;
          if (this.game.Data.SFTypeObj[this.detailnr].ModelCostType == -1)
            str5 = str4 + "Upgrade costs " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempUpgradeCost) + " PP.\r\n";
          else
            str5 = str4 + "Upgrade costs " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempUpgradeCost) + " " + this.game.Data.RegimeSlotName[this.game.Data.SFTypeObj[this.detailnr].ModelCostType] + "\r\n";
          tText = str5 + "A upgraded model will use " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempUpgradeLevels) + " new core research levels and " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempImprovementFields) + " improvement research fields.";
          if (this.game.Data.SFTypeObj[this.detailnr].TempImproveCost > -1)
          {
            str6: String = tText + "\r\n" + "Improving it will use " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempImprovementFields) + " new improvement research levels." + "\r\n";
            if (this.game.Data.SFTypeObj[this.detailnr].ModelCostType == -1)
              tText = str6 + "It can be improved upon. Improving this model costs " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempImproveCost) + " PP.\r\n";
            else
              tText = str6 + "It can be improved upon. Improving this model costs " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempImproveCost) + " " + this.game.Data.RegimeSlotName[this.game.Data.SFTypeObj[this.detailnr].ModelCostType] + "\r\n";
          }
        }
        else if (this.game.Data.SFTypeObj[this.detailnr].TempImproveCost > -1)
        {
          str7: String = tText + "This is a model you have developed..\r\n" + "It uses " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelLevel)) + " core research levels." + "\r\n" + "Its Mark " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelMark)) + ". Its Version " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelVersion));
          let mut num6: i32 = 0;
          let mut researchCounter: i32 = this.game.Data.ResearchCounter;
          for (let mut index: i32 = 0; index <= researchCounter; index += 1)
          {
            if (this.game.Data.SFTypeObj[this.detailnr].ModelLastState[index] == 1)
            {
              num6 += 1;
              if (num6 == 1)
                str7 = str7 + "\r\n" + "This model has been improved with: ";
              if (num6 >= 2)
                str7 += ", ";
              str7 += this.game.Data.ResearchObj[index].Name;
            }
          }
          str8: String = str7 + "\r\n" + "Improving it will use " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempImprovementFields) + " new improvement research levels." + "\r\n";
          if (this.game.Data.SFTypeObj[this.detailnr].ModelCostType == -1)
            tText = str8 + "It can be improved upon. Improving this model costs " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempImproveCost) + " PP.\r\n";
          else
            tText = str8 + "It can be improved upon. Improving this model costs " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempImproveCost) + " " + this.game.Data.RegimeSlotName[this.game.Data.SFTypeObj[this.detailnr].ModelCostType] + "\r\n";
        }
        else if (this.game.Data.SFTypeObj[this.detailnr].ModelID > 0 & this.game.Data.SFTypeObj[this.detailnr].ModelRegime == this.game.Data.Turn)
        {
          str: String = tText + "This is a model you have developed..\r\n" + "It uses " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelLevel)) + " core research levels." + "\r\n" + "Its Mark " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelMark)) + ". Its Version " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelVersion));
          let mut num7: i32 = 0;
          let mut researchCounter: i32 = this.game.Data.ResearchCounter;
          for (let mut index: i32 = 0; index <= researchCounter; index += 1)
          {
            if (this.game.Data.SFTypeObj[this.detailnr].ModelLastState[index] == 1)
            {
              num7 += 1;
              if (num7 == 1)
                str = str + "\r\n" + "This model has been improved with: ";
              if (num7 >= 2)
                str += ", ";
              str += this.game.Data.ResearchObj[index].Name;
            }
          }
          tText = str + "\r\n";
        }
        tsubpart1 =  new TextAreaClass(this.game, 390, 7, Font::new("Times New Roman", 14f, FontStyle.Regular, GraphicsUnit.Pixel), "Technical Data", true, tText, Color.White, tbackbitmap: ( this.OwnBitmap), bbx: 460, bby: 30);
        this.B5Id = this.AddSubPart( tsubpart1, 460, 30, 390, 160, 0);
        let mut num8: i32 = -1;
        let mut num9: i32 = 0;
        if (this.game.Data.SFTypeObj[this.detailnr].TempNewCost > -1)
        {
          let mut num10: i32 = 0;
          if (this.game.Data.SFTypeObj[this.detailnr].ModelCostType == -1)
          {
            if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.SFTypeObj[this.detailnr].TempNewCost)
              num10 = 1;
          }
          else if (this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[this.game.Data.SFTypeObj[this.detailnr].ModelCostType] >= this.game.Data.SFTypeObj[this.detailnr].TempNewCost)
            num10 = 1;
          if (num10 == 1)
          {
            num8 += 1;
            tsubpart1 =  new TextButtonPartClass("New", 100, tBackbitmap: ( this.OwnBitmap), bbx: 850, bby: (30 + num8 * 40));
            this.B7Id = this.AddSubPart( tsubpart1, 850, 30 + num8 * 40, 100, 35, 1);
          }
          else
          {
            num8 += 1;
            tsubpart1 =  new TextButtonPartClass("New", 100, "You cannot pay the cost",  this.OwnBitmap, 850, 30 + num8 * 40, true);
            this.b7bid = this.AddSubPart( tsubpart1, 850, 30 + num8 * 40, 100, 35, 0);
          }
        }
        if (this.game.Data.SFTypeObj[this.detailnr].TempUpgradeCost > -1)
        {
          let mut num11: i32 = 0;
          if (this.game.Data.SFTypeObj[this.detailnr].ModelCostType == -1)
          {
            if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.SFTypeObj[this.detailnr].TempUpgradeCost)
              num11 = 1;
          }
          else if (this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[this.game.Data.SFTypeObj[this.detailnr].ModelCostType] >= this.game.Data.SFTypeObj[this.detailnr].TempUpgradeCost)
            num11 = 1;
          if (num11 == 1)
          {
            num8 += 1;
            tsubpart1 =  new TextButtonPartClass("Upgrade", 100, tBackbitmap: ( this.OwnBitmap), bbx: 850, bby: (30 + num8 * 40));
            this.B8Id = this.AddSubPart( tsubpart1, 850, 30 + num8 * 40, 100, 35, 1);
          }
          else
          {
            num8 += 1;
            tsubpart1 =  new TextButtonPartClass("Upgrade", 100, "You cannot pay the cost",  this.OwnBitmap, 850, 30 + num8 * 40, true);
            this.b8bid = this.AddSubPart( tsubpart1, 850, 30 + num8 * 40, 100, 35, 0);
          }
        }
        if (this.game.Data.SFTypeObj[this.detailnr].TempImproveCost > -1)
        {
          let mut num12: i32 = 0;
          if (this.game.Data.SFTypeObj[this.detailnr].ModelCostType == -1)
          {
            if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.SFTypeObj[this.detailnr].TempImproveCost)
              num12 = 1;
          }
          else if (this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[this.game.Data.SFTypeObj[this.detailnr].ModelCostType] >= this.game.Data.SFTypeObj[this.detailnr].TempImproveCost)
            num12 = 1;
          if (num12 == 1)
          {
            num8 += 1;
            tsubpart1 =  new TextButtonPartClass("Improve", 100, tBackbitmap: ( this.OwnBitmap), bbx: 850, bby: (30 + num8 * 40));
            this.B9Id = this.AddSubPart( tsubpart1, 850, 30 + num8 * 40, 100, 35, 1);
          }
          else
          {
            num8 += 1;
            tsubpart1 =  new TextButtonPartClass("Improve", 100, "You cannot pay the cost",  this.OwnBitmap, 850, 30 + num8 * 40, true);
            this.b9bid = this.AddSubPart( tsubpart1, 850, 30 + num8 * 40, 100, 35, 0);
          }
        }
        if (this.game.Data.SFTypeObj[this.detailnr].TempFieldCount == 0)
        {
          num9 = 0;
          if ((uint) (-(this.game.Data.SFTypeObj[this.detailnr].TempAlterationCost > 0 & this.game.Data.SFTypeObj[this.detailnr].ModelVersion == 1 ? 1 : 0) & this.game.Data.SFTypeObj[this.detailnr].ModelMark) > 0U)
          {
            num8 += 1;
            tsubpart1 =  new TextButtonPartClass("Alter", 100, tBackbitmap: ( this.OwnBitmap), bbx: 850, bby: (30 + num8 * 40));
            this.B11Id = this.AddSubPart( tsubpart1, 850, 30 + num8 * 40, 100, 35, 1);
          }
          if (!this.game.Data.SFTypeObj[this.detailnr].ModelIsBase)
          {
            let mut num13: i32 = num8 + 1;
            tsubpart1 =  new TextButtonPartClass("Rename", 100, tBackbitmap: ( this.OwnBitmap), bbx: 850, bby: (30 + num13 * 40));
            this.B10Id = this.AddSubPart( tsubpart1, 850, 30 + num13 * 40, 100, 35, 1);
          }
        }
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      OrderResult orderResult = OrderResult::new();
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 = this.SubPartCounter;
        for (let mut index1: i32 = 0; index1 <= subPartCounter; index1 += 1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            let mut num1: i32 = this.SubPartID[index1];
            if (num1 == this.B11Id)
            {
              Form3::new( this.formref).Initialize(this.game.Data, 79, this.detailnr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B10Id)
            {
              str: String = Interaction.InputBox("Give new name for all members of this model family", "Shadow Empire : Planetary Conquest");
              if (Strings.Len(str) > 1)
              {
                let mut sfTypeCounter: i32 = this.game.Data.SFTypeCounter;
                for (let mut index2: i32 = 0; index2 <= sfTypeCounter; index2 += 1)
                {
                  if (this.game.Data.SFTypeObj[index2].ModelID == this.game.Data.SFTypeObj[this.detailnr].ModelID)
                  {
                    let mut modelItemType: i32 = this.game.Data.SFTypeObj[index2].ModelItemType;
                    if (modelItemType > -1)
                      this.game.Data.ItemTypeObj[modelItemType].Name = this.game.Data.ItemTypeObj[modelItemType].Name.Replace(this.game.Data.SFTypeObj[index2].ModelName, str);
                    this.game.Data.SFTypeObj[index2].Name = this.game.Data.SFTypeObj[index2].Name.Replace(this.game.Data.SFTypeObj[index2].ModelName, str);
                    this.game.Data.SFTypeObj[index2].ModelName = str;
                  }
                }
                this.game.HandyFunctionsObj.CalculateSFDesignCosts();
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              let mut num2: i32 =  Interaction.MsgBox((object) "Cancelled");
            }
            else
            {
              if (num1 == this.B9Id)
              {
                this.game.ProcessingObj.MakeSFTypeModelImprovement(this.detailnr);
                this.AutoChangeProdLine(this.game.Data.ItemTypeCounter);
                this.game.ProcessingObj.LocationProductionPrognosis();
                windowReturnClass.AddCommand(4, 18);
                windowReturnClass.AddCommand(4, 66);
                this.optnr = 1;
                this.detailnr = this.game.Data.SFTypeCounter;
                this.game.HandyFunctionsObj.CalculateSFDesignCosts();
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B8Id)
              {
                this.game.ProcessingObj.MakeSFTypeModelUpgrade(this.detailnr);
                this.AutoChangeProdLine(this.game.Data.ItemTypeCounter);
                this.game.ProcessingObj.LocationProductionPrognosis();
                windowReturnClass.AddCommand(4, 18);
                windowReturnClass.AddCommand(4, 66);
                this.optnr = 1;
                this.detailnr = this.game.Data.SFTypeCounter;
                this.game.HandyFunctionsObj.CalculateSFDesignCosts();
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B7Id)
              {
                this.game.ProcessingObj.MakeNewSFTypeModel(this.detailnr);
                this.AutoChangeProdLine(this.game.Data.ItemTypeCounter);
                this.game.ProcessingObj.LocationProductionPrognosis();
                windowReturnClass.AddCommand(4, 18);
                windowReturnClass.AddCommand(4, 66);
                this.optnr = 1;
                this.detailnr = this.game.Data.SFTypeCounter;
                this.game.HandyFunctionsObj.CalculateSFDesignCosts();
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B6Id)
              {
                this.game.EditObj.TempProdList1 = this.optnr;
                this.game.EditObj.TempProdList2 = this.detailnr;
                this.game.EditObj.TempProdList3 = -1;
                this.game.EditObj.SFTypeSelected = this.detailnr;
                this.game.EditObj.SFSelected = -1;
                this.game.EditObj.CameFrom = 65;
                windowReturnClass.AddCommand(3, 8);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B5Id)
              {
                this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B1Id)
              {
                this.optnr = 1;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B2Id)
              {
                this.optnr = 2;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B3Id)
              {
                this.optnr = 3;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B4Id)
              {
                this.optnr = 4;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.OptionsListId)
              {
                let mut num3: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num3 > -1)
                {
                  this.detailnr = num3;
                  this.dostuff();
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    pub void AutoChangeProdLine(int newi)
    {
      SimpleList simpleList = SimpleList::new();
      let mut itemTypeCounter: i32 = this.game.Data.ItemTypeCounter;
      int Number;
      for (let mut itemtypenr: i32 = 0; itemtypenr <= itemTypeCounter; itemtypenr += 1)
      {
        if (itemtypenr == newi && this.game.Data.ItemTypeObj[itemtypenr].Blocks > -1)
        {
          let mut blocks: i32 = this.game.Data.ItemTypeObj[itemtypenr].Blocks;
          let mut locCounter: i32 = this.game.Data.LocCounter;
          for (let mut locnr: i32 = 0; locnr <= locCounter; locnr += 1)
          {
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y].Regime == this.game.Data.Turn)
            {
              let mut index: i32 = 0;
              do
              {
                if (this.game.Data.LocObj[locnr].Production[index] == this.game.Data.ItemTypeObj[itemtypenr].Blocks && this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, itemtypenr).result)
                {
                  this.game.Data.LocObj[locnr].Production[index] = itemtypenr;
                  Number += 1;
                }
                index += 1;
              }
              while (index <= 3);
            }
          }
        }
      }
      if (Number <= 0)
        return;
      let mut num: i32 =  Interaction.MsgBox((object) ("Automatically switched " + Conversion.Str((object) Number) + " production line(s)."), Title: ((object) "Shadow Empire : Planetary Conquest"));
    }
  }
}
