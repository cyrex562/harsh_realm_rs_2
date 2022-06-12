// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleEditMapOptionsWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class SimpleEditMapOptionsWindowClass : WindowClass
  {
    public int BBackId;
    public int BBackTextId;
    public int LibId;
    public int LibIdb;
    public int DashId;
    public int DashIdb;
    public int BackId;
    public int BackIdb;
    public int MapId;
    public int MapIdb;
    public int UnitId;
    public int UnitIdb;
    public int ReplId;
    public int ReplIdb;
    public int RegId;
    public int RegIdb;
    public int StringId;
    public int StringIdb;

    public void PopUpRefresh()
    {
    }

    public SimpleEditMapOptionsWindowClass(
      ref GameClass tGame,
      Bitmap screenbitmap = null,
      int sx = -1,
      int sy = -1)
      : base(ref tGame, tGame.ScreenWidth, 50, 9, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.game.EditObj.inSimpleEditor = true;
      this.domenu();
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int num1 = -50;
      if (this.game.EditObj.SimpleEditWindow == 98 | this.game.EditObj.SimpleEditWindow == 99)
      {
        if ((nr == 187 | nr == 191 | nr == 107) & this.game.EditObj.Zoom < 1)
        {
          int num2 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
          int num3 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
          int num4 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 53.0));
          int num5 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 106.0));
          int num6;
          int num7;
          if (this.game.EditObj.Zoom == 0)
          {
            this.game.EditObj.Zoom = 1;
            this.game.CornerX += (int) Math.Round(Conversion.Int((double) num3 / 2.0));
            this.game.CornerY += (int) Math.Round(Conversion.Int((double) num5 / 2.0));
            num6 = 106;
            num7 = 96;
          }
          else
          {
            this.game.EditObj.Zoom = 0;
            this.game.CornerX += (int) Math.Round(Conversion.Int((double) num2 / 2.0));
            this.game.CornerY += (int) Math.Round(Conversion.Int((double) num4 / 2.0));
            num6 = 53;
            num7 = 48;
          }
          if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num6 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
            this.game.CornerX = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num6);
          if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
            this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7);
          if (this.game.CornerX < 0)
            this.game.CornerX = 0;
          if (this.game.CornerY < 0)
            this.game.CornerY = 0;
          this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
          this.game.EditObj.TempCoordList = new CoordList();
          windowReturnClass.AddCommand(1, 5);
          windowReturnClass.AddCommand(2, 12);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
        if ((nr == 189 | nr == 219 | nr == 109) & this.game.EditObj.Zoom > -1)
        {
          int num8 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
          int num9 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
          int num10 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 53.0));
          int num11 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 106.0));
          int num12;
          int num13;
          if (this.game.EditObj.Zoom == 0)
          {
            this.game.EditObj.Zoom = -1;
            this.game.CornerX -= (int) Math.Round(Conversion.Int((double) num8 / 2.0));
            this.game.CornerY -= (int) Math.Round(Conversion.Int((double) num10 / 2.0));
            num12 = 27;
            num13 = 24;
          }
          else
          {
            this.game.EditObj.Zoom = 0;
            this.game.CornerX -= (int) Math.Round(Conversion.Int((double) num9 / 2.0));
            this.game.CornerY -= (int) Math.Round(Conversion.Int((double) num11 / 2.0));
            num12 = 53;
            num13 = 48;
          }
          if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num12 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
            this.game.CornerX = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num12);
          if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num13 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
            this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num13);
          if (this.game.CornerX < 0)
            this.game.CornerX = 0;
          if (this.game.CornerY < 0)
            this.game.CornerY = 0;
          this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
          this.game.EditObj.TempCoordList = new CoordList();
          windowReturnClass.AddCommand(1, 5);
          windowReturnClass.AddCommand(2, 12);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      return windowReturnClass;
    }

    public void domenu()
    {
      if (this.BackId > 0)
        this.RemoveSubPart(this.BackId);
      if (this.LibId > 0)
        this.RemoveSubPart(this.LibId);
      if (this.BackIdb > 0)
        this.RemoveSubPart(this.BackIdb);
      if (this.LibIdb > 0)
        this.RemoveSubPart(this.LibIdb);
      if (this.DashId > 0)
        this.RemoveSubPart(this.DashId);
      if (this.DashIdb > 0)
        this.RemoveSubPart(this.DashIdb);
      if (this.MapId > 0)
        this.RemoveSubPart(this.MapId);
      if (this.MapIdb > 0)
        this.RemoveSubPart(this.MapIdb);
      if (this.UnitId > 0)
        this.RemoveSubPart(this.UnitId);
      if (this.UnitIdb > 0)
        this.RemoveSubPart(this.UnitIdb);
      if (this.RegId > 0)
        this.RemoveSubPart(this.RegId);
      if (this.RegIdb > 0)
        this.RemoveSubPart(this.RegIdb);
      if (this.ReplId > 0)
        this.RemoveSubPart(this.ReplId);
      if (this.ReplIdb > 0)
        this.RemoveSubPart(this.ReplIdb);
      if (this.StringId > 0)
        this.RemoveSubPart(this.StringId);
      if (this.StringIdb > 0)
        this.RemoveSubPart(this.StringIdb);
      int num1 = 10 + (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Exit", 100, tBackbitmap: (ref this.OwnBitmap), bbx: num1, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.BackId = this.AddSubPart(ref tsubpart1, num1, 5, 100, 40, 1);
      int num2 = num1 + 110;
      SubPartClass tsubpart2;
      if (this.game.EditObj.SimpleEditWindow != 95)
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Options", 100, tBackbitmap: (ref this.OwnBitmap), bbx: num2, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.DashId = this.AddSubPart(ref tsubpart2, num2, 5, 100, 40, 1);
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Options", 100, tBackbitmap: (ref this.OwnBitmap), bbx: num2, bby: 5, tinactive: true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.DashIdb = this.AddSubPart(ref tsubpart2, num2, 5, 100, 40, 1);
      }
      int num3 = num2 + 110;
      if (this.game.EditObj.SimpleEditWindow != 98)
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Map", 100, tBackbitmap: (ref this.OwnBitmap), bbx: num3, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.MapId = this.AddSubPart(ref tsubpart2, num3, 5, 100, 40, 1);
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Map", 100, tBackbitmap: (ref this.OwnBitmap), bbx: num3, bby: 5, tinactive: true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.MapIdb = this.AddSubPart(ref tsubpart2, num3, 5, 100, 40, 1);
      }
      int num4 = num3 + 110;
      if (this.game.EditObj.SimpleEditWindow != 112)
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Replace", 100, tBackbitmap: (ref this.OwnBitmap), bbx: num4, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.ReplId = this.AddSubPart(ref tsubpart2, num4, 5, 100, 40, 1);
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Replace", 100, tBackbitmap: (ref this.OwnBitmap), bbx: num4, bby: 5, tinactive: true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.ReplIdb = this.AddSubPart(ref tsubpart2, num4, 5, 100, 40, 1);
      }
    }

    public override void DoRefresh() => this.domenu();

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
            if (num == this.BackId)
            {
              this.game.EditObj.InEditor = false;
              this.game.EditObj.inSimpleMapEditor = false;
              if (this.game.EditorBlock)
                this.game.EditObj.ShowInitialMenu = true;
              if (this.game.ModIntroType == 0)
                windowReturnClass.AddCommand(3, 1);
              else
                windowReturnClass.AddCommand(3, 12);
            }
            else
            {
              if (num == this.DashId)
              {
                this.game.EditObj.PencilMode = 0;
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(2, 107);
                this.game.EditObj.SimpleEditWindow = 107;
                this.domenu();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num == this.MapId)
              {
                this.game.EditObj.PencilMode = 0;
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(2, 98);
                windowReturnClass.AddCommand(2, 12);
                this.game.EditObj.SimpleEditWindow = 98;
                this.domenu();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num == this.ReplId)
              {
                this.game.EditObj.PencilMode = 0;
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(2, 112);
                this.game.EditObj.SimpleEditWindow = 112;
                this.domenu();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
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
