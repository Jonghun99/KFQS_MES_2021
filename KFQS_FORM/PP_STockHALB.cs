﻿#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_StockHALB
//   Form Name    : 자재 재고관리 
//   Name Space   : KFQS_Form
//   Created Date : 2020/08
//   Made By      : DSH
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using DC_POPUP;

using DC00_assm;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
#endregion

namespace KFQS_Form
{
    public partial class PP_StockHALB : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성
        Common _Common             = new Common();
        string plantCode           = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public PP_StockHALB()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void PP_StockHALB_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",      "공장",     true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",       "품목",     true, GridColDataType_emu.VarChar,    140, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",       "품목명",   true, GridColDataType_emu.VarChar,    140, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE",       "품목구분",   true, GridColDataType_emu.VarChar,    140, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO",       "LOTNO",     true, GridColDataType_emu.VarChar,   120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE",       "작업장",     true, GridColDataType_emu.VarChar,   120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME",       "작업장명",     true, GridColDataType_emu.VarChar,   120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY",       "재고수량", true, GridColDataType_emu.Double,     100, 120, Infragistics.Win.HAlign.Right,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",       "단위",     true, GridColDataType_emu.VarChar,    100, 120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("ITEMTYPE");    
            Common.FillComboboxMaster(this.cboItemCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            // 품목코드 
            //FP  : 완제품
            //OM  : 외주가공품
            //R/M : 원자재
            //S/M : 부자재(H / W)
            //SFP : 반제품


            #endregion

            #region ▶ POP-UP ◀
            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode.Value = plantCode;
            #endregion
        }
        #endregion


        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            DoFind();
        }
        private void DoFind()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();
                _GridUtil.Grid_Clear(grid1);
                string sPlantCode      = DBHelper.nvlString(this.cboPlantCode.Value);
                string sItemtype       = DBHelper.nvlString(this.cboItemCode.Value);
                string sLotNo          = DBHelper.nvlString(txtLotNo.Text);

                rtnDtTemp = helper.FillTable("18PP_STockHALB_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE",   sPlantCode,  DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ITEMTYPE",    sItemtype,   DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("LOTNO",       sLotNo,      DbType.String, ParameterDirection.Input)
                                    );

               this.ClosePrgForm();
               this.grid1.DataSource = rtnDtTemp;
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(),DialogForm.DialogType.OK);    
            }
            finally
            {
                helper.Close();
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {   
           
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
        }
        #endregion

    }
}




