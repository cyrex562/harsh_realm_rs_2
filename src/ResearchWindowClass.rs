// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ResearchWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingMicrosoft.VisualBasic.CompilerServices;
// usingSystem;
// usingSystem.Drawing;
// usingSystem.Windows.Forms;

namespace WindowsApplication1
{
  pub class ResearchWindowClass : WindowClass
  {
     ResearchListId: i32;
     ListClass ResearchListObj;
     BAddResearchId: i32;
     BAddResearchTextId: i32;
     BNameId: i32;
     BNameTextId: i32;
     B1Id: i32;
     B1TextId: i32;
     B2Id: i32;
     B2TextId: i32;
     B3Id: i32;
     B3TextId: i32;
     BRemoveResearchId: i32;
     BRemoveResearchTextId: i32;
     BRemoveResearchId2: i32;
     BRemoveResearchTextId2: i32;
     B4Id: i32;
     B4TextId: i32;
     B5Id: i32;
     B5TextId: i32;
     B6Id: i32;
     B6TextId: i32;
     B7Id: i32;
     B7TextId: i32;
     B8Id: i32;
     B8TextId: i32;
     B9Id: i32;
     B9TextId: i32;
     B10Id: i32;
     B10TextId: i32;
     B11Id: i32;
     B11TextId: i32;
     PGListId: i32;
     ListClass PGListObj;
     B3bId: i32;
     B3bTextId: i32;
     ResearchNr: i32;
     detailnr: i32;
     string ss;

