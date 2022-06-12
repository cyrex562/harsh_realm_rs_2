// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.PeopleWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class PeopleWindowClass : WindowClass
  {
    private int LibListId;
    private int LibNr;
    private ListClass LibListObj;
    private int peopleListId;
    private ListClass peopleListObj;
    private int BAddpeopleId;
    private int BAddpeopleTextId;
    private int BNameId;
    private int BNameTextId;
    private int B1Id;
    private int B1TextId;
    private int highId;
    private int lowId;
    private int B2Id;
    private int B2TextId;
    private int B3Id;
    private int B3TextId;
    private int B4Id;
    private int B4TextId;
    private int B4bId;
    private int B4bTextId;
    private int B4cId;
    private int B4cTextId;
    private int z1id;
    private int z1textid;
    private int BRemovepeopleId;
    private int BRemovepeopleTextId;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int firstListId;
    private ListClass firstListObj;
    private int lastListId;
    private ListClass lastListObj;
    private int CombatListId;
    private ListClass CombatListObj;
    private int b19id;
    private int b19textid;
    private int b20id;
    private int b20textid;
    private int b18id;
    private int b18textid;
    private int b21id;
    private int b21textid;
    private int b22id;
    private int b22textid;
    private int b23id;
    private int b23textid;
    private int b24id;
    private int b24textid;
    private int b25id;
    private int b25textid;
    private int b26id;
    private int b26textid;
    private int b27id;
    private int b27textid;
    private int b28id;
    private int b28textid;
    private int a1Id;
    private int a1TextId;
    private int a2Id;
    private int a2TextId;
    private int a3Id;
    private int a3TextId;
    private int a4Id;
    private int a4TextId;
    private int a5Id;
    private int a5TextId;
    private int a6Id;
    private int a6TextId;
    private int a7Id;
    private int a7TextId;
    private int a8Id;
    private int a8TextId;
    private int x1id;
    private int x2id;
    private int x3id;
    private int x4id;
    private int x5id;
    private int x6id;
    private int x7id;
    private int x8id;
    private int x9id;
    private int x10id;
    private int x11id;
    private int x12id;
    private int killnameid;
    private int addnameid;
    private int addtext1;
    private int killname2id;
    private int addname2id;
    private int addtext2;
    private int c1id;
    private int OffPicId;
    private int c2id;
    private int c2textid;
    private int peopleNr;
    private int detailnr;
    private int firstdetail;
    private int lastdetail;
    private int offnr;
    private string ss;

    public PeopleWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Peoples")
    {
      this.peopleNr = -1;
      this.detailnr = -1;
      this.LibNr = -1;
      this.firstdetail = -1;
      this.lastdetail = -1;
      this.offnr = -1;
      this.MakepeopleListGUI(-1);
    }

    public override void DoRefresh() => this.MakepeopleTypeItemGUI();

    private void MakepeopleListGUI(int tpeoplenr)
    {
      if (this.LibListId > 0)
        this.RemoveSubPart(this.LibListId);
      this.LibListObj = new ListClass();
      this.LibListObj.add("All", -2);
      int num1 = -1;
      int num2 = 0;
      int libraryCounter = this.game.Data.LibraryCounter;
      for (int index = 0; index <= libraryCounter; ++index)
      {
        ++num2;
        if (this.LibNr == index)
          num1 = num2;
        this.LibListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.LibraryObj[index].name, index);
      }
      if (this.LibNr == -1)
        num1 = 0;
      ListClass libListObj = this.LibListObj;
      int tlistselect1 = num1;
      GameClass game1 = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(libListObj, 9, 200, tlistselect1, game1, tHeader: "Libraries", tbackbitmap: (ref local1), bbx: 10, bby: 38, overruleFont: (ref local2));
      this.LibListId = this.AddSubPart(ref tsubpart1, 10, 50, 200, 192, 0);
      if (this.peopleListId > 0)
        this.RemoveSubPart(this.peopleListId);
      int num3 = -1;
      int num4 = -1;
      if (this.game.Data.PeopleCounter > -1)
      {
        this.peopleListObj = new ListClass();
        int peopleCounter = this.game.Data.PeopleCounter;
        for (int index = 0; index <= peopleCounter; ++index)
        {
          if (this.game.Data.PeopleObj[index].LibId.libSlot == this.LibNr | this.LibNr == -1)
          {
            ++num4;
            if (this.LibNr == index)
              num3 = num4;
            this.peopleListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.PeopleObj[index].Name + "(id" + this.game.Data.PeopleObj[index].id.ToString() + ")", index);
          }
        }
        ListClass peopleListObj = this.peopleListObj;
        int tlistselect2 = num3;
        GameClass game2 = this.game;
        ref Bitmap local3 = ref this.OwnBitmap;
        font = (Font) null;
        ref Font local4 = ref font;
        SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(peopleListObj, 9, 200, tlistselect2, game2, tHeader: "Peoples", tbackbitmap: (ref local3), bbx: 220, bby: 50, overruleFont: (ref local4));
        this.peopleListId = this.AddSubPart(ref tsubpart2, 220, 50, 200, 192, 0);
        this.peopleNr = tpeoplenr;
        this.MakepeopleTypeItemGUI();
      }
      else
      {
        this.peopleNr = tpeoplenr;
        this.MakepeopleTypeItemGUI();
      }
      if (this.BAddpeopleId > 0)
        this.RemoveSubPart(this.BAddpeopleId);
      if (this.BAddpeopleTextId > 0)
        this.RemoveSubPart(this.BAddpeopleTextId);
      if (this.z1id > 0)
        this.RemoveSubPart(this.z1id);
      if (this.z1textid > 0)
        this.RemoveSubPart(this.z1textid);
      this.ss = "Click to add a people to the list";
      SubPartClass tsubpart3;
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.BAddpeopleId = this.AddSubPart(ref tsubpart3, 10, 270, 32, 16, 1);
      }
      tsubpart3 = (SubPartClass) new TextPartClass("Add a People", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BAddpeopleTextId = this.AddSubPart(ref tsubpart3, 50, 269, 300, 20, 0);
      this.ss = "Click to set all units of a specific regime to a specific people";
      tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
      this.z1id = this.AddSubPart(ref tsubpart3, 410, 290, 32, 16, 1);
      tsubpart3 = (SubPartClass) new TextPartClass("Set Units of Regime X", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.z1textid = this.AddSubPart(ref tsubpart3, 450, 289, 300, 20, 0);
    }

    private void MakepeopleTypeItemGUI()
    {
      if (this.BNameId > 0)
        this.RemoveSubPart(this.BNameId);
      if (this.BNameTextId > 0)
        this.RemoveSubPart(this.BNameTextId);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
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
      if (this.B4bId > 0)
        this.RemoveSubPart(this.B4bId);
      if (this.B4bTextId > 0)
        this.RemoveSubPart(this.B4bTextId);
      if (this.B4cId > 0)
        this.RemoveSubPart(this.B4cId);
      if (this.B4cTextId > 0)
        this.RemoveSubPart(this.B4cTextId);
      if (this.highId > 0)
        this.RemoveSubPart(this.highId);
      if (this.lowId > 0)
        this.RemoveSubPart(this.lowId);
      if (this.b18id > 0)
        this.RemoveSubPart(this.b18id);
      if (this.b18textid > 0)
        this.RemoveSubPart(this.b18textid);
      if (this.b19id > 0)
        this.RemoveSubPart(this.b19id);
      if (this.b19textid > 0)
        this.RemoveSubPart(this.b19textid);
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
      if (this.b23id > 0)
        this.RemoveSubPart(this.b23id);
      if (this.b23textid > 0)
        this.RemoveSubPart(this.b23textid);
      if (this.b24id > 0)
        this.RemoveSubPart(this.b24id);
      if (this.b24textid > 0)
        this.RemoveSubPart(this.b24textid);
      if (this.b25id > 0)
        this.RemoveSubPart(this.b25id);
      if (this.b25textid > 0)
        this.RemoveSubPart(this.b25textid);
      if (this.b26id > 0)
        this.RemoveSubPart(this.b26id);
      if (this.b26textid > 0)
        this.RemoveSubPart(this.b26textid);
      if (this.b27id > 0)
        this.RemoveSubPart(this.b27id);
      if (this.b27textid > 0)
        this.RemoveSubPart(this.b27textid);
      if (this.b28id > 0)
        this.RemoveSubPart(this.b28id);
      if (this.b28textid > 0)
        this.RemoveSubPart(this.b28textid);
      if (this.a1Id > 0)
        this.RemoveSubPart(this.a1Id);
      if (this.a1TextId > 0)
        this.RemoveSubPart(this.a1TextId);
      if (this.a2Id > 0)
        this.RemoveSubPart(this.a2Id);
      if (this.a2TextId > 0)
        this.RemoveSubPart(this.a2TextId);
      if (this.a3Id > 0)
      {
        this.RemoveSubPart(this.a3Id);
        this.a3Id = 0;
      }
      if (this.a3TextId > 0)
        this.RemoveSubPart(this.a3TextId);
      if (this.a4Id > 0)
        this.RemoveSubPart(this.a4Id);
      if (this.a4TextId > 0)
        this.RemoveSubPart(this.a4TextId);
      if (this.a5Id > 0)
        this.RemoveSubPart(this.a5Id);
      if (this.a5TextId > 0)
        this.RemoveSubPart(this.a5TextId);
      if (this.a6Id > 0)
        this.RemoveSubPart(this.a6Id);
      if (this.a6TextId > 0)
        this.RemoveSubPart(this.a6TextId);
      if (this.a7Id > 0)
        this.RemoveSubPart(this.a7Id);
      if (this.a7TextId > 0)
        this.RemoveSubPart(this.a7TextId);
      if (this.a8Id > 0)
        this.RemoveSubPart(this.a8Id);
      if (this.a8TextId > 0)
        this.RemoveSubPart(this.a8TextId);
      if (this.c1id > 0)
        this.RemoveSubPart(this.c1id);
      if (this.OffPicId > 0)
        this.RemoveSubPart(this.OffPicId);
      if (this.c2id > 0)
        this.RemoveSubPart(this.c2id);
      if (this.c2textid > 0)
        this.RemoveSubPart(this.c2textid);
      if (this.killnameid > 0)
        this.RemoveSubPart(this.killnameid);
      if (this.addnameid > 0)
        this.RemoveSubPart(this.addnameid);
      if (this.killname2id > 0)
        this.RemoveSubPart(this.killname2id);
      if (this.addname2id > 0)
        this.RemoveSubPart(this.addname2id);
      if (this.BRemovepeopleId > 0)
        this.RemoveSubPart(this.BRemovepeopleId);
      if (this.BRemovepeopleTextId > 0)
        this.RemoveSubPart(this.BRemovepeopleTextId);
      if (this.firstListId > 0)
        this.RemoveSubPart(this.firstListId);
      if (this.lastListId > 0)
        this.RemoveSubPart(this.lastListId);
      if (this.CombatListId > 0)
        this.RemoveSubPart(this.CombatListId);
      if (this.addtext1 > 0)
        this.RemoveSubPart(this.addtext1);
      if (this.addtext2 > 0)
        this.RemoveSubPart(this.addtext2);
      if (this.x1id > 0)
        this.RemoveSubPart(this.x1id);
      if (this.x2id > 0)
        this.RemoveSubPart(this.x2id);
      if (this.x3id > 0)
        this.RemoveSubPart(this.x3id);
      if (this.x4id > 0)
        this.RemoveSubPart(this.x4id);
      if (this.x5id > 0)
        this.RemoveSubPart(this.x5id);
      if (this.x6id > 0)
        this.RemoveSubPart(this.x6id);
      if (this.x7id > 0)
        this.RemoveSubPart(this.x7id);
      if (this.x8id > 0)
        this.RemoveSubPart(this.x8id);
      if (this.x9id > 0)
        this.RemoveSubPart(this.x9id);
      if (this.x10id > 0)
        this.RemoveSubPart(this.x10id);
      if (this.x11id > 0)
        this.RemoveSubPart(this.x11id);
      if (this.x12id > 0)
        this.RemoveSubPart(this.x12id);
      if (this.peopleNr <= -1)
        return;
      this.ss = "Click to change the name of this people";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BNameId = this.AddSubPart(ref tsubpart, 500, 50, 32, 16, 1);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Name: " + this.game.Data.PeopleObj[this.peopleNr].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.BNameTextId = this.AddSubPart(ref tsubpart1, 540, 49, 200, 20, 0);
      this.ss = "Click to change the colour used to paint counters with these people in them. -1,-1,-1= dont use special colour. Using this, instead of regcol makes the graphics slightly slower.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B1Id = this.AddSubPart(ref tsubpart2, 800, 50, 32, 16, 1);
      }
      SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("Colour: " + Conversion.Str((object) this.game.Data.PeopleObj[this.peopleNr].Red) + "," + Conversion.Str((object) this.game.Data.PeopleObj[this.peopleNr].Green) + "," + Conversion.Str((object) this.game.Data.PeopleObj[this.peopleNr].Blue), new Font("Times New Roman", 12f), 200, 20, false);
      this.B1TextId = this.AddSubPart(ref tsubpart3, 840, 49, 200, 20, 0);
      this.ss = "Cancel the using of a special overruling colour for this people.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.B2Id = this.AddSubPart(ref tsubpart4, 800, 70, 32, 16, 1);
      }
      SubPartClass tsubpart5 = (SubPartClass) new TextPartClass("Kill own people colour", new Font("Times New Roman", 12f), 200, 20, false);
      this.B2TextId = this.AddSubPart(ref tsubpart5, 840, 69, 200, 20, 0);
      this.ss = "Select Library for people";
      string str1 = "";
      if (this.game.Data.PeopleObj[this.peopleNr].LibId.libSlot > -1)
        str1 += this.game.Data.PeopleObj[this.peopleNr].LibId.libSlot.ToString();
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart6 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B4Id = this.AddSubPart(ref tsubpart6, 800, 110, 32, 16, 1);
      }
      SubPartClass tsubpart7 = (SubPartClass) new TextPartClass("Set Library (" + str1 + ")", new Font("Times New Roman", 12f), 200, 20, false);
      this.B4TextId = this.AddSubPart(ref tsubpart7, 840, 109, 200, 20, 0);
      this.ss = "EXPERT USE ONLY - ";
      string str2 = "";
      if (this.game.Data.PeopleObj[this.peopleNr].LibId.libSlot > -1)
        str2 += this.game.Data.PeopleObj[this.peopleNr].LibId.id.ToString();
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B4bId = this.AddSubPart(ref tsubpart8, 800, 130, 32, 16, 1);
      }
      SubPartClass tsubpart9 = (SubPartClass) new TextPartClass("Set Library ID (" + str2 + ")", new Font("Times New Roman", 12f), 200, 20, false);
      this.B4bTextId = this.AddSubPart(ref tsubpart9, 840, 129, 200, 20, 0);
      this.ss = "EXPERT USE ONLY - ";
      string str3 = "" + this.game.Data.PeopleObj[this.peopleNr].id.ToString();
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart10 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B4cId = this.AddSubPart(ref tsubpart10, 800, 150, 32, 16, 1);
      }
      SubPartClass tsubpart11 = (SubPartClass) new TextPartClass("Set ID (" + str3 + ")", new Font("Times New Roman", 12f), 200, 20, false);
      this.B4cTextId = this.AddSubPart(ref tsubpart11, 840, 149, 200, 20, 0);
      if (this.peopleNr < this.game.Data.PeopleCounter)
      {
        SubPartClass tsubpart12 = (SubPartClass) new ButtonPartClass(this.game.BUTTONDOWN, tDescript: "Move down list");
        this.highId = this.AddSubPart(ref tsubpart12, 750, 130, 32, 16, 1);
      }
      if (this.peopleNr > 0)
      {
        SubPartClass tsubpart13 = (SubPartClass) new ButtonPartClass(this.game.BUTTONUP, tDescript: "Move Up List");
        this.lowId = this.AddSubPart(ref tsubpart13, 750, 110, 32, 16, 1);
      }
      this.ss = "Click to change the peoplegroup this people belong too";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart14 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B3Id = this.AddSubPart(ref tsubpart14, 500, 90, 32, 16, 1);
      }
      SubPartClass tsubpart15 = (SubPartClass) new TextPartClass("PeopleGroup: " + this.game.Data.TempString[200 + this.game.Data.PeopleObj[this.peopleNr].PeopleGroup] + " (" + Conversion.Str((object) this.game.Data.PeopleObj[this.peopleNr].PeopleGroup) + ")", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B3TextId = this.AddSubPart(ref tsubpart15, 540, 89, 200, 20, 0);
      this.ss = "Click to change the break percentage of troops of this people";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b25id = this.AddSubPart(ref tsubpart15, 500, 130, 32, 16, 1);
      }
      tsubpart15 = (SubPartClass) new TextPartClass("BreakAt: " + Conversion.Str((object) this.game.Data.PeopleObj[this.peopleNr].BreakAt), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b25textid = this.AddSubPart(ref tsubpart15, 540, 129, 200, 20, 0);
      this.ss = "Click to change the People Gfx for this People (for sideways gfx)";
      tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.Data.PeopleObj[this.peopleNr].SidewaysSpriteID, tDescript: this.ss);
      this.x1id = this.AddSubPart(ref tsubpart15, 570, 180, 140, 80, 1);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.x2id = this.AddSubPart(ref tsubpart15, 530, 180, 32, 16, 1);
      }
      this.ss = "Click to change the overrule symbol for this People (national sprite)";
      tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.Data.PeopleObj[this.peopleNr].NationalSpriteID, tDescript: this.ss);
      this.x3id = this.AddSubPart(ref tsubpart15, 770, 180, 37, 37, 1);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.x4id = this.AddSubPart(ref tsubpart15, 910, 180, 32, 16, 1);
      }
      if (this.game.Data.Product >= 7)
      {
        this.ss = "Click to change the People Gfx for this People (for sideways gfx)";
        tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.Data.PeopleObj[this.peopleNr].SidewaysSpriteID, tDescript: this.ss);
        this.x5id = this.AddSubPart(ref tsubpart15, 970, 180, 140, 80, 1);
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.x6id = this.AddSubPart(ref tsubpart15, 930, 180, 32, 16, 1);
        }
        this.ss = "Click to change the People Gfx for this People (for sideways gfx)";
        tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.Data.PeopleObj[this.peopleNr].SidewaysSpriteID, tDescript: this.ss);
        this.x7id = this.AddSubPart(ref tsubpart15, 1170, 180, 140, 80, 1);
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.x8id = this.AddSubPart(ref tsubpart15, 1130, 180, 32, 16, 1);
        }
        this.ss = "Click to change the People Gfx for this People (for sideways gfx)";
        tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.Data.PeopleObj[this.peopleNr].SidewaysSpriteID, tDescript: this.ss);
        this.x9id = this.AddSubPart(ref tsubpart15, 1370, 180, 140, 80, 1);
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
          this.x10id = this.AddSubPart(ref tsubpart15, 1330, 180, 32, 16, 1);
        }
      }
      if (this.game.Data.PeopleCounter > 0)
      {
        this.ss = "Click to remove this people";
        if (Strings.Len(this.game.Data.MasterFile) == 0)
        {
          tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
          this.BRemovepeopleId = this.AddSubPart(ref tsubpart15, 10, 290, 32, 16, 1);
        }
        tsubpart15 = (SubPartClass) new TextPartClass("remove a People", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.BRemovepeopleTextId = this.AddSubPart(ref tsubpart15, 40, 289, 300, 20, 0);
      }
      this.CombatListObj = new ListClass();
      if (this.detailnr < -1 | this.detailnr > 99)
        this.detailnr = -1;
      int index = 0;
      do
      {
        string str4 = "";
        string str5 = Conversion.Str((object) index) + ") " + this.game.Data.TempString[index + 200];
        if (Strings.Len(str5) > 23)
          str5 = Strings.Left(str5, 23);
        string str6 = str4 + str5 + Strings.Space(25 - Strings.Len(str5));
        string Expression1 = "BMr=" + Strings.Trim(Conversion.Str((object) this.game.Data.PeopleObj[this.peopleNr].BaseMorale[index]));
        string str7 = str6 + Expression1 + Strings.Space(15 - Strings.Len(Expression1));
        string Expression2 = "BFr=" + Strings.Trim(Conversion.Str((object) this.game.Data.PeopleObj[this.peopleNr].BattleForMod[index]));
        string str8 = str7 + Expression2 + Strings.Space(15 - Strings.Len(Expression2));
        string Expression3 = "BVS=" + Strings.Trim(Conversion.Str((object) this.game.Data.PeopleObj[this.peopleNr].BattleVSMod[index]));
        this.CombatListObj.add(str8 + Expression3 + Strings.Space(15 - Strings.Len(Expression3)), index);
        ++index;
      }
      while (index <= 99);
      ListClass combatListObj = this.CombatListObj;
      int detailnr = this.detailnr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      tsubpart15 = (SubPartClass) new ListSubPartClass(combatListObj, 12, 580, detailnr, game, true, "Owned by Peoplegroup modifiers", tbackbitmap: (ref local1), bbx: 10, bby: 340, overruleFont: (ref local2));
      this.CombatListId = this.AddSubPart(ref tsubpart15, 10, 340, 580, 240, 0);
      if (this.detailnr <= -1)
        return;
      this.maketabsheetnr4b();
    }

    public void maketabsheetnr4b()
    {
      this.ss = "Click to set basemorale this people have if ruled by a regime of selected peoplegroup";
      string str1 = Strings.Trim(Conversion.Str((object) this.game.Data.PeopleObj[this.peopleNr].BaseMorale[this.detailnr]));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b18id = this.AddSubPart(ref tsubpart, 610, 340, 32, 16, 1);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("BaseMorale: " + str1, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b18textid = this.AddSubPart(ref tsubpart1, 650, 339, 400, 20, 0);
      this.ss = "Click to set combat modifier this people have if ruled by a regime of selected peoplegroup. 1=no mod. 1.5=50% better. 0.5=50% worse";
      string str2 = Strings.Trim(Conversion.Str((object) this.game.Data.PeopleObj[this.peopleNr].BattleForMod[this.detailnr]));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b20id = this.AddSubPart(ref tsubpart2, 610, 380, 32, 16, 1);
      }
      SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("BattleFor: " + str2, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b20textid = this.AddSubPart(ref tsubpart3, 650, 379, 400, 20, 0);
      this.ss = "Click to set combat modifier this people have if they fight against a subformation of selected peoplegroup. 1=no mod. 1.5=50% better. 0.5=50% worse";
      string str3 = Strings.Trim(Conversion.Str((object) this.game.Data.PeopleObj[this.peopleNr].BattleVSMod[this.detailnr]));
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.b21id = this.AddSubPart(ref tsubpart4, 610, 400, 32, 16, 1);
      }
      SubPartClass tsubpart5 = (SubPartClass) new TextPartClass("BattleVS: " + str3, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.b21textid = this.AddSubPart(ref tsubpart5, 650, 399, 400, 20, 0);
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
                this.LibNr = num2;
                this.peopleNr = -1;
                this.MakepeopleListGUI(this.peopleNr);
              }
              else if (num2 == -2)
              {
                this.LibNr = -1;
                this.peopleNr = -1;
                this.MakepeopleListGUI(this.peopleNr);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.peopleListId)
            {
              int num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num3 > -1)
              {
                this.peopleNr = num3;
                this.MakepeopleTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.firstListId)
            {
              int num4 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num4 > -1)
              {
                this.firstdetail = num4;
                this.MakepeopleTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.x2id)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp|Jpg|*.jpg", "Give File Name For sideways gfx", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.PeopleObj[this.peopleNr].ReplaceSidewaysSprite(filename);
              }
              else
              {
                int num5 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.x4id)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp|Jpg|*.jpg", "Give File Name For symbol overrule gfx", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.PeopleObj[this.peopleNr].ReplaceNationalSprite(filename);
              }
              else
              {
                int num6 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.x6id)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp|Jpg|*.jpg", "Give File Name For sideways gfx 2", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.PeopleObj[this.peopleNr].ReplaceSidewaysSprite2(filename);
              }
              else
              {
                int num7 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.x8id)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp|Jpg|*.jpg", "Give File Name For sideways gfx 3", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.PeopleObj[this.peopleNr].ReplaceSidewaysSprite3(filename);
              }
              else
              {
                int num8 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.x10id)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp|Jpg|*.jpg", "Give File Name For sideways gfx 4", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.PeopleObj[this.peopleNr].ReplaceSidewaysSprite4(filename);
              }
              else
              {
                int num9 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.lastListId)
            {
              int num10 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num10 > -1)
              {
                this.lastdetail = num10;
                this.MakepeopleTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddpeopleId)
            {
              this.game.Data.AddPeople();
              this.game.Data.PeopleObj[this.game.Data.PeopleCounter].LibId.libSlot = this.LibNr;
              if (this.peopleNr > -1 & Interaction.MsgBox((object) "Insert it in current selected people slot?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
              {
                PeopleClass peopleClass = this.game.Data.PeopleObj[this.game.Data.PeopleCounter];
                int peopleCounter = this.game.Data.PeopleCounter;
                int num11 = this.peopleNr + 1;
                for (int Newnr = peopleCounter; Newnr >= num11; Newnr += -1)
                {
                  this.game.Data.PeopleObj[Newnr] = this.game.Data.PeopleObj[Newnr - 1];
                  this.game.Data.ChangePeopleNr(Newnr - 1, Newnr);
                }
                this.game.Data.PeopleObj[this.peopleNr] = peopleClass;
              }
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BNameId)
            {
              this.game.Data.PeopleObj[this.peopleNr].Name = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest");
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B1Id)
            {
              ColorDialog colorDialog = new ColorDialog();
              colorDialog.Color = this.game.Data.PeopleObj[this.peopleNr].Red <= -1 ? Color.FromArgb((int) byte.MaxValue, 128, 128, 128) : Color.FromArgb((int) byte.MaxValue, this.game.Data.PeopleObj[this.peopleNr].Red, this.game.Data.PeopleObj[this.peopleNr].Green, this.game.Data.PeopleObj[this.peopleNr].Blue);
              if (colorDialog.ShowDialog() == DialogResult.OK)
              {
                PeopleClass peopleClass1 = this.game.Data.PeopleObj[this.peopleNr];
                Color color = colorDialog.Color;
                int r = (int) color.R;
                peopleClass1.Red = r;
                PeopleClass peopleClass2 = this.game.Data.PeopleObj[this.peopleNr];
                color = colorDialog.Color;
                int g = (int) color.G;
                peopleClass2.Green = g;
                PeopleClass peopleClass3 = this.game.Data.PeopleObj[this.peopleNr];
                color = colorDialog.Color;
                int b1 = (int) color.B;
                peopleClass3.Blue = b1;
              }
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B2Id)
            {
              this.game.Data.PeopleObj[this.peopleNr].Red = -1;
              this.game.Data.PeopleObj[this.peopleNr].Green = -1;
              this.game.Data.PeopleObj[this.peopleNr].Blue = -1;
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B4Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 96, this.peopleNr);
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.highId)
            {
              this.game.EditObj.UnitSelected = -1;
              this.game.Data.MovePeopleHigher(this.peopleNr);
              ++this.peopleNr;
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.lowId)
            {
              this.game.EditObj.UnitSelected = -1;
              this.game.Data.MovePeopleLower(this.peopleNr);
              --this.peopleNr;
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B3Id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 13, this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BRemovepeopleId)
            {
              this.game.Data.RemovePeople(this.peopleNr);
              this.MakepeopleListGUI(-1);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.CombatListId)
            {
              int num12 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num12 > -1)
              {
                this.detailnr = num12;
                this.MakepeopleListGUI(this.peopleNr);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b23id)
            {
              new Form2((Form) this.formref).Initialize(this.game.Data, 11, this.peopleNr);
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b18id)
            {
              int num13 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new base morale.", "Shadow Empire : Planetary Conquest")));
              if (num13 < 0 | num13 > 100)
              {
                int num14 = (int) Interaction.MsgBox((object) "Between 0 and 100 please. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.PeopleObj[this.peopleNr].BaseMorale[this.detailnr] = num13;
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B4bId)
            {
              this.game.Data.PeopleObj[this.peopleNr].LibId.id = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new library ID.", "Shadow Empire : Planetary Conquest")));
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B4cId)
            {
              int num15 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new ID.", "Shadow Empire : Planetary Conquest")));
              this.game.Data.PeopleObj[this.peopleNr].id = num15;
              if (num15 > this.game.Data.PeopleIdCounter)
                this.game.Data.PeopleIdCounter = num15;
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.a6Id)
            {
              int num16 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new extra graphic (-1=none).", "Shadow Empire : Planetary Conquest")));
              if (num16 < -1 | num16 > 100)
              {
                int num17 = (int) Interaction.MsgBox((object) "Between -1 and 100 please. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.PeopleObj[this.peopleNr].ExtraGraphicUse = num16;
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.z1id)
            {
              int num18 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give regime# to use.", "Shadow Empire : Planetary Conquest")));
              if (num18 < 0 | num18 > this.game.Data.RegimeCounter)
                return windowReturnClass;
              int num19 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give people# to use.", "Shadow Empire : Planetary Conquest")));
              if (num19 < 0 | num19 > this.game.Data.PeopleCounter)
                return windowReturnClass;
              int unitCounter = this.game.Data.UnitCounter;
              for (int index2 = 0; index2 <= unitCounter; ++index2)
              {
                if (this.game.Data.UnitObj[index2].PreDef == -1 & this.game.Data.UnitObj[index2].Regime == num18)
                {
                  int sfCount = this.game.Data.UnitObj[index2].SFCount;
                  for (int index3 = 0; index3 <= sfCount; ++index3)
                    this.game.Data.SFObj[this.game.Data.UnitObj[index2].SFList[index3]].People = num19;
                }
              }
              int num20 = (int) Interaction.MsgBox((object) "Done! ", Title: ((object) "Shadow Empire : Planetary Conquest"));
              return windowReturnClass;
            }
            if (num1 == this.a7Id)
            {
              int num21 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new SFType # to use.", "Shadow Empire : Planetary Conquest")));
              if (num21 < -1 | num21 > this.game.Data.SFTypeCounter)
              {
                int num22 = (int) Interaction.MsgBox((object) "Between -1 and SFTypeCounter please. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.PeopleObj[this.peopleNr].SFIll = num21;
              this.game.Data.PeopleObj[this.peopleNr].SFExtra = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give extra graphic # to use.", "Shadow Empire : Planetary Conquest")));
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b25id)
            {
              int num23 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new break At %. 0=never break. 50=chance starts from half unit lost. 100=immediate chance.", "Shadow Empire : Planetary Conquest")));
              if (num23 < 0 | num23 > 100)
              {
                int num24 = (int) Interaction.MsgBox((object) "Between 0 and 100 please. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.PeopleObj[this.peopleNr].BreakAt = num23;
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b22id)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 14, this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b19id)
            {
              float num25 = (float) Conversion.Val(Interaction.InputBox("Give Prod Mod.", "Shadow Empire : Planetary Conquest"));
              if ((double) num25 < 0.0 | (double) num25 > 10.0)
              {
                int num26 = (int) Interaction.MsgBox((object) "Between 0 and 10 please. You can use 0.51 or 4.87 like values.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.PeopleObj[this.peopleNr].ProdMod[this.detailnr] = num25;
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b28id)
            {
              float num27 = (float) Conversion.Val(Interaction.InputBox("Give Prod Mod 4.", "Shadow Empire : Planetary Conquest"));
              if ((double) num27 < 0.0 | (double) num27 > 10.0)
              {
                int num28 = (int) Interaction.MsgBox((object) "Between 0 and 10 please. You can use 0.51 or 4.87 like values.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.PeopleObj[this.peopleNr].ProdMod4[this.detailnr] = num27;
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b27id)
            {
              float num29 = (float) Conversion.Val(Interaction.InputBox("Give Prod Mod 3.", "Shadow Empire : Planetary Conquest"));
              if ((double) num29 < 0.0 | (double) num29 > 10.0)
              {
                int num30 = (int) Interaction.MsgBox((object) "Between 0 and 10 please. You can use 0.51 or 4.87 like values.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.PeopleObj[this.peopleNr].ProdMod3[this.detailnr] = num29;
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b26id)
            {
              float num31 = (float) Conversion.Val(Interaction.InputBox("Give Prod Mod 2.", "Shadow Empire : Planetary Conquest"));
              if ((double) num31 < 0.0 | (double) num31 > 10.0)
              {
                int num32 = (int) Interaction.MsgBox((object) "Between 0 and 10 please. You can use 0.51 or 4.87 like values.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.PeopleObj[this.peopleNr].ProdMod2[this.detailnr] = num31;
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b20id)
            {
              float num33 = (float) Conversion.Val(Interaction.InputBox("Give Battle For Mod (normal=1).", "Shadow Empire : Planetary Conquest"));
              if ((double) num33 < 0.0 | (double) num33 > 10.0)
              {
                int num34 = (int) Interaction.MsgBox((object) "Between 0 and 10 please. You can use 0.51 or 4.87 like values.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.PeopleObj[this.peopleNr].BattleForMod[this.detailnr] = num33;
              this.MakepeopleListGUI(this.peopleNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b21id)
            {
              float num35 = (float) Conversion.Val(Interaction.InputBox("Give Battle VS Mod (normal=1).", "Shadow Empire : Planetary Conquest"));
              if ((double) num35 < 0.0 | (double) num35 > 10.0)
              {
                int num36 = (int) Interaction.MsgBox((object) "Between 0 and 10 please. You can use 0.51 or 4.87 like values.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
                this.game.Data.PeopleObj[this.peopleNr].BattleVSMod[this.detailnr] = num35;
              this.MakepeopleListGUI(this.peopleNr);
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
