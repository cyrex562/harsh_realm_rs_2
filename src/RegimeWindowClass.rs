// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.RegimeWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingMicrosoft.VisualBasic.CompilerServices;
// usingSystem;
// usingSystem.Drawing;
// usingSystem.IO;
// usingSystem.Windows.Forms;

namespace WindowsApplication1
{
  pub class RegimeWindowClass : WindowClass
  {
     LibListId: i32;
     LibNr: i32;
     ListClass LibListObj;
     regimeListId: i32;
     ListClass regimeListObj;
     BAddregimeId: i32;
     BAddregimeTextId: i32;
     BNameId: i32;
     BNameTextId: i32;
     BRedId: i32;
     BRedTextId: i32;
     BRed2Id: i32;
     BRed2TextId: i32;
     BRed3Id: i32;
     BRed3TextId: i32;
     BRed4Id: i32;
     BRed4TextId: i32;
     BMorId: i32;
     BMorTextId: i32;
     BAIId: i32;
     BAITextID: i32;
     PbemId: i32;
     PbemTextId: i32;
     BRemoveregimeId: i32;
     BRemoveregimeTextId: i32;
     BDrawId: i32;
     BDrawTextId: i32;
     OptionsListId: i32;
     ListClass OptionsListObj;
     BResId: i32;
     BResTextId: i32;
     BPolId: i32;
     BPolTextId: i32;
     clid: i32;
     cltextid: i32;
     e1id: i32;
     e1textid: i32;
     e2id: i32;
     e2textid: i32;
     e3id: i32;
     e3textid: i32;
     e4id: i32;
     e4textid: i32;
     e5id: i32;
     e5textid: i32;
     e6id: i32;
     e6textid: i32;
     e7id: i32;
     e7textid: i32;
     e8id: i32;
     e8textid: i32;
     e9id: i32;
     e9textid: i32;
     e10id: i32;
     e10textid: i32;
     e11id: i32;
     e11textid: i32;
     e12id: i32;
     e12textid: i32;
     e13id: i32;
     e13textid: i32;
     altid: i32;
     alttextid: i32;
     B1Id: i32;
     B1TextId: i32;
     BSymbolId: i32;
     BChangeSymbolId: i32;
     NatIconId: i32;
     NatIconPic: i32;
     RoundelId: i32;
     RoundelPic: i32;
     stringListId: i32;
     ListClass stringListObj;
     B2Id: i32;
     B2TextId: i32;
     ResListId: i32;
     ListClass ResListObj;
     b3Id: i32;
     B3TextId: i32;
     b5Id: i32;
     B5TextId: i32;
     dipListId: i32;
     ListClass dipListObj;
     b4Id: i32;
     B4TextId: i32;
     regimeNr: i32;
     TabSheetNr: i32;
     DetailNr: i32;
     HighId: i32;
     LowId: i32;
     string ss;

