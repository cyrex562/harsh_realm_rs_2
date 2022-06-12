// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.AdviceWindow
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace WindowsApplication1
{
  public class AdviceWindow : WindowClass
  {
    private int hideId;
    private int Info1Id;
    private int info2id;
    private int info3id;
    private int info4id;
    private int info5id;
    private int info6id;
    private int info7id;
    private int info8id;
    private int w;
    private int h;
    private int MouseOverWhichTab;
    private string cacheList;
    private int profId;
    private int currentShqNr;
    private int special1id;
    private int special2id;
    private int special3id;

    public AdviceWindow(
      ref GameClass tGame,
      ref WindowClass tLowerWindow,
      ref Rectangle tLowerRect)
      : base(ref tGame, 820, 240, 8)
    {
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.w = 820;
      this.h = 240;
      this.BlockBlit = false;
      this.dostuff();
    }

    public override WindowReturnClass HandleMouseMove(int x, int y)
    {
      WindowReturnClass windowReturnClass = base.HandleMouseMove(x, y);
      if (this.game.EditObj.SetViewMode2 > 0)
        windowReturnClass.Flag = false;
      return windowReturnClass;
    }

    public override void DoRefresh() => this.dostuff();

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.game.EditObj.SetViewMode2 > 0 || this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 502, 0, 0))].Length != -1)
        return windowReturnClass;
      this.game.EditObj.TempBlockAdvice = true;
      windowReturnClass.AddCommand(3, 11);
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    public void dostuff()
    {
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 502, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 191, 0, 0));
      if (this.hideId > 0)
      {
        this.RemoveSubPart(this.hideId);
        this.hideId = 0;
      }
      if (this.Info1Id > 0)
      {
        this.RemoveSubPart(this.Info1Id);
        this.Info1Id = 0;
      }
      if (this.info2id > 0)
      {
        this.RemoveSubPart(this.info2id);
        this.info2id = 0;
      }
      if (this.info3id > 0)
      {
        this.RemoveSubPart(this.info3id);
        this.info3id = 0;
      }
      if (this.info4id > 0)
      {
        this.RemoveSubPart(this.info4id);
        this.info4id = 0;
      }
      if (this.info5id > 0)
      {
        this.RemoveSubPart(this.info5id);
        this.info5id = 0;
      }
      if (this.info6id > 0)
      {
        this.RemoveSubPart(this.info6id);
        this.info6id = 0;
      }
      if (this.info7id > 0)
      {
        this.RemoveSubPart(this.info7id);
        this.info7id = 0;
      }
      if (this.info8id > 0)
      {
        this.RemoveSubPart(this.info8id);
        this.info8id = 0;
      }
      if (this.special1id > 0)
      {
        this.RemoveSubPart(this.special1id);
        this.special1id = 0;
      }
      if (this.special2id > 0)
      {
        this.RemoveSubPart(this.special2id);
        this.special2id = 0;
      }
      if (this.special3id > 0)
      {
        this.RemoveSubPart(this.special3id);
        this.special3id = 0;
      }
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      if (this.game.EditObj.SetViewMode2 > 0)
      {
        this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      }
      else
      {
        Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
        ref Graphics local1 = ref Expression;
        Bitmap bitmap = BitmapStore.GetBitmap(this.game.BACKGROUND3MARC);
        ref Bitmap local2 = ref bitmap;
        Rectangle rectangle1 = new Rectangle(0, 0, 512, this.h - 24);
        Rectangle srcrect1 = rectangle1;
        Rectangle rectangle2 = new Rectangle(8, 8, 512, this.h - 24);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
        ref Graphics local3 = ref Expression;
        Bitmap b = BitmapStore.GetBitmap(this.game.BACKGROUND3MARC);
        ref Bitmap local4 = ref b;
        rectangle2 = new Rectangle(0, 0, 264, this.h - 24);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(520, 8, 264, this.h - 24);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        b = (Bitmap) null;
        DrawMod.DrawMessFrame(ref b, ref Expression, 0, 0, this.w - 32, this.h - 16);
        ref Graphics local5 = ref Expression;
        b = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_EXITLEFT);
        ref Bitmap local6 = ref b;
        int x = this.w - 32;
        int y = this.h - 160;
        DrawMod.DrawSimple(ref local5, ref local6, x, y);
        SubPartClass tsubpart1 = (SubPartClass) new SEButtonPartClass(this.game.SE1_ARROW2, "Hide the advice bar.", 23);
        this.hideId = this.AddSubPart(ref tsubpart1, this.w - 30, this.h - 160 + 18, 23, 35, 1);
        this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
        if (this.game.Data.StringListObj[stringListById1].Length > -1)
        {
          int id = this.game.EventRelatedObj.CheckStringlistID("SE_IO", 158, 0, 0);
          if (this.game.EditObj.se1_adviceWindowPage < 0)
            this.game.EditObj.se1_adviceWindowPage = 0;
          if (this.game.EditObj.se1_adviceWindowPage > this.game.Data.StringListObj[stringListById1].Length)
            this.game.EditObj.se1_adviceWindowPage = this.game.Data.StringListObj[stringListById1].Length;
          int num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[this.game.EditObj.se1_adviceWindowPage, 0]));
          int charId = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[this.game.EditObj.se1_adviceWindowPage, 1]));
          int idValue1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[this.game.EditObj.se1_adviceWindowPage, 2]));
          int idValue2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[this.game.EditObj.se1_adviceWindowPage, 3]));
          string str1 = this.game.Data.StringListObj[stringListById1].Data[this.game.EditObj.se1_adviceWindowPage, 4];
          string str2 = this.game.Data.StringListObj[stringListById1].Data[this.game.EditObj.se1_adviceWindowPage, 5];
          ref Graphics local7 = ref Expression;
          b = BitmapStore.GetBitmap(this.game.SE1_PAPER2);
          ref Bitmap local8 = ref b;
          rectangle2 = new Rectangle(16, 16, this.w - 58, this.h - 42);
          Rectangle srcrect3 = rectangle2;
          rectangle1 = new Rectangle(14, 14, this.w - 58, this.h - 42);
          Rectangle destrect3 = rectangle1;
          DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect3, destrect3);
          string tstring1 = str2 + " " + (this.game.EditObj.se1_adviceWindowPage + 1).ToString() + "/" + (this.game.Data.StringListObj[stringListById1].Length + 1).ToString();
          DrawMod.DrawTextColouredConsoleCenter(ref Expression, tstring1, DrawMod.TGame.se1TypeWriterBig, (int) Math.Round((double) this.w / 2.0) - 18, 20, DrawMod.TGame.seColTW);
          if (charId > 0)
          {
            ref Graphics local9 = ref Expression;
            b = this.game.CustomBitmapObj.DrawLeaderPortrait(charId, 78, 110);
            ref Bitmap local10 = ref b;
            DrawMod.DrawSimple(ref local9, ref local10, 20, 55);
            string tstring2 = this.game.EventRelatedObj.GetLeaderName(charId, true) + " says:";
            DrawMod.DrawTextColouredConsole(ref Expression, tstring2, DrawMod.TGame.se1TypeWriterSmall, 104, 52, DrawMod.TGame.seColTW);
          }
          this.game.EventRelatedObj.IO_AddClear();
          this.game.EventRelatedObj.IO_AddText("\"" + str1 + "\"", 0, 0, this.w - 182, IO_ColNr.Black, IO_FontNr.Regular, returnHeight: true);
          SubPartClass tsubpart2 = (SubPartClass) new UDSPartClass(this.game, this.w - 182, this.h - 48, this.game.EventRelatedObj.CheckKey(id, "FINALTEXT", 0, 0), ref this.OwnBitmap, 104, 69, true);
          this.info4id = this.AddSubPart(ref tsubpart2, 104, 69, this.w - 182, this.h - 48, 0);
          SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Del", 50, "Never give me this specific type of advice again for remainder of the game.", ref this.OwnBitmap, 16, this.h - 65, usefont: DrawMod.TGame.se1TypeWriterMedium, tudsButton: true);
          this.info5id = this.AddSubPart(ref tsubpart3, 16, this.h - 65, 50, 35, 1);
          SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Dismiss", 120, "Remove this advice for now, but remind me later if deemed neccessary.", ref this.OwnBitmap, 66, this.h - 65, usefont: DrawMod.TGame.se1TypeWriterMedium, tudsButton: true);
          this.info6id = this.AddSubPart(ref tsubpart4, 66, this.h - 65, 120, 35, 1);
          if (idValue1 > 0)
          {
            string str3 = this.game.Data.StringListObj[stringListById2].GetData(0, idValue1, 2);
            int num2 = Strings.InStr(str3.ToLower(), "How to".ToLower());
            if (num2 > 0)
              str3 = Strings.Mid(str3, num2 + 7);
            int num3 = Strings.InStr(str3, " ");
            if (num3 > 0)
            {
              int num4 = Strings.InStr(num3 + 1, str3, " ");
              if (num4 > 0)
              {
                int num5 = Strings.InStr(num4 + 1, str3, " ");
                if (num5 > 0)
                {
                  int num6 = Strings.InStr(num5 + 1, str3, " ");
                  if (num6 > 0)
                    str3 = Strings.Left(str3, num6 - 1);
                }
              }
            }
            SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass(Strings.Left(str3, 1).ToUpper() + Strings.Mid(str3, 2), 290, "Give more information on: " + this.game.Data.StringListObj[stringListById2].GetData(0, idValue1, 2), ref this.OwnBitmap, 186, this.h - 65, usefont: DrawMod.TGame.se1TypeWriterMedium, tudsButton: true);
            this.info7id = this.AddSubPart(ref tsubpart5, 186, this.h - 65, 290, 35, 1);
          }
          if (idValue2 > 0)
          {
            string str4 = this.game.Data.StringListObj[stringListById2].GetData(0, idValue2, 2);
            int num7 = Strings.InStr(str4.ToLower(), "How to".ToLower());
            if (num7 > 0)
              str4 = Strings.Mid(str4, num7 + 7);
            int num8 = Strings.InStr(str4, " ");
            if (num8 > 0)
            {
              int num9 = Strings.InStr(num8 + 1, str4, " ");
              if (num9 > 0)
              {
                int num10 = Strings.InStr(num9 + 1, str4, " ");
                if (num10 > 0)
                {
                  int num11 = Strings.InStr(num10 + 1, str4, " ");
                  if (num11 > 0)
                    str4 = Strings.Left(str4, num11 - 1);
                }
              }
            }
            SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass(Strings.Left(str4, 1).ToUpper() + Strings.Mid(str4, 2), 290, "Give more information on: " + this.game.Data.StringListObj[stringListById2].GetData(0, idValue2, 2), ref this.OwnBitmap, 481, this.h - 65, usefont: DrawMod.TGame.se1TypeWriterMedium, tudsButton: true);
            this.info8id = this.AddSubPart(ref tsubpart6, 481, this.h - 65, 290, 35, 1);
          }
          if (this.game.Data.StringListObj[stringListById1].Length > 0)
          {
            int num12 = 0;
            if (this.game.EditObj.se1_adviceWindowPage < 1)
              num12 = 1;
            SubPartClass tsubpart7 = (SubPartClass) new TextButtonPartClass("<", 60, "Go to previous Advice...", ref this.OwnBitmap, 30, 20, num12 == 1, theight: 30, usefont: DrawMod.TGame.se1TypeWriterMedium, tudsButton: true);
            this.info2id = this.AddSubPart(ref tsubpart7, 30, 20, 60, 30, 1);
            int num13 = 1;
            if (this.game.EditObj.se1_adviceWindowPage < this.game.Data.StringListObj[stringListById1].Length)
              num13 = 0;
            SubPartClass tsubpart8 = (SubPartClass) new TextButtonPartClass(">", 60, "Go to next Advice...", ref this.OwnBitmap, this.w - 110, 20, num13 == 1, theight: 30, usefont: DrawMod.TGame.se1TypeWriterMedium, tudsButton: true);
            this.info3id = this.AddSubPart(ref tsubpart8, this.w - 110, 20, 60, 30, 1);
          }
        }
        if (Information.IsNothing((object) Expression))
          return;
        Expression.Dispose();
        Expression = (Graphics) null;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public override void HandleToolTip(int x, int y)
    {
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            this.game.EditObj.TipButton = false;
            this.SubPartList[index].HandleToolTip(x - this.SubPartX[index], y - this.SubPartY[index]);
            if (this.game.EditObj.TipButton)
              return;
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
          if (Strings.InStr(this.game.EditObj.TipText, "MX-ENTR") <= 0)
            break;
          this.game.EditObj.TipTitle += "<FIXEDSYS>";
          break;
        }
      }
    }

    public void PopUpRefresh() => this.DoRefresh();

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.game.EditObj.SetViewMode2 > 0 || this.game.EditObj.TutOrder > -1)
        return windowReturnClass;
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (this.SubPartCounter > -1 && x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
        {
          int num1 = this.SubPartID[index];
          if (num1 == this.Info1Id)
          {
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (num1 == this.info2id)
          {
            --this.game.EditObj.se1_adviceWindowPage;
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (num1 == this.hideId)
          {
            this.game.EditObj.BlockAdvice = true;
            this.game.EditObj.TempBlockAdvice = true;
            windowReturnClass.AddCommand(3, 11);
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (num1 == this.info3id)
          {
            ++this.game.EditObj.se1_adviceWindowPage;
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (num1 == this.info7id)
          {
            int stringListById = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 502, 0, 0));
            this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 503, 0, 0));
            int num2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[this.game.EditObj.se1_adviceWindowPage, 0]));
            int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[this.game.EditObj.se1_adviceWindowPage, 2]));
            this.game.EditObj.udsManagementTabOverrideId = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Present", 79, 0, 0))].GetData(11, idValue, 0)));
            this.game.EditObj.SetViewMode2 = 12;
            this.ClearMouse();
            this.NewBackGroundAndClearAll(this.w, this.h, -1);
            this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
            if (this.game.ScreenHeight < 920 & this.game.ScreenWidth < 1465)
            {
              this.game.EditObj.GuiDown = true;
              this.game.EditObj.RightDown = true;
              windowReturnClass.AddCommand(3, 11);
            }
            else if (this.game.ScreenHeight < 920)
            {
              this.game.EditObj.GuiDown = true;
              windowReturnClass.AddCommand(3, 11);
            }
            else if (this.game.ScreenWidth < 1465)
            {
              this.game.EditObj.RightDown = true;
              windowReturnClass.AddCommand(3, 11);
            }
            else
              windowReturnClass.AddCommand(3, 11);
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (num1 == this.info8id)
          {
            int stringListById = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 502, 0, 0));
            this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 503, 0, 0));
            int num3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[this.game.EditObj.se1_adviceWindowPage, 0]));
            int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[this.game.EditObj.se1_adviceWindowPage, 3]));
            this.game.EditObj.udsManagementTabOverrideId = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Present", 79, 0, 0))].GetData(11, idValue, 0)));
            this.game.EditObj.SetViewMode2 = 12;
            this.ClearMouse();
            this.NewBackGroundAndClearAll(this.w, this.h, -1);
            this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
            if (this.game.ScreenHeight < 920 & this.game.ScreenWidth < 1465)
            {
              this.game.EditObj.GuiDown = true;
              this.game.EditObj.RightDown = true;
              windowReturnClass.AddCommand(3, 11);
            }
            else if (this.game.ScreenHeight < 920)
            {
              this.game.EditObj.GuiDown = true;
              windowReturnClass.AddCommand(3, 11);
            }
            else if (this.game.ScreenWidth < 1465)
            {
              this.game.EditObj.RightDown = true;
              windowReturnClass.AddCommand(3, 11);
            }
            else
              windowReturnClass.AddCommand(3, 11);
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (num1 == this.info5id)
          {
            int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 502, 0, 0));
            int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 503, 0, 0));
            int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[this.game.EditObj.se1_adviceWindowPage, 0]));
            if (idValue > 0)
            {
              int num4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, idValue, 1)));
              int num5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, idValue, 2)));
              int setValue = 999999;
              this.game.Data.StringListObj[stringListById2].SetData(0, idValue, 1, setValue, true);
              this.game.Data.StringListObj[stringListById1].RemoveRow(this.game.EditObj.se1_adviceWindowPage);
            }
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (num1 == this.info6id)
          {
            int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 502, 0, 0));
            int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 503, 0, 0));
            int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].Data[this.game.EditObj.se1_adviceWindowPage, 0]));
            if (idValue > 0)
            {
              int num6 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, idValue, 1)));
              int num7 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, idValue, 2)));
              if (num7 < 1)
                num7 = 1;
              int setValue1 = num7 + (1 + num7);
              int setValue2 = this.game.Data.Round + (1 + setValue1);
              this.game.Data.StringListObj[stringListById4].SetData(0, idValue, 1, setValue2, true);
              this.game.Data.StringListObj[stringListById4].SetData(0, idValue, 2, setValue1, true);
              this.game.Data.StringListObj[stringListById3].RemoveRow(this.game.EditObj.se1_adviceWindowPage);
            }
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
      }
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height && this.MouseData[index] > 0 & this.MouseData[index] <= 3)
        {
          this.dostuff();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      if (x > 0 & x < this.w && y > 0 & y < this.h)
        windowReturnClass.NoMouseClickBelow = true;
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false) => new WindowReturnClass();
  }
}
