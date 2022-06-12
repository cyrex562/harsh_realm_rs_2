// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.UDSMessageWindowClass
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
  public class UDSMessageWindowClass : WindowClass
  {
    private int pageId;
    private int okId;
    private bool noBackground;
    private bool exitFound;
    private int useExitEventNr;
    private string useExitKey;
    private string useExitValue;
    private int useExitElementSlot;
    private UDSPartClass udsPartObj;
    private SimpleStringList[] backupUdsKeys;
    private int[] backupEvent;
    private int[] backupY;
    private StringListClass[] backupStringlist;
    private int[,] backupTempVars;
    private int backupCounter;
    private StringListClass[] backupStrl;
    private UDSData[] backupUdsData;
    private bool currentBlockedForBackup;
    private bool exitPopupCommand;
    private int useExtraHeight;

    public UDSMessageWindowClass(ref GameClass tGame, int extraHeight)
      : base(ref tGame, 1260, 750 + extraHeight, 8)
    {
      this.backupUdsKeys = new SimpleStringList[1];
      this.backupEvent = new int[1];
      this.backupY = new int[1];
      this.backupStringlist = new StringListClass[1];
      this.backupTempVars = new int[400, 1];
      this.backupStrl = new StringListClass[1];
      this.backupUdsData = new UDSData[1];
      this.noBackground = false;
      this.useExtraHeight = extraHeight;
      this.useExitEventNr = -1;
      this.backupCounter = -1;
      this.SetBackup();
      this.ViewMessage();
      this.SetBackup(true);
    }

    public UDSMessageWindowClass(ref GameClass tGame, bool tnoBackground, int extraHeight)
      : base(ref tGame, 1260, 750 + extraHeight, 8)
    {
      this.backupUdsKeys = new SimpleStringList[1];
      this.backupEvent = new int[1];
      this.backupY = new int[1];
      this.backupStringlist = new StringListClass[1];
      this.backupTempVars = new int[400, 1];
      this.backupStrl = new StringListClass[1];
      this.backupUdsData = new UDSData[1];
      this.noBackground = tnoBackground;
      this.backupCounter = -1;
      this.useExtraHeight = extraHeight;
      this.useExitEventNr = -1;
      this.SetBackup();
      this.ViewMessage();
    }

    public override void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
        {
          this.game.EditObj.TipButton = false;
          this.SubPartList[index].HandleToolTip(x - this.SubPartX[index], y - this.SubPartY[index]);
          if (this.game.EditObj.TipButton)
            break;
          int num = this.SubPartID[index];
        }
      }
    }

    public void ViewMessage(bool dontDrawPage = false)
    {
      if (this.pageId > 0)
      {
        this.RemoveSubPart(this.pageId);
        this.pageId = 0;
      }
      if (this.okId > 0)
      {
        this.RemoveSubPart(this.okId);
        this.okId = 0;
      }
      this.ClearMouse();
      if (!this.noBackground)
      {
        this.NewBackGroundAndClearAll(1260, 750 + this.useExtraHeight, 8);
        Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
        DrawMod.DrawMessFrame(ref this.OwnBitmap, ref g, 0, 0, 1260, 750 + this.useExtraHeight);
        this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      }
      this.exitFound = false;
      UDSData udsData = new UDSData(Strings.LCase(this.game.EditObj.UDSpopupText), false);
      string buttontext = "exit";
      this.exitPopupCommand = false;
      int elementCounter = udsData.elementCounter;
      for (int index = 0; index <= elementCounter; ++index)
      {
        if (udsData.element[index].type == UDSType.Button && udsData.element[index].hidden)
        {
          this.exitFound = true;
          this.useExitEventNr = udsData.element[index].eventNr;
          this.useExitKey = udsData.element[index].key;
          this.useExitValue = udsData.element[index].value;
          this.useExitElementSlot = index;
          buttontext = Strings.Trim(Strings.UCase(udsData.element[index].texty));
        }
        if (udsData.element[index].type == UDSType.Hidden && Operators.CompareString(udsData.element[index].key.ToLower(), "CLOSEPOPUP".ToLower(), false) == 0 && Conversions.ToDouble(udsData.element[index].value) > 0.0)
          this.exitPopupCommand = true;
      }
      if ((Strings.InStr(Strings.LCase(this.game.EditObj.UDSpopupText), "[type]button[/type]") < 1 | this.exitFound) & !this.noBackground)
      {
        this.udsPartObj = new UDSPartClass(this.game, 1184, 650 + this.useExtraHeight, this.game.EditObj.UDSpopupText, ref this.OwnBitmap, 42, 25, noBitmapDraw: true);
        SubPartClass udsPartObj = (SubPartClass) this.udsPartObj;
        int num = this.AddSubPart(ref udsPartObj, 42, 25, 1184, 650 + this.useExtraHeight, 0);
        this.udsPartObj = (UDSPartClass) udsPartObj;
        this.pageId = num;
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(buttontext, 190, "Click to " + buttontext.ToLower() + ".", ref this.OwnBitmap, 535, 688 + this.useExtraHeight, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.okId = this.AddSubPart(ref tsubpart, 535, 688 + this.useExtraHeight, 190, 35, 1);
      }
      else if (this.noBackground)
      {
        this.udsPartObj = new UDSPartClass(this.game, 1280, 700 + this.useExtraHeight, this.game.EditObj.UDSpopupText, ref this.OwnBitmap, 0, 25, tNoBackground: true, noBitmapDraw: true);
        SubPartClass udsPartObj = (SubPartClass) this.udsPartObj;
        int num = this.AddSubPart(ref udsPartObj, 0, 25, 1280, 700 + this.useExtraHeight, 0);
        this.udsPartObj = (UDSPartClass) udsPartObj;
        this.pageId = num;
      }
      else
      {
        this.udsPartObj = new UDSPartClass(this.game, 1184, 700 + this.useExtraHeight, this.game.EditObj.UDSpopupText, ref this.OwnBitmap, 42, 25, noBitmapDraw: true);
        SubPartClass udsPartObj = (SubPartClass) this.udsPartObj;
        int num = this.AddSubPart(ref udsPartObj, 42, 25, 1184, 700 + this.useExtraHeight, 0);
        this.udsPartObj = (UDSPartClass) udsPartObj;
        this.pageId = num;
      }
      if (!(this.pageId > 0 & !this.currentBlockedForBackup) || ((UDSPartClass) this.SubPartList[this.SubpartNr(this.pageId)]).curY == this.backupY[this.backupCounter] || this.backupEvent[this.backupCounter] == this.game.EditObj.udsLastCalledPopupEventNr)
        return;
      ((UDSPartClass) this.SubPartList[this.SubpartNr(this.pageId)]).curY = this.backupY[this.backupCounter];
      if (dontDrawPage)
        return;
      ((UDSPartClass) this.SubPartList[this.SubpartNr(this.pageId)]).MakeBitmap();
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      try
      {
        if (nr == 27 | nr == 32)
        {
          if (this.okId > 0)
          {
            int index = this.SubpartNr(this.okId);
            windowReturnClass1 = this.HandleMouseClick(this.SubPartX[index] + 1, this.SubPartY[index] + 1, 1);
            this.game.EditObj.udsReturnFromPopup = true;
            return windowReturnClass1;
          }
          if (this.pageId > 0)
          {
            UDSData udsData = new UDSData(Strings.LCase(this.game.EditObj.UDSpopupText), false);
            int elementCounter = udsData.elementCounter;
            for (int index1 = 0; index1 <= elementCounter; ++index1)
            {
              if (udsData.element[index1].type == UDSType.Button && !udsData.element[index1].hidden && Operators.CompareString(Strings.LCase(udsData.element[index1].texty), "ok", false) == 0)
              {
                int num1 = udsData.element[index1].x + 20;
                int num2 = udsData.element[index1].y + 10;
                int index2 = this.SubpartNr(this.pageId);
                WindowReturnClass windowReturnClass2 = new WindowReturnClass();
                WindowReturnClass windowReturnClass3 = this.HandleMouseClick(this.SubPartX[index2] + num1, this.SubPartY[index2] + num2, 1);
                if (windowReturnClass3.Counter > -1)
                {
                  this.game.EditObj.udsReturnFromPopup = true;
                  return windowReturnClass3;
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return windowReturnClass1;
    }

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      return this.game.EditObj.WINDOW_DEBUG_MODE ? this.HandleKeyPress(32, false) : windowReturnClass;
    }

    public void SetBackup(bool updateCurrent = false)
    {
      if (updateCurrent)
      {
        if (this.currentBlockedForBackup)
          return;
      }
      else
        this.currentBlockedForBackup = false;
      bool flag1;
      if (this.backupCounter == -1)
        flag1 = true;
      if (this.backupCounter > -1 & !updateCurrent)
        flag1 = this.backupEvent[this.backupCounter] != this.game.EditObj.udsLastCalledPopupEventNr;
      int udSinputCounter1 = this.game.EditObj.UDSinputCounter;
      bool flag2;
      for (int index = 0; index <= udSinputCounter1; ++index)
      {
        if (Operators.CompareString(this.game.EditObj.UDSinputKey[index], "BACKUPSKIP", false) == 0 & (int) Math.Round(Conversion.Val(this.game.EditObj.UDSinputValue[index])) == 1)
        {
          flag2 = true;
          this.currentBlockedForBackup = true;
          flag1 = false;
        }
      }
      if (updateCurrent)
        flag1 = false;
      if (flag1)
      {
        ++this.backupCounter;
        this.backupUdsKeys = (SimpleStringList[]) Utils.CopyArray((Array) this.backupUdsKeys, (Array) new SimpleStringList[this.backupCounter + 1]);
        this.backupEvent = (int[]) Utils.CopyArray((Array) this.backupEvent, (Array) new int[this.backupCounter + 1]);
        this.backupY = (int[]) Utils.CopyArray((Array) this.backupY, (Array) new int[this.backupCounter + 1]);
        this.backupStringlist = (StringListClass[]) Utils.CopyArray((Array) this.backupStringlist, (Array) new StringListClass[this.backupCounter + 1]);
        this.backupTempVars = (int[,]) Utils.CopyArray((Array) this.backupTempVars, (Array) new int[400, this.backupCounter + 1]);
        this.backupStringlist = (StringListClass[]) Utils.CopyArray((Array) this.backupStringlist, (Array) new StringListClass[this.backupCounter + 1]);
        this.backupUdsData = (UDSData[]) Utils.CopyArray((Array) this.backupUdsData, (Array) new UDSData[this.backupCounter + 1]);
        this.backupEvent[this.backupCounter] = this.game.EditObj.udsLastCalledPopupEventNr;
      }
      if (!flag2)
      {
        this.backupUdsKeys[this.backupCounter] = new SimpleStringList();
        int udSinputCounter2 = this.game.EditObj.UDSinputCounter;
        for (int index = 0; index <= udSinputCounter2; ++index)
          this.backupUdsKeys[this.backupCounter].Add(this.game.EditObj.UDSinputKey[index], (int) Math.Round(Conversion.Val(this.game.EditObj.UDSinputValue[index])));
        int index1 = 0;
        do
        {
          this.backupTempVars[index1, this.backupCounter] = this.game.Data.TempVar[index1];
          ++index1;
        }
        while (index1 <= 399);
        if (this.game.Data.Product == 7)
          this.backupStringlist[this.backupCounter] = this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Present", 165, 0, 0))].Clone();
        if (this.pageId > 0)
          this.backupY[this.backupCounter] = ((UDSPartClass) this.SubPartList[this.SubpartNr(this.pageId)]).curY;
        if (this.pageId > 0)
        {
          UDSPartClass subPart = (UDSPartClass) this.SubPartList[this.SubpartNr(this.pageId)];
          this.backupUdsData[this.backupCounter] = subPart.dyn;
          int elementCounter = subPart.dyn.elementCounter;
          for (int index2 = 0; index2 <= elementCounter; ++index2)
          {
            if (subPart.dyn.element[index2].type == UDSType.Table)
            {
              StringListClass stringListClass = this.game.Data.StringListObj[(int) Math.Round(Conversion.Val(subPart.dyn.element[index2].texty))];
              this.backupStrl = (StringListClass[]) Utils.CopyArray((Array) this.backupStrl, (Array) new StringListClass[this.backupCounter + 1]);
              this.backupStrl[this.backupCounter] = stringListClass.Clone();
              int length = stringListClass.Length;
              for (int index3 = 0; index3 <= length; ++index3)
              {
                int width = stringListClass.Width;
                for (int index4 = 0; index4 <= width; ++index4)
                {
                  this.backupStrl[this.backupCounter].TempDesc[index3, index4] = stringListClass.TempDesc[index3, index4];
                  this.backupStrl[this.backupCounter].TempBmp[index3, index4] = stringListClass.TempBmp[index3, index4];
                }
              }
            }
          }
        }
      }
      this.game.EventRelatedObj.SetUDSKey("BACKUPSKIP", 0);
    }

    public override WindowReturnClass HandleMouseUp(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          int enr = this.SubPartList[index].HandleMouseUp(x - this.SubPartX[index], y - this.SubPartY[index]);
          if (enr > 1)
          {
            this.game.EditObj.UDSpopupText = "";
            this.formref.Cursor = Cursors.WaitCursor;
            this.game.EventRelatedObj.DoCheckSpecificEvent(enr);
            this.formref.Cursor = Cursors.Default;
            if (Strings.InStr(Strings.LCase(this.game.EditObj.UDSpopupText), "[key]nobackground[/key]") > 0)
            {
              this.noBackground = true;
              Graphics.FromImage((Image) this.OwnBitmap).Clear(Color.Transparent);
              this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
            }
            else
              this.noBackground = false;
            this.game.EditObj.udsLastCalledPopupEventNr = enr;
            this.SetBackup();
            this.ViewMessage();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (enr > -1)
          {
            if (this.backupCounter > -1)
              this.SetBackup(true);
            windowReturnClass.SetFlag(true);
            this.SubPartFlag[index] = true;
            return windowReturnClass;
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
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
            int num2;
            if (num1 == this.okId)
            {
              if (this.exitPopupCommand)
              {
                this.game.EventRelatedObj.SetUDSKey("BACKUPSKIP", 0);
                this.game.EditObj.udsReturnFromPopup = true;
                this.game.EditObj.udsLastCalledPopupEventNr = -1;
                windowReturnClass.AddCommand(6, 0);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.backupCounter == 0 && this.backupEvent[0] != this.game.EditObj.udsLastCalledPopupEventNr)
                ++this.backupCounter;
              if (this.backupCounter > 0)
              {
                --this.backupCounter;
                this.game.EditObj.UDSpopupText = "";
                this.currentBlockedForBackup = false;
                this.formref.Cursor = Cursors.WaitCursor;
                int enr = this.backupEvent[this.backupCounter];
                this.game.EditObj.UDSClearInput();
                int counter = this.backupUdsKeys[this.backupCounter].Counter;
                int index2;
                for (index2 = 0; index2 <= counter; ++index2)
                  this.game.EditObj.UDSAddInput(this.backupUdsKeys[this.backupCounter].Id[index2], this.backupUdsKeys[this.backupCounter].Weight[index2]);
                if (this.game.Data.Product == 7)
                {
                  this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Present", 165, 0, 0))] = this.backupStringlist[this.backupCounter];
                  num2 = index2;
                }
                int index3 = 0;
                do
                {
                  this.game.Data.TempVar[index3] = this.backupTempVars[index3, this.backupCounter];
                  ++index3;
                }
                while (index3 <= 399);
                this.game.EventRelatedObj.DoCheckSpecificEvent(enr, skipSettingTempVars: true);
                this.formref.Cursor = Cursors.Default;
                if (this.game.EditObj.UDSpopupText.Length > 1)
                {
                  if (Strings.InStr(Strings.LCase(this.game.EditObj.UDSpopupText), "[key]nobackground[/key]") > 0)
                  {
                    this.noBackground = true;
                    Graphics.FromImage((Image) this.OwnBitmap).Clear(Color.Transparent);
                    this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
                  }
                  else
                    this.noBackground = false;
                  this.ViewMessage(true);
                  this.game.EditObj.udsLastCalledPopupEventNr = enr;
                  if (this.pageId > 0)
                  {
                    UDSPartClass subPart = (UDSPartClass) this.SubPartList[this.SubpartNr(this.pageId)];
                    UDSData Expression = this.backupUdsData[this.backupCounter];
                    if (!Information.IsNothing((object) Expression))
                    {
                      int elementCounter = subPart.dyn.elementCounter;
                      for (int index4 = 0; index4 <= elementCounter; ++index4)
                      {
                        if (Expression.elementCounter >= index4)
                        {
                          if (subPart.dyn.element[index4].type == Expression.element[index4].type && subPart.dyn.element[index4].x == Expression.element[index4].x & subPart.dyn.element[index4].y == Expression.element[index4].y)
                          {
                            subPart.dyn.element[index4].topRow = Expression.element[index4].topRow;
                            if (subPart.dyn.element[index4].parentElement > -1)
                            {
                              subPart.dyn.element[index4].grayed = Expression.element[index4].grayed;
                              subPart.dyn.element[index4].texty = Expression.element[index4].texty;
                            }
                          }
                          if (subPart.dyn.element[index4].type == UDSType.Table & !Information.IsNothing((object) this.backupStrl))
                          {
                            StringListClass stringListClass = this.game.Data.StringListObj[(int) Math.Round(Conversion.Val(subPart.dyn.element[index4].texty))];
                            this.game.Data.StringListObj[(int) Math.Round(Conversion.Val(subPart.dyn.element[index4].texty))] = this.backupStrl[this.backupCounter];
                          }
                        }
                      }
                    }
                    ((UDSPartClass) this.SubPartList[this.SubpartNr(this.pageId)]).MakeBitmap();
                  }
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                this.game.EditObj.udsLastCalledPopupEventNr = enr;
                this.game.EditObj.udsLastCalledPopupEventNr = -1;
                this.game.EventRelatedObj.SetUDSKey("BACKUPSKIP", 0);
                windowReturnClass.AddCommand(6, 0);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              this.game.EventRelatedObj.SetUDSKey("BACKUPSKIP", 0);
              this.game.EditObj.udsReturnFromPopup = true;
              this.game.EditObj.udsLastCalledPopupEventNr = -1;
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == 9999992)
            {
              if (this.useExitEventNr > 0)
              {
                this.game.EditObj.udsReturnFromPopup = true;
                this.udsPartObj.SetHiddenAndBaseData(this.useExitElementSlot, this.useExitKey, this.useExitValue);
                int useExitEventNr = this.useExitEventNr;
                if (useExitEventNr > 0)
                {
                  this.game.EditObj.UDSpopupText = "";
                  this.formref.Cursor = Cursors.WaitCursor;
                  this.game.EventRelatedObj.DoCheckSpecificEvent(useExitEventNr);
                  this.formref.Cursor = Cursors.Default;
                  if (this.game.EditObj.UDSpopupText.Length > 1)
                  {
                    if (Strings.InStr(Strings.LCase(this.game.EditObj.UDSpopupText), "[key]nobackground[/key]") > 0)
                    {
                      this.noBackground = true;
                      Graphics.FromImage((Image) this.OwnBitmap).Clear(Color.Transparent);
                      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
                    }
                    else
                      this.noBackground = false;
                    this.ViewMessage();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  this.game.EditObj.udsLastCalledPopupEventNr = -1;
                  this.game.EventRelatedObj.SetUDSKey("BACKUPSKIP", 0);
                  windowReturnClass.AddCommand(6, 0);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (useExitEventNr == -999)
                {
                  this.game.EditObj.udsLastCalledPopupEventNr = -1;
                  this.game.EventRelatedObj.SetUDSKey("BACKUPSKIP", 0);
                  windowReturnClass.AddCommand(6, 0);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                this.SubPartFlag[index1] = true;
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              this.game.EditObj.udsLastCalledPopupEventNr = -1;
              this.game.EventRelatedObj.SetUDSKey("BACKUPSKIP", 0);
              this.game.EditObj.udsReturnFromPopup = true;
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.pageId)
            {
              int enr1 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              if (enr1 > 0)
              {
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                this.game.EventRelatedObj.DoCheckSpecificEvent(enr1);
                this.formref.Cursor = Cursors.Default;
                if (this.game.EditObj.UDSpopupText.Length > 1)
                {
                  if (Strings.InStr(Strings.LCase(this.game.EditObj.UDSpopupText), "[key]nobackground[/key]") > 0)
                  {
                    this.noBackground = true;
                    Graphics.FromImage((Image) this.OwnBitmap).Clear(Color.Transparent);
                    this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
                  }
                  else
                    this.noBackground = false;
                  this.game.EditObj.udsLastCalledPopupEventNr = enr1;
                  this.SetBackup();
                  this.ViewMessage();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                this.game.EventRelatedObj.SetUDSKey("BACKUPSKIP", 0);
                this.game.EditObj.udsReturnFromPopup = true;
                this.game.EditObj.udsLastCalledPopupEventNr = -1;
                windowReturnClass.AddCommand(6, 0);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (enr1 == -999)
              {
                if (Strings.InStr(this.game.EditObj.UDSpopupText.ToLower(), "[key]closepopup[/key]") > 0)
                {
                  this.game.EditObj.udsLastCalledPopupEventNr = -1;
                  this.game.EventRelatedObj.SetUDSKey("BACKUPSKIP", 0);
                  this.game.EditObj.udsReturnFromPopup = true;
                  windowReturnClass.AddCommand(6, 0);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (this.backupCounter > 0)
                {
                  --this.backupCounter;
                  this.game.EditObj.UDSpopupText = "";
                  this.formref.Cursor = Cursors.WaitCursor;
                  int enr2 = this.backupEvent[this.backupCounter];
                  this.game.EditObj.UDSClearInput();
                  int counter = this.backupUdsKeys[this.backupCounter].Counter;
                  int index5;
                  for (index5 = 0; index5 <= counter; ++index5)
                    this.game.EditObj.UDSAddInput(this.backupUdsKeys[this.backupCounter].Id[index5], this.backupUdsKeys[this.backupCounter].Weight[index5]);
                  if (this.game.Data.Product == 7)
                  {
                    this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Present", 165, 0, 0))] = this.backupStringlist[this.backupCounter];
                    num2 = index5;
                  }
                  int index6 = 0;
                  do
                  {
                    this.game.Data.TempVar[index6] = this.backupTempVars[index6, this.backupCounter];
                    ++index6;
                  }
                  while (index6 <= 399);
                  this.game.EventRelatedObj.DoCheckSpecificEvent(enr2, skipSettingTempVars: true);
                  this.game.EditObj.udsLastCalledPopupEventNr = enr2;
                  this.formref.Cursor = Cursors.Default;
                  if (this.game.EditObj.UDSpopupText.Length > 1)
                  {
                    if (Strings.InStr(Strings.LCase(this.game.EditObj.UDSpopupText), "[key]nobackground[/key]") > 0)
                    {
                      this.noBackground = true;
                      Graphics.FromImage((Image) this.OwnBitmap).Clear(Color.Transparent);
                      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
                    }
                    else
                      this.noBackground = false;
                    this.ViewMessage();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  this.game.EditObj.udsLastCalledPopupEventNr = -1;
                  this.game.EventRelatedObj.SetUDSKey("BACKUPSKIP", 0);
                  windowReturnClass.AddCommand(6, 0);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                this.game.EditObj.udsLastCalledPopupEventNr = -1;
                this.game.EventRelatedObj.SetUDSKey("BACKUPSKIP", 0);
                this.game.EditObj.udsReturnFromPopup = true;
                windowReturnClass.AddCommand(6, 0);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.backupCounter > -1)
                this.SetBackup(true);
              this.SubPartFlag[index1] = true;
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
