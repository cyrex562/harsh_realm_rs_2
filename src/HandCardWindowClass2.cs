﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.HandCardWindowClass2
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
  public class HandCardWindowClass2 : WindowClass
  {
    private int okid;
    private int cancelid;
    private int oktextid;
    private int Pic1Id;
    private int TAid;
    private int His;
    private int Card;
    private int Unr;
    private int tSelectX;
    private int tSelectY;
    private int tSelectMap;
    private int tCornerX;
    private int tCornerY;

    public HandCardWindowClass2(ref GameClass tGame)
      : base(ref tGame, 380, 380, 8)
    {
      this.His = tGame.Data.UnitObj[tGame.EditObj.UnitSelected].Historical;
      this.Unr = tGame.EditObj.UnitSelected;
      this.Card = tGame.EditObj.HandCard;
      this.tSelectX = this.game.SelectX;
      this.tSelectY = this.game.SelectY;
      this.tCornerX = this.game.CornerX;
      this.tCornerY = this.game.CornerY;
      this.tSelectMap = this.game.EditObj.MapSelected;
      this.ViewCard();
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

    public void ViewCard()
    {
      this.ClearMouse();
      this.NewBackGroundAndClearAll(380, 380, -1);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref g, 0, 0, 380, 380);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      if (this.okid > 0)
      {
        this.RemoveSubPart(this.okid);
        this.okid = 0;
      }
      if (this.cancelid > 0)
      {
        this.RemoveSubPart(this.cancelid);
        this.cancelid = 0;
      }
      ref Graphics local1 = ref g;
      Bitmap bitmap = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.Turn, this.Card);
      ref Bitmap local2 = ref bitmap;
      DrawMod.DrawSimple(ref local1, ref local2, 95, 30);
      if (this.game.Data.ActionCardObj[this.Card].MouseOver.Length > 0)
      {
        Rectangle trect = new Rectangle(95, 30, 190, 266);
        this.AddMouse(ref trect, "", this.game.Data.ActionCardObj[this.Card].MouseOver);
      }
      if ((this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.ActionCardObj[this.Card].PPCost | this.game.Data.ActionCardObj[this.Card].PPCost == 0) & (this.game.Data.ActionCardObj[this.Card].HisVarCostType == -1 | this.game.Data.HistoricalUnitObj[this.His].GiveHisVarValue(this.game.Data.ActionCardObj[this.Card].HisVarCostType) >= this.game.Data.ActionCardObj[this.Card].HisVarCostQty))
      {
        SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("PLAY CARD", 125, "Click to play this actioncard. [SPACE]", ref this.OwnBitmap, 50, 310, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.okid = this.AddSubPart(ref tsubpart1, 50, 310, 105, 40, 1);
        SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("CANCEL", 105, "Click to not play this card. [ESC]", ref this.OwnBitmap, 205, 310, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.cancelid = this.AddSubPart(ref tsubpart2, 205, 310, 105, 40, 1);
      }
      else
      {
        SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("PLAY CARD", 125, "You do not have the PP and/or commander points needed.", ref this.OwnBitmap, 50, 310, true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.oktextid = this.AddSubPart(ref tsubpart3, 50, 310, 105, 40, 1);
        SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("CANCEL", 105, "Click to not play this card. [ESC]", ref this.OwnBitmap, 205, 310, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.cancelid = this.AddSubPart(ref tsubpart4, 205, 310, 105, 40, 1);
      }
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr == 27)
        {
          windowReturnClass.AddCommand(6, 0);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
        if (nr == 32)
        {
          windowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.okid)] + 1, this.SubPartY[this.SubpartNr(this.okid)] + 1, 1);
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
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num1 = this.SubPartID[index1];
            if (num1 == this.okid)
            {
              this.game.EditObj.SkippedPreSelectPopup = false;
              if (this.game.Data.ActionCardObj[this.Card].AreaSlot > -1)
              {
                this.game.ProcessingObj.PlayCardPreEvent(this.Card);
                if (this.game.HandyFunctionsObj.CardSelectHexTestPossible(this.Card, this.game.Data.ActionCardObj[this.Card].AreaSlot, this.game.Data.ActionCardObj[this.Card].AreaValue))
                {
                  this.game.EditObj.DoCardSlot = this.Card;
                  this.game.EditObj.AreaSlot = this.game.Data.ActionCardObj[this.Card].AreaSlot;
                  this.game.EditObj.AreaValue = this.game.Data.ActionCardObj[this.Card].AreaValue;
                  this.game.EditObj.PopupValue = 1;
                  windowReturnClass.AddCommand(5, 14);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                this.game.EditObj.SkippedPreSelectPopup = true;
              }
              else if (this.game.Data.ActionCardObj[this.Card].UnitSelect)
              {
                this.game.ProcessingObj.PlayCardPreEvent(this.Card);
                if (this.game.HandyFunctionsObj.CardSelectUnitTestPossible(this.Card))
                {
                  this.game.EditObj.PopupValue = 3;
                  windowReturnClass.AddCommand(5, 14);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                this.game.EditObj.SkippedPreSelectPopup = true;
              }
              int messCounter = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
              this.game.ProcessingObj.PlayCardByUnit(this.game.EditObj.UnitSelected, this.Card);
              this.game.EditObj.AreaX = -1;
              this.game.EditObj.AreaSlot = -1;
              this.game.EditObj.HandCard = -1;
              if (Strings.Len(this.game.Data.LoadGame) > 0)
              {
                this.game.FormRef.Cursor = Cursors.WaitCursor;
                Form formRef = (Form) this.game.FormRef;
                this.game.HandyFunctionsObj.LoadGameNow();
                this.game.FormRef = (Form1) formRef;
                this.game.FormRef.Cursor = Cursors.Default;
                windowReturnClass.AddCommand(3, 13);
                return windowReturnClass;
              }
              int locCounter = this.game.Data.LocCounter;
              int Number;
              for (int locnr = 0; locnr <= locCounter; ++locnr)
              {
                if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y].Regime == this.game.Data.Turn)
                {
                  int index2 = 0;
                  do
                  {
                    if (this.game.Data.LocObj[locnr].Production[index2] > -1 && !this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, this.game.Data.LocObj[locnr].Production[index2]).result)
                    {
                      ++Number;
                      this.game.Data.LocObj[locnr].Production[index2] = -1;
                      this.game.Data.LocObj[locnr].ProdPointRemainder[index2] = 0;
                      this.game.Data.LocObj[locnr].ProdPercent[index2] = 0;
                    }
                    ++index2;
                  }
                  while (index2 <= 3);
                }
              }
              if (Number > 0)
              {
                int num2 = (int) Interaction.MsgBox((object) (Conversion.Str((object) Number) + " production lines have been cancelled due to this action card being played."), Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.game.CornerX = this.tCornerX;
              this.game.CornerY = this.tCornerY;
              this.game.SelectX = this.tSelectX;
              this.game.SelectY = this.tSelectY;
              this.game.EditObj.MapSelected = this.tSelectMap;
              this.game.EditObj.TempCoordList = new CoordList();
              this.game.HandyFunctionsObj.RedimTempValue(9999);
              if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.Data.Product >= 6)
                this.game.EditObj.udsReturnFromPopup = true;
              if (this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter > messCounter)
              {
                this.game.EditObj.PopupValue = 0;
                this.game.EditObj.FromMessage = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
                windowReturnClass.AddCommand(5, 14);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              this.game.EditObj.DoCardSlot = -1;
              return windowReturnClass;
            }
            if (num1 == this.cancelid)
            {
              this.game.CornerX = this.tCornerX;
              this.game.CornerY = this.tCornerY;
              this.game.SelectX = this.tSelectX;
              this.game.SelectY = this.tSelectY;
              this.game.EditObj.MapSelected = this.tSelectMap;
              this.game.EditObj.TempCoordList = new CoordList();
              this.game.HandyFunctionsObj.RedimTempValue(9999);
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
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
