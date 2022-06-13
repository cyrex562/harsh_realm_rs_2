// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.BattlegroupWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class BattlegroupWindowClass : WindowClass
  {
     int okid;
     int cancelid;
     int transferid;
     int transfer2id;
     int oktextid;
     int sourceUnr;
     int targetUnr;
     SimpleList TL;
     int Pic1Id;
     int[] SlidersId;
     int[] SlidersSfnr;
     int SourceNextId;
     int SourcePrevId;
     int TargetNextId;
     int TargetPrevId;
     int SourcePage;
     int TargetPage;
     int SourcePageMax;
     int TargetPageMax;

    pub BattlegroupWindowClass(ref GameClass tGame)
      : base(ref tGame, 1000, 760, 8)
    {
      this.SlidersId = new int[20];
      this.SlidersSfnr = new int[20];
      this.TL = SimpleList::new();
      this.sourceUnr = this.game.EditObj.UnitSelected;
      this.targetUnr = -1;
      this.SetUnits();
      this.View();
    }

    pub void SetUnits()
    {
      int index = 0;
      do
      {
        if (this.SlidersId[index] > 0)
        {
          this.RemoveSubPart(this.SlidersId[index]);
          this.SlidersId[index] = 0;
        }
        index += 1;
      }
      while (index <= 19);
    }

    pub void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; index += 1)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            this.SubPartList[index].DescriptInfo(x - this.SubPartX[index], y - this.SubPartY[index]);
            if (Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
            {
              this.game.EditObj.TipButton = true;
              this.game.EditObj.TipTitle = "";
              this.game.EditObj.TipText = this.SubPartList[index].Descript;
              return;
            }
          }
        }
      }
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; index += 1)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] > 0)
            this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          break;
        }
      }
    }

    pub void View()
    {
      int selectX = this.game.SelectX;
      int selectY = this.game.SelectY;
      if (this.cancelid > 0)
      {
        this.RemoveSubPart(this.cancelid);
        this.cancelid = 0;
      }
      if (this.transferid > 0)
      {
        this.RemoveSubPart(this.transferid);
        this.transferid = 0;
      }
      if (this.transfer2id > 0)
      {
        this.RemoveSubPart(this.transfer2id);
        this.transfer2id = 0;
      }
      if (this.SourceNextId > 0)
      {
        this.RemoveSubPart(this.SourceNextId);
        this.SourceNextId = 0;
      }
      if (this.SourcePrevId > 0)
      {
        this.RemoveSubPart(this.SourcePrevId);
        this.SourcePrevId = 0;
      }
      if (this.TargetNextId > 0)
      {
        this.RemoveSubPart(this.TargetNextId);
        this.TargetNextId = 0;
      }
      if (this.TargetPrevId > 0)
      {
        this.RemoveSubPart(this.TargetPrevId);
        this.TargetPrevId = 0;
      }
      this.TL.removeWeight0orLower();
      Color color = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.ClearMouse();
      this.NewBackGroundAndClearAll(1000, 760, -1);
      Graphics toG = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref toG, 0, 0, 1000, 760);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      int battlegroupTemplate = this.game.HandyFunctionsObj.GetBattlegroupTemplate(this.game.Data.Turn);
      int index1 = -1;
      if ((double) this.game.Data.RuleVar[486] > 0.0)
        index1 = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[486]));
      int x1_1 = 5;
      int num1 = 980;
      int h1 = 110;
      int y1_1 = 10;
      DrawMod.DrawBlockGradient2(ref toG, x1_1, y1_1, 235, 40, this.game.MarcCol1, this.game.MarcCol2);
      DrawMod.DrawBlockGradient2(ref toG, x1_1 + 240, y1_1, 235, h1, this.game.MarcCol1, this.game.MarcCol2);
      DrawMod.DrawBlockGradient2(ref toG, x1_1 + 480, y1_1, (int) byte.MaxValue, h1, this.game.MarcCol1, this.game.MarcCol2);
      DrawMod.DrawBlockGradient2(ref toG, x1_1 + 740, y1_1, 235, 40, this.game.MarcCol1, this.game.MarcCol2);
      tstring1: String = "Source unit list";
      DrawMod.DrawTextColouredMarcCenter(ref toG, tstring1, this.game.MarcFont3, x1_1 + 120, y1_1 + 10, Color.White);
      tstring2: String = "Target unit list";
      DrawMod.DrawTextColouredMarcCenter(ref toG, tstring2, this.game.MarcFont3, x1_1 + 840, y1_1 + 10, Color.White);
      int num2 = 740;
      int num3 = 5;
      int num4 = 52;
      int num5 = 235;
      int num6 = 37;
      SimpleList simpleList1 = SimpleList::new();
      int unitCounter1 = this.game.Data.MapObj[0].HexObj[selectX, selectY].UnitCounter;
      for (int index2 = 0; index2 <= unitCounter1; index2 += 1)
      {
        int unit = this.game.Data.MapObj[0].HexObj[selectX, selectY].UnitList[index2];
        if (this.sourceUnr == -1)
          this.sourceUnr = unit;
        simpleList1.Add(unit, 1);
      }
      int counter1 = simpleList1.Counter;
      Rectangle trect1;
      for (int index3 = 0; index3 <= counter1; index3 += 1)
      {
        int index4 = simpleList1.Id[index3];
        if (index4 == this.sourceUnr)
        {
          DrawMod.DrawBlock(ref toG, num3, num4, num5, num6, 0, 0, 0, 64);
          DrawMod.DrawRectangle(ref toG, num3, num4 - 1, num5, num6 + 2, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
        }
        else if (index4 == this.targetUnr)
          DrawMod.DrawBlock(ref toG, num3, num4, num5, num6, 128, 0, 0, 128);
        else
          DrawMod.DrawBlock(ref toG, num3, num4, num5, num6, 0, 0, 0, 128);
        this.game.CustomBitmapObj.DrawUnit(index4, toG: toG, tx: (num3 + 8), ty: num4);
        str: String = this.game.Data.UnitObj[index4].Name;
        if (str.Length > 25)
          str = Strings.Left(str, 25) + ".";
        DrawMod.DrawTextColouredMarc(ref toG, str, this.game.MarcFont4, num3 + 50, num4 + 5, Color.White);
        int hq = this.game.Data.UnitObj[index4].HQ;
        tstring3: String = hq <= -1 ? "no HQ" : "HQ: " + this.game.Data.UnitObj[hq].Name;
        DrawMod.DrawTextColouredMarc(ref toG, tstring3, this.game.MarcFont5, num3 + 52, num4 + 22, Color.LightGray);
        if (index4 != this.targetUnr)
        {
          trect1 = new Rectangle(num3, num4, num5, num6);
          this.AddMouse(ref trect1, "", "", 1, index4);
        }
        num4 += 39;
      }
      int num7 = 745;
      int num8 = 52;
      int num9 = 235;
      int num10 = 37;
      SimpleList simpleList2 = SimpleList::new();
      int unitCounter2 = this.game.Data.MapObj[0].HexObj[selectX, selectY].UnitCounter;
      for (int index5 = 0; index5 <= unitCounter2; index5 += 1)
      {
        int unit = this.game.Data.MapObj[0].HexObj[selectX, selectY].UnitList[index5];
        simpleList2.Add(unit, 1);
      }
      if ((double) this.game.Data.RuleVar[486] > 0.0)
      {
        if (-3 == this.targetUnr)
        {
          DrawMod.DrawBlock(ref toG, num7, num8, num9, num10, 0, 0, 0, 64);
          DrawMod.DrawRectangle(ref toG, num7, num8 - 1, num9, num10 + 2, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
        }
        else
          DrawMod.DrawBlock(ref toG, num7, num8, num9, num10, 0, 0, 0, 128);
        tstring4: String = "Scrap & Scuttle";
        DrawMod.DrawTextColouredMarc(ref toG, tstring4, this.game.MarcFont4, num7 + 50, num8 + 5, Color.White);
        tstring5: String = "Destroys selected equipment";
        DrawMod.DrawTextColouredMarc(ref toG, tstring5, this.game.MarcFont5, num7 + 52, num8 + 22, Color.LightGray);
        trect1 = new Rectangle(num7, num8, num9, num10);
        Rectangle trect2 = trect1;
        this.AddMouse(ref trect2, "", "", 2, -3);
        num8 += 39;
      }
      if (this.game.HandyFunctionsObj.GetBattlegroupTemplate(this.game.Data.Turn) > -1)
      {
        if (-2 == this.targetUnr)
        {
          DrawMod.DrawBlock(ref toG, num7, num8, num9, num10, 0, 0, 0, 64);
          DrawMod.DrawRectangle(ref toG, num7, num8 - 1, num9, num10 + 2, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
        }
        else
          DrawMod.DrawBlock(ref toG, num7, num8, num9, num10, 0, 0, 0, 128);
        tstring6: String = "New Battlegroup";
        if (battlegroupTemplate > -1)
        {
          tstring6 = "New " + this.game.Data.HistoricalUnitObj[battlegroupTemplate].Name;
          if (this.game.Data.HistoricalUnitObj[battlegroupTemplate].PP > 0)
            tstring6 = tstring6 + " [" + this.game.Data.HistoricalUnitObj[battlegroupTemplate].PP.ToString() + "pp]";
        }
        DrawMod.DrawTextColouredMarc(ref toG, tstring6, this.game.MarcFont4, num7 + 50, num8 + 5, Color.White);
        tstring7: String = "Newly created Battlegroup";
        DrawMod.DrawTextColouredMarc(ref toG, tstring7, this.game.MarcFont5, num7 + 52, num8 + 22, Color.LightGray);
        trect1 = new Rectangle(num7, num8, num9, num10);
        Rectangle trect3 = trect1;
        this.AddMouse(ref trect3, "", "", 2, -2);
        num8 += 39;
      }
      int counter2 = simpleList2.Counter;
      for (int index6 = 0; index6 <= counter2; index6 += 1)
      {
        int index7 = simpleList2.Id[index6];
        if (index7 == this.targetUnr)
        {
          DrawMod.DrawBlock(ref toG, num7, num8, num9, num10, 0, 0, 0, 64);
          DrawMod.DrawRectangle(ref toG, num7, num8 - 1, num9, num10 + 2, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
        }
        else if (index7 == this.sourceUnr)
          DrawMod.DrawBlock(ref toG, num7, num8, num9, num10, 128, 0, 0, 128);
        else
          DrawMod.DrawBlock(ref toG, num7, num8, num9, num10, 0, 0, 0, 128);
        this.game.CustomBitmapObj.DrawUnit(index7, toG: toG, tx: (num7 + 8), ty: num8);
        str: String = this.game.Data.UnitObj[index7].Name;
        if (str.Length > 25)
          str = Strings.Left(str, 25) + ".";
        DrawMod.DrawTextColouredMarc(ref toG, str, this.game.MarcFont4, num7 + 50, num8 + 5, Color.White);
        int hq = this.game.Data.UnitObj[index7].HQ;
        tstring8: String = hq <= -1 ? "no HQ" : "HQ: " + this.game.Data.UnitObj[hq].Name;
        DrawMod.DrawTextColouredMarc(ref toG, tstring8, this.game.MarcFont5, num7 + 52, num8 + 22, Color.LightGray);
        if (index7 != this.sourceUnr)
        {
          trect1 = new Rectangle(num7, num8, num9, num10);
          Rectangle trect4 = trect1;
          this.AddMouse(ref trect4, "", "", 2, index7);
        }
        num8 += 39;
      }
      int num11 = 11;
      int x1_2 = 485;
      int y1_2 = 125;
      int maxValue = (int) byte.MaxValue;
      int h2 = 40;
      SimpleList simpleList3 = this.TL.Clone();
      SimpleList simpleList4 = SimpleList::new();
      SimpleList SL = SimpleList::new();
      int index8 = -1;
      int num12 = -1;
      if (this.targetUnr > -1)
      {
        index8 = this.game.Data.UnitObj[this.targetUnr].Historical;
        int historicalSubPart = this.game.Data.UnitObj[this.targetUnr].HistoricalSubPart;
        if (index8 > -1)
        {
          int subPart = this.game.Data.HistoricalUnitObj[index8].SubParts[historicalSubPart];
          if (subPart > 0)
          {
            int preDef = this.game.HandyFunctionsObj.GetPreDef(subPart);
            int sfCount = this.game.Data.UnitObj[preDef].SFCount;
            for (int index9 = 0; index9 <= sfCount; index9 += 1)
            {
              int sf = this.game.Data.UnitObj[preDef].SFList[index9];
              int type = this.game.Data.SFObj[sf].Type;
              int people = this.game.Data.SFObj[sf].People;
              int qty = this.game.Data.SFObj[sf].Qty;
              int reinforcementType = this.game.Data.SFTypeObj[type].ReinforcementType;
              simpleList4.AddWeight(reinforcementType, qty, people);
            }
          }
        }
        int sfCount1 = this.game.Data.UnitObj[this.targetUnr].SFCount;
        for (int index10 = 0; index10 <= sfCount1; index10 += 1)
        {
          int sf = this.game.Data.UnitObj[this.targetUnr].SFList[index10];
          int type = this.game.Data.SFObj[sf].Type;
          int people = this.game.Data.SFObj[sf].People;
          int qty = this.game.Data.SFObj[sf].Qty;
          int reinforcementType = this.game.Data.SFTypeObj[type].ReinforcementType;
          SL.AddWeight(reinforcementType, qty, people);
        }
      }
      int counter3 = simpleList3.Counter;
      int qty1;
      for (int index11 = 0; index11 <= counter3; index11 += 1)
      {
        int index12 = simpleList3.Id[index11];
        int type = this.game.Data.SFObj[index12].Type;
        int people = this.game.Data.SFObj[index12].People;
        qty1 = this.game.Data.SFObj[index12].Qty;
        int reinforcementType = this.game.Data.SFTypeObj[type].ReinforcementType;
        SL.AddWeight(reinforcementType, simpleList3.Weight[index11], people);
      }
      SimpleList simpleList5 = simpleList4.Clone();
      simpleList5.RemoveWeight(ref SL);
      SimpleList simpleList6 = simpleList3.Clone();
      if (this.targetUnr > -1)
      {
        int sfCount = this.game.Data.UnitObj[this.targetUnr].SFCount;
        for (int index13 = 0; index13 <= sfCount; index13 += 1)
        {
          int sf = this.game.Data.UnitObj[this.targetUnr].SFList[index13];
          int type1 = this.game.Data.SFObj[sf].Type;
          int reinforcementType = this.game.Data.SFTypeObj[type1].ReinforcementType;
          int people1 = this.game.Data.SFObj[sf].People;
          for (int counter4 = simpleList3.Counter; counter4 >= 0; counter4 += -1)
          {
            int index14 = simpleList3.Id[counter4];
            int type2 = this.game.Data.SFObj[index14].Type;
            int people2 = this.game.Data.SFObj[index14].People;
            if (type2 == type1 & people2 == people1)
              simpleList6.RemoveNr(counter4);
          }
        }
      }
      this.TargetPageMax = this.targetUnr <= -1 ? Convert.ToInt32(Decimal.Divide(Math.Ceiling(new Decimal(0 + simpleList6.Counter + 1)), new Decimal(num11))) : (int) Math.Round(Math.Ceiling((double) (this.game.Data.UnitObj[this.targetUnr].SFCount + 1 + simpleList6.Counter + 1) / (double) num11));
      if (this.TargetPageMax < 1)
        this.TargetPageMax = 1;
      if (this.TargetPage < 1)
        this.TargetPage = 1;
      if (this.TargetPage > this.TargetPageMax)
        this.TargetPage = this.TargetPageMax;
      int num13;
      int num14;
      int num15;
      int num16;
      int num17;
      if (this.targetUnr > -1)
      {
        int sfCount = this.game.Data.UnitObj[this.targetUnr].SFCount;
        for (int index15 = 0; index15 <= sfCount; index15 += 1)
        {
          int sf = this.game.Data.UnitObj[this.targetUnr].SFList[index15];
          int type3 = this.game.Data.SFObj[sf].Type;
          int reinforcementType = this.game.Data.SFTypeObj[type3].ReinforcementType;
          int people3 = this.game.Data.SFObj[sf].People;
          int qty2 = this.game.Data.SFObj[sf].Qty;
          int num18 = 0;
          for (int counter5 = simpleList3.Counter; counter5 >= 0; counter5 += -1)
          {
            int index16 = simpleList3.Id[counter5];
            int type4 = this.game.Data.SFObj[index16].Type;
            int people4 = this.game.Data.SFObj[index16].People;
            int qty3 = this.game.Data.SFObj[index16].Qty;
            if (type4 == type3 & people4 == people3)
            {
              num18 += simpleList3.Weight[counter5];
              simpleList3.RemoveNr(counter5);
            }
          }
          if (num18 <= 0)
            num18 = 0;
          if (this.game.Data.SFTypeObj[type3].CarryCap < 1 & this.game.Data.transportMovementType[this.game.Data.SFTypeObj[type3].MoveType] == 2)
            num13 += this.game.Data.SFTypeObj[type3].Weight * (qty2 + num18);
          if (this.game.Data.SFTypeObj[type3].CarryCap < 1 & this.game.Data.transportMovementType[this.game.Data.SFTypeObj[type3].MoveType] == 2)
            num14 += this.game.Data.SFTypeObj[type3].manpower * (qty2 + num18);
          if (this.game.Data.transportMovementType[this.game.Data.SFTypeObj[type3].MoveType] != 2)
            num15 += this.game.Data.SFTypeObj[type3].CarryCap * (qty2 + num18);
          if (this.game.Data.transportMovementType[this.game.Data.SFTypeObj[type3].MoveType] != 2)
            num16 += this.game.Data.SFTypeObj[type3].manpowerCarry * (qty2 + num18);
          num17 += this.game.Data.SFTypeObj[type3].PowerPts * (qty2 - num18);
          if (index15 >= (this.TargetPage - 1) * num11 & index15 <= (this.TargetPage - 1) * num11 + (num11 - 1))
          {
            DrawMod.DrawBlock(ref toG, x1_2, y1_2, maxValue, h2, 0, 0, 0, 128);
            num12 += 1;
            int people5 = this.game.Data.SFObj[sf].People;
            int symbolSpriteId = this.game.Data.SFTypeObj[type3].SymbolSpriteID;
            ref Graphics local1 = ref toG;
            Bitmap bitmap = BitmapStore.GetBitmap(symbolSpriteId);
            ref Bitmap local2 = ref bitmap;
            int sftypenr = type3;
            int ppl = people5;
            int tx = x1_2 + 3;
            int ty = y1_2 + 7;
            DrawMod.DrawWithArtCode(ref local1, ref local2, 34, 17, sftypenr, ppl, tx, ty, -1, -1);
            int num19 = qty2 * this.game.Data.SFTypeObj[type3].Ratio;
            int num20 = num18 * this.game.Data.SFTypeObj[type3].Ratio;
            tstring9: String = (num19 + num20).ToString() + "x " + this.game.Data.SFTypeObj[type3].Name + "(" + Strings.Left(this.game.Data.PeopleObj[people5].Name, 3) + ")";
            DrawMod.DrawTextColouredMarc(ref toG, tstring9, this.game.MarcFont4, x1_2 + 65, y1_2 + 2, Color.White);
            if (this.targetUnr == -3)
            {
              tstring10: String = this.game.Data.SFTypeObj[type3].scrapable.ToString() + "%";
              DrawMod.DrawTextColouredMarc(ref toG, tstring10, this.game.MarcFont4, x1_2 + maxValue - 40, y1_2 + 15, Color.White);
            }
            else if (num20 > 0)
            {
              tstring11: String = "+" + num20.ToString();
              DrawMod.DrawTextColouredMarc(ref toG, tstring11, this.game.MarcFont4, x1_2 + maxValue - 40, y1_2 + 15, Color.White);
            }
            if (reinforcementType > -1 & index8 > -1 & this.targetUnr > -1)
            {
              int num21 = SL.FindWeight(reinforcementType, people5) * this.game.Data.ReinfRatio[reinforcementType];
              int num22 = simpleList4.FindWeight(reinforcementType, people5) * this.game.Data.ReinfRatio[reinforcementType];
              int num23 = 0;
              if (this.targetUnr > -1 && this.game.Data.UnitObj[this.targetUnr].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.targetUnr].Historical].Type == 8)
                num23 = 1;
              if ((num21 > 0 | num22 > 0) & !this.game.HandyFunctionsObj.CheckIsBattlegroup(this.targetUnr) & num23 == 0)
              {
                tstring12: String = "Reinf. max: " + num21.ToString() + "/" + num22.ToString();
                if (num21 > num22)
                  DrawMod.DrawTextColouredMarc(ref toG, tstring12, this.game.MarcFont4, x1_2 + 65, y1_2 + 20, Color.Red);
                else
                  DrawMod.DrawTextColouredMarc(ref toG, tstring12, this.game.MarcFont4, x1_2 + 65, y1_2 + 20, Color.Gray);
              }
              else
              {
                tstring13: String = "No organisational limit";
                DrawMod.DrawTextColouredMarc(ref toG, tstring13, this.game.MarcFont4, x1_2 + 65, y1_2 + 20, Color.Gray);
              }
            }
            else
            {
              tstring14: String = "No organisational limit";
              DrawMod.DrawTextColouredMarc(ref toG, tstring14, this.game.MarcFont4, x1_2 + 65, y1_2 + 20, Color.Gray);
            }
            y1_2 += 42;
          }
        }
      }
      int num24 = num12;
      int num25;
      if (this.targetUnr == -2 | this.targetUnr == -3 | this.targetUnr > -1)
      {
        int counter6 = simpleList3.Counter;
        for (int index17 = 0; index17 <= counter6; index17 += 1)
        {
          int index18 = simpleList3.Id[index17];
          int type = this.game.Data.SFObj[index18].Type;
          int reinforcementType = this.game.Data.SFTypeObj[type].ReinforcementType;
          int people = this.game.Data.SFObj[index18].People;
          qty1 = this.game.Data.SFObj[index18].Qty;
          int num26 = simpleList3.Weight[index17];
          if (num26 <= 0)
            num26 = 0;
          if (this.game.Data.SFTypeObj[type].CarryCap < 1 & this.game.Data.transportMovementType[this.game.Data.SFTypeObj[type].MoveType] == 2)
            num13 += this.game.Data.SFTypeObj[type].Weight * num26;
          if (this.game.Data.SFTypeObj[type].CarryCap < 1 & this.game.Data.transportMovementType[this.game.Data.SFTypeObj[type].MoveType] == 2)
            num14 += this.game.Data.SFTypeObj[type].manpower * num26;
          if (this.game.Data.transportMovementType[this.game.Data.SFTypeObj[type].MoveType] != 2)
            num15 += this.game.Data.SFTypeObj[type].CarryCap * num26;
          if (this.game.Data.transportMovementType[this.game.Data.SFTypeObj[type].MoveType] != 2)
            num16 += this.game.Data.SFTypeObj[type].manpowerCarry * num26;
          num17 += this.game.Data.SFTypeObj[type].PowerPts * num26;
          if (index17 + num24 + 1 >= (this.TargetPage - 1) * num11 & index17 + num24 + 1 <= (this.TargetPage - 1) * num11 + (num11 - 1))
          {
            DrawMod.DrawBlock(ref toG, x1_2, y1_2, maxValue, h2, 0, 0, 0, 128);
            num12 += 1;
            int symbolSpriteId = this.game.Data.SFTypeObj[type].SymbolSpriteID;
            ref Graphics local3 = ref toG;
            Bitmap bitmap = BitmapStore.GetBitmap(symbolSpriteId);
            ref Bitmap local4 = ref bitmap;
            int sftypenr = type;
            int ppl = people;
            int tx = x1_2 + 3;
            int ty = y1_2 + 7;
            DrawMod.DrawWithArtCode(ref local3, ref local4, 34, 17, sftypenr, ppl, tx, ty, -1, -1);
            int num27 = 0;
            int num28 = num26 * this.game.Data.SFTypeObj[type].Ratio;
            string[] strArray1 = new string[6];
            string[] strArray2 = strArray1;
            num25 = num27 + num28;
            str: String = num25.ToString();
            strArray2[0] = str;
            strArray1[1] = "x ";
            strArray1[2] = this.game.Data.SFTypeObj[type].Name;
            strArray1[3] = "(";
            strArray1[4] = Strings.Left(this.game.Data.PeopleObj[people].Name, 3);
            strArray1[5] = ")";
            tstring15: String = string.Concat(strArray1);
            DrawMod.DrawTextColouredMarc(ref toG, tstring15, this.game.MarcFont4, x1_2 + 65, y1_2 + 2, Color.White);
            if (this.targetUnr == -3)
            {
              tstring16: String = this.game.Data.SFTypeObj[type].scrapable.ToString() + "%";
              DrawMod.DrawTextColouredMarc(ref toG, tstring16, this.game.MarcFont4, x1_2 + maxValue - 40, y1_2 + 15, Color.White);
            }
            else if (num28 > 0)
            {
              tstring17: String = "+" + num28.ToString();
              DrawMod.DrawTextColouredMarc(ref toG, tstring17, this.game.MarcFont4, x1_2 + maxValue - 40, y1_2 + 15, Color.White);
            }
            if (this.targetUnr == -3)
            {
              tstring18: String = "Earmarked for scrapping";
              DrawMod.DrawTextColouredMarc(ref toG, tstring18, this.game.MarcFont4, x1_2 + 65, y1_2 + 20, Color.Gray);
            }
            else if (reinforcementType > -1 & index8 > -1 & this.targetUnr > -1)
            {
              int num29 = SL.FindWeight(reinforcementType, people) * this.game.Data.ReinfRatio[reinforcementType];
              int num30 = simpleList4.FindWeight(reinforcementType, people) * this.game.Data.ReinfRatio[reinforcementType];
              int num31 = 0;
              if (this.targetUnr > -1 && this.game.Data.UnitObj[this.targetUnr].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.targetUnr].Historical].Type == 8)
                num31 = 1;
              if ((num29 > 0 | num30 > 0) & !this.game.HandyFunctionsObj.CheckIsBattlegroup(this.targetUnr) & num31 == 0)
              {
                tstring19: String = "Reinf. max: " + num29.ToString() + "/" + num30.ToString();
                if (num29 > num30)
                  DrawMod.DrawTextColouredMarc(ref toG, tstring19, this.game.MarcFont4, x1_2 + 65, y1_2 + 20, Color.Red);
                else
                  DrawMod.DrawTextColouredMarc(ref toG, tstring19, this.game.MarcFont4, x1_2 + 65, y1_2 + 20, Color.Gray);
              }
              else
              {
                tstring20: String = "No organisational limit";
                DrawMod.DrawTextColouredMarc(ref toG, tstring20, this.game.MarcFont4, x1_2 + 65, y1_2 + 20, Color.Gray);
              }
            }
            else
            {
              tstring21: String = "No organisational limit";
              DrawMod.DrawTextColouredMarc(ref toG, tstring21, this.game.MarcFont4, x1_2 + 65, y1_2 + 20, Color.Gray);
            }
            y1_2 += 42;
          }
        }
      }
      int y1_3 = 125 + num11 * 42;
      DrawMod.DrawBlock(ref toG, x1_2, y1_3, maxValue, h2, 0, 0, 0, 128);
      if (this.TargetPage > 1)
      {
        let mut tsubpart: SubPartClass =  new TextButtonPartClass(" < ", 50, tBackbitmap: (ref this.OwnBitmap), bbx: (x1_2 + 10), bby: (y1_3 + 4), usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.TargetPrevId = this.AddSubPart(ref tsubpart, x1_2 + 10, y1_3 + 4, 50, 35, 1);
      }
      else
      {
        let mut tsubpart: SubPartClass =  new TextButtonPartClass(" < ", 50, tBackbitmap: (ref this.OwnBitmap), bbx: (x1_2 + 10), bby: (y1_3 + 4), tinactive: true, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.TargetPrevId = this.AddSubPart(ref tsubpart, x1_2 + 10, y1_3 + 4, 50, 35, 0);
      }
      if (this.TargetPage < this.TargetPageMax)
      {
        let mut tsubpart: SubPartClass =  new TextButtonPartClass(" > ", 50, tBackbitmap: (ref this.OwnBitmap), bbx: (x1_2 + 200), bby: (y1_3 + 4), usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.TargetNextId = this.AddSubPart(ref tsubpart, x1_2 + 200, y1_3 + 4, 50, 35, 1);
      }
      else
      {
        let mut tsubpart: SubPartClass =  new TextButtonPartClass(" > ", 50, tBackbitmap: (ref this.OwnBitmap), bbx: (x1_2 + 200), bby: (y1_3 + 4), tinactive: true, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.TargetNextId = this.AddSubPart(ref tsubpart, x1_2 + 200, y1_3 + 4, 50, 35, 0);
      }
      tstring22: String = this.TargetPage.ToString() + "/" + this.TargetPageMax.ToString();
      DrawMod.DrawTextColouredMarcCenter(ref toG, tstring22, this.game.MarcFont4, x1_2 + 130, y1_3 + 12, Color.White);
      int x1_3 = 245;
      int y1_4 = 125;
      int w1 = 235;
      int h3 = 40;
      this.SourcePageMax = this.sourceUnr <= -1 ? Convert.ToInt32(Decimal.Divide(Math.Ceiling(new Decimal(0 + simpleList6.Counter + 1)), new Decimal(num11))) : (int) Math.Round(Math.Ceiling((double) (this.game.Data.UnitObj[this.sourceUnr].SFCount + 1) / (double) num11));
      if (this.SourcePageMax < 1)
        this.SourcePageMax = 1;
      if (this.SourcePage < 1)
        this.SourcePage = 1;
      if (this.SourcePage > this.SourcePageMax)
        this.SourcePage = this.SourcePageMax;
      int num32;
      int num33;
      int num34;
      int num35;
      int num36;
      if (this.sourceUnr > -1)
      {
        int index19 = -1;
        int sfCount = this.game.Data.UnitObj[this.sourceUnr].SFCount;
        for (int index20 = 0; index20 <= sfCount; index20 += 1)
        {
          int sf = this.game.Data.UnitObj[this.sourceUnr].SFList[index20];
          int type = this.game.Data.SFObj[sf].Type;
          int people6 = this.game.Data.SFObj[sf].People;
          int reinforcementType = this.game.Data.SFTypeObj[type].ReinforcementType;
          int num37 = this.game.Data.SFObj[sf].Qty;
          int num38 = this.TL.FindWeight(sf);
          if (num38 <= 0)
            num38 = 0;
          if (num38 > 0)
            num37 = num37;
          int people7 = this.game.Data.SFObj[sf].People;
          if (this.game.Data.SFTypeObj[type].CarryCap < 1 & this.game.Data.transportMovementType[this.game.Data.SFTypeObj[type].MoveType] == 2)
            num32 += this.game.Data.SFTypeObj[type].manpower * (num37 - num38);
          if (this.game.Data.SFTypeObj[type].CarryCap < 1 & this.game.Data.transportMovementType[this.game.Data.SFTypeObj[type].MoveType] == 2)
            num33 += this.game.Data.SFTypeObj[type].Weight * (num37 - num38);
          if (this.game.Data.transportMovementType[this.game.Data.SFTypeObj[type].MoveType] != 2)
            num34 += this.game.Data.SFTypeObj[type].CarryCap * (num37 - num38);
          if (this.game.Data.transportMovementType[this.game.Data.SFTypeObj[type].MoveType] != 2)
            num35 += this.game.Data.SFTypeObj[type].manpowerCarry * (num37 - num38);
          num36 += this.game.Data.SFTypeObj[type].PowerPts * (num37 - num38);
          if (index20 >= (this.SourcePage - 1) * num11 & index20 <= (this.SourcePage - 1) * num11 + (num11 - 1))
          {
            bool flag1 = true;
            if (reinforcementType > -1)
            {
              if (this.game.Data.Product == 7)
              {
                if (simpleList4.FindWeight(reinforcementType) <= 0)
                  flag1 = false;
              }
              else if (simpleList4.FindWeight(reinforcementType, people7) <= 0)
                flag1 = false;
            }
            else
              flag1 = false;
            if (this.targetUnr > -1)
            {
              if (this.game.HandyFunctionsObj.CheckIsBattlegroup(this.targetUnr))
                flag1 = true;
            }
            else
              flag1 = true;
            if (this.targetUnr == -3)
            {
              if (index1 > -1)
              {
                if (Conversions.ToInteger(this.game.Data.StringListObj[index1].GetData(0, people7, 1)) < 1)
                  flag1 = false;
                if (this.game.Data.SFTypeObj[type].scrapable <= 0)
                  flag1 = false;
              }
              else
                flag1 = false;
            }
            if (this.targetUnr > -1 && this.game.Data.UnitObj[this.targetUnr].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.targetUnr].Historical].Type == 8)
              flag1 = true;
            if (flag1)
              DrawMod.DrawBlock(ref toG, x1_3, y1_4, w1, h3, 0, 0, 0, 128);
            else
              DrawMod.DrawBlock(ref toG, x1_3, y1_4, w1, h3, 128, 0, 0, 128);
            index19 += 1;
            int symbolSpriteId = this.game.Data.SFTypeObj[type].SymbolSpriteID;
            ref Graphics local5 = ref toG;
            Bitmap bitmap = BitmapStore.GetBitmap(symbolSpriteId);
            ref Bitmap local6 = ref bitmap;
            int sftypenr = type;
            int ppl = people7;
            int tx = x1_3 + 3;
            int ty = y1_4 + 7;
            DrawMod.DrawWithArtCode(ref local5, ref local6, 34, 17, sftypenr, ppl, tx, ty, -1, -1);
            int num39 = num37 * this.game.Data.SFTypeObj[type].Ratio;
            tstring23: String = num39.ToString() + "x " + this.game.Data.SFTypeObj[type].Name + "(" + Strings.Left(this.game.Data.PeopleObj[people7].Name, 3) + ")";
            bool flag2 = false;
            bool flag3 = false;
            if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.sourceUnr].Historical].GiveHisVarValue(11) > 0)
            {
              if (this.targetUnr > -1)
              {
                if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.targetUnr].Historical].Type < 8 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.targetUnr].Historical].GiveHisVarValue(11) < 1)
                  flag2 = true;
              }
              else if (this.targetUnr == -2)
              {
                flag3 = true;
                flag2 = true;
              }
            }
            if (this.game.Data.PeopleObj[people7].tv1 >= 11 & this.game.Data.PeopleObj[people7].tv1 <= 19)
            {
              if (this.targetUnr > -1)
              {
                if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.targetUnr].Historical].Type < 8 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.targetUnr].Historical].GiveHisVarValue(11) < 1)
                  flag2 = true;
              }
              else if (this.targetUnr == -2)
              {
                flag3 = true;
                flag2 = true;
              }
            }
            if (flag2)
            {
              DrawMod.DrawTextColouredMarc(ref toG, tstring23, this.game.MarcFont4, x1_3 + 65, y1_4 + 2, Color.White);
              if (flag3)
                DrawMod.DrawTextColouredMarc(ref toG, "No Battlegroup for Militia", this.game.MarcFont4, x1_3 + 65, y1_4 + 20, Color.Gray);
              else
                DrawMod.DrawTextColouredMarc(ref toG, "Target unsuitable for Militia", this.game.MarcFont4, x1_3 + 65, y1_4 + 20, Color.Gray);
            }
            else if (this.game.Data.SFTypeObj[type].Theater == 2 && this.targetUnr == -2)
            {
              DrawMod.DrawTextColouredMarc(ref toG, "No Battlegroup for Air", this.game.MarcFont4, x1_3 + 65, y1_4 + 20, Color.Gray);
              flag2 = true;
            }
            if (!flag2)
            {
              if (flag1 | this.targetUnr == -2)
              {
                if (this.SlidersId[index19] < 1)
                {
                  int[] slidersId = this.SlidersId;
                  int index21 = index19;
                  let mut tsubpart: SubPartClass =  new NumberSliderSubPartClass2(this.game, "", " of " + num39.ToString() + "x " + this.game.Data.SFTypeObj[type].Name + "(" + Strings.Left(this.game.Data.PeopleObj[people7].Name, 3) + ")", 190, 0, num37 * this.game.Data.SFTypeObj[type].Ratio, num38 * this.game.Data.SFTypeObj[type].Ratio, tsmallchange: this.game.Data.SFTypeObj[type].Ratio, tbackbitmap: (ref this.OwnBitmap), bbx: (x1_3 + 45), bby: (y1_4 + 0));
                  int num40 = this.AddSubPart(ref tsubpart, x1_3 + 45, y1_4 + 0, 190, 40, 0);
                  slidersId[index21] = num40;
                  this.SlidersSfnr[index19] = sf;
                }
              }
              else if (this.targetUnr == -3)
              {
                DrawMod.DrawTextColouredMarc(ref toG, tstring23, this.game.MarcFont4, x1_3 + 65, y1_4 + 2, Color.White);
                DrawMod.DrawTextColouredMarc(ref toG, "Cannot be Scrapped", this.game.MarcFont4, x1_3 + 65, y1_4 + 20, Color.Gray);
              }
              else
              {
                DrawMod.DrawTextColouredMarc(ref toG, tstring23, this.game.MarcFont4, x1_3 + 65, y1_4 + 2, Color.White);
                DrawMod.DrawTextColouredMarc(ref toG, "No Target Unit TOE match", this.game.MarcFont4, x1_3 + 65, y1_4 + 20, Color.Gray);
              }
            }
            y1_4 += 42;
          }
        }
      }
      int y1_5 = 125 + num11 * 42;
      DrawMod.DrawBlock(ref toG, x1_3, y1_5, w1, h3, 0, 0, 0, 128);
      if (this.SourcePage > 1)
      {
        let mut tsubpart: SubPartClass =  new TextButtonPartClass(" < ", 50, tBackbitmap: (ref this.OwnBitmap), bbx: (x1_3 + 10), bby: (y1_5 + 4), usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.SourcePrevId = this.AddSubPart(ref tsubpart, x1_3 + 10, y1_5 + 4, 50, 35, 1);
      }
      else
      {
        let mut tsubpart: SubPartClass =  new TextButtonPartClass(" < ", 50, tBackbitmap: (ref this.OwnBitmap), bbx: (x1_3 + 10), bby: (y1_5 + 4), tinactive: true, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.SourcePrevId = this.AddSubPart(ref tsubpart, x1_3 + 10, y1_5 + 4, 50, 35, 0);
      }
      if (this.SourcePage < this.SourcePageMax)
      {
        let mut tsubpart: SubPartClass =  new TextButtonPartClass(" > ", 50, tBackbitmap: (ref this.OwnBitmap), bbx: (x1_3 + 180), bby: (y1_5 + 4), usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.SourceNextId = this.AddSubPart(ref tsubpart, x1_3 + 180, y1_5 + 4, 50, 35, 1);
      }
      else
      {
        let mut tsubpart: SubPartClass =  new TextButtonPartClass(" > ", 50, tBackbitmap: (ref this.OwnBitmap), bbx: (x1_3 + 180), bby: (y1_5 + 4), tinactive: true, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.SourceNextId = this.AddSubPart(ref tsubpart, x1_3 + 180, y1_5 + 4, 50, 35, 0);
      }
      tstring24: String = this.SourcePage.ToString() + "/" + this.SourcePageMax.ToString();
      DrawMod.DrawTextColouredMarcCenter(ref toG, tstring24, this.game.MarcFont4, x1_3 + 120, y1_5 + 12, Color.White);
      bool flag = false;
      SimpleStringList simpleStringList1 = SimpleStringList::new();
      int num41 = 0;
      int num42 = 0;
      if (this.targetUnr < 0)
        num41 = 1;
      if (this.targetUnr > -1 && this.game.HandyFunctionsObj.CheckIsBattlegroup(this.targetUnr))
        num41 = 1;
      if (this.targetUnr > -1 && this.game.Data.UnitObj[this.targetUnr].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.targetUnr].Historical].Type == 8)
      {
        num41 = 1;
        num42 = 1;
      }
      if (num41 == 0)
      {
        int counter7 = simpleList5.Counter;
        for (int index22 = 0; index22 <= counter7; index22 += 1)
        {
          if (simpleList5.Weight[index22] < 0)
          {
            simpleStringList1.Add("Exceeding Target Unit organisational limits.", 1);
            flag = true;
            break;
          }
        }
      }
      if (this.targetUnr != -3 & this.sourceUnr > -1 && num36 < (int) Math.Round((double) this.game.Data.RuleVar[476]) & !(num36 == 0 & this.game.HandyFunctionsObj.GetPowerPtsAbsolute(this.sourceUnr) > 0 & !this.game.Data.UnitObj[this.sourceUnr].IsHQ))
      {
        flag = true;
        SimpleStringList simpleStringList2 = simpleStringList1;
        num25 = (int) Math.Round((double) this.game.Data.RuleVar[476]);
        tid: String = "You cannot reduce Source Unit below " + num25.ToString() + " power points.";
        simpleStringList2.Add(tid, 1);
      }
      if (this.targetUnr == -2 & num17 < (int) Math.Round((double) this.game.Data.RuleVar[476]))
      {
        flag = true;
        SimpleStringList simpleStringList3 = simpleStringList1;
        num25 = (int) Math.Round((double) this.game.Data.RuleVar[476]);
        tid: String = "You cannot create a new Battlegroup with less than " + num25.ToString() + " power points.";
        simpleStringList3.Add(tid, 1);
      }
      if (this.targetUnr == -2 & num17 > (int) Math.Round((double) this.game.Data.RuleVar[477]))
      {
        flag = true;
        SimpleStringList simpleStringList4 = simpleStringList1;
        num25 = (int) Math.Round((double) this.game.Data.RuleVar[477]);
        tid: String = "You cannot create a Battlegroup with more than " + num25.ToString() + " power points.";
        simpleStringList4.Add(tid, 1);
      }
      if (this.targetUnr == -1)
      {
        flag = true;
        simpleStringList1.Add("No Target Unit selected.", 1);
      }
      if (battlegroupTemplate > -1 && this.targetUnr == -2 & this.game.Data.RegimeObj[this.game.Data.Turn].ResPts < this.game.Data.HistoricalUnitObj[battlegroupTemplate].PP)
      {
        flag = true;
        simpleStringList1.Add("You do not have the " + this.game.Data.HistoricalUnitObj[battlegroupTemplate].PP.ToString() + " PP to create a new Battlegroup.", 1);
      }
      int x1_4 = 245;
      int y1_6 = 125 + num11 * 42 + 42;
      int h4 = 62;
      int w2 = 495;
      DrawMod.DrawBlock(ref toG, x1_4, y1_6, w2, h4, 0, 0, 0, 128);
      int num43 = simpleStringList1.Counter + 1;
      if (num43 < 1)
        num43 = 1;
      if (num43 > 3)
        num43 = 3;
      int y = y1_6 + (30 - num43 * 10);
      int num44 = x1_4 + 110;
      int counter8 = simpleStringList1.Counter;
      for (int index23 = 0; index23 <= counter8; index23 += 1)
      {
        tstring25: String = simpleStringList1.Id[index23];
        DrawMod.DrawTextColouredMarcCenter(ref toG, tstring25, this.game.MarcFont4, num44 + 130, y, Color.Red);
        y += 18;
      }
      if (simpleStringList1.Counter == -1)
      {
        if (this.targetUnr == -3)
        {
          if (this.TL.Counter == -1)
          {
            tstring26: String = "Please select troops for Scrapping.";
            DrawMod.DrawTextColouredMarcCenter(ref toG, tstring26, this.game.MarcFont4, num44 + 130, y, Color.White);
          }
          else
          {
            tstring27: String = "Transfer selection for Scrapping.";
            DrawMod.DrawTextColouredMarcCenter(ref toG, tstring27, this.game.MarcFont4, num44 + 130, y, Color.White);
          }
        }
        else if (this.TL.Counter == -1)
        {
          tstring28: String = "Please select troops to transfer.";
          DrawMod.DrawTextColouredMarcCenter(ref toG, tstring28, this.game.MarcFont4, num44 + 130, y, Color.White);
        }
        else
        {
          tstring29: String = "Transfer selection is valid.";
          DrawMod.DrawTextColouredMarcCenter(ref toG, tstring29, this.game.MarcFont4, num44 + 130, y, Color.White);
        }
      }
      int x1_5 = 245;
      int y1_7 = 125 + num11 * 42 + 42 + 64;
      int h5 = 40;
      DrawMod.DrawBlock(ref toG, x1_5, y1_7, w2, h5, 0, 0, 0, 128);
      int num45 = y1_7 + 4;
      int num46 = x1_5 + 45;
      let mut tsubpart1: SubPartClass =  new TextButtonPartClass("Cancel", 150, "Click to return to main screen.", ref this.OwnBitmap, num46, num45, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.cancelid = this.AddSubPart(ref tsubpart1, num46, num45, 150, 35, 1);
      int num47 = num46 + 250;
      str1: String = "";
      if (this.targetUnr == -2 & battlegroupTemplate > -1)
        str1 = str1 + " [" + this.game.Data.HistoricalUnitObj[battlegroupTemplate].PP.ToString() + " PP]";
      else if (this.targetUnr <= -1)
        ;
      if (this.targetUnr == -3)
      {
        if (this.TL.Counter > -1 & !flag)
        {
          let mut tsubpart2: SubPartClass =  new TextButtonPartClass("Scrap" + str1, 150, "Go ahead and Scrap the selected equipment.", ref this.OwnBitmap, num47, num45, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.transferid = this.AddSubPart(ref tsubpart2, num47, num45, 150, 35, 1);
        }
        else
        {
          let mut tsubpart3: SubPartClass =  new TextButtonPartClass("Scrap" + str1, 150, "Not possible to Scrap.", ref this.OwnBitmap, num47, num45, true, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.transfer2id = this.AddSubPart(ref tsubpart3, num47, num45, 150, 35, 0);
        }
      }
      else if (this.TL.Counter > -1 & !flag)
      {
        let mut tsubpart4: SubPartClass =  new TextButtonPartClass("Transfer" + str1, 150, "Go ahead and make the selected transfer.", ref this.OwnBitmap, num47, num45, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.transferid = this.AddSubPart(ref tsubpart4, num47, num45, 150, 35, 1);
      }
      else
      {
        let mut tsubpart5: SubPartClass =  new TextButtonPartClass("Transfer" + str1, 150, "Not possible to transfer.", ref this.OwnBitmap, num47, num45, true, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.transfer2id = this.AddSubPart(ref tsubpart5, num47, num45, 150, 35, 0);
      }
      int num48 = 5;
      num1 = 980;
      num2 = 110;
      int num49 = 10;
      str2: String = "No source unit selected";
      tstring30: String = "";
      tstring31: String = "";
      if (this.sourceUnr > -1)
        str2 = this.game.Data.UnitObj[this.sourceUnr].Name;
      if ((double) toG.MeasureString(str2, DrawMod.TGame.MarcFont3).Width > 230.0)
      {
        int num50 = Strings.InStr(str2, " ");
        if (num50 > 0)
        {
          int num51 = Strings.InStr(num50 + 1, str2, " ");
          if (num51 > 0)
          {
            int num52 = Strings.InStr(num51 + 1, str2, " ");
            if (num52 > 0)
            {
              tstring31 = Strings.Mid(str2, num52 + 1);
              tstring30 = Strings.Left(str2, num52 - 1);
            }
          }
          else
          {
            int num53 = Strings.InStr(str2, " ");
            if (num53 <= 0 || Strings.InStr(num53 + 1, str2, " ") <= 0)
              ;
          }
        }
        if (tstring30.Length > 0)
        {
          DrawMod.DrawTextColouredMarcCenter(ref toG, tstring30, this.game.MarcFont4, num48 + 360, num49 + 20, Color.White);
          DrawMod.DrawTextColouredMarcCenter(ref toG, tstring31, this.game.MarcFont4, num48 + 360, num49 + 35, Color.White);
        }
        else
          DrawMod.DrawTextColouredMarcCenter(ref toG, str2, this.game.MarcFont4, num48 + 360, num49 + 30, Color.White);
      }
      else
        DrawMod.DrawTextColouredMarcCenter(ref toG, str2, this.game.MarcFont3, num48 + 360, num49 + 30, Color.White);
      tstring32: String = "Wgt: " + num33.ToString() + " Car: " + num34.ToString() + " Pow: " + num36.ToString();
      DrawMod.DrawTextColouredMarcCenter(ref toG, tstring32, this.game.MarcFont4, num48 + 360, num49 + 60, Color.White);
      if (num32 > 0 | num35 > 0)
      {
        tstring33: String = "ManpWgt: " + num32.ToString() + " ManpCar: " + num35.ToString();
        DrawMod.DrawTextColouredMarcCenter(ref toG, tstring33, this.game.MarcFont4, num48 + 360, num49 + 80, Color.White);
      }
      str3: String = "No target unit selected";
      if (this.targetUnr > -1)
        str3 = this.game.Data.UnitObj[this.targetUnr].Name;
      if (this.targetUnr == -2)
        str3 = "New Battlegroup";
      if (this.targetUnr == -3)
        str3 = "Selected for Scrapping";
      if (this.targetUnr == -2 && battlegroupTemplate > -1)
        str3 = "New " + this.game.Data.HistoricalUnitObj[battlegroupTemplate].Name;
      tstring34: String = "";
      tstring35: String = "";
      if ((double) toG.MeasureString(str3, DrawMod.TGame.MarcFont3).Width > 230.0)
      {
        int num54 = Strings.InStr(str3, " ");
        if (num54 > 0)
        {
          int num55 = Strings.InStr(num54 + 1, str3, " ");
          if (num55 > 0)
          {
            int num56 = Strings.InStr(num55 + 1, str3, " ");
            if (num56 > 0)
            {
              tstring35 = Strings.Mid(str3, num56 + 1);
              tstring34 = Strings.Left(str3, num56 - 1);
            }
          }
          else
          {
            int num57 = Strings.InStr(str3, " ");
            if (num57 <= 0 || Strings.InStr(num57 + 1, str3, " ") <= 0)
              ;
          }
        }
        if (tstring34.Length > 0)
        {
          DrawMod.DrawTextColouredMarcCenter(ref toG, tstring34, this.game.MarcFont4, num48 + 600, num49 + 20, Color.White);
          DrawMod.DrawTextColouredMarcCenter(ref toG, tstring35, this.game.MarcFont4, num48 + 600, num49 + 35, Color.White);
        }
        else
          DrawMod.DrawTextColouredMarcCenter(ref toG, str3, this.game.MarcFont4, num48 + 600, num49 + 30, Color.White);
      }
      else
        DrawMod.DrawTextColouredMarcCenter(ref toG, str3, this.game.MarcFont3, num48 + 600, num49 + 30, Color.White);
      tstring36: String = "Wgt: " + num13.ToString() + " Car: " + num15.ToString() + " Pow: " + num17.ToString();
      DrawMod.DrawTextColouredMarcCenter(ref toG, tstring36, this.game.MarcFont4, num48 + 600, num49 + 60, Color.White);
      if (!(num14 > 0 | num16 > 0))
        return;
      tstring37: String = "ManpWgt: " + num14.ToString() + " ManpCar: " + num16.ToString();
      DrawMod.DrawTextColouredMarcCenter(ref toG, tstring37, this.game.MarcFont4, num48 + 600, num49 + 80, Color.White);
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
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return windowReturnClass;
    }

    pub HandleMouseUp: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      OrderResult orderResult = OrderResult::new();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
label_10:
        for (int index1 = 0; index1 <= subPartCounter; index1 += 1)
        {
          if (this.SubPartList[index1].Scroller)
          {
            int index2 = 0;
            while (this.SlidersId[index2] != this.SubPartID[index1])
            {
              index2 += 1;
              if (index2 > 19)
                goto label_10;
            }
            int tweight = (int) Math.Round((double) this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1], b) / (double) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.SlidersSfnr[index2]].Type].Ratio);
            this.SubPartFlag[index1] = true;
            this.FlagAll();
            windowReturnClass.SetFlag(true);
            this.SubPartList[index1].Scroller = false;
            int nr = this.TL.FindNr(this.SlidersSfnr[index2]);
            if (nr > -1)
              this.TL.RemoveNr(nr);
            this.TL.Add(this.SlidersSfnr[index2], tweight);
            this.View();
            return windowReturnClass;
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; index += 1)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] == 1)
          {
            this.SetUnits();
            this.TL = SimpleList::new();
            this.sourceUnr = this.MouseData2[index];
            this.View();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (this.MouseData[index] == 2)
          {
            this.SetUnits();
            this.TL = SimpleList::new();
            this.targetUnr = this.MouseData2[index];
            this.View();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
      }
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
label_125:
        for (int index1 = 0; index1 <= subPartCounter; index1 += 1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int index2 = 0;
            while (this.SubPartID[index1] != this.SlidersId[index2])
            {
              index2 += 1;
              if (index2 > 19)
              {
                int num1 = this.SubPartID[index1];
                if (num1 == this.SourcePrevId)
                {
                  this.SetUnits();
                  --this.SourcePage;
                  this.FlagAll();
                  windowReturnClass.SetFlag(true);
                  this.View();
                  return windowReturnClass;
                }
                if (num1 == this.SourceNextId)
                {
                  this.SetUnits();
                  this += 1.SourcePage;
                  this.FlagAll();
                  windowReturnClass.SetFlag(true);
                  this.View();
                  return windowReturnClass;
                }
                if (num1 == this.TargetPrevId)
                {
                  --this.TargetPage;
                  this.FlagAll();
                  windowReturnClass.SetFlag(true);
                  this.View();
                  return windowReturnClass;
                }
                if (num1 == this.TargetNextId)
                {
                  this += 1.TargetPage;
                  this.FlagAll();
                  windowReturnClass.SetFlag(true);
                  this.View();
                  return windowReturnClass;
                }
                if (num1 == this.cancelid)
                {
                  windowReturnClass.AddCommand(6, 0);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.transferid)
                {
                  int unr = -1;
                  int battlegroupTemplate = this.game.HandyFunctionsObj.GetBattlegroupTemplate(this.game.Data.Turn);
                  int sfCount1 = this.game.Data.UnitObj[this.sourceUnr].SFCount;
                  int num2;
                  int num3;
                  for (int index3 = 0; index3 <= sfCount1; index3 += 1)
                  {
                    int sf = this.game.Data.UnitObj[this.sourceUnr].SFList[index3];
                    int qty = this.game.Data.SFObj[sf].Qty;
                    int type = this.game.Data.SFObj[sf].Type;
                    num2 += this.game.Data.SFTypeObj[type].FuelCarry * qty;
                    num3 += this.game.Data.SFTypeObj[type].SupplyCarry * qty;
                  }
                  if (this.targetUnr == -3)
                  {
                    int counter1 = this.TL.Counter;
                    for (int index4 = 0; index4 <= counter1; index4 += 1)
                    {
                      this.TL.Data5[index4] = this.TL.Weight[index4];
                      this.TL.Weight[index4] = this.TL.Id[index4];
                    }
                    this.TL.ReverseSort();
                    int counter2 = this.TL.Counter;
                    for (int index5 = 0; index5 <= counter2; index5 += 1)
                      this.TL.Weight[index5] = this.TL.Data5[index5];
                    if ((double) this.game.Data.RuleVar[486] > 0.0)
                    {
                      int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[486]));
                      int counter3 = this.TL.Counter;
                      for (int index6 = 0; index6 <= counter3; index6 += 1)
                      {
                        int index7 = this.TL.Id[index6];
                        int qty = this.game.Data.SFObj[index7].Qty;
                        int people = this.game.Data.SFObj[index7].People;
                        int type = this.game.Data.SFObj[index7].Type;
                        int xp = this.game.Data.SFObj[index7].Xp;
                        int ap = this.game.Data.SFObj[index7].Ap;
                        int rdn = this.game.Data.SFObj[index7].Rdn;
                        int mor = this.game.Data.SFObj[index7].Mor;
                        int supplyConsume = this.game.Data.UnitObj[this.sourceUnr].SupplyConsume;
                        int offMod = this.game.Data.SFObj[index7].OffMod;
                        int defMod = this.game.Data.SFObj[index7].DefMod;
                        int SfType = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, people, 1)));
                        int Qty = 0;
                        if (this.game.Data.SFTypeObj[type].scrapable >= 100)
                          Qty = this.TL.Weight[index6] * (int) Math.Round(Math.Floor((double) this.game.Data.SFTypeObj[type].scrapable / 100.0));
                        else if (this.game.Data.SFTypeObj[type].scrapable > 1)
                        {
                          int num4 = this.TL.Weight[index6];
                          for (int index8 = 1; index8 <= num4; index8 += 1)
                          {
                            if (DrawMod.RandyNumber.Next(1, 100) <= this.game.Data.SFTypeObj[type].scrapable)
                              Qty += 1;
                          }
                        }
                        else
                          Qty = 0;
                        int Ap = ap - 25;
                        if (Ap < 0)
                          Ap = 0;
                        this.game.HandyFunctionsObj.AddTroops3(this.sourceUnr, SfType, people, Qty, xp, rdn, Ap, mor, supplyConsume, offmod: offMod, defmod: defMod);
                        this.game.HandyFunctionsObj.RemoveTroops(this.sourceUnr, type, people, this.TL.Weight[index6], -1);
                      }
                      int num5 = 0;
                      int num6 = 0;
                      int sfCount2 = this.game.Data.UnitObj[this.sourceUnr].SFCount;
                      for (int index9 = 0; index9 <= sfCount2; index9 += 1)
                      {
                        int sf = this.game.Data.UnitObj[this.sourceUnr].SFList[index9];
                        int qty = this.game.Data.SFObj[sf].Qty;
                        int type = this.game.Data.SFObj[sf].Type;
                        num5 += this.game.Data.SFTypeObj[type].SupplyCarry * qty;
                        num6 += this.game.Data.SFTypeObj[type].FuelCarry * qty;
                      }
                      if (num5 < this.game.Data.UnitObj[this.sourceUnr].Supply)
                        this.game.Data.UnitObj[this.sourceUnr].Supply = num5;
                      if (num6 < this.game.Data.UnitObj[this.sourceUnr].Fuel)
                        this.game.Data.UnitObj[this.sourceUnr].Fuel = num6;
                    }
                  }
                  else
                  {
                    if (this.targetUnr == -2)
                    {
                      this.game.ProcessingObj.AddNewUnitBasedOnHistorical(this.game.SelectX, this.game.SelectY, 0, this.game.Data.Turn, battlegroupTemplate);
                      unr = this.game.Data.UnitCounter;
                      int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
                      if ((double) this.game.Data.RuleVar[403] == 1.0)
                      {
                        this.game.Data.HistoricalUnitObj[historicalUnitCounter].SetHisVarValue(71, 50);
                        this.game.Data.HistoricalUnitObj[historicalUnitCounter].SetHisVarValue(72, 10);
                      }
                      this.game.Data.UnitObj[unr].HQ = this.game.Data.UnitObj[this.sourceUnr].HQ;
                      if (this.game.Data.Product == 7 && this.game.Data.UnitObj[this.sourceUnr].HQ > -1 && this.game.Data.UnitObj[this.game.Data.UnitObj[this.sourceUnr].HQ].HQ > -1)
                        this.game.Data.UnitObj[unr].HQ = this.game.Data.UnitObj[this.game.Data.UnitObj[this.sourceUnr].HQ].HQ;
                      this.game.Data.HistoricalUnitObj[historicalUnitCounter].BattleGroup = 1;
                      if ((double) this.game.Data.RuleVar[479] > 0.0)
                      {
                        int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[479]));
                        string str;
                        int num7;
                        for (int index10 = 0; index10 < 99; index10 += 1)
                        {
                          int index11 = DrawMod.RandyNumber.Next(0, this.game.Data.StringListObj[stringListById].Length);
                          if (Conversions.ToInteger(this.game.Data.StringListObj[stringListById].Data[index11, 0]) == this.game.Data.Turn)
                          {
                            str = this.game.Data.StringListObj[stringListById].Data[index11, 1];
                            num7 = 0;
                            int unitCounter = this.game.Data.UnitCounter;
                            for (int index12 = 0; index12 <= unitCounter; index12 += 1)
                            {
                              if (Strings.InStr(this.game.Data.UnitObj[index12].Name, str) > 0)
                                num7 = 1;
                            }
                            if (num7 == 0)
                              index10 = 99999;
                          }
                        }
                        if (num7 == 1)
                        {
                          this.game.Data.HistoricalUnitObj[historicalUnitCounter].CounterString = Strings.Left(this.game.Data.HistoricalUnitObj[battlegroupTemplate].Name, 5);
                        }
                        else
                        {
                          this.game.Data.UnitObj[unr].Name = this.game.Data.HistoricalUnitObj[battlegroupTemplate].Name + " " + str;
                          this.game.Data.HistoricalUnitObj[historicalUnitCounter].Name = this.game.Data.UnitObj[unr].Name;
                          this.game.Data.HistoricalUnitObj[historicalUnitCounter].CounterString = Strings.Left(str, 5);
                        }
                      }
                    }
                    else
                      unr = this.targetUnr;
                    SimpleList SL1 = SimpleList::new();
                    SimpleList simpleList1;
                    SimpleList simpleList2;
                    if ((double) this.game.Data.RuleVar[403] == 1.0)
                    {
                      int sfCount3 = this.game.Data.UnitObj[this.sourceUnr].SFCount;
                      for (int index13 = 0; index13 <= sfCount3; index13 += 1)
                      {
                        int sf = this.game.Data.UnitObj[this.sourceUnr].SFList[index13];
                        int qty = this.game.Data.SFObj[sf].Qty;
                        int people = this.game.Data.SFObj[sf].People;
                        int type = this.game.Data.SFObj[sf].Type;
                        SL1.AddWeight(type, qty);
                      }
                      simpleList1 = DrawMod.TGame.EventRelatedObj.Helper_SupplyItemList_ForSFTypeList(SL1);
                      simpleList2 = this.game.Data.UnitObj[this.sourceUnr].items.list.Clone();
                    }
                    int counter = this.TL.Counter;
                    int num8;
                    int num9;
                    for (int index14 = 0; index14 <= counter; index14 += 1)
                    {
                      int index15 = this.TL.Id[index14];
                      int qty = this.game.Data.SFObj[index15].Qty;
                      int people = this.game.Data.SFObj[index15].People;
                      int type = this.game.Data.SFObj[index15].Type;
                      int xp = this.game.Data.SFObj[index15].Xp;
                      int rdn = this.game.Data.SFObj[index15].Rdn;
                      int mor = this.game.Data.SFObj[index15].Mor;
                      int supplyConsume = this.game.Data.UnitObj[this.sourceUnr].SupplyConsume;
                      int offMod = this.game.Data.SFObj[index15].OffMod;
                      int defMod = this.game.Data.SFObj[index15].DefMod;
                      num8 += this.game.Data.SFTypeObj[type].FuelCarry * this.TL.Weight[index14];
                      num9 += this.game.Data.SFTypeObj[type].SupplyCarry * this.TL.Weight[index14];
                      if ((double) this.game.Data.RuleVar[403] == 1.0)
                      {
                        SimpleList SL2 = SimpleList::new();
                        int tid1 = this.game.Data.SFTypeObj[type].SFTypeVar[45];
                        int tweight1 = this.game.Data.SFTypeObj[type].SFTypeVar[52] * this.TL.Weight[index14];
                        if (tid1 > 0 & simpleList1.FindWeight(tid1) > 0)
                          tweight1 = (int) Math.Round(Math.Floor((double) tweight1 * Math.Min(1.0, (double) simpleList2.FindWeight(tid1) / (double) simpleList1.FindWeight(tid1))));
                        if (tweight1 > 0)
                          SL2.Add(tid1, tweight1);
                        int tid2 = this.game.Data.SFTypeObj[type].SFTypeVar[47];
                        int tweight2 = this.game.Data.SFTypeObj[type].SFTypeVar[53] * this.TL.Weight[index14];
                        if (tid2 > 0 & simpleList1.FindWeight(tid2) > 0)
                          tweight2 = (int) Math.Round(Math.Floor((double) tweight2 * Math.Min(1.0, (double) simpleList2.FindWeight(tid2) / (double) simpleList1.FindWeight(tid2))));
                        if (tweight2 > 0)
                          SL2.Add(tid2, tweight2);
                        int tid3 = this.game.Data.SFTypeObj[type].SFTypeVar[50];
                        int tweight3 = this.game.Data.SFTypeObj[type].SFTypeVar[54] * this.TL.Weight[index14];
                        if (tid3 > 0 & simpleList1.FindWeight(tid3) > 0)
                          tweight3 = (int) Math.Round(Math.Floor((double) tweight3 * Math.Min(1.0, (double) simpleList2.FindWeight(tid3) / (double) simpleList1.FindWeight(tid3))));
                        if (tweight3 > 0)
                          SL2.Add(tid3, tweight3);
                        if (this.game.Data.UnitObj[this.sourceUnr].items.list.CanRemoveWeight(ref SL2))
                        {
                          this.game.Data.UnitObj[this.sourceUnr].items.list.RemoveWeight(ref SL2);
                          this.game.Data.UnitObj[unr].items.list.AddWeight(ref SL2);
                        }
                      }
                      this.game.HandyFunctionsObj.AddTroops3(unr, type, people, this.TL.Weight[index14], xp, rdn, 0, mor, supplyConsume, offmod: offMod, defmod: defMod);
                      this.game.HandyFunctionsObj.RemoveTroops(this.sourceUnr, type, people, this.TL.Weight[index14], -1);
                    }
                    if ((double) this.game.Data.RuleVar[403] == 0.0)
                    {
                      if (num3 > 0)
                      {
                        int num10 = (int) Math.Round((double) (this.game.Data.UnitObj[this.sourceUnr].Supply * num9) / (double) num3);
                        UnitClass[] unitObj1 = this.game.Data.UnitObj;
                        UnitClass[] unitClassArray1 = unitObj1;
                        int index16 = unr;
                        int index17 = index16;
                        unitClassArray1[index17].Supply = unitObj1[index16].Supply + num10;
                        UnitClass[] unitObj2 = this.game.Data.UnitObj;
                        UnitClass[] unitClassArray2 = unitObj2;
                        int sourceUnr = this.sourceUnr;
                        int index18 = sourceUnr;
                        unitClassArray2[index18].Supply = unitObj2[sourceUnr].Supply - num10;
                        if (this.game.Data.UnitObj[this.sourceUnr].Supply < 0)
                          this.game.Data.UnitObj[this.sourceUnr].Supply = 0;
                      }
                      if (num2 > 0)
                      {
                        int num11 = (int) Math.Round((double) (this.game.Data.UnitObj[this.sourceUnr].Fuel * num8) / (double) num2);
                        UnitClass[] unitObj3 = this.game.Data.UnitObj;
                        UnitClass[] unitClassArray3 = unitObj3;
                        int index19 = unr;
                        int index20 = index19;
                        unitClassArray3[index20].Fuel = unitObj3[index19].Fuel + num11;
                        UnitClass[] unitObj4 = this.game.Data.UnitObj;
                        UnitClass[] unitClassArray4 = unitObj4;
                        int sourceUnr = this.sourceUnr;
                        int index21 = sourceUnr;
                        unitClassArray4[index21].Fuel = unitObj4[sourceUnr].Fuel - num11;
                        if (this.game.Data.UnitObj[this.sourceUnr].Fuel < 0)
                          this.game.Data.UnitObj[this.sourceUnr].Fuel = 0;
                      }
                    }
                    if (this.game.Data.UnitObj[this.sourceUnr].SFCount == -1 & !this.game.Data.UnitObj[this.sourceUnr].IsHQ)
                    {
                      this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].RemoveUnitFromList(this.sourceUnr);
                      if (this.game.EditObj.UnitSelected == this.sourceUnr)
                        this.game.EditObj.UnitSelected = -1;
                      if (this.game.EditObj.OrderUnit == this.sourceUnr)
                        this.game.EditObj.OrderUnit = -1;
                      this.game.EditObj.UnitSelected = -1;
                      this.game.EditObj.OrderUnit = -1;
                      data: DataClass = this.game.Data;
                      int sourceUnr = this.sourceUnr;
                      let mut gameClass: GameClass = (GameClass) null;
                      ref let mut local: GameClass = ref gameClass;
                      data.RemoveUnit(sourceUnr, ref local);
                      this.game.EditObj.OldUnit = -1;
                      this.sourceUnr = -1;
                      this.targetUnr = -1;
                      unr = -1;
                    }
                  }
                  if (this.sourceUnr > -1 && !Information.IsNothing((object) this.game.Data.UnitObj[this.sourceUnr].tempSFTypeBitmap))
                  {
                    this.game.Data.UnitObj[this.sourceUnr].tempSFTypeBitmap.Dispose();
                    this.game.Data.UnitObj[this.sourceUnr].tempSFTypeBitmap = (Bitmap) null;
                  }
                  if (this.targetUnr > -1 && !Information.IsNothing((object) this.game.Data.UnitObj[this.targetUnr].tempSFTypeBitmap))
                  {
                    this.game.Data.UnitObj[this.targetUnr].tempSFTypeBitmap.Dispose();
                    this.game.Data.UnitObj[this.targetUnr].tempSFTypeBitmap = (Bitmap) null;
                  }
                  this.SetUnits();
                  if (this.targetUnr != -3)
                    this.targetUnr = unr;
                  this.TL = SimpleList::new();
                  this.FlagAll();
                  windowReturnClass.SetFlag(true);
                  this.View();
                  return windowReturnClass;
                }
                goto label_125;
              }
            }
            int num = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1], b);
            int nr = this.TL.FindNr(this.SlidersSfnr[index2]);
            int tweight = (int) Math.Round((double) num / (double) this.game.Data.SFTypeObj[this.game.Data.SFObj[this.SlidersSfnr[index2]].Type].Ratio);
            if (nr > -1)
              this.TL.RemoveNr(nr);
            this.TL.Add(this.SlidersSfnr[index2], tweight);
            this.SubPartFlag[index1] = true;
            this.FlagAll();
            windowReturnClass.SetFlag(true);
            this.SubPartList[index1].Scroller = true;
            this.View();
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
