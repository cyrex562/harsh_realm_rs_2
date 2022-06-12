// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleLibraryWindowClass
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
  public class SimpleLibraryWindowClass : WindowClass
  {
    private int LibListId;
    private ListClass LibListObj;
    private int CatListId;
    private ListClass CatListObj;
    private int IndListId;
    private ListClass IndListObj;
    private int AddLibEventId;
    private int AddLibTroopsId;
    private int AddLibTextId;
    private int RemoveLibEventId;
    private int RemoveLibEventIdb;
    private int loadVarsId;
    private int LibVarListId;
    private ListClass LibVarListObj;
    private int AddLibVarId;
    private int AddLibVarTextId;
    private int RemoveLibVarId;
    private int RemoveLibVarTextId;
    private int LibVarTypeId;
    private int LibVarTypeTextId;
    private int importId;
    private int LibVarNameId;
    private int LibVarNameTextId;
    private int LibVarInfoId;
    private int LibVarInfoTextId;
    private int LibVarValueTypeId;
    private int LibVarValueTypeTextId;
    private int BNameId;
    private int BNameTextId;
    private int B2Id;
    private int B2TextId;
    private int B3Id;
    private int B3TextId;
    private int B4Id;
    private int B4TextId;
    private int text1id;
    private int text2id;
    private int ChangeValId;
    private int ExecuteId;
    private int TaId;
    private int loadEventPic;
    private int loadSmallGfx;
    private int removeSmallGfx;
    private int removeEventPic;
    private int saveId;
    private int save2id;
    private int save3id;
    private int save4id;
    private int reloadEventPic;
    private int reloadSmallGfx;
    private int LibId;
    private int LibVarId;
    private int IndId;
    private int CatId;
    private string ss;

    public SimpleLibraryWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 50, 9, tDoBorders: 1, tHeaderString: "Libraries")
    {
      this.LibId = -1;
      this.LibVarId = -1;
      this.CatId = -1;
      this.IndId = -1;
      this.DoStuff();
    }

    public override void DoRefresh() => this.DoStuff();

    public void PopUpRefresh() => this.DoStuff();

    private void InfoLibVar(ref Graphics g, int usex1, int usey1)
    {
      DrawMod.DrawBlock(ref g, usex1, usey1, 680, 304, 0, 0, 0, 80);
      DrawMod.DrawTextColouredMarc(ref g, "Name:", this.game.MarcFont4, usex1 + 20, usey1 + 30, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, this.game.Data.LibVarObj[this.LibVarId].name + "(inst.id=" + this.game.Data.LibVarObj[this.LibVarId].instanceId.id.ToString() + ")", this.game.MarcFont3, usex1 + 20, usey1 + 50, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, "Value:", this.game.MarcFont4, usex1 + 300, usey1 + 30, Color.White);
      int libVarUseId = this.game.Data.GetLibVarUseId(this.LibVarId, this.IndId);
      string tstring1 = this.game.Data.LibVarObj[libVarUseId].valueType.ToString();
      string tstring2 = this.game.Data.LibVarObj[libVarUseId].GetValue(ref this.game.Data);
      if (this.game.Data.LibVarObj[libVarUseId].instanceId.id > -1)
        tstring2 = this.game.Data.LibVarObj[libVarUseId].GetValue(ref this.game.Data) + " (NumericValue=" + this.game.Data.LibVarObj[libVarUseId].value.ToString() + ")";
      if (libVarUseId == this.LibVarId & this.game.Data.LibVarObj[libVarUseId].instanceId.id == -1 & !(this.game.Data.LibVarObj[libVarUseId].type == NewEnums.LibVarType.General | this.game.Data.LibVarObj[libVarUseId].type == NewEnums.LibVarType.Hex))
        tstring2 = "-not set-";
      if (tstring2.Length > 30)
        DrawMod.DrawTextColouredMarc(ref g, tstring2, this.game.MarcFont5, usex1 + 300, usey1 + 50, Color.White);
      else if (tstring2.Length > 15)
        DrawMod.DrawTextColouredMarc(ref g, tstring2, this.game.MarcFont4, usex1 + 300, usey1 + 50, Color.White);
      else
        DrawMod.DrawTextColouredMarc(ref g, tstring2, this.game.MarcFont3, usex1 + 300, usey1 + 50, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, "ValueType:", this.game.MarcFont4, usex1 + 20, usey1 + 75, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, tstring1, this.game.MarcFont3, usex1 + 20, usey1 + 95, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, "Variable information:", this.game.MarcFont4, usex1 + 20, usey1 + 125, Color.White);
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 580, 4, this.game.MarcFont4, this.game.Data.LibVarObj[this.LibVarId].information, 27, ref this.OwnBitmap, usex1 + 20, usey1 + 120);
      this.text2id = this.AddSubPart(ref tsubpart1, usex1 + 20, usey1 + 120, 580, 100, 0);
      this.ss = "Click to change this value";
      if (this.game.Data.LibVarObj[libVarUseId].type == NewEnums.LibVarType.Hex)
        return;
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Change this value", 200, this.ss, ref this.OwnBitmap, usex1 + 300, usey1 + 75, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.ChangeValId = this.AddSubPart(ref tsubpart2, usex1 + 300, usey1 + 75, 200, 35, 1);
    }

    private void InfoEvent(ref Graphics g, int usex1, int usey1)
    {
      DrawMod.DrawBlock(ref g, usex1, usey1, 680, 304, 0, 0, 0, 80);
      DrawMod.DrawTextColouredMarc(ref g, "Event name:", this.game.MarcFont4, usex1 + 20, usey1 + 30, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, this.game.Data.EventObj[this.LibVarId].Name, this.game.MarcFont3, usex1 + 20, usey1 + 50, Color.White);
      if (this.game.Data.EventObj[this.LibVarId].AllowExecute)
      {
        this.ss = "Click to execute this event. Please read the library information, if available, to better understand what will happen when you do.";
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Execute this event", 200, this.ss, ref this.OwnBitmap, usex1 + 300, usey1 + 30, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.ExecuteId = this.AddSubPart(ref tsubpart, usex1 + 300, usey1 + 30, 200, 35, 1);
      }
      DrawMod.DrawTextColouredMarc(ref g, "Event Library slot ID:", this.game.MarcFont4, usex1 + 20, usey1 + 80, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, this.game.Data.EventObj[this.LibVarId].LibId.id.ToString(), this.game.MarcFont3, usex1 + 20, usey1 + 100, Color.White);
    }

    private void InfoStringlist(ref Graphics g, int usex1, int usey1)
    {
      DrawMod.DrawBlock(ref g, usex1, usey1, 680, 304, 0, 0, 0, 80);
      DrawMod.DrawTextColouredMarc(ref g, "Table name:", this.game.MarcFont4, usex1 + 20, usey1 + 30, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, this.game.Data.StringListObj[this.LibVarId].Name, this.game.MarcFont3, usex1 + 20, usey1 + 50, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, "Table information:", this.game.MarcFont4, usex1 + 20, usey1 + 85, Color.White);
      SubPartClass tsubpart = (SubPartClass) new TextAreaClass2(this.game, 580, 4, this.game.MarcFont4, this.game.Data.StringListObj[this.LibVarId].Description, 27, ref this.OwnBitmap, usex1 + 20, usey1 + 80);
      this.text1id = this.AddSubPart(ref tsubpart, usex1 + 20, usey1 + 80, 580, 120, 0);
    }

    private void InfoLibrary(ref Graphics g, int usex1, int usey1)
    {
      usex1 = 10;
      DrawMod.DrawBlock(ref g, usex1, usey1, this.game.ScreenWidth - 20, 304, 0, 0, 0, 80);
      DrawMod.DrawTextColouredMarc(ref g, "Name:", this.game.MarcFont4, usex1 + 20, usey1 + 30, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, this.game.Data.LibraryObj[this.LibId].name, this.game.MarcFont3, usex1 + 20, usey1 + 50, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, "Version:", this.game.MarcFont4, usex1 + 20, usey1 + 140, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, this.game.Data.LibraryObj[this.LibId].version.ToString(), this.game.MarcFont3, usex1 + 20, usey1 + 160, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, "By:", this.game.MarcFont4, usex1 + 20, usey1 + 85, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, this.game.Data.LibraryObj[this.LibId].creator, this.game.MarcFont3, usex1 + 20, usey1 + 105, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, "Library information:", this.game.MarcFont4, usex1 + 420, usey1 + 15, Color.White);
      SubPartClass tsubpart = (SubPartClass) new TextAreaClass2(this.game, this.game.ScreenWidth - 460, 13, this.game.MarcFont4, this.game.Data.LibraryObj[this.LibId].information, 17, ref this.OwnBitmap, usex1 + 420, usey1 + 30);
      this.text1id = this.AddSubPart(ref tsubpart, usex1 + 420, usey1 + 30, this.game.ScreenWidth - 440, 240, 0);
    }

    private void InfoHisUnit(ref Graphics g, int usex1, int usey1)
    {
    }

    private void InfoOfficer(ref Graphics g, int usex1, int usey1)
    {
    }

    private void InfoRegime(ref Graphics g, int usex1, int usey1)
    {
      DrawMod.DrawBlock(ref g, usex1, usey1, 680, 304, 0, 0, 0, 80);
      DrawMod.DrawTextColouredMarc(ref g, "Name:", this.game.MarcFont4, usex1 + 20, usey1 + 30, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, this.game.Data.RegimeObj[this.IndId].Name, this.game.MarcFont3, usex1 + 20, usey1 + 50, Color.White);
      int hqSpriteNr = this.game.Data.RegimeObj[this.IndId].HQSpriteNr;
      DrawMod.DrawTextColouredMarc(ref g, "HQ Graphic:", this.game.MarcFont4, usex1 + 20, usey1 + 90, Color.White);
      DrawMod.DrawBlock(ref g, usex1 + 20, usey1 + 110, 76, 76, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210);
      if (hqSpriteNr > -1)
      {
        if (Strings.InStr(BitmapStore.GetFileName(hqSpriteNr), "systemgraphics/trans.bmp") > 0)
        {
          DrawMod.DrawTextColouredMarcCenter(ref g, "No Graphic", this.game.MarcFont4, usex1 + 20 + 39, usey1 + 110 + 40, Color.Black);
        }
        else
        {
          ref Graphics local1 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(hqSpriteNr, 1);
          ref Bitmap local2 = ref bitmap;
          Rectangle srcrect = new Rectangle(0, 0, BitmapStore.GetWidth(hqSpriteNr, 1), BitmapStore.Getheight(hqSpriteNr, 1));
          Rectangle destrect = new Rectangle(usex1 + 20, usey1 + 110, 76, 76);
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
          DrawMod.DrawTextColouredMarcCenter(ref g, BitmapStore.GetWidth(hqSpriteNr, 1).ToString() + "x" + BitmapStore.Getheight(hqSpriteNr, 1).ToString(), this.game.MarcFont4, usex1 + 20 + 38, usey1 + 110 + 52, Color.Salmon);
        }
      }
      DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, usex1 + 20, usey1 + 110, 76, 76, -1, -1);
      DrawMod.DrawTextColouredMarc(ref g, "People:", this.game.MarcFont4, usex1 + 20, usey1 + 200, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.IndId].People].Name, this.game.MarcFont3, usex1 + 20, usey1 + 220, Color.White);
    }

    private void InfoPeople(ref Graphics g, int usex1, int usey1)
    {
      DrawMod.DrawBlock(ref g, usex1, usey1, 680, 304, 0, 0, 0, 80);
      DrawMod.DrawTextColouredMarc(ref g, "Name:", this.game.MarcFont4, usex1 + 20, usey1 + 30, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, this.game.Data.PeopleObj[this.IndId].Name, this.game.MarcFont3, usex1 + 20, usey1 + 50, Color.White);
      int sidewaysSpriteId = this.game.Data.PeopleObj[this.IndId].SidewaysSpriteID;
      DrawMod.DrawTextColouredMarc(ref g, "Sideways Graphic:", this.game.MarcFont4, usex1 + 20, usey1 + 90, Color.White);
      DrawMod.DrawBlock(ref g, usex1 + 20, usey1 + 110, 140, 80, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210);
      if (sidewaysSpriteId > -1)
      {
        if (Strings.InStr(BitmapStore.GetFileName(sidewaysSpriteId), "systemgraphics/trans.bmp") > 0)
        {
          DrawMod.DrawTextColouredMarcCenter(ref g, "No Graphic", this.game.MarcFont4, usex1 + 20 + 70, usey1 + 110 + 40, Color.Black);
        }
        else
        {
          ref Graphics local1 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(sidewaysSpriteId);
          ref Bitmap local2 = ref bitmap;
          Rectangle srcrect = new Rectangle(0, 0, BitmapStore.GetWidth(sidewaysSpriteId), BitmapStore.Getheight(sidewaysSpriteId));
          Rectangle destrect = new Rectangle(usex1 + 20, usey1 + 110, 140, 80);
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
          DrawMod.DrawTextColouredMarcCenter(ref g, BitmapStore.GetWidth(sidewaysSpriteId).ToString() + "x" + BitmapStore.Getheight(sidewaysSpriteId).ToString(), this.game.MarcFont4, usex1 + 20 + 70, usey1 + 110 + 55, Color.Salmon);
        }
      }
      DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, usex1 + 20, usey1 + 110, 140, 80, -1, -1);
    }

    private void InfoEventPic(ref Graphics g, int usex1, int usey1)
    {
      DrawMod.DrawBlock(ref g, usex1, usey1, 680, 304, 0, 0, 0, 80);
      if (this.IndId > -1)
      {
        string str = "" + ", id=" + this.game.Data.eventPicLibId[this.IndId].id.ToString() + ", slot=" + this.IndId.ToString();
        DrawMod.DrawTextColouredMarc(ref g, "Name:", this.game.MarcFont4, usex1 + 20, usey1 + 30, Color.White);
        DrawMod.DrawTextColouredMarc(ref g, this.game.Data.EventPicName[this.IndId] + str, this.game.MarcFont4, usex1 + 20, usey1 + 50, Color.White);
        int nr = this.game.Data.EventPicNr[this.IndId];
        DrawMod.DrawTextColouredMarc(ref g, "Graphic:", this.game.MarcFont4, usex1 + 20, usey1 + 90, Color.White);
        if (nr > -1 & !Information.IsNothing((object) BitmapStore.GetBitmap(nr)))
        {
          ref Graphics local1 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(nr);
          ref Bitmap local2 = ref bitmap;
          Rectangle srcrect = new Rectangle(0, 0, BitmapStore.GetWidth(nr), BitmapStore.Getheight(nr));
          Rectangle destrect = new Rectangle(usex1 + 20, usey1 + 110, 362, 175);
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
          DrawMod.DrawTextColouredMarcCenter(ref g, BitmapStore.GetWidth(nr).ToString() + "x" + BitmapStore.Getheight(nr).ToString(), this.game.MarcFont4, usex1 + 20 + 180, usey1 + 110 + 90, Color.Salmon);
        }
        DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, usex1 + 20, usey1 + 110, 362, 175, -1, -1);
      }
      else
        DrawMod.DrawTextColouredMarc(ref g, "No specific event picture selected", this.game.MarcFont4, usex1 + 20, usey1 + 30, Color.White);
      if (this.LibId != -1)
        return;
      if (this.IndId > -1)
      {
        this.ss = "Click to reload image used for this Event Pic.";
        SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Change Event Pic", 170, this.ss, ref this.OwnBitmap, usex1 + 490, usey1 + 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.reloadEventPic = this.AddSubPart(ref tsubpart1, usex1 + 490, usey1 + 40, 170, 35, 1);
        this.ss = "Click to remove this Event Pic.";
        SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Remove Event Pic", 170, this.ss, ref this.OwnBitmap, usex1 + 490, usey1 + 90, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.removeEventPic = this.AddSubPart(ref tsubpart2, usex1 + 490, usey1 + 90, 170, 35, 1);
      }
      this.ss = "Click to reload image used for this Event Pic.";
      SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Add Event Pic", 170, this.ss, ref this.OwnBitmap, usex1 + 490, 80, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.loadEventPic = this.AddSubPart(ref tsubpart, usex1 + 490, 80, 170, 35, 1);
    }

    private void InfoCommander(ref Graphics g, int usex1, int usey1)
    {
      SizeF sizeF1 = new SizeF();
      DrawMod.DrawBlock(ref g, usex1, usey1, 680, 304, 0, 0, 0, 80);
      int num1 = usex1 + 25 - 110;
      int num2 = usey1 + 25 - 5;
      int indId = this.IndId;
      DrawMod.DrawTextColouredMarc(ref g, "Deckcards:", this.game.MarcFont4, num1 + 110, usey1 + 160, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, (this.game.Data.HistoricalUnitObj[indId].DeckCardCounter + 1).ToString(), this.game.MarcFont4, num1 + 110, usey1 + 185, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, "Statistics:", this.game.MarcFont4, num1 + 110, usey1 + 20, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, "Portrait:", this.game.MarcFont4, num1 + 460, usey1 + 20, Color.White);
      if (this.game.Data.HistoricalUnitObj[indId].CommanderSpriteID > -1)
      {
        int commanderSpriteId = this.game.Data.HistoricalUnitObj[indId].CommanderSpriteID;
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(commanderSpriteId);
        ref Bitmap local2 = ref bitmap;
        int x = num1 + 460;
        int y = num2 + 35;
        DrawMod.DrawSimple(ref local1, ref local2, x, y);
        DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, num1 + 460, num2 + 35, 177, 194, -1, -1);
        DrawMod.DrawTextColouredMarcCenter(ref g, BitmapStore.GetWidth(commanderSpriteId).ToString() + "x" + BitmapStore.Getheight(commanderSpriteId).ToString(), this.game.MarcFont4, num1 + 460 + 85, num2 + 182, Color.Salmon);
      }
      else
      {
        DrawMod.DrawBlock(ref g, num1 + 460, num2 + 35, 177, 194, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210);
        DrawMod.DrawTextColouredMarcCenter(ref g, "No Graphic", this.game.MarcFont4, num1 + 460 + 85, num2 + 35 + 92, Color.Black);
        DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, num1 + 460, num2 + 35, 177, 194, -1, -1);
      }
      TextAreaClass2 textAreaClass2 = new TextAreaClass2(this.game, 340, 4, this.game.MarcFont13, "", 12, ref this.OwnBitmap, num1 + 110, num2 + 22, true);
      ref Graphics local3 = ref g;
      Bitmap bitmap1 = textAreaClass2.Paint();
      ref Bitmap local4 = ref bitmap1;
      int x1 = num1 + 110;
      int y1 = num2 + 22;
      DrawMod.DrawSimple(ref local3, ref local4, x1, y1);
      Rectangle trect1 = new Rectangle(num1 + 105, num2 + 34, 280, 45);
      this.AddMouse(ref trect1, "OFFICER INFO", "Click to get full stats and biography", 50);
      DrawMod.DrawTextColouredMarc(ref g, this.game.Data.HistoricalUnitObj[indId].CommanderName, this.game.MarcFont6, num1 + 125, num2 + 44, Color.White);
      int num3 = 110;
      DrawMod.DrawBlock(ref g, num1 + num3, num2 + 67, 247, 2, (int) this.game.MarcCol3.R, (int) this.game.MarcCol3.G, (int) this.game.MarcCol3.B, (int) byte.MaxValue);
      for (; num3 < 365; num3 += 35)
      {
        DrawMod.DrawBlockGradient2(ref g, num1 + num3, num2 + 68, 2, 41, this.game.MarcCol3, this.game.MarcCol2);
        int index;
        if (this.game.Data.HistoricalUnitObj[indId].HisVarCount >= index)
        {
          string str = Strings.Trim(Conversion.Str((object) this.game.Data.HistoricalUnitObj[indId].HisVarValue[index]));
          SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont8b);
          int x2 = (int) Math.Round((double) ((float) (num1 + num3 + 18) - sizeF2.Width / 2f));
          DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont8b, x2, num2 + 90, Color.White);
          Bitmap bitmap2;
          if (this.game.Data.HistoricalUnitObj[indId].HisVarSmall[index] > -1)
          {
            ref Graphics local5 = ref g;
            bitmap2 = BitmapStore.GetBitmap(this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[indId].HisVarSmall[index]]);
            ref Bitmap local6 = ref bitmap2;
            int x3 = x2;
            int y2 = num2 + 71;
            DrawMod.DrawSimple(ref local5, ref local6, x3, y2);
          }
          else if (this.game.Data.HistoricalUnitObj[indId].HisVarNato[index] > -1)
          {
            ref Graphics local7 = ref g;
            bitmap2 = BitmapStore.GetBitmap(this.game.NATO[this.game.Data.HistoricalUnitObj[indId].HisVarNato[index]]);
            ref Bitmap local8 = ref bitmap2;
            int x4 = x2;
            int y3 = num2 + 71;
            DrawMod.DrawSimple(ref local7, ref local8, x4, y3);
          }
          trect1 = new Rectangle(x2, num2 + 71, 35, 50);
          Rectangle trect2 = trect1;
          this.AddMouse(ref trect2, "", this.game.Data.TempString[1200 + this.game.Data.HistoricalUnitObj[indId].HisVarType[index]]);
        }
        ++index;
      }
    }

    private void InfoSmallGraphic(ref Graphics g, int usex1, int usey1)
    {
      int num = usex1;
      if (this.IndId > -1)
      {
        DrawMod.DrawBlock(ref g, usex1, usey1, 680, 304, 0, 0, 0, 80);
        DrawMod.DrawTextColouredMarc(ref g, "Name:", this.game.MarcFont4, usex1 + 20, usey1 + 30, Color.White);
        DrawMod.DrawTextColouredMarc(ref g, this.game.Data.SmallPicName[this.IndId], this.game.MarcFont3, usex1 + 20, usey1 + 50, Color.White);
        int nr = this.game.Data.SmallPicNr[this.IndId];
        if (nr > -1)
        {
          DrawMod.DrawTextColouredMarc(ref g, "Big version:", this.game.MarcFont4, usex1 + 20, usey1 + 90, Color.White);
          DrawMod.DrawBlock(ref g, usex1 + 20, usey1 + 110, BitmapStore.GetWidth(nr, 1), BitmapStore.Getheight(nr, 1), (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210);
          Bitmap bitmap;
          Rectangle rectangle1;
          Rectangle rectangle2;
          if (Strings.InStr(BitmapStore.GetFileName(nr), "systemgraphics/trans.bmp") > 0)
          {
            DrawMod.DrawTextColouredMarcCenter(ref g, "No Graphic", this.game.MarcFont4, usex1 + 20 + 70, usey1 + 110 + 40, Color.Black);
          }
          else
          {
            ref Graphics local1 = ref g;
            bitmap = BitmapStore.GetBitmap(nr, 1);
            ref Bitmap local2 = ref bitmap;
            rectangle1 = new Rectangle(0, 0, BitmapStore.GetWidth(nr, 1), BitmapStore.Getheight(nr, 1));
            Rectangle srcrect = rectangle1;
            rectangle2 = new Rectangle(usex1 + 20, usey1 + 110, BitmapStore.GetWidth(nr, 1), BitmapStore.Getheight(nr, 1));
            Rectangle destrect = rectangle2;
            DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
            DrawMod.DrawTextColouredMarcCenter(ref g, BitmapStore.GetWidth(nr, 1).ToString() + "x" + BitmapStore.Getheight(nr, 1).ToString(), this.game.MarcFont4, (int) Math.Round((double) (usex1 + 20) + (double) BitmapStore.GetWidth(nr, 1) / 2.0), (int) Math.Round((double) (usey1 + 110) + (double) BitmapStore.Getheight(nr, 1) / 2.0), Color.Salmon);
          }
          DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, usex1 + 20, usey1 + 110, BitmapStore.GetWidth(nr, 1), BitmapStore.Getheight(nr, 1), -1, -1);
          usex1 += 140;
          DrawMod.DrawTextColouredMarc(ref g, "Reg version:", this.game.MarcFont4, usex1 + 20, usey1 + 90, Color.White);
          DrawMod.DrawBlock(ref g, usex1 + 20, usey1 + 110, BitmapStore.GetWidth(nr), BitmapStore.Getheight(nr), (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210);
          if (Strings.InStr(BitmapStore.GetFileName(nr), "systemgraphics/trans.bmp") > 0)
          {
            DrawMod.DrawTextColouredMarcCenter(ref g, "No Graphic", this.game.MarcFont4, usex1 + 20 + 70, usey1 + 110 + 40, Color.Black);
          }
          else
          {
            ref Graphics local3 = ref g;
            bitmap = BitmapStore.GetBitmap(nr);
            ref Bitmap local4 = ref bitmap;
            rectangle2 = new Rectangle(0, 0, BitmapStore.GetWidth(nr), BitmapStore.Getheight(nr));
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(usex1 + 20, usey1 + 110, BitmapStore.GetWidth(nr), BitmapStore.Getheight(nr));
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
            DrawMod.DrawTextColouredMarcCenter(ref g, BitmapStore.GetWidth(nr).ToString() + "x" + BitmapStore.Getheight(nr).ToString(), this.game.MarcFont4, (int) Math.Round((double) (usex1 + 20) + (double) BitmapStore.GetWidth(nr) / 2.0), (int) Math.Round((double) (usey1 + 110) + (double) BitmapStore.Getheight(nr) / 2.0), Color.Salmon);
          }
          DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, usex1 + 20, usey1 + 110, BitmapStore.GetWidth(nr), BitmapStore.Getheight(nr), -1, -1);
          usex1 += 100;
          DrawMod.DrawTextColouredMarc(ref g, "Small version:", this.game.MarcFont4, usex1 + 20, usey1 + 90, Color.White);
          DrawMod.DrawBlock(ref g, usex1 + 20, usey1 + 110, BitmapStore.GetWidth(nr, -1), BitmapStore.Getheight(nr, -1), (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210);
          if (Strings.InStr(BitmapStore.GetFileName(nr), "systemgraphics/trans.bmp") > 0)
          {
            DrawMod.DrawTextColouredMarcCenter(ref g, "No Graphic", this.game.MarcFont4, usex1 + 20 + 70, usey1 + 110 + 40, Color.Black);
          }
          else
          {
            ref Graphics local5 = ref g;
            bitmap = BitmapStore.GetBitmap(nr, -1);
            ref Bitmap local6 = ref bitmap;
            rectangle2 = new Rectangle(0, 0, BitmapStore.GetWidth(nr, -1), BitmapStore.Getheight(nr, -1));
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(usex1 + 20, usey1 + 110, BitmapStore.GetWidth(nr, -1), BitmapStore.Getheight(nr, -1));
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect, destrect);
            DrawMod.DrawTextColouredMarcCenter(ref g, BitmapStore.GetWidth(nr, -1).ToString() + "x" + BitmapStore.Getheight(nr, -1).ToString(), this.game.MarcFont4, (int) Math.Round((double) (usex1 + 20) + (double) BitmapStore.GetWidth(nr, -1) / 2.0), usey1 + 110 + BitmapStore.Getheight(nr, -1) + 4, Color.Salmon);
          }
          DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, usex1 + 20, usey1 + 110, BitmapStore.GetWidth(nr, -1), BitmapStore.Getheight(nr, -1), -1, -1);
        }
        else
          DrawMod.DrawTextColouredMarcCenter(ref g, "No Graphic", this.game.MarcFont4, usex1 + 20 + 37, usey1 + 110 + 40, Color.Black);
      }
      else
      {
        DrawMod.DrawBlock(ref g, usex1, usey1, 680, 304, 0, 0, 0, 80);
        DrawMod.DrawTextColouredMarc(ref g, "No specific small graphic selected", this.game.MarcFont4, usex1 + 20, usey1 + 30, Color.White);
      }
      usex1 = num;
      if (this.LibId != -1)
        return;
      if (this.IndId > -1)
      {
        this.ss = "Click to reload image used for this Small Graphic.";
        SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Change SmallGfx", 170, this.ss, ref this.OwnBitmap, usex1 + 490, usey1 + 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.reloadSmallGfx = this.AddSubPart(ref tsubpart1, usex1 + 490, usey1 + 40, 170, 35, 1);
        this.ss = "Click to remove this Small Graphic.";
        SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Remove SmallGfx", 170, this.ss, ref this.OwnBitmap, usex1 + 490, usey1 + 90, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.removeSmallGfx = this.AddSubPart(ref tsubpart2, usex1 + 490, usey1 + 90, 170, 35, 1);
      }
      this.ss = "Click to reload image used for this Small Graphic.";
      SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Add SmallGfx", 170, this.ss, ref this.OwnBitmap, usex1 + 490, 80, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.loadSmallGfx = this.AddSubPart(ref tsubpart, usex1 + 490, 80, 170, 35, 1);
    }

    private void InfoHisModel(ref Graphics g, int usex1, int usey1)
    {
      DrawMod.DrawBlock(ref g, usex1, usey1, 680, 304, 0, 0, 0, 80);
      DrawMod.DrawTextColouredMarc(ref g, "Name:", this.game.MarcFont4, usex1 + 20, usey1 + 30, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, this.game.Data.HistoricalUnitObj[this.IndId].Name, this.game.MarcFont3, usex1 + 20, usey1 + 50, Color.White);
      int nr = -1;
      if (this.game.Data.HistoricalUnitObj[this.IndId].SmallGfx > -1 & this.game.Data.HistoricalUnitObj[this.IndId].SmallGfx <= this.game.Data.SmallPicCounter)
        nr = this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[this.IndId].SmallGfx];
      else if (this.game.Data.HistoricalUnitObj[this.IndId].Counter > 0)
        nr = this.game.NATO[this.game.Data.HistoricalUnitObj[this.IndId].Counter];
      DrawMod.DrawTextColouredMarc(ref g, "His Unit Graphic:", this.game.MarcFont4, usex1 + 20, usey1 + 90, Color.White);
      DrawMod.DrawBlock(ref g, usex1 + 20, usey1 + 110, 76, 76, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210);
      if (nr > -1)
      {
        if (Strings.InStr(BitmapStore.GetFileName(nr), "systemgraphics/trans.bmp") > 0)
        {
          DrawMod.DrawTextColouredMarcCenter(ref g, "No Graphic", this.game.MarcFont4, usex1 + 20 + 70, usey1 + 110 + 40, Color.Black);
        }
        else
        {
          ref Graphics local1 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(nr, 1);
          ref Bitmap local2 = ref bitmap;
          Rectangle srcrect = new Rectangle(0, 0, BitmapStore.GetWidth(nr, 1), BitmapStore.Getheight(nr, 1));
          Rectangle destrect = new Rectangle(usex1 + 20, usey1 + 110, 76, 76);
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
          DrawMod.DrawTextColouredMarcCenter(ref g, BitmapStore.GetWidth(nr, 1).ToString() + "x" + BitmapStore.Getheight(nr, 1).ToString(), this.game.MarcFont4, usex1 + 20 + 38, usey1 + 110 + 52, Color.Salmon);
        }
      }
      else
        DrawMod.DrawTextColouredMarcCenter(ref g, "No Graphic", this.game.MarcFont4, usex1 + 20 + 37, usey1 + 110 + 40, Color.Black);
      DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, usex1 + 20, usey1 + 110, 76, 76, -1, -1);
    }

    private void InfoSFType(ref Graphics g, int usex1, int usey1)
    {
      int num = usex1;
      DrawMod.DrawBlock(ref g, usex1, usey1, 680, 304, 0, 0, 0, 80);
      DrawMod.DrawTextColouredMarc(ref g, "Name:", this.game.MarcFont4, usex1 + 20, usey1 + 30, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, this.game.Data.SFTypeObj[this.IndId].Name, this.game.MarcFont3, usex1 + 20, usey1 + 50, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, "Lib ID:", this.game.MarcFont4, usex1 + 320, usey1 + 30, Color.White);
      DrawMod.DrawTextColouredMarc(ref g, this.game.Data.SFTypeObj[this.IndId].LibId.id.ToString(), this.game.MarcFont3, usex1 + 320, usey1 + 50, Color.White);
      int sidewaysSpriteId = this.game.Data.SFTypeObj[this.IndId].SidewaysSpriteID;
      DrawMod.DrawTextColouredMarc(ref g, "Sideways graphic:", this.game.MarcFont4, usex1 + 20, usey1 + 90, Color.White);
      DrawMod.DrawBlock(ref g, usex1 + 20, usey1 + 110, 140, 100, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210);
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (sidewaysSpriteId > -1)
      {
        if (Strings.InStr(BitmapStore.GetFileName(sidewaysSpriteId), "systemgraphics/trans.bmp") > 0)
        {
          DrawMod.DrawTextColouredMarcCenter(ref g, "No Graphic", this.game.MarcFont4, usex1 + 20 + 70, usey1 + 110 + 40, Color.Black);
        }
        else
        {
          ref Graphics local1 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(sidewaysSpriteId);
          ref Bitmap local2 = ref bitmap;
          rectangle1 = new Rectangle(0, 0, BitmapStore.GetWidth(sidewaysSpriteId), BitmapStore.Getheight(sidewaysSpriteId));
          Rectangle srcrect = rectangle1;
          rectangle2 = new Rectangle(usex1 + 20, usey1 + 110, 140, 100);
          Rectangle destrect = rectangle2;
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
          DrawMod.DrawTextColouredMarcCenter(ref g, BitmapStore.GetWidth(sidewaysSpriteId).ToString() + "x" + BitmapStore.Getheight(sidewaysSpriteId).ToString(), this.game.MarcFont4, usex1 + 20 + 70, usey1 + 110 + 5, Color.Salmon);
        }
      }
      DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, usex1 + 20, usey1 + 110, 140, 100, -1, -1);
      int picSpriteId = this.game.Data.SFTypeObj[this.IndId].PicSpriteID;
      usex1 += 180;
      DrawMod.DrawTextColouredMarc(ref g, "Illustration graphic:", this.game.MarcFont4, usex1 + 20, usey1 + 90, Color.White);
      DrawMod.DrawBlock(ref g, usex1 + 20, usey1 + 110, 140, 100, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210);
      if (picSpriteId > -1)
      {
        if (Strings.InStr(BitmapStore.GetFileName(picSpriteId), "systemgraphics/trans.bmp") > 0)
        {
          DrawMod.DrawTextColouredMarcCenter(ref g, "No Graphic", this.game.MarcFont4, usex1 + 20 + 70, usey1 + 110 + 40, Color.Black);
        }
        else
        {
          ref Graphics local3 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(picSpriteId);
          ref Bitmap local4 = ref bitmap;
          rectangle2 = new Rectangle(0, 0, BitmapStore.GetWidth(picSpriteId), BitmapStore.Getheight(picSpriteId));
          Rectangle srcrect = rectangle2;
          rectangle1 = new Rectangle(usex1 + 20, usey1 + 110, 140, 100);
          Rectangle destrect = rectangle1;
          DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
          DrawMod.DrawTextColouredMarcCenter(ref g, BitmapStore.GetWidth(picSpriteId).ToString() + "x" + BitmapStore.Getheight(picSpriteId).ToString(), this.game.MarcFont4, usex1 + 20 + 70, usey1 + 110 + 5, Color.Salmon);
        }
      }
      DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, usex1 + 20, usey1 + 110, 140, 100, -1, -1);
      usey1 += 190;
      usex1 = num;
      DrawMod.DrawTextColouredMarc(ref g, "ReinfType#1:", this.game.MarcFont4, usex1 + 20, usey1 + 30, Color.White);
      string tstring = "none";
      int reinforcementType = this.game.Data.SFTypeObj[this.IndId].ReinforcementType;
      if (reinforcementType > -1)
      {
        tstring = "'" + this.game.Data.ReinfName[reinforcementType] + "'";
        if (this.game.Data.ReinfLibId[reinforcementType].libSlot > -1)
          tstring = tstring + " (libslot: " + this.game.Data.ReinfLibId[reinforcementType].libSlot.ToString() + ", libid: " + this.game.Data.ReinfLibId[reinforcementType].id.ToString() + ")";
      }
      DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont3, usex1 + 20, usey1 + 50, Color.White);
    }

    private void DoStuff()
    {
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      int num2 = this.game.ScreenHeight - 768 - 30;
      if (num2 < 0)
        num2 = 0;
      if (this.text1id > 0)
        this.RemoveSubPart(this.text1id);
      if (this.text2id > 0)
        this.RemoveSubPart(this.text2id);
      if (this.ChangeValId > 0)
        this.RemoveSubPart(this.ChangeValId);
      if (this.ExecuteId > 0)
        this.RemoveSubPart(this.ExecuteId);
      if (this.loadSmallGfx > 0)
        this.RemoveSubPart(this.loadSmallGfx);
      if (this.loadEventPic > 0)
        this.RemoveSubPart(this.loadEventPic);
      if (this.reloadSmallGfx > 0)
        this.RemoveSubPart(this.reloadSmallGfx);
      if (this.reloadEventPic > 0)
        this.RemoveSubPart(this.reloadEventPic);
      if (this.removeSmallGfx > 0)
        this.RemoveSubPart(this.removeSmallGfx);
      if (this.removeEventPic > 0)
        this.RemoveSubPart(this.removeEventPic);
      if (this.loadVarsId > 0)
        this.RemoveSubPart(this.loadVarsId);
      if (this.saveId > 0)
      {
        this.RemoveSubPart(this.saveId);
        this.saveId = 0;
      }
      if (this.save2id > 0)
      {
        this.RemoveSubPart(this.save2id);
        this.save2id = 0;
      }
      if (this.save3id > 0)
      {
        this.RemoveSubPart(this.save3id);
        this.save3id = 0;
      }
      if (this.save4id > 0)
      {
        this.RemoveSubPart(this.save4id);
        this.save4id = 0;
      }
      if (this.TaId > 0)
        this.RemoveSubPart(this.TaId);
      if (this.importId > 0)
        this.RemoveSubPart(this.importId);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      graphics.TextContrast = 1;
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 50, -1);
      int num3 = 10 + num1 + 240;
      int num4 = num3 + 320 + 40;
      int num5 = 328 + num2;
      int num6 = num5 + num2;
      if (this.LibVarId > -1)
      {
        if (this.CatId < 100)
          this.InfoLibVar(ref graphics, num3, num5);
        else if (this.CatId == 101)
        {
          if (this.LibVarId > -1)
          {
            this.InfoEvent(ref graphics, num3, num5);
          }
          else
          {
            DrawMod.DrawBlock(ref graphics, num3, num5, 680, 304, 0, 0, 0, 80);
            DrawMod.DrawTextColouredMarc(ref graphics, "No specific event selected", this.game.MarcFont4, num3 + 20, num5 + 30, Color.White);
          }
        }
        else if (this.CatId == 109)
        {
          if (this.LibVarId > -1)
          {
            this.InfoEvent(ref graphics, num3, num5);
          }
          else
          {
            DrawMod.DrawBlock(ref graphics, num3, num5, 680, 304, 0, 0, 0, 80);
            DrawMod.DrawTextColouredMarc(ref graphics, "No specific event selected", this.game.MarcFont4, num3 + 20, num5 + 30, Color.White);
          }
        }
        else if (this.CatId == 108)
        {
          if (this.LibVarId > -1)
          {
            this.InfoStringlist(ref graphics, num3, num5);
          }
          else
          {
            DrawMod.DrawBlock(ref graphics, num3, num5, 680, 304, 0, 0, 0, 80);
            DrawMod.DrawTextColouredMarc(ref graphics, "No specific table selected", this.game.MarcFont4, num3 + 20, num5 + 30, Color.White);
          }
        }
      }
      else if (this.CatId == 102)
      {
        if (this.IndId > -1)
        {
          this.InfoSFType(ref graphics, num3, num5);
        }
        else
        {
          DrawMod.DrawBlock(ref graphics, num3, num5, 680, 304, 0, 0, 0, 80);
          DrawMod.DrawTextColouredMarc(ref graphics, "No specific trooptype selected", this.game.MarcFont4, num3 + 20, num5 + 30, Color.White);
        }
      }
      else if (this.CatId > 0 & this.CatId <= 20)
      {
        if (this.LibVarId <= -1)
        {
          DrawMod.DrawBlock(ref graphics, num3, num5, 680, 304, 0, 0, 0, 80);
          DrawMod.DrawTextColouredMarc(ref graphics, "No specific libvar selected", this.game.MarcFont4, num3 + 20, num5 + 30, Color.White);
        }
      }
      else if (this.CatId == 101)
      {
        if (this.LibVarId <= -1)
        {
          DrawMod.DrawBlock(ref graphics, num3, num5, 680, 304, 0, 0, 0, 80);
          DrawMod.DrawTextColouredMarc(ref graphics, "No specific event selected", this.game.MarcFont4, num3 + 20, num5 + 30, Color.White);
        }
      }
      else if (this.CatId == 112)
      {
        if (this.LibVarId <= -1)
        {
          DrawMod.DrawBlock(ref graphics, num3, num5, 680, 304, 0, 0, 0, 80);
          DrawMod.DrawTextColouredMarc(ref graphics, "Detailed info still to be provided by VR coding.", this.game.MarcFont4, num3 + 20, num5 + 30, Color.White);
        }
      }
      else if (this.CatId == 109)
      {
        if (this.LibVarId <= -1)
        {
          DrawMod.DrawBlock(ref graphics, num3, num5, 680, 304, 0, 0, 0, 80);
          DrawMod.DrawTextColouredMarc(ref graphics, "No specific event selected", this.game.MarcFont4, num3 + 20, num5 + 30, Color.White);
        }
      }
      else if (this.CatId == 104)
      {
        if (this.IndId > -1)
        {
          DrawMod.DrawBlock(ref graphics, num3, num5, 680, 304, 0, 0, 0, 80);
          DrawMod.DrawTextColouredMarc(ref graphics, "Detailed info still to be provided by VR coding.", this.game.MarcFont4, num3 + 20, num5 + 30, Color.White);
        }
        else
        {
          DrawMod.DrawBlock(ref graphics, num3, num5, 680, 304, 0, 0, 0, 80);
          DrawMod.DrawTextColouredMarc(ref graphics, "No specific historical unit selected", this.game.MarcFont4, num3 + 20, num5 + 30, Color.White);
        }
      }
      else if (this.CatId == 108)
      {
        if (this.LibVarId <= -1)
        {
          DrawMod.DrawBlock(ref graphics, num3, num5, 680, 304, 0, 0, 0, 80);
          DrawMod.DrawTextColouredMarc(ref graphics, "No specific table selected", this.game.MarcFont4, num3 + 20, num5 + 30, Color.White);
        }
      }
      else if (this.CatId == 110)
      {
        if (this.IndId >= -1)
          this.InfoEventPic(ref graphics, num3, num5);
      }
      else if (this.CatId == 111)
      {
        if (this.IndId >= -1)
          this.InfoSmallGraphic(ref graphics, num3, num5);
      }
      else if (this.CatId == 103)
      {
        if (this.IndId > -1)
        {
          this.InfoHisModel(ref graphics, num3, num5);
        }
        else
        {
          DrawMod.DrawBlock(ref graphics, num3, num5, 680, 304, 0, 0, 0, 80);
          DrawMod.DrawTextColouredMarc(ref graphics, "No specific historical model selected", this.game.MarcFont4, num3 + 20, num5 + 30, Color.White);
        }
      }
      else if (this.CatId == 105)
      {
        if (this.IndId > -1)
        {
          this.InfoCommander(ref graphics, num3, num5);
        }
        else
        {
          DrawMod.DrawBlock(ref graphics, num3, num5, 680, 304, 0, 0, 0, 80);
          DrawMod.DrawTextColouredMarc(ref graphics, "No specific commander selected", this.game.MarcFont4, num3 + 20, num5 + 30, Color.White);
        }
      }
      else if (this.CatId == 106)
      {
        if (this.IndId > -1)
        {
          this.InfoPeople(ref graphics, num3, num5);
        }
        else
        {
          DrawMod.DrawBlock(ref graphics, num3, num5, 680, 304, 0, 0, 0, 80);
          DrawMod.DrawTextColouredMarc(ref graphics, "No specific people selected", this.game.MarcFont4, num3 + 20, num5 + 30, Color.White);
        }
      }
      else if (this.CatId == 107)
      {
        if (this.IndId > -1)
        {
          this.InfoRegime(ref graphics, num3, num5);
        }
        else
        {
          DrawMod.DrawBlock(ref graphics, num3, num5, 680, 304, 0, 0, 0, 80);
          DrawMod.DrawTextColouredMarc(ref graphics, "No specific regime selected", this.game.MarcFont4, num3 + 20, num5 + 30, Color.White);
        }
      }
      else if (this.LibId > -1)
      {
        this.InfoLibrary(ref graphics, num3, num5);
      }
      else
      {
        DrawMod.DrawBlock(ref graphics, num3, num5, 680, 304, 0, 0, 0, 50);
        DrawMod.DrawTextColouredMarc(ref graphics, "No library selected", this.game.MarcFont4, num3 + 20, num5 + 30, Color.White);
      }
      if (this.LibListId > 0)
        this.RemoveSubPart(this.LibListId);
      if (this.AddLibEventId > 0)
        this.RemoveSubPart(this.AddLibEventId);
      if (this.RemoveLibEventId > 0)
        this.RemoveSubPart(this.RemoveLibEventId);
      if (this.RemoveLibEventIdb > 0)
        this.RemoveSubPart(this.RemoveLibEventIdb);
      if (this.AddLibTroopsId > 0)
        this.RemoveSubPart(this.AddLibTroopsId);
      this.LibListObj = new ListClass();
      int num7 = 0;
      int tlistselect1 = -1;
      this.LibListObj.add(Conversion.Str((object) -1) + ") ** No library **", -2);
      if (this.LibId == -1)
        tlistselect1 = 0;
      int libraryCounter = this.game.Data.LibraryCounter;
      for (int index = 0; index <= libraryCounter; ++index)
      {
        ++num7;
        this.LibListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.LibraryObj[index].name, index);
        if (this.LibId == index)
          tlistselect1 = num7;
      }
      if (tlistselect1 == -1)
        this.LibId = -1;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(this.LibListObj, 16, (int) Math.Round(200.0 + (double) num1 / 2.0), tlistselect1, this.game, true, "Libraries", false, tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: ((int) Math.Round(10.0 + (double) num1 / 2.0)), bby: 72, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
      this.LibListId = this.AddSubPart(ref tsubpart1, (int) Math.Round(10.0 + (double) num1 / 2.0), 72, (int) Math.Round(200.0 + (double) num1 / 2.0), 408, 0);
      this.ss = "Click to load a library compatible with the current ruleset";
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Load library", 200, this.ss, ref this.OwnBitmap, num1 + 10, 486, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.AddLibEventId = this.AddSubPart(ref tsubpart2, num1 + 10, 486, 200, 35, 1);
      if (this.LibId > -1)
      {
        DependencyClass dependencyClass1 = new DependencyClass();
        DependencyClass dependencyClass2 = this.game.HandyFunctionsObj.Libraries_CheckDependency(ref this.game.Data, this.LibId, false);
        if (dependencyClass2.ok)
        {
          this.ss = "Click to remove library";
          SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Remove library", 200, this.ss, ref this.OwnBitmap, num1 + 10, 526, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.RemoveLibEventId = this.AddSubPart(ref tsubpart3, num1 + 10, 526, 200, 35, 1);
        }
        else
        {
          this.ss = dependencyClass2.text;
          SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Remove library", 200, this.ss, ref this.OwnBitmap, num1 + 10, 526, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.RemoveLibEventIdb = this.AddSubPart(ref tsubpart4, num1 + 10, 526, 200, 35, 1);
        }
        if (this.game.SuperAdminRights)
        {
          this.ss = "Click to load a the libvar settings from selected library in another scenario. Expert use advise. ";
          SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("Load libvars", 200, this.ss, ref this.OwnBitmap, num1 + 10, 566, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.loadVarsId = this.AddSubPart(ref tsubpart5, num1 + 10, 566, 200, 35, 1);
        }
      }
      else
      {
        this.ss = "No library selected";
        SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("Remove library", 200, this.ss, ref this.OwnBitmap, num1 + 10, 526, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RemoveLibEventIdb = this.AddSubPart(ref tsubpart6, num1 + 10, 526, 200, 35, 1);
      }
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
      for (int index = 0; index <= historicalUnitCounter1; ++index)
      {
        if (this.game.Data.HistoricalUnitObj[index].CommanderName.Length > 1)
        {
          if (this.game.Data.HistoricalUnitObj[index].LibId.libSlot == this.LibId)
            flag1 = true;
        }
        else if (this.game.Data.HistoricalUnitObj[index].LibId.libSlot == this.LibId)
          flag3 = true;
      }
      int sfTypeCounter1 = this.game.Data.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter1; ++index)
      {
        if (this.game.Data.SFTypeObj[index].LibId.libSlot == this.LibId && this.game.Data.SFTypeObj[index].CopyDataFromBackup > -1)
          flag2 = true;
      }
      int num8 = 0;
      SubPartClass tsubpart7;
      if (this.LibId > -1)
      {
        if (flag1)
        {
          this.ss = "Save a library; Note this is still EXPERIMENTAL.";
          tsubpart7 = (SubPartClass) new TextButtonPartClass("Save Officer Lib", 150, this.ss, ref this.OwnBitmap, num1 - 150, 486 + num8, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.saveId = this.AddSubPart(ref tsubpart7, num1 - 150, 486 + num8, 150, 35, 1);
          num8 += 40;
        }
        if (flag3)
        {
          this.ss = "Save a library; Note this is still EXPERIMENTAL.";
          tsubpart7 = (SubPartClass) new TextButtonPartClass("Save His Lib", 150, this.ss, ref this.OwnBitmap, num1 - 150, 486 + num8, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.save2id = this.AddSubPart(ref tsubpart7, num1 - 150, 486 + num8, 150, 35, 1);
          num8 += 40;
        }
        if (flag2)
        {
          this.ss = "Save a library; Note this is still EXPERIMENTAL.";
          tsubpart7 = (SubPartClass) new TextButtonPartClass("Save Troops Lib", 150, this.ss, ref this.OwnBitmap, num1 - 150, 486 + num8, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.save3id = this.AddSubPart(ref tsubpart7, num1 - 150, 486 + num8, 150, 35, 1);
          num8 += 40;
        }
      }
      this.ss = "Save the map; Note this is still EXPERIMENTAL.";
      tsubpart7 = (SubPartClass) new TextButtonPartClass("Save Map", 150, this.ss, ref this.OwnBitmap, num1 - 150, 486 + num8, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.save4id = this.AddSubPart(ref tsubpart7, num1 - 150, 486 + num8, 150, 35, 1);
      int num9 = num8 + 40;
      if (this.CatListId > 0)
        this.RemoveSubPart(this.CatListId);
      this.CatListObj = new ListClass();
      int tlistselect2 = -1;
      int num10 = -1;
      if (this.LibId >= -1)
      {
        int num11 = 0;
        do
        {
          int num12 = 0;
          int libVarCounter = this.game.Data.LibVarCounter;
          for (int index = 0; index <= libVarCounter; ++index)
          {
            if (this.game.Data.LibVarObj[index].libId.libSlot == this.LibId & this.game.Data.LibVarObj[index].libId.id == -1 & this.game.Data.LibVarObj[index].type == (NewEnums.LibVarType) num11 && this.game.Data.LibVarObj[index].instanceId.id == -1)
              ++num12;
          }
          if (num12 > 0)
          {
            ++num10;
            if (num11 == 0)
              this.CatListObj.add("Global LibVars [" + num12.ToString() + "]", 0);
            if (num11 == 1)
              this.CatListObj.add("Landscape LibVars [" + num12.ToString() + "]", 1);
            if (num11 == 2)
              this.CatListObj.add("Road Type LibVars [" + num12.ToString() + "]", 2);
            if (num11 == 3)
              this.CatListObj.add("River Type LibVars [" + num12.ToString() + "]", 3);
            if (num11 == 4)
              this.CatListObj.add("Hex LibVars [" + num12.ToString() + "]", 4);
            if (num11 == 7)
              this.CatListObj.add("Historical Unit LibVars [" + num12.ToString() + "]", 7);
            if (num11 == 8)
              this.CatListObj.add("Historical Model LibVars [" + num12.ToString() + "]", 8);
            if (num11 == 5)
              this.CatListObj.add("TroopType LibVars [" + num12.ToString() + "]", 5);
            if (num11 == 6)
              this.CatListObj.add("Location Type LibVars [" + num12.ToString() + "]", 6);
            if (num11 == 9)
              this.CatListObj.add("Commander LibVars [" + num12.ToString() + "]", 9);
            if (num11 == 10)
              this.CatListObj.add("People LibVars [" + num12.ToString() + "]", 10);
            if (num11 == 11)
              this.CatListObj.add("Regime LibVars [" + num12.ToString() + "]", 11);
            if (this.CatId == num11)
              tlistselect2 = num10;
          }
          ++num11;
        }
        while (num11 <= 19);
        int num13 = 0;
        int eventCounter1 = this.game.Data.EventCounter;
        for (int index = 0; index <= eventCounter1; ++index)
        {
          if (this.game.Data.EventObj[index].LibId.libSlot == this.LibId & this.game.Data.EventObj[index].AllowExecute)
            ++num13;
        }
        if (num13 > 0)
        {
          ++num10;
          this.CatListObj.add("Executable events [" + num13.ToString() + "]", 101);
          if (this.CatId == 101)
            tlistselect2 = num10;
        }
        int num14 = 0;
        int eventCounter2 = this.game.Data.EventCounter;
        for (int index = 0; index <= eventCounter2; ++index)
        {
          if (this.game.Data.EventObj[index].LibId.libSlot == this.LibId & !this.game.Data.EventObj[index].AllowExecute)
            ++num14;
        }
        if (num14 > 0)
        {
          ++num10;
          this.CatListObj.add("Non-executable events [" + num14.ToString() + "]", 109);
          if (this.CatId == 109)
            tlistselect2 = num10;
        }
        int num15 = 0;
        int stringListCounter = this.game.Data.StringListCounter;
        for (int index = 0; index <= stringListCounter; ++index)
        {
          if (this.game.Data.StringListObj[index].LibId.libSlot == this.LibId & this.game.Data.StringListObj[index].Editable)
            ++num15;
        }
        if (num15 > 0)
        {
          ++num10;
          this.CatListObj.add("Tables [" + num15.ToString() + "]", 108);
          if (this.CatId == 108)
            tlistselect2 = num10;
        }
        int num16 = 0;
        int sfTypeCounter2 = this.game.Data.SFTypeCounter;
        for (int index = 0; index <= sfTypeCounter2; ++index)
        {
          if (this.game.Data.SFTypeObj[index].LibId.libSlot == this.LibId & !this.game.Data.SFTypeObj[index].DontShowInList)
            ++num16;
        }
        if (num16 > 0)
        {
          ++num10;
          this.CatListObj.add("Trooptypes [" + num16.ToString() + "]", 102);
          if (this.CatId == 102)
            tlistselect2 = num10;
        }
        int num17 = 0;
        int historicalUnitCounter2 = this.game.Data.HistoricalUnitCounter;
        for (int index = 0; index <= historicalUnitCounter2; ++index)
        {
          if (Information.IsNothing((object) this.game.Data.HistoricalUnitObj[index].CommanderName))
            this.game.Data.HistoricalUnitObj[index].CommanderName = "";
          if (this.game.Data.HistoricalUnitObj[index].LibId.libSlot == this.LibId & this.game.Data.HistoricalUnitObj[index].Model & this.game.Data.HistoricalUnitObj[index].CommanderName.Length < 1)
            ++num17;
        }
        if (num17 > 0)
        {
          ++num10;
          this.CatListObj.add("Historical models [" + num17.ToString() + "]", 103);
          if (this.CatId == 103)
            tlistselect2 = num10;
        }
        int num18 = 0;
        int historicalUnitCounter3 = this.game.Data.HistoricalUnitCounter;
        for (int his = 0; his <= historicalUnitCounter3; ++his)
        {
          if (this.game.Data.HistoricalUnitObj[his].LibId.libSlot == this.LibId & !this.game.Data.HistoricalUnitObj[his].Model & (this.game.Data.HistoricalUnitObj[his].CommanderName.Length < 1 | this.game.HandyFunctionsObj.GetUnitByHistorical(his) > -1))
            ++num18;
        }
        if (num18 > 0)
        {
          ++num10;
          this.CatListObj.add("Historical units [" + num18.ToString() + "]", 104);
          if (this.CatId == 104)
            tlistselect2 = num10;
        }
        int num19 = 0;
        int historicalUnitCounter4 = this.game.Data.HistoricalUnitCounter;
        for (int index = 0; index <= historicalUnitCounter4; ++index)
        {
          if (!this.game.Data.HistoricalUnitObj[index].Model & this.game.Data.HistoricalUnitObj[index].CommanderName.Length > 0 && this.LibId != -1 & this.game.Data.HistoricalUnitObj[index].OffLibId.libSlot == this.LibId)
            ++num19;
          if (!this.game.Data.HistoricalUnitObj[index].Model & this.game.Data.HistoricalUnitObj[index].CommanderName.Length > 0 && this.LibId != -1 & this.game.Data.HistoricalUnitObj[index].LibId.libSlot == this.LibId & this.game.Data.HistoricalUnitObj[index].OffLibId.libSlot == -1)
            ++num19;
        }
        if (num19 > 0)
        {
          ++num10;
          this.CatListObj.add("Officers [" + num19.ToString() + "]", 105);
          if (this.CatId == 105)
            tlistselect2 = num10;
        }
        int num20 = 0;
        int peopleCounter = this.game.Data.PeopleCounter;
        for (int index = 0; index <= peopleCounter; ++index)
        {
          if (this.game.Data.PeopleObj[index].LibId.libSlot == this.LibId)
            ++num20;
        }
        if (num20 > 0)
        {
          ++num10;
          this.CatListObj.add("Peoples [" + num20.ToString() + "]", 106);
          if (this.CatId == 106)
            tlistselect2 = num10;
        }
        int num21 = 0;
        int eventPicCounter = this.game.Data.EventPicCounter;
        for (int index = 0; index <= eventPicCounter; ++index)
        {
          if (this.game.Data.eventPicLibId[index].libSlot == this.LibId)
            ++num21;
        }
        if (num21 >= 0)
        {
          ++num10;
          this.CatListObj.add("Event Pictures [" + num21.ToString() + "]", 110);
          if (this.CatId == 110)
            tlistselect2 = num10;
        }
        int num22 = 0;
        int smallPicCounter = this.game.Data.SmallPicCounter;
        for (int index = 0; index <= smallPicCounter; ++index)
        {
          if (this.game.Data.SmallLibId[index].libSlot == this.LibId)
            ++num22;
        }
        if (num22 >= 0)
        {
          ++num10;
          this.CatListObj.add("Small Graphics [" + num22.ToString() + "]", 111);
          if (this.CatId == 111)
            tlistselect2 = num10;
        }
        int num23 = 0;
        int actionCardCounter = this.game.Data.ActionCardCounter;
        for (int index = 0; index <= actionCardCounter; ++index)
        {
          if (this.game.Data.ActionCardObj[index].LibId.libSlot == this.LibId)
            ++num23;
        }
        if (num23 > 0)
        {
          ++num10;
          this.CatListObj.add("Action Cards [" + num23.ToString() + "]", 112);
          if (this.CatId == 112)
            tlistselect2 = num10;
        }
        int num24 = 0;
        int regimeCounter = this.game.Data.RegimeCounter;
        for (int index = 0; index <= regimeCounter; ++index)
        {
          if (this.game.Data.RegimeObj[index].libId.libSlot == this.LibId)
            ++num24;
        }
        if (num24 > 0)
        {
          int num25 = num10 + 1;
          this.CatListObj.add("Regimes [" + num24.ToString() + "]", 107);
          if (this.CatId == 107)
            tlistselect2 = num25;
        }
      }
      tsubpart7 = (SubPartClass) new ListSubPartClass(this.CatListObj, 4 + (int) Math.Round((double) num2 / 24.0), 200, tlistselect2, this.game, true, "Variable categories", false, tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: (10 + num1 + 240), bby: 72, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
      this.CatListId = this.AddSubPart(ref tsubpart7, 10 + num1 + 240, 72, 200, (5 + (int) Math.Round((double) num2 / 24.0)) * 24, 0);
      if (this.IndListId > 0)
        this.RemoveSubPart(this.IndListId);
      this.IndListObj = new ListClass();
      int num26 = -1;
      int num27 = -1;
      if (this.CatId > -1)
      {
        if (this.CatId == 0)
        {
          ++num27;
          this.IndListObj.add("All", 0);
          if (this.IndId == 0)
            num26 = num27;
        }
        if (this.CatId == 4)
        {
          ++num27;
          this.IndListObj.add("All", 0);
          if (this.IndId == 0)
            num26 = num27;
        }
        if (this.CatId == 5)
        {
          int sfTypeCounter3 = this.game.Data.SFTypeCounter;
          for (int tdata = 0; tdata <= sfTypeCounter3; ++tdata)
          {
            this.IndListObj.add(this.game.Data.SFTypeObj[tdata].Name, tdata);
            ++num27;
            if (this.IndId == tdata)
              num26 = num27;
          }
        }
        if (this.CatId == 7)
        {
          int historicalUnitCounter5 = this.game.Data.HistoricalUnitCounter;
          for (int index = 0; index <= historicalUnitCounter5; ++index)
          {
            if (!this.game.Data.HistoricalUnitObj[index].Model & (this.game.Data.HistoricalUnitObj[index].CommanderName.Length < 1 | this.game.HandyFunctionsObj.GetUnitByHistorical(index) > -1))
            {
              this.IndListObj.add(this.game.Data.HistoricalUnitObj[index].Name, index);
              ++num27;
              if (this.IndId == index)
                num26 = num27;
            }
          }
        }
        if (this.CatId == 8)
        {
          int historicalUnitCounter6 = this.game.Data.HistoricalUnitCounter;
          for (int tdata = 0; tdata <= historicalUnitCounter6; ++tdata)
          {
            if (this.game.Data.HistoricalUnitObj[tdata].Model & this.game.Data.HistoricalUnitObj[tdata].CommanderName.Length < 1)
            {
              this.IndListObj.add(this.game.Data.HistoricalUnitObj[tdata].Name, tdata);
              ++num27;
              if (this.IndId == tdata)
                num26 = num27;
            }
          }
        }
        if (this.CatId == 9)
        {
          int historicalUnitCounter7 = this.game.Data.HistoricalUnitCounter;
          for (int tdata = 0; tdata <= historicalUnitCounter7; ++tdata)
          {
            if (!this.game.Data.HistoricalUnitObj[tdata].Model & this.game.Data.HistoricalUnitObj[tdata].CommanderName.Length > 0)
            {
              this.IndListObj.add(this.game.Data.HistoricalUnitObj[tdata].CommanderName, tdata);
              ++num27;
              if (this.IndId == tdata)
                num26 = num27;
            }
          }
        }
        if (this.CatId == 1)
        {
          int landscapeTypeCounter = this.game.Data.LandscapeTypeCounter;
          for (int tdata = 0; tdata <= landscapeTypeCounter; ++tdata)
          {
            this.IndListObj.add(this.game.Data.LandscapeTypeObj[tdata].Name, tdata);
            ++num27;
            if (this.IndId == tdata)
              num26 = num27;
          }
        }
        if (this.CatId == 6)
        {
          int locTypeCounter = this.game.Data.LocTypeCounter;
          for (int tdata = 0; tdata <= locTypeCounter; ++tdata)
          {
            this.IndListObj.add(this.game.Data.LocTypeObj[tdata].Name, tdata);
            ++num27;
            if (this.IndId == tdata)
              num26 = num27;
          }
        }
        if (this.CatId == 10)
        {
          int peopleCounter = this.game.Data.PeopleCounter;
          for (int tdata = 0; tdata <= peopleCounter; ++tdata)
          {
            this.IndListObj.add(this.game.Data.PeopleObj[tdata].Name, tdata);
            ++num27;
            if (this.IndId == tdata)
              num26 = num27;
          }
        }
        if (this.CatId == 11)
        {
          int regimeCounter = this.game.Data.RegimeCounter;
          for (int tdata = 0; tdata <= regimeCounter; ++tdata)
          {
            this.IndListObj.add(this.game.Data.RegimeObj[tdata].Name, tdata);
            ++num27;
            if (this.IndId == tdata)
              num26 = num27;
          }
        }
        if (this.CatId == 3)
        {
          int riverTypeCounter = this.game.Data.RiverTypeCounter;
          for (int tdata = 0; tdata <= riverTypeCounter; ++tdata)
          {
            this.IndListObj.add(this.game.Data.RiverTypeObj[tdata].Name, tdata);
            ++num27;
            if (this.IndId == tdata)
              num26 = num27;
          }
        }
        if (this.CatId == 2)
        {
          int roadTypeCounter = this.game.Data.RoadTypeCounter;
          for (int tdata = 0; tdata <= roadTypeCounter; ++tdata)
          {
            this.IndListObj.add(this.game.Data.RoadTypeObj[tdata].Name, tdata);
            ++num27;
            if (this.IndId == tdata)
              num26 = num27;
          }
        }
        if (this.CatId == 101)
        {
          ++num27;
          this.IndListObj.add("All events", 0);
          if (this.IndId == 0)
            num26 = num27;
        }
        if (this.CatId == 109)
        {
          ++num27;
          this.IndListObj.add("All events", 0);
          if (this.IndId == 0)
            num26 = num27;
        }
        if (this.CatId == 108)
        {
          ++num27;
          this.IndListObj.add("All tables", 0);
          if (this.IndId == 0)
            num26 = num27;
        }
        if (this.CatId == 110)
        {
          int eventPicCounter = this.game.Data.EventPicCounter;
          for (int tdata = 0; tdata <= eventPicCounter; ++tdata)
          {
            if (this.game.Data.eventPicLibId[tdata].libSlot == this.LibId)
            {
              this.IndListObj.add(this.game.Data.EventPicName[tdata] + " (id=" + this.game.Data.eventPicLibId[tdata].id.ToString() + ")", tdata);
              ++num27;
              if (this.IndId == tdata)
                num26 = num27;
            }
          }
        }
        if (this.CatId == 111)
        {
          int smallPicCounter = this.game.Data.SmallPicCounter;
          for (int tdata = 0; tdata <= smallPicCounter; ++tdata)
          {
            if (this.game.Data.SmallLibId[tdata].libSlot == this.LibId)
            {
              this.IndListObj.add(this.game.Data.SmallPicName[tdata] + " (id=" + this.game.Data.SmallLibId[tdata].id.ToString() + ")", tdata);
              ++num27;
              if (this.IndId == tdata)
                num26 = num27;
            }
          }
        }
        if (this.CatId == 112)
        {
          int actionCardCounter = this.game.Data.ActionCardCounter;
          for (int tdata = 0; tdata <= actionCardCounter; ++tdata)
          {
            if (this.game.Data.ActionCardObj[tdata].LibId.libSlot == this.LibId)
            {
              this.IndListObj.add(this.game.Data.ActionCardObj[tdata].Title + " (id=" + this.game.Data.ActionCardObj[tdata].LibId.id.ToString() + ")", tdata);
              ++num27;
              if (this.IndId == tdata)
                num26 = num27;
            }
          }
        }
        if (this.CatId == 102)
        {
          int sfTypeCounter4 = this.game.Data.SFTypeCounter;
          for (int tdata = 0; tdata <= sfTypeCounter4; ++tdata)
          {
            if (this.game.Data.SFTypeObj[tdata].LibId.libSlot == this.LibId & !this.game.Data.SFTypeObj[tdata].DontShowInList)
            {
              this.IndListObj.add(this.game.Data.SFTypeObj[tdata].Name + " (id=" + this.game.Data.SFTypeObj[tdata].LibId.id.ToString() + ")", tdata);
              ++num27;
              if (this.IndId == tdata)
                num26 = num27;
            }
          }
        }
        if (this.CatId == 103)
        {
          int historicalUnitCounter8 = this.game.Data.HistoricalUnitCounter;
          for (int tdata = 0; tdata <= historicalUnitCounter8; ++tdata)
          {
            if (this.game.Data.HistoricalUnitObj[tdata].LibId.libSlot == this.LibId & this.game.Data.HistoricalUnitObj[tdata].Model & this.game.Data.HistoricalUnitObj[tdata].CommanderName.Length < 1)
            {
              this.IndListObj.add(this.game.Data.HistoricalUnitObj[tdata].Name + " (id=" + this.game.Data.HistoricalUnitObj[tdata].LibId.id.ToString() + ")", tdata);
              ++num27;
              if (this.IndId == tdata)
                num26 = num27;
            }
          }
        }
        if (this.CatId == 104)
        {
          int historicalUnitCounter9 = this.game.Data.HistoricalUnitCounter;
          for (int index = 0; index <= historicalUnitCounter9; ++index)
          {
            if (this.game.Data.HistoricalUnitObj[index].LibId.libSlot == this.LibId & !this.game.Data.HistoricalUnitObj[index].Model & (this.game.Data.HistoricalUnitObj[index].CommanderName.Length < 1 | this.game.HandyFunctionsObj.GetUnitByHistorical(index) > -1))
            {
              this.IndListObj.add(this.game.Data.HistoricalUnitObj[index].Name + " (id=" + this.game.Data.HistoricalUnitObj[index].LibId.id.ToString() + ")", index);
              ++num27;
              if (this.IndId == index)
                num26 = num27;
            }
          }
        }
        if (this.CatId == 105)
        {
          int historicalUnitCounter10 = this.game.Data.HistoricalUnitCounter;
          for (int tdata = 0; tdata <= historicalUnitCounter10; ++tdata)
          {
            if (!this.game.Data.HistoricalUnitObj[tdata].Model & this.game.Data.HistoricalUnitObj[tdata].CommanderName.Length > 0 && this.LibId != -1 & this.game.Data.HistoricalUnitObj[tdata].LibId.libSlot == this.LibId & this.game.Data.HistoricalUnitObj[tdata].OffLibId.libSlot == -1)
            {
              this.IndListObj.add(this.game.Data.HistoricalUnitObj[tdata].CommanderName + " (id=" + this.game.Data.HistoricalUnitObj[tdata].LibId.id.ToString() + ")", tdata);
              ++num27;
              if (this.IndId == tdata)
                num26 = num27;
            }
            if (!this.game.Data.HistoricalUnitObj[tdata].Model & this.game.Data.HistoricalUnitObj[tdata].CommanderName.Length > 0 && this.LibId != -1 & this.game.Data.HistoricalUnitObj[tdata].OffLibId.libSlot == this.LibId)
            {
              this.IndListObj.add(this.game.Data.HistoricalUnitObj[tdata].CommanderName + " (id=" + this.game.Data.HistoricalUnitObj[tdata].OffLibId.id.ToString() + ") <assigned>", tdata);
              ++num27;
              if (this.IndId == tdata)
                num26 = num27;
            }
          }
        }
        if (this.CatId == 106)
        {
          int peopleCounter = this.game.Data.PeopleCounter;
          for (int tdata = 0; tdata <= peopleCounter; ++tdata)
          {
            if (this.game.Data.PeopleObj[tdata].LibId.libSlot == this.LibId)
            {
              this.IndListObj.add(this.game.Data.PeopleObj[tdata].Name + " (id=" + this.game.Data.PeopleObj[tdata].LibId.id.ToString() + ")", tdata);
              ++num27;
              if (this.IndId == tdata)
                num26 = num27;
            }
          }
        }
        if (this.CatId == 107)
        {
          int regimeCounter = this.game.Data.RegimeCounter;
          for (int tdata = 0; tdata <= regimeCounter; ++tdata)
          {
            if (this.game.Data.RegimeObj[tdata].libId.libSlot == this.LibId)
            {
              this.IndListObj.add(this.game.Data.RegimeObj[tdata].Name + " (id=" + this.game.Data.RegimeObj[tdata].libId.id.ToString() + ")", tdata);
              ++num27;
              if (this.IndId == tdata)
                num26 = num27;
            }
          }
        }
      }
      ListClass indListObj = this.IndListObj;
      int tlistsize1 = 7 + (int) Math.Round((double) num2 / 16.0);
      int tlistselect3 = num26;
      GameClass game1 = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      int bbx1 = 10 + num1 + 480;
      Font font = (Font) null;
      ref Font local2 = ref font;
      tsubpart7 = (SubPartClass) new ListSubPartClass(indListObj, tlistsize1, 200, tlistselect3, game1, true, "Instances", false, tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: bbx1, bby: 72, tMarcStyle: true, overruleFont: (ref local2));
      this.IndListId = this.AddSubPart(ref tsubpart7, 10 + num1 + 480, 72, 220, (9 + (int) Math.Round((double) num2 / 16.0)) * 16, 0);
      if (this.LibVarListId > 0)
        this.RemoveSubPart(this.LibVarListId);
      this.LibVarListObj = new ListClass();
      int num28 = -1;
      int num29 = -1;
      bool flag4;
      if (this.IndId > -1)
      {
        if (this.CatId <= 19)
        {
          int libVarCounter = this.game.Data.LibVarCounter;
          for (int index = 0; index <= libVarCounter; ++index)
          {
            if (this.game.Data.LibVarObj[index].libId.libSlot == this.LibId & this.game.Data.LibVarObj[index].type == (NewEnums.LibVarType) this.CatId)
            {
              bool flag5 = false;
              int num30 = -1;
              int num31;
              if (this.game.Data.LibVarObj[index].type == NewEnums.LibVarType.HistoricalUnit)
              {
                num31 = this.game.Data.HistoricalUnitObj[this.IndId].LibId.libSlot;
                num30 = this.game.Data.HistoricalUnitObj[this.IndId].LibId.id;
                if (num30 == -1)
                  num30 = this.IndId;
              }
              if (this.game.Data.LibVarObj[index].type == NewEnums.LibVarType.HistoricalUnitModel)
              {
                num31 = this.game.Data.HistoricalUnitObj[this.IndId].LibId.libSlot;
                num30 = this.game.Data.HistoricalUnitObj[this.IndId].LibId.id;
              }
              if (this.game.Data.LibVarObj[index].type == NewEnums.LibVarType.Officer)
              {
                if (this.game.Data.HistoricalUnitObj[this.IndId].OffLibId.id > -1)
                {
                  num31 = this.game.Data.HistoricalUnitObj[this.IndId].OffLibId.libSlot;
                  num30 = this.game.Data.HistoricalUnitObj[this.IndId].OffLibId.id;
                }
                else
                {
                  num31 = this.game.Data.HistoricalUnitObj[this.IndId].LibId.libSlot;
                  num30 = this.game.Data.HistoricalUnitObj[this.IndId].LibId.id;
                }
              }
              if (this.game.Data.LibVarObj[index].type == NewEnums.LibVarType.Landscape)
              {
                num31 = -1;
                num30 = this.IndId;
              }
              if (this.game.Data.LibVarObj[index].type == NewEnums.LibVarType.LocationType)
              {
                num31 = -1;
                num30 = this.IndId;
              }
              if (this.game.Data.LibVarObj[index].type == NewEnums.LibVarType.People)
              {
                num31 = this.game.Data.PeopleObj[this.IndId].LibId.libSlot;
                num30 = this.game.Data.PeopleObj[this.IndId].LibId.id;
                if (num30 == -1)
                  num30 = this.IndId;
              }
              if (this.game.Data.LibVarObj[index].type == NewEnums.LibVarType.Regime)
              {
                num31 = this.game.Data.RegimeObj[this.IndId].libId.libSlot;
                num30 = this.game.Data.RegimeObj[this.IndId].libId.id;
                if (num30 == -1)
                  num30 = this.IndId;
              }
              if (this.game.Data.LibVarObj[index].type == NewEnums.LibVarType.River)
              {
                num31 = -1;
                num30 = this.IndId;
              }
              if (this.game.Data.LibVarObj[index].type == NewEnums.LibVarType.Road)
              {
                num31 = -1;
                num30 = this.IndId;
              }
              if (this.game.Data.LibVarObj[index].type == NewEnums.LibVarType.SFtype)
              {
                num31 = this.game.Data.SFTypeObj[this.IndId].LibId.libSlot;
                num30 = this.game.Data.SFTypeObj[this.IndId].LibId.id;
              }
              string tvalue;
              if (num30 > -1 & num31 == this.game.Data.LibVarObj[index].instanceId.libSlot & num30 == this.game.Data.LibVarObj[index].instanceId.id)
              {
                flag4 = true;
                ++num29;
                if (this.LibVarId == index)
                  num28 = num29;
                flag5 = true;
                tvalue = this.game.Data.LibVarObj[this.game.Data.GetLibVarUseId(index, this.IndId)].GetValue(ref this.game.Data);
              }
              else if (this.game.Data.LibVarObj[index].instanceId.id == -1)
              {
                int libVarUseId = this.game.Data.GetLibVarUseId(index, this.IndId);
                if (libVarUseId == index)
                {
                  flag5 = true;
                  if (Operators.CompareString(this.game.Data.LibVarObj[libVarUseId].information, "hidden", false) == 0)
                    flag5 = false;
                  if (flag5)
                  {
                    ++num29;
                    if (this.LibVarId == index)
                      num28 = num29;
                    tvalue = !(this.game.Data.LibVarObj[libVarUseId].type == NewEnums.LibVarType.General | this.game.Data.LibVarObj[libVarUseId].type == NewEnums.LibVarType.Hex) ? "-not set-" : this.game.Data.LibVarObj[libVarUseId].GetValue(ref this.game.Data);
                  }
                }
              }
              else
                index = index;
              if (flag5)
                this.LibVarListObj.add(this.game.Data.LibVarObj[index].name, index, tvalue);
            }
          }
          if (this.LibVarListObj.ListCount > -1)
          {
            ListClass libVarListObj = this.LibVarListObj;
            int tlistsize2 = 13 + (int) Math.Round((double) num2 / 16.0);
            int twidth = (int) Math.Round(Math.Max(200.0, (double) this.game.ScreenWidth / 2.0 - 312.0));
            int tlistselect4 = num28;
            GameClass game2 = this.game;
            int tValueWidth = (int) Math.Round(Conversion.Int(Math.Max(200.0, (double) this.game.ScreenWidth / 2.0 - 312.0) * 0.66));
            ref Bitmap local3 = ref this.OwnBitmap;
            int bbx2 = 10 + num1 + 720;
            font = (Font) null;
            ref Font local4 = ref font;
            tsubpart7 = (SubPartClass) new ListSubPartClass(libVarListObj, tlistsize2, twidth, tlistselect4, game2, true, "Variables", false, tShowPair: true, tValueWidth: tValueWidth, tdotopandbottom: false, tbackbitmap: (ref local3), bbx: bbx2, bby: 72, tMarcStyle: true, overruleFont: (ref local4));
            this.LibVarListId = this.AddSubPart(ref tsubpart7, 10 + num1 + 720, 72, (int) Math.Round(Math.Max(200.0, (double) this.game.ScreenWidth / 2.0 - 312.0)), (15 + (int) Math.Round((double) num2 / 16.0)) * 16, 0);
          }
        }
        else if (this.CatId == 5)
        {
          int libVarCounter1 = this.game.Data.LibVarCounter;
          for (int tdata = 0; tdata <= libVarCounter1; ++tdata)
          {
            if (this.game.Data.LibVarObj[tdata].libId.libSlot == this.LibId & this.game.Data.LibVarObj[tdata].type == (NewEnums.LibVarType) this.CatId && -1 == this.game.Data.LibVarObj[tdata].instanceId.id)
            {
              flag4 = true;
              ++num29;
              if (this.LibVarId == tdata)
                num28 = num29;
              string tvalue = "-not set-";
              flag4 = false;
              int libVarCounter2 = this.game.Data.LibVarCounter;
              for (int index = 0; index <= libVarCounter2; ++index)
              {
                if (this.game.Data.LibVarObj[tdata].libId.libSlot == this.game.Data.LibVarObj[index].libId.libSlot && Operators.CompareString(this.game.Data.LibVarObj[tdata].name, this.game.Data.LibVarObj[index].name, false) == 0 && this.game.Data.SFTypeObj[this.IndId].LibId.libSlot == this.game.Data.LibVarObj[index].instanceId.libSlot && this.game.Data.SFTypeObj[this.IndId].LibId.id == this.game.Data.LibVarObj[index].instanceId.id)
                {
                  flag4 = true;
                  if (this.game.Data.LibVarObj[tdata].valueType == NewEnums.LibVarValueType.Number)
                  {
                    tvalue = this.game.Data.LibVarObj[index].value.ToString();
                    break;
                  }
                  break;
                }
              }
              this.LibVarListObj.add(this.game.Data.LibVarObj[tdata].name, tdata, tvalue);
            }
          }
          ListClass libVarListObj = this.LibVarListObj;
          int tlistsize3 = 13 + (int) Math.Round((double) num2 / 16.0);
          int twidth = (int) Math.Round(Math.Max(200.0, (double) this.game.ScreenWidth / 2.0 - 312.0));
          int tlistselect5 = num28;
          GameClass game3 = this.game;
          ref Bitmap local5 = ref this.OwnBitmap;
          int bbx3 = 10 + num1 + 720;
          font = (Font) null;
          ref Font local6 = ref font;
          tsubpart7 = (SubPartClass) new ListSubPartClass(libVarListObj, tlistsize3, twidth, tlistselect5, game3, true, "Variables", false, tShowPair: true, tValueWidth: 75, tdotopandbottom: false, tbackbitmap: (ref local5), bbx: bbx3, bby: 72, tMarcStyle: true, overruleFont: (ref local6));
          this.LibVarListId = this.AddSubPart(ref tsubpart7, 10 + num1 + 720, 72, (int) Math.Round(Math.Max(200.0, (double) this.game.ScreenWidth / 2.0 - 312.0)), (15 + (int) Math.Round((double) num2 / 16.0)) * 16, 0);
        }
        else if (this.CatId == 101)
        {
          int eventCounter = this.game.Data.EventCounter;
          for (int tdata = 0; tdata <= eventCounter; ++tdata)
          {
            if (this.game.Data.EventObj[tdata].LibId.libSlot == this.LibId & this.game.Data.EventObj[tdata].AllowExecute)
            {
              ++num29;
              if (this.LibVarId == tdata)
                num28 = num29;
              this.LibVarListObj.add(this.game.Data.EventObj[tdata].Name, tdata);
            }
          }
          ListClass libVarListObj = this.LibVarListObj;
          int tlistsize4 = 13 + (int) Math.Round((double) num2 / 16.0);
          int twidth = (int) Math.Round(Math.Max(200.0, (double) this.game.ScreenWidth / 2.0 - 312.0));
          int tlistselect6 = num28;
          GameClass game4 = this.game;
          ref Bitmap local7 = ref this.OwnBitmap;
          int bbx4 = 10 + num1 + 720;
          font = (Font) null;
          ref Font local8 = ref font;
          tsubpart7 = (SubPartClass) new ListSubPartClass(libVarListObj, tlistsize4, twidth, tlistselect6, game4, true, "Events", false, tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref local7), bbx: bbx4, bby: 72, tMarcStyle: true, overruleFont: (ref local8));
          this.LibVarListId = this.AddSubPart(ref tsubpart7, 10 + num1 + 720, 72, (int) Math.Round(Math.Max(200.0, (double) this.game.ScreenWidth / 2.0 - 312.0)), (15 + (int) Math.Round((double) num2 / 16.0)) * 16, 0);
        }
        else if (this.CatId == 109)
        {
          int eventCounter = this.game.Data.EventCounter;
          for (int tdata = 0; tdata <= eventCounter; ++tdata)
          {
            if (this.game.Data.EventObj[tdata].LibId.libSlot == this.LibId & !this.game.Data.EventObj[tdata].AllowExecute)
            {
              ++num29;
              if (this.LibVarId == tdata)
                num28 = num29;
              this.LibVarListObj.add(this.game.Data.EventObj[tdata].Name, tdata);
            }
          }
          ListClass libVarListObj = this.LibVarListObj;
          int tlistsize5 = 13 + (int) Math.Round((double) num2 / 16.0);
          int twidth = (int) Math.Round(Math.Max(200.0, (double) this.game.ScreenWidth / 2.0 - 312.0));
          int tlistselect7 = num28;
          GameClass game5 = this.game;
          ref Bitmap local9 = ref this.OwnBitmap;
          int bbx5 = 10 + num1 + 720;
          font = (Font) null;
          ref Font local10 = ref font;
          tsubpart7 = (SubPartClass) new ListSubPartClass(libVarListObj, tlistsize5, twidth, tlistselect7, game5, true, "Events", false, tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref local9), bbx: bbx5, bby: 72, tMarcStyle: true, overruleFont: (ref local10));
          this.LibVarListId = this.AddSubPart(ref tsubpart7, 10 + num1 + 720, 72, (int) Math.Round(Math.Max(200.0, (double) this.game.ScreenWidth / 2.0 - 312.0)), (15 + (int) Math.Round((double) num2 / 16.0)) * 16, 0);
        }
        else if (this.CatId == 108)
        {
          int stringListCounter = this.game.Data.StringListCounter;
          for (int tdata = 0; tdata <= stringListCounter; ++tdata)
          {
            if (this.game.Data.StringListObj[tdata].LibId.libSlot == this.LibId & this.game.Data.StringListObj[tdata].Editable)
            {
              ++num29;
              if (this.LibVarId == tdata)
                num28 = num29;
              this.LibVarListObj.add(this.game.Data.StringListObj[tdata].Name, tdata);
            }
          }
          ListClass libVarListObj = this.LibVarListObj;
          int tlistsize6 = 13 + (int) Math.Round((double) num2 / 16.0);
          int twidth = (int) Math.Round(Math.Max(200.0, (double) this.game.ScreenWidth / 2.0 - 312.0));
          int tlistselect8 = num28;
          GameClass game6 = this.game;
          ref Bitmap local11 = ref this.OwnBitmap;
          int bbx6 = 10 + num1 + 720;
          font = (Font) null;
          ref Font local12 = ref font;
          tsubpart7 = (SubPartClass) new ListSubPartClass(libVarListObj, tlistsize6, twidth, tlistselect8, game6, true, "Tables", false, tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref local11), bbx: bbx6, bby: 72, tMarcStyle: true, overruleFont: (ref local12));
          this.LibVarListId = this.AddSubPart(ref tsubpart7, 10 + num1 + 720, 72, (int) Math.Round(Math.Max(200.0, (double) this.game.ScreenWidth / 2.0 - 312.0)), (15 + (int) Math.Round((double) num2 / 16.0)) * 16, 0);
        }
        else
        {
          int libVarCounter = this.game.Data.LibVarCounter;
          for (int tdata = 0; tdata <= libVarCounter; ++tdata)
          {
            if (this.game.Data.LibVarObj[tdata].libId.libSlot == this.LibId & this.game.Data.LibVarObj[tdata].type == (NewEnums.LibVarType) this.CatId)
            {
              bool flag6 = false;
              if (this.CatId == 0 && this.IndId == 0)
                flag6 = true;
              if (this.CatId == 4)
              {
                ++num29;
                if (this.LibVarId == tdata)
                  num28 = num29;
                this.LibVarListObj.add(this.game.Data.LibVarObj[tdata].name, tdata, "map paint to set value");
              }
              if (flag6)
              {
                ++num29;
                if (this.LibVarId == tdata)
                  num28 = num29;
                string tvalue = "";
                if (this.game.Data.LibVarObj[tdata].valueType == NewEnums.LibVarValueType.Number)
                  tvalue = this.game.Data.LibVarObj[tdata].value.ToString();
                this.LibVarListObj.add(this.game.Data.LibVarObj[tdata].name, tdata, tvalue);
              }
            }
          }
          ListClass libVarListObj = this.LibVarListObj;
          int tlistsize7 = 13 + (int) Math.Round((double) num2 / 16.0);
          int twidth = (int) Math.Round(Math.Max(200.0, (double) this.game.ScreenWidth / 2.0 - 312.0));
          int tlistselect9 = num28;
          GameClass game7 = this.game;
          ref Bitmap local13 = ref this.OwnBitmap;
          int bbx7 = 10 + num1 + 720;
          font = (Font) null;
          ref Font local14 = ref font;
          tsubpart7 = (SubPartClass) new ListSubPartClass(libVarListObj, tlistsize7, twidth, tlistselect9, game7, true, "Variables", false, tShowPair: true, tValueWidth: 75, tdotopandbottom: false, tbackbitmap: (ref local13), bbx: bbx7, bby: 72, tMarcStyle: true, overruleFont: (ref local14));
          this.LibVarListId = this.AddSubPart(ref tsubpart7, 10 + num1 + 720, 72, (int) Math.Round(Math.Max(200.0, (double) this.game.ScreenWidth / 2.0 - 312.0)), (15 + (int) Math.Round((double) num2 / 16.0)) * 16, 0);
        }
      }
      if (!(this.LibVarListObj.ListCount == -1 & this.LibVarListId > 0))
        return;
      this.RemoveSubPart(this.LibVarListId);
      this.LibVarListId = 0;
    }

    private void MakeLibItemGUI()
    {
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      if (this.LibVarListId > 0)
        this.RemoveSubPart(this.LibVarListId);
      if (this.BNameId > 0)
        this.RemoveSubPart(this.BNameId);
      if (this.BNameTextId > 0)
        this.RemoveSubPart(this.BNameTextId);
      if (this.RemoveLibEventId > 0)
        this.RemoveSubPart(this.RemoveLibEventId);
      if (this.RemoveLibEventIdb > 0)
        this.RemoveSubPart(this.RemoveLibEventIdb);
      if (this.AddLibVarId > 0)
        this.RemoveSubPart(this.AddLibVarId);
      if (this.AddLibVarTextId > 0)
        this.RemoveSubPart(this.AddLibVarTextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
      if (this.B4Id > 0)
        this.RemoveSubPart(this.B4Id);
      if (this.B4TextId > 0)
        this.RemoveSubPart(this.B4TextId);
      if (this.LibId > -1)
      {
        this.ss = "Click to change the name of this Library. Make sure its a unique name. So maybe use part of your name or something thats not easily thought of by other designer.";
        SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("name: " + this.game.Data.LibraryObj[this.LibId].name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.BNameTextId = this.AddSubPart(ref tsubpart1, 510, 49, 400, 20, 0);
        this.ss = "Click to change the name of this Library. Make sure its a unique name. So maybe use part of your name or something thats not easily thought of by other designer.";
        SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("creator: " + this.game.Data.LibraryObj[this.LibId].creator, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B2TextId = this.AddSubPart(ref tsubpart2, 510, 79, 400, 20, 0);
        this.ss = "Click to document how to use your library.";
        SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("information: " + Strings.Left(this.game.Data.LibraryObj[this.LibId].information, 20) + "...", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B3TextId = this.AddSubPart(ref tsubpart3, 510, 109, 400, 20, 0);
        this.ss = "Click to change the name of this Library. Make sure its a unique name. So maybe use part of your name or something thats not easily thought of by other designer.";
        SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("version: " + this.game.Data.LibraryObj[this.LibId].version.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B4TextId = this.AddSubPart(ref tsubpart4, 510, 139, 400, 20, 0);
        if (this.LibVarListId > 0)
          this.RemoveSubPart(this.LibVarListId);
        int num2 = -1;
        int num3 = -1;
        this.LibVarListObj = new ListClass();
        int libVarCounter = this.game.Data.LibVarCounter;
        for (int index = 0; index <= libVarCounter; ++index)
        {
          if (this.game.Data.LibVarObj[index].libId.libSlot == this.LibId)
          {
            ++num3;
            this.LibVarListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.LibVarObj[index].name, index);
            if (this.LibVarId == index)
              num2 = num3;
          }
        }
        if (num2 == -1)
          this.LibVarId = -1;
        ListClass libVarListObj = this.LibVarListObj;
        int tlistselect = num2;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart5 = (SubPartClass) new ListSubPartClass(libVarListObj, 14, 400, tlistselect, game, tHeader: "LibVars", tbackbitmap: (ref local1), bbx: 470, bby: 200, overruleFont: (ref local2));
        this.LibVarListId = this.AddSubPart(ref tsubpart5, 470, 200, 400, 272, 0);
        if (this.AddLibVarId > 0)
          this.RemoveSubPart(this.AddLibVarId);
        if (this.AddLibVarTextId > 0)
          this.RemoveSubPart(this.AddLibVarTextId);
        this.ss = "Click to add a new LibVar";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
          this.AddLibVarId = this.AddSubPart(ref tsubpart6, 470, 500, 32, 16, 1);
        }
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          SubPartClass tsubpart7 = (SubPartClass) new TextPartClass("Add LibVar", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
          this.AddLibVarTextId = this.AddSubPart(ref tsubpart7, 520, 499, 300, 20, 0);
        }
      }
      this.MakeLibVarItemGUI();
    }

    private void MakeLibVarItemGUI()
    {
      if (this.LibVarTypeId > 0)
        this.RemoveSubPart(this.LibVarTypeId);
      if (this.LibVarValueTypeId > 0)
        this.RemoveSubPart(this.LibVarValueTypeId);
      if (this.LibVarNameId > 0)
        this.RemoveSubPart(this.LibVarNameId);
      if (this.LibVarTypeTextId > 0)
        this.RemoveSubPart(this.LibVarTypeTextId);
      if (this.LibVarValueTypeTextId > 0)
        this.RemoveSubPart(this.LibVarValueTypeTextId);
      if (this.LibVarNameTextId > 0)
        this.RemoveSubPart(this.LibVarNameTextId);
      if (this.LibVarInfoId > 0)
        this.RemoveSubPart(this.LibVarInfoId);
      if (this.LibVarInfoTextId > 0)
        this.RemoveSubPart(this.LibVarInfoTextId);
      if (this.RemoveLibVarId > 0)
        this.RemoveSubPart(this.RemoveLibVarId);
      if (this.RemoveLibVarTextId > 0)
        this.RemoveSubPart(this.RemoveLibVarTextId);
      if (this.LibVarId <= -1)
        return;
      this.ss = "";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.LibVarTypeId = this.AddSubPart(ref tsubpart, 470, 550, 32, 16, 1);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Type: " + this.game.Data.LibVarObj[this.LibVarId].type.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.LibVarTypeTextId = this.AddSubPart(ref tsubpart1, 510, 549, 400, 20, 0);
      this.ss = "";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.LibVarNameId = this.AddSubPart(ref tsubpart1, 470, 580, 32, 16, 1);
      }
      tsubpart1 = (SubPartClass) new TextPartClass("Name: " + this.game.Data.LibVarObj[this.LibVarId].name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.LibVarNameTextId = this.AddSubPart(ref tsubpart1, 510, 579, 400, 20, 0);
      this.ss = "";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.LibVarValueTypeId = this.AddSubPart(ref tsubpart1, 470, 610, 32, 16, 1);
      }
      tsubpart1 = (SubPartClass) new TextPartClass("ValueType: " + this.game.Data.LibVarObj[this.LibVarId].valueType.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.LibVarValueTypeTextId = this.AddSubPart(ref tsubpart1, 510, 609, 400, 20, 0);
      this.ss = "";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.LibVarInfoId = this.AddSubPart(ref tsubpart1, 470, 640, 32, 16, 1);
      }
      tsubpart1 = (SubPartClass) new TextPartClass("Information: " + Strings.Left(this.game.Data.LibVarObj[this.LibVarId].information, 20) + "...", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.LibVarInfoTextId = this.AddSubPart(ref tsubpart1, 510, 639, 400, 20, 0);
      this.ss = "Click to remove this libvar.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.RemoveLibVarId = this.AddSubPart(ref tsubpart1, 470, 520, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      tsubpart1 = (SubPartClass) new TextPartClass("Remove Libvar", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.RemoveLibVarTextId = this.AddSubPart(ref tsubpart1, 520, 519, 200, 20, 0);
    }

    public void SaveOfficerLib()
    {
      string tinitdir = this.game.AppPath + "scenarios\\";
      if (!Information.IsNothing((object) this.game.Data.ScenarioDir))
      {
        if (this.game.Data.ScenarioDir.Length > 1)
          tinitdir = tinitdir.Replace("scenarios", this.game.Data.ScenarioDir);
        else if (this.game.ModScenarioDir.Length > 1)
          tinitdir = tinitdir.Replace("scenarios", this.game.ModScenarioDir);
      }
      else if (this.game.ModScenarioDir.Length > 1)
        tinitdir = tinitdir.Replace("scenarios", this.game.ModScenarioDir);
      string str = this.game.HandyFunctionsObj.SaveSomething("SE1 Officer library(*.se1off)|*.se1off", "Give save name...", tinitdir, false);
      if (Strings.Len(str) < 2)
      {
        int num1 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      else
      {
        this.game.FormRef.Cursor = Cursors.WaitCursor;
        this.game.EditObj.TempFileType = NewEnums.LibFileType.LoadOfficers;
        this.game.HandyFunctionsObj.ActuallyExportLib(this.LibId).serialize(str);
        this.game.HandyFunctionsObj.ZipFile(str);
        this.game.FormRef.Cursor = Cursors.Default;
        int num2 = (int) Interaction.MsgBox((object) "Completed & Saved", Title: ((object) "Shadow Empire : Planetary Conquest"));
        this.game.EditObj.TempFileType = NewEnums.LibFileType.None;
      }
    }

    public void SaveMap()
    {
      string tinitdir = this.game.AppPath + "scenarios\\";
      if (!Information.IsNothing((object) this.game.Data.ScenarioDir))
      {
        if (this.game.Data.ScenarioDir.Length > 1)
          tinitdir = tinitdir.Replace("scenarios", this.game.Data.ScenarioDir);
        else if (this.game.ModScenarioDir.Length > 1)
          tinitdir = tinitdir.Replace("scenarios", this.game.ModScenarioDir);
      }
      else if (this.game.ModScenarioDir.Length > 1)
        tinitdir = tinitdir.Replace("scenarios", this.game.ModScenarioDir);
      string str = this.game.HandyFunctionsObj.SaveSomething("SE1 Map file(*.se1map)|*.se1map", "Give save name...", tinitdir, false);
      if (Strings.Len(str) < 2)
      {
        int num1 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      else
      {
        this.game.FormRef.Cursor = Cursors.WaitCursor;
        this.game.EditObj.TempFileType = NewEnums.LibFileType.LoadMap;
        this.game.HandyFunctionsObj.ActuallyExportLib(this.LibId).serialize(str);
        this.game.HandyFunctionsObj.ZipFile(str);
        this.game.FormRef.Cursor = Cursors.Default;
        int num2 = (int) Interaction.MsgBox((object) "Completed & Saved", Title: ((object) "Shadow Empire : Planetary Conquest"));
        this.game.EditObj.TempFileType = NewEnums.LibFileType.None;
      }
    }

    public void SaveTroopTypeLib()
    {
      string tinitdir = this.game.AppPath + "scenarios\\";
      if (!Information.IsNothing((object) this.game.Data.ScenarioDir))
      {
        if (this.game.Data.ScenarioDir.Length > 1)
          tinitdir = tinitdir.Replace("scenarios", this.game.Data.ScenarioDir);
        else if (this.game.ModScenarioDir.Length > 1)
          tinitdir = tinitdir.Replace("scenarios", this.game.ModScenarioDir);
      }
      else if (this.game.ModScenarioDir.Length > 1)
        tinitdir = tinitdir.Replace("scenarios", this.game.ModScenarioDir);
      string str = this.game.HandyFunctionsObj.SaveSomething("SE1 Troops&Equipment library(*.se1troops)|*.se1troops", "Give save name...", tinitdir, false);
      if (Strings.Len(str) < 2)
      {
        int num1 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      else
      {
        this.game.FormRef.Cursor = Cursors.WaitCursor;
        this.game.EditObj.TempFileType = NewEnums.LibFileType.LoadTroops;
        this.game.HandyFunctionsObj.ActuallyExportLib(this.LibId).serialize(str);
        this.game.HandyFunctionsObj.ZipFile(str);
        this.game.FormRef.Cursor = Cursors.Default;
        int num2 = (int) Interaction.MsgBox((object) "Completed & Saved", Title: ((object) "Shadow Empire : Planetary Conquest"));
        this.game.EditObj.TempFileType = NewEnums.LibFileType.None;
      }
    }

    public void SaveHisLib()
    {
      string tinitdir = this.game.AppPath + "scenarios\\";
      if (!Information.IsNothing((object) this.game.Data.ScenarioDir))
      {
        if (this.game.Data.ScenarioDir.Length > 1)
          tinitdir = tinitdir.Replace("scenarios", this.game.Data.ScenarioDir);
        else if (this.game.ModScenarioDir.Length > 1)
          tinitdir = tinitdir.Replace("scenarios", this.game.ModScenarioDir);
      }
      else if (this.game.ModScenarioDir.Length > 1)
        tinitdir = tinitdir.Replace("scenarios", this.game.ModScenarioDir);
      string str = this.game.HandyFunctionsObj.SaveSomething("SE1 Historical library(*.se1his)|*.se1his", "Give save name...", tinitdir, false);
      if (Strings.Len(str) < 2)
      {
        int num1 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      else
      {
        this.game.FormRef.Cursor = Cursors.WaitCursor;
        this.game.EditObj.TempFileType = NewEnums.LibFileType.LoadHistoricals;
        this.game.HandyFunctionsObj.ActuallyExportLib(this.LibId).serialize(str);
        this.game.HandyFunctionsObj.ZipFile(str);
        this.game.FormRef.Cursor = Cursors.Default;
        int num2 = (int) Interaction.MsgBox((object) "Completed & Saved", Title: ((object) "Shadow Empire : Planetary Conquest"));
        this.game.EditObj.TempFileType = NewEnums.LibFileType.None;
      }
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
            if (num1 == this.LibListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.LibId = num2;
                this.LibVarId = -1;
                this.CatId = -1;
                this.IndId = -1;
                this.DoStuff();
              }
              else if (num2 == -2)
              {
                this.LibId = -1;
                this.LibVarId = -1;
                this.CatId = -1;
                this.IndId = -1;
                this.DoStuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.saveId)
            {
              this.SaveOfficerLib();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.save2id)
            {
              this.SaveHisLib();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.save3id)
            {
              this.SaveTroopTypeLib();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.save4id)
            {
              this.SaveMap();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.CatListId)
            {
              int num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num3 > -1)
              {
                this.CatId = num3;
                this.IndId = -1;
                if (this.CatId == 4 | this.CatId == 0)
                  this.IndId = 0;
                this.LibVarId = -1;
                this.DoStuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            int num4;
            if (num1 == this.text2id)
            {
              num4 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.IndListId)
            {
              int num5 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num5 > -1)
              {
                this.IndId = num5;
                this.LibVarId = -1;
                this.DoStuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.text1id)
            {
              num4 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.LibVarListId)
            {
              int num6 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num6 > -1)
              {
                this.LibVarId = num6;
                this.DoStuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeValId)
            {
              int tnr = this.game.Data.GetLibVarUseId(this.LibVarId, this.IndId);
              if (!(this.game.Data.LibVarObj[tnr].type == NewEnums.LibVarType.General & this.game.Data.LibVarObj[tnr].type == NewEnums.LibVarType.General) && tnr == this.LibVarId & this.game.Data.LibVarObj[tnr].instanceId.id == -1)
              {
                this.game.Data.AddLibVar(this.game.Data.LibVarObj[this.LibVarId].libId.libSlot);
                this.game.Data.LibVarObj[this.game.Data.LibVarCounter] = this.game.Data.LibVarObj[this.LibVarId].Clone();
                if (this.game.Data.LibVarObj[this.LibVarId].type == NewEnums.LibVarType.SFtype)
                {
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id = this.game.Data.SFTypeObj[this.IndId].LibId.id;
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.libSlot = this.game.Data.SFTypeObj[this.IndId].LibId.libSlot;
                }
                if (this.game.Data.LibVarObj[this.LibVarId].type == NewEnums.LibVarType.Road)
                {
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id = this.IndId;
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.libSlot = -1;
                }
                if (this.game.Data.LibVarObj[this.LibVarId].type == NewEnums.LibVarType.River)
                {
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id = this.IndId;
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.libSlot = -1;
                }
                if (this.game.Data.LibVarObj[this.LibVarId].type == NewEnums.LibVarType.Regime)
                {
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id = this.game.Data.RegimeObj[this.IndId].libId.id;
                  if (this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id == -1)
                    this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id = this.IndId;
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.libSlot = this.game.Data.RegimeObj[this.IndId].libId.libSlot;
                }
                if (this.game.Data.LibVarObj[this.LibVarId].type == NewEnums.LibVarType.People)
                {
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id = this.game.Data.PeopleObj[this.IndId].LibId.id;
                  if (this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id == -1)
                    this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id = this.IndId;
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.libSlot = this.game.Data.PeopleObj[this.IndId].LibId.libSlot;
                }
                if (this.game.Data.LibVarObj[this.LibVarId].type == NewEnums.LibVarType.Officer)
                {
                  if (this.game.Data.HistoricalUnitObj[this.IndId].OffLibId.id > -1)
                  {
                    this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id = this.game.Data.HistoricalUnitObj[this.IndId].OffLibId.id;
                    this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.libSlot = this.game.Data.HistoricalUnitObj[this.IndId].OffLibId.libSlot;
                  }
                  else
                  {
                    this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id = this.game.Data.HistoricalUnitObj[this.IndId].LibId.id;
                    this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.libSlot = this.game.Data.HistoricalUnitObj[this.IndId].LibId.libSlot;
                  }
                }
                if (this.game.Data.LibVarObj[this.LibVarId].type == NewEnums.LibVarType.Landscape)
                {
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id = this.IndId;
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.libSlot = -1;
                }
                if (this.game.Data.LibVarObj[this.LibVarId].type == NewEnums.LibVarType.LocationType)
                {
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id = this.IndId;
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.libSlot = -1;
                }
                if (this.game.Data.LibVarObj[this.LibVarId].type == NewEnums.LibVarType.HistoricalUnitModel)
                {
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id = this.game.Data.HistoricalUnitObj[this.IndId].LibId.id;
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.libSlot = this.game.Data.HistoricalUnitObj[this.IndId].LibId.libSlot;
                }
                if (this.game.Data.LibVarObj[this.LibVarId].type == NewEnums.LibVarType.HistoricalUnit)
                {
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id = this.game.Data.HistoricalUnitObj[this.IndId].LibId.id;
                  if (this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id == -1)
                    this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id = this.IndId;
                  this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.libSlot = this.game.Data.HistoricalUnitObj[this.IndId].LibId.libSlot;
                  if (this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.libSlot == -1)
                    this.game.Data.LibVarObj[this.game.Data.LibVarCounter].instanceId.id = this.IndId;
                }
                tnr = this.game.Data.LibVarCounter;
              }
              if (tnr == -1)
                tnr = this.LibVarId;
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.Number)
              {
                string DefaultResponse = "";
                if (this.game.Data.LibVarObj[tnr].value > 0)
                  DefaultResponse = this.game.Data.LibVarObj[tnr].value.ToString();
                int num7 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new number value for variable", "Shadow Empire : Planetary Conquest", DefaultResponse)));
                this.game.Data.LibVarObj[tnr].value = num7;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.Text)
              {
                string str = Interaction.InputBox("Give new text for variable", "Shadow Empire : Planetary Conquest", this.game.Data.LibVarObj[tnr].valueText);
                this.game.Data.LibVarObj[tnr].valueText = str;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.HistoricalUnitId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 118, tnr, tGame: this.game);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.HistoricalUnitModelId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 119, tnr, tGame: this.game);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.LandscapeId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 120, tnr, tGame: this.game);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.OfficerId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 121, tnr, tGame: this.game);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.PeopleId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 122, tnr, tGame: this.game);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.ActionCardId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 146, tnr, tGame: this.game);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.RegimeId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 123, tnr, tGame: this.game);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.RiverId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 124, tnr, tGame: this.game);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.RoadId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 125, tnr, tGame: this.game);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.LocationTypeId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 128, tnr, tGame: this.game);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.SFTypeId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 126, tnr, tGame: this.game);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.HistoricalUnitId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 118, tnr, tGame: this.game);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.SmallGfxId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 142, tnr, tGame: this.game);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.EventPicId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 143, tnr, tGame: this.game);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.YesNo)
              {
                if (Interaction.MsgBox((object) "Set value of to Yes or No?", MsgBoxStyle.YesNo, (object) "Variable value") == MsgBoxResult.Yes)
                  this.game.Data.LibVarObj[tnr].value = 1;
                else
                  this.game.Data.LibVarObj[tnr].value = 0;
              }
              if (this.game.Data.LibVarObj[tnr].valueType == NewEnums.LibVarValueType.DateString)
              {
                string str1 = Interaction.InputBox("Give new Day.", "Shadow Empire : Planetary Conquest");
                if (Conversions.ToInteger(str1) >= 1 & Conversions.ToInteger(str1) <= 31)
                {
                  string str2 = str1;
                  string str3 = Interaction.InputBox("Give new Month.", "Shadow Empire : Planetary Conquest");
                  if (Conversions.ToInteger(str3) >= 1 & Conversions.ToInteger(str3) <= 12)
                  {
                    string str4 = str2 + "/" + str3;
                    string str5 = Interaction.InputBox("Give new Year.", "Shadow Empire : Planetary Conquest");
                    if (Conversions.ToInteger(str5) >= 1 & Conversions.ToInteger(str5) <= 9999)
                    {
                      string str6 = str4 + "/" + str5;
                      this.game.Data.LibVarObj[tnr].valueText = str6;
                    }
                  }
                }
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.removeEventPic)
            {
              this.game.Data.RemoveEventPic(this.IndId);
              if (this.IndId > this.game.Data.EventPicCounter)
                this.IndId = this.game.Data.EventPicCounter;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.loadEventPic)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps|*.bmp|Jpegs|*.jpg", "Select File For New Event Picture:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.AddEventPic(filename);
              }
              else
              {
                int num8 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.reloadEventPic)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps|*.bmp|Jpegs|*.jpg", "Select File For New Event Picture:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.EventPicReplaceprite(this.IndId, filename);
              }
              else
              {
                int num9 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.removeSmallGfx)
            {
              this.game.Data.RemoveSmallPic(this.IndId);
              if (this.IndId > this.game.Data.EventPicCounter)
                this.IndId = this.game.Data.EventPicCounter;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.loadSmallGfx)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps|*.bmp|Jpegs|*.jpg", "Select File For New Small Gfx:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.AddSmallPic(filename);
              }
              else
              {
                int num10 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.reloadSmallGfx)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps|*.bmp|Jpegs|*.jpg", "Select File For New Small Gfx:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.SmallPicReplaceprite(this.IndId, filename);
              }
              else
              {
                int num11 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ExecuteId)
            {
              this.game.HandyFunctionsObj.RedimStats();
              int regimeCounter = this.game.Data.RegimeCounter;
              for (int regnr = 0; regnr <= regimeCounter; ++regnr)
              {
                this.game.HandyFunctionsObj.ClearHistory((object) regnr);
                this.game.ProcessingObj.SetInitialReconAndZOC(regnr);
              }
              int turn = this.game.Data.Turn;
              this.game.Data.Turn = 0;
              this.game.EventRelatedObj.DoCheckSpecificEvent(this.LibVarId);
              this.game.Data.Turn = turn;
              int num12 = (int) Interaction.MsgBox((object) "Event has been executed", Title: ((object) "Shadow Empire : Planetary Conquest"));
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.RemoveLibEventId)
            {
              if (Interaction.MsgBox((object) "Are you sure? Removing a library will usually cause any stringlist or units or other data related to this  library to be removed from your scenario.", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
              {
                this.game.Data.RemoveLibrary(this.LibId);
                this.game.HandyFunctionsObj.Libraries_ClearUpAllRemnants();
                this.game.EditObj.OldUnit = -1;
                this.game.EditObj.UnitSelected = -1;
                this.LibId = -1;
                this.LibVarId = -1;
                this.CatId = -1;
                this.IndId = -1;
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.loadVarsId)
            {
              string str = this.game.HandyFunctionsObj.LoadSomething("SE1 Event library(*.se1evlib)|*.se1evlib|SE1 Troops&Equipment library(*.se1troops)|*.se1troops|SE1 Historical library(*.se1his)|*.se1his|SE1 Officer Card Library(*.se1offcard)|*.se1offcard|SE1 Officer library(*.se1off)|*.se1off", "Pick file to load libraries from...", this.game.AppPath + this.game.ModScenarioDir, false);
              try
              {
                if (File.Exists(str))
                {
                  this.game.HandyFunctionsObj.Unzip(str);
                  DataClass dataClass = DataClass.deserialize(str);
                  this.game.HandyFunctionsObj.ZipFile(str);
                  int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
                  for (int index2 = 0; index2 <= mapWidth1; ++index2)
                  {
                    int mapHeight = this.game.Data.MapObj[0].MapHeight;
                    for (int index3 = 0; index3 <= mapHeight; ++index3)
                    {
                      for (int hexLibVarCounter = this.game.Data.MapObj[0].HexObj[index2, index3].HexLibVarCounter; hexLibVarCounter >= 0; hexLibVarCounter += -1)
                      {
                        if (this.game.Data.LibVarObj[this.game.Data.MapObj[0].HexObj[index2, index3].HexLibVarSlotNr[hexLibVarCounter]].libId.libSlot == this.LibId)
                          this.game.Data.MapObj[0].HexObj[index2, index3].RemoveHexLibVar(hexLibVarCounter);
                      }
                    }
                  }
                  for (int libVarCounter = this.game.Data.LibVarCounter; libVarCounter >= 0; libVarCounter += -1)
                  {
                    if (this.game.Data.LibVarObj[libVarCounter].libId.libSlot == this.LibId)
                      this.game.Data.RemoveLibVar(libVarCounter);
                  }
                  int libVarCounter1 = dataClass.LibVarCounter;
                  for (int index4 = 0; index4 <= libVarCounter1; ++index4)
                  {
                    int libSlot = dataClass.LibVarObj[index4].libId.libSlot;
                    if (libSlot > -1 && Operators.CompareString(dataClass.LibraryObj[libSlot].name, this.game.Data.LibraryObj[this.LibId].name, false) == 0)
                    {
                      this.game.Data.AddLibVar(this.LibId);
                      this.game.Data.LibVarObj[this.game.Data.LibVarCounter] = dataClass.LibVarObj[index4].Clone();
                    }
                  }
                  int mapWidth2 = dataClass.MapObj[0].MapWidth;
                  for (int index5 = 0; index5 <= mapWidth2; ++index5)
                  {
                    int mapHeight = dataClass.MapObj[0].MapHeight;
                    for (int index6 = 0; index6 <= mapHeight; ++index6)
                    {
                      for (int hexLibVarCounter = dataClass.MapObj[0].HexObj[index5, index6].HexLibVarCounter; hexLibVarCounter >= 0; hexLibVarCounter += -1)
                      {
                        int tLibVarSlotNr = dataClass.MapObj[0].HexObj[index5, index6].HexLibVarSlotNr[hexLibVarCounter];
                        int tValue = dataClass.MapObj[0].HexObj[index5, index6].HexLibVarValue[hexLibVarCounter];
                        if (this.game.Data.LibVarObj[tLibVarSlotNr].libId.libSlot == this.LibId)
                          this.game.Data.MapObj[0].HexObj[index5, index6].AddHexLibVar(tLibVarSlotNr, tValue);
                      }
                    }
                  }
                }
                int num13 = (int) Interaction.MsgBox((object) "Done.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                int num14 = (int) Interaction.MsgBox((object) "Something went wrong. Sorry. Could not execute.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                ProjectData.ClearProjectError();
              }
            }
            else if (num1 == this.AddLibEventId)
            {
              string str = this.game.HandyFunctionsObj.LoadSomething("SE1 Event library(*.se1evlib)|*.se1evlib|SE1 Troops&Equipment library(*.se1troops)|*.se1troops|SE1 Historical library(*.se1his)|*.se1his|SE1 Officer Card Library(*.se1offcard)|*.se1offcard|SE1 Officer library(*.se1off)|*.se1off", "Pick file to load libraries from...", this.game.AppPath + this.game.ModScenarioDir, false);
              if (File.Exists(str))
              {
                this.game.EditObj.TempFileName = str;
                if (Strings.InStr(str, ".se1troops") > 0 & ".se1troops".Length > 0)
                  this.game.EditObj.TempFileType = NewEnums.LibFileType.LoadTroops;
                else if (Strings.InStr(str, ".se1his") > 0 & ".se1his".Length > 0)
                  this.game.EditObj.TempFileType = NewEnums.LibFileType.LoadHistoricals;
                else if (Strings.InStr(str, ".se1evlib") > 0 & ".se1evlib".Length > 0)
                  this.game.EditObj.TempFileType = NewEnums.LibFileType.LoadEvents;
                else if (Strings.InStr(str, ".se1offcard") > 0 & ".se1offcard".Length > 0)
                  this.game.EditObj.TempFileType = NewEnums.LibFileType.LoadOfficerCards;
                else if (Strings.InStr(str, ".se1off") > 0 & ".se1off".Length > 0)
                {
                  this.game.EditObj.TempFileType = NewEnums.LibFileType.LoadOfficers;
                }
                else
                {
                  int num15 = (int) Interaction.MsgBox((object) "Sorry no go. You can only import Troops, Historical, Events, Officer or Officer Card Libraries in the Simple Editor.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                this.LibId = -1;
                this.LibVarId = -1;
                this.CatId = -1;
                this.IndId = -1;
                this.game.EditObj.PopupValue = 17;
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                windowReturnClass.AddCommand(5, 10);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              int num16 = (int) Interaction.MsgBox((object) "Could not find file", Title: ((object) "Shadow Empire : Planetary Conquest"));
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

    public override void HandleToolTip(int x, int y)
    {
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index] && Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
          {
            this.game.EditObj.TipButton = true;
            this.game.EditObj.TipTitle = "";
            this.game.EditObj.TipText = this.SubPartList[index].Descript;
            return;
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

    public void Import()
    {
      string path = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to import libvars from...", this.game.AppPath + this.game.ModScenarioDir, false);
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
      int libVarCounter = dataClass2.LibVarCounter;
      int num2;
      int num3;
      for (int index = 0; index <= libVarCounter; ++index)
      {
        int libSlot = dataClass2.LibVarObj[index].libId.libSlot;
        bool flag = false;
        int library1 = this.game.Data.FindLibrary(dataClass2.LibraryObj[libSlot].name);
        int libVar = this.game.Data.FindLibVar(ref dataClass2.LibVarObj[index], dataClass2.LibraryObj[libSlot].name);
        if (libVar > -1 && this.game.Data.LibVarObj[libVar].valueType == dataClass2.LibVarObj[index].valueType)
        {
          if (this.game.Data.LibVarObj[libVar].type == NewEnums.LibVarType.General)
          {
            this.game.Data.LibVarObj[libVar].value = dataClass2.LibVarObj[index].value;
            this.game.Data.LibVarObj[libVar].valueText = dataClass2.LibVarObj[index].valueText;
            flag = true;
          }
          else if (this.game.Data.LibVarObj[libVar].type != NewEnums.LibVarType.Hex)
          {
            if (this.game.Data.LibVarObj[libVar].type == NewEnums.LibVarType.HistoricalUnit & dataClass2.LibVarObj[index].instanceId.libSlot > -1 & dataClass2.LibVarObj[index].instanceId.id > -1)
            {
              int library2 = this.game.Data.FindLibrary(dataClass2.LibraryObj[dataClass2.LibVarObj[index].instanceId.libSlot].name);
              int id = dataClass2.LibVarObj[index].instanceId.id;
              int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
              for (int slotId = 0; slotId <= historicalUnitCounter; ++slotId)
              {
                if (this.game.Data.HistoricalUnitObj[slotId].LibId.libSlot == library2 && this.game.Data.HistoricalUnitObj[slotId].LibId.id == id)
                {
                  int libVarUseId = this.game.Data.GetLibVarUseId(libVar, slotId);
                  if (libVarUseId == libVar)
                  {
                    this.game.Data.AddLibVar(library1);
                    this.game.Data.LibVarObj[this.game.Data.LibVarCounter] = this.game.Data.LibVarObj[libVar].Clone();
                    this.game.Data.LibVarObj[libVarUseId].value = dataClass2.LibVarObj[index].value;
                    this.game.Data.LibVarObj[libVarUseId].valueText = dataClass2.LibVarObj[index].valueText;
                    this.game.Data.LibVarObj[libVarUseId].instanceId.libSlot = library2;
                    this.game.Data.LibVarObj[libVarUseId].instanceId.id = id;
                  }
                  else
                  {
                    this.game.Data.LibVarObj[libVarUseId].value = dataClass2.LibVarObj[index].value;
                    this.game.Data.LibVarObj[libVarUseId].valueText = dataClass2.LibVarObj[index].valueText;
                    flag = true;
                  }
                }
              }
            }
            else if (this.game.Data.LibVarObj[libVar].type != NewEnums.LibVarType.HistoricalUnitModel && this.game.Data.LibVarObj[libVar].type != NewEnums.LibVarType.Landscape && this.game.Data.LibVarObj[libVar].type != NewEnums.LibVarType.LocationType && this.game.Data.LibVarObj[libVar].type != NewEnums.LibVarType.Officer && this.game.Data.LibVarObj[libVar].type != NewEnums.LibVarType.People)
            {
              if (this.game.Data.LibVarObj[libVar].type == NewEnums.LibVarType.Regime)
              {
                int library3 = this.game.Data.FindLibrary(dataClass2.LibraryObj[dataClass2.LibVarObj[index].instanceId.libSlot].name);
                int id = dataClass2.LibVarObj[index].instanceId.id;
                int regimeCounter = this.game.Data.RegimeCounter;
                for (int slotId = 0; slotId <= regimeCounter; ++slotId)
                {
                  if (this.game.Data.RegimeObj[slotId].libId.libSlot == library3 && this.game.Data.RegimeObj[slotId].libId.id == id)
                  {
                    int libVarUseId = this.game.Data.GetLibVarUseId(libVar, slotId);
                    if (libVarUseId == libVar)
                    {
                      this.game.Data.AddLibVar(library1);
                      this.game.Data.LibVarObj[this.game.Data.LibVarCounter] = this.game.Data.LibVarObj[libVar].Clone();
                      this.game.Data.LibVarObj[libVarUseId].value = dataClass2.LibVarObj[index].value;
                      this.game.Data.LibVarObj[libVarUseId].valueText = dataClass2.LibVarObj[index].valueText;
                      this.game.Data.LibVarObj[libVarUseId].instanceId.libSlot = library3;
                      this.game.Data.LibVarObj[libVarUseId].instanceId.id = id;
                    }
                    else
                    {
                      this.game.Data.LibVarObj[libVarUseId].value = dataClass2.LibVarObj[index].value;
                      this.game.Data.LibVarObj[libVarUseId].valueText = dataClass2.LibVarObj[index].valueText;
                      flag = true;
                    }
                  }
                }
              }
              else if (this.game.Data.LibVarObj[libVar].type == NewEnums.LibVarType.River || this.game.Data.LibVarObj[libVar].type == NewEnums.LibVarType.Road || this.game.Data.LibVarObj[libVar].type != NewEnums.LibVarType.SFtype)
                ;
            }
          }
        }
        if (flag)
          ++num2;
        else
          ++num3;
      }
      dataClass1 = (DataClass) null;
      this.game.EditObj.UnitSelected = -1;
      this.game.EditObj.OldUnit = -1;
      this.game.FormRef.Cursor = Cursors.Default;
      int num4 = (int) Interaction.MsgBox((object) ("Import completed succesfully. Imported " + num2.ToString() + " libvars and skipped " + num3.ToString() + "."), Title: ((object) "Shadow Empire : Planetary Conquest"));
    }
  }
}
