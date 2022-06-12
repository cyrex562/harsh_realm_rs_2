﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.LandSelectWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class LandSelectWindowClass : WindowClass
  {
    private int okid;
    private int cancelid;
    private int oktextid;
    private int Pic1Id;
    private int TAid;
    private int His;
    private int Card;
    private int Unr;
    private UnitList UL;
    private int[] Air;

    public LandSelectWindowClass(ref GameClass tGame)
      : base(ref tGame, 680, 380, 8)
    {
      this.Air = new int[100];
      this.SetUnits();
      this.View();
    }

    public void SetUnits()
    {
      this.UL = new UnitList();
      int unitCounter = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter; ++index)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn)
        {
          if (this.game.HandyFunctionsObj.CanDoLandAttack(index, new Coordinate()
          {
            x = this.game.EditObj.TargetX,
            y = this.game.EditObj.TargetY
          }))
            this.UL.add(index);
        }
      }
    }

    public override void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
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
      for (int index = 0; index <= mouseCounter; ++index)
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

    public void View()
    {
      if (this.cancelid > 0)
      {
        this.RemoveSubPart(this.cancelid);
        this.cancelid = 0;
      }
      if (this.TAid > 0)
        this.RemoveSubPart(this.TAid);
      int index1 = 0;
      do
      {
        if (this.Air[index1] > 0)
        {
          this.RemoveSubPart(this.Air[index1]);
          this.Air[index1] = 0;
        }
        ++index1;
      }
      while (index1 <= 99);
      this.ClearMouse();
      this.NewBackGroundAndClearAll(680, 380, -1);
      Graphics toG = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref toG, 0, 0, 680, 380);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      DrawMod.DrawBlockGradient2(ref toG, 160, 80, 359, 179, this.game.MarcCol1, this.game.MarcCol2);
      DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref toG, 160, 80, 360, 180, -1, -1);
      SizeF sizeF1 = new SizeF();
      string str1 = "Select/deselect land attack units";
      SizeF sizeF2 = toG.MeasureString(str1, this.game.MarcFont4);
      DrawMod.DrawTextColouredMarc(ref toG, str1, this.game.MarcFont4, (int) Math.Round(335.0 - (double) sizeF2.Width / 2.0), 40, Color.White);
      string str2 = "Stack: " + Conversion.Str((object) (this.game.HandyFunctionsObj.CurrentAttackStack() + this.game.Data.MapObj[this.game.EditObj.TargetMap].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].get_BattleStack(this.game.Data.Turn))) + "/" + Conversion.Str((object) this.game.HandyFunctionsObj.maxAttackStack()) + ". Concentric: +" + Conversion.Str((object) Conversion.Int((float) (((double) this.game.HandyFunctionsObj.GetConcentricBonus2() - 1.0) * 100.0))) + "%";
      int divBonusForAttack = this.game.HandyFunctionsObj.GetDivBonusForAttack(this.game.EditObj.TargetX, this.game.EditObj.TargetY, this.game.EditObj.TargetMap);
      if (divBonusForAttack > 0)
        str2 = str2 + ". Divisional: +" + Conversion.Str((object) Conversion.Int(divBonusForAttack)) + "%";
      SizeF sizeF3 = toG.MeasureString(str2, this.game.MarcFont4);
      DrawMod.DrawTextColouredMarc(ref toG, str2, this.game.MarcFont4, (int) Math.Round(335.0 - (double) sizeF3.Width / 2.0), 278, Color.White);
      int counter = this.UL.counter;
      for (int index2 = 0; index2 <= counter; ++index2)
      {
        int num1 = 180 + index2 * 40;
        int num2 = 100;
        while (num1 > 480)
        {
          num1 -= 320;
          num2 += 40;
        }
        string str3 = "";
        int num3 = 0;
        int sfCount = this.game.Data.UnitObj[this.UL.unr[index2]].SFCount;
        for (int index3 = 0; index3 <= sfCount; ++index3)
        {
          int sf = DrawMod.TGame.Data.UnitObj[this.UL.unr[index2]].SFList[index3];
          int type = DrawMod.TGame.Data.SFObj[sf].Type;
          if (DrawMod.TGame.Data.SFTypeObj[type].Theater == 0)
          {
            ++num3;
            if (num3 > 1)
              str3 += ", ";
            str3 = str3 + Strings.Trim(Conversion.Str((object) (DrawMod.TGame.Data.SFObj[sf].Qty * DrawMod.TGame.Data.SFTypeObj[type].Ratio))) + "x " + DrawMod.TGame.Data.SFTypeObj[type].Name;
          }
        }
        string ttext = str3 + "\r\n" + "Average Readiness: " + Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetAverageRdn(this.UL.unr[index2]))) + "\r\n" + "Action Points: " + Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetLowestAp(this.UL.unr[index2])));
        this.game.CustomBitmapObj.DrawUnit(this.UL.unr[index2], toG: toG, tx: num1, ty: num2, ShowAttacker: true);
        Rectangle trect = new Rectangle(num1, num2, 38, 38);
        this.AddMouse(ref trect, this.game.Data.UnitObj[this.UL.unr[index2]].Name, ttext, this.UL.unr[index2]);
      }
      SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("OK", 150, "Click to return to main screen.", ref this.OwnBitmap, 265, 315, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.cancelid = this.AddSubPart(ref tsubpart, 265, 315, 150, 40, 1);
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr == 27 | nr == 32)
        {
          if (this.game.Data.Product >= 6 & (double) this.game.Data.RuleVar[701] > 0.0 & this.game.EditObj.useLeftRightClickMode)
            this.game.EditObj.battleTimerPopupRefreshDoesntStartIt = true;
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

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
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
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
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
