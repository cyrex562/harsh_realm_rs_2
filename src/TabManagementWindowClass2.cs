// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TabManagementWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class TabManagementWindowClass2 : WindowClass
  {
    private int w;
    private int h;
    private int tabnr;
    private string tabname;
    private int subtabcount;
    private string[] subtabname;
    private int subtabnr;
    private int[] pagecount;
    private string[,] pagename;
    private int[,] pagerow;
    private int[,] pageclickable;
    private int pagenr;
    private int stringlistslot;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int pageId;
    private int prevPageNr;
    private string lastEventNr;
    private int prevPageId;
    private int curPageId;
    private int cache_udsManagementOverride;

    public TabManagementWindowClass2(
      ref GameClass tGame,
      ref WindowClass tLowerWindow,
      ref Rectangle tLowerRect,
      Rectangle trect)
      : base(ref tGame, trect.Width, trect.Height, 8)
    {
      this.subtabname = new string[11];
      this.pagecount = new int[11];
      this.pagename = new string[11, 211];
      this.pagerow = new int[11, 211];
      this.pageclickable = new int[11, 211];
      this.cache_udsManagementOverride = 0;
      this.w = trect.Width;
      this.h = trect.Height;
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.initTabs();
      this.prevPageNr = this.pagenr;
      this.dostuff();
    }

    public void initTabs()
    {
      bool forUDSRandomTab = false;
      this.subtabcount = 0;
      this.subtabname = new string[11];
      this.pagecount = new int[11];
      this.pagename = new string[11, 211];
      this.pagerow = new int[11, 211];
      int id;
      if (this.game.EditObj.SetViewMode2 < 100)
      {
        this.tabnr = this.game.EditObj.SetViewMode2 - 10;
        id = (int) Math.Round((double) this.game.Data.RuleVar[441]);
      }
      else
      {
        this.tabnr = this.game.EditObj.SetViewMode2 - 100;
        forUDSRandomTab = true;
        id = (int) Math.Round((double) this.game.Data.RuleVar[443]);
      }
      if (this.tabnr < 0)
        this.tabnr = 0;
      this.tabname = this.game.HandyFunctionsObj.GetUDSmanagementTabName(this.tabnr, forUDSRandomTab);
      this.stringlistslot = this.game.HandyFunctionsObj.GetStringListByID(id);
      this.subtabcount = 0;
      int subTabNr = 1;
      do
      {
        string smanagementSubTabName = this.game.HandyFunctionsObj.GetUDSmanagementSubTabName(this.tabnr, subTabNr, forUDSRandomTab);
        if (smanagementSubTabName.Length > 1)
        {
          ++this.subtabcount;
          this.subtabname[this.subtabcount] = smanagementSubTabName;
          int pageNr = 1;
          do
          {
            int integer = Conversions.ToInteger(this.game.HandyFunctionsObj.GetUDSmanagementPageRow(this.tabnr, this.subtabcount, pageNr, forUDSRandomTab));
            if (integer >= 0)
            {
              int stringListById = this.game.HandyFunctionsObj.GetStringListByID(id);
              string str = this.game.Data.StringListObj[stringListById].Data[integer, 4];
              if (str.Length > 1)
              {
                int[] pagecount = this.pagecount;
                int[] numArray = pagecount;
                int subtabcount = this.subtabcount;
                int index = subtabcount;
                int num = pagecount[subtabcount] + 1;
                numArray[index] = num;
                if (this.subtabnr < 1)
                  this.subtabnr = this.subtabcount;
                this.pagename[this.subtabcount, this.pagecount[this.subtabcount]] = str;
                this.pagerow[this.subtabcount, this.pagecount[this.subtabcount]] = integer;
                this.pageclickable[this.subtabcount, this.pagecount[this.subtabcount]] = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[integer, 5])) <= 0 ? 1 : 0;
                if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[integer, 0])) == this.game.EditObj.udsManagementTabOverrideId)
                {
                  this.subtabnr = this.subtabcount;
                  this.pagenr = this.pagecount[this.subtabcount];
                  this.game.EditObj.uds_subtab[this.tabnr] = this.subtabnr;
                  this.game.EditObj.uds_page[this.tabnr, this.subtabnr] = this.pagenr;
                  this.game.EditObj.udsManagementTabOverrideId = -1;
                }
              }
              else
                pageNr = 999;
            }
            else
              pageNr = 999;
            ++pageNr;
          }
          while (pageNr <= 200);
        }
        else
          subTabNr = 999;
        ++subTabNr;
      }
      while (subTabNr <= 8);
      if (this.tabnr < 0)
        this.tabnr = 0;
      if (this.game.EditObj.uds_subtab[this.tabnr] > 0)
        this.subtabnr = this.game.EditObj.uds_subtab[this.tabnr];
      if (this.subtabnr <= 0 || this.game.EditObj.uds_page[this.tabnr, this.subtabnr] <= 0)
        return;
      this.pagenr = this.game.EditObj.uds_page[this.tabnr, this.subtabnr];
    }

    public override void DoRefresh()
    {
      this.prevPageNr = this.pagenr;
      if (this.OptionsListId > 0)
      {
        this.RemoveSubPart(this.OptionsListId);
        this.OptionsListId = 0;
      }
      this.initTabs();
      this.dostuff();
    }

    public void PopUpRefresh()
    {
      int num = 0;
      this.prevPageNr = this.pagenr;
      bool dontDrawPage = false;
      UDSData dyn;
      StringListClass Expression;
      if (this.pageId > 0)
      {
        num = ((UDSPartClass) this.SubPartList[this.SubpartNr(this.pageId)]).curY;
        UDSPartClass subPart = (UDSPartClass) this.SubPartList[this.SubpartNr(this.pageId)];
        dyn = subPart.dyn;
        int elementCounter = subPart.dyn.elementCounter;
        for (int index1 = 0; index1 <= elementCounter; ++index1)
        {
          if (subPart.dyn.element[index1].type == UDSType.Table)
          {
            StringListClass stringListClass = this.game.Data.StringListObj[(int) Math.Round(Conversion.Val(subPart.dyn.element[index1].texty))];
            Expression = stringListClass.Clone();
            int length = stringListClass.Length;
            for (int index2 = 0; index2 <= length; ++index2)
            {
              int width = stringListClass.Width;
              for (int index3 = 0; index3 <= width; ++index3)
              {
                Expression.TempDesc[index2, index3] = stringListClass.TempDesc[index2, index3];
                Expression.TempBmp[index2, index3] = stringListClass.TempBmp[index2, index3];
              }
            }
          }
        }
        this.RemoveSubPart(this.pageId);
        this.pageId = 0;
        dontDrawPage = true;
      }
      this.initTabs();
      this.dostuff(dontDrawPage);
      if (num > 0 & this.pageId > 0 & dontDrawPage & this.prevPageId == this.curPageId)
        ((UDSPartClass) this.SubPartList[this.SubpartNr(this.pageId)]).curY = num;
      if (!(this.pageId > 0 & dontDrawPage))
        return;
      UDSPartClass subPart1 = (UDSPartClass) this.SubPartList[this.SubpartNr(this.pageId)];
      int elementCounter1 = subPart1.dyn.elementCounter;
      for (int index = 0; index <= elementCounter1; ++index)
      {
        if (dyn.elementCounter >= index)
        {
          if (subPart1.dyn.element[index].type == dyn.element[index].type && subPart1.dyn.element[index].x == dyn.element[index].x & subPart1.dyn.element[index].y == dyn.element[index].y)
          {
            subPart1.dyn.element[index].topRow = dyn.element[index].topRow;
            if (subPart1.dyn.element[index].parentElement > -1)
            {
              subPart1.dyn.element[index].grayed = dyn.element[index].grayed;
              subPart1.dyn.element[index].texty = dyn.element[index].texty;
            }
          }
          if (subPart1.dyn.element[index].type == UDSType.Table & !Information.IsNothing((object) Expression))
          {
            StringListClass stringListClass = this.game.Data.StringListObj[(int) Math.Round(Conversion.Val(subPart1.dyn.element[index].texty))];
            this.game.Data.StringListObj[(int) Math.Round(Conversion.Val(subPart1.dyn.element[index].texty))] = Expression;
          }
        }
      }
      subPart1.MakeBitmap();
    }

    public void dostuff(bool dontDrawPage = false)
    {
      if (this.stringlistslot == -1)
        return;
      int num1 = 0;
      int subtabcount1 = this.subtabcount;
      for (int index = 1; index <= subtabcount1; ++index)
      {
        if (this.pagecount[index] > 0)
          ++num1;
      }
      int num2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.stringlistslot].Data[this.pagerow[this.subtabnr, this.pagenr], 6]));
      if (num2 > 0)
      {
        int num3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.stringlistslot].Data[this.pagerow[this.subtabnr, this.pagenr], 10]));
        int num4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.stringlistslot].Data[this.pagerow[this.subtabnr, this.pagenr], 11]));
        int num5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.stringlistslot].Data[this.pagerow[this.subtabnr, this.pagenr], 12]));
        int num6 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.stringlistslot].Data[this.pagerow[this.subtabnr, this.pagenr], 13]));
        string Left = num2.ToString() + "," + num3.ToString() + "," + num4.ToString() + "," + num5.ToString() + "," + num6.ToString();
        if (Operators.CompareString(Left, this.lastEventNr, false) != 0 && this.pageId > 0)
        {
          this.RemoveSubPart(this.pageId);
          this.pageId = 0;
        }
        this.lastEventNr = Left;
      }
      else
      {
        if (Operators.CompareString(this.lastEventNr, this.game.Data.StringListObj[this.stringlistslot].Data[this.pagerow[this.subtabnr, this.pagenr], 8], false) != 0 && this.pageId > 0)
        {
          this.RemoveSubPart(this.pageId);
          this.pageId = 0;
        }
        this.lastEventNr = this.game.Data.StringListObj[this.stringlistslot].Data[this.pagerow[this.subtabnr, this.pagenr], 8];
      }
      if (this.prevPageNr != this.pagenr && this.pageId > 0)
      {
        this.RemoveSubPart(this.pageId);
        this.pageId = 0;
      }
      this.ClearMouse();
      if (!dontDrawPage)
        this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      Rectangle trect1 = DrawMod.DrawBackTab(g, this.w, this.h, this.tabname, this.game.EditObj.SetViewMode2);
      this.AddMouse(ref trect1, "CLOSE TAB", "Click here to close this tab. [ESC]", 999);
      if (num1 == 0)
      {
        DrawMod.DrawTextColouredMarcCenter(ref g, "No decisions remaining.", this.game.MarcFont4, 100, 40, Color.White);
      }
      else
      {
        if (this.subtabcount < 1)
          return;
        int width = (int) Math.Round((double) Math.Min(this.w - 80, 1180) / (double) this.subtabcount);
        if (width > 250)
          width = 250;
        g.SmoothingMode = SmoothingMode.None;
        DrawMod.drawLineDot(ref g, 25, 8, 25 + width * this.subtabcount + 25, 8, Color.White);
        DrawMod.drawLineDot(ref g, 25, 52, 25 + width * this.subtabcount + 25, 52, Color.White);
        DrawMod.drawLineDot(ref g, 25, 10, 25, 50, Color.White);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.PixelOffsetMode = PixelOffsetMode.Half;
        int num7 = 0;
        if (this.subtabnr > 0 && this.pagecount[this.subtabnr] < 1)
          this.subtabnr = -1;
        int subtabcount2 = this.subtabcount;
        for (int index1 = 1; index1 <= subtabcount2; ++index1)
        {
          if (this.pagecount[index1] > 0)
          {
            ++num7;
            int num8 = 25 + (num7 - 1) * width;
            int num9 = 10;
            if (this.subtabnr == -1)
              this.subtabnr = index1;
            if (index1 == this.subtabnr)
            {
              DrawMod.DrawBlockGradient(ref g, num8, num9, (int) Math.Round((double) width / 2.0), 40, Color.FromArgb(0, 0, 0, 0), Color.FromArgb(96, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
              DrawMod.DrawBlockGradient(ref g, num8 + (int) Math.Round((double) width / 2.0), num9, (int) Math.Round((double) width / 2.0), 40, Color.FromArgb(96, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), Color.FromArgb(0, 0, 0, 0));
            }
            SizeF sizeF = new SizeF();
            int num10 = (int) Math.Round((double) g.MeasureString(this.subtabname[index1], this.game.MarcFont4).Width);
            Rectangle trect2 = new Rectangle(num8, num9, width, 40);
            this.AddMouse(ref trect2, this.subtabname[index1], "Click to see all pages for this tab.", 1000 + index1);
            if (num10 > width - 20 & Strings.InStr(this.subtabname[index1], " ") > 0)
            {
              string[] strArray = this.subtabname[index1].Split(' ');
              string tstring1 = "";
              string tstring2 = "";
              int upperBound = strArray.GetUpperBound(0);
              for (int index2 = 0; index2 <= upperBound; ++index2)
              {
                if ((double) index2 < Math.Max(1.0, (double) strArray.GetUpperBound(0) / 2.0))
                {
                  if (tstring1.Length > 0)
                    tstring1 += " ";
                  tstring1 += strArray[index2];
                }
                else
                {
                  if (tstring2.Length > 0)
                    tstring2 += " ";
                  tstring2 += strArray[index2];
                }
              }
              DrawMod.DrawTextColouredMarcCenter(ref g, tstring1, this.game.MarcFont4, (int) Math.Round((double) num8 + (double) width / 2.0), num9 + 3, Color.White);
              DrawMod.DrawTextColouredMarcCenter(ref g, tstring2, this.game.MarcFont4, (int) Math.Round((double) num8 + (double) width / 2.0), num9 + 20, Color.White);
            }
            else
              DrawMod.DrawTextColouredMarcCenter(ref g, this.subtabname[index1], this.game.MarcFont4, (int) Math.Round((double) num8 + (double) width / 2.0), num9 + 12, Color.White);
            g.SmoothingMode = SmoothingMode.None;
            DrawMod.drawLineDot(ref g, num8 + width, num9, num8 + width, num9 + 40, Color.White);
            g.SmoothingMode = SmoothingMode.AntiAlias;
          }
        }
        int num11 = 0;
        int num12 = 0;
        int num13 = 0;
        if (this.w < 1240)
        {
          int num14 = 1240 - this.w;
          num11 = (int) Math.Round((double) num14 * 0.65);
          int num15 = (int) Math.Round((double) num14 * 0.35);
          if (num15 > 10)
          {
            num12 = 10;
            num15 -= 10;
          }
          if (num15 > 10)
          {
            num13 = 10;
            num15 -= 10;
          }
          if (num15 > 10)
          {
            num13 += 10;
            num15 -= 10;
          }
          if (num15 > 10)
          {
            num13 += 10;
            int num16 = num15 - 10;
          }
        }
        int num17 = 25;
        int num18 = 74;
        int overruleItemSize1 = 24;
        int tlistsize1 = (int) Math.Round((double) (this.h - 134) / (double) overruleItemSize1) - 1;
        this.OptionsListObj = new ListClass();
        if (this.subtabnr < 0)
          return;
        int num19 = this.pagecount[this.subtabnr];
        for (int tdata = 1; tdata <= num19; ++tdata)
        {
          if (this.pagenr < 1)
            this.pagenr = tdata;
          if (this.pageclickable[this.subtabnr, tdata] > 0)
            this.OptionsListObj.add(this.pagename[this.subtabnr, tdata], tdata);
          else
            this.OptionsListObj.add(this.pagename[this.subtabnr, tdata].ToUpper(), -1);
        }
        if (this.pagenr > this.pagecount[this.subtabnr])
          this.pagenr = this.pagecount[this.subtabnr];
        SubPartClass tsubpart;
        if (this.OptionsListId > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, this.pagenr - 1);
          this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
        }
        else if (num11 > 10)
        {
          ListClass optionsListObj = this.OptionsListObj;
          int tlistsize2 = tlistsize1;
          int twidth = 250 - num11;
          int tlistselect = this.pagenr - 1;
          GameClass game = this.game;
          ref Bitmap local1 = ref this.OwnBitmap;
          int bbx = num17;
          int bby = num18;
          Font font = (Font) null;
          ref Font local2 = ref font;
          int overruleItemSize2 = overruleItemSize1;
          tsubpart = (SubPartClass) new ListSubPartClass(optionsListObj, tlistsize2, twidth, tlistselect, game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: bbx, bby: bby, tMarcStyle: true, overruleFont: (ref local2), overruleItemSize: overruleItemSize2);
          this.OptionsListId = this.AddSubPart(ref tsubpart, num17, num18, 250 - num11, (tlistsize1 + 1) * overruleItemSize1, 0);
        }
        else
        {
          tsubpart = (SubPartClass) new ListSubPartClass(this.OptionsListObj, tlistsize1, 250 - num11, this.pagenr - 1, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num17, bby: num18, tMarcStyle: true, overruleFont: (ref this.game.MarcFont7), overruleItemSize: overruleItemSize1);
          this.OptionsListId = this.AddSubPart(ref tsubpart, num17, num18, 250 - num11, (tlistsize1 + 1) * overruleItemSize1, 0);
        }
        int num20 = 293 - (num12 + num11);
        int num21 = 74;
        int num22 = this.w - (326 - num13) + num11;
        int num23 = this.h - 124;
        int enr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.stringlistslot].Data[this.pagerow[this.subtabnr, this.pagenr], 6]));
        if (this.pageId == 0)
        {
          this.game.EditObj.UdsInsideTabOpenMode = false;
          int num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.stringlistslot].Data[this.pagerow[this.subtabnr, this.pagenr], 9]));
          string udStabText;
          if (enr > 0)
          {
            int tv0 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.stringlistslot].Data[this.pagerow[this.subtabnr, this.pagenr], 10]));
            int tv1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.stringlistslot].Data[this.pagerow[this.subtabnr, this.pagenr], 11]));
            int tv2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.stringlistslot].Data[this.pagerow[this.subtabnr, this.pagenr], 12]));
            int tv3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.stringlistslot].Data[this.pagerow[this.subtabnr, this.pagenr], 13]));
            this.game.EventRelatedObj.DoCheckSpecificEvent(enr, tv0, tv1, tv2, tv3);
            udStabText = this.game.EditObj.UDStabText;
            int num25 = (int) Math.Round(Conversion.Val((object) Conversions.ToInteger(this.game.Data.StringListObj[this.stringlistslot].GetData(4, this.subtabname[this.subtabnr], 0))));
            if (!(num25 >= 77 & num25 <= 79))
            {
              int id = this.game.EventRelatedObj.CheckStringlistID("SE_IO", 158, 0, 0);
              this.game.EventRelatedObj.IO_AddClear();
              this.game.EventRelatedObj.IO_AddStamp(2, -35, -35);
              string str = this.game.EventRelatedObj.CheckKey(id, "FINALTEXT", 0, 0);
              udStabText += str;
            }
            this.game.EditObj.UDStabText = "";
          }
          else
            udStabText = this.game.Data.StringListObj[this.stringlistslot].Data[this.pagerow[this.subtabnr, this.pagenr], 8];
          this.prevPageId = this.curPageId;
          this.curPageId = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.stringlistslot].Data[this.pagerow[this.subtabnr, this.pagenr], 0]));
          if (dontDrawPage)
          {
            tsubpart = (SubPartClass) new UDSPartClass(this.game, num22, num23, udStabText, ref this.OwnBitmap, num20, num21, tAllGray: (num24 == 1), noBitmapDraw: true);
            this.pageId = this.AddSubPart(ref tsubpart, num20, num21, num22, num23, 0);
          }
          else
          {
            tsubpart = (SubPartClass) new UDSPartClass(this.game, num22, num23, udStabText, ref this.OwnBitmap, num20, num21, tAllGray: (num24 == 1));
            this.pageId = this.AddSubPart(ref tsubpart, num20, num21, num22, num23, 0);
          }
        }
        else
          this.SubPartFlag[this.SubpartNr(this.pageId)] = true;
        if (this.subtabnr > -1)
          this.game.EditObj.uds_subtab[this.tabnr] = this.subtabnr;
        else
          this.game.EditObj.uds_subtab[this.tabnr] = -1;
        if (this.subtabnr <= -1)
          return;
        this.game.EditObj.uds_page[this.tabnr, this.subtabnr] = this.pagenr;
      }
    }

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.game.EditObj.interfaceCue == 1 & this.game.EditObj.SetViewMode2 > 100)
      {
        this.game.EditObj.SetViewMode2 = 0;
        this.game.EditObj.inRandomScreen = false;
        windowReturnClass.AddCommand(3, 12);
        this.game.EditObj.interfaceCue = 0;
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      if (!(this.game.EditObj.interfaceCue == 5 & this.game.EditObj.SetViewMode2 > 100))
        return windowReturnClass;
      VBMath.Randomize();
      this.game.Data.GameID = (int) Math.Round((double) (VBMath.Rnd() * 1E+08f));
      this.game.HandyFunctionsObj.RedimStats();
      this.game.HandyFunctionsObj.DoResMod();
      if (this.game.EditObj.AutoSave)
      {
        this.game.Data.specialSaveMode = 1;
        this.game.EventRelatedObj.ExecSuperImposeMessage("Saving Planet", "Making an Auto-Save of your generated Planet", 0, 0, "");
        string str = this.game.AppPath_SAVEGAMES + "lastplanetgenerated.se1";
        this.game.Data.serialize(str);
        this.game.HandyFunctionsObj.ZipFile(str);
        GC.Collect();
        Application.DoEvents();
        this.game.Data.specialSaveMode = 0;
      }
      windowReturnClass.AddCommand(3, 13);
      this.game.EditObj.SetViewMode2 = 0;
      this.game.EditObj.inRandomScreen = false;
      this.game.EditObj.interfaceCue = 0;
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
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

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false) => new WindowReturnClass();

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] > 1000)
          {
            this.subtabnr = this.MouseData[index] - 1000;
            if (this.pageId > 0)
            {
              this.RemoveSubPart(this.pageId);
              this.pageId = 0;
            }
            if (this.OptionsListId > 0)
            {
              this.RemoveSubPart(this.OptionsListId);
              this.OptionsListId = 0;
            }
            this.prevPageNr = this.pagenr;
            if (this.subtabnr > -1 && this.game.EditObj.uds_page[this.tabnr, this.subtabnr] > -1)
              this.pagenr = this.game.EditObj.uds_page[this.tabnr, this.subtabnr];
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (this.MouseData[index] == 999)
          {
            if (this.game.EditObj.SetViewMode2 > 100)
            {
              windowReturnClass.AddCommand(1, 9);
              windowReturnClass.AddCommand(7, 12);
              windowReturnClass.AddCommand(4, 114);
            }
            else if (this.game.EditObj.GuiDown | this.game.EditObj.RightDown)
            {
              this.game.EditObj.GuiDown = false;
              this.game.EditObj.RightDown = false;
              this.game.EditObj.SetViewMode2 = 0;
              windowReturnClass.AddCommand(3, 11);
            }
            else
            {
              windowReturnClass.AddCommand(1, 9);
              windowReturnClass.AddCommand(7, 12);
              windowReturnClass.AddCommand(4, 67);
            }
            this.game.EditObj.SetViewMode2 = 0;
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
      }
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
        {
          int num1 = this.SubPartID[index];
          if (num1 == this.OptionsListId)
          {
            int num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
            this.SubPartFlag[index] = true;
            if (num2 > -1 && this.pagenr != num2)
            {
              this.pagenr = num2;
              if (this.pageId > 0)
              {
                this.RemoveSubPart(this.pageId);
                this.pageId = 0;
              }
            }
            this.prevPageNr = this.pagenr;
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (num1 == this.pageId)
          {
            this.game.EditObj.interfaceCue = 0;
            int num3 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
            if (num3 > 0)
            {
              bool flag = false;
              if (this.game.EditObj.UdsInsideTabOpenMode & !Information.IsNothing((object) this.game.EditObj.udsInsideTabOpenModeList) && this.game.EditObj.udsInsideTabOpenModeList.FindNr(num3) > -1)
                flag = true;
              if (this.game.EditObj.UdsInsideTabOpenMode & flag)
              {
                if (this.pageId > 0)
                {
                  this.RemoveSubPart(this.pageId);
                  this.pageId = 0;
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              this.game.EditObj.UDSpopupText = "";
              this.formref.Cursor = Cursors.WaitCursor;
              this.game.EventRelatedObj.DoCheckSpecificEvent(num3);
              this.formref.Cursor = Cursors.Default;
              if (this.game.EditObj.interfaceCue == 2)
              {
                if (this.pageId > 0)
                {
                  this.RemoveSubPart(this.pageId);
                  this.pageId = 0;
                }
                this.game.EditObj.interfaceCue = 0;
                if (this.game.EditObj.SetViewMode2 > 100)
                {
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 114);
                  windowReturnClass.AddCommand(4, 116);
                  windowReturnClass.AddCommand(4, 9);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                windowReturnClass.AddCommand(7, 12);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 9);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.EditObj.UDSpopupText.Length > 1)
              {
                this.game.EditObj.PopupValue = 21;
                this.game.EditObj.udsLastCalledPopupEventNr = num3;
                windowReturnClass.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else if (this.game.EditObj.interfaceCue == 2)
            {
              if (this.pageId > 0)
              {
                this.RemoveSubPart(this.pageId);
                this.pageId = 0;
              }
              this.game.EditObj.interfaceCue = 0;
              if (this.game.EditObj.SetViewMode2 > 100)
              {
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 114);
                windowReturnClass.AddCommand(4, 116);
                windowReturnClass.AddCommand(4, 9);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              windowReturnClass.AddCommand(7, 12);
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 69);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 9);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            this.SubPartFlag[index] = true;
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
      }
      if (x > 8 & x < this.w - 8 && y < this.h - 24)
        windowReturnClass.NoMouseClickBelow = true;
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }
  }
}
