// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.UdsUnitOpsWindowClass
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
  public class UdsUnitOpsWindowClass : WindowClass
  {
    private int but1;
    private int but2;
    private int but3;
    private int but4;
    private int but5;
    private int but6;
    private int but7;
    private int but8;
    private int but9;
    private int but10;
    private int but11;
    private int cancelid;
    private int[] udsBut;
    private int udsButCounter;
    private int zoneId;
    private SimpleStringList SL;

    public UdsUnitOpsWindowClass(
      ref GameClass tGame,
      ref WindowClass tLowerWindow,
      ref Rectangle tLowerRect,
      ref int useHeight)
      : base(ref tGame, 200, useHeight, 8)
    {
      this.udsBut = new int[100];
      this.udsButCounter = -1;
      this.zoneId = -1;
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.SL = this.game.HandyFunctionsObj.UnitPopupUdsButtons();
      this.udsButCounter = -1;
      this.View();
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
      this.ClearMouse();
      this.NewBackGroundAndClearAll(200, this.LowerRect.Height, -1);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref graphics, 0, 0, 200, this.LowerRect.Height);
      SizeF sizeF1 = new SizeF();
      string str1 = "Select Order Mode";
      SizeF sizeF2 = graphics.MeasureString(str1, this.game.MarcFont4);
      DrawMod.DrawTextColouredMarc(ref graphics, str1, this.game.MarcFont4, (int) Math.Round(100.0 - (double) sizeF2.Width / 2.0), 10, Color.White);
      int num1 = 28;
      int num2 = 30;
      bool flag1 = false;
      if (this.game.EditObj.udsUnitOrderMode == 0)
        flag1 = true;
      SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Inspect", 160, "Allows you to just look at your units [Shortkey I]", ref this.OwnBitmap, 20, num2, flag1, flag1, num1, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.but1 = this.AddSubPart(ref tsubpart1, 20, num2, 160, num1, 1);
      int num3 = num2 + (num1 + 2);
      bool flag2 = false;
      if (this.game.EditObj.udsUnitOrderMode == 1)
        flag2 = true;
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Move", 160, "Allows you to move units and initiate regular attacks [Shortkey M]", ref this.OwnBitmap, 20, num3, flag2, flag2, num1, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.but2 = this.AddSubPart(ref tsubpart2, 20, num3, 160, num1, 1);
      int num4 = num3 + (num1 + 2);
      bool flag3 = false;
      if (this.game.EditObj.udsUnitOrderMode == 48)
        flag3 = true;
      SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Group Move", 160, "Allows you to move all units in the same hex at the same time [Shortkey G]", ref this.OwnBitmap, 20, num4, flag3, flag3, num1, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.but7 = this.AddSubPart(ref tsubpart3, 20, num4, 160, num1, 1);
      int num5 = num4 + (num1 + 2);
      bool flag4 = false;
      if (this.game.EditObj.udsUnitOrderMode == 18)
        flag4 = true;
      SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Strategic Move", 160, "Allows your units to be transfered by your logistical network [Shortkey S]", ref this.OwnBitmap, 20, num5, flag4, flag4, num1, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.but3 = this.AddSubPart(ref tsubpart4, 20, num5, 160, num1, 1);
      int num6 = num5 + (num1 + 2);
      bool flag5 = false;
      if (this.game.EditObj.udsUnitOrderMode == 11)
        flag5 = true;
      SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("Ranged Attack", 160, "Allows your to target units with artillery or missile fire [Shortkey A]", ref this.OwnBitmap, 20, num6, flag5, flag5, num1, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.but4 = this.AddSubPart(ref tsubpart5, 20, num6, 160, num1, 1);
      if (this.game.EventRelatedObj.Helper_AirEnabled())
      {
        int num7 = num6 + (num1 + 2);
        bool flag6 = false;
        if (this.game.EditObj.udsUnitOrderMode == 14)
          flag6 = true;
        SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("Air Attack", 160, "Allows your to target units with your airforce [Shortkey X]", ref this.OwnBitmap, 20, num7, flag6, flag6, num1, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.but9 = this.AddSubPart(ref tsubpart6, 20, num7, 160, num1, 1);
        int num8 = num7 + (num1 + 2);
        bool flag7 = false;
        if (this.game.EditObj.udsUnitOrderMode == 33)
          flag7 = true;
        SubPartClass tsubpart7 = (SubPartClass) new TextButtonPartClass("Air Recon", 160, "Allows your to do a recon mission with your airforce [Shortkey Y]", ref this.OwnBitmap, 20, num8, flag7, flag7, num1, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.but10 = this.AddSubPart(ref tsubpart7, 20, num8, 160, num1, 1);
        num6 = num8 + (num1 + 2);
        bool flag8 = false;
        if (this.game.EditObj.udsUnitOrderMode == 55)
          flag8 = true;
        SubPartClass tsubpart8 = (SubPartClass) new TextButtonPartClass("Air Bridge", 160, "Allows your to order Air Bridges", ref this.OwnBitmap, 20, num6, flag8, flag8, num1, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.but11 = this.AddSubPart(ref tsubpart8, 20, num6, 160, num1, 1);
      }
      if ((double) this.game.Data.RuleVar[702] > 0.0)
      {
        num6 += num1 + 2;
        bool flag9 = false;
        if (this.game.EditObj.udsUnitOrderMode == 36)
          flag9 = true;
        SubPartClass tsubpart9 = (SubPartClass) new TextButtonPartClass("Construct Road", 160, "Allows your to construct roads [Shortkey R]", ref this.OwnBitmap, 20, num6, flag9, flag9, num1, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.but5 = this.AddSubPart(ref tsubpart9, 20, num6, 160, num1, 1);
      }
      int num9 = num6 + (num1 + 2);
      bool flag10 = false;
      if (this.game.EditObj.udsUnitOrderMode == 53)
        flag10 = true;
      SubPartClass tsubpart10 = (SubPartClass) new TextButtonPartClass("Traffic Signs", 160, "Allows you to place and remove Traffic Signs [Shortkey T]", ref this.OwnBitmap, 20, num9, flag10, flag10, num1, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.but6 = this.AddSubPart(ref tsubpart10, 20, num9, 160, num1, 1);
      DataClass data = DrawMod.TGame.Data;
      string str2 = "Zones";
      ref string local = ref str2;
      this.zoneId = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(data.FindLibVar(ref local, "SE_Data"));
      int num10 = -1;
      if (this.zoneId > 0)
        num10 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0))].GetData(0, this.zoneId, 8)));
      int num11 = num9 + (num1 + 2);
      bool flag11 = false;
      if (this.game.EditObj.udsUnitOrderMode == 54)
        flag11 = true;
      if (this.game.Data.RegimeObj[this.game.Data.Turn].id == num10 & this.zoneId > 0)
      {
        SubPartClass tsubpart11 = (SubPartClass) new TextButtonPartClass("Zone Borders", 160, "Allows you to re-draw the Zone Borders [Shortkey Z]", ref this.OwnBitmap, 20, num11, flag11, flag11, num1, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.but8 = this.AddSubPart(ref tsubpart11, 20, num11, 160, num1, 1);
      }
      int num12 = num11 + (num1 + 2);
      SubPartClass tsubpart12 = (SubPartClass) new TextButtonPartClass("Exit", 100, "Click to return to main screen.", ref this.OwnBitmap, 50, this.LowerRect.Height - 55, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.cancelid = this.AddSubPart(ref tsubpart12, 50, this.LowerRect.Height - 55, 100, 40, 1);
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr == 27 | nr == 32)
        {
          windowReturnClass.AddCommand(1, 118);
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

    public override WindowReturnClass HandleMouseClickOutsideWindow(
      int x,
      int y,
      int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
      ScreenClass screeny = this.formref.Screeny;
      System.Type type = typeof (MapWindowClass2);
      ref System.Type local = ref type;
      MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
      if (!Information.IsNothing((object) window) & this.game.EditObj.UnitSelected > -1)
        window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
      windowReturnClass.AddCommand(1, 118);
      windowReturnClass.SetFlag(true);
      windowReturnClass.alwaysExecuteWR = true;
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
            int num = this.SubPartID[index1];
            if (num == this.cancelid)
            {
              this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
              ScreenClass screeny = this.formref.Screeny;
              System.Type type = typeof (MapWindowClass2);
              ref System.Type local = ref type;
              MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
              if (!Information.IsNothing((object) window))
              {
                if (this.game.EditObj.UnitSelected > -1)
                  window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                else
                  window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
              }
              windowReturnClass.AddCommand(1, 118);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.but1)
            {
              this.game.EditObj.udsUnitOrderMode = 0;
              ScreenClass screeny = this.formref.Screeny;
              System.Type type = typeof (MapWindowClass2);
              ref System.Type local = ref type;
              MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
              windowReturnClass.AddCommand(1, 118);
              if (!Information.IsNothing((object) window))
              {
                this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                if (this.game.EditObj.UnitSelected > -1)
                  window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                else
                  window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.but6)
            {
              this.game.EditObj.udsUnitOrderMode = 53;
              ScreenClass screeny = this.formref.Screeny;
              System.Type type = typeof (MapWindowClass2);
              ref System.Type local = ref type;
              MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
              windowReturnClass.AddCommand(1, 118);
              if (!Information.IsNothing((object) window))
              {
                this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                if (this.game.EditObj.UnitSelected > -1)
                  window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                else
                  window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.but8)
            {
              this.game.EditObj.udsUnitOrderMode = 54;
              this.game.EditObj.OrderSubType = this.zoneId;
              ScreenClass screeny = this.formref.Screeny;
              System.Type type = typeof (MapWindowClass2);
              ref System.Type local = ref type;
              MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
              windowReturnClass.AddCommand(1, 118);
              if (!Information.IsNothing((object) window))
              {
                this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                if (this.game.EditObj.UnitSelected > -1)
                  window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                else
                  window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.but2)
            {
              this.game.EditObj.udsUnitOrderMode = 1;
              ScreenClass screeny = this.formref.Screeny;
              System.Type type = typeof (MapWindowClass2);
              ref System.Type local = ref type;
              MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
              windowReturnClass.AddCommand(1, 118);
              if (!Information.IsNothing((object) window))
              {
                this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                if (this.game.EditObj.UnitSelected > -1)
                  window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                else
                  window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.but7)
            {
              this.game.EditObj.udsUnitOrderMode = 48;
              ScreenClass screeny = this.formref.Screeny;
              System.Type type = typeof (MapWindowClass2);
              ref System.Type local = ref type;
              MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
              windowReturnClass.AddCommand(1, 118);
              if (!Information.IsNothing((object) window))
              {
                this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                if (this.game.EditObj.UnitSelected > -1)
                  window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                else
                  window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.but3)
            {
              this.game.EditObj.udsUnitOrderMode = 18;
              ScreenClass screeny = this.formref.Screeny;
              System.Type type = typeof (MapWindowClass2);
              ref System.Type local = ref type;
              MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
              windowReturnClass.AddCommand(1, 118);
              if (!Information.IsNothing((object) window))
              {
                this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                if (this.game.EditObj.UnitSelected > -1)
                  window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                else
                  window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.but4)
            {
              this.game.EditObj.udsUnitOrderMode = 11;
              ScreenClass screeny = this.formref.Screeny;
              System.Type type = typeof (MapWindowClass2);
              ref System.Type local = ref type;
              MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
              windowReturnClass.AddCommand(1, 118);
              if (!Information.IsNothing((object) window))
              {
                this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                if (this.game.EditObj.UnitSelected > -1)
                  window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                else
                  window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.but9)
            {
              this.game.EditObj.udsUnitOrderMode = 14;
              ScreenClass screeny = this.formref.Screeny;
              System.Type type = typeof (MapWindowClass2);
              ref System.Type local = ref type;
              MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
              windowReturnClass.AddCommand(1, 118);
              if (!Information.IsNothing((object) window))
              {
                this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                if (this.game.EditObj.UnitSelected > -1)
                  window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                else
                  window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.but10)
            {
              this.game.EditObj.udsUnitOrderMode = 33;
              ScreenClass screeny = this.formref.Screeny;
              System.Type type = typeof (MapWindowClass2);
              ref System.Type local = ref type;
              MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
              windowReturnClass.AddCommand(1, 118);
              if (!Information.IsNothing((object) window))
              {
                this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                if (this.game.EditObj.UnitSelected > -1)
                  window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                else
                  window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.but11)
            {
              this.game.EditObj.udsUnitOrderMode = 55;
              ScreenClass screeny = this.formref.Screeny;
              System.Type type = typeof (MapWindowClass2);
              ref System.Type local = ref type;
              MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
              windowReturnClass.AddCommand(1, 118);
              if (!Information.IsNothing((object) window))
              {
                this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                if (this.game.EditObj.UnitSelected > -1)
                  window.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
                else
                  window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.but5)
            {
              int enr = (int) Math.Round((double) this.game.Data.RuleVar[705]);
              this.game.EditObj.UDSpopupText = "";
              this.game.EditObj.UDSAddInput("ROADCHOICE", 0);
              if (enr > 0)
                this.game.EventRelatedObj.DoCheckSpecificEvent(enr);
              if (this.game.EditObj.UDSpopupText.Length > 1)
              {
                this.game.EditObj.UDSpushedPopupText = this.game.EditObj.UDSpopupText;
                this.game.EditObj.UDSpopupText = "";
                windowReturnClass.AddCommand(1, 118);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              this.game.EditObj.udsUnitOrderMode = 36;
              ScreenClass screeny = this.formref.Screeny;
              System.Type type = typeof (MapWindowClass2);
              ref System.Type local = ref type;
              MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
              windowReturnClass.AddCommand(1, 118);
              if (!Information.IsNothing((object) window))
              {
                this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                window.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 68);
                windowReturnClass.AddCommand(4, 9);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            int udsButCounter = this.udsButCounter;
            for (int index2 = 0; index2 <= udsButCounter; ++index2)
            {
              if (this.udsBut[index2] == this.SubPartID[index1])
              {
                this.game.HandyFunctionsObj.UnitPopupUdsButtons_SetIO(this.SL.Data2[index2]);
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                int areaX = this.game.EditObj.AreaX;
                int areaY = this.game.EditObj.AreaY;
                this.game.EditObj.AreaX = this.game.SelectX;
                this.game.EditObj.AreaY = this.game.SelectY;
                this.game.EventRelatedObj.DoCheckSpecificEvent(this.SL.Data1[index2]);
                this.game.EditObj.AreaX = areaX;
                this.game.EditObj.AreaY = areaY;
                this.formref.Cursor = Cursors.Default;
                this.game.EditObj.UDSpushedPopupText = this.game.EditObj.UDSpopupText;
                this.game.EditObj.UDSpopupText = "";
                windowReturnClass.AddCommand(1, 118);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
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
