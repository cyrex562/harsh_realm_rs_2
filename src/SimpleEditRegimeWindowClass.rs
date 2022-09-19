// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleEditRegimeWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingSystem;
// usingSystem.Drawing;
// usingSystem.Drawing.Drawing2D;
// usingSystem.Drawing.Text;
// usingSystem.IO;
// usingSystem.Windows.Forms;

namespace WindowsApplication1
{
  pub class SimpleEditRegimeWindowClass : WindowClass
  {
     int listId;
     ListClass listObj;
     int list2Id;
     ListClass list2Obj;
     int regId;
     int offid;
     int AddOff;
     int RemoveOff;
     int RemoveOffB;
     int AddRegime;
     int RemoveRegime;
     int ChangeFlag;
     int changeColorExt;
     int AddRegimeB;
     int RemoveRegimeB;
     int ChangeColorBack;
     int ChangeColorFront;
     int ChangeName;
     int ChangePeople;
     int ChangeIcon;
     int ChangeRoundel;
     int ChangeMirror;

    pub SimpleEditRegimeWindowClass( GameClass tGame)
      : base( tGame, tGame.ScreenWidth, tGame.ScreenHeight - 50, 9, tDoBorders: 1, tHeaderString: "Regimes")
    {
      this.regId = -1;
      this.offid = -1;
      this.DoStuff();
    }

    pub void DoRefresh() => this.DoStuff();

