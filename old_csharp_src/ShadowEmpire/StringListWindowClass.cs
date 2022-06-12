// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.StringListWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class StringListWindowClass : WindowClass
  {
    private int ListId;
    private ListClass ListObj;
    private int LibListId;
    private ListClass LibListObj;
    private int BAddId;
    private int BAddTextId;
    private int b1id;
    private int b1textid;
    private int b2id;
    private int b2textid;
    private int b3id;
    private int b3textid;
    private int b4id;
    private int b4textid;
    private int b5id;
    private int b5textid;
    private int b6id;
    private int b6textid;
    private int b7id;
    private int b7textid;
    private int b8id;
    private int b8textid;
    private int b9id;
    private int b9textid;
    private int b10id;
    private int b10textid;
    private int b11id;
    private int b11textid;
    private int b12id;
    private int b12textid;
    private int b13id;
    private int b13textid;
    private int b14id;
    private int b14textid;
    private int b15id;
    private int b15textid;
    private int b16id;
    private int b16textid;
    private int b17id;
    private int b17textid;
    private int b18id;
    private int b18textid;
    private int b19id;
    private int b19textid;
    private int b20id;
    private int b20textid;
    private int b21id;
    private int b21textid;
    private int b22id;
    private int b22textid;
    private int BNameId;
    private int BNameTextId;
    private int OptionsListId;
    private int BRemoveId;
    private int BRemoveTextId;
    private int detailnr;
    private int libnr;
    private int detailx;
    private int detaily;
    private string ss;

    public StringListWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "String Lists")
    {
      this.detailnr = -1;
      this.libnr = -1;
      this.detailx = -1;
      this.detaily = -1;
      this.MakeList(-1);
    }

    public override void DoRefresh() => this.MakeList(this.detailnr);

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.detailnr == -1)
        return windowReturnClass;
      if (nr == 32 & this.detailx > -1 & this.b1id > 0)
      {
        windowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.b1id)] + 1, this.SubPartY[this.SubpartNr(this.b1id)] + 1, 1);
        windowReturnClass.SetFlag(true);
      }
      if (nr == 38 & this.detailx > 0)
      {
        --this.detailx;
        this.MakeItem();
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      if (nr == 40 & this.detailx < this.game.Data.StringListObj[this.detailnr].Length)
      {
        ++this.detailx;
        this.MakeItem();
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      if (nr == 37 & this.detaily > 0)
      {
        --this.detaily;
        this.MakeItem();
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      if (!(nr == 39 & this.detaily < this.game.Data.StringListObj[this.detailnr].Width))
        return windowReturnClass;
      ++this.detaily;
      this.MakeItem();
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    private void MakeList(int tDetailnr)
    {
      int num1 = -1;
      if (this.LibListId > 0)
        this.RemoveSubPart(this.LibListId);
      if (this.game.Data.LibraryCounter > -1)
      {
        this.LibListObj = new ListClass();
        this.LibListObj.add("All stringlists", -2);
        this.LibListObj.add("Without libraries", -3);
        if (this.libnr == -1)
          num1 = 0;
        if (this.libnr == -2)
          num1 = 1;
        int num2 = 1;
        int libraryCounter = this.game.Data.LibraryCounter;
        for (int index = 0; index <= libraryCounter; ++index)
        {
          ++num2;
          if (this.libnr == index)
            num1 = num2;
          this.LibListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.LibraryObj[index].name, index);
        }
        ListClass libListObj = this.LibListObj;
        int tlistselect = num1;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(libListObj, 10, 200, tlistselect, game, tHeader: "Libraries", tbackbitmap: (ref local1), bbx: 10, bby: 50, overruleFont: (ref local2));
        this.LibListId = this.AddSubPart(ref tsubpart, 10, 50, 200, 208, 0);
      }
      if (this.ListId > 0)
        this.RemoveSubPart(this.ListId);
      int num3 = -1;
      int num4 = -1;
      if (this.game.Data.StringListCounter > -1)
      {
        this.ListObj = new ListClass();
        int stringListCounter = this.game.Data.StringListCounter;
        for (int index = 0; index <= stringListCounter; ++index)
        {
          if (this.game.Data.StringListObj[index].LibId.libSlot == this.libnr | this.libnr == -1 | this.game.Data.StringListObj[index].LibId.libSlot == -1 & this.libnr == -2)
          {
            ++num3;
            if (tDetailnr == index)
              num4 = num3;
            this.ListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.StringListObj[index].Name + "(ID" + Strings.Trim(Conversion.Str((object) this.game.Data.StringListObj[index].ID)) + ")", index);
          }
        }
        int num5 = 0;
        if (this.game.ScreenHeight > 768)
          num5 = Math.Max(0, (int) Math.Round((double) (this.game.ScreenHeight - 768) / 16.0) - 2);
        ListClass listObj = this.ListObj;
        int tlistsize = 20 + num5;
        int tlistselect = num4;
        GameClass game = this.game;
        ref Bitmap local3 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local4 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(listObj, tlistsize, 200, tlistselect, game, tHeader: "Stringlists", tbackbitmap: (ref local3), bbx: 10, bby: 274, overruleFont: (ref local4));
        this.ListId = this.AddSubPart(ref tsubpart, 10, 274, 200, (23 + num5) * 16, 0);
        this.detailnr = tDetailnr;
        this.MakeItem();
      }
      else
      {
        this.detailnr = tDetailnr;
        this.MakeItem();
      }
      if (this.BAddId > 0)
        this.RemoveSubPart(this.BAddId);
      if (this.BAddTextId > 0)
        this.RemoveSubPart(this.BAddTextId);
      this.ss = "Click to add a new simplelist";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.BAddId = this.AddSubPart(ref tsubpart1, 310, 50, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Add Simplelist", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
      this.BAddTextId = this.AddSubPart(ref tsubpart2, 350, 49, 150, 20, 0);
      if (this.b8id > 0)
        this.RemoveSubPart(this.b8id);
      if (this.b8textid > 0)
        this.RemoveSubPart(this.b8textid);
      if (this.b9id > 0)
        this.RemoveSubPart(this.b9id);
      if (this.b9textid > 0)
        this.RemoveSubPart(this.b9textid);
      if (this.b10id > 0)
        this.RemoveSubPart(this.b10id);
      if (this.b10textid > 0)
        this.RemoveSubPart(this.b10textid);
      if (this.b12id > 0)
        this.RemoveSubPart(this.b12id);
      if (this.b12textid > 0)
        this.RemoveSubPart(this.b12textid);
      if (this.b13id > 0)
        this.RemoveSubPart(this.b13id);
      if (this.b13textid > 0)
        this.RemoveSubPart(this.b13textid);
      if (this.b14id > 0)
        this.RemoveSubPart(this.b14id);
      if (this.b14textid > 0)
        this.RemoveSubPart(this.b14textid);
      if (this.b17id > 0)
        this.RemoveSubPart(this.b17id);
      if (this.b17textid > 0)
        this.RemoveSubPart(this.b17textid);
      if (this.b18id > 0)
        this.RemoveSubPart(this.b18id);
      if (this.b18textid > 0)
        this.RemoveSubPart(this.b18textid);
      if (this.b19id > 0)
        this.RemoveSubPart(this.b19id);
      if (this.b19textid > 0)
        this.RemoveSubPart(this.b19textid);
      this.ss = "Import 1 list from another scenario or masterfile";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.b8id = this.AddSubPart(ref tsubpart2, 510, 50, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Import Spec.List", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
      this.b8textid = this.AddSubPart(ref tsubpart2, 550, 49, 150, 20, 0);
      this.ss = "Import all lists from another scenario or masterfile";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.b9id = this.AddSubPart(ref tsubpart2, 710, 50, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Import All.List", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
      this.b9textid = this.AddSubPart(ref tsubpart2, 750, 49, 150, 20, 0);
      this.ss = "Get all stringlists where a certain expression occurs";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.b19id = this.AddSubPart(ref tsubpart2, 1110, 50, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Search", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
      this.b19textid = this.AddSubPart(ref tsubpart2, 1150, 49, 150, 20, 0);
      this.ss = "Add records from textfile to list. can use comma-seperated-values. will auto add columns if neccessary.";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.b10id = this.AddSubPart(ref tsubpart2, 910, 50, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Imp Txt Names", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
      this.b10textid = this.AddSubPart(ref tsubpart2, 950, 49, 150, 20, 0);
      this.ss = "Writes this stringlist to a file of choice in CSV format.";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.b12id = this.AddSubPart(ref tsubpart2, 910, 70, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Export Txt Names", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
      this.b12textid = this.AddSubPart(ref tsubpart2, 950, 69, 150, 20, 0);
      this.ss = "Clears this Stringlist";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
      this.b13id = this.AddSubPart(ref tsubpart2, 710, 70, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("CLEAR", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
      this.b13textid = this.AddSubPart(ref tsubpart2, 750, 69, 150, 20, 0);
    }

    private void MakeItem()
    {
      if (this.BNameId > 0)
        this.RemoveSubPart(this.BNameId);
      if (this.BNameTextId > 0)
        this.RemoveSubPart(this.BNameTextId);
      if (this.BRemoveId > 0)
        this.RemoveSubPart(this.BRemoveId);
      if (this.BRemoveTextId > 0)
        this.RemoveSubPart(this.BRemoveTextId);
      if (this.b2id > 0)
        this.RemoveSubPart(this.b2id);
      if (this.b2textid > 0)
        this.RemoveSubPart(this.b2textid);
      if (this.b3id > 0)
        this.RemoveSubPart(this.b3id);
      if (this.b3textid > 0)
        this.RemoveSubPart(this.b3textid);
      if (this.b1id > 0)
        this.RemoveSubPart(this.b1id);
      if (this.b1textid > 0)
        this.RemoveSubPart(this.b1textid);
      if (this.b6id > 0)
        this.RemoveSubPart(this.b6id);
      if (this.b6textid > 0)
        this.RemoveSubPart(this.b6textid);
      if (this.b4id > 0)
        this.RemoveSubPart(this.b4id);
      if (this.b4textid > 0)
        this.RemoveSubPart(this.b4textid);
      if (this.b5id > 0)
        this.RemoveSubPart(this.b5id);
      if (this.b5textid > 0)
        this.RemoveSubPart(this.b5textid);
      if (this.b7id > 0)
        this.RemoveSubPart(this.b7id);
      if (this.b7textid > 0)
        this.RemoveSubPart(this.b7textid);
      if (this.b16id > 0)
        this.RemoveSubPart(this.b16id);
      if (this.b16textid > 0)
        this.RemoveSubPart(this.b16textid);
      if (this.b14id > 0)
        this.RemoveSubPart(this.b14id);
      if (this.b14textid > 0)
        this.RemoveSubPart(this.b14textid);
      if (this.b17id > 0)
        this.RemoveSubPart(this.b17id);
      if (this.b17textid > 0)
        this.RemoveSubPart(this.b17textid);
      if (this.b18id > 0)
        this.RemoveSubPart(this.b18id);
      if (this.b18textid > 0)
        this.RemoveSubPart(this.b18textid);
      if (this.b20id > 0)
        this.RemoveSubPart(this.b20id);
      if (this.b20textid > 0)
        this.RemoveSubPart(this.b20textid);
      if (this.b21id > 0)
        this.RemoveSubPart(this.b21id);
      if (this.b21textid > 0)
        this.RemoveSubPart(this.b21textid);
      if (this.b22id > 0)
        this.RemoveSubPart(this.b22id);
      if (this.b22textid > 0)
        this.RemoveSubPart(this.b22textid);
      if (this.OptionsListId > 0)
        this.RemoveSubPart(this.OptionsListId);
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 100, -1);
      this.FlagAll();
      if (this.detailnr <= -1)
        return;
      this.ss = "Click to set library";
      string str = "(No Lib set)";
      if (this.game.Data.StringListObj[this.detailnr].LibId.libSlot > -1)
        str = "(.LibSlot=" + this.game.Data.LibraryObj[this.game.Data.StringListObj[this.detailnr].LibId.libSlot].name + ". LibId=" + this.game.Data.StringListObj[this.detailnr].LibId.id.ToString() + ")";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.b14id = this.AddSubPart(ref tsubpart1, 910, 90, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Set Lib " + str, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.b14textid = this.AddSubPart(ref tsubpart2, 950, 89, 350, 20, 0);
      if (this.b11id > 0)
        this.RemoveSubPart(this.b11id);
      if (this.b11textid > 0)
        this.RemoveSubPart(this.b11textid);
      this.ss = "Add a list, thats copied from this one";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.b11id = this.AddSubPart(ref tsubpart2, 510, 70, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Copy", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
      this.b11textid = this.AddSubPart(ref tsubpart2, 550, 69, 150, 20, 0);
      this.ss = "Replace string foranother in currently selected stringlist";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.b20id = this.AddSubPart(ref tsubpart2, 1310, 50, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Replace", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
      this.b20textid = this.AddSubPart(ref tsubpart2, 1350, 49, 150, 20, 0);
      this.ss = "Click to change the name of this StringList";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.BNameId = this.AddSubPart(ref tsubpart2, 310, 110, 32, 16, 1);
      if (this.detailx > -1 & this.detaily > -1)
      {
        tsubpart2 = (SubPartClass) new TextPartClass("Name: " + this.game.Data.StringListObj[this.detailnr].Name + ", Value: " + this.game.Data.StringListObj[this.detailnr].Data[this.detailx, this.detaily] + " (row:" + this.detaily.ToString() + ",col:" + this.detailx.ToString() + ")", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.BNameTextId = this.AddSubPart(ref tsubpart2, 350, 109, 400, 20, 0);
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextPartClass("Name: " + this.game.Data.StringListObj[this.detailnr].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.BNameTextId = this.AddSubPart(ref tsubpart2, 350, 109, 400, 20, 0);
      }
      this.ss = "Click to remove this stringlist";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
      this.BRemoveId = this.AddSubPart(ref tsubpart2, 310, 70, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Remove this Stringlist", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.BRemoveTextId = this.AddSubPart(ref tsubpart2, 350, 69, 200, 20, 0);
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS);
      this.b4id = this.AddSubPart(ref tsubpart2, 510, 160, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Add Row", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 140, 20, false, tDescript: this.ss);
      this.b4textid = this.AddSubPart(ref tsubpart2, 550, 159, 140, 20, 0);
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS);
      this.b5id = this.AddSubPart(ref tsubpart2, 710, 160, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Add Col", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 140, 20, false, tDescript: this.ss);
      this.b5textid = this.AddSubPart(ref tsubpart2, 750, 159, 140, 20, 0);
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.b16id = this.AddSubPart(ref tsubpart2, 910, 130, 32, 16, 1);
      this.ss = "Click to set description for stringlist. And if it can be edited in simple editor.";
      tsubpart2 = (SubPartClass) new TextPartClass("Descr./Editable =" + this.game.Data.StringListObj[this.detailnr].Editable.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 140, 20, false, tDescript: this.ss);
      this.b16textid = this.AddSubPart(ref tsubpart2, 950, 129, 140, 20, 0);
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.b7id = this.AddSubPart(ref tsubpart2, 810, 110, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("ID=" + Conversion.Str((object) this.game.Data.StringListObj[this.detailnr].ID), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 140, 20, false, tDescript: this.ss);
      this.b7textid = this.AddSubPart(ref tsubpart2, 850, 109, 140, 20, 0);
      this.ss = "Set the column selected to a lookUp Column of a certain stringlist ID";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.b17id = this.AddSubPart(ref tsubpart2, 1310, 70, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Set Col to LookupCol", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
      this.b17textid = this.AddSubPart(ref tsubpart2, 1350, 69, 150, 20, 0);
      if (this.game.Data.Product == 7)
      {
        this.ss = "n/a";
        if (this.detaily > -1)
          this.ss = this.game.Data.StringListObj[this.detailnr].SSID[this.detaily].ToString();
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b22id = this.AddSubPart(ref tsubpart2, 1610, 70, 32, 16, 1);
        tsubpart2 = (SubPartClass) new TextPartClass("SSID=" + this.ss, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false);
        this.b22textid = this.AddSubPart(ref tsubpart2, 1650, 69, 150, 20, 0);
      }
      this.ss = "When referred to by other stringlist use the following columns for ID + Label. ";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.b18id = this.AddSubPart(ref tsubpart2, 1110, 70, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Lookup ID/Label", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false, tDescript: this.ss);
      this.b18textid = this.AddSubPart(ref tsubpart2, 1150, 69, 150, 20, 0);
      int num = 0;
      if (this.game.ScreenHeight > 768)
        num = Math.Max(0, (int) Math.Round((double) (this.game.ScreenHeight - 768) / 16.0) - 2);
      tsubpart2 = (SubPartClass) new MatrixSubPartClass(this.game.Data.StringListObj[this.detailnr], 20 + num, Math.Min(1600, this.game.ScreenWidth - 324), this.detailx, this.detaily, this.game, tbackbitmap: (ref this.BackBitmap), bbx: 310, bby: 200);
      this.OptionsListId = this.AddSubPart(ref tsubpart2, 310, 200, Math.Min(1600, this.game.ScreenWidth - 324), (23 + num) * 16, 0);
      this.MakeTab();
    }

    public void MakeTab()
    {
      if (this.b2id > 0)
        this.RemoveSubPart(this.b2id);
      if (this.b2textid > 0)
        this.RemoveSubPart(this.b2textid);
      if (this.b3id > 0)
        this.RemoveSubPart(this.b3id);
      if (this.b3textid > 0)
        this.RemoveSubPart(this.b3textid);
      if (this.b1id > 0)
        this.RemoveSubPart(this.b1id);
      if (this.b1textid > 0)
        this.RemoveSubPart(this.b1textid);
      if (this.b6id > 0)
        this.RemoveSubPart(this.b6id);
      if (this.b6textid > 0)
        this.RemoveSubPart(this.b6textid);
      if (this.b15id > 0)
        this.RemoveSubPart(this.b15id);
      if (this.b15textid > 0)
        this.RemoveSubPart(this.b15textid);
      if (this.b21id > 0)
        this.RemoveSubPart(this.b21id);
      if (this.b21textid > 0)
        this.RemoveSubPart(this.b21textid);
      if (this.detailx > -1)
      {
        SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
        this.b1id = this.AddSubPart(ref tsubpart1, 310, 130, 32, 16, 1);
        SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Set Value", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 140, 20, false, tDescript: this.ss);
        this.b1textid = this.AddSubPart(ref tsubpart2, 350, 129, 140, 20, 0);
      }
      if (this.detailx > -1)
      {
        SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
        this.b6id = this.AddSubPart(ref tsubpart3, 310, 160, 32, 16, 1);
        SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Name Col", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 140, 20, false, tDescript: this.ss);
        this.b6textid = this.AddSubPart(ref tsubpart4, 350, 159, 140, 20, 0);
      }
      if (this.detailx > -1)
      {
        SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL);
        this.b2id = this.AddSubPart(ref tsubpart5, 510, 130, 32, 16, 1);
        SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("Remove Row", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 140, 20, false, tDescript: this.ss);
        this.b2textid = this.AddSubPart(ref tsubpart6, 550, 129, 140, 20, 0);
      }
      if (this.detailx > -1 & this.game.Data.StringListObj[this.detailnr].Width > 0 & this.detaily > -1)
      {
        SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL);
        this.b3id = this.AddSubPart(ref tsubpart7, 710, 130, 32, 16, 1);
        SubPartClass tsubpart8 = (SubPartClass) new TextPartClass("Remove Col", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 140, 20, false, tDescript: this.ss);
        this.b3textid = this.AddSubPart(ref tsubpart8, 750, 129, 140, 20, 0);
      }
      if (this.detailx > -1 & this.detaily > -1)
      {
        SubPartClass tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
        this.b15id = this.AddSubPart(ref tsubpart9, 910, 160, 32, 16, 1);
        SubPartClass tsubpart10 = (SubPartClass) new TextPartClass("Set Col Value Type", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 140, 20, false, tDescript: this.ss);
        this.b15textid = this.AddSubPart(ref tsubpart10, 950, 159, 140, 20, 0);
      }
      if (this.game.Data.Product != 7 || !(this.detailx > -1 & this.detaily > -1))
        return;
      SubPartClass tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.b21id = this.AddSubPart(ref tsubpart11, 1110, 160, 32, 16, 1);
      SubPartClass tsubpart12 = (SubPartClass) new TextPartClass("LogEnabled=" + this.game.Data.StringListObj[this.detailnr].logEnabled[this.detaily].ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 140, 20, false, tDescript: this.ss);
      this.b21textid = this.AddSubPart(ref tsubpart12, 1150, 159, 140, 20, 0);
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
            if (num1 == this.ListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.detailnr = num2;
                this.detailx = -1;
                this.detaily = -1;
                this.MakeItem();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.LibListId)
            {
              int num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num3 > -1)
              {
                this.libnr = num3;
                this.detailnr = -1;
                this.MakeList(this.detailnr);
              }
              else
              {
                switch (num3)
                {
                  case -3:
                    this.libnr = -2;
                    this.detailnr = -1;
                    this.MakeList(this.detailnr);
                    break;
                  case -2:
                    this.libnr = -1;
                    this.detailnr = -1;
                    this.MakeList(this.detailnr);
                    break;
                }
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddId)
            {
              this.game.Data.AddStringList();
              this.detailnr = this.game.Data.StringListCounter;
              new Form3((Form) this.formref).Initialize(this.game.Data, 56, this.game.Data.StringListCounter);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b11id)
            {
              this.game.Data.AddStringList();
              int id = this.game.Data.StringListObj[this.game.Data.StringListCounter].ID;
              this.game.Data.StringListObj[this.game.Data.StringListCounter] = this.game.Data.StringListObj[this.detailnr].Clone();
              this.game.Data.StringListObj[this.game.Data.StringListCounter].ID = id;
              this.detailnr = this.game.Data.StringListCounter;
              this.MakeList(this.detailnr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b10id)
            {
              string path = this.game.HandyFunctionsObj.LoadSomething("Text file (*.txt)|*.txt", "Pick a textfile. all lines will be added as rows. use , to seperate column values.", this.game.AppPath + "logs\\", false);
              if (File.Exists(path))
              {
                try
                {
                  StreamReader streamReader = File.OpenText(path);
                  while (!streamReader.EndOfStream)
                  {
                    string Expression = streamReader.ReadLine();
                    if (Strings.Len(Expression) > 0)
                    {
                      this.game.Data.StringListObj[this.detailnr].AddRow(this.game.Data.StringListObj[this.detailnr].Length);
                      string[] strArray = Expression.Split('\t');
                      int index2 = -1;
                      foreach (string str in strArray)
                      {
                        ++index2;
                        if (index2 > this.game.Data.StringListObj[this.detailnr].Width)
                          this.game.Data.StringListObj[this.detailnr].AddCol(this.game.Data.StringListObj[this.detailnr].Width);
                        this.game.Data.StringListObj[this.detailnr].Data[this.game.Data.StringListObj[this.detailnr].Length, index2] = str;
                      }
                    }
                  }
                  streamReader.Close();
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  ProjectData.ClearProjectError();
                }
              }
              this.MakeItem();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BNameId)
            {
              this.game.Data.StringListObj[this.detailnr].Name = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest");
              this.MakeList(this.detailnr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsListId)
            {
              Coordinate coordinate = this.SubPartList[index1].Click2(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (coordinate.x > -1)
              {
                this.detailx = coordinate.x;
                this.detaily = coordinate.y;
                if (this.detaily > this.game.Data.StringListObj[this.detailnr].Width)
                  this.detaily = this.game.Data.StringListObj[this.detailnr].Width;
                if (this.detailx > this.game.Data.StringListObj[this.detailnr].Length)
                  this.detailx = this.game.Data.StringListObj[this.detailnr].Length;
                this.MakeTab();
                this.RemoveSubPart(this.BNameTextId);
                if (this.detailx > -1 & this.detaily > -1)
                {
                  SubPartClass tsubpart = (SubPartClass) new TextPartClass("Name: " + this.game.Data.StringListObj[this.detailnr].Name + ", Value: " + this.game.Data.StringListObj[this.detailnr].Data[this.detailx, this.detaily] + " (row:" + this.detailx.ToString() + ",col:" + this.detaily.ToString() + ")", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
                  this.BNameTextId = this.AddSubPart(ref tsubpart, 350, 109, 400, 20, 0);
                }
                else
                {
                  SubPartClass tsubpart = (SubPartClass) new TextPartClass("Name: " + this.game.Data.StringListObj[this.detailnr].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
                  this.BNameTextId = this.AddSubPart(ref tsubpart, 350, 109, 400, 20, 0);
                }
                if (this.game.Data.Product == 7)
                {
                  this.RemoveSubPart(this.b22textid);
                  this.ss = "n/a";
                  if (this.detaily > -1)
                    this.ss = this.game.Data.StringListObj[this.detailnr].SSID[this.detaily].ToString();
                  SubPartClass tsubpart = (SubPartClass) new TextPartClass("SSID=" + this.ss, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 150, 20, false);
                  this.b22textid = this.AddSubPart(ref tsubpart, 1650, 69, 150, 20, 0);
                }
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b1id)
            {
              this.game.Data.StringListObj[this.detailnr].Data[this.detailx, this.detaily] = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest", this.game.Data.StringListObj[this.detailnr].Data[this.detailx, this.detaily]);
              this.MakeItem();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b2id)
            {
              this.game.Data.StringListObj[this.detailnr].RemoveRow(this.detailx);
              --this.detailx;
              this.MakeItem();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b3id)
            {
              this.game.Data.StringListObj[this.detailnr].RemoveCol(this.detaily);
              --this.detaily;
              this.MakeItem();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b4id)
            {
              this.game.Data.StringListObj[this.detailnr].AddRow(this.detailx);
              this.MakeItem();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b5id)
            {
              this.game.Data.StringListObj[this.detailnr].AddCol(this.detaily);
              this.MakeItem();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b6id)
            {
              this.game.Data.StringListObj[this.detailnr].ColumnName[this.detaily] = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest");
              this.MakeItem();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b22id)
            {
              if (this.detaily > -1)
              {
                this.game.Data.StringListObj[this.detailnr].SSID[this.detaily] = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new SS-ID value please (0=none)", "Shadow Empire : Planetary Conquest")));
                this.MakeItem();
              }
              else
              {
                int num4 = (int) Interaction.MsgBox((object) "No column selected");
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b19id)
            {
              string lower = Interaction.InputBox("Search expression (case insensitive)", "Shadow Empire : Planetary Conquest").ToLower();
              bool[] flagArray = new bool[this.game.Data.StringListCounter + 1];
              int stringListCounter1 = this.game.Data.StringListCounter;
              for (int index3 = 0; index3 <= stringListCounter1; ++index3)
              {
                if (Strings.InStr(this.game.Data.StringListObj[index3].Name.ToLower(), lower) > 0)
                  flagArray[index3] = true;
                int length = this.game.Data.StringListObj[index3].Length;
                for (int index4 = 0; index4 <= length; ++index4)
                {
                  int width = this.game.Data.StringListObj[index3].Width;
                  for (int index5 = 0; index5 <= width; ++index5)
                  {
                    if (Strings.InStr(this.game.Data.StringListObj[index3].Data[index4, index5].ToLower(), lower) > 0)
                      flagArray[index3] = true;
                  }
                }
              }
              string str = "";
              int stringListCounter2 = this.game.Data.StringListCounter;
              for (int index6 = 0; index6 <= stringListCounter2; ++index6)
              {
                if (flagArray[index6])
                {
                  if (str.Length > 0)
                    str += ", ";
                  str = str + this.game.Data.StringListObj[index6].Name + "(" + this.game.Data.StringListObj[index6].ID.ToString() + ")";
                }
              }
              if (Operators.CompareString(str, "", false) == 0)
                str = "No results found";
              int num5 = (int) Interaction.MsgBox((object) str, Title: ((object) "Search results"));
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b20id)
            {
              bool flag = false;
              if (Interaction.MsgBox((object) "Replace in ALL stringlists?", MsgBoxStyle.YesNo, (object) "Are you sure?") == MsgBoxResult.Yes)
                flag = true;
              string str1 = Interaction.InputBox("Search expression (case sensitive)", "Shadow Empire : Planetary Conquest");
              string newValue = Interaction.InputBox("Replace expression (case sensitive)", "Shadow Empire : Planetary Conquest");
              int num6 = 0;
              bool[] flagArray = new bool[this.game.Data.StringListCounter + 1];
              int stringListCounter = this.game.Data.StringListCounter;
              for (int index7 = 0; index7 <= stringListCounter; ++index7)
              {
                if (index7 == this.detailnr | flag)
                {
                  int length = this.game.Data.StringListObj[index7].Length;
                  for (int index8 = 0; index8 <= length; ++index8)
                  {
                    int width = this.game.Data.StringListObj[index7].Width;
                    for (int index9 = 0; index9 <= width; ++index9)
                    {
                      string String1 = this.game.Data.StringListObj[index7].Data[index8, index9];
                      if (Strings.InStr(String1, str1) > 0)
                      {
                        string str2 = String1.Replace(str1, newValue);
                        this.game.Data.StringListObj[index7].Data[index8, index9] = str2;
                        ++num6;
                      }
                    }
                  }
                }
              }
              int num7 = (int) Interaction.MsgBox((object) (num6.ToString() + " replacements made."), Title: ((object) "Replace results"));
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b17id)
            {
              int num8 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new lookup stringlist ID, please. -1=none. (that stringlist must have lookupId,lookupLabel set) ", "Shadow Empire : Planetary Conquest")));
              if (num8 >= -1 & this.detaily > -1)
                this.game.Data.StringListObj[this.detailnr].LookUpCol[this.detaily] = num8;
              this.MakeItem();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b21id)
            {
              this.game.Data.StringListObj[this.detailnr].logEnabled[this.detaily] = !this.game.Data.StringListObj[this.detailnr].logEnabled[this.detaily];
              return windowReturnClass;
            }
            if (num1 == this.b18id)
            {
              int num9 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new column for Lookup ID, -1=none ", "Shadow Empire : Planetary Conquest")));
              if (num9 >= -1)
                this.game.Data.StringListObj[this.detailnr].LookUpId = num9;
              int num10 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new column for Lookup Label, -1=none ", "Shadow Empire : Planetary Conquest")));
              if (num10 >= -1)
                this.game.Data.StringListObj[this.detailnr].LookUpLabel = num10;
              this.MakeItem();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b16id)
            {
              if (Interaction.MsgBox((object) "Is editable in Simple Editor?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
              {
                this.game.Data.StringListObj[this.detailnr].Editable = true;
                new Form2((Form) this.formref).Initialize(this.game.Data, 12, this.detailnr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              this.game.Data.StringListObj[this.detailnr].Editable = false;
              this.game.Data.StringListObj[this.detailnr].Description = "";
              this.MakeItem();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b15id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 105, this.detailnr, this.detaily);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b14id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 104, this.detailnr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b7id)
            {
              int num11 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest")));
              this.game.Data.StringListObj[this.detailnr].ID = num11;
              if (num11 > this.game.Data.StringIDCounter)
                this.game.Data.StringIDCounter = num11;
              this.MakeList(this.detailnr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BRemoveId)
            {
              this.game.Data.RemoveStringList(this.detailnr);
              --this.detailnr;
              this.MakeList(this.detailnr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b12id)
            {
              StreamWriter text = File.CreateText(this.game.AppPath + "logs/" + Interaction.InputBox("Give name of file (writes in log directory, adds .txt automaticly)", "Shadow Empire : Planetary Conquest") + ".txt");
              int length = this.game.Data.StringListObj[this.detailnr].Length;
              for (int index10 = 0; index10 <= length; ++index10)
              {
                string str = "";
                int width = this.game.Data.StringListObj[this.detailnr].Width;
                for (int index11 = 0; index11 <= width; ++index11)
                {
                  if (index11 > 0)
                    str += "\t";
                  str += this.game.Data.StringListObj[this.detailnr].Data[index10, index11];
                }
                text.WriteLine(str);
              }
              text.Close();
              int num12 = (int) Interaction.MsgBox((object) "finished");
            }
            else
            {
              if (num1 == this.b13id)
              {
                for (this.detailx = this.game.Data.StringListObj[this.detailnr].Length; this.game.Data.StringListObj[this.detailnr].Length > -1 & this.detailx > -1; --this.detailx)
                  this.game.Data.StringListObj[this.detailnr].RemoveRow(this.detailx);
                this.detailx = -1;
                this.detaily = -1;
                this.MakeItem();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.b8id)
              {
                string str = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to a specific stringlist from...", this.game.AppPath + "scenarios\\", false);
                if (File.Exists(str))
                {
                  this.game.HandyFunctionsObj.Unzip(str);
                  DataClass dataClass = DataClass.deserialize(str);
                  this.game.HandyFunctionsObj.ZipFile(str);
                  string InputStr = Interaction.InputBox("Give StringList# to import, -1=all");
                  int stringListCounter = dataClass.StringListCounter;
                  for (int index12 = 0; index12 <= stringListCounter; ++index12)
                  {
                    if ((double) index12 == Conversion.Val(InputStr) | Conversion.Val(InputStr) == -1.0)
                    {
                      this.game.Data.AddStringList();
                      this.game.Data.StringListObj[this.game.Data.StringListCounter] = dataClass.StringListObj[index12].Clone();
                      if (this.game.Data.StringListObj[this.game.Data.StringListCounter].ID > this.game.Data.StringIDCounter)
                        this.game.Data.StringIDCounter = this.game.Data.StringListObj[this.game.Data.StringListCounter].ID;
                    }
                  }
                  this.detailnr = this.game.Data.StringListCounter;
                  this.MakeList(this.detailnr);
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.b9id)
              {
                string str = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to load all stringlists from...", this.game.AppPath + "scenarios\\", false);
                if (File.Exists(str))
                {
                  this.game.HandyFunctionsObj.Unzip(str);
                  DataClass dataClass = DataClass.deserialize(str);
                  this.game.HandyFunctionsObj.ZipFile(str);
                  int stringListCounter = dataClass.StringListCounter;
                  for (int index13 = 0; index13 <= stringListCounter; ++index13)
                  {
                    this.game.Data.AddStringList();
                    this.game.Data.StringListObj[this.game.Data.StringListCounter] = dataClass.StringListObj[index13].Clone();
                    if (this.game.Data.StringListObj[this.game.Data.StringListCounter].ID > this.game.Data.StringIDCounter)
                      this.game.Data.StringIDCounter = this.game.Data.StringListObj[this.game.Data.StringListCounter].ID;
                  }
                  this.detailnr = this.game.Data.StringListCounter;
                  this.MakeList(this.detailnr);
                }
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
  }
}
