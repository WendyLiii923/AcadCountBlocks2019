Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Interop
Imports System.Xml

Public Class frmMain

#Region "   Declaration   "
    Private LstrAutocadAppName As String = "AutoCAD.Application"
    Private LobjACAD As AcadApplication
    Private LstrFilePath As String      '紀錄當前檔案位置
    Private LobjXML As XmlDocument = Nothing, LobjRoot As XmlNode = Nothing
    Private LhtAttTypeDef As New Hashtable
    Private LhtAttManufTypeDef As New Hashtable
    Private LhtAttManufTypeValidateCheckDef As New Hashtable

    Private acObjSels As AcadSelectionSet = Nothing
    Private acObjSel As AcadSelectionSet = Nothing
    Private acDocActive As AcadDocument = Nothing

    Public GstrMainBlockName As String
    Public GacMainBlock As AcadBlockReference
    Public GFilterType() As Short
    Public GFilterData() As Object
#End Region

#Region "視窗狀態"
    Public Declare Function SetForegroundWindow Lib "user32" (ByVal hWnd As IntPtr) As Long
    Public Declare Function IsIconic Lib "user32" (ByVal hwnd As IntPtr) As Boolean   '是否最小化
    Public Declare Function ShowWindowAsync Lib "user32" (ByVal hwnd As IntPtr, ByVal intCmdShow As Integer) As Boolean '視窗顯示
    '設定視窗型式
    '設定視窗型式常數
    Private Const SW_HIDE As Integer = 0
    Private Const SW_NORMAL As Integer = 1
    Private Const SW_MAXIMIZE As Integer = 3
    Private Const SW_SHOWNOACTIVATE As Integer = 4
    Private Const SW_SHOW As Integer = 5
    Private Const SW_MINIMIZE As Integer = 6
    Private Const SW_RESTORE As Integer = 9
    Private Const SW_SHOWDEFAULT As Integer = 10
#End Region
#Region "Load"
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LobjACAD = GetObject(, LstrAutocadAppName)
            If LobjACAD Is Nothing Then
                Try
                    LobjACAD = CType(CreateObject(LstrAutocadAppName), AcadApplication)
                Catch ex As Exception
                    MessageBox.Show(ex.Message & System.Environment.NewLine & ex.StackTrace)
                End Try
                If LobjACAD Is Nothing Then
                    MessageBox.Show("尚未開啟ACAD")
                    Me.Close()
                    Exit Try
                End If
            End If

            '找到圖面上有的圖塊名稱並匯入選單
            'Dim AcadObj As AcadObject
            'Dim BlockRef As AcadBlockReference
            'Dim acDocActive As AcadDocument = Nothing

            'If CheckAcadState(False) = False Then Exit Sub
            'acDocActive = LobjACAD.ActiveDocument
            'DeleteSpecifiedSet(LobjACAD, acDocActive, "AttrSelections")

            'For Each AcadObj In acDocActive.ModelSpace
            '    If TypeOf AcadObj Is AcadBlockReference Then

            '        BlockRef = AcadObj
            '        If cobBlockName.Items.Contains(BlockRef.EffectiveName) Then
            '            'NULL
            '        Else
            '            Me.cobBlockName.Items.Add(BlockRef.EffectiveName)
            '        End If
            '    End If
            'Next
        Catch ex As Exception
            MessageBox.Show(ex.Message & System.Environment.NewLine & ex.StackTrace)
        End Try
    End Sub
