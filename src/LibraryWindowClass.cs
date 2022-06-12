// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.LibraryWindowClass
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
  public class LibraryWindowClass : WindowClass
  {
    private int LibListId;
    private ListClass LibListObj;
    private int AddLibId;
    private int AddLibTextId;
    private int RemoveLibId;
    private int RemoveLibTextId;
    private int LibVarListId;
    private ListClass LibVarListObj;
    private int AddLibVarId;
    private int AddLibVarTextId;
    private int RemoveLibVarId;
    private int RemoveLibVarTextId;
    private int LibVarTypeId;
    private int LibVarTypeTextId;
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
    private int B5Id;
    private int B5TextId;
    private int LibId;
    private int LibVarId;
    private string ss;

    public LibraryWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Libraries")
    {
      this.LibId = -1;
      this.LibVarId = -1;
      this.MakeLibListGUI(-1);
    }

    public override void DoRefresh() => this.MakeLibItemGUI();

    private void MakeLibListGUI(int tLibNr)
    {
      if (this.LibListId > 0)
        this.RemoveSubPart(this.LibListId);
      this.LibListObj = new ListClass();
      tLibNr = -1;
      int libraryCounter = this.game.Data.LibraryCounter;
      for (int index = 0; index <= libraryCounter; ++index)
      {
        this.LibListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.LibraryObj[index].name, index);
        if (this.LibId == index)
          tLibNr = index + 1;
      }
      if (tLibNr == -1)
        this.LibId = -1;
      ListClass libListObj = this.LibListObj;
      int libId = this.LibId;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(libListObj, 19, 400, libId, game, tHeader: "Libraries", tbackbitmap: (ref local1), bbx: 10, bby: 50, overruleFont: (ref local2));
      this.LibListId = this.AddSubPart(ref tsubpart1, 10, 50, 400, 352, 0);
      this.MakeLibItemGUI();
      if (this.AddLibId > 0)
        this.RemoveSubPart(this.AddLibId);
      if (this.AddLibTextId > 0)
        this.RemoveSubPart(this.AddLibTextId);
      this.ss = "Click to add a new Library";
      SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.AddLibId = this.AddSubPart(ref tsubpart2, 10, 430, 32, 16, 1);
      SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("Add Library", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.AddLibTextId = this.AddSubPart(ref tsubpart3, 50, 429, 300, 20, 0);
    }

    private void MakeLibItemGUI()
    {
      if (this.LibVarListId > 0)
        this.RemoveSubPart(this.LibVarListId);
      if (this.BNameId > 0)
        this.RemoveSubPart(this.BNameId);
      if (this.BNameTextId > 0)
        this.RemoveSubPart(this.BNameTextId);
      if (this.RemoveLibId > 0)
        this.RemoveSubPart(this.RemoveLibId);
      if (this.RemoveLibTextId > 0)
        this.RemoveSubPart(this.RemoveLibTextId);
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
      if (this.B5Id > 0)
        this.RemoveSubPart(this.B5Id);
      if (this.B5TextId > 0)
        this.RemoveSubPart(this.B5TextId);
      if (this.LibId > -1)
      {
        this.ss = "Click to change the name of this Library. Make sure its a unique name. So maybe use part of your name or something thats not easily thought of by other designer.";
        SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BNameId = this.AddSubPart(ref tsubpart1, 470, 50, 32, 16, 1);
        SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("name: " + this.game.Data.LibraryObj[this.LibId].name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.BNameTextId = this.AddSubPart(ref tsubpart2, 510, 49, 400, 20, 0);
        this.ss = "Click to change the name of this Library. Make sure its a unique name. So maybe use part of your name or something thats not easily thought of by other designer.";
        SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B2Id = this.AddSubPart(ref tsubpart3, 470, 80, 32, 16, 1);
        SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("creator: " + this.game.Data.LibraryObj[this.LibId].creator, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B2TextId = this.AddSubPart(ref tsubpart4, 510, 79, 400, 20, 0);
        this.ss = "Click to document how to use your library.";
        SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B3Id = this.AddSubPart(ref tsubpart5, 470, 110, 32, 16, 1);
        SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("information: " + Strings.Left(this.game.Data.LibraryObj[this.LibId].information, 20) + "...", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B3TextId = this.AddSubPart(ref tsubpart6, 510, 109, 400, 20, 0);
        this.ss = "Click to change the name of this Library. Make sure its a unique name. So maybe use part of your name or something thats not easily thought of by other designer.";
        SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B4Id = this.AddSubPart(ref tsubpart7, 470, 140, 32, 16, 1);
        SubPartClass tsubpart8 = (SubPartClass) new TextPartClass("version: " + this.game.Data.LibraryObj[this.LibId].version.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B4TextId = this.AddSubPart(ref tsubpart8, 510, 139, 400, 20, 0);
        this.ss = "Click to create a single event library.";
        SubPartClass tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B5Id = this.AddSubPart(ref tsubpart9, 470, 170, 32, 16, 1);
        SubPartClass tsubpart10 = (SubPartClass) new TextPartClass("Export Single Library", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B5TextId = this.AddSubPart(ref tsubpart10, 510, 169, 400, 20, 0);
        this.ss = "Click to remove this Library.";
        SubPartClass tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.RemoveLibId = this.AddSubPart(ref tsubpart11, 10, 450, 32, 16, 1);
        SubPartClass tsubpart12 = (SubPartClass) new TextPartClass("Remove Library", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.RemoveLibTextId = this.AddSubPart(ref tsubpart12, 50, 449, 200, 20, 0);
        if (this.LibVarListId > 0)
          this.RemoveSubPart(this.LibVarListId);
        int num1 = -1;
        int num2 = -1;
        this.LibVarListObj = new ListClass();
        int libVarCounter = this.game.Data.LibVarCounter;
        for (int index = 0; index <= libVarCounter; ++index)
        {
          if (this.game.Data.LibVarObj[index].libId.libSlot == this.LibId)
          {
            ++num2;
            this.LibVarListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.LibVarObj[index].name, index);
            if (this.LibVarId == index)
              num1 = num2;
          }
        }
        if (num1 == -1)
          this.LibVarId = -1;
        ListClass libVarListObj = this.LibVarListObj;
        int tlistselect = num1;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart13 = (SubPartClass) new ListSubPartClass(libVarListObj, 14, 400, tlistselect, game, tHeader: "LibVars", tbackbitmap: (ref local1), bbx: 470, bby: 200, overruleFont: (ref local2));
        this.LibVarListId = this.AddSubPart(ref tsubpart13, 470, 200, 400, 272, 0);
        if (this.AddLibVarId > 0)
          this.RemoveSubPart(this.AddLibVarId);
        if (this.AddLibVarTextId > 0)
          this.RemoveSubPart(this.AddLibVarTextId);
        this.ss = "Click to add a new LibVar";
        SubPartClass tsubpart14 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.AddLibVarId = this.AddSubPart(ref tsubpart14, 470, 500, 32, 16, 1);
        SubPartClass tsubpart15 = (SubPartClass) new TextPartClass("Add LibVar", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.AddLibVarTextId = this.AddSubPart(ref tsubpart15, 520, 499, 300, 20, 0);
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
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.LibVarTypeId = this.AddSubPart(ref tsubpart1, 470, 550, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Type: " + this.game.Data.LibVarObj[this.LibVarId].type.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.LibVarTypeTextId = this.AddSubPart(ref tsubpart2, 510, 549, 400, 20, 0);
      this.ss = "";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.LibVarNameId = this.AddSubPart(ref tsubpart2, 470, 580, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Name: " + this.game.Data.LibVarObj[this.LibVarId].name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.LibVarNameTextId = this.AddSubPart(ref tsubpart2, 510, 579, 400, 20, 0);
      if (this.game.Data.LibVarObj[this.LibVarId].type != NewEnums.LibVarType.Hex)
      {
        this.ss = "";
        tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.LibVarValueTypeId = this.AddSubPart(ref tsubpart2, 470, 610, 32, 16, 1);
        tsubpart2 = (SubPartClass) new TextPartClass("ValueType: " + this.game.Data.LibVarObj[this.LibVarId].valueType.ToString(), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.LibVarValueTypeTextId = this.AddSubPart(ref tsubpart2, 510, 609, 400, 20, 0);
      }
      this.ss = "";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.LibVarInfoId = this.AddSubPart(ref tsubpart2, 470, 640, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Information: " + Strings.Left(this.game.Data.LibVarObj[this.LibVarId].information, 20) + "...", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.LibVarInfoTextId = this.AddSubPart(ref tsubpart2, 510, 639, 400, 20, 0);
      this.ss = "Click to remove this libvar.";
      tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
      this.RemoveLibVarId = this.AddSubPart(ref tsubpart2, 470, 520, 32, 16, 1);
      tsubpart2 = (SubPartClass) new TextPartClass("Remove Libvar", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.RemoveLibVarTextId = this.AddSubPart(ref tsubpart2, 520, 519, 200, 20, 0);
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
                this.MakeLibItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.LibVarListId)
            {
              int num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num3 > -1)
              {
                this.LibVarId = num3;
                this.MakeLibVarItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.AddLibId)
            {
              this.game.Data.AddLibrary();
              this.MakeLibListGUI(this.LibId);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.AddLibVarId)
            {
              this.game.Data.AddLibVar(this.LibId);
              this.MakeLibItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.RemoveLibVarId)
            {
              this.game.Data.RemoveLibVar(this.LibVarId);
              this.MakeLibItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BNameId)
            {
              this.game.Data.LibraryObj[this.LibId].name = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest");
              this.MakeLibListGUI(this.LibId);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B2Id)
            {
              this.game.Data.LibraryObj[this.LibId].creator = Interaction.InputBox("Give creator name, please.", "Shadow Empire : Planetary Conquest");
              this.MakeLibListGUI(this.LibId);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B3Id)
            {
              new Form2((Form) this.formref).Initialize(this.game.Data, 13, this.LibId);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B5Id)
            {
              if (this.LibId < 0)
                return windowReturnClass;
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
              string str = this.game.HandyFunctionsObj.SaveSomething("SE1 Event library(*.se1evlib)|*.se1evlib", "Give save name for event library...", tinitdir, false);
              this.game.FormRef.Cursor = Cursors.WaitCursor;
              DataClass dataClass = this.game.Data.Clone();
              string name = this.game.Data.LibraryObj[this.LibId].name;
              for (int regimeCounter = dataClass.RegimeCounter; regimeCounter >= 0; regimeCounter += -1)
                dataClass.RemoveRegime(regimeCounter);
              for (int locCounter = dataClass.LocCounter; locCounter >= 0; locCounter += -1)
                dataClass.RemoveLoc(locCounter);
              int[] numArray = new int[dataClass.SmallPicCounter + 1];
              int smallPicCounter1 = dataClass.SmallPicCounter;
              for (int index2 = 0; index2 <= smallPicCounter1; ++index2)
                numArray[index2] = index2;
              int smallPicCounter2 = dataClass.SmallPicCounter;
              for (int nr = 0; nr <= smallPicCounter2 && dataClass.SmallPicCounter >= 0 && nr <= dataClass.SmallPicCounter; ++nr)
              {
                if (dataClass.SmallLibId[nr].libSlot != this.LibId)
                {
                  int num4 = nr;
                  int num5 = dataClass.SmallPicCounter - 1;
                  for (int index3 = num4; index3 <= num5; ++index3)
                    numArray[index3] = numArray[index3 + 1];
                  dataClass.RemoveSmallPic(nr);
                  if (dataClass.SmallPicCounter > -1)
                    --nr;
                }
              }
              int smallPicCounter3 = dataClass.SmallPicCounter;
              for (int index4 = 0; index4 <= smallPicCounter3; ++index4)
                this.game.Data.SmallLibId[numArray[index4]].id = index4;
              for (int libraryCounter = dataClass.LibraryCounter; libraryCounter >= 0; libraryCounter += -1)
              {
                if (Operators.CompareString(dataClass.LibraryObj[libraryCounter].name, name, false) != 0)
                  dataClass.RemoveLibrary(libraryCounter);
              }
              int eventCounter = dataClass.EventCounter;
              for (int index5 = 0; index5 <= eventCounter; ++index5)
              {
                if (dataClass.EventObj[index5].LibId.libSlot == 0 && dataClass.EventObj[index5].LibId.id > -1)
                {
                  dataClass.EventObj[index5].Id = dataClass.EventObj[index5].LibId.id;
                  dataClass.EventObj[index5].LibId.id = -1;
                }
              }
              int stringListCounter = dataClass.StringListCounter;
              for (int index6 = 0; index6 <= stringListCounter; ++index6)
              {
                if (dataClass.StringListObj[index6].LibId.libSlot == 0 && dataClass.StringListObj[index6].LibId.id > -1)
                {
                  dataClass.StringListObj[index6].ID = dataClass.StringListObj[index6].LibId.id;
                  dataClass.StringListObj[index6].LibId.id = -1;
                }
              }
              int eventPicCounter = dataClass.EventPicCounter;
              for (int index7 = 0; index7 <= eventPicCounter; ++index7)
              {
                if (dataClass.eventPicLibId[index7].libSlot == 0 && dataClass.eventPicLibId[index7].id > -1)
                {
                  dataClass.EventPicNr[index7] = dataClass.eventPicLibId[index7].id;
                  dataClass.eventPicLibId[index7].id = -1;
                }
              }
              dataClass.MasterFile = "";
              dataClass.Description = "Event library";
              dataClass.Name = name + " event library";
              dataClass.serialize(str);
              this.game.HandyFunctionsObj.ZipFile(str);
              windowReturnClass.SetFlag(true);
              this.game.FormRef.Cursor = Cursors.Default;
              int num6 = (int) Interaction.MsgBox((object) "Saved", Title: ((object) "Shadow Empire : Planetary Conquest"));
            }
            else
            {
              if (num1 == this.LibVarNameId)
              {
                this.game.Data.LibVarObj[this.LibVarId].name = Interaction.InputBox("Give name, please.", "Shadow Empire : Planetary Conquest");
                this.MakeLibItemGUI();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.LibVarInfoId)
              {
                new Form2((Form) this.formref).Initialize(this.game.Data, 14, this.LibVarId);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.LibVarValueTypeId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 92, this.LibVarId);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.LibVarTypeId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 91, this.LibVarId);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B4Id)
              {
                int num7 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give version number please.", "Shadow Empire : Planetary Conquest")));
                if (num7 >= 1 & num7 <= 9999)
                {
                  this.game.Data.LibraryObj[this.LibId].version = num7;
                }
                else
                {
                  int num8 = (int) Interaction.MsgBox((object) "Value between 1-9999 please.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeLibListGUI(this.LibId);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.RemoveLibId)
              {
                this.game.Data.RemoveLibrary(this.LibId);
                if (this.LibId > this.game.Data.LibraryCounter)
                  this.LibId = this.game.Data.LibraryCounter;
                this.LibVarId = -1;
                this.MakeLibListGUI(this.LibId);
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
