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
  pub class ResourceWindowClass : WindowClass
  {
     int AllId;
     int info2id;
     int b2id;
     string ShowString;
     DateTime ShowTime;
     int w;
     int h;

    pub ResourceWindowClass( GameClass tGame, int morewidth)
      : base( tGame, tGame.ScreenWidth - 220 + morewidth, 35, 8)
    {
      this.w = tGame.ScreenWidth - 220 + morewidth;
      this.h = 35;
      this.dostuff();
    }

    pub void DoRefresh() => this.dostuff();

    pub void PopUpRefresh() => this.dostuff();

    pub string WindowDescription(int x, int y)
    {
      if (this.game.SelectX < 0 || this.game.Data.Turn == -1)
        return "";
      let mut mouseCounter: i32 = this.MouseCounter;
      for (let mut index: i32 = 0; index <= mouseCounter; index += 1)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
          return this.MouseText[index];
      }
      return "";
    }

    pub void dostuff()
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
      let mut num1: i32 = 0;
      if (this.game.Data.Turn > -1)
      {
        let mut index: i32 = 0;
        do
        {
          if (this.game.Data.RegimeObj[this.game.Data.Turn].LastTempRegimeSlotPredict[index] != this.game.Data.RegimeObj[this.game.Data.Turn].TempRegimeSlotPredict[index])
            num1 += 1;
          index += 1;
        }
        while (index <= 499);
      }
      if (num1 > 0)
        this.game.ProcessingObj.LocationProductionPrognosis();
      let mut num2: i32 = 0;
      SizeF sizeF1 = SizeF::new();
      int[] numArray1 = new int[500];
      let mut num3: i32 = -1;
      DrawMod.DrawBlock( Expression, 0, 0, this.w, this.h,  this.game.VicColor4.R,  this.game.VicColor4.G,  this.game.VicColor4.B,  this.game.VicColor4.A);
      this.ClearMouse();
      SizeF sizeF2;
      int num4;
      if (this.game.Data.Round > 0)
      {
        name: String = this.game.Data.RegimeObj[this.game.Data.Turn].Name;
        sizeF2 = Expression.MeasureString(name, this.game.VicFont2);
        let mut num5: i32 =  Math.Round((double) sizeF2.Width);
        sizeF2 = Expression.MeasureString("CURRENT REGIME", this.game.VicFont5);
        if ((double) sizeF2.Width + 20.0 > (double) num5)
          num5 =  Math.Round((double) (sizeF2.Width + 20f));
        int num6;
        let mut num7: i32 = num6 + num5 + 20;
        text1: String = Strings.Left(this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.Turn].People].Name, 3);
        sizeF2 = Expression.MeasureString(text1, this.game.VicFont2);
        let mut num8: i32 =  Math.Round((double) sizeF2.Width);
        sizeF2 = Expression.MeasureString("PPL", this.game.VicFont5);
        if ((double) sizeF2.Width + 20.0 > (double) num8)
          num8 =  Math.Round((double) (sizeF2.Width + 20f));
        let mut num9: i32 = num7 + num8 + 20;
        text2: String = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts));
        sizeF2 = Expression.MeasureString(text2, this.game.VicFont2);
        let mut num10: i32 =  Math.Round((double) sizeF2.Width);
        sizeF2 = Expression.MeasureString("PP", this.game.VicFont5);
        if ((double) sizeF2.Width + 20.0 > (double) num10)
          num10 =  Math.Round((double) (sizeF2.Width + 20f));
        let mut tempPpIncrease: i32 = this.game.Data.RegimeObj[this.game.Data.Turn].TempPPIncrease;
        text3: String = tempPpIncrease <= 0 ? "0" : "+" + Strings.Trim(Conversion.Str((object) tempPpIncrease));
        sizeF2 = Expression.MeasureString(text3, this.game.VicFont2);
        let mut num11: i32 =  Math.Round((double) ((float) num9 + (0.0f + sizeF2.Width))) + num10 + 20 + 40;
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
          DateTime dateTime1 = DateTime::new().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1));
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
        let mut num12: i32 =  Math.Round((double) sizeF2.Width);
        sizeF2 = Expression.MeasureString(text5, this.game.VicFont5);
        if ((double) sizeF2.Width > (double) num12)
          num12 =  Math.Round((double) sizeF2.Width);
        num4 = num11 + num12 + 20;
      }
      let mut num13: i32 = num2 + num4;
      let mut index1: i32 = 0;
      do
      {
        if (this.game.Data.RegimeSlotShow[index1])
        {
          let mut num14: i32 = num13;
          if (this.game.Data.RegimeSlotNato[index1] > 0)
          {
            int[] numArray2 = numArray1;
            int[] numArray3 = numArray2;
            let mut index2: i32 = index1;
            let mut index3: i32 = index2;
            let mut num15: i32 = numArray2[index2] + 40;
            numArray3[index3] = num15;
          }
          text6: String = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index1]));
          sizeF2 = Expression.MeasureString(text6, this.game.VicFont2);
          int[] numArray4 = numArray1;
          int[] numArray5 = numArray4;
          let mut index4: i32 = index1;
          let mut index5: i32 = index4;
          let mut num16: i32 =  Math.Round((double) ((float) numArray4[index4] + sizeF2.Width));
          numArray5[index5] = num16;
          let mut Number1: i32 = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index1] - this.game.Data.RegimeObj[this.game.Data.Turn].TempRegimeSlotPredict[index1];
          str: String = "";
          if (Number1 > 0)
            str += "-";
          text7: String = str + Strings.Trim(Conversion.Str((object) Number1));
          if (Number1 <= this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index1])
            ;
          sizeF2 = Expression.MeasureString(text7, this.game.VicFont2);
          int[] numArray6 = numArray1;
          int[] numArray7 = numArray6;
          let mut index6: i32 = index1;
          let mut index7: i32 = index6;
          let mut num17: i32 =  Math.Round((double) ((float) numArray6[index6] + sizeF2.Width));
          numArray7[index7] = num17;
          let mut Number2: i32 = this.game.Data.RegimeObj[this.game.Data.Turn].TempRegimeSlotIncrease[index1];
          if (Number2 > 0)
          {
            text8: String = "+" + Strings.Trim(Conversion.Str((object) Number2));
            sizeF2 = Expression.MeasureString(text8, this.game.VicFont2);
            int[] numArray8 = numArray1;
            int[] numArray9 = numArray8;
            let mut index8: i32 = index1;
            let mut index9: i32 = index8;
            let mut num18: i32 =  Math.Round((double) ((float) numArray8[index8] + sizeF2.Width));
            numArray9[index9] = num18;
          }
          if (this.game.Data.RegimeSlotNato[index1] < 1)
          {
            text9: String = Strings.UCase(this.game.Data.RegimeSlotName[index1] + ":");
            sizeF2 = Expression.MeasureString(text9, this.game.VicFont5);
            if ((double) sizeF2.Width + 20.0 > (double) numArray1[index1])
              numArray1[index1] =  Math.Round((double) (sizeF2.Width + 20f));
          }
          let mut num19: i32 = num13 + numArray1[index1];
          if (num19 > this.w & num3 == -1)
          {
            num3 = index1;
            num13 = num14 + 20 + 60 + 20;
            break;
          }
          num13 = num19 + 20;
        }
        index1 += 1;
      }
      while (index1 <= 499);
      let mut num20: i32 = num13 - 20;
      let mut num21: i32 =  Math.Round((double) this.game.ScreenWidth / 2.0 - (double) num20 / 2.0);
      if (num21 + num20 > this.w - 2)
        num21 = this.w - 2 - num20;
      let mut x1: i32 = num21;
      if (0 > x1)
        x1 = 0;
      let mut num22: i32 = x1;
      Rectangle rectangle1;
      Rectangle trect;
      string str1;
      if (this.game.Data.Round > 0)
      {
        name: String = this.game.Data.RegimeObj[this.game.Data.Turn].Name;
        sizeF2 = Expression.MeasureString(name, this.game.VicFont2);
        let mut width1: i32 =  Math.Round((double) sizeF2.Width);
        text10: String = "CURRENT REGIME";
        sizeF2 = Expression.MeasureString(text10, this.game.VicFont5);
        if ((double) sizeF2.Width + 20.0 > (double) width1)
          width1 =  Math.Round((double) (sizeF2.Width + 20f));
         let mut local1: &Graphics = &Expression;
        Rectangle rect1_1 = Rectangle::new(x1, 0, width1, 10);
        txt1_1: String = text10;
        rectangle1 = Rectangle::new(x1, 10, width1, 17);
        let mut rect2_1: &Rectangle = &rectangle1
        txt2_1: String = name;
        DrawMod.MakeFullBoxVic2( local1, rect1_1, txt1_1, rect2_1, txt2_1);
        rectangle1 = Rectangle::new(x1, 0, width1, 25);
        trect = rectangle1;
        this.AddMouse( trect, "", "Current regime you are giving orders too");
        let mut x2: i32 = x1 + width1 + 20;
        text11: String = Strings.UCase(Strings.Left(this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.Turn].People].Name, 3));
        sizeF2 = Expression.MeasureString(text11, this.game.VicFont2);
        let mut width2: i32 =  Math.Round((double) sizeF2.Width);
        text12: String = "PPL";
        sizeF2 = Expression.MeasureString(text12, this.game.VicFont5);
        if ((double) sizeF2.Width + 20.0 > (double) width2)
          width2 =  Math.Round((double) (sizeF2.Width + 20f));
         let mut local2: &Graphics = &Expression;
        rectangle1 = Rectangle::new(x2, 0, width2, 10);
        let mut rect1_2: &Rectangle = &rectangle1
        txt1_2: String = text12;
        trect = Rectangle::new(x2, 10, width2, 17);
        let mut rect2_2: &Rectangle = &trect
        txt2_2: String = text11;
        DrawMod.MakeFullBoxVic2( local2, rect1_2, txt1_2, rect2_2, txt2_2);
        rectangle1 = Rectangle::new(x2, 0, width2, 25);
        trect = rectangle1;
        this.AddMouse( trect, "", "The people that are in charge of the regime you are playing");
        let mut num23: i32 = x2 + width2 + 5;
        if (this.game.EditObj.OrderType != 26)
        {
          let mut tsubpart: SubPartClass =  new TextButtonPartClass("?", 30, "Get more information on this people",  this.OwnBitmap, num23, 3, theight: 25);
          this.b2id = this.AddSubPart( tsubpart, num23, 3, 30, 25, 1);
        }
        let mut x3: i32 = num23 + 45;
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
          DateTime dateTime3 = DateTime::new().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1));
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
        let mut width3: i32 =  Math.Round((double) sizeF2.Width);
        sizeF2 = Expression.MeasureString(text14, this.game.VicFont5);
        if ((double) sizeF2.Width > (double) width3)
          width3 =  Math.Round((double) sizeF2.Width);
         let mut local3: &Graphics = &Expression;
        rectangle1 = Rectangle::new(x3, 0, width3, 10);
        let mut rect1_3: &Rectangle = &rectangle1
        txt1_3: String = text14;
        trect = Rectangle::new(x3, 10, width3, 17);
        let mut rect2_3: &Rectangle = &trect
        txt2_3: String = text13;
        DrawMod.MakeFullBoxVic2( local3, rect1_3, txt1_3, rect2_3, txt2_3);
        ttext: String = "The date or the round number. Round number is " + Strings.Trim(Conversion.Str((object) this.game.Data.Round)) + ". ";
        if (this.game.Data.AlternateRound > -1)
        {
          str2: String = ttext + "The date of the next round will be: ";
          DateTime dateTime = DateTime::new().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1));
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
        rectangle1 = Rectangle::new(x3, 0, width3, 25);
        trect = rectangle1;
        this.AddMouse( trect, "", ttext);
        let mut x4: i32 = x3 + width3 + 20;
        text15: String = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts));
        sizeF2 = Expression.MeasureString(text15, this.game.VicFont2);
        let mut num24: i32 =  Math.Round((double) sizeF2.Width);
        text16: String = "PP";
        sizeF2 = Expression.MeasureString(text16, this.game.VicFont5);
        if ((double) sizeF2.Width + 20.0 > (double) num24)
          num24 =  Math.Round((double) (sizeF2.Width + 20f));
        let mut tempPpIncrease: i32 = this.game.Data.RegimeObj[this.game.Data.Turn].TempPPIncrease;
        str1 = tempPpIncrease <= 0 ? "0" : "+" + Strings.Trim(Conversion.Str((object) tempPpIncrease));
        let mut num25: i32 =  Math.Round((double) Expression.MeasureString(str1, this.game.VicFont2).Width);
        let mut num26: i32 = num24 - 5;
        let mut width4: i32 = num24 + num25;
         let mut local4: &Graphics = &Expression;
        rectangle1 = Rectangle::new(x4, 0, width4, 10);
        let mut rect1_4: &Rectangle = &rectangle1
        txt1_4: String = text16;
        trect = Rectangle::new(x4, 10, width4, 17);
        let mut rect2_4: &Rectangle = &trect
        txt2_4: String = text15;
        DrawMod.MakeFullBoxVic2( local4, rect1_4, txt1_4, rect2_4, txt2_4);
        DrawMod.DrawTextVic2( Expression, str1, this.game.VicFont2, x4 + num26 + 4, 11, Color.YellowGreen, Color.Black);
        rectangle1 = Rectangle::new(x4, 0, width4, 25);
        trect = rectangle1;
        this.AddMouse( trect, "", "Political points. In white the current amount. In green the projected production next round");
        x1 = x4 + width4 + 20;
      }
      let mut index10: i32 = 0;
      do
      {
        if (this.game.Data.RegimeSlotShow[index10])
        {
          let mut num27: i32 = x1;
          if (num3 == index10)
          {
            if (this.game.EditObj.OrderType != 24)
            {
              let mut tsubpart: SubPartClass =  new TextButtonPartClass("MORE", 60, "There are more resources in play. Click to get information on all resources.",  this.OwnBitmap, x1 - 13, 2, theight: 26);
              this.AllId = this.AddSubPart( tsubpart, x1 - 13, 3, 60, 26, 1);
              break;
            }
            break;
          }
          if (this.game.Data.RegimeSlotNato[index10] > 0)
          {
             let mut local5: &Graphics = &Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.RegimeSlotNato[index10]]);
             let mut local6: &Bitmap = &bitmap;
            let mut x5: i32 = x1;
            DrawMod.DrawSimple( local5,  local6, x5, 0);
            x1 += 40;
          }
          else
            str1 = Strings.UCase(this.game.Data.RegimeSlotName[index10]);
          if (this.game.Data.RegimeSlotNato[index10] < 1)
          {
             let mut local: &Graphics = &Expression;
            rectangle1 = Rectangle::new(x1, 0, numArray1[index10], 10);
            let mut rect1: &Rectangle = &rectangle1
            txt1: String = str1;
            trect = Rectangle::new(x1, 10, numArray1[index10], 17);
            let mut rect2: &Rectangle = &trect
            DrawMod.MakeFullBoxVic2( local, rect1, txt1, rect2, "");
            rectangle1 = Rectangle::new(x1, 0, numArray1[index10], 25);
            trect = rectangle1;
            this.AddMouse( trect, "", this.game.Data.RegimeSlotName[index10] + ": White = current amount, Yellow/Red = projected usage in production, Green =projected new production");
          }
          else
          {
             let mut local: &Graphics = &Expression;
            Rectangle rectangle2;
            let mut rect1: &Rectangle = &rectangle2
            rectangle1 = Rectangle::new(x1, 10, numArray1[index10] - 40, 17);
            let mut rect2: &Rectangle = &rectangle1
            DrawMod.MakeFullBoxVic2( local, rect1, "", rect2, "");
            rectangle1 = Rectangle::new(x1, 0, numArray1[index10] - 40, 25);
            trect = rectangle1;
            this.AddMouse( trect, "", this.game.Data.RegimeSlotName[index10] + ": White = current amount, Yellow/Red = projected usage in production, Green =projected new production");
          }
          str3: String = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index10]));
          DrawMod.DrawTextVic2( Expression, str3, this.game.VicFont2, x1, 11, Color.White, Color.Black);
          sizeF2 = Expression.MeasureString(str3, this.game.VicFont2);
          let mut x6: i32 =  Math.Round((double) ((float) x1 + sizeF2.Width));
          let mut Number3: i32 = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index10] - this.game.Data.RegimeObj[this.game.Data.Turn].TempRegimeSlotPredict[index10];
          str4: String = "";
          if (Number3 > 0)
            str4 += "-";
          str5: String = str4 + Strings.Trim(Conversion.Str((object) Number3));
          if (Number3 <= this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[index10])
            DrawMod.DrawTextVic2( Expression, str5, this.game.VicFont2, x6, 11, Color.Yellow, Color.Black);
          else
            DrawMod.DrawTextVic2( Expression, str5, this.game.VicFont2, x6, 11, Color.Red, Color.Black);
          sizeF2 = Expression.MeasureString(str5, this.game.VicFont2);
          let mut x7: i32 =  Math.Round((double) ((float) x6 + sizeF2.Width));
          let mut Number4: i32 = this.game.Data.RegimeObj[this.game.Data.Turn].TempRegimeSlotIncrease[index10];
          if (Number4 > 0)
          {
            str6: String = "+" + Strings.Trim(Conversion.Str((object) Number4));
            DrawMod.DrawTextVic2( Expression, str6, this.game.VicFont2, x7, 11, Color.YellowGreen, Color.Black);
            sizeF2 = Expression.MeasureString(str6, this.game.VicFont2);
            let mut num28: i32 =  Math.Round((double) ((float) x7 + sizeF2.Width));
          }
          x1 = num27 + numArray1[index10] + 20;
        }
        index10 += 1;
      }
      while (index10 <= 499);
      let mut num29: i32 = x1 - 15 + 20;
      let mut num30: i32 = num22 - 8 - 20;
      if (!this.game.EditObj.ProdFlap)
      {
        if (this.game.EditObj.Layout == 0 | this.game.EditObj.OrderType == 26 | this.game.EditObj.OrderType == 24)
          DrawMod.drawLine( Expression, 0, 34, this.w, 34,  this.game.VicColor6.R,  this.game.VicColor6.G,  this.game.VicColor6.B,  this.game.VicColor6.A);
        else
          DrawMod.drawLine( Expression, 219, 34, this.w, 34,  this.game.VicColor6.R,  this.game.VicColor6.G,  this.game.VicColor6.B,  this.game.VicColor6.A);
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
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
            let mut num: i32 = this.SubPartID[index];
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

    pub HandleMouseMove: WindowReturnClass(int x, int y)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      currentDescript: String = this.game.EditObj.CurrentDescript;
      return base.HandleMouseMove(x, y);
    }
  }
}
