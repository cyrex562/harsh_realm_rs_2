// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.AirSelectWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class AirSelectWindowClass : WindowClass
  {
     int okid;
     int cancelid;
     int oktextid;
     int Pic1Id;
     int TAid;
     int His;
     int Card;
     int Unr;
     UnitList UL;
     int[] Air;

    pub AirSelectWindowClass(ref GameClass tGame)
      : base(ref tGame, 880, 580, 8)
    {
      this.Air = new int[100];
      this.SetUnits();
      this.View();
    }

    pub void SetUnits()
    {
      this.UL = UnitList::new();
      let mut unitCounter: i32 =  this.game.Data.UnitCounter;
      for (let mut index: i32 =  0; index <= unitCounter; index += 1)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn && this.game.HandyFunctionsObj.HasUnitAirSF(index))
        {
          Coordinate target = Coordinate::new();
          target.x = this.game.EditObj.TargetX;
          target.y = this.game.EditObj.TargetY;
          if (this.game.HandyFunctionsObj.CanDoAirStrike(index, target))
            this.UL.add(index, this.game.HandyFunctionsObj.Distance(target.x, target.y, 0, this.game.Data.UnitObj[index].X, this.game.Data.UnitObj[index].Y, 0, 999));
        }
      }
      this.UL.SortOnData();
    }

    pub void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 =  this.SubPartCounter;
        for (let mut index: i32 =  0; index <= subPartCounter; index += 1)
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
      let mut mouseCounter: i32 =  this.MouseCounter;
      for (let mut index: i32 =  0; index <= mouseCounter; index += 1)
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
      if (this.cancelid > 0)
      {
        this.RemoveSubPart(this.cancelid);
        this.cancelid = 0;
      }
      if (this.TAid > 0)
        this.RemoveSubPart(this.TAid);
      let mut index1: i32 =  0;
      do
      {
        if (this.Air[index1] > 0)
        {
          this.RemoveSubPart(this.Air[index1]);
          this.Air[index1] = 0;
        }
        index1 += 1;
      }
      while (index1 <= 99);
      this.ClearMouse();
      this.NewBackGroundAndClearAll(880, 580, -1);
      Graphics toG = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref toG, 0, 0, 880, 580);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      DrawMod.DrawBlockGradient2(ref toG, 80, 80, 719, 379, this.game.MarcCol1, this.game.MarcCol2);
      DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref toG, 80, 80, 720, 380, -1, -1);
      SizeF sizeF1 = SizeF::new();
      str1: String = "Select/deselect air units";
      SizeF sizeF2 = toG.MeasureString(str1, this.game.MarcFont4);
      DrawMod.DrawTextColouredMarc(ref toG, str1, this.game.MarcFont4, (int) Math.Round(435.0 - (double) sizeF2.Width / 2.0), 40, Color.White);
      str2: String = "";
      if ((double) this.game.Data.RuleVar[833] > 0.0)
        str2 = str2 + "Stack:" + Conversion.Str((object) (this.game.HandyFunctionsObj.CurrentAttackStackAir() + this.game.Data.MapObj[this.game.EditObj.TargetMap].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].get_BattleStackAir(this.game.Data.Turn))) + "/" + Conversion.Str((object) this.game.Data.RuleVar[833]);
      SizeF sizeF3 = toG.MeasureString(str2, this.game.MarcFont4);
      DrawMod.DrawTextColouredMarc(ref toG, str2, this.game.MarcFont4, (int) Math.Round(435.0 - (double) sizeF3.Width / 2.0), 478, Color.White);
      let mut num1: i32 =  45;
      let mut num2: i32 =  100;
      let mut counter: i32 =  this.UL.counter;
      for (let mut index2: i32 =  0; index2 <= counter; index2 += 1)
      {
        num1 += 75;
        if (num1 > 780)
        {
          num1 = 120;
          num2 += 60;
        }
        if (num2 < 450)
        {
          str3: String = "";
          let mut num3: i32 =  0;
          let mut sfCount: i32 =  this.game.Data.UnitObj[this.UL.unr[index2]].SFCount;
          for (let mut index3: i32 =  0; index3 <= sfCount; index3 += 1)
          {
            let mut sf: i32 =  DrawMod.TGame.Data.UnitObj[this.UL.unr[index2]].SFList[index3];
            let mut type: i32 =  DrawMod.TGame.Data.SFObj[sf].Type;
            if (DrawMod.TGame.Data.SFTypeObj[type].Theater == 2)
            {
              num3 += 1;
              if (num3 > 1)
                str3 += ", ";
              str3 = str3 + Strings.Trim(Conversion.Str((object) (DrawMod.TGame.Data.SFObj[sf].Qty * DrawMod.TGame.Data.SFTypeObj[type].Ratio))) + "x " + DrawMod.TGame.Data.SFTypeObj[type].Name;
            }
          }
          ttext: String = str3 + "\r\n" + "Average Readiness: " + Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetAverageRdn(this.UL.unr[index2])));
          this.game.CustomBitmapObj.DrawUnit(this.UL.unr[index2], toG: toG, tx: num1, ty: num2, ShowAttacker: true);
          Rectangle trect = Rectangle::new(num1, num2, 38, 38);
          this.AddMouse(ref trect, this.game.Data.UnitObj[this.UL.unr[index2]].Name, ttext, this.UL.unr[index2]);
          str4: String = this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[this.UL.unr[index2]].X, this.game.Data.UnitObj[this.UL.unr[index2]].Y].Location <= -1 ? this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[this.UL.unr[index2]].X, this.game.Data.UnitObj[this.UL.unr[index2]].Y].Name : this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[this.UL.unr[index2]].X, this.game.Data.UnitObj[this.UL.unr[index2]].Y].Location].Name;
          let mut num4: i32 =  -1;
          let mut num5: i32 =  0;
          SizeF sizeF4;
          while (num4 <= 0)
          {
            sizeF4 = toG.MeasureString(str4, this.game.MarcFont10);
            if ((double) sizeF4.Width > 70.0)
            {
              num5 = 1;
              str4 = Strings.Left(str4, str4.Length - 1);
            }
            else
              num4 = 1;
          }
          if (num5 == 1)
            str4 = Strings.Left(str4, str4.Length - 1) + "...";
          sizeF4 = toG.MeasureString(str4, this.game.MarcFont10);
          DrawMod.DrawTextColouredMarc(ref toG, str4, this.game.MarcFont10, (int) Math.Round((double) ((float) (num1 + 19) - sizeF4.Width / 2f)), num2 + 38, Color.White);
          str5: String = "(dist: " + this.UL.data[index2].ToString() + ")";
          sizeF4 = toG.MeasureString(str5, this.game.MarcFont10);
          DrawMod.DrawTextColouredMarc(ref toG, str5, this.game.MarcFont10, (int) Math.Round((double) ((float) (num1 + 19) - sizeF4.Width / 2f)), num2 + 38 + 9, Color.White);
        }
      }
      let mut tsubpart: SubPartClass =  new TextButtonPartClass("OK", 150, "Click to return to main screen.", ref this.OwnBitmap, 365, 515, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.cancelid = this.AddSubPart(ref tsubpart, 365, 515, 150, 40, 1);
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

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      let mut mouseCounter: i32 =  this.MouseCounter;
      for (let mut index: i32 =  0; index <= mouseCounter; index += 1)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height && this.MouseData[index] >= 0)
        {
          if (!this.game.EditObj.TempUnitList.CheckIfPresent(this.MouseData[index]))
            this.game.EditObj.TempUnitList.add(this.MouseData[index]);
          else
            this.game.EditObj.TempUnitList.remove(this.MouseData[index]);
          this.View();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 =  this.SubPartCounter;
        for (let mut index: i32 =  0; index <= subPartCounter; index += 1)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index] && this.SubPartID[index] == this.cancelid)
          {
            windowReturnClass.AddCommand(6, 0);
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
