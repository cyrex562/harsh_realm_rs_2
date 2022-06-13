// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleEditOptionsWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class SimpleEditOptionsWindowClass : WindowClass
  {
    pub BBackId: i32;
    pub BBackTextId: i32;
    pub LibId: i32;
    pub LibIdb: i32;
    pub DashId: i32;
    pub DashIdb: i32;
    pub BackId: i32;
    pub BackIdb: i32;
    pub MapId: i32;
    pub MapIdb: i32;
    pub UnitId: i32;
    pub UnitIdb: i32;
    pub RegId: i32;
    pub RegIdb: i32;
    pub StringId: i32;
    pub StringIdb: i32;
    pub DebugId: i32;
    pub DebugIdb: i32;

    pub void PopUpRefresh()
    {
    }

    pub SimpleEditOptionsWindowClass( GameClass tGame, Bitmap screenbitmap = null, let mut sx: i32 = -1, let mut sy: i32 = -1)
      : base( tGame, tGame.ScreenWidth, 50, 9, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.game.EditObj.inSimpleEditor = true;
      this.domenu();
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      let mut num1: i32 = -50;
      if (this.game.EditObj.SimpleEditWindow == 98 | this.game.EditObj.SimpleEditWindow == 99)
      {
        if ((nr == 187 | nr == 191 | nr == 107) & this.game.EditObj.Zoom < 1)
        {
          let mut num2: i32 =  Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
          let mut num3: i32 =  Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
          let mut num4: i32 =  Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 53.0));
          let mut num5: i32 =  Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 106.0));
          int num6;
          int num7;
          if (this.game.EditObj.Zoom == 0)
          {
            this.game.EditObj.Zoom = 1;
            this.game.CornerX +=  Math.Round(Conversion.Int((double) num3 / 2.0));
            this.game.CornerY +=  Math.Round(Conversion.Int((double) num5 / 2.0));
            num6 = 106;
            num7 = 96;
          }
          else
          {
            this.game.EditObj.Zoom = 0;
            this.game.CornerX +=  Math.Round(Conversion.Int((double) num2 / 2.0));
            this.game.CornerY +=  Math.Round(Conversion.Int((double) num4 / 2.0));
            num6 = 53;
            num7 = 48;
          }
          if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num6 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
            this.game.CornerX =  Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num6);
          if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
            this.game.CornerY =  Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7);
          if (this.game.CornerX < 0)
            this.game.CornerX = 0;
          if (this.game.CornerY < 0)
            this.game.CornerY = 0;
          this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
          this.game.EditObj.TempCoordList = CoordList::new();
          windowReturnClass.AddCommand(1, 5);
          windowReturnClass.AddCommand(2, 12);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
        if ((nr == 189 | nr == 219 | nr == 109) & this.game.EditObj.Zoom > -1)
        {
          let mut num8: i32 =  Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
          let mut num9: i32 =  Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
          let mut num10: i32 =  Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 53.0));
          let mut num11: i32 =  Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 106.0));
          int num12;
          int num13;
          if (this.game.EditObj.Zoom == 0)
          {
            this.game.EditObj.Zoom = -1;
            this.game.CornerX -=  Math.Round(Conversion.Int((double) num8 / 2.0));
            this.game.CornerY -=  Math.Round(Conversion.Int((double) num10 / 2.0));
            num12 = 27;
            num13 = 24;
          }
          else
          {
            this.game.EditObj.Zoom = 0;
            this.game.CornerX -=  Math.Round(Conversion.Int((double) num9 / 2.0));
            this.game.CornerY -=  Math.Round(Conversion.Int((double) num11 / 2.0));
            num12 = 53;
            num13 = 48;
          }
          if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num12 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
            this.game.CornerX =  Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num12);
          if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num13 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
            this.game.CornerY =  Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num13);
          if (this.game.CornerX < 0)
            this.game.CornerX = 0;
          if (this.game.CornerY < 0)
            this.game.CornerY = 0;
          this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
          this.game.EditObj.TempCoordList = CoordList::new();
          windowReturnClass.AddCommand(1, 5);
          windowReturnClass.AddCommand(2, 12);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      return windowReturnClass;
    }

    pub void domenu()
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
      let mut num1: i32 = 10 +  Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      let mut tsubpart1: SubPartClass =  new TextButtonPartClass("Exit", 100, tBackbitmap: ( this.OwnBitmap), bbx: num1, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.BackId = this.AddSubPart( tsubpart1, num1, 5, 100, 40, 1);
      let mut num2: i32 = num1 + 110;
      SubPartClass tsubpart2;
      if (this.game.EditObj.SimpleEditWindow != 95)
      {
        tsubpart2 =  new TextButtonPartClass("Dashboard", 100, tBackbitmap: ( this.OwnBitmap), bbx: num2, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.DashId = this.AddSubPart( tsubpart2, num2, 5, 100, 40, 1);
      }
      else
      {
        tsubpart2 =  new TextButtonPartClass("Dashboard", 100, tBackbitmap: ( this.OwnBitmap), bbx: num2, bby: 5, tinactive: true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.DashIdb = this.AddSubPart( tsubpart2, num2, 5, 100, 40, 1);
      }
      let mut num3: i32 = num2 + 110;
      if (this.game.EditObj.SimpleEditWindow != 96)
      {
        tsubpart2 =  new TextButtonPartClass("Libraries", 100, tBackbitmap: ( this.OwnBitmap), bbx: num3, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.LibId = this.AddSubPart( tsubpart2, num3, 5, 100, 40, 1);
      }
      else
      {
        tsubpart2 =  new TextButtonPartClass("Libraries", 100, tBackbitmap: ( this.OwnBitmap), bbx: num3, bby: 5, tinactive: true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.LibIdb = this.AddSubPart( tsubpart2, num3, 5, 100, 40, 1);
      }
      let mut num4: i32 = num3 + 110;
      if (this.game.EditObj.SimpleEditWindow != 98)
      {
        tsubpart2 =  new TextButtonPartClass("Map", 100, tBackbitmap: ( this.OwnBitmap), bbx: num4, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.MapId = this.AddSubPart( tsubpart2, num4, 5, 100, 40, 1);
      }
      else
      {
        tsubpart2 =  new TextButtonPartClass("Map", 100, tBackbitmap: ( this.OwnBitmap), bbx: num4, bby: 5, tinactive: true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.MapIdb = this.AddSubPart( tsubpart2, num4, 5, 100, 40, 1);
      }
      let mut num5: i32 = num4 + 110;
      if (this.game.EditObj.SimpleEditWindow != 99)
      {
        tsubpart2 =  new TextButtonPartClass("Units", 100, tBackbitmap: ( this.OwnBitmap), bbx: num5, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.UnitId = this.AddSubPart( tsubpart2, num5, 5, 100, 40, 1);
      }
      else
      {
        tsubpart2 =  new TextButtonPartClass("Units", 100, tBackbitmap: ( this.OwnBitmap), bbx: num5, bby: 5, tinactive: true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.UnitIdb = this.AddSubPart( tsubpart2, num5, 5, 100, 40, 1);
      }
      let mut num6: i32 = num5 + 110;
      if (this.game.EditObj.SimpleEditWindow != 100)
      {
        tsubpart2 =  new TextButtonPartClass("Regimes", 100, tBackbitmap: ( this.OwnBitmap), bbx: num6, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RegId = this.AddSubPart( tsubpart2, num6, 5, 100, 40, 1);
      }
      else
      {
        tsubpart2 =  new TextButtonPartClass("Regimes", 100, tBackbitmap: ( this.OwnBitmap), bbx: num6, bby: 5, tinactive: true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RegIdb = this.AddSubPart( tsubpart2, num6, 5, 100, 40, 1);
      }
      let mut num7: i32 = num6 + 110;
      if (this.game.EditObj.SimpleEditWindow != 101)
      {
        tsubpart2 =  new TextButtonPartClass("Tables", 100, tBackbitmap: ( this.OwnBitmap), bbx: num7, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.StringId = this.AddSubPart( tsubpart2, num7, 5, 100, 40, 1);
      }
      else
      {
        tsubpart2 =  new TextButtonPartClass("Tables", 100, tBackbitmap: ( this.OwnBitmap), bbx: num7, bby: 5, tinactive: true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.StringIdb = this.AddSubPart( tsubpart2, num7, 5, 100, 40, 1);
      }
      let mut num8: i32 = num7 + 110;
      if (this.game.EditObj.SimpleEditWindow != 109)
      {
        tsubpart2 =  new TextButtonPartClass("Debug", 100, tBackbitmap: ( this.OwnBitmap), bbx: num8, bby: 5, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.DebugId = this.AddSubPart( tsubpart2, num8, 5, 100, 40, 1);
      }
      else
      {
        tsubpart2 =  new TextButtonPartClass("Debug", 100, tBackbitmap: ( this.OwnBitmap), bbx: num8, bby: 5, tinactive: true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.DebugIdb = this.AddSubPart( tsubpart2, num8, 5, 100, 40, 1);
      }
    }

    pub void DoRefresh() => this.domenu();

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
            if (num == this.BackId)
            {
              this.game.EditObj.InEditor = false;
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
                windowReturnClass.AddCommand(2, 96);
                this.game.EditObj.SimpleEditWindow = 96;
                this.domenu();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num == this.RegId)
              {
                this.game.EditObj.PencilMode = 0;
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(2, 100);
                this.game.EditObj.SimpleEditWindow = 100;
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
              if (num == this.UnitId)
              {
                this.game.EditObj.PencilMode = 0;
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(2, 99);
                windowReturnClass.AddCommand(2, 12);
                this.game.EditObj.SimpleEditWindow = 99;
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
