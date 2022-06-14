// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.InfoWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class InfoWindowClass : WindowClass
  {
     int Info1Id;
     int info2id;
     string ShowString;
     DateTime ShowTime;
     int w;
     int h;

    pub InfoWindowClass( GameClass tGame)
      : base( tGame, tGame.ScreenWidth, 20, 8)
    {
      this.w = tGame.ScreenWidth;
      this.h = 20;
      this.dostuff();
    }

    pub void DoRefresh() => this.dostuff();

    pub void dostuff()
    {
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (Strings.Len(this.game.EditObj.FeedBackString) > 0)
      {
        this.ShowString = this.game.EditObj.FeedBackString;
        this.game.EditObj.FeedBackString = "";
        this.ShowTime = DateAndTime.Now;
      }
      if (this.Info1Id > 0)
        this.RemoveSubPart(this.Info1Id);
      str1: String = this.game.EditObj.CurrentDescript;
      if (this.game.EditObj.OrderType == 1 & this.game.Data.Round > 0 && this.game.EditObj.MouseOverX > -1 & this.game.EditObj.MouseOverY > -1)
      {
        str1 = this.game.EditObj.TempValue[this.game.EditObj.MapSelected].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY] >= 9999 ? (this.game.EditObj.TempValue2[this.game.EditObj.MapSelected].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY] <= 0 ? "Impossible to move here" : "Impossible to move here. Move Cost = " + Conversion.Str((object) this.game.EditObj.TempValue2[this.game.EditObj.MapSelected].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY])) : "Move Cost = " + Conversion.Str((object) this.game.EditObj.TempValue[this.game.EditObj.MapSelected].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY]);
        if (Information.IsNothing((object) this.game.EditObj.TempValueSpecial))
          this.game.HandyFunctionsObj.RedimTempValueSpecial(0);
        if (this.game.EditObj.TempValueSpecial[this.game.EditObj.MapSelected].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY] == 1)
          str1 += ". OUT OF FUEL";
        if (Strings.Len(this.game.EditObj.TempString[this.game.EditObj.MapSelected].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY]) > 0)
          str1 = this.game.EditObj.TempString[this.game.EditObj.MapSelected].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY];
      }
      if (this.game.EditObj.OrderType == 9 & this.game.Data.Round > 0 && this.game.EditObj.MouseOverX > -1 & this.game.EditObj.MouseOverY > -1)
        str1 = this.game.EditObj.TempValue[this.game.EditObj.MapSelected].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY] >= 9999 ? "Impossible to transfer here too" : "Transfer Cost = " + Conversion.Str((object) this.game.EditObj.TempValue[this.game.EditObj.MapSelected].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY]);
      if (this.game.EditObj.OrderType == 18 & this.game.Data.Round > 0 && this.game.EditObj.OrderTarget > -1 & this.game.EditObj.OrderUnit > -1 & this.game.EditObj.TargetX > -1 && this.game.EditObj.MouseOverX > -1 & this.game.EditObj.MouseOverY > -1)
        str1 = this.game.EditObj.TempValue[this.game.EditObj.MapSelected].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY] >= 9999 ? "Impossible to strategic transfer here too" : "Strategic Transfer Cost = " + Conversion.Str((object) this.game.EditObj.TempValue[this.game.EditObj.MapSelected].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY]);
      if (this.game.Data.Round == 0 & this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1)
      {
        let mut unitCounter: i32 =  this.game.Data.UnitCounter;
        for (let mut index: i32 =  0; index <= unitCounter; index += 1)
        {
          if (this.game.Data.UnitObj[index].Historical == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical)
          {
            int num;
            num += 1;
          }
        }
      }
      if (this.game.EditObj.UnitSelected > -1)
      {
        let mut num1: i32 =  this.game.Data.RegimeObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime].AI ? 1 : 0;
      }
      if (Strings.Len(this.ShowString) > 0)
        str1 = Strings.UCase(this.ShowString);
      SizeF sizeF1 = SizeF::new();
      str2: String = Strings.UCase(str1);
      SizeF sizeF2 = Expression.MeasureString(str2, DrawMod.TGame.VicFont5);
      DrawMod.DrawBlock( Expression, 0, 0, this.w, this.h,  this.game.VicColor4.R,  this.game.VicColor4.G,  this.game.VicColor4.B,  this.game.VicColor4.A);
      Rectangle rect2;
      DrawMod.MakeFullBoxVic2( Expression, Rectangle::new( Math.Round(Conversion.Int((double) this.w / 2.0 - (double) sizeF2.Width / 2.0)), 4,  Math.Round((double) sizeF2.Width), 14), str2, rect2, "");
      if (!this.game.EditObj.ProdFlap & this.game.EditObj.OrderType != 24)
      {
        if (this.game.EditObj.Layout == 0)
          DrawMod.drawLine( Expression, 0, 0, this.w - 220, 0,  this.game.VicColor6.R,  this.game.VicColor6.G,  this.game.VicColor6.B,  this.game.VicColor6.A);
        else
          DrawMod.drawLine( Expression, 219, 0, this.w - 220, 0,  this.game.VicColor6.R,  this.game.VicColor6.G,  this.game.VicColor6.B,  this.game.VicColor6.A);
      }
      if (this.game.EditObj.OrderType == 26 | this.game.EditObj.OrderType == 24)
        DrawMod.drawLine( Expression, 0, 0, this.w, 0,  this.game.VicColor6.R,  this.game.VicColor6.G,  this.game.VicColor6.B,  this.game.VicColor6.A);
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    pub handleTimer: WindowReturnClass()
    {
      DateTime now = DateAndTime.Now;
      if (Strings.Len(this.ShowString) > 0 && now.Subtract(this.ShowTime).Seconds > 1)
      {
        this.ShowString = "";
        windowReturnClass: WindowReturnClass = WindowReturnClass::new();
        this.dostuff();
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      windowReturnClass1: WindowReturnClass = WindowReturnClass::new();
      windowReturnClass1.SetFlag(false);
      return windowReturnClass1;
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 =  this.SubPartCounter;
        for (let mut index: i32 =  0; index <= subPartCounter; index += 1)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            let mut num: i32 =  this.SubPartID[index];
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
