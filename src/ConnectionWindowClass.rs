// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ConnectionWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class ConnectionWindowClass : WindowClass
  {
     int ConTypeListId;
     ListClass ConTypeListObj;
     int BAddConTypeId;
     int BAddConTypeTextId;
     int BAddConType2Id;
     int BAddConTypeText2Id;
     int BNameId;
     int BNameTextId;
     int OptionsListId;
     ListClass OptionsListObj;
     int BRemoveConTypeId;
     int BRemoveConTypeTextId;
     int BRemoveConTypeId2;
     int BRemoveConTypeTextId2;
     int BDrawId;
     int BDrawTextId;
     int BLTNrId;
     int BLTTextId;
     int BLTSpriteId;
     int BLTSpriteTextId;
     int BuildGroundListId;
     ListClass BuildGroundListObj;
     int ChangeBGId;
     int ChangeBGText;
     int B1Id;
     int B1TextId;
     int B2Id;
     int B2TextId;
     int B5Id;
     int B5TextId;
     int B6Id;
     int B6TextId;
     int b7id;
     int b7textid;
     int b8id;
     int b8textid;
     int B9Id;
     int B9TextId;
     int B10Id;
     int B10TextId;
     int B11Id;
     int B11TextId;
     int B12Id;
     int B12TextId;
     int B13Id;
     int B13TextId;
     int B14Id;
     int B14TextId;
     int B15Id;
     int B15TextId;
     int B16Id;
     int B16TextId;
     int B17Id;
     int B17TextId;
     int B18Id;
     int B18TextId;
     int B19Id;
     int B19TextId;
     int B21Id;
     int B21TextId;
     int B22Id;
     int B22TextId;
     int B23Id;
     int B23TextId;
     int[] Bitemid;
     int[] bitemtextid;
     int[] Bupgid;
     int[] bupgtextid;
     int PGListId;
     ListClass PGListObj;
     int B3Id;
     int B3TextId;
     int IGListId;
     ListClass IGListObj;
     int B4Id;
     int B4TextId;
     int LTListId;
     ListClass LTListObj;
     int B20Id;
     int B20TextId;
     int ConTypeNr;
     int TabSheetNr;
     int DetailNr;
     string ss;

    pub ConnectionWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Connections")
    {
      this.Bitemid = new int[5];
      this.bitemtextid = new int[5];
      this.Bupgid = new int[5];
      this.bupgtextid = new int[5];
      this.ConTypeNr = -1;
      this.TabSheetNr = -1;
      this.DetailNr = -1;
      this.MakeConTypeListGUI(-1);
    }

    pub void DoRefresh() => this.MakeConTypeTypeItemGUI();

     void MakeConTypeListGUI(int tConTypenr)
    {
      if (this.ConTypeListId > 0)
        this.RemoveSubPart(this.ConTypeListId);
      if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionCount > -1)
      {
        this.ConTypeListObj = ListClass::new();
        let mut connectionCount: i32 =  this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionCount;
        for (let mut index: i32 =  0; index <= connectionCount; index += 1)
        {
          string str;
          if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionX[index] == -1)
            str = "All Hexes on Map [" + Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionMap[index])) + "] " + this.game.Data.MapObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionMap[index]].Name;
          else
            str = Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionX[index])) + "," + Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionY[index])) + " on Map [" + Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionMap[index])) + "] " + this.game.Data.MapObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionMap[index]].Name;
          this.ConTypeListObj.add(Conversion.Str((object) index) + ") " + str, index);
        }
        ListClass conTypeListObj = this.ConTypeListObj;
        let mut conTypeNr: i32 =  this.ConTypeNr;
        let mut game: GameClass = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font =  null;
        ref Font local2 = ref font;
        let mut tsubpart: SubPartClass =  new ListSubPartClass(conTypeListObj, 9, 200, conTypeNr, game, tHeader: "Connections", tbackbitmap: (ref local1), bbx: 10, bby: 50, overruleFont: (ref local2));
        this.ConTypeListId = this.AddSubPart(ref tsubpart, 10, 50, 200, 192, 0);
        this.MakeConTypeTypeItemGUI();
      }
      else
        this.MakeConTypeTypeItemGUI();
      if (this.BAddConTypeId > 0)
        this.RemoveSubPart(this.BAddConTypeId);
      if (this.BAddConTypeTextId > 0)
        this.RemoveSubPart(this.BAddConTypeTextId);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      this.ss = "Click to add another Con";
      let mut tsubpart1: SubPartClass =  ButtonPartClass::new(this.game.BUTTONPLUS, tDescript: this.ss);
      this.BAddConTypeId = this.AddSubPart(ref tsubpart1, 10, 250, 32, 16, 1);
      let mut tsubpart2: SubPartClass =  TextPartClass::new("Add Con", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BAddConTypeTextId = this.AddSubPart(ref tsubpart2, 50, 249, 300, 20, 0);
      this.ss = "Click to add another Con For all hexes on this Map";
      let mut tsubpart3: SubPartClass =  ButtonPartClass::new(this.game.BUTTONPLUS, tDescript: this.ss);
      this.B1Id = this.AddSubPart(ref tsubpart3, 10, 280, 32, 16, 1);
      let mut tsubpart4: SubPartClass =  TextPartClass::new("Add Con For Map", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.B1TextId = this.AddSubPart(ref tsubpart4, 50, 279, 300, 20, 0);
    }

     void MakeConTypeTypeItemGUI()
    {
      if (this.BNameId > 0)
        this.RemoveSubPart(this.BNameId);
      if (this.BNameTextId > 0)
        this.RemoveSubPart(this.BNameTextId);
      if (this.BRemoveConTypeId > 0)
        this.RemoveSubPart(this.BRemoveConTypeId);
      if (this.BRemoveConTypeTextId > 0)
        this.RemoveSubPart(this.BRemoveConTypeTextId);
      if (this.BRemoveConTypeId2 > 0)
        this.RemoveSubPart(this.BRemoveConTypeId2);
      if (this.BRemoveConTypeTextId2 > 0)
        this.RemoveSubPart(this.BRemoveConTypeTextId2);
      if (this.BDrawId > 0)
        this.RemoveSubPart(this.BDrawId);
      if (this.BDrawTextId > 0)
        this.RemoveSubPart(this.BDrawTextId);
      if (this.OptionsListId > 0)
        this.RemoveSubPart(this.OptionsListId);
      if (this.BAddConType2Id > 0)
        this.RemoveSubPart(this.BAddConType2Id);
      if (this.BAddConTypeText2Id > 0)
        this.RemoveSubPart(this.BAddConTypeText2Id);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.ConTypeNr > -1)
      {
        this.ss = "Click to remove this Con";
        let mut tsubpart1: SubPartClass =  ButtonPartClass::new(this.game.BUTTONKILL, tDescript: this.ss);
        this.BRemoveConTypeId = this.AddSubPart(ref tsubpart1, 10, 310, 32, 16, 1);
        let mut tsubpart2: SubPartClass =  TextPartClass::new("Remove this Con", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BRemoveConTypeTextId = this.AddSubPart(ref tsubpart2, 50, 309, 200, 20, 0);
        this.ss = "Click to remove ALL Con";
        let mut tsubpart3: SubPartClass =  ButtonPartClass::new(this.game.BUTTONKILL, tDescript: this.ss);
        this.BRemoveConTypeId2 = this.AddSubPart(ref tsubpart3, 10, 330, 32, 16, 1);
        let mut tsubpart4: SubPartClass =  TextPartClass::new("Remove ALL Con", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BRemoveConTypeTextId2 = this.AddSubPart(ref tsubpart4, 50, 329, 200, 20, 0);
      }
      this.ss = "Click to remove ALL Con For All Hex";
      let mut tsubpart5: SubPartClass =  ButtonPartClass::new(this.game.BUTTONKILL, tDescript: this.ss);
      this.B2Id = this.AddSubPart(ref tsubpart5, 10, 330, 32, 16, 1);
      let mut tsubpart6: SubPartClass =  TextPartClass::new("Remove ALL Con On Map", Font::new("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B2TextId = this.AddSubPart(ref tsubpart6, 50, 329, 200, 20, 0);
    }

     void maketabsheet()
    {
      if (this.BLTNrId > 0)
        this.RemoveSubPart(this.BLTNrId);
      if (this.BLTTextId > 0)
        this.RemoveSubPart(this.BLTTextId);
      if (this.BLTSpriteId > 0)
        this.RemoveSubPart(this.BLTSpriteId);
      if (this.BLTSpriteTextId > 0)
        this.RemoveSubPart(this.BLTSpriteTextId);
      if (this.BuildGroundListId > 0)
        this.RemoveSubPart(this.BuildGroundListId);
      if (this.ChangeBGId > 0)
        this.RemoveSubPart(this.ChangeBGId);
      if (this.ChangeBGText > 0)
        this.RemoveSubPart(this.ChangeBGText);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
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
      if (this.B6Id > 0)
        this.RemoveSubPart(this.B6Id);
      if (this.B6TextId > 0)
        this.RemoveSubPart(this.B6TextId);
      if (this.b7id > 0)
        this.RemoveSubPart(this.b7id);
      if (this.b7textid > 0)
        this.RemoveSubPart(this.b7textid);
      if (this.b8id > 0)
        this.RemoveSubPart(this.b8id);
      if (this.b8textid > 0)
        this.RemoveSubPart(this.b8textid);
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
      if (this.B12Id > 0)
        this.RemoveSubPart(this.B12Id);
      if (this.B12TextId > 0)
        this.RemoveSubPart(this.B12TextId);
      if (this.B13Id > 0)
        this.RemoveSubPart(this.B13Id);
      if (this.B13TextId > 0)
        this.RemoveSubPart(this.B13TextId);
      if (this.B14Id > 0)
        this.RemoveSubPart(this.B14Id);
      if (this.B14TextId > 0)
        this.RemoveSubPart(this.B14TextId);
      if (this.B15Id > 0)
        this.RemoveSubPart(this.B15Id);
      if (this.B15TextId > 0)
        this.RemoveSubPart(this.B15TextId);
      if (this.B16Id > 0)
        this.RemoveSubPart(this.B16Id);
      if (this.B16TextId > 0)
        this.RemoveSubPart(this.B16TextId);
      if (this.B17Id > 0)
        this.RemoveSubPart(this.B17Id);
      if (this.B17TextId > 0)
        this.RemoveSubPart(this.B17TextId);
      if (this.B18Id > 0)
        this.RemoveSubPart(this.B18Id);
      if (this.B18TextId > 0)
        this.RemoveSubPart(this.B18TextId);
      if (this.B19Id > 0)
        this.RemoveSubPart(this.B19Id);
      if (this.B19TextId > 0)
        this.RemoveSubPart(this.B19TextId);
      if (this.B20Id > 0)
        this.RemoveSubPart(this.B20Id);
      if (this.B20TextId > 0)
        this.RemoveSubPart(this.B20TextId);
      if (this.B21Id > 0)
        this.RemoveSubPart(this.B21Id);
      if (this.B21TextId > 0)
        this.RemoveSubPart(this.B21TextId);
      if (this.B22Id > 0)
        this.RemoveSubPart(this.B22Id);
      if (this.B22TextId > 0)
        this.RemoveSubPart(this.B22TextId);
      if (this.B23Id > 0)
        this.RemoveSubPart(this.B23Id);
      if (this.B23TextId > 0)
        this.RemoveSubPart(this.B23TextId);
      if (this.PGListId > 0)
        this.RemoveSubPart(this.PGListId);
      if (this.IGListId > 0)
        this.RemoveSubPart(this.IGListId);
      if (this.LTListId <= 0)
        return;
      this.RemoveSubPart(this.LTListId);
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 =  this.SubPartCounter;
        for (let mut index1: i32 =  0; index1 <= subPartCounter; index1 += 1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            let mut num1: i32 =  this.SubPartID[index1];
            if (num1 == this.ConTypeListId)
            {
              let mut num2: i32 =  this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.ConTypeNr = num2;
                this.MakeConTypeTypeItemGUI();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAddConTypeId)
            {
              let mut map: i32 =  (int) Math.Round(Conversion.Val(Interaction.InputBox("Give map, please.", "Shadow Empire : Planetary Conquest")));
              if (!(map > -1 & map <= this.game.Data.MapCounter))
              {
                let mut num3: i32 =  (int) Interaction.MsgBox((object) "Invalid X", Title: ((object) "Shadow Empire : Planetary Conquest"));
                return windowReturnClass;
              }
              let mut x1: i32 =  (int) Math.Round(Conversion.Val(Interaction.InputBox("Give X please.", "Shadow Empire : Planetary Conquest")));
              if (x1 > -2 & x1 <= this.game.Data.MapObj[map].MapWidth)
              {
                int y1;
                if (x1 > -1)
                {
                  y1 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Y please.", "Shadow Empire : Planetary Conquest")));
                  if (!(y1 > -1 & y1 <= this.game.Data.MapObj[map].MapHeight))
                  {
                    let mut num4: i32 =  (int) Interaction.MsgBox((object) "Invalid Y", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    return windowReturnClass;
                  }
                }
                else
                  y1 = -1;
                this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Addconnection(x1, y1, map);
                this.MakeConTypeListGUI(this.ConTypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              let mut num5: i32 =  (int) Interaction.MsgBox((object) "Invalid map", Title: ((object) "Shadow Empire : Planetary Conquest"));
              return windowReturnClass;
            }
            if (num1 == this.B1Id)
            {
              let mut map: i32 =  (int) Math.Round(Conversion.Val(Interaction.InputBox("Give map, please.", "Shadow Empire : Planetary Conquest")));
              if (!(map > -1 & map <= this.game.Data.MapCounter))
              {
                let mut num6: i32 =  (int) Interaction.MsgBox((object) "Invalid X", Title: ((object) "Shadow Empire : Planetary Conquest"));
                return windowReturnClass;
              }
              let mut x2: i32 =  (int) Math.Round(Conversion.Val(Interaction.InputBox("Give X please.", "Shadow Empire : Planetary Conquest")));
              if (x2 > -2 & x2 <= this.game.Data.MapObj[map].MapWidth)
              {
                int y2;
                if (x2 > -1)
                {
                  y2 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Y please.", "Shadow Empire : Planetary Conquest")));
                  if (!(y2 > -1 & y2 <= this.game.Data.MapObj[map].MapHeight))
                  {
                    let mut num7: i32 =  (int) Interaction.MsgBox((object) "Invalid Y", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    return windowReturnClass;
                  }
                }
                else
                  y2 = -1;
                let mut mapWidth: i32 =  this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
                for (let mut index2: i32 =  0; index2 <= mapWidth; index2 += 1)
                {
                  let mut mapHeight: i32 =  this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
                  for (let mut index3: i32 =  0; index3 <= mapHeight; index3 += 1)
                    this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index2, index3].Addconnection(x2, y2, map);
                }
                this.MakeConTypeListGUI(this.ConTypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              let mut num8: i32 =  (int) Interaction.MsgBox((object) "Invalid map", Title: ((object) "Shadow Empire : Planetary Conquest"));
              return windowReturnClass;
            }
            if (num1 == this.BRemoveConTypeId)
            {
              this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].RemoveConnection(this.ConTypeNr);
              this.MakeConTypeListGUI(-1);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BRemoveConTypeId2)
            {
              while (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionCount > -1)
                this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].RemoveConnection(0);
              this.MakeConTypeListGUI(-1);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B2Id)
            {
              let mut mapWidth: i32 =  this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
              for (let mut index4: i32 =  0; index4 <= mapWidth; index4 += 1)
              {
                let mut mapHeight: i32 =  this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
                for (let mut index5: i32 =  0; index5 <= mapHeight; index5 += 1)
                {
                  while (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index4, index5].ConnectionCount > -1)
                    this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index4, index5].RemoveConnection(0);
                }
              }
              this.MakeConTypeListGUI(-1);
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
