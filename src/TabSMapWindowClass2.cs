// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TabSMapWindowClass2
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
  public class TabSMapWindowClass2 : WindowClass
  {
    private int Info1Id;
    private int info2id;
    private string ShowString;
    private DateTime ShowTime;
    private int w;
    private int h;
    private int CurrentView;
    private int detailnr;
    private int regnr;
    private int subtab;
    private int B1Id;
    private int B1TextId;
    private int B2Id;
    private int B2TextId;
    private int b3Id;
    private int b3textid;
    private int b4Id;
    private int b4textid;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int OptionsList3Id;
    private ListClass OptionsList3Obj;
    private int[] regimesToBeShown;
    private int[] zonesToBeShown;

    public TabSMapWindowClass2(
      ref GameClass tGame,
      ref WindowClass tLowerWindow,
      ref Rectangle tLowerRect,
      Rectangle trect)
      : base(ref tGame, trect.Width, trect.Height, 8)
    {
      this.regimesToBeShown = new int[1];
      this.zonesToBeShown = new int[1];
      this.w = trect.Width;
      this.h = trect.Height;
      this.game.DC2AIObj.SetTempHexNeighbours();
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.game.EditObj.MiniMap = new Bitmap(10, 10);
      this.prepareTempValue4();
      this.regnr = this.game.Data.Turn;
      this.detailnr = -1;
      if (this.game.SelectX > -1)
        this.detailnr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime;
      if (this.game.EditObj.se1_StrategyTab > -1)
      {
        this.subtab = this.game.EditObj.se1_StrategyTab;
        if (this.subtab > 0)
          this.detailnr = -1;
      }
      if (this.subtab == 2)
        this.detailnr = this.game.EditObj.se1_StrategySpecial1;
      this.dostuff();
    }

    public override void DoRefresh() => this.dostuff();

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int num1 = -1;
      if (nr == 40)
      {
        this.SubPartList[this.SubpartNr(this.OptionsListId)].ShiftDown();
        this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
        if (this.subtab == 0)
        {
          this.detailnr = this.SubPartList[this.SubpartNr(this.OptionsListId)].GetSelect();
          this.dostuff();
          windowReturnClass.SetFlag(true);
        }
        else
          num1 = this.SubPartList[this.SubpartNr(this.OptionsListId)].GetSelect();
      }
      if (nr == 38)
      {
        this.SubPartList[this.SubpartNr(this.OptionsListId)].ShiftUp();
        this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
        if (this.subtab == 0)
        {
          this.detailnr = this.SubPartList[this.SubpartNr(this.OptionsListId)].GetSelect();
          this.dostuff();
          windowReturnClass.SetFlag(true);
        }
        else
          num1 = this.SubPartList[this.SubpartNr(this.OptionsListId)].GetSelect();
      }
      if (num1 > -1)
      {
        bool flag1 = false;
        if (this.subtab == 0)
        {
          if (num1 >= -1 & num1 != this.detailnr)
          {
            this.detailnr = num1;
            this.prepareTempValue4();
            flag1 = true;
          }
        }
        else if (this.subtab == 1 && num1 >= -1 & num1 != this.detailnr)
        {
          this.detailnr = num1;
          this.prepareTempValue4();
          flag1 = true;
        }
        int num2 = -1;
        int num3 = -1;
        bool flag2 = false;
        if (flag1)
        {
          int num4;
          int num5;
          if (this.subtab == 1)
          {
            int stringListById = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
            num4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, this.detailnr, 10)));
            num5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, this.detailnr, 11)));
            SimpleList simpleList = new SimpleList();
            int mapWidth = this.game.Data.MapObj[0].MapWidth;
            for (int tdata1 = 0; tdata1 <= mapWidth; ++tdata1)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int tdata2 = 0; tdata2 <= mapHeight; ++tdata2)
              {
                if (this.game.EditObj.TempValue4[0].Value[tdata1, tdata2] == this.detailnr && this.game.Data.MapObj[0].HexObj[tdata1, tdata2].MaxRecon > 0)
                {
                  int tweight = !(tdata1 == num4 & tdata2 == num5) ? (this.game.Data.MapObj[0].HexObj[tdata1, tdata2].Location <= -1 ? (this.game.Data.MapObj[0].HexObj[tdata1, tdata2].UnitCounter <= -1 ? 1 : 5) : 10) : 100;
                  simpleList.Add(tdata2 * this.game.Data.MapObj[0].MapWidth + tdata1, tweight, tdata1, tdata2);
                }
              }
            }
            simpleList.ReverseSortHighSpeed();
            if (simpleList.Counter > -1)
            {
              flag2 = true;
              num2 = simpleList.Data1[0];
              num3 = simpleList.Data2[0];
              this.game.EditObj.SetViewModeExtraNr = 1;
            }
          }
          if (this.subtab == 0 & this.detailnr > -1)
          {
            int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 143, 0, 0))].GetData(0, this.game.Data.RegimeObj[this.detailnr].id, 12)));
            if (id > 0)
            {
              int locationById = this.game.HandyFunctionsObj.GetLocationByID(id);
              if (locationById > -1)
              {
                num4 = this.game.Data.LocObj[locationById].X;
                num5 = this.game.Data.LocObj[locationById].Y;
              }
            }
            SimpleList simpleList = new SimpleList();
            int mapWidth = this.game.Data.MapObj[0].MapWidth;
            for (int tdata1 = 0; tdata1 <= mapWidth; ++tdata1)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int tdata2 = 0; tdata2 <= mapHeight; ++tdata2)
              {
                if (this.game.EditObj.TempValue4[0].Value[tdata1, tdata2] == this.game.Data.RegimeObj[this.detailnr].id && this.game.Data.MapObj[0].HexObj[tdata1, tdata2].MaxRecon > 0)
                {
                  int tweight = !(tdata1 == num4 & tdata2 == num5) ? (this.game.Data.MapObj[0].HexObj[tdata1, tdata2].Location <= -1 ? (this.game.Data.MapObj[0].HexObj[tdata1, tdata2].UnitCounter <= -1 ? 1 : 5) : 10) : 100;
                  simpleList.Add(tdata2 * this.game.Data.MapObj[0].MapWidth + tdata1, tweight, tdata1, tdata2);
                }
              }
            }
            simpleList.ReverseSortHighSpeed();
            if (simpleList.Counter > -1)
            {
              flag2 = true;
              num2 = simpleList.Data1[0];
              num3 = simpleList.Data2[0];
              this.game.EditObj.SetViewModeExtraNr = 2;
            }
          }
        }
        if (flag2 & num2 > -1 & num3 > -1)
        {
          this.game.SelectX = num2;
          this.game.SelectY = num3;
          this.game.EditObj.UnitSelected = -1;
          if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > -1)
            this.game.EditObj.UnitSelected = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0];
          this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
          int num6 = this.game.EditObj.ShowHQ ? 1 : 0;
          windowReturnClass.AddCommand(4, 69);
          windowReturnClass.AddCommand(4, 68);
          flag1 = true;
        }
        if (flag1)
        {
          this.dostuff();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      return windowReturnClass;
    }

    public void dostuff()
    {
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 288, 0, 0));
      int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 275, 0, 0));
      int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 143, 0, 0));
      int stringListById5 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0));
      int stringListById6 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 306, 0, 0));
      int num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData(0, 58, 2)));
      if (this.B1Id > 0)
      {
        this.RemoveSubPart(this.B1Id);
        this.B1Id = 0;
      }
      if (this.B2Id > 0)
      {
        this.RemoveSubPart(this.B2Id);
        this.B2Id = 0;
      }
      if (this.B2TextId > 0)
      {
        this.RemoveSubPart(this.B2TextId);
        this.B2TextId = 0;
      }
      if (this.b3Id > 0)
      {
        this.RemoveSubPart(this.b3Id);
        this.b3Id = 0;
      }
      if (this.b3textid > 0)
      {
        this.RemoveSubPart(this.b3textid);
        this.b3textid = 0;
      }
      if (this.b4Id > 0)
      {
        this.RemoveSubPart(this.b4Id);
        this.b4Id = 0;
      }
      if (this.b4textid > 0)
      {
        this.RemoveSubPart(this.b4textid);
        this.b4textid = 0;
      }
      if (this.info2id > 0)
      {
        this.RemoveSubPart(this.info2id);
        this.info2id = 0;
      }
      if (this.Info1Id > 0)
      {
        this.RemoveSubPart(this.Info1Id);
        this.Info1Id = 0;
      }
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      this.ClearMouse();
      Rectangle trect1 = DrawMod.DrawBackTab(objgraphics, this.w, this.h, "S.MAP", 6);
      this.AddMouse(ref trect1, "CLOSE TAB", "Click here to close this tab. [ESC/F7]", 999);
      int num2 = this.w - 680;
      bool tpaintview;
      if (this.game.EditObj.Zoom == 0)
      {
        if ((double) (this.game.Data.MapObj[0].MapHeight + this.game.Data.MapObj[0].MapWidth) > (double) this.game.ScreenWidth / 52.0 + (double) this.game.ScreenHeight / 48.0)
          tpaintview = true;
      }
      else if (this.game.EditObj.Zoom == -1)
      {
        if ((double) (this.game.Data.MapObj[0].MapHeight + this.game.Data.MapObj[0].MapWidth) > (double) this.game.ScreenWidth / 27.0 + (double) this.game.ScreenHeight / 24.0)
          tpaintview = true;
      }
      else if (this.game.EditObj.Zoom == 1 && (double) (this.game.Data.MapObj[0].MapHeight + this.game.Data.MapObj[0].MapWidth) > (double) this.game.ScreenWidth / 104.0 + (double) this.game.ScreenHeight / 96.0)
        tpaintview = true;
      if (this.subtab == 1 & this.detailnr < 0)
        this.detailnr = 0;
      int ttempValue4mustBe = this.detailnr;
      if (this.subtab == 0 & this.detailnr > -1)
        ttempValue4mustBe = this.game.Data.RegimeObj[this.detailnr].id;
      bool tTempZones = false;
      if (this.subtab == 1)
        tTempZones = true;
      if (this.subtab > 0)
        this.game.EditObj.se1_StrategySpecial2 = 0;
      if (this.subtab == 2)
      {
        SubPartClass tsubpart = (SubPartClass) new MiniMapPartClass(DrawMod.TGame, tpaintview, this.w - 300, this.h - 40, true, true, this.game.ScreenWidth, this.game.ScreenHeight - 340, this.game.EditObj.Zoom, alsoHQ: this.game.EditObj.ShowHQ, tTempZones: tTempZones, tspecialMode1: this.detailnr);
        this.Info1Id = this.AddSubPart(ref tsubpart, 10, 0, this.w - 300, this.h - 40, 0);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new MiniMapPartClass(DrawMod.TGame, tpaintview, this.w - 300, this.h - 40, true, true, this.game.ScreenWidth, this.game.ScreenHeight - 340, this.game.EditObj.Zoom, alsoHQ: this.game.EditObj.ShowHQ, ttempValue4mustBe: ttempValue4mustBe, tTempValue3usedForAlpha: true, tTempAi2use: true, tTempZones: tTempZones);
        this.Info1Id = this.AddSubPart(ref tsubpart, 10, 0, this.w - 300, this.h - 40, 0);
      }
      this.OptionsListObj = new ListClass();
      int tlistselect = -1;
      SizeF sizeF = new SizeF();
      int x1 = 410 + num2;
      int num3 = this.h - 200;
      int num4 = (int) Math.Round(Math.Floor((double) num3 / 24.0));
      int num5 = 24;
      if (this.subtab == 0)
      {
        int num6 = -1;
        this.OptionsListObj.add("  --None-- ", -1);
        if (this.game.Data.RegimeCounter > -1)
        {
          int regimeCounter = this.game.Data.RegimeCounter;
          for (int tdata = 0; tdata <= regimeCounter; ++tdata)
          {
            if (this.regimesToBeShown[tdata] == -1)
            {
              string name = this.game.Data.RegimeObj[tdata].Name;
              int num7 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, this.game.Data.RegimeObj[tdata].id, 2, "recon", 3)));
              string tname;
              if (tdata == 1)
                tname = "  --" + name + "-- ";
              else if (tdata == this.game.Data.Turn)
                tname = "⍟ " + name;
              else if (num7 >= 2)
              {
                switch ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, this.game.Data.RegimeObj[tdata].id, 1))))
                {
                  case 1:
                    tname = "⌾ " + name;
                    break;
                  case 2:
                    int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, this.game.Data.RegimeObj[tdata].id, 2)));
                    tname = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData(0, idValue, 1))) != num1 ? "∘ " + name : "∞ " + name;
                    break;
                  case 3:
                    tname = "⊷ " + name;
                    break;
                  default:
                    tname = "  " + name;
                    break;
                }
              }
              else
              {
                switch ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, this.game.Data.RegimeObj[tdata].id, 1))))
                {
                  case 1:
                    tname = "⌾ " + name;
                    break;
                  case 2:
                    tname = "∘ " + name;
                    break;
                  case 3:
                    tname = "⊷ " + name;
                    break;
                  default:
                    tname = "  " + name;
                    break;
                }
              }
              this.OptionsListObj.add(tname, tdata);
            }
          }
          this.OptionsListObj.Sort();
          int listCount = this.OptionsListObj.ListCount;
          for (int index = 0; index <= listCount; ++index)
          {
            ++num6;
            if (this.OptionsListObj.ListData[index] == this.detailnr)
              tlistselect = num6;
          }
          if (this.OptionsListId > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect);
            this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(this.OptionsListObj, num4 - 1, 250, tlistselect, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: (410 + num2), bby: num5, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
            this.OptionsListId = this.AddSubPart(ref tsubpart, 410 + num2, num5, 250, num4 * 24, 0);
          }
        }
      }
      else if (this.subtab == 1)
      {
        int num8 = -1;
        this.OptionsListObj.add(" --None-- ", 0);
        int length = this.game.Data.StringListObj[stringListById1].Length;
        for (int index1 = 0; index1 <= length; ++index1)
        {
          int index2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index1, 0]));
          int num9 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index1, 8]));
          string tname = this.game.Data.StringListObj[stringListById1].Data[index1, 7];
          if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, index2, 2, "recon", 3))) > -1 | num9 == this.game.Data.RegimeObj[this.game.Data.Turn].id | this.zonesToBeShown[index2] == -1)
          {
            if (num9 == this.game.Data.RegimeObj[this.game.Data.Turn].id)
              tname += " *";
            this.OptionsListObj.add(tname, index2);
          }
        }
        this.OptionsListObj.Sort();
        int listCount = this.OptionsListObj.ListCount;
        for (int index = 0; index <= listCount; ++index)
        {
          ++num8;
          if (this.OptionsListObj.ListData[index] == this.detailnr)
            tlistselect = num8;
        }
        if (this.OptionsListId > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect);
          this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
        }
        else
        {
          SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(this.OptionsListObj, num4 - 1, 250, tlistselect, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: (410 + num2), bby: num5, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
          this.OptionsListId = this.AddSubPart(ref tsubpart, 410 + num2, num5, 250, num4 * 24, 0);
        }
      }
      else if (this.subtab == 2)
      {
        int num10 = 0;
        if (this.detailnr < 0)
          this.detailnr = 0;
        this.OptionsListObj.add("-- Nothing --", 0);
        if (this.detailnr > 12)
          this.detailnr = 0;
        if (0 == this.detailnr)
          tlistselect = num10;
        int num11 = num10 + 1;
        this.OptionsListObj.add("All Resources", 6);
        if (6 == this.detailnr)
          tlistselect = num11;
        int num12 = 1;
        do
        {
          ++num11;
          if (num12 == 1)
            this.OptionsListObj.add("Oil", 1);
          if (num12 == 2)
            this.OptionsListObj.add("Metals", 2);
          if (num12 == 3)
            this.OptionsListObj.add("Rare Metals", 3);
          if (num12 == 4)
            this.OptionsListObj.add("Radioactives", 4);
          if (num12 == 5)
            this.OptionsListObj.add("Water", 5);
          if (num12 == 6)
            this.OptionsListObj.add("Rain", 7);
          if (num12 == 7)
            this.OptionsListObj.add("Temperature", 8);
          if (num12 == 8)
            this.OptionsListObj.add("Radiation", 9);
          if (num12 == 9)
            this.OptionsListObj.add("Height", 10);
          if (num12 == 10)
            this.OptionsListObj.add("Tectonic Plates", 11);
          if (num12 == 11)
            this.OptionsListObj.add("Scavenge Points", 12);
          if (this.OptionsListObj.ListData[this.OptionsListObj.ListCount] == this.detailnr)
            tlistselect = num11;
          ++num12;
        }
        while (num12 <= 11);
        if (this.OptionsListId > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect);
          this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
        }
        else
        {
          SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(this.OptionsListObj, num4 - 1, 250, tlistselect, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: (410 + num2), bby: num5, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
          this.OptionsListId = this.AddSubPart(ref tsubpart, 410 + num2, num5, 250, num4 * 24, 0);
        }
      }
      Rectangle rectangle1;
      Rectangle trect2;
      Bitmap bitmap1;
      if (this.subtab == 2)
      {
        ref Graphics local1 = ref objgraphics;
        Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local2 = ref bitmap2;
        Rectangle rectangle2 = new Rectangle(0, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect1 = rectangle2;
        rectangle1 = new Rectangle(x1 + 0, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect1 = rectangle1;
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
        ref Graphics local3 = ref objgraphics;
        Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local4 = ref bitmap3;
        rectangle1 = new Rectangle(BitmapStore.GetWidth(this.game.MARCLARGETAB) - 52, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect2 = rectangle1;
        rectangle2 = new Rectangle(x1 + 52, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect2 = rectangle2;
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        string str1 = "REGIMES";
        sizeF = objgraphics.MeasureString(str1, this.game.MarcFont16);
        int x2 = x1 + 20;
        int y1 = 0;
        DrawMod.DrawTextColouredMarc(ref objgraphics, str1, this.game.MarcFont16, x2, y1 + 4, Color.White);
        rectangle1 = new Rectangle(x1, y1, 80, 24);
        trect2 = rectangle1;
        this.AddMouse(ref trect2, "", "Click to select a regime", 101);
        ref Graphics local5 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local6 = ref bitmap1;
        rectangle1 = new Rectangle(0, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect3 = rectangle1;
        trect2 = new Rectangle(x1 + 70, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect3 = trect2;
        DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
        ref Graphics local7 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local8 = ref bitmap1;
        rectangle1 = new Rectangle(BitmapStore.GetWidth(this.game.MARCLARGETAB) - 52, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect4 = rectangle1;
        trect2 = new Rectangle(x1 + 122, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect4 = trect2;
        DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
        string str2 = "ZONES";
        sizeF = objgraphics.MeasureString(str2, this.game.MarcFont16);
        int x3 = x1 + 20 + 70;
        int y2 = 0;
        DrawMod.DrawTextColouredMarc(ref objgraphics, str2, this.game.MarcFont16, x3, y2 + 4, Color.White);
        rectangle1 = new Rectangle(x1 + 70, y2, 182, 24);
        trect2 = rectangle1;
        this.AddMouse(ref trect2, "", "Click to select a Zone", 102);
        ref Graphics local9 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local10 = ref bitmap1;
        rectangle1 = new Rectangle(0, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect5 = rectangle1;
        trect2 = new Rectangle(x1 + 140, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect5 = trect2;
        DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
        ref Graphics local11 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local12 = ref bitmap1;
        rectangle1 = new Rectangle(BitmapStore.GetWidth(this.game.MARCLARGETAB) - 52, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect6 = rectangle1;
        trect2 = new Rectangle(x1 + 122 + 70, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect6 = trect2;
        DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
        string str3 = "STATS";
        sizeF = objgraphics.MeasureString(str3, this.game.MarcFont16);
        int x4 = x1 + 20 + 140;
        int y3 = 0;
        DrawMod.DrawTextColouredMarc(ref objgraphics, str3, this.game.MarcFont16, x4, y3 + 4, Color.White);
        rectangle1 = new Rectangle(x1 + 140, y3, 80, 24);
        trect2 = rectangle1;
        this.AddMouse(ref trect2, "", "Click to select a specific Stat to inspect", 103);
      }
      if (this.subtab == 1)
      {
        ref Graphics local13 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local14 = ref bitmap1;
        rectangle1 = new Rectangle(0, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect7 = rectangle1;
        trect2 = new Rectangle(x1 + 0, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect7 = trect2;
        DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
        ref Graphics local15 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local16 = ref bitmap1;
        rectangle1 = new Rectangle(BitmapStore.GetWidth(this.game.MARCLARGETAB) - 52, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect8 = rectangle1;
        trect2 = new Rectangle(x1 + 52, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect8 = trect2;
        DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
        string str4 = "REGIMES";
        sizeF = objgraphics.MeasureString(str4, this.game.MarcFont16);
        int x5 = x1 + 20;
        int y4 = 0;
        DrawMod.DrawTextColouredMarc(ref objgraphics, str4, this.game.MarcFont16, x5, y4 + 4, Color.White);
        rectangle1 = new Rectangle(x1, y4, 80, 24);
        trect2 = rectangle1;
        this.AddMouse(ref trect2, "", "Click to select a regime", 101);
        ref Graphics local17 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local18 = ref bitmap1;
        rectangle1 = new Rectangle(0, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect9 = rectangle1;
        trect2 = new Rectangle(x1 + 140, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect9 = trect2;
        DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
        ref Graphics local19 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local20 = ref bitmap1;
        rectangle1 = new Rectangle(BitmapStore.GetWidth(this.game.MARCLARGETAB) - 52, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect10 = rectangle1;
        trect2 = new Rectangle(x1 + 122 + 70, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect10 = trect2;
        DrawMod.DrawSimplePart2(ref local19, ref local20, srcrect10, destrect10);
        string str5 = "STATS";
        sizeF = objgraphics.MeasureString(str5, this.game.MarcFont16);
        int x6 = x1 + 20 + 140;
        int y5 = 0;
        DrawMod.DrawTextColouredMarc(ref objgraphics, str5, this.game.MarcFont16, x6, y5 + 4, Color.White);
        rectangle1 = new Rectangle(x1 + 140, y5, 80, 24);
        trect2 = rectangle1;
        this.AddMouse(ref trect2, "", "Click to select a specific Stat to inspect", 103);
        ref Graphics local21 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local22 = ref bitmap1;
        rectangle1 = new Rectangle(0, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect11 = rectangle1;
        trect2 = new Rectangle(x1 + 70, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect11 = trect2;
        DrawMod.DrawSimplePart2(ref local21, ref local22, srcrect11, destrect11);
        ref Graphics local23 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local24 = ref bitmap1;
        rectangle1 = new Rectangle(BitmapStore.GetWidth(this.game.MARCLARGETAB) - 52, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect12 = rectangle1;
        trect2 = new Rectangle(x1 + 122, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect12 = trect2;
        DrawMod.DrawSimplePart2(ref local23, ref local24, srcrect12, destrect12);
        string str6 = "ZONES";
        sizeF = objgraphics.MeasureString(str6, this.game.MarcFont16);
        int x7 = x1 + 20 + 70;
        int y6 = 0;
        DrawMod.DrawTextColouredMarc(ref objgraphics, str6, this.game.MarcFont16, x7, y6 + 4, Color.White);
        rectangle1 = new Rectangle(x1 + 70, y6, 182, 24);
        trect2 = rectangle1;
        this.AddMouse(ref trect2, "", "Click to select a Zone", 102);
      }
      if (this.subtab == 0)
      {
        ref Graphics local25 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local26 = ref bitmap1;
        rectangle1 = new Rectangle(0, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect13 = rectangle1;
        trect2 = new Rectangle(x1 + 140, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect13 = trect2;
        DrawMod.DrawSimplePart2(ref local25, ref local26, srcrect13, destrect13);
        ref Graphics local27 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local28 = ref bitmap1;
        rectangle1 = new Rectangle(BitmapStore.GetWidth(this.game.MARCLARGETAB) - 52, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect14 = rectangle1;
        trect2 = new Rectangle(x1 + 122 + 70, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect14 = trect2;
        DrawMod.DrawSimplePart2(ref local27, ref local28, srcrect14, destrect14);
        string str7 = "STATS";
        sizeF = objgraphics.MeasureString(str7, this.game.MarcFont16);
        int x8 = x1 + 20 + 140;
        int y7 = 0;
        DrawMod.DrawTextColouredMarc(ref objgraphics, str7, this.game.MarcFont16, x8, y7 + 4, Color.White);
        rectangle1 = new Rectangle(x1 + 140, y7, 80, 24);
        trect2 = rectangle1;
        this.AddMouse(ref trect2, "", "Click to select a specific Stat to inspect", 103);
        ref Graphics local29 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local30 = ref bitmap1;
        rectangle1 = new Rectangle(0, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect15 = rectangle1;
        trect2 = new Rectangle(x1 + 70, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect15 = trect2;
        DrawMod.DrawSimplePart2(ref local29, ref local30, srcrect15, destrect15);
        ref Graphics local31 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local32 = ref bitmap1;
        rectangle1 = new Rectangle(BitmapStore.GetWidth(this.game.MARCLARGETAB) - 52, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect16 = rectangle1;
        trect2 = new Rectangle(x1 + 122, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect16 = trect2;
        DrawMod.DrawSimplePart2(ref local31, ref local32, srcrect16, destrect16);
        string str8 = "ZONES";
        sizeF = objgraphics.MeasureString(str8, this.game.MarcFont16);
        int x9 = x1 + 20 + 70;
        int y8 = 0;
        DrawMod.DrawTextColouredMarc(ref objgraphics, str8, this.game.MarcFont16, x9, y8 + 4, Color.White);
        rectangle1 = new Rectangle(x1 + 70, y8, 182, 24);
        trect2 = rectangle1;
        this.AddMouse(ref trect2, "", "Click to select a Zone", 102);
        ref Graphics local33 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local34 = ref bitmap1;
        rectangle1 = new Rectangle(0, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect17 = rectangle1;
        trect2 = new Rectangle(x1 + 0, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect17 = trect2;
        DrawMod.DrawSimplePart2(ref local33, ref local34, srcrect17, destrect17);
        ref Graphics local35 = ref objgraphics;
        bitmap1 = BitmapStore.GetBitmap(this.game.MARCLARGETAB);
        ref Bitmap local36 = ref bitmap1;
        rectangle1 = new Rectangle(BitmapStore.GetWidth(this.game.MARCLARGETAB) - 52, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle srcrect18 = rectangle1;
        trect2 = new Rectangle(x1 + 52, 0, 52, BitmapStore.Getheight(this.game.MARCLARGETAB));
        Rectangle destrect18 = trect2;
        DrawMod.DrawSimplePart2(ref local35, ref local36, srcrect18, destrect18);
        string str9 = "REGIMES";
        sizeF = objgraphics.MeasureString(str9, this.game.MarcFont16);
        int x10 = x1 + 20;
        int y9 = 0;
        DrawMod.DrawTextColouredMarc(ref objgraphics, str9, this.game.MarcFont16, x10, y9 + 4, Color.White);
        rectangle1 = new Rectangle(x1, y9, 80, 24);
        trect2 = rectangle1;
        this.AddMouse(ref trect2, "", "Click to select a Regime", 101);
      }
      int num13 = num3 + 32;
      if (this.detailnr > -1 & this.subtab == 0)
      {
        if (this.detailnr != this.regnr)
        {
          if (!this.game.Data.RegimeObj[this.detailnr].AI)
          {
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("MESSAGE", 240, "Send this regime a text message", ref this.OwnBitmap, 410 + num2, num13, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
            this.B1Id = this.AddSubPart(ref tsubpart, 410 + num2, num13, 240, 35, 1);
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("MESSAGE", 240, "Cant send message to an AI.\r\nIt will not understand.", ref this.OwnBitmap, 410 + num2, num13, true, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
            this.info2id = this.AddSubPart(ref tsubpart, 410 + num2, num13, 240, 35, 1);
          }
        }
        else
        {
          SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("MESSAGE", 240, "Cant send message to self.", ref this.OwnBitmap, 410 + num2, 290, true, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.info2id = this.AddSubPart(ref tsubpart, 410 + num2, num13, 240, 35, 1);
        }
        num13 += 48;
      }
      else if (this.subtab == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("MESSAGE", 240, "Select the regime you want to send message too first.", ref this.OwnBitmap, 410 + num2, num13, true, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.info2id = this.AddSubPart(ref tsubpart, 410 + num2, num13, 240, 35, 1);
        num13 += 48;
      }
      int num14 = 410 + num2;
      SubPartClass tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, this.game.EditObj.ShowHQ, "Show HQs on map", ref this.OwnBitmap, num14, 290);
      this.B2Id = this.AddSubPart(ref tsubpart1, num14, num13, 35, 35, 1);
      DrawMod.DrawTextColouredMarc(ref objgraphics, "SHOW HQ", this.game.MarcFont4, num14 + 40, num13 + 6, Color.White);
      int num15 = num14 + 122;
      SubPartClass tsubpart2;
      if (this.subtab < 2)
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("GO THERE", 110, "Focus map on selection.", ref this.OwnBitmap, num15, num13, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.b3Id = this.AddSubPart(ref tsubpart2, num15, num13, 110, 35, 1);
      }
      if (this.subtab < 1)
      {
        int num16 = 410 + num2;
        int y = num13 + 40;
        tsubpart2 = (SubPartClass) new MarcRadioPartClass(0, this.game.EditObj.se1_StrategySpecial2 == 1, "Diplomatic Colors will be shown.\r\nGreen for peace.\r\nRed for war\r\nOrange to Yellow-Green for unclear.", ref this.OwnBitmap, num16, 290);
        this.b4Id = this.AddSubPart(ref tsubpart2, num16, y, 35, 35, 1);
        DrawMod.DrawTextColouredMarc(ref objgraphics, "DIP.COLORS", this.game.MarcFont4, num16 + 40, y + 6, Color.White);
      }
      this.game.EditObj.se1_StrategyTab = this.subtab;
    }

    public override WindowReturnClass handleTimerWheel(int x, int y)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      windowReturnClass.Flag = false;
      if (this.SubPartCounter > -1)
      {
        for (int subPartCounter = this.SubPartCounter; subPartCounter >= 0; subPartCounter += -1)
        {
          if (x > this.SubPartX[subPartCounter] & y > this.SubPartY[subPartCounter] & x < this.SubPartX[subPartCounter] + this.SubPartW[subPartCounter] & y < this.SubPartY[subPartCounter] + this.SubPartH[subPartCounter])
          {
            SubPartClass subPart = this.SubPartList[subPartCounter];
            int x1 = x - this.SubPartX[subPartCounter];
            int y1 = y - this.SubPartY[subPartCounter];
            WindowClass windowClass = (WindowClass) this;
            ref WindowClass local = ref windowClass;
            if (subPart.HandleTimerWheel(x1, y1, ref local))
            {
              windowReturnClass.SetFlag(true);
              this.SubPartFlag[subPartCounter] = true;
              if (this.Info1Id == this.SubPartID[subPartCounter])
              {
                this.game.EditObj.MiniMap = new Bitmap(10, 10);
                this.dostuff();
              }
              return windowReturnClass;
            }
          }
        }
      }
      windowReturnClass.SetFlag(false);
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

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          switch (this.MouseData[index])
          {
            case 101:
              this.detailnr = -1;
              this.subtab = 0;
              this.RemoveSubPart(this.OptionsListId);
              this.OptionsListId = 0;
              this.prepareTempValue4();
              this.game.EditObj.MiniMap = new Bitmap(10, 10);
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            case 102:
              this.subtab = 1;
              this.detailnr = 0;
              this.RemoveSubPart(this.OptionsListId);
              this.OptionsListId = 0;
              this.prepareTempValue4();
              this.game.EditObj.MiniMap = new Bitmap(10, 10);
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            case 103:
              this.subtab = 2;
              this.detailnr = this.game.EditObj.se1_StrategySpecial1;
              this.RemoveSubPart(this.OptionsListId);
              this.OptionsListId = 0;
              this.game.HandyFunctionsObj.RedimTempValue4(-1);
              this.game.HandyFunctionsObj.RedimTempValue3(-1);
              this.game.EditObj.MiniMap = new Bitmap(10, 10);
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            case 999:
              this.game.EditObj.SetViewMode2 = 0;
              windowReturnClass.AddCommand(1, 9);
              windowReturnClass.AddCommand(7, 12);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            default:
              continue;
          }
        }
      }
      int subPartCounter = this.SubPartCounter;
      for (int index1 = 0; index1 <= subPartCounter; ++index1)
      {
        if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
        {
          int num1 = this.SubPartID[index1];
          if (num1 == this.B1Id)
          {
            new Form2((Form) this.formref).Initialize(this.game.Data, 7, this.detailnr);
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (num1 == this.B2Id)
          {
            this.game.EditObj.ShowHQ = !this.game.EditObj.ShowHQ;
            this.game.EditObj.MiniMap = new Bitmap(10, 10);
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (num1 == this.b4Id)
          {
            if (this.game.EditObj.se1_StrategySpecial2 == 0)
              this.game.EditObj.se1_StrategySpecial2 = 1;
            else
              this.game.EditObj.se1_StrategySpecial2 = 0;
            this.game.EditObj.MiniMap = new Bitmap(10, 10);
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (num1 == this.b3Id)
          {
            this.game.EditObj.UnitSelected = -1;
            if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > -1)
              this.game.EditObj.UnitSelected = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0];
            this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
            this.game.HandyFunctionsObj.SetcornerXY2();
            windowReturnClass.AddCommand(4, 12);
            windowReturnClass.AddCommand(4, 69);
            windowReturnClass.AddCommand(4, 67);
            windowReturnClass.AddCommand(4, 68);
            windowReturnClass.AddCommand(4, 9);
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (num1 == this.OptionsListId)
          {
            int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
            this.SubPartFlag[index1] = true;
            if (num2 > -1)
            {
              bool flag1 = false;
              if (this.subtab == 0)
              {
                if (num2 >= -1 & num2 != this.detailnr)
                {
                  this.detailnr = num2;
                  this.prepareTempValue4();
                  flag1 = true;
                }
              }
              else if (this.subtab == 1)
              {
                if (num2 >= -1 & num2 != this.detailnr)
                {
                  this.detailnr = num2;
                  this.prepareTempValue4();
                  flag1 = true;
                }
              }
              else if (this.subtab == 2)
              {
                this.detailnr = num2;
                this.game.EditObj.se1_StrategySpecial1 = this.detailnr;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              int num3 = -1;
              int num4 = -1;
              bool flag2 = false;
              if (flag1)
              {
                int num5;
                int num6;
                if (this.subtab == 1)
                {
                  int stringListById = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
                  num5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, this.detailnr, 10)));
                  num6 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, this.detailnr, 11)));
                  SimpleList simpleList = new SimpleList();
                  int mapWidth = this.game.Data.MapObj[0].MapWidth;
                  for (int tdata1 = 0; tdata1 <= mapWidth; ++tdata1)
                  {
                    int mapHeight = this.game.Data.MapObj[0].MapHeight;
                    for (int tdata2 = 0; tdata2 <= mapHeight; ++tdata2)
                    {
                      if (this.game.EditObj.TempValue4[0].Value[tdata1, tdata2] == this.detailnr && this.game.Data.MapObj[0].HexObj[tdata1, tdata2].MaxRecon > 0 | !this.game.Data.ShrowdOn)
                      {
                        int tweight = !(tdata1 == num5 & tdata2 == num6) ? (this.game.Data.MapObj[0].HexObj[tdata1, tdata2].Location <= -1 ? (this.game.Data.MapObj[0].HexObj[tdata1, tdata2].UnitCounter <= -1 ? 1 : 5) : 10) : 100;
                        simpleList.Add(tdata2 * this.game.Data.MapObj[0].MapWidth + tdata1, tweight, tdata1, tdata2);
                      }
                    }
                  }
                  simpleList.ReverseSortHighSpeed();
                  if (simpleList.Counter > -1)
                  {
                    flag2 = true;
                    num3 = simpleList.Data1[0];
                    num4 = simpleList.Data2[0];
                    this.game.EditObj.SetViewModeExtraNr = 1;
                  }
                }
                if (this.subtab == 0 & this.detailnr > -1)
                {
                  int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 143, 0, 0))].GetData(0, this.game.Data.RegimeObj[this.detailnr].id, 12)));
                  if (id > 0)
                  {
                    int locationById = this.game.HandyFunctionsObj.GetLocationByID(id);
                    if (locationById > -1)
                    {
                      num5 = this.game.Data.LocObj[locationById].X;
                      num6 = this.game.Data.LocObj[locationById].Y;
                    }
                  }
                  SimpleList simpleList = new SimpleList();
                  int mapWidth = this.game.Data.MapObj[0].MapWidth;
                  for (int tdata1 = 0; tdata1 <= mapWidth; ++tdata1)
                  {
                    int mapHeight = this.game.Data.MapObj[0].MapHeight;
                    for (int tdata2 = 0; tdata2 <= mapHeight; ++tdata2)
                    {
                      if (this.game.EditObj.TempValue4[0].Value[tdata1, tdata2] == this.game.Data.RegimeObj[this.detailnr].id && this.game.Data.MapObj[0].HexObj[tdata1, tdata2].MaxRecon > 0 | !this.game.Data.ShrowdOn)
                      {
                        int tweight = !(tdata1 == num5 & tdata2 == num6) ? (this.game.Data.MapObj[0].HexObj[tdata1, tdata2].Location <= -1 ? (this.game.Data.MapObj[0].HexObj[tdata1, tdata2].UnitCounter <= -1 ? 1 : 5) : 10) : 100;
                        simpleList.Add(tdata2 * this.game.Data.MapObj[0].MapWidth + tdata1, tweight, tdata1, tdata2);
                      }
                    }
                  }
                  simpleList.ReverseSortHighSpeed();
                  if (simpleList.Counter > -1)
                  {
                    flag2 = true;
                    num3 = simpleList.Data1[0];
                    num4 = simpleList.Data2[0];
                    this.game.EditObj.SetViewModeExtraNr = 2;
                  }
                }
              }
              if (flag2 & num3 > -1 & num4 > -1)
              {
                this.game.SelectX = num3;
                this.game.SelectY = num4;
                this.game.EditObj.UnitSelected = -1;
                if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > -1)
                  this.game.EditObj.UnitSelected = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0];
                this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
                int num7 = this.game.EditObj.ShowHQ ? 1 : 0;
                windowReturnClass.AddCommand(4, 69);
                windowReturnClass.AddCommand(4, 68);
                flag1 = true;
              }
              if (flag1)
              {
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else
            {
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
          else if (num1 == this.Info1Id)
          {
            this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1], 3);
            Coordinate hexCoord = ((MiniMapPartClass) this.SubPartList[index1]).GetHexCoord(x - this.SubPartX[index1], y - this.SubPartY[index1]);
            if (this.subtab == 2 && hexCoord.onmap)
            {
              int selectX = this.game.SelectX;
              int selectY = this.game.SelectY;
              this.game.SelectX = hexCoord.x;
              this.game.SelectY = hexCoord.y;
              this.game.HandyFunctionsObj.SetcornerXY2();
              this.game.SelectX = selectX;
              this.game.SelectY = selectY;
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 69);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 9);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (this.game.EditObj.CurrentMiniX > -1 & this.game.EditObj.CurrentMiniY > -1 & this.game.EditObj.MapSelected > -1 && this.game.EditObj.CurrentMiniX <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth & this.game.EditObj.CurrentMiniY <= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.CurrentMiniX, this.game.EditObj.CurrentMiniY].Regime > -1 && !this.game.Data.RegimeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.CurrentMiniX, this.game.EditObj.CurrentMiniY].Regime].Sleep)
            {
              this.detailnr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.CurrentMiniX, this.game.EditObj.CurrentMiniY].Regime;
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.CurrentMiniX, this.game.EditObj.CurrentMiniY].get_SeeNow(this.game.Data.Turn) < 1)
                this.detailnr = -1;
            }
            bool flag3 = false;
            if (hexCoord.onmap)
            {
              if (this.subtab == 0 & this.game.EditObj.TempValue4[0].Value[hexCoord.x, hexCoord.y] > 0)
              {
                int regimeById = this.game.HandyFunctionsObj.GetRegimeByID(this.game.EditObj.TempValue4[0].Value[hexCoord.x, hexCoord.y]);
                if (regimeById > -1)
                {
                  this.detailnr = regimeById;
                  this.prepareTempValue4();
                  flag3 = true;
                }
              }
              else if (this.subtab == 0 & this.game.EditObj.TempValue4[0].Value[hexCoord.x, hexCoord.y] < 1)
              {
                this.regnr = -1;
                this.detailnr = this.regnr;
                this.prepareTempValue4();
                flag3 = true;
              }
              else if (this.subtab == 1)
              {
                this.detailnr = this.game.EditObj.TempValue4[0].Value[hexCoord.x, hexCoord.y];
                this.prepareTempValue4();
                flag3 = true;
              }
            }
            int num8 = -1;
            int num9 = -1;
            bool flag4 = false;
            if (flag3)
            {
              if (this.game.Data.MapObj[0].HexObj[hexCoord.x, hexCoord.y].MaxRecon > 0 | !this.game.Data.ShrowdOn)
              {
                if (this.subtab == 1)
                {
                  flag4 = true;
                  num8 = hexCoord.x;
                  num9 = hexCoord.y;
                  this.game.EditObj.SetViewModeExtraNr = 1;
                }
                else if (this.subtab == 0)
                {
                  flag4 = true;
                  num8 = hexCoord.x;
                  num9 = hexCoord.y;
                  this.game.EditObj.SetViewModeExtraNr = 2;
                }
              }
              else
              {
                int num10;
                int num11;
                if (this.subtab == 1)
                {
                  int stringListById = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
                  num10 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, this.detailnr, 10)));
                  num11 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, this.detailnr, 11)));
                  SimpleList simpleList = new SimpleList();
                  int mapWidth = this.game.Data.MapObj[0].MapWidth;
                  for (int index2 = 0; index2 <= mapWidth; ++index2)
                  {
                    int mapHeight = this.game.Data.MapObj[0].MapHeight;
                    for (int index3 = 0; index3 <= mapHeight; ++index3)
                    {
                      if (this.game.EditObj.TempValue4[0].Value[index2, index3] == this.detailnr && this.game.Data.MapObj[0].HexObj[index2, index3].MaxRecon > 0 | !this.game.Data.ShrowdOn)
                      {
                        int tweight = this.game.HandyFunctionsObj.Distance(hexCoord.x, hexCoord.y, 0, index2, index3, 0, 19);
                        simpleList.Add(index3 * this.game.Data.MapObj[0].MapWidth + index2, tweight, index2, index3);
                      }
                    }
                  }
                  simpleList.SortHighSpeed();
                  if (simpleList.Counter > -1)
                  {
                    flag4 = true;
                    num8 = simpleList.Data1[0];
                    num9 = simpleList.Data2[0];
                    this.game.EditObj.SetViewModeExtraNr = 1;
                  }
                }
                if (this.subtab == 0 & this.detailnr > -1)
                {
                  int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 143, 0, 0))].GetData(0, this.game.Data.RegimeObj[this.detailnr].id, 12)));
                  if (id > 0)
                  {
                    int locationById = this.game.HandyFunctionsObj.GetLocationByID(id);
                    if (locationById > -1)
                    {
                      num10 = this.game.Data.LocObj[locationById].X;
                      num11 = this.game.Data.LocObj[locationById].Y;
                    }
                  }
                  SimpleList simpleList = new SimpleList();
                  int mapWidth = this.game.Data.MapObj[0].MapWidth;
                  for (int index4 = 0; index4 <= mapWidth; ++index4)
                  {
                    int mapHeight = this.game.Data.MapObj[0].MapHeight;
                    for (int index5 = 0; index5 <= mapHeight; ++index5)
                    {
                      if (this.game.EditObj.TempValue4[0].Value[index4, index5] == this.game.Data.RegimeObj[this.detailnr].id && this.game.Data.MapObj[0].HexObj[index4, index5].MaxRecon > 0 | !this.game.Data.ShrowdOn)
                      {
                        int tweight = this.game.HandyFunctionsObj.Distance(hexCoord.x, hexCoord.y, 0, index4, index5, 0, 19);
                        simpleList.Add(index5 * this.game.Data.MapObj[0].MapWidth + index4, tweight, index4, index5);
                      }
                    }
                  }
                  simpleList.SortHighSpeed();
                  if (simpleList.Counter > -1)
                  {
                    flag4 = true;
                    num8 = simpleList.Data1[0];
                    num9 = simpleList.Data2[0];
                    this.game.EditObj.SetViewModeExtraNr = 2;
                  }
                }
              }
            }
            if (flag4 & num8 > -1 & num9 > -1)
            {
              this.game.SelectX = num8;
              this.game.SelectY = num9;
              this.game.EditObj.UnitSelected = -1;
              if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > -1)
                this.game.EditObj.UnitSelected = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitList[0];
              this.game.EditObj.OldUnit = this.game.EditObj.UnitSelected;
              int num12 = this.game.EditObj.ShowHQ | flag3 ? 1 : 0;
              windowReturnClass.AddCommand(4, 69);
              windowReturnClass.AddCommand(4, 68);
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            windowReturnClass.AddCommand(4, 12);
            windowReturnClass.AddCommand(4, 68);
            windowReturnClass.AddCommand(4, 67);
            windowReturnClass.AddCommand(4, 9);
            int num13 = this.game.EditObj.ShowHQ ? 1 : 0;
            this.dostuff();
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

    public void prepareTempValue4()
    {
      this.regimesToBeShown = new int[this.game.Data.RegimeCounter + 1];
      this.game.HandyFunctionsObj.RedimTempValue4(-1);
      this.game.HandyFunctionsObj.RedimTempValue3(-1);
      this.game.EditObj.TempAI = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.game.EditObj.TempAI2 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      DataClass data = DrawMod.TGame.Data;
      string str = "Zones";
      ref string local = ref str;
      int libVar = data.FindLibVar(ref local, "SE_Data");
      this.zonesToBeShown = new int[this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0))].GetHighestValue(0) + 1 + 1];
      AIMatrix specialMask = new AIMatrix(ref this.game.DC2AIObj, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight, 0, 0);
      bool[] flagArray = new bool[this.game.Data.RegimeCounter + 1];
      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (index1 == 61 & index2 == 14)
            index1 = index1;
          if (this.game.Data.MapObj[0].HexObj[index1, index2].Regime > -1)
            flagArray[this.game.Data.MapObj[0].HexObj[index1, index2].Regime] = true;
          if (this.subtab == 0)
          {
            int regime = this.game.Data.MapObj[0].HexObj[index1, index2].Regime;
            if (regime > -1)
              this.game.EditObj.TempValue4[0].Value[index1, index2] = this.game.Data.RegimeObj[regime].id;
          }
          else if (this.subtab == 1)
          {
            int hexLibVarValue = DrawMod.TGame.Data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar);
            if (hexLibVarValue > 0 & (this.game.Data.MapObj[0].HexObj[index1, index2].MaxRecon > 0 | !this.game.Data.ShrowdOn))
            {
              this.game.EditObj.TempValue4[0].Value[index1, index2] = hexLibVarValue;
              this.zonesToBeShown[hexLibVarValue] = -1;
            }
            specialMask.Value[index1, index2] = 0;
            if ((this.game.Data.MapObj[0].HexObj[index1, index2].MaxRecon > 0 | !this.game.Data.ShrowdOn) & this.game.Data.MapObj[0].HexObj[index1, index2].Regime > -1)
              specialMask.Value[index1, index2] = this.game.Data.MapObj[0].HexObj[index1, index2].Regime + 2;
            else if (this.game.Data.MapObj[0].HexObj[index1, index2].get_LastReg(this.game.Data.Turn) > 0)
              specialMask.Value[index1, index2] = this.game.Data.MapObj[0].HexObj[index1, index2].get_LastReg(this.game.Data.Turn) + 2;
            else if (this.game.Data.MapObj[0].HexObj[index1, index2].get_LastReg(this.game.Data.Turn) == -1 & this.game.Data.MapObj[0].HexObj[index1, index2].get_LastLT(this.game.Data.Turn) > -1)
              specialMask.Value[index1, index2] = 0;
          }
        }
      }
      AIMatrix aiMatrix1 = new AIMatrix(ref this.game.DC2AIObj, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight, 0, 0);
      AIMatrix aiMatrix2 = new AIMatrix(ref this.game.DC2AIObj, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight, 0, 0);
      AIMatrix aiMatrix3 = new AIMatrix(ref this.game.DC2AIObj, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight, 0, 0);
      AIMatrix aiMatrix4 = new AIMatrix(ref this.game.DC2AIObj, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight, 0, 0);
      int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
      for (int index3 = 0; index3 <= mapWidth2; ++index3)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index4 = 0; index4 <= mapHeight; ++index4)
        {
          this.game.EditObj.TempAI[index3, index4] = 0;
          aiMatrix4.Value[index3, index4] = this.game.Data.MapObj[0].HexObj[index3, index4].get_LastLT(this.game.Data.Turn);
          if (aiMatrix4.Value[index3, index4] < 0)
            aiMatrix4.Value[index3, index4] = 0;
          if (index3 == 38 & index4 == 21)
            index3 = index3;
          if (this.game.Data.MapObj[0].HexObj[index3, index4].MaxRecon > 0 | !this.game.Data.ShrowdOn)
          {
            aiMatrix1.Value[index3, index4] = (int) byte.MaxValue;
            aiMatrix2.Value[index3, index4] = this.game.EditObj.TempValue4[0].Value[index3, index4];
            if (aiMatrix2.Value[index3, index4] <= 0)
              aiMatrix2.Value[index3, index4] = 999999;
            aiMatrix3.Value[index3, index4] = this.game.Data.MapObj[0].HexObj[index3, index4].Regime + 2;
            aiMatrix4.Value[index3, index4] = this.game.Data.MapObj[0].HexObj[index3, index4].LandscapeType + 1;
            if (this.game.Data.MapObj[0].HexObj[index3, index4].Regime > -1)
              this.regimesToBeShown[this.game.Data.MapObj[0].HexObj[index3, index4].Regime] = -1;
          }
          else if (this.game.Data.MapObj[0].HexObj[index3, index4].get_LastReg(this.game.Data.Turn) > 0)
          {
            if (flagArray[this.game.Data.MapObj[0].HexObj[index3, index4].get_LastReg(this.game.Data.Turn)])
              aiMatrix3.Value[index3, index4] = this.game.Data.MapObj[0].HexObj[index3, index4].get_LastReg(this.game.Data.Turn) + 2;
            aiMatrix4.Value[index3, index4] = this.game.Data.MapObj[0].HexObj[index3, index4].get_LastLT(this.game.Data.Turn) + 1;
            aiMatrix1.Value[index3, index4] = (int) byte.MaxValue;
            aiMatrix2.Value[index3, index4] = this.game.EditObj.TempValue4[0].Value[index3, index4];
            if (aiMatrix2.Value[index3, index4] <= 0 & this.subtab == 0)
              aiMatrix2.Value[index3, index4] = 999999;
            if (this.game.Data.MapObj[0].HexObj[index3, index4].get_LastReg(this.game.Data.Turn) > -1 && this.game.Data.MapObj[0].HexObj[index3, index4].get_LastReg(this.game.Data.Turn) <= this.game.Data.RegimeCounter && flagArray[this.game.Data.MapObj[0].HexObj[index3, index4].get_LastReg(this.game.Data.Turn)])
              this.regimesToBeShown[this.game.Data.MapObj[0].HexObj[index3, index4].get_LastReg(this.game.Data.Turn)] = -1;
          }
        }
      }
      if (this.subtab == 1)
        specialMask.ExpandAllNonZeroValuesForAnyRegime(15);
      aiMatrix1.ExpandAndRemovePercentageForAnyRegime((int) byte.MaxValue, 0.7f, true);
      if (this.subtab == 1)
        aiMatrix2.ExpandAllNonZeroValuesForAnyRegime(15, specialMask);
      else
        aiMatrix2.ExpandAllNonZeroValuesForAnyRegime(15);
      aiMatrix3.ExpandAllNonZeroValuesForAnyRegime(15);
      aiMatrix4.ExpandAllNonZeroValuesForAnyRegime(15);
      int[] numArray1 = new int[this.game.Data.RegimeCounter + 2 + 1];
      int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
      for (int index5 = 0; index5 <= mapWidth3; ++index5)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index6 = 0; index6 <= mapHeight; ++index6)
        {
          if (this.game.Data.MapObj[0].HexObj[index5, index6].Regime > -1)
          {
            int[] numArray2 = numArray1;
            int[] numArray3 = numArray2;
            int regime = this.game.Data.MapObj[0].HexObj[index5, index6].Regime;
            int index7 = regime;
            int num = numArray2[regime] + 1;
            numArray3[index7] = num;
          }
          if (this.game.Data.MapObj[0].HexObj[index5, index6].MaxRecon > 0 | !this.game.Data.ShrowdOn)
          {
            aiMatrix1.Value[index5, index6] = (int) byte.MaxValue;
            aiMatrix2.Value[index5, index6] = this.game.EditObj.TempValue4[0].Value[index5, index6];
            aiMatrix3.Value[index5, index6] = this.game.Data.MapObj[0].HexObj[index5, index6].Regime + 2;
            aiMatrix4.Value[index5, index6] = this.game.Data.MapObj[0].HexObj[index5, index6].LandscapeType + 1;
          }
          else if (this.game.Data.MapObj[0].HexObj[index5, index6].get_LastReg(this.game.Data.Turn) > 0)
          {
            aiMatrix1.Value[index5, index6] = (int) byte.MaxValue;
            if (this.subtab == 0)
              aiMatrix2.Value[index5, index6] = this.game.EditObj.TempValue4[0].Value[index5, index6];
            aiMatrix3.Value[index5, index6] = this.game.Data.MapObj[0].HexObj[index5, index6].get_LastReg(this.game.Data.Turn) + 2;
            aiMatrix4.Value[index5, index6] = this.game.Data.MapObj[0].HexObj[index5, index6].get_LastLT(this.game.Data.Turn) + 1;
          }
          else if (aiMatrix1.Value[index5, index6] < 20)
          {
            aiMatrix1.Value[index5, index6] = 0;
            aiMatrix2.Value[index5, index6] = 0;
            aiMatrix3.Value[index5, index6] = 0;
            aiMatrix4.Value[index5, index6] = 0;
          }
          if (index5 == 47 & index6 == 20)
            index5 = index5;
          if (aiMatrix2.Value[index5, index6] == 999999)
            aiMatrix2.Value[index5, index6] = 0;
          if (this.subtab == 0)
          {
            this.game.EditObj.TempValue4[0].Value[index5, index6] = 0;
            if (aiMatrix3.Value[index5, index6] > 1)
              this.game.EditObj.TempValue4[0].Value[index5, index6] = this.game.Data.RegimeObj[aiMatrix3.Value[index5, index6] - 2].id;
          }
          else
            this.game.EditObj.TempValue4[0].Value[index5, index6] = aiMatrix2.Value[index5, index6];
          this.game.EditObj.TempValue3[0].Value[index5, index6] = aiMatrix1.Value[index5, index6];
          this.game.EditObj.TempAI[index5, index6] = aiMatrix3.Value[index5, index6] - 2;
          this.game.EditObj.TempAI2[index5, index6] = aiMatrix4.Value[index5, index6] - 1;
        }
      }
      int regimeCounter = this.game.Data.RegimeCounter;
      for (int index = 0; index <= regimeCounter; ++index)
      {
        if (numArray1[index] < 1)
          this.regimesToBeShown[index] = 0;
      }
    }
  }
}
