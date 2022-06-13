// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.OfficerInfoWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Text;

namespace WindowsApplication1
{
  pub class OfficerInfoWindowClass : WindowClass
  {
     int okid;
     int cancelid;
     int oktextid;
     int Pic1Id;
     int TAid;
     int His;
     int Card;
     int Unr;

    pub OfficerInfoWindowClass( GameClass tGame)
      : base( tGame, 810, 610, BackSprite: tGame.BACKGROUND2MARC, tBackSpriteScaled: true)
    {
      this.His = this.game.EditObj.TempHisUnit <= -1 ? tGame.Data.UnitObj[tGame.EditObj.UnitSelected].Historical : this.game.EditObj.TempHisUnit;
      this.View();
    }

    pub void View()
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
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      int commanderSpriteId = this.game.Data.HistoricalUnitObj[this.His].CommanderSpriteID;
      int num;
      if (commanderSpriteId > -1)
      {
        SizeF sizeF1 = SizeF::new();
        SizeF sizeF2 = objgraphics.MeasureString(this.game.Data.HistoricalUnitObj[this.His].CommanderName, Font::new("Arial", 48f, FontStyle.Regular, GraphicsUnit.Pixel));
        DrawMod.DrawTextColouredNicely( objgraphics, this.game.Data.HistoricalUnitObj[this.His].CommanderName, Font::new("Arial", 48f, FontStyle.Regular, GraphicsUnit.Pixel),  Math.Round(405.0 - (double) sizeF2.Width / 2.0 + 2.0), 62, Color.Black);
        DrawMod.DrawTextColouredNicely( objgraphics, this.game.Data.HistoricalUnitObj[this.His].CommanderName, Font::new("Arial", 48f, FontStyle.Regular, GraphicsUnit.Pixel),  Math.Round(405.0 - (double) sizeF2.Width / 2.0), 60, Color.White);
        int width = BitmapStore.GetWidth(commanderSpriteId);
        int height = BitmapStore.Getheight(commanderSpriteId);
        if (width > 320)
        {
          height =  Math.Round((double) height * (320.0 / (double) width));
          width =  Math.Round((double) width * (320.0 / (double) width));
        }
        Rectangle rectangle = new Rectangle( Math.Round(405.0 - (double) width / 2.0), 130, width, height);
        DrawMod.DrawOfficer(objgraphics, this.His, rectangle.X, rectangle.Y, BitmapStore.GetWidth(commanderSpriteId), BitmapStore.Getheight(commanderSpriteId));
        num = height + 100 + 20 + 30;
      }
      else
        num = 60;
      int trows =  Math.Round(Conversion.Int(65.0 / 3.0) - (double) num / 24.0);
      let mut tsubpart1: SubPartClass =  new TextAreaClass(this.game, 650, trows, this.game.GameFont1, "", false, this.game.Data.HistoricalUnitObj[this.His].Descript, Color.White, tItemSize: 20, tbackbitmap: ( this.OwnBitmap), bbx: 75, bby: num, tcenterit: true);
      this.TAid = this.AddSubPart( tsubpart1, 75, num, 650, 20 * (trows + 3), 0);
      let mut tsubpart2: SubPartClass =  new TextButtonPartClass("OK", 200, tBackbitmap: ( this.OwnBitmap), bbx: 300, bby: 540);
      this.cancelid = this.AddSubPart( tsubpart2, 300, 540, 200, 35, 1);
      if (Information.IsNothing((object) objgraphics))
        return;
      objgraphics.Dispose();
      objgraphics = (Graphics) null;
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
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

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; index += 1)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num = this.SubPartID[index];
            if (num == this.TAid)
            {
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.cancelid)
            {
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
