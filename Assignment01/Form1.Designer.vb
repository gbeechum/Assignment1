<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblId = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
        Me.txtUnitPrice = New System.Windows.Forms.TextBox()
        Me.cbFlatPrice = New System.Windows.Forms.CheckBox()
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnLeft = New System.Windows.Forms.Button()
        Me.btnRight = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(12, 10)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(30, 20)
        Me.lblId.TabIndex = 0
        Me.lblId.Text = "ID:"
        Me.lblId.UseWaitCursor = True
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(111, 7)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(350, 26)
        Me.txtId.TabIndex = 1
        Me.txtId.UseWaitCursor = True
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(467, 13)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(93, 20)
        Me.lblDescription.TabIndex = 2
        Me.lblDescription.Text = "Description:"
        Me.lblDescription.UseWaitCursor = True
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(579, 10)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(350, 26)
        Me.txtDescription.TabIndex = 3
        Me.txtDescription.UseWaitCursor = True
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Location = New System.Drawing.Point(12, 68)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(72, 20)
        Me.lblQuantity.TabIndex = 4
        Me.lblQuantity.Text = "Quantity:"
        Me.lblQuantity.UseWaitCursor = True
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(111, 69)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(350, 26)
        Me.txtQuantity.TabIndex = 5
        Me.txtQuantity.UseWaitCursor = True
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.AutoSize = True
        Me.lblUnitPrice.Location = New System.Drawing.Point(467, 68)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Size = New System.Drawing.Size(109, 20)
        Me.lblUnitPrice.TabIndex = 6
        Me.lblUnitPrice.Text = "Per Unit Price:"
        Me.lblUnitPrice.UseWaitCursor = True
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.Location = New System.Drawing.Point(579, 65)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(350, 26)
        Me.txtUnitPrice.TabIndex = 7
        Me.txtUnitPrice.UseWaitCursor = True
        '
        'cbFlatPrice
        '
        Me.cbFlatPrice.AutoSize = True
        Me.cbFlatPrice.Location = New System.Drawing.Point(579, 126)
        Me.cbFlatPrice.Name = "cbFlatPrice"
        Me.cbFlatPrice.Size = New System.Drawing.Size(276, 24)
        Me.cbFlatPrice.TabIndex = 8
        Me.cbFlatPrice.Text = "Flat Price Regardless of Quantity?"
        Me.cbFlatPrice.UseVisualStyleBackColor = True
        Me.cbFlatPrice.UseWaitCursor = True
        '
        'btnCalculate
        '
        Me.btnCalculate.Location = New System.Drawing.Point(12, 238)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(917, 50)
        Me.btnCalculate.TabIndex = 9
        Me.btnCalculate.Text = "Calculate Inventory Item Value"
        Me.btnCalculate.UseVisualStyleBackColor = True
        Me.btnCalculate.UseWaitCursor = True
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(12, 186)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 20)
        Me.lblTotal.TabIndex = 12
        Me.lblTotal.UseWaitCursor = True
        Me.lblTotal.Visible = False
        '
        'btnLeft
        '
        Me.btnLeft.Location = New System.Drawing.Point(12, 324)
        Me.btnLeft.Name = "btnLeft"
        Me.btnLeft.Size = New System.Drawing.Size(175, 50)
        Me.btnLeft.TabIndex = 14
        Me.btnLeft.Text = "<<"
        Me.btnLeft.UseVisualStyleBackColor = True
        Me.btnLeft.UseWaitCursor = True
        Me.btnLeft.Visible = False
        '
        'btnRight
        '
        Me.btnRight.Location = New System.Drawing.Point(754, 324)
        Me.btnRight.Name = "btnRight"
        Me.btnRight.Size = New System.Drawing.Size(175, 50)
        Me.btnRight.TabIndex = 15
        Me.btnRight.Text = ">>"
        Me.btnRight.UseVisualStyleBackColor = True
        Me.btnRight.UseWaitCursor = True
        Me.btnRight.Visible = False
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(193, 324)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(555, 50)
        Me.btnAddNew.TabIndex = 16
        Me.btnAddNew.Text = "Add New Inventory Item"
        Me.btnAddNew.UseVisualStyleBackColor = True
        Me.btnAddNew.UseWaitCursor = True
        Me.btnAddNew.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(275, 410)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(175, 50)
        Me.btnSave.TabIndex = 18
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.UseWaitCursor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(491, 410)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(175, 50)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.UseWaitCursor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 477)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnRight)
        Me.Controls.Add(Me.btnLeft)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.btnCalculate)
        Me.Controls.Add(Me.cbFlatPrice)
        Me.Controls.Add(Me.txtUnitPrice)
        Me.Controls.Add(Me.lblUnitPrice)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.lblId)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "Inventory System - Add New"
        Me.UseWaitCursor = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblId As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents lblQuantity As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents lblUnitPrice As Label
    Friend WithEvents txtUnitPrice As TextBox
    Friend WithEvents cbFlatPrice As CheckBox
    Friend WithEvents btnCalculate As Button
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnLeft As Button
    Friend WithEvents btnRight As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
