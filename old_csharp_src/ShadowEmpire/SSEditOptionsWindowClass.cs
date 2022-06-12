// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SSEditOptionsWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class SSEditOptionsWindowClass : WindowClass
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
    public int RegId;
    public int RegIdb;
    public int StringId;
    public int StringIdb;
    public int DebugId;
    public int DebugIdb;

    public void PopUpRefresh()
    {
    }

    public SSEditOptionsWindowClass(ref GameClass tGame, Bitmap screenbitmap = null, int sx = -1, int sy = -1)
      : base(ref tGame, tGame.ScreenWidth, 50, 9, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.game.EditObj.inSimpleEditor = true;
      this.domenu();
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
      if (this.StringId > 0)
        this.RemoveSubPart(this.StringId);
      if (this.StringIdb > 0)
        this.RemoveSubPart(this.StringIdb);
      if (this.DebugId > 0)
        this.RemoveSubPart(this.DebugId);
      if (this.DebugIdb > 0)
        this.RemoveSubPart(this.DebugIdb);
      int num1 = 10 + (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Exit", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 10, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.BackId = this.AddSubPart(ref tsubpart1, 10, 5, 100, 40, 1);
      int num2 = num1 + 110;
      SubPartClass tsubpart2;
      if (this.game.EditObj.SimpleEditWindow != 95)
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Dashboard", 100, tBackbitmap: (ref this.OwnBitmap), bbx: num2, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.DashId = this.AddSubPart(ref tsubpart2, num2, 5, 100, 40, 1);
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Dashboard", 100, tBackbitmap: (ref this.OwnBitmap), bbx: num2, bby: 5, tinactive: true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.DashIdb = this.AddSubPart(ref tsubpart2, num2, 5, 100, 40, 1);
      }
      int num3 = num2 + 110;
      if (this.game.EditObj.SimpleEditWindow != 101)
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Tables", 100, tBackbitmap: (ref this.OwnBitmap), bbx: num3, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.StringId = this.AddSubPart(ref tsubpart2, num3, 5, 100, 40, 1);
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Tables", 100, tBackbitmap: (ref this.OwnBitmap), bbx: num3, bby: 5, tinactive: true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.StringIdb = this.AddSubPart(ref tsubpart2, num3, 5, 100, 40, 1);
      }
      int num4 = num3 + 110;
      if (this.game.EditObj.SimpleEditWindow != 122)
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Event Pics", 100, tBackbitmap: (ref this.OwnBitmap), bbx: num4, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.LibId = this.AddSubPart(ref tsubpart2, num4, 5, 100, 40, 1);
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Event Pics", 100, tBackbitmap: (ref this.OwnBitmap), bbx: num4, bby: 5, tinactive: true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.LibIdb = this.AddSubPart(ref tsubpart2, num4, 5, 100, 40, 1);
      }
      int num5 = num4 + 110;
      if (this.game.EditObj.SimpleEditWindow != 123)
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Small Gfx", 100, tBackbitmap: (ref this.OwnBitmap), bbx: num5, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.UnitId = this.AddSubPart(ref tsubpart2, num5, 5, 100, 40, 1);
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Small Gfx", 100, tBackbitmap: (ref this.OwnBitmap), bbx: num5, bby: 5, tinactive: true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.UnitIdb = this.AddSubPart(ref tsubpart2, num5, 5, 100, 40, 1);
      }
      int num6 = num5 + 110;
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
              if (!this.game.SuperAdminRights)
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
                windowReturnClass.AddCommand(2, 95);
                this.game.EditObj.SimpleEditWindow = 95;
                this.domenu();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num == this.LibId)
              {
                this.game.EditObj.PencilMode = 0;
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(2, 122);
                this.game.EditObj.SimpleEditWindow = 122;
                this.domenu();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num == this.UnitId)
              {
                this.game.EditObj.PencilMode = 0;
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(2, 123);
                this.game.EditObj.SimpleEditWindow = 123;
                this.domenu();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num == this.DebugId)
              {
                this.game.EditObj.PencilMode = 0;
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(2, 109);
                this.game.EditObj.SimpleEditWindow = 109;
                this.domenu();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num == this.StringId)
              {
                this.game.EditObj.PencilMode = 0;
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(2, 101);
                this.game.EditObj.SimpleEditWindow = 101;
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
