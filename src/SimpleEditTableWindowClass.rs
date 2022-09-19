// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleEditTableWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingMicrosoft.VisualBasic.CompilerServices;
// usingSystem;
// usingSystem.Drawing;
// usingSystem.Drawing.Drawing2D;
// usingSystem.Drawing.Text;
// usingSystem.IO;
// usingSystem.Windows.Forms;

namespace WindowsApplication1
{
  pub class SimpleEditTableWindowClass : WindowClass
  {
     int listId;
     ListClass listObj;
     ListClass libListObj;
     int libTableId;
     int tableId;
     int text1id;
     int addId;
     int remId;
     int remIdb;
     int editId;
     int editidb;
     int importCsv;
     int exportCsv;
     int strId;
     int detailx;
     int detaily;
     int cellinfoid;
     int libSelect;
     int switchId;
     int fullForwardId;
     int forwardId;
     int backwardId;
     int fullBackwardId;
     int mode;
     int pageNumberId;

    pub SimpleEditTableWindowClass( GameClass tGame)
      : base( tGame, tGame.ScreenWidth, tGame.ScreenHeight - 50, 9, tDoBorders: 1, tHeaderString: "Tables")
    {
      this.strId = -1;
      this.detailx = -1;
      this.detaily = -1;
      this.libSelect = -1;
      this.mode = 1;
      this.DoStuff();
    }

    pub void RefreshCellInfo()
    {
      if (this.cellinfoid > 0)
      {
        this.RemoveSubPart(this.cellinfoid);
        this.cellinfoid = 0;
      }
      string txt;
      if (this.detaily == -1 | this.detailx == -1)
        txt = "No cell selected";
      else if (this.strId > -1)
        txt = "(row" + this.detailx.ToString() + ",col" + this.detaily.ToString() + ")             " + this.game.Data.StringListObj[this.strId].ColumnName[this.detaily].ToUpper() + "                " + this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily];
      let mut tsubpart: SubPartClass =  TextPartClass::new(txt, this.game.MarcFont4, this.game.ScreenWidth - 23, 20, false, tMarc: true);
      this.cellinfoid = this.AddSubPart( tsubpart, 12, 49, this.game.ScreenWidth - 32, 20, 0);
    }

