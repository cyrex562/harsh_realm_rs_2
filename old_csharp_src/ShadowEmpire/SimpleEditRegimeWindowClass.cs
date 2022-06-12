// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleEditRegimeWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class SimpleEditRegimeWindowClass : WindowClass
  {
    private int listId;
    private ListClass listObj;
    private int list2Id;
    private ListClass list2Obj;
    private int regId;
    private int offid;
    private int AddOff;
    private int RemoveOff;
    private int RemoveOffB;
    private int AddRegime;
    private int RemoveRegime;
    private int ChangeFlag;
    private int changeColorExt;
    private int AddRegimeB;
    private int RemoveRegimeB;
    private int ChangeColorBack;
    private int ChangeColorFront;
    private int ChangeName;
    private int ChangePeople;
    private int ChangeIcon;
    private int ChangeRoundel;
    private int ChangeMirror;

    public SimpleEditRegimeWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 50, 9, tDoBorders: 1, tHeaderString: "Regimes")
    {
      this.regId = -1;
      this.offid = -1;
      this.DoStuff();
    }

    public override void DoRefresh() => this.DoStuff();

    public void DoStuff()
    {
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      if (this.listId > 0)
        this.RemoveSubPart(this.listId);
      if (this.list2Id > 0)
        this.RemoveSubPart(this.list2Id);
      if (this.AddOff > 0)
        this.RemoveSubPart(this.AddOff);
      if (this.RemoveOff > 0)
        this.RemoveSubPart(this.RemoveOff);
      if (this.RemoveOffB > 0)
        this.RemoveSubPart(this.RemoveOffB);
      if (this.AddRegime > 0)
        this.RemoveSubPart(this.AddRegime);
      if (this.AddRegimeB > 0)
        this.RemoveSubPart(this.AddRegimeB);
      if (this.RemoveRegime > 0)
        this.RemoveSubPart(this.RemoveRegime);
      if (this.RemoveRegimeB > 0)
        this.RemoveSubPart(this.RemoveRegimeB);
      if (this.ChangeColorBack > 0)
        this.RemoveSubPart(this.ChangeColorBack);
      if (this.ChangeColorFront > 0)
        this.RemoveSubPart(this.ChangeColorFront);
      if (this.changeColorExt > 0)
        this.RemoveSubPart(this.changeColorExt);
      if (this.ChangeName > 0)
        this.RemoveSubPart(this.ChangeName);
      if (this.ChangePeople > 0)
        this.RemoveSubPart(this.ChangePeople);
      if (this.ChangeIcon > 0)
        this.RemoveSubPart(this.ChangeIcon);
      if (this.ChangeRoundel > 0)
        this.RemoveSubPart(this.ChangeRoundel);
      if (this.ChangeMirror > 0)
        this.RemoveSubPart(this.ChangeMirror);
      if (this.ChangeFlag > 0)
        this.RemoveSubPart(this.ChangeFlag);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      Expression.SmoothingMode = SmoothingMode.AntiAlias;
      Expression.TextRenderingHint = TextRenderingHint.AntiAlias;
      Expression.TextContrast = 1;
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 50, -1);
      int num2 = -1;
      int num3 = -1;
      this.listObj = new ListClass();
      int regimeCounter = this.game.Data.RegimeCounter;
      for (int index = 0; index <= regimeCounter; ++index)
      {
        ++num2;
        this.listObj.add(Conversion.Str((object) index) + ") " + this.game.Data.RegimeObj[index].Name, index);
        if (this.regId == index)
          num3 = num2;
      }
      if (num3 == -1)
        this.regId = -1;
      ListClass listObj = this.listObj;
      int tlistselect1 = num3;
      GameClass game1 = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      int bbx1 = 10 + num1;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(listObj, 5, 300, tlistselect1, game1, true, "Regimes", tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: bbx1, bby: 92, tMarcStyle: true, overruleFont: (ref local2));
      this.listId = this.AddSubPart(ref tsubpart, 10 + num1, 72, 300, 128, 0);
      int num4 = 198;
      if (this.game.Data.RegimeCounter < 1)
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("Add Regime", 140, "Click to add a regime", ref this.OwnBitmap, 10 + num1, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.AddRegime = this.AddSubPart(ref tsubpart, 10 + num1, num4, 140, 35, 1);
      }
      else
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("Add Regime", 140, "Maximum 2 regime supported at the moment", ref this.OwnBitmap, 10 + num1, num4, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.AddRegimeB = this.AddSubPart(ref tsubpart, 10 + num1, num4, 140, 35, 1);
      }
      if (this.regId > -1)
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("Remove Regime", 140, "Click to remove selected regime", ref this.OwnBitmap, 150 + num1, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RemoveRegime = this.AddSubPart(ref tsubpart, 150 + num1, num4, 140, 35, 1);
      }
      else
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("Remove Regime", 140, "You must first select a regime.", ref this.OwnBitmap, 150 + num1, num4, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RemoveRegimeB = this.AddSubPart(ref tsubpart, 150 + num1, 262, 140, 35, 1);
      }
      if (this.regId > -1)
      {
        DrawMod.DrawBlock(ref Expression, 410 + num1, 72, 600, 320, 0, 0, 0, 60);
        DrawMod.DrawTextColouredMarc(ref Expression, "COMMANDER POOL", this.game.MarcFont4, 430 + num1, 82, Color.White);
        int num5 = -1;
        int num6 = -1;
        this.list2Obj = new ListClass();
        int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
        for (int index = 0; index <= historicalUnitCounter; ++index)
        {
          if (this.game.Data.HistoricalUnitObj[index].CommanderName.Length > 0 & this.game.Data.HistoricalUnitObj[index].TempRegime == this.regId & this.game.Data.HistoricalUnitObj[index].Pool & this.game.HandyFunctionsObj.GetUnitByHistorical(index) == -1)
          {
            ++num5;
            int people = this.game.Data.HistoricalUnitObj[index].People;
            if (people > -1)
              this.list2Obj.add(Conversion.Str((object) index) + ") " + this.game.Data.HistoricalUnitObj[index].CommanderName + " (" + this.game.Data.PeopleObj[people].Name + ")", index);
            else
              this.list2Obj.add(Conversion.Str((object) index) + ") " + this.game.Data.HistoricalUnitObj[index].CommanderName, index);
            if (this.offid == index)
              num6 = num5;
          }
        }
        if (num3 == -1)
          this.regId = -1;
        ListClass list2Obj = this.list2Obj;
        int tlistselect2 = num6;
        GameClass game2 = this.game;
        ref Bitmap local3 = ref this.OwnBitmap;
        int bbx2 = 430 + num1;
        font = (Font) null;
        ref Font local4 = ref font;
        tsubpart = (SubPartClass) new ListSubPartClass(list2Obj, 15, 300, tlistselect2, game2, true, "Commander Pool", tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref local3), bbx: bbx2, bby: 102, tMarcStyle: true, overruleFont: (ref local4));
        this.list2Id = this.AddSubPart(ref tsubpart, 430 + num1, 102, 300, 288, 0);
        tsubpart = (SubPartClass) new TextButtonPartClass("Add Commander", 200, "Click to add commander", ref this.OwnBitmap, 760 + num1, 102, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.AddOff = this.AddSubPart(ref tsubpart, 760 + num1, 102, 200, 35, 1);
        if (this.offid > -1)
        {
          tsubpart = (SubPartClass) new TextButtonPartClass("Remove Commander", 200, "Click to remove commander", ref this.OwnBitmap, 760 + num1, 142, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.RemoveOff = this.AddSubPart(ref tsubpart, 760 + num1, 142, 200, 35, 1);
        }
        else
        {
          tsubpart = (SubPartClass) new TextButtonPartClass("Remove Commander", 200, "Click to remove commander", ref this.OwnBitmap, 760 + num1, 142, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.RemoveOffB = this.AddSubPart(ref tsubpart, 760 + num1, 142, 200, 35, 1);
        }
        int num7 = 20 + num1;
        int y1 = 266;
        DrawMod.DrawBlock(ref Expression, 10 + num1, y1 - 10, 340, 492, 0, 0, 0, 60);
        DrawMod.DrawTextColouredMarc(ref Expression, "Name", this.game.MarcFont4, num7, y1, Color.White);
        DrawMod.DrawTextColouredMarc(ref Expression, this.game.Data.RegimeObj[this.regId].Name, this.game.MarcFont3, num7, y1 + 20, Color.White);
        tsubpart = (SubPartClass) new TextButtonPartClass("Change", 70, "Click to change the name of selected regime", ref this.OwnBitmap, num7 + 250, y1 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.ChangeName = this.AddSubPart(ref tsubpart, num7 + 250, y1 + 5, 60, 35, 1);
        int y2 = y1 + 52;
        DrawMod.DrawTextColouredMarc(ref Expression, "People", this.game.MarcFont4, num7, y2, Color.White);
        DrawMod.DrawTextColouredMarc(ref Expression, this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.regId].People].Name, this.game.MarcFont3, num7, y2 + 20, Color.White);
        tsubpart = (SubPartClass) new TextButtonPartClass("Change", 70, "Click to change the people of selected regime", ref this.OwnBitmap, num7 + 250, y2 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.ChangePeople = this.AddSubPart(ref tsubpart, num7 + 250, y2 + 5, 60, 35, 1);
        int y3 = y2 + 52;
        DrawMod.DrawTextColouredMarc(ref Expression, "Counter background color", this.game.MarcFont4, num7, y3, Color.White);
        DrawMod.DrawBlock(ref Expression, num7, y3 + 20, 240, 16, this.game.Data.RegimeObj[this.regId].Red, this.game.Data.RegimeObj[this.regId].Green, this.game.Data.RegimeObj[this.regId].Blue, (int) byte.MaxValue);
        tsubpart = (SubPartClass) new TextButtonPartClass("Change", 70, "Click to change the background color of the counter. ", ref this.OwnBitmap, num7 + 250, y3 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.ChangeColorBack = this.AddSubPart(ref tsubpart, num7 + 250, y3 + 5, 60, 35, 1);
        int y4 = y3 + 52;
        DrawMod.DrawTextColouredMarc(ref Expression, "Counter forground color", this.game.MarcFont4, num7, y4, Color.White);
        DrawMod.DrawBlock(ref Expression, num7, y4 + 20, 240, 16, this.game.Data.RegimeObj[this.regId].Red2, this.game.Data.RegimeObj[this.regId].Green2, this.game.Data.RegimeObj[this.regId].Blue2, (int) byte.MaxValue);
        tsubpart = (SubPartClass) new TextButtonPartClass("Change", 70, "Click to change the text and siluet printing on the counters.", ref this.OwnBitmap, num7 + 250, y4 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.ChangeColorFront = this.AddSubPart(ref tsubpart, num7 + 250, y4 + 5, 60, 35, 1);
        int y5 = y4 + 52;
        DrawMod.DrawTextColouredMarc(ref Expression, "Frontline overlay color", this.game.MarcFont4, num7, y5, Color.White);
        DrawMod.DrawBlock(ref Expression, num7, y5 + 20, 240, 16, this.game.Data.RegimeObj[this.regId].Red3, this.game.Data.RegimeObj[this.regId].Green3, this.game.Data.RegimeObj[this.regId].Blue3, (int) byte.MaxValue);
        tsubpart = (SubPartClass) new TextButtonPartClass("Change", 70, "Click to change the colour of the shading of the hexes and frontlines for this regime.", ref this.OwnBitmap, num7 + 250, y5 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.changeColorExt = this.AddSubPart(ref tsubpart, num7 + 250, y5 + 5, 60, 35, 1);
        int y6 = y5 + 52;
        DrawMod.DrawTextColouredMarc(ref Expression, "Mirror counter siluets", this.game.MarcFont4, num7, y6, Color.White);
        DrawMod.DrawTextColouredMarc(ref Expression, this.game.Data.RegimeObj[this.regId].Mirror.ToString(), this.game.MarcFont3, num7, y6 + 20, Color.White);
        tsubpart = (SubPartClass) new TextButtonPartClass("Change", 70, "Click to change the mirror setting. Mirroring swaps orientation of siluet on counter.", ref this.OwnBitmap, num7 + 250, y6 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.ChangeMirror = this.AddSubPart(ref tsubpart, num7 + 250, y6 + 5, 60, 35, 1);
        int y7 = y6 + 52;
        DrawMod.DrawTextColouredMarc(ref Expression, "National icon", this.game.MarcFont4, num7, y7, Color.White);
        ref Graphics local5 = ref Expression;
        Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[this.regId].NationalIconSprite, -1);
        ref Bitmap local6 = ref bitmap1;
        int x1 = num7 + 20;
        int y8 = y7 + 23;
        DrawMod.DrawSimple(ref local5, ref local6, x1, y8);
        ref Graphics local7 = ref Expression;
        Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[this.regId].NationalIconSprite);
        ref Bitmap local8 = ref bitmap2;
        int x2 = num7 + 40;
        int y9 = y7 + 23;
        DrawMod.DrawSimple(ref local7, ref local8, x2, y9);
        ref Graphics local9 = ref Expression;
        Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[this.regId].NationalIconSprite, 1);
        ref Bitmap local10 = ref bitmap3;
        int x3 = num7 + 60;
        int y10 = y7 + 23;
        DrawMod.DrawSimple(ref local9, ref local10, x3, y10);
        tsubpart = (SubPartClass) new TextButtonPartClass("Change", 70, "Click to change the national icon of the selected regime", ref this.OwnBitmap, num7 + 250, y7 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.ChangeIcon = this.AddSubPart(ref tsubpart, num7 + 250, y7 + 5, 60, 35, 1);
        int y11 = y7 + 52;
        DrawMod.DrawTextColouredMarc(ref Expression, "Roundel sprite", this.game.MarcFont4, num7, y11, Color.White);
        ref Graphics local11 = ref Expression;
        Bitmap bitmap4 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[this.regId].RoundelIconSprite);
        ref Bitmap local12 = ref bitmap4;
        int x4 = num7 + 110;
        int y12 = y11 + 3;
        DrawMod.DrawScaled(ref local11, ref local12, x4, y12, 64, 64, true);
        tsubpart = (SubPartClass) new TextButtonPartClass("Change", 70, "Click to change the roundel sprite of the selected regime", ref this.OwnBitmap, num7 + 230, y11 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.ChangeRoundel = this.AddSubPart(ref tsubpart, num7 + 250, y11 + 5, 60, 35, 1);
        int y13 = y11 + 52;
        DrawMod.DrawTextColouredMarc(ref Expression, "(HQ) Flag", this.game.MarcFont4, num7, y13, Color.White);
        ref Graphics local13 = ref Expression;
        Bitmap bitmap5 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[this.regId].HQSpriteNr, -1);
        ref Bitmap local14 = ref bitmap5;
        int x5 = num7 + 90;
        int y14 = y13 + 23;
        DrawMod.DrawSimple(ref local13, ref local14, x5, y14);
        ref Graphics local15 = ref Expression;
        Bitmap bitmap6 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[this.regId].HQSpriteNr);
        ref Bitmap local16 = ref bitmap6;
        int x6 = num7 + 110;
        int y15 = y13 + 13;
        DrawMod.DrawSimple(ref local15, ref local16, x6, y15);
        ref Graphics local17 = ref Expression;
        bitmap6 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[this.regId].HQSpriteNr, 1);
        ref Bitmap local18 = ref bitmap6;
        int x7 = num7 + 140;
        int y16 = y13 - 3;
        DrawMod.DrawSimple(ref local17, ref local18, x7, y16);
        tsubpart = (SubPartClass) new TextButtonPartClass("Change", 70, "Click to change the HQ flag of the selected regime", ref this.OwnBitmap, num7 + 250, y13 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.ChangeFlag = this.AddSubPart(ref tsubpart, num7 + 250, y13 + 5, 60, 35, 1);
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
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
            if (num1 == this.listId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              if (num2 > -1)
              {
                this.regId = num2;
                this.offid = -1;
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.list2Id)
            {
              int num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              if (num3 > -1)
                this.offid = num3;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.AddOff)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 102, this.regId, tGame: this.game);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.RemoveOff)
            {
              this.game.Data.HistoricalUnitObj[this.offid].Pool = false;
              this.offid = -1;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.AddRegime)
            {
              if (this.game.Data.PeopleCounter < 0)
              {
                this.game.Data.AddPeople();
                this.game.Data.PeopleObj[0].Name = "Universals";
              }
              this.game.Data.AddRegime();
              this.regId = this.game.Data.RegimeCounter;
              this.game.Data.RegimeObj[this.game.Data.RegimeCounter].Name = "Regime #" + this.game.Data.RegimeCounter.ToString();
              this.game.Data.RegimeObj[this.game.Data.RegimeCounter].People = 0;
              int regimeCounter = this.game.Data.RegimeCounter;
              for (int index2 = 0; index2 <= regimeCounter; ++index2)
              {
                this.game.Data.RegimeObj[this.game.Data.RegimeCounter].RegimeRel[index2] = 0;
                this.game.Data.RegimeObj[index2].RegimeRel[this.game.Data.RegimeCounter] = 0;
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.RemoveRegime)
            {
              this.game.Data.RemoveRegime(this.regId);
              this.regId = -1;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeName)
            {
              this.game.Data.RegimeObj[this.regId].Name = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest");
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangePeople)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 3, this.regId);
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeColorBack)
            {
              ColorDialog colorDialog = new ColorDialog();
              colorDialog.Color = Color.FromArgb((int) byte.MaxValue, this.game.Data.RegimeObj[this.regId].Red, this.game.Data.RegimeObj[this.regId].Green, this.game.Data.RegimeObj[this.regId].Blue);
              if (colorDialog.ShowDialog() == DialogResult.OK)
              {
                RegimeClass regimeClass1 = this.game.Data.RegimeObj[this.regId];
                Color color = colorDialog.Color;
                int r = (int) color.R;
                regimeClass1.Red = r;
                RegimeClass regimeClass2 = this.game.Data.RegimeObj[this.regId];
                color = colorDialog.Color;
                int g = (int) color.G;
                regimeClass2.Green = g;
                RegimeClass regimeClass3 = this.game.Data.RegimeObj[this.regId];
                color = colorDialog.Color;
                int b1 = (int) color.B;
                regimeClass3.Blue = b1;
                this.game.Data.RegimeObj[this.regId].HexBack = (Bitmap) null;
                this.game.Data.RegimeObj[this.regId].TempCounter = (Bitmap) null;
                this.game.Data.RegimeObj[this.regId].DoTempCounter();
                this.game.Data.RegimeObj[this.regId].DoTempCounterBig();
                this.game.Data.RegimeObj[this.regId].DoTempCounterSmall();
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeColorFront)
            {
              ColorDialog colorDialog = new ColorDialog();
              colorDialog.Color = Color.FromArgb((int) byte.MaxValue, this.game.Data.RegimeObj[this.regId].Red2, this.game.Data.RegimeObj[this.regId].Green2, this.game.Data.RegimeObj[this.regId].Blue2);
              if (colorDialog.ShowDialog() == DialogResult.OK)
              {
                RegimeClass regimeClass4 = this.game.Data.RegimeObj[this.regId];
                Color color = colorDialog.Color;
                int r = (int) color.R;
                regimeClass4.Red2 = r;
                RegimeClass regimeClass5 = this.game.Data.RegimeObj[this.regId];
                color = colorDialog.Color;
                int g = (int) color.G;
                regimeClass5.Green2 = g;
                RegimeClass regimeClass6 = this.game.Data.RegimeObj[this.regId];
                color = colorDialog.Color;
                int b2 = (int) color.B;
                regimeClass6.Blue2 = b2;
                this.game.Data.RegimeObj[this.regId].HexBack = (Bitmap) null;
                this.game.Data.RegimeObj[this.regId].TempCounter = (Bitmap) null;
                this.game.Data.RegimeObj[this.regId].DoTempCounter();
                this.game.Data.RegimeObj[this.regId].DoTempCounterBig();
                this.game.Data.RegimeObj[this.regId].DoTempCounterSmall();
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.changeColorExt)
            {
              ColorDialog colorDialog = new ColorDialog();
              colorDialog.Color = Color.FromArgb((int) byte.MaxValue, this.game.Data.RegimeObj[this.regId].Red3, this.game.Data.RegimeObj[this.regId].Green3, this.game.Data.RegimeObj[this.regId].Blue3);
              if (colorDialog.ShowDialog() == DialogResult.OK)
              {
                RegimeClass regimeClass7 = this.game.Data.RegimeObj[this.regId];
                Color color = colorDialog.Color;
                int r = (int) color.R;
                regimeClass7.Red3 = r;
                RegimeClass regimeClass8 = this.game.Data.RegimeObj[this.regId];
                color = colorDialog.Color;
                int g = (int) color.G;
                regimeClass8.Green3 = g;
                RegimeClass regimeClass9 = this.game.Data.RegimeObj[this.regId];
                color = colorDialog.Color;
                int b3 = (int) color.B;
                regimeClass9.Blue3 = b3;
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeIcon)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png (*.png)|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of National Identifier of this regime:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.RegimeObj[this.regId].ReplaceNationalSprite(filename);
              }
              else
              {
                int num4 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeFlag)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png (*.png)|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of HQ Symbol Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.RegimeObj[this.regId].ReplaceHQSprite(filename);
              }
              else
              {
                int num5 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeRoundel)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png (*.png)|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of National Identifier of this regime:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.RegimeObj[this.regId].ReplaceRoundelSprite(filename);
              }
              else
              {
                int num6 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeMirror)
            {
              this.game.Data.RegimeObj[this.regId].Mirror = !this.game.Data.RegimeObj[this.regId].Mirror;
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
  }
}
