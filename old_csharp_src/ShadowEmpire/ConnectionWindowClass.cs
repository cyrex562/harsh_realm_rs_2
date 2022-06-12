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
  public class ConnectionWindowClass : WindowClass
  {
    private int ConTypeListId;
    private ListClass ConTypeListObj;
    private int BAddConTypeId;
    private int BAddConTypeTextId;
    private int BAddConType2Id;
    private int BAddConTypeText2Id;
    private int BNameId;
    private int BNameTextId;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int BRemoveConTypeId;
    private int BRemoveConTypeTextId;
    private int BRemoveConTypeId2;
    private int BRemoveConTypeTextId2;
    private int BDrawId;
    private int BDrawTextId;
    private int BLTNrId;
    private int BLTTextId;
    private int BLTSpriteId;
    private int BLTSpriteTextId;
    private int BuildGroundListId;
    private ListClass BuildGroundListObj;
    private int ChangeBGId;
    private int ChangeBGText;
    private int B1Id;
    private int B1TextId;
    private int B2Id;
    private int B2TextId;
    private int B5Id;
    private int B5TextId;
    private int B6Id;
    private int B6TextId;
    private int b7id;
    private int b7textid;
    private int b8id;
    private int b8textid;
    private int B9Id;
    private int B9TextId;
    private int B10Id;
    private int B10TextId;
    private int B11Id;
    private int B11TextId;
    private int B12Id;
    private int B12TextId;
    private int B13Id;
    private int B13TextId;
    private int B14Id;
    private int B14TextId;
    private int B15Id;
    private int B15TextId;
    private int B16Id;
    private int B16TextId;
    private int B17Id;
    private int B17TextId;
    private int B18Id;
    private int B18TextId;
    private int B19Id;
    private int B19TextId;
    private int B21Id;
    private int B21TextId;
    private int B22Id;
    private int B22TextId;
    private int B23Id;
    private int B23TextId;
    private int[] Bitemid;
    private int[] bitemtextid;
    private int[] Bupgid;
    private int[] bupgtextid;
    private int PGListId;
    private ListClass PGListObj;
    private int B3Id;
    private int B3TextId;
    private int IGListId;
    private ListClass IGListObj;
    private int B4Id;
    private int B4TextId;
    private int LTListId;
    private ListClass LTListObj;
    private int B20Id;
    private int B20TextId;
    private int ConTypeNr;
    private int TabSheetNr;
    private int DetailNr;
    private string ss;

    public ConnectionWindowClass(ref GameClass tGame)
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

    public override void DoRefresh() => this.MakeConTypeTypeItemGUI();

    private void MakeConTypeListGUI(int tConTypenr)
    {
      if (this.ConTypeListId > 0)
        this.RemoveSubPart(this.ConTypeListId);
      if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionCount > -1)
      {
        this.ConTypeListObj = new ListClass();
        int connectionCount = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionCount;
        for (int index = 0; index <= connectionCount; ++index)
        {
          string str;
          if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionX[index] == -1)
            str = "All Hexes on Map [" + Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionMap[index])) + "] " + this.game.Data.MapObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionMap[index]].Name;
          else
            str = Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionX[index])) + "," + Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionY[index])) + " on Map [" + Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionMap[index])) + "] " + this.game.Data.MapObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].ConnectionMap[index]].Name;
          this.ConTypeListObj.add(Conversion.Str((object) index) + ") " + str, index);
        }
        ListClass conTypeListObj = this.ConTypeListObj;
        int conTypeNr = this.ConTypeNr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(conTypeListObj, 9, 200, conTypeNr, game, tHeader: "Connections", tbackbitmap: (ref local1), bbx: 10, bby: 50, overruleFont: (ref local2));
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
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.BAddConTypeId = this.AddSubPart(ref tsubpart1, 10, 250, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Add Con", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.BAddConTypeTextId = this.AddSubPart(ref tsubpart2, 50, 249, 300, 20, 0);
      this.ss = "Click to add another Con For all hexes on this Map";
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONPLUS, tDescript: this.ss);
      this.B1Id = this.AddSubPart(ref tsubpart3, 10, 280, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Add Con For Map", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 300, 20, false, tDescript: this.ss);
      this.B1TextId = this.AddSubPart(ref tsubpart4, 50, 279, 300, 20, 0);
    }

    private void MakeConTypeTypeItemGUI()
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
        SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.BRemoveConTypeId = this.AddSubPart(ref tsubpart1, 10, 310, 32, 16, 1);
        SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Remove this Con", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BRemoveConTypeTextId = this.AddSubPart(ref tsubpart2, 50, 309, 200, 20, 0);
        this.ss = "Click to remove ALL Con";
        SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
        this.BRemoveConTypeId2 = this.AddSubPart(ref tsubpart3, 10, 330, 32, 16, 1);
        SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Remove ALL Con", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BRemoveConTypeTextId2 = this.AddSubPart(ref tsubpart4, 50, 329, 200, 20, 0);
      }
      this.ss = "Click to remove ALL Con For All Hex";
      SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL, tDescript: this.ss);
      this.B2Id = this.AddSubPart(ref tsubpart5, 10, 330, 32, 16, 1);
      SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("Remove ALL Con On Map", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
      this.B2TextId = this.AddSubPart(ref tsubpart6, 50, 329, 200, 20, 0);
    }

    private void maketabsheet()
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
            if (num1 == this.ConTypeListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
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
              int map = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give map, please.", "Shadow Empire : Planetary Conquest")));
              if (!(map > -1 & map <= this.game.Data.MapCounter))
              {
                int num3 = (int) Interaction.MsgBox((object) "Invalid X", Title: ((object) "Shadow Empire : Planetary Conquest"));
                return windowReturnClass;
              }
              int x1 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give X please.", "Shadow Empire : Planetary Conquest")));
              if (x1 > -2 & x1 <= this.game.Data.MapObj[map].MapWidth)
              {
                int y1;
                if (x1 > -1)
                {
                  y1 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Y please.", "Shadow Empire : Planetary Conquest")));
                  if (!(y1 > -1 & y1 <= this.game.Data.MapObj[map].MapHeight))
                  {
                    int num4 = (int) Interaction.MsgBox((object) "Invalid Y", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
              int num5 = (int) Interaction.MsgBox((object) "Invalid map", Title: ((object) "Shadow Empire : Planetary Conquest"));
              return windowReturnClass;
            }
            if (num1 == this.B1Id)
            {
              int map = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give map, please.", "Shadow Empire : Planetary Conquest")));
              if (!(map > -1 & map <= this.game.Data.MapCounter))
              {
                int num6 = (int) Interaction.MsgBox((object) "Invalid X", Title: ((object) "Shadow Empire : Planetary Conquest"));
                return windowReturnClass;
              }
              int x2 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give X please.", "Shadow Empire : Planetary Conquest")));
              if (x2 > -2 & x2 <= this.game.Data.MapObj[map].MapWidth)
              {
                int y2;
                if (x2 > -1)
                {
                  y2 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Y please.", "Shadow Empire : Planetary Conquest")));
                  if (!(y2 > -1 & y2 <= this.game.Data.MapObj[map].MapHeight))
                  {
                    int num7 = (int) Interaction.MsgBox((object) "Invalid Y", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    return windowReturnClass;
                  }
                }
                else
                  y2 = -1;
                int mapWidth = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
                for (int index2 = 0; index2 <= mapWidth; ++index2)
                {
                  int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
                  for (int index3 = 0; index3 <= mapHeight; ++index3)
                    this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index2, index3].Addconnection(x2, y2, map);
                }
                this.MakeConTypeListGUI(this.ConTypeNr);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              int num8 = (int) Interaction.MsgBox((object) "Invalid map", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
              int mapWidth = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
              for (int index4 = 0; index4 <= mapWidth; ++index4)
              {
                int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
                for (int index5 = 0; index5 <= mapHeight; ++index5)
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
