// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ResourceWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class ResourceWindowClass : WindowClass
  {
    private int AllId;
    private int info2id;
    private int b2id;
    private string ShowString;
    private DateTime ShowTime;
    private int w;
    private int h;

    public ResourceWindowClass(ref GameClass tGame, int morewidth)
      : base(ref tGame, tGame.ScreenWidth - 220 + morewidth, 35, 8)
    {
      this.w = tGame.ScreenWidth - 220 + morewidth;
      this.h = 35;
      this.dostuff();
    }

    public override void DoRefresh() => this.dostuff();

    public void PopUpRefresh() => this.dostuff();

    public override string WindowDescription(int x, int y)
    {
      if (this.game.SelectX < 0 || this.game.Data.Turn == -1)
        return "";
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
          return this.MouseText[index];
      }
      return "";
    }

    public void dostuff()
    {
      if (this.AllId > 0)
      {
        this.RemoveSubPart(this.AllId);
        this.AllId = 0;
      }
      if (this.b2id > 0)
      {
        this.RemoveSubPart(this.b2id);
        this.b2id = 0;
      }
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.game.Data.Turn == -1)
        return;
      int num1 = 0;
      if (this.game.Data.Turn > -1)
      {
        int index = 0;
        do
        {
          if (this.game.Data.RegimeObj[this.game.Data.Turn].LastTempRegimeSlotPredict[index] != this.game.Data.RegimeObj[this.game.Data.Turn].TempRegimeSlotPredict[index])
            ++num1;
          ++index;
        }
        while (index <= 499);
      }
      if (num1 > 0)
        this.game.ProcessingObj.LocationProductionPrognosis();
      int num2 = 0;
      SizeF sizeF1 = new SizeF();
      int[] numArray1 = new int[500];
      int num3 = -1;
      DrawMod.DrawBlock(ref Expression, 0, 0, this.w, this.h, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
      this.ClearMouse();
      SizeF sizeF2;
      int num4;
      if (this.game.Data.Round > 0)
      {
        string name = this.game.Data.RegimeObj[this.game.Data.Turn].Name;
        sizeF2 = Expression.MeasureString(name, this.game.VicFont2);
        int num5 = (int) Math.Round((double) sizeF2.Width);
        sizeF2 = Expression.MeasureString("CURRENT REGIME", this.game.VicFont5);
        if ((double) sizeF2.Width + 20.0 > (double) num5)
          num5 = (int) Math.Round((double) (sizeF2.Width + 20f));
        int num6;
        int num7 = num6 + num5 + 20;
        string text1 = Strings.Left(this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.Turn].People].Name, 3);
        sizeF2 = Expression.MeasureString(text1, this.game.VicFont2);
        int num8 = (int) Math.Round((double) sizeF2.Width);
        sizeF2 = Expression.MeasureString("PPL", this.game.VicFont5);
        if ((double) sizeF2.Width + 20.0 > (double) num8)
          num8 = (int) Math.Round((double) (sizeF2.Width + 20f));
        int num9 = num7 + num8 + 20;
        string text2 = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts));
        sizeF2 = Expression.MeasureString(text2, this.game.VicFont2);
        int num10 = (int) Math.Round((double) sizeF2.Width);
        sizeF2 = Expression.MeasureString("PP", this.game.VicFont5);
        if ((double) sizeF2.Width + 20.0 > (double) num10)
          num10 = (int) Math.Round((double) (sizeF2.Width + 20f));
        int tempPpIncrease = this.game.Data.RegimeObj[this.game.Data.Turn].TempPPIncrease;
        string text3 = tempPpIncrease <= 0 ? "0" : "+" + Strings.Trim(Conversion.Str((object) tempPpIncrease));
        sizeF2 = Expression.MeasureString(text3, this.game.VicFont2);
        int num11 = (int) Math.Round((double) ((float) num9 + (0.0f + sizeF2.Width))) + num10 + 20 + 40;
        if (Information.IsNothing((object) this.game.Data.TurnString))
          this.game.Data.TurnString = "";
        string text4;
        string text5;
        if (this.game.Data.TurnString.Length > 0)
        {
          text4 = this.game.Data.TurnString;
          text5 = "ROUND";
        }
        else if (this.game.Data.AlternateRound == -1)
        {
          text4 = Strings.Trim(Conversion.Str((object) this.game.Data.Round));
          text5 = "ROUND";
        }
        else
        {
          DateTime dateTime1 = new DateTime().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1));
          DateTime dateTime2;
          if (this.game.Data.AlternateRound == 31)
          {
            dateTime2 = dateTime1.AddMonths((this.game.Data.Round - 1) * 1);
          }
          else
          {
            TimeSpan timeSpan = new TimeSpan((this.game.Data.Round - 1) * this.game.Data.AlternateRound, 0, 0, 0);
            dateTime2 = dateTime1.Add(timeSpan);
          }
          text4 = Strings.Left(this.game.HandyFunctionsObj.GetMonth(dateTime2.Month), 3) + " " + Strings.Trim(Conversion.Str((object) dateTime2.Day)) + ", " + Strings.Trim(Conversion.Str((object) dateTime2.Year));
          text5 = "ROUND";
        }
        sizeF2 = Expression.MeasureString(text4, this.game.VicFont2);
        int num12 = (int) Math.Round((double) sizeF2.Width);
        sizeF2 = Expression.MeasureString(text5, this.game.VicFont5);
        if ((double) sizeF2.Width > (double) num12)
          num12 = (int) Math.Round((double) sizeF2.Width);
        num4 = num11 + num12 + 20;
      }
      int num13 = num2 + num4;
      int index1 = 0;
      do
      {
        if (this.game.Data.RegimeSlotShow[index1])
        {
          int num14 = num13;
          if (this.game.Data.RegimeSlotNato[index1] > 0)
          {
            int[] numArray2 = numArray1;
            int[] numArray3 = numArray2;
            int index2 = index1;
            int index3 = index2;
            int num15 = numArray2[index2] + 40;
            numArray3[index3] = num15;
          }
          string text6 = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index1]));
          sizeF2 = Expression.MeasureString(text6, this.game.VicFont2);
          int[] numArray4 = numArray1;
          int[] numArray5 = numArray4;
          int index4 = index1;
          int index5 = index4;
          int num16 = (int) Math.Round((double) ((float) numArray4[index4] + sizeF2.Width));
          numArray5[index5] = num16;
          int Number1 = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index1] - this.game.Data.RegimeObj[this.game.Data.Turn].TempRegimeSlotPredict[index1];
          string str = "";
          if (Number1 > 0)
            str += "-";
          string text7 = str + Strings.Trim(Conversion.Str((object) Number1));
          if (Number1 <= this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index1])
            ;
          sizeF2 = Expression.MeasureString(text7, this.game.VicFont2);
          int[] numArray6 = numArray1;
          int[] numArray7 = numArray6;
          int index6 = index1;
          int index7 = index6;
          int num17 = (int) Math.Round((double) ((float) numArray6[index6] + sizeF2.Width));
          numArray7[index7] = num17;
          int Number2 = this.game.Data.RegimeObj[this.game.Data.Turn].TempRegimeSlotIncrease[index1];
          if (Number2 > 0)
          {
            string text8 = "+" + Strings.Trim(Conversion.Str((object) Number2));
            sizeF2 = Expression.MeasureString(text8, this.game.VicFont2);
            int[] numArray8 = numArray1;
            int[] numArray9 = numArray8;
            int index8 = index1;
            int index9 = index8;
            int num18 = (int) Math.Round((double) ((float) numArray8[index8] + sizeF2.Width));
            numArray9[index9] = num18;
          }
          if (this.game.Data.RegimeSlotNato[index1] < 1)
          {
            string text9 = Strings.UCase(this.game.Data.RegimeSlotName[index1] + ":");
            sizeF2 = Expression.MeasureString(text9, this.game.VicFont5);
            if ((double) sizeF2.Width + 20.0 > (double) numArray1[index1])
              numArray1[index1] = (int) Math.Round((double) (sizeF2.Width + 20f));
          }
          int num19 = num13 + numArray1[index1];
          if (num19 > this.w & num3 == -1)
          {
            num3 = index1;
            num13 = num14 + 20 + 60 + 20;
            break;
          }
          num13 = num19 + 20;
        }
        ++index1;
      }
      while (index1 <= 499);
      int num20 = num13 - 20;
      int num21 = (int) Math.Round((double) this.game.ScreenWidth / 2.0 - (double) num20 / 2.0);
      if (num21 + num20 > this.w - 2)
        num21 = this.w - 2 - num20;
      int x1 = num21;
      if (0 > x1)
        x1 = 0;
      int num22 = x1;
      Rectangle rectangle1;
      Rectangle trect;
      string str1;
      if (this.game.Data.Round > 0)
      {
        string name = this.game.Data.RegimeObj[this.game.Data.Turn].Name;
        sizeF2 = Expression.MeasureString(name, this.game.VicFont2);
        int width1 = (int) Math.Round((double) sizeF2.Width);
        string text10 = "CURRENT REGIME";
        sizeF2 = Expression.MeasureString(text10, this.game.VicFont5);
        if ((double) sizeF2.Width + 20.0 > (double) width1)
          width1 = (int) Math.Round((double) (sizeF2.Width + 20f));
        ref Graphics local1 = ref Expression;
        Rectangle rect1_1 = new Rectangle(x1, 0, width1, 10);
        string txt1_1 = text10;
        rectangle1 = new Rectangle(x1, 10, width1, 17);
        Rectangle rect2_1 = rectangle1;
        string txt2_1 = name;
        DrawMod.MakeFullBoxVic2(ref local1, rect1_1, txt1_1, rect2_1, txt2_1);
        rectangle1 = new Rectangle(x1, 0, width1, 25);
        trect = rectangle1;
        this.AddMouse(ref trect, "", "Current regime you are giving orders too");
        int x2 = x1 + width1 + 20;
        string text11 = Strings.UCase(Strings.Left(this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.Turn].People].Name, 3));
        sizeF2 = Expression.MeasureString(text11, this.game.VicFont2);
        int width2 = (int) Math.Round((double) sizeF2.Width);
        string text12 = "PPL";
        sizeF2 = Expression.MeasureString(text12, this.game.VicFont5);
        if ((double) sizeF2.Width + 20.0 > (double) width2)
          width2 = (int) Math.Round((double) (sizeF2.Width + 20f));
        ref Graphics local2 = ref Expression;
        rectangle1 = new Rectangle(x2, 0, width2, 10);
        Rectangle rect1_2 = rectangle1;
        string txt1_2 = text12;
        trect = new Rectangle(x2, 10, width2, 17);
        Rectangle rect2_2 = trect;
        string txt2_2 = text11;
        DrawMod.MakeFullBoxVic2(ref local2, rect1_2, txt1_2, rect2_2, txt2_2);
        rectangle1 = new Rectangle(x2, 0, width2, 25);
        trect = rectangle1;
        this.AddMouse(ref trect, "", "The people that are in charge of the regime you are playing");
        int num23 = x2 + width2 + 5;
        if (this.game.EditObj.OrderType != 26)
        {
          SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("?", 30, "Get more information on this people", ref this.OwnBitmap, num23, 3, theight: 25);
          this.b2id = this.AddSubPart(ref tsubpart, num23, 3, 30, 25, 1);
        }
        int x3 = num23 + 45;
        if (Information.IsNothing((object) this.game.Data.TurnString))
          this.game.Data.TurnString = "";
        string text13;
        string text14;
        if (this.game.Data.TurnString.Length > 0)
        {
          text13 = this.game.Data.TurnString;
          text14 = "ROUND";
        }
        else if (this.game.Data.AlternateRound == -1)
        {
          text13 = Strings.Trim(Conversion.Str((object) this.game.Data.Round));
          text14 = "ROUND";
        }
        else
        {
          DateTime dateTime3 = new DateTime().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1));
          DateTime dateTime4;
          if (this.game.Data.AlternateRound == 31)
          {
            dateTime4 = dateTime3.AddMonths((this.game.Data.Round - 1) * 1);
          }
          else
          {
            TimeSpan timeSpan = new TimeSpan((this.game.Data.Round - 1) * this.game.Data.AlternateRound, 0, 0, 0);
            dateTime4 = dateTime3.Add(timeSpan);
          }
          text13 = Strings.Left(this.game.HandyFunctionsObj.GetMonth(dateTime4.Month), 3) + " " + Strings.Trim(Conversion.Str((object) dateTime4.Day)) + ", " + Strings.Trim(Conversion.Str((object) dateTime4.Year));
          text14 = "ROUND";
        }
        sizeF2 = Expression.MeasureString(text13, this.game.VicFont2);
        int width3 = (int) Math.Round((double) sizeF2.Width);
        sizeF2 = Expression.MeasureString(text14, this.game.VicFont5);
        if ((double) sizeF2.Width > (double) width3)
          width3 = (int) Math.Round((double) sizeF2.Width);
        ref Graphics local3 = ref Expression;
        rectangle1 = new Rectangle(x3, 0, width3, 10);
        Rectangle rect1_3 = rectangle1;
        string txt1_3 = text14;
        trect = new Rectangle(x3, 10, width3, 17);
        Rectangle rect2_3 = trect;
        string txt2_3 = text13;
        DrawMod.MakeFullBoxVic2(ref local3, rect1_3, txt1_3, rect2_3, txt2_3);
        string ttext = "The date or the round number. Round number is " + Strings.Trim(Conversion.Str((object) this.game.Data.Round)) + ". ";
        if (this.game.Data.AlternateRound > -1)
        {
          string str2 = ttext + "The date of the next round will be: ";
          DateTime dateTime = new DateTime().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1));
          if (this.game.Data.AlternateRound == 31)
          {
            dateTime = dateTime.AddMonths(this.game.Data.Round * 1);
          }
          else
          {
            TimeSpan timeSpan = new TimeSpan(this.game.Data.Round * this.game.Data.AlternateRound, 0, 0, 0);
            dateTime = dateTime.Add(timeSpan);
          }
          ttext = str2 + this.game.HandyFunctionsObj.GetMonth(dateTime.Month) + " " + Strings.Trim(Conversion.Str((object) dateTime.Day)) + " " + Strings.Trim(Conversion.Str((object) dateTime.Year));
        }
        rectangle1 = new Rectangle(x3, 0, width3, 25);
        trect = rectangle1;
        this.AddMouse(ref trect, "", ttext);
        int x4 = x3 + width3 + 20;
        string text15 = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts));
        sizeF2 = Expression.MeasureString(text15, this.game.VicFont2);
        int num24 = (int) Math.Round((double) sizeF2.Width);
        string text16 = "PP";
        sizeF2 = Expression.MeasureString(text16, this.game.VicFont5);
        if ((double) sizeF2.Width + 20.0 > (double) num24)
          num24 = (int) Math.Round((double) (sizeF2.Width + 20f));
        int tempPpIncrease = this.game.Data.RegimeObj[this.game.Data.Turn].TempPPIncrease;
        str1 = tempPpIncrease <= 0 ? "0" : "+" + Strings.Trim(Conversion.Str((object) tempPpIncrease));
        int num25 = (int) Math.Round((double) Expression.MeasureString(str1, this.game.VicFont2).Width);
        int num26 = num24 - 5;
        int width4 = num24 + num25;
        ref Graphics local4 = ref Expression;
        rectangle1 = new Rectangle(x4, 0, width4, 10);
        Rectangle rect1_4 = rectangle1;
        string txt1_4 = text16;
        trect = new Rectangle(x4, 10, width4, 17);
        Rectangle rect2_4 = trect;
        string txt2_4 = text15;
        DrawMod.MakeFullBoxVic2(ref local4, rect1_4, txt1_4, rect2_4, txt2_4);
        DrawMod.DrawTextVic2(ref Expression, str1, this.game.VicFont2, x4 + num26 + 4, 11, Color.YellowGreen, Color.Black);
        rectangle1 = new Rectangle(x4, 0, width4, 25);
        trect = rectangle1;
        this.AddMouse(ref trect, "", "Political points. In white the current amount. In green the projected production next round");
        x1 = x4 + width4 + 20;
      }
      int index10 = 0;
      do
      {
        if (this.game.Data.RegimeSlotShow[index10])
        {
          int num27 = x1;
          if (num3 == index10)
          {
            if (this.game.EditObj.OrderType != 24)
            {
              SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("MORE", 60, "There are more resources in play. Click to get information on all resources.", ref this.OwnBitmap, x1 - 13, 2, theight: 26);
              this.AllId = this.AddSubPart(ref tsubpart, x1 - 13, 3, 60, 26, 1);
              break;
            }
            break;
          }
          if (this.game.Data.RegimeSlotNato[index10] > 0)
          {
            ref Graphics local5 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.RegimeSlotNato[index10]]);
            ref Bitmap local6 = ref bitmap;
            int x5 = x1;
            DrawMod.DrawSimple(ref local5, ref local6, x5, 0);
            x1 += 40;
          }
          else
            str1 = Strings.UCase(this.game.Data.RegimeSlotName[index10]);
          if (this.game.Data.RegimeSlotNato[index10] < 1)
          {
            ref Graphics local = ref Expression;
            rectangle1 = new Rectangle(x1, 0, numArray1[index10], 10);
            Rectangle rect1 = rectangle1;
            string txt1 = str1;
            trect = new Rectangle(x1, 10, numArray1[index10], 17);
            Rectangle rect2 = trect;
            DrawMod.MakeFullBoxVic2(ref local, rect1, txt1, rect2, "");
            rectangle1 = new Rectangle(x1, 0, numArray1[index10], 25);
            trect = rectangle1;
            this.AddMouse(ref trect, "", this.game.Data.RegimeSlotName[index10] + ": White = current amount, Yellow/Red = projected usage in production, Green =projected new production");
          }
          else
          {
            ref Graphics local = ref Expression;
            Rectangle rectangle2;
            Rectangle rect1 = rectangle2;
            rectangle1 = new Rectangle(x1, 10, numArray1[index10] - 40, 17);
            Rectangle rect2 = rectangle1;
            DrawMod.MakeFullBoxVic2(ref local, rect1, "", rect2, "");
            rectangle1 = new Rectangle(x1, 0, numArray1[index10] - 40, 25);
            trect = rectangle1;
            this.AddMouse(ref trect, "", this.game.Data.RegimeSlotName[index10] + ": White = current amount, Yellow/Red = projected usage in production, Green =projected new production");
          }
          string str3 = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index10]));
          DrawMod.DrawTextVic2(ref Expression, str3, this.game.VicFont2, x1, 11, Color.White, Color.Black);
          sizeF2 = Expression.MeasureString(str3, this.game.VicFont2);
          int x6 = (int) Math.Round((double) ((float) x1 + sizeF2.Width));
          int Number3 = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index10] - this.game.Data.RegimeObj[this.game.Data.Turn].TempRegimeSlotPredict[index10];
          string str4 = "";
          if (Number3 > 0)
            str4 += "-";
          string str5 = str4 + Strings.Trim(Conversion.Str((object) Number3));
          if (Number3 <= this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index10])
            DrawMod.DrawTextVic2(ref Expression, str5, this.game.VicFont2, x6, 11, Color.Yellow, Color.Black);
          else
            DrawMod.DrawTextVic2(ref Expression, str5, this.game.VicFont2, x6, 11, Color.Red, Color.Black);
          sizeF2 = Expression.MeasureString(str5, this.game.VicFont2);
          int x7 = (int) Math.Round((double) ((float) x6 + sizeF2.Width));
          int Number4 = this.game.Data.RegimeObj[this.game.Data.Turn].TempRegimeSlotIncrease[index10];
          if (Number4 > 0)
          {
            string str6 = "+" + Strings.Trim(Conversion.Str((object) Number4));
            DrawMod.DrawTextVic2(ref Expression, str6, this.game.VicFont2, x7, 11, Color.YellowGreen, Color.Black);
            sizeF2 = Expression.MeasureString(str6, this.game.VicFont2);
            int num28 = (int) Math.Round((double) ((float) x7 + sizeF2.Width));
          }
          x1 = num27 + numArray1[index10] + 20;
        }
        ++index10;
      }
      while (index10 <= 499);
      int num29 = x1 - 15 + 20;
      int num30 = num22 - 8 - 20;
      if (!this.game.EditObj.ProdFlap)
      {
        if (this.game.EditObj.Layout == 0 | this.game.EditObj.OrderType == 26 | this.game.EditObj.OrderType == 24)
          DrawMod.drawLine(ref Expression, 0, 34, this.w, 34, (int) this.game.VicColor6.R, (int) this.game.VicColor6.G, (int) this.game.VicColor6.B, (int) this.game.VicColor6.A);
        else
          DrawMod.drawLine(ref Expression, 219, 34, this.w, 34, (int) this.game.VicColor6.R, (int) this.game.VicColor6.G, (int) this.game.VicColor6.B, (int) this.game.VicColor6.A);
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
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
            int num = this.SubPartID[index];
            if (num == this.b2id)
            {
              this.game.EditObj.PeopleSelected = this.game.Data.RegimeObj[this.game.Data.Turn].People;
              this.game.EditObj.PopupValue = 13;
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.AddCommand(5, 10);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num != this.AllId)
              return windowReturnClass;
            this.game.EditObj.OrderType = 24;
            this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
            windowReturnClass.AddCommand(1, 5);
            windowReturnClass.AddCommand(1, 3);
            windowReturnClass.AddCommand(1, 66);
            windowReturnClass.AddCommand(2, 39);
            windowReturnClass.AddCommand(2, 53);
            windowReturnClass.AddCommand(2, 66);
            windowReturnClass.AddCommand(1, 2);
            windowReturnClass.AddCommand(4, 44);
            this.dostuff();
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

    public override WindowReturnClass HandleMouseMove(int x, int y)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      string currentDescript = this.game.EditObj.CurrentDescript;
      return base.HandleMouseMove(x, y);
    }
  }
}