    pub void DoStuff()
    {
      let mut num1: i32 =  Math.Round( (this.game.ScreenWidth - 1024) / 2.0);
      if (this.listId > 0)
        this.RemoveSubPart(this.listId);
      if (this.list2Id > 0)
        this.RemoveSubPart(this.list2Id);
      if (this.AddOff > 0)
        this.RemoveSubPart(this.AddOff);
      if (this.RemoveOff > 0)
        this.RemoveSubPart(this.RemoveOff);
      if (this.RemoveOffB > 0)
        this.RemoveSubPart(this.RemoveOffB);
      if (this.AddRegime > 0)
        this.RemoveSubPart(this.AddRegime);
      if (this.AddRegimeB > 0)
        this.RemoveSubPart(this.AddRegimeB);
      if (this.RemoveRegime > 0)
        this.RemoveSubPart(this.RemoveRegime);
      if (this.RemoveRegimeB > 0)
        this.RemoveSubPart(this.RemoveRegimeB);
      if (this.ChangeColorBack > 0)
        this.RemoveSubPart(this.ChangeColorBack);
      if (this.ChangeColorFront > 0)
        this.RemoveSubPart(this.ChangeColorFront);
      if (this.changeColorExt > 0)
        this.RemoveSubPart(this.changeColorExt);
      if (this.ChangeName > 0)
        this.RemoveSubPart(this.ChangeName);
      if (this.ChangePeople > 0)
        this.RemoveSubPart(this.ChangePeople);
      if (this.ChangeIcon > 0)
        this.RemoveSubPart(this.ChangeIcon);
      if (this.ChangeRoundel > 0)
        this.RemoveSubPart(this.ChangeRoundel);
      if (this.ChangeMirror > 0)
        this.RemoveSubPart(this.ChangeMirror);
      if (this.ChangeFlag > 0)
        this.RemoveSubPart(this.ChangeFlag);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      Expression.SmoothingMode = SmoothingMode.AntiAlias;
      Expression.TextRenderingHint = TextRenderingHint.AntiAlias;
      Expression.TextContrast = 1;
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 50, -1);
      let mut num2: i32 = -1;
      let mut num3: i32 = -1;
      this.listObj = ListClass::new();
      let mut regimeCounter: i32 = this.game.Data.RegimeCounter;
      for (let mut index: i32 = 0; index <= regimeCounter; index += 1)
      {
        num2 += 1;
        this.listObj.add(Conversion.Str( index) + ") " + this.game.Data.RegimeObj[index].Name, index);
        if (this.regId == index)
          num3 = num2;
      }
      if (num3 == -1)
        this.regId = -1;
      ListClass listObj = this.listObj;
      let mut tlistselect1: i32 = num3;
      let mut game1: GameClass = this.game;
       Bitmap local1 =  this.OwnBitmap;
      let mut bbx1: i32 = 10 + num1;
      Font font =  null;
       Font local2 =  font;
      let mut tsubpart: SubPartClass =  new ListSubPartClass(listObj, 5, 300, tlistselect1, game1, true, "Regimes", tValueWidth: 0, tdotopandbottom: false, tbackbitmap: ( local1), bbx: bbx1, bby: 92, tMarcStyle: true, overruleFont: ( local2));
      this.listId = this.AddSubPart( tsubpart, 10 + num1, 72, 300, 128, 0);
      let mut num4: i32 = 198;
      if (this.game.Data.RegimeCounter < 1)
      {
        tsubpart =  new TextButtonPartClass("Add Regime", 140, "Click to add a regime",  this.OwnBitmap, 10 + num1, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.AddRegime = this.AddSubPart( tsubpart, 10 + num1, num4, 140, 35, 1);
      }
      else
      {
        tsubpart =  new TextButtonPartClass("Add Regime", 140, "Maximum 2 regime supported at the moment",  this.OwnBitmap, 10 + num1, num4, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.AddRegimeB = this.AddSubPart( tsubpart, 10 + num1, num4, 140, 35, 1);
      }
      if (this.regId > -1)
      {
        tsubpart =  new TextButtonPartClass("Remove Regime", 140, "Click to remove selected regime",  this.OwnBitmap, 150 + num1, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RemoveRegime = this.AddSubPart( tsubpart, 150 + num1, num4, 140, 35, 1);
      }
      else
      {
        tsubpart =  new TextButtonPartClass("Remove Regime", 140, "You must first select a regime.",  this.OwnBitmap, 150 + num1, num4, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RemoveRegimeB = this.AddSubPart( tsubpart, 150 + num1, 262, 140, 35, 1);
      }
      if (this.regId > -1)
      {
        DrawMod.DrawBlock( Expression, 410 + num1, 72, 600, 320, 0, 0, 0, 60);
        DrawMod.DrawTextColouredMarc( Expression, "COMMANDER POOL", this.game.MarcFont4, 430 + num1, 82, Color.White);
        let mut num5: i32 = -1;
        let mut num6: i32 = -1;
        this.list2Obj = ListClass::new();
        let mut historicalUnitCounter: i32 = this.game.Data.HistoricalUnitCounter;
        for (let mut index: i32 = 0; index <= historicalUnitCounter; index += 1)
        {
          if (this.game.Data.HistoricalUnitObj[index].CommanderName.Length > 0 & this.game.Data.HistoricalUnitObj[index].TempRegime == this.regId & this.game.Data.HistoricalUnitObj[index].Pool & this.game.HandyFunctionsObj.GetUnitByHistorical(index) == -1)
          {
            num5 += 1;
            let mut people: i32 = this.game.Data.HistoricalUnitObj[index].People;
            if (people > -1)
              this.list2Obj.add(Conversion.Str( index) + ") " + this.game.Data.HistoricalUnitObj[index].CommanderName + " (" + this.game.Data.PeopleObj[people].Name + ")", index);
            else
              this.list2Obj.add(Conversion.Str( index) + ") " + this.game.Data.HistoricalUnitObj[index].CommanderName, index);
            if (this.offid == index)
              num6 = num5;
          }
        }
        if (num3 == -1)
          this.regId = -1;
        ListClass list2Obj = this.list2Obj;
        let mut tlistselect2: i32 = num6;
        let mut game2: GameClass = this.game;
         Bitmap local3 =  this.OwnBitmap;
        let mut bbx2: i32 = 430 + num1;
        font =  null;
         Font local4 =  font;
        tsubpart =  new ListSubPartClass(list2Obj, 15, 300, tlistselect2, game2, true, "Commander Pool", tValueWidth: 0, tdotopandbottom: false, tbackbitmap: ( local3), bbx: bbx2, bby: 102, tMarcStyle: true, overruleFont: ( local4));
        this.list2Id = this.AddSubPart( tsubpart, 430 + num1, 102, 300, 288, 0);
        tsubpart =  new TextButtonPartClass("Add Commander", 200, "Click to add commander",  this.OwnBitmap, 760 + num1, 102, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.AddOff = this.AddSubPart( tsubpart, 760 + num1, 102, 200, 35, 1);
        if (this.offid > -1)
        {
          tsubpart =  new TextButtonPartClass("Remove Commander", 200, "Click to remove commander",  this.OwnBitmap, 760 + num1, 142, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.RemoveOff = this.AddSubPart( tsubpart, 760 + num1, 142, 200, 35, 1);
        }
        else
        {
          tsubpart =  new TextButtonPartClass("Remove Commander", 200, "Click to remove commander",  this.OwnBitmap, 760 + num1, 142, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.RemoveOffB = this.AddSubPart( tsubpart, 760 + num1, 142, 200, 35, 1);
        }
        let mut num7: i32 = 20 + num1;
        let mut y1: i32 = 266;
        DrawMod.DrawBlock( Expression, 10 + num1, y1 - 10, 340, 492, 0, 0, 0, 60);
        DrawMod.DrawTextColouredMarc( Expression, "Name", this.game.MarcFont4, num7, y1, Color.White);
        DrawMod.DrawTextColouredMarc( Expression, this.game.Data.RegimeObj[this.regId].Name, this.game.MarcFont3, num7, y1 + 20, Color.White);
        tsubpart =  new TextButtonPartClass("Change", 70, "Click to change the name of selected regime",  this.OwnBitmap, num7 + 250, y1 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.ChangeName = this.AddSubPart( tsubpart, num7 + 250, y1 + 5, 60, 35, 1);
        let mut y2: i32 = y1 + 52;
        DrawMod.DrawTextColouredMarc( Expression, "People", this.game.MarcFont4, num7, y2, Color.White);
        DrawMod.DrawTextColouredMarc( Expression, this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.regId].People].Name, this.game.MarcFont3, num7, y2 + 20, Color.White);
        tsubpart =  new TextButtonPartClass("Change", 70, "Click to change the people of selected regime",  this.OwnBitmap, num7 + 250, y2 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.ChangePeople = this.AddSubPart( tsubpart, num7 + 250, y2 + 5, 60, 35, 1);
        let mut y3: i32 = y2 + 52;
        DrawMod.DrawTextColouredMarc( Expression, "Counter background color", this.game.MarcFont4, num7, y3, Color.White);
        DrawMod.DrawBlock( Expression, num7, y3 + 20, 240, 16, this.game.Data.RegimeObj[this.regId].Red, this.game.Data.RegimeObj[this.regId].Green, this.game.Data.RegimeObj[this.regId].Blue,  byte.MaxValue);
        tsubpart =  new TextButtonPartClass("Change", 70, "Click to change the background color of the counter. ",  this.OwnBitmap, num7 + 250, y3 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.ChangeColorBack = this.AddSubPart( tsubpart, num7 + 250, y3 + 5, 60, 35, 1);
        let mut y4: i32 = y3 + 52;
        DrawMod.DrawTextColouredMarc( Expression, "Counter forground color", this.game.MarcFont4, num7, y4, Color.White);
        DrawMod.DrawBlock( Expression, num7, y4 + 20, 240, 16, this.game.Data.RegimeObj[this.regId].Red2, this.game.Data.RegimeObj[this.regId].Green2, this.game.Data.RegimeObj[this.regId].Blue2,  byte.MaxValue);
        tsubpart =  new TextButtonPartClass("Change", 70, "Click to change the text and siluet printing on the counters.",  this.OwnBitmap, num7 + 250, y4 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.ChangeColorFront = this.AddSubPart( tsubpart, num7 + 250, y4 + 5, 60, 35, 1);
        let mut y5: i32 = y4 + 52;
        DrawMod.DrawTextColouredMarc( Expression, "Frontline overlay color", this.game.MarcFont4, num7, y5, Color.White);
        DrawMod.DrawBlock( Expression, num7, y5 + 20, 240, 16, this.game.Data.RegimeObj[this.regId].Red3, this.game.Data.RegimeObj[this.regId].Green3, this.game.Data.RegimeObj[this.regId].Blue3,  byte.MaxValue);
        tsubpart =  new TextButtonPartClass("Change", 70, "Click to change the colour of the shading of the hexes and frontlines for this regime.",  this.OwnBitmap, num7 + 250, y5 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.changeColorExt = this.AddSubPart( tsubpart, num7 + 250, y5 + 5, 60, 35, 1);
        let mut y6: i32 = y5 + 52;
        DrawMod.DrawTextColouredMarc( Expression, "Mirror counter siluets", this.game.MarcFont4, num7, y6, Color.White);
        DrawMod.DrawTextColouredMarc( Expression, this.game.Data.RegimeObj[this.regId].Mirror.ToString(), this.game.MarcFont3, num7, y6 + 20, Color.White);
        tsubpart =  new TextButtonPartClass("Change", 70, "Click to change the mirror setting. Mirroring swaps orientation of siluet on counter.",  this.OwnBitmap, num7 + 250, y6 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.ChangeMirror = this.AddSubPart( tsubpart, num7 + 250, y6 + 5, 60, 35, 1);
        let mut y7: i32 = y6 + 52;
        DrawMod.DrawTextColouredMarc( Expression, "National icon", this.game.MarcFont4, num7, y7, Color.White);
         let mut local5: &Graphics = &Expression;
        Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[this.regId].NationalIconSprite, -1);
         let mut local6: &Bitmap = &bitmap1;
        let mut x1: i32 = num7 + 20;
        let mut y8: i32 = y7 + 23;
        DrawMod.DrawSimple( local5,  local6, x1, y8);
         let mut local7: &Graphics = &Expression;
        Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[this.regId].NationalIconSprite);
         let mut local8: &Bitmap = &bitmap2;
        let mut x2: i32 = num7 + 40;
        let mut y9: i32 = y7 + 23;
        DrawMod.DrawSimple( local7,  local8, x2, y9);
         let mut local9: &Graphics = &Expression;
        Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[this.regId].NationalIconSprite, 1);
         let mut local10: &Bitmap = &bitmap3;
        let mut x3: i32 = num7 + 60;
        let mut y10: i32 = y7 + 23;
        DrawMod.DrawSimple( local9,  local10, x3, y10);
        tsubpart =  new TextButtonPartClass("Change", 70, "Click to change the national icon of the selected regime",  this.OwnBitmap, num7 + 250, y7 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.ChangeIcon = this.AddSubPart( tsubpart, num7 + 250, y7 + 5, 60, 35, 1);
        let mut y11: i32 = y7 + 52;
        DrawMod.DrawTextColouredMarc( Expression, "Roundel sprite", this.game.MarcFont4, num7, y11, Color.White);
         let mut local11: &Graphics = &Expression;
        Bitmap bitmap4 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[this.regId].RoundelIconSprite);
         let mut local12: &Bitmap = &bitmap4;
        let mut x4: i32 = num7 + 110;
        let mut y12: i32 = y11 + 3;
        DrawMod.DrawScaled( local11,  local12, x4, y12, 64, 64, true);
        tsubpart =  new TextButtonPartClass("Change", 70, "Click to change the roundel sprite of the selected regime",  this.OwnBitmap, num7 + 230, y11 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.ChangeRoundel = this.AddSubPart( tsubpart, num7 + 250, y11 + 5, 60, 35, 1);
        let mut y13: i32 = y11 + 52;
        DrawMod.DrawTextColouredMarc( Expression, "(HQ) Flag", this.game.MarcFont4, num7, y13, Color.White);
         let mut local13: &Graphics = &Expression;
        Bitmap bitmap5 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[this.regId].HQSpriteNr, -1);
         let mut local14: &Bitmap = &bitmap5;
        let mut x5: i32 = num7 + 90;
        let mut y14: i32 = y13 + 23;
        DrawMod.DrawSimple( local13,  local14, x5, y14);
         let mut local15: &Graphics = &Expression;
        Bitmap bitmap6 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[this.regId].HQSpriteNr);
         let mut local16: &Bitmap = &bitmap6;
        let mut x6: i32 = num7 + 110;
        let mut y15: i32 = y13 + 13;
        DrawMod.DrawSimple( local15,  local16, x6, y15);
         let mut local17: &Graphics = &Expression;
        bitmap6 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[this.regId].HQSpriteNr, 1);
         let mut local18: &Bitmap = &bitmap6;
        let mut x7: i32 = num7 + 140;
        let mut y16: i32 = y13 - 3;
        DrawMod.DrawSimple( local17,  local18, x7, y16);
        tsubpart =  new TextButtonPartClass("Change", 70, "Click to change the HQ flag of the selected regime",  this.OwnBitmap, num7 + 250, y13 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.ChangeFlag = this.AddSubPart( tsubpart, num7 + 250, y13 + 5, 60, 35, 1);
      }
      if (Information.IsNothing( Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
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
            if (num1 == this.listId)
            {
              let mut num2: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              if (num2 > -1)
              {
                this.regId = num2;
                this.offid = -1;
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.list2Id)
            {
              let mut num3: i32 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              if (num3 > -1)
                this.offid = num3;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.AddOff)
            {
              Form3::new( this.formref).Initialize(this.game.Data, 102, this.regId, tGame: this.game);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.RemoveOff)
            {
              this.game.Data.HistoricalUnitObj[this.offid].Pool = false;
              this.offid = -1;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.AddRegime)
            {
              if (this.game.Data.PeopleCounter < 0)
              {
                this.game.Data.AddPeople();
                this.game.Data.PeopleObj[0].Name = "Universals";
              }
              this.game.Data.AddRegime();
              this.regId = this.game.Data.RegimeCounter;
              this.game.Data.RegimeObj[this.game.Data.RegimeCounter].Name = "Regime #" + this.game.Data.RegimeCounter.ToString();
              this.game.Data.RegimeObj[this.game.Data.RegimeCounter].People = 0;
              let mut regimeCounter: i32 = this.game.Data.RegimeCounter;
              for (let mut index2: i32 = 0; index2 <= regimeCounter; index2 += 1)
              {
                this.game.Data.RegimeObj[this.game.Data.RegimeCounter].RegimeRel[index2] = 0;
                this.game.Data.RegimeObj[index2].RegimeRel[this.game.Data.RegimeCounter] = 0;
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.RemoveRegime)
            {
              this.game.Data.RemoveRegime(this.regId);
              this.regId = -1;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeName)
            {
              this.game.Data.RegimeObj[this.regId].Name = Interaction.InputBox("Give new name, please.", "Shadow Empire : Planetary Conquest");
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangePeople)
            {
              Form3::new( this.formref).Initialize(this.game.Data, 3, this.regId);
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeColorBack)
            {
              ColorDialog colorDialog = ColorDialog::new();
              colorDialog.Color = Color.FromArgb( byte.MaxValue, this.game.Data.RegimeObj[this.regId].Red, this.game.Data.RegimeObj[this.regId].Green, this.game.Data.RegimeObj[this.regId].Blue);
              if (colorDialog.ShowDialog() == DialogResult.OK)
              {
                RegimeClass regimeClass1 = this.game.Data.RegimeObj[this.regId];
                Color color = colorDialog.Color;
                let mut r: i32 =  color.R;
                regimeClass1.Red = r;
                RegimeClass regimeClass2 = this.game.Data.RegimeObj[this.regId];
                color = colorDialog.Color;
                let mut g: i32 =  color.G;
                regimeClass2.Green = g;
                RegimeClass regimeClass3 = this.game.Data.RegimeObj[this.regId];
                color = colorDialog.Color;
                let mut b1: i32 =  color.B;
                regimeClass3.Blue = b1;
                this.game.Data.RegimeObj[this.regId].HexBack = (Bitmap) null;
                this.game.Data.RegimeObj[this.regId].TempCounter = (Bitmap) null;
                this.game.Data.RegimeObj[this.regId].DoTempCounter();
                this.game.Data.RegimeObj[this.regId].DoTempCounterBig();
                this.game.Data.RegimeObj[this.regId].DoTempCounterSmall();
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeColorFront)
            {
              ColorDialog colorDialog = ColorDialog::new();
              colorDialog.Color = Color.FromArgb( byte.MaxValue, this.game.Data.RegimeObj[this.regId].Red2, this.game.Data.RegimeObj[this.regId].Green2, this.game.Data.RegimeObj[this.regId].Blue2);
              if (colorDialog.ShowDialog() == DialogResult.OK)
              {
                RegimeClass regimeClass4 = this.game.Data.RegimeObj[this.regId];
                Color color = colorDialog.Color;
                let mut r: i32 =  color.R;
                regimeClass4.Red2 = r;
                RegimeClass regimeClass5 = this.game.Data.RegimeObj[this.regId];
                color = colorDialog.Color;
                let mut g: i32 =  color.G;
                regimeClass5.Green2 = g;
                RegimeClass regimeClass6 = this.game.Data.RegimeObj[this.regId];
                color = colorDialog.Color;
                let mut b2: i32 =  color.B;
                regimeClass6.Blue2 = b2;
                this.game.Data.RegimeObj[this.regId].HexBack = (Bitmap) null;
                this.game.Data.RegimeObj[this.regId].TempCounter = (Bitmap) null;
                this.game.Data.RegimeObj[this.regId].DoTempCounter();
                this.game.Data.RegimeObj[this.regId].DoTempCounterBig();
                this.game.Data.RegimeObj[this.regId].DoTempCounterSmall();
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.changeColorExt)
            {
              ColorDialog colorDialog = ColorDialog::new();
              colorDialog.Color = Color.FromArgb( byte.MaxValue, this.game.Data.RegimeObj[this.regId].Red3, this.game.Data.RegimeObj[this.regId].Green3, this.game.Data.RegimeObj[this.regId].Blue3);
              if (colorDialog.ShowDialog() == DialogResult.OK)
              {
                RegimeClass regimeClass7 = this.game.Data.RegimeObj[this.regId];
                Color color = colorDialog.Color;
                let mut r: i32 =  color.R;
                regimeClass7.Red3 = r;
                RegimeClass regimeClass8 = this.game.Data.RegimeObj[this.regId];
                color = colorDialog.Color;
                let mut g: i32 =  color.G;
                regimeClass8.Green3 = g;
                RegimeClass regimeClass9 = this.game.Data.RegimeObj[this.regId];
                color = colorDialog.Color;
                let mut b3: i32 =  color.B;
                regimeClass9.Blue3 = b3;
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeIcon)
            {
              filename: String = this.game.HandyFunctionsObj.LoadSomething("Png (*.png)|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of National Identifier of this regime:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.RegimeObj[this.regId].ReplaceNationalSprite(filename);
              }
              else
              {
                let mut num4: i32 =  Interaction.MsgBox( "File does not exist. Operation ordered is canceled due to this.", Title: ( "Shadow Empire : Planetary Conquest"));
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeFlag)
            {
              filename: String = this.game.HandyFunctionsObj.LoadSomething("Png (*.png)|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of HQ Symbol Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.RegimeObj[this.regId].ReplaceHQSprite(filename);
              }
              else
              {
                let mut num5: i32 =  Interaction.MsgBox( "File does not exist. Operation ordered is canceled due to this.", Title: ( "Shadow Empire : Planetary Conquest"));
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeRoundel)
            {
              filename: String = this.game.HandyFunctionsObj.LoadSomething("Png (*.png)|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of National Identifier of this regime:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.RegimeObj[this.regId].ReplaceRoundelSprite(filename);
              }
              else
              {
                let mut num6: i32 =  Interaction.MsgBox( "File does not exist. Operation ordered is canceled due to this.", Title: ( "Shadow Empire : Planetary Conquest"));
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.ChangeMirror)
            {
              this.game.Data.RegimeObj[this.regId].Mirror = !this.game.Data.RegimeObj[this.regId].Mirror;
              this.DoStuff();
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