    pub void DoRefresh() => this.DoStuff();

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false)
    {
      windowReturnClass1: WindowReturnClass = WindowReturnClass::new();
      if (this.strId == -1)
        return windowReturnClass1;
      if ((nr == 32 | nr == 13) & this.detailx > -1 & this.editId > 0)
      {
        windowReturnClass2: WindowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.editId)] + 1, this.SubPartY[this.SubpartNr(this.editId)] + 1, 1);
        windowReturnClass2.SetFlag(true);
        return windowReturnClass2;
      }
      if (nr == 38 & this.detailx > 0)
      {
        --this.detailx;
        this.RefreshCellInfo();
        let mut index: i32 = this.SubpartNr(this.tableId);
        if (index > -1)
          this.SubPartFlag[index] = true;
        if (index > -1)
          this.SubPartList[index].Refresh(this.game.Data.StringListObj[this.strId], this.detailx, this.detaily);
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (nr == 40 & this.detailx < this.game.Data.StringListObj[this.strId].Length)
      {
        this += 1.detailx;
        this.RefreshCellInfo();
        let mut index: i32 = this.SubpartNr(this.tableId);
        if (index > -1)
          this.SubPartFlag[index] = true;
        if (index > -1)
          this.SubPartList[index].Refresh(this.game.Data.StringListObj[this.strId], this.detailx, this.detaily);
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (this.mode == 1)
      {
        if (nr == 37 & this.detaily > 0)
        {
          --this.detaily;
          this.RefreshCellInfo();
          let mut index: i32 = this.SubpartNr(this.tableId);
          if (index > -1)
            this.SubPartFlag[index] = true;
          if (index > -1)
            this.SubPartList[index].Refresh(this.game.Data.StringListObj[this.strId], this.detailx, this.detaily);
          windowReturnClass1.SetFlag(true);
          return windowReturnClass1;
        }
        if (nr == 39 & this.detaily < this.game.Data.StringListObj[this.strId].Width)
        {
          this += 1.detaily;
          this.RefreshCellInfo();
          let mut index: i32 = this.SubpartNr(this.tableId);
          if (index > -1)
            this.SubPartFlag[index] = true;
          if (index > -1)
            this.SubPartList[index].Refresh(this.game.Data.StringListObj[this.strId], this.detailx, this.detaily);
          windowReturnClass1.SetFlag(true);
          return windowReturnClass1;
        }
      }
      return windowReturnClass1;
    }

    pub void DoStuff()
    {
      let mut num1: i32 =  Math.Round( (this.game.ScreenWidth - 1024) / 2.0);
      let mut num2: i32 = this.game.ScreenHeight - 768;
      if (this.addId > 0)
        this.RemoveSubPart(this.addId);
      if (this.remId > 0)
        this.RemoveSubPart(this.remId);
      if (this.remIdb > 0)
        this.RemoveSubPart(this.remIdb);
      if (this.editId > 0)
        this.RemoveSubPart(this.editId);
      if (this.editidb > 0)
        this.RemoveSubPart(this.editidb);
      if (this.tableId > 0)
        this.RemoveSubPart(this.tableId);
      if (this.importCsv > 0)
        this.RemoveSubPart(this.importCsv);
      if (this.exportCsv > 0)
        this.RemoveSubPart(this.exportCsv);
      if (this.text1id > 0)
        this.RemoveSubPart(this.text1id);
      if (this.listId > 0)
      {
        this.RemoveSubPart(this.listId);
        this.listId = 0;
      }
      if (this.libTableId > 0)
      {
        this.RemoveSubPart(this.libTableId);
        this.libTableId = 0;
      }
      if (this.cellinfoid > 0)
      {
        this.RemoveSubPart(this.cellinfoid);
        this.cellinfoid = 0;
      }
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.TextContrast = 1;
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 50, -1);
      let mut num3: i32 = -1;
      int num4;
      if (num2 > 10)
        num4 =  Math.Round( (num2 - 10) * 0.33 / 16.0);
      this.libListObj = ListClass::new();
      this.libListObj.add("All", -2);
      if (this.libSelect == -1)
        num3 = 0;
      let mut num5: i32 = 0;
      if (num1 >= 256)
      {
        DrawMod.DrawTextColouredMarc( objgraphics, "Libraries:", this.game.MarcFont4, 10 + num1 - 256,  Math.Round(72.0 + (15.0 +   Math.Round( num2 * 0.66) / 24.0) * 24.0 + 55.0 + 30.0), Color.White);
        let mut libraryCounter: i32 = this.game.Data.LibraryCounter;
        for (let mut index1: i32 = 0; index1 <= libraryCounter; index1 += 1)
        {
          bool flag = false;
          let mut stringListCounter: i32 = this.game.Data.StringListCounter;
          for (let mut index2: i32 = 0; index2 <= stringListCounter; index2 += 1)
          {
            if (this.game.Data.StringListObj[index2].LibId.libSlot == index1 && this.game.Data.StringListObj[index2].Editable)
            {
              flag = true;
              break;
            }
          }
          if (flag)
          {
            num5 += 1;
            this.libListObj.add(Conversion.Str( index1) + ") " + this.game.Data.LibraryObj[index1].name, index1);
            if (this.libSelect == index1)
              num3 = num5;
          }
        }
        if (this.libListObj.ListCount > 0)
        {
          ListClass libListObj = this.libListObj;
          let mut tlistsize: i32 = 9 + num4;
          let mut tlistselect: i32 = num3;
          let mut game: GameClass = this.game;
           Bitmap local1 =  this.OwnBitmap;
          let mut bbx: i32 = 10 + num1 - 256;
          let mut bby: i32 =  Math.Round(72.0 + (15.0 +   Math.Round( num2 * 0.66) / 24.0) * 24.0 + 55.0 + 50.0);
          Font font =  null;
           Font local2 =  font;
          let mut tsubpart: SubPartClass =  new ListSubPartClass(libListObj, tlistsize, 250, tlistselect, game, true, "Tables", tValueWidth: 0, tdotopandbottom: false, tbackbitmap: ( local1), bbx: bbx, bby: bby, tMarcStyle: true, overruleFont: ( local2));
          this.libTableId = this.AddSubPart( tsubpart, 10 + num1 - 256,  Math.Round(72.0 + (15.0 +   Math.Round( num2 * 0.66) / 24.0) * 24.0 + 55.0 + 50.0), 250, (12 + num4) * 16, 0);
        }
      }
      tstring: String = "Tables:";
      DrawMod.DrawTextColouredMarc( objgraphics, tstring, this.game.MarcFont4, 10 + num1,  Math.Round(72.0 + (15.0 +   Math.Round( num2 * 0.66) / 24.0) * 24.0 + 55.0 + 30.0), Color.White);
      let mut num6: i32 = -1;
      let mut num7: i32 = -1;
      this.listObj = ListClass::new();
      let mut stringListCounter1: i32 = this.game.Data.StringListCounter;
      for (let mut index: i32 = 0; index <= stringListCounter1; index += 1)
      {
        if (this.game.Data.StringListObj[index].Editable && this.game.Data.StringListObj[index].LibId.libSlot == this.libSelect | this.libSelect == -1)
        {
          num6 += 1;
          this.listObj.add(Conversion.Str( index) + ") " + this.game.Data.StringListObj[index].Name, index);
          if (num7 == -1)
            num7 = 0;
          if (this.strId == -1)
            this.strId = index;
          if (this.strId == index)
            num7 = num6;
        }
      }
      if (num7 > num6)
        num7 = 0;
      if (num7 == -1)
        this.strId = -1;
      SubPartClass tsubpart1;
      if (this.game.Data.StringListCounter > -1)
      {
        ListClass listObj = this.listObj;
        let mut tlistsize: i32 = 9 + num4;
        let mut tlistselect: i32 = num7;
        let mut game: GameClass = this.game;
         Bitmap local3 =  this.OwnBitmap;
        let mut bbx: i32 = 10 + num1;
        let mut bby: i32 =  Math.Round(72.0 + (15.0 +   Math.Round( num2 * 0.66) / 24.0) * 24.0 + 55.0 + 50.0);
        Font font =  null;
         Font local4 =  font;
        tsubpart1 =  new ListSubPartClass(listObj, tlistsize, 250, tlistselect, game, true, "Tables", tValueWidth: 0, tdotopandbottom: false, tbackbitmap: ( local3), bbx: bbx, bby: bby, tMarcStyle: true, overruleFont: ( local4));
        this.listId = this.AddSubPart( tsubpart1, 10 + num1,  Math.Round(72.0 + (15.0 +   Math.Round( num2 * 0.66) / 24.0) * 24.0 + 55.0 + 50.0), 250, (12 + num4) * 16, 0);
      }
      if (this.strId <= -1)
        return;
      if (this.mode == 1)
      {
        tsubpart1 =  new MatrixSubPartClass(this.game.Data.StringListObj[this.strId], 13 +  Math.Round( num2 * 0.66 / 24.0), Math.Max(1000, this.game.ScreenWidth - 24), this.detailx, this.detaily, this.game, tbackbitmap: ( this.BackBitmap), bbx: 10, bby: 72, trowheight: 24, tfontsize: 16, tfontoffsety: 4, tMarcy: true, tLibSlot: this.game.Data.StringListObj[this.strId].LibId.libSlot);
        this.tableId = this.AddSubPart( tsubpart1, 10, 72, Math.Max(1000, this.game.ScreenWidth - 24),  Math.Round((15.0 +   Math.Round( num2 * 0.66) / 24.0) * 24.0), 0);
      }
      else
      {
        if (this.detailx > this.game.Data.StringListObj[this.strId].Length | this.detailx == -1 & this.game.Data.StringListObj[this.strId].Length > -1)
          this.detailx = 0;
        if (this.detailx > -1 & this.detailx <= this.game.Data.StringListObj[this.strId].Length)
        {
          StringListClass tListobj = new StringListClass(-9999);
          tListobj.AddCol(0, "Column Name");
          tListobj.AddCol(1, "Value");
          let mut width: i32 = this.game.Data.StringListObj[this.strId].Width;
          for (let mut col: i32 = 0; col <= width; col += 1)
          {
            LibVarClass libVarClass = this.game.Data.StringListObj[this.strId].GetValue( this.game.Data, this.detailx, col);
            tListobj.AddRowWithData(this.game.Data.StringListObj[this.strId].ColumnName[col], libVarClass.valueText);
          }
          tsubpart1 =  new MatrixSubPartClass(tListobj, 13 +  Math.Round( num2 * 0.66 / 24.0), Math.Max(1000, this.game.ScreenWidth - 24), this.detaily, 1, this.game, tbackbitmap: ( this.BackBitmap), bbx: 10, bby: 72, trowheight: 24, tfontsize: 16, tfontoffsety: 4, tMarcy: true, tTwoColumnVariant: 200);
          this.tableId = this.AddSubPart( tsubpart1, 10, 72, Math.Max(1000, this.game.ScreenWidth - 24),  Math.Round((15.0 +   Math.Round( num2 * 0.66) / 24.0) * 24.0), 0);
        }
        else
          DrawMod.DrawTextColouredMarcCenter( objgraphics, "No rows in table", this.game.MarcFont4, num1 + 512, 256 +  Math.Round( num2 * 0.33), Color.White);
      }
      str1: String = " (Id " + this.game.Data.StringListObj[this.strId].ID.ToString();
      if (this.game.Data.StringListObj[this.strId].LibId.libSlot > -1)
        str1 = str1 + ", LibId " + this.game.Data.StringListObj[this.strId].ID.ToString();
      str2: String = str1 + ")";
      DrawMod.DrawTextColouredMarc( objgraphics, this.game.Data.StringListObj[this.strId].Name + str2 + " information:", this.game.MarcFont3, 310 + num1, 72 + (15 +  Math.Round( num2 * 0.66 / 24.0)) * 24 + 55 + 30, Color.White);
      tsubpart1 =  new TextAreaClass2(this.game,  Math.Round(Math.Max(700.0,  this.game.ScreenWidth / 2.0 - 324.0)), 4 +  Math.Round( num2 * 0.33 / 27.0), this.game.MarcFont4, this.game.Data.StringListObj[this.strId].Description, 27,  this.OwnBitmap, 310 + num1,  Math.Round(72.0 + (15.0 +   Math.Round( num2 * 0.66) / 24.0) * 24.0 + 62.0 + 30.0));
      this.text1id = this.AddSubPart( tsubpart1, 310 + num1,  Math.Round(72.0 + (15.0 +   Math.Round( num2 * 0.66) / 24.0) * 24.0 + 62.0 + 30.0),  Math.Round(Math.Max(700.0,  this.game.ScreenWidth / 2.0 - 324.0)), Math.Max(120, this.game.ScreenHeight - 648), 0);
      this.Tabby();
      if (!(this.detailx > -1 & this.detaily > -1 & !Information.IsNothing( this.tableId)))
        return;
      this.RefreshCellInfo();
    }

    pub void Tabby()
    {
      if (this.addId > 0)
        this.RemoveSubPart(this.addId);
      if (this.remId > 0)
        this.RemoveSubPart(this.remId);
      if (this.remIdb > 0)
        this.RemoveSubPart(this.remIdb);
      if (this.editId > 0)
        this.RemoveSubPart(this.editId);
      if (this.editidb > 0)
        this.RemoveSubPart(this.editidb);
      if (this.importCsv > 0)
        this.RemoveSubPart(this.importCsv);
      if (this.exportCsv > 0)
        this.RemoveSubPart(this.exportCsv);
      if (this.switchId > 0)
        this.RemoveSubPart(this.switchId);
      if (this.forwardId > 0)
        this.RemoveSubPart(this.forwardId);
      if (this.backwardId > 0)
        this.RemoveSubPart(this.backwardId);
      if (this.fullForwardId > 0)
        this.RemoveSubPart(this.fullForwardId);
      if (this.fullBackwardId > 0)
        this.RemoveSubPart(this.fullBackwardId);
      if (this.pageNumberId > 0)
        this.RemoveSubPart(this.pageNumberId);
      let mut num1: i32 =  Math.Round( (this.game.ScreenWidth - 1024) / 2.0);
      let mut num2: i32 = this.game.ScreenHeight - 768;
      if (this.strId < 0)
        return;
      let mut num3: i32 =  Math.Round(72.0 + (15.0 +   Math.Round( num2 * 0.66) / 24.0) * 24.0 + 28.0);
      SubPartClass tsubpart;
      if (this.mode == 1)
      {
        tsubpart =  new TextButtonPartClass("=> Records", 150, tBackbitmap: ( this.OwnBitmap), bbx: (330 + num1), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.switchId = this.AddSubPart( tsubpart, 330 + num1, num3, 150, 35, 1);
      }
      else
      {
        tsubpart =  new TextButtonPartClass("=> Table", 150, tBackbitmap: ( this.OwnBitmap), bbx: (330 + num1), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.switchId = this.AddSubPart( tsubpart, 330 + num1, num3, 150, 35, 1);
        tDescript: String = "";
        tsubpart =  new TextButtonPartClass("<<", 40, tDescript,  this.OwnBitmap, 10 + num1, num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.fullBackwardId = this.AddSubPart( tsubpart, 10 + num1, num3, 40, 35, 1);
        tsubpart =  new TextButtonPartClass("<", 40, tDescript,  this.OwnBitmap, 50 + num1, num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.backwardId = this.AddSubPart( tsubpart, 50 + num1, num3, 40, 35, 1);
        tsubpart =  new TextButtonPartClass(">", 40, tDescript,  this.OwnBitmap, 230 + num1, num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.forwardId = this.AddSubPart( tsubpart, 230 + num1, num3, 40, 35, 1);
        tsubpart =  new TextButtonPartClass(">>", 40, tDescript,  this.OwnBitmap, 270 + num1, num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.fullForwardId = this.AddSubPart( tsubpart, 270 + num1, num3, 40, 35, 1);
        txt: String = this.detailx.ToString() + " / " + this.game.Data.StringListObj[this.strId].Length.ToString();
        if (this.game.Data.StringListObj[this.strId].Length == -1)
          txt = "No rows";
        tsubpart =  TextPartClass::new(txt, this.game.MarcFont4, 120, 35, true, tBlackBack: true, tMarc: true);
        this.pageNumberId = this.AddSubPart( tsubpart, 100 + num1, num3, 120, 35, 0);
      }
      if (this.detailx > -1 & this.detaily > -1)
      {
        tsubpart =  new TextButtonPartClass("Edit cell", 150, tBackbitmap: ( this.OwnBitmap), bbx: (830 + num1), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.editId = this.AddSubPart( tsubpart, 830 + num1, num3, 150, 35, 1);
      }
      else
      {
        tsubpart =  new TextButtonPartClass("Edit cell", 150, "First select a cell you want to edit the value of",  this.OwnBitmap, 830 + num1, num3, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.editidb = this.AddSubPart( tsubpart, 830 + num1, num3, 150, 35, 1);
      }
      tsubpart =  new TextButtonPartClass("Add row", 150, tBackbitmap: ( this.OwnBitmap), bbx: (510 + num1), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.addId = this.AddSubPart( tsubpart, 510 + num1, num3, 150, 35, 1);
      if (this.detaily > -1)
      {
        tsubpart =  new TextButtonPartClass("Remove row", 150, tBackbitmap: ( this.OwnBitmap), bbx: (670 + num1), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.remId = this.AddSubPart( tsubpart, 670 + num1, num3, 150, 35, 1);
      }
      else
      {
        tsubpart =  new TextButtonPartClass("Remove row", 150, "First select a row you want to remove",  this.OwnBitmap, 670 + num1, num3, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.remIdb = this.AddSubPart( tsubpart, 670 + num1, num3, 150, 35, 1);
      }
      if (this.mode != 1)
        return;
      tsubpart =  new TextButtonPartClass("Import Csv", 150, tBackbitmap: ( this.OwnBitmap), bbx: (10 + num1), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.importCsv = this.AddSubPart( tsubpart, 10 + num1, num3, 150, 35, 1);
      tsubpart =  new TextButtonPartClass("Export Csv", 150, tBackbitmap: ( this.OwnBitmap), bbx: (170 + num1), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.exportCsv = this.AddSubPart( tsubpart, 170 + num1, num3, 150, 35, 1);
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass1: WindowReturnClass = WindowReturnClass::new();
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 = this.SubPartCounter;
        for (let mut index1: i32 = 0; index1 <= subPartCounter; index1 += 1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            let mut num1: i32 = this.SubPartID[index1];
            if (num1 == this.editId)
            {
              if (this.detaily > -1 && this.game.Data.StringListObj[this.strId].LookUpCol[this.detaily] > 0)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 150, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.RegimeId)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 106, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.HistoricalUnitId)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 144, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.HistoricalUnitModelId)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 111, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.OfficerId)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 112, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.LandscapeId)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 113, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.PeopleId)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 114, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.RiverId)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 115, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.LocationTypeId)
              {
                Form3::new( this.formref).Initialize(this.game.Data,  sbyte.MaxValue, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.RoadId)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 116, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.SFTypeId)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 145, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.ActionCardId)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 146, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.SmallGfxId)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 140, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.EventPicId)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 141, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.DateString)
              {
                if (this.game.Data.AlternateRound < 1)
                {
                  this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily] = Interaction.InputBox("Give round number", "Shadow Empire : Planetary Conquest");
                }
                else
                {
                  str1: String = Interaction.InputBox("Give new Day.", "Shadow Empire : Planetary Conquest");
                  this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily] = "";
                  if (Operators.CompareString(str1, "", false) != 0)
                  {
                    str2: String = Conversions.ToString(Conversion.Val(str1));
                    if (Conversions.ToInteger(str2) >= 1 & Conversions.ToInteger(str2) <= 31)
                    {
                      str3: String = str2;
                      str4: String = Interaction.InputBox("Give new Month.", "Shadow Empire : Planetary Conquest");
                      if (Operators.CompareString(str4, "", false) != 0)
                      {
                        str5: String = Conversions.ToString(Conversion.Val(str4));
                        if (Conversions.ToInteger(str5) >= 1 & Conversions.ToInteger(str5) <= 12)
                        {
                          str6: String = str3 + "/" + str5;
                          str7: String = Interaction.InputBox("Give new Year.", "Shadow Empire : Planetary Conquest");
                          if (Operators.CompareString(str7, "", false) != 0)
                          {
                            str8: String = Conversions.ToString(Conversion.Val(str7));
                            if (Conversions.ToInteger(str8) >= 1 & Conversions.ToInteger(str8) <= 9999)
                              this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily] = str6 + "/" + str8;
                          }
                        }
                      }
                    }
                  }
                }
                if (this.mode == 2)
                  this.DoStuff();
                let mut index2: i32 = this.SubpartNr(this.tableId);
                if (index2 > -1)
                  this.SubPartFlag[index2] = true;
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.YesNo)
              {
                if (Interaction.MsgBox( "Set value of cell to Yes or No?", MsgBoxStyle.YesNo,  "Cell value") == MsgBoxResult.Yes)
                  this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily] = "1";
                else
                  this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily] = "0";
                if (this.mode == 2)
                  this.DoStuff();
                let mut index3: i32 = this.SubpartNr(this.tableId);
                if (index3 > -1)
                  this.SubPartFlag[index3] = true;
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily] = Interaction.InputBox("Give new value of cell, please.", "Shadow Empire : Planetary Conquest", this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily]);
              if (this.mode == 2)
                this.DoStuff();
              let mut index4: i32 = this.SubpartNr(this.tableId);
              if (index4 > -1)
                this.SubPartFlag[index4] = true;
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.remId)
            {
              this.game.Data.StringListObj[this.strId].RemoveRow(this.detailx);
              if (this.detailx > this.game.Data.StringListObj[this.strId].Length)
                this.detailx = this.game.Data.StringListObj[this.strId].Length;
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.addId)
            {
              int index5;
              if (this.detailx == -1)
              {
                this.game.Data.StringListObj[this.strId].AddRow(this.game.Data.StringListObj[this.strId].Length);
                index5 = this.game.Data.StringListObj[this.strId].Length;
              }
              else
              {
                this.game.Data.StringListObj[this.strId].AddRow(this.detailx);
                index5 = this.detailx + 1;
              }
              if (this.game.Data.Product == 7)
              {
                let mut width1: i32 = this.game.Data.StringListObj[this.strId].Width;
                for (let mut index6: i32 = 0; index6 <= width1; index6 += 1)
                {
                  if (this.game.Data.StringListObj[this.strId].SSID[index6] > 0 & this.game.Data.StringListObj[this.strId].SSID[index6] < 50)
                  {
                    let mut num2: i32 = 0;
                    let mut stringListCounter: i32 = this.game.Data.StringListCounter;
                    for (let mut index7: i32 = 0; index7 <= stringListCounter; index7 += 1)
                    {
                      if (this.game.Data.StringListObj[index7].Length > -1)
                      {
                        let mut width2: i32 = this.game.Data.StringListObj[index7].Width;
                        for (let mut index8: i32 = 0; index8 <= width2; index8 += 1)
                        {
                          if (this.game.Data.StringListObj[index7].SSID[index8] > 0 & this.game.Data.StringListObj[index7].SSID[index8] < 50)
                          {
                            let mut length: i32 = this.game.Data.StringListObj[index7].Length;
                            for (let mut index9: i32 = 0; index9 <= length; index9 += 1)
                            {
                              let mut num3: i32 =  Math.Round(Conversion.Val(this.game.Data.StringListObj[index7].Data[index9, index8]));
                              if (num3 > num2)
                                num2 = num3;
                            }
                          }
                        }
                      }
                    }
                    num2 += 1;
                    this.game.Data.StringListObj[this.strId].Data[index5, index6] = num2.ToString();
                  }
                }
              }
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.forwardId)
            {
              this += 1.detailx;
              if (this.detailx > this.game.Data.StringListObj[this.strId].Length)
                this.detailx = this.game.Data.StringListObj[this.strId].Length;
              this.Tabby();
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.backwardId)
            {
              --this.detailx;
              if (this.detailx < 0)
                this.detailx = 0;
              if (this.detailx > this.game.Data.StringListObj[this.strId].Length)
                this.detailx = this.game.Data.StringListObj[this.strId].Length;
              this.Tabby();
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.fullForwardId)
            {
              this.detailx = this.game.Data.StringListObj[this.strId].Length;
              this.Tabby();
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.fullBackwardId)
            {
              this.detailx = 0;
              if (this.detailx > this.game.Data.StringListObj[this.strId].Length)
                this.detailx = this.game.Data.StringListObj[this.strId].Length;
              this.Tabby();
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.switchId)
            {
              this.mode = this.mode != 1 ? 1 : 2;
              this.Tabby();
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.tableId)
            {
              Coordinate coordinate = this.SubPartList[index1].Click2(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (coordinate.x > -1)
              {
                if (this.mode == 1)
                {
                  this.detailx = coordinate.x;
                  this.detaily = coordinate.y;
                  if (this.detaily > this.game.Data.StringListObj[this.strId].Width)
                    this.detaily = this.game.Data.StringListObj[this.strId].Width;
                  if (this.detailx > this.game.Data.StringListObj[this.strId].Length)
                    this.detailx = this.game.Data.StringListObj[this.strId].Length;
                }
                else
                {
                  this.detaily = coordinate.x;
                  if (this.detaily > this.game.Data.StringListObj[this.strId].Width)
                    this.detaily = this.game.Data.StringListObj[this.strId].Width;
                }
                this.RefreshCellInfo();
                this.Tabby();
              }
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.text1id)
            {
              this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.listId)
            {
              let mut num4: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num4 > -1)
              {
                this.strId = num4;
                this.detailx = -1;
                this.detaily = -1;
                this.DoStuff();
              }
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.libTableId)
            {
              let mut num5: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num5 > -1)
              {
                this.libSelect = num5;
                this.strId = -1;
                this.detailx = -1;
                this.detaily = -1;
                this.DoStuff();
              }
              else if (num5 == -2)
              {
                this.libSelect = -1;
                this.detailx = -1;
                this.detaily = -1;
                this.DoStuff();
              }
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.importCsv)
            {
              str9: String = this.game.HandyFunctionsObj.LoadSomething("CSV (*.csv)|*.csv|TXT (*.txt)|*.txt|All (*.*)|*.*", "Select file to import...", this.game.AppPath + "csv/", false);
              while (this.game.Data.StringListObj[this.strId].Length > -1)
                this.game.Data.StringListObj[this.strId].RemoveRow(this.game.Data.StringListObj[this.strId].Length);
              if (Strings.Len(str9) < 2)
              {
                let mut num6: i32 =  Interaction.MsgBox( "Operation is Cancelled", Title: ( "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                windowReturnClass2: WindowReturnClass;
                try
                {
                  StreamReader streamReader = File.OpenText(str9);
                  let mut num7: i32 = 0;
                  str10: String = ",";
                  let mut index10: i32 = 0;
                  try
                  {
                    bool flag1 = false;
                    if (this.game.Data.Product >= 7 && Interaction.MsgBox( "Inverse import?", MsgBoxStyle.YesNo,  "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                    {
                      flag1 = true;
                      num7 = 2;
                    }
                    while (!streamReader.EndOfStream)
                    {
                      str11: String = streamReader.ReadLine();
                      if ((uint) Strings.InStr(str11, "sep=") > 0U)
                      {
                        str10 = Strings.Mid(str11, 5, 1);
                        num7 = 1;
                      }
                      else
                      {
                        switch (num7)
                        {
                          case 0:
                            if (Strings.InStr(str11, "\t") > 0)
                              str10 = "\t";
                            else if (Strings.InStr(str11, ",") > 0)
                              str10 = ",";
                            else if (Strings.InStr(str11, ";") > 0)
                              str10 = ";";
                            num7 = 2;
                            continue;
                          case 1:
                            num7 = 2;
                            continue;
                          case 2:
                            bool flag2 = true;
                            while (flag2)
                            {
                              flag2 = false;
                              let mut num8: i32 = Strings.InStr(str11, "\"");
                              if (num8 > 0)
                              {
                                let mut num9: i32 = Strings.InStr(num8 + 1, str11, "\"");
                                if (num9 > 0)
                                {
                                  str12: String = Strings.Left(str11, num8 - 1);
                                  str13: String = Strings.Mid(str11, num8 + 1, num9 - num8 - 1);
                                  str14: String = Strings.Mid(str11, num9 + 1);
                                  str15: String = str13.Replace(",", "¢");
                                  str11 = str12 + str15 + str14;
                                  flag2 = true;
                                }
                              }
                            }
                            string[] strArray = str11.Split(Conversions.ToChar(str10));
                            if (!flag1 && strArray.GetUpperBound(0) > this.game.Data.StringListObj[this.strId].Width & index10 == 0 && Interaction.MsgBox( "Allow adding columns to table?", MsgBoxStyle.YesNo,  "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                            {
                              let mut num10: i32 = strArray.GetUpperBound(0) - this.game.Data.StringListObj[this.strId].Width;
                              for (let mut index11: i32 = 1; index11 <= num10; index11 += 1)
                                this.game.Data.StringListObj[this.strId].AddCol(this.game.Data.StringListObj[this.strId].Width);
                            }
                            if (!flag1)
                            {
                              this.game.Data.StringListObj[this.strId].AddRow(index10 - 1);
                              let mut upperBound: i32 = strArray.GetUpperBound(0);
                              for (let mut index12: i32 = 0; index12 <= upperBound; index12 += 1)
                              {
                                if (index12 <= this.game.Data.StringListObj[this.strId].Width)
                                {
                                  str16: String = strArray[index12].Replace("¢", ",");
                                  this.game.Data.StringListObj[this.strId].Data[index10, index12] = str16;
                                }
                              }
                            }
                            else
                            {
                              if (index10 > this.game.Data.StringListObj[this.strId].Width)
                                this.game.Data.StringListObj[this.strId].AddCol(this.game.Data.StringListObj[this.strId].Width);
                              let mut upperBound: i32 = strArray.GetUpperBound(0);
                              for (let mut index13: i32 = 0; index13 <= upperBound; index13 += 1)
                              {
                                if (index13 - 1 > this.game.Data.StringListObj[this.strId].Length)
                                  this.game.Data.StringListObj[this.strId].AddRow(this.game.Data.StringListObj[this.strId].Length);
                                str17: String = strArray[index13].Replace("¢", ",");
                                if (index13 == 0)
                                  this.game.Data.StringListObj[this.strId].ColumnName[index10] = str17;
                                else
                                  this.game.Data.StringListObj[this.strId].Data[index13 - 1, index10] = str17;
                              }
                            }
                            index10 += 1;
                            continue;
                          default:
                            continue;
                        }
                      }
                    }
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    Exception exception = ex;
                    streamReader.Close();
                    this.game.Data.LoadGraphics(this.formref);
                    let mut num11: i32 =  Interaction.MsgBox( ("Import problem encountered: '" + exception.Message + "'. Your current data might be corrupted. "), Title: ( "Shadow Empire : Planetary Conquest"));
                    this.RemoveSubPart(this.tableId);
                    this.tableId = 0;
                    this.DoStuff();
                    windowReturnClass1.SetFlag(true);
                    windowReturnClass2 = windowReturnClass1;
                    ProjectData.ClearProjectError();
                    goto label_216;
                  }
                  streamReader.Close();
                  this.game.Data.LoadGraphics(this.formref);
                  let mut num12: i32 =  Interaction.MsgBox( "Import finished", Title: ( "Shadow Empire : Planetary Conquest"));
                  this.RemoveSubPart(this.tableId);
                  this.tableId = 0;
                  this.DoStuff();
                  windowReturnClass1.SetFlag(true);
                  windowReturnClass2 = windowReturnClass1;
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  let mut num13: i32 =  Interaction.MsgBox( "Error opening file", Title: ( "Shadow Empire : Planetary Conquest"));
                  ProjectData.ClearProjectError();
                  continue;
                }
label_216:
                return windowReturnClass2;
              }
            }
            else if (num1 == this.exportCsv)
            {
              str18: String = this.game.HandyFunctionsObj.SaveSomething("CSV (*.csv)|*.csv|TXT (*.txt)|*.txt|All (*.*)|*.*", "Give save name...", this.game.AppPath + "csv/", false);
              if (Strings.Len(str18) < 2)
              {
                let mut num14: i32 =  Interaction.MsgBox( "Operation is Cancelled", Title: ( "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                bool flag3 = false;
                bool flag4 = false;
                if (this.game.Data.Product >= 7)
                {
                  if (Interaction.MsgBox( "Inverse export?", MsgBoxStyle.YesNo,  "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                    flag3 = true;
                }
                try
                {
                  StreamWriter text = File.CreateText(str18);
                  try
                  {
                    if (!flag3)
                    {
                      str19: String = "";
                      let mut width3: i32 = this.game.Data.StringListObj[this.strId].Width;
                      for (let mut index14: i32 = 0; index14 <= width3; index14 += 1)
                      {
                        if (index14 > 0)
                          str19 += "\t";
                        str19 += this.game.Data.StringListObj[this.strId].ColumnName[index14];
                      }
                      text.WriteLine(str19);
                      let mut length: i32 = this.game.Data.StringListObj[this.strId].Length;
                      for (let mut row: i32 = 0; row <= length; row += 1)
                      {
                        str20: String = "";
                        let mut width4: i32 = this.game.Data.StringListObj[this.strId].Width;
                        for (let mut col: i32 = 0; col <= width4; col += 1)
                        {
                          if (col > 0)
                            str20 += "\t";
                          valueText: String = this.game.Data.StringListObj[this.strId].Data[row, col];
                          if (flag4)
                            valueText = this.game.Data.StringListObj[this.strId].GetValue( this.game.Data, row, col, this.game.Data.StringListObj[this.strId].LibId.libSlot).valueText;
                          str20 += valueText;
                        }
                        text.WriteLine(str20);
                      }
                    }
                    else
                    {
                      let mut width: i32 = this.game.Data.StringListObj[this.strId].Width;
                      for (let mut index15: i32 = 0; index15 <= width; index15 += 1)
                      {
                        str21: String = this.game.Data.StringListObj[this.strId].ColumnName[index15];
                        let mut length: i32 = this.game.Data.StringListObj[this.strId].Length;
                        for (let mut index16: i32 = 0; index16 <= length; index16 += 1)
                          str21 = str21 + "\t" + this.game.Data.StringListObj[this.strId].Data[index16, index15];
                        text.WriteLine(str21);
                      }
                    }
                    text.Close();
                    let mut num15: i32 =  Interaction.MsgBox( "Export has been written to the csv/ directory", Title: ( "Shadow Empire : Planetary Conquest"));
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    Exception exception = ex;
                    text.Close();
                    let mut num16: i32 =  Interaction.MsgBox( ("Problem writing: " + exception.Message), Title: ( "Shadow Empire : Planetary Conquest"));
                    ProjectData.ClearProjectError();
                  }
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  let mut num17: i32 =  Interaction.MsgBox( "Problem writing. Check if the file is not opened in other application please.", Title: ( "Shadow Empire : Planetary Conquest"));
                  ProjectData.ClearProjectError();
                }
              }
            }
          }
        }
        windowReturnClass1.SetFlag(false);
        return windowReturnClass1;
      }
      windowReturnClass1.SetFlag(false);
      return windowReturnClass1;
    }
  }
}
