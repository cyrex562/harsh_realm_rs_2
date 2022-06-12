// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TabReportsWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class TabReportsWindowClass2 : WindowClass
  {
    private int Info1Id;
    private int info2id;
    private string ShowString;
    private DateTime ShowTime;
    private int w;
    private int h;
    private int detailnr;
    private int CurrentView;
    private int OptionsList5id;
    private int Text1Id;
    private int Text2Id;
    private ListClass OptionsList5Obj;
    private int okId;

    public TabReportsWindowClass2(
      ref GameClass tGame,
      ref WindowClass tLowerWindow,
      ref Rectangle tLowerRect,
      Rectangle trect)
      : base(ref tGame, trect.Width, trect.Height, 8)
    {
      this.w = trect.Width;
      this.h = trect.Height;
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.detailnr = -1;
      this.dostuff();
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (nr == 40)
      {
        this.SubPartList[this.SubpartNr(this.OptionsList5id)].ShiftDown();
        this.SubPartFlag[this.SubpartNr(this.OptionsList5id)] = true;
        this.detailnr = this.SubPartList[this.SubpartNr(this.OptionsList5id)].GetSelect();
        if (this.Text1Id > 0)
        {
          this.RemoveSubPart(this.Text1Id);
          this.Text1Id = 0;
        }
        if (this.Text2Id > 0)
        {
          this.RemoveSubPart(this.Text2Id);
          this.Text2Id = 0;
        }
        this.dostuff();
        windowReturnClass.SetFlag(true);
      }
      if (nr == 38)
      {
        this.SubPartList[this.SubpartNr(this.OptionsList5id)].ShiftUp();
        this.SubPartFlag[this.SubpartNr(this.OptionsList5id)] = true;
        this.detailnr = this.SubPartList[this.SubpartNr(this.OptionsList5id)].GetSelect();
        if (this.Text1Id > 0)
        {
          this.RemoveSubPart(this.Text1Id);
          this.Text1Id = 0;
        }
        if (this.Text2Id > 0)
        {
          this.RemoveSubPart(this.Text2Id);
          this.Text2Id = 0;
        }
        this.dostuff();
        windowReturnClass.SetFlag(true);
      }
      if (this.Text2Id > 0)
      {
        if (nr == 39)
        {
          this.SubPartList[this.SubpartNr(this.Text2Id)].ShiftDown();
          this.SubPartFlag[this.SubpartNr(this.Text2Id)] = true;
          windowReturnClass.SetFlag(true);
        }
        if (nr == 37)
        {
          this.SubPartList[this.SubpartNr(this.Text2Id)].ShiftUp();
          this.SubPartFlag[this.SubpartNr(this.Text2Id)] = true;
          windowReturnClass.SetFlag(true);
        }
      }
      return windowReturnClass;
    }

    public override void DoRefresh() => this.dostuff();

    public void PopUpRefresh() => this.DoRefresh();

    public void dostuff()
    {
      if (this.okId > 0)
      {
        this.RemoveSubPart(this.okId);
        this.okId = 0;
      }
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      Rectangle trect1 = DrawMod.DrawBackTab(g, this.w, this.h, "REPS", 4);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      this.ClearMouse();
      this.AddMouse(ref trect1, "CLOSE TAB", "Click here to close this tab. [ESC/F5]", 999);
      this.OptionsList5Obj = new ListClass();
      int tlistselect1 = -1;
      int num1 = -1;
      int num2 = 0;
      if (this.h > 380)
        num2 = this.h - 380;
      int messCounter = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
      for (int tdata = 0; tdata <= messCounter; ++tdata)
      {
        if (this.game.Data.RegimeObj[this.game.Data.Turn].MesName[tdata] != null & this.game.Data.RegimeObj[this.game.Data.Turn].MessBackPic[tdata] == -2 & !this.game.Data.RegimeObj[this.game.Data.Turn].MesHideFromTab[tdata])
        {
          ++num1;
          if (this.detailnr == -1)
            this.detailnr = 0;
          if (this.detailnr == tdata)
            tlistselect1 = num1;
          string str;
          if (this.game.Data.RegimeObj[this.game.Data.Turn].MesName[tdata].Length > 1)
          {
            str = this.game.Data.RegimeObj[this.game.Data.Turn].MesName[tdata];
          }
          else
          {
            int num3 = Strings.InStr(this.game.Data.RegimeObj[this.game.Data.Turn].MessString[tdata], "\r\n");
            if (Information.IsNothing((object) num3) | num3 <= 0)
            {
              str = Strings.Left(this.game.Data.RegimeObj[this.game.Data.Turn].MessString[tdata], 50) + "...";
            }
            else
            {
              str = Strings.Left(this.game.Data.RegimeObj[this.game.Data.Turn].MessString[tdata], num3);
              if (Strings.Len(str) > 50)
                str = Strings.Left(str, 50) + "...";
            }
          }
          bool flag = false;
          DynamicData dynamicData = new DynamicData(this.game.Data.RegimeObj[this.game.Data.Turn].MessString[tdata]);
          int elementCounter = dynamicData.elementCounter;
          for (int index = 0; index <= elementCounter; ++index)
          {
            if (dynamicData.element[index].type == DynamicType.OptionField)
              flag = true;
          }
          if (flag)
          {
            if (this.game.Data.RegimeObj[this.game.Data.Turn].MesChosen[tdata] == 0)
              this.OptionsList5Obj.add(str, tdata, tbmp: BitmapStore.GetBitmap(this.game.SMALLCHAR1));
            else
              this.OptionsList5Obj.add(str, tdata, tbmp: BitmapStore.GetBitmap(this.game.SMALLCHAR2));
          }
          else
            this.OptionsList5Obj.add(str, tdata);
        }
      }
      if (this.OptionsList5Obj.ListCount > -1)
      {
        SubPartClass tsubpart;
        if (this.OptionsList5id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList5id)].Refresh(this.OptionsList5Obj, tlistselect1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList5id)] = true;
        }
        else
        {
          ListClass optionsList5Obj = this.OptionsList5Obj;
          int tlistsize = (int) Math.Round(9.0 + Conversion.Int((double) num2 / 16.0));
          int tlistselect2 = tlistselect1;
          GameClass game = this.game;
          ref Bitmap local1 = ref this.OwnBitmap;
          Font font = (Font) null;
          ref Font local2 = ref font;
          tsubpart = (SubPartClass) new ListSubPartClass(optionsList5Obj, tlistsize, 250, tlistselect2, game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: 25, bby: 17, tMarcStyle: true, overruleFont: (ref local2));
          this.OptionsList5id = this.AddSubPart(ref tsubpart, 25, 17, 250, (int) Math.Round((10.0 + Conversion.Int((double) num2 / 16.0)) * 16.0), 0);
        }
        Rectangle rectangle = new Rectangle(25, 17, 250, (int) Math.Round((10.0 + Conversion.Int((double) num2 / 16.0)) * 16.0));
        Rectangle trect2 = rectangle;
        this.AddMouse(ref trect2, "List of messages", "Click on a message to read full text");
        if (this.detailnr <= -1)
          return;
        if (this.game.Data.RegimeObj[this.game.Data.Turn].MessFrontPic[this.detailnr] > -1)
        {
          int commanderSpriteId = this.game.Data.RegimeObj[this.game.Data.Turn].MessFrontPic[this.detailnr];
          if (commanderSpriteId >= 10000)
            commanderSpriteId = this.game.Data.HistoricalUnitObj[commanderSpriteId - 10000].CommanderSpriteID;
          else if (commanderSpriteId <= this.game.Data.EventPicCounter)
            commanderSpriteId = this.game.Data.EventPicNr[commanderSpriteId];
          if (commanderSpriteId > -1)
          {
            int num4 = BitmapStore.GetWidth(commanderSpriteId);
            int num5 = BitmapStore.Getheight(commanderSpriteId);
            if (num4 > 250)
            {
              num5 = (int) Math.Round((double) num5 * (250.0 / (double) num4));
              num4 = (int) Math.Round((double) num4 * (250.0 / (double) num4));
            }
            if (num5 > 120)
            {
              num4 = (int) Math.Round((double) num4 * (120.0 / (double) num5));
              num5 = (int) Math.Round((double) num5 * (120.0 / (double) num5));
            }
            if (num4 > 64)
            {
              if (this.game.Data.RegimeObj[this.game.Data.Turn].MesNote2[this.detailnr].Length > 0)
              {
                ref Graphics local3 = ref g;
                Bitmap bitmap = BitmapStore.GetBitmap(commanderSpriteId);
                ref Bitmap local4 = ref bitmap;
                trect2 = new Rectangle(0, 0, BitmapStore.GetWidth(commanderSpriteId), BitmapStore.Getheight(commanderSpriteId));
                Rectangle srcrect = trect2;
                rectangle = new Rectangle(25, 215 + num2, num4, num5);
                Rectangle destrect = rectangle;
                DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
              }
              else
              {
                ref Graphics local5 = ref g;
                Bitmap bitmap = BitmapStore.GetBitmap(commanderSpriteId);
                ref Bitmap local6 = ref bitmap;
                trect2 = new Rectangle(0, 0, BitmapStore.GetWidth(commanderSpriteId), BitmapStore.Getheight(commanderSpriteId));
                Rectangle srcrect = trect2;
                rectangle = new Rectangle(25, 200 + num2, num4, num5);
                Rectangle destrect = rectangle;
                DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect, destrect);
              }
              if (this.game.Data.RegimeObj[this.game.Data.Turn].MessFrontPic[this.detailnr] >= 10000)
              {
                int overdrawSpriteId = this.game.Data.HistoricalUnitObj[this.game.Data.RegimeObj[this.game.Data.Turn].MessFrontPic[this.detailnr] - 10000].OverdrawSpriteID;
                if (this.game.Data.RegimeObj[this.game.Data.Turn].MesNote2[this.detailnr].Length > 0)
                {
                  if (overdrawSpriteId > -1)
                  {
                    ref Graphics local7 = ref g;
                    Bitmap bitmap = BitmapStore.GetBitmap(overdrawSpriteId);
                    ref Bitmap local8 = ref bitmap;
                    int y = 215 + num2;
                    int w = num4;
                    int h = num5;
                    DrawMod.DrawScaled(ref local7, ref local8, 25, y, w, h);
                  }
                }
                else if (overdrawSpriteId > -1)
                {
                  ref Graphics local9 = ref g;
                  Bitmap bitmap = BitmapStore.GetBitmap(overdrawSpriteId);
                  ref Bitmap local10 = ref bitmap;
                  int y = 200 + num2;
                  int w = num4;
                  int h = num5;
                  DrawMod.DrawScaled(ref local9, ref local10, 25, y, w, h);
                }
              }
              if (this.game.Data.RegimeObj[this.game.Data.Turn].MesNote2[this.detailnr].Length > 0)
                DrawMod.DrawTextColouredMarc(ref g, this.game.Data.RegimeObj[this.game.Data.Turn].MesNote2[this.detailnr], this.game.MarcFont7, 25, 190 + num2, Color.White);
              else
                DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, 25, 200 + num2, num4, num5, 25, 200);
              int num6 = num5 + 10;
            }
          }
        }
        if (this.game.Data.RegimeObj[this.game.Data.Turn].MesStyle[this.detailnr] == 3)
        {
          if (this.Text2Id == 0)
          {
            tsubpart = (SubPartClass) new DynamicArea(this.game, 565, this.h - 100, this.game.Data.RegimeObj[this.game.Data.Turn].MessString[this.detailnr], ref this.OwnBitmap, 294, 0);
            this.Text2Id = this.AddSubPart(ref tsubpart, 294, 0, 565, this.h - 100, 0);
          }
          else
            this.SubPartFlag[this.SubpartNr(this.Text2Id)] = true;
          if (Strings.InStr(this.game.Data.RegimeObj[this.game.Data.Turn].MessString[this.detailnr].ToLower(), "[type]option[/type]".ToLower()) <= 0)
            return;
          if (this.game.Data.RegimeObj[this.game.Data.Turn].MesChosen[this.detailnr] > 0)
          {
            tsubpart = (SubPartClass) new TextButtonPartClass("REVIEW DECISION", 305, "You already made a decision, but you can click to review it.", ref this.OwnBitmap, 424, this.h - 90, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.okId = this.AddSubPart(ref tsubpart, 424, this.h - 90, 305, 40, 1);
          }
          else
          {
            tsubpart = (SubPartClass) new TextButtonPartClass("MAKE DECISION", 305, "Click to review possible decisions for this report.", ref this.OwnBitmap, 424, this.h - 90, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.okId = this.AddSubPart(ref tsubpart, 424, this.h - 90, 305, 40, 1);
          }
        }
        else if (this.Text2Id == 0)
        {
          tsubpart = (SubPartClass) new TextAreaClass2(this.game, 360 + (this.w - 684), (int) Math.Round(Conversion.Int((double) (this.h - 100) / 17.0)), this.game.MarcFont8, "[tab]Message," + this.game.Data.RegimeObj[this.game.Data.Turn].MessString[this.detailnr] + "[/tab]", 17, ref this.OwnBitmap, 294, 0);
          this.Text2Id = this.AddSubPart(ref tsubpart, 294, 0, 360 + (this.w - 684), ((int) Math.Round(Math.Ceiling((double) (this.h - 100 - 0) / 17.0)) + 1) * 17, 0);
        }
        else
          this.SubPartFlag[this.SubpartNr(this.Text2Id)] = true;
      }
      else
        DrawMod.DrawText(ref g, "No reports available.", this.game.GameFont1, 10, 150);
    }

    public override void HandleToolTip(int x, int y)
    {
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          return;
        }
      }
      if (this.SubPartCounter <= -1)
        return;
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
        {
          this.game.EditObj.TipButton = false;
          this.SubPartList[index].HandleToolTip(x - this.SubPartX[index], y - this.SubPartY[index]);
          if (this.game.EditObj.TipButton)
            break;
          if (!this.game.EditObj.TipButton & Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
          {
            this.game.EditObj.TipButton = true;
            this.game.EditObj.TipTitle = "";
            this.game.EditObj.TipText = this.SubPartList[index].Descript;
            break;
          }
        }
      }
    }

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
            int num1 = this.SubPartID[index];
            if (num1 == this.Text2Id)
            {
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsList5id)
            {
              int num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num2 > -1)
              {
                this.detailnr = num2;
                if (this.Text1Id > 0)
                {
                  this.RemoveSubPart(this.Text1Id);
                  this.Text1Id = 0;
                }
                if (this.Text2Id > 0)
                {
                  this.RemoveSubPart(this.Text2Id);
                  this.Text2Id = 0;
                }
                this.dostuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.okId)
            {
              this.game.EditObj.FromMessage = this.detailnr;
              this.game.EditObj.PopupValue = 19;
              windowReturnClass.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
        }
      }
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height && this.MouseData[index] == 999)
        {
          this.game.EditObj.SetViewMode2 = 0;
          windowReturnClass.AddCommand(1, 9);
          windowReturnClass.AddCommand(7, 12);
          windowReturnClass.AddCommand(4, 67);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      if (x > 8 & x < this.w - 8 && y < this.h - 24)
        windowReturnClass.NoMouseClickBelow = true;
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }
  }
}
