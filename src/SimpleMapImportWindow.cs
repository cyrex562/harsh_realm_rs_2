// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleMapImportWindow
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class SimpleMapImportWindow : WindowClass
  {
    private DataClass TData;
    private int but1id;
    private int but2id;
    private int LibListId;
    private ListClass LibListObj;
    private int LibId;
    private int ImpId;
    private int but2idb;
    private int but3id;
    private int but3idb;
    private int textid;
    private int switchid;
    private bool[] import;
    private int impCount;
    private int OpListId;
    private ListClass OpListObj;
    private int OpId;
    private int ChangeId;
    private int Op2ListId;
    private ListClass Op2ListObj;
    private int Op2Id;
    private int Change2Id;
    private int[] subReg;
    private int[] subPpl;
    private int[] subLib;
    private bool[] usePpl;

    public SimpleMapImportWindow(ref GameClass tGame)
      : base(ref tGame, 1024, 768, 9)
    {
      this.import = new bool[2];
      this.subReg = new int[2];
      this.subPpl = new int[2];
      this.subLib = new int[2];
      this.usePpl = new bool[2];
      this.game.FormRef.Cursor = Cursors.WaitCursor;
      this.LoadMap();
      this.game.FormRef.Cursor = Cursors.Default;
      this.subPpl = new int[this.TData.PeopleCounter + 1];
      this.usePpl = new bool[this.TData.PeopleCounter + 1];
      int peopleCounter1 = this.TData.PeopleCounter;
      for (int index1 = 0; index1 <= peopleCounter1; ++index1)
      {
        this.subPpl[index1] = -1;
        this.usePpl[index1] = false;
        if (this.TData.PeopleObj[index1].LibId.libSlot > -1)
        {
          int peopleCounter2 = this.game.Data.PeopleCounter;
          for (int index2 = 0; index2 <= peopleCounter2; ++index2)
          {
            if (this.game.Data.PeopleObj[index2].LibId.libSlot > -1)
            {
              if (Operators.CompareString(this.TData.LibraryObj[this.TData.PeopleObj[index1].LibId.libSlot].name, this.game.Data.LibraryObj[this.game.Data.PeopleObj[index2].LibId.libSlot].name, false) == 0 && this.TData.PeopleObj[index1].id == this.game.Data.PeopleObj[index2].LibId.id)
                this.subPpl[index1] = index2;
            }
            else if (Operators.CompareString(this.TData.PeopleObj[index1].Name, this.game.Data.PeopleObj[index2].Name, false) == 0)
              this.subPpl[index1] = index2;
          }
        }
        else
        {
          int peopleCounter3 = this.game.Data.PeopleCounter;
          for (int index3 = 0; index3 <= peopleCounter3; ++index3)
          {
            if (this.game.Data.PeopleObj[index3].LibId.libSlot == -1 & this.TData.PeopleObj[index1].LibId.libSlot == -1 && Operators.CompareString(this.TData.PeopleObj[index1].Name, this.game.Data.PeopleObj[index3].Name, false) == 0)
              this.subPpl[index1] = index3;
          }
        }
      }
      this.OpId = -1;
      this.Op2Id = -1;
      this.game.EditObj.TempRegimeSlot = -1;
      this.game.EditObj.TempPeopleSlot = -1;
      this.DoStuff();
    }

    public override void DoRefresh()
    {
      if (this.game.EditObj.TempPeopleSlot != -1)
      {
        if (this.game.EditObj.TempPeopleSlot <= -2)
          this.game.EditObj.TempPeopleSlot = -1;
        this.subPpl[this.Op2Id] = this.game.EditObj.TempPeopleSlot;
        this.game.EditObj.TempPeopleSlot = -1;
      }
      this.DoStuff();
    }

    public void DoStuff()
    {
      this.NewBackGroundAndClearAll(1024, 768, 9);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
      DrawMod.DrawMessFrameSimplePopup(ref this.OwnBitmap, ref graphics, 0, 0, 1024, 768, "Loading map: '" + this.TData.MapName + "'");
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      if (this.but1id > 0)
        this.RemoveSubPart(this.but1id);
      if (this.but2id > 0)
        this.RemoveSubPart(this.but2id);
      if (this.but2idb > 0)
        this.RemoveSubPart(this.but2idb);
      if (this.but3id > 0)
        this.RemoveSubPart(this.but3id);
      if (this.but3idb > 0)
        this.RemoveSubPart(this.but3idb);
      if (this.OpListId > 0)
        this.RemoveSubPart(this.OpListId);
      if (this.ChangeId > 0)
        this.RemoveSubPart(this.ChangeId);
      if (this.Op2ListId > 0)
        this.RemoveSubPart(this.Op2ListId);
      if (this.Change2Id > 0)
        this.RemoveSubPart(this.Change2Id);
      SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Cancel", 200, tBackbitmap: (ref this.OwnBitmap), bbx: 300, bby: 680, theight: 45, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.but1id = this.AddSubPart(ref tsubpart1, 300, 680, 200, 45, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Load Map", 200, tBackbitmap: (ref this.OwnBitmap), bbx: 524, bby: 680, theight: 45, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.but2id = this.AddSubPart(ref tsubpart2, 524, 680, 200, 45, 1);
      if (this.TData.MapObj[0].MapWidth + 1 < this.game.Data.MapObj[0].MapWidth & this.TData.MapObj[0].MapHeight + 1 < this.game.Data.MapObj[0].MapHeight)
      {
        SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Insert Map", 200, tBackbitmap: (ref this.OwnBitmap), bbx: 748, bby: 680, theight: 45, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.but3id = this.AddSubPart(ref tsubpart3, 748, 680, 200, 45, 1);
      }
      else
      {
        SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Insert Map", 200, "Cannot insert since the map we attempt to load is either (almost) wider of higher.", ref this.OwnBitmap, 748, 680, true, theight: 45, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.but3idb = this.AddSubPart(ref tsubpart4, 748, 680, 200, 45, 0);
      }
      int num1;
      int y1 = num1 + 70;
      string tstring1 = "Current map: " + this.game.Data.MapObj[0].MapWidth.ToString() + "x" + this.game.Data.MapObj[0].MapHeight.ToString() + " : " + this.game.Data.MapName + " by " + this.game.Data.MapDesigner + ", version " + this.game.Data.MapVersion.ToString();
      DrawMod.DrawTextColouredMarcCenter(ref graphics, tstring1, this.game.MarcFont4, 512, y1, Color.White);
      int y2 = y1 + 19;
      string tstring2 = "Map attempting to load: " + this.TData.MapObj[0].MapWidth.ToString() + "x" + this.TData.MapObj[0].MapHeight.ToString() + " : " + this.TData.MapName + " by " + this.TData.MapDesigner + ", version " + this.TData.MapVersion.ToString();
      DrawMod.DrawTextColouredMarcCenter(ref graphics, tstring2, this.game.MarcFont4, 512, y2, Color.White);
      int y3 = y2 + 25;
      if (this.TData.MapObj[0].MapWidth == this.game.Data.MapObj[0].MapWidth & this.TData.MapObj[0].MapHeight == this.game.Data.MapObj[0].MapHeight)
      {
        if (Operators.CompareString(this.TData.MapName, this.game.Data.MapName, false) == 0)
        {
          if (this.TData.MapVersion > this.game.Data.MapVersion)
            DrawMod.DrawTextColouredMarcCenter(ref graphics, "You already have map with this name loaded. But this is newer version.", this.game.MarcFont3, 512, y3, Color.GreenYellow);
          else if (this.TData.MapVersion == this.game.Data.MapVersion)
            DrawMod.DrawTextColouredMarcCenter(ref graphics, "You already have map with this name loaded. Seems to be same version.", this.game.MarcFont3, 512, y3, Color.Yellow);
          else if (this.TData.MapVersion < this.game.Data.MapVersion)
            DrawMod.DrawTextColouredMarcCenter(ref graphics, "You already have map with this name loaded. Be careful loading, this is an older version.", this.game.MarcFont3, 512, y3, Color.Salmon);
        }
        else
          DrawMod.DrawTextColouredMarcCenter(ref graphics, "Be carefull. The name of your current map loaded is different from this one.", this.game.MarcFont3, 512, y3, Color.Salmon);
      }
      else if (this.game.Data.MapObj[0].MapWidth > 0 & this.game.Data.MapObj[0].MapHeight > 0)
        DrawMod.DrawTextColouredMarcCenter(ref graphics, "The size dimensions of the current map and the one you are preparing to load are not exactly the same.", this.game.MarcFont3, 512, y3, Color.Salmon);
      int num2 = 0;
      int mapWidth = this.TData.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.TData.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.TData.MapObj[0].HexObj[index1, index2].Location > -1)
            this.usePpl[this.TData.LocObj[this.TData.MapObj[0].HexObj[index1, index2].Location].People] = true;
        }
      }
      int peopleCounter1 = this.TData.PeopleCounter;
      for (int index = 0; index <= peopleCounter1; ++index)
      {
        if (this.usePpl[index])
          ++num2;
      }
      int y4 = y3 + 60;
      if (num2 <= 0)
        return;
      DrawMod.DrawTextColouredMarc(ref graphics, "Substitute peoples in locations on this map?", this.game.MarcFont4, 110, y4, Color.White);
      int y5 = y4 + 30;
      this.Op2ListObj = new ListClass();
      int num3 = -1;
      int num4 = -1;
      int peopleCounter2 = this.TData.PeopleCounter;
      for (int index = 0; index <= peopleCounter2; ++index)
      {
        if (this.usePpl[index])
        {
          ++num4;
          string tvalue = "Import this people";
          if (this.subPpl[index] > -1)
            tvalue = "Subst. with " + this.game.Data.PeopleObj[this.subPpl[index]].Name;
          this.Op2ListObj.add(Conversion.Str((object) index) + ") " + this.TData.PeopleObj[index].Name, index, tvalue);
          if (this.Op2Id == -1)
            this.Op2Id = index;
          if (this.Op2Id == index)
            num3 = num4;
        }
      }
      ListClass op2ListObj = this.Op2ListObj;
      int tlistselect = num3;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      int bby = y5;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart5 = (SubPartClass) new ListSubPartClass(op2ListObj, 9, 750, tlistselect, game, true, "Peoples", false, tShowPair: true, tValueWidth: 225, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: 100, bby: bby, tMarcStyle: true, overruleFont: (ref local2));
      this.Op2ListId = this.AddSubPart(ref tsubpart5, 100, y5, 750, 192, 0);
      SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("Change", 130, tBackbitmap: (ref this.OwnBitmap), bbx: 870, bby: (y5 + 10), theight: 45, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.Change2Id = this.AddSubPart(ref tsubpart6, 870, y5 + 10, 130, 45, 1);
    }

    public bool LoadMap()
    {
      string tempFileName = this.game.EditObj.TempFileName;
      if (!File.Exists(tempFileName))
        return false;
      this.game.HandyFunctionsObj.Unzip(tempFileName);
      this.TData = new DataClass(DontLoadGraphics: true);
      this.TData = DataClass.deserialize(tempFileName);
      this.game.HandyFunctionsObj.ZipFile(tempFileName);
      GC.Collect();
      Application.DoEvents();
      return true;
    }

    public void ActuallyImportLibs()
    {
      int peopleCounter = this.TData.PeopleCounter;
      for (int index1 = 0; index1 <= peopleCounter; ++index1)
      {
        if (this.usePpl[index1] & this.subPpl[index1] == -1)
        {
          bool flag = false;
          int index2 = -1;
          if (this.TData.PeopleObj[index1].LibId.libSlot > -1)
            index2 = this.game.Data.FindPeople(ref this.TData.PeopleObj[index1], this.TData.LibraryObj[this.TData.PeopleObj[index1].LibId.libSlot].name);
          if (index2 > -1)
          {
            flag = true;
            this.game.Data.PeopleObj[index2] = this.TData.PeopleObj[index1].Clone();
            ++this.game.Data.PeopleIdCounter;
            this.game.Data.PeopleObj[index2].id = this.game.Data.PeopleIdCounter;
            this.game.Data.PeopleObj[index2].LibId.id = this.TData.PeopleObj[index1].id;
          }
          if (!flag)
          {
            this.game.Data.AddPeople();
            this.game.Data.PeopleObj[this.game.Data.PeopleCounter] = this.TData.PeopleObj[index1].Clone();
            ++this.game.Data.PeopleIdCounter;
            this.game.Data.PeopleObj[this.game.Data.PeopleCounter].id = this.game.Data.PeopleIdCounter;
            if (this.TData.PeopleObj[index1].LibId.libSlot > -1)
            {
              int num;
              if (this.game.Data.FindLibrary(this.TData.LibraryObj[this.TData.PeopleObj[index1].LibId.libSlot].name) == -1)
              {
                this.game.Data.AddLibrary();
                this.game.Data.LibraryObj[this.game.Data.LibraryCounter] = this.TData.LibraryObj[this.TData.PeopleObj[index1].LibId.libSlot].Clone();
                num = this.game.Data.LibraryCounter;
              }
              else
                num = this.game.Data.FindLibrary(this.TData.LibraryObj[this.TData.PeopleObj[index1].LibId.libSlot].name);
              this.game.Data.PeopleObj[this.game.Data.PeopleCounter].LibId.libSlot = num;
              this.game.Data.PeopleObj[this.game.Data.PeopleCounter].LibId.id = this.TData.PeopleObj[index1].id;
            }
            else
            {
              this.game.Data.PeopleObj[this.game.Data.PeopleCounter].LibId.libSlot = -1;
              this.game.Data.PeopleObj[this.game.Data.PeopleCounter].LibId.id = -1;
            }
            this.subPpl[index1] = this.game.Data.PeopleCounter;
          }
        }
      }
      bool flag1 = false;
      if (this.game.Data.MapObj[0].MapWidth > 0 & this.game.Data.MapObj[0].MapHeight > 0)
        flag1 = true;
      DataClass data = this.game.Data;
      data.MapDesigner = this.TData.MapDesigner;
      data.MapVersion = this.TData.MapVersion;
      data.MapName = this.TData.MapName;
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = false;
      data.MapObj[0].MapLoop = this.TData.MapObj[0].MapLoop;
      if (flag1 && !(data.MapObj[0].MapWidth == this.TData.MapObj[0].MapWidth & data.MapObj[0].MapHeight == this.TData.MapObj[0].MapHeight))
      {
        if (Interaction.MsgBox((object) "Map not same size. Reload is cancelled. Are you sure you want to continue", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.No)
          return;
        flag4 = true;
      }
      if (flag1 && Interaction.MsgBox((object) "Do you want to overwrite the current Victory Point settings on your current map?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.No)
        flag2 = true;
      if (this.TData.LocTypeCounter > data.LocTypeCounter && Interaction.MsgBox((object) "Do you want to add extra locationtypes present in the map file (that are not present in the master)?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
        flag3 = true;
      if (flag3 && this.TData.LocTypeCounter > data.LocTypeCounter)
      {
        data.LocTypeObj = (LocationTypeClass[]) Utils.CopyArray((Array) data.LocTypeObj, (Array) new LocationTypeClass[this.TData.LocTypeCounter + 1]);
        int locTypeCounter = this.TData.LocTypeCounter;
        for (int index = 0; index <= locTypeCounter; ++index)
        {
          if (index > data.LocTypeCounter)
            data.LocTypeObj[index] = this.TData.LocTypeObj[index];
        }
        data.LocTypeCounter = this.TData.LocTypeCounter;
      }
      if (!flag1)
      {
        int mapWidth = data.MapObj[0].MapWidth;
        for (int index3 = 0; index3 <= mapWidth; ++index3)
        {
          int mapHeight = data.MapObj[0].MapHeight;
          for (int index4 = 0; index4 <= mapHeight; ++index4)
          {
            while (data.MapObj[0].HexObj[index3, index4].UnitCounter > -1)
            {
              DataClass dataClass = data;
              int unit = data.MapObj[0].HexObj[index3, index4].UnitList[0];
              GameClass gameClass = (GameClass) null;
              ref GameClass local = ref gameClass;
              dataClass.RemoveUnit(unit, ref local);
            }
            if (data.MapObj[0].HexObj[index3, index4].Location > -1)
              data.RemoveLoc(data.MapObj[0].HexObj[index3, index4].Location);
          }
        }
        data.MapObj[0].MapWidth = this.TData.MapObj[0].MapWidth;
        data.MapObj[0].MapHeight = this.TData.MapObj[0].MapHeight;
        data.MapObj[0].HexObj = new HexClass[this.TData.MapObj[0].MapWidth + 1, this.TData.MapObj[0].MapHeight + 1];
      }
      else
      {
        int mapWidth = data.MapObj[0].MapWidth;
        for (int index5 = 0; index5 <= mapWidth; ++index5)
        {
          int mapHeight = data.MapObj[0].MapHeight;
          for (int index6 = 0; index6 <= mapHeight; ++index6)
          {
            if (data.MapObj[0].HexObj[index5, index6].Location > -1)
              data.RemoveLoc(data.MapObj[0].HexObj[index5, index6].Location);
          }
        }
        if (flag4)
        {
          if (this.TData.MapObj[0].MapWidth < data.MapObj[0].MapWidth)
            this.game.HandyFunctionsObj.RemoveXToMap(data.MapObj[0].MapWidth - this.TData.MapObj[0].MapWidth);
          if (this.TData.MapObj[0].MapWidth > data.MapObj[0].MapWidth)
            this.game.HandyFunctionsObj.AddXToMap(this.TData.MapObj[0].MapWidth - data.MapObj[0].MapWidth);
          if (this.TData.MapObj[0].MapHeight < data.MapObj[0].MapHeight)
            this.game.HandyFunctionsObj.RemoveYToMap(data.MapObj[0].MapHeight - this.TData.MapObj[0].MapHeight);
          if (this.TData.MapObj[0].MapHeight > data.MapObj[0].MapHeight)
            this.game.HandyFunctionsObj.AddYToMap(this.TData.MapObj[0].MapHeight - data.MapObj[0].MapHeight);
        }
      }
      int mapWidth1 = this.TData.MapObj[0].MapWidth;
      for (int index7 = 0; index7 <= mapWidth1; ++index7)
      {
        int mapHeight = this.TData.MapObj[0].MapHeight;
        for (int index8 = 0; index8 <= mapHeight; ++index8)
        {
          if (!flag1)
            data.MapObj[0].HexObj[index7, index8] = new HexClass(0, this.game.Data.RegimeCounter, this.game.Data.RegimeCounter);
          int index9 = 0;
          do
          {
            data.MapObj[0].HexObj[index7, index8].AreaCode[index9] = this.TData.MapObj[0].HexObj[index7, index8].AreaCode[index9];
            ++index9;
          }
          while (index9 <= 9);
          int index10 = 0;
          do
          {
            data.MapObj[0].HexObj[index7, index8].Bridge[index10] = this.TData.MapObj[0].HexObj[index7, index8].Bridge[index10];
            data.MapObj[0].HexObj[index7, index8].RiverType[index10] = this.TData.MapObj[0].HexObj[index7, index8].RiverType[index10];
            data.MapObj[0].HexObj[index7, index8].RoadType[index10] = this.TData.MapObj[0].HexObj[index7, index8].RoadType[index10];
            ++index10;
          }
          while (index10 <= 5);
          data.MapObj[0].HexObj[index7, index8].CardUponConquest = -1;
          data.MapObj[0].HexObj[index7, index8].LabelText1 = this.TData.MapObj[0].HexObj[index7, index8].LabelText1;
          data.MapObj[0].HexObj[index7, index8].LabelText2 = this.TData.MapObj[0].HexObj[index7, index8].LabelText2;
          data.MapObj[0].HexObj[index7, index8].LabelType1 = this.TData.MapObj[0].HexObj[index7, index8].LabelType1;
          data.MapObj[0].HexObj[index7, index8].LabelType2 = this.TData.MapObj[0].HexObj[index7, index8].LabelType2;
          data.MapObj[0].HexObj[index7, index8].LandscapeType = this.TData.MapObj[0].HexObj[index7, index8].LandscapeType;
          data.MapObj[0].HexObj[index7, index8].SmallLabel = this.TData.MapObj[0].HexObj[index7, index8].SmallLabel;
          data.MapObj[0].HexObj[index7, index8].SmallLabelType = this.TData.MapObj[0].HexObj[index7, index8].SmallLabelType;
          data.MapObj[0].HexObj[index7, index8].randomOverrule = this.TData.MapObj[0].HexObj[index7, index8].randomOverrule;
          data.MapObj[0].HexObj[index7, index8].Location = this.TData.MapObj[0].HexObj[index7, index8].Location;
          data.MapObj[0].HexObj[index7, index8].Name = this.TData.MapObj[0].HexObj[index7, index8].Name;
          data.MapObj[0].HexObj[index7, index8].SpecialSprite = this.TData.MapObj[0].HexObj[index7, index8].SpecialSprite;
          data.MapObj[0].HexObj[index7, index8].SpecialType = this.TData.MapObj[0].HexObj[index7, index8].SpecialType;
          data.MapObj[0].HexObj[index7, index8].SpriteNr = this.TData.MapObj[0].HexObj[index7, index8].SpriteNr;
          data.MapObj[0].HexObj[index7, index8].HeightLevel = this.TData.MapObj[0].HexObj[index7, index8].HeightLevel;
          if (!flag2)
            data.MapObj[0].HexObj[index7, index8].VP = this.TData.MapObj[0].HexObj[index7, index8].VP;
        }
      }
      data.LocCounter = this.TData.LocCounter;
      data.LocObj = (LocationClass[]) Utils.CopyArray((Array) data.LocObj, (Array) new LocationClass[data.LocCounter + 1]);
      int locCounter1 = this.TData.LocCounter;
      for (int index = 0; index <= locCounter1; ++index)
      {
        data.LocObj[index] = this.TData.LocObj[index];
        data.LocObj[index].People = this.subPpl[this.TData.LocObj[index].People];
      }
      int num1 = 0;
      for (int locCounter2 = data.LocCounter; locCounter2 >= 0; locCounter2 += -1)
      {
        if (data.LocObj[locCounter2].Type > data.LocTypeCounter)
        {
          data.RemoveLoc(locCounter2);
          ++num1;
        }
      }
      if (num1 > 0)
      {
        int num2 = (int) Interaction.MsgBox((object) ("Removed " + num1.ToString() + " locations since they were set to a locationType that was not present in master."), Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      int num3 = 0;
      for (int locTypeCounter = data.LocTypeCounter; locTypeCounter >= 0; locTypeCounter += -1)
      {
        if (data.LocTypeObj[locTypeCounter].SmallGraphic > data.SmallPicCounter)
        {
          data.LocTypeObj[locTypeCounter].SmallGraphic = data.SmallPicCounter;
          ++num3;
        }
      }
      if (num3 > 0)
      {
        int num4 = (int) Interaction.MsgBox((object) ("Replaced " + num3.ToString() + " small graphics from locationTypes because they were not present in master."), Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      this.game.Data.LoadGraphics(this.formref);
    }

    public void ActuallyImportLibs2()
    {
      int peopleCounter = this.TData.PeopleCounter;
      for (int index1 = 0; index1 <= peopleCounter; ++index1)
      {
        if (this.usePpl[index1] & this.subPpl[index1] == -1)
        {
          bool flag = false;
          int index2 = -1;
          if (this.TData.PeopleObj[index1].LibId.libSlot > -1)
            index2 = this.game.Data.FindPeople(ref this.TData.PeopleObj[index1], this.TData.LibraryObj[this.TData.PeopleObj[index1].LibId.libSlot].name);
          if (index2 > -1)
          {
            flag = true;
            this.game.Data.PeopleObj[index2] = this.TData.PeopleObj[index1].Clone();
            ++this.game.Data.PeopleIdCounter;
            this.game.Data.PeopleObj[index2].id = this.game.Data.PeopleIdCounter;
            this.game.Data.PeopleObj[index2].LibId.id = this.TData.PeopleObj[index1].id;
          }
          if (!flag)
          {
            this.game.Data.AddPeople();
            this.game.Data.PeopleObj[this.game.Data.PeopleCounter] = this.TData.PeopleObj[index1].Clone();
            ++this.game.Data.PeopleIdCounter;
            this.game.Data.PeopleObj[this.game.Data.PeopleCounter].id = this.game.Data.PeopleIdCounter;
            if (this.TData.PeopleObj[index1].LibId.libSlot > -1)
            {
              int num;
              if (this.game.Data.FindLibrary(this.TData.LibraryObj[this.TData.PeopleObj[index1].LibId.libSlot].name) == -1)
              {
                this.game.Data.AddLibrary();
                this.game.Data.LibraryObj[this.game.Data.LibraryCounter] = this.TData.LibraryObj[this.TData.PeopleObj[index1].LibId.libSlot].Clone();
                num = this.game.Data.LibraryCounter;
              }
              else
                num = this.game.Data.FindLibrary(this.TData.LibraryObj[this.TData.PeopleObj[index1].LibId.libSlot].name);
              this.game.Data.PeopleObj[this.game.Data.PeopleCounter].LibId.libSlot = num;
              this.game.Data.PeopleObj[this.game.Data.PeopleCounter].LibId.id = this.TData.PeopleObj[index1].id;
            }
            else
            {
              this.game.Data.PeopleObj[this.game.Data.PeopleCounter].LibId.libSlot = -1;
              this.game.Data.PeopleObj[this.game.Data.PeopleCounter].LibId.id = -1;
            }
            this.subPpl[index1] = this.game.Data.PeopleCounter;
          }
        }
      }
      DataClass data = this.game.Data;
      int integer1 = Conversions.ToInteger(Interaction.InputBox("Give X coordinate to insert 0,0 coordinate of import map on. Make sure it is an EVEN coordinate", "Shadow Empire : Planetary Conquest"));
      int integer2 = Conversions.ToInteger(Interaction.InputBox("Give Y coordinate to insert 0,0 coordinate of import map on.", "Shadow Empire : Planetary Conquest"));
      int num1 = integer1 + this.TData.MapObj[0].MapWidth;
      int num2 = integer2 + this.TData.MapObj[0].MapHeight;
      if ((integer1 + 2) % 2 > 0)
      {
        int num3 = (int) Interaction.MsgBox((object) "You picked an UNEVEN X Coordinate. Aborting Insert Operation. ", (MsgBoxStyle) Conversions.ToInteger("Shadow Empire : Planetary Conquest"));
      }
      else if (num1 > this.game.Data.MapObj[0].MapWidth | num2 > this.game.Data.MapObj[0].MapHeight)
      {
        int num4 = (int) Interaction.MsgBox((object) "Invalid insert coordinate. The inserted map will exceed the current map width or height. Aborting Insert Operation. ", (MsgBoxStyle) Conversions.ToInteger("Shadow Empire : Planetary Conquest"));
      }
      else if (Interaction.MsgBox((object) ("This operation requires you to be sure that the map you are inserting is using the same masterfile/ruleset as the one it is being inserted in. Are you sure to insert this map on the area " + integer1.ToString() + "," + integer2.ToString() + " - " + num1.ToString() + "," + num2.ToString() + " ?"), MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.No)
      {
        int num5 = (int) Interaction.MsgBox((object) "Aborting Insert Operation", (MsgBoxStyle) Conversions.ToInteger("Shadow Empire : Planetary Conquest"));
      }
      else
      {
        bool flag = false;
        if (Interaction.MsgBox((object) "Do you want to overwrite the current Victory Point settings on your current map?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.No)
          flag = true;
        int num6 = integer1;
        int num7 = num1;
        for (int x = num6; x <= num7; ++x)
        {
          int num8 = integer2;
          int num9 = num2;
          for (int y = num8; y <= num9; ++y)
          {
            int index3 = x - integer1;
            int index4 = y - integer2;
            if (x == 166 & y == 42)
              x = x;
            int index5 = 0;
            do
            {
              data.MapObj[0].HexObj[x, y].Bridge[index5] = this.TData.MapObj[0].HexObj[index3, index4].Bridge[index5];
              data.MapObj[0].HexObj[x, y].RiverType[index5] = this.TData.MapObj[0].HexObj[index3, index4].RiverType[index5];
              data.MapObj[0].HexObj[x, y].RoadType[index5] = this.TData.MapObj[0].HexObj[index3, index4].RoadType[index5];
              ++index5;
            }
            while (index5 <= 5);
            data.MapObj[0].HexObj[x, y].CardUponConquest = -1;
            data.MapObj[0].HexObj[x, y].LabelText1 = this.TData.MapObj[0].HexObj[index3, index4].LabelText1;
            data.MapObj[0].HexObj[x, y].LabelText2 = this.TData.MapObj[0].HexObj[index3, index4].LabelText2;
            data.MapObj[0].HexObj[x, y].LabelType1 = this.TData.MapObj[0].HexObj[index3, index4].LabelType1;
            data.MapObj[0].HexObj[x, y].LabelType2 = this.TData.MapObj[0].HexObj[index3, index4].LabelType2;
            data.MapObj[0].HexObj[x, y].LandscapeType = this.TData.MapObj[0].HexObj[index3, index4].LandscapeType;
            data.MapObj[0].HexObj[x, y].SmallLabel = this.TData.MapObj[0].HexObj[index3, index4].SmallLabel;
            data.MapObj[0].HexObj[x, y].SmallLabelType = this.TData.MapObj[0].HexObj[index3, index4].SmallLabelType;
            data.MapObj[0].HexObj[x, y].randomOverrule = this.TData.MapObj[0].HexObj[index3, index4].randomOverrule;
            if (this.TData.MapObj[0].HexObj[index3, index4].Location > -1)
            {
              if (data.MapObj[0].HexObj[x, y].Location > -1)
              {
                this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x, y].Location].Name = this.TData.LocObj[this.TData.MapObj[0].HexObj[index3, index4].Location].Name;
                this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x, y].Location].Type = this.TData.LocObj[this.TData.MapObj[0].HexObj[index3, index4].Location].Type;
                this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x, y].Location].People = this.TData.LocObj[this.TData.MapObj[0].HexObj[index3, index4].Location].People;
                this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x, y].Location].StructuralPts = this.TData.LocObj[this.TData.MapObj[0].HexObj[index3, index4].Location].StructuralPts;
              }
              else
              {
                this.game.Data.AddLoc(x, y, 0);
                this.game.Data.LocObj[this.game.Data.LocCounter] = this.TData.LocObj[this.TData.MapObj[0].HexObj[index3, index4].Location];
                this.game.Data.LocObj[this.game.Data.LocCounter].Name = this.TData.LocObj[this.TData.MapObj[0].HexObj[index3, index4].Location].Name;
                this.game.Data.LocObj[this.game.Data.LocCounter].Type = this.TData.LocObj[this.TData.MapObj[0].HexObj[index3, index4].Location].Type;
                this.game.Data.LocObj[this.game.Data.LocCounter].People = this.TData.LocObj[this.TData.MapObj[0].HexObj[index3, index4].Location].People;
                this.game.Data.LocObj[this.game.Data.LocCounter].StructuralPts = this.TData.LocObj[this.TData.MapObj[0].HexObj[index3, index4].Location].StructuralPts;
                this.game.Data.MapObj[0].HexObj[x, y].Location = this.game.Data.LocCounter;
              }
            }
            else if (this.game.Data.MapObj[0].HexObj[x, y].Location > -1)
              this.game.Data.RemoveLoc(data.MapObj[0].HexObj[x, y].Location);
            data.MapObj[0].HexObj[x, y].Name = this.TData.MapObj[0].HexObj[index3, index4].Name;
            data.MapObj[0].HexObj[x, y].SpecialSprite = this.TData.MapObj[0].HexObj[index3, index4].SpecialSprite;
            data.MapObj[0].HexObj[x, y].SpecialType = this.TData.MapObj[0].HexObj[index3, index4].SpecialType;
            data.MapObj[0].HexObj[x, y].SpriteNr = this.TData.MapObj[0].HexObj[index3, index4].SpriteNr;
            data.MapObj[0].HexObj[x, y].HeightLevel = this.TData.MapObj[0].HexObj[index3, index4].HeightLevel;
            if (!flag)
              data.MapObj[0].HexObj[x, y].VP = this.TData.MapObj[0].HexObj[index3, index4].VP;
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
            if (num1 == this.Op2ListId)
            {
              int num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num2 > -1)
                this.Op2Id = num2;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Change2Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 99, -1);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.but1id)
            {
              this.TData = (DataClass) null;
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.but2id)
            {
              this.game.FormRef.Cursor = Cursors.WaitCursor;
              this.ActuallyImportLibs();
              this.game.FormRef.Cursor = Cursors.Default;
              int num3 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
              this.TData = (DataClass) null;
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 != this.but3id)
              return windowReturnClass;
            this.game.FormRef.Cursor = Cursors.WaitCursor;
            this.ActuallyImportLibs2();
            this.game.FormRef.Cursor = Cursors.Default;
            int num4 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
            this.TData = (DataClass) null;
            windowReturnClass.AddCommand(6, 0);
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
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