    pub ResearchWindowClass( tGame: GameClass)
      : base( tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Decision Room")
    {
      this.ResearchNr = -1;
      this.detailnr = -1;
      this.MakeResearchListGUI(-1);
    }

    pub fn DoRefresh() => this.MakeResearchTypeItemGUI();

     void MakeResearchListGUI(tResearchnr: i32)
    {
      if (this.ResearchListId > 0)
        this.RemoveSubPart(this.ResearchListId);
      SubPartClass tsubpart;
      if (this.game.Data.ResearchCounter > -1)
      {
        this.ResearchListObj = ListClass::new();
        let mut researchCounter: i32 = this.game.Data.ResearchCounter;
        for (let mut index: i32 = 0; index <= researchCounter; index += 1)
          this.ResearchListObj.add(Conversion.Str( index) + ") " + this.game.Data.ResearchObj[index].Name, index);
        ListClass researchListObj = this.ResearchListObj;
        let mut tlistselect: i32 = tResearchnr;
        let mut game: GameClass = this.game;
         local1: Bitmap =  this.OwnBitmap;
        font: Font =  null;
         local2: Font =  font;
        tsubpart =  new ListSubPartClass(researchListObj, 9, 200, tlistselect, game, tHeader: "Researchfields", tbackbitmap: ( local1), bbx: 10, bby: 50, overruleFont: ( local2));
        this.ResearchListId = this.AddSubPart( tsubpart, 10, 50, 200, 192, 0);
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
        tsubpart =  ButtonPartClass::new(this.game.BUTTONPLUS, tDescript: this.ss);
        this.BAddResearchId = this.AddSubPart( tsubpart, 10, 270, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart =  TextPartClass::new("Add a Research", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.BAddResearchTextId = this.AddSubPart( tsubpart, 50, 269, 300, 20, 0);
      }
      if (this.B7Id > 0)
        this.RemoveSubPart(this.B7Id);
      if (this.B7TextId > 0)
        this.RemoveSubPart(this.B7TextId);
      this.ss = "Clicking this button sets cost for all pplgroups equal to that of the first peoplegroup.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart =  ButtonPartClass::new(this.game.BUTTONYELLOW, tDescript: this.ss);
        this.B7Id = this.AddSubPart( tsubpart, 10, 310, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      tsubpart =  TextPartClass::new("Set all to pplgroup0", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.B7TextId = this.AddSubPart( tsubpart, 50, 309, 300, 20, 0);
    }

     void MakeResearchTypeItemGUI()
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
        let mut tsubpart: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B7Id = this.AddSubPart( tsubpart, 10, 310, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        let mut tsubpart: SubPartClass =  TextPartClass::new("Set all to pplgroup0", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
        this.B7TextId = this.AddSubPart( tsubpart, 50, 309, 300, 20, 0);
      }
      if (this.ResearchNr <= -1)
        return;
      this.ss = "Click to change the name of the researchfield";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        let mut tsubpart: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BNameId = this.AddSubPart( tsubpart, 370, 50, 32, 16, 1);
      }
      let mut tsubpart1: SubPartClass =  TextPartClass::new("Name: " + this.game.Data.ResearchObj[this.ResearchNr].Name, Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.BNameTextId = this.AddSubPart( tsubpart1, 410, 49, 400, 20, 0);
      this.ss = "Click to give a short one sentence description of this researchfield";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        let mut tsubpart2: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B1Id = this.AddSubPart( tsubpart2, 370, 70, 32, 16, 1);
      }
      let mut tsubpart3: SubPartClass =  TextPartClass::new("Text: " + this.game.Data.ResearchObj[this.ResearchNr].Text, Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B1TextId = this.AddSubPart( tsubpart3, 410, 69, 400, 20, 0);
      this.ss = "Click to assign the picture of a sftype to this researchfield. -1=none. This is also used by the AI for research directions!";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        let mut tsubpart4: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B2Id = this.AddSubPart( tsubpart4, 370, 90, 32, 16, 1);
      }
      if (this.game.Data.ResearchObj[this.ResearchNr].SFTypePic > -1)
      {
        let mut tsubpart5: SubPartClass =  TextPartClass::new("SFTypeNr Sprite: " + this.game.Data.SFTypeObj[this.game.Data.ResearchObj[this.ResearchNr].SFTypePic].Name + " (" + Conversion.Str( this.game.Data.ResearchObj[this.ResearchNr].SFTypePic) + ")", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B2TextId = this.AddSubPart( tsubpart5, 410, 89, 400, 20, 0);
      }
      else
      {
        let mut tsubpart6: SubPartClass =  TextPartClass::new("SFTypeNr Sprite: -1", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.B2TextId = this.AddSubPart( tsubpart6, 410, 89, 400, 20, 0);
      }
      this.ss = "Click to set which other researchfield is a prerequisite for this one";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        let mut tsubpart7: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B4Id = this.AddSubPart( tsubpart7, 370, 110, 32, 16, 1);
      }
      let mut tsubpart8: SubPartClass =  TextPartClass::new("PreReq: " + Conversion.Str( this.game.Data.ResearchObj[this.ResearchNr].PreReq), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B4TextId = this.AddSubPart( tsubpart8, 410, 109, 400, 20, 0);
      this.ss = "Click to set which other researchfield is a prerequisite for this one";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart8 =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B5Id = this.AddSubPart( tsubpart8, 370, 130, 32, 16, 1);
      }
      tsubpart8 =  TextPartClass::new("PreReq2: " + Conversion.Str( this.game.Data.ResearchObj[this.ResearchNr].PreReq2), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B5TextId = this.AddSubPart( tsubpart8, 410, 129, 400, 20, 0);
      this.ss = "Click to set which researchfield is blocked once this researchfield is bought by a regime. -1=none";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart8 =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B6Id = this.AddSubPart( tsubpart8, 370, 150, 32, 16, 1);
      }
      tsubpart8 =  TextPartClass::new("Blocks: " + Conversion.Str( this.game.Data.ResearchObj[this.ResearchNr].Blocks), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B6TextId = this.AddSubPart( tsubpart8, 410, 149, 400, 20, 0);
      this.ss = "Click to set tech level (used in regime menu and by random game). -1/0 = no tech level assigned.";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart8 =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B9Id = this.AddSubPart( tsubpart8, 370, 170, 32, 16, 1);
      }
      tsubpart8 =  TextPartClass::new("TechLevel: " + Conversion.Str( this.game.Data.ResearchObj[this.ResearchNr].TechLevel), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B9TextId = this.AddSubPart( tsubpart8, 410, 169, 400, 20, 0);
      this.ss = "Click to set cost type. -1=PP =>0 is the regimevar specified";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart8 =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B10Id = this.AddSubPart( tsubpart8, 370, 190, 32, 16, 1);
      }
      tsubpart8 =  TextPartClass::new("CostType: " + Conversion.Str( this.game.Data.ResearchObj[this.ResearchNr].CostType), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
      this.B10TextId = this.AddSubPart( tsubpart8, 410, 189, 400, 20, 0);
      this.ss = "Click to remove this researchfield";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart8 =  ButtonPartClass::new(this.game.BUTTONKILL, tDescript: this.ss);
        this.BRemoveResearchId = this.AddSubPart( tsubpart8, 10, 290, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart8 =  TextPartClass::new("Remove this Research", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BRemoveResearchTextId = this.AddSubPart( tsubpart8, 50, 289, 200, 20, 0);
      }
      this.ss = "Click to remove ALL researchfield";
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart8 =  ButtonPartClass::new(this.game.BUTTONKILL, tDescript: this.ss);
        this.BRemoveResearchId2 = this.AddSubPart( tsubpart8, 10, 330, 32, 16, 1);
      }
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        tsubpart8 =  TextPartClass::new("Remove ALL Research", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BRemoveResearchTextId2 = this.AddSubPart( tsubpart8, 50, 329, 200, 20, 0);
      }
      this.PGListObj = ListClass::new();
      if (this.detailnr < -1 | this.detailnr > 99)
        this.detailnr = -1;
      let mut index: i32 = 0;
      do
      {
        this.PGListObj.add(Conversion.Str( index) + ") " + this.game.Data.TempString[index + 200] + " = " + Conversion.Str( this.game.Data.ResearchObj[this.ResearchNr].PointCost[index]), index);
        index += 1;
      }
      while (index <= 99);
      ListClass pgListObj = this.PGListObj;
      let mut detailnr: i32 = this.detailnr;
      let mut game: GameClass = this.game;
       local1: Bitmap =  this.OwnBitmap;
      font: Font =  null;
       local2: Font =  font;
      tsubpart8 =  new ListSubPartClass(pgListObj, 6, 200, detailnr, game, tHeader: "Research Cost", tbackbitmap: ( local1), bbx: 10, bby: 350, overruleFont: ( local2));
      this.PGListId = this.AddSubPart( tsubpart8, 10, 350, 200, 144, 0);
      this.maketabsheet3b();
    }

     void maketabsheet3b()
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
        let mut tsubpart: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.B3bId = this.AddSubPart( tsubpart, 215, 350, 32, 16, 1);
      }
      if (!(Strings.Len(this.game.Data.MasterFile) == 0 | !this.game.Data.MasterfileReadPeople))
        return;
      let mut tsubpart1: SubPartClass =  TextPartClass::new("Change", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 100, 20, false, tDescript: this.ss);
      this.B3bTextId = this.AddSubPart( tsubpart1, 250, 349, 200, 20, 0);
    }

    pub HandleMouseClick: WindowReturnClass(x: i32, y: i32, b: i32)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 = this.SubPartCounter;
        for (let mut index1: i32 = 0; index1 <= subPartCounter; index1 += 1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            let mut num1: i32 = this.SubPartID[index1];
            if (num1 == this.ResearchListId)
            {
              let mut num2: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
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
              str: String = Interaction.InputBox("We will set all to ppg0 pp cost, with the following mod (1.0 is none)", "Shadow Empire : Planetary Conquest", "1");
              if (Operators.CompareString(str, "", false) != 0)
              {
                float num3 =  Conversion.Val(str);
                let mut researchCounter: i32 = this.game.Data.ResearchCounter;
                for (let mut index2: i32 = 0; index2 <= researchCounter; index2 += 1)
                {
                  let mut num4: i32 = this.game.Data.ResearchObj[index2].PointCost[0];
                  let mut index3: i32 = 1;
                  do
                  {
                    this.game.Data.ResearchObj[index2].PointCost[index3] =  Math.Round( Conversion.Int( num4 * num3));
                    index3 += 1;
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
                Form2::new( this.formref).Initialize(this.game.Data, 5, this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B4Id)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 22, this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B5Id)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 23, this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B6Id)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 24, this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B9Id)
              {
                let mut num5: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("TechLevel (-1 = no tech level..no problem) .. ", "Shadow Empire : Planetary Conquest")));
                if (num5 >= -1 & num5 <= 999)
                {
                  this.game.Data.ResearchObj[this.ResearchNr].TechLevel = num5;
                }
                else
                {
                  let mut num6: i32 =  Interaction.MsgBox( "number between -1 and 999 plz", Title: ( "Shadow Empire : Planetary Conquest"));
                }
                this.MakeResearchListGUI(this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B10Id)
              {
                let mut num7: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("CostType... -1=pp >=0 is regimevar ", "Shadow Empire : Planetary Conquest")));
                if (num7 >= -1 & num7 <= 499)
                {
                  this.game.Data.ResearchObj[this.ResearchNr].CostType = num7;
                }
                else
                {
                  let mut num8: i32 =  Interaction.MsgBox( "number between -1 and 499 plz", Title: ( "Shadow Empire : Planetary Conquest"));
                }
                this.MakeResearchListGUI(this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B11Id)
              {
                let mut num9: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("UpgradeCost in prodpoints for improvement.. -1=not possible ", "Shadow Empire : Planetary Conquest")));
                if (num9 >= -1 & num9 <= 999999)
                {
                  this.game.Data.ResearchObj[this.ResearchNr].UpgradeCost = num9;
                }
                else
                {
                  let mut num10: i32 =  Interaction.MsgBox( "number between -1 and 999999 plz", Title: ( "Shadow Empire : Planetary Conquest"));
                }
                this.MakeResearchListGUI(this.ResearchNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B2Id)
              {
                Form3::new( this.formref).Initialize(this.game.Data, 21, this.ResearchNr);
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
                for (let mut researchCounter: i32 = this.game.Data.ResearchCounter; researchCounter >= 0; researchCounter += -1)
                  this.game.Data.RemoveResearch(researchCounter);
                this.MakeResearchListGUI(-1);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.PGListId)
              {
                let mut num11: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
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
                let mut num12: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give new pocost: i32 for this peoplegroup 0-9999 (-1 or 9999 = impossible) ", "Shadow Empire : Planetary Conquest")));
                if (num12 < -1 | num12 > 9999)
                {
                  let mut num13: i32 =  Interaction.MsgBox( "Between 0 and 1000 please!", Title: ( "Shadow Empire : Planetary Conquest"));
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