#End Region

    '選取範圍
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        Try
            If CheckAcadState(False) = False Then Exit Sub
            acDocActive = LobjACAD.ActiveDocument
            Me.Visible = False
            DeleteSpecifiedSet(LobjACAD, acDocActive, "BlocksSelections")
            acObjSels = acDocActive.SelectionSets.Add("BlocksSelections")
            acObjSels.SelectOnScreen()
            Me.Visible = True

            '沒選範圍
            If acObjSels Is Nothing Then
                txtSelectState.Text = "整張圖面"
            Else '有選範圍                
                txtSelectState.Text = "所選區域"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & System.Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    '選取圖塊
        Private Sub btnSelectBlock_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectBlock.Click
        Dim objBlockRef As AcadBlockReference = Nothing
        Try
            '沒選範圍
            If acObjSels Is Nothing Then
                txtSelectState.Text = "整張圖面"
            Else '有選範圍                
                txtSelectState.Text = "所選區域"
            End If

            If CheckAcadState(False) = False Then Exit Sub
            acDocActive = LobjACAD.ActiveDocument
            Me.Visible = False
            DeleteSpecifiedSet(LobjACAD, acDocActive, "BlockSelections")
            acObjSel = acDocActive.SelectionSets.Add("BlockSelections")
            acObjSel.SelectOnScreen()
            Me.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message & System.Environment.NewLine & ex.StackTrace)
        End Try

        Try
            If acObjSel.Count > 1 Then
                Throw New Exception("只能選擇一個圖塊，請重新選擇")
            End If
            If TypeOf acObjSel.Item(0) Is AcadBlockReference Then
                objBlockRef = acObjSel.Item(0)
                txtBlockName.Text = objBlockRef.EffectiveName
            Else
                Throw New System.Exception("只能選擇圖塊類型，請重新選擇")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '計算圖塊數量
    Private Sub btnCountBlock_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountBlock.Click
        Dim objBlockRefs As AcadBlockReference = Nothing
        Dim objBlockRef As AcadBlockReference = Nothing
        Dim intI As Integer = 0

        Try
            If acObjSel Is Nothing Then
                Throw New Exception("沒有選取要計算的圖塊，請重新選取")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            If CheckAcadState(False) = False Then Exit Sub
            acDocActive = LobjACAD.ActiveDocument

            objBlockRef = acObjSel.Item(0)

            lblSecond.Visible = True
            '沒選範圍
            If acObjSels Is Nothing Then

                For Each AcadObj In acDocActive.ModelSpace
                    If TypeOf AcadObj Is AcadBlockReference Then
                        objBlockRefs = AcadObj
                        If objBlockRefs.EffectiveName = objBlockRef.EffectiveName Then
                            intI += 1
                        End If
                    End If
                    lblSecond.Text = "Loading"
                    lblSecond.Text = "Loading."
                    lblSecond.Text = "Loading.."
                    lblSecond.Text = "Loading..."
                Next
                lblSecond.Visible = False
                txtBlockQty.Text = intI
                txtSelectState.Text = "整張圖面"
            Else '有選範圍
                For Each AcadObj In acObjSels
                    If TypeOf AcadObj Is AcadBlockReference Then
                        objBlockRefs = AcadObj
                        If objBlockRefs.EffectiveName = objBlockRef.EffectiveName Then
                            intI += 1
                        End If
                    End If
                    lblSecond.Text = "Loading"
                    lblSecond.Text = "Loading."
                    lblSecond.Text = "Loading.."
                    lblSecond.Text = "Loading..."
                Next
                lblSecond.Visible = False
                txtBlockQty.Text = intI
                txtSelectState.Text = "所選區域"
            End If
            acObjSels = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message & System.Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

#Region "   Private Fucntion   "
    '確認ACAD當前狀態
    Private Function CheckAcadState(Optional ByVal blnFocusAcad As Boolean = True) As Boolean
        CheckAcadState = False
        Try

            If LobjACAD.GetAcadState.IsQuiescent = False Then Exit Try
            If LobjACAD.Documents.Count = 0 Then
                MessageBox.Show("尚未開啟ACAD圖檔")
                Exit Try
            End If
            If LobjACAD.ActiveDocument.FullName = "" Then
                MessageBox.Show("請先將本圖儲存後，在執行")
                Exit Try
            End If
            If blnFocusAcad Then
                SetForegroundWindow(CType(LobjACAD.HWND, System.IntPtr))
            End If
            CheckAcadState = True
        Catch ex As Exception
            MessageBox.Show(ex.Message & System.Environment.NewLine & ex.StackTrace)
        End Try
    End Function

    '刪除特定的AcadSelectionSet
    Public Sub DeleteSpecifiedSet(ByVal acACAD As AcadApplication, ByVal acDocActive As AcadDocument, ByVal strSpecifiedSetName As String)
        Dim objSelectionSet As AcadSelectionSet
        Dim objSelectionSets As AcadSelectionSets

        Try
            'If acDocActive Is Nothing OrElse acDocActive.Application.GetAcadState.IsQuiescent = False Then
            'AcadDocument如果在使用者操作時使用，會造成異常狀況
            If acDocActive Is Nothing OrElse acACAD.GetAcadState.IsQuiescent = False Then
                Exit Try
            End If

            objSelectionSets = acDocActive.SelectionSets
            For Each objSelectionSet In objSelectionSets
                If objSelectionSet.Name.Trim = strSpecifiedSetName.Trim Then
                    objSelectionSet.Delete()
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message & System.Environment.NewLine & ex.StackTrace)
        End Try
    End Sub


