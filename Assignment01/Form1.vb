Public Class frmMain
    Public Structure InventoryItem
        Public strID As String
        Public strDescription As String
        Public strQuantity As String
        Public strPrice As String
        Public strFlat As String
        Public Sub New(strIdIn As String,
                       strDescriptionIn As String,
                       strQuantityIn As String,
                       strPriceIn As String,
                       strFlatIn As String)
            strID = strIdIn
            strDescription = strDescriptionIn
            strQuantity = strQuantityIn
            strPrice = strPriceIn
            strFlat = strFlatIn
        End Sub
    End Structure

    Public Items As List(Of InventoryItem) = ReadsFile()
    Dim intCurrentItem As Integer = Items.Count - 1
    Private Sub Main(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Items.Count = 0) Then
            AddNewScreen()
        Else
            ViewInventory()
        End If
    End Sub

    Function CreatesFileForWriting() As Object
        Dim StreamWriter As System.IO.StreamWriter = System.IO.File.CreateText("input.txt")
        Return StreamWriter
    End Function

    Function ReadsFile() As List(Of InventoryItem)
        Dim ReadList = New List(Of InventoryItem)
        Try

            Dim StreamReader As System.IO.StreamReader = System.IO.File.OpenText("input.txt")

            Do Until (StreamReader.EndOfStream())
                Dim strTemp As String = StreamReader.ReadLine()
                Dim arrSplitTemp() As String = strTemp.Split(";")
                ReadList.Add(New InventoryItem(arrSplitTemp(0),
                                            arrSplitTemp(1),
                                            arrSplitTemp(2),
                                            arrSplitTemp(3),
                                            arrSplitTemp(4)))
            Loop
            StreamReader.Close()
            Return ReadList
        Catch ex As Exception
            Console.Write(ex)
            Return ReadList
        End Try
    End Function

    Function ValidateNum(sender As Object) As Boolean
        If (Not IsNumeric(sender.text)) Then
            MessageBox.Show("Must be a number")
            sender.select()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub IsNum(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtId.Validating, txtQuantity.Validating, txtUnitPrice.Validating
        ValidateNum(sender)
    End Sub

    Private Sub CalculateTotal(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim strTotal As String = "Total Inventory Value on this item : "
        If (IsNumeric(txtQuantity.Text) And IsNumeric(txtUnitPrice.Text)) Then
            If (cbFlatPrice.Checked) Then
                lblTotal.Text = strTotal & FormatCurrency(Val(txtUnitPrice.Text))
                lblTotal.Show()

            Else
                lblTotal.Text = strTotal & FormatCurrency(Val(txtUnitPrice.Text) * Val(txtQuantity.Text))
                lblTotal.Show()
            End If
        End If
    End Sub

    Private Sub AddNewScreen()
        txtId.Enabled = True
        txtId.Text = ""
        txtDescription.Enabled = True
        txtDescription.Text = ""
        txtQuantity.Enabled = True
        txtQuantity.Text = ""
        txtUnitPrice.Enabled = True
        txtUnitPrice.Text = ""
        cbFlatPrice.Enabled = True
        cbFlatPrice.Checked = False

        btnAddNew.Hide()
        btnLeft.Hide()
        btnRight.Hide()

        btnSave.Show()
        btnCancel.Show()

        Me.Text = "Inventory System - Add New"
    End Sub

    Private Sub ViewInventory()
        txtId.Enabled = False
        txtId.Text = Items(intCurrentItem).strID
        txtDescription.Enabled = False
        txtDescription.Text = Items(intCurrentItem).strDescription
        txtQuantity.Enabled = False
        txtQuantity.Text = Items(intCurrentItem).strQuantity
        txtUnitPrice.Enabled = False
        txtUnitPrice.Text = Items(intCurrentItem).strPrice
        cbFlatPrice.Enabled = False
        cbFlatPrice.Checked = Convert.ToBoolean(Items(intCurrentItem).strFlat)

        btnAddNew.Show()
        btnLeft.Show()
        btnRight.Show()

        btnSave.Hide()
        btnCancel.Hide()

        Me.Text = "Inventory System - Item " & Convert.ToString(intCurrentItem + 1) & "/" & Convert.ToString(Items.Count)
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        AddNewScreen()
    End Sub
End Class