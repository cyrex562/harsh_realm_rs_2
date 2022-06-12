// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleEditUnitWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class SimpleEditUnitWindowClass : WindowClass
  {
    private int listId;
    private ListClass listObj;
    private int loadMapId;
    private int loadMapIdB;
    private int importId;
    private int textId;
    private int detailnr;
    private int currentStep;
    private int standing1;
    private int standing2;
    private ListClass VPListOBj;
    private int VPListId;
    private int AddUnitModel;
    private int AddUnit;
    private int AddUnitModelB;
    private int cancelid;
    private int AddUnitB;
    private int ChangeCounterUnit;
    private int ChangeCounterUnitB;
    private int RemoveUnit;
    private int MoveUnit;
    private int MoveUnitB;
    private int HqUnit;
    private int HqUnitB;
    private int RemoveUnitB;
    private int AddVPIdb;
    private int SetCommander;
    private int SetCommanderB;
    private int changeColor;
    private int changeColorB;

    public SimpleEditUnitWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, 300, 9, tDoBorders: 1, tHeaderString: "Units")
    {
      this.detailnr = -1;
      this.game.EditObj.TempHisModelUnit = -1;
      this.game.EditObj.TempHisUnit = -1;
      this.game.EditObj.TempRandom = -1;
      this.DoStuff();
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      if (nr == 77 & this.game.EditObj.UnitSelected > -1 & this.SubpartNr(this.MoveUnit) > 0)
      {
        WindowReturnClass windowReturnClass2 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.MoveUnit)] + 1, this.SubPartY[this.SubpartNr(this.MoveUnit)] + 1, 1);
        windowReturnClass2.SetFlag(true);
        return windowReturnClass2;
      }
      if (nr == 72 & this.game.EditObj.UnitSelected > -1 & this.SubpartNr(this.HqUnit) > 0)
      {
        WindowReturnClass windowReturnClass3 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.HqUnit)] + 1, this.SubPartY[this.SubpartNr(this.HqUnit)] + 1, 1);
        windowReturnClass3.SetFlag(true);
        return windowReturnClass3;
      }
      if (!((nr == 13 | nr == 32) & this.game.EditObj.UnitSelected > -1 & this.SubpartNr(this.cancelid) > 0))
        return windowReturnClass1;
      WindowReturnClass windowReturnClass4 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.cancelid)] + 1, this.SubPartY[this.SubpartNr(this.cancelid)] + 1, 1);
      windowReturnClass4.SetFlag(true);
      return windowReturnClass4;
    }

    public override void DoRefresh()
    {
      if (this.game.EditObj.TempHisModelUnit > -1)
      {
        this.game.ProcessingObj.AddNewUnitBasedOnHistorical(this.game.SelectX, this.game.SelectY, 0, this.game.Data.HistoricalUnitObj[this.game.EditObj.TempHisModelUnit].TempRegime, this.game.EditObj.TempHisModelUnit, freePPnoUnit: true, populateUnit: true);
        this.game.EditObj.UnitSelected = this.game.Data.UnitCounter;
        this.game.EditObj.TempHisModelUnit = -1;
      }
      if (this.game.EditObj.TempHisUnit > -1)
      {
        int tempRegime = this.game.Data.HistoricalUnitObj[this.game.EditObj.TempHisUnit].TempRegime;
        this.game.EventRelatedObj.ExecAddHistoricalUnit(this.game.SelectX, this.game.SelectY, this.game.Data.HistoricalUnitObj[this.game.EditObj.TempHisUnit].ID, 0, "");
        this.game.EditObj.UnitSelected = this.game.Data.UnitCounter;
        this.game.EditObj.TempHisUnit = -1;
      }
      if (this.game.EditObj.TempRandom > -1)
      {
        if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName.Length > 0)
        {
          LibIdClass libIdClass1 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].OffLibId.Clone();
          LibIdClass libIdClass2 = this.game.Data.HistoricalUnitObj[this.game.EditObj.TempRandom].LibId.Clone();
          this.game.ProcessingObj.SwapOfficer(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical, this.game.EditObj.TempRandom, this.game.EditObj.UnitSelected);
          this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].OffLibId = libIdClass2;
          this.game.Data.HistoricalUnitObj[this.game.EditObj.TempRandom].LibId = libIdClass1.Clone();
          this.game.Data.HistoricalUnitObj[this.game.EditObj.TempRandom].OffLibId = new LibIdClass();
          this.game.Data.HistoricalUnitObj[this.game.EditObj.TempRandom].Pool = true;
        }
        else
        {
          LibIdClass libIdClass = this.game.Data.HistoricalUnitObj[this.game.EditObj.TempRandom].LibId.Clone();
          this.game.ProcessingObj.SwapOfficer(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical, this.game.EditObj.TempRandom, this.game.EditObj.UnitSelected);
          this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].OffLibId = libIdClass;
        }
        this.game.EditObj.TempRandom = -1;
      }
      else if (this.game.EditObj.TempRandom == -2 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName.Length > 0)
      {
        LibIdClass libIdClass = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].OffLibId.Clone();
        this.game.Data.AddHistoricalUnit();
        this.game.ProcessingObj.SwapOfficer(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical, this.game.Data.HistoricalUnitCounter, this.game.EditObj.UnitSelected);
        this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].OffLibId = new LibIdClass();
        this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].LibId = libIdClass.Clone();
        this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].Pool = true;
        this.game.EditObj.TempRandom = -1;
      }
      this.DoStuff();
    }

    public void DoStuff()
    {
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      graphics.TextContrast = 1;
      this.ClearMouse();
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 350, -1);
      DrawMod.DrawBlock(ref graphics, 2, 294, DrawMod.TGame.ScreenWidth - 4, 4, 0, 0, 0, 128);
      if (this.VPListId > 0)
      {
        this.RemoveSubPart(this.VPListId);
        this.VPListId = 0;
      }
      if (this.AddUnitModel > 0)
      {
        this.RemoveSubPart(this.AddUnitModel);
        this.AddUnitModel = 0;
      }
      if (this.AddUnit > 0)
      {
        this.RemoveSubPart(this.AddUnit);
        this.AddUnit = 0;
      }
      if (this.RemoveUnit > 0)
      {
        this.RemoveSubPart(this.RemoveUnit);
        this.RemoveUnit = 0;
      }
      if (this.RemoveUnitB > 0)
      {
        this.RemoveSubPart(this.RemoveUnitB);
        this.RemoveUnitB = 0;
      }
      if (this.ChangeCounterUnit > 0)
      {
        this.RemoveSubPart(this.ChangeCounterUnit);
        this.ChangeCounterUnit = 0;
      }
      if (this.ChangeCounterUnitB > 0)
      {
        this.RemoveSubPart(this.ChangeCounterUnitB);
        this.ChangeCounterUnitB = 0;
      }
      if (this.AddUnitModelB > 0)
      {
        this.RemoveSubPart(this.AddUnitModelB);
        this.AddUnitModelB = 0;
      }
      if (this.AddUnitB > 0)
      {
        this.RemoveSubPart(this.AddUnitB);
        this.AddUnitB = 0;
      }
      if (this.AddVPIdb > 0)
      {
        this.RemoveSubPart(this.AddVPIdb);
        this.AddVPIdb = 0;
      }
      if (this.SetCommander > 0)
      {
        this.RemoveSubPart(this.SetCommander);
        this.SetCommander = 0;
      }
      if (this.SetCommanderB > 0)
      {
        this.RemoveSubPart(this.SetCommanderB);
        this.SetCommanderB = 0;
      }
      if (this.MoveUnit > 0)
      {
        this.RemoveSubPart(this.MoveUnit);
        this.MoveUnit = 0;
      }
      if (this.HqUnit > 0)
      {
        this.RemoveSubPart(this.HqUnit);
        this.HqUnit = 0;
      }
      if (this.HqUnitB > 0)
      {
        this.RemoveSubPart(this.HqUnitB);
        this.HqUnitB = 0;
      }
      if (this.MoveUnitB > 0)
      {
        this.RemoveSubPart(this.MoveUnitB);
        this.MoveUnitB = 0;
      }
      if (this.HqUnitB > 0)
      {
        this.RemoveSubPart(this.HqUnitB);
        this.HqUnitB = 0;
      }
      if (this.importId > 0)
      {
        this.RemoveSubPart(this.importId);
        this.importId = 0;
      }
      if (this.cancelid > 0)
      {
        this.RemoveSubPart(this.cancelid);
        this.cancelid = 0;
      }
      if (this.changeColor > 0)
      {
        this.RemoveSubPart(this.changeColor);
        this.changeColor = 0;
      }
      if (this.changeColorB > 0)
      {
        this.RemoveSubPart(this.changeColorB);
        this.changeColorB = 0;
      }
      if (this.standing1 > 0)
      {
        this.RemoveSubPart(this.standing1);
        this.standing1 = 0;
      }
      if (this.standing2 > 0)
      {
        this.RemoveSubPart(this.standing2);
        this.standing2 = 0;
      }
      this.VPListOBj = new ListClass();
      int num2 = num1 + 250;
      int y = 55;
      string tDescript;
      SubPartClass tsubpart1;
      if (this.game.SelectX > -1 & this.game.SelectY > -1)
      {
        int num3 = -1;
        int num4 = -1;
        int unitCounter = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter;
        for (int index = 0; index <= unitCounter; ++index)
        {
          int unit = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitList[index];
          ++num4;
          this.VPListOBj.add(index.ToString() + "," + this.game.Data.UnitObj[unit].Name, unit);
          if (this.game.EditObj.UnitSelected == unit)
            num3 = num4;
        }
        if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter == -1)
          this.VPListOBj.add("no units on hex", -1);
        ListClass vpListObj = this.VPListOBj;
        int tlistselect = num3;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        int bbx = 10 + num1;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(vpListObj, 10, 200, tlistselect, game, true, "Units in Hex", false, tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: bbx, bby: 52, tMarcStyle: true, overruleFont: (ref local2));
        this.VPListId = this.AddSubPart(ref tsubpart2, 10 + num1, 52, 200, 176, 0);
        bool flag = true;
        if (this.game.EditObj.UnitSelected > -1 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName.Length > 0)
          flag = false;
        if (flag)
        {
          DrawMod.DrawTextColouredMarc(ref graphics, "Selected hex:", this.game.MarcFont4, num2 + 400, y + 50, Color.White);
          DrawMod.DrawTextColouredMarc(ref graphics, this.game.SelectX.ToString() + "," + this.game.SelectY.ToString() + "," + this.game.HandyFunctionsObj.GetHexName(this.game.SelectX, this.game.SelectY, 0), this.game.MarcFont3, num2 + 400, y + 70, Color.White);
        }
        if (this.game.EditObj.UnitSelected > -1)
        {
          DrawMod.DrawTextColouredMarc(ref graphics, "Selected unit:", this.game.MarcFont4, num2, y, Color.White);
          int historical = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical;
          string ttext = "Unit slot: " + this.game.EditObj.UnitSelected.ToString() + "\r\n";
          if (historical > -1)
            ttext = ttext + "Historical slot: " + historical.ToString() + "\r\n" + "Historical ID: " + this.game.Data.HistoricalUnitObj[historical].ID.ToString() + "\r\n";
          Rectangle trect = new Rectangle(num2, y, 200, 20);
          this.AddMouse(ref trect, "Selected unit", ttext);
          DrawMod.DrawTextColouredMarc(ref graphics, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Name, this.game.MarcFont3, num2, y + 20, Color.White);
          DrawMod.DrawTextColouredMarc(ref graphics, "Units model:", this.game.MarcFont4, num2, y + 50, Color.White);
          string tstring1;
          if (historical > -1)
          {
            int modelMaster = this.game.Data.HistoricalUnitObj[historical].ModelMaster;
            if (modelMaster > -1)
            {
              int num5 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HistoricalSubPart + 1;
              tstring1 = this.game.Data.HistoricalUnitObj[modelMaster].Name;
              if (!this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
              {
                tstring1 = tstring1 + " (sub-part " + num5.ToString() + ")";
              }
              else
              {
                if (this.game.Data.HistoricalUnitObj[modelMaster].Type == 5)
                  tstring1 += " (lowest level HQ)";
                if (this.game.Data.HistoricalUnitObj[modelMaster].Type == 6)
                  tstring1 += " (medium level HQ)";
                if (this.game.Data.HistoricalUnitObj[modelMaster].Type == 7)
                  tstring1 += " (high level HQ)";
                if (this.game.Data.HistoricalUnitObj[modelMaster].Type == 8)
                  tstring1 += " (supreme level HQ)";
              }
            }
            else
              tstring1 = "Warning! unit not set to a model";
          }
          else
            tstring1 = "Warning! unit is not a historical unit";
          DrawMod.DrawTextColouredMarc(ref graphics, tstring1, this.game.MarcFont3, num2, y + 70, Color.White);
          DrawMod.DrawTextColouredMarc(ref graphics, "is HQ:", this.game.MarcFont4, num2 + 400, y, Color.White);
          string tstring2 = "Yes";
          if (!this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
            tstring2 = "No";
          DrawMod.DrawTextColouredMarc(ref graphics, tstring2, this.game.MarcFont3, num2 + 400, y + 20, Color.White);
          DrawMod.DrawTextColouredMarc(ref graphics, "Assigned to HQ:", this.game.MarcFont4, num2 + 500, y, Color.White);
          string tstring3 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ != -1 ? this.game.Data.UnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ].Name : "None";
          DrawMod.DrawTextColouredMarc(ref graphics, tstring3, this.game.MarcFont3, num2 + 500, y + 20, Color.White);
          if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName.Length > 0)
          {
            DrawMod.DrawTextColouredMarc(ref graphics, "Commander:", this.game.MarcFont4, num2 + 400, y + 50, Color.White);
            string tstring4 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName;
            int people = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].People;
            if (people > -1)
              tstring4 = tstring4 + " (" + this.game.Data.PeopleObj[people].Name + ")";
            DrawMod.DrawTextColouredMarc(ref graphics, tstring4, this.game.MarcFont3, num2 + 400, y + 70, Color.White);
          }
        }
        else
        {
          DrawMod.DrawTextColouredMarc(ref graphics, "Selected unit:", this.game.MarcFont4, num2, y, Color.White);
          DrawMod.DrawTextColouredMarc(ref graphics, "none", this.game.MarcFont3, num2, y + 20, Color.White);
        }
        if (this.game.EditObj.OrderType >= 1)
        {
          DrawMod.DrawTextColouredMarc(ref graphics, "Currently executing an order.", this.game.MarcFont4, num2 + 400, y + 50, Color.White);
          tDescript = "Cancel order";
          tsubpart1 = (SubPartClass) new TextButtonPartClass("Cancel order", 250, tDescript, ref this.OwnBitmap, num2 + 400, y + 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.cancelid = this.AddSubPart(ref tsubpart1, num2 + 400, y + 100, 250, 35, 1);
        }
        else if (this.game.EditObj.UnitSelected > -1)
        {
          if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
          {
            SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Set Commander", 250, "Change commander", ref this.OwnBitmap, num2 + 400, y + 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.SetCommander = this.AddSubPart(ref tsubpart3, num2 + 400, y + 100, 250, 35, 1);
            SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Change color", 155, "Click to change color of HQ.", ref this.OwnBitmap, num2 + 190, y + 180, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.changeColor = this.AddSubPart(ref tsubpart4, num2 + 190, y + 180, 155, 35, 1);
          }
          else
          {
            SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("Set Commander", 250, "You can only set commander for a HQ", ref this.OwnBitmap, num2 + 400, y + 100, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.SetCommanderB = this.AddSubPart(ref tsubpart5, num2 + 400, y + 100, 250, 35, 0);
            SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("Change color", 155, "You can only change color of HQ.", ref this.OwnBitmap, num2 + 190, y + 180, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.changeColorB = this.AddSubPart(ref tsubpart6, num2 + 190, y + 180, 155, 35, 0);
          }
          SubPartClass tsubpart7 = (SubPartClass) new TextButtonPartClass("Move Unit [M]", 250, tBackbitmap: (ref this.OwnBitmap), bbx: (num2 + 400), bby: (y + 140), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.MoveUnit = this.AddSubPart(ref tsubpart7, num2 + 400, y + 140, 250, 35, 1);
          SubPartClass tsubpart8 = (SubPartClass) new TextButtonPartClass("Set HQ [H]", 250, tBackbitmap: (ref this.OwnBitmap), bbx: (num2 + 400), bby: (y + 180), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.HqUnit = this.AddSubPart(ref tsubpart8, num2 + 400, y + 180, 250, 35, 1);
          tsubpart1 = (SubPartClass) new TextButtonPartClass("Remove unit", 155, "Click to remove this unit.", ref this.OwnBitmap, num2, y + 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.RemoveUnit = this.AddSubPart(ref tsubpart1, num2, y + 100, 155, 35, 1);
          tsubpart1 = (SubPartClass) new TextButtonPartClass("Change counter", 155, "Click to change the Number and the Shortname of the selected unit.", ref this.OwnBitmap, num2 + 190, y + 140, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.ChangeCounterUnit = this.AddSubPart(ref tsubpart1, num2 + 190, y + 140, 155, 35, 1);
          tDescript = "Change Standing Order: Retreat Percentage. Will change setting for current unit and all subordinates. 100% is fight till the end. 25% retreat asap. ";
          tsubpart1 = (SubPartClass) new TextButtonPartClass("Rtr:" + (100 - this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SODefendPercent).ToString(), 90, tDescript, ref this.OwnBitmap, num2 - 240, y + 180, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.standing1 = this.AddSubPart(ref tsubpart1, num2 - 240, y + 180, 90, 35, 1);
          if (this.game.HandyFunctionsObj.HasUnitAirSF(this.game.EditObj.UnitSelected))
          {
            tDescript = "Change Standing Order: Intercept Percentage. Will change setting for current unit and all subordinates. % specifies the minimum readiness needed to allow intercept missions. ";
            string str = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop.ToString();
            if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop == 100)
              str = "Nev.";
            tsubpart1 = (SubPartClass) new TextButtonPartClass("Intc:" + str, 90, tDescript, ref this.OwnBitmap, num2 - 140, y + 180, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.standing2 = this.AddSubPart(ref tsubpart1, num2 - 140, y + 180, 90, 35, 1);
          }
        }
        else
        {
          SubPartClass tsubpart9 = (SubPartClass) new TextButtonPartClass("Remove unit", 155, "No unit selected", ref this.OwnBitmap, num2, y + 100, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.RemoveUnitB = this.AddSubPart(ref tsubpart9, num2, y + 100, 155, 35, 0);
          SubPartClass tsubpart10 = (SubPartClass) new TextButtonPartClass("Move Unit", 250, "No unit selected", ref this.OwnBitmap, num2 + 400, y + 140, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.MoveUnitB = this.AddSubPart(ref tsubpart10, num2 + 400, y + 140, 250, 35, 0);
          tsubpart1 = (SubPartClass) new TextButtonPartClass("Set HQ", 250, "No unit selected", ref this.OwnBitmap, num2 + 400, y + 180, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.HqUnitB = this.AddSubPart(ref tsubpart1, num2 + 400, y + 180, 250, 35, 0);
          tsubpart1 = (SubPartClass) new TextButtonPartClass("Change counter", 155, "No unit selected", ref this.OwnBitmap, num2 + 190, y + 140, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.ChangeCounterUnitB = this.AddSubPart(ref tsubpart1, num2 + 190, y + 140, 155, 35, 0);
          tsubpart1 = (SubPartClass) new TextButtonPartClass("Change color", 155, "No unit selected", ref this.OwnBitmap, num2 + 190, y + 180, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.changeColorB = this.AddSubPart(ref tsubpart1, num2 + 190, y + 180, 155, 35, 0);
        }
      }
      else
      {
        DrawMod.DrawTextColouredMarc(ref graphics, "Selected hex:", this.game.MarcFont4, num2, y, Color.White);
        DrawMod.DrawTextColouredMarc(ref graphics, "None", this.game.MarcFont3, num2, y + 20, Color.White);
      }
      if (this.game.EditObj.OrderType <= 0)
      {
        if (!this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType].IsSea & this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1)
        {
          tsubpart1 = (SubPartClass) new TextButtonPartClass("Add unit model", 155, "Click to add a unit to this hex, based on a historical unit model, but a fresh non-yet existing instance of it.", ref this.OwnBitmap, num2, y + 140, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.AddUnitModel = this.AddSubPart(ref tsubpart1, num2, y + 140, 155, 35, 1);
          tDescript = "Click to add a pre-defined historical unit, not yet on map, on the map";
          tsubpart1 = (SubPartClass) new TextButtonPartClass("Add unit", 155, tDescript, ref this.OwnBitmap, num2, y + 180, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.AddUnit = this.AddSubPart(ref tsubpart1, num2, y + 180, 155, 35, 1);
        }
        else
        {
          tDescript = "Can only place on friendly hex";
          tsubpart1 = (SubPartClass) new TextButtonPartClass("Add unit model", 155, tDescript, ref this.OwnBitmap, num2, y + 140, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.AddUnitModelB = this.AddSubPart(ref tsubpart1, num2, y + 140, 155, 35, 1);
          tsubpart1 = (SubPartClass) new TextButtonPartClass("Add unit", 155, tDescript, ref this.OwnBitmap, num2, y + 180, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.AddUnitB = this.AddSubPart(ref tsubpart1, num2, y + 180, 250, 35, 1);
        }
      }
      if (this.game.EditObj.UnitSelected == -1 | this.game.EditObj.OrderType > 0)
      {
        tsubpart1 = (SubPartClass) new TextButtonPartClass("Remove unit", 155, tDescript, ref this.OwnBitmap, num2, y + 100, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RemoveUnitB = this.AddSubPart(ref tsubpart1, num2, y + 100, 155, 35, 1);
      }
      tsubpart1 = (SubPartClass) new TextButtonPartClass("Import Units", 155, "Allows you to import the units placed on the map in another scenario. This will remove all your current units and assigned officers. This only works if you have loaded the neccessary officer and historical unit libraries that are used by the units you are trying to import. Also this will overwrite the hex ownership. ", ref this.OwnBitmap, num2 + 190, y + 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.importId = this.AddSubPart(ref tsubpart1, num2 + 190, y + 100, 155, 35, 1);
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
            if (num1 == this.VPListId)
            {
              int index2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (index2 > -1)
              {
                this.game.EditObj.UnitSelected = index2;
                int x1 = this.game.Data.UnitObj[index2].X;
                int y1 = this.game.Data.UnitObj[index2].Y;
                this.game.SelectX = x1;
                this.game.SelectY = y1;
                this.game.HandyFunctionsObj.CenterOnXY(x1, y1, true);
                windowReturnClass.AddCommand(4, 12);
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.AddUnitModel)
            {
              this.game.EditObj.TempHisModelUnit = -1;
              this.game.EditObj.TempHisUnit = -1;
              this.game.EditObj.TempRandom = -1;
              new Form3((Form) this.formref).Initialize(this.game.Data, 100, this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime, 0, this.game);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.standing1)
            {
              int unitCounter1 = this.game.Data.UnitCounter;
              for (int index3 = 0; index3 <= unitCounter1; ++index3)
              {
                if (this.game.Data.UnitObj[index3].Historical == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical & (this.game.Data.Round == 0 | this.game.Data.UnitObj[index3].Regime == this.game.Data.Turn))
                {
                  if (this.game.Data.UnitObj[index3].SODefendPercent == 0)
                    this.game.Data.UnitObj[index3].SODefendPercent = 25;
                  else if (this.game.Data.UnitObj[index3].SODefendPercent == 25)
                    this.game.Data.UnitObj[index3].SODefendPercent = 50;
                  else if (this.game.Data.UnitObj[index3].SODefendPercent == 50)
                    this.game.Data.UnitObj[index3].SODefendPercent = 75;
                  else
                    this.game.Data.UnitObj[index3].SODefendPercent = 0;
                }
              }
              int unitCounter2 = this.game.Data.UnitCounter;
              for (int unr = 0; unr <= unitCounter2; ++unr)
              {
                if (this.game.HandyFunctionsObj.IsUnitInHQChain(unr, this.game.EditObj.UnitSelected))
                  this.game.Data.UnitObj[unr].SODefendPercent = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SODefendPercent;
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.standing2)
            {
              if (this.game.Data.Round == 0 | this.game.Data.Turn == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime && this.game.HandyFunctionsObj.HasUnitAirSF(this.game.EditObj.UnitSelected))
              {
                if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop == 25)
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = 100;
                else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop == 50)
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = 25;
                else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop == 75)
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = 50;
                else
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = 75;
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.AddUnit)
            {
              this.game.EditObj.TempHisModelUnit = -1;
              this.game.EditObj.TempHisUnit = -1;
              this.game.EditObj.TempRandom = -1;
              new Form3((Form) this.formref).Initialize(this.game.Data, 101, 0, 0, this.game);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.SetCommander)
            {
              this.game.EditObj.TempHisModelUnit = -1;
              this.game.EditObj.TempHisUnit = -1;
              this.game.EditObj.TempRandom = -1;
              new Form3((Form) this.formref).Initialize(this.game.Data, 103, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, 0, this.game);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.HqUnit)
            {
              this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
              new Form3((Form) this.formref).Initialize(this.game.Data, 82, this.game.EditObj.OrderUnit, tGame: this.game);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.importId)
            {
              this.Import();
              this.DoStuff();
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.changeColor)
            {
              ColorDialog colorDialog = new ColorDialog();
              colorDialog.Color = Color.FromArgb((int) byte.MaxValue, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Red, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Green, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Blue);
              if (colorDialog.ShowDialog() == DialogResult.OK)
              {
                UnitClass unitClass1 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected];
                Color color = colorDialog.Color;
                int b1 = (int) color.B;
                unitClass1.Blue = b1;
                UnitClass unitClass2 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected];
                color = colorDialog.Color;
                int g = (int) color.G;
                unitClass2.Green = g;
                this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Red = (int) colorDialog.Color.R;
              }
              this.DoStuff();
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.MoveUnit)
            {
              this.game.EditObj.OrderType = 1;
              this.game.EditObj.TempCoordList = this.game.HandyFunctionsObj.MakeMovePrediction(this.game.EditObj.UnitSelected, this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, attackoptions: true, ismove: true);
              this.game.EditObj.TempCoordList.RemoveCoord(0);
              this.game.EditObj.OrderUnit = this.game.EditObj.UnitSelected;
              this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
              windowReturnClass.AddCommand(4, 12);
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.cancelid)
            {
              switch (this.game.EditObj.OrderType)
              {
                case 1:
                case 48:
                  this.game.EditObj.OrderType = 0;
                  if (this.game.EditObj.TempCoordList.counter < 3)
                    this.game.EditObj.TempCoordList = new CoordList();
                  this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                  this.game.SelectX = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X;
                  this.game.SelectY = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y;
                  this.game.EditObj.MapSelected = this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Map;
                  windowReturnClass.AddCommand(4, 12);
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                case 3:
                  this.game.EditObj.OrderType = 0;
                  this.game.EditObj.TempCoordList = new CoordList();
                  this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                  this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
                  windowReturnClass.AddCommand(4, 12);
                  this.game.SelectX = this.game.EditObj.OrderX;
                  this.game.SelectY = this.game.EditObj.OrderY;
                  this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                  if (this.game.Data.Round == 0)
                    this.game.Data.Turn = -1;
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                default:
                  continue;
              }
            }
            else if (num1 == this.ChangeCounterUnit)
            {
              int historical = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical;
              if (historical > -1)
              {
                string str1 = Interaction.InputBox("Give new name for unit", "Shadow Empire : Planetary Conquest", this.game.Data.HistoricalUnitObj[historical].Name.ToString());
                string str2 = Interaction.InputBox("Give new short name of unit", "Shadow Empire : Planetary Conquest", this.game.Data.HistoricalUnitObj[historical].CounterString);
                if (str1.Length > 0)
                  this.game.Data.HistoricalUnitObj[historical].Name = str1;
                this.game.Data.HistoricalUnitObj[historical].CounterString = str2;
                if (Operators.CompareString(Conversion.Val(str2).ToString(), str2, false) == 0)
                {
                  double a = Conversion.Val(str2);
                  if (this.game.Data.HistoricalUnitObj[historical].ModelMaster > -1 && a > (double) this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[historical].ModelMaster].NameCounter)
                    this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[historical].ModelMaster].NameCounter = (int) Math.Round(a);
                }
                int unitCounter = this.game.Data.UnitCounter;
                for (int index4 = 0; index4 <= unitCounter; ++index4)
                {
                  if (this.game.Data.UnitObj[index4].Historical == historical)
                    this.game.Data.UnitObj[index4].Name = this.game.Data.HistoricalUnitObj[historical].Name;
                }
                windowReturnClass.AddCommand(4, 12);
                this.game.SelectX = this.game.EditObj.OrderX;
                this.game.SelectY = this.game.EditObj.OrderY;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              int num2 = (int) Interaction.MsgBox((object) "Unit is not set to a historical unit.");
            }
            else if (num1 == this.RemoveUnit)
            {
              if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName.Length > 0)
              {
                LibIdClass libIdClass = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].OffLibId.Clone();
                this.game.Data.AddHistoricalUnit();
                this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].TempRegime = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].TempRegime;
                this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].People = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].People;
                this.game.ProcessingObj.SwapOfficer(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical, this.game.Data.HistoricalUnitCounter, this.game.EditObj.UnitSelected);
                this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].OffLibId = new LibIdClass();
                this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].LibId = libIdClass;
                this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].Pool = true;
              }
              if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].LibId.libSlot == -1)
              {
                this.game.Data.RemoveHistoricalUnit(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical);
                for (int unitCounter = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
                {
                  if (this.game.Data.UnitObj[unitCounter].PreDef == -1 & this.game.Data.UnitObj[unitCounter].Historical == -1)
                  {
                    DataClass data = this.game.Data;
                    int nr = unitCounter;
                    GameClass gameClass = (GameClass) null;
                    ref GameClass local = ref gameClass;
                    data.RemoveUnit(nr, ref local);
                  }
                }
              }
              else
              {
                int historical = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical;
                for (int unitCounter = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
                {
                  if (this.game.Data.UnitObj[unitCounter].Historical == historical)
                  {
                    this.game.Data.UnitObj[unitCounter].Historical = -1;
                    DataClass data = this.game.Data;
                    int nr = unitCounter;
                    GameClass gameClass = (GameClass) null;
                    ref GameClass local = ref gameClass;
                    data.RemoveUnit(nr, ref local);
                  }
                }
              }
              this.game.EditObj.UnitSelected = -1;
              windowReturnClass.AddCommand(4, 12);
              this.DoStuff();
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

    public void Import()
    {
      string str = "";
      string path = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to import units/assigned officers from...", this.game.AppPath + this.game.ModScenarioDir, false);
      if (!File.Exists(path))
        return;
      int num1 = (int) Interaction.MsgBox((object) "Ok hold on... this can take some time", Title: ((object) "Shadow Empire : Planetary Conquest"));
      this.game.FormRef.Cursor = Cursors.WaitCursor;
      this.game.EditObj.TempFileName = path;
      string tempFileName = this.game.EditObj.TempFileName;
      this.game.HandyFunctionsObj.Unzip(tempFileName);
      DataClass dataClass1 = new DataClass(DontLoadGraphics: true);
      DataClass dataClass2 = DataClass.deserialize(tempFileName);
      this.game.HandyFunctionsObj.ZipFile(tempFileName);
      bool[] flagArray = new bool[dataClass2.UnitCounter + 1];
      if (dataClass2.MapObj[0].MapWidth > this.game.Data.MapObj[0].MapWidth | dataClass2.MapObj[0].MapHeight > this.game.Data.MapObj[0].MapHeight)
        str = "Map of import is larger than your current map.";
      if (str.Length == 0)
      {
        int unitCounter = dataClass2.UnitCounter;
        for (int index1 = 0; index1 <= unitCounter; ++index1)
        {
          if (dataClass2.UnitObj[index1].PreDef == -1)
          {
            int historical = dataClass2.UnitObj[index1].Historical;
            if (dataClass2.HistoricalUnitObj[historical].CommanderName.Length > 0)
            {
              int libSlot = dataClass2.HistoricalUnitObj[historical].OffLibId.libSlot;
              if (libSlot > -1)
              {
                bool flag = false;
                if (this.game.Data.FindLibrary(dataClass2.LibraryObj[libSlot].name) > -1)
                {
                  int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
                  for (int index2 = 0; index2 <= historicalUnitCounter; ++index2)
                  {
                    if (this.game.Data.HistoricalUnitObj[index2].LibId.id == dataClass2.HistoricalUnitObj[historical].OffLibId.id)
                      flag = true;
                    if (this.game.Data.HistoricalUnitObj[index2].OffLibId.id == dataClass2.HistoricalUnitObj[historical].OffLibId.id)
                      flag = true;
                  }
                  if (!flag)
                    str = str + "Current scenario's library: " + dataClass2.LibraryObj[libSlot].name + " is missing definition for officer: " + dataClass2.HistoricalUnitObj[historical].CommanderName;
                }
                else
                  str = str + "Current scenario missing library: " + dataClass2.LibraryObj[libSlot].name;
              }
              else
                str = str + dataClass2.HistoricalUnitObj[historical].CommanderName + "";
            }
            if (dataClass2.HistoricalUnitObj[historical].LibId.libSlot > -1)
            {
              int libSlot = dataClass2.HistoricalUnitObj[historical].LibId.libSlot;
              if (libSlot > -1)
              {
                bool flag = false;
                if (this.game.Data.FindLibrary(dataClass2.LibraryObj[libSlot].name) > -1)
                {
                  int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
                  for (int index3 = 0; index3 <= historicalUnitCounter; ++index3)
                  {
                    if (this.game.Data.HistoricalUnitObj[index3].LibId.id == dataClass2.HistoricalUnitObj[historical].LibId.id)
                      flag = true;
                  }
                  if (!flag)
                    str = str + "Current scenario's library: " + dataClass2.LibraryObj[libSlot].name + " is missing definition for hist.unit: " + dataClass2.HistoricalUnitObj[historical].Name;
                }
                else
                  str = str + "Current scenario missing library: " + dataClass2.LibraryObj[libSlot].name;
              }
              else
                str = str + "Current scenario missing library: " + dataClass2.LibraryObj[libSlot].name;
            }
            else if (dataClass2.HistoricalUnitObj[historical].ModelMaster > -1)
            {
              int modelMaster = dataClass2.HistoricalUnitObj[historical].ModelMaster;
              if (modelMaster > -1)
              {
                if (dataClass2.HistoricalUnitObj[modelMaster].LibId.libSlot > -1)
                {
                  int libSlot = dataClass2.HistoricalUnitObj[modelMaster].LibId.libSlot;
                  if (libSlot > -1)
                  {
                    bool flag = false;
                    if (this.game.Data.FindLibrary(dataClass2.LibraryObj[libSlot].name) > -1)
                    {
                      int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
                      for (int index4 = 0; index4 <= historicalUnitCounter; ++index4)
                      {
                        if (this.game.Data.HistoricalUnitObj[index4].LibId.id == dataClass2.HistoricalUnitObj[modelMaster].LibId.id)
                          flag = true;
                      }
                      if (!flag)
                        str = str + "Current scenario's library: " + dataClass2.LibraryObj[libSlot].name + " is missing definition for hist.unit model: " + dataClass2.HistoricalUnitObj[modelMaster].Name;
                    }
                    else
                      str = str + "Current scenario missing library: " + dataClass2.LibraryObj[libSlot].name;
                  }
                  else
                    str = str + "Current scenario missing library: " + dataClass2.LibraryObj[libSlot].name;
                }
                else
                  str = str + "Unit " + dataClass2.UnitObj[index1].Name + " using model that does not use a library.";
              }
              else
                str = str + "Unit " + dataClass2.UnitObj[index1].Name + " without library and without model.";
            }
          }
          if (str.Length > 0)
            break;
        }
      }
      if (str.Length == 0)
      {
        int mapWidth = dataClass2.MapObj[0].MapWidth;
        for (int index5 = 0; index5 <= mapWidth; ++index5)
        {
          int mapHeight = dataClass2.MapObj[0].MapHeight;
          for (int index6 = 0; index6 <= mapHeight; ++index6)
          {
            int num2 = dataClass2.MapObj[0].HexObj[index5, index6].Regime <= -1 ? -1 : this.game.Data.FindRegimeFromSameLib(ref dataClass2.RegimeObj[dataClass2.MapObj[0].HexObj[index5, index6].Regime], "");
            this.game.Data.MapObj[0].HexObj[index5, index6].Regime = num2;
          }
        }
      }
      if (str.Length == 0)
      {
        for (int unitCounter = this.game.Data.UnitCounter; unitCounter >= 0; unitCounter += -1)
        {
          if (this.game.Data.UnitObj[unitCounter].PreDef == -1)
          {
            if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unitCounter].Historical].OffLibId.libSlot > -1)
            {
              int tempRegime = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unitCounter].Historical].TempRegime;
              LibIdClass libIdClass = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unitCounter].Historical].OffLibId.Clone();
              this.game.Data.AddHistoricalUnit();
              this.game.ProcessingObj.SwapOfficer(this.game.Data.UnitObj[unitCounter].Regime, this.game.Data.UnitObj[unitCounter].Historical, this.game.Data.HistoricalUnitCounter, unitCounter);
              this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unitCounter].Historical].OffLibId = new LibIdClass();
              this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].LibId = libIdClass;
              this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].Pool = true;
              this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unitCounter].Historical].TempRegime = tempRegime;
            }
            DataClass data = this.game.Data;
            int nr = unitCounter;
            GameClass gameClass = (GameClass) null;
            ref GameClass local = ref gameClass;
            data.RemoveUnit(nr, ref local);
          }
        }
        for (int historicalUnitCounter = this.game.Data.HistoricalUnitCounter; historicalUnitCounter >= 0; historicalUnitCounter += -1)
        {
          if (this.game.Data.HistoricalUnitObj[historicalUnitCounter].LibId.libSlot == -1)
            this.game.Data.RemoveHistoricalUnit(historicalUnitCounter);
        }
      }
      if (str.Length == 0)
      {
        int unitCounter1 = dataClass2.UnitCounter;
        for (int index7 = 0; index7 <= unitCounter1; ++index7)
        {
          if (dataClass2.UnitObj[index7].PreDef == -1 & !flagArray[index7])
          {
            int historical = dataClass2.UnitObj[index7].Historical;
            if (dataClass2.HistoricalUnitObj[historical].LibId.libSlot > -1)
            {
              this.game.Data.FindRegimeFromSameLib(ref dataClass2.RegimeObj[dataClass2.HistoricalUnitObj[historical].TempRegime], dataClass2.LibraryObj[dataClass2.HistoricalUnitObj[historical].LibId.libSlot].name);
              int historicalFromSameLib = this.game.Data.FindHistoricalFromSameLib(ref dataClass2.HistoricalUnitObj[historical], dataClass2.LibraryObj[dataClass2.HistoricalUnitObj[historical].LibId.libSlot].name);
              this.game.EventRelatedObj.ExecAddHistoricalUnit(dataClass2.UnitObj[index7].X, dataClass2.UnitObj[index7].Y, this.game.Data.HistoricalUnitObj[historicalFromSameLib].ID, 0, "");
              int unitCounter2 = dataClass2.UnitCounter;
              for (int index8 = 0; index8 <= unitCounter2; ++index8)
              {
                if (dataClass2.UnitObj[index8].Historical == dataClass2.UnitObj[index7].Historical)
                {
                  flagArray[index8] = true;
                  for (int unitCounter3 = this.game.Data.MapObj[0].HexObj[dataClass2.UnitObj[index7].X, dataClass2.UnitObj[index7].Y].UnitCounter; unitCounter3 >= 0; unitCounter3 += -1)
                  {
                    int unit = this.game.Data.MapObj[0].HexObj[dataClass2.UnitObj[index7].X, dataClass2.UnitObj[index7].Y].UnitList[unitCounter3];
                    if (this.game.Data.UnitObj[unit].Historical == historicalFromSameLib & this.game.Data.UnitObj[unit].HistoricalSubPart == dataClass2.UnitObj[index8].HistoricalSubPart)
                    {
                      this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unit].X, this.game.Data.UnitObj[unit].Y].RemoveUnitFromList(unit);
                      this.game.Data.MapObj[0].HexObj[dataClass2.UnitObj[index8].X, dataClass2.UnitObj[index8].Y].AddUnitToList(unit);
                    }
                  }
                }
              }
            }
            else
            {
              int regimeFromSameLib = this.game.Data.FindRegimeFromSameLib(ref dataClass2.RegimeObj[dataClass2.HistoricalUnitObj[historical].TempRegime], "");
              int modelMaster = dataClass2.HistoricalUnitObj[historical].ModelMaster;
              int historicalFromSameLib = this.game.Data.FindHistoricalFromSameLib(ref dataClass2.HistoricalUnitObj[modelMaster], dataClass2.LibraryObj[dataClass2.HistoricalUnitObj[modelMaster].LibId.libSlot].name);
              this.game.ProcessingObj.AddNewUnitBasedOnHistorical(dataClass2.UnitObj[index7].X, dataClass2.UnitObj[index7].Y, 0, regimeFromSameLib, historicalFromSameLib, freePPnoUnit: true, populateUnit: true);
              int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
              int unitCounter4 = dataClass2.UnitCounter;
              for (int index9 = 0; index9 <= unitCounter4; ++index9)
              {
                if (dataClass2.UnitObj[index9].Historical == dataClass2.UnitObj[index7].Historical)
                {
                  flagArray[index9] = true;
                  for (int unitCounter5 = this.game.Data.MapObj[0].HexObj[dataClass2.UnitObj[index7].X, dataClass2.UnitObj[index7].Y].UnitCounter; unitCounter5 >= 0; unitCounter5 += -1)
                  {
                    int unit = this.game.Data.MapObj[0].HexObj[dataClass2.UnitObj[index7].X, dataClass2.UnitObj[index7].Y].UnitList[unitCounter5];
                    if (this.game.Data.UnitObj[unit].Historical == historicalUnitCounter & this.game.Data.UnitObj[unit].HistoricalSubPart == dataClass2.UnitObj[index9].HistoricalSubPart)
                    {
                      this.game.Data.MapObj[0].HexObj[this.game.Data.UnitObj[unit].X, this.game.Data.UnitObj[unit].Y].RemoveUnitFromList(unit);
                      this.game.Data.MapObj[0].HexObj[dataClass2.UnitObj[index9].X, dataClass2.UnitObj[index9].Y].AddUnitToList(unit);
                      this.game.Data.UnitObj[unit].X = dataClass2.UnitObj[index9].X;
                      this.game.Data.UnitObj[unit].Y = dataClass2.UnitObj[index9].Y;
                      this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unit].Historical].Counter = dataClass2.HistoricalUnitObj[dataClass2.UnitObj[index9].Historical].Counter;
                      this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[unit].Historical].CounterString = dataClass2.HistoricalUnitObj[dataClass2.UnitObj[index9].Historical].CounterString;
                      break;
                    }
                  }
                }
              }
            }
            if (dataClass2.HistoricalUnitObj[historical].OffLibId.libSlot > -1)
            {
              int historicalBySameLib = this.game.Data.FindOffHistoricalBySameLib(ref dataClass2.HistoricalUnitObj[historical], dataClass2.LibraryObj[dataClass2.HistoricalUnitObj[historical].OffLibId.libSlot].name);
              LibIdClass libIdClass = this.game.Data.HistoricalUnitObj[historicalBySameLib].LibId.Clone();
              this.game.ProcessingObj.SwapOfficer(this.game.Data.UnitObj[this.game.Data.UnitCounter].Regime, this.game.Data.UnitObj[this.game.Data.UnitCounter].Historical, historicalBySameLib, this.game.Data.UnitCounter);
              this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.Data.UnitCounter].Historical].OffLibId = libIdClass.Clone();
            }
          }
        }
      }
      if (str.Length == 0)
      {
        int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
        for (int index10 = 0; index10 <= historicalUnitCounter1; ++index10)
        {
          if (this.game.Data.HistoricalUnitObj[index10].Model)
          {
            int historicalUnitCounter2 = dataClass2.HistoricalUnitCounter;
            for (int index11 = 0; index11 <= historicalUnitCounter2; ++index11)
            {
              if (dataClass2.HistoricalUnitObj[index11].Model && Operators.CompareString(this.game.Data.LibraryObj[this.game.Data.HistoricalUnitObj[index10].LibId.libSlot].name, dataClass2.LibraryObj[dataClass2.HistoricalUnitObj[index11].LibId.libSlot].name, false) == 0 && this.game.Data.HistoricalUnitObj[index10].LibId.id == dataClass2.HistoricalUnitObj[index11].LibId.id)
                this.game.Data.HistoricalUnitObj[index10].NameCounter = dataClass2.HistoricalUnitObj[index11].NameCounter;
            }
          }
        }
      }
      dataClass1 = (DataClass) null;
      this.game.EditObj.UnitSelected = -1;
      this.game.EditObj.OldUnit = -1;
      this.game.FormRef.Cursor = Cursors.Default;
      if (str.Length > 0)
      {
        int num3 = (int) Interaction.MsgBox((object) ("ERROR IN IMPORT: " + str), Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      else
      {
        int num4 = (int) Interaction.MsgBox((object) "Import completed succesfully", Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
    }
  }
}
