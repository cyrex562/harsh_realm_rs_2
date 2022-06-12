// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.HandCardWindowClass
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
  public class HandCardWindowClass : WindowClass
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

    public HandCardWindowClass(ref GameClass tGame)
      : base(ref tGame, 810, 610, BackSprite: tGame.BACKGROUND2MARC, tBackSpriteScaled: true)
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

    public void ViewCard()
    {
      if (this.Pic1Id > 0)
        this.RemoveSubPart(this.Pic1Id);
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
      if (this.oktextid > 0)
        this.RemoveSubPart(this.oktextid);
      if (this.TAid > 0)
        this.RemoveSubPart(this.TAid);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      ref Graphics local1 = ref Expression;
      Bitmap bitmap = this.game.CustomBitmapObj.DrawActionCard(this.Card);
      ref Bitmap local2 = ref bitmap;
      DrawMod.DrawSimple(ref local1, ref local2, 250, 40);
      if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.ActionCardObj[this.Card].PPCost | this.game.Data.ActionCardObj[this.Card].PPCost == 0)
      {
        SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Play Card", 200, tBackbitmap: (ref this.OwnBitmap), bbx: 150, bby: 540);
        this.okid = this.AddSubPart(ref tsubpart1, 150, 540, 200, 35, 1);
        SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Cancel", 200, tBackbitmap: (ref this.OwnBitmap), bbx: 450, bby: 540);
        this.cancelid = this.AddSubPart(ref tsubpart2, 450, 540, 200, 35, 1);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Cancel", 200, tBackbitmap: (ref this.OwnBitmap), bbx: 300, bby: 540);
        this.cancelid = this.AddSubPart(ref tsubpart, 300, 540, 200, 35, 1);
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
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
              if (this.game.Data.ActionCardObj[this.Card].AreaSlot > -1)
              {
                this.game.ProcessingObj.PlayCardPreEvent(this.Card);
                this.game.EditObj.DoCardSlot = -1;
                this.game.EditObj.AreaSlot = this.game.Data.ActionCardObj[this.Card].AreaSlot;
                this.game.EditObj.AreaValue = this.game.Data.ActionCardObj[this.Card].AreaValue;
                this.game.EditObj.PopupValue = 1;
                windowReturnClass.AddCommand(5, 10);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.Data.ActionCardObj[this.Card].UnitSelect)
              {
                this.game.ProcessingObj.PlayCardPreEvent(this.Card);
                this.game.EditObj.DoCardSlot = -1;
                this.game.EditObj.AreaSlot = this.game.Data.ActionCardObj[this.Card].AreaSlot;
                this.game.EditObj.AreaValue = this.game.Data.ActionCardObj[this.Card].AreaValue;
                this.game.EditObj.PopupValue = 3;
                windowReturnClass.AddCommand(5, 10);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
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
                windowReturnClass.AddCommand(3, 4);
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
              if (this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter > messCounter)
              {
                this.game.EditObj.PopupValue = 0;
                this.game.EditObj.FromMessage = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
                windowReturnClass.AddCommand(5, 10);
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
