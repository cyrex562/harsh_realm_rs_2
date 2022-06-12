// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleLibImportWindow
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class SimpleLibImportWindow : WindowClass
  {
    private DataClass TData;
    private int but1id;
    private int but2id;
    private int LibListId;
    private ListClass LibListObj;
    private int LibId;
    private int ImpId;
    private int but2idb;
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
    private int Op3ListId;
    private ListClass Op3ListObj;
    private int Op3Id;
    private int Change3Id;
    private int[] subReg;
    private int[] subPpl;
    private int[] subLib;
    private int[] subLibAtStart;
    private bool[] regActive;
    private bool[] regSubObligatoire;
    private bool quitNow;

    public SimpleLibImportWindow(ref GameClass tGame)
      : base(ref tGame, 1024, 768, 9)
    {
      this.import = new bool[2];
      this.subReg = new int[2];
      this.subPpl = new int[2];
      this.subLib = new int[2];
      this.subLibAtStart = new int[2];
      this.regActive = new bool[1];
      this.regSubObligatoire = new bool[1];
      this.game.FormRef.Cursor = Cursors.WaitCursor;
      this.game.HandyFunctionsObj.LoadLibrary(ref this.TData);
      this.game.FormRef.Cursor = Cursors.Default;
      this.import = new bool[this.TData.LibraryCounter + 1];
      this.subReg = new int[this.TData.RegimeCounter + 1];
      this.subPpl = new int[this.TData.PeopleCounter + 1];
      this.subLib = new int[this.TData.LibraryCounter + 1];
      this.subLibAtStart = new int[this.TData.LibraryCounter + 1];
      int regimeCounter1 = this.TData.RegimeCounter;
      for (int index1 = 0; index1 <= regimeCounter1; ++index1)
      {
        this.subReg[index1] = -1;
        if (this.TData.RegimeObj[index1].libId.libSlot > -1)
        {
          int regimeCounter2 = this.game.Data.RegimeCounter;
          for (int index2 = 0; index2 <= regimeCounter2; ++index2)
          {
            if (this.game.Data.RegimeObj[index2].libId.libSlot > -1 && Operators.CompareString(this.TData.LibraryObj[this.TData.RegimeObj[index1].libId.libSlot].name, this.game.Data.LibraryObj[this.game.Data.RegimeObj[index2].libId.libSlot].name, false) == 0 && this.TData.RegimeObj[index1].id == this.game.Data.RegimeObj[index2].libId.id)
              this.subReg[index1] = index2;
          }
        }
      }
      int peopleCounter1 = this.TData.PeopleCounter;
      for (int index3 = 0; index3 <= peopleCounter1; ++index3)
      {
        this.subPpl[index3] = -1;
        if (this.TData.PeopleObj[index3].LibId.libSlot > -1)
        {
          int peopleCounter2 = this.game.Data.PeopleCounter;
          for (int index4 = 0; index4 <= peopleCounter2; ++index4)
          {
            if (this.game.Data.PeopleObj[index4].LibId.libSlot > -1 && Operators.CompareString(this.TData.LibraryObj[this.TData.PeopleObj[index3].LibId.libSlot].name, this.game.Data.LibraryObj[this.game.Data.PeopleObj[index4].LibId.libSlot].name, false) == 0 && this.TData.PeopleObj[index3].id == this.game.Data.PeopleObj[index4].LibId.id)
              this.subPpl[index3] = index4;
          }
        }
      }
      int libraryCounter1 = this.TData.LibraryCounter;
      for (int index5 = 0; index5 <= libraryCounter1; ++index5)
      {
        this.subLib[index5] = -1;
        this.subLibAtStart[index5] = -1;
        int libraryCounter2 = this.game.Data.LibraryCounter;
        for (int index6 = 0; index6 <= libraryCounter2; ++index6)
        {
          if (Operators.CompareString(this.game.Data.LibraryObj[index6].name, this.TData.LibraryObj[index5].name, false) == 0)
          {
            this.subLib[index5] = index6;
            this.subLibAtStart[index5] = index6;
          }
        }
      }
      this.OpId = -1;
      this.Op2Id = -1;
      this.Op3Id = -1;
      this.game.EditObj.TempRegimeSlot = -1;
      this.game.EditObj.TempPeopleSlot = -1;
      if (Operators.CompareString(Strings.Trim(Strings.LCase(this.TData.RuleSetName)), Strings.Trim(Strings.LCase(this.game.Data.RuleSetName)), false) != 0)
      {
        if (Interaction.MsgBox((object) ("You are attempting to load a library defined with ruleset '" + this.TData.RuleSetName + "'. It is not the same as our currents scenario ruleset '" + this.game.Data.RuleSetName + "'. Combining libraries and simple editor masterfiles from different rulesets can cause problems. Proceed at own risk. Do you want to proceed?"), MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.No)
          this.quitNow = true;
      }
      this.DoStuff();
    }

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (!this.quitNow)
        return windowReturnClass;
      this.TData = (DataClass) null;
      windowReturnClass.AddCommand(6, 0);
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    public override void DoRefresh()
    {
      if (this.game.EditObj.TempRegimeSlot != -1)
      {
        if (this.game.EditObj.TempRegimeSlot <= -2)
          this.game.EditObj.TempRegimeSlot = -1;
        this.subReg[this.OpId] = this.game.EditObj.TempRegimeSlot;
        this.game.EditObj.TempRegimeSlot = -1;
      }
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
      DrawMod.DrawMessFrameSimplePopup(ref this.OwnBitmap, ref graphics, 0, 0, 1024, 768, "Loading libs from: '" + this.game.EditObj.TempFileName.Replace(this.game.AppPath, "") + "'");
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      if (this.quitNow)
        return;
      if (this.but1id > 0)
        this.RemoveSubPart(this.but1id);
      if (this.but2id > 0)
        this.RemoveSubPart(this.but2id);
      if (this.but2idb > 0)
        this.RemoveSubPart(this.but2idb);
      if (this.OpListId > 0)
        this.RemoveSubPart(this.OpListId);
      if (this.ChangeId > 0)
        this.RemoveSubPart(this.ChangeId);
      if (this.Op2ListId > 0)
        this.RemoveSubPart(this.Op2ListId);
      if (this.Change2Id > 0)
        this.RemoveSubPart(this.Change2Id);
      if (this.Op3ListId > 0)
        this.RemoveSubPart(this.Op3ListId);
      if (this.Change3Id > 0)
        this.RemoveSubPart(this.Change3Id);
      if (this.LibListId > 0)
        this.RemoveSubPart(this.LibListId);
      this.LibListObj = new ListClass();
      int num1 = -1;
      int num2 = -1;
      int libraryCounter1 = this.TData.LibraryCounter;
      for (int index1 = 0; index1 <= libraryCounter1; ++index1)
      {
        bool flag1 = true;
        bool flag2 = false;
        bool flag3 = false;
        bool flag4 = false;
        bool flag5 = false;
        bool flag6 = false;
        int sfTypeCounter = this.TData.SFTypeCounter;
        for (int index2 = 0; index2 <= sfTypeCounter; ++index2)
        {
          if (this.TData.SFTypeObj[index2].LibId.libSlot == index1)
            flag2 = true;
        }
        int actionCardCounter = this.TData.ActionCardCounter;
        for (int index3 = 0; index3 <= actionCardCounter; ++index3)
        {
          if (this.TData.ActionCardObj[index3].LibId.libSlot == index1)
            flag3 = true;
        }
        int historicalUnitCounter1 = this.TData.HistoricalUnitCounter;
        for (int index4 = 0; index4 <= historicalUnitCounter1; ++index4)
        {
          if (this.TData.HistoricalUnitObj[index4].LibId.libSlot == index1 && this.TData.HistoricalUnitObj[index4].CommanderName.Length < 1)
            flag4 = true;
        }
        int historicalUnitCounter2 = this.TData.HistoricalUnitCounter;
        for (int index5 = 0; index5 <= historicalUnitCounter2; ++index5)
        {
          if (this.TData.HistoricalUnitObj[index5].LibId.libSlot == index1 && this.TData.HistoricalUnitObj[index5].CommanderName.Length > 0)
            flag5 = true;
        }
        int eventCounter = this.TData.EventCounter;
        for (int index6 = 0; index6 <= eventCounter; ++index6)
        {
          if (this.TData.EventObj[index6].LibId.libSlot == index1)
            flag6 = true;
        }
        if (this.game.EditObj.TempFileType == NewEnums.LibFileType.LoadEvents)
        {
          if (flag2)
            flag1 = false;
          if (flag4)
            flag1 = false;
          if (flag5)
            flag1 = false;
        }
        if (this.game.EditObj.TempFileType == NewEnums.LibFileType.LoadHistoricals)
        {
          if (flag6)
            flag1 = false;
          if (flag2)
            flag1 = false;
          if (flag5)
            flag1 = false;
          if (flag3)
            flag1 = false;
        }
        if (this.game.EditObj.TempFileType == NewEnums.LibFileType.LoadOfficerCards)
        {
          if (flag2)
            flag1 = false;
          if (flag4)
            flag1 = false;
          if (flag5)
            flag1 = false;
        }
        if (this.game.EditObj.TempFileType == NewEnums.LibFileType.LoadOfficers)
        {
          if (flag6)
            flag1 = false;
          if (flag2)
            flag1 = false;
          if (flag4)
            flag1 = false;
          if (flag3)
            flag1 = false;
        }
        if (this.game.EditObj.TempFileType == NewEnums.LibFileType.LoadTroops)
        {
          if (flag6)
            flag1 = false;
          if (flag5)
            flag1 = false;
          if (flag4)
            flag1 = false;
          if (flag3)
            flag1 = false;
        }
        if (flag1)
        {
          ++num2;
          this.LibListObj.add(Conversion.Str((object) index1) + ") " + this.TData.LibraryObj[index1].name, index1);
          if (this.LibId == index1)
            num1 = num2;
        }
      }
      if (num1 == -1)
        this.LibId = -1;
      ListClass libListObj = this.LibListObj;
      int tlistselect1 = num1;
      GameClass game1 = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font1 = (Font) null;
      ref Font local2 = ref font1;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(libListObj, 10, 400, tlistselect1, game1, true, "Libraries", false, tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: 50, bby: 125, tMarcStyle: true, overruleFont: (ref local2));
      this.LibListId = this.AddSubPart(ref tsubpart1, 50, 125, 400, 208, 0);
      if (this.textid > 0)
        this.RemoveSubPart(this.textid);
      if (this.switchid > 0)
        this.RemoveSubPart(this.switchid);
      if (this.ImpId > 0)
        this.RemoveSubPart(this.ImpId);
      int num3 = -1;
      SubPartClass tsubpart2;
      if (this.LibId > -1)
      {
        DependencyClass dependencyClass1 = new DependencyClass();
        DependencyClass dependencyClass2 = this.game.HandyFunctionsObj.Libraries_CheckDependency(ref this.TData, this.LibId, true);
        bool flag7 = true;
        int libraryCounter2 = this.game.Data.LibraryCounter;
        for (int index = 0; index <= libraryCounter2; ++index)
        {
          if (Operators.CompareString(this.game.Data.LibraryObj[index].name, this.TData.LibraryObj[this.LibId].name, false) == 0)
          {
            flag7 = false;
            num3 = this.game.Data.LibraryObj[index].version;
          }
        }
        int libraryCounter3 = this.game.Data.LibraryCounter;
        for (int index = 0; index <= libraryCounter3; ++index)
        {
          if (Operators.CompareString(this.game.Data.LibraryObj[index].name, this.TData.LibraryObj[this.LibId].name, false) == 0)
          {
            flag7 = false;
            num3 = this.game.Data.LibraryObj[index].version;
          }
        }
        this.regActive = new bool[this.TData.RegimeCounter + 1];
        this.regSubObligatoire = new bool[this.TData.RegimeCounter + 1];
        int num4 = 0;
        int regimeCounter1 = this.TData.RegimeCounter;
        for (int index7 = 0; index7 <= regimeCounter1; ++index7)
        {
          if (this.TData.RegimeObj[index7].libId.libSlot == this.LibId)
            this.regActive[index7] = true;
          int historicalUnitCounter = this.TData.HistoricalUnitCounter;
          for (int index8 = 0; index8 <= historicalUnitCounter; ++index8)
          {
            if (this.TData.HistoricalUnitObj[index8].LibId.libSlot == this.LibId & this.TData.HistoricalUnitObj[index8].TempRegime == index7 & !this.regActive[index7])
            {
              this.regActive[this.TData.HistoricalUnitObj[index8].TempRegime] = true;
              this.regSubObligatoire[this.TData.HistoricalUnitObj[index8].TempRegime] = true;
            }
          }
          if (this.regActive[index7])
            ++num4;
        }
        int y1 = 390;
        bool flag8;
        if (num4 > 0)
        {
          DrawMod.DrawTextColouredMarc(ref graphics, "Substitute regimes in this library by existing ones?", this.game.MarcFont4, 510, y1, Color.White);
          y1 += 30;
          this.OpListObj = new ListClass();
          int num5 = -1;
          int num6 = -1;
          int regimeCounter2 = this.TData.RegimeCounter;
          for (int index = 0; index <= regimeCounter2; ++index)
          {
            if (this.regActive[index])
            {
              ++num6;
              string tvalue = "Import this regime";
              if (this.regSubObligatoire[index])
                tvalue = "Not yet substituted";
              if (this.subReg[index] > -1)
                tvalue = "Subst. with " + this.game.Data.RegimeObj[this.subReg[index]].Name;
              else if (Strings.InStr(Strings.LCase(this.TData.RegimeObj[index].Name), "only") > 0 & this.subReg[index] == -1)
                flag8 = true;
              if (this.game.Data.Product == 6 & this.subReg[index] == -1)
                flag8 = true;
              this.OpListObj.add(Conversion.Str((object) index) + ") " + this.TData.RegimeObj[index].Name, index, tvalue);
              if (this.OpId == -1)
                this.OpId = index;
              if (this.OpId == index)
                num5 = num6;
            }
          }
          ListClass opListObj = this.OpListObj;
          int tlistselect2 = num5;
          GameClass game2 = this.game;
          ref Bitmap local3 = ref this.OwnBitmap;
          int bby = y1;
          Font font2 = (Font) null;
          ref Font local4 = ref font2;
          SubPartClass tsubpart3 = (SubPartClass) new ListSubPartClass(opListObj, 5, 350, tlistselect2, game2, true, "Regimes", false, tShowPair: true, tValueWidth: 225, tdotopandbottom: false, tbackbitmap: (ref local3), bbx: 500, bby: bby, tMarcStyle: true, overruleFont: (ref local4));
          this.OpListId = this.AddSubPart(ref tsubpart3, 500, y1, 350, 96, 0);
          SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Change", 130, tBackbitmap: (ref this.OwnBitmap), bbx: 870, bby: (y1 + 10), theight: 45, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.ChangeId = this.AddSubPart(ref tsubpart4, 870, y1 + 10, 130, 45, 1);
        }
        int num7 = 0;
        int peopleCounter1 = this.TData.PeopleCounter;
        for (int index = 0; index <= peopleCounter1; ++index)
        {
          if (this.TData.PeopleObj[index].LibId.libSlot == this.LibId)
            ++num7;
        }
        int y2 = y1 + 110;
        bool flag9;
        if (num7 > 0)
        {
          DrawMod.DrawTextColouredMarc(ref graphics, "Substitute peoples in this library by existing ones?", this.game.MarcFont4, 510, y2, Color.White);
          y2 += 30;
          this.Op2ListObj = new ListClass();
          int num8 = -1;
          int num9 = -1;
          int peopleCounter2 = this.TData.PeopleCounter;
          for (int index = 0; index <= peopleCounter2; ++index)
          {
            if (this.TData.PeopleObj[index].LibId.libSlot == this.LibId)
            {
              ++num9;
              string tvalue = "Import this people";
              if (this.subPpl[index] > -1)
                tvalue = "Subst. with " + this.game.Data.PeopleObj[this.subPpl[index]].Name;
              else if (Strings.InStr(Strings.LCase(this.TData.PeopleObj[index].Name), "only") > 0 & this.subPpl[index] == -1)
                flag9 = true;
              this.Op2ListObj.add(Conversion.Str((object) index) + ") " + this.TData.PeopleObj[index].Name, index, tvalue);
              if (this.Op2Id == -1)
                this.Op2Id = index;
              if (this.Op2Id == index)
                num8 = num9;
            }
          }
          ListClass op2ListObj = this.Op2ListObj;
          int tlistselect3 = num8;
          GameClass game3 = this.game;
          ref Bitmap local5 = ref this.OwnBitmap;
          int bby = y2;
          Font font3 = (Font) null;
          ref Font local6 = ref font3;
          SubPartClass tsubpart5 = (SubPartClass) new ListSubPartClass(op2ListObj, 5, 350, tlistselect3, game3, true, "Peoples", false, tShowPair: true, tValueWidth: 225, tdotopandbottom: false, tbackbitmap: (ref local5), bbx: 500, bby: bby, tMarcStyle: true, overruleFont: (ref local6));
          this.Op2ListId = this.AddSubPart(ref tsubpart5, 500, y2, 350, 128, 0);
          SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("Change", 130, tBackbitmap: (ref this.OwnBitmap), bbx: 870, bby: (y2 + 10), theight: 45, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.Change2Id = this.AddSubPart(ref tsubpart6, 870, y2 + 10, 130, 45, 1);
        }
        DrawMod.DrawTextColouredMarc(ref graphics, "Substitute existing library", this.game.MarcFont4, 50, 330, Color.White);
        int num10 = y2 + 30;
        this.Op3ListObj = new ListClass();
        int num11 = -1;
        int num12 = -1;
        bool flag10 = true;
        int libraryCounter4 = this.game.Data.LibraryCounter;
        for (int index = 0; index <= libraryCounter4; ++index)
        {
          ++num12;
          string tvalue = "-";
          if (this.subLib[this.LibId] == index)
          {
            tvalue = "Replace this lib";
            if (this.subLibAtStart[this.LibId] > -1)
              flag10 = false;
          }
          this.Op3ListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.LibraryObj[index].name, index, tvalue);
          if (this.Op3Id == index)
            num11 = num12;
          if (this.Op3Id == -1 & this.subLib[this.LibId] == index)
          {
            num11 = num12;
            this.Op3Id = index;
          }
        }
        ListClass op3ListObj = this.Op3ListObj;
        int tlistselect4 = num11;
        GameClass game4 = this.game;
        ref Bitmap local7 = ref this.OwnBitmap;
        Font font4 = (Font) null;
        ref Font local8 = ref font4;
        SubPartClass tsubpart7 = (SubPartClass) new ListSubPartClass(op3ListObj, 13, 420, tlistselect4, game4, true, "Library Replacement", false, tShowPair: true, tValueWidth: 125, tdotopandbottom: false, tbackbitmap: (ref local7), bbx: 50, bby: 360, tMarcStyle: true, overruleFont: (ref local8));
        this.Op3ListId = this.AddSubPart(ref tsubpart7, 50, 360, 420, 256, 0);
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Change", 130, tBackbitmap: (ref this.OwnBitmap), bbx: 50, bby: 620, theight: 45, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.Change3Id = this.AddSubPart(ref tsubpart2, 50, 620, 130, 45, 1);
        DrawMod.DrawTextColouredMarc(ref graphics, this.TData.LibraryObj[this.LibId].name, this.game.MarcFont1, 510, 125, Color.White);
        if (dependencyClass2.ok)
        {
          int regimeCounter3 = this.TData.RegimeCounter;
          for (int index = 0; index <= regimeCounter3; ++index)
          {
            if (this.regActive[index] & this.regSubObligatoire[index] & this.subReg[index] == -1)
            {
              dependencyClass2.ok = false;
              dependencyClass2.text = "You must substitute the regimes in the substitute list for this import.";
            }
          }
        }
        if (!dependencyClass2.ok)
        {
          DrawMod.DrawTextColouredMarc(ref graphics, "Dependency problem", this.game.MarcFont3, 510, 170, Color.Salmon);
          tsubpart2 = (SubPartClass) new TextAreaClass2(this.game, 500, 3, this.game.MarcFont4, "Dependency problem details:\r\n" + dependencyClass2.text, 27, ref this.OwnBitmap, 500, 245, true, true);
          this.textid = this.AddSubPart(ref tsubpart2, 500, 245, 500, 108, 0);
        }
        else
        {
          if (flag7)
          {
            tsubpart2 = (SubPartClass) new MarcRadioPartClass(0, this.import[this.LibId], tBackbitmap: (ref this.OwnBitmap), bbx: 510, bby: 160);
            this.ImpId = this.AddSubPart(ref tsubpart2, 510, 160, 35, 35, 1);
            DrawMod.DrawTextColouredMarc(ref graphics, "Import this library", this.game.MarcFont3, 550, 165, Color.White);
          }
          else
          {
            if (this.TData.LibraryObj[this.LibId].version > num3)
              DrawMod.DrawTextColouredMarc(ref graphics, "You already have this library. But this is newer version v" + this.TData.LibraryObj[this.LibId].version.ToString(), this.game.MarcFont3, 510, 170, Color.GreenYellow);
            else if (this.TData.LibraryObj[this.LibId].version == num3)
              DrawMod.DrawTextColouredMarc(ref graphics, "You already have this library. Seems to be same version v" + this.TData.LibraryObj[this.LibId].version.ToString(), this.game.MarcFont3, 510, 170, Color.Yellow);
            else if (this.TData.LibraryObj[this.LibId].version == num3)
              DrawMod.DrawTextColouredMarc(ref graphics, "You already have this library. But this is older version v" + this.TData.LibraryObj[this.LibId].version.ToString(), this.game.MarcFont3, 510, 170, Color.Salmon);
            tsubpart2 = (SubPartClass) new MarcRadioPartClass(0, this.import[this.LibId], tBackbitmap: (ref this.OwnBitmap), bbx: 510, bby: 200);
            this.ImpId = this.AddSubPart(ref tsubpart2, 510, 200, 35, 35, 1);
            DrawMod.DrawTextColouredMarc(ref graphics, "Reload this library", this.game.MarcFont3, 550, 205, Color.White);
          }
          int num13 = 0;
          if (this.OpListId < 1 & this.Op2ListId < 1)
            num13 += 9;
          tsubpart2 = (SubPartClass) new TextAreaClass2(this.game, 500, 3 + num13, this.game.MarcFont4, this.TData.LibraryObj[this.LibId].information, 27, ref this.OwnBitmap, 500, 245);
          this.textid = this.AddSubPart(ref tsubpart2, 500, 245, 500, (4 + num13) * 27, 0);
        }
        if (flag9 | flag8)
        {
          tsubpart2 = (SubPartClass) new TextButtonPartClass("Import " + this.impCount.ToString() + " libs", 200, "You cannot import if there are peoples with 'only' in name that have not yet been substituted. Or if there are Regimes that have not yet been substituted.", ref this.OwnBitmap, 524, 680, true, theight: 45, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.but2idb = this.AddSubPart(ref tsubpart2, 524, 680, 200, 45, 1);
        }
        else if (this.impCount > 0)
        {
          tsubpart2 = (SubPartClass) new TextButtonPartClass("Import " + this.impCount.ToString() + " libs", 200, tBackbitmap: (ref this.OwnBitmap), bbx: 524, bby: 680, theight: 45, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.but2id = this.AddSubPart(ref tsubpart2, 524, 680, 200, 45, 1);
        }
        else
        {
          tsubpart2 = (SubPartClass) new TextButtonPartClass("Import " + this.impCount.ToString() + " libs", 200, "You have to flag a library in order to import it.", ref this.OwnBitmap, 524, 680, true, theight: 45, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.but2idb = this.AddSubPart(ref tsubpart2, 524, 680, 200, 45, 1);
        }
      }
      if (Operators.CompareString(this.TData.RuleSetName, this.game.Data.RuleSetName, false) != 0)
        DrawMod.DrawTextColouredMarcCenter(ref graphics, "Lib uses: '" + this.TData.RuleSetName + "', is different from scn ruleset: '" + this.game.Data.RuleSetName + "'", this.game.MarcFont3, 512, 70, Color.Salmon);
      else
        DrawMod.DrawTextColouredMarcCenter(ref graphics, "Library uses same ruleset as your scenario: '" + this.game.Data.RuleSetName + "'", this.game.MarcFont3, 512, 70, Color.GreenYellow);
      tsubpart2 = (SubPartClass) new TextButtonPartClass("Cancel", 200, tBackbitmap: (ref this.OwnBitmap), bbx: 300, bby: 680, theight: 45, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.but1id = this.AddSubPart(ref tsubpart2, 300, 680, 200, 45, 1);
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
            if (num1 == this.LibListId)
            {
              int num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num2 > -1)
                this.LibId = num2;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.textid)
            {
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OpListId)
            {
              int num3 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num3 > -1)
                this.OpId = num3;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Op2ListId)
            {
              int num4 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num4 > -1)
                this.Op2Id = num4;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.Op3ListId)
            {
              int num5 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num5 > -1)
              {
                this.Op3Id = num5;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else
            {
              if (num1 == this.Change3Id)
              {
                if (this.subLib[this.LibId] == this.subLibAtStart[this.LibId] & this.subLibAtStart[this.LibId] > -1 && Interaction.MsgBox((object) "Are you sure? This will cause a duplicate library. ", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.No)
                {
                  this.DoStuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                this.subLib[this.LibId] = this.subLib[this.LibId] == this.Op3Id ? -1 : this.Op3Id;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.ChangeId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 98, -1);
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
                this.game.HandyFunctionsObj.ActuallyImportLibs(ref this.TData, ref this.import, ref this.subLib, ref this.subPpl, ref this.subReg);
                this.game.FormRef.Cursor = Cursors.Default;
                this.TData = (DataClass) null;
                windowReturnClass.AddCommand(6, 0);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.ImpId)
              {
                if (!this.import[this.LibId])
                  ++this.impCount;
                else
                  --this.impCount;
                this.import[this.LibId] = !this.import[this.LibId];
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
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
