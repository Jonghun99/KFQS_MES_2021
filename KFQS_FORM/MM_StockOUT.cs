#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM_StockOUT
//   Form Name    : 자재 생산 출고 관리
//   Name Space   : KFQS_Form
//   Created Date : 2020/08
//   Made By      : LJH
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
    public partial class MM_StockOUT : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성
        Common _Common             = new Common();
        string plantCode           = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public MM_StockOUT()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void MM_StockOUT_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "확정", true, GridColDataType_emu.CheckBox, 100, 120, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",      "공장",        true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",       "입고일자", true, GridColDataType_emu.DateTime24, 100, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 200, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", true, GridColDataType_emu.VarChar, 200, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNUM", "LOTNO", true, GridColDataType_emu.VarChar, 200, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "수량", true, GridColDataType_emu.VarChar, 200, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 200, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고", true, GridColDataType_emu.VarChar, 200, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "입고자", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장                                                                                               // 콤보박스 생성
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", ""); // 콤보박스에 값 넣음 
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");                                                            // 그리드 박스도 콤보박스로

            rtnDtTemp = _Common.GET_ItemCodeFERT_Code("ROH");    // 품목
            Common.FillComboboxMaster(this.cmbItemCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");


            rtnDtTemp = _Common.Standard_CODE("WHCODE","MINORCODE = 'WH003'");  // 출고창고                                                                                              
            Common.FillComboboxMaster(this.cmbWHCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", ""); 
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");                                                           

            rtnDtTemp = _Common.Standard_CODE("STORAGELOCCODE","RELCODE1 = 'WH003'");  // 출고저장위치                                                                                            
            Common.FillComboboxMaster(this.cmbLocationCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", ""); 
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");                                                           

            // 품목코드 
            //FP  : 완제품
            //OM  : 외주가공품
            //R/M : 원자재
            //S/M : 부자재(H / W)
            //SFP : 반제품
            rtnDtTemp = _Common.GET_ItemCodeFERT_Code("FERT");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
            base.DoInquire();
            DBHelper helper = new DBHelper(false);
            try
            {
                string sPlantCode      = Convert.ToString(cboPlantCode.Value);
                string sItemCode       = Convert.ToString(cmbItemCode.Value);
                string sLotNo = Convert.ToString(txtLotNo.Text);
                string sWHCode = Convert.ToString(cmbWHCode.Value);
                string sLocationCode   = Convert.ToString(cmbLocationCode.Value);
                string sStart = string.Format("{0:yyyy-MM-dd}", dtpStart.Value);
                string sEnd = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);

                DataTable rtnDtTemp = new DataTable();
                rtnDtTemp = helper.FillTable("18MM_StockOUT_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE",      sPlantCode,      DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ITEMCODE", sItemCode,      DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("MATLOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("WHCODE", sWHCode,    DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("STORAGELOCCODE", sLocationCode,    DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("STARTDATE", sStart, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ENDDATE", sEnd, DbType.String, ParameterDirection.Input)
                                    );
               this.ClosePrgForm();
               this.grid1.DataSource = rtnDtTemp;
                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    ShowDialog("조회할 데이터가 없습니다.", DC00_WinForm.DialogForm.DialogType.OK);
                }
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
            base.DoNew();
            try
            {
                this.grid1.InsertRow();
                this.grid1.SetDefaultValue("PLANTCODE", this.plantCode);

                grid1.ActiveRow.Cells["PLANTCODE"].Activation      = Activation.NoEdit;
                grid1.ActiveRow.Cells["LOTNO"].Activation         = Activation.NoEdit;
                grid1.ActiveRow.Cells["ITEMCODE"].Activation     = Activation.NoEdit;
                grid1.ActiveRow.Cells["STOCKQTY"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["UNITCODE"].Activation       = Activation.NoEdit;
                grid1.ActiveRow.Cells["WHCODE"].Activation    = Activation.NoEdit;
                grid1.ActiveRow.Cells["STRORAGELOCCODE"].Activation      = Activation.NoEdit;
                grid1.ActiveRow.Cells["WORKERID"].Activation    = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString());
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {   
           if (Convert.ToString(grid1.ActiveRow.Cells["CHK"].Value) == "1")
            {
                ShowDialog("작업지시 확정 내역을 취소후 삭제 하세요.", DialogForm.DialogType.OK);
                return;
            }
            base.DoDelete();
            grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            // 그리드에 표현된 내용을 소스 바인딩에 포함한다.
            this.grid1.UpdateData();

            DataTable dtTemp = new DataTable();
            dtTemp = grid1.chkChange();

            if (dtTemp == null) return;

            DBHelper helper = new DBHelper("",true); // 헬퍼 호출
            try
            {
                this.Focus();

                if (this.ShowDialog("등록한 데이터를 저장 하시겠습니까?") == System.Windows.Forms.DialogResult.Cancel) // val
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in dtTemp.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("18MM_StockOUT_D1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", plantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PLANNO", drRow["PLANNO"], DbType.String, ParameterDirection.Input)
                                                                    );

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            string sErrorMsg = string.Empty;
                            if (Convert.ToString(drRow["ITEMCODE"]) == "")
                            {
                                sErrorMsg += "품목 ";
                            }
                            if (Convert.ToString(drRow["PLANQTY"]) == "")
                            {
                                sErrorMsg += "수량 ";
                            }
                            if (Convert.ToString(drRow["WORKCENTERCODE"]) == "")
                            {
                                sErrorMsg += "작업장 ";
                            }
                            if (sErrorMsg != "")
                            {
                                this.ClosePrgForm();
                                ShowDialog(sErrorMsg + "을 입력하지 않았습니다", DialogForm.DialogType.OK);
                                return;
                            }
                            helper.ExecuteNoneQuery("18MM_StockOUT_I1", CommandType.StoredProcedure
                                                  , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("ITEMCODE", drRow["ITEMCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("PLANQTY", Convert.ToString(drRow["PLANQTY"]).Replace(",", ""), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("UNITCODE", drRow["UNITCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("WORKCENTERCODE", drRow["WORKCENTERCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                  );

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            string sOrderFalg = string.Empty;
                            if (Convert.ToString(drRow["CHK"]).ToUpper() == "1") sOrderFalg = "Y";
                            else sOrderFalg = "N";

                            helper.ExecuteNoneQuery("18MM_StockOUT_U1", CommandType.StoredProcedure
                                                  , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("PLANNO", drRow["PLANNO"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("ORDERFLAG", sOrderFalg, DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                  );


                            #endregion
                            break;
                    }
                }
                if (helper.RSCODE != "S")
                {
                    this.ClosePrgForm();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                    return;
                }
                helper.Commit();
                this.ClosePrgForm();
                this.ShowDialog("R00002", DialogForm.DialogType.OK);    // 데이터가 저장 되었습니다.
                DoInquire();
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

    }
}




