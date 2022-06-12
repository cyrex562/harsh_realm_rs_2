﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.EventWindowClass
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
  public class EventWindowClass : WindowClass
  {
    private int Info1textId;
    private int info1id;
    private int info2textid;
    private int info2id;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int AddEventId;
    private int RemoveEventId;
    private int EventUpId;
    private int EventDownId;
    private int GroupListId;
    private ListClass GroupListObj;
    private object groupdetail;
    private int OptionsList2Id;
    private ListClass OptionsList2Obj;
    private int info3textid;
    private int info3id;
    private int AddCommandId;
    private int RemoveCommandId;
    private int CommandUpId;
    private int CommandDownId;
    private int CommandCopy;
    private int CommandPaste;
    private int EventCopy;
    private int EventPaste;
    private int setCat;
    private int setPrio;
    private int setPrioB;
    private int DescriptId;
    private int CurTyp;
    private int Typ1;
    private int Typ1b;
    private int Typ2;
    private int Typ2b;
    private int Typ3;
    private int Typ3b;
    private int Typ4;
    private int Typ4b;
    private int Typ5;
    private int Typ5b;
    private int Typ6;
    private int Typ6b;
    private int Typ7;
    private int Typ7b;
    private int TypMode;
    private int TypModeB;
    private int typstr;
    private int typstrb;
    private int Export;
    private int ExportB;
    private int Import1;
    private int Import2;
    private int replaceId;
    private int Item1;
    private int Item1b;
    private int cat;
    private int Item2;
    private int Item2b;
    private int Item3;
    private int Item3b;
    private int Item4;
    private int Item4b;
    private int Item5;
    private int Item5b;
    private string[] ITEMNAME;
    private int OptionsList3Id;
    private ListClass OptionsList3Obj;
    private int OptionsList4Id;
    private ListClass OptionsList4Obj;
    private int OptionsList5Id;
    private ListClass OptionsList5Obj;
    private int OptionsList6Id;
    private ListClass OptionsList6Obj;
    private int Tab1;
    private int Tab2;
    private int Tab3;
    private int Tab4;
    private int Tab5;
    private int Tab6;
    private int Tab7;
    private int Tab8;
    private int Tab9;
    private int Tab10;
    private int tab110;
    private int tab110b;
    private int tab111;
    private int tab111b;
    private int NTab1;
    private int NTab2;
    private int NTab1b;
    private int NTab2b;
    private int ntab1x;
    private int ntab2x;
    private int setLib;
    private int Tab1b;
    private int Tab2b;
    private int Tab3b;
    private int Tab4b;
    private int Tab5b;
    private int Tab6b;
    private int Tab7b;
    private int Tab8b;
    private int Tab9b;
    private int Tab10b;
    private int tab11;
    private int tab12;
    private int tab13;
    private int tab131;
    private int tab132;
    private int tab133;
    private int tab14;
    private int tab15;
    private int tab16;
    private int tab17;
    private int tab18;
    private int tab11b;
    private int tab12b;
    private int tab13b;
    private int tab131b;
    private int tab132b;
    private int tab133b;
    private int tab14b;
    private int tab15b;
    private int tab16b;
    private int tab17b;
    private int tab18b;
    private int tab19b;
    private int tab19;
    private int tabx1;
    private int tabx2;
    private int tabx3;
    private int quick1;
    private int quick1b;
    private int quick2;
    private int quick2b;
    private int quick3;
    private int quick3b;
    private int quick4;
    private int quick4b;
    private int quick5;
    private int quick5b;
    private int quick6;
    private int quick6b;
    private int quick7;
    private int quick7b;
    private int quick8;
    private int quick8b;
    private int[] tbutton;
    private int[] tline;
    private int[] toption;
    private int InsertId;
    private int allowExecuteId;
    private int[] trefer;
    private int tok;
    private int tok2;
    private int tta;
    private string[] temptext;
    private int[] tempoption;
    private int[] temprefer;
    private bool DoEscape;
    private int ExecNow;
    private int detail1;
    private int detail2;
    private int detail3;
    private int detail4;
    private int detailchoice;
    private int detailLib;
    private string[] COMMANDTYPE;
    private string String1;
    private string String2;
    private string String3;
    private bool DoingSlots;
    private int SetSlot;
    private int StepCurrent;
    private int VarExtra;
    private const int VARINFO = 1;
    private const int CHECKTYPE = 2;
    private const int CONDITION = 3;
    private const int EXECTYPE = 4;
    private const int SETTYPE = 5;
    private const int STRINGINFO = 6;
    private const int CHECK = 1;
    private const int ENDCHECK = 2;
    private const int EXEC = 3;
    private const int SETVAR = 4;
    private const int LOOPER = 5;
    private const int ENDLOOPER = 6;
    private const int COMMENT = 7;
    private string ss;

    public EventWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight)
    {
      this.ITEMNAME = new string[6];
      this.tbutton = new int[20];
      this.tline = new int[20];
      this.toption = new int[20];
      this.trefer = new int[20];
      this.temptext = new string[20];
      this.tempoption = new int[20];
      this.temprefer = new int[20];
      this.COMMANDTYPE = new string[11];
      this.detail1 = -1;
      this.detail2 = -1;
      this.detail3 = -1;
      this.detail4 = -1;
      this.groupdetail = (object) -1;
      this.cat = -1;
      this.COMMANDTYPE[0] = "EMPTY";
      this.COMMANDTYPE[1] = nameof (CHECK);
      this.COMMANDTYPE[2] = "END CHECK";
      this.COMMANDTYPE[3] = "EXECUTE";
      this.COMMANDTYPE[4] = nameof (SETVAR);
      this.COMMANDTYPE[5] = nameof (LOOPER);
      this.COMMANDTYPE[6] = "END LOOPER";
      this.COMMANDTYPE[7] = nameof (COMMENT);
      this.DoingSlots = false;
      this.dostuff();
    }

    public override void DoRefresh() => this.dostuff();

    public void bigclear()
    {
      if (this.OptionsList3Id > 0)
      {
        this.RemoveSubPart(this.OptionsList3Id);
        this.OptionsList3Id = 0;
      }
      if (this.GroupListId > 0)
      {
        this.RemoveSubPart(this.GroupListId);
        this.GroupListId = 0;
      }
      if (this.DescriptId <= 0)
        return;
      this.RemoveSubPart(this.DescriptId);
      this.DescriptId = 0;
    }

    public void dostuff()
    {
      if (this.info1id > 0)
        this.RemoveSubPart(this.info1id);
      if (this.Info1textId > 0)
        this.RemoveSubPart(this.Info1textId);
      if (this.info2textid > 0)
        this.RemoveSubPart(this.info2textid);
      if (this.info3id > 0)
        this.RemoveSubPart(this.info3id);
      if (this.setLib > 0)
        this.RemoveSubPart(this.setLib);
      if (this.info3textid > 0)
        this.RemoveSubPart(this.info3textid);
      if (this.OptionsListId > 0)
        this.RemoveSubPart(this.OptionsListId);
      if (this.OptionsList2Id > 0)
        this.RemoveSubPart(this.OptionsList2Id);
      if (this.OptionsList4Id > 0)
        this.RemoveSubPart(this.OptionsList4Id);
      if (this.OptionsList5Id > 0)
        this.RemoveSubPart(this.OptionsList5Id);
      if (this.OptionsList6Id > 0)
        this.RemoveSubPart(this.OptionsList6Id);
      if (this.AddEventId > 0)
        this.RemoveSubPart(this.AddEventId);
      if (this.RemoveEventId > 0)
        this.RemoveSubPart(this.RemoveEventId);
      if (this.AddCommandId > 0)
        this.RemoveSubPart(this.AddCommandId);
      if (this.RemoveCommandId > 0)
        this.RemoveSubPart(this.RemoveCommandId);
      if (this.CommandCopy > 0)
        this.RemoveSubPart(this.CommandCopy);
      if (this.CommandPaste > 0)
        this.RemoveSubPart(this.CommandPaste);
      if (this.EventCopy > 0)
        this.RemoveSubPart(this.EventCopy);
      if (this.EventPaste > 0)
        this.RemoveSubPart(this.EventPaste);
      if (this.setPrio > 0)
        this.RemoveSubPart(this.setPrio);
      if (this.setPrioB > 0)
        this.RemoveSubPart(this.setPrioB);
      if (this.Typ1 > 0)
        this.RemoveSubPart(this.Typ1);
      if (this.Typ1b > 0)
        this.RemoveSubPart(this.Typ1b);
      if (this.Typ2 > 0)
        this.RemoveSubPart(this.Typ2);
      if (this.Typ2b > 0)
        this.RemoveSubPart(this.Typ2b);
      if (this.Typ3 > 0)
        this.RemoveSubPart(this.Typ3);
      if (this.Typ3b > 0)
        this.RemoveSubPart(this.Typ3b);
      if (this.Typ4 > 0)
        this.RemoveSubPart(this.Typ4);
      if (this.Typ4b > 0)
        this.RemoveSubPart(this.Typ4b);
      if (this.Typ5 > 0)
        this.RemoveSubPart(this.Typ5);
      if (this.Typ5b > 0)
        this.RemoveSubPart(this.Typ5b);
      if (this.Typ6 > 0)
        this.RemoveSubPart(this.Typ6);
      if (this.Typ6b > 0)
        this.RemoveSubPart(this.Typ6b);
      if (this.Typ7 > 0)
        this.RemoveSubPart(this.Typ7);
      if (this.Typ7b > 0)
        this.RemoveSubPart(this.Typ7b);
      if (this.CurTyp > 0)
        this.RemoveSubPart(this.CurTyp);
      if (this.Item1 > 0)
        this.RemoveSubPart(this.Item1);
      if (this.Item1b > 0)
        this.RemoveSubPart(this.Item1b);
      if (this.Item2 > 0)
        this.RemoveSubPart(this.Item2);
      if (this.Item2b > 0)
        this.RemoveSubPart(this.Item2b);
      if (this.Item3 > 0)
        this.RemoveSubPart(this.Item3);
      if (this.Item3b > 0)
        this.RemoveSubPart(this.Item3b);
      if (this.quick1 > 0)
        this.RemoveSubPart(this.quick1);
      if (this.quick1b > 0)
        this.RemoveSubPart(this.quick1b);
      if (this.quick2 > 0)
        this.RemoveSubPart(this.quick2);
      if (this.quick2b > 0)
        this.RemoveSubPart(this.quick2b);
      if (this.quick3 > 0)
        this.RemoveSubPart(this.quick3);
      if (this.quick3b > 0)
        this.RemoveSubPart(this.quick3b);
      if (this.quick4 > 0)
        this.RemoveSubPart(this.quick4);
      if (this.quick4b > 0)
        this.RemoveSubPart(this.quick4b);
      if (this.quick5 > 0)
        this.RemoveSubPart(this.quick5);
      if (this.quick5b > 0)
        this.RemoveSubPart(this.quick5b);
      if (this.quick6 > 0)
        this.RemoveSubPart(this.quick6);
      if (this.quick6b > 0)
        this.RemoveSubPart(this.quick6b);
      if (this.quick7 > 0)
        this.RemoveSubPart(this.quick7);
      if (this.quick7b > 0)
        this.RemoveSubPart(this.quick7b);
      if (this.quick8 > 0)
        this.RemoveSubPart(this.quick8);
      if (this.quick8b > 0)
        this.RemoveSubPart(this.quick8b);
      if (this.Tab1 > 0)
        this.RemoveSubPart(this.Tab1);
      if (this.Tab1b > 0)
        this.RemoveSubPart(this.Tab1b);
      if (this.Tab2 > 0)
        this.RemoveSubPart(this.Tab2);
      if (this.Tab2b > 0)
        this.RemoveSubPart(this.Tab2b);
      if (this.NTab1 > 0)
        this.RemoveSubPart(this.NTab1);
      if (this.NTab1b > 0)
        this.RemoveSubPart(this.NTab1b);
      if (this.NTab2 > 0)
        this.RemoveSubPart(this.NTab2);
      if (this.NTab2b > 0)
        this.RemoveSubPart(this.NTab2b);
      if (this.Tab3 > 0)
        this.RemoveSubPart(this.Tab3);
      if (this.Tab3b > 0)
        this.RemoveSubPart(this.Tab3b);
      if (this.Tab4 > 0)
        this.RemoveSubPart(this.Tab4);
      if (this.Tab4b > 0)
        this.RemoveSubPart(this.Tab4b);
      if (this.Tab5 > 0)
        this.RemoveSubPart(this.Tab5);
      if (this.Tab5b > 0)
        this.RemoveSubPart(this.Tab5b);
      if (this.Tab6 > 0)
        this.RemoveSubPart(this.Tab6);
      if (this.Tab6b > 0)
        this.RemoveSubPart(this.Tab6b);
      if (this.Tab7 > 0)
        this.RemoveSubPart(this.Tab7);
      if (this.Tab7b > 0)
        this.RemoveSubPart(this.Tab7b);
      if (this.Tab8 > 0)
        this.RemoveSubPart(this.Tab8);
      if (this.Tab8b > 0)
        this.RemoveSubPart(this.Tab8b);
      if (this.Tab9 > 0)
        this.RemoveSubPart(this.Tab9);
      if (this.Tab9b > 0)
        this.RemoveSubPart(this.Tab9b);
      if (this.Tab10 > 0)
        this.RemoveSubPart(this.Tab10);
      if (this.Tab10b > 0)
        this.RemoveSubPart(this.Tab10b);
      if (this.tab11 > 0)
        this.RemoveSubPart(this.tab11);
      if (this.tab11b > 0)
        this.RemoveSubPart(this.tab11b);
      if (this.tab110 > 0)
        this.RemoveSubPart(this.tab110);
      if (this.tab110b > 0)
        this.RemoveSubPart(this.tab110b);
      if (this.tab111 > 0)
        this.RemoveSubPart(this.tab111);
      if (this.tab111b > 0)
        this.RemoveSubPart(this.tab111b);
      if (this.tab12 > 0)
        this.RemoveSubPart(this.tab12);
      if (this.tab12b > 0)
        this.RemoveSubPart(this.tab12b);
      if (this.tab13 > 0)
        this.RemoveSubPart(this.tab13);
      if (this.tab13b > 0)
        this.RemoveSubPart(this.tab13b);
      if (this.tab131 > 0)
        this.RemoveSubPart(this.tab131);
      if (this.tab131b > 0)
        this.RemoveSubPart(this.tab131b);
      if (this.tab132 > 0)
        this.RemoveSubPart(this.tab132);
      if (this.tab132b > 0)
        this.RemoveSubPart(this.tab132b);
      if (this.tab133 > 0)
        this.RemoveSubPart(this.tab133);
      if (this.tab133b > 0)
        this.RemoveSubPart(this.tab133b);
      if (this.tab14 > 0)
        this.RemoveSubPart(this.tab14);
      if (this.tab14b > 0)
        this.RemoveSubPart(this.tab14b);
      if (this.tab15 > 0)
        this.RemoveSubPart(this.tab15);
      if (this.tab15b > 0)
        this.RemoveSubPart(this.tab15b);
      if (this.tab16 > 0)
        this.RemoveSubPart(this.tab16);
      if (this.tab16b > 0)
        this.RemoveSubPart(this.tab16b);
      if (this.tab17 > 0)
        this.RemoveSubPart(this.tab17);
      if (this.tab17b > 0)
        this.RemoveSubPart(this.tab17b);
      if (this.tab18 > 0)
        this.RemoveSubPart(this.tab18);
      if (this.tab18b > 0)
        this.RemoveSubPart(this.tab18b);
      if (this.tab19 > 0)
        this.RemoveSubPart(this.tab19);
      if (this.tab19b > 0)
        this.RemoveSubPart(this.tab19b);
      if (this.tabx1 > 0)
        this.RemoveSubPart(this.tabx1);
      if (this.tabx2 > 0)
        this.RemoveSubPart(this.tabx2);
      if (this.tabx3 > 0)
        this.RemoveSubPart(this.tabx3);
      if (this.ntab1x > 0)
        this.RemoveSubPart(this.ntab1x);
      if (this.ntab2x > 0)
        this.RemoveSubPart(this.ntab2x);
      if (this.allowExecuteId > 0)
        this.RemoveSubPart(this.allowExecuteId);
      if (this.TypMode > 0)
        this.RemoveSubPart(this.TypMode);
      if (this.TypModeB > 0)
        this.RemoveSubPart(this.TypModeB);
      if (this.Export > 0)
        this.RemoveSubPart(this.Export);
      if (this.ExportB > 0)
        this.RemoveSubPart(this.ExportB);
      if (this.typstr > 0)
        this.RemoveSubPart(this.typstr);
      if (this.typstrb > 0)
        this.RemoveSubPart(this.typstrb);
      if (this.CommandUpId > 0)
        this.RemoveSubPart(this.CommandUpId);
      if (this.CommandDownId > 0)
        this.RemoveSubPart(this.CommandDownId);
      if (this.EventUpId > 0)
        this.RemoveSubPart(this.EventUpId);
      if (this.EventDownId > 0)
        this.RemoveSubPart(this.EventDownId);
      if (this.setCat > 0)
        this.RemoveSubPart(this.setCat);
      if (this.Import1 > 0)
        this.RemoveSubPart(this.Import1);
      if (this.Import2 > 0)
        this.RemoveSubPart(this.Import2);
      if (this.ExecNow > 0)
        this.RemoveSubPart(this.ExecNow);
      if (this.replaceId > 0)
        this.RemoveSubPart(this.replaceId);
      if (this.InsertId > 0)
        this.RemoveSubPart(this.InsertId);
      int index1 = 0;
      do
      {
        if (this.tline[index1] > 0)
          this.RemoveSubPart(this.tline[index1]);
        if (this.toption[index1] > 0)
          this.RemoveSubPart(this.toption[index1]);
        if (this.trefer[index1] > 0)
          this.RemoveSubPart(this.trefer[index1]);
        if (this.tbutton[index1] > 0)
          this.RemoveSubPart(this.tbutton[index1]);
        ++index1;
      }
      while (index1 <= 19);
      if (this.tok > 0)
        this.RemoveSubPart(this.tok);
      if (this.tok2 > 0)
        this.RemoveSubPart(this.tok2);
      if (this.tta > 0)
        this.RemoveSubPart(this.tta);
      if (this.DoingSlots)
        this.TabsheetSlots();
      if (this.DoingSlots)
        return;
      this.ss = "click to exit the event screen";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
      this.info1id = this.AddSubPart(ref tsubpart1, 10, 2, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Exit Event Screen", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.Info1textId = this.AddSubPart(ref tsubpart2, 50, 2, 200, 20, 0);
      this.OptionsList6Obj = new ListClass();
      this.OptionsList6Obj.add("All Events", -1);
      int num1 = 0;
      int libraryCounter = this.game.Data.LibraryCounter;
      string str1;
      for (int index2 = 0; index2 <= libraryCounter; ++index2)
      {
        str1 = this.game.Data.LibraryObj[index2].name;
        this.OptionsList6Obj.add(str1, index2 + 1);
        if (index2 == this.detailLib)
          num1 = index2 + 1;
      }
      ListClass optionsList6Obj = this.OptionsList6Obj;
      int tlistselect1 = num1;
      GameClass game1 = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font1 = (Font) null;
      ref Font local2 = ref font1;
      SubPartClass tsubpart3 = (SubPartClass) new ListSubPartClass(optionsList6Obj, 17, 190, tlistselect1, game1, true, "Libraries", tbackbitmap: (ref local1), bbx: 10, bby: 230, overruleFont: (ref local2));
      this.OptionsList6Id = this.AddSubPart(ref tsubpart3, 10, 230, 190, 320, 0);
      this.OptionsList5Obj = new ListClass();
      this.OptionsList5Obj.add("All Events", -1);
      int num2 = 0;
      int num3 = 0;
      int tdata = 0;
      do
      {
        if (Strings.Len(this.game.Data.TempString[800 + tdata]) > 1)
        {
          ++num3;
          str1 = this.game.Data.TempString[800 + tdata];
          if (tdata == this.cat)
            num2 = num3;
          this.OptionsList5Obj.add(str1, tdata);
        }
        ++tdata;
      }
      while (tdata <= 99);
      ListClass optionsList5Obj = this.OptionsList5Obj;
      int tlistselect2 = num2;
      GameClass game2 = this.game;
      ref Bitmap local3 = ref this.OwnBitmap;
      Font font2 = (Font) null;
      ref Font local4 = ref font2;
      SubPartClass tsubpart4 = (SubPartClass) new ListSubPartClass(optionsList5Obj, 7, 190, tlistselect2, game2, true, "Event Categories", tbackbitmap: (ref local3), bbx: 10, bby: 20, overruleFont: (ref local4));
      this.OptionsList5Id = this.AddSubPart(ref tsubpart4, 10, 20, 190, 160, 0);
      this.OptionsListObj = new ListClass();
      int num4 = -1;
      int num5 = -1;
      if (this.game.Data.EventCounter > -1)
      {
        int eventCounter = this.game.Data.EventCounter;
        for (int index3 = 0; index3 <= eventCounter; ++index3)
        {
          if ((this.cat == -1 | this.game.Data.EventObj[index3].Category == this.cat) & (this.detailLib == -1 | this.game.Data.EventObj[index3].LibId.libSlot == this.detailLib))
          {
            ++num4;
            if (index3 == this.detail1)
              num5 = num4;
            string str2 = "slot" + Strings.Trim(Conversion.Str((object) index3)) + ") " + this.game.Data.EventObj[index3].Name + "<id" + this.game.Data.EventObj[index3].Id.ToString() + ">";
            if (Strings.Len(str2) > 60)
              str2 = Strings.Left(str2, 60);
            string str3 = str2 + Strings.Space(65 - Strings.Len(str2));
            if (this.game.Data.EventObj[index3].CheckMode == 0)
              str3 += "No Check";
            else if (this.game.Data.EventObj[index3].CheckMode == 1)
              str3 += "Round Check";
            else if (this.game.Data.EventObj[index3].CheckMode == 2)
              str3 += "Early Turn (no unter)";
            else if (this.game.Data.EventObj[index3].CheckMode == 3)
              str3 += "Late Turn Check";
            else if (this.game.Data.EventObj[index3].CheckMode == 4)
              str3 += "Late Open Turn Check";
            else if (this.game.Data.EventObj[index3].CheckMode == 5)
              str3 += "Close Turn Check";
            else if (this.game.Data.EventObj[index3].CheckMode == 6)
              str3 += "After AI Init Check";
            else if (this.game.Data.EventObj[index3].CheckMode == 7)
              str3 += "Game Startup Always";
            else if (this.game.Data.EventObj[index3].CheckMode == 8)
              str3 += "Early Open Turn Check (depr)";
            else if (this.game.Data.EventObj[index3].CheckMode == 9)
              str3 += "Load Game Early (by button)";
            else if (this.game.Data.EventObj[index3].CheckMode == 10)
              str3 += "Load Game Late";
            else if (this.game.Data.EventObj[index3].CheckMode == 11)
              str3 += "Mid Turn Check (no unter)";
            else if (this.game.Data.EventObj[index3].CheckMode == 12)
              str3 += "Early Cinematics Check";
            if (this.game.Data.EventObj[index3].Priority != 0)
              str3 = str3 + ", prio=" + this.game.Data.EventObj[index3].Priority.ToString();
            if (Strings.Len(str3) > 102)
              str3 = Strings.Left(str3, 102);
            string str4 = str3 + Strings.Space(105 - Strings.Len(str3));
            if (this.game.Data.EventObj[index3].Category > -1)
              str4 += this.game.Data.TempString[800 + this.game.Data.EventObj[index3].Category];
            if (Strings.Len(str4) > 132)
              str4 = Strings.Left(str4, 132);
            str1 = str4 + Strings.Space(135 - Strings.Len(str4));
            if (this.game.Data.EventObj[index3].LibId.libSlot > -1)
              str1 = str1 + this.game.Data.LibraryObj[this.game.Data.EventObj[index3].LibId.libSlot].name + " <libId" + this.game.Data.EventObj[index3].LibId.id.ToString() + ">";
            if (Strings.Len(str1) > 160)
              str1 = Strings.Left(str1, 160);
            this.OptionsListObj.add(str1, index3);
          }
        }
      }
      if (this.game.Data.EventCounter < this.detail1)
        this.detail1 = -1;
      int w1 = this.game.ScreenWidth - 400;
      ListClass optionsListObj = this.OptionsListObj;
      int twidth1 = w1;
      int tlistselect3 = num5;
      GameClass game3 = this.game;
      ref Bitmap local5 = ref this.OwnBitmap;
      Font font3 = (Font) null;
      ref Font local6 = ref font3;
      SubPartClass tsubpart5 = (SubPartClass) new ListSubPartClass(optionsListObj, 7, twidth1, tlistselect3, game3, true, "Events", tbackbitmap: (ref local5), bbx: 210, bby: 20, overruleFont: (ref local6));
      this.OptionsListId = this.AddSubPart(ref tsubpart5, 210, 20, w1, 160, 0);
      this.ss = "Click to add a new event to the eventlist";
      SubPartClass tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.AddEventId = this.AddSubPart(ref tsubpart6, 250 + w1, 20, 32, 16, 1);
      if (this.detail1 > -1)
      {
        this.ss = "Click to move this event up in the list";
        SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONUP, tDescript: this.ss);
        this.EventUpId = this.AddSubPart(ref tsubpart7, 250 + w1, 40, 32, 16, 1);
        this.ss = "Click to move this event down in the list";
        SubPartClass tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONDOWN, tDescript: this.ss);
        this.EventDownId = this.AddSubPart(ref tsubpart8, 250 + w1, 60, 32, 16, 1);
        this.ss = "Click to make a copy of this event in memory";
        SubPartClass tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONCOPY, tDescript: this.ss);
        this.EventCopy = this.AddSubPart(ref tsubpart9, 250 + w1, 80, 32, 16, 1);
        this.ss = "Click to add the event below the selected event";
        SubPartClass tsubpart10 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPASTE, tDescript: this.ss);
        this.EventPaste = this.AddSubPart(ref tsubpart10, 250 + w1, 100, 32, 16, 1);
        this.ss = "Click to set category";
        SubPartClass tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.setCat = this.AddSubPart(ref tsubpart11, 250 + w1, 120, 32, 16, 1);
        this.ss = "Click to set library";
        SubPartClass tsubpart12 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.setLib = this.AddSubPart(ref tsubpart12, 320 + w1, 120, 32, 16, 1);
        this.ss = "Replace Options ; Do not forget to make a backup first. ";
        SubPartClass tsubpart13 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
        this.replaceId = this.AddSubPart(ref tsubpart13, 320 + w1, 140, 32, 16, 1);
        this.ss = "Click to export all events to textfiles in log directory";
        SubPartClass tsubpart14 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
        this.Export = this.AddSubPart(ref tsubpart14, 320 + w1, 20, 32, 16, 1);
      }
      this.ss = "Click to import a specific (you must know slot number) event from another file";
      SubPartClass tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.Import1 = this.AddSubPart(ref tsubpart15, 320 + w1, 40, 32, 16, 1);
      this.ss = "Click to import ALL or a specific category of events from another file";
      SubPartClass tsubpart16 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLUE, tDescript: this.ss);
      this.Import2 = this.AddSubPart(ref tsubpart16, 320 + w1, 60, 32, 16, 1);
      this.ss = "Click to execute this event right now...";
      SubPartClass tsubpart17 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.ExecNow = this.AddSubPart(ref tsubpart17, 320 + w1, 90, 32, 16, 1);
      int y;
      SubPartClass tsubpart18;
      if (this.detail1 > -1)
      {
        this.ss = "Click to remove this event from the list";
        SubPartClass tsubpart19 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.RemoveEventId = this.AddSubPart(ref tsubpart19, 250 + w1, 140, 32, 16, 1);
        int w2 = this.game.ScreenWidth - 260;
        y = this.game.ScreenHeight - 420;
        this.ss = "Click to give this event a new name";
        SubPartClass tsubpart20 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.info3id = this.AddSubPart(ref tsubpart20, 10, 202, 32, 16, 1);
        tsubpart18 = (SubPartClass) new TextPartClass("Event: " + this.game.Data.EventObj[this.detail1].Name, new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.info3textid = this.AddSubPart(ref tsubpart18, 50, 202, 200, 20, 0);
        this.OptionsList2Obj = new ListClass();
        int num6 = 0;
        if (this.game.Data.EventObj[this.detail1].CommandCounter > -1)
        {
          int commandCounter = this.game.Data.EventObj[this.detail1].CommandCounter;
          for (int index4 = 0; index4 <= commandCounter; ++index4)
          {
            string str5 = this.COMMANDTYPE[this.game.Data.EventObj[this.detail1].CommandList[index4].type];
            if (this.game.Data.EventObj[this.detail1].CommandList[index4].type == 2)
            {
              --num6;
              if (0 > num6)
                num6 = 0;
            }
            if (this.game.Data.EventObj[this.detail1].CommandList[index4].type == 6)
            {
              --num6;
              if (0 > num6)
                num6 = 0;
            }
            if (this.game.Data.EventObj[this.detail1].CommandList[index4].type == 1)
              str5 = str5 + ": " + this.ItemInfo(this.detail1, index4, 0) + " " + this.ItemInfo(this.detail1, index4, 1) + " " + this.ItemInfo(this.detail1, index4, 2);
            if (this.game.Data.EventObj[this.detail1].CommandList[index4].type == 3)
              str5 = str5 + ": " + this.ItemInfo(this.detail1, index4, 0);
            if (this.game.Data.EventObj[this.detail1].CommandList[index4].type == 7)
              str5 = "' " + this.game.Data.EventObj[this.detail1].CommandList[index4].DataString;
            if (this.game.Data.EventObj[this.detail1].CommandList[index4].type == 4)
              str5 = str5 + ": " + this.ItemInfo(this.detail1, index4, 0) + " " + this.ItemInfo(this.detail1, index4, 1) + " " + this.ItemInfo(this.detail1, index4, 2);
            if (this.game.Data.EventObj[this.detail1].CommandList[index4].type == 5)
              str5 = str5 + ": " + this.ItemInfo(this.detail1, index4, 0) + " " + this.ItemInfo(this.detail1, index4, 1) + " " + this.ItemInfo(this.detail1, index4, 2);
            str1 = Strings.Trim(Conversion.Str((object) index4)) + ") " + Strings.Space(4 - Strings.Len(Strings.Trim(Conversion.Str((object) index4)))) + Strings.Space(num6 * 2) + str5;
            if (this.game.Data.EventObj[this.detail1].CommandList[index4].type == 7)
              this.OptionsList2Obj.add(str1, index4, tcol: 1);
            else
              this.OptionsList2Obj.add(str1, index4);
            if (this.game.Data.EventObj[this.detail1].CommandList[index4].type == 1)
              ++num6;
            if (this.game.Data.EventObj[this.detail1].CommandList[index4].type == 5)
              ++num6;
          }
        }
        if (this.game.Data.EventObj[this.detail1].CommandCounter < this.detail2)
          this.detail2 = -1;
        ListClass optionsList2Obj = this.OptionsList2Obj;
        int tlistsize = (int) Math.Round(Conversion.Int((double) y / 16.0) - 1.0);
        int twidth2 = w2;
        int detail2 = this.detail2;
        GameClass game4 = this.game;
        ref Bitmap local7 = ref this.OwnBitmap;
        Font font4 = (Font) null;
        ref Font local8 = ref font4;
        tsubpart18 = (SubPartClass) new ListSubPartClass(optionsList2Obj, tlistsize, twidth2, detail2, game4, true, "Code", tbackbitmap: (ref local7), bbx: 210, bby: 220, overruleFont: (ref local8));
        this.OptionsList2Id = this.AddSubPart(ref tsubpart18, 210, 220, w2, (int) Math.Round((Conversion.Int((double) y / 16.0) + 2.0) * 16.0), 0);
        this.ss = "Click to add a line of code to the selected event; will be placed below selected line";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.AddCommandId = this.AddSubPart(ref tsubpart18, 300, 202, 32, 16, 1);
      }
      else
      {
        this.detail2 = -1;
        this.detail3 = -1;
        this.detail4 = -1;
      }
      if (this.detail2 > -1)
      {
        this.ss = "Click to remove this line of code";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.RemoveCommandId = this.AddSubPart(ref tsubpart18, 550, 202, 32, 16, 1);
        this.ss = "Click to move this line of code up one line";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONUP, tDescript: this.ss);
        this.CommandUpId = this.AddSubPart(ref tsubpart18, 400, 202, 32, 16, 1);
        this.ss = "Click to move this line of code down one line";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONDOWN, tDescript: this.ss);
        this.CommandDownId = this.AddSubPart(ref tsubpart18, 435, 202, 32, 16, 1);
        this.ss = "Click to copy this line into memory";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONCOPY, tDescript: this.ss);
        this.CommandCopy = this.AddSubPart(ref tsubpart18, 470, 202, 32, 16, 1);
        this.ss = "Click to paste the line in memory below the selected line";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPASTE, tDescript: this.ss);
        this.CommandPaste = this.AddSubPart(ref tsubpart18, 505, 202, 32, 16, 1);
        this.ss = "Sort of command that is on the selected line";
        if (this.game.Data.EventObj[this.detail1].CheckMode == 0)
          str1 = "No Check";
        else if (this.game.Data.EventObj[this.detail1].CheckMode == 1)
          str1 = "Round Check";
        else if (this.game.Data.EventObj[this.detail1].CheckMode == 2)
          str1 = "Early Start Turn (no unter)";
        else if (this.game.Data.EventObj[this.detail1].CheckMode == 3)
          str1 = "Late Start Turn Check";
        else if (this.game.Data.EventObj[this.detail1].CheckMode == 4)
          str1 = "Late Open Turn Check";
        else if (this.game.Data.EventObj[this.detail1].CheckMode == 5)
          str1 = "Close Turn Check";
        else if (this.game.Data.EventObj[this.detail1].CheckMode == 6)
          str1 = "After AI Init Check";
        else if (this.game.Data.EventObj[this.detail1].CheckMode == 7)
          str1 = "Game Startup Always";
        else if (this.game.Data.EventObj[this.detail1].CheckMode == 8)
          str1 = "Early Open Turn Check (depreciated)";
        else if (this.game.Data.EventObj[this.detail1].CheckMode == 9)
          str1 = "Load Game Early (by button)";
        else if (this.game.Data.EventObj[this.detail1].CheckMode == 10)
          str1 = "Load Game Late";
        else if (this.game.Data.EventObj[this.detail1].CheckMode == 11)
          str1 = "Mid Turn (no unter)";
        else if (this.game.Data.EventObj[this.detail1].CheckMode == 12)
          str1 = "Early Cinematics Check";
        this.ss = "Click to change if the event should be round or turn checked or never at all";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.TypMode = this.AddSubPart(ref tsubpart18, 610, 202, 32, 16, 1);
        tsubpart18 = (SubPartClass) new TextPartClass(str1, new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 150, 16, false, tDescript: this.ss);
        this.TypModeB = this.AddSubPart(ref tsubpart18, 650, 202, 150, 16, 0);
        this.ss = "Click to insert a specified number of lines from a specified event below this position.";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPASTE, tDescript: this.ss);
        this.InsertId = this.AddSubPart(ref tsubpart18, 850, 202, 32, 16, 1);
        this.ss = "Is event executable in editor?";
        if (this.game.Data.EventObj[this.detail1].AllowExecute)
        {
          tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONFLAGGED, tDescript: this.ss);
          this.allowExecuteId = this.AddSubPart(ref tsubpart18, 900, 202, 32, 16, 1);
        }
        else
        {
          tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONUNFLAGGED, tDescript: this.ss);
          this.allowExecuteId = this.AddSubPart(ref tsubpart18, 900, 202, 32, 16, 1);
        }
        this.ss = "Set Priority. Default is 0. Higher will be executed before, lower after. Current prio = " + this.game.Data.EventObj[this.detail1].Priority.ToString();
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.setPrio = this.AddSubPart(ref tsubpart18, 950, 202, 32, 16, 1);
        tsubpart18 = (SubPartClass) new TextPartClass("Prio=" + this.game.Data.EventObj[this.detail1].Priority.ToString(), new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 70, 16, false, tDescript: this.ss);
        this.setPrioB = this.AddSubPart(ref tsubpart18, 990, 202, 70, 16, 0);
        y += 270;
        tsubpart18 = (SubPartClass) new TextPartClass("Type: " + this.COMMANDTYPE[this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type], new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.CurTyp = this.AddSubPart(ref tsubpart18, 10, y, 200, 20, 0);
        this.ss = "Click to change the selected line in a CHECK line. CHECK is used to compare one value to another";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.Typ1 = this.AddSubPart(ref tsubpart18, 200, y, 32, 16, 1);
        tsubpart18 = (SubPartClass) new TextPartClass("CHECK", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 50, 16, false, tDescript: this.ss);
        this.Typ1b = this.AddSubPart(ref tsubpart18, 235, y, 50, 16, 0);
        this.ss = "Click to change the selected line in an END CHECK line. END CHECK closes of the code following a CHECK.";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.Typ2 = this.AddSubPart(ref tsubpart18, 285, y, 32, 16, 1);
        tsubpart18 = (SubPartClass) new TextPartClass("END.CH", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 50, 16, false, tDescript: this.ss);
        this.Typ2b = this.AddSubPart(ref tsubpart18, 320, y, 50, 16, 0);
        this.ss = "Click to change the selected line in a EXEC line. EXEC lines are there to execute a specific hardcoded function";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.Typ3 = this.AddSubPart(ref tsubpart18, 370, y, 32, 16, 1);
        tsubpart18 = (SubPartClass) new TextPartClass("EXEC", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 50, 16, false, tDescript: this.ss);
        this.Typ3b = this.AddSubPart(ref tsubpart18, 405, y, 50, 16, 0);
        this.ss = "Click to change the selected line in a SETVAR line. SETVAR is used to set a variable to another value.";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.Typ4 = this.AddSubPart(ref tsubpart18, 455, y, 32, 16, 1);
        tsubpart18 = (SubPartClass) new TextPartClass("SETVAR", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 50, 16, false, tDescript: this.ss);
        this.Typ4b = this.AddSubPart(ref tsubpart18, 490, y, 50, 16, 0);
        this.ss = "Click to change the selected line in a LOOP line";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.Typ5 = this.AddSubPart(ref tsubpart18, 540, y, 32, 16, 1);
        tsubpart18 = (SubPartClass) new TextPartClass("LOOP", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 50, 16, false, tDescript: this.ss);
        this.Typ5b = this.AddSubPart(ref tsubpart18, 575, y, 50, 16, 0);
        this.ss = "Click to change the selected line in a ENDLOOP line. ENDLOOP is used to close of code following a LOOP line";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.Typ6 = this.AddSubPart(ref tsubpart18, 625, y, 32, 16, 1);
        tsubpart18 = (SubPartClass) new TextPartClass("END.LP", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 50, 16, false, tDescript: this.ss);
        this.Typ6b = this.AddSubPart(ref tsubpart18, 660, y, 50, 16, 0);
        this.ss = "Click to change the selected line in a COMMENT line";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.Typ7 = this.AddSubPart(ref tsubpart18, 710, y, 32, 16, 1);
        tsubpart18 = (SubPartClass) new TextPartClass("COMMENT", new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 80, 16, false, tDescript: this.ss);
        this.Typ7b = this.AddSubPart(ref tsubpart18, 745, y, 80, 16, 0);
        if (this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type == 3 | this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type == 7 && this.game.Data.ExecTypeString[Conversions.ToInteger(this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[0, 1])] > 0 | this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type == 7)
        {
          this.ss = "Click to change the text of the datastring. Used by for example: messages exec. Or the comment text.";
          tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.typstr = this.AddSubPart(ref tsubpart18, 10, y + 70, 32, 16, 1);
          tsubpart18 = (SubPartClass) new TextPartClass(this.game.Data.EventObj[this.detail1].CommandList[this.detail2].DataString, new Font("Times New Roman", 10f, FontStyle.Bold, GraphicsUnit.Pixel), 700, 16, false, tDescript: this.ss);
          this.typstrb = this.AddSubPart(ref tsubpart18, 50, y + 70, 700, 16, 0);
        }
      }
      this.detail3 = -1;
      this.detail4 = -1;
      this.detailchoice = -1;
      if (this.detail2 <= -1 || this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type <= 0)
        return;
      int type = this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type;
      this.SetitemName(type);
      if (Strings.Len(this.ITEMNAME[1]) > 0)
      {
        this.ss = "Click to set the first item of this code line";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.Item1 = this.AddSubPart(ref tsubpart18, 10, y + 40, 32, 16, 1);
        tsubpart18 = (SubPartClass) new TextPartClass(this.ITEMNAME[1], new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 16, false, tDescript: this.ss);
        this.Item1b = this.AddSubPart(ref tsubpart18, 50, y + 40, 350, 16, 0);
        if (type == 1 | type == 3)
        {
          int integer1 = Conversions.ToInteger(this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[0, 0]);
          int integer2 = Conversions.ToInteger(this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[0, 1]);
          switch (integer1)
          {
            case 2:
              if (integer2 > 0)
              {
                int num7 = this.game.Data.CheckTypeVarCount[integer2];
                for (int index5 = 1; index5 <= num7; ++index5)
                {
                  this.ss = this.game.Data.CheckTypeVarName[integer2, index5];
                  if (index5 == 1)
                  {
                    tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
                    this.quick1 = this.AddSubPart(ref tsubpart18, 400, y + 40, 32, 16, 1);
                  }
                  if (index5 == 2)
                  {
                    tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
                    this.quick2 = this.AddSubPart(ref tsubpart18, 450, y + 40, 32, 16, 1);
                  }
                  if (index5 == 3)
                  {
                    tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
                    this.quick3 = this.AddSubPart(ref tsubpart18, 500, y + 40, 32, 16, 1);
                  }
                  if (index5 == 4)
                  {
                    tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
                    this.quick4 = this.AddSubPart(ref tsubpart18, 550, y + 40, 32, 16, 1);
                  }
                }
                break;
              }
              break;
            case 4:
              if (integer2 > 0)
              {
                int num8 = this.game.Data.ExecTypeVarCount[integer2];
                for (int index6 = 1; index6 <= num8; ++index6)
                {
                  this.ss = this.game.Data.ExecTypeVarName[integer2, index6];
                  if (index6 == 1)
                  {
                    tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
                    this.quick1 = this.AddSubPart(ref tsubpart18, 400, y + 40, 32, 16, 1);
                  }
                  if (index6 == 2)
                  {
                    tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
                    this.quick2 = this.AddSubPart(ref tsubpart18, 450, y + 40, 32, 16, 1);
                  }
                  if (index6 == 3)
                  {
                    tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
                    this.quick3 = this.AddSubPart(ref tsubpart18, 500, y + 40, 32, 16, 1);
                  }
                  if (index6 == 4)
                  {
                    tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
                    this.quick4 = this.AddSubPart(ref tsubpart18, 550, y + 40, 32, 16, 1);
                  }
                }
                break;
              }
              break;
          }
        }
      }
      if (Strings.Len(this.ITEMNAME[2]) > 0)
      {
        this.ss = "Click to set the second item of this code line";
        tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.Item2 = this.AddSubPart(ref tsubpart18, 10, y + 70, 32, 16, 1);
        tsubpart18 = (SubPartClass) new TextPartClass(this.ITEMNAME[2], new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 650, 16, false, tDescript: this.ss);
        this.Item2b = this.AddSubPart(ref tsubpart18, 50, y + 70, 650, 16, 0);
      }
      if (Strings.Len(this.ITEMNAME[3]) <= 0)
        return;
      this.ss = "Click to set the third item of this code line";
      tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.Item3 = this.AddSubPart(ref tsubpart18, 10, y + 100, 32, 16, 1);
      tsubpart18 = (SubPartClass) new TextPartClass(this.ITEMNAME[3], new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 16, false, tDescript: this.ss);
      this.Item3b = this.AddSubPart(ref tsubpart18, 50, y + 100, 350, 16, 0);
      if (!(type == 1 | type == 4))
        return;
      int integer3 = Conversions.ToInteger(this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[2, 0]);
      int integer4 = Conversions.ToInteger(this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[2, 1]);
      switch (integer3)
      {
        case 2:
          if (integer4 <= 0)
            break;
          int num9 = this.game.Data.CheckTypeVarCount[integer4];
          for (int index7 = 1; index7 <= num9; ++index7)
          {
            this.ss = this.game.Data.CheckTypeVarName[integer4, index7];
            if (index7 == 1)
            {
              tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
              this.quick5 = this.AddSubPart(ref tsubpart18, 400, y + 100, 32, 16, 1);
            }
            if (index7 == 2)
            {
              tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
              this.quick6 = this.AddSubPart(ref tsubpart18, 450, y + 100, 32, 16, 1);
            }
            if (index7 == 3)
            {
              tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
              this.quick7 = this.AddSubPart(ref tsubpart18, 500, y + 100, 32, 16, 1);
            }
            if (index7 == 4)
            {
              tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
              this.quick8 = this.AddSubPart(ref tsubpart18, 550, y + 100, 32, 16, 1);
            }
          }
          break;
        case 4:
          if (integer4 <= 0)
            break;
          int num10 = this.game.Data.ExecTypeVarCount[integer4];
          for (int index8 = 1; index8 <= num10; ++index8)
          {
            this.ss = this.game.Data.ExecTypeVarName[integer4, index8];
            if (index8 == 1)
            {
              tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
              this.quick5 = this.AddSubPart(ref tsubpart18, 400, y + 100, 32, 16, 1);
            }
            if (index8 == 2)
            {
              tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
              this.quick6 = this.AddSubPart(ref tsubpart18, 450, y + 100, 32, 16, 1);
            }
            if (index8 == 3)
            {
              tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
              this.quick7 = this.AddSubPart(ref tsubpart18, 500, y + 100, 32, 16, 1);
            }
            if (index8 == 4)
            {
              tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
              this.quick8 = this.AddSubPart(ref tsubpart18, 550, y + 100, 32, 16, 1);
            }
          }
          break;
      }
    }

    public void TabsheetSlots()
    {
      int type = this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type;
      this.String1 = "";
      this.String2 = "";
      this.String3 = "";
      int num = -1;
      CommandClass command = this.game.Data.EventObj[this.detail1].CommandList[this.detail2];
      if (type == 1)
      {
        if (this.SetSlot == 0 | this.SetSlot == 2)
        {
          if (this.StepCurrent == 0)
          {
            this.String1 = "Check With What?";
            num = 0;
          }
          if (this.StepCurrent == 1)
          {
            if (Conversions.ToDouble(command.Data[this.SetSlot, 0]) == 1.0)
            {
              this.String1 = "Set VarInfo";
              num = 1;
              this.VarExtra = 0;
            }
            if (Conversions.ToDouble(command.Data[this.SetSlot, 0]) == 2.0)
            {
              this.String1 = "Set CheckType";
              num = 2;
            }
          }
          if (this.StepCurrent > 1 & Conversions.ToDouble(command.Data[this.SetSlot, 0]) == 2.0 && this.game.Data.CheckTypeVarCount[Conversions.ToInteger(command.Data[this.SetSlot, 1])] >= this.StepCurrent - 1)
          {
            this.String1 = "Set CheckType Variable " + Conversion.Str((object) (this.StepCurrent - 1)) + ": '" + this.game.Data.CheckTypeVarName[Conversions.ToInteger(command.Data[this.SetSlot, 1]), this.StepCurrent - 1] + "'";
            num = 1;
            this.VarExtra = (this.StepCurrent - 1) * 3;
          }
        }
        if (this.SetSlot == 1 && this.StepCurrent == 0)
        {
          command.Data[this.SetSlot, 0] = Conversions.ToString(3);
          this.String1 = "Set Conditional";
          num = 3;
        }
      }
      if (type == 3)
      {
        if (this.StepCurrent == 0)
        {
          command.Data[this.SetSlot, 0] = Conversions.ToString(4);
          this.String1 = "Set ExecType";
          num = 4;
        }
        if (this.StepCurrent > 0 & Conversions.ToDouble(command.Data[this.SetSlot, 0]) == 4.0)
        {
          if (this.game.Data.ExecTypeVarCount[Conversions.ToInteger(command.Data[this.SetSlot, 1])] >= this.StepCurrent)
          {
            this.String1 = "Set Exec Type Variable " + Conversion.Str((object) this.StepCurrent) + ": '" + this.game.Data.ExecTypeVarName[Conversions.ToInteger(command.Data[this.SetSlot, 1]), this.StepCurrent] + "'";
            num = 1;
            this.VarExtra = this.StepCurrent * 3;
          }
          else if (this.game.Data.ExecTypeVarCount[Conversions.ToInteger(command.Data[this.SetSlot, 1])] + 1 == this.StepCurrent)
          {
            if (this.game.Data.ExecTypeString[Conversions.ToInteger(command.Data[this.SetSlot, 1])] == 1)
            {
              this.String1 = "Set Message";
              num = 6;
            }
            if (this.game.Data.ExecTypeString[Conversions.ToInteger(command.Data[this.SetSlot, 1])] == 2)
              this.game.Data.EventObj[this.detail1].CommandList[this.detail2].DataString = Interaction.InputBox("And give a string (name probably)", "Shadow Empire : Planetary Conquest");
          }
        }
      }
      if (type == 4)
      {
        if (this.SetSlot == 0 && this.StepCurrent == 0)
        {
          this.String1 = "Set VarInfo";
          command.Data[this.SetSlot, 0] = Conversions.ToString(1);
          num = 1;
          this.VarExtra = 0;
        }
        if (this.SetSlot == 2)
        {
          if (this.StepCurrent == 0)
          {
            this.String1 = "Check With What?";
            num = 0;
          }
          if (this.StepCurrent == 1)
          {
            if (Conversions.ToDouble(command.Data[this.SetSlot, 0]) == 1.0)
            {
              this.String1 = "Set VarInfo";
              num = 1;
              this.VarExtra = 0;
            }
            if (Conversions.ToDouble(command.Data[this.SetSlot, 0]) == 2.0)
            {
              this.String1 = "Set CheckType";
              num = 2;
            }
          }
          if (this.StepCurrent > 1 & Conversions.ToDouble(command.Data[this.SetSlot, 0]) == 2.0 && this.game.Data.CheckTypeVarCount[Conversions.ToInteger(command.Data[this.SetSlot, 1])] >= this.StepCurrent - 1)
          {
            this.String1 = "Set CheckType Variable " + Conversion.Str((object) (this.StepCurrent - 1)) + ": '" + this.game.Data.CheckTypeVarName[Conversions.ToInteger(command.Data[this.SetSlot, 1]), this.StepCurrent - 1] + "'";
            num = 1;
            this.VarExtra = (this.StepCurrent - 1) * 3;
          }
        }
        if (this.SetSlot == 1 && this.StepCurrent == 0)
        {
          command.Data[this.SetSlot, 0] = Conversions.ToString(5);
          this.String1 = "Set SetType";
          num = 5;
        }
      }
      if (type == 5 && this.SetSlot == 1 | this.SetSlot == 2)
      {
        if (this.StepCurrent == 0)
        {
          this.String1 = "Use what Sort of Number?";
          num = 0;
        }
        if (this.StepCurrent == 1)
        {
          if (Conversions.ToDouble(command.Data[this.SetSlot, 0]) == 1.0)
          {
            this.String1 = "Set VarInfo";
            num = 1;
            this.VarExtra = 0;
          }
          if (Conversions.ToDouble(command.Data[this.SetSlot, 0]) == 2.0)
          {
            this.String1 = "Set CheckType";
            num = 2;
          }
        }
        if (this.StepCurrent > 1 & Conversions.ToDouble(command.Data[this.SetSlot, 0]) == 2.0 && this.game.Data.CheckTypeVarCount[Conversions.ToInteger(command.Data[this.SetSlot, 1])] >= this.StepCurrent - 1)
        {
          this.String1 = "Set CheckType Variable " + Conversion.Str((object) (this.StepCurrent - 1)) + ": '" + this.game.Data.CheckTypeVarName[Conversions.ToInteger(command.Data[this.SetSlot, 1]), this.StepCurrent - 1] + "'";
          num = 1;
          this.VarExtra = (this.StepCurrent - 1) * 3;
        }
      }
      if (num == -1)
      {
        this.DoingSlots = false;
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass(this.String1, new Font("Times New Roman", 16f, FontStyle.Bold, GraphicsUnit.Pixel), 650, 20, false);
        this.Info1textId = this.AddSubPart(ref tsubpart, 12, 10, 650, 20, 0);
        if (num == 0)
          this.TabSheetNr0();
        if (num == 1)
          this.TabSheetNr1();
        if (num == 2)
          this.TabSheetNr2();
        if (num == 3)
          this.TabSheetNr3();
        if (num == 4)
          this.TabSheetNr4();
        if (num == 5)
          this.TabSheetNr5();
        if (num != 6)
          return;
        this.TabSheetNr6();
      }
    }

    public void TabSheetNr0()
    {
      this.ss = "Click to get a value from a hardcoded function";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.Tab2 = this.AddSubPart(ref tsubpart1, 10, 160, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("CheckType", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.Tab2b = this.AddSubPart(ref tsubpart2, 50, 160, 350, 20, 0);
      this.ss = "Click to select a temporary value. These are only remembered within this specific event. ";
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.Tab6 = this.AddSubPart(ref tsubpart3, 10, 180, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("TempVar", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.Tab6b = this.AddSubPart(ref tsubpart4, 50, 180, 350, 20, 0);
      this.ss = "Click to select a regimevar value";
      SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.Tab7 = this.AddSubPart(ref tsubpart5, 10, 200, 32, 16, 1);
      SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("RegimeVar", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.Tab7b = this.AddSubPart(ref tsubpart6, 50, 200, 350, 20, 0);
      this.ss = "Click to select the value of a gamevar";
      SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.Tab8 = this.AddSubPart(ref tsubpart7, 10, 220, 32, 16, 1);
      SubPartClass tsubpart8 = (SubPartClass) new TextPartClass("GameVar", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.Tab8b = this.AddSubPart(ref tsubpart8, 50, 220, 350, 20, 0);
      this.ss = "Click to give a real number.";
      SubPartClass tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.Tab9 = this.AddSubPart(ref tsubpart9, 10, 240, 32, 16, 1);
      SubPartClass tsubpart10 = (SubPartClass) new TextPartClass("Real Number", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.Tab9b = this.AddSubPart(ref tsubpart10, 50, 240, 350, 20, 0);
      this.ss = "Click to give a Historical Unit ID.";
      SubPartClass tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.NTab1 = this.AddSubPart(ref tsubpart11, 10, 260, 32, 16, 1);
      SubPartClass tsubpart12 = (SubPartClass) new TextPartClass("Historical Unit ID", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.NTab1b = this.AddSubPart(ref tsubpart12, 50, 260, 350, 20, 0);
      this.ss = "Click to give a Defined Area ID.";
      SubPartClass tsubpart13 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.NTab2 = this.AddSubPart(ref tsubpart13, 10, 280, 32, 16, 1);
      SubPartClass tsubpart14 = (SubPartClass) new TextPartClass("Area ID", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.NTab2b = this.AddSubPart(ref tsubpart14, 50, 280, 350, 20, 0);
      this.ss = "Clieck to select a temporary string. These are only remembered within this specific event.";
      SubPartClass tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.Tab10 = this.AddSubPart(ref tsubpart15, 10, 300, 32, 16, 1);
      SubPartClass tsubpart16 = (SubPartClass) new TextPartClass("TempString", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.Tab10b = this.AddSubPart(ref tsubpart16, 50, 300, 300, 20, 0);
      this.ss = "Click to give a real string.";
      SubPartClass tsubpart17 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.tab19 = this.AddSubPart(ref tsubpart17, 10, 320, 32, 16, 1);
      SubPartClass tsubpart18 = (SubPartClass) new TextPartClass("Real String", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.tab19b = this.AddSubPart(ref tsubpart18, 50, 320, 300, 20, 0);
      this.ss = "Cancel this";
      SubPartClass tsubpart19 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
      this.tabx1 = this.AddSubPart(ref tsubpart19, 10, 390, 32, 16, 1);
    }

    public void TabSheetNr1()
    {
      this.ss = "Click to select a temporary value. These are only remembered within this specific event. ";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.Tab6b = this.AddSubPart(ref tsubpart1, 10, 190, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("TempVar", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.tab16b = this.AddSubPart(ref tsubpart2, 50, 190, 350, 20, 0);
      this.ss = "Click to select a regimevar value";
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.Tab7b = this.AddSubPart(ref tsubpart3, 10, 210, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("RegimeVar", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.tab17b = this.AddSubPart(ref tsubpart4, 50, 210, 350, 20, 0);
      this.ss = "Click to select the value of a gamevar";
      SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.Tab8b = this.AddSubPart(ref tsubpart5, 10, 230, 32, 16, 1);
      SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("GameVar", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.tab18b = this.AddSubPart(ref tsubpart6, 50, 230, 350, 20, 0);
      this.ss = "Click to give a real number.";
      SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.Tab9b = this.AddSubPart(ref tsubpart7, 10, 250, 32, 16, 1);
      SubPartClass tsubpart8 = (SubPartClass) new TextPartClass("Real Number", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.tab15b = this.AddSubPart(ref tsubpart8, 50, 250, 350, 20, 0);
      this.ss = "Click to give a Historical Unit ID.";
      SubPartClass tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.ntab1x = this.AddSubPart(ref tsubpart9, 10, 270, 32, 16, 1);
      SubPartClass tsubpart10 = (SubPartClass) new TextPartClass("Historical Unit ID", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.NTab1b = this.AddSubPart(ref tsubpart10, 50, 270, 350, 20, 0);
      this.ss = "Click to give a Defined Area ID.";
      SubPartClass tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.ntab2x = this.AddSubPart(ref tsubpart11, 10, 290, 32, 16, 1);
      SubPartClass tsubpart12 = (SubPartClass) new TextPartClass("Area ID", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.NTab2b = this.AddSubPart(ref tsubpart12, 50, 290, 350, 20, 0);
      this.ss = "Clieck to select a temporary string. These are only remembered within this specific event.";
      SubPartClass tsubpart13 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.Tab10b = this.AddSubPart(ref tsubpart13, 10, 310, 32, 16, 1);
      SubPartClass tsubpart14 = (SubPartClass) new TextPartClass("TempString", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.Tab6 = this.AddSubPart(ref tsubpart14, 50, 310, 300, 20, 0);
      this.ss = "Click to give a real string.";
      SubPartClass tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.tab19b = this.AddSubPart(ref tsubpart15, 10, 330, 32, 16, 1);
      SubPartClass tsubpart16 = (SubPartClass) new TextPartClass("Real String", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false, tDescript: this.ss);
      this.Tab8 = this.AddSubPart(ref tsubpart16, 50, 330, 300, 20, 0);
      if (this.detailchoice == 5)
      {
        this.OptionsList3Obj = new ListClass();
        int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
        for (int tdata = 0; tdata <= historicalUnitCounter; ++tdata)
          this.OptionsList3Obj.add(Conversion.Str((object) this.game.Data.HistoricalUnitObj[tdata].ID) + ") " + this.game.Data.HistoricalUnitObj[tdata].Name, tdata);
        if (this.game.Data.HistoricalUnitCounter < this.detail3)
          this.detail3 = -1;
        if (this.OptionsList3Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, this.detail3);
          this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
        }
        else
        {
          ListClass optionsList3Obj = this.OptionsList3Obj;
          int tlistsize = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - 500) / 16.0) - 3.0);
          int detail3 = this.detail3;
          GameClass game = this.game;
          ref Bitmap local1 = ref this.OwnBitmap;
          Font font = (Font) null;
          ref Font local2 = ref font;
          SubPartClass tsubpart17 = (SubPartClass) new ListSubPartClass(optionsList3Obj, tlistsize, 490, detail3, game, true, "Historical Units", tbackbitmap: (ref local1), bbx: 10, bby: 250, overruleFont: (ref local2));
          this.OptionsList3Id = this.AddSubPart(ref tsubpart17, 10, 450, 490, Conversion.Int(this.game.ScreenHeight - 500), 0);
        }
        if (this.detail3 > -1)
        {
          SubPartClass tsubpart18 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
          this.Tab5 = this.AddSubPart(ref tsubpart18, 610, 650, 32, 16, 1);
          SubPartClass tsubpart19 = (SubPartClass) new TextPartClass("Ok. Select this one!", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false);
          this.Tab5b = this.AddSubPart(ref tsubpart19, 650, 650, 350, 20, 0);
        }
      }
      if (this.detailchoice == 6)
      {
        this.OptionsList3Obj = new ListClass();
        int areaCounter = this.game.Data.AreaCounter;
        for (int tdata = 0; tdata <= areaCounter; ++tdata)
          this.OptionsList3Obj.add(Conversion.Str((object) this.game.Data.AreaObj[tdata].ID) + ") " + this.game.Data.AreaObj[tdata].Name + " (" + Conversion.Str((object) this.game.Data.AreaObj[tdata].Slot) + "," + Conversion.Str((object) this.game.Data.AreaObj[tdata].Code) + ")", tdata);
        if (this.game.Data.AreaCounter < this.detail3)
          this.detail3 = -1;
        if (this.OptionsList3Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, this.detail3);
          this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
        }
        else
        {
          ListClass optionsList3Obj = this.OptionsList3Obj;
          int tlistsize = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - 500) / 16.0) - 3.0);
          int detail3 = this.detail3;
          GameClass game = this.game;
          ref Bitmap local3 = ref this.OwnBitmap;
          Font font = (Font) null;
          ref Font local4 = ref font;
          SubPartClass tsubpart20 = (SubPartClass) new ListSubPartClass(optionsList3Obj, tlistsize, 490, detail3, game, true, "Areas", tbackbitmap: (ref local3), bbx: 10, bby: 250, overruleFont: (ref local4));
          this.OptionsList3Id = this.AddSubPart(ref tsubpart20, 10, 450, 490, Conversion.Int(this.game.ScreenHeight - 500), 0);
        }
        if (this.detail3 > -1)
        {
          SubPartClass tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
          this.Tab5 = this.AddSubPart(ref tsubpart21, 610, 650, 32, 16, 1);
          SubPartClass tsubpart22 = (SubPartClass) new TextPartClass("Ok. Select this one!", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false);
          this.Tab5b = this.AddSubPart(ref tsubpart22, 650, 650, 350, 20, 0);
        }
      }
      if (this.detailchoice == 3)
      {
        this.OptionsList3Obj = new ListClass();
        int index = 0;
        do
        {
          this.OptionsList3Obj.add(Conversion.Str((object) index) + ") " + this.game.Data.GameSlotName[index], index);
          ++index;
        }
        while (index <= 499);
        if (499 < this.detail3)
          this.detail3 = -1;
        if (this.OptionsList3Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, this.detail3);
          this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
        }
        else
        {
          ListClass optionsList3Obj = this.OptionsList3Obj;
          int tlistsize = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - 500) / 16.0) - 3.0);
          int detail3 = this.detail3;
          GameClass game = this.game;
          ref Bitmap local5 = ref this.OwnBitmap;
          Font font = (Font) null;
          ref Font local6 = ref font;
          SubPartClass tsubpart23 = (SubPartClass) new ListSubPartClass(optionsList3Obj, tlistsize, 490, detail3, game, true, "Game Variables", tbackbitmap: (ref local5), bbx: 10, bby: 250, overruleFont: (ref local6));
          this.OptionsList3Id = this.AddSubPart(ref tsubpart23, 10, 450, 490, (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - 500) / 16.0) * 16.0), 0);
        }
        if (this.detail3 > -1)
        {
          SubPartClass tsubpart24 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
          this.Tab5 = this.AddSubPart(ref tsubpart24, 610, 650, 32, 16, 1);
          SubPartClass tsubpart25 = (SubPartClass) new TextPartClass("Ok. Select this one!", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false);
          this.Tab5b = this.AddSubPart(ref tsubpart25, 650, 650, 350, 20, 0);
        }
      }
      if (this.detailchoice != 2)
        return;
      this.OptionsList4Obj = new ListClass();
      if (this.game.Data.RegimeCounter > -1)
      {
        int regimeCounter = this.game.Data.RegimeCounter;
        for (int index = 0; index <= regimeCounter; ++index)
          this.OptionsList4Obj.add(Conversion.Str((object) index) + ") " + this.game.Data.RegimeObj[index].Name, index);
      }
      if (this.game.Data.RegimeCounter < this.detail4)
        this.detail4 = -1;
      ListClass optionsList4Obj = this.OptionsList4Obj;
      int tlistsize1 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - 650) / 16.0) - 3.0);
      int detail4 = this.detail4;
      GameClass game1 = this.game;
      ref Bitmap local7 = ref this.OwnBitmap;
      Font font1 = (Font) null;
      ref Font local8 = ref font1;
      SubPartClass tsubpart26 = (SubPartClass) new ListSubPartClass(optionsList4Obj, tlistsize1, 290, detail4, game1, true, "Regimes", tbackbitmap: (ref local7), bbx: 10, bby: 600, overruleFont: (ref local8));
      this.OptionsList4Id = this.AddSubPart(ref tsubpart26, 10, 600, 290, (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - 650) / 16.0) * 16.0), 0);
      if (this.detail4 <= -1)
        return;
      this.OptionsList3Obj = new ListClass();
      int index1 = 0;
      do
      {
        this.OptionsList3Obj.add(Conversion.Str((object) index1) + ") " + this.game.Data.RegimeSlotName[index1], index1);
        ++index1;
      }
      while (index1 <= 499);
      if (499 < this.detail3)
        this.detail3 = -1;
      if (this.OptionsList3Id > 0)
      {
        this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, this.detail3);
        this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
      }
      else
      {
        ListClass optionsList3Obj = this.OptionsList3Obj;
        int detail3 = this.detail3;
        GameClass game2 = this.game;
        ref Bitmap local9 = ref this.OwnBitmap;
        Font font2 = (Font) null;
        ref Font local10 = ref font2;
        SubPartClass tsubpart27 = (SubPartClass) new ListSubPartClass(optionsList3Obj, 33, 490, detail3, game2, true, "Regime Variables", tbackbitmap: (ref local9), bbx: 10, bby: 250, overruleFont: (ref local10));
        this.OptionsList3Id = this.AddSubPart(ref tsubpart27, 510, 10, 490, 480, 0);
      }
      if (this.detail3 <= -1)
        return;
      SubPartClass tsubpart28 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.Tab5 = this.AddSubPart(ref tsubpart28, 320, 650, 32, 16, 1);
      SubPartClass tsubpart29 = (SubPartClass) new TextPartClass("Ok. Select this one!", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 650, false);
      this.Tab5b = this.AddSubPart(ref tsubpart29, 350, 650, 350, 20, 0);
    }

    public void TabSheetNr2()
    {
      this.GroupListObj = new ListClass();
      if (Operators.ConditionalCompareObjectLess(this.groupdetail, (object) 1, false))
        this.groupdetail = (object) 1;
      int tdata1 = 1;
      do
      {
        this.GroupListObj.add(this.game.Data.CheckCategoryName[tdata1], tdata1);
        ++tdata1;
      }
      while (tdata1 <= 12);
      int tlistselect1 = -1;
      if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreater(this.groupdetail, (object) 0, false), Operators.CompareObjectGreaterEqual((object) 12, this.groupdetail, false))))
        tlistselect1 = Conversions.ToInteger(Operators.SubtractObject(this.groupdetail, (object) 1));
      if (this.GroupListId > 0)
      {
        this.SubPartList[this.SubpartNr(this.GroupListId)].Refresh(this.GroupListObj, tlistselect1);
        this.SubPartFlag[this.SubpartNr(this.GroupListId)] = true;
      }
      else
      {
        ListClass groupListObj = this.GroupListObj;
        int tlistselect2 = tlistselect1;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(groupListObj, 24, 290, tlistselect2, game, true, "Check Categories", tbackbitmap: (ref local1), bbx: 10, bby: 50, overruleFont: (ref local2));
        this.GroupListId = this.AddSubPart(ref tsubpart, 10, 50, 290, 432, 0);
      }
      this.OptionsList3Obj = new ListClass();
      int checkTypeCount = this.game.Data.CheckTypeCount;
      for (int tdata2 = 1; tdata2 <= checkTypeCount; ++tdata2)
      {
        if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.CompareObjectEqual((object) this.game.Data.CheckCategory[tdata2], this.groupdetail, false), Operators.CompareObjectEqual((object) this.game.Data.CheckCategory2[tdata2], this.groupdetail, false)), Operators.CompareObjectEqual(this.groupdetail, (object) -1, false))))
          this.OptionsList3Obj.add(this.game.Data.CheckTypeNames[tdata2], tdata2);
      }
      this.OptionsList3Obj.Sort();
      if (this.game.Data.CheckTypeCount < this.detail3)
        this.detail3 = -1;
      int tlistselect3 = -1;
      int listCount = this.OptionsList3Obj.ListCount;
      for (int index = 0; index <= listCount; ++index)
      {
        if (this.detail3 == this.OptionsList3Obj.ListData[index])
          tlistselect3 = index;
      }
      if (this.OptionsList3Id > 0)
      {
        this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, tlistselect3);
        this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
      }
      else
      {
        ListClass optionsList3Obj = this.OptionsList3Obj;
        int tlistselect4 = tlistselect3;
        GameClass game = this.game;
        ref Bitmap local3 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local4 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(optionsList3Obj, 30, 290, tlistselect4, game, true, "Hardcoded check functions", tbackbitmap: (ref local3), bbx: 310, bby: 50, overruleFont: (ref local4));
        this.OptionsList3Id = this.AddSubPart(ref tsubpart, 310, 50, 290, 528, 0);
      }
      if (this.detail3 > -1)
      {
        SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
        this.Tab3 = this.AddSubPart(ref tsubpart1, 710, 50, 32, 16, 1);
        SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Ok. Select this one!", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false);
        this.Tab3b = this.AddSubPart(ref tsubpart2, 650, 150, 350, 20, 0);
      }
      string str = "";
      if (this.detail3 > -1)
      {
        int num = this.game.Data.CheckTypeVarCount[this.detail3];
        for (int Number = 1; Number <= num; ++Number)
          str = str + Conversion.Str((object) Number) + ") " + this.game.Data.CheckTypeVarName[this.detail3, Number] + "\r\n";
        string tText = str + "\r\n" + this.game.Data.CheckDesc[this.detail3];
        if (this.DescriptId > 0)
          this.RemoveSubPart(this.DescriptId);
        SubPartClass tsubpart3 = (SubPartClass) new TextAreaClass(this.game, 290, 15, new Font(this.game.FontCol.Families[1], 13f, FontStyle.Regular, GraphicsUnit.Pixel), "Description", true, tText, Color.White, tbackbitmap: (ref this.OwnBitmap), bbx: 10, bby: 470);
        this.DescriptId = this.AddSubPart(ref tsubpart3, 10, 470, 290, 2528, 0);
        SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
        this.Tab4 = this.AddSubPart(ref tsubpart4, 710, 50, 32, 16, 1);
        SubPartClass tsubpart5 = (SubPartClass) new TextPartClass("Select", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 50, 20, false);
        this.Tab4b = this.AddSubPart(ref tsubpart5, 750, 50, 50, 20, 0);
      }
      else if (this.DescriptId > 0)
        this.RemoveSubPart(this.DescriptId);
      this.ss = "Cancel this";
      SubPartClass tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
      this.tabx2 = this.AddSubPart(ref tsubpart6, 710, 100, 32, 16, 1);
    }

    public void TabSheetNr3()
    {
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.tab11 = this.AddSubPart(ref tsubpart1, 10, 130, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("> IS BIGGER", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false);
      this.tab11b = this.AddSubPart(ref tsubpart2, 50, 130, 350, 20, 0);
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.tab12 = this.AddSubPart(ref tsubpart3, 10, 160, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("< IS SMALLER", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false);
      this.tab12b = this.AddSubPart(ref tsubpart4, 50, 160, 350, 20, 0);
      SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.tab13 = this.AddSubPart(ref tsubpart5, 10, 190, 32, 16, 1);
      SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("== IS EQUAL", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false);
      this.tab13b = this.AddSubPart(ref tsubpart6, 50, 190, 350, 20, 0);
      SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.tab131 = this.AddSubPart(ref tsubpart7, 10, 220, 32, 16, 1);
      SubPartClass tsubpart8 = (SubPartClass) new TextPartClass("=> IS BIGGER OR EQUAL", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false);
      this.tab131b = this.AddSubPart(ref tsubpart8, 50, 220, 350, 20, 0);
      SubPartClass tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.tab132 = this.AddSubPart(ref tsubpart9, 10, 250, 32, 16, 1);
      SubPartClass tsubpart10 = (SubPartClass) new TextPartClass("=< IS SMALLER OR EQUAL", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false);
      this.tab132b = this.AddSubPart(ref tsubpart10, 50, 250, 350, 20, 0);
      SubPartClass tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.tab133 = this.AddSubPart(ref tsubpart11, 10, 280, 32, 16, 1);
      SubPartClass tsubpart12 = (SubPartClass) new TextPartClass("!= IS NOT EQUAL", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false);
      this.tab133b = this.AddSubPart(ref tsubpart12, 50, 280, 350, 20, 0);
    }

    public void TabSheetNr4()
    {
      if (Operators.ConditionalCompareObjectLess(this.groupdetail, (object) 1, false))
        this.groupdetail = (object) 1;
      this.GroupListObj = new ListClass();
      int tdata1 = 1;
      do
      {
        this.GroupListObj.add(this.game.Data.ExecCategoryName[tdata1], tdata1);
        ++tdata1;
      }
      while (tdata1 <= 22);
      int tlistselect1 = -1;
      if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreater(this.groupdetail, (object) 0, false), Operators.CompareObjectGreaterEqual((object) 22, this.groupdetail, false))))
        tlistselect1 = Conversions.ToInteger(Operators.SubtractObject(this.groupdetail, (object) 1));
      if (this.GroupListId > 0)
      {
        this.SubPartList[this.SubpartNr(this.GroupListId)].Refresh(this.GroupListObj, tlistselect1);
        this.SubPartFlag[this.SubpartNr(this.GroupListId)] = true;
      }
      else
      {
        ListClass groupListObj = this.GroupListObj;
        int tlistselect2 = tlistselect1;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(groupListObj, 26, 290, tlistselect2, game, true, "Exec Categories", tbackbitmap: (ref local1), bbx: 10, bby: 50, overruleFont: (ref local2));
        this.GroupListId = this.AddSubPart(ref tsubpart, 10, 50, 290, 464, 0);
      }
      this.OptionsList3Obj = new ListClass();
      int execTypeCount = this.game.Data.ExecTypeCount;
      for (int tdata2 = 1; tdata2 <= execTypeCount; ++tdata2)
      {
        if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.CompareObjectEqual((object) this.game.Data.ExecCategory[tdata2], this.groupdetail, false), Operators.CompareObjectEqual((object) this.game.Data.ExecCategory2[tdata2], this.groupdetail, false)), Operators.CompareObjectEqual(this.groupdetail, (object) -1, false))))
          this.OptionsList3Obj.add(this.game.Data.ExecTypeNames[tdata2], tdata2);
      }
      this.OptionsList3Obj.Sort();
      if (this.game.Data.ExecTypeCount < this.detail3)
        this.detail3 = -1;
      int tlistselect3 = -1;
      int listCount = this.OptionsList3Obj.ListCount;
      for (int index = 0; index <= listCount; ++index)
      {
        if (this.detail3 == this.OptionsList3Obj.ListData[index])
          tlistselect3 = index;
      }
      if (this.OptionsList3Id > 0)
      {
        this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, tlistselect3);
        this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
      }
      else
      {
        ListClass optionsList3Obj = this.OptionsList3Obj;
        int tlistselect4 = tlistselect3;
        GameClass game = this.game;
        ref Bitmap local3 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local4 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(optionsList3Obj, 35, 290, tlistselect4, game, true, "Hardcoded exec functions", tbackbitmap: (ref local3), bbx: 310, bby: 50, overruleFont: (ref local4));
        this.OptionsList3Id = this.AddSubPart(ref tsubpart, 310, 50, 290, 608, 0);
      }
      string str = "";
      if (this.detail3 > -1)
      {
        int num = this.game.Data.ExecTypeVarCount[this.detail3];
        for (int Number = 1; Number <= num; ++Number)
          str = str + Conversion.Str((object) Number) + ") " + this.game.Data.ExecTypeVarName[this.detail3, Number] + "\r\n";
        if (this.game.Data.ExecTypeString[this.detail3] == 2)
          str += "+ You can input a string\r\n";
        if (this.game.Data.ExecTypeString[this.detail3] == 1)
          str += "+ You can input a textfield\r\n";
        string tText = str + "\r\n" + this.game.Data.ExecDesc[this.detail3];
        if (this.DescriptId > 0)
          this.RemoveSubPart(this.DescriptId);
        SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass(this.game, 290, 12, new Font(this.game.FontCol.Families[1], 13f, FontStyle.Regular, GraphicsUnit.Pixel), "Description", true, tText, Color.White, tbackbitmap: (ref this.OwnBitmap), bbx: 10, bby: 516);
        this.DescriptId = this.AddSubPart(ref tsubpart1, 10, 516, 290, 224, 0);
        SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
        this.Tab4 = this.AddSubPart(ref tsubpart2, 710, 50, 32, 16, 1);
        SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("Select", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 50, 20, false);
        this.Tab4b = this.AddSubPart(ref tsubpart3, 750, 50, 50, 20, 0);
      }
      else if (this.DescriptId > 0)
        this.RemoveSubPart(this.DescriptId);
      this.ss = "Cancel this";
      SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
      this.tabx1 = this.AddSubPart(ref tsubpart4, 710, 100, 32, 16, 1);
    }

    public void TabSheetNr5()
    {
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.tab14 = this.AddSubPart(ref tsubpart1, 10, 130, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("= SET TO", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false);
      this.tab14b = this.AddSubPart(ref tsubpart2, 50, 130, 350, 20, 0);
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.tab15 = this.AddSubPart(ref tsubpart3, 10, 160, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("+= ADD", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false);
      this.tab15b = this.AddSubPart(ref tsubpart4, 50, 160, 350, 20, 0);
      SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.tab16 = this.AddSubPart(ref tsubpart5, 10, 190, 32, 16, 1);
      SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("-= SUBTRACT", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false);
      this.tab16b = this.AddSubPart(ref tsubpart6, 50, 190, 350, 20, 0);
      SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.tab17 = this.AddSubPart(ref tsubpart7, 10, 220, 32, 16, 1);
      SubPartClass tsubpart8 = (SubPartClass) new TextPartClass("/= DIVIDE", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false);
      this.tab17b = this.AddSubPart(ref tsubpart8, 50, 220, 350, 20, 0);
      SubPartClass tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.tab18 = this.AddSubPart(ref tsubpart9, 10, 250, 32, 16, 1);
      SubPartClass tsubpart10 = (SubPartClass) new TextPartClass("*= MULTIPLY", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 350, 20, false);
      this.tab18b = this.AddSubPart(ref tsubpart10, 50, 250, 350, 20, 0);
    }

    public void TabSheetNr6()
    {
      SubPartClass tsubpart1;
      if (Conversions.ToDouble(this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[0, 1]) == 11.0)
      {
        SubPartClass tsubpart2 = (SubPartClass) new TextAreaClass(this.game, 400, 15, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), "Text", true, this.game.Data.EventObj[this.detail1].CommandList[this.detail2].DataString, Color.White, tbackbitmap: (ref this.OwnBitmap), bbx: 10, bby: 100);
        this.tta = this.AddSubPart(ref tsubpart2, 10, 100, 400, 288, 0);
        SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.OKBALL);
        this.tok2 = this.AddSubPart(ref tsubpart3, 10, 500, 32, 32, 1);
      }
      else
      {
        string str1 = this.game.Data.EventObj[this.detail1].CommandList[this.detail2].DataString;
        int index1 = -1;
        int index2 = 0;
        do
        {
          this.temptext[index2] = "";
          this.tempoption[index2] = 0;
          this.temprefer[index2] = -1;
          ++index2;
        }
        while (index2 <= 19);
        int num1 = 0;
        if (Strings.Len(str1) > 0)
        {
          do
          {
            int Length = Strings.InStr(str1, "#", CompareMethod.Text);
            if (Length > 0)
            {
              string str2 = Strings.Left(str1, Length);
              string str3 = Strings.Left(str2, Strings.Len(str2) - 1);
              ++index1;
              this.temptext[index1] = str3;
              if (Strings.Len(str1) > Length)
                str1 = Strings.Mid(str1, Length + 1);
              else
                num1 = 1;
            }
            else
            {
              if (Strings.Len(str1) > 0)
              {
                ++index1;
                this.temptext[index1] = str1;
              }
              num1 = 1;
            }
          }
          while (num1 == 0);
        }
        int num2 = index1;
        for (int index3 = 0; index3 <= num2; ++index3)
        {
          int num3 = Strings.InStr(this.temptext[index3], "*", CompareMethod.Text);
          string str4 = Strings.Mid(this.temptext[index3], num3 + 1);
          int num4 = Strings.InStr(str4, "@", CompareMethod.Text);
          if (num3 > 0 & num4 > 0)
          {
            string str5 = Strings.Mid(str4, num4 + 1);
            str4 = Strings.Left(str4, Strings.Len(str4) - (1 + Strings.Len(str5)));
            int num5 = (int) Math.Round(Conversion.Val(str5));
            this.temprefer[index3] = num5;
            this.tempoption[index3] = 1;
            int num6;
            ++num6;
          }
          this.temptext[index3] = str4;
        }
        int num7 = index1;
        for (int index4 = 0; index4 <= num7; ++index4)
        {
          int y = 100 + index4 * 25;
          int[] tbutton = this.tbutton;
          int index5 = index4;
          SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
          int num8 = this.AddSubPart(ref tsubpart4, 10, y, 32, 16, 1);
          tbutton[index5] = num8;
          int[] tline = this.tline;
          int index6 = index4;
          tsubpart4 = (SubPartClass) new TextPartClass(this.temptext[index4], new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 650, 20, false);
          int num9 = this.AddSubPart(ref tsubpart4, 50, y, 650, 20, 0);
          tline[index6] = num9;
          if (this.tempoption[index4] == 1)
          {
            int[] toption = this.toption;
            int index7 = index4;
            SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONFLAGGED);
            int num10 = this.AddSubPart(ref tsubpart5, 750, y, 32, 16, 1);
            toption[index7] = num10;
            int[] trefer = this.trefer;
            int index8 = index4;
            SubPartClass tsubpart6 = (SubPartClass) new TextPartClass(Conversion.Str((object) this.temprefer[index4]), new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 200, 20, false);
            int num11 = this.AddSubPart(ref tsubpart6, 790, y, 200, 20, 0);
            trefer[index8] = num11;
          }
          else
          {
            int[] toption = this.toption;
            int index9 = index4;
            SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONUNFLAGGED);
            int num12 = this.AddSubPart(ref tsubpart7, 750, y, 32, 16, 1);
            toption[index9] = num12;
          }
        }
        if (index1 < 19)
        {
          for (int index10 = index1 + 1; index10 <= 19; ++index10)
          {
            int y = 100 + index10 * 25;
            int[] tbutton = this.tbutton;
            int index11 = index10;
            tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
            int num13 = this.AddSubPart(ref tsubpart1, 10, y, 32, 16, 1);
            tbutton[index11] = num13;
          }
        }
      }
      tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.OKBALL);
      this.tok = this.AddSubPart(ref tsubpart1, 10, 700, 32, 32, 1);
      tsubpart1 = (SubPartClass) new TextPartClass("Ok, Alright!", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 200, 20, false);
      this.tab14b = this.AddSubPart(ref tsubpart1, 50, 700, 200, 20, 0);
    }

    public void SetitemName(int typ)
    {
      int index = 1;
      do
      {
        this.ITEMNAME[index] = "";
        ++index;
      }
      while (index <= 5);
      if (typ == 1)
      {
        this.ITEMNAME[1] = "ITEM1: " + this.ItemInfo(this.detail1, this.detail2, 0);
        this.ITEMNAME[2] = "CONDITION: " + this.ItemInfo(this.detail1, this.detail2, 1);
        this.ITEMNAME[3] = "ITEM2: " + this.ItemInfo(this.detail1, this.detail2, 2);
      }
      if (typ == 3)
        this.ITEMNAME[1] = "EXECTYPE: " + this.ItemInfo(this.detail1, this.detail2, 0);
      if (typ == 4)
      {
        this.ITEMNAME[1] = "SETVAR: " + this.ItemInfo(this.detail1, this.detail2, 0);
        this.ITEMNAME[2] = "SETTYPE: " + this.ItemInfo(this.detail1, this.detail2, 1);
        this.ITEMNAME[3] = "VALUE: " + this.ItemInfo(this.detail1, this.detail2, 2);
      }
      if (typ != 5)
        return;
      this.ITEMNAME[1] = "TEMPVAR: " + this.ItemInfo(this.detail1, this.detail2, 0);
      this.ITEMNAME[2] = "STARTVAL: " + this.ItemInfo(this.detail1, this.detail2, 1);
      this.ITEMNAME[3] = "ENDVAL: " + this.ItemInfo(this.detail1, this.detail2, 2);
    }

    public string ItemInfo(int enr, int cnr, int inr)
    {
      CommandClass command = this.game.Data.EventObj[enr].CommandList[cnr];
      if (command.type == 5 && inr == 0)
        return "TempVar" + Strings.Trim(Conversion.Str((object) command.Data[inr, 0]));
      if (Conversions.ToDouble(command.Data[inr, 0]) == 0.0)
        return "Empty";
      if (Conversions.ToDouble(command.Data[inr, 0]) == 1.0)
      {
        if (command.type == 5 & inr == 1)
          return "FROM " + this.GetVarInfo(enr, cnr, inr, 1);
        return command.type == 5 & inr == 2 ? "TO " + this.GetVarInfo(enr, cnr, inr, 1) : this.GetVarInfo(enr, cnr, inr, 1);
      }
      if (Conversions.ToDouble(command.Data[inr, 0]) == 2.0)
      {
        if (Conversions.ToDouble(command.Data[inr, 1]) == 0.0)
          return "Empty CheckType";
        string str1 = this.game.Data.CheckTypeNames[Conversions.ToInteger(command.Data[inr, 1])];
        if (this.game.Data.CheckTypeVarCount[Conversions.ToInteger(command.Data[inr, 1])] > 0)
        {
          string str2 = str1 + "(";
          int num = this.game.Data.CheckTypeVarCount[Conversions.ToInteger(command.Data[inr, 1])];
          for (int index = 1; index <= num; ++index)
          {
            if (index > 1)
              str2 += ", ";
            str2 += this.GetVarInfo(enr, cnr, inr, 1 + 3 * index);
          }
          str1 = str2 + ")";
        }
        if (command.type == 5 & inr == 1)
          return "FROM " + str1;
        return command.type == 5 & inr == 2 ? "TO " + str1 : str1;
      }
      if (Conversions.ToDouble(command.Data[inr, 0]) == 3.0)
      {
        if (Conversions.ToDouble(command.Data[inr, 1]) == 0.0)
          return "Empty Condition";
        if (Conversions.ToDouble(command.Data[inr, 1]) == 1.0)
          return ">";
        if (Conversions.ToDouble(command.Data[inr, 1]) == 2.0)
          return "<";
        if (Conversions.ToDouble(command.Data[inr, 1]) == 3.0)
          return "==";
        if (Conversions.ToDouble(command.Data[inr, 1]) == 4.0)
          return "=>";
        if (Conversions.ToDouble(command.Data[inr, 1]) == 5.0)
          return "=<";
        if (Conversions.ToDouble(command.Data[inr, 1]) == 6.0)
          return "!=";
      }
      else
      {
        if (Conversions.ToDouble(command.Data[inr, 0]) == 4.0)
        {
          if (Conversions.ToDouble(command.Data[inr, 1]) == 0.0)
            return "Empty ExecType";
          string str3 = this.game.Data.ExecTypeNames[Conversions.ToInteger(command.Data[inr, 1])];
          if (this.game.Data.ExecTypeVarCount[Conversions.ToInteger(command.Data[inr, 1])] > 0)
          {
            string str4 = str3 + "(";
            int num = this.game.Data.ExecTypeVarCount[Conversions.ToInteger(command.Data[inr, 1])];
            for (int index = 1; index <= num; ++index)
            {
              if (index > 1)
                str4 += ", ";
              str4 += this.GetVarInfo(enr, cnr, inr, 1 + 3 * index);
            }
            str3 = str4 + ")";
          }
          return str3;
        }
        if (Conversions.ToDouble(command.Data[inr, 0]) == 5.0)
        {
          if (Conversions.ToDouble(command.Data[inr, 1]) == 0.0)
            return "Empty SetType";
          if (Conversions.ToDouble(command.Data[inr, 1]) == 1.0)
            return "=";
          if (Conversions.ToDouble(command.Data[inr, 1]) == 2.0)
            return "+";
          if (Conversions.ToDouble(command.Data[inr, 1]) == 3.0)
            return "-";
          if (Conversions.ToDouble(command.Data[inr, 1]) == 4.0)
            return "/";
          if (Conversions.ToDouble(command.Data[inr, 1]) == 5.0)
            return "*";
        }
      }
      string str;
      return str;
    }

    public string GetVarInfo(int enr, int cnr, int inr, int datnr)
    {
      CommandClass command = this.game.Data.EventObj[enr].CommandList[cnr];
      if (Conversions.ToDouble(command.Data[inr, datnr]) == 0.0)
        return "Empty VarInfo";
      if (Conversions.ToDouble(command.Data[inr, datnr]) == 1.0)
        return "TempVar" + Strings.Trim(Conversion.Str((object) command.Data[inr, datnr + 1]));
      if (Conversions.ToDouble(command.Data[inr, datnr]) == 2.0)
      {
        string varInfo;
        if (Conversions.ToDouble(command.Data[inr, datnr + 1]) <= (double) this.game.Data.RegimeCounter)
          varInfo = this.game.Data.RegimeObj[Conversions.ToInteger(command.Data[inr, datnr + 1])].Name + "_" + this.game.Data.RegimeSlotName[Conversions.ToInteger(command.Data[inr, datnr + 2])] + "(#" + Strings.Trim(Conversion.Str((object) command.Data[inr, datnr + 2])) + ")";
        else
          varInfo = "Non-existing Regime" + Conversion.Str((object) command.Data[inr, datnr + 1]) + "_" + this.game.Data.RegimeSlotName[Conversions.ToInteger(command.Data[inr, datnr + 2])] + "(#" + Strings.Trim(Conversion.Str((object) command.Data[inr, datnr + 2])) + ")";
        return varInfo;
      }
      if (Conversions.ToDouble(command.Data[inr, datnr]) == 3.0)
      {
        string str = "Gameslot_(#" + Strings.Trim(Conversion.Str((object) command.Data[inr, datnr + 1])) + ")_" + this.game.Data.GameSlotName[Conversions.ToInteger(command.Data[inr, datnr + 1])];
        if (str.Length > 49)
          str = Strings.Left(str, 49) + "...";
        return str;
      }
      if (Conversions.ToDouble(command.Data[inr, datnr]) == 4.0)
        return Strings.Trim(Conversion.Str((object) command.Data[inr, datnr + 1]));
      if (Conversions.ToDouble(command.Data[inr, datnr]) == 5.0)
      {
        int historicalUnitById = this.game.HandyFunctionsObj.GetHistoricalUnitByID(Conversions.ToInteger(command.Data[inr, datnr + 1]));
        return historicalUnitById <= -1 ? "_!!Unit_Aint_OnMap!!_" : "[HisID" + this.game.Data.HistoricalUnitObj[historicalUnitById].ID.ToString() + "]" + this.game.Data.HistoricalUnitObj[historicalUnitById].Name;
      }
      if (Conversions.ToDouble(command.Data[inr, datnr]) == 6.0)
      {
        int areaById = this.game.HandyFunctionsObj.GetAreaByID(Conversions.ToInteger(command.Data[inr, datnr + 1]));
        return areaById <= -1 ? "_!!Area_Aint_OnMap!!_" : "[Area]" + this.game.Data.AreaObj[areaById].Name;
      }
      if (Conversions.ToDouble(command.Data[inr, datnr]) == 7.0)
        return "TempString" + Strings.Trim(Conversion.Str((object) command.Data[inr, datnr + 1]));
      if (Conversions.ToDouble(command.Data[inr, datnr]) == 8.0)
        return "'" + command.Data[inr, datnr + 1] + "'";
      string varInfo1;
      return varInfo1;
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
            if (num1 == this.ExecNow)
            {
              if (this.detail1 > -1)
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
                this.game.EventRelatedObj.DoCheckSpecificEvent(this.detail1);
                this.game.Data.EventObj[this.detail1].Blocked = false;
                this.game.Data.Turn = turn;
                int num2 = (int) Interaction.MsgBox((object) "Done");
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else
            {
              if (num1 == this.Import1)
              {
                string str = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1|SE1 Map file(*.se1map)|*.se1map|SE1 Master file(*.se1master)|*.se1master|SE1 Event library(*.se1evlib)|*.se1evlib|SE1 Troops&Equipment library(*.se1troops)|*.se1troops|SE1 Historical library(*.se1his)|*.se1his|SE1 Officer Card Library(*.se1offcard)|*.se1offcard|SE1 Officer library(*.se1off)|*.se1off", "Pick a scenario to load events from...", this.game.AppPath + "scenarios\\", false);
                if (File.Exists(str))
                {
                  this.game.HandyFunctionsObj.Unzip(str);
                  DataClass dataClass = DataClass.deserialize(str);
                  this.game.HandyFunctionsObj.ZipFile(str);
                  string InputStr = Interaction.InputBox("Give Event# to import, -1=all");
                  int eventCounter = dataClass.EventCounter;
                  for (int index2 = 0; index2 <= eventCounter; ++index2)
                  {
                    if (Conversion.Val(InputStr) != -1.0 & Conversion.Val(InputStr) == (double) index2 & this.detail1 > -1)
                    {
                      if (Interaction.MsgBox((object) "Overwrite selected event?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                        this.game.Data.EventObj[this.detail1] = dataClass.EventObj[index2].Clone();
                      else if (Operators.CompareString(this.game.Data.EventObj[this.detail1].Name, "New Event", false) == 0)
                      {
                        this.game.Data.EventObj[this.detail1] = dataClass.EventObj[index2].Clone();
                        ++this.game.Data.EventIdCounter;
                        this.game.Data.EventObj[this.detail1].Id = this.game.Data.EventIdCounter;
                      }
                      else
                      {
                        this.game.Data.AddEvent();
                        this.game.Data.EventObj[this.game.Data.EventCounter] = dataClass.EventObj[index2].Clone();
                        ++this.game.Data.EventIdCounter;
                        this.game.Data.EventObj[this.game.Data.EventCounter].Id = this.game.Data.EventIdCounter;
                      }
                    }
                    else if ((double) index2 == Conversion.Val(InputStr) | Conversion.Val(InputStr) == -1.0)
                    {
                      if (this.detail1 > -1 & Conversion.Val(InputStr) != -1.0)
                      {
                        if (Operators.CompareString(this.game.Data.EventObj[this.detail1].Name, "New Event", false) == 0)
                        {
                          this.game.Data.EventObj[this.detail1] = dataClass.EventObj[index2].Clone();
                          ++this.game.Data.EventIdCounter;
                          this.game.Data.EventObj[this.detail1].Id = this.game.Data.EventIdCounter;
                        }
                        else
                        {
                          this.game.Data.AddEvent();
                          this.game.Data.EventObj[this.game.Data.EventCounter] = dataClass.EventObj[index2].Clone();
                          ++this.game.Data.EventIdCounter;
                          this.game.Data.EventObj[this.game.Data.EventCounter].Id = this.game.Data.EventIdCounter;
                        }
                      }
                      else
                      {
                        this.game.Data.AddEvent();
                        this.game.Data.EventObj[this.game.Data.EventCounter] = dataClass.EventObj[index2].Clone();
                        ++this.game.Data.EventIdCounter;
                        this.game.Data.EventObj[this.game.Data.EventCounter].Id = this.game.Data.EventIdCounter;
                      }
                    }
                  }
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.Import2)
              {
                string str = this.game.HandyFunctionsObj.LoadSomething("SE1 Scenario file (*.se1)|*.se1", "Pick a scenario to load events from...", this.game.AppPath + "scenarios\\", false);
                if (File.Exists(str))
                {
                  this.game.HandyFunctionsObj.Unzip(str);
                  DataClass dataClass = DataClass.deserialize(str);
                  this.game.HandyFunctionsObj.ZipFile(str);
                  string InputStr = Interaction.InputBox("Give Event Group# to import, -1=all");
                  int eventCounter = dataClass.EventCounter;
                  for (int index3 = 0; index3 <= eventCounter; ++index3)
                  {
                    if ((double) dataClass.EventObj[index3].Category == Conversion.Val(InputStr) | Conversion.Val(InputStr) == -1.0)
                    {
                      this.game.Data.AddEvent();
                      this.game.Data.EventObj[this.game.Data.EventCounter] = dataClass.EventObj[index3].Clone();
                      ++this.game.Data.EventIdCounter;
                      this.game.Data.EventObj[this.game.Data.EventCounter].Id = this.game.Data.EventIdCounter;
                    }
                  }
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.info1id)
              {
                windowReturnClass.AddCommand(3, 2);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.AddEventId)
              {
                if (this.detail1 == -1)
                  this.detail1 = this.game.Data.EventCounter;
                this.game.Data.AddEvent(this.detail1);
                if (this.cat > -1)
                  this.game.Data.EventObj[this.detail1 + 1].Category = this.cat;
                ++this.detail1;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.EventCopy)
              {
                this.game.EditObj.TempEvent = this.game.Data.EventObj[this.detail1].Clone();
                return windowReturnClass;
              }
              if (num1 == this.EventPaste)
              {
                if (this.game.EditObj.TempEvent != null)
                {
                  this.game.Data.AddEvent(this.detail1);
                  int id = this.game.Data.EventObj[this.detail1 + 1].Id;
                  ++this.detail1;
                  this.game.Data.EventObj[this.detail1] = this.game.EditObj.TempEvent.Clone();
                  this.game.Data.EventObj[this.detail1].Id = id;
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.replaceId)
              {
                int num3 = (int) Math.Round(Conversion.Val(Interaction.InputBox("What kind of replacement?" + "\r\n0) Cancel" + "\r\n1) RealString, EXACT" + "\r\n2) RealString, PARTIAL + EXACT", "Replace Options")));
                if (!(num3 >= 1 & num3 <= 2))
                  return windowReturnClass;
                int num4 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Extend of replacement" + "\r\n0) Cancel" + "\r\n1) Only in selected event" + "\r\n2) Only in selected library (or all without library)" + "\r\n3) In all events", "Replace Options")));
                if (!(num4 >= 1 & num4 <= 3))
                  return windowReturnClass;
                if (this.detail1 == -1 & num4 < 3)
                {
                  int num5 = (int) Interaction.MsgBox((object) "You must have an event selected to use the replace function like this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  return windowReturnClass;
                }
                string str1 = Interaction.InputBox("Search for");
                string newValue = Interaction.InputBox("Replace with");
                int eventCounter = this.game.Data.EventCounter;
                int num6;
                int num7;
                string str2;
                for (int index4 = 0; index4 <= eventCounter; ++index4)
                {
                  bool flag1 = false;
                  bool flag2 = true;
                  if (num4 == 1 && index4 != this.detail1)
                    flag2 = false;
                  if (num4 == 2 && this.game.Data.EventObj[index4].LibId.libSlot != this.game.Data.EventObj[this.detail1].LibId.libSlot)
                    flag2 = false;
                  if (flag2)
                  {
                    int commandCounter = this.game.Data.EventObj[index4].CommandCounter;
                    for (int index5 = 0; index5 <= commandCounter; ++index5)
                    {
                      int index6 = 0;
                      do
                      {
                        int num8 = 0;
                        do
                        {
                          int integer = Conversions.ToInteger(this.game.Data.EventObj[index4].CommandList[index5].Data[index6, 1 + num8 * 3]);
                          string str3 = this.game.Data.EventObj[index4].CommandList[index5].Data[index6, 1 + num8 * 3 + 1];
                          if (num3 == 1 & integer == 8)
                          {
                            if (Operators.CompareString(str3, str1, false) == 0)
                            {
                              this.game.Data.EventObj[index4].CommandList[index5].Data[index6, 1 + num8 * 3 + 1] = newValue;
                              ++num6;
                              flag1 = true;
                            }
                          }
                          else if (num3 == 2 & integer == 8 && Strings.InStr(str3, str1) > 0)
                          {
                            string str4 = str3.Replace(str1, newValue);
                            this.game.Data.EventObj[index4].CommandList[index5].Data[index6, 1 + num8 * 3 + 1] = str4;
                            ++num6;
                            flag1 = true;
                          }
                          ++num8;
                        }
                        while (num8 <= 3);
                        ++index6;
                      }
                      while (index6 <= 2);
                    }
                  }
                  if (flag1)
                  {
                    ++num7;
                    if (num7 > 1)
                      str2 += ", ";
                    str2 = str2 + "[" + index4.ToString() + "] " + this.game.Data.EventObj[index4].Name;
                  }
                }
                int num9 = (int) Interaction.MsgBox((object) ("Made " + num6.ToString() + " changes in " + num7.ToString() + " events. " + str2), Title: ((object) "Shadow Empire : Planetary Conquest"));
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.setCat)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 32, this.detail1);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.setLib)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 90, this.detail1);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.RemoveEventId)
              {
                this.game.Data.RemoveEvent(this.detail1);
                --this.detail1;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.AddCommandId)
              {
                this.game.Data.EventObj[this.detail1].AddCommand(this.detail2);
                ++this.detail2;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.allowExecuteId)
              {
                this.game.Data.EventObj[this.detail1].AllowExecute = !this.game.Data.EventObj[this.detail1].AllowExecute;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.InsertId)
              {
                int index7 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give an event #", "Shadow Empire : Planetary Conquest")));
                int num10 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give start command line #", "Shadow Empire : Planetary Conquest")));
                int num11 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give end command line #", "Shadow Empire : Planetary Conquest"))) - num10 + 1;
                if (index7 > -1 & index7 <= this.game.Data.EventCounter)
                {
                  int num12 = num11;
                  for (int index8 = 1; index8 <= num12; ++index8)
                  {
                    int index9 = num10 - 1 + index8;
                    if (this.game.Data.EventObj[index7].CommandCounter >= index9 & index9 > -1)
                    {
                      CommandClass commandClass = this.game.Data.EventObj[index7].CommandList[index9].Clone();
                      this.game.Data.EventObj[this.detail1].AddCommand(this.detail2);
                      ++this.detail2;
                      if (index7 == this.detail1 & num10 > this.detail2)
                      {
                        ++num10;
                        ++num11;
                      }
                      this.game.Data.EventObj[this.detail1].CommandList[this.detail2] = commandClass;
                    }
                  }
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.CommandCopy)
              {
                this.game.EditObj.TempCommand = this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Clone();
                return windowReturnClass;
              }
              if (num1 == this.CommandPaste)
              {
                if (this.game.EditObj.TempCommand != null)
                {
                  this.game.Data.EventObj[this.detail1].AddCommand(this.detail2);
                  ++this.detail2;
                  this.game.Data.EventObj[this.detail1].CommandList[this.detail2] = this.game.EditObj.TempCommand.Clone();
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.CommandUpId)
              {
                this.game.Data.EventObj[this.detail1].Commandup(this.detail2);
                --this.detail2;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.CommandDownId)
              {
                this.game.Data.EventObj[this.detail1].Commanddown(this.detail2);
                ++this.detail2;
                if (this.detail2 > this.game.Data.EventObj[this.detail1].CommandCounter)
                  --this.detail2;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.RemoveCommandId)
              {
                this.game.Data.EventObj[this.detail1].RemoveCommand(this.detail2);
                --this.detail2;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.EventUpId)
              {
                this.game.Data.eventup(this.detail1);
                --this.detail1;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.EventDownId)
              {
                this.game.Data.eventdown(this.detail1);
                ++this.detail1;
                if (this.detail1 > this.game.Data.EventCounter)
                  --this.detail1;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.info3id)
              {
                this.game.Data.EventObj[this.detail1].Name = Interaction.InputBox("Give Name for this Event", "Shadow Empire : Planetary Conquest");
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.Typ1)
              {
                this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type = 1;
                int index10 = 0;
                do
                {
                  int index11 = 0;
                  do
                  {
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[index10, index11] = Conversions.ToString(0);
                    ++index11;
                  }
                  while (index11 <= 30);
                  ++index10;
                }
                while (index10 <= 2);
                this.bigclear();
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.Typ2)
              {
                this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type = 2;
                int index12 = 0;
                do
                {
                  int index13 = 0;
                  do
                  {
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[index12, index13] = Conversions.ToString(0);
                    ++index13;
                  }
                  while (index13 <= 30);
                  ++index12;
                }
                while (index12 <= 2);
                this.bigclear();
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.Typ3)
              {
                this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type = 3;
                int index14 = 0;
                do
                {
                  int index15 = 0;
                  do
                  {
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[index14, index15] = Conversions.ToString(0);
                    ++index15;
                  }
                  while (index15 <= 30);
                  ++index14;
                }
                while (index14 <= 2);
                this.bigclear();
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.Typ4)
              {
                this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type = 4;
                int index16 = 0;
                do
                {
                  int index17 = 0;
                  do
                  {
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[index16, index17] = Conversions.ToString(0);
                    ++index17;
                  }
                  while (index17 <= 30);
                  ++index16;
                }
                while (index16 <= 2);
                this.bigclear();
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.Typ5)
              {
                this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type = 5;
                int index18 = 0;
                do
                {
                  int index19 = 0;
                  do
                  {
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[index18, index19] = Conversions.ToString(0);
                    ++index19;
                  }
                  while (index19 <= 30);
                  ++index18;
                }
                while (index18 <= 2);
                this.bigclear();
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.Typ6)
              {
                this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type = 6;
                int index20 = 0;
                do
                {
                  int index21 = 0;
                  do
                  {
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[index20, index21] = Conversions.ToString(0);
                    ++index21;
                  }
                  while (index21 <= 30);
                  ++index20;
                }
                while (index20 <= 2);
                this.bigclear();
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.Typ7)
              {
                this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type = 7;
                int index22 = 0;
                do
                {
                  int index23 = 0;
                  do
                  {
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[index22, index23] = Conversions.ToString(0);
                    ++index23;
                  }
                  while (index23 <= 30);
                  ++index22;
                }
                while (index22 <= 2);
                this.bigclear();
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.typstr)
              {
                if (this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type == 3)
                {
                  int integer = Conversions.ToInteger(this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[0, 1]);
                  if (this.game.Data.ExecTypeString[integer] == 1)
                  {
                    this.DoingSlots = true;
                    this.SetSlot = 0;
                    this.StepCurrent = this.game.Data.ExecTypeVarCount[integer] + 1;
                    this.dostuff();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (this.game.Data.ExecTypeString[integer] == 2)
                  {
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].DataString = Interaction.InputBox("Give String", "Shadow Empire : Planetary Conquest", this.game.Data.EventObj[this.detail1].CommandList[this.detail2].DataString);
                    this.dostuff();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                }
                if (this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type == 7)
                {
                  this.game.Data.EventObj[this.detail1].CommandList[this.detail2].DataString = Interaction.InputBox("Give String for Comment Line", "Shadow Empire : Planetary Conquest", this.game.Data.EventObj[this.detail1].CommandList[this.detail2].DataString);
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                int num13 = (int) Interaction.MsgBox((object) "Cannot edit tempstring. Is not exectype, or exectype has no text option.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                this.bigclear();
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.TypMode)
              {
                EventClass[] eventObj = this.game.Data.EventObj;
                EventClass[] eventClassArray = eventObj;
                int detail1 = this.detail1;
                int index24 = detail1;
                eventClassArray[index24].CheckMode = eventObj[detail1].CheckMode + 1;
                if (this.game.Data.EventObj[this.detail1].CheckMode > 12)
                  this.game.Data.EventObj[this.detail1].CheckMode = 0;
                this.bigclear();
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.setPrio)
              {
                this.game.Data.EventObj[this.detail1].Priority = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new prio (0=default)", "Shadow Empire : Planetary Conquest", this.game.Data.EventObj[this.detail1].Priority.ToString())));
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.Item1)
              {
                if (this.game.Data.EventObj[this.detail1].CommandList[this.detail2].type == 5)
                {
                  int num14 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give a TempVar between 0-999.", "Shadow Empire : Planetary Conquest")));
                  if (num14 < 0 | num14 > 999)
                  {
                    int num15 = (int) Interaction.MsgBox((object) "between 0 and 999 please", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[0, 0] = Conversions.ToString(num14);
                    this.bigclear();
                    this.dostuff();
                    windowReturnClass.SetFlag(true);
                  }
                }
                else
                {
                  this.DoingSlots = true;
                  this.SetSlot = 0;
                  this.StepCurrent = 0;
                  this.bigclear();
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
              }
              else
              {
                if (num1 == this.Item2)
                {
                  this.DoingSlots = true;
                  this.SetSlot = 1;
                  this.StepCurrent = 0;
                  this.bigclear();
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.Item3)
                {
                  this.DoingSlots = true;
                  this.SetSlot = 2;
                  this.StepCurrent = 0;
                  this.bigclear();
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.tabx1)
                {
                  this.DoingSlots = false;
                  this.bigclear();
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.tabx2)
                {
                  this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 0] = Conversions.ToString(0);
                  --this.StepCurrent;
                  this.bigclear();
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.quick1)
                {
                  this.DoingSlots = true;
                  this.DoEscape = true;
                  this.SetSlot = 0;
                  this.StepCurrent = 2;
                  if (Conversions.ToDouble(this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[0, 0]) == 4.0)
                    --this.StepCurrent;
                  this.bigclear();
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.quick2)
                {
                  this.DoingSlots = true;
                  this.DoEscape = true;
                  this.SetSlot = 0;
                  this.StepCurrent = 3;
                  if (Conversions.ToDouble(this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[0, 0]) == 4.0)
                    --this.StepCurrent;
                  this.bigclear();
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.quick3)
                {
                  this.DoingSlots = true;
                  this.DoEscape = true;
                  this.SetSlot = 0;
                  this.StepCurrent = 4;
                  if (Conversions.ToDouble(this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[0, 0]) == 4.0)
                    --this.StepCurrent;
                  this.bigclear();
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.quick4)
                {
                  this.DoingSlots = true;
                  this.DoEscape = true;
                  this.SetSlot = 0;
                  this.StepCurrent = 5;
                  if (Conversions.ToDouble(this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[0, 0]) == 4.0)
                    --this.StepCurrent;
                  this.bigclear();
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.quick5)
                {
                  this.DoingSlots = true;
                  this.DoEscape = true;
                  this.SetSlot = 2;
                  this.StepCurrent = 2;
                  if (Conversions.ToDouble(this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[2, 0]) == 4.0)
                    --this.StepCurrent;
                  this.bigclear();
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.quick6)
                {
                  this.DoingSlots = true;
                  this.DoEscape = true;
                  this.SetSlot = 2;
                  this.StepCurrent = 3;
                  if (Conversions.ToDouble(this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[2, 0]) == 4.0)
                    --this.StepCurrent;
                  this.bigclear();
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.quick7)
                {
                  this.DoingSlots = true;
                  this.DoEscape = true;
                  this.SetSlot = 2;
                  this.StepCurrent = 4;
                  if (Conversions.ToDouble(this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[2, 0]) == 4.0)
                    --this.StepCurrent;
                  this.bigclear();
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.quick8)
                {
                  this.DoingSlots = true;
                  this.DoEscape = true;
                  this.SetSlot = 2;
                  this.StepCurrent = 5;
                  if (Conversions.ToDouble(this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[2, 0]) == 4.0)
                    --this.StepCurrent;
                  this.bigclear();
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsListId)
                {
                  int num16 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  if (num16 != -1)
                  {
                    this.detail1 = num16;
                    this.dostuff();
                  }
                  else
                    this.SubPartFlag[index1] = true;
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                int num17;
                if (num1 == this.DescriptId)
                {
                  num17 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsList5Id)
                {
                  int num18 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  if (this.cat != num18)
                  {
                    this.cat = num18;
                    this.dostuff();
                  }
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsList6Id)
                {
                  int num19 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  if (num19 > 0)
                    --num19;
                  if (this.detailLib != num19)
                  {
                    this.detailLib = num19;
                    this.dostuff();
                  }
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.tta)
                {
                  num17 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.SubPartFlag[index1] = true;
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsList2Id)
                {
                  int num20 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  if (num20 != -1)
                  {
                    this.detail2 = num20;
                    this.dostuff();
                  }
                  else
                    this.SubPartFlag[index1] = true;
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsList3Id)
                {
                  this.detail3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.GroupListId)
                {
                  this.groupdetail = (object) this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsList4Id)
                {
                  this.detail4 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.Tab1)
                {
                  this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 0] = Conversions.ToString(1);
                  ++this.StepCurrent;
                  this.bigclear();
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.Tab2)
                {
                  this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 0] = Conversions.ToString(2);
                  ++this.StepCurrent;
                  this.bigclear();
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.Tab6)
                {
                  this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 0] = Conversions.ToString(1);
                  ++this.StepCurrent;
                  this.dostuff();
                  int num21 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give a TempVar number between 0 and 999", "Shadow Empire : Planetary Conquest")));
                  if (num21 < 0 | num21 > 999)
                  {
                    int num22 = (int) Interaction.MsgBox((object) "Beep. Stay in the limits plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1 + this.VarExtra] = Conversions.ToString(1);
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 2 + this.VarExtra] = Conversions.ToString(num21);
                    ++this.StepCurrent;
                    if (this.DoEscape)
                    {
                      this.DoEscape = false;
                      this.DoingSlots = false;
                    }
                    this.bigclear();
                    this.dostuff();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                }
                else if (num1 == this.Tab9)
                {
                  this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 0] = Conversions.ToString(1);
                  ++this.StepCurrent;
                  this.bigclear();
                  this.dostuff();
                  int num23 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give a Real number between -999999 and 999999", "Shadow Empire : Planetary Conquest")));
                  if (num23 < -999999 | num23 > 999999)
                  {
                    int num24 = (int) Interaction.MsgBox((object) "Beep. Stay in the limits plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1 + this.VarExtra] = Conversions.ToString(4);
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 2 + this.VarExtra] = Conversions.ToString(num23);
                    ++this.StepCurrent;
                    if (this.DoEscape)
                    {
                      this.DoEscape = false;
                      this.DoingSlots = false;
                    }
                    this.bigclear();
                    this.dostuff();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                }
                else if (num1 == this.Tab10)
                {
                  this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 0] = Conversions.ToString(1);
                  ++this.StepCurrent;
                  this.bigclear();
                  this.dostuff();
                  int num25 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give a TempString number between 0 and 999", "Shadow Empire : Planetary Conquest")));
                  if (num25 < -999999 | num25 > 999999)
                  {
                    int num26 = (int) Interaction.MsgBox((object) "Beep. Stay in the limits plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1 + this.VarExtra] = Conversions.ToString(7);
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 2 + this.VarExtra] = Conversions.ToString(num25);
                    ++this.StepCurrent;
                    if (this.DoEscape)
                    {
                      this.DoEscape = false;
                      this.DoingSlots = false;
                    }
                    this.bigclear();
                    this.dostuff();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                }
                else if (num1 == this.Tab10b)
                {
                  int num27 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give a TempString number between 0 and 999", "Shadow Empire : Planetary Conquest")));
                  if (num27 < 0 | num27 > 999)
                  {
                    int num28 = (int) Interaction.MsgBox((object) "Beep. Stay in the limits plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1 + this.VarExtra] = Conversions.ToString(7);
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 2 + this.VarExtra] = Conversions.ToString(num27);
                    ++this.StepCurrent;
                    if (this.DoEscape)
                    {
                      this.DoEscape = false;
                      this.DoingSlots = false;
                    }
                    this.dostuff();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                }
                else
                {
                  if (num1 == this.tab19)
                  {
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 0] = Conversions.ToString(1);
                    ++this.StepCurrent;
                    this.bigclear();
                    this.dostuff();
                    string str = Interaction.InputBox("Give a Real String", "Shadow Empire : Planetary Conquest", this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 2 + this.VarExtra]);
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1 + this.VarExtra] = Conversions.ToString(8);
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 2 + this.VarExtra] = str;
                    ++this.StepCurrent;
                    if (this.DoEscape)
                    {
                      this.DoEscape = false;
                      this.DoingSlots = false;
                    }
                    this.bigclear();
                    this.dostuff();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.Tab7)
                  {
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 0] = Conversions.ToString(1);
                    ++this.StepCurrent;
                    this.bigclear();
                    this.dostuff();
                    this.detailchoice = 2;
                    this.dostuff();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.Tab8)
                  {
                    this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 0] = Conversions.ToString(1);
                    ++this.StepCurrent;
                    this.bigclear();
                    this.dostuff();
                    this.detailchoice = 3;
                    this.dostuff();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.Tab6b)
                  {
                    int num29 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give a TempVar number between 0 and 999", "Shadow Empire : Planetary Conquest")));
                    if (num29 < 0 | num29 > 999)
                    {
                      int num30 = (int) Interaction.MsgBox((object) "Beep. Stay in the limits plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    else
                    {
                      this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1 + this.VarExtra] = Conversions.ToString(1);
                      this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 2 + this.VarExtra] = Conversions.ToString(num29);
                      ++this.StepCurrent;
                      if (this.DoEscape)
                      {
                        this.DoEscape = false;
                        this.DoingSlots = false;
                      }
                      this.dostuff();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                  }
                  else if (num1 == this.Tab9b)
                  {
                    int num31 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give a Real number between -9999 and 9999", "Shadow Empire : Planetary Conquest")));
                    if (num31 < -999999 | num31 > 999999)
                    {
                      int num32 = (int) Interaction.MsgBox((object) "Beep. Stay in the limits plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    else
                    {
                      this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1 + this.VarExtra] = Conversions.ToString(4);
                      this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 2 + this.VarExtra] = Conversions.ToString(num31);
                      ++this.StepCurrent;
                      if (this.DoEscape)
                      {
                        this.DoEscape = false;
                        this.DoingSlots = false;
                      }
                      this.bigclear();
                      this.dostuff();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                  }
                  else
                  {
                    if (num1 == this.tab19b)
                    {
                      string str = Interaction.InputBox("Give a Real String", "Shadow Empire : Planetary Conquest", this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 2 + this.VarExtra]);
                      this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1 + this.VarExtra] = Conversions.ToString(8);
                      this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 2 + this.VarExtra] = str;
                      ++this.StepCurrent;
                      if (this.DoEscape)
                      {
                        this.DoEscape = false;
                        this.DoingSlots = false;
                      }
                      this.bigclear();
                      this.dostuff();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.Tab7b)
                    {
                      this.detailchoice = 2;
                      this.bigclear();
                      this.dostuff();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.Tab8b)
                    {
                      this.detailchoice = 3;
                      this.bigclear();
                      this.dostuff();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.NTab1)
                    {
                      this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 0] = Conversions.ToString(1);
                      ++this.StepCurrent;
                      this.bigclear();
                      this.dostuff();
                      this.detailchoice = 5;
                      this.dostuff();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.ntab1x)
                    {
                      this.detailchoice = 5;
                      this.bigclear();
                      this.dostuff();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.ntab2x)
                    {
                      this.detailchoice = 6;
                      this.bigclear();
                      this.dostuff();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.NTab2)
                    {
                      this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 0] = Conversions.ToString(1);
                      ++this.StepCurrent;
                      this.bigclear();
                      this.dostuff();
                      this.detailchoice = 6;
                      this.dostuff();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.Tab5)
                    {
                      if (this.detailchoice == 2)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1 + this.VarExtra] = Conversions.ToString(2);
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 2 + this.VarExtra] = Conversions.ToString(this.detail4);
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 3 + this.VarExtra] = Conversions.ToString(this.detail3);
                        ++this.StepCurrent;
                        if (this.DoEscape)
                        {
                          this.DoEscape = false;
                          this.DoingSlots = false;
                        }
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (this.detailchoice == 3)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1 + this.VarExtra] = Conversions.ToString(3);
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 2 + this.VarExtra] = Conversions.ToString(this.detail3);
                        ++this.StepCurrent;
                        if (this.DoEscape)
                        {
                          this.DoEscape = false;
                          this.DoingSlots = false;
                        }
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (this.detailchoice == 5)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1 + this.VarExtra] = Conversions.ToString(5);
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 2 + this.VarExtra] = Conversions.ToString(this.game.Data.HistoricalUnitObj[this.detail3].ID);
                        ++this.StepCurrent;
                        if (this.DoEscape)
                        {
                          this.DoEscape = false;
                          this.DoingSlots = false;
                        }
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (this.detailchoice == 6)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1 + this.VarExtra] = Conversions.ToString(6);
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 2 + this.VarExtra] = Conversions.ToString(this.game.Data.AreaObj[this.detail3].ID);
                        ++this.StepCurrent;
                        if (this.DoEscape)
                        {
                          this.DoEscape = false;
                          this.DoingSlots = false;
                        }
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                    }
                    else
                    {
                      if (num1 == this.tab11)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1] = Conversions.ToString(1);
                        ++this.StepCurrent;
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.tab12)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1] = Conversions.ToString(2);
                        ++this.StepCurrent;
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.tab13)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1] = Conversions.ToString(3);
                        ++this.StepCurrent;
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.tab131)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1] = Conversions.ToString(4);
                        ++this.StepCurrent;
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.tab132)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1] = Conversions.ToString(5);
                        ++this.StepCurrent;
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.tab133)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1] = Conversions.ToString(6);
                        ++this.StepCurrent;
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.Tab3)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1] = Conversions.ToString(this.detail3);
                        this.bigclear();
                        ++this.StepCurrent;
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.Tab4)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1] = Conversions.ToString(this.detail3);
                        ++this.StepCurrent;
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.tab14)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1] = Conversions.ToString(1);
                        ++this.StepCurrent;
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.tab15)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1] = Conversions.ToString(2);
                        ++this.StepCurrent;
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.tab16)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1] = Conversions.ToString(3);
                        ++this.StepCurrent;
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.tab17)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1] = Conversions.ToString(4);
                        ++this.StepCurrent;
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.tab18)
                      {
                        this.game.Data.EventObj[this.detail1].CommandList[this.detail2].Data[this.SetSlot, 1] = Conversions.ToString(5);
                        ++this.StepCurrent;
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.tok)
                      {
                        ++this.StepCurrent;
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.tok2)
                      {
                        new Form2((Form) this.formref).Initialize(this.game.Data, 3, this.detail1, this.detail2);
                        this.bigclear();
                        this.dostuff();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.Export)
                      {
                        this.game.FormRef.Cursor = Cursors.WaitCursor;
                        this.DoExport();
                        this.game.FormRef.Cursor = Cursors.Default;
                        int num33 = (int) Interaction.MsgBox((object) "Done");
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                    }
                  }
                }
              }
            }
            int index25 = 0;
            do
            {
              int num34 = this.SubPartID[index1];
              if (num34 == this.tbutton[index25])
              {
                this.temptext[index25] = Interaction.InputBox("Give Text Line.... (dont use #,@,*,)", "Shadow Empire : Planetary Conquest");
                this.ReconstructString();
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num34 == this.toption[index25])
              {
                if (this.tempoption[index25] == 1)
                {
                  this.tempoption[index25] = 0;
                }
                else
                {
                  int num35 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Leads to which event nr#??", "Shadow Empire : Planetary Conquest")));
                  if (num35 < 0 | num35 > this.game.Data.EventCounter)
                  {
                    int num36 = (int) Interaction.MsgBox((object) "No valid event#", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    this.tempoption[index25] = 1;
                    this.temprefer[index25] = num35;
                  }
                }
                this.ReconstructString();
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              ++index25;
            }
            while (index25 <= 19);
            return windowReturnClass;
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public void DoExport()
    {
      int eventCounter = this.game.Data.EventCounter;
      for (int enr = 0; enr <= eventCounter; ++enr)
      {
        StreamWriter text = File.CreateText(this.game.AppPath + "logs/" + this.game.Data.Name + "_eventID" + Conversion.Str((object) this.game.Data.EventObj[enr].Id) + ".txt");
        int num = 0;
        if (this.game.Data.EventObj[enr].CommandCounter > -1)
        {
          int commandCounter = this.game.Data.EventObj[enr].CommandCounter;
          for (int index = 0; index <= commandCounter; ++index)
          {
            string str1 = this.COMMANDTYPE[this.game.Data.EventObj[enr].CommandList[index].type];
            if (this.game.Data.EventObj[enr].CommandList[index].type == 2)
            {
              --num;
              if (0 > num)
                num = 0;
            }
            if (this.game.Data.EventObj[enr].CommandList[index].type == 6)
            {
              --num;
              if (0 > num)
                num = 0;
            }
            if (this.game.Data.EventObj[enr].CommandList[index].type == 1)
              str1 = str1 + ": " + this.ItemInfo(enr, index, 0) + " " + this.ItemInfo(enr, index, 1) + " " + this.ItemInfo(enr, index, 2);
            if (this.game.Data.EventObj[enr].CommandList[index].type == 3)
              str1 = str1 + ": " + this.ItemInfo(enr, index, 0);
            if (this.game.Data.EventObj[enr].CommandList[index].type == 7)
              str1 = "' " + this.game.Data.EventObj[enr].CommandList[index].DataString;
            if (this.game.Data.EventObj[enr].CommandList[index].type == 4)
              str1 = str1 + ": " + this.ItemInfo(enr, index, 0) + " " + this.ItemInfo(enr, index, 1) + " " + this.ItemInfo(enr, index, 2);
            if (this.game.Data.EventObj[enr].CommandList[index].type == 5)
              str1 = str1 + ": " + this.ItemInfo(enr, index, 0) + " " + this.ItemInfo(enr, index, 1) + " " + this.ItemInfo(enr, index, 2);
            string str2 = Strings.Trim(Conversion.Str((object) index)) + ") " + Strings.Space(4 - Strings.Len(Strings.Trim(Conversion.Str((object) index)))) + Strings.Space(num * 2) + str1;
            text.WriteLine(str2);
            if (this.game.Data.EventObj[enr].CommandList[index].type == 1)
              ++num;
            if (this.game.Data.EventObj[enr].CommandList[index].type == 5)
              ++num;
          }
        }
        text.Close();
      }
    }

    public void ReconstructString()
    {
      int num1 = -1;
      string str = "";
      int index1 = 0;
      do
      {
        if (Strings.Len(this.temptext[index1]) > 0)
          num1 = index1;
        ++index1;
      }
      while (index1 <= 19);
      int num2 = num1;
      for (int index2 = 0; index2 <= num2; ++index2)
      {
        if (this.tempoption[index2] == 1)
          str += "*";
        str += this.temptext[index2];
        if (this.tempoption[index2] == 1)
          str = str + "@" + Strings.Trim(Conversion.Str((object) this.temprefer[index2]));
        if (index2 < num1)
          str += "#";
      }
      this.game.Data.EventObj[this.detail1].CommandList[this.detail2].DataString = str;
    }
  }
}