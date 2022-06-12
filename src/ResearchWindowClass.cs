// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ResearchWindowClass
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
  public class ResearchWindowClass : WindowClass
  {
    private int ResearchListId;
    private ListClass ResearchListObj;
    private int BAddResearchId;
    private int BAddResearchTextId;
    private int BNameId;
    private int BNameTextId;
    private int B1Id;
    private int B1TextId;
    private int B2Id;
    private int B2TextId;
    private int B3Id;
    private int B3TextId;
    private int BRemoveResearchId;
    private int BRemoveResearchTextId;
    private int BRemoveResearchId2;
    private int BRemoveResearchTextId2;
    private int B4Id;
    private int B4TextId;
    private int B5Id;
    private int B5TextId;
    private int B6Id;
    private int B6TextId;
    private int B7Id;
    private int B7TextId;
    private int B8Id;
    private int B8TextId;
    private int B9Id;
    private int B9TextId;
    private int B10Id;
    private int B10TextId;
    private int B11Id;
    private int B11TextId;
    private int PGListId;
    private ListClass PGListObj;
    private int B3bId;
    private int B3bTextId;
    private int ResearchNr;
    private int detailnr;
    private string ss;

    public ResearchWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Decision Room")
    {
      this.ResearchNr = -1;
      this.detailnr = -1;
      this.MakeResearchListGUI(-1);
    }

    public override void DoRefresh() => this.MakeResearchTypeItemGUI();

    private void MakeResearchListGUI(int tResearchnr)
    {
      if (this.ResearchListId > 0)
        this.RemoveSubPart(this.ResearchListId);
      SubPartClass tsubpart;
      if (this.game.Data.ResearchCounter > -1)
      {
        this.ResearchListObj = new ListClass();
        int researchCounter = this.game.Data.ResearchCounter;
        for (int index = 0; index <= researchCounter; ++index)
          this.ResearchListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.ResearchObj[index].Name, index);
        ListClass researchListObj = this.ResearchListObj;
        int tlistselect = tResearchnr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        tsubpart = (SubPartClass) new ListSubPartClass(researchListObj, 9, 200, tlistselect, game, tHeader: "Researchfields", tbackbitmap: (ref local1), bbx: 10, bby: 50, overruleFont: (ref local2));
        this.ResearchListId = this.AddSubPart(ref tsubpart, 10, 50, 200, 192, 0);
        this.ResearchNr = tResearchnr;
        this.MakeResearchTypeItemGUI();
      }
      else
      {
        this.ResearchNr = tResearchnr;
        this.MakeResearchTypeItemGUI();
      }
      if (this.BAddResearchId > 0)
        this.RemoveSubPart(this.BAddResearchId);
      if (this.BAddResearchTextId > 0)
        this.RemoveSubPart(this.BAddResearchTextId);
      this.ss = "Click to add a researchfield";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
        this.BAddResearchId = this.AddSubPart(ref tsubpart, 10, 270, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new TextPartClass("Add a Research", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.BAddResearchTextId = this.AddSubPart(ref tsubpart, 50, 269, 300, 20, 0);
      }
      if (this.B7Id > 0)
        this.RemoveSubPart(this.B7Id);
      if (this.B7TextId > 0)
        this.RemoveSubPart(this.B7TextId);
      this.ss = "Clicking this button sets cost for all pplgroups equal to that of the first peoplegroup.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONYELLOW, tDescript: this.ss);
        this.B7Id = this.AddSubPart(ref tsubpart, 10, 310, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      tsubpart = (SubPartClass) new TextPartClass("Set all to pplgroup0", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.B7TextId = this.AddSubPart(ref tsubpart, 50, 309, 300, 20, 0);
    }

    private void MakeResearchTypeItemGUI()
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
      if (this.B3bId > 0)
        this.RemoveSubPart(this.B3bId);
      if (this.B3bTextId > 0)
        this.RemoveSubPart(this.B3bTextId);
      if (this.PGListId > 0)
        this.RemoveSubPart(this.PGListId);
      if (this.B4Id > 0)
        this.RemoveSubPart(this.B4Id);
      if (this.B4TextId > 0)
        this.RemoveSubPart(this.B4TextId);
      if (this.B5Id > 0)
        this.RemoveSubPart(this.B5Id);
      if (this.B5TextId > 0)
        this.RemoveSubPart(this.B5TextId);
      if (this.B6Id > 0)
        this.RemoveSubPart(this.B6Id);
      if (this.B6TextId > 0)
        this.RemoveSubPart(this.B6TextId);
      if (this.B7Id > 0)
        this.RemoveSubPart(this.B7Id);
      if (this.B7TextId > 0)
        this.RemoveSubPart(this.B7TextId);
      if (this.B8Id > 0)
        this.RemoveSubPart(this.B8Id);
      if (this.B8TextId > 0)
        this.RemoveSubPart(this.B8TextId);
      if (this.B9Id > 0)
        this.RemoveSubPart(this.B9Id);
      if (this.B9TextId > 0)
        this.RemoveSubPart(this.B9TextId);
      if (this.B10Id > 0)
        this.RemoveSubPart(this.B10Id);
      if (this.B10TextId > 0)
        this.RemoveSubPart(this.B10TextId);
      if (this.B11Id > 0)
        this.RemoveSubPart(this.B11Id);
      if (this.B11TextId > 0)
        this.RemoveSubPart(this.B11TextId);
      if (this.BRemoveResearchId > 0)
        this.RemoveSubPart(this.BRemoveResearchId);
      if (this.BRemoveResearchTextId > 0)
        this.RemoveSubPart(this.BRemoveResearchTextId);
      if (this.BRemoveResearchId2 > 0)
        this.RemoveSubPart(this.BRemoveResearchId2);
      if (this.BRemoveResearchTextId2 > 0)
        this.RemoveSubPart(this.BRemoveResearchTextId2);
      this.ss = "Clicking this button sets cost for all pplgroups equal to that of the first peoplegroup.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B7Id = this.AddSubPart(ref tsubpart, 10, 310, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("Set all to pplgroup0", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.B7TextId = this.AddSubPart(ref tsubpart, 50, 309, 300, 20, 0);
      }
      if (this.ResearchNr <= -1)
        return;
      this.ss = "Click to change the name of the researchfield";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BNameId = this.AddSubPart(ref tsubpart, 370, 50, 32, 16, 1);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Name: " + this.game.Data.ResearchObj[this.ResearchNr].Name, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.BNameTextId = this.AddSubPart(ref tsubpart1, 410, 49, 400, 20, 0);
      this.ss = "Click to give a short one sentence description of this researchfield";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B1Id = this.AddSubPart(ref tsubpart2, 370, 70, 32, 16, 1);
      }
      SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("Text: " + this.game.Data.ResearchObj[this.ResearchNr].Text, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B1TextId = this.AddSubPart(ref tsubpart3, 410, 69, 400, 20, 0);
      this.ss = "Click to assign the picture of a sftype to this researchfield. -1=none. This is also used by the AI for research directions!";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B2Id = this.AddSubPart(ref tsubpart4, 370, 90, 32, 16, 1);
      }
      if (this.game.Data.ResearchObj[this.ResearchNr].SFTypePic > -1)
      {
        SubPartClass tsubpart5 = (SubPartClass) new TextPartClass("SFTypeNr Sprite: " + this.game.Data.SFTypeObj[this.game.Data.ResearchObj[this.ResearchNr].SFTypePic].Name + " (" + Conversion.Str((object) this.game.Data.ResearchObj[this.ResearchNr].SFTypePic) + ")", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B2TextId = this.AddSubPart(ref tsubpart5, 410, 89, 400, 20, 0);
      }
      else
      {
        SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("SFTypeNr Sprite: -1", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B2TextId = this.AddSubPart(ref tsubpart6, 410, 89, 400, 20, 0);
      }
      this.ss = "Click to set which other researchfield is a prerequisite for this one";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B4Id = this.AddSubPart(ref tsubpart7, 370, 110, 32, 16, 1);
      }
      SubPartClass tsubpart8 = (SubPartClass) new TextPartClass("PreReq: " + Conversion.Str((object) this.game.Data.ResearchObj[this.ResearchNr].PreReq), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B4TextId = this.AddSubPart(ref tsubpart8, 410, 109, 400, 20, 0);
      this.ss = "Click to set which other researchfield is a prerequisite for this one";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B5Id = this.AddSubPart(ref tsubpart8, 370, 130, 32, 16, 1);
      }
      tsubpart8 = (SubPartClass) new TextPartClass("PreReq2: " + Conversion.Str((object) this.game.Data.ResearchObj[this.ResearchNr].PreReq2), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B5TextId = this.AddSubPart(ref tsubpart8, 410, 129, 400, 20, 0);
      this.ss = "Click to set which researchfield is blocked once this researchfield is bought by a regime. -1=none";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B6Id = this.AddSubPart(ref tsubpart8, 370, 150, 32, 16, 1);
      }
      tsubpart8 = (SubPartClass) new TextPartClass("Blocks: " + Conversion.Str((object) this.game.Data.ResearchObj[this.ResearchNr].Blocks), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B6TextId = this.AddSubPart(ref tsubpart8, 410, 149, 400, 20, 0);
      this.ss = "Click to set tech level (used in regime menu and by random game). -1/0 = no tech level assigned.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B9Id = this.AddSubPart(ref tsubpart8, 370, 170, 32, 16, 1);
      }
      tsubpart8 = (SubPartClass) new TextPartClass("TechLevel: " + Conversion.Str((object) this.game.Data.ResearchObj[this.ResearchNr].TechLevel), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B9TextId = this.AddSubPart(ref tsubpart8, 410, 169, 400, 20, 0);
      this.ss = "Click to set cost type. -1=PP =>0 is the regimevar specified";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B10Id = this.AddSubPart(ref tsubpart8, 370, 190, 32, 16, 1);
      }
      tsubpart8 = (SubPartClass) new TextPartClass("CostType: " + Conversion.Str((object) this.game.Data.ResearchObj[this.ResearchNr].CostType), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B10TextId = this.AddSubPart(ref tsubpart8, 410, 189, 400, 20, 0);
      this.ss = "Click to remove this researchfield";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.BRemoveResearchId = this.AddSubPart(ref tsubpart8, 10, 290, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart8 = (SubPartClass) new TextPartClass("Remove this Research", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BRemoveResearchTextId = this.AddSubPart(ref tsubpart8, 50, 289, 200, 20, 0);
      }
      this.ss = "Click to remove ALL researchfield";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart8 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.BRemoveResearchId2 = this.AddSubPart(ref tsubpart8, 10, 330, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart8 = (SubPartClass) new TextPartClass("Remove ALL Research", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BRemoveResearchTextId2 = this.AddSubPart(ref tsubpart8, 50, 329, 200, 20, 0);
      }
      this.PGListObj = new ListClass();
      if (this.detailnr < -1 | this.detailnr > 99)
        this.detailnr = -1;
      int index = 0;
      do
      {
        this.PGListObj.add(Conversion.Str((object) index) + ") " + this.game.Data.TempString[index + 200] + " = " + Conversion.Str((object) this.game.Data.ResearchObj[this.ResearchNr].PointCost[index]), index);
        ++index;
      }
      while (index <= 99);
      ListClass pgListObj = this.PGListObj;
      int detailnr = this.detailnr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      tsubpart8 = (SubPartClass) new ListSubPartClass(pgListObj, 6, 200, detailnr, game, tHeader: "Research Cost", tbackbitmap: (ref local1), bbx: 10, bby: 350, overruleFont: (ref local2));
      this.PGListId = this.AddSubPart(ref tsubpart8, 10, 350, 200, 144, 0);
      this.maketabsheet3b();
    }

    private void maketabsheet3b()
    {
      if (this.detailnr <= -1)
        return;
      if (this.B3bId > 0)
        this.RemoveSubPart(this.B3bId);
      if (this.B3bTextId > 0)
        this.RemoveSubPart(this.B3bTextId);
      this.ss = "Click to change the cost in pol.pts for selected peoplegroup to research this field. -1 = impossible to research this for this peoplegroup";
      if (Strings.Len(this.game.Data.MasterFile) == 0 | !this.game.Data.MasterfileReadPeople)
      {
        SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B3bId = this.AddSubPart(ref tsubpart, 215, 350, 32, 16, 1);
      }
      if (!(Strings.Len(this.game.Data.MasterFile) == 0 | !this.game.Data.MasterfileReadPeople))
        return;
      SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("Change", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 100, 20, false, tDescript: this.ss);
      this.B3bTextId = this.AddSubPart(ref tsubpart1, 250, 349, 200, 20, 0);
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
            if (num1 == this.ResearchListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.ResearchNr = num2;
                this.MakeResearchTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddResearchId)
            {
              this.game.Data.AddResearch();
              this.MakeResearchListGUI(this.ResearchNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B7Id)
            {
              string str = Interaction.InputBox("We will set all to ppg0 pp cost, with the following mod (1.0 is none)", "Shadow Empire : Planetary Conquest", "1");
              if (Operators.CompareString(str, "", false) != 0)
              {
                float num3 = (float) Conversion.Val(str);
                int researchCounter = this.game.Data.ResearchCounter;
                for (int index2 = 0; index2 <= researchCounter; ++index2)
                {
                  int num4 = this.game.Data.ResearchObj[index2].PointCost[0];
                  int index3 = 1;
                  do
                  {
                    this.game.Data.ResearchObj[index2].PointCost[index3] = (int) Math.Round((double) Conversion.Int((float) num4 * num3));
                    ++index3;
                  }
                  while (index3 <= 99);
                }
                this.MakeResearchListGUI(this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else
            {
              if (num1 == this.BNameId)
              {
                this.game.Data.ResearchObj[this.ResearchNr].Name = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest", this.game.Data.ResearchObj[this.ResearchNr].Name);
                this.MakeResearchListGUI(this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B1Id)
              {
                new Form2((Form) this.formref).Initialize(this.game.Data, 5, this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B4Id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 22, this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B5Id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 23, this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B6Id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 24, this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B9Id)
              {
                int num5 = (int) Math.Round(Conversion.Val(Interaction.InputBox("TechLevel (-1 = no tech level..no problem) .. ", "Shadow Empire : Planetary Conquest")));
                if (num5 >= -1 & num5 <= 999)
                {
                  this.game.Data.ResearchObj[this.ResearchNr].TechLevel = num5;
                }
                else
                {
                  int num6 = (int) Interaction.MsgBox((object) "number between -1 and 999 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeResearchListGUI(this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B10Id)
              {
                int num7 = (int) Math.Round(Conversion.Val(Interaction.InputBox("CostType... -1=pp >=0 is regimevar ", "Shadow Empire : Planetary Conquest")));
                if (num7 >= -1 & num7 <= 499)
                {
                  this.game.Data.ResearchObj[this.ResearchNr].CostType = num7;
                }
                else
                {
                  int num8 = (int) Interaction.MsgBox((object) "number between -1 and 499 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeResearchListGUI(this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B11Id)
              {
                int num9 = (int) Math.Round(Conversion.Val(Interaction.InputBox("UpgradeCost in prodpoints for improvement.. -1=not possible ", "Shadow Empire : Planetary Conquest")));
                if (num9 >= -1 & num9 <= 999999)
                {
                  this.game.Data.ResearchObj[this.ResearchNr].UpgradeCost = num9;
                }
                else
                {
                  int num10 = (int) Interaction.MsgBox((object) "number between -1 and 999999 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.MakeResearchListGUI(this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B2Id)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 21, this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BRemoveResearchId)
              {
                this.game.Data.RemoveResearch(this.ResearchNr);
                this.MakeResearchListGUI(-1);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BRemoveResearchId2)
              {
                for (int researchCounter = this.game.Data.ResearchCounter; researchCounter >= 0; researchCounter += -1)
                  this.game.Data.RemoveResearch(researchCounter);
                this.MakeResearchListGUI(-1);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.PGListId)
              {
                int num11 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num11 > -1)
                {
                  this.detailnr = num11;
                  this.MakeResearchTypeItemGUI();
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B3bId)
              {
                int num12 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new point cost for this peoplegroup 0-9999 (-1 or 9999 = impossible) ", "Shadow Empire : Planetary Conquest")));
                if (num12 < -1 | num12 > 9999)
                {
                  int num13 = (int) Interaction.MsgBox((object) "Between 0 and 1000 please!", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                {
                  this.game.Data.ResearchObj[this.ResearchNr].PointCost[this.detailnr] = num12;
                  this.MakeResearchTypeItemGUI();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
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
