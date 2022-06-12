// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.UdsOrderWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class UdsOrderWindowClass : WindowClass
  {
    public int w;
    public int h;
    public int lastorderx;
    public int lastordery;
    private int exitId;
    private int tab1;
    private int tab2;
    private int tab3;
    private int tab4;
    private int tab51;
    private int tab52;
    private int tab53;
    private int tab54;
    private int tab6;
    private int currentview;
    private int butCount;
    private int[] butId;
    private string[] butString;
    private int[] butEvent;
    private string[] butMouseOver;
    private int[] butSmallGfx;
    private int[] butTempVar0;
    private int[] butTempVar1;
    private int[] butTempVarStringlistId;
    private int MouseOverWhichTab;

    public UdsOrderWindowClass(
      ref GameClass tGame,
      ref WindowClass tLowerWindow,
      ref Rectangle tLowerRect)
      : base(ref tGame, tGame.ScreenWidth, 90)
    {
      this.butId = new int[100];
      this.butString = new string[100];
      this.butEvent = new int[100];
      this.butMouseOver = new string[100];
      this.butSmallGfx = new int[100];
      this.butTempVar0 = new int[100];
      this.butTempVar1 = new int[100];
      this.butTempVarStringlistId = new int[100];
      this.NewGfx = true;
      this.w = tGame.ScreenWidth;
      this.h = 90;
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      if (this.game.SelectX > -1 && this.game.EditObj.UnitSelected == -1 & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > -1 && this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime))
        this.game.EditObj.UnitSelected = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0];
      this.game.EditObj.PurelyOrderRedrawRefresh = false;
      this.DoRefresh();
    }

    public override void DoRefresh()
    {
      if (this.game.EditObj.OrderType == 0)
      {
        this.lastorderx = -1;
        this.lastordery = -1;
      }
      this.dostuff();
    }

    public override WindowReturnClass handleTimerWheel(int x, int y)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      windowReturnClass.Flag = false;
      if (this.game.EditObj.MouseWheel > 0 & this.game.EditObj.Zoom < 1 & this.game.EditObj.TutOrder == -1)
      {
        if (this.game.EditObj.MouseOverX > -1 & this.game.EditObj.MouseOverY > -1)
          this.game.HandyFunctionsObj.CenterOnXY(this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY, true);
        this.game.EditObj.MouseWheel = 0;
        this.game.EditObj.MouseWheelWait = 4;
        return this.actionZoomIn();
      }
      if (this.game.EditObj.MouseWheel < 0 & this.game.EditObj.Zoom > -1 & this.game.EditObj.TutOrder == -1)
      {
        int num = this.game.EditObj.MouseOverX > -1 & this.game.EditObj.MouseOverY > -1 & this.game.Data.Product <= 5 ? 1 : 0;
        this.game.EditObj.MouseWheel = 0;
        this.game.EditObj.MouseWheelWait = 4;
        return this.actionZoomOut();
      }
      if (!this.game.EditObj.GuiDown || Information.IsNothing((object) this.game.EditObj.UDSpushedPopupText) || this.game.EditObj.UDSpushedPopupText.Length <= 1)
        return windowReturnClass;
      this.game.EditObj.UDSpopupText = this.game.EditObj.UDSpushedPopupText;
      this.game.EditObj.UDSpushedPopupText = "";
      this.game.EditObj.PopupValue = 21;
      windowReturnClass.AddCommand(5, 14);
      this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.MouseOverWhichTab <= 0 || this.MouseInThisWindow)
        return windowReturnClass;
      this.MouseOverWhichTab = 0;
      this.dostuff();
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    public void DoTabs(ref Graphics g)
    {
      SizeF sizeF1 = new SizeF();
      this.tab1 = -1;
      this.tab2 = -1;
      this.tab3 = -1;
      this.tab4 = -1;
      this.tab51 = -1;
      this.tab52 = -1;
      this.tab53 = -1;
      this.tab54 = -1;
      this.tab6 = -1;
      if (this.game.EditObj.GuiDown)
        return;
      int num1;
      if (this.game.EditObj.UnitSelected == -1)
      {
        if (this.game.Data.ExtraTabName.Length <= 0)
          return;
        int width = 182;
        int num2 = 52;
        int num3 = 1;
        if (this.game.Data.ExtraTabName2.Length > 0)
        {
          width = 140;
          num2 = 132;
          num3 = 2;
        }
        if (this.game.Data.ExtraTabName3.Length > 0)
        {
          width = 112;
          num2 = 172;
          num3 = 3;
        }
        if (this.game.Data.ExtraTabName4.Length > 0)
        {
          width = 102;
          num2 = 130;
          num3 = 4;
        }
        int num4 = num2 - width;
        if (this.game.EditObj.SetViewModeExtraNr == 0)
        {
          int x1 = (int) Math.Round((double) num4 + (double) this.game.ScreenWidth / 2.0 - 370.0) + (width - 12);
          Bitmap bitmap;
          SizeF sizeF2;
          Rectangle trect1;
          Rectangle trect2;
          if (this.game.Data.ExtraTabName4.Length > 0)
          {
            x1 -= width - 12;
            ref Graphics local1 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local2 = ref bitmap;
            int x2 = x1;
            int w = width;
            DrawMod.DrawScaledColorized(ref local1, ref local2, x2, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
            string upper = this.game.Data.ExtraTabName4.ToUpper();
            sizeF2 = g.MeasureString(upper, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x1 + (double) width / 2.0 - (double) sizeF2.Width / 2.0), 70, Color.White);
            trect1 = new Rectangle(x1, 66, width, 24);
            trect2 = trect1;
            this.AddMouse(ref trect2, "", "Extra data sheet.", 54);
            this.tab54 = this.MouseCounter;
          }
          if (this.game.Data.ExtraTabName3.Length > 0)
          {
            x1 -= width - 12;
            ref Graphics local3 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local4 = ref bitmap;
            int x3 = x1;
            int w = width;
            DrawMod.DrawScaledColorized(ref local3, ref local4, x3, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
            string upper = this.game.Data.ExtraTabName3.ToUpper();
            sizeF2 = g.MeasureString(upper, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x1 + (double) width / 2.0 - (double) sizeF2.Width / 2.0), 70, Color.White);
            trect2 = new Rectangle(x1, 66, width, 24);
            trect1 = trect2;
            this.AddMouse(ref trect1, "", "Extra data sheet.", 53);
            this.tab53 = this.MouseCounter;
          }
          if (this.game.Data.ExtraTabName2.Length > 0)
          {
            x1 -= width - 12;
            ref Graphics local5 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local6 = ref bitmap;
            int x4 = x1;
            int w = width;
            DrawMod.DrawScaledColorized(ref local5, ref local6, x4, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
            string upper = this.game.Data.ExtraTabName2.ToUpper();
            sizeF2 = g.MeasureString(upper, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x1 + (double) width / 2.0 - (double) sizeF2.Width / 2.0), 70, Color.White);
            trect2 = new Rectangle(x1, 66, width, 24);
            trect1 = trect2;
            this.AddMouse(ref trect1, "", "Extra data sheet.", 52);
            this.tab52 = this.MouseCounter;
          }
          int x5 = x1 - (width - 12);
          ref Graphics local7 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
          ref Bitmap local8 = ref bitmap;
          int x6 = x5;
          int w1 = width;
          DrawMod.DrawScaledColorized(ref local7, ref local8, x6, 66, w1, 24, 182, 24, 0.0f, 0.0f, 0.0f, 1f);
          string upper1 = this.game.Data.ExtraTabName.ToUpper();
          sizeF2 = g.MeasureString(upper1, this.game.MarcFont16);
          DrawMod.DrawTextColouredMarc(ref g, upper1, this.game.MarcFont16, (int) Math.Round((double) x5 + (double) width / 2.0 - (double) sizeF2.Width / 2.0), 70, Color.White);
          trect2 = new Rectangle(x5, 66, width, 24);
          trect1 = trect2;
          this.AddMouse(ref trect1, "", "Extra data sheet.", 51);
          this.tab51 = this.MouseCounter;
        }
        else
        {
          int x7 = (int) Math.Round((double) num4 + (double) this.game.ScreenWidth / 2.0 - 370.0) + (width - 12);
          Bitmap bitmap;
          string upper;
          SizeF sizeF3;
          Rectangle rectangle;
          if (this.game.Data.ExtraTabName4.Length > 0 & this.game.EditObj.SetViewModeExtraNr != 4)
          {
            x7 -= width - 12;
            ref Graphics local9 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local10 = ref bitmap;
            int x8 = x7;
            int w = width;
            DrawMod.DrawScaledColorized(ref local9, ref local10, x8, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
            upper = this.game.Data.ExtraTabName4.ToUpper();
            sizeF3 = g.MeasureString(upper, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x7 + (double) width / 2.0 - (double) sizeF3.Width / 2.0), 70, Color.White);
            rectangle = new Rectangle(x7, 66, width, 24);
            Rectangle trect = rectangle;
            this.AddMouse(ref trect, "", "Extra data sheet.", 54);
            this.tab54 = this.MouseCounter;
          }
          else if (this.game.Data.ExtraTabName3.Length > 0)
            x7 -= width - 12;
          if (this.game.Data.ExtraTabName3.Length > 0 & this.game.EditObj.SetViewModeExtraNr != 3)
          {
            x7 -= width - 12;
            ref Graphics local11 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local12 = ref bitmap;
            int x9 = x7;
            int w = width;
            DrawMod.DrawScaledColorized(ref local11, ref local12, x9, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
            upper = this.game.Data.ExtraTabName3.ToUpper();
            sizeF3 = g.MeasureString(upper, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x7 + (double) width / 2.0 - (double) sizeF3.Width / 2.0), 70, Color.White);
            rectangle = new Rectangle(x7, 66, width, 24);
            Rectangle trect = rectangle;
            this.AddMouse(ref trect, "", "Extra data sheet.", 53);
            this.tab53 = this.MouseCounter;
          }
          else if (this.game.Data.ExtraTabName3.Length > 0)
            x7 -= width - 12;
          if (this.game.Data.ExtraTabName2.Length > 0 & this.game.EditObj.SetViewModeExtraNr != 2)
          {
            x7 -= width - 12;
            ref Graphics local13 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local14 = ref bitmap;
            int x10 = x7;
            int w = width;
            DrawMod.DrawScaledColorized(ref local13, ref local14, x10, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
            upper = this.game.Data.ExtraTabName2.ToUpper();
            sizeF3 = g.MeasureString(upper, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x7 + (double) width / 2.0 - (double) sizeF3.Width / 2.0), 70, Color.White);
            rectangle = new Rectangle(x7, 66, width, 24);
            Rectangle trect = rectangle;
            this.AddMouse(ref trect, "", "Extra data sheet.", 52);
            this.tab52 = this.MouseCounter;
          }
          else if (this.game.Data.ExtraTabName2.Length > 0)
            x7 -= width - 12;
          if (this.game.Data.ExtraTabName.Length > 0 & this.game.EditObj.SetViewModeExtraNr != 1)
          {
            int x11 = x7 - (width - 12);
            ref Graphics local15 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local16 = ref bitmap;
            int x12 = x11;
            int w = width;
            DrawMod.DrawScaledColorized(ref local15, ref local16, x12, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
            upper = this.game.Data.ExtraTabName.ToUpper();
            sizeF3 = g.MeasureString(upper, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x11 + (double) width / 2.0 - (double) sizeF3.Width / 2.0), 70, Color.White);
            rectangle = new Rectangle(x11, 66, width, 24);
            Rectangle trect = rectangle;
            this.AddMouse(ref trect, "", "Extra data sheet.", 51);
            this.tab51 = this.MouseCounter;
          }
          else if (this.game.Data.ExtraTabName.Length > 0)
            num1 = x7 - (width - 12);
          int x13 = (int) Math.Round((double) num4 + (double) this.game.ScreenWidth / 2.0 - 370.0) + (width - 12);
          if (this.game.EditObj.SetViewModeExtraNr == 1)
          {
            upper = this.game.Data.ExtraTabName.ToUpper();
            x13 -= (width - 12) * (num3 - 0);
          }
          if (this.game.EditObj.SetViewModeExtraNr == 2)
          {
            upper = this.game.Data.ExtraTabName2.ToUpper();
            x13 -= (width - 12) * (num3 - 1);
          }
          if (this.game.EditObj.SetViewModeExtraNr == 3)
          {
            upper = this.game.Data.ExtraTabName3.ToUpper();
            x13 -= (width - 12) * (num3 - 2);
          }
          if (this.game.EditObj.SetViewModeExtraNr == 4)
          {
            upper = this.game.Data.ExtraTabName4.ToUpper();
            x13 -= (width - 12) * (num3 - 3);
          }
          ref Graphics local17 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
          ref Bitmap local18 = ref bitmap;
          int x14 = x13;
          int w2 = width;
          DrawMod.DrawScaledColorized(ref local17, ref local18, x14, 66, w2, 24, 182, 24, 0.0f, 0.0f, 0.0f, 1f);
          sizeF3 = g.MeasureString(upper, this.game.MarcFont16);
          DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x13 + (double) width / 2.0 - (double) sizeF3.Width / 2.0), 70, Color.White);
          rectangle = new Rectangle(x13, 66, width, 24);
          Rectangle trect3 = rectangle;
          this.AddMouse(ref trect3, "", "Extra data sheet.", 50 + this.game.EditObj.SetViewModeExtraNr);
          if (this.game.EditObj.SetViewModeExtraNr == 1)
            this.tab51 = this.MouseCounter;
          if (this.game.EditObj.SetViewModeExtraNr == 2)
            this.tab52 = this.MouseCounter;
          if (this.game.EditObj.SetViewModeExtraNr == 3)
            this.tab53 = this.MouseCounter;
          if (this.game.EditObj.SetViewModeExtraNr != 4)
            return;
          this.tab54 = this.MouseCounter;
        }
      }
      else
      {
        if (this.game.EditObj.UnitSelected <= -1)
          return;
        object obj = (object) true;
        if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1)
        {
          if (Information.IsNothing((object) this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName))
            obj = (object) false;
          else if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName.Length < 1)
            obj = (object) false;
          if (!this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
            ;
        }
        else
          obj = (object) false;
        if (this.game.Data.ExtraTabName.Length > 0)
        {
          int width = 182;
          int num5 = 52;
          int num6 = 1;
          if (this.game.Data.ExtraTabName2.Length > 0)
          {
            width = 140;
            num5 = 132;
            num6 = 2;
          }
          if (this.game.Data.ExtraTabName3.Length > 0)
          {
            width = 112;
            num5 = 172;
            num6 = 3;
          }
          if (this.game.Data.ExtraTabName4.Length > 0)
          {
            width = 102;
            num5 = 228;
            num6 = 4;
          }
          if (this.game.EditObj.SetViewModeExtraNr == 0)
          {
            int x15 = (int) Math.Round((double) num5 + (double) this.game.ScreenWidth / 2.0 - 480.0) + (width - 12);
            Bitmap bitmap;
            SizeF sizeF4;
            Rectangle rectangle;
            if (this.game.Data.ExtraTabName4.Length > 0)
            {
              x15 -= width - 12;
              ref Graphics local19 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local20 = ref bitmap;
              int x16 = x15;
              int w = width;
              DrawMod.DrawScaledColorized(ref local19, ref local20, x16, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              string upper = this.game.Data.ExtraTabName4.ToUpper();
              sizeF4 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x15 + (double) width / 2.0 - (double) sizeF4.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x15, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 54);
              this.tab54 = this.MouseCounter;
            }
            if (this.game.Data.ExtraTabName3.Length > 0)
            {
              x15 -= width - 12;
              ref Graphics local21 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local22 = ref bitmap;
              int x17 = x15;
              int w = width;
              DrawMod.DrawScaledColorized(ref local21, ref local22, x17, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              string upper = this.game.Data.ExtraTabName3.ToUpper();
              sizeF4 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x15 + (double) width / 2.0 - (double) sizeF4.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x15, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 53);
              this.tab53 = this.MouseCounter;
            }
            if (this.game.Data.ExtraTabName2.Length > 0)
            {
              x15 -= width - 12;
              ref Graphics local23 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local24 = ref bitmap;
              int x18 = x15;
              int w = width;
              DrawMod.DrawScaledColorized(ref local23, ref local24, x18, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              string upper = this.game.Data.ExtraTabName2.ToUpper();
              sizeF4 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x15 + (double) width / 2.0 - (double) sizeF4.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x15, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 52);
              this.tab52 = this.MouseCounter;
            }
            int x19 = x15 - (width - 12);
            ref Graphics local25 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local26 = ref bitmap;
            int x20 = x19;
            int w3 = width;
            DrawMod.DrawScaledColorized(ref local25, ref local26, x20, 66, w3, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
            string upper2 = this.game.Data.ExtraTabName.ToUpper();
            sizeF4 = g.MeasureString(upper2, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, upper2, this.game.MarcFont16, (int) Math.Round((double) x19 + (double) width / 2.0 - (double) sizeF4.Width / 2.0), 70, Color.White);
            rectangle = new Rectangle(x19, 66, width, 24);
            Rectangle trect4 = rectangle;
            this.AddMouse(ref trect4, "", "Extra data sheet.", 51);
            this.tab51 = this.MouseCounter;
            int x21 = x19 - (width - 12);
            ref Graphics local27 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local28 = ref bitmap;
            int x22 = x21;
            int w4 = width;
            DrawMod.DrawScaledColorized(ref local27, ref local28, x22, 66, w4, 24, 182, 24, 0.0f, 0.0f, 0.0f, 1f);
            string str = "UNIT INFO";
            sizeF4 = g.MeasureString(str, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, (int) Math.Round((double) x21 + (double) width / 2.0 - (double) sizeF4.Width / 2.0), 70, Color.White);
            rectangle = new Rectangle(x21, 66, width, 24);
            Rectangle trect5 = rectangle;
            this.AddMouse(ref trect5, "", "The base info of the unit is always shown.");
          }
          else
          {
            int x23 = (int) Math.Round((double) num5 + (double) this.game.ScreenWidth / 2.0 - 480.0) + (width - 12);
            Bitmap bitmap;
            SizeF sizeF5;
            Rectangle rectangle;
            if (this.game.Data.ExtraTabName4.Length > 0 & this.game.EditObj.SetViewModeExtraNr != 4)
            {
              x23 -= width - 12;
              ref Graphics local29 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local30 = ref bitmap;
              int x24 = x23;
              int w = width;
              DrawMod.DrawScaledColorized(ref local29, ref local30, x24, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              string upper = this.game.Data.ExtraTabName4.ToUpper();
              sizeF5 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x23 + (double) width / 2.0 - (double) sizeF5.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x23, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 54);
              this.tab54 = this.MouseCounter;
            }
            else if (this.game.Data.ExtraTabName3.Length > 0)
              x23 -= width - 12;
            if (this.game.Data.ExtraTabName3.Length > 0 & this.game.EditObj.SetViewModeExtraNr != 3)
            {
              x23 -= width - 12;
              ref Graphics local31 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local32 = ref bitmap;
              int x25 = x23;
              int w = width;
              DrawMod.DrawScaledColorized(ref local31, ref local32, x25, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              string upper = this.game.Data.ExtraTabName3.ToUpper();
              sizeF5 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x23 + (double) width / 2.0 - (double) sizeF5.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x23, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 53);
              this.tab53 = this.MouseCounter;
            }
            else if (this.game.Data.ExtraTabName3.Length > 0)
              x23 -= width - 12;
            if (this.game.Data.ExtraTabName2.Length > 0 & this.game.EditObj.SetViewModeExtraNr != 2)
            {
              x23 -= width - 12;
              ref Graphics local33 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local34 = ref bitmap;
              int x26 = x23;
              int w = width;
              DrawMod.DrawScaledColorized(ref local33, ref local34, x26, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              string upper = this.game.Data.ExtraTabName2.ToUpper();
              sizeF5 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x23 + (double) width / 2.0 - (double) sizeF5.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x23, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 52);
              this.tab52 = this.MouseCounter;
            }
            else if (this.game.Data.ExtraTabName2.Length > 0)
              x23 -= width - 12;
            if (this.game.Data.ExtraTabName.Length > 0 & this.game.EditObj.SetViewModeExtraNr != 1)
            {
              int x27 = x23 - (width - 12);
              ref Graphics local35 = ref g;
              bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
              ref Bitmap local36 = ref bitmap;
              int x28 = x27;
              int w = width;
              DrawMod.DrawScaledColorized(ref local35, ref local36, x28, 66, w, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
              string upper = this.game.Data.ExtraTabName.ToUpper();
              sizeF5 = g.MeasureString(upper, this.game.MarcFont16);
              DrawMod.DrawTextColouredMarc(ref g, upper, this.game.MarcFont16, (int) Math.Round((double) x27 + (double) width / 2.0 - (double) sizeF5.Width / 2.0), 70, Color.White);
              rectangle = new Rectangle(x27, 66, width, 24);
              Rectangle trect = rectangle;
              this.AddMouse(ref trect, "", "Extra data sheet.", 51);
              this.tab51 = this.MouseCounter;
            }
            else if (this.game.Data.ExtraTabName.Length > 0)
              num1 = x23 - (width - 12);
            int num7 = (int) Math.Round((double) num5 + (double) this.game.ScreenWidth / 2.0 - 480.0) + (width - 12);
            if (this.game.Data.ExtraTabName4.Length > 0)
              num7 -= width - 12;
            if (this.game.Data.ExtraTabName3.Length > 0)
              num7 -= width - 12;
            if (this.game.Data.ExtraTabName2.Length > 0)
              num7 -= width - 12;
            if (this.game.Data.ExtraTabName.Length > 0)
              num7 -= width - 12;
            int x29 = num7 - (width - 12);
            ref Graphics local37 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local38 = ref bitmap;
            int x30 = x29;
            int w5 = width;
            DrawMod.DrawScaledColorized(ref local37, ref local38, x30, 66, w5, 24, 182, 24, -0.1f, -0.1f, -0.1f, 1f);
            string str = "UNIT INFO";
            sizeF5 = g.MeasureString(str, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, (int) Math.Round((double) x29 + (double) width / 2.0 - (double) sizeF5.Width / 2.0), 70, Color.White);
            rectangle = new Rectangle(x29, 66, width, 24);
            Rectangle trect6 = rectangle;
            this.AddMouse(ref trect6, "", "The base info of the unit is always shown.", 6);
            this.tab6 = this.MouseCounter;
            int x31 = (int) Math.Round((double) num5 + (double) this.game.ScreenWidth / 2.0 - 480.0) + (width - 12);
            if (this.game.EditObj.SetViewModeExtraNr == 1)
            {
              str = this.game.Data.ExtraTabName.ToUpper();
              x31 -= (width - 12) * (num6 - 0);
            }
            if (this.game.EditObj.SetViewModeExtraNr == 2)
            {
              str = this.game.Data.ExtraTabName2.ToUpper();
              x31 -= (width - 12) * (num6 - 1);
            }
            if (this.game.EditObj.SetViewModeExtraNr == 3)
            {
              str = this.game.Data.ExtraTabName3.ToUpper();
              x31 -= (width - 12) * (num6 - 2);
            }
            if (this.game.EditObj.SetViewModeExtraNr == 4)
            {
              str = this.game.Data.ExtraTabName4.ToUpper();
              x31 -= (width - 12) * (num6 - 3);
            }
            ref Graphics local39 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
            ref Bitmap local40 = ref bitmap;
            int x32 = x31;
            int w6 = width;
            DrawMod.DrawScaledColorized(ref local39, ref local40, x32, 66, w6, 24, 182, 24, 0.0f, 0.0f, 0.0f, 1f);
            sizeF5 = g.MeasureString(str, this.game.MarcFont16);
            DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, (int) Math.Round((double) x31 + (double) width / 2.0 - (double) sizeF5.Width / 2.0), 70, Color.White);
            rectangle = new Rectangle(x31, 66, width, 24);
            Rectangle trect7 = rectangle;
            this.AddMouse(ref trect7, "", "Extra data sheet.", 50 + this.game.EditObj.SetViewModeExtraNr);
            if (this.game.EditObj.SetViewModeExtraNr == 1)
              this.tab51 = this.MouseCounter;
            if (this.game.EditObj.SetViewModeExtraNr == 2)
              this.tab52 = this.MouseCounter;
            if (this.game.EditObj.SetViewModeExtraNr == 3)
              this.tab53 = this.MouseCounter;
            if (this.game.EditObj.SetViewModeExtraNr == 4)
              this.tab54 = this.MouseCounter;
          }
        }
        else
        {
          int x33 = (int) Math.Round((double) this.game.ScreenWidth / 2.0 - 480.0);
          ref Graphics local41 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
          ref Bitmap local42 = ref bitmap;
          int x34 = x33;
          DrawMod.DrawSimple(ref local41, ref local42, x34, 66);
          string str = "UNIT BASE INFO";
          SizeF sizeF6 = g.MeasureString(str, this.game.MarcFont16);
          DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, (int) Math.Round((double) ((float) (x33 + 91) - sizeF6.Width / 2f)), 70, Color.White);
          Rectangle trect = new Rectangle(x33, 66, BitmapStore.GetWidth(this.game.MARCLARGETAB), 24);
          this.AddMouse(ref trect, "", "The base info of the unit is always shown.");
        }
        if (this.game.EditObj.SetViewModeExtraNr != 0)
          return;
        bool flag;
        if (this.game.EditObj.OrderType == 14)
          flag = true;
        if (this.game.EditObj.OrderType == 33)
          flag = true;
        if (this.game.EditObj.OrderType == 15)
          flag = true;
        if (this.game.EditObj.OrderType == 2)
          flag = true;
        if (this.game.EditObj.OrderType == 12)
          flag = true;
        if (this.game.EditObj.OrderType == 11)
          flag = true;
        if (this.game.EditObj.OrderType == 13)
          flag = true;
        if (this.currentview == 2 & !flag)
        {
          this.currentview = 0;
          this.game.EditObj.SetViewMode = 0;
        }
        if (Conversions.ToBoolean(Operators.AndObject((object) (this.currentview == 3), Operators.OrObject((object) !this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ, Operators.CompareObjectEqual(obj, (object) false, false)))))
        {
          this.currentview = 0;
          this.game.EditObj.SetViewMode = 0;
          this.game.EditObj.SetViewMode3 = false;
        }
        if (Conversions.ToBoolean(Operators.AndObject((object) (this.currentview == 0), Operators.AndObject((object) this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ, obj))) && !this.game.EditObj.SetViewMode3)
        {
          this.currentview = 3;
          this.game.EditObj.SetViewMode = 3;
          this.game.EditObj.SetViewMode3 = true;
        }
        if (Conversions.ToBoolean(Operators.AndObject((object) this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ, Operators.CompareObjectEqual(obj, (object) true, false))))
        {
          if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn))
          {
            if (this.currentview == 3)
            {
              this.DoTabs2B(ref g);
              this.DoTabs1B(ref g);
              this.DoTabs4(ref g, true);
            }
            else if (this.currentview == 0)
            {
              this.DoTabs2B(ref g);
              this.DoTabs4(ref g);
              this.DoTabs1B(ref g, true);
            }
            else if (this.currentview == 1)
            {
              this.DoTabs4(ref g);
              this.DoTabs1B(ref g);
              this.DoTabs2B(ref g, true);
            }
            else
            {
              if (this.currentview != 2)
                return;
              this.DoTabs4(ref g);
              if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn))
                this.DoTabs1B(ref g);
              this.DoTabs2B(ref g, true);
            }
          }
          else if (this.currentview != 3)
          {
            this.DoTabs4(ref g);
            this.DoTabs1B(ref g, true);
          }
          else
          {
            this.DoTabs1B(ref g);
            this.DoTabs4(ref g, true);
          }
        }
        else if (this.currentview == 0)
        {
          if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn))
            this.DoTabs2(ref g);
          this.DoTabs1(ref g, true);
        }
        else if (this.currentview == 1)
        {
          this.DoTabs1(ref g);
          if (!this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn))
            return;
          this.DoTabs2(ref g, true);
        }
        else
        {
          if (this.currentview != 2)
            return;
          this.DoTabs1(ref g);
          if (!this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn))
            return;
          this.DoTabs2(ref g);
        }
      }
    }

    public Rectangle DrawOneTab(
      Graphics g,
      bool wideTab,
      bool active,
      int tx,
      string sHeader,
      string sText,
      int spriteSlot,
      int iconSlot,
      int smallNumber = -1,
      bool grayedOut = false,
      int textOffsetX = 0,
      int spriteOffsetY = 0,
      bool tMousingOverNow = false)
    {
      int y1 = 24;
      Bitmap bitmap;
      if (tMousingOverNow)
      {
        if (active & wideTab)
        {
          ref Graphics local1 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ORDERBAR_TAB1HIGH);
          ref Bitmap local2 = ref bitmap;
          int x = tx;
          int y2 = y1;
          DrawMod.Draw(ref local1, ref local2, x, y2, 0.05f, 0.05f, 0.05f, 1f);
        }
        if (!active & wideTab)
        {
          ref Graphics local3 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ORDERBAR_TAB1LOW);
          ref Bitmap local4 = ref bitmap;
          int x = tx;
          int y3 = y1;
          DrawMod.Draw(ref local3, ref local4, x, y3, 0.05f, 0.05f, 0.05f, 1f);
        }
        if (active & !wideTab)
        {
          ref Graphics local5 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ORDERBAR_TAB2HIGH);
          ref Bitmap local6 = ref bitmap;
          int x = tx;
          int y4 = y1;
          DrawMod.Draw(ref local5, ref local6, x, y4, 0.05f, 0.05f, 0.05f, 1f);
        }
        if (!active & !wideTab)
        {
          ref Graphics local7 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ORDERBAR_TAB2LOW);
          ref Bitmap local8 = ref bitmap;
          int x = tx;
          int y5 = y1;
          DrawMod.Draw(ref local7, ref local8, x, y5, 0.05f, 0.05f, 0.05f, 1f);
        }
      }
      else
      {
        if (active & wideTab)
        {
          ref Graphics local9 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ORDERBAR_TAB1HIGH);
          ref Bitmap local10 = ref bitmap;
          int x = tx;
          int y6 = y1;
          DrawMod.DrawSimple(ref local9, ref local10, x, y6);
        }
        if (!active & wideTab)
        {
          ref Graphics local11 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ORDERBAR_TAB1LOW);
          ref Bitmap local12 = ref bitmap;
          int x = tx;
          int y7 = y1;
          DrawMod.DrawSimple(ref local11, ref local12, x, y7);
        }
        if (active & !wideTab)
        {
          ref Graphics local13 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ORDERBAR_TAB2HIGH);
          ref Bitmap local14 = ref bitmap;
          int x = tx;
          int y8 = y1;
          DrawMod.DrawSimple(ref local13, ref local14, x, y8);
        }
        if (!active & !wideTab)
        {
          ref Graphics local15 = ref g;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_ORDERBAR_TAB2LOW);
          ref Bitmap local16 = ref bitmap;
          int x = tx;
          int y9 = y1;
          DrawMod.DrawSimple(ref local15, ref local16, x, y9);
        }
      }
      if (wideTab)
      {
        if (spriteSlot > 0)
        {
          if (active)
          {
            ref Graphics local17 = ref g;
            bitmap = BitmapStore.GetBitmap(spriteSlot);
            ref Bitmap local18 = ref bitmap;
            int x = tx + 3;
            int y10 = y1 + 4 + spriteOffsetY;
            DrawMod.DrawSimple(ref local17, ref local18, x, y10);
          }
          if (!active)
          {
            ref Graphics local19 = ref g;
            bitmap = BitmapStore.GetBitmap(spriteSlot);
            ref Bitmap local20 = ref bitmap;
            int x = tx + 3;
            int y11 = y1 + 11 + spriteOffsetY;
            DrawMod.DrawSimple(ref local19, ref local20, x, y11);
          }
        }
        else if (iconSlot > -1 && !grayedOut)
        {
          Rectangle rectangle1;
          Rectangle rectangle2;
          if (active)
          {
            ref Graphics local21 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
            ref Bitmap local22 = ref bitmap;
            rectangle1 = new Rectangle(iconSlot * 42, 32, 42, 32);
            Rectangle srcrect = rectangle1;
            rectangle2 = new Rectangle(tx + 4, y1 + 11, 42, 32);
            Rectangle destrect = rectangle2;
            DrawMod.DrawSimplePart2(ref local21, ref local22, srcrect, destrect);
          }
          if (!active)
          {
            ref Graphics local23 = ref g;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
            ref Bitmap local24 = ref bitmap;
            rectangle2 = new Rectangle(iconSlot * 42, 0, 42, 32);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(tx + 4, y1 + 18, 42, 32);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local23, ref local24, srcrect, destrect);
          }
        }
      }
      SizeF sizeF = g.MeasureString(sText, DrawMod.TGame.MarcFont16);
      Color c1;
      Color c2;
      if (active)
      {
        c1 = this.game.seColWhite;
        c2 = this.game.seColGray;
      }
      if (!active)
      {
        c1 = this.game.seColGray;
        c2 = this.game.seColGray;
      }
      if (grayedOut)
      {
        c1 = Color.FromArgb((int) byte.MaxValue, 128, 128, 128);
        c2 = Color.FromArgb((int) byte.MaxValue, 128, 128, 128);
      }
      if (active)
      {
        if (wideTab)
        {
          if ((double) sizeF.Width > 150.0)
          {
            string[] strArray = sText.Split(new char[1]
            {
              ' '
            }, StringSplitOptions.RemoveEmptyEntries);
            sHeader = "";
            int num1 = -1;
            int upperBound1 = strArray.GetUpperBound(0);
            for (int index = 0; index <= upperBound1 && (double) g.MeasureString(sHeader + " " + strArray[index], DrawMod.TGame.MarcFont16).Width < 150.0; ++index)
            {
              if (sHeader.Length > 0)
                sHeader += " ";
              sHeader += strArray[index];
              num1 = index;
            }
            sText = "";
            int num2 = num1 + 1;
            int upperBound2 = strArray.GetUpperBound(0);
            for (int index = num2; index <= upperBound2; ++index)
            {
              if ((double) g.MeasureString(sText + " " + strArray[index], DrawMod.TGame.MarcFont16).Width < 150.0)
              {
                if (sText.Length > 0)
                  sText += " ";
                sText += strArray[index];
              }
              else
              {
                sText += "..";
                break;
              }
            }
            DrawMod.DrawTextColouredConsole(ref g, sHeader, this.game.MarcFont16, tx + 44 + textOffsetX, y1 + 10, c1);
            DrawMod.DrawTextColouredConsole(ref g, sText, this.game.MarcFont16, tx + 44 + textOffsetX, y1 + 26, c1);
          }
          else if (sHeader.Length > 0)
          {
            DrawMod.DrawTextColouredConsole(ref g, sHeader, this.game.MarcFont5, tx + 44 + textOffsetX, y1 + 13, c2);
            DrawMod.DrawTextColouredConsole(ref g, sText, this.game.MarcFont16, tx + 44 + textOffsetX, y1 + 24, c1);
          }
          else
            DrawMod.DrawTextColouredConsole(ref g, sText, this.game.MarcFont16, tx + 44 + textOffsetX, y1 + 18, c1);
        }
        else
          DrawMod.DrawTextColouredConsoleCenter(ref g, sText, this.game.MarcFont16, tx + 37, y1 + 18, c1);
      }
      else if (wideTab)
      {
        if ((double) sizeF.Width > 150.0)
        {
          string[] strArray = sText.Split(new char[1]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
          sText = "";
          int num = -1;
          int upperBound = strArray.GetUpperBound(0);
          for (int index = 0; index <= upperBound; ++index)
          {
            if ((double) g.MeasureString(sText + " " + strArray[index], DrawMod.TGame.MarcFont16).Width < 141.0)
            {
              if (sText.Length > 0)
                sText += " ";
              sText += strArray[index];
              num = index;
            }
            else
            {
              sText += "..";
              break;
            }
          }
        }
        DrawMod.DrawTextColouredConsole(ref g, sText, this.game.MarcFont16, tx + 44 + textOffsetX, y1 + 25, c1);
      }
      else
        DrawMod.DrawTextColouredConsoleCenter(ref g, sText, this.game.MarcFont16, tx + 37, y1 + 25, c1);
      Rectangle rectangle = new Rectangle(tx, y1, 200, 50);
      if (!wideTab)
        rectangle = new Rectangle(tx, y1, 75, 50);
      return rectangle;
    }

    public void dostuff()
    {
      this.currentview = this.game.EditObj.SetViewMode;
      this.ClearMouse();
      if (this.exitId > 0)
      {
        this.RemoveSubPart(this.exitId);
        this.exitId = 0;
      }
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      bool flag = false;
      if (this.game.EditObj.leftSideBarMode > 0)
        flag = true;
      Bitmap bitmap;
      Rectangle trect1;
      Rectangle rectangle;
      if (flag)
      {
        if (this.game.EditObj.leftSideBarMode == 1 & this.game.ScreenWidth >= 1435)
        {
          ref Graphics local1 = ref objgraphics;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_PAPER2);
          ref Bitmap local2 = ref bitmap;
          trect1 = new Rectangle(0, 0, 145, 90);
          Rectangle srcrect = trect1;
          rectangle = new Rectangle(0, 0, 145, 90);
          Rectangle destrect = rectangle;
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
        }
        else
        {
          ref Graphics local3 = ref objgraphics;
          bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_TEXTURE);
          ref Bitmap local4 = ref bitmap;
          rectangle = new Rectangle(35, 0, 145, 90);
          Rectangle srcrect = rectangle;
          trect1 = new Rectangle(0, 0, 145, 90);
          Rectangle destrect = trect1;
          DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
        }
        ref Graphics local5 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_MAINFRAME_LEFT);
        ref Bitmap local6 = ref bitmap;
        rectangle = new Rectangle(0, 148, 40, this.h);
        Rectangle srcrect1 = rectangle;
        trect1 = new Rectangle(145, 0, 40, this.h);
        Rectangle destrect1 = trect1;
        DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect1, destrect1);
      }
      ref Graphics local7 = ref objgraphics;
      bitmap = BitmapStore.GetBitmap(this.game.SE1_MAINFRAME_MIDDLE);
      ref Bitmap local8 = ref bitmap;
      rectangle = new Rectangle(10, 0, 60, 32);
      Rectangle srcrect2 = rectangle;
      trect1 = new Rectangle(120, 58, this.w - 595, 32);
      Rectangle destrect2 = trect1;
      DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect2, destrect2);
      this.dostuff2(objgraphics);
      int num1 = (int) Math.Round((double) this.game.ScreenWidth / 2.0 - 158.0);
      if (this.game.SelectX > -1 & this.game.SelectY > -1)
      {
        int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 370, 0, 0));
        int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
        int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 125, 0, 0));
        int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 382, 0, 0));
        int stringListById5 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 288, 0, 0));
        int num2 = this.game.Data.StringListObj[stringListById3].Length + 1;
        int idValue = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType;
        int num3 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].SpriteNr;
        DataClass data1 = DrawMod.TGame.Data;
        string str1 = "Zones";
        ref string local9 = ref str1;
        int libVar = data1.FindLibVar(ref local9, "SE_Data");
        int num4 = 0;
        int hexLibVarValue1 = DrawMod.TGame.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(libVar);
        if (this.game.Data.FOWOn & this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon < 1)
        {
          if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_LastLT(this.game.Data.Turn) == -1)
          {
            idValue = -1;
          }
          else
          {
            idValue = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_LastLT(this.game.Data.Turn);
            num3 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_LastSpr(this.game.Data.Turn);
          }
        }
        if (hexLibVarValue1 > 0)
          num4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, hexLibVarValue1, 13)));
        int num5 = (int) Math.Round((double) num4 / (double) num2);
        int eventPicOrigSlot1;
        int eventPicOrigSlot2;
        if (stringListById1 > -1)
        {
          eventPicOrigSlot1 = num5 >= 50 ? (num5 >= 500 ? (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 3))) : (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 2)))) : (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 1)));
          eventPicOrigSlot2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 6)));
        }
        if (idValue == -1)
        {
          eventPicOrigSlot2 = 61;
          eventPicOrigSlot1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData(0, 0, 1)));
        }
        int eventPic1 = this.game.Data.FindEventPic(eventPicOrigSlot1, "SE_Present");
        int x1 = this.w - 274;
        int y1 = 6;
        int num6;
        int num7;
        if (eventPic1 > -1)
        {
          int nr = this.game.Data.EventPicNr[eventPic1];
          num6 = 256;
          num7 = 80;
          ref Graphics local10 = ref objgraphics;
          bitmap = BitmapStore.GetBitmap(nr);
          ref Bitmap local11 = ref bitmap;
          rectangle = new Rectangle(0, 0, 256, 80);
          Rectangle srcrect3 = rectangle;
          trect1 = new Rectangle(x1, y1, 256, 80);
          Rectangle destrect3 = trect1;
          DrawMod.DrawSimplePart2(ref local10, ref local11, srcrect3, destrect3);
        }
        int eventPic2 = this.game.Data.FindEventPic(eventPicOrigSlot2, "SE_Present");
        if (eventPic2 > -1)
        {
          int nr = this.game.Data.EventPicNr[eventPic2];
          num6 = 256;
          num7 = 80;
          ref Graphics local12 = ref objgraphics;
          bitmap = BitmapStore.GetBitmap(nr);
          ref Bitmap local13 = ref bitmap;
          rectangle = new Rectangle(0, 0, 256, 80);
          Rectangle srcrect4 = rectangle;
          trect1 = new Rectangle(x1, y1, 256, 80);
          Rectangle destrect4 = trect1;
          DrawMod.DrawSimplePart2(ref local12, ref local13, srcrect4, destrect4);
        }
        ref Graphics local14 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(this.game.SE1_MAINFRAME_RIGHT2);
        ref Bitmap local15 = ref bitmap;
        int x2 = this.w - 475;
        DrawMod.DrawSimple(ref local14, ref local15, x2, 0);
        if (idValue > -1 & num3 > -1)
        {
          string name = this.game.Data.LandscapeTypeObj[idValue].Name;
          DataClass data2 = this.game.Data;
          string str2 = "hexName";
          ref string local16 = ref str2;
          int hexLibVarValue2 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].GetHexLibVarValue(data2.FindLibVar(ref local16, "SE_Data"));
          string str3 = "";
          if (hexLibVarValue2 > 0)
            str3 = this.game.Data.StringListObj[stringListById4].GetData(0, hexLibVarValue2, 1);
          if (idValue == 43)
            str3 = "";
          int integer = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(this.game.SelectX, this.game.SelectY, "SE_Data", "Zones"));
          string str4 = "";
          int num8 = 0;
          if (integer > 0)
          {
            str4 = this.game.Data.StringListObj[stringListById2].GetData(0, integer, 7);
            num8 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, integer, 2, "recon", 3)));
          }
          if (num8 < 1 & this.game.Data.FOWOn)
            str4 = "Unknown";
          string str5 = "";
          if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location > -1)
            str5 = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location].Name + " ";
          string str6;
          if (Operators.CompareString(Strings.Trim(Strings.LCase(str4)), Strings.Trim(Strings.LCase(str5)), false) == 0 & str4.Length > 0)
            str6 = str4 + " ";
          else if (str5.Length > 0)
            str6 = str5 + " ";
          else if (str3.Length > 0)
            str6 = str3 + " ";
          string tstring = str6 + "(" + Strings.Trim(Conversion.Str((object) this.game.SelectX)) + "," + Strings.Trim(Conversion.Str((object) this.game.SelectY)) + ")";
          int x3 = this.w - 475 + 103;
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, name, this.game.MarcFont16, x3, 35, this.game.seColGray);
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, tstring, this.game.MarcFont4, x3, 52, this.game.seColGray);
          string ttext = this.game.HandyFunctionsObj.GetLandscapeMouseOverText();
          if (str3.Length > 0)
            ttext = "Area Name: " + str3 + "\r\n" + ttext;
          if (str4.Length > 0)
            ttext = "Zone Name: " + str4 + "\r\n" + ttext;
          string ttitle = name + " (" + Strings.Trim(Conversion.Str((object) this.game.SelectX)) + "," + Strings.Trim(Conversion.Str((object) this.game.SelectY)) + ")" + "<FIXEDSYS>";
          rectangle = new Rectangle(x3 - 103, 18, 360, 65);
          trect1 = rectangle;
          this.AddMouse(ref trect1, ttitle, ttext);
          string str7 = "";
          int regime;
          if (this.game.EditObj.OrderType == 26)
          {
            if (this.game.EditObj.HisOwner[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY] > -1)
            {
              str7 = this.game.Data.RegimeObj[this.game.EditObj.HisOwner[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY]].Name;
              regime = this.game.EditObj.HisOwner[this.game.EditObj.MapSelected].Value[this.game.SelectX, this.game.SelectY];
            }
          }
          else if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1)
          {
            str7 = this.game.EventRelatedObj.Helper_GetOwnerNameForGuiDisplay(this.game.SelectX, this.game.SelectY);
            regime = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime;
          }
          int num9 = this.w - 67;
          int y2 = 13;
          int num10 = 54;
          int height = 68;
          if (Operators.CompareString(str7.ToLower(), "unknown", false) != 0)
          {
            int bannerSpriteNr = this.game.Data.RegimeObj[regime].BannerSpriteNr;
            ref Graphics local17 = ref objgraphics;
            bitmap = BitmapStore.GetBitmap(bannerSpriteNr);
            ref Bitmap local18 = ref bitmap;
            int x4 = num9;
            int y3 = y2;
            int w1 = num10;
            int h1 = height;
            double r1 = (double) ((float) this.game.Data.RegimeObj[regime].Red / (float) byte.MaxValue);
            double g1 = (double) ((float) this.game.Data.RegimeObj[regime].Green / (float) byte.MaxValue);
            double b1 = (double) ((float) this.game.Data.RegimeObj[regime].Blue / (float) byte.MaxValue);
            DrawMod.DrawScaledColorized2(ref local17, ref local18, x4, y3, w1, h1, 124, 210, (float) r1, (float) g1, (float) b1, 1f);
            int bannerSpriteNr2 = this.game.Data.RegimeObj[regime].BannerSpriteNr2;
            if (bannerSpriteNr2 > 0)
            {
              ref Graphics local19 = ref objgraphics;
              bitmap = BitmapStore.GetBitmap(bannerSpriteNr2);
              ref Bitmap local20 = ref bitmap;
              int x5 = num9;
              int y4 = y2;
              int w2 = num10;
              int h2 = height;
              double r2 = (double) ((float) this.game.Data.RegimeObj[regime].Red2 / (float) byte.MaxValue);
              double g2 = (double) ((float) this.game.Data.RegimeObj[regime].Green2 / (float) byte.MaxValue);
              double b2 = (double) ((float) this.game.Data.RegimeObj[regime].Blue2 / (float) byte.MaxValue);
              DrawMod.DrawScaledColorized2(ref local19, ref local20, x5, y4, w2, h2, 124, 210, (float) r2, (float) g2, (float) b2, 1f);
            }
            int hqSpriteNr2 = this.game.Data.RegimeObj[regime].HQSpriteNr2;
            if (hqSpriteNr2 > 0)
            {
              ref Graphics local21 = ref objgraphics;
              bitmap = BitmapStore.GetBitmap(hqSpriteNr2);
              ref Bitmap local22 = ref bitmap;
              int x6 = num9 + 4;
              int y5 = y2 + 18;
              double r3 = (double) ((float) this.game.Data.RegimeObj[regime].Red3 / (float) byte.MaxValue) - 1.0;
              double g3 = (double) ((float) this.game.Data.RegimeObj[regime].Green3 / (float) byte.MaxValue) - 1.0;
              double b3 = (double) ((float) this.game.Data.RegimeObj[regime].Blue3 / (float) byte.MaxValue) - 1.0;
              DrawMod.Draw(ref local21, ref local22, x6, y5, (float) r3, (float) g3, (float) b3, 0.95f);
            }
            rectangle = new Rectangle(num9 - 20, y2, num10 + 60, height);
            trect1 = rectangle;
            this.AddMouse(ref trect1, "", "Hex is controlled by " + this.game.Data.RegimeObj[regime].Name);
          }
        }
        else
        {
          string tstring1 = "Unknown Landscape";
          string str8;
          string tstring2 = str8 + "(" + Strings.Trim(Conversion.Str((object) this.game.SelectX)) + "," + Strings.Trim(Conversion.Str((object) this.game.SelectY)) + ")";
          int x7 = this.w - 475 + 103;
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, tstring2, this.game.MarcFont16, x7, 35, this.game.seColGray);
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, tstring1, this.game.MarcFont4, x7, 52, this.game.seColGray);
        }
      }
      ref Graphics local23 = ref objgraphics;
      bitmap = BitmapStore.GetBitmap(this.game.SE1_MAINFRAME_LEFT2);
      ref Bitmap local24 = ref bitmap;
      DrawMod.DrawSimple(ref local23, ref local24, 0, 0);
      if (this.exitId < 1)
      {
        if (this.game.EditObj.GuiDown)
        {
          SubPartClass tsubpart = (SubPartClass) new SEButtonPartClass(this.game.SE1_ARROW3, "Show the bottom bar.", 45, 20);
          this.exitId = this.AddSubPart(ref tsubpart, 8, 53, 45, 20, 1);
        }
        else
        {
          SubPartClass tsubpart = (SubPartClass) new SEButtonPartClass(this.game.SE1_ARROW4, "Hide the bottom bar.", 45, 20);
          this.exitId = this.AddSubPart(ref tsubpart, 8, 53, 45, 20, 1);
        }
      }
      if (!this.game.EditObj.GuiDown)
      {
        int tx1 = (int) Math.Round((double) (this.w - 1280) / 2.0);
        if (this.w <= 1280)
          tx1 += 56;
        bool active1 = false;
        if (this.game.EditObj.SetViewModeExtraNr == 1)
          active1 = true;
        string nameForGuiDisplay1 = this.game.EventRelatedObj.Helper_GetZoneNameForGuiDisplay(this.game.SelectX, this.game.SelectY);
        Rectangle trect2 = this.DrawOneTab(objgraphics, true, active1, tx1, "ZONE", nameForGuiDisplay1, -1, 16, tMousingOverNow: (this.MouseOverWhichTab == 51));
        this.AddMouse(ref trect2, "", "Zone bottom tab", 51);
        int tx2 = tx1 + 200;
        bool active2 = false;
        if (this.game.EditObj.SetViewModeExtraNr == 0)
          active2 = true;
        bool grayedOut = false;
        int spriteSlot1 = -1;
        int spriteOffsetY1 = 0;
        string sText1;
        if (this.game.EditObj.UnitSelected > -1)
        {
          Coordinate reconMinusHide;
          if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn | this.game.Data.Round == 0 | !this.game.Data.FOWOn)
            reconMinusHide.x = 3;
          else
            reconMinusHide = this.game.HandyFunctionsObj.GetReconMinusHide(this.game.EditObj.UnitSelected, this.game.Data.Turn);
          if (reconMinusHide.x >= 2)
          {
            int historical = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical;
            if (this.game.Data.HistoricalUnitObj[historical].SmallGfx > -1)
              spriteSlot1 = this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[historical].SmallGfx];
            else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
            {
              spriteSlot1 = this.game.Data.RegimeObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime].HQSpriteNr2;
              spriteOffsetY1 = 13;
            }
            sText1 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Name;
          }
          else
            sText1 = "Unknown Unit";
        }
        else
        {
          sText1 = "No Unit selected";
          grayedOut = true;
        }
        trect2 = this.DrawOneTab(objgraphics, true, active2, tx2, "UNIT", sText1, spriteSlot1, -1, grayedOut: grayedOut, textOffsetX: -6, spriteOffsetY: spriteOffsetY1, tMousingOverNow: (this.MouseOverWhichTab == 6));
        this.AddMouse(ref trect2, "", "Unit bottom tab", 6);
        int tx3 = tx2 + 200;
        bool active3 = false;
        int spriteOffsetY2 = 13;
        if (this.game.EditObj.SetViewModeExtraNr == 2)
          active3 = true;
        string nameForGuiDisplay2 = this.game.EventRelatedObj.Helper_GetOwnerNameForGuiDisplay(this.game.SelectX, this.game.SelectY);
        int spriteSlot2 = !(Operators.CompareString(nameForGuiDisplay2.ToLower(), "unknown", false) == 0 | Operators.CompareString(nameForGuiDisplay2.ToLower(), "unclear", false) == 0 | Operators.CompareString(nameForGuiDisplay2.ToLower(), "none", false) == 0 | this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime == -1) ? this.game.Data.RegimeObj[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime].HQSpriteNr2 : -1;
        trect2 = this.DrawOneTab(objgraphics, true, active3, tx3, "REGIME", nameForGuiDisplay2, spriteSlot2, -1, textOffsetX: -2, spriteOffsetY: spriteOffsetY2, tMousingOverNow: (this.MouseOverWhichTab == 52));
        this.AddMouse(ref trect2, "", "Regime bottom tab", 52);
        int tx4 = tx3 + 200;
        if (this.game.ScreenWidth >= 1530)
        {
          bool active4 = false;
          if (this.game.EditObj.SetViewModeExtraNr == 3)
            active4 = true;
          string sText2 = "ASSETS";
          trect2 = this.DrawOneTab(objgraphics, true, active4, tx4, "", sText2, -1, 17, tMousingOverNow: (this.MouseOverWhichTab == 53));
          this.AddMouse(ref trect2, "", "Zone Assets bottom tab", 53);
          int tx5 = tx4 + 200;
          bool active5 = false;
          if (this.game.EditObj.SetViewModeExtraNr == 4)
            active5 = true;
          string sText3 = "ITEMS";
          trect2 = this.DrawOneTab(objgraphics, true, active5, tx5, "", sText3, -1, 10, tMousingOverNow: (this.MouseOverWhichTab == 54));
          this.AddMouse(ref trect2, "", "Zone Items bottom tab", 54);
          num1 = tx5 + 200;
        }
        else
        {
          bool active6 = false;
          if (this.game.EditObj.SetViewModeExtraNr == 3)
            active6 = true;
          string sText4 = "ASSETS";
          trect2 = this.DrawOneTab(objgraphics, false, active6, tx4, "", sText4, -1, 16, tMousingOverNow: (this.MouseOverWhichTab == 53));
          this.AddMouse(ref trect2, "", "Zone Assets bottom tab", 53);
          int tx6 = tx4 + 75;
          bool active7 = false;
          if (this.game.EditObj.SetViewModeExtraNr == 4)
            active7 = true;
          string sText5 = "ITEMS";
          trect2 = this.DrawOneTab(objgraphics, false, active7, tx6, "", sText5, -1, 16, tMousingOverNow: (this.MouseOverWhichTab == 54));
          this.AddMouse(ref trect2, "", "Zone Items bottom tab", 54);
          num1 = tx6 + 75;
        }
      }
      if (Information.IsNothing((object) objgraphics))
        return;
      objgraphics.Dispose();
      objgraphics = (Graphics) null;
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.game.EditObj.BattleTimerActive)
        return windowReturnClass;
      if ((nr == 187 | nr == 191 | nr == 107) & this.game.EditObj.Zoom < 1)
        windowReturnClass = this.actionZoomIn();
      if ((nr == 189 | nr == 219 | nr == 109) & this.game.EditObj.Zoom > -1)
        windowReturnClass = this.actionZoomOut();
      bool flag = false;
      if (nr == 27 & this.tab1 > -1 & this.game.EditObj.SetViewMode2 < 1)
        flag = true;
      if (nr == 73 | flag)
      {
        this.game.EditObj.udsUnitOrderMode = 0;
        ScreenClass screeny = this.formref.Screeny;
        Type type = typeof (MapWindowClass2);
        ref Type local = ref type;
        MapWindowClass2 window = (MapWindowClass2) screeny.GetWindow(ref local);
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
      switch (nr)
      {
        case 49:
          this.game.EditObj.layerUnits = !this.game.EditObj.layerUnits;
          this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
          if (!this.game.EditObj.layerUnits)
            this.game.EditObj.UnitSelected = -1;
          windowReturnClass.AddCommand(4, 12);
          windowReturnClass.AddCommand(4, 67);
          windowReturnClass.AddCommand(4, 68);
          windowReturnClass.AddCommand(4, 9);
          windowReturnClass.AddCommand(4, 69);
          this.dostuff();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        case 50:
          this.game.EditObj.ShowLabel = !this.game.EditObj.ShowLabel;
          this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
          windowReturnClass.AddCommand(4, 12);
          windowReturnClass.AddCommand(4, 67);
          windowReturnClass.AddCommand(4, 68);
          windowReturnClass.AddCommand(4, 9);
          this.dostuff();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        case 51:
          this.game.EditObj.HideAS = !this.game.EditObj.HideAS;
          this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
          windowReturnClass.AddCommand(4, 12);
          windowReturnClass.AddCommand(4, 67);
          windowReturnClass.AddCommand(4, 68);
          windowReturnClass.AddCommand(4, 9);
          this.dostuff();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        case 52:
          this.game.EditObj.HexRasterOn = !this.game.EditObj.HexRasterOn;
          this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
          windowReturnClass.AddCommand(4, 12);
          windowReturnClass.AddCommand(4, 67);
          windowReturnClass.AddCommand(4, 68);
          windowReturnClass.AddCommand(4, 9);
          this.dostuff();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        case 53:
          this.game.EditObj.RegimeColoring = !this.game.EditObj.RegimeColoring;
          this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
          windowReturnClass.AddCommand(4, 12);
          windowReturnClass.AddCommand(4, 67);
          windowReturnClass.AddCommand(4, 68);
          windowReturnClass.AddCommand(4, 9);
          this.dostuff();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        case 54:
          this.game.HandyFunctionsObj.RedimTempSup(9999);
          this.game.EditObj.ShowLISRange = !this.game.EditObj.ShowLISRange;
          if (this.game.EditObj.ShowLISRange)
          {
            this.game.EditObj.ShowHQPower = false;
            this.game.EditObj.ShowAirRange = false;
          }
          this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
          windowReturnClass.AddCommand(4, 12);
          windowReturnClass.AddCommand(4, 67);
          windowReturnClass.AddCommand(4, 68);
          windowReturnClass.AddCommand(4, 9);
          this.dostuff();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        case 65:
          this.game.EditObj.udsUnitOrderMode = 11;
          ScreenClass screeny1 = this.formref.Screeny;
          Type type1 = typeof (MapWindowClass2);
          ref Type local1 = ref type1;
          MapWindowClass2 window1 = (MapWindowClass2) screeny1.GetWindow(ref local1);
          if (!Information.IsNothing((object) window1))
          {
            this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
            if (this.game.EditObj.UnitSelected > -1)
              window1.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
            else
              window1.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
            windowReturnClass.AddCommand(4, 12);
            windowReturnClass.AddCommand(4, 67);
            windowReturnClass.AddCommand(4, 68);
            windowReturnClass.AddCommand(4, 9);
          }
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        case 71:
          this.game.EditObj.udsUnitOrderMode = 48;
          ScreenClass screeny2 = this.formref.Screeny;
          Type type2 = typeof (MapWindowClass2);
          ref Type local2 = ref type2;
          MapWindowClass2 window2 = (MapWindowClass2) screeny2.GetWindow(ref local2);
          if (!Information.IsNothing((object) window2))
          {
            this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
            if (this.game.EditObj.UnitSelected > -1)
              window2.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
            else
              window2.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
            windowReturnClass.AddCommand(4, 12);
            windowReturnClass.AddCommand(4, 67);
            windowReturnClass.AddCommand(4, 68);
            windowReturnClass.AddCommand(4, 9);
          }
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        case 76:
          this.game.EditObj.layerLisAvailable = !this.game.EditObj.layerLisAvailable;
          this.game.EditObj.layerLisUsed = false;
          this.game.EditObj.layerLisTotal = false;
          this.game.EditObj.layerLisBottlenecks = false;
          this.game.EditObj.layerLisPreview = false;
          windowReturnClass.AddCommand(4, 12);
          windowReturnClass.AddCommand(4, 67);
          windowReturnClass.AddCommand(4, 68);
          windowReturnClass.AddCommand(4, 9);
          this.dostuff();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        case 77:
          this.game.EditObj.udsUnitOrderMode = 1;
          ScreenClass screeny3 = this.formref.Screeny;
          Type type3 = typeof (MapWindowClass2);
          ref Type local3 = ref type3;
          MapWindowClass2 window3 = (MapWindowClass2) screeny3.GetWindow(ref local3);
          if (!Information.IsNothing((object) window3))
          {
            this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
            if (this.game.EditObj.UnitSelected > -1)
              window3.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
            else
              window3.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
            windowReturnClass.AddCommand(4, 12);
            windowReturnClass.AddCommand(4, 67);
            windowReturnClass.AddCommand(4, 68);
            windowReturnClass.AddCommand(4, 9);
          }
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        case 80:
          this.game.EditObj.layerLisAvailable = false;
          this.game.EditObj.layerLisUsed = false;
          this.game.EditObj.layerLisTotal = false;
          this.game.EditObj.layerLisBottlenecks = false;
          this.game.EditObj.layerLisPreview = !this.game.EditObj.layerLisPreview;
          this.game.EditObj.layerLisOnlyAssetId = -1;
          if (!this.game.EditObj.layerLisPreview)
          {
            int mapWidth = this.game.Data.MapObj[0].MapWidth;
            for (int index1 = 0; index1 <= mapWidth; ++index1)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index2 = 0; index2 <= mapHeight; ++index2)
              {
                int index3 = 0;
                do
                {
                  this.game.Data.MapObj[0].HexObj[index1, index2].tempPreviewLIS[index3] = 0;
                  this.game.Data.MapObj[0].HexObj[index1, index2].tempPreviewAssetLIS[index3] = 0;
                  ++index3;
                }
                while (index3 <= 8);
              }
            }
          }
          else
            this.game.ProcessingObj.LIS_SetNetwork(false, true);
          windowReturnClass.AddCommand(4, 12);
          windowReturnClass.AddCommand(4, 67);
          windowReturnClass.AddCommand(4, 68);
          windowReturnClass.AddCommand(4, 9);
          this.dostuff();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        case 82:
          int enr = (int) Math.Round((double) this.game.Data.RuleVar[705]);
          this.game.EditObj.UDSpopupText = "";
          this.game.EditObj.UDSAddInput("ROADCHOICE", 0);
          if (enr > 0)
            this.game.EventRelatedObj.DoCheckSpecificEvent(enr);
          if (this.game.EditObj.UDSpopupText.Length > 1)
          {
            this.game.EditObj.UDSpushedPopupText = this.game.EditObj.UDSpopupText;
            this.game.EditObj.UDSpopupText = "";
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          this.game.EditObj.udsUnitOrderMode = 36;
          ScreenClass screeny4 = this.formref.Screeny;
          Type type4 = typeof (MapWindowClass2);
          ref Type local4 = ref type4;
          MapWindowClass2 window4 = (MapWindowClass2) screeny4.GetWindow(ref local4);
          if (!Information.IsNothing((object) window4))
          {
            this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
            window4.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
            windowReturnClass.AddCommand(4, 12);
            windowReturnClass.AddCommand(4, 67);
            windowReturnClass.AddCommand(4, 68);
            windowReturnClass.AddCommand(4, 9);
          }
          this.dostuff();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        case 83:
          this.game.EditObj.udsUnitOrderMode = 18;
          ScreenClass screeny5 = this.formref.Screeny;
          Type type5 = typeof (MapWindowClass2);
          ref Type local5 = ref type5;
          MapWindowClass2 window5 = (MapWindowClass2) screeny5.GetWindow(ref local5);
          if (!Information.IsNothing((object) window5))
          {
            this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
            if (this.game.EditObj.UnitSelected > -1)
              window5.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
            else
              window5.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
            windowReturnClass.AddCommand(4, 12);
            windowReturnClass.AddCommand(4, 67);
            windowReturnClass.AddCommand(4, 68);
            windowReturnClass.AddCommand(4, 9);
          }
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        case 84:
          this.game.EditObj.udsUnitOrderMode = 53;
          ScreenClass screeny6 = this.formref.Screeny;
          Type type6 = typeof (MapWindowClass2);
          ref Type local6 = ref type6;
          MapWindowClass2 window6 = (MapWindowClass2) screeny6.GetWindow(ref local6);
          if (!Information.IsNothing((object) window6))
          {
            this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
            if (this.game.EditObj.UnitSelected > -1)
              window6.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
            else
              window6.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
            windowReturnClass.AddCommand(4, 12);
            windowReturnClass.AddCommand(4, 67);
            windowReturnClass.AddCommand(4, 68);
            windowReturnClass.AddCommand(4, 9);
          }
          this.dostuff();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        case 88:
          this.game.EditObj.udsUnitOrderMode = 14;
          ScreenClass screeny7 = this.formref.Screeny;
          Type type7 = typeof (MapWindowClass2);
          ref Type local7 = ref type7;
          MapWindowClass2 window7 = (MapWindowClass2) screeny7.GetWindow(ref local7);
          if (!Information.IsNothing((object) window7))
          {
            this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
            if (this.game.EditObj.UnitSelected > -1)
              window7.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
            else
              window7.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
            windowReturnClass.AddCommand(4, 12);
            windowReturnClass.AddCommand(4, 67);
            windowReturnClass.AddCommand(4, 68);
            windowReturnClass.AddCommand(4, 9);
          }
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        case 89:
          this.game.EditObj.udsUnitOrderMode = 33;
          ScreenClass screeny8 = this.formref.Screeny;
          Type type8 = typeof (MapWindowClass2);
          ref Type local8 = ref type8;
          MapWindowClass2 window8 = (MapWindowClass2) screeny8.GetWindow(ref local8);
          if (!Information.IsNothing((object) window8))
          {
            this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
            if (this.game.EditObj.UnitSelected > -1)
              window8.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
            else
              window8.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
            windowReturnClass.AddCommand(4, 12);
            windowReturnClass.AddCommand(4, 67);
            windowReturnClass.AddCommand(4, 68);
            windowReturnClass.AddCommand(4, 9);
          }
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        case 90:
          this.game.EditObj.udsUnitOrderMode = 54;
          this.game.EditObj.OrderSubType = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(this.game.SelectX, this.game.SelectY, "SE_Data", "Zones"));
          ScreenClass screeny9 = this.formref.Screeny;
          Type type9 = typeof (MapWindowClass2);
          ref Type local9 = ref type9;
          MapWindowClass2 window9 = (MapWindowClass2) screeny9.GetWindow(ref local9);
          windowReturnClass.AddCommand(1, 118);
          if (!Information.IsNothing((object) window9))
          {
            this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
            if (this.game.EditObj.UnitSelected > -1)
              window9.UdsClickUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Map, true);
            else
              window9.UdsClickUnit(this.game.SelectX, this.game.SelectY, 0, true);
            windowReturnClass.AddCommand(4, 12);
            windowReturnClass.AddCommand(4, 67);
            windowReturnClass.AddCommand(4, 68);
            windowReturnClass.AddCommand(4, 9);
          }
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        default:
          return windowReturnClass;
      }
    }

    public void dostuff2(Graphics g)
    {
      SizeF sizeF1 = new SizeF();
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
      int index1 = this.game.EditObj.UnitSelected;
      if (this.game.EditObj.OrderUnit > -1 & this.game.EditObj.OrderType > 0)
        index1 = this.game.EditObj.OrderUnit;
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0 + 830.0 + 64.0 - 128.0);
      string str1 = "";
      string str2 = "";
      int num2 = -1;
      int num3 = -1;
      int regime = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime;
      if (index1 > -1)
      {
        if (this.game.Data.UnitObj[index1].IsHQ)
        {
          if (this.game.Data.UnitObj[index1].Historical > -1)
          {
            if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index1].Historical].Type == 5)
              num3 = index1;
            else if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index1].Historical].Type == 8)
            {
              num3 = index1;
              num2 = index1;
            }
          }
        }
        else if (this.game.Data.UnitObj[index1].HQ > -1 && this.game.Data.UnitObj[this.game.Data.UnitObj[index1].HQ].Historical > -1)
        {
          if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.Data.UnitObj[index1].HQ].Historical].Type == 5)
            num3 = this.game.Data.UnitObj[index1].HQ;
          else if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.Data.UnitObj[index1].HQ].Historical].Type == 8)
          {
            num2 = this.game.Data.UnitObj[index1].HQ;
            num3 = this.game.Data.UnitObj[index1].HQ;
          }
        }
      }
      bool flag1 = false;
      bool flag2 = false;
      if (this.game.EditObj.OrderType == 36)
      {
        int enr = (int) Math.Round((double) this.game.Data.RuleVar[703]);
        if (enr > 0)
        {
          this.game.EventRelatedObj.DoCheckSpecificEvent(enr);
          if (this.game.EditObj.OrderSubType <= 2)
            str1 = this.game.Data.RoadTypeObj[this.game.EditObj.OrderSubType].Name + " Construction Mode";
          else if (this.game.EditObj.OrderSubType == 8)
            str1 = " Road Demolition Mode";
          str2 = this.game.EditObj.udsOrderBarFeedbackString;
          Color color;
          if (this.game.EditObj.udsOrderBarFeedbackColor <= 1)
          {
            color = Color.FromArgb((int) byte.MaxValue, 0, (int) byte.MaxValue, 0);
            flag1 = true;
          }
          else if (this.game.EditObj.udsOrderBarFeedbackColor == 2)
          {
            color = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, 0);
            flag2 = true;
          }
          else if (this.game.EditObj.udsOrderBarFeedbackColor == 3)
            color = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 0);
        }
      }
      else if (this.game.EditObj.udsUnitOrderMode == 0)
        str1 = "Inspection Mode";
      else if (this.game.EditObj.udsUnitOrderMode == 1 | this.game.EditObj.udsUnitOrderMode == 48)
      {
        str1 = "Move Mode";
        if (this.game.EditObj.udsUnitOrderMode == 48)
          str1 = "Group Move Mode";
        if (this.game.EditObj.OrderUnit > -1 & this.game.EditObj.MouseOverX > -1 & this.game.EditObj.MouseOverY > -1 && this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Regime == this.game.Data.Turn)
        {
          if (this.game.EditObj.TempValue[0].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY] < 999)
            str2 = this.game.EditObj.TempValue[0].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY].ToString() + " AP";
          else if (this.game.EditObj.TempValue2[0].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY] < 999 & this.game.EditObj.TempValue2[0].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY] > 0)
          {
            str2 = "Out of range - " + this.game.EditObj.TempValue2[0].Value[this.game.EditObj.MouseOverX, this.game.EditObj.MouseOverY].ToString() + " AP";
            flag2 = true;
          }
          else
          {
            str2 = "Out of range / Not enough AP";
            flag1 = true;
          }
          bool flag3 = false;
          int mouseOverX = this.game.EditObj.MouseOverX;
          int mouseOverY = this.game.EditObj.MouseOverY;
          if (mouseOverX > -1 && this.game.HandyFunctionsObj.Distance(mouseOverX, mouseOverY, 0, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y, 0, 1) == 1)
          {
            int index2 = 0;
            do
            {
              if (this.game.EditObj.TempAttack[0].Value[mouseOverX, mouseOverY, index2])
                flag3 = true;
              ++index2;
            }
            while (index2 <= 5);
            if (flag3)
            {
              flag1 = false;
              flag2 = false;
              str2 = "Right click to Attack!";
            }
          }
        }
      }
      else if (this.game.EditObj.udsUnitOrderMode == 18)
      {
        str1 = "Strategic Move Mode";
        if (this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn)
        {
          int sizeForAirBridge = this.game.HandyFunctionsObj.GetHighestSizeForAirBridge(this.game.EditObj.UnitSelected);
          int mouseOverX = this.game.EditObj.MouseOverX;
          int mouseOverY = this.game.EditObj.MouseOverY;
          str1 = str1 + " - Weight: " + this.game.HandyFunctionsObj.GetUnitWeight(this.game.EditObj.UnitSelected, includeLisWeight: true).ToString();
          if (mouseOverX > -1 & mouseOverY > -1)
            str1 = str1 + " / " + this.game.EditObj.TempValue[0].Value[mouseOverX, mouseOverY].ToString();
          bool flag4 = false;
          if (mouseOverX > -1 & mouseOverY > -1 & this.game.EventRelatedObj.Helper_AirEnabled())
          {
            Coordinate coordinate = this.game.EditObj.TempCameFrom[0].Value[mouseOverX, mouseOverY];
            if (coordinate.onmap && this.game.HandyFunctionsObj.HexFacing(mouseOverX, mouseOverY, 0, coordinate.x, coordinate.y, 0) == -1 & coordinate.data1 > 0 | coordinate.data2 > 0)
            {
              int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 534, 0, 0));
              int length = this.game.Data.StringListObj[stringListById2].Length;
              for (int index3 = 0; index3 <= length; ++index3)
              {
                if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 0])) == this.game.Data.RegimeObj[this.game.Data.Turn].id)
                {
                  if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 1])) == coordinate.x && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 2])) == coordinate.y && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 3])) == mouseOverX && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 4])) == mouseOverY)
                  {
                    flag4 = true;
                    string letter = this.game.HandyFunctionsObj.CovertNumberToLetter((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 8])));
                    str1 = str1 + ", Air Bridge Points used: " + this.game.HandyFunctionsObj.GetUnitWeight(this.game.EditObj.UnitSelected, includeLisWeight: true).ToString() + "/" + coordinate.data1.ToString() + " (" + letter + "), " + "Dam: " + ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 7]))).ToString() + ", " + "Max Size: " + sizeForAirBridge.ToString() + " / " + ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 10]))).ToString();
                  }
                  if (!flag4 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 3])) == coordinate.x && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 4])) == coordinate.y && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 1])) == mouseOverX && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 2])) == mouseOverY)
                  {
                    flag4 = true;
                    string letter = this.game.HandyFunctionsObj.CovertNumberToLetter((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 8])));
                    str1 = str1 + ", Air Bridge Points used: " + this.game.HandyFunctionsObj.GetUnitWeight(this.game.EditObj.UnitSelected, includeLisWeight: true).ToString() + "/" + coordinate.data1.ToString() + " (" + letter + "), " + "Dam: " + ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 7]))).ToString() + ", " + "Max Size: " + sizeForAirBridge.ToString() + " / " + ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index3, 10]))).ToString();
                  }
                }
              }
            }
          }
          if (!flag4)
          {
            string str3 = "";
            string str4 = "";
            int num4 = 0;
            int num5 = 0;
            int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 534, 0, 0));
            if (stringListById3 > 0)
            {
              int length = this.game.Data.StringListObj[stringListById3].Length;
              for (int index4 = 0; index4 <= length; ++index4)
              {
                if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index4, 0])) == this.game.Data.RegimeObj[this.game.Data.Turn].id)
                {
                  if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index4, 1])) == mouseOverX && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index4, 2])) == mouseOverY)
                  {
                    string letter = this.game.HandyFunctionsObj.CovertNumberToLetter((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index4, 8])));
                    if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index4, 5])) > num4)
                    {
                      num4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index4, 5]));
                      str3 = letter;
                    }
                    if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index4, 10])) > num5)
                    {
                      num5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index4, 10]));
                      str4 = letter;
                    }
                  }
                  if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index4, 3])) == mouseOverX && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index4, 4])) == mouseOverY)
                  {
                    string letter = this.game.HandyFunctionsObj.CovertNumberToLetter((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index4, 8])));
                    if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index4, 5])) > num4)
                    {
                      num4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index4, 5]));
                      str3 = letter;
                    }
                    if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index4, 10])) > num5)
                    {
                      num5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[index4, 10]));
                      str4 = letter;
                    }
                  }
                }
              }
            }
            if (num5 > 0)
              str1 = str1 + ", Best Airbr. Pts in Hex: " + num4.ToString() + " (" + str3 + "), " + "Best Airbr. Max Size in Hex: " + sizeForAirBridge.ToString() + " / " + num5.ToString() + " (" + str4 + ") ";
          }
        }
      }
      else if (this.game.EditObj.udsUnitOrderMode == 11)
        str1 = "Ranged Attack Mode";
      else if (this.game.EditObj.udsUnitOrderMode == 14)
        str1 = "Air Attack Mode";
      else if (this.game.EditObj.udsUnitOrderMode == 55)
        str1 = "Air Bridge Mode";
      else if (this.game.EditObj.udsUnitOrderMode == 33)
        str1 = "Air Recon Mode";
      else if (this.game.EditObj.udsUnitOrderMode == 53)
        str1 = "Traffic Signs Mode";
      else if (this.game.EditObj.udsUnitOrderMode == 54)
        str1 = "Zone Border Mode - Drawing Hexes for ZONE '" + this.game.Data.StringListObj[stringListById1].GetData(0, this.game.EditObj.OrderSubType, 7) + "'";
      string str5 = str1.ToUpper();
      if (str2.Length > 0)
        str5 = str5 + ": " + str2;
      SizeF sizeF2 = g.MeasureString(str5, DrawMod.TGame.MarcFont16);
      ref Graphics local1 = ref g;
      Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_BLACKGRADIENT);
      ref Bitmap local2 = ref bitmap;
      int x = (int) Math.Round((double) ((float) this.w - (float) (270.0 + (double) sizeF2.Width + 100.0)));
      int w = (int) Math.Round((double) (sizeF2.Width + 100f));
      DrawMod.DrawScaled(ref local1, ref local2, x, 3, w, 28, true);
      Color c = !flag1 ? (!flag2 ? this.game.seColWhite : Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 175, 100)) : Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 100, 100);
      DrawMod.DrawTextColouredConsole(ref g, str5, this.game.MarcFont16, (int) Math.Round((double) ((float) this.w - (float) (270.0 + (double) sizeF2.Width + 20.0))), 7, c);
    }

    public void DoTabs1(ref Graphics g, bool Active = false)
    {
      SizeF sizeF = new SizeF();
    }

    public void DoTabs1B(ref Graphics g, bool Active = false)
    {
      SizeF sizeF = new SizeF();
    }

    public void DoTabs2(ref Graphics g, bool Active = false)
    {
      SizeF sizeF = new SizeF();
    }

    public void DoTabs2B(ref Graphics g, bool Active = false)
    {
      SizeF sizeF = new SizeF();
    }

    public void DoTabs3(ref Graphics g, bool Active = false)
    {
      SizeF sizeF1 = new SizeF();
      if (this.game.Data.Round == 0)
        return;
      int num = (int) Math.Round((double) this.game.ScreenWidth / 2.0 - 480.0);
      if (!Active)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local2 = ref bitmap;
        int x = num + 340 + 420;
        DrawMod.Draw(ref local1, ref local2, x, 66, -0.1f, -0.1f, -0.1f, 1f);
      }
      else
      {
        ref Graphics local3 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local4 = ref bitmap;
        int x = num + 340 + 420;
        DrawMod.DrawSimple(ref local3, ref local4, x, 66);
      }
      string str = "COMBAT SETUP";
      SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont16);
      int x1 = (int) Math.Round((double) ((float) (num + 420 + 340 + 91) - sizeF2.Width / 2f));
      int y = 66;
      DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, x1, y + 4, Color.White);
      Rectangle trect = new Rectangle(num + 340 + 420, y, 182, 24);
      this.AddMouse(ref trect, "", "Click to see the combat setup. [F12]", 3);
      this.tab3 = this.MouseCounter;
    }

    public void DoTabs4(ref Graphics g, bool Active = false)
    {
      SizeF sizeF1 = new SizeF();
      int num = (int) Math.Round((double) this.game.ScreenWidth / 2.0 - 480.0);
      if (!Active)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local2 = ref bitmap;
        int x = num + 0 + 420;
        DrawMod.Draw(ref local1, ref local2, x, 66, -0.1f, -0.1f, -0.1f, 1f);
      }
      else
      {
        ref Graphics local3 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local4 = ref bitmap;
        int x = num + 0 + 420;
        DrawMod.DrawSimple(ref local3, ref local4, x, 66);
      }
      string str = "OFFICER INFO";
      SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont16);
      int x1 = (int) Math.Round((double) ((float) (num + 420 + 0 + 91) - sizeF2.Width / 2f));
      int y = 66;
      DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, x1, y + 4, Color.White);
      Rectangle trect = new Rectangle(num + 0 + 420, y, 182, 24);
      this.AddMouse(ref trect, "", "Click to see the info on the officer with this unit. [F9]", 4);
      this.tab4 = this.MouseCounter;
    }

    public void DoTabs4B(ref Graphics g, bool Active = false)
    {
      SizeF sizeF1 = new SizeF();
      int num = (int) Math.Round((double) this.game.ScreenWidth / 2.0 - 480.0);
      if (!Active)
      {
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local2 = ref bitmap;
        int x = num + 170 + 420;
        DrawMod.Draw(ref local1, ref local2, x, 66, -0.1f, -0.1f, -0.1f, 1f);
      }
      else
      {
        ref Graphics local3 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local4 = ref bitmap;
        int x = num + 170 + 420;
        DrawMod.DrawSimple(ref local3, ref local4, x, 66);
      }
      string str = "OFFICER INFO";
      SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont16);
      int x1 = (int) Math.Round((double) ((float) (num + 420 + 170 + 91) - sizeF2.Width / 2f));
      int y = 66;
      DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont16, x1, y + 4, Color.White);
      Rectangle trect = new Rectangle(num + 170 + 420, y, 182, 24);
      this.AddMouse(ref trect, "", "Click to see the info on the officer with this unit. [F9]", 4);
      this.tab4 = this.MouseCounter;
    }

    public override void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter <= -1)
        return;
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index] && Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
        {
          this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = "";
          this.game.EditObj.TipText = this.SubPartList[index].Descript;
          break;
        }
      }
    }

    public override WindowReturnClass HandleMouseMove(int x, int y)
    {
      WindowReturnClass windowReturnClass = base.HandleMouseMove(x, y);
      if (y > 18 && (double) this.w / 2.0 - 500.0 < (double) x & (double) x < (double) this.w / 2.0 + 500.0)
        windowReturnClass.NoMouseClickBelow = true;
      int num = -1;
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (this.MouseData[mouseCounter] > 0 && x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height)
          num = this.MouseData[mouseCounter];
      }
      if (num > 0)
      {
        if (this.MouseOverWhichTab != num)
        {
          if (this.game.EmpireStyle)
            SoundMod.PlayAWave(this.game.AppPath + "sound/interface/mouseover.wav", ref this.game.EditObj);
          this.MouseOverWhichTab = num;
          this.dostuff();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      else if (this.MouseOverWhichTab > 0)
      {
        this.MouseOverWhichTab = -1;
        this.dostuff();
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      return windowReturnClass;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      int[,] numArray = new int[this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1, this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight + 1];
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.game.EditObj.BattleTimerActive)
        return windowReturnClass;
      if (y > 18 && (double) this.w / 2.0 - 500.0 < (double) x & (double) x < (double) this.w / 2.0 + 500.0)
        windowReturnClass.NoMouseClickBelow = true;
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (this.MouseData[mouseCounter] > 0 && x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height)
        {
          switch (this.MouseData[mouseCounter])
          {
            case 1:
              if (this.game.EditObj.SetViewMode == 0)
                this.game.EditObj.SubformationListMode = !this.game.EditObj.SubformationListMode;
              this.game.EditObj.SetViewMode = 0;
              this.dostuff();
              windowReturnClass.AddCommand(4, 69);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            case 2:
              this.game.EditObj.SetViewMode = 1;
              this.dostuff();
              windowReturnClass.AddCommand(4, 69);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            case 3:
              this.game.EditObj.SetViewMode = 2;
              this.dostuff();
              windowReturnClass.AddCommand(4, 69);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            case 4:
              this.game.EditObj.SetViewMode = 3;
              this.dostuff();
              windowReturnClass.AddCommand(4, 69);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            case 6:
              this.game.EditObj.SetViewModeExtraNr = 0;
              this.dostuff();
              windowReturnClass.AddCommand(4, 69);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            case 51:
              this.game.EditObj.SetViewModeExtraNr = 1;
              this.dostuff();
              windowReturnClass.AddCommand(4, 69);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            case 52:
              this.game.EditObj.SetViewModeExtraNr = 2;
              this.dostuff();
              windowReturnClass.AddCommand(4, 69);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            case 53:
              this.game.EditObj.SetViewModeExtraNr = 3;
              this.dostuff();
              windowReturnClass.AddCommand(4, 69);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            case 54:
              this.game.EditObj.SetViewModeExtraNr = 4;
              this.dostuff();
              windowReturnClass.AddCommand(4, 69);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            default:
              continue;
          }
        }
      }
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            if (this.SubPartID[index1] == this.exitId)
            {
              if (!this.game.EditObj.GuiDown)
                this.game.EditObj.GuiDown = true;
              else
                this.game.EditObj.GuiDown = false;
              windowReturnClass.AddCommand(3, 11);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            int butCount = this.butCount;
            for (int index2 = 0; index2 <= butCount; ++index2)
            {
              if (this.butId[index2] == this.SubPartID[index1])
              {
                int areaX = this.game.EditObj.AreaX;
                int areaY = this.game.EditObj.AreaY;
                this.game.EditObj.AreaX = this.game.SelectX;
                this.game.EditObj.AreaY = this.game.SelectY;
                this.game.EditObj.UDSinputCounter = -1;
                this.game.EventRelatedObj.DoCheckSpecificEvent(this.butEvent[index2], this.butTempVar0[index2], this.butTempVar1[index2]);
                int stringListById = this.game.HandyFunctionsObj.GetStringListByID((int) Math.Round((double) this.game.Data.RuleVar[409]));
                if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, this.butTempVarStringlistId[index2], 9))) < 1)
                {
                  this.game.EditObj.AreaX = areaX;
                  this.game.EditObj.AreaY = areaY;
                  windowReturnClass.SetFlag(true);
                  this.game.EditObj.PopupValue = 21;
                  windowReturnClass.AddCommand(5, 14);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                windowReturnClass.SetFlag(true);
                this.game.EditObj.QuestionText = this.game.Data.StringListObj[stringListById].GetData(0, this.butTempVarStringlistId[index2], 10);
                this.game.EditObj.DoCardSlot = -1;
                this.game.EditObj.HandCard = -1;
                this.game.EditObj.PopupValue = 1;
                windowReturnClass.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
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

    public void PopUpRefresh() => this.DoRefresh();

    public WindowReturnClass actionZoomOut()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int num1 = 0;
      if (this.game.EditObj.GuiDown)
        num1 = 222;
      int num2 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 53.0));
      int num3 = (int) Math.Round(Conversion.Int((double) this.game.ScreenWidth / 106.0));
      int num4 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 53.0));
      int num5 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - (265 - num1)) / 106.0));
      int num6;
      int num7;
      if (this.game.EditObj.Zoom == 0)
      {
        this.game.EditObj.Zoom = -1;
        this.game.CornerX -= (int) Math.Round(Conversion.Int((double) num2 / 2.0));
        this.game.CornerY -= (int) Math.Round(Conversion.Int((double) num4 / 2.0));
        num6 = 27;
        num7 = 24;
      }
      else
      {
        this.game.EditObj.Zoom = 0;
        this.game.CornerX -= (int) Math.Round(Conversion.Int((double) num3 / 2.0));
        this.game.CornerY -= (int) Math.Round(Conversion.Int((double) num5 / 2.0));
        num6 = 53;
        num7 = 48;
      }
      if (!this.game.Data.MapObj[0].MapLoop)
      {
        if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num6 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
          this.game.CornerX = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num6);
        if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
          this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7);
        if (this.game.CornerX < 0)
          this.game.CornerX = 0;
        if (this.game.CornerY < 0)
          this.game.CornerY = 0;
      }
      else
      {
        if (this.game.CornerX > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
        {
          this.game.CornerX = (int) Math.Round((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num6);
          this.game.CornerX -= this.game.Data.MapObj[0].MapWidth;
        }
        if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
          this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7);
        if (this.game.CornerX < 0)
          this.game.CornerX = this.game.Data.MapObj[0].MapWidth + this.game.CornerX;
        if (this.game.CornerY < 0)
          this.game.CornerY = 0;
      }
      this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
      this.game.EditObj.TempCoordList = new CoordList();
      windowReturnClass.AddCommand(1, 12);
      windowReturnClass.AddCommand(2, 12);
      windowReturnClass.AddCommand(4, 9);
      windowReturnClass.AddCommand(4, 67);
      windowReturnClass.AddCommand(4, 68);
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    public WindowReturnClass actionZoomIn()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int num1 = 0;
      if (this.game.EditObj.GuiDown)
        num1 = 222;
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
      if (!this.game.Data.MapObj[0].MapLoop)
      {
        if ((double) this.game.CornerX + (double) this.game.ScreenWidth / (double) num6 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
          this.game.CornerX = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num6);
        if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
          this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7);
        if (this.game.CornerX < 0)
          this.game.CornerX = 0;
        if (this.game.CornerY < 0)
          this.game.CornerY = 0;
      }
      else
      {
        if (this.game.CornerX > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
          this.game.CornerX -= this.game.Data.MapObj[0].MapWidth;
        if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
          this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - (256 - num1)) / (double) num7);
        if (this.game.CornerX < 0)
          this.game.CornerX = this.game.Data.MapObj[0].MapWidth + this.game.CornerX;
        if (this.game.CornerY < 0)
          this.game.CornerY = 0;
      }
      this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
      this.game.EditObj.TempCoordList = new CoordList();
      windowReturnClass.AddCommand(1, 12);
      windowReturnClass.AddCommand(2, 12);
      windowReturnClass.AddCommand(4, 9);
      windowReturnClass.AddCommand(4, 67);
      windowReturnClass.AddCommand(4, 68);
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }
  }
}