#End Region

#Region "   沒有用到   "
    '顯示目前版本
    'Private Sub btnFindVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVer.Click
    '    Dim acDocActive As AcadDocument = Nothing
    '    Dim acObjSel As AcadSelectionSet = Nothing
    '    Dim strT As String = Nothing
    '    Dim FilterType(0) As Short, FilterData(0) As Object
    '    Dim acEntity As AcadEntity = Nothing
    '    Dim xTypeOut As Object = Nothing
    '    Dim xdataOut As Object = Nothing
    '    Dim objBlockRef As AcadBlockReference
    '    Dim arrAttributes As Array
    '    Dim strTag As String
    '    Dim strText As String

    '    Try
    '        If CheckAcadState(False) = False Then Exit Sub
    '        acDocActive = LobjACAD.ActiveDocument
    '        DeleteSpecifiedSet(LobjACAD, acDocActive, "AttrSelections")

    '        FilterType(0) = 2 : FilterData(0) = "AX"

    '        acObjSel = acDocActive.SelectionSets.Add("AttrSelections")
    '        acObjSel.Select(AcSelect.acSelectionSetAll, FilterType:=FilterType, FilterData:=FilterData)

    '        If acObjSel.Count > 0 Then
    '            objBlockRef = CType(acObjSel.Item(0), AcadBlockReference)
    '            arrAttributes = objBlockRef.GetAttributes

    '            For intI = LBound(arrAttributes) To UBound(arrAttributes)
    '                strTag = arrAttributes(intI).TagString
    '                strText = arrAttributes(intI).TextString

    '                If strTag = "$MOD_NO1" Then
    '                    MessageBox.Show("目前版本為 " + strText)
    '                End If
    '            Next
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message & System.Environment.NewLine & ex.StackTrace)
    '    Finally
    '        DeleteSpecifiedSet(LobjACAD, acDocActive, "SelectManufSelections")
    '        Me.Visible = True
    '    End Try
    'End Sub

    '修改版本
    'Private Sub btnModifyVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModifyVer.Click
    '    Dim acDocActive As AcadDocument = Nothing
    '    Dim acObjSel As AcadSelectionSet = Nothing
    '    Dim strT As String = Nothing
    '    Dim FilterType(0) As Short, FilterData(0) As Object
    '    Dim acEntity As AcadEntity = Nothing
    '    Dim xTypeOut As Object = Nothing
    '    Dim xdataOut As Object = Nothing
    '    Dim objBlockRef As AcadBlockReference
    '    Dim arrAttributes As Array
    '    Dim strTag As String

    '    Try
    '        If CheckAcadState(False) = False Then Exit Sub
    '        acDocActive = LobjACAD.ActiveDocument

    '        DeleteSpecifiedSet(LobjACAD, acDocActive, "AttrSelections")
    '        acObjSel = acDocActive.SelectionSets.Add("AttrSelections")

    '        FilterType(0) = 2 : FilterData(0) = "AX"
    '        acObjSel.Select(AcSelect.acSelectionSetAll, FilterType:=FilterType, FilterData:=FilterData)

    '        If acObjSel.Count > 0 Then
    '            objBlockRef = CType(acObjSel.Item(0), AcadBlockReference)
    '            arrAttributes = objBlockRef.GetAttributes

    '            For intI = LBound(arrAttributes) To UBound(arrAttributes)
    '                strTag = arrAttributes(intI).TagString.Trim
    '                If strTag = "$MOD_NO1" Then
    '                    If txtVer.Text <> String.Empty Then
    '                        arrAttributes(intI).TextString = txtVer.Text
    '                        arrAttributes(intI).Update()
    '                        MessageBox.Show("修改完成")
    '                    Else
    '                        MessageBox.Show("請輸入新版本")
    '                    End If
    '                End If
    '            Next
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message & System.Environment.NewLine & ex.StackTrace)
    '    Finally
    '        DeleteSpecifiedSet(LobjACAD, acDocActive, "SelectManufSelections")
    '        Me.Visible = True
    '    End Try
    'End Sub

    '關閉程式
    'Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
    '    Try
    '        Me.Close()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message & System.Environment.NewLine & ex.StackTrace)
    '    End Try
    'End Sub
#End Region

End Class

