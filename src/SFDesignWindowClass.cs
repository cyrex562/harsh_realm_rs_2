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
  public class SFDesignWindowClass : WindowClass
  {
    private int B1Id;
    private int B1TextId;
    private int B2Id;
    private int B2TextId;
    private int B3Id;
    private int B3TextId;
    private int B4Id;
    private int B4TextId;
    private int B5Id;
    private int B5TextId;
    private int B6Id;
    private int B6TextId;
    private int B7Id;
    private int b7bid;
    private int B7TextId;
    private int B8Id;
    private int b8bid;
    private int B8TextId;
    private int B9Id;
    private int b9bid;
    private int B9TextId;
    private int B10Id;
    private int B10TextId;
    private int B11Id;
    private int B11TextId;
    private int off1id;
    private int detailnr;
    private int optnr;
    private int Text1Id;
    private int Text2Id;
    private int Text3Id;
    private int Pic1Id;
    private int detailnr2;
    private int OrderTextId;
    private int OrderText2Id;
    private int OrderUpId;
    private int OrderDownId;
    private int ExtraId;
    private int steppy;
    private int typpy;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int OptionsList2Id;
    private ListClass OptionsList2Obj;
    private bool Hq;

    public override void DoRefresh()
    {
      this.game.HandyFunctionsObj.CalculateSFDesignCosts();
      this.dostuff();
    }

    public SFDesignWindowClass(
      ref GameClass tGame,
      Bitmap screenbitmap = null,
      int sx = -1,
      int sy = -1,
      int tl1 = -1,
      int tl2 = -1)
      : base(ref tGame, 1024, 200, 99, screenbitmap: screenbitmap, sx: sx, sy: sy)
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

    private void dostuff()
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
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONFLAGGED);
        this.B1Id = this.AddSubPart(ref tsubpart, 5, 10, 32, 32, 1);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONUNFLAGGED);
        this.B1Id = this.AddSubPart(ref tsubpart, 5, 10, 32, 32, 1);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("All", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 60, 24, false);
      this.B1TextId = this.AddSubPart(ref tsubpart1, 40, 9, 60, 24, 0);
      if (this.optnr == 2)
      {
        tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONFLAGGED);
        this.B2Id = this.AddSubPart(ref tsubpart1, 5, 40, 32, 32, 1);
      }
      else
      {
        tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONUNFLAGGED);
        this.B2Id = this.AddSubPart(ref tsubpart1, 5, 40, 32, 32, 1);
      }
      tsubpart1 = (SubPartClass) new TextPartClass("New", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 60, 24, false);
      this.B2TextId = this.AddSubPart(ref tsubpart1, 40, 39, 60, 24, 0);
      if (this.optnr == 3)
      {
        tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONFLAGGED);
        this.B3Id = this.AddSubPart(ref tsubpart1, 5, 70, 32, 32, 1);
      }
      else
      {
        tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONUNFLAGGED);
        this.B3Id = this.AddSubPart(ref tsubpart1, 5, 70, 32, 32, 1);
      }
      tsubpart1 = (SubPartClass) new TextPartClass("Upgrade", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 60, 24, false);
      this.B3TextId = this.AddSubPart(ref tsubpart1, 40, 69, 60, 24, 0);
      if (this.optnr == 4)
      {
        tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONFLAGGED);
        this.B4Id = this.AddSubPart(ref tsubpart1, 5, 100, 32, 32, 1);
      }
      else
      {
        tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONUNFLAGGED);
        this.B4Id = this.AddSubPart(ref tsubpart1, 5, 100, 32, 32, 1);
      }
      tsubpart1 = (SubPartClass) new TextPartClass("Improve", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 60, 24, false);
      this.B4TextId = this.AddSubPart(ref tsubpart1, 40, 99, 60, 24, 0);
      this.OptionsListObj = new ListClass();
      int num1 = -1;
      int num2 = -1;
      int sfTypeCounter1 = this.game.Data.SFTypeCounter;
      for (int tdata = 0; tdata <= sfTypeCounter1; ++tdata)
      {
        int num3 = 1;
        int sfTypeCounter2 = this.game.Data.SFTypeCounter;
        for (int index = 0; index <= sfTypeCounter2; ++index)
        {
          if (this.game.Data.SFTypeObj[index].ModelID == this.game.Data.SFTypeObj[tdata].ModelID && this.game.Data.SFTypeObj[tdata].ModelBaseModel == this.game.Data.SFTypeObj[index].ModelBaseModel && this.game.Data.SFTypeObj[tdata].ModelMark == this.game.Data.SFTypeObj[index].ModelMark && this.game.Data.SFTypeObj[tdata].ModelVersion < this.game.Data.SFTypeObj[index].ModelVersion)
            num3 = 0;
        }
        if (num3 == 1)
        {
          if ((this.optnr == 1 | this.optnr == 2) & this.game.Data.SFTypeObj[tdata].TempNewCost > -1 & (this.game.Data.SFTypeObj[tdata].ModelRegime == this.game.Data.Turn | this.game.Data.SFTypeObj[tdata].ModelRegime == -1))
          {
            ++num2;
            this.OptionsListObj.add(this.game.Data.SFTypeObj[tdata].Name, tdata);
            if (this.detailnr == tdata)
              num1 = num2;
          }
          else if (this.optnr == 1 & this.game.Data.SFTypeObj[tdata].ModelID > 0 & this.game.Data.SFTypeObj[tdata].ModelRegime == this.game.Data.Turn)
          {
            ++num2;
            this.OptionsListObj.add(this.game.Data.SFTypeObj[tdata].Name, tdata);
            if (this.detailnr == tdata)
              num1 = num2;
          }
          else if (this.optnr == 1 & this.game.Data.SFTypeObj[tdata].TempUpgradeCost > -1 & this.game.Data.SFTypeObj[tdata].ModelRegime == this.game.Data.Turn)
          {
            ++num2;
            this.OptionsListObj.add(this.game.Data.SFTypeObj[tdata].Name, tdata);
            if (this.detailnr == tdata)
              num1 = num2;
          }
          else if (this.optnr == 3 & this.game.Data.SFTypeObj[tdata].TempUpgradeCost > -1 & this.game.Data.SFTypeObj[tdata].ModelRegime == this.game.Data.Turn)
          {
            int num4 = 1;
            int sfTypeCounter3 = this.game.Data.SFTypeCounter;
            for (int index = 0; index <= sfTypeCounter3; ++index)
            {
              if (this.game.Data.SFTypeObj[index].ModelID == this.game.Data.SFTypeObj[tdata].ModelID & this.game.Data.SFTypeObj[index].ModelVersion > this.game.Data.SFTypeObj[tdata].ModelVersion)
                num4 = 0;
            }
            if (num4 == 1)
            {
              ++num2;
              this.OptionsListObj.add(this.game.Data.SFTypeObj[tdata].Name, tdata);
              if (this.detailnr == tdata)
                num1 = num2;
            }
          }
          else if (this.optnr == 4 & this.game.Data.SFTypeObj[tdata].TempImproveCost > -1 & this.game.Data.SFTypeObj[tdata].ModelRegime == this.game.Data.Turn)
          {
            ++num2;
            this.OptionsListObj.add(this.game.Data.SFTypeObj[tdata].Name, tdata);
            if (this.detailnr == tdata)
              num1 = num2;
          }
        }
      }
      if (num1 == -1)
        this.detailnr = -1;
      ListClass optionsListObj = this.OptionsListObj;
      int tlistselect = num1;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      tsubpart1 = (SubPartClass) new ListSubPartClass(optionsListObj, 8, 220, tlistselect, game, tHeader: "Subformationtype Models", tShowPair: true, tValueWidth: 100, tbackbitmap: (ref local1), bbx: 110, bby: 5, overruleFont: (ref local2));
      this.OptionsListId = this.AddSubPart(ref tsubpart1, 110, 5, 220, 176, 0);
      if (this.detailnr > -1)
      {
        DrawMod.DrawText(ref Expression, this.game.Data.SFTypeObj[this.detailnr].Name, this.game.GameFont3, 350, 10);
        int picSpriteId = this.game.Data.SFTypeObj[this.detailnr].PicSpriteID;
        if (this.game.Data.RegimeObj[this.game.Data.Turn].ExtraGraphicUse > -1)
        {
          int extraCounter = this.game.Data.SFTypeObj[this.detailnr].ExtraCounter;
          for (int index = 0; index <= extraCounter; ++index)
          {
            if (this.game.Data.SFTypeObj[this.detailnr].ExtraCode[index] == this.game.Data.RegimeObj[this.game.Data.Turn].ExtraGraphicUse)
              picSpriteId = this.game.Data.SFTypeObj[this.detailnr].ExtraPicSpriteID[index];
          }
        }
        ref Graphics local3 = ref Expression;
        Bitmap bitmap = BitmapStore.GetBitmap(picSpriteId);
        ref Bitmap local4 = ref bitmap;
        DrawMod.DrawScaled(ref local3, ref local4, 350, 30, 100, 75);
        DrawMod.DrawRectangle(ref Expression, 350, 30, 100, 75, 0, 0, 0, (int) byte.MaxValue);
        DrawMod.DrawRectangle(ref Expression, 351, 31, 98, 73, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        tsubpart1 = (SubPartClass) new TextButtonPartClass("Info", 70, tBackbitmap: (ref this.OwnBitmap), bbx: 350, bby: 115);
        this.B6Id = this.AddSubPart(ref tsubpart1, 350, 115, 70, 35, 1);
        string tText = "";
        if (this.game.Data.SFTypeObj[this.detailnr].TempNewCost > -1)
        {
          string str1 = tText + "This is a concept. \r\n" + "Designing a model based on it is possible.\r\n";
          string str2;
          if (this.game.Data.SFTypeObj[this.detailnr].ModelCostType == -1)
            str2 = str1 + "This costs " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempNewCost) + " PP.\r\n";
          else
            str2 = str1 + "This costs " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempNewCost) + " " + this.game.Data.RegimeSlotName[this.game.Data.SFTypeObj[this.detailnr].ModelCostType] + "\r\n";
          tText = str2 + "A new model will use " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempNewLevels) + " new core research levels and " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempImprovementFields) + " improvement research fields.";
        }
        else if (this.game.Data.SFTypeObj[this.detailnr].TempUpgradeCost > -1)
        {
          string str3 = tText + "This is a model you can upgrade. " + "It uses " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelLevel)) + " core research levels. " + "Its Mark " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelMark)) + ". Its Version " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelVersion));
          int num5 = 0;
          int researchCounter = this.game.Data.ResearchCounter;
          for (int index = 0; index <= researchCounter; ++index)
          {
            if (this.game.Data.SFTypeObj[this.detailnr].ModelLastState[index] == 1)
            {
              ++num5;
              if (num5 == 1)
                str3 = str3 + "\r\n" + "This model has been improved with: ";
              if (num5 >= 2)
                str3 += ", ";
              str3 += this.game.Data.ResearchObj[index].Name;
            }
          }
          string str4 = str3 + "\r\n";
          string str5;
          if (this.game.Data.SFTypeObj[this.detailnr].ModelCostType == -1)
            str5 = str4 + "Upgrade costs " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempUpgradeCost) + " PP.\r\n";
          else
            str5 = str4 + "Upgrade costs " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempUpgradeCost) + " " + this.game.Data.RegimeSlotName[this.game.Data.SFTypeObj[this.detailnr].ModelCostType] + "\r\n";
          tText = str5 + "A upgraded model will use " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempUpgradeLevels) + " new core research levels and " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempImprovementFields) + " improvement research fields.";
          if (this.game.Data.SFTypeObj[this.detailnr].TempImproveCost > -1)
          {
            string str6 = tText + "\r\n" + "Improving it will use " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempImprovementFields) + " new improvement research levels." + "\r\n";
            if (this.game.Data.SFTypeObj[this.detailnr].ModelCostType == -1)
              tText = str6 + "It can be improved upon. Improving this model costs " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempImproveCost) + " PP.\r\n";
            else
              tText = str6 + "It can be improved upon. Improving this model costs " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempImproveCost) + " " + this.game.Data.RegimeSlotName[this.game.Data.SFTypeObj[this.detailnr].ModelCostType] + "\r\n";
          }
        }
        else if (this.game.Data.SFTypeObj[this.detailnr].TempImproveCost > -1)
        {
          string str7 = tText + "This is a model you have developed..\r\n" + "It uses " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelLevel)) + " core research levels." + "\r\n" + "Its Mark " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelMark)) + ". Its Version " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelVersion));
          int num6 = 0;
          int researchCounter = this.game.Data.ResearchCounter;
          for (int index = 0; index <= researchCounter; ++index)
          {
            if (this.game.Data.SFTypeObj[this.detailnr].ModelLastState[index] == 1)
            {
              ++num6;
              if (num6 == 1)
                str7 = str7 + "\r\n" + "This model has been improved with: ";
              if (num6 >= 2)
                str7 += ", ";
              str7 += this.game.Data.ResearchObj[index].Name;
            }
          }
          string str8 = str7 + "\r\n" + "Improving it will use " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempImprovementFields) + " new improvement research levels." + "\r\n";
          if (this.game.Data.SFTypeObj[this.detailnr].ModelCostType == -1)
            tText = str8 + "It can be improved upon. Improving this model costs " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempImproveCost) + " PP.\r\n";
          else
            tText = str8 + "It can be improved upon. Improving this model costs " + Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].TempImproveCost) + " " + this.game.Data.RegimeSlotName[this.game.Data.SFTypeObj[this.detailnr].ModelCostType] + "\r\n";
        }
        else if (this.game.Data.SFTypeObj[this.detailnr].ModelID > 0 & this.game.Data.SFTypeObj[this.detailnr].ModelRegime == this.game.Data.Turn)
        {
          string str = tText + "This is a model you have developed..\r\n" + "It uses " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelLevel)) + " core research levels." + "\r\n" + "Its Mark " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelMark)) + ". Its Version " + Strings.Trim(Conversion.Str((object) this.game.Data.SFTypeObj[this.detailnr].ModelVersion));
          int num7 = 0;
          int researchCounter = this.game.Data.ResearchCounter;
          for (int index = 0; index <= researchCounter; ++index)
          {
            if (this.game.Data.SFTypeObj[this.detailnr].ModelLastState[index] == 1)
            {
              ++num7;
              if (num7 == 1)
                str = str + "\r\n" + "This model has been improved with: ";
              if (num7 >= 2)
                str += ", ";
              str += this.game.Data.ResearchObj[index].Name;
            }
          }
          tText = str + "\r\n";
        }
        tsubpart1 = (SubPartClass) new TextAreaClass(this.game, 390, 7, new Font("Times New Roman", 14f, FontStyle.Regular, GraphicsUnit.Pixel), "Technical Data", true, tText, Color.White, tbackbitmap: (ref this.OwnBitmap), bbx: 460, bby: 30);
        this.B5Id = this.AddSubPart(ref tsubpart1, 460, 30, 390, 160, 0);
        int num8 = -1;
        int num9 = 0;
        if (this.game.Data.SFTypeObj[this.detailnr].TempNewCost > -1)
        {
          int num10 = 0;
          if (this.game.Data.SFTypeObj[this.detailnr].ModelCostType == -1)
          {
            if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.SFTypeObj[this.detailnr].TempNewCost)
              num10 = 1;
          }
          else if (this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[this.game.Data.SFTypeObj[this.detailnr].ModelCostType] >= this.game.Data.SFTypeObj[this.detailnr].TempNewCost)
            num10 = 1;
          if (num10 == 1)
          {
            ++num8;
            tsubpart1 = (SubPartClass) new TextButtonPartClass("New", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 850, bby: (30 + num8 * 40));
            this.B7Id = this.AddSubPart(ref tsubpart1, 850, 30 + num8 * 40, 100, 35, 1);
          }
          else
          {
            ++num8;
            tsubpart1 = (SubPartClass) new TextButtonPartClass("New", 100, "You cannot pay the cost", ref this.OwnBitmap, 850, 30 + num8 * 40, true);
            this.b7bid = this.AddSubPart(ref tsubpart1, 850, 30 + num8 * 40, 100, 35, 0);
          }
        }
        if (this.game.Data.SFTypeObj[this.detailnr].TempUpgradeCost > -1)
        {
          int num11 = 0;
          if (this.game.Data.SFTypeObj[this.detailnr].ModelCostType == -1)
          {
            if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.SFTypeObj[this.detailnr].TempUpgradeCost)
              num11 = 1;
          }
          else if (this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[this.game.Data.SFTypeObj[this.detailnr].ModelCostType] >= this.game.Data.SFTypeObj[this.detailnr].TempUpgradeCost)
            num11 = 1;
          if (num11 == 1)
          {
            ++num8;
            tsubpart1 = (SubPartClass) new TextButtonPartClass("Upgrade", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 850, bby: (30 + num8 * 40));
            this.B8Id = this.AddSubPart(ref tsubpart1, 850, 30 + num8 * 40, 100, 35, 1);
          }
          else
          {
            ++num8;
            tsubpart1 = (SubPartClass) new TextButtonPartClass("Upgrade", 100, "You cannot pay the cost", ref this.OwnBitmap, 850, 30 + num8 * 40, true);
            this.b8bid = this.AddSubPart(ref tsubpart1, 850, 30 + num8 * 40, 100, 35, 0);
          }
        }
        if (this.game.Data.SFTypeObj[this.detailnr].TempImproveCost > -1)
        {
          int num12 = 0;
          if (this.game.Data.SFTypeObj[this.detailnr].ModelCostType == -1)
          {
            if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.SFTypeObj[this.detailnr].TempImproveCost)
              num12 = 1;
          }
          else if (this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[this.game.Data.SFTypeObj[this.detailnr].ModelCostType] >= this.game.Data.SFTypeObj[this.detailnr].TempImproveCost)
            num12 = 1;
          if (num12 == 1)
          {
            ++num8;
            tsubpart1 = (SubPartClass) new TextButtonPartClass("Improve", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 850, bby: (30 + num8 * 40));
            this.B9Id = this.AddSubPart(ref tsubpart1, 850, 30 + num8 * 40, 100, 35, 1);
          }
          else
          {
            ++num8;
            tsubpart1 = (SubPartClass) new TextButtonPartClass("Improve", 100, "You cannot pay the cost", ref this.OwnBitmap, 850, 30 + num8 * 40, true);
            this.b9bid = this.AddSubPart(ref tsubpart1, 850, 30 + num8 * 40, 100, 35, 0);
          }
        }
        if (this.game.Data.SFTypeObj[this.detailnr].TempFieldCount == 0)
        {
          num9 = 0;
          if ((uint) (-(this.game.Data.SFTypeObj[this.detailnr].TempAlterationCost > 0 & this.game.Data.SFTypeObj[this.detailnr].ModelVersion == 1 ? 1 : 0) & this.game.Data.SFTypeObj[this.detailnr].ModelMark) > 0U)
          {
            ++num8;
            tsubpart1 = (SubPartClass) new TextButtonPartClass("Alter", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 850, bby: (30 + num8 * 40));
            this.B11Id = this.AddSubPart(ref tsubpart1, 850, 30 + num8 * 40, 100, 35, 1);
          }
          if (!this.game.Data.SFTypeObj[this.detailnr].ModelIsBase)
          {
            int num13 = num8 + 1;
            tsubpart1 = (SubPartClass) new TextButtonPartClass("Rename", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 850, bby: (30 + num13 * 40));
            this.B10Id = this.AddSubPart(ref tsubpart1, 850, 30 + num13 * 40, 100, 35, 1);
          }
        }
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      OrderResult orderResult = new OrderResult();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num1 = this.SubPartID[index1];
            if (num1 == this.B11Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 79, this.detailnr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B10Id)
            {
              string str = Interaction.InputBox("Give new name for all members of this model family", "Shadow Empire : Planetary Conquest");
              if (Strings.Len(str) > 1)
              {
                int sfTypeCounter = this.game.Data.SFTypeCounter;
                for (int index2 = 0; index2 <= sfTypeCounter; ++index2)
                {
                  if (this.game.Data.SFTypeObj[index2].ModelID == this.game.Data.SFTypeObj[this.detailnr].ModelID)
                  {
                    int modelItemType = this.game.Data.SFTypeObj[index2].ModelItemType;
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
              int num2 = (int) Interaction.MsgBox((object) "Cancelled");
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
                int num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
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

    public void AutoChangeProdLine(int newi)
    {
      SimpleList simpleList = new SimpleList();
      int itemTypeCounter = this.game.Data.ItemTypeCounter;
      int Number;
      for (int itemtypenr = 0; itemtypenr <= itemTypeCounter; ++itemtypenr)
      {
        if (itemtypenr == newi && this.game.Data.ItemTypeObj[itemtypenr].Blocks > -1)
        {
          int blocks = this.game.Data.ItemTypeObj[itemtypenr].Blocks;
          int locCounter = this.game.Data.LocCounter;
          for (int locnr = 0; locnr <= locCounter; ++locnr)
          {
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y].Regime == this.game.Data.Turn)
            {
              int index = 0;
              do
              {
                if (this.game.Data.LocObj[locnr].Production[index] == this.game.Data.ItemTypeObj[itemtypenr].Blocks && this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, itemtypenr).result)
                {
                  this.game.Data.LocObj[locnr].Production[index] = itemtypenr;
                  ++Number;
                }
                ++index;
              }
              while (index <= 3);
            }
          }
        }
      }
      if (Number <= 0)
        return;
      int num = (int) Interaction.MsgBox((object) ("Automatically switched " + Conversion.Str((object) Number) + " production line(s)."), Title: ((object) "Shadow Empire : Planetary Conquest"));
    }
  }
}