    pub RegimeWindowClass( tGame: GameClass)
      : base( tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Regimes")
    {
      this.regimeNr = -1;
      this.TabSheetNr = -1;
      this.LibNr = -1;
      this.DetailNr = -1;
      this.MakeregimeListGUI(-1);
    }

    pub fn DoRefresh()
    {
      if (this.regimeNr > -1)
        this.LibNr = this.game.Data.RegimeObj[this.regimeNr].libId.libSlot;
      this.MakeregimeListGUI(this.regimeNr);
    }

     void MakeregimeListGUI(tregimenr: i32)
    {
      if (this.regimeListId > 0)
        this.RemoveSubPart(this.regimeListId);
      if (this.LibListId > 0)
        this.RemoveSubPart(this.LibListId);
      this.LibListObj = ListClass::new();
      this.LibListObj.add("All", -2);
      let mut num1: i32 = -1;
      let mut num2: i32 = 0;
      let mut libraryCounter: i32 = this.game.Data.LibraryCounter;
      for (let mut index: i32 = 0; index <= libraryCounter; index += 1)
      {
        num2 += 1;
        if (this.LibNr == index)
          num1 = num2;
        this.LibListObj.add(Conversion.Str( index) + ") " + this.game.Data.LibraryObj[index].name, index);
      }
      if (this.LibNr == -1)
        num1 = 0;
      ListClass libListObj = this.LibListObj;
      let mut tlistselect1: i32 = num1;
      let mut game1: GameClass = this.game;
       local1: Bitmap =  this.OwnBitmap;
      font1: Font =  null;
       local2: Font =  font1;
      let mut tsubpart1: SubPartClass =  new ListSubPartClass(libListObj, 7, 200, tlistselect1, game1, tHeader: "Libraries", tbackbitmap: ( local1), bbx: 10, bby: 40, overruleFont: ( local2));
      this.LibListId = this.AddSubPart( tsubpart1, 10, 40, 200, 160, 0);
      let mut num3: i32 = -1;
      let mut num4: i32 = -1;
      if (this.game.Data.RegimeCounter > -1)
      {
        this.regimeListObj = ListClass::new();
        let mut regimeCounter: i32 = this.game.Data.RegimeCounter;
        for (let mut index: i32 = 0; index <= regimeCounter; index += 1)
        {
          if (this.game.Data.RegimeObj[index].libId.libSlot == this.LibNr | this.LibNr == -1)
          {
            this.regimeListObj.add(Strings.Trim(Conversion.Str( index)) + ") " + this.game.Data.RegimeObj[index].Name + "(id=" + this.game.Data.RegimeObj[index].id.ToString() + ")", index);
            num3 += 1;
            if (this.LibNr == index)
              num4 = num3;
          }
        }
        ListClass regimeListObj = this.regimeListObj;
        let mut tlistselect2: i32 = num4;
        let mut game2: GameClass = this.game;
         local3: Bitmap =  this.OwnBitmap;
        font2: Font =  null;
         local4: Font =  font2;
        let mut tsubpart2: SubPartClass =  new ListSubPartClass(regimeListObj, 3, 200, tlistselect2, game2, tHeader: "Regimes", tbackbitmap: ( local3), bbx: 10, bby: 210, overruleFont: ( local4));
        this.regimeListId = this.AddSubPart( tsubpart2, 10, 210, 200, 80, 0);
        this.regimeNr = tregimenr;
        this.MakeregimeTypeItemGUI();
      }
      else
      {
        this.regimeNr = tregimenr;
        this.MakeregimeTypeItemGUI();
      }
      if (this.BAddregimeId > 0)
        this.RemoveSubPart(this.BAddregimeId);
      if (this.BAddregimeTextId > 0)
        this.RemoveSubPart(this.BAddregimeTextId);
      this.ss = "Click to add a regime";
      let mut tsubpart3: SubPartClass =  ButtonPartClass::new(this.game.BUTTONPLUS, tDescript: this.ss);
      this.BAddregimeId = this.AddSubPart( tsubpart3, 610, 70, 32, 16, 1);
      let mut tsubpart4: SubPartClass =  TextPartClass::new("Add Regime", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BAddregimeTextId = this.AddSubPart( tsubpart4, 650, 69, 300, 20, 0);
    }

     void MakeregimeTypeItemGUI()
    {
      if (this.BNameId > 0)
        this.RemoveSubPart(this.BNameId);
      if (this.BNameTextId > 0)
        this.RemoveSubPart(this.BNameTextId);
      if (this.BRedId > 0)
        this.RemoveSubPart(this.BRedId);
      if (this.BRedTextId > 0)
        this.RemoveSubPart(this.BRedTextId);
      if (this.clid > 0)
        this.RemoveSubPart(this.clid);
      if (this.cltextid > 0)
        this.RemoveSubPart(this.cltextid);
      if (this.BRed2Id > 0)
        this.RemoveSubPart(this.BRed2Id);
      if (this.BRed2TextId > 0)
        this.RemoveSubPart(this.BRed2TextId);
      if (this.BRed3Id > 0)
        this.RemoveSubPart(this.BRed3Id);
      if (this.BRed3TextId > 0)
        this.RemoveSubPart(this.BRed3TextId);
      if (this.BRed4Id > 0)
        this.RemoveSubPart(this.BRed4Id);
      if (this.BRed4TextId > 0)
        this.RemoveSubPart(this.BRed4TextId);
      if (this.BRemoveregimeId > 0)
        this.RemoveSubPart(this.BRemoveregimeId);
      if (this.BRemoveregimeTextId > 0)
        this.RemoveSubPart(this.BRemoveregimeTextId);
      if (this.BDrawId > 0)
        this.RemoveSubPart(this.BDrawId);
      if (this.BDrawTextId > 0)
        this.RemoveSubPart(this.BDrawTextId);
      if (this.OptionsListId > 0)
        this.RemoveSubPart(this.OptionsListId);
      if (this.BMorId > 0)
        this.RemoveSubPart(this.BMorId);
      if (this.BMorTextId > 0)
        this.RemoveSubPart(this.BMorTextId);
      if (this.altid > 0)
        this.RemoveSubPart(this.altid);
      if (this.alttextid > 0)
        this.RemoveSubPart(this.alttextid);
      if (this.BResId > 0)
        this.RemoveSubPart(this.BResId);
      if (this.BPolId > 0)
        this.RemoveSubPart(this.BPolId);
      if (this.BResTextId > 0)
        this.RemoveSubPart(this.BResTextId);
      if (this.BPolTextId > 0)
        this.RemoveSubPart(this.BPolTextId);
      if (this.BAIId > 0)
        this.RemoveSubPart(this.BAIId);
      if (this.BAITextID > 0)
        this.RemoveSubPart(this.BAITextID);
      if (this.e1id > 0)
        this.RemoveSubPart(this.e1id);
      if (this.e1textid > 0)
        this.RemoveSubPart(this.e1textid);
      if (this.e2id > 0)
        this.RemoveSubPart(this.e2id);
      if (this.e2textid > 0)
        this.RemoveSubPart(this.e2textid);
      if (this.e3id > 0)
        this.RemoveSubPart(this.e3id);
      if (this.e3textid > 0)
        this.RemoveSubPart(this.e3textid);
      if (this.e4id > 0)
        this.RemoveSubPart(this.e4id);
      if (this.e4textid > 0)
        this.RemoveSubPart(this.e4textid);
      if (this.e5id > 0)
        this.RemoveSubPart(this.e5id);
      if (this.e5textid > 0)
        this.RemoveSubPart(this.e5textid);
      if (this.e6id > 0)
        this.RemoveSubPart(this.e6id);
      if (this.e6textid > 0)
        this.RemoveSubPart(this.e6textid);
      if (this.e7id > 0)
        this.RemoveSubPart(this.e7id);
      if (this.e7textid > 0)
        this.RemoveSubPart(this.e7textid);
      if (this.e8id > 0)
        this.RemoveSubPart(this.e8id);
      if (this.e8textid > 0)
        this.RemoveSubPart(this.e8textid);
      if (this.e9id > 0)
        this.RemoveSubPart(this.e9id);
      if (this.e9textid > 0)
        this.RemoveSubPart(this.e9textid);
      if (this.e10id > 0)
        this.RemoveSubPart(this.e10id);
      if (this.e10textid > 0)
        this.RemoveSubPart(this.e10textid);
      if (this.e11id > 0)
        this.RemoveSubPart(this.e11id);
      if (this.e11textid > 0)
        this.RemoveSubPart(this.e11textid);
      if (this.e12id > 0)
        this.RemoveSubPart(this.e12id);
      if (this.e12textid > 0)
        this.RemoveSubPart(this.e12textid);
      if (this.e13id > 0)
        this.RemoveSubPart(this.e13id);
      if (this.e13textid > 0)
        this.RemoveSubPart(this.e13textid);
      if (this.PbemId > 0)
        this.RemoveSubPart(this.PbemId);
      if (this.PbemTextId > 0)
        this.RemoveSubPart(this.PbemTextId);
      if (this.NatIconId > 0)
        this.RemoveSubPart(this.NatIconId);
      if (this.NatIconPic > 0)
        this.RemoveSubPart(this.NatIconPic);
      if (this.RoundelId > 0)
        this.RemoveSubPart(this.RoundelId);
      if (this.RoundelPic > 0)
        this.RemoveSubPart(this.RoundelPic);
      if (this.HighId > 0)
        this.RemoveSubPart(this.HighId);
      if (this.LowId > 0)
        this.RemoveSubPart(this.LowId);
      if (this.regimeNr > -1)
      {
        this.ss = "Click to change the name of the regime";
        let mut tsubpart1: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BNameId = this.AddSubPart( tsubpart1, 370, 220, 32, 16, 1);
        let mut tsubpart2: SubPartClass =  TextPartClass::new("Name: " + this.game.Data.RegimeObj[this.regimeNr].Name, Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BNameTextId = this.AddSubPart( tsubpart2, 410, 219, 200, 20, 0);
        this.ss = "Click to change the of: Color the counters and backgrounds of this regime";
        let mut tsubpart3: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BRedId = this.AddSubPart( tsubpart3, 370, 50, 32, 16, 1);
        let mut tsubpart4: SubPartClass =  ButtonPartClass::new(this.game.CustomBitmapObj.DrawHistoryForce(this.regimeNr, -1, -1));
        this.BRedTextId = this.AddSubPart( tsubpart4, 410, 49, 38, 38, 0);
        this.ss = "Click to change the of: Color the sprite and text on the counters, and over backgrounds";
        let mut tsubpart5: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BRed2Id = this.AddSubPart( tsubpart5, 370, 120, 32, 16, 1);
        if (this.game.Data.SFTypeCounter > -1)
        {
          let mut tsubpart6: SubPartClass =  ButtonPartClass::new(this.game.CustomBitmapObj.DrawHistoryForce(this.regimeNr, 50, 0));
          this.BRed2TextId = this.AddSubPart( tsubpart6, 410, 119, 200, 20, 0);
        }
        this.ss = "Click to set basemorale for regime. 100 means the basemorale of a people is not modified. 50 means basemorale of a people will be 50% lower.";
        let mut tsubpart7: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BMorId = this.AddSubPart( tsubpart7, 370, 180, 32, 16, 1);
        let mut tsubpart8: SubPartClass =  TextPartClass::new("BaseMorale: " + Conversion.Str( this.game.Data.RegimeObj[this.regimeNr].BaseMorale), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BMorTextId = this.AddSubPart( tsubpart8, 410, 179, 200, 20, 0);
        this.ss = "Click to set the political points this regime starts with";
        tsubpart8 =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BResId = this.AddSubPart( tsubpart8, 370, 200, 32, 16, 1);
        tsubpart8 =  TextPartClass::new("Pol.Pts: " + Conversion.Str( this.game.Data.RegimeObj[this.regimeNr].ResPts), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BResTextId = this.AddSubPart( tsubpart8, 410, 199, 200, 20, 0);
        this.ss = "Click to set if this regime is an AI as default or not";
        tsubpart8 =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BAIId = this.AddSubPart( tsubpart8, 370, 240, 32, 16, 1);
        tsubpart8 =  TextPartClass::new("is AI: " + Conversion.Str( this.game.Data.RegimeObj[this.regimeNr].AI), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BAITextID = this.AddSubPart( tsubpart8, 410, 239, 200, 20, 0);
        this.ss = "Click to set if this regime is sleeping. (sleeping means it wont be able to play until an event wakes it)";
        tsubpart8 =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.e5id = this.AddSubPart( tsubpart8, 670, 220, 32, 16, 1);
        tsubpart8 =  TextPartClass::new("Sleeping: " + Conversion.Str( this.game.Data.RegimeObj[this.regimeNr].Sleep), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e5textid = this.AddSubPart( tsubpart8, 710, 219, 200, 20, 0);
        this.ss = "Click to set the PBEM++ Player for this regime. 0=auto set, 1=player 1, 2=player 2";
        tsubpart8 =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.PbemId = this.AddSubPart( tsubpart8, 670, 240, 32, 16, 1);
        tsubpart8 =  TextPartClass::new("PBEM++ player: " + Conversion.Str( this.game.Data.RegimeObj[this.regimeNr].PbemPlayer), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.PbemTextId = this.AddSubPart( tsubpart8, 710, 239, 200, 20, 0);
        this.ss = "Set to true if regime uses Alternative actioncard pictures";
        tsubpart8 =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.altid = this.AddSubPart( tsubpart8, 670, 260, 32, 16, 1);
        tsubpart8 =  TextPartClass::new("Alt.ActionCardPics: " + Conversion.Str( this.game.Data.RegimeObj[this.regimeNr].UseAlternateActionCardPics), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.alttextid = this.AddSubPart( tsubpart8, 710, 259, 200, 20, 0);
        this.ss = "Click to set all subformations of this regime to its current people!";
        tsubpart8 =  ButtonPartClass::new(this.game.BUTTONYELLOW, tDescript: this.ss);
        this.e9id = this.AddSubPart( tsubpart8, 670, 170, 32, 16, 1);
        tsubpart8 =  TextPartClass::new("Set All SF Ppl", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e9textid = this.AddSubPart( tsubpart8, 710, 169, 200, 20, 0);
        this.ss = "Click to remove a regime";
        tsubpart8 =  ButtonPartClass::new(this.game.BUTTONKILL, tDescript: this.ss);
        this.BRemoveregimeId = this.AddSubPart( tsubpart8, 610, 90, 32, 16, 1);
        tsubpart8 =  TextPartClass::new("Remove ", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BRemoveregimeTextId = this.AddSubPart( tsubpart8, 650, 89, 200, 20, 0);
        this.ss = "Click to change Lib";
        tsubpart8 =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.clid = this.AddSubPart( tsubpart8, 850, 90, 32, 16, 1);
        tsubpart8 =  TextPartClass::new("Set Library", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.cltextid = this.AddSubPart( tsubpart8, 890, 89, 200, 20, 0);
        if (this.regimeNr < this.game.Data.RegimeCounter)
        {
          tsubpart8 =  ButtonPartClass::new(this.game.BUTTONDOWN, tDescript: "Move down list");
          this.HighId = this.AddSubPart( tsubpart8, 10, 330, 32, 16, 1);
        }
        if (this.regimeNr > 0)
        {
          tsubpart8 =  ButtonPartClass::new(this.game.BUTTONUP, tDescript: "Move Up List");
          this.LowId = this.AddSubPart( tsubpart8, 50, 330, 32, 16, 1);
        }
        this.ss = "Click to use this regime for drawing on the map";
        tsubpart8 =  ButtonPartClass::new(this.game.BUTTONDRAW, tDescript: this.ss);
        this.BDrawId = this.AddSubPart( tsubpart8, 610, 110, 32, 16, 1);
        tsubpart8 =  TextPartClass::new("Select as pencil", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BDrawTextId = this.AddSubPart( tsubpart8, 650, 109, 200, 20, 0);
        this.OptionsListObj = ListClass::new();
        this.OptionsListObj.add("Statistics", 0);
        this.OptionsListObj.add("RegimeSlots", 1);
        this.OptionsListObj.add("Diplomatic Relations", 2);
        ListClass optionsListObj = this.OptionsListObj;
        let mut tabSheetNr: i32 = this.TabSheetNr;
        let mut game: GameClass = this.game;
         local1: Bitmap =  this.OwnBitmap;
        font: Font =  null;
         local2: Font =  font;
        tsubpart8 =  new ListSubPartClass(optionsListObj, 5, 300, tabSheetNr, game, tHeader: "Property Sheets", tbackbitmap: ( local1), bbx: 370, bby: 262, overruleFont: ( local2));
        this.OptionsListId = this.AddSubPart( tsubpart8, 370, 262, 300, 128, 0);
      }
      this.maketabsheet();
    }

     void maketabsheet()
    {
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.b3Id > 0)
        this.RemoveSubPart(this.b3Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
      if (this.b4Id > 0)
        this.RemoveSubPart(this.b4Id);
      if (this.B4TextId > 0)
        this.RemoveSubPart(this.B4TextId);
      if (this.b5Id > 0)
        this.RemoveSubPart(this.b5Id);
      if (this.B5TextId > 0)
        this.RemoveSubPart(this.B5TextId);
      if (this.e8id > 0)
        this.RemoveSubPart(this.e8id);
      if (this.e8textid > 0)
        this.RemoveSubPart(this.e8textid);
      if (this.stringListId > 0)
        this.RemoveSubPart(this.stringListId);
      if (this.ResListId > 0)
        this.RemoveSubPart(this.ResListId);
      if (this.BSymbolId > 0)
        this.RemoveSubPart(this.BSymbolId);
      if (this.BChangeSymbolId > 0)
        this.RemoveSubPart(this.BChangeSymbolId);
      if (this.NatIconId > 0)
        this.RemoveSubPart(this.NatIconId);
      if (this.NatIconPic > 0)
        this.RemoveSubPart(this.NatIconPic);
      if (this.RoundelId > 0)
        this.RemoveSubPart(this.RoundelId);
      if (this.RoundelPic > 0)
        this.RemoveSubPart(this.RoundelPic);
      if (this.e10id > 0)
        this.RemoveSubPart(this.e10id);
      if (this.e10textid > 0)
        this.RemoveSubPart(this.e10textid);
      if (this.e11id > 0)
        this.RemoveSubPart(this.e11id);
      if (this.e11textid > 0)
        this.RemoveSubPart(this.e11textid);
      if (this.e12id > 0)
        this.RemoveSubPart(this.e12id);
      if (this.e12textid > 0)
        this.RemoveSubPart(this.e12textid);
      if (this.e13id > 0)
        this.RemoveSubPart(this.e13id);
      if (this.e13textid > 0)
        this.RemoveSubPart(this.e13textid);
      if (this.dipListId > 0)
        this.RemoveSubPart(this.dipListId);
      if (!(this.regimeNr > -1 & this.TabSheetNr > -1))
        return;
      if (this.TabSheetNr == 0)
        this.maketabsheetnr0();
      if (this.TabSheetNr == 1)
        this.maketabsheetnr1();
      if (this.TabSheetNr != 2)
        return;
      this.maketabsheetnr4();
    }

     void maketabsheetnr0()
    {
      this.ss = "Click to select which people rule this regime. (is important for people basemorale and production)";
      name: String = this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.regimeNr].People].Name;
      let mut tsubpart1: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.B1Id = this.AddSubPart( tsubpart1, 10, 380, 32, 16, 1);
      let mut tsubpart2: SubPartClass =  TextPartClass::new("People: " + name, Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B1TextId = this.AddSubPart( tsubpart2, 50, 379, 400, 20, 0);
      this.ss = "Click to change the HQ sprite";
      let mut tsubpart3: SubPartClass =  ButtonPartClass::new(this.game.Data.RegimeObj[this.regimeNr].HQSpriteNr, tDescript: this.ss);
      this.BSymbolId = this.AddSubPart( tsubpart3, 10, 410, 31, 31, 0);
      let mut tsubpart4: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLUE, tDescript: this.ss);
      this.BChangeSymbolId = this.AddSubPart( tsubpart4, 50, 410, 32, 16, 1);
      this.ss = "Click to select if this HQ sprite should have its colours adjusted for the regimes color.";
      let mut tsubpart5: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.e8id = this.AddSubPart( tsubpart5, 10, 450, 32, 16, 1);
      let mut tsubpart6: SubPartClass =  TextPartClass::new("HQSymbolOverrule: " + Strings.Trim(Conversion.Str( this.game.Data.RegimeObj[this.regimeNr].HQSpriteOverrule)), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.e8textid = this.AddSubPart( tsubpart6, 50, 449, 400, 20, 0);
      this.ss = "Click to change the National Icon of this regime";
      let mut tsubpart7: SubPartClass =  ButtonPartClass::new(this.game.Data.RegimeObj[this.regimeNr].NationalIconSprite, tDescript: this.ss);
      this.NatIconPic = this.AddSubPart( tsubpart7, 10, 490, 10, 10, 0);
      let mut tsubpart8: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLUE, tDescript: this.ss);
      this.NatIconId = this.AddSubPart( tsubpart8, 50, 490, 32, 16, 1);
      this.ss = "Click to set UberRegime for this Regime.";
      let mut tsubpart9: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.e12id = this.AddSubPart( tsubpart9, 10, 580, 32, 16, 1);
      SubPartClass tsubpart10;
      if (this.game.Data.RegimeObj[this.regimeNr].UberRegime == -1)
      {
        tsubpart10 =  TextPartClass::new("UberRegime: -1 (none)", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e12textid = this.AddSubPart( tsubpart10, 50, 579, 400, 20, 0);
      }
      else
      {
        let mut tsubpart11: SubPartClass =  TextPartClass::new("UberRegime: " + this.game.Data.RegimeObj[this.game.Data.RegimeObj[this.regimeNr].UberRegime].Name, Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.e12textid = this.AddSubPart( tsubpart11, 50, 579, 400, 20, 0);
      }
      this.ss = "Click to set if SFType sprites should be mirrored for this regime";
      tsubpart10 =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.e13id = this.AddSubPart( tsubpart10, 10, 610, 32, 16, 1);
      tsubpart10 =  TextPartClass::new("Mirror: " + Strings.Trim(Conversion.Str( this.game.Data.RegimeObj[this.regimeNr].Mirror)), Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.e13textid = this.AddSubPart( tsubpart10, 50, 609, 400, 20, 0);
      this.ss = "Click to change the Roundel Icon of this regime";
      tsubpart10 =  ButtonPartClass::new(this.game.Data.RegimeObj[this.regimeNr].RoundelIconSprite, tDescript: this.ss, tResizeX: 20, tresizeY: 20);
      this.RoundelPic = this.AddSubPart( tsubpart10, 10, 630, 10, 10, 0);
      tsubpart10 =  ButtonPartClass::new(this.game.BUTTONBLUE, tDescript: this.ss);
      this.RoundelId = this.AddSubPart( tsubpart10, 50, 630, 32, 16, 1);
    }

     void maketabsheetnr1()
    {
      this.stringListObj = ListClass::new();
      let mut index: i32 = 0;
      do
      {
        this.stringListObj.add(Conversion.Str( index) + ") " + this.game.Data.RegimeSlotName[index] + " = " + Conversion.Str( this.game.Data.RegimeObj[this.regimeNr].RegimeSlot[index]), index);
        index += 1;
      }
      while (index <= 499);
      if (this.DetailNr > this.game.Data.StringCounter)
        this.DetailNr = -1;
      ListClass stringListObj = this.stringListObj;
      let mut detailNr: i32 = this.DetailNr;
      let mut game: GameClass = this.game;
       local1: Bitmap =  this.OwnBitmap;
      font: Font =  null;
       local2: Font =  font;
      let mut tsubpart: SubPartClass =  new ListSubPartClass(stringListObj, 12, 300, detailNr, game, tHeader: "Regimeslots", tbackbitmap: ( local1), bbx: 10, bby: 400, overruleFont: ( local2));
      this.stringListId = this.AddSubPart( tsubpart, 10, 400, 300, 240, 0);
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr1b();
    }

     void maketabsheetnr1b()
    {
      this.ss = "Click to change value of regimeslots. Regimeslots can be used in events. Their names can be set in settings";
      let mut tsubpart1: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.B2Id = this.AddSubPart( tsubpart1, 350, 400, 32, 16, 1);
      let mut tsubpart2: SubPartClass =  TextPartClass::new("Change Value", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B2TextId = this.AddSubPart( tsubpart2, 390, 399, 400, 20, 0);
    }

     void maketabsheetnr3()
    {
      this.ResListObj = ListClass::new();
      if (this.game.Data.ResearchCounter <= -1)
        return;
      let mut researchCounter: i32 = this.game.Data.ResearchCounter;
      for (let mut index: i32 = 0; index <= researchCounter; index += 1)
        this.ResListObj.add(Conversion.Str( index) + ") " + this.game.Data.ResearchObj[index].Name + " = " + Conversion.Str( this.game.Data.RegimeObj[this.regimeNr].ResField[index]), index);
      if (this.DetailNr > this.game.Data.ResearchCounter)
        this.DetailNr = -1;
      ListClass resListObj = this.ResListObj;
      let mut detailNr: i32 = this.DetailNr;
      let mut game: GameClass = this.game;
       local1: Bitmap =  this.OwnBitmap;
      font: Font =  null;
       local2: Font =  font;
      let mut tsubpart: SubPartClass =  new ListSubPartClass(resListObj, 12, 300, detailNr, game, tHeader: "Regimes Research", tbackbitmap: ( local1), bbx: 10, bby: 400, overruleFont: ( local2));
      this.ResListId = this.AddSubPart( tsubpart, 10, 400, 300, 240, 0);
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr3b();
    }

     void maketabsheetnr3b()
    {
      this.ss = "Click to enable or disable a researchfield for this regime";
      let mut tsubpart1: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.b3Id = this.AddSubPart( tsubpart1, 350, 400, 32, 16, 1);
      let mut tsubpart2: SubPartClass =  TextPartClass::new("Change Value", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B3TextId = this.AddSubPart( tsubpart2, 390, 399, 400, 20, 0);
      this.ss = "Click here to set all research up to lvl X on.. and above off";
      let mut tsubpart3: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.b5Id = this.AddSubPart( tsubpart3, 350, 450, 32, 16, 1);
      let mut tsubpart4: SubPartClass =  TextPartClass::new("Set research to lvl", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B5TextId = this.AddSubPart( tsubpart4, 390, 449, 400, 20, 0);
    }

     void maketabsheetnr4()
    {
      this.dipListObj = ListClass::new();
      if (this.game.Data.RegimeCounter <= -1)
        return;
      let mut regimeCounter: i32 = this.game.Data.RegimeCounter;
      for (let mut index: i32 = 0; index <= regimeCounter; index += 1)
        this.dipListObj.add(Conversion.Str( index) + ") " + this.game.Data.RegimeObj[index].Name + " = " + Conversion.Str( this.game.Data.RegimeObj[this.regimeNr].RegimeRel[index]), index);
      if (this.DetailNr > this.game.Data.RegimeCounter)
        this.DetailNr = -1;
      ListClass dipListObj = this.dipListObj;
      let mut detailNr: i32 = this.DetailNr;
      let mut game: GameClass = this.game;
       local1: Bitmap =  this.OwnBitmap;
      font: Font =  null;
       local2: Font =  font;
      let mut tsubpart: SubPartClass =  new ListSubPartClass(dipListObj, 12, 300, detailNr, game, tHeader: "Dip", tbackbitmap: ( local1), bbx: 10, bby: 400, overruleFont: ( local2));
      this.dipListId = this.AddSubPart( tsubpart, 10, 400, 300, 240, 0);
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr4b();
    }

     void maketabsheetnr4b()
    {
      this.ss = "Click to change diplomatic relation of selected regime with this regime";
      let mut tsubpart1: SubPartClass =  ButtonPartClass::new(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.b4Id = this.AddSubPart( tsubpart1, 350, 400, 32, 16, 1);
      let mut tsubpart2: SubPartClass =  TextPartClass::new("Change Value", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B4TextId = this.AddSubPart( tsubpart2, 390, 399, 400, 20, 0);
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
            if (num1 == this.LibListId)
            {
              let mut num2: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.LibNr = num2;
                this.regimeNr = -1;
                this.MakeregimeListGUI(this.regimeNr);
              }
              else if (num2 == -2)
              {
                this.LibNr = -1;
                this.regimeNr = -1;
                this.MakeregimeListGUI(this.regimeNr);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.regimeListId)
            {
              let mut num3: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num3 > -1)
              {
                this.regimeNr = num3;
                this.MakeregimeTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddregimeId)
            {
              this.game.Data.AddRegime();
              this.MakeregimeListGUI(this.regimeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BNameId)
            {
              this.game.Data.RegimeObj[this.regimeNr].Name = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest");
              this.MakeregimeListGUI(this.regimeNr);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BMorId)
            {
              let mut num4: i32 =  Math.Round(Conversion.Int(Conversion.Val(Conversions.ToString(Conversion.Val(Interaction.InputBox("Give new base morale please.", "Shadow Empire : Planetary Conquest"))))));
              if (num4 > -1 & num4 < 300)
              {
                this.game.Data.RegimeObj[this.regimeNr].BaseMorale = num4;
                this.MakeregimeListGUI(this.regimeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              let mut num5: i32 =  Interaction.MsgBox( "Wrong input. between 0-300 please. Cancelled.", Title: ( "Shadow Empire : Planetary Conquest"));
            }
            else if (num1 == this.BResId)
            {
              let mut num6: i32 =  Math.Round(Conversion.Int(Conversion.Val(Conversions.ToString(Conversion.Val(Interaction.InputBox("Give new political pts please.", "Shadow Empire : Planetary Conquest"))))));
              if (num6 > -1 & num6 < 9999)
              {
                this.game.Data.RegimeObj[this.regimeNr].ResPts = num6;
                this.MakeregimeListGUI(this.regimeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              let mut num7: i32 =  Interaction.MsgBox( "Wrong input. between 0-9999 please. Cancelled.", Title: ( "Shadow Empire : Planetary Conquest"));
            }
            else
            {
              if (num1 == this.BAIId)
              {
                this.game.Data.RegimeObj[this.regimeNr].AI = !this.game.Data.RegimeObj[this.regimeNr].AI;
                this.MakeregimeListGUI(this.regimeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.altid)
              {
                this.game.Data.RegimeObj[this.regimeNr].UseAlternateActionCardPics = !this.game.Data.RegimeObj[this.regimeNr].UseAlternateActionCardPics;
                this.MakeregimeListGUI(this.regimeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.e5id)
              {
                this.game.Data.RegimeObj[this.regimeNr].Sleep = !this.game.Data.RegimeObj[this.regimeNr].Sleep;
                this.MakeregimeListGUI(this.regimeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.PbemId)
              {
                let mut num8: i32 =  Math.Round(Conversion.Int(Conversion.Val(Conversions.ToString(Conversion.Val(Interaction.InputBox("Give new PBEM++ player please. 0=auto/no-overrule. 1=player 1, 2=player 2. Remember PBEM++ games always should have 2 human players! no more no less.", "Shadow Empire : Planetary Conquest"))))));
                if (num8 >= 0 & num8 < 3)
                {
                  this.game.Data.RegimeObj[this.regimeNr].PbemPlayer = num8;
                  this.MakeregimeListGUI(this.regimeNr);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                let mut num9: i32 =  Interaction.MsgBox( "Wrong input. between 0-2 please. Cancelled.", Title: ( "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                if (num1 == this.clid)
                {
                  Form3::new( this.formref).Initialize(this.game.Data, 97, this.regimeNr);
                  this.MakeregimeListGUI(this.regimeNr);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BRedId)
                {
                  ColorDialog colorDialog = ColorDialog::new();
                  colorDialog.Color = Color.FromArgb( byte.MaxValue, this.game.Data.RegimeObj[this.regimeNr].Red, this.game.Data.RegimeObj[this.regimeNr].Green, this.game.Data.RegimeObj[this.regimeNr].Blue);
                  if (colorDialog.ShowDialog() == DialogResult.OK)
                  {
                    RegimeClass regimeClass1 = this.game.Data.RegimeObj[this.regimeNr];
                    color: Color = colorDialog.Color;
                    let mut r: i32 =  color.R;
                    regimeClass1.Red = r;
                    RegimeClass regimeClass2 = this.game.Data.RegimeObj[this.regimeNr];
                    color = colorDialog.Color;
                    let mut g: i32 =  color.G;
                    regimeClass2.Green = g;
                    RegimeClass regimeClass3 = this.game.Data.RegimeObj[this.regimeNr];
                    color = colorDialog.Color;
                    let mut b1: i32 =  color.B;
                    regimeClass3.Blue = b1;
                    this.game.Data.RegimeObj[this.regimeNr].HexBack = (Bitmap) null;
                    this.game.Data.RegimeObj[this.regimeNr].TempCounter = (Bitmap) null;
                  }
                  this.MakeregimeListGUI(this.regimeNr);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BRed3Id)
                {
                  ColorDialog colorDialog = ColorDialog::new();
                  colorDialog.Color = Color.FromArgb( byte.MaxValue, this.game.Data.RegimeObj[this.regimeNr].Red3, this.game.Data.RegimeObj[this.regimeNr].Green3, this.game.Data.RegimeObj[this.regimeNr].Blue3);
                  if (colorDialog.ShowDialog() == DialogResult.OK)
                  {
                    RegimeClass regimeClass4 = this.game.Data.RegimeObj[this.regimeNr];
                    color: Color = colorDialog.Color;
                    let mut r: i32 =  color.R;
                    regimeClass4.Red3 = r;
                    RegimeClass regimeClass5 = this.game.Data.RegimeObj[this.regimeNr];
                    color = colorDialog.Color;
                    let mut g: i32 =  color.G;
                    regimeClass5.Green3 = g;
                    RegimeClass regimeClass6 = this.game.Data.RegimeObj[this.regimeNr];
                    color = colorDialog.Color;
                    let mut b2: i32 =  color.B;
                    regimeClass6.Blue3 = b2;
                  }
                  this.MakeregimeListGUI(this.regimeNr);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BRed4Id)
                {
                  ColorDialog colorDialog = ColorDialog::new();
                  colorDialog.Color = Color.FromArgb( byte.MaxValue, this.game.Data.RegimeObj[this.regimeNr].Red4, this.game.Data.RegimeObj[this.regimeNr].Green4, this.game.Data.RegimeObj[this.regimeNr].Blue4);
                  if (colorDialog.ShowDialog() == DialogResult.OK)
                  {
                    RegimeClass regimeClass7 = this.game.Data.RegimeObj[this.regimeNr];
                    color: Color = colorDialog.Color;
                    let mut r: i32 =  color.R;
                    regimeClass7.Red4 = r;
                    RegimeClass regimeClass8 = this.game.Data.RegimeObj[this.regimeNr];
                    color = colorDialog.Color;
                    let mut g: i32 =  color.G;
                    regimeClass8.Green4 = g;
                    RegimeClass regimeClass9 = this.game.Data.RegimeObj[this.regimeNr];
                    color = colorDialog.Color;
                    let mut b3: i32 =  color.B;
                    regimeClass9.Blue4 = b3;
                  }
                  this.MakeregimeListGUI(this.regimeNr);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BRed2Id)
                {
                  ColorDialog colorDialog = ColorDialog::new();
                  colorDialog.Color = Color.FromArgb( byte.MaxValue, this.game.Data.RegimeObj[this.regimeNr].Red2, this.game.Data.RegimeObj[this.regimeNr].Green2, this.game.Data.RegimeObj[this.regimeNr].Blue2);
                  if (colorDialog.ShowDialog() == DialogResult.OK)
                  {
                    RegimeClass regimeClass10 = this.game.Data.RegimeObj[this.regimeNr];
                    color: Color = colorDialog.Color;
                    let mut r: i32 =  color.R;
                    regimeClass10.Red2 = r;
                    RegimeClass regimeClass11 = this.game.Data.RegimeObj[this.regimeNr];
                    color = colorDialog.Color;
                    let mut g: i32 =  color.G;
                    regimeClass11.Green2 = g;
                    RegimeClass regimeClass12 = this.game.Data.RegimeObj[this.regimeNr];
                    color = colorDialog.Color;
                    let mut b4: i32 =  color.B;
                    regimeClass12.Blue2 = b4;
                    this.game.Data.RegimeObj[this.regimeNr].HexBack = (Bitmap) null;
                    this.game.Data.RegimeObj[this.regimeNr].TempCounter = (Bitmap) null;
                  }
                  this.MakeregimeListGUI(this.regimeNr);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BRemoveregimeId)
                {
                  this.game.EditObj.UnitSelected = -1;
                  this.game.Data.RemoveRegime(this.regimeNr);
                  this.MakeregimeListGUI(-1);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.HighId)
                {
                  this.game.EditObj.UnitSelected = -1;
                  this.game.Data.MoveRegimeHigher(this.regimeNr);
                  this += 1.regimeNr;
                  this.MakeregimeListGUI(this.regimeNr);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.LowId)
                {
                  this.game.EditObj.UnitSelected = -1;
                  this.game.Data.MoveRegimeLower(this.regimeNr);
                  --this.regimeNr;
                  this.MakeregimeListGUI(this.regimeNr);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.BDrawId)
                {
                  this.game.EditObj.PencilType = 3;
                  this.game.EditObj.PencilData1 = this.regimeNr;
                  windowReturnClass.AddCommand(4, 13);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.OptionsListId)
                {
                  let mut num10: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.SubPartFlag[index1] = true;
                  if (num10 > -1)
                  {
                    this.TabSheetNr = num10;
                    this.maketabsheet();
                  }
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.B1Id)
                {
                  Form3::new( this.formref).Initialize(this.game.Data, 3, this.regimeNr);
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.e11id)
                {
                  Form3::new( this.formref).Initialize(this.game.Data, 55, this.regimeNr);
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.e12id)
                {
                  Form3::new( this.formref).Initialize(this.game.Data, 57, this.regimeNr);
                  this.maketabsheet();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.stringListId)
                {
                  let mut num11: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.SubPartFlag[index1] = true;
                  if (num11 > -1)
                  {
                    this.DetailNr = num11;
                    this.maketabsheet();
                  }
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.ResListId)
                {
                  let mut num12: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.SubPartFlag[index1] = true;
                  if (num12 > -1)
                  {
                    this.DetailNr = num12;
                    this.maketabsheet();
                  }
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.dipListId)
                {
                  let mut num13: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.SubPartFlag[index1] = true;
                  if (num13 > -1)
                  {
                    this.DetailNr = num13;
                    this.maketabsheet();
                  }
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.B2Id)
                {
                  let mut num14: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give new people #, please.", "Shadow Empire : Planetary Conquest")));
                  if (num14 >= -1 & num14 <= 999999)
                  {
                    this.game.Data.RegimeObj[this.regimeNr].RegimeSlot[this.DetailNr] = num14;
                    this.maketabsheet();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  let mut num15: i32 =  Interaction.MsgBox( "Wrong input. Cancelled.", Title: ( "Shadow Empire : Planetary Conquest"));
                }
                else if (num1 == this.e10id)
                {
                  let mut num16: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give extra graphic #, please.", "Shadow Empire : Planetary Conquest")));
                  if (num16 >= -1 & num16 <= 999999)
                  {
                    this.game.Data.RegimeObj[this.regimeNr].ExtraGraphicUse = num16;
                    this.maketabsheet();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  let mut num17: i32 =  Interaction.MsgBox( "Wrong input. Cancelled.", Title: ( "Shadow Empire : Planetary Conquest"));
                }
                else
                {
                  if (num1 == this.b3Id)
                  {
                    this.game.Data.RegimeObj[this.regimeNr].ResField[this.DetailNr] = !this.game.Data.RegimeObj[this.regimeNr].ResField[this.DetailNr];
                    this.maketabsheet();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (num1 == this.b5Id)
                  {
                    let mut num18: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give research level for this regime...", "Shadow Empire : Planetary Conquest")));
                    if (num18 >= -1 & num18 <= 999999)
                    {
                      let mut researchCounter: i32 = this.game.Data.ResearchCounter;
                      for (let mut index2: i32 = 0; index2 <= researchCounter; index2 += 1)
                      {
                        if (this.game.Data.ResearchObj[index2].TechLevel <= num18 & this.game.Data.ResearchObj[index2].TechLevel > 0)
                          this.game.Data.RegimeObj[this.regimeNr].ResField[index2] = true;
                        else
                          this.game.Data.RegimeObj[this.regimeNr].ResField[index2] = false;
                      }
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    let mut num19: i32 =  Interaction.MsgBox( "Wrong input. Cancelled.", Title: ( "Shadow Empire : Planetary Conquest"));
                  }
                  else if (num1 == this.b4Id)
                  {
                    if (this.DetailNr != this.regimeNr)
                    {
                      let mut num20: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give new relation please. 0=war, 1=peace, 2=allied ", "Shadow Empire : Planetary Conquest")));
                      if (num20 < 0 | num20 > 2)
                      {
                        let mut num21: i32 =  Interaction.MsgBox( "Beep. Not allowed. ", Title: ( "Shadow Empire : Planetary Conquest"));
                      }
                      else
                      {
                        this.game.Data.RegimeObj[this.regimeNr].RegimeRel[this.DetailNr] = num20;
                        this.game.Data.RegimeObj[this.DetailNr].RegimeRel[this.regimeNr] = num20;
                        this.maketabsheet();
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                    }
                    else
                    {
                      let mut num22: i32 =  Interaction.MsgBox( "You cannot change relation with your self", Title: ( "Shadow Empire : Planetary Conquest"));
                    }
                  }
                  else
                  {
                    if (num1 == this.BChangeSymbolId)
                    {
                      filename: String = this.game.HandyFunctionsObj.LoadSomething("Png (*.png)|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of HQ Symbol Sprite:", this.game.AppPath + "graphics\\", true);
                      if (File.Exists(this.game.AppPath + "graphics/" + filename))
                      {
                        this.game.Data.RegimeObj[this.regimeNr].ReplaceHQSprite(filename);
                      }
                      else
                      {
                        let mut num23: i32 =  Interaction.MsgBox( "File does not exist. Operation ordered is canceled due to this.", Title: ( "Shadow Empire : Planetary Conquest"));
                      }
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.NatIconId)
                    {
                      filename: String = this.game.HandyFunctionsObj.LoadSomething("Png (*.png)|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of National Identifier of this regime:", this.game.AppPath + "graphics\\", true);
                      if (File.Exists(this.game.AppPath + "graphics/" + filename))
                      {
                        this.game.Data.RegimeObj[this.regimeNr].ReplaceNationalSprite(filename);
                      }
                      else
                      {
                        let mut num24: i32 =  Interaction.MsgBox( "File does not exist. Operation ordered is canceled due to this.", Title: ( "Shadow Empire : Planetary Conquest"));
                      }
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.RoundelId)
                    {
                      filename: String = this.game.HandyFunctionsObj.LoadSomething("Png (*.png)|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of National Identifier of this regime:", this.game.AppPath + "graphics\\", true);
                      if (File.Exists(this.game.AppPath + "graphics/" + filename))
                      {
                        this.game.Data.RegimeObj[this.regimeNr].ReplaceRoundelSprite(filename);
                      }
                      else
                      {
                        let mut num25: i32 =  Interaction.MsgBox( "File does not exist. Operation ordered is canceled due to this.", Title: ( "Shadow Empire : Planetary Conquest"));
                      }
                      this.maketabsheet();
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.e1id)
                    {
                      this.game.Data.RegimeObj[this.regimeNr].UnitName = Interaction.InputBox("Give new UnitName.", "Shadow Empire : Planetary Conquest");
                      this.MakeregimeListGUI(this.regimeNr);
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    if (num1 == this.e2id)
                    {
                      let mut num26: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give new Unit Counter.", "Shadow Empire : Planetary Conquest")));
                      if (num26 > -1)
                      {
                        this.game.Data.RegimeObj[this.regimeNr].UnitNumber = num26;
                        this.MakeregimeListGUI(this.regimeNr);
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      let mut num27: i32 =  Interaction.MsgBox( "Invalid input", Title: ( "Shadow Empire : Planetary Conquest"));
                    }
                    else
                    {
                      if (num1 == this.e3id)
                      {
                        this.game.Data.RegimeObj[this.regimeNr].HQName = Interaction.InputBox("Give new HQName.", "Shadow Empire : Planetary Conquest");
                        this.MakeregimeListGUI(this.regimeNr);
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                      if (num1 == this.e9id)
                      {
                        let mut unitCounter: i32 = this.game.Data.UnitCounter;
                        for (let mut index3: i32 = 0; index3 <= unitCounter; index3 += 1)
                        {
                          if (this.game.Data.UnitObj[index3].Regime == this.regimeNr)
                          {
                            let mut sfCount: i32 = this.game.Data.UnitObj[index3].SFCount;
                            for (let mut index4: i32 = 0; index4 <= sfCount; index4 += 1)
                              this.game.Data.SFObj[this.game.Data.UnitObj[index3].SFList[index4]].People = this.game.Data.RegimeObj[this.regimeNr].People;
                          }
                        }
                        let mut num28: i32 =  Interaction.MsgBox( "Done", Title: ( "Shadow Empire : Planetary Conquest"));
                      }
                      else if (num1 == this.e4id)
                      {
                        let mut num29: i32 =  Math.Round(Conversion.Val(Interaction.InputBox("Give new HQ Counter.", "Shadow Empire : Planetary Conquest")));
                        if (num29 > -1)
                        {
                          this.game.Data.RegimeObj[this.regimeNr].HQNumber = num29;
                          this.MakeregimeListGUI(this.regimeNr);
                          windowReturnClass.SetFlag(true);
                          return windowReturnClass;
                        }
                        let mut num30: i32 =  Interaction.MsgBox( "Invalid input", Title: ( "Shadow Empire : Planetary Conquest"));
                      }
                      else
                      {
                        if (num1 == this.e7id)
                        {
                          this.game.Data.RegimeObj[this.regimeNr].DipBlock = !this.game.Data.RegimeObj[this.regimeNr].DipBlock;
                          this.MakeregimeListGUI(this.regimeNr);
                          windowReturnClass.SetFlag(true);
                          return windowReturnClass;
                        }
                        if (num1 == this.e8id)
                        {
                          this.game.Data.RegimeObj[this.regimeNr].HQSpriteOverrule = !this.game.Data.RegimeObj[this.regimeNr].HQSpriteOverrule;
                          this.MakeregimeListGUI(this.regimeNr);
                          windowReturnClass.SetFlag(true);
                          return windowReturnClass;
                        }
                        if (num1 == this.e13id)
                        {
                          this.game.Data.RegimeObj[this.regimeNr].Mirror = !this.game.Data.RegimeObj[this.regimeNr].Mirror;
                          this.MakeregimeListGUI(this.regimeNr);
                          windowReturnClass.SetFlag(true);
                          return windowReturnClass;
                        }
                      }
                    }
                  }
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
