// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.PlayScreenClass2
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
  public class PlayScreenClass2 : ScreenClass
  {
    private int WMap;
    private int WPlay;
    private int WOrder;
    private int WRes;
    private int WTabs;
    private int WLeft;
    private int wRight;
    private int wAdvice;
    private int wOps;
    private int OffSetX;
    private int lastx;
    private int lasty;
    private int playExtraHeight;
    private int rightSideBarWidth;
    private int leftSideBarWidth;

    public PlayScreenClass2(ref GameClass tgame, Form1 tformref)
      : base(ref tgame, -3, tformref)
    {
      this.playExtraHeight = 222;
      this.rightSideBarWidth = 185;
      this.leftSideBarWidth = 185;
      if (this.Game.Data.Product == 6)
      {
        this.rightSideBarWidth = 320;
        this.leftSideBarWidth = 250;
        this.playExtraHeight = 150;
      }
      if (this.Game.Data.Product == 6 && this.Game.EditObj.SetViewMode2 == 7)
        this.Game.EditObj.SetViewMode2 = 0;
      if (this.Game.Data.Product >= 5)
      {
        this.Game.HandyFunctionsObj.RedimTempValue(9999);
        this.Game.HandyFunctionsObj.RedimTempLosValue(0);
        this.Game.HandyFunctionsObj.RedimTempValue(9999);
        this.Game.HandyFunctionsObj.RedimTempValueSpecial(0);
        this.Game.HandyFunctionsObj.RedimTempValueSpecial2(0);
        this.Game.HandyFunctionsObj.RedimTempValue2(0);
        this.Game.HandyFunctionsObj.RedimTempCameFrom();
        this.Game.HandyFunctionsObj.RedimTempAttack(false);
      }
      this.Game.HandyFunctionsObj.RedimTempValue3(9999);
      if ((double) this.Game.Data.RuleVar[701] > 0.0)
        this.Game.HandyFunctionsObj.RedimTempValue4(9999);
      this.OffSetX = (int) Math.Round((double) (this.Game.ScreenWidth - 1024) / 2.0);
      this.Game.HandyFunctionsObj.SetGameColors();
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (this.Game.EditObj.GuiDown)
      {
        if ((double) this.Game.Data.RuleVar[408] > 0.0)
        {
          if (this.Game.EditObj.RightDown)
          {
            MapWindowClass2 tmpWindow = new MapWindowClass2(ref tgame, tminwidth: 0);
            int screenWidth = this.Game.ScreenWidth;
            int h = this.Game.ScreenHeight - 0;
            Rectangle rectangle3 = new Rectangle(0, 75, this.Game.ScreenWidth, this.Game.ScreenHeight - 165);
            Rectangle tShowRectangle = rectangle3;
            this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, h, tShowRectangle);
            ref GameClass local1 = ref tgame;
            ref WindowClass local2 = ref this.WindowList[this.GetNr(this.WMap)];
            rectangle3 = new Rectangle(0, 0, this.Game.ScreenWidth, 75);
            rectangle1 = rectangle3;
            ref Rectangle local3 = ref rectangle1;
            this.WRes = this.AddWindow((WindowClass) new ResourceWindowClass2(ref local1, ref local2, ref local3), 0, 0, this.Game.ScreenWidth, 75);
            if (!this.Game.EditObj.LeftDown)
            {
              ref GameClass local4 = ref tgame;
              int theight = this.Game.ScreenHeight - 165;
              ref WindowClass local5 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle1 = new Rectangle(0, 75, this.leftSideBarWidth, this.Game.ScreenHeight - 165);
              rectangle2 = rectangle1;
              ref Rectangle local6 = ref rectangle2;
              this.WLeft = this.AddWindow((WindowClass) new LeftSideBar(ref local4, theight, ref local5, ref local6), 0, 75, this.leftSideBarWidth, this.Game.ScreenHeight - 165);
            }
          }
          else
          {
            MapWindowClass2 tmpWindow = new MapWindowClass2(ref tgame, tminwidth: 0);
            int screenWidth = this.Game.ScreenWidth;
            int h = this.Game.ScreenHeight - 0;
            rectangle1 = new Rectangle(0, 75, this.Game.ScreenWidth, this.Game.ScreenHeight - 165);
            Rectangle tShowRectangle = rectangle1;
            this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, h, tShowRectangle);
            ref GameClass local7 = ref tgame;
            ref WindowClass local8 = ref this.WindowList[this.GetNr(this.WMap)];
            rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, 75);
            Rectangle rectangle4 = rectangle1;
            ref Rectangle local9 = ref rectangle4;
            this.WRes = this.AddWindow((WindowClass) new ResourceWindowClass2(ref local7, ref local8, ref local9), 0, 0, this.Game.ScreenWidth, 75);
            ref GameClass local10 = ref tgame;
            int theight1 = this.Game.ScreenHeight - 165;
            ref WindowClass local11 = ref this.WindowList[this.GetNr(this.WMap)];
            rectangle1 = new Rectangle(0, 75, this.leftSideBarWidth, this.Game.ScreenHeight - 165);
            rectangle2 = rectangle1;
            ref Rectangle local12 = ref rectangle2;
            this.WLeft = this.AddWindow((WindowClass) new LeftSideBar(ref local10, theight1, ref local11, ref local12), 0, 75, this.leftSideBarWidth, this.Game.ScreenHeight - 165);
            ref GameClass local13 = ref tgame;
            int theight2 = this.Game.ScreenHeight - 165;
            ref WindowClass local14 = ref this.WindowList[this.GetNr(this.WMap)];
            rectangle1 = new Rectangle(this.Game.ScreenWidth - this.rightSideBarWidth, 75, this.rightSideBarWidth, this.Game.ScreenHeight - 165);
            rectangle2 = rectangle1;
            ref Rectangle local15 = ref rectangle2;
            this.wRight = this.AddWindow((WindowClass) new RightSideBar(ref local13, theight2, ref local14, ref local15), this.Game.ScreenWidth - this.rightSideBarWidth, 75, this.rightSideBarWidth, this.Game.ScreenHeight - 165);
          }
          if (!this.Game.EditObj.BlockAdvice & !this.Game.EditObj.TempBlockAdvice)
          {
            ref GameClass local16 = ref tgame;
            ref WindowClass local17 = ref this.WindowList[this.GetNr(this.WMap)];
            rectangle1 = new Rectangle(185, 75, 620, 240);
            rectangle2 = rectangle1;
            ref Rectangle local18 = ref rectangle2;
            this.wAdvice = this.AddWindow((WindowClass) new AdviceWindow(ref local16, ref local17, ref local18), this.rightSideBarWidth, 75, 620, 240);
          }
        }
        else
        {
          MapWindowClass2 tmpWindow = new MapWindowClass2(ref tgame, tminwidth: 0);
          int screenWidth = this.Game.ScreenWidth;
          int h = this.Game.ScreenHeight - 0;
          rectangle1 = new Rectangle(0, 75, this.Game.ScreenWidth, this.Game.ScreenHeight - 165);
          Rectangle tShowRectangle = rectangle1;
          this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, h, tShowRectangle);
          ref GameClass local19 = ref tgame;
          ref WindowClass local20 = ref this.WindowList[this.GetNr(this.WMap)];
          rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, 75);
          Rectangle rectangle5 = rectangle1;
          ref Rectangle local21 = ref rectangle5;
          this.WRes = this.AddWindow((WindowClass) new ResourceWindowClass2(ref local19, ref local20, ref local21), 0, 0, this.Game.ScreenWidth, 75);
          if (!this.Game.EditObj.LeftDown)
          {
            ref GameClass local22 = ref tgame;
            int theight = this.Game.ScreenHeight - 165;
            ref WindowClass local23 = ref this.WindowList[this.GetNr(this.WMap)];
            rectangle1 = new Rectangle(0, 75, this.leftSideBarWidth, this.Game.ScreenHeight - 165);
            rectangle2 = rectangle1;
            ref Rectangle local24 = ref rectangle2;
            this.WLeft = this.AddWindow((WindowClass) new LeftSideBar(ref local22, theight, ref local23, ref local24), 0, 75, this.leftSideBarWidth, this.Game.ScreenHeight - 165);
          }
          if (!this.Game.EditObj.RightDown)
          {
            ref GameClass local25 = ref tgame;
            int theight = this.Game.ScreenHeight - 165;
            ref WindowClass local26 = ref this.WindowList[this.GetNr(this.WMap)];
            rectangle1 = new Rectangle(this.Game.ScreenWidth - this.rightSideBarWidth, 75, this.rightSideBarWidth, this.Game.ScreenHeight - 165);
            rectangle2 = rectangle1;
            ref Rectangle local27 = ref rectangle2;
            this.wRight = this.AddWindow((WindowClass) new RightSideBar(ref local25, theight, ref local26, ref local27), this.Game.ScreenWidth - this.rightSideBarWidth, 75, this.rightSideBarWidth, this.Game.ScreenHeight - 165);
          }
        }
        if ((double) this.Game.Data.RuleVar[408] > 0.0)
        {
          ref GameClass local28 = ref tgame;
          ref WindowClass local29 = ref this.WindowList[this.GetNr(this.WMap)];
          rectangle1 = new Rectangle(0, this.Game.ScreenHeight - 90, this.Game.ScreenWidth, 90);
          rectangle2 = rectangle1;
          ref Rectangle local30 = ref rectangle2;
          this.WOrder = this.AddWindow((WindowClass) new UdsOrderWindowClass(ref local28, ref local29, ref local30), 0, this.Game.ScreenHeight - 90, this.Game.ScreenWidth, 90);
        }
        else
        {
          ref GameClass local31 = ref tgame;
          ref WindowClass local32 = ref this.WindowList[this.GetNr(this.WMap)];
          rectangle1 = new Rectangle(0, this.Game.ScreenHeight - 90, this.Game.ScreenWidth, 90);
          rectangle2 = rectangle1;
          ref Rectangle local33 = ref rectangle2;
          this.WOrder = this.AddWindow((WindowClass) new OrderWindowClass2(ref local31, ref local32, ref local33), 0, this.Game.ScreenHeight - 90, this.Game.ScreenWidth, 90);
        }
        this.WPlay = -1;
      }
      else
      {
        if ((double) this.Game.Data.RuleVar[408] > 0.0)
        {
          MapWindowClass2 tmpWindow = new MapWindowClass2(ref tgame, this.playExtraHeight, 0);
          int screenWidth = this.Game.ScreenWidth;
          int h = this.Game.ScreenHeight - this.playExtraHeight;
          rectangle1 = new Rectangle(0, 75, this.Game.ScreenWidth, this.Game.ScreenHeight - (165 + this.playExtraHeight));
          Rectangle tShowRectangle = rectangle1;
          this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, h, tShowRectangle);
          ref GameClass local34 = ref tgame;
          ref WindowClass local35 = ref this.WindowList[this.GetNr(this.WMap)];
          rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, 75);
          Rectangle rectangle6 = rectangle1;
          ref Rectangle local36 = ref rectangle6;
          this.WRes = this.AddWindow((WindowClass) new ResourceWindowClass2(ref local34, ref local35, ref local36), 0, 0, this.Game.ScreenWidth, 75);
          ref GameClass local37 = ref tgame;
          int theight3 = this.Game.ScreenHeight - (165 + this.playExtraHeight);
          ref WindowClass local38 = ref this.WindowList[this.GetNr(this.WMap)];
          rectangle1 = new Rectangle(0, 75, this.leftSideBarWidth, this.Game.ScreenHeight - (165 + this.playExtraHeight));
          rectangle2 = rectangle1;
          ref Rectangle local39 = ref rectangle2;
          this.WLeft = this.AddWindow((WindowClass) new LeftSideBar(ref local37, theight3, ref local38, ref local39), 0, 75, this.leftSideBarWidth, this.Game.ScreenHeight - (165 + this.playExtraHeight));
          if (!this.Game.EditObj.RightDown)
          {
            ref GameClass local40 = ref tgame;
            int theight4 = this.Game.ScreenHeight - (165 + this.playExtraHeight);
            ref WindowClass local41 = ref this.WindowList[this.GetNr(this.WMap)];
            rectangle1 = new Rectangle(this.Game.ScreenWidth - this.rightSideBarWidth, 75, this.rightSideBarWidth, this.Game.ScreenHeight - (165 + this.playExtraHeight));
            rectangle2 = rectangle1;
            ref Rectangle local42 = ref rectangle2;
            this.wRight = this.AddWindow((WindowClass) new RightSideBar(ref local40, theight4, ref local41, ref local42), this.Game.ScreenWidth - this.rightSideBarWidth, 75, this.rightSideBarWidth, this.Game.ScreenHeight - (165 + this.playExtraHeight));
          }
          if (!this.Game.EditObj.BlockAdvice & !this.Game.EditObj.TempBlockAdvice)
          {
            ref GameClass local43 = ref tgame;
            ref WindowClass local44 = ref this.WindowList[this.GetNr(this.WMap)];
            rectangle1 = new Rectangle(185, 75, 820, 240);
            rectangle2 = rectangle1;
            ref Rectangle local45 = ref rectangle2;
            this.wAdvice = this.AddWindow((WindowClass) new AdviceWindow(ref local43, ref local44, ref local45), 185, 75, 820, 240);
          }
        }
        else
        {
          MapWindowClass2 tmpWindow = new MapWindowClass2(ref tgame, this.playExtraHeight, 0);
          int screenWidth = this.Game.ScreenWidth;
          int h = this.Game.ScreenHeight - this.playExtraHeight;
          rectangle1 = new Rectangle(0, 75, this.Game.ScreenWidth, this.Game.ScreenHeight - (165 + this.playExtraHeight));
          Rectangle tShowRectangle = rectangle1;
          this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, h, tShowRectangle);
          ref GameClass local46 = ref tgame;
          ref WindowClass local47 = ref this.WindowList[this.GetNr(this.WMap)];
          rectangle1 = new Rectangle(0, 0, this.Game.ScreenWidth, 75);
          Rectangle rectangle7 = rectangle1;
          ref Rectangle local48 = ref rectangle7;
          this.WRes = this.AddWindow((WindowClass) new ResourceWindowClass2(ref local46, ref local47, ref local48), 0, 0, this.Game.ScreenWidth, 75);
          if (!this.Game.EditObj.LeftDown & this.Game.Data.Product >= 6)
          {
            ref GameClass local49 = ref tgame;
            int theight = this.Game.ScreenHeight - (165 + this.playExtraHeight);
            ref WindowClass local50 = ref this.WindowList[this.GetNr(this.WMap)];
            rectangle1 = new Rectangle(0, 75, this.leftSideBarWidth, this.Game.ScreenHeight - (165 + this.playExtraHeight));
            rectangle2 = rectangle1;
            ref Rectangle local51 = ref rectangle2;
            this.WLeft = this.AddWindow((WindowClass) new LeftSideBar(ref local49, theight, ref local50, ref local51), 0, 75, this.leftSideBarWidth, this.Game.ScreenHeight - (165 + this.playExtraHeight));
          }
          if (!this.Game.EditObj.RightDown & this.Game.Data.Product >= 6)
          {
            ref GameClass local52 = ref tgame;
            int theight = this.Game.ScreenHeight - (165 + this.playExtraHeight);
            ref WindowClass local53 = ref this.WindowList[this.GetNr(this.WMap)];
            rectangle1 = new Rectangle(this.Game.ScreenWidth - this.rightSideBarWidth, 75, this.rightSideBarWidth, this.Game.ScreenHeight - (165 + this.playExtraHeight));
            rectangle2 = rectangle1;
            ref Rectangle local54 = ref rectangle2;
            this.wRight = this.AddWindow((WindowClass) new RightSideBar(ref local52, theight, ref local53, ref local54), this.Game.ScreenWidth - this.rightSideBarWidth, 75, this.rightSideBarWidth, this.Game.ScreenHeight - (165 + this.playExtraHeight));
          }
        }
        if ((double) this.Game.Data.RuleVar[408] > 0.0)
        {
          ref GameClass local55 = ref tgame;
          ref WindowClass local56 = ref this.WindowList[this.GetNr(this.WMap)];
          rectangle1 = new Rectangle(0, this.Game.ScreenHeight - 312, this.Game.ScreenWidth, 90);
          rectangle2 = rectangle1;
          ref Rectangle local57 = ref rectangle2;
          this.WOrder = this.AddWindow((WindowClass) new UdsOrderWindowClass(ref local55, ref local56, ref local57), 0, this.Game.ScreenHeight - 312, this.Game.ScreenWidth, 90);
        }
        else
        {
          ref GameClass local58 = ref tgame;
          ref WindowClass local59 = ref this.WindowList[this.GetNr(this.WMap)];
          rectangle1 = new Rectangle(0, this.Game.ScreenHeight - (90 + this.playExtraHeight), this.Game.ScreenWidth, 90);
          rectangle2 = rectangle1;
          ref Rectangle local60 = ref rectangle2;
          this.WOrder = this.AddWindow((WindowClass) new OrderWindowClass2(ref local58, ref local59, ref local60), 0, this.Game.ScreenHeight - (90 + this.playExtraHeight), this.Game.ScreenWidth, 90);
        }
        this.WPlay = !(this.Game.EditObj.OrderType == 51 | this.Game.EditObj.LayerSupplyOn) ? this.AddWindow((WindowClass) new PlayExtraWindowClass2(ref tgame), 0, this.Game.ScreenHeight - this.playExtraHeight, this.Game.ScreenWidth, this.playExtraHeight) : this.AddWindow((WindowClass) new SupplyLayerWindowClass(ref tgame), 0, this.Game.ScreenHeight - this.playExtraHeight, this.Game.ScreenWidth, this.playExtraHeight);
      }
      Rectangle rectForTab;
      if (this.Game.EditObj.SetViewMode2 == 1)
      {
        rectForTab = DrawMod.GetRectForTab(1);
        ref GameClass local61 = ref tgame;
        ref WindowClass local62 = ref this.WindowList[this.GetNr(this.WMap)];
        rectangle1 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
        rectangle2 = rectangle1;
        ref Rectangle local63 = ref rectangle2;
        Rectangle trect = rectForTab;
        this.WTabs = this.AddWindow((WindowClass) new TabBriefingWindowClass2(ref local61, ref local62, ref local63, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      }
      if (this.Game.EditObj.SetViewMode2 == 2)
      {
        rectForTab = DrawMod.GetRectForTab(2);
        ref GameClass local64 = ref tgame;
        ref WindowClass local65 = ref this.WindowList[this.GetNr(this.WMap)];
        rectangle1 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
        rectangle2 = rectangle1;
        ref Rectangle local66 = ref rectangle2;
        Rectangle trect = rectForTab;
        this.WTabs = this.AddWindow((WindowClass) new TabStatsWindowClass2(ref local64, ref local65, ref local66, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      }
      if (this.Game.EditObj.SetViewMode2 == 3)
      {
        rectForTab = DrawMod.GetRectForTab(3);
        ref GameClass local67 = ref tgame;
        ref WindowClass local68 = ref this.WindowList[this.GetNr(this.WMap)];
        rectangle1 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
        rectangle2 = rectangle1;
        ref Rectangle local69 = ref rectangle2;
        Rectangle trect = rectForTab;
        this.WTabs = this.AddWindow((WindowClass) new TabOOBWindowClass2(ref local67, ref local68, ref local69, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      }
      if (this.Game.EditObj.SetViewMode2 == 4)
      {
        rectForTab = DrawMod.GetRectForTab(4);
        ref GameClass local70 = ref tgame;
        ref WindowClass local71 = ref this.WindowList[this.GetNr(this.WMap)];
        rectangle1 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
        rectangle2 = rectangle1;
        ref Rectangle local72 = ref rectangle2;
        Rectangle trect = rectForTab;
        this.WTabs = this.AddWindow((WindowClass) new TabReportsWindowClass2(ref local70, ref local71, ref local72, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      }
      if (this.Game.EditObj.SetViewMode2 == 5)
      {
        rectForTab = DrawMod.GetRectForTab(5);
        ref GameClass local73 = ref tgame;
        ref WindowClass local74 = ref this.WindowList[this.GetNr(this.WMap)];
        rectangle1 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
        rectangle2 = rectangle1;
        ref Rectangle local75 = ref rectangle2;
        Rectangle trect = rectForTab;
        this.WTabs = this.AddWindow((WindowClass) new TabCardsWindowClass2(ref local73, ref local74, ref local75, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      }
      if (this.Game.EditObj.SetViewMode2 == 6)
      {
        rectForTab = DrawMod.GetRectForTab(6);
        ref GameClass local76 = ref tgame;
        ref WindowClass local77 = ref this.WindowList[this.GetNr(this.WMap)];
        rectangle1 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
        rectangle2 = rectangle1;
        ref Rectangle local78 = ref rectangle2;
        Rectangle trect = rectForTab;
        this.WTabs = this.AddWindow((WindowClass) new TabSMapWindowClass2(ref local76, ref local77, ref local78, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      }
      if (this.Game.EditObj.SetViewMode2 == 7)
      {
        rectForTab = DrawMod.GetRectForTab(7);
        ref GameClass local79 = ref tgame;
        ref WindowClass local80 = ref this.WindowList[this.GetNr(this.WMap)];
        rectangle1 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
        rectangle2 = rectangle1;
        ref Rectangle local81 = ref rectangle2;
        Rectangle trect = rectForTab;
        this.WTabs = this.AddWindow((WindowClass) new TabMiniMapWindowClass2(ref local79, ref local80, ref local81, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      }
      if (this.Game.EditObj.SetViewMode2 == 8)
      {
        rectForTab = DrawMod.GetRectForTab(8);
        ref GameClass local82 = ref tgame;
        ref WindowClass local83 = ref this.WindowList[this.GetNr(this.WMap)];
        rectangle1 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
        rectangle2 = rectangle1;
        ref Rectangle local84 = ref rectangle2;
        Rectangle trect = rectForTab;
        this.WTabs = this.AddWindow((WindowClass) new TabPrefsWindowClass2(ref local82, ref local83, ref local84, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      }
      if (this.Game.EditObj.SetViewMode2 == 9)
      {
        rectForTab = DrawMod.GetRectForTab(9);
        ref GameClass local85 = ref tgame;
        ref WindowClass local86 = ref this.WindowList[this.GetNr(this.WMap)];
        rectangle1 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
        rectangle2 = rectangle1;
        ref Rectangle local87 = ref rectangle2;
        Rectangle trect = rectForTab;
        this.WTabs = this.AddWindow((WindowClass) new TabHelpWindowClass2(ref local85, ref local86, ref local87, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      }
      if (!(this.Game.EditObj.SetViewMode2 >= 11 & this.Game.EditObj.SetViewMode2 <= 13))
        return;
      rectForTab = DrawMod.GetRectForTab(this.Game.EditObj.SetViewMode2);
      ref GameClass local88 = ref tgame;
      ref WindowClass local89 = ref this.WindowList[this.GetNr(this.WMap)];
      rectangle1 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
      rectangle2 = rectangle1;
      ref Rectangle local90 = ref rectangle2;
      Rectangle trect1 = rectForTab;
      this.WTabs = this.AddWindow((WindowClass) new TabManagementWindowClass2(ref local88, ref local89, ref local90, trect1), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
    }

    public ScreenReturnClass HandleWR(
      WindowReturnClass wr,
      bool setflag,
      ref ScreenReturnClass obj)
    {
      if (wr.Counter > -1)
      {
        int counter = wr.Counter;
        for (int index1 = 0; index1 <= counter; ++index1)
        {
          if (wr.CommandType[index1] == 3)
          {
            obj.NewScreen = wr.CommandData[index1];
            return obj;
          }
          if (wr.CommandType[index1] == 5)
          {
            obj.OpenPopUp = true;
            obj.NewScreen = wr.CommandData[index1];
            return obj;
          }
          if (wr.CommandType[index1] == 6)
          {
            obj.ClosePopUp = true;
            obj.NewScreen = 0;
            return obj;
          }
          if (wr.CommandType[index1] == 4)
          {
            if (wr.CommandData[index1] == 69 & this.WPlay > -1)
            {
              this.WindowList[this.GetNr(this.WPlay)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WPlay)] = true;
            }
            if (wr.CommandData[index1] == 87 & this.WPlay > -1)
            {
              this.WindowList[this.GetNr(this.WPlay)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WPlay)] = true;
            }
            if (wr.CommandData[index1] == 88 & this.WPlay > -1)
            {
              this.WindowList[this.GetNr(this.WPlay)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WPlay)] = true;
            }
            if (wr.CommandData[index1] == 90 & this.WPlay > -1)
            {
              this.WindowList[this.GetNr(this.WPlay)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WPlay)] = true;
            }
            if (wr.CommandData[index1] == 89 & this.WPlay > -1)
            {
              this.WindowList[this.GetNr(this.WPlay)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WPlay)] = true;
            }
            if (wr.CommandData[index1] == 12)
            {
              this.WindowList[this.GetNr(this.WMap)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WMap)] = true;
            }
            if (wr.CommandData[index1] == 68)
            {
              this.WindowList[this.GetNr(this.WOrder)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WOrder)] = true;
            }
            if (wr.CommandData[index1] == 3 & this.wRight > 0)
            {
              this.WindowList[this.GetNr(this.wRight)].DoRefresh();
              this.WindowFlag[this.GetNr(this.wRight)] = true;
            }
            if (wr.CommandData[index1] == 2 & this.WLeft > 0)
            {
              this.WindowList[this.GetNr(this.wRight)].DoRefresh();
              this.WindowFlag[this.GetNr(this.wRight)] = true;
            }
            if (wr.CommandData[index1] == 67)
            {
              this.WindowList[this.GetNr(this.WRes)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WRes)] = true;
              if (this.WLeft > 0)
              {
                this.WindowList[this.GetNr(this.WLeft)].DoRefresh();
                this.WindowFlag[this.GetNr(this.WLeft)] = true;
              }
              if (this.wRight > 0)
              {
                this.WindowList[this.GetNr(this.wRight)].DoRefresh();
                this.WindowFlag[this.GetNr(this.wRight)] = true;
              }
              if (this.wAdvice > 0 & this.Game.EditObj.SetViewMode2 < 1)
              {
                this.WindowList[this.GetNr(this.wAdvice)].DoRefresh();
                this.WindowFlag[this.GetNr(this.wAdvice)] = true;
              }
            }
            if (wr.CommandData[index1] == 9 & this.WTabs > 0)
            {
              this.WindowList[this.GetNr(this.WTabs)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WTabs)] = true;
            }
            if (wr.CommandData[index1] == 35 & this.WPlay > -1)
            {
              this.WindowList[this.GetNr(this.WPlay)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WPlay)] = true;
            }
          }
          if (wr.CommandType[index1] == 7)
          {
            this.WindowFlag[this.GetNr(this.WMap)] = true;
            if (this.WLeft > 0)
            {
              this.WindowList[this.GetNr(this.WLeft)].DoRefresh();
              this.WindowFlag[this.GetNr(this.WLeft)] = true;
            }
            if (this.wRight > 0)
            {
              this.WindowList[this.GetNr(this.wRight)].DoRefresh();
              this.WindowFlag[this.GetNr(this.wRight)] = true;
            }
            if (this.wAdvice > 0)
            {
              this.WindowList[this.GetNr(this.wAdvice)].DoRefresh();
              this.WindowFlag[this.GetNr(this.wAdvice)] = true;
            }
          }
          if (wr.CommandType[index1] == 1)
          {
            if (wr.CommandData[index1] == 12)
            {
              this.RemoveWindow(this.WMap);
              this.WMap = 0;
            }
            if (wr.CommandData[index1] == 67)
            {
              this.RemoveWindow(this.WRes);
              this.WRes = 0;
            }
            if (wr.CommandData[index1] == 69 | wr.CommandData[index1] == 5)
            {
              this.RemoveWindow(this.WPlay);
              this.WPlay = 0;
            }
            if (wr.CommandData[index1] == 68)
            {
              this.RemoveWindow(this.WOrder);
              this.WOrder = 0;
            }
            if (wr.CommandData[index1] == 119 & this.wAdvice > 0)
            {
              this.RemoveWindow(this.wAdvice);
              this.wAdvice = 0;
            }
            if (wr.CommandData[index1] == 118)
            {
              int windowCounter = this.WindowCounter;
              for (int index2 = 0; index2 <= windowCounter; ++index2)
                this.WindowInputBlock[index2] = false;
              this.RemoveWindow(this.wOps);
              this.wOps = 0;
            }
            if (wr.CommandData[index1] == 9)
            {
              this.RemoveWindow(this.WTabs);
              this.WTabs = 0;
              this.WTabs = 0;
            }
          }
          if (wr.CommandType[index1] == 2)
          {
            Rectangle rectangle1;
            Rectangle rectangle2;
            if (wr.CommandData[index1] == 119 && !this.Game.EditObj.BlockAdvice & !this.Game.EditObj.TempBlockAdvice)
            {
              ref GameClass local1 = ref DrawMod.TGame;
              ref WindowClass local2 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle1 = new Rectangle(185, 75, 820, 240);
              rectangle2 = rectangle1;
              ref Rectangle local3 = ref rectangle2;
              this.wAdvice = this.AddWindow((WindowClass) new AdviceWindow(ref local1, ref local2, ref local3), 185, 75, 820, 240);
            }
            if (wr.CommandData[index1] == 12)
            {
              if (this.Game.EditObj.GuiDown)
              {
                MapWindowClass2 tmpWindow = new MapWindowClass2(ref DrawMod.TGame, tminwidth: 0);
                int screenWidth = this.Game.ScreenWidth;
                int h = this.Game.ScreenHeight - 0;
                rectangle2 = new Rectangle(0, 75, this.Game.ScreenWidth, this.Game.ScreenHeight - 165);
                Rectangle tShowRectangle = rectangle2;
                this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, h, tShowRectangle);
              }
              else
              {
                MapWindowClass2 tmpWindow = new MapWindowClass2(ref DrawMod.TGame, this.playExtraHeight, 0);
                int screenWidth = this.Game.ScreenWidth;
                int h = this.Game.ScreenHeight - this.playExtraHeight;
                rectangle2 = new Rectangle(0, 75, this.Game.ScreenWidth, this.Game.ScreenHeight - (165 + this.playExtraHeight));
                Rectangle tShowRectangle = rectangle2;
                this.WMap = this.AddWindow((WindowClass) tmpWindow, 0, 0, screenWidth, h, tShowRectangle);
              }
              if (this.WRes > 0)
                this.WindowList[this.GetNr(this.WRes)].LowerWindow = this.WindowList[this.GetNr(this.WMap)];
              if (this.WOrder > 0)
                this.WindowList[this.GetNr(this.WOrder)].LowerWindow = this.WindowList[this.GetNr(this.WMap)];
              if (this.WTabs > 0)
                this.WindowList[this.GetNr(this.WTabs)].LowerWindow = this.WindowList[this.GetNr(this.WMap)];
              if (this.wRight > 0)
                this.WindowList[this.GetNr(this.wRight)].LowerWindow = this.WindowList[this.GetNr(this.WMap)];
              if (this.WLeft > 0)
                this.WindowList[this.GetNr(this.WLeft)].LowerWindow = this.WindowList[this.GetNr(this.WMap)];
              if (this.wAdvice > 0)
                this.WindowList[this.GetNr(this.wAdvice)].LowerWindow = this.WindowList[this.GetNr(this.WMap)];
            }
            if (wr.CommandData[index1] == 118)
            {
              int num1 = this.Game.ScreenHeight - (165 + this.playExtraHeight);
              if (this.Game.EditObj.GuiDown)
                num1 = this.Game.ScreenHeight - 165;
              int x = this.FormRef.LastMouseX - 120;
              int y = this.FormRef.LastMouseY <= 375 ? this.FormRef.LastMouseY : this.FormRef.LastMouseY - 300;
              if (x < 100)
                x = 100;
              if (x > this.Game.ScreenWidth - 350)
                x = this.Game.ScreenWidth - 350;
              int windowCounter = this.WindowCounter;
              for (int index3 = 0; index3 <= windowCounter; ++index3)
                this.WindowInputBlock[index3] = true;
              int num2 = 340;
              if (this.Game.Data.Product == 7 && this.Game.EventRelatedObj.Helper_AirEnabled())
                num2 = 430;
              ref GameClass local4 = ref DrawMod.TGame;
              ref WindowClass local5 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(x, y, 200, num2);
              rectangle1 = rectangle2;
              ref Rectangle local6 = ref rectangle1;
              ref int local7 = ref num2;
              this.wOps = this.AddWindow((WindowClass) new UdsUnitOpsWindowClass(ref local4, ref local5, ref local6, ref local7), x, y, 200, num2);
            }
            if (wr.CommandData[index1] == 67)
            {
              ref GameClass local8 = ref DrawMod.TGame;
              ref WindowClass local9 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(0, 0, this.Game.ScreenWidth, 75);
              rectangle1 = rectangle2;
              ref Rectangle local10 = ref rectangle1;
              this.WRes = this.AddWindow((WindowClass) new ResourceWindowClass2(ref local8, ref local9, ref local10), 0, 0, this.Game.ScreenWidth, 75);
            }
            Rectangle rectForTab;
            if (wr.CommandData[index1] == 70)
            {
              rectForTab = DrawMod.GetRectForTab(1);
              ref GameClass local11 = ref DrawMod.TGame;
              ref WindowClass local12 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local13 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabBriefingWindowClass2(ref local11, ref local12, ref local13, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index1] == 71)
            {
              rectForTab = DrawMod.GetRectForTab(2);
              ref GameClass local14 = ref DrawMod.TGame;
              ref WindowClass local15 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local16 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabStatsWindowClass2(ref local14, ref local15, ref local16, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index1] == 113)
            {
              rectForTab = DrawMod.GetRectForTab(this.Game.EditObj.SetViewMode2);
              ref GameClass local17 = ref DrawMod.TGame;
              ref WindowClass local18 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local19 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabManagementWindowClass2(ref local17, ref local18, ref local19, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index1] == 72)
            {
              rectForTab = DrawMod.GetRectForTab(3);
              ref GameClass local20 = ref DrawMod.TGame;
              ref WindowClass local21 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local22 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabOOBWindowClass2(ref local20, ref local21, ref local22, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index1] == 73)
            {
              rectForTab = DrawMod.GetRectForTab(4);
              ref GameClass local23 = ref DrawMod.TGame;
              ref WindowClass local24 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local25 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabReportsWindowClass2(ref local23, ref local24, ref local25, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index1] == 74)
            {
              rectForTab = DrawMod.GetRectForTab(5);
              ref GameClass local26 = ref DrawMod.TGame;
              ref WindowClass local27 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local28 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabCardsWindowClass2(ref local26, ref local27, ref local28, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index1] == 75)
            {
              rectForTab = DrawMod.GetRectForTab(6);
              ref GameClass local29 = ref DrawMod.TGame;
              ref WindowClass local30 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local31 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabSMapWindowClass2(ref local29, ref local30, ref local31, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index1] == 76)
            {
              rectForTab = DrawMod.GetRectForTab(7);
              ref GameClass local32 = ref DrawMod.TGame;
              ref WindowClass local33 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local34 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabMiniMapWindowClass2(ref local32, ref local33, ref local34, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index1] == 77)
            {
              rectForTab = DrawMod.GetRectForTab(8);
              ref GameClass local35 = ref DrawMod.TGame;
              ref WindowClass local36 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local37 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabPrefsWindowClass2(ref local35, ref local36, ref local37, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index1] == 110)
            {
              rectForTab = DrawMod.GetRectForTab(9);
              ref GameClass local38 = ref DrawMod.TGame;
              ref WindowClass local39 = ref this.WindowList[this.GetNr(this.WMap)];
              rectangle2 = new Rectangle(rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
              rectangle1 = rectangle2;
              ref Rectangle local40 = ref rectangle1;
              Rectangle trect = rectForTab;
              this.WTabs = this.AddWindow((WindowClass) new TabHelpWindowClass2(ref local38, ref local39, ref local40, trect), rectForTab.X, rectForTab.Y, rectForTab.Width, rectForTab.Height);
            }
            if (wr.CommandData[index1] == 35)
              this.WPlay = this.AddWindow((WindowClass) new StrategicWindowClass2(ref DrawMod.TGame), 0, this.Game.ScreenHeight - this.playExtraHeight, this.Game.ScreenWidth, this.playExtraHeight);
            if (wr.CommandData[index1] == 69)
              this.WPlay = this.AddWindow((WindowClass) new PlayExtraWindowClass2(ref DrawMod.TGame), 0, this.Game.ScreenHeight - this.playExtraHeight, this.Game.ScreenWidth, this.playExtraHeight);
            if (wr.CommandData[index1] == 87)
              this.WPlay = this.AddWindow((WindowClass) new OfficerPoolWindowClass2(ref DrawMod.TGame), 0, this.Game.ScreenHeight - this.playExtraHeight, this.Game.ScreenWidth, this.playExtraHeight);
            if (wr.CommandData[index1] == 88)
              this.WPlay = this.AddWindow((WindowClass) new NewUnitWindowClass2(ref DrawMod.TGame), 0, this.Game.ScreenHeight - this.playExtraHeight, this.Game.ScreenWidth, this.playExtraHeight);
            if (wr.CommandData[index1] == 121)
              this.WPlay = this.AddWindow((WindowClass) new SupplyLayerWindowClass(ref DrawMod.TGame), 0, this.Game.ScreenHeight - this.playExtraHeight, this.Game.ScreenWidth, this.playExtraHeight);
            if (wr.CommandData[index1] == 90)
              this.WPlay = this.AddWindow((WindowClass) new ChangeModelWindowClass2(ref DrawMod.TGame), 0, this.Game.ScreenHeight - this.playExtraHeight, this.Game.ScreenWidth, this.playExtraHeight);
            if (wr.CommandData[index1] == 89)
              this.WPlay = this.AddWindow((WindowClass) new NewUnit2WindowClass2(ref DrawMod.TGame), 0, this.Game.ScreenHeight - this.playExtraHeight, this.Game.ScreenWidth, this.playExtraHeight);
          }
        }
      }
      if (setflag)
        obj.flag = wr.Flag;
      else if (wr.Flag)
        obj.flag = wr.Flag;
      ScreenReturnClass screenReturnClass;
      return screenReturnClass;
    }

    public override ScreenReturnClass HandleMouseClick(int x, int y, int b)
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (this.Game.Data.Product < 6)
      {
        if (x > this.Game.ScreenWidth - 52 & x < this.Game.ScreenWidth - 28 & y < 25)
          this.Game.FormRef.WindowState = FormWindowState.Minimized;
        if (x > this.Game.ScreenWidth - 28 & x < this.Game.ScreenWidth - 4 & y < 25 && Interaction.MsgBox((object) "Are you sure you want to exit your current game?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
        {
          this.Game.Data = new DataClass();
          this.Game.EditObj = new EditClass(this.Game.AppPath + "editobj.txt");
          if (this.Game.Data.UseAI == 1)
          {
            if (Information.IsNothing((object) this.Game.NewAIObj))
              this.Game.NewAIObj = new NewAIClass(this.Game);
            this.Game.NewAIObj.LastRegime = -1;
          }
          this.Game.EditObj.ShowInitialMenu = true;
          screenReturnClass.NewScreen = 12;
          return screenReturnClass;
        }
      }
      if (this.WindowCounter > -1)
      {
        for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
        {
          if (Operators.CompareString(this.WindowList[windowCounter].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) != 0 & !this.WindowInputBlock[windowCounter])
          {
            bool flag = false;
            if (x > this.WindowX[windowCounter] & x < this.WindowX[windowCounter] + this.WindowW[windowCounter] && y > this.WindowY[windowCounter] & y < this.WindowY[windowCounter] + this.WindowH[windowCounter])
            {
              flag = true;
              WindowReturnClass wr = this.WindowList[windowCounter].HandleMouseClick(x - this.WindowX[windowCounter], y - this.WindowY[windowCounter], b);
              this.WindowFlag[windowCounter] = wr.Flag;
              if (wr.Flag)
              {
                this.HandleWR(wr, true, ref screenReturnClass);
                return screenReturnClass;
              }
              if (wr.NoMouseClickBelow)
              {
                screenReturnClass.flag = false;
                return screenReturnClass;
              }
            }
            if (!flag)
            {
              WindowReturnClass wr = this.WindowList[windowCounter].HandleMouseClickOutsideWindow(x - this.WindowX[windowCounter], y - this.WindowY[windowCounter], b);
              if (wr.Flag | wr.alwaysExecuteWR)
              {
                this.HandleWR(wr, true, ref screenReturnClass);
                screenReturnClass.flag = true;
                return screenReturnClass;
              }
            }
          }
        }
        for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
        {
          if (Operators.CompareString(this.WindowList[windowCounter].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) == 0 & !this.WindowInputBlock[windowCounter])
          {
            bool flag = false;
            if (x > this.WindowX[windowCounter] & x < this.WindowX[windowCounter] + this.WindowW[windowCounter] && y > this.WindowY[windowCounter] & y < this.WindowY[windowCounter] + this.WindowH[windowCounter])
            {
              flag = true;
              WindowReturnClass wr = this.WindowList[windowCounter].HandleMouseClick(x - this.WindowX[windowCounter], y - this.WindowY[windowCounter], b);
              this.WindowFlag[windowCounter] = wr.Flag;
              if (wr.Flag | wr.alwaysExecuteWR)
              {
                this.HandleWR(wr, true, ref screenReturnClass);
                screenReturnClass.flag = true;
                return screenReturnClass;
              }
              if (wr.NoMouseClickBelow)
              {
                screenReturnClass.flag = false;
                return screenReturnClass;
              }
            }
            if (!flag)
            {
              WindowReturnClass wr = this.WindowList[windowCounter].HandleMouseClickOutsideWindow(x - this.WindowX[windowCounter], y - this.WindowY[windowCounter], b);
              this.WindowFlag[windowCounter] = wr.Flag;
              if (wr.Flag | wr.alwaysExecuteWR)
              {
                this.HandleWR(wr, true, ref screenReturnClass);
                screenReturnClass.flag = true;
                return screenReturnClass;
              }
            }
          }
        }
        screenReturnClass.flag = false;
        return screenReturnClass;
      }
      screenReturnClass.flag = false;
      return screenReturnClass;
    }

    public override ScreenReturnClass HandleMouseUp(int x, int y, int b)
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (this.WindowCounter > -1)
      {
        for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
        {
          if (x > this.WindowX[windowCounter] & x < this.WindowX[windowCounter] + this.WindowW[windowCounter] & !this.WindowInputBlock[windowCounter] && y > this.WindowY[windowCounter] & y < this.WindowY[windowCounter] + this.WindowH[windowCounter] && !Information.IsNothing((object) this.WindowList[windowCounter]))
          {
            WindowReturnClass wr = this.WindowList[windowCounter].HandleMouseUp(x - this.WindowX[windowCounter], y - this.WindowY[windowCounter], b);
            this.WindowFlag[windowCounter] = wr.Flag;
            if (wr.Flag)
            {
              this.HandleWR(wr, true, ref screenReturnClass);
              return screenReturnClass;
            }
            if (wr.NoMouseClickBelow)
            {
              screenReturnClass.flag = false;
              return screenReturnClass;
            }
          }
        }
        screenReturnClass.flag = false;
        return screenReturnClass;
      }
      screenReturnClass.flag = false;
      return screenReturnClass;
    }

    public override ScreenReturnClass HandleMouseMove(int x, int y)
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (x > this.Game.ScreenWidth - 52 & x < this.Game.ScreenWidth - 28 & y < 25)
      {
        if (!this.doMinimize)
        {
          this.doMinimize = true;
          screenReturnClass.flag = true;
        }
      }
      else if (this.doMinimize)
      {
        this.doMinimize = false;
        screenReturnClass.flag = true;
      }
      if (x > this.Game.ScreenWidth - 28 & x < this.Game.ScreenWidth - 4 & y < 25)
      {
        if (!this.doQuit)
        {
          this.doQuit = true;
          screenReturnClass.flag = true;
        }
      }
      else if (this.doQuit)
      {
        this.doQuit = false;
        screenReturnClass.flag = true;
      }
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      int num1 = -1;
      for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
      {
        if (!Information.IsNothing((object) this.WindowList[windowCounter]))
        {
          this.WindowList[windowCounter].MouseInThisWindow = false;
          if (x >= this.WindowX[windowCounter] & x < this.WindowX[windowCounter] + this.WindowW[windowCounter] && y >= this.WindowY[windowCounter] & y < this.WindowY[windowCounter] + this.WindowH[windowCounter])
          {
            if (num1 == -1)
              num1 = windowCounter;
            if (num1 > -1 && !Information.IsNothing((object) this.WindowList[windowCounter].LowerWindow))
              num1 = windowCounter;
          }
        }
      }
      int windowCounter1 = this.WindowCounter;
      for (int index = 0; index <= windowCounter1; ++index)
      {
        this.WindowList[index].MouseInThisWindow = false;
        if (x >= this.WindowX[index] & x < this.WindowX[index] + this.WindowW[index] && y >= this.WindowY[index] & y < this.WindowY[index] + this.WindowH[index])
          this.WindowList[index].MouseInThisWindow = true;
      }
      int windowCounter2 = this.WindowCounter;
      for (int index = 0; index <= windowCounter2; ++index)
      {
        if (index == num1 & Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) != 0 & !this.WindowInputBlock[index] && !(x >= this.WindowX[index] & x <= this.WindowX[index] + this.WindowW[index] & y >= this.WindowY[index] & y <= this.WindowY[index] + this.WindowH[index]) && this.LastOverlayWindow == this.WindowID[index])
        {
          this.ClearOverlaySpecificWindow(this.LastOverlayWindow);
          this.LastOverlayWindow = -1;
          screenReturnClass.flag = true;
          return screenReturnClass;
        }
      }
      bool flag = false;
      int windowCounter3 = this.WindowCounter;
      WindowReturnClass windowReturnClass;
      for (int index = 0; index <= windowCounter3; ++index)
      {
        if (index == num1 & Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) != 0 & !this.WindowInputBlock[index] && x >= this.WindowX[index] & x <= this.WindowX[index] + this.WindowW[index] & y >= this.WindowY[index] & y <= this.WindowY[index] + this.WindowH[index])
        {
          windowReturnClass = this.WindowList[index].HandleMouseMove(x - this.WindowX[index], y - this.WindowY[index]);
          this.WindowFlag[index] = windowReturnClass.Flag;
          if (windowReturnClass.allowOtherMouseOverWindow)
            flag = true;
          if (windowReturnClass.Counter > -1)
          {
            this.HandleWR(windowReturnClass, true, ref screenReturnClass);
            windowReturnClass.Flag = true;
          }
          if (windowReturnClass.Overlay | this.LastOverlayWindow > 0)
          {
            if (this.LastOverlayWindow > 0 & this.LastOverlayWindow != this.WindowID[index])
              this.ClearOverlaySpecificWindow(this.LastOverlayWindow);
            if (windowReturnClass.Overlay)
              this.LastOverlayWindow = this.WindowID[index];
          }
          if (!screenReturnClass.flag)
            screenReturnClass.flag = windowReturnClass.Flag;
          if (screenReturnClass.flag | windowReturnClass.Overlay || windowReturnClass.NoMouseClickBelow)
            return screenReturnClass;
        }
      }
      int num2;
      if (Information.IsNothing((object) windowReturnClass))
        num2 = 1;
      else if (!windowReturnClass.NoMouseClickBelow)
        num2 = 1;
      if (num2 == 1)
      {
        int windowCounter4 = this.WindowCounter;
        for (int index = 0; index <= windowCounter4; ++index)
        {
          if ((index == num1 | flag) & Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) == 0 & !this.WindowInputBlock[index] && x >= this.WindowX[index] & x <= this.WindowX[index] + this.WindowW[index] & y >= this.WindowY[index] & y <= this.WindowY[index] + this.WindowH[index])
          {
            WindowReturnClass wr = this.WindowList[index].HandleMouseMove(x - this.WindowX[index], y - this.WindowY[index]);
            this.WindowFlag[index] = wr.Flag;
            if (wr.Counter > -1)
            {
              this.HandleWR(wr, true, ref screenReturnClass);
              wr.Flag = true;
            }
            if (wr.Overlay | this.LastOverlayWindow > 0)
            {
              if (this.LastOverlayWindow > 0 & this.LastOverlayWindow != this.WindowID[index])
                this.ClearOverlaySpecificWindow(this.LastOverlayWindow);
              if (wr.Overlay)
                this.LastOverlayWindow = this.WindowID[index];
            }
            if (!screenReturnClass.flag)
              screenReturnClass.flag = wr.Flag;
            if (screenReturnClass.flag)
              return screenReturnClass;
          }
        }
      }
      if (this.LastOverlayWindow > 0)
      {
        this.ClearOverlaySpecificWindow(this.LastOverlayWindow);
        screenReturnClass.flag = true;
      }
      return screenReturnClass;
    }

    public override ScreenReturnClass HandleTimerWheel(int x, int y)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      ScreenReturnClass screenReturnClass1 = new ScreenReturnClass();
      if (this.WindowCounter <= -1)
      {
        ScreenReturnClass screenReturnClass2;
        return screenReturnClass2;
      }
      int num = 1;
      do
      {
        int windowCounter1 = this.WindowCounter;
        for (int index1 = 0; index1 <= windowCounter1; ++index1)
        {
          if (!this.WindowInputBlock[index1])
          {
            bool flag;
            if (x > this.WindowX[index1] & y > this.WindowY[index1] & x < this.WindowX[index1] + this.WindowW[index1] & y < this.WindowY[index1] + this.WindowH[index1])
              flag = true;
            if (Operators.CompareString(this.WindowList[index1].GetType().FullName, "WindowsApplication1.OrderWindowClass2", false) == 0 | Operators.CompareString(this.WindowList[index1].GetType().FullName, "WindowsApplication1.UdsOrderWindowClass", false) == 0)
            {
              if (num == 2)
              {
                int windowCounter2 = this.WindowCounter;
                for (int index2 = 0; index2 <= windowCounter2; ++index2)
                {
                  if (Operators.CompareString(this.WindowList[index2].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) == 0 && x > this.WindowX[index2] & y > this.WindowY[index2] & x < this.WindowX[index2] + this.WindowW[index2] & y < this.WindowY[index2] + this.WindowH[index2])
                    flag = true;
                }
              }
              else
                flag = false;
            }
            else if (num == 2)
              flag = false;
            if (Operators.CompareString(this.WindowList[index1].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) == 0)
              flag = false;
            if (flag)
            {
              WindowReturnClass wr = this.WindowList[index1].handleTimerWheel(x - this.WindowX[index1], y - this.WindowY[index1]);
              if (wr.Flag)
              {
                screenReturnClass1.flag = true;
                this.WindowFlag[index1] = true;
                if (wr.Counter > -1)
                  this.HandleWR(wr, false, ref screenReturnClass1);
                return screenReturnClass1;
              }
              this.Game.EditObj.MouseWheel = 0;
              screenReturnClass1.flag = false;
              return screenReturnClass1;
            }
          }
        }
        ++num;
      }
      while (num <= 2);
      this.Game.EditObj.MouseWheel = 0;
      screenReturnClass1.flag = false;
      return screenReturnClass1;
    }

    public override ScreenReturnClass HandleTimer()
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      bool flag = false;
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
      {
        if (Operators.CompareString(this.WindowList[windowCounter].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) != 0 & !this.WindowInputBlock[windowCounter])
        {
          WindowReturnClass wr = this.WindowList[windowCounter].handleTimer();
          if (!this.WindowFlag[windowCounter] & wr.Flag)
            this.WindowFlag[windowCounter] = wr.Flag;
          if (wr.Flag)
          {
            if (wr.Counter > -1)
              this.HandleWR(wr, false, ref screenReturnClass);
            if (wr.Flag)
              flag = true;
          }
        }
      }
      for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
      {
        if (Operators.CompareString(this.WindowList[windowCounter].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) == 0 & !this.WindowInputBlock[windowCounter])
        {
          WindowReturnClass wr = this.WindowList[windowCounter].handleTimer();
          if (!this.WindowFlag[windowCounter] & wr.Flag)
            this.WindowFlag[windowCounter] = wr.Flag;
          if (wr.Flag)
          {
            if (wr.Counter > -1)
              this.HandleWR(wr, false, ref screenReturnClass);
            if (wr.Flag)
              flag = true;
          }
        }
      }
      if (flag)
        screenReturnClass.flag = true;
      return screenReturnClass;
    }

    public override ScreenReturnClass HandleKeyPress(int nr)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      for (int windowCounter = this.WindowCounter; windowCounter >= 0; windowCounter += -1)
      {
        if (!this.WindowInputBlock[windowCounter])
        {
          WindowReturnClass wr = this.WindowList[windowCounter].HandleKeyPress(nr);
          if (!this.WindowFlag[windowCounter] & wr.Flag)
            this.WindowFlag[windowCounter] = wr.Flag;
          if (wr.Counter > -1)
            this.HandleWR(wr, false, ref screenReturnClass);
          if (wr.Flag)
          {
            screenReturnClass.flag = true;
            return screenReturnClass;
          }
        }
      }
      screenReturnClass.flag = true;
      return screenReturnClass;
    }
  }
}
